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
 * JDFNumberList.cs
 * Last changes
 */

namespace org.cip4.jdflib.datatypes
{
   using System;
   using System.Collections;


   using JDFConstants = org.cip4.jdflib.core.JDFConstants;

   ///
   /// <summary> * This class is a representation of a number list (JDFNumberList). It is a whitespace separated list of double values. </summary>
   /// 
   public class JDFNumberList : JDFNumList
   {
      // **************************************** Constructors
      // ****************************************
      ///   
      ///	 <summary> * constructs a number list with the given string
      ///	 *  </summary>
      ///	 * <param name="s"> the given String
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the String has not a valid format </exception>
      ///	 
      public JDFNumberList(string s)
         : base(s)
      {
      }

      ///   
      ///	 <summary> * constructs a number list with the given vector
      ///	 *  </summary>
      ///	 * <param name="v"> the given vector
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the Vector has not a valid format </exception>
      ///	 
      public JDFNumberList(ArrayList v)
         : base(v)
      {
      }

      // **************************************** Methods
      // *********************************************
      ///   
      ///	 <summary> * isValid - true if all instances are Double types
      ///	 *  </summary>
      ///	 * <exception cref="FormatException"> - if the Vector has not a valid format </exception>
      ///	 
      public override void isValid()
      {
         for (int i = 0; i < m_numList.Count; i++)
         {
            if (!(m_numList[i] is double))
            {
               throw new FormatException("Data format exception!");
            }
         }
      }


      ///   
      ///	 <summary> * add - adds a Double object to the vector
      ///	 *  </summary>
      ///	 * <param name="x"> the Double object </param>
      ///	 
      public virtual void Add(double x)
      {
         m_numList.Add(x);
      }

      ///   
      ///	 <summary> * add - adds a complete number list to the vector
      ///	 *  </summary>
      ///	 * <param name="nl"> the given JDFNumberList </param>
      ///	 
      public virtual void Add(JDFNumberList nl)
      {
         m_numList.AddRange(nl.copyNumList());
      }

      ///   
      ///	 <summary> * add - adds a number list to the already existing number list
      ///	 *  </summary>
      ///	 * <param name="s"> the given string
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the String has not a valid format </exception>
      ///	 
      public virtual void Add(string s)
      {
         //StringTokenizer sToken = new StringTokenizer(s, JDFConstants.BLANK);
         SupportClass.Tokenizer sToken = new SupportClass.Tokenizer(s, JDFConstants.BLANK);

         while (sToken.HasMoreTokens())
         {
            string t = sToken.NextToken().Trim();
            m_numList.Add(t);
         }
      }

      ///   
      ///	 <summary> * return true if at least one value in the list is d
      ///	 *  </summary>
      ///	 * <param name="d"> the value to search
      ///	 * @return </param>
      ///	 
      public virtual bool Contains(double d)
      {
         return Contains(d);
      }
   }
}
