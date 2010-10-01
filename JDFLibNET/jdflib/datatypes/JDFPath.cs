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
 * @author GonnermannJ
 * JDFPath.cs
 */

// Java to C# Conversion - TODO: Conversion not complete.
//                      Need to work out equivalent paths , points, and types between Java and .NET

namespace org.cip4.jdflib.datatypes
{
   using System;
   using System.Collections;
   using System.Drawing;
   using System.Drawing.Drawing2D;
   using System.Globalization;
   using System.Text;


   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using VString = org.cip4.jdflib.core.VString;


   /// <summary>
   /// converts a PDFpath description into a GeneralPath-Object (Shape)
   /// </summary>
   public class JDFPath
   {
      private string m_strPath;
      private readonly GraphicsPath m_GPI = new GraphicsPath();


      /// <summary>
      /// Human readable presentation of object
      /// </summary>
      /// <returns>string</returns>
      public override string ToString()
      {
         string path = JDFConstants.EMPTYSTRING;
         Matrix at = new Matrix();
         at.Reset();
         GraphicsPathIterator pi = getIterator(at);
         pi.Rewind();
         int startIndex = 0;
         int endIndex = 0;

         float[] seg;

         int segNum = 0;
         while (segNum < pi.SubpathCount)
         {
            seg = new float[6];
            int type = 0;
            pi.NextMarker(out startIndex, out endIndex);

            path += ("\nseg[" + segNum + "]= [");
            for (int j = 0; j < 5; j++)
            {
               path += (JDFConstants.BLANK + seg[j] + JDFConstants.COMMA);
            }
            path += (" type=[" + type + "] ]\n");
            segNum++;
         }

         return "Path= [\n" + "\tbox=     " + Rectangle.Round(m_GPI.GetBounds()) + "\n" + "\twinding= " + (int)m_GPI.FillMode + "\n" + "\tcurrent= " + m_GPI.GetLastPoint() + "\n" + "segments:\n" + path + "]";
      }


	   
      /// <summary>
      /// Set Path
      /// </summary>
      /// <param name="path"></param>
      private void setPath(string path)
      {
         m_strPath = path;
      }


	   /// <summary>
	   /// Get Path
	   /// </summary>
	   /// <returns>string</returns>
      public virtual string getPath()
      {
         return m_strPath;
      }


	   /// <summary>
	   /// Constructor for JDFPath
	   /// </summary>
	   /// <param name="pdfPath"></param>
      public JDFPath(string pdfPath)
      {
         setPath(pdfPath);

         // split path
         SupportClass.Tokenizer st = new SupportClass.Tokenizer(pdfPath);

         // fill m_GPI
         ArrayList s = new ArrayList(4);
         double d = 0;
         string nt = JDFConstants.EMPTYSTRING;

         while (st.HasMoreTokens())
         {
            while (!((double)d).Equals((double)(-1)))
            {
               if (st.HasMoreTokens())
               {
                  nt = st.NextToken();
               }
               if (nt.StartsWith("["))
               {
                  nt = nt.Substring(1);
               }
               if (nt.EndsWith("]"))
               {
                  nt = nt.Substring(0, nt.Length - 1);

               }
               if (nt.Equals(JDFConstants.EMPTYSTRING))
               {
                  s.Add(JDFConstants.EMPTYSTRING); // empty param eg []
                  continue;
               }

               try
               {
                  d = Double.Parse(nt, CultureInfo.InvariantCulture);
                  s.Add(nt);
               }
               catch (FormatException)
               {
                  d = (-1);
               }
            }

            if (d == -1)
            {
               // Path Segment Operators
               if ("m".Equals(nt))
               {
                  addValues(nt, 2, s);
               }
               else if ("l".Equals(nt))
               {
                  addValues(nt, 2, s);
               }

               else if ("c".Equals(nt))
               {
                  addValues(nt, 6, s);
               }
               else if ("v".Equals(nt))
               {
                  addValues(nt, 4, s);
               }
               else if ("y".Equals(nt))
               {
                  addValues(nt, 4, s);
               }

               else if ("re".Equals(nt))
               {
                  addValues(nt, 4, s);
               }

               else if ("h".Equals(nt))
               {
                  addValues(nt, 0, s);
               }

            // Path Painting Operators
               else if ("n".Equals(nt))
               {
                  addValues(nt, 0, s);
               }

               else if ("S".Equals(nt))
               {
                  addValues(nt, 0, s);
               }
               else if ("s".Equals(nt))
               {
                  addValues(nt, 0, s);
               }

               else if ("f".Equals(nt))
               {
                  addValues(nt, 0, s);
               }
               else if ("F".Equals(nt))
               {
                  addValues(nt, 0, s);
               }
               else if ("f*".Equals(nt))
               {
                  addValues(nt, 0, s);
               }
               else if ("B".Equals(nt))
               {
                  addValues(nt, 0, s);
               }

               else if ("b".Equals(nt))
               {
                  addValues(nt, 0, s);
               }
               else if ("B*".Equals(nt))
               {
                  addValues(nt, 0, s);
               }
               else if ("b*".Equals(nt))
               {
                  addValues(nt, 0, s);
               }

               else if ("sh".Equals(nt))
               {
                  addValues(nt, 1, s);
               } // !!!! STRING-PARAM !!!

            // Path Clipping Operators
               else if ("W".Equals(nt))
               {
                  addValues(nt, 0, s);
               }
               else if ("W*".Equals(nt))
               {
                  addValues(nt, 0, s);
               }

               // reset
               d = 0;
               s.Clear();
            } 
         } 
      } 



