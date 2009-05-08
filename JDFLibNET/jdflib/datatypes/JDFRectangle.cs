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
 * JDFRectangle.cs
 * Last changes
 */

namespace org.cip4.jdflib.datatypes
{
   using System;
   using System.Collections;


   using HashUtil = org.cip4.jdflib.util.HashUtil;

   ///
   /// <summary> * This class represents a rectangle JDFRectangle) consisting of a lower left x value (llx), a lower left y value (lly),
   /// * an upper right x value (urx) and an upper right y value (ury) all values are Double types. </summary>
   /// 
   public class JDFRectangle : JDFNumList
   {
      // **************************************** Constructors
      // ****************************************
      ///   
      ///	 <summary> * constructs a rectangle with all 4 values set to 0.0 Double </summary>
      ///	 
      public JDFRectangle()
         : base(JDFBaseDataTypes_Fields.MAX_RECTANGLE_DIMENSION)
      {
      }

      ///   
      ///	 <summary> * constructs a rectangle with all values set via a Vector of Double objects
      ///	 *  </summary>
      ///	 * <param name="v"> the given Vector with MAX_RECTANGLE_DIMENSION objects of type Double
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the Vector has not a valid format </exception>
      ///	 
      public JDFRectangle(ArrayList v)
         : base(v)
      {
      }

      ///   
      ///	 <summary> * constructs a rectangle with all values set via a String
      ///	 *  </summary>
      ///	 * <param name="s"> the given String, blank separated numbers
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the String has not a valid format </exception>
      ///	 
      public JDFRectangle(string s)
         : base(s)
      {
      }

      ///   
      ///	 <summary> * constructs a rectangle with all values set via a JDFRectangle
      ///	 *  </summary>
      ///	 * <param name="rec"> the given rectangle </param>
      ///	 
      public JDFRectangle(JDFRectangle rec)
         : base(JDFBaseDataTypes_Fields.MAX_RECTANGLE_DIMENSION)
      {
         Llx = rec.Llx;
         Lly = rec.Lly;
         Urx = rec.Urx;
         Ury = rec.Ury;
      }

      ///   
      ///	 <summary> * constructs a rectangle with all values set via a JDFNumberList
      ///	 *  </summary>
      ///	 * <param name="nl"> the given number list
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the JDFNumberList has not a valid format </exception>
      ///	 
      public JDFRectangle(JDFNumberList nl)
         : base(JDFBaseDataTypes_Fields.MAX_RECTANGLE_DIMENSION)
      {
         if (nl.Count != JDFBaseDataTypes_Fields.MAX_RECTANGLE_DIMENSION)
            throw new FormatException("JDFRectangle: can't construct JDFRectangle from this JDFNuberList value");
         m_numList[0] = nl.m_numList[0];
         m_numList[1] = nl.m_numList[1];
         m_numList[2] = nl.m_numList[2];
         m_numList[3] = nl.m_numList[3];
      }

      ///   
      ///	 <summary> * constructs a new JDFRectangle with the given double values
      ///	 *  </summary>
      ///	 * <param name="llx"> lower left x coordinate </param>
      ///	 * <param name="lly"> lower left y coordinate </param>
      ///	 * <param name="urx"> lower left x coordinate </param>
      ///	 * <param name="ury"> lower left y coordinate </param>
      ///	 
      public JDFRectangle(double llx, double lly, double urx, double ury)
         : base(JDFBaseDataTypes_Fields.MAX_RECTANGLE_DIMENSION)
      {
         Llx = llx;
         Lly = lly;
         Urx = urx;
         Ury = ury;
      }

