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
 * JDFNumberRangeListTest.cs
 * @author Elena Skobchenko
 * 
 * Copyright (c) 2001-2004 The International Cooperation for the Integration 
 * of Processes in  Prepress, Press and Postpress (CIP4).  All rights reserved. 
 */

namespace org.cip4.jdflib.datatypes
{
   using System;
   using Microsoft.VisualStudio.TestTools.UnitTesting;



   [TestClass]
   public class JDFNumberRangeListTest
   {

      [TestMethod]
      public void testSetString()
      {
         JDFNumberRangeList rangeList = new JDFNumberRangeList();
         try
         {
            rangeList = new JDFNumberRangeList("0.4 1.6 ~ 2.7 3.6 ~ 6");
         }
         catch (FormatException dfe)
         {
            Console.WriteLine(dfe.ToString());
         }
         // rangeList is not empty
         Assert.IsFalse(rangeList.ToString().Length == 0, "Bad Constructor from a given String");

      }


      [TestMethod]
      public void testInRange()
      {
         JDFNumberRangeList rangeList = new JDFNumberRangeList();
         try
         {
            rangeList = new JDFNumberRangeList("0.4 1.6 ~ 2.7 3.6 ~ 6 77.5 ~ INF");
         }
         catch (FormatException)
         {
            Assert.Fail("FormatException");
         }
         Assert.IsFalse(rangeList.inRange(2.8), "Bad inRange");
         Assert.IsTrue(rangeList.inRange(0.4), "Bad inRange");
         Assert.IsTrue(rangeList.inRange(12345.0), "Bad inRange");
      }


      [TestMethod]
      public void testInitRange()
      {
         JDFNumberRange range = new JDFNumberRange("0.0");
         Assert.AreEqual(0.0, range.Left, 0.0);
      }


      [TestMethod]
      public void testIsPartOfRange()
      {
         JDFNumberRangeList rangeList = new JDFNumberRangeList();
         try
         {
            rangeList = new JDFNumberRangeList("0.4 1.6 ~ 2.7 3.6 ~ 6");
         }
         catch (FormatException dfe)
         {
            Console.WriteLine(dfe.ToString());
         }
         Assert.IsFalse(rangeList.isPartOfRange(new JDFNumberRange(2.8, 3.0)), "Bad isPartOfRange");
         Assert.IsTrue(rangeList.isPartOfRange(new JDFNumberRange(1.6, 2.7)), "Bad isPartOfRange");
      }


      [TestMethod]
      public void testJDFNumberRangeList_CopyConstructor()
      {
         JDFNumberRangeList rangeList = null;
         JDFNumberRangeList copyRangeList = null;
         try
         {
            rangeList = new JDFNumberRangeList("0 4");
            copyRangeList = new JDFNumberRangeList(rangeList);
            copyRangeList.Append(new JDFNumberRange("8~9"));

            Assert.AreEqual("0 4", rangeList.ToString(), "original rangeList wrong:");
            Assert.AreEqual("0 4 8 ~ 9", copyRangeList.ToString(), "changed copy of rangeList wrong:");
         }
         catch (FormatException dfe)
         {
            Console.WriteLine(dfe.ToString());
         }
      }


      [TestMethod]
      public void testAppend()
      {
         JDFNumberRangeList rangeList = null;
         JDFNumberRangeList copyRangeList = null;
         try
         {
            rangeList = new JDFNumberRangeList("0 4~5");
            rangeList.Append(5.7);
            rangeList.Append(6, 6.5);
            rangeList.Append(new JDFNumberRange(6.6, 7.7));
            rangeList.Append(new JDFNumberRange("8~9"));
            copyRangeList = new JDFNumberRangeList("0 4~5 5.7 6~6.5 6.6~7.7 8~9");
         }
         catch (FormatException dfe)
         {
            Console.WriteLine(dfe.ToString());
         }

         if (rangeList != null)
         {
            Assert.IsTrue(rangeList.Equals(copyRangeList), "Bad isList");
         }
      }


