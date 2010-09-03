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
   using System.IO;


   ///
   /// <summary> * A Reader which implements C <tt>scanf</tt> functionality. Once created, an application can read various primitive
   /// * types from the underlying stream using various <tt>scan</tt> methods that implement <tt>scanf</tt> type input
   /// * formatting.
   /// * 
   /// * <p>
   /// * There are scan methods to read float, double, long, int, char, char[], and String. The methods take as an argument
   /// * either a format string, a pre-allocated <tt>ScanfFormat</tt> object which is created from a format string, or no
   /// * argument (implying a default format). The format string is modeled after that accepted by the C <tt>scanf()</tt>
   /// * methodName, and is described in the documentation for the class <tt>ScanfFormat</tt>.
   /// * 
   /// * <p>
   /// * Because Java does not permit variable-length argument lists, only one primitive type may be returned per method, and
   /// * the format used may contain only one conversion specification (which must be appropriate to the type being scanned).
   /// * 
   /// * <p>
   /// * Input errors in the underlying Reader result in a <tt>java.io.IOException</tt> being thrown, while a
   /// * <tt>java.io.EOFException</tt> is thrown if the end of input is reached before the scan can complete successfully. If
   /// * the input does not match the specified format, then a <tt>ScanfMatchException</tt> is thrown. In the event of a match
   /// * error, scanning stops at the first character from which it can be determined that the match will fail. This character
   /// * is remembered by the stream (see the discussion of the look-ahead character, below) and will be the first character
   /// * seen by the next <tt>scan</tt> or <tt>read</tt> method which is called. Finally, an invalid format string (or
   /// * <tt>ScanfFormat</tt> object) will trigger an <tt>InvalidArgumentException</tt>.
   /// * 
   /// * <p>
   /// * The class keeps track of the current line number (accessible with the methods <tt>getLineNumber</tt> and
   /// * <tt>setLineNumber</tt>), as well as the number of characters which have been consumed (accesible with the methods
   /// * <tt>getCharNumber</tt> and <tt>setCharNumber</tt>).
   /// * 
   /// * <p>
   /// * The class usually keeps one character of look-ahead which has been read from the underlying reader but not yet
   /// * consumed by any scan method. If the underlying reader is used later in some other capacity, this look-ahead character
   /// * may have to be taken into account. If a look-ahead character is actually being stored, the
   /// * <tt>lookAheadCharValid</tt> method will return <tt>true</tt>, and the look-ahead character itself can then be
   /// * obtained using the <tt>getLookAheadChar</tt> method. The look-ahead character can be cleared using the
   /// * <tt>clearLookAheadChar</tt> method. </summary>
   /// 
   public class ScanfReader : StreamReader
   {
      // ~ Static fields/initializers

      private static string hexChars = "0123456789abcdefABCDEF";
      private static string octChars = "01234567";
      private const int BUFSIZE = 1024;
      private static ScanfFormat defaultDoubleFmt = new ScanfFormat("%f");
      private static ScanfFormat defaultIntFmt = new ScanfFormat("%i");
      private static ScanfFormat defaultDecFmt = new ScanfFormat("%d");
      private static ScanfFormat defaultHexFmt = new ScanfFormat("%x");
      private static ScanfFormat defaultOctFmt = new ScanfFormat("%o");
      private static ScanfFormat defaultStringFmt = new ScanfFormat("%s");
      private static ScanfFormat defaultCharFmt = new ScanfFormat("%c");

      // ~ Instance fields

      private int bcnt;
      private readonly char[] buffer;
      private int charCnt = 0;
      private int curChar;
      private bool curCharValid = false;
      private int lastChar;
      private int lineCnt = 1;

      private StringReader reader = null;
      private bool spacesCStandardFlag = true;

      // ~ Constructors

      ///   
      ///	 <summary> * Create a new ScanfReader from the given reader.
      ///	 *  </summary>
      ///	 * <param name="reader"> Underlying Reader </param>
      ///	 
      public ScanfReader(StringReader @in)
         : base(new MemoryStream())
      {
         reader = @in;
         curCharValid = false;
         charCnt = 0;
         lineCnt = 1;
         curChar = 0;
         lastChar = 0;

         // XXX XXX XXX fixed size buffer is a big hack
         buffer = new char[BUFSIZE];
         bcnt = 0;
      }

      // ~ Methods

      ///   
      ///	 <summary> * Clears the look-ahead character. </summary>
      ///	 
      public virtual void clearLookAheadChar()
      {
         curCharValid = false;
      }

      ///   
      ///	 <summary> * Closes the stream.
      ///	 *  </summary>
      ///	 * <exception cref="IOException"> An I/O error occurred </exception>
      ///	 
      public override void Close()
      {
         reader.Close();
      }

      ///   
      ///	 <summary> * Gets the current character number (equal to the number of characters that have been consumed by the stream).
      ///	 *  </summary>
      ///	 * <returns> Current character number </returns>
      ///	 * <seealso cref= ScanfReader#setCharNumber </seealso>
      ///	 
      public virtual int getCharNumber()
      {
         return charCnt;
      }

      ///   
      ///	 <summary> * Gets the current line number. The initial value (when the Reader is created) is 1. A new line is recorded upon
      ///	 * reading a carriage return, a line feed, or a carriage return immediately followed by a line feed.
      ///	 *  </summary>
      ///	 * <returns> Current line number </returns>
      ///	 * <seealso cref= ScanfReader#setLineNumber </seealso>
      ///	 
      public virtual int getLineNumber()
      {
         return lineCnt;
      }

      ///   
      ///	 <summary> * Returns the look-ahead character.
      ///	 *  </summary>
      ///	 * <returns> Look-ahead character, -1 if EOF has been reached, or 0 if no look-ahead character is being stored. </returns>
      ///	 
      public virtual int getLookAheadChar()
      {
         int i = 0;

         if (curCharValid)
         {
            i = curChar;
         }

         return i;
      }

      ///   
      ///	 <summary> * Returns whether or not a look-ahead character is currently begin stored.
      ///	 *  </summary>
      ///	 * <returns> True if a look-ahead character is being stored. </returns>
      ///	 
      public virtual bool lookAheadCharValid()
      {
         return curCharValid;
      }

      ///   
      ///	 <summary> * Reads characters into a portion of a character array. The method will block until input is available, an I/O
      ///	 * error occurs, or the end of the stream is reached.
      ///	 *  </summary>
      ///	 * <param name="cbuf"> Buffer to write characters into </param>
      ///	 * <param name="off"> Offset to start writing at </param>
      ///	 * <param name="len"> Number of characters to read </param>
      ///	 * <returns> The number of characters read, or -1 if the end of the stream is reached. </returns>
      ///	 * <exception cref="IOException"> An I/O error occurred </exception>
      ///	 
      public override int Read(char[] cbuf, int off, int len)
      {
         int offLocal = off;
         int lenLocal = len;

         int n;
         int c;
         int n0 = 0;

         if (curCharValid)
         {
            consumeChar();

            if (curChar != -1)
            {
               cbuf[offLocal++] = (char)curChar;
               lenLocal--;
               n0 = 1;
            }
            else
            {
               return -1;
            }
         }

         if (lenLocal > 0)
         {
            n = reader.Read(cbuf, offLocal, lenLocal);
         }
         else
         {
            return n0;
         }

         if (n == -1)
         {
            return -1;
         }


         for (int i = 0; i < n; i++)
         {
            c = cbuf[offLocal + i];

            if ((c == '\r') || ((c == '\n') && (lastChar != '\r')))
            {
               lineCnt++;
            }

            lastChar = c;
         }

         charCnt += n;

         return n + n0;
      }

      ///   
      ///	 <summary> * Scan and return a single character, using the default format string "%c".
      ///	 *  </summary>
      ///	 * <param name="s"> Format string </param>
      ///	 * <returns> Scanned character </returns>
      ///	 * <exception cref="ScanfMatchException"> Input did not match format </exception>
      ///	 * <exception cref="java.io.EOFException"> End of file </exception>
      ///	 * <exception cref="java.io.IOException"> Other input error </exception>
      ///	 * <seealso cref= ScanfFormat </seealso>
      ///	 * <seealso cref= ScanfReader#scanChar(String) </seealso>
      ///	 
      public virtual char scanChar()
      {
         char val = '\0';

         try
         {
            val = scanChar(defaultCharFmt);
         }
         catch (ArgumentException e)
         {
            // can't happen
            SupportClass.WriteStackTrace(e, Console.Error);
         }

         return val;
      }

      ///   
      ///	 <summary> * Scan and return a single character.
      ///	 * 
      ///	 * <p>
      ///	 * The format string <tt>s</tt> must have the form described by the documentation for the class <tt>ScanfFormat</tt>
      ///	 * , and must contain the conversion character 'c' or '['. If the conversion character is '[', then each character
      ///	 * scanned must match the sequence specified between the '[' and the closing ']' (see the documentation for
      ///	 * <tt>ScanfFormat</tt>).
      ///	 * 
      ///	 * <p>
      ///	 * White space preceding the character is not skipped.
      ///	 *  </summary>
      ///	 * <param name="s"> Format string </param>
      ///	 * <returns> Scanned character </returns>
      ///	 * <exception cref="ScanfMatchException"> Input did not match format </exception>
      ///	 * <exception cref="IllegalArgumentException"> Error in format specification </exception>
      ///	 * <exception cref="java.io.EOFException"> End of file </exception>
      ///	 * <exception cref="java.io.IOException"> Other input error </exception>
      ///	 * <seealso cref= ScanfFormat </seealso>
      ///	 
      public virtual char scanChar(string s)
      {
         return scanChar(new ScanfFormat(s));
      }

      ///   
      ///	 <summary> * Scan and return a single character, using a pre-allocated <tt>ScanfFormat</tt> object. This saves the overhead of
      ///	 * parsing the format from a string.
      ///	 *  </summary>
      ///	 * <param name="fmt"> Format object </param>
      ///	 * <returns> Scanned character </returns>
      ///	 * <exception cref="ScanfMatchException"> Input did not match format </exception>
      ///	 * <exception cref="IllegalArgumentException"> Error in format specification </exception>
      ///	 * <exception cref="java.io.EOFException"> End of file </exception>
      ///	 * <exception cref="java.io.IOException"> Other input error </exception>
      ///	 * <seealso cref= ScanfFormat </seealso>
      ///	 * <seealso cref= ScanfReader#scanChar(String) </seealso>
      ///	 
      public virtual char scanChar(ScanfFormat fmt)
      {
         char @value = '\0';

         checkTypeAndScanPrefix(fmt, "c[");
         initChar();

         if (curChar == -1)
         {
            throw new EndOfStreamException("EOF");
         }

         @value = (char)curChar;

         if ((fmt.type == '[') && !fmt.matchChar(@value))
         {
            throw new ScanfMatchException("Input char '" + @value + "' does not match '[" + fmt.cmatch + "]'");
         }

         consumeAndReplaceChar();
         scanSuffix(fmt);

         return @value;
      }

      ///   
      ///	 <summary> * Scan and return a character array, whose size is determined by the field width specified in the format string
      ///	 * (with a default width of 1 being assumed if no width is specified).
      ///	 * 
      ///	 * <p>
      ///	 * The format string <tt>s</tt> must have the form described by the documentation for the class <tt>ScanfFormat</tt>
      ///	 * , and must contain the conversion characters 'c' or '['. If the conversion character is '[', then each character
      ///	 * scanned must match the sequence specified between the '[' and the closing ']' (see the documentation for
      ///	 * <tt>ScanfFormat</tt>).
      ///	 * 
      ///	 * <p>
      ///	 * White space preceding the character sequence is not skipped.
      ///	 *  </summary>
      ///	 * <param name="s"> Format string </param>
      ///	 * <returns> Scanned character array </returns>
      ///	 * <exception cref="ScanfMatchException"> Input did not match format </exception>
      ///	 * <exception cref="IllegalArgumentException"> Error in format specification </exception>
      ///	 * <exception cref="java.io.EOFException"> End of file </exception>
      ///	 * <exception cref="java.io.IOException"> Other input error </exception>
      ///	 * <seealso cref= ScanfFormat </seealso>
      ///	 
      public virtual char[] scanChars(string s)
      {
         return scanChars(new ScanfFormat(s));
      }

      ///   
      ///	 <summary> * Scan and return a character array, using the default format string "%c", with the field width (number of
      ///	 * characters to read) supplanted by the argument <tt>n</tt>.
      ///	 *  </summary>
      ///	 * <param name="n"> Number of characters to read </param>
      ///	 * <returns> Scanned character array </returns>
      ///	 * <exception cref="IllegalArgumentException"> <tt>n</tt> not a positive number </exception>
      ///	 * <exception cref="ScanfMatchException"> Input did not match format </exception>
      ///	 * <exception cref="java.io.EOFException"> End of file </exception>
      ///	 * <exception cref="java.io.IOException"> Other input error </exception>
      ///	 * <seealso cref= ScanfFormat </seealso>
      ///	 * <seealso cref= ScanfReader#scanChars(String) </seealso>
      ///	 
      public virtual char[] scanChars(int n)
      {
         if (n <= 0)
         {
            throw new ArgumentException("n is non-positive");
         }

         return scanChars(defaultCharFmt, n);
      }

      ///   
      ///	 <summary> * Scan and return a character array, using a pre-allocated <tt>ScanfFormat</tt> object. This saves the overhead of
      ///	 * parsing the format from a string.
      ///	 *  </summary>
      ///	 * <param name="fmt"> Format object </param>
      ///	 * <returns> Scanned character array </returns>
      ///	 * <exception cref="ScanfMatchException"> Input did not match format </exception>
      ///	 * <exception cref="IllegalArgumentException"> Error in format specification </exception>
      ///	 * <exception cref="java.io.EOFException"> End of file </exception>
      ///	 * <exception cref="java.io.IOException"> Other input error </exception>
      ///	 * <seealso cref= ScanfFormat </seealso>
      ///	 * <seealso cref= ScanfReader#scanChars(String) </seealso>
      ///	 
      public virtual char[] scanChars(ScanfFormat fmt)
      {
         return scanChars(fmt, fmt.width);
      }

      ///   
      ///	 <summary> * Scan and return a signed decimal (long) integer, using the default format string "%d".
      ///	 *  </summary>
      ///	 * <param name="s"> Format string </param>
      ///	 * <returns> Scanned integer </returns>
      ///	 * <exception cref="ScanfMatchException"> Input did not match format </exception>
      ///	 * <exception cref="java.io.EOFException"> End of file </exception>
      ///	 * <exception cref="java.io.IOException"> Other input error </exception>
      ///	 * <seealso cref= ScanfFormat </seealso>
      ///	 * <seealso cref= ScanfReader#scanDec(String) </seealso>
      ///	 
      public virtual long scanDec()
      {
         long val = 0;

         try
         {
            val = scanDec(defaultDecFmt, -1);
         }
         catch (ArgumentException e)
         {
            // can't happen
            SupportClass.WriteStackTrace(e, Console.Error);
         }

         return val;
      }

      ///   
      ///	 <summary> * Scan and return a signed decimal (long) integer.
      ///	 * 
      ///	 * <p>
      ///	 * The format string <tt>s</tt> must have the form described by the documentation for the class <tt>ScanfFormat</tt>
      ///	 * , and must contain the conversion character 'd'. The integer itself must consist of an optional sign ('+' or '-')
      ///	 * followed by a sequence of digits. White space preceding the number is skipped.
      ///	 *  </summary>
      ///	 * <param name="s"> Format string </param>
      ///	 * <returns> Scanned integer </returns>
      ///	 * <exception cref="ScanfMatchException"> Input did not match format </exception>
      ///	 * <exception cref="IllegalArgumentException"> Error in format specification </exception>
      ///	 * <exception cref="java.io.EOFException"> End of file </exception>
      ///	 * <exception cref="java.io.IOException"> Other input error </exception>
      ///	 * <seealso cref= ScanfFormat </seealso>
      ///	 
      public virtual long scanDec(string s)
      {
         return scanDec(new ScanfFormat(s));
      }

      ///   
      ///	 <summary> * Scan and return a signed decimal (long) integer, using a pre-allocated <tt>ScanfFormat</tt> object. This saves
      ///	 * the overhead of parsing the format from a string.
      ///	 *  </summary>
      ///	 * <param name="fmt"> Format object </param>
      ///	 * <returns> Scanned integer </returns>
      ///	 * <exception cref="ScanfMatchException"> Input did not match format </exception>
      ///	 * <exception cref="IllegalArgumentException"> Error in format specification </exception>
      ///	 * <exception cref="java.io.EOFException"> End of file </exception>
      ///	 * <exception cref="java.io.IOException"> Other input error </exception>
      ///	 * <seealso cref= ScanfFormat </seealso>
      ///	 * <seealso cref= ScanfReader#scanDec(String) </seealso>
      ///	 
      public virtual long scanDec(ScanfFormat fmt)
      {
         return scanDec(fmt, fmt.width);
      }

      ///   
      ///	 <summary> * Scan and return a double, using the default format string "%f".
      ///	 *  </summary>
      ///	 * <returns> Scanned double value </returns>
      ///	 * <exception cref="ScanfMatchException"> Input did not match format </exception>
      ///	 * <exception cref="java.io.EOFException"> End of file </exception>
      ///	 * <exception cref="java.io.IOException"> Other input error </exception>
      ///	 * <seealso cref= ScanfFormat </seealso>
      ///	 * <seealso cref= ScanfReader#scanDouble(String) </seealso>
      ///	 
      public virtual double scanDouble()
      {
         double val = 0;

         try
         {
            val = scanDouble(defaultDoubleFmt);
         }
         catch (ArgumentException e)
         {
            // can't happen
            SupportClass.WriteStackTrace(e, Console.Error);
         }

         return val;
      }

      ///   
      ///	 <summary> * Scan and return a double.
      ///	 * 
      ///	 * <p>
      ///	 * The format string <tt>s</tt> must have the form described by the documentation for the class <tt>ScanfFormat</tt>
      ///	 * , and must contain the conversion character 'f'. The number itself may consist of (a) an optional sign ('+' or
      ///	 * '-'), (b) a sequence of decimal digits, with an optional decimal point, (c) an optional exponent ('e' or 'E'),
      ///	 * which must by followed by an optionally signed sequence of decimal digits. White space immediately before the
      ///	 * number is skipped.
      ///	 *  </summary>
      ///	 * <param name="s"> Format string </param>
      ///	 * <returns> Scanned double value </returns>
      ///	 * <exception cref="ScanfMatchException"> Input did not match format </exception>
      ///	 * <exception cref="IllegalArgumentException"> Error in format specification </exception>
      ///	 * <exception cref="java.io.EOFException"> End of file </exception>
      ///	 * <exception cref="java.io.IOException"> Other input error </exception>
      ///	 * <seealso cref= ScanfFormat </seealso>
      ///	 
      public virtual double scanDouble(string s)
      {
         return scanDouble(new ScanfFormat(s));
      }

      ///   
      ///	 <summary> * Scan and return a double, using a pre-allocated <tt>ScanfFormat</tt> object. This saves the overhead of parsing
      ///	 * the format from a string.
      ///	 *  </summary>
      ///	 * <param name="fmt"> Format object </param>
      ///	 * <returns> Scanned double value </returns>
      ///	 * <exception cref="ScanfMatchException"> Input did not match format </exception>
      ///	 * <exception cref="IllegalArgumentException"> Error in format specification </exception>
      ///	 * <exception cref="java.io.EOFException"> End of file </exception>
      ///	 * <exception cref="java.io.IOException"> Other input error </exception>
      ///	 * <seealso cref= ScanfFormat </seealso>
      ///	 * <seealso cref= ScanfReader#scanDouble(String) </seealso>
      ///	 
      public virtual double scanDouble(ScanfFormat fmt)
      {
         // parse [-][0-9]*[.][0-9]*[eE][-][0-9]*
         bool hasDigits = false;

         double @value = 0;
         int w;

         checkTypeAndScanPrefix(fmt, "f");

         if (curChar == -1)
         {
            throw new EndOfStreamException("EOF");
         }

         bcnt = 0;
         w = ((fmt.width == -1) ? 1000000000 : fmt.width);

         if (spacesCStandardFlag)
         {
            skipWhiteSpace();
         }
         else
         {
            int skippedSpaces = skipWhiteSpace(w);
            w -= skippedSpaces;
         }

         if (acceptDigits(w))
         {
            hasDigits = true;
         }

         acceptChar('.', w);

         if (!hasDigits && ((bcnt == w) || !char.IsDigit((char)curChar)))
         {
            if (curCharValid && (curChar == -1))
            {
               throw new EndOfStreamException("EOF");
            }

            throw new ScanfMatchException("Malformed floating point number: no digits");
         }

         acceptDigits(w);

         if (acceptChar('e', w) || acceptChar('E', w))
         {
            if ((bcnt == w) || !char.IsDigit((char)curChar))
            {
               if (curCharValid && (curChar == -1))
               {
                  throw new EndOfStreamException("EOF");
               }

               throw new ScanfMatchException("Malformed floating point number: no digits in exponent");
            }

            acceptDigits(w);
         }

         try
         {
            @value = double.Parse(new string(buffer, 0, bcnt));
         }
         catch (FormatException)
         {
            throw new ScanfMatchException("Malformed floating point number");
         }

         scanSuffix(fmt);

         return @value;
      }

      ///   
      ///	 <summary> * Scan and return a float, using the default format string "%f".
      ///	 *  </summary>
      ///	 * <returns> Scanned float value </returns>
      ///	 * <exception cref="ScanfMatchException"> Input did not match format </exception>
      ///	 * <exception cref="java.io.EOFException"> End of file </exception>
      ///	 * <exception cref="java.io.IOException"> Other input error </exception>
      ///	 * <seealso cref= ScanfFormat </seealso>
      ///	 * <seealso cref= ScanfReader#scanDouble(String) </seealso>
      ///	 
      public virtual float scanFloat()
      {
         return (float)scanDouble();
      }

      ///   
      ///	 <summary> * Scan and return a float. The format string <tt>s</tt> takes the same form as that described in the documentation
      ///	 * for <tt>scanDouble(String)</tt>.
      ///	 *  </summary>
      ///	 * <param name="s"> Format string </param>
      ///	 * <returns> Scanned float value </returns>
      ///	 * <exception cref="ScanfMatchException"> Input did not match format </exception>
      ///	 * <exception cref="IllegalArgumentException"> Error in format specification </exception>
      ///	 * <exception cref="java.io.EOFException"> End of file </exception>
      ///	 * <exception cref="java.io.IOException"> Other input error </exception>
      ///	 * <seealso cref= ScanfFormat </seealso>
      ///	 * <seealso cref= ScanfReader#scanDouble(String) </seealso>
      ///	 
      public virtual float scanFloat(string s)
      {
         return (float)scanDouble(new ScanfFormat(s));
      }

      ///   
      ///	 <summary> * Scan and return a float, using a pre-allocated <tt>ScanfFormat</tt> object. This saves the overhead of parsing
      ///	 * the format from a string.
      ///	 *  </summary>
      ///	 * <param name="fmt"> Format object </param>
      ///	 * <returns> Scanned float value </returns>
      ///	 * <exception cref="ScanfMatchException"> Input did not match format </exception>
      ///	 * <exception cref="IllegalArgumentException"> Error in format specification </exception>
      ///	 * <exception cref="java.io.EOFException"> End of file </exception>
      ///	 * <exception cref="java.io.IOException"> Other input error </exception>
      ///	 * <seealso cref= ScanfFormat </seealso>
      ///	 * <seealso cref= ScanfReader#scanDouble(String) </seealso>
      ///	 
      public virtual float scanFloat(ScanfFormat fmt)
      {
         return (float)scanDouble(fmt);
      }

      ///   
      ///	 <summary> * Scan and return a hex (long) integer, using the default format string "%x".
      ///	 *  </summary>
      ///	 * <param name="s"> Format string </param>
      ///	 * <returns> Scanned integer </returns>
      ///	 * <exception cref="ScanfMatchException"> Input did not match format </exception>
      ///	 * <exception cref="java.io.EOFException"> End of file </exception>
      ///	 * <exception cref="java.io.IOException"> Other input error </exception>
      ///	 * <seealso cref= ScanfFormat </seealso>
      ///	 * <seealso cref= ScanfReader#scanHex(String) </seealso>
      ///	 
      public virtual long scanHex()
      {
         long val = 0;

         try
         {
            val = scanHex(defaultHexFmt, -1);
         }
         catch (ArgumentException e)
         {
            // can't happen
            SupportClass.WriteStackTrace(e, Console.Error);
         }

         return val;
      }

      ///   
      ///	 <summary> * Scan and return a hex (long) integer.
      ///	 * 
      ///	 * <p>
      ///	 * The format string <tt>s</tt> must have the form described by the documentation for the class <tt>ScanfFormat</tt>
      ///	 * , and must contain the conversion character 'x'. The integer itself must be formed from the characters
      ///	 * [0-9a-fA-F], and white space which immediately precedes it is skipped.
      ///	 *  </summary>
      ///	 * <param name="s"> Format string </param>
      ///	 * <returns> Scanned integer </returns>
      ///	 * <exception cref="ScanfMatchException"> Input did not match format </exception>
      ///	 * <exception cref="IllegalArgumentException"> Error in format specification </exception>
      ///	 * <exception cref="java.io.EOFException"> End of file </exception>
      ///	 * <exception cref="java.io.IOException"> Other input error </exception>
      ///	 * <seealso cref= ScanfFormat </seealso>
      ///	 
      public virtual long scanHex(string s)
      {
         return scanHex(new ScanfFormat(s));
      }

      ///   
      ///	 <summary> * Scan and return a hex (long) integer, using a pre-allocated <tt>ScanfFormat</tt> object. This saves the overhead
      ///	 * of parsing the format from a string.
      ///	 *  </summary>
      ///	 * <param name="fmt"> Format object </param>
      ///	 * <returns> Scanned integer </returns>
      ///	 * <exception cref="ScanfMatchException"> Input did not match format </exception>
      ///	 * <exception cref="IllegalArgumentException"> Error in format specification </exception>
      ///	 * <exception cref="java.io.EOFException"> End of file </exception>
      ///	 * <exception cref="java.io.IOException"> Other input error </exception>
      ///	 * <seealso cref= ScanfFormat </seealso>
      ///	 * <seealso cref= ScanfReader#scanHex(String) </seealso>
      ///	 
      public virtual long scanHex(ScanfFormat fmt)
      {
         return scanHex(fmt, fmt.width);
      }

      ///   
      ///	 <summary> * Scan and return a signed integer, using the default format string "%i".
      ///	 *  </summary>
      ///	 * <param name="s"> Format string </param>
      ///	 * <returns> Scanned integer </returns>
      ///	 * <exception cref="ScanfMatchException"> Input did not match format </exception>
      ///	 * <exception cref="java.io.EOFException"> End of file </exception>
      ///	 * <exception cref="java.io.IOException"> Other input error </exception>
      ///	 * <seealso cref= ScanfFormat </seealso>
      ///	 * <seealso cref= ScanfReader#scanInt(String) </seealso>
      ///	 
      public virtual int scanInt()
      {
         return (int)scanLong();
      }

      ///   
      ///	 <summary> * Scan and return a signed integer.
      ///	 * 
      ///	 * <p>
      ///	 * The format string <tt>s</tt> must have the form described by the documentation for the class <tt>ScanfFormat</tt>
      ///	 * , and must contain one of the conversion characters "doxi".
      ///	 * 
      ///	 * <p>
      ///	 * Specifying the conversion characters 'd', 'o', or 'x' is equivalent to calling (int versions of) <tt>scanDec</tt>, <tt>scanOct</tt>, and <tt>scanHex</tt>, respectively.
      ///	 * 
      ///	 * <p>
      ///	 * If the conversion character is 'i', then after an optional sign ('+' or '-'), if the number begins with an <tt>0x</tt>,
      ///	 * then it is scanned as a hex number; if it begins with an <tt>0</tt>, then it is scanned as an octal number, and
      ///	 * otherwise it is scanned as a decimal number. White space preceding the number is skipped.
      ///	 *  </summary>
      ///	 * <param name="s"> Format string </param>
      ///	 * <returns> Scanned integer </returns>
      ///	 * <exception cref="ScanfMatchException"> Input did not match format </exception>
      ///	 * <exception cref="IllegalArgumentException"> Error in format specification </exception>
      ///	 * <exception cref="java.io.EOFException"> End of file </exception>
      ///	 * <exception cref="java.io.IOException"> Other input error </exception>
      ///	 * <seealso cref= ScanfFormat </seealso>
      ///	 * <seealso cref= ScanfReader#scanDec(String) </seealso>
      ///	 * <seealso cref= ScanfReader#scanOct(String) </seealso>
      ///	 * <seealso cref= ScanfReader#scanHex(String) </seealso>
      ///	 
      public virtual int scanInt(string s)
      {
         return (int)scanLong(s);
      }

      ///   
      ///	 <summary> * Scan and return a signed integer, using a pre-allocated <tt>ScanfFormat</tt> object. This saves the overhead of
      ///	 * parsing the format from a string.
      ///	 *  </summary>
      ///	 * <param name="fmt"> Format object </param>
      ///	 * <returns> Scanned integer </returns>
      ///	 * <exception cref="ScanfMatchException"> Input did not match format </exception>
      ///	 * <exception cref="IllegalArgumentException"> Error in format specification </exception>
      ///	 * <exception cref="java.io.EOFException"> End of file </exception>
      ///	 * <exception cref="java.io.IOException"> Other input error </exception>
      ///	 * <seealso cref= ScanfFormat </seealso>
      ///	 * <seealso cref= ScanfReader#scanInt(String) </seealso>
      ///	 
      public virtual int scanInt(ScanfFormat fmt)
      {
         return (int)scanLong(fmt);
      }

      ///   
      ///	 <summary> * Scan and return a signed (long) integer, using the default format string "%i".
      ///	 *  </summary>
      ///	 * <param name="s"> Format string </param>
      ///	 * <returns> Scanned integer </returns>
      ///	 * <exception cref="ScanfMatchException"> Input did not match format </exception>
      ///	 * <exception cref="java.io.EOFException"> End of file </exception>
      ///	 * <exception cref="java.io.IOException"> Other input error </exception>
      ///	 * <seealso cref= ScanfFormat </seealso>
      ///	 * <seealso cref= ScanfReader#scanInt(String) </seealso>
      ///	 
      public virtual long scanLong()
      {
         long val = 0;

         try
         {
            val = scanLong(defaultIntFmt);
         }
         catch (ArgumentException e)
         {
            // can't happen
            SupportClass.WriteStackTrace(e, Console.Error);
         }

         return val;
      }

      ///   
      ///	 <summary> * Scan and return a signed (long) integer. Functionality is identical to that for <tt>scanInt(String)</tt>.
      ///	 *  </summary>
      ///	 * <param name="s"> Format string </param>
      ///	 * <returns> Scanned integer </returns>
      ///	 * <exception cref="ScanfMatchException"> Input did not match format </exception>
      ///	 * <exception cref="IllegalArgumentException"> Error in format specification </exception>
      ///	 * <exception cref="java.io.EOFException"> End of file </exception>
      ///	 * <exception cref="java.io.IOException"> Other input error </exception>
      ///	 * <seealso cref= ScanfReader#scanInt(String) </seealso>
      ///	 
      public virtual long scanLong(string s)
      {
         return scanLong(new ScanfFormat(s));
      }

      ///   
      ///	 <summary> * Scan and return a signed (long) integer, using a pre-allocated <tt>ScanfFormat</tt> object.
      ///	 *  </summary>
      ///	 * <param name="fmt"> Format object </param>
      ///	 * <returns> Scanned integer </returns>
      ///	 * <exception cref="ScanfMatchException"> Input did not match format </exception>
      ///	 * <exception cref="IllegalArgumentException"> Error in format specification </exception>
      ///	 * <exception cref="java.io.EOFException"> End of file </exception>
      ///	 * <exception cref="java.io.IOException"> Other input error </exception>
      ///	 * <seealso cref= ScanfReader#scanInt(String) </seealso>
      ///	 
      public virtual long scanLong(ScanfFormat fmt)
      {
         if (fmt.type == 'd')
         {
            return scanDec(fmt);
         }
         else if (fmt.type == 'x')
         {
            return scanHex(fmt);
         }
         else if (fmt.type == 'o')
         {
            return scanOct(fmt);
         }
         else
         // fmt.type == 'i';
         {
            long val = 0;
            int sign = 1;
            int ccnt = 0;
            int width = fmt.width;

            if (width == -1)
            {
               width = 1000000000;
            }

            checkTypeAndScanPrefix(fmt, "i");

            if (spacesCStandardFlag)
            {
               skipWhiteSpace();
            }
            else
            {
               int skippedSpaces = skipWhiteSpace(width);
               width -= skippedSpaces;
            }

            if ((curChar == '-') || (curChar == '+'))
            {
               if (width == 1)
               {
                  throw new ScanfMatchException("Malformed integer");
               }

               if (curChar == '-')
               {
                  sign = -1;
               }

               consumeAndReplaceChar();
               ccnt++;
            }

            if (curChar == -1)
            {
               throw new EndOfStreamException("EOF");
            }

            if (curChar == '0')
            {
               consumeAndReplaceChar();
               ccnt++;

               if (ccnt == width)
               {
                  val = 0;
               }
               else
               {
                  if ((curChar == 'x') || (curChar == 'X'))
                  {
                     if ((ccnt + 1) == width)
                     {
                        throw new ScanfMatchException("Malformed hex integer");
                     }

                     consumeAndReplaceChar();
                     ccnt++;

                     if (char.IsWhiteSpace((char)curChar))
                     {
                        throw new ScanfMatchException("Malformed hex integer");
                     }

                     val = scanHex(defaultHexFmt, width - ccnt);
                  }
                  else
                  {
                     if (char.IsWhiteSpace((char)curChar))
                     {
                        val = 0;
                     }
                     else
                     {
                        val = scanOct(defaultOctFmt, width - ccnt);
                     }
                  }
               }
            }
            else
            { // scan unsigned decimal integer

               int i = 0;
               val = 0;

               if (!char.IsDigit((char)curChar))
               {
                  throw new ScanfMatchException("Malformed decimal integer");
               }

               while (char.IsDigit((char)curChar) && (i < (width - ccnt)))
               {
                  val = (val * 10) + (curChar - '0');
                  consumeAndReplaceChar();
                  i++;
               }
            }

            scanSuffix(fmt);

            return sign * val;
         }
      }

      ///   
      ///	 <summary> * Scan and return an octal (long) integer, using the default format string "%o".
      ///	 *  </summary>
      ///	 * <param name="s"> Format string </param>
      ///	 * <returns> Scanned integer </returns>
      ///	 * <exception cref="ScanfMatchException"> Input did not match format </exception>
      ///	 * <exception cref="java.io.EOFException"> End of file </exception>
      ///	 * <exception cref="java.io.IOException"> Other input error </exception>
      ///	 * <seealso cref= ScanfFormat </seealso>
      ///	 * <seealso cref= ScanfReader#scanOct(String) </seealso>
      ///	 
      public virtual long scanOct()
      {
         long val = 0;

         try
         {
            val = scanOct(defaultOctFmt, -1);
         }
         catch (ArgumentException e)
         {
            // can't happen
            SupportClass.WriteStackTrace(e, Console.Error);
         }

         return val;
      }

      ///   
      ///	 <summary> * Scan and return an octal (long) integer.
      ///	 * 
      ///	 * <p>
      ///	 * The format string <tt>s</tt> must have the form described by the documentation for the class <tt>ScanfFormat</tt>
      ///	 * , and must contain the conversion character 'o'. The integer itself must be composed of the digits [0-7], and
      ///	 * white space which immediately precedes it is skipped.
      ///	 *  </summary>
      ///	 * <param name="s"> Format string </param>
      ///	 * <returns> Scanned integer </returns>
      ///	 * <exception cref="ScanfMatchException"> Input did not match format </exception>
      ///	 * <exception cref="IllegalArgumentException"> Error in format specification </exception>
      ///	 * <exception cref="java.io.EOFException"> End of file </exception>
      ///	 * <exception cref="java.io.IOException"> Other input error </exception>
      ///	 * <seealso cref= ScanfFormat </seealso>
      ///	 
      public virtual long scanOct(string s)
      {
         return scanOct(new ScanfFormat(s));
      }

      ///   
      ///	 <summary> * Scan and return an octal (long) integer, using a pre-allocated <tt>ScanfFormat</tt> object. This saves the
      ///	 * overhead of parsing the format from a string.
      ///	 *  </summary>
      ///	 * <param name="fmt"> Format object </param>
      ///	 * <returns> Scanned integer </returns>
      ///	 * <exception cref="ScanfMatchException"> Input did not match format </exception>
      ///	 * <exception cref="IllegalArgumentException"> Error in format specification </exception>
      ///	 * <exception cref="java.io.EOFException"> End of file </exception>
      ///	 * <exception cref="java.io.IOException"> Other input error </exception>
      ///	 * <seealso cref= ScanfFormat </seealso>
      ///	 * <seealso cref= ScanfReader#scanOct(String) </seealso>
      ///	 
      public virtual long scanOct(ScanfFormat fmt)
      {
         return scanOct(fmt, fmt.width);
      }

      ///   
      ///	 <summary> * Scan and return a <tt>String</tt>, using the default format string "%s".
      ///	 *  </summary>
      ///	 * <param name="s"> Format string </param>
      ///	 * <returns> Scanned <tt>String</tt> </returns>
      ///	 * <exception cref="ScanfMatchException"> Input did not match format </exception>
      ///	 * <exception cref="java.io.EOFException"> End of file </exception>
      ///	 * <exception cref="java.io.IOException"> Other input error </exception>
      ///	 * <seealso cref= ScanfFormat </seealso>
      ///	 * <seealso cref= ScanfReader#scanString(String) </seealso>
      ///	 
      public virtual string scanString()
      {
         string val = null;

         try
         {
            val = scanString(defaultStringFmt);
         }
         catch (ArgumentException e)
         {
            // can't happen
            SupportClass.WriteStackTrace(e, Console.Error);
         }

         return val;
      }

      ///   
      ///	 <summary> * Scan and return a <tt>String</tt>.
      ///	 * 
      ///	 * <p>
      ///	 * The format string <tt>s</tt> must have the form described by the documentation for the class <tt>ScanfFormat</tt>
      ///	 * , and must contain the conversion character 's'. The string returned corresponds to the next non-white-space
      ///	 * sequence of characters found in the input, with preceding white space skipped.
      ///	 *  </summary>
      ///	 * <param name="s"> Format string </param>
      ///	 * <returns> Scanned <tt>String</tt> </returns>
      ///	 * <exception cref="ScanfMatchException"> Input did not match format </exception>
      ///	 * <exception cref="IllegalArgumentException"> Error in format specification </exception>
      ///	 * <exception cref="java.io.EOFException"> End of file </exception>
      ///	 * <exception cref="java.io.IOException"> Other input error </exception>
      ///	 * <seealso cref= ScanfFormat </seealso>
      ///	 
      public virtual string scanString(string s)
      {
         return scanString(new ScanfFormat(s));
      }

      ///   
      ///	 <summary> * Scan and return a <tt>String</tt>, using a pre-allocated <tt>ScanfFormat</tt> object. This saves the overhead of
      ///	 * parsing the format from a string.
      ///	 *  </summary>
      ///	 * <param name="fmt"> Format object </param>
      ///	 * <returns> Scanned <tt>String</tt> </returns>
      ///	 * <exception cref="ScanfMatchException"> Input did not match format </exception>
      ///	 * <exception cref="IllegalArgumentException"> Error in format specification </exception>
      ///	 * <exception cref="java.io.EOFException"> End of file </exception>
      ///	 * <exception cref="java.io.IOException"> Other input error </exception>
      ///	 * <seealso cref= ScanfFormat </seealso>
      ///	 * <seealso cref= ScanfReader#scanString(String) </seealso>
      ///	 
      public virtual string scanString(ScanfFormat fmt)
      {
         int blimit = BUFSIZE;

         if ((fmt.width != -1) && (fmt.width < blimit))
         {
            blimit = fmt.width;
         }

         checkTypeAndScanPrefix(fmt, "s");

         if (spacesCStandardFlag)
         {
            skipWhiteSpace();
         }
         else
         {
            int skippedSpaces = skipWhiteSpace(blimit);
            blimit -= skippedSpaces;
         }

         if (curChar == -1)
         {
            throw new EndOfStreamException("EOF");
         }

         bcnt = 0;

         while (!char.IsWhiteSpace((char)curChar) && (curChar != -1) && (bcnt < blimit))
         {
            buffer[bcnt++] = (char)curChar;
            consumeAndReplaceChar();
         }

         scanSuffix(fmt);

         return new string(buffer, 0, bcnt);
      }

      ///   
      ///	 <summary> * Sets the current character number.
      ///	 *  </summary>
      ///	 * <param name="n"> New character number </param>
      ///	 * <seealso cref= ScanfReader#getCharNumber </seealso>
      ///	 
      public virtual void setCharNumber(int n)
      {
         charCnt = n;
      }

      ///   
      ///	 <summary> * Sets the current line number.
      ///	 *  </summary>
      ///	 * <param name="n"> New line number </param>
      ///	 * <seealso cref= ScanfReader#setLineNumber </seealso>
      ///	 
      public virtual void setLineNumber(int n)
      {
         lineCnt = n;
      }

      ///   
      ///	 <summary> * White spaces are skipped at the beginning of a line if flag is <tt>true</tt> otherwise spaces are counted as
      ///	 * valid characters. </summary>
      ///	 
      public virtual bool useCstandard()
      {
         return spacesCStandardFlag;
      }

      ///   
      ///	 <summary> * White spaces are skipped at the beginning of a line if <tt>flag</tt> is <tt>true</tt> otherwise spaces are
      ///	 * counted as valid characters. </summary>
      ///	 
      public virtual void useCstandard(bool flag)
      {
         spacesCStandardFlag = flag;
      }

      private bool acceptChar(char c, int width)
      {
         bool accept = false;

         if ((curChar == c) && (bcnt < width))
         {
            buffer[bcnt++] = (char)curChar;

            if (bcnt < width)
            {
               consumeAndReplaceChar();
            }
            else
            {
               consumeChar();
            }

            accept = true;
         }

         return accept;
      }

      private bool acceptDigits(int width)
      {
         bool matched = false;

         while (char.IsDigit((char)curChar) && (bcnt < width))
         {
            buffer[bcnt++] = (char)curChar;
            matched = true;

            if (bcnt < width)
            {
               consumeAndReplaceChar();
            }
            else
            {
               consumeChar();
            }
         }

         return matched;
      }

      private void checkTypeAndScanPrefix(ScanfFormat fmt, string type)
      {
         if (fmt.type == -1)
         {
            throw new ArgumentException("No conversion character");
         }

         if (type.IndexOf((char)fmt.type) == -1)
         {
            throw new ArgumentException("Illegal conversion character '" + (char)fmt.type + "'");
         }

         if (fmt.prefix != null)
         {
            matchString(fmt.prefix);
         }
      }

      private void consumeAndReplaceChar()
      {
         if (curChar != -1)
         {
            charCnt++;

            if ((curChar == '\r') || ((curChar == '\n') && (lastChar != '\r')))
            {
               lineCnt++;
            }
         }

         lastChar = curChar;
         curChar = reader.Read();
      }

      private void consumeChar()
      {
         if (curChar != -1)
         {
            charCnt++;

            if ((curChar == '\r') || ((curChar == '\n') && (lastChar != '\r')))
            {
               lineCnt++;
            }
         }

         lastChar = curChar;
         curCharValid = false;
      }

      private void initChar()
      {
         if (!curCharValid)
         {
            curChar = reader.Read();
            curCharValid = true;
         }

         // charCnt = 0;
      }

      private void matchString(string s)
      {
         initChar();

         for (int i = 0; i < s.Length; i++)
         {
            char c = s[i];

            if (curChar == -1)
            {
               throw new EndOfStreamException("EOF");
            }

            if (char.IsWhiteSpace(c))
            {
               if (skipWhiteSpace() == false)
               // { if (skipWhiteSpace(s.length()) == 0)
               {
                  throw new ScanfMatchException("No white space to match white space in format");
               }
            }
            else
            {
               if (curChar != c)
               {
                  throw new ScanfMatchException("Char '" + (char)curChar + "' does not match char '" + c + "' in format");
               }

               consumeAndReplaceChar();
            }
         }
      }

      ///   
      ///	 <summary> * Implementing methodName for scanChars.
      ///	 *  </summary>
      ///	 * <seealso cref= ScanfReader#scanChars(String) </seealso>
      ///	 
      private char[] scanChars(ScanfFormat fmt, int w)
      {
         int wLocal = w;

         if (wLocal == -1)
         {
            wLocal = 1;
         }

         char[] @value = new char[wLocal];
         checkTypeAndScanPrefix(fmt, "c[");
         initChar();

         if (curChar == -1)
         {
            throw new EndOfStreamException("EOF");
         }

         for (int i = 0; i < wLocal; i++)
         {
            @value[i] = (char)curChar;

            if ((fmt.type == '[') && !fmt.matchChar(@value[i]))
            {
               throw new ScanfMatchException("Input char '" + @value[i] + "' does not match '[" + fmt.cmatch + "]'");
            }

            consumeAndReplaceChar();
         }

         scanSuffix(fmt);

         return @value;
      }

      ///   
      ///	 <summary> * Implementing methodName for scanDec.
      ///	 *  </summary>
      ///	 * <seealso cref= ScanfReader#scanDec(String) </seealso>
      ///	 
      private long scanDec(ScanfFormat fmt, int width)
      {
         int widthLocal = width;

         if (widthLocal == -1)
         {
            widthLocal = 1000000000;
         }

         long val;
         int i;

         bool negate = false;

         checkTypeAndScanPrefix(fmt, "d");

         if (spacesCStandardFlag)
         {
            skipWhiteSpace();
         }
         else
         {
            int skippedSpaces = skipWhiteSpace(widthLocal);
            widthLocal -= skippedSpaces;
         }

         if ((curChar == '-') || (curChar == '+'))
         {
            negate = (curChar == '-');
            consumeAndReplaceChar();
         }

         if (curChar == -1)
         {
            throw new EndOfStreamException("EOF");
         }

         if (!char.IsDigit((char)curChar))
         {
            throw new ScanfMatchException("Malformed decimal integer");
         }

         val = 0;
         i = 0;

         while ((char.IsDigit((char)curChar)) && (i < widthLocal))
         {
            val = (val * 10) + (curChar - '0');
            consumeAndReplaceChar();
            i++;
         }

         if (negate)
         {
            val = -val;
         }

         scanSuffix(fmt);

         return val;
      }

      ///   
      ///	 <summary> * Implementing methodName for scanHex.
      ///	 *  </summary>
      ///	 * <seealso cref= ScanfReader#scanHex(String) </seealso>
      ///	 
      private long scanHex(ScanfFormat fmt, int width)
      {
         int widthLocal = width;

         if (widthLocal == -1)
         {
            widthLocal = 1000000000;
         }

         long val;
         int k;
         int i;

         checkTypeAndScanPrefix(fmt, "x");

         if (spacesCStandardFlag)
         {
            skipWhiteSpace();
         }
         else
         {
            int skippedSpaces = skipWhiteSpace(widthLocal);
            widthLocal -= skippedSpaces;
         }

         if (curChar == -1)
         {
            throw new EndOfStreamException("EOF");
         }

         if (hexChars.IndexOf((char)curChar) == -1)
         {
            throw new ScanfMatchException("Malformed hex integer");
         }

         val = 0;
         i = 0;

         while (((k = hexChars.IndexOf((char)curChar)) != -1) && (i < widthLocal))
         {
            if (k > 15)
            {
               k -= 6;
            }

            val = (val * 16) + k;
            consumeAndReplaceChar();
            i++;
         }

         scanSuffix(fmt);

         return val;
      }

      ///   
      ///	 <summary> * Implementing methodName for scanOct.
      ///	 *  </summary>
      ///	 * <seealso cref= ScanfReader#scanOct(String) </seealso>
      ///	 
      private long scanOct(ScanfFormat fmt, int width)
      {
         int widthLocal = width;

         if (widthLocal == -1)
         {
            widthLocal = 1000000000;
         }

         long val;
         int k;
         int i;

         checkTypeAndScanPrefix(fmt, "o");

         if (spacesCStandardFlag)
         {
            skipWhiteSpace();
         }
         else
         {
            int skippedSpaces = skipWhiteSpace(widthLocal);
            widthLocal -= skippedSpaces;
         }

         if (curChar == -1)
         {
            throw new EndOfStreamException("EOF");
         }

         if (octChars.IndexOf((char)curChar) == -1)
         {
            throw new ScanfMatchException("Malformed octal integer");
         }

         val = 0;
         i = 0;

         while (((k = octChars.IndexOf((char)curChar)) != -1) && (i < widthLocal))
         {
            val = (val * 8) + k;
            consumeAndReplaceChar();
            i++;
         }

         scanSuffix(fmt);

         return val;
      }

      // private final void scanPrefix(ScanfFormat fmt) throws IOException
      // {
      // if (fmt.prefix != null)
      // {
      // matchString(fmt.prefix);
      // }
      // }

      private void scanSuffix(ScanfFormat fmt)
      {
         if (fmt.suffix != null)
         {
            matchString(fmt.suffix);
         }
      }

      ///   
      ///	 <summary> * Skip white spacew and count line numbers. </summary>
      ///	 
      private bool skipWhiteSpace()
      {
         bool encounterdWhiteSpace = false;

         initChar();

         while (char.IsWhiteSpace((char)curChar))
         {
            encounterdWhiteSpace = true;
            consumeAndReplaceChar();
         }

         return encounterdWhiteSpace ? true : false;
      }

      ///   
      ///	 <summary> * Skip white spacew and count line numbers.
      ///	 *  </summary>
      ///	 * <param name="limit"> the maximum of the number that will be skipped </param>
      ///	 * <returns> the number of skipped white spaces </returns>
      ///	 
      private int skipWhiteSpace(int limit)
      {
         initChar();

         int spaces = 0;

         while (char.IsWhiteSpace((char)curChar) && (spaces <= limit))
         {
            spaces++;
            consumeAndReplaceChar();
         }

         return spaces;
      }
   }
}
