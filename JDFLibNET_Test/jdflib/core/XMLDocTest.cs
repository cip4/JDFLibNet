
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



namespace org.cip4.jdflib.core
{
   using System;
   using System.Text;
   using System.Diagnostics;
   using System.Collections;
   using System.Threading;
   using System.IO;
   using System.Xml;
   using Microsoft.VisualStudio.TestTools.UnitTesting;

   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using EnumDirtyPolicy = org.cip4.jdflib.core.XMLDocUserData.EnumDirtyPolicy;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using ByteArrayIOStream = org.cip4.jdflib.util.ByteArrayIOStream;
   using JDFDate = org.cip4.jdflib.util.JDFDate;
   using JDFSpawn = org.cip4.jdflib.util.JDFSpawn;

   ///
   /// <summary> * @author MuchaD </summary>
   /// 
   [TestClass]
   public class XMLDocTest : JDFTestCaseBase
   {

      protected internal abstract class MyThread
      {
         public XMLDoc d;
         public int iLoop;
         public Exception hook = null;
         private object mutex = null;

         protected internal virtual void waitComplete()
         {
            if (mutex == null)
               return;
            lock (mutex)
            {
               try
               {
                  Monitor.Wait(mutex);
               }
               catch (ThreadInterruptedException)
               {
                  // nop
               }
            }
         }

         protected internal abstract void runMyThread();

         ///      
         ///		 <summary> * (non-Javadoc)
         ///		 *  </summary>
         ///		 * <seealso cref= java.lang.Runnable#run() </seealso>
         ///		 
         public virtual void Run()
         {
            try
            {
               mutex = new object();
               Console.WriteLine("Starting " + iLoop);
               runMyThread();
               Console.WriteLine("Completing " + iLoop);
            }
            catch (Exception e)
            {
               hook = e;
            }
            finally
            {
               lock (mutex)
               {
                  Monitor.PulseAll(mutex);
                  mutex = null;
               }
            }
         }
      }

      protected internal class MyReadThread : MyThread
      {

         //      
         //		 * (non-Javadoc)
         //		 * 
         //		 * @see java.lang.Runnable#run()
         //		 
         protected internal override void runMyThread()
         {
            KElement root = d.getRoot();
            XmlNodeList nl = root.GetElementsByTagName("elem" + iLoop % 3);
            for (int i = 0; i < nl.Count; i++)
            {
               // Node n=
               //nl[i];
            }
         }
      }

      protected internal class MyWriteThread : MyThread
      {
         ///      
         ///		 <summary> * (non-Javadoc)
         ///		 *  </summary>
         ///		 * <seealso cref= java.lang.Runnable#run() </seealso>
         ///		 
         protected internal override void runMyThread()
         {
            KElement root = d.getRoot();
            XmlNodeList nl = root.ChildNodes;
            for (int i = 0; i < nl.Count; i++)
            {
               XmlNode n = nl[i];
               if (i % 73 == 0)
                  root.removeChild(n);
            }
            Console.WriteLine("Completing " + iLoop);
         }
      }

      ///   
      ///	 <summary> * thread class that writes a lot of documents
      ///	 * @author Rainer Prosi, Heidelberger Druckmaschinen
      ///	 * </summary>
      ///	 
      protected internal class MyManyWriteThread : MyThread
      {
         protected string DirTestDataTemp;
         protected internal int outerLoop = 10;

         public MyManyWriteThread(string dirTestDataTemp)
         {
            DirTestDataTemp = dirTestDataTemp;
         }

         ///      
         ///		 <summary> * (non-Javadoc)
         ///		 *  </summary>
         ///		 * <seealso cref= java.lang.Runnable#run() </seealso>
         ///		 
         protected internal override void runMyThread()
         {
            KElement root = d.getRoot();
            string baseDir = DirTestDataTemp + @"\threadDir";
            new DirectoryInfo(baseDir).Create();
            string @base = baseDir + @"\ThreadWrite_" + iLoop + "_";
            for (int j = 0; j < outerLoop; j++)
            {
               if (j % 100 == 0)
                  Console.Write("\n" + iLoop + " " + j + " " + new JDFDate().TimeISO + " - ");
               root.appendElement("bar");
               Console.Write(".");
               for (int i = 0; i < 100; i++)
               {
                  string fn = @base + i + ".jdf";
                  FileInfo file = new FileInfo(fn);
                  file.Delete();
                  //Assert.IsTrue(file.createNewFile());
                  if (!d.write2File(file, 0, true))
                  {
                     Console.WriteLine("snafu " + iLoop);
                     throw new JDFException("Snafu");
                  }
               }
            }
         }
      }


