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
 * Copyright (c) 2002 Heidelberger Druckmaschinen AG, All Rights Reserved.
 * XMLDocUserData.cs
 * Last changes
 * 2002-05-23   Joerg Gonnermann - create the file (port from C++)
 */


namespace org.cip4.jdflib.core
{
   using System.Collections;
   using System.Xml;


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   public class XMLDocUserData
   {
      ///   
      ///	 <summary> * additional userdata that is attached by applications </summary>
      ///	 
      private object m_userData;
      private static bool useIDCache = true;
      private bool globalDirty = false;

      ///   
      ///	 <summary> * vKString vDirtyID the vector of dirty IDs </summary>
      ///	 
      private readonly VString m_vDirtyID;

      ///   
      ///	 <summary> * map of ID KElement pairs </summary>
      ///	 
      private readonly Hashtable m_mapTarget;

      private EnumDirtyPolicy dirtyPolicy;

      ///   
      ///	 <summary> * constructor </summary>
      ///	 
      public XMLDocUserData()
      {
         m_mapTarget = new Hashtable(); // default is on
         m_vDirtyID = new VString();

         clearDirtyIDs();
         clearTargets();
         m_userData = null;
         dirtyPolicy = EnumDirtyPolicy.None;
      }

      ///   
      ///	 <summary> * switch on or off the caching method for ids
      ///	 *  </summary>
      ///	 * <param name="bCache"> if true, the ids will be cached </param>
      ///	 
      public virtual void setIDCache(bool bCache)
      {
         useIDCache = bCache;
      }

      ///   
      ///	 <summary> * get the status of the caching method for ids
      ///	 *  </summary>
      ///	 * <returns> if true, the ids will be cached </returns>
      ///	 
      public virtual bool getIDCache()
      {
         return useIDCache;
      }

      ///   
      ///	 <summary> * is target cashing enabled
      ///	 *  </summary>
      ///	 * <returns> true if cashing is enabled </returns>
      ///	 
      public virtual bool hasTargetCache()
      {
         return m_mapTarget != null;
      }

      ///   
      ///	 <summary> * Enumeration of various policies </summary>
      ///	 
      public sealed class EnumDirtyPolicy : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumDirtyPolicy(string name)
            : base(name, m_startValue++)
         {
         }

         ///      
         ///		 <summary> * EnumDirtyPolicy
         ///		 *  </summary>
         ///		 * <param name="enumName"> the name of the enum object to return </param>
         ///		 * <returns> the enum object if enumName is valid. Otherwise null. </returns>
         ///		 
         public static EnumDirtyPolicy getEnum(string enumName)
         {
            return (EnumDirtyPolicy)getEnum(typeof(EnumDirtyPolicy), enumName);
         }

         ///      
         ///		 <summary> * EnumDirtyPolicy
         ///		 *  </summary>
         ///		 * <param name="enumValue"> the value of the enum object to return </param>
         ///		 * <returns> the enum object if enumName is valid. Otherwise null </returns>
         ///		 
         public static EnumDirtyPolicy getEnum(int enumValue)
         {
            return (EnumDirtyPolicy)getEnum(typeof(EnumDirtyPolicy), enumValue);
         }

         ///      
         ///		 <summary> * get a map of all orientation enums
         ///		 *  </summary>
         ///		 * <returns> a map of all orientation enums </returns>
         ///		 
         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumDirtyPolicy));
         }

         ///      
         ///		 <summary> * get a list of all orientation enums
         ///		 *  </summary>
         ///		 * <returns> a list of all orientation enums </returns>
         ///		 
         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumDirtyPolicy));
         }

         ///      
         ///		 <summary> * get an iterator over the enum objects
         ///		 *  </summary>
         ///		 * <returns> an iterator over the enum objects </returns>
         ///		 
         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumDirtyPolicy));
         }

         // none is default instead of unknown
         public static readonly EnumDirtyPolicy None = new EnumDirtyPolicy("None");
         public static readonly EnumDirtyPolicy ID = new EnumDirtyPolicy("ID");
         public static readonly EnumDirtyPolicy Doc = new EnumDirtyPolicy("Doc");
         public static readonly EnumDirtyPolicy XPath = new EnumDirtyPolicy("XPath");
      }

      ///   
      ///	 <summary> * Set the dirty policy to dirtPol
      ///	 *  </summary>
      ///	 * <param name="dirtPol"> the dirtyPolicy to set </param>
      ///	 
      public virtual void setDirtyPolicy(EnumDirtyPolicy dirtPol)
      {
         dirtyPolicy = dirtPol;
      }

      ///   
      ///	 <summary> * Return the documents user data pointer.<br>
      ///	 * User data allows application programs to attach extra data to JDF Documents and can be set using the function
      ///	 * <code>JDFDoc::SetUserData(p)</code>.
      ///	 *  </summary>
      ///	 * <returns> The user data pointer. </returns>
      ///	 
      public virtual object getUserData()
      {
         return m_userData;
      }

      ///   
      ///	 <summary> * Set the user data for a document.<br>
      ///	 * 
      ///	 * User data allows application programs to attach extra data to DOM nodes, and can be retrieved using the function
      ///	 * <code>DOM_Node::getUserData(p)</code>.
      ///	 * <p>
      ///	 * Deletion of the user data remains the responsibility of the application program; it will not be automatically
      ///	 * deleted when the nodes themselves are reclaimed.
      ///	 * 
      ///	 * <p>
      ///	 * Because DOM_Node is not designed to be subclassed, userdata provides an alternative means for extending the
      ///	 * information kept with nodes by an application program.
      ///	 *  </summary>
      ///	 * <param name="p"> the pointer to be kept with the node. </param>
      ///	 
      public virtual void setUserData(object objUserData)
      {
         m_userData = objUserData;
      }

      ///   
      ///	 <summary> * get a vector of all IDs of elements that are dirty
      ///	 *  </summary>
      ///	 * <returns> vKString - the vector of element IDs </returns>
      ///	 
      public virtual VString getDirtyIDs()
      {
         if (dirtyPolicy == EnumDirtyPolicy.ID)
         {
            return m_vDirtyID;
         }

         return null;
      }

      ///   
      ///	 <summary> * get the vector of dirty XPaths
      ///	 *  </summary>
      ///	 * <returns> VString - vector of dirty XPaths </returns>
      ///	 
      public virtual VString getDirtyXPaths()
      {
         if (dirtyPolicy == EnumDirtyPolicy.XPath)
         {
            return m_vDirtyID;
         }

         return null;
      }

      ///   
      ///	 <summary> * clear the vector of all IDs of elements that are dirty </summary>
      ///	 
      public virtual void clearDirtyIDs()
      {
         globalDirty = false;
         if (dirtyPolicy == EnumDirtyPolicy.ID)
         {
            m_vDirtyID.Clear();
         }
         if (dirtyPolicy == EnumDirtyPolicy.XPath)
         {
            m_vDirtyID.Clear();
         }
      }

      ///   
      ///	 <summary> * add string id uniquely to the vector of dirty ids
      ///	 *  </summary>
      ///	 * <param name="e"> the element to be added to the dirty list </param>
      ///	 * <param name="bAttribute"> if true, only attributes are dirty, else also sub-elements </param>
      ///	 * <returns> VString - the vector of element IDs after appending id </returns>
      ///	 
      internal virtual VString setDirty(KElement e, bool bAttribute)
      {

         globalDirty = true;
         if (dirtyPolicy == EnumDirtyPolicy.XPath)
         {
            string x = e.buildXPath(null, 1);

            if (bAttribute)
            {
               x += "/@";
            }

            int i;
            int size = m_vDirtyID.Count;
            for (i = 0; i < size; i++)
            {
               string s = m_vDirtyID[i];
               if (s.StartsWith(x))
               {
                  if (s.Equals(x)) // e is already dirty
                  {
                     return m_vDirtyID;
                  }
                  m_vDirtyID.RemoveAt(i);
                  i--;
               }
               else if (x.StartsWith(s)) // we have a dirty parent, do
               // nothing
               {
                  return m_vDirtyID;
               }
               else if (x.CompareTo(s) > 0) // keep sorted
               {
                  break;
               }
            }

            m_vDirtyID.Insert(i, x);
         }
         else if (dirtyPolicy == EnumDirtyPolicy.ID)
         {
            m_vDirtyID.appendUnique(e.getInheritedAttribute(AttributeName.ID, null, JDFConstants.EMPTYSTRING));
         }
         return m_vDirtyID;
      }

      ///   
      ///	 <summary> * checks if <code>element</code> is dirty
      ///	 *  </summary>
      ///	 * <param name="element"> element to check </param>
      ///	 * <returns> true, if <code>element</code> is dirty </returns>
      ///	 
      public virtual bool isDirty(KElement element)
      {
         if (element == null)
            return false;
         if (dirtyPolicy == EnumDirtyPolicy.Doc)
         {
            return globalDirty;
         }
         else if (dirtyPolicy == EnumDirtyPolicy.ID)
         {
            string id = element.getInheritedAttribute("ID", null, null);
            return isDirty(id);
         }
         else if (dirtyPolicy == EnumDirtyPolicy.XPath)
         {
            string xPath = element.buildXPath(null, 1);
            return isDirty(xPath);
         }
         return false;
      }

      ///   
      ///	 <summary> * checks wheter the node with <code>strID</code> is dirty
      ///	 *  </summary>
      ///	 * <param name="strID"> the id of the node to be checked </param>
      ///	 * <returns> bool true if the node with ID=<code>strID</code> is dirty </returns>
      ///	 
      public virtual bool isDirty(string strID)
      {
         if (dirtyPolicy == EnumDirtyPolicy.ID)
         {
            if (strID == null)
               return m_vDirtyID.Count > 0;
            return m_vDirtyID.Contains(strID); // was in C++.hasString(id);
         }
         else if (dirtyPolicy == EnumDirtyPolicy.XPath)
         {
            int size = m_vDirtyID.Count;
            if (strID == null)
               return size > 0;

            for (int i = 0; i < size; i++)
            {
               string s = m_vDirtyID[i];
               if (strID.StartsWith(s)) // we have a dirty parent, do nothing
               {
                  return true;
               }
               else if (strID.CompareTo(s) > 0) // sorted
               {
                  break;
               }
            }
            return false;
         }
         return globalDirty;

      }

      ///   
      ///	 <summary> * Set the target to target
      ///	 *  </summary>
      ///	 * <param name="targetElement"> the target element </param>
      ///	 * <param name="id"> </param>
      ///	 
      public virtual void setTarget(KElement targetElement, string id)
      {
         string idLocal = id;

         if (!useIDCache || m_mapTarget == null)
            return;

         if (idLocal == null)
            idLocal = targetElement.getAttribute(AttributeName.ID, null, null);

         if (idLocal != null)
         {
            m_mapTarget.Add(idLocal, targetElement); // put the correct in
         }
      }

      ///   
      ///	 <summary> * remove the KElement from the target list
      ///	 *  </summary>
      ///	 * <param name="target"> the element to remove </param>
      ///	 
      public virtual void removeTarget(KElement targetElement)
      {
         if (!useIDCache || m_mapTarget == null)
            return;

         string id = targetElement.getAttribute("ID", null, null);
         if (id != null)
         {
            KElement kelem = (KElement)m_mapTarget[id];
            if (kelem != null)
            { // element with key of id was found, so delete it
               m_mapTarget.Remove(id);
            }
         }
      }

      ///   
      ///	 <summary> * remove the target id from the target list
      ///	 *  </summary>
      ///	 * <param name="id"> the target element id </param>
      ///	 
      public virtual void removeTarget(string id)
      {
         if (useIDCache && m_mapTarget != null)
            m_mapTarget.Remove(id);
      }

      ///   
      ///	 <summary> * Get the target with ID=<code>strID</code>
      ///	 *  </summary>
      ///	 * <param name="strID"> the id of the target to search </param>
      ///	 * <returns> KElement target the target element </returns>
      ///	 
      public virtual KElement getTarget(string strID)
      {
         // m_mapTarget=null; // uncomment this to ensure that the cache is off
         if (useIDCache && m_mapTarget != null && strID != null)
         {

            KElement elem = (KElement)m_mapTarget[strID];
            if (elem != null)
            {
               XmlAttribute a = elem.GetAttributeNode(AttributeName.ID);
               if (a != null && strID.Equals(a.Value))
               {
                  return elem;
               }
               m_mapTarget.Remove(strID);
               // oops this guy is inconsistent - zapp it
            }
         }
         return null;
      }

      ///   
      ///	 <summary> * clear the map of all targets </summary>
      ///	 
      public virtual void clearTargets()
      {
         if (useIDCache && m_mapTarget != null)
            m_mapTarget.Clear();
      }

      public virtual void clear()
      {
         clearDirtyIDs();
         clearTargets();
         m_userData = null;
      }
   }
}
