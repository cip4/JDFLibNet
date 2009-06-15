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

/*
 * ElementInfo.cs
 * 09022005 VF initial version 
 */

namespace org.cip4.jdflib.core
{
   using System.Collections;
   using System.Collections.Generic;


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;
   using EnumAttributeValidity = org.cip4.jdflib.core.AttributeInfo.EnumAttributeValidity;
   using EnumVersion = org.cip4.jdflib.core.JDFElement.EnumVersion;

   ///
   /// <summary> * @author MatternK
   /// * @See EnumElementValidity below for current list of validity value
   /// * 
   /// *      0 Unknown UNKNOWN); 1 None NONE); 2 Required REQUIRED); 3 Optional OPTIONAL); 4 Deprecated DEPRECATED); 5
   /// *      SingleRequired SINGLEREQUIRED); 6 SingleOptional SINGLEOPTIONAL); 7 SingleDeprecated SINGLEDEPRECATED); 8 Dummy
   /// *      DUMMY); </summary>
   /// 
   public class ElementInfo
   {

      internal Hashtable elementInfoTable = new Hashtable();
      private EnumVersion version = null;

      ///   
      ///	 <summary> * Constructor
      ///	 *  </summary>
      ///	 * <param name="ElementInfo"> elemInfo_super: corresponding element info of super; if null: start from scratch, otherwise
      ///	 *            initialize from other ElementInfo </param>
      ///	 * <param name="ElemInfoTable"> [] elemInfo_own: table with element-specific element info </param>
      ///	 
      public ElementInfo(ElementInfo elemInfo_super, ElemInfoTable[] elemInfo_own)
      {
         // use ElementInfo of super as a starting point
         if (elemInfo_super != null)
         {
            elementInfoTable = new Hashtable(elemInfo_super.elementInfoTable);
            version = elemInfo_super.version;
         }

         // fill table with the element info specific to this element type (if
         // any)
         updateAdd(elemInfo_own);

         // now all schema-based knowledge should be in the element info table
      }

      ///   
      ///	 <summary> * Updater
      ///	 *  </summary>
      ///	 * <param name="ElemInfoTable"> [] elemInfo_update: table with element-specific attribute info </param>
      ///	 
      public virtual ElementInfo updateAdd(ElemInfoTable elemInfo_update)
      {
         if (elemInfo_update != null)
         {
            if (!elementInfoTable.ContainsKey(elemInfo_update.getElementName()))
            {
               elementInfoTable.Add(elemInfo_update.getElementName(), new ElemInfo(elemInfo_update.getValidityStatus()));
            }
            else
            {
               // complain about duplicate element name
            }
         }
         return this;
      }

      ///   
      ///	 <summary> * Updater
      ///	 *  </summary>
      ///	 * <param name="ElemInfoTable"> [] elemInfo_update: table with element-specific attribute info </param>
      ///	 
      public virtual ElementInfo updateAdd(ElemInfoTable[] elemInfo_update)
      {
         if (elemInfo_update != null)
         {
            for (int i = 0; i < elemInfo_update.Length; i++)
            {
               if (elemInfo_update[i] != null)
               {
                  if (!elementInfoTable.ContainsKey(elemInfo_update[i].getElementName()))
                  {
                     elementInfoTable.Add(elemInfo_update[i].getElementName(), new ElemInfo(elemInfo_update[i].getValidityStatus()));
                  }
                  else
                  {
                     // complain about duplicate element name
                  }
               }
            }
         }
         return this;
      }

      ///   
      ///	 <summary> * Updater
      ///	 *  </summary>
      ///	 * <param name="AtrInfoTable"> [] attrInfo_update: table with element-specific attribute info </param>
      ///	 
      public virtual ElementInfo updateRemove(ElemInfoTable elemInfo_update)
      {
         if (elemInfo_update != null)
         {
            if (elementInfoTable.ContainsKey(elemInfo_update.getElementName()))
            {
               elementInfoTable.Remove(elemInfo_update.getElementName());
            }
         }
         return this;
      }

      ///   
      ///	 <summary> * Updater
      ///	 *  </summary>
      ///	 * <param name="AtrInfoTable"> [] attrInfo_update: table with element-specific attribute info to remove from attribInfoTable </param>
      ///	 
      public virtual ElementInfo updateRemove(ElemInfoTable[] elemInfo_update)
      {
         if (elemInfo_update != null)
         {
            for (int i = 0; i < elemInfo_update.Length; i++)
            {
               if (elementInfoTable.ContainsKey(elemInfo_update[i].getElementName()))
               {
                  elementInfoTable.Remove(elemInfo_update[i].getElementName());
               }
            }
         }
         return this;
      }

