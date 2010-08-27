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
 * @author muchadie
 */

namespace org.cip4.jdflib.util
{
   using System;
   using System.IO;
   using System.Collections;
   using System.Net;
   using System.Net.Mail;
   using System.Net.Mime;
   using System.Text;
   using Microsoft.VisualStudio.TestTools.UnitTesting;


   using VElement = org.cip4.jdflib.core.VElement;
   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFParser = org.cip4.jdflib.core.JDFParser;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using JDFCommand = org.cip4.jdflib.jmf.JDFCommand;
   using JDFJMF = org.cip4.jdflib.jmf.JDFJMF;
   using JDFMessage = org.cip4.jdflib.jmf.JDFMessage;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using EnumType = org.cip4.jdflib.node.JDFNode.EnumType;
   using JDFFileSpec = org.cip4.jdflib.resource.process.JDFFileSpec;
   using JDFRunList = org.cip4.jdflib.resource.process.JDFRunList;
   using JDFColorSpaceConversionParams = org.cip4.jdflib.resource.process.prepress.JDFColorSpaceConversionParams;
   using MIMEDetails = org.cip4.jdflib.util.MimeUtil.MIMEDetails;

   [TestClass]
   public class MimeUtilTest : JDFTestCaseBase
   {

      [TestMethod]
      public virtual void testGetMimeTypeFromExt()
      {
         Assert.AreEqual(UrlUtil.TEXT_UNKNOWN, MimeUtil.getMimeTypeFromExt("www.foobar.com"));
         Assert.AreEqual(UrlUtil.VND_JDF, MimeUtil.getMimeTypeFromExt(".JDF"));
         Assert.AreEqual(UrlUtil.VND_JDF, MimeUtil.getMimeTypeFromExt(".jdf"));
         Assert.AreEqual(UrlUtil.VND_JDF, MimeUtil.getMimeTypeFromExt("http://fobar.con/snarf.jdf"));
         Assert.AreEqual(UrlUtil.VND_JMF, MimeUtil.getMimeTypeFromExt("http://fobar.con/snarf.JMF"));
         Assert.AreEqual(UrlUtil.TEXT_XML, MimeUtil.getMimeTypeFromExt("http://fobar.con/snarf.xml"));
      }


      [TestMethod]
      public virtual void testBuildMimePackageDocJMF()
      {
         JDFDoc docJMF = new JDFDoc("JMF");
         docJMF.setOriginalFileName("JMF.jmf");
         JDFJMF jmf = docJMF.getJMFRoot();
         JDFCommand com = (JDFCommand)jmf.appendMessageElement(JDFMessage.EnumFamily.Command, JDFMessage.EnumType.SubmitQueueEntry);
         com.appendQueueSubmissionParams().setURL("TheJDF");

         JDFDoc doc = new JDFDoc("JDF");
         doc.setOriginalFileName("JDF.jdf");
         JDFNode n = doc.getJDFRoot();
         n.setType(EnumType.ColorSpaceConversion);
         JDFColorSpaceConversionParams cscp = (JDFColorSpaceConversionParams)n.addResource(ElementName.COLORSPACECONVERSIONPARAMS, null, EnumUsage.Input, null, null, null, null);
         JDFFileSpec fs0 = cscp.appendFinalTargetDevice();
         fs0.setURL(StringUtil.uncToUrl(sm_dirTestData + "test.icc", true));
         JDFRunList rl = (JDFRunList)n.addResource(ElementName.RUNLIST, null, EnumUsage.Input, null, null, null, null);
         rl.addPDF(StringUtil.uncToUrl(sm_dirTestData + "url1.pdf", false), 0, -1);
         for (int i = 0; i < 100; i++)
            rl.addPDF(StringUtil.uncToUrl(sm_dirTestData + "url?.pdf", false), 0, -1);
         AttachmentCollection m = MimeUtil.buildMimePackage(docJMF, doc, true);
         MimeUtil.writeToFile(m, sm_dirTestDataTemp + "testMimePackageDoc.mjm", null);
      }


