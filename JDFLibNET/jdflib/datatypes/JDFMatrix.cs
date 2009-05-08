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
 * JDFMatrix.cs
 * Last changes
 * 2001-10-19   Dagmar Schlenz  Bug fixed in getAffineTransform
 */

namespace org.cip4.jdflib.datatypes
{
   using System;
   using System.Collections;
   using System.Drawing.Drawing2D;

   using EnumOrientation = org.cip4.jdflib.core.JDFElement.EnumOrientation;
   using HashUtil = org.cip4.jdflib.util.HashUtil;

   ///
   /// <summary> * This class represents a transformation matrix consisting of 6 transformation values a, b, c, d, tx, ty all values are
   /// * double values. The matrix looks like:
   /// * 
   /// * <pre>
   /// *  [ x']   [  a  b  tx  ] [ x ]   [ m00x + m01y + m02 ]
   /// *  [ y'] = [  c  d  ty  ] [ y ] = [ m10x + m11y + m12 ]
   /// *  [ 1 ]   [  0  0  1   ] [ 1 ]   [         1         ]
   /// * </pre>
   /// *  </summary>
   /// 
   public class JDFMatrix : JDFNumList
   {
      // **************************************** Constructors
      // ****************************************
      public static readonly JDFMatrix unitMatrix = new JDFMatrix(1, 0, 0, 1, 0, 0);

      ///   
      ///	 <summary> * constructs a matrix with all values set to 0.0 Double </summary>
      ///	 
      public JDFMatrix()
         : base(JDFBaseDataTypes_Fields.MAX_MATRIX_DIMENSION)
      {
      }

      ///   
      ///	 <summary> * constructs a matrix with all values set via a Vector of Double objects
      ///	 *  </summary>
      ///	 * <param name="Vector"> v - the given Vector
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the Vector has not a valid format </exception>
      ///	 
      public JDFMatrix(ArrayList v)
         : base(v)
      {
      }

      ///   
      ///	 <summary> * constructs a matrix with all values set via arotation and a shift
      ///	 *  </summary>
      ///	 * <param name="degrees"> - the rotation in degrees </param>
      ///	 * <param name="x"> the X shift </param>
      ///	 * <param name="y"> the Y shift
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the Vector has not a valid format </exception>
      ///	 
      public JDFMatrix(double degrees, double x, double y)
         : base(JDFBaseDataTypes_Fields.MAX_MATRIX_DIMENSION)
      {
         A = 1.0;
         D = 1.0;
         shift(x, y);
         rotate(degrees);
      }

      ///   
      ///	 <summary> * constructs a matrix with all values set via an enumerated orientation
      ///	 *  </summary>
      ///	 * <param name="orientation"> - the named orientation </param>
      ///	 * <param name="w"> the width of the unrotated object to transform </param>
      ///	 * <param name="h"> the height of the unrotated object to transform
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the Vector has not a valid format </exception>
      ///	 
      public JDFMatrix(EnumOrientation orientation, double w, double h)
         : base(JDFBaseDataTypes_Fields.MAX_MATRIX_DIMENSION)
      {
         if (orientation == null || orientation.Equals(EnumOrientation.Rotate0))
         {
            A = 1.0;
            D = 1.0;
         }
         else if (orientation.Equals(EnumOrientation.Rotate90))
         {
            B = 1.0;
            C = -1.0;
            Tx = h;
         }
         else if (orientation.Equals(EnumOrientation.Rotate180))
         {
            A = -1.0;
            D = -1.0;
            Tx = w;
            Ty = h;
         }
         else if (orientation.Equals(EnumOrientation.Rotate270))
         {
            B = -1.0;
            C = 1.0;
            Ty = w;
         }
         else if (orientation.Equals(EnumOrientation.Flip0))
         {
            A = 1.0;
            D = -1.0;
            Ty = h;
         }
         else if (orientation.Equals(EnumOrientation.Flip90))
         {
            B = -1.0;
            C = -1.0;
            Tx = h;
            Ty = w;
         }
         else if (orientation.Equals(EnumOrientation.Flip180))
         {
            A = -1.0;
            D = 1.0;
            Tx = w;
         }
         else if (orientation.Equals(EnumOrientation.Flip270))
         {
            B = 1.0;
            C = 1.0;
         }
      }

