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
 * JDFIntegerRange.cs
 */

namespace org.cip4.jdflib.datatypes
{
   using System;

   using HashUtil = org.cip4.jdflib.util.HashUtil;
   using StringUtil = org.cip4.jdflib.util.StringUtil;

   ///
   /// <summary> * This class represents an integer range (JDFIntegerRange). It is a pair of 2 integer values separated by a tilde "~",
   /// * for example "123 ~ 145" negative values are treated differently depending on the value of m_defaultXDef @see
   /// * getDefaultDef </summary>
   /// 
   public class JDFIntegerRange : JDFRange
   {
      // **************************************** Attributes
      // ******************************************
      private int m_left = 0; // the left value of the range
      private int m_right = 0; // the right value of the range
      private int m_xDef = m_defaultXDef; // the static default when generating a
      // list
      private static int m_defaultXDef = 0;

      // **************************************** Constructors
      // ****************************************
      ///   
      ///	 <summary> * constructs an empty integer range </summary>
      ///	 
      public JDFIntegerRange()
      {
         init(0, 0, 0);
      }

      ///   
      ///	 <summary> * constructs an integer range with the given int (both values are equal)
      ///	 *  </summary>
      ///	 * <param name="x"> the given min and max value </param>
      ///	 
      public JDFIntegerRange(int x)
      {
         init(x, x, m_defaultXDef);
      }

      ///   
      ///	 <summary> * constructs an integer range with the given int values
      ///	 *  </summary>
      ///	 * <param name="xmin"> the given min value </param>
      ///	 * <param name="xmax"> the given max value </param>
      ///	 
      public JDFIntegerRange(int xmin, int xmax)
      {
         init(xmin, xmax, m_defaultXDef);
      }

      ///   
      ///	 <summary> * constructs an integer range with the given int values
      ///	 *  </summary>
      ///	 * <param name="xmin"> the given min value </param>
      ///	 * <param name="xmax"> the given max value </param>
      ///	 * <param name="xdef"> number of items </param>
      ///	 
      public JDFIntegerRange(int xmin, int xmax, int xdef)
      {
         init(xmin, xmax, xdef);
      }

      ///   
      ///	 <summary> * constructs an integer range with a given JDFIntegerRange
      ///	 *  </summary>
      ///	 * <param name="ir"> the given JDFIntegerRange </param>
      ///	 
      public JDFIntegerRange(JDFIntegerRange ir)
      {
         init(ir.m_left, ir.m_right, ir.m_xDef);
      }

      ///   
      ///	 <summary> * Initialization </summary>
      ///	 
      protected internal virtual void init(int xmin, int xmax, int xdef)
      {
         m_left = xmin;
         m_right = xmax;
         this.setDef(xdef);
      }

      ///   
      ///	 <summary> * constructs an integer range with the given string
      ///	 *  </summary>
      ///	 * <param name="s"> the given string
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the String has not a valid format </exception>
      ///	 
      public JDFIntegerRange(string s)
         : this(s, m_defaultXDef)
      {
      }

      ///   
      ///	 <summary> * constructs an integer range with the given string
      ///	 *  </summary>
      ///	 * <param name="s"> the given string </param>
      ///	 * <param name="xdef"> value which is used for negative numbers the value that -1 will represent in this range
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the String has not a valid format </exception>
      ///	 
      public JDFIntegerRange(string s, int xdef)
      {
         if (s == null)
         {
            throw new FormatException("JDFIntegerRange illegal string: " + s);
         }
         string[] strArray = s.Split("~".ToCharArray());
         if ((strArray.Length <= 0) || (strArray.Length > 2))
         {
            throw new FormatException("JDFIntegerRange illegal string: " + s);
         }
         try
         {
            if (strArray.Length == 1)
            {
               // the min and the max values are equal
               m_left = StringUtil.parseInt(strArray[0], xdef);
               if (m_left == xdef && !StringUtil.isInteger(strArray[0]))
                  throw new FormatException("JDFIntegerRange illegal string: " + s);
               m_right = m_left;
            }
            // two different values
            else
            {
               m_left = StringUtil.parseInt(strArray[0], xdef);
               // the min and the max values are equal
               m_left = StringUtil.parseInt(strArray[0], xdef);
               if (m_left == xdef && !StringUtil.isInteger(strArray[0]))
                  throw new FormatException("JDFIntegerRange illegal string: " + s);
               m_right = StringUtil.parseInt(strArray[1], xdef);
               if (m_right == xdef && !StringUtil.isInteger(strArray[1]))
                  throw new FormatException("JDFIntegerRange illegal string: " + s);
            }
         }
         catch (FormatException)
         {
            throw new FormatException("JDFIntegerRange illegal string: " + s);
         }

         this.setDef(xdef); // set xDef
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
         if (Left == Right)
         {
            return StringUtil.formatInteger(Right);
         }
         return StringUtil.formatInteger(Left) + " ~ " + StringUtil.formatInteger(Right);
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
            new JDFIntegerRange(s);
         }
         catch (FormatException)
         {
            return false;
         }
         return true;
      }

