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
 * JDFDateTest.java
 * 
 * @author Dietrich Mucha
 *
 * Copyright (C) 2002 Heidelberger Druckmaschinen AG. All Rights Reserved. 
 */

namespace org.cip4.jdflib.util
{
   using System;
   using Microsoft.VisualStudio.TestTools.UnitTesting;



   [TestClass]
   public class JDFDateTest
   {
      [TestMethod]
      public virtual void testBadDate()
      {
         JDFDate date;
         try
         {
            date = new JDFDate("1999+09-26T11:43:10+03:00");
            Assert.Fail("date exception: " + date);
         }
         catch (FormatException)
         {
            //
         }

         try
         {
            date = new JDFDate("1999");
            Assert.Fail("date exception: " + date);
         }
         catch (FormatException)
         {
            //
         }

         try
         {
            date = new JDFDate((string)null);
         }
         catch (FormatException)
         {
            Assert.Fail("date exception: ");
         }

         try
         {
            date = new JDFDate("1975-01-01T20:00:10.5");
            Assert.Fail("date exception: " + date);
         }
         catch (FormatException)
         {
            //
         }

         try
         {
            date = new JDFDate("2004-11-26T11:43:10.33-03");
            Assert.Fail("date exception: " + date);
         }
         catch (FormatException)
         {
            //
         }

         try
         {
            date = new JDFDate("2004-11-26T11:43:10.-0300");
            Assert.Fail("date exception: " + date);
         }
         catch (FormatException)
         {
            //
         }
      }

      ///   
      ///	 <summary> * Method testdateOnly </summary>
      ///	 
      [TestMethod]
      public virtual void testdateOnly()
      {
         JDFDate date = new JDFDate();
         string strDate = date.DateTimeISO;
         date = new JDFDate("2006-11-26");
         strDate = date.DateTimeISO;
         Assert.AreEqual("2006-11-26T00:00:00" + new JDFDate().TimeZoneISO, strDate, "Bug " + strDate);
      }

      ///   
      ///	 <summary> * Method testdateTimeISO. </summary>
      ///	 
      [TestMethod]
      public virtual void testdateTimeZone()
      {
         JDFDate date = new JDFDate();
         string strDate = date.DateTimeISO;
         JDFDate date2 = new JDFDate(strDate);
         Assert.AreEqual(date, date2);
      }

      ///   
      ///	 <summary> * Method testdateTimeISO. </summary>
      ///	 
      [TestMethod]
      public virtual void testdateTimeISO()
      {
         JDFDate date = new JDFDate();
         string strDate = date.DateTimeISO;
         // summer
         date = new JDFDate("1999-09-26T11:43:10+03:00");
         strDate = date.DateTimeISO;
         Assert.IsTrue(strDate.Equals("1999-09-26T11:43:10+03:00"), "Bug " + strDate + " is not equal to 1999-09-26T11:43:10+03:00");

         date = new JDFDate("1999-09-26T11:43:10-03:00");
         strDate = date.DateTimeISO;
         Assert.IsTrue(strDate.Equals("1999-09-26T11:43:10-03:00"), "Bug " + strDate + " is not equal to 1999-09-26T11:43:10-03:00");

         // winter
         date = new JDFDate("1999-11-26T11:43:10+03:00");
         strDate = date.DateTimeISO;
         Assert.IsTrue(strDate.Equals("1999-11-26T11:43:10+03:00"), "Bug " + strDate + " is not equal to 1999-11-26T11:43:10+03:00");

         date = new JDFDate("1999-11-26T11:43:10-03:00");
         strDate = date.DateTimeISO;
         Assert.IsTrue(strDate.Equals("1999-11-26T11:43:10-03:00"), "Bug " + strDate + " is not equal to 1999-11-26T11:43:10-03:00");

         // note the various A,c zulu etc times below
         date = new JDFDate("1999-11-26T11:43:10a");
         strDate = date.DateTimeISO;
         Assert.AreEqual("1999-11-26T11:43:10+01:00", strDate, "Bug ");

         date = new JDFDate("1999-11-26T11:43:10C");
         strDate = date.DateTimeISO;
         Assert.AreEqual("1999-11-26T11:43:10+03:00", strDate, "Bug ");

         date = new JDFDate("1999-11-26T11:43:10Z");
         strDate = date.DateTimeISO;
         Assert.AreEqual("1999-11-26T11:43:10+00:00", strDate, "Bug ");

         date = new JDFDate("1999-11-26T11:43:10i");
         strDate = date.DateTimeISO;
         Assert.AreEqual("1999-11-26T11:43:10+09:00", strDate, "Bug ");

         date = new JDFDate("1999-11-26T11:43:10K");
         strDate = date.DateTimeISO;
         Assert.AreEqual("1999-11-26T11:43:10+10:00", strDate, "Bug ");

         date = new JDFDate("1999-11-26T11:43:10M");
         strDate = date.DateTimeISO;
         Assert.AreEqual("1999-11-26T11:43:10+12:00", strDate, "Bug ");

         date = new JDFDate("1999-11-26T11:43:10N");
         strDate = date.DateTimeISO;
         Assert.AreEqual("1999-11-26T11:43:10-01:00", strDate, "Bug ");

         date = new JDFDate("1999-11-26T11:43:10V");
         strDate = date.DateTimeISO;
         Assert.AreEqual("1999-11-26T11:43:10-09:00", strDate, "Bug ");

         date = new JDFDate("1999-11-26T11:43:10W");
         strDate = date.DateTimeISO;
         Assert.AreEqual("1999-11-26T11:43:10-10:00", strDate, "Bug ");

         date = new JDFDate("1999-11-26T11:43:10Y");
         strDate = date.DateTimeISO;
         Assert.AreEqual("1999-11-26T11:43:10-12:00", strDate, "Bug ");

         date = new JDFDate("1999-11-26T11:43:10.123Y");
         strDate = date.DateTimeISO;
         Assert.AreEqual("1999-11-26T11:43:10-12:00", strDate, "Bug ");

         date = new JDFDate("1999-11-26T11:43:10.12345-03:00");
         strDate = date.DateTimeISO;
         Assert.IsTrue(strDate.Equals("1999-11-26T11:43:10-03:00"), "Bug " + strDate + " is not equal to 1999-11-26T11:43:10-03:00");

         date = new JDFDate("2004-11-26T11:43:10.-03:00");
         strDate = date.DateTimeISO;
         Assert.IsTrue(strDate.Equals("2004-11-26T11:43:10-03:00"), "Bug " + strDate + " is not equal to 2004-11-26T11:43:10-03:00");

         // date = new JDFDate("2004-11-26T11:43:10");
         // Assert.IsNotNull(date);
         // strDate = date.DateTimeISO;

      }


