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
 * JDFShapeState.cs
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
   using JDFNumberRange = org.cip4.jdflib.datatypes.JDFNumberRange;
   using JDFNumberRangeList = org.cip4.jdflib.datatypes.JDFNumberRangeList;
   using JDFShape = org.cip4.jdflib.datatypes.JDFShape;
   using JDFShapeRange = org.cip4.jdflib.datatypes.JDFShapeRange;
   using JDFShapeRangeList = org.cip4.jdflib.datatypes.JDFShapeRangeList;
   using EnumTerm = org.cip4.jdflib.resource.devicecapability.JDFTerm.EnumTerm;
   using EnumFitsValue = org.cip4.jdflib.datatypes.EnumFitsValue;

   public class JDFShapeState : JDFAbstractState
   {
      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[14];
      static JDFShapeState()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ALLOWEDVALUELIST, 0x33333331, AttributeInfo.EnumAttributeType.ShapeRangeList, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.ALLOWEDVALUEMAX, 0x44444431, AttributeInfo.EnumAttributeType.shape, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.ALLOWEDVALUEMIN, 0x44444431, AttributeInfo.EnumAttributeType.shape, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.ALLOWEDX, 0x33333311, AttributeInfo.EnumAttributeType.NumberRangeList, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.ALLOWEDY, 0x33333311, AttributeInfo.EnumAttributeType.NumberRangeList, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.ALLOWEDZ, 0x33333311, AttributeInfo.EnumAttributeType.NumberRangeList, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.CURRENTVALUE, 0x33333331, AttributeInfo.EnumAttributeType.shape, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.DEFAULTVALUE, 0x33333331, AttributeInfo.EnumAttributeType.shape, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.PRESENTVALUELIST, 0x33333311, AttributeInfo.EnumAttributeType.ShapeRangeList, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.PRESENTVALUEMAX, 0x44444431, AttributeInfo.EnumAttributeType.shape, null, null);
         atrInfoTable[10] = new AtrInfoTable(AttributeName.PRESENTVALUEMIN, 0x44444431, AttributeInfo.EnumAttributeType.shape, null, null);
         atrInfoTable[11] = new AtrInfoTable(AttributeName.PRESENTX, 0x33333311, AttributeInfo.EnumAttributeType.NumberRangeList, null, null);
         atrInfoTable[12] = new AtrInfoTable(AttributeName.PRESENTY, 0x33333311, AttributeInfo.EnumAttributeType.NumberRangeList, null, null);
         atrInfoTable[13] = new AtrInfoTable(AttributeName.PRESENTZ, 0x33333311, AttributeInfo.EnumAttributeType.NumberRangeList, null, null);
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
      ///	 <summary> * constructor for JDFShapeState
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFShapeState(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * constructor for JDFShapeState
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFShapeState(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * constructor for JDFShapeState
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFShapeState(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
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
         return "JDFShapeState[  --> " + base.ToString() + " ]";
      }

      //   
      //	 * // Attribute getter/ setter
      //	 

      public virtual void setCurrentValue(JDFShape @value)
      {
         setAttribute(AttributeName.CURRENTVALUE, @value.ToString(), null);
      }

      public virtual JDFShape getCurrentValue()
      {
         try
         {
            return new JDFShape(getAttribute(AttributeName.CURRENTVALUE));
         }
         catch (FormatException)
         {
            throw new JDFException("JDFShapeState.getCurrentValue: Attribute CURRENTVALUE is not capable to create JDFShape");
         }
      }

      public virtual void setDefaultValue(JDFShape @value)
      {
         setAttribute(AttributeName.DEFAULTVALUE, @value.ToString(), null);
      }

      public virtual JDFShape getDefaultValue()
      {
         try
         {
            return new JDFShape(getAttribute(AttributeName.DEFAULTVALUE));
         }
         catch (FormatException)
         {
            throw new JDFException("JDFShapeState.getDefaultValue: Attribute DEFAULTVALUE is not capable to create JDFShape");
         }
      }

      public virtual void setAllowedValueList(JDFShapeRangeList @value)
      {
         setAttribute(AttributeName.ALLOWEDVALUELIST, @value.ToString());
      }

      public virtual JDFShapeRangeList getAllowedValueList()
      {
         try
         {
            string attribute = getAttribute(AttributeName.ALLOWEDVALUELIST, null, null);
            return attribute == null ? null : new JDFShapeRangeList(attribute);
         }
         catch (FormatException)
         {
            throw new JDFException("JDFShapeState.getAllowedValueList: Attribute ALLOWEDVALUELIST is not capable to create JDFShapeRangeList");
         }
      }

      public virtual void setPresentValueList(JDFShapeRangeList @value)
      {
         setAttribute(AttributeName.PRESENTVALUELIST, @value.ToString(), null);
      }

      public virtual JDFShapeRangeList getPresentValueList()
      {
         if (hasAttribute(AttributeName.PRESENTVALUELIST))
         {
            try
            {
               return new JDFShapeRangeList(getAttribute(AttributeName.PRESENTVALUELIST));
            }
            catch (FormatException)
            {
               throw new JDFException("JDFShapeState.getPresentValueList: Attribute PRESENTVALUELIST is not capable to create JDFShapeRangeList");
            }
         }
         return getAllowedValueList();
      }

      public virtual void setAllowedX(JDFNumberRangeList @value)
      {
         setAttribute(AttributeName.ALLOWEDX, @value.ToString(), null);
      }

      public virtual JDFNumberRangeList getAllowedX()
      {
         try
         {
            return new JDFNumberRangeList(getAttribute(AttributeName.ALLOWEDX));
         }
         catch (FormatException)
         {
            throw new JDFException("JDFShapeState.getAllowedX: Attribute ALLOWEDX is not capable to create JDFNumberRangeList");
         }
      }

      public virtual void setPresentX(JDFNumberRangeList @value)
      {
         setAttribute(AttributeName.PRESENTX, @value.ToString(), null);
      }

      public virtual JDFNumberRangeList getPresentX()
      {
         if (hasAttribute(AttributeName.PRESENTX))
         {
            try
            {
               return new JDFNumberRangeList(getAttribute(AttributeName.PRESENTX));
            }
            catch (FormatException)
            {
               throw new JDFException("JDFShapeState.getPresentX: Attribute PRESENTX is not capable to create JDFNumberRangeList");
            }
         }
         return getAllowedX();
      }

      public virtual void setAllowedY(JDFNumberRangeList @value)
      {
         setAttribute(AttributeName.ALLOWEDY, @value.ToString(), null);
      }

      public virtual JDFNumberRangeList getAllowedY()
      {
         try
         {
            return new JDFNumberRangeList(getAttribute(AttributeName.ALLOWEDY));
         }
         catch (FormatException)
         {
            throw new JDFException("JDFShapeState.getAllowedY: Attribute ALLOWEDY is not capable to create JDFNumberRangeList");
         }
      }

      public virtual void setPresentY(JDFNumberRangeList @value)
      {
         setAttribute(AttributeName.PRESENTY, @value.ToString(), null);
      }

      public virtual JDFNumberRangeList getPresentY()
      {
         if (hasAttribute(AttributeName.PRESENTY))
         {
            try
            {
               return new JDFNumberRangeList(getAttribute(AttributeName.PRESENTY));
            }
            catch (FormatException)
            {
               throw new JDFException("JDFShapeState.getPresentY: Attribute PRESENTY is not capable to create JDFNumberRangeList");
            }
         }
         return getAllowedY();
      }

      public virtual void setAllowedZ(JDFNumberRangeList @value)
      {
         setAttribute(AttributeName.ALLOWEDZ, @value.ToString(), null);
      }

      public virtual JDFNumberRangeList getAllowedZ()
      {
         try
         {
            return new JDFNumberRangeList(getAttribute(AttributeName.ALLOWEDZ));
         }
         catch (FormatException)
         {
            throw new JDFException("JDFShapeState.getAllowedZ: Attribute ALLOWEDZ is not capable to create JDFNumberRangeList");
         }
      }

      public virtual void setPresentZ(JDFNumberRangeList @value)
      {
         setAttribute(AttributeName.PRESENTZ, @value.ToString(), null);
      }

      public virtual JDFNumberRangeList getPresentZ()
      {
         if (hasAttribute(AttributeName.PRESENTZ))
         {
            try
            {
               return new JDFNumberRangeList(getAttribute(AttributeName.PRESENTZ));
            }
            catch (FormatException)
            {
               throw new JDFException("JDFShapeState.getPresentZ: Attribute PRESENTZ is not capable to create JDFNumberRangeList");
            }
         }
         return getAllowedZ();
      }

      public virtual void setAllowedValueMax(JDFShape @value)
      {
         setAttribute(AttributeName.ALLOWEDVALUEMAX, @value.ToString(), null);
      }

      public virtual JDFShape getAllowedValueMax()
      {
         try
         {
            return new JDFShape(getAttribute(AttributeName.ALLOWEDVALUEMAX));
         }
         catch (FormatException)
         {
            throw new JDFException("JDFShapeState.getAllowedValueMax: Attribute ALLOWEDVALUEMAX is not capable to create JDFShape");
         }
      }

      public virtual void setPresentValueMax(JDFShape @value)
      {
         setAttribute(AttributeName.PRESENTVALUEMAX, @value.ToString(), null);
      }

      public virtual JDFShape getPresentValueMax()
      {
         if (hasAttribute(AttributeName.PRESENTVALUEMAX))
         {
            try
            {
               return new JDFShape(getAttribute(AttributeName.PRESENTVALUEMAX));
            }
            catch (FormatException)
            {
               throw new JDFException("JDFShapeState.getPresentValueMax: Attribute PRESENTVALUEMAX is not capable to create JDFShape");
            }

         }
         return getAllowedValueMax();
      }

      public virtual void setAllowedValueMin(JDFShape @value)
      {
         setAttribute(AttributeName.ALLOWEDVALUEMIN, @value.ToString(), null);
      }

      public virtual JDFShape getAllowedValueMin()
      {
         try
         {
            return new JDFShape(getAttribute(AttributeName.ALLOWEDVALUEMIN));
         }
         catch (FormatException)
         {
            throw new JDFException("JDFShapeState.setAllowedValueMin: Attribute ALLOWEDVALUEMIN is not capable to create JDFShape");
         }
      }

      public virtual void setPresentValueMin(JDFShape @value)
      {
         setAttribute(AttributeName.PRESENTVALUEMIN, @value.ToString(), null);
      }

      public virtual JDFShape getPresentValueMin()
      {
         if (hasAttribute(AttributeName.PRESENTVALUEMIN))
         {
            try
            {
               return new JDFShape(getAttribute(AttributeName.PRESENTVALUEMIN));
            }
            catch (FormatException)
            {
               throw new JDFException("JDFShapeState.getPresentValueMin: Attribute PRESENTVALUEMIN is not capable to create JDFShape");
            }

         }
         return getAllowedValueMin();
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

         JDFShape rect;
         try
         {
            rect = new JDFShape(@value);
         }
         catch (FormatException)
         {
            return; // nop for bad values
         }
         if (testlists == null || EnumFitsValue.Allowed.Equals(testlists))
         {
            JDFShapeRangeList list = getAllowedValueList();
            if (list == null)
               list = new JDFShapeRangeList();
            list.Append(rect);
            setAllowedValueList(list);
         }
         if (testlists == null || EnumFitsValue.Present.Equals(testlists))
         {
            JDFShapeRangeList list = getPresentValueList();
            if (list == null || !hasAttribute(AttributeName.PRESENTVALUELIST))
               list = new JDFShapeRangeList();
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
      ///	 *            lists are ValueList AND ValueMod.<br>
      ///	 *            Choose one of two values: FitsValue_Allowed or
      ///	 *            FitsValue_Present. (Defaults to Allowed)
      ///	 *  </param>
      ///	 * <returns> boolean - true, if <code>value</code> matches testlists or if
      ///	 *         AllowedValueList and AllowedValueMod are not specified </returns>
      ///	 
      public override bool fitsValue(string @value, EnumFitsValue testlists)
      {
         if (!fitsListType(@value))
            return false;

         JDFShapeRangeList rangelist = null;
         try
         {
            rangelist = new JDFShapeRangeList(@value);
         }
         catch (FormatException)
         {
            return false;
         }

         return (fitsValueList(rangelist, testlists) && fitsXYZ(rangelist, testlists));

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
      private bool fitsValueList(JDFShapeRangeList rangelist, EnumFitsValue valuelist)
      {
         JDFShapeRangeList list;
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
            JDFShapeRange range = (JDFShapeRange)rangelist[i];

            if (!list.isPartOfRange(range))
               return false;
         }
         return true;
      }

      ///   
      ///	 <summary> * fitsXYZ - checks whether <code>rangelist</code> matches the (AllowedX,
      ///	 * AllowedY, AllowedZ) or (PresentX, PresentY, PresentZ) values specified
      ///	 * for this State
      ///	 *  </summary>
      ///	 * <param name="rangelist">
      ///	 *            range list to test </param>
      ///	 * <param name="xyzlist">
      ///	 *            switches between (AllowedX, AllowedY, AllowedZ) and (PresentX,
      ///	 *            PresentY, PresentZ). </param>
      ///	 * <returns> boolean - true, if the 'rangelist' matches xyzlist or if
      ///	 *         AllowedX, AllowedY, AllowedZ are not specified </returns>
      ///	 
      private bool fitsXYZ(JDFShapeRangeList rangelist, EnumFitsValue xyzlist)
      {
         int siz = rangelist.Count;
         for (int i = 0; i < siz; i++)
         {
            JDFShapeRange range = (JDFShapeRange)rangelist[i];

            JDFNumberRangeList x, y, z;

            JDFShape left = range.Left;
            JDFShape right = range.Right;

            double leftX = left.Y;
            double rightX = right.Y;
            JDFNumberRange rangeX = new JDFNumberRange(leftX, rightX);

            double leftY = left.X;
            double rightY = right.X;
            JDFNumberRange rangeY = new JDFNumberRange(leftY, rightY);

            double leftZ = left.Z;
            double rightZ = right.Z;
            JDFNumberRange rangeZ = new JDFNumberRange(leftZ, rightZ);

            if (xyzlist.Equals(EnumFitsValue.Allowed))
            {
               x = getAllowedX();
               y = getAllowedY();
               z = getAllowedZ();
            }
            else
            {
               x = getPresentX();
               y = getPresentY();
               z = getPresentZ();
            }

            bool bFit = true;
            if (x.Count != 0)
            {
               bFit = x.isPartOfRange(rangeX);
            }
            if (!bFit)
               return false;

            if (y.Count != 0)
            {
               bFit = y.isPartOfRange(rangeY);
            }
            if (!bFit)
               return false;

            if (z.Count != 0)
            {
               bFit = z.isPartOfRange(rangeZ);
            }
            if (!bFit)
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
      ///	 
      private bool fitsCompleteList(JDFShapeRangeList @value, JDFShapeRangeList list)
      {
         int v_size = @value.Count;
         int l_size = list.Count;

         if (v_size != l_size)
            return false;

         if (!@value.isUnique())
            return false;

         JDFShapeRangeList valueList = new JDFShapeRangeList(@value);

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
      private bool fitsCompleteOrderedList(JDFShapeRangeList @value, JDFShapeRangeList list)
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
      private bool fitsContainedList(JDFShapeRangeList @value, JDFShapeRangeList list)
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
