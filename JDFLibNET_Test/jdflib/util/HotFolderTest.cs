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
   using System.Threading;
   using Microsoft.VisualStudio.TestTools.UnitTesting;
   using System.IO;

   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;

   ///
   /// <summary> * @author Rainer
   /// * 
   /// *         To change the template for this generated type comment go to Window -
   /// *         Preferences - Java - Code Generation - Code and Comments </summary>
   /// 
   [TestClass]
   public class HotFolderTest : JDFTestCaseBase
   {
      private DirectoryInfo theHF;
      internal HotFolder hf;

      protected internal class MyListener : HotFolderListener
      {
         protected internal bool bZapp;

         protected internal MyListener(bool _bZapp)
         {
            bZapp = _bZapp;
         }

         //      
         //		 * (non-Javadoc)
         //		 * 
         //		 * @see org.cip4.jdflib.util.HotFolderListener#hotFile(java.io.FileInfo)
         //		 
         public virtual void hotFile(FileInfo hotFile)
         {
            bool zapp = false;
            if (bZapp)
            {
               try
               {
                  hotFile.Delete();
                  zapp = true;
               }
               catch (Exception)
               {
               }
            }
            Console.WriteLine(JDFDate.ToMillisecs(DateTime.Now) + " " + hotFile.FullName + "," + zapp);
         }
      }


      [TestInitialize]
      public override void setUp()
      {
         base.setUp();
         theHF = new DirectoryInfo(sm_dirTestDataTemp + "HFTest");
         theHF.Create();
      }


      [TestMethod]
      public virtual void testStartNull()
      {
         hf = new HotFolder(theHF, null, new MyListener(false));
         FileInfo file = new FileInfo(theHF + Path.DirectorySeparatorChar.ToString() + "f1.txt");
         SupportClass.FileSupport.CreateNewFile(file);
         file.Refresh();
         Assert.IsTrue(file.Exists);
         StatusCounter.sleep(3000);
         file.Refresh();
         Assert.IsTrue(file.Exists);
      }


      [TestMethod]
      public virtual void testRestartMany()
      {
         hf = new HotFolder(theHF, null, new MyListener(true));
         for (int i = 0; i < 10; i++)
         {
            // Java to C# Conversion - TODO: What is .NET Equivalent to activeCount()?
            //Assert.AreEqual(3, Thread.activeCount());
            hf.restart();
         }
         for (int i = 0; i < 3; i++)
         {
            Thread.Sleep(1);
            hf.Stop();
            // Java to C# Conversion - TODO: What is .NET Equivalent to activeCount()?
            //Assert.AreEqual(2, Thread.activeCount());
         }
      }


      [TestMethod]
      public virtual void testStopStart()
      {
         hf = new HotFolder(theHF, null, new MyListener(true));
         FileInfo file = new FileInfo(theHF + Path.DirectorySeparatorChar.ToString() + "f1.txt");
         SupportClass.FileSupport.CreateNewFile(file);
         file.Refresh();
         Assert.IsTrue(file.Exists);
         StatusCounter.sleep(3000);
         file.Refresh();
         Assert.IsFalse(file.Exists, "First delete attempt.");
         hf.Stop();
         hf.Stop();
         SupportClass.FileSupport.CreateNewFile(file);
         file.Refresh();
         Assert.IsTrue(file.Exists);
         StatusCounter.sleep(3000);
         file.Refresh();
         Assert.IsTrue(file.Exists);
         hf.restart();
         hf.restart();
         hf.restart();
         StatusCounter.sleep(5000);
         file.Refresh();
         Assert.IsFalse(file.Exists, "Second delete attempt.");
      }


      [TestMethod]
      public virtual void testExtension()
      {
         hf = new HotFolder(theHF, ".txt,.xml", new MyListener(true));
         StatusCounter.sleep(1000); // time to start up
         FileInfo file = new FileInfo(theHF + Path.DirectorySeparatorChar.ToString() + "f1.txt");
         FileInfo file1 = new FileInfo(theHF + Path.DirectorySeparatorChar.ToString() + "f1.xml");
         FileInfo file2 = new FileInfo(theHF + Path.DirectorySeparatorChar.ToString() + "f1.foo");
         SupportClass.FileSupport.CreateNewFile(file);
         file.Refresh();
         Assert.IsTrue(file.Exists);
         SupportClass.FileSupport.CreateNewFile(file1);
         file1.Refresh();
         Assert.IsTrue(file1.Exists);
         SupportClass.FileSupport.CreateNewFile(file2);
         file2.Refresh();
         Assert.IsTrue(file2.Exists);
         StatusCounter.sleep(4000);
         file.Refresh();
         file1.Refresh();
         file2.Refresh();
         Assert.IsFalse(file.Exists);
         Assert.IsFalse(file1.Exists);
         Assert.IsTrue(file2.Exists);
      }


      [TestMethod]
      public virtual void testDir()
      {
         hf = new HotFolder(theHF, ".txt,.xml", new MyListener(true));
         FileInfo file = new FileInfo(theHF + Path.DirectorySeparatorChar.ToString() + "f1.txt");
         FileInfo file1 = new FileInfo(theHF + Path.DirectorySeparatorChar.ToString() + "f2.xml"
            + Path.DirectorySeparatorChar.ToString() + "f1.xml");
         DirectoryInfo file2 = new DirectoryInfo(theHF + Path.DirectorySeparatorChar.ToString() + "f2.xml");
         SupportClass.FileSupport.CreateNewFile(file);
         file.Refresh();
         file2.Create();
         file2.Refresh();
         SupportClass.FileSupport.CreateNewFile(file1);
         file1.Refresh();
         Assert.IsTrue(file.Exists);
         StatusCounter.sleep(5000);
         file.Refresh();
         file1.Refresh();
         file2.Refresh();
         Assert.IsFalse(file.Exists);
         Assert.IsTrue(file1.Exists, "in subdir");
         Assert.IsTrue(file2.Exists);
      }


      [TestMethod]
      public virtual void testStartNullDelete()
      {
         hf = new HotFolder(theHF, null, new MyListener(true));
         FileInfo file = new FileInfo(theHF + Path.DirectorySeparatorChar.ToString() + "f1.txt");
         SupportClass.FileSupport.CreateNewFile(file);
         file.Refresh();
         Assert.IsTrue(file.Exists);
         StatusCounter.sleep(3000);
         file.Refresh();
         Assert.IsFalse(file.Exists);
      }


      [TestMethod]
      public virtual void testBig()
      {
         hf = new HotFolder(theHF, null, new MyListener(true));
         FileInfo file = new FileInfo(theHF + Path.DirectorySeparatorChar.ToString() + "f1.txt");
         SupportClass.FileSupport.CreateNewFile(file);
         file.Refresh();
         Assert.IsTrue(file.Exists);

         FileStream fos = new FileStream(file.FullName, FileMode.Open);
         byte[] ba = new byte[1];
         for (int i = 0; i < 20; i++) // incrementally fill file
         {
            ba[0] = (byte)i;
            fos.Write(ba, 0, 1);
            fos.Flush();

            StatusCounter.sleep(10);

         }
         file.Refresh();
         Assert.IsTrue(file.Exists);
         fos.Close();

         StatusCounter.sleep(3000);
         file.Refresh();
         Assert.IsFalse(file.Exists);
      }


      [TestCleanup]
      public override void tearDown()
      {
         hf.Stop();
         base.tearDown();
      }
   }
}
