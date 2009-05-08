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
 * JDFXYPairRange.cs
 */


namespace org.cip4.jdflib.datatypes
{
   using System;

   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using HashUtil = org.cip4.jdflib.util.HashUtil;

   ///
   /// <summary> * This class represents a x y pair range (JDFXYPairRange). It is a whitespace separated list of 2 xy pairs separated by
   /// * a tilde "~", for example "1.23 3.24 ~ 2.34 7.12" </summary>
   /// 
   public class JDFXYPairRange : JDFRange
   {
      // **************************************** Attributes
      // ******************************************
      private JDFXYPair m_left = null; // the left value of the range
      private JDFXYPair m_right = null; // the right value of the range

      // **************************************** Constructors
      // ****************************************
      ///   
      ///	 <summary> * constructs a xy pair range with all values set to 0.0 Double </summary>
      ///	 
      public JDFXYPairRange()
         : this(null, null)
      {
      }

      ///   
      ///	 <summary> * constructs a xy pair range with both values equal ("from x to x")
      ///	 *  </summary>
      ///	 * <param name="x"> left/right pair </param>
      ///	 
      public JDFXYPairRange(JDFXYPair x)
         : this(x, x)
      {
      }

      ///   
      ///	 <summary> * constructs a xy pair range with the given left and right xy pair
      ///	 *  </summary>
      ///	 * <param name="min"> the given left xy pair </param>
      ///	 * <param name="max"> the given right xy pair </param>
      ///	 
      public JDFXYPairRange(JDFXYPair min, JDFXYPair max)
      {
         init(min, max);
      }

      ///   
      ///	 <summary> * constructs a xy pair range with the given xy pair range
      ///	 *  </summary>
      ///	 * <param name="JDFXYPairRange"> r - the given xy pair range </param>
      ///	 
      public JDFXYPairRange(JDFXYPairRange r)
      {
         init(r.Left, r.Right);
      }

      ///   
      ///	 <summary> * Initialization
      ///	 *  </summary>
      ///	 * <param name="min"> </param>
      ///	 * <param name="max"> </param>
      ///	 
      protected internal virtual void init(JDFXYPair min, JDFXYPair max)
      {
         m_left = min;
         m_right = max;
      }

      ///   
      ///	 <summary> * constructs a xy pair range with all values set via a string
      ///	 *  </summary>
      ///	 * <param name="s"> the given string
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the String has not a valid format </exception>
      ///	 
      public JDFXYPairRange(string s)
      {
         string[] strArray = s.Split("~".ToCharArray());
         if (strArray.Length > 2)
         {
            throw new FormatException("JDFXYPairRange illegal string: " + s);
         }
         try
         {
            // the min and the max values are equal
            if (strArray.Length == 1)
            {
               m_left = new JDFXYPair(strArray[0].Trim());
               m_right = new JDFXYPair(strArray[0].Trim());
            }
            // two different values
            else if (strArray.Length == 2)
            {
               m_left = new JDFXYPair(strArray[0].Trim());
               m_right = new JDFXYPair(strArray[1].Trim());
            }
         }
         catch (FormatException)
         {
            throw new FormatException("JDFXYPairRange illegal string: " + s);
         }
      }

      // **************************************** Methods
      // *********************************************

      ///   
      ///	 <summary> * toString - returns the range as a String
      ///	 *  </summary>
      ///	 * <returns> String - the range as a String </returns>
      ///	 
      public override string ToString()
      {
         if (m_left.Equals(m_right))
         {
            return JDFConstants.EMPTYSTRING + Left;
         }
         return Left.ToString() + " ~ " + Right.ToString();
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
            new JDFXYPairRange(s);
         }
         catch (FormatException)
         {
            return false;
         }
         return true;
      }

      ///   
      ///	 <summary> * equals - returns true if both JDFXYPaiRanges are equal otherwise false
      ///	 *  </summary>
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

         JDFXYPairRange range = (JDFXYPairRange)other;

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
      ///	 <summary> * getLeft - returns the left JDFXYPair object
      ///	 *  </summary>
      ///	 * <returns> JDFXYPair - the left JDFXYPair object </returns>
      ///	 
      public virtual JDFXYPair Left
      {
         get { return m_left; }
         set { m_left = value; }

      }

