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


namespace org.cip4.jdflib.util
{
   using System.Collections;
   using System.Collections.Generic;


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFAudit = org.cip4.jdflib.core.JDFAudit;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFRefElement = org.cip4.jdflib.core.JDFRefElement;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using EnumAttributeType = org.cip4.jdflib.core.AttributeInfo.EnumAttributeType;
   using EnumNodeStatus = org.cip4.jdflib.core.JDFElement.EnumNodeStatus;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using JDFAncestor = org.cip4.jdflib.node.JDFAncestor;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using JDFSpawned = org.cip4.jdflib.node.JDFSpawned;
   using EnumActivation = org.cip4.jdflib.node.JDFNode.EnumActivation;
   using JDFAncestorPool = org.cip4.jdflib.pool.JDFAncestorPool;
   using JDFAuditPool = org.cip4.jdflib.pool.JDFAuditPool;
   using JDFResourcePool = org.cip4.jdflib.pool.JDFResourcePool;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using EnumPartUsage = org.cip4.jdflib.resource.JDFResource.EnumPartUsage;
   using EnumSpawnStatus = org.cip4.jdflib.resource.JDFResource.EnumSpawnStatus;
   using JDFIdentical = org.cip4.jdflib.resource.process.JDFIdentical;

   ///
   /// <summary> * @author Rainer Prosi This class is used when spawning a JDF node it summarizes all spawning routines the had been
   /// *         part of JDF Node </summary>
   /// 
   public class JDFSpawn
   {

      private JDFNode node;

      ///   
      ///	 <summary> * if true, reduce read only partitions, else retain entire resource </summary>
      ///	 
      public bool bSpawnROPartsOnly = true;

      ///   
      ///	 <summary> * if true, allow multiple rw spawning of resources note that this feature causes race conditions when merging </summary>
      ///	 
      public bool bSpawnRWPartsMultiple = false;

      ///   
      ///	 <summary> * if true, copy node info </summary>
      ///	 
      public bool bCopyNodeInfo = true;

      ///   
      ///	 <summary> * if true, copy customer info </summary>
      ///	 
      public bool bCopyCustomerInfo = true;

      ///   
      ///	 <summary> * if true, copy comments </summary>
      ///	 
      public bool bCopyComments = false;

      ///   
      ///	 <summary> * if true, ensure sufficient partitioning of rw resources, else do not add missing partitions </summary>
      ///	 
      public bool bFixResources = true;
      public string parentURL = null;
      public string spawnURL = null;
      ///   
      ///	 <summary> * list of all resources to copy rw </summary>
      ///	 
      public VString vRWResources_in = null;
      ///   
      ///	 <summary> * list of partitions to spawn </summary>
      ///	 
      public VJDFAttributeMap vSpawnParts = null;

      ///   
      ///	 <summary> * exception id for multiple merge attempt </summary>
      ///	 
      public const int exAlreadyMerged = 10001;
      ///   
      ///	 <summary> * exception id for multiple rw spawns </summary>
      ///	 
      public const int exMultiSpawnRW = 10002;

      ///   
      ///	 <summary> *  </summary>
      ///	 * <param name="nodeToSpawn"> the node to be spawned </param>
      ///	 
      public JDFSpawn(JDFNode nodeToSpawn)
      {
         node = nodeToSpawn;
      }

      ///   
      ///	 <summary> * spawn a node; url is the file name of the new node, vRWResourceUsage is the vector of Resources Usages (or Names
      ///	 * if no usage exists for the process) that are spawned RW, all others are spawned read only; vParts is the vector
      ///	 * of part maps that are to be spawned, defaults to no part, i.e. the whole thing
      ///	 *  </summary>
      ///	 * <param name="parentURL"> </param>
      ///	 * <param name="spawnURL"> : URL of the spawned JDF file </param>
      ///	 * <param name="vRWResources"> : vector of resource names and Usage / ProcessUsage that are spawned as rw <br>
      ///	 *            the format is one of:<br>
      ///	 *            ResName:Input<br>
      ///	 *            ResName:Output<br>
      ///	 *            ResName:ProcessUsage<br> </param>
      ///	 * <param name="VJDFAttributeMap"> vSpawnParts: vector of mAttributes that describe the parts to spawn, only valid
      ///	 *            PartIDKeys are allowed </param>
      ///	 * <param name="bSpawnROPartsOnly"> if true, only the parts of RO resources that are specified in vParts are spawned, else
      ///	 *            the complete resource is spawned </param>
      ///	 * <param name="bCopyNodeInfo"> copy the NodeInfo elements into the Ancestors </param>
      ///	 * <param name="bCopyCustomerInfo"> copy the CustomerInfo elements into the Ancestors </param>
      ///	 * <param name="bCopyComments"> copy the Comment elements into the Ancestors
      ///	 *  </param>
      ///	 * <returns> The spawned node
      ///	 * @since 050831 added bCopyComments @ tbd enhance nested spawning of partitioned nodes
      ///	 * 
      ///	 *        default: spawn(parentURL, null, null, null, false, false, false, false) </returns>
      ///	 
      public virtual JDFNode spawn()
      {
         // need copy in order to fix up 1.3 NodeInfo spawn
         VString vRWResources = vRWResources_in == null ? new VString() : vRWResources_in;
         VJDFAttributeMap vLocalSpawnParts = vSpawnParts;

         if (!bSpawnRWPartsMultiple)
            checkMultipleRWRes();

         // create a new jdf document that contains the node to be spawned
         JDFDoc docOut = new JDFDoc(ElementName.JDF);
         JDFNode rootOut = (JDFNode)docOut.getRoot();

         // prepare the nodeinfos in main prior to spawning
         prepareNodeInfos();

         // merge this node into it
         rootOut.mergeNode(node, false); // "copy" this node into the new created
         // document
         string spawnID = "Sp" + JDFElement.uniqueID(0); // create a spawn
         // id for this
         // transaction
         rootOut.setSpawnID(spawnID);
         rootOut.setVersion(node.getVersion(true));

         // need copy in order to fix up 1.3 NodeInfo spawn
         const string nodeInfoNonAncestor = "NodeInfo:Input"; // named process
         // usage
         if (!vRWResources.Contains(nodeInfoNonAncestor))
         {
            vRWResources.Add(nodeInfoNonAncestor); // the local nodeinfo
            // MUST always be rw
         }

         JDFNode spawnParentNode = null;
         // we want to spawn a partition
         if (vLocalSpawnParts != null && !vLocalSpawnParts.IsEmpty())
         {
            spawnParentNode = node;
            // don't copy the whole history along
            rootOut.getAuditPool().flush();

            // The AncestorPool of the original JDF contains the appropriate
            // Part elements
            JDFAncestorPool ancpool = docOut.getJDFRoot().getAncestorPool();
            VJDFAttributeMap preSpawnedParts = new VJDFAttributeMap();

            if (ancpool != null)
            {
               preSpawnedParts = ancpool.getPartMapVector();
            }
            // 150102 RP add AncestorPool pre spawn part handling
            if (!preSpawnedParts.IsEmpty())
            {
               // allParts is the vector of all parts that the spawned
               // AncestorPool will contain
               VJDFAttributeMap allParts = new VJDFAttributeMap();

               for (int psp = 0; psp < preSpawnedParts.Count; psp++)
               {
                  List<JDFAttributeMap> vAttrib = vLocalSpawnParts.getVector();
                  VJDFAttributeMap tmpParts = new VJDFAttributeMap(vAttrib.ToArray());
                  tmpParts.overlapMap(preSpawnedParts[psp]);
                  allParts.appendUnique(tmpParts);
               }
               vLocalSpawnParts = allParts;
            }
            // we arrived at a null vector of parts - that ain't no good
            if (vLocalSpawnParts.IsEmpty())
            {
               throw new JDFException("JDFNode.Spawn attempting to spawn incompatible partitions");
            }
            // Spawn a complete node -> no partition handling
         }
         else
         // Spawn a complete node -> no partition handling
         {
            spawnParentNode = node.getParentJDF();

            if (spawnParentNode == null)
            {
               throw new JDFException("JDFNode.Spawn cannot spawn unpartitioned root node");
            }
         }

         // setup the ancestor nodes
         setSpawnParent(rootOut, spawnParentNode);

         JDFSpawned spawnAudit = createSpawnAudit(rootOut, spawnID, spawnParentNode);

         // find resources that must be copied
         addSpawnedResources(rootOut, spawnAudit);
         finalizeSpawn(vLocalSpawnParts, rootOut, spawnAudit);

         // return the spawned node
         return rootOut;
      }

