
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
 * THIS SOFTWARE IS PROVIDED ``AS IS'' AND ANY EXPRESSED OR IMPLIED
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


namespace org.cip4.jdflib.core
{
   using Microsoft.VisualStudio.TestTools.UnitTesting;

   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using EnumAuditType = org.cip4.jdflib.core.JDFAudit.EnumAuditType;
   using EnumNodeStatus = org.cip4.jdflib.core.JDFElement.EnumNodeStatus;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using EnumType = org.cip4.jdflib.node.JDFNode.EnumType;
   using JDFAuditPool = org.cip4.jdflib.pool.JDFAuditPool;
   using JDFCreated = org.cip4.jdflib.resource.JDFCreated;
   using JDFModified = org.cip4.jdflib.resource.JDFModified;
   using JDFPhaseTime = org.cip4.jdflib.resource.JDFPhaseTime;
   using JDFProcessRun = org.cip4.jdflib.resource.JDFProcessRun;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFDate = org.cip4.jdflib.util.JDFDate;

   ///
   /// <summary> * @author MuchaD
   /// * 
   /// *         This implements the first fixture with unit tests for class JDFAudit. </summary>
   /// 
   [TestClass]
   public class JDFAuditTest : JDFTestCaseBase
   {
      private bool bAutoAgent;

      [TestMethod]
      public virtual void testInit()
      {
         JDFDoc d = new JDFDoc(ElementName.JDF);
         JDFNode n = d.getJDFRoot();
         n.setType("ConventionalPrinting", true);
         JDFAuditPool ap = n.getAuditPool();
         Assert.IsNotNull(ap);
         JDFCreated crea = (JDFCreated)ap.getAudit(0, EnumAuditType.Created, null, null);
         Assert.IsTrue(crea.hasAttribute("ID"));
         Assert.IsTrue(crea.getID().StartsWith("a"));
         JDFProcessRun pr = ap.addProcessRun(EnumNodeStatus.Completed, "me", null);
         Assert.IsTrue(pr.hasAttribute("End"));
         Assert.IsTrue(pr.hasAttribute("ID"));
         n.setVersion(JDFElement.EnumVersion.Version_1_2);
         JDFModified mod = ap.addModified("me", n);
         Assert.IsFalse(mod.hasAttribute("ID"));
      }


      [TestMethod]
      public virtual void testFixVersion()
      {
         JDFDoc d = new JDFDoc(ElementName.JDF);
         JDFNode n = d.getJDFRoot();
         n.setType("ConventionalPrinting", true);
         JDFAuditPool ap = n.getAuditPool();
         Assert.IsNotNull(ap);
         JDFCreated crea = (JDFCreated)ap.getAudit(0, EnumAuditType.Created, null, null);
         Assert.IsTrue(crea.hasAttribute("ID"));
         n.fixVersion(JDFElement.EnumVersion.Version_1_2);
         Assert.IsFalse(crea.hasAttribute("ID"));
      }


      [TestMethod]
      public virtual void testSetRef()
      {
         JDFDoc d = new JDFDoc(ElementName.JDF);
         JDFNode n = d.getJDFRoot();
         n.setType("ConventionalPrinting", true);
         JDFAuditPool ap = n.getAuditPool();
         Assert.IsNotNull(ap);
         JDFPhaseTime pt = ap.setPhase(EnumNodeStatus.Stopped, null, null, null);
         JDFPhaseTime pt2 = ap.setPhase(EnumNodeStatus.Aborted, null, null, null);
         pt2.setRef(pt);
         Assert.AreEqual(pt.getID(), pt2.getrefID());
      }


      [TestMethod]
      public virtual void testCreateUpdate()
      {
         JDFDoc d = new JDFDoc(ElementName.JDF);
         JDFNode n = d.getJDFRoot();
         n.setType("ConventionalPrinting", true);
         JDFAuditPool ap = n.getAuditPool();
         Assert.IsNotNull(ap);
         JDFPhaseTime pt = ap.setPhase(EnumNodeStatus.Stopped, null, null, null);
         JDFPhaseTime pt2 = (JDFPhaseTime)pt.createUpdateAudit();
         Assert.AreEqual(pt.getID(), pt2.getrefID());
         Assert.AreNotEqual("", pt.getID());
         Assert.AreNotEqual("", pt2.getID());
         Assert.AreNotEqual(pt2.getID(), pt.getID());
      }


