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



namespace org.cip4.jdflib.resource
{
   using Microsoft.VisualStudio.TestTools.UnitTesting;


   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using EnumMediaType = org.cip4.jdflib.auto.JDFAutoMedia.EnumMediaType;
   using EnumSide = org.cip4.jdflib.auto.JDFAutoPart.EnumSide;
   using EnumMarkUsage = org.cip4.jdflib.auto.JDFAutoRegisterMark.EnumMarkUsage;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFParser = org.cip4.jdflib.core.JDFParser;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using EnumVersion = org.cip4.jdflib.core.JDFElement.EnumVersion;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using EnumValidationLevel = org.cip4.jdflib.core.KElement.EnumValidationLevel;
   using JDFMatrix = org.cip4.jdflib.datatypes.JDFMatrix;
   using JDFRectangle = org.cip4.jdflib.datatypes.JDFRectangle;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using EnumProcessUsage = org.cip4.jdflib.node.JDFNode.EnumProcessUsage;
   using EnumType = org.cip4.jdflib.node.JDFNode.EnumType;
   using EnumPartIDKey = org.cip4.jdflib.resource.JDFResource.EnumPartIDKey;
   using JDFColorControlStrip = org.cip4.jdflib.resource.process.JDFColorControlStrip;
   using JDFContentObject = org.cip4.jdflib.resource.process.JDFContentObject;
   using JDFLayout = org.cip4.jdflib.resource.process.JDFLayout;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;
   using JDFRegisterMark = org.cip4.jdflib.resource.process.JDFRegisterMark;
   using JDFRunList = org.cip4.jdflib.resource.process.JDFRunList;
   using JDFSurface = org.cip4.jdflib.resource.process.JDFSurface;
   using JDFSheet = org.cip4.jdflib.resource.process.postpress.JDFSheet;

   ///
   /// <summary> * all kinds of fun tests around JDF 1.2 vs JDF 1.3 Layouts also some tests for
   /// * automated layout
   /// *  </summary>
   /// 
   [TestClass]
   public class JDFLayoutTest : JDFTestCaseBase
   {

      private JDFDoc doc = null;
      private JDFNode n = null;
      private JDFRunList rl = null;

      [TestInitialize]
      public override void setUp()
      {
         base.setUp();
         JDFElement.setLongID(false);
         reset();
      }


      private void reset()
      {
         doc = new JDFDoc("JDF");
         n = doc.getJDFRoot();
         n.setType(EnumType.Imposition);
         rl = (JDFRunList)n.appendMatchingResource(ElementName.RUNLIST, EnumProcessUsage.AnyInput, null);
      }


      [TestMethod]
      public virtual void testIsNewLayout()
      {
         Assert.AreEqual(EnumVersion.Version_1_3, n.getVersion(false), "version ok");
         JDFLayout lo = (JDFLayout)n.appendMatchingResource(ElementName.LAYOUT, EnumProcessUsage.AnyInput, null);
         Assert.IsTrue(JDFLayout.isNewLayout(lo), "lo 1.3");
         n.setVersion(EnumVersion.Version_1_2);
         Assert.IsFalse( JDFLayout.isNewLayout(lo), "lo 1.3");
         lo.addPartition(EnumPartIDKey.SheetName, "Sheet1");
         Assert.IsTrue(JDFLayout.isNewLayout(lo), "lo 1.3");
         Assert.IsFalse(JDFLayout.isNewLayout(rl), "l no layout");
      }


      [TestMethod]
      public virtual void testAutoRegister()
      {
         Assert.AreEqual(EnumVersion.Version_1_3, n.getVersion(false), "version ok");
         JDFLayout lo = (JDFLayout)n.appendMatchingResource(ElementName.LAYOUT, EnumProcessUsage.AnyInput, null);
         JDFColorControlStrip autoReg = lo.appendMarkObject().appendColorControlStrip();
         autoReg.setStripType("AutoRegister");
         autoReg.appendElement("SeparationSpec").setAttribute("Name", "Black");
         autoReg.appendElement("SeparationSpec").setAttribute("Name", "Cyan");
         autoReg.appendElement("SeparationSpec").setAttribute("Name", "Yellow");
         autoReg.appendElement("SeparationSpec").setAttribute("Name", "Magenta");
         autoReg.appendElement("SeparationSpec").setAttribute("Name", "Spot1");
         autoReg.appendElement("SeparationSpec").setAttribute("Name", "Spot2");
         JDFColorControlStrip fms = lo.getMarkObject(0).appendColorControlStrip();
         fms.setStripType("FMS");
         fms.appendElement("SeparationSpec").setAttribute("Name", "Black");
         fms.appendElement("SeparationSpec").setAttribute("Name", "Yellow");
         fms.appendElement("SeparationSpec").setAttribute("Name", "Magenta");
         fms.appendElement("SeparationSpec").setAttribute("Name", "Cyan");

         fms = lo.getMarkObject(0).appendColorControlStrip();
         fms.setStripType("FMS");
         fms.appendElement("SeparationSpec").setAttribute("Name", "Spot1");
         fms.appendElement("SeparationSpec").setAttribute("Name", "Spot2");
         doc.write2File(sm_dirTestDataTemp + "autoregister.jdf", 2, false);
      }


