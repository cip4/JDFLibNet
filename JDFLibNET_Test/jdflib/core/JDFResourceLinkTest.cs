
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
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using EnumValidationLevel = org.cip4.jdflib.core.KElement.EnumValidationLevel;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using JDFIntegerList = org.cip4.jdflib.datatypes.JDFIntegerList;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using JDFCommand = org.cip4.jdflib.jmf.JDFCommand;
   using JDFJMF = org.cip4.jdflib.jmf.JDFJMF;
   using JDFPipeParams = org.cip4.jdflib.jmf.JDFPipeParams;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using EnumProcessUsage = org.cip4.jdflib.node.JDFNode.EnumProcessUsage;
   using EnumType = org.cip4.jdflib.node.JDFNode.EnumType;
   using JDFResourceLinkPool = org.cip4.jdflib.pool.JDFResourceLinkPool;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using EnumPartIDKey = org.cip4.jdflib.resource.JDFResource.EnumPartIDKey;
   using EnumPartUsage = org.cip4.jdflib.resource.JDFResource.EnumPartUsage;
   using EnumResStatus = org.cip4.jdflib.resource.JDFResource.EnumResStatus;
   using EnumResourceClass = org.cip4.jdflib.resource.JDFResource.EnumResourceClass;
   using JDFComponent = org.cip4.jdflib.resource.process.JDFComponent;
   using JDFExposedMedia = org.cip4.jdflib.resource.process.JDFExposedMedia;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;
   using JDFRunList = org.cip4.jdflib.resource.process.JDFRunList;

   ///
   /// <summary> * @author MuchaD
   /// * 
   /// *         This implements the first fixture with unit tests for class
   /// *         JDFElement. </summary>
   /// 
   [TestClass]
   public class JDFResourceLinkTest : JDFTestCaseBase
   {

      [TestMethod]
      public virtual void testAmount()
      {
         JDFDoc d = new JDFDoc(ElementName.JDF);
         JDFNode n = d.getJDFRoot();
         n.setVersion(JDFElement.EnumVersion.Version_1_3);
         n.setType("ConventionalPrinting", true);
         JDFMedia m = (JDFMedia)n.addResource(ElementName.MEDIA, null, EnumUsage.Input, null, null, null, null);
         JDFResourceLink rl = n.getLink(m, null);

         m.setAmount(42);
         Assert.AreEqual("42", m.getAttribute(AttributeName.AMOUNT), "m amount!=42");
         Assert.IsTrue(rl.getAmount(null) == 42, "rl amount!=42");
         Assert.IsTrue(rl.getMinAmount(null) == 42, "rl amount!=42");
         Assert.IsTrue(rl.getMaxAmount(null) == 42, "rl amount!=42");

         rl.setAmount(44, null);
         Assert.AreEqual("44", rl.getAttribute(AttributeName.AMOUNT), "ml amount!=44");
         Assert.IsTrue(rl.getAmount(null) == 44, "rl amount!=44");
         Assert.IsTrue(rl.getMinAmount(null) == 44, "rl amount!=44");
         Assert.IsTrue(rl.getMaxAmount(null) == 44, "rl amount!=44");
      }


      [TestMethod]
      public virtual void testAmountCondition()
      {
         JDFDoc d = new JDFDoc(ElementName.JDF);
         JDFNode n = d.getJDFRoot();
         n.setVersion(JDFElement.EnumVersion.Version_1_3);
         n.setType("ConventionalPrinting", true);
         JDFMedia m = (JDFMedia)n.addResource(ElementName.MEDIA, null, EnumUsage.Input, null, null, null, null);
         JDFResourceLink rl = n.getLink(m, null);
         JDFAttributeMap map = new JDFAttributeMap("SheetName", "s1");
         JDFAttributeMap mapC = new JDFAttributeMap(map);
         mapC.put("Condition", "Good");

         m.setAmount(42);
         Assert.AreEqual("42", m.getAttribute(AttributeName.AMOUNT), "m amount!=42");
         Assert.AreEqual(42.0, rl.getAmount(null), 0.1, "rl amount!=42");
         Assert.AreEqual(42.0, rl.getMinAmount(null), 0.1, "rl amount!=42");
         Assert.AreEqual(42.0, rl.getMaxAmount(null), 0.1, "rl amount!=42");

         rl.setAmount(44, map);
         Assert.AreEqual(44.0, rl.getAmount(map), 0.1, "rl amount!=42");
         Assert.AreEqual(44.0, rl.getMinAmount(map), 0.1, "rl amount!=42");
         Assert.AreEqual(44.0, rl.getMaxAmount(map), 0.1, "rl amount!=42");

         Assert.AreEqual(-1.0, rl.getAmount(mapC), 0.1, "no good in map");
         Assert.AreEqual(-1.0, rl.getMinAmount(mapC), 0.1, "no good in map");
         Assert.AreEqual(-1.0, rl.getMaxAmount(mapC), 0.1, "no good in map");

         rl.removeChild(ElementName.AMOUNTPOOL, null, 0);
         rl.setAmount(44, mapC);
         Assert.AreEqual(44.0, rl.getAmount(mapC), 0.1, "rl amount!=42");
         Assert.AreEqual(44.0, rl.getMinAmount(mapC), 0.1, "rl amount!=42");
         Assert.AreEqual(44.0, rl.getMaxAmount(mapC), 0.1, "rl amount!=42");

         Assert.AreEqual(44.0, rl.getAmount(map), 0.1, "no good in rl");
         Assert.AreEqual(44.0, rl.getMinAmount(map), 0.1, "no good in rl");
         Assert.AreEqual(44.0, rl.getMaxAmount(map), 0.1, "no good in rl");

         JDFAttributeMap mapW = new JDFAttributeMap(map);
         mapW.put("Condition", "Waste");
         rl.setAmount(4, mapW);
         Assert.AreEqual(48.0, rl.getAmount(map), 0.1, "sum g/w in rl");
         Assert.AreEqual(48.0, rl.getMinAmount(map), 0.1, "sum g/w in rl");
         Assert.AreEqual(48.0, rl.getMaxAmount(map), 0.1, "sum g/w in rl");
      }


      [TestMethod]
      public virtual void testAppendAmountPool()
      {
         JDFDoc d = new JDFDoc("MediaLink");
         JDFResourceLink rl = (JDFResourceLink)d.getRoot();
         Assert.IsNotNull(rl.appendAmountPool());
         try
         {
            rl.appendAmountPool();
            Assert.Fail("AmountPool #2");
         }
         catch (JDFException)
         {
            // nop
         }

      }


      [TestMethod]
      public virtual void testDraftOK()
      {
         JDFDoc d = new JDFDoc(ElementName.JDF);
         JDFNode n = d.getJDFRoot();
         n.setVersion(JDFElement.EnumVersion.Version_1_3);
         n.setType("ProcessGroup", true);
         JDFCustomerInfo ci = (JDFCustomerInfo)n.addResource(ElementName.CUSTOMERINFO, null, EnumUsage.Input, null, null, null, null);
         JDFComponent co = (JDFComponent)n.addResource(ElementName.COMPONENT, null, EnumUsage.Output, null, null, null, null);
         JDFResourceLink rl = n.getLink(ci, null);
         Assert.AreEqual(JDFResource.EnumResStatus.Available, rl.getMinStatus(), "available");

         rl.setDraftOK(true);
         Assert.AreEqual(JDFResource.EnumResStatus.Draft, rl.getMinStatus(), "draft");
         Assert.IsTrue(!rl.hasAttribute(AttributeName.DRAFTOK), "has no draft");
         Assert.IsTrue(rl.getMinLateStatus() == JDFResource.EnumResStatus.Draft, "late draft");
         Assert.IsTrue(rl.isValid(EnumValidationLevel.Complete), "1.3 valid");
         rl.setDraftOK(false);
         Assert.AreEqual(JDFResource.EnumResStatus.Available, rl.getMinStatus(), "draft");
         Assert.IsTrue(!rl.hasAttribute(AttributeName.DRAFTOK), "has no draft");
         Assert.IsTrue(rl.getMinLateStatus() == JDFResource.EnumResStatus.Available, "late draft");
         Assert.IsTrue(rl.isValid(EnumValidationLevel.Complete), "1.3 valid");
         rl.removeAttribute(AttributeName.MINSTATUS);

         n.setVersion(JDFElement.EnumVersion.Version_1_2);
         rl.setDraftOK(true);
         Assert.IsTrue(rl.getMinStatus() == JDFResource.EnumResStatus.Draft, "draft");
         Assert.IsTrue(rl.hasAttribute(AttributeName.DRAFTOK), "has draft");
         Assert.IsTrue(!rl.hasAttribute(AttributeName.MINSTATUS), "has no MinStatus");
         Assert.AreEqual(rl.getMinLateStatus(), JDFResource.EnumResStatus.Draft, "late draft");
         Assert.IsTrue(rl.isValid(EnumValidationLevel.Complete), "1.2 valid");
         rl.setDraftOK(false);
         Assert.IsTrue(rl.getMinStatus() == JDFResource.EnumResStatus.Available, "draft");
         Assert.IsTrue(rl.hasAttribute(AttributeName.DRAFTOK), "has draft");
         Assert.IsTrue(!rl.hasAttribute(AttributeName.MINSTATUS), "has no MinStatus");
         Assert.AreEqual(rl.getMinLateStatus(), JDFResource.EnumResStatus.Available, "late draft");
         Assert.IsTrue(rl.isValid(EnumValidationLevel.Complete), "1.2 valid");

         rl = n.getLink(co, null);
         Assert.AreEqual(JDFResource.EnumResStatus.Unavailable, rl.getMinStatus(), "unavailable");
      }


      [TestMethod]
      public virtual void testGetMinAmountPoolAttribute()
      {
         JDFDoc d = new JDFDoc("TestLink");
         JDFResourceLink rl = (JDFResourceLink)d.getRoot();
         rl.setActualAmount(12, new JDFAttributeMap("SignatureName", "1"));
         rl.setActualAmount(14, new JDFAttributeMap("SignatureName", "2"));
         Assert.AreEqual(12.0, rl.getMinAmountPoolAttribute("ActualAmount", null, null, 42), 0.0);

         JDFAttributeMap map = new JDFAttributeMap("SignatureName", "3");
         map.put("SheetName", "a");
         rl.setActualAmount(24, map);
         map.put("SheetName", "b");
         rl.setActualAmount(26, map);
         Assert.AreEqual(24.0, rl.getMinAmountPoolAttribute("ActualAmount", null, new JDFAttributeMap("SignatureName", "3"), 42), 0.0);
      }


      [TestMethod]
      public virtual void testExpandAmountPool()
      {
         JDFDoc d = new JDFDoc(ElementName.JDF);
         JDFNode n = d.getJDFRoot();
         n.setVersion(JDFElement.EnumVersion.Version_1_3);
         n.setType("ConventionalPrinting", true);
         JDFComponent comp = (JDFComponent)n.addResource(ElementName.COMPONENT, null, EnumUsage.Output, null, null, null, null);
         comp.addPartitions(EnumPartIDKey.SheetName, new VString("S1 S2 S3", null));
         JDFResourceLink rl = n.getLink(comp, null);
         rl.setAmount(42, null);
         rl.setPipeProtocol("JDF");
         Assert.AreEqual(42.0, rl.getAmount(null), 0.1);
         Assert.IsNull(rl.getAmountPool());
         rl.expandAmountPool();
         Assert.IsNull(rl.getAttribute("Amount", null, null));
         Assert.AreEqual(42.0, rl.getAmount(new JDFAttributeMap(EnumPartIDKey.SheetName, "S2")), 0.1);
         Assert.IsNotNull(rl.getAmountPool());
         Assert.AreEqual("JDF", rl.getPipeProtocol());

      }


      [TestMethod]
      public virtual void testGenerateCPI()
      {
         JDFDoc d = new JDFDoc(ElementName.JDF);
         JDFNode n = d.getJDFRoot();
         n.setVersion(JDFElement.EnumVersion.Version_1_3);
         JDFResource r = n.addResource(ElementName.CONVENTIONALPRINTINGPARAMS, EnumUsage.Input);
         JDFResourceLink rl = n.getLink(r, null);
         Assert.IsNull(rl.getCombinedProcessIndex());
         n.setCombined(new VString("ImageSetting ConventionalPrinting", null));
         rl.generateCombinedProcessIndex();
         Assert.AreEqual(new JDFIntegerList("1"), rl.getCombinedProcessIndex());
         n.setCombined(new VString("ImageSetting ConventionalPrinting ConventionalPrinting", null));
         rl.generateCombinedProcessIndex();
         Assert.AreEqual(new JDFIntegerList("1 2"), rl.getCombinedProcessIndex());
      }


      [TestMethod]
      public virtual void testGetAmountPoolDouble()
      {
         JDFDoc d = new JDFDoc("TestLink");
         JDFResourceLink rl = (JDFResourceLink)d.getRoot();
         rl.setActualAmount(12, new JDFAttributeMap("SignatureName", "1"));
         rl.setActualAmount(14, new JDFAttributeMap("SignatureName", "2"));
         Assert.AreEqual(26.0, rl.getActualAmount(null), 0.1);
         rl.setAmount(42.0, null);
         Assert.AreEqual(42.0, rl.getAmount(new JDFAttributeMap("SignatureName", "2")), 0.1, "root attribute is incorrectly retrieved");
         rl.removeChild(ElementName.AMOUNTPOOL, null, 0);
         rl.setActualAmount(33, null);
         Assert.AreEqual(33.0, rl.getActualAmount(null), 0.1);
      }


      [TestMethod]
      public virtual void testGetAmountPoolSumDouble()
      {
         JDFNode d = new JDFDoc("JDF").getJDFRoot();
         JDFResource m = d.addResource("Media", EnumUsage.Input);
         m.addPartition(EnumPartIDKey.SignatureName, "1");
         JDFResourceLink rl = d.getLink(m, EnumUsage.Input);
         JDFAttributeMap map = new JDFAttributeMap("SignatureName", "1");
         map.put("Condition", "Good");

         rl.setActualAmount(12, map);
         VJDFAttributeMap vMap = new VJDFAttributeMap();
         vMap.Add(new JDFAttributeMap("SignatureName", "1"));
         JDFAttributeMap sig1 = new JDFAttributeMap("SignatureName", "2");
         vMap.Add(sig1);

         rl.getAmountPool().getPartAmount(map).setPartMapVector(vMap);
         map.put("Condition", "Waste");
         rl.setActualAmount(14, map);
         Assert.AreEqual(26.0, rl.getAmountPoolSumDouble(AttributeName.ACTUALAMOUNT, null), 0.1);
         Assert.AreEqual(26.0, rl.getAmountPoolSumDouble(AttributeName.ACTUALAMOUNT, vMap), 0.1);
         sig1.put("SheetName", "S1");
         Assert.AreEqual(26.0, rl.getAmountPoolSumDouble(AttributeName.ACTUALAMOUNT, vMap), 0.1, " also when more granular");
         sig1 = new JDFAttributeMap(sig1);
         sig1.put("SheetName", "S2");
         vMap.Add(sig1);
         Assert.AreEqual(26.0, rl.getAmountPoolSumDouble(AttributeName.ACTUALAMOUNT, vMap), 0.1, " also when more granular");
      }


      [TestMethod]
      public virtual void testGetAmountPoolVector()
      {
         JDFDoc d = new JDFDoc("TestLink");
         JDFResourceLink rl = (JDFResourceLink)d.getRoot();
         VJDFAttributeMap vM = new VJDFAttributeMap();
         vM.Add(new JDFAttributeMap("SignatureName", "1"));
         vM.Add(new JDFAttributeMap("SignatureName", "2"));
         rl.setAmountPoolAttribute("Amount", "42", null, vM);

         Assert.AreEqual("42", rl.getAmountPoolAttribute("Amount", null, vM));
         vM.Add(new JDFAttributeMap("SignatureName", "3"));
         Assert.IsNull(rl.getAmountPoolAttribute("Amount", null, vM));
      }


      [TestMethod]
      public virtual void testPartAmount()
      {
         JDFDoc d = new JDFDoc(ElementName.JDF);
         JDFNode n = d.getJDFRoot();
         n.setVersion(JDFElement.EnumVersion.Version_1_3);
         n.setType("ConventionalPrinting", true);
         JDFExposedMedia xm = (JDFExposedMedia)n.addResource(ElementName.EXPOSEDMEDIA, null, EnumUsage.Input, null, null, null, null);
         JDFExposedMedia xm1 = (JDFExposedMedia)xm.addPartition(JDFResource.EnumPartIDKey.SheetName, "Sheet1");
         xm.addPartition(JDFResource.EnumPartIDKey.SheetName, "Sheet2");
         xm1.setAmount(1.0);
         xm.setAmount(2.0);
         JDFAttributeMap map1 = new JDFAttributeMap(JDFResource.EnumPartIDKey.SheetName.getName(), "Sheet1");
         JDFAttributeMap map2 = new JDFAttributeMap(JDFResource.EnumPartIDKey.SheetName.getName(), "Sheet2");

         JDFResourceLink rl = n.getLink(xm, null);
         JDFPartAmount pa = rl.getCreateAmountPool().getCreatePartAmount(new JDFAttributeMap("SheetName", "Sheet1"));
         pa.setDraftOK(true);
         Assert.IsTrue(pa.getMinStatus() == JDFResource.EnumResStatus.Draft, "draft");
         Assert.IsTrue(!pa.hasAttribute(AttributeName.DRAFTOK), "has no draft");
         Assert.IsTrue(pa.getMinLateStatus() == JDFResource.EnumResStatus.Draft, "late draft");
         pa.removeAttribute(AttributeName.MINSTATUS);
         n.setVersion(JDFElement.EnumVersion.Version_1_2);
         pa.setDraftOK(true);
         Assert.IsTrue(pa.getMinStatus() == JDFResource.EnumResStatus.Draft, "draft");
         Assert.IsTrue(pa.hasAttribute(AttributeName.DRAFTOK), "has draft");
         Assert.IsTrue(!pa.hasAttribute(AttributeName.MINSTATUS), "has no MinStatus");
         Assert.IsTrue(pa.getMinLateStatus() == JDFResource.EnumResStatus.Draft, "late draft");

         rl.setMinAmount(42.0, map1);
         Assert.AreEqual(42.0, rl.getMinAmount(map1), 0.0, "map1min");
         Assert.AreEqual(1.0, rl.getMaxAmount(map1), 0.0, "map1max");
         Assert.AreEqual(2.0, rl.getMinAmount(map2), 0.0, "map2min"); // last default
         Assert.AreEqual(2.0, rl.getMaxAmount(null), 0.0, "map0min"); // last default
         pa.setAmount(55, null);
         Assert.AreEqual(55.0, pa.getAmount(null), 0.0, "pa amount");
      }


      [TestMethod]
      public virtual void testPartAmountVirtual()
      {
         JDFDoc d = new JDFDoc(ElementName.JDF);
         JDFNode n = d.getJDFRoot();
         n.setVersion(JDFElement.EnumVersion.Version_1_3);
         n.setType("ConventionalPrinting", true);
         JDFComponent comp = (JDFComponent)n.appendMatchingResource(ElementName.COMPONENT, EnumProcessUsage.AnyOutput, null);

         JDFResourceLink cpLink = n.getLink(comp, null);
         JDFAttributeMap mapBad = new JDFAttributeMap("Condition", "Waste");
         cpLink.setActualAmount(42, mapBad);
         Assert.AreEqual(42.0, cpLink.getActualAmount(mapBad), 0);
         Assert.IsTrue(n.isValid(EnumValidationLevel.Incomplete), "allow part amounts to non-existing partitions");

         cpLink.removeChild(ElementName.AMOUNTPOOL, null, 0);
         comp.addPartition(EnumPartIDKey.SheetName, "Sheet1");
         mapBad.put(EnumPartIDKey.SheetName.getName(), "Sheet1");
         cpLink.setActualAmount(42, mapBad);
         Assert.AreEqual(42.0, cpLink.getActualAmount(mapBad), 0);
         Assert.IsTrue(n.isValid(EnumValidationLevel.Incomplete), "allow partamounts to non-existing partitions");
         mapBad.put(EnumPartIDKey.SheetName.getName(), "Sheet2");
         Assert.AreEqual(0.0, cpLink.getActualAmount(mapBad), 0);
         JDFAttributeMap m2 = new JDFAttributeMap("Condition", "Waste");
         Assert.AreEqual(42.0, cpLink.getActualAmount(m2), 0);
         m2.put("SheetName", "Sheet1");
         Assert.AreEqual(42.0, cpLink.getActualAmount(m2), 0);
         m2.put("Side", "Front");
         Assert.AreEqual(0.0, cpLink.getActualAmount(m2), 0);
      }


      [TestMethod]
      public virtual void testSetAmountPoolAttribute()
      {
         JDFDoc d = new JDFDoc("ResourceLinkPool");
         JDFResourceLinkPool rlp = (JDFResourceLinkPool)d.getRoot();
         JDFResourceLink foo = (JDFResourceLink)rlp.appendElement("FooLink");
         VJDFAttributeMap vPart = new VJDFAttributeMap();
         vPart.Add(new JDFAttributeMap());
         foo.setAmountPoolAttribute("blub", "123", null, vPart);
         Assert.AreEqual("123", foo.getAttribute("blub"));
         vPart = new VJDFAttributeMap();
         JDFAttributeMap map = new JDFAttributeMap("SheetName", "b");
         vPart.Add(map);
         foo.setAmountPoolAttribute("blub", "123", null, vPart);
         Assert.IsNull(foo.getAttribute("blub", null, null));
         Assert.AreEqual("123", foo.getAmountPoolAttribute("blub", null, map, 0));
      }


      [TestMethod]
      public virtual void testGetLinkRootJMF()
      {
         JDFDoc d = new JDFDoc("JMF");
         JDFJMF jmf = d.getJMFRoot();
         jmf.setSenderID("Elvis");
         JDFCommand c = jmf.appendCommand();
         c.setType("PipePull");
         JDFPipeParams pp = c.appendPipeParams();
         pp.setAttribute(AttributeName.PIPEID, "foo", null);
         JDFRunList ruli = (JDFRunList)pp.appendResource(ElementName.RUNLIST);
         JDFResourceLink rl = pp.appendResourceLink("RunListLink", true);
         rl.setrRef(ruli.getID());
         Assert.IsTrue(jmf.isValid(EnumValidationLevel.Complete), "valid param");
         Assert.AreEqual( rl.getTarget(), ruli);
      }


      [TestMethod]
      public virtual void testGetTargetVector()
      {
         JDFDoc d = JDFTestCaseBase.creatXMDoc();
         JDFNode n = d.getJDFRoot();
         JDFAttributeMap mPart = new JDFAttributeMap("SignatureName", "Sig1");
         mPart.put("SheetName", "S1");
         JDFResourceLink rl = n.getMatchingLink("ExposedMedia", EnumProcessUsage.Plate, 0);
         rl.setPartMap(mPart);
         VElement v = rl.getTargetVector(0);
         Assert.AreEqual(1, v.Count, "The target vector is the node with two leaves");
      }


      [TestMethod]
      public virtual void testGetTargetVectorSparse()
      {
         JDFNode n = new JDFDoc("JDF").getJDFRoot();
         JDFExposedMedia xm = (JDFExposedMedia)n.getCreateResource("ExposedMedia", EnumUsage.Input, 0);
         JDFExposedMedia xmb = (JDFExposedMedia)xm.addPartition(EnumPartIDKey.Separation, "Black");
         JDFExposedMedia xmbe = (JDFExposedMedia)xmb.addPartition(EnumPartIDKey.PartVersion, "EN");
         JDFExposedMedia xmbd = (JDFExposedMedia)xmb.addPartition(EnumPartIDKey.PartVersion, "DE");
         JDFExposedMedia xmc = (JDFExposedMedia)xm.addPartition(EnumPartIDKey.Separation, "Cyan");
         xm.setPartUsage(EnumPartUsage.Sparse);
         JDFResourceLink rl = n.getLink(xm, null);
         rl.setPartMap(new JDFAttributeMap("PartVersion", "DE"));
         VElement v = rl.getTargetVector(-1);
         Assert.AreEqual(2, v.Count, "DE/Black + Cyan");
         Assert.AreEqual(xmbd, v[0]);
         Assert.AreEqual(xmc, v[1]);
         rl.setPartMap(new JDFAttributeMap("PartVersion", "EN"));
         v = rl.getTargetVector(-1);
         Assert.AreEqual(2, v.Count);
         Assert.AreEqual(xmbe, v[0]);
         Assert.AreEqual(xmc, v[1]);
         rl.setPartMap(new JDFAttributeMap("PartVersion", "FR"));
         v = rl.getTargetVector(-1);
         Assert.AreEqual(1, v.Count);
         Assert.AreEqual(xmc, v[0]);
         xm.setPartUsage(EnumPartUsage.Implicit);
         v = rl.getTargetVector(-1);
         Assert.AreEqual(2, v.Count);
         // TODO should be xmb?
         Assert.AreEqual(xm, v[0]);
         Assert.AreEqual(xmc, v[1]);
      }


      [TestMethod]
      public virtual void testGetTargetVectorNullPart()
      {
         JDFDoc d = JDFTestCaseBase.creatXMDoc();
         JDFNode n = d.getJDFRoot();
         JDFResourceLink rl = n.getMatchingLink("ExposedMedia", EnumProcessUsage.Plate, 0);
         rl.appendPart();
         VElement v = rl.getTargetVector(0);
         Assert.AreEqual(1, v.Count, "The target vector is the node with two leaves");
         JDFResource linkRoot = rl.getLinkRoot();
         Assert.AreEqual(linkRoot, v[0], "The target vector is the node with two leaves");
         linkRoot.setPartUsage(EnumPartUsage.Implicit);
         v = rl.getTargetVector(0);
         Assert.AreEqual(1, v.Count, "The target vector is the node with two leaves");
         Assert.AreEqual(linkRoot, v[0], "The target vector is the node with two leaves");

         linkRoot.setPartUsage(EnumPartUsage.Explicit);

         JDFAttributeMap mPart = new JDFAttributeMap("SignatureName", "Sig1");
         mPart.put("SheetName", "S1");
         rl.setPartMap(mPart);
         rl.appendPart();

         v = rl.getTargetVector(0);
         Assert.AreEqual(2, v.Count, "The target vector is the node with two leaves");
         Assert.IsTrue(v.Contains(linkRoot));
         Assert.IsTrue(v.Contains(linkRoot.getPartition(mPart, null)));
         linkRoot.setPartUsage(EnumPartUsage.Implicit);
         v = rl.getTargetVector(0);
         Assert.IsTrue(v.Contains(linkRoot));
         Assert.IsTrue(v.Contains(linkRoot.getPartition(mPart, null)));
      }


      [TestMethod]
      public virtual void testGetTarget()
      {
         JDFDoc d = JDFTestCaseBase.creatXMDoc();
         JDFNode n = d.getJDFRoot();
         JDFExposedMedia xm = (JDFExposedMedia)n.getMatchingResource("ExposedMedia", JDFNode.EnumProcessUsage.AnyInput, null, 0);
         JDFAttributeMap mPart = new JDFAttributeMap("SignatureName", "Sig1");
         mPart.put("SignatureName", "S12234");
         mPart.put("SheetName", "S12");
         mPart.put("Side", "Front");

         JDFAttributeMap mPart2 = new JDFAttributeMap("SignatureName", "Sig1");
         mPart2.put("SignatureName", "Sig1");
         mPart2.put("SheetName", "S1");
         mPart2.put("Side", "Front");
         JDFExposedMedia xmPart = (JDFExposedMedia)xm.getPartition(mPart2, null);
         Assert.IsNotNull(xmPart);

         JDFResourceLink rl = n.getMatchingLink("ExposedMedia", EnumProcessUsage.Plate, 0);

         rl.setPartMap(mPart);
         Assert.IsNull(rl.getTarget());
         Assert.AreEqual(0, rl.getTargetVector(0).Count);

         xm.setPartUsage(EnumPartUsage.Explicit);
         Assert.IsNull(rl.getTarget());
         Assert.AreEqual(0, rl.getTargetVector(0).Count);

         xm.setPartUsage(EnumPartUsage.Implicit);
         Assert.AreEqual(xm, rl.getTarget());
         Assert.AreEqual(1, rl.getTargetVector(0).Count);

         xm.setPartUsage(EnumPartUsage.Sparse);
         Assert.AreEqual(null, rl.getTarget());
         Assert.AreEqual(0, rl.getTargetVector(0).Count);

         rl.setPartMap(mPart2);
         xm.removeAttribute("PartUsage");
         Assert.AreEqual(xmPart, rl.getTarget());
         Assert.AreEqual(1, rl.getTargetVector(0).Count);

         xm.setPartUsage(EnumPartUsage.Explicit);
         Assert.AreEqual(xmPart, rl.getTarget());
         Assert.AreEqual(1, rl.getTargetVector(0).Count);

         xm.setPartUsage(EnumPartUsage.Implicit);
         Assert.AreEqual(xmPart, rl.getTarget());
         Assert.AreEqual(1, rl.getTargetVector(0).Count);

         xm.setPartUsage(EnumPartUsage.Sparse);
         Assert.AreEqual(xmPart, rl.getTarget());
         Assert.AreEqual(1, rl.getTargetVector(0).Count);

         mPart2.put("PartVersion", "Fnarf");
         rl.setPartMap(mPart2);
         xm.removeAttribute("PartUsage");
         Assert.AreEqual(null, rl.getTarget());
         Assert.AreEqual(0, rl.getTargetVector(0).Count);

         xm.setPartUsage(EnumPartUsage.Explicit);
         Assert.AreEqual(null, rl.getTarget());
         Assert.AreEqual(0, rl.getTargetVector(0).Count);

         xm.setPartUsage(EnumPartUsage.Implicit);
         Assert.AreEqual(xmPart, rl.getTarget());
         Assert.AreEqual(1, rl.getTargetVector(0).Count);

         xm.setPartUsage(EnumPartUsage.Sparse);
         Assert.AreEqual(xmPart, rl.getTarget());
         Assert.AreEqual(1, rl.getTargetVector(0).Count);
      }


      [TestMethod]
      public virtual void testGetCombinedProcessTypes()
      {
         JDFDoc d = new JDFDoc(ElementName.JDF);
         JDFNode n = d.getJDFRoot();
         n.setType("Combined", true);
         n.setTypes(new VString("a b c d e f e f", " "));
         JDFResource r = n.addResource(ElementName.ADHESIVEBINDINGPARAMS, EnumUsage.Input);
         JDFResourceLink rl = n.getLink(r, null);
         VString nodeTypes = n.getTypes();
         nodeTypes.unify();
         CollectionAssert.AreEqual(nodeTypes, rl.getCombinedProcessTypes());
         rl.setCombinedProcessType("c");
         CollectionAssert.AreEqual(new VString("c", " "), rl.getCombinedProcessTypes());
         rl.removeAttribute(AttributeName.COMBINEDPROCESSTYPE);
         CollectionAssert.AreEqual(nodeTypes, rl.getCombinedProcessTypes());
         rl.setCombinedProcessIndex(new JDFIntegerList("0 2 4 6"));
         CollectionAssert.AreEqual(new VString("a c e", " "), rl.getCombinedProcessTypes());
         rl.setCombinedProcessIndex(new JDFIntegerList("0 2 4 6 8 99"));
         CollectionAssert.AreEqual(new VString("a c e", " "), rl.getCombinedProcessTypes());
      }


      [TestMethod]
      public virtual void testGetLinkRoot()
      {
         JDFDoc d = new JDFDoc(ElementName.JDF);
         JDFNode n = d.getJDFRoot();
         n.setType("ProcessGroup", true);
         JDFNode n2 = n.addJDFNode("ConventionalPrinting");
         JDFCustomerInfo ci = (JDFCustomerInfo)n.addResource(ElementName.CUSTOMERINFO, null, EnumUsage.Input, null, null, null, null);
         JDFResourceLink ciLink = n.getLink(ci, null);
         Assert.IsTrue(ci == ciLink.getLinkRoot(), "getLinkRoot in same node");
         Assert.IsTrue(ci == ciLink.getTarget(), "getLinkTarget in same node");
         Assert.IsTrue(ci == ciLink.getTarget(), "getTarget in same node");

         JDFResourceLink ciLink2 = n2.linkResource(ci, EnumUsage.Input, null);
         Assert.IsTrue(ci == ciLink2.getLinkRoot(), "getLinkRoot in child node");
         Assert.IsTrue(ci == ciLink2.getTarget(), "getLinkTarget in child node");
         Assert.IsTrue(ci == ciLink2.getTarget(), "getTarget in child node");

         JDFNodeInfo ni = (JDFNodeInfo)n2.addResource(ElementName.NODEINFO, null, null, null, null, null, null);
         JDFResourceLink niLink = n2.linkResource(ni, EnumUsage.Input, null);
         Assert.IsTrue(ni == niLink.getLinkRoot(), "getLinkRoot both in child node");
         Assert.IsTrue(ni == niLink.getTarget(), "getLinkTarget both in child node");
         Assert.IsTrue(ni == niLink.getTarget(), "getTarget both in child node");

         JDFResourceLink niLink2 = (JDFResourceLink)n.getCreateResourceLinkPool().appendElement("NodeInfoLink", null);
         niLink2.setrRef(ni.getID());
         Assert.IsTrue(niLink2.getLinkRoot() == null, "getLinkRoot illegal in child node");
         Assert.IsTrue(niLink2.getTarget() == null, "getLinkTarget illegal in child node");
         Assert.IsTrue(niLink2.getTarget() == null, "getTarget illegal in child node");

         JDFDoc d22 = new JDFDoc(ElementName.JDF);
         JDFNode n22 = d22.getJDFRoot();
         JDFResourceLinkPool rlp = n22.getCreateResourceLinkPool();
         bool bCaught = false;
         try
         {
            rlp.linkResource(ni, EnumUsage.Input, null);
         }
         catch (JDFException)
         {
            bCaught = true;
         }
         Assert.IsTrue(bCaught, "Resource from other document not linked");
         Assert.IsNull(rlp.getElement("NodeInfoLink"), "NI not linked");

      }


      [TestMethod]
      public virtual void testLinkRootDeadLoop()
      {
         JDFDoc jdfDoc = new JDFDoc("JDF");
         JDFNode node = jdfDoc.getJDFRoot();
         JDFResource r = node.addResource(ElementName.ADHESIVEBINDINGPARAMS, EnumUsage.Input);
         node.getResourcePool().insertBefore(ElementName.ADHESIVEBINDINGPARAMS + "Ref", r, null).setAttribute("rRef", "badLink");
         JDFResourceLink link = node.getLink(r, null);
         Assert.IsNotNull(link.getLinkRoot()); // Endlos-Schleife !!!!
      }


      [TestMethod]
      public virtual void testMatchesString()
      {
         JDFDoc jdfDoc = new JDFDoc("JDF");
         JDFNode node = jdfDoc.getJDFRoot();
         JDFResource r = node.addResource(ElementName.ADHESIVEBINDINGPARAMS, EnumUsage.Input);
         JDFResourceLink link = node.getLink(r, null);
         Assert.IsTrue(link.matchesString(ElementName.ADHESIVEBINDINGPARAMS));
         Assert.IsTrue(link.matchesString("Input"));
         Assert.IsFalse(link.matchesString("Output"));
         Assert.IsTrue(link.matchesString(ElementName.ADHESIVEBINDINGPARAMS + "Link"));
         Assert.IsFalse(link.matchesString(ElementName.ADHESIVEBINDINGPARAMS + ":Plate"));
         link.setProcessUsage(EnumProcessUsage.Plate);
         Assert.IsTrue(link.matchesString(ElementName.ADHESIVEBINDINGPARAMS));
         Assert.IsTrue(link.matchesString("Input"));
         Assert.IsFalse(link.matchesString("Output"));
         Assert.IsTrue(link.matchesString(ElementName.ADHESIVEBINDINGPARAMS + "Link"));
         Assert.IsTrue(link.matchesString(ElementName.ADHESIVEBINDINGPARAMS + ":Plate"));
      }


      [TestMethod]
      public virtual void testSetPartMap()
      {
         JDFDoc d = new JDFDoc(ElementName.JDF);
         JDFNode n = d.getJDFRoot();
         n.setVersion(JDFElement.EnumVersion.Version_1_3);
         n.setType("ConventionalPrinting", true);
         JDFExposedMedia xm = (JDFExposedMedia)n.addResource(ElementName.EXPOSEDMEDIA, null, EnumUsage.Input, null, null, null, null);
         xm.addPartition(JDFResource.EnumPartIDKey.SheetName, "Sheet1");
         xm.addPartition(JDFResource.EnumPartIDKey.SheetName, "Sheet2");
         JDFAttributeMap map1 = new JDFAttributeMap(JDFResource.EnumPartIDKey.SheetName.getName(), "Sheet1");
         JDFAttributeMap map2 = new JDFAttributeMap(JDFResource.EnumPartIDKey.SheetName.getName(), "Sheet2");
         JDFResourceLink rl = n.getLink(xm, null);

         VJDFAttributeMap v = new VJDFAttributeMap();
         v.Add(map1);
         v.Add(map2);
         rl.setPartMapVector(v);
      }


      [TestMethod]
      public virtual void testSetTarget()
      {
         JDFDoc d = new JDFDoc(ElementName.JDF);
         JDFNode n = d.getJDFRoot();
         n.setVersion(JDFElement.EnumVersion.Version_1_3);
         n.setType("ConventionalPrinting", true);
         JDFExposedMedia xm = (JDFExposedMedia)n.addResource(ElementName.EXPOSEDMEDIA, null, EnumUsage.Input, null, null, null, null);
         JDFExposedMedia xm1 = (JDFExposedMedia)xm.addPartition(JDFResource.EnumPartIDKey.SignatureName, "Sig1");
         VJDFAttributeMap vSig1 = new VJDFAttributeMap();
         vSig1.Add(xm1.getPartMap());
         // want a lower leaf partition
         xm1.addPartition(JDFResource.EnumPartIDKey.SheetName, "Sheet1");
         JDFMedia m = xm.appendMedia();
         JDFResourceLink rl = n.linkResource(xm, EnumUsage.Input, null);
         try
         {
            rl.setTarget(m);
            Assert.Fail("no link to subelem");
         }
         catch (JDFException)
         {
            // nop
         }
         rl.setTarget(xm1);
         Assert.AreEqual(vSig1, rl.getPartMapVector());
      }


      [TestMethod]
      public virtual void testGetUsage()
      {
         JDFDoc d = new JDFDoc(ElementName.JDF);
         JDFNode n = d.getJDFRoot();
         JDFResourceLinkPool rlp = n.appendResourceLinkPool();
         JDFResourceLink rl = (JDFResourceLink)rlp.appendElement("FooLink");
         Assert.IsNull(rl.getUsage());
      }

      
      [TestMethod]
      public virtual void testHasResourcePartMap()
      {
         JDFDoc d = new JDFDoc(ElementName.JDF);
         JDFNode n = d.getJDFRoot();
         JDFResource r = n.addResource(ElementName.SCREENINGINTENT, null, EnumUsage.Input, null, null, null, null);

         JDFResourceLink rl = n.getLink(r, null);
         // the root always exists
         Assert.IsTrue(rl.hasResourcePartMap(null, false));
         Assert.IsTrue(rl.hasResourcePartMap(null, true));

         JDFAttributeMap attributeMap = new JDFAttributeMap(EnumPartIDKey.SignatureName, "sig1");

         Assert.IsTrue(rl.hasResourcePartMap(attributeMap, false));
         Assert.IsFalse(rl.hasResourcePartMap(attributeMap, true));

         r.setPartUsage(EnumPartUsage.Implicit);
         Assert.IsTrue(rl.hasResourcePartMap(attributeMap, false));
         Assert.IsTrue(rl.hasResourcePartMap(attributeMap, true));

         r.setPartUsage(EnumPartUsage.Explicit);

         JDFResource rSig = r.addPartition(EnumPartIDKey.SignatureName, "sig1");

         // the root always exists
         Assert.IsTrue(rl.hasResourcePartMap(null, false));
         Assert.IsTrue(rl.hasResourcePartMap(null, true));

         // link and resource match
         rl.setPart(EnumPartIDKey.SignatureName.getName(), "sig1");
         Assert.IsTrue(rl.hasResourcePartMap(null, false));
         Assert.IsTrue(rl.hasResourcePartMap(null, true));

         // resource is partitioned deeper than link
         rSig.addPartition(EnumPartIDKey.SheetName, "sh1");
         Assert.IsTrue(rl.hasResourcePartMap(null, false));
         Assert.IsTrue(rl.hasResourcePartMap(attributeMap, false));

         attributeMap.put(EnumPartIDKey.SheetName, "sh1");
         Assert.IsTrue(rl.hasResourcePartMap(attributeMap, true));
         Assert.IsFalse(rl.hasResourcePartMap(attributeMap, false));

         attributeMap.put(EnumPartIDKey.SheetName, "sh2");
         Assert.IsFalse(rl.hasResourcePartMap(attributeMap, true));
         Assert.IsFalse(rl.hasResourcePartMap(attributeMap, false));

         attributeMap.put(EnumPartIDKey.Side, "Front");
         Assert.IsFalse(rl.hasResourcePartMap(attributeMap, true));
         Assert.IsFalse(rl.hasResourcePartMap(attributeMap, false));

         Assert.IsFalse(rl.hasResourcePartMap(new JDFAttributeMap(EnumPartIDKey.SignatureName, "sig2"), false));
         Assert.IsFalse(rl.hasResourcePartMap(new JDFAttributeMap(EnumPartIDKey.SignatureName, "sig2"), true));

         r.setPartUsage(EnumPartUsage.Implicit);
         Assert.IsTrue(rl.hasResourcePartMap(attributeMap, true));
         Assert.IsTrue(rl.hasResourcePartMap(attributeMap, false));

         Assert.IsFalse(rl.hasResourcePartMap(new JDFAttributeMap(EnumPartIDKey.SignatureName, "sig2"), false));
         Assert.IsFalse(rl.hasResourcePartMap(new JDFAttributeMap(EnumPartIDKey.SignatureName, "sig2"), true));
      }


      [TestMethod]
      public virtual void testIsExecutable()
      {
         JDFDoc d = new JDFDoc(ElementName.JDF);
         JDFNode n = d.getJDFRoot();
         JDFResource r = n.addResource(ElementName.SCREENINGINTENT, null, EnumUsage.Input, null, null, null, null);
         JDFResourceLink rl = n.getLink(r, null);

         r.setResStatus(EnumResStatus.Available, true);
         Assert.IsTrue(rl.isExecutable(null, true));
         r.setResStatus(EnumResStatus.Unavailable, true);
         Assert.IsFalse(rl.isExecutable(null, true));
         r.setResStatus(EnumResStatus.Draft, true);
         Assert.IsFalse(rl.isExecutable(null, true));
         rl.setDraftOK(true);
         Assert.IsTrue(rl.isExecutable(null, true));

         rl.setUsage(EnumUsage.Output);
         r.setResStatus(EnumResStatus.Available, true);
         Assert.IsTrue(rl.isExecutable(null, true));
         r.setResStatus(EnumResStatus.Unavailable, true);
         Assert.IsFalse(rl.isExecutable(null, true));
         r.setResStatus(EnumResStatus.Draft, true);
         Assert.IsTrue(rl.isExecutable(null, true));
         rl.setDraftOK(true);
         Assert.IsTrue(rl.isExecutable(null, true));

         JDFResource rSig = r.addPartition(EnumPartIDKey.SignatureName, "sig1");
         JDFResource rSheet = rSig.addPartition(EnumPartIDKey.SheetName, "sh1");
         rSheet.setResStatus(EnumResStatus.Available, false);
         r.setResStatus(EnumResStatus.Unavailable, true);
         rSheet.setResStatus(EnumResStatus.Available, true);
         rl.setUsage(EnumUsage.Input);
         JDFAttributeMap map = new JDFAttributeMap(EnumPartIDKey.SignatureName, "sig1");
         Assert.IsFalse(rl.isExecutable(map, false));
         Assert.IsTrue(rl.isExecutable(map, true));
         JDFResource rSheet2 = rSig.addPartition(EnumPartIDKey.SheetName, "sh2");
         rSheet2.setResStatus(EnumResStatus.Unavailable, false);
         Assert.IsFalse(rl.isExecutable(map, false));
         Assert.IsFalse(rl.isExecutable(map, true));
         map.put(EnumPartIDKey.SheetName, "sh1");
         Assert.IsTrue(rl.isExecutable(map, false));
         Assert.IsTrue(rl.isExecutable(map, true));
         rl.appendPart().setPartMap(map);
         map.put(EnumPartIDKey.SheetName, "sh2");
         rl.appendPart().setPartMap(map);
         map = new JDFAttributeMap(EnumPartIDKey.SignatureName, "sig1");
         rSheet2.setResStatus(EnumResStatus.Available, false);

         Assert.IsTrue(rl.isExecutable(map, false));
         Assert.IsTrue(rl.isExecutable(map, true));

      }


      [TestMethod]
      public virtual void testValidName()
      {
         JDFDoc d = new JDFDoc(ElementName.JDF);
         JDFNode n = d.getJDFRoot();
         JDFResourceLinkPool rlp = n.appendResourceLinkPool();
         JDFResourceLink rl = (JDFResourceLink)rlp.appendElement("FooLink");
         JDFResource rBar = n.addResource("Bar", EnumResourceClass.Parameter, EnumUsage.Input, null, null, null, null);
         rl.setrRef(rBar.getID());
         Assert.IsFalse((rl.isValid(null)));
         rl = n.getLink(rBar, null);
         Assert.IsNotNull(rl);
         Assert.IsTrue((rl.isValid(null)));
      }


      [TestMethod]
      public virtual void testValidPosition()
      {
         JDFDoc d = new JDFDoc(ElementName.JDF);
         JDFNode n = d.getJDFRoot();
         n.setType(EnumType.ProcessGroup);
         JDFResource rBar = n.addResource("Bar", EnumResourceClass.Parameter, EnumUsage.Input, null, null, null, null);
         JDFResourceLink rl = n.getLink(rBar, null);
         Assert.IsNotNull(rl);
         Assert.IsTrue((rl.isValid(null)));
         JDFNode n2 = n.addJDFNode("Whatever");
         n2.moveElement(n.getResourcePool(), null);
         Assert.IsFalse((rl.isValid(null)));
         Assert.IsFalse((rl.validResourcePosition()));
      }

      
      [TestMethod]
      public virtual void testValidAttributesAmountPool()
      {
         JDFDoc d = new JDFDoc(ElementName.JDF);
         JDFNode n = d.getJDFRoot();
         n.setType(EnumType.Strapping);
         JDFResource rBar = n.addResource(ElementName.COMPONENT, EnumUsage.Input);
         JDFResourceLink rl = n.getLink(rBar, null);
         rl.setActualAmount(42, null);
         Assert.IsFalse(rl.getInvalidAttributes(EnumValidationLevel.Incomplete, false, 99).Contains(AttributeName.ACTUALAMOUNT));
         // rl.appendAmountPool();
         // Assert.IsTrue(rl.getInvalidAttributes(EnumValidationLevel.Incomplete,
         // false, 99).contains(AttributeName.ACTUALAMOUNT));
      }


      [TestMethod]
      public virtual void testValidCombinedProcessIndex()
      {
         JDFDoc d = new JDFDoc(ElementName.JDF);
         JDFNode n = d.getJDFRoot();
         n.setType(EnumType.Strapping);
         JDFResource rBar = n.addResource("Bar", EnumResourceClass.Parameter, EnumUsage.Input, null, null, null, null);
         JDFResourceLink rl = n.getLink(rBar, null);
         Assert.IsTrue(rl.validCombinedProcessIndex());
         rl.setCombinedProcessIndex(null);
         Assert.IsTrue(rl.validCombinedProcessIndex());
         JDFIntegerList il = new JDFIntegerList();
         rl.setCombinedProcessIndex(il);
         Assert.IsTrue(rl.validCombinedProcessIndex());
         il.Add(0);
         rl.setCombinedProcessIndex(il);
         Assert.IsFalse(rl.validCombinedProcessIndex());
         n.setCombined(new VString("Approval ImageSetting", " "));
         Assert.IsTrue(rl.validCombinedProcessIndex());
         il.Add(1);
         rl.setCombinedProcessIndex(il);
         Assert.IsTrue(rl.validCombinedProcessIndex());
         il.Add(1);
         rl.setCombinedProcessIndex(il);
         Assert.IsTrue(rl.validCombinedProcessIndex());
         Assert.IsTrue(n.isValid(EnumValidationLevel.Incomplete));
         il.Add(2);
         rl.setCombinedProcessIndex(il);
         Assert.IsFalse(rl.validCombinedProcessIndex());
         Assert.IsFalse(n.isValid(EnumValidationLevel.Incomplete));
         Assert.IsTrue(rl.getInvalidAttributes(EnumValidationLevel.Incomplete, true, -1).Contains(AttributeName.COMBINEDPROCESSINDEX));

      } 


      [TestMethod]
      public virtual void testSetCombinedProcessIndex()
      {
         JDFDoc d = new JDFDoc(ElementName.JDF);
         JDFNode n = d.getJDFRoot();
         n.setType(EnumType.Strapping);
         JDFResource rBar = n.addResource("Bar", EnumResourceClass.Parameter, EnumUsage.Input, null, null, null, null);
         JDFResourceLink rl = n.getLink(rBar, null);
         rl.setCombinedProcessIndex(null);
         Assert.IsFalse(rl.hasAttribute(AttributeName.COMBINEDPROCESSINDEX));
         JDFIntegerList il = new JDFIntegerList();
         rl.setCombinedProcessIndex(il);
         Assert.IsFalse(rl.hasAttribute(AttributeName.COMBINEDPROCESSINDEX));
         il.Add(0);
         rl.setCombinedProcessIndex(il);
         Assert.AreEqual(il, rl.getCombinedProcessIndex());
      }
   }
}