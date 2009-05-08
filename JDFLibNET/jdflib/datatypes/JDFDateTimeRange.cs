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
 * Copyright (c) 2001 Heidelberger Druckmaschinen AG, All Rights Reserved.
 * 
 * @author Elena Skobchenko
 * JDFDateTimeRange.cs
 */

namespace org.cip4.jdflib.datatypes
{
   using System;

   using HashUtil = org.cip4.jdflib.util.HashUtil;
   using JDFDate = org.cip4.jdflib.util.JDFDate;

   public class JDFDateTimeRange : JDFRange
   {
      // **************************************** Attributes
      // ******************************************
      ///   
      ///	 <summary> * first, left element </summary>
      ///	 
      private JDFDate m_left = null;

      ///   
      ///	 <summary> * second, right element </summary>
      ///	 
      private JDFDate m_right = null;

      // **************************************** Constructors
      // ****************************************
      ///   
      ///	 <summary> * Empty range constructor </summary>
      ///	 
      public JDFDateTimeRange()
      {
         init(null, null);
      }

      ///   
      ///	 <summary> * Constructor - creates a DateTime range defined by x ("from x to x")
      ///	 *  </summary>
      ///	 * <param name="x"> boundary of the date/time range </param>
      ///	 
      public JDFDateTimeRange(JDFDate x)
      {
         init(x, x);
      }

      ///   
      ///	 <summary> * Constructor - creates a DateTime range defined by xmin and xmax
      ///	 *  </summary>
      ///	 * <param name="xmin"> </param>
      ///	 * <param name="xmax"> </param>
      ///	 
      public JDFDateTimeRange(JDFDate xmin, JDFDate xmax)
      {
         init(xmin, xmax);
      }

      ///   
      ///	 <summary> * copy constructor </summary>
      ///	 
      public JDFDateTimeRange(JDFDateTimeRange r)
      {
         init(r.Left, r.Right);
      }

      ///   
      ///	 <summary> * Initialization </summary>
      ///	 
      protected internal virtual void init(JDFDate xmin, JDFDate xmax)
      {
         m_left = xmin;
         m_right = xmax;
      }

      ///   
      ///	 <summary> * Construct a JDFDateTimeRange from a string
      ///	 *  </summary>
      ///	 * <exception cref="FormatException"> - if the String has not a valid format </exception>
      ///	 
      public JDFDateTimeRange(string s)
      {
         string[] strArray = s.Split("~".ToCharArray());
         if (strArray.Length <= 0 || strArray.Length > 2)
         {
            throw new FormatException("JDFDateTimeRange illegal string: " + s);
         }

         try
         {
            // the min and the max values are equal
            if (strArray.Length == 1)
            {
               m_left = new JDFDate(strArray[0].Trim());
               m_right = new JDFDate(strArray[0].Trim());
            }
            // two different values
            else
            {
               m_left = new JDFDate(strArray[0].Trim());
               m_right = new JDFDate(strArray[1].Trim());
            }
         }
         catch (FormatException)
         {
            throw new FormatException("JDFDateTimeRange illegal string: " + s);
         }
      }

      ///   
      ///	 <summary> * toString
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public override string ToString()
      {
         if (m_left.Equals(m_right))
         {
            return m_left.DateTimeISO;
         }
         return m_left.DateTimeISO + (" ~ ") + m_right.DateTimeISO;
      }

      ///   
      ///	 <summary> * isValid - validate the given String
      ///	 *  </summary>
      ///	 * <param name="s"> the given string
      ///	 *  </param>
      ///	 * <returns> boolean - false if the String has not a valid format </returns>
      ///	 
      public virtual bool isValid(string s)
      {
         try
         {
            new JDFDateTimeRange(s);
         }
         catch (FormatException)
         {
            return false;
         }
         return true;
      }

      ///   
      ///	 <summary> * hashCode complements equals() to fulfill the equals/hashCode contract </summary>
      ///	 
      public override int GetHashCode()
      {
         return HashUtil.GetHashCode(0, this.ToString());
      }

      ///   
      ///	 <summary> * inRange - returns true if 'x' is within the range defined by 'this'
      ///	 *  </summary>
      ///	 * <param name="x"> JDFDate that is to be compared with 'this' </param>
      ///	 * <returns> boolean - true if 'x' is within the range defined by 'this' </returns>
      ///	 
      public virtual bool inRange(JDFDate x)
      {
         JDFDate min = this.LowerValue;
         JDFDate max = this.UpperValue;
         return ((x.isLater(min) || x.Equals(min)) && (x.isEarlier(max) || x.Equals(max)));
      }

      ///   
      ///	 <summary> * isPartOfRange - is range 'r' within this range?
      ///	 *  </summary>
      ///	 * <param name="r"> the range to test
      ///	 *  </param>
      ///	 * <returns> boolean - true if range 'r' is within this range, else false </returns>
      ///	 
      public override bool isPartOfRange(JDFRange ra)
      {
         JDFDateTimeRange r = (JDFDateTimeRange)ra;
         JDFDate min = this.LowerValue;
         JDFDate r_min = r.LowerValue;
         JDFDate max = this.UpperValue;
         JDFDate r_max = r.UpperValue;
         return r_min.isLater(min) && r_max.isEarlier(max);
      }

      ///   
      ///	 <summary> * Get/Set the left of the two range deliminators xmin ~ xmax
      ///	 *  </summary>
      ///	 * <returns> JDFDate - the left value </returns>
      ///	 
      public virtual JDFDate Left
      {
         get { return m_left; }
         set { m_left = value; }
      }

      ///   
      ///	 <summary> * Get/Set the right of the two range deliminators xmin ~ xmax
      ///	 *  </summary>
      ///	 * <returns> JDFDate - the right value </returns>
      ///	 
      public virtual JDFDate Right
      {
         get { return m_right; }
         set { m_right = value; }
      }


      ///   
      ///	 <summary> * getUpperValue - returns the upper value of the bounds
      ///	 *  </summary>
      ///	 * <returns> JDFDate - the upper value of the range </returns>
      ///	 
      public virtual JDFDate UpperValue
      {
         get { return (m_left.isEarlier(m_right) || (m_left.Equals(m_right)) ? m_right : m_left); }
      }

      ///   
      ///	 <summary> * getLowerValue - returns the lower value of the bounds
      ///	 *  </summary>
      ///	 * <returns> JDFDate - the lower value of the range </returns>
      ///	 
      public virtual JDFDate LowerValue
      {
         get { return (m_left.isEarlier(m_right) ? m_left : m_right); }
      }

      protected internal override object getRightObject()
      {
         return m_right;
      }

      protected internal override object getLeftObject()
      {
         return m_left;
      }

      protected internal override bool inObjectRange(object other)
      {
         return inRange((JDFDate)other);
      }
   }
}
