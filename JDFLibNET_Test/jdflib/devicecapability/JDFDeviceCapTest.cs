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
 * JDFDeviceCapTest.cs
 *
 * @author Elena Skobchenko
 *
 * Copyright (c) 2001-2004 The International Cooperation for the Integration
 * of Processes in  Prepress, Press and Postpress (CIP4).  All rights reserved. 
 */

namespace org.cip4.jdflib.devicecapability
{
   using System;
   using System.Collections.Generic;
   using Microsoft.VisualStudio.TestTools.UnitTesting;


   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using EnumListType = org.cip4.jdflib.auto.JDFAutoBasicPreflightTest.EnumListType;
   using EnumContext = org.cip4.jdflib.auto.JDFAutoDevCaps.EnumContext;
   using EnumCombinedMethod = org.cip4.jdflib.auto.JDFAutoDeviceCap.EnumCombinedMethod;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFParser = org.cip4.jdflib.core.JDFParser;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using XMLDoc = org.cip4.jdflib.core.XMLDoc;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using EnumValidationLevel = org.cip4.jdflib.core.KElement.EnumValidationLevel;
   using JDFMatrix = org.cip4.jdflib.datatypes.JDFMatrix;
   using EnumFitsValue = org.cip4.jdflib.datatypes.EnumFitsValue;
   using JDFJMF = org.cip4.jdflib.jmf.JDFJMF;
   using JDFMessage = org.cip4.jdflib.jmf.JDFMessage;
   using JDFMessageService = org.cip4.jdflib.jmf.JDFMessageService;
   using JDFResponse = org.cip4.jdflib.jmf.JDFResponse;
   using EnumType = org.cip4.jdflib.jmf.JDFMessage.EnumType;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using EnumProcessUsage = org.cip4.jdflib.node.JDFNode.EnumProcessUsage;
   using JDFDevice = org.cip4.jdflib.resource.JDFDevice;
   using JDFAction = org.cip4.jdflib.resource.devicecapability.JDFAction;
   using JDFActionPool = org.cip4.jdflib.resource.devicecapability.JDFActionPool;
   using JDFDevCap = org.cip4.jdflib.resource.devicecapability.JDFDevCap;
   using JDFDevCapPool = org.cip4.jdflib.resource.devicecapability.JDFDevCapPool;
   using JDFDevCaps = org.cip4.jdflib.resource.devicecapability.JDFDevCaps;
   using JDFDeviceCap = org.cip4.jdflib.resource.devicecapability.JDFDeviceCap;
   using JDFNameState = org.cip4.jdflib.resource.devicecapability.JDFNameState;
   using JDFNumberState = org.cip4.jdflib.resource.devicecapability.JDFNumberState;
   using JDFTest = org.cip4.jdflib.resource.devicecapability.JDFTest;
   using JDFTestPool = org.cip4.jdflib.resource.devicecapability.JDFTestPool;
   using EnumTerm = org.cip4.jdflib.resource.devicecapability.JDFTerm.EnumTerm;
   using JDFContentObject = org.cip4.jdflib.resource.process.JDFContentObject;
   using JDFLayout = org.cip4.jdflib.resource.process.JDFLayout;
   using JDFRunList = org.cip4.jdflib.resource.process.JDFRunList;
   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   [TestClass]
   public class JDFDeviceCapTest : JDFTestCaseBase
   {

      private JDFDeviceCap devicecap;
      private JDFDeviceCap devicecapProduct;
      private JDFDevice device;