      [TestMethod]
      public virtual void testEquals()
      {
         JDFDate date1 = new JDFDate();
         JDFDate date2 = new JDFDate(date1);
         Assert.AreEqual(date1, date2);
         Assert.IsTrue(date1.Equals(date2));
      }


      [TestMethod]
      public virtual void testSort()
      {
         JDFDate[] a = new JDFDate[10];
         JDFDate date1 = new JDFDate();
         for (int i = 0; i < 10; i++)
         {
            JDFDate date2 = new JDFDate(date1);
            date2.addOffset(10 * (i % 3) + i, 0, 0, 0);
            a[i] = date2;
         }
         System.Array.Sort(a);
         for (int i = 0; i < 9; i++)
         {
            Assert.IsTrue(a[i].CompareTo(a[i + 1]) < 0);
         }
      }


      [TestMethod]
      public virtual void testCompareTo()
      {
         JDFDate date1 = new JDFDate();
         JDFDate date2 = new JDFDate();
         Assert.AreEqual(date1.CompareTo(date2), 0);
         date2.addOffset(0, 0, 0, 1); // it is now later
         Assert.IsTrue(date1.CompareTo(date2) < 0);
         Assert.IsTrue(date2.CompareTo(date1) > 0);
         Assert.IsTrue(date2.CompareTo(date2) == 0);
      }


      [TestMethod]
      public virtual void testCompare()
      {
         JDFDate date1 = new JDFDate();
         JDFDate date2 = new JDFDate();
         Assert.AreEqual(0, new JDFDate().Compare(date1, date2));
         date2.addOffset(0, 0, 0, 1); // it is now later
         Assert.IsTrue(new JDFDate().Compare(date1, date2) < 0);
         Assert.IsTrue(new JDFDate().Compare(date2, date1) > 0);
         Assert.IsTrue(new JDFDate().Compare(date2, date2) == 0);
      }


      [TestMethod]
      public virtual void testCompareString()
      {
         JDFDate date1 = new JDFDate();
         JDFDate date2 = new JDFDate();
         Assert.AreEqual(date1.CompareTo(date2), 0);
         date2.addOffset(0, 0, 0, 1); // it is now later
         Assert.IsTrue(date1.CompareTo(date2.DateTimeISO) < 0);
         Assert.IsTrue(date2.CompareTo(date1.DateTimeISO) > 0);
      }


