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
 * Created on Jun 13, 2005
 */ 

namespace org.cip4.jdflib
{
   using System;
   using System.Collections;
   using System.Collections.Generic;
   using Microsoft.VisualStudio.TestTools.UnitTesting;
   using System.IO;

   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using KElement = org.cip4.jdflib.core.KElement;
   using VString = org.cip4.jdflib.core.VString;
   using XMLDoc = org.cip4.jdflib.core.XMLDoc;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using EnumValidationLevel = org.cip4.jdflib.core.KElement.EnumValidationLevel;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using EnumType = org.cip4.jdflib.node.JDFNode.EnumType;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;
   using StatusCounter = org.cip4.jdflib.util.StatusCounter;
   using ICheckValidator = org.cip4.jdflib.validate.ICheckValidator;
   using ICheckValidatorFactory = org.cip4.jdflib.validate.ICheckValidatorFactory;
   using JDFValidator = org.cip4.jdflib.validate.JDFValidator;

   ///
   /// <summary> * @author Claes Buckwalter (clabu@itn.liu.se) </summary>
   /// 
   [TestClass]
   public class CheckJDFTest : JDFTestCaseBase
   {

      [TestMethod]
      public virtual void testValidate()
      {
         FileInfo jdfFile = new FileInfo(sm_dirTestData + "job.jdf");
         Console.WriteLine("Checking JDF: " + jdfFile.FullName);
         // TODO There is a bug in MyArgs that prevents command line arguments
         // containing hyphens from being parsed correctly
         string[] args = { jdfFile.FullName, "-q", "-c" };

         CheckJDF checker = new CheckJDF();
         checker.validate(args, null);
      }

      protected internal class ValidFactory : ICheckValidatorFactory
      {
         internal ICheckValidator cv = new MyValid();

         protected internal class MyValid : ICheckValidator
         {

            ///         
            ///			 <summary> * very simple check for the string "snafu" </summary>
            ///			 
            public virtual bool validate(KElement toCheck, KElement report)
            {
               bool b = toCheck.ToString().ToUpper().IndexOf("SNAFU") >= 0;
               if (b)
               {
                  report.setAttribute("IsValid", false, null);
                  report.setAttribute("ErrorType", "PrivateValidation", null);
                  report.setAttribute("Message", "MyValid: Element contains snafu!!!", null);
                  Console.WriteLine("MyValid: Element contains snafu!!! " + toCheck.Name);
               }
               return !b;
            }

         }

         //      
         //		 * (non-Javadoc)
         //		 * 
         //		 * @see
         //		 * org.cip4.jdflib.validate.ICheckValidatorFactory#getValidator(org.
         //		 * cip4.jdflib.core.KElement)
         //		 
         public virtual ICheckValidator getValidator(KElement toCheck)
         {
            // always the snafu checker...
            return cv;
         }
      }


      [TestMethod]
      public virtual void testPrivateValidate()
      {
         StatusCounter sc = new StatusCounter(null, null, null);
         sc.setEvent("id1", "good", "blah");
         JDFValidator c = new JDFValidator();
         c.setValidatorFactory(new ValidFactory());
         JDFDoc d = sc.getDocJMFNotification(true);
         Assert.IsTrue(c.isValid(d));
         sc.setEvent("id2", "oops", "Snafu");
         d = sc.getDocJMFNotification(true);
         // XMLDoc report=
         c.processSingleDocument(d);
         Assert.IsFalse(c.isValid(d));

      }

      ///   
      ///	 <summary> * @author Eniac </summary>
      ///	 

      [TestMethod]
      public virtual void testCmdLineChecker()
      {
         string checkSavePath = sm_dirTestData + "NarrowWeb.jdf";
         string checkSavePathResult = sm_dirTestDataTemp + "NarrowWeb.out.xml";
         string schemaLocator = sm_dirTestSchema + "JDF.xsd"; //.toURL().
         // toExternalForm();

         string checkSaveLocator = checkSavePathResult;

         CheckJDF checker = new CheckJDF();

         List<string> args = new List<string>();
         args.Add(checkSavePath);
         args.Add("-x" + checkSaveLocator);
         args.Add("-L" + schemaLocator);
         args.Add("-qcv");
         string[] commandLineArgs = args.ToArray();

         string logStr = "";
         for (int i = 0; i < commandLineArgs.Length; i++)
            logStr += commandLineArgs[i] + " ";

         Console.WriteLine(logStr);

         checker.validate(commandLineArgs, null);

         Console.WriteLine("end");
      }


