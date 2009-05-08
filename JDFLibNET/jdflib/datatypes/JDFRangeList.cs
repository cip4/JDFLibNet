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
 * THIS SOFTWARE IS PROVIDED ``AS IS'' AND ANY EXPRESSED OR IMPLIED
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
 * JDFRangeList.cs
 */

namespace org.cip4.jdflib.datatypes
{
   using System;
   using System.Collections;
   using System.Text;


   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using HashUtil = org.cip4.jdflib.util.HashUtil;

   ///
   /// <summary> * This abstract class is the representation of a range list. Intern these object are collected in a vector and there
   /// * are several methods to provide an access to the data. A range has the following format : "1~3.4" The class member
   /// * Vector rangeList contains for example "1~3.4" , "7~5" </summary>
   /// 
   public abstract class JDFRangeList : JDFBaseDataTypes
   {
      // **************************************** Constructors
      // ****************************************
      protected internal ArrayList rangeList = new ArrayList();

      // **************************************** Constructors
      // ****************************************
      ///   
      ///	 <summary> * constructor </summary>
      ///	 
      public JDFRangeList()
      {
         // default super constructor
      }

      // **************************************** Methods
      // *********************************************

      ///   
      ///	 <summary> * remove - removes an object from the vector
      ///	 *  </summary>
      ///	 * <param name="i"> the index of the element to remove </param>
      ///	 
      public void remove(int i)
      {
         rangeList.Remove(i);
      }

      ///   
      ///	 <summary> * isPartOfRange - check whether range 'x' is in the range defined by 'this'
      ///	 *  </summary>
      ///	 * <param name="x"> JDFRange to test </param>
      ///	 * <returns> boolean - true if 'x' is in the range defined by 'this' </returns>
      ///	 
      public bool isPartOfRange(JDFRange x)
      {
         int sz = rangeList.Count;
         for (int i = 0; i < sz; i++)
         {
            JDFRange r = (JDFRange)rangeList[i];

            if (r.isPartOfRange(x))
            {
               return true;
            }
         }
         return false;
      }

      ///   
      ///	 <summary> * isPartOfRange - check whether JDFRangeList 'x' is within this range list
      ///	 *  </summary>
      ///	 * <param name="x"> the range list to test </param>
      ///	 * <returns> boolean - true if range list 'x' is within 'this' range list, else false </returns>
      ///	 
      public bool isPartOfRange(JDFRangeList x)
      {
         int size = x.Count;
         for (int i = 0; i < size; i++)
         {
            JDFRange range = x[i];
            if (isPartOfRange(range))
               return true;
         }
         return false;
      }

      ///   
      ///	 <summary> * getString - serialize to string
      ///	 *  </summary>
      ///	 * <returns> String - a list of ranges in the format PT30M30S~PT35M (duration (JDFDate) has a
      ///	 *         format=P1Y2M3DT12H30M30S) </returns>
      ///	 * @deprecated 060418 use toString 
      ///	 
      [Obsolete("060418 use toString")]
      public string getString()
      {
         return ToString();
      }

      ///   
      ///	 <summary> * toString - serialize to string
      ///	 *  </summary>
      ///	 * <returns> String - a list of ranges in the format PT30M30S~PT35M (duration (JDFDuration) has a
      ///	 *         format=P1Y2M3DT12H30M30S) </returns>
      ///	 
      public override sealed string ToString()
      {
         int sz = rangeList.Count;
         StringBuilder s = new StringBuilder((sz + 1) * 16);
         for (int i = 0; i < sz; i++)
         {
            s.Append(rangeList[i].ToString());
            if (i < (sz - 1))
            {
               s.Append(JDFConstants.BLANK);
            }
         }
         return s.ToString();
      }

      ///   
      ///	 <summary> * number of Duration range elements
      ///	 *  </summary>
      ///	 * <returns> int - the number of Duration ranges in the list </returns>
      ///	 
      public int Count
      {
         get { return rangeList.Count; }
      }

      ///   
      ///	 <summary> * cleanup and empty the internal storge </summary>
      ///	 
      public void Clear()
      {
         rangeList.Clear();
      }

