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
 * JDFFilespecTest.java
 * @author Dietrich Mucha
 * Copyright (C) 2004 Heidelberger Druckmaschinen AG. All Rights Reserved.
 */

namespace org.cip4.jdflib.resource
{
   using System.IO;
   using System.Collections;
   using System.Net.Mail;
   using Microsoft.VisualStudio.TestTools.UnitTesting;

   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using JDFFileSpec = org.cip4.jdflib.resource.process.JDFFileSpec;
   using JDFColorSpaceConversionParams = org.cip4.jdflib.resource.process.prepress.JDFColorSpaceConversionParams;
   using MimeUtil = org.cip4.jdflib.util.MimeUtil;
   using MimeUtilTest = org.cip4.jdflib.util.MimeUtilTest;


   [TestClass]
   public class JDFFilespecTest : JDFTestCaseBase
   {
      [TestMethod]
      public virtual void testSetAbsoluteURL()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode n = doc.getJDFRoot();
         JDFFileSpec fs = (JDFFileSpec)n.addResource("FileSpec", null, EnumUsage.Input, null, null, null, null);
         JDFFileSpec fs2 = (JDFFileSpec)n.addResource("FileSpec", null, EnumUsage.Input, null, null, null, null);
         fs.setAbsoluteFileURL(new FileInfo("C:\\ist bl�d\\fnord is �"), false);
         fs2.setAbsoluteFileURL(new FileInfo("C:\\ist bl�d\\fnord is �"), true);
         Assert.AreEqual("file:///C:/ist%20bl�d/fnord%20is%20�", fs.getURL());
         Assert.AreEqual("file:///C:/ist%20bl%c3%b6d/fnord%20is%20%e2%82%ac", fs2.getURL());
      }


      [TestMethod]
      public virtual void testGetURLCidStream()
      {
         new MimeUtilTest().testBuildMimePackageDocJMF();
         AttachmentCollection mp = MimeUtil.GetMultiPart(sm_dirTestDataTemp + "testMimePackageDoc.mjm");
         Attachment bp = MimeUtil.GetPartByCID(mp, "jdf.JDF");
         JDFDoc d = MimeUtil.getJDFDoc(bp);
         JDFNode n = d.getJDFRoot();
         JDFColorSpaceConversionParams cscp = (JDFColorSpaceConversionParams)n.getMatchingResource(ElementName.COLORSPACECONVERSIONPARAMS, null, null, 0);
         Assert.IsNotNull(cscp);
         JDFFileSpec fs = cscp.getFinalTargetDevice();
         Stream @is = fs.getURLInputStream();
         Assert.IsNotNull(@is);
         byte[] b = new byte[100];
         int i = @is.Read(b, 0, 100);
         Assert.IsTrue(i > 0);
         string s = System.Text.Encoding.Default.GetString(b);
         Assert.IsTrue(s.IndexOf("I C C") >= 0);
      }


      [TestMethod]
      public virtual void testGetMimeTypeFromURL()
      {
         Assert.IsNull(JDFFileSpec.getMimeTypeFromURL(null));
         Assert.IsNull(JDFFileSpec.getMimeTypeFromURL("burp"));
         Assert.AreEqual("application/pdf", JDFFileSpec.getMimeTypeFromURL("file://a/b/./testtif.foo.PDF"));
         Assert.AreEqual("image/tiff", JDFFileSpec.getMimeTypeFromURL("http://a/b/./testtif.foo.tiff"));
      }


      [TestMethod]
      public virtual void testSetMimeURL()
      {
         JDFDoc d = new JDFDoc("FileSpec");
         JDFFileSpec fs = (JDFFileSpec)d.getRoot();
         fs.setMimeURL("file:/c/test.pdf");
         Assert.AreEqual("application/pdf", fs.getMimeType());
         Assert.AreEqual("file:/c/test.pdf", fs.getURL());
      }
   }
}
