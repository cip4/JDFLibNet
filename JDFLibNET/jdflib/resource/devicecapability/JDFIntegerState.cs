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
 * JDFIntegerState.cs
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
   using JDFIntegerList = org.cip4.jdflib.datatypes.JDFIntegerList;
   using JDFIntegerRange = org.cip4.jdflib.datatypes.JDFIntegerRange;
   using JDFIntegerRangeList = org.cip4.jdflib.datatypes.JDFIntegerRangeList;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using EnumTerm = org.cip4.jdflib.resource.devicecapability.JDFTerm.EnumTerm;
   using StringUtil = org.cip4.jdflib.util.StringUtil;
   using EnumFitsValue = org.cip4.jdflib.datatypes.EnumFitsValue;


   public class JDFIntegerState : JDFAbstractState
   {
      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[11];
      static JDFIntegerState()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ALLOWEDVALUELIST, 0x33333331, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.ALLOWEDVALUEMAX, 0x44444431, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.ALLOWEDVALUEMIN, 0x44444431, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.ALLOWEDVALUEMOD, 0x33333311, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.CURRENTVALUE, 0x33333331, AttributeInfo.EnumAttributeType.IntegerList, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.DEFAULTVALUE, 0x33333331, AttributeInfo.EnumAttributeType.IntegerList, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.PRESENTVALUELIST, 0x33333331, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.PRESENTVALUEMAX, 0x44444431, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.PRESENTVALUEMIN, 0x44444431, AttributeInfo.EnumAttributeType.integer, null, null);
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
      ///	 <summary> * constructor for JDFIntegerState
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFIntegerState(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * constructor for JDFIntegerState
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFIntegerState(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * constructor for JDFIntegerState
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFIntegerState(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
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
         return "JDFIntegerState[ --> " + base.ToString() + " ]";
      }

      //   
      //	 * // Attribute getter/ setter
      //	 

      public virtual void setDefaultValue(int @value)
      {
         setAttribute(AttributeName.DEFAULTVALUE, @value, null);
      }

      public virtual void setDefaultValue(JDFIntegerList @value)
      {
         setAttribute(AttributeName.DEFAULTVALUE, @value, null);
      }

      public virtual void setCurrentValue(JDFIntegerList @value)
      {
         setAttribute(AttributeName.CURRENTVALUE, @value, null);
      }

      public virtual JDFIntegerList getDefaultValue()
      {
         return getIntegerList(AttributeName.DEFAULTVALUE);
      }

      public virtual void setCurrentValue(int @value)
      {
         setAttribute(AttributeName.CURRENTVALUE, @value, null);
      }

      public virtual JDFIntegerList getCurrentValue()
      {
         return getIntegerList(AttributeName.CURRENTVALUE);
      }

      public virtual void setAllowedValueList(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.ALLOWEDVALUELIST, @value.ToString(), null);
      }

      ///   
      ///	 <summary> * get the allowedValueList
      ///	 *  </summary>
      ///	 * <returns> the allowedValuelist, <code>null</code> if no list exists </returns>
      ///	 
      public virtual JDFIntegerRangeList getAllowedValueList()
      {
         return getIntegerRangeList(AttributeName.ALLOWEDVALUELIST);
      }

      public virtual void setPresentValueList(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.PRESENTVALUELIST, @value.ToString(), null);
      }

      public virtual JDFIntegerRangeList getPresentValueList()
      {
         JDFIntegerRangeList il = getIntegerRangeList(AttributeName.PRESENTVALUELIST);
         return (il == null) ? getAllowedValueList() : il;
      }

      ///   
      ///	 * <param name="listName">
      ///	 * @return </param>
      ///	 
      private JDFIntegerRangeList getIntegerRangeList(string listName)
      {
         try
         {
            string attribute = getAttribute(listName, null, null);
            if (attribute == null)
               return null;
            return new JDFIntegerRangeList(attribute);
         }
         catch (FormatException)
         {
            throw new JDFException("JDFIntegerState.getIntegerRangeList, Unable to create JDFIntegerRangeList from Attribute value: " + listName);
         }
      }

      ///   
      ///	 * <param name="listName">
      ///	 * @return </param>
      ///	 
      private JDFIntegerList getIntegerList(string listName)
      {
         try
         {
            string attribute = getAttribute(listName, null, null);
            if (attribute == null)
               return null;
            return new JDFIntegerList(attribute);
         }
         catch (FormatException)
         {
            throw new JDFException("JDFIntegerState.getIntegerList, Unable to create JDFIntegerRangeList from Attribute value: " + listName);
         }
      }

      public virtual void setAllowedValueMax(int @value)
      {
         setAttribute(AttributeName.ALLOWEDVALUEMAX, @value, null);
      }

      public virtual int getAllowedValueMax()
      {
         return getIntAttribute(AttributeName.ALLOWEDVALUEMAX, null, 0);
      }

      public virtual void setPresentValueMax(int @value)
      {
         setAttribute(AttributeName.PRESENTVALUEMAX, @value, null);
      }

      public virtual int getPresentValueMax()
      {
         if (hasAttribute(AttributeName.PRESENTVALUEMAX))
         {
            return getIntAttribute(AttributeName.PRESENTVALUEMAX, null, 0);
         }
         return getAllowedValueMax();
      }

      public virtual void setAllowedValueMin(int @value)
      {
         setAttribute(AttributeName.ALLOWEDVALUEMIN, @value, null);
      }

      public virtual int getAllowedValueMin()
      {
         return getIntAttribute(AttributeName.ALLOWEDVALUEMIN, null, 0);
      }

      public virtual void setPresentValueMin(int @value)
      {
         setAttribute(AttributeName.PRESENTVALUEMIN, @value, null);
      }

      public virtual int getPresentValueMin()
      {
         if (hasAttribute(AttributeName.PRESENTVALUEMIN))
         {
            return getIntAttribute(AttributeName.PRESENTVALUEMIN, null, 0);
         }
         return getAllowedValueMin();
      }

      public virtual void setAllowedValueMod(JDFXYPair @value)
      {
         setAttribute(AttributeName.ALLOWEDVALUEMOD, @value.ToString());
      }

      public virtual JDFXYPair getAllowedValueMod()
      {
         try
         {
            return new JDFXYPair(getAttribute(AttributeName.ALLOWEDVALUEMOD));
         }
         catch (FormatException)
         {
            throw new JDFException("JDFIntegerState.getAllowedValueMod: The XYPair value is invalid!");
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
            throw new JDFException("The XYPair value is invalid!");
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

         if (!StringUtil.isInteger(@value))
            return;
         int i = StringUtil.parseInt(@value, 0);

         if (testlists == null || EnumFitsValue.Allowed.Equals(testlists))
         {
            JDFIntegerRangeList list = getAllowedValueList();
            if (list == null)
               list = new JDFIntegerRangeList();
            list.Append(i);
            list.normalize(true);
            setAllowedValueList(list);

         }
         if (testlists == null || EnumFitsValue.Present.Equals(testlists))
         {
            JDFIntegerRangeList list = getPresentValueList();
            if (list == null || !hasAttribute(AttributeName.PRESENTVALUELIST))
               list = new JDFIntegerRangeList();
            list.Append(i);
            list.normalize(true);
            setPresentValueList(list);
         }
      }

      ///   
      ///	 <summary> * fitsValue - checks whether <code>value</code> matches the given test
      ///	 * lists
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <param name="testlists">
      ///	 *            test lists the value has to match. In this State the test
      ///	 *            lists are ValueList AND ValueMod.<br>
      ///	 *            Choose one of two values: FitsValue_Allowed or
      ///	 *            FitsValue_Present. Defaults to Allowed.
      ///	 *  </param>
      ///	 * <returns> boolean - true, if <code>value</code> matches the testlists or if
      ///	 *         AllowedValueList and AllowedValueMod are not specified </returns>
      ///	 
      public override bool fitsValue(string @value, EnumFitsValue testlists)
      {
         bool testResult = true;

         if (!fitsListType(@value))
            testResult = false;
         else
         {
            JDFIntegerRangeList rangelist = null;
            try
            {
               rangelist = new JDFIntegerRangeList(@value);
            }
            catch (FormatException)
            {
               testResult = false;
            }
            if (testResult)
               testResult = (fitsValueList(rangelist, testlists) && fitsValueMod(rangelist, testlists));
         }
         return testResult;
      }

      ///   
      ///	 <summary> * fitsValueList - checks whether <code>rangelist</code> matches the
      ///	 * AllowedValueList/PresentValueList, specified for this State
      ///	 *  </summary>
      ///	 * <param name="rangelist">
      ///	 *            range list to test </param>
      ///	 * <param name="valuelist">
      ///	 *            switches between AllowedValueList and PresentValueList
      ///	 *  </param>
      ///	 * <returns> boolean - true, if <code>rangelist</code> matches the valuelist
      ///	 *         or if AllowedValueList is not specified </returns>
      ///	 
      private bool fitsValueList(JDFIntegerRangeList rangelist, EnumFitsValue valuelist)
      {
         JDFIntegerRangeList list = null;
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
            JDFIntegerRange range = (JDFIntegerRange)rangelist[i];

            // if range looks like"0~-1" but no xdef, then we assume that
            // xdef=lastIntegerInList
            int lastInList = ((JDFIntegerRange)list[list.Count - 1]).Right;
            int leftInRange = range.Left;
            int rightInRange = range.Right;
            if (lastInList > 0 && ((rightInRange < 0 && Math.Abs(rightInRange) < lastInList) || (leftInRange < 0 && Math.Abs(leftInRange) < lastInList)))
            {
               range.setDef(lastInList);
            }
            if (!list.isPartOfRange(range))
               return false;
         }
         return true;
      }

      ///   
      ///	 <summary> * fitsValueMod - checks whether <code>rangelist</code> matches
      ///	 * AllowedValueMod/PresentValueMod, specified for this State
      ///	 *  </summary>
      ///	 * <param name="rangelist">
      ///	 *            range list to test </param>
      ///	 * <param name="valuemod">
      ///	 *            switches between AllowedValueMod and PresentValueMod.
      ///	 *  </param>
      ///	 * <returns> boolean - true, if <code>rangelist</code> matches the
      ///	 *         <code>valuemod</code> or if AllowedValueMod is not specified </returns>
      ///	 
      private bool fitsValueMod(JDFIntegerRangeList rangelist, EnumFitsValue valuemod)
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

         int divi = (int)(mod.X + 0.5); // X - the Modulo
         int shift = (int)(mod.Y + 0.5); // Y - offset of the
         // allowed/present value

         if (divi == 0) // ValueMod can't be "0 x"
            return false;

         JDFIntegerList v = rangelist.getIntegerList();
         int[] vi = v.getIntArray();
         int siz = vi.Length;
         for (int i = 0; i < siz; i++)
         {
            if ((((vi[i] % divi) - shift) % divi) != 0)
               return false;
         }
         return true;
      }

      ///   
      ///	 <summary> * fitsCompleteList - tests whether <code>value</code> matches the given
      ///	 * testlist (ListType=CompleteList)
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <param name="list">
      ///	 *            testlist, either AllowedValueList or PresentValueList.
      ///	 *  </param>
      ///	 * <returns> boolean - true, if <code>value</code> matches the testlist </returns>
      ///	 
      private bool fitsCompleteList(JDFIntegerRangeList @value, JDFIntegerRangeList list)
      {
         int v_size = @value.Count;
         int l_size = list.Count;

         if (v_size != l_size)
            return false;

         if (!@value.isUnique())
            return false;

         JDFIntegerRangeList valueList = new JDFIntegerRangeList(@value);

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
      private bool fitsCompleteOrderedList(JDFIntegerRangeList @value, JDFIntegerRangeList list)
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
      ///	 * <returns> boolean - true, if <code>value</code> matches the testlist </returns>
      ///	 
      private bool fitsContainedList(JDFIntegerRangeList @value, JDFIntegerRangeList list)
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
         return EnumTerm.IntegerEvaluation;
      }
   }
}
