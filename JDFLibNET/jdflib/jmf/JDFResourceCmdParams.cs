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
 * class JDFResourceCmdParams extends JDFResource
 * ==========================================================================
 * @COPYRIGHT Heidelberger Druckmaschinen AG, 1999-2001
 * ALL RIGHTS RESERVED
 * @Author sabjon@topmail.de   using a code generator
 * Warning! very preliminary test version. Interface subject to change without prior notice!
 * Revision history:    ... 
 */


namespace org.cip4.jdflib.jmf
{
   using System.Collections;



   using JDFAutoResourceCmdParams = org.cip4.jdflib.auto.JDFAutoResourceCmdParams;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFNodeInfo = org.cip4.jdflib.core.JDFNodeInfo;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using INodeIdentifiable = org.cip4.jdflib.ifaces.INodeIdentifiable;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using NodeIdentifier = org.cip4.jdflib.node.JDFNode.NodeIdentifier;
   using JDFResourceLinkPool = org.cip4.jdflib.pool.JDFResourceLinkPool;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using EnumPartUsage = org.cip4.jdflib.resource.JDFResource.EnumPartUsage;
   using StringUtil = org.cip4.jdflib.util.StringUtil;

   ///
   /// <summary> * class that wraps a ResourceCmdParams element
   /// * 
   /// * @author prosirai
   /// *  </summary>
   /// 
   public class JDFResourceCmdParams : JDFAutoResourceCmdParams, INodeIdentifiable
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * container for applying resource commands to commands
      ///	 * @author Rainer Prosi, Heidelberger Druckmaschinen
      ///	 * </summary>
      ///	 
      protected internal class ApplyCommand
      {

         private JDFResourceCmdParams enclosingInstance;

         public ApplyCommand(JDFResourceCmdParams pEnclosingInstance)
         {
            enclosingInstance = pEnclosingInstance;
         }
         ///      
         ///		 <summary> * apply the parameters in this to all appropriate resources in parentNode or one of parentNode's children
         ///		 *  </summary>
         ///		 * <param name="parentNode"> the node to search in </param>
         ///		 
         internal virtual void applyResourceCommand(JDFNode parentNode)
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
               JDFResource resCmd = enclosingInstance.getResource(null);
               if (resCmd == null)
                  continue;

               bool isIncremental = (enclosingInstance.getUpdateMethod() == EnumUpdateMethod.Incremental);

               // commented out, statements have no effect
               // double dAmount = -1.0;
               // if (hasAttribute (AttributeName.PRODUCTIONAMOUNT))
               // {
               // dAmount = getProductionAmount (); // TODO: set ProductionAmount
               // }
               // final String strProcessUsage = getProcessUsage(); // TODO: use
               // ProcessUsage
               // final JDFElement.EnumNodeStatus status = getStatus(); // TODO:
               // set Status

               VJDFAttributeMap vamParts = enclosingInstance.getPartMapVector();
               JDFResource resTarget = getTargetResource(node);
               if (resTarget == null)
               {
                  resTarget = createNewResource(node, resCmd);
                  if (resTarget == null)
                     continue;
               }

               // get the most granular list of partIDKeys from the cmd or resource
               VString vsPartIDKeys = resTarget.getPartIDKeys();
               VString vsPartIDKeysCmd = resCmd.getPartIDKeys();
               int sizTarget = vsPartIDKeys == null ? 0 : vsPartIDKeys.Count;
               int sizCmd = vsPartIDKeysCmd == null ? 0 : vsPartIDKeysCmd.Count;
               if (sizCmd > sizTarget)
                  vsPartIDKeys = vsPartIDKeysCmd;

               int sizeParts = vamParts == null ? 1 : vamParts.Count;
               for (int j = 0; j < sizeParts; j++)
               {
                  JDFAttributeMap amParts = vamParts == null ? null : vamParts[j];
                  JDFResource resTargetPart = resTarget.getCreatePartition(amParts, vsPartIDKeys);
                  if (resTargetPart == null)
                     continue;

                  string id = resTargetPart.getID();
                  if (!isIncremental)
                  {
                     JDFAttributeMap map = resTargetPart.getPartMap();
                     resTargetPart.flush();
                     resTargetPart.setAttributes(map);
                  }

                  JDFResource resCmdPart = resCmd.getPartition(amParts, EnumPartUsage.Implicit);
                  JDFAttributeMap map2 = resCmdPart.getAttributeMap();
                  VString keys = map2.getKeys();
                  if (keys != null)
                  {
                     int keySize = keys.Count;
                     for (int k = 0; k < keySize; k++)
                     {
                        string key = keys[k];
                        string @value = map2.get(key);
                        if (@value == null || JDFConstants.EMPTYSTRING.Equals(@value))
                        {
                           resCmdPart.removeAttribute(key);
                           resTargetPart.removeAttribute(key);
                        }
                     }
                  }

                  resTargetPart.mergeElement(resCmdPart, false);
                  resTarget.setID(id);
               }

