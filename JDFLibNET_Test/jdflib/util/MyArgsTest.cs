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



//
// * Created on Aug 12, 2005
// 
namespace org.cip4.jdflib.util
{
   using System;
   using Microsoft.VisualStudio.TestTools.UnitTesting;


   [TestClass]
   public class MyArgsTest : JDFTestCaseBase
   {

      internal readonly string[] _testArray = { "/Users/clabu/Documents/workarea/Elk/testarea/jakarta-tomcat-5.0.30/temp/VAHNSC6a7ag5ecAn9379.jdf", "-qc", "-v", "-d /Users/clabu/Documents/workarea/Elk/testarea/jakarta-tomcat-5.0.30/temp/tENgU4Gh3huO2iVH9380.xml", "-x /Users/clabu/Documents/workarea/Elk/testarea/jakarta-tomcat-5.0.30/temp/SimpleJDFPreprocessor_report9378.xml" };

      internal readonly string[] _testArrayWithQuotes = { "\"/Users/clabu/Documents/workarea/Elk/testarea/jakarta-tomcat-5.0.30/temp/VAHNSC6a7ag5ecAn9379.jdf\"", "-qcv", "-d \"/Users/clabu/Documents/workarea/Elk/testarea/jakarta-tomcat-5.0.30/temp/tENgU4Gh3huO2iVH9380.xml\"", "-x \"/Users/clabu/Documents/workarea/Elk/testarea/jakarta-tomcat-5.0.30/temp/SimpleJDFPreprocessor_report9378.xml\"" };

      internal MyArgs _myArgs;

      [TestInitialize]
      public override void setUp()
      {
         base.setUp();
         _myArgs = new MyArgs(_testArray, "?cqvVntP", "dlLuhpx", null);
      }

      //   
      //	 * Test method for 'org.cip4.jdflib.util.MyArgs.MyArgs(String[], String,
      //	 * String)'
      //	 
      [TestMethod]
      public virtual void testMyArgsStringArrayStringString()
      {
         MyArgs args = new MyArgs(_testArray, "?cqvVntP", "dlLuhpx", null);
         Console.WriteLine("Without quotes:");
         Console.WriteLine(args);

         MyArgs args2 = new MyArgs(_testArrayWithQuotes, "?cqvVntP", "dlLuhpx", null);
         Console.WriteLine("With quotes:");
         Console.WriteLine(args2);
      }

      //   
      //	 * Test method for 'org.cip4.jdflib.util.MyArgs.MyArgs(String[], String,
      //	 * String, String)'
      //	 
      [TestMethod]
      public virtual void testMyArgsStringArrayStringStringString()
      {
         // dummy
      }

      //   
      //	 * Test method for 'org.cip4.jdflib.util.MyArgs.MyArgs(Vector, String,
      //	 * String, String)'
      //	 
      [TestMethod]
      public virtual void testMyArgsVectorStringStringString()
      {
         // dummy
      }

      //   
      //	 * Test method for 'org.cip4.jdflib.util.MyArgs.initMyArgs(Vector, String,
      //	 * String, String)'
      //	 
      [TestMethod]
      public virtual void testInitMyArgs()
      {
         // dummy
      }

      //   
      //	 * Test method for 'org.cip4.jdflib.util.MyArgs.toString()'
      //	 
      [TestMethod]
      public virtual void testToString()
      {
         // dummy
      }

      //   
      //	 * Test method for 'org.cip4.jdflib.util.MyArgs.parameter(String)'
      //	 
      [TestMethod]
      public virtual void testParameterString()
      {
         string d = _myArgs.parameter("d");
         Assert.AreEqual(" /Users/clabu/Documents/workarea/Elk/testarea/jakarta-tomcat-5.0.30/temp/tENgU4Gh3huO2iVH9380.xml", d);
      }

      //   
      //	 * Test method for 'org.cip4.jdflib.util.MyArgs.parameter(char)'
      //	 
      [TestMethod]
      public virtual void testParameterChar()
      {
         // dummy
      }

      //   
      //	 * Test method for 'org.cip4.jdflib.util.MyArgs.parameterString(String)'
      //	 
      [TestMethod]
      public virtual void testParameterStringString()
      {
         // dummy
      }

      //   
      //	 * Test method for 'org.cip4.jdflib.util.MyArgs.parameterString(char)'
      //	 
      [TestMethod]
      public virtual void testParameterStringChar()
      {
         // dummy
      }

      //   
      //	 * Test method for 'org.cip4.jdflib.util.MyArgs.nargs()'
      //	 
      [TestMethod]
      public virtual void testNargs()
      {
         string[] s = { "-abc", "foo" };
         MyArgs args = new MyArgs(s, "ab", "c", null);
         Assert.AreEqual(0, args.nargs());

      }

      //   
      //	 * Test method for 'org.cip4.jdflib.util.MyArgs.hasParameter()'
      //	 
      public virtual void hasParam()
      {
         string[] s = { "-abc", "foo" };
         MyArgs args = new MyArgs(s, "ab", "c", null);
         Assert.IsTrue(args.hasParameter('a'));
         Assert.IsTrue(args.hasParameter('b'));
         Assert.IsTrue(args.hasParameter('c'));
         Assert.IsFalse(args.hasParameter('d'));

      }

      //   
      //	 * Test method for 'org.cip4.jdflib.util.MyArgs.argument(int)'
      //	 
      [TestMethod]
      public virtual void testArgument()
      {
         string[] s = { "-abc", "foo", "bar" };
         MyArgs args = new MyArgs(s, "ab", "c", null);
         Assert.AreEqual(1, args.nargs());
         Assert.AreEqual("bar", args.argument(0));
      }

      //   
      //	 * Test method for 'org.cip4.jdflib.util.MyArgs.argumentString(int)'
      //	 
      [TestMethod]
      public virtual void testArgumentString()
      {
         // dummy
      }

      //   
      //	 * Test method for 'org.cip4.jdflib.util.MyArgs.intParameter(char, int,
      //	 * int)'
      //	 
      [TestMethod]
      public virtual void testIntParameterCharIntInt()
      {
         // dummy
      }

      //   
      //	 * Test method for 'org.cip4.jdflib.util.MyArgs.intParameter(String, int,
      //	 * int)'
      //	 
      [TestMethod]
      public virtual void testIntParameterStringIntInt()
      {
         // dummy
      }

      //   
      //	 * Test method for 'org.cip4.jdflib.util.MyArgs.floatParameter(char,
      //	 * double)'
      //	 
      [TestMethod]
      public virtual void testFloatParameterCharDouble()
      {
         // dummy
      }

      //   
      //	 * Test method for 'org.cip4.jdflib.util.MyArgs.floatParameter(String,
      //	 * double)'
      //	 
      [TestMethod]
      public virtual void testFloatParameterStringDouble()
      {
         // dummy
      }

      //   
      //	 * Test method for 'org.cip4.jdflib.util.MyArgs.boolParameter(char,
      //	 * boolean)'
      //	 
      [TestMethod]
      public virtual void testBoolParameterCharBoolean()
      {
         // dummy
      }

      //   
      //	 * Test method for 'org.cip4.jdflib.util.MyArgs.boolParameter(String,
      //	 * boolean)'
      //	 
      [TestMethod]
      public virtual void testBoolParameterStringBoolean()
      {
         // dummy
      }

      //   
      //	 * Test method for 'org.cip4.jdflib.util.MyArgs.usage(String)'
      //	 
      [TestMethod]
      public virtual void testUsage()
      {
         // dummy
      }
   }
}
