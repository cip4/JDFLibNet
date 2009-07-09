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



/* ==========================================================================
 * class JDFDate 
 * 
 * JDFDate additionally stores the timezone offset of the original date, 
 * so that after mDate = new JDFDate("1999-09-26T11:43:10+03:00") the following
 * equation holds: mDate.dateTimeISO() == "1999-09-26T11:43:10+03:00"
 * independent of the default timezone
 * ==========================================================================
 * COPYRIGHT Heidelberger Druckmaschinen AG, 1999-2003. ALL RIGHTS RESERVED  
 */

namespace org.cip4.jdflib.util
{
   using System;
   using System.Text;
   using System.Collections;
   using System.Globalization;


   using JDFConstants = org.cip4.jdflib.core.JDFConstants;

   ///
   /// <summary> * @author Rainer Prosi, Heidelberger Druckmaschinen
   /// * </summary>
   /// 
   public class JDFDate : IComparable, ICloneable
   {
      private const long serialVersionUID = 1L;

      //
      //   Java to C# Conversion - 
      // 
      // 1 .NET Tick   = 1 X 10 to the -7 seconds (100 nS)
      // 1 Millisecond = 1 X 10 to the -3 seconds
      // 
      // .NET Time is based on the number of Ticks past 12:00 AM Jan 1, Year 0001
      // Java Time is based on the number of millisecs past 12:00 AM Jan 1, 1970
      // JDFDate date/time data will be stored internally as a .NET DataTime object
      // And Converted to and from Java Millisecs as necessary
      // 

      private static long TICKS_ON_JAN_1_1970 = 621355968000000000L;

      private DateTime m_DateTime;
      private TimeZone m_TimeZone = null;

      public static long ToMillisecs(DateTime dt)
      {
         return (dt.Ticks - TICKS_ON_JAN_1_1970) / 10000;
      }

      public static DateTime FromMillisecs(long millisecs)
      {
         return new DateTime((millisecs * 10000) + TICKS_ON_JAN_1_1970);
      }



      /// <summary>
      /// The basic constructor
      /// </summary>
      /// <param name="dateTime">.NET DateTime object</param>
      public JDFDate(DateTime dateTime)
      {
         m_DateTime = dateTime;
         m_TimeZone = TimeZone.CurrentTimeZone;
      }

      ///   
      ///	 <summary> * Allocates a <code>JDFDate</code> object and initializes it so that it represents the time at which it was
      ///	 * allocated, measured to the nearest millisecond. Also sets the current time zone to the system default time zone </summary>
      ///	 
      public JDFDate()
         : this(System.DateTime.Now)
      {
      }

      ///   
      ///	 <summary> * Allocates a <code>JDFDate</code> object and initializes it so that it represents the time point, expressed in
      ///	 * milliseconds after January 1, 1970, 0:00:00 GMT. Also sets the current time zone to the system default time zone
      ///	 *  </summary>
      ///	 * <param name="iTime"> current time in milliseconds after January 1, 1970, 0:00:00 GMT. Use JDFDuration instead. This class
      ///	 *            will be modified to handle only JDFDate objects </param>
      ///	 
      public JDFDate(long iTime)
         : this()
      {
         m_DateTime = FromMillisecs(iTime);
      }

      ///   
      ///	 * <param name="other"> the  date to clone </param>
      ///	 
      public JDFDate(JDFDate other)
      {
         if (other != null)
         {
            m_DateTime = other.m_DateTime;
            m_TimeZone = other.m_TimeZone;
         }
      }


      // Java to C# Conversion - TODO: String to time conversion needs work, add calendar stuff back in? 
      //                          Still need time zone offset?
      ///   
      ///	 <summary> * Allocates a <code>JDFDate</code> object and initializes it so that the JDFDate represents a date set by
      ///	 * <code>strDateTime</code> Format of <code>strDateTime</code>
      ///	 * <p>
      ///	 * Valid DataTime Strings are:
      ///	 * <li>"yyyy-mm-ddThh:mm:ss.sss+hh:00"</li>
      ///	 * <li>"yyyy-mm-ddThh:mm:ss+hh:00"</li>
      ///	 * <li>"yyyy-mm-ddThh:mm:ss-hh:00"</li>
      ///	 * <li>"yyyy-mm-ddThh:mm:ssZ"</li>
      ///	 * <p>
      ///	 * Attention!<br>
      ///	 * you can enter milliseconds, but <code>getDateTimeISO()</code> still returns the time rounded to full seconds.
      ///	 * Only <code>long getTimeInMillis()</code> returns the exact time
      ///	 *  </summary>
      ///	 * <param name="strDateTime"> formatted date and time </param>
      ///	 * <exception cref="FormatException"> if strDateTime is not a valid DateTime
      ///	 * 
      ///	 *             Attention! you can enter milliseconds, but getDateTimeISO() still returns the time rounded to full
      ///	 *             seconds only long getTimeInMillis() returns the exact time </exception>
      ///	 
      public JDFDate(string strDateTime)
         : this()
      {
         init(strDateTime);
      }

