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
 * JDFResourceLinkPool.cs
 * Last changes
 * 2002-07-02   JG - added IsValid()
 * 2002-07-02   JG - now inherits from JDFPool
 * 2002-07-02   JG - added GetPoolChild, GetPoolChildren
 * 2002-07-02   JG - GetPartValues() first parameter is now JDFRessource::EnumPartIDKey
 */

namespace org.cip4.jdflib.pool
{
   using System;
   using System.Collections;



   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using EnumProcessUsage = org.cip4.jdflib.node.JDFNode.EnumProcessUsage;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using EnumPartIDKey = org.cip4.jdflib.resource.JDFResource.EnumPartIDKey;

   ///
   /// <summary> * </summary>
   /// 
   public class JDFResourceLinkPool : JDFPool
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFResourceLinkPool
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFResourceLinkPool(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFResourceLinkPool
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFResourceLinkPool(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFResourceLinkPool
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFResourceLinkPool(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateAdd(JDFResourcePool.getLinkInfoTable());
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
         return "JDFResourceLinkPool[ --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * GetLinks - get the links matching mLinkAtt out of the resource link pool
      ///	 * <p>
      ///	 * default: GetLinks(null)
      ///	 *  </summary>
      ///	 * <param name="mLinkAtt"> the attributes to search for
      ///	 *  </param>
      ///	 * <returns> mLinkAtt vector all all elements matching the condition mLinkAtt </returns>
      ///	 * @deprecated use getPoolChildren() 
      ///	 
      [Obsolete("use getPoolChildren()")]
      public virtual VElement getLinks(JDFAttributeMap mLinkAtt)
      {
         return getPoolChildren(null, mLinkAtt, null);
      }

      ///   
      ///	 <summary> * GetLinks - get the links matching elementName/nameSpaceURI from the resource pool<br>
      ///	 * if you need all links in the doc, call getLinks from JDFElement
      ///	 * <p>
      ///	 * default: GetLinks(null, null)
      ///	 *  </summary>
      ///	 * <param name="elementName"> Name of the Linked resource </param>
      ///	 * <param name="nameSpaceURI"> the namespace to search in
      ///	 *  </param>
      ///	 * <returns> VElement - vector all all elements matching the condition mLinkAtt </returns>
      ///	 * @deprecated use getPoolChildren() 
      ///	 
      [Obsolete("use getPoolChildren()")]
      public virtual VElement getLinks(string elementName, string nameSpaceURI)
      {
         return getPoolChildren(elementName, null, nameSpaceURI);
      }

      ///   
      ///	 <summary> * Get the linked resources matching some conditions
      ///	 * <p>
      ///	 * default: GetLinkedResources(null, null, null, false)
      ///	 *  </summary>
      ///	 * <param name="resName"> type(Name) of the resource to get </param>
      ///	 * <param name="mLinkAtt"> the link attribute to search for </param>
      ///	 * <param name="mResAtt"> attribute to search for </param>
      ///	 * <param name="bFollowRefs"> if true search all HRefs and add them to the list
      ///	 *  </param>
      ///	 * <returns> VElement - vector with all Resources matching the conditions </returns>
      ///	 
      public virtual VElement getLinkedResources(string resName, JDFAttributeMap mLinkAtt, JDFAttributeMap mResAtt, bool bFollowRefs)
      {
         string resNameLocal = resName;

         VElement vL = new VElement();
         VElement v = getPoolChildren(null, mLinkAtt, null);
         if (v != null)
         {
            if (resNameLocal != null && resNameLocal.EndsWith(JDFConstants.LINK))
               resNameLocal = resNameLocal.Substring(0, resNameLocal.Length - 4); // remove link

            int size = v.Count;
            for (int i = 0; i < size; i++)
            {
               JDFResourceLink l = (JDFResourceLink)v[i];

               JDFResource linkRoot = l.getLinkRoot();
               if ((linkRoot != null) && ((resNameLocal == null) || resNameLocal.Equals(JDFConstants.EMPTYSTRING) || linkRoot.LocalName.Equals(resNameLocal)))
               {
                  if (linkRoot.includesAttributes(mResAtt, true))
                  {
                     vL.Add(linkRoot);
                     if (bFollowRefs)
                     {
                        vL.appendUnique(linkRoot.getvHRefRes(bFollowRefs, true));
                     }
                  }
               }
            }
         }

         return vL;
      }

      ///   
      ///	 <summary> * GetInOutLinks - get the links from the pool (input or output)
      ///	 * <p>
      ///	 * default: GetInOutLinks(bInOut, true, JDFConstants.WILDCARD, JDFConstants.WILDCARD)
      ///	 *  </summary>
      ///	 * <param name="bInOut"> what kind of links you want to have (true for input) </param>
      ///	 * <param name="bLink"> if true, return the resource links. if false return the resources </param>
      ///	 * <param name="resType"> type of the resource to get ( * for all) </param>
      ///	 * <param name="resProcUsage"> process usage of the resource to get (* for all) </param>
      ///	 * @deprecated use getInOutLinks with EnumUsage signature 
      ///	 * <returns> VElement - Vector with the found resource links </returns>
      ///	 
      [Obsolete("use getInOutLinks with EnumUsage signature")]
      public virtual VElement getInOutLinks(bool bInOut, bool bLink, string resName, string resProcUsage)
      {
         return getInOutLinks(bInOut ? EnumUsage.Input : EnumUsage.Output, bLink, resName, EnumProcessUsage.getEnum(resProcUsage));
      }

      ///   
      ///	 <summary> * GetInOutLinks - get the links from the pool (input or output)
      ///	 * <p>
      ///	 * default: GetInOutLinks(null, true, null, null)
      ///	 *  </summary>
      ///	 * <param name="usage"> what kind of links you want to have (input, output). If null all are selected. </param>
      ///	 * <param name="bLink"> if true, return the resource links. if false return the resources </param>
      ///	 * <param name="resName"> name of the resource to get ( * for all) </param>
      ///	 * <param name="procUsage"> process usage of the resource to get
      ///	 *  </param>
      ///	 * <returns> VElement - Vector with the found resource links </returns>
      ///	 
      public virtual VElement getInOutLinks(EnumUsage usage, bool bLink, string resName, EnumProcessUsage procUsage)
      {
         JDFAttributeMap mA = (usage != null) ? new JDFAttributeMap(AttributeName.USAGE, usage.getName()) : null;

         VElement v = getPoolChildren(null, mA, null);
         if (v != null)
         {
            int size = v.Count;
            for (int i = size - 1; i >= 0; i--)
            {
               JDFResourceLink li = (JDFResourceLink)v[i];
               if (!isWildCard(resName))
               {
                  if (!li.getLinkedResourceName().Equals(resName))
                  {
                     v.RemoveAt(i);
                     continue;
                  }
               }

               if (procUsage != null && !isWildCard(procUsage.getName()))
               {
                  if (!procUsage.Equals(li.getEnumProcessUsage()))
                  {
                     v.RemoveAt(i);
                     continue;
                  }
               }
            }
         }

         if (!bLink)
         {
            v = resourceVector(v, resName);
         }

         return v;
      }

      ///   
      ///	 <summary> * ResourceVector - convert a link vector to a resource vector
      ///	 *  </summary>
      ///	 * <param name="linkVector"> vector to convert </param>
      ///	 * <param name="resType"> kind of resType to add ( <code>*</code> for all)
      ///	 *  </param>
      ///	 * <returns> VElement - the converted vector </returns>
      ///	 
      public static VElement resourceVector(VElement linkVector, string resType)
      {
         if (linkVector == null)
            return null;

         VElement v = new VElement();
         bool bResTypeWildcard = isWildCard(resType);

         for (int i = 0; i < linkVector.Count; i++)
         {
            JDFResourceLink l = (JDFResourceLink)linkVector[i];

            // 120803 rp follow parts of resource links
            if (bResTypeWildcard || (l.getLinkedResourceName().Equals(resType)))
            {
               VElement vRes = l.getTargetVector(-1);
               v.AddRange(vRes);
            }
         }

         return v;
      }

      ///   
      ///	 <summary> * AppendResource - append resource r to this link pool
      ///	 * <p>
      ///	 * default: AppendResource(r, input, false)
      ///	 *  </summary>
      ///	 * <param name="r"> the resource to append </param>
      ///	 * <param name="input"> usage of the link (true = inout, false = output) </param>
      ///	 * <param name="bForce"> if true create the link, even though it already exists - now ignored since it is useless
      ///	 *  </param>
      ///	 * <returns> JDFResourceLink - link to appended resource
      ///	 *  </returns>
      ///	 * <exception cref="JDFException"> if r is not in the same document as this
      ///	 * 
      ///	 * @deprecated </exception>
      ///	 
      [Obsolete]
      public virtual JDFResourceLink appendResource(JDFResource r, bool input, bool bForce)
      {
         bool bForceLocal = bForce;

         if (bForceLocal)
            bForceLocal = true; // fool compiler

         return linkResource(r, input ? EnumUsage.Input : EnumUsage.Output, null);
      }

      ///   
      ///	 <summary> * getLink - get the resourcelink that resides in the ResourceLinkPool of this node and references the resource r
      ///	 * <p>
      ///	 * default: getLink(r, EnumUsage.Input, null)
      ///	 *  </summary>
      ///	 * <param name="r"> the resource you are searching a link for </param>
      ///	 * <param name="usage"> usage of the link (input/output) </param>
      ///	 * <param name="processUsage"> ProcessUsage of the link
      ///	 *  </param>
      ///	 * <returns> JDFResourceLink - the resource link you were searching for. If not found, a new empty JDFResourceLink is
      ///	 *         returned. </returns>
      ///	 
      public virtual JDFResourceLink getLink(JDFResource r, EnumUsage usage, EnumProcessUsage processUsage)
      {
         if (r == null || !r.hasAttribute(AttributeName.ID))
         {
            return null;
         }

         // get any possible links
         VElement v = getInOutLinks(usage, true, null, processUsage);
         if (v != null)
         {
            // is it the right one?
            int vSize = v.Count;
            for (int i = 0; i < vSize; i++)
            {
               JDFResourceLink resLink = (JDFResourceLink)v[i];

               if (resLink != null && resLink.getrRef().Equals(r.getID()) && resLink.Name.Equals(r.getLinkString()))
               {
                  return resLink;
               }
            }
         }

         // nothing found
         return null;
      }

      ///   
      ///	 <summary> * linkResource - link resource r to this link pool
      ///	 * <p>
      ///	 * default: linkResource(r, usage, null)
      ///	 *  </summary>
      ///	 * <param name="r"> the resource to link </param>
      ///	 * <param name="usage"> usage of the link </param>
      ///	 * <param name="processUsage"> processUsage of the link, null if none
      ///	 *  </param>
      ///	 * <returns> JDFResourceLink - new link resource
      ///	 *  </returns>
      ///	 * <exception cref="JDFException"> - if <code>r</code> is not in the same document as <code>this</code> </exception>
      ///	 
      public virtual JDFResourceLink linkResource(JDFResource r, JDFResourceLink.EnumUsage usage, EnumProcessUsage processUsage)
      {
         JDFResource rLocal = r;

         if (rLocal == null || usage == null)
            return null;

         string s = rLocal.getID();
         if (isWildCard(s))
         {
            s = rLocal.getResourceRoot().appendAnchor(null);
         }

         JDFResourceLink rl = (JDFResourceLink)appendElement(rLocal.getLinkString(), rLocal.getNamespaceURI());
         rl.setTarget(rLocal);
         rl.setUsage(usage);
         rl.setProcessUsage(processUsage);

         // move the resource to the closest common ancestor if it is not already
         // an ancestor of this
         JDFNode parent = rLocal.getParentJDF();

         // move the resource to the closest common ancestor if it is not already
         // an ancestor of this
         while (parent != null && !parent.isAncestor(this))
         {
            parent = rLocal.getParentJDF();
            if (parent == null)
               break;

            parent = parent.getParentJDF();
            if (parent == null)
            {
               rl.deleteNode(); // cleanup
               throw new JDFException("JDFResourceLink appendResource resource is not in the same document");
            }

            rLocal = (JDFResource)parent.getCreateResourcePool().moveElement(rLocal, null);
         }

         return rl;
      }

      ///   
      ///	 <summary> * getPartMapVector - get the part map vector from the actual element
      ///	 *  </summary>
      ///	 * <param name="bComplete"> if true, expand all parts defined in PartIDKeys
      ///	 *  </param>
      ///	 * <returns> VJDFAttributeMap - map of all parts linked by this resourcelinkpool </returns>
      ///	 
      public virtual VJDFAttributeMap getPartMapVector(bool bComplete)
      {
         VJDFAttributeMap vMap = new VJDFAttributeMap();

         if (bComplete)
         {
            VString vKeys = getPartIDKeys();

            int keySize = vKeys.Count;
            ArrayList vvValues = new ArrayList();
            int[] pI = new int[keySize];
            int[] pISize = new int[keySize];

            for (int i = 0; i < keySize; i++)
            {
               if (EnumPartIDKey.getEnum((string)vKeys[i]) != null)
               {
                  vvValues.Add(getPartValues(JDFResource.EnumPartIDKey.getEnum(i)));

                  pI[i] = 0;
                  pISize[i] = ((ArrayList)vvValues[i]).Count;
               }
            }

            while (true)
            {
               JDFAttributeMap m = new JDFAttributeMap();
               bool bDone = false;

               for (int i = 0; i < keySize; i++)
               {
                  m.put((string)vKeys[i], (string)((ArrayList)vvValues[i])[pI[i]]);
               }

               vMap.Add(m);

               for (int n = 0; n < keySize; n++)
               {
                  if (++pI[n] >= pISize[n])
                  {
                     pI[n] = 0;

                     if (n == keySize - 1)
                     {
                        bDone = true;
                     }
                  }
                  else
                  {
                     break;
                  }
               }

               if (bDone)
               {
                  break;
               }
            }
         }
         else
         {
            VElement links = getPoolChildren(null, null, null);
            if (links != null)
            {
               for (int l = 0; l < links.Count; l++)
               {
                  JDFResourceLink link = (JDFResourceLink)links[l];
                  VJDFAttributeMap tempMap = link.getPartMapVector();

                  for (int i = 0; i < tempMap.Count; i++)
                  {
                     JDFAttributeMap mTmp = tempMap[i];
                     bool bFound = false;
                     bool bReplace = false;

                     for (int j = vMap.Count - 1; j >= 0; j--)
                     {
                        // backwards because of potential erasing
                        JDFAttributeMap mAtt = vMap[j];

                        if (!bReplace && mAtt.subMap(mTmp))
                        {
                           bFound = true;
                           break;
                        }

                        if (mTmp.subMap(mAtt))
                        {
                           if (bReplace)
                           {
                              vMap[j] = mTmp;
                           }
                           else
                           { // already replaced one, clear all other
                              // matches
                              vMap.Clear();
                           }

                           bReplace = true;
                        }
                     }

                     if (!bFound)
                     {
                        vMap.Add(mTmp);
                     }
                  }
               }
            }
         }

         return vMap;
      }

      ///   
      ///	 <summary> * get a vector of all part id keys linked
      ///	 *  </summary>
      ///	 * <returns> Vector </returns>
      ///	 
      public virtual VString getPartIDKeys()
      {
         VString vs = new VString();
         VElement links = getPoolChildren(null, null, null);
         if (links != null)
         {
            for (int i = 0; i < links.Count; i++)
            {
               JDFResourceLink link = (JDFResourceLink)links[i];
               VString keys = link.getLinkRoot().getPartIDKeys();

               for (int j = 0; j < keys.Count; j++)
               {
                  if (!vs.Contains(keys[j]))
                  {
                     vs.Add(keys[j]);
                  }
               }
            }
         }

         return vs;
      }

      ///   
      ///	 <summary> * GetPartValues - get a list of the values for attribute partType within the leaves of all linked resources
      ///	 *  </summary>
      ///	 * <param name="partType"> the attribute name you which to get the values
      ///	 *  </param>
      ///	 * <returns> Vector - vector with all values of the attribute partType </returns>
      ///	 
      public virtual ArrayList getPartValues(JDFResource.EnumPartIDKey partType)
      {
         ArrayList vs = new ArrayList();
         VElement links = getPoolChildren(null, null, null);
         if (links != null)
         {
            for (int i = 0; i < links.Count; i++)
            {
               JDFResourceLink link = (JDFResourceLink)links[i];
               VString keys = link.getLinkRoot().getPartValues(partType);

               for (int j = 0; j < keys.Count; j++)
               {
                  if (!vs.Contains(keys[j]))
                  {
                     vs.Add(keys[j]);
                  }
               }
            }
         }

         return vs;
      }

      ///   
      ///	 <summary> * Gets all children with the attribute <code>name, mAttrib, nameSpaceURI</code> out of the pool
      ///	 *  </summary>
      ///	 * <param name="name"> name of the Child </param>
      ///	 * <param name="mAttrib"> a attribute to search for </param>
      ///	 * <param name="nameSpaceURI"> the namespace uri
      ///	 *  </param>
      ///	 * <returns> VElement: a vector with all elements in the pool matching the conditions
      ///	 * 
      ///	 *         default: getPoolChildren(null, null, null) </returns>
      ///	 
      public virtual VElement getPoolChildren(string strName, JDFAttributeMap mAttrib, string nameSpaceURI)
      {
         VElement v = getPoolChildrenGeneric(strName, mAttrib, nameSpaceURI);
         if (v == null)
            return null;
         for (int i = v.Count - 1; i >= 0; i--)
         {
            if (!(v[i] is JDFResourceLink))
            {
               v.RemoveAt(i);
            }
         }
         return v.Count == 0 ? null : v;
      }

      ///   
      ///	 <summary> * get a child resource from the pool matching the parameters
      ///	 *  </summary>
      ///	 * <param name="i"> the index of the child, or -1 to make a new one. </param>
      ///	 * <param name="strName"> the name of the element </param>
      ///	 * <param name="mAttrib"> the attribute of the element </param>
      ///	 * <param name="nameSpaceURI"> the namespace to search in
      ///	 *  </param>
      ///	 * <returns> JDFElement: the pool child matching the above conditions </returns>
      ///	 
      public virtual JDFResourceLink getPoolChild(int i, string strName, JDFAttributeMap mAttrib, string nameSpaceURI)
      {
         JDFResourceLink resLink = null;

         int iLocal = i;

         VElement v = getPoolChildren(strName, mAttrib, nameSpaceURI);
         if (v != null)
         {
            int size = v.Count;
            if (iLocal < 0)
            {
               iLocal = size + iLocal;
               if (iLocal < 0)
               {
                  return null;
               }
            }

            if (size > iLocal)
            {
               resLink = (JDFResourceLink)v[iLocal];
            }
         }

         return resLink;
      }

      ///   
      ///	 <summary> * return a vector of unknown element nodenames
      ///	 * <p>
      ///	 * default: GetInvalidElements(true, 999999)
      ///	 *  </summary>
      ///	 * <param name="bIgnorePrivate"> used by JDFElement during the validation </param>
      ///	 * <param name="nMax"> maximum size of the returned vector </param>
      ///	 * <returns> Vector - vector of unknown element nodenames
      ///	 * 
      ///	 *         !!! Do not change the signature of this method </returns>
      ///	 
      public override VString getUnknownElements(bool bIgnorePrivate, int nMax)
      {
         return getUnknownPoolElements(JDFElement.EnumPoolType.ResourceLinkPool, nMax);
      }

      ///   
      ///	 <summary> * get inter-resource linked resource ids
      ///	 *  </summary>
      ///	 * <param name="vDoneRefs"> (null, used for recursion) </param>
      ///	 * <param name="bRecurse"> if true, also return recursively linked IDS </param>
      ///	 * <returns> vElement: the vector of referenced resource ids </returns>
      ///	 
      public override SupportClass.HashSetSupport getAllRefs(SupportClass.HashSetSupport vDoneRefs, bool bRecurse)
      {
         SupportClass.HashSetSupport vDoneRefsLocal = vDoneRefs;

         VElement vResourceLinks = getPoolChildren(null, null, null);
         if (vResourceLinks != null)
         {
            int size = vResourceLinks.Count;
            for (int i = 0; i < size; i++)
            {
               JDFResourceLink rl = (JDFResourceLink)vResourceLinks[i];
               if (!vDoneRefsLocal.Contains(rl))
               {
                  vDoneRefsLocal.Add(rl);
                  if (bRecurse)
                  {
                     JDFResource r = rl.getLinkRoot();
                     if (r != null && !vDoneRefsLocal.Contains(r))
                     {
                        vDoneRefsLocal = r.getAllRefs(vDoneRefsLocal, bRecurse);
                     }
                  }
               }
            }
         }

         return vDoneRefsLocal;
      }
   }
}
