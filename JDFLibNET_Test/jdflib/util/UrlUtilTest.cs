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
 * 04022005 VF initial version
 * 
 *
 * Created on Aug 26, 2004
 */

namespace org.cip4.jdflib.util
{
   using System;
   using System.IO;
   using System.Text;
   using Microsoft.VisualStudio.TestTools.UnitTesting;


   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFParser = org.cip4.jdflib.core.JDFParser;
   using KElement = org.cip4.jdflib.core.KElement;
   using XMLDoc = org.cip4.jdflib.core.XMLDoc;

   [TestClass]
   public class UrlUtilTest : JDFTestCaseBase
   {

      [TestMethod]
      public virtual void testGetLocalURL()
      {
         Assert.IsNull(UrlUtil.getLocalURL("foo", "foo"));
         Assert.IsNull(UrlUtil.getLocalURL("foo", null));
         Assert.AreEqual("bar", UrlUtil.getLocalURL("foo", "foo/bar"));
         Assert.AreEqual("bar", UrlUtil.getLocalURL("foo/", "foo/bar"));
         Assert.AreEqual("foo/bar", UrlUtil.getLocalURL(null, "foo/bar"));
         Assert.AreEqual("foo/bar", UrlUtil.getLocalURL("", "foo/bar"));
      }


      [TestMethod]
      public virtual void testWriteToURL()
      {
         // Assert.IsNotNull(UrlUtil.writeToURL("http://www.example.com", null,
         // UrlUtil.GET, UrlUtil.TEXT_PLAIN, null));
      }


      [TestMethod]
      public virtual void testIsCid()
      {
         Assert.IsTrue(UrlUtil.isCID("cid:foo"));
         Assert.IsTrue(UrlUtil.isCID("<cid:foo>"));
         Assert.IsTrue(UrlUtil.isCID("<cid:"));
         Assert.IsFalse(UrlUtil.isCID(null));
         Assert.IsFalse(UrlUtil.isCID("<"));
      }


      [TestMethod]
      public virtual void testIsHTTP()
      {
         Assert.IsTrue(UrlUtil.isHttp("http://foo.bar.com"));
         Assert.IsFalse(UrlUtil.isHttp(null));
         Assert.IsFalse(UrlUtil.isHttp("foo.bar.com"));
      }


      [TestMethod]
      public virtual void testIsIRL()
      {
         Assert.IsTrue(UrlUtil.isIRL("file://blöd€.txt"));
         Assert.IsTrue(UrlUtil.isIRL("http://foo.com/blöd€.txt"));
         Assert.IsFalse(UrlUtil.isIRL("http:///blöd€.txt"), "3 ///");
         Assert.IsFalse(UrlUtil.isIRL("file://a blöd€.txt"), "blank is bad");
         Assert.IsTrue(UrlUtil.isIRL("file://a%20blöd€.txt"), "blank %20 is good");
         Assert.IsTrue(UrlUtil.isIRL("file:C:/a/b.txt"));
         Assert.IsTrue(UrlUtil.isIRL("./3€.txt"), "relative url");
         Assert.IsFalse(UrlUtil.isIRL("http://@"), "invalid char: @");
         Assert.IsTrue(UrlUtil.isIRL("HTTP://€/€"));
         Assert.IsTrue(UrlUtil.isIRL("file:///C:/Documents%20and%20Settings/Israel/My%20Documents/Vio%20Production/Results/TIME_H8789/TIME_H8789.pdf"));
      }


      [TestMethod]
      public virtual void testIsURL()
      {
         Assert.IsTrue(UrlUtil.isURL("file://bl.txt"));
         Assert.IsTrue(UrlUtil.isURL("http://foo.com/bl.txt"));
         Assert.IsFalse(UrlUtil.isURL("http:///bl.txt"), "3 ///");
         Assert.IsFalse(UrlUtil.isURL("file://a b.txt"), "blank is bad");
         Assert.IsTrue(UrlUtil.isURL("file://a%20bl.txt"), "blank %20 is good");
         Assert.IsTrue(UrlUtil.isURL("file:C:/a/b.txt"));
         Assert.IsTrue(UrlUtil.isURL("./3.txt"), "relative url");
         Assert.IsFalse(UrlUtil.isURL("http://@"), "invalid char: @");
         Assert.IsTrue(UrlUtil.isURL("HTTP://a/b?c"));
      }


