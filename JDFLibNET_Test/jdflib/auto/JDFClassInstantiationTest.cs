
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

namespace org.cip4.jdflib.auto
{
   using System;
   using System.Collections;
   using System.IO;
   using Microsoft.VisualStudio.TestTools.UnitTesting;

   using VString = org.cip4.jdflib.core.VString;

   [TestClass]
   public class JDFClassInstantiationTest
   {
      private static string[] ignoreFileNames = {"JDFConstants.cs", "JDFDoc.cs", "JDFDocumentBuilder.cs", "JDFException.cs", "JDFParser.cs", "JDFVersions.cs", "JDFAbstractState.cs", "JDFEvaluation.cs", "JDFNodeTerm.cs", "JDFTerm.cs", "JDFEnumerationSpan.cs", "JDFSpan.cs", "JDFSpanBase.cs", "JDFDurationSpan.cs", "JDFIntegerSpan.cs", "JDFNameSpan.cs", "JDFNumberSpan.cs", "JDFOptionSpan.cs", "JDFShapeSpan.cs", "JDFSpanNamedColor.cs", "JDFStringSpan.cs", "JDFTimeSpan.cs", "JDFXYPairSpan.cs", "JDFResourceLink.cs", "JDFPool.cs" };

      internal static bool OkToVisitFile(string fileName)
      {
         foreach (string ignoreFileName in ignoreFileNames)
         {
            if (ignoreFileName == fileName)
               return false;
         }

         return true;
      }

      internal static bool OkToVisitDir(string dirName)
      {
         if (dirName == "auto" || dirName == "datatypes" || dirName == "util" || dirName == "validate")
            return false;
         else
            return true;
      }

      internal static void traverseNormalClassesAndInstantiate(DirectoryInfo dir, DirectoryVisitor visitor)
      {
         if (!dir.Exists)
         {
            throw new ArgumentException("not a directory: " + dir.Name);
         }

         visitor.enterDirectory(dir);
               // ignore classes in directories "auto", "datatypes" and
               // "util"
               // ignoreList : abstract classes, classes which are no jdf
               // elements ...

         //FileFilter ff = new FileFilter() 
         //{ 
         //   public bool accept(File pathname) 
         //   { 
         //      bool acceptFile = false; 
         //      string name = pathname.getName(); 
         //      if (pathname.isDirectory()) 
         //      { 
         //         acceptFile = !name.Equals("auto") && !name.Equals("datatypes") && !name.Equals("util") && !name.Equals("validate"); 
         //      } 
         //      else 
         //      { 
         //         VString ignoreList = new VString("JDFConstants.java JDFDoc.java JDFDocumentBuilder.java " + "JDFException.java JDFParser.java JDFVersions.java JDFAbstractState.java " + "JDFEvaluation.java JDFNodeTerm.java JDFTerm.java JDFEnumerationSpan.java " + "JDFSpan.java JDFSpanBase.java " + "JDFDurationSpan.java JDFIntegerSpan.java JDFNameSpan.java JDFNumberSpan.java " + "JDFOptionSpan.java JDFShapeSpan.java JDFSpanNamedColor.java " + "JDFStringSpan.java JDFTimeSpan.java JDFXYPairSpan.java " + "JDFResourceLink.java " + "JDFPool.java", null); 
         //         acceptFile = !ignoreList.Contains(name) && name.StartsWith("JDF") && name.ToLower().EndsWith(".java"); 
         //      } 
         //      return acceptFile;      
         //    }
         //);


         DirectoryInfo[] dirs = dir.GetDirectories();
         for (int j = 0; j < dirs.Length; ++j)
         {
            DirectoryInfo jDir = dirs[j];
            if (OkToVisitDir(jDir.Name))
               traverseNormalClassesAndInstantiate(jDir, visitor);
         }

         FileInfo[] files = dir.GetFiles("JDF*.cs");
         for (int i = 0; i < files.Length; ++i)
         {
            FileInfo file = files[i];
            if (OkToVisitFile(file.Name))
              visitor.visitFile(file);
         }

         visitor.leaveDirectory(dir);
      }

///   
///	 <summary> * get the fileName for every class JDFxxx below "./src/org/cip4/jdflib"
///	 * which is not in ignoreList and extract from it elementName (=xxx) With
///	 * elementName instantiate the corresponding class (using
///	 * jdfRoot.appendElement(elementName) and factory DocumentJDFImpl.java)
///	 * 
///	 * Then createdClass+".java" should be equal to fileName, i.e. the factory
///	 * DocumentJDFImpl creates a class at the correct point in the hierarchy
///	 * 
///	 * result = fileName.equals(createdClass + ".java") ||
///	 * (fileName.startsWith("JDFAuto") &&
///	 * createdClass.equals(JDFConstants.JDFELEMENT)) ||
///	 * fileName.equals(JDFConstants.JDFNODE) ||
///	 * !createdClass.equals(JDFConstants.JDFELEMENT);
///	 *  </summary>
///	 
      [TestMethod]
      public virtual void testDirectoryInstantiateVisitor()
      {
         string[] args = { "./src/org/cip4/jdflib" };

         try
         {
         // instantiate all classes starting with JDF
            traverseNormalClassesAndInstantiate(new DirectoryInfo(args[0]), new DirectoryInstantiateVisitor());
         }
         catch (Exception e)
         {
            Assert.Fail("DOMException : " + e.Message);
         }
      }

