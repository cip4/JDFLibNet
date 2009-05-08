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
 * JDFNameRange.cs
 */

namespace org.cip4.jdflib.datatypes
{


   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using VString = org.cip4.jdflib.core.VString;
   using HashUtil = org.cip4.jdflib.util.HashUtil;

   ///
   /// <summary> * This class represents a name range (JDFNameRange). It is a whitespace separated list of 2 names separated by a tilde
   /// * "~", for example "jack ~ john" </summary>
   /// 
   public class JDFNameRange : JDFRange
   {
      // **************************************** Attributes
      // ******************************************

      private string m_left = JDFConstants.EMPTYSTRING; // the left value of the range
      private string m_right = JDFConstants.EMPTYSTRING; // the right value of the range

      // **************************************** Constructors
      // ****************************************
      ///   
      ///	 <summary> * constructor </summary>
      ///	 
      public JDFNameRange()
         : this(JDFConstants.EMPTYSTRING, JDFConstants.EMPTYSTRING)
      {
      }

      ///   
      ///	 <summary> * constructs a JDFNameRange with the given string
      ///	 *  </summary>
      ///	 * <param name="s"> the given string
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the String has not a valid format </exception>
      ///	 
      public JDFNameRange(string s)
      {
         isValid(s);
      }

      ///   
      ///	 <summary> * constructs a JDFNameRange with two given strings the left and the right name
      ///	 *  </summary>
      ///	 * <param name="p_left"> the given left string </param>
      ///	 * <param name="p_right"> the given right string </param>
      ///	 
      public JDFNameRange(string p_left, string p_right)
      {
         Left = p_left;
         Right = p_right;
      }

      ///   
      ///	 <summary> * constructs a JDFNameRange with a give JDFNameRange
      ///	 *  </summary>
      ///	 * <param name="JDFNameRange"> nr </param>
      ///	 
      public JDFNameRange(JDFNameRange nr)
      {
         Left = nr.Left;
         Right = nr.Right;
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
         if (Left.Equals(Right))
         {
            return Right;
         }
         return Left + " ~ " + Right;
      }

      ///   
      ///	 <summary> * inRange - returns true if (left string >= x <= right string), it is a lexicographical compare
      ///	 *  </summary>
      ///	 * <param name="x"> comparison string
      ///	 *  </param>
      ///	 * <returns> boolean - true if x in range otherwise false </returns>
      ///	 
      public virtual bool inRange(string x)
      {
         return ((x.CompareTo(Left) >= 0) && (x.CompareTo(Right) <= 0));
      }

      ///   
      ///	 <summary> * equals - returns true if both JDFNameRange are equal otherwise false
      ///	 *  </summary>
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

         return this.ToString().Equals(((JDFNameRange)other).ToString());
      }

      ///   
      ///	 <summary> * hashCode complements equals() to fulfill the equals/hashCode contract </summary>
      ///	 
      public override int GetHashCode()
      {
         return HashUtil.GetHashCode(0, this.ToString());
      }

      ///   
      ///	 <summary> * getLowerValue - returns the lower value of the range
      ///	 *  </summary>
      ///	 * <returns> String - the lower value of the range </returns>
      ///	 
      public virtual string LowerValue
      {
         get { return (Left.CompareTo(Right) >= 0) ? Left : Right; }
      }

      ///   
      ///	 <summary> * getUpperValue - return the upper value of the range
      ///	 *  </summary>
      ///	 * <returns> String - the upper value of the range </returns>
      ///	 
      public virtual string UpperValue
      {
         get { return (Left.CompareTo(Right) >= 0) ? Right : Left; }
      }

      ///   
      ///	 <summary> * isValid - validates the given String
      ///	 *  </summary>
      ///	 * <param name="s"> the given string
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the String has not a valid format </exception>
      ///	 
      protected internal virtual void isValid(string s)
      {
         VString vs = new VString();
         //StringTokenizer sToken = new StringTokenizer(s, "~");
         SupportClass.Tokenizer sToken = new SupportClass.Tokenizer(s, "~");

         while (sToken.HasMoreTokens())
         {
            string str = sToken.NextToken();
            vs.Add(str.Trim());
         }

         Left = vs[0];

         if (vs.Count == 2)
         {
            Right = vs[1];
         }
         else
         {
            Right = vs[0];
         }
      }

      /// <summary>
      /// Get/Set Left range
      /// </summary>
      public virtual string Left
      {
         get { return m_left; }
         set { m_left = value; }

      }

      /// <summary>
      /// Get/Set Right value
      /// </summary>
      public virtual string Right
      {
         get { return m_right; }
         set { m_right = value; }
      }

      public override bool isPartOfRange(JDFRange ra)
      {
         return this.Equals(ra);
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
         return inRange((string)other);
      }
   }
}
