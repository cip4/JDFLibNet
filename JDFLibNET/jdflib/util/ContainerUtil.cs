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
 * ContainerUtil.cs
 * Last changes
 */

namespace org.cip4.jdflib.util
{
   using System;
   using System.Collections.Generic;


   using IMatches = org.cip4.jdflib.ifaces.IMatches;

   ///
   /// <summary> * class with utilities for containers, e.g. Vectors, sets etc. also simple object utils
   /// * 
   /// * @author prosirai
   /// *  </summary>
   /// 
   public class ContainerUtil
   {
      ///   
      ///	 <summary> * create a HashSet from a List (Vector...) </summary>
      ///	 * @param <a> the data typeof the sets
      ///	 *  </param>
      ///	 * <param name="list"> </param>
      ///	 * <returns> a Set created from list </returns>
      ///	 
      public static SupportClass.SetSupport<a> toHashSet<a>(List<a> list)
      {
         if (list == null)
            return null;
         SupportClass.SetSupport<a> s = new SupportClass.HashSetSupport<a>();
         for (int i = 0; i < list.Count; i++)
            s.Add(list[i]);
         return s;
      }

      ///   
      ///	 <summary> * create a HashSet from an Array </summary>
      ///	 * @param <a> the data typeof the sets
      ///	 *  </param>
      ///	 * <param name="l"> </param>
      ///	 * <returns> a Set created from list </returns>
      ///	 
      public static SupportClass.SetSupport<a> toHashSet<a>(a[] l)
      {
         if (l == null)
            return null;
         SupportClass.SetSupport<a> s = new SupportClass.HashSetSupport<a>();
         for (int i = 0; i < l.Length; i++)
            s.Add(l[i]);
         return s;
      }

      ///   
      ///	 <summary> * create a Vector from an Array </summary>
      ///	 * @param <a> 
      ///	 *  </param>
      ///	 * <param name="l"> </param>
      ///	 * <returns> a Vector<a> </returns>
      ///	 
      public static List<a> toVector<a>(a[] l)
      {
         if (l == null)
            return null;
         List<a> v = new List<a>();
         v.Capacity = l.Length;
         for (int i = 0; i < l.Length; i++)
            v.Add(l[i]);
         return v;
      }

      ///   
      ///	 <summary> * return a matching element from a collection of Imatches </summary>
      ///	 * @param <a> the data type
      ///	 *  </param>
      ///	 * <param name="c"> the collection to search </param>
      ///	 * <param name="obj"> the search key for matches </param>
      ///	 * <param name="iSkip"> which one to grab, may be negative in which case we count -1=last, -2=second last... </param>
      ///	 * <returns> the matching <a> </returns>
      ///	 
      public static IMatches getMatch<a, T1>(ICollection<T1> c, a obj, int iSkip) where T1 : IMatches
      {
         int iSkipLocal = iSkip;

         if (c == null)
            return null;

         if (iSkipLocal < 0)
         {
            List<IMatches> v = getMatches(c, obj);
            if (v == null)
               return null;

            iSkipLocal = v.Count + iSkipLocal;
            if (iSkipLocal < 0)
               return null;

            return v[iSkipLocal];
         }

         IEnumerator<T1> it = c.GetEnumerator();
         while (it.MoveNext())
         {
            IMatches m = it.Current;
            if (m.matches(obj) && iSkipLocal-- <= 0)
               return m;
         }

         return null;
      }

      ///   
      ///	 <summary> * return a matching element from a collection of IMatches </summary>
      ///	 * @param <a> the data type
      ///	 *  </param>
      ///	 * <param name="c"> the collection to search </param>
      ///	 * <param name="obj"> the search key for matches </param>
      ///	 * <returns> Vector of matching a </returns>
      ///	 
      public static List<IMatches> getMatches<a, T1>(ICollection<T1> c, a obj) where T1 : IMatches
      {
         if (c == null)
            return null;
         IEnumerator<T1> it = c.GetEnumerator();
         List<IMatches> v = new List<IMatches>();
         while (it.MoveNext())
         {
            IMatches m = it.Current;
            if (m.matches(obj))
               v.Add(m);
         }
         return v.Count == 0 ? null : v;
      }

      ///   
      ///	 <summary> * create a Vector of entry values from a map
      ///	 *  </summary>
      ///	 * <param name="m"> the map to dump to an array  </param>
      ///	 * <param name="sortByKey"> , if true, sort the entries by key
      ///	 *  </param>
      ///	 * <returns> the vector </returns>
      ///	 
      public static List<b> toValueVector<a, b>(IDictionary<a, b> m, bool sortByKey) where a : IComparable<a>
      {
         if (!sortByKey)
            return toValueVector(m);

         if (m == null)
            return null;

         lock (m)
         {
            if (m.Count == 0)
               return null;

            List<b> v = new List<b>(m.Count);
            List<a> keys = new List<a>(m.Count);

            IEnumerator<a> it = m.Keys.GetEnumerator();
            while (it.MoveNext())
            {
               a key = it.Current;
               if (key != null)
                  keys.Add(key);
            }

            keys.Sort();
            for (int i = 0; i < keys.Count; i++)
            {
               v.Add(m[keys[i]]);
            }
            return v;
         }
      }

      ///   
      ///	 <summary> * create a Vector of entry values from a map </summary>
      ///	 * @param <a> data type of the map key </param>
      ///	 * @param <b> data type of the map value
      ///	 *  </param>
      ///	 * <param name="m"> the map to dump to an array 
      ///	 *  </param>
      ///	 * <returns> the vector </returns>
      ///	 
      public static List<b> toValueVector<a, b>(IDictionary<a, b> m)
      {
         if (m == null)
            return null;

         lock (m)
         {
            if (m.Count == 0)
               return null;

            List<b> v = new List<b>(m.Count);

            IEnumerator<a> it = m.Keys.GetEnumerator();
            while (it.MoveNext())
               v.Add(m[it.Current]);

            return v;
         }
      }

      ///   
      ///	 <summary> * return true if a equals b or both are null
      ///	 *  </summary>
      ///	 * <param name="a"> Object to compare </param>
      ///	 * <param name="b"> Object to compare </param>
      ///	 * <returns> boolean true if a equals b or both are null </returns>
      ///	 
      public static new bool Equals(object a, object b)
      {
         if (a == null)
            return b == null;
         if (b == null)
            return false;
         return a.Equals(b);
      }

      ///   
      ///	 <summary> * static implementation of compare for any comparable object that gracefully handles null
      ///	 * null is always the smallest </summary>
      ///	 * <param name="c0">  </param>
      ///	 * <param name="c1"> </param>
      ///	 * <returns> -1 if c0<c1, 0 if equal, 1 if c0>c1 </returns>
      ///	 
      public static int compare(IComparable c0, IComparable c1)
      {
         if (c0 == null)
            return c1 == null ? 0 : 1;
         if (c1 == null)
            return -1;
         return c0.CompareTo(c1);
      }
   }
}
