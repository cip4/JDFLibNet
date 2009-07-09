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
   using System.Collections;
   using Microsoft.VisualStudio.TestTools.UnitTesting;


   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using EnumValidationLevel = org.cip4.jdflib.core.KElement.EnumValidationLevel;
   using JDFIntegerRange = org.cip4.jdflib.datatypes.JDFIntegerRange;
   using JDFIntegerRangeList = org.cip4.jdflib.datatypes.JDFIntegerRangeList;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using JDFResourcePool = org.cip4.jdflib.pool.JDFResourcePool;
   using EnumPartIDKey = org.cip4.jdflib.resource.JDFResource.EnumPartIDKey;
   using JDFIntegerEvaluation = org.cip4.jdflib.resource.devicecapability.JDFIntegerEvaluation;
   using JDFNameEvaluation = org.cip4.jdflib.resource.devicecapability.JDFNameEvaluation;
   using JDFStringEvaluation = org.cip4.jdflib.resource.devicecapability.JDFStringEvaluation;
   using JDFand = org.cip4.jdflib.resource.devicecapability.JDFand;
   using EnumTerm = org.cip4.jdflib.resource.devicecapability.JDFTerm.EnumTerm;
   using JDFRunData = org.cip4.jdflib.resource.process.JDFRunList.JDFRunData;
   using JDFColorSpaceConversionOp = org.cip4.jdflib.resource.process.prepress.JDFColorSpaceConversionOp;
   using JDFColorSpaceConversionParams = org.cip4.jdflib.resource.process.prepress.JDFColorSpaceConversionParams;
   using StringUtil = org.cip4.jdflib.util.StringUtil;

   ///
   /// <summary> * @author Rainer Prosi, Heidelberger Druckmaschinen
   /// * </summary>
   /// 
   [TestClass]
   public class JDFRunListTest : JDFTestCaseBase
   {

      ///   
      ///	 <summary> *  </summary>
      ///	 
      private const string EXPR = "Expr";
      private const string METADATA_MAP = "MetadataMap";
      private JDFDoc doc;
      private JDFNode root;
      private JDFRunList rl;

      [TestMethod]
      public void testCollapseNPage()
      {
         JDFRunList rl1 = rl.addPDF("file:///file1.pdf", 0, 2);
         JDFRunList rl2 = rl.addPDF("file:///file2.pdf", 1, 3);
         Assert.AreEqual(6, rl.getNPage());
         Assert.AreEqual(3, rl1.getNPage());
         Assert.AreEqual(3, rl2.getNPage());

         rl.collapse(false);
         Assert.AreEqual(6, rl.getNPage());
         Assert.AreEqual(3, rl1.getNPage());
         Assert.AreEqual(3, rl2.getNPage());
         JDFRunList rl3 = rl.addPDF("file:///file3.pdf", 1, 3);
         Assert.AreEqual(9, rl.getNPage());
         rl.expand(false);
         Assert.AreEqual(9, rl.getNPage());
         Assert.AreEqual(3, rl1.getNPage());
         Assert.AreEqual(3, rl2.getNPage());
         rl.collapse(false);
         Assert.AreEqual(9, rl.getNPage());
         Assert.AreEqual(3, rl1.getNPage());
         Assert.AreEqual(3, rl2.getNPage());
         Assert.AreEqual(3, rl3.getNPage());
      }


      [TestMethod]
      public void testAddRun()
      {
         JDFRunList rl2 = rl.addRun("f1.pdf", 0, -1);
         Assert.IsFalse(rl2.hasAttribute_KElement(AttributeName.NPAGE, null, false));
         Assert.IsFalse(rl.hasAttribute_KElement(AttributeName.NPAGE, null, false));
      }


      [TestMethod]
      public void testGetFileURL()
      {
         rl.setFileURL("./foo/bar.pdf");
         rl.setDirectory("FileInfo://c/fnarf");
         Assert.AreEqual("FileInfo://c/fnarf/foo/bar.pdf", rl.getFileURL());
      }


      [TestMethod]
      public void testSetPages()
      {
         JDFIntegerRangeList integerRangeList = new JDFIntegerRangeList(new JDFIntegerRange(0, -1, 8));
         rl.setPages(integerRangeList);
         Assert.AreEqual(integerRangeList, rl.getPages());
         Assert.AreEqual(8, rl.getNPage());
      }


      [TestMethod]
      public void testGetMimeType()
      {
         JDFResourcePool resPool = root.getCreateResourcePool();
         KElement kElem = resPool.appendResource(ElementName.RUNLIST, null, null);
         Assert.IsTrue(kElem is JDFRunList);
         JDFRunList ruli = (JDFRunList)kElem;
         Assert.IsNull(ruli.getFileMimeType());
         kElem.setXPathAttribute("LayoutElement/FileSpec/@MimeType", "application/pdf");
         Assert.AreEqual("application/pdf", ruli.getFileMimeType());
      }


      [TestMethod]
      public void testGetTruePage()
      {
         JDFResourcePool resPool = root.getCreateResourcePool();
         JDFRunList ruli = (JDFRunList)resPool.appendResource(ElementName.RUNLIST, null, null);
         Assert.AreEqual(ruli, ruli.getTruePage());
         JDFRunList ruli2 = ruli.addSepRun(StringUtil.tokenize("c.pdf m.pdf y.pdf k.pdf", " ", false), StringUtil.tokenize("Cyan Magenta Yellow Black", " ", false), 0, 4, true);
         Assert.AreEqual(ruli, ruli.getTruePage());
         Assert.AreEqual(ruli2, ruli2.getTruePage());
         JDFRunList ruli2c = (JDFRunList)ruli2.getElement_KElement(ElementName.RUNLIST, null, 0);
         Assert.AreEqual(ruli2, ruli2.getTruePage());
         Assert.AreEqual(ruli2, ruli2c.getTruePage());
      }

      //   
      //	 * Test method for
      //	 * 'org.cip4.jdflib.resource.process.JDFMedia.setDimensionCM(JDFXYPair)'
      //	 
      [TestMethod]
      public void testGetNPage()
      {
         JDFRunList rlp = (JDFRunList)rl.addPartition(EnumPartIDKey.Run, "r1");
         rlp.setPages(new JDFIntegerRangeList("1 3 5 7"));
         Assert.AreEqual(4, rlp.getNPage());
         rlp.setNPage(3);
         Assert.AreEqual(3, rlp.getNPage());
         JDFRunList rlp2 = (JDFRunList)rl.addPartition(EnumPartIDKey.Run, "r2");
         rlp2.setPages(new JDFIntegerRangeList("0 2 4 6"));
         Assert.AreEqual(4, rlp2.getNPage());
         rlp2.setNPage(3);
         Assert.AreEqual(3, rlp2.getNPage());
         Assert.AreEqual(6, rl.getNPage());
      }

      //   
      //	 * Test method for
      //	 * 'org.cip4.jdflib.resource.process.JDFMedia.setDimensionCM(JDFXYPair)'
      //	 
      [TestMethod]
      public void testGetIndexPartition()
      {
         JDFRunList rlp = (JDFRunList)rl.addPartition(EnumPartIDKey.Run, "r1");
         rlp.setPages(new JDFIntegerRangeList("1 3 5 7"));
         Assert.AreEqual(rlp, rl.getIndexPartition(0));
         Assert.AreEqual(rlp, rl.getIndexPartition(3));
         rlp.setNPage(3);
         JDFRunList rlp2 = (JDFRunList)rl.addPartition(EnumPartIDKey.Run, "r2");
         rlp2.setPages(new JDFIntegerRangeList("0 2 4 6"));
         Assert.AreEqual(rlp2, rl.getIndexPartition(3));
         Assert.AreEqual(rlp2, rl.getIndexPartition(6));
         Assert.IsNull(rl.getIndexPartition(7));
      }

      //   
      //	 * Test method for
      //	 * 'org.cip4.jdflib.resource.process.JDFMedia.setDimensionCM(JDFXYPair)'
      //	 
      [TestMethod]
      public void testGetPageInFile()
      {
         JDFRunList rlp = (JDFRunList)rl.addPartition(EnumPartIDKey.Run, "r1");
         rlp.setPages(new JDFIntegerRangeList("1 3 5 7"));
         Assert.AreEqual(1, rlp.getPageInFile(0));
         Assert.AreEqual(3, rlp.getPageInFile(1));
         Assert.AreEqual(7, rlp.getPageInFile(3));
         rlp.setNPage(3);
         Assert.AreEqual(-1, rlp.getPageInFile(3));
         JDFRunList rlp2 = (JDFRunList)rl.addPartition(EnumPartIDKey.Run, "r2");
         rlp2.setPages(new JDFIntegerRangeList("0 2 4 6"));
         Assert.AreEqual(-1, rlp2.getPageInFile(0));
         Assert.AreEqual(0, rlp2.getPageInFile(3));
         Assert.AreEqual(4, rlp2.getPageInFile(5));
         Assert.AreEqual(6, rlp2.getPageInFile(6));
         rlp2.setNPage(3);
         Assert.AreEqual(-1, rlp2.getPageInFile(6));
         rlp2.setNPage(4);
         Assert.AreEqual(6, rlp2.getPageInFile(6));
      }

      //   
      //	 * Test method for
      //	 * 'org.cip4.jdflib.resource.process.JDFMedia.setDimensionCM(JDFXYPair)'
      //	 
      [TestMethod]
      public void testGetPageLeaves()
      {
         JDFRunList rlp = (JDFRunList)rl.addPartition(EnumPartIDKey.Run, "r1");
         JDFRunList rlp2 = (JDFRunList)rl.addPartition(EnumPartIDKey.Run, "r2");
         VElement v = rl.getPageLeaves();
         Assert.IsTrue(v.Contains(rlp));
         Assert.IsTrue(v.Contains(rlp2));
         Assert.AreEqual(2, v.Count);
         JDFRunList rlp21 = (JDFRunList)rlp2.addPartition(EnumPartIDKey.RunSet, "s1");
         JDFRunList rlp22 = (JDFRunList)rlp2.addPartition(EnumPartIDKey.RunSet, "s2");
         v = rl.getPageLeaves();
         Assert.IsTrue(v.Contains(rlp));
         Assert.IsFalse(v.Contains(rlp2));
         Assert.IsTrue(v.Contains(rlp21));
         Assert.IsTrue(v.Contains(rlp22));
         Assert.AreEqual(3, v.Count);
         rlp21.setIsPage(false);
         rlp22.setIsPage(false);
         v = rl.getPageLeaves();
         Assert.IsTrue(v.Contains(rlp));
         Assert.IsTrue(v.Contains(rlp2));
         Assert.AreEqual(2, v.Count);
         v = rlp2.getPageLeaves();
         Assert.IsTrue(v.Contains(rlp2));
         Assert.AreEqual(1, v.Count);

      }

      //   
      //	 * Test method for
      //	 * 'org.cip4.jdflib.resource.process.JDFMedia.setDimensionCM(JDFXYPair)'
      //	 
      [TestMethod]
      public void testGetIndex()
      {
         JDFRunList rlp = (JDFRunList)rl.addPartition(EnumPartIDKey.Run, "r1");
         rlp.setPages(new JDFIntegerRangeList("1 3 5 7"));
         Assert.AreEqual(0, rlp.getFirstIndex(), "first partition starts at 0");
         Assert.AreEqual(3, rlp.getLastIndex());
         rlp.setNPage(3);
         Assert.AreEqual(0, rlp.getFirstIndex());
         Assert.AreEqual(2, rlp.getLastIndex());
         JDFRunList rlp2 = (JDFRunList)rl.addPartition(EnumPartIDKey.Run, "r2");
         rlp2.setPages(new JDFIntegerRangeList("0 2 4 6"));
         Assert.AreEqual(3, rlp2.getFirstIndex());
         Assert.AreEqual(6, rlp2.getLastIndex());
         rlp2.setNPage(2);
         Assert.AreEqual(3, rlp2.getFirstIndex());
         Assert.AreEqual(4, rlp2.getLastIndex());
         JDFRunList rlp3 = (JDFRunList)rl.addPartition(EnumPartIDKey.Run, "r3");
         rlp2.setLogicalPage(11);
         rlp3.setPages(new JDFIntegerRangeList("0 2 4 6"));
         Assert.AreEqual(13, rlp3.getFirstIndex());
         Assert.AreEqual(16, rlp3.getLastIndex());
         rlp3.setNPage(2);
         rlp3.setLogicalPage(22);
         Assert.AreEqual(22, rlp3.getFirstIndex());
         Assert.AreEqual(23, rlp3.getLastIndex());
      }

      //   
      //	 * Test method for
      //	 * 'org.cip4.jdflib.resource.process.JDFMedia.setDimensionCM(JDFXYPair)'
      //	 
      [TestMethod]
      public void testPageIterator()
      {
         JDFRunList rlp = (JDFRunList)rl.addPartition(EnumPartIDKey.Run, "r1");
         rlp.setPages(new JDFIntegerRangeList("1 3 5 7"));
         rlp.setNPage(3);
         JDFRunList rlp2 = (JDFRunList)rl.addPartition(EnumPartIDKey.Run, "r2");
         rlp2.setPages(new JDFIntegerRangeList("0 2 4 6"));
         IEnumerator it = rl.getPageIterator();
         int n = 0;
         while (it.MoveNext())
         {
            JDFRunData ri = (JDFRunData)it.Current;
            Assert.AreEqual(ri.getRunIndex(), n);
            Assert.AreEqual(ri.getRunList(), n < 3 ? rlp : rlp2);
            n++;
         }
         Assert.AreEqual(7, n);
      }

      ///   
      ///	 <summary> * performance check for the runlist iterator
      ///	 *  </summary>
      ///	 * <exception cref="Exception"> </exception>
      ///	 
      [TestMethod]
      public void testPageIteratorSpeed()
      {
         int nMax = 3000;
         for (int i = 0; i < nMax; i++)
         {
            JDFRunList rlp = (JDFRunList)rl.addPartition(EnumPartIDKey.Run, "r" + i);
            rlp.setPages(new JDFIntegerRangeList("1 3 5 7"));
            rlp.setFileURL("FileInfo://Test" + i + ".pdf");
         }
         IEnumerator it = rl.getPageIterator();
         int n = 0;

         while (it.MoveNext())
         {
            JDFRunData ri = (JDFRunData)it.Current;
            Assert.AreEqual(n, ri.getRunIndex());
            Assert.AreEqual(n % 4, ((ri.getPageInFile() - 1) / 2) % 4);
            n++;
         }
         Assert.AreEqual(n, 4 * nMax);
      }

      ///   
      ///	 <summary> * experimental mapping of tags to partition keys </summary>
      ///	 
      [TestMethod]
      public virtual void testTagMapTiff()
      {
         KElement tagMap = rl.appendElement(METADATA_MAP);
         tagMap.setAttribute("BoundaryKey", "EndOfDocument");
         KElement tagSet = tagMap.appendElement(EXPR);
         tagSet.setAttribute("Path", "/x3141");
         tagMap.setXMLComment("This tagmap specifies which document structure corresponds to a Document\n" + " thus incrementing DocIndex or forcing an implicit RunList/@EndofDocument=true\n D100 is the tiff tag 0x3141");

         rl.setFileURL("bigVariable.tiff");
         rl.setXMLComment("this runlist points to a tiff file with arbitrary structural tagging defined in the tiff tags");
      }

      ///   
      ///	 <summary> * experimental mapping of tags to partition keys </summary>
      ///	 
      [TestMethod]
      public virtual void testObjectTagsMetadata()
      {
         KElement tagMap = rl.appendElement(METADATA_MAP);
         tagMap.setXMLComment("This tagmap specifies The path for the NMTOKEN \"ObjectTag\"");
         tagMap.setAttribute("Name", "ObjectTags");
         tagMap.setAttribute(AttributeName.VALUEFORMAT, "%s");
         tagMap.setAttribute(AttributeName.CONTEXT, "Object");
         tagMap.setAttribute(AttributeName.DATATYPE, "NMTOKEN");
         tagMap.setAttribute(AttributeName.VALUETEMPLATE, "AnyName1");
         tagMap.addNameSpace("TIFFXMP", "http://ns.adobe.com/tiff/1.0");
         string[] ss = new string[] { "Acme", "Bcme", "Ccme" };
         for (int i = 0; i < ss.Length; i++)
         {
            string s = ss[i];
            KElement tagSet = tagMap.appendElement(EXPR);
            tagSet.setAttribute("Name", "AnyName1");
            tagSet.setAttribute("Value", s);

            JDFStringEvaluation eval = (JDFStringEvaluation)tagSet.appendElement(ElementName.STRINGEVALUATION);
            eval.setAttribute("Path", "TIFFXMP:Make");
            eval.setRegExp("(.*)" + s + "(.*)");
            eval.setXMLComment("Any acme camera is mapped to \"" + s + "\"");
         }
         JDFColorSpaceConversionParams csp = (JDFColorSpaceConversionParams)root.addResource(ElementName.COLORSPACECONVERSIONPARAMS, EnumUsage.Input);
         csp.setXMLComment("This ColorSpaceConversionParams treats Acme and Bcme cameras the same but differentiates for Ccme");
         JDFColorSpaceConversionOp op1 = csp.appendColorSpaceConversionOp();
         op1.setAttribute("ObjectTags", "Acme Bcme");
         JDFColorSpaceConversionOp op2 = csp.appendColorSpaceConversionOp();
         op2.setAttribute("ObjectTags", "Ccme");
         doc.write2File(sm_dirTestDataTemp + "objectTags.jdf", 2, false);
      }

      ///   
      ///	 <summary> * experimental mapping of tags to partition keys </summary>
      ///	 * <exception cref="Exception">  </exception>
      ///	 
      [TestMethod]
      public virtual void testTagMap()
      {

         JDFLayout lo = (JDFLayout)root.addResource(ElementName.LAYOUT, null, EnumUsage.Input, null, null, null, null);
         JDFMedia med = (JDFMedia)root.addResource(ElementName.MEDIA, null, EnumUsage.Input, null, null, null, null);
         JDFMedia medM = (JDFMedia)med.addPartition(EnumPartIDKey.RunTags, "MaleCover");
         JDFMedia medF = (JDFMedia)med.addPartition(EnumPartIDKey.RunTags, "FemaleCover");
         JDFMedia medB = (JDFMedia)med.addPartition(EnumPartIDKey.RunTags, "MaleBigBody MaleSmallBody FemaleBigBody FemaleSmallBody");

         JDFLayout loM = (JDFLayout)lo.addPartition(EnumPartIDKey.RunTags, "MaleCover");
         loM.refElement(medM);
         JDFLayout loF = (JDFLayout)lo.addPartition(EnumPartIDKey.RunTags, "FemaleCover");
         loF.refElement(medF);
         JDFLayout loBB = (JDFLayout)lo.addPartition(EnumPartIDKey.RunTags, "MaleBigBody FemaleBigBody");
         loBB.refElement(medB);
         JDFLayout loSB = (JDFLayout)lo.addPartition(EnumPartIDKey.RunTags, "MaleSmallBody FemaleSmallBody");
         loSB.refElement(medB);
         lo.setXMLComment("Layout for versioned product");

         KElement metaMap = rl.appendElement(METADATA_MAP);
         metaMap.setXMLComment("The MetadataMap element maps arbitrary tags in the document to a structural RunTag partition key\n" + "Note that any partition key may be mapped.\n" + "Note also that although an XPath syntax is used, this may be mapped to any hierarchical structure including but not limited to XML.\n");

         metaMap.setAttribute("Name", "RunTags");
         metaMap.setAttribute(AttributeName.DATATYPE, "PartIDKey");
         metaMap.setAttribute(AttributeName.VALUEFORMAT, "%s%s");
         metaMap.setAttribute(AttributeName.VALUETEMPLATE, "sex,section");

         KElement expr = metaMap.appendElement(EXPR);
         expr.setXMLComment("This expression maps the value of /Dokument/Rezipient/@Sex to a variable \"sex\"\n" + "The Mapping is unconditional, therefore no Term is required");
         expr.setAttribute("Name", "sex");
         expr.setAttribute("Path", "/Dokument/Rezipient/@Sex");

         expr = metaMap.appendElement(EXPR);
         expr.setXMLComment("Maps all elements with /Dokument/Sektion=Einband to Cover");
         expr.setAttribute("Name", "section");
         expr.setAttribute("Value", "Cover");
         JDFNameEvaluation nev = (JDFNameEvaluation)expr.appendElement(ElementName.NAMEEVALUATION);
         nev.setAttribute("Path", "/Dokument/Sektion");
         nev.setRegExp("Einband");

         expr = metaMap.appendElement(EXPR);
         expr.setXMLComment("Maps all elements with /Dokument/Sektion=HauptTeil and >50 pages to BigBody");
         expr.setAttribute("Name", "section");
         expr.setAttribute("Value", "BigBody");

         JDFand and = (JDFand)expr.appendElement("and");
         nev = (JDFNameEvaluation)and.appendElement(ElementName.NAMEEVALUATION);
         nev.setAttribute("Path", "/Dokument/Sektion");
         nev.setRegExp("HauptTeil");
         JDFIntegerEvaluation iev = (JDFIntegerEvaluation)and.appendTerm(EnumTerm.IntegerEvaluation);
         iev.setAttribute("Path", "count(PAGE)");
         iev.setValueList(new JDFIntegerRangeList("51~INF"));

         expr = metaMap.appendElement(EXPR);
         expr.setXMLComment("Maps all elements with /Dokument/Sektion=HauptTeil and <=50 pages to SmallBody");
         expr.setAttribute("Name", "section");
         expr.setAttribute("Value", "SmallBody");

         and = (JDFand)expr.appendElement("and");
         nev = (JDFNameEvaluation)and.appendElement(ElementName.NAMEEVALUATION);
         nev.setAttribute("Path", "/Dokument/Sektion");
         nev.setRegExp("HauptTeil");
         iev = (JDFIntegerEvaluation)and.appendTerm(EnumTerm.IntegerEvaluation);
         iev.setAttribute("Path", "count(PAGE)");
         iev.setValueList(new JDFIntegerRangeList("0~INF"));

         rl.setFileURL("bigVariable.ppml");
         rl.setXMLComment("this runlist points to a ppml with arbitrary structural tagging");

         JDFResourceLink rll = root.getLink(rl, null);
         rll.appendPart().setDocIndex(new JDFIntegerRangeList("10 ~ 20"));
         rll.setXMLComment("this link selects the 11-20 document");

         doc.write2File(sm_dirTestDataTemp + "metadataMap.jdf", 2, false);
      }


      [TestMethod]
      public virtual void testSeparatedTiff()
      {
         ArrayList v1 = StringUtil.tokenize("Cyan Magenta Yello Black", " ", false);
         ArrayList v2 = new ArrayList();
         for (int i = 0; i < v1.Count; i++)
            v2.Add("FileInfo://device/dir/" + v1[i] + ".tif");
         JDFRunList rl2 = rl.addSepRun(v2, v1, 0, 0, false);
         Assert.IsTrue(rl2.isValid(EnumValidationLevel.Complete));

      }


      [TestInitialize]
      public override void setUp()
      {
         JDFElement.setLongID(false);
         base.setUp();
         doc = new JDFDoc("JDF");
         root = doc.getJDFRoot();
         rl = (JDFRunList)root.addResource(ElementName.RUNLIST, EnumUsage.Input);

      }
   }
}