      ///   
      ///	 <summary> * prepare all nodeInfos of node for partitioned spawn </summary>
      ///	 
      private void prepareNodeInfos()
      {
         if (vSpawnParts == null)
            return;
         VElement vn = node.getvJDFNode(null, null, false);
         int size = vn.Count;
         // fill all resources and all links of all children into vResPool and
         // links
         for (int i = 0; i < size; i++)
         {
            JDFNode vnNode_i = (JDFNode)vn[i];
            vnNode_i.prepareNodeInfo(vSpawnParts); // make sure we have a
            // nodeinfo in all spawned
            // nodes of main in case we
            // have to merge stati
         }
      }

      ///   
      ///	 <summary> * check for multiple rw resources and throw a JDFException if an rw resource </summary>
      ///	 
      private void checkMultipleRWRes()
      {
         // only check if not explicitly requested not to check
         ICollection vCheck = checkSpawnedResources();
         if (vCheck != null)
         {
            string strIDs = "JDFNode.spawn: multiply spawned rw resources: ";
            VString vBad = new VString();
            IEnumerator iterCheck = vCheck.GetEnumerator();
            while (iterCheck.MoveNext())
            {
               vBad.appendUnique(((JDFResource)iterCheck.Current).getAttribute(AttributeName.ID));
            }
            strIDs += StringUtil.setvString(vBad, JDFConstants.BLANK, null, null);
            throw new JDFException(strIDs, exMultiSpawnRW);
         }
      }

      ///   
      ///	 <summary> * return the resources that would be spawned RW multiple times
      ///	 *  </summary>
      ///	 * <param name="VString"> vRWResourceUsage: vector of resource names and Usage / ProcessUsage that are spawned as rw <br>
      ///	 *            the format is one of:<br>
      ///	 *            ResName<br>
      ///	 *            ResName:Input<br>
      ///	 *            ResName:Output<br>
      ///	 *            ResName:ProcessUsage<br>
      ///	 *            ID<br> </param>
      ///	 * <param name="VJDFAttributeMap"> vParts: vector of JDFAttributeMaps that describe the parts to spawn
      ///	 *  </param>
      ///	 * <returns> Collection: set of resources or resource partitions that would be spawned rw multiple times null if all
      ///	 *         is well </returns>
      ///	 
      public virtual ICollection checkSpawnedResources()
      {
         VString vRWResources = new VString(vRWResources_in);
         SupportClass.HashSetSupport v = new SupportClass.LinkedHashSet();
         // grab the root node and all it's children

         SupportClass.HashSetSupport vRootLinks = node.getAllRefs(null, true);
         IEnumerator iter = vRootLinks.GetEnumerator();
         while (iter.MoveNext())
         {
            JDFElement liRoot = (JDFElement)iter.Current;
            JDFResource r = null;
            bool bResRW = false;
            if (liRoot is JDFResourceLink)
            {
               bResRW = linkFitsRWRes((JDFResourceLink)liRoot, vRWResources);
               if (bResRW)
               {
                  JDFResourceLink rl = (JDFResourceLink)liRoot;
                  r = rl.getTarget();
               }
            }
            else if (liRoot is JDFRefElement)
            {
               JDFRefElement re = (JDFRefElement)liRoot;
               r = re.getTarget();
               if (r != null)
               {
                  bResRW = resFitsRWRes(r, vRWResources);
               }
            }
            if (bResRW && r != null)
            {
               VElement vRes = new VElement();
               if (vSpawnParts == null || vSpawnParts.IsEmpty())
               {
                  vRes = r.getLeaves(false);
               }
               else
               {
                  for (int j = 0; j < vSpawnParts.Count; j++)
                  {
                     vRes.appendUnique(r.getPartitionVector(vSpawnParts[j], null));
                  }
               }
               for (int k = 0; k < vRes.Count; k++)
               {
                  JDFResource rTarget = (JDFResource)vRes[k];
                  if (rTarget.getSpawnStatus() == JDFResource.EnumSpawnStatus.SpawnedRW)
                  {
                     if (!v.Contains(rTarget))
                        v.Add(rTarget);
                  }
               }
            }
         }
         // empty if all is well
         return v.Count == 0 ? null : v;
      }

      ////

      private VElement prepareSpawnLinks(JDFNode rootOut)
      {
         VElement vn = rootOut.getvJDFNode(null, null, false);
         int size = vn.Count;
         VElement outLinks = new VElement();

         // fill all links of all children of rootOut into vOutRes and outLinks
         for (int i = 0; i < size; i++)
         {
            JDFNode vnNode_i = (JDFNode)vn[i];
            outLinks.appendUnique(vnNode_i.getResourceLinks(null));
         }
         return outLinks;
      }

      ///   
      ///	 <summary> *  </summary>
      ///	 * <param name="parent"> </param>
      ///	 * <param name="url"> </param>
      ///	 * <param name="vSpawnParts"> </param>
      ///	 * <param name="bCopyNodeInfo"> </param>
      ///	 * <param name="bCopyCustomerInfo"> </param>
      ///	 * <param name="bCopyComments"> </param>
      ///	 
      private void setSpawnParent(JDFNode rootOut, JDFNode parent)
      {
         VString vs = parent.getAncestorIDs();
         JDFAncestorPool ancestorPool = parent.getJDFRoot().getAncestorPool();
         string lastAncestorID = JDFConstants.EMPTYSTRING;

         if (!(parent.Equals(node))) // only do this if we are not spawning
         // parallel
         {
            rootOut.removeChild(ElementName.ANCESTORPOOL, null, 0); // just in
            // case
            if (parent.getJDFRoot().hasChildElement(ElementName.ANCESTORPOOL, null))
            {
               ancestorPool = (JDFAncestorPool)rootOut.copyElement(ancestorPool, null);
               int numAncestors = ancestorPool.numChildElements(ElementName.ANCESTOR, null);
               if (numAncestors > 0)
               {
                  lastAncestorID = ancestorPool.getAncestor(numAncestors - 1).getNodeID();
               }
            }
         }
         ancestorPool = rootOut.getCreateAncestorPool();
         ancestorPool.setPartMapVector(vSpawnParts);

         // avoid double counting of this node's root element in case of
         // partitioned spawning
         int startAncestorLoop = 0;
         if ((vs.Count > 0) && ((vs[0]).Equals(lastAncestorID)))
         {
            startAncestorLoop = 1;
         }

         // 010702 RP reversed in getAncestorIDs: the last in the list is the
         // actual
         for (int i = startAncestorLoop; i < vs.Count; i++)
         {
            JDFAncestor ancestor = ancestorPool.appendAncestor();
            ancestor.setNodeID(vs[i]);
            if (i == 0)
            { // first in list is the parent
               if (parentURL != null && !parentURL.Equals(JDFConstants.EMPTYSTRING))
               {
                  ancestor.setFileName(parentURL);
               }
            }
         }
         rootOut.setJobID(parent.getJobID(true));

         // 180502 RP added line
         ancestorPool.copyNodeData(parent, bCopyNodeInfo, bCopyCustomerInfo, bCopyComments);
      }

