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



namespace org.cip4.jdflib.resource.process
{
   using System.Collections.Generic;
   using Microsoft.VisualStudio.TestTools.UnitTesting;

   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using EnumScope = org.cip4.jdflib.auto.JDFAutoUsageCounter.EnumScope;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using VString = org.cip4.jdflib.core.VString;
   using EnumAuditType = org.cip4.jdflib.core.JDFAudit.EnumAuditType;
   using EnumValidationLevel = org.cip4.jdflib.core.KElement.EnumValidationLevel;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using EnumProcessUsage = org.cip4.jdflib.node.JDFNode.EnumProcessUsage;
   using EnumType = org.cip4.jdflib.node.JDFNode.EnumType;
   using JDFAuditPool = org.cip4.jdflib.pool.JDFAuditPool;
   using JDFResourceAudit = org.cip4.jdflib.resource.JDFResourceAudit;
   using StringUtil = org.cip4.jdflib.util.StringUtil;
   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   [TestClass]
   public class JDFUsageCounterTest : JDFTestCaseBase
   {

      //   
      //	 * Test method for
      //	 * 'org.cip4.jdflib.resource.process.JDFMedia.setDimensionCM(JDFXYPair)'
      //	 
      [TestMethod]
      public void testUsageCounter()
      {
         JDFElement.setLongID(false);
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode root = doc.getJDFRoot();
         root.setType(EnumType.DigitalPrinting);
         JDFUsageCounter uc = (JDFUsageCounter)root.appendMatchingResource(
            ElementName.USAGECOUNTER, EnumProcessUsage.AnyInput, null);
         Assert.IsTrue(uc.isValid(EnumValidationLevel.Incomplete));
         Assert.IsFalse(uc.isValid(EnumValidationLevel.Complete));
         uc.setCounterID("c1");
         uc.setScope(EnumScope.Job);
         uc.setCounterTypes(new VString(
            "NormalSize Black OneSided TwoSided Impressions", " "));
         Assert.IsTrue(uc.isValid(EnumValidationLevel.Complete));
         Assert.AreEqual(StringUtil.setvString(uc.getEnumCounterTypes()),
            StringUtil.setvString(uc.getCounterTypes()));
         JDFResourceLink rl = root.getLink(uc, null);
         rl.setActualAmount(10, null);
         JDFAuditPool ap = root.getCreateAuditPool();
         JDFResourceAudit ra = (JDFResourceAudit)ap.addAudit(
            EnumAuditType.ResourceAudit, null);
         ra.updateLink(rl);

         JDFUsageCounter uc2 = (JDFUsageCounter)root.appendMatchingResource(
            ElementName.USAGECOUNTER, EnumProcessUsage.AnyInput, null);
         uc2.setCounterID("c2");
         uc2.setScope(EnumScope.Job);
         uc2.setCounterTypes(new VString(
            "NormalSize Color OneSided TwoSided Impressions", " "));
         Assert.IsTrue(uc2.isValid(EnumValidationLevel.Complete));
         Assert.AreEqual(StringUtil.setvString(uc2.getEnumCounterTypes()),
            StringUtil.setvString(uc2.getCounterTypes()));
         rl = root.getLink(uc2, null);
         rl.setActualAmount(20, null);
         ra = (JDFResourceAudit)ap.addAudit(EnumAuditType.ResourceAudit, null);
         ra.updateLink(rl);

         JDFUsageCounter uc3 = (JDFUsageCounter)root.appendMatchingResource(
            ElementName.USAGECOUNTER, EnumProcessUsage.AnyInput, null);
         uc3.setCounterID("c3");
         uc3.setScope(EnumScope.Job);
         uc3.setCounterTypes(new VString(
            "LargeSize Black OneSided TwoSided Impressions", " "));
         Assert.IsTrue(uc3.isValid(EnumValidationLevel.Complete));
         Assert.AreEqual(StringUtil.setvString(uc3.getEnumCounterTypes()),
            StringUtil.setvString(uc3.getCounterTypes()));
         rl = root.getLink(uc3, null);
         rl.setActualAmount(30, null);
         ra = (JDFResourceAudit)ap.addAudit(EnumAuditType.ResourceAudit, null);
         ra.updateLink(rl);

         JDFUsageCounter uc4 = (JDFUsageCounter)root.appendMatchingResource(
            ElementName.USAGECOUNTER, EnumProcessUsage.AnyInput, null);
         uc4.setCounterID("c4");
         uc4.setScope(EnumScope.Job);
         uc4.setCounterTypes(new VString(
            "LargeSize Color OneSided TwoSided Impressions", " "));
         Assert.IsTrue(uc4.isValid(EnumValidationLevel.Complete));
         Assert.AreEqual(StringUtil.setvString(uc4.getEnumCounterTypes()),
            StringUtil.setvString(uc4.getCounterTypes()));
         rl = root.getLink(uc4, null);
         rl.setActualAmount(40, null);
         ra = (JDFResourceAudit)ap.addAudit(EnumAuditType.ResourceAudit, null);
         ra.updateLink(rl);
         Assert.IsTrue(root.isValid(EnumValidationLevel.Incomplete));

         doc.write2File(sm_dirTestDataTemp + "UCList.jdf", 2, false);
      }


      [TestMethod]
      public void testMatchesString()
      {
         JDFUsageCounter c = (JDFUsageCounter)new JDFDoc(
            ElementName.USAGECOUNTER).getRoot();
         Assert.IsTrue(c.matchesString(ElementName.USAGECOUNTER));
         Assert.IsFalse(c.matchesString(ElementName.USAGECOUNTER + ":"));
         c.setCounterTypes(new VString("Black SingleSided", null));
         Assert.IsFalse(c.matchesString(ElementName.USAGECOUNTER + ":Black"));
         Assert.IsTrue(c.matchesString(ElementName.USAGECOUNTER
            + ":Black_SingleSided"));
         Assert.IsTrue(c.matchesString(ElementName.USAGECOUNTER));
         c.setCounterID("CID");
         Assert.IsTrue(c.matchesString(ElementName.USAGECOUNTER + ":CID"));
         Assert.IsFalse(c.matchesString(ElementName.USAGECOUNTER + ":CID2"));
         Assert.IsFalse(c.matchesString(ElementName.USAGECOUNTER + ":CI"));
         Assert.IsFalse(c.matchesString(ElementName.USAGECOUNTER + ":cid"));
      }
   }
}
