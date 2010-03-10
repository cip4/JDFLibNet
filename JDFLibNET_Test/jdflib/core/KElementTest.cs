
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



/* 
 * KElementTest.java
 * 
 * @author Dietrich Mucha
 *
 * Copyright (C) 2002 Heidelberger Druckmaschinen AG. All Rights Reserved.
 */


namespace org.cip4.jdflib.core
{
   using System;
   using System.IO;
   using System.Collections;
   using System.Xml;
   using Microsoft.VisualStudio.TestTools.UnitTesting;

   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using EnumSide = org.cip4.jdflib.auto.JDFAutoPart.EnumSide;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using EnumValidationLevel = org.cip4.jdflib.core.KElement.EnumValidationLevel;
   using SimpleNodeComparator = org.cip4.jdflib.core.KElement.SimpleNodeComparator;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using JDFResourcePool = org.cip4.jdflib.pool.JDFResourcePool;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using EnumPartIDKey = org.cip4.jdflib.resource.JDFResource.EnumPartIDKey;
   using JDFExposedMedia = org.cip4.jdflib.resource.process.JDFExposedMedia;
   using JDFRunList = org.cip4.jdflib.resource.process.JDFRunList;
   using StringUtil = org.cip4.jdflib.util.StringUtil;

   ///
   /// <summary> * test class for KElement
   /// * 
   /// * @author Rainer Prosi, Heidelberger Druckmaschinen
   /// * </summary>
   /// 
   [TestClass]
   public class KElementTest : JDFTestCaseBase
   {

      [TestMethod]
      public virtual void testAncestorDistance()
      {
         KElement e = new JDFDoc("a").getRoot();
         Assert.AreEqual(0, e.ancestorDistance(e));
         KElement e1 = e.appendElement("b");
         Assert.AreEqual(1, e.ancestorDistance(e1));
         KElement e11 = e1.appendElement("b");
         Assert.AreEqual(2, e.ancestorDistance(e11));
         KElement e2 = e.appendElement("b");
         Assert.AreEqual(-1, e1.ancestorDistance(e2));
      }


      [TestMethod]
      public virtual void testDeleteNode()
      {
         KElement k = new XMLDoc("root", null).getRoot();
         // Java to C# Conversion - Divide number of tests by 1000 for now
         for (int i = 0; i < 50; i++)
            k.appendElement("DOA").deleteNode();
         Assert.AreEqual(getCurrentMem(), mem, 50000, "memory size test");
      }


      [TestMethod]
      public virtual void testImportNode()
      {
         KElement k = new XMLDoc("root", null).getRoot();
         // Java to C# Conversion - Divide number of tests by 1000 for now
         for (int i = 0; i < 50; i++)
         {
            KElement d2 = new XMLDoc("mama", null).getRoot();

            for (int j = 0; j < 100; j++)
               d2.appendElement("kid");
            k.moveElement(d2.appendElement("kid"), null);
         }
         Assert.AreEqual(getCurrentMem(), mem, 100 * 50000, "memory size test"); // allow 100 per element
      }


      [TestMethod]
      public virtual void testEnumValid()
      {
         EnumValidationLevel level = EnumValidationLevel.RecursiveComplete;
         Assert.AreEqual(EnumValidationLevel.NoWarnComplete, EnumValidationLevel.setNoWarning(level, true));
         Assert.AreEqual(EnumValidationLevel.RecursiveComplete, EnumValidationLevel.setNoWarning(level, false));
         level = EnumValidationLevel.RecursiveIncomplete;
         Assert.AreEqual(EnumValidationLevel.NoWarnIncomplete, EnumValidationLevel.setNoWarning(level, true));
         Assert.AreEqual(EnumValidationLevel.RecursiveIncomplete, EnumValidationLevel.setNoWarning(level, false));
      }

      ///   
      ///	 <summary> * Test for void RemoveAttribute(String, String) - PR-AKMP-000001 </summary>
      ///	 

      [TestMethod]
      public virtual void testRemoveAttributeStringString()
      {
         JDFParser p = new JDFParser();
         JDFDoc jdfDoc = p.parseFile(sm_dirTestData + "emptyAuthorAttribute.jdf");

         JDFNode root = (JDFNode)jdfDoc.getRoot();
         KElement kElem = root.getChildByTagName("Created", null, 0, null, false, true);

         bool before = kElem.hasAttribute("Author", null, false);
         Assert.IsTrue(before, "The Attribute 'Author' does not exist");

         if (before)
         {
            kElem.removeAttribute("Author", "");
            bool after = kElem.hasAttribute("Author", "", false);

            Assert.IsFalse(after, "The Attribute 'Author' was not removed");
         }
      }


      [TestMethod]
      public virtual void testRenameElement()
      {
         XMLDoc d = new XMLDoc("root", "www.root.com");
         KElement root = d.getRoot();
         string nsUri = root.getNamespaceURI();
         //C# renameElement only returns the renamed element.
         root = root.renameElement("foo", null);
         Assert.AreEqual(nsUri, root.getNamespaceURI());
         Assert.AreEqual("foo", root.Name);
         //C# renameElement only returns the renamed element.
         root = root.renameElement("bar", "www.bar.com");
         Assert.AreEqual("www.bar.com", root.getNamespaceURI());
         string s = d.write2String(2);
         Assert.IsTrue(s.IndexOf("www.root.com") < 0);
         Assert.IsTrue(s.IndexOf("www.bar.com") > 0);
      }


      [TestMethod]
      public virtual void testGetElementsWithMultipleID()
      {
         XMLDoc d = new XMLDoc("e1", null);
         KElement e1 = d.getRoot();
         Assert.IsNull(e1.getMultipleIDs("ID"));
         e1.setXPathAttribute("./e2[2]/e3/@ID", "i1");
         e1.setXPathAttribute("./e2[3]/e3/@ID", "i2");
         Assert.IsNull(e1.getMultipleIDs("ID"));
         e1.setXPathAttribute("./e2[4]/e3/@ID", "i1");
         Assert.AreEqual("i1", e1.getMultipleIDs("ID").stringAt(0));
         Assert.AreEqual(1, e1.getMultipleIDs("ID").Count);
         e1.setAttribute("ID", "i2");
         Assert.AreEqual(2, e1.getMultipleIDs("ID").Count);
         Assert.IsTrue(e1.getMultipleIDs("ID").Contains("i1"));
         Assert.IsTrue(e1.getMultipleIDs("ID").Contains("i2"));

      }


      [TestMethod]
      public virtual void testGetFirstChildElement()
      {
         XMLDoc d = new XMLDoc("e1", null);
         KElement e1 = d.getRoot();
         KElement a = e1.appendElement("a");
         KElement b = e1.appendElement("b");
         KElement c = e1.appendElement("c:c", "cc");
         Assert.AreEqual(a, e1.getFirstChildElement("a", null));
         Assert.AreEqual(b, e1.getFirstChildElement("b", null));
         Assert.IsNull(e1.getFirstChildElement("d", null));
         Assert.AreEqual(c, e1.getFirstChildElement("c", "cc"));
      }


      [TestMethod]
      public virtual void testGetNextSibling()
      {
         XMLDoc d = new XMLDoc("e1", null);
         KElement e1 = d.getRoot();
         KElement a = e1.appendElement("a");
         KElement b = e1.appendElement("b");
         KElement c = e1.appendElement("c:c", "cc");
         Assert.AreEqual(c, a.getNextSiblingElement("c", "cc"));
         Assert.AreEqual(c, b.getNextSiblingElement("c", "cc"));
         Assert.AreEqual(b, a.getNextSiblingElement("b", null));
         Assert.IsNull(a.getNextSiblingElement("a", null));
      }


      [TestMethod]
      public virtual void testGetElementById()
      {
         string xmlString = "<JDF ID=\"Link20704459_000351\">" + "<ELEM2 ID=\"Link20704459_000352\">" + "<ELEM3 ID=\"Link20704459_000353\">" + "<Comment/>" + "</ELEM3>" + "</ELEM2>" + "</JDF>";

         for (int i = 0; i < 2; i++)
         {
            JDFParser parser = new JDFParser();
            if (i == 1) // test both with and withot schema
               parser.m_SchemaLocation = SupportClass.FileSupport.ToUri(new FileInfo(sm_dirTestSchema + "JDF.xsd")).ToString();
            JDFDoc jdfDoc = parser.parseString(xmlString);
            KElement root = jdfDoc.getRoot();

            KElement kElem, kElem2;

            // alt funktioniert
            kElem2 = root.getTarget("Link20704459_000351", AttributeName.ID);
            Assert.IsNotNull(kElem2);

            // neu funktioniert nicht -
            // http://mail-archives.apache.org/mod_mbox/
            // xerces-j-users/200410.mbox/%3c4178694B.40708@metalab.unc.edu%3e
            // http://www.stylusstudio.com/xmldev/200012/post80000.html
            kElem = (KElement)jdfDoc.getElementById("Link20704459_000351");
            Assert.IsNotNull(kElem);

            // alt funktioniert
            kElem2 = root.getTarget("Link20704459_000352", AttributeName.ID);
            Assert.IsNotNull(kElem2);

            // neu funktioniert nicht
            kElem = (KElement)jdfDoc.getElementById("Link20704459_000352");
            Assert.IsNotNull(kElem);

            // alt funktioniert
            kElem2 = root.getTarget("Link20704459_000353", AttributeName.ID);
            Assert.IsNotNull(kElem2);

            // neu funktioniert nicht
            kElem = (KElement)jdfDoc.getElementById("Link20704459_000353");
            Assert.IsNotNull(kElem);
         }
      }


      [TestMethod]
      public virtual void testReplaceElementRoot()
      {
         XMLDoc d = new XMLDoc("root", "www.root.com");
         XMLDoc d2 = new XMLDoc("root2", "www.root2.com");
         KElement e = d.getRoot();
         e.appendElement("c1");

         KElement e2 = d2.getRoot();
         //C# replaceElement on root only returns the replaced element.
         e2 = e2.replaceElement(e);
         Assert.AreEqual(e2, d2.getRoot(), "copied root");
         // Java to C# Conversion - No isEqualNode equivalent.
         // Normalize and check innerxml (good enough for this test).
         e.Normalize();
         e2.Normalize();
         Assert.IsTrue(e2.InnerXml == e.InnerXml, "same contents");
      }

      ///   
      ///	 <summary> * test memory leaks in replaceElement </summary>
      ///	 

      [TestMethod]
      public virtual void testReplaceElementMem()
      {
         XMLDoc d = new XMLDoc("root", "www.root.com");
         KElement e = d.getRoot();
         KElement ec1 = e.appendElement("c1");
         long l = d.getDocMemoryUsed();
         // Java to C# Conversion - Divide number of tests by 1000 for now
         for (int i = 0; i < 100; i++)
         {
            ec1.replaceElement(((XMLDoc)d.Clone()).getRoot().getFirstChildElement());
         }
         GC.Collect();
         long l2 = d.getDocMemoryUsed();
         Assert.AreEqual(l, l2, 100000, "memory nice and low");
      }


      [TestMethod]
      public virtual void testReplaceElement()
      {
         XMLDoc d = new XMLDoc("root", "www.root.com");
         XMLDoc d2 = new XMLDoc("root2", "www.root2.com");
         KElement e = d.getRoot();
         KElement ec1 = e.appendElement("c1");
         KElement ec2 = e.appendElement("c2");
         ec2.setAttribute("foo", "ec2");
         KElement ec4 = e.appendElement("c4");

         KElement ec3 = ec1.replaceElement(ec2);
         Assert.AreEqual(ec3, ec2, "c1=c2");
         Assert.AreEqual(ec3, ec4.PreviousSibling, "c4 is next");
         Assert.AreEqual(ec4, ec3.NextSibling, "c4 is next");
         Assert.IsNull(ec1.NextSibling, "no sibling");
         Assert.IsNull(ec1.PreviousSibling, "no sibling");
         Assert.AreEqual(e, ec2.getParentNode_KElement(), "parent ok");
         Assert.IsNull(ec1.ParentNode, "ec1 no parent");

         KElement ec33 = ec3.replaceElement(ec3);
         Assert.AreEqual(ec33, ec3, "replace of this is a nop");

         // now cross document
         KElement e2 = d2.getRoot();
         e2.appendElement("e22");

         ec1 = ec3.replaceElement(e2);
         Assert.IsNull(ec3.ParentNode, "ec3 no parent");
         Assert.AreEqual(e, ec1.getParentNode_KElement(), "parent ok");
         Assert.AreEqual(ec1, ec4.PreviousSibling, "c4 is next");
         Assert.AreEqual(ec4, ec1.NextSibling, "c4 is next");
         Assert.AreEqual(e, ec1.ParentNode, "root");

         //C# replaceElement on root only returns the replaced element.
         e = e.replaceElement(e2);
         KElement eNew = e;
         Assert.IsTrue(eNew.isEqual(e2));
         Assert.IsTrue(e.isEqual(e2));
      }


