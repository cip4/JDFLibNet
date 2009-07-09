
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
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using FileUtil = org.cip4.jdflib.util.FileUtil;

   ///
   /// <summary> * @author Rainer Prosi, Heidelberger Druckmaschinen
   /// * </summary>
   ///
   [TestClass]
   public class JDFParserTest : JDFTestCaseBase
   {
      internal string s;
      internal bool bSearch;

      ///   
      ///	 <summary> * check speed of the parser
      ///	 *  </summary>
      ///	 
      [TestMethod]
      public virtual void testSpeed()
      {
         long l1 = DateTime.Now.Ticks;
         for (int i = 0; i < 1000; i++)
         {
            new JDFParser().parseString(s);
         }
         Console.WriteLine("new  p: " + (DateTime.Now.Ticks - l1) / 1000000);
      }

      ///   
      ///	 <summary> * check speed of the parser
      ///	 *  </summary>
      ///	 
      [TestMethod]
      public virtual void testSpeed1()
      {
         long l1 = DateTime.Now.Ticks;
         for (int i = 0; i < 1000; i++)
         {
            new JDFParser();
         }
         Console.WriteLine("new:   " + (DateTime.Now.Ticks - l1) / 1000000);
      }

      ///   
      ///	 <summary> * check speed of the parser
      ///	 *  </summary>
      ///	 
      [TestMethod]
      public virtual void testParseSpeed()
      {
         JDFParser parser = new JDFParser();
         //System.gc();
         long l1 = DateTime.Now.Ticks;
         JDFDoc d = parser.parseFile(sm_dirTestData + "bigWhite.jdf");
         Assert.IsNotNull(d);
         Console.WriteLine("big parse:   " + (DateTime.Now.Ticks - l1) / 1000000);
      }

      ///   
      ///	 <summary> * check simple parsestring
      ///	 *  </summary>
      ///	 
      [TestMethod]
      public virtual void testParseString()
      {
         JDFParser parser = new JDFParser();
         Assert.IsNotNull(parser.parseString(s));
      }

      ///   
      ///	 <summary> * check speed of the parser
      ///	 *  </summary>
      ///	 
      [TestMethod]
      public virtual void testBadNS()
      {
         string s2 = "<JMF/>";
         Assert.AreEqual("JMF", new JDFParser().parseString(s2).getRoot().LocalName);
      }

      ///   
      ///	 <summary> * check speed of the parser
      ///	 *  </summary>
      ///	 
      [TestMethod]
      public virtual void testSpeed2()
      {
         long l1 = DateTime.Now.Ticks;
         JDFParser p = new JDFParser();
         for (int i = 0; i < 1000; i++)
         {
            p.parseString(s);
         }
         Console.WriteLine("reuse: " + (DateTime.Now.Ticks - l1) / 1000000);
      }

      ///   
      ///	 <summary> * parse a string with guck up front
      ///	 *  </summary>
      ///	 * <exception cref="Exception"> </exception>
      ///	 
      [TestMethod]
      public virtual void testSkipParse()
      {
         JDFParser.m_searchStream = true;
         string s2 = "        ------ end of header ----!\n<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n <JMF/>";
         JDFParser.m_searchStream = false;
         Assert.IsNull(new JDFParser().parseString(s2));
      }

      ///   
      ///	 <summary> * parse a simple JDF against all official schemas
      ///	 * this test catches corrupt xmöl schemas </summary>
      ///	 * <exception cref="Exception"> </exception>
      ///	 
      [TestMethod]
      public virtual void testSchema()
      {
         DirectoryInfo foo = new DirectoryInfo(sm_dirTestSchema).Parent;

         Assert.IsTrue(foo.Exists, "please mount the svn schema parallel to jdflibJ");
         DirectoryInfo[] dirs = foo.GetDirectories(".*Version_.*");
         Assert.IsTrue(dirs.Length > 3);
         int nCheck = 0;
         for (int i = 0; i < dirs.Length; i++)
         {
            DirectoryInfo dir = dirs[i];
            if (!dir.Exists)
               continue;
            FileInfo jdfxsd = new FileInfo(dir + @"\JDF.xsd");
            Assert.IsTrue(jdfxsd.Exists);
            JDFParser p = new JDFParser();
            p.setJDFSchemaLocation(jdfxsd);
            Assert.IsNotNull(p.parseString(s), "oops in" + jdfxsd);
            nCheck++;
         }
         Assert.IsTrue(nCheck >= 3);
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.JDFTestCaseBase#setUp()
      //	 
      [TestInitialize]
      public override void setUp()
      {
         base.setUp();
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         JDFResource rl = n.addResource("RunList", EnumUsage.Input);
         rl.setDescriptiveName("Runlist für 10 € &&&"); // sum special characters
         s = d.write2String(2);
         bSearch = JDFParser.m_searchStream;
      }

      [TestCleanup]
      public override void tearDown()
      {
         // TODO Auto-generated method stub
         base.tearDown();
         JDFParser.m_searchStream = bSearch;
      }
   }
}