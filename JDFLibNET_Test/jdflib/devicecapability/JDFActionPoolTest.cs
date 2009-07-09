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


namespace org.cip4.jdflib.devicecapability
{
   using Microsoft.VisualStudio.TestTools.UnitTesting;

   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFAction = org.cip4.jdflib.resource.devicecapability.JDFAction;
   using JDFActionPool = org.cip4.jdflib.resource.devicecapability.JDFActionPool;
   using JDFDevCaps = org.cip4.jdflib.resource.devicecapability.JDFDevCaps;
   using JDFDeviceCap = org.cip4.jdflib.resource.devicecapability.JDFDeviceCap;
   using JDFIntegerState = org.cip4.jdflib.resource.devicecapability.JDFIntegerState;
   using JDFStringState = org.cip4.jdflib.resource.devicecapability.JDFStringState;
   using JDFTest = org.cip4.jdflib.resource.devicecapability.JDFTest;
   using JDFand = org.cip4.jdflib.resource.devicecapability.JDFand;
   using JDFnot = org.cip4.jdflib.resource.devicecapability.JDFnot;
   using EnumTerm = org.cip4.jdflib.resource.devicecapability.JDFTerm.EnumTerm;

   [TestClass]
   public class JDFActionPoolTest : JDFTestCaseBase
   {
      [TestMethod]
      public virtual void testAppendActionTest()
      {
         JDFDoc d = new JDFDoc(ElementName.PREFLIGHTPARAMS);
         JDFActionPool ap = (JDFActionPool)d.getRoot().appendElement(ElementName.ACTIONPOOL);
         JDFAction a = ap.appendActionTest(EnumTerm.and, true);
         JDFTest test = a.getTest();
         Assert.IsNotNull(test);
         Assert.IsNotNull(test.getTerm());
         Assert.IsTrue(test.getTerm() is JDFand);

         a = ap.appendActionTest(EnumTerm.and, false);
         test = a.getTest();
         Assert.IsNotNull(test);
         Assert.IsNotNull(test.getTerm());
         Assert.IsTrue(test.getTerm() is JDFnot);
         Assert.IsTrue(((JDFnot)test.getTerm()).getTerm(null, 0) is JDFand);
      }


      [TestMethod]
      public virtual void testAppendExcludeTest()
      {
         JDFDoc d = new JDFDoc(ElementName.DEVICECAP);
         JDFDeviceCap dc = (JDFDeviceCap)d.getRoot();

         JDFActionPool ap = (JDFActionPool)d.getRoot().appendElement(ElementName.ACTIONPOOL);
         JDFDevCaps dcs = dc.appendDevCaps();
         JDFStringState stst = dcs.appendDevCap().appendStringState("stbar");
         JDFIntegerState ist = dcs.appendDevCap().appendIntegerState("ibar");

         JDFAction ac = ap.appendExcludeTest(stst, ist);
         Assert.IsNotNull(ac);
         JDFTest t = ac.getTest();
         Assert.IsNotNull(t);
         JDFand a = (JDFand)t.getTerm();
         Assert.IsNotNull(a);
         Assert.IsNotNull(a.getTerm(EnumTerm.StringEvaluation, 0));
         Assert.IsNotNull(a.getTerm(EnumTerm.IntegerEvaluation, 0));
      }
   }
}