      /// <summary>
      /// Add Values to Path
      /// </summary>
      /// <param name="type"></param>
      /// <param name="paramNum"></param>
      /// <param name="s"></param>
      /// <returns>true if successful</returns>
      private bool addValues(string type, int paramNum, ArrayList s)
      {
         if (s.Count != paramNum)
         {
            return false;
         }

         float[] x = new float[paramNum];
         try
         { // Parse Points in s
            for (int i = 0; i < paramNum; i++)
            {
               x[i] = Single.Parse(Convert.ToString(s[i], CultureInfo.InvariantCulture), CultureInfo.InvariantCulture);
            }
         }
         catch (FormatException e)
         {
            SupportClass.WriteStackTrace(e, Console.Error);
         }

         float[] a = { 0, 0 };
         try
         { // init actual point
            PointF currentPoint = m_GPI.GetLastPoint();
            if (currentPoint != null)
            {
               a[0] = Single.Parse(JDFConstants.EMPTYSTRING + Convert.ToString(currentPoint.X, CultureInfo.InvariantCulture), CultureInfo.InvariantCulture);
               a[1] = Single.Parse(JDFConstants.EMPTYSTRING + Convert.ToString(currentPoint.Y, CultureInfo.InvariantCulture), CultureInfo.InvariantCulture);
            }
         }
         catch (FormatException)
         {
            if (!"m".Equals(type))
            {
               a[0] = 0;
               a[1] = 0;
            }
         }
         catch (ArgumentException)
         {
            // if there are no points in the path yet, do nothing
         }

         try
         { // set Path
            if ("m".Equals(type))
            {
               m_GPI.AddLine(x[0], x[1], x[0], x[1]);
            }
            else if ("l".Equals(type))
            {
               m_GPI.AddLine(m_GPI.PathPoints[m_GPI.PathPoints.Length - 1].X, m_GPI.PathPoints[m_GPI.PathPoints.Length - 1].Y, x[0], x[1]);
            }
            else if ("c".Equals(type))
            {
               m_GPI.AddBezier(m_GPI.PathPoints[m_GPI.PathPoints.Length - 1].X, m_GPI.PathPoints[m_GPI.PathPoints.Length - 1].Y, x[0], x[1], x[2], x[3], x[4], x[5]);
            }
            else if ("v".Equals(type))
            {
               m_GPI.AddBezier(m_GPI.PathPoints[m_GPI.PathPoints.Length - 1].X, m_GPI.PathPoints[m_GPI.PathPoints.Length - 1].Y, a[0], a[1], x[0], x[1], x[2], x[3]);
            }
            else if ("y".Equals(type))
            {
               m_GPI.AddBezier(m_GPI.PathPoints[m_GPI.PathPoints.Length - 1].X, m_GPI.PathPoints[m_GPI.PathPoints.Length - 1].Y, x[0], x[1], x[2], x[3], x[2], x[3]);
            }
            else if ("re".Equals(type))
            {
               rectangle(x[0], x[1], x[2], x[3]);
            }

            else if ("h".Equals(type))
            {
               m_GPI.CloseFigure();
            }

            else
            {
               return false;
            }
         }
         catch (Exception e)
         {
            SupportClass.WriteStackTrace(e, Console.Error);
         }

         return true;
      }


