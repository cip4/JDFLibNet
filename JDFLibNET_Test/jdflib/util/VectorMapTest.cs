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
 * @author muchadie
 */

namespace org.cip4.jdflib.util
{
   using Microsoft.VisualStudio.TestTools.UnitTesting;

   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;

   ///
   /// <summary> * @author Rainer Prosi, Heidelberger Druckmaschinen
   /// * tests for the VectorMap class </summary>
   /// 
   [TestClass]
   public class VectorMapTest : JDFTestCaseBase
   {
      private VectorMap<string, string> m;

      ///   
      ///	 <summary> *  </summary>
      ///	 
      [TestMethod]
      public virtual void testSize()
      {
         Assert.AreEqual(2, m.size("a"));
      }

      ///   
      ///	 <summary> * test for getOne </summary>
      ///	 
      [TestMethod]
      public virtual void testGetOne()
      {
         Assert.AreEqual("b", m.getOne("a", 0));
      }

      ///   
      ///	 <summary> * test for getIndex </summary>
      ///	 
      [TestMethod]
      public virtual void testGetIndex()
      {
         Assert.AreEqual(0, m.getIndex("a", "b"));
         Assert.AreEqual(1, m.getIndex("a", "c"));
         Assert.AreEqual(-1, m.getIndex("a", "d"));
         Assert.AreEqual(-2, m.getIndex("c", "c"));
      }


      [TestMethod]
      public virtual void testPutOne()
      {
         Assert.AreEqual(2, m.size("a"));
         m.putOne("a", "b");
         Assert.AreEqual("b", m.getOne("a", 0));
      }


      [TestMethod]
      public virtual void testremoveOne()
      {
         m.removeOne("a", "b");
         Assert.AreEqual("c", m.getOne("a", 0));
         Assert.AreEqual(-1, m.getIndex("a", "b"));
         Assert.AreEqual(1, m.size("a"));
         m.removeOne("a", "c");
         Assert.AreEqual(-2, m.getIndex("a", "b"));
         System.Collections.Generic.List<string> list = null;
         m.TryGetValue("a", out list);
         Assert.IsNull(list);
         m.removeOne("a", "c");
         Assert.AreEqual(-2, m.getIndex("a", "b"));
         m.TryGetValue("a", out list);
         Assert.IsNull(list);
      }


      [TestMethod]
      public virtual void testSetOne()
      {
         m.setOne("a", "b1", "b");
         Assert.AreEqual("b1", m.getOne("a", 0));
         Assert.AreEqual(2, m.size("a"));
         m.setOne("a", "b2", "b4");
         Assert.AreEqual("b2", m.getOne("a", 2));
         Assert.AreEqual(3, m.size("a"));
         m.setOne("aaa", "bb", "b4");
         Assert.AreEqual("bb", m.getOne("aaa", 0));
         Assert.AreEqual(1, m.size("aaa"));
      }


      [TestInitialize]
      public override void setUp()
      {
         // TODO Auto-generated method stub
         base.setUp();
         m = new VectorMap<string, string>();
         m.putOne("a", "b");
         m.putOne("a", "c");
         m.putOne("a2", "c");
      }
   }
}
