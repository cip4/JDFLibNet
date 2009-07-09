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
 * RIPTest.cs
 * @author muchadie
 */

namespace org.cip4.jdflib.examples
{
   using Microsoft.VisualStudio.TestTools.UnitTesting;


   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using EnumDeviceStatus = org.cip4.jdflib.auto.JDFAutoDeviceInfo.EnumDeviceStatus;
   using EnumWorkType = org.cip4.jdflib.auto.JDFAutoMISDetails.EnumWorkType;
   using EnumMediaType = org.cip4.jdflib.auto.JDFAutoMedia.EnumMediaType;
   using EnumReason = org.cip4.jdflib.auto.JDFAutoResourceAudit.EnumReason;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using EnumNodeStatus = org.cip4.jdflib.core.JDFElement.EnumNodeStatus;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using JDFJMF = org.cip4.jdflib.jmf.JDFJMF;
   using JDFMessage = org.cip4.jdflib.jmf.JDFMessage;
   using JDFSignal = org.cip4.jdflib.jmf.JDFSignal;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using EnumType = org.cip4.jdflib.node.JDFNode.EnumType;
   using JDFNotification = org.cip4.jdflib.resource.JDFNotification;
   using JDFProcessRun = org.cip4.jdflib.resource.JDFProcessRun;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using EnumPartIDKey = org.cip4.jdflib.resource.JDFResource.EnumPartIDKey;
   using JDFExposedMedia = org.cip4.jdflib.resource.process.JDFExposedMedia;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;
   using StatusCounter = org.cip4.jdflib.util.StatusCounter;

   [TestClass]
   public class RIPTest : JDFTestCaseBase
   {
      private JDFNode n;
      private JDFDoc d;
      private JDFMedia inMedia;
      private JDFExposedMedia outXM;
      private JDFResourceLink rlMediaIn;
      private JDFResourceLink rlXMOut;
      private StatusCounter statCounter;
      private VElement vRL;
      private VString vsSheet;
      private VString vsCMYK;


      [TestMethod]
      public virtual void testReprintJMF()
      {
         testAuditsImageSetting();
         statCounter.setActiveNode(null, null, null);
         string sheet = vsSheet.stringAt(1);
         VJDFAttributeMap vmP = new VJDFAttributeMap();
         JDFAttributeMap attributeMap = new JDFAttributeMap(EnumPartIDKey.SheetName, sheet);
         attributeMap.put("SignatureName", "Sig1");
         attributeMap.put("Separation", vsCMYK.stringAt(3));
         attributeMap.put("Side", "Front");

         vmP.Add(attributeMap);
         statCounter.setActiveNode(n, vmP, vRL);
         string refXM = rlXMOut.getrRef();
         string refMedia = rlMediaIn.getrRef();

         statCounter.setTrackWaste(refXM, true);
         statCounter.setTrackWaste(refMedia, false);

         statCounter.setActiveNode(n, vmP, vRL);
         statCounter.setWorkType(EnumWorkType.Rework);
         statCounter.setPhase(EnumNodeStatus.InProgress, "Imaging", EnumDeviceStatus.Running, null);
         statCounter.addPhase(refMedia, 1, 0, true);
         statCounter.addPhase(refXM, 1, 0, true);
         statCounter.setPhase(EnumNodeStatus.InProgress, "Imaging", EnumDeviceStatus.Running, null);
         JDFDoc d2 = statCounter.getDocJMFResource();
         JDFJMF jmf = d2.getJMFRoot();
         jmf.convertResponses(null);
         VElement vSigs = jmf.getMessageVector(JDFMessage.EnumFamily.Signal, JDFMessage.EnumType.Resource);

         d2.write2File(sm_dirTestDataTemp + "ImageSetResourceReprint_.jmf", 2, false);
         JDFDoc dStatusJMF = statCounter.getDocJMFPhaseTime();
         jmf = dStatusJMF.getJMFRoot();
         jmf.convertResponses(null);
         for (int i = 0; i < vSigs.Count; i++)
            jmf.copyElement(vSigs.item(i), null);
         dStatusJMF.write2File(sm_dirTestDataTemp + "ImageSetReprint_.jmf", 2, false);

         // JDFResourceAudit ra=
         statCounter.setResourceAudit(refMedia, EnumReason.ProcessResult);
         // JDFProcessRun pr=
         statCounter.setProcessResult(EnumNodeStatus.Completed);

         d.write2File(sm_dirTestDataTemp + "ImageSetAmount_Reprint.jdf", 2, false);
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
         n.setType(EnumType.Combined);
         inMedia = (JDFMedia)n.addResource(ElementName.MEDIA, null, EnumUsage.Input, null, null, null, null);
         outXM = (JDFExposedMedia)n.addResource(ElementName.EXPOSEDMEDIA, EnumUsage.Output);
         outXM.refMedia(inMedia);
         n.addTypes(EnumType.Interpreting);
         n.addTypes(EnumType.Rendering);
         n.addTypes(EnumType.ImageSetting);
         n.setJobID("RIP-job");
         rlXMOut = n.getLink(outXM, null);
         rlMediaIn = n.getLink(inMedia, null);
         inMedia.setProductID("Media-ProductID");
         inMedia.setMediaType(EnumMediaType.Plate);
         inMedia.setMediaTypeDetails("Aluminum");

         vRL = new VElement();
         vRL.Add(rlMediaIn);
         vRL.Add(rlXMOut);

         JDFExposedMedia xmPart = (JDFExposedMedia)outXM.addPartition(EnumPartIDKey.SignatureName, "Sig1");
         vsSheet = new VString("Cover Sheet1 Sheet2", " ");
         vsCMYK = new VString("Cyan Magenta Yellow Black Spot1", " ");
         VElement v = xmPart.addPartitions(EnumPartIDKey.SheetName, vsSheet);
         for (int i = 0; i < v.Count; i++)
         {
            JDFResource xmPart2 = (JDFResource)v[i];
            xmPart2.getCreatePartition(EnumPartIDKey.Side, "Front", null).addPartitions(EnumPartIDKey.Separation, vsCMYK);
            // xmPart2.getCreatePartition(EnumPartIDKey.Side,"Back",null).
            // addPartitions(EnumPartIDKey.Separation, vsCMYK);
         }
         statCounter = new StatusCounter(n, null, vRL);
         statCounter.setDeviceID("Rip-DeviceID");
         statCounter.setCopyResInResInfo(rlMediaIn.getrRef(), true);

      }