      [TestMethod]
      public virtual void testSortChildren()
      {
         XMLDoc d = new JDFDoc("parent");
         KElement e = d.getRoot();
         KElement b = e.appendElement("b");
         KElement a = e.appendElement("a");
         a.setAttribute("ID", "a1");
         KElement c = e.appendElement("c");
         e.sortChildren();
         Assert.AreEqual(a, e.getFirstChildElement());
         Assert.AreEqual(b, a.getNextSiblingElement());
         Assert.AreEqual(c, b.getNextSiblingElement());
         KElement a3 = e.appendElement("a");
         a3.setAttribute("ID", "z1");
         KElement a2 = e.appendElement("a");
         a2.setAttribute("ID", "a2");
         e.sortChildren();
         Assert.AreEqual(a, e.getFirstChildElement());
         Assert.AreEqual(a2, a.getNextSiblingElement());
         Assert.AreEqual(a3, a2.getNextSiblingElement());
         Assert.AreEqual(b, a3.getNextSiblingElement());
         Assert.AreEqual(c, b.getNextSiblingElement());
      }


      [TestMethod]
      public virtual void testSortChildrenCompPerformance()
      {
         XMLDoc d = new JDFDoc("parent");
         KElement e = d.getRoot();

         // Java to C# Conversion - Divide number of tests by 1000 for now
         for (int i = 0; i < 10; i++)
            e.appendElement("b" + (int)(new Random(1).NextDouble() * 100));
         Console.WriteLine(DateTime.Now.Ticks);
         e.sortChildren(new SimpleNodeComparator().Compare);
         Console.WriteLine(DateTime.Now.Ticks);
         d = new JDFDoc("parent");
         e = d.getRoot();
         // Java to C# Conversion - Divide number of tests by 1000 for now
         for (int i = 0; i < 10; i++)
            e.appendElement("b" + (int)(new Random(2).NextDouble() * 100));
         Console.WriteLine(DateTime.Now.Ticks);
         e.sortChildren();
         Console.WriteLine(DateTime.Now.Ticks);
         e.sortChildren();
         Console.WriteLine(DateTime.Now.Ticks);
      }


      [TestMethod]
      public virtual void testSortChildrenComp()
      {

         XMLDoc d = new JDFDoc("parent");
         KElement e = d.getRoot();
         KElement b = e.appendElement("b");
         KElement a = e.appendElement("a");
         a.setAttribute("ID", "a1");

         KElement c = e.appendElement("c");
         e.sortChildren(new SimpleNodeComparator().Compare);
         Assert.AreEqual(a, e.getFirstChildElement());
         Assert.AreEqual(b, a.getNextSiblingElement());
         Assert.AreEqual(c, b.getNextSiblingElement());
         KElement a3 = e.appendElement("a");
         a3.setAttribute("ID", "z1");
         KElement a2 = e.appendElement("a");
         a2.setAttribute("ID", "a2");
         e.sortChildren();
         Assert.AreEqual(a, e.getFirstChildElement());
         Assert.AreEqual(a2, a.getNextSiblingElement());
         Assert.AreEqual(a3, a2.getNextSiblingElement());
         Assert.AreEqual(b, a3.getNextSiblingElement());
         Assert.AreEqual(c, b.getNextSiblingElement());
      }


      [TestMethod]
      public virtual void testRemoveFromAttribute()
      {
         XMLDoc d = new JDFDoc("Foo");
         KElement e = d.getRoot();
         e.setAttribute("a", "1 b 2");
         e.removeFromAttribute("a", "b", null, " ", 333);
         Assert.AreEqual("1 2", e.getAttribute("a"));
         e.setAttribute("a", "c");
         e.removeFromAttribute("a", "c", null, " ", 333);
         Assert.IsNull(e.getAttribute("a", null, null));
         e.removeFromAttribute("a", "c", null, " ", 333);
         Assert.IsNull(e.getAttribute("a", null, null));
      }


      [TestMethod]
      public virtual void testRemoveExtensions()
      {
         KElement e = new XMLDoc("e", "a.com").getRoot();
         KElement b = e.appendElement("b", "b.com");
         b.setAttribute("c:at", "cc", "c.com");
         // KElement c=
         e.appendElement("c", "c.com");
         Assert.IsNotNull(b.getAttribute("at", "c.com", null));
         Assert.IsNotNull(e.getElement("c", "c.com", 0));
         e.removeExtensions("c.com");
         Assert.IsNull(b.getAttribute("at", "c.com", null));
         Assert.IsNull(e.getElement("c", "c.com", 0));
      }


      [TestMethod]
      public virtual void testRemoveEmptyAttributes()
      {
         JDFDoc d = new JDFDoc("JDF");
         KElement e = d.getJDFRoot();

         e.setAttribute("foo", "bar", null);
         e.setAttribute("foo2", "", null);

         Assert.IsTrue(e.hasAttribute("foo"), "has foo");
         Assert.IsTrue(e.hasAttribute("foo2"), "has foo2");

         KElement e2 = e.appendElement("e2");
         e2.setAttribute("foo", "bar", null);
         e2.setAttribute("foo2", "", null);

         e.eraseEmptyAttributes(false);
         Assert.IsTrue(e.hasAttribute("foo"), "has foo");
         Assert.IsFalse(e.hasAttribute("foo2"), "has foo2");
         Assert.IsTrue(e2.hasAttribute("foo"), "has foo");
         Assert.IsTrue(e2.hasAttribute("foo2"), "has foo2");

         e.eraseEmptyAttributes(true);
         Assert.IsTrue(e.hasAttribute("foo"), "has foo");
         Assert.IsFalse(e.hasAttribute("foo2"), "has foo2");
         Assert.IsTrue(e2.hasAttribute("foo"), "has foo");
         Assert.IsFalse(e2.hasAttribute("foo2"), "has foo2");
      }


      [TestMethod]
      public virtual void testRemoveAttribute()
      {
         JDFDoc d = new JDFDoc("JDF");
         KElement e = d.getJDFRoot();
         e.setAttribute("foo", "bar", null);
         Assert.IsTrue(e.hasAttribute("foo"), "has foo");
         Assert.IsTrue(e.hasAttribute("foo", null, false), "has foo");
         e.removeAttribute("foo", null);
         Assert.IsFalse(e.hasAttribute("foo"), "has foo");
         Assert.IsFalse(e.hasAttribute("foo", null, false), "has foo");
         e.removeAttribute("foo", null);
         e.removeAttribute("foo"); // make sure we have no npe for removing non
         // existing attrbutes
         e.removeAttribute(""); // make sure we have no npe for removing non
         // existing attrbutes

         e.setAttribute("foo", "bar", "");
         Assert.IsTrue(e.hasAttribute("foo"), "has foo");
         Assert.IsTrue(e.hasAttribute("foo", "", false), "has foo");
         e.removeAttribute("foo", "");
         Assert.IsFalse(e.hasAttribute("foo"), "has foo");
         Assert.IsFalse(e.hasAttribute("foo", "", false), "has foo");

         e.setAttribute("foo", "bar", JDFConstants.JDFNAMESPACE);
         Assert.IsTrue(e.hasAttribute("foo"), "has foo");
         Assert.IsTrue(e.hasAttribute("foo", JDFConstants.JDFNAMESPACE, false), "has foo");
         e.removeAttribute("foo", JDFConstants.JDFNAMESPACE);
         Assert.IsFalse(e.hasAttribute("foo"), "has foo");
         Assert.IsFalse(e.hasAttribute("foo", JDFConstants.JDFNAMESPACE, false), "has foo");

         e.setAttribute("JDF:foo", "bar", JDFConstants.JDFNAMESPACE);
         Assert.IsTrue(e.hasAttribute("JDF:foo"), "has foo");
         Assert.IsTrue(e.hasAttribute("foo", JDFConstants.JDFNAMESPACE, false), "has foo");
         e.removeAttribute("foo", JDFConstants.JDFNAMESPACE);
         Assert.IsFalse(e.hasAttribute("JDF:foo"), "has foo");
         Assert.IsFalse(e.hasAttribute("foo", JDFConstants.JDFNAMESPACE, false), "has foo");
      }


      [TestMethod]
      public virtual void testMatchesPath()
      {
         XMLDoc doc = new XMLDoc("Test", "www.test.com");
         KElement root = doc.getRoot();
         KElement a = root.appendElement("a");
         root.appendElement("b");
         KElement a2 = root.appendElement("a");
         KElement a3 = root.appendElement("a");
         KElement c = root.appendElement("ns:c", "www.c.com");
         c.setAttribute("att", "41");
         a.setAttribute("att", "42");
         Assert.IsTrue(a.matchesPath("//a", false));
         Assert.IsTrue(a.matchesPath("/Test/a", false));
         Assert.IsTrue(a.matchesPath("/Test/a[1]", false));
         Assert.IsTrue(a.matchesPath("/Test/a[@att=\"42\"]", false));
         Assert.IsTrue(a2.matchesPath("/Test/a[2]", false));
         Assert.IsTrue(a3.matchesPath("/Test/a[3]", false));
         Assert.IsFalse(a3.matchesPath("/Test/a[@att=\"*\"]", false));
         Assert.IsTrue(a.matchesPath("/Test/a[@att=\"*\"]", false));
         Assert.IsTrue(a.matchesPath("/Test/a[@att=\"42\"]", false));
         Assert.IsFalse(a.matchesPath("/Test/a[@att=\"43\"]", false));
         Assert.IsTrue(c.matchesPath("/Test/ns:c", false));
         Assert.IsTrue(c.matchesPath("/Test/ns:c[1]", false));
         Assert.IsTrue(c.matchesPath("/Test/ns:c[@att=\"*\"]", false));
         Assert.IsTrue(c.matchesPath("/Test/ns:c[@att=\"41\"]", false));
      }


      [TestMethod]
      public virtual void testMergeElement()
      {
         XMLDoc doc = new XMLDoc("Test", "www.test.com");
         KElement root = doc.getRoot();
         KElement t2 = root.appendElement("foo");
         t2.setAttribute("a", "1");
         t2.setAttribute("b", "1");

         XMLDoc doc2 = new XMLDoc("Test", "www.test.com");
         KElement root2 = doc2.getRoot();
         KElement t3 = root2.appendElement("foo");
         t3.setAttribute("a", "2");
         t3.setAttribute("c", "2");

         t2.mergeElement(t3, false);
         Assert.AreEqual("2", t2.getAttribute("a"));
         Assert.AreEqual("1", t2.getAttribute("b"));
         Assert.AreEqual("2", t2.getAttribute("c"));
      }


      [TestMethod]
      public virtual void testMergeElementElements()
      {
         XMLDoc doc = new XMLDoc("Test", "www.test.com");
         KElement root = doc.getRoot();
         KElement t2 = root.appendElement("foo");
         KElement t22 = t2.appendElement("bar");
         t22.setAttribute("a", "1");
         t22.setAttribute("b", "1");

         XMLDoc doc2 = new XMLDoc("Test", "www.test.com");
         KElement root2 = doc2.getRoot();
         KElement t3 = root2.appendElement("foo");
         KElement t32 = t3.appendElement("bar");
         t32.setAttribute("a", "2");
         t32.setAttribute("c", "2");

         t2.mergeElement(t3, false);
         Assert.AreEqual(t22, t2.getElement("bar", null, 0));
         Assert.AreEqual("2", t22.getAttribute("a"));
         Assert.AreEqual("1", t22.getAttribute("b"));
         Assert.AreEqual("2", t22.getAttribute("c"));
      }


      [TestMethod]
      public virtual void testMoveMe()
      {
         XMLDoc doc = new XMLDoc("Test", "www.test.com");
         KElement root = doc.getRoot();
         KElement a = root.appendElement("a");
         KElement b = root.appendElement("b");
         KElement c = b.appendElement("c");
         Assert.IsNull(root.moveMe(a));
         Assert.IsNull(b.moveMe(c));
         Assert.AreEqual(a, b.PreviousSibling);
         b = b.moveMe(a);
         Assert.AreEqual(a, b.NextSibling);
         b = b.moveMe(b);
         Assert.AreEqual(a, b.NextSibling);
         b = b.moveMe(null);
         Assert.AreEqual(b, a.NextSibling);
      }


      [TestMethod]
      public virtual void testMoveElement()
      {
         XMLDoc doc = new XMLDoc("Test", null);
         KElement root = doc.getRoot();
         KElement a = root.appendElement("a");
         KElement b = root.appendElement("b");
         KElement c = b.appendElement("c");
         KElement c2 = b.removeChild("c", null, 0);
         Assert.AreEqual(c2, c);
         KElement c3 = a.moveElement(c2, null);
         Assert.AreEqual(c3, c);
         Assert.AreEqual(c3, a.getElement("c"));
      }


      [TestMethod]
      public virtual void testCopyElementMem()
      {
         KElement k = new XMLDoc("root", null).getRoot();
         // Java to C# Conversion - Divide number of tests by 1000 for now
         for (int i = 0; i < 50; i++)
         {
            KElement d2 = new XMLDoc("mama", null).getRoot();

            for (int j = 0; j < 100; j++)
               d2.appendElement("kid");
            k.copyElement(d2.appendElement("kid"), null);
         }
         // Java to C# Conversion - Divide number of tests by 1000 for now
         Assert.AreEqual(mem, getCurrentMem(), 100 * 50, "memory size test"); // allow 100 per element
      }


      [TestMethod]
      public virtual void testCloneElementMem()
      {
         XMLDoc doc = new XMLDoc("root", null);
         //		KElement k = 
         doc.getRoot();
         // Java to C# Conversion - Divide number of tests by 1000 for now
         for (int i = 0; i < 50; i++)
         {
            KElement d2 = new XMLDoc("mama", null).getRoot();
            d2.CloneNode(true);
            doc.cloneNode(true);
         }
         Assert.AreEqual(mem, getCurrentMem(), 100000, "memory size test");
      }


