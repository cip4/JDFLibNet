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
 * THIS SOFTWARE IS PROVIDED `AS IS'' AND ANY EXPRESSED OR IMPLIED
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





/* Copyright (c) 2001 Heidelberger Druckmaschinen AG, All Rights Reserved.
 * 
 * @author Elena Skobchenko
 *
 * JDFAbstractState.cs
 */


namespace org.cip4.jdflib.resource.devicecapability
{
   using System;
   using System.Collections;
   using System.Text;


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   using EnumListType = org.cip4.jdflib.auto.JDFAutoBasicPreflightTest.EnumListType;
   using EnumContext = org.cip4.jdflib.auto.JDFAutoDevCaps.EnumContext;
   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using KElement = org.cip4.jdflib.core.KElement;
   using VString = org.cip4.jdflib.core.VString;
   using JDFBaseDataTypes = org.cip4.jdflib.datatypes.JDFBaseDataTypes;
   using JDFIntegerRange = org.cip4.jdflib.datatypes.JDFIntegerRange;
   using JDFMatrix = org.cip4.jdflib.datatypes.JDFMatrix;
   using JDFNameRangeList = org.cip4.jdflib.datatypes.JDFNameRangeList;
   using JDFRangeList = org.cip4.jdflib.datatypes.JDFRangeList;
   using ICapabilityElement = org.cip4.jdflib.ifaces.ICapabilityElement;
   using JDFMessageService = org.cip4.jdflib.jmf.JDFMessageService;
   using EnumAvailability = org.cip4.jdflib.resource.devicecapability.JDFDeviceCap.EnumAvailability;
   using EnumTerm = org.cip4.jdflib.resource.devicecapability.JDFTerm.EnumTerm;
   using JDFIntentResource = org.cip4.jdflib.resource.intent.JDFIntentResource;
   using JDFSpanBase = org.cip4.jdflib.span.JDFSpanBase;
   using JDFDate = org.cip4.jdflib.util.JDFDate;
   using JDFDuration = org.cip4.jdflib.util.JDFDuration;
   using StringUtil = org.cip4.jdflib.util.StringUtil;
   using EnumFitsValue = org.cip4.jdflib.datatypes.EnumFitsValue;

   public abstract class JDFAbstractState : JDFElement, JDFBaseDataTypes, ICapabilityElement
   {
      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[16];
      static JDFAbstractState()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.AVAILABILITY, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumAvailability.getEnum(0), null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.ACTIONREFS, 0x33333311, AttributeInfo.EnumAttributeType.IDREFS, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.DEPENDENTMACROREF, 0x33333311, AttributeInfo.EnumAttributeType.IDREF, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.DEVNS, 0x33333331, AttributeInfo.EnumAttributeType.URI, null, JDFConstants.JDFNAMESPACE);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.EDITABLE, 0x33333311, AttributeInfo.EnumAttributeType.boolean_, null, JDFConstants.TRUE);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.HASDEFAULT, 0x33333331, AttributeInfo.EnumAttributeType.boolean_, null, JDFConstants.TRUE);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.ID, 0x33333311, AttributeInfo.EnumAttributeType.ID, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.LISTTYPE, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumListType.getEnum(0), EnumListType.SingleValue.getName());
         atrInfoTable[8] = new AtrInfoTable(AttributeName.MACROREFS, 0x33333311, AttributeInfo.EnumAttributeType.IDREFS, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.MAXOCCURS, 0x33333311, AttributeInfo.EnumAttributeType.unbounded, null, "1");
         atrInfoTable[10] = new AtrInfoTable(AttributeName.MINOCCURS, 0x33333311, AttributeInfo.EnumAttributeType.integer, null, "1");
         atrInfoTable[11] = new AtrInfoTable(AttributeName.MODULEREFS, 0x33333111, AttributeInfo.EnumAttributeType.IDREFS, null, null);
         atrInfoTable[12] = new AtrInfoTable(AttributeName.NAME, 0x33333331, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[13] = new AtrInfoTable(AttributeName.REQUIRED, 0x33333311, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[14] = new AtrInfoTable(AttributeName.SPAN, 0x44444431, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[15] = new AtrInfoTable(AttributeName.USERDISPLAY, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumUserDisplay.getEnum(0), EnumUserDisplay.Display.getName());
         elemInfoTable[0] = new ElemInfoTable(ElementName.LOC, 0x33333311);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }

      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[1];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }

      ///   
      ///	 <summary> * constructor for JDFAbstractState
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFAbstractState(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * constructor for JDFAbstractState
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFAbstractState(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * constructor for JDFAbstractState
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFAbstractState(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      // **************************************** Methods
      // *********************************************

      ///   
      ///	 <summary> * toString
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public override string ToString()
      {
         return "JDFAbstractState[ --> " + base.ToString() + " ]";
      }

      public class EnumUserDisplay : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumUserDisplay(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumUserDisplay getEnum(string enumName)
         {
            return (EnumUserDisplay)getEnum(typeof(EnumUserDisplay), enumName);
         }

         public static EnumUserDisplay getEnum(int enumValue)
         {
            return (EnumUserDisplay)getEnum(typeof(EnumUserDisplay), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumUserDisplay));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumUserDisplay));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumUserDisplay));
         }

         public static readonly EnumUserDisplay Display = new EnumUserDisplay("Display");
         public static readonly EnumUserDisplay Hide = new EnumUserDisplay("Hide");
         public static readonly EnumUserDisplay Dependent = new EnumUserDisplay("Dependent");

      }

      ///   
      ///	 <summary> * 
      ///	 * add a value to the list of values defined by testlists
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <param name="valuelist">
      ///	 *            switches between Allowed test lists and Present test lists.
      ///	 *            Has two values: Allowed and Present. </param>
      ///	 
      public abstract void addValue(string @value, EnumFitsValue testlists);

      ///   
      ///	 <summary> * Tests wheterh the defined value matches the Allowed test lists or the
      ///	 * Present test lists specified for this state
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <param name="valuelist">
      ///	 *            switches between Allowed test lists and Present test lists.
      ///	 *            Has two values: Allowed and Present. </param>
      ///	 * <returns> boolean - true, if the value matches the test lists or if Allowed
      ///	 *         testlists are not specified </returns>
      ///	 
      public abstract bool fitsValue(string @value, EnumFitsValue testlists);

      ///   
      ///	 <summary> * Gets the NamePath of this State in form "
      ///	 * <code>DevCapsName[Context=aaa, LinkUsage=ccc]/DevCapName1/DevCapName2../@StateName</code>
      ///	 * "
      ///	 * <p>
      ///	 * default getNamePath(false)
      ///	 *  </summary>
      ///	 * <returns> String - NamePath of this State </returns>
      ///	 
      public string getNamePath()
      {
         string namePath = getParentPath();

         JDFDevCaps dcs = getParentDevCaps();
         if (dcs != null)
         {
            EnumContext context = dcs.getContext();
            if (EnumContext.Link.Equals(context))
               namePath += "Link";
         }
         if (getListType().Equals(EnumListType.Span))
            return (namePath + "/" + getName()); // Span is an element
         return (namePath + "/@" + getName());
      }

      private string getParentPath()
      {
         string namePath = null;
         KElement parent = getParentNode_KElement();
         if (parent is JDFDevCap)
         {
            JDFDevCap devCap = getParentDevCap();
            namePath = devCap.getNamePath(true);
         }
         else if (parent is JDFDeviceCap)
         {
            namePath = "JDF";
         }
         else if (parent is JDFMessageService)
         {
            namePath = "JMF";
         }
         return namePath;
      }

      public VString getNamePathVector()
      {
         return getNamePathVector(true);
      }

      ///   
      ///	 <summary> * Gets the NamePath of this State in form "
      ///	 * <code>DevCapsName[Context=aaa, LinkUsage=ccc]/DevCapName1/DevCapName2../@StateName</code>
      ///	 * "
      ///	 * <p>
      ///	 * default getNamePath(false)
      ///	 *  </summary>
      ///	 * <param name="bRecurse">
      ///	 *            if true returns "
      ///	 *            <code>DevCapsName/SubelemName1/SubelemName2/../@StateName</code>
      ///	 *            "
      ///	 *  </param>
      ///	 * <returns> String - NamePath of this State </returns>
      ///	 
      public VString getNamePathVector(bool bRecurse)
      {
         VString vNamePath = getParentPathVector(bRecurse);
         JDFDevCaps dcs = getParentDevCaps();
         if (dcs != null)
         {
            EnumContext context = dcs.getContext();
            if (EnumContext.Link.Equals(context))
            {
               StringUtil.concatStrings(vNamePath, "Link");
            }
         }
         if (getListType().Equals(EnumListType.Span))
         {
            StringUtil.concatStrings(vNamePath, "/" + getName()); // Span is an
            // element
         }
         else
         {
            StringUtil.concatStrings(vNamePath, "/@" + getName());
         }
         return vNamePath;
      }

      ///   
      ///	 * <param name="recurse">
      ///	 * @return </param>
      ///	 
      private VString getParentPathVector(bool recurse)
      {
         KElement parent = getParentNode_KElement();
         if (parent is JDFDevCap)
            return ((JDFDevCap)parent).getNamePathVector(recurse);
         return new VString(getParentPath(), null);
      }

      ///   
      ///	 <summary> * get the ancestor devCaps, null if this resides in a DevCapPool
      ///	 *  </summary>
      ///	 * <returns> JDFDevCaps </returns>
      ///	 
      public virtual JDFDevCaps getParentDevCaps()
      {
         return (JDFDevCaps)getDeepParent(ElementName.DEVCAPS, 0);
      }

      //   
      //	 * // Attribute Getter / Setter
      //	 
      ///   
      ///	 <summary> * Sets attribute Availability
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            the value to set the attribute to </param>
      ///	 
      public virtual void setAvailability(EnumAvailability @value)
      {
         setAttribute(AttributeName.AVAILABILITY, @value.getName(), null);
      }

      ///   
      ///	 <summary> * Gets typesafe enumerated attribute Availability
      ///	 *  </summary>
      ///	 * <returns> EnumAvailability: the enumeration value of the attribute </returns>
      ///	 
      public virtual EnumAvailability getAvailability()
      {
         EnumAvailability avail = EnumAvailability.getEnum(getAttribute(AttributeName.AVAILABILITY, null, null));

         if (avail == null)
         {
            JDFDevCap par = getParentDevCap();
            if (par != null)
               avail = par.getAvailability();
         }
         return avail == null ? EnumAvailability.Installed : avail;
      }

      ///   
      ///	 <summary> * get the parent devCap of this
      ///	 * 
      ///	 * @return </summary>
      ///	 
      public virtual JDFDevCap getParentDevCap()
      {
         return (JDFDevCap)ParentNode;
      }

      ///   
      ///	 <summary> * Sets attribute DevNS
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            the value to set the attribute to </param>
      ///	 
      public virtual void setDevNS(string @value)
      {
         setAttribute(AttributeName.DEVNS, @value);
      }

      ///   
      ///	 <summary> * Gets URI attribute DevNS
      ///	 *  </summary>
      ///	 * <returns> String: the attribute value </returns>
      ///	 
      public virtual string getDevNS()
      {
         return getAttribute(AttributeName.DEVNS, null, JDFElement.getSchemaURL());
      }

      ///   
      ///	 <summary> * Sets attribute HasDefault, default=true
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            the value to set the attribute to </param>
      ///	 
      public virtual void setHasDefault(bool @value)
      {
         setAttribute(AttributeName.HASDEFAULT, @value, null);
      }

      ///   
      ///	 <summary> * Gets boolean attribute HasDefault
      ///	 *  </summary>
      ///	 * <returns> boolean: the attribute value </returns>
      ///	 
      public virtual bool getHasDefault()
      {
         return getBoolAttribute(AttributeName.HASDEFAULT, null, true);
      }

      ///   
      ///	 <summary> * get the id </summary>
      ///	 
      public override string getID()
      {
         return getAttribute(AttributeName.ID);
      }

      ///   
      ///	 <summary> * Sets attribute MaxOccurs,
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            the value to set the attribute to </param>
      ///	 
      public virtual void setMaxOccurs(int @value)
      {
         setAttribute(AttributeName.MAXOCCURS, @value, null);
      }

      ///   
      ///	 <summary> * Gets integer attribute MaxOccurs
      ///	 *  </summary>
      ///	 * <returns> int: the attribute value </returns>
      ///	 
      public virtual int getMaxOccurs()
      {
         string s = getAttribute(AttributeName.MAXOCCURS, null, null);
         if (JDFConstants.UNBOUNDED.Equals(s)) // legacy support
            return int.MaxValue;
         return StringUtil.parseInt(s, 1);
      }

      ///   
      ///	 <summary> * Sets attribute MinOccurs, default=1
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            the value to set the attribute to </param>
      ///	 
      public virtual void setMinOccurs(int @value)
      {
         setAttribute(AttributeName.MINOCCURS, @value, null);
      }

      ///   
      ///	 <summary> * Get integer attribute MinOccurs
      ///	 *  </summary>
      ///	 * <returns> int: the attribute value </returns>
      ///	 
      public virtual int getMinOccurs()
      {
         return getIntAttribute(AttributeName.MINOCCURS, JDFConstants.EMPTYSTRING, 1);
      }

      ///   
      ///	 <summary> * Sets String attribute Name<br>
      ///	 * Since name is independent of the data type of the State element, the
      ///	 * setter is defined here
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            the value to set the attribute to </param>
      ///	 
      public virtual void setName(string @value)
      {
         setAttribute(AttributeName.NAME, @value);
      }

      ///   
      ///	 <summary> * Gets String attribute Name<br>
      ///	 * Since name is independent of the data type of the State element,the
      ///	 * getter is defined here
      ///	 *  </summary>
      ///	 * <returns> String: the attribute value </returns>
      ///	 
      public virtual string getName()
      {
         return getAttribute(AttributeName.NAME, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * Sets attribute Required
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            the value to set the attribute to </param>
      ///	 
      public virtual void setRequired(bool @value)
      {
         setAttribute(AttributeName.REQUIRED, @value, null);
      }

      ///   
      ///	 <summary> * Gets boolean attribute Required
      ///	 *  </summary>
      ///	 * <returns> boolean: the attribute value </returns>
      ///	 
      public virtual bool getRequired()
      {
         return getBoolAttribute(AttributeName.REQUIRED, JDFConstants.EMPTYSTRING, false);
      }

      ///   
      ///	 <summary> * Sets attribute ListType, default=SingleValue
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            the value to set the attribute to </param>
      ///	 
      public virtual void setListType(EnumListType @value)
      {
         setAttribute(AttributeName.LISTTYPE, @value.getName(), null);
      }

      ///   
      ///	 <summary> * Gets typesafe enumerated attribute ListType
      ///	 *  </summary>
      ///	 * <returns> EnumListType: the enumeration value of the attribute </returns>
      ///	 
      public virtual EnumListType getListType()
      {
         return EnumListType.getEnum(getAttribute(AttributeName.LISTTYPE, null, EnumListType.SingleValue.getName()));
      }

      ///   
      ///	 <summary> * Sets attribute ActionRefs
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            vector of ActionRefs </param>
      ///	 
      public virtual void setActionRefs(VString @value)
      {
         StringBuilder strActionRefs = new StringBuilder(100);
         for (int i = 0; i < @value.Count; i++)
         {
            strActionRefs.Append(@value[i]);
         }
         setAttribute(AttributeName.ACTIONREFS, strActionRefs.ToString());
      }

      ///   
      ///	 <summary> * Gets NMTOKENS attribute ActionRefs
      ///	 *  </summary>
      ///	 * <returns> VString: the attribute value </returns>
      ///	 
      public virtual VString getActionRefs()
      {
         string strActionRefs = getAttribute(AttributeName.ACTIONREFS, null, JDFConstants.EMPTYSTRING);
         return new VString(StringUtil.tokenize(strActionRefs, JDFConstants.COMMA, false));
      }

      ///   
      ///	 <summary> * Sets attribute Editable
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            the value to set the attribute to </param>
      ///	 
      public virtual void setEditable(bool @value)
      {
         setAttribute(AttributeName.EDITABLE, @value, null);
      }

      ///   
      ///	 <summary> * Gets boolean attribute Editable
      ///	 *  </summary>
      ///	 * <returns> boolean: the attribute value </returns>
      ///	 
      public virtual bool getEditable()
      {
         return getBoolAttribute(AttributeName.EDITABLE, JDFConstants.EMPTYSTRING, true);
      }

      ///   
      ///	 <summary> * Sets attribute MacroRefs
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            vector of MacroRefs </param>
      ///	 
      public virtual void setMacroRefs(VString @value)
      {
         StringBuilder strMacroRefs = new StringBuilder(100);
         for (int i = 0; i < @value.Count; i++)
         {
            strMacroRefs.Append(@value[i]);
         }
         setAttribute(AttributeName.MACROREFS, strMacroRefs.ToString());
      }

      ///   
      ///	 <summary> * Get NMTOKENS attribute MacroRefs
      ///	 *  </summary>
      ///	 * <returns> VString: the attribute value </returns>
      ///	 
      public virtual VString getMacroRefs()
      {
         string strMacroRef = getAttribute(AttributeName.MACROREFS, null, JDFConstants.EMPTYSTRING);
         return new VString(StringUtil.tokenize(strMacroRef, JDFConstants.COMMA, false));
      }

      ///   
      ///	 <summary> * Sets attribute DependentMacroRef
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            vector of DependentMacroRef </param>
      ///	 
      public virtual void setDependentMacroRef(string @value)
      {
         setAttribute(AttributeName.DEPENDENTMACROREF, @value);
      }

      ///   
      ///	 <summary> * Get string attribute DependentMacroRef
      ///	 *  </summary>
      ///	 * <returns> String: the attribute value </returns>
      ///	 
      public virtual string getDependentMacroRef()
      {
         return getAttribute(AttributeName.DEPENDENTMACROREF, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * Sets attribute UserDisplay, default=Display
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            the value to set the attribute to </param>
      ///	 
      public virtual void setUserDisplay(EnumUserDisplay @value)
      {
         setAttribute(AttributeName.USERDISPLAY, @value.getName(), null);
      }

      ///   
      ///	 <summary> * Gets typesafe enumerated attribute UserDisplay
      ///	 *  </summary>
      ///	 * <returns> EnumUserDisplay: the enumeration value of the attribute </returns>
      ///	 
      public virtual EnumUserDisplay getUserDisplay()
      {
         return EnumUserDisplay.getEnum(getAttribute(AttributeName.USERDISPLAY, null, EnumUserDisplay.Display.getName()));
      }

      //   
      //	 * // Element Getter / Setter
      //	 
      // @{
      ///   
      ///	 <summary> * Gets the iSkip-th element Loc. If doesn't exist, it is created.
      ///	 * <p>
      ///	 * default: getCreateLoc(0)
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            number of elements to skip </param>
      ///	 * <returns> JDFLoc: the matching element </returns>
      ///	 
      public virtual JDFLoc getCreateLoc(int iSkip)
      {
         return (JDFLoc)getCreateElement(ElementName.LOC, JDFConstants.EMPTYSTRING, iSkip);
      }

      ///   
      ///	 <summary> * Gets the iSkip-th element Loc
      ///	 * <p>
      ///	 * default: getCreateLoc(0)
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            number of elements to skip </param>
      ///	 * <returns> JDFLoc: the matching element </returns>
      ///	 
      public virtual JDFLoc getLoc(int iSkip)
      {
         JDFLoc e = (JDFLoc)getElement(ElementName.LOC, JDFConstants.EMPTYSTRING, iSkip);
         return e;
      }

      ///   
      ///	 <summary> * Appends element Loc to the end of <code>this</code>
      ///	 *  </summary>
      ///	 * <returns> JDFLoc: newly created Loc element </returns>
      ///	 
      public virtual JDFLoc appendLoc()
      {
         return (JDFLoc)appendElement(ElementName.LOC, null);
      }

      ///   
      ///	 <summary> * set attribute ID
      ///	 *  </summary>
      ///	 * <param name="sid">
      ///	 *            the value to set the attribute to </param>
      ///	 
      public virtual void setID(string sid)
      {
         setAttribute(AttributeName.ID, sid, null);
      }

      ///   
      ///	 <summary> * set attribute AllowedLength
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            the value to set the attribute to </param>
      ///	 
      public virtual void setAllowedLength(JDFIntegerRange @value)
      {
         setAttribute(AttributeName.ALLOWEDLENGTH, @value.ToString());
      }

      ///   
      ///	 <summary> * get attribute AllowedLength
      ///	 *  </summary>
      ///	 * <returns> JDFIntegerRange: the attribute value </returns>
      ///	 
      public virtual JDFIntegerRange getAllowedLength()
      {
         try
         {
            string len = getAttribute(AttributeName.ALLOWEDLENGTH, null, null);
            if (len == null)
               return null;
            JDFIntegerRange ir = new JDFIntegerRange(len);
            return ir;
         }
         catch (FormatException)
         {
            throw new JDFException("JDFAbstractState.getAllowedLength: Attribute ALLOWEDLENGTH is not capable to create JDFIntegerRange");
         }

      }

      public virtual void setPresentLength(JDFIntegerRange @value)
      {
         setAttribute(AttributeName.PRESENTLENGTH, @value.ToString());
      }

      public virtual JDFIntegerRange getPresentLength()
      {
         if (hasAttribute(AttributeName.PRESENTLENGTH))
         {
            try
            {
               JDFIntegerRange ir = new JDFIntegerRange(getAttribute(AttributeName.PRESENTLENGTH));
               return ir;
            }
            catch (FormatException)
            {
               throw new JDFException("JDFAbstractState.getPresentLength: Attribute PRESENTLENGTH is not capable to create JDFIntegerRange");
            }
         }
         return getAllowedLength();
      }

      ///   
      ///	 <summary> * Mother of all version fixing routines <br>
      ///	 * Uses heuristics to modify this element and its children to be compatible
      ///	 * with a given version. In general, it will be able to move from low to
      ///	 * high versions, but potentially fail when attempting to move from higher
      ///	 * to lower versions.
      ///	 *  </summary>
      ///	 * <param name="version">
      ///	 *            version that the resulting element should correspond to </param>
      ///	 * <returns> true if successful </returns>
      ///	 
      public override bool fixVersion(EnumVersion version)
      {
         if (JDFConstants.UNBOUNDED.Equals(getAttribute(AttributeName.MAXOCCURS, null, null)))
            setAttribute(AttributeName.MAXOCCURS, JDFConstants.POSINF);
         return base.fixVersion(version);
      }

      ///   
      ///	 <summary> * fitsLength - tests, if the defined String <code>str</code> matches
      ///	 * AllowedLength or the PresentLength, specified for this State
      ///	 *  </summary>
      ///	 * <param name="str">
      ///	 *            string to test </param>
      ///	 * <param name="length">
      ///	 *            switches between AllowedLength and PresentLength. </param>
      ///	 * <returns> boolean - true, if 'str' matches Length or if AllowedLength is
      ///	 *         not specified </returns>
      ///	 
      protected internal bool fitsLength(string str, EnumFitsValue length)
      {

         JDFIntegerRange lengthlist;
         if (length.Equals(EnumFitsValue.Allowed))
         {
            lengthlist = getAllowedLength();
         }
         else
         {
            lengthlist = getPresentLength();
         }

         if (lengthlist != null)
         {
            int len = str.Length;
            return lengthlist.inRange(len);
         }
         return true;
      }

      ///   
      ///	 <summary> * gets the matching Attribute value String or AbstractSpan object from the
      ///	 * parent, depending on the type of the state
      ///	 *  </summary>
      ///	 * <param name="element">
      ///	 *            the parent in which to search </param>
      ///	 * <returns> Object: either a String or AbstractSpan </returns>
      ///	 
      public virtual object getMatchingObjectInNode(KElement element)
      {
         string nam = getName();
         if (getListType().Equals(EnumListType.Span))
         {
            return element.getElement(nam, getDevNS(), 0);
         }

         return element.getAttribute(nam, getDevNS(), null);
      }

      ///   
      ///	 <summary> * set the default values specified in this in element
      ///	 *  </summary>
      ///	 * <param name="element">
      ///	 *            the element to set the defaults on </param>
      ///	 * <returns> true if successful </returns>
      ///	 
      public virtual bool setDefaultsFromCaps(KElement element, bool bAll)
      {
         string def = getAttribute(AttributeName.DEFAULTVALUE, null, null);
         if (!bAll && def == null)
            return false;
         if (def == null)
         {
            def = getAttribute(AttributeName.CURRENTVALUE, null, null);
         }

         if (def == null)
         {
            def = getAttribute(AttributeName.ALLOWEDVALUELIST, null, null);
            if (def != null && (def.IndexOf("~") >= 0 || def.IndexOf(" ") >= 0)) // allowedvaluelist
            // is
            // a
            // list
            // or
            // range
            {
               string lt = getListType().getName();
               if (!lt.EndsWith("List") && def.IndexOf(" ") >= 0)
               {
                  def = StringUtil.token(def, 0, " ");
               }
               else if (lt.IndexOf("Range") < 0 && def.IndexOf("~") >= 0)
               {
                  def = null;
               }
            }
            if (def == null)
               def = getXPathAttribute("Value/@AllowedValue", null);
         }
         if (def == null)
         {
            if ((this is JDFIntegerState) || (this is JDFNumberState))
            {
               def = "1";
            }
            else if (this is JDFXYPairState)
            {
               def = "1 1";
            }
            else if (this is JDFBooleanState)
            {
               def = "true";
            }
            else if (this is JDFMatrixState)
            {
               def = JDFMatrix.unitMatrix.ToString();
            }
            else if (this is JDFShapeState)
            {
               def = "1 2 3";
            }
            else if (this is JDFDateTimeState)
            {
               def = new JDFDate().DateTimeISO;
            }
            else if (this is JDFDurationState)
            {
               def = new JDFDuration(42).getDurationISO();
            }
            else
            {
               def = "some_value"; // TODO add better type dependent value
               // generator
            }
         }
         object theValue = getMatchingObjectInNode(element);
         if (theValue != null)
            return false;

         string nam = getName();
         string nsURI = getDevNS();
         if (nsURI.Equals(JDFElement.getSchemaURL()))
            nsURI = null;
         if (nsURI != null)
         {
            string prefix = KElement.xmlnsPrefix(nam);
            if (prefix == null)
            {
               nam = StringUtil.token(nsURI, -1, "/") + ":" + nam;
            }
         }

         if (getListType().Equals(EnumListType.Span))
         {
            JDFIntentResource ir = (JDFIntentResource)element;
            JDFSpanBase span = ir.appendSpan(nam, null);
            span.setAttribute(AttributeName.PREFERRED, def);
         }
         else
         // some attribute...
         {

            element.setAttribute(nam, def, nsURI);
         }
         return true;
      }

      ///   
      ///	 <summary> * fitsListType - tests, if the defined <code>value</code> matches value of
      ///	 * ListType attribute, specified for this State
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test
      ///	 *  </param>
      ///	 * <returns> boolean - true, if 'value' matches specified ListType </returns>
      ///	 
      protected internal bool fitsListType(string @value)
      {
         if (@value == null)
            return true;

         EnumListType listType = getListType();

         JDFRangeList rangelist; // lists of strings are most generic
         try
         {
            rangelist = new JDFNameRangeList(@value);
         }
         catch (FormatException)
         {
            return false;
         }
         catch (JDFException)
         {
            return false;
         }

         if (listType == null || listType.Equals(EnumListType.SingleValue))
         { // default ListType = SingleValue
            return @value.IndexOf(" ") == -1;
         }
         else if (listType.Equals(EnumListType.RangeList) || listType.Equals(EnumListType.Span))
         {
            return true;
         }
         else if (listType.Equals(EnumListType.Range))
         {
            return rangelist.Count == 1;
         }
         // not -
         // tested in
         // fitsValueList
         // in
         // fitsValueList
         else if (listType.Equals(EnumListType.List) || listType.Equals(EnumListType.CompleteList) || listType.Equals(EnumListType.CompleteOrderedList) || listType.Equals(EnumListType.ContainedList)) // tested in
         // fitsValueList
         {
            return rangelist.isList();
         }
         else if (listType.Equals(EnumListType.OrderedList))
         {
            return (rangelist.isList() && rangelist.isOrdered());
         }
         else if (listType.Equals(EnumListType.UniqueList))
         {
            return (rangelist.isList() && rangelist.isUnique());
         }
         else if (listType.Equals(EnumListType.UniqueOrderedList))
         {
            return (rangelist.isList() && rangelist.isUniqueOrdered());
         }
         else if (listType.Equals(EnumListType.OrderedRangeList))
         {
            return rangelist.isOrdered();
         }
         else if (listType.Equals(EnumListType.UniqueRangeList))
         {
            return rangelist.isUnique();
         }
         else if (listType.Equals(EnumListType.UniqueOrderedRangeList))
         {
            return (rangelist.isUniqueOrdered());
         }
         else
         {
            throw new JDFException("JDFDateTimeState.fitsListType illegal ListType attribute");
         }
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see
      //	 * org.cip4.jdflib.core.JDFElement#getInvalidAttributes(org.cip4.jdflib.
      //	 * core.KElement.EnumValidationLevel, boolean, int)
      //	 
      protected internal virtual VString getInvalidAttributesImpl(EnumValidationLevel level, bool bIgnorePrivate, int nMax)
      {
         VString v = base.getInvalidAttributes(level, bIgnorePrivate, nMax);
         if (nMax > 0 && v.Count >= nMax)
            return v;
         if (!fitsListType(getAttribute(AttributeName.DEFAULTVALUE)))
            v.appendUnique(AttributeName.DEFAULTVALUE);
         if (!fitsListType(getAttribute(AttributeName.CURRENTVALUE)))
            v.appendUnique(AttributeName.CURRENTVALUE);
         return v;
      }

      ///   
      ///	 <summary> * Gets the j-th element Loc of the i-th element Value
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            number of Value elements to skip (iSkip=0 - first Value
      ///	 *            element) </param>
      ///	 * <param name="jSkip">
      ///	 *            number of Loc subelements of i-th Value element to skip,
      ///	 *            (jSkip=0 - first Loc element) </param>
      ///	 * <returns> JDFLoc: the matching Loc element </returns>
      ///	 
      public virtual JDFLoc getValueLocLoc(int iSkip, int jSkip)
      {
         JDFValueLoc val = getValueLoc(iSkip);
         if (val == null)
            return null;
         return val.getLoc(jSkip);
      }

      ///   
      ///	 <summary> * get iSkip'th element Loc
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            number of Value elements to skip (iSkip=0 - get first element) </param>
      ///	 * <returns> JDFValueLoc: the element </returns>
      ///	 
      public JDFValueLoc getValueLoc(int iSkip)
      {
         return (JDFValueLoc)getElement(ElementName.VALUELOC, null, iSkip);
      }

      ///   
      ///	 <summary> * appends element Loc to the end of the i-th subelement Value
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            number of Value elements to skip (iSkip=0 - first Value
      ///	 *            element) </param>
      ///	 * <returns> JDFLoc: newly created Loc element </returns>
      ///	 
      public virtual JDFLoc appendValueLocLoc(int iSkip)
      {
         JDFValueLoc val = getValueLoc(iSkip);
         if (val == null)
            return null;
         return val.appendLoc();
      }

      ///   
      ///	 <summary> * Appends element ValueLoc
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            number of Value elements to skip </param>
      ///	 * <returns> JDFLoc: newly created Loc element </returns>
      ///	 
      public JDFValueLoc appendValueLoc()
      {
         return (JDFValueLoc)appendElement(ElementName.VALUELOC, null);
      }

      ///   
      ///	 <summary> * fitsRegExp - checks whether <code>str</code> matches the
      ///	 * AllowedRegExp/PresentRegExp specified for this State
      ///	 *  </summary>
      ///	 * <param name="str">
      ///	 *            string to test </param>
      ///	 * <param name="regexp">
      ///	 *            switches between AllowedRegExp and PresentRegExp. </param>
      ///	 * <returns> boolean - true, if <code>str</code> matches the RegExp or if
      ///	 *         AllowedRegExp is not specified </returns>
      ///	 
      protected internal bool fitsRegExp(string str, EnumFitsValue regexp)
      {
         string rExp;
         if (regexp.Equals(EnumFitsValue.Allowed))
         {
            rExp = getAllowedRegExp();
         }
         else
         {
            rExp = getPresentRegExp();
         }
         if (rExp.Length == 0)
            return true; // if AllowedRegExp is not specified return true

         if (!StringUtil.matches(str, rExp))
            return false;
         return true;
      }

      ///   
      ///	 <summary> * @return </summary>
      ///	 
      public virtual string getPresentRegExp()
      {
         // dummy - never used
         return null;
      }

      ///   
      ///	 <summary> * @return </summary>
      ///	 
      public virtual string getAllowedRegExp()
      {
         // dummy - never used
         return null;
      }

      ///   
      ///	 <summary> * get the availability of this devcaps based on the list of installed
      ///	 * modules in ModuleRefs and ModulePool
      ///	 * 
      ///	 * @return </summary>
      ///	 
      public virtual EnumAvailability getModuleAvailability()
      {
         return JDFModulePool.getModuleAvailability(this);
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.ifaces.IModuleCapability#getModulePool()
      //	 
      public virtual JDFModulePool getModulePool()
      {
         return (JDFModulePool)getParentPool(ElementName.MODULEPOOL);
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.ifaces.IModuleCapability#getModulePool()
      //	 
      public virtual JDFModulePool getCreateModulePool()
      {
         return (JDFModulePool)getCreateParentPool(ElementName.MODULEPOOL);
      }

      ///   
      ///	 <summary> * get the DEvCapPool that contains devcap elements referenced by this
      ///	 *  </summary>
      ///	 * <returns> JDFDevCapPool the pool </returns>
      ///	 
      private KElement getParentPool(string poolName)
      {
         KElement parent = getPoolParent();
         return parent.getElement(poolName);
      }

      ///   
      ///	 <summary> * get the DEvCapPool that contains devcap elements referenced by this
      ///	 *  </summary>
      ///	 * <returns> JDFDevCapPool the pool </returns>
      ///	 
      private KElement getCreateParentPool(string poolName)
      {
         KElement parent = getPoolParent();
         return parent.getCreateElement(poolName);
      }

      private KElement getPoolParent()
      {
         KElement parent = getDeepParent(ElementName.DEVICECAP, 0);
         if (parent == null)
            parent = getDeepParent(ElementName.MESSAGESERVICE, 0);
         if (!(parent is JDFDeviceCap) && !(parent is JDFMessageService))
            throw new JDFException("JDFDevCap.getParentPool - invalid parent context");
         return parent;
      }

      ///   
      ///	 <summary> * (21) get VString attribute ModuleRefs
      ///	 *  </summary>
      ///	 * <returns> VString the value of the attribute </returns>
      ///	 
      public virtual VString getModuleRefs()
      {
         return new VString(StringUtil.tokenize(getAttribute(AttributeName.MODULEREFS, null, null), " ", false));
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see
      //	 * org.cip4.jdflib.ifaces.IModuleCapability#appendModuleRef(java.lang.String
      //	 * )
      //	 
      public virtual JDFModuleCap appendModuleRef(string id)
      {
         return JDFModulePool.appendModuleRef(this, id);
      }


      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.core.KElement#init()
      //	 
      public override bool init()
      {
         appendAnchor(null);
         return base.init();
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.core.JDFElement#getIDPrefix()
      //	 
      public override string getIDPrefix()
      {
         return "d";
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.ifaces.ICapabilityElement#getEvaluationType()
      //	 
      public abstract EnumTerm getEvaluationType();
   }
}
