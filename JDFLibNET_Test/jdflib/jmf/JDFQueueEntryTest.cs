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
   using System.Collections.Generic;
   using Microsoft.VisualStudio.TestTools.UnitTesting;



   using EnumQueueStatus = org.cip4.jdflib.auto.JDFAutoQueue.EnumQueueStatus;
   using EnumQueueEntryStatus = org.cip4.jdflib.auto.JDFAutoQueueEntry.EnumQueueEntryStatus;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFDate = org.cip4.jdflib.util.JDFDate;
   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   ///
   /// <summary> * @author MuchaD
   /// * 
   /// *         This implements the first fixture with unit tests for class JDFQueue. </summary>
   /// 
   [TestClass]
   public class JDFQueueEntryTest : JDFTestCaseBase
   {
      private JDFQueue q;

      public override string ToString()
      {
         return q == null ? "null" : q.ToString();
      }


      [TestMethod]
      public virtual void testEndTime()
      {
         JDFQueueEntry _qe = (JDFQueueEntry)new JDFDoc(ElementName.QUEUEENTRY).getRoot();
         JDFDate d = _qe.getEndTime();
         Assert.IsNull(d);
      }


      [TestMethod]
      public virtual void testGetNextStatusVector()
      {
         JDFQueueEntry qe = (JDFQueueEntry)new JDFDoc(ElementName.QUEUEENTRY).getRoot();
         qe.setQueueEntryStatus(EnumQueueEntryStatus.Aborted);
         Assert.IsTrue(qe.getNextStatusVector().Contains(EnumQueueEntryStatus.PendingReturn));
         Assert.IsTrue(qe.getNextStatusVector().Contains(EnumQueueEntryStatus.Aborted));
         Assert.IsFalse(qe.getNextStatusVector().Contains(EnumQueueEntryStatus.Running));
      }


      [TestMethod]
      public virtual void testSetPriority()
      {
         JDFQueueEntry qe = q.getQueueEntry("qe2");
         Assert.AreEqual(1, q.getQueueEntryPos("qe2"));
         q.setAutomated(true);
         int l = q.numEntries(null);
         qe.setPriority(99);
         Assert.AreEqual(l, q.numEntries(null));
         Assert.AreEqual(1, q.getQueueEntryPos("qe2"));

         qe.setPriority(0);
         Assert.AreEqual(l, q.numEntries(null));
         Assert.AreEqual(2, q.getQueueEntryPos("qe2"));
         q.removeChildren(ElementName.QUEUEENTRY, null, null);
         for (int i = 0; i < 1000; i++)
         {
            qe = q.appendQueueEntry();
            qe.setQueueEntryID("q" + i);
            qe.setPriority((i * 7) % 100);
            qe.setQueueEntryStatus((i % 3 != 0) ? EnumQueueEntryStatus.Waiting : EnumQueueEntryStatus.Running);
         }
         JDFQueueEntry qeLast = null;
         for (int i = 0; i < 1000; i++)
         {
            qe = q.getQueueEntry(i);
            Assert.IsTrue(qe.CompareTo(qeLast) >= 0, "queue is sorted: " + i);
            qeLast = qe;
         }
      }


      [TestMethod]
      public virtual void testSetQueueEntryStatus()
      {
         JDFQueueEntry qe = q.getQueueEntry("qe2");
         Assert.AreEqual(q.getQueueEntryPos("qe2"), 1);
         q.setAutomated(true);
         Assert.AreEqual(EnumQueueStatus.Running, q.getQueueStatus());
         q.setMaxRunningEntries(3);
         q.setMaxCompletedEntries(9999);
         int l = q.numEntries(null);
         qe.setQueueEntryStatus(EnumQueueEntryStatus.Completed);
         Assert.AreEqual(l, q.numEntries(null));
         Assert.IsTrue(qe.hasAttribute(AttributeName.ENDTIME));
         Assert.AreEqual(3, q.getQueueEntryPos("qe2"));
         Assert.AreEqual(EnumQueueStatus.Waiting, q.getQueueStatus(), "3 is max");
         qe.setQueueEntryStatus(EnumQueueEntryStatus.Running);
         Assert.AreEqual(EnumQueueStatus.Waiting, q.getQueueStatus(), "3 is max");
         Assert.AreEqual(l, q.numEntries(null));
         Assert.AreEqual(0, q.getQueueEntryPos("qe2"));
         qe = q.getQueueEntry("qe1");
         qe.setQueueEntryStatus(EnumQueueEntryStatus.Running);
         Assert.AreEqual(EnumQueueStatus.Running, q.getQueueStatus(), "3 is max");
         Assert.AreEqual(l, q.numEntries(null));
         Assert.AreEqual(1, q.getQueueEntryPos("qe1"));

         qe = q.getQueueEntry("qe5");
         qe.setQueueEntryStatus(EnumQueueEntryStatus.Aborted);
         Assert.AreEqual(EnumQueueStatus.Waiting, q.getQueueStatus(), "3 is max");
         Assert.AreEqual(l, q.numEntries(null));
         Assert.AreEqual(4, q.getQueueEntryPos("qe5"));

         qe = q.getQueueEntry("qe1");
         qe.setQueueEntryStatus(EnumQueueEntryStatus.Aborted);
         Assert.AreEqual(EnumQueueStatus.Waiting, q.getQueueStatus(), "3 is max");
         Assert.AreEqual(l, q.numEntries(null));
         Assert.AreEqual(3, q.getQueueEntryPos("qe1"));

         qe.setQueueEntryStatus(EnumQueueEntryStatus.Removed);
         Assert.AreEqual(EnumQueueStatus.Waiting, q.getQueueStatus(), "3 is max");
         Assert.AreEqual(l - 1, q.numEntries(null));
         Assert.AreEqual(-1, q.getQueueEntryPos("qe1"));
         Assert.IsNull(q.getQueueEntry("qe1"));
      }


      [TestMethod]
      public virtual void testSortQueue()
      {
         q.setAutomated(true);
         JDFQueue q2 = (JDFQueue)new JDFDoc("Queue").getRoot();
         JDFQueueEntry qe = q2.appendQueueEntry();
         qe.setQueueEntryID("qeNew");
         qe.setQueueEntryStatus(EnumQueueEntryStatus.Waiting);
         qe.setPriority(42);
         // JDFQueueEntry qe2=(JDFQueueEntry)
         q.moveElement(qe, null);
         q.sortChildren();
         Assert.AreEqual(2, q.getQueueEntryPos("qeNew"));
      }


      [TestMethod]
      public virtual void testMatchesFilter()
      {
         q.setAutomated(true);
         JDFQueue q2 = (JDFQueue)new JDFDoc("Queue").getRoot();
         JDFQueueEntry qe = q2.appendQueueEntry();
         qe.setQueueEntryID("qeNew");
         qe.setQueueEntryStatus(EnumQueueEntryStatus.Waiting);
         Assert.IsTrue(qe.matchesQueueFilter(null));
         JDFQueueFilter filter = (JDFQueueFilter)q.appendElement(ElementName.QUEUEFILTER);
         List<ValuedEnum> v = new List<ValuedEnum>();
         v.Add(EnumQueueEntryStatus.Completed);
         filter.setStatusList(v);
         Assert.IsFalse(qe.matchesQueueFilter(filter));
         v.Add(EnumQueueEntryStatus.Waiting);
         filter.setStatusList(v);
         Assert.IsTrue(qe.matchesQueueFilter(filter));
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see junit.framework.TestCase#setUp()
      //	 
      [TestInitialize]
      public override void setUp()
      {
         // TODO Auto-generated method stub
         base.setUp();
         JDFDoc doc = new JDFDoc(ElementName.QUEUE);
         q = (JDFQueue)doc.getRoot();
         JDFQueueEntry qe = q.appendQueueEntry();
         qe.setQueueEntryID("qe1");
         qe.setQueueEntryStatus(EnumQueueEntryStatus.Waiting);
         qe.setPriority(5);
         qe = q.appendQueueEntry();
         qe.setQueueEntryStatus(EnumQueueEntryStatus.Waiting);
         qe.setPriority(55);
         qe.setQueueEntryID("qe2");
         qe = q.appendQueueEntry();
         qe.setQueueEntryStatus(EnumQueueEntryStatus.Held);
         qe.setPriority(99);
         qe.setQueueEntryID("qe3");
         qe = q.appendQueueEntry();
         qe.setQueueEntryStatus(EnumQueueEntryStatus.Completed);
         qe.setQueueEntryID("qe4");
         qe = q.appendQueueEntry();
         qe.setQueueEntryStatus(EnumQueueEntryStatus.Running);
         qe.setQueueEntryID("qe5");
      }
   }
}