      [TestMethod]
      public virtual void testGetJMFSubmission()
      {
         JDFDoc d1 = new JDFDoc("JMF");
         d1.setOriginalFileName("JMF.jmf");
         JDFJMF jmf = d1.getJMFRoot();
         jmf.setDeviceID("gr?n?");
         JDFCommand com = (JDFCommand)jmf.appendMessageElement(JDFMessage.EnumFamily.Command, JDFMessage.EnumType.SubmitQueueEntry);

         com.appendQueueSubmissionParams().setURL("TheJDF");

         JDFDoc doc = new JDFDoc("JDF");
         doc.setOriginalFileName("JDF.jdf");
         JDFNode n = doc.getJDFRoot();
         n.setType(EnumType.ColorSpaceConversion);
         JDFColorSpaceConversionParams cscp = (JDFColorSpaceConversionParams)n.addResource(ElementName.COLORSPACECONVERSIONPARAMS, null, EnumUsage.Input, null, null, null, null);
         JDFFileSpec fs0 = cscp.appendFinalTargetDevice();
         fs0.setURL(StringUtil.uncToUrl(sm_dirTestData + "test.icc", true));
         JDFRunList rl = (JDFRunList)n.addResource(ElementName.RUNLIST, null, EnumUsage.Input, null, null, null, null);
         rl.addPDF(StringUtil.uncToUrl(sm_dirTestData + "url1.pdf", false), 0, -1);
         for (int i = 0; i < 100; i++)
            rl.addPDF("gr?n?" + i + ".pdf", 0, -1);
         AttachmentCollection m = MimeUtil.buildMimePackage(d1, doc, true);

         JDFDoc[] d2 = MimeUtil.GetJMFSubmission(m);
         Assert.IsNotNull(d2);
         Assert.AreEqual("cid:JDF.jdf", d2[0].getJMFRoot().getCommand(0).getQueueSubmissionParams(0).getURL());
         Assert.AreEqual(EnumType.ColorSpaceConversion, d2[1].getJDFRoot().getEnumType());

         // now serialize to file and reread - should still work
         MimeUtil.writeToFile(m, sm_dirTestDataTemp + "test2.mjm", null);
         AttachmentCollection m2 = MimeUtil.GetMultiPart(sm_dirTestDataTemp + "test2.mjm");
         Assert.IsNotNull(m2);
         d2 = MimeUtil.GetJMFSubmission(m);
         Assert.IsNotNull(d2);
         Assert.AreEqual("cid:JDF.jdf", d2[0].getJMFRoot().getCommand(0).getQueueSubmissionParams(0).getURL());
         Assert.AreEqual(EnumType.ColorSpaceConversion, d2[1].getJDFRoot().getEnumType());
      }


      [TestMethod]
      public virtual void testGetPartByCID()
      {
         testBuildMimePackageDocJMF();
         AttachmentCollection mp = MimeUtil.GetMultiPart(sm_dirTestDataTemp + "testMimePackageDoc.mjm");
         Attachment bp = MimeUtil.GetPartByCID(mp, "JDF.jdf");
         Assert.IsNotNull(bp);
         Assert.AreEqual("JDF.jdf", bp.Name);
      }


      [TestMethod]
      public virtual void testGetContentID()
      {
         testBuildMimePackageDocJMF();
         AttachmentCollection mp = MimeUtil.GetMultiPart(sm_dirTestDataTemp + "testMimePackageDoc.mjm");
         Attachment bp = MimeUtil.GetPartByCID(mp, "JDF.jdf");
         Assert.IsNotNull(bp);
         Assert.AreEqual("JDF.jdf", bp.Name);
         Assert.AreEqual("JDF.jdf", MimeUtil.getContentID(bp));
         MimeUtil.setContentID(bp, "TheJDF");
         Assert.AreEqual("TheJDF", MimeUtil.getContentID(bp));
         MimeUtil.setContentID(bp, "<TheJDF>");
         Assert.AreEqual("TheJDF", MimeUtil.getContentID(bp));
         MimeUtil.setContentID(bp, "<cid:TheJDF>");
         Assert.AreEqual("TheJDF", MimeUtil.getContentID(bp));
      }


