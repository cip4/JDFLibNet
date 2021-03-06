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



namespace org.cip4.jdflib.examples
{
   using System.Threading;
   using Microsoft.VisualStudio.TestTools.UnitTesting;


   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using EnumListType = org.cip4.jdflib.auto.JDFAutoBasicPreflightTest.EnumListType;
   using EnumDeviceStatus = org.cip4.jdflib.auto.JDFAutoDeviceInfo.EnumDeviceStatus;
   using EnumSides = org.cip4.jdflib.auto.JDFAutoDigitalPrintingParams.EnumSides;
   using EnumReason = org.cip4.jdflib.auto.JDFAutoResourceAudit.EnumReason;
   using EnumStitchType = org.cip4.jdflib.auto.JDFAutoStitchingParams.EnumStitchType;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFAudit = org.cip4.jdflib.core.JDFAudit;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using EnumNodeStatus = org.cip4.jdflib.core.JDFElement.EnumNodeStatus;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using JDFIntegerList = org.cip4.jdflib.datatypes.JDFIntegerList;
   using JDFIntegerRange = org.cip4.jdflib.datatypes.JDFIntegerRange;
   using JDFIntegerRangeList = org.cip4.jdflib.datatypes.JDFIntegerRangeList;
   using JDFDeviceInfo = org.cip4.jdflib.jmf.JDFDeviceInfo;
   using JDFJMF = org.cip4.jdflib.jmf.JDFJMF;
   using JDFJobPhase = org.cip4.jdflib.jmf.JDFJobPhase;
   using JDFMessage = org.cip4.jdflib.jmf.JDFMessage;
   using JDFSignal = org.cip4.jdflib.jmf.JDFSignal;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using EnumProcessUsage = org.cip4.jdflib.node.JDFNode.EnumProcessUsage;
   using EnumType = org.cip4.jdflib.node.JDFNode.EnumType;
   using JDFAuditPool = org.cip4.jdflib.pool.JDFAuditPool;
   using JDFModulePhase = org.cip4.jdflib.resource.JDFModulePhase;
   using JDFModuleStatus = org.cip4.jdflib.resource.JDFModuleStatus;
   using JDFPageList = org.cip4.jdflib.resource.JDFPageList;
   using JDFPhaseTime = org.cip4.jdflib.resource.JDFPhaseTime;
   using EnumPartIDKey = org.cip4.jdflib.resource.JDFResource.EnumPartIDKey;
   using EnumResStatus = org.cip4.jdflib.resource.JDFResource.EnumResStatus;
   using JDFDevCap = org.cip4.jdflib.resource.devicecapability.JDFDevCap;
   using JDFDevCaps = org.cip4.jdflib.resource.devicecapability.JDFDevCaps;
   using JDFDeviceCap = org.cip4.jdflib.resource.devicecapability.JDFDeviceCap;
   using JDFNameState = org.cip4.jdflib.resource.devicecapability.JDFNameState;
   using JDFComponent = org.cip4.jdflib.resource.process.JDFComponent;
   using JDFContentData = org.cip4.jdflib.resource.process.JDFContentData;
   using JDFContentList = org.cip4.jdflib.resource.process.JDFContentList;
   using JDFDigitalPrintingParams = org.cip4.jdflib.resource.process.JDFDigitalPrintingParams;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;
   using JDFMiscConsumable = org.cip4.jdflib.resource.process.JDFMiscConsumable;
   using JDFPageData = org.cip4.jdflib.resource.process.JDFPageData;
   using JDFRunList = org.cip4.jdflib.resource.process.JDFRunList;
   using JDFUsageCounter = org.cip4.jdflib.resource.process.JDFUsageCounter;
   using JDFStitchingParams = org.cip4.jdflib.resource.process.postpress.JDFStitchingParams;
   using JDFDate = org.cip4.jdflib.util.JDFDate;
   using StatusCounter = org.cip4.jdflib.util.StatusCounter;
   using StatusUtil = org.cip4.jdflib.util.StatusUtil;
   using AmountBag = org.cip4.jdflib.util.StatusUtil.AmountBag;