      [TestMethod]
      public virtual void testMedia()
      {
         JDFLayout lo = (JDFLayout)n.appendMatchingResource(ElementName.LAYOUT, EnumProcessUsage.AnyInput, null);
         lo.appendMedia();
         JDFMedia m2 = lo.appendMedia();
         Assert.IsNotNull(m2, "2. Media ok");
         Assert.AreEqual(m2, lo.getMedia(1));
         Assert.AreEqual(m2, lo.getCreateMedia(1));
      }


      [TestMethod]
      public virtual void testDynamicMarks()
      {
         JDFElement.setLongID(false);
         JDFLayout lo = (JDFLayout)n.appendMatchingResource(ElementName.LAYOUT, EnumProcessUsage.AnyInput, null);
         lo.setXMLComment("Layout that illustrates dynamic mark placement - all margins are 25 points (gutter=2*25)");
         lo.setSurfaceContentsBox(new JDFRectangle(0, 0, 500, 350));
         JDFSheet s = lo.appendSheet();
         JDFSurface su = s.appendFrontSurface();

         JDFContentObject co0 = su.appendContentObject();
         co0.setOrd(0);
         JDFMatrix m1 = (JDFMatrix)JDFMatrix.unitMatrix.Clone();
         m1.shift(25, 25);
         co0.setCTM(JDFMatrix.unitMatrix);
         co0.setTrimSize(new JDFXYPair(200, 300));
         string[] id = new string[2];
         id[0] = co0.appendAnchor(null);
         JDFContentObject co1 = su.appendContentObject();
         m1 = (JDFMatrix)JDFMatrix.unitMatrix.Clone();
         m1.shift(275, 25);
         co1.setCTM(m1);
         co1.setTrimSize(200, 300);
         id[1] = co1.appendAnchor(null);

         {
            JDFMarkObject mark0 = su.appendMarkObject();
            mark0.setXMLComment("Register Mark on the top right of the sheet - assumed size is 20*30, assumed sheet size is 500*350");
            mark0.setTrimSize(20, 30);
            mark0.setCTM(new JDFMatrix(1, 0, 0, 1, 500 - 20, 350 - 30));
            mark0.appendDeviceMark().setAttribute("Anchor", "TopRight");
            mark0.appendRegisterMark().setXMLComment("mark metadata goes here");
            appendRefAnchor(mark0, "TopRight", "Parent", null);
         }

         {
            JDFMarkObject mark0 = su.appendMarkObject();
            mark0.setXMLComment("Vertical Slug Line beginning at the top of the bottom margin of of the sheet between the 2 pages" + "\nnote that no TrimSize need be specified and therefore TrimCTM / CTM place the point defined by @Anchor" + "\nnote also that the anchor points to centerleft which is in the unrotated (horizontal) cs of the slug line");
            JDFMatrix m0 = new JDFMatrix(1, 0, 0, 1, 0, 0);
            m0.rotate(90);
            m0.shift(250, 25);
            mark0.setCTM(m0);
            JDFDeviceMark dm = mark0.appendDeviceMark();
            dm.setAttribute("Anchor", "CenterLeft");
            dm.setFontSize(10);
            dm.setFont("GhostCrypt");
            JDFJobField jf = mark0.appendJobField();
            jf.setXMLComment("Result: Sheet Printed by Dracula at the moonphase FullMoon");
            jf.setAttribute("JobFormat", "Sheet Printed by %s at the moonphase %s");
            jf.setAttribute("JobTemplate", "Operator,MoonPhase");
            appendRefAnchor(mark0, "BottomCenter", "Parent", null);
         }

         for (int i = 0; i < 2; i++)
         {
            JDFMarkObject mark0 = su.appendMarkObject();
            mark0.setXMLComment("Horizonzal Slug Line, centered 5 points over the top of page " + i + "\nnote that page is not yet a predefined token\n");
            JDFMatrix m0 = new JDFMatrix(1, 0, 0, 1, 0, 0);
            m0.rotate(90);
            m0.shift(25 + 100, 300 + 25 + 5);
            if (i == 1)
               m0.shift(250, 0);
            mark0.setCTM(m0);
            JDFDeviceMark dm = mark0.appendDeviceMark();
            dm.setAttribute("Anchor", "BottomCenter");
            dm.setFontSize(8);
            JDFJobField jf = mark0.appendJobField();
            jf.setXMLComment("Result: Page # " + i + " for Customer, Polanski - Job: J11");
            jf.setAttribute("JobFormat", "Page # %i for Customer, %s - Job: %s");
            jf.setAttribute("JobTemplate", "Page,JobRecipientName,JobID");
            appendRefAnchor(mark0, "BottomCenter", "Sibling", id[i]);
         }
         doc.write2File(sm_dirTestDataTemp + "LayoutDynamicMarks.jdf", 2, false);
      }


