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
 * JDFRectangleEvaluation.cs
 */


namespace org.cip4.jdflib.resource.devicecapability
{
   using System;



   using EnumListType = org.cip4.jdflib.auto.JDFAutoBasicPreflightTest.EnumListType;
   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFRectangle = org.cip4.jdflib.datatypes.JDFRectangle;
   using JDFRectangleRange = org.cip4.jdflib.datatypes.JDFRectangleRange;
   using JDFRectangleRangeList = org.cip4.jdflib.datatypes.JDFRectangleRangeList;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFBaseDataTypes_Fields = org.cip4.jdflib.datatypes.JDFBaseDataTypes_Fields;

   public class JDFRectangleEvaluation : JDFEvaluation
   {
      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[3];
      static JDFRectangleEvaluation()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.HWRELATION, 0x33333333, AttributeInfo.EnumAttributeType.XYRelation, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.TOLERANCE, 0x33333333, AttributeInfo.EnumAttributeType.XYPair, null, "0 0");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.VALUELIST, 0x33333333, AttributeInfo.EnumAttributeType.RectangleRangeList, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }

      ///   
      ///	 <summary> * JDFRectangleEvaluation
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFRectangleEvaluation(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * JDFRectangleEvaluation
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFRectangleEvaluation(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * JDFRectangleEvaluation
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFRectangleEvaluation(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
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
         return "JDFRectangleEvaluation[ --> " + base.ToString() + " ]";
      }

      //   
      //	 * // Attribute getter / setter
      //	 

      public virtual void setValueList(JDFRectangleRangeList @value)
      {
         setAttribute(AttributeName.VALUELIST, @value.ToString());
      }

      ///   
      ///	 <summary> * set valuelist to exactly one rectangle
      ///	 *  </summary>
      ///	 * <param name="value"> </param>
      ///	 
      public virtual void setValueList(JDFRectangle @value)
      {
         setAttribute(AttributeName.VALUELIST, @value.ToString());
      }

      ///   
      ///	 <summary> * 
      ///	 * @return </summary>
      ///	 
      public virtual JDFRectangleRangeList getValueList()
      {
         string vl = getAttribute(AttributeName.VALUELIST, null, null);
         if (vl == null)
            return null;

         try
         {
            return new JDFRectangleRangeList(vl);
         }
         catch (FormatException)
         {
            throw new JDFException("JDFRectangleEvaluation.getValueList: Attribute VALUELIST is not capable to create JDFRectangleRangeList");
         }
      }

      public virtual void setHWRelation(EnumXYRelation @value)
      {
         setAttribute(AttributeName.HWRELATION, @value.getName(), null);
      }

      public virtual JDFElement.EnumXYRelation getHWRelation()
      {
         return JDFElement.EnumXYRelation.getEnum(getAttribute(AttributeName.HWRELATION, null, null));
      }

      public virtual void setTolerance(JDFXYPair @value)
      {
         setAttribute(AttributeName.TOLERANCE, @value.ToString(), null);
      }

      public override JDFXYPair getTolerance()
      {
         return base.getTolerance();
      }

      //   
      //	 * // FitsValue Methods
      //	 

      ///   
      ///	 <summary> * fitsValue - checks whether <code>value</code> matches the testlists
      ///	 * specified for this Evaluation
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <returns> boolean - true, if <code>value</code> matches the testlists or if
      ///	 *         testlists are not specified </returns>
      ///	 
      public sealed override bool fitsValue(string @value)
      {
         if (!fitsListType(@value))
            return false;

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
         { // we test both of range deliminators - right and left, if they fit
            // HWRelation
            // In this case test of deliminators is sufficient for evaluation of
            // the whole range
            JDFRectangleRange range = (JDFRectangleRange)rrl[i];

            JDFRectangle left = range.Left;
            JDFRectangle right = range.Right;

            if (left.Equals(right))
            {
               JDFRectangle rectangle = left;
               if ((fitsValueList(new JDFRectangleRange(rectangle)) && fitsHWRelation(rectangle)) == false)
                  return false;
            }
            else
            {
               if ((fitsValueList(range) && fitsHWRelation(left) && fitsHWRelation(right)) == false)
                  return false;
            }
         }
         return true;

      }

      ///   
      ///	 <summary> * fitsListType - checks whether <code>value</code> matches the value of the
      ///	 * ListType attribute specified for this Evaluation
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <returns> boolean - true, if <code>value</code> matches the specified value
      ///	 *         of ListType </returns>
      ///	 
      private bool fitsListType(string @value)
      {
         EnumListType listType = getListType();

         JDFRectangleRangeList rangelist;
         try
         {
            rangelist = new JDFRectangleRangeList(@value);
         }
         catch (FormatException)
         {
            return false;
         }
         catch (JDFException)
         {
            return false;
         }

         if (listType.Equals(EnumListType.SingleValue) || listType.Equals(EnumListType.getEnum(0)))
         { // default ListType = SingleValue
            try
            {
               new JDFRectangle(@value);
            }
            catch (JDFException)
            {
               return false;
            }
            catch (FormatException)
            {
               return false;
            }
            return true;
         }
         else if (listType.Equals(EnumListType.RangeList))
         {
            return true;
         }
         else if (listType.Equals(EnumListType.List))
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
            throw new JDFException("JDFRectangleEvaluation.fitsListType illegal ListType attribute");
         }
      }

      ///   
      ///	 <summary> * fitsValueList - checks whether <code>range</code> is in the ValueList
      ///	 * specified for this Evaluation
      ///	 *  </summary>
      ///	 * <param name="range">
      ///	 *            range to test </param>
      ///	 * <returns> boolean - true, if <code>range</code> is in the ValueList or if
      ///	 *         ValueList is not specified </returns>
      ///	 
      private bool fitsValueList(JDFRectangleRange range)
      {
         if (!hasAttribute(AttributeName.VALUELIST))
            return true;

         JDFRectangleRangeList rangelist = getValueList();

         if (hasAttribute(AttributeName.TOLERANCE))
            return (fitsTolerance(rangelist).isPartOfRange(range));
         return rangelist.isPartOfRange(range);

      }

      ///   
      ///	 <summary> * fitsTolerance - checks whether this Evaluation has a specified Tolerance
      ///	 * that it is not equal to "0 0", and expands original the rangelist to the
      ///	 * rangelist that fits Tolerance.
      ///	 *  </summary>
      ///	 * <param name="rangeList">
      ///	 *            original rangelist </param>
      ///	 * <returns> NumberRangeList - expanded rangelist, returns original range if
      ///	 *         Tolerance=="0 0" </returns>
      ///	 
      private JDFRectangleRangeList fitsTolerance(JDFRectangleRangeList origRangeList)
      {
         double nt = getTolerance().X; // negative tolerance
         double pt = getTolerance().Y; // positive tolerance

         if ((nt == 0) && (pt == 0))
         {
            return origRangeList;
         }

         // expand our original range into the range +/- Tolerance

         JDFRectangleRangeList rangeList = new JDFRectangleRangeList(origRangeList);

         JDFRectangleRangeList tolRangeList = new JDFRectangleRangeList();

         int size = rangeList.Count;
         for (int i = 0; i < size; i++)
         {
            JDFRectangleRange range = (JDFRectangleRange)rangeList[i];

            JDFRectangle left = range.Left;
            double leftLlx = left.Llx;
            double leftLly = left.Lly;
            double leftUrx = left.Urx;
            double leftUry = left.Ury;
            left.Llx = leftLlx - nt;
            left.Lly = leftLly - nt;
            left.Urx = leftUrx - nt;
            left.Ury = leftUry - nt;

            JDFRectangle right = range.Right;
            double rightLlx = right.Llx;
            double rightLly = right.Lly;
            double rightUrx = right.Urx;
            double rightUry = right.Ury;
            right.Llx = rightLlx + pt;
            right.Lly = rightLly + pt;
            right.Urx = rightUrx + pt;
            right.Ury = rightUry + pt;

            range.Left = left;
            range.Right = right;

            tolRangeList.Append(range);

         }
         return tolRangeList;

      }

      ///   
      ///	 <summary> * fitsHWRelation - checks whether <code>rect</code> value matches the
      ///	 * HWRelation specified for this Evaluation
      ///	 *  </summary>
      ///	 * <param name="rect">
      ///	 *            rectangle value to test </param>
      ///	 * <returns> boolean - true, if <code>rect</code> matches HWRelation or if
      ///	 *         HWRelation is not specified </returns>
      ///	 
      private bool fitsHWRelation(JDFRectangle rect)
      {
         double width = rect.Urx - rect.Llx;
         double height = rect.Ury - rect.Lly;

         if (!hasAttribute(AttributeName.HWRELATION))
            return true;
         if (!hasAttribute(AttributeName.TOLERANCE))
            return getHWRelation().evaluateXY(width, height, JDFBaseDataTypes_Fields.EPSILON, JDFBaseDataTypes_Fields.EPSILON);

         double nt = getTolerance().X; // negative tolerance
         double pt = getTolerance().Y; // positive tolerance

         return getHWRelation().evaluateXY(width, height, nt, pt);
      }
   }
}