      ////

      private JDFSpawned createSpawnAudit(JDFNode rootOut, string spawnID, JDFNode spawnParentNode)
      {
         // throw in the audits
         JDFAuditPool p = spawnParentNode.getCreateAuditPool();
         JDFSpawned spawnAudit = p.addSpawned(rootOut, null, null, null, null);

         // 210302 RP added if statement
         if (spawnURL != null && !spawnURL.Equals(JDFConstants.EMPTYSTRING))
         {
            if (spawnURL.IndexOf("://") == -1)
            {
               spawnAudit.setURL("file://" + spawnURL);
            }
            else
            {
               spawnAudit.setURL(spawnURL);
            }
         }
         spawnAudit.setNewSpawnID(spawnID);
         return spawnAudit;
      }

      ///   
      ///	 <summary> * add any resources that live in ancestor nodes to this node
      ///	 *  </summary>
      ///	 * <param name="spawnAudit"> : </param>
      ///	 * <param name="root"> : </param>
      ///	 * <param name="vRWresources"> :XXX </param>
      ///	 * <param name="vParts"> : </param>
      ///	 * <param name="bSpawnROPartsOnly"> if true, only the parts of RO resources that are specified in vParts are spawned, else
      ///	 *            the complete resource is spawned </param>
      ///	 * <returns> int: number of resources added to the spawned node </returns>
      ///	 
      private int addSpawnedResources(JDFNode rootOut, JDFSpawned spawnAudit)
      {
         VString vRWResources = new VString(vRWResources_in);
         int nSpawned = 0;
         JDFResourcePool rPool = rootOut.getCreateResourcePool();

         // must copy the ap to the nood to have a decent hook on ap referenced
         // resources
         JDFAncestorPool ap = rootOut.getAncestorPool();
         if (ap != null)
            ap = (JDFAncestorPool)node.copyElement(ap, null);

         // grab the root node and all it's children

         SupportClass.HashSetSupport vRootLinks = node.getAllRefs(null, false);

         // create a HashSet with all IDs of the newly created Node
         SupportClass.HashSetSupport allIDsCopied = new SupportClass.LinkedHashSet();
         rootOut.fillHashSet(AttributeName.ID, null, allIDsCopied);

         string spawnID = spawnAudit.getNewSpawnID();

         // first check only read only resources, since there may be a collision
         for (int loopRORW = 0; loopRORW < 2; loopRORW++)
         {
            // loop over all links
            IEnumerator iter = vRootLinks.GetEnumerator();
            while (iter.MoveNext())
            {
               JDFElement liRoot = (JDFElement)iter.Current;

               // test for direct children of resourcepool - these will be
               // added later
               if (liRoot.getDeepParent(ElementName.RESOURCEPOOL, 0) != null)
                  continue;

               string refID = liRoot.getAttribute(AttributeName.RREF); // must
               // be
               // either
               // refelem
               // or
               // link
               // ,
               // therefore
               // will
               // have
               // rref

               bool bResRW = false;
               JDFResource rRoot = null;
               if (liRoot is JDFResourceLink)
               {
                  bResRW = linkFitsRWRes((JDFResourceLink)liRoot, vRWResources);
               }
               else if (liRoot is JDFRefElement)
               {
                  rRoot = (JDFResource)node.getTarget(refID, AttributeName.ID);
                  bResRW = resFitsRWRes(rRoot, vRWResources);
               }

               // do only RO on the first loop and only RW on the second
               if (bResRW != (loopRORW != 0))
               {
                  continue;
               }

               // 091204 RP bug fix for multiple deep copies
               // don't copy if it is already there!
               bool isThereAlready = allIDsCopied.Contains(refID);
               JDFResource.EnumSpawnStatus copyStatus = bResRW ? JDFResource.EnumSpawnStatus.SpawnedRW : JDFResource.EnumSpawnStatus.SpawnedRO;

               SupportClass.HashSetSupport vvRO = new SupportClass.LinkedHashSet();
               SupportClass.HashSetSupport vvRW = new SupportClass.LinkedHashSet();
               if (rRoot == null)
                  rRoot = node.getTarget(refID, AttributeName.ID) as JDFResource;

               // check for null and throw an exception in picky mode
               if (rRoot == null)
               {
                  continue;
               }
               // 080505 must always check existing resources, otherwise we can
               // lose references
               // if(!isThereAlready)
               // {
               // copy any missing linked resources, just in case
               // the root is in the original jdf and can be used as a hook to
               // the original document
               // get a list of all resources referenced by this link
               // always do a copyresource in case some dangling rRefs are
               // waiting
               copySpawnedResource(rPool, rRoot, copyStatus, vSpawnParts, spawnID, vRWResources, vvRW, vvRO, allIDsCopied);
               nSpawned += vvRO.Count + vvRW.Count;
               // }
               // else
               // {
               if (isThereAlready && bResRW)
                  vvRW.Add(rRoot.getID());
               // }
               VString rRefsRW = spawnAudit.getrRefsRWCopied();
               VString rRefsRO = spawnAudit.getrRefsROCopied();
               IEnumerator iterRefs = vvRW.GetEnumerator();
               while (iterRefs.MoveNext())
               {
                  string s = (string)iterRefs.Current;
                  rRefsRW.Add(s);
                  int ind = rRefsRO.index(s);
                  if (ind >= 0)
                     rRefsRO.RemoveAt(ind);
               }
               iterRefs = vvRO.GetEnumerator();
               while (iterRefs.MoveNext())
               {
                  string s = (string)iterRefs.Current;
                  rRefsRO.Add(s);
               }
               rRefsRO.unify();
               rRefsRW.unify();
               if (rRefsRO.IsEmpty())
                  rRefsRO = null;
               if (rRefsRW.IsEmpty())
                  rRefsRW = null;

               spawnAudit.setrRefsROCopied(rRefsRO);
               spawnAudit.setrRefsRWCopied(rRefsRW);
               // get the effected resources
               VElement vRes = new VElement();
               VElement vResRoot = new VElement();
               if (liRoot is JDFResourceLink)
               {
                  JDFResourceLink liRootLink = (JDFResourceLink)liRoot;
                  VJDFAttributeMap vLinkMap = liRootLink.getPartMapVector();
                  // make sure that spawned resources are sufficiently
                  // partitioned if spawning rw so that no merge conflicts
                  // arise
                  // create a temporary dummy copy of the link so that we have
                  // a gauranteed copy that behaves the same as the original
                  JDFResourceLink dummy = (JDFResourceLink)rootOut.getCreateResourceLinkPool().copyElement(liRoot, null);
                  fixResLinks(rootOut, bResRW, liRootLink, dummy);
                  // reduce partitions in main so that the links remain
                  // consistent
                  liRootLink.setPartMapVector(vSpawnParts);
                  dummy.setPartMapVector(vSpawnParts);

                  vResRoot = ((JDFResourceLink)liRoot).getTargetVector(-1);

                  vRes = dummy.getTargetVector(-1);
                  dummy.deleteNode();
                  // reset partitions in main
                  liRootLink.setPartMapVector(vLinkMap);

               }
               else if (liRoot is JDFRefElement)
               {
                  vResRoot.Add(((JDFRefElement)liRoot).getTarget());

                  // create a temporary dummy copy of the link so that we have
                  // a gauranteed copy that behaves the same as the original
                  JDFRefElement dummy = (JDFRefElement)rootOut.copyElement(liRoot, null);
                  vRes.Add(dummy.getTarget());
                  dummy.deleteNode();
               }
               else
               {
                  continue; // snafu - should never get here
               }
               addIdentical(vResRoot);
               addIdentical(vRes);

               // fixed not to crash with corrupt jdfs.
               // Now just continue and ignore the corrupt resource
               int siz = vRes.Count < vResRoot.Count ? vRes.Count : vResRoot.Count;

               // loop over all partitions
               for (int resParts = 0; resParts < siz; resParts++)
               {
                  JDFResource r = (JDFResource)vRes[resParts];
                  JDFResource rRoot1 = (JDFResource)vResRoot[resParts];

                  spawnPart(rRoot1, spawnID, copyStatus, vSpawnParts, true);
                  spawnPart(r, spawnID, copyStatus, vSpawnParts, false);

                  if (vSpawnParts != null && vSpawnParts.Count != 0 && (bResRW || bSpawnROPartsOnly))
                  {
                     // reduce partitions of all RW resources and of RO
                     // resources if requested
                     // r.getResourceRoot().reducePartitions(vSpawnParts);
                     reducePartitions(r.getResourceRoot());
                  }
               }
            }
         }

         // must remove ap after use
         if (ap != null)
            ap.deleteNode();

         return nSpawned;
      }

