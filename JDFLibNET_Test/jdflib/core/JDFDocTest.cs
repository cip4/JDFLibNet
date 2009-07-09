
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
 * JDFDocTest.java
 * 
 * @author Kai Mattern
 *
 * Copyright (C) 2002 Heidelberger Druckmaschinen AG. All Rights Reserved.
 */

namespace org.cip4.jdflib.core
{
   using System;
   using System.IO;
   using Microsoft.VisualStudio.TestTools.UnitTesting;

   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using JDFJMF = org.cip4.jdflib.jmf.JDFJMF;
   using JDFMessage = org.cip4.jdflib.jmf.JDFMessage;
   using JDFNode = org.cip4.jdflib.node.JDFNode;

   [TestClass]
   public class JDFDocTest : JDFTestCaseBase
   {

      ///   
      ///	 <summary> * just a minor test. It only checks the precessgroup count and also the
      ///	 * class casts in GetProcessGroups </summary>
      ///	 
      [TestMethod]
      public virtual void testRoots()
      {
         string xmlFile = "job.jdf";

         JDFParser p = new JDFParser();
         JDFDoc jdfDoc = p.parseFile(sm_dirTestData + xmlFile);

         Assert.IsTrue(jdfDoc != null, xmlFile + ": Parse Error");
         if (jdfDoc == null)
            return; // soothe findbugs ;)

         Assert.IsNotNull(jdfDoc.getJDFRoot(), "jdf root");
         Assert.IsNull(jdfDoc.getJMFRoot(), "no jmf root");
      }

      ///   
      ///	 <summary> * just a minor test. It only checks that cloned docs are actually different </summary>
      ///	
      [TestMethod]
      public virtual void testClone()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFDoc d2 = (JDFDoc)d.clone();
         KElement e1 = d.getRoot();
         KElement e2 = d2.getRoot();
         Assert.AreNotEqual(e1, e2);
         e1.appendElement("foo");
         Assert.IsNull(e2.getElement("foo"));
      }


      [TestMethod]
      public virtual void testForeignRoot()
      {
         XMLDoc doc = new XMLDoc("Foo", "fooNS");
         KElement r = doc.getRoot();
         JDFNode n = new JDFDoc("JDF").getJDFRoot();
         r.copyElement(n, null);
         string s = doc.write2String(0);
         JDFParser p = new JDFParser();
         JDFDoc d = p.parseString(s);
         Assert.IsNotNull(d.getJDFRoot());
         Assert.IsNotNull(d.getRoot());
         Assert.AreNotEqual(d.getRoot(), d.getJDFRoot());

      }


      ///   
      ///	 <summary> * just a minor test. It only checks the precessgroup count and also the
      ///	 * class casts in GetProcessGroups </summary>
      ///	 
      [TestMethod]
      public virtual void testNull()
      {
         JDFDoc doc = null;
         string foo = "wehflkh";
         JDFParser p = new JDFParser();

         doc = p.parseString(foo);
         Assert.IsNull(doc);
         doc = new JDFDoc("JDF");
         Assert.IsNotNull(doc.getNodeName());
      }


      [TestMethod]
      public virtual void testGetContentType()
      {
         JDFDoc d = new JDFDoc("JDF");
         Assert.AreEqual("application/vnd.cip4-jdf+xml", d.getContentType());
         JDFDoc dm = new JDFDoc("JMF");
         Assert.AreEqual("application/vnd.cip4-jmf+xml", dm.getContentType());
         JDFDoc db = new JDFDoc("JMF_");
         Assert.AreEqual("text/xml", db.getContentType());
      }


      [TestMethod]
      public virtual void testSchemaDefault()
      {
         for (int i = 0; i < 3; i++)
         {
            JDFDoc doc = new JDFDoc("JDF");
            JDFNode n = (JDFNode)doc.getRoot();
            Assert.IsFalse(n.hasAttribute(AttributeName.TEMPLATE), "no schema - no default");
            string s = doc.write2String(2);
            JDFParser parser = new JDFParser();
            JDFDoc docNoSchema = parser.parseString(s);
            JDFNode as2 = (JDFNode)docNoSchema.getRoot();
            Assert.IsFalse(as2.hasAttribute(AttributeName.TEMPLATE), "no schema - no default");
            parser.m_SchemaLocation = sm_dirTestSchema + @"\JDF.xsd";
            JDFDoc docSchema = parser.parseString(s);
            JDFNode as3 = (JDFNode)docSchema.getRoot();
            Assert.IsTrue(as3.hasAttribute(AttributeName.TEMPLATE), "schema parse - default is set");
            Assert.IsFalse(as3.getTemplate(), "schema parse - default is set");
         }
      }


      [TestMethod]
      public virtual void testNS()
      {
         JDFDoc doc = new JDFDoc("foo:bar");
         string s = doc.write2String(2);
         Assert.IsTrue(s.IndexOf(JDFConstants.JDFNAMESPACE) > 0);
         XMLDoc doc2 = new XMLDoc("abc", null);
         string s2 = doc2.write2String(2);
         Assert.IsTrue(s2.IndexOf(JDFConstants.JDFNAMESPACE) < 0);
         doc2.getRoot().copyElement(doc.getRoot(), null);
         s2 = doc2.write2String(2);
         Assert.IsTrue(s2.IndexOf(JDFConstants.JDFNAMESPACE) > 0);

      }