      [TestMethod]
      public virtual void testStringToURL()
      {
         // test for an existing directory (a trailing slash is appended by
         // StringToURL)
         Assert.IsTrue(UrlUtil.StringToURL("c:\\temp\\").AbsolutePath.StartsWith(new Uri("File:/c:/temp").AbsolutePath));
         Assert.IsTrue(UrlUtil.StringToURL("File:/c:/temp/").AbsolutePath.StartsWith(new Uri("File:/c:/temp").AbsolutePath));
         Assert.IsTrue(UrlUtil.StringToURL("c:\\temp").AbsolutePath.StartsWith(new Uri("File:/c:/temp").AbsolutePath));
         Assert.IsTrue(UrlUtil.StringToURL("File:/c:/temp").AbsolutePath.StartsWith(new Uri("File:/c:/temp").AbsolutePath));

         // test for a file or a non existing object (trailing slash is
         // removed by StringToURL)
         Assert.AreEqual(UrlUtil.StringToURL("File:/c:/blöd .pdf"), new Uri(UrlUtil.fileToUrl(new FileInfo("c:/blöd .pdf"), true)));
         Assert.AreEqual(UrlUtil.StringToURL("c:\\xyz\\").AbsolutePath, new Uri("File:/c:/xyz").AbsolutePath);
         Assert.AreEqual(UrlUtil.StringToURL("File:/c:/xyz/").AbsolutePath, new Uri("File:/c:/xyz").AbsolutePath);
         Assert.AreEqual(UrlUtil.StringToURL("c:\\xyz").AbsolutePath, new Uri("File:/c:/xyz").AbsolutePath);
         Assert.AreEqual(UrlUtil.StringToURL("File:/c:/xyz").AbsolutePath, new Uri("File:/c:/xyz").AbsolutePath);

         Assert.AreEqual(UrlUtil.StringToURL("http://foo"), new Uri("http://foo"));
         Assert.AreEqual(UrlUtil.StringToURL("http%3A%2F%2FDRU-CIP4HD1%3A6331"), new Uri("http://DRU-CIP4HD1:6331"));
      }


      [TestMethod]
      public virtual void testIsEscaped()
      {
         Assert.IsTrue(UrlUtil.isEscaped("http%3A%2F%2FDRU-CIP4HD1%3A6331"));
         Assert.IsFalse(UrlUtil.isEscaped("file:http%3A%2F%2FDRU-CIP4HD1%3A6331"));
         Assert.IsFalse(UrlUtil.isEscaped("text%20a.pdf"));
      }


      [TestMethod]
      public virtual void testFileToURL()
      {
         FileInfo f = new FileInfo("C:\\IO.SYS");
         string s = UrlUtil.fileToUrl(f, false);
         Assert.AreEqual("file:///C:/IO.SYS", s);
         s = UrlUtil.fileToUrl(new FileInfo("\\\\fooBar\\4€.txt"), true);
         Assert.AreEqual("file://fooBar/4%e2%82%ac.txt", s);
         s = UrlUtil.fileToUrl(new FileInfo("\\\\fooBar\\4€.txt"), false);
         Assert.AreEqual("file://fooBar/4€.txt", s);
      }


      [TestMethod]
      public virtual void testNonAsciiFileURL()
      {
         for (int i = 0; i < 2; i++) // loop over escape and non-escape
         {
            FileInfo f = new FileInfo("4€5%äö.txt");
            FileInfo f2 = FileUtil.getFileInDirectory(new DirectoryInfo(sm_dirTestDataTemp), f);
            f2.Delete();
            f2.Create();
            Assert.IsTrue(f2.Exists);
            string url = UrlUtil.fileToUrl(f2, i == 0);
            XMLDoc doc = new XMLDoc("URL", null);
            KElement root = doc.getRoot();
            root.setAttribute("url", url);
            doc.write2File(sm_dirTestDataTemp + "url.xml", 2, false);
            JDFParser p = new JDFParser();
            p.bKElementOnly = true;
            JDFDoc d = p.parseFile(sm_dirTestDataTemp + "url.xml");
            KElement root2 = d.getRoot();
            string urlParse = root2.getAttribute("url");
            Assert.AreEqual(url, urlParse);
            FileInfo f3 = UrlUtil.urlToFile(urlParse);
            Assert.AreEqual(f2.FullName, f3.FullName);
            Assert.IsTrue(f3.Exists);
         }
      }