      [TestInitialize]
      public override void setUp()
      {
         JDFDoc doc = new JDFDoc("Device");
         device = (JDFDevice)doc.getRoot();
         base.setUp();
         {
            devicecap = device.appendDeviceCap();
            devicecap.setCombinedMethod(EnumCombinedMethod.None);
            devicecap.setTypeExpression("(fnarf)|(blub)");
            devicecap.setTypes(new VString("fnarf blub", null));
            devicecap.setGenericAttributes(new VString("*", null));

            JDFDevCapPool dcp = devicecap.appendDevCapPool();
            JDFDevCaps dcs = devicecap.appendDevCaps();
            dcs.setContext(EnumContext.Element);
            dcs.setName("AuditPool");
            dcs.setRequired(true);
            JDFDevCap dc = dcp.appendDevCap();
            dc.setID("dc_AuditPool");
            dcs.setDevCapRef(dc);
            dc = dc.appendDevCap();
            dc.setName("Created");
            dc.setID("dc_Created");

            dcs = devicecap.appendDevCaps();
            dcs.setContext(EnumContext.Element);
            dcs.setName("AncestorPool");
            dc = dcs.appendDevCap();
            dc.setMinOccurs(0);
            dc.setID("dc_AncestorPool");
            JDFDevCap dc2 = dc.appendDevCap();
            dc2.setID("dc_Ancestor");
            dc2.setName("Ancestor");

            for (int pu = 0; pu < 2; pu++)
            {
               dcs = devicecap.appendDevCaps();
               dcs.setContext(EnumContext.Resource);
               dcs.setName("RunList");
               dcs.setLinkUsage(EnumUsage.Input);
               dcs.setProcessUsage(pu == 0 ? "Document" : "Marks");
               dc = dcs.appendDevCap();
               if (pu == 0)
               {
                  dc.setID("dc_RL_Doc");
                  dc.setMinOccurs(1);
               }
               else
               {
                  dc.setID("dc_RL_Mark");
                  dc.setMinOccurs(0);
               }
            }

            dcs = devicecap.appendDevCaps();
            dcs.setContext(EnumContext.Resource);
            dcs.setName("Layout");
            dcs.setLinkUsage(EnumUsage.Input);
            dc = dcs.appendDevCap();
            dc.setID("dc_Layout");
            dc.setMinOccurs(1);
            JDFDevCap coDC = dc.appendDevCap();
            coDC.setName(ElementName.CONTENTOBJECT);
            coDC.setMinOccurs(2);
            JDFNumberState st = coDC.appendNumberState(AttributeName.CTM);
            st.setRequired(true);
            st.setListType(EnumListType.List);
            st.setMinOccurs(6);
            st.setMaxOccurs(6);
            st.setHasDefault(true);
            st.setAttribute("DefaultValue", "1 0 0 1 1 1");

            dcs = devicecap.appendDevCaps();
            dcs.setContext(EnumContext.Link);
            dcs.setLinkUsage(EnumUsage.Input);
            dcs.setName("Layout");
            dc = dcs.appendDevCap();
            dc.setID("dc_LayoutLink");

            dcs = devicecap.appendDevCaps();
            dcs.setContext(EnumContext.Element);
            dcs.setName("JDF");
            dc = dcp.appendDevCap();
            dc.setID("dc_JDF");
            dcs.setDevCapRef(dc);
            doc.write2File(sm_dirTestDataTemp + "devCapDefaults.jdf", 2, false);
         }
         {
            devicecapProduct = device.appendDeviceCap();

            List<ValuedEnum> vMethods = new List<ValuedEnum>();
            vMethods.Add(EnumCombinedMethod.None);
            vMethods.Add(EnumCombinedMethod.ProcessGroup);
            vMethods.Add(EnumCombinedMethod.Combined);
            devicecapProduct.setCombinedMethod(vMethods);
            devicecapProduct.setTypeExpression("((fnarf)|(blub))( (fnarf)|(blub))*");
            devicecapProduct.setTypes(new VString("fnarf blub", null));

            JDFDevCapPool dcp = devicecapProduct.appendDevCapPool();
            JDFDevCaps dcs = devicecap.appendDevCaps();
            dcs.setContext(EnumContext.Element);
            dcs.setName("AuditPool");
            dcs.setRequired(true);
            JDFDevCap dc = dcp.appendDevCap();
            dc.setID("dc_AuditPool");
            dcs.setDevCapRef(dc);
            dc = dc.appendDevCap();
            dc.setName("Created");
            dc.setID("dc_Created");

            dcs = devicecap.appendDevCaps();
            dcs.setContext(EnumContext.Resource);
            dcs.setName("Layout");
            dcs.setLinkUsage(EnumUsage.Input);
            dc = dcs.appendDevCap();
            dc.setID("dc_Layout");
            dc.setMinOccurs(1);
            JDFDevCap coDC = dc.appendDevCap();
            coDC.setName(ElementName.CONTENTOBJECT);
            coDC.setMinOccurs(2);
            coDC.setMaxOccurs(999);
            JDFNumberState st = coDC.appendNumberState(AttributeName.CTM);
            st.setRequired(true);
            st.setListType(EnumListType.List);
            st.setMinOccurs(6);
            st.setMaxOccurs(6);
            st.setHasDefault(true);
            st.setAttribute("DefaultValue", "1 0 0 1 1 1");

            dcs = devicecap.appendDevCaps();
            dcs.setContext(EnumContext.Link);
            dcs.setLinkUsage(EnumUsage.Input);
            dcs.setName("Layout");
            dc = dcs.appendDevCap();
            dc.setID("dc_LayoutLink");

            dcs = devicecap.appendDevCaps();
            dcs.setContext(EnumContext.Element);
            dcs.setName("JDF");
            dc = dcp.appendDevCap();
            dc.setID("dc_JDF");
            dcs.setDevCapRef(dc);
         }

      }


