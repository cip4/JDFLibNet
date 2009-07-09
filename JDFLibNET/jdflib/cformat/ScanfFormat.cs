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
 * Copyright John E. Lloyd, 2000. All rights reserved. Permission
 * to use, copy, and modify, without fee, is granted for non-commercial
 * and research purposes, provided that this copyright notice appears
 * in all copies.
 *
 * This  software is distributed "as is", without any warranty, including
 * any implied warranty of merchantability or fitness for a particular
 * use. The authors assume no responsibility for, and shall not be liable
 * for, any special, indirect, or consequential damages, or any damages
 * whatsoever, arising out of or in connection with the use of this
 * software.
 */

namespace org.cip4.jdflib.cformat
{
   using System;


   ///
   /// <summary> * Format object for scanning input in the same way as the C <tt>scanf</tt> methodName.
   /// * 
   /// * <p>
   /// * A <tt>scanf</tt> style format string is specified in the constructor. Once instantiated, objects of this class may be
   /// * passed as arguments to the <tt>scan</tt> methods of the <tt>ScanfReader</tt> class.
   /// *  </summary>
   /// * <seealso cref= ScanfReader
   /// * @.author John E. Lloyd </seealso>
   /// 
   public class ScanfFormat
   {
      // ~ Static fields/initializers

      private static string validTypes = "dioxfsc[";

      // ~ Instance fields

      public string cmatch;
      public string prefix;
      public string suffix;
      public int type;
      public int width;

      // ~ Constructors

      ///   
      ///	 <summary> * Constructs a ScanfFormat class from a format string. The structure of the format string is described in the
      ///	 * documentation for the <tt>set</tt> method.
      ///	 *  </summary>
      ///	 * <param name="fmt"> Format string </param>
      ///	 * <exception cref="IllegalArgumentException"> Malformed format string </exception>
      ///	 * <seealso cref= ScanfReader </seealso>
      ///	 
      public ScanfFormat(string fmt)
      {
         @set(fmt);
      }

      // ~ Methods

