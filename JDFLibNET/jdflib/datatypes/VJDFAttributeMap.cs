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


/* 
 * The CIP4 Software License, Version 1.0
 *
 *
 * Copyright (c) 2001-2009 The International Cooperation for the Integration of Processes in
 * Prepress, Press and Postpress (CIP4). All rights reserved.
 * 
 * Redistribution and use in source and binary forms, with or without modification, are permitted
 * provided that the following conditions are met:
 * 
 * 1. Redistributions of source code must retain the above copyright notice, this list of conditions
 * and the following disclaimer.
 * 
 * 2. Redistributions in binary form must reproduce the above copyright notice, this list of
 * conditions and the following disclaimer in the documentation and/or other materials provided with
 * the distribution.
 * 
 * 3. The end-user documentation included with the redistribution, if any, must include the
 * following acknowledgment: "This product includes software developed by the The International
 * Cooperation for the Integration of Processes in Prepress, Press and Postpress (www.cip4.org)"
 * Alternately, this acknowledgment may appear in the software itself, if and wherever such
 * third-party acknowledgments normally appear.
 * 
 * 4. The names "CIP4" and "The International Cooperation for the Integration of Processes in
 * Prepress, Press and Postpress" must not be used to endorse or promote products derived from this
 * software without prior written permission. For written permission, please contact info@cip4.org.
 * 
 * 5. Products derived from this software may not be called "CIP4", nor may "CIP4" appear in their
 * name, without prior written permission of the CIP4 organization
 * 
 * Usage of this software in commercial products is subject to restrictions. For details please
 * consult info@cip4.org.
 * 
 * THIS SOFTWARE IS PROVIDED ``AS IS'' AND ANY EXPRESSED OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
 * LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL THE INTERNATIONAL COOPERATION FOR THE INTEGRATION OF PROCESSES IN
 * PREPRESS, PRESS AND POSTPRESS OR ITS CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
 * SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
 * SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
 * CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
 * NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF
 * THE POSSIBILITY OF SUCH DAMAGE.
 * ====================================================================
 *
 * This software consists of voluntary contributions made by many individuals on behalf of the The
 * International Cooperation for the Integration of Processes in Prepress, Press and Postpress and
 * was originally based on software copyright (c) 1999-2001, Heidelberger Druckmaschinen AG
 * copyright (c) 1999-2001, Agfa-Gevaert N.V.
 *
 * For more information on The International Cooperation for the Integration of Processes in
 * Prepress, Press and Postpress , please see <http://www.cip4.org/>.
 *
 */

 

/*
 * Copyright (c) 2001 Heidelberger Druckmaschinen AG, All Rights Reserved.
 * VJDFAttributeMap.cs
 * Last changes
 */

namespace org.cip4.jdflib.datatypes
{
   using System;
   using System.Collections;
   using System.Collections.Generic;
   using System.Text;


   using HashUtil = org.cip4.jdflib.util.HashUtil;

   ///
   /// <summary> * 
   /// * Description: This class represents a vector of JDFAttributeMaps
   /// * 
   /// * @author Torsten Kaehlert
   /// * 
   /// * @version 1.0 2002-01-24
   /// *  </summary>
   /// 
   public class VJDFAttributeMap
   {
      // **************************************** Attributes
      // ******************************************
      private List<JDFAttributeMap> m_vec = new List<JDFAttributeMap>();

      // **************************************** Constructors
      // ****************************************
      ///   
      ///	 <summary> * constructor </summary>
      ///	 
      public VJDFAttributeMap()
      {
         // default super constructor
      }

      ///   
      ///	 <summary> * copy constructor, the map elements are cloned
      ///	 *  </summary>
      ///	 * <param name="toAdd"> Vector of elements to clone </param>
      ///	 
      public VJDFAttributeMap(ArrayList toAdd)
      {
         m_vec.Clear();
         for (int i = 0; i < toAdd.Count; i++)
         {
            m_vec.Add(new JDFAttributeMap((JDFAttributeMap)toAdd[i]));
         }
      }

      ///   
      ///	 <summary> * constructor from array, the map elements are not cloned
      ///	 *  </summary>
      ///	 * <param name="toAdd"> the array </param>
      ///	 
      public VJDFAttributeMap(JDFAttributeMap[] toAdd)
      {
         m_vec.Clear();
         for (int i = 0; i < toAdd.Length; i++)
         {
            m_vec.Add(toAdd[i]);
         }
      }

