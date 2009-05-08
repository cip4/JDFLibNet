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
 * Copyright (c) 2001 Heidelberger Druckmaschinen AG, All Rights Reserved.
 * JDFIntegerList.cs
 * Last changes
 */

namespace org.cip4.jdflib.datatypes
{
   using System;
   using System.Collections;

   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using HashUtil = org.cip4.jdflib.util.HashUtil;
   using StringUtil = org.cip4.jdflib.util.StringUtil;

   ///
   /// <summary> * This class is a representation of an integer list (JDFIntegerList). It is a whitespace separated
   /// * list of integer values. </summary>
   /// 
   public class JDFIntegerList : JDFNumList
   {
      ///    
      ///     <summary> * constructs an empty range list </summary>
      ///     
      public JDFIntegerList()
      {
         //default super constructor
      }


      ///    
      ///     <summary> * constructs an integer list with all values set via a String
      ///     * </summary>
      ///     * <param name="s"> the given String
      ///     * </param>
      ///     * <exception cref="FormatException"> - if the String has not a valid format </exception>
      ///     
      public JDFIntegerList(string s)
         : base(s)
      {
      }

      ///    
      ///     <summary> * constructs an integer list with all values set via a Vector of Intger objects
      ///     * </summary>
      ///     * <param name="v"> the given vector
      ///     * </param>
      ///     * <exception cref="FormatException"> - if the Vector has not a valid format </exception>
      ///     
      public JDFIntegerList(ArrayList v)
         : base(v)
      {
      }

      ///    
      ///     <summary> * constructs an integer list with all values set via a JDFIntegerList
      ///     * </summary>
      ///     * <param name="il"> the given integer list
      ///     * </param>
      ///     * <exception cref="FormatException"> - if the JDFIntegerList has not a valid format </exception>
      ///     
      public JDFIntegerList(JDFIntegerList il)
         : this(il.m_numList)
      {
      }

      ///    
      ///     <summary> * constructs an integer list with all values set via an int[]
      ///     * </summary>
      ///     * <param name="iArray"> - the given integer array </param>
      ///     
      public JDFIntegerList(int[] iArray)
         : base()
      {
         setIntArray(iArray);
      }
      ///    
      ///     <summary> * constructs an integer list with all values set via an int
      ///     * </summary>
      ///     * <param name="i"> the given integer  </param>
      ///     
      public JDFIntegerList(int i)
         : base()
      {
         setInt(i);
      }

      //**************************************** Methods *********************************************
      ///    
      ///     <summary> * isValid - true if all instances are Integer types
      ///     * </summary>
      ///     * <exception cref="FormatException"> - if the Vector has not a valid format </exception>
      ///     
      public override void isValid()
      {
         for (int i = 0; i < m_numList.Count; i++)
         {
            if (!(m_numList[i] is int))
            {
               throw new FormatException("Data format exception!");
            }
         }
      }

      ///    
      ///     <summary> * return true if at least one value in the list is d </summary>
      ///     * <param name="d"> the value to search
      ///     * @return </param>
      ///     
      public virtual bool Contains(int d)
      {
         return base.Contains(d);
      }

      ///    
      ///     <summary> * equals - returns true if both JDFIntegerList are equal otherwise false
      ///     * </summary>
      ///     * <returns> boolean - true if equal otherwise false </returns>
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

         return this.ToString().Equals(((JDFIntegerList)other).ToString());
      }

      ///    
      ///     <summary> * hashCode complements equals() to fulfill the equals/hashCode contract </summary>
      ///     
      public override int GetHashCode()
      {
         return HashUtil.GetHashCode(base.GetHashCode(), this.ToString());
      }

      ///    
      ///     <summary> * addIntegerList - adds an integer list to this integer list
      ///     * </summary>
      ///     * <param name="il"> the given integer list </param>
      ///     
      public virtual void addIntegerList(JDFIntegerList il)
      {
         ArrayList getnumList = m_numList;
         int size = il.Count;
         for (int i = 0; i < size; i++)
         {
            getnumList.Add(il.elementAt(i));
         }
      }


      ///    
      ///     <summary> * add - add an Integer object to the vector
      ///     * </summary>
      ///     * <param name="x"> the Integer object </param>
      ///     
      public virtual void Add(int x)
      {
         m_numList.Add(x);
      }

      ///    
      ///     <summary> * add - adds a complete integer list to the vector
      ///     * </summary>
      ///     * <param name="il"> the given integer list </param>
      ///     
      public virtual void Add(JDFIntegerList il)
      {
         m_numList.AddRange(il.copyNumList());
      }

      ///    
      ///     <summary> * add - adds a integer list string to the existing integer list
      ///     * </summary>
      ///     * <param name="s"> the given string
      ///     * </param>
      ///     * <exception cref="FormatException"> - if the String has not a valid format </exception>
      ///     
      public virtual void Add(string s)
      {
         //StringTokenizer sToken = new StringTokenizer(s, JDFConstants.BLANK);
         SupportClass.Tokenizer sToken = new SupportClass.Tokenizer(s, JDFConstants.BLANK);

         ArrayList numList = m_numList;

         while (sToken.HasMoreTokens())
         {
            int i = StringUtil.parseInt(sToken.NextToken(), 0);

            try
            {
               numList.Add(i);
            }
            catch (FormatException)
            {
               throw new FormatException("Data format exception!");
            }
         }
      }

      ///    
      ///     <summary> * getInt - returns the integer at 'pos' from the list.<br>
      ///     * Note: if pos is negative, getInt returns the pos'th integer counting from the end.
      ///     * </summary>
      ///     * <param name="pos"> index of the integer to get
      ///     * </param>
      ///     * <returns> int - the pos'th int </returns>
      ///     
      public virtual int getInt(int pos)
      {
         int posLocal = pos;

         if (posLocal < 0)
            posLocal = posLocal + Count;

         int i = (int)elementAt(posLocal);

         return i;
      }

      //    
      //     * must keep this because otherwise the object vector gets corrupted with Double objects
      //     * (non-Javadoc)
      //     * @see org.cip4.jdflib.datatypes.JDFNumList#scale(double)
      //     
      public override void scale(double factor)
      {
         int[] a = getIntArray();
         for (int i = 0; i < a.Length; i++)
            a[i] *= (int)factor;
         setIntArray(a);
      }
      ///     
      ///     <summary> * getIntArray - returns this integer list as an int array
      ///     * </summary>
      ///     * <returns> int[] - the int array </returns>
      ///     
      public virtual int[] getIntArray()
      {
         ArrayList numList = m_numList;
         int size = numList.Count;
         int[] intArray = new int[size];

         for (int i = 0; i < size; i++)
         {
            intArray[i] = ((int)numList[i]);
         }

         return intArray;
      }

      ///    
      ///     <summary> * setIntArray - sets this integer list to an int array<br>
      ///     * the RangeList is emptied, then the values of iArray are added
      ///     * </summary>
      ///     * <param name="iArray"> the int array </param>
      ///     
      public virtual void setIntArray(int[] iArray)
      {
         ArrayList numList = m_numList;
         numList.Clear();
         for (int i = 0; i < iArray.Length; i++)
            numList.Add(iArray[i]); // (new int(iArray[i]));
      }

      ///    
      ///     <summary> * setIntArray - sets this integer list to an int<br>
      ///     * the RangeList is empied, then the single value i is added 
      ///     * </summary>
      ///     * <param name="i"> the value </param>
      ///     
      public virtual void setInt(int i)
      {
         ArrayList numList = m_numList;
         numList.Clear();
         numList.Add(i);
      }
   }
}
