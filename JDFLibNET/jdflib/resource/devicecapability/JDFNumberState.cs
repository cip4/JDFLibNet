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
 * JDFNumberState.cs
 */


namespace org.cip4.jdflib.resource.devicecapability
{
   using System;



   using EnumListType = org.cip4.jdflib.auto.JDFAutoBasicPreflightTest.EnumListType;
   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using VString = org.cip4.jdflib.core.VString;
   using JDFNumberList = org.cip4.jdflib.datatypes.JDFNumberList;
   using JDFNumberRange = org.cip4.jdflib.datatypes.JDFNumberRange;
   using JDFNumberRangeList = org.cip4.jdflib.datatypes.JDFNumberRangeList;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using EnumTerm = org.cip4.jdflib.resource.devicecapability.JDFTerm.EnumTerm;
   using StringUtil = org.cip4.jdflib.util.StringUtil;
   using EnumFitsValue = org.cip4.jdflib.datatypes.EnumFitsValue;
   using JDFBaseDataTypes_Fields = org.cip4.jdflib.datatypes.JDFBaseDataTypes_Fields;

   public class JDFNumberState : JDFAbstractState
   {
      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[11];
      static JDFNumberState()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ALLOWEDVALUELIST, 0x33333331, AttributeInfo.EnumAttributeType.NumberRangeList, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.ALLOWEDVALUEMAX, 0x44444431, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.ALLOWEDVALUEMIN, 0x44444431, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.ALLOWEDVALUEMOD, 0x33333311, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.CURRENTVALUE, 0x33333331, AttributeInfo.EnumAttributeType.NumberList, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.DEFAULTVALUE, 0x33333331, AttributeInfo.EnumAttributeType.NumberList, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.PRESENTVALUELIST, 0x33333331, AttributeInfo.EnumAttributeType.NumberRangeList, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.PRESENTVALUEMAX, 0x44444431, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.PRESENTVALUEMIN, 0x44444431, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.PRESENTVALUEMOD, 0x33333311, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[10] = new AtrInfoTable(AttributeName.UNITTYPE, 0x33333311, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
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
      ///	 <summary> * constructor for JDFNumberState
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFNumberState(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * constructor for JDFNumberState
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFNumberState(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * constructor for JDFNumberState
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFNumberState(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
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
         return "JDFNumberState[ --> " + base.ToString() + " ]";
      }

      //   
      //	 * // Attribute getter/ setter
      //	 

      public virtual void setDefaultValue(double @value)
      {
         setAttribute(AttributeName.DEFAULTVALUE, @value, null);
      }

      public virtual void setDefaultValue(JDFNumberList @value)
      {
         setAttribute(AttributeName.DEFAULTVALUE, @value, null);
      }

      public virtual void setCurrentValue(JDFNumberList @value)
      {
         setAttribute(AttributeName.CURRENTVALUE, @value, null);
      }

      public virtual JDFNumberList getDefaultValue()
      {
         return getNumberList(AttributeName.DEFAULTVALUE);
      }

      public virtual void setCurrentValue(double @value)
      {
         setAttribute(AttributeName.CURRENTVALUE, @value, null);
      }

      public virtual JDFNumberList getCurrentValue()
      {
         return getNumberList(AttributeName.CURRENTVALUE);
      }

      public virtual void setAllowedValueList(JDFNumberRangeList @value)
      {
         setAttribute(AttributeName.ALLOWEDVALUELIST, @value.ToString(), null);
      }

      public virtual JDFNumberRangeList getAllowedValueList()
      {
         return getNumberRangeList(AttributeName.ALLOWEDVALUELIST);
      }

      public virtual void setPresentValueList(JDFNumberRangeList @value)
      {
         setAttribute(AttributeName.PRESENTVALUELIST, @value.ToString(), null);
      }

      public virtual JDFNumberRangeList getPresentValueList()
      {
         JDFNumberRangeList nl = getNumberRangeList(AttributeName.PRESENTVALUELIST);
         return (nl == null) ? getAllowedValueList() : nl;
      }

      public virtual void setAllowedValueMax(double @value)
      {
         setAttribute(AttributeName.ALLOWEDVALUEMAX, @value, null);
      }

      public virtual double getAllowedValueMax()
      {
         return getRealAttribute(AttributeName.ALLOWEDVALUEMAX, null, 0.0);
      }

      public virtual void setPresentValueMax(double @value)
      {
         setAttribute(AttributeName.PRESENTVALUEMAX, @value, null);
      }

      public virtual double getPresentValueMax()
      {
         if (hasAttribute(AttributeName.PRESENTVALUEMAX))
         {
            return getRealAttribute(AttributeName.PRESENTVALUEMAX, null, 0.0);
         }
         return getAllowedValueMax();
      }

      public virtual void setAllowedValueMin(double @value)
      {
         setAttribute(AttributeName.ALLOWEDVALUEMIN, @value, null);
      }

      public virtual double getAllowedValueMin()
      {
         return getRealAttribute(AttributeName.ALLOWEDVALUEMIN, null, 0.0);
      }

      public virtual void setPresentValueMin(double @value)
      {
         setAttribute(AttributeName.PRESENTVALUEMIN, @value, null);
      }

      public virtual double getPresentValueMin()
      {
         if (hasAttribute(AttributeName.PRESENTVALUEMIN))
         {
            return getRealAttribute(AttributeName.PRESENTVALUEMIN, null, 0.0);
         }
         return getAllowedValueMin();
      }

      public virtual void setAllowedValueMod(JDFXYPair @value)
      {
         setAttribute(AttributeName.ALLOWEDVALUEMOD, @value.ToString(), null);
      }

      public virtual JDFXYPair getAllowedValueMod()
      {
         try
         {
            return new JDFXYPair(getAttribute(AttributeName.ALLOWEDVALUEMOD));
         }
         catch (FormatException)
         {
            throw new JDFException("JDFNumberState.setAllowedValueMod: Attribute allowvaluemod is not applicable to create JDFXYPair");
         }

      }

      public virtual void setPresentValueMod(JDFXYPair @value)
      {
         setAttribute(AttributeName.PRESENTVALUEMOD, @value.ToString());
      }

      public virtual JDFXYPair getPresentValueMod()
      {
         try
         {
            if (hasAttribute(AttributeName.PRESENTVALUEMOD))
            {
               return new JDFXYPair(getAttribute(AttributeName.PRESENTVALUEMOD));
            }
            return getAllowedValueMod();
         }
         catch (FormatException)
         {
            throw new JDFException("JDFNumberState.setAllowedValueMod: The XYPair value is invalid!");
         }

      }

      public virtual string getUnitType()
      {
         return getAttribute(AttributeName.UNITTYPE);
      }

      public virtual void setUnitType(string @value)
      {
         setAttribute(AttributeName.UNITTYPE, @value);
      }

      //   
      //	 * // Element getter / setter
      //	 
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

         if (!StringUtil.isNumber(@value))
            return;
         double d = StringUtil.parseDouble(@value, 0);

         if (testlists == null || EnumFitsValue.Allowed.Equals(testlists))
         {
            JDFNumberRangeList list = getAllowedValueList();
            if (list == null)
               list = new JDFNumberRangeList();
            list.Append(d);
            setAllowedValueList(list);
         }
         if (testlists == null || EnumFitsValue.Present.Equals(testlists))
         {
            JDFNumberRangeList list = getPresentValueList();
            if (list == null || !hasAttribute(AttributeName.PRESENTVALUELIST))
               list = new JDFNumberRangeList();
            list.Append(d);
            setPresentValueList(list);
         }
      }

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
      public override bool fitsValue(string @value, EnumFitsValue testlists)
      {
         if (fitsListType(@value))
         {
            JDFNumberRangeList rangelist = null;
            try
            {
               rangelist = new JDFNumberRangeList(@value);
            }
            catch (FormatException)
            {
               return false;
            }

            return (fitsValueList(rangelist, testlists) && fitsValueMod(rangelist, testlists));
         }
         return false; // the value doesn't fit ListType attribute of this State
      }

      ///   
      ///	 <summary> * fitsValueList - checks whether <code>rangelist</code> matches the
      ///	 * AllowedValueList/PresentValueList specified for this State
      ///	 *  </summary>
      ///	 * <param name="rangelist">
      ///	 *            range list to test </param>
      ///	 * <param name="valuelist">
      ///	 *            switches between AllowedValueList and PresentValueList.
      ///	 *  </param>
      ///	 * <returns> boolean - true, if <code>rangelist</code> matches the valuelist
      ///	 *         or if AllowedValueList is not specified </returns>
      ///	 
      private bool fitsValueList(JDFNumberRangeList rangelist, EnumFitsValue valuelist)
      {
         JDFNumberRangeList list;
         if (valuelist.Equals(EnumFitsValue.Allowed))
         {
            list = getAllowedValueList();
         }
         else
         {
            list = getPresentValueList();
         }
         if (list == null)
            return true;

         EnumListType listType = getListType();
         if (listType.Equals(EnumListType.CompleteList))
         {
            return fitsCompleteList(rangelist, list);
         }
         else if (listType.Equals(EnumListType.CompleteOrderedList))
         {
            return fitsCompleteOrderedList(rangelist, list);
         }
         else if (listType.Equals(EnumListType.ContainedList))
         {
            return fitsContainedList(rangelist, list);
         }

         int siz = rangelist.Count;
         for (int i = 0; i < siz; i++)
         {
            JDFNumberRange range = (JDFNumberRange)rangelist[i];

            if (!list.isPartOfRange(range))
               return false;
         }
         return true;
      }

      ///   
      ///	 <summary> * fitsValueMod - checks whether <code>range</code> matches the
      ///	 * <code>ValueMod</code> specified for this State.
      ///	 *  </summary>
      ///	 * <param name="rangelist">
      ///	 *            range list to test </param>
      ///	 * <param name="valuemod">
      ///	 *            switches between AllowedValueMod and PresentValueMod.
      ///	 *  </param>
      ///	 * <returns> boolean - true, if <code>rangelist</code> matches the valuemod or
      ///	 *         if AllowedValueMod is not specified </returns>
      ///	 
      private bool fitsValueMod(JDFNumberRangeList rangelist, EnumFitsValue valuemod)
      {
         if (valuemod.Equals(EnumFitsValue.Allowed))
         {
            if (!hasAttribute(AttributeName.ALLOWEDVALUEMOD))
               return true;
         }
         else
         {
            if (!hasAttribute(AttributeName.ALLOWEDVALUEMOD) && !hasAttribute(AttributeName.PRESENTVALUEMOD))
               return true;
         }

         JDFXYPair mod;
         if (valuemod.Equals(EnumFitsValue.Allowed))
         {
            mod = getAllowedValueMod();
         }
         else
         {
            mod = getPresentValueMod();
         }

         int size = rangelist.Count;
         for (int i = 0; i < size; )
         {
            JDFNumberRange range = (JDFNumberRange)rangelist[i];

            double left = range.Left;
            double right = range.Right;
            if (left != right) // if we have a range return false, check only
               // single value
               return false;

            double elem = left; // single value
            double divi = mod.X; // X - the Modulo
            double shift = mod.Y; // Y - offset of the allowed/present
            // value

            if (divi == 0)
               return false;

            // if ValueMod is not "0 x"
            double n = ((elem - divi * (int)(elem / divi)) - shift); // n =
            // elem
            // %
            // divi
            // -
            // shift
            if (Math.Abs(n) < JDFBaseDataTypes_Fields.EPSILON * Math.Abs(divi))
            {
               return true;
            }

            double m = (n - divi * (int)(n / divi)); // m = ( elem % divi -
            // shift ) % divi
            if (Math.Abs(m) < JDFBaseDataTypes_Fields.EPSILON * Math.Abs(divi))
            {
               return true;
            }
            return false;

         }
         return true;
      }

      ///   
      ///	 <summary> * fitsCompleteList - tests whether <code>value</code> matches the given
      ///	 * testlist (ListType=fitsCompleteList)
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <param name="list">
      ///	 *            testlist, either AllowedValueList or PresentValueList.
      ///	 *  </param>
      ///	 * <returns> boolean - true, if <code>value</code> matches the testlist </returns>
      ///	 
      private bool fitsCompleteList(JDFNumberRangeList @value, JDFNumberRangeList list)
      {
         int v_size = @value.Count;
         int l_size = list.Count;

         if (v_size != l_size)
            return false;

         if (!@value.isUnique())
            return false;

         JDFNumberRangeList valueList = new JDFNumberRangeList(@value);

         bool bFound;
         for (int i = l_size - 1; i >= 0; i--)
         {
            bFound = false;
            for (int j = valueList.Count - 1; j >= 0; j--)
            {
               if (list[i].Equals(valueList[j]))
               {
                  valueList.erase(j);
                  bFound = true;
                  break;
               }
            }
            if (!bFound)
            {
               return false;
            }
         }
         return true;
      }

      ///   
      ///	 <summary> * fitsCompleteOrderedList - tests whether <code>value</code> matches the
      ///	 * given testlist (ListType=CompleteOrderedList)
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <param name="list">
      ///	 *            testlist, either AllowedValueList or PresentValueList.
      ///	 *  </param>
      ///	 * <returns> boolean - true, if <code>value</code> matches the testlist </returns>
      ///	 
      private bool fitsCompleteOrderedList(JDFNumberRangeList @value, JDFNumberRangeList list)
      {
         int v_size = @value.Count;
         int l_size = list.Count;

         if (v_size != l_size)
            return false;

         if (!@value.isUnique())
            return false;

         for (int i = 0; i < l_size; i++)
         {
            if (!list[i].Equals(@value[i]))
            {
               return false;
            }
         }
         return true;
      }

      ///   
      ///	 <summary> * fitsContainedList - tests whether <code>value</code> matches the given
      ///	 * testlist (ListType=ContainedList)
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <param name="list">
      ///	 *            testlist, either AllowedValueList or PresentValueList.
      ///	 *  </param>
      ///	 * <returns> boolean - true, if <code>value</code> matches testlist </returns>
      ///	 
      private bool fitsContainedList(JDFNumberRangeList @value, JDFNumberRangeList list)
      {
         int v_size = @value.Count;
         int l_size = list.Count;

         for (int i = 0; i < v_size; i++)
         {
            for (int j = 0; j < l_size; j++)
            {
               if (@value[i].Equals(list[j]))
               {
                  return true;
               }
            }
         }
         return false;
      }

      ///   
      ///	 * <param name="listName">
      ///	 * @return </param>
      ///	 
      private JDFNumberList getNumberList(string listName)
      {
         try
         {
            string attribute = getAttribute(listName, null, null);
            if (attribute == null)
               return null;
            return new JDFNumberList(attribute);
         }
         catch (FormatException)
         {
            throw new JDFException("JDFNumberState.getNumberList, Unable to create JDFIntegerRangeList from Attribute value: " + listName);
         }
      }

      ///   
      ///	 * <param name="listName">
      ///	 * @return </param>
      ///	 
      private JDFNumberRangeList getNumberRangeList(string listName)
      {
         try
         {
            string attribute = getAttribute(listName, null, null);
            if (attribute == null)
               return null;
            return new JDFNumberRangeList(attribute);
         }
         catch (FormatException)
         {
            throw new JDFException("JDFIntegerState.getIntegerRangeList, Unable to create JDFIntegerRangeList from Attribute value: " + listName);
         }
      }

      public override VString getInvalidAttributes(EnumValidationLevel level, bool bIgnorePrivate, int nMax)
      {
         return getInvalidAttributesImpl(level, bIgnorePrivate, nMax);
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.ifaces.ICapabilityElement#getEvaluationType()
      //	 
      public override EnumTerm getEvaluationType()
      {
         return EnumTerm.NumberEvaluation;
      }
   }
}