      [TestMethod]
      public void testIsList()
      {
         JDFNumberRangeList rangeList = null;
         JDFNumberRangeList badRangeList = null;
         try
         {
            rangeList = new JDFNumberRangeList("0 4");
            rangeList.Append(6);
            rangeList.Append(7);
            badRangeList = new JDFNumberRangeList(rangeList);
            badRangeList.Append(new JDFNumberRange("8~9"));
         }
         catch (FormatException dfe)
         {
            Console.WriteLine(dfe.ToString());
         }

         if (rangeList != null)
            Assert.IsTrue(rangeList.isList(), "Bad isList");
         if (badRangeList != null)
            Assert.IsFalse(badRangeList.isList(), "Bad isList");
      }


      [TestMethod]
      public void testIsUnique()
      {
         JDFNumberRangeList rangelist = null;
         try
         {
            rangelist = new JDFNumberRangeList("0 3~4 ");
            rangelist.Append(3.5);
         }
         catch (FormatException dfe)
         {
            Console.WriteLine(dfe.ToString());
         }

         if (rangelist != null)
            Assert.IsFalse(rangelist.isUnique(), "Bad isUnique");
      }


      [TestMethod]
      public void testIsOrdered_False()
      {
         JDFNumberRangeList rangelist = null;
         try
         {
            rangelist = new JDFNumberRangeList("0~8");
            rangelist.Append(5);
            rangelist.Append(new JDFNumberRange("5.9~6.9"));
            rangelist.Append(7);
         }
         catch (FormatException dfe)
         {
            Console.WriteLine(dfe.ToString());
         }

         if (rangelist != null)
            Assert.IsFalse(rangelist.isOrdered(), "Bad isOrdered");
      }


      [TestMethod]
      public void testIsOrdered_Reverse_True()
      {
         JDFNumberRangeList rangelist = null;
         try
         {
            rangelist = new JDFNumberRangeList("21.5 ~ 10.5 6");
            rangelist.Append(5);
            rangelist.Append(new JDFNumberRange("4~3"));
            rangelist.Append(2);
         }
         catch (FormatException dfe)
         {
            Console.WriteLine(dfe.ToString());
         }

         if (rangelist != null)
            Assert.IsTrue(rangelist.isOrdered(), "Bad isOrdered");
      }


      [TestMethod]
      public void testIsUniqueOrdered_Reverse_False()
      {
         JDFNumberRangeList rangelist = null;
         try
         {
            rangelist = new JDFNumberRangeList("7 4.5");
            rangelist.Append(10);
            rangelist.Append(3.5, 2.5);
         }
         catch (FormatException dfe)
         {
            Console.WriteLine(dfe.ToString());
         }

         if (rangelist != null)
            Assert.IsFalse(rangelist.isUniqueOrdered(), "Bad isUniqueOrdered");
      }


      [TestMethod]
      public void testIsUniqueOrdered_False()
      {
         JDFNumberRangeList rangelist = null;
         try
         {
            rangelist = new JDFNumberRangeList("0 2.3 5.5");
            rangelist.Append(5.5);
            rangelist.Append(new JDFNumberRange("6~7.8"));
            rangelist.Append(9);
         }
         catch (FormatException dfe)
         {
            Console.WriteLine(dfe.ToString());
         }

         if (rangelist != null)
            Assert.IsFalse(rangelist.isUniqueOrdered(), "Bad isUniqueOrdered");
      }


      [TestMethod]
      public void testIsUniqueOrdered_True()
      {
         JDFNumberRangeList rangelist = null;
         try
         {
            rangelist = new JDFNumberRangeList("0 2.3 5.5");
            rangelist.Append(6, 7.8);
            rangelist.Append(9);
         }
         catch (FormatException dfe)
         {
            Console.WriteLine(dfe.ToString());
         }

         if (rangelist != null)
            Assert.IsTrue(rangelist.isUniqueOrdered(), "Bad isUniqueOrdered" + rangelist.ToString());
      }
   }
}