      public static KElement appendRefAnchor(JDFMarkObject mark0, string anchor, string anchorType, string rRef)
      {
         KElement refAnchor = mark0.getCreateElement("RefAnchor", null, 0);
         refAnchor.setAttribute("Anchor", anchor);
         refAnchor.setAttribute("AnchorType", anchorType);
         refAnchor.setAttribute("rRef", rRef);
         return refAnchor;
      }

      ///   
      ///	 <summary> * build a 1.2 layout using appendsignature etc
      ///	 *  </summary>
      ///	 
      [TestMethod]
      public virtual void testBuildOldLayout()
      {
         reset();

         n.setVersion(EnumVersion.Version_1_2);
         JDFLayout lo = (JDFLayout)n.appendMatchingResource(ElementName.LAYOUT, EnumProcessUsage.AnyInput, null);
         Assert.IsFalse(JDFLayout.isNewLayout(lo), "lo 1.3");
         JDFSignature si = lo.appendSignature();
         si.setName("Sig1");
         Assert.AreEqual(ElementName.SIGNATURE, si.LocalName, "signature name");
         Assert.IsFalse(si.hasAttribute(AttributeName.CLASS));
         si = lo.appendSignature();
         si.setName("Sig2");
         Assert.AreEqual(2, lo.numSignatures(), "num sigs");
         Assert.AreEqual(ElementName.SIGNATURE, si.LocalName, "signature name");

         JDFSheet sh = si.appendSheet();
         sh.setName("Sheet2_1");
         sh.makeRootResource(null, null, true); // see what happens with
         // refelements
         sh = si.appendSheet();
         sh.setName("Sheet2_2");
         Assert.AreEqual(2, si.numSheets(), "num sheets");
         Assert.AreEqual(ElementName.SHEET, sh.LocalName, "sheet name");
         sh = si.getCreateSheet(4);
         Assert.AreEqual(3, si.numSheets(), "num sheets");
         Assert.AreEqual(ElementName.SHEET, sh.LocalName, "sheet name");
         sh = si.getSheet(2);
         Assert.AreEqual(3, si.numSheets(), "num sheets");
         Assert.AreEqual(ElementName.SHEET, sh.LocalName, "sheet name");

         JDFSurface su = sh.appendFrontSurface();
         Assert.AreEqual(1, sh.numSurfaces(), "num surfaces");
         Assert.AreEqual(ElementName.SURFACE, su.LocalName, "sheet name");
         Assert.IsTrue(sh.hasFrontSurface(), "hasfrontSurface");
         su.appendContentObject();
         su.appendMarkObject();
         su.appendContentObject();
         su.appendContentObject();

         su = sh.appendBackSurface();
         su.makeRootResource(null, null, true);
         su.appendContentObject();
         su.appendMarkObject();
         su.appendContentObject();
         su.appendContentObject();
         su.appendMarkObject();
         Assert.AreEqual(2, sh.numSurfaces(), "num surfaces");
         Assert.AreEqual(ElementName.SURFACE, su.LocalName, "sheet name");
         Assert.IsTrue(sh.hasBackSurface(), "hasBackSurface");

         try
         {
            sh.appendBackSurface();
            Assert.Fail("append second surface");
         }
         catch (JDFException)
         { // nop 
         }

         si = lo.getCreateSignature(4);
         Assert.AreEqual(3, lo.numSignatures(), "num sigs");
         Assert.AreEqual(ElementName.SIGNATURE, si.LocalName, "signature name");
         si = lo.getSignature(2);
         Assert.AreEqual(3, lo.numSignatures(), "num sigs");
         Assert.AreEqual(ElementName.SIGNATURE, si.LocalName, "signature name");
         si = lo.getSignature(5);
         Assert.IsNull(si, "si null");
         Assert.AreEqual(lo.numSignatures(), lo.getSignatureVector().Count);

      }

