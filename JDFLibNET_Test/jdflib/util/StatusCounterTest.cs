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
 * @author muchadie
 */

namespace org.cip4.jdflib.util
{
   using Microsoft.VisualStudio.TestTools.UnitTesting;

   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using EnumDeviceStatus = org.cip4.jdflib.auto.JDFAutoDeviceInfo.EnumDeviceStatus;
   using EnumWorkType = org.cip4.jdflib.auto.JDFAutoMISDetails.EnumWorkType;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using VElement = org.cip4.jdflib.core.VElement;
   using EnumNodeStatus = org.cip4.jdflib.core.JDFElement.EnumNodeStatus;
   using EnumVersion = org.cip4.jdflib.core.JDFElement.EnumVersion;
   using EnumValidationLevel = org.cip4.jdflib.core.KElement.EnumValidationLevel;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using MISCPGoldenTicket = org.cip4.jdflib.goldenticket.MISCPGoldenTicket;
   using JDFDeviceInfo = org.cip4.jdflib.jmf.JDFDeviceInfo;
   using JDFJMF = org.cip4.jdflib.jmf.JDFJMF;
   using JDFJobPhase = org.cip4.jdflib.jmf.JDFJobPhase;
   using JDFResponse = org.cip4.jdflib.jmf.JDFResponse;
   using EnumFamily = org.cip4.jdflib.jmf.JDFMessage.EnumFamily;
   using EnumType = org.cip4.jdflib.jmf.JDFMessage.EnumType;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using JDFNotification = org.cip4.jdflib.resource.JDFNotification;
   using JDFComponent = org.cip4.jdflib.resource.process.JDFComponent;
   using JDFEmployee = org.cip4.jdflib.resource.process.JDFEmployee;
   using JDFExposedMedia = org.cip4.jdflib.resource.process.JDFExposedMedia;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;

   ///
   /// <summary> * @author Rainer Prosi, Heidelberger Druckmaschinen
   /// * </summary>
   /// 
   [TestClass]
   public class StatusCounterTest : JDFTestCaseBase
   {
      protected internal JDFDoc d;
      private JDFNode n;
      private StatusCounter sc;
      private string deviceID;
      private string resID;
      private JDFExposedMedia xpMedia;
      private JDFEmployee employee;


      [TestInitialize]
      public override void setUp()
      {
         d = creatXMDoc();
         n = d.getJDFRoot();
         xpMedia = (JDFExposedMedia)n.getMatchingResource("ExposedMedia", null, null, 0);
         JDFResourceLink rlxp = n.getLink(xpMedia, null);
         rlxp.setAmount(100, null);
         sc = new StatusCounter(n, null, null);
         deviceID = "Status-counter-TestDevice";
         sc.setDeviceID(deviceID);
         resID = xpMedia.getID();
         sc.setFirstRefID(resID);
         sc.addPhase(resID, 200, 0, true);
         employee = (JDFEmployee)new JDFDoc("Employee").getRoot();
         employee.setPersonalID("P1");
         base.setUp();
      }


      [TestMethod]
      public virtual void testDeviceID()
      {
         bool bChanged = sc.setPhase(EnumNodeStatus.InProgress, "i", EnumDeviceStatus.Running, "r");
         Assert.IsTrue(bChanged);
         JDFDoc docJMF = sc.getDocJMFPhaseTime();
         JDFResponse sig = (JDFResponse)docJMF.getJMFRoot().getMessageElement(EnumFamily.Response, EnumType.Status, 0);
         JDFDeviceInfo deviceInfo = sig.getDeviceInfo(0);
         Assert.AreEqual(deviceID, deviceInfo.getDeviceID());
      }


      [TestMethod]
      public virtual void testWasteAmount()
      {
         VJDFAttributeMap singleMap = new VJDFAttributeMap();
         singleMap.Add(xpMedia.getPartMapVector(false)[0]);

         MISCPGoldenTicket gt = new MISCPGoldenTicket(2, EnumVersion.Version_1_3, 2, 2, false, singleMap);
         gt.good = 1000;
         gt.waste = 100;
         gt.assign(null);
         n = gt.getNode();
         JDFComponent c = (JDFComponent)n.getResource(ElementName.COMPONENT, null, 0);
         JDFMedia m = (JDFMedia)n.getResource(ElementName.MEDIA, null, 0);
         JDFResourceLink rl = n.getLink(c, null);
         JDFResourceLink rlMedia = n.getLink(m, null);
         VElement vRL = new VElement();
         vRL.Add(rl);
         vRL.Add(rlMedia);
         sc = new StatusCounter(null, null, null);
         sc.setTrackWaste(rl.getrRef(), true);
         sc.setTrackWaste(rlMedia.getrRef(), true);
         sc.setActiveNode(n, c.getPartMapVector(false), vRL);
         Assert.AreEqual(100, sc.getPlannedWaste(rlMedia.getrRef()), 0);
         Assert.AreEqual(1000, sc.getPlannedAmount(rl.getrRef()), 0);
      }


