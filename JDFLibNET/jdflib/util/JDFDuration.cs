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
 * class JDFDuration
 * 
 * ==========================================================================
 * COPYRIGHT Heidelberger Druckmaschinen AG, 1999-2003. ALL RIGHTS RESERVED  */

namespace org.cip4.jdflib.util
{
   using System;
   using System.Text;
   using System.Text.RegularExpressions;



   public class JDFDuration : IComparable<JDFDuration>
   {
      private const long serialVersionUID = 1L;

      private double m_lDuration = 0; // in seconds

      // private static final String REGEX_DURATION_RESTRICTED is a
      // RegularExpression
      // for a validation of incoming duration Strings, where is important that
      // values of seconds, minutes do not exceed 59, hours do not exceed 23...
      // It's a restricted form of a REGEX_DURATION
      //
      // Formatted string looks like "PyYmMdDThHmMsS"
      //
      // date Part "yYmMdD"
      // year (0?[0-9]|[1-9][0-9]) -- 0(00) - 99 are valid years
      // month (0?[0-9]|1[01]) -- 0(00) - 11 are valid months
      // day (0?[0-9]|[12][0-9]|3[0]) -- 0(00) - 30 are valid days
      // 
      // time Part "hHmMsS"
      // hour (0?[0-9]|1[0-9]|2[0123]|) -- 0(00) - 23 are valid hours
      // min (0?[0-9]|[1-5][0-9]) -- 0(00) - 59 are valid seconds
      // sec (0?[0-9]|[1-5][0-9]) -- 0(00) - 59 are valid minutes
      // regual expressions to validate incoming duration Strings

      // private static final String REGEX_DURATION_RESTRICTED =
      // "[P]((0?[0-9]|[1-9][0-9])[Y])?((0?[0-9]|1[01])[M])?((0?[0-9]|[12][0-9]|3[0])[D])?"
      // +
      // "([T]((0?[0-9]|1[0-9]|2[0123])[H])?((0?[0-9]|[1-5][0-9])[M])?((0?[0-9]|[1-5][0-9])[S])?)?"
      // ;

      // private static final String REGEX_DURATION is a RegularExpression
      // for a validation of incoming duration Strings
      // Formatted string looks like "PyYmMdDThHmMsS"
      // y,m,d,h,m,s are any int values.
      // E.g. expressions "P60D" that is equal 60 days or "PT68H" that is equal
      // 68hours are allowed

      // .NET add ^ ... $ to force full match in Regex.
      private const string REGEX_DURATION = "^([-])?[P](((\\d)+)[Y])?((\\d)+[M])?((\\d)+[D])?" + "([T]((\\d)+[H])?((\\d)+[M])?((\\d)+([.](\\d)+)?[S])?)?$";

      ///   
      ///	 <summary> * Allocates a <code>JDFDuration</code> object and initializes it with 0 </summary>
      ///	 
      public JDFDuration()
      {
         m_lDuration = 0;
      }

      ///   
      ///	 <summary> * Makes a copy of the<code>JDFDuration</code> object 'd' </summary>
      ///	 
      public JDFDuration(JDFDuration d)
      {
         m_lDuration = d.m_lDuration;
      }

      ///   
      ///	 <summary> * creates a duration from two dates; may be negative if start later end
      ///	 *  </summary>
      ///	 * <param name="start"> the starting point </param>
      ///	 * <param name="end"> the end point
      ///	 *  </param>
      ///	 
      public JDFDuration(JDFDate start, JDFDate end)
      {
         if (start == null || end == null)
            return;
         m_lDuration = (end.TimeInMillis - start.TimeInMillis) / 1000.0;
      }

      ///   
      ///	 <summary> * Allocates a <code>JDFDuration</code> object and initializes it with 's'
      ///	 *  </summary>
      ///	 * <param name="s"> duration in seconds s may be fractional </param>
      ///	 
      public JDFDuration(double s)
      {
         m_lDuration = s;
      }

      ///   
      ///	 <summary> * Allocates a <code>JDFDuration</code> object and initializes it with 's'
      ///	 *  </summary>
      ///	 * <param name="s"> duration in seconds s may be fractional </param>
      ///	 
      public JDFDuration(int s)
      {
         m_lDuration = s;
      }