      ///   
      ///	 <summary> * build a 1.3 layout using appendsignature etc
      ///	 *  </summary>
      ///	 
      [TestMethod]
      public virtual void testBuildNewLayout()
      {
         reset();

         JDFLayout lo = (JDFLayout)n.appendMatchingResource(ElementName.LAYOUT, EnumProcessUsage.AnyInput, null);
         Assert.IsTrue(JDFLayout.isNewLayout(lo), "lo 1.3");
         JDFSignature si = lo.appendSignature();
         Assert.AreEqual(ElementName.LAYOUT, si.LocalName, "signature name");
         si = lo.appendSignature();
         Assert.AreEqual(2, lo.numSignatures(), "num sigs");
         Assert.AreEqual(ElementName.LAYOUT, si.LocalName, "signature name");

         JDFSheet sh = si.appendSheet();
         sh = si.appendSheet();
         Assert.AreEqual(2, si.numSheets(), "num sheets");
         Assert.AreEqual(ElementName.LAYOUT, sh.LocalName, "sheet name");
         sh = si.getCreateSheet(4);
         Assert.AreEqual(3, si.numSheets(), "num sheets");
         Assert.AreEqual(ElementName.LAYOUT, sh.LocalName, "sheet name");
         sh = si.getSheet(2);
         Assert.AreEqual(3, si.numSheets(), "num sheets");
         Assert.AreEqual(ElementName.LAYOUT, sh.LocalName, "sheet name");

         JDFSurface su = sh.appendFrontSurface();
         Assert.AreEqual(1, sh.numSurfaces(), "num surfaces");
         Assert.AreEqual(ElementName.LAYOUT, su.LocalName, "sheet name");
         Assert.IsTrue(sh.hasFrontSurface(), "hasfrontSurface");

         su = sh.appendBackSurface();
         Assert.AreEqual(2, sh.numSurfaces(), "num surfaces");
         Assert.AreEqual(ElementName.LAYOUT, su.LocalName, "sheet name");

         try
         {
            sh.appendBackSurface();
            Assert.Fail("no two back surfaces");
         }
         catch (JDFException)
         { // nop 
         }

         si = lo.getCreateSignature(4);
         Assert.AreEqual(3, lo.numSignatures(), "num sigs");
         Assert.AreEqual(ElementName.LAYOUT, si.LocalName, "signature name");
         si = lo.getSignature(2);
         Assert.AreEqual(3, lo.numSignatures(), "num sigs");
         Assert.AreEqual(ElementName.LAYOUT, si.LocalName, "signature name");
         si = lo.getSignature(5);
         Assert.IsNull(si, "si null");
         Assert.IsTrue(lo.isValid(EnumValidationLevel.Complete), "layout valid");
         Assert.AreEqual(lo.numSignatures(), lo.getSignatureVector().Count);
      }


      [TestMethod]
      public virtual void testFixToNewLayout()
      {
         testBuildOldLayout();
         n.fixVersion(EnumVersion.Version_1_3);
         JDFLayout lo = (JDFLayout)n.getMatchingResource(ElementName.LAYOUT, EnumProcessUsage.AnyInput, null, 0);
         Assert.IsTrue(JDFLayout.isNewLayout(lo));
         JDFSignature si = lo.getSignature(0);
         Assert.AreEqual("Sig1", si.getSignatureName());
         Assert.IsFalse(si.hasAttribute(AttributeName.CLASS));
      }


      [TestMethod]
      public virtual void testFixFromNewLayout()
      {
         testBuildNewLayout();
         n.fixVersion(EnumVersion.Version_1_2);
         JDFLayout lo = (JDFLayout)n.getMatchingResource(ElementName.LAYOUT, EnumProcessUsage.AnyInput, null, 0);
         Assert.IsFalse(JDFLayout.isNewLayout(lo));
         JDFSignature si = lo.getSignature(0);
         Assert.AreEqual(ElementName.SIGNATURE, si.LocalName);
      }