      [TestMethod]
      public virtual void testGetMultiPart()
      {
         testBuildMimePackageDocJMF();
         AttachmentCollection mp = MimeUtil.GetMultiPart(sm_dirTestDataTemp + "testMimePackageDoc.mjm");
         MimeUtil.writeToFile(mp, sm_dirTestDataTemp + "testMimePackageDoc_out.mjm", null);
      }


      [TestMethod]
      public virtual void testGetCreatePartByCID()
      {
         AttachmentCollection multipart = null; 

         Attachment bp = MimeUtil.GetCreatePartByCID(multipart, "cid1");
         MimeUtil.SetAttachmentContent(bp, "boo");
         Attachment bp2 = MimeUtil.GetCreatePartByCID(multipart, "cid2");
         MimeUtil.SetAttachmentContent(bp2, "bar");
         Attachment bp3 = MimeUtil.GetCreatePartByCID(multipart, "cid1");
         Assert.AreEqual(bp, bp3);
         Assert.AreEqual(2, multipart.Count);
         Assert.AreEqual("boo", MimeUtil.GetAttachmentContent(bp3));
      }


      [TestMethod]
      public virtual void testGetJDFDoc()
      {
         testBuildMimePackageDocJMF();
         AttachmentCollection mp = MimeUtil.GetMultiPart(sm_dirTestDataTemp + "testMimePackageDoc.mjm");
         Attachment bp = MimeUtil.GetPartByCID(mp, "JDF.jdf");
         Assert.IsNotNull(bp);
         Attachment bp2 = MimeUtil.GetPartByCID(mp, "CID:JDF.jdf");
         Assert.AreEqual(bp, bp2);
         Attachment bp3 = MimeUtil.GetPartByCID(mp, "<cid:JDF.jdf>");
         Assert.AreEqual(bp, bp3);
         Assert.AreEqual("JDF.jdf", bp.Name);
         JDFDoc d = MimeUtil.getJDFDoc(bp);
         Assert.IsNotNull(d);
         JDFNode n = d.getJDFRoot();
         Assert.IsNotNull(n);
      }


      [TestMethod]
      public virtual void testBuildMimePackageDoc()
      {
         for (int i = 0; i < 2; i++)
         {
            JDFDoc doc = new JDFDoc("JDF");
            if (i == 1)
               doc.setOriginalFileName("JDF.jdf");
            JDFNode n = doc.getJDFRoot();
            n.setType(EnumType.ColorSpaceConversion);
            JDFColorSpaceConversionParams cscp = (JDFColorSpaceConversionParams)n.addResource(ElementName.COLORSPACECONVERSIONPARAMS, null, EnumUsage.Input, null, null, null, null);
            JDFFileSpec fs0 = cscp.appendFinalTargetDevice();
            fs0.setURL(StringUtil.uncToUrl(sm_dirTestData + "test.icc", true));
            JDFRunList rl = (JDFRunList)n.addResource(ElementName.RUNLIST, null, EnumUsage.Input, null, null, null, null);
            rl.addPDF(StringUtil.uncToUrl(sm_dirTestData + "url1.pdf", false), 0, -1);
            rl.addPDF(StringUtil.uncToUrl(sm_dirTestData + "url1.pdf", false), 0, -1);
            rl.addPDF(StringUtil.uncToUrl(sm_dirTestData + "url2.pdf", false), 0, -1);
            AttachmentCollection m = MimeUtil.buildMimePackage(null, doc, true);

            string mimeFile = sm_dirTestDataTemp + "testMimePackageDoc" + (i == 0 ? "0" : "") + ".mjm";
            MimeUtil.writeToFile(m, mimeFile, null);

            AttachmentCollection mp = MimeUtil.GetMultiPart(mimeFile);
            Assert.AreEqual(4, mp.Count, "JDF, 2* rl, 1 icc");
         }
      }