   //JAVA TO VB & C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
   //ORIGINAL LINE: @SuppressWarnings("deprecation") public class DigiPrintTest extends JDFTestCaseBase
   [TestClass]
   public class DigiPrintTest : JDFTestCaseBase
   {
      private JDFDoc doc;
      private JDFNode n;
      private JDFComponent comp;
      private JDFRunList ruli;
      private JDFResourceLink rlComp;
      private JDFDigitalPrintingParams digiParams;
      private JDFMedia med;
      private JDFResourceLink rlMedia;

      ///   
      ///	 <summary> * test amount handling
      ///	 * 
      ///	 * @return </summary>
      ///	 
      [TestMethod]
      public virtual void testModules()
      {
         JDFAuditPool ap = n.getCreateAuditPool();
         ap.appendXMLComment("JDF 1.3 compatible auditing of module phases - note that modulephase start and end times are set outside of the phasetime start and end times", null);
         JDFPhaseTime pt = ap.addPhaseTime(EnumNodeStatus.Setup, null, null);
         JDFPhaseTime pt2 = ap.addPhaseTime(EnumNodeStatus.InProgress, null, null);
         JDFDate date = new JDFDate();
         JDFModulePhase mpRIP = pt.appendModulePhase();
         JDFModulePhase mpRIP2 = pt2.appendModulePhase();
         mpRIP.setStatus(EnumNodeStatus.InProgress);
         mpRIP2.setStatus(EnumNodeStatus.InProgress);
         mpRIP2.setDescriptiveName("This ModulePhase is actually the same as the initial ModulePhase in the setup PhaseTime");
         mpRIP.setModuleType("Imaging");
         mpRIP2.setModuleType("Imaging");
         pt.setStart(date);
         mpRIP.setStart(date);
         mpRIP2.setStart(date);
         date.addOffset(0, 5, 0, 0);
         pt.setEnd(date);

         JDFModulePhase mpPrint = pt2.appendModulePhase();
         mpPrint.setStatus(EnumNodeStatus.InProgress);
         pt2.setStart(date);
         mpPrint.setStart(date);
         date.addOffset(0, 30, 0, 0);
         mpRIP.setEnd(date);
         mpRIP2.setEnd(date);

         date.addOffset(0, 70, 0, 0);
         pt2.setEnd(date);
         mpPrint.setEnd(date);
         mpPrint.setModuleType("Printer");
         doc.write2File(sm_dirTestDataTemp + "DigiPrintModule1.jdf", 2, false);
      }


      [TestMethod]
      public virtual void testModulesUpdate()
      {
         JDFAuditPool ap = n.getCreateAuditPool();
         ap.appendXMLComment("JDF 1.3 compatible auditing of module phases with updates", null);
         JDFPhaseTime pt = ap.addPhaseTime(EnumNodeStatus.Setup, null, null);
         JDFPhaseTime pt2 = ap.addPhaseTime(EnumNodeStatus.InProgress, null, null);
         JDFPhaseTime pt3 = ap.addPhaseTime(EnumNodeStatus.InProgress, null, null);
         JDFDate date = new JDFDate();
         JDFModulePhase mpRIP = pt.appendModulePhase();
         mpRIP.setModuleType("Imaging");
         JDFModulePhase mpJob = pt.appendModulePhase();
         mpJob.setModuleType("Manual");
         mpJob.setStatus(EnumNodeStatus.InProgress);
         JDFModulePhase mpPrint = pt.appendModulePhase();
         mpPrint.setModuleType("Printing");

         mpRIP.setStatus(EnumNodeStatus.InProgress);
         pt.setStart(date);
         mpRIP.setStart(date);
         date.addOffset(0, 5, 0, 0);
         pt.setEnd(date);

         pt2.copyElement(mpRIP, null);
         pt2.copyElement(mpJob, null);
         pt2.copyElement(mpPrint, null);
         mpPrint.setStatus(EnumNodeStatus.InProgress);
         pt2.setStart(date);
         mpPrint.setStart(date);
         date.addOffset(0, 30, 0, 0);
         mpRIP.setEnd(date);

         date.addOffset(0, 70, 0, 0);
         pt2.setEnd(date);
         mpPrint.setEnd(date);
         pt3.copyElement(mpRIP, null);
         pt3.copyElement(mpJob, null);
         pt3.copyElement(mpPrint, null);

         doc.write2File(sm_dirTestDataTemp + "DigiPrintModuleUpdate.jdf", 2, false);
      }

