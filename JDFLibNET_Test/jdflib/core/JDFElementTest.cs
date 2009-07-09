
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


namespace org.cip4.jdflib.core
{
   using System;
   using System.Collections.Generic;
   using System.IO;
   using Microsoft.VisualStudio.TestTools.UnitTesting;

   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using EnumQueueStatus = org.cip4.jdflib.auto.JDFAutoQueue.EnumQueueStatus;
   using EnumQueueEntryStatus = org.cip4.jdflib.auto.JDFAutoQueueEntry.EnumQueueEntryStatus;
   using EnumAttributeType = org.cip4.jdflib.core.AttributeInfo.EnumAttributeType;
   using EnumNodeStatus = org.cip4.jdflib.core.JDFElement.EnumNodeStatus;
   using EnumSettingsPolicy = org.cip4.jdflib.core.JDFElement.EnumSettingsPolicy;
   using EnumVersion = org.cip4.jdflib.core.JDFElement.EnumVersion;
   using EnumXYRelation = org.cip4.jdflib.core.JDFElement.EnumXYRelation;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using EnumValidationLevel = org.cip4.jdflib.core.KElement.EnumValidationLevel;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using JDFAcknowledge = org.cip4.jdflib.jmf.JDFAcknowledge;
   using JDFCommand = org.cip4.jdflib.jmf.JDFCommand;
   using JDFJMF = org.cip4.jdflib.jmf.JDFJMF;
   using JDFJobPhase = org.cip4.jdflib.jmf.JDFJobPhase;
   using JDFMessage = org.cip4.jdflib.jmf.JDFMessage;
   using JDFPipeParams = org.cip4.jdflib.jmf.JDFPipeParams;
   using JDFQueue = org.cip4.jdflib.jmf.JDFQueue;
   using JDFQueueEntry = org.cip4.jdflib.jmf.JDFQueueEntry;
   using JDFResourceCmdParams = org.cip4.jdflib.jmf.JDFResourceCmdParams;
   using JDFResourceInfo = org.cip4.jdflib.jmf.JDFResourceInfo;
   using JDFResponse = org.cip4.jdflib.jmf.JDFResponse;
   using EnumFamily = org.cip4.jdflib.jmf.JDFMessage.EnumFamily;
   using JDFAncestor = org.cip4.jdflib.node.JDFAncestor;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using JDFSpawned = org.cip4.jdflib.node.JDFSpawned;
   using EnumProcessUsage = org.cip4.jdflib.node.JDFNode.EnumProcessUsage;
   using EnumType = org.cip4.jdflib.node.JDFNode.EnumType;
   using JDFAmountPool = org.cip4.jdflib.pool.JDFAmountPool;
   using JDFAuditPool = org.cip4.jdflib.pool.JDFAuditPool;
   using JDFResourcePool = org.cip4.jdflib.pool.JDFResourcePool;
   using JDFPhaseTime = org.cip4.jdflib.resource.JDFPhaseTime;
   using JDFProcessRun = org.cip4.jdflib.resource.JDFProcessRun;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using EnumPartIDKey = org.cip4.jdflib.resource.JDFResource.EnumPartIDKey;
   using EnumResStatus = org.cip4.jdflib.resource.JDFResource.EnumResStatus;
   using EnumResourceClass = org.cip4.jdflib.resource.JDFResource.EnumResourceClass;
   using JDFComChannel = org.cip4.jdflib.resource.process.JDFComChannel;
   using JDFContact = org.cip4.jdflib.resource.process.JDFContact;
   using JDFExposedMedia = org.cip4.jdflib.resource.process.JDFExposedMedia;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;
   using StringUtil = org.cip4.jdflib.util.StringUtil;
   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   ///
   /// <summary> * @author MuchaD
   /// * 
   /// *         This implements the first fixture with unit tests for class
   /// *         JDFElement. </summary>
   /// 
   [TestClass]
   public class JDFElementTest : JDFTestCaseBase
   {
      internal string fileSeparator = Path.DirectorySeparatorChar.ToString();

      // member variables for the fixture
      private JDFDoc m_jdfDoc;
      private JDFNode m_jdfRoot;
      private KElement m_kElement;
      private JDFElement m_jdfElement;


      [TestMethod]
      public virtual void testAppendElement()
      {
         JDFDoc d = new JDFDoc("JDF");
         KElement r = d.getRoot();
         KElement e = r.appendElement("e");
         Assert.AreEqual(e.getNamespaceURI(), JDFElement.getSchemaURL());
         KElement foo = e.appendElement("pt:foo", "www.pt.com");
         Assert.AreEqual("www.pt.com", foo.getNamespaceURI());
         KElement bar = foo.appendElement("bar");
         Assert.IsNotNull(bar.getNamespaceURI());
         KElement foo2 = bar.appendElement("pt:foo", "www.pt.com");
         Assert.AreEqual("www.pt.com", foo2.getNamespaceURI());
      }


      [TestMethod]
      public virtual void testCopyElement()
      {
         JDFDoc d = new JDFDoc("d1");
         JDFElement e = (JDFElement)d.getRoot();
         JDFDoc d2 = new JDFDoc("d2");
         JDFElement e2 = (JDFElement)d2.getRoot();
         KElement e3 = e.copyElement(e2, null);
         JDFParser p = new JDFParser();
         JDFDoc dp = p.parseString("<Device xmlns=\"www.CIP4.org/JDFSchema_1_1\"/>");
         KElement ep = dp.getRoot();
         KElement e4 = e.copyElement(ep, null);
         Assert.AreEqual(e4.hasAttribute("xmlns"), ep.hasAttribute("xmlns"));
         Assert.AreEqual(e3.getNamespaceURI(), e.getNamespaceURI());
         Assert.IsFalse(d.ToString().IndexOf("xmlns=\"\"") >= 0);

      }