      ///   
      ///	 * <param name="res"> </param>
      ///	 
      private void addIdentical(VElement vRes)
      {
         if (vRes == null || vRes.Count == 0 || vSpawnParts == null || vSpawnParts.Count == 0)
            return;
         JDFResource root = ((JDFResource)vRes[0]).getResourceRoot();
         VElement identicals = root.getChildrenByTagName(ElementName.IDENTICAL, null, null, false, true, -1, false);
         if (identicals == null || identicals.Count == 0)
            return;

         for (int i = 0; i < identicals.Count; i++)
         {
            JDFIdentical ident = (JDFIdentical)identicals[i];
            JDFResource identParent = (JDFResource)ident.getParentNode_KElement();
            JDFAttributeMap identMap = identParent.getPartMap();
            for (int j = 0; j < vSpawnParts.Count; j++)
            {
               JDFAttributeMap mapPart = vSpawnParts[j];
               if (mapPart.subMap(identMap))
                  vRes.Add(identParent);
            }
         }

      }

      ///   
      ///	 * <param name="rootOut"> </param>
      ///	 * <param name="bResRW"> </param>
      ///	 * <param name="liRootLink"> </param>
      ///	 * <param name="dummy"> </param>
      ///	 
      private void fixResLinks(JDFNode rootOut, bool bResRW, JDFResourceLink liRootLink, JDFResourceLink dummy)
      {
         if (bFixResources && vSpawnParts != null && vSpawnParts.Count != 0 && bResRW)
         {
            VString rootPartIDKeys = rootOut.getJDFRoot().getPartIDKeys(vSpawnParts[0]);
            JDFResource linkRoot = liRootLink.getLinkRoot();
            if (linkRoot != null)
            {
               try
               {
                  linkRoot.createPartitions(vSpawnParts, rootPartIDKeys);
               }
               catch (JDFException)
               {
                  for (int i = 0; i < vSpawnParts.Count; i++)
                  {
                     fixSpawnPartitions(linkRoot.getPartition(vSpawnParts[i], null), rootPartIDKeys);
                  }
               }
            }
            JDFResource dummyRoot = dummy.getLinkRoot();
            if (dummyRoot != null)
            {
               try
               {
                  dummyRoot.createPartitions(vSpawnParts, rootPartIDKeys);
               }
               catch (JDFException)
               {
                  for (int i = 0; i < vSpawnParts.Count; i++)
                  {
                     fixSpawnPartitions(dummyRoot.getPartition(vSpawnParts[i], null), rootPartIDKeys);
                  }
               }
            }
         }
      }

      ////

      private void finalizeSpawn(VJDFAttributeMap vLocalSpawnParts, JDFNode rootOut, JDFSpawned spawnAudit)
      {
         VElement outLinks = prepareSpawnLinks(rootOut);
         VElement mainLinks = prepareSpawnLinks(node);
         int mainLinkLen = mainLinks.Count;

         string spawnID = spawnAudit.getNewSpawnID();
         // add parts to resource links if necessary
         if (vLocalSpawnParts != null && !vLocalSpawnParts.IsEmpty())
         {
            int outLinkSize = outLinks.Count;
            for (int i = 0; i < outLinkSize; i++)
            {
               JDFResourceLink link = (JDFResourceLink)outLinks[i];
               JDFResource r = link.getLinkRoot();

               // 2005-03-11 KM if the link is null continue, the JDF ist
               // invalid but in
               // the best case only an audit is missing and the JDF is still
               // operable
               // in the worst caste the spawned JDF is not executable at all
               if (r != null)
               {
                  VJDFAttributeMap vPartMap = getSpawnLinkMap(vLocalSpawnParts, r);
                  if (!vPartMap.IsEmpty())
                  {
                     VJDFAttributeMap vNewMap = getSpawnedLinkPartMap(link, vPartMap);
                     link.setPartMapVector(vNewMap);
                     updateSpawnIDs(spawnID, link);
                     string id = link.getrRef();
                     if (id != null)
                     {
                        link = (JDFResourceLink)mainLinks[i];

                        if (id.Equals(link.getrRef()))
                        {
                           updateSpawnIDsInMain(spawnID, link, vPartMap);
                        }
                        else
                        // the sequence of links changed - must search,
                        // hopefully we never get here
                        {
                           for (int ii = 0; ii < mainLinkLen; ii++)
                           {
                              link = (JDFResourceLink)mainLinks[ii];
                              if (id.Equals(link.getrRef()))
                              {
                                 updateSpawnIDsInMain(spawnID, link, vPartMap);
                              }
                           }
                        }
                     }
                  }
               }
            }
         }
         finalizeStatusAndAudits(vLocalSpawnParts, spawnAudit);
      }

