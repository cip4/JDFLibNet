
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


namespace org.cip4.jdflib.datatypes
{
   using System;
   using System.Collections.Generic;
   using Microsoft.VisualStudio.TestTools.UnitTesting;

   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using EnumSide = org.cip4.jdflib.auto.JDFAutoPart.EnumSide;
   using VString = org.cip4.jdflib.core.VString;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using EnumPartIDKey = org.cip4.jdflib.resource.JDFResource.EnumPartIDKey;

   ///
   /// <summary> * test of JDFAttributemap
   /// * @author Rainer Prosi, Heidelberger Druckmaschinen
   /// * </summary>
   /// 

   [TestClass]
   public class JDFAttributeMapTest : JDFTestCaseBase
   {

      [TestMethod]
      public virtual void testShowKeys()
      {
         JDFAttributeMap m1 = new JDFAttributeMap("a1", "v1");
         Assert.AreEqual("(a1 = v1)", m1.showKeys(" "));
         m1.put("b1", "v2");
         Assert.AreEqual("(a1 = v1) (b1 = v2)", m1.showKeys(" "));
         Assert.AreEqual("(a1 = v1)\n(b1 = v2)", m1.showKeys("\n"));
         Assert.AreEqual("(a1 = v1)(b1 = v2)", m1.showKeys(null));
      }


      [TestMethod]
      public virtual void testClone()
      {
         JDFAttributeMap m1 = new JDFAttributeMap("a1", "v1");
         m1.put("a2", "v2");
         JDFAttributeMap m2 = new JDFAttributeMap(m1);
         Assert.AreEqual(m1, m2);
         m2.put("a2", "v3");
         Assert.AreNotEqual(m1, m2);
         Assert.AreEqual("v2", m1.get("a2"));
         Assert.AreEqual("v3", m2.get("a2"));
      }


      [TestMethod]
      public virtual void testCloneNull()
      {
         JDFAttributeMap m1 = new JDFAttributeMap(null);
         m1.put("a2", "v2");
         JDFAttributeMap m2 = new JDFAttributeMap(m1);
         Assert.AreEqual(m1, m2);
         m2.put("a2", "v3");
         Assert.AreNotEqual(m1, m2);
         Assert.AreEqual("v2", m1.get("a2"));
         Assert.AreEqual("v3", m2.get("a2"));
      }


      [TestMethod]
      public virtual void testEquals()
      {
         JDFAttributeMap m1 = new JDFAttributeMap("a1", "v1");
         m1.put("a2", "v2");
         JDFAttributeMap m2 = new JDFAttributeMap("a1", "v1");
         Assert.AreNotEqual(m1, m2);
         m2.put("a2", "v2");
         Assert.AreEqual(m1, m2);
         m1.put("a2", null);
         Assert.AreNotEqual(m1, m2);
         m2.put("a2", null);
         Assert.AreEqual(m1, m2);
         Assert.AreNotEqual(null, m1);
      }


      [TestMethod]
      public virtual void testPut()
      {
         JDFAttributeMap m1 = new JDFAttributeMap(EnumPartIDKey.SignatureName, "v1");
         Assert.AreEqual("v1", m1.get("SignatureName"));
         m1.put(EnumPartIDKey.SheetName, "s1");
         Assert.AreEqual("s1", m1.get("SheetName"));
         m1.put(EnumPartIDKey.Side, EnumSide.Front);
         Assert.AreEqual("Front", m1.get("Side"));
         m1.put("Usage", EnumUsage.Input);
         Assert.AreEqual("Input", m1.get("Usage"));
      }


      [TestMethod]
      public virtual void testGet()
      {
         JDFAttributeMap m1 = new JDFAttributeMap(EnumPartIDKey.SignatureName, "v1");
         Assert.AreEqual("v1", m1.get("SignatureName"));
         m1.put(EnumPartIDKey.SheetName, "s1");
         Assert.AreEqual("v1", m1.get(EnumPartIDKey.SignatureName));
      }


