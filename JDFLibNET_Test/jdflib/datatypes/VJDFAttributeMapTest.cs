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
 * VJDFAttributeMapTest.cs
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
   using VString = org.cip4.jdflib.core.VString;

   ///
   /// <summary> * @author Rainer Prosi, Heidelberger Druckmaschinen
   /// * </summary>
   /// 
   [TestClass]
   public class VJDFAttributeMapTest : JDFTestCaseBase
   {
      ///   
      ///	 <summary> * tests clone </summary>
      ///	 
      [TestMethod]
      public virtual void testClone()
      {
         JDFAttributeMap m1 = new JDFAttributeMap("a1", "v1");
         m1.put("a2", "v2");
         JDFAttributeMap m2 = new JDFAttributeMap(m1);
         m2.put("a2", "v3");
         VJDFAttributeMap v = new VJDFAttributeMap((VJDFAttributeMap)null);
         v.Add(m1);
         v.Add(m2);
         VJDFAttributeMap v2 = new VJDFAttributeMap(v);
         Assert.AreEqual(v2, v);
         m1.put("a3", "a4");
         Assert.AreNotEqual(v2, v, "modification did not migrate!");
      }

      ///   
      ///	 <summary> * tests subMap() </summary>
      ///	 
      [TestMethod]
      public virtual void testSubMap()
      {
         JDFAttributeMap m1 = new JDFAttributeMap("a1", "v1");
         m1.put("a2", "v2");
         JDFAttributeMap m2 = new JDFAttributeMap(m1);
         m2.put("a2", "v3");
         VJDFAttributeMap v = new VJDFAttributeMap();
         v.Add(m1);
         v.Add(m2);
         Assert.IsTrue(v.subMap(m1));
         Assert.IsTrue(v.subMap(m2));
         v.put("a3", "v4");
         JDFAttributeMap m3 = new JDFAttributeMap(m1);
         Assert.IsTrue(v.subMap(m3));
         m3.put("a3", "v5");
         Assert.IsFalse(v.subMap(m3));
      }

      ///   
      ///	 <summary> * tests OvelapsMap for individual maps </summary>
      ///	 
      [TestMethod]
      public virtual void testOverlapsMap()
      {
         JDFAttributeMap m1 = new JDFAttributeMap("a1", "v1");
         m1.put("a2", "v2");
         JDFAttributeMap m2 = new JDFAttributeMap(m1);
         m2.put("a2", "v3");
         VJDFAttributeMap v = new VJDFAttributeMap();
         v.Add(m1);
         v.Add(m2);
         Assert.IsTrue(v.overlapsMap(m1));
         Assert.IsFalse(v.overlapsMap(new JDFAttributeMap("a2", "v4")));
      }

      ///   
      ///	 <summary> * tests OvelapsMap for vectors of maps </summary>
      ///	 
      [TestMethod]
      public virtual void testOverlapsMapVector()
      {
         JDFAttributeMap m1 = new JDFAttributeMap("a1", "v1");
         m1.put("a2", "v2");
         JDFAttributeMap m2 = new JDFAttributeMap(m1);
         m2.put("a2", "v3");
         VJDFAttributeMap v = new VJDFAttributeMap();
         v.Add(m1);
         v.Add(m2);
         VJDFAttributeMap v2 = new VJDFAttributeMap();
         Assert.IsTrue(v.overlapsMap(v2));
         v2.Add(new JDFAttributeMap(m1));
         Assert.IsTrue(v.overlapsMap(v2));
         v2.Add(new JDFAttributeMap("a2", "v4"));
         Assert.IsTrue(v.overlapsMap(v2));
         v.put("foo", "bar");
         Assert.IsTrue(v.overlapsMap(v2));
         v2.put("foo", "notbar");
         Assert.IsFalse(v.overlapsMap(v2));
      }

      ///   
      ///	 <summary> * tests addAll </summary>
      ///	 
      [TestMethod]
      public virtual void testAddAll()
      {
         JDFAttributeMap m1 = new JDFAttributeMap("a1", "v1");
         m1.put("a2", "v2");
         JDFAttributeMap m2 = new JDFAttributeMap(m1);
         m2.put("a2", "v3");
         JDFAttributeMap m3 = new JDFAttributeMap(m1);
         m3.put("a2", "v3");
         VJDFAttributeMap v = new VJDFAttributeMap();
         v.Add(m1);
         v.Add(m2);
         VJDFAttributeMap v2 = new VJDFAttributeMap();
         v2.Add(m2);
         v2.Add(m3);
         v.addAll(v2);
         Assert.AreEqual(4, v.Count);
         Assert.IsTrue(v.Contains(m1));
         Assert.IsTrue(v.Contains(m2));
         Assert.IsTrue(v.Contains(m3));

      }

      ///   
      ///	 <summary> *  </summary>
      ///	 
      [TestMethod]
      public virtual void testShowKeys()
      {
         JDFAttributeMap m1 = new JDFAttributeMap();
         m1.put("a2", "v2");
         JDFAttributeMap m2 = new JDFAttributeMap(m1);
         m2.put("a2", "v3");
         m2.put("a3", "v3");
         VJDFAttributeMap v = new VJDFAttributeMap();
         v.Add(m1);
         v.Add(m2);
         Assert.AreEqual("[0](a2 = v2)-[1](a2 = v3) (a3 = v3)", v.showKeys("-", " "));
      }

      ///   
      ///	 <summary> * test Unify </summary>
      ///	 
      [TestMethod]
      public virtual void testUnify()
      {
         JDFAttributeMap m1 = new JDFAttributeMap("a1", "v1");
         m1.put("a2", "v2");
         JDFAttributeMap m2 = new JDFAttributeMap(m1);
         m2.put("a2", "v3");
         JDFAttributeMap m3 = new JDFAttributeMap(m1);
         m3.put("a2", "v3");
         VJDFAttributeMap v = new VJDFAttributeMap();
         v.Add(m1);
         v.Add(m2);
         v.Add(m3);
         v.unify();
         Assert.AreEqual(2, v.Count);
         Assert.IsTrue(v.Contains(m1));
         Assert.IsTrue(v.Contains(m2));
         Assert.IsTrue(v.Contains(m3));
         v.Add(m1);
         v.Add(m2);
         v.Add(m3);
         v.Add(m1);
         v.Add(m2);
         v.Add(m3);
         v.unify();
         Assert.AreEqual(2, v.Count);
         Assert.IsTrue(v.Contains(m1));
         Assert.IsTrue(v.Contains(m2));
         Assert.IsTrue(v.Contains(m3));

         v.Add(null);
         v.unify();
         Assert.AreEqual(3, v.Count);
         Assert.IsTrue(v.Contains(m1));
         Assert.IsTrue(v.Contains(m2));
         Assert.IsTrue(v.Contains(m3));
         Assert.IsTrue(v.Contains(null));

      }

      ///   
      ///	 <summary> * test Equals() </summary>
      ///	 
      [TestMethod]
      public virtual void testEquals()
      {
         JDFAttributeMap m1 = new JDFAttributeMap("a1", "v1");
         m1.put("a2", "v2");
         JDFAttributeMap m2 = new JDFAttributeMap(m1);
         m2.put("a2", "v3");
         VJDFAttributeMap v = new VJDFAttributeMap();
         v.Add(m1);
         v.Add(m2);
         VJDFAttributeMap v2 = new VJDFAttributeMap();
         v2.Add(m2);
         v2.Add(m1);
         Assert.AreEqual(v2, v, "mixed ordering");
         v2.Add(m1);
         Assert.AreNotEqual(v2, v, "mixed ordering -other cardinality ");
      }

      ///   
      ///	 <summary> * tests copy constructor </summary>
      ///	 
      [TestMethod]
      public virtual void testCopy()
      {
         JDFAttributeMap m1 = new JDFAttributeMap("a1", "v1");
         VJDFAttributeMap v2 = new VJDFAttributeMap();
         v2.Add(new JDFAttributeMap(m1));
         VJDFAttributeMap v3 = new VJDFAttributeMap(v2);
         Assert.AreEqual(v3, v2);
      }

      ///   
      ///	 <summary> * tests put method </summary>
      ///	 
      [TestMethod]
      public virtual void testPut()
      {
         JDFAttributeMap m1 = new JDFAttributeMap("a1", "v1");
         VJDFAttributeMap v2 = new VJDFAttributeMap();
         v2.Add(m1);
         VJDFAttributeMap v3 = new VJDFAttributeMap(v2);
         Assert.AreEqual(v3, v2);
         v3.put("a2", "b");
         m1.put("a2", "b");
         Assert.AreEqual(v2, v3);
         VJDFAttributeMap v4 = new VJDFAttributeMap((VJDFAttributeMap)null);
         v4.put("a1", "b1");
         Assert.AreEqual(1, v4.Count);

      }

      ///   
      ///	 <summary> * test reduceMap() </summary>
      ///	 
      [TestMethod]
      public virtual void testReduceMap()
      {
         JDFAttributeMap m1 = new JDFAttributeMap("a1", "v1");
         VJDFAttributeMap v2 = new VJDFAttributeMap();
         v2.Add(new JDFAttributeMap(m1));
         m1.put("a2", "v2");
         JDFAttributeMap m2 = new JDFAttributeMap(m1);
         m2.put("a2", "v3");
         VJDFAttributeMap v = new VJDFAttributeMap();
         v.Add(m1);
         v.Add(m2);
         VString vs = new VString("a1", " ");
         v.reduceMap(vs.getSet());
         Assert.AreEqual(v2, v);
      }

      ///   
      ///	 <summary> * test removeKeys() </summary>
      ///	 
      [TestMethod]
      public virtual void testRemoveKeys()
      {
         JDFAttributeMap m1 = new JDFAttributeMap("a1", "v1");
         VJDFAttributeMap v2 = new VJDFAttributeMap();
         v2.Add(new JDFAttributeMap(m1));
         m1.put("a2", "v2");
         JDFAttributeMap m2 = new JDFAttributeMap(m1);
         m2.put("a2", "v3");
         VJDFAttributeMap v = new VJDFAttributeMap();
         v.Add(m1);
         v.Add(m2);
         VString vs = new VString("a2", " ");
         v.removeKeys(vs.getSet());
         Assert.AreEqual(v2, v);
         Assert.AreEqual(1, v.Count);
      }
   }
}
