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
 * JDFNumberRange.cs
 */

namespace org.cip4.jdflib.datatypes
{
   using System;


   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using HashUtil = org.cip4.jdflib.util.HashUtil;
   using StringUtil = org.cip4.jdflib.util.StringUtil;

   ///
   /// <summary> * This class represents a number range (JDFNumberRange). It is a whitespace separated list of 2 double values separated
   /// * by a tilde "~", for example "1.23 ~ 1.45" </summary>
   /// 
   public class JDFNumberRange : JDFRange
   {
      // **************************************** Attributes
      // ******************************************
      private double m_left = 0; // the left value of the range
      private double m_right = 0; // the right value of the range

      // **************************************** Constructors
      // ****************************************
      ///   
      ///	 <summary> * constructs an empty JDFNumberRange </summary>
      ///	 
      public JDFNumberRange()
      {
         init(0, 0);
      }

      ///   
      ///	 <summary> * constructs a JDFNumberRange, both values are equal ("from x to x")
      ///	 *  </summary>
      ///	 * <param name="x"> the given double </param>
      ///	 
      public JDFNumberRange(double x)
      {
         init(x, x);
      }

      ///   
      ///	 <summary> * constructor, creates a JDFNumberRange bounded by two double values ("from xmin to xmax")
      ///	 *  </summary>
      ///	 * <param name="xmin"> the given min value </param>
      ///	 * <param name="xmax"> the given max value </param>
      ///	 
      public JDFNumberRange(double xmin, double xmax)
      {
         init(xmin, xmax);
      }

      ///   
      ///	 <summary> * copy constructor, creates a JDFNumberRange with the given JDFNumberRange
      ///	 *  </summary>
      ///	 * <param name="nr"> </param>
      ///	 
      public JDFNumberRange(JDFNumberRange nr)
      {
         init(nr.Left, nr.Right);

      }

      ///   
      ///	 <summary> * Initialization
      ///	 *  </summary>
      ///	 * <param name="xmin"> left value </param>
      ///	 * <param name="xmax"> right value </param>
      ///	 
      protected internal virtual void init(double xmin, double xmax)
      {
         m_left = xmin;
         m_right = xmax;
      }

      ///   
      ///	 <summary> * constructs a JDFNumberRange with the values of the given string
      ///	 *  </summary>
      ///	 * <param name="s"> the given string
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the String has not a valid format </exception>
      ///	 
      public JDFNumberRange(string s)
      {
         string[] strArray = s.Split("~".ToCharArray());
         if (strArray.Length <= 0 || strArray.Length > 2)
         {
            throw new FormatException("JDFNumberRange illegal string: " + s);
         }
         try
         {
            // the min and the max values are equal
            if (strArray.Length == 1)
            {
               m_left = StringUtil.parseDouble(strArray[0], 0.0);
               if (m_left == 0.0 && !StringUtil.isNumber(strArray[0]))
                  throw new FormatException("JDFIntegerRange illegal string: " + s);
               m_right = m_left;
            }
            // two different values
            else
            {
               m_left = StringUtil.parseDouble(strArray[0], 0.0);
               if (m_left == 0.0 && !StringUtil.isNumber(strArray[0]))
                  throw new FormatException("JDFIntegerRange illegal string: " + s);
               m_right = StringUtil.parseDouble(strArray[1], 0.0);
               if (m_right == 0.0 && !StringUtil.isNumber(strArray[1]))
                  throw new FormatException("JDFIntegerRange illegal string: " + s);
            }
         }
         catch (FormatException)
         {
            throw new FormatException("JDFNumberRange illegal string: " + s);
         }
      }

      // **************************************** Methods
      // *********************************************
      ///   
      ///	 <summary> * toString
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public override string ToString()
      {
         if (Math.Abs(this.Left - this.Right) < JDFBaseDataTypes_Fields.EPSILON)
         {
            return JDFConstants.EMPTYSTRING + RightString();
         }
         return LeftString() + " ~ " + RightString();
      }

