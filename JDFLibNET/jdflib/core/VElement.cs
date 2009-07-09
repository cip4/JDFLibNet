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
 * VElement.cs
 * Last changes
 */

namespace org.cip4.jdflib.core
{
   using System;
   using System.Collections;
   using System.Collections.Generic;
   using System.Xml;


   using SimpleNodeComparator = org.cip4.jdflib.core.KElement.SimpleNodeComparator;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;

   ///
   /// <summary> * </summary>
   /// 
   public class VElement : List<KElement>
   {
      private const long serialVersionUID = 1L;

      // **************************************** Constructors
      // ****************************************
      ///   
      ///	 <summary> * constructor </summary>
      ///	 
      public VElement()
         : base()
      {
      }

      ///   
      ///	 <summary> * constructor
      ///	 *  </summary>
      ///	 * <param name="m"> </param>
      ///	 
      public VElement(VElement m)
         : base()
      {
         addAll(m);
      }

      ///   
      ///	 <summary> * constructor
      ///	 *  </summary>
      ///	 * <param name="n"> </param>
      ///	 
      public VElement(XmlNodeList n)
         : base()
      {

         if (n != null)
         {
            int len = n.Count;

            for (int i = 0; i < len; i++)
            {
               if (n.Item(i).NodeType == XmlNodeType.Element)
               {
                  this.Add((KElement)n.Item(i));
               }
            }
         }
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
         return "VElement[ --> " + base.ToString() + " ]";
      }


      /// <summary>
      /// Convert a generic list of elements to VElement
      /// </summary>
      /// <typeparam name="T">Type of Element</typeparam>
      /// <param name="list">List of elements</param>
      /// <returns>VElement list</returns>
      public static VElement ToVElement<T>(List<T> list) where T : KElement
      {
         if (list != null)
         {
            VElement vList = new VElement();
            foreach (KElement element in list)
            {
               vList.Add(element);
            }
            return vList;
         }
         return null;
      }

      ///   
      ///	 <summary> * index - get the index of s in the vector
      ///	 *  </summary>
      ///	 * <param name="s"> KElement to search for
      ///	 *  </param>
      ///	 * <returns> int - the index of s in the vector </returns>
      ///	 
      public virtual int index(KElement s)
      {
         for (int i = 0; i < Count; i++)
         {
            if (this[i].isEqual(s))
            {
               return i;
            }
         }

         return -1;
      }

      ///   
      ///	 <summary> * hasElement - checks if kElem is in the vector in contrast to contains, this uses the isEquals method
      ///	 *  </summary>
      ///	 * <param name="kElem"> the element to look for </param>
      ///	 * @deprecated 060216 use containsElement 
      ///	 * <returns> true if s is contained in this </returns>
      ///	 
      [Obsolete("060216 use containsElement")]
      public virtual bool hasElement(KElement kElem)
      {
         return index(kElem) >= 0;
      }

      ///   
      ///	 <summary> * appendUniqueNotNull - append a string but ignore multiple entries
      ///	 *  </summary>
      ///	 * <param name="KElement"> v </param>
      ///	 * @deprecated simply use appendUnique 
      ///	 
      [Obsolete("simply use appendUnique")]
      public virtual void appendUniqueNotNull(KElement v)
      {
         if (v != null && !Contains(v))
         {
            Add(v);
         }
      }

      ///   
      ///	 <summary> * AppendUniqueNotNull - append a vector but ignore multiple entries
      ///	 *  </summary>
      ///	 * <param name="VElement"> v </param>
      ///	 * @deprecated simply use appendUnique 
      ///	 
      [Obsolete("simply use appendUnique")]
      public virtual void appendUniqueNotNull(VElement v)
      {
         if (v != null)
         {
            for (int i = 0; i < v.Count; i++)
            {
               appendUniqueNotNull(v[i]);
            }
         }
      }

      ///   
      ///	 <summary> * AppendUnique - append a string but ignore multiple entries
      ///	 *  </summary>
      ///	 * <param name="v"> the element to append </param>
      ///	 
      public virtual void appendUnique(KElement elem)
      {
         if (elem == null)
            return;
         if (!(index(elem) >= 0))
         {
            Add(elem);
         }
      }

      ///   
      ///	 <summary> * addAll ignoring null collections
      ///	 *  </summary>
      ///	 * <param name="v"> the vector of elements to append </param>
      ///	 
      public virtual void addAll(VElement elem)
      {
         if (elem == null)
            return;
         base.AddRange(elem);

      }

      ///   
      ///	 <summary> * does this contain an equivalent element similar to contains but uses isEqual() instead of equals()
      ///	 *  </summary>
      ///	 * <param name="v"> the element to look for </param>
      ///	 * <returns> true, if v is contained in this </returns>
      ///	 
      public virtual bool containsElement(KElement elem)
      {
         int size = Count;
         for (int i = 0; i < size; i++)
         {
            if (elem.isEqual(item(i)))
               return true;
         }
         return false;

      }