      ///   
      ///	 <summary> * equals - returns true if both JDFIntegerRange are equal otherwise false
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

         return this.ToString().Equals(((JDFIntegerRange)other).ToString());
      }

      ///   
      ///	 <summary> * hashCode complements equals() to fulfill the equals/hashCode contract </summary>
      ///	 
      public override int GetHashCode()
      {
         return HashUtil.GetHashCode(0, this.ToString());
      }

      ///   
      ///	 <summary> * getLeft - returns the left int object
      ///	 *  </summary>
      ///	 * <returns> int - the left int object </returns>
      ///	 
      public virtual int Left
      {
         get { return (m_left < 0 && m_xDef > 0) ? m_xDef + m_left : m_left; }
         set { m_left = value; }
      }


      ///   
      ///	 <summary> * getRight - returns the right int object
      ///	 *  </summary>
      ///	 * <returns> int - the right int </returns>
      ///	 
      public virtual int Right
      {
         get { return (m_right < 0 && m_xDef > 0) ? m_xDef + m_right : m_right; }
         set { m_right = value; }
      }


      ///   
      ///	 <summary> * getLowerValue - returns the lower value of the bounds for example 4~6 return 4, 7~5 return 5
      ///	 *  </summary>
      ///	 * <returns> int - the lower value of the range </returns>
      ///	 
      public virtual int LowerValue
      {
         get
         {
            int left = this.Left;
            int right = this.Right;
            return (left < right) ? left : right;
         }
         set
         {
            int left = this.Left;
            int right = this.Right;
            if (left == right)
            {
               this.Left = value;
               this.Right = value;
            }
            else if (left < right)
            {
               this.Left = value;
            }
            else
            {
               this.Right = value;
            }
         }
      }


      ///   
      ///	 <summary> * getUpperValue - returns the upper value of the bounds for example 4~6 return 6, 7~5 return 7
      ///	 *  </summary>
      ///	 * <returns> int the upper value of the range </returns>
      ///	 
      public virtual int UpperValue
      {
         get
         {
            int left = this.Left;
            int right = this.Right;
            return (left < right) ? right : left;
         }
         set
         {
            int left = this.Left;
            int right = this.Right;
            if (left == right)
            {
               this.Left = value;
               this.Right = value;
            }
            else if (left > right)
            {
               this.Left = value;
            }
            else
            {
               this.Right = value;
            }
         }
      }


      ///   
      ///	 <summary> * inRange - returns true if (lower value >= x <= upper value)
      ///	 *  </summary>
      ///	 * <param name="x"> comparison value
      ///	 *  </param>
      ///	 * <returns> boolean - true if x in range </returns>
      ///	 
      public virtual bool inRange(int x)
      {
         return (x >= this.LowerValue) && (x <= this.UpperValue);
      }

      ///   
      ///	 <summary> * isPartOfRange - is range 'ir' within this range?
      ///	 *  </summary>
      ///	 * <param name="ir"> the range to test
      ///	 *  </param>
      ///	 * <returns> boolean - true if range 'ir' is within this range, else false </returns>
      ///	 
      public override bool isPartOfRange(JDFRange r)
      {
         JDFIntegerRange ir = (JDFIntegerRange)r;
         return (ir.LowerValue >= this.LowerValue) && (ir.UpperValue <= this.UpperValue);
      }

      ///   
      ///	 <summary> * getElementCount - returns the number of elements in this range, on the C++ side of the JDF library this method is
      ///	 * called NElements if any if any range cannot be resolved due to an unknown negative value without a known default,
      ///	 * -1 is returned
      ///	 *  </summary>
      ///	 * <returns> int - the number of elements in this range, -1 if any range cannot be resolved </returns>
      ///	 
      public virtual int getElementCount()
      {
         if (m_defaultXDef == 0 && (Right < 0 || Left < 0))
            return -1;
         return 1 + Math.Abs(this.Left - this.Right);
      }

      ///   
      ///	 <summary> * append - appends a value to this range, returns true if possible returns false if the element is not the next
      ///	 * element in the list, it only appends on the right side of the range. For example:
      ///	 * 
      ///	 * <pre>
      ///	 * &quot;3&tilde;5&quot;        append(6)   -&gt; &quot;3&tilde;6&quot;
      ///	 * &quot;5&quot;          append(6)   -&gt; &quot;5&tilde;6&quot;
      ///	 * &quot;5&quot;          append(7)   -&gt; &quot;5 7&quot;
      ///	 * &quot;5&tilde;9&quot;        append(6)   -&gt; &quot;5&tilde;9 6&quot;
      ///	 * &quot;7&tilde;5&quot;        append(4)   -&gt; &quot;7&tilde;4&quot;
      ///	 * </pre>
      ///	 *  </summary>
      ///	 * <param name="x"> the new value
      ///	 *  </param>
      ///	 * <returns> boolean - true if successful </returns>
      ///	 
      public virtual bool Append(int x)
      {
         int right = this.Right;
         int left = this.Left;
         if (right > left)
         {
            if ((right + 1) == x)
            {
               m_right = x;
               return true;
            }
         }
         else if (right < left)
         {
            if ((right - 1) == x)
            {
               m_right = x;
               return true;
            }
         }
         else
         {
            if ((right + 1) == x)
            {
               m_right = x;
               return true;
            }
            else if ((right - 1) == x)
            {
               m_right = x;
               return true;
            }
         }

         return false;
      }

      ///   
      ///	 <summary> * Element - value of the ith element in the range.<br>
      ///	 * If the index is negativ the position is counted from the end of the range. For example the range is 3~7, the 2nd
      ///	 * element is 5 and the -2nd element is 6. On the C++ side of the JDF library this method is called Element.
      ///	 *  </summary>
      ///	 * <param name="i"> the position, if it is a negativ value start counting from the right side +1
      ///	 *  </param>
      ///	 * <returns> int the value at the ith position
      ///	 *  </returns>
      ///	 * <exception cref="NoSuchElementException"> - if the index is out of range </exception>
      ///	 
      public virtual int getElement(int i)
      {
         int n = this.getElementCount();

         if ((i >= n) || (i < -n))
         {
            throw new ArgumentOutOfRangeException("JDFIntegerRange::Element out of range error!");
         }

         // element(-2) is the second to last element
         if (i < 0)
         {
            return this.getElement(n + i);
         }

         // ascending range
         int left = this.Left;
         int right = this.Right;
         if (right >= left)
         {
            return left + i;
         }

         // decending range
         return left - i;
      }

      ///   
      ///	 <summary> * setDef - sets xDef, the default value which is used for negative numbers<br>
      ///	 * the value represents the index that is one past the end of the list<br>
      ///	 * if xdef==0 (the default), the neg numbers themselves are used
      ///	 *  </summary>
      ///	 * <param name="xdef"> the value that will represent negative values in this range </param>
      ///	 
      public virtual void setDef(int xdef)
      {
         m_xDef = xdef;
      }

      ///   
      ///	 <summary> * setDefaultDef - sets the preset for xDef, which will be used when constructing an IntegerRange<br>
      ///	 * the value represents the index that is one past the end of the list<br>
      ///	 * if xdef==0 (the default), the neg numbers themselves are used
      ///	 *  </summary>
      ///	 * <param name="xdef"> - (int)1 above the value that -1 will represent in this range i.e. the value that -0, were it
      ///	 *            possible to specify, would represent </param>
      ///	 
      public static void setDefaultDef(int xdef)
      {
         m_defaultXDef = xdef;
      }

      ///   
      ///	 <summary> * getDefaultDef - gets the preset for xDef, which will be used when constructing an IntegerRange<br>
      ///	 * the value represents the index that is one past the end of the list<br>
      ///	 * if xdef==0 (the default), the neg numbers themselves are used
      ///	 *  </summary>
      ///	 * <returns> int - (int)1 above the value that -1 will represent in this range i.e. the value that -0, were it
      ///	 *         possible to specify, would represent </returns>
      ///	 
      public static int getDefaultDef()
      {
         return m_defaultXDef;
      }

      ///   
      ///	 <summary> * getDef - gets xDef, the default value which is used for negative numbers
      ///	 *  </summary>
      ///	 * <returns> int - one above the value that -1 will represent in this range i.e. the value that -0, were it possible
      ///	 *         to specify, would represent </returns>
      ///	 
      public virtual int getDef()
      {
         return m_xDef;
      }

      ///   
      ///	 <summary> * getIntegerList - returns the integer range as an integer list<br>
      ///	 * for example an integer range of "5~9" will be returned as "5 6 7 8 9"
      ///	 *  </summary>
      ///	 * <returns> JDFIntegerList - the integer list </returns>
      ///	 
      public virtual JDFIntegerList getIntegerList()
      {

         JDFIntegerList irl = new JDFIntegerList();
         int elementCount = this.getElementCount();
         for (int i = 0; i < elementCount; i++)
         {
            irl.Add(this.getElement(i));
         }
         return irl;

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
         return inRange((int)other);
      }
   }
}
