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
 * JDFCMYKColor.cs
 * Last changes
 */

namespace org.cip4.jdflib.datatypes
{
   using System;
   using System.Collections;


   ///
   /// <summary> * This class is a representation of a CMYK color (JDFCMYKColor). It is a blank separated list of double values
   /// * consisting of C the cyan color, M the magenta color, Y the yellow color and K the black color value. </summary>
   /// 
   public class JDFCMYKColor : JDFNumList
   {
      // **************************************** Constructors
      // ****************************************
      ///   
      ///	 <summary> * constructs a CMYK color with all values set to 0.0 Double </summary>
      ///	 
      public JDFCMYKColor()
         : base(JDFBaseDataTypes_Fields.MAX_CMYK_COLOR)
      {
      }

      ///   
      ///	 <summary> * constructs a CMYK color with the given vector
      ///	 *  </summary>
      ///	 * <param name="Vector"> v - the given vector
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the Vector has not a valid format </exception>
      ///	 
      public JDFCMYKColor(ArrayList v)
         : base(v)
      {
      }

      ///   
      ///	 <summary> * constructs a CMYK color with the given String
      ///	 *  </summary>
      ///	 * <param name="String"> s - the given String
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the String has not a valid format </exception>
      ///	 
      public JDFCMYKColor(string s)
         : base(s)
      {
      }

      ///   
      ///	 <summary> * constructs a CMYK color with a given JDFCMYKColor
      ///	 *  </summary>
      ///	 * <param name="JDFCMYKColor"> cmyk - the given CMYK colors
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the String has not a valid format </exception>
      ///	 
      public JDFCMYKColor(JDFCMYKColor cmyk)
         : this(cmyk.ToString())
      {
      }

      ///   
      ///	 <summary> * constructs a CMYK color with a given JDFNumberList
      ///	 *  </summary>
      ///	 * <param name="JDFNumberList"> nl - the given number list
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the String has not a valid format </exception>
      ///	 
      public JDFCMYKColor(JDFNumberList nl)
         : base(nl)
      {
      }

      ///   
      ///	 <summary> * constructs a new CMYK color with the given double values
      ///	 *  </summary>
      ///	 * <param name="double"> c - the value c </param>
      ///	 * <param name="double"> m - the value m </param>
      ///	 * <param name="double"> y - the value y </param>
      ///	 * <param name="double"> k - the value k </param>
      ///	 
      public JDFCMYKColor(double c, double m, double y, double k)
         : base(JDFBaseDataTypes_Fields.MAX_CMYK_COLOR)
      {
         m_numList[0] = c;
         m_numList[1] = m;
         m_numList[2] = y;
         m_numList[3] = k;
      }

      // **************************************** Methods
      // *********************************************
      ///   
      ///	 <summary> * isValid - the size of the vector must be 4 and all instances are Double types
      ///	 *  </summary>
      ///	 * <exception cref="FormatException"> - if the Vector has not a valid format </exception>
      ///	 
      public override void isValid()
      {
         if (m_numList.Count != JDFBaseDataTypes_Fields.MAX_CMYK_COLOR)
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
      ///	 <summary> * Get/Set the value C of the CMYK color
      ///	 *  </summary>
      ///	 * <returns> double - the value C of the CMYK color </returns>
      ///	 
      public virtual double C
      {
         get { return ((double)m_numList[0]); }
         set { m_numList[0] = value; }
      }


      ///   
      ///	 <summary> * Get/Set the value M of the CMYK color
      ///	 *  </summary>
      ///	 * <returns> double - the value M of the CMYK color </returns>
      ///	 
      public virtual double M
      {
         get { return ((double)m_numList[1]); }
         set { m_numList[1] = value; }
      }

      ///   
      ///	 <summary> * getY - returns the value Y of the CMYK color
      ///	 *  </summary>
      ///	 * <returns> double - the value Y of the CMYK color </returns>
      ///	 
      public virtual double Y
      {
         get { return ((double)m_numList[2]); }
         set { m_numList[2] = value; }
      }

      ///   
      ///	 <summary> * getK - returns the value K of the CMYK color
      ///	 *  </summary>
      ///	 * <returns> double - the value K of the CMYK color </returns>
      ///	 
      public virtual double K
      {
         get { return ((double)m_numList[3]); }
         set { m_numList[3] = value; }
      }
   }
}