      // **************************************** Methods
      // *********************************************
      ///   
      ///	 <summary> * isValid - true if the size of the vector is 4 and all instances are Double types
      ///	 *  </summary>
      ///	 * <exception cref="FormatException"> - if the Vector has not a valid format </exception>
      ///	 
      public override void isValid()
      {
         if (m_numList.Count != JDFBaseDataTypes_Fields.MAX_RECTANGLE_DIMENSION)
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
      ///	 <summary> * hashCode complements equals() to fulfill the equals/hashCode contract
      ///	 *  </summary>
      ///	 * <returns> int </returns>
      ///	 
      public override int GetHashCode()
      {
         return HashUtil.GetHashCode(base.GetHashCode(), this.ToString());
      }

      ///   
      ///	 <summary> * Get/Set Llx - the lower left x coordinate
      ///	 *  </summary>
      ///	 * <returns> double - the lower left x coordinate </returns>
      ///	 
      public virtual double Llx
      {
         get { return ((double)m_numList[0]); }
         set { m_numList[0] = value; }
      }

      ///   
      ///	 <summary> * Get/Set Lly - the lower left y coordinate
      ///	 *  </summary>
      ///	 * <returns> double - the lower left y coordinate </returns>
      ///	 
      public virtual double Lly
      {
         get { return ((double)m_numList[1]); }
         set { m_numList[1] = value; }
      }


      ///   
      ///	 <summary> * Get/Set Urx - the upper right x coordinate
      ///	 *  </summary>
      ///	 * <returns> double - the upper right x coordinate </returns>
      ///	 
      public virtual double Urx
      {
         get { return ((double)m_numList[2]); }
         set { m_numList[2] = value; }
      }


      ///   
      ///	 <summary> * Get/Set Ury the upper right y coordinate
      ///	 *  </summary>
      ///	 * <returns> double - the upper right y coordinate </returns>
      ///	 
      public virtual double Ury
      {
         get { return ((double)m_numList[3]); }
         set { m_numList[3] = value; }
      }


      ///   
      ///	 <summary> * getWidth - returns the width of the rectangle, the difference between upper right x value and lower left x value
      ///	 * as an absolute value
      ///	 *  </summary>
      ///	 * <returns> double - the width of the rectangle </returns>
      ///	 
      public virtual double Width
      {
         //return Math.Abs(((double) m_numList[2]).doubleValue() - ((double) m_numList[0]).doubleValue());
         get { return Math.Abs(((double)m_numList[2]) - ((double)m_numList[0])); }
      }

      ///   
      ///	 <summary> * getHeight - returns the height of the rectangle, the difference between upper right y value and lower left y
      ///	 * value as an absolute value
      ///	 *  </summary>
      ///	 * <returns> double - the height of the rectangle </returns>
      ///	 
      public virtual double Height
      {
         //return Math.Abs(((double)m_numList[3]).doubleValue() - ((double)m_numList[1]).doubleValue());
         get { return Math.Abs(((double)m_numList[3]) - ((double)m_numList[1])); }
      }

      ///   
      ///	 <summary> * isGreater - equality operator >
      ///	 *  </summary>
      ///	 * <param name="r"> the JDFRectangle object to compare to </param>
      ///	 * <returns> boolean - true if <code>this</this> > r </returns>
      ///	 
      public virtual bool isGreater(JDFRectangle r)
      {
         return (!Equals(r) && (Llx <= r.Llx) && (Lly <= r.Lly) && (Urx >= r.Urx) && (Ury >= r.Ury));
      }

      ///   
      ///	 <summary> * isGreaterOrEqual - equality operator >=
      ///	 *  </summary>
      ///	 * <param name="r"> the JDFRectangle object to compare to </param>
      ///	 * <returns> boolean - true if <code>this</this> >= r </returns>
      ///	 
      public virtual bool isGreaterOrEqual(JDFRectangle r)
      {
         return (Llx <= r.Llx) && (Lly <= r.Lly) && (Urx >= r.Urx) && (Ury >= r.Ury);
      }

      ///   
      ///	 <summary> * isLess - equality operator <
      ///	 *  </summary>
      ///	 * <param name="r"> the JDFRectangle object to compare to </param>
      ///	 * <returns> boolean - true if <code>this</this> < r </returns>
      ///	 
      public virtual bool isLess(JDFRectangle r)
      {
         return (!Equals(r) && (Llx >= r.Llx) && (Lly >= r.Lly) && (Urx <= r.Urx) && (Ury <= r.Ury));
      }

      ///   
      ///	 <summary> * isLessOrEqual - equality operator <=
      ///	 *  </summary>
      ///	 * <param name="r"> the JDFRectangle object to compare to </param>
      ///	 * <returns> boolean - true if <code>this</this> <= r </returns>
      ///	 
      public virtual bool isLessOrEqual(JDFRectangle r)
      {
         return (Llx >= r.Llx) && (Lly >= r.Lly) && (Urx <= r.Urx) && (Ury <= r.Ury);
      }
   }
}