      [TestMethod]
      public virtual void testCreated()
      {
         JDFDoc d = new JDFDoc(ElementName.JDF);
         JDFNode n = d.getJDFRoot();
         n.setType(EnumType.ProcessGroup);
         JDFAuditPool ap = n.getAuditPool();
         Assert.IsNotNull(ap);
         JDFNode n2 = n.addJDFNode(EnumType.CaseMaking);
         JDFCreated c1 = ap.addCreated("foo", n2);
         Assert.AreEqual(c1.getXPath(), n2.buildXPath(ap.getParentJDF().buildXPath(null, 1), 1));
         JDFResource r = n2.addResource("CaseMakingParams", null, EnumUsage.Input, null, null, null, null);
         JDFCreated c2 = ap.addCreated("foo", r);
         Assert.AreEqual(c2.getXPath(), r.buildXPath(ap.getParentJDF().buildXPath(null, 1), 1));

         d.write2File(sm_dirTestDataTemp + "createdTest.jdf", 0, false);

      }


      [TestMethod]
      public virtual void testProcessRun()
      {
         JDFNode n = new JDFDoc(ElementName.JDF).getJDFRoot();
         n.setType(EnumType.ProcessGroup);
         JDFAuditPool ap = n.getAuditPool();
         Assert.IsNotNull(ap);
         JDFProcessRun p1 = ap.addProcessRun(EnumNodeStatus.Completed, null, null);
         Assert.AreEqual(new JDFDate(), p1.getTimeStampDate());
      }


      [TestMethod]
      public virtual void testSpawnID()
      {
         JDFDoc d = new JDFDoc(ElementName.JDF);
         JDFNode n = d.getJDFRoot();
         n.setSpawnID("spawn");
         n.setType(EnumType.ProcessGroup);
         JDFAuditPool ap = n.getAuditPool();
         Assert.IsNotNull(ap);
         JDFProcessRun p1 = ap.addProcessRun(EnumNodeStatus.Completed, null, null);
         Assert.AreEqual(p1.getSpawnID(), n.getSpawnID(false));
         JDFNode n2 = n.addJDFNode(EnumType.CaseMaking);
         JDFProcessRun p2 = n.getCreateAuditPool().addProcessRun(EnumNodeStatus.Completed, null, null);
         Assert.AreEqual(p2.getSpawnID(), n2.getSpawnID(true));
         Assert.AreEqual(p2.getSpawnID(), n.getSpawnID(false));
      }


      [TestMethod]
      public virtual void testSetStaticAgentVersion()
      {
         JDFDoc d = new JDFDoc(ElementName.JDF);
         JDFNode n = d.getJDFRoot();
         n.setType("ConventionalPrinting", true);
         JDFAuditPool ap = n.getAuditPool();
         Assert.IsNotNull(ap);
         JDFCreated crea = (JDFCreated)ap.getAudit(0, EnumAuditType.Created, null, null);
         Assert.AreEqual(crea.getAgentName(), JDFAudit.getStaticAgentName());

         JDFResource.setAutoAgent(true);
         JDFResource r = n.appendMatchingResource(ElementName.CONVENTIONALPRINTINGPARAMS, null, null);
         Assert.AreEqual(r.getAgentName(), JDFAudit.getStaticAgentName());
         Assert.AreEqual(r.getAgentVersion(), JDFAudit.getStaticAgentVersion());
         JDFAudit.setStaticAgentName(null);
         JDFAudit.setStaticAgentVersion(null);
         JDFAudit.setStaticAuthor(null);
         d = new JDFDoc(ElementName.JDF);
         n = d.getJDFRoot();
         n.setType("ConventionalPrinting", true);
         ap = n.getAuditPool();
         Assert.IsNotNull(ap);
         crea = (JDFCreated)ap.getAudit(0, EnumAuditType.Created, null, null);
         Assert.AreEqual("", crea.getAgentName());
         Assert.AreEqual("", crea.getAgentVersion());
         Assert.AreEqual("", crea.getAuthor());
         r = n.appendMatchingResource(ElementName.CONVENTIONALPRINTINGPARAMS, null, null);
         // Java to C# Conversion - AgentName and Agentversion attributes are there but values are ""
         Assert.IsFalse(r.hasAttribute(AttributeName.AGENTNAME));
         Assert.IsFalse(r.hasAttribute(AttributeName.AGENTVERSION));
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
         JDFResource.setAutoAgent(bAutoAgent);

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
         bAutoAgent = JDFResource.getAutoAgent();
         JDFElement.setLongID(false);
      }
   }
}