      [TestMethod]
      public virtual void testAddPhase()
      {
         bool bChanged = sc.setPhase(EnumNodeStatus.InProgress, "i", EnumDeviceStatus.Running, "r");
         Assert.IsTrue(bChanged);
         JDFDoc docJMF = sc.getDocJMFPhaseTime();
         JDFResponse sig = (JDFResponse)docJMF.getJMFRoot().getMessageElement(EnumFamily.Response, EnumType.Status, 0);
         JDFJobPhase jp = sig.getDeviceInfo(0).getJobPhase(0);
         Assert.AreEqual(200, jp.getAmount(), 0);
         sc.addPhase(resID, 0, 100, true);
         sc.setTrackWaste(resID, true);
         JDFResourceLink rlXM = n.getLink(xpMedia, null);
         for (int loop = 1; loop < 4; loop++)
         {
            bChanged = sc.setPhase(EnumNodeStatus.InProgress, "i", EnumDeviceStatus.Running, "r");
            Assert.IsFalse(bChanged);
            docJMF = sc.getDocJMFPhaseTime();
            sig = (JDFResponse)docJMF.getJMFRoot().getMessageElement(EnumFamily.Response, EnumType.Status, 0);
            jp = sig.getDeviceInfo(0).getJobPhase(0);
            Assert.AreEqual(200, jp.getAmount(), 0, "multiple setPhase calls do not modify");
            Assert.AreEqual(200, rlXM.getActualAmount(new JDFAttributeMap("Condition", "Good")), 0, "multiple setPhase calls do not modify: " + loop);
            Assert.AreEqual(200.0, jp.getPercentCompleted(), 0, "% " + loop);
            sc.addPhase(resID, 0, 100, true);
            Assert.AreEqual(loop * 100, jp.getWaste(), 0, "" + loop);
            Assert.AreEqual(100 * loop, rlXM.getActualAmount(new JDFAttributeMap("Condition", "Waste")), 0, "multiple setPhase calls do Stack: " + loop);
         }
         sc.setWorkType(EnumWorkType.Alteration);
         bChanged = sc.setPhase(EnumNodeStatus.InProgress, "ii", EnumDeviceStatus.Running, "r");
         Assert.IsTrue(bChanged);
         docJMF = sc.getDocJMFPhaseTime();
         sig = (JDFResponse)docJMF.getJMFRoot().getMessageElement(EnumFamily.Response, EnumType.Status, 0);
         jp = sig.getDeviceInfo(0).getJobPhase(0);
         Assert.AreEqual(200, jp.getAmount(), 0);
         Assert.AreEqual(400, jp.getWaste(), 0);
         Assert.IsTrue(jp.hasAttribute(AttributeName.PHASEAMOUNT));
         sig = (JDFResponse)docJMF.getJMFRoot().getMessageElement(EnumFamily.Response, EnumType.Status, 1);
         jp = sig.getDeviceInfo(0).getJobPhase(0);
         Assert.AreEqual(0.0, jp.getPhaseAmount(), 0.0);
         Assert.AreEqual(EnumWorkType.Alteration, jp.getMISDetails().getWorkType());

         sc.setFirstRefID("dummy");
         sc.addPhase(resID, 0, 100, true);
         sc.setTrackWaste(resID, true);
         sc.setPhase(EnumNodeStatus.InProgress, "i", EnumDeviceStatus.Running, "r");
         docJMF = sc.getDocJMFPhaseTime();
         sig = (JDFResponse)docJMF.getJMFRoot().getMessageElement(EnumFamily.Response, EnumType.Status, 0);
         jp = sig.getDeviceInfo(0).getJobPhase(0);
         Assert.IsFalse(jp.hasAttribute(AttributeName.AMOUNT));
         Assert.AreEqual(EnumWorkType.Alteration, jp.getMISDetails().getWorkType());
      }


