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



namespace org.cip4.jdflib.node
{
   using System;
   using System.Collections;
   using System.Collections.Generic;
   using System.Threading;
   using Microsoft.VisualStudio.TestTools.UnitTesting;


   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using EnumComponentType = org.cip4.jdflib.auto.JDFAutoComponent.EnumComponentType;
   using EnumDeviceStatus = org.cip4.jdflib.auto.JDFAutoDeviceInfo.EnumDeviceStatus;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFCustomerInfo = org.cip4.jdflib.core.JDFCustomerInfo;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFNodeInfo = org.cip4.jdflib.core.JDFNodeInfo;
   using JDFParser = org.cip4.jdflib.core.JDFParser;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using XMLDoc = org.cip4.jdflib.core.XMLDoc;
   using EnumAuditType = org.cip4.jdflib.core.JDFAudit.EnumAuditType;
   using EnumNodeStatus = org.cip4.jdflib.core.JDFElement.EnumNodeStatus;
   using EnumVersion = org.cip4.jdflib.core.JDFElement.EnumVersion;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using EnumValidationLevel = org.cip4.jdflib.core.KElement.EnumValidationLevel;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using JDFIntegerList = org.cip4.jdflib.datatypes.JDFIntegerList;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using JDFJMF = org.cip4.jdflib.jmf.JDFJMF;
   using EnumActivation = org.cip4.jdflib.node.JDFNode.EnumActivation;
   using EnumCleanUpMerge = org.cip4.jdflib.node.JDFNode.EnumCleanUpMerge;
   using EnumProcessUsage = org.cip4.jdflib.node.JDFNode.EnumProcessUsage;
   using EnumType = org.cip4.jdflib.node.JDFNode.EnumType;
   using NodeIdentifier = org.cip4.jdflib.node.JDFNode.NodeIdentifier;
   using JDFAncestorPool = org.cip4.jdflib.pool.JDFAncestorPool;
   using JDFAuditPool = org.cip4.jdflib.pool.JDFAuditPool;
   using JDFResourceLinkPool = org.cip4.jdflib.pool.JDFResourceLinkPool;
   using JDFResourcePool = org.cip4.jdflib.pool.JDFResourcePool;
   using JDFDevice = org.cip4.jdflib.resource.JDFDevice;
   using JDFPhaseTime = org.cip4.jdflib.resource.JDFPhaseTime;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFResourceAudit = org.cip4.jdflib.resource.JDFResourceAudit;
   using EnumAmountMerge = org.cip4.jdflib.resource.JDFResource.EnumAmountMerge;
   using EnumPartIDKey = org.cip4.jdflib.resource.JDFResource.EnumPartIDKey;
   using EnumPartUsage = org.cip4.jdflib.resource.JDFResource.EnumPartUsage;
   using EnumResStatus = org.cip4.jdflib.resource.JDFResource.EnumResStatus;
   using EnumResourceClass = org.cip4.jdflib.resource.JDFResource.EnumResourceClass;
   using JDFModule = org.cip4.jdflib.resource.devicecapability.JDFModule;
   using JDFComponent = org.cip4.jdflib.resource.process.JDFComponent;
   using JDFContact = org.cip4.jdflib.resource.process.JDFContact;
   using JDFConventionalPrintingParams = org.cip4.jdflib.resource.process.JDFConventionalPrintingParams;
   using JDFEmployee = org.cip4.jdflib.resource.process.JDFEmployee;
   using JDFExposedMedia = org.cip4.jdflib.resource.process.JDFExposedMedia;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;
   using JDFRunList = org.cip4.jdflib.resource.process.JDFRunList;
   using JDFDate = org.cip4.jdflib.util.JDFDate;
   using JDFMerge = org.cip4.jdflib.util.JDFMerge;
   using JDFSpawn = org.cip4.jdflib.util.JDFSpawn;
   using StatusCounter = org.cip4.jdflib.util.StatusCounter;
   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   ///
   /// <summary> * @author Rainer Prosi, Heidelberger Druckmaschinen
   /// * </summary>
   /// 
   [TestClass]
   public class JDFNodeTest : JDFTestCaseBase
   {

      ///   
      ///	 <summary> * performance test </summary>
      ///	 
      [TestMethod]
      public virtual void testBigSortChildren()
      {
         const string strJDFName = "000023_Test_PR3.0.jdf";
         JDFParser p = new JDFParser();
         JDFDoc d = p.parseFile(sm_dirTestData + strJDFName);
         JDFNode n = d.getJDFRoot();
         n.sortChildren();
      }


      [TestMethod]
      public virtual void testGetPredecessors()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setType(EnumType.ProcessGroup);
         JDFNode n2 = n.addJDFNode("ImageSetting");
         JDFResource r = n2.addResource("ExposedMedia", null, EnumUsage.Output, null, n, null, null);
         JDFNode n3 = n.addJDFNode("ConventionalPrinting");
         n3.linkResource(r, EnumUsage.Input, null);
         Assert.IsTrue(n3.getPredecessors(true, true).Contains(n2));
         Assert.IsTrue(n3.getPredecessors(true, false).Contains(n2));
         Assert.IsTrue(n2.getPredecessors(false, true).Contains(n3));
         Assert.IsTrue(n2.getPredecessors(false, false).Contains(n3));
         n3.linkResource(r, EnumUsage.Output, null);
         // used to dead loop here after in=out...
         n3.getPredecessors(false, true);
         n3.getPredecessors(true, true);
      }


      [TestMethod]
      public virtual void testGetRefPartition()
      {
         JDFDoc jdfDoc = JDFDoc.parseFile(sm_dirTestData + "GetReferencedPartition.jdf");
         JDFNode nodeProc = jdfDoc.getJDFRoot().getJobPart("1008.C", null);
         JDFResourceLinkPool linkPool = nodeProc.getResourceLinkPool();
         JDFResourceLink link = linkPool.getPoolChild(0, "ExposedMediaLink", null, null);
         VJDFAttributeMap vam = nodeProc.getExecutablePartitions(link, JDFResource.EnumResStatus.Draft, true);
         Assert.IsTrue(vam.Count == 5);

         // VJDFAttributeMap:
         // [0]JDFAttributeMap: { (Side = Front) (SheetName = 002_Text-1)
         // (SignatureName = SIG2) (Separation = Cyan) }
         // [1]JDFAttributeMap: { (Side = Front) (SheetName = 002_Text-1)
         // (SignatureName = SIG2) (Separation = Magenta) }
         // [2]JDFAttributeMap: { (Side = Front) (SheetName = 002_Text-1)
         // (SignatureName = SIG2) (Separation = Yellow) }
         // [3]JDFAttributeMap: { (Side = Front) (SheetName = 002_Text-1)
         // (SignatureName = SIG2) (Separation = Black) }
         // [4]JDFAttributeMap: { (Side = Front) (SheetName = 002_Text-1)
         // (SignatureName = SIG2) }
      }


      [TestMethod]
      public virtual void testSortChildren()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setType(EnumType.ProcessGroup);
         JDFResourcePool rp = n.appendResourcePool();
         KElement m2 = rp.appendElement("Media");
         m2.setAttribute("ID", "m2");
         KElement xm = rp.appendElement("ExposedMedia");
         xm.setAttribute("ID", "xm2");
         KElement m1 = rp.appendElement("Media");
         m1.setAttribute("ID", "m1");
         JDFNode n2 = n.addJDFNode("foo");
         n2.setID("n2");
         JDFNode n1 = n.addJDFNode("foo");
         n1.setID("n1");
         JDFResourcePool rp2 = n2.appendResourcePool();
         KElement m22 = rp2.appendElement("Media");
         m22.setAttribute("ID", "m2");
         KElement xm2 = rp2.appendElement("ExposedMedia");
         xm2.setAttribute("ID", "xm2");
         KElement m21 = rp2.appendElement("Media");
         m21.setAttribute("ID", "m1");

         n.sortChildren();
         Assert.AreEqual(n.getChildWithAttribute("JDF", "ID", null, "n2", 0, true), n.getChildWithAttribute("JDF", "ID", null, "n1", 0, true).getNextSiblingElement(null, null), "reordered sub elements");

