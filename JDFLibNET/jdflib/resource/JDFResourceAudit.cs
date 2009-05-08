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
 * JDFResource.cs
 * Last changes
 * 2001-07-30   Torsten Kaehlert - delete isNull() and throwNull() methods in parent class KNode
 *              TKAE20010730
 * 2002-02-08   Kai Mattern - check added to GetCreator method
 * 2002-02-21   Kai Mattern - changed isValid in respect to C++ lib (refer to C++ for further details)
 * 2002-02-21   Kai Mattern - added ValidID in respect to C++ lib (refer to C++ for further details)
 * 2001-02-21   Kai Mattern - added ValidStatus in respect to C++ lib (refer to C++ for further details)
 * 2002-02-25   Kai Mattern - added method RemoveFromSpawnIDs
 * 2002-02-25   Kai Mattern - added Valid SpawnIDs
 * 2002-02-25   Kai Mattern - added SpawnIDs to optional Attributes
 * 2002-11-25   Kai Mattern - added UpdateLink() */

namespace org.cip4.jdflib.resource
{
   using System;
   using System.Collections;



   using JDFAutoResourceAudit = org.cip4.jdflib.auto.JDFAutoResourceAudit;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;

   public class JDFResourceAudit : JDFAutoResourceAudit
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFResourceAudit
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFResourceAudit(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFResourceAudit
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFResourceAudit(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFResourceAudit
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFResourceAudit(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      ///   
      ///	 <summary> * add a link to the new resource
      ///	 *  </summary>
      ///	 * <param name="r"> the resource that is valid after modification<br>
      ///	 *            if r is not specified, return the link that already exists </param>
      ///	 * <returns> the ResourceLink object in the ResourceAudit that points to r </returns>
      ///	 * @deprecated use addNewOldLink(true,...) 
      ///	 
      [Obsolete("use addNewOldLink(true,...)")]
      public virtual JDFResourceLink addNewLink(JDFResource r, bool bInput)
      {
         return addNewOldLink(true, r, bInput);
      }

      ///   
      ///	 <summary> * add a link to the new resource
      ///	 *  </summary>
      ///	 * <param name="r"> the resource that is valid after modification<br>
      ///	 *            if r is not specified, return the link that already exists </param>
      ///	 * <returns> the ResourceLink object in the ResourceAudit that points to r </returns>
      ///	 * @deprecated use addNewOldLink(false,...)
      ///	 *  
      ///	 
      [Obsolete("use addNewOldLink(false,...)")]
      public virtual JDFResourceLink addOldLink(JDFResource r, bool bInput)
      {
         return addNewOldLink(false, r, bInput);
      }

      ///   
      ///	 <summary> * add a link to one of the resources
      ///	 *  </summary>
      ///	 * <param name="bNew"> new or original? </param>
      ///	 * <param name="r"> the resource that was valid before modification </param>
      ///	 * <param name="bInput"> usage of the resource </param>
      ///	 * <returns> the ResourceLink object in the ResourceAudit that points to r </returns>
      ///	 * @deprecated use addNewOldLink(bNew, r, bInput ? EnumUsage.Input : EnumUsage.Output); 
      ///	 

      [Obsolete("use addNewOldLink(bNew, r, bInput ? EnumUsage.Input : EnumUsage.Output);")]
      public virtual JDFResourceLink addNewOldLink(bool bNew, JDFResource r, bool bInput)
      {
         return addNewOldLink(bNew, r, bInput ? EnumUsage.Input : EnumUsage.Output);
      }

      ///   
      ///	 <summary> * add a link to one of the resources
      ///	 *  </summary>
      ///	 * <param name="bNew"> true - new link, false - original link </param>
      ///	 * <param name="r"> the resource that was valid before modification </param>
      ///	 * <param name="usage"> usage of the resource </param>
      ///	 * <returns> the ResourceLink object in the ResourceAudit that points to r </returns>
      ///	 

      public virtual JDFResourceLink addNewOldLink(bool bNew, JDFResource r, EnumUsage usage)
      {
         VElement v = getChildElementVector(null, null, null, true, 0, false);
         int iNew = bNew ? 0 : 1;
         for (int i = v.Count - 1; i >= 0; i--)
         {
            if (!(v[i] is JDFResourceLink))
               v.RemoveAt(i);
         }

         if (v.Count != iNew)
         {
            throw new JDFException("JDFResourceLink::AddNewOldLink invalid  ResourceAudit");
         }
         JDFResourceLink l = (JDFResourceLink)appendElement(r.getLinkString(), JDFConstants.EMPTYSTRING);
         l.setTarget(r);
         l.setUsage(usage);
         return l;
      }

      ///   
      ///	 <summary> * add a link to the new resource
      ///	 *  </summary>
      ///	 * <returns> the ResourceLink object in the ResourceAudit </returns>
      ///	 
      public virtual JDFResourceLink getNewLink()
      {
         return getNewOldLink(true);
      }

      ///   
      ///	 <summary> * add a link to the new resource
      ///	 *  </summary>
      ///	 * <returns> the ResourceLink object in the ResourceAudit </returns>
      ///	 
      public virtual JDFResourceLink getOldLink()
      {
         return getNewOldLink(false);
      }

      ///   
      ///	 <summary> * add a link to one of the resources
      ///	 *  </summary>
      ///	 * <param name="bNew"> new or original? </param>
      ///	 * <param name="r"> the resource that was valid before modification<br>
      ///	 *            if r is not specified, return the link that already exists </param>
      ///	 * <returns> the ResourceLink object in the ResourceAudit that points to r </returns>
      ///	 
      public virtual JDFResourceLink getNewOldLink(bool bNew)
      {
         VElement v = getChildElementVector(null, null, null, true, 0, false);
         int iNew = bNew ? 0 : 1;
         // remove any non-reslinks, e.g. comments
         for (int i = v.Count - 1; i >= 0; i--)
         {
            if (!(v[i] is JDFResourceLink))
               v.RemoveAt(i);
         }

         if (v.Count < iNew)
         {
            return null;
         }

         return (JDFResourceLink)v[iNew];
      }

      ///   
      ///	 <summary> * replace
      ///	 *  </summary>
      ///	 * <param name="newLink"> node to insert </param>
      ///	 * <returns> the updated element </returns>
      ///	 
      public virtual JDFResourceLink updateLink(JDFResourceLink newLink)
      {
         VElement v = getResourceLinkVector();

         if (v.Count > 2)
         {
            throw new JDFException("JDFResourceLink.UpdateLink invalid  ResourceAudit");
         }

         // update of an update, delete the first element and assume the second
         // is the real original
         if (v.Count > 1)
         {
            (v[0]).deleteNode();
            v.Remove(v[0]);
         }

         // the updated link is the first
         JDFResourceLink resLink = (JDFResourceLink)copyElement(newLink, null);

         if (v.Count > 0)
         {
            resLink = (JDFResourceLink)insertBefore(resLink, v[0]);
         }
         return resLink;
      }

      ///   
      ///	 <summary> * Get the vector of ResourceLinks
      ///	 *  </summary>
      ///	 * <returns> VElement: the resource links in this </returns>
      ///	 
      public virtual VElement getResourceLinkVector()
      {
         VElement v = getChildElementVector(null, null, null, true, 0, false);
         for (int i = v.Count - 1; i >= 0; i--)
         {
            JDFElement e = (JDFElement)v[i];

            if (!(e is JDFResourceLink))
            {
               v.Remove(v[i]);
            }
         }
         return v;
      }

      ///   
      ///	 <summary> * return a vector of unknown element nodenames
      ///	 * <p>
      ///	 * default: getUnknownElements(true, 999999)
      ///	 *  </summary>
      ///	 * <param name="bIgnorePrivate"> used by JDFElement during the validation </param>
      ///	 * <param name="nMax"> maximum size of the returned vector </param>
      ///	 * <returns> Vector - vector of unknown element nodenames
      ///	 * 
      ///	 *         !!! Do not change the signature of this method </returns>
      ///	 
      public override VString getUnknownElements(bool bIgnorePrivate, int nMax)
      {
         return getUnknownPoolElements(EnumPoolType.ResourceLinkPool, nMax);
      }

      ///   
      ///	 <summary> * get list of missing elements
      ///	 *  </summary>
      ///	 * <param name="nMax"> maximum size of the returned vector </param>
      ///	 
      public override VString getMissingElements(int nMax)
      {
         VString vs = getTheElementInfo().requiredElements();
         vs = getMissingElementVector(vs, nMax);
         VElement v2 = getChildElementVector_KElement(null, null, null, true, 0);
         int n = 0;
         for (int i = 0; i < v2.Count; i++)
         {
            if (v2[i] is JDFResourceLink)
               n++;
         }
         if (n == 0)
            vs.Add("ResourceLink");

         return vs;
      }

      // the following are prerelease errata in JDF 1.3

      ///   
      ///	 <summary> * set all parts to those defined in vParts
      ///	 *  </summary>
      ///	 * <param name="vParts"> vector of attribute maps for the parts </param>
      ///	 
      public override void setPartMapVector(VJDFAttributeMap vParts)
      {
         base.setPartMapVector(vParts);
      }

      ///   
      ///	 <summary> * set all parts to those defined by mPart
      ///	 *  </summary>
      ///	 * <param name="mPart"> attribute map for the part to set </param>
      ///	 
      public override void setPartMap(JDFAttributeMap mPart)
      {
         base.setPartMap(mPart);
      }

      ///   
      ///	 <summary> * remove the part defined by mPart
      ///	 *  </summary>
      ///	 * <param name="mPart"> attribute map for the part to remove </param>
      ///	 
      public override void removePartMap(JDFAttributeMap mPart)
      {
         base.removePartMap(mPart);
      }

      ///   
      ///	 <summary> * check whether the part defined in mPart is included
      ///	 *  </summary>
      ///	 * <param name="mPart"> attribute map to look for </param>
      ///	 * <returns> boolean - returns true if the part exists </returns>
      ///	 
      public override bool hasPartMap(JDFAttributeMap mPart)
      {
         return base.hasPartMap(mPart);
      }
   }
}