      [TestMethod]
      public virtual void testPerformance()
      {
         {
            JDFDoc doc = new JDFDoc("JDF");
            KElement root = doc.getRoot();
            long l = DateTime.Now.Ticks;
            // Java to C# Conversion - Divide number of tests by 1000 for now
            for (int i = 0; i < 10; i++)
            {
               root.appendElement("Elem00");
            }
            Console.WriteLine("Append With factory: " + (DateTime.Now.Ticks - l));
            l = DateTime.Now.Ticks;
            string s = doc.write2String(0);
            Console.WriteLine("Write With factory: " + (DateTime.Now.Ticks - l));
            l = DateTime.Now.Ticks;
            JDFParser p = new JDFParser();
            Console.WriteLine("Parser With factory: " + (DateTime.Now.Ticks - l));
            l = DateTime.Now.Ticks;
            p.parseString(s);
            Console.WriteLine("Parse With factory: " + (DateTime.Now.Ticks - l));
         }
         {
            JDFDoc doc = new JDFDoc("JDF");
            KElement root = doc.getRoot();
            ((DocumentJDFImpl)root.OwnerDocument).bKElementOnly = true;
            long l = DateTime.Now.Ticks;
            // Java to C# Conversion - Divide number of tests by 1000 for now
            for (int i = 0; i < 10; i++)
            {
               root.appendElement("Elem00");
            }
            Console.WriteLine("Append Without factory: " + (DateTime.Now.Ticks - l));
            l = DateTime.Now.Ticks;
            string s = doc.write2String(0);
            Console.WriteLine("Write Without factory: " + (DateTime.Now.Ticks - l) + " " + s.Length);
            l = DateTime.Now.Ticks;
            JDFParser p = new JDFParser();
            Console.WriteLine("Parser Without factory: " + (DateTime.Now.Ticks - l));
            l = DateTime.Now.Ticks;
            p.parseString(s);
            Console.WriteLine("Parse Without factory: " + (DateTime.Now.Ticks - l));
         }

         {
            JDFDoc doc = new JDFDoc("JDF");
            KElement root = doc.getRoot();
            ((DocumentJDFImpl)root.OwnerDocument).bKElementOnly = true;
            long l = DateTime.Now.Ticks;
            // Java to C# Conversion - Divide number of tests by 1000 for now
            for (int i = 0; i < 10; i++)
            {
               root.appendElement("Elem00");
            }
            Console.WriteLine("Append00 Without factory: " + (DateTime.Now.Ticks - l));
            l = DateTime.Now.Ticks;
            string s = doc.write2String(0);
            Console.WriteLine("Write00 Without factory: " + (DateTime.Now.Ticks - l));
            l = DateTime.Now.Ticks;
            JDFParser p = new JDFParser();
            Console.WriteLine("Parser00 Without factory: " + (DateTime.Now.Ticks - l));
            l = DateTime.Now.Ticks;
            p.parseString(s);
            Console.WriteLine("Parse00 Without factory: " + (DateTime.Now.Ticks - l));
         }

         {
            JDFDoc doc = new JDFDoc("JDF");
            KElement root = doc.getRoot();
            long l = DateTime.Now.Ticks;
            // Java to C# Conversion - Divide number of tests by 1000 for now
            for (int i = 0; i < 10; i++)
            {
               root.appendElement("Elem00");
            }
            Console.WriteLine("Append With factory: " + (DateTime.Now.Ticks - l));
            l = DateTime.Now.Ticks;
            string s = doc.write2String(0);
            Console.WriteLine("Write With factory: " + (DateTime.Now.Ticks - l));
            l = DateTime.Now.Ticks;
            JDFParser p = new JDFParser();
            Console.WriteLine("Parser With factory: " + (DateTime.Now.Ticks - l));
            l = DateTime.Now.Ticks;
            p.parseString(s);
            Console.WriteLine("Parse With factory: " + (DateTime.Now.Ticks - l));
         }

      }

      ///   
      ///	 <summary> * make sure that corrupt files always return a null document
      ///	 *  </summary>
      ///	 
      [TestMethod]
      public virtual void testCorrupt()
      {
         JDFDoc doc = null;
         string foo = "wehflkh";
         JDFParser p = new JDFParser();
         doc = p.parseString(foo);
         Assert.IsNull(doc);
         foo = "<xxx><yyy><zzz></yyy></xxx>";
         doc = p.parseString(foo);
         Assert.IsNull(doc);

         doc = p.parseFile(sm_dirTestData + "corrupt.jdf");
         Assert.IsNull(doc);
         doc = new JDFDoc("JDF");
         Assert.IsNotNull(doc.getNodeName());
      }

      ///   
      ///     <summary> * 
      ///     * </summary>
      ///     
      [TestMethod]
      public virtual void testEmptyString()
      {
         JDFDoc inMessageDoc = new JDFDoc(ElementName.JMF);
         JDFJMF jmfIn = inMessageDoc.getJMFRoot();

         jmfIn.appendMessageElement(JDFMessage.EnumFamily.Response, null);
         string s = inMessageDoc.write2String(0);
         Assert.IsNotNull(s);
      }
   }
}