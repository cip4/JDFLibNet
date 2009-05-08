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
 * JDFNumList.cs
 * Last changes
 */

namespace org.cip4.jdflib.datatypes
{
   using System;
   using System.Collections;
   using System.Text;


   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using VString = org.cip4.jdflib.core.VString;
   using HashUtil = org.cip4.jdflib.util.HashUtil;
   using StringUtil = org.cip4.jdflib.util.StringUtil;

   ///
   /// <summary> * This abstract class is the representation of a number list (Integer and Double object). Intern these objects are
   /// * collected in a vector and there are several methods to provide an access to the data. </summary>
   /// 
   public abstract class JDFNumList : JDFBaseDataTypes, ICloneable
   {
      // **************************************** Constructors
      // ****************************************
      protected internal ArrayList m_numList = new ArrayList();

      // **************************************** Constructors
      // ****************************************
      ///   
      ///	 <summary> * constructs an empty number list </summary>
      ///	 
      public JDFNumList()
      {
         // default super constructor
      }

      ///   
      ///	 <summary> * constructor - constructs a number list with the given size and sets all values set to 0.0 Double
      ///	 *  </summary>
      ///	 * <param name="size"> the given size </param>
      ///	 
      public JDFNumList(int size)
      {
         for (int i = 0; i < size; i++)
         {
            m_numList.Add(0.0);
         }
      }

      ///   
      ///	 <summary> * same as Vector.clear()
      ///	 *  </summary>
      ///	 
      public virtual void Clear()
      {
         m_numList.Clear();
      }

      ///   
      ///	 <summary> * constructor - constructs a number list with the given vector
      ///	 *  </summary>
      ///	 * <param name="v"> a vector with number list objects
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the Vector has not a valid format </exception>
      ///	 
      public JDFNumList(ArrayList v)
      {
         this.m_numList = v;
         isValid();
      }

      ///   
      ///	 <summary> * constructor - constructs a number list with the given String; if the sub class is of type JDFIntegerList all
      ///	 * object will be Integer in all other cases the object will be a Double
      ///	 *  </summary>
      ///	 * <param name="sl"> the given String
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the String has not a valid format </exception>
      ///	 
      public JDFNumList(string sl)
      {
         VString v = new VString(StringUtil.tokenize(sl, null, false));
         int size = v.Count;
         for (int i = 0; i < size; i++)
         {
            string s = v.stringAt(i);
            if (!StringUtil.isNumber(s))
               throw new FormatException("JDFNumList: bad numeric value: " + s);
            if (this is JDFIntegerList)
            {
               m_numList.Add(StringUtil.parseInt(s, 0));
            }
            else
            {
               m_numList.Add(StringUtil.parseDouble(s, 0));
            }
         }
         isValid();
      }

      ///   
      ///	 <summary> * constructor - constructs a number list with a given JDFNumList
      ///	 *  </summary>
      ///	 * <param name="nl"> the given number list
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the String has not a valid format </exception>
      ///	 
      public JDFNumList(JDFNumList nl)
         : this(nl.copyNumList())
      {
      }

      // **************************************** Methods
      // *********************************************
      ///   
      ///	 <summary> * getString - returns all values whitespace separated in a String
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 * @deprecated 060418 - use toString 
      ///	 
      [Obsolete("060418 - use toString")]
      public virtual string getString()
      {
         return ToString();
      }

      ///   
      ///	 <summary> * toString - returns the JDFNumList as a String
      ///	 *  </summary>
      ///	 * <returns> String - the JDFNumList as a String </returns>
      ///	 
      public override string ToString()
      {
         StringBuilder sb = new StringBuilder();

         for (int i = 0; i < m_numList.Count; i++)
         {
            if (i > 0)
            {
               sb.Append(JDFConstants.BLANK);
            }

            object o = m_numList[i];
            if (o is double)
            {
               sb.Append(StringUtil.formatDouble((double)o)); //.doubleValue()));
            }
            else if (o is int)
            {
               sb.Append(StringUtil.formatInteger((int)o)); //.intValue()));
            }
            else
            {
               sb.Append(o.ToString());
            }
         }

         return sb.ToString();
      }

      ///   
      ///	 <summary> * getNumberList - returns the object in a JDFNumberList format
      ///	 *  </summary>
      ///	 * <returns> JDFNumberList - the object in JDFNumberList format </returns>
      ///	 
      protected internal virtual JDFNumberList getNumberList()
      {
         JDFNumberList nl = null;

         try
         {
            nl = new JDFNumberList(m_numList);
         }
         catch (Exception e)
         {
            SupportClass.WriteStackTrace(e, Console.Error);
         }

         return nl;
      }

      ///   
      ///	 <summary> * equals - compares two JDFNumList elements
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

         bool retVal = false;

         JDFNumList jdfNumList = (JDFNumList)other;
         int size_ = Count;
         if (size_ == jdfNumList.Count)
         {
            retVal = true;
            for (int i = 0; i < size_ && retVal == true; i++)
            {
               double d1 = doubleAt(i);
               double d2 = jdfNumList.doubleAt(i);
               retVal = StringUtil.isEqual(d1, d2);
            }
         }