      ///   
      ///	 <summary> * update only local resources
      ///	 *  </summary>
      ///	 * <param name="spawnID"> </param>
      ///	 * <param name="link"> </param>
      ///	 * <param name="vPartMap"> </param>
      ///	 
      private void updateSpawnIDsInMain(string spawnID, JDFResourceLink link, VJDFAttributeMap vPartMap)
      {
         JDFResource rMain = link.getLinkRoot();
         for (int k = 0; k < vPartMap.Count; k++)
         {
            VElement vMainPart = rMain.getPartitionVector(vPartMap[k], null);
            for (int kk = 0; kk < vMainPart.Count; kk++)
            {
               JDFResource rMainPart = (JDFResource)vMainPart[kk];
               if (rMainPart == null)
                  continue;

               VElement leaves = rMainPart.getLeaves(true);
               bool bSpawnID = false;

               // if any child node or leaf has this spawnID we need not do
               // anything
               for (int kkk = 0; kkk < leaves.Count; kkk++)
               {
                  JDFResource rMainLeaf = (JDFResource)leaves[kkk];
                  bSpawnID = rMainLeaf.includesMatchingAttribute(AttributeName.SPAWNIDS, spawnID, EnumAttributeType.NMTOKENS);
                  if (bSpawnID)
                     break;
               }
               if (!bSpawnID)
               {
                  rMainPart.appendSpawnIDs(spawnID);
                  rMainPart.setLocked(true);
                  rMainPart.setSpawnStatus(EnumSpawnStatus.SpawnedRW);
               }
            }
         }
      }

      ///   
      ///	 * <param name="link"> </param>
      ///	 * <param name="vPartMap">
      ///	 * @return </param>
      ///	 
      private VJDFAttributeMap getSpawnedLinkPartMap(JDFResourceLink link, VJDFAttributeMap vPartMap)
      {
         VJDFAttributeMap vLinkMap = link.getPartMapVector();
         VJDFAttributeMap vNewMap = new VJDFAttributeMap();

         if (vLinkMap == null)
         {
            vNewMap = vPartMap;
         }
         else
         {
            for (int l = 0; l < vLinkMap.Count; l++)
            {
               for (int k = 0; k < vPartMap.Count; k++)
               {
                  JDFAttributeMap m = new JDFAttributeMap(vPartMap[k]);
                  m = m.orMap(vLinkMap[l]);

                  if (!m.IsEmpty())
                  {
                     vNewMap.appendUnique(m);
                  }
               }
            }
         }
         return vNewMap;
      }

      ///   
      ///	 * <param name="spawnID"> </param>
      ///	 * <param name="link"> </param>
      ///	 
      private void updateSpawnIDs(string spawnID, JDFResourceLink link)
      {
         VElement vRes = link.getTargetVector(-1);
         for (int t = 0; t < vRes.Count; t++)
         {
            JDFResource res = (JDFResource)vRes[t];
            // only fix those local resources that haven't been fixed along the
            // way...
            if (!res.includesMatchingAttribute(AttributeName.SPAWNIDS, spawnID, EnumAttributeType.NMTOKENS))
            {
               res.appendSpawnIDs(spawnID);
               res.setLocked(false);
            }
         }
      }

      ///   
      ///	 * <param name="vLocalSpawnParts"> </param>
      ///	 * <param name="spawnAudit"> </param>
      ///	 
      private void finalizeStatusAndAudits(VJDFAttributeMap vLocalSpawnParts, JDFSpawned spawnAudit)
      {
         // add partition information to the audits and StatusPool or NodeInfo
         // 050906 RP move to the back so that it occurs after any global
         // resources have been copied
         if (vLocalSpawnParts != null && !vLocalSpawnParts.IsEmpty())
         {
            spawnAudit.setPartMapVector(vLocalSpawnParts);

            EnumNodeStatus partStatus = node.getPartStatus(vLocalSpawnParts[0]);
            if (partStatus != null)
               spawnAudit.setStatus(partStatus);
            node.setPartStatus(vLocalSpawnParts, EnumNodeStatus.Spawned, null);
         }
         else
         // No partitioning - set Audit + Status globally
         {
            EnumNodeStatus status = node.getStatus();
            if (status != null)
               spawnAudit.setStatus(status);
            node.setStatus(JDFElement.EnumNodeStatus.Spawned);
         }
      }

      ///   
      ///	 * <param name="vLocalSpawnParts"> </param>
      ///	 * <param name="r">
      ///	 * @return </param>
      ///	 
      private VJDFAttributeMap getSpawnLinkMap(VJDFAttributeMap vLocalSpawnParts, JDFResource r)
      {
         VJDFAttributeMap vPartMap = new VJDFAttributeMap(vLocalSpawnParts);

         // 160802 RP leave implied resource link parts if PartUsage=implicit
         if (!r.getPartUsage().Equals(JDFResource.EnumPartUsage.Implicit))
         {
            VString vPartKeys = r.getPartIDKeys();
            List<ValuedEnum> vImplicitPartitions = r.getImplicitPartitions();
            if (vImplicitPartitions != null)
            {
               for (int ii = 0; ii < vImplicitPartitions.Count; ii++)
               {
                  JDFResource.EnumPartIDKey e = (JDFResource.EnumPartIDKey)vImplicitPartitions[ii];
                  vPartKeys.Add(e.getName());
               }
            }
            vPartMap.reduceMap(vPartKeys.getSet());
         }
         return vPartMap;
      }

      ///   
      ///	 <summary> * calculate whether a link should be RW or RO
      ///	 *  </summary>
      ///	 * <param name="JDFResourceLink"> li the link to check </param>
      ///	 * <param name="VString"> vRWResources the list of resource ids, process usages, usages, names. If any match, the referenced
      ///	 *            resource is considered rw </param>
      ///	 * <returns> boolean true if rw </returns>
      ///	 
      private bool linkFitsRWRes(JDFResourceLink li, VString vRWResources)
      {
         bool bResRW = vRWResources.Contains(li.getNamedProcessUsage());
         // 200602 RP added fix
         if (!bResRW)
         {
            bResRW = vRWResources.Contains(li.getLinkedResourceName());
         }

         // 230802 RP added check for ID in vRWResources
         if (!bResRW)
         {
            bResRW = vRWResources.Contains(li.getrRef());
         }

         // 040902 RP added check for Usage in vRWResources
         if (!bResRW)
         {
            bResRW = vRWResources.Contains(li.getAttribute(AttributeName.USAGE));
         }
         return bResRW;
      }

      ///   
      ///	 <summary> * Reduces partition so that only the parts that overlap with vResources remain
      ///	 *  </summary>
      ///	 * <param name="vValidParts"> vector of partmaps that define the individual valid parts.<br>
      ///	 *            The individual PartMaps are ored to define the final resource. </param>
      ///	 

      private VElement reducePartitions(JDFResource r, string nodeName, string nsURI, VString partIDKeys, int partIDPos, JDFAttributeMap parentMap, VElement identical)
      {
         VElement children = r.getChildElementVector_KElement(nodeName, nsURI, null, true, -1);
         VElement bad = new VElement();
         for (int i = 0; i < children.Count; i++)
         {
            JDFResource child = (JDFResource)children[i];
            string key = partIDKeys[partIDPos];
            if (key != null)
            {
               string val = child.getAttribute_KElement(key, null, null);
               if (val != null)
               {
                  JDFAttributeMap testMap = new JDFAttributeMap(parentMap);
                  testMap.put(key, val);
                  if (vSpawnParts.overlapsMap(testMap))
                  {
                     JDFIdentical id = child.getIdentical();
                     if (id != null)
                     {
                        JDFResource resourceRoot = r.getResourceRoot();
                        JDFResource partition = resourceRoot.getPartition(testMap, null);
                        while (partition != resourceRoot)
                        {
                           identical.Add(partition);
                           partition = (JDFResource)partition.getParentNode_KElement();
                        }
                     }
                     bad.appendUnique(reducePartitions(child, nodeName, nsURI, partIDKeys, partIDPos + 1, testMap, identical));
                  }
                  else
                     bad.Add(child);
               }
            }

         }
         return bad;
      }

