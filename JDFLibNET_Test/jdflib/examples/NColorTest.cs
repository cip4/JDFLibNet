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
   using System.Collections.Generic;
   using Microsoft.VisualStudio.TestTools.UnitTesting;


   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using EnumDeviceStatus = org.cip4.jdflib.auto.JDFAutoDeviceInfo.EnumDeviceStatus;
   using EnumSide = org.cip4.jdflib.auto.JDFAutoPart.EnumSide;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using EnumNodeStatus = org.cip4.jdflib.core.JDFElement.EnumNodeStatus;
   using EnumValidationLevel = org.cip4.jdflib.core.KElement.EnumValidationLevel;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using JDFIntegerRangeList = org.cip4.jdflib.datatypes.JDFIntegerRangeList;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using MISCPGoldenTicket = org.cip4.jdflib.goldenticket.MISCPGoldenTicket;
   using JDFDeviceInfo = org.cip4.jdflib.jmf.JDFDeviceInfo;
   using JDFJMF = org.cip4.jdflib.jmf.JDFJMF;
   using JDFJobPhase = org.cip4.jdflib.jmf.JDFJobPhase;
   using JDFSignal = org.cip4.jdflib.jmf.JDFSignal;
   using EnumFamily = org.cip4.jdflib.jmf.JDFMessage.EnumFamily;
   using EnumType = org.cip4.jdflib.jmf.JDFMessage.EnumType;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using JDFModuleStatus = org.cip4.jdflib.resource.JDFModuleStatus;
   using EnumPartIDKey = org.cip4.jdflib.resource.JDFResource.EnumPartIDKey;

   [TestClass]
   public class NColorTest : JDFTestCaseBase
   {
      private JDFNode node;
      private MISCPGoldenTicket bgt;
      private readonly List<string> doneSheets = new List<string>();


      ///   
      ///	 <summary> * test iteration using Identical in NodeInfo </summary>
      ///	 
      [TestMethod]
      public virtual void testFrontBackIdentical()
      {
         JDFElement.setLongID(false);
         setup(null, 2);
         JDFAttributeMap mapS1F = new JDFAttributeMap();
         mapS1F.put("SheetName", "Sheet2");
         mapS1F.put("Side", "Front");

         JDFAttributeMap mapS0F = new JDFAttributeMap();
         mapS0F.put("SheetName", "Sheet1");
         mapS0F.put("Side", "Front");

         VJDFAttributeMap vMap = new VJDFAttributeMap();
         vMap.Add(mapS0F);
         vMap.Add(mapS1F);
         node.getNodeInfo().setIdentical(vMap);
         node.getResource("ExposedMedia", null, 0).setIdentical(vMap);

         bgt.write2File(sm_dirTestDataTemp + "FrontBackIdentSetup.jdf", 2);
         run2Seps("Sheet1", EnumSide.Front, null, null, 550, 100, "press0", EnumNodeStatus.Stopped, false);
         bgt.write2File(sm_dirTestDataTemp + "FrontBackIdent_Front0.jdf", 2);
         run2Seps("Sheet2", EnumSide.Back, null, null, 550, 100, "press1", EnumNodeStatus.Completed, false);
         bgt.write2File(sm_dirTestDataTemp + "FrontBackIdent_Back1.jdf", 2);
         run2Seps("Sheet2", EnumSide.Front, null, null, 1000, 150, "press0", EnumNodeStatus.Completed, false);
         bgt.write2File(sm_dirTestDataTemp + "FrontBackIdent_Front1.jdf", 2);
         run2Seps("Sheet1", EnumSide.Back, null, null, 1000, 150, "press1", EnumNodeStatus.Completed, false);
         bgt.write2File(sm_dirTestDataTemp + "FrontBackIdent_Back0.jdf", 2);
      }

      ///   
      ///	 <summary> * test iteration using Identical in NodeInfo </summary>
      ///	 
      [TestMethod]
      public virtual void testPerfectingJMF()
      {
         JDFElement.setLongID(false);
         JDFJMF jmfStatus = JDFJMF.createJMF(EnumFamily.Signal, EnumType.Status);
         jmfStatus.setSenderID("thePress");
         JDFSignal sig = jmfStatus.getSignal(0);
         JDFDeviceInfo di = sig.appendDeviceInfo();
         di.setDeviceStatus(EnumDeviceStatus.Running);

         JDFJobPhase jp = di.appendJobPhase();
         jp.setJobID("jobID");
         jp.setJobPartID("jobPartID");
         jp.setStatus(EnumNodeStatus.InProgress);

         JDFModuleStatus ms = jp.appendModuleStatus();
         ms.setModuleID("ID_Perfecting_1");
         ms.setModuleType("PerfectingModule");
         ms.setDeviceStatus(EnumDeviceStatus.Idle);

         ms = jp.appendModuleStatus();
         ms.setModuleType("PrintModule");
         ms.setDeviceStatus(EnumDeviceStatus.Running);
         ms.setModuleIndex(new JDFIntegerRangeList("0 1 3 4"));

         ms = jp.appendModuleStatus();
         ms.setModuleType("PrintModule");
         ms.setDeviceStatus(EnumDeviceStatus.Idle);
         ms.setModuleIndex(new JDFIntegerRangeList("2"));

         jmfStatus.getOwnerDocument_JDFElement().write2File(sm_dirTestDataTemp + "StatusPerfecting.jmf", 2, false);
         Assert.IsTrue(jmfStatus.isValid(EnumValidationLevel.Complete), "known defect - wait for autoclass fix");
      }

      ///   
      ///	 <summary> * test iteration using Identical in NodeInfo </summary>
      ///	 
      [TestMethod]
      public virtual void testFrontBackSimple()
      {
         JDFElement.setLongID(false);
         setup(null, 1);

         bgt.write2File(sm_dirTestDataTemp + "FrontBackSetup.jdf", 2);
         run2Seps("Sheet1", EnumSide.Front, null, null, 550, 100, "press0", EnumNodeStatus.Stopped, false);
         bgt.write2File(sm_dirTestDataTemp + "FrontBack_Front0.jdf", 2);
         run2Seps("Sheet1", EnumSide.Back, null, null, 550, 100, "press1", EnumNodeStatus.Stopped, false);
         bgt.write2File(sm_dirTestDataTemp + "FrontBack_Back0.jdf", 2);
         run2Seps("Sheet1", EnumSide.Front, null, null, 1000, 150, "press0", EnumNodeStatus.Completed, false);
         JDFAttributeMap attributeMapS0 = new JDFAttributeMap("SheetName", "Sheet1");
         // node.getLink(component, null).setAmountPoolAttribute("ActualAmount",
         // String.valueOf(500), null, attributeMapS0);
         bgt.write2File(sm_dirTestDataTemp + "FrontBack_Front1.jdf", 2);
         run2Seps("Sheet1", EnumSide.Back, null, null, 1000, 150, "press1", EnumNodeStatus.Completed, false);
         // node.getLink(component, null).setAmountPoolAttribute("ActualAmount",
         // String.valueOf(1000), null, attributeMapS0);
         node.setPartStatus(attributeMapS0, EnumNodeStatus.Completed, null);
         bgt.write2File(sm_dirTestDataTemp + "FrontBack_Back1.jdf", 2);
      }

      ///   
      ///	 <summary> * test iteration using Identical in NodeInfo </summary>
      ///	 
      [TestMethod]
      public virtual void testNColor()
      {

         setup(null, 2);
         bgt.write2File(sm_dirTestDataTemp + "NColorSetup.jdf", 2);

         run2Seps("Sheet1", EnumSide.Front, "Cyan", "Magenta", 510, 55, "press", EnumNodeStatus.Completed, false);
         bgt.write2File(sm_dirTestDataTemp + "NColor_S0_F_CM.jdf", 2);

         run2Seps("Sheet1", EnumSide.Back, "Cyan", "Magenta", 450, 60, "press", EnumNodeStatus.Completed, false);
         bgt.write2File(sm_dirTestDataTemp + "NColor_S0_B_CM.jdf", 2);

         run2Seps("Sheet2", EnumSide.Front, "Cyan", "Magenta", 500, 55, "press", EnumNodeStatus.Completed, false);
         bgt.write2File(sm_dirTestDataTemp + "NColor_S1_F_CM.jdf", 2);

         run2Seps("Sheet2", EnumSide.Back, "Cyan", "Magenta", 450, 50, "press", EnumNodeStatus.Completed, false);
         bgt.write2File(sm_dirTestDataTemp + "NColor_S1_B_CM.jdf", 2);

         run2Seps("Sheet1", EnumSide.Front, "Black", "Yellow", 400, 50, "press", EnumNodeStatus.Completed, false);
         bgt.write2File(sm_dirTestDataTemp + "NColor_S0_F_KY.jdf", 2);

         run2Seps("Sheet1", EnumSide.Back, "Black", "Yellow", 350, 50, "press", EnumNodeStatus.Completed, true);
         bgt.write2File(sm_dirTestDataTemp + "NColor_S0_B_KY.jdf", 2);

         run2Seps("Sheet2", EnumSide.Front, "Black", "Yellow", 400, 50, "press", EnumNodeStatus.Completed, false);
         bgt.write2File(sm_dirTestDataTemp + "NColor_S1_F_KY.jdf", 2);

         run2Seps("Sheet2", EnumSide.Back, "Black", "Yellow", 360, 40, "press", EnumNodeStatus.Completed, true);
         bgt.write2File(sm_dirTestDataTemp + "NColor_S1_B_KY.jdf", 2);
      }


      ///   
      ///	 <summary> * simulate running 2 separations on one press
      ///	 *  </summary>
      ///	 * <param name="bLast">
      ///	 *            TODO </param>
      ///	 
      //JAVA TO VB & C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
      //ORIGINAL LINE: private void run2Seps(String sheet, EnumSide side, String sep1, String sep2, @SuppressWarnings("unused") int good, @SuppressWarnings("unused") int waste, @SuppressWarnings("unused") String deviceID, @SuppressWarnings("unused") EnumNodeStatus endStatus, boolean bLast)
      private void run2Seps(string sheet, EnumSide side, string sep1, string sep2, int good, int waste, string deviceID, EnumNodeStatus endStatus, bool bLast)
      {
         string jmfFile = sm_dirTestDataTemp + "NColorStatus";
         JDFAttributeMap[] map = new JDFAttributeMap[sep1 == null ? 1 : 2];
         map[0] = new JDFAttributeMap(EnumPartIDKey.SheetName, sheet);
         map[0].put(EnumPartIDKey.Side, side);
         map[0].put(EnumPartIDKey.SignatureName, "Sig1");
         jmfFile += sheet + "_" + side.getName();
         bool bFirst = !doneSheets.Contains(sheet);
         if (bFirst)
         {
            doneSheets.Add(sheet);
         }

         if (sep1 != null)
         {

            map[1] = new JDFAttributeMap(map[0]);
            map[0].put(EnumPartIDKey.Separation, sep1);
            map[1].put(EnumPartIDKey.Separation, sep2);
            jmfFile += "_" + sep1 + "_" + sep2;
         }
         VJDFAttributeMap vMap = new VJDFAttributeMap(map);
         bgt.makeReady();
         bgt.execute(vMap, bLast, bFirst);
         JDFDoc jmfStatus = bgt.getStatusCounter().getDocJMFPhaseTime();
         jmfStatus.write2File(jmfFile + "_status.jmf", 2, false);
         JDFDoc jmfRes = bgt.getStatusCounter().getDocJMFResource();
         jmfRes.write2File(jmfFile + "_resource.jmf", 2, false);
      }


      ///   
      ///	 <summary> * create 2 sheets with 2 surfaces of 4 seps each </summary>
      ///	 
      private void setup(EnumPartIDKey scheduleDepth, int nSheet)
      {
         VJDFAttributeMap vMap = new VJDFAttributeMap();
         JDFAttributeMap map = new JDFAttributeMap();
         map.put(EnumPartIDKey.SignatureName, "Sig1");
         for (int i = 1; i <= nSheet; i++)
         {
            map.put(EnumPartIDKey.SheetName, "Sheet" + i);
            map.put(EnumPartIDKey.Side, "Front");
            vMap.Add(new JDFAttributeMap(map));
            map.put(EnumPartIDKey.Side, "Back");
            vMap.Add(new JDFAttributeMap(map));
         }
         bgt = new MISCPGoldenTicket(1, null, 2, 1, true, vMap);
         if (scheduleDepth != null)
         {
            // TODO lower
         }
         bgt.nCols[0] = bgt.nCols[1] = 4;
         bgt.assign(null);
         node = bgt.getNode();
      }
   }
}
