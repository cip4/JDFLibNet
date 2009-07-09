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


/* JDFDurationRangeTest.cs
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



   using JDFDuration = org.cip4.jdflib.util.JDFDuration;

   [TestClass]
   public class JDFDurationRangeTest
   {

      //   
      //	 * Constructors JDFDurationRange(JDFDuration) and
      //	 * JDFDurationRange(JDFDuration, JDFDuration)
      //	 
      [TestMethod]
      public void testJDFDurationRangeJDFDuration()
      {
         JDFDurationRange r = new JDFDurationRange(new JDFDuration("PT5M"), new JDFDuration("PT15M"));
         JDFDurationRange r2 = new JDFDurationRange(new JDFDuration("PT5M"));

         Assert.IsTrue(r.ToString().Equals("PT5M ~ PT15M"), "Bad Constructor ");
         Assert.IsTrue(r2.ToString().Equals("PT5M"), "Bad Constructor ");
      }

      //   
      //	 * Class under test for void JDFDurationRange(JDFDurationRange)
      //	 
      [TestMethod]
      public void testJDFDurationRangeJDFDurationRange()
      {
         JDFDurationRange r = new JDFDurationRange(new JDFDuration("PT5M"), new JDFDuration("PT25M"));
         JDFDurationRange r2 = new JDFDurationRange(new JDFDuration("PT15M"));
         JDFDurationRange r3 = new JDFDurationRange(r2);
         r3.Right = new JDFDuration("PT25M");
         Assert.IsTrue(r.ToString().Equals("PT5M ~ PT25M"), "Bad Constructor" + r.ToString());
         Assert.IsTrue(r2.ToString().Equals("PT15M"), "Bad Constructor" + r2.ToString());
         Assert.IsTrue(r3.ToString().Equals("PT15M ~ PT25M"), "Bad CopyConstructor" + r3.ToString());
      }

      [TestMethod]
      public void testJDFDurationRangeString()
      {
         JDFDurationRange r = new JDFDurationRange(" PT5M ~ PT15M ");

         Assert.IsTrue(r.ToString().Equals("PT5M ~ PT15M"), "Bad Constructor" + r.ToString());
      }

      [TestMethod]
      public void testInRange()
      {
         JDFDurationRangeList rangelist = new JDFDurationRangeList("PT5M ~ PT15M  PT1H5M ~ PT1H15M");

         Assert.IsTrue(rangelist.inRange(new JDFDuration("PT15M")), "InRange: ");
         Assert.IsTrue(rangelist.inRange(new JDFDuration("PT1H15M")), "InRange: ");
         Assert.IsFalse(rangelist.inRange(new JDFDuration("PT1H25M")), "NOT InRange: ");
         Assert.IsFalse(rangelist.inRange(new JDFDuration("PT55S")), "NOT InRange: ");

      }

      [TestMethod]
      public void testJDFDuration()
      {

         JDFDuration d = new JDFDuration("PT5M");
         JDFDuration d1 = new JDFDuration("PT50M");

         try
         {
            new JDFDuration("P0T5M");
            Assert.Fail("invalid duration String");

         }
         catch (FormatException)
         {
            //
         }

         try
         {
            new JDFDuration("PT5MS");
            Assert.Fail("invalid duration String");

         }
         catch (FormatException)
         {
            //
         }
         JDFDuration p1 = new JDFDuration("P1Y2M3DT50M");
         JDFDuration p11 = new JDFDuration("P01Y02M03DT50M");
         Assert.AreEqual(p1, p11);
         JDFDuration p2 = new JDFDuration("P01Y02M03D");
         JDFDuration p3 = new JDFDuration("P1Y2M3DT10H30M");
         Assert.IsTrue(d.Duration == 300, "Bad Constructor d");
         Assert.IsTrue(d1.Duration == 3000, "Bad Constructor d1");
         Assert.IsTrue(p1.getDurationISO().Equals("P1Y2M3DT50M"), "Bad Constructor p1");
         Assert.IsTrue(p2.getDurationISO().Equals("P1Y2M3D"), "Bad Constructor p2");
         Assert.IsTrue(p3.getDurationISO().Equals("P1Y2M3DT10H30M"), "Bad Constructor p2");
      }
   }
}
