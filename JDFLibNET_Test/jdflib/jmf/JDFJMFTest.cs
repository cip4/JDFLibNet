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
   using System.Collections;
   using Microsoft.VisualStudio.TestTools.UnitTesting;


   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using EnumDeviceStatus = org.cip4.jdflib.auto.JDFAutoDeviceInfo.EnumDeviceStatus;
   using EnumDeviceDetails = org.cip4.jdflib.auto.JDFAutoStatusQuParams.EnumDeviceDetails;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using EnumVersion = org.cip4.jdflib.core.JDFElement.EnumVersion;
   using EnumValidationLevel = org.cip4.jdflib.core.KElement.EnumValidationLevel;
   using EnumFamily = org.cip4.jdflib.jmf.JDFMessage.EnumFamily;
   using EnumType = org.cip4.jdflib.jmf.JDFMessage.EnumType;
   using JDFNotification = org.cip4.jdflib.resource.JDFNotification;

   [TestClass]
   public class JDFJMFTest : JDFTestCaseBase
   {

      [TestMethod]
      public virtual void testGetMessageVector()
      {
         JDFDoc doc = new JDFDoc(ElementName.JMF);
         JDFJMF jmf = doc.getJMFRoot();
         JDFCommand command = (JDFCommand)jmf.appendMessageElement(EnumFamily.Command, EnumType.Status);
         Assert.AreEqual(command, jmf.getMessageVector(null, EnumType.Status)[0]);
         Assert.AreEqual(1, jmf.getMessageVector(null, EnumType.Status).Count);
         JDFSignal signal = (JDFSignal)jmf.appendMessageElement(EnumFamily.Signal, EnumType.Status);
         Assert.AreEqual(command, jmf.getMessageVector(null, EnumType.Status)[0]);
         Assert.AreEqual(signal, jmf.getMessageVector(null, EnumType.Status)[1]);
         Assert.AreEqual(2, jmf.getMessageVector(null, EnumType.Status).Count);
      }


      [TestMethod]
      public virtual void testInit()
      {
         JDFDoc doc = new JDFDoc(ElementName.JMF);
         JDFJMF jmf = doc.getJMFRoot();
         jmf.setSenderID("sid");
         JDFCommand c = jmf.appendCommand();
         Assert.IsTrue(c.getID().IndexOf(".sid.") != -1);
         Assert.IsTrue(jmf.ToString().IndexOf("xsi:type=") > 0);
         Assert.AreEqual(jmf.getMaxVersion(), jmf.getVersion(false));
         Assert.AreEqual(jmf.getMaxVersion(), c.getMaxVersion(true));
      }


      [TestMethod]
      public virtual void testInitMaxVersion()
      {
         JDFElement.setDefaultJDFVersion(EnumVersion.Version_1_2);
         JDFDoc doc = new JDFDoc(ElementName.JMF);
         JDFJMF jmf = doc.getJMFRoot();
         Assert.AreEqual(jmf.getMaxVersion(), jmf.getVersion(false));
         JDFCommand c = jmf.appendCommand();
         Assert.AreEqual(jmf.getMaxVersion(), c.getMaxVersion(true));
      }


      [TestMethod]
      public virtual void testTheSenderID()
      {
         JDFJMF.setTheSenderID("sid");
         JDFDoc doc = new JDFDoc(ElementName.JMF);
         JDFJMF jmf = doc.getJMFRoot();
         JDFCommand c = jmf.appendCommand();
         Assert.IsTrue(c.getID().IndexOf(".sid.") != -1);
         JDFJMF.setTheSenderID(null);
      }


      [TestMethod]
      public virtual void testgetSubmissionParams()
      {
         JDFDoc doc = new JDFDoc(ElementName.JMF);
         JDFJMF jmf = doc.getJMFRoot();
         Assert.IsNull(jmf.getSubmissionURL());
         JDFCommand c = jmf.appendCommand(EnumType.ResubmitQueueEntry);
         Assert.IsNull(jmf.getSubmissionURL());
         JDFResubmissionParams rsp = c.appendResubmissionParams();
         Assert.IsNull(jmf.getSubmissionURL());
         rsp.setURL("url");
         Assert.AreEqual("url", jmf.getSubmissionURL());
      }


      [TestMethod]
      public virtual void testCreateResponse()
      {
         JDFJMF queries = JDFJMF.createJMF(EnumFamily.Query, EnumType.Status);
         queries.appendCommand(EnumType.Resource);
         queries.appendCommand(EnumType.Resource);
         queries.appendRegistration(EnumType.Resource);

         JDFJMF responses = queries.createResponse();
         VElement messageVector = queries.getMessageVector(null, null);
         VElement responseVector = responses.getMessageVector(null, null);
         Assert.AreEqual(responseVector.Count, 4);
         for (int i = 0; i < responseVector.Count; i++)
         {
            JDFResponse r = (JDFResponse)responseVector[i];
            JDFMessage m = (JDFMessage)messageVector[i];
            Assert.AreEqual(r.getrefID(), m.getID());
            Assert.AreEqual(r.getType(), m.getType());
         }
      }


      [TestMethod]
      public virtual void testConvertResponse()
      {
         JDFDoc doc = new JDFDoc(ElementName.JMF);
         JDFJMF jmf = doc.getJMFRoot();
         JDFDoc doc2 = new JDFDoc(ElementName.JMF);
         JDFJMF jmf2 = doc2.getJMFRoot();
         JDFSignal s = jmf.appendSignal();
         JDFResponse r = jmf2.appendResponse();
         JDFQuery q = jmf.appendQuery();
         q.setType("KnownMessages");
         r.setQuery(q);
         Assert.AreEqual("refID", q.getID(), r.getrefID());

         JDFMessageService ms = r.appendMessageService();
         ms.setType("KnownMessages");
         s.convertResponse(r, q);
         Assert.AreEqual("type", r.getType(), s.getType());
         Assert.IsTrue(ms.isEqual(s.getMessageService(0)), "ms equal");
         s = jmf.appendSignal();
         s.convertResponse(r, null);
         Assert.AreEqual(r.getType(), s.getType(), "type");
         Assert.IsTrue(ms.isEqual(s.getMessageService(0)), "ms equal");
         Assert.IsTrue(s.getXSIType().StartsWith("Signal"));
      }


      [TestMethod]
      public virtual void testConvertResponses()
      {
         JDFDoc doc = new JDFDoc(ElementName.JMF);
         JDFJMF jmf = doc.getJMFRoot();
         JDFDoc doc2 = new JDFDoc(ElementName.JMF);
         JDFJMF jmf2 = doc2.getJMFRoot();
         JDFResponse r = jmf2.appendResponse();
         JDFQuery q = jmf.appendQuery();
         q.setType("KnownMessages");
         r.setQuery(q);
         Assert.AreEqual("refID", q.getID(), r.getrefID());

         jmf2.convertResponses(q);
         Assert.IsNull(jmf2.getResponse(0));
         Assert.AreEqual(q.getID(), jmf2.getSignal(0).getrefID());
      }


      [TestMethod]
      public virtual void testCreateJMF()
      {
         JDFJMF jmf = JDFJMF.createJMF(EnumFamily.Response, EnumType.AbortQueueEntry);
         Assert.AreEqual(EnumType.AbortQueueEntry, jmf.getResponse(0).getEnumType());
         Assert.AreEqual("Response", jmf.getResponse(0).LocalName);
      }


      [TestMethod]
      public virtual void testSenderIDBlank()
      {
         JDFJMF.setTheSenderID("a b");
         JDFJMF jmf = JDFJMF.createJMF(EnumFamily.Response, EnumType.AbortQueueEntry);
         JDFResponse response = jmf.getResponse(0);
         Assert.IsTrue(response.getID().IndexOf(".ab.") > 0, "thge sender id was added but stripped");
      }


      [TestMethod]
      public virtual void testDeviceInfo()
      {
         JDFDoc doc = new JDFDoc(ElementName.JMF);
         JDFJMF jmf = doc.getJMFRoot();
         JDFSignal s = (JDFSignal)jmf.appendMessageElement(EnumFamily.Signal, null);
         s.setType("Status");
         JDFStatusQuParams sqp = s.appendStatusQuParams();
         sqp.setDeviceDetails(EnumDeviceDetails.Brief);
         JDFDeviceInfo di = s.appendDeviceInfo();
         di.setDeviceStatus(EnumDeviceStatus.Unknown);
         JDFJobPhase jp = di.appendJobPhase();
         Assert.AreEqual(di.getJobPhase(0), jp);
         jp = (JDFJobPhase)di.appendElement("jdf:JobPhase", JDFElement.getSchemaURL());
         Assert.AreEqual(di.getJobPhase(1), jp);
         Assert.IsNull(di.getJobPhase(2));
         jp.appendNode();
         Assert.IsTrue(jp.isValid(EnumValidationLevel.Incomplete));
         jp.setAttribute("Status", "fnarf");
         Assert.IsFalse(jp.isValid(EnumValidationLevel.Incomplete));
      }


      [TestMethod]
      public virtual void testError()
      {
         JDFDoc doc = new JDFDoc(ElementName.JMF);
         JDFJMF jmf = doc.getJMFRoot();
         JDFResponse r = (JDFResponse)jmf.appendMessageElement(EnumFamily.Response, null);
         r.setType("Status");
         r.setrefID("r1");
         JDFNotification n = r.setErrorText("blub");
         Assert.AreEqual("blub", n.getComment(0).getText(), "get comment text");
         Assert.AreEqual("Error", n.getType(), "type");
         Assert.IsTrue(r.isValid(EnumValidationLevel.Complete));
         jmf.setSenderID("S1");
         Assert.IsTrue(jmf.isValid(EnumValidationLevel.Complete));
      }


      [TestMethod]
      public virtual void testGetMessageElement()
      {
         JDFDoc d = new JDFDoc("JMF");
         JDFJMF jmf = d.getJMFRoot();
         JDFCommand c = (JDFCommand)jmf.appendMessageElement(EnumFamily.Command, EnumType.Events);
         Assert.AreEqual(c, jmf.getMessageElement(EnumFamily.Command, EnumType.Events, 0));
         jmf.appendComment();

         JDFSignal s = (JDFSignal)jmf.appendMessageElement(EnumFamily.Signal, EnumType.Events);
         Assert.AreEqual(s, jmf.getMessageElement(EnumFamily.Signal, EnumType.Events, 0));
         Assert.AreEqual(s, jmf.getMessageElement(null, EnumType.Events, 1));
         Assert.AreEqual(s, jmf.getMessageElement(null, null, 1));

         JDFSignal s2 = (JDFSignal)jmf.appendMessageElement(EnumFamily.Signal, EnumType.Status);
         Assert.AreEqual(s2, jmf.getMessageElement(EnumFamily.Signal, EnumType.Status, 0));
         Assert.AreEqual(s2, jmf.getMessageElement(EnumFamily.Signal, null, 1));
         Assert.AreEqual(s2, jmf.getMessageElement(null, null, 2));
         Assert.AreEqual(s2, jmf.getMessageElement(null, null, -1));
         Assert.AreEqual(s, jmf.getMessageElement(null, null, -2));
         Assert.AreEqual(c, jmf.getMessageElement(null, null, -3));
         Assert.IsNull(jmf.getMessageElement(null, null, -4));
      }


      [TestMethod]
      public virtual void testJobPhase()
      {
         JDFDoc doc = new JDFDoc(ElementName.JMF);
         JDFJMF jmf = doc.getJMFRoot();
         JDFSignal s = (JDFSignal)jmf.appendMessageElement(EnumFamily.Signal, null);
         s.setType("Status");
         JDFStatusQuParams sqp = s.appendStatusQuParams();
         sqp.setDeviceDetails(EnumDeviceDetails.Brief);
         JDFDeviceInfo di = s.appendDeviceInfo();
         JDFJobPhase jp = di.appendJobPhase();
         Assert.AreEqual(di.getJobPhase(0), jp);
         jp = (JDFJobPhase)di.appendElement("jdf:JobPhase", JDFElement.getSchemaURL());
         Assert.AreEqual(di.getJobPhase(1), jp);
         Assert.IsNull(di.getJobPhase(2));
         jp.appendNode();
         Assert.IsTrue(jp.isValid(EnumValidationLevel.Incomplete));
      }


      [TestMethod]
      public virtual void testMessage()
      {
         JDFDoc doc = new JDFDoc(ElementName.JMF);
         JDFJMF jmf = doc.getJMFRoot();
         jmf.setSenderID("Pippi Langstrumpf");

         IEnumerator it = JDFMessage.EnumFamily.iterator();
         while (it.MoveNext())
         {
            JDFMessage.EnumFamily f = (JDFMessage.EnumFamily)it.Current;
            if (f == null)
               continue;
            JDFMessage m = jmf.appendMessageElement(f, null);
            m.setType("KnownMessages");

            if (f.Equals(JDFMessage.EnumFamily.Acknowledge))
            {
               JDFAcknowledge a = (JDFAcknowledge)m;
               a.setrefID("refID");
            }

            if (f.Equals(JDFMessage.EnumFamily.Registration))
            {
               JDFRegistration r = (JDFRegistration)m;
               r.appendSubscription();
            }

            Assert.IsTrue(jmf.getMessageVector(f, null).Count == 1, " added messages");
            Assert.IsTrue(jmf.getMessageElement(f, null, 0).hasAttribute(AttributeName.XSITYPE), "xsi type");
            Assert.AreEqual(f.getName() + "KnownMessages", jmf.getMessageElement(f, null, 0).getAttribute(AttributeName.XSITYPE), "xsi type");

         }

         Assert.IsTrue(jmf.getMessageVector(null, null).Count == 6, " added messages");
         Assert.IsTrue(jmf.isValid(EnumValidationLevel.Complete), "valid");
      }


      [TestMethod]
      public virtual void testPrivateMessage()
      {
         JDFDoc doc = new JDFDoc(ElementName.JMF);
         JDFJMF jmf = doc.getJMFRoot();
         JDFSignal s = (JDFSignal)jmf.appendMessageElement(EnumFamily.Signal, null);
         s.setType("foo:test");
         s.appendDevice();
         Assert.IsNull(s.getXSIType());
         Assert.IsTrue(s.getDevice(0) != null, "get device");
      }


      [TestMethod]
      public virtual void testReturnQueueEntry()
      {
         JDFDoc doc = new JDFDoc(ElementName.JMF);
         JDFJMF jmf = doc.getJMFRoot();
         JDFCommand c = (JDFCommand)jmf.appendMessageElement(EnumFamily.Command, null);
         c.setType("ReturnQueueEntry");
         JDFReturnQueueEntryParams rqe = c.appendReturnQueueEntryParams();
         rqe.setURL("http://foo.jdf");
         rqe.setQueueEntryID("dummyID");
         Assert.IsTrue(rqe.isValid(EnumValidationLevel.Complete), "JDFReturnQueueEntryParams");
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see junit.framework.TestCase#tearDown()
      //	 
      [TestCleanup]
      public override void tearDown()
      {
         JDFJMF.setTheSenderID(null);
         base.tearDown();
      }
   }
}