      ///   
      ///	 <summary> * constructs a matrix with all values set via a String
      ///	 *  </summary>
      ///	 * <param name="s"> the given String
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the String has not a valid format </exception>
      ///	 
      public JDFMatrix(string s)
         : base(s)
      {
      }

      ///   
      ///	 <summary> * constructs a matrix with all values set via a JDFMatrix
      ///	 *  </summary>
      ///	 * <param name="JDma"> the given matrix </param>
      ///	 
      public JDFMatrix(JDFMatrix ma)
         : base(JDFBaseDataTypes_Fields.MAX_MATRIX_DIMENSION)
      {
         A = ma.A;
         B = ma.B;
         C = ma.C;
         D = ma.D;
         Tx = ma.Tx;
         Ty = ma.Ty;
      }

      ///   
      ///	 <summary> * constructs a rectangle with all values set via a JDFNumberList
      ///	 *  </summary>
      ///	 * <param name="nl"> the given number list
      ///	 *  </param>
      ///	 * <exception cref="FormatException"> - if the JDFNumberList has not a valid format </exception>
      ///	 
      public JDFMatrix(JDFNumberList nl)
         : base(JDFBaseDataTypes_Fields.MAX_MATRIX_DIMENSION)
      {
         if (nl.Count != JDFBaseDataTypes_Fields.MAX_MATRIX_DIMENSION)
            throw new FormatException("JDFMatrix: can't construct JDFMatrix from this JDFNuberList value");
         m_numList[0] = nl.m_numList[0];
         m_numList[1] = nl.m_numList[1];
         m_numList[2] = nl.m_numList[2];
         m_numList[3] = nl.m_numList[3];
         m_numList[4] = nl.m_numList[4];
         m_numList[5] = nl.m_numList[5];
      }

      ///   
      ///	 <summary> * constructs a new JDFMatrix with the given double values
      ///	 *  </summary>
      ///	 * <param name="a"> position 01 of the transformation matrix </param>
      ///	 * <param name="b"> position 02 of the transformation matrix </param>
      ///	 * <param name="c"> position 10 of the transformation matrix </param>
      ///	 * <param name="d"> position 11 of the transformation matrix </param>
      ///	 * <param name="tx"> position 03 of the transformation matrix </param>
      ///	 * <param name="ty"> position 13 of the transformation matrix </param>
      ///	 
      public JDFMatrix(double a, double b, double c, double d, double tx, double ty)
         : base(JDFBaseDataTypes_Fields.MAX_MATRIX_DIMENSION)
      {
         A = a;
         B = b;
         C = c;
         D = d;
         Tx = tx;
         Ty = ty;
      }