      [TestMethod]
      public virtual void testAuditsImageSetting()
      {

         for (int i = 0; i < vsSheet.Count; i++)
         {
            string sheet = vsSheet.stringAt(i);
            VJDFAttributeMap vmP = new VJDFAttributeMap();
            JDFAttributeMap attributeMap = new JDFAttributeMap(EnumPartIDKey.SheetName, sheet);
            attributeMap.put("SignatureName", "Sig1");

            vmP.Add(attributeMap);
            statCounter.setActiveNode(n, vmP, vRL);
            string refXM = rlXMOut.getrRef();
            string refMedia = rlMediaIn.getrRef();

            statCounter.setTrackWaste(refXM, true);
            statCounter.setTrackWaste(refMedia, false);

            statCounter.setPhase(EnumNodeStatus.Stopped, "PowerOn", EnumDeviceStatus.Stopped, "PowerOn");

            statCounter.setPhase(EnumNodeStatus.InProgress, "Imaging", EnumDeviceStatus.Running, null);
            statCounter.addPhase(refMedia, 5, 0, true);
            statCounter.addPhase(refXM, 5, 0, true);
            statCounter.setPhase(EnumNodeStatus.InProgress, "Imaging", EnumDeviceStatus.Running, null);

            // JDFResourceAudit ra=
            statCounter.setResourceAudit(refMedia, EnumReason.ProcessResult);

            JDFProcessRun pr = statCounter.setProcessResult(EnumNodeStatus.Completed);
            pr.setDescriptiveName("we even have the utterly useless ProcessRun");
         }
         d.write2File(sm_dirTestDataTemp + "ImageSetAmount_.jdf", 2, false);
         JDFDoc d2 = statCounter.getDocJMFResource();
         JDFJMF jmf = d2.getJMFRoot();
         jmf.convertResponses(null);
         JDFSignal sig = jmf.appendSignal(org.cip4.jdflib.jmf.JDFMessage.EnumType.Notification);
         JDFNotification not = sig.appendNotification();
         not.setXPathAttribute("MileStone/@MileStoneType", "PrepressCompleted");
         not.setXPathAttribute("MileStone/@Amount", "5");
         d2.write2File(sm_dirTestDataTemp + "ImageSetAmount_.jmf", 2, false);
         JDFDoc dStatusJMF = statCounter.getDocJMFPhaseTime();
         jmf = dStatusJMF.getJMFRoot();
         jmf.convertResponses(null);
         dStatusJMF.write2File(sm_dirTestDataTemp + "ImageSetPhaseTime_.jmf", 2, false);
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.JDFTestCaseBase#tearDown()
      //	 
      [TestCleanup]
      public override void tearDown()
      {
         // TODO Auto-generated method stub
         base.tearDown();
         statCounter.setActiveNode(null, null, null);
         statCounter.setWorkType(null);
      }
   }
}