      public virtual ElementInfo updateReplace(ElemInfoTable elemInfo_update)
      {
         if (elemInfo_update != null)
         {
            // if the table already contains this element, remove it first
            if (elementInfoTable.ContainsKey(elemInfo_update.getElementName()))
            {
               elementInfoTable.Remove(elemInfo_update.getElementName());
            }

            elementInfoTable.Add(elemInfo_update.getElementName(), new ElemInfo(elemInfo_update.getValidityStatus()));
         }
         return this;
      }

      public virtual ElementInfo updateReplace(ElemInfoTable[] elemInfo_update)
      {
         if (elemInfo_update != null)
         {
            for (int i = 0; i < elemInfo_update.Length; i++)
            {
               // if the table already contains this element, remove it first
               if (elementInfoTable.ContainsKey(elemInfo_update[i].getElementName()))
               {
                  elementInfoTable.Remove(elemInfo_update[i].getElementName());
               }

               elementInfoTable.Add(elemInfo_update[i].getElementName(), new ElemInfo(elemInfo_update[i].getValidityStatus()));
            }
         }
         return this;
      }

      ///   
      ///	 <summary> * Returns a list of element names matching the requested validity for the specified JDF version.
      ///	 *  </summary>
      ///	 * <param name="EnumElementValidity"> elemValidity: requested validity </param>
      ///	 * <returns> VString: list of strings containing the names of the matching elements </returns>
      ///	 
      private VString conformingElements(EnumElementValidity elemValidity1, EnumElementValidity elemValidity2, EnumElementValidity elemValidity3, EnumElementValidity elemValidity4)
      {
         VString matchingElements = new VString();
         IEnumerator iter = elementInfoTable.Keys.GetEnumerator();

         long l2 = JDFVersions.getTheMask(version);
         long v2 = JDFVersions.getTheOffset(version);
         while (iter.MoveNext())
         {
            string theKey = (string)iter.Current;
            ElemInfo ei = (ElemInfo)elementInfoTable[theKey];
            long eiValStatus = ei.getElemValidityStatus() & l2;
            if (eiValStatus == ((long)elemValidity1.getValue() << (int)v2))
            {
               matchingElements.Add(theKey);
            }
            else if (eiValStatus == ((long)elemValidity2.getValue() << (int)v2))
            {
               matchingElements.Add(theKey);
            }
            else if (eiValStatus == ((long)elemValidity3.getValue() << (int)v2))
            {
               matchingElements.Add(theKey);
            }
            else if (eiValStatus == ((long)elemValidity4.getValue() << (int)v2))
            {
               matchingElements.Add(theKey);
            }
         }

         return matchingElements;
      }

      ///   
      ///	 <summary> * Returns true if there is at least one sub-element matching the requested validity for the specified JDF version.
      ///	 *  </summary>
      ///	 * <param name="EnumElementValidity"> elemValidity: requested validity </param>
      ///	 * <returns> boolean: true if at least one sub-element matches the requested validity </returns>
      ///	 
      public virtual bool hasConformingElements(EnumElementValidity elemValidity1, EnumElementValidity elemValidity2, EnumElementValidity elemValidity3, EnumElementValidity elemValidity4)
      {
         return !conformingElements(elemValidity1, elemValidity2, elemValidity3, elemValidity4).IsEmpty();
      }

      ///   
      ///	 <summary> * Returns the list of required sub-elements for the specified JDF version.
      ///	 *  </summary>
      ///	 * <returns> VString: list of strings containing the names of the required sub-elements </returns>
      ///	 
      public virtual VString requiredElements()
      {
         return conformingElements(EnumElementValidity.Required, EnumElementValidity.SingleRequired, EnumElementValidity.Dummy, EnumElementValidity.Dummy);
      }

      ///   
      ///	 <summary> * Returns the list of optional sub-elements for the specified JDF version. Note: This includes elements marked as
      ///	 * optional as well as elements marked as deprecated (since, for backward compatibility, these are also optional).
      ///	 *  </summary>
      ///	 * <returns> VString: list of strings containing the names of the optional attributes </returns>
      ///	 
      public virtual VString optionalElements()
      {
         return conformingElements(EnumElementValidity.Optional, EnumElementValidity.Deprecated, EnumElementValidity.SingleDeprecated, EnumElementValidity.SingleOptional);
      }

      ///   
      ///	 <summary> * Returns the list of deprecated elements for the specified JDF version.
      ///	 *  </summary>
      ///	 * <returns> VString: list of strings containing the names of the deprecated attributes </returns>
      ///	 
      public virtual VString deprecatedElements()
      {
         return conformingElements(EnumElementValidity.Deprecated, EnumElementValidity.SingleDeprecated, EnumElementValidity.Dummy, EnumElementValidity.Dummy);
      }