      ///   
      ///	 <summary> * test amount handling
      ///	 * 
      ///	 * @return </summary>
      ///	 
      [TestMethod]
      public virtual void testModules14()
      {
         VString v = new VString("orig fullList end", null);
         for (int i = 0; i < v.Count; i++)
         {
            reSetUp();
            string testType = v.stringAt(i);
            JDFAuditPool ap = n.getCreateAuditPool();
            ap.appendXMLComment("JDF 1.3 incompatible auditing of module phases the REQUIRED time attributes are not set in the ModulePhase elements\n" + "- note that phases may now arbitrarily overlap\n" + "The modulePhase elements now only specify which modules are involved, times are all defined by the phasetime proper", null);
            ap.appendXMLComment("The following phaseTime is executed by one module - the RIP,which executes two process steps (Interpreting and Rendering)", null);
            JDFPhaseTime ptRIP = ap.addPhaseTime(EnumNodeStatus.Setup, null, null);
            JDFDate date = new JDFDate();
            ptRIP.setStart(date);

            JDFDoc jmfDoc = new JDFDoc("JMF");
            JDFJMF jmf = jmfDoc.getJMFRoot();
            jmf.setDescriptiveName("Initial phase when the RIP starts up");
            JDFSignal signal = jmf.appendSignal(JDFMessage.EnumType.Status);
            JDFDeviceInfo di = signal.appendDeviceInfo();

            JDFJobPhase jpRIP = di.appendJobPhase();
            di.setDeviceStatus(EnumDeviceStatus.Setup);
            jpRIP.setStartTime(date);
            jpRIP.setStatus(EnumNodeStatus.Setup);
            jpRIP.setJobID(n.getJobID(true));
            jpRIP.setJobPartID(n.getJobPartID(true));

            JDFModuleStatus msRIP = jpRIP.appendModuleStatus();
            msRIP.setCombinedProcessIndex(new JDFIntegerList("0 1"));
            msRIP.setModuleType("Imaging");
            msRIP.setModuleID("ID_Imaging");

            JDFModulePhase mpRIP = ptRIP.appendModulePhase();
            mpRIP.setCombinedProcessIndex(new JDFIntegerList("0 1"));
            mpRIP.setModuleType("Imaging");
            mpRIP.setModuleID("ID_Imaging");

            JDFModuleStatus msPrint = di.appendModuleStatus();
            msPrint.setCombinedProcessIndex(new JDFIntegerList("2"));
            msPrint.setModuleType("Printer");
            msPrint.setModuleID("ID_Printer");

            JDFModuleStatus msStitch = di.appendModuleStatus();
            msStitch.setCombinedProcessIndex(new JDFIntegerList("3"));
            msStitch.setModuleType("Stitcher");
            msStitch.setModuleID("ID_Stitcher");

            jmfDoc.write2File(sm_dirTestDataTemp + "moduleStatus" + testType + "0.jmf", 2, false);
            date.addOffset(0, 5, 0, 0);
            jmf.setTimeStamp(date);

            JDFJobPhase jpPrint = di.appendJobPhase();
            di.setDeviceStatus(EnumDeviceStatus.Running);
            jpPrint.setStatus(EnumNodeStatus.InProgress);
            jpPrint.setStartTime(date);
            jpPrint.setJobID(n.getJobID(true));
            jpPrint.setJobPartID(n.getJobPartID(true));

            msPrint = jpPrint.appendModuleStatus();
            msPrint.setCombinedProcessIndex(new JDFIntegerList("2"));
            msPrint.setModuleType("Printer");
            msPrint.setModuleID("ID_Printer");

            msStitch = jpPrint.appendModuleStatus();
            msStitch.setCombinedProcessIndex(new JDFIntegerList("3"));
            msStitch.setModuleType("Stitcher");
            msStitch.setModuleID("ID_Stitcher");

            di.removeChildren(ElementName.MODULESTATUS, null, null);
            jmf.setDescriptiveName("Phase when the Printer and Finisher start up; RIP is still RIPping");
            jmfDoc.write2File(sm_dirTestDataTemp + "moduleStatus" + testType + "1.jmf", 2, false);

            ap.appendXMLComment("The following phaseTime is executed by two modules - sticher and printer", null);
            JDFPhaseTime ptPrint = ap.addPhaseTime(EnumNodeStatus.InProgress, null, null);
            JDFModulePhase mpPrint = ptPrint.appendModulePhase();
            mpPrint.setCombinedProcessIndex(new JDFIntegerList("2"));
            mpPrint.setModuleType("Printer");
            mpPrint.setModuleID("ID_Printer");
            ptPrint.setStart(date);

            JDFModulePhase mpStitch = ptPrint.appendModulePhase();
            mpStitch.setCombinedProcessIndex(new JDFIntegerList("3"));
            mpStitch.setModuleType("Stitcher");
            mpStitch.setModuleID("ID_Stitcher");
            date.addOffset(0, 30, 0, 0);
            ptRIP.setEnd(date);

            JDFDeviceInfo di2 = null;
            if (i < 2)
            {
               JDFSignal signal2 = jmf.appendSignal(JDFMessage.EnumType.Status);
               di2 = (JDFDeviceInfo)signal2.copyElement(di, null);
               di2.removeChild(ElementName.JOBPHASE, null, 0);
               if (i == 1)
               {
                  JDFModuleStatus directMSRip = (JDFModuleStatus)di2.copyElement(msRIP, null);
                  directMSRip.setDeviceStatus(EnumDeviceStatus.Idle);
               }
            }
            else
            {
               jpRIP.setAttribute("EndTime", date.DateTimeISO);
               jpRIP.setDescriptiveName("Added EndTime to explicitly close phase");
            }
            jmf.setTimeStamp(date);
            jmf.setDescriptiveName("Phase when the RIP has completed, Printer and Finisher are still RIPping");
            jmfDoc.write2File(sm_dirTestDataTemp + "moduleStatus" + testType + "2.jmf", 2, false);

            date.addOffset(0, 70, 0, 0);
            ptPrint.setEnd(date);
            jmf.setTimeStamp(date);

            if (i < 2)
            {
               signal.deleteNode();
               signal = jmf.appendSignal(JDFMessage.EnumType.Status);
               di = (JDFDeviceInfo)signal.copyElement(di2, null);
               di.removeChild(ElementName.JOBPHASE, null, 0);
               di.removeChild(ElementName.MODULESTATUS, null, 0);
               di.setDeviceStatus(EnumDeviceStatus.Idle);
               signal.appendXMLComment("Or should the complete list of modules also be specified here?", di);
            }
            else
            {
               jpRIP.deleteNode();
               jpPrint.setAttribute("EndTime", date.DateTimeISO);
               jpPrint.setDescriptiveName("Added EndTime to explicitly close phase");
            }
            jmf.setDescriptiveName("Phase when the Printer and Finisher have completed");
            jmfDoc.write2File(sm_dirTestDataTemp + "moduleStatus" + testType + "3.jmf", 2, false);
            doc.write2File(sm_dirTestDataTemp + "DigiPrintModule.1.4" + testType + ".jdf", 2, false);
         }
      }

