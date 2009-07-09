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
 * JDFDurationRangeTest.java
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


   using JDFDate = org.cip4.jdflib.util.JDFDate;
   using JDFDuration = org.cip4.jdflib.util.JDFDuration;

   [TestClass]
   public class JDFDurationTest 
   {

      [TestMethod]
      public void testNegativeDuration()
      {
         JDFDuration d = new JDFDuration(" -PT5M ");
         Assert.AreEqual("-PT5M", d.getDurationISO());
         try
         {
            new JDFDuration("--PT5M90.95S");
            Assert.Fail("bad duration string");
         }
         catch (Exception)
         {
         // nop
         }
         d = new JDFDuration("-P3M");
         Assert.AreEqual("-P3M", d.getDurationISO());
         Assert.AreEqual(-3 * 30 * 24 * 60 * 60, d.Duration);
         d = new JDFDuration("-P3MT4M");
         Assert.AreEqual("-P3MT4M", d.getDurationISO());
         Assert.AreEqual(-3 * 30 * 24 * 60 * 60 - 4 * 60, d.Duration);
         d = new JDFDuration("-P13M");
         Assert.AreEqual("-P1Y1M", d.getDurationISO());

         d = new JDFDuration("-P365D");
         Assert.AreEqual("-P1Y", d.getDurationISO());
         d = new JDFDuration("-P395D");
         Assert.AreEqual("-P1Y1M", d.getDurationISO());
         d = new JDFDuration("-PT3600S");
         Assert.AreEqual("-PT1H", d.getDurationISO());
         Assert.AreEqual("-PT0.95S", new JDFDuration("-PT0.95S").getDurationISO());
         Assert.AreEqual("-PT5M30.45S", new JDFDuration("-PT5M30.45S").getDurationISO());
         Assert.AreEqual("-PT6M30.95S", new JDFDuration("-PT5M90.95S").getDurationISO());
      }


      [TestMethod]
      public void testJDFDurationString()
      {
         JDFDuration d = new JDFDuration(" PT5M ");
         Assert.AreEqual("PT5M", d.getDurationISO());
         try
         {
            new JDFDuration("PT5M90.95aS");
            Assert.Fail("bad duration string");
         }
         catch (Exception)
         {
         // nop
         }
         try
         {
            new JDFDuration("PTM90.95aS");
            Assert.Fail("bad duration string");
         }
         catch (Exception)
         {
         // nop
         }
         d = new JDFDuration("P3M");
         Assert.AreEqual("P3M", d.getDurationISO());
         Assert.AreEqual(3 * 30 * 24 * 60 * 60, d.Duration);
         d = new JDFDuration("P3MT4M");
         Assert.AreEqual("P3MT4M", d.getDurationISO());
         Assert.AreEqual(3 * 30 * 24 * 60 * 60 + 4 * 60, d.Duration);
         d = new JDFDuration("P13M");
         Assert.AreEqual("P1Y1M", d.getDurationISO());

         d = new JDFDuration("P365D");
         Assert.AreEqual("P1Y", d.getDurationISO());
         d = new JDFDuration("P395D");
         Assert.AreEqual("P1Y1M", d.getDurationISO());
         d = new JDFDuration("PT3600S");
         Assert.AreEqual("PT1H", d.getDurationISO());
      }


      [TestMethod]
      public void testFractions()
      {
         Assert.AreEqual("PT1M30.5S", new JDFDuration(90.5).getDurationISO());
         Assert.AreEqual("-PT1M30.5S", new JDFDuration(-90.5).getDurationISO());
         Assert.AreEqual("PT0.95S", new JDFDuration("PT0.95S").getDurationISO());
         Assert.AreEqual("PT5M30.45S", new JDFDuration("PT5M30.45S").getDurationISO());
         Assert.AreEqual("PT6M30.95S", new JDFDuration("PT5M90.95S").getDurationISO());
      }


      [TestMethod]
      public void testCompareTo()
      {
         Assert.AreEqual(0, new JDFDuration(90.5).CompareTo(new JDFDuration(90.5)));
         Assert.AreEqual(0, new JDFDuration(-90.5).CompareTo(new JDFDuration(-90.5)));
         Assert.AreEqual(-1, new JDFDuration(-90.5).CompareTo(new JDFDuration(0)));
         Assert.AreEqual(-1, new JDFDuration(-90.5).CompareTo(new JDFDuration(-20)));
         Assert.AreEqual(1, new JDFDuration(90.5).CompareTo(new JDFDuration(0)));
         Assert.AreEqual(1, new JDFDuration(90.5).CompareTo(new JDFDuration(90)));
         Assert.AreEqual(-1, new JDFDuration(90.5).CompareTo(new JDFDuration(900)));
      }


      [TestMethod]
      public void testConstructFromDate()
      {
         JDFDate start = new JDFDate();
         JDFDate end = new JDFDate(start);
         Assert.AreEqual(new JDFDuration(0), new JDFDuration(start, end));
         end.addOffset(20, 0, 0, 0);
         Assert.AreEqual(new JDFDuration(20), new JDFDuration(start, end));
         start.addOffset(120, 0, 0, 0);
         Assert.AreEqual(new JDFDuration(-100), new JDFDuration(start, end));
      }


      [TestMethod]
      public void testAddSeconds()
      {
         JDFDuration duration = new JDFDuration();
         Assert.AreEqual(5.234, duration.addSeconds(5.234), 0.0001);
         Assert.AreEqual("PT5.234S", duration.getDurationISO());
      }


      [TestMethod]
      public void testSetDuration()
      {
         JDFDuration duration = new JDFDuration();
         duration.setDuration(65);
         Assert.AreEqual("PT1M5S", duration.getDurationISO());
         duration.setDuration(60 * 60 * 24 * 63);
         Assert.AreEqual("P2M3D", duration.getDurationISO());
         duration.addSeconds(65.5);
         Assert.AreEqual("P2M3DT1M5.5S", duration.getDurationISO());
         duration.addSeconds(60 * 60 * 3);
         Assert.AreEqual("P2M3DT3H1M5.5S", duration.getDurationISO());
         duration.addSeconds(60 * 60 * 3);
         Assert.AreEqual("P2M3DT6H1M5.5S", duration.getDurationISO());
      }
   }
}