      ///   
      ///	 <summary> * copy constructor - clones the vector including the contents!
      ///	 *  </summary>
      ///	 * <param name="v"> the VJDFAttributeMap to copy </param>
      ///	 
      public VJDFAttributeMap(VJDFAttributeMap v)
      {
         if (v != null)
         {
            Clear();
            int size = v.Count;
            for (int i = 0; i < size; i++)
            {
               Add(new JDFAttributeMap(v[i]));
            }
         }
      }

      // **************************************** Methods
      // *********************************************


      /// <summary>
      /// Indext get and set
      /// </summary>
      /// <param name="index"></param>
      /// <returns></returns>
      public JDFAttributeMap this[int index]
      {
         get { return m_vec[index]; }
         set { m_vec[index] = value; }
      }

      ///   
      ///	 <summary> * toString
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public override string ToString()
      {
         return "VJDFAttributeMap: " + showKeys("\n", " ");
      }

      ///   
      ///	 * <param name="sepMap"> the separator between maps </param>
      ///	 * <param name="sepEntry"> the saparator between map entries </param>
      ///	 * <returns> the string representation </returns>
      ///	 
      public virtual string showKeys(string sepMap, string sepEntry)
      {
         StringBuilder sb = new StringBuilder();
         int nPartMaps = this.Count;

         for (int i = 0; i < nPartMaps; i++)
         {
            JDFAttributeMap amParts = this[i];
            sb.Append("[").Append(i).Append("]").Append(amParts.showKeys(sepEntry));
            if (i + 1 < nPartMaps)
               sb.Append(sepMap);
         }
         return sb.ToString();
      }

      ///   
      ///	 <summary> * Returns the vector with JDFAttributeMap elements
      ///	 *  </summary>
      ///	 * <returns> Vector - the vector with JDFAttributeMap elements </returns>
      ///	 
      public virtual List<JDFAttributeMap> getVector()
      {
         return m_vec;
      }

      ///   
      ///	 <summary> * sets the Vector with JDFAttributeMap elements
      ///	 *  </summary>
      ///	 * <param name="vec"> the Vector with JDFAttributeMap elements </param>
      ///	 
      public virtual void setVector(List<JDFAttributeMap> vec)
      {
         m_vec = vec;
      }

      ///   
      ///	 <summary> * Return the size of the JDFAttributeMap vector
      ///	 *  </summary>
      ///	 * <returns> int - the size </returns>
      ///	
      public int Count
      {
         get { return m_vec.Count; }
      }

      ///   
      ///	 <summary> * Return true if the JDFAttributeMap vector is empty
      ///	 *  </summary>
      ///	 * <returns> boolean - true if empty otherwise false </returns>
      ///	 
      public virtual bool IsEmpty()
      {
         return m_vec.Count == 0;
      }


      ///   
      ///	 <summary> * Method removeElementAt.
      ///	 *  </summary>
      ///	 * <param name="index"> the position of the element to remove </param>
      ///	 
      public virtual void RemoveAt(int index)
      {
         m_vec.RemoveAt(index);
      }

      ///   
      ///	 <summary> * remove the keys specified in set and then erase any duplicates and emptys
      ///	 *  </summary>
      ///	 * <param name="set"> </param>
      ///	 
      public virtual void removeKeys(SupportClass.SetSupport<string> @set)
      {
         for (int i = Count - 1; i >= 0; i--)
         {
            this[i].removeKeys(@set);
            if (this[i].IsEmpty())
               RemoveAt(i);
         }
         unify();
      }


      ///   
      ///	 <summary> * Appends the specified element to the end of this Vector
      ///	 *  </summary>
      ///	 * <param name="obj"> the given element </param>
      ///	 
      public virtual void Add(JDFAttributeMap obj)
      {
         m_vec.Add(obj);
      }

      ///   
      ///	 <summary> * Appends all the specified elements to the end of this Vector
      ///	 *  </summary>
      ///	 * <param name="obj"> the given element </param>
      ///	 
      public virtual void addAll(VJDFAttributeMap obj)
      {
         if (obj != null)
         {
            for (int i = 0; i < obj.Count; i++)
            {
               m_vec.Add(obj[i]);
            }
         }
      }


      ///   
      ///	 <summary> * Tests if the specified object is a component in this vector
      ///	 *  </summary>
      ///	 * <param name="obj"> the given JDFAttributeMap element
      ///	 *  </param>
      ///	 * <returns> boolean - true if and only if the specified object is the same as a component in this vector, as
      ///	 *         determined by the equals method; false otherwise </returns>
      ///	 
      public virtual bool Contains(JDFAttributeMap obj)
      {
         return m_vec.Contains(obj);
      }

