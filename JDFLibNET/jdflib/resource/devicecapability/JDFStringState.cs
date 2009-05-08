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
 * JDFStringState.cs
 */


namespace org.cip4.jdflib.resource.devicecapability
{


   using EnumValueUsage = org.cip4.jdflib.auto.JDFAutoValue.EnumValueUsage;
   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using VElement = org.cip4.jdflib.core.VElement;
   using JDFIntegerRange = org.cip4.jdflib.datatypes.JDFIntegerRange;
   using JDFValue = org.cip4.jdflib.resource.JDFValue;
   using EnumTerm = org.cip4.jdflib.resource.devicecapability.JDFTerm.EnumTerm;
   using EnumFitsValue = org.cip4.jdflib.datatypes.EnumFitsValue;

   public class JDFStringState : JDFAbstractState
   {
      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[6];
      static JDFStringState()
      {
         atrInfoTable[1] = new AtrInfoTable(AttributeName.ALLOWEDLENGTH, 0x33333311, AttributeInfo.EnumAttributeType.IntegerRange, null, null);
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ALLOWEDREGEXP, 0x33333311, AttributeInfo.EnumAttributeType.RegExp, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.CURRENTVALUE, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.DEFAULTVALUE, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.PRESENTLENGTH, 0x33333311, AttributeInfo.EnumAttributeType.IntegerRange, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.PRESENTREGEXP, 0x33333311, AttributeInfo.EnumAttributeType.RegExp, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.VALUE, 0x33333331);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }

      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[1];

      protected internal override ElementInfo getTheElementInfo()
      {
         return new ElementInfo(base.getTheElementInfo(), elemInfoTable);
      }

