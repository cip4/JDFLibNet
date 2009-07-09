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
   using System.Collections.Generic;
   using Microsoft.VisualStudio.TestTools.UnitTesting;


   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using IMatches = org.cip4.jdflib.ifaces.IMatches;
   using VString = org.cip4.jdflib.core.VString;

   ///
   /// <summary> * general utilities for containers and objects
   /// * 
   /// * @author Rainer Prosi
   /// *  </summary>
   /// 
   [TestClass]
   public class ContainerUtilTest : JDFTestCaseBase
   {
      private class SimpleMatch : IMatches
      {
         private readonly int i;

         public SimpleMatch(int pi)
            : base()
         {
            this.i = pi;
         }

         //      
         //		 * (non-Javadoc)
         //		 * 
         //		 * @see org.cip4.jdflib.ifaces.IMatches#matches(java.lang.Object)
         //		 
         public virtual bool matches(object subset)
         {
            return ((SimpleMatch)subset).i == i;
         }

         //      
         //		 * (non-Javadoc)
         //		 * 
         //		 * @see java.lang.Object#equals(java.lang.Object)
         //		 
         public override bool Equals(object obj)
         {
            return matches(obj);
         }



         public override int GetHashCode()
         {
            return base.GetHashCode();
         }

      }

      [TestMethod]
      public virtual void testEquals()
      {
         Assert.IsTrue(ContainerUtil.Equals(null, null));
         Assert.IsFalse(ContainerUtil.Equals(null, ""));
         Assert.IsFalse(ContainerUtil.Equals("", null));
         Assert.IsFalse(ContainerUtil.Equals("", " "));
         Assert.IsTrue(ContainerUtil.Equals("a", "a"));
      }


      [TestMethod]
      public virtual void testGetMatch()
      {
         List<SimpleMatch> v = new List<SimpleMatch>();
         for (int i = 0; i < 10; i++)
            v.Add(new SimpleMatch(i % 2));
         SimpleMatch simpleMatch1 = new SimpleMatch(1);
         Assert.AreEqual(5, ContainerUtil.getMatches(v, simpleMatch1).Count);
         Assert.AreEqual(simpleMatch1, ContainerUtil.getMatch(v, simpleMatch1, 0));
      }


      [TestMethod]
      public virtual void testToHashSetArray()
      {
         string[] a = { "a", "b" };
         SupportClass.SetSupport<string> s = ContainerUtil.toHashSet(a);
         Assert.IsTrue(s.Contains("a"));
         Assert.IsTrue(s.Contains("b"));
         Assert.IsFalse(s.Contains("c"));
         Assert.AreEqual(s.Count, a.Length);
      }


      [TestMethod]
      public virtual void testToValueVector()
      {
         Dictionary<string, string> hm = new Dictionary<string, string>();
         for (int i = 0; i < 10; i++)
            hm.Add("" + i, "a" + i);
         List<string> v = ContainerUtil.toValueVector(hm, false);
         Assert.AreEqual(v.Count, 10);
         VString vString = new VString(v);
         List<string> vs = ContainerUtil.toValueVector(hm, true);
         VString vsString = new VString(vs);

         Assert.IsTrue(vsString.ContainsAll(vString));
         Assert.IsTrue(vString.ContainsAll(vsString));
         for (int i = 1; i < 10; i++)
            Assert.IsTrue(vs[i - 1].CompareTo(vs[i]) < 0);
      }
   }
}