      ///
      ///      <summary> * Sets the contents of the object according to
      ///      * the information provided in the format string.
      ///      *
      ///      *
      ///      * <p>
      ///      * The format string describes what input to expect for a
      ///      * ScanfReader, and its form closely matches that for the C
      ///      * <tt>scanf</tt> methodName, expect that multiple conversions
      ///      * cannot be specified.
      ///      *
      ///      * <p>
      ///      * A conversion sequence is introduced by the '%' character; valid
      ///      * conversion sequences are described below. Other characters may
      ///      * appear in the format string. A white space character requests
      ///      * a match of any amount of white space, including none. Other
      ///      * characters request an exact match of themselves. The character
      ///      * sequence "%%" requests a match of the '%' character.
      ///      *
      ///      * <p>
      ///      * The '%' character introducing a conversion sequence
      ///      * may be followed by an unsigned decimal integer
      ///      * indicating the field width, which is the maximum number of
      ///      * characters used for a particular conversion. Field widths must
      ///      * be greater than 0.
      ///      *
      ///      * <p>
      ///      * The optional field width is followed by one of the following
      ///      * <em>conversion characters</em>, which specifies the primitive
      ///      * type to be scanned:
      ///      *
      ///      * <dl>
      ///      * <dt> f
      ///      * <dd> floating point (double).
      ///      * <dt> d
      ///      * <dd> signed decimal integer (long or int).
      ///      * <dt> o
      ///      * <dd> unsigned octal integer (long or int), formed from the digits
      ///      * [0-7].
      ///      * <dt> x
      ///      * <dd> unsigned hex integer (long or int), formed from the
      ///      * characters [0-9a-fA-F].
      ///      * <dt> i
      ///      * <dd> signed integer (long or int). If the digit sequence
      ///      * begins with "<tt>0x</tt>", then a hex value is scanned; if
      ///      * the digit sequence begins with "<tt>0</tt>", then an octal
      ///      * value is scanned; and otherwise a decimal value is scanned.
      ///      * <dt> c
      ///      * <dd> character (char).
      ///      * <dt> [
      ///      * <dd> matches any character in the sequence specified between
      ///      * the '[' and a closing ']', unless the first character in the
      ///      * sequence is a '^', in which case any character is matched which
      ///      * does <em>not</em> appear in the following sequence. To include
      ///      * ']' in the sequence, it should be placed immediately after the
      ///      * initial '[' or '[^'. The character '-' is also special; if it
      ///      * appears between any two characters in the sequence, then all
      ///      * characters within the numeric range specified by the two
      ///      * characters are implicitly incorported into the sequence.
      ///      * Consecutive '-' characters are not permitted in the sequence.
      ///      * A lone '-' character may be specified by placing it at the
      ///      * end of the sequence, before the closing ']'.
      ///      * <dt> s
      ///      * <dd> matches a string delimited by white space.
      ///      * </dl>
      ///      * </summary>
      ///      * <param name="fmt">        Format string </param>
      ///      * <exception cref="IllegalArgumentException"> Malformed format string </exception>
      ///      * <seealso cref= ScanfReader </seealso>
      ///      
      public virtual void @set(string fmt)
      {
         type = -1;
         width = -1;
         prefix = null;
         suffix = null;
         cmatch = null;

         char[] buf = new char[fmt.Length];
         int i;
         int n;
         int c = 0;

         if (fmt.Length == 0)
         {
            return;
         }

         n = 0;

         for (i = 0; i < fmt.Length; i++)
         {
            if ((c = fmt[i]) == '%')
            {
               i++;

               if (i == fmt.Length)
               {
                  throw new ArgumentException("Format string terminates with '%'");
               }

               if ((c = fmt[i]) != '%')
               {
                  break;
               }
            }

            buf[n++] = (char)c;
         }

         if (n > 0)
         {
            prefix = new string(buf, 0, n);
         }

         if (i == fmt.Length)
         {
            return;
         }

         if (char.IsDigit((char)c))
         {
            int w = c - '0';

            for (i++; i < fmt.Length; i++)
            {
               if (char.IsDigit((char)(c = fmt[i])))
               {
                  w = ((w * 10) + c) - '0';
               }
               else
               {
                  break;
               }
            }

            if (i == fmt.Length)
            {
               throw new ArgumentException("Premature end of format string");
            }

            if (w == 0)
            {
               throw new ArgumentException("Zero field width specified");
            }

            width = w;
         }

         if (validTypes.IndexOf(Convert.ToChar(c)) == -1)
         {
            throw new ArgumentException("Illegal conversion character '" + (char)c + "'");
         }

         type = c;

         if (type == '[')
         {
            n = 0;

            // first scan the cmatch string ...
            for (i++; i < fmt.Length; i++)
            {
               if (((c = fmt[i]) == ']') && (n != 0) && !((buf[0] == '^') && (n == 1)))
               {
                  break;
               }

               buf[n++] = (char)c;
            }

            if (i == fmt.Length)
            {
               throw new ArgumentException("Premature end of format string");
            }

            // and now make sure it's legal ....
            for (int k = 0; k < n; k++)
            {
               if (buf[k] == '-')
               {
                  if ((k < (n - 1)) && (buf[k + 1] == '-'))
                  {
                     throw new ArgumentException("Misplaced '-' in character match spec '[" + new string(buf, 0, n) + "]'");
                  }
               }
            }

            cmatch = new string(buf, 0, n);
         }

         n = 0;

         for (i++; i < fmt.Length; i++)
         {
            if ((c = fmt[i]) == '%')
            {
               i++;

               if ((i < fmt.Length) && (fmt[i] == '%'))
               {
                  buf[n++] = '%';
               }
               else
               {
                  throw new ArgumentException("Extra '%' in format string");
               }
            }
            else
            {
               buf[n++] = (char)c;
            }
         }

         if (n > 0)
         {
            suffix = new string(buf, 0, n);
         }
      }

      ///   
      ///	 <summary> * Checks to see if a character matches the sequence specified by the character set cmatch.
      ///	 *  </summary>
      ///	 * <param name="c"> Character to test </param>
      ///	 * <returns> True if c is a member of the character set specified by the string cmatch (or not a member, if the string
      ///	 *         begins with a '^'). </returns>
      ///	 
      internal virtual bool matchChar(char c)
      {
         int i0 = 0;
         int len;
         bool negate = false;
         char c0;
         char c1;

         if (cmatch == null)
         {
            return false;
         }

         len = cmatch.Length;

         if (cmatch[0] == '^')
         {
            negate = true;
            i0 = 1;
         }

         for (int i = i0; i < len; i++)
         {
            c0 = cmatch[i];

            if ((i < (len - 2)) && (cmatch[i + 1] == '-'))
            {
               c1 = cmatch[i + 2];

               if (c0 < c1)
               {
                  if ((c0 <= c) && (c <= c1))
                  {
                     return !negate;
                  }
               }
               else
               {
                  if ((c1 <= c) && (c <= c0))
                  {
                     return !negate;
                  }
               }

               i++;
            }
            else
            {
               if (c == c0)
               {
                  return !negate;
               }
            }
         }

         return negate;
      }

      // ~ Inner Classes

      internal class Cmatch
      {
         internal char clower = '\0';
         internal char cupper = '\0';
      }
   }
}
