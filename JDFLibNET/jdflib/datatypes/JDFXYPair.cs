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
 *  
 */ 


/*
 * Copyright (c) 2001 Heidelberger Druckmaschinen AG, All Rights Reserved.
 * JDFXYPair.cs
 * Last changes
 */

namespace org.cip4.jdflib.datatypes
{
   using System;
   using System.Collections;


   using HashUtil = org.cip4.jdflib.util.HashUtil;

   ///
   /// <summary> * This class represents a x y pair (JDFXYPair). It is a whitespace separated list of 2 numbers. </summary>
   /// 
   public class JDFXYPair : JDFNumList
   {
      // **************************************** Constructors
      // ****************************************
      ///   
      ///	 <summary> * constructs a xy pair with all values set to 0.0 Double </summary>
      ///	 
      public JDFXYPair()
         : base(JDFBaseDataTypes_Fields.MAX_XY_DIMENSION)
      {
      }

      ///   
      ///	 <summary> * constructs a xy pair with all values set via a Vector of Double objects
      ///	 *  </summary>
      ///	 * <param name="v"> Vector of Double
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the Vector has not a valid format </exception>
      ///	 
      public JDFXYPair(ArrayList v)
         : base(v)
      {
      }

      ///   
      ///	 <summary> * constructs a xy pair with all values set via a String
      ///	 *  </summary>
      ///	 * <param name="s"> the given String
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the String has not a valid format </exception>
      ///	 
      public JDFXYPair(string s)
         : base(s)
      {
      }

      ///   
      ///	 <summary> * constructs a xy pair with all values set via a JDFXYPair
      ///	 *  </summary>
      ///	 * <param name="xy"> the given xy pair
      ///	 *  </param>
      ///	 
      public JDFXYPair(JDFXYPair xy)
         : base(JDFBaseDataTypes_Fields.MAX_XY_DIMENSION)
      {
         this.X = xy.X;
         this.Y = xy.Y;
      }

      ///   
      ///	 <summary> * constructs a xy pair with all values set via a JDFNumberList
      ///	 *  </summary>
      ///	 * <param name="nl"> the given number list
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the JDFNumberList has not a valid format </exception>
      ///	 
      public JDFXYPair(JDFNumberList nl)
         : base(JDFBaseDataTypes_Fields.MAX_XY_DIMENSION)
      {
         if (nl.Count != JDFBaseDataTypes_Fields.MAX_XY_DIMENSION)
            throw new FormatException("JDFXYPair: can't construct JDFXYPair from this JDFNuberList value");
         m_numList[0] = nl.m_numList[0];
         m_numList[1] = nl.m_numList[1];
      }

      ///   
      ///	 <summary> * constructs a new JDFXYPair with the given double values
      ///	 *  </summary>
      ///	 * <param name="x"> the x coordinate </param>
      ///	 * <param name="y"> the y coordinate </param>
      ///	 
      public JDFXYPair(double x, double y)
         : base(JDFBaseDataTypes_Fields.MAX_XY_DIMENSION)
      {
         m_numList[0] = x;
         m_numList[1] = y;
      }

      // **************************************** Methods
      // *********************************************
      ///   
      ///	 <summary> * isValid - valid if the size of the vector is 2 and all instances are Double types
      ///	 *  </summary>
      ///	 * <exception cref="FormatException"> - if the Vector has not a valid format </exception>
      ///	 
      public override void isValid()
      {
         if (m_numList.Count != JDFBaseDataTypes_Fields.MAX_XY_DIMENSION)
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


      /// <summary>
      /// Get/Set X value
      /// </summary>
      public virtual double X
      {
         get { return (double)m_numList[0]; }
         set { m_numList[0] = value; }
      }

      /// <summary>
      /// Get/Set Y value
      /// </summary>
      public virtual double Y
      {
         get { return (double)m_numList[1]; }
         set { m_numList[1] = value; }
      }


      ///   
      ///	 <summary> * equals - returns true if both JDFShapes are equal, otherwise false
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

         JDFXYPair xyPair = (JDFXYPair)other;

         return (Math.Abs(this.X - xyPair.X) <= JDFBaseDataTypes_Fields.EPSILON) && (Math.Abs(this.Y - xyPair.Y) <= JDFBaseDataTypes_Fields.EPSILON);
      }

      ///   
      ///	 <summary> * hashCode complements equals() to fulfill the equals/hashCode contract </summary>
      ///	 
      public override int GetHashCode()
      {
         return HashUtil.GetHashCode(base.GetHashCode(), this.ToString());
      }

      ///   
      ///	 <summary> * isGreaterOrEqual - equality operator >=
      ///	 *  </summary>
      ///	 * <param name="x"> the JDFXYPair object to compare to </param>
      ///	 * <returns> boolean - true if this >= x </returns>
      ///	 
      public virtual bool isGreaterOrEqual(JDFXYPair x)
      {
         return (Equals(x) || ((this.X >= x.X) && (this.Y >= x.Y)));
      }

      ///   
      ///	 <summary> * isLessOrEqual - equality operator <=
      ///	 *  </summary>
      ///	 * <param name="x"> the JDFXYPair object to compare to </param>
      ///	 * <returns> boolean - true if this <= x </returns>
      ///	 
      public virtual bool isLessOrEqual(JDFXYPair x)
      {
         return (Equals(x) || ((this.X <= x.X) && (this.Y <= x.Y)));
      }

      ///   
      ///	 <summary> * isGreater - equality operator >
      ///	 *  </summary>
      ///	 * <param name="x"> the JDFXYPair object to compare to </param>
      ///	 * <returns> boolean - true if this > x </returns>
      ///	 
      public virtual bool isGreater(JDFXYPair x)
      {
         return (!isLessOrEqual(x));
      }

      ///   
      ///	 <summary> * isLess - equality operator <
      ///	 *  </summary>
      ///	 * <param name="x"> the JDFXYPair object to compare to </param>
      ///	 * <returns> boolean - true if this < x </returns>
      ///	 
      public virtual bool isLess(JDFXYPair x)
      {
         return (!isGreaterOrEqual(x));
      }
   }
}
