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


/*
 * ProcessRunTest.cs
 * @author Dietrich Mucha
 * Copyright (C) 2004 Heidelberger Druckmaschinen AG. All Rights Reserved.
 */

namespace org.cip4.jdflib.resource
{
   using Microsoft.VisualStudio.TestTools.UnitTesting;

   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using EnumNodeStatus = org.cip4.jdflib.core.JDFElement.EnumNodeStatus;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using JDFAuditPool = org.cip4.jdflib.pool.JDFAuditPool;
   using JDFDate = org.cip4.jdflib.util.JDFDate;

   [TestClass]
   public class ProcessRunTest : JDFTestCaseBase
   {
      [TestMethod]
      public virtual void testGetDuration()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode n = doc.getJDFRoot();
         JDFAuditPool ap = n.getCreateAuditPool();
         JDFProcessRun pt = ap.addProcessRun(EnumNodeStatus.Completed, null, null);
         pt.setStart(new JDFDate());
         JDFDate end = new JDFDate();
         end.TimeInMillis = end.TimeInMillis + 100 * 1000;
         pt.setEnd(end);
         Assert.AreEqual(100.0, pt.getDuration().Duration, 1.0);
         pt.setDurationSeconds(50);
         Assert.AreEqual(50.0, pt.getDuration().Duration, 1.0);
      }


      [TestMethod]
      public virtual void testAddPhaseTime()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode n = doc.getJDFRoot();
         JDFAuditPool ap = n.getCreateAuditPool();
         JDFProcessRun pr = ap.addProcessRun(EnumNodeStatus.Completed, null, null);
         JDFPhaseTime pt0 = null;
         for (int i = 0; i < 10; i++)
         {
            JDFPhaseTime pt = ap.addPhaseTime(EnumNodeStatus.InProgress, null, null);
            if (i == 0)
            {
               pt0 = pt;
            }

            JDFDate start = new JDFDate();
            start.TimeInMillis = start.TimeInMillis + i * 1000 * 1000;
            pt.setStart(start);
            JDFDate end = new JDFDate();
            end.TimeInMillis = end.TimeInMillis + 100 * 1000 + i * 1000 * 1000;
            pt.setEnd(end);
            Assert.AreEqual(100, pt.getDuration().Duration, 1.0);

            pr.addPhase(pt);
            Assert.AreEqual((i + 1) * 100, pr.getDuration().Duration, 1.0);
            if (pt0 != null)
            {
               Assert.AreEqual(pr.getStart(), pt0.getStart());
            }
            Assert.AreEqual(pr.getEnd(), pt.getEnd());
         }
      }
   }
}
