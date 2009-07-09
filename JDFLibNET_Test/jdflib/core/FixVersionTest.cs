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

   using EnumApprovalState = org.cip4.jdflib.auto.JDFAutoApprovalDetails.EnumApprovalState;
   using EnumAuditType = org.cip4.jdflib.core.JDFAudit.EnumAuditType;
   using EnumVersion = org.cip4.jdflib.core.JDFElement.EnumVersion;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using EnumProcessUsage = org.cip4.jdflib.node.JDFNode.EnumProcessUsage;
   using JDFAuditPool = org.cip4.jdflib.pool.JDFAuditPool;
   using JDFResourcePool = org.cip4.jdflib.pool.JDFResourcePool;
   using JDFCreated = org.cip4.jdflib.resource.JDFCreated;
   using JDFTool = org.cip4.jdflib.resource.JDFTool;
   using EnumResStatus = org.cip4.jdflib.resource.JDFResource.EnumResStatus;
   using JDFApprovalDetails = org.cip4.jdflib.resource.process.JDFApprovalDetails;
   using JDFApprovalSuccess = org.cip4.jdflib.resource.process.JDFApprovalSuccess;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;
   using StringUtil = org.cip4.jdflib.util.StringUtil;

   [TestClass]
   public class FixVersionTest
   {
      private JDFDoc mDoc;
      private JDFNode n;

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see junit.framework.TestCase#setUp()
      //	 
      [TestInitialize]
      public virtual void setUp()
      {
         mDoc = new JDFDoc("JDF");
         n = mDoc.getJDFRoot();
      }


      [TestMethod]
      public virtual void testApprovalSuccess()
      {
         n.setType("Approval", true);
         JDFApprovalSuccess @as = (JDFApprovalSuccess)n.appendMatchingResource(ElementName.APPROVALSUCCESS, EnumProcessUsage.AnyOutput, null);
         n.setVersion(EnumVersion.Version_1_2);
         @as.appendContact();
         @as.appendFileSpec();
         bool bRet = n.fixVersion(EnumVersion.Version_1_3);
         Assert.IsTrue(bRet, "fix ok");
         Assert.IsNotNull(@as.getApprovalDetails(0), "approvaldetails");
         bRet = n.fixVersion(EnumVersion.Version_1_2);
         Assert.IsTrue(bRet, "fix ok");
         Assert.IsNull(@as.getApprovalDetails(0), "approvaldetails");
         bRet = n.fixVersion(EnumVersion.Version_1_3);
         Assert.IsTrue(bRet, "fix ok");
         @as = (JDFApprovalSuccess)n.getMatchingResource(ElementName.APPROVALSUCCESS, EnumProcessUsage.AnyOutput, null, 0);
         JDFApprovalDetails ad = @as.getApprovalDetails(0);
         ad.setApprovalState(EnumApprovalState.Rejected);
         bRet = n.fixVersion(EnumVersion.Version_1_2);
         Assert.IsFalse(bRet, "fix not ok");
      }


      [TestMethod]
      public virtual void testRRefs()
      {
         JDFResourcePool rp = n.appendResourcePool();
         rp.setAttribute(AttributeName.RREFS, "a b", null);
         n.fixVersion(null);
         Assert.IsFalse(rp.hasAttribute(AttributeName.RREFS));
      }


      [TestMethod]
      public virtual void testAudit()
      {
         JDFAuditPool ap = n.getAuditPool();
         Assert.IsNotNull(ap);
         JDFCreated crea = (JDFCreated)ap.getAudit(0, EnumAuditType.Created, null, null);
         string agent = crea.getAgentName();
         Assert.IsNotNull(agent);
         string author = crea.getAuthor();
         Assert.IsNotNull(author);

         n.fixVersion(EnumVersion.Version_1_1);
         author = crea.getAuthor();
         Assert.AreEqual(agent, StringUtil.token(author, 1, "_|_"));
         Assert.IsTrue(author.StartsWith(agent));
         string agent2 = crea.getAgentName();
         Assert.AreEqual("", agent2);

         n.fixVersion(EnumVersion.Version_1_3);
         author = crea.getAuthor();
         Assert.AreEqual(-1, author.IndexOf("_|_"));
         agent2 = crea.getAgentName();
         Assert.AreEqual(agent, agent2);

         n.fixVersion(EnumVersion.Version_1_2);
         author = crea.getAuthor();
         Assert.AreEqual(-1, author.IndexOf("_|_"));
         agent2 = crea.getAgentName();
         Assert.AreEqual(agent, agent2);

      }

      [TestMethod]
      public virtual void testResourceStatus()
      {
         JDFMedia m = (JDFMedia)n.addResource("Media", null, EnumUsage.Input, null, null, null, null);
         m.setResStatus(EnumResStatus.Available, true);
         Assert.AreEqual(EnumResStatus.Available, m.getResStatus(true));
         Assert.IsTrue(m.fixVersion(EnumVersion.Version_1_1));
         Assert.AreEqual(EnumResStatus.Available, m.getResStatus(true));
         Assert.IsTrue(m.fixVersion(EnumVersion.Version_1_3));
         Assert.AreEqual(EnumResStatus.Available, m.getResStatus(true));
      }

      [TestMethod]
      public virtual void testTool()
      {
         JDFTool t = (JDFTool)n.addResource("Tool", null, EnumUsage.Input, null, null, null, null);
         t.setResStatus(EnumResStatus.Available, true);
         t.setProductID("toolID");
         Assert.IsTrue(t.fixVersion(EnumVersion.Version_1_1));
         Assert.AreEqual("toolID", t.getToolID());
         Assert.AreEqual("toolID", t.getProductID());
         Assert.IsTrue(t.fixVersion(EnumVersion.Version_1_3));
         Assert.AreEqual("", t.getToolID());
         Assert.AreEqual("toolID", t.getProductID());
      }
   }
}