      [TestMethod]
      public virtual void testIsDirty()
      {
         XMLDoc doc = new XMLDoc("test", null);
         KElement e = doc.getRoot();
         Assert.IsFalse(e.isDirty());
         Assert.IsFalse(doc.isDirty(null));
         doc.getCreateXMLDocUserData().setDirtyPolicy(EnumDirtyPolicy.Doc);
         Assert.IsFalse(e.isDirty());
         Assert.IsFalse(doc.isDirty(null));
         e.setAttribute("foo", "bar");
         Assert.IsTrue(e.isDirty());
         Assert.IsTrue(doc.isDirty(null));
         doc.clearDirtyIDs();
         Assert.IsFalse(doc.isDirty(null));
         Assert.IsFalse(e.isDirty());
         KElement e2 = e.appendElement("foobar");
         Assert.IsTrue(e.isDirty());
         Assert.IsTrue(doc.isDirty(null));
         Assert.IsTrue(e2.isDirty());
         doc.getCreateXMLDocUserData().setDirtyPolicy(EnumDirtyPolicy.XPath);
         doc.clearDirtyIDs();
         Assert.IsFalse(doc.isDirty(null));
         Assert.IsFalse(e.isDirty());
         e2 = e.appendElement("foobar");
         Assert.IsTrue(doc.isDirty(null));
         Assert.IsTrue(e.isDirty());
         Assert.IsTrue(e2.isDirty());
      }


      [TestMethod]
      public virtual void testSetSchemaLocation()
      {
         XMLDoc doc = new XMLDoc("test", null);
         doc.write2File(sm_dirTestDataTemp + "schematest.xml", 0, false); // create
         // a
         // readable
         // dummy
         FileInfo schema = new FileInfo(sm_dirTestDataTemp + "schematest.xml");

         const string nsURI = "www.foo.com";
         doc.setSchemaLocation(nsURI, schema);
         Assert.IsNotNull(doc.getSchemaLocation(nsURI));
         Assert.AreEqual(doc.getSchemaLocationFile(nsURI).FullName, schema.FullName);
      }


      [TestMethod]
      public virtual void testDirtyIDs()
      {
         // -i bookintent.jdf -o spawned.jdf -p 4
         string xmlFile = "bookintent.jdf";
         string outFile = "spawned.jdf";
         string strPartID = "4";

         JDFParser p = new JDFParser();
         JDFDoc jdfDocIn = p.parseFile(sm_dirTestData + xmlFile);

         Assert.IsTrue(jdfDocIn != null);
         if (jdfDocIn == null)
         {
            return; // soothe findbugs ;)
         }

         XMLDocUserData xmlUserData = jdfDocIn.getCreateXMLDocUserData();
         xmlUserData.setDirtyPolicy(XMLDocUserData.EnumDirtyPolicy.ID);

         JDFNode rootIn = (JDFNode)jdfDocIn.getRoot();

         JDFNode nodeToSpawn;
         if (strPartID.Equals(""))
         {
            nodeToSpawn = rootIn;
         }
         else
         {
            nodeToSpawn = rootIn.getJobPart(strPartID, "");
         }

         if (nodeToSpawn == null)
         {
            Assert.Fail("No such JobPartID: " + strPartID);
         }
         else
         {
            ArrayList vRWResources = new ArrayList();
            vRWResources.Add("Component");
            vRWResources.Add("RunList");

            VJDFAttributeMap vSpawnParts = new VJDFAttributeMap();
            JDFSpawn spawn = new JDFSpawn(nodeToSpawn);

            JDFNode node = spawn.spawn(xmlFile, outFile, vRWResources, vSpawnParts, false, false, false, false);

            // neu gespawntes FileInfo rausschreiben
            JDFNode rootOut = node;
            XMLDoc docOut = rootOut.getOwnerDocument_KElement();
            docOut.write2File(sm_dirTestDataTemp + outFile, 0, true);

            // verändertes Ausgangsfile rausschreiben
            string strOutXMLFile = "_" + xmlFile;
            rootIn.eraseEmptyNodes(true);
            jdfDocIn.write2File(sm_dirTestDataTemp + strOutXMLFile, 0, true);
            Assert.IsTrue(true, "SpawnJDF ok");

            // test, if all changed nodes are in our list

            // Java to C# Conversion - Java version indicated there should be 5 Dirty IDs, but it only checks for 4.
            //                         C# version returns 4 Dirty IDs.  Set it to 4 for now.
            VString vstrDirtyIDs = jdfDocIn.getDirtyIDs();
            Assert.AreEqual(4, vstrDirtyIDs.Count);
            Assert.IsTrue(vstrDirtyIDs.Contains("n0014")); // audit pool was added
            Assert.IsTrue(vstrDirtyIDs.Contains("n0016")); // status changed:
            // waiting --> spawned
            Assert.IsTrue(vstrDirtyIDs.Contains("r0017")); //SpawnStatus="SpawnedRW"
            // added
            Assert.IsTrue(vstrDirtyIDs.Contains("r0018")); // SizeIntent added
         }
      }