      [TestMethod]
      public virtual void testUpdateXMLMultipart()
      {
         AttachmentCollection multipart = null; 
         JDFDoc jDoc = new JDFDoc("JMF");

         MimeUtil.updateXMLMultipart(multipart, jDoc, null);
         string mimeFile = sm_dirTestDataTemp + "testUpdateXML";
         MimeUtil.writeToFile(multipart, mimeFile + "0.mjm", null);
         AttachmentCollection multiparsed = MimeUtil.GetMultiPart(mimeFile + "0.mjm");
         Attachment bp = multiparsed[0];
         Assert.IsTrue(bp.ContentId.Length > 5, "cid >cid_");

         JDFDoc jDoc1 = new JDFDoc("JDF");
         jDoc1.setOriginalFileName("jdf1.jdf");

         MimeUtil.updateXMLMultipart(multipart, jDoc1, null);

         MimeUtil.writeToFile(multipart, mimeFile + "1.mjm", null);
         multiparsed = MimeUtil.GetMultiPart(mimeFile + "1.mjm");
         bp = multiparsed[0];
         Assert.IsTrue(bp.ContentId.Length > 5, "cid >cid_");

         JDFDoc jDoc2 = new JDFDoc("JDF");
         jDoc2.setOriginalFileName("jdf1.jdf");
         jDoc2.getJDFRoot().setDescriptiveName("updated jdf");
         MimeUtil.updateXMLMultipart(multipart, jDoc2, "jdf1.jdf");
         MimeUtil.writeToFile(multipart, mimeFile + "2.mjm", null);

         AttachmentCollection multipart3 = MimeUtil.GetMultiPart(mimeFile + "2.mjm");
         jDoc2.getJDFRoot().setDescriptiveName("3rd jdf");
         MimeUtil.updateXMLMultipart(multipart3, jDoc2, "jdf2.jdf");
         MimeUtil.writeToFile(multipart3, mimeFile + "3.mjm", null);
      }


      [TestMethod]
      public virtual void testReplaceContents()
      {
         JDFDoc doc = new JDFDoc("JDF");
         doc.setOriginalFileName("JDF.jdf");
         JDFNode n = doc.getJDFRoot();
         n.setType(EnumType.ColorSpaceConversion);
         JDFColorSpaceConversionParams cscp = (JDFColorSpaceConversionParams)n.addResource(ElementName.COLORSPACECONVERSIONPARAMS, null, EnumUsage.Input, null, null, null, null);
         JDFFileSpec fs0 = cscp.appendFinalTargetDevice();
         fs0.setURL(StringUtil.uncToUrl(sm_dirTestData + "test.icc", true));
         AttachmentCollection mp = MimeUtil.buildMimePackage(null, doc, true);
         Assert.AreEqual(2, mp.Count, "JDF,  1 icc");

         Attachment bp = mp[1];
         Assert.IsNotNull(bp);
         MimeUtil.SetAttachmentContent(bp, "hello World");

         Attachment bp2 = mp[1];
         Assert.AreEqual("hello World", MimeUtil.GetAttachmentContent(bp2));

         string mimeFile = sm_dirTestDataTemp + "testReplaceContents";
         MimeUtil.writeToFile(mp, mimeFile + ".mjm", null);

         AttachmentCollection mp2 = MimeUtil.GetMultiPart(mimeFile + ".mjm");
         Attachment bp21 = mp2[1];
         Assert.AreEqual("hello World", MimeUtil.GetAttachmentContent(bp21));

         Attachment bp22 = mp2[1];
         Assert.IsNotNull(bp22);
         MimeUtil.SetAttachmentContent(bp22, "bye World");
         Assert.AreEqual("bye World", MimeUtil.GetAttachmentContent(bp22));
         Attachment bp23 = mp2[1];
         Assert.AreEqual(bp22, bp23);

         MimeUtil.writeToFile(mp2, mimeFile + "_1.mjm", null);
         AttachmentCollection mp3 = MimeUtil.GetMultiPart(mimeFile + "_1.mjm");
         Attachment bp31 = mp3[1];
         Assert.AreEqual("bye World", MimeUtil.GetAttachmentContent(bp31));
      }

