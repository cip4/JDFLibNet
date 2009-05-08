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



/* Copyright (c) 2001 Heidelberger Druckmaschinen AG, All Rights Reserved.
 * 
 * @author Elena Skobchenko
 * JDFRectangleRangeList.cs
 */


namespace org.cip4.jdflib.datatypes
{
   using System;
   using System.Collections;
   using System.Collections.Generic;
   using System.Text;


   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using VString = org.cip4.jdflib.core.VString;
   using StringUtil = org.cip4.jdflib.util.StringUtil;

   public class JDFRectangleRangeList : JDFRangeList
   {

      ///   
      ///	 <summary> * empty constructor </summary>
      ///	 
      public JDFRectangleRangeList()
      {
         // default super constructor
      }

      ///   
      ///	 <summary> * copy constructor<br>
      ///	 * constructs a JDFRectangleRangeList with the given JDFRectangleRangeList
      ///	 *  </summary>
      ///	 * <param name="rl"> </param>
      ///	 
      public JDFRectangleRangeList(JDFRectangleRangeList rl)
      {
         rangeList = new ArrayList(rl.rangeList);
      }

      ///   
      ///	 <summary> * constructs a JDFRectangleRangeList from a given string
      ///	 *  </summary>
      ///	 * <param name="s"> the given string
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the String has not a valid format </exception>
      ///	 
      public JDFRectangleRangeList(string s)
      {
         if (s != null && !s.Equals(JDFConstants.EMPTYSTRING))
         {
            setString(s);
         }
      }

      // **************************************** Methods
      // *********************************************

      ///   
      ///	 <summary> * inRange - check whether rectangle 'x' is in the rectangle range defined by 'this'
      ///	 *  </summary>
      ///	 * <param name="x"> rectangle value to test </param>
      ///	 * <returns> boolean - true if 'x' is in the range defined by 'this' </returns>
      ///	 
      public virtual bool inRange(JDFRectangle x)
      {
         int sz = rangeList.Count;
         for (int i = 0; i < sz; i++)
         {
            if (((JDFRectangleRange)rangeList[i]).inRange(x))
            {
               return true;
            }
         }
         return false;
      }

