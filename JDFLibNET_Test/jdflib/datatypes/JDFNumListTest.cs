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
 * JDFNumListTest.cs
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
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFNode = org.cip4.jdflib.node.JDFNode;

   [TestClass]
   public class JDFNumListTest : JDFTestCaseBase
   {
      [TestMethod]
      public void testSetString()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();

         JDFIntegerList il = null;
         il = new JDFIntegerList("1 2 INF");
         n.setAttribute("test", il, null);
         Assert.AreEqual("1 2 INF", il.ToString(), "il");

         JDFNumberList nl = null;
         nl = new JDFNumberList("-INF 1.1 2.2 INF");
         n.setAttribute("test2", nl, null);
         Assert.AreEqual("-INF 1.1 2.2 INF", nl.ToString(), "nl");
      }


      [TestMethod]
      public void testGetIntArray()
      {
         JDFIntegerList il = new JDFIntegerList("1 2 INF");
         int[] ar = il.getIntArray();
         Assert.AreEqual(3, ar.Length);
         Assert.AreEqual(int.MaxValue, ar[2]);
      }


      [TestMethod]
      public void testSetIntArray()
      {
         int[] iArray = new int[3];
         iArray[0] = 1;
         iArray[1] = 2;
         iArray[2] = 4;
         JDFIntegerList il = new JDFIntegerList(iArray);
         int[] ar = il.getIntArray();
         Assert.AreEqual(iArray.Length, ar.Length);
         Assert.AreEqual(iArray[0], ar[0]);
         Assert.AreEqual(iArray[1], ar[1]);
         Assert.AreEqual(iArray[2], ar[2]);
      }


      [TestMethod]
      public void testScale()
      {
         int[] iArray = new int[3];
         iArray[0] = 1;
         iArray[1] = 2;
         iArray[2] = 4;
         JDFIntegerList il = new JDFIntegerList(iArray);
         il.scale(2);
         int[] ar = il.getIntArray();
         Assert.AreEqual(iArray.Length, ar.Length);
         Assert.AreEqual(2 * iArray[0], ar[0]);
         Assert.AreEqual(2 * iArray[1], ar[1]);
         Assert.AreEqual(2 * iArray[2], ar[2]);
      }


      [TestMethod]
      public void testCopy()
      {
         JDFCMYKColor cmy1 = new JDFCMYKColor("1 2 3 4");
         JDFCMYKColor cmy2 = new JDFCMYKColor(cmy1);
         Assert.AreEqual(cmy1, cmy2);
         cmy2.K = 0;
         Assert.AreEqual(0.0, cmy2.K, 0.0);
         Assert.AreEqual(4.0, cmy1.K, 0.0);
      }


      [TestMethod]
      public void testContainsDouble()
      {
         JDFNumberList l = new JDFNumberList("1 2.0 3 4 3.0");
         Assert.IsTrue(l.Contains(2.0));
         Assert.IsTrue(l.Contains(4.00));
         Assert.IsTrue(l.Contains(3));
         Assert.IsFalse(l.Contains(0));
      }


      [TestMethod]
      public void testContainsInt()
      {
         JDFIntegerList l = new JDFIntegerList("1 2 3 4 3");
         Assert.IsTrue(l.Contains(2));
         Assert.IsTrue(l.Contains(4));
         Assert.IsTrue(l.Contains(3));
         Assert.IsFalse(l.Contains(0));
      }


      [TestMethod]
      public void testContainsList()
      {
         JDFIntegerList l = new JDFIntegerList("1 2 3 4 3");
         Assert.IsTrue(l.Contains(new JDFIntegerList("1")));
         Assert.IsTrue(l.Contains(new JDFIntegerList("2 5")));

         Assert.IsFalse(l.Contains(new JDFIntegerList("5")));
      }


      [TestMethod]
      public void testRemoveElementAt()
      {
         int[] iArray = new int[3];
         iArray[0] = 1;
         iArray[1] = 2;
         iArray[2] = 4;
         JDFIntegerList il = new JDFIntegerList(iArray);
         Assert.AreEqual(4, il.getInt(-1));
         il.RemoveAt(2);
         Assert.AreEqual(2, il.getInt(-1));
         il.RemoveAt(-1);
         Assert.AreEqual(1, il.getInt(-1));
      }


      [TestMethod]
      public virtual void testGetDouble()
      {
         JDFNumberList nl = new JDFNumberList("1.1 2.2 3.3");
         Assert.AreEqual(1.1, nl.doubleAt(0), 0.0);
         Assert.AreEqual(2.2, nl.doubleAt(1), 0.0);
         Assert.AreEqual(3.3, nl.doubleAt(2), 0.0);
         Assert.AreEqual(3.3, nl.doubleAt(-1), 0.0);
         Assert.AreEqual(0.0, nl.doubleAt(3), 0.0);
      }


      [TestMethod]
      public virtual void testShape()
      {
         JDFShape nl = new JDFShape("1.1 2.2 3.3");
         Assert.AreEqual(1.1, nl.doubleAt(0), 0.0);
         Assert.AreEqual(2.2, nl.doubleAt(1), 0.0);
         Assert.AreEqual(3.3, nl.doubleAt(2), 0.0);
         Assert.AreEqual(1.1, nl.X, 0.0);
         Assert.AreEqual(2.2, nl.Y, 0.0);
         Assert.AreEqual(3.3, nl.Z, 0.0);

         nl.Y = 5;
         Assert.AreEqual(5, nl.Y, 0.0);
      }


      [TestMethod]
      public virtual void testShape2()
      {
         JDFShape nl = new JDFShape(1, 2);
         Assert.AreEqual(1, nl.doubleAt(0), 0.0);
         Assert.AreEqual(2, nl.doubleAt(1), 0.0);
         Assert.AreEqual(0, nl.doubleAt(2), 0.0);
         Assert.AreEqual(1, nl.X, 0.0);
         Assert.AreEqual(2, nl.Y, 0.0);
         Assert.AreEqual(0, nl.Z, 0.0);
      }
   }
}
