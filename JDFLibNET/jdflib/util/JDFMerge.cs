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
 *    Alternately, this acknowledgment mrSubRefay appear in the software itself,
 *    if and wherever such third-party acknowledgments normally appear.
 *
 * 4. The names "CIP4" and "The International Cooperation for the Integration of
 *    Processes in  Prepress, Press and Postpress" must
 *    not be used to endorse or promote products derived from this
 *    software without prior written permission. For written
 *    permission, please contact info@cip4.org.
 *
 * 5. Products derived from this software may not be called "CIP4",
 *    nor may "CIP4" appear in their name, without prior writtenrestartProcesses()
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
 * SPECIAL, EXEMPLARY, OR CONSEQUENTIrSubRefAL DAMAGES (INCLUDING, BUT NOT
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
 * originally based on software restartProcesses()
 * copyright (c) 1999-2001, Heidelberger Druckmaschinen AG
 * copyright (c) 1999-2001, Agfa-Gevaert N.V.
 *
 * For more information on The International Cooperation for the
 * Integration of Processes in  Prepress, Press and Postpress , please see
 * <http://www.cip4.org/>.
 */


namespace org.cip4.jdflib.util
{
   using System.Collections.Generic;


   using EnumClass = org.cip4.jdflib.auto.JDFAutoNotification.EnumClass;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFAudit = org.cip4.jdflib.core.JDFAudit;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFPartAmount = org.cip4.jdflib.core.JDFPartAmount;
   using JDFPartStatus = org.cip4.jdflib.core.JDFPartStatus;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using EnumAuditType = org.cip4.jdflib.core.JDFAudit.EnumAuditType;
   using EnumVersion = org.cip4.jdflib.core.JDFElement.EnumVersion;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using JDFSpawned = org.cip4.jdflib.node.JDFSpawned;
   using EnumCleanUpMerge = org.cip4.jdflib.node.JDFNode.EnumCleanUpMerge;
   using JDFAmountPool = org.cip4.jdflib.pool.JDFAmountPool;
   using JDFAncestorPool = org.cip4.jdflib.pool.JDFAncestorPool;
   using JDFAuditPool = org.cip4.jdflib.pool.JDFAuditPool;
   using JDFResourceLinkPool = org.cip4.jdflib.pool.JDFResourceLinkPool;
   using JDFResourcePool = org.cip4.jdflib.pool.JDFResourcePool;
   using JDFStatusPool = org.cip4.jdflib.pool.JDFStatusPool;
   using JDFMerged = org.cip4.jdflib.resource.JDFMerged;
   using JDFNotification = org.cip4.jdflib.resource.JDFNotification;
   using JDFProcessRun = org.cip4.jdflib.resource.JDFProcessRun;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using EnumAmountMerge = org.cip4.jdflib.resource.JDFResource.EnumAmountMerge;
   using EnumPartUsage = org.cip4.jdflib.resource.JDFResource.EnumPartUsage;
   using EnumSpawnStatus = org.cip4.jdflib.resource.JDFResource.EnumSpawnStatus;

   ///
   /// <summary> * @author Rainer Prosi This class is used when merging a JDF node it summarizes all merging routines the had been part
   /// *         of JDF Node </summary>
   /// 
   public class JDFMerge
   {

      private JDFSpawned spawnAudit = null;
      private readonly JDFNode m_ParentNode;
      private JDFNode subJDFNode;
      private SupportClass.SetSupport<string> vsRO;
      private SupportClass.SetSupport<string> vsRW;
      private string spawnID = null;
      private readonly VString previousMergeIDs = new VString(); // list of merges in
      // the ancestors
      private bool bSnafu = true;
      private JDFNode overWriteNode;
      private Dictionary<string, JDFSpawned> newSpawnMap = null;

      ///   
      ///	 <summary> * set this to true if you want to update the stati of the relevant parent nodes based on the new Stati of the
      ///	 * merged node </summary>
      ///	 
      public bool bUpdateStati = false;

      ///   
      ///	 <summary> * set this to true if you want to update the ProcessRun(s) timestamps for this merge </summary>
      ///	 
      public bool bAddMergeToProcessRun = false;

      ///   
      ///	 <summary> *  </summary>
      ///	 * <param name="parentNode"> the parent node to merge into. MAY be the actual node to be replace or any Parent thereof </param>
      ///	 
      public JDFMerge(JDFNode parentNode)
      {
         m_ParentNode = parentNode;
      }

      ///   
      ///	 <summary> * merge a previously spawned JDF into a node that is a child of, or this root
      ///	 * <p>
      ///	 * default: mergeJDF(subJDFNode, null, JDFNode.EnumCleanUpMerge.None, JDFResource.EnumAmountMerge.None)
      ///	 *  </summary>
      ///	 * <param name="subJDFNode"> the previously spawned jdf node </param>
      ///	 * <param name="urlMerge"> the url of the ??? </param>
      ///	 * <param name="cleanPolicy"> policy how to clean up the spawn and merge audits after merging </param>
      ///	 * <param name="amountPolicy"> policy how to clean up the Resource amounts after merging </param>
      ///	 * <returns> JDFNode - the merged node in the new document<br>
      ///	 *         note that the return value used to be boolean. The boolean value is now replaced by exceptions. This
      ///	 *         corresponds to <code>true</code> always.
      ///	 *  </returns>
      ///	 * <exception cref="JDFException"> if subJDFNode has already been merged </exception>
      ///	 * <exception cref="JDFException"> if subJDFNode was not spawned from this </exception>
      ///	 * <exception cref="JDFException"> if subJDFNode has no AncestorPool
      ///	 * 
      ///	 *             default: mergeJDF(subJDFNode, null, JDFNode.EnumCleanUpMerge.None, JDFResource.EnumAmountMerge.None) </exception>
      ///	 

      public virtual JDFNode mergeJDF(JDFNode _toMerge, string urlMerge, EnumCleanUpMerge cleanPolicy, JDFResource.EnumAmountMerge amountPolicy)
      {
         subJDFNode = _toMerge;
         if (subJDFNode == null || !subJDFNode.hasParent(m_ParentNode))
         {
            throw new JDFException("JDFNode.MergeJDF no matching parent found");
         }

         string idm = subJDFNode.getID();
         overWriteNode = (JDFNode)m_ParentNode.getTarget(idm, AttributeName.ID);

         if (overWriteNode == null)
         {
            throw new JDFException("JDFNode.MergeJDF no Node with ID: " + idm);
         }

         analyzeAuditPool(idm);
         // get parts from audit
         VJDFAttributeMap parts = spawnAudit.getPartMapVector();

         // merge copied readOnly resources
         vsRO = spawnAudit.getrRefsROCopied().getSet();
         vsRW = spawnAudit.getrRefsRWCopied().getSet();

         string preSpawn = mergeCheckPrespawn();

         mergeLocalLinks(parts);

         cleanROResources();
         mergeRWResources(amountPolicy);

         mergeLocalNodes(amountPolicy, parts);
         JDFMerged mergeAudit = mergeMainPools(parts, preSpawn, urlMerge);
         // an empty spawnID should never happen here, but check just in case
         // since an empty spawnID in CleanUpMerge removes all Spawned audits
         if (spawnID != null)
         {
            JDFNode overWriteParent = mergeAudit.getParentJDF(); // since all
            // links get
            // screwed
            // up, let's
            // relink
            // here
            cleanUpMerge(overWriteParent, cleanPolicy, false);
         }

         // now burn it in!
         overWriteNode = (JDFNode)overWriteNode.replaceElement(subJDFNode);
         overWriteNode.eraseEmptyNodes(true);
         // overWriteNode.synchParentAmounts(); // add all actualamounts into the
         // merged parent gray box
         // update all stati (generally in NodeInfo) of the merged node and of
         // the parents of the merged node
         if (bUpdateStati)
            overWriteNode.updatePartStatus(parts, true, true);
         return overWriteNode;
      }

      private void analyzeAuditPool(string idm)
      {
         // tbd multiple ancestor handling
         JDFAncestorPool ancestorPool = subJDFNode.getAncestorPool();
         if (ancestorPool == null)
         {
            throw new JDFException("JDFNode.MergeJDF no Ancestor Pool in Node: " + idm);
         }
         int numAncestors = ancestorPool.numChildElements(ElementName.ANCESTOR, null);

         if (numAncestors <= 0)
         {
            throw new JDFException("JDFNode.MergeJDF no Ancestors in AncestorPool found. Node: " + idm);
         }

         int iFound = 0;
         for (int whereToLook = 1; whereToLook <= numAncestors; whereToLook++)
         {
            // the last ancestor has the id!
            string idParent = ancestorPool.getAncestor(numAncestors - whereToLook).getNodeID();
            KElement k = m_ParentNode.getTarget(idParent, AttributeName.ID);
            if (k == null)
            {
               break;
            }

            JDFNode op = (JDFNode)k;
            JDFAuditPool ap = op.getCreateAuditPool();

            // find all ids of previous merge operations for reverse merge
            // cleanup
            VElement vMergeAudit = ap.getAudits(EnumAuditType.Merged, null, null);
            for (int nMerged = 0; nMerged < vMergeAudit.Count; nMerged++)
            {
               JDFMerged merged = (JDFMerged)vMergeAudit[nMerged];
               previousMergeIDs.appendUnique(merged.getMergeID());
            }

            if (iFound != 0) // we've already found a spawned Audit, just
            // looping for previous merges
            {
               continue;
            }

            // get appropriate spawned element
            VElement vSpawnAudit = ap.getChildrenByTagName(ElementName.SPAWNED, null, new JDFAttributeMap(AttributeName.JREF, idm), true, true, 0);
            spawnID = subJDFNode.getSpawnID(false);

            for (int isp = vSpawnAudit.Count - 1; isp >= 0; isp--)
            { // loop backwards because the latest is assumed correct
               JDFSpawned testSpawn = (JDFSpawned)vSpawnAudit[isp];
               if (testSpawn.getNewSpawnID().Equals(spawnID))
               {
                  // tbd check for matching merged...
                  spawnAudit = testSpawn;
                  JDFMerged matchingMerged = (JDFMerged)ap.getChildWithAttribute(ElementName.MERGED, AttributeName.MERGEID, null, spawnID, 0, true);

                  if (matchingMerged != null)
                  {
                     throw new JDFException("JDFNode.MergeJDF Spawn Audit already merged, SpawnID: " + spawnID, JDFSpawn.exAlreadyMerged);
                  }
                  break;
               }
            }
            // found an audit that fits,
            if (spawnAudit != null)
            {
               iFound = whereToLook;
            }
         }

         // if the spawn Audit is not found at the first attempt, something went
         // badly wrong
         // we will insert a error audit later but continue limping along!
         bSnafu = iFound != 1;

         if (spawnAudit == null)
         {
            throw new JDFException("JDFNode.MergeJDF no matching Spawn Audit, SpawnID: " + spawnID);
         }
      }

      ///   
      ///	 <summary> * merge the audit pools
      ///	 *  </summary>
      ///	 * <param name="overWriteNode"> </param>
      ///	 * <param name="subJDFNode"> the source node of the audit pool to merge into this </param>
      ///	 
      private void mergeAuditPool(JDFNode poverWriteNode, JDFNode toMerge)
      {
         // merge audit pool
         JDFAuditPool overWriteAuditPool = poverWriteNode.getAuditPool();
         JDFAuditPool toMergeAuditPool = toMerge.getAuditPool();

         // the node that is overwritten has an audit pool that must be merged
         if (overWriteAuditPool != null)
         {
            // the overwriting node node is empty, just copy the previous pool
            if (toMergeAuditPool == null)
            {
               toMerge.copyElement(overWriteAuditPool, null);
            }
            else
            {
               // must merge the old node into the overwriting node
               overWriteAuditPool.appendUnique(toMergeAuditPool);
               toMergeAuditPool.replaceElement(overWriteAuditPool);
            }
         }
      }


      private string mergeCheckPrespawn()
      {
         string preSpawn = spawnAudit.getSpawnID();
         // check all recursive previous spawns
         while (preSpawn != null && !preSpawn.Equals(JDFConstants.EMPTYSTRING))
         {
            JDFMerged preMerge = (JDFMerged)m_ParentNode.getTarget(preSpawn, AttributeName.MERGEID);
            if (preMerge != null)
            {
               JDFSpawned preSpawnAudit = (JDFSpawned)m_ParentNode.getTarget(preSpawn, AttributeName.NEWSPAWNID);
               vsRO.AddAll(preSpawnAudit.getrRefsROCopied());
               vsRW.AddAll(preSpawnAudit.getrRefsRWCopied());
               preSpawn = preSpawnAudit.getSpawnID();
            }
            else
            {
               subJDFNode.setSpawnID(preSpawn);
               break;
            }
         }
         return preSpawn;
      }


      private void mergeComments(JDFNode poverWriteNode, JDFNode toMerge)
      {
         VElement v = poverWriteNode.getChildElementVector(ElementName.COMMENT, null, null, false, 0, false);
         VElement vToMerge = toMerge.getChildElementVector(ElementName.COMMENT, null, null, false, 0, false);
         int siz = vToMerge.Count; // size prior to appending
         vToMerge.appendUnique(v);
         for (int i = siz; i < vToMerge.Count; i++)
         {
            toMerge.moveElement(vToMerge[i], null);
         }
      }

      private void mergeLocalLinks(VJDFAttributeMap parts)
      {
         int numParts = parts == null ? 0 : parts.Count;
         VElement vn = overWriteNode.getvJDFNode(null, null, false);
         int size = vn.Count;
         // merge local (internal) partitioned resource links
         for (int nod = 0; nod < size; nod++)
         {
            JDFNode overwriteLocalNode = (JDFNode)vn[nod];
            JDFNode toMergeLocalNode = subJDFNode.getChildJDFNode(overwriteLocalNode.getID(), false);
            mergeResourceLinkPool(overwriteLocalNode, toMergeLocalNode, parts);

            EnumVersion version = toMergeLocalNode.getVersion(true);
            if ((version != null) && (version.getValue() >= EnumVersion.Version_1_3.getValue()))
            {
               JDFNode.EnumNodeStatus stat = toMergeLocalNode.getStatus();
               if (stat != null && !stat.Equals(JDFElement.EnumNodeStatus.Part) && !stat.Equals(JDFElement.EnumNodeStatus.Pool) && numParts > 0)
               {
                  toMergeLocalNode.setPartStatus(parts, stat, null);
               }
            }
         }
      }



      private void mergeLocalNodes(JDFResource.EnumAmountMerge amountPolicy, VJDFAttributeMap parts)
      {
         // merge local (internal) partitioned resources
         VElement vn = overWriteNode.getvJDFNode(null, null, false);
         for (int nod = 0; nod < vn.Count; nod++)
         {
            JDFNode overwriteLocalNode = (JDFNode)vn[nod];

            JDFNode toMergeLocalNode = (JDFNode)subJDFNode.getTarget(overwriteLocalNode.getID(), AttributeName.ID);
            JDFResourcePool poolOverWrite = overwriteLocalNode.getResourcePool();
            JDFResourcePool poolToMerge = toMergeLocalNode.getResourcePool();

            if (poolOverWrite != null)
            {
               VElement resOverWrite = poolOverWrite.getPoolChildren(null, null, null);

               int size = resOverWrite.Count;
               for (int i = 0; i < size; i++)
               {
                  JDFResource res1 = (JDFResource)resOverWrite[i];
                  mergeLocalResource(amountPolicy, poolToMerge, res1);
               }
            }

            // retain all other elements of the original (non spawned) JDF Node
            // if the spawn is partitioned¬
            VElement localChildren = overwriteLocalNode.getChildElementVector(null, null, null, true, 0, false);

            int siz = localChildren.Count;
            for (int i = 0; i < siz; i++)
            {
               KElement e = localChildren[i];
               // skip all pools
               string nodeName = e.LocalName;
               if (nodeName.EndsWith("Pool"))
               {
                  if (nodeName.Equals(ElementName.RESOURCELINKPOOL))
                  {
                     continue;
                  }
                  if (nodeName.Equals(ElementName.RESOURCEPOOL))
                  {
                     continue;
                  }
                  if (nodeName.Equals(ElementName.AUDITPOOL))
                  {
                     mergeAuditPool(overwriteLocalNode, toMergeLocalNode);
                     continue;
                  }
                  if (nodeName.Equals(ElementName.STATUSPOOL))
                  {
                     mergeStatusPool(overwriteLocalNode, toMergeLocalNode, parts);
                     continue;
                  }
                  if (nodeName.Equals(ElementName.ANCESTORPOOL))
                  {
                     continue;
                  }
               }

               // 131204 RP also skip all sub-JDF nodes!!!
               if (nodeName.Equals(ElementName.JDF))
               {
                  continue;
               }
               // 050708 RP special handling for comments
               if (nodeName == ElementName.COMMENT)
               {
                  mergeComments(overwriteLocalNode, toMergeLocalNode);
                  continue;
               }

               toMergeLocalNode.removeChildren(nodeName, null, null);
               toMergeLocalNode.moveElement(e, null);

               // repeat in case of multiple identical elements (e.g. comments)
               for (int j = i + 1; j < siz; j++)
               {
                  JDFElement localChild = (JDFElement)localChildren[j];
                  if (localChild != null)
                  {
                     if (localChild.Name.Equals(nodeName))
                     {
                        toMergeLocalNode.moveElement(localChild, null);
                        localChildren[j] = null;
                     }
                  }
               }
            }
         }
      }

      ///   
      ///	 <summary> * Merges partitioned resources into this resource uses PartIDKey to identify the correct resources
      ///	 *  </summary>
      ///	 * <param name="resToMerge"> the resource leaf to merge into this </param>
      ///	 * <param name="spawnID"> the spawnID of the spawning that will now be merged </param>
      ///	 * <param name="amountPolicy"> how to clean up the Resource amounts after merging </param>
      ///	 * <param name="bLocalResource"> must be true for the local resources in a spawned node and its subnodes, which default to
      ///	 *            RW
      ///	 *  </param>
      ///	 * <exception cref="JDFException"> if here is an attempt to merge incompatible resources </exception>
      ///	 * <exception cref="JDFException"> if here is an attempt to merge incompatible partitions
      ///	 * 
      ///	 * @default mergePartition (resToMerge, spawnID, EnumAmountMerge.None, false); </exception>
      ///	 
      //   
      //	 * mergePartition will stay public, as long as deprecated JDFResource.mergePartition is not deleted
      //	 
      public static JDFResource mergePartition(JDFResource targetRes, JDFResource resToMerge, string spawnID, EnumAmountMerge amountPolicy, bool bLocalResource)
      {
         if (!targetRes.getID().Equals(resToMerge.getID()))
         {
            throw new JDFException("JDFResource.mergePartition  merging incompatible resources ID=" + targetRes.getID() + " IDMerge=" + resToMerge.getID());
         }

         // / TBD RP SpawnStatus Handling!!!!
         JDFResource toMerge = resToMerge;
         JDFResource root = targetRes.getResourceRoot();
         VString partIDKeys = root.getPartIDKeys();
         VString mergeIDKeys = toMerge.getPartIDKeys();
         VElement allChildren = resToMerge.getNodesWithSpawnID(spawnID);

         // No spawntargets take all
         if (allChildren.IsEmpty())
         {
            allChildren.Add(toMerge);
         }

         bool bTargetGone = false;
         for (int i = 0; i < allChildren.Count; i++)
         {
            JDFResource src = (JDFResource)allChildren[i];
            if (src.getIdentical() != null)
               continue; // no need to merge identical elements
            JDFAttributeMap srcMap = src.getPartMap(mergeIDKeys);
            JDFResource trg = targetRes.getPartition(srcMap, EnumPartUsage.Implicit);

            if (trg == null)
            {
               trg = targetRes;
            }
            JDFAttributeMap trgMap = trg.getPartMap();

            // RP 220605 - not puristic, but pragmatic
            // found only a root or high level partition for an rw resource
            // partition
            // try to create the new partition and pray that it will not be
            // subsequently completely overwritten
            // this is still better than throwing an exception or silently
            // ignoring the rw resource
            if ((src.getLocked() == false) && (trgMap.getKeys().Count < srcMap.getKeys().Count))
            {
               trg = targetRes.getCreatePartition(srcMap, partIDKeys);
               // fool the algorithm to think that the new partition is rw
               // (which it probably was)
               trg.setSpawnStatus(EnumSpawnStatus.SpawnedRW);
               trgMap = trg.getPartMap(); // 061114 fix!
            }

            if (bLocalResource || trg.getSpawnStatus() == JDFResource.EnumSpawnStatus.SpawnedRW)
            {

               if (srcMap.Equals(trgMap))
               {
                  if (trgMap.IsEmpty())
                  { // we actually replaced the root nothing left to do
                     bTargetGone = true;
                     trg = (JDFResource)targetRes.replaceElement(src);
                     root = trg.getResourceRoot();
                  }
                  else
                  {
                     KElement copyElement = targetRes.copyElement(src, null);
                     trg = (JDFResource)trg.replaceElement(copyElement);
                  }
               }
               else if (srcMap.subMap(trgMap))
               {
                  if (trgMap.Count + 1 != srcMap.Count)
                     throw new JDFException("JDFResource.mergePartition attempting to merge incompatible sub-partitions!");

                  trg.copyElement(src, null);
               }
               else
               { // oops
                  throw new JDFException("JDFResource.mergePartition attempting to merge incompatible partitions");
               }
            }
            // update the partitions amounts
            if ((amountPolicy != EnumAmountMerge.None) && targetRes.isPhysical())
            {
               JDFResource trgKeep = trg;
               trg = root.getPartition(srcMap, EnumPartUsage.Implicit); // must
               // repeat
               // since
               // replaceelement
               // does
               // not
               // modify
               // itself
               if (trg == null)
               {
                  trg = trgKeep;
               }
               VElement vr = trg.getLeaves(true);
               for (int l = 0; l < vr.Count; l++)
               {
                  double amo = 0;
                  JDFResource r = (JDFResource)vr[l];
                  if (amountPolicy != EnumAmountMerge.LinkOnly)
                  {
                     amo = r.getAmount();
                  }
                  r.updateAmounts(amo);
               }
            }
         }

         // some crap is left - remove it
         if (!bTargetGone)
         {
            toMerge.deleteNode();
         }

         partIDKeys.appendUnique(mergeIDKeys);

         if (partIDKeys.IsEmpty())
         {
            root.removeAttribute(AttributeName.PARTIDKEYS);
         }
         else
         {
            root.setPartIDKeys(partIDKeys);
         }
         return root;
      }

      private void mergeLocalResource(JDFResource.EnumAmountMerge amountPolicy, JDFResourcePool poolToMerge, JDFResource res1)
      {
         JDFResource res1Local = res1;

         string resID = res1Local.getID();
         JDFResource res2 = poolToMerge.getResourceByID(resID);

         if (res2 != null)
         {
            mergeSpawnIDs(res2, res1Local, false);
            res1Local = mergePartition(res1Local, res2, spawnID, amountPolicy, true); // esp
            // .
            // deletes
            // res2
            // from
            // subJDFNode
            // node
         }
         // copy resource from orig to spawned node
         poolToMerge.copyElement(res1Local, null);
         res1Local = poolToMerge.getResourceByID(resID);
         VElement resLeafsSpawned = res1Local.getNodesWithSpawnID(spawnID);
         for (int leaf = 0; leaf < resLeafsSpawned.Count; leaf++)
         {
            JDFResource leafRes = (JDFResource)resLeafsSpawned[leaf];
            leafRes.removeFromSpawnIDs(spawnID);
            VString spawnIDs = leafRes.getSpawnIDs(false);
            if (spawnIDs != null)
               spawnIDs.removeStrings(previousMergeIDs, int.MaxValue);
            leafRes.setSpawnIDs(spawnIDs);
            calcSpawnStatus(leafRes, true);
         }
      }

      private void calcSpawnStatus(JDFResource leafRes, bool bLocal)
      {
         if (leafRes == null)
            return;
         prepareNewSpawnMap();
         VString spawnIDs = leafRes.getSpawnIDs(false);
         string resID = leafRes.getID();
         if (spawnIDs == null || spawnIDs.IsEmpty())
         {
            removeSpawnAttributes(leafRes);
            return;
         }
         else if (bLocal || vsRW.Contains(resID))
         {
            bool bWrite = bLocal;

            for (int i = 0; i < spawnIDs.Count; i++) // check for multiple rw
            // spawns
            {

               string resSpawnID = spawnIDs.stringAt(i);
               // JDFSpawned spawnedAudit=(JDFSpawned)
               // (m_ParentNode.getChildByTagName(ElementName.SPAWNED, null, 0,
               // new JDFAttributeMap(AttributeName.NEWSPAWNID,resSpawnID),
               // false, true));
               JDFSpawned spawnedAudit;
               newSpawnMap.TryGetValue(resSpawnID, out spawnedAudit);
               if (spawnedAudit != null)
               {
                  VString rw = spawnedAudit.getrRefsRWCopied();
                  if (rw != null && rw.Contains(resID))
                  {
                     bWrite = true;
                  }
               }
               else
               // clean up spurious spawnids of spawns that were initiated off
               // line
               {
                  string mainSpawnID = leafRes.getJDFRoot().getSpawnID(true);
                  if (KElement.isWildCard(mainSpawnID)) // only remove unknown
                  // spawnids in a
                  // real main ticket
                  // Spawned spawnids
                  // may be specified
                  // in a spawn
                  // ancestor
                  {
                     leafRes.removeFromAttribute(AttributeName.SPAWNIDS, resSpawnID, null, null, -1);
                     VString spawnIDsNew = leafRes.getSpawnIDs(false);
                     if (spawnIDsNew == null || spawnIDsNew.IsEmpty())
                     {
                        removeSpawnAttributes(leafRes);
                        return;
                     }
                  }
               }
            }
            if (bWrite)
            {
               leafRes.setSpawnStatus(EnumSpawnStatus.SpawnedRW);
               leafRes.setLocked(true);
            }
            else
            {
               leafRes.setSpawnStatus(EnumSpawnStatus.SpawnedRO);
               leafRes.setLocked(false);
            }
         }
         else
         // this was ro
         {
            // nop
         }
      }

      ///   
      ///	 * <param name="leafRes"> </param>
      ///	 
      private void removeSpawnAttributes(JDFResource leafRes)
      {
         leafRes.removeAttribute(AttributeName.SPAWNIDS);
         leafRes.removeAttribute(AttributeName.SPAWNSTATUS);
         leafRes.removeAttribute(AttributeName.LOCKED);
      }

      ///   
      ///     <summary> *  </summary>
      ///     
      private void prepareNewSpawnMap()
      {
         if (newSpawnMap != null)
            return;

         newSpawnMap = new Dictionary<string, JDFSpawned>();
         // VElement v=m_ParentNode.getChildrenByTagName(ElementName.SPAWNED,
         // null, null, false, true, 0, false);
         VElement v = m_ParentNode.getvJDFNode(null, null, false);
         for (int i = 0; i < v.Count; i++)
         {
            JDFNode n = (JDFNode)v[i];
            JDFAuditPool ap = n.getAuditPool();
            VElement v2 = ap == null ? null : ap.getAudits(EnumAuditType.Spawned, null, null);
            if (v2 != null)
            {
               // JDFSpawned s=(JDFSpawned) v.get(i);
               int siz = v2.Count;
               for (int j = 0; j < siz; j++)
               {
                  JDFSpawned s = (JDFSpawned)v2[j];
                  string nsID = s.getNewSpawnID();
                  if (!KElement.isWildCard(nsID))
                     newSpawnMap.Add(nsID, s);
               }
            }
         }

      }

      

      private JDFMerged mergeMainPools(VJDFAttributeMap parts, string preSpawn, string urlMerge)
      {
         // add the merged audit - maintain sychronicity of spawned and merged
         JDFNode overWriteParent = null;
         JDFAuditPool ap = subJDFNode.getAuditPool();
         JDFSpawned spawnedAudit = null;

         if (ap != null)
         {
            spawnedAudit = (JDFSpawned)ap.getChildWithAttribute(ElementName.SPAWNED, AttributeName.NEWSPAWNID, null, spawnID, 0, true);
            overWriteParent = overWriteNode;
         }

         if (spawnedAudit == null)
         {
            overWriteParent = overWriteNode.getParentJDF();
            if (overWriteParent == null)
            {
               throw new JDFException("mergeMainPools - corrupt audit structure");
            }

            ap = overWriteParent.getAuditPool();
            if (ap != null)
               spawnedAudit = (JDFSpawned)ap.getChildWithAttribute(ElementName.SPAWNED, AttributeName.NEWSPAWNID, null, spawnID, 0, true);
         }

         if (spawnedAudit == null || overWriteParent == null || ap == null)
         {
            // ????
            throw new JDFException("mergeMainPools - corrupt audit structure; no Spawn Audit found");
         }

         // JDFNode overWriteParent=ap.getParentJDF();
         VString vs = new VString();
         IEnumerator<string> it = vsRW.GetEnumerator();
         while (it.MoveNext())
            vs.Add(it.Current);

         JDFMerged mergeAudit = ap.addMerged(subJDFNode, vs, null, parts);

         if (urlMerge != null && !urlMerge.Equals(JDFConstants.EMPTYSTRING))
         {
            string url = urlMerge;
            // 300802 RP added check for preexisting file prefix
            if (url.IndexOf("://") == -1)
            {
               url = "File://" + url;
            }

            mergeAudit.setURL(url);
         }

         mergeAudit.setMergeID(spawnID);

         // if something went wrong, also add a notification
         if (bSnafu)
         {
            JDFNotification notification = ap.addNotification(EnumClass.Error, "JDFNode.MergeJDF ", parts);
            notification.setType("Error");
            notification.appendComment().appendText("The Ancestor list was incorrectly ordered for merging in the spawned JDF");
         }

         // cleanup
         subJDFNode.removeChild(ElementName.ANCESTORPOOL, null, 0);
         if (parts != null && parts.Count >= 1)
         {
            mergeStatusPool(overWriteNode, subJDFNode, parts);
            // handle ancestor pools only in partitioned spawns
            JDFAncestorPool ancPool = overWriteParent.getAncestorPool();
            if (ancPool != null)
            {
               subJDFNode.copyElement(ancPool, null);
            }
         }

         string jid = overWriteParent.getJobID(true);
         if (subJDFNode.getAttribute(AttributeName.JOBID, null, JDFConstants.EMPTYSTRING).Equals(jid))
         {
            subJDFNode.removeAttribute(AttributeName.JOBID, null);
         }
         if (preSpawn == null || preSpawn.Equals(JDFConstants.EMPTYSTRING))
         {
            subJDFNode.removeAttribute(AttributeName.SPAWNID, null);
            mergeAudit.removeAttribute(AttributeName.SPAWNID, null);
         }
         else
         {
            subJDFNode.setSpawnID(preSpawn);
         }

         return mergeAudit;
      }

      ///   
      ///	 <summary> * merge the resource link pools
      ///	 *  </summary>
      ///	 * <param name="oMerge"> the source node of the status pool to merge into this </param>
      ///	 * <param name="parts"> the partitions to merge </param>
      ///	 
      private void mergeResourceLinkPool(JDFNode mainNode, JDFNode toMerge, VJDFAttributeMap parts)
      {
         JDFResourceLinkPool resourceLinkPool = toMerge.getResourceLinkPool();
         expandLinkedResources(resourceLinkPool);

         JDFResourceLinkPool toMergeRLP = resourceLinkPool;
         if (toMergeRLP == null)
            return; // nothing to do

         JDFResourceLinkPool overWriteRLP = mainNode.getCreateResourceLinkPool();
         if (parts != null && !parts.IsEmpty())
         {
            VElement overWriteLinks = overWriteRLP.getPoolChildren(null, null, null);
            VElement toMergeLinks = toMergeRLP.getPoolChildren(null, null, null);

            if (toMergeLinks != null && overWriteLinks != null)
            {
               for (int rl = 0; rl < toMergeLinks.Count; rl++)
               {
                  JDFResourceLink overWriteLink = null;
                  JDFResourceLink toMergeLink = (JDFResourceLink)toMergeLinks[rl];
                  string rRef = toMergeLink.getAttribute(AttributeName.RREF);

                  for (int k = 0; k < overWriteLinks.Count; k++)
                  {
                     if (((JDFResourceLink)overWriteLinks[k]).getAttribute(AttributeName.RREF).Equals(rRef))
                     {
                        overWriteLink = (JDFResourceLink)overWriteLinks[k];
                        overWriteLinks.Remove(overWriteLinks[k]);
                        break;
                     }
                  }

                  if (overWriteLink != null)
                  {
                     if (toMergeLink.hasChildElement(ElementName.PART, null))
                     {
                        fixPartAmountAttributes(overWriteLink, toMergeLink);
                     }
                     else
                     {
                        // blast the spawned link into the overWritePool
                        // completely
                        overWriteLink.replaceElement(toMergeLink);
                     }
                  }
               }
            }

            toMergeRLP.deleteNode();
            toMerge.copyElement(overWriteRLP, null);
         }
         else
         // copy the rlp from sub to main so that amount recalc in mergerw finds
         // all required links in main
         {
            overWriteRLP.deleteNode();
            mainNode.copyElement(toMergeRLP, null);
         }
      }

      ///   
      ///	 * <param name="parts"> </param>
      ///	 * <param name="mainLink"> </param>
      ///	 * <param name="subLink"> </param>
      ///	 * <param name="jdfAmountPool"> </param>
      ///	 
      private void fixPartAmountAttributes(JDFResourceLink mainLink, JDFResourceLink subLink)
      {
         JDFAmountPool subAmountPool = subLink.getAmountPool();
         VJDFAttributeMap subLinkParts = subLink.getPartMapVector();
         int partSize = subLinkParts.Count;
         for (int i = 0; i < partSize; i++)
         {
            // final boolean hasAP =
            // mainLink.hasChildElement(ElementName.AMOUNTPOOL, null);
            VElement vSubPartAmounts = null;
            if (subAmountPool != null)
               vSubPartAmounts = subAmountPool.getMatchingPartAmountVector(subLinkParts[i]);

            if (vSubPartAmounts == null)
            {
               JDFAttributeMap subLinkMap = subLink.getAttributeMap();
               // remove generic link stuff
               subLinkMap.Remove(AttributeName.COMBINEDPROCESSINDEX);
               subLinkMap.Remove(AttributeName.COMBINEDPROCESSTYPE);
               // tbd opa.RemoveAttribute(atr_PipePartIDKeys);
               subLinkMap.Remove(AttributeName.PIPEPROTOCOL);
               subLinkMap.Remove(AttributeName.PROCESSUSAGE);
               subLinkMap.Remove(AttributeName.RREF);
               subLinkMap.Remove(AttributeName.RSUBREF);
               subLinkMap.Remove(AttributeName.USAGE);

               removeIdenticalFromPartAmountMap(mainLink, subLinkMap);

               // create a new partamount for each spawned part that contains
               // the contents of the outer link
               if (!subLinkMap.IsEmpty() && !subLinkMap.Equals(subLinkParts[i]))
               {
                  JDFPartAmount mainPartAmount = mainLink.getCreateAmountPool().getCreatePartAmount(subLinkParts[i]);
                  mainPartAmount.setAttributes(subLinkMap);
                  mainLink.removeAttributes(subLinkMap.getKeys());
               }
            }
            else
            // we found matching partamounts, clean them up and move them in
            {
               // loop over all fitting part amounts and blast them in
               for (int j = 0; j < vSubPartAmounts.Count; j++)
               {
                  JDFPartAmount subPartAmount = (JDFPartAmount)vSubPartAmounts[j];
                  JDFAttributeMap subAmountMap = subPartAmount.getAttributeMap();
                  removeIdenticalFromPartAmountMap(mainLink, subAmountMap);

                  if (!subAmountMap.IsEmpty())
                  {
                     JDFAttributeMap subPartMap = subPartAmount.getPartMap();
                     JDFPartAmount mainPartAmount = mainLink.getCreateAmountPool().getCreatePartAmount(subPartMap);
                     mainPartAmount.setAttributes(subAmountMap);
                     mainLink.removeAttributes(subAmountMap.getKeys());
                  }
               }
            }

            // nothing has changed --> leave as is
         }
      }

      private void removeIdenticalFromPartAmountMap(JDFResourceLink mainLink, JDFAttributeMap subLinkMap)
      {
         {
            JDFAttributeMap mainLinkMap = mainLink.getAttributeMap();
            IEnumerator<string> iter = mainLinkMap.getKeyIterator();
            while (iter.MoveNext())
            {
               string key = iter.Current;
               if (mainLinkMap.get(key).Equals(subLinkMap.get(key)))
                  subLinkMap.Remove(key);
            }
         }
      }

      ///   
      ///	 * <param name="resourceLinkPool"> the resourceLinkPool that contains the links to the resources to expand </param>
      ///	 
      private void expandLinkedResources(JDFResourceLinkPool resourceLinkPool)
      {
         if (resourceLinkPool != null)
         {
            VElement links = resourceLinkPool.getPoolChildren(null, null, null);
            if (links != null)
            {
               int size = links.Count;
               for (int i = 0; i < size; i++)
               {
                  JDFResourceLink rl = (JDFResourceLink)links[i];
                  // 071214 only expand if rw
                  if (vsRW.Contains(rl.getrRef()))
                     rl.expandTarget(false);
               }
            }
         }
      }

      ///   
      ///	 <summary> * Merges the spawnIDs of the various partitions <br>
      ///	 * also updates SpawnStatus, if necessary <br>
      ///	 * this routine is needed to correctly handle nested spawning and merging
      ///	 *  </summary>
      ///	 * <param name="mainres"> the resource in the main jdf to merge to </param>
      ///	 * <param name="resToMerge"> the resource with potentially new spawnIDs </param>
      ///	 * <param name="bReadOnly"> if true, don't add anything since it was RO
      ///	 *  </param>
      ///	 
      private void mergeSpawnIDs(JDFResource mainRes, JDFResource resToMerge, bool bReadOnly)
      {
         if (!mainRes.getID().Equals(resToMerge.getID()))
         {
            throw new JDFException("JDFResource.mergeSpawnIDs  merging incompatible resources ID = " + mainRes.getID() + " IDMerge = " + resToMerge.getID());
         }

         VElement allLeaves = mainRes.getLeaves(true);
         VString partIDKeys = mainRes.getPartIDKeys();
         for (int i = 0; i < allLeaves.Count; i++)
         {
            JDFResource thisResNode = (JDFResource)allLeaves[i];
            JDFResource mergeResNode = resToMerge.getPartition(thisResNode.getPartMap(partIDKeys), EnumPartUsage.Explicit);

            if (mergeResNode != null)
            {
               VString vSpawnIDs = thisResNode.getSpawnIDs(false);
               int siz = vSpawnIDs == null ? 0 : vSpawnIDs.Count;
               if (!bReadOnly) // only append from rw resources, not from ro
               {
                  if (vSpawnIDs == null)
                  {
                     vSpawnIDs = mergeResNode.getSpawnIDs(false);
                  }
                  else
                  {
                     vSpawnIDs.appendUnique(mergeResNode.getSpawnIDs(false));
                  }
               }
               if (vSpawnIDs != null)
                  vSpawnIDs.removeStrings(previousMergeIDs, 999999);

               if (vSpawnIDs == null || vSpawnIDs.IsEmpty())
               {
                  removeSpawnAttributes(thisResNode);
               }
               else if (siz < vSpawnIDs.Count)
               {
                  thisResNode.setSpawnIDs(vSpawnIDs);
                  // one of the spawnstatus elements was rw, must also be
                  // valid here
                  if (mergeResNode.getSpawnStatus() == EnumSpawnStatus.SpawnedRW)
                  {
                     thisResNode.setSpawnStatus(EnumSpawnStatus.SpawnedRW);
                  }
               }
            }
         }
      }

      ///   
      ///	 <summary> * merge the RW resources of the main JDF
      ///	 *  </summary>
      ///	 * <param name="subJDFNode"> the source node of the status pool to merge into this </param>
      ///	 * <param name="subJDFNode"> the source node of the status pool to merge into this </param>
      ///	 * <param name="previousMergeIDs"> SpawnIDs of previously merged </param>
      ///	 * <param name="vsRW"> Resource IDs of non-local spawned resources </param>
      ///	 * <param name="spawnID"> the original spawnID </param>
      ///	 * <param name="amountPolicy"> policy how to clean up the Resource amounts after merging </param>
      ///	 
      private void mergeRWResources(JDFResource.EnumAmountMerge amountPolicy)
      {
         // merge rw resources
         IEnumerator<string> it = vsRW.GetEnumerator();
         while (it.MoveNext())
         {
            string s = it.Current;
            JDFResource oldRes = overWriteNode.getLinkRoot(s);
            if (oldRes == null) // also check in tree below
            {
               oldRes = overWriteNode.getTargetResource(s);
               if (oldRes == null) // also check in entire tree below root
               {
                  oldRes = overWriteNode.getTargetResource(s);
               }
            }

            if (oldRes != null)
            {
               JDFResource newRes = subJDFNode.getTargetResource(s);

               // merge all potential new spawnIds from this to subJDFNode before
               // merging them
               mergeSpawnIDs(oldRes, newRes, false);
               // do both, since some leaves may be RO
               mergeSpawnIDs(newRes, oldRes, false);

               try
               {
                  // merge the resource from the spawned node into the lower level resourcepool
                  oldRes = mergePartition(oldRes, newRes, spawnID, amountPolicy, false);
               }
               catch (System.Exception)
               {
                  throw new JDFException("JDFNode:mergeJDF, error in mergePartition: ID=" + (oldRes == null ? ">>> oldRes is null !!! <<<" : oldRes.getID()) + " SpawnID=" + spawnID);
               }

               string oldID = oldRes.getID();
               JDFResource myRes = (JDFResource)overWriteNode.getTarget(oldID, AttributeName.ID);
               if (myRes == null)
               {
                  throw new JDFException("JDFNode.mergeJDF: Merged Resource not found! Cant remove SpawnIDs");
               }
               VElement oldResLeafsSpawned = myRes.getNodesWithSpawnID(spawnID);
               for (int leaf = 0; leaf < oldResLeafsSpawned.Count; leaf++)
               {
                  JDFResource leafRes = (JDFResource)oldResLeafsSpawned[leaf];
                  leafRes.removeFromSpawnIDs(spawnID);
                  calcSpawnStatus(leafRes, false);
               }
            }
         }

      }

      ///   
      ///	 <summary> * merge the status pools
      ///	 *  </summary>
      ///	 * <param name="subJDFNode"> the source node of the status pool to merge into this </param>
      ///	 * <param name="parts"> the partitions to merge </param>
      ///	 
      private void mergeStatusPool(JDFNode poverWriteNode, JDFNode toMerge, VJDFAttributeMap parts)
      {
         if (toMerge.hasChildElement(ElementName.STATUSPOOL, null) || poverWriteNode.hasChildElement(ElementName.STATUSPOOL, null))
         {
            JDFStatusPool overWriteStatusPool = poverWriteNode.getCreateStatusPool();
            if (!poverWriteNode.getStatus().Equals(JDFElement.EnumNodeStatus.Pool))
            {
               overWriteStatusPool.setStatus(poverWriteNode.getStatus());
               poverWriteNode.setStatus(JDFElement.EnumNodeStatus.Pool);
            }

            JDFStatusPool toMergeStatusPool = toMerge.getStatusPool();
            int size = parts == null ? 0 : parts.Count;
            if (JDFElement.EnumNodeStatus.Pool.Equals(toMerge.getStatus()))
            {
               if (parts != null)
               {
                  for (int i = 0; i < size; i++)
                  {
                     // clean up the pool to overwrite
                     VElement vpso = overWriteStatusPool.getMatchingPartStatusVector(parts[i]);
                     for (int j = 0; j < vpso.Count; j++)
                     {
                        // remove all matching partstatus elements in case 
                        // they were expanded in the spawned node
                        ((JDFPartStatus)vpso[j]).deleteNode();
                     }

                     // extract data from spawned node
                     VElement vps = toMergeStatusPool.getMatchingPartStatusVector(parts[i]);
                     for (int j = 0; j < vps.Count; j++)
                     {
                        JDFPartStatus ps = (JDFPartStatus)vps[j];
                        JDFAttributeMap m = ps.getPartMap();
                        overWriteStatusPool.setStatus(m, ps.getStatus(), ps.getStatusDetails());
                     }

                     // 100305 RP the following lines cause problems with nested
                     // spawn and therefore are commented out
                     // final JDFPartStatus
                     // ps=overWriteStatusPool.getPartStatus(parts[i]);
                     // just in case someone updated detailed partstatus elements
                     // if (ps != null && ps.getStatus() ==
                     // EnumNodeStatus.Spawned)
                     // ps.deleteNode();
                  }
               }

               toMergeStatusPool.replaceElement(overWriteStatusPool);
            }
            else
            {
               // this part of the program will probably never be executed,
               // but...
               if (parts != null)
               {
                  for (int i = 0; i < size; i++)
                     overWriteStatusPool.setStatus(parts[i], toMerge.getStatus(), null);
               }
               if (toMergeStatusPool != null)
                  toMergeStatusPool.deleteNode();
               toMerge.setStatus(JDFElement.EnumNodeStatus.Pool);
               toMerge.moveElement(overWriteStatusPool, null);
            }
         }
      }

      ///   
      ///	 <summary> * merge the RO resources of the main JDF
      ///	 *  </summary>
      ///	 * <param name="subJDFNode"> the source node of the status pool to merge into this </param>
      ///	 * <param name="previousMergeIDs"> SpawnIDs of previously merged </param>
      ///	 * <param name="vsRO"> Resource IDs of non-local spawned resources </param>
      ///	 * <param name="spawnID"> the original spawnID </param>
      ///	 
      private void cleanROResources()
      {
         IEnumerator<string> it = vsRO.GetEnumerator();
         while (it.MoveNext())
         {
            string ro = it.Current;
            JDFResource newRes = subJDFNode.getTargetResource(ro);
            JDFResource oldRes = (JDFResource)overWriteNode.getTarget(ro, AttributeName.ID);
            if (oldRes == null || newRes == null)
               continue; // snafu, lets just ignore the rest and limp along

            // merge all potential new spawnIds from subJDFNode to this
            mergeSpawnIDs(oldRes, newRes, true);
            VElement oldResLeafsSpawned = oldRes.getNodesWithSpawnID(spawnID);
            for (int leaf = 0; leaf < oldResLeafsSpawned.Count; leaf++)
            {
               JDFResource leafRes = (JDFResource)oldResLeafsSpawned[leaf];
               // handle multiple spawns (reference count of spawned audits!)
               leafRes.removeFromSpawnIDs(spawnID);
               calcSpawnStatus(leafRes, false);
            }
            if (!newRes.getParentJDF().getID().Equals(oldRes.getParentJDF().getID()))
            {
               // this has been copied from lower down up and MUST be
               // deleted...
               newRes.deleteNode();
            }
            else
            {
               // don't use a simple for because deleting a parent may
               // invalidate later resources!
               VElement newResLeafsSpawned = newRes.getNodesWithSpawnID(spawnID);
               // just in case: if no SpawnID exists assume the whole thing
               if (newResLeafsSpawned.Count == 0)
               {
                  newResLeafsSpawned.Add(newRes);
               }
               while (newResLeafsSpawned.Count > 0)
               {
                  // use the last because it is potentially the root...
                  JDFResource leafRes = (JDFResource)newResLeafsSpawned[newResLeafsSpawned.Count - 1];
                  bool bZappRoot = leafRes.Equals(newRes);
                  leafRes.deleteNode();
                  // we killed the root, nothing can be left...
                  if (bZappRoot)
                  {
                     break;
                  }
                  // regenerate the list
                  newResLeafsSpawned = newRes.getNodesWithSpawnID(spawnID);
               }
            }
         }
      }

      ///   
      ///	 <summary> * clean up the spawn and merge audits in this Node
      ///	 * <p>
      ///	 * default: CleanUpMerge(EnumCleanUpMerge cleanPolicy, JDFConstants.EMPTYSTRING, false)
      ///	 *  </summary>
      ///	 * <param name="cleanPolicy"> policy how to clean up the spawn and merge audits after merging </param>
      ///	 * <param name="spawnID"> the SpawnID of the spawn and MergeID of the merge to clean up.<br>
      ///	 *            If not specified all spawns will be cleaned up. </param>
      ///	 * <param name="bRecurse"> if true also recurse into all child JDF nodes; default=false </param>
      ///	 

      private void cleanUpMerge(JDFNode overWriteTmpNode, EnumCleanUpMerge cleanPolicy, bool bRecurse)
      {
         if (bAddMergeToProcessRun)
         {
            VElement vProcessRun = subJDFNode.getChildrenByTagName(ElementName.PROCESSRUN, null, new JDFAttributeMap(AttributeName.SPAWNID, spawnID), false, true, -1);
            JDFSpawned spawned = (JDFSpawned)overWriteTmpNode.getChildByTagName(ElementName.SPAWNED, null, 0, new JDFAttributeMap(AttributeName.NEWSPAWNID, spawnID), false, true);
            JDFMerged merged = (JDFMerged)overWriteTmpNode.getChildByTagName(ElementName.MERGED, null, 0, new JDFAttributeMap(AttributeName.MERGEID, spawnID), false, true);
            for (int k = 0; k < vProcessRun.Count; k++)
            {
               JDFProcessRun pr = (JDFProcessRun)vProcessRun[k];
               if (!pr.hasAttribute("ReturnTime"))
               {
                  if (merged != null)
                     pr.setReturnTime(merged.getTimeStampDate());
                  if (spawned != null)
                     pr.setSubmissionTime(spawned.getTimeStampDate());
               }
            }
         }
         if (!cleanPolicy.Equals(EnumCleanUpMerge.None))
         {
            if (bRecurse)
            {
               VElement v = overWriteTmpNode.getvJDFNode(null, null, false);
               for (int i = v.Count; i >= 0; i--)
               {
                  cleanUpMerge((JDFNode)v[i], cleanPolicy, false);
               }
            }
            else
            {
               JDFAuditPool auditPool = overWriteTmpNode.getAuditPool();
               if (auditPool != null)
                  cleanUpMergeAudits(auditPool, cleanPolicy);
            }
         }
      }

      ///   
      ///	 * <param name="cleanPolicy"> </param>
      ///	 * <param name="spawnID"> </param>
      ///	 
      private void cleanUpMergeAudits(JDFAuditPool pool, JDFNode.EnumCleanUpMerge cleanPolicy)
      {
         if (cleanPolicy != JDFNode.EnumCleanUpMerge.None)
         {
            VElement vMerged = new VElement();
            VElement vSpawned = new VElement();
            if (KElement.isWildCard(spawnID))
            {
               vMerged = pool.getAudits(JDFAudit.EnumAuditType.Merged, null, null);
               vSpawned = pool.getAudits(JDFAudit.EnumAuditType.Spawned, null, null);
            }
            else
            {

               JDFAttributeMap mSpawnID = new JDFAttributeMap(AttributeName.MERGEID, spawnID);
               JDFAudit a = pool.getAudit(0, JDFAudit.EnumAuditType.Merged, mSpawnID, null);
               if (a != null)
               {
                  vMerged.Add(a);
               }
               mSpawnID.Clear();
               mSpawnID.put(AttributeName.NEWSPAWNID, spawnID);
               a = pool.getAudit(0, JDFAudit.EnumAuditType.Spawned, mSpawnID, null);
               if (a != null)
               {
                  vSpawned.Add(a);
               }
            }
            for (int i = vMerged.Count - 1; i >= 0; i--)
            {
               JDFMerged merged = (JDFMerged)vMerged[i];
               string mergeID = merged.getMergeID();
               KElement doubleSpawn = pool.getChildWithAttribute(ElementName.SPAWNED, AttributeName.SPAWNID, null, mergeID, 0, true);
               if (doubleSpawn != null)
                  continue; // skip cleanup in case spawned audits rely on
               // this

               for (int j = vSpawned.Count - 1; j >= 0; j--)
               {
                  JDFSpawned spawned = (JDFSpawned)vSpawned[i];
                  if (spawned.getNewSpawnID().Equals(mergeID))
                  {

                     if (cleanPolicy == JDFNode.EnumCleanUpMerge.RemoveAll)
                     {
                        spawned.deleteNode();
                        merged.deleteNode();
                        vSpawned.RemoveAt(j);
                     }
                     else if (cleanPolicy == JDFNode.EnumCleanUpMerge.RemoveRRefs)
                     {
                        spawned.removeAttribute(AttributeName.RREFSRWCOPIED);
                        spawned.removeAttribute(AttributeName.RREFSROCOPIED);
                        merged.removeAttribute(AttributeName.RREFSOVERWRITTEN);
                     }
                     else
                     {
                        // never get here
                        throw new JDFException("JDFNode.EnumCleanUpMerge: illegal cleanPolicy enumeration: " + cleanPolicy.getValue());
                     }
                  }
               }
            }
         }
      }
   }
}