      ///   
      ///	 <summary> * test devcaps for usagecounters
      ///	 * 
      ///	 * @return </summary>
      ///	 
      [TestMethod]
      public virtual void testUsageCounterDevCaps()
      {
         JDFDoc duc = new JDFDoc("DeviceCap");
         JDFDeviceCap devicecap = (JDFDeviceCap)duc.getRoot();
         JDFDevCaps dcs = devicecap.appendDevCaps();
         dcs.setName(ElementName.USAGECOUNTER);
         JDFDevCap dc = dcs.appendDevCapInPool();
         dc.setMinOccurs(3);
         dc.setMaxOccurs(3);
         JDFNameState counterID = dc.appendNameState(AttributeName.COUNTERID);
         counterID.setAllowedValueList(new VString("ID_Black ID_Color ID_Total", null));
         counterID.setListType(EnumListType.SingleValue);
         duc.write2File(sm_dirTestDataTemp + "DevCapUsageCounter.jdf", 2, false);
      }

      ///   
      ///	 <summary> * test amount handling
      ///	 * 
      ///	 * @return </summary>
      ///	 
      [TestMethod]
      public virtual void testDirectProof()
      {
         n.setXMLComment("Example workflow with initioal warmup phase, one direct proof and 100 copies of 10 sheets each.\n" + "The direct proof is acceptable and included in the good output");
         digiParams.setDirectProofAmount(1);
         digiParams.setXMLComment("1 initial proof is requested");
         rlComp.setAmount(100, null);
         JDFAuditPool ap = n.getAuditPool();

         VElement vRL = new VElement();
         vRL.Add(rlComp);
         vRL.Add(rlMedia);

         StatusCounter stCounter = new StatusCounter(n, null, vRL);
         stCounter.setDeviceID("MyDevice");
         string mediaRef = rlMedia.getrRef();
         stCounter.setTrackWaste(mediaRef, true);
         string compRef = rlComp.getrRef();
         stCounter.setTrackWaste(compRef, false);

         doc.write2File(sm_dirTestDataTemp + "DigiPrintAmount_initial.jdf", 2, false);

         stCounter.setPhase(EnumNodeStatus.InProgress, "Waste", EnumDeviceStatus.Running, null);
         ap.getLastPhase(null, null).setXMLComment("Phase where warm up waste is produced");
         stCounter.addPhase(mediaRef, 0, 2, true);
         stCounter.addPhase(compRef, 0, 20, true);

         stCounter.setPhase(EnumNodeStatus.InProgress, "Waste", EnumDeviceStatus.Running, null);

         stCounter.setPhase(EnumNodeStatus.InProgress, "Good", EnumDeviceStatus.Running, null);
         stCounter.addPhase(mediaRef, 1, 0, true);
         stCounter.addPhase(compRef, 10, 0, true);
         stCounter.setPhase(EnumNodeStatus.InProgress, "Good", EnumDeviceStatus.Running, null);
         ap.getLastPhase(null, null).setXMLComment("Phase where 1 proof is produced");

         stCounter.setPhase(EnumNodeStatus.Stopped, "WaitForApproval", EnumDeviceStatus.Stopped, null);
         ap.getLastPhase(null, null).setXMLComment("Phase where the proof is evaluated while the device is stopped");
         stCounter.setPhase(EnumNodeStatus.InProgress, "Good", EnumDeviceStatus.Running, null);

         stCounter.addPhase(mediaRef, 99, 0, true);
         stCounter.addPhase(compRef, 990, 0, true);
         stCounter.setPhase(EnumNodeStatus.InProgress, "Good", EnumDeviceStatus.Running, null);
         ap.getLastPhase(null, null).setXMLComment("Phase where the 100 copies are produced");

         stCounter.setPhase(EnumNodeStatus.Completed, "Idle", EnumDeviceStatus.Idle, null);
         stCounter.setResourceAudit(mediaRef, EnumReason.ProcessResult);
         doc.write2File(sm_dirTestDataTemp + "DigiPrintProof_final.jdf", 2, false);

      }