         return retVal;
      }

      ///   
      ///	 <summary> * hashCode complements equals() to fulfill the equals/hashCode contract </summary>
      ///	 
      public override int GetHashCode()
      {
         return HashUtil.GetHashCode(0, this.m_numList);
      }

      ///   
      ///	 <summary> * size - returns the size of the list
      ///	 *  </summary>
      ///	 * <returns> int - the size of the list </returns>
      ///	 
      public virtual int Count
      {
         get { return m_numList.Count; }
      }

      ///   
      ///	 <summary> * getElementAt - returns the element at the ith position
      ///	 *  </summary>
      ///	 * <param name="i"> the index </param>
      ///	 * <returns> Object - the range object at the given position, null if i is out of range </returns>
      ///	 
      public virtual object elementAt(int i)
      {
         int iLocal = i;

         ArrayList numList = m_numList;
         if (iLocal < 0)
            iLocal = numList.Count + iLocal;

         if (iLocal < 0 || iLocal >= numList.Count)
            return null;
         return numList[iLocal];
      }

      ///   
      ///	 <summary> * getElementAt - returns the element at the ith position
      ///	 *  </summary>
      ///	 * <param name="i"> the index </param>
      ///	 * <returns> double - the double value given position, 0.0 if out of range </returns>
      ///	 
      public virtual double doubleAt(int i)
      {
         object o = elementAt(i);
         if (o is int)
            return ((double)o);
         if (o is double)
            return ((double)o);
         return 0;
      }

      ///   
      ///	 <summary> * copyNumList - returns a clone of the numList vector
      ///	 *  </summary>
      ///	 * <returns> Vector - the clone of the numList vector </returns>
      ///	 
      public virtual ArrayList copyNumList()
      {
         return (ArrayList)m_numList.Clone();
      }

      ///   
      ///	 <summary> * clone - Returns a clone of this instance
      ///	 *  </summary>
      ///	 * <returns> Object - the clone </returns>
      ///	 * <exception cref="CloneNotSupportedException"> </exception>
      ///	 
      public object Clone()
      {
         JDFNumList num = (JDFNumList)base.MemberwiseClone();
         num.m_numList = ((ArrayList)(m_numList.Clone()));
         return num;
      }

      ///   
      ///	 <summary> * removeElementAt - removes the element at the given position
      ///	 *  </summary>
      ///	 * <param name="i"> the position from where to remove the element
      ///	 *  </param>
      ///	 * <returns> boolean - true if successfull otherwise false </returns>
      ///	 
      public virtual bool RemoveAt(int i)
      {
         int iLocal = i;

         if (iLocal < 0)
            iLocal = iLocal + Count;

         if ((iLocal < Count) && (iLocal >= 0))
         {
            m_numList.RemoveAt(iLocal);

            return true;
         }

         return false;
      }

      ///   
      ///	 <summary> * replaceElementAt - replaces the element at the given position with the given object
      ///	 *  </summary>
      ///	 * <param name="obj"> the object </param>
      ///	 * <param name="i"> the given position </param>
      ///	 * <returns> boolean - true if successfull otherwise false </returns>
      ///	 
      public virtual bool replaceElementAt(object obj, int i)
      {
         int iLocal = i;

         if (iLocal < 0)
            iLocal = iLocal + Count;

         if ((iLocal < m_numList.Count) && (iLocal > -1))
         {
            m_numList.RemoveAt(iLocal);
            m_numList.Insert(iLocal, obj);

            return true;
         }

         return false;
      }

      ///   
      ///	 <summary> * isValid - true if all instances are Double or Integer types
      ///	 *  </summary>
      ///	 * <returns> boolean - true if all instances are Double or Integer types </returns>
      ///	 
      public abstract void isValid();

      ///   
      ///	 <summary> * scale all values of this by factor
      ///	 *  </summary>
      ///	 * <param name="factor"> </param>
      ///	 
      public virtual void scale(double factor)
      {
         for (int i = 0; i < m_numList.Count; i++)
         {
            double number = doubleAt(i) * factor;
            m_numList[i] = number;
         }
      }

      ///   
      ///	 <summary> * return true if this contains the Double or Integer object o
      ///	 *  </summary>
      ///	 * <param name="o">
      ///	 * @return </param>
      ///	 
      public virtual bool Contains(object o)
      {
         return m_numList.Contains(o);
      }

      ///   
      ///	 <summary> * return true if this contains the Double or Integer object o
      ///	 *  </summary>
      ///	 * <param name="o">
      ///	 * @return </param>
      ///	 
      public virtual bool Contains(JDFNumList l)
      {
         if (l == null)
            return false;
         for (int i = 0; i < l.Count; i++)
         {
            if (Contains(l.elementAt(i)))
               return true;
         }
         return false;
      }
   }
}