      [TestMethod]
      public virtual void testGetBadJDFInfo()
      {
         JDFDoc d = JDFDoc.parseFile(sm_dirTestData + "Device_Elk_ConventionalPrinting2.xml");
         JDFDeviceCap dc = (JDFDeviceCap)d.getRoot().getXPathElement("/JMF/Response/DeviceList/DeviceInfo/Device/DeviceCap");
         Assert.IsNotNull(dc);
         JDFDoc d2 = JDFDoc.parseFile(sm_dirTestData + "Elk_ConventionalPrinting.jdf");
         JDFNode cpNode = d2.getJDFRoot();
         Assert.IsNotNull(cpNode);
         XMLDoc outDoc = dc.getBadJDFInfo(cpNode, EnumFitsValue.Allowed, EnumValidationLevel.Complete);
         Assert.IsNull(outDoc, "devcaps are consistently evaluated");
      }


      [TestMethod]
      public virtual void testAction()
      {
         JDFDoc d = new JDFDoc(ElementName.DEVICECAP);
         JDFDeviceCap dc = (JDFDeviceCap)d.getRoot();
         JDFTestPool tp = dc.appendTestPool();
         JDFTest test = tp.appendTest();
         JDFActionPool ap = dc.appendActionPool();
         JDFAction a = ap.appendAction();
         a.setTest(test);
         Assert.AreEqual(test, a.getTest());
         Assert.IsTrue(a.hasAttribute("TestRef"));
      }


      [TestMethod]
      public virtual void testGetDevCapsByName()
      {
         JDFDevCaps dcs = devicecap.getDevCapsByName("AuditPool", null, null, null, 0);
         Assert.IsNotNull(dcs);
         Assert.AreEqual("AuditPool", dcs.getName());
         dcs = devicecap.getDevCapsByName("Layout", EnumContext.Resource, null, null, 0);
         Assert.IsNotNull(dcs);
         Assert.AreEqual("Layout", dcs.getName());
         Assert.AreEqual("dc_Layout", dcs.getDevCap().getID());
         dcs = devicecap.getDevCapsByName("Layout", EnumContext.Link, null, null, 0);
         Assert.IsNotNull(dcs);
         Assert.AreEqual("Layout", dcs.getName());
         Assert.AreEqual(dcs.getDevCap().getID(), "dc_LayoutLink");
         dcs = devicecap.getDevCapsByName("Layout", EnumContext.Element, null, null, 0);
         Assert.IsNull(dcs);
         dcs = devicecap.getDevCapsByName("RunList", null, null, EnumProcessUsage.Marks, 0);
         Assert.IsNotNull(dcs);
         dcs = devicecap.getDevCapsByName("RunList", null, null, EnumProcessUsage.Ancestor, 0);
         Assert.IsNull(dcs);
      }


