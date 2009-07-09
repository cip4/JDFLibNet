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
 * JDFShapeRangeListTest.cs
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
   public class JDFShapeRangeListTest
   {
      //   
      //	 * Class under test for void append(JDFShapeRange)
      //	 
      [TestMethod]
      public void testAppendJDFShapeRange()
      {
         JDFShapeRangeList rangeList = new JDFShapeRangeList();
         try
         {
            rangeList = new JDFShapeRangeList("0 0 3 1 2 3~4 5 6 4 2 3~4 5 6");
            rangeList.Append(new JDFShapeRange("7.5 8.5 9.5"));
         }
         catch (FormatException dfe)
         {
            Console.WriteLine(dfe.ToString());
         }

         Assert.AreEqual("0 0 3 1 2 3 ~ 4 5 6 4 2 3 ~ 4 5 6 7.5 8.5 9.5", rangeList.ToString(), "original rangeList wrong:");
         Assert.IsTrue(rangeList.Count == 4, "Bad append" + rangeList.ToString());
      }


      [TestMethod]
      public void testSetString()
      {
         JDFShapeRangeList rangelist = new JDFShapeRangeList();
         try
         {
            rangelist = new JDFShapeRangeList("1 2 3 ~ 4 5 6   1.55 3.75 5.85");
         }
         catch (FormatException dfe)
         {
            Console.WriteLine(dfe.ToString());
         }

         // rangeList is not empty
         Assert.IsTrue(rangelist.Count == 2, "Bad setString: " + rangelist.Count);
      }


      [TestMethod]
      public void testInRange()
      {
         JDFShapeRangeList rangelist = new JDFShapeRangeList();
         try
         {
            rangelist = new JDFShapeRangeList("1 2 3 ~ 4 5 6  7 8 9~10 11 12");
         }
         catch (FormatException dfe)
         {
            Console.WriteLine(dfe.ToString());
         }
         Assert.IsTrue(rangelist.inRange(new JDFShape(3, 4, 5)), "Bad setString: ");
         Assert.IsTrue(rangelist.inRange(new JDFShape(4, 5, 6)), "Bad setString: ");
         Assert.IsFalse(rangelist.inRange(new JDFShape(6, 7, 8)), "Bad setString: ");
         Assert.IsFalse(rangelist.inRange(new JDFShape(10, 12, 12)), "Bad setString: ");
      }


      [TestMethod]
      public void testIsPartOfRange()
      {
         JDFShapeRangeList rangelist = new JDFShapeRangeList();

         try
         {
            rangelist = new JDFShapeRangeList("1 2 3 ~ 4 5 6  7 8 9~10 11 12");
         }
         catch (FormatException dfe)
         {
            Console.WriteLine(dfe.ToString());
         }
         Assert.IsTrue(rangelist.isPartOfRange(new JDFShapeRange(new JDFShape(3, 4, 5), new JDFShape(4, 5, 6))), "Bad setString: ");
         Assert.IsTrue(rangelist.isPartOfRange(new JDFShapeRange(new JDFShape(9, 9, 9), new JDFShape(10, 10, 10))), "Bad setString: ");
         Assert.IsFalse(rangelist.isPartOfRange(new JDFShapeRange(new JDFShape(9, 9, 9), new JDFShape(12, 12, 12))), "Bad setString: ");
         Assert.IsFalse(rangelist.isPartOfRange(new JDFShapeRange(new JDFShape(4, 5, 6), new JDFShape(7, 8, 9))), "Bad setString: ");
      }


      [TestMethod]
      public void testIsList_False()
      {
         JDFShapeRangeList rangelist = new JDFShapeRangeList();
         try
         {
            rangelist = new JDFShapeRangeList("0 0 4");
            rangelist.Append(new JDFShapeRange(new JDFShape("0 0 5"), new JDFShape("0 0 6")));
            rangelist.Append(new JDFShape("0 0 6"));
            rangelist.Append(new JDFShape("0 0 7"));
         }
         catch (FormatException dfe)
         {
            Console.WriteLine(dfe.ToString());
         }

         Assert.IsFalse(rangelist.isList(), "Bad isList");
      }


      [TestMethod]
      public void testIsUnique_False()
      {
         JDFShapeRangeList rangelist = new JDFShapeRangeList();
         try
         {
            rangelist = new JDFShapeRangeList("0 0 4");
            rangelist.Append(new JDFShapeRange(new JDFShape("0 0 5"), new JDFShape("0 0 6")));
            rangelist.Append(new JDFShape("0 0 5.5")); // in "0 0 5 ~ 0 0 6"
            rangelist.Append(new JDFShape("0 0 7"));
         }
         catch (FormatException dfe)
         {
            Console.WriteLine(dfe.ToString());
         }

         Assert.IsFalse(rangelist.isUnique(), "Bad isUnique");
      }


      [TestMethod]
      public void testIsOrdered_False()
      {
         JDFShapeRangeList rangelist = new JDFShapeRangeList();
         try
         {
            rangelist = new JDFShapeRangeList("0 0 4");
            rangelist.Append(new JDFShape("0 0 5"));
            rangelist.Append(new JDFShapeRange(new JDFShape("0 0 5.5"), new JDFShape("0 0 6")));
            rangelist.Append(new JDFShape("0 0 5"));
            rangelist.Append(new JDFShape("0 0 7"));
         }
         catch (FormatException dfe)
         {
            Console.WriteLine(dfe.ToString());
         }

         Assert.IsFalse(rangelist.isOrdered(), "Bad isOrdered");
      }


      [TestMethod]
      public void testIsOrdered_Reverse_True()
      {
         JDFShapeRangeList rangelist = new JDFShapeRangeList();
         try
         {
            rangelist = new JDFShapeRangeList("0 0 7");
            rangelist.Append(new JDFShape(0, 0, 5));
            rangelist.Append(new JDFShapeRange("0 0 4~0 0 2"));
         }
         catch (FormatException dfe)
         {
            Console.WriteLine(dfe.ToString());
         }

         Assert.IsTrue(rangelist.isOrdered(), "Bad isOrdered");
      }


      [TestMethod]
      public void testIsUniqueOrdered_Reverse_False()
      {
         JDFShapeRangeList rangelist = new JDFShapeRangeList();
         try
         {
            rangelist = new JDFShapeRangeList("0 0 7");
            rangelist.Append(new JDFShape("0 0 5"));
            rangelist.Append(new JDFShapeRange("0 0 4~0 0 2"));
            rangelist.Append(new JDFShape("0 0 5"));
         }
         catch (FormatException dfe)
         {
            Console.WriteLine(dfe.ToString());
         }

         Assert.IsFalse(rangelist.isUniqueOrdered(), "Bad isUniqueOrdered");
      }


      [TestMethod]
      public void testIsUniqueOrdered_True()
      {
         JDFShapeRangeList rangelist = new JDFShapeRangeList();
         try
         {
            rangelist = new JDFShapeRangeList("0 0 4");
            rangelist.Append(new JDFShape("0 0 5"));
            rangelist.Append(new JDFShapeRange(new JDFShape("0 0 5.5"), new JDFShape("0 0 6")));
            // rangelist.append(new JDFShape("0 0 5"));
            rangelist.Append(new JDFShape("0 0 7"));
         }
         catch (FormatException dfe)
         {
            Console.WriteLine(dfe.ToString());
         }

         Assert.IsTrue(rangelist.isUniqueOrdered(), "Bad isUniqueOrdered");
      }
   }
}