      ///   
      ///	 <summary> * isValid - validate the given String
      ///	 *  </summary>
      ///	 * <param name="s"> the given string to validate
      ///	 *  </param>
      ///	 * <returns> boolean - false if the String has not a valid format </returns>
      ///	 
      public virtual bool isValid(string s)
      {
         try
         {
            new JDFNumberRange(s);
         }
         catch (FormatException)
         {
            return false;
         }
         return true;
      }

      ///   
      ///	 <summary> * equals - returns true if both JDFNumberRange are equal otherwise false, the difference must be smaller than
      ///	 * EPSILON
      ///	 *  </summary>
      ///	 * <param name="other"> the object to compare with <code>this</code> </param>
      ///	 * <returns> boolean - true if equal otherwise false </returns>
      ///	 
      public override bool Equals(object other)
      {
         if (this == other)
         {
            return true;
         }
         if (other == null)
         {
            return false;
         }
         if (!other.GetType().Equals(this.GetType()))
         {
            return false;
         }

         JDFNumberRange jdfNumberRange = (JDFNumberRange)other;

         return (Math.Abs(this.Left - jdfNumberRange.Left) <= JDFBaseDataTypes_Fields.EPSILON) && (Math.Abs(this.Right - jdfNumberRange.Right) <= JDFBaseDataTypes_Fields.EPSILON);
      }

      ///   
      ///	 <summary> * hashCode complements equals() to fulfill the equals/hashCode contract
      ///	 *  </summary>
      ///	 * <returns> int - hash code of <code>this</this> </returns>
      ///	 
      public override int GetHashCode()
      {
         return HashUtil.GetHashCode(0, this.ToString());
      }

      ///   
      ///	 <summary> * returns the string representation of the left value of the range
      ///	 *  </summary>
      ///	 * <returns> the left value of the range </returns>
      ///	 
      public virtual string LeftString()
      {
         return StringUtil.formatDouble(Left);
      }

      ///   
      ///	 <summary> * getLeft - returns the left value of the range
      ///	 *  </summary>
      ///	 * <returns> double - the left value of the range </returns>
      ///	 
      public virtual double Left
      {
         get { return m_left; }
         set { m_left = value; }
      }

      ///   
      ///	 <summary> * returns the string representation of the left value of the range
      ///	 *  </summary>
      ///	 * <returns> the left value of the range </returns>
      ///	 
      public virtual string RightString()
      {
         return StringUtil.formatDouble(Right);
      }

      ///   
      ///	 <summary> * getRight - returns the right value of the range
      ///	 *  </summary>
      ///	 * <returns> double - the right value of the range </returns>
      ///	 
      public virtual double Right
      {
         get { return m_right; }
         set { m_right = value; }
      }


      ///   
      ///	 <summary> * getLowerValue - returns the lower value of the bounds<br> for example 4.5~6.3 returns 4.5, 7.0~5.9 returns 5.9
      ///	 *  </summary>
      ///	 * <returns> double - the lower value of the range </returns>
      ///	 
      public virtual double LowerValue
      {
         get { return (Left < Right) ? Left : Right; }
      }

      ///   
      ///	 <summary> * getUpperValue - return the upper value of the bounds<br> for example 4.5~6.3 returns 6.3, 7.0~5.9 returns 7.0
      ///	 *  </summary>
      ///	 * <returns> double - the upper value of the range </returns>
      ///	 
      public virtual double UpperValue
      {
         get { return (Left < Right) ? Right : Left; }
      }

      ///   
      ///	 <summary> * inRange - returns true if (lower value >= x <= upper value)
      ///	 *  </summary>
      ///	 * <param name="x"> comparison value
      ///	 *  </param>
      ///	 * <returns> boolean - true if x in range </returns>
      ///	 
      public virtual bool inRange(double x)
      {
         return (x >= LowerValue) && (x <= UpperValue);
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
         JDFNumberRange r = (JDFNumberRange)ra;
         return (r.LowerValue >= this.LowerValue) && (r.UpperValue <= this.UpperValue);
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
         return inRange(((double)other));
      }
   }
}
