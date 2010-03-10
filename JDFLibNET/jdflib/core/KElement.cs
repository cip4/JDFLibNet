/* 
 * The CIP4 Software License, Version 1.0
 *
 *
 * Copyright (c) 2001-2009 The International Cooperation for the Integration of
 * Processes in  Prepress, Press and Postpress (CIP4).  All rights
 * reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions
 * are met:
 *
 * 1. Redistributions of source code must retain the above copyright
 *    notice, this list of conditions and the following disclaimer.
 *
 * 2. Redistributions in binary form must reproduce the above copyright
 *    notice, this list of conditions and the following disclaimer in
 *    the documentation and/or other materials provided with the
 *    distribution.
 *
 * 3. The end-user documentation included with the redistribution,
 *    if any, must include the following acknowledgment:
 *       "This product includes software developed by the
 *        The International Cooperation for the Integration of
 *        Processes in  Prepress, Press and Postpress (www.cip4.org)"
 *    Alternately, this acknowledgment may appear in the software itself,
 *    if and wherever such third-party acknowledgments normally appear.
 *
 * 4. The names "CIP4" and "The International Cooperation for the Integration of
 *    Processes in  Prepress, Press and Postpress" must
 *    not be used to endorse or promote products derived from this
 *    software without prior written permission. For written
 *    permission, please contact info@cip4.org.
 *
 * 5. Products derived from this software may not be called "CIP4",
 *    nor may "CIP4" appear in their name, without prior written
 *    permission of the CIP4 organization
 *
 * Usage of this software in commercial products is subject to restrictions. For
 * details please consult info@cip4.org.
 *
 * THIS SOFTWARE IS PROVIDED ``AS IS'' AND ANY EXPRESSED OR IMPLIED
 * WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES
 * OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED.  IN NO EVENT SHALL THE INTERNATIONAL COOPERATION FOR
 * THE INTEGRATION OF PROCESSES IN PREPRESS, PRESS AND POSTPRESS OR
 * ITS CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
 * SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
 * LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF
 * USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
 * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
 * OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT
 * OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF
 * SUCH DAMAGE.
 * ====================================================================
 *
 *
 * This software consists of voluntary contributions made by many
 * individuals on behalf of the The International Cooperation for the Integration
 * of Processes in Prepress, Press and Postpress and was
 * originally based on software
 * copyright (c) 1999-2001, Heidelberger Druckmaschinen AG
 * copyright (c) 1999-2001, Agfa-Gevaert N.V.
 *
 * For more information on The International Cooperation for the
 * Integration of Processes in  Prepress, Press and Postpress , please see
 * <http://www.cip4.org/>.
 */

namespace org.cip4.jdflib.core
{
   using System;
   using System.Runtime.CompilerServices;
   using System.Collections;
   using System.Collections.Generic;
   using System.Text;
   using System.IO;
   using System.Xml;
   using System.Xml.Serialization;


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;
   using EnumAttributeType = org.cip4.jdflib.core.AttributeInfo.EnumAttributeType;
   using EnumVersion = org.cip4.jdflib.core.JDFElement.EnumVersion;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using JDFResourcePool = org.cip4.jdflib.pool.JDFResourcePool;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using StringUtil = org.cip4.jdflib.util.StringUtil;

   ///
   /// <summary> * 
   /// * KElement wraps Element and contains some generic utilities.<br>
   /// * Every access to a Element should be wrapped using KElement.<br>
   /// * KElement is completely agnostic to JDF.<br>
   /// * Typically elements in non-JDF namespaces will be KElements.<br>
   /// * <br>
   /// * note that it is discouraged to mix direct calls to Dom Element and KElement routines a future version will most
   /// * likely contain a private ElementNSImpl rather than inherit from it. The current extension solution is a work around
   /// * around a xerces bug
   /// * 
   /// * @author CIP4 </summary>
   /// * <seealso cref= JDFElement for the first element class that is aware of JDF </seealso>
   /// 
   public class KElement : XmlElement
   {
      public const long serialVersionUID = 1L;
      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[1];

      static KElement()
      {
         atrInfoTable[0] = new AtrInfoTable(JDFConstants.XMLNS, 0x33333333, AttributeInfo.EnumAttributeType.URI, null, null);
      }

      protected internal virtual AttributeInfo getTheAttributeInfo()
      {
         AttributeInfo ai = new AttributeInfo(atrInfoTable);
         ai.setVersion(EnumVersion.getEnum(this.getInheritedAttribute(AttributeName.VERSION, null, null)));
         return ai;
      }

      ///   
      ///	 <summary> * returns the data type of a given attribute
      ///	 *  </summary>
      ///	 * <param name="attributeName"> the localname of the attribute to check </param>
      ///	 * <returns> the data type of attributeName </returns>
      ///	 
      public virtual EnumAttributeType getAtrType(string attributeName)
      {
         AttributeInfo ai = getTheAttributeInfo();
         return ai.getAttributeType(attributeName);
      }

      ///   
      ///	 <summary> * get the first JDF version where attribute name or element name is valid
      ///	 *  </summary>
      ///	 * <param name="eaName"> attribute name </param>
      ///	 * <param name="bElement"> true - get ElementInfo, false - get AttributeInfo </param>
      ///	 * <returns> JDF version, Version_1_0 if no Info is found </returns>
      ///	 
      public virtual EnumVersion getFirstVersion(string eaName, bool bElement)
      {
         EnumVersion v = null;
         if (bElement)
         {
            ElementInfo ei = getTheElementInfo();
            v = ei.getFirstVersion(eaName);
         }
         else
         {
            AttributeInfo ai = getTheAttributeInfo();
            v = ai.getFirstVersion(eaName);
         }
         if (v == null)
         {
            v = EnumVersion.Version_1_0;
         }
         return v;
      }

      ///   
      ///	 <summary> * get the last JDF version where attribute name or element name is valid
      ///	 *  </summary>
      ///	 * <param name="eaName"> attribute name </param>
      ///	 * <param name="bElement"> true - get ElementInfo, false - get AttributeInfo </param>
      ///	 * <returns> JDF version, Version_1_0 if no Info is found </returns>
      ///	 
      public virtual EnumVersion getLastVersion(string eaName, bool bElement)
      {
         EnumVersion v = null;
         if (bElement)
         {
            ElementInfo ei = getTheElementInfo();
            v = ei.getLastVersion(eaName);
         }
         else
         {
            AttributeInfo ai = getTheAttributeInfo();
            v = ai.getLastVersion(eaName);
         }
         return v;
      }

      protected internal virtual ElementInfo getTheElementInfo()
      {
         ElementInfo ei = new ElementInfo(null, null);
         ei.setVersion(EnumVersion.getEnum(this.getInheritedAttribute(AttributeName.VERSION, null, null)));
         return ei;
      }