      [TestMethod]
      public virtual void testFixFromFlatNewLayout()
      {
         n.setVersion(EnumVersion.Version_1_3);
         JDFLayout loNew = (JDFLayout)n.appendMatchingResource(ElementName.LAYOUT, EnumProcessUsage.AnyInput, null);
         JDFContentObject co1 = loNew.appendContentObject();

         n.fixVersion(EnumVersion.Version_1_2);
         JDFLayout lo = (JDFLayout)n.getMatchingResource(ElementName.LAYOUT, EnumProcessUsage.AnyInput, null, 0);
         Assert.IsFalse(JDFLayout.isNewLayout(lo));
         JDFSignature si = lo.getSignature(0);
         Assert.AreEqual(ElementName.SIGNATURE, si.LocalName);
         JDFSheet sh = si.getSheet(0);
         JDFSurface su = sh.getSurface(EnumSide.Front);
         Assert.AreEqual(co1, su.getContentObject(0));
      }


      [TestMethod]
      public virtual void testFixFromSheetNewLayout()
      {
         n.setVersion(EnumVersion.Version_1_3);
         JDFLayout loNew = (JDFLayout)n.appendMatchingResource(ElementName.LAYOUT, EnumProcessUsage.AnyInput, null);
         loNew = (JDFLayout)loNew.addPartition(EnumPartIDKey.SheetName, "s1");
         JDFContentObject co1 = loNew.appendContentObject();

         n.fixVersion(EnumVersion.Version_1_2);
         JDFLayout lo = (JDFLayout)n.getMatchingResource(ElementName.LAYOUT, EnumProcessUsage.AnyInput, null, 0);
         Assert.IsFalse(JDFLayout.isNewLayout(lo));
         JDFSignature si = lo.getSignature(0);
         Assert.AreEqual(ElementName.SIGNATURE, si.LocalName);
         JDFSheet sh = si.getSheet(0);
         JDFSurface su = sh.getSurface(EnumSide.Front);
         Assert.AreEqual(co1, su.getContentObject(0));
      }


      [TestMethod]
      public virtual void testFixFromSurfaceNewLayout()
      {
         n.setVersion(EnumVersion.Version_1_3);
         JDFLayout loNew = (JDFLayout)n.appendMatchingResource(ElementName.LAYOUT, EnumProcessUsage.AnyInput, null);
         loNew = (JDFLayout)loNew.addPartition(EnumPartIDKey.Side, "Back");
         JDFContentObject co1 = loNew.appendContentObject();

         n.fixVersion(EnumVersion.Version_1_2);
         JDFLayout lo = (JDFLayout)n.getMatchingResource(ElementName.LAYOUT, EnumProcessUsage.AnyInput, null, 0);
         Assert.IsFalse(JDFLayout.isNewLayout(lo));
         JDFSignature si = lo.getSignature(0);
         Assert.AreEqual(ElementName.SIGNATURE, si.LocalName);
         JDFSheet sh = si.getSheet(0);
         JDFSurface su = sh.getSurface(EnumSide.Front);
         Assert.IsNull(su);
         su = sh.getSurface(EnumSide.Back);
         Assert.AreEqual(co1, su.getContentObject(0));
      }



      ///   
      ///	 <summary> * test getPlacedObjectVector </summary>
      ///	 
      [TestMethod]
      public virtual void testGetPlacedObjectVector()
      {
         testBuildOldLayout();
         JDFLayout lo = (JDFLayout)n.getMatchingResource(ElementName.LAYOUT, EnumProcessUsage.AnyInput, null, 0);
         JDFSurface su = lo.getSignature(1).getSheet(2).getSurface(EnumSide.Front);
         VElement v = su.getPlacedObjectVector();
         Assert.AreEqual(v.Count, 4);
         Assert.IsTrue(v[0] is JDFContentObject);
         Assert.IsTrue(v[1] is JDFMarkObject);
         Assert.IsTrue(v[2] is JDFContentObject);
         Assert.IsTrue(v[3] is JDFContentObject);
      }

