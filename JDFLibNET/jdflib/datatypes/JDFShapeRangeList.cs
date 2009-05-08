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
 * JDFShapeRangeList.cs */


namespace org.cip4.jdflib.datatypes
{
   using System;
   using System.Collections;
   using System.Collections.Generic;
   using System.Text;


   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using VString = org.cip4.jdflib.core.VString;
   using StringUtil = org.cip4.jdflib.util.StringUtil;

   public class JDFShapeRangeList : JDFRangeList
   {

      ///   
      ///	 <summary> * empty constructor </summary>
      ///	 
      public JDFShapeRangeList()
      {
         // default super constructor
      }

      ///   
      ///	 <summary> * copy constructor<br>
      ///	 * constructs a JDFShapeRangeList with the given JDFShapeRangeList
      ///	 *  </summary>
      ///	 * <param name="rl"> </param>
      ///	 
      public JDFShapeRangeList(JDFShapeRangeList rl)
      {
         rangeList = new ArrayList(rl.rangeList);
      }

      ///   
      ///	 <summary> * constructs a JDFShapeRangeList from the values of a given String
      ///	 *  </summary>
      ///	 * <param name="s"> the given String
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the String has not a valid format </exception>
      ///	 
      public JDFShapeRangeList(string s)
      {
         if (s != null && !s.Equals(JDFConstants.EMPTYSTRING))
         {
            setString(s);
         }
      }

      // **************************************** Methods
      // *********************************************

      ///   
      ///	 <summary> * inRange - check whether shape 'x' is in the shape range defined by 'this'
      ///	 *  </summary>
      ///	 * <param name="x"> shape value to test </param>
      ///	 * <returns> boolean - true if 'x' is in the range defined by 'this' </returns>
      ///	 
      public virtual bool inRange(JDFShape x)
      {
         int sz = rangeList.Count;
         for (int i = 0; i < sz; i++)
         {
            if (((JDFShapeRange)rangeList[i]).inRange(x))
            {
               return true;
            }
         }
         return false;
      }

      ///   
      ///	 <summary> * setString - deserialize a string Reads the string, which represents JDFShapeRangeList, and converts it into real
      ///	 * JDFShapeRangeList
      ///	 *  </summary>
      ///	 * <param name="s"> string to read
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the String has not a valid format </exception>
      ///	 
      public virtual void setString(string s)
      {
         if (s.IndexOf(JDFConstants.TILDE) == 0 || s.LastIndexOf(JDFConstants.TILDE) == (s.Length - 1))
            throw new FormatException("JDFShapeRangeList.setString: Illegal string " + s);
         string zappedWS = StringUtil.zappTokenWS(s, JDFConstants.TILDE);
         VString vs = new VString(zappedWS, JDFConstants.BLANK);
         rangeList.Clear();
         for (int i = 0, size = vs.Count; i < size; i++)
         {
            if (size - i < JDFBaseDataTypes_Fields.MAX_SHAPE_DIMENSION) // the last Shape is incomplete
               throw new FormatException("JDFShapeRangeList.setString: Illegal string " + s);

            StringBuilder str = new StringBuilder(100);
            str.Append(vs[i]).Append(JDFConstants.BLANK).Append(vs[++i]).Append(JDFConstants.BLANK);
            // the third token 'tildeToken' can be with or without "~"
            string tildeToken = vs[++i];
            str.Append(tildeToken);
            if (tildeToken.IndexOf(JDFConstants.TILDE) != -1) // str -
            // JDFShapeRange
            {
               if (size - i < JDFBaseDataTypes_Fields.MAX_SHAPE_DIMENSION) // the last ShapeRange is
                  // incomplete
                  throw new FormatException("JDFShapeRangeList.setString: Illegal string " + s);

               str.Append(JDFConstants.BLANK).Append(vs[++i]).Append(JDFConstants.BLANK).Append(vs[++i]);
            }
            try
            {
               JDFShapeRange r = new JDFShapeRange(str.ToString());
               rangeList.Add(r);
            }
            catch (FormatException)
            {
               throw new FormatException("JDFShapeRangeList.setString: Illegal string " + s);
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
            new JDFShapeRangeList(s);
         }
         catch (FormatException)
         {
            return false;
         }
         return true;
      }

      ///   
      ///	 <summary> * append - adds an element defined by a JDFShapeRange
      ///	 *  </summary>
      ///	 * <param name="x"> the range to append to the list </param>
      ///	 
      public virtual void Append(JDFShapeRange x)
      {
         rangeList.Add(x);
      }

      ///   
      ///	 <summary> * append - adds an individual JDFShape element
      ///	 *  </summary>
      ///	 * <param name="x"> the left and right value of the range to append to the list </param>
      ///	 
      public virtual void Append(JDFShape x)
      {
         Append(new JDFShapeRange(x));
      }

      ///   
      ///	 <summary> * append - adds an element defined by two JDFShapes: xMin~xMax
      ///	 *  </summary>
      ///	 * <param name="xMin"> the left value of the range to append to the list </param>
      ///	 * <param name="xMax"> the right value of the range to append to the list </param>
      ///	 
      public virtual void Append(JDFShape xMin, JDFShape xMax)
      {
         Append(new JDFShapeRange(xMin, xMax));
      }

      ///   
      ///	 <summary> * isOrdered - tests if 'this' is OrderedRangeList
      ///	 *  </summary>
      ///	 * <returns> boolean - true if 'this' is a OrdneredRangeList </returns>
      ///	 
      public override bool isOrdered()
      {
         int size = rangeList.Count;
         if (size == 0)
            return false; // attempt to operate on a null element

         ArrayList v = new ArrayList(); // vector of ranges
         for (int i = 0; i < size; i++)
         {
            JDFShapeRange r = (JDFShapeRange)rangeList[i];
            v.Add(r.Left);
            if (!r.Left.Equals(r.Right))
            {
               v.Add(r.Right);
            }
         }

         int n = v.Count - 1;
         if (n == 0)
            return true; // single value

         JDFShape first = (JDFShape)v[0];
         JDFShape last = (JDFShape)v[n];

         for (int j = 0; j < n; j++)
         {
            JDFShape @value = (JDFShape)v[j];
            JDFShape nextvalue = (JDFShape)v[j + 1];

            if (((first.Equals(last) && @value.Equals(nextvalue)) || (first.isLess(last) && @value.isLessOrEqual(nextvalue)) || (first.isGreater(last) && @value.isGreaterOrEqual(nextvalue))) == false)
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

         List<JDFShape> v = new List<JDFShape>(); // vector of ranges
         for (int i = 0; i < siz; i++)
         {
            JDFShapeRange r = (JDFShapeRange)rangeList[i];
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
         JDFShape first = v[0];
         JDFShape last = v[n];

         if (first.Equals(last))
         {
            return false;
         }
         for (int j = 0; j < n; j++)
         {
            JDFShape @value = v[j];
            JDFShape nextvalue = v[j + 1];

            if (((first.isLess(last) && @value.isLess(nextvalue)) || (first.isGreater(last) && @value.isGreater(nextvalue))) == false)
               return false;
         }
         return true;
      }
   }
}
