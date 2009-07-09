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


namespace org.cip4.jdflib.pool
{
   using Microsoft.VisualStudio.TestTools.UnitTesting;

   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFAudit = org.cip4.jdflib.core.JDFAudit;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using EnumAuditType = org.cip4.jdflib.core.JDFAudit.EnumAuditType;
   using EnumNodeStatus = org.cip4.jdflib.core.JDFElement.EnumNodeStatus;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using JDFDeviceInfo = org.cip4.jdflib.jmf.JDFDeviceInfo;
   using JDFJMF = org.cip4.jdflib.jmf.JDFJMF;
   using JDFJobPhase = org.cip4.jdflib.jmf.JDFJobPhase;
   using JDFQueueEntry = org.cip4.jdflib.jmf.JDFQueueEntry;
   using JDFSignal = org.cip4.jdflib.jmf.JDFSignal;
   using EnumType = org.cip4.jdflib.jmf.JDFMessage.EnumType;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using JDFSpawned = org.cip4.jdflib.node.JDFSpawned;
   using JDFCreated = org.cip4.jdflib.resource.JDFCreated;
   using JDFMerged = org.cip4.jdflib.resource.JDFMerged;
   using JDFPhaseTime = org.cip4.jdflib.resource.JDFPhaseTime;
   using JDFProcessRun = org.cip4.jdflib.resource.JDFProcessRun;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFEmployee = org.cip4.jdflib.resource.process.JDFEmployee;
   using JDFDate = org.cip4.jdflib.util.JDFDate;

   ///
   /// <summary> * @author MuchaD
   /// * 
   /// *         This implements the first fixture with unit tests for class
   /// *         JDFElement. </summary>
   /// 
   [TestClass]
   public class JDFAuditPoolTest : JDFTestCaseBase
   {
      private JDFDoc jdfDoc;
      private JDFNode jdfRoot;
      private JDFAuditPool myAuditPool;

