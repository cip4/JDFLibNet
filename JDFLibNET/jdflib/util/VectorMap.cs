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
 * VectorMap.cs
 * Last changes
 */

namespace org.cip4.jdflib.util
{
   using System.Collections.Generic;


   ///
   /// <summary> * HashMap of multiple elements utility class
   /// * 
   /// * @author Rainer Prosi </summary>
   /// * @param <key> the type used for the key </param>
   /// * @param <vectorObject> the type used for individual elements of each vector in the map
   /// *  </param>
   /// 
   public class VectorMap<key, vectorObject> : Dictionary<key, List<vectorObject>>
   {

      ///   
      ///	 <summary> *  </summary>
      ///	 
      private const long serialVersionUID = -2180413692846276265L;

      ///   
      ///	 <summary> * null constructor </summary>
      ///	 
      public VectorMap()
         : base()
      {
      }

      ///   
      ///	 <summary> * get the value for key </summary>
      ///	 * <param name="key"> the search key </param>
      ///	 * <param name="i"> the index in the vecor matching key; if <0 count from the back of the vector </param>
      ///	 * <returns> the matching vectorObject; null if the key does not exist or i is out of range </returns>
      ///	 
      public virtual vectorObject getOne(object key, int i)
      {
         int iLocal = i;

         List<vectorObject> c = this[(key)key];
         if (c == null)
            return default(vectorObject);

         int n = c.Count;
         if (iLocal < 0)
            iLocal = n + iLocal;

         if (iLocal < 0 || iLocal >= n)
            return default(vectorObject);

         return c[iLocal];
      }

      ///   
      ///	 <summary> * get the index of singleObject in the vector of key </summary>
      ///	 * <param name="key"> the key of the vector </param>
      ///	 * <param name="singleObject"> the object to search </param>
      ///	 * <returns> -2: no such key; -1: no value in key; else the index in the vexctor of key </returns>
      ///	 
      public virtual int getIndex(key key, vectorObject singleObject)
      {
         List<vectorObject> keyVector = this[key]; // get(key);
         if (keyVector == null)
            return -2;
         return keyVector.IndexOf(singleObject);
      }

      ///   
      ///	 <summary> * get the size of the vector for key </summary>
      ///	 * <param name="key"> the key of the vector </param>
      ///	 * <returns> the size of the vector for key, 0 if no key exists </returns>
      ///	 
      public virtual int size(key key)
      {
         List<vectorObject> c = this[key]; // get(key);
         if (c == null)
            return 0;
         return c.Count;
      }

      ///   
      ///	 <summary> * put the value for key, ensuring uniqueness </summary>
      ///	 * <param name="key"> the key of the vector </param>
      ///	 * <param name="val"> the vector element </param>
      ///	 
      public virtual void putOne(key key, vectorObject val)
      {
         List<vectorObject> v = this[key]; // get(key);
         if (v == null)
         {
            v = new List<vectorObject>();
            this.Add(key, v); // put(key, v);
         }
         if (!v.Contains(val))
            v.Add(val);
      }

      ///   
      ///	 <summary> * remove the value for key,also remove key if the vector is empty
      ///	 * </summary>
      ///	 * <param name="key"> the key of the vector </param>
      ///	 * <param name="val"> the vector element </param>
      ///	 
      public virtual void removeOne(key key, vectorObject val)
      {
         List<vectorObject> v = this[key]; // get(key);
         if (v != null)
         {
            v.Remove(val);
            if (v.Count == 0)
               Remove(key);
         }
      }

      ///   
      ///	 <summary> * replace the value for key, add if oldObj==null or is not there
      ///	 *  </summary>
      ///	 * <param name="key"> the key of the vector </param>
      ///	 * <param name="newObj"> the new object to set </param>
      ///	 * <param name="oldObj"> the old object to replace </param>
      ///	 
      public virtual void setOne(key key, vectorObject newObj, vectorObject oldObj)
      {

         List<vectorObject> v = this[key]; // get(key);
         if (v != null)
         {
            int i = v.IndexOf(oldObj);
            if (i < 0)
               putOne(key, newObj);
            else
               v[i] = newObj;
         }
         else
         {
            putOne(key, newObj);
         }
      }
   }
}