      ///   
      ///	 <summary> * tests the typed media getter </summary>
      ///	 
      [TestMethod]
      public virtual void testGetMedia()
      {
         JDFLayout lo = (JDFLayout)new JDFDoc("JDF").getRoot().appendElement(ElementName.RESOURCEPOOL).appendElement(ElementName.LAYOUT);
         JDFLayout s1 = (JDFLayout)lo.addPartition(EnumPartIDKey.SheetName, "s1");
         JDFMedia media = lo.appendMedia();
         media.setMediaType(EnumMediaType.Plate);
         Assert.IsNull(lo.getMedia(EnumMediaType.Paper));
         Assert.IsNull(s1.getMedia(EnumMediaType.Paper));
         Assert.AreEqual(s1.getMedia(EnumMediaType.Plate), media);
         Assert.AreEqual(lo.getMedia(EnumMediaType.Plate), media);

         JDFMedia media2 = s1.appendMedia();
         media2.setMediaType(EnumMediaType.Paper);
         Assert.IsNull(s1.getMedia(EnumMediaType.Plate));
         Assert.AreEqual(s1.getMedia(EnumMediaType.Paper), media2);
         JDFMedia media3 = s1.appendMedia();
         media3.setMediaType(EnumMediaType.Plate);
         Assert.AreEqual(s1.getMedia(EnumMediaType.Paper), media2);
         Assert.AreEqual(s1.getMedia(EnumMediaType.Plate), media3);
         media3.makeRootResource(null, null, true);
         Assert.AreEqual(s1.getMedia(EnumMediaType.Paper), media2);
         Assert.AreEqual(s1.getMedia(EnumMediaType.Plate), media3);
      }


      [TestMethod]
      public virtual void testGetLayoutLeavesOld()
      {
         testBuildOldLayout();

         JDFLayout lo = (JDFLayout)n.getMatchingResource(ElementName.LAYOUT, EnumProcessUsage.AnyInput, null, 0);
         VElement leaves = lo.getLayoutLeaves(false);
         Assert.AreEqual(2, leaves.Count);
         JDFSignature si = lo.getSignature(1);
         leaves = si.getLayoutLeaves(false);
         Assert.AreEqual(2, leaves.Count);
         JDFSheet sh = si.getSheet(2);
         leaves = sh.getLayoutLeaves(false);
         Assert.AreEqual(2, leaves.Count);
      }


      [TestMethod]
      public virtual void testGetLayoutLeavesNew()
      {
         testBuildNewLayout();

         JDFLayout lo = (JDFLayout)n.getMatchingResource(ElementName.LAYOUT, EnumProcessUsage.AnyInput, null, 0);
         VElement leaves = lo.getLayoutLeaves(false);
         Assert.AreEqual(6, leaves.Count, "2 Sigs, 2 sheets, 2 surfaces");
         JDFSignature si = lo.getSignature(1);
         leaves = si.getLayoutLeaves(false);
         Assert.AreEqual(4, leaves.Count, "2 sheets, 2 surfaces");
         JDFSheet sh = si.getSheet(2);
         leaves = sh.getLayoutLeaves(false);
         Assert.AreEqual(2, leaves.Count, "2 surfaces");
      }


      [TestMethod]
      public virtual void testGetSignatureVector_Old()
      {
         testBuildOldLayout();
         JDFLayout lo = (JDFLayout)n.getMatchingResource(ElementName.LAYOUT, EnumProcessUsage.AnyInput, null, 0);
         VElement v = lo.getSignatureVector();
         JDFSignature sig = (JDFSignature)v[0];
         Assert.AreEqual(sig.getName(), sig.getSignatureName());
         Assert.AreEqual("Sig1", sig.getSignatureName());
         JDFSignature sig2 = (JDFSignature)v[1];
         Assert.AreEqual(sig2.getName(), sig2.getSignatureName());
         Assert.AreEqual("Sig2", sig2.getSignatureName());
         VElement vSheet = sig2.getSheetVector();
         JDFSheet s1 = (JDFSheet)vSheet[1]; // don't try 0 it will
         // fail because it is
         // referenced...
         Assert.AreEqual("Sig2", s1.getSignatureName());
         Assert.AreEqual("Sheet2_2", s1.getSheetName());
         JDFSurface su = s1.getCreateBackSurface();
         Assert.AreEqual("Sig2", su.getSignatureName());
         Assert.AreEqual("Sheet2_2", su.getSheetName());
         Assert.AreEqual(su, s1.getSurfaceVector()[0]);
      }


      [TestMethod]
      public virtual void testGetSignatureName_Old()
      {
         testBuildOldLayout();
         JDFLayout lo = (JDFLayout)n.getMatchingResource(ElementName.LAYOUT, EnumProcessUsage.AnyInput, null, 0);
         JDFSignature sig = lo.getSignature(0);
         Assert.AreEqual(sig.getName(), sig.getSignatureName());
         Assert.AreEqual("Sig1", sig.getSignatureName());
         JDFSignature sig2 = lo.getSignature(1);
         Assert.AreEqual(sig2.getName(), sig2.getSignatureName());
         Assert.AreEqual("Sig2", sig2.getSignatureName());
         JDFSheet s1 = sig2.getSheet(1); // don't try 0 it will fail because it
         // is referenced...
         Assert.AreEqual("Sig2", s1.getSignatureName());
         Assert.AreEqual("Sheet2_2", s1.getSheetName());
         JDFSurface su = s1.getCreateBackSurface();
         Assert.AreEqual("Sig2", su.getSignatureName());
         Assert.AreEqual("Sheet2_2", su.getSheetName());
      }


