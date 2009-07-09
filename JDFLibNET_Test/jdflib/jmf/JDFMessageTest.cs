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


   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using EnumValidationLevel = org.cip4.jdflib.core.KElement.EnumValidationLevel;
   using EnumFamily = org.cip4.jdflib.jmf.JDFMessage.EnumFamily;
   using EnumType = org.cip4.jdflib.jmf.JDFMessage.EnumType;

   [TestClass]
   public class JDFMessageTest
   {

      [TestMethod]
      public virtual void testIsValidMessageElement()
      {
         JDFDoc doc = new JDFDoc(ElementName.JMF);
         JDFJMF jmf = doc.getJMFRoot();
         JDFSignal sig = (JDFSignal)jmf.appendMessageElement(EnumFamily.Signal, EnumType.UpdateJDF);
         Assert.IsTrue(sig.isValidMessageElement(ElementName.UPDATEJDFCMDPARAMS, 0));
         Assert.IsFalse(sig.isValidMessageElement(ElementName.MODIFYNODECMDPARAMS, 0));

         JDFResponse resp = (JDFResponse)jmf.appendMessageElement(EnumFamily.Response, EnumType.RepeatMessages);
         Assert.IsTrue(resp.isValidMessageElement(ElementName.SIGNAL, 3));
         Assert.IsTrue(resp.isValidMessageElement(ElementName.REGISTRATION, 3));
         Assert.IsFalse(resp.isValidMessageElement(ElementName.QUEUE, 0));

         JDFRegistration reg = (JDFRegistration)jmf.appendMessageElement(EnumFamily.Registration, EnumType.RepeatMessages);
         Assert.IsFalse(reg.isValidMessageElement(ElementName.SIGNAL, 3));

      }


      [TestMethod]
      public virtual void testAppendValidElement()
      {
         JDFDoc doc = new JDFDoc(ElementName.JMF);
         JDFJMF jmf = doc.getJMFRoot();
         JDFSignal sig = (JDFSignal)jmf.appendMessageElement(EnumFamily.Signal, EnumType.UpdateJDF);
         Assert.IsNotNull(sig.appendValidElement(ElementName.UPDATEJDFCMDPARAMS, null));
      }


      [TestMethod]
      public virtual void testGetInvalidAttributes()
      {
         JDFDoc doc = new JDFDoc(ElementName.JMF);
         JDFJMF jmf = doc.getJMFRoot();
         JDFSignal sig = (JDFSignal)jmf.appendMessageElement(EnumFamily.Signal, EnumType.UpdateJDF);
         Assert.IsNotNull(sig.appendValidElement(ElementName.UPDATEJDFCMDPARAMS, null));
         Assert.IsFalse(sig.getInvalidAttributes(EnumValidationLevel.Complete, true, 999).Contains(AttributeName.XSITYPE));
         sig.setAttribute("Type", EnumType.AbortQueueEntry.getName());
         Assert.IsTrue(sig.getInvalidAttributes(EnumValidationLevel.Complete, true, 999).Contains(AttributeName.XSITYPE));
      }


      [TestMethod]
      public virtual void testModifyNode()
      {
         JDFDoc doc = new JDFDoc(ElementName.JMF);
         JDFJMF jmf = doc.getJMFRoot();
         JDFSignal sig = (JDFSignal)jmf.appendMessageElement(EnumFamily.Signal, EnumType.ModifyNode);
         JDFModifyNodeCmdParams mnp = sig.appendModifyNodeCmdParams();
         Assert.IsNotNull(mnp);
         JDFModifyNodeCmdParams mnp2 = sig.getModifyNodeCmdParams();
         Assert.AreEqual(mnp, mnp2);
         mnp2 = sig.getCreateModifyNodeCmdParams();
         Assert.AreEqual(mnp, mnp2);
         try
         {
            sig.appendModifyNodeCmdParams();
            Assert.Fail("oops");
         }
         catch (JDFException)
         {
            // nop
         }
      }


      [TestMethod]
      public virtual void testUpdateJDF()
      {
         JDFDoc doc = new JDFDoc(ElementName.JMF);
         JDFJMF jmf = doc.getJMFRoot();
         JDFCommand command = (JDFCommand)jmf.appendMessageElement(EnumFamily.Command, EnumType.UpdateJDF);
         JDFUpdateJDFCmdParams ujn = command.appendUpdateJDFCmdParams();
         Assert.IsNotNull(ujn);
         JDFUpdateJDFCmdParams ujn2 = command.getUpdateJDFCmdParams();
         Assert.AreEqual(ujn, ujn2);
         ujn2 = command.getCreateUpdateJDFCmdParams();
         Assert.AreEqual(ujn, ujn2);
         try
         {
            command.appendUpdateJDFCmdParams();
            Assert.Fail("oops");
         }
         catch (JDFException)
         {
            // nop
         }
      }


      [TestMethod]
      public virtual void testSetType()
      {
         JDFDoc doc = new JDFDoc(ElementName.JMF);
         JDFJMF jmf = doc.getJMFRoot();
         JDFCommand command = (JDFCommand)jmf.appendMessageElement(EnumFamily.Command, EnumType.UpdateJDF);
         Assert.AreEqual("CommandUpdateJDF", command.getXSIType());
         command.setType("foo:bar");
         Assert.IsNull(command.getXSIType());
         Assert.AreEqual("foo:bar", command.getType());
      }


      [TestMethod]
      public virtual void testSenderID()
      {
         JDFDoc doc = new JDFDoc(ElementName.JMF);
         JDFJMF jmf = doc.getJMFRoot();
         JDFCommand command = (JDFCommand)jmf.appendMessageElement(EnumFamily.Command, EnumType.UpdateJDF);
         Assert.AreEqual(command.getSenderID(), jmf.getSenderID());
         command.setSenderID("foo:bar");
         Assert.AreEqual("foo:bar", command.getSenderID());
      }


      [TestMethod]
      public virtual void testCreateResponse()
      {
         JDFDoc doc = new JDFDoc(ElementName.JMF);
         JDFJMF jmf = doc.getJMFRoot();
         JDFCommand command = (JDFCommand)jmf.appendMessageElement(EnumFamily.Command, EnumType.UpdateJDF);
         Assert.AreEqual("CommandUpdateJDF", command.getXSIType());
         command.setType("foo:bar");
         Assert.IsNull(command.getXSIType());
         Assert.AreEqual("foo:bar", command.getType());
         JDFJMF resp = command.createResponse();
         JDFResponse response = resp.getResponse(0);
         Assert.AreEqual(resp.getMessageElement(null, null, 0), response);
         Assert.AreEqual("foo:bar", response.getType());
         Assert.AreEqual(command.getID(), response.getrefID());
      }
   }
}
