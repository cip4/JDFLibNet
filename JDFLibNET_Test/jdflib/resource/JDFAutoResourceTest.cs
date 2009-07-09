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
 * JDFAutoResourceTest.java
 * @author Dietrich Mucha
 * Copyright (C) 2004 Heidelberger Druckmaschinen AG. All Rights Reserved.
 */

namespace org.cip4.jdflib.resource
{
   using Microsoft.VisualStudio.TestTools.UnitTesting;


   using EnumSheetType = org.cip4.jdflib.auto.JDFAutoInsertSheet.EnumSheetType;
   using EnumSheetUsage = org.cip4.jdflib.auto.JDFAutoInsertSheet.EnumSheetUsage;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using VString = org.cip4.jdflib.core.VString;
   using EnumNamedColor = org.cip4.jdflib.core.JDFElement.EnumNamedColor;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using EnumValidationLevel = org.cip4.jdflib.core.KElement.EnumValidationLevel;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using EnumProcessUsage = org.cip4.jdflib.node.JDFNode.EnumProcessUsage;
   using EnumResStatus = org.cip4.jdflib.resource.JDFResource.EnumResStatus;
   using EnumResourceClass = org.cip4.jdflib.resource.JDFResource.EnumResourceClass;
   using JDFModule = org.cip4.jdflib.resource.devicecapability.JDFModule;
   using JDFMediaIntent = org.cip4.jdflib.resource.intent.JDFMediaIntent;
   using JDFColor = org.cip4.jdflib.resource.process.JDFColor;
   using JDFColorPool = org.cip4.jdflib.resource.process.JDFColorPool;
   using JDFFileSpec = org.cip4.jdflib.resource.process.JDFFileSpec;
   using JDFInsertSheet = org.cip4.jdflib.resource.process.JDFInsertSheet;
   using JDFRunList = org.cip4.jdflib.resource.process.JDFRunList;
   using JDFScore = org.cip4.jdflib.resource.process.postpress.JDFScore;
   using EnumScoreSide = org.cip4.jdflib.resource.process.postpress.JDFScore.EnumScoreSide;
   using JDFStringSpan = org.cip4.jdflib.span.JDFStringSpan;

   [TestClass]
   public class JDFAutoResourceTest
   {
      [TestMethod]
      public virtual void testRunList()
      {
         JDFDoc d = new JDFDoc(ElementName.JDF);
         JDFNode r = d.getJDFRoot();
         JDFRunList rl = (JDFRunList)r.addResource("RunList", null, EnumUsage.Input, null, null, null, null);
         JDFInsertSheet is1 = rl.appendInsertSheet();
         is1.setSheetType(EnumSheetType.SeparatorSheet);
         is1.setSheetUsage(EnumSheetUsage.Slip);
         JDFInsertSheet is2 = rl.appendInsertSheet();
         is2.setSheetType(EnumSheetType.SeparatorSheet);
         is2.setSheetUsage(EnumSheetUsage.Slip);
         Assert.AreNotEqual(is2, is1, "two insert sheets");

         rl.appendLayoutElement(); // 1
         Assert.IsTrue(rl.isValid(EnumValidationLevel.Complete), "runlist valid");
         bool b1 = false;
         try
         {
            rl.appendLayoutElement();
         }
         catch (JDFException)
         {
            b1 = true;
         }
         Assert.IsTrue(b1, "only one layoutelement possible");
      }


      [TestMethod]
      public virtual void testEnumerations()
      {
         JDFDoc d = new JDFDoc(ElementName.JDF);
         JDFNode r = d.getJDFRoot();
         JDFColorPool cp = (JDFColorPool)r.addResource("ColorPool", null, EnumUsage.Input, null, null, null, null);
         JDFColor col = cp.appendColor();
         col.setColorName(EnumNamedColor.Red);
         Assert.IsTrue(col.getColorName() == EnumNamedColor.Red, "named color get");
         Assert.IsTrue(col.getAttribute(AttributeName.COLORNAME) == "Red", "named color get raw");
      }