      ///   
      ///	 <summary> * constructor for JDFStringState
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFStringState(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * constructor for JDFStringState
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFStringState(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * constructor for JDFStringState
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFStringState(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
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
         return "JDFStringState[ --> " + base.ToString() + " ]";
      }

      //   
      //	 * // Attribute getter/ setter
      //	 

      public virtual void setCurrentValue(string @value)
      {
         setAttribute(AttributeName.CURRENTVALUE, @value);
      }

      public virtual string getCurrentValue()
      {
         return getAttribute(AttributeName.CURRENTVALUE, null, JDFConstants.EMPTYSTRING);
      }

      public virtual void setDefaultValue(string @value)
      {
         setAttribute(AttributeName.DEFAULTVALUE, @value);
      }

      public virtual string getDefaultValue()
      {
         return getAttribute(AttributeName.DEFAULTVALUE, null, JDFConstants.EMPTYSTRING);
      }

      public virtual void setAllowedRegExp(string @value)
      {
         setAttribute(AttributeName.ALLOWEDREGEXP, @value);
      }

      public override string getAllowedRegExp()
      {
         return getAttribute(AttributeName.ALLOWEDREGEXP);
      }

      public virtual void setPresentRegExp(string @value)
      {
         setAttribute(AttributeName.PRESENTREGEXP, @value);
      }

      public override string getPresentRegExp()
      {
         if (hasAttribute(AttributeName.PRESENTREGEXP))
         {
            return getAttribute(AttributeName.PRESENTREGEXP);
         }
         return getAllowedRegExp();
      }

      //   
      //	 * // Element getter / setter
      //	 

      public virtual JDFValue getValue(int iSkip)
      {
         JDFValue e = (JDFValue)getElement(ElementName.VALUE, null, iSkip);
         return e;
      }

      public virtual JDFValue appendValue()
      {
         return (JDFValue)appendElement(ElementName.VALUE, null);
      }

      //   
      //	 * // Subelement attribute and element Getter / Setter
      //	 

      ///   
      ///	 <summary> * Gets the jSkip'th element <code>Loc</code> of the iSkip'th element
      ///	 * <code>Value</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            number of <code>Value</code> elements to skip (iSkip=0 ->
      ///	 *            first <code>Value</code> element) </param>
      ///	 * <param name="jSkip">
      ///	 *            number of <code>Loc</code> subelements of iSkip'th
      ///	 *            <code>Value</code> element to skip (jSkip=0 -> first
      ///	 *            <code>Loc</code> element) </param>
      ///	 * <returns> JDFLoc: the matching Loc element </returns>
      ///	 
      public override JDFLoc getValueLocLoc(int iSkip, int jSkip)
      {
         JDFValue val = (JDFValue)getElement(ElementName.VALUE, null, iSkip);
         JDFLoc loc = (JDFLoc)val.getElement(ElementName.LOC, null, jSkip);
         return loc;
      }

      ///   
      ///	 <summary> * Appends element <code>Loc</code> to the end of the iSkip'th subelement
      ///	 * <code>Value</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            number of <code>Value</code> elements to skip (iSkip=0 ->
      ///	 *            first <code>Value</code> element) </param>
      ///	 * <returns> JDFLoc: newly created <code>Loc</code> element </returns>
      ///	 
      public override JDFLoc appendValueLocLoc(int iSkip)
      {
         JDFValue val = getValue(iSkip);
         if (val == null)
            return null;
         return val.appendLoc();
      }

      ///   
      ///	 <summary> * Sets the <code>AllowedValue</code> attribute of the iSkip'th subelement
      ///	 * <code>Value</code>
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to set the attribute to </param>
      ///	 
      public virtual void appendValueAllowedValue(string @value)
      {
         JDFValue e = (JDFValue)appendElement(ElementName.VALUE, null);
         e.setAllowedValue(@value);
      }

      ///   
      ///	 <summary> * Gets the <code>AllowedValue</code> attribute of the iSkip'th subelement
      ///	 * <code>Value</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            the number of <code>Value</code> elements to skip </param>
      ///	 * <returns> String: the attribute value </returns>
      ///	 
      public string getValueAllowedValue(int iSkip)
      {
         JDFValue e = (JDFValue)getElement(ElementName.VALUE, null, iSkip);
         if (e == null)
            return null;
         return e.getAllowedValue();
      }

      ///   
      ///	 <summary> * Sets the ValueUsage attribute of the i-th subelement Value
      ///	 *  </summary>
      ///	 * <param name="int"> iSkip: the number of Value elements to skip </param>
      ///	 * <param name="EnumFitsValue">
      ///	 *            value: value to set the attribute to </param>
      ///	 
      public virtual void setValueValueUsage(int iSkip, EnumFitsValue @value)
      {
         JDFValue e = (JDFValue)getElement(ElementName.VALUE, null, iSkip);
         e.setValueUsage(EnumValueUsage.getEnum(@value.getName()));
      }

      ///   
      ///	 <summary> * Gets the value of attribute <code>ValueUsage</code> of the iSkip'th
      ///	 * subelement <code>Value</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            the number of <code>Value</code> elements to skip </param>
      ///	 * <returns> EnumFitsValue: the attribute value </returns>
      ///	 
      public EnumFitsValue getValueValueUsage(int iSkip)
      {
         JDFValue e = (JDFValue)getElement(ElementName.VALUE, null, iSkip);
         return EnumFitsValue.getEnum(e.getValueUsage().getName());
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see
      //	 * org.cip4.jdflib.resource.devicecapability.JDFAbstractState#addValue(java
      //	 * .lang.String, org.cip4.jdflib.datatypes.JDFBaseDataTypes.EnumFitsValue)
      //	 
      public override void addValue(string @value, EnumFitsValue testlists)
      {
         if (fitsValue(@value, testlists))
            return;

         if (testlists == null || EnumFitsValue.Allowed.Equals(testlists))
         {
            JDFValue v = appendValue();
            v.setAllowedValue(@value);
            if (testlists != null)
               v.setValueUsage(EnumValueUsage.Allowed);
         }
         if (EnumFitsValue.Present.Equals(testlists))
         {
            JDFValue v = appendValue();
            v.setAllowedValue(@value);
            if (testlists != null)
               v.setValueUsage(EnumValueUsage.Present);
         }
      }

      //   
      //	 * // FitsValue Methods
      //	 

      ///   
      ///	 <summary> * fitsValue - checks whether <code>value</code> matches the Allowed/Present
      ///	 * test lists specified for this State
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <param name="testlists">
      ///	 *            the test lists the value has to match. In this State the test
      ///	 *            lists are ValueList AND ValueMod.<br>
      ///	 *            Choose one of two values: FitsValue_Allowed or
      ///	 *            FitsValue_Present. (Defaults to Allowed)
      ///	 *  </param>
      ///	 * <returns> boolean - true, if <code>value</code> matches testlists or if
      ///	 *         AllowedValueList and AllowedValueMod are not specified </returns>
      ///	 
      public sealed override bool fitsValue(string @value, EnumFitsValue testlists)
      {
         return (fitsLength(@value, testlists) && fitsRegExp(@value, testlists) && fitsValueElem(@value, testlists));
      }

      ///   
      ///	 <summary> * fitsValueElem - checks whether <code>str</code> matches the subelement
      ///	 * <code>Value</code> specified for this State
      ///	 *  </summary>
      ///	 * <param name="str">
      ///	 *            string to test </param>
      ///	 * <param name="valueusage">
      ///	 *            switches between Allowed and Present configuration in
      ///	 *            subelement <code>Value</code>
      ///	 *  </param>
      ///	 * <returns> boolean - true, if <code>str</code> matches subelement Value or
      ///	 *         no corresponding value elements exist </returns>
      ///	 
      private bool fitsValueElem(string str, EnumFitsValue valuelist)
      {
         VElement v = getChildElementVector(ElementName.VALUE, null, null, true, 0, false);
         int siz = v.Count;
         bool hasValue = false;
         for (int i = 0; i < siz; i++)
         {
            JDFValue elm = (JDFValue)v[i];
            if (elm.hasAttribute(AttributeName.VALUEUSAGE))
            {
               EnumFitsValue valueUsage = getValueValueUsage(i);
               if (valuelist.Equals(valueUsage))
               {
                  string @value = getValueAllowedValue(i);
                  hasValue = true;
                  if (@value.CompareTo(str) == 0)
                     return true; // we have found it
               }
            }
            else
            {
               hasValue = true;
               string @value = getValueAllowedValue(i);
               if (@value.CompareTo(str) == 0)
                  return true; // we have found it
            }
         }
         return !hasValue;
      }

      public override void setAllowedLength(JDFIntegerRange @value)
      {
         base.setPresentLength(@value);
      }

      public override JDFIntegerRange getAllowedLength()
      {
         return base.getAllowedLength();
      }

      public override void setPresentLength(JDFIntegerRange @value)
      {
         base.setAllowedLength(@value);
      }

      public override JDFIntegerRange getPresentLength()
      {
         return base.getPresentLength();
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.ifaces.ICapabilityElement#getEvaluationType()
      //	 
      public override EnumTerm getEvaluationType()
      {
         return EnumTerm.StringEvaluation;
      }
   }
}
