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


namespace org.cip4.jdflib.jmf
{
   using Microsoft.VisualStudio.TestTools.UnitTesting;

   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using EnumDeviceStatus = org.cip4.jdflib.auto.JDFAutoDeviceInfo.EnumDeviceStatus;
   using EnumJMFRole = org.cip4.jdflib.auto.JDFAutoMessageService.EnumJMFRole;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using XMLDoc = org.cip4.jdflib.core.XMLDoc;
   using EnumValidationLevel = org.cip4.jdflib.core.KElement.EnumValidationLevel;
   using EnumFitsValue = org.cip4.jdflib.datatypes.EnumFitsValue;
   using EnumType = org.cip4.jdflib.jmf.JDFMessage.EnumType;
   using JDFDeviceList = org.cip4.jdflib.resource.JDFDeviceList;
   using JDFAction = org.cip4.jdflib.resource.devicecapability.JDFAction;
   using JDFActionPool = org.cip4.jdflib.resource.devicecapability.JDFActionPool;
   using JDFDevCap = org.cip4.jdflib.resource.devicecapability.JDFDevCap;
   using JDFDevCaps = org.cip4.jdflib.resource.devicecapability.JDFDevCaps;
   using JDFDeviceCap = org.cip4.jdflib.resource.devicecapability.JDFDeviceCap;
   using JDFStringState = org.cip4.jdflib.resource.devicecapability.JDFStringState;
   using JDFTest = org.cip4.jdflib.resource.devicecapability.JDFTest;
   using EnumTerm = org.cip4.jdflib.resource.devicecapability.JDFTerm.EnumTerm;

   ///
   /// <summary> * @author Rainer Prosi
   /// * 
   /// *         Test of the Resource JMF </summary>
   /// 
   [TestClass]
   public class JMFKnownMessagesTest : JDFTestCaseBase
   {
      [TestMethod]
      public virtual void testJMFDevCaps()
      {
         JDFDoc doc = new JDFDoc(ElementName.JMF);
         JDFJMF jmfDC = doc.getJMFRoot();

         JDFResponse r = jmfDC.appendResponse(EnumType.KnownMessages);
         jmfDC.setSenderID("DeviceSenderID");

         JDFMessageService ms = r.appendMessageService();
         ms.setJMFRole(EnumJMFRole.Sender);
         ms.setQuery(true);
         ms.setType("KnownDevices");
         JDFDevCaps dcs = ms.appendDevCaps();
         dcs.setName("DeviceList");
         JDFDevCap dc = dcs.appendDevCapInPool();
         JDFDevCap dcDI = dc.appendDevCap();
         dcDI.setName(ElementName.DEVICEINFO);
         dcDI.setMinOccurs(1);
         dcDI.setMaxOccurs(1);
         JDFStringState state = dcDI.appendStringState(AttributeName.DEVICEID);
         state.setRequired(true);

         state = dcDI.appendStringState(AttributeName.DEVICESTATUS);
         state.setRequired(true);
         state.appendValueAllowedValue("Running");

         ms = r.appendMessageService();
         ms.setJMFRole(EnumJMFRole.Sender);
         ms.setQuery(true);
         ms.setType("KnownMessages");
         dcs = ms.appendDevCaps();
         dcs.setName("MessageService");
         dc = dcs.appendDevCapInPool();
         state = dc.appendStringState(AttributeName.TYPE);
         state.setRequired(true);
         state = dc.appendStringState("Foo");
         state.setRequired(false);

         JDFActionPool ap = ms.appendActionPool();
         JDFAction a = ap.appendActionTest(EnumTerm.IsPresentEvaluation, true);
         JDFTest t = a.getTest();
         // JDFTerm term=
         t.getTerm();
         // TODO
         JDFDoc docJMF = new JDFDoc("JMF");
         JDFJMF jmf = docJMF.getJMFRoot();
         for (int i = 0; i < 3; i++)
         {
            JDFResponse resp = jmf.appendResponse(EnumType.KnownDevices);
            JDFDeviceList dl = resp.appendDeviceList();
            JDFDeviceInfo di = dl.appendDeviceInfo();
            di.setDeviceID("d123");
            di.setDeviceStatus(EnumDeviceStatus.Running);
            XMLDoc report = JDFDeviceCap.getJMFInfo(jmf, r, EnumFitsValue.Allowed, EnumValidationLevel.Complete, true);
            Assert.AreEqual("true", report.getRoot().getAttribute("IsValid"));
         }
         {
            JDFResponse resp = jmf.appendResponse(EnumType.KnownMessages);
            JDFMessageService mi = resp.appendMessageService();
            mi.setType("FooBar");
            doc.write2File(sm_dirTestDataTemp + "JMFDevCap.xml", 2, false);
            docJMF.write2File(sm_dirTestDataTemp + "JMFDevCapTest.jmf", 2, false);

         }
         XMLDoc report_1 = JDFDeviceCap.getJMFInfo(jmf, r, EnumFitsValue.Allowed, EnumValidationLevel.Complete, true);
         Assert.AreEqual("true", report_1.getRoot().getAttribute("IsValid"));

         doc.write2File(sm_dirTestDataTemp + "JMFDevCap.xml", 2, false);
         docJMF.write2File(sm_dirTestDataTemp + "JMFDevCapTest.jmf", 2, false);
         {
            jmf.appendResponse(EnumType.AbortQueueEntry);
         }
         report_1 = JDFDeviceCap.getJMFInfo(jmf, r, EnumFitsValue.Allowed, EnumValidationLevel.Complete, true);
         Assert.AreEqual("false", report_1.getRoot().getAttribute("IsValid"));
      }
   }
}
