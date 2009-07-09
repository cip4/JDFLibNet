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
 * IterationTest.cs
 * @author muchadie
 */

namespace org.cip4.jdflib.examples
{
   using System;
   using Microsoft.VisualStudio.TestTools.UnitTesting;


   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using VString = org.cip4.jdflib.core.VString;
   using EnumNodeStatus = org.cip4.jdflib.core.JDFElement.EnumNodeStatus;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using EnumProcessUsage = org.cip4.jdflib.node.JDFNode.EnumProcessUsage;
   using JDFPhaseTime = org.cip4.jdflib.resource.JDFPhaseTime;
   using JDFResourceAudit = org.cip4.jdflib.resource.JDFResourceAudit;
   using EnumResStatus = org.cip4.jdflib.resource.JDFResource.EnumResStatus;
   using JDFApprovalParams = org.cip4.jdflib.resource.process.JDFApprovalParams;
   using JDFApprovalSuccess = org.cip4.jdflib.resource.process.JDFApprovalSuccess;
   using JDFLayoutElementProductionParams = org.cip4.jdflib.resource.process.JDFLayoutElementProductionParams;
   using JDFRunList = org.cip4.jdflib.resource.process.JDFRunList;
   using JDFDate = org.cip4.jdflib.util.JDFDate;
   using StringUtil = org.cip4.jdflib.util.StringUtil;

   [TestClass]
   public class IterationTest : JDFTestCaseBase
   {
      private const string ITERATION_PAUSED = "IterationPaused";
      private JDFLayoutElementProductionParams iterLepp;
      private JDFApprovalParams iterApp;
      private JDFRunList iterRuli;
      private JDFRunList inRuli;
      private JDFNode iterNode;
      private JDFDoc iterDoc;
      private JDFApprovalSuccess iterAppSuccess;

      ///   
      ///	 <summary> * test iteration
      ///	 * 
      ///	 * @return </summary>
      ///	 
      [TestMethod]
      public virtual void testIterate()
      {
         JDFElement.setLongID(false);

         iterateSetup();
         iterateFirst();
         iterateSecond();
         iterateThird();
         iterateForth();
         iterateLast();
      }


      private void iterateSetup()
      {
         iterDoc = new JDFDoc("JDF");
         iterNode = iterDoc.getJDFRoot();
         iterNode.setCombined(new VString("LayoutElementProduction Approval", " "));
         iterNode.setStatus(EnumNodeStatus.Waiting);
         iterLepp = (JDFLayoutElementProductionParams)iterNode.appendMatchingResource(ElementName.LAYOUTELEMENTPRODUCTIONPARAMS, EnumProcessUsage.AnyInput, null);
         iterLepp.setResStatus(EnumResStatus.Available, true);
         iterApp = (JDFApprovalParams)iterNode.appendMatchingResource(ElementName.APPROVALPARAMS, EnumProcessUsage.AnyInput, null);
         iterApp.setResStatus(EnumResStatus.Available, true);
         iterAppSuccess = (JDFApprovalSuccess)iterNode.appendMatchingResource(ElementName.APPROVALSUCCESS, EnumProcessUsage.AnyInput, null);
         iterAppSuccess.setResStatus(EnumResStatus.Unavailable, true);
         iterRuli = (JDFRunList)iterNode.appendMatchingResource(ElementName.RUNLIST, EnumProcessUsage.AnyOutput, null);
         iterRuli.setResStatus(EnumResStatus.Unavailable, true);
         inRuli = (JDFRunList)iterNode.addResource(ElementName.RUNLIST, null, EnumUsage.Input, null, null, null, null);
         inRuli.setResStatus(EnumResStatus.Available, true);

         iterRuli.addPDF(StringUtil.uncToUrl("C:\\local\\Myinput.pdf", true), 0, 3);
         iterRuli.setDescriptiveName("save in place - input equals output");
         inRuli.addPDF(StringUtil.uncToUrl("C:\\local\\Myinput.pdf", true), 0, 3);
         inRuli.addPDF(StringUtil.uncToUrl("C:\\local\\Image1.pdf", true), 0, 0);
         inRuli.addPDF(StringUtil.uncToUrl("C:\\local\\Image2.pdf", true), 0, 0);
         iterDoc.write2File(getIteration(0), 2, false);
      }


      private void iterateRead(int i)
      {
         iterDoc = JDFDoc.parseFile(getIteration(i));
         Assert.IsNotNull(iterDoc);
         iterNode = iterDoc.getJDFRoot();
         Assert.IsNotNull(iterNode);
         iterLepp = (JDFLayoutElementProductionParams)iterNode.getMatchingResource(ElementName.LAYOUTELEMENTPRODUCTIONPARAMS, EnumProcessUsage.AnyInput, null, 0);
         Assert.IsNotNull(iterLepp);
         iterApp = (JDFApprovalParams)iterNode.getMatchingResource(ElementName.APPROVALPARAMS, EnumProcessUsage.AnyInput, null, 0);
         Assert.IsNotNull(iterApp);
         iterAppSuccess = (JDFApprovalSuccess)iterNode.getMatchingResource(ElementName.APPROVALSUCCESS, EnumProcessUsage.AnyInput, null, 0);
         Assert.IsNotNull(iterAppSuccess);
         iterRuli = (JDFRunList)iterNode.getMatchingResource(ElementName.RUNLIST, EnumProcessUsage.AnyOutput, null, 0);
         Assert.IsNotNull(iterRuli);

      }