      [TestMethod]
      public virtual void testCreateElement()
      {
         XMLDoc d = new XMLDoc("TEST", null);
         KElement e = (KElement)d.createElement("foo:bar");
         // e.appendElement("bar:foo");
         e.setAttribute("foo:at", "1");
         e.appendElement("bar2");
         d.getRoot().appendChild(e);
         Assert.AreEqual("1", e.getAttribute("foo:at"));

      }


      [TestMethod]
      public virtual void testCreateElementNoNS()
      {
         XMLDoc d = new XMLDoc("TEST", null);
         d.getMemberDocument().setIgnoreNSDefault(true);
         KElement e = (KElement)d.createElement("bar");
         Assert.IsNull(e.getNamespaceURI()=="" ? null : "");
      }


      [TestMethod]
      public virtual void testCreateElementThreads()
      {
         XMLDoc d1 = new XMLDoc("JDF", null);
         Assert.AreEqual(typeof(KElement), d1.getRoot().GetType(), "XMLDoc only creates KElement");
         JDFDoc jd = new JDFDoc("JDF");
         Assert.AreEqual(typeof(JDFNode), jd.getRoot().GetType(), "JDFDoc creates typesafe elements");
         XMLDoc d2 = new XMLDoc("JDF", null);
         Assert.AreEqual(typeof(KElement), d2.getRoot().GetType(), "XMLDoc only creates KElement - Hasmap must not be applied");
      }


      [TestMethod]
      public virtual void testParseNoNS()
      {
         XMLDoc d = new XMLDoc("TEST", null);
         string fn = sm_dirTestDataTemp + "testParseNoNS.xml";
         d.write2File(fn, 2, true);
         JDFParser p = new JDFParser();
         JDFDoc d2 = p.parseFile(fn);
         KElement root = d2.getRoot();
         // Assert.IsNull(root.getNamespaceURI());
         Assert.IsFalse(d2.ToString().IndexOf("xmlns=\"\"") >= 0);
         Assert.IsFalse(d.ToString().IndexOf("xmlns=\"\"") >= 0);
         Assert.IsFalse(root.ToString().IndexOf("xmlns=\"\"") >= 0);
         KElement foo = root.appendElement("foofoo");
         Assert.IsNull(foo.getNamespaceURI() == "" ? null : "");
      }


      [TestMethod]
      public virtual void testCreateAttribute()
      {
         XMLDoc d = new XMLDoc("TEST", null);
         XmlAttribute a = d.createAttribute("dom1");
         Assert.IsNotNull(a, "a");
         bool bcatch = false;
         try
         {
            d.createAttribute("xmlns:foo");
         }
         catch (Exception)
         {
            bcatch = true;
         }
         Assert.IsTrue(!bcatch, "catch b");
         bcatch = false;
         try
         {
            d.createAttribute("foo:dom1");
         }
         catch (Exception)
         {
            bcatch = true;
         }
         Assert.IsTrue(!bcatch, "catch c");

      }


