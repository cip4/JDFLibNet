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
 * AmountTest.cs
 * @author muchadie
 */

namespace org.cip4.jdflib.examples
{
   using Microsoft.VisualStudio.TestTools.UnitTesting;


   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using EnumDeviceStatus = org.cip4.jdflib.auto.JDFAutoDeviceInfo.EnumDeviceStatus;
   using EnumReason = org.cip4.jdflib.auto.JDFAutoResourceAudit.EnumReason;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using EnumAuditType = org.cip4.jdflib.core.JDFAudit.EnumAuditType;
   using EnumNodeStatus = org.cip4.jdflib.core.JDFElement.EnumNodeStatus;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using EnumType = org.cip4.jdflib.node.JDFNode.EnumType;
   using JDFAmountPool = org.cip4.jdflib.pool.JDFAmountPool;
   using JDFAuditPool = org.cip4.jdflib.pool.JDFAuditPool;
   using JDFProcessRun = org.cip4.jdflib.resource.JDFProcessRun;
   using JDFResourceAudit = org.cip4.jdflib.resource.JDFResourceAudit;
   using EnumPartIDKey = org.cip4.jdflib.resource.JDFResource.EnumPartIDKey;
   using JDFComponent = org.cip4.jdflib.resource.process.JDFComponent;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;
   using StatusCounter = org.cip4.jdflib.util.StatusCounter;

   [TestClass]
   public class AmountTest : JDFTestCaseBase
   {
      private JDFNode n;
      private JDFComponent outComp;
      private JDFMedia inMedia;
      private JDFResourceLink rlOut;
      private JDFResourceLink rlMediaIn;
      private JDFDoc d;

      ///   
      ///	 <summary> * test specification of planned waste in AmountPool
      ///	 * 
      ///	 * @return </summary>
      ///	 
      [TestMethod]
      public virtual void testPlannedWaste()
      {
         JDFElement.setLongID(false);
         d = new JDFDoc("JDF");
         n = d.getJDFRoot();
         n.setType(EnumType.ConventionalPrinting);
         outComp = (JDFComponent)n.addResource(ElementName.COMPONENT, null, EnumUsage.Output, null, null, null, null);
         rlOut = n.getLink(outComp, null);
         JDFAmountPool ap = rlOut.getCreateAmountPool();

         JDFComponent cover = (JDFComponent)outComp.addPartition(EnumPartIDKey.SheetName, "Cover");
         JDFAttributeMap map = cover.getPartMap();
         ap.appendXMLComment("Want 10000-10500 good cover sheets and allow for 500 waste cover sheets", null);
         map.put(EnumPartIDKey.Condition, "Good");
         rlOut.setAmount(10000, map);
         rlOut.setMaxAmount(10500, map);
         map.put(EnumPartIDKey.Condition, "Waste");
         rlOut.setMaxAmount(500, map);

         ap.appendXMLComment("Want 20000 good first insert sheets and allow for 200 waste insert sheets", null);
         JDFComponent sheet1 = (JDFComponent)outComp.addPartition(EnumPartIDKey.SheetName, "Sheet1");
         map = sheet1.getPartMap();
         map.put(EnumPartIDKey.Condition, "Good");
         rlOut.setAmount(20000, map);
         map.put(EnumPartIDKey.Condition, "Waste");
         rlOut.setMaxAmount(200, map);

         ap.appendXMLComment("Want 20000 good second insert sheets and allow for 200 waste insert sheets", null);
         JDFComponent sheet2 = (JDFComponent)outComp.addPartition(EnumPartIDKey.SheetName, "Sheet2");
         map = sheet2.getPartMap();
         map.put(EnumPartIDKey.Condition, "Good");
         rlOut.setAmount(20000, map);
         map.put(EnumPartIDKey.Condition, "Waste");
         rlOut.setMaxAmount(100, map);

         d.write2File(sm_dirTestDataTemp + "plannedWaste.jdf", 2, true);
      }

