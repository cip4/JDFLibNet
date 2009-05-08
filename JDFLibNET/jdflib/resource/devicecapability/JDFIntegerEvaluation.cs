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
 * JDFIntegerEvaluation.cs
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
   using JDFIntegerList = org.cip4.jdflib.datatypes.JDFIntegerList;
   using JDFIntegerRangeList = org.cip4.jdflib.datatypes.JDFIntegerRangeList;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using StringUtil = org.cip4.jdflib.util.StringUtil;

   public class JDFIntegerEvaluation : JDFEvaluation
   {
      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[2];
      static JDFIntegerEvaluation()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.VALUELIST, 0x33333333, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.VALUEMOD, 0x33333333, AttributeInfo.EnumAttributeType.XYPair, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }

      ///   
      ///	 <summary> * constructor for JDFIntegerEvaluation
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFIntegerEvaluation(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * constructor for JDFIntegerEvaluation
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFIntegerEvaluation(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * constructor for JDFIntegerEvaluation
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFIntegerEvaluation(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
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
         return "JDFIntegerEvaluation[ --> " + base.ToString() + " ]";
      }

      //   
      //	 * // Attribute getter/ setter
      //	 

      ///   
      ///	 <summary> * set attribute <code>ValueList</code>
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            the value to set the attribute to </param>
      ///	 
      public virtual void setValueList(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.VALUELIST, @value.ToString(), null);
      }

      ///   
      ///	 <summary> * append the value of int to @ValueList
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            the integer value to append </param>
      ///	 
      public virtual void appendValueList(int @value)
      {
         JDFIntegerRangeList irl = getValueList();
         irl.Append(@value);
         setValueList(irl);
      }

      ///   
      ///	 <summary> * get attribute <code>ValueList</code>
      ///	 *  </summary>
      ///	 * <returns> JDFIntegerRangeList - the value of the attribute </returns>
      ///	 
      public virtual JDFIntegerRangeList getValueList()
      {
         try
         {
            return new JDFIntegerRangeList(getAttribute(AttributeName.VALUELIST, null, JDFConstants.EMPTYSTRING));
         }
         catch (FormatException)
         {
            throw new JDFException("JDFIntegerEvaluation.getValueList: Unable to create JDFIntegerRangeList from Attribute value \"ValueList\"");
         }
      }

      ///   
      ///	 <summary> * set attribute <code>ValueMod</code>
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            the value to set the attribute to </param>
      ///	 
      public virtual void setValueMod(JDFXYPair @value)
      {
         setAttribute(AttributeName.VALUEMOD, @value.ToString());
      }

      ///   
      ///	 <summary> * get attribute ValueMod
      ///	 *  </summary>
      ///	 * <returns> JDFXYPair - the value of the attribute </returns>
      ///	 
      public virtual JDFXYPair getValueMod()
      {
         try
         {
            return new JDFXYPair(getAttribute(AttributeName.VALUEMOD));
         }
         catch (FormatException)
         {
            throw new JDFException("JDFIntegerEvaluation.getValueMod: The XYPair value is invalid!");
         }
      }

      //   
      //	 * // FitsValue Methods
      //	 

      ///   
      ///	 <summary> * fitsValue - tests if the defined 'value' matches testlists, specified for
      ///	 * this Evaluation
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <returns> boolean - true, if 'value' matches testlists or if testlists are
      ///	 *         not specified </returns>
      ///	 
      public override bool fitsValue(string @value)
      {
         if (fitsListType(@value))
         {
            JDFIntegerRangeList rangelist = null;
            try
            {
               rangelist = new JDFIntegerRangeList(@value);
            }
            catch (FormatException)
            {
               return false;
            }

            return (fitsValueList(rangelist) && fitsValueMod(rangelist));
         }
         return false; // the value doesn't fit ListType attribute of this
         // Evaluation
      }

      ///   
      ///	 <summary> * fitsListType - tests if the defined 'value' matches ListType attribute,
      ///	 * specified for this Evaluation
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <returns> boolean - true, if 'value' matches specified value of ListType </returns>
      ///	 
      private bool fitsListType(string @value)
      {
         EnumListType listType = getListType();

         JDFIntegerRangeList rangelist;
         try
         {
            rangelist = new JDFIntegerRangeList(@value);
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
            return (StringUtil.isInteger(@value));
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
            throw new JDFException("JDFIntegerEvaluation.fitsListType illegal ListType attribute");
         }
      }

      ///   
      ///	 <summary> * fitsValueList - tests if the defined 'rangelist' matches the ValueList,
      ///	 * specified for this Evaluation
      ///	 *  </summary>
      ///	 * <param name="rangelist">
      ///	 *            range list to test </param>
      ///	 * <returns> boolean - true, if 'rangelist' matches the ValueList or if
      ///	 *         ValueList is not specified </returns>
      ///	 
      private bool fitsValueList(JDFIntegerRangeList rangelist)
      {
         if (!hasAttribute(AttributeName.VALUELIST))
            return true;

         JDFIntegerRangeList valuelist = getValueList();

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

         int siz = rangelist.Count;
         for (int i = 0; i < siz; i++)
         {
            if (!valuelist.isPartOfRange(rangelist[i]))
               return false;
         }
         return true;
      }

      ///   
      ///	 <summary> * fitsValueMod - tests if the defined 'rangelist' matches the ValueMod,
      ///	 * specified for this Evaluation
      ///	 *  </summary>
      ///	 * <param name="rangelist">
      ///	 *            range list to test </param>
      ///	 * <returns> boolean - true, if 'rangelist' matches the ValueMod or if
      ///	 *         ValueMod is not specified </returns>
      ///	 
      private bool fitsValueMod(JDFIntegerRangeList rangelist)
      {
         if (!hasAttribute(AttributeName.VALUEMOD))
            return true;

         JDFXYPair mod = getValueMod();

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
      ///	 <summary> * fitsContainedList - tests for the case, when ListType=CompleteList, does
      ///	 * the defined 'value' match ValueList, specified for this Evaluation
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <param name="list">
      ///	 *            specified ValueList </param>
      ///	 * <returns> boolean - true, if 'value' matches testlist </returns>
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
      ///	 * given ValueList (ListType=CompleteOrderedList)
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <param name="list">
      ///	 *            specified ValueList </param>
      ///	 * <returns> boolean - true, if 'value' matches testlist </returns>
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
      ///	 * ValueList (ListType=ContainedList)
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <param name="list">
      ///	 *            specified ValueList </param>
      ///	 * <returns> boolean - true, if <code>value</code> matches testlist </returns>
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
   }
}
