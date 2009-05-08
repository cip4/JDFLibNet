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
 * 
 * @author Elena Skobchenko
 * JDFIntegerRangeList.cs
 */

namespace org.cip4.jdflib.datatypes
{
   using System;
   using System.Collections;
   using System.Collections.Generic;

   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using VString = org.cip4.jdflib.core.VString;
   using StringUtil = org.cip4.jdflib.util.StringUtil;

   ///
   /// <summary> * This class is a representation of an integer range list (JDFIntegerRangeList). It is a whitespace separated list of
   /// * integer ranges, for example "12~15 19~33" </summary>
   /// 
   public class JDFIntegerRangeList : JDFRangeList
   {
      // **************************************** Attributes
      // ******************************************
      private int m_xDef = JDFIntegerRange.getDefaultDef();

      // **************************************** Constructors
      // ****************************************
      ///   
      ///	 <summary> * constructs an empty range list </summary>
      ///	 
      public JDFIntegerRangeList()
      {
         // default super constructor
      }

      ///   
      ///	 <summary> * constructs a JDFIntegerRangeList with the given string the default value for -1 is set to 0, i.e positive and
      ///	 * negative numbers are handled explicitly
      ///	 *  </summary>
      ///	 * <param name="s"> - the given string
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the String has not a valid format </exception>
      ///	 
      public JDFIntegerRangeList(string s)
         : this(s, JDFIntegerRange.getDefaultDef())
      {
      }

      ///   
      ///	 <summary> * constructs a JDFIntegerRangeList with the given String and sets the number of items
      ///	 *  </summary>
      ///	 * <param name="s"> - the given string </param>
      ///	 * <param name="xdef"> - the default value that
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the String has not a valid format </exception>
      ///	 
      public JDFIntegerRangeList(string s, int xdef)
      {
         setString(s);
         setDef(xdef);
      }

      ///   
      ///	 <summary> * constructs a JDFIntegerRangeList with the given JDFIntegerRangeList and sets the number of items
      ///	 *  </summary>
      ///	 * <param name="irl"> the given JDFIntegerRangeList </param>
      ///	 
      public JDFIntegerRangeList(JDFIntegerRangeList irl)
      {
         rangeList = new ArrayList(irl.rangeList);
         setDef(irl.getDef());
      }

      ///   
      ///	 <summary> * constructs a JDFIntegerRangeList with the given JDFIntegerRange and sets xDef
      ///	 *  </summary>
      ///	 * <param name="ir"> the given JDFIntegerRange </param>
      ///	 
      public JDFIntegerRangeList(JDFIntegerRange ir)
      {
         rangeList = new ArrayList();
         rangeList.Add(ir);
         setDef(ir.getDef());
      }

      // **************************************** Methods
      // *********************************************

      ///   
      ///	 <summary> * inRange - returns true if the given int value is in one of the ranges of the range list
      ///	 *  </summary>
      ///	 * <param name="x"> the given int value to compare
      ///	 *  </param>
      ///	 * <returns> boolean - true if in range otherwise false </returns>
      ///	 
      public virtual bool inRange(int x)
      {
         int sz = rangeList.Count;
         for (int i = 0; i < sz; i++)
         {
            JDFIntegerRange r = (JDFIntegerRange)rangeList[i];

            if (r.inRange(x))
            {
               return true;
            }
         }
         return false;
      }

      ///   
      ///	 <summary> * setString - parse the given string and set the integer ranges
      ///	 *  </summary>
      ///	 * <param name="s"> the given string
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the String has not a valid format </exception>
      ///	 
      public virtual void setString(string s)
      {
         rangeList.Clear();
         if (s == null || s.Equals(JDFConstants.EMPTYSTRING))
            return;
         if (s.IndexOf(JDFConstants.TILDE) == 0 || s.LastIndexOf(JDFConstants.TILDE) == (s.Length - 1))
            throw new FormatException("JDFIntegerRangeList::SetString: Illegal string " + s);
         string zappedWS = StringUtil.zappTokenWS(s, "~");
         VString vs = new VString(StringUtil.tokenize(zappedWS, " \t", false));
         for (int i = 0; i < vs.Count; i++)
         {
            string str = vs[i];
            try
            {
               JDFIntegerRange ir = new JDFIntegerRange(str);
               rangeList.Add(ir);
            }
            catch (FormatException)
            {
               throw new FormatException("JDFIntegerRangeList::SetString: Illegal string " + s);
            }
         }
      }