      private void reducePartitions(JDFResource r)
      {
         if (r == null || vSpawnParts == null || vSpawnParts.Count == 0)
            return;
         VString partIDKeys = r.getPartIDKeys();
         if (partIDKeys == null || partIDKeys.Count == 0)
            return;
         string nodeName = r.LocalName;
         string nsURI = r.getNamespaceURI();
         VElement identical = new VElement();
         VElement vBad = reducePartitions(r, nodeName, nsURI, partIDKeys, 0, new JDFAttributeMap(), identical);
         vBad.removeElements(identical);
         for (int i = 0; i < vBad.Count; i++)
            vBad[i].deleteNode();

      }

      ///   
      ///	 <summary> * calculate whether a link should be RW or RO
      ///	 *  </summary>
      ///	 * <param name="JDFResourceLink"> li the link to check </param>
      ///	 * <param name="VString"> vRWResources the list of resource ids, process usages, usages, names. If any match, the referenced
      ///	 *            resource is considered rw </param>
      ///	 * <returns> boolean true if rw </returns>
      ///	 
      private bool resFitsRWRes(JDFResource r, VString vRWResources)
      {
         if (r == null)
            return false;
         bool bResRW = vRWResources.Contains(r.LocalName);
         // 200602 RP added fix
         if (!bResRW)
         {
            bResRW = vRWResources.Contains(JDFConstants.STAR);
         }

         // 230802 RP added check for ID in vRWResources
         if (!bResRW)
         {
            bResRW = vRWResources.Contains(r.getID());
         }

         return bResRW;
      }

      ///   
      ///	 <summary> * copies a resource recursively and optionally fixes status flags and locks in the source resource
      ///	 *  </summary>
      ///	 * <param name="p"> the pool to copy r into </param>
      ///	 * <param name="r"> the resource to copy </param>
      ///	 * <param name="copyStatus"> rw or ro </param>
      ///	 * <param name="vParts"> part map vector of the partitions to copy </param>
      ///	 * <param name="spawnID"> the spawnID of the spawning that initiated the copy </param>
      ///	 * <param name="resInPool"> internal recursion checker </param>
      ///	 * <param name="vRWResources"> write resources
      ///	 *  </param>
      ///	 * <returns> VString vector of resource names that have been copied </returns>
      ///	 
      private void copySpawnedResource(JDFResourcePool p, JDFResource r, JDFResource.EnumSpawnStatus copyStatus, VJDFAttributeMap vParts, string spawnID, VString vRWResources, SupportClass.HashSetSupport vRWIDs, SupportClass.HashSetSupport vROIDs, SupportClass.HashSetSupport allIDsCopied)
      {
         JDFResource.EnumSpawnStatus copyStatusLocal = copyStatus;

         if (r == null)
         {
            return;
         }

         // r is not yet here copy r
         bool bRW = copyStatusLocal == JDFResource.EnumSpawnStatus.SpawnedRW;
         string rID = r.getID();
         if (!allIDsCopied.Contains(rID))
         {
            JDFResource rNew = (JDFResource)p.copyElement(r, null);
            // if spawning, fix stati and locks

            if (bRW || bSpawnROPartsOnly)
            {
               reducePartitions(rNew);
            }

            spawnPart(r, spawnID, copyStatusLocal, vParts, true);
            spawnPart(rNew, spawnID, copyStatusLocal, vParts, false);

            if (bRW)
            {
               vRWIDs.Add(rID);
            }
            else
            {
               vROIDs.Add(rID);
            }

            allIDsCopied.Add(rID);
         }

         VString vs = r.getHRefs(new VString(), false, false);
         // add recursively copied resource references
         int size = vs.Count;
         for (int i = 0; i < size; i++)
         {
            string id = vs[i];

            // the referenced resource is already in this pool - continue
            if (!allIDsCopied.Contains(id))
            {
               // 071101 RP added r is by definition in the original document
               // which also contains the rrefs elements
               JDFResource next = ((JDFNode)r.getDocRoot()).getTargetResource(id);

               // and now all those interlinked resources
               if (next != null)
               {
                  // only copy refelements rw if they are explicitly in the
                  // list
                  if (bRW)
                  {
                     copyStatusLocal = resFitsRWRes(next, vRWResources) ? JDFResource.EnumSpawnStatus.SpawnedRW : JDFResource.EnumSpawnStatus.SpawnedRO;
                  }
                  // recurse into refelements
                  copySpawnedResource(p, next, copyStatusLocal, vParts, spawnID, vRWResources, vRWIDs, vROIDs, allIDsCopied);
               }
            }
         }

         return;
      }

      ///   
      ///	 * <param name="r"> </param>
      ///	 * <param name="spawnID"> </param>
      ///	 * <param name="copyStatus"> </param>
      ///	 * <param name="vParts"> </param>
      ///	 
      private void spawnPart(JDFResource r, string spawnID, JDFResource.EnumSpawnStatus copyStatus, VJDFAttributeMap vParts, bool bStayinMain)
      {
         if (vParts != null && vParts.Count > 0)
         {
            int size = vParts.Count;
            // loop over all part maps to get best matching resource
            for (int j = 0; j < size; j++)
            {
               VElement vSubParts = r.getPartitionVector(vParts[j], EnumPartUsage.Implicit); // alway
               // implicit
               // -
               // in
               // the
               // worst case some
               // partitions may be
               // multiply spawned
               for (int k = 0; k < vSubParts.Count; k++)
               {
                  JDFResource pLeaf = (JDFResource)vSubParts.item(k);
                  if (pLeaf != null)
                  {
                     // set the lock of the leaf to true if it is RO, else
                     // unlock it
                     if (bStayinMain)
                     {
                        if ((copyStatus == EnumSpawnStatus.SpawnedRW) || (pLeaf.getSpawnStatus() != EnumSpawnStatus.SpawnedRW))
                        {
                           pLeaf.setSpawnStatus(copyStatus);
                           pLeaf.setLocked(copyStatus == EnumSpawnStatus.SpawnedRW);
                        }
                        pLeaf.appendSpawnIDs(spawnID);
                     }
                     else
                     {
                        pLeaf.setLocked(copyStatus != EnumSpawnStatus.SpawnedRW);
                        pLeaf.setSpawnIDs(new VString(spawnID, null));
                     }
                  }
               }
            }
         }
         else
         // no partitions
         {
            if (bStayinMain)
            {
               if ((copyStatus == EnumSpawnStatus.SpawnedRW) || (r.getSpawnStatus() != EnumSpawnStatus.SpawnedRW))
               {
                  r.setSpawnStatus(copyStatus);
                  r.setLocked(copyStatus == EnumSpawnStatus.SpawnedRW);
               }
            }
            else
            {
               r.setLocked(copyStatus != EnumSpawnStatus.SpawnedRW);
            }

            if (bStayinMain)
               r.appendSpawnIDs(spawnID);
            else
               r.setSpawnIDs(new VString(spawnID, null));
         }
      }