      [TestMethod]
      public virtual void testProcessSingleFile()
      {
         processSingleFile(sm_dirTestData + "matsch.jdf", false, EnumValidationLevel.Complete);
         processSingleFile(sm_dirTestData + "matsch.jdf", false, EnumValidationLevel.RecursiveComplete);
      }


      private void processSingleFile(string fileName, bool bShouldValidate, EnumValidationLevel level)
      {
         JDFValidator checkJDF = new JDFValidator();
         checkJDF.setPrint(false);
         checkJDF.bQuiet = true;
         checkJDF.level = level != null ? level : EnumValidationLevel.Complete;
         XMLDoc schemaValidationResult = checkJDF.processSingleFile(fileName);
         KElement root = schemaValidationResult.getRoot();
         Assert.IsNotNull(root.getXPathElement("TestFile/SchemaValidationOutput"));
         Assert.IsNotNull(root.getXPathElement("TestFile/CheckJDFOutput"));

         checkJDF = new JDFValidator();
         checkJDF.setPrint(false);
         checkJDF.bQuiet = true;
         checkJDF.level = EnumValidationLevel.Complete;
         checkJDF.processSingleFile(fileName);
         Assert.IsNotNull(root);

         if (bShouldValidate)
         {
            Assert.AreEqual(root.getXPathAttribute("TestFile/CheckJDFOutput/@IsValid", ""), "true", fileName + " should validate");
         }
         else
         {
            Assert.AreEqual(root.getXPathAttribute("TestFile/CheckJDFOutput/@IsValid", ""), "false", fileName + " should not validate");
         }

         // now repeat including schema
         checkJDF.setJDFSchemaLocation(new FileInfo(sm_dirTestSchema + "JDF.xsd"));
         checkJDF.processSingleDocument(null);
         Assert.IsNotNull(root);

         if (bShouldValidate)
         {
            Assert.AreEqual(root.getXPathAttribute("TestFile/CheckJDFOutput/@IsValid", ""), "true");
         }
         else
         {
            Assert.AreEqual(root.getXPathAttribute("TestFile/CheckJDFOutput/@IsValid", ""), "false");
         }
      }


      [TestMethod]
      public virtual void testProcessAllFiles()
      {
         JDFValidator checkJDF = new JDFValidator();
         checkJDF.setPrint(false);
         checkJDF.bQuiet = true;
         checkJDF.level = EnumValidationLevel.Complete;
         VString files = new VString();
         files.Add(sm_dirTestData + "job.jdf");
         checkJDF.allFiles = files;
         XMLDoc schemaValidationResult = checkJDF.processAllFiles();
         Assert.IsNotNull(schemaValidationResult.getRoot().getXPathElement("TestFile/SchemaValidationOutput"));
         Assert.IsNotNull(schemaValidationResult.getRoot().getXPathElement("TestFile/CheckJDFOutput"));
      }


      [TestMethod]
      public virtual void testValidateStream()
      {
         FileInfo jdfFile = new FileInfo(sm_dirTestData + "job.jdf");
         FileStream ins = new FileStream(jdfFile.FullName, FileMode.Open);
         Console.WriteLine("Checking JDF: " + jdfFile.FullName);
         // TODO There is a bug in MyArgs that prevents command line arguments
         // containing hyphens from being parsed correctly
         string[] args = { jdfFile.FullName, "-q", "-c" };

         CheckJDF checker = new CheckJDF();
         checker.validate(args, ins);
      }


      [TestMethod]
      public virtual void testBadResLink()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setType(EnumType.Stitching);
         JDFResource r = n.addResource(ElementName.STITCHINGPARAMS, EnumUsage.Input);
         JDFResourceLink rl = n.getLink(r, null);
         Assert.IsTrue(rl.isValid(EnumValidationLevel.Complete));
         Assert.IsTrue(n.isValid(EnumValidationLevel.Incomplete));
         rl.setrRef("badLink");
         Assert.IsFalse(rl.isValid(EnumValidationLevel.Complete));
         Assert.IsFalse(n.isValid(EnumValidationLevel.Complete));
         JDFValidator cj = new JDFValidator();
         XMLDoc res = cj.processSingleDocument(d);
         KElement root = res.getRoot();
         string s = root.ToString();
         Assert.IsTrue(s.IndexOf("Dangling") > 0);
      }