      ///   
      ///	 <summary> * isValid - validate the given String
      ///	 *  </summary>
      ///	 * <param name="s"> the given string
      ///	 *  </param>
      ///	 * <returns> boolean - false if the String has not a valid format </returns>
      ///	 
      public virtual bool isValid(string s)
      {
         try
         {
            new JDFIntegerRangeList(s);
         }
         catch (FormatException)
         {
            return false;
         }
         return true;
      }

      ///   
      ///	 <summary> * getElementCount - returns the number of elements in the list. On the C++ side of the JDF library this method is
      ///	 * called NElements. <br>
      ///	 * E.g. the following list has 14 elements: "1~5 10~15 20~22" if any if any range cannot be resolved due to an
      ///	 * unknown negative value without a known default, -1 is returned
      ///	 *  </summary>
      ///	 * <returns> int - the number of elements in this range, -1 if any range cannot be resolved </returns>
      ///	 
      public virtual int getElementCount()
      {
         int sz = rangeList.Count;
         int elementCount = 0;

         for (int i = 0; i < sz; i++)
         {
            JDFIntegerRange r = (JDFIntegerRange)rangeList[i];
            int elemCount = r.getElementCount();
            if (elemCount <= 0)
               return -1;
            elementCount += elemCount;
         }

         return elementCount;
      }

      ///   
      ///	 <summary> * Element - value of the ith element in the range. If the index is negative, the position is counted from the end
      ///	 * of the range.<br>
      ///	 * For example the range is 3~7, the 2nd element is 5 and the -2nd element is 6.
      ///	 * <p>
      ///	 * performace warning: don't loop over getElement for potentially large lists with many individual elements.<br>
      ///	 * Prefer to call getIntegerList() and loop over the list.
      ///	 *  </summary>
      ///	 * <param name="i"> the position, if it is a negative value start counting from the right side +1
      ///	 *  </param>
      ///	 * <returns> int - the value at the ith position
      ///	 *  </returns>
      ///	 * <exception cref="NoSuchElementException"> - if the index is out of range </exception>
      ///	 

      public virtual int getElement(int i)
      {
         int iLocal = i;

         int n = this.getElementCount();

         if ((iLocal >= n) || (iLocal < -n))
         {
            throw new IndexOutOfRangeException("JDFIntegerRangeList::Element out of range error!");
         }

         if (iLocal < 0)
         {
            return getElement(n + iLocal);
         }

         n = 0;

         for (int j = 0; j < rangeList.Count; j++)
         {
            JDFIntegerRange r = (JDFIntegerRange)rangeList[j];
            int k = r.getElementCount();
            if (iLocal >= k)
            {
               // go to next range
               iLocal -= k;
            }
            else
            {
               return r.getElement(iLocal);
            }
         }

         return 0;
      }

      ///   
      ///	 <summary> * append - appends a new IntegerRange to the IntegerRangeList
      ///	 *  </summary>
      ///	 * <param name="r"> the given JDFIntegerRange </param>
      ///	 
      public virtual void Append(JDFIntegerRange r)
      {
         r.setDef(getDef());
         rangeList.Add(r);
      }

      ///   
      ///	 <summary> * append - appends a new IntegerRange to the IntegerRangeList
      ///	 *  </summary>
      ///	 * <param name="xMin"> the left value of the new range </param>
      ///	 * <param name="xMax"> the right value of the new range </param>
      ///	 
      public virtual void Append(int xMin, int xMax)
      {
         this.Append(new JDFIntegerRange(xMin, xMax, m_xDef));
      }