      [TestMethod]
      public virtual void testDevCapsMinOccurs()
      {
         JDFDevCaps dcs = devicecap.getDevCapsByName("AuditPool", null, null, null, 0);
         Assert.AreEqual(1, dcs.getMinOccurs());
      }


      [TestMethod]
      public virtual void testDevCapsMaxOccurs()
      {
         JDFDevCaps dcs = devicecap.getDevCapsByName("AuditPool", null, null, null, 0);
         Assert.AreEqual(1, dcs.getMaxOccurs());
      }


      [TestMethod]
      public virtual void testLogic()
      {
         JDFDoc d = new JDFDoc(ElementName.DEVICECAP);
         JDFDeviceCap dc = (JDFDeviceCap)d.getRoot();
         dc.appendDevCapPool();

         JDFTestPool tp = dc.appendTestPool();
         JDFTest test = tp.appendTest();
         test.appendTerm(EnumTerm.and);
         JDFActionPool ap = dc.appendActionPool();
         JDFAction a = ap.appendAction();
         a.setTest(test);
         // TODO more
      }


      [TestMethod]
      public virtual void testGetCombinedMethod()
      {
         JDFDoc d = new JDFDoc(ElementName.DEVICECAP);
         JDFDeviceCap dc = (JDFDeviceCap)d.getRoot();
         List<ValuedEnum> v = new List<ValuedEnum>();
         v.Add(EnumCombinedMethod.None);
         CollectionAssert.AreEqual(v, dc.getCombinedMethod(), "default is none");

      }


      [TestMethod]
      public virtual void testDeviceCapIsValid()
      {
         JDFParser p = new JDFParser();
         string docDevCap = "DevCaps_Product_MISPrepress_ICS_Minimal.jdf";
         JDFDoc jmfDevCap = p.parseFile(sm_dirTestData + docDevCap);
         Assert.IsNotNull(jmfDevCap, "Parse of file " + docDevCap + " failed");
         JDFJMF jmfRoot = jmfDevCap.getJMFRoot();
         Assert.IsNotNull(jmfRoot, "jmfRoot == null Can't start Test");
         JDFDeviceCap deviceCap = (JDFDeviceCap)jmfRoot.getChildByTagName("DeviceCap", "", 0, null, false, true);
         Assert.IsTrue(deviceCap.isValid(KElement.EnumValidationLevel.Incomplete));
      }


      [TestMethod]
      public virtual void testGetExecutableJDF()
      {
         string docTest = "MISPrepress_ICS_Minimal.jdf";
         string docDevCap = "DevCaps_Product_MISPrepress_ICS_Minimal.jdf";

         // parse input file
         JDFParser p = new JDFParser();
         JDFDoc jmfDevCap = p.parseFile(sm_dirTestData + docDevCap);
         JDFJMF jmfRoot = null;
         Assert.IsNotNull(jmfDevCap, "Parse of file " + docDevCap + " failed");
         jmfRoot = jmfDevCap.getJMFRoot();
         Assert.IsNotNull(jmfRoot, "jmfRoot == null Can't start Test");
         XMLDoc docOutDevCap = jmfRoot.getOwnerDocument_KElement();
         docOutDevCap.write2File(sm_dirTestDataTemp + "_" + docDevCap, 0, true);

         JDFDoc jdfTest = p.parseFile(sm_dirTestData + docTest);
         JDFNode jdfRoot = jdfTest.getJDFRoot();
         Assert.IsTrue(jdfRoot != null, "jdfRoot is null");

         if (jdfRoot != null)
         {
            jdfRoot.getOwnerDocument_KElement();
            JDFDeviceCap deviceCap = (JDFDeviceCap)jmfRoot.getChildByTagName("DeviceCap", null, 0, null, false, true);

            EnumFitsValue testlists = EnumFitsValue.Allowed;
            EnumValidationLevel level = KElement.EnumValidationLevel.Complete;
            VElement vExecNodes = deviceCap.getExecutableJDF(jdfRoot, testlists, level);
            if (vExecNodes == null)
            {
               Console.WriteLine(docDevCap + ": found No matching JDFNode");
            }
            else
            {
               for (int n = 0; n < vExecNodes.Count; n++)
               {
                  // XMLDoc docExecNodes = ((JDFNode)
                  // vExecNodes.elementAt(n)).getOwnerDocument_KElement();
                  // docExecNodes.write2File ("temp\\" + "_" + docTest
                  // +"_ExecNode" + (n+1) +
                  // ".jdf", 0);
                  Console.WriteLine(vExecNodes[n]);

               }
            }

            XMLDoc testResult = deviceCap.getBadJDFInfo(jdfRoot, testlists, level);
            if (testResult != null)
            {
               testResult.write2File(sm_dirTestDataTemp + "_BugReport.xml", 0, true);
            }
         }
      }