      ///   
      ///	 <summary> * Tests wether this has a entry with the same key and value entries not more nor less keys
      ///	 *  </summary>
      ///	 * <param name="attmap"> the given JDFAttributeMap element </param>
      ///	 * @deprecated use contains 
      ///	 * <returns> boolean - true if and only if the specified AttributeMap has the some number of keys and values and the
      ///	 *         same keys and values as a entry in this vector </returns>
      ///	 
      [Obsolete("use contains")]
      public virtual bool hasEntryWithEqualKeyValuePairs(JDFAttributeMap attmap)
      {

         bool bEquals = false;

         for (int i = 0; i < Count; i++)
         {
            // if its the same object...ne further action needed
            if (attmap == this[i])
            {
               return true;
            }

            // reset for every entry
            bEquals = false;
            JDFAttributeMap map = this[i];

            // only check if both have the same size

            if (map.Count == attmap.Count)
            {
               // now that we found a entry with same entry counter set
               // this to true. A single wrong entry will set it to false and
               // break. If bEquals is still true after all checks, we found
               // the map
               bEquals = true;
               IEnumerator<string> it = map.getKeyIterator();
               while (it.MoveNext())
               {
                  string key = it.Current;
                  if (!attmap.ContainsKey(key))
                  {
                     bEquals = false;
                     break;
                  }
                  string value1 = map.get(key);
                  string value2 = attmap.get(key);
                  if (!value1.Equals(value2))
                  {
                     bEquals = false;
                     break;
                  }
               }
               // if bEquals is still true we found a matching map
               if (bEquals)
               {
                  return bEquals;
               }
            }
         }

         return bEquals;
      }

      ///   
      ///	 <summary> * Removes all of the elements from this Vector </summary>
      ///	 
      public virtual void Clear()
      {
         m_vec.Clear();
      }

      ///   
      ///	 <summary> *  </summary>
      ///	 * <param name="vKeys"> </param>
      ///	 * @deprecated use redceMap 
      ///	 
      [Obsolete("use redceMap")]
      public virtual void reduceKey(ICollection<string> vKeys)
      {
         VJDFAttributeMap v = new VJDFAttributeMap();

         for (int i = 0; i < m_vec.Count; i++)
         {
            JDFAttributeMap map = m_vec[i];
            map.reduceMap(vKeys);

            if (!map.IsEmpty())
            {
               v.appendUnique(map);
            }
         }

         m_vec = v.getVector();
      }

      ///   
      ///	 <summary> * reduce each JDFAttributeMap in <code>this</code> by keySet
      ///	 *  </summary>
      ///	 * <param name="keySet"> </param>
      ///	 
      public virtual void reduceMap(ICollection<string> keySet)
      {
         VJDFAttributeMap v = new VJDFAttributeMap();

         for (int i = 0; i < m_vec.Count; i++)
         {
            JDFAttributeMap map = m_vec[i];
            bool bNullMap = map.IsEmpty();
            map.reduceMap(keySet);

            if (bNullMap || !map.IsEmpty())
            {
               v.appendUnique(map);
            }
         }
         m_vec = v.getVector();
      }

      ///   
      ///	 <summary> *  </summary>
      ///	 * <param name="map"> map to append </param>
      ///	 
      public virtual void appendUnique(JDFAttributeMap map)
      {
         for (int i = 0; i < m_vec.Count; i++)
         {
            if ((m_vec[i]).Equals(map))
            {
               return;
            }
         }

         m_vec.Add(map);
      }

      ///   
      ///	 <summary> * unify - make VElement unique, retaining initial order </summary>
      ///	 
      public virtual void unify()
      {
         SupportClass.HashSetSupport @set = new SupportClass.HashSetSupport();
         int size = Count;
         for (int i = 0; i < size; i++)
         {
            JDFAttributeMap e = this[i];
            if (@set.Contains(e))
            {
               this.RemoveAt(i);
               i--;
               size--;
            }
            else
            {
               @set.Add(e);
            }
         }
      }

      ///   
      ///	 <summary> * Method appendUnique.
      ///	 *  </summary>
      ///	 * <param name="map"> maps to append </param>
      ///	 
      public virtual void appendUnique(VJDFAttributeMap map)
      {
         addAll(map);
         unify();
      }

      ///   
      ///	 <summary> * Method overlapMap.
      ///	 *  </summary>
      ///	 * <param name="map"> the map to check against </param>
      ///	 
      public virtual void overlapMap(JDFAttributeMap map)
      {
         for (int i = this.Count - 1; i >= 0; i--)
         {
            if (!this[i].overlapMap(map))
            {
               this.RemoveAt(i);
            }
         }
      }

      ///   
      ///	 <summary> * Method overlapMap.
      ///	 *  </summary>
      ///	 * <param name="map"> the map to check against </param>
      ///	 
      public virtual bool overlapsMap(JDFAttributeMap map)
      {
         for (int i = Count - 1; i >= 0; i--)
         {
            if (this[i].overlapMap(map))
            {
               return true;
            }
         }
         return false;
      }