      [TestMethod]
      public virtual void testAddOffset()
      {
         JDFDate date1 = new JDFDate();
         JDFDate date2 = new JDFDate(date1);
         Assert.AreEqual(0, date1.CompareTo(date2));
         date2.addOffset(0, 0, 0, 1); // it is now later
         Assert.AreEqual(-1, date1.ToString().CompareTo(date2.ToString()));
         date1.addOffset(0, 0, 24, 0); // it is now later
         Assert.AreEqual(0, date1.ToString().CompareTo(date2.ToString()));
         Assert.AreEqual(0, date1.CompareTo(date2));
         date2.addOffset(60, 0, 0, 1); // it is now later
         date1.addOffset(0, 1, 24, 0); // it is now later
         Assert.AreEqual(0, date1.CompareTo(date2));
         date2.addOffset(0, 60, 0, 1); // it is now later
         date1.addOffset(0, 0, 25, 0); // it is now later
         Assert.AreEqual(0, date1.CompareTo(date2));

         JDFDate date = new JDFDate("2007-09-26T11:43:10+03:00");
         date.addOffset(0, 0, 0, 1); // it is now later
         Assert.AreEqual("2007-09-27T11:43:10+03:00", date.DateTimeISO);
         date.addOffset(0, 0, 0, 1); // it is now later
         Assert.AreEqual("2007-09-28T11:43:10+03:00", date.DateTimeISO);
         date.addOffset(2, 0, 0, 0); // it is now later
         Assert.AreEqual("2007-09-28T11:43:12+03:00", date.DateTimeISO);
         Assert.AreEqual("2007-09-28", date.DateISO);
         date.addOffset(0, 0, 0, 4); // it is now later
         Assert.AreEqual("2007-10-02", date.DateISO);
      }


      [TestMethod]
      public virtual void testMyDateLong()
      {
         long timeMilli = 1008745211300L; // 2001-12-19T07:00:11+00:00

         JDFDate date = new JDFDate(timeMilli);
         Assert.IsTrue(date.TimeInMillis == timeMilli, "Bug " + date.TimeInMillis + " is not equal to 1008745211000L");

         string strDate = date.DateTimeISO;
         JDFDate date2 = new JDFDate("2001-12-19T07:00:11.300+00:00");

         string strDate2 = date2.DateTimeISO;
         Assert.AreEqual(date, date2, "Bug " + strDate + " is not equal to " + strDate2);

         JDFDate date3 = new JDFDate("2001-12-19T07:00:11.300-00:00");
         string strDate3 = date3.DateTimeISO;
         Assert.AreEqual(date, date3, "Bug " + strDate + " is not equal to " + strDate3);

         JDFDate date4 = new JDFDate("2001-12-19T07:00:11.300Z");
         string strDate4 = date4.DateTimeISO;
         Assert.AreEqual(date, date4, "Bug " + strDate + " is not equal to " + strDate4);
      }


      [TestMethod]
      public virtual void testGetFormattedDateTime()
      {
         const string dateString = "2008-12-19T07:00:11.300+00:00";
         JDFDate date = new JDFDate(dateString);
         //Assert.AreEqual("2008", date.getFormattedDateTime("yyyy"));
         Assert.AreEqual(2008, date.Time.Year);
         //Assert.AreEqual("12", date.getFormattedDateTime("MM"));
         Assert.AreEqual(12, date.Time.Month);
         //Assert.AreEqual("300", date.getFormattedDateTime("SSS")); // test for milliseconds
         Assert.AreEqual(300, date.Time.Millisecond); // test for milliseconds
         //Assert.AreEqual("300", date.getFormattedDateTime("S")); // test for milliseconds
         Assert.AreEqual(dateString, date.Time.ToString("yyyy'-'MM'-'dd'T'HH:mm:ss.SSSZZ"));
         Assert.AreEqual(dateString, date.Time.ToString("yyyy-MM-dd'T'HH:mm:ss.SSSZZ"));
         Assert.AreEqual("12 19-07:00:11", date.Time.ToString("MM dd-HH:mm:ss"));
      }


      [TestMethod]
      public virtual void testGetDateTime()
      {
         JDFDate date = new JDFDate("2008-12-19T07:00:11.300+00:00");
         Assert.AreEqual("20081219070011", date.DateTime);
      }


      [TestMethod]
      public virtual void testMyDateTime()
      {
         JDFDate[] v = new JDFDate[100000];
         JDFDate d = new JDFDate();
         for (int i = 0; i < 100000; i++)
         {
            v[i] = d;
            d.addOffset(0, 0, 1, 0);
            d = new JDFDate(d.DateTimeISO);
            if (i > 0)
               Assert.IsTrue(d.after(v[i - 1]));
         }
      }


      [TestMethod]
      public virtual void testTimeZone()
      {
         TimeZone t = TimeZone.CurrentTimeZone;
         JDFDate d = new JDFDate();
         Assert.AreEqual(t.GetUtcOffset(DateTime.Now), d.getTimeZoneOffsetInMillis());
      }
   }
}
