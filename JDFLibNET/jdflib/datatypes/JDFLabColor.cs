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
 * JDFLabColor.cs
 * Last changes
 */

namespace org.cip4.jdflib.datatypes
{
   using System;
   using System.Collections;


   ///
   /// <summary> * This class is a representation of a Lab color (JDFLabColor). It is a blank separated list of double values consisting
   /// * of L, a and b value. </summary>
   /// 
   public class JDFLabColor : JDFNumList
   {
      // **************************************** Constructors
      // ****************************************
      ///   
      ///	 <summary> * constructs a Lab color with all values set to 0.0 Double </summary>
      ///	 
      public JDFLabColor()
         : base(JDFBaseDataTypes_Fields.MAX_LAB_COLOR)
      {
      }

      ///   
      ///	 <summary> * constructs a Lab color with all values set via a Vector of Double objects
      ///	 *  </summary>
      ///	 * <param name="v"> the given vector
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the Vector has not a valid format </exception>
      ///	 
      public JDFLabColor(ArrayList v)
         : base(v)
      {
      }

      ///   
      ///	 <summary> * constructs a Lab color with all values set via a String
      ///	 *  </summary>
      ///	 * <param name="s"> the given String
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the String has not a valid format </exception>
      ///	 
      public JDFLabColor(string s)
         : base(s)
      {
      }

      ///   
      ///	 <summary> * constructs a Lab color with all values set via a JDFLabColor
      ///	 *  </summary>
      ///	 * <param name="lab"> the given Lab colors
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the String has not a valid format </exception>
      ///	 
      public JDFLabColor(JDFLabColor lab)
         : this(lab.ToString())
      {
      }

      ///   
      ///	 <summary> * constructs a Lab color with all values set via a JDFNumberList
      ///	 *  </summary>
      ///	 * <param name="nl"> the given number list
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the String does not have a valid format </exception>
      ///	 
      public JDFLabColor(JDFNumberList nl)
         : this(nl.ToString())
      {
      }

      ///   
      ///	 <summary> * constructs a new Lab color with the given double values
      ///	 *  </summary>
      ///	 * <param name="l"> the value L </param>
      ///	 * <param name="a"> the value a </param>
      ///	 * <param name="b"> the value b </param>
      ///	 
      public JDFLabColor(double l, double a, double b)
         : base(JDFBaseDataTypes_Fields.MAX_LAB_COLOR)
      {
         m_numList[0] = l;
         m_numList[1] = a;
         m_numList[2] = b;
      }

      // **************************************** Methods
      // *********************************************
      ///   
      ///	 <summary> * isValid - true if the size of the vector is 3 and all objects are Double types
      ///	 *  </summary>
      ///	 * <exception cref="FormatException"> - if the Vector has not a valid format </exception>
      ///	 
      public override void isValid()
      {
         if (m_numList.Count != JDFBaseDataTypes_Fields.MAX_LAB_COLOR)
         {
            throw new FormatException("Data format exception!");
         }

         for (int i = 0; i < m_numList.Count; i++)
         {
            if (!(m_numList[i] is double))
            {
               throw new FormatException("Data format exception!");
            }
         }
      }

      ///   
      ///	 <summary> * Get/Set the value L of the Lab color
      ///	 *  </summary>
      ///	 * <returns> double - the value L of the Lab color </returns>
      ///	 
      public virtual double L
      {
         get { return ((double)m_numList[0]); }
         set { m_numList[0] = value; }
      }


      ///   
      ///	 <summary> * Get/Set the value a of the Lab color
      ///	 *  </summary>
      ///	 * <returns> double - the value a of the Lab color </returns>
      ///	 
      public virtual double A
      {
         get { return ((double)m_numList[1]); }
         set { m_numList[1] = value; }
      }


      ///   
      ///	 <summary> * Get/Set the value b of the Lab color
      ///	 *  </summary>
      ///	 * <returns> double - the value b of the Lab color </returns>
      ///	 
      public virtual double B
      {
         get { return ((double)m_numList[2]); }
         set { m_numList[2] = value; }
      }
   }
}
