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
   using System.Globalization;
   using System.Text;

   using StringUtil = org.cip4.jdflib.util.StringUtil;

   ///
   /// <summary> * Object for formatting output in the same way as the C <tt>printf</tt> methodName.
   /// * 
   /// * <p>
   /// * A <tt>printf</tt> style format string is specified in the constructor. Once instantiated, the <tt>tostr</tt> methods
   /// * of this class may be used to convert primitives types (float, double, char, int, long, String) into Strings.
   /// * Alternatively, instances of this class may be passed as arguments to the <tt>printf</tt> methods of the
   /// * <tt>PrintfWriter</tt> or <tt>PrintfStream</tt> classes.
   /// * 
   /// * <p>
   /// * Examples:
   /// * 
   /// * <pre>
   /// * double theta1 = 45.0;
   /// * double theta2 = 85.0;
   /// * PrintfFormat fmt = new PrintfFormat(&quot;%7.2f\n&quot;);
   /// * System.out.println(&quot;theta1=&quot; + fmt.tostr(theta1) + &quot;theta2=&quot; + fmt.tostr(theta2));
   /// * PrintfStream pfw = new PrintfStream(System.out, true);
   /// * pfw.print(&quot;theta1=&quot;);
   /// * pfw.printf(fmt, theta1);
   /// * pfw.print(&quot;theta2=&quot;);
   /// * pfw.printf(fmt, theta2);
   /// * </pre>
   /// *  </summary>
   /// * <seealso cref= PrintfWriter </seealso>
   /// * <seealso cref= PrintfStream
   /// * @.author John E. Lloyd </seealso>
   /// 
   public class PrintfFormat
   {
      // ~ Static fields/initializers

      private static char[] ddigits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
      private static char[] xdigits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
      private static char[] Xdigits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

      // ~ Instance fields

      public bool addBlank = false;
      public bool addSign = false;
      public bool alternate = false;
      public bool leftAdjust = false;
      public int prec = -1;

      public string prefix = null;
      public string suffix = null;
      public char type = '\0';
      public int width = 0;
      public bool zeropad = false;
      private DecDouble dd;
      private int idx;
      private readonly OutBuffer output;
      private readonly string validTypes = "diouxXeEfFgGaAcs";

      // ~ Constructors

      ///   
      ///	 <summary> * Creates a new instance of PrintfFormat from the supplied format string. The structure of the format string is
      ///	 * described in the documentation for the <tt>set</tt> method.
      ///	 *  </summary>
      ///	 * <param name="fmt"> Format string </param>
      ///	 * <exception cref="IllegalArgumentException"> Malformed format string </exception>
      ///	 * <seealso cref= PrintfFormat#set </seealso>
      ///	 
      public PrintfFormat(string fmt)
      {
         output = new OutBuffer(1024);
         @set(fmt);
      }

      // ~ Methods

      ///   
      ///	 <summary> * Gets the prefix string associated with the format. The prefix string is that part of the format that appears
      ///	 * before the conversion.
      ///	 *  </summary>
      ///	 * <returns> Prefix string </returns>
      ///	 * <seealso cref= PrintfFormat#setPrefix </seealso>
      ///	 
      public virtual string getPrefix()
      {
         return prefix;
      }

      ///   
      ///	 <summary> * Gets the suffix string associated with the format. The suffix string is that part of the format that appears
      ///	 * after the conversion.
      ///	 *  </summary>
      ///	 * <returns> Suffix string </returns>
      ///	 * <seealso cref= PrintfFormat#setSuffix </seealso>
      ///	 
      public virtual string getSuffix()
      {
         return suffix;
      }

      ///
      ///     <summary> * Sets the format characteristics according to the supplied
      ///     * String.
      ///     *
      ///     * <p>
      ///     * The format string has the same form as the one used by the C
      ///     * <tt>printf</tt> methodName, except that only one conversion
      ///     * sequence may be specified (because routines which
      ///     * use PrintfFormat each convert only one object).
      ///     *
      ///     * <p>
      ///     * The format string consists of an optional <em>prefix</em>
      ///     * of regular characters, followed by a conversion sequence,
      ///     * followed by an optional <em>suffix</em> of regular characters.
      ///     *
      ///     * <p>
      ///     * The conversion sequence is introduced by a '%' character, and
      ///     * is followed by any number of optional <em>flag</em> characters,
      ///     * an optional unsigned decimal integer specifying a <em>field
      ///     * width</em>, another optional unsigned decimal integer (preceded
      ///     * by a '.' character) specifying a <em>precision</em>, and
      ///     * finally a <tt>conversion character</tt>. To incorporate
      ///     * a '%' character into either the prefix or suffix, one should
      ///     * specify the sequence "%%".
      ///     *
      ///     * The allowed flag characters are:
      ///     *
      ///     * <dl>
      ///     * <dt> #
      ///     * <dd> The value is converted into an "alternate" form.
      ///     *      For 'o' conversions, the output is always prefixed with a
      ///     *      '0'. For 'x' and 'X' conversions, the output is prefixed
      ///     *      with "0x" or "0X", respectively. For 'a', 'A', 'e', 'E',
      ///     *      'f', 'g', and 'G' conversions, the result will always
      ///     *      contain a decimal point. For 'g' and 'G' conversions,
      ///     *      trailing zeros are not removed. There is no effect for
      ///     *      other conversions.
      ///     * <dt> 0
      ///     * <dd> Use '0' to pad the field on the left, instead of blanks.
      ///     *      If the conversion is 'd', 'i', 'o', 'u', 'x', or 'X',
      ///     *      and a precision is given, then this flag is ignored.
      ///     * <dt> -
      ///     * <dd> The output is aligned with the left of the field
      ///     *      boundary, and padded on the right with blanks.
      ///     *      This flag overrides the '0' flag.
      ///     * <dt> ' '
      ///     * <dd> Leave a blank before a positive number produced by a
      ///     *      signed conversion.
      ///     * <dt> +
      ///     * <dd> A '+' sign is placed before non-negative numbers produced
      ///     *      by a signed conversion. This flag overrides the ' ' flag.
      ///     * </dl>
      ///     * <p>
      ///     * The conversion character is one of:
      ///     *
      ///     * <dt> d,i
      ///     * <dd> The integer argument is output as a signed decimal number.
      ///     *      If a precision is given, it describes the minimum number
      ///     *      of digits that must appear (default 1). If the precision
      ///     *      exceeds the number of digits that would normally appear,
      ///     *      the output is padded on the left with zeros. When 0 is
      ///     *      printed with precision 0, the result is empty.
      ///     * <dt> o,u,x,X
      ///     * <dd> The integer argument is output as an unsigned number in
      ///     *      either octal ('o'), decimal ('u'), or hexadecimal ('x' or
      ///     *      'X'). The digits "abcdef" are used for 'x', and "ABCDEF"
      ///     *      are used for 'X'. If a precision is given, it describes
      ///     *      the minimum number of digits that must appear (default 1).
      ///     *      If the precision exceeds the number of digits that would
      ///     *      normally appear, the output is padded on the left with
      ///     *      zeros. When 0 is printed with precision 0, the result is
      ///     *      empty.
      ///     * <dt> e,E
      ///     * <dd> The floating point argument is output in the exponential
      ///     *      form <tt>[-]d.ddde+dd</tt>, with the number of digits
      ///     *      after the decimal point given by the precision. The
      ///     *      default precision value is 6. No decimal point is output
      ///     *      if the precision is 0. Conversion 'E' causes 'E' to be
      ///     *      used as an exponent instead of 'e'. The exponent is
      ///     *      always at least two characters.
      ///     * <dt> f
      ///     * <dd> The floating point argument is output in the form
      ///     *      <tt>[-]ddd.ddd</tt>, with the number of digits
      ///     *      after the decimal point given by the precision. The
      ///     *      default precision value is 6. No decimal point is output
      ///     *      if the precision is 0. If a decimal point appears, at
      ///     *      least one digit appears before it.
      ///     * <dt> g,G
      ///     * <dd> The floating point argument is output in either the 'f'
      ///     *      or 'e' style (or 'E' style of 'G' conversions). The
      ///     *      precision gives the number of significant digits, with a
      ///     *      default value of 6. Style 'e' is used if the resulting
      ///     *      exponent is less than -4 or greater than or equal to the
      ///     *      precision. Trailing zeros are removed from the fractional
      ///     *      part of the result, and a decimal point appears if it is
      ///     *      followed by at least one digit.
      ///     * <dt> a,A
      ///     * <dd> The floating point argument is output in the hexadecimal
      ///     *      floating point form <tt>[-]0xh.hhhp+dd</tt>. The
      ///     *      exponent is a decimal number and describes a power of 2.
      ///     *      The 'A' style uses the prefix "0X", the hex digits
      ///     *      "ABCDEF", and the exponent character 'P'. The number of
      ///     *      digits after the decimal point is given by the precision.
      ///     *      The default precision is enough for an exact
      ///     *      representation of the value.
      ///     * <dt> c
      ///     * <dd> The single character argument is output as a character.
      ///     * <dt> s
      ///     * <dd> The string argument is output. If a precision is given,
      ///     *      then the number of characters output is limited to this.
      ///     * </dl>
      ///     * </summary>
      ///     * <param name="fmt"> Format string </param>
      ///     * <exception cref="IllegalArgumentException"> Malformed format string </exception>
      ///     
      public virtual void @set(string fmt)
      {
         char[] buf = new char[fmt.Length];
         int n;
         char c;

         prefix = "";
         suffix = "";
         idx = 0;
         n = scanRegularChars(buf, fmt);

         if (n > 0)
         {
            prefix = new string(buf, 0, n);
         }

         if (idx == fmt.Length)
         {
            return;
         }

         // parse the flags
         bool parsingFlags = true;

         do
         {
            c = fmt[idx];

            switch (c)
            {
               case '+':
                  {
                     addSign = true;

                     break;
                  }

               case ' ':
                  {
                     addBlank = true;

                     break;
                  }

               case '-':
                  {
                     leftAdjust = true;

                     break;
                  }

               case '#':
                  {
                     alternate = true;

                     break;
                  }

               case '0':
                  {
                     zeropad = true;

                     break;
                  }

               default:
                  {
                     parsingFlags = false;

                     break;
                  }
            }

            if (parsingFlags)
            {
               if (++idx == fmt.Length)
               {
                  parsingFlags = false;
               }
            }
         }
         while (parsingFlags);

         if ((idx < fmt.Length) && char.IsDigit(fmt[idx]))
         {
            width = scanUnsignedInt(fmt);
         }

         if ((idx < fmt.Length) && (fmt[idx] == '.'))
         {
            if ((++idx < fmt.Length) && char.IsDigit(fmt[idx]))
            {
               prec = scanUnsignedInt(fmt);
            }
            else
            {
               throw new ArgumentException("'.' in conversion spec not followed by precision value");
            }
         }

         if (idx == fmt.Length)
         {
            throw new ArgumentException("Format string ends prematurely");
         }

         type = fmt[idx++];

         switch (type)
         {
            case 'd':
            case 'i':
            case 'o':
            case 'u':
            case 'x':
            case 'X':
               {
                  if ((prec != -1) && zeropad)
                  {
                     zeropad = false;
                  }

                  break;
               }

            case 'g':
            case 'G':
            case 'f':
            case 'e':
            case 'E':
            case 'a':
            case 'A':
               break;

            case 'c':
               break;

            case 's':
               break;

            default:
               {
                  if (validTypes.IndexOf(type) == -1)
                  {
                     throw new ArgumentException("Conversion character '" + type + "' not one of '" + validTypes + "'");
                  }

                  break;
               }
         }

         n = scanRegularChars(buf, fmt);

         if (n > 0)
         {
            suffix = new string(buf, 0, n);
         }

         if (idx != fmt.Length)
         {
            throw new ArgumentException("Format string has more than one conversion spec");
         }

         if (leftAdjust && zeropad)
         {
            zeropad = false;
         }

         if (addSign && addBlank)
         {
            addBlank = false;
         }
      }

      ///   
      ///	 <summary> * Sets the prefix string associated with the format.
      ///	 *  </summary>
      ///	 * <param name="s"> New prefix string </param>
      ///	 * <seealso cref= PrintfFormat#getPrefix </seealso>
      ///	 
      public virtual string setPrefix(string s)
      {
         string old = prefix;
         prefix = s;

         return old;
      }

      ///   
      ///	 <summary> * Sets the suffix string associated with the format.
      ///	 *  </summary>
      ///	 * <param name="s"> New suffix string </param>
      ///	 * <seealso cref= PrintfFormat#getSuffix </seealso>
      ///	 
      public virtual string setSuffix(string s)
      {
         string old = suffix;
         suffix = s;

         return old;
      }

      ///   
      ///	 <summary> * Formats a float into a string.
      ///	 *  </summary>
      ///	 * <param name="x"> Float value to convert </param>
      ///	 * <returns> Resulting string </returns>
      ///	 
      public virtual string tostr(float x)
      {
         return tostr((double)x);
      }



      ///   
      ///	 <summary> * Formats a double into a string.
      ///	 *  </summary>
      ///	 * <param name="x"> Double value to convert </param>
      ///	 * <returns> Resulting string </returns>
      ///	 
      public virtual string tostr(double x)
      {
         if ("diuoxX".IndexOf(type) > -1)
            return tostr((long)x);

         if (dd == null)
         {
            dd = new DecDouble();
         }

         if ((type != 'a') && (type != 'A'))
         {
            dd.set(x);
         }
         else
         {
            dd.setSignAndAlt(x);
         }

         char p = '\0';

         output.init(width + 1);

         if (dd.alt != null)
         {
            output.append(dd.alt);
         }
         else if (type == 'f')
         {
            fixedFormat(dd, (prec < 0) ? 6 : prec);
         }
         else if ((type == 'e') || (type == 'E'))
         {
            expFormat(dd, (prec < 0) ? 6 : prec);
         }
         else if ((type == 'a') || (type == 'A'))
         {
            expHexFormat(x, prec);
         }
         else if ((type == 'g') || (type == 'G'))
         {
            freeFormat(dd, (prec < 0) ? 6 : prec);
         }
         else
         {
            Console.Write("f = " + type);
            throw new ArgumentException();
         }

         if (dd.sign == -1)
         {
            p = '-';
         }
         else if (addSign)
         {
            p = '+';
         }
         else if (addBlank)
         {
            p = ' ';
         }

         if (zeropad)
         {
            int nz = width - (output.kn - output.k0);

            if (p != '\0')
            {
               nz--;
            }

            output.prepend('0', nz);
         }

         if (p != '\0')
         {
            output.prepend(p);
         }

         return pad();
      }

      ///   
      ///	 <summary> * Formats an int into a string.
      ///	 *  </summary>
      ///	 * <param name="x"> Int value to convert </param>
      ///	 * <returns> Resulting string </returns>
      ///	 
      public virtual string tostr(int x)
      {
         string intStr;

         long lx = x;

         if ((type == 'd') || (type == 'i'))
         {
            intStr = tostr(lx);
         }
         else
         { // unsigned; clear high bits
            intStr = tostr(lx & 0xffffffffL);
         }

         return intStr;
      }

      ///   
      ///	 <summary> * Formats a long into a string.
      ///	 *  </summary>
      ///	 * <param name="x"> Long value to convert </param>
      ///	 * <returns> Resulting string </returns>
      ///	 
      public virtual string tostr(long x)
      {
         long xLocal = x;

         string p = null;

         output.init(Math.Max(width, 32));

         if ((type == 'd') || (type == 'i'))
         {
            if (xLocal < 0)
            {
               xLocal = -xLocal;
               p = "-";
            }
            else
            {
               if (addSign)
               {
                  p = "+";
               }
               else if (addBlank)
               {
                  p = " ";
               }
            }

            if ((prec != 0) || (xLocal != 0))
            {
               output.append(Convert.ToString(xLocal, CultureInfo.InvariantCulture));
            }
         }
         else if (type == 'u')
         {
            uconv(xLocal, 10, ddigits);
         }
         else if (type == 'o')
         {
            uconv(xLocal, 8, ddigits);

            if (alternate && (output.buf[output.k0] != '0'))
            {
               p = "0";
            }
         }
         else if (type == 'x')
         {
            uconv(xLocal, 16, xdigits);

            if (alternate)
            {
               p = "0x";
            }
         }
         else if (type == 'X')
         {
            uconv(xLocal, 16, Xdigits);

            if (alternate)
            {
               p = "0X";
            }
         }
         else
         {
            throw new ArgumentException();
         }

         int nz = 0;

         if (zeropad)
         {
            nz = width - (output.kn - output.k0);
         }
         else if (prec > 0)
         {
            nz = prec - (output.kn - output.k0);
         }

         if (nz > 0)
         {
            if (p != null)
            {
               nz -= p.Length;
            }

            output.prepend('0', nz);
         }

         if (p != null)
         {
            output.prepend(p);
         }

         return pad();
      }

      ///   
      ///	 <summary> * Formats a char into a string.
      ///	 *  </summary>
      ///	 * <param name="x"> Char value to convert </param>
      ///	 * <returns> Resulting string </returns>
      ///	 
      public virtual string tostr(char x)
      {
         if (type != 'c')
         {
            throw new ArgumentException();
         }

         output.init(Math.Max(width, 1));
         output.append(Convert.ToString(x));

         return pad();
      }

      ///   
      ///	 <summary> * Formats a String into a string.
      ///	 *  </summary>
      ///	 * <param name="x"> String value to format </param>
      ///	 * <returns> Resulting string </returns>
      ///	 
      public virtual string tostr(string x)
      {
         if (type != 's')
         {
            if (StringUtil.isInteger(x))
               return tostr(StringUtil.parseInt(x, 0));
            if (StringUtil.isNumber(x))
               return tostr(StringUtil.parseDouble(x, 0));
            // no more choices, gotta go..
            throw new ArgumentException();
         }

         output.init(Math.Max(width, 1));

         if (prec >= 0)
         {
            output.append(x.Substring(0, prec));
         }
         else
         {
            output.append(x);
         }

         return pad();
      }

      // private void convert(long x, int n, int m, String d)
      // {
      // if (x == 0)
      // {
      // output.append('0');
      //
      // return;
      // }
      //
      // while (x != 0)
      // {
      // output.prepend(d.charAt((int) (x & m)));
      // x = x >>> n;
      // }
      // }

      private void expFormat(DecDouble pdd, int p)
      {
         int i;

         i = 0;
         output.append(pdd.digits[i++]);

         if ((p > 0) || alternate)
         {
            output.append('.');
         }

         if (p > 0)
         {
            int kend = p + output.k0 + 2;

            while ((i < pdd.numd) && (output.kn < kend))
            {
               output.append(pdd.digits[i++]);
            }

            if ((i == pdd.numd) && (output.kn < kend) && (((type != 'g') && (type != 'G')) || alternate))
            {
               output.append('0', kend - output.kn);
            }
         }

         if ((i < pdd.numd) && (pdd.digits[i] >= '5'))
         {
            roundUpFixedOutput(output);

            if (output.buf[output.k0 + 1] == '0')
            {
               output.buf[output.k0 + 1] = '.';
               output.buf[output.k0 + 2] = '0';
               pdd.exp++;
               output.kn--;
            }
         }

         output.append(((type == 'G') || (type == 'E')) ? 'E' : 'e');
         output.append((pdd.exp >= 0) ? '+' : '-');

         string expStr = Convert.ToString(Math.Abs(pdd.exp), CultureInfo.InvariantCulture);

         if (expStr.Length < 2)
         {
            output.append('0');
         }

         output.append(expStr);
      }

      private void expHexFormat(double d, int p)
      {
         int pLocal = p;

         char[] digits = null;
         long bits;
         int e;
         long m;

         bits = SupportClass.doubleToLongBits(d);
         e = (int)((bits >> 52) & 0x7ffL);
         m = (e == 0) ? ((bits & 0xfffffffffffffL) << 1) : ((bits & 0xfffffffffffffL) | 0x10000000000000L);

         if (m == 0)
         {
            e = 0;
         }
         else
         {
            e -= 1023;
         }

         if (m != 0)
         {
            while ((m & 0x10000000000000L) == 0)
            {
               m = m << 1;
               e--;
            }
         }

         if ((pLocal > 0) && (pLocal < 13))
         { // then round up if necessary

            if ((0xf & (m >> (4 * (12 - pLocal)))) >= 8)
            {
               m += (1L << (4 * (13 - pLocal)));

               if ((m & 0x20000000000000L) != 0)
               {
                  m = m >> 1;
                  e++;
               }
            }
         }

         output.append('0');

         if (type == 'A')
         {
            output.append('X');
            digits = Xdigits;
         }
         else
         {
            output.append('x');
            digits = xdigits;
         }

         output.append(((m & 0x10000000000000L) != 0) ? '1' : '0');

         if ((pLocal > 0) || ((pLocal == -1) && (m != 0)) || alternate)
         {
            output.append('.');
         }

         while ((pLocal > 0) || ((pLocal == -1) && ((m & 0xfffffffffffffL) != 0)))
         {
            output.append(digits[(int)((m & 0xf000000000000L) >> 48)]);
            m = m << 4;

            if (pLocal > 0)
            {
               pLocal--;
            }
         }

         output.append((type == 'A') ? 'P' : 'p');
         output.append((e >= 0) ? '+' : '-');

         string expStr = Convert.ToString(Math.Abs(e), CultureInfo.InvariantCulture);
         output.append(expStr);
      }

      private void fixedFormat(DecDouble pdd, int p)
      {
         int kend;
         bool freeFormat = ((type == 'g') || (type == 'G'));

         int i = 0;

         if (pdd.exp >= 0)
         {
            while ((output.kn <= (output.k0 + pdd.exp)) && (i < pdd.numd))
            {
               output.append(pdd.digits[i++]);
            }

            if (output.kn <= (output.k0 + pdd.exp))
            {
               output.append('0', (output.k0 + 1 + pdd.exp) - output.kn);
            }
         }
         else
         {
            output.append('0');
         }

         if (((p > 0) && (!freeFormat || (i < pdd.numd))) || alternate)
         {
            output.append('.');
         }

         if (p > 0)
         {
            kend = output.kn + p;

            // pad if needed
            if (pdd.exp < -1)
            {
               output.append('0', Math.Min(p, -pdd.exp - 1));
            }

            while ((output.kn < kend) && (i < pdd.numd))
            {
               output.append(pdd.digits[i++]);
            }

            if ((output.kn < kend) && (!freeFormat || alternate))
            {
               output.append('0', kend - output.kn);
            }
         }

         if ((i < pdd.numd) && (pdd.digits[i] >= '5'))
         {
            roundUpFixedOutput(output);
         }
      }

      private void freeFormat(DecDouble pdd, int pprec)
      {
         int p = Math.Max(1, pprec);

         if ((pdd.exp >= -4) && (pdd.exp < p))
         {
            fixedFormat(pdd, p - pdd.exp - 1);
         }
         else
         {
            expFormat(pdd, p - 1);
         }
      }

      private string pad()
      {
         int padcnt = width - (output.kn - output.k0);

         if (leftAdjust)
         {
            output.append(' ', padcnt);
         }
         else
         {
            output.prepend(' ', padcnt);
         }

         return prefix + output.getString() + suffix;
      }

      private void roundUpFixedOutput(OutBuffer @out)
      {
         int i;

         for (i = @out.kn - 1; i >= @out.k0; i--)
         {
            if (@out.buf[i] == '9')
            {
               @out.buf[i] = '0';

               // carry by continuing
            }
            else if (@out.buf[i] != '.')
            {
               @out.buf[i]++; // += 1;

               break;
            }
         }

         if (i < @out.k0)
         {
            @out.buf[--@out.k0] = '1';
         }
      }

      private int scanRegularChars(char[] buf, string fmt)
      {
         int n = 0;
         char c;

         for (; idx < fmt.Length; idx++)
         {
            if ((c = fmt[idx]) == '%')
            {
               idx++;

               if (idx == fmt.Length)
               {
                  throw new ArgumentException("Format string terminates with '%'");
               }

               if ((c = fmt[idx]) != '%')
               {
                  break;
               }
            }

            buf[n++] = c;
         }

         return n;
      }

      private int scanUnsignedInt(string fmt)
      {
         int @value = 0;
         char c;

         for (c = fmt[idx]; char.IsDigit(c); c = fmt[idx])
         {
            @value = ((10 * @value) + c) - '0';

            if (++idx == fmt.Length)
            {
               break;
            }
         }

         return @value;
      }

      private void uconv(long val, int radix, char[] digits)
      {
         long valLocal = val;

         if (valLocal == 0)
         {
            if (prec != 0)
            {
               output.append('0');
            }

            return;
         }

         if (valLocal < 0)
         { // have to compute the first val/radix and val%radix in a
            // complicated way

            long halfval;
            int mod;

            halfval = valLocal >> 1;
            mod = (int)((2 * (halfval % radix)) + (valLocal & 0x1));
            valLocal = 2 * (halfval / radix);

            if (mod >= radix)
            {
               mod -= radix;
               valLocal += 1;
            }

            output.prepend(digits[mod]);
         }

         while (valLocal != 0)
         {
            output.prepend(digits[(int)(valLocal % radix)]);
            valLocal /= radix;
         }
      }

      // ~ Inner Classes

      ///   
      ///	 <summary> * Stores the decimal representation of a double. Provides a canonical form from which the rest of the formatting is
      ///	 * easy. We let the java Double.toString() method do most of the work in creating the representation. </summary>
      ///	 
      private class DecDouble
      {
         internal string alt = null;
         internal char[] digits = null;
         internal int exp = 0; // exponent if decimal follows 1st digit
         internal int numd = 0;
         internal int sign = 1;

         internal DecDouble()
         {
            init();
            @set(0);
         }

         internal DecDouble(double d)
         {
            init();
            @set(d);
         }

         internal virtual void @set(double d)
         {
            double dLocal = d;

            numd = 0;
            exp = 0;

            setSignAndAlt(dLocal);

            if (alt != null)
            {
               return;
            }
            else if (dLocal == 0)
            {
               digits[0] = '0';
               numd = 1;
            }
            else
            {
               if (dLocal < 0)
               {
                  dLocal = -dLocal;
               }

               string s = Convert.ToString(dLocal, CultureInfo.InvariantCulture);

               int k;
               int len;
               int idec;
               char c;

               len = s.Length;

               // skip leading 0's and look for dec point:
               idec = -1;

               for (k = 0; k < len; k++)
               {
                  if ((c = s[k]) == '.')
                  {
                     idec = k;
                  }
                  else if (c != '0')
                  {
                     break;
                  }
               }

               // now store digits
               numd = 0;

               for (; k < len; k++)
               {
                  if ((c = s[k]) == '.')
                  {
                     idec = k;
                  }
                  else if ((c == 'e') || (c == 'E'))
                  {
                     break;
                  }
                  else
                  {
                     digits[numd++] = c;
                  }
               }

               if (k < len) // then there is an exponent
               {
                  exp = Int32.Parse(s.Substring(k + 1), CultureInfo.InvariantCulture);
               }
               else
               {
                  exp = 0;
               }

               // adjust exp so decimal follows the leading digit
               if (idec == -1) // no decimal in orig. string
               {
                  exp += (numd - 1);
               }
               else
               {
                  exp += (idec - (k - numd));
               }
            }
         }

         internal virtual void setSignAndAlt(double d)
         {
            alt = null;
            sign = 1;

            if (double.IsNaN(d))
            {
               alt = "nan";
            }
            else if (d == double.PositiveInfinity)
            {
               alt = "inf";
            }
            else if (d == double.NegativeInfinity)
            {
               alt = "inf";
               sign = -1;
            }
            else if (d == 0)
            {
               if (((ulong)SupportClass.doubleToLongBits(d) & 0x8000000000000000L) == 0)
               {
                  sign = 1;
               }
               else
               {
                  sign = -1;
               }
            }
            else if (d < 0)
            {
               sign = -1;
            }
         }

         private void init()
         {
            digits = new char[256];
            numd = 0;
         }
      }

      ///   
      ///	 <summary> * OutBuffer is used to form the output character sequence. We defined this because it makes things a little faster
      ///	 * than working with strings. </summary>
      ///	 
      private class OutBuffer
      {
         internal char[] buf;
         internal int k0;
         internal int kn;

         internal OutBuffer(int n)
         {
            buf = new char[n];
            kn = k0 = 0;
         }

         internal void append(char c)
         {
            buf[kn++] = c;
         }

         internal int append(string s)
         {
            for (int i = 0; i < s.Length; i++)
            {
               buf[kn++] = s[i];
            }

            return kn;
         }

         internal int append(char c, int n)
         {
            int nLocal = n;

            while (nLocal-- > 0)
            {
               buf[kn++] = c;
            }

            return kn;
         }

         internal string getString()
         {
            //return String.valueOf(buf, k0, kn - k0);
            StringBuilder sb = new StringBuilder(kn - k0);
            sb.Append(buf, k0, kn - k0);
            return sb.ToString();

         }

         internal void init(int @base)
         {
            kn = k0 = @base;
         }

         internal void prepend(char c)
         {
            buf[--k0] = c;
         }

         internal int prepend(string s)
         {
            for (int i = s.Length - 1; i >= 0; i--)
            {
               buf[--k0] = s[i];
            }

            return k0;
         }

         internal int prepend(char c, int n)
         {
            int nLocal = n;

            while (nLocal-- > 0)
            {
               buf[--k0] = c;
            }

            return k0;
         }
      }
   }
}