      [TestMethod]
      public virtual void testGetSignatureByName()
      {
         for (int i = 0; i < 2; i++)
         {
            if (i == 0)
               testBuildNewLayout();
            else
            {
               testBuildOldLayout();
               JDFLayout lo = (JDFLayout)n.getMatchingResource(ElementName.LAYOUT, EnumProcessUsage.AnyInput, null, 0);
               lo.getSignature(0).setName("SignatureName1");
               lo.getSignature(1).setName("SignatureName2");
               lo.getSignature(1).getSheet(0).setName("SheetName1");
            }
            JDFLayout lo_1 = (JDFLayout)n.getMatchingResource(ElementName.LAYOUT, EnumProcessUsage.AnyInput, null, 0);
            Assert.IsNull(lo_1.getSignature("fooBar"));
            Assert.AreEqual(lo_1.getSignature("SignatureName1"), lo_1.getSignature(0));
            Assert.AreEqual(lo_1.getSheet("SheetName1"), lo_1.getSheet(0));
            JDFSignature signature2 = lo_1.getSignature("SignatureName2");
            Assert.AreEqual(signature2.getSheet("SheetName1"), lo_1.getSignature(1).getSheet(0));
            Assert.AreEqual(lo_1.getCreateSignature("fooBar"), lo_1.getSignature(-1));
         }
      }


      [TestMethod]
      public virtual void testGetSignatureName_New()
      {
         testBuildNewLayout();
         JDFLayout lo = (JDFLayout)n.getMatchingResource(ElementName.LAYOUT, EnumProcessUsage.AnyInput, null, 0);
         JDFSignature sig = lo.getSignature(0);
         Assert.AreEqual("SignatureName1", sig.getSignatureName());
         JDFSignature sig2 = lo.getSignature(1);
         Assert.AreEqual("SignatureName2", sig2.getSignatureName());
         JDFSheet s1 = sig2.getSheet(1); // don't try 0 it will fail because it
         // is referenced...
         Assert.AreEqual("SignatureName2", s1.getSignatureName());
         Assert.AreEqual("SheetName2", s1.getSheetName());
         JDFSurface su = s1.getCreateBackSurface();
         Assert.AreEqual("SignatureName2", su.getSignatureName());
         Assert.AreEqual("SheetName2", su.getSheetName());
      }


      [TestMethod]
      public virtual void testGetSignatureVector_New()
      {
         testBuildNewLayout();
         JDFLayout lo = (JDFLayout)n.getMatchingResource(ElementName.LAYOUT, EnumProcessUsage.AnyInput, null, 0);
         VElement v = lo.getSignatureVector();
         JDFSignature sig = (JDFSignature)v[0];
         Assert.AreEqual("SignatureName1", sig.getSignatureName());
         JDFSignature sig2 = (JDFSignature)v[1];
         Assert.AreEqual("SignatureName2", sig2.getSignatureName());
         VElement vSheet = sig2.getSheetVector();
         JDFSheet s1 = (JDFSheet)vSheet[1]; // don't try 0 it will
         // fail because it is
         // referenced...
         Assert.AreEqual("SignatureName2", s1.getSignatureName());
         Assert.AreEqual("SheetName2", s1.getSheetName());
         JDFSurface su = s1.getCreateBackSurface();
         Assert.AreEqual("SignatureName2", su.getSignatureName());
         Assert.AreEqual("SheetName2", su.getSheetName());
         Assert.AreEqual(su, s1.getSurfaceVector()[0]);
      }



      [TestMethod]
      public virtual void testFixVersionProblem()
      {
         JDFParser p = new JDFParser();
         JDFDoc d = p.parseFile(sm_dirTestData + "FixVersionProblem.jdf");
         Assert.IsNotNull(d, "FixVersionProblem exists");
         n = d.getJDFRoot();
         n.fixVersion(EnumVersion.Version_1_2);
         JDFLayout lo = (JDFLayout)n.getResourcePool().getElement(ElementName.LAYOUT, null, 0);
         Assert.AreEqual(1, lo.numChildElements("Signature", null));
      }



