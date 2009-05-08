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
 * JDFNumberEvaluation.cs
 */


namespace org.cip4.jdflib.resource.devicecapability
{
   using System;



   using EnumListType = org.cip4.jdflib.auto.JDFAutoBasicPreflightTest.EnumListType;
   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFNumberRange = org.cip4.jdflib.datatypes.JDFNumberRange;
   using JDFNumberRangeList = org.cip4.jdflib.datatypes.JDFNumberRangeList;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using StringUtil = org.cip4.jdflib.util.StringUtil;
   using JDFBaseDataTypes_Fields = org.cip4.jdflib.datatypes.JDFBaseDataTypes_Fields;

   public class JDFNumberEvaluation : JDFEvaluation
   {
      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[3];
      static JDFNumberEvaluation()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.TOLERANCE, 0x33333333, AttributeInfo.EnumAttributeType.XYPair, null, "0 0");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.VALUELIST, 0x33333333, AttributeInfo.EnumAttributeType.NumberRangeList, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.VALUEMOD, 0x33333333, AttributeInfo.EnumAttributeType.XYPair, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }

      ///   
      ///	 <summary> * constructor for JDFNumberEvaluation
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFNumberEvaluation(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * constructor for JDFNumberEvaluation
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFNumberEvaluation(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * constructor for JDFNumberEvaluation
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFNumberEvaluation(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
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
         return "JDFNumberEvaluation[ --> " + base.ToString() + " ]";
      }

      //   
      //	 * // Attribute getter/ setter
      //	 

      public virtual void setValueList(JDFNumberRangeList @value)
      {
         setAttribute(AttributeName.VALUELIST, @value.ToString(), null);
      }

      public virtual JDFNumberRangeList getValueList()
      {
         try
         {
            return new JDFNumberRangeList(getAttribute(AttributeName.VALUELIST, JDFConstants.EMPTYSTRING, null));

         }
         catch (FormatException)
         {
            throw new JDFException("JDFNumberEvaluation.setValueList: Attribute VALUELIST not applicable to create a JDFNumberRangeList");
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

      public virtual void setValueMod(JDFXYPair @value)
      {
         setAttribute(AttributeName.VALUEMOD, @value.ToString(), null);
      }

      public virtual JDFXYPair getValueMod()
      {
         try
         {
            return new JDFXYPair(getAttribute(AttributeName.VALUEMOD));
         }
         catch (FormatException)
         {
            throw new JDFException("JDFNumberEvaluation.setValueMod: Attribute AllowedValueMod is not applicable to create JDFXYPair");
         }
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
            return false;

         JDFNumberRangeList rangelist = null;
         try
         {
            rangelist = new JDFNumberRangeList(@value);
         }
         catch (FormatException)
         {
            return false;
         }

         int siz = rangelist.Count;
         for (int i = 0; i < siz; i++)
         {
            if (!fitsValueMod((JDFNumberRange)rangelist[i]))
               return false;
         }
         return (fitsValueList(rangelist));

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

         JDFNumberRangeList rangelist;
         try
         {
            rangelist = new JDFNumberRangeList(@value);
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
            return (StringUtil.isNumber(@value));
         }
         else if (listType.Equals(EnumListType.RangeList) || listType.Equals(EnumListType.Span))
         {
            return true;
         }
         // not -
         // tested in
         // fitsValueList
         // in
         // fitsValueList
         else if (listType.Equals(EnumListType.List) || listType.Equals(EnumListType.CompleteList) || listType.Equals(EnumListType.CompleteOrderedList) || listType.Equals(EnumListType.ContainedList)) // tested in
         // fitsValueList
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
            throw new JDFException("JDFNumberEvaluation.fitsListType illegal ListType attribute");
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
      private bool fitsValueList(JDFNumberRangeList rangelist)
      {
         if (!hasAttribute(AttributeName.VALUELIST))
            return true;

         JDFNumberRangeList valuelist = getValueList();

         EnumListType listType = getListType();

         if (listType.Equals(EnumListType.CompleteList))
         {
            return fitsCompleteList(rangelist, valuelist);
         }
         else if (listType.Equals(EnumListType.CompleteOrderedList))
         {
            return fitsCompleteOrderedList(rangelist, valuelist);
         }
         else if (listType.Equals(EnumListType.ContainedList))
         {
            return fitsContainedList(rangelist, valuelist);
         }

         if (hasAttribute(AttributeName.TOLERANCE))
         {
            valuelist = fitsTolerance(valuelist);
         }
         return (!valuelist.isPartOfRange(rangelist));

      }

      ///   
      ///	 <summary> * fitsValueMod - checks whether <code>range</code> matches the
      ///	 * <code>ValueMod</code> specified for this Evaluation. If ValueMod is
      ///	 * specified, only a single value can be tested, otherwise
      ///	 * <code>false</code> is returned.
      ///	 *  </summary>
      ///	 * <param name="range">
      ///	 *            range to test </param>
      ///	 * <returns> boolean - true, if <code>range</code> matches the ValueMod or if
      ///	 *         ValueMod is not specified </returns>
      ///	 
      private bool fitsValueMod(JDFNumberRange range)
      {
         if (!hasAttribute(AttributeName.VALUEMOD))
            return true;

         JDFXYPair mod = getValueMod();

         double left = range.Left;
         double right = range.Right;
         if (left != right) // if we have a range return false, check only single
            // value
            return false;

         double elem = left; // single value
         double divi = mod.X; // X - the Modulo
         double shift = mod.Y; // Y - offset of the allowed/present value

         if (divi == 0)
            return false;

         double nt; // negative tolerance
         double pt; // positive tolerance

         if (hasAttribute(AttributeName.TOLERANCE))
         {
            nt = getTolerance().X;
            pt = getTolerance().Y;
         }
         else
         {
            nt = pt = JDFBaseDataTypes_Fields.EPSILON;
         }

         double n = ((elem - divi * (int)(elem / divi)) - shift); // n = ( elem
         // % divi -
         // shift )
         if (Math.Abs(n) < pt || Math.Abs(n) > (divi - nt))
         {
            return true;
         }

         double m = (n - divi * (int)(n / divi)); // m = ( elem % divi - shift )
         // % divi
         if (Math.Abs(m) < pt || Math.Abs(m) > (divi - nt))
         {
            return true;
         }
         return false;
      }

      ///   
      ///	 <summary> * fitsTolerance - checks whether this Evaluation has a specified Tolerance
      ///	 * that it is not equal to "0 0", and expands original the rangelist to the
      ///	 * rangelist that fits Tolerance.
      ///	 *  </summary>
      ///	 * <param name="origRangeList">
      ///	 *            original rangelist </param>
      ///	 * <returns> NumberRangeList - expanded rangelist, returns original range if
      ///	 *         Tolerance=="0 0" </returns>
      ///	 
      public JDFNumberRangeList fitsTolerance(JDFNumberRangeList origRangeList)
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

      ///   
      ///	 <summary> * fitsCompleteList - tests whether <code>value</code> matches the given
      ///	 * ValueList (ListType=fitsCompleteList)
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <param name="list">
      ///	 *            ValueList </param>
      ///	 * <returns> boolean - true, if <code>value</code> matches the ValueList </returns>
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
      ///	 * given ValueList (ListType=CompleteOrderedList)
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <param name="list">
      ///	 *            ValueList </param>
      ///	 * <returns> boolean - true, if <code>value</code> matches the ValueList </returns>
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
      ///	 * ValueList (ListType=ContainedList)
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <param name="list">
      ///	 *            ValueList </param>
      ///	 * <returns> boolean - true, if <code>value</code> matches the ValueList </returns>
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
   }
}