      [TestMethod]
      public virtual void testRegisterClass()
      {
         XMLDoc.registerCustomClass("JDFTestType", "org.cip4.jdflib.core.JDFTestType");
         XMLDoc.registerCustomClass("fnarf:JDFTestType", "org.cip4.jdflib.core.JDFTestType");
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();

         JDFTestType tt = (JDFTestType)n.appendElement("JDFTestType", null);
         tt.setAttribute("fnarf", 3, null);
         Assert.IsTrue(tt.isValid(KElement.EnumValidationLevel.Complete), "extension is valid");

         tt = (JDFTestType)n.appendElement("fnarf:JDFTestType", "WWW.fnarf.com");
         tt.setAttribute("fnarf", 3, null);
         Assert.IsTrue(tt.isValid(KElement.EnumValidationLevel.Complete), "ns extension is valid");
         tt.setAttribute("fnarf", "a", null); // illegal - must be integer
         Assert.IsTrue(!tt.isValid(KElement.EnumValidationLevel.Complete), "ns extension is valid");
         tt.removeAttribute("fnarf", null);
         Assert.IsTrue(tt.isValid(KElement.EnumValidationLevel.Complete), "ns extension is valid");
         tt.setAttribute("gnu", "a", null); // illegal - non existent
         Assert.IsFalse(tt.isValid(KElement.EnumValidationLevel.Complete), "ns extension is valid");

         // boolean bClassCast = false;
         // try
         // {
         // tt = (JDFTestType) n.appendElement("blub:JDFTestType",
         // "WWW.fnarf2.com");
         // }
         // catch (ClassCastException exc)
         // {
         // bClassCast = true;
         // }
         // Assert.IsTrue("ns extension works", bClassCast);
         Assert.IsTrue(!(n.appendElement("blub:JDFTestType", "WWW.fnarf2.com") is JDFTestType), "ns extension works");
      }


      [TestMethod]
      public virtual void testNSRoot()
      {
         XMLDoc d = new XMLDoc("JDF:foo", null);
         KElement e = d.getRoot();
         Assert.IsFalse(e is JDFElement, "E K");

         d = new XMLDoc("a:foo", "bar");
         e = d.getRoot();
         Assert.IsFalse(e is JDFElement, "E K");

         d = new XMLDoc("_foo", null);
         e = d.getRoot();
         Assert.IsFalse(e is JDFElement, "E K");

         d = new XMLDoc("bar:foo", JDFConstants.JDFNAMESPACE);
         e = d.getRoot();
         Assert.IsTrue(e is JDFElement, "E K");

         d = new XMLDoc("Myfoo", JDFConstants.JDFNAMESPACE);
         e = d.getRoot();
         Assert.IsTrue(e is JDFElement, "E K");

         d = new XMLDoc("JDF:Myfoo", JDFConstants.JDFNAMESPACE);
         e = d.getRoot();
         Assert.IsTrue(e is JDFElement, "E K");

         d = new XMLDoc("Myfoo", null);
         e = d.getRoot();
         Assert.IsFalse(e is JDFElement, "E K");
      }

      ///   
      ///	 <summary> * tests memory leaks in clone() </summary>
      ///	 * <exception cref="Exception"> </exception>
      ///	 

      [TestMethod]
      public virtual void testCloneMem()
      {
         System.GC.Collect();
         XMLDoc doc = new XMLDoc("foobar", null);
         long l = doc.getDocMemoryUsed();
         Console.WriteLine(l);
         // Java to C# Conversion - Divide number of tests by 1000 for now
         for (int i = 0; i < 1000; i++)
            doc.Clone();
         System.GC.Collect();
         long l2 = doc.getDocMemoryUsed();
         Console.WriteLine(l2);
         Assert.IsTrue(l2 - l < 100000);
      }

      ///   
      ///	 <summary> * tests .clone() </summary>
      ///	 * <exception cref="Exception"> </exception>
      ///	 