      [TestMethod]
      public virtual void testMoveAttribute()
      {
         XMLDoc doc = new XMLDoc("Test", "www.test.com");
         KElement root = doc.getRoot();
         KElement a = root.appendElement("a");
         KElement b = root.appendElement("b");
         a.setAttribute("att", "42");
         b.moveAttribute("att", a, null, null, null);
         Assert.AreEqual("42", b.getAttribute("att"));
         Assert.IsNull(a.getAttribute("att", null, null));
         b.moveAttribute("noThere", a, null, null, null);
         Assert.IsNull(b.getAttribute("noThere", null, null));
         Assert.IsNull(a.getAttribute("noThere", null, null));
         a.setAttribute("foo", "a");
         b.moveAttribute("bar", a, "foo", null, null);
         Assert.AreEqual("a", b.getAttribute("bar"));
         Assert.IsNull(a.getAttribute("bar", null, null));
         Assert.IsNull(b.getAttribute("foo", null, null));
         Assert.IsNull(a.getAttribute("foo", null, null));
         b.moveAttribute("bar", b, "bar", null, null);
         Assert.AreEqual("a", b.getAttribute("bar"));
         b.moveAttribute("bar", null, "bar", null, null);
         Assert.AreEqual("a", b.getAttribute("bar"));
         b.moveAttribute("bar", null, null, null, null);
         Assert.AreEqual("a", b.getAttribute("bar"));
         b.moveAttribute("bar2", null, "bar", null, null);
         Assert.AreEqual("a", b.getAttribute("bar2"));
         Assert.IsNull(b.getAttribute("bar", null, null));
      }


      [TestMethod]
      public virtual void testCopyElement()
      {
         XMLDoc d = new XMLDoc("d1", null);
         KElement e = d.getRoot();
         XMLDoc d2 = new XMLDoc("d2", null);
         KElement e2 = d2.getRoot();
         KElement e3 = e.copyElement(e2, null);
         Assert.IsTrue(String.IsNullOrEmpty(e3.getNamespaceURI()));
         Assert.IsFalse(d.ToString().IndexOf("xmlns=\"\"") >= 0);
      }

      ///   
      ///	 <summary> * test for copyElement after clone
      ///	 * check for spurious npes here </summary>
      ///	 
      [TestMethod]
      public virtual void testCopyElementClone()
      {
         XMLDoc d = new XMLDoc("d1", null);
         KElement e = d.getRoot();
         XMLDoc d2 = new XMLDoc("d2", null);
         // Java to C# Conversion - Divide number of tests by 1000 for now
         for (int i = 0; i < 10; i++)
         {
            KElement e3 = e.copyElement(((XMLDoc)d2.Clone()).getRoot(), null);
            Assert.IsTrue(String.IsNullOrEmpty(e3.getNamespaceURI()));
         }
      }


      [TestMethod]
      public virtual void testCopyElements()
      {
         XMLDoc d = new XMLDoc("d1", null);
         KElement e = d.getRoot();

         XMLDoc d2 = new XMLDoc("d2", null);
         KElement e2 = d2.getRoot();
         VElement v = new VElement();
         v.Add(e2.appendElement("a"));
         v.Add(e2.appendElement("b"));
         e.copyElements(v, null);
         Assert.AreEqual("b", e.LastChild.LocalName);
         Assert.AreEqual("a", e.FirstChild.LocalName);
         KElement last = e.appendElement("last");
         e.copyElements(v, last);
         Assert.AreEqual("last", e.LastChild.LocalName);
         Assert.AreEqual("b", e.LastChild.PreviousSibling.LocalName);
         Assert.AreEqual(5, e.numChildElements(null, null));
      }


      [TestMethod]
      public virtual void testCopyElementNS()
      {
         XMLDoc d = new XMLDoc("d1", null);
         KElement e = d.getRoot();
         XMLDoc d2 = new XMLDoc("d2", null);
         KElement e2 = d2.getRoot();
         e2.addNameSpace("foo", "www.foo.com");
         e2.setAttribute("foo:bar", "blub");
         KElement e3 = e.copyElement(e2, null);
         Assert.IsTrue(String.IsNullOrEmpty(e3.getNamespaceURI()));
         Assert.IsTrue(d.ToString().IndexOf("xmlns:foo=\"www.foo.com\"") > 0);
      }


      [TestMethod]
      public virtual void testCopyAttribute()
      {
         XMLDoc doc = new XMLDoc("Test", "www.test.com");
         KElement root = doc.getRoot();
         KElement a = root.appendElement("a");
         KElement b = root.appendElement("b");
         a.setAttribute("att", "42");
         b.copyAttribute("att", a, null, null, null);
         Assert.AreEqual("42", a.getAttribute("att"));
         Assert.AreEqual("42", b.getAttribute("att"));
         b.copyAttribute("noThere", a, null, null, null);
         Assert.IsNull(b.getAttribute("noThere", null, null));
         Assert.IsNull(a.getAttribute("noThere", null, null));
         b.setAttribute("noThereA", "b");
         b.copyAttribute("noThereA", a, null, null, null);
         Assert.IsNull(b.getAttribute("noThereA", null, null), "the existing attribute was removed ");
         Assert.IsNull(a.getAttribute("noThereA", null, null));

         a.setAttribute("foo", "a");
         b.copyAttribute("bar", a, "foo", null, null);
         Assert.AreEqual("a", b.getAttribute("bar"));
         Assert.AreEqual("a", a.getAttribute("foo"));
         Assert.IsNull(a.getAttribute("bar", null, null));
         Assert.IsNull(b.getAttribute("foo", null, null));

         // ns copy tests
         a.setAttribute("ns:aa", "A", "www.ns.com");
         a.setAttribute("ns:bb", "B", "www.ns.com");
         a.setAttribute("cc", "C", null);
         b.copyAttribute("ns:aa", a, null, null, "www.ns.com");
         Assert.AreEqual("A", b.getAttribute("ns:aa"));
         Assert.AreEqual("A", b.getAttribute("aa", "www.ns.com", null));
         b.copyAttribute("bb", a, null, null, "www.ns.com");
         Assert.AreEqual("B", b.getAttribute("ns:bb"));
         Assert.AreEqual("B", b.getAttribute("bb", "www.ns.com", null));
         b.copyAttribute("ns:cc", a, "cc", "www.ns.com", null);
         Assert.AreEqual("C", b.getAttribute("ns:cc"));
         Assert.AreEqual("C", b.getAttribute("cc", "www.ns.com", null));
      }


      [TestMethod]
      public virtual void testNameSpace()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         KElement root = doc.getRoot();

         root.setAttribute("xmlns", "http://www.CIP4.org/JDFSchema_1_1");

         string docNS = "http://www.cip4.org/test/";
         string myPrefix = "MyPrefix";

         // add the namespace, this is mandatory for java xerces (contrary to c++
         // xerces )
         root.addNameSpace(myPrefix, docNS);

         // add an element with a (predefined) prefix and no namespace
         KElement kElem9 = root.appendElement(myPrefix + JDFConstants.COLON + "MyElementLevel_2", "");
         Assert.IsTrue(kElem9.getNamespaceURI().Equals(docNS));
         Assert.IsTrue(kElem9.Prefix.Equals(myPrefix));

         KElement kElem1 = root.appendElement("MyElementLevel_1", docNS);
         Assert.IsTrue(kElem1.getNamespaceURI().Equals(docNS));

         // kElem1.setAttributeNS(docNS, myPrefix+":att", "attval");
         kElem1.setAttributeNS(docNS, "att1", "attval1");

         // add an element in a namespace
         KElement kElem = root.appendElement(myPrefix + JDFConstants.COLON + "MyElement", docNS);
         Assert.IsTrue(kElem.getNamespaceURI().Equals(docNS));
         Assert.IsTrue(kElem.Prefix.Equals(myPrefix));

         // add an attribute and its value in a namespace
         kElem.setAttributeNS(docNS, myPrefix + JDFConstants.COLON + "MyAttribute", "MyValue");

         // How to get the element, Version 1
         KElement kElem2 = root.getElement_KElement("MyElement", docNS, 0);

         string attr = kElem2.getAttribute_KElement("MyAttribute", docNS, "MyDefault");
         Assert.IsTrue(attr.Equals("MyValue"));

         // this is pretty invalid but the ns url takes precedence
         attr = kElem2.getAttribute_KElement(myPrefix + JDFConstants.COLON + "MyAttribute", docNS, "MyDefault");
         Assert.IsTrue(attr.Equals("MyValue"));

         // this is even more invalid but the ns url takes precedence
         attr = kElem2.getAttribute_KElement("fnarf" + JDFConstants.COLON + "MyAttribute", docNS, "MyDefault");
         Assert.IsTrue(attr.Equals("MyValue"));

         // How to get the element, Version 2
         KElement kElem3 = root.getElement_KElement(myPrefix + JDFConstants.COLON + "MyElement", docNS, 0);

         attr = kElem3.getAttribute_KElement("MyAttribute", docNS, "MyDefault");
         Assert.IsTrue(attr.Equals("MyValue"));

         attr = kElem3.getAttribute_KElement(myPrefix + JDFConstants.COLON + "MyAttribute", docNS, "MyDefault");
         Assert.IsTrue(attr.Equals("MyValue"));

         DocumentJDFImpl doc0 = (DocumentJDFImpl)root.OwnerDocument;

         XmlElement newChild = doc0.createElementNS(docNS, myPrefix + JDFConstants.COLON + ElementName.RESOURCELINKPOOL);
         root.appendChild(newChild);

         doc.write2File(sm_dirTestDataTemp + "NameSpace.jdf", 0, true);
      }


      [TestMethod]
      public virtual void testNameSpaceInElements()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         KElement root = doc.getRoot();

         string cip4NameSpaceURI = root.getNamespaceURI(); // "http://www.CIP4.org/JDFSchema_1_1"
         // ;
         Assert.AreEqual(JDFConstants.JDFNAMESPACE, cip4NameSpaceURI);

         // adding cip4NameSpaceURI a second time as default namespace is ignored
         // (using addNameSpace or setAttribute)
         root.addNameSpace(JDFConstants.EMPTYSTRING, cip4NameSpaceURI);
         root.setAttribute(JDFConstants.XMLNS, cip4NameSpaceURI);

         // adding cip4NameSpaceURI with different prefixes using addNameSpace is
         // ignored
         string cip4Prefix1 = "JDF";
         string cip4Prefix2 = "jdf";
         string cip4Prefix3 = "JDFS";
         root.addNameSpace(cip4Prefix1, cip4NameSpaceURI);
         root.addNameSpace(cip4Prefix2, cip4NameSpaceURI);
         root.addNameSpace(cip4Prefix3, cip4NameSpaceURI);

         // adding cip4NameSpaceURI with different prefixes using setAttribute is
         // allowed
         root.setAttribute(JDFConstants.XMLNS + JDFConstants.COLON + cip4Prefix1, cip4NameSpaceURI);
         root.setAttribute(JDFConstants.XMLNS + JDFConstants.COLON + cip4Prefix2, cip4NameSpaceURI);
         root.setAttribute(JDFConstants.XMLNS + JDFConstants.COLON + cip4Prefix3, cip4NameSpaceURI);

         // append an element without prefix with null NameSpaceURI or
         // cip4NameSpaceURI
         KElement kElement0 = root.appendElement("kElement0", null);
         Assert.IsTrue(kElement0.getNamespaceURI().Equals(cip4NameSpaceURI));
         Assert.IsTrue(String.IsNullOrEmpty(kElement0.Prefix));

         KElement kElement1 = root.appendElement("kElement1", cip4NameSpaceURI);
         Assert.IsTrue(kElement1.getNamespaceURI().Equals(cip4NameSpaceURI));
         Assert.IsTrue(String.IsNullOrEmpty(kElement1.Prefix));

         // append an element with prefix with null NameSpaceURI or
         // cip4NameSpaceURI
         KElement kElement2 = root.appendElement(cip4Prefix1 + JDFConstants.COLON + "kElement2", null);
         Assert.IsTrue(kElement2.getNamespaceURI().Equals(cip4NameSpaceURI));
         Assert.IsTrue(kElement2.Prefix.Equals(cip4Prefix1));

         KElement kElement3 = root.appendElement(cip4Prefix1 + JDFConstants.COLON + "kElement3", cip4NameSpaceURI);
         Assert.IsTrue(kElement3.getNamespaceURI().Equals(cip4NameSpaceURI));
         Assert.IsTrue(kElement3.Prefix.Equals(cip4Prefix1));

         string jdfDocString = "<JDF ID=\"n051221_021145422_000005\" Version=\"1.3\" " + "xmlns=\"http://www.CIP4.org/JDFSchema_1_1\" " + "xmlns:JDF=\"http://www.CIP4.org/JDFSchema_1_1\" " + "xmlns:JDFS=\"http://www.CIP4.org/JDFSchema_1_1\" " + "xmlns:jdf=\"http://www.CIP4.org/JDFSchema_1_1\">" + "<kElement0/>" + "<JDF:kElement1/>" + "<JDFS:kElement2/>" + "<jdf:kElement3/>" + "</JDF>";

         JDFParser p = new JDFParser();
         JDFDoc jdfDoc = p.parseString(jdfDocString);
         KElement root1 = jdfDoc.getRoot();

         // How to get the element, uri = null or cip4NameSpaceURI

