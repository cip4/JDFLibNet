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
 * Copyright (c) 2001 Heidelberger Druckmaschinen AG, All Rights Reserved.
 * JDFAttribute.cs
 * Last changes
 */

namespace org.cip4.jdflib.datatypes
{
   using System;
   using System.Collections;
   using System.Collections.Generic;
   using System.Text;

   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using KElement = org.cip4.jdflib.core.KElement;
   using VString = org.cip4.jdflib.core.VString;
   using EnumPartIDKey = org.cip4.jdflib.resource.JDFResource.EnumPartIDKey;
   using HashUtil = org.cip4.jdflib.util.HashUtil;

   ///
   /// <summary> * This is the Java class to the mAttribute class on the C++ side. </summary>
   /// 
   public class JDFAttributeMap : IDictionary<string, string>
   {
      // **************************************** Attributes
      // ******************************************
      private Dictionary<string, string> m_hashTable = new Dictionary<string, string>();

      // **************************************** Constructors
      // ****************************************
      ///   
      ///	 <summary> * constructor </summary>
      ///	 
      public JDFAttributeMap()
      {
         // default super constructor
      }

      ///   
      ///	 <summary> * utility constructor to construct a single value map
      ///	 *  </summary>
      ///	 * <param name="key"> the key of the single value map </param>
      ///	 * <param name="value"> the value of the single value map </param>
      ///	 
      public JDFAttributeMap(string key, string value)
      {
         put(key, value);
      }

      ///   
      ///	 <summary> * utility constructor to construct a single value map
      ///	 *  </summary>
      ///	 * <param name="key"> the key of the single value map </param>
      ///	 * <param name="value"> the value of the single value map </param>
      ///	 
      public JDFAttributeMap(string key, ValuedEnum value)
      {
         put(key, value.getName());
      }

      ///   
      ///	 <summary> * Method JDFAttributeMap clone the content of the input map
      ///	 *  </summary>
      ///	 * <param name="inputMap"> map to clone </param>
      ///	 
      public JDFAttributeMap(JDFAttributeMap inputMap)
      {
         if (inputMap != null)
            m_hashTable = new Dictionary<string, string>(inputMap.m_hashTable);
      }

      ///   
      ///	 <summary> * Method JDFAttributeMap clone the content of the input map
      ///	 *  </summary>
      ///	 * <param name="inputMap"> map to clone </param>
      ///	 
      public JDFAttributeMap(IDictionary<string, string> inputMap)
      {
         if (inputMap != null)
            m_hashTable = new Dictionary<string, string>(inputMap);
      }
      ///   
      ///	 <summary> * constructor: create a new map with one entry that is defined by partIDKey, value
      ///	 *  </summary>
      ///	 * <param name="partIDKey"> the enumerated partIDKey </param>
      ///	 * <param name="value"> the partition key value </param>
      ///	 
      public JDFAttributeMap(EnumPartIDKey partIDKey, string value)
         : this(partIDKey.getName(), value)
      {
      }

      // **************************************** Methods
      // *********************************************
      ///   
      ///	 <summary> * showKeys - similar to toString but without class identifier </summary>
      ///	 * <param name="sep"> the separator key between key-entry pairs
      ///	 *  </param>
      ///	 * <returns> String </returns>
      ///	 
      public virtual string showKeys(string sep)
      {
         string sepLocal = sep;

         if (sepLocal == null)
            sepLocal = "";
         StringBuilder sb = new StringBuilder();
         VString vsKeys = this.getKeys();
         int size = vsKeys.Count;
         for (int k = 0; k < size; k++)
         {
            string strKey = vsKeys.stringAt(k);
            string strValue = this.get(strKey);
            sb.Append(k == 0 ? "" : sepLocal).Append("(").Append(strKey).Append(" = ").Append(strValue).Append(")");
         }
         return (sb.ToString());
      }

      ///   
      ///	 <summary> * toString
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public override string ToString()
      {
         return "JDFAttributeMap: {" + showKeys(JDFConstants.BLANK) + " ";
      }