      ///   
      ///	 <summary> * Method subMap.
      ///	 *  </summary>
      ///	 * <param name="map"> the submap to check against </param>
      ///	 * <returns> true if this has at least one entry that subMap is a submap of </returns>
      ///	 
      public virtual bool subMap(JDFAttributeMap map)
      {
         for (int i = this.Count - 1; i >= 0; i--)
         {
            if (this[i].subMap(map))
               return true;
         }
         return false;
      }

      ///   
      ///	 <summary> * Method subMap.
      ///	 *  </summary>
      ///	 * <param name="vMap"> the vector submaps to check against </param>
      ///	 * <returns> true if this has at least one entry that vMap contains at least a submap of </returns>
      ///	 
      public virtual bool subMap(VJDFAttributeMap vMap)
      {
         if (vMap == null)
            return true;
         for (int i = 0; i < vMap.Count; i++)
         {
            if (subMap(vMap[i]))
               return true;
         }
         return false;
      }

      ///   
      ///	 <summary> * Method overlapsMap.
      ///	 * returns true if at least one element exists that has no non-matching key value pairs
      ///	 *  </summary>
      ///	 * <param name="vMap"> the vector to check against </param>
      ///	 * <returns> true if this has at least one entry that vMap contains at least a submap of </returns>
      ///	 
      public virtual bool overlapsMap(VJDFAttributeMap vMap)
      {
         int size = vMap == null ? 0 : vMap.Count;
         if (size == 0)
            return true;

         if (vMap != null)
         {
            for (int i = 0; i < size; i++)
            {
               if (overlapsMap(vMap[i]))
                  return true;
            }
         }

         return false;
      }

      ///   
      ///	 <summary> * equals - Compares two map vectors, returns true if content equal regardless of element order, otherwise false.<br>
      ///	 * If input is not of type VJDFAttributeMap, result of superclasses equals method is returned.
      ///	 *  </summary>
      ///	 * <param name="other"> in this case VJDFAttributeMap to compare
      ///	 *  </param>
      ///	 * <returns> boolean - true if the maps are equal, otherwise false </returns>
      ///	 
      public override bool Equals(object other)
      {
         if (this == other)
            return true;
         if (other == null)
            return false;
         if (!(other is VJDFAttributeMap))
            return false;

         int size = Count;
         if (size != ((VJDFAttributeMap)other).Count)
            return false;

         VJDFAttributeMap vOther = new VJDFAttributeMap((JDFAttributeMap[])((VJDFAttributeMap)other).getVector().ToArray());
         for (int i = 0; i < size; i++)
         {
            JDFAttributeMap map = this[i];
            int index = vOther.IndexOf(map);
            if (index < 0)
               return false;
            vOther.RemoveAt(index);
         }
         return true;
      }

      ///   
      ///	 <summary> * hashCode complements equals() to fulfill the equals/hashCode contract
      ///	 *  </summary>
      ///	 * <returns> int </returns>
      ///	 
      public override int GetHashCode()
      {
         return HashUtil.GetHashCode(0, this.m_vec);
      }

      ///   
      ///	 <summary> * returns the index of a given JDFAttributeMap, -1 if not present
      ///	 *  </summary>
      ///	 * <param name="map"> the given JDFAttributeMap </param>
      ///	 
      public virtual int IndexOf(JDFAttributeMap map)
      {
         int index = -1;
         int size = this.Count;
         for (int i = 0; i < size; i++)
         {
            if (this[i].Equals(map))
            {
               index = i;
               break;
            }
         }
         return index;
      }

      ///   
      ///	 <summary> * put the key value pair into all entries
      ///	 *  </summary>
      ///	 * <param name="key"> the key to set - may be either String or Enum </param>
      ///	 * <param name="value"> the value to set - may be either String or Enum </param>
      ///	 
      public virtual void put(object key, object @value)
      {
         for (int i = 0; i < Count; i++)
            this[i].put(key, @value);
      }

      ///   
      ///	 <summary> * put the key value pair into all entries; if no entries are there, create exactly one entry with the given key value pair
      ///	 *  </summary>
      ///	 * <param name="key"> the key to set </param>
      ///	 * <param name="value"> the value to set </param>
      ///	 
      public virtual void put(string key, string @value)
      {
         int size = Count;
         if (size == 0)
            Add(new JDFAttributeMap(key, @value));
         else
         {
            for (int i = 0; i < size; i++)
               this[i].put(key, @value);
         }
      }
   }
}
