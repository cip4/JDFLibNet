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
 * ==========================================================================
 * class JDFPipeParams extends JDFResource
 * ==========================================================================
 * @COPYRIGHT Heidelberger Druckmaschinen AG, 1999-2001
 * ALL RIGHTS RESERVED
 * @Author: sabjon@topmail.de   using a code generator
 * Warning! very preliminary test version. Interface subject to change without prior notice!
 * Revision history:    ... 
 */


namespace org.cip4.jdflib.jmf
{
   using System;
   using System.Collections;



   using JDFAutoPipeParams = org.cip4.jdflib.auto.JDFAutoPipeParams;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using VString = org.cip4.jdflib.core.VString;


   //----------------------------------
   public class JDFPipeParams : JDFAutoPipeParams
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFPipeParams
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFPipeParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFPipeParams
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFPipeParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFPipeParams
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFPipeParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      public override string ToString()
      {
         return "JDFPipeParams[  --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * Gets all ResourceLink children with the attribute name, mAttrib, nameSpaceURI from the pool
      ///	 *  </summary>
      ///	 * <param name="name"> name of the Child </param>
      ///	 * <param name="mAttrib"> a attribute to search for </param>
      ///	 * <returns> VElement: a vector with all resource links in the pool matching the conditions </returns>
      ///	 * @deprecated use getResourceLink() 
      ///	 
      [Obsolete("use getResourceLink()")]
      public VElement getResourceLinks(string nam, JDFAttributeMap mAttrib, string nameSpaceURI)
      {
         VElement v = getChildElementVector(nam, nameSpaceURI, mAttrib, true, 0, false);

         for (int i = v.Count - 1; i >= 0; i--)
         {
            JDFElement e = (JDFElement)v[i];
            if (!(e is JDFResourceLink))
            {
               v.RemoveAt(i);
            }
         }
         return v;
      }

      ///   
      ///	 <summary> * Gets the ResourceLink from the PipeParams element
      ///	 *  </summary>
      ///	 * <returns> VElement: a vector with all resource links in the pool matching the conditions </returns>
      ///	 
      public JDFResourceLink getResourceLink()
      {
         VElement v = getChildElementVector(null, null, null, true, 0, false);

         for (int i = 0; i < v.Count; i++)
         {
            KElement e = v.item(i);
            if (e is JDFResourceLink)
            {
               return (JDFResourceLink)e;
            }
         }
         return null;
      }

      ///   
      ///	 <summary> * get the vector of unknown element nodenames
      ///	 * <p>
      ///	 * default: GetUnknownElements(true, 999999)
      ///	 *  </summary>
      ///	 * <param name="bIgnorePrivate"> used by JDFElement during the validation !!! Do not change the signature of this method </param>
      ///	 * <param name="nMax"> maximum size of the returned vector </param>
      ///	 * <returns> Vector - vector of unknown element nodenames </returns>
      ///	 

      public override VString getUnknownElements(bool bIgnorePrivate, int nMax)
      {
         bool bIgnorePrivateLocal = bIgnorePrivate;

         if (bIgnorePrivateLocal) // dummy to soothe compiler warning
            bIgnorePrivateLocal = false;

         return getUnknownPoolElements(JDFElement.EnumPoolType.PipeParams, nMax);
      }

      ///   
      ///	 <summary> * get resource defined by <code>resName</code>, create if it doesn't exist
      ///	 *  </summary>
      ///	 * <param name="resName"> name of the resource to get/create </param>
      ///	 * <returns> JDFResource: the element </returns>
      ///	 
      public virtual JDFResource getCreateResource(string resName)
      {
         JDFResource r = null;
         KElement e = getCreateElement(resName, null, 0);
         if (e is JDFResource)
         {
            //
         }
         else
         {
            throw new JDFException("JDFPipeParams.getCreateResource tried to create a JDFElement instead of a JDFResource");
         }
         return r;
      }

      ///   
      ///	 <summary> * get resource defined by <code>resName</code>
      ///	 *  </summary>
      ///	 * <param name="resName"> name of the resource to get; if null get the resource that is linked by the reslink </param>
      ///	 * <returns> JDFResource: the element </returns>
      ///	 
      public virtual JDFResource getResource(string resName)
      {
         if (resName == null)
         {
            JDFResourceLink rl = getResourceLink();
            if (rl != null)
               return rl.getTarget();
            VElement v = getChildElementVector(null, null, null, true, 0, false);

            for (int i = 0; i < v.Count; i++)
            {
               KElement e = v.item(i);
               if (e is JDFResource)
               {
                  return (JDFResource)e;
               }
            }
            return null;
         }
         JDFResource r = null;
         KElement e2 = getElement(resName, null, 0);
         if (e2 is JDFResource)
         {
            r = (JDFResource)e2;
         }
         else
         {
            throw new JDFException("JDFPipeParams.getResource tried to return a JDFElement instead of a JDFResource");
         }
         return r;
      }

      ///   
      ///	 <summary> * append Resource
      ///	 *  </summary>
      ///	 * <param name="resName"> name of the resource to append </param>
      ///	 
      public virtual JDFResource appendResource(string resName)
      {
         KElement e = appendElement(resName, null);
         if (!(e is JDFResource))
         {
            throw new JDFException("JDFpipeParams.appendResource tried to return a JDFElement instead of a JDFResource: " + resName);
         }
         return (JDFResource)e;
      }

      ///   
      ///	 <summary> * append ResourceLink
      ///	 *  </summary>
      ///	 * <param name="linkName"> name of the ResourceLink to append a link for </param>
      ///	 * <param name="bInput"> if true, the link is an input link </param>
      ///	 * <returns> JDFResourceLink: the appended element </returns>
      ///	 
      public virtual JDFResourceLink appendResourceLink(string linkName, bool bInput)
      {
         string linkNameLocal = linkName;

         if (!linkNameLocal.EndsWith("Link"))
            linkNameLocal += "Link";

         JDFResourceLink rl = null;
         if (getResourceLink() != null)
            throw new JDFException("JDFpipeParams.appendResourceLink tried to append an additional link");

         KElement e = appendElement(linkNameLocal, null);
         if (e is JDFResourceLink)
         {
            rl = (JDFResourceLink)e;
            rl.setUsage(bInput ? EnumUsage.Input : EnumUsage.Output);
         }
         else
         {
            throw new JDFException("JDFpipeParams.appendResourceLink tried to return a JDFElement instead of a JDFResourceLink: " + linkNameLocal);
         }

         return rl;
      }

      ///   
      ///	 <summary> * apply the parameters in this to all appropriate resources in parentNode or one of parentNode's children
      ///	 *  </summary>
      ///	 * <param name="parentNode"> the node to search in TODO implement resource handling </param>
      ///	 
      public virtual void applyPipeToNode(JDFNode parentNode)
      {
         if (parentNode == null)
            return;
         VElement vNodes = parentNode.getvJDFNode(null, null, false);

         int size = vNodes.Count;
         for (int i = 0; i < size; i++)
         {
            JDFNode node = (JDFNode)vNodes[i];
            if (!matchesNode(node))
               continue;
            JDFElement.EnumNodeStatus status = getStatus(); // TODO: set
            // Status
            node.setStatus(status);

            // final boolean isIncremental = (getUpdateMethod () ==
            // EnumUpdateMethod.Incremental);
            double dAmount = -1.0;
            JDFResourceLink rl = getResourceLink();

            if (rl != null)
            {
               JDFResourceLink rlNode = node.getLink(0, rl.Name, new JDFAttributeMap(AttributeName.RREF, rl.getrRef()), null);
               if (rlNode == null)
                  throw new JDFException("Applying pipeparams to inconsistent node: missing resourcelink: " + rl.Name);

               VJDFAttributeMap vMap = rl.getPartMapVector();
               if (vMap == null)
               {
                  vMap = new VJDFAttributeMap();
                  vMap.Add(null);
               }
               for (int j = 0; j < vMap.Count; j++)
               {
                  JDFAttributeMap map = vMap[j];
                  dAmount = rl.getActualAmount(map);
                  rlNode.setActualAmount(dAmount, map);
               }
            }
         }
      }

      ///   
      ///	 * <param name="node">
      ///	 * @return </param>
      ///	 
      private bool matchesNode(JDFNode node)
      {
         if (node == null)
            return false;
         if (hasAttribute(AttributeName.JOBID) && !getJobID().Equals(node.getJobID(true)))
            return false;
         if (hasAttribute(AttributeName.JOBPARTID) && !getJobPartID().Equals(node.getJobPartID(false)))
            return false;
         return true;
      }
   }
}