         // empty prefix is ok
         KElement kElemGet1 = root1.getElement("kElement1", null, 0);
         KElement kElemGet2 = root1.getElement("kElement1", cip4NameSpaceURI, 0);
         Assert.AreEqual(kElemGet1, kElemGet2);

         // correct prefix is ok
         KElement kElemGet3 = root1.getElement(cip4Prefix1 + JDFConstants.COLON + "kElement1", null, 0);
         KElement kElemGet4 = root1.getElement(cip4Prefix1 + JDFConstants.COLON + "kElement1", cip4NameSpaceURI, 0);
         Assert.AreEqual(kElemGet3, kElemGet4);
         Assert.AreEqual(kElemGet2, kElemGet4);

         // wrong prefix
         KElement kElemGet5 = root1.getElement(cip4Prefix2 + JDFConstants.COLON + "kElement1", null, 0);
         KElement kElemGet6 = root1.getElement(cip4Prefix2 + JDFConstants.COLON + "kElement1", cip4NameSpaceURI, 0);
         Assert.IsNull(kElemGet5);
         Assert.IsNull(kElemGet6);
      }


      [TestMethod]
      public virtual void testNameSpace1()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFElement root = (JDFElement)doc.getRoot();

         string docNS1 = "www1";
         string docNS2 = "www2";
         string myPrefix = "HDM";

         try
         {
            // add an element in a namespace
            KElement kElem1 = root.appendElement(myPrefix + JDFConstants.COLON + "Foo_1", docNS1);
            Assert.IsTrue(kElem1.getNamespaceURI().Equals(docNS1));
            Assert.IsTrue(kElem1.Prefix.Equals(myPrefix));

            kElem1.setAttribute(myPrefix + JDFConstants.COLON + "Foo_1", "attval1", docNS1);
            kElem1.setAttribute(myPrefix + JDFConstants.COLON + "Foo_2", "attval2", docNS2);
            Assert.Fail("Called KElement.setAttribute with same prefix but different namespaces ?!");
         }
         catch (JDFException expected)
         {
            string partOfErrorMessage = "KElement.setAttribute:";
            Assert.IsTrue(expected.Message.IndexOf(partOfErrorMessage) >= 0, "Exception message doesn't even mention '" + partOfErrorMessage + "'?!");
         }
      }


      [TestMethod]
      public virtual void testNameSpaceInAttributes()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFElement root = (JDFElement)doc.getRoot();
         root.addNameSpace("foo", "www.foo.com");
         Assert.AreEqual("www.foo.com", root.getAttribute("xmlns:foo"), "ns");
         KElement child = root.appendElement("abc");
         child.addNameSpace("foo", "www.foo.com");
         Assert.IsFalse(child.hasAttribute("xmlns:foo"), "ns 2");

         child.setAttribute("foo:bar", "a1");
         Assert.AreEqual("a1", child.getAttribute("foo:bar"), "dom1");
         child.setAttribute("foo:bar", "a2", "www.foo.com");
         child.setAttribute("foo:barNs", "ns", "www.foo.com");
         Assert.AreEqual("a2", child.getAttribute("foo:bar"), "dom1");
         Assert.AreEqual("a2", child.getAttribute("bar", "www.foo.com", null), "dom2");
         child.setAttribute("foo:bar", "a3");
         Assert.AreEqual("a3", child.getAttribute("foo:bar"), "dom1");
         Assert.AreEqual("a3", child.getAttribute("bar", "www.foo.com", null), "dom2");
         child.setAttribute("bar:bar", "b3", "www.bar.com");
         Assert.AreEqual("b3", child.getAttribute("bar:bar"), "dom1");
         Assert.AreEqual("b3", child.getAttribute("bar", "www.bar.com", null), "dom2");
         child.setAttribute("bar:bar", "b2");
         Assert.AreEqual("b2", child.getAttribute("bar:bar"), "dom1");
         Assert.AreEqual("b2", child.getAttribute("bar", "www.bar.com", null), "dom2");
         child.setAttribute("bar:bar", "b4", "www.bar.com");
         Assert.AreEqual("b4", child.getAttribute("bar:bar"), "dom1");
         Assert.AreEqual("b4", child.getAttribute("bar", "www.bar.com", null), "dom2");
      }


      [TestMethod]
      public virtual void testGetPrefix()
      {
         JDFDoc jdfDoc = new JDFDoc(ElementName.JDF);
         JDFNode myRoot = (JDFNode)jdfDoc.getRoot();
         myRoot.addNameSpace("foo", "www.foo.com");
         KElement e = myRoot.appendElement("foo:bar", null);
         Assert.AreEqual("foo", e.Prefix);
         myRoot.removeAttribute("xmlns:foo");
         Assert.AreEqual("foo", e.Prefix);
      }


      [TestMethod]
      public virtual void testGetLocalName()
      {
         JDFDoc jdfDoc = new JDFDoc(ElementName.JDF);
         JDFNode myRoot = (JDFNode)jdfDoc.getRoot();
         string docNS = "http://www.cip4.org/test/";
         string myPrefix = "MyPrefix";

         // append an element with a different default namespace
         myRoot.appendElement("Foo", docNS);
         // get your element back
         KElement k = myRoot.getElement_JDFElement("Foo", "", 0);
         // test your method on this element
         string s = k.LocalName;
         // gotcha First test ready
         Assert.AreEqual("Foo", s, "LocalName 'Foo' is not equal the original written name");

         // add the namespace, this is mandatory for java xerces (contrary to c++
         // xerces )
         myRoot.addNameSpace(myPrefix, docNS);

         // append another element with a prefix, namespace is equal to default
         // namespace
         myRoot.appendElement(myPrefix + ":Faa", null);
         // get your element back
         k = myRoot.getElement_JDFElement("Faa", null, 0);
         // no null pointer handling...this is a test. The element HAS TO be
         // there...otherwise test failed
         s = k.LocalName;
         //
         Assert.AreEqual("Faa", s, "LocalName 'Faa' is not equal the original written name");

         jdfDoc.write2File(sm_dirTestDataTemp + "GetLocalNameStatic.jdf", 0, true);
      }


      ///   
      ///	 <summary> * tests whether the correct virtual call hierarch is followed in
      ///	 * getCreateElement </summary>
      ///	 

      [TestMethod]
      public virtual void testGetCreateElement()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFNode root = doc.getJDFRoot();
         root.setType(JDFNode.EnumType.Imposition.getName(), false);
         JDFRunList rl = (JDFRunList)root.appendMatchingResource(ElementName.RUNLIST, JDFNode.EnumProcessUsage.Document, null);
         rl.appendLayoutElement();
         JDFRunList leaf = (JDFRunList)rl.getCreatePartition(JDFResource.EnumPartIDKey.Run, "Run1", new VString(JDFResource.EnumPartIDKey.Run.getName(), " "));

         KElement el1 = rl.getCreateElement_KElement(ElementName.LAYOUTELEMENT, null, 0);
         KElement el2 = leaf.getCreateElement_KElement(ElementName.LAYOUTELEMENT, null, 0);
         Assert.AreNotEqual(el1, el2);
      }


      [TestMethod]
      public virtual void testGetMatchesPath()
      {
         XMLDoc d = new XMLDoc("a", null);
         KElement r = d.getRoot();
         KElement b = r.getCreateXPathElement("b/c/d");
         Assert.IsTrue(b.matchesPath("d", true));
         Assert.IsTrue(b.matchesPath("c/d", true));
         Assert.IsTrue(b.matchesPath("/a/b/c/d", true));
         Assert.IsTrue(b.matchesPath("a/b/c/d", true));
         Assert.IsFalse(b.matchesPath("a/a/b/c/d", true));
      }


      [TestMethod]
      public virtual void testGetDefaultAttributeMap()
      {
         JDFDoc jdfDoc = new JDFDoc(ElementName.JDF);
         JDFNode root = (JDFNode)jdfDoc.getRoot();
         JDFAttributeMap defs = root.getDefaultAttributeMap();
         Assert.AreEqual("false", defs.get("Template"), "Template is defaulted");
         Assert.IsNull(defs.get("ID"), "ID is not defaulted");
      }


      [TestMethod]
      public virtual void testEraseDefaultAttributeMap()
      {
         JDFDoc jdfDoc = new JDFDoc(ElementName.JDF);
         JDFNode root = (JDFNode)jdfDoc.getRoot();
         root.setTemplate(false);
         Assert.IsTrue(root.hasAttribute(AttributeName.TEMPLATE));
         root.eraseDefaultAttributes(true);
         Assert.IsFalse(root.hasAttribute(AttributeName.TEMPLATE), "Template is defaulted");
         Assert.IsTrue(root.hasAttribute(AttributeName.ID), "ID is not defaulted");
      }


      [TestMethod]
      public virtual void testGetAttributeMap()
      {
         JDFDoc jdfDoc = new JDFDoc(ElementName.JDF);
         JDFNode root = (JDFNode)jdfDoc.getRoot();
         Assert.IsFalse(root.getAttributeMap().ContainsKey("Template"), "Template is defaulted");
      }


      [TestMethod]
      public virtual void testEraseEmptyNodes()
      {
         JDFParser p = new JDFParser();
         string inFile = sm_dirTestData + @"\BigWhite.jdf";
         JDFDoc jdfDoc = p.parseFile(inFile);
         JDFNode root = (JDFNode)jdfDoc.getRoot();
         root.eraseEmptyNodes(true);
         string outFile = sm_dirTestDataTemp + @"\SmallWhite.jdf";
         jdfDoc.write2File(outFile, 0, false);
         FileInfo f = new FileInfo(inFile);
         FileInfo f2 = new FileInfo(outFile);
         Assert.IsTrue(f.Length > 1.1 * f2.Length);
      }


      [TestMethod]
      public virtual void testRemoveXPathElement()
      {
         XMLDoc d = new XMLDoc("doc", null);
         KElement root = d.getRoot();
         root.setXPathAttribute("a/b[2]/@att", "foo");
         Assert.AreEqual("foo", root.getXPathAttribute("a/b[2]/@att", null));
         Assert.AreEqual("foo", root.getXPathAttribute("a/b[@att=\"foo\"]/@att", null));
         Assert.IsTrue(root.hasXPathNode("a/b[@att=\"foo\"]/@att"));
         Assert.IsTrue(root.hasXPathNode("a/b[@att=\"foo\"]"));
         root.removeXPathAttribute("a/b[2]/@att");
         Assert.IsFalse(root.hasXPathNode("a/b[@att=\"foo\"]/@att"));
         Assert.IsFalse(root.hasXPathNode("a/b[@att=\"foo\"]"));
         Assert.IsTrue(root.hasXPathNode("a/b[2]"));
         root.setXPathAttribute("a/b[2]/@att", "foo");
         root.removeXPathAttribute("a/b[@att=\"foo\"]/@att");
         Assert.IsFalse(root.hasXPathNode("a/b[@att=\"foo\"]/@att"));
         Assert.IsFalse(root.hasXPathNode("a/b[@att=\"foo\"]"));
         Assert.IsTrue(root.hasXPathNode("a/b[2]"));
      }


      [TestMethod]
      public virtual void testGetXPathAttributeMap()
      {
         XMLDoc jdfDoc = new XMLDoc("a", null);
         KElement root = jdfDoc.getRoot();
         root.setXPathAttribute("b/c[3]/d/@foo", "bar3");
         root.setXPathAttribute("b/c[5]/d/@foo", "bar5");
         //KElement doesn't return a JDFAttributeMap. JDFElement does.
         JDFAttributeMap m = new JDFAttributeMap(root.getXPathAttributeMap("//*/@foo"));
         Assert.AreEqual(2, m.Count);
         m = new JDFAttributeMap(root.getXPathAttributeMap("//@foo"));
         Assert.AreEqual(2, m.Count);
         IEnumerator it = m.Keys.GetEnumerator();
         it.MoveNext();
         Assert.AreEqual("bar3", root.getXPathAttribute((string)it.Current, null));
         it.MoveNext();
         Assert.AreEqual("bar5", root.getXPathAttribute((string)it.Current, null));

      }


      [TestMethod]
      public virtual void testGetXPathElementVector()
      {
         XMLDoc jdfDoc = new XMLDoc("a", null);
         KElement root = jdfDoc.getRoot();
         VElement va = new VElement();
         va.Add(root);
         Assert.AreEqual(va, root.getXPathElementVector("//a", 0));
         Assert.AreEqual(va, root.getXPathElementVector("/a", 0));
         Assert.AreEqual(va, root.getXPathElementVector(".", 0));
         va.Clear();
         va.Add(root.appendElement("b"));
         va.Add(root.appendElement("b"));
         Assert.AreEqual(va, root.getXPathElementVector("b", 0));
         Assert.AreEqual(va, root.getXPathElementVector("//b", 0));
         va.Clear();
         va.Add(root.getCreateXPathElement("./b/c"));
         va.Add(root.getCreateXPathElement("./c"));
         root.getCreateXPathElement("./c/d");
         Assert.AreEqual(va, root.getXPathElementVector("//c", 0));
         root.getCreateXPathElement("./c/d");
         Assert.AreEqual(va, root.getXPathElementVector("//c", 0));
         Assert.AreEqual(1, root.getXPathElementVector("//d", 0).Count);
         Assert.AreEqual(root.getXPathElementVector("//d", 0), root.getXPathElementVector("//c/d", 0));
         Assert.IsTrue(root.getXPathElementVector("//*", 0).Contains(va[0]));
         Assert.IsTrue(root.getXPathElementVector("//*", 0).Contains(root));
         root.getCreateXPathElement("./c/d[2]");
         Assert.AreEqual(2, root.getXPathElementVector("//d", 0).Count);
         Assert.AreEqual(2, root.getXPathElementVector("/a/c/d", 0).Count);
         Assert.AreEqual("d", root.getXPathElementVector("/a/c/d", 0)[0].Name);
      }


      [TestMethod]
      public virtual void testGetXPathElement()
      {
         JDFDoc jdfDoc = new JDFDoc(ElementName.JDF);
         JDFNode root = (JDFNode)jdfDoc.getRoot();

         root.setXPathAttribute("/JDF/a[2]/@foo", "v2");
         root.setXPathAttribute("/JDF/a[3]/@foo", "v3");
         Assert.AreEqual(root.getXPathElement("/JDF/a[2]"), root.getXPathElement("/JDF/a[@foo=\"v2\"]"));
         Assert.AreEqual(root.getXPathElement("/JDF/a[3]"), root.getXPathElement("/JDF/a[@foo=\"v3\"]"));

         string nodeName = "Created";
         KElement kElem = root.getXPathElement("AuditPool/" + nodeName);
         Assert.AreEqual(nodeName, kElem.Name);
         Assert.IsTrue(kElem.matchesPath("Created", false));
         Assert.IsTrue(kElem.matchesPath("/JDF/AuditPool/Created", false));
         Assert.IsTrue(kElem.matchesPath("JDF/AuditPool/Created", false));
         Assert.IsFalse(kElem.matchesPath("/Created", false));

         nodeName = "notFound";
         kElem = root.getXPathElement("AuditPool/" + nodeName);
         Assert.IsNull(kElem);
         XMLDoc d2 = new XMLDoc("doc", null);
         KElement root2 = d2.getRoot();
         for (int i = 0; i < 10; i++)
         {
            KElement e = root2.appendElement("e");
            Assert.AreEqual(root2.getXPathElement("e[" + (i + 1) + "]"), e);
            Assert.AreEqual(root2, e.getXPathElement("../"));
            Assert.AreEqual(root2, e.getXPathElement(".."));
            Assert.AreEqual(root2, e.getXPathElement(".././."));
         }
         KElement e2 = root2.getCreateElement("foo.bar");
         Assert.AreEqual("foo.bar", e2.Name);
         Assert.AreEqual(root2.getXPathElement("foo.bar"), e2);
         Assert.AreEqual(root2.getCreateXPathElement("foo.bar"), e2);
         root.setXPathAttribute("/JDF/ee[2]/@a", "2");
         root.setXPathAttribute("/JDF/ee[1]/@a", "2");
         root.setXPathAttribute("/JDF/ee[2]/ff/@b", "3");
         Assert.AreEqual("3", root.getXPathAttribute("/JDF/ee/ff/@b", null));
         Assert.AreEqual("3", root.getXPathAttribute("/JDF/ee[@a=\"2\"]/ff/@b", null));
         Assert.AreEqual("3", root.getXPathAttribute("//ee[@a=\"2\"]/ff/@b", null));
         Assert.IsNull(root.getXPathAttribute("/JDF/ee[1]/ff/@b", null));
      }

 
      // public void testGetXPathNode()
      // {
      // JDFDoc jdfDoc = new JDFDoc(ElementName.JDF);
      // JDFNode root = (JDFNode) jdfDoc.getRoot();

      // String nodeName = "Created";
      // KElement kElem = (KElement)root.getXPathNode("AuditPool/"+nodeName);
      // Assert.AreEqual(kElem.getNodeName(),nodeName);
      // Assert.IsTrue(kElem.matchesPath("Created",false));
      // Assert.IsTrue(kElem.matchesPath("/JDF/AuditPool/Created",false));
      // Assert.IsTrue(kElem.matchesPath("JDF/AuditPool/Created",false));
      // Assert.IsFalse(kElem.matchesPath("/Created",false));

      // nodeName = "notFound";
      // kElem = (KElement)root.getXPathNode("AuditPool/"+nodeName);
      // Assert.IsNull(kElem);
      // }


      [TestMethod]
      public virtual void testGetCreateXPathElement()
      {
         JDFDoc jdfDoc = new JDFDoc(ElementName.JDF);
         JDFNode root = (JDFNode)jdfDoc.getRoot();

         string nodeName = "Created";
         KElement kElem = root.getCreateXPathElement("AuditPool/" + nodeName);
         Assert.IsTrue(kElem != null && kElem.Name.Equals(nodeName), "");

         nodeName = "newElement";
         kElem = root.getCreateXPathElement("AuditPool/" + nodeName);
         Assert.IsTrue(kElem != null && kElem.Name.Equals(nodeName), "");

         KElement e = root.getCreateXPathElement("./foo/bar[2]/fnarf[3]");
         Assert.IsNotNull(e, "e");
         Assert.AreEqual(e, root.getCreateXPathElement("./foo/bar[2]/fnarf[3]"), "");
         Assert.AreEqual(e, root.getXPathElement("./foo/bar[2]/fnarf[3]"), "");
         root.setXPathAttribute("./foo/bar[2]@blub", "b1");

         Assert.AreEqual(1, root.numChildElements("foo", null), "1 foo");
         Assert.IsNotNull(root.getXPathElement("./foo/bar[2]/fnarf[3]"), "get");
         Assert.AreEqual(2, root.getElement("foo").numChildElements("bar", null), "");
         Assert.AreEqual(0, root.getElement("foo").getElement("bar").numChildElements("fnarf", null), "");
         Assert.AreEqual(3, root.getElement("foo").getElement("bar").getNextSiblingElement("bar", null).numChildElements("fnarf", null), "");
         Assert.AreEqual(root, root.getCreateXPathElement("."), "");

         Assert.AreEqual(e, root.getXPathElement("./foo/bar[@blub=\"b1\"]/fnarf[3]"), "");
         Assert.AreEqual(e, root.getCreateXPathElement("./foo/bar[@blub=\"b1\"]/fnarf[3]"), "");
         Assert.AreNotEqual(e, root.getCreateXPathElement("./foo/bar[@blub=\"b1\"]/fnarf[5]"), "");
         Assert.AreEqual(0, root.getElement("foo").getElement("bar").numChildElements("fnarf", null), "");
         Assert.AreEqual(5, root.getElement("foo").getElement("bar").getNextSiblingElement("bar", null).numChildElements("fnarf", null), "");
         try
         {
            root.getCreateXPathElement("./foo/bar[@blub=\"b1\"]/fnarf[@a=\"b\"]");
            Assert.Fail("cannot create by attribute value");
         }
         catch (ArgumentException)
         {
            // 
         }
      }


      [TestMethod]
      public virtual void testBuildXPath()
      {
         XMLDoc d = new XMLDoc("d", null);
         KElement root = d.getRoot();
         Assert.AreEqual("/d", root.buildXPath(null, 1));
         Assert.AreEqual(".", root.buildXPath("/d", 1));
         Assert.AreEqual("/d", root.buildXPath(null, 0));
         Assert.AreEqual(".", root.buildXPath("/d", 0));
         root.appendElement("e");
         KElement e = root.appendElement("e");
         e.setAttribute("ID", "i");
         root.setAttribute("ID", "r");
         Assert.AreEqual("/d/e[2]", e.buildXPath(null, 1));
         Assert.AreEqual("/d[@ID=\"r\"]/e[@ID=\"i\"]", e.buildXPath(null, 3));
         Assert.AreEqual("./e[@ID=\"i\"]", e.buildXPath("/d", 3));
         Assert.AreEqual("/d/e", e.buildXPath(null, 0));
         Assert.AreEqual("./e[2]", e.buildXPath("/d", 1));
         Assert.AreEqual(e.buildXPath("/d", 1), e.buildXPath("/d", 2));
         Assert.AreEqual("./e", e.buildXPath("/d", 0));

      }


      [TestMethod]
      public virtual void testGetXPathAttribute()
      {
         JDFAudit.setStaticAuthor(JDFAudit.software());
         JDFDoc jdfDoc = new JDFDoc(ElementName.JDF);
         JDFNode root = (JDFNode)jdfDoc.getRoot();

         string nodeName = "Created";
         string attribute = "Author";
         string attValue = root.getXPathAttribute("AuditPool/" + nodeName + "@" + attribute, "dummydefault");
         Assert.AreEqual(JDFAudit.software(), attValue);

         attribute = "notExistingAttribute";
         attValue = root.getXPathAttribute("AuditPool/" + nodeName + "@" + attribute, "dummydefault");
         Assert.AreEqual("dummydefault", attValue);
         Assert.IsNull(root.getXPathAttribute("AuditPool/" + nodeName + "@" + attribute, null));
         root.setXPathAttribute("foo/bar[2]/@a", "b2");
         root.setXPathAttribute("foo/bar[2]/sub/@c", "d2");
         Assert.AreEqual("d2", root.getXPathAttribute("foo/bar[@a=\"b2\"]/sub/@c", null));
         try
         {
            root.getXPathAttribute("foo/bar[0]/sub/@c", null);
            Assert.Fail("index must be >0");
         }
         catch (ArgumentException)
         {
            // nop
         }
      }


      [TestMethod]
      public virtual void testGetDOMAttr()
      {
         XMLDoc xd = new XMLDoc("a", null);
         KElement root = xd.getRoot();
         root.setAttribute("at", "b");
         Assert.AreEqual(root.getAttribute("at"), root.getDOMAttr("at", null, false).Value, "");
         KElement child = root.appendElement("child");
         Assert.IsNull(child.getDOMAttr("at", null, false), "");
         Assert.IsNull(child.getDOMAttr("at_notther", null, true), "");
         Assert.IsNotNull(child.getDOMAttr("at", null, true), "");
      }


      [TestMethod]
      public virtual void testRemoveXPathAttribute()
      {
         JDFDoc jdfDoc = new JDFDoc(ElementName.JDF);
         JDFNode root = (JDFNode)jdfDoc.getRoot();

         string nodeName = "Created";
         string attribute = "Author";
         root.removeXPathAttribute("AuditPool/" + nodeName + "@" + attribute);
         string attValue = root.getXPathAttribute("AuditPool/" + nodeName + "@" + attribute, null);
         Assert.IsNull(attValue, "");

         attribute = "notExistingAttribute";
         root.removeXPathAttribute("AuditPool/" + nodeName + "@" + attribute);
         attValue = root.getXPathAttribute("AuditPool/" + nodeName + "@" + attribute, "dummydefault");
         Assert.IsTrue(attValue.Equals("dummydefault"), "");
      }


      [TestMethod]
      public virtual void testSetXPathAttribute()
      {
         JDFDoc jdfDoc = new JDFDoc(ElementName.JDF);
         JDFNode root = (JDFNode)jdfDoc.getRoot();

         string nodeName = "Created";
         string attribute = "Author";
         root.setXPathAttribute("AuditPool/" + nodeName + "@" + attribute, "newAttributeValue");
         root.setXPathAttribute("new/@foo", "bar");
         Assert.AreEqual("bar", root.getXPathAttribute("new/@foo", null), "");
         Assert.AreEqual("bar", root.getXPathAttribute("new@foo", null), "");
         root.setXPathAttribute("new@foo2", "bar2");
         Assert.AreEqual("bar2", root.getXPathAttribute("new/@foo2", null), "");
         Assert.AreEqual("bar2", root.getXPathAttribute("new@foo2", null), "");
         string attValue = root.getXPathAttribute("AuditPool/" + nodeName + "@" + attribute, "dummydefault");
         Assert.AreEqual("newAttributeValue", attValue, "");
      }

      ///   
      ///	 <summary> * Method testGetDeepParentChild.
      ///	 *  </summary>
      ///	 * <exception cref="Exception"> </exception>
      ///	 

      [TestMethod]
      public virtual void testGetDeepParentChild()
      {
         XMLDoc jdfDoc = new XMLDoc("Test", "www.test.com");
         KElement e = jdfDoc.getRoot();
         KElement foo = e.appendElement("foo");
         KElement bar = foo.appendElement("bar");
         Assert.IsNull(bar.getDeepParentChild("fnarf"));
         Assert.AreEqual(foo, bar.getDeepParentChild("Test"));
         Assert.AreEqual(bar, bar.getDeepParentChild("foo"));
         KElement foo2 = e.appendElement("foo:foo", "www.foo.com");
         KElement bar2 = foo2.appendElement("bar:bar", "www.bar.com");
         Assert.AreEqual(bar2, bar2.getDeepParentChild("foo:foo"));
         KElement bar3 = bar2.appendElement("bar:fnarf", "www.bar.com");
         Assert.AreEqual(bar2, bar3.getDeepParentChild("foo:foo"));
      }

      ///   
      ///	 <summary> * Method testGetDeepParentNotName.
      ///	 *  </summary>
      ///	 * <exception cref="Exception"> </exception>
      ///	 

      [TestMethod]
      public virtual void testGetDeepParentNotName()
      {
         XMLDoc jdfDoc = new XMLDoc("Test", "www.test.com");
         KElement e = jdfDoc.getRoot();
         KElement foo = e.appendElement("foo");
         KElement bar = foo.appendElement("bar");
         Assert.AreEqual(foo, bar.getDeepParentNotName("bar"));
         KElement bar2 = bar.appendElement("bar", "www.bar.com");
         Assert.AreEqual(foo, bar2.getDeepParentNotName("bar"));
         KElement bar3 = (KElement)jdfDoc.createElement("bar");
         Assert.IsNull(bar3.getDeepParentNotName("bar"));
         KElement bar4 = (KElement)jdfDoc.createElementNS("www.bar.com", "bar");
         Assert.IsNull(bar4.getDeepParentNotName("bar"));
      }

      ///   
      ///	 <summary> * Method testGetElementByID.
      ///	 *  </summary>
      ///	 * <exception cref="Exception"> </exception>
      ///	 

      [TestMethod]
      public virtual void testGetDeepElementByID()
      {
         string xmlFile = "bookintent.jdf";

         JDFParser p = new JDFParser();
         JDFDoc jdfDoc = p.parseFile(sm_dirTestData + xmlFile);

         JDFNode jdfRoot = (JDFNode)jdfDoc.getRoot();
         XMLDocUserData ud = jdfRoot.getXMLDocUserData();

         // first try
         KElement kelem1 = jdfRoot.getDeepElementByID("ID", "n0006", null, ud);
         Assert.IsNotNull(kelem1, "kelem1==null");
         Assert.AreEqual("n0006", kelem1.getAttribute("ID"), "id");

         // second try
         KElement kelem2 = jdfRoot.getDeepElementByID("Preferred", "198", null, null);
         Assert.IsTrue(kelem2 != null, "kelem2==null");
         if (kelem2 == null)
            return; // soothe findbugs ;)
         string strAtrib2 = kelem2.getAttribute("Preferred", "", "");
         Assert.IsTrue(strAtrib2.Equals("198"), "Preferred!=198");
      }


      [TestMethod]
      public virtual void testInsertBefore()
      {
         XMLDoc jdfDoc = new XMLDoc("Test", "www.test.com");
         KElement e = jdfDoc.getRoot();
         KElement k1 = (KElement)jdfDoc.createElement("second");
         KElement k2 = (KElement)jdfDoc.createElement("first");
         KElement k01 = (KElement)e.InsertBefore(k1, null);
         KElement k02 = (KElement)e.InsertBefore(k2, k1);
         Assert.AreEqual(k1, k01);
         Assert.AreEqual(k2, k02);
         Assert.AreEqual(k1, k2.getNextSiblingElement());

      }


      [TestMethod]
      public virtual void testHasAttributeNS()
      {
         XMLDoc jdfDoc = new XMLDoc("a:Test", "www.a.com");
         KElement e = jdfDoc.getRoot();
         e.setAttribute("a:foo", "bar");
         e.setAttribute("bar", "bar2");
         Assert.IsTrue(e.hasAttribute("foo"));
         Assert.IsTrue(e.hasAttribute("a:foo"), "");
         Assert.IsTrue(e.hasAttribute("bar"));
         Assert.IsTrue(e.hasAttribute("a:bar"), "");
      }


      [TestMethod]
      public virtual void testInfinity()
      {
         XMLDoc jdfDoc = new XMLDoc("Test", "www.test.com");
         KElement e = jdfDoc.getRoot();
         e.setAttribute("inf", int.MaxValue, null);
         e.setAttribute("minf", int.MinValue, null);
         Assert.AreEqual(JDFConstants.POSINF, e.getAttribute("inf", null, null), "inf");
         Assert.AreEqual(JDFConstants.NEGINF, e.getAttribute("minf", null, null), "minf");
         Assert.AreEqual(int.MaxValue, e.getIntAttribute("inf", null, 0), "inf");
         Assert.AreEqual(int.MinValue, e.getIntAttribute("minf", null, 0), "minf");
         // now double
         e.setAttribute("inf", double.MaxValue, null);
         e.setAttribute("minf", -double.MaxValue, null);
         Assert.AreEqual(JDFConstants.POSINF, e.getAttribute("inf", null, null), "inf");
         Assert.AreEqual(JDFConstants.NEGINF, e.getAttribute("minf", null, null), "minf");
         Assert.AreEqual(double.MaxValue, e.getRealAttribute("inf", null, 0), 0.0, "inf");
         Assert.AreEqual(-double.MaxValue, e.getRealAttribute("minf", null, 0), 0.0, "minf");
      }


      [TestMethod]
      public virtual void testSetAttribute_LongAttValue()
      {
         JDFDoc jdfDoc = new JDFDoc(ElementName.JDF);
         JDFNode root = (JDFNode)jdfDoc.getRoot();
         string longString = "";
         for (int i = 0; i < 13; i++)
            longString += longString + "0 123456789abcdefghijklmnopqrstuvwxyz";

         root.setAttribute("long", longString);
         Assert.AreEqual(longString, root.getAttribute("long"));
         jdfDoc.write2File(sm_dirTestDataTemp + "longAtt.jdf", 2, false);
         jdfDoc = new JDFDoc();
         jdfDoc = JDFDoc.parseFile(sm_dirTestDataTemp + "longAtt.jdf");
         root = jdfDoc.getJDFRoot();
         Assert.AreEqual(longString, root.getAttribute("long"));
      }


      [TestMethod]
      public virtual void testSetAttributes()
      {
         XMLDoc jdfDoc = new XMLDoc("Foo", null);
         KElement root = jdfDoc.getRoot();
         KElement a = root.appendElement("a");
         a.setAttribute("a", "1", null);
         a.setAttribute("b:b", "2", "www.b.com");
         XMLDoc jdfDoc2 = new XMLDoc("Foo", null);
         KElement root2 = jdfDoc2.getRoot();
         KElement a2 = root2.appendElement("a");
         a2.setAttributes(a);
         Assert.AreEqual("1", a2.getAttribute("a"));
         Assert.AreEqual("2", a2.getAttribute("b", "www.b.com", null));
      }


      [TestMethod]
      public virtual void testSetAttributesResource()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode n = doc.getJDFRoot();
         JDFExposedMedia x = (JDFExposedMedia)n.addResource("ExposedMedia", EnumUsage.Input);
         x.setAgentName("a1");
         JDFExposedMedia x2 = (JDFExposedMedia)x.addPartition(EnumPartIDKey.SignatureName, "S1");
         KElement e2 = n.appendElement("foo");
         e2.setAttributes(x2);
         Assert.AreEqual("a1", e2.getAttribute("AgentName"), "root resource attributes not copied");
         Assert.AreEqual("S1", e2.getAttribute("SignatureName"), "leaf resource attributes not copied");
      }


      [TestMethod]
      public virtual void testSetAttribute()
      {
         JDFDoc jdfDoc = new JDFDoc(ElementName.JDF);
         JDFNode root = (JDFNode)jdfDoc.getRoot();

         string nodeName = "Created";
         KElement kElem = root.getXPathElement("AuditPool/" + nodeName);
         Assert.IsTrue(kElem.Name.Equals(nodeName), "");

         // does setAttribute really set an empty value?
         kElem.setAttribute("Author", "");
         Assert.IsTrue(kElem.getAttribute("Author", null, null).Equals(""), "");

         Assert.IsTrue(kElem.hasAttribute("Author", "", false), "");
         Assert.IsFalse(kElem.hasAttribute("NewAttribute", "", false), "");

         kElem.setAttribute("Author", "", AttributeName.XMLNSURI);
         kElem.setAttribute("NewAttribute", "");
         Assert.IsTrue(kElem.getAttribute("NewAttribute", null, null).Equals(""), "");
         kElem.setAttribute("foo", "הצü\"\'");
         Assert.AreEqual("הצü\"\'", kElem.getAttribute("foo", null, null), "special characters");
      }


      [TestMethod]
      public virtual void testSetAttributeNS()
      {
         XMLDoc doc = new XMLDoc("a", null);
         KElement root = doc.getRoot();
         root.setAttribute("n:b", "1", "www.n.com");
         Assert.AreEqual("1", root.getAttribute("n:b"));
         Assert.AreEqual("1", root.getAttribute("n:b", "www.n.com", null));
         Assert.AreEqual("1", root.getAttribute("b", "www.n.com", null));
         root.setAttribute("n:b", (string)null, "www.n.com");
         Assert.IsNull(root.getAttribute("n:b", null, null));
         Assert.IsNull(root.getAttribute("n:b", "www.n.com", null));
         Assert.IsNull(root.getAttribute("b", "www.n.com", null));
      }


      [TestMethod]
      public virtual void testCache()
      {
         XMLDoc d1 = new XMLDoc("d1", null);
         XMLDoc d2 = new XMLDoc("d2", null);
         Assert.IsNotNull(d1.getXMLDocUserData());
         Assert.IsNotNull(d2.getXMLDocUserData());
         Assert.IsTrue(d1.getXMLDocUserData().getIDCache());
         KElement e1 = d1.getRoot();
         KElement e2 = d2.getRoot();
         for (int i = 0; i < 4; i++)
         {
            e1.setXPathAttribute("e2/e3" + Convert.ToString(i) + "/@ID", "i1" + Convert.ToString(i));
            e2.setXPathAttribute("e2/e3" + Convert.ToString(i) + "/@ID", "i2" + Convert.ToString(i));
         }
         KElement e13 = e2.getTarget("i13", "ID");
         Assert.IsNull(e13);
         e13 = e1.getTarget("i13", "ID");
         Assert.IsNotNull(e13);
         Assert.AreEqual(d1, e1.getOwnerDocument_KElement());
         KElement e23 = e2.getTarget("i23", "ID");
         Assert.IsNotNull(e23);
         Assert.AreEqual(d2, e2.getOwnerDocument_KElement());
         e1.moveElement(e23, null);
         e23 = e2.getTarget("i23", "ID");
         Assert.IsNull(e23);
         e23 = e1.getTarget("i23", "ID");
         Assert.IsNotNull(e23);
         Assert.AreEqual(d1, e23.getOwnerDocument_KElement());
         e23.deleteNode();
         e23 = e1.getTarget("i23", "ID");
         Assert.IsNull(e23);

         e23 = e2.getTarget("i22", "ID");
         Assert.IsNotNull(e23);
         //C# renameElement only returns the renamed element.
         e23 = e23.renameElement("fnarf", null);
         KElement e24 = e23;
         Assert.AreEqual(e24, e23);
         Assert.AreEqual("fnarf", e24.Name);
         Assert.AreEqual("fnarf", e24.LocalName);
         Assert.AreEqual(e24, e2.getTarget("i22", "ID"));
      }


      [TestMethod]
      public virtual void testGetElementHashMap()
      {
         XMLDoc d = new XMLDoc("root", null);
         KElement root = d.getRoot();
         for (int i = 0; i < 1000; i++)
         {
            KElement c = root.appendElement("child1");
            c.setAttribute("ID", "id1_" + Convert.ToString(i));
            c.setAttribute("II", "abc");
            c = root.appendElement("ns:child2", "myns");
            c.setAttribute("ID", "id2_" + JDFElement.uniqueID(0));
         }
         Assert.AreEqual(2000, root.getElementHashMap(null, null, "ID").Count, "");
         Assert.AreEqual(1000, root.getElementHashMap(null, "myns", "ID").Count, "");
         Assert.AreEqual(root.getElementHashMap(null, null, "ID")["id1_50"], root.getChildByTagName("child1", null, 0, new JDFAttributeMap("ID", "id1_50"), true, true), "");
      }


      [TestMethod]
      public virtual void testGetElement_KElement()
      {
         XMLDoc d = new XMLDoc("JDF", null);
         KElement root = d.getRoot();
         KElement c1 = root.appendElement("c");
         KElement c2 = root.appendElement("c");
         KElement b1 = root.appendElement("b");
         KElement c3 = root.appendElement("c");
         c3.setAttribute("ID", "i1");
         KElement @ref = root.appendElement("dRef");

         Assert.AreEqual(c1, root.getElement("c"));
         Assert.AreEqual(root.FirstChild, root.getElement(null));
         Assert.AreEqual(@ref, root.getElement("dRef"));

         Assert.IsNull(root.getElement("d"));
         Assert.AreEqual(b1, root.getElement("b"));
         Assert.AreEqual(c1, root.getElement_KElement("c", null, 0));
         Assert.AreEqual(b1, root.getElement_KElement("b", null, -1));
         Assert.AreEqual(c1, root.getElement_KElement("c", null, -3));
         Assert.AreEqual(c3, root.getElement_KElement("c", null, -1));
         Assert.AreEqual(c2, root.getElement_KElement("c", null, 1));
         Assert.AreEqual(c2, root.getElement_KElement("c", null, -2));
         Assert.AreEqual(c1, root.getElement_KElement(null, null, -5));
         Assert.AreEqual(c3, root.getElement_KElement(null, null, 3));
         Assert.IsNull(root.getElement_KElement("c", null, -4));
         Assert.IsNull(root.getElement_KElement("c", null, 3));
      }


      [TestMethod]
      public virtual void testGetElementsByTagName_KElement()
      {
         JDFDoc d = creatXMDoc();
         JDFNode n = d.getJDFRoot();
         Assert.IsNotNull(n.getElementsByTagName_KElement("*", null));
         Assert.IsNotNull(n.getElementsByTagName_KElement("", null));
         Assert.IsNotNull(n.getElementsByTagName_KElement(null, null));
      }


      [TestMethod]
      public virtual void testGetChildrenByTagName()
      {
         string xmlFile = "getChildrenByTagNameTest.jdf";

         JDFParser p = new JDFParser();
         JDFDoc jdfDoc = p.parseFile(sm_dirTestData + xmlFile);

         JDFNode jdfRoot = (JDFNode)jdfDoc.getRoot();
         JDFResourcePool jdfPool = jdfRoot.getResourcePool();
         VElement v = jdfPool.getChildrenByTagName("RunList", null, null, false, true, 0);
         Assert.AreEqual(10, v.Count, "Wrong number of child elements found");
         v = jdfPool.getChildrenByTagName("RunList", null, null, false, true, -1);
         Assert.AreEqual(10, v.Count, "Wrong number of child elements found");
         v = jdfPool.getChildrenByTagName("RunList", null, null, false, true, 5);
         Assert.AreEqual(5, v.Count, "Wrong number of child elements found");
      }


      [TestMethod]
      public virtual void testGetChildrenFromList()
      {
         XMLDoc doc = new XMLDoc("Foo", null);
         KElement root = doc.getRoot();
         KElement a = root.appendElement("a");
         KElement b = a.appendElement("b");
         KElement b2 = a.appendElement("b:b", "s");
         Assert.IsTrue(root.getChildrenFromList(new VString("b", " "), null, false, null).Contains(b));
         Assert.IsTrue(root.getChildrenFromList(new VString("b", " "), null, false, null).Contains(b2));
         Assert.IsTrue(root.getChildrenFromList(new VString("b:b", " "), null, false, null).Contains(b2));
         Assert.IsFalse(root.getChildrenFromList(new VString("b:b", " "), null, false, null).Contains(b));
      }


      [TestMethod]
      public virtual void testGetChildWithAttribute()
      {
         XMLDoc doc = new XMLDoc("Foo", null);
         KElement root = doc.getRoot();
         Assert.AreEqual(0, root.getChildElementArray().Length);
         root.appendElement("bar:bar", "www.bar.com");
         KElement bar2 = root.appendElement("bar2");
         bar2.setAttribute("foo", "1");
         bar2.setAttribute("ID", "id2");
         KElement bar3 = bar2.appendElement("bar3");
         bar3.setAttribute("foo", "1");
         bar3.setAttribute("foo2", "2");
         bar3.setAttribute("ID", "id3");
         Assert.AreEqual(bar3, root.getChildWithAttribute(null, "foo2", null, null, 0, false));
         Assert.AreEqual(bar2, root.getChildWithAttribute(null, "foo", null, null, 0, false));
         Assert.AreEqual(bar3, root.getChildWithAttribute(null, "foo", null, null, 1, false));
         Assert.AreEqual(bar2, root.getChildWithAttribute(null, "foo", null, null, 0, true));
         Assert.AreEqual(bar2, root.getChildWithAttribute(null, "foo", null, "1", 0, true));
         Assert.AreEqual(bar2, root.getChildWithAttribute(null, "ID", null, "id2", 0, true));
         Assert.IsNull(root.getChildWithAttribute(null, "ID", null, "id3", 0, true));

         XMLDoc doc2 = new XMLDoc("Foo", null);
         KElement root2 = doc2.getRoot();
         KElement bar22 = root2.appendElement("bar2");
         bar22.setAttribute("ID", "id22");
         Assert.AreEqual(bar22, root2.getChildWithAttribute(null, "ID", null, "id22", 0, true));
         Assert.IsNull(root.getChildWithAttribute(null, "ID", null, "id22", 0, true));
         bar3.moveElement(bar22, null);
         Assert.IsNull(root2.getChildWithAttribute(null, "ID", null, "id22", 0, true));
      }


      [TestMethod]
      public virtual void testGetChildElementVector_KElement()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode n = doc.getJDFRoot();
         JDFResource r = n.addResource(ElementName.EXPOSEDMEDIA, null, null, null, null, null, null);
         JDFResource rp = r.addPartition(EnumPartIDKey.Side, EnumSide.Front.getName());
         VElement v = r.getChildElementVector_KElement(ElementName.EXPOSEDMEDIA, null, null, true, 0);
         Assert.AreEqual(rp, v[0]);
         Assert.AreEqual(1, v.Count);
         JDFResource r2 = rp.addPartition(EnumPartIDKey.SheetName, "s2");
         v = r.getChildElementVector_KElement(ElementName.EXPOSEDMEDIA, null, null, true, 0);
         Assert.AreEqual(rp, v[0]);
         Assert.AreEqual(1, v.Count);
         JDFResource r3 = rp.addPartition(EnumPartIDKey.SheetName, "s3");
         JDFAttributeMap map = new JDFAttributeMap(AttributeName.SHEETNAME, "s2");
         v = rp.getChildElementVector_KElement(ElementName.EXPOSEDMEDIA, null, map, true, 0);
         Assert.IsTrue(v.Contains(r2));
         Assert.IsFalse(v.Contains(r3));
      }


      [TestMethod]
      public virtual void testGetChildElementArray()
      {
         XMLDoc doc = new XMLDoc("Foo", null);
         KElement root = doc.getRoot();
         Assert.AreEqual(0, root.getChildElementArray().Length);
         root.appendElement("bar:bar", "www.bar.com");
         root.appendElement("bar2");
         Assert.AreEqual(2, root.getChildElementArray().Length);
         Assert.AreEqual(root.getElement("bar:bar"), root.getChildElementArray()[0]);
         Assert.AreEqual(root.getElement("bar2"), root.getChildElementArray()[1]);
      }


      [TestMethod]
      public virtual void testAttributeInfo()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         VString s = n.getNamesVector("Status");
         Assert.IsTrue(s.Contains("InProgress"), "Status enum");
      }


      [TestMethod]
      public virtual void testPushUp()
      {
         { // defines a logical test block
            // pushup from 4 to 1
            JDFDoc jdfDoc = new JDFDoc(ElementName.JDF);
            JDFNode root = (JDFNode)jdfDoc.getRoot();
            KElement e = root;
            for (int i = 0; i < 5; i++)
            {
               e = e.appendElement("Test" + i, null);
            }
            e.pushUp("Test1");
            KElement k = root.getXPathElement("Test0/Test1");
            VElement v = k.getChildElementVector("Test4", null, new JDFAttributeMap(), true, 99999, false);
            Assert.IsTrue(v.Count == 1, "pushUp does not work");
         }

         { // defines a logical test block
            // pushup with emptystring
            JDFDoc jdfDoc = new JDFDoc(ElementName.JDF);
            JDFNode root = (JDFNode)jdfDoc.getRoot();
            KElement e = root;
            for (int i = 0; i < 5; i++)
            {
               e = e.appendElement("Test" + i, null);
            }
            e.pushUp("");
            KElement k = root.getXPathElement("Test0/Test1/Test2");
            VElement v = k.getChildElementVector("Test4", null, new JDFAttributeMap(), true, 99999, false);
            Assert.IsTrue(v.Count == 1, "pushUp does not work");
         }

         { // defines a logical test block
            // pushup and force parentNode == null
            JDFDoc jdfDoc = new JDFDoc(ElementName.JDF);
            JDFNode root = (JDFNode)jdfDoc.getRoot();
            KElement e = root;
            for (int i = 0; i < 5; i++)
            {
               e = e.appendElement("Test" + i, null);
            }
            KElement k = e.pushUp("Foo");
            Assert.IsTrue(k == null);
         }
      }


      [TestMethod]
      public virtual void testSetAttribute_DoubleAtt()
      {
         JDFParser p = new JDFParser();
         {
            XMLDoc doc = new XMLDoc("d", null);
            KElement root = doc.getRoot();
            root.setAttribute("a:b", "a1");
            string s2 = doc.write2String(0);
            XMLDoc doc2 = p.parseString(s2);
            Assert.IsNull(doc2, "invalid ns stuff");
            root.setAttributeNS("www.a.com", "a:b", "a2");
            s2 = doc.write2String(0);
            doc2 = p.parseString(s2);
            Assert.IsNotNull(doc2, "invalid ns stuff");
            KElement root2 = doc2.getRoot();
            root2.setAttribute("a:b", "a2", "www.a.com");
            root.setAttribute("a:b", "a2", "www.a.com");

            string s = doc.write2String(0);
            p.parseString(s);
            s2 = doc.write2String(0);
            p.parseString(s2);
         }
         {
            XMLDoc doc = new XMLDoc("d", null);
            KElement root = doc.getRoot();
            root.setAttribute("a:b", "a2", "www.a.com");
            root.setAttribute("a:b", "a1");
            string s = doc.write2String(0);
            doc = p.parseString(s);
            root = doc.getRoot();
            root.setAttribute("a:b", "a3");
            s = doc.write2String(0);
            doc = p.parseString(s);
         }
      }


      [TestMethod]
      public virtual void testSetAttribute_NameSpaceHandling()
      {
         for (int dd = 0; dd < 2; dd++)
         {
            JDFDoc jdfDoc = new JDFDoc(ElementName.JDF);
            JDFNode root = (JDFNode)jdfDoc.getRoot();
            KElement e = root;

            root.setAttribute("xmlns:Kai", "foo");
            KElement appended = e.appendElement("Kai:Test1", "foo");
            appended.setAttribute("Kai:Test1", "1", "foo");
            // no try to change the namespace and append
            e.setAttribute("xmlns:Kai", "faa");
            appended.setAttribute("Kai:Test1", "2", null);
            root.setAttribute("aa", "bb");
            root.setAttribute("aa", "bb", null);
            Assert.IsTrue(root.hasAttribute("aa"));

            KElement c = root.appendElement("Comment", null);
            Assert.IsTrue(c.getNamespaceURI().Equals(root.getNamespaceURI()), "ns append ok");
            KElement f = root.insertBefore("fnarf", c, null);
            Assert.IsTrue(f.getNamespaceURI().Equals(root.getNamespaceURI()), "ns insert ok");
            Assert.IsTrue(!String.IsNullOrEmpty(f.getNamespaceURI()), "ns  ok");
            Assert.IsTrue(f.getNamespaceURI().Equals(JDFConstants.JDFNAMESPACE), "ns  ok");
            KElement f2 = root.insertBefore("fnarf:fnarf", c, "www.fnarf");
            Assert.IsTrue(f2.getNamespaceURI().Equals("www.fnarf"), "ns  ok");

            // try to add an element into an unspecified namespace MUST FAIL
            try
            {
               e.appendElement("Kai:Test1");
               // assume that the namespace will be added later fail("snafu");
            }
            catch (JDFException)
            {
               // do nothing
            }

            string testIt = jdfDoc.write2String(0);
            JDFParser p = new JDFParser();
            JDFDoc d2 = p.parseString(testIt);
            root = (JDFNode)d2.getRoot();
            // root.setAttribute("aa","cc");
            root.setAttribute("aa", "nsns", root.getNamespaceURI());
            Assert.IsFalse(root.hasAttribute("ns1:aa"), "no ns1");
            Assert.AreEqual("nsns", root.getAttribute("aa", root.getNamespaceURI(), null), "no ns1");
            root.setAttribute("bb:aa", "nsnt", root.getNamespaceURI());
            Assert.IsTrue(root.hasAttribute("aa"), "ns1 default");
            Assert.IsTrue(root.hasAttribute("bb:aa"), "no ns1");
            Assert.AreEqual("nsnt", root.getAttribute("aa", root.getNamespaceURI(), null), "no ns1");
            Assert.AreEqual("nsnt", root.getAttribute("aa", null, null), "no ns1");
         }
      }


      [TestMethod]
      public virtual void testXMLNameSpace()
      {
         Assert.IsNull(KElement.xmlnsPrefix("abc"), "no ns");
         Assert.IsNull(KElement.xmlnsPrefix(":abc"), "no ns");
         Assert.AreEqual("ns", KElement.xmlnsPrefix("ns:abc"), "ns");
         Assert.AreEqual("abc", KElement.xmlnsLocalName("ns:abc"), "ns");
         Assert.IsNull(KElement.xmlnsLocalName("abc:"), "no local name");
         Assert.IsNull(KElement.xmlnsLocalName(null), "no local name");
      }


      [TestMethod]
      public virtual void testAppendChild()
      {
         XMLDoc d = new XMLDoc("e", null);
         KElement e = d.getRoot();
         e.setAttribute("xmlns:foo", "www.foo.com");
         KElement e2 = (KElement)d.createElement("e2");
         e.appendChild(e2);
         Assert.AreEqual(e2, e.FirstChild);
         KElement e3 = (KElement)d.createElement("foo:e3");
         Assert.IsTrue(String.IsNullOrEmpty(e3.getNamespaceURI()));
         e.appendChild(e3);
         Assert.AreEqual(e3, e2.NextSibling);
         Assert.AreEqual("www.foo.com", e3.getNamespaceURI());
      }


      [TestMethod]
      public virtual void testAppendCData()
      {
         XMLDoc d = new XMLDoc("e", null);
         KElement e = d.getRoot();
         XMLDoc d2 = new XMLDoc("e2", null);
         KElement e2 = d2.getRoot();
         e.appendCData(e2);
         Assert.IsTrue(e.ToString().IndexOf("<e2") > 0);
         e.appendCData(e);
         JDFParser p = new JDFParser();
         JDFDoc d3 = p.parseString(d.write2String(2));
         Assert.IsNotNull(d3);
      }


      [TestMethod]
      public virtual void testParseAppendChild()
      {
         string s = "<e xmlns=\"a\" xmlns:foo=\"www.foo.com\"><e2/></e>";
         JDFParser p = new JDFParser();
         p.bKElementOnly = true;
         p.ignoreNSDefault = true;

         XMLDoc d = p.parseString(s);
         KElement e = d.getRoot();
         KElement e3 = (KElement)d.createElement("foo:e3");
         Assert.IsTrue(String.IsNullOrEmpty(e3.getNamespaceURI()));
         e.appendChild(e3);
         KElement e2 = (KElement)e.FirstChild;
         Assert.AreEqual(e3, e2.NextSibling);
         Assert.IsTrue(String.IsNullOrEmpty(e3.getNamespaceURI()));
         KElement e4 = (KElement)d.createElement("foo:e3");
         Assert.IsTrue(String.IsNullOrEmpty(e4.getNamespaceURI()));
         e.appendChild(e4);
         Assert.IsTrue(String.IsNullOrEmpty(e4.getNamespaceURI()));
      }


      [TestMethod]
      public virtual void testSetXMLComment()
      {
         XMLDoc d = new XMLDoc("e", null);
         KElement root = d.getRoot();
         root.setXMLComment("foo");
         Assert.AreEqual("foo", d.getDocumentElement().ParentNode.FirstChild.Value);
         root.setXMLComment("bar");
         Assert.AreEqual("bar", d.getDocumentElement().ParentNode.FirstChild.Value);
         KElement e2 = root.appendElement("e2");
         e2.setXMLComment("foobar");
         Assert.AreEqual("foobar", root.FirstChild.Value);
         e2.setXMLComment("foobar2");
         Assert.AreEqual("foobar2", root.FirstChild.Value);
         Assert.AreEqual(e2, root.FirstChild.NextSibling);
         Assert.IsNull(root.FirstChild.NextSibling.NextSibling);
      }


      [TestMethod]
      public virtual void testAppendElement()
      {
         XMLDoc d = new XMLDoc("e", null);
         KElement e = d.getRoot();
         Assert.IsTrue(String.IsNullOrEmpty(e.getNamespaceURI()));
         KElement foo = e.appendElement("pt:foo", "www.pt.com");
         Assert.AreEqual("www.pt.com", foo.getNamespaceURI());
         KElement bar = foo.appendElement("bar");
         Assert.IsTrue(String.IsNullOrEmpty(bar.getNamespaceURI()));
         bar.setAttribute("xmlns", "www.bar.com");

         KElement bar2 = bar.appendElement("bar");
         Assert.AreEqual("www.bar.com", bar2.getNamespaceURI());

         KElement foo2 = bar.appendElement("pt:foo", "www.pt.com");
         Assert.AreEqual("www.pt.com", foo2.getNamespaceURI());

         d.getMemberDocument().setIgnoreNSDefault(true);
         KElement bar3 = bar.appendElement("bar");
         Assert.IsTrue(String.IsNullOrEmpty(bar3.getNamespaceURI()));
         KElement bar4 = bar2.appendElement("bar");
         Assert.IsTrue(String.IsNullOrEmpty(bar4.getNamespaceURI()));
      }


      [TestMethod]
      public virtual void testAppendElement_NSAtt()
      {
         XMLDoc d = new XMLDoc("e", null);
         KElement e = d.getRoot();
         Assert.IsTrue(String.IsNullOrEmpty(e.getNamespaceURI()));
         e.setAttribute("xmlns:pt", "www.pt.com");
         KElement foo = e.appendElement("foo", null);
         Assert.IsTrue(String.IsNullOrEmpty(foo.getNamespaceURI()));
         KElement bar = foo.appendElement("bar");
         Assert.IsTrue(String.IsNullOrEmpty(bar.getNamespaceURI()));
         KElement bar2 = foo.appendElement("pt:bar");
         Assert.AreEqual("www.pt.com", bar2.getNamespaceURI());
      }


      [TestMethod]
      public virtual void testAppendElement_NSAttJDFDoc()
      {
         JDFDoc d = new JDFDoc("e");
         d.getMemberDocument().setIgnoreNSDefault(true);
         string url = JDFElement.getSchemaURL();
         {
            KElement e = d.getRoot();
            Assert.AreEqual(url, e.getNamespaceURI());
            e.setAttribute("xmlns:pt", "www.pt.com");
            KElement foo = e.appendElement("foo", null);
            Assert.AreEqual(url, foo.getNamespaceURI());
            KElement bar = foo.appendElement("bar");
            Assert.AreEqual(url, bar.getNamespaceURI());
            KElement bar2 = foo.appendElement("pt:bar");
            Assert.AreEqual("www.pt.com", bar2.getNamespaceURI());
         }
         string s = d.write2String(0);

         // now check for parsed document with no default xmlns declaration
         JDFParser p = new JDFParser();
         int pos = s.IndexOf(url);
         s = s.Substring(0, pos - 7) + s.Substring(pos + url.Length + 1); //+/-
         // for
         // xmlns
         // =
         // " and "
         d = p.parseString(s);
         d.getMemberDocument().setIgnoreNSDefault(true);
         {
            KElement e = d.getRoot();
            Assert.IsTrue(String.IsNullOrEmpty(e.getNamespaceURI()));
            e.setAttribute("xmlns:pt", "www.pt.com");
            KElement foo = e.appendElement("foo", null);
            Assert.IsTrue(String.IsNullOrEmpty(foo.getNamespaceURI()));
            KElement bar = foo.appendElement("bar");
            Assert.IsTrue(String.IsNullOrEmpty(bar.getNamespaceURI()));
            KElement bar2 = foo.appendElement("pt:bar");
            Assert.AreEqual("www.pt.com", bar2.getNamespaceURI());
         }
      }


      [TestMethod]
      public virtual void testAppendElement_SingleNS()
      {
         for (int i = 0; i < 2; i++)
         {
            const string wwwECom = "www.e.com";
            XMLDoc d = i == 0 ? new XMLDoc() : new JDFDoc();
            d.setRoot("e", wwwECom);
            KElement e = d.getRoot();
            e.addNameSpace(null, wwwECom);
            Assert.AreEqual(wwwECom, e.getNamespaceURI());
            KElement foo = e.appendElement("f", null);
            Assert.AreEqual(wwwECom, foo.getNamespaceURI());
            foo = e.appendElement("f", "");
            Assert.AreEqual(wwwECom, foo.getNamespaceURI());
         }
      }


      [TestMethod]
      public virtual void testCreateElement_NoNS()
      {
         for (int i = 0; i < 2; i++)
         {
            const string wwwECom = "www.e.com";
            XMLDoc d = i == 0 ? new XMLDoc() : new JDFDoc();
            d.setRoot("e", wwwECom);
            KElement e = d.getRoot();
            Assert.AreEqual(wwwECom, e.getNamespaceURI());
            XmlElement eFoo = d.createElement("f");
            e.appendChild(eFoo);
            XmlElement eBar = d.createElement("b");
            eFoo.AppendChild(eBar);
            Assert.AreEqual(wwwECom, eBar.NamespaceURI);
            Assert.AreEqual(wwwECom, eFoo.NamespaceURI);
            eFoo = d.createElementNS(wwwECom, "f");
            e.appendChild(eFoo);
            Assert.AreEqual(wwwECom, eFoo.NamespaceURI);
         }
      }


      [TestMethod]
      public virtual void testParse_SingleNS()
      {
         const string wwwECom = "www.e.com";
         XMLDoc d = new XMLDoc("e", wwwECom);
         KElement e = d.getRoot();
         Assert.AreEqual(wwwECom, e.getNamespaceURI());
         KElement foo = e.appendElement("f", null);
         Assert.AreEqual(wwwECom, foo.getNamespaceURI());
         string s = d.write2String(2);
         JDFParser p = new JDFParser();
         JDFDoc d2 = p.parseString(s);
         KElement e2 = d2.getRoot();
         Assert.AreEqual(wwwECom, e2.getNamespaceURI());
         KElement foo2 = e.appendElement("f", null);
         Assert.AreEqual(wwwECom, foo2.getNamespaceURI());
         Assert.AreEqual(-1, d2.write2String(2).IndexOf("jdf"));
      }


      [TestMethod]
      public virtual void testAppendXMLComment()
      {
         XMLDoc d = new XMLDoc("e", null);
         KElement e = d.getRoot();
         VString v = new VString("a . - . -- . -->.<!--", ".");
         for (int i = 0; i < v.Count; i++)
         {
            string s = v.stringAt(i);
            e.appendXMLComment(s, null);
            d.write2File(sm_dirTestDataTemp + "xmlComment.jdf", 2, false);
            XMLDoc d2 = new JDFParser().parseFile(sm_dirTestDataTemp + "xmlComment.jdf");
            KElement e2 = d2.getRoot();
            s = StringUtil.replaceString(s, "--", "__");
            Assert.AreEqual(s, e.getXMLComment(i));
            Assert.AreEqual(s, e2.getXMLComment(i));
         }
      }


      [TestMethod]
      public virtual void testAppendAttribute()
      {
         XMLDoc d = new XMLDoc("e", null);
         KElement e = d.getRoot();
         e.appendAttribute("at", "a", null, " ", false);
         e.appendAttribute("at", "b", null, " ", false);
         e.appendAttribute("at", "c", null, " ", false);
         Assert.AreEqual("a b c", e.getAttribute("at"), "a b c");
         e.appendAttribute("at", "c", null, " ", true);
         Assert.AreEqual("a b c", e.getAttribute("at"), "a b c");
         e.appendAttribute("at", "c", null, " ", false);
         Assert.AreEqual("a b c c", e.getAttribute("at"), "a b c c");
         e.appendAttribute("at", "a a b c", null, null, true);
         Assert.AreEqual("a b c c a a b c", e.getAttribute("at"), "a b c c a a b c");
         e.appendAttribute("ns:key", "na", "www.ns.com", " ", true);
         Assert.AreEqual("na", e.getAttribute("key", "www.ns.com", ""), "ns a");
         e.appendAttribute("ns:key", "nb", null, " ", true);
         Assert.AreEqual("na nb", e.getAttribute("ns:key"), "ns ab");
         e.appendAttribute("ns:key", "nc", "www.ns.com", " ", true);
         Assert.AreEqual("na nb nc", e.getAttribute("key", "www.ns.com", ""), "ns a b c");
         Assert.AreEqual("na nb nc", e.getAttribute("ns:key"), "ns a b c");
      }


      [TestMethod]
      public virtual void testTypeInfo() // commented out due to Java 1.4 1.5 package
      // incompatibilities
      {
         // XMLDoc d = new XMLDoc("doc", null);
         // KElement root = d.getRoot();
         // TypeInfo ti=root.getSchemaTypeInfo();
         // Assert.IsNotNull(ti);
      }


      [TestMethod]
      public virtual void testTextMethods()
      {
         XMLDoc d = new XMLDoc("doc", null);
         KElement root = d.getRoot();
         KElement e1 = root.appendElement("e1");
         e1.setAttribute("a", "b");

         e1.setText("foo");
         Assert.AreEqual("foo", e1.getText());
         Assert.IsTrue(e1.hasChildText());

         e1.setText("bar");
         Assert.AreEqual("bar", e1.getText());
         Assert.IsTrue(e1.hasChildText());

         e1.removeAllText();
         Assert.IsNull(e1.getText());
         Assert.IsFalse(e1.hasChildText());

         e1.appendText("foo");
         Assert.AreEqual("foo", e1.getText());
         Assert.IsTrue(e1.hasChildText());

         e1.appendText("bar");
         Assert.AreEqual("foobar", e1.getText());
         Assert.IsTrue(e1.hasChildText());

         Assert.AreEqual(e1.getNumChildText(), 2);
         Assert.AreEqual("foo", e1.getText(0));
         Assert.AreEqual("bar", e1.getText(1));
         Assert.IsTrue(e1.hasChildText());

         e1.removeChildText(1);
         Assert.AreEqual(1, e1.getNumChildText());
         Assert.AreEqual("foo", e1.getText(0));
         Assert.IsTrue(e1.hasChildText());

         e1.removeChildText(0);
         Assert.AreEqual(0, e1.getNumChildText());
         Assert.AreEqual(null, e1.getText(0)); // getText(i) can return null
         Assert.IsNull(e1.getText()); // getText() can return null !!!
         Assert.IsFalse(e1.hasChildText());

         e1.removeAllText();
         Assert.IsFalse(e1.hasChildText());

         KElement e2 = root.appendTextElement("e2", "text");
         Assert.AreEqual(1, e2.getNumChildText());
         Assert.AreEqual("text", e2.getText(0));
      }


      [TestMethod]
      public virtual void testFillHashSet()
      {
         XMLDoc d = new XMLDoc("doc", null);
         KElement root = d.getRoot();
         KElement e1 = root.appendElement("e1");
         e1.setAttribute("a", "b");
         e1.setAttribute("a2", "b");
         root.setAttribute("a", "aa");

         e1.setXPathAttribute("./e2/e3@a", "c");
         e1.setXPathAttribute("./e3/e4@a", "d");
         SupportClass.HashSetSupport h = new SupportClass.HashSetSupport();
         root.fillHashSet("a", null, h);

         Assert.IsTrue(h.Contains("aa"), "");
         Assert.IsTrue(h.Contains("b"), "");
         Assert.IsTrue(h.Contains("c"), "");
         Assert.IsTrue(h.Contains("d"), "");
         Assert.IsFalse(h.Contains("a2"), "");

         h.Clear();
         e1.fillHashSet("a", null, h);

         Assert.IsFalse(h.Contains("aa"), "");
         Assert.IsTrue(h.Contains("b"), "");
         Assert.IsTrue(h.Contains("c"), "");
         Assert.IsTrue(h.Contains("d"), "");
         Assert.IsFalse(h.Contains("a2"), "");
      }
   }
}