               if (sizeParts > 0 && resTarget is JDFNodeInfo)
               {
                  fixNodeStatusFromNodeInfo(node, resTarget);
               }
            }
         }

         ///      
         ///		 * <param name="node"> </param>
         ///		 * <returns> the target resource </returns>
         ///		 
         private JDFResource getTargetResource(JDFNode node)
         {
            if (node == null)
               return null;
            JDFResourceLinkPool rlp = node.getResourceLinkPool();
            if (rlp == null)
               return null;
            string resID = enclosingInstance.getResourceID();
            if (resID != null && !resID.Equals(""))
            {
               VElement vRes = rlp.getLinkedResources(null, null, new JDFAttributeMap(AttributeName.ID, resID), false);
               if (vRes.Count > 0)
                  return (JDFResource)vRes[0];
            }

            string resName = enclosingInstance.getResourceName();
            if (resName != null && !resName.Equals(""))
            {
               VElement vRes = rlp.getLinkedResources(resName, null, null, false);
               if (vRes.Count > 0)
                  return (JDFResource)vRes[0];

               // TODO link usage, process usage etc.

            }
            return null;
         }

         ///      
         ///		 * <param name="node"> </param>
         ///		 * <returns> true if it matches </returns>
         ///		 
         private bool matchesNode(JDFNode node)
         {
            if (node == null)
               return false;
            bool bMatch = true;
            string jobID = StringUtil.getNonEmpty(enclosingInstance.getJobID());
            if (jobID != null)
               bMatch = jobID.Equals(node.getJobID(true));
            if (!bMatch)
               return false;
            string jobPartID = StringUtil.getNonEmpty(enclosingInstance.getJobPartID());
            if (jobPartID != null)
               bMatch = jobPartID.Equals(node.getJobPartID(true));
            return bMatch;
         }

         ///      
         ///		 * <param name="node"> </param>
         ///		 * <param name="resCmd"> </param>
         ///		 * <returns> the new resource </returns>
         ///		 
         private JDFResource createNewResource(JDFNode node, JDFResource resCmd)
         {
            JDFResource resTarget = null;
            EnumUsage u = enclosingInstance.getUsage();
            if (u != null)
            {
               resTarget = (JDFResource)node.getCreateResourcePool().copyElement(resCmd, null);
               JDFResourceLink rl = node.linkResource(resTarget, u, null);
               rl.copyAttribute(AttributeName.PROCESSUSAGE, enclosingInstance); //JDFResourceCmdParams.this);
               resTarget = getTargetResource(node);
            }
            return resTarget;
         }

         ///      
         ///		 * <param name="node"> the jdf node </param>
         ///		 * <param name="resTarget"> </param>
         ///		 
         private void fixNodeStatusFromNodeInfo(JDFNode node, JDFResource resTarget)
         {
            EnumNodeStatus nodeStatus = node.getStatus();
            if (!EnumNodeStatus.Part.Equals(nodeStatus) && !EnumNodeStatus.Pool.Equals(node.getStatus()))
            {
               node.setStatus(EnumNodeStatus.Part);
               JDFNodeInfo ni = (JDFNodeInfo)resTarget;
               if (!ni.hasAttribute(AttributeName.NODESTATUS))
                  ni.setNodeStatus(nodeStatus);
            }
         }

      }

      ///   
      ///	 <summary> * Constructor for JDFResourceCmdParams
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFResourceCmdParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFResourceCmdParams
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFResourceCmdParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFResourceCmdParams
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFResourceCmdParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      ///   
      ///	 <summary> * toString()
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public override string ToString()
      {
         return "JDFResourceCmdParams[  --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * get resource defined by <code>resName</code>, create if it doesn't exist
      ///	 *  </summary>
      ///	 * <param name="resName"> name of the resource to get/create </param>
      ///	 * <returns> JDFResource the element </returns>
      ///	 
      public virtual JDFResource getCreateResource(string resName)
      {
         JDFResource r = null;
         KElement e = getCreateElement(resName, JDFConstants.EMPTYSTRING, 0);
         if (!(e is JDFResource))
         {
            throw new JDFException("JDFResourceCmdParams.getCreateResource tried to create a JDFElement instead of a JDFResource");
         }
         return r;
      }

      ///   
      ///	 <summary> * get resource defined by <code>resNam</code>
      ///	 *  </summary>
      ///	 * <param name="resName"> name of the resource to get, if null get the one and only resource </param>
      ///	 * <returns> JDFResource the element, null if none exists </returns>
      ///	 
      public virtual JDFResource getResource(string resName)
      {
         if (resName != null)
         {
            KElement e = getElement(resName, null, 0);
            if (e is JDFResource)
            {
               return (JDFResource)e;
            }
         }
         else
         {
            string resName2 = getResourceName();
            if (resName2 != null && !resName2.Equals(""))
               return getResource(resName2);
            KElement e2 = getFirstChildElement();
            while (e2 != null)
            {
               if (e2 is JDFResource)
                  return (JDFResource)e2;
               e2 = e2.getNextSiblingElement();
            }
         }
         return null;
      }

      ///   
      ///	 <summary> * Append Resource
      ///	 *  </summary>
      ///	 * <param name="resName"> name of the resource to append </param>
      ///	 * <returns> JDFResource the element </returns>
      ///	 
      public virtual JDFResource appendResource(string resName)
      {
         KElement e = appendElement(resName, null);
         if (!(e is JDFResource))
         {
            throw new JDFException("JDFResourceCMDParams.appendResource tried to return a JDFElement instead of a JDFResource");
         }
         return (JDFResource)e;
      }

      ///   
      ///	 <summary> * return the vector of unknown element nodenames
      ///	 * <p>
      ///	 * default: GetInvalidElements(true, 999999)<br>
      ///	 * !!! Do not change the signature of this method
      ///	 *  </summary>
      ///	 * <param name="bIgnorePrivate"> used by JDFElement during the validation </param>
      ///	 * <param name="nMax"> maximum number of elements to get
      ///	 *  </param>
      ///	 * <returns> Vector - vector of unknown element nodenames </returns>
      ///	 
      public override VString getUnknownElements(bool bIgnorePrivate, int nMax)
      {
         return getUnknownPoolElements(JDFElement.EnumPoolType.ResourcePool, nMax);
      }

      ///   
      ///	 <summary> * get part map vector
      ///	 *  </summary>
      ///	 * <returns> VJDFAttributeMap: vector of attribute maps, one for each part </returns>
      ///	 
      public override VJDFAttributeMap getPartMapVector()
      {
         return base.getPartMapVector();
      }

      ///   
      ///	 <summary> * set all parts to those defined by vParts
      ///	 *  </summary>
      ///	 * <param name="vParts"> vector of attribute maps for the parts </param>
      ///	 
      public override void setPartMapVector(VJDFAttributeMap vParts)
      {
         base.setPartMapVector(vParts);
      }

      ///   
      ///	 <summary> * set all parts to those define by mPart
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

      ///   
      ///	 <summary> * apply the parameters in this to all appropriate resources in parentNode or one of parentNode's children
      ///	 * if no matching resource exists in the node, Usage MUST be set in this JDFResourceCmdParams, 
      ///	 * otherwise it is not possible to correctly link the newly created resource
      ///	 *  </summary>
      ///	 * <param name="parentNode"> the node to search in </param>
      ///	 
      public virtual void applyResourceCommand(JDFNode parentNode)
      {
         new ApplyCommand(this).applyResourceCommand(parentNode);
      }

      ///   
      ///	 <summary> * gets the NodeIdetifier that matches this
      ///	 *  </summary>
      ///	 * <returns> <seealso cref="NodeIdentifier"/> the matching NodeIdentifier </returns>
      ///	 
      public virtual NodeIdentifier getIdentifier()
      {
         return new NodeIdentifier(getJobID(), getJobPartID(), getPartMapVector());
      }

      //    ---------------------------------------------------------------------
      //	Methods for Attribute Usage
      //	--------------------------------------------------------------------- 
      ///   
      ///	  <summary> * (5) set attribute Usage </summary>
      ///	  * <param name="enumVar">  the enumVar to set the attribute to </param>
      ///	  
      public virtual void setUsage(JDFResourceLink.EnumUsage enumVar)
      {
         setAttribute(AttributeName.USAGE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///   
      ///	  <summary> * (9) get attribute Usage </summary>
      ///	  * <returns> the value of the attribute </returns>
      ///	  
      public virtual JDFResourceLink.EnumUsage getUsage()
      {
         return JDFResourceLink.EnumUsage.getEnum(getAttribute(AttributeName.USAGE, null, null));
      }

      ///   
      ///	 * <seealso cref= org.cip4.jdflib.ifaces.INodeIdentifiable#setIdentifier(org.cip4.jdflib.node.JDFNode.NodeIdentifier) </seealso>
      ///	 * <param name="ni"> </param>
      ///	 
      public virtual void setIdentifier(NodeIdentifier ni)
      {
         NodeIdentifier niLocal = ni;

         if (niLocal == null)
            niLocal = new NodeIdentifier();

         setJobID(niLocal.getJobID());
         setJobPartID(niLocal.getJobPartID());
         setPartMapVector(niLocal.getPartMapVector());
      }
   }
}