      ///   
      ///	 <summary> * are the two vectors equivalent, i.e. do thay only contain elements that are isEqual() or if this is empty and the
      ///	 * comparison is against null
      ///	 *  </summary>
      ///	 * <param name="v"> the vector to compare </param>
      ///	 * <returns> true, if v is equal to this </returns>
      ///	 
      public virtual bool isEqual(VElement v)
      {
         int size = Count;
         if (v == null)
            return size == 0;
         if (size != v.Count)
            return false;
         VElement v0 = new VElement(this);
         VElement v1 = new VElement(v);
         v0.Sort();
         v1.Sort();
         for (int i = 0; i < size; i++)
            if (!v0[i].isEqual(v1[i]))
               return false;
         return true;

      }

      ///   
      ///	 <summary> * AppendUnique - append a vector but ignore multiple entries
      ///	 *  </summary>
      ///	 * <param name="v"> the vector of elements to append </param>
      ///	 
      public virtual void appendUnique(VElement v)
      {
         if (v == null)
            return;

         int size = v.Count;
         for (int i = 0; i < size; i++)
         {
            appendUnique(v.item(i));
         }
      }

      ///   
      ///	 <summary> * set the attribute key to the values defined in vValue
      ///	 *  </summary>
      ///	 * <param name="key"> key the attribute name </param>
      ///	 * <param name="vValue"> vValue the vector of values </param>
      ///	 * <param name="nameSpaceURI"> nameSpace of the attribute to set
      ///	 * 
      ///	 * @default setAttributes(key, vValue, null) </param>
      ///	 
      public virtual void setAttributes(string key, ArrayList vValue, string nameSpaceURI)
      {
         if (Count != vValue.Count)
         {
            Console.WriteLine("VElement.SetAttributes: size mismatch");
         }

         for (int i = 0; i < Count; i++)
         {
            KElement k = this[i];
            k.setAttribute(key, (string)vValue[i], nameSpaceURI);
         }
      }

      ///   
      ///	 <summary> * sorts the vector in canonical order using SimpleNodeComparator
      ///	 *  </summary>
      ///	 
      public new void Sort()
      {
         base.Sort(new SimpleNodeComparator());
      }

      ///   
      ///	 <summary> * SetAttribute in all elements of this
      ///	 *  </summary>
      ///	 * <param name="key"> key the attribute name </param>
      ///	 * <param name="value"> the value </param>
      ///	 * <param name="nameSpaceURI"> nameSpace of the attribute to set
      ///	 * 
      ///	 * @default SetAttributes(key, value, null) </param>
      ///	 
      public virtual void setAttribute(string key, string @value, string nameSpaceURI)
      {
         int siz = Count;
         for (int i = 0; i < siz; i++)
         {
            KElement k = this[i];
            k.setAttribute(key, @value, nameSpaceURI);
         }
      }

      ///   
      ///	 <summary> * Remove Attribute in all elements of this
      ///	 *  </summary>
      ///	 * <param name="key"> key the attribute name </param>
      ///	 * <param name="nameSpaceURI"> nameSpace of the attribute to set
      ///	 * 
      ///	 * @default removeAttributes(key, null) </param>
      ///	 
      public virtual void removeAttribute(string key, string nameSpaceURI)
      {
         int siz = Count;
         for (int i = 0; i < siz; i++)
         {
            KElement k = this[i];
            k.removeAttribute(key, nameSpaceURI);
         }
      }

      ///   
      ///	 <summary> * Remove elements listed in v from this
      ///	 *  </summary>
      ///	 * <param name="v"> elements to remove </param>
      ///	 
      public virtual void removeElements(VElement v)
      {
         for (int i = Count - 1; i >= 0; i--)
         {
            if (v.containsElement(this[i]))
            {
               RemoveAt(i);
            }
         }
      }

      ///   
      ///	 <summary> * RemoveElements
      ///	 *  </summary>
      ///	 * <param name="e"> the element to remove </param>
      ///	 * <param name="nMax"> maximum number of dulicate elements to remove
      ///	 * 
      ///	 * @default RemoveElements(e, 0) </param>
      ///	 
      public virtual void removeElements(KElement e, int nMax)
      {
         int j = 0;

         for (int i = Count - 1; i >= 0; i--)
         {
            if (e == this[i])
            {
               RemoveAt(i);

               if (++j == nMax)
               {
                  break;
               }
            }
         }
      }

      ///   
      ///	 <summary> * get the node names of this vector in the same order
      ///	 *  </summary>
      ///	 * <param name="bLocal"> if true use LocalName else Name o each item </param>
      ///	 * <returns> VString vector of node names </returns>
      ///	 
      public virtual VString getElementNameVector(bool bLocal)
      {
         VString v = new VString();
         int size = Count;
         v.Capacity = size;
         for (int i = 0; i < size; i++)
            v.Add(bLocal ? item(i).LocalName : item(i).Name);
         return v;
      }