      ///   
      ///	 <summary> * for debug purpose
      ///	 *  </summary>
      ///	 * <returns> Object informations
      ///	 * @Override </returns>
      ///	 
      public override string ToString()
      {
         return "JDFDate[ " + DateTimeISO + " TimeZoneOffsetInMillis=(" + getTimeZoneOffsetInMillis() + ")  --> " + " ]";
      }

      ///   
      ///	 <summary> * init - initializes a JDFDate object with a formatted ISO DateTime value<br>
      ///	 * Method init handles Strings of type: <br>
      ///	 * <li>yyyy-mm-ddThh:mm:ss+hh:00</li> <li>yyyy-mm-ddThh:mm:ss-hh:00</li> <li>
      ///	 * yyyy-mm-ddThh:mm:ssZ</li> <li>yyyy-mm-dd</li>
      ///	 * <p>
      ///	 * The values for month, time etc must be valid time values (e.g. 27 hours or 87 sec are invalid)
      ///	 * <p>
      ///	 * Use JDFDuration instead. This class will be modified to handle only JDFDate objects Deprecated are strings of the
      ///	 * following type (express duration):
      ///	 * <li>"P1Y2M3DT10H30M"</li>
      ///	 * <li>"PM8T12M"</li>
      ///	 * <li>"PT30M"</li>
      ///	 *  </summary>
      ///	 * <param name="strDateTime"> formatted date and time </param>
      ///	 * <exception cref="FormatException"> thrown if the string is not a reasonable iso date or date time </exception>
      ///	 
      private void init(string strDateTime)
      {
         string strDateTimeLocal = strDateTime;

         if (strDateTimeLocal == null || strDateTimeLocal.Equals(JDFConstants.EMPTYSTRING))
         {
            m_DateTime = System.DateTime.Now;
            return;
         }

         try
         {

            if (strDateTimeLocal.IndexOf("T") == -1)
               strDateTimeLocal += "T00:00:00" + TimeZoneISO;

            // check for zulu style time zone
            int length = strDateTimeLocal.Length;
            string lastChar = strDateTimeLocal.Substring(length - 1);


            // not necessarily valid but let's not be too picky
            if ((lastChar.CompareTo("a") >= 0) && (lastChar.CompareTo("z") <= 0))
            {
               lastChar = lastChar.ToUpper();
            }

            int iCmp = lastChar[0].CompareTo('A');
            bool bZulu = (iCmp >= 0) && (iCmp <= 25);
            // The last character is a ZULU style timezone
            if (bZulu)
            {
               string strBuffer = strDateTimeLocal.Substring(0, length - 1);
               string bias = null;
               if (iCmp >= 0 && iCmp <= 8) // A-I
               {
                  bias = "+0" + Convert.ToString(iCmp + 1);
               }
               else if (iCmp == 9) // J
               {
                  throw new FormatException("JDFDate.init: invalid date String " + strDateTimeLocal);
               }
               else if (iCmp >= 10 && iCmp <= 12) // K-M
               {
                  bias = "+" + Convert.ToString(iCmp);
               }
               else if (iCmp >= 13 && iCmp <= 21) // N-V
               {
                  bias = "-0" + Convert.ToString(iCmp - 12);
               }
               else if (iCmp >= 22 && iCmp <= 24) // W-Y
               {
                  bias = "-1" + Convert.ToString(iCmp - 22);
               }
               else if (iCmp == 25) // Z
               {
                  bias = "+00";
               }

               bias += ":00";

               strDateTimeLocal = strBuffer + bias; // add the alphabetical timezone
            }

            int decimalLength = 0;
            int indexOfDecimal = strDateTimeLocal.IndexOf('.');
            if (indexOfDecimal != -1)
            {
               if (indexOfDecimal != 19)
               {
                  // ignore for now
               }
               else
               {
                  decimalLength++;
                  while ("0123456789".IndexOf(strDateTimeLocal[indexOfDecimal + decimalLength]) != -1)
                  {
                     decimalLength++;
                  }
               }
            }

            // if the time looks like 2004-07-14T18:21:47
            // check if there is an +xx:00 or -xx:00 at the end specifying the
            // timezone
            if ((strDateTimeLocal.IndexOf('+', 19) == -1) && (strDateTimeLocal.IndexOf('-', 19) == -1))
            {
               setTimeZoneOffsetInMillis(TimeZone.CurrentTimeZone.GetUtcOffset(m_DateTime).Milliseconds);
            }
            else
            {
               // handle sign explicitly, because "+02" is no valid Integer,
               // while "-02" and "02" are valid Integer
               setTimeZoneOffsetInMillis(3600 * 1000 * Convert.ToInt32(strDateTimeLocal.Substring(20 + decimalLength, 2)));
               if (strDateTimeLocal[19 + decimalLength] == '-')
               {
                  setTimeZoneOffsetInMillis(-getTimeZoneOffsetInMillis());
               }
            }

            // interpret the string - low level enhances performance quite a bit...
            // sbyte[] b = strDateTimeLocal.getBytes();
            Encoding encoding = Encoding.Default;
            sbyte[] b = SupportClass.ToSByteArray(encoding.GetBytes(strDateTimeLocal));
            if (b[4] != '-' || b[7] != '-' || b[10] != 'T' || b[13] != ':' || b[16] != ':' || strDateTimeLocal.Length - decimalLength != 25) // 6 digit tz
            {
               throw new FormatException("JDFDate.init: invalid date String " + strDateTimeLocal);
            }

            int iYear = getIntFromPos(b, 0, 4);
            int iMonth = getIntFromPos(b, 5, 7);
            int iDay = getIntFromPos(b, 8, 10);
            int iHour = getIntFromPos(b, 11, 13);
            int iMinute = getIntFromPos(b, 14, 16);
            int iSecond = getIntFromPos(b, 17, 19);

            // set seconds, minutes, hours, days, years to GregorianCalendar
            //GregorianCalendar gregcal = new GregorianCalendar();

            //gregcal.setTimeZone(new SimpleTimeZone(getTimeZoneOffsetInMillis(), JDFConstants.EMPTYSTRING));
            //SupportClass.CalendarManager.manager.Clear(gregcal); // so milliseconds are set to zero
            //SupportClass.CalendarManager.manager.Set(gregcal, iYear, iMonth, iDay, iHour, iMinute, iSecond);
            //lTimeInMillis = gregcal.getTimeInMillis();

            int iMillisec = 0;
            if (decimalLength > 1)
            { // now handle fractions of seconds
               if (decimalLength == 2)
               {
                  iMillisec += getIntFromPos(b, 20, 21) * 100;
               }
               else if (decimalLength == 3)
               {
                  iMillisec += getIntFromPos(b, 20, 22) * 10;
               }
               else
               {
                  iMillisec += getIntFromPos(b, 20, 23);
               }

            }
            m_DateTime = new DateTime(iYear, iMonth, iDay, iHour, iMinute, iSecond, iMillisec);
         }
         catch (IndexOutOfRangeException)
         {
            // now that we no longer check the string for validation we have no
            // catch this
            throw new FormatException("JDFDate.init: invalid date String " + strDateTimeLocal);
         }
         catch (ArgumentOutOfRangeException)
         {
            throw new FormatException("JDFDate.init: invalid date String " + strDateTimeLocal);
         }
         catch (FormatException)
         {
            throw new FormatException("JDFDate.init: invalid date String " + strDateTimeLocal);
         }
      }

