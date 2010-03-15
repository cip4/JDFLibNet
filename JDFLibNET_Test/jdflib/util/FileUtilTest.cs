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
   using System.IO;
   using Microsoft.VisualStudio.TestTools.UnitTesting;


   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;

   ///
   /// <summary> * @author Rainer Prosi, Heidelberger Druckmaschinen
   /// * </summary>
   /// 
   [TestClass]
   public class FileUtilTest : JDFTestCaseBase
   {

      [TestMethod]
      public virtual void testisAbsoluteFile()
      {
         Assert.IsFalse(FileUtil.isAbsoluteFile(new FileInfo("foo")));
         Assert.IsFalse(FileUtil.isAbsoluteFile("foo"));
         Assert.IsTrue(FileUtil.isAbsoluteFile(new FileInfo("c:\\")));
         Assert.IsTrue(FileUtil.isAbsoluteFile("c:\\"));
         Assert.IsTrue(FileUtil.isAbsoluteFile(new FileInfo("c:\\a")));
         Assert.IsTrue(FileUtil.isAbsoluteFile("c:\\a"));
         Assert.IsTrue(FileUtil.isAbsoluteFile(new FileInfo("c:/a")));
      }


      [TestMethod]
      public virtual void testisCleanURLFile()
      {
         //C# FileInfo Equals is a reference equals. Checking FullName.
         Assert.AreEqual(new FileInfo("C:").FullName, FileUtil.cleanURL(new FileInfo("C:/")).FullName);
         Assert.AreEqual(new FileInfo("C:").FullName, FileUtil.cleanURL(new FileInfo("C:\\")).FullName);
         Assert.AreEqual(new FileInfo("C:\\a").FullName, FileUtil.cleanURL(new FileInfo("C:\\a")).FullName);
         Assert.AreEqual(new FileInfo("C:\\a").FullName, FileUtil.cleanURL(new FileInfo("C:/a")).FullName);
      }


      [TestMethod]
      public virtual void testListFiles()
      {
         DirectoryInfo f = new DirectoryInfo(sm_dirTestDataTemp + "foo");
         f.Create(); // make sure we have one
         Assert.IsTrue(FileUtil.DeleteAll(f));
         f.Create();
         f.Refresh();
         Assert.IsTrue(f.Exists);
         Assert.IsNull(FileUtil.listFilesWithExtension(null, null));

         for (char c = 'a'; c < 'g'; c++)
         {
            for (int i = 0; i < 3; i++)
            {
               FileInfo f2 = new FileInfo(Path.Combine(f.FullName, i + "." + c));
               f2.Create();
               f2.Refresh();
               Assert.IsTrue(f2.Exists);
            }
         }
         Assert.AreEqual(3, FileUtil.listFilesWithExtension(f, "a").Length);
         Assert.AreEqual("0.c", FileUtil.listFilesWithExtension(f, "C")[0].Name);
         Assert.AreEqual("0.a", FileUtil.listFilesWithExtension(f, "a,b,.c")[0].Name);
         Assert.AreEqual("2.c", FileUtil.listFilesWithExtension(f, "a,b,.c")[8].Name);
         Assert.AreEqual(18, FileUtil.listFilesWithExtension(f, null).Length);
         Assert.IsNull(FileUtil.listFilesWithExtension(f, "CC"));
         Assert.IsNull(FileUtil.listFilesWithExtension(f, ".CC,.dd"));
         new FileInfo(Path.Combine(f.FullName, "a")).Create();
         Assert.AreEqual(19, FileUtil.listFilesWithExtension(f, null).Length);
         Assert.AreEqual(1, FileUtil.listFilesWithExtension(f, ".").Length);
         new FileInfo(Path.Combine(f.FullName, "b.")).Create();
         Assert.AreEqual(2, FileUtil.listFilesWithExtension(f, ".").Length);
      }


      [TestMethod]
      public virtual void testListDirectories()
      {
         DirectoryInfo f = new DirectoryInfo(Path.Combine(sm_dirTestDataTemp, "foo"));
         f.Create(); // make sure we have one
         Assert.IsTrue(FileUtil.DeleteAll(f));
         f.Create();
         f.Refresh();
         Assert.IsTrue(f.Exists);
         Assert.IsNull(FileUtil.listDirectories(null));
         Assert.IsNull(FileUtil.listDirectories(f));
         DirectoryInfo f1 = new DirectoryInfo(Path.Combine(Path.Combine(sm_dirTestDataTemp, "foo"), "bar1"));
         f1.Create();
         f1.Refresh();
         Assert.IsTrue(f1.Exists);
         FileInfo f2 = new FileInfo(Path.Combine(Path.Combine(sm_dirTestDataTemp, "foo"), "bar2"));
         f2.Create();
         f2.Refresh();
         Assert.IsTrue(f2.Exists);
         Assert.AreEqual(1, FileUtil.listDirectories(f).Length);
         Assert.AreEqual(f1.FullName, FileUtil.listDirectories(f)[0].FullName, "skipping bar2 - not a directory");
      }


      [TestMethod]
      public virtual void testMoveFile()
      {
         byte[] b = new byte[55555];
         for (int i = 0; i < 55555; i++)
         {
            b[i] = (byte)(i % 256);
         }
         MemoryStream @is = new MemoryStream(b);
         @is.Flush();
         FileInfo f = new FileInfo(sm_dirTestDataTemp + "streamMove.dat");
         if (f.Exists)
         {
            f.Delete();
         }
         FileUtil.streamToFile(@is, f.FullName);
         FileInfo f2 = new FileInfo(sm_dirTestDataTemp + "streamMove2.dat");

         Assert.IsTrue(FileUtil.moveFile(f, f2));
         Assert.IsFalse(f.Exists);
         Assert.IsTrue(f2.Length > 50000);
         string newdir = sm_dirTestDataTemp + "newDir";
         DirectoryInfo fd = new DirectoryInfo(newdir);
         FileUtil.DeleteAll(fd);
         Assert.IsFalse(fd.Exists);
         fd.Create();
         FileInfo f3 = new FileInfo(newdir + "streamMove3.dat");
         Assert.IsTrue(FileUtil.moveFile(f2, f3));
         Assert.IsFalse(f2.Exists);
         Assert.IsTrue(f3.Length > 50000);
      }


      [TestMethod]
      public virtual void testMoveFileToDir()
      {
         byte[] b = new byte[55555];
         for (int i = 0; i < 55555; i++)
         {
            b[i] = (byte)(i % 256);
         }
         MemoryStream @is = new MemoryStream(b);
         @is.Flush();
         FileInfo f = new FileInfo(sm_dirTestDataTemp + "streamMove.dat");
         if (f.Exists)
         {
            f.Delete();
         }
         FileUtil.streamToFile(@is, f.FullName);
         string newdir = sm_dirTestDataTemp + "newDir2";
         DirectoryInfo fd = new DirectoryInfo(newdir);
         FileUtil.DeleteAll(fd);
         Assert.IsFalse(fd.Exists);
         fd.Create();
         FileInfo nf = FileUtil.moveFileToDir(f, fd);
         Assert.IsNotNull(nf);
         Assert.AreEqual(nf.Directory.FullName, fd.FullName);
         Assert.AreEqual(nf.Name, f.Name);
      }


      [TestMethod]
      public virtual void testStreamToFile()
      {
         byte[] b = new byte[55555];
         for (int i = 0; i < 55555; i++)
         {
            b[i] = (byte)(i % 256);
         }
         MemoryStream @is = new  MemoryStream(b);
         @is.Flush();
         FileInfo f = new FileInfo(sm_dirTestDataTemp + "stream.dat");
         if (f.Exists)
         {
            f.Delete();
         }

         FileUtil.streamToFile(@is, sm_dirTestDataTemp + "stream.dat");
         f.Refresh();
         Assert.IsTrue(f.Exists);

         FileStream fis = new FileStream(f.FullName, FileMode.Open);
         for (int i = 0; i < 55555; i++)
         {
            fis.Read(b, i,  1);
            if (i % 287 == 0)
            {
               Assert.AreEqual((256 + b[i]) % 256, i % 256);
            }
         }

         int j = fis.Read(b, 55555-1, 1);
         Assert.AreEqual(0, j, "eof reached");
         fis.Close();

         FileStream fis2 = new FileStream(f.FullName, FileMode.Open);
         FileInfo f2 = FileUtil.streamToFile(fis2, sm_dirTestDataTemp + "stream2.dat");
         Assert.IsTrue(f2.Exists);
         f.Delete();
         f.Refresh();
         Assert.IsFalse(f.Exists);
         f2.Delete();
         f2.Refresh();
         Assert.IsFalse(f2.Exists);
      }


      [TestMethod]
      public virtual void testGetFileInDirectory()
      {
         //C# FileInfo Equals is a reference equals. Checking FullName.
         Assert.AreEqual(new FileInfo("a/b").FullName, FileUtil.getFileInDirectory(new DirectoryInfo("a"), new FileInfo("b")).FullName);
         Assert.AreEqual(new FileInfo("a/b").FullName, FileUtil.getFileInDirectory(new DirectoryInfo("a/"), new FileInfo("b")).FullName);
         Assert.AreEqual(new FileInfo("a/b").FullName, FileUtil.getFileInDirectory(new DirectoryInfo("a\\"), new FileInfo("b")).FullName);
         Assert.AreEqual(new FileInfo("a/b").FullName, FileUtil.getFileInDirectory(new DirectoryInfo("a/"), new FileInfo("/b")).FullName);
         Assert.AreEqual(new FileInfo("a/b").FullName, FileUtil.getFileInDirectory(new DirectoryInfo("a\\"), new FileInfo("\\b")).FullName);
         Assert.AreEqual(new FileInfo("a/c/b").FullName, FileUtil.getFileInDirectory(new DirectoryInfo("a"), new FileInfo("c/b")).FullName);
         Assert.AreEqual(new FileInfo("a/aa/c/b").FullName, FileUtil.getFileInDirectory(new DirectoryInfo("a/aa"), new FileInfo("c/b")).FullName);
         Assert.AreEqual(FileUtil.getFileInDirectory(new DirectoryInfo("a/b"), new FileInfo("c")).FullName, new FileInfo("a/b/c").FullName);
         Assert.AreEqual(FileUtil.getFileInDirectory(new DirectoryInfo("a/b"), new FileInfo("c/d")).FullName, new FileInfo("a/b/c/d").FullName);
         Assert.AreEqual(FileUtil.getFileInDirectory(new DirectoryInfo("a/b"), new FileInfo("/c")).FullName, new FileInfo("a/b/c").FullName);
         Assert.AreEqual(FileUtil.getFileInDirectory(new DirectoryInfo("a/b"), new FileInfo("/c/d")).FullName, new FileInfo("a/b/c/d").FullName);
         //C# a/b/c/d/ is different from a/b/c/d.
         Assert.AreNotEqual(FileUtil.getFileInDirectory(new DirectoryInfo("a/b"), new FileInfo("/c/d/")).FullName, new FileInfo("a/b/c/d").FullName);
      }
   }
}