      ///   
      ///	 <summary> * clear - clears the hashtable </summary>
      ///	 
      public virtual void Clear()
      {
         m_hashTable.Clear();
      }

      ///   
      ///	 <summary> * size - returns the number of keys in this hashtable
      ///	 *  </summary>
      ///	 * <returns> int - the number of keys in this hashtable </returns>
      ///	 


      ///   
      ///	 <summary> * get - returns the value to which the specified key is mapped in this hashtable.
      ///	 *  </summary>
      ///	 * <param name="key"> the key of the value to get
      ///	 *  </param>
      ///	 * <returns> String - the String to which the key is mapped in this hashtable; null if the key is not mapped to any
      ///	 *         value in this hashtable. </returns>
      ///	 
      public virtual string @get(string key)
      {
         if (m_hashTable.ContainsKey(key))
            return m_hashTable[key];
         else
            return null;
      }

      ///   
      ///	 <summary> * put - maps the specified key to the specified value in this hashtable. Neither the key nor the value can be ""
      ///	 * 
      ///	 * Note: This method is the equivalent to AddPair in C++
      ///	 *  </summary>
      ///	 * <param name="key"> unique key of the pair to add. Must not be "" or null. </param>
      ///	 * <param name="value"> value of the pair to add. Must not be "" or null.
      ///	 *  </param>
      ///	 * <returns> boolean - false if one Inputparamter is invalid (empty String and null are not alowed)<br>
      ///	 *         true if the new Key was inserted
      ///	 *         <p>
      ///	 *         NOTE: It is NOT possible to enter to identical keys. If you enter a key to a Attribute Map which already
      ///	 *         exists, the value will be replaced. </returns>
      ///	 
      public virtual bool put(string key, string value)
      {
         string valueLocal = value;

         // check input parameter (valid or invalid)
         if (key == null || key.Equals(JDFConstants.EMPTYSTRING))
         {
            return false;
         }

         if (valueLocal == null)
            valueLocal = "";
         // put key value to hashmap. The map returns null if the key was new
         // or an object (the old value) if the value was replaced
         if (m_hashTable.ContainsKey(key))
            m_hashTable.Remove(key);

         m_hashTable.Add(key, valueLocal);

         return true;
      }

      ///   
      ///	 <summary> * entrySet - Returns a Set view of the entries contained in this Hashtable. Each element in this collection is a
      ///	 * Map.Entry. The Set is backed by the Hashtable, so changes to the Hashtable are reflected in the Set, and
      ///	 * vice-versa. The Set supports element removal (which removes the corresponding entry from the Hashtable), but not
      ///	 * element addition.
      ///	 *  </summary>
      ///	 * <returns> Set - the set view of the entries contained in this hashtable </returns>
      ///	 
      // TODO: Just Delete this?
      //      public virtual Set entrySet()
      //      {
      ////JAVA TO VB & C# CONVERTER TODO TASK: There is no .NET Dictionary equivalent to the Java 'entrySet' method:
      //         return m_hashTable.entrySet();
      //      }

      ///   
      ///	 <summary> * subMap - returns true if map contains subMap, all keys of submap must be in this hashtable and they must have the
      ///	 * same value<br>
      ///	 * 
      ///	 * if subMap is null, the function returns true if subMap contains any wildcards, then the existance of the key in
      ///	 * this defines a match
      ///	 *  </summary>
      ///	 * <param name="subMap"> the map to compare
      ///	 *  </param>
      ///	 * <returns> boolean - true if this map contains subMap </returns>
      ///	 
      public virtual bool subMap(JDFAttributeMap subMap)
      {
         if (subMap == null) // the null map is a subset of everything
         {
            return true;
         }

         ICollection<string> mapSet = this.Keys;
         ICollection<string> subMapSet = subMap.Keys;

         if (!this.containsAll(subMapSet))
         {
            return false;
         }

         IEnumerator<string> it = subMapSet.GetEnumerator();
         while (it.MoveNext())
         {
            string key = it.Current;
            string subVal = subMap[key];
            if (!KElement.isWildCard(subVal))
            {
               string val = this[key];
               if (!val.Equals(subVal))
                  return false;
            }

         }
         return true;
      }