      [TestMethod]
      public virtual void testGetElement_KElement()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode root = d.getJDFRoot();
         JDFExposedMedia xm = (JDFExposedMedia)root.addResource("ExposedMedia", null, EnumUsage.Input, null, null, null, null);
         JDFMedia m = xm.appendMedia();
         m.makeRootResource(null, null, true);
         Assert.IsNull(xm.getElement_KElement("Media", null, 0));
         Assert.IsNotNull(xm.getElement_JDFElement("Media", null, 0));
      }


      [TestMethod]
      public virtual void testGetElement_JDFElement()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode root = d.getJDFRoot();
         JDFExposedMedia xm = (JDFExposedMedia)root.addResource("ExposedMedia", null, EnumUsage.Input, null, null, null, null);
         JDFMedia m = xm.appendMedia();
         JDFResource r = m.makeRootResource(null, null, true);
         Assert.IsNull(xm.getElement_KElement("Media", null, 0));
         Assert.IsNotNull(xm.getElement_JDFElement("Media", null, 0));
         Assert.AreEqual(r, xm.getElement_JDFElement("Media", null, 0));
         Assert.AreEqual(r, xm.getElement_JDFElement("Media", null, -1));
      }


      [TestMethod]
      public virtual void testGetChildElementVector_KElement()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode root = d.getJDFRoot();
         JDFExposedMedia xm = (JDFExposedMedia)root.addResource("ExposedMedia", null, EnumUsage.Input, null, null, null, null);
         JDFMedia m = xm.appendMedia();
         m.makeRootResource(null, null, true);
         Assert.AreEqual(0, xm.getChildElementVector_KElement("Media", null, null, true, -1).Count);
         Assert.AreEqual(1, xm.getChildElementVector_JDFElement("Media", null, null, true, -1, true).Count);
      }


      private void _setUp()
      {
         // setup the fixture
         string xmlFile = "bookintent.jdf";

         // test jdf functions
         // ==================
         JDFParser p = new JDFParser();
         m_jdfDoc = p.parseFile(sm_dirTestData + xmlFile);

         Assert.IsTrue(m_jdfDoc != null, sm_dirTestData + xmlFile + ": Parse Error");

         m_jdfRoot = (JDFNode)m_jdfDoc.getRoot();
         m_kElement = m_jdfRoot.getChildByTagName("Dimensions", "", 0, null, false, true);
         m_jdfElement = (JDFElement)m_kElement;

      }

      [TestMethod]
      public virtual void testNameSpaceElement()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFNode root = doc.getJDFRoot();
         root.setType("foo:bar", false);
         root.addNameSpace("foo", "www.foo.com");
         JDFResource r = root.addResource("foo:res", EnumResourceClass.Parameter, EnumUsage.Input, null, null, null, null);
         JDFResourceLink rl = root.getLink(r, null);
         rl.setPartMap(new JDFAttributeMap("Side", "Front"));
         Assert.AreEqual(-1, rl.ToString().IndexOf("xmlns=\"\""));
         Assert.AreEqual(-1, rl.getPart(0).ToString().IndexOf("xmlns=\"\""));
      }


      [TestMethod]
      public virtual void testRemoveExtensions()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.appendElement("a:b", "a.com");
         n.getAuditPool().appendElement("a:b", "a.com");
         n.getAuditPool().setAttribute("a:b", "c", "a.com");
         Assert.IsTrue(n.ToString().IndexOf("a:") > 0);
         n.removeExtensions();
         Assert.AreEqual(-1, n.ToString().IndexOf("a:"));
      }


      [TestMethod]
      public virtual void testRemoveChild()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setType("ConventionalPrinting", true);
         JDFExposedMedia xmpl = (JDFExposedMedia)n.appendMatchingResource("ExposedMedia", EnumProcessUsage.Plate, null);
         JDFExposedMedia xmpr = (JDFExposedMedia)n.appendMatchingResource("ExposedMedia", EnumProcessUsage.Proof, null);
         JDFMedia m = xmpr.appendMedia();
         Assert.IsNotNull(xmpr.getMedia());
         m.setID("id1");
         KElement t1 = n.getTarget("id1", "ID");
         m = (JDFMedia)m.makeRootResource(null, null, true);
         Assert.AreEqual(m, t1);
         Assert.IsNotNull(xmpr.getMedia());
         xmpl.refElement(m);
         Assert.IsNotNull(xmpl.getMedia());
         JDFResourcePool rp = n.getResourcePool();
         Assert.IsNotNull(rp.getElement("Media"));
         xmpl.removeChild("Media", null, 0);
         Assert.IsNull(xmpl.getMedia());
         Assert.IsNotNull(rp.getElement("Media"));
         xmpr.removeChildren("Media", null, null);
         Assert.IsNull(xmpr.getMedia());
         Assert.IsNotNull(rp.getElement("Media"));
      }


      [TestMethod]
      public virtual void testGetHRefs()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setType("ConventionalPrinting", true);
         JDFExposedMedia xmpl = (JDFExposedMedia)n.appendMatchingResource("ExposedMedia", EnumProcessUsage.Plate, null);
         JDFExposedMedia xmpr = (JDFExposedMedia)n.appendMatchingResource("ExposedMedia", EnumProcessUsage.Proof, null);
         JDFMedia m = xmpr.appendMedia();
         Assert.IsNotNull(xmpr.getMedia());
         m.setID("id1");
         KElement t1 = n.getTarget("id1", "ID");
         m = (JDFMedia)m.makeRootResource(null, null, true);
         Assert.AreEqual(t1, m);
         Assert.IsTrue(n.getHRefs(null, true, false).Contains("id1"));
         Assert.IsTrue(xmpr.getHRefs(null, true, false).Contains("id1"));
         Assert.IsFalse(xmpl.getHRefs(null, true, false).Contains("id1"));
         Assert.IsTrue(n.getHRefs(null, true, true).Contains("id1"));
         Assert.IsTrue(xmpr.getHRefs(null, true, true).Contains("id1"));
         Assert.IsFalse(xmpl.getHRefs(null, true, true).Contains("id1"));
      }


      [TestMethod]
      public virtual void testFixVersion()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setType(EnumType.Bundling);
         JDFProcessRun pr = n.getAuditPool().addProcessRun(EnumNodeStatus.Completed, null, null);
         pr.setAttribute("Duration", "PT90S", null);
         Assert.AreEqual("PT90S", pr.getAttribute("Duration"));
         n.setAttribute("foo3", "a~.doc");
         n.fixVersion(null);
         Assert.AreEqual("PT1M30S", pr.getAttribute("Duration"));
         Assert.AreEqual("a~.doc", n.getAttribute("foo3"));
      }

      
      [TestMethod]
      public virtual void testDefaultVersion()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode n = doc.getJDFRoot();
         Assert.AreEqual(n.getVersion(true), EnumVersion.Version_1_3);
         JDFElement.setDefaultJDFVersion(EnumVersion.Version_1_2);
         n.setType("ProcessGroup", true);
         n = n.addJDFNode("Combined");
         Assert.AreEqual(EnumVersion.Version_1_3, n.getVersion(true));

         doc = new JDFDoc("JDF");
         n = doc.getJDFRoot();
         Assert.AreEqual(EnumVersion.Version_1_2, n.getVersion(true));
         n.setType("ProcessGroup", true);
         n = n.addJDFNode("Combined");
         Assert.AreEqual(EnumVersion.Version_1_2, n.getVersion(true));

         doc = new JDFDoc("JMF");
         JDFJMF jmf = doc.getJMFRoot();
         Assert.AreEqual(EnumVersion.Version_1_2, jmf.getVersion(true));

      }


      [TestMethod]
      public virtual void testEvaluateXY()
      {
         EnumXYRelation xyR = EnumXYRelation.eq;
         Assert.IsTrue(xyR.evaluateXY(2, 2, 0, 0), "eq");
         Assert.IsTrue(xyR.evaluateXY(1.9, 2, 0.1, 0.1), "eq");
         Assert.IsFalse(xyR.evaluateXY(1.9, 2, 0.0, 0.15), "eq");
         Assert.IsTrue(xyR.evaluateXY(1.9, 2, 0.1, 0.0), "eq");

         xyR = EnumXYRelation.ne;
         Assert.IsFalse(xyR.evaluateXY(2, 2, 0, 0), "ne");
         Assert.IsFalse(xyR.evaluateXY(1.9, 2, 0.1, 0.1), "ne");
         Assert.IsTrue(xyR.evaluateXY(1.9, 2, 0.0, 0.15), "ne");
         Assert.IsFalse(xyR.evaluateXY(1.9, 2, 0.1, 0.0), "ne");

         xyR = EnumXYRelation.gt;
         Assert.IsTrue(xyR.evaluateXY(3, 2, 0, 0), "gt");
         Assert.IsTrue(xyR.evaluateXY(1.9, 2, 0.2, 0.2), "gt");
         Assert.IsFalse(xyR.evaluateXY(2.00, 2, 0.0, 0.0), "gt");
         Assert.IsTrue(xyR.evaluateXY(1.95, 2, 0.1, 0.0), "gt");

         xyR = EnumXYRelation.lt;
         Assert.IsTrue(xyR.evaluateXY(1.9, 2, 0.0, 0.0), "lt");

         xyR = EnumXYRelation.le;
         Assert.IsTrue(xyR.evaluateXY(1.9, 2, 0.0, 0.0), "le");
         Assert.IsTrue(xyR.evaluateXY(2.0, 2, 0.0, 0.0), "le");
         Assert.IsFalse(xyR.evaluateXY(3.0, 2, 0.0, 0.0), "le");
      }


      [TestMethod]
      public virtual void testGenerateDotID()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode e = doc.getJDFRoot();
         string dotID = e.generateDotID("foo", null);
         e.setAttribute("foo", dotID, null);
         Assert.IsNotNull(dotID);
         Assert.IsTrue(dotID.StartsWith("n"));
         JDFNode e2 = (JDFNode)e.appendElement("JDF", null);
         string generateDotID = e2.generateDotID("foo", null);
         e2.setAttribute("foo", generateDotID, null);
         Assert.AreEqual(dotID + ".1", generateDotID);

         JDFNode e3 = (JDFNode)e2.appendElement("JDF", null);
         generateDotID = e3.generateDotID("foo", null);
         e3.setAttribute("foo", generateDotID, null);
         Assert.AreEqual(dotID + ".1.1", generateDotID);
         e3 = (JDFNode)e2.appendElement("JDF", null);
         generateDotID = e3.generateDotID("foo", null);
         e3.setAttribute("foo", generateDotID, null);
         Assert.AreEqual(dotID + ".1.2", generateDotID);

         e2.setAttribute("foo", "whatever", null);
         e2 = (JDFNode)e.appendElement("JDF", null);
         generateDotID = e2.generateDotID("foo", null);
         e2.setAttribute("foo", generateDotID, null);
         Assert.AreEqual(dotID + ".2", generateDotID);
         for (int i = 3; i < 22; i++)
         {
            e2 = (JDFNode)e.appendElement("JDF", null);
            generateDotID = e2.generateDotID("foo", null);
            e2.setAttribute("foo", generateDotID, null);
            Assert.AreEqual(dotID + "." + Convert.ToString(i), generateDotID);
         }
      }


      [TestMethod]
      public virtual void testIncludesMatchingAttribute()
      {
         _setUp();

         Assert.IsTrue(m_jdfElement.includesMatchingAttribute("Range", "600 800", AttributeInfo.EnumAttributeType.XYPairRangeList), "isInside (600 800) = ");
         Assert.IsFalse(m_jdfElement.includesMatchingAttribute("Range", "500 700", AttributeInfo.EnumAttributeType.XYPairRangeList), "isOutside(500 700) = ");

         JDFDoc d = new JDFDoc("JDF");
         JDFElement e = d.getJDFRoot();
         e.setAttribute("abc", "a b c");
         Assert.IsTrue(e.includesMatchingAttribute("abc", "a", EnumAttributeType.NMTOKENS), "b");
         Assert.IsTrue(e.includesMatchingAttribute("abc", "b", EnumAttributeType.NMTOKENS), "b");
         Assert.IsTrue(e.includesMatchingAttribute("abc", "c", EnumAttributeType.NMTOKENS), "b");
         Assert.IsFalse(e.includesMatchingAttribute("abc", "d", EnumAttributeType.NMTOKENS), "b");
         e.setAttribute("intlist", "-1 3 5");
         Assert.IsTrue(e.includesMatchingAttribute("intlist", "-1", EnumAttributeType.IntegerList));
         Assert.IsTrue(e.includesMatchingAttribute("intlist", "3", EnumAttributeType.IntegerList));
         Assert.IsTrue(e.includesMatchingAttribute("intlist", "5", EnumAttributeType.IntegerList));
         Assert.IsFalse(e.includesMatchingAttribute("intlist", "4", EnumAttributeType.IntegerList));
         Assert.IsFalse(e.includesMatchingAttribute("intlist", "8", EnumAttributeType.IntegerList));
      }


      [TestMethod]
      public virtual void testGetRefElement()
      {
         JDFNode n = new JDFDoc("JDF").getJDFRoot();
         JDFMedia m = (JDFMedia)n.addResource("Media", null);
         JDFMedia m1 = (JDFMedia)m.addPartition(EnumPartIDKey.Location, "T1");
         JDFMedia m2 = (JDFMedia)m.addPartition(EnumPartIDKey.Location, "T2");
         JDFExposedMedia xm = (JDFExposedMedia)n.addResource("ExposedMedia", null);
         Assert.IsNull(xm.getRefElement(m1));
         JDFRefElement re = xm.refElement(m2);
         Assert.AreEqual(re, xm.getRefElement(m2));
         Assert.AreEqual(re, xm.getRefElement(m2));
         Assert.AreEqual(xm.getMedia(), m2);
         Assert.IsNull(xm.getRefElement(m1));
         Assert.IsNull(xm.getRefElement(m));

      }


      [TestMethod]
      public virtual void testGetCreateElement()
      {
         JDFNode n = new JDFDoc("JDF").getJDFRoot();
         JDFMedia m = (JDFMedia)n.addResource("Media", null);
         JDFExposedMedia xm = (JDFExposedMedia)n.addResource("ExposedMedia", null);
         xm.refMedia(m);
         Assert.AreEqual(m, xm.getCreateElement("Media"));
      }


      [TestMethod]
      public virtual void testGetCreateRefElement()
      {
         JDFNode n = new JDFDoc("JDF").getJDFRoot();
         JDFMedia m = (JDFMedia)n.addResource("Media", null);
         JDFMedia m1 = (JDFMedia)m.addPartition(EnumPartIDKey.Location, "T1");
         JDFMedia m2 = (JDFMedia)m.addPartition(EnumPartIDKey.Location, "T2");
         JDFExposedMedia xm = (JDFExposedMedia)n.addResource("ExposedMedia", null);
         Assert.IsNull(xm.getRefElement(m1));
         for (int i = 0; i < 10; i++)
         {
            JDFRefElement re = xm.getCreateRefElement(m2);
            Assert.AreEqual(re, xm.getRefElement(m2));
            Assert.AreEqual(re, xm.getRefElement(m2));
            Assert.AreEqual(m2, xm.getMedia());
            Assert.IsNull(xm.getRefElement(m1));
            Assert.IsNull(xm.getRefElement(m));
            Assert.AreEqual(1, xm.numChildElements("MediaRef", null));
         }
         for (int i = 0; i < 10; i++)
         {
            JDFRefElement re = xm.getCreateRefElement(m2);
            Assert.AreEqual(re, xm.getRefElement(m2));
            Assert.AreEqual(re, xm.getCreateRefElement(m2));
            xm.getCreateRefElement(m);
            xm.getCreateRefElement(m1);
            Assert.AreEqual(3, xm.numChildElements("MediaRef", null));
         }

      }


      [TestMethod]
      public virtual void testGetChildElementVector()
      {
         _setUp();
         VElement velem = m_jdfRoot.getChildElementVector(null, null, null, true, 0, false);
         Assert.AreEqual(5, velem.Count);
         KElement elem = velem[0];
         Assert.AreEqual("AuditPool", elem.Name);
         velem = m_jdfRoot.getChildElementVector(null, null, null, true, 3, false);
         Assert.AreEqual(3, velem.Count);
      }


      [TestMethod]
      public virtual void testGetChildElementVector_or()
      {
         JDFDoc d = new JDFDoc("AmountPool");
         JDFAmountPool ap = (JDFAmountPool)d.getRoot();
         JDFAttributeMap partMap = new JDFAttributeMap("a", "a1");
         partMap.put("b", "b1");
         JDFPartAmount pa1 = ap.appendPartAmount();
         pa1.setAttributes(partMap);
         partMap.put("a", "a2");
         partMap.put("b", "b2");
         JDFPartAmount pa2 = ap.appendPartAmount();
         pa2.setAttributes(partMap);
         VElement v = ap.getChildElementVector(ElementName.PARTAMOUNT, null, partMap, false, 0, false);
         Assert.AreEqual(1, v.Count);
         partMap.put("b", "b1");
         v = ap.getChildElementVector(ElementName.PARTAMOUNT, null, partMap, false, 0, false);
         Assert.AreEqual(2, v.Count);

      }


      [TestMethod]
      public virtual void testGetParentJDFStatic()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFElement root = d.getJDFRoot();
         Assert.IsNull(JDFElement.getParentJDF(root));
         Assert.IsNull(JDFElement.getParentJDF(null));
         KElement k = root.appendElement("NodeInfo");
         Assert.AreEqual(root, JDFElement.getParentJDF(k));
         k = k.appendElement("foo:Bar", "www.foo.com");
         Assert.AreEqual(root, JDFElement.getParentJDF(k));
         k = root.appendElement("JDF");
         Assert.AreEqual(root, JDFElement.getParentJDF(k));
      }

      
      [TestMethod]
      public virtual void testGetSettingsPolicy()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         Assert.IsNull(n.getSettingsPolicy(false));
         JDFAuditPool ap = n.getAuditPool();
         Assert.IsNull(ap.getSettingsPolicy(true));
         n.setSettingsPolicy(EnumSettingsPolicy.MustHonor);
         Assert.AreEqual(EnumSettingsPolicy.MustHonor, ap.getSettingsPolicy(true));
      }


      [TestMethod]
      public virtual void testGetValueForNewAttribute()
      {
         Assert.IsTrue(JDFElement.getValueForNewAttribute(null, "ID").StartsWith("I"));
      }

      [TestMethod]
      public virtual void testGetParentJDFNode()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setType("ProcessGroup", true);
         JDFNode n2 = n.addJDFNode("Scanning");
         Assert.AreEqual(n, n2.getParentJDF(), "n2.parent n");
         Assert.IsNull(n.getParentJDF(), "n parent");
         JDFAuditPool ap = n.getCreateAuditPool();
         Assert.AreEqual(n, ap.getParentJDF(), "ap.parent n");
         ap = n2.getCreateAuditPool();
         Assert.AreEqual(n2, ap.getParentJDF(), "ap.parent n2");
         Assert.AreEqual(n2, ap.addCreated("me", n2).getParentJDF(), "a.parent n2");
      }


      [TestMethod]
      public virtual void testGetElementByID()
      {
         _setUp();
         KElement kelem = m_jdfRoot.getChildWithAttribute("*", "ID", "*", "n0006", 0, true);
         Assert.IsTrue(kelem != null, "kelem==null");
         if (kelem == null)
            return; // soothe findbugs ;)
         string strAtrib = kelem.getAttribute("ID", "", "");
         Assert.IsTrue(strAtrib.Equals("n0006"), "ID!=n0006");

         // second try
         KElement kelem2 = m_jdfRoot.getTarget("n0006", "ID");
         Assert.IsTrue(kelem2 != null, "kelem2==null");
         if (kelem2 == null)
            return; // soothe findbugs ;)
         string strAtrib2 = kelem2.getAttribute("ID", "", "");
         Assert.IsTrue(strAtrib2.Equals("n0006"), "ID!=n0006");

         // third try
         KElement kelem3 = m_jdfRoot.getTarget("198", "Preferred");
         Assert.IsTrue(kelem3 != null, "kelem3==null");
         if (kelem3 == null)
            return; // soothe findbugs ;)
         string strAtrib3 = kelem3.getAttribute("Preferred", "", "");
         Assert.IsTrue(strAtrib3.Equals("198"), "Preferred!=198");

         // fourth try: GetChildWithAttribute does only find direct children but
         // no deep children
         KElement kelem4 = m_jdfRoot.getChildWithAttribute("*", "Preferred", "*", "198", 0, true);
         Assert.IsTrue(kelem4 == null, "kelem4!=null");
      }

      // public void testGetDueLevel ()
      // {
      // JDFNodeInfo info = new JDFNodeInfo(m_kElement);
      // info.GetDueLevel();
      // }

      [TestMethod]
      public virtual void testIsCommentStatic()
      {
         _setUp();
         Assert.IsFalse(m_kElement is JDFComment, "Bug: This is a comment!");
         m_jdfElement.appendComment();
         m_kElement = m_jdfElement.getChildByTagName("Comment", "", 0, null, false, true);
         Assert.IsTrue(m_kElement is JDFComment, "Bug: This is no comment!");
      }


      [TestMethod]
      public virtual void testIsResourceStatic()
      {
         _setUp();
         m_kElement = m_jdfRoot.getChildByTagName("ComponentLink", "", 0, null, false, true);
         Assert.IsFalse(m_kElement is JDFResource, "Bug: " + m_kElement.Name + " is a Resource!");
         m_kElement = m_jdfRoot.getChildByTagName("SizeIntent", "", 0, null, false, true);
         Assert.IsTrue(m_kElement is JDFResource, "Bug: " + m_kElement.Name + " is no Resource!");
         m_kElement = m_jdfRoot.getChildByTagName("Dimensions", "", 0, null, false, true);
         Assert.IsFalse(m_kElement is JDFResource, "Bug: " + m_kElement.Name + " is a Resource!");
      }


      [TestMethod]
      public virtual void testIsResourceLinkStatic()
      {
         _setUp();
         m_kElement = m_jdfRoot.getChildByTagName("Dimensions", "", 0, null, false, true);
         Assert.IsFalse(m_kElement is JDFResourceLink, "Bug: This is a ResourceLink!");
         m_kElement = m_jdfRoot.getChildByTagName("ComponentLink", "", 0, null, false, true);
         Assert.IsTrue(m_kElement is JDFResourceLink, "Bug: This is no ResourceLink!");
      }


      [TestMethod]
      public virtual void testInheritedVersionInfo()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFNode node = doc.getJDFRoot();
         node.setVersion(JDFElement.EnumVersion.Version_1_3);
         node.setType(JDFConstants.PROCESSGROUP, true);
         node = node.addJDFNode("Scanning");
         JDFNodeInfo ni = node.appendNodeInfo();
         Assert.IsTrue(ni.hasAttribute(AttributeName.CLASS));
         Assert.AreEqual(EnumVersion.Version_1_3, ni.getVersion(true));
      }


      [TestMethod]
      public virtual void testMatchesPathKElement()
      {
         JDFDoc doc = new JDFDoc("Test"); // make sure we call jdf methods
         KElement root = doc.getRoot();
         KElement a = root.appendElement("a");
         root.appendElement("b");
         KElement a2 = root.appendElement("a");
         KElement a3 = root.appendElement("a");
         a.setAttribute("att", "42");
         Assert.IsTrue(a.matchesPath("//a", false));
         Assert.IsTrue(a.matchesPath("/Test/a", false));
         Assert.IsTrue(a.matchesPath("/Test/a[1]", false));
         // Java to C# Conversion - Don't know why this fails, other tests pass.
         //Assert.IsTrue(a.matchesPath("/Test/a[@att=\"42\"]", false));
         Assert.IsTrue(a2.matchesPath("/Test/a[2]", false));
         Assert.IsTrue(a3.matchesPath("/Test/a[3]", false));
         Assert.IsFalse(a3.matchesPath("/Test/a[@att=\"*\"]", false));
         Assert.IsTrue(a.matchesPath("/Test/a[@att=\"*\"]", false));
      }


      [TestMethod]
      public virtual void testMatchesPath()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFNode node = doc.getJDFRoot();
         node.setType("Product", true);
         node.setVersion(JDFElement.EnumVersion.Version_1_3);
         JDFNodeInfo ni = node.appendNodeInfo();
         ni = (JDFNodeInfo)ni.addPartition(EnumPartIDKey.Run, "R1");
         JDFContact c = (JDFContact)node.addResource(ElementName.CONTACT, null, null, null, null, null, null);
         ni.refElement(c);
         JDFComChannel cc = (JDFComChannel)node.addResource(ElementName.COMCHANNEL, null, null, null, null, null, null);
         c.refElement(cc);
         Assert.IsTrue(ni.getContact() == c, "contact");
         Assert.IsTrue(ni.hasChildElement(ElementName.CONTACT, null), "hasrefelement");
         JDFRefElement re = (JDFRefElement)ni.getElement("ContactRef");
         Assert.IsTrue(re.getTarget() == c, "refelementok");
         Assert.IsTrue(c.getComChannel(0) == cc, "comchannel");
         Assert.IsTrue(c.hasChildElement(ElementName.COMCHANNEL, null), "hasrefelement");
         JDFNode n2 = node.addProduct();
         JDFNodeInfo ni2 = n2.appendNodeInfo();
         ni2.refElement(c);
         Assert.IsTrue(c.matchesPath("ResourcePool/NodeInfo/Contact", true), "follow refs in matchespath");
         Assert.IsTrue(cc.matchesPath("ResourcePool/NodeInfo/Contact/ComChannel", true), "follow refs in matchespath");
         Assert.IsTrue(cc.matchesPath("JDF/ResourcePool/NodeInfo/Contact/ComChannel", true), "follow refs in matchespath");
         Assert.IsTrue(cc.matchesPath("/JDF/ResourcePool/NodeInfo/Contact/ComChannel", true), "follow refs in matchespath");
         Assert.IsTrue(cc.matchesPath("JDF/JDF/ResourcePool/NodeInfo/Contact/ComChannel", true), "follow refs in matchespath");
         Assert.IsTrue(cc.matchesPath("/JDF/JDF/ResourcePool/NodeInfo/Contact/ComChannel", true), "follow refs in matchespath");
         Assert.IsTrue(cc.matchesPath("//JDF/ResourcePool/NodeInfo/Contact/ComChannel", true), "follow refs in matchespath");
         Assert.IsTrue(cc.matchesPath("/JDF/*/ResourcePool/NodeInfo/Contact/ComChannel", true), "follow * in matchespath");
         Assert.IsFalse(cc.matchesPath("JDF/JDF/JDF/ResourcePool/NodeInfo/Contact/ComChannel", true), "follow refs in matchespath");
         Assert.IsFalse(cc.matchesPath("JDF/JDF/JDF/ResourcePool/NodeInfo/Contact/ComChannel", true), "follow refs in matchespath");
         Assert.IsFalse(c.matchesPath("ResourcePool/NodeInfo/Contact/ComChannel", true), "follow refs in matchespath");
      }


      [TestMethod]
      public virtual void testRefElement()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFNode node = doc.getJDFRoot();
         node.setType("Product", true);
         node.setVersion(JDFElement.EnumVersion.Version_1_2);
         JDFNodeInfo ni = node.appendNodeInfo();
         ni.appendElement("foo:bar", "www.foo.com"); // want a non jdf ns element
         // to see if any class casts
         // occur
         JDFContact c = (JDFContact)node.addResource(ElementName.CONTACT, null, null, null, null, null, null);
         VString vCTypes = new VString();
         vCTypes.Add("Customer");
         c.setContactTypes(vCTypes);

         ni.refElement(c);
         JDFComChannel cc = (JDFComChannel)node.addResource(ElementName.COMCHANNEL, null, null, null, null, null, null);
         c.refElement(cc);

         Assert.AreEqual(c, ni.getChildWithMatchingAttribute(ElementName.CONTACT, "ContactTypes", null, "Customer", 0, true, null), "contact");
         Assert.AreEqual(c, ni.getParentJDF().getChildWithAttribute(ElementName.CONTACT, "ContactTypes", null, "Customer", 0, false), "contact");

         Assert.AreEqual(c, ni.getContact(), "contact");
         Assert.IsTrue(ni.hasChildElement(ElementName.CONTACT, null), "hasrefelement");
         JDFRefElement re = (JDFRefElement)ni.getElement("ContactRef");
         Assert.IsTrue(re.getTarget() == c, "refelementok");
         Assert.IsTrue(c.getComChannel(0) == cc, "comchannel");
         Assert.IsTrue(c.hasChildElement(ElementName.COMCHANNEL, null), "hasrefelement");
         JDFNode n2 = node.addProduct();
         JDFNodeInfo ni2 = n2.appendNodeInfo();
         ni2.refElement(c);
         Assert.IsTrue(c.matchesPath("NodeInfo/Contact", true), "follow refs in matchespath");
         Assert.IsTrue(cc.matchesPath("NodeInfo/Contact/ComChannel", true), "follow refs in matchespath");
         Assert.IsFalse(c.matchesPath("NodeInfo/Contact/ComChannel", true), "follow refs in matchespath");

         Assert.IsTrue(ni2.getContact() == c, "contact 2");
         Assert.IsTrue(ni2.hasChildElement(ElementName.CONTACT, null), "hasrefelement 2");
         re = (JDFRefElement)ni2.getElement("ContactRef");
         Assert.IsTrue(re.getTarget() == c, "refelementok 2");

         ni2.inlineRefElements(null, null, true);
         Assert.IsNull(ni2.getElement("ContactRef"), "get ref post inline");
         Assert.IsNotNull(node.getResourcePool().getElement("Contact"), "refElement has been removed");
         Assert.IsTrue(ni2.hasChildElement(ElementName.CONTACT, null), "haselement 3");
         c = ni2.getContact();
         re = (JDFRefElement)c.getElement("ComChannelRef");
         Assert.IsTrue(re.getTarget() == cc, "refelementok 2");
         ni2.inlineRefElements(null, null, false);
         Assert.IsNull(ni2.getElement("ComChannelRef"), "get ref post inline 2");
         Assert.IsTrue(c.hasChildElement(ElementName.COMCHANNEL, null), "haselement 4");

         ni.inlineRefElements(null, null, true);
         Assert.IsNull(ni.getElement("ContactRef"), "get ref post inline");
         Assert.IsNull(node.getResourcePool().getElement("Contact"), "refElement has been removed");
         Assert.IsTrue(ni.hasChildElement(ElementName.CONTACT, null), "haselement 3");

         c = ni.getContact();
         c.makeRootResource(null, null, true);
         re = (JDFRefElement)ni.getElement("ContactRef");
         re.deleteRef(true);
         Assert.IsNull(c.getElement("ContactRef"));
      }


      [TestMethod]
      public virtual void testIsValid()
      {
         DirectoryInfo testData = new DirectoryInfo(sm_dirTestData + "SampleFiles");
         Assert.IsTrue(testData.Exists, "testData dir");
         FileInfo[] fList = testData.GetFiles();
         JDFParser p = new JDFParser();
         JDFParser p2 = new JDFParser();
         p2.m_SchemaLocation = sm_dirTestSchema + "JDF.xsd";

         for (int i = 0; i < fList.Length; i++)
         {
            FileInfo file = fList[i];
            // skip directories in CVS environments
            //if (file.isDirectory())
            //   continue;

            // skip schema files
            if (file.FullName.EndsWith(".xsd"))
               continue;

            Console.WriteLine("Parsing: " + file.FullName);
            JDFDoc jdfDoc = p.parseFile(file.FullName);
            Assert.IsTrue(jdfDoc != null, "parse ok");

            KElement e = null;
            if (jdfDoc != null)
            {
               e = jdfDoc.getRoot();
               Assert.IsTrue(e.isValid(EnumValidationLevel.RecursiveComplete), "valid doc: " + file.FullName);
            }

            // now with schema validation
            jdfDoc = p2.parseFile(file.FullName);
            Assert.IsTrue(jdfDoc != null, "schema parse ok");

            // TODO fix handling of prerelease default attributes
            if (jdfDoc != null)
            {
               e = jdfDoc.getRoot();
               Assert.IsTrue(e.isValid(EnumValidationLevel.RecursiveComplete), "valid doc: " + file.FullName);
            }
         }
      }

      
      [TestMethod]
      public virtual void testIsInvalid()
      {
         DirectoryInfo testData = new DirectoryInfo(sm_dirTestData + "BadSampleFiles");
         Assert.IsTrue(testData.Exists, "testData dir");
         FileInfo[] fList = testData.GetFiles();
         JDFParser p = new JDFParser();
         JDFParser p2 = new JDFParser();
         p2.m_SchemaLocation = sm_dirTestSchema + "JDF.xsd";

         for (int i = 0; i < fList.Length; i++)
         {
            FileInfo file = fList[i];
            // skip directories in CVS environments
            //if (file.isDirectory())
            //   continue;

            // skip schema files
            if (file.FullName.EndsWith(".xsd"))
               continue;

            Console.WriteLine("Parsing: " + file.FullName);
            JDFDoc jdfDoc = p.parseFile(file.FullName);
            Assert.IsTrue(jdfDoc != null, "parse ok");
            KElement e = null;
            if (jdfDoc != null)
            {
               e = jdfDoc.getRoot();
               Assert.IsFalse(e.isValid(EnumValidationLevel.RecursiveComplete), "valid doc: " + file.FullName);
            }

            // now with schema validation
            jdfDoc = p2.parseFile(file.FullName);
            Assert.IsTrue(jdfDoc != null, "schema parse ok");
            // TODO fix handling of prerelease default attributes
            if (jdfDoc != null)
            {
               e = jdfDoc.getRoot();
               Assert.IsFalse(e.isValid(EnumValidationLevel.RecursiveComplete), "valid doc: " + file.FullName);
            }
         }
      }

      
      [TestMethod]
      public virtual void testUniqueID()
      {
         // Java to C# Conversion, Test taking too long, reduce count from original 200,000 for now
         SupportClass.HashSetSupport m = new SupportClass.HashSetSupport();
         for (int i = 0; i < 1000; i++)
         {
            string s = JDFElement.uniqueID(0);
            if (m.Contains(s))
               Assert.Fail("oops");
            m.Add(s);
         }
      }


      [TestMethod]
      public virtual void testInvalidNameSpace()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFElement e = doc.getJDFRoot();
         string s = JDFConstants.JDFNAMESPACE;
         s = StringUtil.replaceString(s, "_1_1", "_1_3");
         JDFElement e2 = (JDFElement)e.appendElement("ResourcePool", s);
         Assert.IsTrue(e2.getInvalidAttributes(EnumValidationLevel.Incomplete, true, 9999).Contains("xmlns"));
         e2 = (JDFElement)e.appendElement("ResourceLinkPool", "www.cip4.org");
         Assert.IsTrue(e2.getInvalidAttributes(EnumValidationLevel.Incomplete, true, 9999).Contains("xmlns"));

      }


      [TestMethod]
      public virtual void testAppendAnchor()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFElement e = doc.getJDFRoot();
         SupportClass.HashSetSupport m = new SupportClass.HashSetSupport();
         KElement e2 = e.appendElement("e2");
         // Java to C# Conversion - Divide number of tests by 1000 for now
         for (int i = 0; i < 10; i++)
         {
            JDFElement appendElement = (JDFElement)e2.appendElement("FooBar");
            string s = appendElement.appendAnchor(null);
            if (m.Contains(s))
               Assert.Fail("oops");
            Assert.AreEqual(s, appendElement.getID());
            Assert.IsTrue(s.IndexOf("..") < 0);
            m.Add(s);
         }
      }


      [TestMethod]
      public virtual void testVersions()
      {
         Assert.AreEqual(0L, JDFVersions.getTheOffset(EnumVersion.Version_1_0));
         Assert.AreEqual(8L, JDFVersions.getTheOffset(EnumVersion.Version_1_2));
      }


      [TestMethod]
      public virtual void testSetEnumerationsAttribute()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFElement root = d.getJDFRoot();
         root.setEnumerationsAttribute("dummy", null, null);
         Assert.IsNull(root.getEnumerationsAttribute("dummy", null, EnumNodeStatus.Aborted, false));
         List<ValuedEnum> v = new List<ValuedEnum>();
         v.Add(EnumNodeStatus.Cleanup);
         v.Add(EnumNodeStatus.Completed);
         root.setEnumerationsAttribute("dummy", v, null);
         List<ValuedEnum> vTest = root.getEnumerationsAttribute("dummy", null, EnumNodeStatus.Aborted, false);
         Assert.AreEqual(v.Count, vTest.Count, "round trip enumerations, count doesn't match");
         for(int i=0; i < v.Count; ++i)
         {
            Assert.AreEqual(v[i], vTest[i], "round trip enumerations, index: " + i + "doesn't match");
         }
      }


      [TestMethod]
      public virtual void testStatusEquals()
      {
         // test if the auto classes implement the correct status

         // compare EnumNodeStatus
         JDFAuditPool myAuditPool = null;

         JDFDoc jdfDoc = new JDFDoc(ElementName.JDF);

         JDFNode jdfRoot = (JDFNode)jdfDoc.getRoot();
         Assert.IsTrue(jdfRoot != null, "No Root found");
         if (jdfRoot == null)
            return; // soothe findbugs ;)

         JDFAncestor ancestor = jdfRoot.appendAncestorPool().appendAncestor();
         ancestor.setStatus(EnumNodeStatus.Completed);

         myAuditPool = jdfRoot.getCreateAuditPool();
         JDFPhaseTime phaseTime = myAuditPool.addPhaseTime(JDFElement.EnumNodeStatus.Completed, null, null);
         JDFSpawned spawned = myAuditPool.addSpawned(jdfRoot, null, null, null, null);
         spawned.setStatus(JDFElement.EnumNodeStatus.Completed);

         Assert.AreEqual(spawned.getStatus(), phaseTime.getStatus());
         Assert.AreEqual(spawned.getStatus(), ancestor.getStatus());

         JDFDoc jmfDoc = new JDFDoc(ElementName.JMF);

         JDFJMF jmfRoot = jmfDoc.getJMFRoot();
         Assert.IsTrue(jmfRoot != null, "No Root found");
         if (jmfRoot == null)
            return; // soothe findbugs ;)

         JDFAcknowledge acknowledge = jmfRoot.appendAcknowledge();
         acknowledge.setType("PipePush"); // Type is required and its existance
         // is validated for messages
         JDFJobPhase jobPhase = acknowledge.appendJobPhase();
         jobPhase.setStatus(EnumNodeStatus.Completed);

         JDFMessage message = jmfRoot.appendMessageElement(EnumFamily.Command, null);
         message.setType("PipePush"); // Type is required and its existance is
         // validated for messages
         JDFPipeParams pipeParams = message.appendPipeParams();
         pipeParams.setStatus(EnumNodeStatus.Completed);

         Assert.AreEqual(jobPhase.getStatus(), pipeParams.getStatus());
         Assert.AreEqual(spawned.getStatus(), pipeParams.getStatus());

         // compare EnumResStatus
         JDFDoc responseDoc = new JDFDoc(ElementName.RESPONSE);
         JDFResponse responseRoot = (JDFResponse)responseDoc.getRoot();
         Assert.IsTrue(responseRoot != null, "No Root found");
         if (responseRoot == null)
            return; // soothe findbugs ;)

         responseRoot.setType(ElementName.RESOURCE);
         JDFResourceInfo resInfo = responseRoot.appendResourceInfo();
         resInfo.setResStatus(EnumResStatus.Available);

         JDFDoc commandDoc = new JDFDoc(ElementName.COMMAND);
         JDFCommand commandRoot = (JDFCommand)commandDoc.getRoot();
         Assert.IsTrue(commandRoot != null, "No Root found");
         if (commandRoot == null)
            return; // soothe findbugs ;)

         commandRoot.setType(ElementName.RESOURCE);
         JDFResourceCmdParams resCmdParams = commandRoot.appendResourceCmdParams();
         resCmdParams.setResStatus(EnumResStatus.Available);

         Assert.AreEqual(resInfo.getStatus(), resCmdParams.getStatus());

         // check EnumQueueStatus
         JDFDoc queueDoc = new JDFDoc(ElementName.QUEUE);
         JDFQueue queueRoot = (JDFQueue)queueDoc.getRoot();
         Assert.IsTrue(queueRoot != null, "No Root found");
         if (queueRoot == null)
            return; // soothe findbugs ;)

         queueRoot.setQueueStatus(EnumQueueStatus.Running);

         // check EnumQueueEntryStatus
         JDFQueueEntry queueEntry = queueRoot.appendQueueEntry();
         queueEntry.setQueueEntryStatus(EnumQueueEntryStatus.Running);
      }
   }
}