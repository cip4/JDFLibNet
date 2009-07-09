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
 * JDFMatrixTest.cs
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
   using EnumOrientation = org.cip4.jdflib.core.JDFElement.EnumOrientation;
   using JDFNode = org.cip4.jdflib.node.JDFNode;

   [TestClass]
   public class JDFMatrixTest : JDFTestCaseBase
   {
      [TestMethod]
      public virtual void testCreate()
      {
         JDFMatrix m = new JDFMatrix(90, 20, 20);
         JDFMatrix m2 = new JDFMatrix(EnumOrientation.Rotate90, 0, 0);
         m2.shift(20, 20);
         Assert.AreEqual(m, m2);
      }


      [TestMethod]
      public virtual void testSetString()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();

         JDFMatrix m = new JDFMatrix("1 0 0 1 0 0");
         Assert.AreEqual(JDFMatrix.unitMatrix, m);
         n.setAttribute("foo", m, null);
         Assert.AreEqual(n.getAttribute("foo"), m.ToString());
      }


      [TestMethod]
      public virtual void testOrientation()
      {
         JDFMatrix m = new JDFMatrix(EnumOrientation.Rotate0, 0, 0);
         Assert.AreEqual(JDFMatrix.unitMatrix, m);
      }


      [TestMethod]
      public virtual void testRotate()
      {
         JDFMatrix m = new JDFMatrix(EnumOrientation.Rotate0, 0, 0);
         Assert.AreEqual(JDFMatrix.unitMatrix, m);
         m.rotate(180);
         Assert.AreEqual(new JDFMatrix(EnumOrientation.Rotate180, 0, 0), m);
         m.rotate(90);
         Assert.AreEqual(new JDFMatrix(EnumOrientation.Rotate270, 0, 0), m);

         m.rotate(180);
         Assert.AreEqual(new JDFMatrix(EnumOrientation.Rotate90, 0, 0), m);
         m = new JDFMatrix(EnumOrientation.Flip0, 0, 0);
         m.rotate(180);
         Assert.AreEqual(new JDFMatrix(EnumOrientation.Flip180, 0, 0), m);
         m.rotate(90);
         Assert.AreEqual(new JDFMatrix(EnumOrientation.Flip270, 0, 0), m);
      }


      [TestMethod]
      public virtual void testShift()
      {
         JDFMatrix m = new JDFMatrix(EnumOrientation.Rotate0, 0, 0);
         Assert.AreEqual(JDFMatrix.unitMatrix, m);
         m.shift(10, 11);
         Assert.AreEqual(new JDFMatrix("1 0 0 1 10 11"), m);
         m.shift(10, 11);
         Assert.AreEqual(new JDFMatrix("1 0 0 1 20 22"), m, "2nd shift adds up");
      }


      [TestMethod]
      public virtual void testShiftXY()
      {
         JDFMatrix m = new JDFMatrix(EnumOrientation.Rotate90, 0, 0);
         m.shift(new JDFXYPair(20, 25));
         Assert.AreEqual(new JDFMatrix("0 1 -1 0 20 25"), m);
      }


      [TestMethod]
      public virtual void testConcat()
      {
         JDFMatrix m = new JDFMatrix(EnumOrientation.Rotate90, 0, 0);
         JDFMatrix m2 = new JDFMatrix(EnumOrientation.Rotate270, 0, 0);
         m.concat(m2);
         Assert.AreEqual(JDFMatrix.unitMatrix, m);

         m = new JDFMatrix(EnumOrientation.Rotate90, 0, 0);
         m.concat(m);
         Assert.AreEqual(new JDFMatrix(EnumOrientation.Rotate180, 0, 0), m);

         m = new JDFMatrix(EnumOrientation.Flip180, 0, 0);
         m.concat(m);
         Assert.AreEqual(new JDFMatrix(EnumOrientation.Rotate0, 0, 0), m);

      }


      [TestMethod]
      public virtual void testClone()
      {
         JDFMatrix m = (JDFMatrix)JDFMatrix.unitMatrix.Clone();
         m.rotate(180);
         Assert.AreNotEqual(JDFMatrix.unitMatrix, m);
         Assert.AreEqual(JDFMatrix.unitMatrix, new JDFMatrix("1 0 0 1 0 0"));
         Assert.AreEqual(new JDFMatrix(EnumOrientation.Rotate180, 0, 0), m);
      }
   }
}
