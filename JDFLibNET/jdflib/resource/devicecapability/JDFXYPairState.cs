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
 * Copyright (c) 2001 Heidelberger Druckmaschinen AG, All Rights Reserved.
 * 
 * @author Elena Skobchenko
 *
 * JDFXYPairState.cs
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
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFXYPairRange = org.cip4.jdflib.datatypes.JDFXYPairRange;
   using JDFXYPairRangeList = org.cip4.jdflib.datatypes.JDFXYPairRangeList;
   using EnumTerm = org.cip4.jdflib.resource.devicecapability.JDFTerm.EnumTerm;
   using EnumFitsValue = org.cip4.jdflib.datatypes.EnumFitsValue;
   using JDFBaseDataTypes_Fields = org.cip4.jdflib.datatypes.JDFBaseDataTypes_Fields;

   public class JDFXYPairState : JDFAbstractState
   {
      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[11];
      static JDFXYPairState()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ALLOWEDVALUELIST, 0x33333331, AttributeInfo.EnumAttributeType.XYPairRangeList, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.ALLOWEDVALUEMAX, 0x44444431, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.ALLOWEDVALUEMIN, 0x44444431, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.ALLOWEDXYRELATION, 0x33333311, AttributeInfo.EnumAttributeType.XYRelation, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.CURRENTVALUE, 0x33333331, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.DEFAULTVALUE, 0x33333331, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.PRESENTVALUELIST, 0x33333331, AttributeInfo.EnumAttributeType.XYPairRangeList, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.PRESENTVALUEMAX, 0x44444431, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.PRESENTVALUEMIN, 0x44444431, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.PRESENTXYRELATION, 0x33333311, AttributeInfo.EnumAttributeType.XYRelation, null, null);
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
      ///	 <summary> * constructor for JDFXYPairState
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFXYPairState(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * constructor for JDFXYPairState
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFXYPairState(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * constructor for JDFXYPairState
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFXYPairState(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      ///   
      ///	 <summary> * toString
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public override string ToString()
      {
         return "JDFXYPairState[ --> " + base.ToString() + " ]";
      }


      public virtual void setCurrentValue(JDFXYPair @value)
      {
         setAttribute(AttributeName.CURRENTVALUE, @value.ToString(), null);
      }

      public virtual JDFXYPair getCurrentValue()
      {
         try
         {
            return new JDFXYPair(getAttribute(AttributeName.CURRENTVALUE));
         }
         catch (FormatException)
         {
            throw new JDFException("JDFXYPairState.getCurrentValue: Attribute CURRENTVALUE is not capable to create JDFXYPair");
         }
      }

      public virtual void setDefaultValue(JDFXYPair @value)
      {
         setAttribute(AttributeName.DEFAULTVALUE, @value.ToString(), null);
      }

      public virtual JDFXYPair getDefaultValue()
      {
         try
         {
            return new JDFXYPair(getAttribute(AttributeName.DEFAULTVALUE));
         }
         catch (FormatException)
         {
            throw new JDFException("JDFXYPairState.getDefaultValue: Attribute DEFAULTVALUE is not capable to create JDFXYPair");
         }
      }

      //   
      //	 * // Attribute getter/ setter
      //	 

      public virtual void setAllowedValueList(JDFXYPairRangeList @value)
      {
         setAttribute(AttributeName.ALLOWEDVALUELIST, @value.ToString(), null);
      }

      public virtual JDFXYPairRangeList getAllowedValueList()
      {
         try
         {
            string attribute = getAttribute(AttributeName.ALLOWEDVALUELIST, null, null);
            return attribute == null ? null : new JDFXYPairRangeList(attribute);
         }
         catch (FormatException)
         {
            throw new JDFException("JDFXYPairState.getAllowedValueList: Attribute ALLOWEDVALUELIST is not applicable to create JDFXYPairRangeList");
         }
      }

      public virtual void setPresentValueList(JDFXYPairRangeList @value)
      {
         setAttribute(AttributeName.PRESENTVALUELIST, @value.ToString(), null);
      }

      public virtual JDFXYPairRangeList getPresentValueList()
      {
         if (hasAttribute(AttributeName.PRESENTVALUELIST))
         {
            try
            {
               return new JDFXYPairRangeList(getAttribute(AttributeName.PRESENTVALUELIST));
            }
            catch (FormatException)
            {
               throw new JDFException("JDFXYPairState.getPresentValueList: Attribute PRESENTVALUELIST is not applicable to create JDFXYPairRangeList");
            }
         }
         return getAllowedValueList();
      }

      public virtual void setAllowedValueMax(JDFXYPair @value)
      {
         setAttribute(AttributeName.ALLOWEDVALUEMAX, @value.ToString(), null);
      }

      public virtual JDFXYPair getAllowedValueMax()
      {
         try
         {
            return new JDFXYPair(getAttribute(AttributeName.ALLOWEDVALUEMAX));
         }
         catch (FormatException)
         {
            throw new JDFException("JDFXYPairState.getAllowedValueMax: Attribute ALLOWEDVALUEMAX is not applicable to create JDFXYPair");
         }
      }

      public virtual void setPresentValueMax(JDFXYPair @value)
      {
         setAttribute(AttributeName.PRESENTVALUEMAX, @value.ToString(), null);
      }

      public virtual JDFXYPair getPresentValueMax()
      {
         if (hasAttribute(AttributeName.PRESENTVALUEMAX))
         {
            try
            {
               return new JDFXYPair(getAttribute(AttributeName.PRESENTVALUEMAX));
            }
            catch (FormatException)
            {
               throw new JDFException("JDFXYPairState.setAllowedValueMin: Attribute PRESENTVALUEMAX is not applicable to create JDFXYPair");
            }
         }
         return getAllowedValueMax();
      }

      public virtual void setAllowedValueMin(JDFXYPair @value)
      {
         setAttribute(AttributeName.ALLOWEDVALUEMIN, @value.ToString(), null);
      }

      public virtual JDFXYPair getAllowedValueMin()
      {
         try
         {
            return new JDFXYPair(getAttribute(AttributeName.ALLOWEDVALUEMIN));
         }
         catch (FormatException)
         {
            throw new JDFException("JDFXYPairState.setAllowedValueMin: Attribute ALLOWEDVALUEMIN is not applicable to create JDFXYPair");
         }
      }

      public virtual void setPresentValueMin(JDFXYPair @value)
      {
         setAttribute(AttributeName.PRESENTVALUEMIN, @value.ToString(), null);
      }

      public virtual JDFXYPair getPresentValueMin()
      {
         if (hasAttribute(AttributeName.PRESENTVALUEMIN))
         {

            try
            {
               return new JDFXYPair(getAttribute(AttributeName.PRESENTVALUEMIN));
            }
            catch (FormatException)
            {
               throw new JDFException("JDFXYPairState.getPresentValueMin: Attribute PRESENTVALUEMIN is not applicable to create JDFXYPair");
            }
         }
         return getAllowedValueMin();
      }

      public virtual void setAllowedXYRelation(EnumXYRelation @value)
      {
         setAttribute(AttributeName.ALLOWEDXYRELATION, @value.getName(), null);
      }

      public virtual JDFElement.EnumXYRelation getAllowedXYRelation()
      {
         return EnumXYRelation.getEnum(getAttribute(AttributeName.ALLOWEDXYRELATION, null, null));
      }

      public virtual void setPresentXYRelation(EnumXYRelation @value)
      {
         setAttribute(AttributeName.PRESENTXYRELATION, @value.getName(), null);
      }

      public virtual JDFElement.EnumXYRelation getPresentXYRelation()
      {
         // return EnumXYRelation.getEnum(getAttribute(
         // AttributeName.ALLOWEDXYRELATION, null,
         // EnumXYRelation.Unknown.getName()));
         JDFElement.EnumXYRelation avail = JDFElement.EnumXYRelation.getEnum(getAttribute(AttributeName.PRESENTXYRELATION, null, null));

         if (avail == null)
         {
            return getAllowedXYRelation();
         }

         return avail;
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

         JDFXYPair rect;
         try
         {
            rect = new JDFXYPair(@value);
         }
         catch (FormatException)
         {
            return; // nop for bad values
         }
         if (testlists == null || EnumFitsValue.Allowed.Equals(testlists))
         {
            JDFXYPairRangeList list = getAllowedValueList();
            if (list == null)
               list = new JDFXYPairRangeList();
            list.Append(rect);
            setAllowedValueList(list);
         }
         if (testlists == null || EnumFitsValue.Present.Equals(testlists))
         {
            JDFXYPairRangeList list = getPresentValueList();
            if (list == null || !hasAttribute(AttributeName.PRESENTVALUELIST))
               list = new JDFXYPairRangeList();
            list.Append(rect);
            setPresentValueList(list);
         }
      }

      ///   
      ///	 <summary> * fitsValue - checks whether <code>value</code> matches the Allowed/Present
      ///	 * test lists specified for this State. In this State the test lists are
      ///	 * ValueList AND XYRelation.
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <param name="valuelist">
      ///	 *            the test lists the value has to match.<br>
      ///	 *            Choose one of two values: FitsValue_Allowed and
      ///	 *            FitsValue_Present. (Defaults to Allowed)
      ///	 *  </param>
      ///	 * <returns> boolean - true, if the value is in the valuelist or if
      ///	 *         AllowedValueList is not specified </returns>
      ///	 
      public override bool fitsValue(string @value, EnumFitsValue testlists)
      {
         if (!fitsListType(@value))
            return false;

         JDFXYPairRangeList rangelist = null;
         try
         {
            rangelist = new JDFXYPairRangeList(@value);
         }
         catch (FormatException)
         {
            return false;
         }

         int siz = rangelist.Count;
         for (int i = 0; i < siz; i++) // For every range, that rangelist
         // consists of,
         { // we test both of range deliminators - right and left, if they fit
            // XYRelation
            // In this case test of deliminators is sufficient for evaluation of
            // the whole range
            JDFXYPairRange range = (JDFXYPairRange)rangelist[i];

            JDFXYPair left = range.Left;
            JDFXYPair right = range.Right;

            bool bFitsXY;
            if (left.Equals(right))
            {
               bFitsXY = fitsXYRelation(left, testlists);
            }
            else
            {
               bFitsXY = fitsXYRelation(left, testlists) && fitsXYRelation(right, testlists);
            }
            if (!bFitsXY)
               return false;
         }

         return fitsValueList(rangelist, testlists); // if we are here bFitsXY is
         // true, test ValueList
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
      private bool fitsValueList(JDFXYPairRangeList rangelist, EnumFitsValue valuelist)
      {
         JDFXYPairRangeList list;
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
            JDFXYPairRange range = (JDFXYPairRange)rangelist[i];

            if (!list.isPartOfRange(range))
               return false;
         }
         return true;
      }

      ///   
      ///	 <summary> * fitsXYRelation - checks whether <code>xypair</code> value matches the
      ///	 * AllowedXYRelation/PresentXYRelation specified for this State
      ///	 *  </summary>
      ///	 * <param name="xypair">
      ///	 *            xypair to test </param>
      ///	 * <param name="xyrelation">
      ///	 *            switches between AllowedXYRelation and PresentXYRelation. </param>
      ///	 * <returns> boolean - true, if the <code>xypair</code> matches xyrelation or
      ///	 *         if AllowedXYRelation is not specified </returns>
      ///	 
      private bool fitsXYRelation(JDFXYPair xypair, EnumFitsValue xyrelation)
      {
         EnumXYRelation relation;

         if (xyrelation.Equals(EnumFitsValue.Allowed))
         {
            relation = getAllowedXYRelation();
         }
         else
         {
            relation = getPresentXYRelation();
         }

         if (relation == null)
            return true;

         double x = xypair.X;
         double y = xypair.Y;

         return relation.evaluateXY(x, y, JDFBaseDataTypes_Fields.EPSILON, JDFBaseDataTypes_Fields.EPSILON);
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
      private bool fitsCompleteList(JDFXYPairRangeList @value, JDFXYPairRangeList list)
      {
         int v_size = @value.Count;
         int l_size = list.Count;

         if (v_size != l_size)
            return false;

         if (!@value.isUnique())
            return false;

         JDFXYPairRangeList valueList = new JDFXYPairRangeList(@value);

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
      private bool fitsCompleteOrderedList(JDFXYPairRangeList @value, JDFXYPairRangeList list)
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
      ///	 * ValueList (ListType=ContainedList)
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <param name="list">
      ///	 *            ValueList </param>
      ///	 * <returns> boolean - true, if <code>value</code> matches the ValueList </returns>
      ///	 
      private bool fitsContainedList(JDFXYPairRangeList @value, JDFXYPairRangeList list)
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

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.ifaces.ICapabilityElement#getEvaluationType()
      //	 
      public override EnumTerm getEvaluationType()
      {
         return EnumTerm.XYPairEvaluation;
      }
   }
}