      [TestMethod]
      public virtual void testValidateZip()
      {
         FileInfo zip = new FileInfo(sm_dirTestData + "checkjdf.zip");
         JDFValidator checker = new JDFValidator();
         XMLDoc d = checker.processZipFile(zip);
         KElement root = d.getRoot();
         Assert.AreEqual(17, root.numChildElements("TestFile", null), "checkJDF.zip has 17 files");
      }


      [TestMethod]
      public virtual void testValidateMime()
      {
         FileInfo mim = new FileInfo(sm_dirTestData + "checkjdf.mjm");
         JDFValidator checker = new JDFValidator();
         FileStream @is = new FileStream(mim.FullName, FileMode.Open);
         XMLDoc d = checker.ProcessMimeStream(@is);
         KElement root = d.getRoot();
         Assert.AreEqual(2, root.numChildElements("TestFile", null), "checkJDF.mjm has 2 files");
      }


      [TestMethod]
      public virtual void testMainQuietComplete()
      {
         FileInfo jdfFile = new FileInfo(sm_dirTestData + "job.jdf");
         Console.WriteLine("Checking JDF: " + jdfFile.FullName);
         // TODO There is a bug in MyArgs that prevents command line arguments
         // containing hyphens from being parsed correctly
         string[] args = { jdfFile.FullName, "-q", "-c" };
         CheckJDF.Main(args);
      }


      [TestMethod]
      public virtual void testMainQuietCompleteXMLReport()
      {
         FileInfo jdfFile = new FileInfo(sm_dirTestData + "job.jdf");
         Console.WriteLine("Checking JDF: " + jdfFile.FullName);
         // TODO There is a bug in MyArgs that prevents command line arguments
         // containing hyphens from being parsed correctly

         // Run test once
         string report1 = sm_dirTestDataTemp + "checkjdf_report_1.xml";
         string[] args1 = { jdfFile.FullName, "-q", "-c", "-x", report1 };
         CheckJDF.Main(args1);
         Assert.IsTrue(new FileInfo(report1).Exists);
         // TODO Run test twice and compare XML files
      }


      [TestMethod]
      public virtual void testValidateJMF()
      {
         // Write temp JMF
         string jmf = "<?xml version='1.0' encoding='UTF-8'?><JMF xmlns='http://www.CIP4.org/JDFSchema_1_1' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'  SenderID='Alces' TimeStamp='2004-08-30T17:23:00+01:00' Version='1.2'><Query ID='M001' Type='KnownDevices' xsi:type='QueryKnownDevices'><DeviceFilter DeviceDetails='None'/></Query></JMF>";
         FileInfo jmfFile = new FileInfo("Query-KnownDevices.jmf");
         // jmfFile.deleteOnExit();
         StreamWriter @out = new StreamWriter(new FileStream(jmfFile.FullName, FileMode.Open));
         @out.Write(jmf);
         @out.Close();
         Assert.IsTrue(jmfFile.Exists);

         FileInfo reportFile = new FileInfo("Queue-KnownDevices-report.xml");
         // reportFile.deleteOnExit();

         // Run JDFValidator
         string[] args = { jmfFile.FullName, "-cq", "-x " + reportFile.FullName };
         CheckJDF checker = new CheckJDF();
         XMLDoc d = checker.validate(args, null);
         KElement dRoot = d.getRoot();
         Assert.AreEqual("true", dRoot.getXPathAttribute("/CheckOutput/TestFile/CheckJDFOutput/@IsValid", null));

         // Check that report exists
         Assert.IsTrue(reportFile.Exists);
         jmfFile.Delete();
         reportFile.Delete();
      }


      [TestMethod]
      public virtual void testValidateExtensionschema()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFValidator checkJDF = new JDFValidator();
         checkJDF.setPrint(false);
         checkJDF.bQuiet = true;
         checkJDF.level = EnumValidationLevel.Incomplete;
         DirectoryInfo foo = new DirectoryInfo(sm_dirTestSchema);
         Assert.IsTrue(foo.Exists, "please mount the svn schema parallel to JDFLibNet");
         FileInfo jdfxsd = new FileInfo(sm_dirTestSchema + "JDF.xsd");
         checkJDF.setJDFSchemaLocation(jdfxsd);
         JDFNode n = doc.getJDFRoot();
         n.setType(EnumType.ConventionalPrinting);
         JDFMedia med = (JDFMedia)n.addResource("Media", null, EnumUsage.Input, null, null, null, null);
         checkJDF.setIgnorePrivate(false);
         doc.write2File(sm_dirTestDataTemp + "extension.jdf", 0, true);
         XMLDoc @out = checkJDF.processSingleFile(sm_dirTestDataTemp + "extension.jdf");
         Assert.AreEqual(@out.getRoot().getXPathAttribute("TestFile/SchemaValidationOutput/@ValidationResult", null), "Valid");