      private void fixSpawnPartitions(JDFResource r, VString rootPartIDKeys)
      {
         if (r == null)
            return;
         VString oldParts = r.getPartIDKeys();
         if (oldParts.containsAny(rootPartIDKeys))
         {
            throw new JDFException("fixSpawnPartitions - adding incompatible resources");
         }

         // move away all preexisting partititons and dump them int the new nodes
         VElement ve = r.getChildElementVector_KElement(r.Name, r.getNamespaceURI(), null, true, 9999999);
         KElement[] tmp = new KElement[ve.Count];
         for (int i = 0; i < ve.Count; i++)
            tmp[i] = ve.item(i).deleteNode();
         r.removeAttribute(AttributeName.PARTIDKEYS);
         VElement vNew = r.getResourceRoot().createPartitions(vSpawnParts, rootPartIDKeys);

         // copy initial leaves into the newly created stuff
         for (int i = 0; i < vNew.Count; i++)
            for (int j = 0; j < tmp.Length; j++)
               vNew.item(i).copyElement(tmp[j], null);

         // fix partidkeys
         VString partIDKeys = r.getPartIDKeys();
         partIDKeys.appendUnique(oldParts);
         r.setPartIDKeys(partIDKeys);
      }

      ////

      ///   
      ///	 <summary> * spawn a node in informative mode without modifying the root JDF; url is the file name of the new node, the
      ///	 * parameters except for the list of rw resources, which are by definition empty, are identical to those of Spawn
      ///	 * 
      ///	 * vRWResourceUsage is the vector of Resources Usages, Resource Names or Resource IDs that are spawned RW, all
      ///	 * others are spawned read only; vParts is the vector of part maps that are to be spawned, defaults to no part, i.e.
      ///	 * the whole thing
      ///	 *  </summary>
      ///	 * <returns> JDFDoc: The spawned node's owner document.
      ///	 * 
      ///	 *  </returns>
      ///	 
      public virtual JDFNode spawnInformative()
      {
         JDFDoc docNew = new JDFDoc(ElementName.JDF);
         JDFNode rootOut = (JDFNode)docNew.getRoot();
         JDFNode thisRoot = node.getJDFRoot();
         // merge this node into it
         rootOut.mergeNode(thisRoot, false);
         JDFNode copyOfThis = rootOut.getChildJDFNode(node.getID(), false);
         JDFNode tmp = node;
         node = copyOfThis;
         JDFNode nodeNew = null;
         VString vRWTmp = vRWResources_in;
         bool spawnMultKeep = bSpawnRWPartsMultiple;
         bSpawnRWPartsMultiple = true; // never check multiple resources when
         // spawning informative - who cares
         nodeNew = spawn();
         bSpawnRWPartsMultiple = spawnMultKeep;
         rootOut = nodeNew.getRoot();
         rootOut.setActivation(EnumActivation.Informative);
         node = tmp;

         vRWResources_in = vRWTmp;

         return nodeNew;
      }

      ///   
      ///	 <summary> * spawn a node; url is the file name of the new node, vRWResourceUsage is the vector of Resources Usages (or Names
      ///	 * if no usage exists for the process) that are spawned RW, all others are spawned read only; vParts is the vector
      ///	 * of part maps that are to be spawned, defaults to no part, i.e. the whole thing
      ///	 *  </summary>
      ///	 * <param name="parentURL"> </param>
      ///	 * <param name="spawnURL"> : URL of the spawned JDF file </param>
      ///	 * <param name="vRWResources"> : vector of resource names and Usage / ProcessUsage that are spawned as rw <br>
      ///	 *            the format is one of:<br>
      ///	 *            ResName:Input<br>
      ///	 *            ResName:Output<br>
      ///	 *            ResName:ProcessUsage<br> </param>
      ///	 * <param name="VJDFAttributeMap"> vSpawnParts: vector of mAttributes that describe the parts to spawn, only valid
      ///	 *            PartIDKeys are allowed </param>
      ///	 * <param name="bSpawnROPartsOnly"> if true, only the parts of RO resources that are specified in vParts are spawned, else
      ///	 *            the complete resource is spawned </param>
      ///	 * <param name="bCopyNodeInfo"> copy the NodeInfo elements into the Ancestors </param>
      ///	 * <param name="bCopyCustomerInfo"> copy the CustomerInfo elements into the Ancestors </param>
      ///	 * <param name="bCopyComments"> copy the Comment elements into the Ancestors
      ///	 *  </param>
      ///	 * <returns> The spawned node
      ///	 * @since 050831 added bCopyComments @ tbd enhance nested spawning of partitioned nodes default: spawn(parentURL,
      ///	 *        null, null, null, false, false, false, false) </returns>
      ///	 
      public virtual JDFNode spawn(string _parentURL, string _spawnURL, ArrayList _vRWResources_in, VJDFAttributeMap _vSpawnParts, bool _bSpawnROPartsOnly, bool _bCopyNodeInfo, bool _bCopyCustomerInfo, bool _bCopyComments)
      {
         bCopyComments = _bCopyComments;
         bCopyCustomerInfo = _bCopyCustomerInfo;
         bCopyNodeInfo = _bCopyNodeInfo;
         bSpawnROPartsOnly = _bSpawnROPartsOnly;
         vSpawnParts = _vSpawnParts;
         vRWResources_in = new VString(_vRWResources_in);
         spawnURL = _spawnURL;
         parentURL = _parentURL;
         return spawn();

      }

      ////

      ///   
      ///	 <summary> * spawn a node in informative mode without modifying the root JDF; url is the file name of the new node, the
      ///	 * parameters except for the list of rw resources, which are by definition empty, are identical to those of Spawn
      ///	 * 
      ///	 * vRWResourceUsage is the vector of Resources Usages, Resource Names or Resource IDs that are spawned RW, all
      ///	 * others are spawned read only; vParts is the vector of part maps that are to be spawned, defaults to no part, i.e.
      ///	 * the whole thing
      ///	 *  </summary>
      ///	 * <param name="spawnURL"> : URL of the spawned JDF file </param>
      ///	 * <param name="vParts"> : vector of mAttributes that describe the parts to spawn </param>
      ///	 * <param name="bSpawnROPartsOnly"> if true, only the parts of RO resources that are specified in vParts are spawned, else
      ///	 *            the complete resource is spawned </param>
      ///	 * <param name="bCopyNodeInfo"> copy the NodeInfo elements into the Ancestors </param>
      ///	 * <param name="bCopyCustomerInfo"> copy the CustomerInfo elements into the Ancestors </param>
      ///	 * <param name="bCopyComments"> copy the Comment elements into the Ancestors </param>
      ///	 * <returns> JDFDoc: The spawned node's owner document.
      ///	 * 
      ///	 * @default spawnInformative(parentURL, null, null, false, false, false, false);
      ///	 *  </returns>
      ///	 
      public virtual JDFNode spawnInformative(string _parentURL, string _spawnURL, VJDFAttributeMap _vSpawnParts, bool _bSpawnROPartsOnly, bool _bCopyNodeInfo, bool _bCopyCustomerInfo, bool _bCopyComments)
      {
         bCopyComments = _bCopyComments;
         bCopyCustomerInfo = _bCopyCustomerInfo;
         bCopyNodeInfo = _bCopyNodeInfo;
         bSpawnROPartsOnly = _bSpawnROPartsOnly;
         vSpawnParts = _vSpawnParts;
         vRWResources_in = null;
         spawnURL = _spawnURL;
         parentURL = _parentURL;
         return spawnInformative();
      }


