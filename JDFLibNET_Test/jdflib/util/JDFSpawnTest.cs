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
   using System;
   using System.Collections;
   using Microsoft.VisualStudio.TestTools.UnitTesting;
   using System.IO;
   using System.Xml;

   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using EnumClass = org.cip4.jdflib.auto.JDFAutoNotification.EnumClass;
   using EnumSide = org.cip4.jdflib.auto.JDFAutoPart.EnumSide;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFAudit = org.cip4.jdflib.core.JDFAudit;
   using JDFComment = org.cip4.jdflib.core.JDFComment;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFCustomerInfo = org.cip4.jdflib.core.JDFCustomerInfo;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFNodeInfo = org.cip4.jdflib.core.JDFNodeInfo;
   using JDFParser = org.cip4.jdflib.core.JDFParser;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using XMLDoc = org.cip4.jdflib.core.XMLDoc;
   using EnumAuditType = org.cip4.jdflib.core.JDFAudit.EnumAuditType;
   using EnumSeverity = org.cip4.jdflib.core.JDFAudit.EnumSeverity;
   using EnumNodeStatus = org.cip4.jdflib.core.JDFElement.EnumNodeStatus;
   using EnumVersion = org.cip4.jdflib.core.JDFElement.EnumVersion;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using EnumValidationLevel = org.cip4.jdflib.core.KElement.EnumValidationLevel;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using JDFAncestor = org.cip4.jdflib.node.JDFAncestor;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using JDFSpawned = org.cip4.jdflib.node.JDFSpawned;
   using EnumCleanUpMerge = org.cip4.jdflib.node.JDFNode.EnumCleanUpMerge;
   using EnumProcessUsage = org.cip4.jdflib.node.JDFNode.EnumProcessUsage;
   using EnumType = org.cip4.jdflib.node.JDFNode.EnumType;
   using JDFAuditPool = org.cip4.jdflib.pool.JDFAuditPool;
   using JDFResourcePool = org.cip4.jdflib.pool.JDFResourcePool;
   using JDFBufferParams = org.cip4.jdflib.resource.JDFBufferParams;
   using JDFMerged = org.cip4.jdflib.resource.JDFMerged;
   using JDFNotification = org.cip4.jdflib.resource.JDFNotification;
   using JDFProcessRun = org.cip4.jdflib.resource.JDFProcessRun;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFResourceAudit = org.cip4.jdflib.resource.JDFResourceAudit;
   using EnumAmountMerge = org.cip4.jdflib.resource.JDFResource.EnumAmountMerge;
   using EnumPartIDKey = org.cip4.jdflib.resource.JDFResource.EnumPartIDKey;
   using EnumPartUsage = org.cip4.jdflib.resource.JDFResource.EnumPartUsage;
   using EnumResStatus = org.cip4.jdflib.resource.JDFResource.EnumResStatus;
   using EnumSpawnStatus = org.cip4.jdflib.resource.JDFResource.EnumSpawnStatus;
   using JDFApprovalSuccess = org.cip4.jdflib.resource.process.JDFApprovalSuccess;
   using JDFComponent = org.cip4.jdflib.resource.process.JDFComponent;
   using JDFContact = org.cip4.jdflib.resource.process.JDFContact;
   using JDFConventionalPrintingParams = org.cip4.jdflib.resource.process.JDFConventionalPrintingParams;
   using JDFEmployee = org.cip4.jdflib.resource.process.JDFEmployee;
   using JDFExposedMedia = org.cip4.jdflib.resource.process.JDFExposedMedia;
   using JDFLayout = org.cip4.jdflib.resource.process.JDFLayout;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;
   using JDFRunList = org.cip4.jdflib.resource.process.JDFRunList;
   using JDFFoldingParams = org.cip4.jdflib.resource.process.postpress.JDFFoldingParams;

   [TestClass]
   public class JDFSpawnTest : JDFTestCaseBase
   {

      ///   
      ///	 <summary> * Method testUnSpawn.
      ///	 *  </summary>
      ///	 * <exception cref="Exception"> </exception>
      ///	 
      private void unSpawn(string strXMLFile, string strSpawnID)
      {
         string strXMLFileModified = "_" + strXMLFile;

         JDFParser p = new JDFParser();
         JDFDoc doc = p.parseFile(sm_dirTestDataTemp + strXMLFileModified);

         // parse the original file, which is already spawned
         Assert.IsNotNull(doc, "Parse of file " + sm_dirTestDataTemp + strXMLFileModified + " failed"); // _bookintent.jdf

         JDFNode root = (JDFNode)doc.getRoot();
         Assert.IsNotNull(root);
         if (root != null)
         {
            root = new JDFSpawn(root).unSpawn(strSpawnID);
            Assert.IsTrue(root.ToString().IndexOf(strSpawnID) < 0, " root empty");
            Assert.IsNull(root.getMultipleIDs("ID"));

            // write out the unspawned file
            doc.write2File(sm_dirTestDataTemp + "Unspawn_" + strXMLFile, 0, true); // Unspawn_bookintent.jdf
         }

         // Vergleich, ob alles richtig gelaufen ist
         // compareXMLFiles (strXMLFile + "_Unspawn.jdf", strXMLFile+".jdf");
      }


      [TestMethod]
      public virtual void testCorruptPartitionedSpawn()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode root = d.getJDFRoot();
         root.setType(EnumType.ProcessGroup);
         JDFNode cp = root.addJDFNode(EnumType.ConventionalPrinting);
         JDFNode fold = root.addJDFNode(EnumType.Folding);
         JDFComponent comp = (JDFComponent)cp.addResource("Component", null, EnumUsage.Output, null, root, null, null);
         JDFAttributeMap cMap = new JDFAttributeMap();
         cMap.put(EnumPartIDKey.SignatureName, "Sig1");
         cMap.put(EnumPartIDKey.SheetName, "S1");
         cMap.put(EnumPartIDKey.Condition, "Good");
         comp.getCreatePartition(cMap, new VString("SignatureName SheetName Condition", " "));
         cMap.put(EnumPartIDKey.Condition, "Waste");
         comp.getCreatePartition(cMap, null);
         comp.setResStatus(EnumResStatus.Available, true);
         fold.linkResource(comp, EnumUsage.Input, null);

         JDFComponent compOut = (JDFComponent)fold.addResource("Component", null, EnumUsage.Output, null, root, null, null);
         compOut.addPartition(EnumPartIDKey.Condition, "Good");
         compOut.addPartition(EnumPartIDKey.Condition, "Waste");
         JDFAttributeMap map = new JDFAttributeMap();
         map.put(EnumPartIDKey.SignatureName, "Sig1");
         // map.put(EnumPartIDKey.SheetName, "Sht1");
         VJDFAttributeMap v = new VJDFAttributeMap();
         v.Add(map);
         ArrayList vRW = new ArrayList();
         vRW.Add("Output");
         vRW.Add(null);

         JDFSpawn spawn = new JDFSpawn(fold);
         JDFNode spawned = spawn.spawn(null, null, vRW, v, true, true, true, true);

         JDFComponent spCompOut = (JDFComponent)spawned.getMatchingLink("Component", EnumProcessUsage.AnyOutput, 0).getLinkRoot();
         Assert.IsTrue(spCompOut.isValid(EnumValidationLevel.Incomplete), "partition structure is zapped");
      }


      [TestMethod]
      public virtual void testSubsetPartitionedSpawn()
      {
         for (int i = 0; i < 2; i++)
         {
            for (int j = 0; j < 2; j++)
            {
               JDFDoc d = new JDFDoc("JDF");
               JDFNode root = d.getJDFRoot();
               root.setType(EnumType.ProcessGroup);
               JDFNode cp = root.addJDFNode(EnumType.ConventionalPrinting);
               JDFComponent comp = (JDFComponent)cp.addResource("Component", null, EnumUsage.Output, null, null, null, null);
               JDFAttributeMap cMap = new JDFAttributeMap();
               cMap.put(EnumPartIDKey.SignatureName, "Sig1");
               cMap.put(EnumPartIDKey.SheetName, "S1");
               comp.getCreatePartition(cMap, new VString("SignatureName SheetName", " "));
               comp.getCreatePartition(cMap, null);
               comp.setResStatus(EnumResStatus.Available, true);

               cMap.put(EnumPartIDKey.Side, "Front");
               VJDFAttributeMap v = new VJDFAttributeMap();
               v.Add(cMap);
               ArrayList vRW = new ArrayList();
               vRW.Add("Output");
               vRW.Add(null);

               JDFNodeInfo ni = cp.appendNodeInfo();
               JDFNodeInfo ni2 = (JDFNodeInfo)ni.getCreatePartition(cMap, new VString("SignatureName SheetName Side", " "));
               JDFEmployee emp = ni2.appendEmployee();
               emp.makeRootResource(null, null, true);
               Assert.IsNull(root.getResourcePool());
               if (j == 1)
               {
                  root.moveElement(cp.getResourcePool(), null);
                  Assert.IsNotNull(root.getResourcePool());
               }

               JDFSpawn spawn = new JDFSpawn(cp);
               if (i == 0)
               {
                  spawn.bFixResources = false;
               }
               JDFNode spawned = spawn.spawn(null, null, vRW, v, true, true, true, true);

               JDFComponent spCompOut = (JDFComponent)spawned.getMatchingLink("Component", EnumProcessUsage.AnyOutput, 0).getLinkRoot();
               if (i == 0)
               {
                  Assert.IsNull(spCompOut.getPartition(cMap, null), "partition structure is zapped");
               }
               else
               {
                  Assert.IsNotNull(spCompOut.getPartition(cMap, null), "partition structure is notzapped " + i + " " + j);
               }
               cMap.Remove(EnumPartIDKey.Side.ToString());
               Assert.IsNotNull(spCompOut.getPartition(cMap, null), "partition structure is zapped");

               Assert.IsNotNull(spawned.getResourcePool().getElement("Employee"), "The Employee that was referenced by a partition was correctly spawned");
            }
         }
      }


      [TestMethod]
      public virtual void testSpawnPartMulti()
      {
         JDFDoc dRoot = new JDFDoc("JDF");
         JDFNode nRoot = dRoot.getJDFRoot();
         JDFCustomerInfo ci = nRoot.appendCustomerInfo();
         ci.setCustomerProjectID("foo");

         nRoot.setType("Product", true);

         JDFDoc d = JDFTestCaseBase.creatXMDoc();
         JDFNode n = (JDFNode)nRoot.copyElement(d.getJDFRoot(), null);
         JDFExposedMedia xm = (JDFExposedMedia)n.getMatchingResource(ElementName.EXPOSEDMEDIA, EnumProcessUsage.AnyInput, null, 0);
         JDFMedia media = xm.getMedia();
         media.makeRootResource("mediaID", nRoot, true);

         JDFNode nodeImageSet = nRoot.addJDFNode("ImageSetting");
         // Java to C# Conversion - Unreachable code.
         //nodeImageSet.linkResource(xm, false ? EnumUsage.Input : EnumUsage.Output, null);
         nodeImageSet.linkResource(xm, EnumUsage.Output, null);
         ArrayList v = new ArrayList();
         v.Add(ElementName.EXPOSEDMEDIA);
         VJDFAttributeMap vMap = new VJDFAttributeMap();
         JDFAttributeMap map = new JDFAttributeMap();
         map.put("SignatureName", "Sig1");
         vMap.Add(map);
         JDFSpawn spawn = new JDFSpawn(nodeImageSet);
         JDFNode spawnedPSNodeInfo = spawn.spawnInformative(null, null, vMap, false, true, true, true);
         Assert.AreEqual("foo", spawnedPSNodeInfo.getInheritedCustomerInfo("@CustomerProjectID").getCustomerProjectID(), "cpi");

         spawn = new JDFSpawn(nodeImageSet);
         JDFNode spawnedPSNode = spawn.spawn(null, null, v, vMap, false, true, true, true);
         Assert.AreEqual("foo", spawnedPSNode.getInheritedCustomerInfo("@CustomerProjectID").getCustomerProjectID(), "cpi");
         // this one spawns the component rw
         v = new ArrayList();
         v.Add(ElementName.COMPONENT);
         JDFExposedMedia xmSpawn = (JDFExposedMedia)spawnedPSNode.getMatchingResource(ElementName.EXPOSEDMEDIA, EnumProcessUsage.AnyOutput, null, 0);
         Assert.IsNotNull(xmSpawn);
         JDFMedia mediaSpawn = xmSpawn.getMedia();
         Assert.IsNotNull(mediaSpawn, "The referenced Media gets spawned correctly");

         spawn = new JDFSpawn(n);

         JDFNode spawnedNodeAll = spawn.spawn("thisUrl", "newURL", v, null, false, true, true, true);
         string spawnID = spawnedNodeAll.getSpawnID(false);
         // merge and immediately respawn the same thing
         n = new JDFMerge(n).mergeJDF(spawnedNodeAll, null, EnumCleanUpMerge.RemoveAll, EnumAmountMerge.UpdateLink);
         Assert.IsTrue(nRoot.ToString().IndexOf(spawnID) < 0, "spawnID gone");
         spawn = new JDFSpawn(n);

         JDFNode spawnedNode = spawn.spawn("thisUrl", "newURL", v, vMap, false, true, true, true);
         spawnID = spawnedNode.getSpawnID(false);
         Assert.IsTrue(spawnedNode.hasChildElement(ElementName.ANCESTORPOOL, null), "AncestorPool");

         // merge and immediately respawn the same thing
         n = new JDFMerge(n).mergeJDF(spawnedNode, null, EnumCleanUpMerge.RemoveAll, EnumAmountMerge.UpdateLink);
         Assert.IsTrue(nRoot.ToString().IndexOf(spawnID) < 0, "spawnID gone");
         spawn = new JDFSpawn(n);

         spawnedNode = spawn.spawn("thisUrl", "newURL", v, vMap, false, true, true, true);
         Assert.IsTrue(spawnedNode.hasChildElement(ElementName.ANCESTORPOOL, null), "AncestorPool after merge");

         map.put("SheetName", "S1");
         spawn = new JDFSpawn(spawnedNode);
         JDFNode respawnedNode = spawn.spawn("reUrl", "renewURL", v, vMap, false, true, true, true);
         Assert.IsTrue(spawnedNode.hasChildElement(ElementName.ANCESTORPOOL, null), "AncestorPool after respawn");

         xm = (JDFExposedMedia)respawnedNode.getMatchingResource(ElementName.EXPOSEDMEDIA, EnumProcessUsage.AnyInput, null, 0);
         JDFComponent comp = (JDFComponent)respawnedNode.getMatchingResource(ElementName.COMPONENT, EnumProcessUsage.AnyOutput, null, 0);
         VString vSpID = xm.getSpawnIDs(false);
         Assert.IsFalse(vSpID.IsEmpty(), "SpawnIDS");
         xm = (JDFExposedMedia)xm.getPartition(map, null);
         Assert.IsTrue(xm.getLocked(), "xm rw");
         comp = (JDFComponent)comp.getPartition(map, null);
         Assert.IsFalse(comp.getLocked(), "comp rw");

         map.put("SheetName", "S2");
         spawn = new JDFSpawn(spawnedNode);
         JDFNode respawnedNode2 = spawn.spawn("reUrl", "renewURL", v, vMap, false, true, true, true);
         xm = (JDFExposedMedia)respawnedNode2.getMatchingResource(ElementName.EXPOSEDMEDIA, EnumProcessUsage.AnyInput, null, 0);
         comp = (JDFComponent)respawnedNode2.getMatchingResource(ElementName.COMPONENT, EnumProcessUsage.AnyOutput, null, 0);
         vSpID = xm.getSpawnIDs(false);
         Assert.IsFalse(vSpID.IsEmpty(), "SpawnIDS");
         xm = (JDFExposedMedia)xm.getPartition(map, null);
         Assert.IsTrue(xm.getLocked(), "xm rw");
         comp = (JDFComponent)comp.getPartition(map, null);
         Assert.IsFalse(comp.getLocked(), "comp rw");
         string spawnID1 = spawnedNode.getSpawnID(false);
         JDFNode testSpawnedNode = new JDFMerge(spawnedNode).mergeJDF(respawnedNode2, null, EnumCleanUpMerge.None, EnumAmountMerge.UpdateLink);
         Assert.IsTrue(spawnedNode.hasChildElement(ElementName.ANCESTORPOOL, null), "AncestorPool after respawn merge");
         Assert.AreEqual(spawnID1, testSpawnedNode.getSpawnID(false), "spawnID ok");
         spawn = new JDFSpawn(spawnedNode);
         respawnedNode2 = spawn.spawn("reUrl", "renewURL", v, vMap, false, true, true, true);

         // now go backwards!
         spawnedNode.getOwnerDocument_JDFElement().write2File(sm_dirTestDataTemp + "multiSpawn_s1.jdf", 2, false);
         new JDFMerge(nRoot).mergeJDF(spawnedNode, null, EnumCleanUpMerge.None, EnumAmountMerge.UpdateLink);
         nRoot.getOwnerDocument_JDFElement().write2File(sm_dirTestDataTemp + "multiSpawn_m1.jdf", 2, false);
         respawnedNode.getOwnerDocument_JDFElement().write2File(sm_dirTestDataTemp + "multiSpawn_s2.jdf", 2, false);
         new JDFMerge(nRoot).mergeJDF(respawnedNode, null, EnumCleanUpMerge.None, EnumAmountMerge.UpdateLink);
         nRoot.getOwnerDocument_JDFElement().write2File(sm_dirTestDataTemp + "multiSpawn_m2.jdf", 2, false);
         respawnedNode2.getOwnerDocument_JDFElement().write2File(sm_dirTestDataTemp + "multiSpawn_s3.jdf", 2, false);
         new JDFMerge(nRoot).mergeJDF(respawnedNode2, null, EnumCleanUpMerge.None, EnumAmountMerge.UpdateLink);
         nRoot.getOwnerDocument_JDFElement().write2File(sm_dirTestDataTemp + "multiSpawn_m3.jdf", 2, false);

         new JDFMerge(nRoot).mergeJDF(spawnedPSNode, null, EnumCleanUpMerge.None, EnumAmountMerge.UpdateLink);
         Assert.IsTrue(nRoot.ToString().IndexOf("SpawnIDs") < 0, "spawnIDs gone");
         nRoot.getOwnerDocument_JDFElement().write2File(sm_dirTestDataTemp + "multiSpawn.jdf", 2, false);
         Assert.IsTrue(nRoot.isValid(EnumValidationLevel.Incomplete));

      }


      [TestMethod]
      public virtual void testSpawnPartChain()
      {
         for (int i = 0; i < 3; i++)
         {
            JDFDoc dRoot = new JDFDoc("JDF");
            JDFNode nRoot = dRoot.getJDFRoot();
            JDFCustomerInfo ci = nRoot.appendCustomerInfo();
            ci.setCustomerProjectID("foo");

            nRoot.setType("Product", true);

            JDFDoc d = JDFTestCaseBase.creatXMDoc();
            JDFNode n = (JDFNode)nRoot.copyElement(d.getJDFRoot(), null);
            JDFExposedMedia xm = (JDFExposedMedia)n.getMatchingResource(ElementName.EXPOSEDMEDIA, EnumProcessUsage.AnyInput, null, 0);
            JDFMedia media = xm.getMedia();
            media.makeRootResource("mediaID", nRoot, true);
            JDFResourcePool rp = nRoot.getCreateResourcePool();
            rp.moveElement(xm, null);
            rp.moveElement(n.getMatchingResource(ElementName.COMPONENT, EnumProcessUsage.AnyOutput, null, 0), null);

            VJDFAttributeMap vMap = new VJDFAttributeMap();
            JDFAttributeMap map = new JDFAttributeMap();
            map.put("SignatureName", "Sig1");
            vMap.Add(map);
            ArrayList v = new ArrayList();
            v.Add(ElementName.COMPONENT);
            JDFSpawn spawn = new JDFSpawn(n);

            JDFNode spawnedNode = spawn.spawn("thisUrl", "newURL", v, vMap, false, true, true, true);
            nRoot.getOwnerDocument_JDFElement().write2File(sm_dirTestDataTemp + "chainSpawn_main0.jdf", 2, false);
            JDFComponent coSig = (JDFComponent)spawnedNode.getResource(ElementName.COMPONENT, EnumUsage.Output, 0);
            coSig = (JDFComponent)coSig.getPartition(map, null);
            Assert.IsNotNull(coSig);
            JDFNodeInfo niSig = (JDFNodeInfo)spawnedNode.getResource(ElementName.NODEINFO, EnumUsage.Input, 0);
            niSig = (JDFNodeInfo)niSig.getPartition(map, null);
            Assert.IsNotNull(niSig);
            JDFExposedMedia xmSig = (JDFExposedMedia)spawnedNode.getResource(ElementName.EXPOSEDMEDIA, EnumUsage.Input, 0);
            xmSig = (JDFExposedMedia)xmSig.getPartition(map, null);
            Assert.IsNotNull(xmSig);
            for (int j = 3; j < 9; j++)
            {
               coSig.addPartition(EnumPartIDKey.SheetName, "S" + j);
               niSig.addPartition(EnumPartIDKey.SheetName, "S" + j);
               xmSig.addPartition(EnumPartIDKey.SheetName, "S" + j);
            }
            // String spawnID=
            spawnedNode.getSpawnID(false);
            Assert.IsTrue(spawnedNode.hasChildElement(ElementName.ANCESTORPOOL, null), "AncestorPool");

            map.put("SheetName", "S1");
            for (int j = 2; j < 9; j++)
            {
               JDFAttributeMap map2 = new JDFAttributeMap(map);
               map2.put("SheetName", "S" + j);
               vMap.Add(map2);
            }

            JDFNode respawnedNode = spawnedNode;
            JDFNode[] nodes = new JDFNode[9];
            nodes[0] = spawnedNode;
            for (int j = 1; j < 9; j++)
            {
               Console.WriteLine("Spawn" + j);
               spawn = new JDFSpawn(respawnedNode);
               nodes[j] = respawnedNode = spawn.spawn("reUrl1" + j, "renewURL1" + j, v, vMap, false, true, true, true);
               Assert.IsTrue(respawnedNode.hasChildElement(ElementName.ANCESTORPOOL, null), "AncestorPool after respawn");
               Assert.AreEqual(respawnedNode.getAncestorPool().getPartMapVector(), vMap, "AncestorPool after respawn");

               xm = (JDFExposedMedia)respawnedNode.getMatchingResource(ElementName.EXPOSEDMEDIA, EnumProcessUsage.AnyInput, null, 0);
               JDFComponent comp = (JDFComponent)respawnedNode.getMatchingResource(ElementName.COMPONENT, EnumProcessUsage.AnyOutput, null, 0);
               map = vMap[0];
               VString vSpID = xm.getSpawnIDs(false);
               Assert.IsFalse(vSpID.IsEmpty(), "SpawnIDS");
               xm = (JDFExposedMedia)xm.getPartition(map, null);
               Assert.IsTrue(xm.getLocked(), "xm rw");
               comp = (JDFComponent)comp.getCreatePartition(map, null);
               comp.setResStatus(EnumResStatus.Available, false);
               Assert.IsFalse(comp.getLocked(), "comp rw");
               vMap.RemoveAt(0);
               respawnedNode.getOwnerDocument_JDFElement().write2File(sm_dirTestDataTemp + "chainSpawn_s" + j + ".jdf", 2, false);
               if (j > 1)
                  nodes[j - 1].getOwnerDocument_JDFElement().write2File(sm_dirTestDataTemp + "chainSpawn_ms" + j + ".jdf", 2, false);
            }
            for (int j = 0; j < 9; j++)
            {

               Console.WriteLine("Merge" + j);
               JDFNode nodeJ = nodes[j];
               EnumCleanUpMerge enumCleanUpMerge = EnumCleanUpMerge.getEnum(i);
               // JDFNode overwritten=
               new JDFMerge(nRoot).mergeJDF(nodeJ, null, enumCleanUpMerge, EnumAmountMerge.UpdateLink);

               Assert.AreEqual(1, nRoot.getChildrenByTagName(null, null, new JDFAttributeMap(AttributeName.ID, xm.getID()), false, true, 99, false).Count);
               Assert.IsTrue(nRoot.isValid(EnumValidationLevel.Incomplete));
               nRoot.getOwnerDocument_JDFElement().write2File(sm_dirTestDataTemp + "chainSpawn_m" + j + ".jdf", 2, false);

            }

            Assert.IsTrue(nRoot.ToString().IndexOf("SpawnIDs") < 0, "spawnIDs gone");
         }
      }

      ///   
      ///	 <summary> * test wierd sequences of spawning and merging with the same res being
      ///	 * spawned both rw and ro
      ///	 *  </summary>
      ///	 
      [TestMethod]
      public virtual void testSpawnPartMultiRORW()
      {
         for (int i = 0; i < 2; i++) // partitioned or not
         {
            VJDFAttributeMap vMap = new VJDFAttributeMap();
            JDFAttributeMap map = new JDFAttributeMap();
            map.put("SignatureName", "Sig1");
            vMap.Add(map);
            if (i == 1)
            {
               vMap = null; // unpartitioned
            }
            for (int j = 0; j < 4; j++) // rw or ro first
            {
               for (int k = 0; k < 2; k++) // copy local or copy from high
               // level
               {
                  for (int kk = 0; kk < 2; kk++) // reslinks have part map
                  {
                     JDFDoc dRoot = new JDFDoc("JDF");
                     JDFNode nRoot = dRoot.getJDFRoot();

                     nRoot.setType("Product", true);

                     JDFDoc d = JDFTestCaseBase.creatXMDoc();
                     JDFNode n = (JDFNode)nRoot.copyElement(d.getJDFRoot(), null);
                     if (k > 0)
                     {
                        nRoot.moveElement(n.getResourcePool(), null);
                     }

                     JDFExposedMedia xm = (JDFExposedMedia)n.getMatchingResource(ElementName.EXPOSEDMEDIA, EnumProcessUsage.AnyInput, null, 0);
                     JDFExposedMedia xmPart = (JDFExposedMedia)xm.getPartition(map, null);
                     JDFMedia media = xm.getMedia();
                     media.makeRootResource("mediaID", n, true);
                     JDFResourceLink rlXM = n.getLink(xm, null);
                     if (kk > 0)
                     {
                        VJDFAttributeMap vMap2 = new VJDFAttributeMap();
                        JDFAttributeMap mapBad = new JDFAttributeMap("SignatureName", "Sig2");
                        vMap2.Add(mapBad);
                        vMap2.Add(map);
                        rlXM.setPartMapVector(vMap2);
                     }

                     ArrayList vRWRes = new ArrayList();
                     if (j < 2)
                     {
                        vRWRes.Add(ElementName.EXPOSEDMEDIA);
                     }

                     JDFSpawn spawn = new JDFSpawn(n);
                     JDFNode spawnedNodeXMRW = spawn.spawn(null, null, vRWRes, vMap, false, true, true, true);

                     // this one spawns the component rw
                     vRWRes.Clear();
                     JDFExposedMedia xmSpawn = (JDFExposedMedia)spawnedNodeXMRW.getMatchingResource(ElementName.EXPOSEDMEDIA, EnumProcessUsage.AnyInput, null, 0);
                     Assert.IsNotNull(xmSpawn);
                     Assert.AreEqual(xmPart.getSpawnStatus(), j < 2 ? EnumSpawnStatus.SpawnedRW : EnumSpawnStatus.SpawnedRO);
                     if (j >= 2)
                     {
                        vRWRes.Add(ElementName.EXPOSEDMEDIA);
                     }

                     spawn = new JDFSpawn(n);

                     JDFNode spawnedNodeXMRO = spawn.spawn("thisUrl", "newURL", vRWRes, vMap, false, true, true, true);
                     // merge and immediately respawn the same thing
                     JDFNode s1 = j % 2 == 0 ? spawnedNodeXMRO : spawnedNodeXMRW;
                     string spawnIDRO = s1.getSpawnID(false);
                     JDFNode s2 = j % 2 == 1 ? spawnedNodeXMRO : spawnedNodeXMRW;
                     string spawnIDRW = s2.getSpawnID(false);
                     // n=new JDFMerge(nRoot).mergeJDF(s1, null,
                     // EnumCleanUpMerge.None, EnumAmountMerge.UpdateLink);
                     n = new JDFMerge(nRoot).mergeJDF(s1, null, EnumCleanUpMerge.RemoveAll, EnumAmountMerge.UpdateLink);
                     Assert.IsTrue(nRoot.ToString().IndexOf(spawnIDRO) < 0, "spawnID RO gone");
                     Assert.IsTrue(nRoot.ToString().IndexOf(spawnIDRW) >= 0, "spawnID RW not gone");
                     xm = (JDFExposedMedia)n.getMatchingResource(ElementName.EXPOSEDMEDIA, EnumProcessUsage.AnyInput, null, 0);
                     xmPart = (JDFExposedMedia)xm.getPartition(map, null);
                     Assert.AreEqual(j == 0 || j == 3 ? EnumSpawnStatus.SpawnedRW : EnumSpawnStatus.SpawnedRO, xmPart.getSpawnStatus(), i + " " + j);

                     // merge and immediately respawn the same thing
                     n = new JDFMerge(nRoot).mergeJDF(s2, null, EnumCleanUpMerge.RemoveAll, EnumAmountMerge.UpdateLink);
                     // n=new JDFMerge(nRoot).mergeJDF(s2, null,
                     // EnumCleanUpMerge.None, EnumAmountMerge.UpdateLink);
                     Assert.IsTrue(nRoot.ToString().IndexOf(spawnIDRW) < 0, "spawnID gone " + i + " " + j + " " + k + " " + kk);
                     Assert.IsTrue(nRoot.ToString().IndexOf("SpawnIDs") < 0, "spawnIDs gone " + i + " " + j + " " + k + " " + kk);
                     xm = (JDFExposedMedia)n.getMatchingResource(ElementName.EXPOSEDMEDIA, EnumProcessUsage.AnyInput, null, 0);
                     xmPart = (JDFExposedMedia)xm.getPartition(map, null);
                     Assert.AreEqual(EnumSpawnStatus.NotSpawned, xmPart.getSpawnStatus());
                  }
               }
            }
         }
      }

      ///   
      ///	 <summary> * test whether getpartition works for when inconsistently called </summary>
      ///	 
      [TestMethod]
      public virtual void testSpawnInconsistentPart()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode n = doc.getJDFRoot();
         n.setType(EnumType.Folding);
         JDFFoldingParams fp = (JDFFoldingParams)n.addResource(ElementName.FOLDINGPARAMS, null, EnumUsage.Input, null, null, null, null);
         JDFAttributeMap m = new JDFAttributeMap("SignatureName", "Sig1");
         JDFNodeInfo ni = (JDFNodeInfo)n.addResource(ElementName.NODEINFO, null, EnumUsage.Input, null, null, null, null);
         m.put("SheetName", "Sheet1");
         JDFResource rSheet = fp.getCreatePartition(m, new VString("SignatureName SheetName", " "));
         JDFResourceLink rl = n.getLink(fp, null);
         rl.setPartMap(m);
         m.put("BlockName", "Block1");
         JDFResource r = fp.getCreatePartition(m, new VString("SignatureName SheetName BlockName", " "));
         m.put("BlockName", "Block2");
         r = fp.getCreatePartition(m, new VString("SignatureName SheetName BlockName", " "));
         JDFAttributeMap m2 = new JDFAttributeMap("SignatureName", "Sig1");
         m2.put("SheetName", "Sheet1");
         m2.put("Side", "Front");
         ni.getCreatePartition(m2, new VString("SignatureName SheetName Side", " "));
         r = fp.getPartition(m2, EnumPartUsage.Implicit);
         Assert.AreEqual(r, rSheet);
         r = fp.getPartition(m2, EnumPartUsage.Explicit);
         Assert.IsNull(r);
         JDFSpawn spawn = new JDFSpawn(n); // fudge to test output counting
         VJDFAttributeMap vMap = new VJDFAttributeMap();
         vMap.Add(m2);
         spawn.spawn("thisUrl", "newURL", null, vMap, true, true, true, true);
      }

      ///   
      ///	 <summary> * test whether getpartition works for when inconsistently called </summary>
      ///	 
      [TestMethod]
      public virtual void testSpawnNoPart()
      {
         for (int i = 0; i < 2; i++)
         {
            JDFDoc doc = new JDFDoc("JDF");
            JDFNode n = doc.getJDFRoot();
            n.setType(EnumType.ProcessGroup);
            //if (i == i)
               n = n.addJDFNode(EnumType.ProcessGroup);
            JDFNode n2 = n.addJDFNode(EnumType.ImageSetting);
            JDFResource xm = n2.addResource("ExposedMedia", EnumUsage.Input);
            JDFResource m = n.addResource("Media", null);
            xm.refElement(m);
            JDFSpawn spawn = new JDFSpawn(i == 1 ? n : n2);
            JDFNode si = spawn.spawn();
            Assert.IsNotNull(si.getResourcePool().getElement("Media"));
         }

      }


      [TestMethod]
      public virtual void testSpawnMixPart()
      {
         for (int i = 0; i < 2; i++)
         {
            JDFDoc doc = new JDFDoc("JDF");
            JDFNode root = doc.getJDFRoot();
            root.setType(EnumType.Imposition);
            JDFRunList rl = (JDFRunList)root.addResource(ElementName.RUNLIST, null, EnumUsage.Input, null, null, null, null);
            JDFRunList rlEn = (JDFRunList)rl.addPartition(EnumPartIDKey.PartVersion, "EN");
            rlEn.addPDF("En.pdf", 0, -1);
            JDFRunList rlDe = (JDFRunList)rl.addPartition(EnumPartIDKey.PartVersion, "DE");
            rlDe.addPDF("De.pdf", 0, -1);

            JDFRunList rlOut = (JDFRunList)root.addResource(ElementName.RUNLIST, null, EnumUsage.Output, null, null, null, null);
            for (int j = 0; j < 4; j++)
            {
               JDFRunList rlS1 = (JDFRunList)rlOut.addPartition(EnumPartIDKey.SheetName, "S" + j);
               JDFRunList rlS1F = (JDFRunList)rlS1.addPartition(EnumPartIDKey.Side, "Front");
               rlS1F.addPartition(EnumPartIDKey.PartVersion, "EN");
               rlS1F.addPartition(EnumPartIDKey.PartVersion, "DE");

               rlS1.addPartition(EnumPartIDKey.Side, "Back");
            }

            JDFSpawn spawn = new JDFSpawn(root);
            spawn.vSpawnParts = new VJDFAttributeMap();
            spawn.vSpawnParts.Add(new JDFAttributeMap(EnumPartIDKey.PartVersion, "EN"));
            spawn.vRWResources_in = new VString("Output", null);
            spawn.bFixResources = i == 0;

            JDFNode spawnedNode = spawn.spawn();

            Assert.IsNotNull(spawnedNode);

            JDFRunList rlOutSpawn = (JDFRunList)spawnedNode.getMatchingResource(ElementName.RUNLIST, EnumProcessUsage.AnyOutput, null, 0);
            VElement vOut = rlOutSpawn.getPartitionVector(new JDFAttributeMap(EnumPartIDKey.PartVersion, "DE"), null);
            Assert.AreEqual(0, vOut.Count);
            vOut = rlOutSpawn.getPartitionVector(new JDFAttributeMap(EnumPartIDKey.PartVersion, "EN"), null);
            Assert.AreEqual(4, vOut.Count);
            for (int j = 0; j < vOut.Count; j++)
            {
               ((JDFResource)vOut.item(j)).setResStatus(EnumResStatus.Available, false);
            }

            JDFMerge merge = new JDFMerge(root);
            root = merge.mergeJDF(spawnedNode, null, EnumCleanUpMerge.None, EnumAmountMerge.UpdateLink);
            Assert.IsNotNull(root);
            JDFRunList rlOutMerge = (JDFRunList)root.getMatchingResource(ElementName.RUNLIST, EnumProcessUsage.AnyOutput, null, 0);
            vOut = rlOutMerge.getPartitionVector(new JDFAttributeMap(EnumPartIDKey.PartVersion, "DE"), null);
            Assert.AreEqual(vOut.Count, 4);

            vOut = rlOutMerge.getPartitionVector(new JDFAttributeMap(EnumPartIDKey.PartVersion, "EN"), null);
            Assert.AreEqual(4, vOut.Count);
            for (int j = 0; j < vOut.Count; j++)
            {
               Assert.AreEqual(EnumResStatus.Available, ((JDFResource)vOut.item(j)).getResStatus(false), "bad status: " + j);
            }
            vOut = rlOutMerge.getPartitionVector(new JDFAttributeMap(EnumPartIDKey.PartVersion, "DE"), null);
            Assert.AreEqual(vOut.Count, 4);
            for (int j = 0; j < vOut.Count; j++)
            {
               Assert.AreEqual(EnumResStatus.Unavailable, ((JDFResource)vOut.item(j)).getResStatus(false));
            }
         }
      }


      [TestMethod]
      public virtual void testSpawnPartNoSide()
      {
         for (int l = 0; l < 2; l++)
         {
            JDFDoc d = new JDFDoc("JDF");
            JDFNode n = d.getJDFRoot();
            n.setType(EnumType.ProcessGroup);
            JDFNode n2 = n.addJDFNode(EnumType.ConventionalPrinting);
            JDFLayout lo = (JDFLayout)n2.addResource("Layout", null, EnumUsage.Input, null, n, null, null);
            JDFConventionalPrintingParams cpp = (JDFConventionalPrintingParams)n2.addResource(ElementName.CONVENTIONALPRINTINGPARAMS, null, EnumUsage.Input, null, n, null, null);
            JDFComponent comp = (JDFComponent)n2.addResource(ElementName.COMPONENT, null, EnumUsage.Output, null, n, null, null);
            JDFNodeInfo ni = (JDFNodeInfo)n2.addResource(ElementName.NODEINFO, null, EnumUsage.Input, null, null, null, null);

            lo = (JDFLayout)lo.addPartition(EnumPartIDKey.SignatureName, "sig1");
            cpp = (JDFConventionalPrintingParams)cpp.addPartition(EnumPartIDKey.SignatureName, "sig1");
            comp = (JDFComponent)comp.addPartition(EnumPartIDKey.SignatureName, "sig1");
            ni = (JDFNodeInfo)ni.addPartition(EnumPartIDKey.SignatureName, "sig1");
            for (int i = 0; i < 2; i++)
            {
               JDFLayout lo2 = (JDFLayout)lo.addPartition(EnumPartIDKey.SheetName, "sh" + i);
               cpp.addPartition(EnumPartIDKey.SheetName, "sh" + i);
               comp.addPartition(EnumPartIDKey.SheetName, "sh" + i);
               lo2.addPartition(EnumPartIDKey.Side, EnumSide.Front);
               lo2.addPartition(EnumPartIDKey.Side, EnumSide.Back);
               JDFNodeInfo ni2 = l == 0 ? (JDFNodeInfo)ni.addPartition(EnumPartIDKey.SheetName, "sh" + i) : ni;
               if (l == 0 || i == 0)
               {
                  ni2.addPartition(EnumPartIDKey.Side, EnumSide.Front);
                  ni2.addPartition(EnumPartIDKey.Side, EnumSide.Back);
               }

            }
            JDFAttributeMap map = new JDFAttributeMap();
            map.put(EnumPartIDKey.SignatureName, "sig1");
            if (l == 0)
            {
               map.put(EnumPartIDKey.SheetName, "sh1");
            }
            map.put(EnumPartIDKey.Side, EnumSide.Front);
            VJDFAttributeMap vMap = new VJDFAttributeMap();
            vMap.Add(map);

            JDFSpawn spawn = new JDFSpawn(n2);
            spawn.bFixResources = false;
            spawn.vRWResources_in = new VString("Output", null);
            spawn.vSpawnParts = vMap;
            spawn.bSpawnRWPartsMultiple = true;

            JDFNode nS1 = spawn.spawn();
            Assert.IsNotNull(nS1);
            nS1.setXPathAttribute("./ResourcePool/Component/Component/Component[@SheetName=\"sh1\"]/@foo", "fnarf");
            map.put(EnumPartIDKey.Side, EnumSide.Back);
            JDFNode nS2 = spawn.spawn();
            Assert.IsNotNull(nS2);

            nS2.setXPathAttribute("./ResourcePool/Component/Component/Component[@SheetName=\"sh1\"]/@foo", "bar");

            JDFMerge merge = new JDFMerge(n);
            merge.mergeJDF(nS1, null, EnumCleanUpMerge.None, EnumAmountMerge.None);
            Assert.AreEqual("fnarf", n.getXPathAttribute("./ResourcePool/Component/Component/Component[@SheetName=\"sh1\"]/@foo", null));
            merge.mergeJDF(nS2, null, EnumCleanUpMerge.None, EnumAmountMerge.None);
            Assert.AreEqual("bar", n.getXPathAttribute("./ResourcePool/Component/Component/Component[@SheetName=\"sh1\"]/@foo", null));
         }
      }


      [TestMethod]
      public virtual void testSpawnPart2Side()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setType(EnumType.ProcessGroup);
         JDFNode n2 = n.addJDFNode(EnumType.ConventionalPrinting);
         JDFComponent comp = (JDFComponent)n2.addResource(ElementName.COMPONENT, null, EnumUsage.Output, null, n, null, null);
         JDFNodeInfo ni = n2.getCreateNodeInfo();
         comp = (JDFComponent)comp.addPartition(EnumPartIDKey.SignatureName, "sig1");
         ni = (JDFNodeInfo)ni.addPartition(EnumPartIDKey.SignatureName, "sig1");
         for (int i = 0; i < 2; i++)
         {
            JDFComponent c2 = (JDFComponent)comp.addPartition(EnumPartIDKey.SheetName, "sh" + i);
            c2.addPartition(EnumPartIDKey.Condition, "Good");
            c2.addPartition(EnumPartIDKey.Condition, "Waste");
            JDFNodeInfo ni2 = (JDFNodeInfo)ni.addPartition(EnumPartIDKey.SheetName, "sh" + i);
            ni2.addPartition(EnumPartIDKey.Side, "Front");
            ni2.addPartition(EnumPartIDKey.Side, "Back");
         }
         JDFAttributeMap map = new JDFAttributeMap();
         map.put(EnumPartIDKey.SignatureName, "sig1");
         map.put(EnumPartIDKey.SheetName, "sh1");
         map.put(EnumPartIDKey.Side, EnumSide.Front);
         VJDFAttributeMap vMap = new VJDFAttributeMap();
         vMap.Add(map);
         map = new JDFAttributeMap(map);
         map.put(EnumPartIDKey.Side, EnumSide.Back);
         vMap.Add(map);

         JDFSpawn spawn = new JDFSpawn(n2);
         spawn.bFixResources = false;
         spawn.vRWResources_in = new VString("Output", null);
         spawn.vSpawnParts = vMap;

         JDFNode nS1 = spawn.spawn();
         Assert.IsNotNull(nS1);
         nS1.setXPathAttribute("./ResourcePool/Component/Component/Component[@SheetName=\"sh1\"]/@foo", "fnarf");

         JDFMerge merge = new JDFMerge(n);
         merge.mergeJDF(nS1, null, EnumCleanUpMerge.None, EnumAmountMerge.None);
         Assert.AreEqual(null, n.getXPathAttribute("./ResourcePool/Component/Component/Component[@SheetName=\"sh1\"]/@foo", null), "only the sides are apawned, not the sheet proper");
      }


      [TestMethod]
      public virtual void testSpawnParallel()
      {
         JDFNode[] aSpawned = new JDFNode[3];
         JDFDoc d = JDFTestCaseBase.creatXMDoc();
         JDFNode n = d.getJDFRoot();
         for (int i = 0; i < 3; i++)
         {
            VJDFAttributeMap vPartMap = new VJDFAttributeMap();
            JDFAttributeMap map = new JDFAttributeMap();
            map.put("SignatureName", "Sig1");
            map.put("SheetName", "S" + i);
            vPartMap.Add(map);

            JDFSpawn spawn = new JDFSpawn(n); // fudge to test output
            // counting}
            spawn.vSpawnParts = vPartMap;
            aSpawned[i] = spawn.spawn();
         }
         for (int i = 0; i < 3; i++)
         {
            JDFElement.uniqueID(100);
            JDFAuditPool ap = aSpawned[i].getCreateAuditPool();
            for (int j = 0; j < 5; j++)
            {
               ap.addNotification(EnumClass.Error, null, null);
            }
            ap.addProcessRun(EnumNodeStatus.Completed, "me", aSpawned[i].getPartMapVector());
         }
         JDFElement.uniqueID(300);
         for (int i = 0; i < 3; i++)
         {
            JDFMerge merge = new JDFMerge(n);
            merge.bAddMergeToProcessRun = true;

            // merge here
            JDFNode mergedNode = merge.mergeJDF(aSpawned[i], "merged", JDFNode.EnumCleanUpMerge.None, EnumAmountMerge.UpdateLink);

            VJDFAttributeMap partMapVector = aSpawned[i].getPartMapVector();
            JDFProcessRun pr = (JDFProcessRun)mergedNode.getAuditPool().getAudit(0, EnumAuditType.ProcessRun, null, partMapVector);
            JDFSpawned sp = (JDFSpawned)mergedNode.getAuditPool().getAudit(0, EnumAuditType.Spawned, null, partMapVector);
            JDFMerged me = (JDFMerged)mergedNode.getAuditPool().getAudit(0, EnumAuditType.Merged, null, partMapVector);
            Assert.IsNotNull(pr, "loop " + i);
            Assert.AreEqual(sp.getTimeStampDate(), pr.getSubmissionTime());
            Assert.AreEqual(me.getTimeStampDate(), pr.getReturnTime());

            Assert.IsNull(mergedNode.getMultipleIDs("ID"));
         }
      }


      [TestMethod]
      public virtual void testSpawnPartAmount()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setType(EnumType.ConventionalPrinting);
         JDFComponent c = (JDFComponent)n.addResource(ElementName.COMPONENT, EnumUsage.Output);
         JDFResourceLink rl = n.getLink(c, null);
         rl.setAttribute("foo:bar", "abc", "www.foo.com");
         JDFAttributeMap mapSheet = new JDFAttributeMap(EnumPartIDKey.SheetName, "s1");
         JDFAttributeMap mapGood = new JDFAttributeMap("Condition", "Good");
         JDFAttributeMap mapWaste = new JDFAttributeMap("Condition", "Waste");
         mapGood.put(EnumPartIDKey.SheetName, "s1");
         mapWaste.put(EnumPartIDKey.SheetName, "s1");
         rl.setAmount(40, mapGood);
         rl.setAmount(11, mapWaste);
         JDFSpawn spawn = new JDFSpawn(n);
         spawn.vSpawnParts = new VJDFAttributeMap();
         spawn.vSpawnParts.Add(new JDFAttributeMap(EnumPartIDKey.SheetName, "s1"));
         spawn.vRWResources_in = new VString("Output", null);
         JDFNode nSpawn = spawn.spawn();

         JDFResourceLink rl2 = (JDFResourceLink)nSpawn.getChildByTagName("ComponentLink", null, 0, null, false, false);
         Assert.IsNotNull(rl2);
         rl2.setActualAmount(44, mapGood);
         JDFAttributeMap mapgf = new JDFAttributeMap(mapGood);
         mapgf.put("Side", "Front");
         rl2.setActualAmount(22, mapgf);
         JDFMerge m = new JDFMerge(n);
         n = m.mergeJDF(nSpawn, null, EnumCleanUpMerge.None, EnumAmountMerge.LinkOnly);
         JDFResourceLink rlmerge = (JDFResourceLink)nSpawn.getChildByTagName("ComponentLink", null, 0, null, false, false);
         Assert.IsTrue(rlmerge.hasAttribute("foo:bar"));
         Assert.AreEqual(22.0, rlmerge.getActualAmount(mapgf), 0.0);
         Assert.AreEqual(44.0 + 22.0, rlmerge.getActualAmount(mapGood), "the actualamount was spawned ro", 0.0);
         JDFComponent comp = (JDFComponent)rlmerge.getTarget().getPartition(mapSheet, null);
         Assert.AreEqual(66.0, comp.getAmount(), 0.0);
         Assert.AreEqual(66.0, comp.getAmountProduced(), 0.0);
      }


      [TestMethod]
      public virtual void testSpawnIdentical()
      {
         for (int i = 0; i < 2; i++)
         {
            JDFNode n = new JDFDoc("JDF").getJDFRoot();
            n.setType(EnumType.ImageSetting);

            for (int j = 0; j < 2; j++)
            {
               JDFResource r = j == 0 ? n.addResource("ExposedMedia", EnumUsage.Output) : n.addResource("Media", EnumUsage.Input);
               if (i == 1)
                  r = r.addPartition(EnumPartIDKey.SheetName, "s1");
               JDFResource rEN = r.addPartition(EnumPartIDKey.PartVersion, "EN");
               JDFResource rDE = r.addPartition(EnumPartIDKey.PartVersion, "DE");
               r.addPartition(EnumPartIDKey.PartVersion, "FR");
               rEN.setIdentical(rDE);
            }
            ArrayList vRWRes = new ArrayList();
            vRWRes.Add(ElementName.EXPOSEDMEDIA);
            VJDFAttributeMap vPartMap = new VJDFAttributeMap();
            JDFAttributeMap map = new JDFAttributeMap();
            map.put("PartVersion", "EN");
            vPartMap.Add(map);
            JDFSpawn spawn = new JDFSpawn(n); // fudge to test output
            // counting

            JDFNode spawnedNode = spawn.spawn("thisUrl", "newURL", vRWRes, vPartMap, true, true, true, true);
            for (int j = 0; j < 2; j++)
            {
               JDFResource rS = spawnedNode.getResource((j == 0 ? "Exposed" : "") + ElementName.MEDIA, null, 0);
               JDFResource rs2 = rS.getPartition(map, null);
               Assert.IsNotNull(rs2);
               Assert.IsNull(rS.getPartition(new JDFAttributeMap(EnumPartIDKey.PartVersion, "FR"), null));
            }

            JDFMerge merge = new JDFMerge(n);
            merge.bAddMergeToProcessRun = true;

            // merge here
            JDFNode mergedNode = merge.mergeJDF(spawnedNode, "merged", JDFNode.EnumCleanUpMerge.None, EnumAmountMerge.UpdateLink);
            for (int j = 0; j < 2; j++)
            {
               JDFResource rMerge = mergedNode.getResource((j == 0 ? "Exposed" : "") + ElementName.MEDIA, null, 0);
               Assert.AreEqual(-1, rMerge.ToString().IndexOf("Spawn"));
            }
         }
      }


      [TestMethod]
      public virtual void testSpawnPart()
      {
         for (int i = 0; i < 3; i++)
         {
            for (int j = 0; j < 2; j++)
            {
               for (int k = 0; k < 2; k++)
               {
                  bool bSpawnroOnly = j == 1;
                  JDFDoc d = JDFTestCaseBase.creatXMDoc();
                  JDFNode n = d.getJDFRoot();
                  n.removeNodeInfo();
                  JDFNodeInfo ni = n.getCreateNodeInfo();
                  Assert.IsNotNull(ni, "ni");
                  JDFComment comment = n.appendComment();
                  comment.setText("Comment 1");
                  // ni.addPartition(JDFResource.EnumPartIDKey.SignatureName,
                  // "Sig1");
                  JDFResourceLink l = n.getMatchingLink(ElementName.NODEINFO, EnumProcessUsage.AnyInput, 0);
                  l.setPart("SignatureName", "Sig1");
                  ArrayList vRWRes = new ArrayList();
                  vRWRes.Add(ElementName.EXPOSEDMEDIA);
                  VJDFAttributeMap vPartMap = new VJDFAttributeMap();
                  JDFAttributeMap map = new JDFAttributeMap();
                  map.put("SignatureName", "Sig1");
                  map.put("SheetName", "S1");
                  vPartMap.Add(map);
                  JDFResourceLink xmRL = n.getMatchingLink(ElementName.EXPOSEDMEDIA, EnumProcessUsage.AnyInput, 0);
                  xmRL.setAmount(40, i == 1 ? map : null);
                  xmRL.setUsage(EnumUsage.Output);
                  xmRL.setAttribute("foo:bar", "a", "www.foobar.com");

                  JDFSpawn spawn = new JDFSpawn(n); // fudge to test
                  // output counting

                  JDFNode spawnedNode;
                  if (k == 0)
                     spawnedNode = spawn.spawn("thisUrl", "newURL", vRWRes, vPartMap, bSpawnroOnly, true, true, true);
                  else
                     spawnedNode = spawn.spawnInformative("thisUrl", "newURL", vPartMap, bSpawnroOnly, true, true, true);

                  string spawnID = spawnedNode.getSpawnID(false);
                  Assert.AreNotEqual("", spawnID);
                  spawnedNode.getCreateAuditPool().addProcessRun(EnumNodeStatus.Completed, null, vPartMap);

                  JDFComponent spawnedROComponent = (JDFComponent)spawnedNode.getResource(ElementName.COMPONENT, EnumUsage.Output, 0);
                  Assert.IsNotNull(spawnedROComponent);
                  Assert.IsNotNull(spawnedROComponent.getPartition(map, EnumPartUsage.Explicit));
                  JDFAttributeMap map2 = new JDFAttributeMap();
                  map2.put("SignatureName", "Sig2");
                  map2.put("SheetName", "S2");
                  if (j == 0)
                     Assert.IsNotNull(spawnedROComponent.getPartition(map2, EnumPartUsage.Explicit), "ro resources are spawned complete");
                  else
                     Assert.IsNull(spawnedROComponent.getPartition(map2, EnumPartUsage.Explicit), "ro resources are spawned reduced");

                  Assert.IsTrue(spawnedNode.ToString().IndexOf(AttributeName.SPAWNSTATUS) < 0, "no spawnStatus");
                  JDFResourceLink rl = spawnedNode.getMatchingLink(ElementName.EXPOSEDMEDIA, EnumProcessUsage.AnyOutput, 0);
                  JDFResourceAudit ra = spawnedNode.cloneResourceToModify(rl);
                  string clonedResID = ra.getOldLink().getrRef();

                  // check that the spawnIDs attribute is correctly placed in
                  // main and sub
                  JDFExposedMedia xmSpawn = (JDFExposedMedia)rl.getTarget();
                  Assert.IsNotNull(xmSpawn);
                  Assert.AreEqual(new VString(spawnID, null), xmSpawn.getSpawnIDs(false));
                  JDFAttributeMap mapXMSpawn = xmSpawn.getPartMap();
                  JDFExposedMedia xmMain = (JDFExposedMedia)n.getMatchingResource(ElementName.EXPOSEDMEDIA, EnumProcessUsage.AnyOutput, null, 0);
                  xmMain = (JDFExposedMedia)xmMain.getPartition(mapXMSpawn, null);
                  Assert.IsNotNull(xmMain);
                  if (k == 0) // no main check for spawn informative
                     Assert.AreEqual(new VString(spawnID, null), xmMain.getSpawnIDs(false));

                  JDFExposedMedia xmSpawnFront = (JDFExposedMedia)xmSpawn.getPartition(new JDFAttributeMap("Side", "Front"), null);
                  Assert.IsNotNull(xmSpawnFront);
                  JDFExposedMedia xmSpawnFrontEn = (JDFExposedMedia)xmSpawnFront.addPartition(EnumPartIDKey.PartVersion, "En");
                  Assert.IsNotNull(xmSpawnFrontEn);

                  JDFResourceLink loRL = spawnedNode.getMatchingLink(ElementName.LAYOUT, EnumProcessUsage.AnyInput, 0);
                  Assert.IsNull(loRL.getPartMapVector());

                  n = d.getJDFRoot();
                  JDFComment comment2 = n.appendComment();
                  comment2.setText("Comment 2 after");
                  JDFComment comment3 = spawnedNode.appendComment();
                  comment3.setText("Comment 3 spawned");

                  JDFResourceLink xmRLspawn = spawnedNode.getMatchingLink(ElementName.EXPOSEDMEDIA, EnumProcessUsage.AnyOutput, 0);
                  xmRLspawn.setActualAmount(42, i != 0 ? map : null);
                  Assert.AreEqual("a", xmRLspawn.getAttribute("foo:bar", "www.foobar.com", null));
                  Assert.AreEqual(40.0, xmRLspawn.getAmount(map), 0, "amount ok");
                  Assert.AreEqual(42.0, xmRLspawn.getActualAmount(map), 0.0, "act amount ok");

                  // xmRLspawn.setAttribute("foo:bar","bb","www.foobar.com");
                  if (i == 2)
                  {
                     xmRLspawn.getAmountPool().getPartAmount(map, 0).removeAttribute(AttributeName.ACTUALAMOUNT);
                     Assert.AreEqual(0, xmRLspawn.getAmountPool().getPartAmount(map, 0).getAttributeMap().Count);
                     xmRLspawn.setActualAmount(42, null);
                  }
                  if (k > 0)
                     continue; // don't merge if spawn informative

                  JDFMerge merge = new JDFMerge(n);
                  merge.bAddMergeToProcessRun = true;

                  // merge here
                  JDFNode mergedNode = merge.mergeJDF(spawnedNode, "merged", JDFNode.EnumCleanUpMerge.None, EnumAmountMerge.UpdateLink);
                  JDFAuditPool ap = mergedNode.getAuditPool();
                  Assert.IsNotNull(ap);
                  JDFMerged merged = (JDFMerged)ap.getAudit(0, EnumAuditType.Merged, null, null);
                  JDFProcessRun pr = (JDFProcessRun)mergedNode.getChildByTagName(ElementName.PROCESSRUN, null, 0, null, false, true);
                  Assert.AreEqual(pr.getSpawnID(), spawnID);
                  Assert.AreEqual(pr.getReturnTime(), merged.getTimeStampDate());

                  Assert.IsNotNull(merged);
                  Assert.AreEqual(vPartMap, merged.getPartMapVector());
                  Assert.IsNull(ap.getElement(ElementName.PART));
                  xmRL = mergedNode.getMatchingLink(ElementName.EXPOSEDMEDIA, EnumProcessUsage.AnyOutput, 0);
                  VElement poolChildren = mergedNode.getResourceLinkPool().getPoolChildren("NodeInfoLink", null, null);
                  Assert.IsNotNull(poolChildren, "poolChildren");
                  Assert.AreEqual(1, poolChildren.Count, "no spurious ni added");
                  Assert.AreEqual(3, mergedNode.getChildElementVector(ElementName.COMMENT, null, null, true, 99, false).Count, "Comment size");
                  Assert.AreEqual(40.0, xmRL.getAmount(map), 0.0, "merged amount ok");
                  Assert.AreEqual("a", xmRL.getAttribute("foo:bar", "www.foobar.com", null), "did not overwrite rl attribute");
                  Assert.IsTrue(xmRL.hasAttribute(AttributeName.RREF));

                  JDFExposedMedia xm = (JDFExposedMedia)mergedNode.getMatchingResource(ElementName.EXPOSEDMEDIA, EnumProcessUsage.AnyOutput, null, 0);
                  Assert.IsTrue(xm.getPartIDKeys().Contains("PartVersion"), "PartVersion was added in spawned node");
                  xm = (JDFExposedMedia)xm.getPartition(map, null);
                  if (i < 2)
                  {
                     Assert.IsTrue(xmRL.getActualAmount(map) == 42, "merged act amount ok");
                     Assert.IsTrue(xm.getAmount() == 42, "merged res amount ok");
                     Assert.IsTrue(xm.getAmountProduced() == 42, "merged res amountproduced ok");
                  }

                  // test whether anything modified and tracked in a resource
                  // audit got correctly merged
                  JDFResourceAudit raMerge = (JDFResourceAudit)ap.getAudit(0, EnumAuditType.ResourceAudit, null, null);
                  Assert.IsNotNull(raMerge, "res audit merged");
                  JDFResource rOld = raMerge.getOldLink().getTarget();
                  Assert.IsNotNull(rOld, "old res  merged");
                  Assert.AreEqual(rOld.getID(), clonedResID, "old res ID");
                  JDFResource rNew = raMerge.getNewLink().getTarget();
                  Assert.IsNotNull(rNew, "new res  merged");
                  Assert.IsNull(ap.getElement("Part"));
                  JDFMerged mergedAudit = (JDFMerged)ap.getAudit(-1, EnumAuditType.Merged, null, null);
                  Assert.IsNotNull(mergedAudit);
                  Assert.AreEqual(mergedAudit.getPartMapVector()[0], map);
               }
            }
         }
      }


      [TestMethod]
      public virtual void testSpawnMergeSimple()
      {
         EnumCleanUpMerge[] cu = new EnumCleanUpMerge[] { EnumCleanUpMerge.None, EnumCleanUpMerge.RemoveAll, EnumCleanUpMerge.RemoveRRefs };
         for (int i = 0; i < 3; i++)
         {
            JDFDoc d = JDFTestCaseBase.creatXMDoc();
            JDFNode n = d.getJDFRoot();
            // test spawning of referenced resources in parent nodes
            n.setType(EnumType.ProcessGroup);
            JDFNode n2 = n.addJDFNode(EnumType.ConventionalPrinting);

            n2.moveElement(n.getResourceLinkPool(), null);
            // JDFComponent c=(JDFComponent)
            // n2.addResource(ElementName.COMPONENT, EnumUsage.Output);
            n2.getCreateAuditPool().addNotification(null, null, null).appendComment().setText("notification all pre");
            n2.removeNodeInfo();
            n2.appendNodeInfo();
            JDFSpawn spawn = new JDFSpawn(n2); // fudge to test output
            // counting
            n2.setStatus(EnumNodeStatus.Waiting);
            Assert.AreEqual(EnumNodeStatus.Waiting, n2.getPartStatus(null));
            n2.getCreateAuditPool().addNotification(null, null, null).appendComment().setText("notification 2 main");

            string pid = n2.getJobPartID(false);
            Assert.AreNotEqual("", pid);

            ArrayList vRW = new ArrayList();
            vRW.Add("Component");
            vRW.Add(null);

            JDFNode spawnedNode = spawn.spawn("thisUrl", "newURL", vRW, null, false, true, true, true);
            spawnedNode.getCreateAuditPool().addNotification(null, null, null).appendComment().setText("notification 3 sub");
            Assert.IsTrue(spawnedNode.ToString().IndexOf(AttributeName.SPAWNSTATUS) < 0, "no spawnStatus");
            JDFResourceLink cLink = spawnedNode.getMatchingLink(ElementName.COMPONENT, null, 0);
            Assert.IsNotNull(cLink);
            cLink.setActualAmount(42, null);

            spawnedNode.setStatus(EnumNodeStatus.Part);
            spawnedNode.getNodeInfo().setNodeStatus(EnumNodeStatus.Aborted);
            Assert.AreEqual(EnumNodeStatus.Part, spawnedNode.getStatus());
            Assert.AreEqual(EnumNodeStatus.Aborted, spawnedNode.getPartStatus(null));
            JDFAuditPool auditPool = spawnedNode.getCreateAuditPool();
            auditPool.addProcessRun(EnumNodeStatus.Aborted, null, null);
            JDFNotification notif = (JDFNotification)auditPool.addAudit(EnumAuditType.Notification, null);
            notif.appendComment().setText("fooBar");

            JDFMerge merge = new JDFMerge(n);
            merge.bAddMergeToProcessRun = true;

            JDFNode mergedNode = merge.mergeJDF(spawnedNode, "merged", cu[i], EnumAmountMerge.UpdateLink);

            Assert.AreEqual(EnumNodeStatus.Part, mergedNode.getStatus());
            Assert.AreEqual(EnumNodeStatus.Aborted, mergedNode.getPartStatus(null));

            JDFNode jobPart = d.getJDFRoot().getJobPart(pid, null);
            Assert.AreEqual(jobPart, mergedNode);
            JDFAuditPool auditPoolMerged = jobPart.getAuditPool();
            if (i == 0)
            {
               Assert.AreEqual(((JDFProcessRun)auditPoolMerged.getAudit(0, EnumAuditType.ProcessRun, null, null)).getSubmissionTime(), n.getAuditPool().getAudit(0, EnumAuditType.Spawned, null, null).getTimeStampDate());
            }
            Assert.IsNotNull(auditPoolMerged.getAudit(3, EnumAuditType.Notification, null, null));
            Assert.IsNull(auditPoolMerged.getAudit(4, EnumAuditType.Notification, null, null));
            Assert.AreEqual("fooBar", auditPoolMerged.getAudit(-1, EnumAuditType.Notification, null, null).getComment(0).getText(), "comment text correctly merged");
            Assert.AreEqual(42.0, ((JDFComponent)jobPart.getResource(ElementName.COMPONENT, EnumUsage.Output, 0)).getAmountProduced(), 0.0);
         }
      }


      [TestMethod]
      public virtual void testSpawnAddPartRoot()
      {
         JDFDoc d = JDFTestCaseBase.creatXMDoc();
         JDFNode n = d.getJDFRoot();
         // test spawning of referenced resources in parent nodes
         n.setType(EnumType.ProcessGroup);
         JDFNode n2 = n.addJDFNode(EnumType.ConventionalPrinting);
         n2.moveElement(n.getResourceLinkPool(), null);
         n = n2;
         n.removeNodeInfo();
         JDFNodeInfo ni = n.getCreateNodeInfo();
         Assert.IsNotNull(ni, "ni");
         JDFComment comment = n.appendComment();
         comment.setText("Comment 1");
         ArrayList vResRW = new ArrayList();
         vResRW.Add(ElementName.EXPOSEDMEDIA);
         vResRW.Add(ElementName.APPROVALSUCCESS);

         JDFResourceLink xmRL = n.getMatchingLink(ElementName.EXPOSEDMEDIA, EnumProcessUsage.AnyInput, 0);
         xmRL.setAmount(40, null);
         xmRL.setUsage(EnumUsage.Output);

         JDFExposedMedia xmMain = (JDFExposedMedia)n.getMatchingResource(ElementName.EXPOSEDMEDIA, EnumProcessUsage.AnyOutput, null, 0);
         JDFMedia media = xmMain.getMedia();
         media.makeRootResource("mediaID", n, true);

         JDFSpawn spawn = new JDFSpawn(n); // fudge to test output counting

         JDFNode spawnedNode = spawn.spawn("thisUrl", "newURL", vResRW, null, false, true, true, true);
         Assert.IsTrue(spawnedNode.ToString().IndexOf(AttributeName.SPAWNSTATUS) < 0, "no spawnStatus");

         JDFResourceLink xmRLspawn = spawnedNode.getMatchingLink(ElementName.EXPOSEDMEDIA, EnumProcessUsage.AnyOutput, 0);
         JDFNodeInfo ni2 = (JDFNodeInfo)spawnedNode.getMatchingResource(ElementName.NODEINFO, EnumProcessUsage.AnyInput, null, 0);
         JDFExposedMedia xm = (JDFExposedMedia)xmRLspawn.getTarget();
         Assert.IsFalse(xm.getPartIDKeys().Contains("PartVersion"), "PartVersion was added in spawned node");
         Assert.IsFalse(ni2.getPartIDKeys().Contains("PartVersion"), "PartVersion was added in spawned node");
         Assert.IsNotNull(xm);

         ni2.addPartition(EnumPartIDKey.PartVersion, "En");

         JDFExposedMedia xmRoot = (JDFExposedMedia)xm.getResourceRoot();
         Assert.AreEqual(xm, xmRoot);

         JDFMedia spawnMedia = xm.getMedia();
         Assert.IsNotNull(spawnMedia);

         n = d.getJDFRoot();
         // test spawning of referenced resources in parent nodes
         n = (JDFNode)n.getElement("JDF");
         JDFNode mergedNode = new JDFMerge(n).mergeJDF(spawnedNode, "merged", JDFNode.EnumCleanUpMerge.None, EnumAmountMerge.UpdateLink);
         xmRL = mergedNode.getMatchingLink(ElementName.EXPOSEDMEDIA, EnumProcessUsage.AnyOutput, 0);
         ni2 = (JDFNodeInfo)mergedNode.getMatchingResource(ElementName.NODEINFO, EnumProcessUsage.AnyInput, null, 0);
         Assert.IsTrue(ni2.getPartIDKeys().Contains("PartVersion"), "PartVersion was added in spawned node");

      }


      [TestMethod]
      public virtual void testSpawnAddPart()
      {
         for (int i = 0; i < 2; i++)
         {
            JDFDoc d = JDFTestCaseBase.creatXMDoc();
            JDFNode n = d.getJDFRoot();
            if (i == 1)
            {
               // test spawning of referenced resources in parent nodes
               n.setType(EnumType.ProcessGroup);
               JDFNode n2 = n.addJDFNode(EnumType.ConventionalPrinting);
               n2.moveElement(n.getResourceLinkPool(), null);
               n = n2;
            }
            n.removeNodeInfo();
            JDFNodeInfo ni = n.getCreateNodeInfo();
            n.appendMatchingResource(ElementName.APPROVALSUCCESS, EnumProcessUsage.AnyInput, null);
            Assert.IsNotNull(ni, "ni");
            JDFComment comment = n.appendComment();
            comment.setText("Comment 1");
            // ni.addPartition(JDFResource.EnumPartIDKey.SignatureName,"Sig1");
            JDFResourceLink l = n.getMatchingLink(ElementName.NODEINFO, EnumProcessUsage.AnyInput, 0);
            l.setPart("SignatureName", "Sig1");
            ArrayList vResRW = new ArrayList();
            vResRW.Add(ElementName.EXPOSEDMEDIA);
            vResRW.Add(ElementName.APPROVALSUCCESS);
            VJDFAttributeMap vMap = new VJDFAttributeMap();
            JDFAttributeMap map = new JDFAttributeMap();
            map.put("SignatureName", "Sig1");
            map.put("SheetName", "S1");
            vMap.Add(map);

            JDFResourceLink xmRL = n.getMatchingLink(ElementName.EXPOSEDMEDIA, EnumProcessUsage.AnyInput, 0);
            xmRL.setAmount(40, i == 0 ? map : null);
            xmRL.setUsage(EnumUsage.Output);

            JDFExposedMedia xmMain = (JDFExposedMedia)n.getMatchingResource(ElementName.EXPOSEDMEDIA, EnumProcessUsage.AnyOutput, null, 0);
            JDFMedia media = xmMain.getMedia();
            media.makeRootResource("mediaID", n, true);

            JDFSpawn spawn = new JDFSpawn(n); // fudge to test output
            // counting

            JDFNode spawnedNode = spawn.spawn("thisUrl", "newURL", vResRW, vMap, false, true, true, true);
            Assert.IsTrue(spawnedNode.ToString().IndexOf(AttributeName.SPAWNSTATUS) < 0, "no spawnStatus");

            JDFResourceLink xmRLspawn = spawnedNode.getMatchingLink(ElementName.EXPOSEDMEDIA, EnumProcessUsage.AnyOutput, 0);
            JDFNodeInfo ni2 = (JDFNodeInfo)spawnedNode.getMatchingResource(ElementName.NODEINFO, EnumProcessUsage.AnyInput, null, 0);
            JDFExposedMedia xm = (JDFExposedMedia)xmRLspawn.getTarget();
            Assert.IsFalse(xm.getPartIDKeys().Contains("PartVersion"), "PartVersion was added in spawned node");
            Assert.IsFalse(ni2.getPartIDKeys().Contains("PartVersion"), "PartVersion was added in spawned node");
            Assert.IsNotNull(xm);
            JDFApprovalSuccess as2 = (JDFApprovalSuccess)spawnedNode.getMatchingResource(ElementName.APPROVALSUCCESS, EnumProcessUsage.AnyInput, null, 0);
            Assert.IsNotNull(as2);
            as2.addPartition(EnumPartIDKey.PartVersion, "En");
            Assert.IsTrue(as2.getPartIDKeys().Contains(EnumPartIDKey.PartVersion.getName()));

            JDFExposedMedia xmSpawnFront = (JDFExposedMedia)xm.getPartition(new JDFAttributeMap("Side", "Front"), null);
            Assert.IsNotNull(xmSpawnFront);
            JDFExposedMedia xmSpawnFrontEn = (JDFExposedMedia)xmSpawnFront.addPartition(EnumPartIDKey.PartVersion, "En");
            Assert.IsNotNull(xmSpawnFrontEn);
            ni2.addPartition(EnumPartIDKey.PartVersion, "En");

            JDFExposedMedia xmRoot = (JDFExposedMedia)xm.getResourceRoot();
            Assert.AreNotEqual(xm, xmRoot);

            JDFMedia spawnMedia = xm.getMedia();
            Assert.IsNotNull(spawnMedia);

            Assert.IsNull(xmRoot.getSpawnIDs(false));
            VString spawnIDs = xm.getSpawnIDs(false);
            string spawnID = spawnedNode.getSpawnID(false);
            Assert.AreEqual(spawnIDs.stringAt(0), spawnID);

            JDFAttributeMap mapNew1 = new JDFAttributeMap();
            mapNew1.put("SignatureName", "Sig1");
            mapNew1.put("SheetName", "S1_OK");
            JDFExposedMedia xmNew1 = (JDFExposedMedia)xmRoot.getCreatePartition(mapNew1, null);
            xmNew1.appendSpawnIDs(spawnID);
            xmNew1.setDescriptiveName("good new parallel");

            JDFAttributeMap mapNew2 = new JDFAttributeMap();
            mapNew2.put("SignatureName", "Sig1");
            mapNew2.put("SheetName", "S1_Bad");
            xmRoot.getCreatePartition(mapNew1, null);

            n = d.getJDFRoot();
            // test spawning of referenced resources in parent nodes
            if (i == 1)
            {
               n = (JDFNode)n.getElement("JDF");
            }
            JDFNode mergedNode = new JDFMerge(n).mergeJDF(spawnedNode, "merged", JDFNode.EnumCleanUpMerge.None, EnumAmountMerge.UpdateLink);
            xmRL = mergedNode.getMatchingLink(ElementName.EXPOSEDMEDIA, EnumProcessUsage.AnyOutput, 0);
            JDFExposedMedia xmMRoot = (JDFExposedMedia)mergedNode.getMatchingResource(ElementName.EXPOSEDMEDIA, EnumProcessUsage.AnyOutput, null, 0);
            Assert.IsTrue(xmMRoot.getPartIDKeys().Contains("PartVersion"), "PartVersion was added in spawned node");
            ni2 = (JDFNodeInfo)mergedNode.getMatchingResource(ElementName.NODEINFO, EnumProcessUsage.AnyInput, null, 0);
            Assert.IsTrue(ni2.getPartIDKeys().Contains("PartVersion"), "PartVersion was added in spawned node");

            JDFExposedMedia xmM1 = (JDFExposedMedia)xmMRoot.getPartition(mapNew1, null);
            Assert.AreEqual(xmNew1.getDescriptiveName(), xmM1.getDescriptiveName(), "Merged xm1");

            JDFExposedMedia xmM2 = (JDFExposedMedia)xmMRoot.getPartition(mapNew2, null);
            Assert.IsNull(xmM2, "did not merge xm2");
         }
      }


      [TestMethod]
      public virtual void testSpawn2()
      {
         string fileNameIn = "km2";
         string spawnNodeID = "Link08539766_000147";

         JDFParser p = new JDFParser();
         JDFDoc jdfDocIn = p.parseFile(sm_dirTestData + fileNameIn + ".jdf");
         Assert.IsTrue(jdfDocIn != null, "Parse of file " + sm_dirTestData + fileNameIn + " failed");

         if (jdfDocIn != null)
         {
            // prepare the spawn process
            JDFNode rootIn = (JDFNode)jdfDocIn.getRoot();

            JDFNode spawnNode = null;
            if (spawnNodeID.Equals(""))
            {
               spawnNode = rootIn;
            }
            else
            {
               spawnNode = (JDFNode)rootIn.getTarget(spawnNodeID, AttributeName.ID);
            }
            Assert.IsNotNull(spawnNode, "No such ID " + spawnNodeID);

            if (spawnNode != null)
            {
               JDFSpawn spawn = new JDFSpawn(spawnNode);
               JDFNode jdfSpawned = spawn.spawn(sm_dirTestData + fileNameIn + ".jdf", null, null, null, false, true, true, true);

               // verändertes Ausgangsfile rausschreiben
               rootIn.eraseEmptyNodes(true);
               string strXMLFileModified = fileNameIn + "_spawnedSource.xml";
               jdfDocIn.write2File(sm_dirTestDataTemp + strXMLFileModified, 2, true);

               XMLDoc doc2 = jdfSpawned.getOwnerDocument_KElement();
               string strXMLFileModified2 = fileNameIn + "_spawnedTarget.xml";
               doc2.write2File(sm_dirTestDataTemp + strXMLFileModified2, 0, true);
            }
         }
      }

      [TestMethod]
      public virtual void testSpawn3()
      {
         string fileNameIn = "km2";

         JDFParser p = new JDFParser();
         JDFDoc jdfDocIn = p.parseFile(sm_dirTestData + fileNameIn + ".jdf");

         JDFNode root = jdfDocIn.getJDFRoot();
         JDFNode subJob = root.getJobPart("Qua0", null); // Link08539766_000147
         VElement v = subJob.getChildElementVector("JDF", null, new JDFAttributeMap(), false, int.MaxValue, false);
         VElement v2 = new VElement();
         int nEvent = 0;
         int nComment = 0;
         for (int i = 0; i < v.Count; i++)
         {
            JDFNode spawnNode = (JDFNode)v[i];
            spawnNode.getCreateAuditPool().addEvent("me", EnumSeverity.Event);
            spawnNode.appendComment().setText("Comment" + Convert.ToString(i));
            JDFSpawn spawn = new JDFSpawn(spawnNode);
            JDFNode spawnedNode = spawn.spawn(sm_dirTestData + fileNameIn + ".jdf", null, null, null, false, true, true, true);
            v2.Add(spawnedNode);
            nEvent += spawnedNode.getChildrenByTagName("Notification", "", new JDFAttributeMap(), false, false, 0).Count;
            nComment += spawnedNode.numChildNodes(XmlNodeType.Comment);
         }
         for (int i = 0; i < v2.Count; i++)
         {
            JDFNode nodeToMerge = (JDFNode)v2[i];
            new JDFMerge(root).mergeJDF(nodeToMerge, JDFConstants.EMPTYSTRING, JDFNode.EnumCleanUpMerge.None, JDFResource.EnumAmountMerge.None);
         }
         Assert.AreEqual(nEvent, root.getChildrenByTagName("Notification", "", new JDFAttributeMap(), false, false, 0).Count);

         int copyComments = 0;
         v = subJob.getChildElementVector("JDF", null, null, false, int.MaxValue, false);
         for (int i = 0; i < v.Count; i++)
         {
            JDFNode spawnNode = (JDFNode)v[i];
            copyComments += spawnNode.numChildNodes(XmlNodeType.Comment);
         }

         Assert.AreEqual(nComment, copyComments);

         jdfDocIn.write2File(sm_dirTestDataTemp + "km2_AllSpawnedAndMerged.xml", 2, true);
      }

      ///   
      ///	 <summary> * test customerinfo and nodeinfo related stuff including high level access
      ///	 * to information in the AncestorPool
      ///	 *  </summary>
      ///	 
      [TestMethod]
      public virtual void testSpawnNI13()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         Assert.AreEqual(null, n.getInheritedCustomerInfo("@CustomerOrderID"), "null cid");
         n.setType("ProcessGroup", false);
         VString v = new VString();
         v.Add("Interpreting");
         v.Add("Rendering");

         for (int i = 0; i < 3; i++)
         {
            JDFNode n2 = n.addCombined(v);
            JDFNodeInfo ni = n2.appendNodeInfo();
            JDFSpawn spawn = new JDFSpawn(n2);
            VJDFAttributeMap vSpawnParts = null;
            if (i >= 1)
            {
               if (i == 2)
               {
                  ni.addPartition(EnumPartIDKey.Run, "r1");
               }
               vSpawnParts = new VJDFAttributeMap();
               vSpawnParts.Add(new JDFAttributeMap("Run", "r1"));
            }
            if (i == 1)
            {
               spawn.bFixResources = false;
            }
            JDFNode spawnedNode = spawn.spawn("thisFile", "spawnFile", null, vSpawnParts, true, true, true, true);
            JDFNodeInfo niSpawn = spawnedNode.getInheritedNodeInfo(null);
            Assert.IsNotNull(niSpawn, "ni");
            if (i >= 1)
            {
               Assert.AreEqual(vSpawnParts, niSpawn.getPartMapVector(false));
            }
            Assert.AreEqual(1, spawnedNode.getResourcePool().numChildElements(ElementName.NODEINFO, null));
         }
      }

      ///   
      ///	 <summary> * test customerinfo and nodeinfo related stuff including high level access
      ///	 * to information in the AncestorPool
      ///	 *  </summary>
      ///	 
      [TestMethod]
      public virtual void testUnSpawn()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         Assert.AreEqual("null cid", n.getInheritedCustomerInfo("@CustomerOrderID"), null);
         n.setType("ProcessGroup", false);
         VString v = new VString();
         v.Add("Interpreting");
         v.Add("Rendering");

         for (int i = 0; i < 2; i++) // 0 = now part, 1==part
         {
            JDFNode n2 = n.addCombined(v);
            JDFSpawn spawn = new JDFSpawn(n2);
            VJDFAttributeMap vMap = new VJDFAttributeMap();
            vMap.Add(new JDFAttributeMap("Side", "Front"));

            JDFNode spawnedNode = spawn.spawn("thisFile", "spawnFile", null, i == 0 ? null : vMap, true, true, true, true);
            string spawnID = spawnedNode.getSpawnID(false);
            Assert.AreNotEqual("", spawnID);
            JDFSpawn spawn2 = new JDFSpawn(n2);
            spawn2.unSpawn(spawnID);
            string toString = n.ToString();
            Assert.IsTrue(toString.IndexOf(spawnID) < 0);
            Assert.IsTrue(toString.IndexOf("Spawn") < 0);
            Assert.IsTrue(toString.IndexOf("Merge") < 0);
         }
      }

      ///   
      ///	 <summary> * test customerinfo and nodeinfo related stuff including high level access
      ///	 * to information in the AncestorPool
      ///	 *  </summary>
      ///	 
      [TestMethod]
      public virtual void testSpawnNI()
      {
         for (int i = 0; i < 2; i++)
         {
            for (int j = 0; j < 2; j++)
            {

               JDFDoc d = new JDFDoc("JDF");
               JDFNode n = d.getJDFRoot();
               Assert.AreEqual(null, n.getInheritedCustomerInfo("@CustomerOrderID"), "null cid");
               n.setType("ProcessGroup", false);
               EnumVersion version = i == 0 ? EnumVersion.Version_1_2 : EnumVersion.Version_1_2;
               n.setVersion(version);

               VString v = new VString();
               v.Add("Interpreting");
               v.Add("Rendering");

               JDFNode n2 = n.addCombined(v);

               JDFNodeInfo ni = j == 0 ? n2.appendNodeInfo() : n.appendNodeInfo();
               ni.setFirstEnd(new JDFDate());
               ni.appendJMF();
               JDFSpawn spawn = new JDFSpawn(n2);
               JDFNode spawnedNode = spawn.spawn("thisFile", "spawnFile", null, null, true, true, true, true);

               JDFNodeInfo niSpawn = spawnedNode.getInheritedNodeInfo(null);
               Assert.IsNotNull(niSpawn, "ni");
               JDFAncestor a = spawnedNode.getAncestorPool().getAncestor(0);
               if (j == 0)
               {
                  Assert.IsNull(a.getNodeInfo());
                  Assert.IsNotNull(spawnedNode.getNodeInfo());
               }
               else
               {
                  Assert.IsNotNull(a.getNodeInfo());
                  Assert.IsNull(spawnedNode.getNodeInfo());
               }

            }
         }
      }

      ///   
      ///	 <summary> * test customerinfo and nodeinfo related stuff including high level access
      ///	 * to information in the AncestorPool
      ///	 *  </summary>
      ///	 
      [TestMethod]
      public virtual void testSpawnCINI()
      {
         for (int i = 0; i < 2; i++)
         {
            for (int j = 0; j < 2; j++)
            {
               VJDFAttributeMap partmapvector = new VJDFAttributeMap();
               if (j == 1)
               {
                  JDFAttributeMap partmap = new JDFAttributeMap();
                  partmap.put("SheetName", "S1");
                  partmapvector.Add(partmap);
               }

               JDFDoc d = new JDFDoc("JDF");
               JDFNode n = d.getJDFRoot();
               Assert.AreEqual(null, n.getInheritedCustomerInfo("@CustomerOrderID"), "null cid");
               n.setType("ProcessGroup", false);
               EnumVersion version = i == 0 ? EnumVersion.Version_1_2 : EnumVersion.Version_1_2;
               n.setVersion(version);
               JDFCustomerInfo ci = n.appendCustomerInfo();
               JDFContact contact = ci.appendContact();
               contact = (JDFContact)contact.makeRootResource("ID_Contact1", n, true);
               ci.setCustomerOrderID("cid");
               Assert.AreEqual("cid", n.getInheritedCustomerInfo("@CustomerOrderID").getCustomerOrderID(), "cid");

               VString v = new VString();
               v.Add("Interpreting");
               v.Add("Rendering");

               JDFNode n2 = n.addCombined(v);
               JDFNodeInfo ni = n2.appendNodeInfo();
               ni.setFirstEnd(new JDFDate());
               JDFSpawn spawn = new JDFSpawn(n2);
               JDFNode spawnedNode = spawn.spawn("thisFile", "spawnFile", null, partmapvector, true, true, true, true);
               ci = spawnedNode.getInheritedCustomerInfo(null);
               Assert.IsNotNull(ci, "ci");
               JDFContact refContact = ci.getContact(0);
               Assert.IsNotNull(refContact, "ref to contact");
               JDFNodeInfo niSpawn = spawnedNode.getInheritedNodeInfo(null);
               Assert.IsNotNull(niSpawn, "ni");

               Assert.IsNotNull(ci, "ci");
               Assert.IsNotNull((j == 1 ? n2 : n).getAuditPool().getAudit(0, JDFAudit.EnumAuditType.Spawned, null, null), "spawned");
               string spawnID = spawnedNode.getSpawnID(false);
               Assert.AreEqual("cid", spawnedNode.getInheritedCustomerInfo("@CustomerOrderID").getCustomerOrderID(), "cid");
               JDFAncestor anc = spawnedNode.getAncestorPool().getAncestor(0);
               Assert.IsNull(anc.getAttribute("type", AttributeName.XSIURI, null), "no xsi:type");

               n = new JDFSpawn(n).unSpawn(spawnID);
               Assert.IsNotNull(n, "n2");
               Assert.IsNull(d.getJDFRoot().getAuditPool().getAudit(0, JDFAudit.EnumAuditType.Spawned, null, null), "spawned");

               n.removeCustomerInfo();
               n.setVersion(version);
               ci = n.appendCustomerInfo();
               contact = ci.appendContact();
               contact = (JDFContact)contact.makeRootResource("ID_Contact1", n, true);

               JDFSpawn _spawn = new JDFSpawn(n2);
               spawnedNode = _spawn.spawn("thisFile", "spawnFile", null, partmapvector, true, true, true, true);
               spawnID = spawnedNode.getSpawnID(false);

               ci = spawnedNode.getInheritedCustomerInfo(null);
               Assert.IsNotNull(ci, "ci");
               refContact = ci.getContact(0);
               Assert.IsNotNull(refContact, "ref to contact: " + version.getName());

               n2 = new JDFSpawn(d.getJDFRoot()).unSpawn(spawnID);
               Assert.IsNotNull(n2, "n2");
               Assert.IsTrue(n2.ToString().IndexOf(spawnID) < 0, "n2 no spawnID");

               JDFSpawn spawn2 = new JDFSpawn(n2);
               spawnedNode = spawn2.spawn("thisFile", "spawnFile", null, partmapvector, true, true, true, true);
               spawnID = spawnedNode.getSpawnID(false);

               niSpawn = spawnedNode.getInheritedNodeInfo(null);
               Assert.IsNotNull(niSpawn, "ni");

               spawnedNode.setPartStatus(partmapvector, EnumNodeStatus.Aborted, null);
               Assert.AreEqual(EnumNodeStatus.Aborted, spawnedNode.getPartStatus(j == 1 ? partmapvector[0] : null));

               JDFNode mergedNode = new JDFMerge(n2).mergeJDF(spawnedNode, "merged", JDFNode.EnumCleanUpMerge.None, EnumAmountMerge.UpdateLink);
               Assert.AreEqual(EnumNodeStatus.Aborted, mergedNode.getPartStatus(j == 1 ? partmapvector[0] : null));
            }
         }
      }


      [TestMethod]
      public virtual void testBigSpawn()
      {
         const string strJDFName = "000023_Test_PR3.0.jdf";
         // final String strJDFName = "biginline.jdf";
         string strJDFPath = sm_dirTestData + strJDFName;
         JDFParser parser = new JDFParser();
         JDFDoc jdfDoc = parser.parseFile(strJDFPath);
         for (int i = 1; i < 10; i++)
         {
            Console.WriteLine("i=" + i);
            VJDFAttributeMap vamParts = new VJDFAttributeMap();
            JDFAttributeMap amParts0 = new JDFAttributeMap();
            amParts0.put("Side", "Front");
            amParts0.put("SignatureName", "Sig00" + i);
            amParts0.put("SheetName", "FB 00" + i);
            vamParts.Add(amParts0);
            JDFAttributeMap amParts1 = new JDFAttributeMap();
            amParts1.put("Side", "Back");
            amParts1.put("SignatureName", "Sig00" + i);
            amParts1.put("SheetName", "FB 00" + i);
            vamParts.Add(amParts1);
            ArrayList vsRWResourceIDs = new ArrayList();
            vsRWResourceIDs.Add("Link84847227_000309");
            vsRWResourceIDs.Add("r85326439_027691");
            JDFNode nodeRoot = jdfDoc.getJDFRoot();
            JDFNode nodeProc = nodeRoot.getJobPart("IPD0.I", null);
            JDFSpawn spawn = new JDFSpawn(nodeProc);
            // JDFNode nodeProc = nodeRoot;
            JDFNode nodeSubJDF = spawn.spawn(strJDFPath, null, vsRWResourceIDs, vamParts, true, true, true, true);
            Assert.IsNotNull(nodeSubJDF);

            if (nodeSubJDF != null)
            {
               nodeSubJDF.getOwnerDocument_KElement().write2File(sm_dirTestDataTemp + "bigSub" + i + ".jdf", 2, true);
               if (i == 9)
               {
                  jdfDoc.write2File(sm_dirTestDataTemp + "bigMainPost.jdf", 2, true);
               }
            }
         }
      }


      [TestMethod]
      public virtual void testManySpawn()
      {
         const string strJDFName = "000023_Test_PR3.0.jdf";
         // final String strJDFName = "biginline.jdf";
         string strJDFPath = sm_dirTestData + strJDFName;
         JDFParser parser = new JDFParser();
         JDFDoc jdfDoc = parser.parseFile(strJDFPath);
         JDFNode nodeRoot = jdfDoc.getJDFRoot();
         VElement vNodes = nodeRoot.getTree("JDF", null, null, false, false);
         for (int i = 1; i < vNodes.Count; i++)
         {
            JDFNode nodeProc = (JDFNode)vNodes[i];
            string jobPartID = nodeProc.getJobPartID(false);
            Console.WriteLine("i= " + i + " of " + (vNodes.Count - 1) + " : " + jobPartID);
            ArrayList vsRWResourceIDs = new ArrayList();
            vsRWResourceIDs.Add("Link84847227_000309");
            vsRWResourceIDs.Add("r85326439_027691");
            vsRWResourceIDs.Add("Output");
            nodeProc = nodeRoot.getJobPart(jobPartID, null); // in case it was
            // overwritten
            // by a previos
            // s-m
            JDFSpawn spawn = new JDFSpawn(nodeProc);
            // JDFNode nodeProc = nodeRoot;
            JDFNode nodeSubJDF = spawn.spawn(strJDFPath, null, vsRWResourceIDs, null, true, true, true, true);
            Assert.IsNotNull(nodeSubJDF);

            nodeSubJDF.getOwnerDocument_KElement().write2File(sm_dirTestDataTemp + "manySub" + i + ".jdf", 2, true);
            jdfDoc.write2File(sm_dirTestDataTemp + "bigMainMany" + i + ".jdf", 2, true);

            Assert.AreEqual(nodeProc.getID(), nodeSubJDF.getID());
            JDFDoc d2 = parser.parseFile(sm_dirTestDataTemp + "manySub" + i + ".jdf");
            Assert.IsNotNull(d2, "The subjdf could be parsed!");
            string spawnID = nodeSubJDF.getSpawnID(false);
            JDFMerge m = new JDFMerge(nodeRoot);
            Assert.IsTrue(nodeRoot.ToString().IndexOf(spawnID) > 0);
            m.mergeJDF(nodeSubJDF, "dummy", EnumCleanUpMerge.RemoveAll, EnumAmountMerge.UpdateLink);
            Assert.IsTrue(nodeRoot.ToString().IndexOf(spawnID) < 0);
         }
         jdfDoc.write2File(sm_dirTestDataTemp + "bigMainMany.jdf", 2, true);

      }


      [TestMethod]
      public virtual void testMergeUpdateNI()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode root = doc.getJDFRoot();
         root.setType(EnumType.ProcessGroup);
         JDFAttributeMap map1 = new JDFAttributeMap("Run", "r1");
         JDFAttributeMap map2 = new JDFAttributeMap("Run", "r2");
         VJDFAttributeMap vMap = new VJDFAttributeMap();
         vMap.Add(map1);
         vMap.Add(map2);
         JDFNode[] nodes = new JDFNode[3];
         root.setPartStatus(vMap, EnumNodeStatus.Waiting, null);
         nodes[0] = root.addJDFNode(EnumType.Approval);
         nodes[1] = root.addJDFNode(EnumType.Bending);
         nodes[2] = root.addJDFNode(EnumType.ImageReplacement);
         for (int i = 0; i < 3; i++)
         {
            nodes[i].setPartStatus(vMap, EnumNodeStatus.Waiting, null);
         }

         vMap.RemoveAt(1);
         for (int i = 0; i < 3; i++)
         {

            JDFNode node = nodes[i];
            Assert.IsNotNull(node.getNodeInfo());
            JDFSpawn spawn = new JDFSpawn(node);
            spawn.vSpawnParts = vMap;
            JDFNode spawnedNode = spawn.spawn();
            spawnedNode.setPartStatus(map1, EnumNodeStatus.Completed, null);
            JDFMerge merge = new JDFMerge(node);

            // this is the feature taht is being tested..
            merge.bUpdateStati = true;
            node = merge.mergeJDF(spawnedNode, null, EnumCleanUpMerge.None, EnumAmountMerge.None);
            Assert.AreEqual(node.getID(), nodes[i].getID());
            Assert.AreEqual(i == 2 ? EnumNodeStatus.Completed : EnumNodeStatus.Waiting, root.getPartStatus(map1));
            Assert.AreEqual(EnumNodeStatus.Waiting, root.getPartStatus(map2));
            Assert.AreEqual(EnumNodeStatus.Completed, node.getPartStatus(map1));
            Assert.AreEqual(EnumNodeStatus.Waiting, node.getPartStatus(map2));
         }
      }


      [TestMethod]
      public virtual void testBigMerge()
      {
         // testBigSpawn();
         JDFParser parser = new JDFParser();
         JDFDoc jdfDoc = parser.parseFile(sm_dirTestDataTemp + "bigMainPost.jdf");
         for (int i = 9; i > 0; i--)
         {
            JDFParser parser2 = new JDFParser();
            JDFDoc jdfDocSub = parser2.parseFile(sm_dirTestDataTemp + "bigSub" + i + ".jdf");
            JDFNode nodeMain = jdfDoc.getJDFRoot();
            JDFNode nodeSub = jdfDocSub.getJDFRoot();
            JDFNode overWrite = new JDFMerge(nodeMain).mergeJDF(nodeSub, null, EnumCleanUpMerge.RemoveRRefs, EnumAmountMerge.UpdateLink);
            JDFAuditPool ap = overWrite.getAuditPool();
            JDFAudit audit = ap.getAudit(0, EnumAuditType.Merged, null, null);
            Assert.IsNotNull(audit);
            Assert.IsFalse(audit.hasAttribute(AttributeName.SPAWNID));
            Assert.IsNull(nodeMain.getMultipleIDs("ID"));
         }
         jdfDoc.write2File(sm_dirTestDataTemp + "BigMerge.jdf", 2, true);
      }


      [TestMethod]
      public virtual void testCheckSpawnedResources()
      {
         const string strJDFName = "000023_Test_PR3.0.jdf";
         string strJDFPath = sm_dirTestData + strJDFName;
         JDFParser parser = new JDFParser();
         JDFDoc jdfDoc = parser.parseFile(strJDFPath);
         //jdfDoc.getCreateXMLDocUserData().setDirtyPolicy(EnumDirtyPolicy.None);
         VJDFAttributeMap vamParts = new VJDFAttributeMap();
         JDFAttributeMap amParts0 = new JDFAttributeMap();
         amParts0.put("Side", "Front");
         amParts0.put("SignatureName", "Sig002");
         amParts0.put("SheetName", "FB 002");
         vamParts.Add(amParts0);

         JDFAttributeMap amParts1 = new JDFAttributeMap();
         amParts1.put("Side", "Back");
         amParts1.put("SignatureName", "Sig002");
         amParts1.put("SheetName", "FB 002");
         vamParts.Add(amParts1);

         VString vsRWResourceIDs = new VString();
         vsRWResourceIDs.Add("Link84847227_000309");
         vsRWResourceIDs.Add("r85326439_027691");

         JDFNode nodeProc = jdfDoc.getJDFRoot().getJobPart("IPD0.I", null);
         ICollection vSpawned = nodeProc.checkSpawnedResources(vsRWResourceIDs, vamParts);
         Assert.IsNull(vSpawned);
         JDFSpawn spawn = new JDFSpawn(nodeProc);
         spawn.vRWResources_in = vsRWResourceIDs;
         spawn.vSpawnParts = vamParts;
         JDFNode s2 = spawn.spawn();
         Assert.IsNotNull(spawn.checkSpawnedResources());
         Assert.IsNull(s2.getMultipleIDs("ID"));

         try
         {
            spawn.spawn();
            Assert.Fail("multi rw spawn");
         }
         catch (JDFException)
         { // nop
         }
         spawn.bSpawnRWPartsMultiple = true;
         Assert.IsNotNull(spawn.checkSpawnedResources());
         spawn.spawn();

      }

      [TestMethod]
      public virtual void testBookintent()
      {
         string fileNameIn = "bookintent.jdf";
         string fileNameOut = "spawned.jdf";
         string spawnNodeID = "n0016";

         ArrayList vRWResources = new ArrayList();
         vRWResources.Add("Component");
         vRWResources.Add("RunList");
         VJDFAttributeMap vSpawnParts = new VJDFAttributeMap();

         string strSpawnID = spawn(fileNameIn, fileNameOut, spawnNodeID, vRWResources, vSpawnParts);
         unSpawn(fileNameIn, strSpawnID); // "Sp7cb:-7fff"
      }


      private string spawn(string strXMLFile, string strSpawnedFile, string strElementID, ArrayList vRWResources, VJDFAttributeMap vSpawnParts)
      {
         string strSpawnID = JDFConstants.EMPTYSTRING;

         // parse input file
         JDFParser p = new JDFParser();
         JDFDoc jdfDocIn = p.parseFile(sm_dirTestData + strXMLFile);
         Assert.IsTrue(jdfDocIn != null, "Parse of file " + sm_dirTestData + strXMLFile + " failed");

         if (jdfDocIn != null)
         {
            // prepare the spawn process
            JDFNode rootIn = (JDFNode)jdfDocIn.getRoot();

            JDFNode spawnNode = null;
            if (strElementID.Equals(""))
            {
               spawnNode = rootIn;
            }
            else
            {
               spawnNode = (JDFNode)rootIn.getTarget(strElementID, AttributeName.ID);
            }
            Assert.IsTrue(spawnNode != null, "No such ID " + strElementID);

            if (spawnNode != null)
            {
               JDFSpawn _spawn = new JDFSpawn(spawnNode);
               JDFNode jdfSpawned = _spawn.spawnInformative(sm_dirTestData + strXMLFile, null, null, false, true, true, true);
               string spawnID = jdfSpawned.getSpawnID(false);

               string big = jdfDocIn.write2String(0);
               Assert.IsTrue(big.IndexOf(spawnID) < 0, "no spawnID in main");
               JDFSpawn spawn1 = new JDFSpawn(spawnNode);

               jdfSpawned = spawn1.spawn(sm_dirTestData + strXMLFile, null, vRWResources, vSpawnParts, false, true, true, true);
               spawnID = jdfSpawned.getSpawnID(false);
               big = jdfDocIn.write2String(0);
               Assert.IsTrue(big.IndexOf(spawnID) >= 0, "spawnID in main");

               // neu gespawntes FileInfo rausschreiben
               JDFNode rootOut = jdfSpawned;
               XMLDoc docOut = rootOut.getOwnerDocument_KElement();
               docOut.write2File(sm_dirTestDataTemp + strSpawnedFile, 0, true);

               // verändertes Ausgangsfile rausschreiben
               rootIn.eraseEmptyNodes(true);
               string strXMLFileModified = "_" + strXMLFile;
               jdfDocIn.write2File(sm_dirTestDataTemp + strXMLFileModified, 0, true);

               // Vergleich, ob alles richtig gelaufen ist
               // compareXMLFiles (strXMLFileModified,
               // strXMLFileModifiedMaster);
               // compareXMLFiles (strSpawnedFile+".jdf",
               // strSpawnedFileMaster);

               strSpawnID = rootOut.getSpawnID(false);
            }
         }

         return strSpawnID;
      }


      [TestMethod]
      public virtual void testSpawnSheetMix()
      {
         JDFNode nr = new JDFDoc("JDF").getJDFRoot();
         nr.setType(EnumType.Product);
         JDFNode n = nr.addJDFNode("Combined");
         JDFNodeInfo ni = n.getCreateNodeInfo();
         n.setCombined(new VString("Interpreting Rendering ImageSetting", null));
         JDFRunList rl = (JDFRunList)n.addResource(ElementName.RUNLIST, null, EnumUsage.Output, null, nr, null, null);
         rl.setPartUsage(EnumPartUsage.Implicit);
         VString pik = new VString("SignatureName SheetName Side Separation PartVersion", null);
         JDFAttributeMap map = new JDFAttributeMap(AttributeName.SIGNATURENAME, "Sig1");
         map.put(AttributeName.PARTVERSION, "en");
         map.put(AttributeName.SHEETNAME, "s1");
         map.put(AttributeName.SIDE, "Front");
         map.put(AttributeName.SEPARATION, "Black");
         rl.getCreatePartition(map, pik);
         ni.getCreatePartition(map, pik);
         map.put(AttributeName.SEPARATION, "Cyan");
         rl.getCreatePartition(map, pik);
         ni.getCreatePartition(map, pik);
         map.put(AttributeName.SEPARATION, "Yellow");
         ni.getCreatePartition(map, pik);

         VJDFAttributeMap vm = new VJDFAttributeMap();
         JDFAttributeMap ms = new JDFAttributeMap(AttributeName.SIGNATURENAME, "Sig1");
         ms.put(AttributeName.PARTVERSION, "en");
         ms.put(AttributeName.SEPARATION, "Black");
         vm.Add(ms);
         JDFAttributeMap ms2 = new JDFAttributeMap(ms);
         ms2.put(AttributeName.SEPARATION, "Yellow"); // not there...
         vm.Add(ms2);

         JDFSpawn sp = new JDFSpawn(n);
         sp.vSpawnParts = vm;
         sp.vRWResources_in = new VString("Output", null);
         sp.bFixResources = false;

         JDFNode spawned = sp.spawn();

         JDFRunList rlS = (JDFRunList)spawned.getResource(ElementName.RUNLIST, null, 0);
         // why??? Assert.IsTrue(rlS.toString().indexOf("Cyan")>0);
         map.put(AttributeName.SEPARATION, "Magenta");
         rlS.getCreatePartition(map, pik);

         Assert.IsTrue(rl.ToString().IndexOf("SpawnedRW") > 0);
         Assert.AreEqual("SpawnedRW", rl.getPartition(ms2, null).getAttribute_KElement(AttributeName.SPAWNSTATUS));
         // Assert.AreEqual(rl.getPartition(ms,
         // null).getAttribute_KElement(AttributeName.SPAWNSTATUS),"");

         JDFMerge m = new JDFMerge(nr);
         n = m.mergeJDF(spawned, null, EnumCleanUpMerge.RemoveAll, EnumAmountMerge.UpdateLink);

         Assert.IsTrue(rl.ToString().IndexOf("SpawnedRW") < 0);
         Assert.IsTrue(n.ToString().IndexOf("SpawnedRW") < 0);
         Assert.IsTrue(n.ToString().IndexOf("SpawnID") < 0);
         Assert.IsNotNull(rl.getPartition(map, null));
      }


      [TestMethod]
      public virtual void testSpawnSheetNeedsSide()
      {
         JDFDoc readJDF = JDFDoc.parseFile(sm_dirTestData + "pdyv5.jdf");
         Assert.IsNotNull(readJDF);
         JDFNode root = readJDF.getJDFRoot();
         JDFNode spawnNode = (JDFNode)root.getTarget("Link070822_032611973_013511", AttributeName.ID);
         VJDFAttributeMap vSpawnParts = new VJDFAttributeMap();
         // "ImP1.MR" with "VJDFAttributeMap: [0]JDFAttributeMap: { (PartVersion
         // = Eng Eng) (SheetName = S0C) (SignatureName = Sig001) }
         JDFAttributeMap partMap = new JDFAttributeMap();
         partMap.put("PartVersion", "Eng Eng");
         partMap.put("SheetName", "S0C");
         partMap.put("SignatureName", "Sig001");

         vSpawnParts.Add(partMap);
         ArrayList vRWResources_in = new ArrayList();
         JDFNode spawnedNode = new JDFSpawn(spawnNode).spawn("parentURL", "spawnURL", vRWResources_in, vSpawnParts, false, true, false, false);
         JDFNodeInfo ni = spawnedNode.getCreateNodeInfo();
         Assert.IsNull(ni.getPartition(partMap, EnumPartUsage.Explicit));
         partMap.put("Side", "Front");
         Assert.IsNotNull(ni.getPartition(partMap, EnumPartUsage.Explicit));
      }


      [TestMethod]
      public virtual void testSpawnNameSpace()
      {
         for (int i = 0; i < 3; i++)
         {
            JDFNode node = new JDFDoc("JDF").getJDFRoot();
            node.setType("ProcessGroup", false);
            JDFResource r = node.addResource("RunList", null);
            JDFNode n2 = node.addJDFNode("Dummy");
            n2.linkResource(r, EnumUsage.Input, null);
            if (i == 0)
            {
               // best!
               r.setAttribute("foo:bar", "test", "fooNS");

            }
            else if (i == 1)
            {
               // ok
               node.setAttribute("xmlns:foo", "fooNS");
               r.setAttribute("foo:bar", "test");
            }
            else
            {
               // this one is bad because there is no hook to link prefix and
               // ns at time of attribute setting
               r.setAttribute("foo:bar", "test");
               node.setAttribute("xmlns:foo", "fooNS");
            }
            JDFSpawn spawn = new JDFSpawn(n2);
            JDFNode n3 = spawn.spawn();

            string n3String = n3.getOwnerDocument_JDFElement().write2String(2);
            JDFParser parser = new JDFParser();
            if (i < 2)
               Assert.IsNotNull(parser.parseString(n3String), "ns, bad parse loop=" + i);
            else
               Assert.IsNull(parser.parseString(n3String), "ns, bad parse loop=" + i);
         }
      }


      [TestMethod]
      public virtual void testPartitionedSpawn()
      {
         string fileNameIn = "partitionedSource.jdf";
         string fileNameOut = "partitionedSpawned.jdf";
         string spawnNodeID = "n0016";

         ArrayList vRWResources = new ArrayList();
         vRWResources.Add("Component");
         vRWResources.Add("RunList");

         JDFAttributeMap spawnPart = new JDFAttributeMap();
         VJDFAttributeMap vSpawnParts = new VJDFAttributeMap();
         // spawnPart.put("Class", "Intent");
         vSpawnParts.Add(spawnPart);

         string strSpawnID = spawn(fileNameIn, fileNameOut, spawnNodeID, vRWResources, vSpawnParts);
         unSpawn(fileNameIn, strSpawnID);
      }


      [TestMethod]
      public virtual void testPartitionedSpawnNI()
      {
         for (int i = 0; i < 2; i++)
         {
            JDFDoc d = new JDFDoc("JDF");
            JDFNode nRoot = d.getJDFRoot();
            nRoot.setType(EnumType.ProcessGroup);
            JDFNode n2 = nRoot.addJDFNode(EnumType.Buffer);
            JDFAttributeMap map = new JDFAttributeMap(EnumPartIDKey.SheetName, "s1");
            JDFNodeInfo ni = (JDFNodeInfo)n2.addResource(ElementName.NODEINFO, null, EnumUsage.Input, null, null, null, null);
            JDFBufferParams bp = (JDFBufferParams)n2.addResource(ElementName.BUFFERPARAMS, null, EnumUsage.Input, null, nRoot, null, null);
            bp.addPartition(EnumPartIDKey.SheetName, "s1");
            JDFComponent comp = (JDFComponent)n2.addResource(ElementName.COMPONENT, null, EnumUsage.Output, null, nRoot, null, null);
            comp.addPartition(EnumPartIDKey.SheetName, "s1");
            JDFSpawn spawn = new JDFSpawn(n2);
            spawn.vRWResources_in = new VString("Output NodeInfo", " ");
            spawn.vSpawnParts = new VJDFAttributeMap();
            spawn.vSpawnParts.Add(map);
            if (i == 0)
            {
               spawn.bFixResources = false;
            }
            JDFNode spawnedNode = spawn.spawn();
            Assert.IsTrue(ni.ToString().IndexOf(AttributeName.SPAWNIDS) > 0);
            JDFNodeInfo ni2 = spawnedNode.getNodeInfo();
            Assert.IsTrue(ni2.ToString().IndexOf(AttributeName.SPAWNIDS) > 0);
         }

      }


      [TestMethod]
      public virtual void testRef()
      {
         string fileNameIn = "ref.jdf";
         string fileNameOut = "spawn.jdf";
         string spawnNodeID = "n0027";

         ArrayList vRWResources = new ArrayList();
         vRWResources.Add("Media");
         vRWResources.Add("ExposedMedia");
         VJDFAttributeMap vSpawnParts = new VJDFAttributeMap();

         string strSpawnID = spawn(fileNameIn, fileNameOut, spawnNodeID, vRWResources, vSpawnParts);
         unSpawn(fileNameIn, strSpawnID);
      }


      [TestMethod]
      public virtual void testMergeJDF()
      {
         // job.jdf subjdf.jdf -o merged.jdf
         string m_xmlFile1 = "_bookintent.jdf";
         string m_xmlFile2 = "spawned.jdf";
         string m_outFile = "merged.jdf";
         JDFDoc m_jdfDoc;
         JDFDoc m_jdfDoc2;

         JDFParser p = new JDFParser();
         m_jdfDoc = p.parseFile(sm_dirTestDataTemp + m_xmlFile1);

         Assert.IsNotNull(m_jdfDoc, sm_dirTestDataTemp + m_xmlFile1 + ": Parse Error\n" + "MergeJDF: JDF merger simulation;\n" + "Arguments: 1=parent input JDF, 2=child input JDF;\n" + "-o: output JDF;\n" + "-d: delete completed tasks from the output JDF\n");

         JDFParser p2 = new JDFParser();
         m_jdfDoc2 = p2.parseFile(sm_dirTestDataTemp + m_xmlFile2);

         Assert.IsTrue(m_jdfDoc2 != null, sm_dirTestDataTemp + m_xmlFile2 + ": Parse Error");
         if (m_jdfDoc2 == null)
         {
            return; // soothe findbugs ;)
         }

         JDFNode rootMain = m_jdfDoc.getJDFRoot();
         JDFNode rootSpawn = m_jdfDoc2.getJDFRoot();
         rootSpawn.setDescriptiveName("fixup");
         string root2ID = rootSpawn.getID();
         JDFComment c2 = rootSpawn.appendComment();
         c2.setText("Comment 1");

         new JDFMerge(rootMain).mergeJDF(rootSpawn, sm_dirTestDataTemp + m_xmlFile2, JDFNode.EnumCleanUpMerge.None, JDFResource.EnumAmountMerge.None);
         JDFNode nodemerged = rootMain.getChildJDFNode(root2ID, false);
         Assert.IsTrue(nodemerged.getDescriptiveName().Equals("fixup"), "MergeJDF fixup");

         Assert.IsNull(m_jdfDoc.getRoot().getMultipleIDs("ID"));
         m_jdfDoc.write2File(sm_dirTestDataTemp + m_outFile, 2, true);

         Assert.IsTrue(true, "MergeJDF ok");
      }


      [TestMethod]
      public virtual void testCleanupMerge()
      {
         ArrayList l = (ArrayList) EnumCleanUpMerge.getEnumList();
         for (int i = 0; i < l.Count; i++)
         {
            JDFDoc doc = new JDFDoc("JDF");
            JDFNode node = doc.getJDFRoot();
            node.setType(EnumType.ProcessGroup);
            JDFNode n2 = node.addJDFNode(EnumType.AdhesiveBinding);
            JDFResource r = n2.addResource(ElementName.ADHESIVEBINDINGPARAMS, null, EnumUsage.Input, null, node, null, null);
            JDFSpawn sp = new JDFSpawn(n2);
            JDFNode spn = sp.spawn();
            JDFSpawned auditSpawn = (JDFSpawned)node.getAuditPool().getAudit(0, EnumAuditType.Spawned, null, null);
            Assert.IsNotNull(auditSpawn);
            Assert.IsTrue(auditSpawn.getrRefsROCopied().Contains(r.getID()));
            EnumCleanUpMerge cm = (EnumCleanUpMerge)l[i];
            new JDFMerge(node).mergeJDF(spn, null, cm, JDFResource.EnumAmountMerge.None);
            JDFSpawned auditSpawn2 = (JDFSpawned)node.getAuditPool().getAudit(0, EnumAuditType.Spawned, null, null);
            JDFMerged mergeSpawn2 = (JDFMerged)node.getAuditPool().getAudit(0, EnumAuditType.Merged, null, null);
            if (cm.Equals(EnumCleanUpMerge.None))
            {
               Assert.IsNotNull(auditSpawn2);
               Assert.IsTrue(auditSpawn2.getrRefsROCopied().Contains(r.getID()));
               Assert.AreEqual(auditSpawn, auditSpawn2);
               Assert.IsNotNull(mergeSpawn2);
               Assert.AreEqual(auditSpawn2.getrRefsRWCopied(), mergeSpawn2.getrRefsOverwritten());
            }
            else if (cm.Equals(EnumCleanUpMerge.RemoveRRefs))
            {
               Assert.IsNotNull(auditSpawn2);
               Assert.IsTrue(auditSpawn2.getrRefsROCopied().IsEmpty());
               Assert.AreEqual(auditSpawn, auditSpawn2);
               Assert.IsNotNull(mergeSpawn2);
               Assert.AreEqual(auditSpawn2.getrRefsRWCopied(), mergeSpawn2.getrRefsOverwritten());
            }
            else if (cm.Equals(EnumCleanUpMerge.RemoveAll))
            {
               Assert.IsNull(auditSpawn2);
               Assert.IsNull(mergeSpawn2);
            }
         }
      }

      // project folder must look to test.jdf
      [TestMethod]
      public virtual void testMergeJDF2()
      {
         JDFParser p = new JDFParser();
         JDFDoc mydoc = p.parseFile(sm_dirTestData + "testMergeJDF2.jdf");
         JDFNode root = (JDFNode)mydoc.getRoot();
         ArrayList rwResources = new ArrayList();

         JDFAttributeMap myMap = new JDFAttributeMap();

         myMap.put("Type", "Imposition");
         myMap.put("Status", "Waiting");

         VElement elemVec = root.getChildrenByTagName("JDF", JDFConstants.EMPTYSTRING, myMap, false, true, 0);
         JDFNode spawnnode = (JDFNode)elemVec[0];

         rwResources.Add("Output");
         JDFSpawn spawn = new JDFSpawn(spawnnode);

         spawnnode = spawn.spawn(sm_dirTestData + "testMergeJDF2.jdf", sm_dirTestDataTemp + "myTest_spawned.jdf", rwResources, null, false, false, false, false);

         Assert.IsTrue(mydoc.write2File(sm_dirTestDataTemp + "testMergeJDF2_spawned.jdf", 0, true));
         new JDFMerge(root).mergeJDF(spawnnode, JDFConstants.EMPTYSTRING, JDFNode.EnumCleanUpMerge.None, JDFResource.EnumAmountMerge.None);

         JDFResource myres = (JDFResource)root.getTarget("Res_Impos_Out_Run_1_3011", AttributeName.ID);
         Assert.IsTrue(myres.getAttribute("SpawnIDs", null, JDFConstants.EMPTYSTRING).Equals(JDFConstants.EMPTYSTRING), "Merged Resource contains SpawnID");

         Assert.IsTrue(mydoc.write2File(sm_dirTestDataTemp + "testMergeJDF2_merged.jdf", 0, true));
      }


      [TestMethod]
      public virtual void testMergeJDF3()
      {
         // job.jdf subjdf.jdf -o merged.jdf
         string m_xmlFile1 = "km111.jdf";
         string m_xmlFile2 = "Link76645060_000155km111Qua0.NSp76664048_000633_28_out.jdf";
         string m_outFile = "km111_merged.xml";
         JDFDoc m_jdfDoc;
         JDFDoc m_jdfDoc2;

         JDFParser p = new JDFParser();
         m_jdfDoc = p.parseFile(m_xmlFile1);

         JDFParser p2 = new JDFParser();
         m_jdfDoc2 = p2.parseFile(m_xmlFile2);

         if (m_jdfDoc2 == null)
         {
            return; // soothe findbugs ;)
         }

         JDFNode root = (JDFNode)m_jdfDoc.getRoot();
         JDFNode root2 = (JDFNode)m_jdfDoc2.getRoot();
         if (root == null)
         {
            return; // soothe findbugs ;)
         }

         new JDFMerge(root).mergeJDF(root2, m_xmlFile2, JDFNode.EnumCleanUpMerge.None, JDFResource.EnumAmountMerge.None);

         m_jdfDoc.write2File(sm_dirTestDataTemp + m_outFile, 2, true);
      }


      [TestInitialize]
      public override void setUp()
      {
         base.setUp();
         JDFElement.setLongID(false);
      }
   }
}