      ///   
      ///	 <summary> * test specification of planned waste in AmountPool
      ///	 * 
      ///	 * @return </summary>
      ///	 
      [TestMethod]
      public virtual void testPlannedWasteICS()
      {
         JDFAmountPool ap = rlOut.getCreateAmountPool();
         JDFAmountPool apIn = rlMediaIn.getCreateAmountPool();

         JDFComponent cover = (JDFComponent)outComp.addPartition(EnumPartIDKey.SheetName, "Cover");
         JDFAttributeMap map = cover.getPartMap();
         ap.appendXMLComment("Want 10000-10400 good cover sheets and allow for 500 waste cover sheets", null);
         map.put(EnumPartIDKey.Condition, "Good");
         rlOut.setAmount(10000, map);
         rlOut.setMaxAmount(10400, map);
         apIn.appendXMLComment("Amount[Good]: planned consumption for good production\n" + "MaxAmount[Good]: planned maximum consumption for good production\n" + "MaxAmount[Waste]: planned Media for waste", null);
         rlMediaIn.setAmount(10500, map);
         map.put(EnumPartIDKey.Condition, "Waste");
         rlMediaIn.setMaxAmount(500, map);

         ap.appendXMLComment("Want 20000 good first insert sheets and allow for 200 waste insert sheets", null);
         JDFComponent sheet1 = (JDFComponent)outComp.addPartition(EnumPartIDKey.SheetName, "Sheet1");
         map = sheet1.getPartMap();
         map.put(EnumPartIDKey.Condition, "Good");
         rlOut.setAmount(20000, map);
         rlOut.setMaxAmount(20800, map);
         rlMediaIn.setAmount(21000, map);
         map.put(EnumPartIDKey.Condition, "Waste");
         rlMediaIn.setMaxAmount(200, map);

         ap.appendXMLComment("Want 20000 good second insert sheets and allow for 100 waste insert sheets", null);
         JDFComponent sheet2 = (JDFComponent)outComp.addPartition(EnumPartIDKey.SheetName, "Sheet2");
         map = sheet2.getPartMap();
         map.put(EnumPartIDKey.Condition, "Good");
         rlOut.setAmount(20000, map);
         rlOut.setMaxAmount(20800, map);
         rlMediaIn.setAmount(20900, map);
         map.put(EnumPartIDKey.Condition, "Waste");
         rlMediaIn.setMaxAmount(100, map);

         d.write2File(sm_dirTestDataTemp + "plannedWasteICS.jdf", 2, true);

         //      
         //		 * map=cover.getPartMap(); map.put(EnumPartIDKey.Condition, "Good");
         //		 * rl.getAmountPool().getPartAmount(map,0).appendXMLComment(
         //		 * "Actually produced covers: 10200\nWaste put on output stack:100");
         //		 * rlIn.getAmountPool().getPartAmount(map,0).appendXMLComment(
         //		 * "Total consumed sheets: 10400\nOf that: sheets wasted: 200");
         //		 * rl.setActualAmount(10200, map); rlIn.setActualAmount(10200, map);
         //		 * map.put(EnumPartIDKey.Condition, "Waste"); rl.setActualAmount(100,
         //		 * map); rlIn.setActualAmount(200, map);
         //		 * 
         //		 * d.write2File(sm_dirTestDataTemp+"actualWasteICS.jdf", 2, true);
         //		 
      }

      ///   
      ///	 <summary> * @return </summary>
      ///	 
      [TestInitialize]
      public override void setUp()
      {
         base.setUp();
         JDFElement.setLongID(false);
         d = new JDFDoc("JDF");

         n = d.getJDFRoot();
         n.appendXMLComment("Example to illustrate JDF 1.3 Base and MIS compatible amount handling", null);
         n.setType(EnumType.ConventionalPrinting);
         outComp = (JDFComponent)n.addResource(ElementName.COMPONENT, null, EnumUsage.Output, null, null, null, null);
         inMedia = (JDFMedia)n.addResource(ElementName.MEDIA, null, EnumUsage.Input, null, null, null, null);
         rlOut = n.getLink(outComp, null);
         rlMediaIn = n.getLink(inMedia, null);
      }