         Assert.AreEqual(xm2, rp2.getFirstChildElement());
         Assert.AreEqual(m21, xm2.getNextSiblingElement());
         Assert.AreEqual(m22, m21.getNextSiblingElement());
      }


      [TestMethod]
      public virtual void testSetType()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         Assert.IsTrue(n.setType(JDFNode.EnumType.ConventionalPrinting.getName(), true), "good Type");
         Assert.AreEqual(JDFNode.EnumType.ConventionalPrinting.getName(), n.getXSIType(), "xsiType");
         try
         {
            n.setType("badTypeName", true);
            Assert.Fail("bad type");
         }
         catch (JDFException e)
         {
            Assert.IsNotNull(e, "bad type");
         }
         n.setType("foo:bar", false);
         Assert.AreEqual("foo:bar", n.getType());
         Assert.IsNull(n.getXSIType());
         VString types = new VString("Interpreting Rendering", " ");
         n.setCombined(types);
         Assert.AreEqual(types, n.getTypes());
         n.setType(EnumType.ContactCopying);
         Assert.IsNull(n.getAttribute("Types", null, null));
      }


      [TestMethod]
      public virtual void testSetEnum()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         Assert.IsTrue(n.setType(JDFNode.EnumType.ConventionalPrinting.getName(), true), "good Type");
         Assert.AreEqual(n.getXSIType(), JDFNode.EnumType.ConventionalPrinting.getName(), "xsiType");
         try
         {
            n.setType("badTypeName", true);
            Assert.Fail("bad type");
         }
         catch (JDFException e)
         {
            Assert.IsNotNull(e, "bad type");
         }
         n.setType("foo:bar", false);
         Assert.AreEqual("foo:bar", n.getType());
         Assert.IsNull(n.getXSIType());
      }


      [TestMethod]
      public virtual void testLinkResourceNS()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         JDFResource rl = n.addResource("NS:RunList", EnumResourceClass.Parameter, null, null, null, "www.ns.com", null);
         Assert.AreEqual("www.ns.com", rl.getNamespaceURI(), "res ns");
         JDFResourceLink rll = n.linkResource(rl, EnumUsage.Input, null);
         Assert.AreEqual("www.ns.com", rll.getNamespaceURI(), "res ns");
         Assert.IsFalse(rll.hasAttribute(AttributeName.COMBINEDPROCESSINDEX));
      }


      [TestMethod]
      public virtual void testEnsureLink()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         JDFResource rl = n.addResource("RunList", null);
         JDFResourceLink rl2 = n.ensureLink(rl, EnumUsage.Input, null);
         Assert.IsNotNull(rl2);
         Assert.AreEqual(n.ensureLink(rl, EnumUsage.Input, null), rl2);
      }

      ///   
      ///	 <summary> * test whether combinedprocessIndex is automagically and correctly assigned
      ///	 *  </summary>
      ///	 
      [TestMethod]
      public virtual void testInsertTypeInTypes()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setType(EnumType.Combined);
         n.insertTypeInTypes(EnumType.Combine, 999);
         Assert.AreEqual("Combine", n.getAttribute("Types"));
         n.insertTypeInTypes(EnumType.Imposition, 999);
         Assert.AreEqual("Combine Imposition", n.getAttribute("Types"));
         n.insertTypeInTypes(EnumType.Stripping, 1);
         Assert.AreEqual("Combine Stripping Imposition", n.getAttribute("Types"));
         n.insertTypeInTypes(EnumType.DigitalDelivery, 0);
         Assert.AreEqual("DigitalDelivery Combine Stripping Imposition", n.getAttribute("Types"));
         n.insertTypeInTypes(EnumType.Imposition, 99999);
         Assert.AreEqual("DigitalDelivery Combine Stripping Imposition Imposition", n.getAttribute("Types"));
      }

      ///   
      ///	 <summary> * test whether combinedprocessIndex is automagically and correctly assigned
      ///	 *  </summary>
      ///	 
      [TestMethod]
      public virtual void testLinkNamesCombined()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setCombined(new VString("Interpreting Trapping Rendering", " "));
         VString e = n.linkNames();
         Assert.IsTrue(e.Contains(ElementName.CUSTOMERINFO));
         Assert.IsTrue(e.Contains(ElementName.RENDERINGPARAMS));
      }

      ///   
      ///	 <summary> * test whether combinedprocessIndex is automagically and correctly assigned
      ///	 *  </summary>
      ///	 
      [TestMethod]
      public virtual void testLinkNamesProduct()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setType(EnumType.Product);
         VString e = n.linkNames();
         Assert.IsTrue(e.Contains(ElementName.CUSTOMERINFO));
         Assert.IsTrue(e.Contains(ElementName.MEDIAINTENT));
         Assert.IsTrue(e.Contains(ElementName.COMPONENT));
      }

      ///   
      ///	 <summary> * test whether combinedprocessIndex is automagically and correctly assigned
      ///	 *  </summary>
      ///	 
      [TestMethod]
      public virtual void testLinkResourceSimple()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setType(EnumType.Folding);
         JDFResource foPa = n.addResource(ElementName.FOLDINGPARAMS, null, EnumUsage.Input, null, null, null, null);
         JDFResourceLink rlfoPa = n.getLink(foPa, null);
         Assert.IsFalse(rlfoPa.hasAttribute(AttributeName.COMBINEDPROCESSINDEX));
      }

      ///   
      ///	 <summary> * test whether combinedprocessIndex is automagically and correctly assigned
      ///	 *  </summary>
      ///	 
      [TestMethod]
      public virtual void testLinkOutput()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setType(EnumType.ProcessGroup);
         JDFNode n1 = n.addJDFNode(EnumType.Interpreting);
         JDFRunList rul1 = (JDFRunList)n1.addResource("RunList", EnumUsage.Output);
         JDFNode n2 = n.addJDFNode(EnumType.Rendering);
         n2.linkOutputs(n1);
         Assert.AreEqual(rul1, n2.getResource("RunList", EnumUsage.Input, 0));
         n2.linkOutputs(n1);
         Assert.AreEqual(rul1, n2.getResource("RunList", EnumUsage.Input, 0));
         Assert.IsNull(n2.getResource("RunList", null, 1));
      }

      ///   
      ///	 <summary> * test whether combinedprocessIndex is automagically and correctly assigned
      ///	 *  </summary>
      ///	 
      [TestMethod]
      public virtual void testLinkResourceCombined()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setType(EnumType.Combined);
         VString v = new VString("Folding Cutting Foo:Bar Folding", " ");
         n.setTypes(v);
         JDFResource foPa = n.addResource(ElementName.FOLDINGPARAMS, null, EnumUsage.Input, null, null, null, null);
         JDFResourceLink rlfoPa = n.getLink(foPa, null);
         Assert.AreEqual("0 3", rlfoPa.getCombinedProcessIndex().ToString(), "folding is 0 and 2");

         JDFResource cuPa = n.addResource(ElementName.CUTTINGPARAMS, null, null, null, null, null, null);
         JDFResourceLink rlCuPa = n.linkResource(cuPa, EnumUsage.Input, null);
         Assert.AreEqual("1", rlCuPa.getCombinedProcessIndex().ToString(), "cutting is 1");

         JDFResource pePa = n.addResource(ElementName.PERFORATINGPARAMS, null, null, null, null, null, null);
         JDFResourceLink rlPePa = n.linkResource(pePa, EnumUsage.Input, null);
         Assert.IsNull(rlPePa.getCombinedProcessIndex(), "no perforating");

         n.insertTypeInTypes(EnumType.AdhesiveBinding, 999);
         Assert.AreEqual("0 3", rlfoPa.getCombinedProcessIndex().ToString(), "folding is 0 and 2");
         Assert.AreEqual("1", rlCuPa.getCombinedProcessIndex().ToString(), "cutting is 1");
         v = n.getTypes();
         Assert.AreEqual(EnumType.AdhesiveBinding.getName(), v[4], "appended one type");
         Assert.AreEqual(5, v.Count, "appended one type");

         n.insertTypeInTypes(EnumType.Bundling, -2);
         Assert.AreEqual("0 4", rlfoPa.getCombinedProcessIndex().ToString(), "folding is 0 and 3");
         Assert.AreEqual("1", rlCuPa.getCombinedProcessIndex().ToString(), "cutting is 1");
         v = n.getTypes();
         Assert.AreEqual(EnumType.Bundling.getName(), v[3], "appended one type");
         Assert.AreEqual(6, v.Count, "appended one type");

         n.insertTypeInTypes(EnumType.BoxPacking, 0);
         Assert.AreEqual("1 5", rlfoPa.getCombinedProcessIndex().ToString(), "folding is 1 and 5");
         Assert.AreEqual("2", rlCuPa.getCombinedProcessIndex().ToString(), "cutting is 2");
         v = n.getTypes();
         Assert.AreEqual(EnumType.BoxPacking.getName(), v[0], "appended one type");
         Assert.AreEqual(EnumType.Folding.getName(), v[1], "appended one type");
         Assert.AreEqual(7, v.Count, "appended one type");

         JDFResource comp = n.addResource(ElementName.COMPONENT, null, null, null, null, null, null);
         JDFResourceLink rlcomp = n.linkResource(comp, EnumUsage.Output, null);
         Assert.AreEqual(new JDFIntegerList("2 6"), rlcomp.getCombinedProcessIndex(), "cpi output");

         JDFResource compIn = n.addResource(ElementName.COMPONENT, null, null, null, null, null, null);
         JDFResourceLink rlcompIn = n.linkResource(compIn, EnumUsage.Input, null);
         Assert.AreEqual(new JDFIntegerList("0 4"), rlcompIn.getCombinedProcessIndex(), "cpi output");

         JDFResource devIn = n.addResource(ElementName.DEVICE, null, null, null, null, null, null);
         JDFResourceLink rlDevIn = n.linkResource(devIn, EnumUsage.Input, null);
         Assert.IsNull(rlDevIn.getCombinedProcessIndex(), "dev input");

         JDFResource niIn = n.addResource(ElementName.NODEINFO, null, null, null, null, null, null);
         JDFResourceLink rlNiIn = n.linkResource(niIn, EnumUsage.Input, null);
         Assert.IsNull(rlNiIn.getCombinedProcessIndex(), "ni input");
      }


      [TestMethod]
      public virtual void testAddTypes()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode mainNode = doc.getJDFRoot();
         mainNode.setType("ProcessGroup", true);
         mainNode.addTypes(EnumType.Shrinking);
         mainNode.addTypes(EnumType.Verification);
         Assert.IsTrue(mainNode.getEnumTypes().Contains(EnumType.Shrinking));
         Assert.IsTrue(mainNode.getEnumTypes().Contains(EnumType.Verification));
         Assert.AreEqual(2, mainNode.getEnumTypes().Count);
         mainNode.addTypes(EnumType.Verification);
         Assert.AreEqual(3, mainNode.getEnumTypes().Count);
      }


      [TestMethod]
      public virtual void testAddProduct()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode mainNode = doc.getJDFRoot();
         mainNode.setType(EnumType.Product);
         JDFNode p2 = mainNode.addProduct();
         Assert.AreEqual("Product", p2.getXSIType());
      }


      [TestMethod]
      public virtual void testAddResource()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode mainNode = doc.getJDFRoot();
         mainNode.setType("Product", true);
         JDFComponent myComponent = (JDFComponent)mainNode.addResource(ElementName.COMPONENT, JDFResource.EnumResourceClass.Quantity, EnumUsage.Output, null, mainNode, null, null);
         Assert.AreEqual(JDFResource.EnumResourceClass.Quantity, myComponent.getResourceClass());
         JDFComponent myComponent2 = (JDFComponent)mainNode.addResource(ElementName.COMPONENT, EnumUsage.Input);
         Assert.AreEqual(JDFResource.EnumResourceClass.Quantity, myComponent2.getResourceClass());
         myComponent.setDescriptiveName("descriptive_name");
         Assert.IsNotNull(mainNode.getMatchingResource(ElementName.COMPONENT, EnumProcessUsage.AnyOutput, null, 0));
         JDFResource myRes = mainNode.addResource("whatever:foo", JDFResource.EnumResourceClass.Quantity, EnumUsage.Output, null, mainNode, "www.whatever.com", null);
         Assert.AreEqual(JDFResource.EnumResourceClass.Quantity, myRes.getResourceClass());
         myRes.setDescriptiveName("descriptive_name");
      }


      [TestMethod]
      public virtual void testAddInternalPipe()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode mainNode = doc.getJDFRoot();
         mainNode.setType("Combined", true);
         mainNode.setTypes(new VString("Cutting Folding Folding Inserting", " "));
         JDFComponent myComponent = (JDFComponent)mainNode.addInternalPipe(ElementName.COMPONENT, 3, 0);
         Assert.IsNotNull(myComponent);
         Assert.AreEqual("Internal", myComponent.getPipeProtocol());
         VElement vE = myComponent.getLinks(myComponent.getLinkString(), null);
         Assert.AreEqual(vE.Count, 2);
         Assert.AreEqual("Internal", ((JDFResourceLink)vE[0]).getPipeProtocol());
         Assert.AreEqual("Internal", ((JDFResourceLink)vE[1]).getPipeProtocol());
      }


      [TestMethod]
      public virtual void testCloneResourceToModify()
      {
         JDFDoc d = JDFTestCaseBase.creatXMDoc();
         JDFNode n = d.getJDFRoot();
         JDFResourceLink rl = n.getMatchingLink(ElementName.EXPOSEDMEDIA, EnumProcessUsage.AnyInput, 0);
         JDFAttributeMap m = new JDFAttributeMap();
         m.put("SignatureName", "Sig1");
         rl.setPartMap(m);
         rl.setAmount(42, m);
         JDFResourceAudit ra = n.cloneResourceToModify(rl);
         Assert.IsTrue(ra.getNewLink().hasChildElement("Part", null), "link");
         Assert.IsTrue(ra.getOldLink().hasChildElement("Part", null), "link");
         Assert.IsTrue(ra.getNewLink().hasChildElement("AmountPool", null), "link");
         Assert.IsTrue(ra.getOldLink().hasChildElement("AmountPool", null), "link");
      }


      [TestMethod]
      public virtual void testEraseEmptyAttributes()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         JDFResource r = n.addResource("fooRes", EnumResourceClass.Consumable, EnumUsage.Input, EnumProcessUsage.AnyInput, null, "", null);
         r.appendAttribute("bar", "", "", "", false);
         n.eraseEmptyAttributes(true);
         Assert.IsFalse(n.hasAttribute("bar"));
      }


      [TestMethod]
      public virtual void testEraseEmptyNodes()
      {
         // note: when using JDFParser.parse(string), empty nodes are removed by
         // default
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.addResource("_foo", EnumResourceClass.Consumable, EnumUsage.Input, EnumProcessUsage.AnyInput, null, "", null);
         n.removeResource("_foo", 0);
         n.eraseEmptyNodes(true);
         Assert.IsNotNull(n.getResourcePool());
         Assert.IsNotNull(n.getResourceLinkPool());
      }


      [TestMethod]
      public virtual void testFixVersion()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode node = doc.getJDFRoot();
         node.setAttribute("Type", "Scanning");
         Assert.IsFalse(node.hasAttribute("type", AttributeName.XSIURI, false));
         node.fixVersion(null);
         Assert.IsTrue(node.hasAttribute("type", AttributeName.XSIURI, false));
         Assert.IsTrue(doc.write2String(0).IndexOf(AttributeName.XSIURI) > 0);
      }


      [TestMethod]
      public virtual void testEraseUnlinkedResources()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         JDFResource r = n.addResource("Component", null, null, null, null, null, null);
         JDFResourcePool rp = n.getResourcePool();
         Assert.IsTrue(r is JDFComponent);
         Assert.IsFalse(n.hasChildElement("ResourceLinkPool", null));
         JDFResourceLinkPool rlp = n.getCreateResourceLinkPool();
         Assert.AreEqual(r, rp.getUnlinkedResources()[0]);

         JDFResourceLink rl = rlp.linkResource(r, EnumUsage.Input, EnumProcessUsage.BookBlock);
         Assert.IsNotNull(rl);
         Assert.IsNull(rp.getUnlinkedResources());
         JDFResource rx = n.addResource("ExposedMedia", null, null, null, null, null, null);
         Assert.AreEqual(rx, rp.getUnlinkedResources()[0]);

         n.setVersion(EnumVersion.Version_1_2);
         JDFCustomerInfo ci = n.appendCustomerInfo();
         JDFContact co = ci.appendContact();
         co = (JDFContact)co.makeRootResource(null, null, true);
         Assert.AreEqual(rx, rp.getUnlinkedResources()[0]);
         Assert.AreEqual(1, rp.getUnlinkedResources().Count);
         n.eraseUnlinkedResources();
         Assert.IsNull(rp.getUnlinkedResources());
         Assert.IsNull(rp.getElement("ExposedMedia"), "didn't zapp unlinked xm");
         Assert.AreEqual(co, rp.getElement("Contact"));

         ci.deleteNode();
         Assert.AreEqual(co, rp.getUnlinkedResources()[0], "referenced contact accidentally zapped");
         n.eraseUnlinkedResources();
         Assert.IsNull(rp.getElement("Contact"), "didn't zapp unlinked co");

         JDFResource rFoo = n.addResource("FOO:Bar", EnumResourceClass.Handling, null, null, null, "www.foo.com", null);
         Assert.AreEqual(rFoo, rp.getUnlinkedResources()[0]);
         JDFResourceLink rlFoo = n.linkResource(rFoo, EnumUsage.Output, null);
         Assert.IsNotNull(rlFoo);
         Assert.IsNull(rp.getUnlinkedResources());
      }


      [TestMethod]
      public virtual void testRemoveResource()
      {
         JDFDoc gd = new JDFDoc("JDF");
         JDFNode n = gd.getJDFRoot();
         // JDFResource r=
         n.addResource("Media", EnumUsage.Input);
         // JDFResource r2=
         n.addResource("Media", EnumUsage.Input);
         Assert.IsNotNull(n.getLink(1, null, null, null));
         n.removeResource("Media", 0);
         Assert.IsNull(n.getLink(1, null, null, null));
         Assert.IsNotNull(n.getLink(0, null, null, null));
         n.removeResource("Media", 0);
         Assert.IsNull(n.getLink(0, null, null, null));
      }


      [TestMethod]
      public virtual void testResourceAudit()
      {
         JDFDoc gd = new JDFDoc("JDF");
         JDFNode n = gd.getJDFRoot();

         JDFRunList rl = (JDFRunList)n.addResource("RunList", null, EnumUsage.Input, null, null, null, null);
         n.setType("Product", false);
         n.setStatus(EnumNodeStatus.Waiting);
         JDFResourceLink rli = n.getLink(rl, null);
         JDFResourceAudit ra = n.cloneResourceToModify(rli);
         // messy comment insertion to test getNewOldLink with Comments
         ra.insertBefore(ElementName.COMMENT, ra.getOldLink(), null);
         ra.appendComment();
         Assert.IsTrue(ra.getComment(0) == ra.getNewLink().getNextSiblingElement(), "Comment after NewLink");
         Assert.IsTrue(ra.getComment(0).getNextSiblingElement() == ra.getOldLink(), "Comment before OldLink");
         Assert.IsTrue(ra.getComment(1) == ra.getOldLink().getNextSiblingElement(), "Comment after OldLink");

         Assert.IsTrue(ra.numChildElements("RunListLink", null) == 2, "resaudit children=2");
         Assert.IsTrue(n.getResourcePool().numChildElements("RunList", null) == 2, "respool children=2");
         Assert.IsTrue(n.getResourceLinkPool().numChildElements("RunListLink", null) == 1, "reslink children=1");
         Assert.IsTrue(((JDFResourceLink)n.getResourceLinkPool().getElement("RunListLink", null, 0)).getrRef().Equals(ra.getNewLink().getrRef()), "reslink audit1=pool");
         Assert.IsTrue((ra.getNewLink().getrRef() + "_old_001").Equals(ra.getOldLink().getrRef()), "id names");
         Assert.IsTrue((ra.getOldLink().getTarget()).getLocked(), "old lock");
         JDFResourceAudit ra2 = n.getAuditPool().addResourceAudit("foo");
         ra2.addNewOldLink(true, rl, EnumUsage.Input);
         ra2.appendComment();
         ra2.addNewOldLink(false, rl, EnumUsage.Input).setDescriptiveName("foo");
         Assert.IsTrue(ra2.getOldLink().getDescriptiveName().Equals("foo"), "addnewlink");
         Assert.IsTrue(ra2.isValid(EnumValidationLevel.Complete), "audit valid with Link");
         ra2.copyElement(rl, null);
         Assert.IsFalse(ra2.isValid(EnumValidationLevel.Complete), "audit invalid with resource");
      }

      ///   
      ///	 <summary> * test setPartStatus with null maps
      ///	 *  </summary>
      ///	 
      [TestMethod]
      public virtual void testSetPartStatusNull()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFNode root = doc.getJDFRoot();
         root.setVersion(JDFElement.EnumVersion.Version_1_3);
         root.setPartStatus(((JDFAttributeMap)null), EnumNodeStatus.Waiting, null);
         JDFNodeInfo ni = root.getNodeInfo();
         Assert.IsNull(ni);
         Assert.IsNull(root.getStatusPool());
         Assert.AreEqual(EnumNodeStatus.Waiting, root.getStatus());

         ni = root.getCreateNodeInfo();
         root.setPartStatus(((JDFAttributeMap)null), EnumNodeStatus.Completed, null);
         Assert.AreEqual(EnumNodeStatus.Completed, root.getStatus());
         Assert.AreEqual(EnumNodeStatus.Completed, ni.getNodeStatus(), "redundantly blasted in new nodestatus");

         root.setVersion(JDFElement.EnumVersion.Version_1_2);
         root.setPartStatus(((JDFAttributeMap)null), EnumNodeStatus.Completed, null);
         ni = root.getNodeInfo();
         Assert.AreEqual(EnumNodeStatus.Completed, root.getStatus());
         Assert.IsNull(root.getStatusPool());
      }


      [TestMethod]
      public virtual void testSetPartStatusNotNull()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFNode root = doc.getJDFRoot();
         root.setVersion(JDFElement.EnumVersion.Version_1_3);
         JDFAttributeMap pm = new JDFAttributeMap(EnumPartIDKey.SheetName.getName(), "s1");
         root.setPartStatus(pm, EnumNodeStatus.Waiting, null);
         JDFNodeInfo ni = (JDFNodeInfo)root.getNodeInfo().getPartition(pm, null);
         Assert.IsNotNull(ni);
         Assert.IsNull(root.getStatusPool());
         Assert.AreEqual(EnumNodeStatus.Part, root.getStatus());
         Assert.AreEqual(EnumNodeStatus.Waiting, root.getNodeInfo().getNodeStatus());
         Assert.AreEqual(EnumNodeStatus.Waiting, ni.getNodeStatus());

         root.setVersion(JDFElement.EnumVersion.Version_1_2);
         root.setPartStatus(pm, EnumNodeStatus.Completed, null);
         ni = root.getNodeInfo();
         Assert.AreEqual(EnumNodeStatus.Pool, root.getStatus());
         Assert.IsNotNull(root.getStatusPool());
         Assert.IsNotNull(root.getStatusPool().getPartStatus(pm));
         Assert.AreEqual(EnumNodeStatus.Completed, root.getStatusPool().getPartStatus(pm).getStatus());
      }


      [TestMethod]
      public virtual void testSetPhase()
      {
         for (int i = 0; i < 1; i++)
         {
            JDFDoc doc = new JDFDoc(ElementName.JDF);
            JDFNode root = doc.getJDFRoot();
            root.setVersion(JDFElement.EnumVersion.Version_1_3);
            root.setJobID("jID");
            root.setJobPartID("jpID");
            JDFNodeInfo nodeInfo = root.getCreateNodeInfo();
            nodeInfo.setAgentName("myAgent");
            StatusCounter su = new StatusCounter(root, null, null);
            su.setPhase(EnumNodeStatus.Waiting, "Queued", EnumDeviceStatus.Idle, null);
            JDFDoc docJMF = su.getDocJMFPhaseTime();
            JDFJMF jmf = docJMF.getJMFRoot();
            Assert.IsNotNull(jmf);
            Assert.AreEqual(1, jmf.numChildElements(ElementName.RESPONSE, null));
            JDFAuditPool ap = root.getAuditPool();
            JDFPhaseTime pt = ap.getLastPhase(null, null);
            Assert.AreEqual(EnumNodeStatus.Waiting, pt.getStatus());
            Assert.AreEqual(EnumNodeStatus.Waiting, root.getPartStatus(null));
            JDFAttributeMap map = new JDFAttributeMap("SheetName", "S1");
            VJDFAttributeMap vMap = new VJDFAttributeMap();
            vMap.Add(map);
            docJMF.write2File(sm_dirTestDataTemp + "queued.jmf", 2, true);
            Thread.Sleep(1000);
            su.setActiveNode(root, vMap, null);
            su.setPhase(EnumNodeStatus.Setup, "Setup", EnumDeviceStatus.Setup, null);

            docJMF = su.getDocJMFPhaseTime();
            pt = ap.getLastPhase(vMap, null);
            Assert.AreEqual(EnumNodeStatus.Setup, pt.getStatus());
            Assert.AreEqual(EnumNodeStatus.Setup, root.getPartStatus(map));
            Assert.AreEqual(vMap, pt.getPartMapVector());
            jmf = docJMF.getJMFRoot();
            Assert.IsNotNull(jmf);
            Assert.AreEqual(1, jmf.numChildElements(ElementName.RESPONSE, null));
            docJMF.write2File(sm_dirTestDataTemp + "setup.jmf", 2, true);
            Thread.Sleep(1000);
            su.setPhase(EnumNodeStatus.InProgress, "Run", EnumDeviceStatus.Running, null);

            docJMF = su.getDocJMFPhaseTime();
            pt = (JDFPhaseTime)ap.getAudit(-1, EnumAuditType.PhaseTime, null, null);
            Assert.AreEqual(EnumNodeStatus.InProgress, pt.getStatus());
            Assert.AreEqual(EnumNodeStatus.InProgress, root.getPartStatus(map));
            Assert.AreEqual(vMap, pt.getPartMapVector());
            jmf = docJMF.getJMFRoot();
            Assert.IsNotNull(jmf);
            Assert.AreEqual(2, jmf.numChildElements(ElementName.RESPONSE, null));
            docJMF.write2File(sm_dirTestDataTemp + "inprogress.jmf", 2, true);
            Thread.Sleep(1000);
            su.setPhase(EnumNodeStatus.InProgress, "Run", EnumDeviceStatus.Running, null);

            docJMF = su.getDocJMFPhaseTime();
            pt = (JDFPhaseTime)ap.getAudit(-1, EnumAuditType.PhaseTime, null, null);
            Assert.AreEqual(EnumNodeStatus.InProgress, pt.getStatus());
            Assert.AreEqual(EnumNodeStatus.InProgress, root.getPartStatus(map));
            Assert.AreEqual(vMap, pt.getPartMapVector());
            jmf = docJMF.getJMFRoot();
            Assert.IsNotNull(jmf);
            Assert.AreEqual(1, jmf.numChildElements(ElementName.RESPONSE, null));
            docJMF.write2File(sm_dirTestDataTemp + "inprogress2.jmf", 2, true);

            root.getCreateAncestorPool().setPartMapVector(vMap);
            su.setPhase(EnumNodeStatus.InProgress, "Run different", EnumDeviceStatus.Running, null);
            docJMF = su.getDocJMFPhaseTime();
            pt = (JDFPhaseTime)ap.getAudit(-1, EnumAuditType.PhaseTime, null, null);
            Assert.AreEqual(EnumNodeStatus.InProgress, pt.getStatus());
            Assert.AreEqual(EnumNodeStatus.InProgress, root.getPartStatus(map));
            Assert.AreEqual(vMap, pt.getPartMapVector());
            jmf = docJMF.getJMFRoot();
            Assert.IsNotNull(jmf);
            Assert.AreEqual(2, jmf.numChildElements(ElementName.RESPONSE, null));

            jmf.convertResponses(null);
            docJMF.write2File(sm_dirTestDataTemp + "inprogress3.jmf", 2, true);

            su.setPhase(EnumNodeStatus.Completed, "Finito", EnumDeviceStatus.Idle, null);
            docJMF = su.getDocJMFPhaseTime();
            pt = (JDFPhaseTime)ap.getAudit(-1, EnumAuditType.PhaseTime, null, null);
            Assert.AreEqual(EnumNodeStatus.InProgress, pt.getStatus());
            Assert.AreEqual(EnumNodeStatus.Completed, root.getPartStatus(map));
            Assert.AreEqual(vMap, pt.getPartMapVector());
            jmf = docJMF.getJMFRoot();
            Assert.IsNotNull(jmf);
            Assert.AreEqual(2, jmf.numChildElements(ElementName.RESPONSE, null));

            jmf.convertResponses(null);
            docJMF.write2File(sm_dirTestDataTemp + "inprogressCompleted.jmf", 2, true);
         }
      }


      [TestMethod]
      public virtual void testGetCreateNodeInfo()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFNode root = doc.getJDFRoot();
         root.setVersion(JDFElement.EnumVersion.Version_1_3);
         JDFNodeInfo nodeInfo = root.getCreateNodeInfo();
         JDFNodeInfo nodeInfo2 = root.getCreateNodeInfo();
         Assert.IsTrue(nodeInfo == nodeInfo2);

         root.setType(JDFNode.EnumType.Product.getName(), false);

         JDFNode nodeVer3 = root.addJDFNode("Version 1.3");
         JDFNode nodeVer1 = root.addJDFNode("Version 1.1");
         nodeVer1.setType("ProcessGroup", false);
         nodeVer3.setType("ProcessGroup", false);

         nodeVer3.setVersion(JDFElement.EnumVersion.Version_1_3);
         nodeVer1.setVersion(JDFElement.EnumVersion.Version_1_1);

         root.setVersion(EnumVersion.Version_1_3);
         // append some NodeInfos

         // try to append the other NodeInfo (only 1 is valid)
         nodeVer1.appendNodeInfo();
         nodeVer3.appendNodeInfo();
         JDFNode subNodeVer1 = nodeVer1.addJDFNode("Folding");
         JDFNode subNodeVer3 = nodeVer3.addJDFNode("Folding");

         bool cat = false;
         try
         {
            nodeVer1.appendNodeInfo();
         }
         catch (JDFException)
         {
            cat = true;
            // nodeinfo has a cardinality of 1 in V1.1
            // if we try to append another NodeInfo
            //
         }
         Assert.IsTrue(cat);
         cat = false;
         try
         {
            nodeVer3.appendNodeInfo();
         }
         catch (JDFException)
         {
            // nodeinfo has a cardinality of 1 in V1.1
            // if we try to append another NodeInfo
            cat = true;
         }
         Assert.IsTrue(cat);
         cat = false;
         try
         {
            nodeVer3.appendNodeInfo();
         }
         catch (JDFException)
         {
            // nodeinfo has a cardinality of 1 in V1.1
            // if we try to append another NodeInfo
            cat = true;
         }

         Assert.IsTrue(cat);
         Assert.IsNotNull(nodeVer1.getNodeInfo());
         Assert.IsNotNull(nodeVer3.getNodeInfo());

         Assert.IsNull(subNodeVer1.getNodeInfo());
         Assert.IsNull(subNodeVer3.getNodeInfo());

         Assert.IsNotNull(subNodeVer1.getInheritedNodeInfo(null));
         Assert.IsNotNull(subNodeVer3.getInheritedNodeInfo(null));

         // remove them all
         nodeVer3.removeNodeInfo();
         Assert.IsNull(nodeVer3.getNodeInfo());
         nodeVer1.removeNodeInfo();
         Assert.IsNull(nodeVer1.getNodeInfo());

         doc.write2File(sm_dirTestDataTemp + "getCreateNodeInfo.xml", 0, true);
      }

      ///   
      ///	 <summary> * Method testGetExecutablePartitionsPreflightImport
      ///	 *  </summary>
      ///	 * <exception cref="Exception"> </exception>
      ///	 

      [TestMethod]
      public virtual void testGetExecutablePartitionsPreflightImport()
      {
         string strJDFName = "PreflightImport1.jdf";

         JDFParser parser = new JDFParser();

         JDFDoc jdfDoc = parser.parseFile(sm_dirTestData + strJDFName);

         JDFNode nodeProc = jdfDoc.getJDFRoot().getJobPart("Qua0.P", JDFConstants.EMPTYSTRING);

         JDFResourceLinkPool linkPool = nodeProc.getResourceLinkPool();

         VElement vRunListLinks = linkPool.getPoolChildren("RunListLink", null, null);
         if (vRunListLinks != null)
         {
            JDFResourceLink link = (JDFResourceLink)vRunListLinks[0];
            VJDFAttributeMap vamExec = nodeProc.getExecutablePartitions(link, JDFResource.EnumResStatus.Draft, true);
            Assert.IsTrue(vamExec.Count == 2, "Size of vamExec must be 2");
            JDFAttributeMap am0 = vamExec[0];
            Assert.IsTrue(am0.Count == 1, "Size of vamExec[0] must be 1");
            Assert.IsTrue(am0.ContainsKey("Run"));
            Assert.IsTrue(am0.ContainsValue("Chf06181149500001"));

            JDFAttributeMap am1 = vamExec[1];

            Assert.IsTrue(am1.Count == 1, "Size of vamExec[1] must be 1");
            Assert.IsTrue(am1.ContainsKey("Run"));
            Assert.IsTrue(am1.ContainsValue("Chf06181154470000"));
         }
      }

      ///   
      ///	 <summary> * Method testGetExecutablePartitionsNormalizer
      ///	 *  </summary>
      ///	 * <exception cref="Exception"> </exception>
      ///	 

      [TestMethod]
      public virtual void testGetExecutablePartitionsNormalizer()
      {
         string strJDFName = "Normalizer.jdf";
         JDFParser parser = new JDFParser();
         JDFDoc jdfDoc = parser.parseFile(sm_dirTestData + strJDFName);
         JDFNode nodeProc = jdfDoc.getJDFRoot().getJobPart("Qua0.N", JDFConstants.EMPTYSTRING);
         JDFResourceLinkPool linkPool = nodeProc.getResourceLinkPool();
         VElement vRunListLinks = linkPool.getPoolChildren("RunListLink", null, null);
         JDFResourceLink link = (JDFResourceLink)vRunListLinks[0];
         VJDFAttributeMap vamExec = nodeProc.getExecutablePartitions(link, JDFResource.EnumResStatus.Draft, true);
         Assert.AreEqual(2, vamExec.Count, "Size of vamExec must be 2");
         JDFAttributeMap am0 = vamExec[0];
         Assert.AreEqual(1, am0.Count, "Size of vamExec[0] must be 1");
         Assert.IsTrue(am0.ContainsKey("Run"));
         Assert.IsTrue(am0.ContainsValue("Run93379_000255"));
         JDFAttributeMap am1 = vamExec[1];
         Assert.AreEqual(0, am1.Count, "Size of vamExec[1] must be 0");
      }

      ///   
      ///	 <summary> * Method testGetExecutablePartitionsNormalizer
      ///	 *  </summary>
      ///	 * <exception cref="Exception"> </exception>
      ///	 

      [TestMethod]
      public virtual void testIsExecutableZones()
      {
         string strJDFName = "ZoneTest.jdf";
         JDFParser parser = new JDFParser();
         JDFDoc jdfDoc = parser.parseFile(sm_dirTestData + strJDFName);
         JDFNode nodeProc = jdfDoc.getJDFRoot().getJobPart("PPIPressRoot.P", null);
         JDFAttributeMap map = new JDFAttributeMap();
         map.put(EnumPartIDKey.SignatureName, "Signature1");
         map.put(EnumPartIDKey.SheetName, "SM 102 52x28");
         VJDFAttributeMap vTest = new VJDFAttributeMap();
         vTest.Add(map);
         bool b = nodeProc.isExecutable(map, true);
         Assert.IsTrue(b);

         VElement links = nodeProc.getResourceLinks(null, new JDFAttributeMap("Usage", "Input"), null);
         for (int i = 0; i < links.Count; i++)
         {
            JDFResourceLink link = (JDFResourceLink)links[i];
            VJDFAttributeMap vamExec = nodeProc.getExecutablePartitions(link, JDFResource.EnumResStatus.Draft, true);
            Assert.IsNotNull(vamExec);
            Assert.IsTrue(vamExec.Count > 0);
         }

         links = nodeProc.getResourceLinks(null, new JDFAttributeMap("Usage", "Output"), null);
         for (int i = 0; i < links.Count; i++)
         {
            JDFResourceLink link = (JDFResourceLink)links[i];
            VJDFAttributeMap vamExec = nodeProc.getExecutablePartitions(link, JDFResource.EnumResStatus.Unavailable, true);
            Assert.IsNotNull(vamExec);
            Assert.IsTrue(vamExec.Count > 0);
            Assert.IsTrue(vamExec.Contains(map));
         }
         JDFSpawn spawn = new JDFSpawn(nodeProc);
         spawn.vSpawnParts = vTest;
         spawn.vRWResources_in = new VString();
         spawn.vRWResources_in.Add("Output");
         JDFNode spawnedNode = spawn.spawn();
         Assert.IsNotNull(spawnedNode);
         Assert.AreEqual(vTest, spawnedNode.getAncestorPool().getPartMapVector());
      }


      [TestMethod]
      public virtual void testNullPointerException()
      {
         ArrayList LcleanUpMerge = (ArrayList)JDFNode.EnumCleanUpMerge.getEnumList();
         ArrayList LamountMerge = (ArrayList)JDFResource.EnumAmountMerge.getEnumList();

         for (int i = 0; i < LcleanUpMerge.Count; i++)
         {
            EnumCleanUpMerge cleanUp = (EnumCleanUpMerge)LcleanUpMerge[i];

            for (int j = 0; j < LcleanUpMerge.Count; j++)
            {
               EnumAmountMerge amountMerge = (EnumAmountMerge)LamountMerge[j];

               string xmlFile1 = "km4444.jdf";
               string xmlFile2 = "Link33458670_000214km4444Qua0.NSp33486069_000371_37_out.jdf";
               string outFile = "km4444_merged.xml";

               JDFParser p = new JDFParser();
               JDFDoc m_jdfDoc = p.parseFile(sm_dirTestData + xmlFile1);
               m_jdfDoc.getCreateXMLDocUserData();
               JDFParser p2 = new JDFParser();
               JDFDoc m_jdfDoc2 = p2.parseFile(sm_dirTestData + xmlFile2);
               m_jdfDoc2.getCreateXMLDocUserData();

               JDFNode root = (JDFNode)m_jdfDoc.getRoot();
               Assert.IsNotNull(root);
               JDFNode root2 = (JDFNode)m_jdfDoc2.getRoot();
               Assert.IsNotNull(root2);
               if (root == null)
               {
                  return; // soothe findbugs ;)
               }
               new JDFMerge(root).mergeJDF(root2, sm_dirTestData + xmlFile2, cleanUp, amountMerge);

               m_jdfDoc.write2File(sm_dirTestDataTemp + outFile + i + j, 2, true);
            }
         }
      }


      [TestMethod]
      public virtual void testNodeIdentifier()
      {
         NodeIdentifier ni = new NodeIdentifier();
         NodeIdentifier ni2 = new NodeIdentifier("", "", null);
         Assert.AreEqual(ni, ni2);
         JDFNode n = new JDFDoc("JDF").getJDFRoot();
         n.setJobID("j1");
         n.setJobPartID("p1");
         ni.setTo(n);
         Assert.AreNotEqual(ni2, ni);
         ni2.setTo(n);
         Assert.AreEqual(ni2, ni);
         n.appendAncestorPool().appendPart().setPartMap(new JDFAttributeMap("a", "b"));
         ni.setTo(n);
         Assert.AreNotEqual(ni2, ni);
         ni2.setTo(n);
         Assert.AreEqual(ni2, ni);
      }


      [TestMethod]
      public virtual void testNodeIdentifierParts()
      {
         JDFNode n = new JDFDoc("JDF").getJDFRoot();
         JDFResource c = n.addResource(ElementName.COMPONENT, EnumUsage.Output);
         VJDFAttributeMap v = new VJDFAttributeMap();

         for (int i = 0; i < 3; i++)
         {
            JDFAttributeMap m = new JDFAttributeMap();
            m.put("SignatureName", "sig1");
            m.put("SheetName", "S" + i);
            v.Add(m);
            c.getCreatePartition(m, new VString("SignatureName SheetName", null));
         }
         NodeIdentifier ni = new NodeIdentifier(n);
         NodeIdentifier ni2 = new NodeIdentifier(n.getJobID(true), n.getJobPartID(true), v);
         Assert.AreEqual(ni2, ni);
         n.setPartStatus(new JDFAttributeMap("SignatureName", "Sig1"), EnumNodeStatus.InProgress, null);
         ni.setTo(n);
         Assert.AreNotEqual(ni2, ni);
      }


      [TestMethod]
      public virtual void testNodeIdentifierMatches()
      {
         NodeIdentifier ni = new NodeIdentifier();
         NodeIdentifier ni2 = new NodeIdentifier("", "", null);
         Assert.AreEqual(ni, ni2);
         Assert.IsTrue(ni.matches(ni2));
         JDFNode n = new JDFDoc("JDF").getJDFRoot();
         n.setJobID("j1");
         n.setJobPartID("p1");
         ni.setTo(n);
         Assert.IsTrue(ni.matches(ni2));
         Assert.IsTrue(ni.matches("j1"), "ok if jobID matches");
         Assert.IsFalse(ni.matches("p1"));
         JDFAncestorPool aPool = n.appendAncestorPool();
         aPool.appendPart().setPartMap(new JDFAttributeMap("a", "b"));
         ni.setTo(n);
         Assert.IsTrue(ni.matches(ni2));
         ni2.setTo(n);
         Assert.IsTrue(ni.matches(ni2));
         aPool.appendPart().setPartMap(new JDFAttributeMap("a", "c"));
         ni.setTo(n);
         Assert.IsTrue(ni.matches(ni2));
      }


      [TestMethod]
      public virtual void testInit()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFNode node = doc.getJDFRoot();
         Assert.IsNotNull(node.getStatus());
         Assert.IsFalse(node.getID().Equals(""));
         node.init();
         node.init();
         JDFAuditPool ap = node.getAuditPool();
         Assert.IsNotNull(ap);
         Assert.AreEqual(1, ap.numChildElements(ElementName.CREATED, null));
      }

      [TestMethod]
      public virtual void testInitDefaultVersion()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFNode node = doc.getJDFRoot();
         Assert.AreEqual(JDFElement.getDefaultJDFVersion(), node.getVersion(true));
         Assert.AreEqual(JDFElement.getDefaultJDFVersion(), node.getMaxVersion(true));

         JDFElement.setDefaultJDFVersion(EnumVersion.Version_1_1);
         doc = new JDFDoc(ElementName.JDF);
         node = doc.getJDFRoot();
         Assert.AreEqual(JDFElement.getDefaultJDFVersion(), node.getVersion(true));
         Assert.AreEqual(JDFElement.getDefaultJDFVersion(), node.getMaxVersion(true));
      }


      [TestMethod]
      public virtual void testIsValid()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFNode node = doc.getJDFRoot();
         node.setType(EnumType.ProcessGroup);
         Assert.IsTrue(node.isValid(EnumValidationLevel.Complete));
         node.removeAttribute(AttributeName.JOBPARTID, null);
         Assert.IsTrue(node.isValid(EnumValidationLevel.Complete), "isvalid does not require jpid");
      }


      [TestMethod]
      public virtual void testIsValidCombined()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFNode node = doc.getJDFRoot();
         node.setType(EnumType.Combined);
         Assert.IsFalse(node.isValid(EnumValidationLevel.Complete), "need typed for combined");
      }


      [TestMethod]
      public virtual void testIsGroupNode()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFNode node = doc.getJDFRoot();
         node.setType(EnumType.Product);
         Assert.IsTrue(node.isGroupNode());
         node.setType(EnumType.ProcessGroup);
         Assert.IsTrue(node.isGroupNode());
         node.setTypes(new VString("foo", " "));
         Assert.IsFalse(node.isGroupNode());
         node.setType(EnumType.Combined);
         Assert.IsFalse(node.isGroupNode());
         node.setType(EnumType.ConventionalPrinting);
         Assert.IsFalse(node.isGroupNode());
      }


      [TestMethod]
      public virtual void testIsTypesNode()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFNode node = doc.getJDFRoot();
         node.setType(EnumType.Product);
         Assert.IsFalse(node.isTypesNode());
         node.setType(EnumType.Combined);
         Assert.IsTrue(node.isTypesNode());
         node.setType(EnumType.ConventionalPrinting);
         Assert.IsFalse(node.isTypesNode());
         node.setType(EnumType.ProcessGroup);
         Assert.IsTrue(node.isTypesNode());
         node.addJDFNode("foo");
         Assert.IsTrue(node.isTypesNode());
      }


      [TestMethod]
      public virtual void testIsExecutable()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFNode node = doc.getJDFRoot();
         node.setType("ConventionalPrinting", true);
         node.setVersion(JDFElement.EnumVersion.Version_1_3);
         node.setStatus(EnumNodeStatus.Ready);

         Assert.IsFalse(node.isExecutable(null, true), "no links, no execute");

         // simple non-partitioned case
         JDFNodeInfo n = node.appendNodeInfo();
         Assert.IsTrue(n.hasAttribute(AttributeName.CLASS), "ni resource");
         JDFConventionalPrintingParams convPrintParams = (JDFConventionalPrintingParams)node.appendMatchingResource(ElementName.CONVENTIONALPRINTINGPARAMS, EnumProcessUsage.AnyInput, null);
         convPrintParams.setResStatus(EnumResStatus.Available, true);
         JDFComponent outComp = (JDFComponent)node.appendMatchingResource(ElementName.COMPONENT, EnumProcessUsage.AnyOutput, null);
         outComp.setResStatus(EnumResStatus.Unavailable, true);
         JDFExposedMedia xm = (JDFExposedMedia)node.appendMatchingResource(ElementName.EXPOSEDMEDIA, EnumProcessUsage.AnyInput, null);
         xm.setResStatus(EnumResStatus.Unavailable, true);
         JDFMedia media = (JDFMedia)node.appendMatchingResource(ElementName.MEDIA, EnumProcessUsage.AnyInput, null);
         media.setResStatus(EnumResStatus.Available, true);
         bool exec = node.isExecutable(null, false);
         Assert.IsFalse(exec, "not exec");
         xm.setResStatus(EnumResStatus.Available, true);
         exec = node.isExecutable(null, false);
         Assert.IsTrue(exec, "exec");
         node.setStatus(EnumNodeStatus.Completed);
         exec = node.isExecutable(null, false);
         Assert.IsFalse(exec, "exec");
         node.setStatus(EnumNodeStatus.Waiting);
         xm.setResStatus(EnumResStatus.Unavailable, true);
         JDFResourceLink rl = node.getLink(xm, null);
         exec = node.isExecutable(null, false);
         Assert.IsFalse(exec, "exec");
         rl.setDraftOK(true);
         exec = node.isExecutable(null, false);
         Assert.IsFalse(exec, "exec");

         xm.setResStatus(EnumResStatus.Draft, true);
         exec = node.isExecutable(null, false);
         Assert.IsTrue(exec, "exec");
         xm.setResStatus(EnumResStatus.Available, true);

         // now a partition
         convPrintParams.setPartUsage(EnumPartUsage.Implicit);
         media.setPartUsage(EnumPartUsage.Implicit);
         xm = (JDFExposedMedia)xm.addPartition(EnumPartIDKey.SignatureName, "sig1");
         xm.setResStatus(EnumResStatus.Unavailable, true);
         exec = node.isExecutable(null, true);
         Assert.IsFalse(exec, "part not exec");
         xm.setResStatus(EnumResStatus.Available, true);
         exec = node.isExecutable(null, true);
         Assert.IsTrue(exec, "part exec");
         JDFAttributeMap partMap = new JDFAttributeMap("SignatureName", "sig1");
         node.setPartStatus(partMap, EnumNodeStatus.Waiting, null);

         outComp.addPartition(EnumPartIDKey.SignatureName, "sig1");
         exec = node.isExecutable(partMap, false);
         Assert.IsTrue(exec, "part exec");

         node.setPartStatus(((JDFAttributeMap)null), EnumNodeStatus.Completed, null);

         // the root is set to completed --> must fail
         exec = node.isExecutable(null, false);
         Assert.IsFalse(exec, "part exec");

         // now try a non existing partition - should fail
         partMap.put("SignatureName", "sig2");
         exec = node.isExecutable(partMap, false);

         Assert.IsFalse(exec, "part exec");
      }


      [TestMethod]
      public virtual void testGetInheritedNodeInfo()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFNode node = doc.getJDFRoot();
         JDFNodeInfo n = node.appendNodeInfo();
         try
         {
            node.appendNodeInfo();
            Assert.Fail("one ni is enough");
         }
         catch (JDFException)
         {
            // nop
         }
         node.setType("ProcessGroup", true);
         JDFNode node2 = node.addProcessGroup(null);
         JDFNode node3 = node2.addJDFNode(JDFNode.EnumType.CaseMaking);
         JDFAncestor an = node.appendAncestorPool().appendAncestor();
         JDFCustomerInfo ciAN = an.appendCustomerInfo();
         JDFNodeInfo niAN = an.appendNodeInfo();
         JDFJMF jmf = niAN.appendJMF();
         VString vs = new VString();
         vs.Add("ICS_Foo");
         jmf.setICSVersions(vs);

         Assert.IsNull(node2.getNodeInfo());
         Assert.IsNull(node2.getInheritedNodeInfo("MISDetails"));
         Assert.IsNull(node2.getInheritedNodeInfo("JMF/@DeviceID"));
         Assert.AreEqual(niAN, node2.getInheritedNodeInfo("JMF/@ICSVersions"));
         Assert.AreEqual(n, node.getInheritedNodeInfo(null));
         Assert.AreEqual(n, node2.getInheritedNodeInfo(null));
         Assert.AreEqual(n, node3.getInheritedNodeInfo(null));
         Assert.AreEqual(ciAN, node3.getInheritedCustomerInfo(null));
         JDFNodeInfo ni3 = node3.appendNodeInfo();
         JDFNodeInfo sigNI = (JDFNodeInfo)ni3.addPartition(EnumPartIDKey.SignatureName, "Sig1");
         sigNI.setStart(new JDFDate());
         JDFNodeInfo niPart = (JDFNodeInfo)sigNI.addPartition(EnumPartIDKey.SheetName, "S1");
         node3.getLink(ni3, null).setPartMap(niPart.getPartMap());
         niPart.setEnd(new JDFDate());
         Assert.AreEqual(niPart, node3.getInheritedNodeInfo(null));
         Assert.AreEqual(niPart, node3.getInheritedNodeInfo("@End"));
         Assert.AreEqual(niPart, node3.getInheritedNodeInfo("@Start"));
         Assert.IsNull(node3.getInheritedNodeInfo("@FooBar"));
         Assert.AreEqual(niAN, node3.getInheritedNodeInfo("JMF/@ICSVersions"));
      }


      [TestMethod]
      public virtual void testCreateNodeInfo()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFNode node = doc.getJDFRoot();
         JDFNodeInfo n = node.appendNodeInfo();
         try
         {
            node.appendNodeInfo();
            Assert.Fail("one ni is enough");
         }
         catch (JDFException)
         {
            // nop
         }
         // System.out.println(n.version());
         Assert.IsTrue(n.getResourceClass() == EnumResourceClass.Parameter, "nodeinfo is resource");
         doc.write2File(sm_dirTestDataTemp + "createNodeInfoTest.xml", 0, true);
         JDFCustomerInfo myCustInfo = node.getCreateCustomerInfo();
         JDFContact myContact = myCustInfo.appendContact();
         Assert.IsTrue(myContact.getResourceClass() == EnumResourceClass.Parameter, "contact is res");
         Assert.IsNotNull(node.getNodeInfo());
         node.removeNodeInfo();
         Assert.IsNull(node.getNodeInfo());
      }


      [TestMethod]
      public virtual void testGetvJDFNode()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setType(EnumType.ProcessGroup);
         JDFNode n1 = n.addProcessGroup(null);
         JDFNode n2 = n.addProcessGroup(null);
         JDFNode n11 = n1.addProcessGroup(null);
         Assert.AreEqual(2, n.getvJDFNode(null, null, true).Count);
         Assert.AreEqual(1, n1.getvJDFNode(null, null, true).Count);
         Assert.AreEqual(1, n2.getvJDFNode(null, null, false).Count);
         Assert.AreEqual(2, n1.getvJDFNode(null, null, false).Count);
         Assert.AreEqual(n.getvJDFNode(null, null, true)[0], n1);
         Assert.AreEqual(n.getvJDFNode(null, null, false)[3], n);
         Assert.AreEqual(n1.getvJDFNode(null, null, true)[0], n11);
         Assert.AreEqual(n1.getvJDFNode(null, null, false)[1], n1);
      }


      [TestMethod]
      public virtual void testGetPartStatusNull()
      {
         JDFNode n = new JDFDoc("JDF").getJDFRoot();
         n.setPartStatus(((JDFAttributeMap)null), EnumNodeStatus.Completed, null);
         Assert.AreEqual(EnumNodeStatus.Completed, n.getPartStatus(null));
         JDFNodeInfo nodeInfo = n.appendNodeInfo();
         nodeInfo.setPartUsage(EnumPartUsage.Implicit);
         nodeInfo.setNodeStatus(EnumNodeStatus.Cleanup);
         n.setStatus(EnumNodeStatus.Part);
         Assert.AreEqual(EnumNodeStatus.Cleanup, n.getPartStatus(null));
         Assert.AreEqual(EnumNodeStatus.Cleanup, n.getPartStatus(new JDFAttributeMap("Run", "r1")));
         n.setStatus(EnumNodeStatus.Setup);
         Assert.AreEqual(EnumNodeStatus.Setup, n.getPartStatus(null));
         Assert.AreEqual(EnumNodeStatus.Setup, n.getPartStatus(new JDFAttributeMap("Run", "r1")));
      }


      [TestMethod]
      public virtual void testGetPartStatusImplicit()
      {
         JDFNode createJDF = new JDFDoc("JDF").getJDFRoot();
         createJDF.getCreateResourcePool();
         JDFNodeInfo createNodeInfo = createJDF.getCreateNodeInfo();
         createNodeInfo.setNodeStatus(EnumNodeStatus.Waiting);
         createJDF.setStatus(EnumNodeStatus.Part);
         JDFAttributeMap partMap = new JDFAttributeMap();
         partMap.put("Run", "1");
         const VString vPartKeys = null;
         JDFNodeInfo createPartition = (JDFNodeInfo)createNodeInfo.getCreatePartition(partMap, vPartKeys);
         createPartition.setNodeStatus(EnumNodeStatus.Completed);
         partMap.put("Run", "2");
         EnumNodeStatus partStatus = createJDF.getPartStatus(partMap);
         Assert.AreEqual(EnumNodeStatus.Waiting, partStatus, "The implicit leaf defaults to root");
      }


      [TestMethod]
      public virtual void testGetPartStatusPerformance()
      {
         JDFNode node = new JDFDoc("JDF").getJDFRoot();
         JDFNodeInfo ni = node.appendNodeInfo();
         JDFResourceLink rl = node.getLink(ni, null);
         VJDFAttributeMap vParts = new VJDFAttributeMap();
         long t = JDFDate.ToMillisecs(DateTime.Now);
         for (int i = 0; i < 1000; i++)
         {
            JDFAttributeMap pm = new JDFAttributeMap("SheetName", "s" + i);
            vParts.Add(pm);
            node.setPartStatus(pm, EnumNodeStatus.Completed, null);
         }
         rl.setPartMapVector(vParts);
         for (int i = 0; i < 1000; i++)
         {
            Assert.AreEqual(EnumNodeStatus.Completed, node.getPartStatus(vParts[i]));
         }
         Assert.IsTrue(JDFDate.ToMillisecs(DateTime.Now) - t < 25000, "too slow may laptop takes roughly 2.5 seconds");
      }


      [TestMethod]
      public virtual void testGetVectorPartStatus()
      {
         JDFNode n = new JDFDoc("JDF").getJDFRoot();
         VJDFAttributeMap v = new VJDFAttributeMap();
         for (int i = 0; i < 3; i++)
            v.Add(new JDFAttributeMap("SheetName", "s" + i));
         n.setPartStatus(v, EnumNodeStatus.Cleanup, null);
         Assert.AreEqual(EnumNodeStatus.Cleanup, n.getVectorPartStatus(v));
         v.RemoveAt(2);
         Assert.AreEqual(EnumNodeStatus.Cleanup, n.getVectorPartStatus(v));
         n.setPartStatus(new JDFAttributeMap("SheetName", "s1"), EnumNodeStatus.Setup, null);
         Assert.IsNull(n.getVectorPartStatus(v));
      }


      [TestMethod]
      public virtual void testGetVectorPartStatusDetails()
      {
         JDFNode n = new JDFDoc("JDF").getJDFRoot();
         VJDFAttributeMap v = new VJDFAttributeMap();
         for (int i = 0; i < 3; i++)
            v.Add(new JDFAttributeMap("SheetName", "s" + i));
         n.setPartStatus(v, EnumNodeStatus.Cleanup, "dummy");
         Assert.AreEqual("dummy", n.getVectorPartStatusDetails(v));
         v.RemoveAt(2);
         Assert.AreEqual("dummy", n.getVectorPartStatusDetails(v));
         n.setPartStatus(new JDFAttributeMap("SheetName", "s1"), EnumNodeStatus.Cleanup, "foobar");
         Assert.IsNull(n.getVectorPartStatusDetails(v));
      }


      [TestMethod]
      public virtual void testGetPartStatus()
      {
         JDFDoc doc = JDFTestCaseBase.creatXMDoc();
         JDFNode node = doc.getJDFRoot();
         JDFNodeInfo ni = node.getNodeInfo();
         Assert.IsTrue(ni.getResourceClass() == EnumResourceClass.Parameter, "nodeinfo is resource");
         node.setPartStatus(((JDFAttributeMap)null), EnumNodeStatus.Waiting, null);
         Assert.IsTrue(node.getPartStatus(null) == EnumNodeStatus.Waiting, "ni root waiting");
         JDFAttributeMap m = new JDFAttributeMap("SignatureName", "Sig1");
         node.setPartStatus(m, EnumNodeStatus.Completed, null);
         Assert.IsTrue(node.getPartStatus(m) == EnumNodeStatus.Completed, "ni sig1 completed");
         Assert.IsNull(node.getPartStatus(null), "ni root mixed");
         JDFAttributeMap m3 = new JDFAttributeMap("SignatureName", "Sig2");
         Assert.IsTrue(node.getPartStatus(m3) == EnumNodeStatus.Waiting, "ni sig2 waiting");

         m.put("SheetName", "S1");
         m.put("Side", "Front");
         Assert.AreEqual(EnumNodeStatus.Completed, node.getPartStatus(m));
         node.setPartStatus(m, EnumNodeStatus.Waiting, null);
         Assert.IsTrue(node.getPartStatus(m) == EnumNodeStatus.Waiting, "ni sig1 waiting");

         JDFAttributeMap m2 = new JDFAttributeMap("SignatureName", "Sig1");
         Assert.IsNull(node.getPartStatus(m2), "ni sig1 mixed");

         JDFAttributeMap m4 = new JDFAttributeMap("SignatureName", "Sig3");
         m4.put("SheetName", "S1");
         VJDFAttributeMap v = new VJDFAttributeMap();
         v.Add(m4);
         node.prepareNodeInfo(v);
         Assert.IsTrue(node.getPartStatus(m4) == EnumNodeStatus.Waiting, "ni sig3 waiting");
         Assert.IsNotNull(ni.getPartition(m4, EnumPartUsage.Explicit), "explicit m4");

         JDFAttributeMap m5 = new JDFAttributeMap("Side", "Back");
         Assert.IsNull(node.getPartStatus(m5), "ni side back  mixed");
      }


      [TestMethod]
      public virtual void testGenericResources()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setType("ConventionalPrinting", true);
         JDFDevice dev = (JDFDevice)n.appendMatchingResource(ElementName.DEVICE, EnumProcessUsage.AnyInput, null);
         dev.setDeviceID("mydev");
         Assert.IsTrue(dev.isValid(EnumValidationLevel.Complete), "valid device");
         JDFModule m = dev.appendModule();
         m.setModuleID("Foo");
         JDFEmployee emp = (JDFEmployee)n.appendMatchingResource(ElementName.EMPLOYEE, EnumProcessUsage.AnyInput, null);
         emp.setPersonalID("emp1");
         Assert.IsTrue(m.isValid(EnumValidationLevel.Complete), "valid module");
         n.appendMatchingResource(ElementName.CONVENTIONALPRINTINGPARAMS, EnumProcessUsage.AnyInput, null);
         n.appendMatchingResource(ElementName.COMPONENT, EnumProcessUsage.AnyOutput, null);
         n.appendMatchingResource(ElementName.EXPOSEDMEDIA, EnumProcessUsage.Plate, null);

         Assert.IsTrue(n.isValid(EnumValidationLevel.Incomplete), "valid node");
      }


      [TestMethod]
      public virtual void testProductValidation()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setType("Product", true);
         JDFDevice dev = (JDFDevice)n.appendMatchingResource(ElementName.DEVICE, EnumProcessUsage.AnyInput, null);
         dev.setDeviceID("mydev");
         Assert.IsTrue(dev.isValid(EnumValidationLevel.Complete), "valid device");
         JDFModule m = dev.appendModule();
         m.setModuleID("Foo");
         JDFEmployee emp = (JDFEmployee)n.appendMatchingResource(ElementName.EMPLOYEE, EnumProcessUsage.AnyInput, null);
         emp.setPersonalID("emp1");
         Assert.IsTrue(m.isValid(EnumValidationLevel.Complete), "valid module");
      }


      [TestMethod]
      public virtual void testGrayBox()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setType("ProcessGroup", true);
         VString v = new VString();
         v.Add("Interpreting");
         v.Add("Rendering");
         n.setTypes(v);
         v = n.getInsertLinkVector(9999);
         Assert.IsTrue(v.Contains("InterpretingParamsLink:AnyInput"), "interpretingParams");
      }


      [TestMethod]
      public virtual void testAppendMatchingResourceProduct()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setStatus(EnumNodeStatus.Ready);
         n.setType("Product", true);
         JDFComponent co = (JDFComponent)n.appendMatchingResource("Component", EnumProcessUsage.Cover, null);
         List<ValuedEnum> vType = new List<ValuedEnum>();
         vType.Add(EnumComponentType.FinalProduct);
         vType.Add(EnumComponentType.Block);
         co.setComponentType(vType);
         co = (JDFComponent)n.appendMatchingResource("Component", EnumProcessUsage.Cover, null);
         co.setComponentType(vType);
         co = (JDFComponent)n.appendMatchingResource("Component", EnumProcessUsage.AnyOutput, null);
         co.setComponentType(vType);
         Assert.IsTrue(n.isValid(EnumValidationLevel.Complete));
      }


      [TestMethod]
      public virtual void testAppendMatchingResourcePrivate()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setCombined(new VString("ConventionalPrinting fnarf ConventionalPrinting", null));
         JDFResource r = n.appendMatchingResource(ElementName.CONVENTIONALPRINTINGPARAMS, null, null);
         JDFResourceLink rl = n.getLink(r, null);
         Assert.IsNotNull(rl, "rl 1");
         r = n.appendMatchingResource("FnarfParams", null, null);
         rl = n.getLink(r, null);
         Assert.IsNotNull(rl, "rl fnarf");
         rl = n.getMatchingLink("FnarfParams", null, 0);
         Assert.IsNotNull(rl, "rl fnarf");
         Assert.AreEqual(1, n.numMatchingLinks("FnarfParams", true, null));
      }


      [TestMethod]
      public virtual void testAppendMatchingResourceDefinition()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setType(EnumType.ResourceDefinition);
         JDFResource r = n.appendMatchingResource("foo", null, null);
         Assert.IsNotNull(r);
         Assert.AreEqual("foo", r.Name);
      }


      [TestMethod]
      public virtual void testGetResource()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setType(EnumType.ResourceDefinition);
         JDFResource r = n.getResource(ElementName.SADDLESTITCHINGPARAMS, EnumUsage.Input, 0);
         Assert.IsNull(r);
         r = n.getResource(ElementName.SADDLESTITCHINGPARAMS, EnumUsage.Input, -1);
         Assert.IsNull(r);
         JDFResource rAdd = n.addResource(ElementName.SADDLESTITCHINGPARAMS, EnumUsage.Input);
         Assert.IsNotNull(rAdd);
         r = n.getResource(ElementName.SADDLESTITCHINGPARAMS, EnumUsage.Input, 0);
         Assert.AreEqual(rAdd, r);
         r = n.getResource(ElementName.SADDLESTITCHINGPARAMS, EnumUsage.Input, -1);
         Assert.AreEqual(rAdd, r);
         JDFResource rAdd2 = n.addResource(ElementName.SADDLESTITCHINGPARAMS, EnumUsage.Input);
         Assert.IsNotNull(rAdd2);
         r = n.getResource(ElementName.SADDLESTITCHINGPARAMS, EnumUsage.Input, -1);
         Assert.AreEqual(rAdd2, r);
         r = n.getResource(ElementName.SADDLESTITCHINGPARAMS, null, -2);
         Assert.AreEqual(rAdd, r);
         JDFResource @out = n.addResource(ElementName.COMPONENT, EnumUsage.Output);
         Assert.AreEqual(n.getResource(null, EnumUsage.Output, null, 0), @out, "null is valid wildcard");
      }


      [TestMethod]
      public virtual void testGetResourceProcessUsage()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setType(EnumType.ResourceDefinition);
         JDFResource rAdd = n.addResource(ElementName.SADDLESTITCHINGPARAMS, EnumUsage.Input);
         JDFResource rAdd2 = n.addResource(ElementName.SADDLESTITCHINGPARAMS, EnumUsage.Input);
         Assert.IsNotNull(rAdd2);
         JDFResourceLink rl = n.getLink(rAdd, null);
         rl.setProcessUsage(EnumProcessUsage.Application);
         JDFResource r = n.getResource(ElementName.SADDLESTITCHINGPARAMS, EnumUsage.Input, EnumProcessUsage.Application, -1);
         Assert.AreEqual(rAdd, r);
         r = n.getResource(ElementName.SADDLESTITCHINGPARAMS, EnumUsage.Input, EnumProcessUsage.Application, 0);
         Assert.AreEqual(rAdd, r);
         r = n.getResource(ElementName.SADDLESTITCHINGPARAMS, EnumUsage.Input, EnumProcessUsage.Application, 1);
         Assert.IsNull(r);
      }


      [TestMethod]
      public virtual void testGetCreateResource()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setType(EnumType.ResourceDefinition);
         JDFResource r = n.getCreateResource(ElementName.SADDLESTITCHINGPARAMS, EnumUsage.Input, 0);
         Assert.IsNotNull(r);
         JDFResource rAdd = n.getCreateResource(ElementName.SADDLESTITCHINGPARAMS, EnumUsage.Input, 0);
         Assert.IsNotNull(rAdd);
         Assert.AreEqual(rAdd, r);
         JDFResource rAdd2 = n.getCreateResource(ElementName.SADDLESTITCHINGPARAMS, EnumUsage.Input, 1);
         Assert.IsNotNull(rAdd2);
         Assert.AreNotEqual(rAdd, rAdd2);
         rAdd2 = n.getCreateResource(ElementName.SADDLESTITCHINGPARAMS, EnumUsage.Input, -2);
         Assert.IsNotNull(rAdd2);
         Assert.AreEqual(rAdd, rAdd2);
      }


      [TestMethod]
      public virtual void testAppendMatchingResource()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setCombined(new VString("ConventionalPrinting ConventionalPrinting", null));
         JDFResource r = n.appendMatchingResource(ElementName.CONVENTIONALPRINTINGPARAMS, null, null);
         JDFResourceLink rl = n.getLink(r, null);
         Assert.IsNotNull(rl, "rl 1");

         r = n.appendMatchingResource(ElementName.CONVENTIONALPRINTINGPARAMS, null, null);
         Assert.IsNotNull(r, "r 2");
         rl = n.getLink(r, null);
         Assert.IsNotNull(rl, "rl 2");
         Assert.AreEqual(EnumUsage.Input, rl.getUsage(), "rl usage");

         try
         {
            r = n.appendMatchingResource(ElementName.CONVENTIONALPRINTINGPARAMS, null, null);
            Assert.Fail("exception 3");
         }
         catch (JDFException)
         {
            // nop
         }

         r = n.appendMatchingResource(ElementName.COMPONENT, null, null);
         Assert.IsNotNull(r, "comp 1");
         rl = n.getLink(r, null);
         Assert.IsNull(rl, "complink 1");
         rl = n.linkMatchingResource(r, EnumProcessUsage.Input, null);
         Assert.IsNotNull(rl, "rl 2");
         Assert.AreEqual(EnumUsage.Input, rl.getUsage(), "rl usage");
         Assert.AreEqual("Input", rl.getProcessUsage());

         r = n.appendMatchingResource(ElementName.COMPONENT, EnumProcessUsage.AnyOutput, null);
         Assert.IsNotNull(r, "comp 2");
         rl = n.getLink(r, null);
         Assert.IsNotNull(rl, "complink 2");
         Assert.AreEqual("", rl.getProcessUsage());

         n.setCombined(new VString("Collecting ConventionalPrinting", null));
         for (int cLoop = 0; cLoop < 5; cLoop++)
         {
            r = n.appendMatchingResource(ElementName.COMPONENT, EnumProcessUsage.AnyInput, null);
            Assert.IsNotNull(r, "comp loop");
            rl = n.getLink(r, null);
            Assert.IsNotNull(rl, "complink 2");
            Assert.AreEqual("", rl.getProcessUsage());
         }
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

         JDFNode nodeProc = jdfDoc.getJDFRoot().getJobPart("IPD0.I", JDFConstants.EMPTYSTRING);

         ICollection vSpawned = nodeProc.checkSpawnedResources(vsRWResourceIDs, vamParts);
         Assert.IsNull(vSpawned);
      }


      [TestMethod]
      public virtual void testGetNodeInfo()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setType(JDFNode.EnumType.ProcessGroup);
         n.setTypes(new VString("a b c", null));
         JDFNodeInfo n2 = n.appendNodeInfo();
         JDFResourceLink rl = n.getLink(n2, null);
         rl.setCombinedProcessIndex(new JDFIntegerList("1 2"));
         JDFAttributeMap map = new JDFAttributeMap("SheetName", "S1");
         n.setPartStatus(map, EnumNodeStatus.FailedTestRun, null);
         Assert.IsNotNull(n.getNodeInfo());
         Assert.AreNotEqual(n2, n.getNodeInfo());
         Assert.AreEqual(n2, n.getNodeInfo(1));
         Assert.AreEqual(n2, n.getNodeInfo(2));
         Assert.IsNull(n.getNodeInfo(0));
         Assert.IsNull(n.getNodeInfo(3));

         Assert.AreEqual(EnumNodeStatus.FailedTestRun, n.getPartStatus(map));
         n.removeAttribute(AttributeName.TYPES);
         Assert.IsNotNull(n.getNodeInfo(), "invalid types attribute, but still retrieve ni with no cpi");
         Assert.AreNotEqual(n2, n.getNodeInfo(), "invalid types attribute, but...");
      }


      [TestMethod]
      public virtual void testGetParentJDF()
      {
         {
            JDFDoc d = new JDFDoc("JDF");
            JDFNode n = d.getJDFRoot();
            Assert.IsNull(n.getParentJDF());
            JDFNode n2 = (JDFNode)n.appendElement("JDF");
            Assert.AreEqual(n, n2.getParentJDF());
         }
         {
            XMLDoc d = new XMLDoc("ns:foo", "ns");
            KElement e = d.getRoot();
            JDFNode n = (JDFNode)e.appendElement("JDF");
            Assert.IsNull(n.getParentJDF());
            JDFNode n2 = (JDFNode)n.appendElement("JDF");
            Assert.AreEqual(n, n2.getParentJDF());
         }
      }


      [TestMethod]
      public virtual void testGetEnumTypes()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode root = doc.getJDFRoot();
         root.setType("fnarf", false);
         Assert.IsNull(root.getEnumTypes());

         root.setType("ProcessGroup", true);

         root.setTypes(new VString("InkZoneCalculation ConventionalPrinting", null));
         Assert.AreEqual(EnumType.InkZoneCalculation, root.getEnumTypes()[0]);
         Assert.AreEqual(EnumType.ConventionalPrinting, root.getEnumTypes()[1]);
         Assert.AreEqual(2, root.getEnumTypes().Count);

         root.setTypes(new VString("InkZoneCalculation xyz:fnarf ConventionalPrinting", null));
         Assert.IsNull(root.getEnumTypes(), "contains extension");
      }


      [TestMethod]
      public virtual void testGetActivation()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode root = doc.getJDFRoot();
         root.setType(EnumType.ProcessGroup);
         Assert.AreEqual(root.getActivation(true), EnumActivation.Active);
         Assert.IsNull(root.getActivation(false));
         VString types = new VString();
         types.Add("foo");
         types.Add("bar");

         JDFNode n2 = root.addCombined(types);
         Assert.AreEqual(EnumActivation.Active, n2.getActivation(true));
         Assert.IsNull(n2.getActivation(false));

         root.setActivation(EnumActivation.Inactive);
         Assert.AreEqual(EnumActivation.Inactive, root.getActivation(true));
         Assert.AreEqual(EnumActivation.Inactive, root.getActivation(false));
         Assert.AreEqual(EnumActivation.Inactive, n2.getActivation(true));
         Assert.IsNull(n2.getActivation(false));

         n2.setActivation(EnumActivation.Active);
         Assert.AreEqual(EnumActivation.Inactive, n2.getActivation(true));
         Assert.AreEqual(EnumActivation.Active, n2.getActivation(false));
      }


      [TestMethod]
      public virtual void testGetAllTypes()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode root = doc.getJDFRoot();
         root.setType("fnarf", false);
         Assert.AreEqual("fnarf", root.getAllTypes().stringAt(0));
         Assert.AreEqual(1, root.getAllTypes().Count);

         root.setType("Product", false);
         Assert.AreEqual("Product", root.getAllTypes().stringAt(0));
         Assert.AreEqual(1, root.getAllTypes().Count);

         root.setType("ProcessGroup", false);
         Assert.IsNull(root.getAllTypes());

         VString types = new VString();
         types.Add("foo");
         types.Add("bar");
         root.setTypes(types);

         Assert.AreEqual(types, root.getAllTypes());
         root.appendElement("JDF").setAttribute("Type", "fooBar2");
         VString types2 = new VString(types);
         types2[0] = "fooBar2";
         // Assert.AreEqual(root.getAllTypes(),types2);

         root.removeAttribute("Types");

         JDFNode n2 = root.addCombined(types);
         n2.setTypes(types);

         Assert.AreEqual(types2, root.getAllTypes());
         Assert.AreEqual(types, n2.getAllTypes());

         root.addJDFNode("foobar");

         Assert.AreEqual(types, n2.getAllTypes());
         types2.Add("foobar");
         Assert.AreEqual(types2, root.getAllTypes());
      }


      [TestMethod]
      public virtual void testGetMatchingNodes()
      {
         JDFNode n = new JDFDoc("JDF").getJDFRoot();
         n.setJobID("j1");
         n.setJobPartID("p1");
         n.setType(EnumType.Product);
         JDFNode n2 = n.addProduct();
         n2.setJobPartID("p2");
         Assert.IsTrue(n.getvJDFNode(null, null, false).ContainsAll(n.getMatchingNodes(null)));
         Assert.IsTrue(n.getMatchingNodes(null).Contains(n));
         Assert.IsTrue(n.getMatchingNodes(n.getIdentifier()).Contains(n));
         Assert.IsTrue(n.getMatchingNodes(n2.getIdentifier()).Contains(n2));
         Assert.IsFalse(n.getMatchingNodes(n2.getIdentifier()).Contains(n));

      }


      [TestMethod]
      public virtual void testGetMatchingResource()
      {
         JDFParser pars = new JDFParser();
         JDFDoc doc = pars.parseFile(sm_dirTestData + "testMatchRes.jdf");
         JDFNode root = doc.getJDFRoot();
         VElement v = root.getvJDFNode("ProcessGroup", null, false);
         JDFNode ppnode = null;
         for (int i = 0; i < v.Count; i++)
         {
            JDFNode p = (JDFNode)v[i];
            if (p.getCategory().Equals("ContentCreation"))
            {
               ppnode = p;
               break;
            }
         }
         Assert.IsNotNull(ppnode);

         if (ppnode != null)
         {
            Assert.IsTrue(ppnode.getTypes().Contains(EnumType.LayoutElementProduction.getName()));
            JDFResource res = ppnode.getMatchingResource("RunList", JDFNode.EnumProcessUsage.AnyInput, null, 0);
            Assert.AreEqual(ElementName.RUNLIST, res.Name);
            res = ppnode.getMatchingResource("LayoutElementProductionParams", JDFNode.EnumProcessUsage.AnyInput, null, 0);
            Assert.AreEqual(ElementName.LAYOUTELEMENTPRODUCTIONPARAMS, res.Name);
         }
      }


      [TestMethod]
      public virtual void testGetJobPart()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFNode root = doc.getJDFRoot();
         root.setType(EnumType.Product);
         root.setJobPartID("p0");
         JDFNode p1 = root.addJDFNode(EnumType.Product);
         Assert.AreEqual(root.getJobPart("p0", null), root);
         Assert.AreEqual(root.getJobPart("p0.1", null), p1);
         JDFNode p11 = p1.addJDFNode(EnumType.Product);
         Assert.AreEqual(root.getJobPart("p0.1.1", null), p11);
         Assert.AreEqual(p1.getJobPart("p0.1.1", null), p11);
      }


      [TestMethod]
      public virtual void testGetChildJDFNode()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFNode root = doc.getJDFRoot();
         root.setType(EnumType.Product);
         root.setJobPartID("p0");
         root.setID("I1");
         JDFNode p1 = root.addJDFNode(EnumType.Product);
         p1.setID("I2");
         Assert.AreEqual(root.getChildJDFNode("I1", false), root);
         Assert.AreEqual(root.getChildJDFNode("I2", false), p1);
         Assert.AreEqual(root.getChildJDFNode("I2", true), p1);
         JDFNode p11 = p1.addJDFNode(EnumType.Product);
         p11.setID("I11");
         Assert.AreEqual(root.getChildJDFNode("I11", false), p11);
         Assert.IsNull(root.getChildJDFNode("I11", true));
         Assert.AreEqual(root.getChildJDFNode("I11", false), p11);
         Assert.AreEqual(p1.getChildJDFNode("I11", true), p11);
         Assert.AreEqual(p1.getChildJDFNode("I11", false), p11);
      }


      [TestMethod]
      public virtual void testGetCombinedProcessIndex()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFNode root = doc.getJDFRoot();
         root.setType(EnumType.Combined);
         root.setTypes(new VString("Folding Cutting Folding Stitching", " "));
         Assert.AreEqual(-1, root.getCombinedProcessIndex(EnumType.AdhesiveBinding, 0));
         Assert.AreEqual(0, root.getCombinedProcessIndex(EnumType.Folding, 0));
         Assert.AreEqual(2, root.getCombinedProcessIndex(EnumType.Folding, 1));
         Assert.AreEqual(1, root.getCombinedProcessIndex(EnumType.Cutting, 1));
         Assert.AreEqual(3, root.getCombinedProcessIndex(EnumType.Stitching, 1));
      }


      [TestMethod]
      public virtual void testGetLink()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFNode root = doc.getJDFRoot();
         root.setType(EnumType.ImageSetting);
         {
            JDFResource r = root.addResource("foo:res", EnumResourceClass.Parameter, EnumUsage.Input, null, null, "www.foo.com", null);
            JDFResourceLink rl = root.getLink(r, null);
            Assert.IsNotNull(rl);
         }
         {
            JDFResource r = root.addResource(ElementName.MEDIA, null, EnumUsage.Input, null, null, null, null);
            JDFResourceLink rl = root.getLink(r, null);
            Assert.IsNotNull(rl);
         }
      }


      [TestMethod]
      public virtual void testGetResourceLinks()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFNode root = doc.getJDFRoot();
         root.setType(EnumType.ImageSetting);
         VElement v = root.getResourceLinks(null);
         Assert.IsNull(v);
         root.addResource("foo:res", EnumResourceClass.Parameter, EnumUsage.Input, null, null, "www.foo.com", null);
         v = root.getResourceLinks(null);
         Assert.AreEqual(1, v.Count);
         Assert.AreEqual(v[0], root.getResourceLinkPool().getElement(null));
      }


      [TestMethod]
      public virtual void testUpdatePartStatus()
      {
         for (int loop = 0; loop < 2; loop++)
         {
            JDFDoc doc = new JDFDoc("JDF");
            JDFNode root = doc.getJDFRoot();
            root.setType(EnumType.ProcessGroup);
            JDFNode[] nodes = new JDFNode[12];
            JDFAttributeMap map1 = new JDFAttributeMap("Run", "r1");
            JDFAttributeMap map2 = new JDFAttributeMap("Run", "r2");
            JDFAttributeMap map3 = new JDFAttributeMap("Run", "r3");
            JDFAttributeMap map21 = new JDFAttributeMap("Run", "r2");
            map21.put("RunSet", "s1");
            JDFAttributeMap map22 = new JDFAttributeMap("Run", "r2");
            map22.put("RunSet", "s2");
            for (int i = 0; i < 4; i++)
            {
               JDFNode interNode = nodes[3 * i] = root.addProcessGroup(null);
               for (int j = 0; j < 3; j++)
               {
                  JDFNode leafNode = nodes[3 * i + j] = interNode.addCombined(new VString("a b c", " "));
                  leafNode.setPartStatus(map1, EnumNodeStatus.Completed, null);
                  leafNode.setPartStatus(map2, EnumNodeStatus.Waiting, null);
                  leafNode.setPartStatus(map3, EnumNodeStatus.Waiting, null);
                  leafNode.setPartStatus(map21, EnumNodeStatus.InProgress, null);
                  leafNode.setPartStatus(map22, EnumNodeStatus.Waiting, null);
               }
            }
            VJDFAttributeMap vMap = loop == 0 ? null : new VJDFAttributeMap();
            if (loop > 0)
            {
               vMap.Add(map1);
               vMap.Add(map3);
            }
            root.updatePartStatus(vMap, true, true);
            Assert.AreEqual(EnumNodeStatus.Completed, root.getPartStatus(map1));
            Assert.IsNull(root.getPartStatus(null));
            if (loop == 0)
            {
               Assert.AreEqual(EnumNodeStatus.InProgress, root.getPartStatus(map21));
            }
            else
            {
               Assert.AreNotEqual(EnumNodeStatus.InProgress, root.getPartStatus(map21), "only updated run=1");
            }
         }
      }


      [TestMethod]
      public virtual void testToGrayBox()
      {
         JDFNode root = new JDFDoc("JDF").getJDFRoot();

         root.setType(EnumType.Combined);
         VString vs = new VString("Cutting Folding Cutting", " ");
         root.setTypes(vs);
         root.toGrayBox(false);
         Assert.AreEqual(vs, root.getTypes());
         Assert.AreEqual("ProcessGroup", root.getType());

         root.removeAttribute(AttributeName.TYPES);
         root.setType(EnumType.ConventionalPrinting);
         root.toGrayBox(false);
         Assert.AreEqual(new VString("ConventionalPrinting", null), root.getTypes());
         Assert.AreEqual("ProcessGroup", root.getType());

         root.removeAttribute(AttributeName.TYPES);
         root.setType(EnumType.ConventionalPrinting);
         root.toGrayBox(true);
         Assert.IsNull(root.getTypes());
         Assert.AreEqual("ProcessGroup", root.getType());
         JDFNode child = (JDFNode)root.getElement(ElementName.JDF, null, 0);
         Assert.IsNotNull(child);
         Assert.AreEqual(EnumType.ConventionalPrinting, child.getEnumType());
      }


      [TestMethod]
      public virtual void testStatusPartMapVector()
      {
         JDFNode root = new JDFDoc("JDF").getJDFRoot();

         root.setType(EnumType.Combined);
         root.setTypes(new VString("Cutting Folding Cutting", " "));
         for (int i = 0; i < 1; i++)
         {
            EnumVersion v = i == 0 ? EnumVersion.Version_1_1 : EnumVersion.Version_1_3;
            root.setVersion(v);
            VJDFAttributeMap vMapIn = new VJDFAttributeMap();
            if (i == 1)
            {
               vMapIn.Add(new JDFAttributeMap());
            }
            for (int j = 0; j < 3; j++)
            {
               JDFAttributeMap map = new JDFAttributeMap("Run", "R" + j);
               root.setPartStatus(map, EnumNodeStatus.Completed, null);
               vMapIn.Add(map);
            }
            VJDFAttributeMap vMap = root.getStatusPartMapVector();
            Assert.AreEqual(vMapIn, vMap);
         }
      }


      [TestMethod]
      public virtual void testGetLinksForType()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode root = doc.getJDFRoot();

         root.setType(EnumType.Combined);
         root.setTypes(new VString("Cutting Folding Cutting", " "));

         JDFResource r1 = root.addResource("CuttingParams", null, EnumUsage.Input, null, null, null, null);
         JDFResourceLink rl1 = root.getLink(r1, null);
         rl1.setCombinedProcessIndex(new JDFIntegerList(0));

         JDFResource r2 = root.addResource("FoldingParams", null, EnumUsage.Input, null, null, null, null);
         JDFResourceLink rl2 = root.getLink(r2, null);
         rl2.setCombinedProcessIndex(new JDFIntegerList(1));

         JDFResource r3 = root.addResource("CuttingParams", null, EnumUsage.Input, null, null, null, null);
         JDFResourceLink rl3 = root.getLink(r3, null);
         rl3.setCombinedProcessIndex(new JDFIntegerList(2));

         JDFResource r4 = root.addResource("Component", null, EnumUsage.Output, null, null, null, null);
         JDFResourceLink rl4 = root.getLink(r4, null);

         VElement ve = root.getLinksForType(EnumType.Cutting, 0);
         Assert.AreEqual(1, ve.Count);
         Assert.IsTrue(ve.Contains(rl1));
         Assert.IsFalse(ve.Contains(rl4));

         ve = root.getLinksForType(EnumType.Cutting, 1);
         Assert.AreEqual(2, ve.Count);
         Assert.IsTrue(ve.Contains(rl3));
         Assert.IsTrue(ve.Contains(rl4));

         ve = root.getLinksForType(EnumType.Cutting, -1);
         Assert.AreEqual(3, ve.Count);
         Assert.IsTrue(ve.Contains(rl1));
         Assert.IsTrue(ve.Contains(rl3));
         Assert.IsTrue(ve.Contains(rl4));

         ve = root.getLinksForType(EnumType.Folding, 0);
         Assert.AreEqual(1, ve.Count);
         Assert.IsTrue(ve.Contains(rl2));
         Assert.IsFalse(ve.Contains(rl4));

         ve = root.getLinksForCombinedProcessIndex(0);
         Assert.AreEqual(1, ve.Count);
         Assert.IsTrue(ve.Contains(rl1));
         Assert.IsFalse(ve.Contains(rl4));

         ve = root.getLinksForCombinedProcessIndex(1);
         Assert.AreEqual(1, ve.Count);
         Assert.IsTrue(ve.Contains(rl2));
         Assert.IsFalse(ve.Contains(rl4));

         // now check whether this works with no cpi
         rl4.removeAttribute(AttributeName.COMBINEDPROCESSINDEX);
         ve = root.getLinksForType(EnumType.Folding, 0);
         Assert.AreEqual(2, ve.Count);
         Assert.IsTrue(ve.Contains(rl2));
         Assert.IsTrue(ve.Contains(rl4));

         ve = root.getLinksForCombinedProcessIndex(0);
         Assert.AreEqual(2, ve.Count);
         Assert.IsTrue(ve.Contains(rl1));
         Assert.IsTrue(ve.Contains(rl4));

         ve = root.getLinksForCombinedProcessIndex(1);
         Assert.AreEqual(2, ve.Count);
         Assert.IsTrue(ve.Contains(rl2));
         Assert.IsTrue(ve.Contains(rl4));

      }


      [TestMethod]
      public virtual void testGetMatchingResourceStar()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode root = doc.getJDFRoot();
         root.setType((EnumType.Combine));

         for (int i = 0; i < 5; i++)
         {
            JDFResource res = root.appendMatchingResource("RunList", JDFNode.EnumProcessUsage.AnyInput, null);
            Assert.IsNotNull(res);
            Assert.AreEqual(ElementName.RUNLIST, res.Name);
            JDFResource resa = root.getMatchingResource("RunList", JDFNode.EnumProcessUsage.AnyInput, null, i);
            Assert.AreEqual(res, resa);
            JDFResourceLink rlb = root.getMatchingLink("RunList", JDFNode.EnumProcessUsage.AnyInput, i);
            Assert.AreEqual(res, rlb.getTarget());
         }
      }


      [TestMethod]
      public virtual void testGetMinID()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode root = doc.getJDFRoot();
         root.setType(EnumType.ConventionalPrinting);
         int id = root.getMinID();
         Assert.IsTrue(id < 5 && id > 0);
         for (int i = 0; i < 1000; i++)
         {
            root.getAuditPool().addModified(null, null);
         }
         Assert.AreEqual(id + 1000, root.getMinID());
         root.setID("ida123456");
         root.setID("ida123456");
         Assert.AreEqual(123456, root.getMinID());
         root.setID("ida00000");
         Assert.AreEqual(id + 1000, root.getMinID());
      }


      [TestMethod]
      public virtual void testGetMissingLinks()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode root = doc.getJDFRoot();
         root.setType(EnumType.ConventionalPrinting);
         VString vs = root.getMissingLinkVector(999);
         Assert.IsTrue(vs.Contains(ElementName.CONVENTIONALPRINTINGPARAMS + "Link:AnyInput"));
         Assert.IsTrue(vs.Contains(ElementName.COMPONENT + "Link:AnyOutput"));

         VString vsc = new VString();
         vsc.Add(EnumType.InkZoneCalculation);
         vsc.Add(EnumType.ConventionalPrinting);
         root.setCombined(vsc);
         vs = root.getMissingLinkVector(999);
         Assert.IsTrue(vs.Contains(ElementName.PREVIEW + "Link:AnyInput"));
         Assert.IsTrue(vs.Contains(ElementName.CONVENTIONALPRINTINGPARAMS + "Link:AnyInput"));
         Assert.IsTrue(vs.Contains(ElementName.COMPONENT + "Link:AnyOutput"));
      }


      [TestMethod]
      public virtual void testGetMissingLinksProduct()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode root = doc.getJDFRoot();
         root.setType(EnumType.Product);
         VString vs = root.getMissingLinkVector(999);
         Assert.IsTrue(vs.Contains(ElementName.COMPONENT + "Link:AnyOutput"));

         root.addJDFNode(EnumType.ProcessGroup);
         root.appendMatchingResource("Employee", EnumProcessUsage.AnyInput, null);
         vs = root.getMissingLinkVector(999);
         Assert.IsTrue(vs.Contains(ElementName.COMPONENT + "Link:AnyOutput"), "product with sub element still requires an output component");
      }


      [TestMethod]
      public virtual void testGetWorkStepID()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode root = doc.getJDFRoot();
         root.setType(EnumType.ConventionalPrinting);
         root.setJobPartID("p1");
         Assert.AreEqual("p1", root.getWorkStepID(null));
         JDFAttributeMap attributeMap = new JDFAttributeMap("SheetName", "S1");
         Assert.AreEqual("p1", root.getWorkStepID(attributeMap));
         root.setPartStatus(attributeMap, EnumNodeStatus.Cleanup, null);
         Assert.AreEqual("p1", root.getWorkStepID(null));
         Assert.AreEqual("p1", root.getWorkStepID(attributeMap));
         JDFNodeInfo ni = root.getNodeInfo();
         JDFNodeInfo nip = (JDFNodeInfo)ni.getPartition(attributeMap, null);
         nip.setWorkStepID("w2");
         Assert.AreEqual("p1", root.getWorkStepID(null));
         Assert.AreEqual("w2", root.getWorkStepID(attributeMap));
         ni.setWorkStepID("w1");
         Assert.AreEqual("w1", root.getWorkStepID(null));
         Assert.AreEqual(root.getWorkStepID(attributeMap), "w2");
         nip.removeAttribute(AttributeName.WORKSTEPID);
         Assert.AreEqual("w1", root.getWorkStepID(null));
         Assert.AreEqual("w1", root.getWorkStepID(attributeMap));
      }


      [TestMethod]
      public virtual void testGetUnknownLinks()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode root = doc.getJDFRoot();
         root.setType(EnumType.ConventionalPrinting);
         VElement vs = root.getUnknownLinkVector(null, 999);
         Assert.IsNull(vs);

         root.addResource(ElementName.FOLDINGPARAMS, null, EnumUsage.Input, null, null, null, null);

         vs = root.getUnknownLinkVector(null, 999);
         Assert.IsTrue(vs[0] is JDFResourceLink);
         Assert.AreEqual("FoldingParamsLink", ((JDFResourceLink)vs[0]).LocalName);

         root.addResource("foo:barRes", EnumResourceClass.Parameter, EnumUsage.Input, null, null, "www.foo.com", null);

         vs = root.getUnknownLinkVector(null, 999);
         Assert.AreEqual(2, vs.Count);
         Assert.IsTrue(vs[0] is JDFResourceLink);
         Assert.AreEqual("FoldingParamsLink", ((JDFResourceLink)vs[0]).LocalName);
         Assert.AreEqual("foo:barResLink", ((JDFResourceLink)vs[1]).Name);

         VString vsc = new VString();
         vsc.Add(EnumType.InkZoneCalculation);
         vsc.Add(EnumType.ConventionalPrinting);
         root.setCombined(vsc);
         vs = root.getUnknownLinkVector(null, 999);
         Assert.IsTrue(vs[0] is JDFResourceLink);
         Assert.AreEqual("FoldingParamsLink", ((JDFResourceLink)vs[0]).LocalName);
      }

      ///   
      ///	 <summary> * test for getting statusdetails </summary>
      ///	 
      [TestMethod]
      public virtual void testGetPartStatusDetails()
      {
         JDFNode n = new JDFDoc("JDF").getJDFRoot();
         n.setPartStatus(((JDFAttributeMap)null), EnumNodeStatus.Completed, null);
         n.setStatusDetails("foobar");
         Assert.AreEqual("foobar", n.getPartStatusDetails(null));
         JDFNodeInfo nodeInfo = n.appendNodeInfo();
         nodeInfo.setPartUsage(EnumPartUsage.Implicit);
         nodeInfo.setNodeStatus(EnumNodeStatus.Cleanup);
         n.setStatus(EnumNodeStatus.Part);
         Assert.IsNull(n.getPartStatusDetails(null));
         nodeInfo.setNodeStatusDetails("niDetails");
         Assert.AreEqual("niDetails", n.getPartStatusDetails(new JDFAttributeMap("Run", "r1")));
      }
   }
}