      internal static void traverseAutoClassesAndCheckForCorrespondingNormalClass(DirectoryInfo dir, DirectoryVisitor visitor)
      {
         if (!dir.Exists)
         {
            throw new ArgumentException("not a directory: " + dir.Name);
         }

         //new FileFilter() 
         //{ 
         //   public bool accept(File pathname) 
         //   { 
         //      bool acceptFile = false; 
         //      string name = pathname.getName(); 
         //      if (pathname.isDirectory()) 
         //      { 
         //         acceptFile = false; 
         //      } 
         //      else 
         //      { 
         //         acceptFile = name.StartsWith("JDFAuto") && name.ToLower().EndsWith(".java"); 
         //      } 
         //      return acceptFile; 
         //   } 
         //  }
         //);


         visitor.enterDirectory(dir);
         DirectoryInfo[] dirs = dir.GetDirectories();
         for (int j = 0; j < dirs.Length; ++j)
         {
            traverseAutoClassesAndCheckForCorrespondingNormalClass(dirs[j], visitor);
         }

         FileInfo[] files = dir.GetFiles("JDFAuto*.cs");
         for (int i = 0; i < files.Length; ++i)
         {
            try
            {
               visitor.visitFile(files[i]);
            }
            catch (Exception e)
            {
               Console.WriteLine(e.Message);
            }
         }

         visitor.leaveDirectory(dir);
      }

      [TestMethod]
      public virtual void testAutoClasses()
      {
         string[] args = { "./src/org/cip4/jdflib/auto" };

      // check that every auto class has a corresponding class
         try
         {
         // instantiate all classes starting with JDF
            traverseAutoClassesAndCheckForCorrespondingNormalClass(new DirectoryInfo(args[0]), new AutoClassInstantiateVisitor());
         }
         catch (Exception e)
         {
            Assert.Fail("DOMException : " + e.Message);
         }
      }

   // Demo code for DirectoryVisitor, DirectoryPrintVisitor,
   // DirectorySizeVisitor
   // public void testDirectoryVisitor()
   // {
   // File file = new File(args[0]);
   //
   // // output directory structure to screen
   // traverse(file, new DirectoryPrintVisitor());
   //
   // // get directory sizes
   // DirectorySizeVisitor visitor = new DirectorySizeVisitor();
   // traverse(file, visitor);
   // System.out.println("directories: " + visitor.getDirs());
   // System.out.println("files: " + visitor.getFiles());
   // System.out.println("size: " + visitor.getSize());
   // }

   }

}