      ///   
      ///	 <summary> * parse a substring for integers - this is a bit faster then the original substring.intvalue... </summary>
      ///	 * <param name="strDateTime"> </param>
      ///	 * <param name="pos1">  </param>
      ///	 * <param name="pos2">  </param>
      ///	 * <returns> the parsed integer value </returns>
      ///	 
      private int getIntFromPos(sbyte[] strDateTime, int pos1, int pos2)
      {
         int ret = 0;
         int f = 1;
         for (int i = pos2 - 1; i >= pos1; i--)
         {
            ret += f * (strDateTime[i] - '0');
            f *= 10;
         }
         return ret;
      }



      ///   
      ///	 <summary> * setOffset: set the offset to this time. Note: The time stored in this is not resetted if you want an offset based
      ///	 * on current time use 'public MyDate(int iOffset)'
      ///	 *  </summary>
      ///	 * <param name="iOffset"> offset time in seconds </param>
      ///	 * @deprecated use addOffset 
      ///	 
      [Obsolete("use addOffset")]
      public virtual void setOffset(int iOffset)
      {
         addOffset(iOffset, 0, 0, 0);
      }

      ///   
      ///	 <summary> * add a given offset to this multiple calls stack
      ///	 *  </summary>
      ///	 * <param name="seconds"> seconds to add to this </param>
      ///	 * <param name="minutes"> minutes to add to this </param>
      ///	 * <param name="hours"> hours to add to this </param>
      ///	 * <param name="days"> days to add to this </param>
      ///	 
      public virtual void addOffset(int seconds, int minutes, int hours, int days)
      {
         long newTime = m_DateTime.Ticks + 10000000 * (seconds + 60 * minutes + 3600 * hours + 3600 * 24 * days);
         m_DateTime = new DateTime(newTime);
      }
      ///   
      ///	 <summary> * returns the date and time of this in non ISO pattern 'yyyyMMddHHmmss'
      ///	 *  </summary>
      ///	 * <returns> String - the date in pattern yyyyMMddHHmmss </returns>
      ///	 
      public virtual string DateTime
      {
         get { return m_DateTime.ToString("yyyyMMddHHmmss"); }
      }