      private void iterateFirst()
      {
         iterateRead(0);
         JDFPhaseTime pt = iterNode.getAuditPool().setPhase(EnumNodeStatus.InProgress, "First Iteration Ongoing", null, null);
         pt.setStart(new JDFDate(JDFDate.ToMillisecs(DateTime.Now) - 100000));
         pt.setEnd(new JDFDate(JDFDate.ToMillisecs(DateTime.Now)));
         pt.appendEmployee().setPersonalID("Employee 1");
         pt.appendDevice().setDeviceID("Device 1");
         iterRuli.setResStatus(EnumResStatus.Draft, false);
         iterNode.setStatus(EnumNodeStatus.Suspended);
         iterNode.setAttribute("StatusDetails", ITERATION_PAUSED);
         iterDoc.write2File(getIteration(1), 2, false);
      }


      private void iterateSecond()
      {
         iterateRead(1);
         JDFPhaseTime pt = iterNode.getAuditPool().setPhase(EnumNodeStatus.InProgress, "First Approval Ongoing", null, null);
         pt.setStart(new JDFDate(JDFDate.ToMillisecs(DateTime.Now) + 1000000));
         pt.setEnd(new JDFDate(JDFDate.ToMillisecs(DateTime.Now) + 1100000));
         pt.appendEmployee().setPersonalID("Employee 2");
         pt.appendDevice().setDeviceID("Approval Device 1");
         iterRuli.setResStatus(EnumResStatus.Rejected, false);
         iterNode.setStatus(EnumNodeStatus.Suspended);
         iterNode.setAttribute("StatusDetails", ITERATION_PAUSED);
         iterDoc.write2File(getIteration(2), 2, false);
      }


      private void iterateThird()
      {
         iterateRead(2);
         JDFPhaseTime pt = iterNode.getAuditPool().setPhase(EnumNodeStatus.InProgress, "Second Iteration Ongoing", null, null);
         pt.setStart(new JDFDate(JDFDate.ToMillisecs(DateTime.Now) + 2000000));
         pt.setEnd(new JDFDate(JDFDate.ToMillisecs(DateTime.Now) + 2100000));
         pt.appendEmployee().setPersonalID("Employee 1");
         pt.appendDevice().setDeviceID("Device 2");
         iterRuli.setResStatus(EnumResStatus.Unavailable, false);
         JDFResourceAudit ra = iterNode.cloneResourceToModify(iterNode.getLink(iterRuli, null));
         iterRuli = (JDFRunList)ra.getNewLink().getTarget();
         iterRuli.setResStatus(EnumResStatus.Draft, false);
         iterRuli.setFileURL(StringUtil.uncToUrl("C:\\local\\MyUpdatedInOutput.pdf", false));

         iterNode.setStatus(EnumNodeStatus.Suspended);
         iterNode.setAttribute("StatusDetails", ITERATION_PAUSED);
         iterDoc.write2File(getIteration(3), 2, false);
      }


      private void iterateForth()
      {
         iterateRead(3);
         JDFPhaseTime pt = iterNode.getAuditPool().setPhase(EnumNodeStatus.InProgress, "Second Approval Ongoing", null, null);
         pt.setStart(new JDFDate(JDFDate.ToMillisecs(DateTime.Now) + 3000000));
         pt.setEnd(new JDFDate(JDFDate.ToMillisecs(DateTime.Now) + 3100000));
         pt.appendEmployee().setPersonalID("Employee 3");
         pt.appendDevice().setDeviceID("Approval Device 1");
         iterRuli.setResStatus(EnumResStatus.Available, false);
         iterNode.setStatus(EnumNodeStatus.Suspended);
         iterNode.setAttribute("StatusDetails", ITERATION_PAUSED);
         iterAppSuccess.setResStatus(EnumResStatus.Available, true);
         iterDoc.write2File(getIteration(4), 2, false);
      }


      private void iterateLast()
      {
         iterateRead(4);
         JDFPhaseTime pt = iterNode.getAuditPool().setPhase(EnumNodeStatus.InProgress, "Final Iteration Ongoing - final output", null, null);
         pt.setStart(new JDFDate(JDFDate.ToMillisecs(DateTime.Now) + 4000000));
         pt.setEnd(new JDFDate(JDFDate.ToMillisecs(DateTime.Now) + 4100000));
         pt.appendEmployee().setPersonalID("Employee 1");
         pt.appendDevice().setDeviceID("Device 1");
         iterNode.setStatus(EnumNodeStatus.Completed);
         iterDoc.write2File(getIteration(5), 2, false);
      }


      private string getIteration(int i)
      {
         return sm_dirTestDataTemp + "Interation_" + Convert.ToString(i) + ".jdf";
      }
   }
}
