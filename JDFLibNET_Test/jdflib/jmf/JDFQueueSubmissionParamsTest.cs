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
   using System;
   using System.Collections;
   using Microsoft.VisualStudio.TestTools.UnitTesting;


   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using EnumQueueEntryStatus = org.cip4.jdflib.auto.JDFAutoQueueEntry.EnumQueueEntryStatus;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using EnumType = org.cip4.jdflib.jmf.JDFMessage.EnumType;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using JDFFileSpec = org.cip4.jdflib.resource.process.JDFFileSpec;
   using JDFRunList = org.cip4.jdflib.resource.process.JDFRunList;
   using JDFColorSpaceConversionParams = org.cip4.jdflib.resource.process.prepress.JDFColorSpaceConversionParams;
   using MimeUtil = org.cip4.jdflib.util.MimeUtil;
   using StringUtil = org.cip4.jdflib.util.StringUtil;

   [TestClass]
   public class JDFQueueSubmissionParamsTest : JDFTestCaseBase
   {
      internal JDFQueue theQueue;
      internal JDFJMF theJMF;
      internal JDFQueueSubmissionParams qsp;

      [TestInitialize]
      public override void setUp()
      {
         base.setUp();
         JDFDoc d = new JDFDoc(ElementName.QUEUE);
         theQueue = (JDFQueue)d.getRoot();
         d = new JDFDoc(ElementName.JMF);
         theJMF = d.getJMFRoot();
         qsp = theJMF.appendCommand(EnumType.SubmitQueueEntry).appendQueueSubmissionParams();
      }


      [TestMethod]
      public virtual void testAddNull()
      {
         JDFResponse resp = qsp.addEntry(null, null);
         Assert.AreEqual(2, resp.getReturnCode());
      }


      [TestMethod]
      public virtual void testAddEntry()
      {
         JDFResponse resp = qsp.addEntry(theQueue, null);
         Assert.AreEqual(0, resp.getReturnCode());
         theQueue = resp.getQueue(0);
         Assert.AreEqual(theQueue.getQueueEntry(0).getQueueEntryStatus(), resp.getQueueEntry(0).getQueueEntryStatus());
         Assert.AreEqual(theQueue.getQueueEntry(0).getQueueEntryID(), resp.getQueueEntry(0).getQueueEntryID());
         Assert.AreNotEqual("", theQueue.getQueueEntry(0).getQueueEntryID());
         Assert.AreEqual(1, theQueue.numEntries(null));
         Assert.AreEqual(1, theQueue.numEntries(EnumQueueEntryStatus.Waiting));
         qsp.setHold(true);
         JDFJMF jmfNew = new JDFDoc("JMF").getJMFRoot();
         resp = qsp.addEntry(theQueue, jmfNew);
         Assert.AreEqual(jmfNew.getResponse(0), resp);
         Assert.AreEqual(2, theQueue.numEntries(null));
         Assert.AreEqual(1, theQueue.numEntries(EnumQueueEntryStatus.Waiting));
         Assert.AreEqual(1, theQueue.numEntries(EnumQueueEntryStatus.Held));
         Assert.AreNotEqual(theQueue.getQueueEntry(0).getQueueEntryID(), theQueue.getQueueEntry(1).getQueueEntryID());
      }


      [TestMethod]
      public virtual void testGetMimeURL()
      {
         JDFDoc d1 = new JDFDoc("JMF");
         d1.setOriginalFileName("JMF.jmf");
         JDFJMF jmf = d1.getJMFRoot();
         JDFCommand com = (JDFCommand)jmf.appendMessageElement(JDFMessage.EnumFamily.Command, JDFMessage.EnumType.SubmitQueueEntry);

         com.appendQueueSubmissionParams().setURL("cid:TheJDF");

         JDFDoc doc = new JDFDoc("JDF");
         doc.setOriginalFileName("JDF.jdf");
         JDFNode n = doc.getJDFRoot();
         n.setType(JDFNode.EnumType.ColorSpaceConversion);
         JDFColorSpaceConversionParams cscp = (JDFColorSpaceConversionParams)n.addResource(ElementName.COLORSPACECONVERSIONPARAMS, null, EnumUsage.Input, null, null, null, null);
         JDFFileSpec fs0 = cscp.appendFinalTargetDevice();
         fs0.setURL(StringUtil.uncToUrl(sm_dirTestData + "test.icc", true));
         JDFRunList rl = (JDFRunList)n.addResource(ElementName.RUNLIST, null, EnumUsage.Input, null, null, null, null);
         rl.addPDF(StringUtil.uncToUrl(sm_dirTestData + "url1.pdf", false), 0, -1);
         System.Net.Mail.AttachmentCollection m = MimeUtil.buildMimePackage(d1, doc, true);

         JDFDoc[] d2 = MimeUtil.GetJMFSubmission(m);
         Assert.IsNotNull(d2);
         JDFQueueSubmissionParams queueSubmissionParams = d2[0].getJMFRoot().getCommand(0).getQueueSubmissionParams(0);
         Assert.AreEqual("cid:JDF.jdf", queueSubmissionParams.getURL());
         Assert.AreEqual(JDFNode.EnumType.ColorSpaceConversion, d2[1].getJDFRoot().getEnumType());
         JDFDoc d3 = queueSubmissionParams.getURLDoc();
         Assert.IsNotNull(d3);
         Assert.AreEqual(JDFNode.EnumType.ColorSpaceConversion, d3.getJDFRoot().getEnumType());
      }


      [TestMethod]
      public virtual void testSetReturnURL()
      {
         qsp.setReturnURL((Uri)null);
         Assert.IsFalse(qsp.hasAttribute(AttributeName.RETURNURL));
         //C# Uri forces a '/' at the end of the host.
         qsp.setReturnURL(new Uri("http://localhost/"));
         Assert.AreEqual("http://localhost/", qsp.getReturnURL());
      }


      [TestMethod]
      public virtual void testSetReturnJMFL()
      {
         qsp.setReturnJMF((Uri)null);
         Assert.IsFalse(qsp.hasAttribute(AttributeName.RETURNJMF));
         //C# Uri forces a '/' at the end of the host.
         qsp.setReturnJMF(new Uri("http://localhost/"));
         Assert.AreEqual("http://localhost/", qsp.getReturnJMF());
      }
   }
}