      ///   
      ///	 <summary> * format the date and time as an ISO 8601 conform String
      ///	 *  </summary>
      ///	 * <returns> date and time as String of form yyyy-mm-ddThh:mm:ss+hh:00 </returns>
      ///	 
      public virtual string DateTimeISO
      {
         get { return m_DateTime.ToString("yyyy-MM-ddTHH:mm:sszzz"); }
      }

      ///   
      ///	 <summary> * format the date with no time added </summary>
      ///	 * <returns> date and time as String of form yyyy-mm-dd </returns>
      ///	 
      public virtual string DateTimeISOBD
      {
         get { return m_DateTime.ToString("yyyy-MM-dd"); }
      }

      ///   
      ///	 <summary> * the date formated as defined in ISO 8601
      ///	 *  </summary>
      ///	 * <returns> String: the date of this of form yyyy-mm-dd </returns>
      ///	 
      public virtual string DateISO
      {
         get { return m_DateTime.ToString("yyyy-MM-dd"); }
      }

      ///   
      ///	 <summary> * format the time into a ISO conform String
      ///	 *  </summary>
      ///	 * <returns> String: the time of this ISO 8601 in format hh:mm:ss </returns>
      ///	 
      public virtual string TimeISO
      {
         get { return m_DateTime.ToString("HH:mm:ss"); }
      }

      ///   
      ///	 <summary> * the TimeZone as spezified in ISO 8601 +/-10:00 for example
      ///	 *  </summary>
      ///	 * <returns> String: the timezone </returns>
      ///	 
      public virtual string TimeZoneISO
      {
         get { return m_DateTime.ToString("zzz"); }
      }

      ///   
      ///	 <summary> * Tests if this date is after the specified date.
      ///	 *  </summary>
      ///	 * <param name="x"> the date you wish to know if it is later than this </param>
      ///	 * <returns> true if and only if the instant represented by this Date object is strictly later than the instant
      ///	 *         represented by x; false otherwise. </returns>
      ///	 
      public virtual bool isLater(JDFDate x)
      {
         return this.TimeInMillis > x.TimeInMillis;
      }

      ///   
      ///	 <summary> * Tests if this date is before the specified date.
      ///	 *  </summary>
      ///	 * <param name="x"> the date you wish to know if it is eariler than this </param>
      ///	 * <returns> true if and only if the instant of time represented by this Date object is strictly earlier than the
      ///	 *         instant represented by x; false otherwise. </returns>
      ///	 
      public virtual bool isEarlier(JDFDate x)
      {
         return this.TimeInMillis < x.TimeInMillis;
      }