      ///   
      ///	 <summary> * Returns the list of unique elements for the specified JDF version.
      ///	 *  </summary>
      ///	 * <returns> VString: list of strings containing the names of the deprecated attributes </returns>
      ///	 
      public virtual VString uniqueElements()
      {
         return conformingElements(EnumElementValidity.SingleRequired, EnumElementValidity.SingleOptional, EnumElementValidity.SingleDeprecated, EnumElementValidity.Dummy);
      }

      ///   
      ///	 <summary> * Returns the list of prerelease attributes (those that are only valid in a later version) for the specified JDF
      ///	 * version.
      ///	 *  </summary>
      ///	 * <returns> VString: list of strings containing the names of the prerelease attributes </returns>
      ///	 
      public virtual VString prereleaseElements()
      {
         return conformingElements(EnumElementValidity.None, EnumElementValidity.Dummy, EnumElementValidity.Dummy, EnumElementValidity.Dummy);
      }

      //   
      //	 * ----------------------------------------------------------------------- Enumeration of element validity values
      //	 * -----------------------------------------------------------------------
      //	 

      ///   
      ///	 <summary> * Enumeration of element validity values </summary>
      ///	 
      public sealed class EnumElementValidity : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         ///      
         ///		 * <param name="name"> </param>
         ///		 
         private EnumElementValidity(string name)
            : base(name, m_startValue++)
         {
         }

         ///      
         ///		 * <param name="enumName"> the name of the enum object to return </param>
         ///		 * <returns> the enum object if enumName is valid. Otherwise null </returns>
         ///		 
         public static EnumElementValidity getEnum(string enumName)
         {
            return (EnumElementValidity)getEnum(typeof(EnumElementValidity), enumName);
         }

         ///      
         ///		 * <param name="enumValue"> the value of the enum object to return </param>
         ///		 * <returns> the enum object if enumName is valid. Otherwise null </returns>
         ///		 
         public static EnumAttributeValidity getEnum(int enumValue)
         {
            return (EnumAttributeValidity)getEnum(typeof(EnumAttributeValidity), enumValue);
         }

         ///      
         ///		 * <returns> a map of all orientation enums </returns>
         ///		 
         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumElementValidity));
         }

         ///      
         ///		 * <returns> a list of all orientation enums </returns>
         ///		 
         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumElementValidity));
         }

         ///      
         ///		 * <returns> an iterator over the enum objects </returns>
         ///		 
         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumElementValidity));
         }

         public static readonly EnumElementValidity Unknown = new EnumElementValidity(JDFConstants.ELEMENTVALIDITY_UNKNOWN);
         public static readonly EnumElementValidity None = new EnumElementValidity(JDFConstants.ELEMENTVALIDITY_NONE);
         public static readonly EnumElementValidity Required = new EnumElementValidity(JDFConstants.ELEMENTVALIDITY_REQUIRED);
         public static readonly EnumElementValidity Optional = new EnumElementValidity(JDFConstants.ELEMENTVALIDITY_OPTIONAL);
         public static readonly EnumElementValidity Deprecated = new EnumElementValidity(JDFConstants.ELEMENTVALIDITY_DEPRECATED);
         public static readonly EnumElementValidity SingleRequired = new EnumElementValidity(JDFConstants.ELEMENTVALIDITY_SINGLEREQUIRED);
         public static readonly EnumElementValidity SingleOptional = new EnumElementValidity(JDFConstants.ELEMENTVALIDITY_SINGLEOPTIONAL);
         public static readonly EnumElementValidity SingleDeprecated = new EnumElementValidity(JDFConstants.ELEMENTVALIDITY_SINGLEDEPRECATED);
         public static readonly EnumElementValidity Dummy = new EnumElementValidity(JDFConstants.ELEMENTVALIDITY_DUMMY);
      }

      public virtual void setVersion(EnumVersion v)
      {
         version = v;
      }

      public override string ToString()
      {
         string s = "ElementInfoTable version=" + version;
         s += elementInfoTable.ToString();
         return s;
      }

      ///   
      ///	 <summary> * get the first jdf version where an attrinute of this type is valid
      ///	 *  </summary>
      ///	 * <param name="elementName"> the name of the queried attribute
      ///	 * @return </param>
      ///	 
      public virtual EnumVersion getFirstVersion(string elementName)
      {
         if (elementInfoTable.ContainsKey(elementName))
         {
            return ((ElemInfo)elementInfoTable[elementName]).getFirstVersion();
         }
         return null;
      }

      ///   
      ///	 <summary> * get the last jdf version where an attrinute of this type is valid
      ///	 *  </summary>
      ///	 * <param name="elementName"> the name of the queried attribute
      ///	 * @return </param>
      ///	 
      public virtual EnumVersion getLastVersion(string elementName)
      {
         if (elementInfoTable.ContainsKey(elementName))
         {
            return ((ElemInfo)elementInfoTable[elementName]).getLastVersion();
         }
         return null;
      }
   }
}