      ///   
      ///	 <summary> * getRight - returns the right JDFXYPair object
      ///	 *  </summary>
      ///	 * <returns> JDFXYPair - the right JDFXYPair object </returns>
      ///	 
      public virtual JDFXYPair Right
      {
         get { return m_right; }
         set { m_right = value; }
      }

      ///   
      ///	 <summary> * getLowerXValue - returns the lower x value of the bounds for example 2.9 4.5~6.3 7.9 return 2.9
      ///	 *  </summary>
      ///	 * <returns> double - the lower x value of the range </returns>
      ///	 
      public virtual double LowerXValue
      {
         get { return (Left.X < Right.X) ? Left.X : Right.X; }
      }

      ///   
      ///	 <summary> * getUpperXValue - return the upper x value of the bounds for example 2.9 4.5~6.3 7.9 return 6.3
      ///	 *  </summary>
      ///	 * <returns> double - the upper x value of the range </returns>
      ///	 
      public virtual double UpperXValue
      {
         get { return (Left.X < Right.X) ? Right.X : Left.X; }
      }

      ///   
      ///	 <summary> * getLowerYValue - returns the lower y value of the bounds for example 2.9 4.5~6.3 7.9 return 4.5
      ///	 *  </summary>
      ///	 * <returns> double - the lower y value of the range </returns>
      ///	 
      public virtual double LowerYValue
      {
         get { return (Left.Y < Right.Y) ? Left.Y : Right.Y; }
      }

      ///   
      ///	 <summary> * getUpperYValue - return the upper y value of the bounds for example 2.9 4.5~6.3 7.9 return 7.9
      ///	 *  </summary>
      ///	 * <returns> double - the upper y value of the range </returns>
      ///	 
      public virtual double UpperYValue
      {
         get { return (Left.Y < Right.Y) ? Right.Y : Left.Y; }
      }

      ///   
      ///	 <summary> * getUpperValue - returns the upper value of the bounds
      ///	 *  </summary>
      ///	 * <returns> JDFXYPair - the upper value of the range </returns>
      ///	 
      public virtual JDFXYPair UpperValue
      {
         get { return (m_left.isLessOrEqual(m_right) ? m_right : m_left); }
      }

      ///   
      ///	 <summary> * getLowerValue - returns the lower value of the bounds
      ///	 *  </summary>
      ///	 * <returns> JDFXYPair - the lower value of the range </returns>
      ///	 
      public virtual JDFXYPair LowerValue
      {
         get { return (m_left.isLess(m_right) ? m_left : m_right); }
      }


      ///   
      ///	 <summary> * isEqual - boolean equivalence
      ///	 *  </summary>
      ///	 * <returns> boolean - true if the ranges are equivalent </returns>
      ///	 
      public virtual bool isEqual(JDFXYPairRange g)
      {
         return (m_left.Equals(g.m_left)) && (m_right.Equals(g.m_right));
      }

      ///   
      ///	 <summary> * inRange - returns true if <code>this</code> contains <code>xypair</code>
      ///	 *  </summary>
      ///	 * <param name="xypair"> comparison pair
      ///	 *  </param>
      ///	 * <returns> boolean - true if xy in range </returns>
      ///	 
      public virtual bool inRange(JDFXYPair xypair)
      {
         JDFXYPair min = this.LowerValue;
         JDFXYPair max = this.UpperValue;
         return xypair.isGreaterOrEqual(min) && xypair.isLessOrEqual(max);
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
         JDFXYPairRange r = (JDFXYPairRange)ra;

         JDFXYPair min = this.LowerValue;
         JDFXYPair r_min = r.LowerValue;
         JDFXYPair max = this.UpperValue;
         JDFXYPair r_max = r.UpperValue;
         return r_min.isGreaterOrEqual(min) && r_max.isLessOrEqual(max);
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
         return inRange((JDFXYPair)other);
      }
   }
}