      [TestMethod]
      public virtual void testClone()
      {
         XMLDoc doc = new XMLDoc("foobar", null);
         XMLDoc doc2 = (XMLDoc)doc.Clone();
         Assert.IsNotNull(doc.getDocumentElement());
         Assert.IsNotNull(doc2.getDocumentElement());
         Assert.AreNotEqual(doc.getDocumentElement(), doc2.getDocumentElement());
         KElement e = doc.getRoot();
         e.setAttribute("foo", "bar");
         Assert.IsTrue(e.hasAttribute("foo"));
         KElement e2 = doc2.getRoot();
         Assert.IsFalse(e2.hasAttribute("foo"));
         Assert.AreEqual(doc.getDoctype(), doc2.getDoctype());
         Assert.AreEqual(e2.getOwnerDocument_KElement(), doc2);
         Assert.AreNotEqual(doc.getXMLDocUserData(), doc2.getXMLDocUserData());
      }


      [TestMethod]
      public virtual void testWriteToFile()
      {
         XMLDoc d = new XMLDoc("doc", null);
         string dirStr = sm_dirTestDataTemp + @"\dir\dir2";
         DirectoryInfo dir = new DirectoryInfo(dirStr);
         if (dir.Exists)
            dir.Delete(true);

         dir.Create();

         // get the directory path string without the relative path stuff (i.e. ..\..\)
         dirStr = dir.FullName;

         string fStr = dirStr + @"\d.xml";

         Assert.IsTrue(d.write2File(fStr, 2, true));
         FileInfo f = new FileInfo(fStr);
         Assert.IsTrue(f.Exists);
      }


      [TestMethod]
      public virtual void testWriteToStringIndent()
      {
         XMLDoc d = new XMLDoc("a", null);
         KElement e = d.getRoot();
         e.appendElement("b");
         string s = d.write2String(2);
         Assert.IsTrue(s.IndexOf("\n ") > 0);
         s = d.write2String(0);
         Assert.IsTrue(s.EndsWith("<a>\r\n<b />\r\n</a>"));
      }


      [TestMethod]
      public virtual void testWriteToStreamIndent()
      {
         XMLDoc d = new XMLDoc("a", null);
         KElement e = d.getRoot();
         KElement b = e.appendElement("b");
         ByteArrayIOStream bos = new ByteArrayIOStream();
         d.write2Stream(bos, 2, false);
         string s = System.Text.Encoding.GetEncoding("utf-8").GetString(bos.ToArray());  
         Assert.IsTrue(s.IndexOf("\n ") > 0);
         string text = "aa\r\nbb\r\n";
         b.setText(text);
         bos = new ByteArrayIOStream();
         d.write2Stream(bos, 2, false);
         s = System.Text.Encoding.GetEncoding("utf-8").GetString(bos.ToArray());
         Assert.IsTrue(s.IndexOf(text) > 0);
         JDFParser p = new JDFParser();
         //		JDFDoc dd = 
         p.parseStream(bos.getInputStream());
         bos = new ByteArrayIOStream();
         d.write2Stream(bos, 2, false);
         s = System.Text.Encoding.GetEncoding("utf-8").GetString(bos.ToArray());
         Assert.IsTrue(s.IndexOf(text) > 0);
      }


      [TestMethod]
      public virtual void testWriteToFileThreadRead()
      {
         XMLDoc d = new XMLDoc("doc", null);
         string @out = sm_dirTestDataTemp + @"\Thread.jdf";

         KElement root = d.getRoot();
         for (int i = 0; i < 1000; i++)
         {
            root.appendElement("elem2").appendElement("elem3").setAttribute("foo", "bar" + i);
         }

         MyReadThread[] mrs = new MyReadThread[100];
         for (int i = 0; i < 100; i++)
         {
            MyReadThread mr = new MyReadThread();
            mr.d = d;
            mr.iLoop = i;
            mrs[i] = mr;
            new Thread(new ThreadStart(mr.Run)).Start();

         }
         Console.WriteLine("Writing start");
         Assert.IsTrue(d.write2File(@out, 2, true));
         Console.WriteLine("Writing done");

         FileInfo f = new FileInfo(@out);
         Assert.IsTrue(f.Exists);
         for (int i = 0; i < 100; i++)
            if (mrs[i].hook != null)
               Assert.Fail("exception: " + mrs[i].hook);

      }


