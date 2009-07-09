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
 * JDFIntegerRangeListTest.cs
 *
 * @author Elena Skobchenko
 * 
 * Copyright (c) 2001-2004 The International Cooperation for the Integration 
 * of Processes in  Prepress, Press and Postpress (CIP4).  All rights reserved. 
 */

namespace org.cip4.jdflib.datatypes
{
   using Microsoft.VisualStudio.TestTools.UnitTesting;

   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;

   [TestClass]
   public class JDFIntegerRangeTest : JDFTestCaseBase
   {

      [TestMethod]
      public void testJDFIntegerRangeString()
      {

         JDFIntegerRange range = new JDFIntegerRange();
         range = new JDFIntegerRange(" 0 ~ 1 ");

         // rangeList is not empty
         Assert.IsFalse(range.ToString().Length == 0, "Bad Constructor from a given String");
         // must be trasformed into the string "0~1"
         Assert.AreEqual("0 ~ 1", range.ToString(), "Bad Constructor from a given String");
         range = new JDFIntegerRange(" 1 ~ 1 ");
         Assert.AreEqual("1", range.ToString(), "Bad Constructor from a given String");

      }


      [TestMethod]
      public void testAppend()
      {
         JDFIntegerRange range = new JDFIntegerRange(" 0 ~ 1 ");

         // rangeList is not empty
         Assert.IsFalse(range.ToString().Length == 0, "Bad Constructor from a given String");
         // must be trasformed into the string "0~1"
         Assert.AreEqual("0 ~ 1", range.ToString(), "Bad Constructor from a given String");
         Assert.IsFalse(range.Append(4));
         Assert.AreEqual("0 ~ 1", range.ToString(), "Bad Constructor from a given String");
         Assert.IsFalse(range.Append(-5));
         Assert.AreEqual("0 ~ 1", range.ToString(), "Bad Constructor from a given String");
         Assert.IsTrue(range.Append(2));
         Assert.AreEqual("0 ~ 2", range.ToString(), "Bad Constructor from a given String");
         Assert.IsFalse(range.Append(2));
         Assert.AreEqual("0 ~ 2", range.ToString(), "Bad Constructor from a given String");
         Assert.IsFalse(range.Append(1));
         Assert.AreEqual("0 ~ 2", range.ToString(), "Bad Constructor from a given String");
      }


      [TestMethod]
      public void testCopyConstructor()
      {
         JDFIntegerRange range = new JDFIntegerRange(4, -1, 8);
         Assert.IsTrue(range.inRange(4));
         Assert.IsFalse(range.inRange(3));
         Assert.IsTrue(range.inRange(7));
         Assert.IsFalse(range.inRange(8));
         JDFIntegerRange range2 = new JDFIntegerRange(range);
         Assert.IsTrue(range2.inRange(4));
         Assert.IsFalse(range2.inRange(3));
         Assert.IsTrue(range2.inRange(7));
         Assert.IsFalse(range2.inRange(8));
      }


      [TestMethod]
      public void testDefaultDef()
      {
         JDFIntegerRange range = new JDFIntegerRange("0~-1");
         Assert.IsFalse(range.inRange(4));
         JDFIntegerRange.setDefaultDef(int.MaxValue);
         range = new JDFIntegerRange("0~-1");
         Assert.IsTrue(range.inRange(4));
         JDFIntegerRange.setDefaultDef(0);
         range = new JDFIntegerRange("0~-1");
         Assert.IsFalse(range.inRange(4));
         Assert.IsFalse(range.inRange(-4));
         Assert.IsTrue(range.inRange(0));
      }
   }
}
