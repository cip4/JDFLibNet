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
 * JDFShape.cs
 * Last changes
 */

namespace org.cip4.jdflib.datatypes
{
   using System;
   using System.Collections;


   using HashUtil = org.cip4.jdflib.util.HashUtil;

   ///
   /// <summary> * This class is a representation of a JDFShape. It is a blank separated list of double values consisting of a width(x),
   /// * a height(y) and a depth(z) value. this spans a standard right-handed xyz coordinate system </summary>
   /// 
   public class JDFShape : JDFNumList
   {
      // **************************************** Constructors
      // ****************************************

      ///   
      ///	 <summary> * constructor - constructs a shape with all values set to 0.0 Double </summary>
      ///	 
      public JDFShape()
         : base(JDFBaseDataTypes_Fields.MAX_SHAPE_DIMENSION)
      {
      }

      ///   
      ///	 <summary> * constructor - constructs a shape with all values set via a Vector of Double objects
      ///	 *  </summary>
      ///	 * <param name="v"> the given vector
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the Vector has not a valid format </exception>
      ///	 
      public JDFShape(ArrayList v)
         : base(v)
      {
      }

      ///   
      ///	 <summary> * constructor - constructs a shape with all values set via a String
      ///	 *  </summary>
      ///	 * <param name="s"> the given String
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the String has not a valid format </exception>
      ///	 
      public JDFShape(string s)
         : base(s)
      {
      }

      ///   
      ///	 <summary> * constructor - constructs a shape with all values set via a JDFShape
      ///	 *  </summary>
      ///	 * <param name="shape"> the given shape
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the JDFShape has not a valid format </exception>
      ///	 
      public JDFShape(JDFShape shape)
         : base(JDFBaseDataTypes_Fields.MAX_SHAPE_DIMENSION)
      {
         Y = shape.Y;
         X = shape.X;
         Z = shape.Z;
      }

      ///   
      ///	 <summary> * constructor - constructs a shape with all values set via a JDFNumberList
      ///	 *  </summary>
      ///	 * <param name="nl"> the given number list
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the JDFNumberList has not a valid format </exception>
      ///	 
      public JDFShape(JDFNumberList nl)
         : base(JDFBaseDataTypes_Fields.MAX_SHAPE_DIMENSION)
      {
         if (nl.Count != JDFBaseDataTypes_Fields.MAX_SHAPE_DIMENSION)
            throw new FormatException("JDFShape: can't construct JDFShape from this JDFNuberList value");
         m_numList[0] = nl.m_numList[0];
         m_numList[1] = nl.m_numList[1];
         m_numList[2] = nl.m_numList[2];
      }

      ///   
      ///	 <summary> * constructor - constructs a new JDFShape with the given double values
      ///	 *  </summary>
      ///	 * <param name="x"> the x value </param>
      ///	 * <param name="y"> the y value </param>
      ///	 * <param name="z"> the z value </param>
      ///	 
      public JDFShape(double x, double y, double z)
         : base(JDFBaseDataTypes_Fields.MAX_SHAPE_DIMENSION)
      {
         Y = y;
         X = x;
         Z = z;
      }

      ///   
      ///	 <summary> * constructor - constructs a new JDFShape with the given 2 double values third is default = 0.
      ///	 *  </summary>
      ///	 * <param name="height"> the height </param>
      ///	 * <param name="width"> the width </param>
      ///	 * <param name="length"> the length = 0.0 </param>
      ///	 
      public JDFShape(double x, double y)
         : base(JDFBaseDataTypes_Fields.MAX_SHAPE_DIMENSION)
      {
         Y = y;
         X = x;
         Z = 0.0;
      }