         checkJDF.schemaLocation += " http://www.extension.com " + sm_dirTestData + "extension.xsd";
         med.setAttribute("ext:ExtensionAtt", "a", "http://www.extension.com");
         KElement fooBar = med.appendElement("ext:FooBar", "http://www.extension.com");
         fooBar.setAttribute("ID", "f1");
         fooBar.setAttribute("Fnarf", "4");

         doc.write2File(sm_dirTestDataTemp + "extension.jdf", 0, true);
         @out = checkJDF.processSingleFile(sm_dirTestDataTemp + "extension.jdf");
         Assert.AreEqual(@out.getRoot().getXPathAttribute("TestFile[2]/SchemaValidationOutput/@ValidationResult", null), "Error");

         med.setAttribute("ext:ExtensionAtt", "3", "http://www.extension.com");
         doc.write2File(sm_dirTestDataTemp + "extension.jdf", 0, true);
         @out = checkJDF.processSingleFile(sm_dirTestDataTemp + "extension.jdf");
         Assert.AreEqual(@out.getRoot().getXPathAttribute("TestFile[3]/SchemaValidationOutput/@ValidationResult", null), "Valid");

         fooBar.setAttribute("Fnarf", "bad");
         doc.write2File(sm_dirTestDataTemp + "extension.jdf", 0, true);
         @out = checkJDF.processSingleFile(sm_dirTestDataTemp + "extension.jdf");
         Assert.AreEqual(@out.getRoot().getXPathAttribute("TestFile[4]/SchemaValidationOutput/@ValidationResult", null), "Error");
      }

      ///   
      ///	 <summary> * tests validation of a document that is passed by reference to a document </summary>
      ///	 
      [TestMethod]
      public virtual void testValidatePrivateDoc()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFValidator checkJDF = new JDFValidator();
         checkJDF.setPrint(false);
         checkJDF.bQuiet = true;
         checkJDF.level = EnumValidationLevel.Incomplete;
         JDFNode n = doc.getJDFRoot();
         checkJDF.setIgnorePrivate(true);

         n.setAttribute("foo:bar", "foobar", "www.foo.cpm");
         XMLDoc schemaValidationResult = checkJDF.processSingleDocument(doc);
         KElement root = schemaValidationResult.getRoot();
         Assert.AreEqual(root.getXPathAttribute("TestFile/CheckJDFOutput/@IsValid", "booboo"), "true");

         n.removeAttribute("bar", "www.foo.cpm");
         n.appendElement("foo:bar", "www.foo.cpm");
         schemaValidationResult = checkJDF.processSingleDocument(doc);
         root = schemaValidationResult.getRoot();
         Assert.AreEqual(root.getXPathAttribute("TestFile[2]/CheckJDFOutput/@IsValid", "booboo"), "true");

         n.setAttribute("jdfbar", "thisbebad");
         schemaValidationResult = checkJDF.processSingleDocument(doc);
         root = schemaValidationResult.getRoot();
         Assert.AreEqual(root.getXPathAttribute("TestFile[3]/CheckJDFOutput/@IsValid", "booboo"), "false");

         n.removeAttribute("jdfbar", null);
         n.appendElement("jdfbar", null);
         schemaValidationResult = checkJDF.processSingleDocument(doc);
         root = schemaValidationResult.getRoot();
         Assert.AreEqual(root.getXPathAttribute("TestFile[4]/CheckJDFOutput/@IsValid", "booboo"), "false");
      }


      ///   
      ///	 <summary> * tests validation of a document that is passed by reference to a document </summary>
      ///	 
      [TestMethod]
      public virtual void testValidateDoc()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFValidator checkJDF = new JDFValidator();
         checkJDF.setPrint(false);
         checkJDF.bQuiet = true;
         int v = 0;
         while (true)
         {
            checkJDF.level = EnumValidationLevel.getEnum(v);
            if (checkJDF.level == null)
               break;
            for (int i = 0; i < 3; i++)
            {
               if (i >= 1)
                  doc = null;
               XMLDoc schemaValidationResult = checkJDF.processSingleDocument(doc);
               KElement root = schemaValidationResult.getRoot();
               Assert.IsNotNull(root.getXPathElement("TestFile/SchemaValidationOutput"));
               Assert.IsNotNull(root.getXPathElement("TestFile/CheckJDFOutput"));
               Assert.AreEqual(root.getXPathAttribute("TestFile/CheckJDFOutput/@IsValid", "booboo"), "true");
            }
            v++;
         }
      }

      ///   
      ///	 <summary> * tests validation of a document that is passed by reference to a document </summary>
      ///	 
      [TestMethod]
      public virtual void testIsValid()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode n = doc.getJDFRoot();
         n.setType(EnumType.ProcessGroup);
         JDFValidator checkJDF = new JDFValidator();
         checkJDF.setPrint(false);
         checkJDF.bQuiet = true;
         int v = 0;
         while (true)
         {
            checkJDF.level = EnumValidationLevel.getEnum(v);
            if (checkJDF.level == null)
               break;
            for (int i = 0; i < 3; i++)
            {
               if (i >= 1)
                  doc = null;
               bool bValid = checkJDF.isValid(doc);
               Assert.IsTrue(bValid);
            }
            v++;
         }
      }

      ///   
      ///	 <summary> * tests validation of a document that is passed by reference to a document </summary>
      ///	 
      [TestMethod]
      public virtual void testValidateCombined()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFValidator checkJDF = new JDFValidator();
         checkJDF.setPrint(false);
         checkJDF.bQuiet = true;
         JDFNode n = doc.getJDFRoot();
         n.setType(EnumType.Combined);
         int v = 0;
         while (true)
         {
            checkJDF.level = EnumValidationLevel.getEnum(v);
            if (checkJDF.level == null)
               break;
            for (int i = 0; i < 3; i++)
            {
               if (i >= 1)
                  doc = null;
               XMLDoc schemaValidationResult = checkJDF.processSingleDocument(doc);
               KElement root = schemaValidationResult.getRoot();
               Assert.IsNotNull(root.getXPathElement("TestFile/SchemaValidationOutput"));
               Assert.IsNotNull(root.getXPathElement("TestFile/CheckJDFOutput"));
               Assert.AreEqual(root.getXPathAttribute("TestFile/CheckJDFOutput/@IsValid", "booboo"), "true");
            }
            v++;
         }
      }


      [TestMethod]
      public virtual void testSamples()
      {
         DirectoryInfo testData = new DirectoryInfo(sm_dirTestData + "SampleFiles");
         Assert.IsTrue(testData.Exists, "testData dir");
         FileInfo[] fList = testData.GetFiles();

         for (int i = 0; i < fList.Length; i++)
         {
            FileInfo file = fList[i];
            // skip directories in CVS environments
            // Java to C# Conversion - Don't need to worry about this, File list will not contain directories
            //if (file.isDirectory())
            //   continue;
            // skip schema files
            if (file.FullName.EndsWith(".xsd"))
               continue;

            Console.WriteLine(i + " Parsing: " + file.FullName);
            processSingleFile(file.FullName, true, null);
            Console.WriteLine(i + " Parsing: " + file.FullName);
            processSingleFile(file.FullName, true, EnumValidationLevel.RecursiveComplete);
         }
      }


      [TestMethod]
      public virtual void testBadSamples()
      {
         DirectoryInfo testData = new DirectoryInfo(sm_dirTestData + "BadSampleFiles");
         //Assert.IsTrue(testData.isDirectory(), "testData dir");
         FileInfo[] fList = testData.GetFiles();

         for (int i = 0; i < fList.Length; i++)
         {
            FileInfo file = fList[i];
            // skip directories in CVS environments
            // Java to C# Conversion - Don't need to worry about this, file list won't contain directories.
            //   if (file.isDirectory())
            //       continue;
            // skip schema files
            if (file.FullName.EndsWith(".xsd"))
               continue;

            Console.WriteLine("Parsing: " + file.FullName);
            processSingleFile(file.FullName, false, null);
         }
      }
   }
}