      ///   
      ///	 <summary> * test amount handling
      ///	 * 
      ///	 * @return </summary>
      ///	 
      [TestMethod]
      public virtual void testAmount()
      {
         rlComp.setAmount(20, null);
         rlComp.setDescriptiveName("The link points to 20 planned and 20 good + 2 Waste brochures");

         JDFMiscConsumable mc = (JDFMiscConsumable)n.appendMatchingResource(ElementName.MISCCONSUMABLE, EnumProcessUsage.AnyInput, null);
         mc.setResStatus(EnumResStatus.Available, false);
         mc.setConsumableType("FooBar");
         mc.setUnit("Fnarfs");
         mc.setDescriptiveName("FooBars are always measured in Fnarfs");
         JDFResourceLink rlmc = n.getLink(mc, null);
         rlmc.setAmount(42, null);
         rlmc.setDescriptiveName("The link points to 42 actual FooBars");

         JDFUsageCounter uc = (JDFUsageCounter)n.appendMatchingResource(ElementName.USAGECOUNTER, EnumProcessUsage.AnyInput, null);
         uc.setResStatus(EnumResStatus.Available, false);
         uc.setCounterTypes(new VString("Click", " "));
         JDFResourceLink rlu = n.getLink(uc, null);
         rlu.setAmount(200, null);
         rlu.setDescriptiveName("The link points to 200 actual clicks");

         rlMedia.setAmount(100, null);
         rlMedia.setDescriptiveName("The link points to 100 actual sheets");

         Thread.Sleep(1000);
         comp.setResStatus(EnumResStatus.Available, true);

         VElement vRL = new VElement();
         vRL.Add(rlComp);
         vRL.Add(rlu);
         vRL.Add(rlMedia);
         vRL.Add(rlmc);
         StatusUtil stUtil = new StatusUtil(n, null, vRL);
         stUtil.setDeviceID("MyDevice");
         stUtil.setTrackWaste(rlMedia, true);
         stUtil.setTrackWaste(rlComp, true);
         stUtil.setCopyResInResInfo(rlu, true);

         doc.write2File(sm_dirTestDataTemp + "DigiPrintAmount_initial.jdf", 2, false);

         AmountBag[] bags = new AmountBag[vRL.Count];
         bags[0] = new AmountBag(rlComp.getrRef());
         bags[1] = new AmountBag(rlu.getrRef());
         bags[2] = new AmountBag(rlMedia.getrRef());
         bags[3] = new AmountBag(rlmc.getrRef());
         stUtil.setPhase(EnumNodeStatus.InProgress, "Waste", EnumDeviceStatus.Running, null, bags);
         JDFDoc docStatusJMF = stUtil.getDocJMFPhaseTime();
         docStatusJMF.write2File(sm_dirTestDataTemp + "DigiPrintAmountStatus0.jmf", 2, false);
         JDFDoc docResJMF = stUtil.getDocJMFResource();
         docResJMF.write2File(sm_dirTestDataTemp + "DigiPrintAmountResource0.jmf", 2, false);

         bags[0].addPhase(0, 2, true);
         bags[1].addPhase(0, 20, true);
         bags[2].addPhase(0, 10, true);
         bags[3].addPhase(0, 0, true);
         stUtil.setPhase(EnumNodeStatus.InProgress, "Waste", EnumDeviceStatus.Running, null, bags);
         docStatusJMF = stUtil.getDocJMFPhaseTime();
         docStatusJMF.write2File(sm_dirTestDataTemp + "DigiPrintAmountStatus1.jmf", 2, false);
         docResJMF = stUtil.getDocJMFResource();
         docResJMF.write2File(sm_dirTestDataTemp + "DigiPrintAmountResource1.jmf", 2, false);

         bags[0].addPhase(15, 0, true);
         bags[1].addPhase(150, 0, true);
         bags[2].addPhase(75, 0, true);
         bags[3].addPhase(32, 0, true);
         stUtil.setPhase(EnumNodeStatus.InProgress, "Good", EnumDeviceStatus.Running, null, bags);
         docStatusJMF = stUtil.getDocJMFPhaseTime();
         docStatusJMF.write2File(sm_dirTestDataTemp + "DigiPrintAmountStatus2.jmf", 2, false);
         docResJMF = stUtil.getDocJMFResource();
         docResJMF.write2File(sm_dirTestDataTemp + "DigiPrintAmountResource2.jmf", 2, false);

         bags[0].addPhase(5, 0, false);
         bags[1].addPhase(50, 0, false);
         bags[2].addPhase(25, 0, false);
         bags[3].addPhase(11, 0, false);
         stUtil.setPhase(EnumNodeStatus.InProgress, "Good", EnumDeviceStatus.Running, null, bags);
         docStatusJMF = stUtil.getDocJMFPhaseTime();
         docStatusJMF.write2File(sm_dirTestDataTemp + "DigiPrintAmountStatus3.jmf", 2, false);
         docResJMF = stUtil.getDocJMFResource();
         docResJMF.write2File(sm_dirTestDataTemp + "DigiPrintAmountResource3.jmf", 2, false);

         bags[0].addPhase(0, 0, true);
         bags[1].addPhase(0, 0, true);
         bags[2].addPhase(0, 0, true);
         bags[3].addPhase(0, 0, true);
         stUtil.setPhase(EnumNodeStatus.Completed, "Idle", EnumDeviceStatus.Idle, null, bags);
         docStatusJMF = stUtil.getDocJMFPhaseTime();
         docStatusJMF.write2File(sm_dirTestDataTemp + "DigiPrintAmountStatus4.jmf", 2, false);
         docResJMF = stUtil.getDocJMFResource();
         docResJMF.write2File(sm_dirTestDataTemp + "DigiPrintAmountResource4.jmf", 2, false);

         doc.write2File(sm_dirTestDataTemp + "DigiPrintAmount_final.jdf", 2, false);
      }