      // **************************************** Methods
      // *********************************************
      ///   
      ///	 <summary> * isValid - true if the size of the vector is 3 and all instances are Double types
      ///	 *  </summary>
      ///	 * <exception cref="FormatException"> - if the Vector has not a valid format </exception>
      ///	 
      public override void isValid()
      {
         if (m_numList.Count != JDFBaseDataTypes_Fields.MAX_SHAPE_DIMENSION && m_numList.Count != JDFBaseDataTypes_Fields.MAX_SHAPE_DIMENSION - 1) // Shape
         // with
         // default
         // length = 0.0
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
         if (m_numList.Count == 2)
            m_numList.Add(0.0);
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

         JDFShape shape = (JDFShape)other;

         return (Math.Abs(this.Y - shape.Y) <= JDFBaseDataTypes_Fields.EPSILON) && (Math.Abs(this.X - shape.X) <= JDFBaseDataTypes_Fields.EPSILON) && (Math.Abs(this.Z - shape.Z) <= JDFBaseDataTypes_Fields.EPSILON);
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
      ///	 * <param name="x"> the JDFShape object to compare to </param>
      ///	 * <returns> boolean - true if this >= x </returns>
      ///	 
      public virtual bool isGreaterOrEqual(JDFShape x)
      {
         return ((Y >= x.Y) && (X >= x.X) && (Z >= x.Z));
      }

      ///   
      ///	 <summary> * isLessOrEqual - equality operator <=
      ///	 *  </summary>
      ///	 * <param name="x"> the JDFShape object to compare to </param>
      ///	 * <returns> boolean - true if this <= x </returns>
      ///	 
      public virtual bool isLessOrEqual(JDFShape x)
      {
         return ((Y <= x.Y) && (X <= x.X) && (Z <= x.Z));
      }

      ///   
      ///	 <summary> * isGreater - equality operator >
      ///	 *  </summary>
      ///	 * <param name="x"> the JDFShape object to compare to </param>
      ///	 * <returns> boolean - true if this > x </returns>
      ///	 
      public virtual bool isGreater(JDFShape x)
      {
         return (!Equals(x) && (Y >= x.Y) && (X >= x.X) && (Z >= x.Z));
      }

      ///   
      ///	 <summary> * isLess - equality operator <
      ///	 *  </summary>
      ///	 * <param name="x"> the JDFShape object to compare to </param>
      ///	 * <returns> boolean - true if this < x </returns>
      ///	 
      public virtual bool isLess(JDFShape x)
      {
         return (!Equals(x) && (Y <= x.Y) && (X <= x.X) && (Z <= x.Z));
      }

      ///   
      ///	 <summary> * Get/Set Y value - the width
      ///	 *  </summary>
      ///	 * <returns> double - the width
      ///	 *  </returns>
      ///	 
      public virtual double Y
      {
         get { return ((double)m_numList[1]); }
         set { m_numList[1] = value; }
      }

      ///   
      ///	 <summary> * getHeight - returns the height
      ///	 *  </summary>
      ///	 * @deprecated use getY - attention height and width were accidentally exchanged
      ///	 *  
      ///	 * <returns> double - the height </returns>
      ///	 
      [Obsolete("use the Y property - attention height and width were accidentally exchanged")]
      public virtual double getHeight()
      {
         return Y;
      }

      ///   
      ///	 <summary> * setHeight - sets the height
      ///	 *  </summary>
      ///	 * @deprecated attention height and width were accidentally exchanged 
      ///	 * <param name="height"> the height </param>
      ///	 
      [Obsolete("use the Y property - attention height and width were accidentally exchanged")]
      public virtual void setHeight(double height)
      {
         Y = height;
      }

      ///   
      ///	 <summary> * Get/Set X value - the width
      ///	 *  </summary>
      ///	 * <returns> double - the width
      ///	 *  </returns>
      ///	 
      public virtual double X
      {
         get { return ((double)m_numList[0]); }
         set { m_numList[0] = value; }
      }

      ///   
      ///	 <summary> * getWidth - returns the width
      ///	 *  </summary>
      ///	 * @deprecated use getX - attention height and width were accidentally exchanged 
      ///	 * <returns> double - the width
      ///	 *  </returns>
      ///	 
      [Obsolete("use the X property - attention height and width were accidentally exchanged")]
      public virtual double getWidth()
      {
         return X;
      }

      ///   
      ///	 <summary> * setWidth - sets the width
      ///	 *  </summary>
      ///	 * @deprecated attention height and width were accidentally exchanged 
      ///	 * <param name="width"> the width </param>
      ///	 
      [Obsolete("use the X property - attention height and width were accidentally exchanged")]
      public virtual void setWidth(double width)
      {
         X = width;
      }


      ///   
      ///	 <summary> * Get/Set the Z value - The length
      ///	 *  </summary>
      ///	 * <returns> double - the length </returns>
      ///	 
      public virtual double Z
      {
         get { return ((double)m_numList[2]); }
         set { m_numList[2] = value; }
      }

      ///   
      ///	 <summary> * getLength - returns the length
      ///	 *  </summary>
      ///	 * @deprecated use getZ 
      ///	 * <returns> double - the length </returns>
      ///	 
      [Obsolete("use the Z property")]
      public virtual double getLength()
      {
         return Z;
      }

      ///   
      ///	 <summary> * setLength - sets the length
      ///	 * 
      ///	 * @deprecated </summary>
      ///	 * <param name="length"> the length </param>
      ///	 
      [Obsolete("use the Z property")]
      public virtual void setLength(double length)
      {
         Z = length;
      }
   }
}