      [TestMethod]
      public virtual void testSubMap()
      {
         JDFAttributeMap m1 = new JDFAttributeMap("a1", "v1");
         m1.put("a2", "v2");
         Assert.IsTrue(m1.subMap((JDFAttributeMap)null));
         JDFAttributeMap m2 = new JDFAttributeMap("a1", "v1");
         JDFAttributeMap mStar = new JDFAttributeMap("a1", (string)null);
         Assert.IsTrue(m1.subMap(m2));
         Assert.IsTrue(m1.subMap(mStar));
         m2.put("a2", "v2");
         mStar = new JDFAttributeMap("a1", "*");
         Assert.IsTrue(m1.subMap(m2));
         Assert.IsTrue(m1.subMap(mStar));
         m2.put("a2", "v3");
         Assert.IsFalse(m1.subMap(m2));
         m2.put("a2", "v2");
         Assert.IsTrue(m1.subMap(m2));
         m2.put("a3", "v3");
         Assert.IsFalse(m1.subMap(m2));
         Assert.IsTrue(m1.subMap((JDFAttributeMap)null));
      }


      [TestMethod]
      public virtual void testOverlapMap()
      {
         JDFAttributeMap m1 = new JDFAttributeMap("a1", "v1");
         m1.put("a2", "v2");
         Assert.IsTrue(m1.overlapMap((JDFAttributeMap)null));
         JDFAttributeMap m2 = new JDFAttributeMap("a1", "v1");
         Assert.IsTrue(m1.overlapMap(m2));
         m2.put("a2", "v2");
         Assert.IsTrue(m1.overlapMap(m2));
         m2.put("a2", "v3");
         Assert.IsFalse(m1.overlapMap(m2));
         m2.put("a2", "v2");
         Assert.IsTrue(m1.overlapMap(m2));
         m2.put("a2", "*");
         Assert.IsTrue(m1.overlapMap(m2));
         m2.put("a3", "v3");
         Assert.IsTrue(m1.overlapMap(m2));
         m2.put("a4", null);
         Assert.IsTrue(m1.overlapMap(m2));
         m2.put("a4", null);
         Assert.IsTrue(m1.overlapMap(m2));
         m1.put("a4", null);
         Assert.IsTrue(m1.overlapMap(m2));
         Assert.IsTrue(m1.overlapMap((JDFAttributeMap)null));
      }


      [Obsolete, TestMethod]
      public virtual void testReduceMap()
      {
         JDFAttributeMap m1 = new JDFAttributeMap("a1", "v1");
         m1.put("a2", "v2");
         JDFAttributeMap m2 = new JDFAttributeMap("a1", "v1");
         VString keys = new VString();
         keys.Add("a1");
         m1.reduceMap(keys);
         Assert.AreEqual(m1, m2);
      }


      [TestMethod]
      public virtual void testReduceMapSet()
      {
         JDFAttributeMap m1 = new JDFAttributeMap("a1", "v1");
         m1.put("a2", "v2");
         JDFAttributeMap m2 = new JDFAttributeMap("a1", "v1");
         SupportClass.HashSetSupport<string> keys = new SupportClass.HashSetSupport<string>();
         keys.Add("a1");
         m1.reduceMap(keys);
         Assert.AreEqual(m1, m2);
      }


      [TestMethod]
      public virtual void testRemoveKeys()
      {
         JDFAttributeMap m1 = new JDFAttributeMap("a1", "v1");
         m1.put("a2", "v2");
         JDFAttributeMap m2 = new JDFAttributeMap("a1", "v1");
         SupportClass.HashSetSupport<string> keys = new SupportClass.HashSetSupport<string>();
         keys.Add("a2");
         m1.removeKeys(keys);
         Assert.AreEqual(m1, m2);
         m1.put("a2", null);
         Assert.AreNotEqual(m1, m2);
         m1.removeKeys(keys);
         Assert.AreEqual(m1, m2);
      }
   }
}