      ///   
      ///	 <summary> * Constructor for KElement
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> the owner document of the new element </param>
      ///	 * <param name="qualifiedName"> the qualified name of the element </param>
      ///	 
      public KElement(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(xmlnsPrefix(qualifiedName), xmlnsLocalName(qualifiedName), null, myOwnerDocument)
      {
      }

      ///   
      ///	 <summary> * Constructor for KElement
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> the owner document of the new element </param>
      ///	 * <param name="myNamespaceURI"> the namespace of the new element </param>
      ///	 * <param name="qualifiedName"> the qualified name of the element </param>
      ///	 
      public KElement(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(xmlnsPrefix(qualifiedName), xmlnsLocalName(qualifiedName), myNamespaceURI, myOwnerDocument)
      {
      }

      ///   
      ///	 <summary> * Constructor for KElement
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> the owner document of the new element </param>
      ///	 * <param name="myNamespaceURI"> the namespace of the new element </param>
      ///	 * <param name="qualifiedName"> the qualified name of the element </param>
      ///	 * <param name="myLocalName"> the localname of the element </param>
      ///	 
      public KElement(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(xmlnsPrefix(qualifiedName), myLocalName, myNamespaceURI, myOwnerDocument)
      {
      }

      /// <summary> Encoding.  </summary>
      private const string sm_strENCODING = "UTF-8"; // faster: "US-ASCII"

      // ************************** start of directly dependend methods
      // ***********

      ///   
      ///	 <summary> * Get the dirty status of this element
      ///	 *  </summary>
      ///	 * <returns> boolean true if dirty </returns>
      ///	 
      public virtual bool isDirty()
      {
         XMLDocUserData usrDat = getXMLDocUserData();
         if (usrDat != null)
         {
            return usrDat.isDirty(this);
         }
         return false;
      }

      ///   
      ///	 <summary> * Set this element as dirty
      ///	 *  </summary>
      ///	 * @deprecated use setDirty (bAttribute) 
      ///	 
      [Obsolete("use setDirty (bAttribute)")]
      public virtual void setDirty()
      {
         setDirty(false);
      }

      ///   
      ///	 <summary> * Set this element as dirty </summary>
      ///	 * <param name="bAttribute"> if true, only attributes are dirty, else also sub-elements </param>
      ///	 
      public virtual void setDirty(bool bAttribute)
      {
         XMLDocUserData usrDat = getXMLDocUserData();
         if (usrDat != null)
         {
            usrDat.setDirty(this, bAttribute);
         }
      }

      ///   
      ///	 <summary> * Get the document object that owns this
      ///	 *  </summary>
      ///	 * <returns> XMLDoc the owner document of this </returns>
      ///	 
      public virtual XMLDoc getOwnerDocument_KElement()
      {
         XmlDocument doc = OwnerDocument;
         return new XMLDoc(doc);
      }

      ///   
      ///	 <summary> * searches for the first attribute occurence in this element or any ancestors
      ///	 *  </summary>
      ///	 * <param name="attrib"> the attribute name </param>
      ///	 * <param name="nameSpaceURI"> the XML-namespace </param>
      ///	 * <param name="def"> the default if it does not exist
      ///	 *  </param>
      ///	 * <returns> String value of attribute found, value of def if not available
      ///	 * 
      ///	 * @default getInheritedAttribute(attrib, null, JDFConstants.EMPTYSTRING) </returns>
      ///	 
      public virtual string getInheritedAttribute(string attrib, string nameSpaceURI, string def)
      {
         return getInheritedAttribute_KElement(attrib, nameSpaceURI, def);
      }

      ///   
      ///	 <summary> * searches for the first attribute occurence in this element or any ancestors
      ///	 *  </summary>
      ///	 * <param name="attrib"> the attribute name </param>
      ///	 * <param name="nameSpaceURI"> the XML-namespace </param>
      ///	 * <param name="def"> the default if it does not exist
      ///	 *  </param>
      ///	 * <returns> String value of attribute found, value of def if not available
      ///	 * 
      ///	 * @default getInheritedAttribute_KElement(attrib, null, JDFConstants.EMPTYSTRING) </returns>
      ///	 
      private string getInheritedAttribute_KElement(string attrib, string nameSpaceURI, string def)
      {
         string strRet = getAttribute_KElement(attrib, nameSpaceURI, null);

         if (strRet == null)
         {
            KElement parentNode = getParentNode_KElement();
            if (parentNode != null)
            {
               strRet = parentNode.getInheritedAttribute(attrib, nameSpaceURI, def);
            }
         }
         return strRet == null ? def : strRet;
      }

      ///   
      ///	 <summary> * mother of all attribute getters. Get a attribute out of this element
      ///	 *  </summary>
      ///	 * <param name="attrib"> the name of the attribute you want to have </param>
      ///	 * <param name="nameSpaceURI"> namespace of key </param>
      ///	 * <param name="def"> the value that is returned if attrib does not exist in this or this is null
      ///	 *  </param>
      ///	 * <returns> String the attribute value as a string, or def if that attribute does not have a specified or default
      ///	 *         value
      ///	 * 
      ///	 * @default GetAttribute(attrib, null, JDFConstants.EMPTYSTRING) </returns>
      ///	 
      public virtual string getAttribute(string attrib, string nameSpaceURI, string def)
      {
         return getAttribute_KElement(attrib, nameSpaceURI, def);
      }

      ///   
      ///	 <summary> * Because getAttribute is overwritten in various classes this method can be called directly to get only KElement
      ///	 * Attribute.
      ///	 *  </summary>
      ///	 * <param name="attrib"> the name of the attribute you want to have </param>
      ///	 * <param name="nameSpaceURI"> namespace of key </param>
      ///	 * <param name="def"> the value that is returned if attrib does not exist in this - may be null
      ///	 *  </param>
      ///	 * <returns> String the attribute value as a string, or def if attribute was not found<br>
      ///	 * <br>
      ///	 * 
      ///	 * @default getAttribute_KElement(attrib, null,null) </returns>
      ///	 
      public virtual string getAttribute_KElement(string attrib, string nameSpaceURI, string def)
      {
         XmlAttribute attribute = getDOMAttr(attrib, nameSpaceURI, false);
         return (attribute == null) ? def : attribute.Value;
         // switch for null defaults return JDFConstants.EMPTYSTRING.equals(def)
         // ? null : def;
      }

      ///   
      ///	 <summary> * Mother of all attribute getters <br>
      ///	 * Gets an attribute value out of an element
      ///	 *  </summary>
      ///	 * <param name="strLocalName"> the name of the attribute you want to have
      ///	 *  </param>
      ///	 * <returns> String the value of the Attribute or emptystring </returns>
      ///	 
      public string getAttribute(string strLocalName)
      {
         return getAttribute(strLocalName, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * Mother of all attribute getters <br>
      ///	 * Gets an attribute value out of an element
      ///	 *  </summary>
      ///	 * <param name="strLocalName"> the name of the attribute you want to have
      ///	 *  </param>
      ///	 * <returns> String the value of the Attribute or emptystring </returns>
      ///	 
      public virtual string getAttribute_KElement(string strLocalName)
      {
         return getAttribute_KElement(strLocalName, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * get the parent node of this
      ///	 *  </summary>
      ///	 * <returns> KElement the parent node of the actual element </returns>
      ///	 
      public virtual KElement getParentNode_KElement()
      {
         XmlNode parentNode = ParentNode;
         if (parentNode is KElement)
         {
            return (KElement)parentNode;
         }
         return null;
      }

      // ************************** end of directly dependend methods
      // *************
      ///////
      ///////
      // ************************** start of methods needed in core
      // ***************
      // ************************** methods needed in JDFElement, JDFNodeInfo,
      // XMLD

      ///   
      ///	 <summary> * Enumeration for validation level <br>
      ///	 * <blockquote>
      ///	 * <ul>
      ///	 * <li>level ValidationLevel_NoWarnIncomplete: Ignore warnings and don't require all required parameters <br>
      ///	 * <li>level ValidationLevel_NoWarnComplete: Ignore warnings and require all required parameters <br>
      ///	 * <li>level ValidationLevel_Incomplete: incomplete elements are valid <br>
      ///	 * <li>level ValidationLevel_Complete: full validation of an individual resource <br>
      ///	 * <li>level ValidationLevel_RecursiveIncomplete: incomplete validation of an individual resource and all of its
      ///	 * child elements - e.g. for pools <br>
      ///	 * <li>level ValidationLevel_RecursiveComplete: full validation of an individual resource and all of its child
      ///	 * elements - e.g. for pools <br>
      ///	 * </ul>
      ///	 * </blockquote> </summary>
      ///	 
      public sealed class EnumValidationLevel : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumValidationLevel(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumValidationLevel getEnum(string enumName)
         {
            return (EnumValidationLevel)getEnum(typeof(EnumValidationLevel), enumName);
         }

         public static EnumValidationLevel getEnum(int enumValue)
         {
            return (EnumValidationLevel)getEnum(typeof(EnumValidationLevel), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumValidationLevel));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumValidationLevel));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumValidationLevel));
         }

         ///      
         ///		 <summary> * return true if vl is a recursvive EnumValidationLevel
         ///		 *  </summary>
         ///		 * <param name="vl"> the EnumValidationLevel to check </param>
         ///		 * <returns> true if vl is recursive </returns>
         ///		 
         public static bool isRecursive(EnumValidationLevel vl)
         {
            return EnumValidationLevel.RecursiveIncomplete.Equals(vl) || EnumValidationLevel.RecursiveComplete.Equals(vl);
         }

         ///      
         ///		 <summary> * return true if vl is a recursvive EnumValidationLevel
         ///		 *  </summary>
         ///		 * <param name="vl"> the EnumValidationLevel to check </param>
         ///		 * <returns> true if vl is recursive </returns>
         ///		 
         public static bool isNoWarn(EnumValidationLevel vl)
         {
            return EnumValidationLevel.NoWarnComplete.Equals(vl) || EnumValidationLevel.NoWarnIncomplete.Equals(vl);
         }

         ///      
         ///		 <summary> * returns true if the enumeration level is either Complete, NoWarnComplete or RecursiveComplete, i.e. if the
         ///		 * parameter is required
         ///		 *  </summary>
         ///		 * <param name="level"> the level to check </param>
         ///		 * <returns> true if required </returns>
         ///		 
         public static bool isRequired(EnumValidationLevel vl)
         {
            return EnumValidationLevel.Complete.Equals(vl) || EnumValidationLevel.RecursiveComplete.Equals(vl) || EnumValidationLevel.NoWarnComplete.Equals(vl);
         }

         public static readonly EnumValidationLevel NoWarnIncomplete = new EnumValidationLevel("NoWarnIncomplete");

         public static readonly EnumValidationLevel NoWarnComplete = new EnumValidationLevel("NoWarnComplete");

         public static readonly EnumValidationLevel Incomplete = new EnumValidationLevel(JDFConstants.VALIDATIONLEVEL_INCOMPLETE);

         public static readonly EnumValidationLevel Complete = new EnumValidationLevel(JDFConstants.VALIDATIONLEVEL_COMPLETE);

         public static readonly EnumValidationLevel RecursiveIncomplete = new EnumValidationLevel(JDFConstants.VALIDATIONLEVEL_RECURSIVEINCOMPLETE);

         public static readonly EnumValidationLevel RecursiveComplete = new EnumValidationLevel(JDFConstants.VALIDATIONLEVEL_RECURSIVECOMPLETE);

         ///      
         ///		 <summary> * 
         ///		 * calculate the corresponding nowarn level based on level
         ///		 *  </summary>
         ///		 * <param name="noWarning"> if true, set to nowarne, else set to standard
         ///		 * @return </param>
         ///		 
         public static EnumValidationLevel setNoWarning(EnumValidationLevel level, bool noWarning)
         {
            EnumValidationLevel levelLocal = level;

            if (noWarning && !isNoWarn(levelLocal))
               levelLocal = isRequired(levelLocal) ? EnumValidationLevel.NoWarnComplete : EnumValidationLevel.NoWarnIncomplete;

            if (!noWarning && isNoWarn(levelLocal))
               levelLocal = isRequired(levelLocal) ? EnumValidationLevel.Complete : EnumValidationLevel.Incomplete;

            return levelLocal;
         }

         ///      
         ///		 <summary> * calculate the corresponding incomplete level based on level
         ///		 *  </summary>
         ///		 * <param name="level"> the level to test </param>
         ///		 * <returns> EnumValidationLevel - the modified level </returns>
         ///		 
         public static EnumValidationLevel incompleteLevel(EnumValidationLevel level)
         {
            EnumValidationLevel levelLocal = level;

            if (EnumValidationLevel.Complete.Equals(levelLocal))
            {
               levelLocal = EnumValidationLevel.Incomplete;
            }
            else if (EnumValidationLevel.RecursiveComplete.Equals(levelLocal))
            {
               levelLocal = EnumValidationLevel.RecursiveIncomplete;
            }
            else if (EnumValidationLevel.NoWarnComplete.Equals(levelLocal))
            {
               levelLocal = EnumValidationLevel.NoWarnIncomplete;
            }
            return levelLocal;
         }
      }

      ///   
      ///	 * @deprecated use local EnumValidationLevel enums 
      ///	 
      [Obsolete("use local EnumValidationLevel enums")]
      public static readonly EnumValidationLevel ValidationLevel_Incomplete = EnumValidationLevel.Incomplete;

      ///   
      ///	 * @deprecated use local EnumValidationLevel enums 
      ///	 
      [Obsolete("use local EnumValidationLevel enums")]
      public static readonly EnumValidationLevel ValidationLevel_Complete = EnumValidationLevel.Complete;

      ///   
      ///	 * @deprecated use local EnumValidationLevel enums 
      ///	 
      [Obsolete("use local EnumValidationLevel enums")]
      public static readonly EnumValidationLevel ValidationLevel_RecursiveIncomplete = EnumValidationLevel.RecursiveIncomplete;

      ///   
      ///	 * @deprecated use local EnumValidationLevel enums 
      ///	 
      [Obsolete("use local EnumValidationLevel enums")]
      public static readonly EnumValidationLevel ValidationLevel_RecursiveComplete = EnumValidationLevel.RecursiveComplete;

      ///   
      ///	 <summary> * Sets an NMTOKENS attribute to all elements from parameter value will be concatenate with blanks to the resulting
      ///	 * NMTOKEN
      ///	 *  </summary>
      ///	 * <param name="key"> the name of the attribute to set </param>
      ///	 * <param name="value"> the values for the attribute key </param>
      ///	 * <param name="nameSpaceURI"> the namespace of the key </param>
      ///	 * @deprecated use setAttribute instead
      ///	 * 
      ///	 * @default setvStringAttribute(key, vStr, null) 
      ///	 
      [Obsolete("use setAttribute instead")]
      public virtual void setvStringAttribute(string key, VString @value, string nameSpaceURI)
      {
         setAttribute(key, @value, nameSpaceURI);
      }

      ///   
      ///	 <summary> * Sets an NMTOKENS attribute to all elements from parameter value will be concatenate with blanks to the resulting
      ///	 * NMTOKEN
      ///	 *  </summary>
      ///	 * <param name="key"> the name of the attribute to set </param>
      ///	 * <param name="value"> the values for the attribute key </param>
      ///	 * <param name="nameSpaceURI"> the namespace of the key
      ///	 * 
      ///	 * @default setvStringAttribute(key, vStr, null) </param>
      ///	 
      public virtual void setAttribute(string key, VString @value, string nameSpaceURI)
      {
         string s = StringUtil.setvString(@value);
         setAttribute(key, s, nameSpaceURI);
      }

      ///   
      ///	 <summary> * Get The DOM Attribute node of a given attribute if attrib has no namespace prefix and nameSpaceURI is a wildcard
      ///	 * the attribute with the element prefix will be returned if no empty attribute exists e.g. getDOMAttr("a") will
      ///	 * return the node x:a in &lt;x:e x:a="b"/&gt;
      ///	 *  </summary>
      ///	 * <param name="attrib"> the attribute Name </param>
      ///	 * <param name="nameSpaceURI"> then namespaceURI, defaults to the local namespace </param>
      ///	 * <param name="bInherit"> search in parent elements as well </param>
      ///	 * <returns> Node the DOMAttr node of the matching attribute </returns>
      ///	 
      public virtual XmlAttribute getDOMAttr(string attrib, string nameSpaceURI, bool bInherit)
      {
         string nameSpaceURILocal = nameSpaceURI;

         XmlAttribute a = null;
         if ((nameSpaceURILocal == null) || nameSpaceURILocal.Equals(JDFConstants.EMPTYSTRING))
         {
            a = this.GetAttributeNode(attrib);
            if (a != null)
            {
               return a;
            }

            nameSpaceURILocal = null;

            string attribPrefix = xmlnsPrefix(attrib);
            string elementPrefix = Prefix;
            if (!String.IsNullOrEmpty(elementPrefix) && attribPrefix != null && attribPrefix.Equals(elementPrefix))
            { // has attribute prefix
               a = GetAttributeNode(attrib.Substring(elementPrefix.Length + 1));
            }
            else if (!String.IsNullOrEmpty(elementPrefix) && attribPrefix == null)
            {
               a = GetAttributeNode(elementPrefix + JDFConstants.COLON + attrib);
            }

            if ((a == null) && !attrib.StartsWith(JDFConstants.XMLNS))
            {
               nameSpaceURILocal = getNamespaceURIFromPrefix(attribPrefix);
            }
         }

         // either we have an explicit ns or we haven't found anything in dom
         // level 1 - assume the namespace of this
         if ((a == null) && (nameSpaceURILocal != null))
         {
            // the xmlNSLocalName here is just in case - actually you shouldn't
            // be calling both ns and prefix
            a = GetAttributeNode(KElement.xmlnsLocalName(attrib), nameSpaceURILocal);
            if ((a == null) && nameSpaceURILocal.Equals(getNamespaceURI()))
            {
               a = GetAttributeNode(KElement.xmlnsLocalName(attrib));
            }

         }

         if (a == null && bInherit)
         {
            KElement parent = getParentNode_KElement();
            if (parent != null)
            {
               return parent.getDOMAttr(attrib, nameSpaceURILocal, bInherit);
            }
         }

         return a;
      }

      ///   
      ///	 <summary> * Mother of all Attribute setters <br>
      ///	 * Sets a new attribute. If an attribute with that name is already present in the element, its value is changed to
      ///	 * be that of the value parameter. This value is a simple string; it is not parsed as it is being set. So any markup
      ///	 * (such as syntax to be recognized as an entity reference) is treated as literal text, and needs to be
      ///	 * appropriately escaped by the implementation when it is written out. In order to assign an attribute value that
      ///	 * contains entity references, the user must create an Attr node plus any Text and EntityReference nodes, build the
      ///	 * appropriate subtree, and use setAttributeNode to assign it as the value of an attribute. To set an attribute with
      ///	 * a qualified name and namespace URI, use the setAttributeNS method.
      ///	 *  </summary>
      ///	 * <param name="key"> the qualified name of the attribute to create or alter. </param>
      ///	 * <param name="value"> the value to set in string form. If null, the attribute is removed </param>
      ///	 * <param name="nameSpaceURI"> the namespace the element is in </param>
      ///	 * <exception cref="JDFException"> if no settings of its attributes are possible </exception>
      ///	 
      public virtual void setAttribute(string key, string @value, string nameSpaceURI)
      {
         string nameSpaceURILocal = nameSpaceURI;

         bool bDirty = false;
         if (@value == null)
         {
            removeAttribute(key, nameSpaceURILocal);
            return;
         }

         if ((nameSpaceURILocal == null) || (nameSpaceURILocal.Equals(JDFConstants.EMPTYSTRING)))
         { // //////////// DOM Level 1 ///////////////////
            // must explicitely set xmlns as DOM level 2 because the xerces
            // serializer checks for DOM level 2
            // xmlns attributes and avoids duplicate serialization of the
            // attribute and namespace nodes
            if (key.StartsWith(JDFConstants.XMLNS) && (key.Length == 5 || key[5] == ':'))
            { // set an attribute which is a namespace
               if (@value.Equals(JDFConstants.EMPTYSTRING))
               {
                  XmlNode a = GetAttributeNode(key);
                  // never ever set "xmlns:foo="" !
                  if (a != null)
                  {
                     bDirty = true;
                     removeAttribute(key);
                  }
               }
               else if (!@value.Equals(getInheritedAttribute(key, null, null)))
               {
                  bDirty = true;
                  SetAttribute(key, @value);
                  // Java to C# Conversion - Question - What is the point of this constant Namspace value, 
                  //    when setting this namespace attribute value?
                  // super.setAttributeNS(AttributeName.XMLNSURI, key, value);
                  ((DocumentJDFImpl)OwnerDocument).setIgnoreNSDefault(false);
               }
            }
            else
            { // set a normal attribute
               string attributePrefix = xmlnsPrefix(key);
               if (attributePrefix == null)
               { // no attribute prefix, put the attribute in the default
                  // namespace
                  bDirty = true;
                  SetAttribute(key, @value);
               }
               else
               { // try to find a namespace
                  string namespaceURI2 = getNamespaceURIFromPrefix(attributePrefix);
                  if (namespaceURI2 != null)
                  {
                     // now we have a namespace --> recurse
                     setAttribute(key, @value, namespaceURI2);
                  }
                  else
                  {
                     // attribute with prefix, no namespace found
                     XmlNode a = getDOMAttr(key, null, false);
                     if (a == null || !@value.Equals(a.Value))
                     {
                        bDirty = true;
                        if (a != null)
                        {
                           string nodeName = a.Name;

                           // don't search the attribute node if it is
                           // already there
                           if (key.Equals(nodeName))
                           { // overwrite default namespace with qualified
                              // namespace or vice versa
                              removeAttribute(nodeName);
                              SetAttribute(key, @value);
                           }
                           else
                           { // same qualified name, simply overwrite the
                              // value
                              a.Value = @value;
                           }
                        }
                        else
                        {
                           string nsURI2 = getNamespaceURIFromPrefix(xmlnsPrefix(key));
                           if ((nsURI2 != null) && !nsURI2.Equals(nameSpaceURILocal))
                           {
                              throw new JDFException("KElement.setAttribute: inconsistent namespace URI for prefix: " + xmlnsPrefix(key) + "; existing URI: " + nsURI2 + "; attempting to set URI: " + nameSpaceURILocal);
                           }
                           try
                           {
                              SetAttribute(key, nsURI2, @value);
                           }
                           catch (Exception)
                           {
                              // we punt here because it wil hopefully
                              // only be an ordering problem
                              SetAttribute(key, @value);
                           }
                        }
                     }
                  }
               }
            }
         }
         else
         { // //////////// DOM Level 2 ///////////////////
            if (AttributeName.XMLNSURI.Equals(nameSpaceURILocal))
            {
               // never ever set "xmlns:foo="" !
               if (@value.Equals(JDFConstants.EMPTYSTRING))
               {
                  bDirty = true;
                  removeAttributeNS(nameSpaceURILocal, key);
               }
               else if (!@value.Equals(getInheritedAttribute(xmlnsLocalName(key), nameSpaceURILocal, null)))
               {
                  bDirty = true;
                  SetAttribute(key, AttributeName.XMLNSURI, @value);
               }
            }
            else
            // standard attribute (not xmlns)
            {
               XmlNode a = this.GetAttributeNode(xmlnsLocalName(key), nameSpaceURILocal);
               if (a == null || !@value.Equals(a.Value))
               {
                  bDirty = true;
                  if (a != null)
                  { // don't search the attribute node if it is already there
                     string nodeName = a.Name;

                     if (!key.Equals(nodeName))
                     { // overwrite default namespace with qualified
                        // namespace or vice versa
                        SetAttribute(key, nameSpaceURILocal, @value);
                     }
                     else
                     { // same qualified name, simply overwrite the value
                        a.Value = @value;
                     }
                  }
                  else
                  {
                     string namespaceURI2 = getNamespaceURIFromPrefix(xmlnsPrefix(key));

                     if (namespaceURI2 != null && !JDFConstants.EMPTYSTRING.Equals(namespaceURI2) && !namespaceURI2.Equals(nameSpaceURILocal))
                     { // in case multiple namespace uris are defined for the
                        // same prefix,
                        // all we can do is to bail out loudly
                        throw new JDFException("KElement.setAttribute: inconsistent namespace URI for prefix: " + xmlnsPrefix(key) + "; existing URI: " + namespaceURI2 + "; attempting to set URI: " + nameSpaceURILocal);
                     }

                     // remove any twin dom lvl 1 attributes - just in case
                     removeAttribute(key);
                     if (nameSpaceURILocal.Equals(getNamespaceURI()))
                     {
                        // clean up any attribute that may be in the same ns
                        // but with a different prefix
                        removeAttributeNS(nameSpaceURILocal, xmlnsLocalName(key));
                        if (xmlnsPrefix(key) == null)
                        {
                           nameSpaceURILocal = null; // avoid spurios NS1 prefix
                        }
                     }
                     SetAttribute(key, nameSpaceURILocal, @value);
                  }
               }
            }
         }

         if (bDirty)
         {
            setDirty(true);
         }
      }
      /// <summary>
      /// SetAttribute that allows a prefix and a namespace.
      /// </summary>
      /// <param name="name"> the qualified name of the attribute to create or alter. </param>
      /// <param name="namespaceURI"> the namespace the element is in </param>
      /// <param name="value"> the value to set in string form. If null, the attribute is removed </param>
      /// <returns>The value of the specified attribute. An empty string is returned if a matching
      /// attribute is not found or if the attribute does not have a specified or default value.</returns>
      /// <remarks>Use setAttribute and not SetAttribute.</remarks>
      public override string SetAttribute(string key, string namespaceURI, string value)
      {
         string prefix = xmlnsPrefix(key);
         if (String.IsNullOrEmpty(prefix))
         {
            return base.SetAttribute(key, namespaceURI, value);
         }
         else
         {
            XmlAttribute attr = SetAttributeNode(xmlnsLocalName(key), namespaceURI);
            if (attr != null)
            {
               attr.Prefix = prefix;
               attr.Value = value;
               return attr.Value;
            }
         }
         return JDFConstants.EMPTYSTRING;
      }
      ///   
      ///	 <summary> * no namespace variant
      ///	 *  </summary>
      ///	 * <param name="key"> name of the attribute to set </param>
      ///	 * <param name="value"> value of the attribute </param>
      ///	 
      public void setAttribute(string key, string @value)
      {
         setAttribute(key, @value, null);
      }

      ///   
      ///	 <summary> * fastest setAttribute - use only if you know exactly what you are doing
      ///	 *  </summary>
      ///	 * <param name="key"> name of the attribute to set </param>
      ///	 * <param name="value"> value of the attribute </param>
      ///	 
      public virtual void setAttributeRaw(string key, string @value)
      {
         SetAttribute(key, @value);
      }

      ///   
      ///	 <summary> * Sets an element attribute
      ///	 *  </summary>
      ///	 * <param name="key"> the name of the attribute to set </param>
      ///	 * <param name="value"> the value for the attribute </param>
      ///	 * <param name="nameSpaceURI"> the namespace the element is in </param>
      ///	 * @deprecated use setAttribute instead
      ///	 * 
      ///	 * @default SetAttribute(key, value, null) 
      ///	 
      [Obsolete("use setAttribute instead")]
      public virtual void setIntAttribute(string key, int @value, string nameSpaceURI)
      {
         setAttribute(key, @value, nameSpaceURI);
      }

      ///   
      ///	 <summary> * Sets an element attribute
      ///	 *  </summary>
      ///	 * <param name="key"> the name of the attribute to set </param>
      ///	 * <param name="value"> the value for the attribute </param>
      ///	 * <param name="nameSpaceURI"> the namespace the element is in
      ///	 * 
      ///	 * @default SetAttribute(key, value, null) </param>
      ///	 
      public virtual void setAttribute(string key, int @value, string nameSpaceURI)
      {
         setAttribute(key, StringUtil.formatInteger(@value), nameSpaceURI);
      }

      ///   
      ///	 <summary> * Sets an element attribute
      ///	 *  </summary>
      ///	 * <param name="key"> the name of the attribute to set </param>
      ///	 * <param name="value"> the value for the attribute </param>
      ///	 * <param name="nameSpaceURI"> the namespace the element is in </param>
      ///	 * @deprecated use setAttribute instead
      ///	 * 
      ///	 * @default setAttribute(key, value, null) 
      ///	 
      [Obsolete("use setAttribute instead")]
      public virtual void setRealAttribute(string key, double @value, string nameSpaceURI)
      {
         setAttribute(key, StringUtil.formatDouble(@value), nameSpaceURI);
      }

      ///   
      ///	 <summary> * Sets an element attribute
      ///	 *  </summary>
      ///	 * <param name="key"> the name of the attribute to set </param>
      ///	 * <param name="value"> the value for the attribute </param>
      ///	 * <param name="nameSpaceURI"> the namespace the element is in
      ///	 * 
      ///	 * @default setAttribute(key, value, null) </param>
      ///	 
      public virtual void setAttribute(string key, double @value, string nameSpaceURI)
      {
         setAttribute(key, StringUtil.formatDouble(@value), nameSpaceURI);
      }

      ///   
      ///	 <summary> * SetAttribute - Sets an element attribute
      ///	 *  </summary>
      ///	 * <param name="key"> the name of the attribute to set </param>
      ///	 * <param name="b"> value of the boolean attribute to be set (true or false) </param>
      ///	 * <param name="nameSpaceURI"> the nameSpace the attribute is in </param>
      ///	 * @deprecated use setAttribute instead
      ///	 * 
      ///	 * @default setAttribute(key, b, null) 
      ///	 
      [Obsolete("use setAttribute instead")]
      public virtual void setBoolAttribute(string key, bool b, string nameSpaceURI)
      {
         setAttribute(key, b, nameSpaceURI);
      }

      ///   
      ///	 <summary> * SetAttribute - Sets an element attribute
      ///	 *  </summary>
      ///	 * <param name="key"> the name of the attribute to set </param>
      ///	 * <param name="b"> value of the boolean attribute to be set (true or false) </param>
      ///	 * <param name="nameSpaceURI"> the nameSpace the attribute is in
      ///	 * 
      ///	 * @default setAttribute(key, b, null) </param>
      ///	 
      public virtual void setAttribute(string key, bool b, string nameSpaceURI)
      {
         setAttribute(key, b ? JDFConstants.TRUE : JDFConstants.FALSE, nameSpaceURI);
      }

      ///   
      ///	 <summary> * increments or decrements a numeric attribute by inc
      ///	 *  </summary>
      ///	 * <param name="key"> the name of the attribute to set </param>
      ///	 * <param name="inc"> the value to increment or decrement by </param>
      ///	 * <param name="nameSpaceURI"> the nameSpace the attribute is in </param>
      ///	 * <returns> double the attribute value after modification </returns>
      ///	 
      public virtual double addAttribute(string key, double inc, string nameSpaceURI)
      {
         double d = getRealAttribute(key, nameSpaceURI, 0);
         d += inc;
         setAttribute(key, d, NamespaceURI);
         return d;
      }

      ///   
      ///	 <summary> * increments or decrements a numeric attribute by inc
      ///	 *  </summary>
      ///	 * <param name="key"> the name of the attribute to set </param>
      ///	 * <param name="inc"> the value to increment or decrement by </param>
      ///	 * <param name="nameSpaceURI"> the nameSpace the attribute is in </param>
      ///	 * <returns> double the attribute value after modification </returns>
      ///	 
      public virtual int addAttribute(string key, int inc, string nameSpaceURI)
      {
         int i = getIntAttribute(key, nameSpaceURI, 0);
         i += inc;
         setAttribute(key, i, NamespaceURI);
         return i;
      }

      ///   
      ///	 <summary> * Remove a attribute from the current element
      ///	 *  </summary>
      ///	 * <param name="attrib"> attribute name to remove </param>
      ///	 * <param name="nameSpaceURI"> the nameSpace of the attribut
      ///	 * 
      ///	 * @default removeAttribute(attrib, null) </param>
      ///	 
      public virtual void removeAttribute(string attrib, string nameSpaceURI)
      {
         removeAttribute_KElement(attrib, nameSpaceURI);
      }

      ///   
      ///	 <summary> * Remove a attribute from the current element
      ///	 *  </summary>
      ///	 * <param name="attrib"> attribute name to remove </param>
      ///	 * <param name="nameSpaceURI"> the nameSpace of the attribut
      ///	 * 
      ///	 * @default removeAttribute(attrib, null) </param>
      ///	 
      public virtual void removeAttribute_KElement(string attrib, string nameSpaceURI)
      {
         if (hasAttribute(attrib, nameSpaceURI, false))
         {
            if ((nameSpaceURI == null) || nameSpaceURI.Equals(JDFConstants.EMPTYSTRING))
            {
               base.RemoveAttribute(attrib);
            }
            else
            {
               base.RemoveAttribute(xmlnsLocalName(attrib), nameSpaceURI);
               if (nameSpaceURI.Equals(NamespaceURI))
               {
                  //C# and Java are different. Use single parameter RemoveAttribute.
                  base.RemoveAttribute(attrib);
               }
            }
            setDirty(true);
         }
      }

      ///   
      ///	 <summary> * Checks if the actual element has a specific attribute<br>
      ///	 * this version checks within the resource and its partitioned parent xml elements
      ///	 *  </summary>
      ///	 * <param name="attrib"> the name of the attribute to look for
      ///	 *  </param>
      ///	 * <returns> boolean true, if the attribute is present </returns>
      ///	 
      public bool hasAttribute(string attrib)
      {
         return hasAttribute_KElement(attrib, null, false);
      }

      ///   
      ///	 <summary> * Checks if the actual element has a specific attribute <br>
      ///	 * this version checks within the exact xml element
      ///	 *  </summary>
      ///	 * <param name="attrib"> the name of the attribute to look for </param>
      ///	 * <param name="nameSpaceURI"> the nameSpace to look in </param>
      ///	 * <param name="bInherit"> if true also check recursively in parent elements
      ///	 *  </param>
      ///	 * <returns> boolean true if the attribute is present
      ///	 * 
      ///	 * @default hasAttribute(attrib, null, false) </returns>
      ///	 
      public virtual bool hasAttribute(string attrib, string nameSpaceURI, bool bInherit)
      {
         return hasAttribute_KElement(attrib, nameSpaceURI, bInherit);
      }

      ///   
      ///	 <summary> * Checks if the actual element has a specific attribute <br>
      ///	 * this version checks within the exact xml element
      ///	 *  </summary>
      ///	 * <param name="attrib"> the name of the attribute to look for </param>
      ///	 * <param name="nameSpaceURI"> the nameSpace to look in </param>
      ///	 * <param name="bInherit"> if true also check recursively in parent elements
      ///	 *  </param>
      ///	 * <returns> boolean true if the attribute is present
      ///	 * 
      ///	 * @default hasAttribute_KElement(attrib, null, false) </returns>
      ///	 
      public virtual bool hasAttribute_KElement(string attrib, string nameSpaceURI, bool bInherit)
      {
         return getDOMAttr(attrib, nameSpaceURI, bInherit) != null;
      }

      ///   
      ///	 <summary> * Append the contents of value to the existing attribute key. Create Key, if it does not exist
      ///	 *  </summary>
      ///	 * <param name="key"> attribute key </param>
      ///	 * <param name="value"> string to be appended </param>
      ///	 * <param name="nameSpaceURI"> namespace of key </param>
      ///	 * <param name="sep"> separator between the original attribute value and value, defaults to " " if null </param>
      ///	 * <param name="bUnique"> if true, the attribute will only be appended if it is not yet within the current attribute value
      ///	 * 
      ///	 * 
      ///	 * 
      ///	 * 
      ///	 *            appendAttribute("key","next",JDFConstants.EMPTYSTRING,JDFConstants .COMMA) applied to <xml
      ///	 *            key="first"/> results in <xml key="first,next"/>
      ///	 * 
      ///	 * @default appendAttribute(key, value, null, null, false) </param>
      ///	 
      public virtual void appendAttribute(string key, string @value, string nameSpaceURI, string sep, bool bUnique)
      {
         string sepLocal = sep;

         if (@value == null)
         {
            return;
         }

         string oldVal = getAttribute_KElement(key, nameSpaceURI, null);
         if (oldVal == null)
         {
            setAttribute(key, @value, nameSpaceURI);
         }
         else
         // something is there
         {
            if (sepLocal == null)
            {
               sepLocal = JDFConstants.BLANK;
            }

            if (!bUnique || !StringUtil.hasToken(oldVal, @value, sepLocal, 0)) // it
            // is
            // either
            // not
            // unique
            // or
            // not
            // there
            // yet
            // --
            // >
            // append
            {
               setAttribute(key, oldVal + sepLocal + @value, nameSpaceURI);
            }
         }
      }

      ///   
      ///	 <summary> * Tests whether an argument is a wildcard i.e null, empty or * note that Wildcard ("*") is deprecated ideally null
      ///	 * should be used to denote a wildcard
      ///	 *  </summary>
      ///	 * <param name="nodeName"> the argument to test
      ///	 *  </param>
      ///	 * <returns> boolean true if the name is wildcard </returns>
      ///	 
      public static bool isWildCard(string nodeName)
      {
         return (nodeName == null) || (nodeName.Length < 2) && (nodeName.Equals(JDFConstants.EMPTYSTRING) || nodeName.Equals(JDFConstants.STAR));
      }

      ///   
      ///	 <summary> * Tests whether the specified nodename and namespace fits the nodename and namespace of 'this'
      ///	 *  </summary>
      ///	 * <param name="nodeName"> the name of the node to test. May be either local or qualified </param>
      ///	 * <param name="nameSpaceURI"> the namespace of the node to test.
      ///	 *  </param>
      ///	 * <returns> boolean true if fits </returns>
      ///	 
      public virtual bool fitsName(string nodeName, string nameSpaceURI)
      {
         return fitsName_KElement(nodeName, nameSpaceURI);
      }

      protected internal virtual bool fitsName_KElement(string nodeName, string nameSpaceURI)
      {
         bool bNameOK = nodeName == null || isWildCard(nodeName);

         // first check name, since it is faster
         if (!bNameOK)
         {
            string s = Name;
            bNameOK = s.EndsWith(nodeName);
            if (bNameOK && !s.Equals(nodeName) && nodeName != null)
            {
               bNameOK = nodeName.Equals(xmlnsLocalName(s));
            }
         }

         // only check ns, if the name is ok
         if (bNameOK && nameSpaceURI != null && !isWildCard(nameSpaceURI))
         {
            if (!nameSpaceURI.Equals(getNamespaceURI()))
            {
               bNameOK = false;
            }
         }

         return bNameOK;
      }

      ///   
      ///	 <summary> * Gets the NameSpaceURI corresponding to a given prefix, returns null if no namespace is defined
      ///	 *  </summary>
      ///	 * <param name="prefix"> the prefix to check for </param>
      ///	 * <returns> String The nameSpaceURI that maps to prefix </returns>
      ///	 
      public virtual string getNamespaceURIFromPrefix(string prefix)
      {
         string strNamespaceURI = null;
         if (prefix == null || prefix.Equals(JDFConstants.EMPTYSTRING))
         {
            string elementPrefix = Prefix;
            if (String.IsNullOrEmpty(elementPrefix))
            {
               strNamespaceURI = getNamespaceURI();
               if (strNamespaceURI != null)
               {
                  return strNamespaceURI;
               }
            }

            strNamespaceURI = getAttribute(AttributeName.XMLNS, null, null);
            if (strNamespaceURI != null)
            {
               return strNamespaceURI;
            }
         }
         else
         {
            // some well known hardcoded stuff
            if (prefix.Equals(AttributeName.XSI))
            {
               return AttributeName.XSIURI;
            }
            if (prefix.Equals(AttributeName.XMLNS))
            {
               return AttributeName.XMLNSURI;
            }

            string elementPrefix = Prefix;
            if (prefix.Equals(elementPrefix))
            {
               // we are checking an element or attribute with the same prefix
               // as this.
               // therefore we assume that the same NamespaceURI also applies,
               // if it is set
               strNamespaceURI = getNamespaceURI();
               if (!String.IsNullOrEmpty(strNamespaceURI))
               {
                  return strNamespaceURI;
               }
            }

            strNamespaceURI = getAttribute(prefix, AttributeName.XMLNSURI, null);

            // found a decent URI
            if (strNamespaceURI != null)
            {
               return strNamespaceURI;
            }

            XmlNamedNodeMap nl = Attributes;
            int length = nl.Count;
            for (int i = 0; i < length; i++)
            {
               XmlNode at = nl.Item(i);
               if (at is XmlAttribute)
               {
                  XmlAttribute ati = (XmlAttribute)at;
                  if (prefix.Equals(ati.Prefix))
                  {
                     strNamespaceURI = ati.NamespaceURI;
                     if (strNamespaceURI != null)
                     {
                        return strNamespaceURI;
                     }
                  }
               }
            }

            // nothing found, recurse into parent element and try again
            KElement e = getParentNode_KElement();
            if (e != null)
            {
               return e.getNamespaceURIFromPrefix(prefix);
            }
         }

         // we reached the document root and didn't find anything --> punt and
         // return an empty string
         return null;
      }

      /// <summary>
      /// Get the NameSpaceURI.
      /// </summary>
      public override string NamespaceURI
      {
         get { return getNamespaceURI(); }
      }
      ///   
      ///	 <summary> * Get the NameSpaceURI
      ///	 *  </summary>
      ///	 * <returns> String The nameSpaceURI </returns>
      ///	 
      public string getNamespaceURI()
      {
         string s = base.NamespaceURI;
         if ((s != null && s != JDFConstants.EMPTYSTRING) || ((DocumentJDFImpl)OwnerDocument).isIgnoreNSDefault())
         {
            return s;
         }

         s = Prefix;

         KElement parent = getParentNode_KElement();
         while (parent != null)
         {
            string prefix = KElement.xmlnsPrefix(parent.Name);
            if (prefix == null && String.IsNullOrEmpty(s) || prefix != null && prefix.Equals(s))
            {
               string nsuri = parent.getNamespaceURI();
               if (nsuri != null) // we found a valid nsuri so we might as well
               // set it for this
               {
                  // Java to C# Conversion - QUESTION: Do we need to be able to assign value?
                  //this.NamespaceURI = nsuri;
                  return nsuri;
               }
            }
            parent = parent.getParentNode_KElement();
         }

         string nsuri2;

         if (!String.IsNullOrEmpty(s))
         {
            nsuri2 = getInheritedAttribute(JDFConstants.XMLNS + JDFConstants.COLON + s, null, null);
         }
         else
         {
            nsuri2 = getInheritedAttribute(JDFConstants.XMLNS, null, null);
         }
         if (nsuri2 != null) // we found a valid nsuri so we might as well set it
         // for this
         {
            // Java to C# Conversion - QUESTION: Do we need to be able to assign value?
            //NamespaceURI = nsuri2;
         }
         else if (String.IsNullOrEmpty(s))
         {
            // ran into root and no default ns found - ciao from now on
            ((DocumentJDFImpl)OwnerDocument).setIgnoreNSDefault(true);

         }
         return nsuri2;
      }

      ///   
      ///	 <summary> * Parses pc for it's namespace prefix
      ///	 *  </summary>
      ///	 * <param name="nodeName"> string to parse </param>
      ///	 * <returns> String namespace prefix of element - null if no ":" is in nodeName or nodeName starts with ":" </returns>
      ///	 

      public static string xmlnsPrefix(string nodeName)
      {
         if (nodeName != null)
         {
            int posColon = nodeName.IndexOf(':');
            if (posColon > 0)
            {
               return nodeName.Substring(0, posColon);
            }
         }

         return null;
      }

      ///   
      ///	 <summary> * Gets the local name of kElem
      ///	 *  </summary>
      ///	 * @deprecated use getLocalName 
      ///	 * <param name="kElem"> the element to get the LocalName from
      ///	 *  </param>
      ///	 * <returns> String the local name of 'this' </returns>
      ///	 
      [Obsolete("use getLocalName")]
      public static string getLocalNameStatic(KElement kElem)
      {
         return kElem.LocalName;
      }

      ///   
      ///	 <summary> * Sets the attributes from the curent element. If Attributes map is null or empty, zero is returned. otherwhise the
      ///	 * size of the map is returned
      ///	 *  </summary>
      ///	 * <param name="map"> map of attributes to set
      ///	 *  </param>
      ///	 * <returns> int size of the map or zero if empty </returns>
      ///	
      public virtual int setAttributes(JDFAttributeMap map)
      {
         int iRet = 0;
         if (map != null && !map.IsEmpty())
         {
            IEnumerator<string> it = map.Keys.GetEnumerator();
            while (it.MoveNext())
            {
               string key = it.Current;
               string @value = map[key];
               setAttribute(key, @value, null);
            }
            iRet = map.Count;
         }
         return iRet;
      }

      ///   
      ///	 <summary> * Sets the attributes from the curent element to the attributes from kElem. If the Attributes map from kElem is
      ///	 * empty (kElem has no attributes), zero is returned. Otherwhise the size of the map (number of attributes from
      ///	 * kElem) is returned.
      ///	 *  </summary>
      ///	 * <param name="kElem"> the attribute source
      ///	 *  </param>
      ///	 * <returns> int number of elements from kElem </returns>
      ///	 
      public virtual int setAttributes(KElement kElem)
      {
         return setAttributes(kElem, null);
      }

      ///   
      ///	 <summary> * Sets the attributes from the curent element to the attributes from kElem. If the Attributes map from kElem is
      ///	 * empty (kElem has no attributes), zero is returned. Otherwhise the size of the map (number of attributes from
      ///	 * kElem) is returned.
      ///	 *  </summary>
      ///	 * <param name="kElem"> the attribute source
      ///	 *  </param>
      ///	 * <returns> int number of elements from kElem </returns>
      ///	 
      protected internal virtual int setAttributes(KElement kElem, VString ignoreList)
      {
         if (kElem == null)
            return 0;

         KElement parent = null;
         if (kElem is JDFResource)
         {
            parent = kElem.getParentNode_KElement();
            if (parent != null && kElem.Name.Equals(parent.Name))
            {
               JDFResource r = (JDFResource)parent;
               VString il2 = ignoreList;
               if (il2 == null)
               {
                  il2 = new VString();
                  il2.Add(AttributeName.ID);
                  il2.Add(AttributeName.PARTUSAGE);
                  il2.Add(AttributeName.PARTIDKEYS);
                  il2.Add(AttributeName.CLASS);
                  il2.appendUnique(r.getPartIDKeys());
               }

               setAttributes(parent, il2);
            }
         }

         int size = 0;
         XmlNamedNodeMap nm = kElem.Attributes;
         if (nm != null)
         {
            size = nm.Count;
            for (int i = 0; i < size; i++)
            {
               XmlNode a = nm.Item(i);
               if (ignoreList == null || !ignoreList.Contains(a.LocalName))
               {
                  setAttribute(a.Name, a.Value, a.NamespaceURI);
               }
            }
         }

         return size;
      }

      ///   
      ///	 <summary> * Get the Attribute Map of the actual element
      ///	 *  </summary>
      ///	 * <returns> JDFAttributeMap the attribute map of the actual element </returns>
      ///	 
      public virtual JDFAttributeMap getAttributeMap()
      {
         JDFAttributeMap m = new JDFAttributeMap();
         XmlNamedNodeMap nm = Attributes;
         if (nm != null)
         {
            int size = nm.Count;

            for (int i = 0; i < size; i++)
            {
               XmlNode a = nm.Item(i);
               string nodeName = a.Name;
               m.put(nodeName, a.Value);
            }
         }

         return m;
      }

      ///   
      ///	 <summary> * Method init. Superclass of all inits
      ///	 *  </summary>
      ///	 * <returns> boolean true always </returns>
      ///	 
      public virtual bool init()
      {
         return true;
      }

      ///   
      ///	 <summary> *  </summary>
      ///	 * <param name="elementName"> the elementname with namespace prefix "xyz:abc" </param>
      ///	 * <param name="nameSpaceURI"> the namespace of the element "null" is valid if the namespace was specified already above.
      ///	 *            The method will lookup the namespace for you. Performance wise its better to add it nevertheless.
      ///	 *  </param>
      ///	 * <returns> KElement the appended element or null
      ///	 *  </returns>
      ///	 * <exception cref="JDFException"> if you tried to append an element into an unspecified namespace </exception>
      ///	 
      [MethodImpl(MethodImplOptions.Synchronized)]
      public virtual KElement appendElement(string elementName, string nameSpaceURI)
      {
         KElement newChild = createChildFromName(elementName, nameSpaceURI);
         appendChild(newChild);
         setDirty(false);
         newChild.init();
         return newChild;
      }

      ///   
      ///	 <summary> * creates a new child from name and nameSpaceURI and does some heuristics to find a lvl 2 namespace in case of dom
      ///	 * level 1 calls
      ///	 *  </summary>
      ///	 * <param name="elementName"> </param>
      ///	 * <param name="nameSpaceURI"> </param>
      ///	 * <returns> KElement </returns>
      ///	 
      private KElement createChildFromName(string elementName, string nameSpaceURI)
      {
         KElement newChild = null;
         DocumentJDFImpl ownerDoc = (DocumentJDFImpl)OwnerDocument;

         if (nameSpaceURI == null || JDFConstants.EMPTYSTRING.Equals(nameSpaceURI))
         { // /////////////// DOM Level 1 ////////////////
            string xmlnsPrefix_ = xmlnsPrefix(elementName);

            string namespaceURI2 = ownerDoc.isIgnoreNSDefault() && xmlnsPrefix_ == null ? nameSpaceURI : getNamespaceURIFromPrefix(xmlnsPrefix_);
            if (xmlnsPrefix_ != null && (namespaceURI2 == null || JDFConstants.EMPTYSTRING.Equals(namespaceURI2)))
            {
               throw new JDFException("You tried to add an element \"" + elementName + "\" in an unspecified Namespace");
            }
            else if (namespaceURI2 != null && !JDFConstants.EMPTYSTRING.Equals(namespaceURI2))
            { // /////////////// we found an URI ////////////////
               newChild = ownerDoc.factoryCreate(this, namespaceURI2, elementName);
            }
            else
            { // /////////////// no URI, create DOM Level 1 ////////////////
               newChild = ownerDoc.factoryCreate(this, elementName);
            }
         }
         else
         { // /////////////// DOM Level 2 ////////////////
            newChild = ownerDoc.factoryCreate(this, nameSpaceURI, elementName);
         }

         return newChild;
      }

      ///   
      ///	 <summary> * append a DOM element. This function creates a new element in the given namespace and appends it there.
      ///	 *  </summary>
      ///	 * <param name="elementName"> the name of the element to append
      ///	 *  </param>
      ///	 * <returns> KElement the appended element </returns>
      ///	 
      public virtual KElement appendElement(string elementName)
      {
         return appendElement(elementName, null);
      }

      ///   
      ///	 <summary> * append all children in a vector of elements in the order of the vector
      ///	 *  </summary>
      ///	 * <param name="v"> the vector of elements to append
      ///	 *  </param>
      ///	 * <param name="beforeChild"> the child before which to append the vector </param>
      ///	 
      public virtual void copyElements(VElement v, KElement beforeChild)
      {
         if (v == null)
            return;
         int size = v.Count;
         for (int i = 0; i < size; i++)
            copyElement(v[i], beforeChild);
      }

      ///   
      ///	 <summary> * Deletes itself from its parent
      ///	 *  </summary>
      ///	 * <returns> KElement - the deleted element, null if this has no parent node </returns>
      ///	 
      public virtual KElement deleteNode()
      {
         KElement parentElement = getParentNode_KElement();
         if (parentElement != null)
         {
            return (KElement)parentElement.removeChild(this);
         }
         return null;
      }

      ///   
      ///	 <summary> * gets an array of the direct children of the current element
      ///	 *  </summary>
      ///	 * <returns> KElement[] the array of direct children </returns>
      ///	 
      [MethodImpl(MethodImplOptions.Synchronized)]
      public virtual KElement[] getChildElementArray()
      {
         VElement v = new VElement();
         v.Capacity = 10; // good guess to avoid resizing too often
         XmlNode n = FirstChild;
         while (n != null)
         {
            if (n.NodeType == XmlNodeType.Element)
            {
               v.Add((KElement)n);
            }
            n = n.NextSibling;
         }
         int size = v.Count;
         KElement[] a = new KElement[size];
         return v.ToArray();
      }

      ///   
      ///	 <summary> * Get all children from the actual element matching the given conditions<br>
      ///	 * does NOT get refElement targets although the attributes are checked in the target elements in case of refElements
      ///	 *  </summary>
      ///	 * <param name="nodeName"> element name you are searching for </param>
      ///	 * <param name="nameSpaceURI"> nameSpace you are searching for </param>
      ///	 * <param name="mAttrib"> attributes you are lokking for </param>
      ///	 * <param name="bAnd"> if true, a child is only added if it has all attributes specified in Attributes mAttrib </param>
      ///	 * <param name="maxSize"> maximum size of the element vector
      ///	 *  </param>
      ///	 * <returns> VElement vector with all found elements </returns>
      ///	 * @deprecated 060302 - use 6 parameter version
      ///	 * @default getChildElementVector(null, null, null, true, 0, false) 
      ///	 
      [Obsolete("060302 - use 6 parameter version")]
      public virtual VElement getChildElementVector(string nodeName, string nameSpaceURI, JDFAttributeMap mAttrib, bool bAnd, int maxSize)
      {
         return getChildElementVector(nodeName, nameSpaceURI, mAttrib, bAnd, maxSize, false);
      }

      ///   
      ///	 <summary> * Get all children from the actual element matching the given conditions<br>
      ///	 * does NOT get refElement targets although the attributes are checked in the target elements in case of refElements
      ///	 *  </summary>
      ///	 * <param name="nodeName"> element name you are searching for </param>
      ///	 * <param name="nameSpaceURI"> nameSpace you are searching for </param>
      ///	 * <param name="mAttrib"> attributes you are lokking for </param>
      ///	 * <param name="bAnd"> if true, a child is only added if it has all attributes specified in Attributes mAttrib </param>
      ///	 * <param name="maxSize"> maximum size of the element vector (0=any) </param>
      ///	 * <param name="bResolveTarget"> if true, IDRef elements are followed, dummy at this level but needed in JDFElement
      ///	 *  </param>
      ///	 * <returns> VElement vector with all found elements
      ///	 * 
      ///	 * @default getChildElementVector(null, null, null, true, 0, true) </returns>
      ///	 
      public virtual VElement getChildElementVector(string nodeName, string nameSpaceURI, JDFAttributeMap mAttrib, bool bAnd, int maxSize, bool bResolveTarget)
      {
         return getChildElementVector_KElement(nodeName, nameSpaceURI, mAttrib, bAnd, maxSize);
      }

      ///   
      ///	 <summary> * Get all children from the actual element matching the given conditions<br>
      ///	 * convenience for getChildElementVector(nodeName, nameSpaceURI, null, true, 0, true)
      ///	 *  </summary>
      ///	 * <param name="nodeName"> element name you are searching for </param>
      ///	 * <param name="nameSpaceURI"> nameSpace you are searching for
      ///	 *  </param>
      ///	 * <returns> VElement vector with all found elements
      ///	 * 
      ///	 * @default getChildElementVector(null, null)
      ///	 *  </returns>
      ///	 
      public virtual VElement getChildElementVector(string nodeName, string nameSpaceURI)
      {
         return getChildElementVector(nodeName, nameSpaceURI, null, true, 0, true);
      }

      ///   
      ///	 <summary> * Get all children from the actual element matching the given conditions<br>
      ///	 * does NOT get refElement targets although the attributes are checked in the target elements in case of refElements
      ///	 *  </summary>
      ///	 * <param name="nodeName"> element name you are searching for </param>
      ///	 * <param name="nameSpaceURI"> nameSpace you are searching for </param>
      ///	 * <param name="mAttrib"> attributes you are lokking for </param>
      ///	 * <param name="bAnd"> if true, a child is only added if it has all attributes specified in Attributes mAttrib </param>
      ///	 * <param name="maxSize"> maximum size of the element vector
      ///	 *  </param>
      ///	 * <returns> VElement vector with all found elements
      ///	 *  </returns>
      ///	 * <seealso cref= org.cip4.jdflib.core.KElement#getChildElementVector(java.lang.String, java.lang.String,
      ///	 *      org.cip4.jdflib.datatypes.JDFAttributeMap, boolean, int)
      ///	 * 
      ///	 * @default getChildElementVector(null, null, null, true, 0) </seealso>
      ///	 
      [MethodImpl(MethodImplOptions.Synchronized)]
      public virtual VElement getChildElementVector_KElement(string nodeName, string nameSpaceURI, JDFAttributeMap mAttrib, bool bAnd, int maxSize)
      {
         string nodeNameLocal = nodeName;
         string nameSpaceURILocal = nameSpaceURI;
         JDFAttributeMap mAttribLocal = mAttrib;

         VElement v = new VElement();
         if (isWildCard(nodeNameLocal))
         {
            nodeNameLocal = null;
         }

         if (isWildCard(nameSpaceURILocal))
         {
            nameSpaceURILocal = null;
         }

         if (mAttribLocal != null && mAttribLocal.IsEmpty())
         {
            mAttribLocal = null;
         }

         bool bAlwaysFit = nodeNameLocal == null && nameSpaceURILocal == null;
         bool bMapEmpty = mAttribLocal == null;

         int iSize = 0;
         KElement kElem = getFirstChildElement();

         while (kElem != null)
         {
            if (bAlwaysFit || kElem.fitsName_KElement(nodeNameLocal, nameSpaceURILocal))
            {
               if (bMapEmpty || kElem.includesAttributes(mAttribLocal, bAnd))
               {
                  v.Add(kElem);

                  if (++iSize == maxSize)
                  {
                     break;
                  }
               }
            }

            kElem = kElem.getNextSiblingElement();
         }

         return v;
      }

      ///   
      ///	 <summary> * get the first child element
      ///	 *  </summary>
      ///	 * <returns> KElement the first child element of type ELEMENT_NODE if existing otherwise null </returns>
      ///	 
      public virtual KElement getFirstChildElement()
      {
         XmlNode firstChildElement = FirstChild;
         while (firstChildElement != null)
         {
            if (firstChildElement.NodeType == XmlNodeType.Element)
            {
               return (KElement)firstChildElement;
            }
            firstChildElement = firstChildElement.NextSibling;
         }
         return null;
      }

      ///   
      ///	 <summary> * get the next sibling element
      ///	 *  </summary>
      ///	 * <returns> KElement the next sibling element is existing otherwise null </returns>
      ///	 
      public virtual KElement getNextSiblingElement()
      {
         XmlNode nextSiblingElement = NextSibling;
         while (nextSiblingElement != null)
         {
            if (nextSiblingElement.NodeType == XmlNodeType.Element)
            {
               return (KElement)nextSiblingElement;
            }
            nextSiblingElement = nextSiblingElement.NextSibling;
         }
         return null;
      }

      ///   
      ///	 <summary> * get the previous sibling element
      ///	 *  </summary>
      ///	 * <returns> KElement the previous sibling element is existing otherwise null </returns>
      ///	 
      public virtual KElement getPreviousSiblingElement()
      {
         XmlNode previousSiblingElement = PreviousSibling;
         while (previousSiblingElement != null)
         {
            if (previousSiblingElement.NodeType == XmlNodeType.Element)
            {
               return (KElement)previousSiblingElement;
            }
            previousSiblingElement = previousSiblingElement.PreviousSibling;
         }
         return null;
      }

      ///   
      ///	 <summary> * Gets the previous sibling named nodename from the namespace nameSpaceURI of 'this'.
      ///	 *  </summary>
      ///	 * <param name="nodeName"> the name of the sibling </param>
      ///	 * <param name="nameSpaceURI"> the namespace of the sibling
      ///	 *  </param>
      ///	 * <returns> KElement the next sibling element of 'this', null if none is found </returns>
      ///	 
      public virtual KElement getNextSiblingElement(string nodeName, string nameSpaceURI)
      {
         KElement e = getNextSiblingElement();
         while (e != null)
         {
            if (e.fitsName(nodeName, nameSpaceURI))
            {
               return e;
            }
            e = e.getNextSiblingElement();
         }
         return null;
      }

      ///   
      ///	 <summary> * Gets the previous sibling named nodename from the namespace nameSpaceURI of 'this'.
      ///	 *  </summary>
      ///	 * <param name="nodeName"> the name of the sibling </param>
      ///	 * <param name="nameSpaceURI"> the namespace of the sibling
      ///	 *  </param>
      ///	 * <returns> KElement the next sibling element of 'this', null if none is found </returns>
      ///	 
      public virtual KElement getFirstChildElement(string nodeName, string nameSpaceURI)
      {
         KElement e = getFirstChildElement();
         while (e != null)
         {
            if (e.fitsName(nodeName, nameSpaceURI))
            {
               return e;
            }
            e = e.getNextSiblingElement();
         }
         return null;
      }

      ///   
      ///	 <summary> * Gets the previous sibling named nodename from the namespace nameSpaceURI of 'this'.
      ///	 *  </summary>
      ///	 * <param name="nodeName"> the name of the sibling </param>
      ///	 * <param name="nameSpaceURI"> the namespace of the sibling
      ///	 *  </param>
      ///	 * <returns> KElement the previous sibling element of 'this', null if none is found </returns>
      ///	 
      public virtual KElement getPreviousSiblingElement(string nodeName, string nameSpaceURI)
      {
         KElement e = getPreviousSiblingElement();
         while (e != null)
         {
            if (e.fitsName(nodeName, nameSpaceURI))
            {
               return e;
            }
            e = e.getPreviousSiblingElement();
         }
         return null;
      }

      ///   
      ///	 <summary> * Checks if the actual element contains the attributes given in aMap
      ///	 *  </summary>
      ///	 * <param name="aMap"> the attribute names to check </param>
      ///	 * <param name="bAnd"> true if you want to make sure all given attributes in aMap are present. False if it is enough if only
      ///	 *            one attribute in aMap is present
      ///	 *  </param>
      ///	 * <returns> boolean: true if present
      ///	 * 
      ///	 * @default IncludesAttributes(aMap, true) </returns>
      ///	 
      public virtual bool includesAttributes(JDFAttributeMap aMap, bool bAnd)
      {
         if (aMap == null || aMap.IsEmpty())
         {
            return true;
         }
         string key;
         string @value;
         IEnumerator<string> it = aMap.Keys.GetEnumerator();

         if (bAnd)
         {
            while (it.MoveNext())
            {
               key = it.Current;
               @value = aMap[key];
               if (!includesAttribute(key, @value))
               {
                  return false;
               }
            }
            return true;
         }
         // bAnd=false
         while (it.MoveNext())
         {
            key = it.Current;
            @value = aMap[key];
            if (includesAttribute(key, @value))
            {
               return true;
            }
         }
         return false;
      }

      ///   
      ///	 <summary> * Check if an attribute is present. If attValue is '*', "" or null it is checked if the element attName is present.
      ///	 * 
      ///	 * Only for simple attributes where an exact .equals match is appropriate, for ranges and rangelists use
      ///	 * JDFElement.includesMatchingAttributes()
      ///	 *  </summary>
      ///	 * <param name="attName"> the name of the attribute </param>
      ///	 * <param name="attValue"> the value of the attribute
      ///	 *  </param>
      ///	 * <returns> boolean true if present
      ///	 * 
      ///	 * @default includesAttribute(attName, null) </returns>
      ///	 
      public virtual bool includesAttribute(string attName, string attValue)
      {
         XmlAttribute attr = getDOMAttr(attName, null, false);
         if (attr == null)
         {
            return false;
         }

         if (isWildCard(attValue))
         {
            return true;
         }
         return attValue.Equals(attr.Value);
      }

      ///   
      ///	 <summary> * Gets children of 'this' by tag name, nameSpaceURI and attribute map, if the attribute map is not empty.<br>
      ///	 * Searches the entire tree including hidden nodes that are children of non-matching nodes
      ///	 *  </summary>
      ///	 * <param name="elementName"> elementname you are searching for </param>
      ///	 * <param name="nameSpaceURI"> nameSpace you are searching for </param>
      ///	 * <param name="mAttrib"> map of attributes you are looking for <br>
      ///	 *            Wildcards in the attribute map are supported </param>
      ///	 * <param name="bDirect"> if true, return value is a vector only of all direct child elements. <br>
      ///	 *            Otherwise the returned vector contains nodes of arbitrary depth </param>
      ///	 * <param name="bAnd"> if true, a child is only added, if it includes all attributes, specified in mAttrib </param>
      ///	 * <param name="maxSize"> maximum size of the element vector. maxSize is ignored if bDirect is false
      ///	 *  </param>
      ///	 * <returns> VElement: vector with all found elements
      ///	 *  </returns>
      ///	 * <seealso cref= org.cip4.jdflib.core.KElement#getChildElementVector(java.lang.String, java.lang.String,
      ///	 *      org.cip4.jdflib.datatypes.JDFAttributeMap, boolean, int, boolean)
      ///	 * 
      ///	 * @default getChildrenByTagName(s,null,null, false, true, 0) </seealso>
      ///	 
      public virtual VElement getChildrenByTagName(string elementName, string nameSpaceURI, JDFAttributeMap mAttrib, bool bDirect, bool bAnd, int maxSize)
      {
         if (bDirect)
         {
            return getChildElementVector(elementName, nameSpaceURI, mAttrib, bAnd, maxSize, true);
         }

         // maxSize is ignored in the tree walk!
         bool bHasNoMap = mAttrib == null || mAttrib.IsEmpty();

         VElement v = new VElement();
         KElement e = getFirstChildElement();
         bool bAlwaysFit = isWildCard(elementName) && isWildCard(nameSpaceURI);
         while (e != null)
         {
            if ((bAlwaysFit || e.fitsName(elementName, nameSpaceURI)) && (bHasNoMap || e.includesAttributes(mAttrib, bAnd)))
            {
               // this guy is the one
               v.Add(e);
               if (maxSize > 0 && v.Count == maxSize)
               {
                  return v;
               }
            }
            int maxSizeRecurse = maxSize > 0 ? maxSize - v.Count : maxSize;
            VElement v2 = e.getChildrenByTagName(elementName, nameSpaceURI, mAttrib, bDirect, bAnd, maxSizeRecurse);
            v.AddRange(v2);

            if (maxSize > 0 && v.Count >= maxSize)
            {
               return v;
            }
            e = e.getNextSiblingElement();
         }
         return v;
      }

      ///   
      ///	 <summary> * wrappers of DOM routines that dont bang on null nodes
      ///	 *  </summary>
      ///	 * <param name="s"> the local name of the elements to match on </param>
      ///	 * <param name="nameSpaceURI"> the namespace URI of the elements to match on
      ///	 *  </param>
      ///	 * <returns> VElement a new NodeList object containing all the matched Elements
      ///	 * 
      ///	 * @default getElementsByTagName_KElement(s, null) </returns>
      ///	 
      public virtual VElement getElementsByTagName_KElement(string s, string nameSpaceURI)
      {
         string sLocal = s;

         VElement vEle = null;
         if (sLocal == null)
            sLocal = JDFConstants.STAR;

         if ((nameSpaceURI == null) || nameSpaceURI.Equals(JDFConstants.EMPTYSTRING))
         {
            vEle = new VElement(GetElementsByTagName(sLocal));
         }
         else
         {
            vEle = new VElement(GetElementsByTagName(sLocal, nameSpaceURI));
         }

         return vEle;
      }

      ///   
      ///	 <summary> * Get a vector of all children with a matching attribte
      ///	 *  </summary>
      ///	 * <param name="nodeName"> elementname you are searching for </param>
      ///	 * <param name="attName"> attributes you are looking for </param>
      ///	 * <param name="nameSpaceURI"> nameSpace you are searching for </param>
      ///	 * <param name="attVal"> value of the attribute you are searching for </param>
      ///	 * <param name="bDirect"> if true : return only direct children if false : search recursively
      ///	 *  </param>
      ///	 * <returns> VElement - vector with all found elements
      ///	 * 
      ///	 * @default GetChildrenWithAttribute(nodeName, attName, null, null, true)
      ///	 *  </returns>
      ///	 * @deprecated use getChildrenByTagName(nodeName, nameSpaceURI, new JDFAttributeMap(attName, attVal), bDirect, true,
      ///	 *             0); 
      ///	 
      [Obsolete("use getChildrenByTagName(nodeName, nameSpaceURI, new JDFAttributeMap(attName, attVal), bDirect, true,")]
      public virtual VElement getChildrenWithAttribute(string nodeName, string attName, string nameSpaceURI, string attVal, bool bDirect)
      {
         return getChildrenByTagName(nodeName, nameSpaceURI, new JDFAttributeMap(attName, attVal), bDirect, true, 0);
      }

      ///   
      ///	 <summary> * Get the actual element, create if not there
      ///	 *  </summary>
      ///	 * <param name="nodeName"> name of the node from the element
      ///	 *  </param>
      ///	 * <returns> KElement the requested element </returns>
      ///	 
      public virtual KElement getCreateElement(string nodeName)
      {
         return getCreateElement(nodeName, null, 0);
      }

      ///   
      ///	 <summary> * Get a vector of all IDs that occur multiple times
      ///	 *  </summary>
      ///	 * <param name="attributeName"> name of the attribute to test for </param>
      ///	 * <returns> VString the list of multiply occurring ID values, null if all is well </returns>
      ///	 
      public virtual VString getMultipleIDs(string attributeName)
      {
         VString vRet = new VString();
         getMultipleIDs(attributeName, vRet, new SupportClass.HashSetSupport());
         return vRet.IsEmpty() ? null : vRet;
      }

      ///   
      ///	 <summary> * Get a vector of all IDs that occur multiple times
      ///	 *  </summary>
      ///	 * <param name="attributeName"> name of the attribute to test for </param>
      ///	 * <param name="vRet"> used for recursion; should be null </param>
      ///	 * <param name="setID"> used for recursion; should be null </param>
      ///	 * <returns> VString the list of multiply occurring ID values, null if all is well </returns>
      ///	 
      private void getMultipleIDs(string attributeName, VString vRet, SupportClass.SetSupport setID)
      {
         string id = getAttribute_KElement(attributeName, null, null);
         if (id != null)
         {
            if (setID.Contains(id))
            {
               vRet.appendUnique(id);
            }
            else
            {
               setID.Add(id);
            }
         }
         KElement child = getFirstChildElement();
         while (child != null)
         {
            child.getMultipleIDs(attributeName, vRet, setID);
            child = child.getNextSiblingElement();
         }
      }

      ///   
      ///	 <summary> * Get the actual element, create if not there
      ///	 *  </summary>
      ///	 * <param name="nodeName"> name of the node from the element </param>
      ///	 * <param name="nameSpaceURI"> the name of the NamespaceURI </param>
      ///	 * <param name="iSkip"> which one you want
      ///	 *  </param>
      ///	 * <returns> KElement the requested element
      ///	 * 
      ///	 * @default getCreateElement(nodeName, null, 0) </returns>
      ///	 
      public virtual KElement getCreateElement(string nodeName, string nameSpaceURI, int iSkip)
      {
         KElement e = getElement(nodeName, nameSpaceURI, iSkip);
         return e == null ? appendElement(nodeName, nameSpaceURI) : e;
      }

      ///   
      ///	 <summary> * Gets the iSkip-th child node with matching nodeName and nameSpaceURI, optionally creates it if it doesn't exist. <br>
      ///	 * If iSkip is more than one larger that the number of elements only one is appended
      ///	 *  </summary>
      ///	 * <param name="nodeName"> name of the child node to get </param>
      ///	 * <param name="nameSpaceURI"> namespace to search for </param>
      ///	 * <param name="iSkip"> number of matching child nodes to skip
      ///	 *  </param>
      ///	 * <returns> KElement the matching child element </returns>
      ///	 
      public virtual KElement getCreateElement_KElement(string nodeName, string nameSpaceURI, int iSkip)
      {
         KElement kElem = getElement_KElement(nodeName, nameSpaceURI, iSkip);

         if (kElem == null)
         {
            kElem = appendElement(nodeName, nameSpaceURI);
         }

         return kElem;
      }

      ///   
      ///	 <summary> * Get the actual element - utility routine.
      ///	 *  </summary>
      ///	 * <param name="nodeName"> Name of the node </param>
      ///	 * <returns> KElement - the child node
      ///	 * 
      ///	 * 
      ///	 * @default getElement_KElement(nodeName, null, 0) </returns>
      ///	 
      public virtual KElement getElement(string nodeName)
      {
         return getElement(nodeName, null, 0);
      }

      ///   
      ///	 <summary> * Gets an existing iSkip-th child node with matching nodeName and nameSpaceURI
      ///	 *  </summary>
      ///	 * <param name="nodeName"> name of the child node to get </param>
      ///	 * <param name="nameSpaceURI"> namespace to search for </param>
      ///	 * <param name="iSkip"> number of matching child nodes to skip
      ///	 *  </param>
      ///	 * <returns> KElement the matching child element
      ///	 * 
      ///	 * @default getElement_KElement(nodeName, null, 0) </returns>
      ///	 
      public virtual KElement getElement(string nodeName, string nameSpaceURI, int iSkip)
      {
         return getElement_KElement(nodeName, nameSpaceURI, iSkip);
      }

      ///   
      ///	 <summary> * performance enhanced function to access multiple elements e.g. by ID get a HashMap of key= attribute value,
      ///	 * object=element
      ///	 *  </summary>
      ///	 * <param name="elementName"> the names of the elements, wildcard if null </param>
      ///	 * <param name="elementNS"> the namespace URI of the elements, any if null </param>
      ///	 * <param name="attributeName"> the attribute name - MUST not be null </param>
      ///	 * <returns> a hashmap of the matching elements </returns>
      ///	 
      public virtual Hashtable getElementHashMap(string elementName, string elementNS, string attributeName)
      {
         Hashtable m = new Hashtable();
         VElement v = getChildElementVector_KElement(elementName, elementNS, new JDFAttributeMap(attributeName, (string)null), true, 0);
         int size = v.Count;
         for (int i = 0; i < size; i++)
         {
            KElement e = v[i];
            m.Add(e.getAttribute(attributeName), e);
         }
         return m;
      }

      ///   
      ///	 <summary> * getElement - Get the actual element
      ///	 *  </summary>
      ///	 * <param name="nodeName"> Name of the node </param>
      ///	 * <param name="nameSpaceURI"> Name of the NamespaceURI to search in </param>
      ///	 * <param name="iSkip"> number of element to get, if negative count backwards (-1 is the last)
      ///	 *  </param>
      ///	 * <returns> KElement the child node
      ///	 * 
      ///	 * @default getElement_KElement(nodeName, null, 0) </returns>
      ///	 
      public virtual KElement getElement_KElement(string nodeName, string nameSpaceURI, int iSkip)
      {
         int iSkipLocal = iSkip;

         KElement kElem = getFirstChildElement();
         int i = 0;
         if (iSkipLocal < 0)
         {
            iSkipLocal = numChildElements_KElement(nodeName, nameSpaceURI) + iSkipLocal;
         }

         if (iSkipLocal < 0)
         {
            return null;
         }

         while (kElem != null)
         {
            if (kElem.fitsName_KElement(nodeName, nameSpaceURI))
            {
               // this guy is the one
               if (i++ == iSkipLocal)
               {
                  return kElem;
               }
            }
            kElem = kElem.getNextSiblingElement();
         }
         return null;
      }

      ///   
      ///	 <summary> * Get the n'th Ancestor node with name parentNode
      ///	 *  </summary>
      ///	 * <param name="parentNode"> name of the parent node to search for </param>
      ///	 * <param name="depth"> which one you want to have in order of appearance
      ///	 *  </param>
      ///	 * <returns> KElement the n'th ancestor node with name nodeName
      ///	 * 
      ///	 * @default getDeepParent(parentNode, 0) </returns>
      ///	 
      public virtual KElement getDeepParent(string parentNode, int depth)
      {
         if (!LocalName.Equals(parentNode))
         {
            KElement parentElement = getParentNode_KElement();
            return (parentElement == null) ? null : parentElement.getDeepParent(parentNode, depth);
         }
         else if (depth > 0)
         {
            KElement parentElement = getParentNode_KElement();
            // last in chain or
            // leaving structure
            if ((parentElement != null) && (parentNode.Equals(parentElement.LocalName)))
            {
               return parentElement.getDeepParent(parentNode, depth - 1);
            }
         }
         return this;
      }

      ///   
      ///	 <summary> * Get the ancestor which may have one of the node names defined in parentNode
      ///	 *  </summary>
      ///	 * <param name="vParentElement"> vector with node names to search for </param>
      ///	 * <param name="depth"> which one you want to have (in order of appearance)
      ///	 *  </param>
      ///	 * <returns> KElement the first ancestor node with name nodeName </returns>
      ///	 * @deprecated - loop over the single node method 
      ///	 
      [Obsolete("- loop over the single node method")]
      public virtual KElement getDeepParent(ArrayList vParentElement, int depth)
      {
         KElement kRet = this;

         if (!(vParentElement.Contains(Name)))
         {
            kRet = getParentNode_KElement().getDeepParent(vParentElement, depth);
         }
         else if (depth > 0)
         {
            KElement par = getParentNode_KElement();

            if (par != null && vParentElement.Contains(par.Name))
            {
               kRet = par.getDeepParent(vParentElement, depth - 1);
            }
         }

         return kRet;
      }

      ///   
      ///	 <summary> * Gets the root element of the current document
      ///	 *  </summary>
      ///	 * <returns> KElement the root element of the current document </returns>
      ///	 
      public virtual KElement getDocRoot()
      {
         KElement kDocRoot = null;
         XmlElement rootElem = OwnerDocument.DocumentElement;

         if (rootElem != null)
         {
            kDocRoot = (KElement)rootElem;
         }

         return kDocRoot;
      }

      ///   
      ///	 <summary> * Gets all attribute keys of 'this' as a vector of strings
      ///	 *  </summary>
      ///	 * <returns> vWString: a vector of all attribute keys in 'this' </returns>
      ///	 
      public virtual VString getAttributeVector()
      {
         return getAttributeVector_KElement();
      }

      ///   
      ///	 <summary> * Gets all attribute keys of 'this' as a vector of strings
      ///	 *  </summary>
      ///	 * <returns> vWString: a vector of all attribute keys in 'this' </returns>
      ///	 
      public virtual VString getAttributeVector_KElement()
      {
         VString v = new VString();
         XmlNamedNodeMap nm = Attributes;
         if (nm != null)
         {
            int size = nm.Count;

            for (int i = 0; i < size; i++)
            {
               XmlNode a = nm.Item(i);
               v.Add(a.Name);
            }
         }

         return v;
      }

      ///   
      ///	 <summary> * This function first, gets all required attributes and then compare them with the attributes present and returns a
      ///	 * Vector with the missing attributes
      ///	 *  </summary>
      ///	 * <param name="nMax"> maximum size of the returned Vector
      ///	 *  </param>
      ///	 * <returns> VString vector with the missing attribute names
      ///	 * 
      ///	 * @default getMissingAttributes(9999999) </returns>
      ///	 
      public virtual VString getMissingAttributes(int nMax)
      {
         VString v = getTheAttributeInfo().requiredAttribs();
         return getMissingAttributeVector(v, nMax);
      }

      ///   
      ///	 <summary> * This function first, gets all deprecated attributes
      ///	 *  </summary>
      ///	 * <param name="nMax"> maximum size of the returned Vector
      ///	 *  </param>
      ///	 * <returns> Vector vector with the deprecated attributes
      ///	 * 
      ///	 * @default getMissingAttributes(9999999) </returns>
      ///	 
      public virtual VString getDeprecatedAttributes(int nMax)
      {
         VString v = deprecatedAttributes();
         return getMatchingAttributeVector(v, nMax);
      }

      ///   
      ///	 <summary> * This function first, gets all prerelease attributes It ignores any atrributes that have been added by a schema
      ///	 * parser
      ///	 *  </summary>
      ///	 * <param name="nMax"> maximum size of the returned Vector
      ///	 *  </param>
      ///	 * <returns> Vector vector with the prerelease attributes
      ///	 * 
      ///	 * @default getMissingAttributes(9999999) </returns>
      ///	 
      public virtual VString getPrereleaseAttributes(int nMax)
      {
         VString v = getMatchingAttributeVector(prereleaseAttributes(), nMax);
         AttributeInfo ai = null;
         if (!(v.Count == 0))
         {
            ai = getTheAttributeInfo();
         }

         // ideally we would find a better method to recognize schema placed
         // attributes
         for (int i = v.Count - 1; i >= 0; i--)
         {
            string key = v.stringAt(i);
            if (ai != null && getAttribute(key).Equals(ai.getAttributeDefault(key)))
            {
               v.RemoveAt(i);
            }
         }
         return v;
      }

      ///   
      ///	 <summary> * Comma separated list of all required attributes. KElement is generic, therefore the list is empty
      ///	 *  </summary>
      ///	 * <returns> String the comma separated list of required attribute keys </returns>
      ///	 
      public virtual VString requiredAttributes()
      {
         return getTheAttributeInfo().requiredAttribs();
      }

      ///   
      ///	 <summary> * Comma separated list of all optional attributes. KElement is generic, therefore only the XML generic attributes
      ///	 * are listed <br>
      ///	 * xmlns: the namespace declaration
      ///	 *  </summary>
      ///	 * <returns> String the comma separated list of optional attribute keys </returns>
      ///	 
      public virtual VString optionalAttributes()
      {
         return getTheAttributeInfo().optionalAttribs();
      }

      ///   
      ///	 <summary> * map of all defaults from the schema
      ///	 *  </summary>
      ///	 * <returns> JDFAttributeMap the comma separated list of deprecated attribute keys </returns>
      ///	 
      public virtual JDFAttributeMap getDefaultAttributeMap()
      {
         return getTheAttributeInfo().getDefaultAttributeMap();
      }

      ///   
      ///	 <summary> * list of all deprecated attributes. KElement is generic, therefore the list is empty
      ///	 *  </summary>
      ///	 * <returns> String the comma separated list of deprecated attribute keys </returns>
      ///	 
      public virtual VString deprecatedAttributes()
      {
         return getTheAttributeInfo().deprecatedAttribs();
      }

      ///   
      ///	 <summary> * Comma separated list of all deprecated attributes. KElement is generic, therefore the list is empty
      ///	 *  </summary>
      ///	 * <returns> String the comma separated list of deprecated attribute keys </returns>
      ///	 
      public virtual VString prereleaseAttributes()
      {
         return getTheAttributeInfo().prereleaseAttribs();
      }

      //   
      //	 * KElement is generic, therefore the list is empty
      //	 * 
      //	 * @return String the comma separated list of known attribute keys
      //	 
      public virtual VString knownAttributes()
      {
         return getTheAttributeInfo().knownAttribs();
      }

      ///   
      ///	 <summary> * checks if the curent element has other attributes then also present in vReqKeys. If the attribute is not present
      ///	 * in vReqKeys, the attribut is added to a new vector. The new vector is returned if there is no missing element
      ///	 * left or the new vector has reached the given size nMax.
      ///	 *  </summary>
      ///	 * <param name="vReqKeys"> the vector with the attributes you already have </param>
      ///	 * <param name="nMax"> vector with the missing attributes
      ///	 *  </param>
      ///	 * <returns> Vector the vector with the missing attributes
      ///	 * 
      ///	 * @default getMissingAttributeVector(vReqKeys, 9999999) </returns>
      ///	 
      public virtual VString getMissingAttributeVector(VString vReqKeys, int nMax)
      {
         VString vAtts = getAttributeVector();
         VString vMissing = new VString(); // is a StringVector like
         // vReqKeys

         string prefix = Prefix;
         if (prefix != null && !prefix.Equals(JDFConstants.EMPTYSTRING))
         {
            prefix += JDFConstants.COLON;
         }
         else
         {
            prefix = JDFConstants.EMPTYSTRING;
         }
         for (int i = 0; i < vReqKeys.Count && vMissing.Count < nMax; i++)
         {
            string req = vReqKeys.stringAt(i);
            if (!vAtts.Contains(prefix + req) && !vAtts.Contains(req) && (!req.Equals(JDFConstants.XMLNS) || base.NamespaceURI == null))
            {
               vMissing.Add(prefix + req);
            }
         }
         return vMissing;
      }

      ///   
      ///	 <summary> * checks if the curent element has other attributes that are present in vReqKeys. If the attribute is present in
      ///	 * vReqKeys, the attribut is added to a new vector. The new vector is returned if there is no missing element left
      ///	 * or the new vector has reached the given size nMax.
      ///	 *  </summary>
      ///	 * <param name="vReqKeys"> the vector with the attributes you already have </param>
      ///	 * <param name="nMax"> vector with the missing attributes
      ///	 *  </param>
      ///	 * <returns> Vector the vector with the missing attributes
      ///	 * 
      ///	 * @default getMissingAttributeVector(vReqKeys, 9999999) </returns>
      ///	 
      private VString getMatchingAttributeVector(VString vReqKeys, int nMax)
      {
         VString vAtts = getAttributeVector();
         VString vMatching = new VString(); // is a StringVector like
         // vReqKeys

         string prefix = Prefix;
         if (prefix != null && !prefix.Equals(JDFConstants.EMPTYSTRING))
         {
            prefix += JDFConstants.COLON;
         }
         else
         {
            prefix = JDFConstants.EMPTYSTRING;
         }
         for (int i = 0; i < vReqKeys.Count && vMatching.Count < nMax; i++)
         {
            string req = (string)vReqKeys[i];
            if (vAtts.Contains(prefix + req) || vAtts.Contains(req))
            {
               vMatching.Add(prefix + req);
            }
         }
         return vMatching;
      }

      ///   
      ///	 <summary> * Returns a vector which contains the childs of the actual element. But every child only once.
      ///	 *  </summary>
      ///	 * <returns> Vector vector with the childs of the actual element. Ever child typ is only added once. </returns>
      ///	 
      public virtual VString getElementNameVector()
      {
         VElement vChildElem = getChildElementVector(null, null, null, true, 0, false);
         VString v = new VString();

         for (int i = 0; i < vChildElem.Count; i++)
         {
            string strName = (vChildElem[i]).Name;
            v.appendUnique(strName);
         }
         return v;
      }

      ///   
      ///	 <summary> * get the missing elements as a vector
      ///	 * <p>
      ///	 * default: getMissingElements(99999999)
      ///	 *  </summary>
      ///	 * <param name="nMax"> maximum value of missing elements to return
      ///	 *  </param>
      ///	 * <returns> VString vector with nMax missing elements </returns>
      ///	 
      public virtual VString getMissingElements(int nMax)
      {
         VString v = getTheElementInfo().requiredElements();
         return getMissingElementVector(v, nMax);
      }

      ///   
      ///	 <summary> * @since 060517 changed signature to VString </summary>
      ///	 * <returns> required elements </returns>
      ///	 
      public virtual VString requiredElements()
      {
         return getTheElementInfo().requiredElements();
      }

      ///   
      ///	 <summary> * Comma separated list of all optional element names; KElement is generic, therefore the list is empty
      ///	 *  </summary>
      ///	 * <returns> VString the comma separated list of optional element names </returns>
      ///	 
      public virtual VString optionalElements()
      {
         return getTheElementInfo().optionalElements();
      }

      ///   
      ///	 <summary> * comma separated list of all unique Elements that may occur at most once; KElement is generic, therefore the list
      ///	 * is empty
      ///	 *  </summary>
      ///	 * <returns> String the comma separated list of required element names </returns>
      ///	 
      public virtual VString uniqueElements()
      {
         return getTheElementInfo().uniqueElements();
      }

      ///   
      ///	 <summary> * comma separated list of all prerelease Elements that may occur in a future version
      ///	 *  </summary>
      ///	 * <returns> String the comma separated list of required element names </returns>
      ///	 
      public virtual string prereleaseElements()
      {
         VString v = getTheElementInfo().prereleaseElements();
         return StringUtil.setvString(v, JDFConstants.COMMA, null, null);
      }

      ///   
      ///	 <summary> * Comma separated list of all prerelease elements.
      ///	 * <p>
      ///	 * default: getPrereleaseElements(99999999)
      ///	 *  </summary>
      ///	 * <returns> VString vector with nMax missing elements </returns>
      ///	 
      public virtual VString getPrereleaseElements(int nMax)
      {
         VString v = getTheElementInfo().prereleaseElements();
         return getMatchingElementVector(v, nMax);
      }

      ///   
      ///	 <summary> * Vector of deprecated elements below the current element.
      ///	 * <p>
      ///	 * default: getDeprecatedElements(99999999)
      ///	 *  </summary>
      ///	 * <returns> VString vector with nMax missing elements </returns>
      ///	 
      public virtual VString getDeprecatedElements(int nMax)
      {
         VString v = getTheElementInfo().deprecatedElements();
         return getMatchingElementVector(v, nMax);
      }

      ///   
      ///	 <summary> * Comma separated list of all known element names;
      ///	 *  </summary>
      ///	 * <returns> String the comma separated list of known element names </returns>
      ///	 
      public virtual VString knownElements()
      {
         VString s = requiredElements();
         s.appendUnique(optionalElements());
         return s;
      }

      ///   
      ///	 <summary> * Returns a vector with missing elements
      ///	 * <p>
      ///	 * default: getMissingElementVector(vRequiredKeys, 9999999)
      ///	 *  </summary>
      ///	 * <param name="vRequiredKeys"> vector with all element wich are required </param>
      ///	 * <param name="nMax"> maximum amount of missing element inside the returned vector
      ///	 *  </param>
      ///	 * <returns> Vector the vector with the missing elements </returns>
      ///	 
      public virtual VString getMissingElementVector(VString vRequiredKeys, int nMax)
      {
         VString vElements = getElementNameVector();
         VString vMissing = new VString();

         for (int i = 0; i < vRequiredKeys.Count && vMissing.Count < nMax; i++)
         {
            string requiredKey = (string)vRequiredKeys[i];
            if (!vElements.Contains(requiredKey))
            {
               if (!checkInstance(vElements, requiredKey))
               {
                  vMissing.Add(requiredKey);
               }
            }
         }

         return vMissing;
      }


      private static readonly DocumentJDFImpl m_dummyDocumentJDFImpl = new DocumentJDFImpl();

      private bool checkInstance(VString vElements, string requiredKey)
      {
         System.Type requiredClass = m_dummyDocumentJDFImpl.getFactoryClass(requiredKey);
         System.Type elementClass = null;
         VString.Enumerator elemIter = vElements.GetEnumerator();
         while (elemIter.MoveNext() && !requiredClass.Equals(elementClass))
         {
            string elemName = elemIter.Current;
            elementClass = m_dummyDocumentJDFImpl.getFactoryClass(elemName);
         }

         return requiredClass.Equals(elementClass);
      }

      ///   
      ///	 <summary> * Returns a vector with matching elements
      ///	 * <p>
      ///	 * default: getMissingElementVector(vReqKeys, 9999999)
      ///	 *  </summary>
      ///	 * <param name="vReqKeys"> vector with all element wich are required </param>
      ///	 * <param name="nMax"> maximum amount of missing element inside the returned vector
      ///	 *  </param>
      ///	 * <returns> Vector the vector with the missing elements </returns>
      ///	 
      private VString getMatchingElementVector(VString vReqKeys, int nMax)
      {
         VString vAtts = getElementNameVector();
         VString vReturn = new VString();

         for (int i = 0; i < vReqKeys.Count && vReturn.Count < nMax; i++)
         {
            if (vAtts.Contains(vReqKeys[i]))
            {
               vReturn.Add(vReqKeys[i]);
            }
         }

         return vReturn;
      }

      ///   
      ///	 <summary> * looking for a specified target with an id, e.g. resource.<br>
      ///	 * Offers access to exactly KElements implementation of GetTarget even if called for an instance of one of it's
      ///	 * subclasses.
      ///	 * <p>
      ///	 * default: getTarget(id, AttributeName.ID)
      ///	 *  </summary>
      ///	 * <param name="id"> value of the ID tag to search </param>
      ///	 * <param name="attrib"> name of the ID tag, defaults to "ID"
      ///	 *  </param>
      ///	 * <returns> KElement - the element if existing, otherwise <code>null</code> </returns>
      ///	 
      public KElement getTarget(string id, string attrib)
      {
         return getTarget_KElement(id, attrib);
      }

      ///   
      ///	 <summary> * Gets the target of link. Follows an ID-IDREF pair by recursively searching for an attrib with the value id
      ///	 *  </summary>
      ///	 * <param name="id"> value of the ID tag to search </param>
      ///	 * <param name="attrib"> name of the ID tag, defaults to "ID"
      ///	 *  </param>
      ///	 * <returns> KElement the target of link - the element node.
      ///	 *  </returns>
      ///	 
      public virtual KElement getTarget_KElement(string id, string attrib)
      {
         string attribLocal = attrib;

         if (id == null || id.Equals(JDFConstants.EMPTYSTRING))
         {
            return null;
         }
         bool bID = false;
         KElement kRet = null;
         if (attribLocal == null)
         {
            attribLocal = AttributeName.ID;
         }

         // try to find the target ID in the cached list
         XMLDocUserData userData = getXMLDocUserData();
         if (attribLocal.Equals(AttributeName.ID) && userData != null)
         {
            kRet = userData.getTarget(id);
            bID = true;
         }

         // if it wasn't in the cached list, search for it
         if (kRet == null)
         {
            // loop upwards from here
            // links are most likely quite local
            KElement excludeElement = null;
            KElement root = this;
            KElement docRoot = getDocRoot();
            bool bFound = false;
            if (!bID)
            {
               userData = null;
            }

            while (root != null && !bFound)
            {
               KElement deepElement = root.getDeepElementByID(attribLocal, id, excludeElement, userData);

               // search tree one level higher
               if (deepElement == null)
               {
                  if (root == docRoot)
                  {
                     kRet = null;
                     bFound = true;
                  }
                  else
                  {
                     excludeElement = root; // was already looked at
                     root = root.getParentNode_KElement();
                  }
               }
               else
               {
                  kRet = deepElement; // found it; return it
                  bFound = true;
               }
            }
         }

         return kRet;
      }

      ///   
      ///	 <summary> * this is an optimized version of GetDeepElement() which returns a complete list of elements. Here we abort, when
      ///	 * we found the first element that fits. (There is only one element, because the id must be unique)
      ///	 *  </summary>
      ///	 * <param name="attName"> attribute name </param>
      ///	 * <param name="id"> attribute ID value </param>
      ///	 * <param name="childToExclude"> here can be specified, if this method should exclude a child-element when searching This is
      ///	 *            useful, when searching a tree up </param>
      ///	 * <param name="ud"> userdata with reference to id cache, if null, no caching
      ///	 *  </param>
      ///	 * <returns> KElement the element specified by id and name </returns>
      ///	 
      public virtual KElement getDeepElementByID(string attName, string id, KElement childToExclude, XMLDocUserData ud)
      {
         string attVal = getAttribute_KElement(attName, null, null);
         if (attVal != null)
         {
            if (ud != null)
            {
               ud.setTarget(this, attVal);
            }
            if (attVal.Equals(id))
            {
               return this; // just found ourselves
            }
         }
         // tree walk children
         KElement childElement = getFirstChildElement();

         while (childElement != null)
         {
            if (!childElement.Equals(childToExclude))
            {
               KElement kDeepElement = childElement.getDeepElementByID(attName, id, childToExclude, ud);
               if (kDeepElement != null)
               {
                  return kDeepElement; // just got it
               }
            }
            // not yet found, try next sibling
            childElement = childElement.getNextSiblingElement();
         } // end while
         return null;
      }

      ///   
      ///	 <summary> * get the first child element
      ///	 *  </summary>
      ///	 * <param name="parent"> the node to get the first element node from
      ///	 *  </param>
      ///	 * <returns> Element - the first child element if existing otherwise null </returns>
      ///	 * @deprecated use elem.getFirstChildElement 
      ///	 
      [Obsolete("use elem.getFirstChildElement")]
      public static XmlElement getFirstElementNode(XmlElement parent)
      {
         XmlNode firstChildElement = parent.FirstChild;

         while (firstChildElement != null && firstChildElement.NodeType != XmlNodeType.Element)
         {
            firstChildElement = firstChildElement.NextSibling;
         }

         return (XmlElement)firstChildElement;
      }

      ///   
      ///	 <summary> * get the next sibling element
      ///	 *  </summary>
      ///	 * <param name="elem"> the Element to get the next element node from
      ///	 *  </param>
      ///	 * <returns> Element the first sibling element if existing otherwise null </returns>
      ///	 * @deprecated - use elem.getNextSiblingElement(); 
      ///	 
      [Obsolete("- use elem.getNextSiblingElement();")]
      public static XmlElement getNextElementNode(XmlElement elem)
      {
         XmlNode nextSiblingElement = elem.NextSibling;

         while (nextSiblingElement != null && nextSiblingElement.NodeType != XmlNodeType.Element)
         {
            nextSiblingElement = nextSiblingElement.NextSibling;
         }

         return (XmlElement)nextSiblingElement;
      }

      ///   
      ///	 * Checks if the contents of this element are equal to element kElem<br/> differs from <seealso cref= equals because nodes
      ///	 * that are in different locations or documents but have the same name, attributes and elements are considered equal
      ///	 *  </seealso>
      ///	 * <param name="kElem"> the element to compare
      ///	 *  </param>
      ///	 * <returns> boolean true if equal </returns>
      ///	 
      public virtual bool isEqual(KElement kElem)
      {
         if (kElem == null)
         {
            return false;
         }
         if (this.Equals(kElem))
         {
            return true;
         }
         if (numChildNodes(0) != kElem.numChildNodes(0))
         {
            return false;
         }
         if (!Name.Equals(kElem.Name))
         {
            return false;
         }

         if (NodeType != kElem.NodeType)
         {
            return false;
         }

         if (!includesAttributes(kElem.getAttributeMap(), true))
         {
            return false;
         }

         if (!kElem.includesAttributes(getAttributeMap(), true))
         {
            return false;
         }

         string txt = getText();
         string txt2 = kElem.getText();
         if (txt == null && txt2 != null)
         {
            return false;
         }
         if (txt2 == null && txt != null)
         {
            return false;
         }
         if (txt != null && !txt.Equals(txt2))
         {
            return false;
         }

         VElement l1 = getChildElementVector(null, null, null, true, 0, false);
         VElement l2 = kElem.getChildElementVector(null, null, null, true, 0, false);

         if (l1.Count != l2.Count)
         {
            return false;
         }
         for (int i = 0; i < l1.Count; i++)
         {
            KElement kNode1 = l1[i];
            KElement kNode2 = l2[i];

            if (!kNode1.isEqual(kNode2))
            {
               return false;
            }
         }

         return true;
      }

      ///   
      ///	 <summary> * Get all child nodes from the actual element
      ///	 *  </summary>
      ///	 * <returns> VElement list of all childs </returns>
      ///	 * @deprecated use getChildElementVector(null, null, null, true, 0) 
      ///	 
      [Obsolete("use getChildElementVector(null, null, null, true, 0)")]
      public virtual VElement getChildNodes_KElement()
      {
         return new VElement(ChildNodes);
      }

      ///   
      ///	 <summary> * Get the unknown attributes
      ///	 * <p>
      ///	 * default: getUnknownAttributes(bIgnorePrivate, 9999999)
      ///	 *  </summary>
      ///	 * <param name="bIgnorePrivate"> if true the private attributes will be ignored </param>
      ///	 * <param name="nMax"> mamimum amount of unknown attributes to return
      ///	 *  </param>
      ///	 * <returns> Vector a vector with all unknown atttributes the Element have </returns>
      ///	 
      public virtual VString getUnknownAttributes(bool bIgnorePrivate, int nMax)
      {
         VString vKnownAttribs = knownAttributes();
         VString v = bIgnorePrivate ? new VString(StringUtil.tokenize(" :JDF", JDFConstants.COLON, false)) : new VString();
         return getUnknownAttributeVector(vKnownAttribs, v, nMax);
      }

      ///   
      ///	 <summary> * Gets the unknown attributes
      ///	 * <p>
      ///	 * default: getUnknownAttributeVector(vKnownKeys, new Vector(), 99999999)
      ///	 *  </summary>
      ///	 * <param name="vKnownKeys"> vector with all known keys </param>
      ///	 * <param name="vInNameSpace"> vector with all namespaces to search in </param>
      ///	 * <param name="nMax"> maximum amount of unknown attributes to return
      ///	 *  </param>
      ///	 * <returns> vector with maximum nMax unknown Attributes </returns>
      ///	 
      public virtual VString getUnknownAttributeVector(VString vKnownKeys, VString vInNameSpace, int nMax)
      {
         int nMaxLocal = nMax;

         if (nMaxLocal < 0)
            nMaxLocal = int.MaxValue;

         VString vAtts = getAttributeVector_KElement();
         VString vUnknown = new VString();
         if (vKnownKeys.Contains("*"))
         {
            return vUnknown;
         }

         bool bAllNS = vInNameSpace.Count == 0;

         for (int j = 0; j < vInNameSpace.Count; j++)
         {
            // tokenize needs a blank
            if (vInNameSpace[j].Equals(JDFConstants.BLANK))
            {
               vInNameSpace[j] = JDFConstants.EMPTYSTRING;
            }
         }

         for (int i = 0; i < vAtts.Count && vUnknown.Count < nMaxLocal; i++)
         {
            string strAtts = vAtts[i];
            string ns = KElement.xmlnsPrefix(strAtts);
            if ((JDFConstants.XSI.Equals(ns)) || JDFConstants.XMLNS.Equals(ns))
            {
               continue;
            }

            if (bAllNS || ns == null || vInNameSpace.Contains(ns))
            {
               if (!vKnownKeys.Contains(strAtts))
               {
                  vUnknown.Add(strAtts);
               }
            }
         }

         return vUnknown;
      }

      ///   
      ///	 <summary> * Get a vector with the unknown elements
      ///	 * <p>
      ///	 * default: getUnknownElements(bIgnorePrivate, 99999999)
      ///	 *  </summary>
      ///	 * <param name="bIgnorePrivate"> true, to ignore the private elements </param>
      ///	 * <param name="nMax"> maximum number of elements in the vector returned
      ///	 *  </param>
      ///	 * <returns> Vector a vector with nMax unknown elements in the actual element.
      ///	 *  </returns>
      ///	 
      public virtual VString getUnknownElements(bool bIgnorePrivate, int nMax)
      {
         VString v1 = knownElements();
         VString v2 = new VString(StringUtil.tokenize(" :JDF", JDFConstants.COLON, false));

         return getUnknownElementVector(v1, bIgnorePrivate ? v2 : new VString(), nMax);
      }

      ///   
      ///	 <summary> * Get a vector with the unknown elements
      ///	 * <p>
      ///	 * default: getUnknownElementVector(vKnownKeys, vInNameSpace, 9999999)
      ///	 *  </summary>
      ///	 * <param name="vKnownKeys"> vector of all known elements </param>
      ///	 * <param name="vInNameSpace"> vector of all namespaces to search in </param>
      ///	 * <param name="nMax"> maximum amount of elements to return
      ///	 *  </param>
      ///	 * <returns> Vector a vector containing the unknown elements </returns>
      ///	 
      public virtual VString getUnknownElementVector(VString vKnownKeys, VString vInNameSpace, int nMax)
      {
         for (int j = 0; j < vInNameSpace.Count; j++)
         {
            // tokenize needs a blank
            if (vInNameSpace[j].Equals(JDFConstants.BLANK))
            {
               vInNameSpace[j] = JDFConstants.EMPTYSTRING;
            }
         }

         VString vAtts = getElementNameVector();
         VString vUnknown = new VString();

         if (vAtts.Count > 0)
         {
            int i = 0;
            bool bAllNS = vInNameSpace.Count == 0;

            do
            {
               string attr = vAtts[i];
               string ns = KElement.xmlnsPrefix(attr);
               if (ns == null)
               {
                  ns = JDFConstants.EMPTYSTRING;
               }

               if (bAllNS || (vInNameSpace.Contains(ns)))
               {
                  if (!vKnownKeys.Contains(attr))
                  {
                     vUnknown.Add(attr);
                  }
               }
            }
            while (vUnknown.Count < nMax && ++i < vAtts.Count);
         }

         return vUnknown;
      }

      ///   
      ///	 <summary> * checks if KElement child is ancestor or not
      ///	 *  </summary>
      ///	 * <param name="child"> child to check
      ///	 *  </param>
      ///	 * <returns> boolean true if anchestor </returns>
      ///	 
      public virtual bool isAncestor(KElement child)
      {
         return ancestorDistance(child) >= 0;
      }

      ///   
      ///	 <summary> * distance to ancestor (0=this)
      ///	 *  </summary>
      ///	 * <param name="child"> child to check </param>
      ///	 * <returns> int distance to ancestor, -1 if no direct descendant </returns>
      ///	 
      public virtual int ancestorDistance(KElement child)
      {
         if (child != null)
         {
            if (child == this)
            {
               return 0;
            }
            int ancestorDistance_ = ancestorDistance(child.getParentNode_KElement());
            return ancestorDistance_ < 0 ? ancestorDistance_ : 1 + ancestorDistance_;
         }
         return -1;
      }

      ///   
      ///	 <summary> * Not full implemented right now right now it checks if a the current object is null (return false) or if there is
      ///	 * a owner document (if not, return false)
      ///	 *  </summary>
      ///	 * @deprecated use isValid(EnumValidationLevel.Complete) 
      ///	 * <returns> boolean - true if valid (see above) </returns>
      ///	 
      [Obsolete("use isValid(EnumValidationLevel.Complete)")]
      public virtual bool isValid()
      {
         bool result = true;

         if (OwnerDocument == null)
         {
            result = false;
         }

         return result;
      }

      ///   
      ///	 <summary> * Mother of all validators
      ///	 *  </summary>
      ///	 * <param name="level"> validation level, defaults to complete if null
      ///	 * 
      ///	 *            <blockquote>
      ///	 *            <ul>
      ///	 *            <li>level ValidationLevel_None: always return true <li>level ValidationLevel_Construct: incomplete and
      ///	 *            null elements are valid
      ///	 * 
      ///	 *            <li>level ValidationLevel_Incomplete: incomplete elements are valid
      ///	 * 
      ///	 *            <li>level ValidationLevel_Complete: full validation of an individual resource
      ///	 * 
      ///	 *            <li>level ValidationLevel_RecursiveIncomplete: incomplete validation of an individual resource and all
      ///	 *            of its child elements - e.g. for pools
      ///	 * 
      ///	 *            <li>level ValidationLevel_RecursiveComplete: full validation of an individual resource and all of its
      ///	 *            child elements - e.g. for pools
      ///	 *            </ul>
      ///	 *            </blockquote>
      ///	 *  </param>
      ///	 * <returns> boolean true, if the node is valid. </returns>
      ///	 
      public virtual bool isValid(EnumValidationLevel level)
      {
         EnumValidationLevel levelLocal = level;

         if (levelLocal == null)
         {
            levelLocal = EnumValidationLevel.Complete; // makes compiler happy
         }
         return OwnerDocument != null;
      }

      ///   
      ///	 <summary> * is the attribute valid and of type iType. iType is of type EnumAttributeType but may be expanded in child classes
      ///	 * <p>
      ///	 * default: validAttribute(key, null)
      ///	 *  </summary>
      ///	 * <param name="key"> the attribute name </param>
      ///	 * <param name="nameSpaceURI"> attribute namespace uri </param>
      ///	 * <param name="level"> the validation level
      ///	 *  </param>
      ///	 * <returns> boolean: true if the attribute is valid </returns>
      ///	 
      public virtual bool validAttribute(string key, string nameSpaceURI, EnumValidationLevel level)
      {
         return getTheAttributeInfo().validAttribute(key, getAttribute(key, nameSpaceURI, null), level);
      }

      ///   
      ///	 <summary> * Get the ValuedEnum for an enumerated attribute
      ///	 *  </summary>
      ///	 * <param name="key"> the local name of the attribute </param>
      ///	 * <returns> ValuedEnum.Unknown of the requested attribute or null if the attribute is not an enum </returns>
      ///	 
      public virtual ValuedEnum getEnumforAttribute(string key)
      {
         return getTheAttributeInfo().getAttributeEnum(key);
      }

      ///   
      ///	 <summary> * Get the EnumAttributeType for an attribute
      ///	 *  </summary>
      ///	 * <param name="key"> the local name of the attribute </param>
      ///	 * <returns> EnumAttributeType of the attribute </returns>
      ///	 
      public virtual ValuedEnum getTypeForAttribute(string key)
      {
         return getTheAttributeInfo().getAttributeType(key);
      }

      ///   
      ///	 <summary> * Get the number of child elements. If String 'node' is an empty string or '*', all nodes are counted.
      ///	 * <p>
      ///	 * default: numChildElements(null, null)
      ///	 *  </summary>
      ///	 * <param name="node"> the nodes with name 'node' to count </param>
      ///	 * <param name="nameSpaceURI"> the nameSpace to look in
      ///	 *  </param>
      ///	 * <returns> int the number of matching child elements </returns>
      ///	 
      public virtual int numChildElements(string node, string nameSpaceURI)
      {
         return numChildElements_KElement(node, nameSpaceURI);
      }

      ///   
      ///	 <summary> * Get the number of child elements. If String 'node' is null, an empty string or '*', all nodes are counted. This
      ///	 * method is the same as numChildElements but prevents before the maybe unwanted virtuality of numChildElements.
      ///	 * <p>
      ///	 * default: numChildElements_KElement(null, null)
      ///	 *  </summary>
      ///	 * <param name="node"> the nodes with name 'node' to count </param>
      ///	 * <param name="nameSpaceURI"> the nameSpace to look in
      ///	 *  </param>
      ///	 * <returns> int the number of matching child elements </returns>
      ///	 
      public virtual int numChildElements_KElement(string node, string nameSpaceURI)
      {
         KElement kElem = getFirstChildElement();
         int n = 0;

         while (kElem != null)
         {
            if (kElem.fitsName_KElement(node, nameSpaceURI))
            {
               n++;
            }
            kElem = kElem.getNextSiblingElement();
         }

         return n;
      }

      ///   
      ///	 <summary> * Removes the n'th child node that matches 'nodeName' and 'nameSpaceURI'
      ///	 *  </summary>
      ///	 * <param name="node"> name of the child node to remove, if empty; or "*" removes the n'th element </param>
      ///	 * <param name="nameSpaceURI"> namespace to search in </param>
      ///	 * <param name="n"> number of nodes to skip before deleting
      ///	 *  </param>
      ///	 * <returns> KElement the removed element </returns>
      ///	 
      public virtual KElement removeChild(string node, string nameSpaceURI, int n)
      {
         KElement kRet = null;
         KElement kElem = getChildByTagName(node, nameSpaceURI, n, null, true, true);
         if (kElem != null)
         {
            kRet = (KElement)removeChild(kElem);
         }

         return kRet;
      }

      ///   
      ///	 <summary> * Get a child from the actual element by the tag name.
      ///	 * <p>
      ///	 * default: getChildByTagName(s, null, 0, null, true, true)
      ///	 *  </summary>
      ///	 * <param name="s"> elementname you are searching for </param>
      ///	 * <param name="nameSpaceURI"> nameSpace you are searching for </param>
      ///	 * <param name="index"> if more then one child match the condition you can specify which one you want to have via the index </param>
      ///	 * <param name="mAttrib"> attributes you are lokking for </param>
      ///	 * <param name="bDirect"> if true return value is directly the elemement. Otherwise the return value is the node of the
      ///	 *            found element. Only direct child, not grandchild etc. </param>
      ///	 * <param name="bAnd"> if true, a child is only returned if it has all attributes specified in mAttrib
      ///	 *  </param>
      ///	 * <returns> KElement the found child (element or node), null if index < 0 or index < number of matching children </returns>
      ///	 
      public virtual KElement getChildByTagName(string s, string nameSpaceURI, int index, JDFAttributeMap mAttrib, bool bDirect, bool bAnd)
      {
         VElement v = getChildrenByTagName(s, nameSpaceURI, mAttrib, bDirect, bAnd, index + 1);
         if ((index >= 0) && (v.Count > index))
         {
            return v.item(index);
         }
         return null;
      }

      ///   
      ///	 <summary> * Remove children that match <code>nodeName</code> and <code>nameSpaceURI</code>
      ///	 * <p>
      ///	 * default: removeChildren(nodeName, nameSpaceURI, null)
      ///	 *  </summary>
      ///	 * <param name="nodeName"> name of the child node to get, if empty or null remove all </param>
      ///	 * <param name="nameSpaceURI"> namespace to search in
      ///	 *  </param>
      ///	 * @deprecated use three parameter version removeChildren(nodeName, nameSpaceURI, null); 
      ///	 
      [Obsolete("use three parameter version removeChildren(nodeName, nameSpaceURI, null);")]
      public virtual void removeChildren(string nodeName, string nameSpaceURI)
      {
         removeChildren(nodeName, nameSpaceURI, null);
      }

      ///   
      ///	 <summary> * Removes the children named <code>nodeName</code> in the namespace <code>nameSpaceURI</code> from the parent
      ///	 * element
      ///	 * <p>
      ///	 * default: removeChildren(null,null,null)
      ///	 *  </summary>
      ///	 * <param name="nodeName"> name of the element typ to remove </param>
      ///	 * <param name="nameSpaceURI"> namespace in which the elements are to be removed </param>
      ///	 
      public virtual void removeChildren(string nodeName, string nameSpaceURI, JDFAttributeMap mAttrib)
      {
         VElement v = getChildElementVector(nodeName, nameSpaceURI, mAttrib, true, 0, false);
         int size = v.Count;
         for (int i = 0; i < size; i++)
         {
            removeChild(v[i]);
         }
      }

      ///   
      ///	 <summary> * Removes the attribute value from its value list <br>
      ///	 * Removes the contents of value from the existing attribute key. Deletes the attribute Key, if it has no value.<br>
      ///	 * <code>removeFromAttribute("key","next","",",", -1)</code> applied to <code><xml key="first,next"/></code> results
      ///	 * in <code><xml key="first"/></code>
      ///	 *  </summary>
      ///	 * <param name="key"> attribute key </param>
      ///	 * <param name="value"> string to remove </param>
      ///	 * <param name="nameSpaceURI"> namespace of attribute key </param>
      ///	 * <param name="sep"> separator between the values </param>
      ///	 * <param name="nMax"> maximum number of value instances to remove (-1 = all)
      ///	 *  </param>
      ///	 * <returns> int number of removed instances </returns>
      ///	 
      public virtual int removeFromAttribute(string key, string @value, string nameSpaceURI, string sep, int nMax)
      {
         int nMaxLocal = nMax;

         string strAttrValue = getAttribute_KElement(key, nameSpaceURI, null);
         if (strAttrValue == null || strAttrValue.IndexOf(@value) < 0)
            return 0;
         VString v = new VString(StringUtil.tokenize(strAttrValue, sep, false));
         int siz = v.Count;

         for (int i = siz - 1; i >= 0; i--)
         {
            if (v[i].Equals(@value))
            {
               v.RemoveAt(i);
               if (--nMaxLocal == 0)
               {
                  break;
               }
            }
         }

         if (v.Count == 0)
         {
            removeAttribute_KElement(key, nameSpaceURI);
            return 0;
         }
         setAttribute(key, StringUtil.setvString(v, sep, null, null), nameSpaceURI);
         return v.Count;
      }

      ///   
      ///	 <summary> * Flush - remove all attributes, elements and text, leaving only a stub tag
      ///	 *  </summary>
      ///	 * <returns> boolean true always </returns>
      ///	 
      public virtual bool flush()
      {
         VElement list = getChildElementVector(null, null, null, true, 0, false);

         for (int i = list.Count - 1; i >= 0; i--)
         {
            XmlNode node = list[i];
            removeChild(node);
         }

         removeAttributes(null);
         return true;
      }

      ///   
      ///	 <summary> * Get all or the spezified number of childs nodes from the actual element a maxSize of 0 spezifies all children.
      ///	 * <p>
      ///	 * default: getChildNodeVector(0)
      ///	 *  </summary>
      ///	 * <returns> Vector vector with all found nodes
      ///	 * @deprecated </returns>
      ///	 
      [Obsolete]
      public virtual ArrayList getChildNodeVector(int maxSize)
      {
         ArrayList v = new ArrayList();
         int i = 0;
         XmlNode node = FirstChild;

         if (node != null)
         {
            do
            {
               v.Add(node); // this guy is ok
               node = node.NextSibling;
            }
            while (++i != maxSize && node != null);
         }

         return v;
      }

      ///   
      ///	 <summary> * Removes all attributes spezified in attribs. If attribs is empty, all attributes are removed
      ///	 *  </summary>
      ///	 * <param name="attribs"> list of attributes to remove, if empty, remove all </param>
      ///	 
      public virtual void removeAttributes(VString attribs)
      {
         if (attribs == null)
         {
            XmlNamedNodeMap nm = Attributes;
            if (nm != null)
            {
               int size = nm.Count;

               for (int i = size - 1; i >= 0; i--)
               {
                  removeAttribute(nm.Item(i).Name);
               }
            }
         }
         else
         {
            for (int i = 0; i < attribs.Count; i++)
            {
               removeAttribute(attribs[i]);
            }
         }
      }

      ///   
      ///	 <summary> * remove all empty attributes from this (e.g. att="")
      ///	 *  </summary>
      ///	 * <param name="bRecurse"> if true, alse recurse subelements, else only local </param>
      ///	 
      public virtual void eraseEmptyAttributes(bool bRecurse)
      {
         XmlNamedNodeMap nm = Attributes;
         if (nm != null)
         {
            int size = nm.Count;

            for (int i = size - 1; i >= 0; i--)
            {
               XmlNode item = nm.Item(i);
               if (item.Value.Equals(JDFConstants.EMPTYSTRING))
               {
                  removeAttribute(item.Name);
               }
            }
         }

         if (bRecurse)
         {
            KElement e = getFirstChildElement();
            while (e != null)
            {
               e.eraseEmptyAttributes(true);
               e = e.getNextSiblingElement();
            }
         }
      }

      ///   
      ///	 <summary> * remove all default attributes from this i.e. all attributes whose value matches the schema default
      ///	 *  </summary>
      ///	 * <param name="bRecurse"> if true, alse recurse subelements, else only local </param>
      ///	 
      public virtual void eraseDefaultAttributes(bool bRecurse)
      {
         JDFAttributeMap aMap = getDefaultAttributeMap();
         if (aMap != null)
         {
            XmlNamedNodeMap nm = Attributes;
            if (nm != null)
            {
               int size = nm.Count;
               for (int i = size - 1; i >= 0; i--)
               {
                  XmlNode item = nm.Item(i);
                  string attVal = item.Name;
                  if (aMap.ContainsKey(attVal) && item.Value.Equals(aMap.get(attVal)))
                  {
                     removeAttribute(attVal);
                  }
               }
            }
         }

         if (bRecurse)
         {
            KElement e = getFirstChildElement();
            while (e != null)
            {
               e.eraseDefaultAttributes(true);
               e = e.getNextSiblingElement();
            }
         }
      }

      ///   
      ///	 <summary> * You can get the iSkip element named by nodeName. If there is no element present, a new empty element is returned.
      ///	 * If iSkip is out of range, a new element is returned.
      ///	 * <p>
      ///	 * default: getDeepElement(nodeName, null, 0)
      ///	 *  </summary>
      ///	 * <param name="nodeName"> the type of element you want to get </param>
      ///	 * <param name="nameSpaceURI"> the namespace to search in !!! NOT USED IN FUCTION !!! </param>
      ///	 * <param name="iSkip"> which element you want to have (order of appearance)
      ///	 *  </param>
      ///	 * <returns> KElement the iSkip element or a new element
      ///	 *  </returns>
      ///	 * @deprecated use getChildByTagName(nodeName, nameSpaceURI, iSkip, null, false, true); 
      ///	 
      [Obsolete("use getChildByTagName(nodeName, nameSpaceURI, iSkip, null, false, true);")]
      public virtual KElement getDeepElement(string nodeName, string nameSpaceURI, int iSkip)
      {
         return getChildByTagName(nodeName, nameSpaceURI, iSkip, null, false, true);
      }

      ///   
      ///	 * @deprecated use getChildFromList(Vector nodeNames, int iSkip, JDFAttributeMap map) 
      ///	 * <param name="nodeNames"> </param>
      ///	 * <param name="iSkip"> </param>
      ///	 * <returns> KElement </returns>
      ///	 
      [Obsolete("use getChildFromList(Vector nodeNames, int iSkip, JDFAttributeMap map)")]
      public virtual KElement getChildFromList(VString nodeNames, int iSkip)
      {
         return getChildFromList(nodeNames, iSkip, null, true);
      }

      ///   
      ///	 <summary> * Get any Child that matches a string defined in nodeNames. The method compares the strings with the element name
      ///	 * <p>
      ///	 * default: getChildFromList(nodeNames, 0, null)
      ///	 *  </summary>
      ///	 * <param name="nodeNames"> container for the node name string </param>
      ///	 * <param name="iSkip"> how many of the found child should be skiped
      ///	 *  </param>
      ///	 * <returns> KElement a child matching the condition </returns>
      ///	 
      public virtual KElement getChildFromList(VString nodeNames, int iSkip, JDFAttributeMap map, bool bDirect)
      {
         int i = 0;
         KElement kElem = getFirstChildElement();
         while (kElem != null)
         {
            if (nodeNames.Contains(kElem.LocalName))
            {
               if (map == null || kElem.includesAttributes(map, true))
               {
                  if (i++ >= iSkip)
                  {
                     return kElem; // this guy is the one
                  }
               }
            }
            if (!bDirect)
            {
               int j = 0;
               KElement e2 = null;
               do
               {
                  e2 = kElem.getChildFromList(nodeNames, j, map, bDirect);
                  if (e2 != null)
                  {
                     if (i++ >= iSkip)
                     {
                        return e2;
                     }
                     j++;
                  }
               }
               while (e2 != null);
            }
            kElem = kElem.getNextSiblingElement();
         }
         return null;
      }

      ///   
      ///	 <summary> * Rename the element with the String newName. Attention. the Java class of the element does not get modified. It is
      ///	 * up to the caller to ensure that no inconsistent types get created with rename
      ///	 * default: renameElement(newName, null)
      ///	 *  </summary>
      ///	 * <param name="newName"> the new name of the actual element </param>
      ///	 * <param name="nameSpaceURI"> the new nameSpace, ignored if null</param>
      ///	 * <returns> KElement the renamed child. </returns>
      ///	 <remarks>Different from Java because this element doesn't change.</remarks>
      public virtual KElement renameElement(string newName, string nameSpaceURI)
      {
         // Java to C# Conversion - TODO: How are we going to assign values?
         //   Create element with new name, 
         //   Copy this attributes and child node to new element, 
         //   Replace this element.
         //   Make new element this element?

         //if it isn't really a rename, don't bother.
         if(this.Name == newName && (String.IsNullOrEmpty(nameSpaceURI) || this.NamespaceURI == nameSpaceURI))
         {
            return this;
         }
         //if no namespace, use this namespace.
         string localnameSpaceURI = nameSpaceURI;
         if (String.IsNullOrEmpty(localnameSpaceURI))
         {
            localnameSpaceURI = this.NamespaceURI;
         }
         KElement newElem = (KElement)this.OwnerDocument.CreateElement(newName, localnameSpaceURI);
         if (newElem != null)
         {
            while (this.HasAttributes)
            {
               newElem.SetAttributeNode(this.RemoveAttributeNode(this.Attributes[0]));
            }
            while (this.HasChildNodes)
            {
               newElem.AppendChild(this.RemoveChild(this.FirstChild));
            }
            if (this.ParentNode != null)
            {
               this.ParentNode.ReplaceChild(newElem, this);
            }
            this.flush();
         }
         return newElem;
      }

      ///   
      ///	 <summary> *remove all elements and attributes of a given namespace
      ///	 *  </summary>
      ///	 * <param name="nsURI"> the ns uri of the extensions to remove
      ///	 *  </param>
      ///	 
      public virtual void removeExtensions(string nsURI)
      {
         if (nsURI == null)
            return;

         KElement n = getFirstChildElement();
         while (n != null)
         {
            KElement next = n.getNextSiblingElement(); // get next prior to
            // zapping
            string nsuri = n.getNamespaceURI();
            if (nsURI.Equals(nsuri))
            {
               removeChild(n);
            }
            else
            {
               n.removeExtensions(nsURI);
            }

            n = next;
         }

         XmlNamedNodeMap nm = Attributes;
         if (nm != null)
         {
            int size = nm.Count;
            for (int i = size - 1; i >= 0; i--)
            {
               XmlNode na = nm.Item(i);
               string nsuri = na.NamespaceURI;
               if (nsURI.Equals(nsuri))
               {
                  removeAttributeNode((XmlAttribute)na);
               }
            }
         }
      }

      ///   
      ///	 <summary> * moves this to a position before another child, fails if either this or beforechild are document roots
      ///	 *  </summary>
      ///	 * <param name="beforeChild"> the child to move before, if beforechild is a the document root, do nothing if null, move me
      ///	 *            to the end of my parent
      ///	 *  </param>
      ///	 * <returns> this after moving, null if failure </returns>
      ///	 
      public virtual KElement moveMe(KElement beforeChild)
      {
         KElement parent = beforeChild == null ? getParentNode_KElement() : beforeChild.getParentNode_KElement();
         if (beforeChild == this)
            return this;
         if (parent == null || getParentNode_KElement() == null)
            return null;
         return parent.moveElement(this, beforeChild);
      }

      ///   
      ///	 <summary> * Moves src node (including all attributes and subelements) from its parent node into 'this' and inserts it in
      ///	 * front of beforeChild, if it exists. Otherwise appends src to 'this'.<br>
      ///	 * If src is <code>null</code>, an empty KElement is returned.<br>
      ///	 * 
      ///	 * src is removed from its parent node. if the actual document owner is the same as the document owner of src, src
      ///	 * is appended to 'this' If the documents are different, then src is appended to 'this' in the actual document.
      ///	 * <p>
      ///	 * default: moveElement(src, null)
      ///	 *  </summary>
      ///	 * <param name="src"> node to move. </param>
      ///	 * <param name="beforeChild"> child of 'this' to insert src before. If beforeChild is null, src is appended to 'this' </param>
      ///	 * <returns> KElement src element after moving, null if src is null
      ///	 *  </returns>
      ///	 * <exception cref="JDFException"> if beforeChild is not a child of 'this' </exception>
      ///	 
      public virtual KElement moveElement(KElement src, KElement beforeChild)
      {
         KElement kRet = null;

         if (src != null)
         {
            if (src.isAncestor(this))
               return null; // snafu when moving a to b in a/b
            XmlNode parentNode = src.ParentNode;
            XmlNode srcElement = parentNode == null ? src : parentNode.RemoveChild(src);

            if (beforeChild != null && beforeChild.ParentNode != this)
            {
               throw new JDFException("KElement.moveElement" + " beforeChild is not child of this");
            }

            if (src.OwnerDocument != OwnerDocument)
            {
               src.clearTargets();
               KElement dest = (KElement)OwnerDocument.ImportNode(srcElement, true);
               //dest.fixParent(this, dest);
               srcElement = dest;
            }

            if (beforeChild == null)
            {
               kRet = (KElement)appendChild(srcElement);
            }
            else
            {
               kRet = (KElement)InsertBefore(srcElement, beforeChild);
            }
         }

         return kRet;
      }

      ///   
      ///	 <summary> * Erases all empty text nodes in 'this' and its subelements If there any empty text nodes removes them. If
      ///	 * bTrimWhite is true, then trims white spaces from both ends of a text node and only then, if it is empty, removes
      ///	 * it
      ///	 *  </summary>
      ///	 * <param name="bTrimWhite"> trims whitespace of text, default = true </param>
      ///	 * <returns> int the number of removed nodes </returns>
      ///	 
      public virtual int eraseEmptyNodes(bool bTrimWhite)
      {
         int nRemove = 0;

         XmlNode n = FirstChild;
         while (n != null)
         {
            XmlNode nNext = n.NextSibling; // must set nNew prior to
            // potentially deleting n...
            XmlNodeType nodeType = n.NodeType;

            if (nodeType == XmlNodeType.Text)
            {
               string s = n.Value;
               if (bTrimWhite)
               {
                  s = s.Trim();
               }
               if (s.Equals(JDFConstants.EMPTYSTRING))
               {
                  removeChild(n);
                  nRemove++;
               }
               else if (bTrimWhite)
               { // replace value with cleaned string
                  n.Value = s; ;
               }
            }
            else if (nodeType == XmlNodeType.Element)
            {
               KElement kElem = (KElement)n;
               nRemove += kElem.eraseEmptyNodes(true);
               // 040302 RP do not erase empty elements
               // they may have a sementic meaning
            }
            n = nNext;

         }

         return nRemove;
      }

      ///   
      ///	 <summary> * Copies src node (including all attributes and subelements) and inserts the copy into 'this' in front of
      ///	 * beforeChild, if it exists. Otherwise appends src node to 'this'.
      ///	 * <p>
      ///	 * default: copyElement(src, null)
      ///	 *  </summary>
      ///	 * <param name="src"> node to copy. </param>
      ///	 * <param name="beforeChild"> child of 'this' to insert src before. If null, src is appended
      ///	 *  </param>
      ///	 * <returns> KElement the copied element, <code>null</code> if src is <code>null</code>. </returns>
      ///	 
      public virtual KElement copyElement(KElement src, KElement beforeChild)
      {
         return (KElement)copyNode(this, src, beforeChild);
      }


      private static XmlNode copyNode(XmlNode parent, XmlNode src, XmlNode beforeChild)
      {
         if (src == null)
            return null;

         lock (parent)
         {

            KElement childNode = null;
            if (src.OwnerDocument == parent.OwnerDocument)
            {
               childNode = (KElement) src.CloneNode(true);
            }
            else
            {
               childNode = (KElement) parent.OwnerDocument.ImportNode(src, true);
            }

            if (beforeChild != null && beforeChild.ParentNode != parent)
            {
               throw new JDFException("KElement.copyElement" + " beforeChild is not child of this");
            }

            return parent.InsertBefore(childNode, beforeChild);
         }
      }


      ///   
      ///	 <summary> * Replaces 'this' with src. <br>
      ///	 * If the actual document is the same as the src document, 'this' is replaced by src.<br>
      ///	 * If the actual document and the src document are different, src is positioned at the position of 'this' in the
      ///	 * current document and removed from the old parent document.<br>
      ///	 * 
      ///	 * @since 130103 ReplaceElement works on all elements including the document root </summary>
      ///	 * <param name="src"> node, that 'this' will be replaced with
      ///	 *  </param>
      ///	 * <returns> KElement the replaced element. If src is null or equal 'this', src is returned. </returns>
      ///	 <remarks>Different from Java because this element doesn't change.</remarks>
      public virtual KElement replaceElement(KElement src)
      {
         KElement srcLocal = src;

         if (srcLocal == this)
         {
            return this; // nop
         }

         KElement kRet = srcLocal;

         if (srcLocal != null)
         {
            // workaround for the document element
            // TBD: there must be a better way
            if (getParentNode_KElement() == null)
            {
               kRet = replaceElement_isDocRoot(srcLocal);
            }
            else
            {
               KElement srcParentNode = srcLocal.getParentNode_KElement();
               if (srcParentNode != null)
               {
                  // removes the resource from the to merge document
                  srcLocal = (KElement)srcParentNode.removeChild(srcLocal);
               }

               // this and src are in the same document
               if (srcLocal.OwnerDocument == OwnerDocument)
               {
                  getParentNode_KElement().replaceChild(srcLocal, this);
                  //fixParent(srcLocal, null);
                  kRet = srcLocal;
               }
               else
               { // import from other document
                  KElement dn = (KElement)OwnerDocument.ImportNode(srcLocal, true);
                  getParentNode_KElement().replaceChild(dn, this);
                  //fixParent(dn, null);
                  kRet = dn;
               }
            }
         }
         // Java to C# Conversion - NOTE: Don't believe we need this.  No ownerNode in .NET
         //this.ownerNode = null; // I've replace this so that it remains an orphan
         // in the document, but has no owner node
         return kRet;
      }

      //   
      //	 * used in replaceElement
      //	 Different from Java because this element doesn't change.
      private KElement replaceElement_isDocRoot(KElement src)
      {
         KElement dst = this;
         if (!dst.Name.Equals(src.Name) || !dst.getNamespaceURI().Equals(src.getNamespaceURI()))
         {
            dst = dst.renameElement(src.Name, src.getNamespaceURI());
         }
         dst.flush();
         dst.setAttributes(src.getAttributeMap());
         VElement children = src.getChildElementVector(null, null, null, true, 0, false);

         for (int iv = 0; iv < children.Count; iv++)
         {
            dst.copyElement(children[iv], null);
         }

         return dst; // return the original
      }

      // ************************** end of methods needed in JDFRefElement
      // ********
      ///////
      // ************************** start of methods needed in JDFResourceLink
      // ****

      ///   
      ///	 <summary> * Get a long attribute if present
      ///	 * <p>
      ///	 * default: getLongAttribute(attrib, null, 0)
      ///	 *  </summary>
      ///	 * <param name="attrib"> attribute to parse for an integer attribute </param>
      ///	 * <param name="nameSpaceURI"> nameSpaceURI to search in </param>
      ///	 * <param name="def"> the default to return if the value is empty or the attribute is not set
      ///	 *  </param>
      ///	 * <returns> the parsed int. If the attribute was not found, <code>long def</code> is returned. </returns>
      ///	 
      public virtual long getLongAttribute(string attrib, string nameSpaceURI, long def)
      {
         long lRet = def;
         string s = getAttribute(attrib, nameSpaceURI, null);

         if (s != null)
         {
            lRet = Convert.ToInt64(s);
         }
         return lRet;
      }

      ///   
      ///	 <summary> * Get a integer attribute if present
      ///	 * <p>
      ///	 * default: getIntAttribute(attrib, null, 0)
      ///	 *  </summary>
      ///	 * <param name="attrib"> attribute to parse for an integer attribute </param>
      ///	 * <param name="nameSpaceURI"> nameSpaceURI to search in </param>
      ///	 * <param name="def"> the default to return if the value is not set or the attribute does not exists
      ///	 *  </param>
      ///	 * <returns> int the parsed int. If the attribute was not found int def is returned </returns>
      ///	 
      public virtual int getIntAttribute(string attrib, string nameSpaceURI, int def)
      {
         string s = getAttribute(attrib, nameSpaceURI, null);
         return StringUtil.parseInt(s, def);
      }

      ///   
      ///	 <summary> * get a boolean attribute
      ///	 * <p>
      ///	 * default: getBoolAttribute(attrib, null, false)
      ///	 *  </summary>
      ///	 * <param name="attrib"> attribute to parse for a boolean value </param>
      ///	 * <param name="nameSpaceURI"> nameSapceURI to search in </param>
      ///	 * <param name="def"> the default to return if value is not set or the attribute does not exists
      ///	 *  </param>
      ///	 * <returns> boolean the boolean value or the def parameter </returns>
      ///	 
      public virtual bool getBoolAttribute(string attrib, string nameSpaceURI, bool def)
      {
         string s = getAttribute(attrib, nameSpaceURI, null);
         return StringUtil.parseBoolean(s, def);
      }

      ///   
      ///	 <summary> * get a double attribute
      ///	 * <p>
      ///	 * default: getRealAttribute(attrib, null, 0.0)
      ///	 *  </summary>
      ///	 * <param name="attrib"> attribute to parse for a boolean value </param>
      ///	 * <param name="nameSpaceURI"> nameSapceURI to search in </param>
      ///	 * <param name="def"> default to return if none value is set or attribute does not exist
      ///	 *  </param>
      ///	 * <returns> double the double value or <code>def</code> </returns>
      ///	 
      public virtual double getRealAttribute(string attrib, string nameSpaceURI, double def)
      {
         string s = getAttribute(attrib, nameSpaceURI, null);
         return StringUtil.parseDouble(s, def);
      }

      ///   
      ///	 <summary> * Get the Ancestor node with name other than thisNode
      ///	 *  </summary>
      ///	 * <param name="thisNode"> serch string
      ///	 *  </param>
      ///	 * <returns> KElement parent node element </returns>
      ///	 
      public virtual KElement getDeepParentNotName(string thisNode)
      {
         KElement kRet = null;

         if (LocalName.Equals(thisNode))
         {
            KElement parent = getParentNode_KElement();
            kRet = (parent == null) ? null : parent.getDeepParentNotName(thisNode);
         }
         else
         {
            kRet = this;
         }

         return kRet;
      }

      // ************************** end of methods needed in JDFResourceLink
      // ******
      ///////
      // ************************** start of methods needed in JDFPartAmount
      // ******

      ///   
      ///	 <summary> * Get the first child of parentNode with name parentNode
      ///	 *  </summary>
      ///	 * <param name="parentNode"> node name to search for </param>
      ///	 * <returns> KElement the matching child of the parent element </returns>
      ///	 
      public virtual KElement getDeepParentChild(string parentNode)
      {
         KElement kElem = getParentNode_KElement();

         if (kElem != null && parentNode != null)
         {
            if (!kElem.Name.Equals(parentNode))
            {
               return kElem.getDeepParentChild(parentNode);
            }
            return this;
         }
         return null;
      }

      // ************************** end of methods needed in JDFPartAmount
      // ********
      ///////
      // ************************** start of methods needed in JDFResponse
      // ********

      ///   
      ///	 <summary> * append a DOM comment <code>&lt;!-- XMLComment --&gt;</code> The double minus sign '--' is escaped with an
      ///	 * underscore '_' in order to ensure valid xml
      ///	 *  </summary>
      ///	 * <param name="commentText"> the comment to append </param>
      ///	 * @deprecated use appendXMLComment(commentText, null); 
      ///	 
      [Obsolete("use appendXMLComment(commentText, null);")]
      public virtual void appendXMLComment(string commentText)
      {
         appendXMLComment(commentText, null);
      }

      ///   
      ///	 <summary> * append a DOM comment <code>&lt;!-- XMLComment --&gt;</code> The double minus sign '--' is escaped with an
      ///	 * underscore '_' in order to ensure valid xml
      ///	 *  </summary>
      ///	 * <param name="commentText"> the comment to append </param>
      ///	 * <param name="beforeChild"> the child of this that the Comment should be appended before. if null, append the Comment </param>
      ///	 
      public virtual void appendXMLComment(string commentText, KElement beforeChild)
      {
         string commentTextLocal = commentText;

         commentTextLocal = StringUtil.replaceString(commentTextLocal, "--", "__");
         XmlComment newChild = OwnerDocument.CreateComment(commentTextLocal);
         InsertBefore(newChild, beforeChild);
      }

      ///   
      ///	 <summary> * set a DOM comment <code>&lt;!-- XMLComment --&gt;</code> in front of <code>this</code> if an xml Comment node
      ///	 * already exists directly in front of <code>this</code>, the previous comment is removed
      ///	 * 
      ///	 * The double minus sign '--' is escaped with an underscore '_' in order to ensure valid xml
      ///	 *  </summary>
      ///	 * <param name="commentText"> the comment text to set </param>
      ///	 
      public virtual void setXMLComment(string commentText)
      {
         string commentTextLocal = commentText;

         KElement e = getParentNode_KElement();
         if (e == null)
         {
            commentTextLocal = StringUtil.replaceString(commentTextLocal, "--", "__");
            XmlComment newChild = OwnerDocument.CreateComment(commentTextLocal);
            OwnerDocument.InsertBefore(newChild, this);
            XmlNode last = newChild.PreviousSibling;
            if (last != null && last.NodeType == XmlNodeType.Comment)
            {
               OwnerDocument.RemoveChild(last);
            }
         }
         else
         {
            XmlNode last = PreviousSibling;
            e.appendXMLComment(commentTextLocal, this);
            if (last != null && last.NodeType == XmlNodeType.Comment)
            {
               e.removeChild(last);
            }

         }
      }

      ///   
      ///	 <summary> * Appends XML CData section <code>&lt;![CDATA[ CData Section ]]&gt;</code> some character data <br>
      ///	 * Appends a new CData section child node to the end of 'this '
      ///	 *  </summary>
      ///	 * <param name="cDataText"> the text of the XML CData section to append </param>
      ///	 
      public virtual void appendCData(string cDataText)
      {
         XmlCDataSection newChild = OwnerDocument.CreateCDataSection(cDataText);
         appendChild(newChild);
      }

      ///   
      ///	 <summary> * Appends XML CData section <code>&lt;![CDATA[ CData Section ]]&gt;</code> some character data <br>
      ///	 * Appends a new CData section child node to the end of 'this '
      ///	 *  </summary>
      ///	 * <param name="cDataElem"> the element of the XML CData section to append </param>
      ///	 
      public virtual void appendCData(KElement cDataElem)
      {
         string s = cDataElem.ToString();
         XmlCDataSection newChild = OwnerDocument.CreateCDataSection(s);
         appendChild(newChild);
      }

      ///   
      ///	 <summary> * append some generic text
      ///	 *  </summary>
      ///	 * <param name="textName"> the text to append </param>
      ///	 
      public virtual void appendText(string textName)
      {
         XmlText newChild = OwnerDocument.CreateTextNode(textName);
         appendChild(newChild);
      }

      ///   
      ///	 <summary> * appends a entity reference to the actual element
      ///	 *  </summary>
      ///	 * <param name="refName"> the name of the entity reference </param>
      ///	 
      public virtual void appendEntityReference(string refName)
      {
         XmlEntityReference newChild = OwnerDocument.CreateEntityReference(refName);
         appendChild(newChild);
      }

      ///   
      ///	 <summary> * append a text element with text included
      ///	 *  </summary>
      ///	 * <param name="nodeName"> node name of the text element </param>
      ///	 * <param name="text"> the text to apend
      ///	 *  </param>
      ///	 * <returns> KElement the appended text element </returns>
      ///	 
      public virtual KElement appendTextElement(string nodeName, string text)
      {
         KElement kElem = appendElement(nodeName, null);
         kElem.appendText(text);

         return kElem;
      }

      // ************************** end of methods needed in JDFResponse
      // **********
      ///////
      // ************************** start of methods needed in JDFNode
      // ************

      ///   
      ///	 <summary> * merge nodes in a way that no duplicate elements are created<br>
      ///	 * <b>attention !! this kills pools !!</b> since elements in kElem overwrite those in *this
      ///	 *  </summary>
      ///	 * <param name="kElem"> the node element to merge with the current node </param>
      ///	 * <param name="bDelete"> if true KElement kElem will be deleted
      ///	 *  </param>
      ///	 * <returns> KElement the merged node element </returns>
      ///	 
      public virtual KElement mergeElement(KElement kElem, bool bDelete)
      {
         if (kElem == null)
            return this;

         VElement v = kElem.getChildElementVector(null, null, null, true, 0, false);

         for (int i = 0; i < v.Count; i++)
         {
            KElement m = v[i];
            int nThis = numChildElements(m.Name, null);

            if (nThis == 1)
            {
               int nE = kElem.numChildElements(m.Name, null);
               if (nE == 1)
               {
                  getElement(m.Name, null, 0).mergeElement(m, bDelete);
                  continue; // we've merged the only element and can continue
                  // with the next
               }
            }
            // it was impossible to merge, therefore simply copy over
            if (bDelete)
            {
               moveElement(m, null);
            }
            else
            {
               copyElement(m, null);
            }
         }
         setAttributes(kElem);

         return this;
      }

      ///   
      ///	 <summary> * GetChildWithAttribute - Get a child with matching attributes
      ///	 * <p>
      ///	 * default: getChildWithAttribute(nodeName, attName, null,attValue, 0, true)
      ///	 *  </summary>
      ///	 * <param name="nodeName"> name of the child node to search for </param>
      ///	 * <param name="attName"> attribute name to search for </param>
      ///	 * <param name="nameSpaceURI"> namespace to search for </param>
      ///	 * <param name="attVal"> the attribute value to search for, Wildcard supported ( <code>null</code>) </param>
      ///	 * <param name="index"> if more then one child meets the condition, you can specify the one to return via an index </param>
      ///	 * <param name="bDirect"> if true, looks only in direct children, else search through all children, grandchildren etc.
      ///	 *  </param>
      ///	 * <returns> KElement the element which matches the above conditions </returns>
      ///	 
      public virtual KElement getChildWithAttribute(string nodeName, string attName, string nameSpaceURI, string attVal, int index, bool bDirect)
      {
         string nodeNameLocal = nodeName;
         string nameSpaceURILocal = nameSpaceURI;
         string attValLocal = attVal;

         KElement kRet = null;
         XMLDocUserData userData = null;

         bool bID = attName.Equals(AttributeName.ID);
         if (bID && !isWildCard(attValLocal))
         {
            userData = getXMLDocUserData();
            if (userData != null)
            {
               kRet = userData.getTarget(attValLocal);
               if (kRet != null && ((bDirect && kRet.getParentNode_KElement() != this) || kRet.OwnerDocument != OwnerDocument))
               {
                  kRet = null; // it is somewhere else, not a child of this!
               }
               if (kRet != null)
               {
                  return kRet;
               }
            }
         }

         if (isWildCard(nodeNameLocal))
         {
            nodeNameLocal = null;
         }
         if (isWildCard(nameSpaceURILocal))
         {
            nameSpaceURILocal = null;
         }
         if (isWildCard(attValLocal))
         {
            attValLocal = null;
         }

         if (bDirect)
         { // inlined for performance
            KElement e0 = getFirstChildElement();
            if (e0 != null)
            {
               bool bAlwaysFit = nodeNameLocal == null && nameSpaceURILocal == null;
               do
               {
                  KElement e = e0;
                  if (e is JDFRefElement)
                  {
                     if (!(this is JDFResourcePool)) // zapp dead
                        // loops!
                        e = ((JDFRefElement)e0).getTarget();
                  }

                  if (e != null)
                  {
                     if ((bAlwaysFit || e.fitsName(nodeNameLocal, nameSpaceURILocal)) && (e.includesAttribute(attName, attValLocal)))
                     {
                        kRet = e;
                     }

                     // update ID cache while searching IDs
                     if (bID && userData != null)
                     {
                        string idVal = e.getAttribute_KElement(AttributeName.ID, null, null);
                        if (idVal != null)
                        {
                           userData.setTarget(e, idVal);
                        }
                     }
                  }

                  e0 = e0.getNextSiblingElement();

               }
               while (e0 != null && (kRet == null)); // loop to end if we are
               // filling the cache
            }
         }
         else
         {
            JDFAttributeMap m = new JDFAttributeMap(attName, attValLocal);
            kRet = getChildByTagName(nodeNameLocal, nameSpaceURILocal, index, m, bDirect, true);
         }

         return kRet;
      }

      ///   
      ///	 <summary> * Checks whether the current element has a child element NodeName
      ///	 * <p>
      ///	 * default: hasChildElement(String nodeName, null)
      ///	 *  </summary>
      ///	 * <param name="nodeName"> name of the node to check for </param>
      ///	 * <param name="nameSpaceURI"> nameSpaceURI to search in
      ///	 *  </param>
      ///	 * <returns> boolean true if there is a child with nodeName, otherwise false </returns>
      ///	 
      public virtual bool hasChildElement(string nodeName, string nameSpaceURI)
      {
         return !(getElement(nodeName, nameSpaceURI, 0) == null);
      }

      ///   
      ///	 <summary> * searches for the first child element occurence in this element or any ancestors
      ///	 * <p>
      ///	 * default: getInheritedElement(elementName, null, 0)
      ///	 *  </summary>
      ///	 * <param name="elementName"> name of the element to be searched </param>
      ///	 * <param name="nameSpaceURI"> XML-namespace </param>
      ///	 * <param name="iSkip"> leading siblings to be skipped
      ///	 *  </param>
      ///	 * <returns> JDFElement the element found </returns>
      ///	 
      public virtual KElement getInheritedElement(string elementName, string nameSpaceURI, int iSkip)
      {
         KElement kElem = getElement(elementName, nameSpaceURI, iSkip);

         if (kElem == null)
         {
            kElem = getParentNode_KElement();

            if (kElem != null)
            {
               kElem = kElem.getInheritedElement(elementName, nameSpaceURI, iSkip);
            }
         }

         return kElem;
      }

      // ************************** end of methods needed in JDFNode
      // **************
      ///////
      // ************************** start of methods needed in JDFRoot
      // ************

      ///   
      ///	 <summary> * Adds a NameSpace and maps the prefix to a URI. <br>
      ///	 * Checks all parents, whether such namespace is already defined in an ancestor
      ///	 *  </summary>
      ///	 * <param name="strPrefix"> the namespace prefix to set </param>
      ///	 * <param name="strNameSpaceURI"> the namespace URI to set </param>
      ///	 * <returns> boolean true if newly set, false if already there and matching </returns>
      ///	 
      public virtual bool addNameSpace(string strPrefix, string strNameSpaceURI)
      {
         bool fSuccess = false;

         string strNameSpace = (strPrefix == null || strPrefix.Length <= 0) ? JDFConstants.XMLNS : JDFConstants.XMLNS + JDFConstants.COLON + strPrefix;

         string strOldNameSpaceURI = getInheritedAttribute(strNameSpace, null, JDFConstants.EMPTYSTRING);
         string myNameSpaceURI = getNamespaceURI();

         if (!strNameSpaceURI.Equals(strOldNameSpaceURI) && !strNameSpaceURI.Equals(myNameSpaceURI))
         {
            fSuccess = true;
            setAttribute(strNameSpace, strNameSpaceURI, null);
         }

         return fSuccess;
      }

      ///   
      ///	 <summary> * sorts according to the lexical string representation of the xml objects
      ///	 * 
      ///	 * @author prosirai
      ///	 *  </summary>
      ///	 
      public class SimpleNodeComparator : IComparer<KElement>
      {
         //      
         //		 * (non-Javadoc)
         //		 * 
         //		 * @see java.util.Comparator#compare(java.lang.Object, java.lang.Object)
         //		 
         public int Compare(KElement o1, KElement o2)
         {
            int i = o1.Name.CompareTo(o2.Name);
            if (i != 0)
               return i;
            string i1 = o1.ToString();
            string i2 = o2.ToString();
            return i1.CompareTo(i2);
         }
      }

      ///   
      ///	 <summary> * sorts all child elements by alphabet
      ///	 *  </summary>
      ///	 
      public virtual void sortChildren()
      {
         sortChildren(new SimpleNodeComparator().Compare);
      }

      ///   
      ///	 <summary> * sorts all child elements by alphabet
      ///	 *  </summary>
      ///	 
      [MethodImpl(MethodImplOptions.Synchronized)]
      public virtual void sortChildren(Comparison<KElement> comparator)
      {
         VElement v = getChildElementVector_KElement(null, null, null, true, -1);
         v.Sort(comparator);
         int size = v.Count;
         for (int i = 0; i < size; i++)
         {
            KElement e = v[i];
            moveElement(e, null);
         }
      }

      ///   
      ///	 <summary> * this to string, used for debug purpose mostly
      ///	 *  </summary>
      ///	 * <returns> string representativ of this
      ///	 *  </returns>
      ///	 * <seealso cref= Object#toString() </seealso>
      ///	 
      public override string ToString()
      {
         string strJdf = JDFConstants.EMPTYSTRING;
         StringWriter osw = new StringWriter();
         try
         {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
            settings.Indent = false;
            settings.NewLineChars = Environment.NewLine;
            settings.ConformanceLevel = ConformanceLevel.Document;
            XmlWriter writer = XmlTextWriter.Create(osw, settings);

            XmlSerializer serial = new XmlSerializer(this.GetType());
            serial.Serialize(writer, this);

            strJdf = osw.ToString();
         }
         catch (IOException e)
         {
            strJdf = "### ERROR while serializing " + this.GetType().FullName + "(" + e.ToString() + ": " + e.Message + ")";
         }
         finally
         {
            osw.Close();
         }

         return strJdf;
      }

      ///   
      ///	 <summary> * serialize this to a string
      ///	 *  </summary>
      ///	 * <returns> String the dom element serialized as a string
      ///	 *  </returns>
      ///	 * <exception cref="JDFExcepion"> if an error occurs while serializing </exception>
      ///	 
      public virtual string toXML()
      {
         string strXML = JDFConstants.EMPTYSTRING;
         StringWriter osw = new StringWriter();

         try
         {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
            settings.Indent = false;
            settings.NewLineChars = Environment.NewLine;
            settings.ConformanceLevel = ConformanceLevel.Document;
            XmlWriter writer = XmlTextWriter.Create(osw, settings);

            XmlSerializer serial = new XmlSerializer(this.GetType());
            serial.Serialize(writer, this);

            strXML = osw.ToString();
         }
         catch (IOException)
         {
            throw new JDFException("ERROR while serializing " + this.GetType().FullName + " element");
         }
         finally
         {
            osw.Close();
         }

         return strXML;
      }

      // ************************** end of methods needed in JDFRoot
      // **************
      ///////
      // ************************** start of methods needed in JDFAncestorPool
      // ****

      ///   
      ///	 <summary> * Rename an attribute in this namespace
      ///	 * <p>
      ///	 * default: renameAttribute(oldName, newName, null, null)
      ///	 *  </summary>
      ///	 * <param name="oldName"> attribute name to move from </param>
      ///	 * <param name="newName"> attribute name to move to </param>
      ///	 * <param name="nameSpaceURI"> attribute nameSpaceURI to move from </param>
      ///	 * <param name="newNameSpaceURI"> attribute nameSpaceURI to move the name to </param>
      ///	 
      public virtual void renameAttribute(string oldName, string newName, string nameSpaceURI, string newNameSpaceURI)
      {
         if (hasAttribute(oldName, nameSpaceURI, false))
         {
            string strAttValue = getAttribute_KElement(oldName, nameSpaceURI, JDFConstants.EMPTYSTRING);

            setAttribute(newName, strAttValue, newNameSpaceURI);
            removeAttribute(oldName, nameSpaceURI);
         }
      }

      // ************************** end of methods needed in JDFAncestorPool
      // ******
      ///////
      // ************************** start of methods needed in JDFResource
      // ********

      ///   
      ///	 <summary> * Get a vector of all value of the attribute attName in the children of this node
      ///	 * <p>
      ///	 * default: getChildAttributeList(nodeName, attName, null, JDFConstants.WILDCARD, true, true)
      ///	 *  </summary>
      ///	 * <param name="nodeName"> element name you are searching for </param>
      ///	 * <param name="attName"> attributes you are looking for </param>
      ///	 * <param name="nameSpaceURI"> nameSpace you are searching for </param>
      ///	 * <param name="bDirect"> if true return value is a vector of all found elements. Otherwise the returned vector contains
      ///	 *            only the nodes </param>
      ///	 * <param name="bUnique"> if you want to make sure, the attribute is unique, set this boolean to true. Otherwise attribute
      ///	 *            attName is added to the returned vector
      ///	 *  </param>
      ///	 * <returns> Vector - vector with attributes </returns>
      ///	 
      public virtual VString getChildAttributeList(string nodeName, string attName, string nameSpaceURI, string attValue, bool bDirect, bool bUnique)
      {
         VString v = new VString();
         VElement vChildren = getChildrenByTagName(nodeName, nameSpaceURI, new JDFAttributeMap(attName, JDFConstants.EMPTYSTRING), bDirect, true, 0);

         bool bAttWildCard = isWildCard(attValue);

         for (int i = 0; i < vChildren.Count; i++)
         {
            bool bAddElement = true;
            KElement kElem = vChildren[i];
            string s = kElem.getAttribute_KElement(attName, nameSpaceURI, JDFConstants.EMPTYSTRING);
            // fill only matching attributes
            if (bAttWildCard || s.Equals(attValue))
            {
               if (bUnique && v.Contains(s))
               {
                  bAddElement = false;
               }

               if (bAddElement)
               {
                  v.Add(s);
               }
            }
         }

         return v;
      }

      ///   
      ///	 <summary> * Inserts the Element elementName before the existing Element node beforeChild. If beforeChild is <code>null</code>
      ///	 * , insert elementName at the end of the list of children. If elementName is a DocumentFragment object, all of its
      ///	 * children are inserted, in the same order, before beforeChild. If the elementName is already in the tree, it is
      ///	 * removed first.
      ///	 * <p>
      ///	 * default: insertBefore(elementName, beforeChild, null)
      ///	 *  </summary>
      ///	 * <param name="elementName"> The elementName to insert the element itself will be created </param>
      ///	 * <param name="beforeChild"> The reference element, i.e., the elemente before which the new element must be inserted </param>
      ///	 * <param name="nameSpaceURI"> The namespace to create elementName in
      ///	 *  </param>
      ///	 * <returns> KElement the element being inserted </returns>
      ///	 
      public virtual KElement insertBefore(string elementName, XmlNode beforeChild, string nameSpaceURI)
      {
         KElement newChild = createChildFromName(elementName, nameSpaceURI);
         if (newChild != null)
         {
            InsertBefore(newChild, beforeChild);
            newChild.init();
         }
         return newChild;
      }

      ///   
      ///	 <summary> * get a vector of all Children that match the strings defined in nodeNames
      ///	 *  </summary>
      ///	 * <param name="nodeNames"> list of node names that fit, both local and qualified node names are checked
      ///	 *  </param>
      ///	 * <returns> VElement the found child elements </returns>
      ///	 
      public virtual VElement getChildrenFromList(VString nodeNames, JDFAttributeMap map, bool bDirect, VElement v)
      {
         VElement vLocal = v;

         if (vLocal == null)
         {
            vLocal = new VElement();
         }
         KElement kElem = getFirstChildElement();

         while (kElem != null)
         {
            if (nodeNames.Contains(kElem.LocalName) || nodeNames.Contains(kElem.Name))
            {
               if (map == null || kElem.includesAttributes(map, true))
               {
                  vLocal.Add(kElem);
               }
            }
            if (!bDirect)
            {
               kElem.getChildrenFromList(nodeNames, map, bDirect, vLocal);
            }
            kElem = kElem.getNextSiblingElement();
         }
         return vLocal;
      }

      // ************************** end of methods needed in JDFSurface
      // ***********
      ///////
      // ************************** start of methods needed in JDFAutoxxx
      // *********

      ///   
      ///	 <summary> * Appends a new child element to the end of 'this', if it's maximum number of the children with defined name and
      ///	 * nameSpace doesn't exceed maxAllowed
      ///	 * <p>
      ///	 * default: AppendElementN(elementName, maxAllowed, null)
      ///	 *  </summary>
      ///	 * <param name="elementName"> name of the new child element </param>
      ///	 * <param name="maxAllowed"> the maximum number of children with defined name and nameSpace, that are allowed for 'this' </param>
      ///	 * <param name="nameSpaceURI"> nameSpace of the new child element
      ///	 *  </param>
      ///	 * <returns> KElement newly created child element
      ///	 *  </returns>
      ///	 * <exception cref="JDFException"> if more elements with name and namespace then maxAllowed already exist </exception>
      ///	 
      public virtual KElement appendElementN(string elementName, int maxAllowed, string nameSpaceURI)
      {
         if (numChildElements_KElement(elementName, nameSpaceURI) >= maxAllowed)
         {
            throw new JDFException("KElement:appendElementN:" + " too many elements (>" + maxAllowed + ") of type" + nameSpaceURI + JDFConstants.COLON + elementName);
         }

         return appendElement(elementName, nameSpaceURI);
      }

      // ************************** end of methods needed in JDFAutoxxx
      // ***********
      ///////
      // ************************** start of methods needed in misc/testNew
      // *******

      ///   
      ///	 <summary> * Gets the XPath full tree representation of 'this'
      ///	 *  </summary>
      ///	 * <returns> String the XPath representation of 'this' e.g. <code>/root/parent/element</code><br>
      ///	 *         <code>null</code> if parent of this is null (e.g. called on rootnode) </returns>
      ///	 * @deprecated use buildXPath(null,true); 
      ///	 
      [Obsolete("use buildXPath(null,true);")]
      public virtual string buildXPath()
      {
         return buildXPath(null, 1);
      }

      ///   
      ///	 <summary> * Gets the XPath full tree representation of 'this'
      ///	 *  </summary>
      ///	 * <param name="relativeTo"> relative path to which to create an xpath </param>
      ///	 * <returns> String the XPath representation of 'this' e.g. <code>/root/parent/element</code><br>
      ///	 *         <code>null</code> if parent of this is null (e.g. called on rootnode) </returns>
      ///	 * @deprecated use buildXPath(relativeTo,true); 
      ///	 
      [Obsolete("use buildXPath(relativeTo,true);")]
      public virtual string buildXPath(string relativeTo)
      {
         return buildXPath(relativeTo, 1);
      }

      ///   
      ///	 <summary> * Gets the XPath full tree representation of 'this'
      ///	 *  </summary>
      ///	 * <param name="relativeTo"> relative path to which to create an xpath </param>
      ///	 * <param name="methCountSiblings"> , if 1 count siblings, i.e. add '[n]' if 0, only specify the path of parents if 2 or 3,
      ///	 *            add [@ID="id"]
      ///	 *  </param>
      ///	 * <returns> String the XPath representation of 'this' e.g. <code>/root/parent/element</code><br>
      ///	 *         <code>null</code> if parent of this is null (e.g. called on rootnode) </returns>
      ///	 
      public virtual string buildXPath(string relativeTo, int methCountSiblings)
      {
         string path = Name;
         KElement p = getParentNode_KElement();

         if (methCountSiblings > 0)
         {
            if (methCountSiblings == 3 && hasAttribute_KElement(AttributeName.ID, null, false))
            {
               path += "[@ID=\"" + getAttribute(AttributeName.ID) + "\"]";
            }
            else
            {
               KElement e = (p != null) ? p.getElement(path, null, 0) : null;
               int i = 1;
               while (e != null)
               {
                  if (e.Equals(this))
                  {
                     path += "[" + Convert.ToString(i) + "]";
                     break;
                  }
                  do
                  {
                     e = e.getNextSiblingElement();
                  }
                  while (e != null && !e.fitsName_KElement(path, null));
                  i++;
               }
            }
         }
         path = "/" + path;
         if (p != null)
         {
            path = p.buildXPath(relativeTo, methCountSiblings) + path;
         }

         if (relativeTo != null)
         {
            if (path.StartsWith(relativeTo))
            {
               path = "." + path.Substring(relativeTo.Length);
               if (path.StartsWith(".["))
               {
                  int iB = path.IndexOf("]");
                  if (iB > 0)
                  {
                     path = "." + path.Substring(iB + 1);
                  }
               }
            }
         }
         return path;
      }

      ///   
      ///	 <summary> * Creates a new child element with defined Name and NameSpace and inserts it in front of the node with a name
      ///	 * bForeNode and namespace beforeNameSpaceURI, with index beforePos
      ///	 * <p>
      ///	 * default: InsertAt(nodeName, beforePos, null, null, null)
      ///	 *  </summary>
      ///	 * <param name="nodeName"> name of the new Element </param>
      ///	 * <param name="beforePos"> index of beforeNode, i.e if beforePos = 0, put it before the first occurrence </param>
      ///	 * <param name="beforeNode"> name of the node to put it before, default - any name, Wildcard supported </param>
      ///	 * <param name="nameSpaceURI"> nameSpace of the new node </param>
      ///	 * <param name="beforeNameSpaceURI"> nameSpace of the node to put it before, default - value of nameSpaceURI
      ///	 *  </param>
      ///	 * <returns> KElement the newly created element
      ///	 *  </returns>
      ///	 * <exception cref="JDFException"> if 'this' is a null element and thus nothing can be inserted in it </exception>
      ///	 
      public virtual KElement insertAt(string nodeName, int beforePos, string beforeNode, string nameSpaceURI, string beforeNameSpaceURI)
      {
         KElement kRet = null;
         string strBeforeNS = ((beforeNameSpaceURI == null) || beforeNameSpaceURI.Equals(JDFConstants.EMPTYSTRING)) ? nameSpaceURI : beforeNameSpaceURI;
         KElement kElem = getElement_KElement(beforeNode, strBeforeNS, beforePos);

         if (kElem == null)
         {
            kRet = appendElement(nodeName, nameSpaceURI);
         }
         else
         {
            kRet = insertBefore(nodeName, kElem, nameSpaceURI);
         }

         return kRet;
      }

      // ************************** end of methods needed in misc/testNew
      // *********
      ///////
      // ************************** start of additional methods
      // *******************

      ///   
      ///	 <summary> * Sets an attribute as defined by XPath to value <br>
      ///	 * 
      ///	 * @tbd enhance the subsets of allowed XPaths, now only .,..,/,@ are supported
      ///	 *  </summary>
      ///	 * <param name="path"> XPath abbreviated syntax representation of the attribute, e.g.:
      ///	 *            <code>parentElement/thisElement@thisAtt</code> <code>parentElement/thisElement[2]/@thisAtt</code> <code>parentElement/thisElement[@foo=\"bar\"]/@thisAtt</code> </param>
      ///	 * <param name="value"> string to be set as attribute value
      ///	 *  </param>
      ///	 * <exception cref="JDFException"> if the defined path is a bad attribute path </exception>
      ///	 
      public virtual void setXPathAttribute(string path, string @value)
      {
         int pos = path.LastIndexOf(JDFConstants.AET);
         if (pos == -1)
         {
            throw new JDFException("SetXPathAttribute - bad attribute path: " + path);
         }

         string att = path.Substring(pos + 1);
         string strAttrPath = path.Substring(0, pos);
         KElement kEle = getXPathElement(strAttrPath);
         if (kEle == null)
         {
            kEle = getCreateXPathElement(strAttrPath);
         }
         kEle.setAttribute(att, @value, null);
      }

      ///   
      ///	 <summary> * returns true if the element or attribute described by this XPath exists, else false
      ///	 *  </summary>
      ///	 * <param name="path"> the XPath to test for </param>
      ///	 * <returns> true if the element described by path exists </returns>
      ///	 
      public virtual bool hasXPathNode(string path)
      {
         string path2 = StringUtil.replaceString(path, "[@", "");
         int pos = path2.IndexOf(JDFConstants.AET);
         if (pos >= 0)
         {
            return getXPathAttribute(path, null) != null;
         }
         return getXPathElement(path) != null;
      }

      ///   
      ///	 <summary> * Gets an attribute value as defined by XPath namespace prefixes are resolved <br>
      ///	 * 
      ///	 * @tbd enhance the subsets of allowed XPaths, now only .,..,/,@ are supported TODO fix bug for attribute searches
      ///	 *      where the att value contains xpath syntax
      ///	 *  </summary>
      ///	 * <param name="path"> XPath abbreviated syntax representation of the attribute,
      ///	 *            <code>parentElement/thisElement/@thisAtt</code> <code>parentElement/thisElement[2]/@thisAtt</code> <code>parentElement[@a=\"b\"]/thisElement[@foo=\"bar\"]/@thisAtt</code> </param>
      ///	 * <param name="def"> default value if it doesn't exist
      ///	 *  </param>
      ///	 * <returns> String the String value of the attribute or null if the xpath element does not exist
      ///	 *  </returns>
      ///	 * <exception cref="JDFException"> if the defined path is a bad attribute path
      ///	 * @default getXPathAttribute(path, null); </exception>
      ///	 
      public virtual string getXPathAttribute(string path, string def)
      {
         int pos = path.LastIndexOf(JDFConstants.AET);
         if (pos == -1 || pos > 0 && path[pos - 1] == '[')
         {
            throw new JDFException("GetXPathAttribute - bad attribute path: " + path);
         }
         KElement kEle = getXPathElement(path.Substring(0, pos));
         return kEle == null ? def : kEle.getAttribute_KElement(path.Substring(pos + 1), null, def);
      }

      ///   
      ///	 <summary> * Gets an attribute value as defined by XPath namespace prefixes are resolved <br>
      ///	 * Attributes are searched for in partitioned resources if appropriate
      ///	 * 
      ///	 * @tbd enhance the subsets of allowed XPaths, now only .,..,/,@ are supported TODO fix bug for attribute searches
      ///	 *      where the att value contains xpath syntax
      ///	 *  </summary>
      ///	 * <param name="path"> XPath abbreviated syntax representation of the attribute,
      ///	 *            <code>parentElement/thisElement/@thisAtt</code> <code>parentElement/thisElement[2]/@thisAtt</code> <code>parentElement[@a=\"b\"]/thisElement[@foo=\"bar\"]/@thisAtt</code> </param>
      ///	 * <param name="def"> default value if it doesn't exist
      ///	 *  </param>
      ///	 * <returns> String the String value of the attribute or null if the xpath element does not exist
      ///	 *  </returns>
      ///	 * <exception cref="JDFException"> if the defined path is a bad attribute path
      ///	 * @default getXPathAttribute(path, null); </exception>
      ///	 
      public virtual string getInheritedXPathAttribute(string path, string def)
      {
         int pos = path.LastIndexOf(JDFConstants.AET);
         if (pos == -1 || pos > 0 && path[pos - 1] == '[')
         {
            throw new JDFException("GetXPathAttribute - bad attribute path: " + path);
         }
         KElement kEle = getXPathElement(path.Substring(0, pos));
         return kEle == null ? def : kEle.getAttribute(path.Substring(pos + 1), null, def);
      }

      ///   
      ///	 <summary> * Gets a map of attribute values as defined by XPath namespace prefixes are resolved <br>
      ///	 * 
      ///	 * @tbd enhance the subsets of allowed XPaths, now only .,..,/,@ are supported
      ///	 *  </summary>
      ///	 * <param name="path"> XPath abbreviated syntax representation of the attribute,
      ///	 *            <code>parentElement/thisElement/@thisAtt</code> <code>parentElement/thisElement[2]/@thisAtt</code> <code>parentElement[@a=\"b\"]/thisElement[@foo=\"bar\"]/@thisAtt</code> </param>
      ///	 * <param name="def"> default value if it doesn't exist
      ///	 *  </param>
      ///	 * <returns> String the String value of the attribute or null if the xpath element does not exist
      ///	 *  </returns>
      ///	 * <exception cref="JDFException"> if the defined path is a bad attribute path
      ///	 * @default getXPathAttribute(path, null); </exception>
      ///	 
      public virtual IDictionary<string, string> getXPathAttributeMap(string path)
      {
         int pos = path.LastIndexOf(JDFConstants.AET);
         if (pos == -1)
         {
            throw new JDFException("GetXPathAttribute - bad attribute path: " + path);
         }
         string attName = path.Substring(pos + 1);
         VElement vEle = getXPathElementVector(path.Substring(0, pos), 0);
         if (vEle == null)
         {
            return null;
         }
         // Java to C# Conversion - QUESTION: Need to implement LinkedHashMap?
         //LinkedHashMap map = new LinkedHashMap();
         IDictionary<string, string> map = CreateAttributeMap();
         for (int i = 0; i < vEle.Count; i++)
         {
            KElement e = vEle[i];
            string s = e.getAttribute_KElement(attName, null, null);
            if (s != null)
            {
               map[e.buildXPath(null, 1) + "/@" + attName] =  s;
            }
         }
         return map.Count > 0 ? map : null;
      }
      /// <summary>
      /// May need to make a LinkedHashMap class at some point.
      /// JDFElement overrides to return a JDFAttributeMap.
      /// </summary>
      /// <returns>A Dictionary.</returns>
      protected virtual IDictionary<string, string> CreateAttributeMap()
      {
         return new Dictionary<string, string>();
      }

      // public Node getXPathNode(String path)
      // {
      // Document doc=OwnerDocument;

      // XPathEvaluator ev=(XPathEvaluator)doc.getFeature("XPath", null);

      // XPathExpression ex=ev.createExpression(path, ev.createNSResolver(this));
      // return (Node) ex.evaluate(this, XPathResult.ANY_UNORDERED_NODE_TYPE,
      // null);
      // }
      ///   
      ///	 <summary> * gets an element as defined by XPath to value <br>
      ///	 * 
      ///	 * 
      ///	 * @tbd enhance the subsets of allowed XPaths, now only .,..,/,@ are supported
      ///	 *  </summary>
      ///	 * <param name="path"> XPath abbreviated syntax representation of the attribute, e.g <code>parentElement/thisElement</code>
      ///	 *            <code>parentElement/thisElement[2]</code> <code>parentElement[@a=\"b\"]/thisElement[@foo=\"bar\"]</code>
      ///	 *  </param>
      ///	 * <returns> KElement the specified element </returns>
      ///	 * <exception cref="IllegalArgumentException"> if path is not supported </exception>
      ///	 
      public virtual KElement getXPathElement(string path)
      {
         VElement v = getXPathElementVector(path, 1);
         if (v == null || v.Count < 1)
         {
            return null;
         }
         return v.item(0);
      }

      ///   
      ///	 <summary> * gets an vector of elements element as defined by XPath to value <br>
      ///	 * 
      ///	 * 
      ///	 * @tbd enhance the subsets of allowed XPaths, now only .,..,/,@,// are supported
      ///	 *  </summary>
      ///	 * <param name="path"> XPath abbreviated syntax representation of the attribute, e.g <code>parentElement/thisElement</code>
      ///	 *            <code>parentElement/thisElement[2]</code> <code>parentElement[@a=\"b\"]/thisElement[@foo=\"bar\"]</code>
      ///	 *  </param>
      ///	 * <returns> VElement the vector of matching elements
      ///	 *  </returns>
      ///	 * <exception cref="IllegalArgumentException"> if path is not supported </exception>
      ///	 
      public virtual VElement getXPathElementVector(string path, int maxSize)
      {
         return getXPathElementVectorInternal(path, maxSize, true);
      }

      ///   
      ///	 <summary> * gets an vector of elements element as defined by XPath to value <br>
      ///	 * 
      ///	 * 
      ///	 * @tbd enhance the subsets of allowed XPaths, now only .,..,/,@,// are supported
      ///	 *  </summary>
      ///	 * <param name="path"> XPath abbreviated syntax representation of the attribute, e.g <code>parentElement/thisElement</code>
      ///	 *            <code>parentElement/thisElement[2]</code> <code>parentElement[@a=\"b\"]/thisElement[@foo=\"bar\"]</code>
      ///	 *  </param>
      ///	 * <returns> VElement the vector of matching elements
      ///	 *  </returns>
      ///	 * <exception cref="IllegalArgumentException"> if path is not supported </exception>
      ///	 
      private VElement getXPathElementVectorInternal(string path, int maxSize, bool bLocal)
      {
         string pathLocal = path;

         if (pathLocal == null)
         {
            return null;
         }

         VElement vRet = new VElement();
         if (JDFConstants.EMPTYSTRING.Equals(pathLocal))
         {
            if (bLocal)
               vRet.Add(this);
            else
               vRet = getChildrenByTagName(null, null, null, false, true, 0);
            return vRet;
         }

         if (pathLocal.StartsWith(JDFConstants.SLASH))
         {
            if (pathLocal.StartsWith("//"))
            {
               return getDocRoot().getXPathElementVectorInternal(pathLocal.Substring(2), maxSize, false);
            }

            KElement r = getDocRoot();
            string rootNodeName = r.Name;
            int nextPos = pathLocal.IndexOf("/", 2);
            //.Net Substring different than java substring.
            string rootPath = nextPos > 0 ? pathLocal.Substring(1, (nextPos - 1)) : pathLocal.Substring(1);
            string nextPath = nextPos > 0 ? pathLocal.Substring(nextPos + 1) : "";
            if (rootPath.Equals(rootNodeName) || isWildCard(rootPath))
            {
               return r.getXPathElementVectorInternal(nextPath, maxSize, true);
            }

            throw new ArgumentException("Invalid root node name");

         }
         else if (pathLocal.StartsWith(JDFConstants.DOT))
         {
            if (pathLocal.StartsWith(JDFConstants.DOTSLASH))
            {
               return getXPathElementVectorInternal(pathLocal.Substring(JDFConstants.DOTSLASH.Length), maxSize, true);
            }

            if (pathLocal.StartsWith(JDFConstants.DOTDOTSLASH))
            {
               KElement parent = getParentNode_KElement();
               if (parent == null)
               {
                  return null;
               }

               return parent.getXPathElementVectorInternal(pathLocal.Substring(JDFConstants.DOTDOTSLASH.Length), maxSize, true);
            }
            else if (pathLocal.Equals(JDFConstants.DOT))
            {
               vRet.Add(this);
               return vRet;
            }
            else if (pathLocal.Equals(".."))
            {
               KElement parent = getParentNode_KElement();
               if (parent == null)
               {
                  return null;
               }

               vRet.Add(parent);
               return vRet;
            }
         }

         pathLocal = StringUtil.replaceString(pathLocal, "[@", "|||");
         int posB0 = pathLocal.IndexOf("[");
         int posBAt = pathLocal.IndexOf("|||");
         int iSkip = 0;
         string newPath = pathLocal;
         int pos = newPath.IndexOf(JDFConstants.SLASH);
         JDFAttributeMap map = null;
         bool bExplicitSkip = false;

         if (posB0 != -1 && (posB0 < pos || pos == -1)) // parse for [n]
         {
            int posB1 = pathLocal.IndexOf("]");

            // TODO fix escape attribute values

            //.Net Substring different than java substring.
            string n = pathLocal.Substring(posB0 + 1, (posB1-(posB0 + 1)));
            iSkip = StringUtil.parseInt(n, 0);
            if (iSkip <= 0)
               throw new ArgumentException("getXPathVector: bad index:" + iSkip);

            iSkip--;
            bExplicitSkip = true;
            newPath = pathLocal.Substring(0, posB0) + pathLocal.Substring(posB1 + 1);
            pos = newPath.IndexOf(JDFConstants.SLASH);
         }
         else if (posBAt != -1 && (posBAt < pos || pos == -1)) // parse for
         // [@a="b"]
         {
            int posB1 = pathLocal.IndexOf("]");
            map = getXPathAtMap(pathLocal, posBAt, posB1);
            newPath = pathLocal.Substring(0, posBAt) + pathLocal.Substring(posB1 + 1);
            pos = newPath.IndexOf(JDFConstants.SLASH);
         }

         if (pos != -1) // have another element
         {
            string elmName = newPath.Substring(0, pos);
            VElement ve;
            if (bLocal)
            {
               ve = getChildElementVector_KElement(elmName, null, map, true, 0);
            }
            else
            {
               ve = getElementsByTagName_KElement(elmName, null);
               if (LocalName.Equals(elmName) || isWildCard(newPath))
                  ve.Add(this);
            }

            if (ve == null || ve.Count <= iSkip)
            {
               return null;
            }

            int iFirst = bExplicitSkip ? iSkip : 0;
            int iLast = bExplicitSkip ? iSkip + 1 : ve.Count;
            for (int i = iFirst; i < iLast; i++) // loop in case multiple
            // elements contain the same
            // attribute
            {
               VElement eRet = null;
               KElement ee = ve[i];
               if (ee != null)
               {
                  eRet = ee.getXPathElementVectorInternal(newPath.Substring(pos + 1), maxSize, true);
               }

               if (eRet != null)
               {
                  vRet.addAll(eRet);
               }
            }

            return vRet.Count > 0 ? vRet : null;
         }
         // last element
         if (bExplicitSkip)
         {
            KElement e = getChildByTagName(newPath, null, iSkip, map, true, true);
            if (e == null)
            {
               return null;
            }

            vRet.Add(e);
            return vRet;
         }

         if (bLocal)
         {
            vRet = getChildElementVector_KElement(newPath, null, map, true, 0);
         }
         else
         {
            vRet = getElementsByTagName_KElement(newPath, null);
            if (LocalName.Equals(newPath) || isWildCard(newPath))
               vRet.Add(this);
         }

         return vRet;
      }

      private JDFAttributeMap getXPathAtMap(string path, int posBAt, int posB1)
      {
         JDFAttributeMap map = new JDFAttributeMap();
         //.Net Substring different than java substring.
         string attEqVal = path.Substring(posBAt + 3, (posB1 - (posBAt + 3)));
         // TODO multiple attributes, maybe tokenize by ","
         string attName = StringUtil.token(attEqVal, 0, "=");
         //.Net Substring different than java substring.
         string attVal = attEqVal.Substring(attName.Length + 2, ((attEqVal.Length - 1) - (attName.Length + 2)));
         map.put(attName, attVal);
         return map;
      }

      ///   
      ///	 <summary> * gets an element as defined by XPath to value and creates it if it does not exist <br>
      ///	 * 
      ///	 * @tbd enhance the subsets of allowed XPaths, now only .,..,/,@ are supported
      ///	 *  </summary>
      ///	 * <param name="path"> XPath abbreviated syntax representation of the attribute, <code>parentElement/thisElement</code>
      ///	 *            <code>parentElement/thisElement[2]</code> <code>parentElement[@a=\"b\"]/thisElement[@foo=\"bar\"]</code>
      ///	 *  </param>
      ///	 * <returns> KElement the specified element </returns>
      ///	 
      public virtual KElement getCreateXPathElement(string path)
      {
         if (path == null || path.Length == 0)
         {
            return this;
         }
         KElement e = getXPathElement(path);
         if (e != null)
         {
            return e;
         }
         int slash = path.IndexOf("/");
         if (slash > 0)
         {
            string next = path.Substring(0, slash);
            e = getXPathElement(next);
            if (e != null)
            {
               next = path.Substring(slash + 1);
               return e.getCreateXPathElement(next);
            }
         }

         if (path.StartsWith(JDFConstants.SLASH))
         {
            KElement r = getDocRoot();
            int nextPos = path.IndexOf(JDFConstants.SLASH, 2);
            //.Net Substring different than java substring.
            if (!path.Substring(1, (nextPos - 1)).Equals(r.Name))
            {
               throw new JDFException("GetCreateXPathElement:: invalid path: " + path);
            }

            if (nextPos == -1)
            {
               return this;
            }

            return r.getCreateXPathElement(path.Substring(nextPos + 1));
         }
         if (path.StartsWith(JDFConstants.DOT))
         {
            if (path.StartsWith(JDFConstants.DOTSLASH))
            {
               return getCreateXPathElement(path.Substring(2));
            }
            if (path.StartsWith(JDFConstants.DOTDOTSLASH))
            {
               return getParentNode_KElement().getCreateXPathElement(path.Substring(3));
            }
            if (path.Equals(JDFConstants.DOT))
            {
               return this;
            }
            if (path.Equals(".."))
            {
               return getParentNode_KElement();
            }
         }
         int posB0 = path.IndexOf("[");
         int iSkip = 0;
         string newPath = path;
         int pos = newPath.IndexOf(JDFConstants.SLASH);
         if (posB0 != -1 && (posB0 < pos || pos == -1))
         {
            int posB1 = path.IndexOf("]");
            //.Net Substring different than java substring.
            string siSkip = path.Substring(posB0 + 1, (posB1 - (posB0 + 1)));
            if (!StringUtil.isInteger(siSkip))
            {
               throw new ArgumentException("GetCreateXPath: illegal path:" + path);
            }
            iSkip = StringUtil.parseInt(siSkip, 1);
            iSkip--;
            newPath = path.Substring(0, posB0) + path.Substring(posB1 + 1);
            pos = newPath.IndexOf(JDFConstants.SLASH);
         }
         if (pos != -1)
         {
            int n = numChildElements(newPath.Substring(0, pos), null);
            for (int i = n; i < iSkip; i++)
            {
               appendElement(newPath.Substring(0, pos), null);
            }
            e = getCreateElement(newPath.Substring(0, pos), null, iSkip);
            return e.getCreateXPathElement(newPath.Substring(pos + 1));
         }
         int n2 = numChildElements(newPath, null);
         for (int i = n2; i < iSkip; i++)
         {
            appendElement(newPath, null);
         }
         return getCreateElement(newPath, null, iSkip);
      }

      ///   
      ///	 <summary> * checks if the current element has attributes
      ///	 *  </summary>
      ///	 * <returns> boolean true if at least one attribute is present </returns>
      ///	 
      public bool hasAttributes()
      {
         XmlNamedNodeMap nm = Attributes;
         int l = (nm == null) ? 0 : nm.Count;

         return l != 0;
      }

      ///   
      ///	 <summary> * checks wether this has node childs of the stated node type
      ///	 *  </summary>
      ///	 * <param name="nodeType"> <blockquote>
      ///	 *        <ul>
      ///	 *        <li>ELEMENT_NODE = 1 <li>ATTRIBUTE_NODE = 2 <li>TEXT_NODE = 3 <li> CDATA_SECTION_NODE = 4 <li>
      ///	 *        ENTITY_REFERENCE_NODE = 5 <li> ENTITY_NODE = 6 <li>PROCESSING_INSTRUCTION_NODE = 7 <li> COMMENT_NODE = 8
      ///	 *        <li>DOCUMENT_NODE = 9 <li>DOCUMENT_TYPE_NODE = 10 <li>DOCUMENT_FRAGMENT_NODE = 11 <li>NOTATION_NODE = 12
      ///	 *        <li> XML_DECL_NODE = 13 </blockquote>
      ///	 *        </ul>
      ///	 *  </param>
      ///	 * <returns> boolean true if there is at least one child of the stated node type, false otherwise </returns>
      ///	 
      protected internal virtual bool hasChildNodes(XmlNodeType nodeType)
      {
         bool bRet = false;
         XmlNode node = FirstChild;

         while (node != null && bRet == false)
         {
            if (node.NodeType == nodeType)
            {
               bRet = true;
            }
            else
            {
               node = node.NextSibling;
            }
         }

         return bRet;
      }

      ///   
      ///	 <summary> * checks if the current element has a child element
      ///	 *  </summary>
      ///	 * <returns> boolean - true if there is one or more child elements present </returns>
      ///	 
      public virtual bool hasChildElements()
      {
         return hasChildNodes(XmlNodeType.Element);
      }

      ///   
      ///	 <summary> * Get children from the actual element by the tag name, nameSpaceURI or attribute map. GetTree only follows direct
      ///	 * links, e.g. as in a JDF tree. Hidden nodes that are children of non-matching nodes are ignored
      ///	 *  </summary>
      ///	 * <param name="nodeName"> elementname you are searching for </param>
      ///	 * <param name="nameSpaceURI"> nameSpace you are searching for </param>
      ///	 * <param name="mAttrib"> attributes you are looking for. Wildcards in the attribute map are supported </param>
      ///	 * <param name="bDirect"> if true return value is a vector of all direct elements. Otherwise the returned vector contains
      ///	 *            nodes of arbitrary depth </param>
      ///	 * <param name="bAnd"> if true, a child is only added if it has all attributes specified in Attributes mAttrib
      ///	 *  </param>
      ///	 * <returns> VElement vector with all found elements </returns>
      ///	 
      public virtual VElement getTree(string nodeName, string nameSpaceURI, JDFAttributeMap mAttrib, bool bDirect, bool bAnd)
      {
         VElement v = new VElement();
         KElement e = getFirstChildElement();
         bool bHasNoMap = mAttrib == null || mAttrib.IsEmpty();
         bool bAlwaysFit = KElement.isWildCard(nodeName) && KElement.isWildCard(nameSpaceURI);

         while (e != null)
         {
            if (bAlwaysFit || e.fitsName_KElement(nodeName, nameSpaceURI))
            {
               if (bHasNoMap || e.includesAttributes(mAttrib, bAnd))
               {
                  // this guy is the one
                  v.Add(e);
                  if (!bDirect)
                  { // if not direct, recurse
                     VElement vv = e.getTree(nodeName, nameSpaceURI, mAttrib, bDirect, bAnd);
                     v.AddRange(vv);
                  }
               }
            }
            e = e.getNextSiblingElement();
         }

         return v;
      }

      ///   
      ///	 <summary> * Get a vector of direct child element names that exist but are unknown in this element.
      ///	 *  </summary>
      ///	 * <returns> a <code>vString</code> that contains missing element keys </returns>
      ///	 
      public virtual VString getInsertElements()
      {
         VString vKnownElements = knownElements();
         VString vUniqueElements = uniqueElements();
         VString vStrRet = getInsertElementVector(vKnownElements, vUniqueElements);
         return vStrRet;
      }

      ///   
      ///	 <summary> * get a <code>vString</code> vector of direct child element names that may be inserted in this element. This means
      ///	 * that a element which is already present as a child and has a max occurs of 1 will not be part of the returned
      ///	 * <code>vString</code>
      ///	 *  </summary>
      ///	 * <param name="vKnownKeys"> a <code>vString</code> list of known element tag names. If you want a complete list of all
      ///	 *            known Elements use <code>KnownElements()</code> from KElement to get a list. Or call
      ///	 *            <code>GetInsertElements(int nMax)</code>
      ///	 *  </param>
      ///	 * <param name="vUnique"> <code>vString</code> a list of elements that may occur only once. Use UniqueElements() to get a
      ///	 *            <code>String</code> which contains all valid unique Elements from this.
      ///	 *  </param>
      ///	 * <returns> VString a vector of strings that contains insertable element keys
      ///	 *  </returns>
      ///	 * <seealso cref= #knownElements() </seealso>
      ///	 * <seealso cref= #getInsertElements() </seealso>
      ///	 * <seealso cref= #uniqueElements() </seealso>
      ///	 
      public virtual VString getInsertElementVector(VString vKnownKeys, VString vUnique)
      {
         VString vAtts = new VString(getElementNameVector());
         VString vInsert = vKnownKeys;

         for (int i = 0; i < vAtts.Count; i++)
         {
            if (vUnique.Contains(vAtts[i]))
            {
               vInsert.Remove(vAtts[i]);
            }
         }

         return vInsert;
      }

      ///   
      ///	 <summary> * Get child from the actual element by the tag name, nameSpaceURI or attribute map. GetTree only follows direct
      ///	 * links, e.g. as in a JDF tree. Hidden nodes that are children of non-matching nodes are ignored
      ///	 *  </summary>
      ///	 * <param name="nodeName"> elementname you are searching for.<br>
      ///	 *            Required, no default.
      ///	 *  </param>
      ///	 * <param name="nameSpaceURI"> nameSpace you are searching for.<br>
      ///	 *            Default is <code>null</code>
      ///	 *  </param>
      ///	 * <param name="mAttrib"> attributes you are looking for <br>
      ///	 *            Wildcards in the attribute map are supported. Default is an empty Map
      ///	 *  </param>
      ///	 * <param name="bDirect"> if true, return value is a vector of all direct elements.<br>
      ///	 *            Otherwise the returned vector contains nodes of arbitrary depth. <br>
      ///	 *            Default is false.
      ///	 *  </param>
      ///	 * <param name="bAnd"> if true, a child is only added if it has all attributes specified in Attributes mAttrib.<br>
      ///	 *            Default is true.
      ///	 *  </param>
      ///	 * <returns> KElement the first found element </returns>
      ///	 
      public virtual KElement getTreeElement(string nodeName, string nameSpaceURI, JDFAttributeMap mAttrib, bool bDirect, bool bAnd)
      {
         if (!bDirect && (mAttrib == null || includesAttributes(mAttrib, bAnd)))
         {
            return this;
         }
         KElement e = getFirstChildElement();
         bool bAlwaysFit = isWildCard(nodeName) && isWildCard(nameSpaceURI);

         while (e != null)
         {
            if (bAlwaysFit || e.fitsName_KElement(nodeName, nameSpaceURI))
            {
               if (bDirect && (mAttrib == null || e.includesAttributes(mAttrib, bAnd)))
               {
                  // this guy is the one
                  return e;
               }
               else if (!bDirect)
               { // if not direct, recurse
                  KElement ee = e.getTreeElement(nodeName, nameSpaceURI, mAttrib, bDirect, bAnd);
                  if (ee != null)
                  {
                     return ee;
                  }
               }
            }
            e = e.getNextSiblingElement();
         }
         // nothing found
         return null;
      }

      ///   
      ///	 <summary> * gets the i'th text child node of 'this'
      ///	 *  </summary>
      ///	 * <param name="i"> index of the child text node, you are searching for
      ///	 *  </param>
      ///	 * <returns> String the text if the i'th text node. <code>null</code> if the i'th text node does not exists </returns>
      ///	 
      public virtual string getText(int i)
      {
         XmlNode n = getChildNode(XmlNodeType.Text, i);
         return (n == null) ? null : n.Value;
      }

      ///   
      ///	 <summary> * Gets of 'this' the text of the i'th XML CData section. This section may also contain &lt; and &gt;.
      ///	 *  </summary>
      ///	 * <param name="i"> index of the CData section child node, you are searching for
      ///	 *  </param>
      ///	 * <returns> String content of the i'th XML CData section </returns>
      ///	 
      public virtual string getCData(int i)
      {
         XmlNode n = getChildNode(XmlNodeType.CDATA, i);
         return (n == null) ? null : n.Value;
      }

      ///   
      ///	 <summary> * gets of 'this' the text of the i-th child XMLComment. <code><!-- this is a XMLComment --></code> would return
      ///	 * <code>this is a XMLComment</code>
      ///	 *  </summary>
      ///	 * <param name="i"> index of the XMLComment child node, you are searching for
      ///	 *  </param>
      ///	 * <returns> String text of the i-th XMLComment, null if i is higher then the number of child nodes </returns>
      ///	 
      public virtual string getXMLComment(int i)
      {
         XmlNode n = getChildNode(XmlNodeType.Comment, i);
         return (n == null) ? null : n.Value;
      }

      ///   
      ///	 <summary> * Checks, if this has any missing attributes
      ///	 *  </summary>
      ///	 * <returns> boolean true, if one or more attributes are missing </returns>
      ///	 
      public virtual bool hasMissingAttributes()
      {
         return getMissingAttributes(1).Count > 0;
      }

      ///   
      ///	 <summary> * Checks, if this has are any unknown attributes
      ///	 *  </summary>
      ///	 * <param name="bIgnorePrivate"> if true, looks only in default and JDF namespaces
      ///	 *  </param>
      ///	 * <returns> boolean true, if one or more attributes are unknown </returns>
      ///	 
      public virtual bool hasUnknownAttributes(bool bIgnorePrivate)
      {
         return getUnknownAttributes(bIgnorePrivate, 1).Count > 0;
      }

      ///   
      ///	 <summary> * Tests, whether 'this' has any missing direct child elements
      ///	 *  </summary>
      ///	 * <returns> boolean true, if one or more direct child elements are missing </returns>
      ///	 
      public virtual bool hasMissingElements()
      {
         return getMissingElements(1).Count > 0;
      }

      ///   
      ///	 <summary> * Tests, whether 'this' has any unknown direct child elements
      ///	 *  </summary>
      ///	 * <param name="bIgnorePrivate"> if true, only looks in default and JDF namespaces </param>
      ///	 * <returns> boolean true if there are any unknown elements (in respect to the parameter) </returns>
      ///	 
      public virtual bool hasUnknownElements(bool bIgnorePrivate)
      {
         return getUnknownElements(bIgnorePrivate, 1).Count > 0;
      }

      ///   
      ///	 <summary> * copy an attribute from src to this
      ///	 * <p>
      ///	 * default: copyAttribute(attrib, src, null, null, null)
      ///	 *  </summary>
      ///	 * <param name="attrib"> the name of the attribute to copy (if source attribute is different only the value will be copied) </param>
      ///	 * <param name="src"> source element where the attribute to be copied resides </param>
      ///	 * <param name="srcAttrib"> attribute to copy, defaults to the value of attrib </param>
      ///	 * <param name="nameSpaceURI"> of the attribute in the destination </param>
      ///	 * <param name="srcNameSpaceURI"> of the attribute in the source, defaults to the value of nameSpaceURI
      ///	 * @default copyAttribute(attrib,src,null,null,null); </param>
      ///	 
      public virtual void copyAttribute(string attrib, KElement src, string srcAttrib, string nameSpaceURI, string srcNameSpaceURI)
      {
         string attribLocal = attrib;

         string strSrcAttrib = (srcAttrib == null) || srcAttrib.Equals(JDFConstants.EMPTYSTRING) ? attribLocal : srcAttrib;
         string strNameSpace = (srcNameSpaceURI == null) || srcNameSpaceURI.Equals(JDFConstants.EMPTYSTRING) ? nameSpaceURI : srcNameSpaceURI;
         if (strNameSpace != null && KElement.xmlnsPrefix(attribLocal) == null)
         {
            XmlAttribute an = src.getDOMAttr(strSrcAttrib, srcNameSpaceURI, false);
            if (an != null)
            {
               string pre = an.Prefix;
               if (!isWildCard(pre))
                  attribLocal = pre + ":" + attribLocal;
            }
         }

         setAttribute(attribLocal, src.getAttribute_KElement(strSrcAttrib, srcNameSpaceURI, null), strNameSpace);
      }

      ///   
      ///	 <summary> * copy an attribute from src to this - shorthand if no renaming or namespace handling is necessary
      ///	 * <p>
      ///	 * default: copyAttribute(attrib, src, null, null, null)
      ///	 *  </summary>
      ///	 * <param name="attrib"> the name of the attribute to copy (if source attribute is different only the value will be copied) </param>
      ///	 * <param name="src"> source element where the attribute to be copied resides </param>
      ///	 
      public virtual void copyAttribute(string attrib, KElement src)
      {

         copyAttribute(attrib, src, null, null, null);
      }

      ///   
      ///	 <summary> * moves an attribute from src to this, the attribute will be removed from src and moved to this.
      ///	 * <p>
      ///	 * default: moveAttribute(attrib, src, null, null, null)
      ///	 *  </summary>
      ///	 * <param name="attrib"> where to move the attribute </param>
      ///	 * <param name="src"> element to move from </param>
      ///	 * <param name="srcAttrib"> the attribute to move. If empty string, the string attrib is used as source and target </param>
      ///	 * <param name="nameSpaceURI"> the NamespaceURI to search in </param>
      ///	 
      public virtual void moveAttribute(string attrib, KElement src, string srcAttrib, string nameSpaceURI, string srcNameSpaceURI)
      {
         KElement srcLocal = src;
         string nameSpaceURILocal = nameSpaceURI;

         if (srcLocal == null)
            srcLocal = this;

         string strSrcAttrib = (srcAttrib == null) || srcAttrib.Equals(JDFConstants.EMPTYSTRING) ? attrib : srcAttrib;
         string strNameSpace = (srcNameSpaceURI == null) || srcNameSpaceURI.Equals(JDFConstants.EMPTYSTRING) ? nameSpaceURILocal : srcNameSpaceURI;
         if (xmlnsPrefix(attrib) != null && nameSpaceURILocal == null)
         {
            bool b = srcLocal.hasAttribute(strSrcAttrib, strNameSpace, false);
            if (b)
            {
               XmlAttribute attr = srcLocal.getDOMAttr(strSrcAttrib, strNameSpace, true);
               if (attr != null)
               {
                  nameSpaceURILocal = attr.NamespaceURI;
               }
            }
         }

         string attribute = srcLocal.getAttribute(strSrcAttrib, strNameSpace, null);
         if (attribute != null)
         {
            srcLocal.removeAttribute(strSrcAttrib, strNameSpace);
         }

         setAttribute(attrib, attribute);
      }

      ///   
      ///	 <summary> * Tests, whether 'this' contains any text child nodes
      ///	 *  </summary>
      ///	 * <returns> boolean true, if there are one or more text child nodes </returns>
      ///	 
      public virtual bool hasChildText()
      {
         return hasChildNodes(XmlNodeType.Text);
      }

      ///   
      ///	 <summary> * gets a concatenated string representing of all direct text child nodes
      ///	 *  </summary>
      ///	 * <returns> String the concatenated values of all direct text child nodes empty string if no child nodes exist </returns>
      ///	 
      public virtual string getText()
      {
         int iBufferSize = 100;
         StringBuilder strBuff = new StringBuilder(iBufferSize);

         XmlNodeList nodeList = ChildNodes;
         for (int i = 0; i < nodeList.Count; i++)
         {
            XmlNode node = nodeList[i];
            if (node.NodeType == XmlNodeType.Text)
            {
               strBuff.Append(node.Value);
            }
         }

         return strBuff.Length <= 0 ? null : strBuff.ToString();
      }

      ///   
      ///	 <summary> * removes all text children of the current node </summary>
      ///	 
      public virtual void removeAllText()
      {
         XmlNodeList allNodes = ChildNodes;

         for (int i = 0; i < allNodes.Count; i++)
         {
            XmlNode node = allNodes[i];

            if (node.NodeType == XmlNodeType.Text)
            {
               removeChild(node);
            }
         }
      }

      ///   
      ///	 <summary> * Moves 'this' from parent to grandparent or to the closest ancestor with name newParentName
      ///	 *  </summary>
      ///	 * <param name="newParentName"> name of the parent to recursively search, defaults to any name
      ///	 *  </param>
      ///	 * <returns> this, null if failed (e.g. no parentNode found) </returns>
      ///	 
      public virtual KElement pushUp(string newParentName)
      {
         KElement kEle = null;
         XmlNode parent = ParentNode;

         if (parent != null)
         {
            do
            {
               parent = parent.ParentNode;
            }
            while (parent != null && newParentName != null && !newParentName.Equals(JDFConstants.EMPTYSTRING) && !parent.Name.Equals(newParentName));

            if (parent != null)
            {
               kEle = ((KElement)parent).moveElement(this, null);
            }
         }

         return kEle;
      }

      ///   
      ///	 <summary> * count the number of child nodes of DOM nodeType nodeType (0=count all)
      ///	 *  </summary>
      ///	 * <param name="nodeType"> DOM nodeType <blockquote>
      ///	 *            <ul>
      ///	 *            <li>count all = 0 <li>ELEMENT_NODE = 1 <li>ATTRIBUTE_NODE = 2 <li>TEXT_NODE = 3 <li>CDATA_SECTION_NODE
      ///	 *            = 4 <li> ENTITY_REFERENCE_NODE = 5 <li>ENTITY_NODE = 6 <li> PROCESSING_INSTRUCTION_NODE = 7 <li>
      ///	 *            COMMENT_NODE = 8 <li> DOCUMENT_NODE = 9 <li>DOCUMENT_TYPE_NODE = 10 <li> DOCUMENT_FRAGMENT_NODE = 11
      ///	 *            <li>NOTATION_NODE = 12 <li> XML_DECL_NODE = 13 </blockquote>
      ///	 *            </ul> </param>
      ///	 * <returns> number of child nodes with "nodeType" </returns>
      ///	 
      public virtual int numChildNodes(XmlNodeType nodeType)
      {
         int i = 0;
         XmlNode n = FirstChild;
         while (n != null)
         {
            if (nodeType == 0 || n.NodeType == nodeType)
            {
               i++;
            }
            n = n.NextSibling;
         }
         return i;
      }

      ///   
      ///	 <summary> * removes the i'th child node, that match NodeType
      ///	 *  </summary>
      ///	 * <param name="nodeType"> the DOM NodeType,if 0 count all nodes <blockquote>
      ///	 *            <ul>
      ///	 *            <li>ELEMENT_NODE = 1 <li>ATTRIBUTE_NODE = 2 <li>TEXT_NODE = 3 <li>CDATA_SECTION_NODE = 4 <li>
      ///	 *            ENTITY_REFERENCE_NODE = 5 <li> ENTITY_NODE = 6 <li>PROCESSING_INSTRUCTION_NODE = 7 <li> COMMENT_NODE =
      ///	 *            8 <li>DOCUMENT_NODE = 9 <li>DOCUMENT_TYPE_NODE = 10 <li>DOCUMENT_FRAGMENT_NODE = 11 <li>NOTATION_NODE
      ///	 *            = 12 <li>XML_DECL_NODE = 13 </blockquote>
      ///	 *            </ul> </param>
      ///	 * <param name="i"> index of the child nodes to remove
      ///	 *  </param>
      ///	 * <returns> true if success, false if failed (no i'th node of nodeType found) </returns>
      ///	 
      public virtual bool removeChildNode(XmlNodeType nodeType, int i)
      {
         bool bRemoved = false;
         XmlNode n = getChildNode(nodeType, i);

         if (n != null)
         {
            removeChild(n);
            bRemoved = true;
         }

         return bRemoved;
      }

      ///   
      ///	 <summary> * Removes the i'th text node of 'this'
      ///	 *  </summary>
      ///	 * <param name="i"> index of the text node to remove. First node has index 0, second 1, etc. </param>
      ///	 
      public virtual void removeChildText(int i)
      {
         removeChildNode(XmlNodeType.Text, i);
      }

      ///   
      ///	 <summary> * Removes the i'th XML CData section
      ///	 *  </summary>
      ///	 * <param name="i"> index of the CData section child node to remove </param>
      ///	 
      public virtual void removeCData(int i)
      {
         removeChildNode(XmlNodeType.CDATA, i);
      }

      ///   
      ///	 <summary> * removes the i'th XMLComment node
      ///	 *  </summary>
      ///	 * <param name="i"> index of the XMLComment node to remove </param>
      ///	 
      public virtual void removeXMLComment(int i)
      {
         removeChildNode(XmlNodeType.Comment, i);
      }

      ///   
      ///	 <summary> * Gets the number of direct child nodes of 'this', that match NodeType
      ///	 *  </summary>
      ///	 * <param name="nodeType"> the DOM NodeType, if 0 count all nodes <blockquote>
      ///	 *            <ul>
      ///	 *            <li>ELEMENT_NODE = 1 <li>ATTRIBUTE_NODE = 2 <li>TEXT_NODE = 3 <li>CDATA_SECTION_NODE = 4 <li>
      ///	 *            ENTITY_REFERENCE_NODE = 5 <li> ENTITY_NODE = 6 <li>PROCESSING_INSTRUCTION_NODE = 7 <li> COMMENT_NODE =
      ///	 *            8 <li>DOCUMENT_NODE = 9 <li>DOCUMENT_TYPE_NODE = 10 <li>DOCUMENT_FRAGMENT_NODE = 11 <li>NOTATION_NODE
      ///	 *            = 12 <li>XML_DECL_NODE = 13 </blockquote>
      ///	 *            </ul> </param>
      ///	 * <returns> int: the counted number of direct child nodes, that match NodeType </returns>
      ///	 
      public virtual int getNumChildNodes(XmlNodeType nodeType)
      {
         int n = 0;

         XmlNodeList nodeList = ChildNodes;
         for (int i = 0; i < nodeList.Count; i++)
         {
            if (nodeList[i].NodeType == nodeType)
            {
               n++;
            }
         }

         return n;
      }

      ///   
      ///	 <summary> * Gets the number of direct text child nodes
      ///	 *  </summary>
      ///	 * <returns> int: the number of direct text child nodes in 'this' </returns>
      ///	 
      public virtual int getNumChildText()
      {
         return getNumChildNodes(XmlNodeType.Text);
      }

      ///   
      ///	 <summary> * gets the number of direct child CData sections
      ///	 *  </summary>
      ///	 * <returns> int: the number of direct child CData sections </returns>
      ///	 
      public virtual int getNumCDatas()
      {
         return getNumChildNodes(XmlNodeType.CDATA);
      }

      ///   
      ///	 <summary> * gets the number of direct XMLComment child nodes of 'this'
      ///	 *  </summary>
      ///	 * <returns> int: the number of direct XMLComment child nodes </returns>
      ///	 
      public virtual int getNumXMLComments()
      {
         return getNumChildNodes(XmlNodeType.Comment);
      }

      ///   
      ///	 <summary> * gets the n'th child node of nodetype <code>nodeType</code> with n = iPos
      ///	 *  </summary>
      ///	 * <param name="nodeType"> the DOM node type to get <blockquote>
      ///	 *        <ul>
      ///	 *        <li>ELEMENT_NODE = 1 <li>ATTRIBUTE_NODE = 2 <li>TEXT_NODE = 3 <li> CDATA_SECTION_NODE = 4 <li>
      ///	 *        ENTITY_REFERENCE_NODE = 5 <li> ENTITY_NODE = 6 <li>PROCESSING_INSTRUCTION_NODE = 7 <li> COMMENT_NODE = 8
      ///	 *        <li>DOCUMENT_NODE = 9 <li>DOCUMENT_TYPE_NODE = 10 <li>DOCUMENT_FRAGMENT_NODE = 11 <li>NOTATION_NODE = 12
      ///	 *        <li> XML_DECL_NODE = 13 </blockquote>
      ///	 *        </ul>
      ///	 *  </param>
      ///	 * <param name="iPos"> the index of the node with default 0 for the first occurance </param>
      ///	 * <returns> KElement: a node that matches the filter, null if iPos is higher then the number of child nodes </returns>
      ///	 
      protected internal virtual XmlNode getChildNode(XmlNodeType nodeType, int iPos)
      {
         XmlNode retNode = null;
         XmlNode node = FirstChild;
         int i = 0;

         // iPos + 1 because we need to stop after the iPos
         // turn and i will then be iPos + 1
         while ((node != null) && (i != iPos + 1))
         {
            if (node.NodeType == nodeType)
            {
               if (i++ == iPos)
               {
                  retNode = node;
               }
            }
            node = node.NextSibling;
         }

         return retNode;
      }

      ///   
      ///	 <summary> * get the namespace prefix from a qualified name. For example, nodename <code>exp:myexampley</code> would return
      ///	 * <code>exp</code>
      ///	 *  </summary>
      ///	 * @deprecated use xmlnsPrefix()
      ///	 *  
      ///	 * <param name="s"> the qualified name
      ///	 *  </param>
      ///	 * <returns> namespace of the qualified name </returns>
      ///	 
      [Obsolete("use xmlnsPrefix()")]
      public static string xmlNameSpace(string s)
      {

         return xmlnsPrefix(s);
      }

      ///   
      ///	 <summary> * sets multiple attributes at once both arrays need to be of equal length.
      ///	 *  </summary>
      ///	 * <param name="myAttributes"> array of attributes </param>
      ///	 * <param name="strValues"> array of values </param>
      ///	 * <exception cref="ArrayIndexOutOfBoundsException"> if the arrays are not of equal length </exception>
      ///	 * @deprecated use setAttributes(JDFAttributeMap) 
      ///	 
      [Obsolete("use setAttributes(JDFAttributeMap)")]
      public virtual void setAttributes(string[] myAttributes, string[] strValues)
      {
         if (myAttributes.Length != strValues.Length)
         {
            throw new IndexOutOfRangeException();
         }

         JDFAttributeMap attributeValueMap = new JDFAttributeMap();

         for (int nPara = 0; nPara < myAttributes.Length; nPara++)
         {
            attributeValueMap.put(myAttributes[nPara], strValues[nPara]);
         }

         setAttributes(attributeValueMap);
      }

      ///   
      ///	 <summary> * used by get localname
      ///	 *  </summary>
      ///	 * <param name="pc"> the qualifiedname </param>
      ///	 * <returns> the local part of the qualified name, null if no local name exists </returns>
      ///	 
      public static string xmlnsLocalName(string pc)
      {
         if (pc != null)
         {
            int posColon = pc.IndexOf(':');
            if (posColon == -1)
            {
               return pc;
            }
            else if (posColon == pc.Length - 1)
            {
               return null;
            }
            return pc.Substring(posColon + 1);
         }
         return null;
      }

      ///   
      ///	 <summary> * get the namespace of the qualified name * <blockquote><b>namespace</b>:localname</blockquote>
      ///	 *  </summary>
      ///	 * <param name="pc"> the qualified name.
      ///	 * @deprecated </param>
      ///	 * <returns> the namespace of the qualified name. An Emptystring if pc is null or no namespace found. </returns>
      ///	 
      [Obsolete]
      public static string getXMLNSNameSpace(string pc)
      {
         return xmlnsPrefix(pc);
      }

      public virtual void setXSIType(string typ)
      {
         setAttribute(AttributeName.XSITYPE, typ, AttributeName.XSIURI);
      }

      ///   
      ///	 <summary> * returns the xsi:type of this element, null if not present
      ///	 *  </summary>
      ///	 * <returns> String the xsi:type of this element, null if not present </returns>
      ///	 
      public virtual string getXSIType()
      {
         return getAttribute("type", AttributeName.XSIURI, null);
      }

      ///   
      ///	 <summary> * Parses pc for it's namespace prefix
      ///	 * <p>
      ///	 * <blockquote><code>ns:foo</code> will return <code>ns</code></blockquote>
      ///	 *  </summary>
      ///	 * @deprecated use xmlnsPrefix 
      ///	 * <param name="pc"> string to parse
      ///	 *  </param>
      ///	 * <returns> String namespace prefix of pc, emptyspace if no ":" is in pc
      ///	 *  </returns>
      ///	 
      [Obsolete("use xmlnsPrefix")]
      public static string getXMLNSPrefix(string pc)
      {
         return xmlnsPrefix(pc);
      }

      ///   
      ///	 <summary> * Fix the parentNode from this. If flagSrc == null the flags of parentNode are used.
      ///	 *  </summary>
      ///	 * <param name="parentSrc"> where we get the parent from </param>
      ///	 * <param name="flagSrc"> where er get the flags from </param>
      ///	 
      // Java to C# Conversion - NOTE: Don't believe we need this in .NET.  No flags to set anyway.
      //private void fixParent(KElement parentSrc, KElement flagSrc)
      //{
      //// tell him where he belongs to and...
      //   this.ownerNode = parentSrc.ownerNode;
      //// that he is owned (the flags are a bitmask)
      //   if (flagSrc == null)
      //   {
      //      this.flags = parentSrc.flags;
      //   }
      //   else
      //   {
      //      this.flags = flagSrc.flags;
      //   }
      //}

      ///   
      ///	 <summary> * Returns the type of the given attribute for the latest JDF version. Attribute types of previous versions have to
      ///	 * be provided by attribute-specific functions (if necessary).
      ///	 *  </summary>
      ///	 * <param name="attributeName"> name of the attribute </param>
      ///	 * <returns> EnumAttributeType the attribute's type </returns>
      ///	 
      public virtual AttributeInfo.EnumAttributeType attributeType(string attributeName)
      {
         return getTheAttributeInfo().getAttributeType(attributeName);
      }

      ///   
      ///	 <summary> * Sets an XML Text <br>
      ///	 * the text contents of this to the value of text
      ///	 *  </summary>
      ///	 * <param name="text"> XML Text to set
      ///	 *  </param>
      ///	 * <exception cref="JDFException"> if 'this' is a null element and thus nothing can be inserted in it </exception>
      ///	 
      public virtual void setText(string text)
      {
         removeAllText();
         appendText(text);
      }

      public void removeAttribute(string attrib)
      {
         removeAttribute_KElement(attrib, null);
      }

      public void removeAttributeNS(string nameSpaceURI, string attrib)
      {
         removeAttribute_KElement(attrib, nameSpaceURI);
      }

      public XmlAttribute removeAttributeNode(XmlAttribute arg0)
      {
         setDirty(true);
         return base.RemoveAttributeNode(arg0);
      }

      public XmlAttribute setAttributeNode(XmlAttribute arg0)
      {
         setDirty(true);
         return base.SetAttributeNode(arg0);
      }

      public XmlAttribute setAttributeNodeNS(XmlAttribute arg0)
      {
         setDirty(true);
         return base.SetAttributeNode(arg0);
      }

      public void setAttributeNS(string nsURI, string arg1, string arg2)
      {
         setDirty(true);
         setAttribute(arg1, arg2, nsURI);
      }

      public void normalize()
      {
         setDirty(false);
         base.Normalize();
      }

      public void setNodeValue(string arg0)
      {
         setDirty(false);
         base.Value = arg0;
      }

      public void setPrefix(string arg0)
      {
         base.Prefix = arg0;
         setDirty(false);
      }

      public XmlNode appendChild(XmlNode arg0)
      {
         return InsertBefore(arg0, null);
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      public XmlNode removeChild(XmlNode arg0)
      {
         setDirty(false);
         if (arg0 is KElement)
         {
            ((KElement)arg0).clearTargets();
         }

         return base.RemoveChild(arg0);
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      public override XmlNode InsertBefore(XmlNode arg0, XmlNode arg1)
      {
         setDirty(false);
         return base.InsertBefore(arg0, arg1);
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      public XmlNode replaceChild(XmlNode arg0, XmlNode arg1)
      {
         setDirty(false);
         if (arg1 is KElement)
         {
            ((KElement)arg1).clearTargets();
         }
         return base.ReplaceChild(arg0, arg1);
      }

      ///   
      ///	 <summary> * get/create the associated XMLDocUserData
      ///	 *  </summary>
      ///	 * <returns> the XMLDocUserData of this </returns>
      ///	 
      public virtual XMLDocUserData getXMLDocUserData()
      {
         return (OwnerDocument == null) ? null : ((DocumentJDFImpl)OwnerDocument).getUserData();
      }

      ///   
      ///	 <summary> * clones the root and also correctly sets the owner document </summary>
      ///	 * <param name="d"> the document to clone the root into </param>
      ///	 * <returns> the cloned root element </returns>
      ///	 
      internal virtual KElement cloneRoot(XMLDoc d)
      {
         KElement e = (KElement)CloneNode(true);
         // Java to C# Conversion - QUESTION: Do we need to be able to assign value?
         //e.OwnerDocument = d.getMemberDocument();
         //e.ownerNode = (XmlNode)d.getParentNode();
         return e;
      }

      private void clearTargets()
      {
         XMLDocUserData ud = getXMLDocUserData();
         if (ud != null)
         {
            if (hasChildElements()) // who knows what is down there -- clear
            // cache
            {
               ud.clearTargets();
            }
            else
            // only need to remove this element
            {
               string id = getAttribute(AttributeName.ID, null, null);
               if (id != null)
               {
                  ud.removeTarget(id);
               }
            }
         }
      }

      ///   
      ///	 <summary> * remove an attribute that is described by the xpath path quietly returns if the attribute does not exist
      ///	 *  </summary>
      ///	 * <param name="path"> the XPath to the attribute that is to be removed </param>
      ///	 * <exception cref="JDFException"> if the XPath is corrupt </exception>
      ///	 
      public virtual void removeXPathAttribute(string path)
      {
         int pos = path.LastIndexOf(JDFConstants.AET);
         if (pos == -1)
         {
            throw new JDFException("RemoveXPathAttribute - bad attribute path: " + path);
         }
         KElement kEle = getXPathElement(path.Substring(0, pos));
         if (kEle != null)
         {
            kEle.removeAttribute(path.Substring(pos + 1), null);
         }
      }

      ///   
      ///	 <summary> * check whether this matches a simple xpath
      ///	 *  </summary>
      ///	 * <param name="path"> </param>
      ///	 * <returns> boolean </returns>
      ///	 * @deprecated use matchesPath(String path, boolean bFollowRefs) 
      ///	 
      [Obsolete("use matchesPath(String path, boolean bFollowRefs)")]
      public virtual bool matchesPath(string path)
      {
         return matchesPath(path, false);
      }

      ///   
      ///	 <summary> * check whether this element matches a simple xpath
      ///	 *  </summary>
      ///	 * <param name="path"> xpath to match may include syntax <code>e[i]</code> or <code>e[@a="b"]</code>
      ///	 *  </param>
      ///	 * <returns> boolean true, if this matches the given xpath </returns>
      ///	 
      public virtual bool matchesPath(string path, bool bFollowRefs)
      {
         // bFollowRefs only needed in the JDFElement version
         if (path == null)
         {
            return true;
         }
         if (bFollowRefs)
         {
            this.GetType(); // dummy to fool compiler
         }

         VString v = new VString(StringUtil.tokenize(path, "/", false));
         KElement e = this;
         for (int i = v.Count - 1; i >= 0; i--)
         {
            if (e == null)
            {
               return false;
            }
            string pathAt = v.stringAt(i);
            if (!e.matchesPathName(pathAt))
            {
               return false;
            }

            e = e.getParentNode_KElement();
         }

         if (path.StartsWith("/") && !path.StartsWith("//"))
         {
            return e == null; // must be root
         }

         return true; // any location
      }

      protected internal virtual bool matchesPathName(string pathAt)
      {
         if (pathAt == null || pathAt.Equals(JDFConstants.STAR))
            return true;
         if (LocalName.Equals(pathAt))
            return true;
         string nodeName = Name;
         if (nodeName.Equals(pathAt))
            return true;
         string startPath = pathAt.StartsWith(LocalName) ? LocalName : pathAt.StartsWith(nodeName) ? nodeName : null;
         if (startPath != null) // process for attributes
         {
            string token = StringUtil.token(pathAt, 1, "[");
            if (token == null || !token.EndsWith("]")) // want e[@a="b"] or
               // e[n];
               return false;
            token = StringUtil.leftStr(token, -1); // remove "]"
            int n = StringUtil.parseInt(token, 0);
            if (n != 0)
            {
               KElement p = getParentNode_KElement();
               if (p == null)
                  return n == 1;
               return p.getElement(LocalName, getNamespaceURI(), n - 1) == this;
            }
            if (token.StartsWith("@"))
            {
               token = token.Substring(1);
               string nam = StringUtil.token(token, 0, "=");
               string @value = StringUtil.token(token, 1, "=");
               if (@value == null)
                  return false;
               if (@value.Length < 2 || !@value.StartsWith("\"") || !@value.EndsWith("\""))
                  return false;
               //.Net Substring different than java substring.
               @value = @value.Substring(1, @value.Length - 2);
               return @value.Equals("*") && hasAttribute_KElement(nam, null, false) || @value.Equals(getAttribute_KElement(nam));
            }
         }
         return false;
      }

      public virtual void fillHashSet(string attName, string attNS, SupportClass.HashSetSupport preFill)
      {
         fillHashSet(attName, attNS, preFill, true);
      }

      ///   
      ///	 <summary> * fills a HashSet with all values of the attribute in all child elements
      ///	 *  </summary>
      ///	 * <param name="attName"> attribute name </param>
      ///	 * <param name="attNS"> attrib ute namespaceuri </param>
      ///	 * <param name="preFill"> the HashSet to fill </param>
      ///	 
      private void fillHashSet(string attName, string attNS, SupportClass.HashSetSupport preFill, bool bFirst)
      {

         string attVal = getAttribute(attName, attNS, null);
         if (attVal != null)
         {
            if (preFill.Contains(attVal))
            {
               return; // been here already: break
            }
            preFill.Add(attVal);
         }

         // get all subnodes, INCLUDING partition leaves
         VElement v = getChildElementVector_KElement(null, null, null, true, 0);
         int siz = v.Count;
         for (int i = 0; i < siz; i++) // do not recurse down again for the
         // leaves, we've already done that
         {
            v[i].fillHashSet(attName, attNS, preFill, false);
         }

         if (bFirst)
         {
            // also get all lower level parent partition refs
            v = getChildElementVector(null, null, null, true, 0, false);
            siz = v.Count;
            for (int i = 0; i < siz; i++)
            {
               v[i].fillHashSet(attName, attNS, preFill, true);
            }
         }
      }

      ///   
      ///	 <summary> * Get the vector of valid attribute values for an enumerated attribute
      ///	 *  </summary>
      ///	 * <param name="key"> the local name of the attribute </param>
      ///	 * <returns> vector of valid names, null if key is not an enumeration </returns>
      ///	 
      public virtual VString getNamesVector(string key)
      {
         ValuedEnum enu = getEnumforAttribute(key);
         if (enu != null)
         {
            return StringUtil.getNamesVector(enu.GetType());
         }
         return null;
      }
   }
}