	   /// <summary>
	   /// Add a rectangle to the shape
	   /// </summary>
	   /// <param name="x"></param>
	   /// <param name="y"></param>
	   /// <param name="w"></param>
	   /// <param name="h"></param>
      private void rectangle(float x, float y, float w, float h)
      {
         ArrayList v = new ArrayList();
         v.Add(JDFConstants.EMPTYSTRING + x);
         v.Add(JDFConstants.EMPTYSTRING + y);
         addValues("m", 2, v);
         v.Clear();
         v.Add(JDFConstants.EMPTYSTRING + (x + w));
         v.Add(JDFConstants.EMPTYSTRING + y);
         addValues("l", 2, v);
         v.Clear();
         v.Add(JDFConstants.EMPTYSTRING + (x + w));
         v.Add(JDFConstants.EMPTYSTRING + (y + h));
         addValues("l", 2, v);
         v.Clear();
         v.Add(JDFConstants.EMPTYSTRING + (x));
         v.Add(JDFConstants.EMPTYSTRING + (y + h));
         addValues("l", 2, v);
         addValues("h", 0, v);
      }


	 
      /// <summary>
      /// Get the Shape
      /// </summary>
      /// <returns>Shape</returns>
      public virtual GraphicsPath getShape()
      {
         return m_GPI;
      }


	   /// <summary>
	   /// Get the path Iterator
	   /// </summary>
	   /// <param name="at"></param>
	   /// <returns>Path Iterator</returns>
      public virtual GraphicsPathIterator getIterator(Matrix at)
      {
         return SupportClass.GraphicsPathIteratorSupport.GetGraphicsPathIterator(m_GPI, at);
      }


	 
      /// <summary>
      /// Transforms the geometry of this path using the specified AffineTransform. The geometry is transformed in place.
      /// </summary>
      /// <param name="at">Matrix (Affine Transform) used to transform the shape</param>
      public virtual void transform(Matrix at)
      {
         m_GPI.Transform(at);
         setPath(calcPath(m_GPI));
      }

       
	 
      /// <summary>
      /// Calculates the JDF string path from the awt shape
      /// </summary>
      /// <param name="shape">The shape</param>
      /// <returns>The path as string</returns>
      private string calcPath(GraphicsPath shape)
      {
         StringBuilder buffer = new StringBuilder();

         if (null != shape)
         {
            PointF[] points = shape.PathPoints;
            Byte[] types = shape.PathTypes;

            SupportClass.TextNumberFormat formatter = getFormatter();
            GraphicsPathIterator pi = new GraphicsPathIterator(shape);
            pi.Rewind();

            double[] seg = new double[6];
            int segNum = 0;
            int startIndex = 0;
            int endIndex = 0;

            while(segNum < pi.SubpathCount)
            {
               
               pi.NextMarker(out startIndex, out endIndex);
               int type = 0;

               switch (type)
               {
                  case (int)PathPointType.Line:

                     appendSegment(buffer, formatter, seg, 2, "l");
                     break;

                  case (int)PathPointType.Start:

                     appendSegment(buffer, formatter, seg, 2, "m");
                     break;

                  //case (int)PathPointType.Bezier3:
                  //   appendSegment(buffer, formatter, seg, 6, "c");
                  //   break;

                  case (int)PathPointType.Bezier:

                     appendSegment(buffer, formatter, seg, 4, "re");
                     break;

                  case (int)PathPointType.CloseSubpath:

                     buffer.Append("h");
                     break;

                  default:
                     // Should not appear!
                     break;
               }
               segNum++;
            }
         }

         return buffer.ToString();
      }


	   /// <summary>
	   /// Append Segement
	   /// </summary>
	   /// <param name="buffer"></param>
	   /// <param name="formatter"></param>
	   /// <param name="seg"></param>
	   /// <param name="nLength"></param>
	   /// <param name="strOrder"></param>
      private void appendSegment(StringBuilder buffer, SupportClass.TextNumberFormat formatter, double[] seg, int nLength, string strOrder)
      {
         for (int i = 0; i < nLength; i++)
         {
            buffer.Append(formatter.FormatDouble(seg[i]));
            buffer.Append(JDFConstants.BLANK);
         }
         buffer.Append(strOrder);
         buffer.Append(JDFConstants.BLANK);
      }

               
	   /// <summary>
	   /// Gets a formatter that is independend from any locale ( hopefully ).
	   /// </summary>
	   /// <returns>The formatter for the conversion of double to string.</returns>
      private SupportClass.TextNumberFormat getFormatter()
      {
         //DecimalFormatSymbols symbols = new DecimalFormatSymbols(Locale.US);
         System.Globalization.NumberFormatInfo symbols = new System.Globalization.CultureInfo("en-US").NumberFormat;
         symbols.NumberDecimalSeparator = "."; // only to be 100% sure!
         symbols.NumberGroupSeparator = ","; // only to be 100% sure!

         // const string pattern = "###.######"; // A size of 6 for the mantissa
         // should be enough
         // DecimalFormat formatter = new DecimalFormat(pattern, symbols);
         SupportClass.TextNumberFormat formatter = new SupportClass.TextNumberFormat();

         return formatter;
      }
   }
}
