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
 * JDFEvaluation.cs
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
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFXYPairRange = org.cip4.jdflib.datatypes.JDFXYPairRange;
   using JDFXYPairRangeList = org.cip4.jdflib.datatypes.JDFXYPairRangeList;
   using JDFBaseDataTypes_Fields = org.cip4.jdflib.datatypes.JDFBaseDataTypes_Fields;

   public class JDFXYPairEvaluation : JDFEvaluation
   {
      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[3];
      static JDFXYPairEvaluation()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.TOLERANCE, 0x33333333, AttributeInfo.EnumAttributeType.XYPair, null, "0 0");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.VALUELIST, 0x33333333, AttributeInfo.EnumAttributeType.XYPairRangeList, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.XYRELATION, 0x33333333, AttributeInfo.EnumAttributeType.XYRelation, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }

      ///   
      ///	 <summary> * constructor for JDFXYPairEvaluation
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFXYPairEvaluation(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * constructor for JDFXYPairEvaluation
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFXYPairEvaluation(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * constructor for JDFXYPairEvaluation
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFXYPairEvaluation(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
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
         return "JDFXYPairEvaluation[ --> " + base.ToString() + " ]";
      }

      //   
      //	 * // Attribute getter/ setter
      //	 

      public virtual void setValueList(JDFXYPairRangeList @value)
      {
         setAttribute(AttributeName.VALUELIST, @value.ToString(), null);
      }

      ///   
      ///	 <summary> * set the value list to exaxtly one value
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            the xypair to set valuelist to </param>
      ///	 
      public virtual void setValueList(JDFXYPair @value)
      {
         setAttribute(AttributeName.VALUELIST, @value.ToString(), null);
      }

      ///   
      ///	 <summary> * get attribute <code>ValueList</code>
      ///	 *  </summary>
      ///	 * <returns> JDFXYPairRangeList - the value of the attribute </returns>
      ///	 
      public virtual JDFXYPairRangeList getValueList()
      {
         try
         {
            string valuelist = getAttribute(AttributeName.VALUELIST, null, null);
            if (valuelist == null)
               return null;
            JDFXYPairRangeList xyprl = new JDFXYPairRangeList(valuelist);
            return xyprl;
         }
         catch (FormatException)
         {
            throw new JDFException("JDFXYPairEvaluation.getValueList: Attribute VALUELIST is not applicable to create JDFXYPairRangeList");
         }
      }

      public virtual void setXYRelation(EnumXYRelation @value)
      {
         setAttribute(AttributeName.XYRELATION, @value.getName(), null);
      }

      public virtual JDFElement.EnumXYRelation getXYRelation()
      {
         return EnumXYRelation.getEnum(getAttribute(AttributeName.XYRELATION, null, null));
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
      public override bool fitsValue(string @value)
      {
         if (!fitsListType(@value))
         {
            return false;
         }

         JDFXYPairRangeList rrl = null;
         try
         {
            rrl = new JDFXYPairRangeList(@value);
         }
         catch (FormatException)
         {
            return false;
         }

         int siz = rrl.Count;
         for (int i = 0; i < siz; i++) // For every range, that rangelist
         // consists of,
         { // we test both of range deliminators - right and left, if they fit
            // XYRelation
            // In this case test of deliminators is sufficient for evaluation of
            // the whole range
            JDFXYPairRange range = (JDFXYPairRange)rrl[i];

            JDFXYPair left = range.Left;
            JDFXYPair right = range.Right;

            if (left.Equals(right))
            {
               JDFXYPair xypair = left;
               if ((fitsValueList(new JDFXYPairRange(xypair)) && fitsXYRelation(xypair)) == false)
                  return false;
            }
            else
            {
               if ((fitsValueList(range) && fitsXYRelation(left) && fitsXYRelation(right)) == false)
                  return false;
            }
         }
         return true; // all elements of rangelist fit
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

         JDFXYPairRangeList rangelist;
         try
         {
            rangelist = new JDFXYPairRangeList(@value);
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
            try
            {
               new JDFXYPair(@value);
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
         else if (listType.Equals(EnumListType.RangeList) || listType.Equals(EnumListType.Span))
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
            throw new JDFException("JDFXYPairEvaluation.fitsListType illegal ListType attribute");
         }
      }

      ///   
      ///	 <summary> * fitsValueList - checks whether <code>rangelist</code> matches the
      ///	 * AllowedValueList or the PresentValueList specified for this Evaluation
      ///	 *  </summary>
      ///	 * <param name="rangelist">
      ///	 *            nmtokens to test </param>
      ///	 * <returns> boolean - true, if <code>value</code> matches
      ///	 *         <code>valuelist</code> or if AllowedValueList is not specified </returns>
      ///	 
      private bool fitsValueList(JDFXYPairRange range)
      {
         if (!hasAttribute(AttributeName.VALUELIST))
            return true;

         JDFXYPairRangeList rangelist = getValueList();

         if (hasAttribute(AttributeName.TOLERANCE))
            return (fitsTolerance(rangelist).isPartOfRange(range));
         return rangelist.isPartOfRange(range);
      }

      ///   
      ///	 <summary> * fitsTolerance - checks whether this Evaluation has a specified Tolerance
      ///	 * that it is not equal to "0 0", and expands the original rangelist to the
      ///	 * rangelist that fits Tolerance.
      ///	 *  </summary>
      ///	 * <param name="origRangeList">
      ///	 *            original rangelist </param>
      ///	 * <returns> NumberRangeList - expanded rangelist, returns original range if
      ///	 *         Tolerance=="0 0" </returns>
      ///	 
      private JDFXYPairRangeList fitsTolerance(JDFXYPairRangeList origRangeList)
      {
         JDFXYPair tolerance = getTolerance();
         double nt = tolerance.X; // negative tolerance
         double pt = tolerance.Y; // positive tolerance

         if ((nt == 0) && (pt == 0))
            return origRangeList;

         // expand our original range into the range +/- Tolerance

         JDFXYPairRangeList rangeList = new JDFXYPairRangeList(origRangeList);

         JDFXYPairRangeList tolRangeList = new JDFXYPairRangeList();

         int size = rangeList.Count;
         for (int i = 0; i < size; i++)
         {
            JDFXYPairRange range = (JDFXYPairRange)rangeList[i];

            JDFXYPair left = range.Left;
            double leftX = left.X;
            double leftY = left.Y;
            left.X = leftX - nt;
            left.Y = leftY - nt;

            JDFXYPair right = range.Right;
            double rightX = right.X;
            double rightY = right.Y;
            right.X = rightX + pt;
            right.Y = rightY + pt;

            range.Left = left;
            range.Right = right;

            tolRangeList.Append(range);
         }

         return tolRangeList;
      }

      ///   
      ///	 <summary> * fitsXYRelation - checks whether <code>xypair</code>matches the XYRelation
      ///	 * specified for this State
      ///	 *  </summary>
      ///	 * <param name="xypair">
      ///	 *            XYPair value to test </param>
      ///	 * <returns> boolean - true, if <code>xypair</code> matches XYRelation or if
      ///	 *         XYRelation is not specified </returns>
      ///	 
      private bool fitsXYRelation(JDFXYPair xypair)
      {
         if (!hasAttribute(AttributeName.XYRELATION))
            return true;

         double x = xypair.X;
         double y = xypair.Y;

         EnumXYRelation relation = getXYRelation();

         if (!hasAttribute(AttributeName.TOLERANCE))
            return relation.evaluateXY(x, y, JDFBaseDataTypes_Fields.EPSILON, JDFBaseDataTypes_Fields.EPSILON);

         double nt = getTolerance().X; // negative tolerance
         double pt = getTolerance().Y; // positive tolerance

         return relation.evaluateXY(x, y, nt, pt);
      }
   }
}