      [TestMethod]
      public virtual void testVariableManifests()
      {
         ruli.setXMLComment("the set / doc / ... structure is transferred from the pre-impositioning pdl");

         JDFPageList pl = (JDFPageList)n.addResource(ElementName.PAGELIST, null);
         pl.setResStatus(EnumResStatus.Available, false);

         JDFContentList cl = (JDFContentList)pl.appendContentList().makeRootResource(null, null, true);
         cl.setResStatus(EnumResStatus.Available, false);
         cl.setXMLComment("Should we allow for content-data cross references to forther contentdata fields?");
         ruli.refPageList(pl);
         comp.refPageList(pl);
         int pageCount = 0;
         digiParams.setSides(EnumSides.TwoSidedFlipY);
         digiParams.setXMLComment("the sides attribute may be overridden by explicitly or implicitly missing runlist input elements");

         VString vRun = new VString("Letter BrochureMale BrochureFemale", null);

         JDFStitchingParams sp = (JDFStitchingParams)n.addResource(ElementName.STITCHINGPARAMS, EnumUsage.Input);
         med.setXMLComment("Media Partitioning is convenience only- the actual media selection is done by the digitalprintingparams MediaRef");
         for (int i = 0; i < vRun.Count; i++)
         {
            string part = vRun[i];
            JDFMedia partMedia = (JDFMedia)med.addPartition(EnumPartIDKey.Run, part);
            partMedia.setProductID(part + "Media");

            JDFDigitalPrintingParams digiPart = (JDFDigitalPrintingParams)digiParams.addPartition(EnumPartIDKey.Run, part);
            digiPart.refMedia(partMedia);

            sp.setXMLComment("how are multiple runs stitched together e.g. cover + body?");
            JDFStitchingParams spPart = (JDFStitchingParams)sp.addPartition(EnumPartIDKey.Run, part);
            if (i == 0)
            {
               spPart.setNoOp(true);
               spPart.setDescriptiveName("The letter is a loose leaf collection");
            }
            else
            {
               spPart.setNumberOfStitches(3);
               spPart.setStitchType(EnumStitchType.Saddle);
            }
         }

         // loop over records
         for (int i = 0; i < 10; i++)
         {
            JDFContentData letter = cl.appendContentData();
            letter.setContentType("Letter");
            JDFContentData brochure = cl.appendContentData();
            brochure.setContentType("Brochure");
            KElement lMeta = letter.appendElement("ContentMetadata");
            // TODO apply new example
            lMeta.setAttribute("Record", "" + i);
            string gender = i % 2 == 0 ? "Male" : "Female";
            lMeta.setAttribute("Gender", gender);
            lMeta.setXMLComment("Note that the final format of the metadata element is open");
            KElement bMeta = brochure.appendElement("Metadata");
            bMeta.setAttribute("Record", "" + i);
            bMeta.setAttribute("Gender", gender);

            JDFRunList runSet = (JDFRunList)ruli.addPartition(EnumPartIDKey.RunSet, "Record" + i);
            JDFRunList run = runSet.addRun("file://server/tifs/testLetter" + i + ".tif", 0, -1);
            run.setRun("Letter");
            JDFComponent compSet = (JDFComponent)comp.addPartition(EnumPartIDKey.RunSet, runSet.getRunSet());
            JDFComponent co = (JDFComponent)compSet.addPartition(EnumPartIDKey.Run, run.getRun());
            int page = (3 * i) % 7 + 1;
            run.setPageListIndex(new JDFIntegerRangeList(new JDFIntegerRange(pageCount, pageCount + page - 1)));
            co.setPageListIndex(new JDFIntegerRangeList(new JDFIntegerRange(pageCount, pageCount + page - 1)));
            co.setSurfaceCount(2 * ((page + 1) / 2));
            run.setPages(new JDFIntegerRangeList("0~" + (page - 1)));
            run.setXMLComment("Cover Letter - record " + i);
            run.setEndOfDocument(true);
            JDFPageData pd = pl.appendPageData();
            pd.refContentData(letter);
            pd.setAttribute("PageIndex", pageCount + " ~ " + (pageCount + page - 1));
            pageCount += page;

            run = runSet.addRun("file://server/tifs/testBrochure" + i + ".tif", 0, -1);
            run.setRun("Brochure" + gender);

            co = (JDFComponent)compSet.addPartition(EnumPartIDKey.Run, run.getRun());
            page = 2 * ((7 * i) % 13) + 2;
            run.setPageListIndex(new JDFIntegerRangeList(new JDFIntegerRange(pageCount, pageCount + page - 1)));
            co.setPageListIndex(new JDFIntegerRangeList(new JDFIntegerRange(pageCount, pageCount + page - 1)));
            co.setSurfaceCount(2 * ((page + 1 + 1) / 2)); // the 2nd +1 is for
            // the blank inside
            // cover
            run.setPages(new JDFIntegerRangeList("0~" + (page - 1)));
            run.setXMLComment("Brochure - record " + i);
            run.setEndOfDocument(true);
            runSet.setEndOfSet(true);
            run.setAttribute("SkipBlankOrds", "1");
            run.setNPage(page + 1);
            run.setXMLComment("SkipBlankOrds specifies the relative position of pages to skip\n1 specifies that the first back sheet is skipped\nNPage MUST be incremented by the # of skipped pages.");
            pd = pl.appendPageData();
            pd.refContentData(brochure);
            pd.setAttribute("PageIndex", pageCount + " ~ " + (pageCount + page - 1));
            pageCount += page;
         }
         doc.write2File(sm_dirTestDataTemp + "RunlistManifest.jdf", 2, false);
      }