      ///   
      ///	 <summary> * at(i) - get the i-th range element
      ///	 *  </summary>
      ///	 * <param name="i"> index of the range to retrieve
      ///	 *  </param>
      ///	 * <returns> JDFRange - JDFDateTimeRange at the position i </returns>
      ///	 
      public JDFRange this[int index]
      {
         get
         {
            if ((index < 0) || (index >= rangeList.Count))
               throw new JDFException("JDFRangeList[i]: illegal index" + index);
            return (JDFRange)rangeList[index];
         }
      }

      ///   
      ///	 <summary> * begin() - returns the first JDFDateTimeRange of the JDFDateTimeRangeList
      ///	 *  </summary>
      ///	 * <returns> JDFRange: the first JDFDateTimeRange of the JDFDateTimeRangeList </returns>
      ///	 
      public JDFRange begin()
      {
         return (JDFRange)rangeList[0];
      }

      ///   
      ///	 <summary> * begin() - returns the last JDFDateTimeRange of the JDFDateTimeRangeList
      ///	 *  </summary>
      ///	 * <returns> JDFRange: the last JDFDateTimeRange of the JDFDateTimeRangeList </returns>
      ///	 
      public JDFRange end()
      {
         return (JDFRange)rangeList[rangeList.Count - 1];
      }

      ///   
      ///	 <summary> * erase(i) - Removes the i-th element of the range list
      ///	 *  </summary>
      ///	 * <param name="i"> index of element (range) to remove </param>
      ///	 
      public void erase(int i)
      {
         rangeList.RemoveAt(i);
      }

      ///   
      ///	 <summary> * isList - tests if 'this' is a List
      ///	 *  </summary>
      ///	 * <returns> boolean - true if 'this' contains no ranges </returns>
      ///	 
      public bool isList()
      {
         int sz = rangeList.Count;
         for (int i = 0; i < sz; i++)
         {
            JDFRange range = this[i];
            if (!range.getLeftObject().Equals(range.getRightObject()))
               return false;
         }
         return true; // if we are here 'this' is a List
      }

      ///   
      ///	 <summary> * equals - returns true if both JDFNumberRangeList are equal otherwise false
      ///	 *  </summary>
      ///	 * <returns> boolean - true if equal otherwise false </returns>
      ///	 
      public override sealed bool Equals(object other)
      {
         if (this == other)
         {
            return true;
         }
         if (other == null)
         {
            return false;
         }
         if (!other.GetType().Equals(this.GetType()))
         {
            return false;
         }

         int size = rangeList.Count;
         JDFRangeList rangeListOther = (JDFRangeList)other;
         int sizeOther = rangeListOther.rangeList.Count;
         if (size != sizeOther)
         {
            return false;
         }
         for (int i = 0; i < size; i++)
         {
            JDFRange range = this[i];
            JDFRange rangeOther = rangeListOther[i];

            if (!range.Equals(rangeOther))
            {
               return false;
            }
         }
         return true;

      }

      ///   
      ///	 <summary> * hashCode complements equals() to fulfill the equals/hashCode contract </summary>
      ///	 
      public override sealed int GetHashCode()
      {
         return HashUtil.GetHashCode(0, this.ToString());
      }

      ///   
      ///	 <summary> * isUniqueOrdered - tests if <code>this</this> has only unique values and if 
      ///	 * the values are ordered
      ///	 *  </summary>
      ///	 * <returns> true if values are unique and ordered, otherwise false </returns>
      ///	 
      public abstract bool isUniqueOrdered();

      ///   
      ///	 <summary> * isUnique - tests if 'this' has only unique values
      ///	 *  </summary>
      ///	 * <returns> boolean: true if 'this' is a unique range list </returns>
      ///	 
      public bool isUnique()
      {
         int sz = rangeList.Count;
         for (int i = 0; i < sz; i++)
         {
            JDFRange range = this[i];
            for (int j = 0; j < sz; j++)
            {
               if (j != i)
               {
                  JDFRange other = this[j];
                  // even if one of the range deliminators belongs to any
                  // other range - return false (range is not unique)
                  if ((other.inObjectRange(range.getLeftObject())) || (other.inObjectRange(range.getRightObject())))
                     return false;
               }
            }
         }
         return true;
      }

      public abstract bool isOrdered();

   }
}