      ///   
      ///	 <summary> * Method subMap check if any of the maps in vMap are a subMap oft this (see subMap for details) if vMap is null,
      ///	 * the function returns true
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
      ///	 <summary> * Method overlapMap.
      ///	 *  </summary>
      ///	 * <param name="vMap"> the vector submaps to check against </param>
      ///	 * <returns> true if this has at least one entry that vMap contains at least a submap or supermap of </returns>
      ///	 
      public virtual bool overlapMap(VJDFAttributeMap vMap)
      {
         if (vMap == null)
            return true;

         int size = vMap.Count;
         for (int i = 0; i < size; i++)
         {
            if (overlapMap(vMap[i]))
               return true;
         }
         return false;
      }

      ///   
      ///	 <summary> * overlapMap - identical keys must have the same values in both maps i.e submap is either a superset or a subset of
      ///	 * this
      ///	 *  </summary>
      ///	 * <param name="subMap"> the map to compare with <code>this</this>
      ///	 *  </param>
      ///	 * <returns> boolean - true if identical keys have the same values in both maps </returns>
      ///	 
      public virtual bool overlapMap(JDFAttributeMap subMap)
      {
         if (subMap == null || subMap.Count == 0)
            return true;

         IEnumerator<string> subMapEnum = subMap.getKeyIterator();

         while (subMapEnum.MoveNext())
         {
            string subMapKey = subMapEnum.Current;
            string subMapVal = subMap[subMapKey];
            if (KElement.isWildCard(subMapVal))
               continue;

            string val = this[subMapKey];
            if (val != null && !subMapVal.Equals(val))
               return false;
         }
         return true;
      }

      ///   
      ///	 <summary> * orMap - put all key/value pairs which are not in this map to this map. Clear this, if both maps have the same
      ///	 * keys with different values.
      ///	 *  </summary>
      ///	 * <param name="subMap"> the map to compare with <code>this</this> </param>
      ///	 
      public virtual JDFAttributeMap orMap(JDFAttributeMap subMap)
      {
         IEnumerator<string> subMapEnum = subMap.getKeyIterator();

         while (subMapEnum.MoveNext())
         {
            string subMapKey = subMapEnum.Current;
            string subMapVal = subMap[subMapKey];
            string hashTableVal = this[subMapKey];

            if (hashTableVal != null)
            {
               if (!hashTableVal.Equals(subMapVal))
               {
                  this.Clear();
                  break;
               }
            }
            else
            {
               this.put(subMapKey, subMapVal);
            }
         }

         return this;
      }

      ///   
      ///	 <summary> * andMap - builds a new map with identical pairs of both maps
      ///	 *  </summary>
      ///	 * <param name="subMap"> the given map </param>
      ///	 
      public virtual void andMap(JDFAttributeMap subMap)
      {
         Dictionary<string, string> ht = new Dictionary<string, string>();

         IEnumerator<string> subMapEnum = subMap.getKeyIterator();

         while (subMapEnum.MoveNext())
         {
            string subMapKey = subMapEnum.Current;
            string subMapVal = subMap[subMapKey];
            string hashTableVal = this[subMapKey];

            if (hashTableVal != null)
            {
               if (hashTableVal.Equals(subMapVal))
               {
                  ht.Add(subMapKey, subMapVal);
               }
            }
         }

         m_hashTable = ht;
      }

      ///   
      ///	 <summary> * reduceKey - reduces the map, only valid map entries with the given key vector will be copied to the new
      ///	 * hashtable; if null, clear this map
      ///	 * 
      ///	 *  </summary>
      ///	 * <param name="keySet"> the collection of given keys </param>
      ///	 
      public virtual void reduceMap(ICollection<string> keySet)
      {
         if (keySet == null)
         {
            Clear();
            return;
         }
         IEnumerator<string> it = keySet.GetEnumerator();
         Dictionary<string, string> ht = new Dictionary<string, string>();
         while (it.MoveNext())
         {
            string key = it.Current;
            if (m_hashTable.ContainsKey(key))
            {
               ht.Add(key, m_hashTable[key]);
            }
         }
         m_hashTable = ht;
      }

