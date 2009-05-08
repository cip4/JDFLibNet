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
 * JDFDurationRangeList.cs
 */

namespace org.cip4.jdflib.datatypes
{
   using System;
   using System.Collections;
   using System.Collections.Generic;


   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using VString = org.cip4.jdflib.core.VString;
   using JDFDuration = org.cip4.jdflib.util.JDFDuration;
   using StringUtil = org.cip4.jdflib.util.StringUtil;

   public class JDFDurationRangeList : JDFRangeList
   {

      // **************************************** Constructors
      // ****************************************

      ///   
      ///	 <summary> * empty constructor </summary>
      ///	 
      public JDFDurationRangeList()
         : base()
      {
      }

      ///   
      ///	 <summary> * constructs a JDFDurationRangeList from a given string
      ///	 *  </summary>
      ///	 * <param name="s"> the given string
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the String has not a valid format </exception>
      ///	 
      public JDFDurationRangeList(string s)
      {
         if (s != null && !s.Equals(JDFConstants.EMPTYSTRING))
         {
            setString(s);
         }
      }

      ///   
      ///	 <summary> * constructs a JDFDurationRangeList from the given JDFDurationRangeList
      ///	 *  </summary>
      ///	 * <param name="rl"> the given JDFDurationRangeList </param>
      ///	 
      public JDFDurationRangeList(JDFDurationRangeList rl)
      {
         rangeList = new ArrayList(rl.rangeList);
      }

      // **************************************** Methods
      // *********************************************

      ///   
      ///	 <summary> * inRange - returns true if the given JDFDuration value is in one of the ranges of the range list
      ///	 *  </summary>
      ///	 * <param name="x"> the given JDFDuration (duration) value to compare
      ///	 *  </param>
      ///	 * <returns> boolean - true if in range otherwise false </returns>
      ///	 
      public virtual bool inRange(JDFDuration x)
      {
         int sz = rangeList.Count;
         for (int i = 0; i < sz; i++)
         {
            JDFDurationRange r = (JDFDurationRange)rangeList[i];

            if (r.inRange(x))
            {
               return true;
            }
         }
         return false;
      }

      ///   
      ///	 <summary> * setString - parse the given string and set the duration range list
      ///	 *  </summary>
      ///	 * <param name="s"> the given string
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the String has not a valid format </exception>
      ///	 
      public virtual void setString(string s)
      {
         if (s.IndexOf(JDFConstants.TILDE) == 0 || s.LastIndexOf(JDFConstants.TILDE) == (s.Length - 1))
            throw new FormatException("JDFDurationRangeList::SetString: Illegal string " + s);
         string zappedWS = StringUtil.zappTokenWS(s, "~");
         VString v = new VString(StringUtil.tokenize(zappedWS, " \t", false));
         VString vs = new VString(v);
         rangeList.Clear();
         for (int i = 0; i < vs.Count; i++)
         {
            string str = vs[i];
            try
            {
               JDFDurationRange dr = new JDFDurationRange(str);
               rangeList.Add(dr);
            }
            catch (FormatException)
            {
               throw new FormatException("JDFDurationRangeList::SetString: Illegal string " + s);
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
            new JDFDurationRangeList(s);
         }
         catch (FormatException)
         {
            return false;
         }
         return true;
      }

      ///   
      ///	 <summary> * add a duration range r =rMin~rMax
      ///	 *  </summary>
      ///	 * <param name="r"> the Duration range to append to the list </param>
      ///	 
      public virtual void Append(JDFDurationRange r)
      {
         rangeList.Add(r);
      }

      ///   
      ///	 <summary> * add a duration range defined by two dates xMin~xMax
      ///	 *  </summary>
      ///	 * <param name="xMin"> the left value of the Duration range to append to the list </param>
      ///	 * <param name="xMax"> the right value of the Duration range to append to the list </param>
      ///	 
      public virtual void Append(JDFDuration xMin, JDFDuration xMax)
      {
         Append(new JDFDurationRange(xMin, xMax));
      }

      ///   
      ///	 <summary> * add an individual JDFDuration element
      ///	 *  </summary>
      ///	 * <param name="x"> the left and right value of the Duration range to append to the list </param>
      ///	 
      public virtual void Append(JDFDuration x)
      {
         Append(new JDFDurationRange(x, x));
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

         List<JDFDuration> v = new List<JDFDuration>(); // vector of ranges
         for (int i = 0; i < siz; i++)
         {
            JDFDurationRange r = (JDFDurationRange)rangeList[i];
            v.Add(r.Left);
            if (!r.Left.Equals(r.Right))
            {
               v.Add(r.Right);
            }
         }

         int n = v.Count - 1;
         if (n == 0)
            return true; // single value

         JDFDuration first = (v[0]);
         JDFDuration last = (v[n]);

         for (int j = 0; j < n; j++)
         {
            JDFDuration @value = (v[j]);
            JDFDuration nextvalue = (v[j + 1]);

            if (((first.Equals(last) && @value.Equals(nextvalue)) || (first.isShorter(last) && (@value.isShorter(nextvalue) || @value.Equals(nextvalue))) || (first.isLonger(last) && (@value.isLonger(nextvalue) || @value.Equals(nextvalue)))) == false)
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

         List<JDFDuration> v = new List<JDFDuration>(); // vector of ranges
         for (int i = 0; i < siz; i++)
         {
            JDFDurationRange r = (JDFDurationRange)rangeList[i];
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
         JDFDuration first = v[0];
         JDFDuration last = v[n];

         if (first.Equals(last))
         {
            return false;
         }
         for (int j = 0; j < n; j++)
         {
            JDFDuration @value = v[j];
            JDFDuration nextvalue = v[j + 1];

            if (((first.isShorter(last) && @value.isShorter(nextvalue)) || (first.isLonger(last) && @value.isLonger(nextvalue))) == false)
               return false;
         }
         return true;
      }
   }
}
