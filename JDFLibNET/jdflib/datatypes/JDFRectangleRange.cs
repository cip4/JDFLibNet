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



/* Copyright (c) 2001 Heidelberger Druckmaschinen AG, All Rights Reserved.
 * 
 * @author Elena Skobchenko
 * JDFRectangleRange.cs
 */


namespace org.cip4.jdflib.datatypes
{
   using System;

   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using HashUtil = org.cip4.jdflib.util.HashUtil;

   public class JDFRectangleRange : JDFRange
   {
      // **************************************** Attributes
      // ******************************************

      private JDFRectangle m_left = null;
      private JDFRectangle m_right = null;

      // **************************************** Constructors
      // ****************************************
      ///   
      ///	 <summary> * constructs a xy pair range with all values set to 0.0 Double </summary>
      ///	 
      public JDFRectangleRange()
      {
         init(null, null);
      }

      ///   
      ///	 <summary> * constructs a JDFRectangleRange, both values are equal ("from x to x")
      ///	 *  </summary>
      ///	 * <param name="x"> - the given JDFRectangle </param>
      ///	 
      public JDFRectangleRange(JDFRectangle x)
      {
         init(x, x);
      }

      ///   
      ///	 <summary> * constructor a JDFRectangleRange with two JDFRectangle values/bounds ("from xmin to xmax")
      ///	 *  </summary>
      ///	 * <param name="xmin"> the given min value </param>
      ///	 * <param name="xmax"> the given max value </param>
      ///	 
      public JDFRectangleRange(JDFRectangle xmin, JDFRectangle xmax)
      {
         init(xmin, xmax);
      }

      ///   
      ///	 <summary> * copy constructor - constructs a JDFRectangleRange with the given JDFRectangleRange
      ///	 *  </summary>
      ///	 * <param name="r"> the JDFRectangleRange to copy </param>
      ///	 
      public JDFRectangleRange(JDFRectangleRange r)
      {
         init(r.Left, r.Right);
      }

      ///   
      ///	 <summary> * Initialization
      ///	 *  </summary>
      ///	 * <param name="x"> left value </param>
      ///	 * <param name="y"> right value </param>
      ///	 
      protected internal virtual void init(JDFRectangle x, JDFRectangle y)
      {
         m_left = x;
         m_right = y;
      }

      ///   
      ///	 <summary> * Constructs a JDFRectangleRange with the values of the given string
      ///	 *  </summary>
      ///	 * <param name="s"> the given string representation of the range
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the String has not a valid format </exception>
      ///	 
      public JDFRectangleRange(string s)
      {
         string[] strArray = s.Split("~".ToCharArray());
         if ((strArray.Length <= 0) || (strArray.Length > 2))
         {
            throw new FormatException("JDFRectangleRange illegal string: " + s);
         }
         try
         {
            // the min and the max values are equal
            if (strArray.Length == 1)
            {
               m_left = new JDFRectangle(strArray[0].Trim());
               m_right = new JDFRectangle(strArray[0].Trim());
            }
            // two different values
            else
            {
               m_left = new JDFRectangle(strArray[0].Trim());
               m_right = new JDFRectangle(strArray[1].Trim());
            }
         }
         catch (FormatException)
         {
            throw new FormatException("JDFRectangleRange illegal string: " + s);
         }
      }

      // **************************************** Methods
      // *********************************************

      ///   
      ///	 <summary> * getString - returns the range as a String
      ///	 *  </summary>
      ///	 * <returns> String - the range as a String </returns>
      ///	 
      public override string ToString()
      {
         if (m_left.Equals(m_right))
         {
            return JDFConstants.EMPTYSTRING + Left;
         }
         return Left + " ~ " + Right;
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
            new JDFRectangleRange(s);
         }
         catch (FormatException)
         {
            return false;
         }
         return true;
      }

      ///   
      ///	 <summary> * equals - returns true if both JDFRectangleRanges are equal otherwise false
      ///	 *  </summary>
      ///	 *<param name="other"> the JDFRectangleRange to compare </param>
      ///	 * <returns> boolean - true if equal, otherwise false </returns>
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

         JDFRectangleRange range = (JDFRectangleRange)other;

         return this.Left.Equals(range.Left) && this.Right.Equals(range.Right);
      }

      ///   
      ///	 <summary> * hashCode complements equals() to fulfill the equals/hashCode contract
      ///	 *  </summary>
      ///	 * <returns> int </returns>
      ///	 
      public override int GetHashCode()
      {
         return HashUtil.GetHashCode(0, this.ToString());
      }

      ///   
      ///	 <summary> * inRange - tests if the given x inside of this range
      ///	 *  </summary>
      ///	 * <param name="x"> comparison value
      ///	 *  </param>
      ///	 * <returns> boolean - true if x in range </returns>
      ///	 
      public virtual bool inRange(JDFRectangle x)
      {
         JDFRectangle min = this.LowerValue;
         JDFRectangle max = this.UpperValue;
         return x.isGreaterOrEqual(min) && x.isLessOrEqual(max);
      }

      ///   
      ///	 <summary> * isPartOfRange - is range 'r' within this range?
      ///	 *  </summary>
      ///	 * <param name="ra"> the range to test
      ///	 *  </param>
      ///	 * <returns> boolean - true if range 'r' is within this range, else false </returns>
      ///	 
      public override bool isPartOfRange(JDFRange ra)
      {
         JDFRectangleRange r = (JDFRectangleRange)ra;
         JDFRectangle min = this.LowerValue;
         JDFRectangle r_min = r.LowerValue;
         JDFRectangle max = this.UpperValue;
         JDFRectangle r_max = r.UpperValue;
         return r_min.isGreaterOrEqual(min) && r_max.isLessOrEqual(max);
      }

      ///   
      ///	 <summary> * Get/Set the left JDFRectangle object of the range
      ///	 *  </summary>
      ///	 * <returns> JDFRectangle - the left JDFRectangle object of the range </returns>
      ///	 
      public virtual JDFRectangle Left
      {
         get { return m_left; }
         set { m_left = value; }
      }

      ///   
      ///	 <summary> * Get/Set the right JDFRectangle object of the range
      ///	 *  </summary>
      ///	 * <returns> JDFRectangle - the right JDFRectangle object of the range </returns>
      ///	 
      public virtual JDFRectangle Right
      {
         get { return m_right; }
         set { m_right = value; }
      }



      ///   
      ///	 <summary> * getUpperValue - returns the upper value of the bounds
      ///	 *  </summary>
      ///	 * <returns> JDFRectangle - the upper value of the range </returns>
      ///	 
      public virtual JDFRectangle UpperValue
      {
         get { return (m_left.isLessOrEqual(m_right) ? m_right : m_left); }
      }

      ///   
      ///	 <summary> * getLowerValue - returns the lower value of the bounds
      ///	 *  </summary>
      ///	 * <returns> JDFRectangle - the lower value of the range </returns>
      ///	 
      public virtual JDFRectangle LowerValue
      {
         get { return (m_left.isLess(m_right) ? m_left : m_right); }
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
         return inRange((JDFRectangle)other);
      }
   }
}