      ///   
      ///	 <summary> * setString - deserialize a string Reads the string, which represents JDFRectangleRangeList, and converts it into
      ///	 * real JDFRectangleRangeList
      ///	 *  </summary>
      ///	 * <param name="s"> string to read
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the String has not a valid format </exception>
      ///	 
      public virtual void setString(string s)
      {
         if (s.IndexOf(JDFConstants.TILDE) == 0 || s.LastIndexOf(JDFConstants.TILDE) == (s.Length - 1))
            throw new FormatException("JDFRectangleRangeList.setString: Illegal string " + s);
         string zappedWS = StringUtil.zappTokenWS(s, JDFConstants.TILDE); // converts
         // "0 0 1 1 ~ 0 0 4 4"
         // to
         // "0 0 1 1~0 0 4 4"
         VString vs = new VString(zappedWS, JDFConstants.BLANK);
         rangeList.Clear();
         for (int i = 0, size = vs.Count; i < size; i++)
         {
            if (size - i < JDFBaseDataTypes_Fields.MAX_RECTANGLE_DIMENSION) // the last Rectangle is
               // incomplete
               throw new FormatException("JDFRectangleRangeList.setString: Illegal string " + s);

            StringBuilder str = new StringBuilder(100);
            str.Append(vs[i]).Append(JDFConstants.BLANK).Append(vs[++i]).Append(JDFConstants.BLANK).Append(vs[++i]).Append(JDFConstants.BLANK);
            // the 4-th token 'tildeToken' can be with or without "~"
            string tildeToken = vs[++i];
            str.Append(tildeToken);
            if (tildeToken.IndexOf(JDFConstants.TILDE) != -1) // str -
            // JDFRectangleRange
            {
               if (size - i < JDFBaseDataTypes_Fields.MAX_RECTANGLE_DIMENSION) // the last
                  // RectangleRange is
                  // incomplete
                  throw new FormatException("JDFRectangleRangeList.setString: Illegal string " + s);

               str.Append(JDFConstants.BLANK).Append(vs[++i]).Append(JDFConstants.BLANK).Append(vs[++i]).Append(JDFConstants.BLANK).Append(vs[++i]);
            }
            try
            {
               JDFRectangleRange r = new JDFRectangleRange(str.ToString());
               rangeList.Add(r);
            }
            catch (FormatException)
            {
               throw new FormatException("JDFRectangleRangeList.setString: Illegal string " + s);
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
            new JDFRectangleRangeList(s);
         }
         catch (FormatException)
         {
            return false;
         }
         return true;
      }

      ///   
      ///	 <summary> * append - adds an element defined by a JDFRectangleRange
      ///	 *  </summary>
      ///	 * <param name="x"> the range to append to the list </param>
      ///	 
      public virtual void Append(JDFRectangleRange x)
      {
         rangeList.Add(x);
      }

      ///   
      ///	 <summary> * append - adds an individual JDFRectangle element
      ///	 *  </summary>
      ///	 * <param name="x"> the left and right value of the range to append to the list </param>
      ///	 
      public virtual void Append(JDFRectangle x)
      {
         Append(new JDFRectangleRange(x));
      }

      ///   
      ///	 <summary> * append - adds an element defined by two JDFRectangles xMin~xMax
      ///	 *  </summary>
      ///	 * <param name="xMin"> the left value of the range to append to the list </param>
      ///	 * <param name="xMax"> the right value of the range to append to the list </param>
      ///	 
      public virtual void Append(JDFRectangle xMin, JDFRectangle xMax)
      {
         Append(new JDFRectangleRange(xMin, xMax));
      }

      ///   
      ///	 <summary> * isOrdered - tests if 'this' is an OrderedRangeList
      ///	 *  </summary>
      ///	 * <returns> boolean - true if 'this' is a OrdneredRangeList </returns>
      ///	 
      public override bool isOrdered()
      {
         int siz = rangeList.Count;
         if (siz == 0)
            return false; // attempt to operate on a null element

         List<JDFRectangle> v = new List<JDFRectangle>(); // vector of ranges
         for (int i = 0; i < siz; i++)
         {
            JDFRectangleRange r = (JDFRectangleRange)rangeList[i];
            v.Add(r.Left);
            if (!r.Left.Equals(r.Right))
            {
               v.Add(r.Right);
            }
         }

         int n = v.Count - 1;
         if (n == 0)
            return true; // single value

         JDFRectangle first = (v[0]);
         JDFRectangle last = (v[n]);

         for (int j = 0; j < n; j++)
         {
            JDFRectangle @value = (v[j]);
            JDFRectangle nextvalue = (v[j + 1]);

            if (((first.Equals(last) && @value.Equals(nextvalue)) || (first.isLess(last) && @value.isLessOrEqual(nextvalue)) || (first.isGreater(last) && @value.isGreaterOrEqual(nextvalue))) == false)
               return false;
         }
         return true;
      }

      ///   
      ///	 <summary> * isUniqueOrdered - tests if 'this' is an UniqueOrdered RangeList
      ///	 *  </summary>
      ///	 * <returns> boolean - true if 'this' is an UniqueOrdered RangeList </returns>
      ///	 
      public override bool isUniqueOrdered()
      {

         int siz = rangeList.Count;
         if (siz == 0)
         {
            return false; // attempt to operate on a null element
         }

         List<JDFRectangle> v = new List<JDFRectangle>(); // vector of ranges
         for (int i = 0; i < siz; i++)
         {
            JDFRectangleRange r = (JDFRectangleRange)rangeList[i];
            v.Add(r.Left);
            if (!r.Left.Equals(r.Right))
            {
               v.Add(r.Right);
            }
         }

         int n = v.Count - 1;
         if (n == 0)
         {
            return true; // single value
         }
         JDFRectangle first = v[0];
         JDFRectangle last = v[n];

         if (first.Equals(last))
         {
            return false;
         }
         for (int j = 0; j < n; j++)
         {
            JDFRectangle @value = v[j];
            JDFRectangle nextvalue = v[j + 1];

            if (((first.isLess(last) && @value.isLess(nextvalue)) || (first.isGreater(last) && @value.isGreater(nextvalue))) == false)
               return false;
         }
         return true;
      }
   }
}