      ///   
      ///	 <summary> * Method unSpawn. undo a spawn, removing any and all bookkeeping of that spawning
      ///	 *  </summary>
      ///	 * <param name="spawnID"> spawnID of the spawn to undo </param>
      ///	 * <returns> the fixed unspawned node </returns>
      ///	 
      public virtual JDFNode unSpawn(string spawnID)
      {
         if (spawnID == null || spawnID.Equals(JDFConstants.EMPTYSTRING))
            return null;

         JDFNode nodeParent = findUnSpawnNode(node, spawnID);
         return unSpawnNode(nodeParent, spawnID);

      }

      ///   
      ///	 * <param name="spawnID"> </param>
      ///	 * <param name="mapSpawn"> </param>
      ///	 
      private JDFNode findUnSpawnNode(JDFNode myNode, string spawnID)
      {
         VElement vJDFNodes = myNode.getvJDFNode(null, null, false);
         JDFAttributeMap mapSpawn = new JDFAttributeMap(AttributeName.NEWSPAWNID, spawnID);

         int i = 0;
         int size = vJDFNodes.Count;
         // loop over all
         for (i = 0; i < size; i++)
         {
            JDFNode nodeParent = (JDFNode)vJDFNodes[i];

            JDFAuditPool auditPool = nodeParent.getAuditPool();
            if (auditPool != null)
            {
               JDFAudit spawnAudit = auditPool.getAudit(0, JDFAudit.EnumAuditType.Spawned, mapSpawn, null);
               // we have a matching spawned audit -> n is the parent node that
               // spawned spawnID
               // let n fix the rest!
               if (spawnAudit != null)
               {
                  // loop over all
                  // look into the audit pool and search something, which was
                  // merged
                  JDFAttributeMap mapMerge = new JDFAttributeMap(JDFConstants.MERGEID, spawnID);

                  JDFAudit mergedAudit = auditPool.getAudit(0, JDFAudit.EnumAuditType.Merged, mapMerge, null);

                  if (mergedAudit == null)
                  {
                     return nodeParent;
                  }
               }
            }
         }
         JDFNode parent = myNode.getParentJDF();
         return parent == null ? null : findUnSpawnNode(parent, spawnID);
      }

      ///   
      ///	 <summary> * unSpawnNode - undo a spawn of a node hier muss noch nachportiert werden - es gibt jetzt in JDFRoot eine Methode
      ///	 * gleichen Namens, bei der man komfortabler das undo aufrufen kann. die Methode hier in JDFNode wird dann umbenannt
      ///	 * (protected) und aus JDFRoot heraus aufgerufen.
      ///	 *  </summary>
      ///	 * <param name="String"> - strSpawnID id of the node, which was spawned before
      ///	 *  </param>
      ///	 * <returns> the fixed unspawned node </returns>
      ///	 
      private JDFNode unSpawnNode(JDFNode parent, string strSpawnID)
      {
         if (parent == null)
            return null;
         JDFSpawned spawnAudit = null;

         JDFNode localNode = null;
         if (strSpawnID != null && !strSpawnID.Equals(JDFConstants.EMPTYSTRING))
         {
            JDFAuditPool auditPool = parent.getAuditPool();
            if (auditPool != null)
            {
               // look into the audit pool and search something, which was
               // spawned
               JDFAttributeMap mapSpawn = new JDFAttributeMap(JDFConstants.NEWSPAWNID, strSpawnID);
               spawnAudit = (JDFSpawned)auditPool.getAudit(0, JDFAudit.EnumAuditType.Spawned, mapSpawn, null);
               if (spawnAudit == null)
               {
                  return null; // nothing was spawned so we can undo nothing
               }

               // get parts from audit
               VJDFAttributeMap parts = spawnAudit.getPartMapVector();
               VString vs = spawnAudit.getrRefsROCopied();

               int i = 0;
               for (i = 0; i < vs.Count; i++)
               {
                  JDFResource oldRes = (JDFResource)parent.getTarget(vs[i], AttributeName.ID);
                  if (oldRes != null)
                  {
                     oldRes.unSpawnPart(strSpawnID, JDFResource.EnumSpawnStatus.SpawnedRO);
                  }
               }

               // merge rw resources
               VString vRWCopied = spawnAudit.getrRefsRWCopied();

               for (i = 0; i < vRWCopied.Count; i++)
               {
                  JDFResource oldRes = (JDFResource)parent.getTarget(vRWCopied[i], AttributeName.ID);
                  if (oldRes != null)
                  {
                     oldRes.unSpawnPart(strSpawnID, JDFResource.EnumSpawnStatus.SpawnedRW);
                  }
               }

               localNode = (JDFNode)parent.getTarget(spawnAudit.getjRef(), AttributeName.ID);
               VElement vn = localNode.getvJDFNode(null, null, false);
               // in C++ Vector is VJDFNode, which is typesafe

               // loop over all child nodes of the spawned node to be unspawned
               for (int nod = 0; nod < vn.Count; nod++)
               {
                  JDFNode deepNode = (JDFNode)vn[nod];
                  JDFResourcePool resPool = deepNode.getResourcePool();

                  if (resPool != null)
                  {
                     VElement vRes = resPool.getPoolChildren(null, null, null);

                     for (i = 0; i < vRes.Count; i++)
                     {
                        JDFResource res1 = (JDFResource)vRes[i];
                        res1.unSpawnPart(strSpawnID, JDFResource.EnumSpawnStatus.SpawnedRW);
                     }
                  }
               }

               EnumNodeStatus status = JDFElement.EnumNodeStatus.Waiting;
               bool fHasAuditStatus = spawnAudit.hasAttribute(AttributeName.STATUS);
               if (fHasAuditStatus)
               {
                  status = spawnAudit.getStatus();
               }

               if (parts != null)
               {
                  EnumNodeStatus parentStatus = parent.getStatus();
                  if (JDFElement.EnumNodeStatus.Pool.Equals(parentStatus) || JDFElement.EnumNodeStatus.Part.Equals(parentStatus))
                  {
                     for (i = 0; i < parts.Count; i++)
                     {
                        if ((parent.getPartStatus(parts[i]).Equals(JDFElement.EnumNodeStatus.Spawned)) || fHasAuditStatus)
                        {
                           parent.setPartStatus(parts[i], status, null);
                        }
                     }
                  }
                  else if (JDFElement.EnumNodeStatus.Spawned.Equals(parentStatus) || spawnAudit.hasAttribute(AttributeName.STATUS))
                  {
                     parent.setStatus(status);
                  }
               }
               else
               {
                  // we either must overwrite because it is now definitely not
                  // spawned
                  // or had an explicit correct status in the spawned audit
                  if (JDFElement.EnumNodeStatus.Spawned.Equals(localNode.getStatus()) || spawnAudit.hasAttribute(AttributeName.STATUS))
                  {
                     localNode.setStatus(status);
                  }
               }
            }

            if (spawnAudit != null)
            {
               spawnAudit.deleteNode();
            }
         }
         return localNode;
      }
   }
}