      [TestMethod]
      public virtual void testEvent()
      {
         Assert.IsNull(sc.getDocJMFNotification(false));
         sc.setEvent("id", "value", "blah blah");
         d = sc.getDocJMFNotification(false);
         JDFDoc d2 = sc.getDocJMFNotification(false);
         Assert.IsTrue(d.getRoot().isEqual(d2.getRoot()));
         d = sc.getDocJMFNotification(true);
         d2 = sc.getDocJMFNotification(false);
         Assert.IsNull(d2);
         JDFJMF jmf = d.getJMFRoot();
         JDFNotification noti = jmf.getSignal(0).getNotification();
         Assert.AreEqual(noti.getJobID(), n.getJobID(true));
         Assert.IsNotNull(noti.getEvent());
         d.write2File(sm_dirTestDataTemp + "jmfNotification.jmf", 2, false);
         Assert.IsTrue(jmf.isValid(EnumValidationLevel.Complete));
         sc.setEvent("id1", "value", "blah blah");
         sc.setEvent("id2", "value", "blah blah blah");
         d = sc.getDocJMFNotification(false);
         jmf = d.getJMFRoot();
         Assert.AreEqual(2, jmf.numChildElements(ElementName.SIGNAL, null));
         sc.setEvent("id2", "value", "blah blah blah");
         d = sc.getDocJMFNotification(true);
         jmf = d.getJMFRoot();
         Assert.AreEqual(3, jmf.numChildElements(ElementName.SIGNAL, null));
         d = sc.getDocJMFNotification(true);
         Assert.IsNull(d);
      }

      ///   
      ///	 <summary> * test for memory leaks in clone </summary>
      ///	 
      [TestMethod]
      public virtual void testMemLeak()
      {
         // Java to C# Conversion - Divide count by 1000 to reduce execution time for now
         //for (int i = 0; i < 100000; i++)
         for (int i = 0; i < 100; i++)
         {
            sc.getDocJMFPhaseTime();
            sc.getDocJMFNotification(true);
            sc.getDocJMFResource();
         }
         Assert.AreEqual(mem, getCurrentMem(), 100000);
      }


      [TestMethod]
      public virtual void testEmployee()
      {
         Assert.IsFalse(sc.removeEmployee(employee));
         Assert.AreEqual(sc.addEmployee(employee), 1);
         Assert.IsTrue(sc.removeEmployee(employee));
         Assert.AreEqual(sc.addEmployee(employee), 1);

         JDFDoc docJMF = sc.getDocJMFPhaseTime();
         JDFResponse sig = (JDFResponse)docJMF.getJMFRoot().getMessageElement(EnumFamily.Response, EnumType.Status, -1);
         JDFDeviceInfo deviceInfo = sig.getDeviceInfo(0);
         Assert.IsTrue(deviceInfo.getEmployee(0).isEqual(employee));
         sc.removeEmployee(employee);
         docJMF = sc.getDocJMFPhaseTime();
         sig = (JDFResponse)docJMF.getJMFRoot().getMessageElement(EnumFamily.Response, EnumType.Status, 0);
         deviceInfo = sig.getDeviceInfo(0);
         Assert.IsNull(deviceInfo.getEmployee(0));
      }


      [TestMethod]
      public virtual void testIdle()
      {
         JDFExposedMedia m = (JDFExposedMedia)n.getMatchingResource("ExposedMedia", null, null, 0);
         bool bChanged = sc.setPhase(EnumNodeStatus.InProgress, "i", EnumDeviceStatus.Running, "r");
         Assert.IsTrue(bChanged);
         JDFDoc docJMF = sc.getDocJMFPhaseTime();
         JDFResponse sig = (JDFResponse)docJMF.getJMFRoot().getMessageElement(EnumFamily.Response, EnumType.Status, 0);
         JDFDeviceInfo deviceInfo = sig.getDeviceInfo(0);
         JDFJobPhase jp = deviceInfo.getJobPhase(0);
         Assert.AreEqual(200, jp.getAmount(), 0);
         sc.addPhase(resID, 0, 100, true);
         sc.setTrackWaste(m.getID(), true);
         bChanged = sc.setPhase(EnumNodeStatus.InProgress, "i", EnumDeviceStatus.Running, "r");
         Assert.IsFalse(bChanged);
         docJMF = sc.getDocJMFPhaseTime();
         sig = (JDFResponse)docJMF.getJMFRoot().getMessageElement(EnumFamily.Response, EnumType.Status, 0);
         bChanged = sc.setPhase(EnumNodeStatus.Completed, null, EnumDeviceStatus.Idle, null);
         Assert.IsTrue(bChanged);

         sc.setActiveNode(null, null, null);
         bChanged = sc.setPhase(null, null, EnumDeviceStatus.Idle, null);
         Assert.IsFalse(bChanged);
         bChanged = sc.setPhase(null, null, EnumDeviceStatus.Idle, "very idle");
         Assert.IsTrue(bChanged);

         docJMF = sc.getDocJMFPhaseTime();
         sig = (JDFResponse)docJMF.getJMFRoot().getMessageElement(EnumFamily.Response, EnumType.Status, 0);
         deviceInfo = sig.getDeviceInfo(0);
         jp = deviceInfo.getJobPhase(0);
         Assert.IsNull(jp);
      }

