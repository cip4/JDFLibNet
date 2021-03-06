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
   using EnumQueueEntryDetails = org.cip4.jdflib.auto.JDFAutoQueueFilter.EnumQueueEntryDetails;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using EnumType = org.cip4.jdflib.jmf.JDFMessage.EnumType;

   [TestClass]
   public class JDFQueueFilterTest : JDFTestCaseBase
   {
      internal JDFQueue theQueue;
      internal JDFJMF theJMF;
      internal JDFQueueFilter filter;

      [TestInitialize]
      public override void setUp()
      {
         base.setUp();
         JDFDoc d = new JDFDoc(ElementName.QUEUE);
         theQueue = (JDFQueue)d.getRoot();
         d = new JDFDoc(ElementName.JMF);
         theJMF = d.getJMFRoot();
         filter = theJMF.appendCommand(EnumType.AbortQueueEntry).appendQueueFilter();
      }


      [TestMethod]
      public virtual void testMatches()
      {
         JDFQueueEntry qe = theQueue.appendQueueEntry();
         Assert.IsTrue(filter.matches(qe), "both empty ");
         qe.setDeviceID("d1");
         qe.setQueueEntryID("qe1");

         filter.appendDevice("qe1");
         Assert.IsFalse(filter.matches(qe), "no device ");
         filter.appendDevice("d1");
         Assert.IsTrue(filter.matches(qe), " device ");

         filter.appendQueueEntryDef("qe2");
         Assert.IsFalse(filter.matches(qe), "no qentryID ");
         filter.appendQueueEntryDef("qe1");
         Assert.IsTrue(filter.matches(qe), "qentryID ");
         filter.setQueueEntryDetails(EnumQueueEntryDetails.None);
         Assert.IsFalse(filter.matches(qe), "details=none never matches ");
      }


      [TestMethod]
      public virtual void testMatch()
      {
         for (int i = 0; i < 100; i++)
         {
            JDFQueueEntry qe = theQueue.appendQueueEntry();
            qe.setQueueEntryID("q" + i);
         }

         filter.setMaxEntries(10);
         filter.match(theQueue);
         Assert.AreEqual(10, theQueue.numEntries(null));
         filter.setQueueEntryDetails(EnumQueueEntryDetails.None);
         filter.match(theQueue);
         Assert.AreEqual(0, theQueue.numEntries(null));
      }


      [TestMethod]
      public virtual void testGetQueueEntrySet()
      {
         filter.appendQueueEntryDef("qe1");
         filter.appendQueueEntryDef("qe2");
         Assert.AreEqual(2, filter.getQueueEntryDefSet().Count);
         Assert.IsTrue(filter.getQueueEntryDefSet().Contains("qe1"));
         Assert.IsTrue(filter.getQueueEntryDefSet().Contains("qe2"));
         Assert.IsFalse(filter.getQueueEntryDefSet().Contains("qe3"));
      }


      [TestMethod]
      public virtual void testGetDeviceSet()
      {
         filter.appendDevice("qe1");
         filter.appendDevice("qe2");
         Assert.AreEqual(2, filter.getDeviceIDSet().Count);
         Assert.IsTrue(filter.getDeviceIDSet().Contains("qe1"));
         Assert.IsTrue(filter.getDeviceIDSet().Contains("qe2"));
         Assert.IsFalse(filter.getDeviceIDSet().Contains("qe3"));
      }
   }
}