      ///   
      ///	 <summary> * Tests that MimeUtil can resolve FileSpec URLs with relative URLs.
      ///	 * 
      ///	 * @author Claes Buckwalter </summary>
      ///	 
      [TestMethod]
      public virtual void testResolveRelativeUrls()
      {
         // Build MIME package
         string path = sm_dirTestData + "MISPrepress-ICS-Complex.jdf";
         JDFDoc jdfDoc = new JDFParser().parseFile(path);
         Assert.IsNotNull(jdfDoc, "Could not parse JDF: " + path);
         AttachmentCollection multipart = MimeUtil.buildMimePackage(null, jdfDoc, true);
         Assert.IsNotNull(multipart, "Could not build multipart");
         // Verify contents
         Assert.AreEqual(3, multipart.Count);
         JDFDoc jdfDoc2 = MimeUtil.getJDFDoc(multipart[0]);
         Assert.IsNotNull(jdfDoc2);
         JDFNode jdf = jdfDoc2.getJDFRoot();
         Assert.IsNotNull(jdf);
         VElement fileSpecs = jdf.getChildrenByTagName(ElementName.FILESPEC, null, new JDFAttributeMap(AttributeName.URL, "*"), false, false, 0);
         Assert.AreEqual(3, fileSpecs.Count);
         for (IEnumerator i = fileSpecs.GetEnumerator(); i.MoveNext(); )
         {
            JDFFileSpec fileSpec = (JDFFileSpec)i.Current;
            string cid = fileSpec.getURL();
            Assert.IsTrue(cid.StartsWith("cid:"));
            Assert.IsNotNull(MimeUtil.GetPartByCID(multipart, cid));
         }
      }


      [TestMethod]
      public virtual void testBuildMimePackage()
      {
         JDFDoc d1 = new JDFDoc("JMF");
         d1.setOriginalFileName("JMF.jmf");
         JDFDoc d2 = new JDFDoc("JDF");
         d2.setOriginalFileName("JDF.jdf");
         ArrayList vXMLDocs = new ArrayList();
         vXMLDocs.Add(d1);
         vXMLDocs.Add(d2);

         AttachmentCollection m = MimeUtil.buildMimePackage(vXMLDocs);
         FileInfo file = MimeUtil.writeToFile(m, sm_dirTestDataTemp + "test.mjm", null);

         AttachmentCollection aBp = MimeUtil.GetMultiPart(file.FullName);
         Assert.AreEqual(2, aBp.Count);

         Assert.AreEqual("JMF.jmf", aBp[0].Name);
         Assert.AreEqual("JDF.jdf", aBp[1].Name);
      }


      [TestMethod]
      public virtual void testWriteToDir()
      {
         testBuildMimePackageDocJMF();

         AttachmentCollection mp = MimeUtil.GetMultiPart(sm_dirTestDataTemp + "testMimePackageDoc.mjm");
         DirectoryInfo directory = new DirectoryInfo(sm_dirTestDataTemp + "TestWriteMime");
         if (directory.Exists)
            directory.Delete();
         MimeUtil.WriteToDir(mp, directory);
         Assert.IsTrue(new FileInfo(sm_dirTestDataTemp + "TestWriteMime/" + "test.icc").Exists);
      }


      [TestMethod]
      public virtual void testWriteToFile()
      {
         testBuildMimePackageDocJMF();

         AttachmentCollection mp = MimeUtil.GetMultiPart(sm_dirTestDataTemp + "testMimePackageDoc.mjm");
         MimeUtil.writeToFile(mp, sm_dirTestDataTemp + "testMimePackageDoc2.mjm", null);
         FileInfo f1 = new FileInfo(sm_dirTestDataTemp + "testMimePackageDoc2.mjm");
         FileInfo f2 = new FileInfo(sm_dirTestDataTemp + "testMimePackageDoc.mjm");
         Assert.IsTrue(f1.Exists);
         Assert.AreEqual(f1.Length, f2.Length, 100);
         AttachmentCollection mp2 = MimeUtil.GetMultiPart(sm_dirTestDataTemp + "testMimePackageDoc2.mjm");
         Assert.IsNotNull(mp2);
         Assert.AreEqual(mp.Count, mp2.Count);
      }


