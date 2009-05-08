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
 * This  software is distributed "as is", without any warranty, including
 * any implied warranty of merchantability or fitness for a particular
 * use. The authors assume no responsibility for, and shall not be liable
 * for, any special, indirect, or consequential damages, or any damages
 * whatsoever, arising out of or in connection with the use of this
 * software.
 */ 

namespace org.cip4.jdflib.cformat
{
   using System.IO;


   ///
   ///  <summary> * PrintStream which outputs primitive types using C <tt>printf</tt>
   ///  * style formatting. For each primitive type (float, double, char, int, long,
   ///  * String), there is a <tt>printf</tt> method which takes (as a first
   ///  * argument) either a <tt>printf</tt> style format string, or a
   ///  * PrintfFormat object.
   ///  * Using the latter can be more efficient because it permits an
   ///  * application to prorate the overhead of parsing a format string.
   ///  *
   ///  * <p>
   ///  * Because Java does not permit variable numbers of arguments, each
   ///  * <tt>printf</tt> methodName accepts only one primitive type, and the
   ///  * format can correspondingly contain only one conversion
   ///  * sequence.
   ///  * </summary>
   ///  * <seealso cref= PrintfFormat </seealso>
   ///  * <seealso cref= PrintfWriter
   ///  * @.author John E. Lloyd </seealso>
   ///  
   public class PrintfStream : StreamWriter
   {
      //~ Constructors ///////////////////////////////////////////////////////////

      ///    
      ///      <summary> * Creates a PrintfStream, without automatic line flushing,
      ///      * from an existing OutputStream.
      ///      * </summary>
      ///      * <param name="out"> An output stream </param>
      ///      
      public PrintfStream(Stream pout)
         : base(pout)
      {
      }

      ///    
      ///      <summary> * Creates a PrintfStream from an existing OutputStream.
      ///      * </summary>
      ///      * <param name="out"> An output stream </param>
      ///      * <param name="autoFlush"> If true, specifies that output flushing will
      ///      * automatically occur when the println() methods are called,
      ///      * a byte array is written, or a new line character or byte is
      ///      * encountered in the output. </param>
      ///      
      public PrintfStream(Stream pout, bool autoFlush)
         : base(pout)
      {
      }

      //~ Methods ////////////////////////////////////////////////////////////////

      ///    
      ///      <summary> * Prints a double in accordance with the supplied format string.
      ///      * </summary>
      ///      * <param name="fs"> Format string </param>
      ///      * <param name="x"> Double to output </param>
      ///      * <exception cref="IllegalArgumentException"> Malformed format string </exception>
      ///      
      public virtual void printf(string fs, double x)
      {
         Write(new PrintfFormat(fs).tostr(x));
      }

      ///    
      ///      <summary> * Prints a float in accordance with the supplied format string.
      ///      * </summary>
      ///      * <param name="fs"> Format string </param>
      ///      * <param name="x"> Float to output </param>
      ///       * <exception cref="IllegalArgumentException"> Malformed format string </exception>
      ///      
      public virtual void printf(string fs, float x)
      {
         Write(new PrintfFormat(fs).tostr(x));
      }

      ///    
      ///      <summary> * Prints a long in accordance with the supplied format string.
      ///      * </summary>
      ///      * <param name="fs"> Format string </param>
      ///      * <param name="x"> Long to output </param>
      ///      * <exception cref="IllegalArgumentException"> Malformed format string </exception>
      ///      
      public virtual void printf(string fs, long x)
      {
         Write(new PrintfFormat(fs).tostr(x));
      }

      ///    
      ///      <summary> * Prints an int in accordance with the supplied format string.
      ///      * </summary>
      ///      * <param name="fs"> Format string </param>
      ///      * <param name="x"> Int to output </param>
      ///      * <exception cref="IllegalArgumentException"> Malformed format string </exception>
      ///      
      public virtual void printf(string fs, int x)
      {
         Write(new PrintfFormat(fs).tostr(x));
      }

      ///    
      ///      <summary> * Prints a String in accordance with the supplied format string.
      ///      * </summary>
      ///      * <param name="fs"> Format string </param>
      ///      * <param name="x"> String to output </param>
      ///      * <exception cref="IllegalArgumentException"> Malformed format string </exception>
      ///      
      public virtual void printf(string fs, string x)
      {
         Write(new PrintfFormat(fs).tostr(x));
      }

      ///    
      ///      <summary> * Prints a char in accordance with the supplied format string.
      ///      * </summary>
      ///      * <param name="fs"> Format string </param>
      ///      * <param name="x"> Char to output </param>
      ///      * <exception cref="IllegalArgumentException"> Malformed format string </exception>
      ///      
      public virtual void printf(string fs, char x)
      {
         Write(new PrintfFormat(fs).tostr(x));
      }

      ///    
      ///      <summary> * Prints a double in accordance with the supplied
      ///      * PrintfFormat object.
      ///      * </summary>
      ///      * <param name="fmt"> Formatting object </param>
      ///      * <param name="x"> Double to output </param>
      ///      * <seealso cref= PrintfFormat </seealso>
      ///      
      public virtual void printf(PrintfFormat fmt, double x)
      {
         Write(fmt.tostr(x));
      }

      ///    
      ///      <summary> * Prints a float in accordance with the supplied
      ///      * PrintfFormat object.
      ///      * </summary>
      ///      * <param name="fmt"> Formatting object </param>
      ///      * <param name="x"> Float to output </param>
      ///      * <seealso cref= PrintfFormat </seealso>
      ///      
      public virtual void printf(PrintfFormat fmt, float x)
      {
         Write(fmt.tostr(x));
      }

      ///    
      ///      <summary> * Prints a long in accordance with the supplied
      ///      * PrintfFormat object.
      ///      * </summary>
      ///      * <param name="fmt"> Formatting object </param>
      ///      * <param name="x"> Long to output </param>
      ///      * <seealso cref= PrintfFormat </seealso>
      ///      
      public virtual void printf(PrintfFormat fmt, long x)
      {
         Write(fmt.tostr(x));
      }

      ///    
      ///      <summary> * Prints an int in accordance with the supplied
      ///      * PrintfFormat object.
      ///      * </summary>
      ///      * <param name="fmt"> Formatting object </param>
      ///      * <param name="x"> Int to output </param>
      ///      * <seealso cref= PrintfFormat </seealso>
      ///      
      public virtual void printf(PrintfFormat fmt, int x)
      {
         Write(fmt.tostr(x));
      }

      ///    
      ///      <summary> * Prints a String in accordance with the supplied
      ///      * PrintfFormat object.
      ///      * </summary>
      ///      * <param name="fmt"> Formatting object </param>
      ///      * <param name="x"> String to output </param>
      ///      * <seealso cref= PrintfFormat </seealso>
      ///      
      public virtual void printf(PrintfFormat fmt, string x)
      {
         Write(fmt.tostr(x));
      }

      ///    
      ///      <summary> * Prints a char in accordance with the supplied
      ///      * PrintfFormat object.
      ///      * </summary>
      ///      * <param name="fmt"> Formatting object </param>
      ///      * <param name="x"> Char to output </param>
      ///      * <seealso cref= PrintfFormat </seealso>
      ///      
      public virtual void printf(PrintfFormat fmt, char x)
      {
         Write(fmt.tostr(x));
      }
   }
}