      ///   
      ///	 <summary> * Get/Set the time in milliseconds
      ///	 *  </summary>
      ///	 * <returns> long - the time in milliseconds </returns>
      ///	 
      public virtual long TimeInMillis
      {
         get { return ToMillisecs(m_DateTime); }
         set { m_DateTime = FromMillisecs(value); }
      }



      ///   
      ///	 * <returns> the GregorianCalendar for this date </returns>
      ///	 
      //public virtual GregorianCalendar getCalendar()
      //{
      //   GregorianCalendar gregorianCalendar = new GregorianCalendar(new SimpleTimeZone(m_TimeZoneOffsetInMillis, JDFConstants.EMPTYSTRING));
      //   gregorianCalendar.setTimeInMillis(getTimeInMillis());
      //   return gregorianCalendar;
      //}

      ///   
      ///	 <summary> * true, if this is before other, also true if other==null
      ///	 *  </summary>
      ///	 * <param name="other"> JDFDate to compare </param>
      ///	 * <returns> true if this is before other </returns>
      ///	 
      public virtual bool before(JDFDate other)
      {
         if (other == null)
            return true;
         return m_DateTime.Ticks < other.m_DateTime.Ticks;
      }

      ///   
      ///	 <summary> * true, if this is after other, also true if other==null
      ///	 *  </summary>
      ///	 * <param name="other">
      ///	 * @return </param>
      ///	 
      public virtual bool after(JDFDate other)
      {
         if (other == null)
            return true;
         return m_DateTime.Ticks > other.m_DateTime.Ticks;
      }


      /// <summary>
      /// Get/Set the Date and Time using .NET DateTime class
      /// </summary>
      public virtual DateTime Time
      {
         get { return m_DateTime; }
         set { m_DateTime = value; }
      }

      ///   
      ///	 <summary> * Compares two JDFDates for equality.<br>
      ///	 * The result is <code>true</code> if and only if the argument is not <code>null</code> and is a
      ///	 * <code>JDFDate</code> object that represents the same point in time, to the millisecond, as this object.
      ///	 * <p>
      ///	 * Thus, two <code>JDFDate</code> objects are equal if and only if the <code>getTimeInMillis</code> method returns
      ///	 * the same <code>long</code> value for both. </summary>
      ///	 
      public override bool Equals(object other)
      {
         if (this == other)
            return true;
         if (other == null)
            return false;
         if (other.GetType() != this.GetType())
            return false;

         return ((this.m_DateTime.Ticks / 10000000) == (((JDFDate)other).m_DateTime.Ticks / 10000000));
      }