      ///   
      ///	 <summary> * append - appends an integer to the last IntegerRange of the IntegerRangelist if possible, examples if the last
      ///	 * range list element looks like:
      ///	 * 
      ///	 * <pre>
      ///	 * &quot;3&tilde;5&quot;        append(6)   -&gt; &quot;3&tilde;6&quot;
      ///	 * &quot;5&quot;          append(6)   -&gt; &quot;5&tilde;6&quot;
      ///	 * &quot;5&quot;          append(7)   -&gt; &quot;5 7&quot;
      ///	 * &quot;5 6&quot;        append(7)   -&gt; &quot;5 &tilde; 7&quot;
      ///	 * &quot;3&tilde;7 5&tilde;7&quot;    append(8)   -&gt; &quot;3&tilde;7 5&tilde;8&quot;
      ///	 * &quot;3&tilde;7 5&tilde;9&quot;    append(8)   -&gt; &quot;3&tilde;7 5&tilde;9 8&quot;
      ///	 * &quot;3&tilde;7 5&tilde;7&quot;    append(18)  -&gt; &quot;3&tilde;7 5&tilde;7 18&quot;
      ///	 * </pre>
      ///	 * 
      ///	 * note that lists are not preserved. If you want to guarantee individual entries use append(x,x);
      ///	 *  </summary>
      ///	 * <param name="x"> the given int x </param>
      ///	 
      public virtual void Append(int x)
      {
         ///      
         ///		 <summary> * only the last range list element, because its append </summary>
         ///		 
         if (rangeList != null && rangeList.Count > 0)
         {
            JDFIntegerRange r = (JDFIntegerRange)rangeList[rangeList.Count - 1];

            if (r.Append(x))
            {
               return;
            }
         }
         this.Append(new JDFIntegerRange(x, x, m_xDef));
      }

      ///   
      ///	 <summary> * getIntegerList - returns this integer range list as a JDFIntegerList
      ///	 *  </summary>
      ///	 * <returns> JDFIntegerList - the integer range list as a JDFIntegerList </returns>
      ///	 
      public virtual JDFIntegerList getIntegerList()
      {
         JDFIntegerList irl = new JDFIntegerList();

         for (int i = 0; i < rangeList.Count; i++)
         {
            JDFIntegerRange r = (JDFIntegerRange)rangeList[i];
            irl.addIntegerList(r.getIntegerList());
         }

         return irl;
      }

      ///   
      ///	 <summary> * setDef - sets xDef, the default value which is used for negative numbers<br>
      ///	 * if xdef==0 (the default), the neg numbers themselves are used<br>
      ///	 * the value represents the index that is one past the end of the list
      ///	 *  </summary>
      ///	 * <param name="xdef"> one above the value that -1 will represent in this range i.e. the value that -0, were it possible to
      ///	 *            specify, would represent </param>
      ///	 
      public virtual void setDef(int xdef)
      {
         m_xDef = xdef;
         for (int i = 0; i < rangeList.Count; i++)
            ((JDFIntegerRange)rangeList[i]).setDef(xdef);
      }

      ///   
      ///	 <summary> * getDef - gets xDef, the default value which is used for negative numbers
      ///	 *  </summary>
      ///	 * <returns> int - one above the value that -1 will represent in this range<br>
      ///	 *         i.e. the value that -0, were it possible to specify, would represent </returns>
      ///	 
      public virtual int getDef()
      {
         return m_xDef;
      }

      ///   
      ///	 <summary> * isOrdered - tests if 'this' is OrderedRangeList
      ///	 *  </summary>
      ///	 * <returns> boolean - true if 'this' is a OrdneredRangeList </returns>
      ///	 
      public override bool isOrdered()
      {
         int siz = rangeList.Count;
         if (siz == 0)
            return false; // attempt to operate on a null element

         List<int> v = new List<int>(); // vector of ranges
         for (int i = 0; i < siz; i++)
         {
            JDFIntegerRange r = (JDFIntegerRange)rangeList[i];
            v.Add(r.Left);
            if (r.Left != r.Right)
            {
               v.Add(r.Right);
            }
         }

         int n = v.Count - 1;
         if (n == 0)
            return true; // single value

         int first = (v[0]);
         int last = (v[n]);

         for (int j = 0; j < n; j++)
         {
            int @value = (v[j]);
            int nextvalue = (v[j + 1]);

            if (((first == last && @value == nextvalue) || (first < last && @value <= nextvalue) || (first > last && @value >= nextvalue)) == false)
               return false;
         }
         return true;
      }