      ///   
      ///     <summary> *  </summary>
      ///     
      [TestInitialize]
      public override void setUp()
      {
         base.setUp();

         reSetUp();
      }

      /// <summary>
      /// All the setUp calls except for base.setUp.
      /// Use when you want to redo a setup without doign a teardown.
      /// </summary>
      public void reSetUp()
      {
         JDFElement.setLongID(false);
         JDFAudit.setStaticAgentName(null);
         JDFAudit.setStaticAgentVersion(null);
         JDFAudit.setStaticAuthor(null);

         doc = new JDFDoc("JDF");
         n = doc.getJDFRoot();
         n.setJobID("JobID");
         n.setType(EnumType.Combined);
         n.setTypes(new VString("Interpreting Rendering DigitalPrinting Stitching", " "));
         comp = (JDFComponent)n.addResource(ElementName.COMPONENT, null, EnumUsage.Output, null, null, null, null);
         rlComp = n.getLink(comp, null);
         digiParams = (JDFDigitalPrintingParams)n.addResource(ElementName.DIGITALPRINTINGPARAMS, null, EnumUsage.Input, null, null, null, null);
         med = (JDFMedia)n.appendMatchingResource(ElementName.MEDIA, EnumProcessUsage.AnyInput, null);
         med.setResStatus(EnumResStatus.Available, false);
         rlMedia = n.getLink(med, null);
         ruli = (JDFRunList)n.appendMatchingResource(ElementName.RUNLIST, EnumProcessUsage.AnyInput, null);
      }
   }
}