      //   
      //	 * GeneratedObject
      //	 * 
      //	 * CTM or Position Position: See ImageShift PositionX and PositionY, Shift
      //	 * (Margins) – See ShiftFront RelativeShift?
      //	 * 
      //	 * Anchor Point (same as position ll, ul, cc, spine…) (if CTM is given)
      //	 * Orientation (rotation, matrix or ll, ul, …) Contents Format/Template
      //	 * JobField (Replace, DynamicField?) SeparationList Mark References
      //	 * (FoldMark, CIE, …)
      //	 
      [TestMethod]
      public virtual void testGeneratedObject()
      {
         n = doc.getJDFRoot();
         JDFLayout lo = (JDFLayout)n.addResource("Layout", null, EnumUsage.Input, null, null, null, null);
         JDFRunList rlo = (JDFRunList)n.addResource("RunList", null, EnumUsage.Output, null, null, null, null);
         rlo.setFileURL("output.pdf");

         lo.appendXMLComment("This is a simple horizontal slug line\nAnchor specifies which of the 9 coordinates is the 0 point for the coordinate system specified in the CTM\nThis slugline describes error and endtime in the lower left corner of the scb", null);
         JDFMarkObject mark = lo.appendMarkObject();
         mark.setCTM(new JDFMatrix("1 0 0 1 0 0"));
         JDFJobField jf = mark.appendJobField();
         jf.setShowList(new VString("Error EndTime", " "));

         lo.appendXMLComment("This is a simple vertical slug line\nAnchor specifies which of the 9 coordinates is the 0 point for the coordinate system specified in the CTM\nThis slugline describes the operator name along the right side of the sheet text from top to bottom\nthe slug line (top right of the slug cs) is anchored in the bottom right of the sheet.\nNote that the coordinates in the ctm are guess work. the real coordinates are left as an exercise for the reader;-)", null);
         mark = lo.appendMarkObject();
         mark.setCTM(new JDFMatrix("0 1 -1 0 555 444"));
         jf = mark.appendJobField();
         jf.setShowList(new VString("Operator", " "));
         JDFDeviceMark dm = jf.appendDeviceMark();
         dm.setAttribute("Anchor", "TopRight");
         dm.setFont("Arial");
         dm.setFontSize(10);

         lo.appendXMLComment("This is a formatted vertical slug line\nAnchor specifies which of the 9 coordinates is the 0 point for the coordinate system specified in the CTM\nThis slugline describes a formatted line along the left side of the sheet text from top to bottom\nthe slug line (top left) is anchored in the bottom left of the sheet.\nThe text is defined in @Format with the sequence in ShowList defining the 5 placeholders marked by %s or %i\nAn example instance would be: \"This Cyan plate of Sheet1 was proudly produced by Joe Cool! Resolution: 600 x 600\"\nNote that the coordinates in the ctm are guess work. the real coordinates are left as an exercise for the reader;-)", null);
         mark = lo.appendMarkObject();
         mark.setCTM(new JDFMatrix("0 1 -1 0 0 0"));
         jf = mark.appendJobField();
         jf.setShowList(new VString("Separation SheetName Operator ResolutionX ResolutionY", " "));
         jf.setAttribute("Format", "This %s plate of %s was proudly produced by %s!\nResolution: %i x %i");
         dm = jf.appendDeviceMark();
         dm.setAttribute("Anchor", "TopLeft");
         dm.setFont("Arial");
         dm.setFontSize(10);

         lo.appendXMLComment("This is a positioned registermark\nthe center of the mark is translated by 666 999\n the JobField is empty and serves aa a Marker that no external Content is requested", null);
         mark = lo.appendMarkObject();
         mark.setCTM(new JDFMatrix("1 0 0 1 666 999"));
         jf = mark.appendJobField();
         mark.appendXMLComment("The coordinate system origin is defined by the anchor in the center, i.e. 0 0\n the separartions are excluding black", null);
         JDFRegisterMark rm = mark.appendRegisterMark();
         rm.setMarkType("Arc Cross");
         rm.setMarkUsage(EnumMarkUsage.Color);
         rm.setCenter(new JDFXYPair("0 0"));
         rm.setSeparations(new VString("Cyan Magent Yellow", " "));
         dm = jf.appendDeviceMark();
         dm.setAttribute("Anchor", "Center");

         doc.write2File(sm_dirTestDataTemp + "generatedObject.jdf", 2, false);

      }
   }
}