      [TestMethod]
      public virtual void testGetMatchingTypeNodeVector()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setType("bar", false);
         Assert.IsNull(devicecap.getMatchingTypeNodeVector(n));

         n.setType("fnarf", false);
         Assert.IsTrue(devicecap.getMatchingTypeNodeVector(n).Contains(n));

         devicecap.setCombinedMethod(EnumCombinedMethod.ProcessGroup);
         n.setType("ProcessGroup", true);
         JDFNode n2 = n.addJDFNode("fnarf");
         Assert.IsFalse(devicecap.getMatchingTypeNodeVector(n).Contains(n), "Only the actually matching nodes are returned, not their ancestors");
         Assert.IsTrue(devicecap.getMatchingTypeNodeVector(n).Contains(n2));
         Assert.IsNull(devicecap.getMatchingTypeNodeVector(n2), "want pg but have local node");
      }


      [TestMethod]
      public virtual void testGetMatchingDeviceCapVector()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setType("bar", false);
         Assert.IsNull(device.getMatchingDeviceCapVector(n, true));
         Assert.IsNull(device.getMatchingDeviceCapVector(n, false));
         n.setType("fnarf", false);
         Assert.AreEqual(2, device.getMatchingDeviceCapVector(n, true).Count);
         Assert.AreEqual(2, device.getMatchingDeviceCapVector(n, false).Count);
         n.setType("ProcessGroup", true);
         JDFNode n2 = n.addJDFNode("fnarf");
         Assert.AreEqual(1, device.getMatchingDeviceCapVector(n, true).Count);
         Assert.AreEqual(devicecapProduct, device.getMatchingDeviceCapVector(n, false)[0]);
         Assert.AreEqual(2, device.getMatchingDeviceCapVector(n2, false).Count);
      }


      [TestMethod]
      public virtual void testProcessUsage()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setType("fnarf", false);

         EnumFitsValue testlists = EnumFitsValue.Allowed;
         EnumValidationLevel level = KElement.EnumValidationLevel.Complete;
         VElement vExecNodes = devicecap.getExecutableJDF(n, testlists, level);
         Assert.IsNull(vExecNodes, "missing resources");

         JDFLayout lo = (JDFLayout)n.addResource(ElementName.LAYOUT, null, EnumUsage.Input, null, null, null, null);
         lo.appendContentObject().setCTM(new JDFMatrix("1 0 0 1 0 0"));
         lo.appendContentObject().setCTM(new JDFMatrix("1 0 0 1 10 20"));

         JDFRunList rlDoc = (JDFRunList)n.addResource(ElementName.RUNLIST, null, EnumUsage.Input, EnumProcessUsage.Document, null, null, null);
         vExecNodes = devicecap.getExecutableJDF(n, testlists, level);
         Assert.IsNotNull(vExecNodes, "no missing resources");

         n.addResource(ElementName.RUNLIST, null, EnumUsage.Input, EnumProcessUsage.Marks, null, null, null);
         vExecNodes = devicecap.getExecutableJDF(n, testlists, level);
         Assert.IsNotNull(vExecNodes, "no missing resources");

         JDFResourceLink rl = n.getLink(rlDoc, null);
         rl.setUsage(EnumUsage.Output);
         vExecNodes = devicecap.getExecutableJDF(n, testlists, level);
         Assert.IsNull(vExecNodes, "no required runlist doc");

         rl.setUsage(EnumUsage.Input);
         vExecNodes = devicecap.getExecutableJDF(n, testlists, level);
         Assert.IsNotNull(vExecNodes, "no required runlist doc");

         JDFDevCaps dcsRLDoc = devicecap.getDevCapsByName("RunList", null, null, EnumProcessUsage.Document, 0);
         JDFNameState ns = dcsRLDoc.getDevCap().appendNameState("RunTag");
         ns.setRequired(true);

         vExecNodes = devicecap.getExecutableJDF(n, testlists, level);
         Assert.IsNull(vExecNodes, "incomplete required runlist doc");

         ns.setRequired(false);
         vExecNodes = devicecap.getExecutableJDF(n, testlists, level);
         Assert.IsNotNull(vExecNodes, "incomplete required runlist doc");

         JDFDevCaps dcsRLMarks = devicecap.getDevCapsByName("RunList", null, null, EnumProcessUsage.Marks, 0);
         JDFNameState nsMarks = dcsRLMarks.getDevCap().appendNameState("PageNames");
         nsMarks.setRequired(true);

         vExecNodes = devicecap.getExecutableJDF(n, testlists, level);
         Assert.IsNull(vExecNodes, "incomplete required runlist marks");
      }


      [TestMethod]
      public virtual void testMatchesType()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setType("bar", false);
         Assert.IsFalse(devicecap.matchesType(n, true));
         Assert.IsFalse(devicecap.matchesType(n, false));
         Assert.IsFalse(device.matchesType(n, true));
         Assert.IsFalse(device.matchesType(n, false));

         n.setType("fnarf", false);
         Assert.IsTrue(devicecap.matchesType(n, true));
         Assert.IsTrue(devicecap.matchesType(n, false));
         Assert.IsTrue(device.matchesType(n, true));
         Assert.IsTrue(device.matchesType(n, false));

         n.setType("blub", false);
         Assert.IsTrue(devicecap.matchesType(n, true));
         Assert.IsTrue(devicecap.matchesType(n, false));
         Assert.IsTrue(device.matchesType(n, true));
         Assert.IsTrue(device.matchesType(n, false));

         n.setType("Combined", false);
         n.setTypes(new VString("blub fnarf", " "));
         Assert.IsFalse(devicecap.matchesType(n, true));
         Assert.IsFalse(devicecap.matchesType(n, false));
         Assert.IsTrue(devicecapProduct.matchesType(n, true));
         Assert.IsTrue(devicecapProduct.matchesType(n, false));
         Assert.IsTrue(device.matchesType(n, false));

         devicecap.setCombinedMethod(EnumCombinedMethod.ProcessGroup);
         n.setType("ProcessGroup", true);
         JDFNode n2 = n.addJDFNode("fnarf");

         Assert.IsFalse(devicecap.matchesType(n, true));
         Assert.IsTrue(devicecap.matchesType(n, false));
         Assert.IsTrue(device.matchesType(n, true));
         Assert.IsTrue(device.matchesType(n, false));
         Assert.IsFalse(devicecap.matchesType(n2, true), "method pg for local individual process");
         Assert.IsFalse(devicecap.matchesType(n2, false));
         Assert.IsTrue(devicecapProduct.matchesType(n2, false));
         Assert.IsTrue(device.matchesType(n2, false));
      }


      [TestMethod]
      public virtual void testSetDefaultsFromCaps()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setType("fnarf", false);
         devicecap.setDefaultsFromCaps(n, true, false);
         Assert.IsNotNull(n.getResourceLinks("Layout", null, null));
         JDFLayout lo = (JDFLayout)n.getResourcePool().getPoolChild(0, "Layout", null, null);
         JDFContentObject contentObject = lo.getContentObject(0);
         Assert.IsNotNull(contentObject);
         Assert.AreEqual(new JDFMatrix("1 0 0 1 1 1"), contentObject.getCTM());
         Assert.IsNotNull(lo.getContentObject(1));
      }


      [TestMethod]
      public virtual void testCreateModuleCaps()
      {
         devicecap.createModuleCaps(null);
         Assert.IsNotNull(devicecap.getModulePool());
      }


      [TestMethod]
      public virtual void testGetNamePathVector()
      {
         {
            JDFDevCap dc = (JDFDevCap)devicecap.getChildWithAttribute(null, AttributeName.ID, null, "dc_Ancestor", 0, false);
            VString v = dc.getNamePathVector(true);
            Assert.AreEqual(1, v.Count);
            Assert.AreEqual("JDF/AncestorPool/Ancestor", v.stringAt(0));
         }
         {
            JDFDevCap dc = (JDFDevCap)devicecap.getChildWithAttribute(null, AttributeName.ID, null, "dc_Layout", 0, false);
            VString v = dc.getNamePathVector(true);
            Assert.IsTrue(v.Count > 1);
            Assert.AreEqual("JDF/ResourcePool/Layout", v.stringAt(0));
         }
         {
            JDFDevCap dc = (JDFDevCap)devicecap.getChildWithAttribute(null, AttributeName.ID, null, "dc_LayoutLink", 0, false);
            VString v = dc.getNamePathVector(true);
            Assert.AreEqual(1, v.Count);
            Assert.AreEqual("JDF/ResourceLinkPool/LayoutLink", v.stringAt(0));
         }
         {
            JDFDevCap dc = (JDFDevCap)devicecap.getChildWithAttribute(null, AttributeName.ID, null, "dc_Created", 0, false);
            VString v = dc.getNamePathVector(true);
            Assert.AreEqual(1, v.Count);
            Assert.AreEqual("JDF/AuditPool/Created", v.stringAt(0));
         }
         {
            JDFDevCap dc = (JDFDevCap)devicecap.getChildWithAttribute(null, AttributeName.ID, null, "dc_JDF", 0, false);
            VString v = dc.getNamePathVector(true);
            Assert.AreEqual(1, v.Count);
            Assert.AreEqual("JDF", v.stringAt(0));
         }
      }


      [TestMethod]
      public virtual void testGetMessageServiceForJMFType()
      {
         JDFMessage m = JDFJMF.createJMF(JDFMessage.EnumFamily.Acknowledge, EnumType.KnownDevices).getMessageElement(null, null, 0);
         JDFResponse resp = JDFJMF.createJMF(JDFMessage.EnumFamily.Response, EnumType.KnownMessages).getResponse(0);
         JDFMessageService ms = resp.appendMessageService();
         ms.setType(EnumType.AbortQueueEntry);
         ms.setAcknowledge(true);
         Assert.IsNull(JDFDeviceCap.getMessageServiceForJMFType(m, resp), "wrong type");
         JDFMessageService ms2 = resp.appendMessageService();
         ms2.setType(EnumType.KnownDevices);
         ms2.setQuery(true);
         Assert.IsNull(JDFDeviceCap.getMessageServiceForJMFType(m, resp), "wrong type");
         JDFMessageService ms3 = resp.appendMessageService();
         ms3.setType(EnumType.KnownDevices);
         ms3.setAcknowledge(true);
         Assert.AreEqual(ms3, JDFDeviceCap.getMessageServiceForJMFType(m, resp), "family and type match");
      }
   }
}
