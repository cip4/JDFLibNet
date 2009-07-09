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
   using System;
   using Microsoft.VisualStudio.TestTools.UnitTesting;


   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;

   [TestClass]
   public class JDFIntegerRangeListTest : JDFTestCaseBase
   {
      private int defaultDef;

      [TestMethod]
      public void testJDFIntegerRangeListString()
      {
         JDFIntegerRangeList rangeList = new JDFIntegerRangeList();
         rangeList = new JDFIntegerRangeList(" 0 1 ~ 2 3 ~ 6 INF ");
         Assert.AreEqual(new JDFIntegerRangeList("1~1"), new JDFIntegerRangeList("   1   "));
         // rangeList is not empty
         Assert.AreEqual(4, rangeList.Count, "Bad Constructor from a given String");
         // must be transformed into the string "0 1~2 3~6"
         Assert.AreEqual("0 1 ~ 2 3 ~ 6 INF", rangeList.ToString(), "Bad Constructor from a given String");

      }


      [TestMethod]
      public void testJDFIntegerRangeListXDef()
      {
         JDFIntegerRange r = new JDFIntegerRange(1, 2);
         JDFIntegerRange r2 = new JDFIntegerRange(3, -1, 16); // 16 elements
         // element(-1) =
         // 15, range =
         // 3~15

         Assert.IsTrue(r.getElementCount() == 2, "Bad construction of ranges: Range:" + r.ToString());
         Assert.IsTrue(r2.getElementCount() == 13, "Bad construction of ranges with setDef: Range:" + r.ToString());

         JDFIntegerRangeList r3 = new JDFIntegerRangeList(" 1 ~ 2 3 ~ -1 ", 16);
         Assert.IsTrue(r3.getElementCount() == 15, "Bad construction of ranges with setDef: Range:" + r.ToString());
      }


      [TestMethod]
      public void testConstruct()
      {
         JDFIntegerRangeList rangeList;
         try
         {
            rangeList = new JDFIntegerRangeList((string)null);
            Assert.AreEqual(0, rangeList.getElementCount());
            rangeList = new JDFIntegerRangeList("");
            Assert.AreEqual(0, rangeList.getElementCount());
         }
         catch (FormatException)
         {
            Assert.Fail("snafu");
         }
      }


      [TestMethod]
      public void testNormalize()
      {
         JDFIntegerRangeList rangeList = new JDFIntegerRangeList("1 3 5 2 4 6 ~ 22");
         rangeList.normalize(true);
         Assert.AreEqual("1 ~ 22", rangeList.ToString());
         rangeList = new JDFIntegerRangeList("1 3 2 1 4 5 6 ~ 22");
         rangeList.normalize(false);
         Assert.AreEqual("1 3 ~ 1 4 ~ 22", rangeList.ToString());
      }


      [TestMethod]
      public void testDef()
      {
         JDFIntegerRangeList rangeList = null;
         try
         {
            rangeList = new JDFIntegerRangeList("0 ~-1");
            rangeList.setDef(20);
            Assert.AreEqual(20, rangeList.getElementCount());
         }
         catch (FormatException)
         {
            Assert.Fail("FormatException");
         }

         try
         {
            rangeList = new JDFIntegerRangeList("2 ~ -6 -3 -2 -1 ");
            rangeList.setDef(10);

            Assert.AreEqual("2 ~ 4 7 8 9", rangeList.ToString());
            rangeList.normalize(false);
            Assert.AreEqual("2 ~ 4 7 ~ 9", rangeList.ToString());
            rangeList = new JDFIntegerRangeList("1 3 5 2 4 6 ~ 22");
            rangeList.normalize(true);
            Assert.AreEqual("1 ~ 22", rangeList.ToString());
         }
         catch (FormatException)
         {
            Assert.Fail("FormatException");
         }
      }


      [TestMethod]
      public void testGetIntegerList()
      {
         try
         {
            JDFIntegerRangeList rangeList = new JDFIntegerRangeList("0 1~2 3~6 8 ~ 7");
            JDFIntegerList list = rangeList.getIntegerList();
            // list must be equal the string "0 1 2 3 4 5 6"
            Assert.AreEqual("0 1 2 3 4 5 6 8 7", list.ToString(), "Bad getIntegerList: " + list);

            // now some performance
            for (int i = 0; i < 1000; i++)
               rangeList.Append(i * 10, i * 10 + 5);

            int n = 0;
            for (int i = 0; i < rangeList.getElementCount(); i++)
            {
               int j = rangeList.getElement(i);
               n += j;
            }

            list = rangeList.getIntegerList();
            int m = 0;
            for (int i = 0; i < list.Count; i++)
            {
               int j = (int)list.elementAt(i);
               m += j;
            }

            Assert.AreEqual(n, m);
         }
         catch (FormatException)
         {
            Assert.Fail("FormatException");
         }
      }


      [TestMethod]
      public void testJDFIntegerRangeList_CopyConstructor()
      {
         JDFIntegerRangeList rangeList = null;
         JDFIntegerRangeList copyRangeList = null;
         try
         {
            rangeList = new JDFIntegerRangeList("0 4");
            copyRangeList = new JDFIntegerRangeList(rangeList);
            copyRangeList.Append(new JDFIntegerRange("8~9"));

            Assert.AreEqual("0 4", rangeList.ToString(), "original rangeList wrong:");
            Assert.AreEqual("0 4 8 ~ 9", copyRangeList.ToString(), "changed copy of rangeList wrong:");
         }
         catch (FormatException)
         {
            Assert.Fail("FormatException");
         }
      }


      [TestMethod]
      public void testAppend()
      {
         JDFIntegerRangeList rangeList = null;
         JDFIntegerRangeList copyRangeList = null;
         try
         {
            rangeList = new JDFIntegerRangeList("0 4~5");
            rangeList.Append(6, 7);
            rangeList.Append(new JDFIntegerRange(7, 8));
            rangeList.Append(new JDFIntegerRange("8~9"));
            copyRangeList = new JDFIntegerRangeList("0 4~5 6~7 7~8 8~9");
         }
         catch (FormatException)
         {
            Assert.Fail("FormatException");
         }

         if (rangeList != null)
            Assert.AreEqual(copyRangeList, rangeList);
      }


      [TestMethod]
      public void testIsList()
      {
         JDFIntegerRangeList goodRangeList = null;
         JDFIntegerRangeList badRangeList = null;
         try
         {
            goodRangeList = new JDFIntegerRangeList("0 4");
            goodRangeList.Append(6, 6);
            goodRangeList.Append(7, 7);

            Assert.IsTrue(goodRangeList.isList(), "Bad isList " + goodRangeList.ToString());

            badRangeList = new JDFIntegerRangeList(goodRangeList);
            badRangeList.Append(new JDFIntegerRange("8~9"));

            Assert.IsFalse(badRangeList.isList(), "Bad isList" + badRangeList.ToString());
         }
         catch (FormatException)
         {
            Assert.Fail("FormatException");
         }
      }


      [TestMethod]
      public void testIsUnique()
      {
         JDFIntegerRangeList rangelist = new JDFIntegerRangeList("0 3~5");
         rangelist.Append(4);
         Assert.IsFalse(rangelist.isUnique(), "Bad isUnique");
      }


      [TestMethod]
      public void testIsOrdered_False()
      {
         JDFIntegerRangeList rangelist = new JDFIntegerRangeList("0~8");
         rangelist.Append(5);
         rangelist.Append(new JDFIntegerRange("6~7"));
         rangelist.Append(9);

         Assert.IsFalse(rangelist.isOrdered(), "Bad isOrdered");
      }


      [TestMethod]
      public void testIsOrdered_Reverse_True()
      {
         JDFIntegerRangeList rangelist = new JDFIntegerRangeList("21 ~ 10 6");
         rangelist.Append(5);
         rangelist.Append(4, 3);

         Assert.IsTrue(rangelist.isOrdered(), "Bad isOrdered");
      }


      [TestMethod]
      public void testIsUniqueOrdered_Reverse_False()
      {
         JDFIntegerRangeList rangelist = new JDFIntegerRangeList("7 4");
         rangelist.Append(10);
         rangelist.Append(3, 1);

         Assert.IsFalse(rangelist.isUniqueOrdered(), "Bad isUniqueOrdered");
      }


      [TestMethod]
      public void testIsUniqueOrdered_False()
      {
         JDFIntegerRangeList rangelist = new JDFIntegerRangeList("0 2 4");
         rangelist.Append(6);
         rangelist.Append(new JDFIntegerRange("6~8"));
         rangelist.Append(10);

         Assert.IsFalse(rangelist.isUniqueOrdered(), "Bad isUniqueOrdered");
      }


      [TestMethod]
      public void testIsUniqueOrdered_True()
      {
         JDFIntegerRangeList rangelist = new JDFIntegerRangeList("0 2 5");
         rangelist.Append(6, 8);
         rangelist.Append(10);

         Assert.IsTrue(rangelist.isUniqueOrdered(), "Bad isUniqueOrdered" + rangelist.ToString());
      }


      [TestMethod]
      public virtual void testJDFIntegerRangeList1()
      {
         JDFIntegerRangeList integerRangeList = new JDFIntegerRangeList();
         for (int i = 0; i <= 10; i++)
         {
            integerRangeList.Append(i);
         }

         Assert.AreEqual("0 ~ 10", integerRangeList.ToString());
      }


      [TestMethod]
      public virtual void testJDFIntegerRangeList2()
      {
         JDFIntegerRangeList integerRangeList = new JDFIntegerRangeList();
         for (int i = 0; i <= 10; i++)
         {
            if (i != 4 && i != 8)
            {
               integerRangeList.Append(i);
            }
         }

         Assert.AreEqual("0 ~ 3 5 ~ 7 9 ~ 10", integerRangeList.ToString());
      }


      [TestMethod]
      public void testDefaultDef()
      {
         JDFIntegerRangeList irl = new JDFIntegerRangeList("-INF ~ 0 5 ~ -1");

         Assert.IsTrue(irl.inRange(-99), "inRange");
         Assert.IsFalse(irl.inRange(99), "inRange");
         Assert.IsTrue(irl.inRange(2), "inRange");

         JDFIntegerRange.setDefaultDef(int.MaxValue);
         irl = new JDFIntegerRangeList("-INF ~ 0 5 ~ -1");

         Assert.IsFalse(irl.inRange(-99), "inRange");
         Assert.IsTrue(irl.inRange(99), "inRange");
         Assert.IsFalse(irl.inRange(2), "inRange");
      }


      [TestMethod]
      public virtual void testInRange()
      {
         JDFIntegerRangeList irl = new JDFIntegerRangeList("-INF ~ 0 5 ~ INF");

         Assert.IsTrue(irl.inRange(-99), "inRange");
         Assert.IsTrue(irl.inRange(99), "inRange");
         Assert.IsFalse(irl.inRange(2), "inRange");
      }


      [TestMethod]
      public virtual void testInfiniteList()
      {
         JDFIntegerRangeList integerRangeList = new JDFIntegerRangeList("0~-1", int.MaxValue);
         for (int i = 0; i <= 10; i++)
         {
            Assert.IsTrue(integerRangeList.inRange(i), "RangeList 0~-1 should contain " + i);
         }
      }


      [TestMethod]
      public virtual void testgetElementCount()
      {
         JDFIntegerRangeList irl = new JDFIntegerRangeList("0 ~ 5");
         Assert.AreEqual(6, irl.getElementCount());
         irl = new JDFIntegerRangeList("0 ~ -1");
         Assert.AreEqual(-1, irl.getElementCount());
         irl = new JDFIntegerRangeList("0 ~ INF");
         Assert.IsTrue(irl.getElementCount() < 0);
         irl = new JDFIntegerRangeList("1 ~ 2 0 ~ INF");
         Assert.IsTrue(irl.getElementCount() < 0);
         irl = new JDFIntegerRangeList("1 ~ 2 5");
         Assert.AreEqual(3, irl.getElementCount());

         irl = new JDFIntegerRangeList("1 ~ 2 -2");
         irl.setDef(4);
         Assert.AreEqual(3, irl.getElementCount());
         irl.setDef(1);
         Assert.AreEqual(-1, irl.getElementCount());
      }


      [TestMethod]
      public virtual void testgetElement()
      {
         JDFIntegerRangeList irl = new JDFIntegerRangeList("5 ~ 8");
         Assert.AreEqual(6, irl.getElement(1));
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.JDFTestCaseBase#setUp()
      //	 
      [TestInitialize]
      public override void setUp()
      {
         // TODO Auto-generated method stub
         base.setUp();
         defaultDef = JDFIntegerRange.getDefaultDef();
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.JDFTestCaseBase#tearDown()
      //	 
      [TestCleanup]
      public override void tearDown()
      {
         // TODO Auto-generated method stub
         base.tearDown();
         JDFIntegerRange.setDefaultDef(defaultDef);
      }
   }
}