      ///   
      ///	 <summary> * equals - Compares two maps, returns true if content equal, otherwise false.<br> If input is not of type
      ///	 * JDFAttributeMap, the result of the superclasses' equals method is returned.
      ///	 *  </summary>
      ///	 * <param name="obj"> JDFAttributeMap to compare with <code>this</code>
      ///	 *  </param>
      ///	 * <returns> boolean - true if the maps are equal, otherwise false </returns>
      ///	 
      public override bool Equals(object other)
      {
         if (this == other)
         {
            return true;
         }
         if (other == null || !(other is JDFAttributeMap))
         {
            return false;
         }

         JDFAttributeMap otherMap = (JDFAttributeMap) other;
         if (this.Count != otherMap.Count)
         {
            return false;
         }
         foreach (string key in this.Keys)
         {
            if (!otherMap.ContainsKey(key))
               return false;

            if (this[key] != otherMap[key])
               return false;
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
         return HashUtil.GetHashCode(0, this.m_hashTable);
      }

      ///   
      ///	 <summary> * containsKey - looks for the given key in the hashtable, returns true if the hashtable contains the key otherwise
      ///	 * false
      ///	 *  </summary>
      ///	 * <param name="key"> the key to look for
      ///	 *  </param>
      ///	 * <returns> boolean - true if the hashtable contains the given key otherwise false </returns>
      ///	 
      public virtual bool ContainsKey(string key)
      {
         return m_hashTable.ContainsKey(key);
      }


      public virtual bool ContainsValue(string value)
      {
         return m_hashTable.ContainsValue(value);
      }

      ///   
      ///	 <summary> * isEmpty - returns true if the hashtable is empty
      ///	 *  </summary>
      ///	 * <returns> boolean - true if the hashtable is empty </returns>
      ///	 
      public virtual bool IsEmpty()
      {
         return m_hashTable.Count == 0;
      }

      ///   
      ///	 <summary> * getKeyIterator - returns an iterator over the elements in this set. The elements are returned in no particular
      ///	 * order (unless this set is an instance of some class that provides a guarantee).
      ///	 *  </summary>
      ///	 * <returns> Iterator - an iterator over the elements in this set </returns>
      ///	 
      public virtual IEnumerator<string> getKeyIterator()
      {
         return m_hashTable.Keys.GetEnumerator();
      }

      ///   
      ///	 <summary> * remove - removes the key (and its corresponding value) from this hashtable.<br>
      ///	 * This method does nothing if the key is not in the hashtable
      ///	 *  </summary>
      ///	 * <returns> Object - the value to which the key had been mapped in this hashtable, or null if the key did not have a
      ///	 *         mapping </returns>
      ///	 
      public virtual object remove(object key)
      {
         object keyLocal = key;

         if (keyLocal is ValuedEnum)
            keyLocal = ((ValuedEnum)keyLocal).getName();

         return m_hashTable.Remove((string)keyLocal);
      }



      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see java.util.Map#putAll(java.util.Map)
      //	 
      public virtual void putAll(IDictionary<string, string> t)
      {
         if ((t != null) && (t.Count > 0))
         {
            IEnumerator<string> it = t.Keys.GetEnumerator();
            while (it.MoveNext())
            {
               string key = it.Current;
               string value = t[key];
               m_hashTable.Add(key, value);
            }
         }
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see java.util.Map#get(java.lang.Object)
      //	 
      public virtual string @get(object key)
      {
         object keyLocal = key;

         if (keyLocal is ValuedEnum)
            keyLocal = ((ValuedEnum)keyLocal).getName();

         return m_hashTable[(string)keyLocal];
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see java.util.Map#put(K, V)
      //	 
      public virtual void put(object key, object @value)
      {
         object keyLocal = key;
         object valueLocal = @value;

         if (keyLocal is ValuedEnum)
            keyLocal = ((ValuedEnum)keyLocal).getName();

         if (valueLocal is ValuedEnum)
            valueLocal = ((ValuedEnum)valueLocal).getName();

         if (m_hashTable.ContainsKey((string)keyLocal))
            m_hashTable.Remove((string)keyLocal);

         m_hashTable.Add((string)keyLocal, (string)valueLocal);
      }


      public virtual void Add(string key, string value)
      {
         put(key, value);
      }


      public virtual bool Remove(string key)
      {
         return m_hashTable.Remove(key);
      }


      public virtual bool TryGetValue(string key, out string value)
      {
         value = m_hashTable[key];
         if (value != null)
            return true;
         else
            return false;
      }


      public virtual string this[string key]
      {
         get 
         {
            if (m_hashTable.ContainsKey(key))
               return m_hashTable[key];
            else
               return null;
         }
         set { m_hashTable[key] = value; }
      }


      public virtual ICollection<string> Keys
      {
         get { return m_hashTable.Keys; }
      }


      public virtual ICollection<string> Values
      {
         get { return m_hashTable.Values; }
      }


      public virtual IEnumerator GetEnumerator()
      {
         return m_hashTable.GetEnumerator();
      }


      void ICollection<KeyValuePair<string, string>>.Add(KeyValuePair<string, string> item)
      {
         m_hashTable.Add(item.Key, item.Value);
      }


      void ICollection<KeyValuePair<string, string>>.Clear()
      {
         m_hashTable.Clear();
      }


      bool ICollection<KeyValuePair<string, string>>.Contains(KeyValuePair<string, string> item)
      {
         if (m_hashTable.ContainsKey(item.Key))
         {
            if (m_hashTable[item.Key] == item.Value)
               return true;
         }
         return false;
      }


      void ICollection<KeyValuePair<string, string>>.CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
      {
         int index = arrayIndex;

         Dictionary<string, string>.Enumerator iterator = m_hashTable.GetEnumerator();
         while (iterator.MoveNext())
         {
            array[index++] = iterator.Current;
         }
      }


      bool ICollection<KeyValuePair<string, string>>.Remove(KeyValuePair<string, string> item)
      {
         if (m_hashTable.ContainsKey(item.Key))
         {
            if (m_hashTable[item.Key] == item.Value)
            {
               m_hashTable.Remove(item.Key);
               return true;
            }
         }
         return false;
      }


      public int Count
      {
         get { return m_hashTable.Count; }
      }


      bool ICollection<KeyValuePair<string, string>>.IsReadOnly
      {
         get { throw new NotImplementedException(); }
      }


      IEnumerator<KeyValuePair<string, string>> IEnumerable<KeyValuePair<string, string>>.GetEnumerator()
      {
         return m_hashTable.GetEnumerator();
      }


      ///   
      ///	 <summary> * get the keys as a Vector,
      ///	 * 
      ///	 * @return </summary>
      ///	 
      public virtual VString getKeys()
      {
         IEnumerator<string> it = getKeyIterator();
         VString thisKeys = new VString();
         while (it.MoveNext())
         {
            thisKeys.Add(it.Current);
         }
         return thisKeys;
      }


      ///   
      ///	 <summary> * remove all keys defined by set from this
      ///	 *  </summary>
      ///	 * <param name="set"> the set of keys ot remove </param>
      ///	 
      public virtual void removeKeys(ICollection<string> keySet)
      {
         if (keySet == null)
            return;
         IEnumerator<string> it = keySet.GetEnumerator();
         while (it.MoveNext())
         {
            string key = it.Current;
            Remove(key);
         }
      }



      /// <summary>
      /// Check if all the keys in the keySet are in the current Attribute Map
      /// </summary>
      /// <param name="keySet"></param>
      /// <returns>true if all the keys in the keySet are in the current Attribute ma</returns>
      private bool containsAll(ICollection<string> keySet)
      {
         if (keySet == null)
            return true;

         if (keySet.Count > this.Count)
            return false;

         foreach (string item in keySet)
         {
            if (!this.ContainsKey(item))
               return false;
         }
         return true;
      }
   }
}
