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
 * JDFRectangleState.cs
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
   using JDFRectangle = org.cip4.jdflib.datatypes.JDFRectangle;
   using JDFRectangleRange = org.cip4.jdflib.datatypes.JDFRectangleRange;
   using JDFRectangleRangeList = org.cip4.jdflib.datatypes.JDFRectangleRangeList;
   using EnumTerm = org.cip4.jdflib.resource.devicecapability.JDFTerm.EnumTerm;
   using EnumFitsValue = org.cip4.jdflib.datatypes.EnumFitsValue;
   using JDFBaseDataTypes_Fields = org.cip4.jdflib.datatypes.JDFBaseDataTypes_Fields;

   public class JDFRectangleState : JDFAbstractState
   {
      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[6];
      static JDFRectangleState()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ALLOWEDHWRELATION, 0x33333311, AttributeInfo.EnumAttributeType.XYRelation, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.ALLOWEDVALUELIST, 0x33333311, AttributeInfo.EnumAttributeType.RectangleRangeList, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.CURRENTVALUE, 0x33333311, AttributeInfo.EnumAttributeType.rectangle, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.DEFAULTVALUE, 0x33333311, AttributeInfo.EnumAttributeType.rectangle, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.PRESENTHWRELATION, 0x33333311, AttributeInfo.EnumAttributeType.XYRelation, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.PRESENTVALUELIST, 0x33333311, AttributeInfo.EnumAttributeType.RectangleRangeList, null, null);
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
      ///	 <summary> * constructor for JDFRectangleState
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFRectangleState(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * constructor for JDFRectangleState
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFRectangleState(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * constructor for JDFRectangleState
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFRectangleState(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
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
         return "JDFRectangleState[ --> " + base.ToString() + " ]";
      }

      //   
      //	 * // Attribute getter / setter
      //	 

      public virtual void setCurrentValue(JDFRectangle @value)
      {
         setAttribute(AttributeName.CURRENTVALUE, @value.ToString(), null);
      }

      public virtual JDFRectangle getCurrentValue()
      {
         try
         {
            JDFRectangle r = new JDFRectangle(getAttribute(AttributeName.CURRENTVALUE));
            return r;
         }
         catch (FormatException)
         {
            throw new JDFException("JDFRectangleState.getCurrentValue: Attribute CURRENTVALUE is not capable to create JDFRectangle");
         }
      }

      public virtual void setDefaultValue(JDFRectangle @value)
      {
         setAttribute(AttributeName.DEFAULTVALUE, @value.ToString(), null);
      }

      public virtual JDFRectangle getDefaultValue()
      {
         try
         {
            return new JDFRectangle(getAttribute(AttributeName.DEFAULTVALUE));
         }
         catch (FormatException)
         {
            throw new JDFException("JDFRectangleState.getDefaultValue: Attribute DEFAULTVALUE is not capable to create JDFRectangle");
         }
      }

      public virtual void setAllowedValueList(JDFRectangleRangeList @value)
      {
         setAttribute(AttributeName.ALLOWEDVALUELIST, @value.ToString());
      }

      public virtual JDFRectangleRangeList getAllowedValueList()
      {
         try
         {
            string attribute = getAttribute(AttributeName.ALLOWEDVALUELIST, null, null);
            return attribute == null ? null : new JDFRectangleRangeList(attribute);
         }
         catch (FormatException)
         {
            throw new JDFException("JDFRectangleState.getAllowedValueList: Attribute ALLOWEDVALUELIST is not capable to create JDFRectangleRangeList");
         }
      }

      public virtual void setPresentValueList(JDFRectangleRangeList @value)
      {
         setAttribute(AttributeName.PRESENTVALUELIST, @value.ToString());
      }

      public virtual JDFRectangleRangeList getPresentValueList()
      {
         if (hasAttribute(AttributeName.PRESENTVALUELIST))
         {
            try
            {
               return new JDFRectangleRangeList(getAttribute(AttributeName.PRESENTVALUELIST));
            }
            catch (FormatException)
            {
               throw new JDFException("JDFRectangleState.getPresentValueList: Attribute PRESENTVALUELIST is not capable to create JDFRectangleRangeList");
            }
         }
         return getAllowedValueList();
      }

      public virtual void setAllowedHWRelation(EnumXYRelation @value)
      {
         setAttribute(AttributeName.ALLOWEDHWRELATION, @value.getName(), null);
      }

      public virtual JDFElement.EnumXYRelation getAllowedHWRelation()
      {
         return JDFElement.EnumXYRelation.getEnum(getAttribute(AttributeName.ALLOWEDHWRELATION, null, null));
      }

      public virtual void setPresentHWRelation(EnumXYRelation @value)
      {
         setAttribute(AttributeName.PRESENTHWRELATION, @value.getName(), null);
      }

      public virtual JDFElement.EnumXYRelation getPresentHWRelation()
      {
         JDFElement.EnumXYRelation rel = JDFElement.EnumXYRelation.getEnum(getAttribute(AttributeName.PRESENTHWRELATION, null, null));

         if (rel == null)
         {
            return getAllowedHWRelation();
         }
         return rel;
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

         JDFRectangle rect;
         try
         {
            rect = new JDFRectangle(@value);
         }
         catch (FormatException)
         {
            return; // nop for bad values
         }
         if (testlists == null || EnumFitsValue.Allowed.Equals(testlists))
         {
            JDFRectangleRangeList list = getAllowedValueList();
            if (list == null)
               list = new JDFRectangleRangeList();
            list.Append(rect);
            setAllowedValueList(list);
         }
         if (testlists == null || EnumFitsValue.Present.Equals(testlists))
         {
            JDFRectangleRangeList list = getPresentValueList();
            if (list == null || !hasAttribute(AttributeName.PRESENTVALUELIST))
               list = new JDFRectangleRangeList();
            list.Append(rect);
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
      ///	 *            lists are ValueList and HWRelation.<br>
      ///	 *            Choose one of two values: FitsValue_Allowed or
      ///	 *            FitsValue_Present. (Defaults to Allowed)
      ///	 *  </param>
      ///	 * <returns> boolean - true, if <code>value</code> matches testlists or if
      ///	 *         AllowedValueList and AllowedValueMod are not specified </returns>
      ///	 
      public sealed override bool fitsValue(string @value, EnumFitsValue testlists)
      {
         if (fitsListType(@value))
         {
            JDFRectangleRangeList rrl = null;
            try
            {
               rrl = new JDFRectangleRangeList(@value);
            }
            catch (FormatException)
            {
               return false;
            }

            int siz = rrl.Count;
            for (int i = 0; i < siz; i++) // For every range, that rangelist
            // consists of,
            { // we test both of range deliminators - right and left, if they
               // fit HWRelation
               // In this case test of deliminators is sufficient for
               // evaluation of the whole range
               JDFRectangleRange range = (JDFRectangleRange)rrl[i];

               JDFRectangle left = range.Left;
               JDFRectangle right = range.Right;

               bool bFitsHW;
               if (left.Equals(right))
               {
                  bFitsHW = fitsHWRelation(left, testlists);
               }
               else
               {
                  bFitsHW = fitsHWRelation(left, testlists) && fitsHWRelation(right, testlists);
               }
               if (!bFitsHW)
                  return false;
            }
            return fitsValueList(rrl, testlists); // if we are here bFitsHW is
            // true, test ValueList
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
      private bool fitsValueList(JDFRectangleRangeList rangelist, EnumFitsValue valuelist)
      {
         JDFRectangleRangeList list;
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
            JDFRectangleRange range = (JDFRectangleRange)rangelist[i];

            if (!list.isPartOfRange(range))
               return false;
         }
         return true;
      }

      ///   
      ///	 <summary> * fitsHWRelation - checks whether <code>rect</code> matches the
      ///	 * AllowedHWRelation/PresentHWRelation specified for this State
      ///	 *  </summary>
      ///	 * <param name="rect">
      ///	 *            rectangle value to test </param>
      ///	 * <param name="hwrelation">
      ///	 *            Switches between AllowedHWRelation and PresentHWRelation. </param>
      ///	 * <returns> boolean - true, if <code>rect</code> matches hwrelation or if
      ///	 *         AllowedHWRelation is not specified </returns>
      ///	 
      private bool fitsHWRelation(JDFRectangle rect, EnumFitsValue hwrelation)
      {
         EnumXYRelation relation;

         if (hwrelation.Equals(EnumFitsValue.Allowed))
         {
            relation = getAllowedHWRelation();
         }
         else
         {
            relation = getPresentHWRelation();
         }

         if (relation == null)
            return true;

         double width = rect.Urx - rect.Llx;
         double height = rect.Ury - rect.Lly;

         return relation.evaluateXY(width, height, JDFBaseDataTypes_Fields.EPSILON, JDFBaseDataTypes_Fields.EPSILON);
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
      private bool fitsCompleteList(JDFRectangleRangeList @value, JDFRectangleRangeList list)
      {
         int v_size = @value.Count;
         int l_size = list.Count;

         if (v_size != l_size)
            return false;

         if (!@value.isUnique())
            return false;

         JDFRectangleRangeList valueList = new JDFRectangleRangeList(@value);

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
      private bool fitsCompleteOrderedList(JDFRectangleRangeList @value, JDFRectangleRangeList list)
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
      private bool fitsContainedList(JDFRectangleRangeList @value, JDFRectangleRangeList list)
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
         return EnumTerm.RectangleEvaluation;
      }
   }
}