      [TestMethod]
      public virtual void testWriteToFileMimeDetails()
      {
         testBuildMimePackageDocJMF();

         MIMEDetails md = new MIMEDetails();
         md.modifyBoundarySemicolon = true;
         AttachmentCollection mp = MimeUtil.GetMultiPart(sm_dirTestDataTemp + "testMimePackageDoc.mjm");
         MimeUtil.writeToFile(mp, sm_dirTestDataTemp + "testMimePackageDoc2.mjm", md);
         FileInfo f2 = new FileInfo(sm_dirTestDataTemp + "testMimePackageDoc2.mjm");
         FileInfo f1 = new FileInfo(sm_dirTestDataTemp + "testMimePackageDoc.mjm");
         Assert.IsTrue(f2.Exists);
         Assert.AreEqual(f1.Length, f2.Length, 100);
         AttachmentCollection mp2 = MimeUtil.GetMultiPart(sm_dirTestDataTemp + "testMimePackageDoc2.mjm");
         Assert.IsNotNull(mp2);
         Assert.AreEqual(mp.Count, mp2.Count);
         MemoryStream sw = new MemoryStream();
         IOUtils.CopyStream(new FileStream(f2.FullName, FileMode.Open), sw);
         Assert.AreEqual(-1, sw.ToString().IndexOf("related;"));
      }


      [TestMethod]
      public virtual void testWriteToURLFile()
      {
         testBuildMimePackageDocJMF();

         AttachmentCollection mp = MimeUtil.GetMultiPart(sm_dirTestDataTemp + "testMimePackageDoc.mjm");
         FileInfo f1 = new FileInfo(sm_dirTestDataTemp + "testMimePackageDoc3.mjm");
         MimeUtil.writeToURL(mp, UrlUtil.fileToUrl(f1, false));
         FileInfo f2 = new FileInfo(sm_dirTestDataTemp + "testMimePackageDoc.mjm");
         Assert.IsTrue(f1.Exists);
         Assert.AreEqual(f1.Length, f2.Length, 100);
      }


      [TestMethod]
      public virtual void testPerformance()
      {
         testWritePerformance();

         long write = JDFDate.ToMillisecs(DateTime.Now);
         AttachmentCollection mp = MimeUtil.GetMultiPart(sm_dirTestDataTemp + "performance.mjm");
         long getMP = JDFDate.ToMillisecs(DateTime.Now);
         Console.WriteLine("get multipart time: " + (getMP - write));
         Attachment bp = MimeUtil.GetPartByCID(mp, "bigger.pdf");
         long getCID = JDFDate.ToMillisecs(DateTime.Now);
         Console.WriteLine("get big time: " + (getCID - getMP));
         Assert.IsNotNull(bp);
         Assert.AreEqual("bigger.pdf", bp.Name);
         FileInfo outFile = FileUtil.streamToFile(bp.ContentStream, sm_dirTestDataTemp + "performance.pdf");
         Assert.IsNotNull(outFile);
         //      
         //		 * InputStream is=bp.getInputStream(); byte[] b=new byte[1000]; int l=0;
         //		 * while (true) { int i=is.read(b); if(i<=0) break; l+=i; }
         //		 
         long extract = JDFDate.ToMillisecs(DateTime.Now);
         //System.out.println("extracted "+l+" bytes in time: "+(extract-getCID))
         // ;
         Console.WriteLine("extracted  bytes in time: " + (extract - getCID));
      }