      [TestMethod]
      public virtual void testURLToFile()
      {
         for (int i = 0; i < 2; i++)
         {
            // Java to C# Conversion - TODO: figure out if isDirectory() make any sense in this context
            FileInfo f = UrlUtil.urlToFile(".");
            //Assert.IsTrue(f.isDirectory());
            FileInfo f2 = UrlUtil.urlToFile(UrlUtil.fileToUrl(f, i == 0));
            //Assert.IsTrue(f2.isDirectory());
            Assert.AreEqual(f2.FullName, f.FullName);

            f = new FileInfo(".\\simple.pdf");
            f2 = UrlUtil.urlToFile(UrlUtil.fileToUrl(f, i == 0));
            Assert.AreEqual(f.FullName, f2.FullName, "asccii");

            f = new FileInfo("blöd .pdf");
            f2 = UrlUtil.urlToFile(UrlUtil.fileToUrl(f, i == 0));
            Assert.AreEqual(f.FullName, f2.FullName, "non asccii");

            f = new FileInfo("bl%öd .pdf");
            f2 = UrlUtil.urlToFile(UrlUtil.fileToUrl(f, i == 0));
            Assert.AreEqual(f.FullName, f2.FullName, "non asccii");

            f = new FileInfo("blöd ist es 10@%€.pdf");
            string fileToUrl = UrlUtil.fileToUrl(f, i == 0);
            f2 = UrlUtil.urlToFile(fileToUrl);
            Assert.AreEqual(f.FullName, f2.FullName, "escape %20");

         }
         FileInfo fi1 = new FileInfo("\\\\fooBar\\4ü€.txt");
         FileInfo fi = UrlUtil.urlToFile("file://fooBar/4ü%e2%82%ac.txt");
         Assert.AreEqual(fi.FullName, fi1.FullName, "escape %20");
      }


      [TestMethod]
      public virtual void testisUNC()
      {
         Assert.IsTrue(UrlUtil.isUNC("\\\\foo\\bar"));
         Assert.IsFalse(UrlUtil.isUNC("c/d/e.f"));
         Assert.IsFalse(UrlUtil.isUNC("/c/d/e.f"));
      }


      [TestMethod]
      public virtual void testGetRelativeURI()
      {
         FileInfo f = new FileInfo("./a b");
         Assert.AreEqual("./a%20b", StringUtil.replaceChar(UrlUtil.getRelativeURL(f, null, true), '\\', "/", 0));
         f = new FileInfo("../a.ä");
         Assert.AreEqual("../a.%c3%a4", StringUtil.replaceChar(UrlUtil.getRelativeURL(f, null, true), '\\', "/", 0), "escaped utf8");
         Assert.AreEqual(Encoding.UTF8.GetString(SupportClass.ToByteArray((StringUtil.setUTF8String("../a.ä")))), StringUtil.replaceChar(UrlUtil.getRelativeURL(f, null, false), '\\', "/", 0), "unescaped but utf8");
      }


      [TestMethod]
      public virtual void testGetRelativeURL()
      {
         FileInfo file = new FileInfo("c:\\a\\b\\c.txt");
         FileInfo cwd = new FileInfo("c:\\a\\b1");
         Assert.AreEqual("../b/c.txt", UrlUtil.getRelativeURL(file, cwd, true));
         file = new FileInfo("c:\\a\\b1\\c.txt");
         Assert.AreEqual("./c.txt", UrlUtil.getRelativeURL(file, cwd, true));
         file = new FileInfo("a\\..\\b\\c.txt");
         Assert.AreEqual("./b/c.txt", UrlUtil.getRelativeURL(file, null, true));
         file = cwd;
         Assert.AreEqual(".", UrlUtil.getRelativeURL(file, cwd, true));
      }


