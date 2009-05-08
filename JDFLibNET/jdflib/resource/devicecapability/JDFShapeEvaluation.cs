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
 * JDFShapeEvaluation.cs
 */


namespace org.cip4.jdflib.resource.devicecapability
{
   using System;



   using EnumListType = org.cip4.jdflib.auto.JDFAutoBasicPreflightTest.EnumListType;
   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFNumberRange = org.cip4.jdflib.datatypes.JDFNumberRange;
   using JDFNumberRangeList = org.cip4.jdflib.datatypes.JDFNumberRangeList;
   using JDFShape = org.cip4.jdflib.datatypes.JDFShape;
   using JDFShapeRange = org.cip4.jdflib.datatypes.JDFShapeRange;
   using JDFShapeRangeList = org.cip4.jdflib.datatypes.JDFShapeRangeList;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;


   public class JDFShapeEvaluation : JDFEvaluation
   {
      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[5];
      static JDFShapeEvaluation()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.TOLERANCE, 0x33333333, AttributeInfo.EnumAttributeType.XYPair, null, "0 0");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.VALUELIST, 0x33333333, AttributeInfo.EnumAttributeType.ShapeRangeList, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.X, 0x33333333, AttributeInfo.EnumAttributeType.NumberRangeList, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.Y, 0x33333333, AttributeInfo.EnumAttributeType.NumberRangeList, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.Z, 0x33333333, AttributeInfo.EnumAttributeType.NumberRangeList, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }

      ///   
      ///	 <summary> * constructor for JDFShapeEvaluation
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFShapeEvaluation(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * constructor for JDFShapeEvaluation
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFShapeEvaluation(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * constructor for JDFShapeEvaluation
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>

      ///	 
      public JDFShapeEvaluation(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
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
         return "JDFShapeEvaluation[  --> " + base.ToString() + " ]";
      }

      //   
      //	 * // Attribute getter/ setter
      //	 

      public virtual void setValueList(JDFShapeRangeList @value)
      {
         setAttribute(AttributeName.VALUELIST, @value.ToString());
      }

      public virtual JDFShapeRangeList getValueList()
      {
         try
         {
            JDFShapeRangeList srl = new JDFShapeRangeList(getAttribute(AttributeName.VALUELIST));
            return srl;
         }
         catch (FormatException)
         {
            throw new JDFException("JDFShapeEvaluation.getValueList: Attribute VALUELIST is not capable to create JDFShapeRangeList");
         }
      }

      public virtual void setX(JDFNumberRangeList @value)
      {
         setAttribute(AttributeName.X, @value.ToString(), null);
      }

      public virtual JDFNumberRangeList getX()
      {
         try
         {
            JDFNumberRangeList nrl = new JDFNumberRangeList(getAttribute(AttributeName.X));
            return nrl;
         }
         catch (FormatException)
         {
            throw new JDFException("JDFShapeEvaluation.getX: Attribute X is not capable to create JDFNumberRangeList");
         }
      }

      public virtual void setY(JDFNumberRangeList @value)
      {
         setAttribute(AttributeName.Y, @value.ToString(), null);
      }

      public virtual JDFNumberRangeList getY()
      {
         try
         {
            JDFNumberRangeList nrl = new JDFNumberRangeList(getAttribute(AttributeName.Y));
            return nrl;
         }
         catch (FormatException)
         {
            throw new JDFException("JDFShapeEvaluation.getY: Attribute Y is not capable to create JDFNumberRangeList");
         }
      }

      public virtual void setZ(JDFNumberRangeList @value)
      {
         setAttribute(AttributeName.Z, @value.ToString(), null);
      }

      public virtual JDFNumberRangeList getZ()
      {
         try
         {
            JDFNumberRangeList nrl = new JDFNumberRangeList(getAttribute(AttributeName.Z));
            return nrl;
         }
         catch (FormatException)
         {
            throw new JDFException("JDFShapeEvaluation.getZ: Attribute Z is not capable to create JDFNumberRangeList");
         }
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

         JDFShapeRangeList rrl = null;
         try
         {
            rrl = new JDFShapeRangeList(@value);
         }
         catch (FormatException)
         {
            return false;
         }

         int siz = rrl.Count;
         for (int i = 0; i < siz; i++)
         {
            JDFShapeRange range = (JDFShapeRange)rrl[i];

            if ((fitsValueList(range) && fitsXYZ(range)) == false)
               return false;
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

         JDFShapeRangeList rangelist;
         try
         {
            rangelist = new JDFShapeRangeList(@value);
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
               new JDFShape(@value);
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
            throw new JDFException("JDFShapeEvaluation.fitsListType illegal ListType attribute");
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
      private bool fitsValueList(JDFShapeRange range)
      {
         if (!hasAttribute(AttributeName.VALUELIST))
            return true;

         JDFShapeRangeList rangelist = getValueList();

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
      private JDFShapeRangeList fitsTolerance(JDFShapeRangeList origRangeList)
      {
         double nt = getTolerance().X; // negative tolerance
         double pt = getTolerance().Y; // positive tolerance

         if ((nt == 0) && (pt == 0))
            return origRangeList;

         // expand our original range into the range +/- Tolerance

         JDFShapeRangeList rangeList = new JDFShapeRangeList(origRangeList);

         JDFShapeRangeList tolRangeList = new JDFShapeRangeList();

         int size = rangeList.Count;
         for (int i = 0; i < size; i++)
         {
            JDFShapeRange range = (JDFShapeRange)rangeList[i];

            JDFShape left = range.Left;
            double leftX = left.Y;
            double leftY = left.X;
            double leftZ = left.Z;
            left.Y = leftX - nt;
            left.X = leftY - nt;
            left.Z = leftZ - nt;

            JDFShape right = range.Right;
            double rightX = right.Y;
            double rightY = right.X;
            double rightZ = right.Z;
            right.Y = rightX + pt;
            right.X = rightY + pt;
            right.Z = rightZ + pt;

            range.Left = left;
            range.Right = right;

            tolRangeList.Append(range);
         }

         return tolRangeList;
      }

      ///   
      ///	 <summary> * fitsXYZ - checks wheterh <code>range</code> matches the test lists X, Y,
      ///	 * Z, specified for this Evaluation
      ///	 *  </summary>
      ///	 * <param name="range">
      ///	 *            range to test </param>
      ///	 * <returns> boolean - true, if <code>range</code> matches test lists X, Y, Z
      ///	 *         or if X, Y, Z are not specified </returns>
      ///	 
      private bool fitsXYZ(JDFShapeRange range)
      {
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

         x = getX();
         y = getY();
         z = getZ();

         if (hasAttribute(AttributeName.TOLERANCE))
         {
            x = fitsXYZTolerance(x);
            y = fitsXYZTolerance(y);
            z = fitsXYZTolerance(z);
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
         return bFit;

      }

      ///   
      ///	 <summary> * fitsXYZTolerance - checks whether this Evaluation has a specified
      ///	 * Tolerance that it is not equal "0 0", and expands the original rangelist
      ///	 * to the rangelist that fits the Tolerance.
      ///	 *  </summary>
      ///	 * <param name="rangeList">
      ///	 *            original rangelist </param>
      ///	 * <returns> JDFNumberRangeList - expanded rangelist, returns original range
      ///	 *         if Tolerance=="0 0" </returns>
      ///	 
      public virtual JDFNumberRangeList fitsXYZTolerance(JDFNumberRangeList origRangeList)
      {
         double nt = getTolerance().X; // negative tolerance
         double pt = getTolerance().Y; // positive tolerance

         if ((nt == 0) && (pt == 0))
            return origRangeList;

         // expand our original range into the range +/- Tolerance

         JDFNumberRangeList rangeList = new JDFNumberRangeList(origRangeList);

         JDFNumberRangeList tolRangeList = new JDFNumberRangeList();

         int size = rangeList.Count;
         for (int i = 0; i < size; i++)
         {
            JDFNumberRange range = (JDFNumberRange)rangeList[i];
            JDFNumberRange r = new JDFNumberRange();
            r.Left = range.Left - nt;
            r.Right = range.Right + pt;

            tolRangeList.Append(r);
         }
         return tolRangeList;
      }
   }
}