      [TestMethod]
      public virtual void testBinderySignature()
      {
         JDFDoc d = new JDFDoc(ElementName.JDF);
         JDFNode n = d.getJDFRoot();
         JDFResource bs = n.addResource(ElementName.BINDERYSIGNATURE, null, null, null, null, null, null);
         Assert.AreEqual(EnumResourceClass.Parameter, bs.getResourceClass(), "bs class");
         bs = n.addResource(ElementName.BINDERYSIGNATURE, JDFResource.EnumResourceClass.Parameter, null, null, n, null, null);
         Assert.AreEqual(EnumResourceClass.Parameter, bs.getResourceClass(), "bs class old style");
         Assert.IsTrue(bs.validClass());
      }


      [TestMethod]
      public virtual void testMediaIntent()
      {
         JDFDoc d = new JDFDoc(ElementName.JDF);
         JDFNode n = d.getJDFRoot();
         n.setType("Product", true);

         JDFMediaIntent mi = (JDFMediaIntent)n.appendMatchingResource(ElementName.MEDIAINTENT, EnumProcessUsage.AnyInput, null);
         JDFStringSpan sb = mi.appendStockBrand();
         sb.setActual("abc foo");
         sb.setPreferred("abc foo");
         Assert.IsTrue(sb.isValid(EnumValidationLevel.Complete), "valid StockBrand");
         Assert.AreEqual(EnumResourceClass.Intent, mi.getValidClass());
         Assert.IsTrue(mi.validClass());
      }


      [TestMethod]
      public virtual void testDevice()
      {
         JDFDoc d = new JDFDoc(ElementName.JDF);
         JDFNode n = d.getJDFRoot();
         n.setType("Stitching", true);
         JDFDevice dev = (JDFDevice)n.appendMatchingResource(ElementName.DEVICE, EnumProcessUsage.AnyInput, null);
         dev.setResStatus(EnumResStatus.Available, true);
         dev.setKnownLocalizations(new VString("De", null));
         dev.setSerialNumber("12345");
         dev.setSecureJMFURL("http://fififi");
         JDFModule m = dev.appendModule();
         // m.setModuleIndex(0);
         m.setModelDescription("1234");
         JDFIconList il = dev.appendIconList();
         Assert.IsFalse(il.isValid(EnumValidationLevel.Complete), "empty iconlist");
         Assert.IsTrue(il.isValid(EnumValidationLevel.Incomplete), "empty iconlist");
         JDFIcon ic = il.appendIcon();
         ic.setSize(new JDFXYPair(200, 200));
         ic.setBitDepth(8);
         JDFFileSpec fs = ic.appendFileSpec();
         fs.setURL("file:///this.ico");

         Assert.IsTrue(ic.isValid(EnumValidationLevel.Complete), "icon valid");
         Assert.IsTrue(il.isValid(EnumValidationLevel.Complete), "iconlist valid");
         Assert.IsTrue(m.isValid(EnumValidationLevel.Complete), "mod valid");
         Assert.IsTrue(dev.isValid(EnumValidationLevel.Complete), "dev valid");
         Assert.IsTrue(dev.validClass());
      }


      // test coverapplication and score
      [TestMethod]
      public virtual void testScore()
      {
         JDFDoc d = new JDFDoc(ElementName.JDF);
         JDFNode n = d.getJDFRoot();
         n.setType("CoverApplication", true);
         JDFCoverApplicationParams cap = (JDFCoverApplicationParams)n.appendMatchingResource(ElementName.COVERAPPLICATIONPARAMS, EnumProcessUsage.AnyInput, null);
         JDFScore score = cap.appendScore();
         score.setSide(EnumScoreSide.FromInside);
         score.setOffset(1234.5);
         Assert.IsTrue(score.isValid(EnumValidationLevel.Complete), "score 1");
         score = cap.appendScore();
         score.setSide(EnumScoreSide.FromOutside);
         Assert.IsTrue(score.isValid(EnumValidationLevel.Complete), "score 2");
         Assert.IsTrue(cap.isValid(EnumValidationLevel.Complete), "cap");
         // we know that we are incomplete since we have missing resources
         Assert.IsTrue(n.isValid(EnumValidationLevel.Incomplete), "n");
      }
   }
}