      // public void testMultiModuleJob()
      // {
      // MultiModuleStatusCounter msc = new MultiModuleStatusCounter(
      // MultiType.JOB);
      // JDFResponse idlePhase = msc.getStatusResponse().getJMFRoot()
      // .getResponse(0);
      // Assert.AreEqual(idlePhase.numChildElements(ElementName.DEVICEINFO, null),
      // 1);
      // StatusCounter scRIP = new StatusCounter(n, null, null);
      // scRIP.setDeviceID("d1");
      // msc.addModule(scRIP);
      // JDFExposedMedia m = (JDFExposedMedia) n.getMatchingResource(
      // "ExposedMedia", null, null, 0);
      // String resID = m.getID();
      // scRIP.setFirstRefID(resID);
      // scRIP.addPhase(resID, 200, 0);
      //
      // JDFNode n2 = creatXMDoc().getJDFRoot();
      // StatusCounter scRIP2 = new StatusCounter(n2, null, null);
      // scRIP2.setDeviceID("d2");
      // msc.addModule(scRIP2);
      // JDFResponse idlePhase2 = msc.getStatusResponse().getJMFRoot()
      // .getResponse(0);
      // Assert.AreEqual(idlePhase2.numChildElements(ElementName.DEVICEINFO, null),
      // 2);
      //
      // }


      [TestMethod]
      public virtual void testMultiModule()
      {
         StatusCounter scRIP = new StatusCounter(n, null, null);
         scRIP.addModule("ID_RIP", "RIP");
         StatusCounter scSetter = new StatusCounter(n, null, null);
         scSetter.addModule("ID_Setter", "Platesetter");

         MultiModuleStatusCounter msc = new MultiModuleStatusCounter();
         msc.addModule(scRIP);
         msc.addModule(scSetter);

         JDFExposedMedia m = (JDFExposedMedia)n.getMatchingResource("ExposedMedia", null, null, 0);
         resID = m.getID();
         scRIP.setFirstRefID(resID);
         scRIP.addPhase(resID, 200, 0, true);
         bool bChanged = scRIP.setPhase(EnumNodeStatus.InProgress, "i", EnumDeviceStatus.Running, "r");
         Assert.IsTrue(bChanged);
         JDFDoc docJMF = scRIP.getDocJMFPhaseTime();
         JDFResponse sig = (JDFResponse)docJMF.getJMFRoot().getMessageElement(EnumFamily.Response, EnumType.Status, 0);
         JDFDeviceInfo deviceInfo = sig.getDeviceInfo(0);
         JDFJobPhase jp = deviceInfo.getJobPhase(0);
         Assert.AreEqual(200, jp.getAmount(), 0);
         scRIP.addPhase(resID, 0, 100, true);
         scRIP.setTrackWaste(m.getID(), true);
         bChanged = scRIP.setPhase(EnumNodeStatus.InProgress, "i", EnumDeviceStatus.Running, "r");
         Assert.IsFalse(bChanged);
         JDFDoc dJMFAll = msc.getStatusResponse();
         Assert.AreEqual(dJMFAll.getRoot().getChildrenByTagName(ElementName.JOBPHASE, null, null, false, true, -1).Count, 1);
         scSetter.setPhase(EnumNodeStatus.InProgress, "seti", EnumDeviceStatus.Running, "run");
         scSetter.setFirstRefID(resID);
         scSetter.addPhase(resID, 400, 0, true);
         dJMFAll = msc.getStatusResponse();
         Assert.AreEqual(2, dJMFAll.getRoot().getChildrenByTagName(ElementName.JOBPHASE, null, null, false, true, -1).Count, "1 RIP, 1 setter");

         scRIP.setActiveNode(null, null, null);
         bChanged = scRIP.setPhase(null, null, EnumDeviceStatus.Idle, null);
         dJMFAll = msc.getStatusResponse();
         Assert.AreEqual(1, dJMFAll.getRoot().getChildrenByTagName(ElementName.JOBPHASE, null, null, false, true, -1).Count);

         scSetter.setActiveNode(null, null, null);
         bChanged = scSetter.setPhase(null, null, EnumDeviceStatus.Idle, null);
         dJMFAll = msc.getStatusResponse();
         Assert.AreEqual(0, dJMFAll.getRoot().getChildrenByTagName(ElementName.JOBPHASE, null, null, false, true, -1).Count);
      }
   }
}
