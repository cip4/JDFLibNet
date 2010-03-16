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
   using System.Collections;
   using Microsoft.VisualStudio.TestTools.UnitTesting;


   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using VString = org.cip4.jdflib.core.VString;
   using EnumOrientation = org.cip4.jdflib.core.JDFElement.EnumOrientation;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using JDFBaseDataTypes_Fields = org.cip4.jdflib.datatypes.JDFBaseDataTypes_Fields;
   using EnumType = org.cip4.jdflib.jmf.JDFMessage.EnumType;

///
/// <summary> * @author MatternK
/// * 
/// *         To change the template for this generated type comment go to Window -
/// *         Preferences - Java - Code Generation - Code and Comments </summary>
/// 
   [TestClass]
   public class StringUtilTest : JDFTestCaseBase
   {
      [TestMethod]
      public virtual void testWipeInvalidXML10Chars()
      {
         char[] cs = new char[] { 'a', (char)0x7, (char)0x3, 'b', (char)0x5 };
         Assert.AreEqual(StringUtil.wipeInvalidXML10Chars(new string(cs), null), "ab");
         Assert.AreEqual(StringUtil.wipeInvalidXML10Chars(new string(cs), "_"), "a__b_");
         Assert.AreEqual(StringUtil.wipeInvalidXML10Chars("abc", null), "abc");
      }


      [TestMethod]
      public virtual void testGetRelativePath()
      {
         FileInfo f = new FileInfo("./a");
         Assert.AreEqual("./a", StringUtil.replaceChar(UrlUtil.getRelativePath(f, null), '\\', "/", 0));
         f = new FileInfo("../a.b");
         Assert.AreEqual("../a.b", StringUtil.replaceChar(UrlUtil.getRelativePath(f, null), '\\', "/", 0));
         f = new FileInfo("./../a b/b");
         Assert.AreEqual("../a b/b", StringUtil.replaceChar(UrlUtil.getRelativePath(f, null), '\\', "/", 0));
         f = new FileInfo("a/b/c");
         Assert.AreEqual("./a/b/c", StringUtil.replaceChar(UrlUtil.getRelativePath(f, null), '\\', "/", 0));
         f = new FileInfo("a/b/c");
         Assert.AreEqual(".", StringUtil.replaceChar(UrlUtil.getRelativePath(f, f), '\\', "/", 0));
      }

///   
///	 <summary> * test for getDefaultNull </summary>
///	 * <exception cref="Exception"> </exception>
///	 
      [TestMethod]
      public virtual void testGetDefaultNull()
      {
         Assert.IsNull(StringUtil.getDefaultNull("", ""));
         Assert.IsNull(StringUtil.getDefaultNull(null, ""));
         Assert.AreEqual("a", StringUtil.getDefaultNull("a", ""));
      }

///   
///	 <summary> * test for getNonEmpty </summary>
///	 * <exception cref="Exception"> </exception>
///	 
      [TestMethod]
      public virtual void testGetNonEmpty()
      {
         Assert.IsNull(StringUtil.getNonEmpty(""));
         Assert.IsNull(StringUtil.getNonEmpty(null));
         Assert.AreEqual("a", StringUtil.getNonEmpty("a"));
      }

///   
///	 <summary> * test for gerRandomString </summary>
///	 
      [TestMethod]
      public virtual void testGetRandomString()
      {
         VString v = new VString();
         for (int i = 0; i < 1000; i++)
         {
            string s = StringUtil.getRandomString();
            if (i % 100 == 0)
               Console.WriteLine(s);
            v.appendUnique(s);
            Assert.IsTrue(s.Length > 1);
         }
         Assert.IsTrue(v.Count < 100, "should be many different");
         Assert.IsTrue(v.Count > 5);
      }


      [TestMethod]
      public virtual void testSprintfString()
      {
         Assert.AreEqual("abc005def", StringUtil.sprintf("abc%03idef", "5"));
         Assert.AreEqual("abc005def", StringUtil.sprintf("abc%03idef", "5.0"));
         Assert.AreEqual("abc00505def", StringUtil.sprintf("abc%03i%02idef", "5.0,5"));
         Assert.AreEqual("abc00505def%abcdefghi", StringUtil.sprintf("abc%03i%02idef%%%s", "5.0,5,abcdefghi"));
         Assert.AreEqual(" c", StringUtil.sprintf("%2x", "12"));
         Assert.AreEqual("12", StringUtil.sprintf("%2x", "18"));
         Assert.AreEqual(",", StringUtil.sprintf("%s", "\\,"));
         Assert.AreEqual("\\,", StringUtil.sprintf("%s", "\\\\,"));
         Assert.AreEqual("\\,_a", StringUtil.sprintf("%s_%s", "\\\\,,a"));
      }


      [TestMethod]
      public virtual void testSprintf()
      {
         object[] o = new object[1];
         o[0] = 5;
         Assert.AreEqual("abc005def", StringUtil.sprintf("abc%03idef", o));
         o[0] = "foobar";
         Assert.AreEqual("abc foobardef", StringUtil.sprintf("abc%7sdef", o));
         Assert.AreEqual("abc foobar7def", StringUtil.sprintf("abc%7s7def", o));
         Assert.AreEqual(" foobardef", StringUtil.sprintf("%7sdef", o));
         Assert.AreEqual(" foobar", StringUtil.sprintf("%7s", o));
         Assert.AreEqual("%_ foobar", StringUtil.sprintf("%%_%7s", o));
         Assert.AreEqual("%", StringUtil.sprintf("%%", o));
         Assert.AreEqual("765", StringUtil.sprintf("765", o));
         try
         {
            StringUtil.sprintf("abc%7idef", o);
            Assert.Fail("foobar is an int?");
         }
         catch (Exception)
         {
         //
         }

         o = new object[] { 5, "foobar" };
         Assert.AreEqual("abc 05 foobardef", StringUtil.sprintf("abc %02i%7sdef", o));
         Assert.AreEqual("05 foobardef", StringUtil.sprintf("%02i%7sdef", o));
         o = new object[] { "5", "foobar" };
         Assert.AreEqual("abc 05 foobardef", StringUtil.sprintf("abc %02i%7sdef", o));
         Assert.AreEqual("05 foobardef", StringUtil.sprintf("%02i%7sdef", o));
      }


      [TestMethod]
      public virtual void testSetHexBinaryBytes()
      {
         string strTestString = "ABCDEFGHIJKLMNOPQESTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789ÖÄÜöäü€";
         byte[] buffer = Encoding.Default.GetBytes(strTestString);
         string strTemp = StringUtil.setHexBinaryBytes(buffer, -1);
         byte[] tempBuffer = StringUtil.getHexBinaryBytes(Encoding.Default.GetBytes(strTemp));
         string strResultString = Encoding.Default.GetString(tempBuffer);
         Assert.AreEqual(strTestString, strResultString, "Input and Outputstring are not equal");
      }


      [TestMethod]
      public virtual void testSetUTF8Bytes()
      {
      // String strTestString = "€";
         string strTestString = "ABCDEFGHIJKLMNOPQESTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789ÖÄÜöäü€";
         byte[] utf8Buf = StringUtil.setUTF8String(strTestString);
         string newString = StringUtil.getUTF8String(utf8Buf);
         byte[] utf8Buf2 = StringUtil.setUTF8String(newString);
         string strResultString = StringUtil.getUTF8String(utf8Buf2);
         Assert.AreEqual(utf8Buf.Length, utf8Buf2.Length, "Input and Output bytes are not equal");
         Assert.AreEqual(strTestString, newString, "Input and Output string are not equal");
         Assert.AreEqual(strTestString, strResultString, "Input and Output string are not equal");
      }


      [TestMethod]
      public virtual void testSetVStringEnum()
      {
         ArrayList v = new ArrayList();
         v.Add(EnumUsage.Input);
         v.Add(EnumUsage.Output);
         Assert.AreEqual("Input Output", StringUtil.setvString(v, " ", null, null));
      }


      [TestMethod]
      public virtual void testSetVString()
      {
         VString v = new VString();
         v.Add("1");
         v.Add("22");
         v.Add("333");
         v.Add("4444");
         string s = StringUtil.setvString(v);

         Assert.AreEqual("1 22 333 4444", s, "s");
         s = StringUtil.setvString(v, "", "", "");
         Assert.AreEqual("1223334444", s, "s");
         s = StringUtil.setvString(v, null, null, null);
         Assert.AreEqual("1223334444", s, "s");

         string[] a = new string[v.Count];
         a = v.ToArray();
         s = StringUtil.setvString(a, " ", null, null);
         Assert.AreEqual("1 22 333 4444", s, "s");
      }


      [TestMethod]
      public virtual void testEscape()
      {
         string iri = "file://myHost/a/c%20äöü%25&?.txtß€";
         Assert.AreEqual(iri, StringUtil.unEscape(StringUtil.escape(iri, ":&?%", "%", 16, 2, 0x21, 127), "%", 16, 2), "escape round trip");
         Assert.AreEqual("%25_%e4", StringUtil.escape("%_ä", ":&?%", "%", 16, 2, 0x21, 127), "escape ");
         Assert.AreEqual("%e2%82%ac", StringUtil.escape(Encoding.Default.GetString(StringUtil.setUTF8String("€")), ":&?%", "%", 16, 2, 0x21, 127), "escape ");
         Assert.AreEqual("ß", StringUtil.escape("ß", null, "%", 16, 2, 0x21, -1));
         Assert.AreEqual("€", StringUtil.escape("€", null, "%", 16, 2, 0x21, -1));
         Assert.AreEqual("a_a", StringUtil.escape("aäa", null, "_", -1, 0, 0x21, 127));
         Assert.AreEqual("a__a", StringUtil.escape("aä_a", null, "_", -1, 0, 0x21, 127));
         Assert.AreEqual("a_äa", StringUtil.escape("aäa", null, "_", 0, 0, 0x21, 127));
      }


      [TestMethod]
      public virtual void testExtension()
      {
         string iri = "file://my.Host/a.n/c%20äöü%25&?.txtß";
         Assert.AreEqual("txtß", UrlUtil.extension(iri));
         Assert.IsNull(UrlUtil.extension("abc"));
      }

///   
///	 <summary> * test regexp matching utility
///	 *  </summary>
///	 
      [TestMethod]
      public virtual void testMatchesIgnoreCase()
      {
         Assert.IsFalse(StringUtil.matchesIgnoreCase(null, "(.+ )*(BB)( .+)*"));
         Assert.IsTrue(StringUtil.matchesIgnoreCase("a bb c", "(.+ )*(BB)( .+)*"));
         Assert.IsTrue(StringUtil.matchesIgnoreCase("mailTo:a@b.c", JDFConstants.REGEXP_EMAIL));
         Assert.IsFalse(StringUtil.matchesIgnoreCase("mailT:a@b.c", JDFConstants.REGEXP_EMAIL));
      }

///   
///	 <summary> * test regexp matching utility
///	 *  </summary>
///	 
      [TestMethod]
      public virtual void testStripPrefix()
      {
         Assert.AreEqual("b", StringUtil.stripPrefix("a:b", "a:", true));
         Assert.AreEqual("b", StringUtil.stripPrefix("a:b", "A:", true));
         Assert.AreEqual("a:b", StringUtil.stripPrefix("a:b", "A:", false));
         Assert.AreEqual("def", StringUtil.stripPrefix("abcdef", "ABC", true));
         Assert.IsNull(StringUtil.stripPrefix(null, "A:", false));
         Assert.AreEqual("a:b", StringUtil.stripPrefix("a:b", null, false));
      }


      [TestMethod]
      public virtual void testStripNot()
      {
         Assert.AreEqual("121", StringUtil.stripNot("a1b321", "12"));
         Assert.IsNull(StringUtil.stripNot("a1b321", null));
         Assert.IsNull(StringUtil.stripNot("a1b321", "7"));
      }

///   
///	 <summary> * test regexp matching utility
///	 *  </summary>
///	 
      [TestMethod]
      public virtual void testMatches()
      {
         Assert.IsFalse(StringUtil.matches(null, "(.+ )*(BB)( .+)*"));
         Assert.IsTrue(StringUtil.matches("a bb c", "(.+ )*(bb)( .+)*"));
         Assert.IsTrue(StringUtil.matches("b bb c", "(.* )*(bb)( .+)*"));
         Assert.IsTrue(StringUtil.matches("a bb", "(.+ )*(bb)( .+)*"));
         Assert.IsTrue(StringUtil.matches("bb", "(.+ )*(bb)( .+)*"));
         Assert.IsFalse(StringUtil.matches(" bb", "(.+ )*(bb)( .+)*"));
         Assert.IsFalse(StringUtil.matches("bb ", "(.+ )*(bb)( .+)*"));
         Assert.IsFalse(StringUtil.matches("a", "(.+ )*(bb)( .+)*"));
         Assert.IsFalse(StringUtil.matches("a c", "(.+ )*(bb)( .+)*"));
         Assert.IsFalse(StringUtil.matches("a b c", "(.+ )*(bb)( .+)*"));
         Assert.IsTrue(StringUtil.matches("abc", "*"));
         Assert.IsTrue(StringUtil.matches("abc", ".*"));
         Assert.IsTrue(StringUtil.matches("abc", ".+"));
         Assert.IsTrue(StringUtil.matches("abc", ""));
         Assert.IsTrue(StringUtil.matches("äbc", "..."));
         Assert.IsFalse(StringUtil.matches("äbc", "...."));
         Assert.IsTrue(StringUtil.matches("äbc", null));
         Assert.IsTrue(StringUtil.matches("ä", "ä?"));
         Assert.IsTrue(StringUtil.matches("ää", "ä{0,2}"));
         Assert.IsFalse(StringUtil.matches("äää", "ä{0,2}"));
         Assert.IsTrue(StringUtil.matches("", "ä?"));
         Assert.IsTrue(StringUtil.matches("12de", JDFConstants.REGEXP_HEXBINARY));
         Assert.IsFalse(StringUtil.matches("12d", JDFConstants.REGEXP_HEXBINARY));
         Assert.IsFalse(StringUtil.matches("12dk", JDFConstants.REGEXP_HEXBINARY));
         Assert.IsFalse(StringUtil.matches("ö", "ä?"));
         Assert.IsFalse(StringUtil.matches("abc", ".."));
         Assert.IsFalse(StringUtil.matches(null, null));
         Assert.IsFalse(StringUtil.matches("abc", "?"));
         Assert.IsTrue(StringUtil.matches("a b", "(a)?( b)?( c)?"));
         Assert.IsTrue(StringUtil.matches("a b", "a? b?"));
         Assert.IsTrue(StringUtil.matches("a b", "a?(( )*b)?"));
         Assert.IsTrue(StringUtil.matches("a", "a?(( )*b)?"));
         Assert.IsTrue(StringUtil.matches("b", "a?(( )*b)?"));
         Assert.IsTrue(StringUtil.matches("b a c", "((.+ )*((a)|(b))( .+)*)+"));
         Assert.IsTrue(StringUtil.matches("b a c", "((.+ )*((a)|(b))( .+)*){1,1}"));
         Assert.IsFalse(StringUtil.matches("d e c", "((.+ )*((a)|(b))( .+)*)+"));
         Assert.IsFalse(StringUtil.matches("b b", "a?(( )*b)?"));
         Assert.IsTrue(StringUtil.matches("MIS_L2-1.3", "((.+ )*((MIS_L2-1.3)|(MISCPS_L1-1.3))( .+)*)+"));

         Assert.IsTrue(StringUtil.matches("a-aB.3@b.c", JDFConstants.REGEXP_EMAIL));
         Assert.IsTrue(StringUtil.matches("a@b.c", JDFConstants.REGEXP_EMAIL));
         Assert.IsTrue(StringUtil.matches("mailto:a@b.c", JDFConstants.REGEXP_EMAIL));
         Assert.IsFalse(StringUtil.matches("mailt:a@b.c", JDFConstants.REGEXP_EMAIL));
         Assert.IsTrue(StringUtil.matches("aa@b.c", JDFConstants.REGEXP_EMAIL));
         Assert.IsFalse(StringUtil.matches("a@b", JDFConstants.REGEXP_EMAIL));
         Assert.IsTrue(StringUtil.matches("+(1).2/344", JDFConstants.REGEXP_PHONE));
         Assert.IsFalse(StringUtil.matches("+(1).2 344", JDFConstants.REGEXP_PHONE));
      }


      [TestMethod]
      public virtual void testMime()
      {
         Assert.AreEqual(JDFConstants.MIME_TEXTUNKNOWN, StringUtil.mime(null));
         Assert.AreEqual(JDFConstants.MIME_PDF, StringUtil.mime("foo.PDF"));
      }


      [TestMethod]
      public virtual void testNewExtension()
      {
         Assert.AreEqual("a.c", StringUtil.newExtension("a.b", "c"));
         Assert.AreEqual("a.b.c", StringUtil.newExtension("a.b.c", "c"));
         Assert.AreEqual("a", StringUtil.newExtension("a.b", null));
         Assert.AreEqual("a.c", StringUtil.newExtension("a.b", ".c"));
         Assert.AreEqual("a.c.d", StringUtil.newExtension("a.b", ".c.d"));
         Assert.AreEqual("a.c.d", StringUtil.newExtension("a.b", "c.d"));
         Assert.AreEqual("a.b.c.d", StringUtil.newExtension("a.b.bb", "c.d"));
         Assert.AreEqual(".c", StringUtil.newExtension(".b", ".c"));
      }


      [TestMethod]
      public virtual void testReplaceString()
      {
         Assert.AreEqual("_bbcc", StringUtil.replaceString("abbcc", "a", "_"));
         Assert.AreEqual("abbcc", StringUtil.replaceString("abbcc", "aa", "_"));
         Assert.AreEqual("a__cc", StringUtil.replaceString("abbcc", "b", "_"));
         Assert.AreEqual("a_cc", StringUtil.replaceString("abbcc", "bb", "_"));
         Assert.AreEqual("abb__", StringUtil.replaceString("abbcc", "c", "_"));
         Assert.AreEqual("abb_", StringUtil.replaceString("abbcc", "cc", "_"));
         Assert.AreEqual("acc", StringUtil.replaceString("abbcc", "bb", null));
         Assert.AreEqual("0", StringUtil.replaceString("000000", "00", "0"));
      }


      [TestMethod]
      public virtual void testReplaceChar()
      {
         Assert.AreEqual("bbcc", StringUtil.replaceChar("abbcc", 'a', null, 0));
         Assert.AreEqual("acc", StringUtil.replaceChar("abbcc", 'b', null, 0));
         Assert.AreEqual("abcc", StringUtil.replaceChar("abbcc", 'b', null, 2));
         Assert.AreEqual("ab_2cc", StringUtil.replaceChar("abbcc", 'b', "_2", 2));
      }


      [TestMethod]
      public virtual void testReplaceCharSet()
      {
         Assert.AreEqual("cc", StringUtil.replaceCharSet("abbcc", "ab", null, 0));
         Assert.AreEqual("___cc", StringUtil.replaceCharSet("abbcc", "ab", "_", 0));
         Assert.AreEqual("ab_cc", StringUtil.replaceCharSet("abbcc", "ab", "_", 2));
      }


      [TestMethod]
      public virtual void testRightString()
      {
         Assert.AreEqual("cc", StringUtil.rightStr("abbcc", 2));
         Assert.AreEqual("cc", StringUtil.rightStr("abbcc", -3));
         Assert.IsNull(StringUtil.rightStr("abbcc", -5));
         Assert.IsNull(StringUtil.rightStr(null, -5));
         Assert.IsNull(StringUtil.rightStr("abc", -55));
      }


      [TestMethod]
      public virtual void testLeftString()
      {
         Assert.AreEqual("ab", StringUtil.leftStr("abbcc", 2));
         Assert.AreEqual("abb", StringUtil.leftStr("abbcc", -2));
         Assert.IsNull(StringUtil.leftStr("abbcc", -5));
         Assert.IsNull(StringUtil.leftStr(null, -5));
         Assert.IsNull(StringUtil.leftStr("abc", -55));
      }


      [TestMethod]
      public virtual void testParseBoolean()
      {
         Assert.AreEqual(false, StringUtil.parseBoolean("", false));
         Assert.AreEqual(true, StringUtil.parseBoolean("", true));
         Assert.AreEqual(true, StringUtil.parseBoolean("TRUE ", false));
         Assert.AreEqual(false, StringUtil.parseBoolean(" FalSe ", true));
      }


      [TestMethod]
      public virtual void testParseDouble()
      {
         string s = "INF";
         Assert.AreEqual(double.MaxValue, StringUtil.parseDouble(s, 0), 0.0);
         Assert.IsTrue(StringUtil.isNumber(s));
         s = "-INF";
         Assert.AreEqual(-double.MaxValue, StringUtil.parseDouble(s, 0), 0.0);
         Assert.IsTrue(StringUtil.isNumber(s));
         s = "123.45e3";
         Assert.AreEqual(123450.0, StringUtil.parseDouble(s, 0), 0.0);
         Assert.IsTrue(StringUtil.isNumber(s));
         s = "123.45E3";
         Assert.AreEqual(123450.0, StringUtil.parseDouble(s, 0), 0.0);
         Assert.IsTrue(StringUtil.isNumber(s));
         s = "123.45";
         Assert.AreEqual(123.450, StringUtil.parseDouble(s, 0), 0.0);
         Assert.IsTrue(StringUtil.isNumber(s));
         s = "-123.45";
         Assert.AreEqual(-123.450, StringUtil.parseDouble(s, 0), 0.0);
         Assert.IsTrue(StringUtil.isNumber(s));
         s = "-123.45a";
         Assert.AreEqual(0.0, StringUtil.parseDouble(s, 0.0), 0.0);
         Assert.IsFalse(StringUtil.isNumber(s));
         s = "";
         Assert.AreEqual(0.0, StringUtil.parseDouble(s, 0.0), 0.0);
         Assert.IsFalse(StringUtil.isNumber(s));
         s = null;
         Assert.AreEqual(0.0, StringUtil.parseDouble(s, 0.0), 0.0);
         Assert.IsFalse(StringUtil.isNumber(s));
      }


      [TestMethod]
      public virtual void testFind_last_not_of()
      {
         Assert.AreEqual(0, StringUtil.find_last_not_of("abc", "bcd"));
         Assert.AreEqual(-1, StringUtil.find_last_not_of("abc", "abc"));
         Assert.AreEqual(1, StringUtil.find_last_not_of("abc", "ac"));
         Assert.AreEqual(3, StringUtil.find_last_not_of("grün", "äöü"));
         Assert.AreEqual(2, StringUtil.find_last_not_of("abc", "_"));
      }


      [TestMethod]
      public virtual void testFormatDouble()
      {
         double d = 0.12345678901234;
         string s = StringUtil.formatDouble(d);
         Assert.AreEqual("0.12345678", s, "s=6");
         d = 0.12345678;
         s = StringUtil.formatDouble(d);
         Assert.AreEqual("0.12345678", s, "s=6");
         d = 0.123456789;
         s = StringUtil.formatDouble(d);
         Assert.AreEqual("0.12345678", s, "s=6");
         d = 0.1234567;
         s = StringUtil.formatDouble(d);
         Assert.AreEqual("0.1234567", s, "s=5");
         d = 234.0;
         s = StringUtil.formatDouble(d);
         Assert.AreEqual("234", s, "s=int");
         d = 123.456e4;
         s = StringUtil.formatDouble(d);
         Assert.AreEqual("1234560", s, "s=int");
         Assert.AreEqual("0", StringUtil.formatDouble(0.1e-20), "s=real small");
         Assert.AreEqual("0", StringUtil.formatDouble(-0.1e-20), "s=real small -");
         Assert.AreEqual("1", StringUtil.formatDouble(1.000000001), "s=1+epsilon");
         Assert.AreEqual("1", StringUtil.formatDouble(0.99999999987), "s=1-epsilon");
         Assert.AreNotEqual("1", StringUtil.formatDouble(0.99949999987), "s=1-epsilon");
      }


      [TestMethod]
      public virtual void testuncToUrl()
      {
         string unc = "\\\\myHost\\a\\.\\b\\..\\c äöü%.txt";
         string iri = "file://myHost/a/c%20äöü%25.txt";
         string uri = "file://myHost/a/c%20%c3%a4%c3%b6%c3%bc%25.txt";

         Assert.AreEqual(uri, StringUtil.uncToUrl(unc, true), "uri ok");
         Assert.AreEqual(iri, StringUtil.uncToUrl(unc, false), "iri ok");
      }


      [TestMethod]
      public virtual void testZappTokenWS()
      {
         string s = " 1 2 3~    4";
         s = StringUtil.zappTokenWS(s, JDFConstants.TILDE);
         Assert.AreEqual("1 2 3~4", s, "new string");
         Assert.AreEqual("n2", StringUtil.zappTokenWS(" n2 ", null));
      }


      [TestMethod]
      public virtual void testHasToken()
      {
         string s = "1 2 3 3 \n15\n4";
         Assert.IsFalse(StringUtil.hasToken(s, "0", " \n", 0));
         Assert.IsTrue(StringUtil.hasToken(s, "1", " ", 0));
         Assert.IsFalse(StringUtil.hasToken(s, "5", " ", 0));
         Assert.IsFalse(StringUtil.hasToken(s, "15", " ", 0));
         Assert.IsTrue(StringUtil.hasToken(s, "2", " ", 0));
         Assert.IsTrue(StringUtil.hasToken(s, "4", "\n ", 0));
         Assert.IsTrue(StringUtil.hasToken(s, "3", " ", 0));
         Assert.IsTrue(StringUtil.hasToken(s, "3", " ", 1));
         Assert.IsFalse(StringUtil.hasToken(s, "3", " ", 2));
         Assert.IsFalse(StringUtil.hasToken(s, "3", " ", 99));
         Assert.IsFalse(StringUtil.hasToken(null, "0", " ", 0));
         Assert.IsFalse(StringUtil.hasToken("ab", "a", " ", 0));
         Assert.IsFalse(StringUtil.hasToken("ab", "b", " ", 0));
      }


      [TestMethod]
      public virtual void testToken()
      {
         string s = "1 2 3 4";
         Assert.AreEqual("1", StringUtil.token(s, 0, " "));
         Assert.AreEqual("2", StringUtil.token(s, 1, " "));
         Assert.AreEqual("2", StringUtil.token(s, -3, " "));
         Assert.AreEqual("4", StringUtil.token(s, -1, " "));
         Assert.IsNull(StringUtil.token(s, 4, " "));
         Assert.IsNull(StringUtil.token(s, -5, " "));
         Assert.IsNull(StringUtil.token(null, 2, " "));
         s = "a/b?c";
         Assert.AreEqual("a", StringUtil.token(s, 0, "?/"));
         Assert.AreEqual("b", StringUtil.token(s, 1, "?/"));
         Assert.AreEqual("c", StringUtil.token(s, 2, "?/"));
      }


      [TestMethod]
      public virtual void testTokenize()
      {
         string s = "1 2\n3 \n4   5";
         VString v = new VString();
         v.Add("1");
         v.Add("2");
         v.Add("3");
         v.Add("4");
         v.Add("5");
         CollectionAssert.AreEqual(v, StringUtil.tokenize(s, " \n", false));
      }


      [TestMethod]
      public virtual void testTokenizeDelim()
      {
         string s = "http://aa/b?c";
         VString v = new VString();
         v.Add("http:");
         v.Add("/");
         v.Add("/");
         v.Add("aa");
         v.Add("/");
         v.Add("b");
         v.Add("?");
         v.Add("c");
         CollectionAssert.AreEqual(v, StringUtil.tokenize(s, "/?", true));
      }


      [TestMethod]
      public virtual void testConcatStrings()
      {
         VString v = new VString(StringUtil.tokenize("a b c", " ", false));
         StringUtil.concatStrings(v, "_foo");
         Assert.AreEqual("a_foo b_foo c_foo", StringUtil.setvString(v, " ", null, null));
      }


      [TestMethod]
      public virtual void testEndsWithIgnoreCase()
      {
         string s = "a.ZIP";
         Assert.IsTrue(s.ToLower().EndsWith(".zip"));
         Assert.AreEqual("a.ZIP", s);
      }


      [TestMethod]
      public virtual void testisEqual()
      {
         const double d = 1.3141516171819;
         double d2 = 0.00000000000001;
         double d3 = -0.000000000000011;

         while (d2 < 9999999999.9999)
         {
            d2 *= d;
            d3 *= d;
            Assert.IsTrue(StringUtil.isEqual(d2, StringUtil.parseDouble(StringUtil.formatDouble(d2), 0.0)), "" + d2);
            Assert.IsTrue(StringUtil.isEqual(d3, StringUtil.parseDouble(StringUtil.formatDouble(d3), 0.0)), "" + d3);
            Assert.IsFalse(StringUtil.isEqual(d2, d2 * (1 + 1.1 * JDFBaseDataTypes_Fields.EPSILON) + JDFBaseDataTypes_Fields.EPSILON), "" + d2);
            Assert.IsFalse(StringUtil.isEqual(d3, d3 * (1 + 1.1 * JDFBaseDataTypes_Fields.EPSILON) - JDFBaseDataTypes_Fields.EPSILON), "" + d3);
         }
         Assert.IsTrue(StringUtil.isEqual(0.000000001, -0.000000001), "0.000001");
         Assert.IsTrue(StringUtil.isEqual(4, 4), "int");
      }


      [TestMethod]
      public virtual void testCompareTo()
      {
         Assert.AreEqual(-1, StringUtil.CompareTo(-3, -2));
         Assert.AreEqual(1, StringUtil.CompareTo(3, 2));
         Assert.AreEqual(1, StringUtil.CompareTo(3, 2));
         Assert.AreEqual(1, StringUtil.CompareTo(3, 2));
         Assert.AreEqual(0, StringUtil.CompareTo(2 + 0.5 * JDFBaseDataTypes_Fields.EPSILON, 2));
      }


      [TestMethod]
      public virtual void testIsNMTOKEN()
      {
         Assert.IsTrue(StringUtil.isNMTOKEN("abc"));
         Assert.IsFalse(StringUtil.isNMTOKEN(" abc"));
         Assert.IsFalse(StringUtil.isNMTOKEN("a bc"));
         Assert.IsFalse(StringUtil.isNMTOKEN("a\nbc"));
         Assert.IsFalse(StringUtil.isNMTOKEN("\tabc"));
         Assert.IsFalse(StringUtil.isNMTOKEN("abc "));
      }


      [TestMethod]
      public virtual void testIsID()
      {
         Assert.IsTrue(StringUtil.isID("abc"));
         Assert.IsFalse(StringUtil.isID("1abc"));
      }


      [TestMethod]
      public virtual void testisWindowsLocalPath()
      {
         Assert.IsTrue(UrlUtil.isWindowsLocalPath("c:\\foo"));
         Assert.IsTrue(UrlUtil.isWindowsLocalPath("c:\\foo\\bar.abc"));
         Assert.IsTrue(UrlUtil.isWindowsLocalPath("d:foo"));
         Assert.IsFalse(UrlUtil.isWindowsLocalPath("\\\\foo\\bar"));
         Assert.IsFalse(UrlUtil.isWindowsLocalPath("c/d/e.f"));
         Assert.IsFalse(UrlUtil.isWindowsLocalPath("/c/d/e.f"));
      }


      [TestMethod]
      public virtual void testPathToName()
      {
         Assert.AreEqual("bar", StringUtil.pathToName("\\\\foo\\bar"));
         Assert.AreEqual("bar.txt", StringUtil.pathToName("c:\\foo\\bar.txt"));
         Assert.AreEqual("bar.txt", StringUtil.pathToName("c/foo/bar.txt"));
         Assert.AreEqual("bar.txt", StringUtil.pathToName("bar.txt"));
      }


      [TestMethod]
      public virtual void testGetNamesVector()
      {
         VString v = StringUtil.getNamesVector(EnumType.AbortQueueEntry.GetType());
         Assert.IsTrue(v.Contains("Resource"));
         v = StringUtil.getNamesVector(EnumOrientation.Flip0.GetType());
         Assert.IsTrue(v.Contains("Rotate90"));
      }


      [TestMethod]
      public virtual void testGetEnumsVector()
      {
         ArrayList v = StringUtil.getEnumsVector(EnumOrientation.Flip180.GetType());
         Assert.IsTrue(v.Contains(EnumOrientation.Rotate180));
      }
   }
}