      ///   
      ///	 <summary> * Allocates a <code>JDFDuration</code> object and initializes it with a value of <code>strDuration</code>,
      ///	 * represented as a formatted duration string. <br>
      ///	 * Duration examples: <li>"P1Y2M3DT10H30M"</li> <li>"P8MT12M"</li> Durations with overflows, e.g. P13M (13 Months)
      ///	 * are also handled and correctly output, in this case P1Y1M
      ///	 *  </summary>
      ///	 * <param name="strDuration"> - formatted duration </param>
      ///	 * <exception cref="FormatException"> if strDuration is not a valid string representation of JDFDuration </exception>
      ///	 
      public JDFDuration(string strDuration)
      {
         init(strDuration);
      }

      ///   
      ///	 <summary> * add seconds to a duration
      ///	 *  </summary>
      ///	 * <param name="seconds"> number of seconds to add </param>
      ///	 
      public virtual double addSeconds(double seconds)
      {
         m_lDuration += seconds;
         return m_lDuration;
      }

      ///   
      ///	 <summary> * for debug purposes
      ///	 *  </summary>
      ///	 * <returns> Object informations </returns>
      ///	 
      public override string ToString()
      {
         return "JDFDuration[ m_lDuration=(" + m_lDuration + ")  --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * Method init handles Strings of type: <br>
      ///	 * <li>"P1Y2M3DT10H30M"</li> <li>"PM8T12M"</li> <li>"PT30M"</li> <li>
      ///	 * "PT30M40S"</li> <li>"PT30M40.3333S"</li>
      ///	 *  </summary>
      ///	 * <param name="strDuration"> </param>
      ///	 * <exception cref="FormatException"> </exception>
      ///	 
      private void init(string strDuration)
      {
         string strDurationLocal = strDuration;

         strDurationLocal = StringUtil.zappTokenWS(strDurationLocal, " ");

         //bool bComplete = strDurationLocal.matches(REGEX_DURATION);
         bool bComplete = Regex.IsMatch(strDurationLocal, REGEX_DURATION);

         m_lDuration = 0;

         if (bComplete)
         {
            bComplete = setDurationISO(strDurationLocal);
         }

         if (!bComplete)
         {
            // its not a DateTime nor a Duration
            throw new FormatException("JDFDuration.init: invalid duration String " + strDurationLocal);
         }
      }

      ///   
      ///	 <summary> * Format and return the duration set by 'setDuration(int i)' or 'setDurationString(String a_aDuration)' as an ISO
      ///	 * conforming String.<br>
      ///	 * For example: 'P1Y2M3DT10H30M'
      ///	 *  </summary>
      ///	 * <returns> String - the duration formatted as an ISO 8601 conforming String if duration is '0' return value is
      ///	 *         'PT00M' </returns>
      ///	 
      public virtual string getDurationISO()
      {
         if (m_lDuration == 0)
            return "PT00M";

         int temp = Math.Abs((int)m_lDuration);
         double abs = Math.Abs(m_lDuration);
         StringBuilder iso = new StringBuilder(32);
         if (m_lDuration < 0)
            iso.Append("-");
         iso.Append("P"); // P is the indicator that 'iso' is a duration

         int i = (int)abs / (60 * 60 * 24 * 365);
         if (i != 0)
         {
            iso.Append(i).Append("Y"); // string with years
            temp = (int)abs - (i * 60 * 60 * 24 * 365);
         }
         i = temp;
         i = i / (60 * 60 * 24 * 30);
         if (i != 0)
         {
            iso.Append(i).Append("M"); // string with months
            temp = temp - (i * 60 * 60 * 24 * 30);
         }
         i = temp % (60 * 60 * 24 * 30);
         i = i / (60 * 60 * 24);
         if (i != 0)
         {
            iso.Append(i).Append("D"); // string with days
         }
         iso.Append("T");

         i = (int)abs % (60 * 60 * 24);
         i = i / (60 * 60);
         if (i != 0)
         {
            iso.Append(i).Append("H"); // string with hours
         }
         i = (int)abs % (60 * 60);
         i = i / (60);
         if (i != 0)
         {
            iso.Append(i).Append("M"); // string with minutes
         }
         i = (int)abs % (60);
         bool bSec = false;
         if (i != 0)
         {
            iso.Append(i); // string with seconds
            bSec = true;
         }
         double deltaS = abs - ((int)(abs));
         if (deltaS > 0)
         {

            string s = StringUtil.formatDouble(deltaS);
            if (!bSec)
               iso.Append("0"); // add missing 0
            iso.Append(s.Substring(1));
            bSec = true;
         }
         if (bSec)
            iso.Append("S");

         int lastIndex = iso.Length - 1;
         if (iso[lastIndex] == 'T')
            iso.Remove(lastIndex, 1);

         return iso.ToString();
      }

      /// <summary>
      /// Get the duration as a string ISO format
      /// </summary>
      public string DurationISO
      {
         get { return getDurationISO(); }
      }

      ///   
      ///	 <summary> * Set a duration. Durations are not bound to time or date and can be set independently
      ///	 *  </summary>
      ///	 * <returns> true - the duration was set<br>
      ///	 *         false - the duration was not set, because a NumberFormatException was thrown (-> parseInt())
      ///	 *  </returns>
      ///	 * <param name="a_aDuration"> formatted duration string 'P1Y2M3DT10H30M' </param>
      ///	 
      public bool setDurationISO(string a_aDuration)
      {
         bool result = true;

         string strDate = null;
         string strTime = null;
         int iYears = 0;
         int iMonths = 0;
         int iDays = 0;
         int iHours = 0;
         int iMinutes = 0;
         int iSeconds = 0;
         int iduration = 0;
         int iTimeLastPos = 0;
         int iDateLastPos = 0;
         int factor = 1; // the factor for negative durations

         int iPPos = a_aDuration.IndexOf("P");
         if (iPPos > 0) // check for negative duration
         {
            char c = a_aDuration[iPPos - 1];
            if (c == '-')
               factor = -1;
         }

         //.Net Substring different than java substring.
         string strPeriod = a_aDuration.Substring(++iPPos);

         // devide periodInstant into date and time part, which are separated by
         // 'T'
         int iTPos = strPeriod.IndexOf("T");

         if (iTPos >= 0)
         {
            if (iTPos == 0)
            { // e.g. if durationInstant looks like "PT10H30M" - without date
               // part
               //.Net Substring different than java substring.
               strTime = strPeriod.Substring(1, (strPeriod.Length - 1));
            }
            else
            { // e.g. if durationInstant looks like "P1Y2M3DT10H30M"
               strDate = strPeriod.Substring(0, iTPos);
               //.Net Substring different than java substring.
               strTime = strPeriod.Substring(++iTPos);
            }
         }
         else
         { // e.g. if durationInstant looks like "P1Y2M3D" - without time part
            strDate = strPeriod;
         }
         double fracSecs = 0;
         try
         {
            if (strDate != null)
            {
               int iYPos = strDate.IndexOf("Y");
               if (iYPos > 0)
               {
                  iYears = Convert.ToInt32(strDate.Substring(0, iYPos));
                  iduration += iYears * 365 * 24 * 60 * 60;
                  iDateLastPos = ++iYPos;
               }

               int iMPos = strDate.IndexOf("M");
               if (iMPos > 0)
               {
                  //.Net Substring different than java substring.
                  iMonths = Convert.ToInt32(strDate.Substring(iDateLastPos, (iMPos - iDateLastPos)));
                  int nYears = iMonths / 12;
                  iduration += (iMonths * 30 + nYears * 5) * 24 * 60 * 60; // add
                  // 5
                  // days
                  // for
                  // each
                  // complete
                  // year
                  // (
                  // 360
                  // --
                  // >
                  // 365
                  // )
                  iDateLastPos = ++iMPos;
               }

               int iDPos = strDate.IndexOf("D");
               if (iDPos > 0)
               {
                  //.Net Substring different than java substring.
                  iDays = Convert.ToInt32(strDate.Substring(iDateLastPos, (iDPos - iDateLastPos)));
                  iduration += iDays * 24 * 60 * 60;
               }
            }

            if (strTime != null)
            {
               int iHPos = strTime.IndexOf("H");
               if (iHPos > 0)
               {
                  iHours = Convert.ToInt32(strTime.Substring(0, iHPos));
                  iduration += iHours * 60 * 60;
                  iTimeLastPos = ++iHPos;
               }
               int iMPos = strTime.IndexOf("M");
               if (iMPos > 0)
               {
                  //.Net Substring different than java substring.
                  iMinutes = Convert.ToInt32(strTime.Substring(iTimeLastPos, (iMPos - iTimeLastPos)));
                  iduration += iMinutes * 60;
                  iTimeLastPos = ++iMPos;
               }

               int iSPos = strTime.IndexOf("S");
               if (iSPos > 0)
               {
                  int iDotPos = strTime.IndexOf(".");
                  if (iDotPos > 0)
                  {
                     //.Net Substring different than java substring.
                     iSeconds = Convert.ToInt32(strTime.Substring(iTimeLastPos, (iDotPos - iTimeLastPos)));
                     iDotPos++;
                     int mLen = iSPos - iDotPos;
                     if (mLen > 0)
                     {
                        //.Net Substring different than java substring.
                        string sMilli = "0." + strTime.Substring(iDotPos, (iSPos - iDotPos));
                        fracSecs = Convert.ToDouble(sMilli);
                     }
                     iduration += iSeconds;

                  }
                  else
                  {
                     //.Net Substring different than java substring.
                     iSeconds = Convert.ToInt32(strTime.Substring(iTimeLastPos, (iSPos - iTimeLastPos)));
                     iduration += iSeconds;
                  }
               }
            }

            m_lDuration = iduration;
            if (fracSecs != 0)
               m_lDuration += fracSecs;
            m_lDuration *= factor;
         }
         catch (FormatException)
         {
            result = false;
         }
         return result;
      }




      ///   
      ///	 <summary> * setDuration: sets a duration for <code>this</code> in seconds, including fractions. This duration is used in
      ///	 * multiple classes of the JDF (e.g. Heating time).
      ///	 *  </summary>
      ///	 * <param name="seconds"> the duration in seconds. </param>
      ///	 
      public virtual void setDuration(double seconds)
      {
         m_lDuration = seconds;
      }

      ///   
      ///	 <summary> * Get/Set the duration in seconds
      ///	 *  </summary>
      ///	 * <returns> int - the duration in seconds; '0' default </returns>
      ///	 
      public virtual int Duration
      {
         get { return (int)m_lDuration; }
         set { m_lDuration = value; }
      }

      ///   
      ///	 <summary> * isLess - tests if the duration of this JDFDuration is longer than the duration of the specified JDFDuration.
      ///	 * Compares the integer durations, thus -PT15S is shorter than -PT5S
      ///	 *  </summary>
      ///	 * <param name="x"> the JDFDuration object to compare to <code>this</code> </param>
      ///	 * <returns> boolean - true if the duration of this JDFDuration is longer than the duration of the JDFDuration 'x'. </returns>
      ///	 
      public virtual bool isLonger(JDFDuration x)
      {
         return this.Duration > x.Duration;
      }

      ///   
      ///	 <summary> * isShorter - tests if the duration of this JDFDuration is less than the duration of the specified JDFDuration.
      ///	 * Compares the integer durations, thus -PT15S is shorter than -PT5S
      ///	 *  </summary>
      ///	 * <param name="x"> the JDFDuration object to compare to <code>this</code> </param>
      ///	 * <returns> boolean - true if the duration of this JDFDuration is shorter than the duration of the JDFDuration 'x'. </returns>
      ///	 
      public virtual bool isShorter(JDFDuration x)
      {
         return this.Duration < x.Duration;
      }

      ///   
      ///	 <summary> * Compares two JDFDuration objects for equality.<br>
      ///	 * The result is <code>true</code> if and only if the argument is not <code>null</code> and is a
      ///	 * <code>JDFDuration</code> object that represents the same duration, as this object.
      ///	 * <p> </summary>
      ///	 
      public override bool Equals(object other)
      {
         if (this == other)
            return true;
         if (other == null)
            return false;
         if (!(other is JDFDuration))
            return false;

         return (this.m_lDuration == ((JDFDuration)other).m_lDuration);
      }

      ///   
      ///	 <summary> * hashCode: complements equals() to fulfill the equals/hashCode contract </summary>
      ///	 
      public override int GetHashCode()
      {
         return HashUtil.GetHashCode(0, m_lDuration);
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see java.lang.Comparable#compareTo(java.lang.Object)
      //	 
      public virtual int CompareTo(JDFDuration arg0)
      {
         double l = (arg0 == null) ? 0 : arg0.m_lDuration;
         l -= m_lDuration;
         return (int)Math.Sign(-l);
      }
   }
}
