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
 *  
 */ 
 


/* Copyright (c) 2001 Heidelberger Druckmaschinen AG, All Rights Reserved.
 * 
 * @author Elena Skobchenko
 * JDFBooleanState.cs
 */


namespace org.cip4.jdflib.resource.devicecapability
{
   using System.Collections;
   using System.Collections.Generic;


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using VString = org.cip4.jdflib.core.VString;
   using EnumTerm = org.cip4.jdflib.resource.devicecapability.JDFTerm.EnumTerm;
   using EnumFitsValue = org.cip4.jdflib.datatypes.EnumFitsValue;

   public class JDFBooleanState : JDFAbstractState
   {
      new private const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[4];
      static JDFBooleanState()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ALLOWEDVALUELIST, 0x33333331, AttributeInfo.EnumAttributeType.enumerations, EnumBoolean.getEnum(0), null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.CURRENTVALUE, 0x33333331, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.DEFAULTVALUE, 0x33333331, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.PRESENTVALUELIST, 0x33333331, AttributeInfo.EnumAttributeType.enumerations, EnumBoolean.getEnum(0), null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.VALUELOC, 0x33333311);
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
      ///	 <summary> * Constructor for JDFBooleanState
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFBooleanState(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFBooleanState
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFBooleanState(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFBooleanState
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFBooleanState(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
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
         return "JDFBooleanState[ --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * set attribute <code>CurrentValue</code>
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to set the attribute to </param>
      ///	 
      public virtual void setCurrentValue(bool @value)
      {
         setAttribute(AttributeName.CURRENTVALUE, @value, null);
      }

      ///   
      ///	 <summary> * get attribute <code>CurrentValue</code>
      ///	 *  </summary>
      ///	 * <returns> the value of the attribute </returns>
      ///	 
      public virtual bool getCurrentValue()
      {
         return getBoolAttribute(AttributeName.CURRENTVALUE, JDFConstants.EMPTYSTRING, false);
      }

      ///   
      ///	 <summary> * set attribute <code>DefaultValue</code>
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            the value to set the attribute to </param>
      ///	 
      public virtual void setDefaultValue(bool @value)
      {
         setAttribute(AttributeName.DEFAULTVALUE, @value, null);
      }

      ///   
      ///	 <summary> * get attribute <code>DefaultValue</code>
      ///	 *  </summary>
      ///	 * <returns> the value of the attribute </returns>
      ///	 
      public virtual bool getDefaultValue()
      {
         return getBoolAttribute(AttributeName.DEFAULTVALUE, JDFConstants.EMPTYSTRING, false);
      }

      ///   
      ///	 <summary> * get the list of allowed values
      ///	 *  </summary>
      ///	 * <returns> Vector, <code>null</code> if no allowed values found </returns>
      ///	 
      public virtual List<ValuedEnum> getAllowedValueList()
      {
         List<ValuedEnum> enumerationsAttribute = getEnumerationsAttribute(AttributeName.ALLOWEDVALUELIST, null, EnumBoolean.True, false);
         if (!(enumerationsAttribute.Count == 0))
            return enumerationsAttribute;
         return null;
      }

      ///   
      ///	 <summary> * set attribute <code>AllowedValueList</code>
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to set the attribute to </param>
      ///	 
      public virtual void setAllowedValueList(List<ValuedEnum> @value)
      {
         setEnumerationsAttribute(AttributeName.ALLOWEDVALUELIST, @value, null);
      }

      ///   
      ///	 <summary> * get attribute <code>PresentValueList</code>
      ///	 *  </summary>
      ///	 * <returns> the value of the attribute </returns>
      ///	 
      public virtual List<ValuedEnum> getPresentValueList()
      {
         if (hasAttribute(AttributeName.PRESENTVALUELIST))
         {
            return getEnumerationsAttribute(AttributeName.PRESENTVALUELIST, null, EnumBoolean.True, false);
         }
         return getAllowedValueList();
      }

      ///   
      ///	 <summary> * set attribute <code>PresentValueList</code>
      ///	 *  </summary>
      ///	 * <param name="value"> </param>
      ///	 
      public virtual void setPresentValueList(List<ValuedEnum> value)
      {
         setEnumerationsAttribute(AttributeName.PRESENTVALUELIST, value, null);
      }

      //   
      //	 * // Element Getter / Setter
      //	 

      ///   
      ///	 <summary> * fitsValue - tests, if the defined value matches the Allowed test lists or
      ///	 * Present test lists, specified for this State
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <param name="testlists">
      ///	 *            test lists, that the value has to match. In this State there
      ///	 *            is only one test list - ValueList.<br>
      ///	 *            Choose one of two values: FitsValue_Allowed or
      ///	 *            FitsValue_Present. Defaults to Allowed.
      ///	 *  </param>
      ///	 * <returns> boolean - true, if <code>value</code> matches testlists or if
      ///	 *         AllowedValueList is not specified </returns>
      ///	 
      public override sealed bool fitsValue(string valueStr, EnumFitsValue testlists)
      {
         if (fitsListType(valueStr))
         {
            VString @value = new VString(valueStr, null);

            for (int i = 0; i < @value.Count; i++)
            {
               if (!fitsValueList(@value[i], testlists))
                  return false;
            }
            return true; // if we are here a whole 'valueStr' fits
         }
         return false;
      }

      ///   
      ///	 <summary> * fitsValueList - tests, if the defined 'value' matches the
      ///	 * AllowedValueList or the PresentValueList, specified for this State
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            token to test </param>
      ///	 * <param name="valuelist">
      ///	 *            Switches between AllowedValueList and PresentValueList. </param>
      ///	 * <returns> boolean - true, if <code>value</code> matches valuelist, or if
      ///	 *         AllowedValueList is not specified </returns>
      ///	 
      private bool fitsValueList(string @value, EnumFitsValue valuelist)
      {
         List<ValuedEnum> v;
         EnumBoolean eb = EnumBoolean.getEnum(@value);
         if (eb == null)
            return false;
         if (valuelist.Equals(EnumFitsValue.Allowed))
         {
            v = getAllowedValueList();
         }
         else
         {
            v = getPresentValueList();
         }

         if (v == null)
            return true;

         return v.Contains(eb);
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
         EnumBoolean b = EnumBoolean.getEnum(@value);
         if (b == null)
            return;

         if (testlists == null || EnumFitsValue.Allowed.Equals(testlists))
         {
            List<ValuedEnum> list = getAllowedValueList();
            if (list == null)
               list = new List<ValuedEnum>();
            list.Add(b);
            setAllowedValueList(list);
         }
         if (testlists == null || EnumFitsValue.Present.Equals(testlists))
         {
            List<ValuedEnum> list = getPresentValueList();
            if (list == null || !hasAttribute(AttributeName.PRESENTVALUELIST))
               list = new List<ValuedEnum>();
            list.Add(b);
            setPresentValueList(list);
         }
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.ifaces.ICapabilityElement#getEvaluationType()
      //	 
      public override EnumTerm getEvaluationType()
      {
         return EnumTerm.BooleanEvaluation;
      }
   }
}