      public bool Equals(JDFDate other)
      {
         if (this == other)
            return true;
         if (other == null)
            return false;

         return ((this.m_DateTime.Ticks / 10000000) == (other.m_DateTime.Ticks / 10000000));
      }
      ///   
      ///	 <summary> * hashCode complements equals() to fulfill the equals/hashCode contract </summary>
      ///	 
      public override int GetHashCode()
      {
         return HashUtil.GetHashCode(base.GetHashCode(), getTimeZoneOffsetInMillis());
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see java.lang.Comparable#compareTo(java.lang.Object) the value 0 if the argument is a Date equal to this Date; a
      //	 * value less than 0 if the argument is a Date after this Date; and a value greater than 0 if the argument is a Date
      //	 * before this Date.
      //	 
      public virtual int CompareTo(object arg0)
      {
         if (arg0 is string)
         {
            string s = (string)arg0;
            try
            {
               return CompareTo(new JDFDate(s));
            }
            catch (FormatException)
            {
               return 1;
            }

         }
         if (!(arg0 is JDFDate))
            return 1;
         return (int)(TimeInMillis / 100) - (int)(((JDFDate)arg0).TimeInMillis / 100);
      }

      ///   
      ///	 * <param name="timeZoneOffsetInMillis"> The timeZoneOffsetInMillis to set. </param>
      ///	 
      public virtual void setTimeZoneOffsetInMillis(int timeZoneOffsetInMillis)
      {
         //m_TimeZone.OffsetInMillis = timeZoneOffsetInMillis;
      }

      ///   
      ///	 * <returns> Returns the timeZoneOffsetInMillis. </returns>
      ///	 
      public virtual int getTimeZoneOffsetInMillis()
      {
         return m_TimeZone.GetUtcOffset(m_DateTime).Milliseconds;
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see java.lang.Object#clone()
      //	 
      public object Clone()
      {
         return new JDFDate(this);
      }

      //    (non-Javadoc)
      //	}
      //	 * @see java.util.Comparator#compare(java.lang.Object, java.lang.Object)
      //	 
      public virtual int Compare(JDFDate d0, JDFDate d1)
      {

         return ContainerUtil.compare(d0, d1);
      }



      ///   
      ///	 <summary> * Makes a copy of the<code>JDFDate</code> object
      ///	 *  </summary>
      ///	 * <param name="JDFDate"> d - the date object to make a copy of deprecated - Only usage of JDFDate as a duration object was
      ///	 *            deprecated. Use JDFDuration instead. This class will be modified to handle only JDFDate objects </param>
      ///	 
      // public JDFDate(JDFDate d)
      // {
      // lTimeInMillis = d.getTimeInMillis();
      // }
      ///   
      ///	 * @deprecated Use class JDFDuration instead setDuration sets a duration for this in seconds. This duration is used
      ///	 *             in multiple classes of the jdf. Heating time for example.
      ///	 *  
      ///	 * <param name="i"> the duration in seconds. Values below '0' are set to '0' </param>
      ///	 
      // public void setDuration(int i)
      // {
      // m_lDuration = (i >= 0 ? i : 0);
      // }
      ///   
      ///	 * * @deprecated Use class JDFDuration instead Format and return the duration set by 'setDuration(int i)' or
      ///	 * 'setDurationString(String a_aDuration)' as an ISO conform String. For Exmaple: 'P1Y2M3DT10H30M'
      ///	 *  
      ///	 * <returns> String the duration formated as an ISO 8601 conform String if duration is '0' return value is 'PT00M' </returns>
      ///	 
      // public String getDurationISO()
      // {
      // if (m_lDuration == 0)
      // return "PT00M";
      // int i;
      // int temp = m_lDuration;
      // StringBuffer iso = new StringBuffer(20);
      // iso.append("P"); //P is the indicator that 'iso' is a duration
      // i = m_lDuration/(60*60*24*365);
      // if(i!=0)
      // {
      // iso.append(i).append("Y"); // string with years
      // temp = m_lDuration - (i*60*60*24*365);
      // }
      // i = temp;
      // i = i/(60*60*24*30);
      // if(i!=0)
      // {
      // iso.append(i).append("M"); // string with months
      // temp = temp -(i*60*60*24*30);
      // }
      // i = temp%(60*60*24*30);
      // i = i/(60*60*24);
      // if(i!=0)
      // {
      // iso.append(i).append("D"); // string with days
      // }
      // iso.append("T");
      // i=m_lDuration%(60*60*24);
      // i=i/(60*60);
      // if(i!=0)
      // {
      // iso.append(i).append("H"); // string with hours
      // }
      // i = m_lDuration%(60*60);
      // i = i/(60);
      // if(i!=0)
      // {
      // iso.append(i).append("M"); // string with minutes
      // }
      // i = m_lDuration%(60);
      // if(i!=0)
      // {
      // iso.append(i).append("S"); // string with seconds
      // }
      // int lastIndex=iso.length()-1;
      // if (iso.charAt(lastIndex)=='T')
      // iso.deleteCharAt(lastIndex);
      // return iso.toString();
      // }
      ///   
      ///	 <summary> * deprecated Use class JDFDuration instead </summary>
      ///	 
      // private int m_lDuration = 0; // duration in seconds
      ///   
      ///	 * @deprecated Use class JDFDuration instead Set a duration. Durations are not bound to time or date and can be set
      ///	 *             independently
      ///	 *  
      ///	 * <param name="a_aDuration"> a String of the form 'P1Y2M3DT10H30M' </param>
      ///	 
      // public void setDurationISO(String a_aDuration) throws FormatException
      // {
      // String strPeriod = JDFConstants.EMPTYSTRING;
      // String strDate = JDFConstants.EMPTYSTRING;
      // String strTime = JDFConstants.EMPTYSTRING;
      // int iYears = 0;
      // int iMonths = 0;
      // int iDays = 0;
      // int iHours = 0;
      // int iMinutes = 0;
      // int iSeconds = 0;
      // int iduration = 0;
      // int iTimeLastPos = 0;
      // int iDateLastPos = 0;
      // if (a_aDuration.indexOf(JDFConstants.BLANK)!=-1) {
      // throw new FormatException("JDFDate illegal string: "+ a_aDuration);
      // }
      // int iPPos = a_aDuration.indexOf("P");
      // strPeriod = a_aDuration.substring(++iPPos, a_aDuration.length());
      // // devide periodInstant into date and time part, which are separated by
      // 'T'
      // int iTPos = strPeriod.indexOf("T");
      // if (iTPos >= 0)
      // {
      // if (iTPos == 0)
      // { // e.g. if durationInstant looks like "PT10H30M" - without date part
      // strTime = strPeriod.substring(1, strPeriod.length());
      // }
      // else
      // { // e.g. if durationInstant looks like "P1Y2M3DT10H30M"
      // strDate = strPeriod.substring(0, iTPos);
      // strTime = strPeriod.substring(++iTPos, strPeriod.length());
      // }
      // }
      // else
      // { // e.g. if durationInstant looks like "P1Y2M3D" - without time part
      // strDate = strPeriod;
      // }
      // if (strDate.length() > 0)
      // {
      // int iYPos = strDate.indexOf("Y");
      // if (iYPos > 0)
      // {
      // iYears = Integer.parseInt(strDate.substring (0, iYPos));
      // iduration += iYears * 365*24*60*60;
      // iDateLastPos = ++iYPos;
      // }
      // int iMPos = strDate.indexOf("M");
      // if (iMPos > 0)
      // {
      // iMonths = Integer.parseInt(strDate.substring (iDateLastPos, iMPos));
      // iduration += iMonths * 30*24*60*60;
      // iDateLastPos = ++iMPos;
      // }
      // int iDPos = strDate.indexOf("D");
      // if (iDPos > 0)
      // {
      // iDays = Integer.parseInt(strDate.substring (iDateLastPos, iDPos));
      // iduration += iDays * 24*60*60;
      // }
      // }
      // if (strTime.length() > 0)
      // {
      // int iHPos = strTime.indexOf("H");
      // if (iHPos > 0)
      // {
      // iHours = Integer.parseInt(strTime.substring (0, iHPos));
      // iduration += iHours * 60*60;
      // iTimeLastPos = ++iHPos;
      // }
      // int iMPos = strTime.indexOf("M");
      // if (iMPos > 0)
      // {
      // iMinutes = Integer.parseInt(strTime.substring (iTimeLastPos, iMPos));
      // iduration += iMinutes * 60;
      // iTimeLastPos = ++iMPos;
      // }
      // int iSPos = strTime.indexOf("S");
      // if (iSPos > 0)
      // {
      // iSeconds = Integer.parseInt(strTime.substring (iTimeLastPos, iSPos));
      // iduration += iSeconds;
      // }
      // }
      // m_lDuration = iduration;
      // }
      ///   
      ///	 * @deprecated Use class JDFDuration instead
      ///	 * 
      ///	 *             isLonger - tests if the duration of this JDFDate is longer then the duration of the specified
      ///	 *             JDFDate.
      ///	 *  
      ///	 * <param name="x"> - the JDFDate object that duration you whant to compare with duration of 'this' JDFDate object </param>
      ///	 * <returns> boolean - true if the duration of this JDFDate is longer then the duration of the JDFDate 'x'. </returns>
      ///	 
      // public boolean isLonger(JDFDate x)
      // {
      // return this.m_lDuration > x.m_lDuration;
      // }
      ///   
      ///	 * @deprecated Use class JDFDuration instead
      ///	 * 
      ///	 *             isShorter - tests if the duration of this JDFDate is less then the duration of the specified JDFDate.
      ///	 *  
      ///	 * <param name="x"> - the JDFDate object that duration you whant to compare with duration of 'this' JDFDate object </param>
      ///	 * <returns> boolean - true if the duration of this JDFDate is shorter then the duration of the JDFDate 'x'. </returns>
      ///	 
      // public boolean isShorter(JDFDate x)
      // {
      // return this.m_lDuration < x.m_lDuration;
      // }
      ///   
      ///	 * @deprecated Use class JDFDuration instead the duration in seconds
      ///	 *  
      ///	 * <returns> int the duration in seconds; '0' default </returns>
      ///	 
      // public int getDuration()
      // {
      // return m_lDuration;
      // }
   }
}