      ///   
      ///	 <summary> * isUniqueOrdered - tests if 'this' is UniqueOrdered RangeList
      ///	 *  </summary>
      ///	 * <returns> boolean - true if 'this' is UniqueOrdered RangeList </returns>
      ///	 
      public override bool isUniqueOrdered()
      {

         int siz = rangeList.Count;
         if (siz == 0)
         {
            return false; // attempt to operate on a null element
         }

         List<int> v = new List<int>(); // vector of ranges
         for (int i = 0; i < siz; i++)
         {
            JDFIntegerRange r = (JDFIntegerRange)rangeList[i];
            v.Add(r.Left);
            //if (!new int(r.getLeft()).Equals(new int(r.getRight())))
            if (!(r.Left.Equals(r.Right)))
            {
               v.Add(r.Right); // (new int(r.getRight()));
            }
         }

         int n = v.Count - 1;
         if (n == 0)
         {
            return true; // single value
         }
         int first = (v[0]);
         int last = (v[n]);

         if (first == last)
         {
            return false;
         }
         for (int j = 0; j < n; j++)
         {
            int @value = (v[j]);
            int nextvalue = (v[j + 1]);

            if (((first < last && @value < nextvalue) || (first > last && @value < nextvalue)) == false)
               return false;
         }
         return true;
      }

      ///   
      ///	 <summary> * deepCopy - a deep copy of this JDFIntegerRangeList
      ///	 *  </summary>
      ///	 * <returns> JDFIntegerRangeList - this object </returns>
      ///	 
      public virtual JDFIntegerRangeList deepCopy()
      {
         JDFIntegerRangeList rl = new JDFIntegerRangeList();
         rl.setString(ToString());
         return rl;
      }

      ///   
      ///	 <summary> * isOverlapping
      ///	 *  </summary>
      ///	 * <param name="newRange"> the range to check, if is overlapping one of the ranges in the list
      ///	 *            <p>
      ///	 *            x: x.upper < y.lower,<br>
      ///	 *            z: z.lower > y.upper,<br>
      ///	 *            one of these situation, means there is no overlapping
      ///	 *  </param>
      ///	 * <param name="newRange"> </param>
      ///	 * <param name="oldRange"> the JDFRangeList removed from the RangeList, before check for overlap. If null, the oldRange is
      ///	 *            ignored
      ///	 *  </param>
      ///	 * <returns> boolean - true if there is an overlapping, otherwise false </returns>
      ///	 
      public virtual bool isOverlapping(JDFIntegerRange newRange, JDFIntegerRange oldRange)
      {
         ArrayList rangeListToCheck = rangeList;

         if (oldRange != null)
         {
            rangeListToCheck = (ArrayList)rangeList.Clone();
            rangeListToCheck.Remove(oldRange);
         }

         return checkOverlap(rangeListToCheck, newRange);
      }

      ///   
      ///	 <summary> * checkOverlap - checks if the newRange overlaps one of the JDFIntegerRanges in the rangeList
      ///	 *  </summary>
      ///	 * <param name="rangeList"> the JDFIntegerRanges to check for overlap </param>
      ///	 * <param name="newRange"> the JDFIntergeRange to check against
      ///	 *  </param>
      ///	 * <returns> boolean - true if overlapping otherwise false </returns>
      ///	 
      private bool checkOverlap(ArrayList vRangeList, JDFIntegerRange newRange)
      {
         int rangeLower = newRange.LowerValue;
         int rangeUpper = newRange.UpperValue;

         for (int i = 0; i < vRangeList.Count; i++)
         {
            JDFIntegerRange r = (JDFIntegerRange)vRangeList[i];

            if (((rangeUpper < r.LowerValue) || (rangeLower > r.UpperValue)) == false)
            {
               return true;
            }
         }

         return false;
      }

      ///   
      ///	 <summary> * normalize this range by removing any consecutive entries and creating ranges instead
      ///	 *  </summary>
      ///	 * <param name="bSort"> if true, sort the rangelist prior to normalizing
      ///	 *  </param>
      ///	 
      public virtual void normalize(bool bSort)
      {
         int[] l = getIntegerList().getIntArray();
         if (bSort)
            System.Array.Sort(l);

         Clear();
         int lSiz = l.Length;
         for (int i = 0; i < lSiz; i++)
         {
            Append(l[i]);
         }
      }
   }
}