      ///   
      ///	 <summary> * Method testIncludesAttribute.
      ///	 *  </summary>
      ///	 * <exception cref="Exception"> </exception>
      ///	 
      [TestMethod]
      public virtual void testAddCreated()
      {
         // Test AddCreated with one parameter
         myAuditPool.addCreated("A_Test_Author", null);
         JDFAudit myAudit = myAuditPool.getAudit(1, JDFAudit.EnumAuditType.Created, new JDFAttributeMap(), null);
         string myText = myAudit.getAuthor();
         Assert.AreEqual("A_Test_Author", myText, "Error: Author should be \"A_Test_Author\"");
         // Test AddCreate with two Parameter

         // Get Create a ResourcePool
         JDFResourcePool myResourcePool = jdfRoot.getCreateResourcePool();
         // Append a ResoureElement
         myResourcePool.appendElement("BindingIntent", "");

         // Get that element back
         JDFResource e = (JDFResource)myResourcePool.getElement("BindingIntent", "", 0);
         myAuditPool.addCreated("A Test Author for JUnitTest 2", e);

         string strResourceID = e.buildXPath("/JDF", 1);
         JDFCreated kResourceAudit = (JDFCreated)myAuditPool.getChildWithAttribute(null, "XPath", null, strResourceID, 0, true);

         Assert.IsNotNull(kResourceAudit, "Error: Audit not found ");
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.JDFTestCaseBase#setUp()
      //	 
      [TestInitialize]
      public override void setUp()
      {
         // TODO Auto-generated method stub
         base.setUp();

         jdfDoc = new JDFDoc(ElementName.JDF);
         jdfRoot = (JDFNode)jdfDoc.getRoot();
         jdfRoot.setJobID("jobID");

         myAuditPool = jdfRoot.getCreateAuditPool();
      }


      [TestMethod]
      public virtual void testAddMerged()
      {
         // Test AddCreated with one parameter
         JDFDoc doc2 = new JDFDoc("JDF");
         JDFNode node2 = doc2.getJDFRoot();
         VJDFAttributeMap vMap = new VJDFAttributeMap();
         vMap.Add(new JDFAttributeMap("SheetName", "s1"));

         JDFMerged m1 = myAuditPool.addMerged(node2, null, null, null);
         JDFMerged m2 = myAuditPool.addMerged(node2, null, null, vMap);
         Assert.IsNotNull(m2);
         Assert.AreEqual(vMap, m2.getPartMapVector());
         Assert.IsNull(myAuditPool.getElement(ElementName.PART));
         Assert.IsNotNull(m1);
      }


      [TestMethod]
      public virtual void testAddSpawned()
      {
         // Test AddCreated with one parameter
         JDFDoc doc2 = new JDFDoc("JDF");
         JDFNode node2 = doc2.getJDFRoot();
         VJDFAttributeMap vMap = new VJDFAttributeMap();
         vMap.Add(new JDFAttributeMap("SheetName", "s1"));

         JDFSpawned m1 = myAuditPool.addSpawned(node2, null, null, null, null);
         Assert.IsNotNull(m1);
         JDFSpawned m2 = myAuditPool.addSpawned(node2, null, null, null, vMap);
         Assert.IsNotNull(m2);
         Assert.AreEqual(vMap, m2.getPartMapVector());
         Assert.IsNull(myAuditPool.getElement(ElementName.PART));
      }


      [TestMethod]
      public virtual void testSetPhase()
      {
         JDFPhaseTime p1 = myAuditPool.setPhase(EnumNodeStatus.Setup, null, null, null);
         Assert.IsNotNull(p1);
         Assert.AreEqual(1, myAuditPool.getChildElementVector(ElementName.PHASETIME, null, null, true, 0, true).Count);
         JDFPhaseTime p2 = myAuditPool.setPhase(EnumNodeStatus.Setup, "foobar", null, null);
         Assert.IsNotNull(p2);
         Assert.AreNotEqual(p1, p2);
         Assert.AreEqual(2, myAuditPool.getChildElementVector(ElementName.PHASETIME, null, null, true, 0, true).Count);
         p2 = myAuditPool.setPhase(EnumNodeStatus.Setup, "foobar", null, null);
         Assert.IsNotNull(p2);
         Assert.AreEqual(2, myAuditPool.getChildElementVector(ElementName.PHASETIME, null, null, true, 0, true).Count);
         p2 = myAuditPool.setPhase(EnumNodeStatus.Ready, "foobar", null, null);
         Assert.IsNotNull(p2);
         Assert.AreEqual(3, myAuditPool.getChildElementVector(ElementName.PHASETIME, null, null, true, 0, true).Count);
         p1 = myAuditPool.setPhase(EnumNodeStatus.InProgress, null, null, null);
         Assert.IsNotNull(p1);
         Assert.AreEqual(4, myAuditPool.getChildElementVector(ElementName.PHASETIME, null, null, true, 0, true).Count);
         p2 = myAuditPool.setPhase(EnumNodeStatus.InProgress, null, null, null);
         Assert.IsNotNull(p2);
         Assert.AreEqual(p1, p2);
         Assert.AreEqual(4, myAuditPool.getChildElementVector(ElementName.PHASETIME, null, null, true, 0, true).Count);
         VElement vEmpl = new VElement();
         JDFEmployee emp = (JDFEmployee)new JDFDoc(ElementName.EMPLOYEE).getRoot();
         emp.setPersonalID("p1");
         vEmpl.Add(emp);
         p2 = myAuditPool.setPhase(EnumNodeStatus.InProgress, null, null, vEmpl);
         Assert.IsNotNull(p2);
         Assert.AreNotEqual(p1, p2);
         Assert.IsTrue(p2.getEmployee(0).isEqual(emp));
         emp.setPersonalID("p2");
         p2 = myAuditPool.setPhase(EnumNodeStatus.InProgress, null, null, vEmpl);
         Assert.IsNotNull(p2);
         Assert.AreNotEqual(p1, p2);
         Assert.AreEqual("p2", p2.getEmployee(0).getPersonalID());
      }


      [TestMethod]
      public virtual void testGetLastPhase()
      {
         JDFPhaseTime p1 = myAuditPool.setPhase(EnumNodeStatus.Setup, null, null, null);
         Assert.IsNotNull(p1);
         Assert.AreEqual(p1, myAuditPool.getLastPhase(null, null));
         VJDFAttributeMap vMap = new VJDFAttributeMap();
         vMap.Add(new JDFAttributeMap("SheetName", "s1"));
         VJDFAttributeMap vMap2 = new VJDFAttributeMap();
         vMap2.Add(new JDFAttributeMap("SheetName", "s1"));
         JDFPhaseTime p2 = myAuditPool.setPhase(EnumNodeStatus.Setup, null, vMap, null);
         Assert.AreEqual(p2, myAuditPool.getLastPhase(vMap, null));
         Assert.AreEqual(p2, myAuditPool.getLastPhase(null, null));
         JDFPhaseTime p3 = myAuditPool.setPhase(EnumNodeStatus.Setup, null, vMap2, null);
         myAuditPool.addModified(null, jdfRoot);
         Assert.AreEqual(p2, myAuditPool.getLastPhase(vMap, null));
         Assert.AreEqual(p3, myAuditPool.getLastPhase(null, null));
         Assert.AreEqual(p3, myAuditPool.getLastPhase(vMap2, null));

         p1.setModules(new VString("m1", null), new VString("RIP", null));
         Assert.IsNull(myAuditPool.getLastPhase(null, "m2"));
         Assert.AreEqual(p1, myAuditPool.getLastPhase(null, "m1"));
      }


      [TestMethod]
      public virtual void testCreateSubmitProcessRun()
      {
         JDFProcessRun pr = myAuditPool.createSubmitProcessRun(null);
         Assert.IsNotNull(pr.getSubmissionTime());
         Assert.IsFalse(new JDFDate().before(pr.getSubmissionTime()), "has submissiontime before now");
         Assert.IsTrue(pr.getAttribute(AttributeName.QUEUEENTRYID).StartsWith("qe"));

         JDFDoc d = new JDFDoc(ElementName.QUEUEENTRY);
         JDFQueueEntry qe = (JDFQueueEntry)d.getRoot();

         JDFDate dat = new JDFDate();
         dat.addOffset(0, 0, 6, 2);
         qe.setSubmissionTime(dat);
         qe.setQueueEntryID("q1");
         pr = myAuditPool.createSubmitProcessRun(qe);
         Assert.AreEqual(dat, pr.getSubmissionTime());
         Assert.AreEqual("q1", pr.getAttribute(AttributeName.QUEUEENTRYID));
      }


      [TestMethod]
      public virtual void testSetPhaseJMF()
      {
         JDFDoc docJMF = new JDFDoc("JMF");
         JDFJMF jmf = docJMF.getJMFRoot();
         JDFSignal sig = jmf.appendSignal(EnumType.Status);
         JDFDeviceInfo di = sig.appendDeviceInfo();
         di.appendEmployee().setPersonalID("p1");
         JDFJobPhase phase = di.appendJobPhase();
         phase.setPhaseStartTime(new JDFDate());
         phase.setStatus(EnumNodeStatus.Setup);
         phase.setJobID(jdfRoot.getJobID(true));
         phase.setJobPartID(jdfRoot.getJobPartID(true));

         VElement el = myAuditPool.setPhase(jmf);
         Assert.IsNotNull(el);
         Assert.AreEqual(1, myAuditPool.getChildElementVector(ElementName.PHASETIME, null, null, true, 0, true).Count);
         Assert.IsNotNull(((JDFPhaseTime)myAuditPool.getAudit(0, EnumAuditType.PhaseTime, null, null)).getEmployee(0));
         Assert.AreEqual(el, myAuditPool.getChildElementVector(ElementName.PHASETIME, null, null, true, 0, true));

         el = myAuditPool.setPhase(jmf);
         Assert.IsNotNull(el);
         Assert.AreEqual(1, myAuditPool.getChildElementVector(ElementName.PHASETIME, null, null, true, 0, true).Count);
         Assert.AreEqual(el, myAuditPool.getChildElementVector(ElementName.PHASETIME, null, null, true, 0, true));

         phase.setStatus(EnumNodeStatus.Aborted);
         el = myAuditPool.setPhase(jmf);
         Assert.IsNotNull(el);
         Assert.AreEqual(2, myAuditPool.getChildElementVector(ElementName.PHASETIME, null, null, true, 0, true).Count);
         Assert.AreEqual(el[0], myAuditPool.getChildElementVector(ElementName.PHASETIME, null, null, true, 0, true)[1]);
      }


      [TestMethod]
      public virtual void testGetAudit()
      {
         JDFAudit a1 = myAuditPool.addAudit(EnumAuditType.Deleted, null);
         JDFAudit a2 = myAuditPool.addAudit(EnumAuditType.Created, null);
         JDFAudit a3 = myAuditPool.addAudit(EnumAuditType.PhaseTime, null);
         JDFAudit a4 = myAuditPool.addAudit(EnumAuditType.Deleted, null);
         Assert.AreEqual(a4, myAuditPool.getAudit(-1, null, null, null));
         Assert.AreEqual(a4, myAuditPool.getAudit(1, EnumAuditType.Deleted, null, null));
         Assert.AreEqual(a3, myAuditPool.getAudit(-2, null, null, null));
         Assert.AreEqual(a1, myAuditPool.getAudit(-2, EnumAuditType.Deleted, null, null));
         Assert.AreEqual(a1, myAuditPool.getAudit(0, EnumAuditType.Deleted, null, null));
         Assert.AreEqual(a2, myAuditPool.getAudit(-1, EnumAuditType.Created, null, null));
      }


      public override string ToString()
      {
         return myAuditPool == null ? "null" : myAuditPool.ToString();
      }
   }
}