      // **************************************** Methods
      // *********************************************
      ///   
      ///	 <summary> * isValid - true if the size of the vector is 6 and all instances are Double types
      ///	 *  </summary>
      ///	 * <exception cref="FormatException"> - if the Vector has not a valid format </exception>
      ///	 
      public override void isValid()
      {
         if (m_numList.Count != JDFBaseDataTypes_Fields.MAX_MATRIX_DIMENSION)
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
      /// Get/Set A, First Coordinate of Transform
      /// </summary>
      public virtual double A
      {
         get { return (double)m_numList[0]; }
         set { m_numList[0] = value; }
      }


      /// <summary>
      /// Get/Set B, Second Coordinate of Transform
      /// </summary>
      public virtual double B
      {
         get { return (double)m_numList[1]; }
         set { m_numList[1] = value; }
      }


      /// <summary>
      /// Get/Set C, Third Coordinate of Transform
      /// </summary>
      public virtual double C
      {
         get { return (double)m_numList[2]; }
         set { m_numList[2] = value; }
      }


      /// <summary>
      /// Get/Set D, Fourth Coordinate of Transform
      /// </summary>
      public virtual double D
      {
         get { return (double)m_numList[3]; }
         set { m_numList[3] = value; }
      }


      /// <summary>
      /// Get/Set Tx, Tx Coordinate of Transform
      /// </summary>
      public virtual double Tx
      {
         get { return (double)m_numList[4]; }
         set { m_numList[4] = value; }
      }


      /// <summary>
      /// Get/Set Ty, TxyCoordinate of Transform
      /// </summary>
      public virtual double Ty
      {
         get { return (double)m_numList[5]; }
         set { m_numList[5] = value; }
      }


      ///   
      ///	 <summary> * equals - returns true if both JDFMatrices are equal, otherwise false
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

         JDFMatrix m = (JDFMatrix)other;

         return (Math.Abs(this.A - m.A) <= JDFBaseDataTypes_Fields.EPSILON) && (Math.Abs(this.B - m.B) <= JDFBaseDataTypes_Fields.EPSILON) && (Math.Abs(this.C - m.C) <= JDFBaseDataTypes_Fields.EPSILON) && (Math.Abs(this.D - m.D) <= JDFBaseDataTypes_Fields.EPSILON) && (Math.Abs(this.Tx - m.Tx) <= JDFBaseDataTypes_Fields.EPSILON) && (Math.Abs(this.Ty - m.Ty) <= JDFBaseDataTypes_Fields.EPSILON);
      }

      ///   
      ///	 <summary> * hashCode complements equals() to fulfill the equals/hashCode contract </summary>
      ///	 
      public override int GetHashCode()
      {
         return HashUtil.GetHashCode(base.GetHashCode(), this.ToString());
      }

      /// <summary>
      /// Get/Set Affine Transform
      /// </summary>
      public virtual Matrix AffineTransform
      {
         get { return new Matrix((float)this.A, (float)this.B, (float)this.C, (float)this.D, (float)this.Tx, (float)this.Ty); }
         set
         {
            double[] flatMatrix = new double[6];
            SupportClass.GetMatrix(value, flatMatrix);
            A = flatMatrix[0];
            B = flatMatrix[1];
            C = flatMatrix[2];
            D = flatMatrix[3];
            Tx = flatMatrix[4];
            Ty = flatMatrix[5];
         }
      }


      ///   
      ///	 <summary> * shifts Tx and Ty by the amount specified
      ///	 *  </summary>
      ///	 * <param name="tX"> shift in x direction </param>
      ///	 * <param name="tY"> shift in y direction </param>
      ///	 
      public virtual void shift(double tx, double ty)
      {
         Tx = Tx + tx;
         Ty = Ty + ty;
      }

      ///   
      ///	 <summary> * rotate this by degrees degrees CouterClockwise
      ///	 *  </summary>
      ///	 * <param name="degrees"> the degrees to rotate by in counterclockwise direction </param>
      ///	 
      public virtual void rotate(double degrees)
      {
         Matrix at = AffineTransform;
         at.Rotate((float)(degrees * System.Math.PI / 180.0 * (180 / System.Math.PI)));
         AffineTransform = at;
      }

      ///   
      ///	 <summary> * concatinates this with m
      ///	 *  </summary>
      ///	 * <param name="m"> the matrix to concatinate </param>
      ///	 * <param name="tY"> shift in y direction </param>
      ///	 
      public virtual void concat(JDFMatrix m)
      {
         Matrix a = AffineTransform;
         Matrix ma = m.AffineTransform;
         //UPGRADE_TODO: Method 'java.awt.geom.AffineTransform.concatenate' was converted to 'System.Drawing.Drawing2D.Matrix.Multiply' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javaawtgeomAffineTransformconcatenate_javaawtgeomAffineTransform'"
         a.Multiply(ma, MatrixOrder.Append);
         AffineTransform = a;
      }

      ///   
      ///	 <summary> * shift this matrix by an xypair
      ///	 *  </summary>
      ///	 * <param name="point"> the point to shift by </param>
      ///	 
      public virtual void shift(JDFXYPair point)
      {
         if (point == null)
            return;
         shift(point.X, point.Y);

      }
   }
}
