
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



/* 
 * VElementTest.cs
 * 
 * @author Dietrich Mucha
 *
 * Copyright (C) 2002 Heidelberger Druckmaschinen AG. All Rights Reserved
 */

namespace org.cip4.jdflib.core
{
   using System.Collections;
   using System.Collections.Generic;
   using Microsoft.VisualStudio.TestTools.UnitTesting;


   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using JDFNode = org.cip4.jdflib.node.JDFNode;

   [TestClass]
   public class VElementTest 
   {

      [TestMethod]
      public virtual void testAddAll()
      {
         XMLDoc d = new XMLDoc("doc", null);
         KElement e = d.getRoot();
         VElement v = new VElement();
         v.addAll((VElement)null);
         Assert.AreEqual(0, v.Count);
         v.Add(e);
         Assert.AreEqual(1, v.Count);
         v.addAll(v);
         Assert.AreEqual(2, v.Count);
         v.addAll(v);
         Assert.AreEqual(4, v.Count);
      }


      // Java to C# Conversion - Not sure what exactly is being tested here.  Casting VElement to List<JDFNode> is not working anyway.
      //[TestMethod]
      //public virtual void testCastVector()
      //{
      //   JDFDoc d = new JDFDoc("JDF");
      //   JDFNode n = d.getJDFRoot();
      //   VElement v = new VElement();
      //   v.Add(n);
      //   List<JDFNode> ll = (List<JDFNode>) v;
      //   ll[0].addResource("foo", EnumUsage.Input);
      //}


      [TestMethod]
      public virtual void testContainsElement()
      {
         XMLDoc d = new XMLDoc("doc", null);
         KElement e = d.getRoot();
         KElement e1 = e.appendElement("e1");
         e1.setAttribute("a", "b");
         VElement v = new VElement();
         v.appendUnique(e1);
         e1 = e.appendElement("e1");
         e1.setAttribute("a", "b");
         Assert.IsTrue(v.containsElement(e1), "containsElement");
         Assert.IsFalse(v.Contains(e1), "contains");
         e1.setText("foo");
         Assert.IsFalse(v.containsElement(e1), "containsElement");
         v.appendUnique(e1);
         Assert.AreEqual(2, v.Count, "size");
         e1 = e.appendElement("e1");
         e1.setAttribute("a", "b");
         e1.setText("foo");
         Assert.IsTrue(v.containsElement(e1), "containsElement");
         e1.setText("bar");
         Assert.IsFalse(v.containsElement(e1), "containsElement");

      }


      [TestMethod]
      public virtual void testgetNodeNames()
      {
         XMLDoc d = new XMLDoc("doc", null);
         KElement e = d.getRoot();
         e.appendElement("a1");
         e.appendElement("b:a2", "b");
         VElement v = e.getChildElementVector(null, null, null, true, 0, true);
         VString s = v.getElementNameVector(false);
         CollectionAssert.AreEqual(new VString("a1 b:a2", " "), s);
         s = v.getElementNameVector(true);
         CollectionAssert.AreEqual(new VString("a1 a2", " "), s);
      }


      [TestMethod]
      public virtual void testUnify()
      {
         XMLDoc d = new XMLDoc("doc", null);
         KElement e = d.getRoot();
         KElement e1 = e.appendElement("e1");
         e1.setAttribute("a", "b");
         VElement v = new VElement();
         v.Add(e1);
         v.Add(e1);
         e1 = e.appendElement("e1");
         e1.setAttribute("a", "b");
         v.Add(e1);
         Assert.AreEqual(3, v.Count);
         v.unify();
         Assert.AreEqual(2, v.Count);
         v.unifyElement();
         Assert.AreEqual(1, v.Count);
      }


      [TestMethod]
      public virtual void testSort()
      {
         XMLDoc d = new XMLDoc("doc", null);
         KElement e = d.getRoot();
         KElement e1 = e.appendElement("e1");
         e1.setAttribute("a", "z");
         KElement e2 = e.appendElement("e1");
         e2.setAttribute("a", "c");
         VElement v = new VElement();
         v.Add(e1);
         v.Add(e2);
         v.Sort();
         Assert.AreEqual(e2, v[0]);
      }


      [TestMethod]
      public virtual void testIsEqual()
      {
         XMLDoc d = new XMLDoc("doc", null);
         KElement e = d.getRoot();
         KElement e1 = e.appendElement("e1");
         e1.setAttribute("a", "b");
         KElement e2 = e.appendElement("e1");
         e2.setAttribute("a", "c");
         KElement e3 = e.appendElement("e1");
         e3.setAttribute("a", "c");
         KElement e4 = e.appendElement("e1");
         e4.setAttribute("a", "d");
         VElement v = new VElement();
         v.Add(e1);
         v.Add(e2);
         VElement v2 = new VElement(v);
         Assert.IsTrue(v.isEqual(v2));
         v2[1] = e3;
         Assert.IsTrue(v.isEqual(v2));
         v2[1] = e4;
         Assert.IsFalse(v.isEqual(v2));
      }
   }
}