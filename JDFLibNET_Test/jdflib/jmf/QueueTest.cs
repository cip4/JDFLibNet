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
   using System.Collections.Generic;
   using System.Threading;
   using Microsoft.VisualStudio.TestTools.UnitTesting;



   using EnumQueueStatus = org.cip4.jdflib.auto.JDFAutoQueue.EnumQueueStatus;
   using EnumQueueEntryStatus = org.cip4.jdflib.auto.JDFAutoQueueEntry.EnumQueueEntryStatus;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using EnumType = org.cip4.jdflib.jmf.JDFMessage.EnumType;
   using CleanupCallback = org.cip4.jdflib.jmf.JDFQueue.CleanupCallback;
   using ExecuteCallback = org.cip4.jdflib.jmf.JDFQueue.ExecuteCallback;
   using NodeIdentifier = org.cip4.jdflib.node.JDFNode.NodeIdentifier;
   using JDFDate = org.cip4.jdflib.util.JDFDate;
   using StatusCounter = org.cip4.jdflib.util.StatusCounter;

   ///
   /// <summary> * @author MuchaD
   /// * 
   /// *         This implements the first fixture with unit tests for class JDFQueue. </summary>
   /// 
   [TestClass]
   public class QueueTest : JDFTestCaseBase
   {
      internal static JDFQueue q;
      protected internal static int iThread = 0;

      protected internal class QueueTestThread
      {
         public virtual void Run()
         {
            int t = 1000 * iThread++;
            for (int i = 0; i < 100; i++)
            {
               JDFQueueEntry qe = q.appendQueueEntry();
               qe.setQueueEntryID("q" + t + "_" + i);
               qe.setPriority((i * 7) % 100);
               qe.setQueueEntryStatus((t % 2000 == 0) ? EnumQueueEntryStatus.Waiting : EnumQueueEntryStatus.Held);
            }
            iThread--;
         }
      }

      private class MyClean : CleanupCallback
      {

         public int i = 0;

         //      
         //		 * (non-Javadoc)
         //		 * 
         //		 * @see
         //		 * org.cip4.jdflib.jmf.JDFQueue.CleanupCallback#cleanEntry(org.cip4.
         //		 * jdflib.jmf.JDFQueueEntry)
         //		 
         public override void cleanEntry(JDFQueueEntry qe)
         {
            i++;
         }

      }

      public override string ToString()
      {
         return q == null ? "null" : q.ToString();
      }


      [TestMethod]
      public virtual void testGetQueueEntry()
      {
         Assert.AreEqual("qe2", q.getQueueEntry(1).getQueueEntryID(), "qe2");
         Assert.AreEqual("qe1", q.getQueueEntry("qe1").getQueueEntryID(), "qe2");
         Assert.AreEqual("qe2", q.getQueueEntry("qe2").getQueueEntryID(), "qe2");
         Assert.AreEqual("qe3", q.getQueueEntry("qe3").getQueueEntryID(), "qe2");
         Assert.IsNull(q.getQueueEntry("qe6"), "qe6");
         Assert.AreEqual(-1, q.getQueueEntryPos("qe6"), "qe6");
         Assert.AreEqual(1, q.getQueueEntryPos("qe2"), "qe2");
      }

      ///   
      ///	 <summary> *  </summary>
      ///	 
      [TestMethod]
      public virtual void testGetQueueEntryMap()
      {
         Dictionary<string, JDFQueueEntry> map = (Dictionary<string, JDFQueueEntry>)q.getQueueEntryIDMap();
         Assert.AreEqual(map.Count, q.numEntries(null));
         Assert.AreEqual(map["qe2"], q.getQueueEntry("qe2"));
      }


      [TestMethod]
      public virtual void testCreateQueueEntry()
      {
         q.setAutomated(true);
         q.setMaxRunningEntries(2);
         q.setMaxWaitingEntries(3);
         q.flushQueue(null);
         JDFQueueEntry qe = q.createQueueEntry(false);
         Assert.AreEqual(EnumQueueEntryStatus.Waiting, qe.getQueueEntryStatus());
         qe = q.createQueueEntry(true);
         Assert.AreEqual(EnumQueueEntryStatus.Held, qe.getQueueEntryStatus());
         q.setMaxWaitingEntries(1);
         qe = q.createQueueEntry(true);
         Assert.IsNull(qe);
      }


      [TestMethod]
      public virtual void testOpenClose()
      {
         q.setAutomated(true);
         q.setMaxRunningEntries(2);
         q.setMaxWaitingEntries(3);
         q.flushQueue(null);
         Assert.AreEqual(EnumQueueStatus.Waiting, q.openQueue());
         Assert.IsTrue(q.canAccept());
         Assert.IsTrue(q.canExecute());
         Assert.AreEqual(EnumQueueStatus.Closed, q.closeQueue());
         Assert.IsFalse(q.canAccept());
         Assert.IsTrue(q.canExecute());
         Assert.AreEqual(EnumQueueStatus.Waiting, q.openQueue());
         Assert.AreEqual(EnumQueueStatus.Held, q.holdQueue());
         Assert.IsTrue(q.canAccept());
         Assert.IsFalse(q.canExecute());
         Assert.AreEqual(EnumQueueStatus.Waiting, q.resumeQueue());
         Assert.AreEqual(EnumQueueStatus.Held, q.holdQueue());
         Assert.AreEqual(EnumQueueStatus.Blocked, q.closeQueue());
         Assert.IsFalse(q.canAccept());
         Assert.IsFalse(q.canExecute());
         Assert.AreEqual(EnumQueueStatus.Closed, q.resumeQueue());
         Assert.AreEqual(EnumQueueStatus.Waiting, q.openQueue());
         JDFQueueEntry qe = q.createQueueEntry(false);
         qe = q.createQueueEntry(false);
         Assert.IsTrue(q.canAccept());
         Assert.AreEqual(EnumQueueStatus.Waiting, q.getQueueStatus());
         qe = q.createQueueEntry(false);
         Assert.IsFalse(q.canAccept(), "max 3 waiting - see above ");
         Assert.AreEqual(EnumQueueStatus.Closed, q.getQueueStatus());
         qe.setQueueEntryStatus(EnumQueueEntryStatus.Running);
         Assert.IsTrue(q.canAccept(), "max 3 waiting - see above ");
         Assert.IsTrue(q.canExecute(), "max 3 waiting - see above ");
         Assert.AreEqual(EnumQueueStatus.Waiting, q.getQueueStatus());
         qe = q.createQueueEntry(false);
         qe.setQueueEntryStatus(EnumQueueEntryStatus.Running);
         Assert.AreEqual(EnumQueueStatus.Running, q.getQueueStatus());
         qe = q.createQueueEntry(false);
         Assert.AreEqual(EnumQueueStatus.Full, q.getQueueStatus());
      }


      [TestMethod]
      public virtual void testSetAutomated()
      {
         q.flush();
         q.setAutomated(true);
         Assert.AreEqual(true, q.isAutomated());
         Assert.AreEqual(EnumQueueStatus.Waiting, q.getQueueStatus());
      }


      [TestMethod]
      public virtual void testFlushAutomated()
      {
         q.setAutomated(true);
         q.setMaxWaitingEntries(1);
         Assert.AreEqual(EnumQueueStatus.Full, q.getQueueStatus());
         q.flushQueue(null);
         Assert.AreEqual(EnumQueueStatus.Waiting, q.getQueueStatus());
      }


      [TestMethod]
      public virtual void testGetQueueEntryByIdentifier()
      {
         q.getQueueEntry(1).setJobID("j7");
         NodeIdentifier ni = new NodeIdentifier("j7", null, null);
         Assert.AreEqual(q.getQueueEntry(1), q.getQueueEntry(ni, 0));
         Assert.AreEqual(q.getQueueEntry(1), q.getQueueEntry(ni, -1));
         Assert.IsNull(q.getQueueEntry(ni, -2));
         Assert.IsNull(q.getQueueEntry(ni, 1));
         q.getQueueEntry(3).setJobID("j7");

         Assert.AreEqual(q.getQueueEntry(1), q.getQueueEntry(ni, 0));
         Assert.AreEqual(q.getQueueEntry(3), q.getQueueEntry(ni, -1));
         Assert.AreEqual(q.getQueueEntry(3), q.getQueueEntry(ni, 1));
         Assert.AreEqual(q.getQueueEntry(1), q.getQueueEntry(ni, -2));
         Assert.IsNull(q.getQueueEntry(ni, -3));
         Assert.IsNull(q.getQueueEntry(ni, 4));
      }


      [TestMethod]
      public virtual void testGetQueueEntryVectorByIdentifier()
      {
         NodeIdentifier ni = new NodeIdentifier("j2", null, null);
         Assert.AreEqual(q.getQueueEntry(1), q.getQueueEntryVector(ni)[0]);
         Assert.AreEqual(q.getQueueEntry(0), q.getQueueEntryVector(null)[0]);
         Assert.AreEqual(q.numChildElements(ElementName.QUEUEENTRY, null), q.getQueueEntryVector(null).Count);
      }


      [TestMethod]
      public virtual void testGetTimes()
      {
         JDFQueueEntry qe = q.getQueueEntry(0);
         qe.setQueueEntryID("qe1");
         JDFDate d = qe.getEndTime();
         Assert.IsNull(d, "date");
         qe.setEndTime(null);
         d = qe.getEndTime();
         Assert.AreEqual(new JDFDate().TimeInMillis, d.TimeInMillis, 30000, "date");
      }


      [TestMethod]
      public virtual void testFlushQueue()
      {
         JDFQueueFilter qf = (JDFQueueFilter)new JDFDoc(ElementName.QUEUEFILTER).getRoot();
         qf.appendQueueEntryDef("qe5");
         VElement v = q.flushQueue(qf);
         Assert.AreEqual(1, v.Count);
         Assert.AreEqual("qe5", ((JDFQueueEntry)v[0]).getQueueEntryID());
         Assert.AreEqual(4, q.numEntries(null));
      }


      [TestMethod]
      public virtual void testThreads()
      {
         q.setAutomated(true);
         q.removeChildren(ElementName.QUEUEENTRY, null, null);
         q.setMaxCompletedEntries(999999999);
         for (int i = 0; i < 10; i++)
         {
            QueueTestThread queueTestThread = new QueueTestThread();
            Thread runThread = new Thread(new ThreadStart(queueTestThread.Run));
            runThread.Name = "Test Thread_" + i;
            runThread.Start();
         }
         // now also zapp some...
         for (int j = 0; j < 100; j++)
         {
            JDFQueueEntry qex = q.getNextExecutableQueueEntry();
            if (qex != null)
            {
               qex.setQueueEntryStatus(EnumQueueEntryStatus.Running);
               qex.setQueueEntryStatus(EnumQueueEntryStatus.Completed);
            }
         }
         while (iThread > 0)
            StatusCounter.sleep(100); // wait for threads to be over
         Assert.AreEqual(q.getQueueSize(), 1000);
         VElement v = q.getQueueEntryVector();
         JDFQueueEntry qeLast = null;
         for (int i = 0; i < v.Count; i++)
         {
            JDFQueueEntry qe = (JDFQueueEntry)v[i];
            Console.WriteLine(qe.getPriority() + " " + qe.getQueueEntryID() + " " + qe.getQueueEntryStatus());
            Assert.IsTrue(qe.CompareTo(qeLast) >= 0);
            qeLast = qe;
         }
         v = q.getQueueEntryVector(new JDFAttributeMap(AttributeName.STATUS, "Completed"), null);
         Assert.AreEqual(100, v.Count);
         v = q.getQueueEntryVector(new JDFAttributeMap(AttributeName.STATUS, "Running"), null);
         Assert.IsNull(v);
         v = q.getQueueEntryVector(new JDFAttributeMap(AttributeName.STATUS, "Held"), null);
         Assert.AreEqual(500, v.Count);
         v = q.getQueueEntryVector(new JDFAttributeMap(AttributeName.STATUS, "Waiting"), null);
         Assert.AreEqual(400, v.Count);
      }


      [TestMethod]
      public virtual void testNumEntries()
      {
         Assert.AreEqual(5, q.numEntries(null));
         Assert.AreEqual(2, q.numEntries(EnumQueueEntryStatus.Waiting));
      }


      [TestMethod]
      public virtual void testGetQueueEntryVector()
      {
         Assert.AreEqual(5, q.getQueueEntryVector().Count);
         Assert.AreEqual(2, q.getQueueEntryVector(new JDFAttributeMap("Status", EnumQueueEntryStatus.Waiting), null).Count);
      }


      [TestMethod]
      public virtual void testCanExecute()
      {
         Assert.IsFalse(q.canExecute());
         q.setMaxRunningEntries(2);
         Assert.IsTrue(q.canExecute());
         q.setQueueStatus(EnumQueueStatus.Held);
         Assert.IsFalse(q.canExecute());
         q.setQueueStatus(EnumQueueStatus.Waiting);
         Assert.IsTrue(q.canExecute(), "note that this is inconsistent");
      }


      protected internal class TestCanExecute : ExecuteCallback
      {

         public TestCanExecute(string pdeviceID, string pproxy)
            : base()
         {
            this.deviceID = pdeviceID;
            this.proxy = pproxy;
         }

         internal string deviceID;
         internal string proxy;

         //       (non-Javadoc)
         //		 * @see org.cip4.jdflib.jmf.JDFQueue.ExecuteCallback#canExecute(org.cip4.jdflib.jmf.JDFQueueEntry)
         //		 
         public override bool canExecute(JDFQueueEntry qe)
         {
            if (proxy != null && qe.hasAttribute(proxy))
               return false;
            if (deviceID != null && !KElement.isWildCard(qe.getDeviceID()) && !deviceID.Equals(qe.getDeviceID()))
               return false;
            return true;
         }
      }


      [TestMethod]
      public virtual void testExecuteCallBack()
      {
         q.setQueueStatus(EnumQueueStatus.Waiting);
         q.setExecuteCallback(new TestCanExecute("d1", null));
         Assert.AreEqual(q.getQueueEntry("qe2"), q.getNextExecutableQueueEntry());
         q.getQueueEntry("qe4").setQueueEntryStatus(EnumQueueEntryStatus.Waiting);
         q.setExecuteCallback(new TestCanExecute("d2", null));
         Assert.AreEqual(q.getQueueEntry("qe2"), q.getNextExecutableQueueEntry());
         q.getQueueEntry("qe2").setDeviceID("d1");
         Assert.AreEqual(q.getQueueEntry("qe1"), q.getNextExecutableQueueEntry());
         q.setExecuteCallback(new TestCanExecute("d1", "foo:foo2"));
         Assert.AreEqual(q.getQueueEntry("qe2"), q.getNextExecutableQueueEntry());
         q.getQueueEntry("qe2").setAttribute("foo:foo2", "bar", "www.foo");
         Assert.AreEqual(q.getQueueEntry("qe1"), q.getNextExecutableQueueEntry());
      }


      [TestMethod]
      public virtual void testGetNextExecutableQueueEntry()
      {
         Assert.IsNull(q.getNextExecutableQueueEntry());
         q.setMaxRunningEntries(2);
         Assert.AreEqual(q.getQueueEntry("qe2"), q.getNextExecutableQueueEntry());
         q.setQueueStatus(EnumQueueStatus.Held);
         Assert.IsNull(q.getNextExecutableQueueEntry());
         q.setQueueStatus(EnumQueueStatus.Waiting);
         Assert.AreEqual(q.getQueueEntry("qe2"), q.getNextExecutableQueueEntry());
         q.getQueueEntry("qe4").setQueueEntryStatus(EnumQueueEntryStatus.Waiting);
         q.getQueueEntry("qe2").setDeviceID("d1");
         Assert.AreEqual(q.getQueueEntry("qe2"), q.getNextExecutableQueueEntry());

      }


      //JAVA TO VB & C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
      //ORIGINAL LINE: @SuppressWarnings("synthetic-access") public void testCleanup()
      [TestMethod]
      public virtual void testCleanup()
      {
         JDFQueueEntry qe = q.appendQueueEntry();
         MyClean myClean = new MyClean();
         Assert.AreEqual(0, myClean.i);
         q.setCleanupCallback(myClean);
         qe.setQueueEntryStatus(EnumQueueEntryStatus.Removed);
         q.setAutomated(true);
         q.setMaxCompletedEntries(1);
         Assert.IsFalse(q.getQueueEntryVector().Contains(qe));
         Assert.AreEqual(1, myClean.i);
         Assert.AreEqual(5, q.numEntries(null), "removed completed and aborted");
         q.setMaxCompletedEntries(0);
         q.cleanup();
         Assert.AreEqual(2, myClean.i);

         Assert.AreEqual(4, q.numEntries(null), "removed completed and aborted");
      }


      [TestMethod]
      public virtual void testCopyToResponse()
      {
         JDFResponse r = JDFJMF.createJMF(JDFMessage.EnumFamily.Response, EnumType.AbortQueueEntry).getResponse(0);
         JDFQueueFilter qf = (JDFQueueFilter)new JDFDoc(ElementName.QUEUEFILTER).getRoot();
         qf.setMaxEntries(3);
         JDFQueue q2 = q.copyToResponse(r, qf);
         Assert.AreEqual(r.getQueue(0), q2);
         Assert.AreEqual(3, q2.numEntries(null));
         Assert.AreNotEqual(q, q2);
         Assert.IsTrue(q.numEntries(null) > 3);
         q2 = q.copyToResponse(r, qf);
         Assert.AreEqual(r.getQueue(0), q2);
         Assert.IsNull(r.getElement("Queue", null, 1));
         Assert.AreEqual(3, q2.numEntries(null));
         Assert.AreNotEqual(q, q2);
         Assert.IsTrue(q.numEntries(null) > 3);
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
         qe.setJobID("j1");
         qe.setQueueEntryStatus(EnumQueueEntryStatus.Waiting);
         qe.setPriority(5);
         qe = q.appendQueueEntry();
         qe.setQueueEntryStatus(EnumQueueEntryStatus.Waiting);
         qe.setPriority(55);
         qe.setQueueEntryID("qe2");
         qe.setJobID("j2");
         qe = q.appendQueueEntry();
         qe.setQueueEntryStatus(EnumQueueEntryStatus.Held);
         qe.setPriority(99);
         qe.setQueueEntryID("qe3");
         qe.setJobID("j3");
         qe = q.appendQueueEntry();
         qe.setQueueEntryStatus(EnumQueueEntryStatus.Completed);
         qe.setQueueEntryID("qe4");
         qe.setJobID("j4");
         qe = q.appendQueueEntry();
         qe.setQueueEntryStatus(EnumQueueEntryStatus.Running);
         qe.setQueueEntryID("qe5");
         qe.setJobID("j5");
         iThread = 0;
      }


      [TestMethod]
      public virtual void testgetQueueSize()
      {
         Assert.AreEqual(5, q.getQueueSize(), "no size set - count entries");
         q.setQueueSize(10);
         Assert.AreEqual(10, q.getQueueSize());
      }
   }
}