      ///   
      ///	 <summary> * ToVector - parse a node list for elements spezified through parameters note that the vector is static - i.e. the
      ///	 * elements are NOT modified by operations to the nodeList. This behavior is different than that of the actual
      ///	 * nodelist!
      ///	 *  </summary>
      ///	 * <param name="element"> name of the element typ you want </param>
      ///	 * <param name="mAttrib"> a attribute typ you want </param>
      ///	 * <param name="bAnd"> true, if you want to add the element if mAttrib was found in the element </param>
      ///	 * <param name="nameSpaceURI"> the namespace to search in </param>
      ///	 * <returns> VElement - vector of all elements matching the conditions above </returns>
      ///	 
      public virtual VElement toVector(string element, JDFAttributeMap mAttrib, bool bAnd, string nameSpaceURI)
      {
         VElement v = new VElement();
         bool bWantName = KElement.isWildCard(element);
         bool bWantNS = KElement.isWildCard(nameSpaceURI);

         // loop over the list
         int len = Count;
         // optimize -> walk tree once to set it up!
         if (len > 0)
         {
            KElement temp = this[len - 1];
         }
         for (int i = 0; i < len; i++)
         {
            KElement k = this[i];
            if (bWantName)
            {
               // want only named elements
               if (!k.Name.Equals(element))
               {
                  continue;
               }
            }
            if (bWantNS)
            {
               // want only named elements
               if (!k.getNamespaceURI().Equals(nameSpaceURI))
               {
                  continue;
               }
            }
            if (k.includesAttributes(mAttrib, bAnd))
            {
               v.Add(k);
            }
         }
         return v;
      }

      ///   
      ///	 <summary> * item - returns null if index is out of bounds or the requested item is not an ELEMENT_NODE !
      ///	 *  </summary>
      ///	 * <param name="index"> vector index of the element you want </param>
      ///	 * <returns> KElement - the requested item or null, if index is out of bounds </returns>
      ///	 
      public virtual KElement item(int index)
      {
         if (Count <= index)
         {
            return null;
         }

         return this[index];
      }

      ///   
      ///	 <summary> * returns the common ancestor of all entries of this
      ///	 *  </summary>
      ///	 * <returns> the element that is a common ancestor of all vector members
      ///	 * @since 050721 </returns>
      ///	 
      internal virtual KElement getCommonAncestor()
      {
         int siz = Count;
         if (siz == 0)
            return null;

         if (siz == 1) // only one - the ancestor is the only entry itself
            return this[0];

         KElement ret = this[0]; // could all be the same, therefore do not
         // start with parent node

         // loop down searching for a common ancestor
         while (ret != null)
         {
            bool bOK = true;
            for (int i = 1; i < siz; i++)
            { // start at 1, since the parents of 0 are ok by definition
               if (!ret.isAncestor(this[i]))
               {
                  bOK = false;
                  break;
               }
            }
            if (bOK)
            { // found the ancestor of all members
               return ret;
            }
            ret = ret.getParentNode_KElement();
         }
         return ret; // if we get here it is null
      }

      ///   
      ///	 <summary> * Resource
      ///	 *  </summary>
      ///	 * <param name="int"> i
      ///	 *  </param>
      ///	 * <returns> JDFResource </returns>
      ///	 * @deprecated used only to facilitate migration from vResource to vElement 
      ///	 
      [Obsolete("used only to facilitate migration from vResource to vElement")]
      public virtual JDFResource resource(int i)
      {
         return (JDFResource)this[i];
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
            KElement e = this.item(i);
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
      ///	 <summary> * unify - make VElement unique, retaining initial order uses containsElement, not contains </summary>
      ///	 
      public virtual void unifyElement()
      {
         int size = Count;
         for (int i = 0; i < size; i++)
         {
            KElement e = this.item(i);
            for (int j = size - 1; j > i; j--)
            {
               KElement e2 = this.item(j);
               if (e.isEqual(e2))
               {
                  RemoveAt(j);
                  size--;
               }
            }
         }
      }

      /// <summary>
      /// Is the Vectore empty
      /// </summary>
      /// <returns>true if vector is empty</returns>
      public bool IsEmpty()
      {
         return (this.Count == 0);
      }


      /// <summary>
      /// Check if all the elements in the list are in this VElement instance
      /// </summary>
      /// <param name="list">VElement list</param>
      /// <returns>true if all of the Elements in the list are in this VElement instance</returns>
      public virtual bool ContainsAll(VElement list)
      {
         if (list == null)
            return true;

         if (list.Count > this.Count)
            return false;

         foreach (KElement item in list)
         {
            if (!this.Contains(item))
               return false;
         }
         return true;
      }

   }
}