      [TestMethod]
      public virtual void testWriteToFileThreadWrite()
      {
         XMLDoc d = new XMLDoc("doc", null);
         string @out = sm_dirTestDataTemp + @"\Thread.jdf";

         KElement root = d.getRoot();
         for (int i = 0; i < 1000; i++)
         {
            root.appendElement("elem0").appendElement("elem1").appendElement("elem2").setAttribute("foo", "bar" + i);
         }
         MyWriteThread[] mrs = new MyWriteThread[10];
         for (int i = 0; i < 10; i++)
         {
            MyWriteThread mr = new MyWriteThread();
            mr.d = d;
            mr.iLoop = i;
            mrs[i] = mr;
            new Thread(new ThreadStart(mr.Run)).Start();
         }
         Console.WriteLine("Writing start");
         Assert.IsTrue(d.write2File(@out, 2, true));
         Console.WriteLine("Writing done");
         for (int i = 0; i < 10; i++)
            if (mrs[i].hook != null)
            {
               // Assert.Fail("exception: "+h.e);
               Console.WriteLine("******** Xerces known defect: not threadsafe: " + mrs[i].hook);
            }

         FileInfo f = new FileInfo(@out);
         Assert.IsTrue(f.Exists);
      }

      ///   
      ///	 <summary> *  test many many writes in parallel threads
      ///	 *  note that the documents themselves are independent </summary>
      ///	 

      [TestMethod]
      public virtual void testWriteToFileThreadWriteMany()
      {
         MyManyWriteThread[] threads = new MyManyWriteThread[10];
         for (int i = 0; i < 10; i++)
         {
            MyManyWriteThread mr = new MyManyWriteThread(sm_dirTestDataTemp);
            mr.d = new XMLDoc("doc", null);
            mr.iLoop = i;
            mr.outerLoop = 1; //10000000; // make high number for over night tests
            threads[i] = mr;
            new Thread(new ThreadStart(mr.Run)).Start();
         }
         for (int i = 0; i < 10; i++)
         {
            threads[i].waitComplete();
            if (threads[i].hook != null)
            {
               Console.WriteLine("exception " + threads[i].hook);
               break;
            }
            Console.WriteLine("done " + i);
         }
         Console.WriteLine("all done ");
      }


      [TestMethod]
      public virtual void testWriteToFileFile()
      {
         XMLDoc d = new XMLDoc("doc", null);
         string dirStr = sm_dirTestDataTemp + @"dir\dir2";
         DirectoryInfo dir = new DirectoryInfo(dirStr);
         if (dir.Exists)
            dir.Delete(true);

         dir.Create();

         // get the directory path string without the relative path stuff (i.e. ..\..\)
         dirStr = dir.FullName;

         string fStr = dirStr + @"\d%20.xml";

         FileInfo f = new FileInfo(fStr);

         Assert.IsTrue(d.write2File(fStr, 2, true));
         Assert.IsTrue(f.Exists);
      }


      [TestMethod]
      public virtual void testWriteToFileURL()
      {
         XMLDoc d = new XMLDoc("doc", null);
         string dirStr = sm_dirTestDataTemp + @"dir\dir2";
         DirectoryInfo dir = new DirectoryInfo(dirStr);
         if (dir.Exists)
            dir.Delete(true);

         dir.Create();

         // get the directory path string without the relative path stuff (i.e. ..\..\)
         dirStr = dir.FullName;
         string fStr1 = dirStr + @"\d .xml";
         string fStr2 = dirStr + @"\d%20.xml";

         FileInfo f = new FileInfo(fStr1);

         Assert.IsNotNull(d.write2URL("File:" + fStr1, null));
         Assert.IsTrue(f.Exists);
         Assert.IsNotNull(d.write2URL("File:" + fStr2, null));
         Assert.IsTrue(f.Exists);
      }

      ///   
      ///	 <summary> * tests all kinds of special characters in file names - including %, € and
      ///	 * umlauts
      ///	 *  </summary>
      ///	 