      [TestMethod]
      public virtual void testPerformanceGet()
      {
         long write = JDFDate.ToMillisecs(DateTime.Now);
         AttachmentCollection mp = MimeUtil.GetMultiPart(sm_dirTestDataTemp + "performance.mjm");
         long getMP = JDFDate.ToMillisecs(DateTime.Now);
         Console.WriteLine("get multipart time: " + (getMP - write));
         Attachment bp = MimeUtil.GetPartByCID(mp, "bigger.pdf");
         long getCID = JDFDate.ToMillisecs(DateTime.Now);
         Console.WriteLine("get big time: " + (getCID - getMP));
         Assert.IsNotNull(bp);
         Assert.AreEqual("bigger.pdf", bp.Name);
      }


      [TestMethod]
      public virtual void testURLPerformance()
      {
         // testWritePerformance();
         try
         {
            long write = JDFDate.ToMillisecs(DateTime.Now);
            AttachmentCollection mp = MimeUtil.GetMultiPart(sm_dirTestDataTemp + "performance.mjm");
            long getMP = JDFDate.ToMillisecs(DateTime.Now);
            Console.WriteLine("get multipart time: " + (getMP - write));
            Attachment bp = MimeUtil.GetPartByCID(mp, "bigger.pdf");
            long getCID = JDFDate.ToMillisecs(DateTime.Now);
            Console.WriteLine("get big time: " + (getCID - getMP));
            Assert.IsNotNull(bp);
            Assert.AreEqual("bigger.pdf", bp.Name);
            HttpWebRequest uc = MimeUtil.writeToURL(mp, "http://localhost:8080/JDFUtility/dump");
            Stream @is = uc.GetRequestStream();
            IOUtils.CopyStream(@is, System.Console.OpenStandardOutput());
            @is.Close();
            Console.WriteLine();
            // System.out.println("extracted "+l+" bytes in time: "+(extract-
            // getCID));
            long extract = JDFDate.ToMillisecs(DateTime.Now);
            Console.WriteLine("sent  bytes in time: " + (extract - getCID));
         }
         catch (Exception)
         {
            // nop
         }
      }


      [TestMethod]
      public virtual void testWritePerformance()
      {
         long start = JDFDate.ToMillisecs(DateTime.Now);
         string big = sm_dirTestData + "big.pdf";
         string bigger = sm_dirTestDataTemp + "bigger.pdf";
         JDFDoc docJMF = new JDFDoc("JMF");
         docJMF.setOriginalFileName("JMF.jmf");
         JDFJMF jmf = docJMF.getJMFRoot();
         JDFCommand com = (JDFCommand)jmf.appendMessageElement(JDFMessage.EnumFamily.Command, JDFMessage.EnumType.SubmitQueueEntry);
         com.appendQueueSubmissionParams().setURL("TheJDF");
         FileInfo fBigger = new FileInfo(bigger);
         SupportClass.FileSupport.CreateNewFile(fBigger);
         FileStream fis = new FileStream(big, FileMode.Open);
         FileStream fos = new FileStream(bigger, FileMode.Create);
         byte[] b = new byte[10000];
         while (true)
         {
            int i = fis.Read(b, 0, 10000);
            if (i <= 0)
               break;
            for (int j = 0; j < 3; j++)
               fos.Write(b, 0, i);
         }
         fis.Close();
         fos.Flush();
         fos.Close();

         JDFDoc doc = new JDFDoc("JDF");
         doc.setOriginalFileName("JDF.jdf");
         JDFNode n = doc.getJDFRoot();
         n.setType(EnumType.Interpreting);
         JDFRunList rl = (JDFRunList)n.addResource(ElementName.RUNLIST, EnumUsage.Input);
         rl.addPDF(StringUtil.uncToUrl(bigger, false), 0, -1);
         long setup = JDFDate.ToMillisecs(DateTime.Now);
         Console.WriteLine("Setup time: " + (setup - start));
         AttachmentCollection m = MimeUtil.buildMimePackage(null, doc, true);
         long build = JDFDate.ToMillisecs(DateTime.Now);
         Console.WriteLine("Build time: " + (build - setup));
         Assert.IsNotNull(MimeUtil.writeToFile(m, sm_dirTestDataTemp + "performance.mjm", null));
         long write = JDFDate.ToMillisecs(DateTime.Now);
         Console.WriteLine("Write time: " + (write - build));
      }
   }
}