      [TestMethod]
      public virtual void testGetURLWithDirectory()
      {
         string url = "File://a.b";
         Assert.AreEqual(url, UrlUtil.getURLWithDirectory(null, url), "test nulls");
         Assert.AreEqual(url, UrlUtil.getURLWithDirectory("", url), "test nulls");
         Assert.AreEqual(url, UrlUtil.getURLWithDirectory("File:/dir", url), "test nulls");

         url = "a.b";
         Assert.AreEqual("File://dir/a.b", UrlUtil.getURLWithDirectory("File://dir/", url), "relative url");
         Assert.AreEqual("File://dir/a.b", UrlUtil.getURLWithDirectory("File://dir", url), "relative url");

         url = "/a.b";
         Assert.AreEqual("File://a.b", UrlUtil.getURLWithDirectory("File://dir/", url), "absolute url no host");
         Assert.AreEqual("File://a.b", UrlUtil.getURLWithDirectory("File://dir", url), "absolute url no host");

         url = "/a.b:c";
         Assert.AreEqual("File://a.b:c", UrlUtil.getURLWithDirectory("File://dir/", url), "absolute url no host - colon");
         Assert.AreEqual("File://a.b:c", UrlUtil.getURLWithDirectory("File://dir", url), "absolute url no host - colon");

         url = "//a.b";
         Assert.AreEqual("File://a.b", UrlUtil.getURLWithDirectory("File://dir/", url), "absolute url with default host");
         Assert.AreEqual("File://a.b", UrlUtil.getURLWithDirectory("File://dir", url), "absolute url with default host");

         url = "ftp://a.b";
         Assert.AreEqual("ftp://a.b", UrlUtil.getURLWithDirectory("File://dir/", url), "absolute url with default host");
         url = "http://a.b";
         Assert.AreEqual("http://a.b", UrlUtil.getURLWithDirectory("File://dir/", url), "absolute url with default host");

         url = "//boo/a.b";
         Assert.AreEqual("File://boo/a.b", UrlUtil.getURLWithDirectory("File://dir/", url), "absolute url with new host");
         Assert.AreEqual("File://boo/a.b", UrlUtil.getURLWithDirectory("File://dir", url), "absolute url with new host");

         url = "//boo/./gg/../a.b";
         Assert.AreEqual("File://boo/a.b", UrlUtil.getURLWithDirectory("File://dir/", url), "absolute url with new host and cleandots");
         Assert.AreEqual("File://boo/a.b", UrlUtil.getURLWithDirectory("File://dir", url), "absolute url with new host and cleandots");
      }


      [TestMethod]
      public virtual void testRemoveExtension()
      {
         Assert.AreEqual("a", UrlUtil.removeExtension("a.b"));
         Assert.AreEqual("a", UrlUtil.removeExtension("a"));
         Assert.AreEqual("a", UrlUtil.removeExtension("a."));
         Assert.AreEqual("a.b", UrlUtil.removeExtension("a.b.c"));
         Assert.AreEqual("", UrlUtil.removeExtension("."));
      }


      [TestMethod]
      public virtual void testCleanDots()
      {
         Assert.AreEqual(".", UrlUtil.cleanDots("."));
         Assert.AreEqual("..", UrlUtil.cleanDots(".."));
         Assert.AreEqual(".", UrlUtil.cleanDots("a/.."));
         Assert.AreEqual("../../c.pdf", UrlUtil.cleanDots("../../c.pdf"));
         Assert.AreEqual("../../c.pdf", UrlUtil.cleanDots(".././../c.pdf"));
         Assert.AreEqual("File://b", UrlUtil.cleanDots("File://a/../b"));
         Assert.AreEqual("File://b.pdf", UrlUtil.cleanDots("File://a/.././c/../b.pdf"));
         Assert.AreEqual("/.", UrlUtil.cleanDots("/."));
      }
   }
}