      [TestMethod]
      public virtual void testAudits()
      {
         testPlannedWasteICS();
         VString vs = new VString("Cover Sheet1 Sheet2", " ");

         VElement vRL = new VElement();
         vRL.Add(rlOut);
         vRL.Add(rlMediaIn);

         for (int j = 0; j < 2; j++)
         {
            bool bMinimal = j == 0;

            for (int i = 0; i < vs.Count; i++)
            {
               string sheet = vs.stringAt(i);
               VJDFAttributeMap vmP = new VJDFAttributeMap();
               vmP.Add(new JDFAttributeMap(EnumPartIDKey.SheetName, sheet));
               StatusCounter stUtil = new StatusCounter(n, vmP, vRL);

               string refComp = rlOut.getrRef();
               string refMedia = rlMediaIn.getrRef();

               stUtil.setTrackWaste(refComp, true);
               stUtil.setTrackWaste(refMedia, true);

               if (i == 0)
                  stUtil.setPhase(EnumNodeStatus.Stopped, "PowerOn", EnumDeviceStatus.Stopped, "PowerOn");
               stUtil.setPhase(EnumNodeStatus.Setup, "FormChange", EnumDeviceStatus.Setup, "FormChange");
               stUtil.addPhase(refMedia, 0, 200, true);
               stUtil.addPhase(refComp, 0, 200, true);
               stUtil.setPhase(EnumNodeStatus.Setup, "FormChange", EnumDeviceStatus.Setup, "FormChange");

               if (i >= 1 && !bMinimal)
               {
                  JDFResourceAudit ra = stUtil.setResourceAudit(refMedia, EnumReason.ProcessResult);

                  stUtil.setResourceAudit(refComp, EnumReason.ProcessResult);

                  stUtil.clearAmounts(refMedia);
                  stUtil.addPhase(refMedia, 50, 0, true);
                  JDFResourceAudit ra2 = stUtil.setResourceAudit(refMedia, EnumReason.OperatorInput);
                  ra2.setRef(ra);
                  ra2.setDescriptiveName("manual reset to using only 50 sheets because 100 initially were wastes");

               }
               stUtil.setPhase(EnumNodeStatus.InProgress, "Good", EnumDeviceStatus.Running, null);
               stUtil.addPhase(refMedia, 4000, 0, true);
               stUtil.addPhase(refComp, 4000, 0, true);
               stUtil.setPhase(EnumNodeStatus.Cleanup, "Washup during processing", EnumDeviceStatus.Cleanup, "Washup");
               stUtil.setPhase(EnumNodeStatus.InProgress, "Waste", EnumDeviceStatus.Running, null);

               stUtil.addPhase(refMedia, 0, i == 0 ? 40 : 30, true);
               stUtil.addPhase(refComp, 0, i == 0 ? 40 : 30, true);
               stUtil.setPhase(EnumNodeStatus.InProgress, "Good", EnumDeviceStatus.Running, null);

               stUtil.addPhase(refMedia, 1000, 0, true);
               stUtil.addPhase(refComp, 1000, 0, true);
               stUtil.setPhase(EnumNodeStatus.InProgress, "Good", EnumDeviceStatus.Running, null);
               stUtil.addPhase(refMedia, i == 0 ? 5200 : 5400, 0, true);
               stUtil.addPhase(refComp, i == 0 ? 5200 : 5400, 0, true);
               stUtil.setPhase(EnumNodeStatus.InProgress, "Good", EnumDeviceStatus.Running, null);

               JDFResourceAudit ra_1 = stUtil.setResourceAudit(refMedia, EnumReason.ProcessResult);

               if (!bMinimal)
               {
                  stUtil.setResourceAudit(refComp, EnumReason.ProcessResult);

                  stUtil.clearAmounts(refMedia);
                  // Java to C# Conversion - Don't know the purpose of this unreachable code.  Default to the false value since 1 != 0
                  //stUtil.addPhase(refMedia, 1 == 0 ? 10100 : 10200, 0, true);
                  stUtil.addPhase(refMedia, 10200, 0, true);
                  JDFResourceAudit ra2 = stUtil.setResourceAudit(refMedia, EnumReason.OperatorInput);
                  ra2.setRef(ra_1);
                  ra2.setDescriptiveName("manual reset to using only 10200 sheets because 100 initially were  wates");
               }
               JDFProcessRun pr = stUtil.setProcessResult(EnumNodeStatus.Completed);
               pr.setDescriptiveName("we even have the utterly useless ProcessRun");
            }
            if (bMinimal)
            {
               JDFAuditPool ap = n.getAuditPool();
               VElement audits = ap.getAudits(EnumAuditType.PhaseTime, null, null);
               for (int i = 0; i < audits.Count; i++)
               {
                  audits.item(i).deleteNode();
               }
            }
            d.write2File(sm_dirTestDataTemp + "ConvPrintAmount_" + (bMinimal ? "min" : "full") + ".jdf", 2, false);
         }
      }
   }
}