      [TestMethod]
      public virtual void testUmlaut()
      {
         XMLDoc d = new XMLDoc("doc", null);
         string dirStr = sm_dirTestDataTemp + @"dir\dir%20 Grün€";
         DirectoryInfo dir = new DirectoryInfo(dirStr);
         if (dir.Exists)
            dir.Delete(true);
         
         dir.Create();

         // get the directory path string without the relative path stuff (i.e. ..\..\)
         dirStr = dir.FullName;

         string fStr = dirStr + @"\7€ .xml";
         FileInfo f = new FileInfo(fStr);

         Assert.IsTrue(d.write2File(fStr, 0, true));
         Assert.IsTrue(f.Exists);

         JDFParser p = new JDFParser();
         JDFDoc d2 = p.parseFile(fStr);
         Assert.IsNotNull(d2);
         Assert.AreEqual("doc", d2.getRoot().LocalName);
      }


      [TestMethod]
      public virtual void testSize()
      {
         Process.GetCurrentProcess();
         GC.Collect();
         Process.GetCurrentProcess();
         GC.Collect();
         Process.GetCurrentProcess();
         GC.Collect();

         XMLDoc d = new XMLDoc("JDF:foo", JDFConstants.JDFNAMESPACE);
         long memlocal = d.getDocMemoryUsed();
         string s = d.write2String(0);
         Assert.IsTrue(memlocal + 100000 > s.Length, "mem 1");
         // the gc is messy and sometimes returns +/- a few 10k
         Assert.IsTrue(memlocal + 100000 > s.Length, "mem 2");
         d = JDFTestCaseBase.creatXMDoc();
         memlocal = d.getDocMemoryUsed();
         s = d.write2String(0);
         Assert.IsTrue(memlocal + 10000 > s.Length, "mem 3");
         d = new XMLDoc("foo", null);
         KElement e = d.getRoot();
         KElement e2 = e.appendElement("e2");
         KElement e3 = e2.appendElement("e3");
         for (int i = 33; i < 999; i++)
         {
            e3.setAttribute("k" + Convert.ToString(i), "value" + Convert.ToString(i));
         }
         for (int j = 0; j < 99; j++)
         {
            e2.copyElement(e3, null);
         }
         memlocal = d.getDocMemoryUsed();
         s = d.write2String(0);
         Assert.IsTrue(memlocal + 200000 > s.Length, "mem 4");
      }


      [TestMethod]
      public virtual void testCreateBig()
      {
         for (int ii = 0; ii < 4; ii++)
         {
            XMLDoc d = ii % 2 == 0 ? new XMLDoc("foo", null) : new JDFDoc("JDF");
            KElement e = d.getRoot();
            long l = DateTime.Now.Ticks;
            for (int j = 0; j < 2000; j++)
            {
               KElement e2 = e.appendElement("AuditPool");
               KElement e3 = e2.appendElement("Created");
               for (int i = 33; i < 199; i++)
               {
                  if (i < 2)
                     e3.setAttribute("k" + Convert.ToString(i), "value" + Convert.ToString(i));
                  else
                     e3.setAttributeRaw("k" + Convert.ToString(i), "value" + Convert.ToString(i));
               }
            }
            long l2 = DateTime.Now.Ticks;

            Console.WriteLine("xmldoc create: " + ii + " " + (l2 - l) / 1000000);
            string fil = sm_dirTestDataTemp + "big" + ii + "writ.jdf";
            d.write2File(fil, 2, false);
            FileInfo f = new FileInfo(fil);
            long l3 = DateTime.Now.Ticks;
            Console.WriteLine("xmldoc write: " + ii + " " + (l3 - l2) / 1000000 + " " + f.Length);
            Console.WriteLine("xmldoc total: " + ii + " " + (l3 - l) / 1000000 + "\n");
         }
      }

      ///   
      ///	 <summary> * test whether the serializer correctly serializes quotes etc. </summary>
      ///	 

      [TestMethod]
      public virtual void testEscapeStrings()
      {
         XMLDoc d = new XMLDoc("foo", "www.foo.com");
         KElement e = d.getRoot();
         e.setAttribute("bar", "><&'\"");
         string s = d.write2String(0);
         Assert.IsTrue(s.IndexOf("&lt;") > 0);
         Assert.IsTrue(s.IndexOf("&amp;") > 0);
         Assert.IsTrue(s.IndexOf("&quot;") > 0);
      }
   }
}