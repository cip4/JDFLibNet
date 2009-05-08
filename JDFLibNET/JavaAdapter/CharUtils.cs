
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



/* Licensed to the Apache Software Foundation (ASF) under one or more
 * contributor license agreements.  See the NOTICE file distributed with
 * this work for additional information regarding copyright ownership.
 * The ASF licenses this file to You under the Apache License, Version 2.0
 * (the "License"); you may not use this file except in compliance with
 * the License.  You may obtain a copy of the License at
 * 
 *      http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

namespace org.apache.commons.lang
{
   using System;


///
/// <summary> * <p>Operations on char primitives and Character objects.</p>
/// *
/// * <p>This class tries to handle <code>null</code> input gracefully.
/// * An exception will not be thrown for a <code>null</code> input.
/// * Each method documents its behaviour in more detail.</p>
/// * 
/// * @author Stephen Colebourne
/// * @since 2.1
/// * @version $Id: CharUtils.java 437554 2006-08-28 06:21:41Z bayard $ </summary>
/// 
   public class CharUtils
   {

       private const string CHAR_STRING = "\u0000\u0001\u0002\u0003\u0004\u0005\u0006\u0007" + "\b\t\n\u000b\f\r\u000e\u000f" + "\u0010\u0011\u0012\u0013\u0014\u0015\u0016\u0017" + "\u0018\u0019\u001a\u001b\u001c\u001d\u001e\u001f" + "\u0020\u0021\"\u0023\u0024\u0025\u0026\u0027" + "\u0028\u0029\u002a\u002b\u002c\u002d\u002e\u002f" + "\u0030\u0031\u0032\u0033\u0034\u0035\u0036\u0037" + "\u0038\u0039\u003a\u003b\u003c\u003d\u003e\u003f" + "\u0040\u0041\u0042\u0043\u0044\u0045\u0046\u0047" + "\u0048\u0049\u004a\u004b\u004c\u004d\u004e\u004f" + "\u0050\u0051\u0052\u0053\u0054\u0055\u0056\u0057" + "\u0058\u0059\u005a\u005b\\\u005d\u005e\u005f" + "\u0060\u0061\u0062\u0063\u0064\u0065\u0066\u0067" + "\u0068\u0069\u006a\u006b\u006c\u006d\u006e\u006f" + "\u0070\u0071\u0072\u0073\u0074\u0075\u0076\u0077" + "\u0078\u0079\u007a\u007b\u007c\u007d\u007e\u007f";

       private static readonly string[] CHAR_STRING_ARRAY = new string[128];
       private static readonly char[] CHAR_ARRAY = new char[128];

///    
///     <summary> * <code>\u000a</code> linefeed LF ('\n').
///     *  </summary>
///     * <seealso cref= <a href="http://java.sun.com/docs/books/jls/third_edition/html/lexical.html#101089">JLF: Escape Sequences
///     *      for Character and String Literals</a>
///     * @since 2.2 </seealso>
///     
       public const char LF = '\n';

///    
///     <summary> * <code>\u000d</code> carriage return CR ('\r').
///     *  </summary>
///     * <seealso cref= <a href="http://java.sun.com/docs/books/jls/third_edition/html/lexical.html#101089">JLF: Escape Sequences
///     *      for Character and String Literals</a>
///     * @since 2.2 </seealso>
///     
       public const char CR = '\r';


       static CharUtils()
       {
           for (int i = 127; i >= 0; i--)
           {
               CHAR_STRING_ARRAY[i] = CHAR_STRING.Substring(i, i + 1);
               CHAR_ARRAY[i] = (char)i; // new char((char)i);
           }
       }

///    
///     <summary> * <p><code>CharUtils</code> instances should NOT be constructed in standard programming.
///     * Instead, the class should be used as <code>CharUtils.toString('c');</code>.</p>
///     *
///     * <p>This constructor is public to permit tools that require a JavaBean instance
///     * to operate.</p> </summary>
///     
       public CharUtils() : base()
       {
       }

    //-----------------------------------------------------------------------
///    
///     <summary> * <p>Converts the character to a Character.</p>
///     * 
///     * <p>For ASCII 7 bit characters, this uses a cache that will return the
///     * same Character object each time.</p>
///     *
///     * <pre>
///     *   CharUtils.toCharacterObject(' ')  = ' '
///     *   CharUtils.toCharacterObject('A')  = 'A'
///     * </pre>
///     * </summary>
///     * <param name="ch">  the character to convert </param>
///     * <returns> a Character of the specified character </returns>
///     
       public static char toCharacterObject(char ch)
       {
           if (ch < CHAR_ARRAY.Length)
           {
               return CHAR_ARRAY[ch];
           }
           return ch; // new char(ch);
       }

///    
///     <summary> * <p>Converts the String to a Character using the first character, returning
///     * null for empty Strings.</p>
///     * 
///     * <p>For ASCII 7 bit characters, this uses a cache that will return the
///     * same Character object each time.</p>
///     * 
///     * <pre>
///     *   CharUtils.toCharacterObject(null) = null
///     *   CharUtils.toCharacterObject("")   = null
///     *   CharUtils.toCharacterObject("A")  = 'A'
///     *   CharUtils.toCharacterObject("BA") = 'B'
///     * </pre>
///     * </summary>
///     * <param name="str">  the character to convert </param>
///     * <returns> the Character value of the first letter of the String </returns>
///     
       public static char toCharacterObject(string str)
       {
           if (StringUtils.IsEmpty(str))
           {
              return '\0'; // null;
           }
           return toCharacterObject(str[0]);
       }

    //-----------------------------------------------------------------------
///    
///     <summary> * <p>Converts the Character to a char throwing an exception for <code>null</code>.</p>
///     * 
///     * <pre>
///     *   CharUtils.toChar(null) = IllegalArgumentException
///     *   CharUtils.toChar(' ')  = ' '
///     *   CharUtils.toChar('A')  = 'A'
///     * </pre>
///     * </summary>
///     * <param name="ch">  the character to convert </param>
///     * <returns> the char value of the Character </returns>
///     * <exception cref="IllegalArgumentException"> if the Character is null </exception>
///     
       public static char toChar(char ch)
       {
           //if (ch == null)
           //{
           //    throw new ArgumentException("The Character must not be null");
           //}
           return ch; 
       }

///    
///     <summary> * <p>Converts the Character to a char handling <code>null</code>.</p>
///     * 
///     * <pre>
///     *   CharUtils.toChar(null, 'X') = 'X'
///     *   CharUtils.toChar(' ', 'X')  = ' '
///     *   CharUtils.toChar('A', 'X')  = 'A'
///     * </pre>
///     * </summary>
///     * <param name="ch">  the character to convert </param>
///     * <param name="defaultValue">  the value to use if the  Character is null </param>
///     * <returns> the char value of the Character or the default if null </returns>
///     
       public static char toChar(char ch, char defaultValue)
       {
           //if (ch == null)
           //{
           //    return defaultValue;
           //}
           return ch; 
       }

    //-----------------------------------------------------------------------
///    
///     <summary> * <p>Converts the String to a char using the first character, throwing
///     * an exception on empty Strings.</p>
///     * 
///     * <pre>
///     *   CharUtils.toChar(null) = IllegalArgumentException
///     *   CharUtils.toChar("")   = IllegalArgumentException
///     *   CharUtils.toChar("A")  = 'A'
///     *   CharUtils.toChar("BA") = 'B'
///     * </pre>
///     * </summary>
///     * <param name="str">  the character to convert </param>
///     * <returns> the char value of the first letter of the String </returns>
///     * <exception cref="IllegalArgumentException"> if the String is empty </exception>
///     
       public static char toChar(string str)
       {
           if (StringUtils.IsEmpty(str))
           {
               throw new ArgumentException("The String must not be empty");
           }
           return str[0];
       }

///    
///     <summary> * <p>Converts the String to a char using the first character, defaulting
///     * the value on empty Strings.</p>
///     * 
///     * <pre>
///     *   CharUtils.toChar(null, 'X') = 'X'
///     *   CharUtils.toChar("", 'X')   = 'X'
///     *   CharUtils.toChar("A", 'X')  = 'A'
///     *   CharUtils.toChar("BA", 'X') = 'B'
///     * </pre>
///     * </summary>
///     * <param name="str">  the character to convert </param>
///     * <param name="defaultValue">  the value to use if the  Character is null </param>
///     * <returns> the char value of the first letter of the String or the default if null </returns>
///     
       public static char toChar(string str, char defaultValue)
       {
           if (StringUtils.IsEmpty(str))
           {
               return defaultValue;
           }
           return str[0];
       }

    //-----------------------------------------------------------------------
///    
///     <summary> * <p>Converts the character to the Integer it represents, throwing an
///     * exception if the character is not numeric.</p>
///     * 
///     * <p>This method coverts the char '1' to the int 1 and so on.</p>
///     *
///     * <pre>
///     *   CharUtils.toIntValue('3')  = 3
///     *   CharUtils.toIntValue('A')  = IllegalArgumentException
///     * </pre>
///     * </summary>
///     * <param name="ch">  the character to convert </param>
///     * <returns> the int value of the character </returns>
///     * <exception cref="IllegalArgumentException"> if the character is not ASCII numeric </exception>
///     
       public static int toIntValue(char ch)
       {
           if (isAsciiNumeric(ch) == false)
           {
               throw new ArgumentException("The character " + ch + " is not in the range '0' - '9'");
           }
           return ch - 48;
       }

///    
///     <summary> * <p>Converts the character to the Integer it represents, throwing an
///     * exception if the character is not numeric.</p>
///     * 
///     * <p>This method coverts the char '1' to the int 1 and so on.</p>
///     *
///     * <pre>
///     *   CharUtils.toIntValue('3', -1)  = 3
///     *   CharUtils.toIntValue('A', -1)  = -1
///     * </pre>
///     * </summary>
///     * <param name="ch">  the character to convert </param>
///     * <param name="defaultValue">  the default value to use if the character is not numeric </param>
///     * <returns> the int value of the character </returns>
///     
       public static int toIntValue(char ch, int defaultValue)
       {
           if (isAsciiNumeric(ch) == false)
           {
               return defaultValue;
           }
           return ch - 48;
       }

///    
///     <summary> * <p>Converts the character to the Integer it represents, throwing an
///     * exception if the character is not numeric.</p>
///     * 
///     * <p>This method coverts the char '1' to the int 1 and so on.</p>
///     *
///     * <pre>
///     *   CharUtils.toIntValue(null) = IllegalArgumentException
///     *   CharUtils.toIntValue('3')  = 3
///     *   CharUtils.toIntValue('A')  = IllegalArgumentException
///     * </pre>
///     * </summary>
///     * <param name="ch">  the character to convert, not null </param>
///     * <returns> the int value of the character </returns>
///     * <exception cref="IllegalArgumentException"> if the Character is not ASCII numeric or is null </exception>
///     
       //public static int toIntValue(char ch)
       //{
       //    if (ch == null)
       //    {
       //        throw new IllegalArgumentException("The character must not be null");
       //    }
       //    return toIntValue(ch.charValue());
       //}

///    
///     <summary> * <p>Converts the character to the Integer it represents, throwing an
///     * exception if the character is not numeric.</p>
///     * 
///     * <p>This method coverts the char '1' to the int 1 and so on.</p>
///     *
///     * <pre>
///     *   CharUtils.toIntValue(null, -1) = -1
///     *   CharUtils.toIntValue('3', -1)  = 3
///     *   CharUtils.toIntValue('A', -1)  = -1
///     * </pre>
///     * </summary>
///     * <param name="ch">  the character to convert </param>
///     * <param name="defaultValue">  the default value to use if the character is not numeric </param>
///     * <returns> the int value of the character </returns>
///     
       //public static int toIntValue(char ch, int defaultValue)
       //{
       //    if (ch == null)
       //    {
       //        return defaultValue;
       //    }
       //    return toIntValue(ch.charValue(), defaultValue);
       //}

    //-----------------------------------------------------------------------
///    
///     <summary> * <p>Converts the character to a String that contains the one character.</p>
///     * 
///     * <p>For ASCII 7 bit characters, this uses a cache that will return the
///     * same String object each time.</p>
///     *
///     * <pre>
///     *   CharUtils.toString(' ')  = " "
///     *   CharUtils.toString('A')  = "A"
///     * </pre>
///     * </summary>
///     * <param name="ch">  the character to convert </param>
///     * <returns> a String containing the one specified character </returns>
///     
       public static string ToString(char ch)
       {
           if (ch < 128)
           {
               return CHAR_STRING_ARRAY[ch];
           }
           return new string(new char[] {ch});
       }

///    
///     <summary> * <p>Converts the character to a String that contains the one character.</p>
///     * 
///     * <p>For ASCII 7 bit characters, this uses a cache that will return the
///     * same String object each time.</p>
///     * 
///     * <p>If <code>null</code> is passed in, <code>null</code> will be returned.</p>
///     *
///     * <pre>
///     *   CharUtils.toString(null) = null
///     *   CharUtils.toString(' ')  = " "
///     *   CharUtils.toString('A')  = "A"
///     * </pre>
///     * </summary>
///     * <param name="ch">  the character to convert </param>
///     * <returns> a String containing the one specified character </returns>
///     
       //public static string ToString(char ch)
       //{
       //    if (ch == null)
       //    {
       //        return null;
       //    }
       //    return ToString(ch.charValue());
       //}

    //--------------------------------------------------------------------------
///    
///     <summary> * <p>Converts the string to the unicode format '\u0020'.</p>
///     * 
///     * <p>This format is the Java source code format.</p>
///     *
///     * <pre>
///     *   CharUtils.unicodeEscaped(' ') = "\u0020"
///     *   CharUtils.unicodeEscaped('A') = "\u0041"
///     * </pre>
///     *  </summary>
///     * <param name="ch">  the character to convert </param>
///     * <returns> the escaped unicode string </returns>
///     
       public static string unicodeEscaped(char ch)
       {
           if (ch < 0x10)
           {
              return "\\u000" + Convert.ToString(ch, 16); // int.toHexString(ch);
           }
           else if (ch < 0x100)
           {
              return "\\u00" + Convert.ToString(ch, 16); //int.toHexString(ch);
           }
           else if (ch < 0x1000)
           {
              return "\\u0" + Convert.ToString(ch, 16); //int.toHexString(ch);
           }
           return "\\u" + Convert.ToString(ch, 16); //int.toHexString(ch);
       }

///    
///     <summary> * <p>Converts the string to the unicode format '\u0020'.</p>
///     * 
///     * <p>This format is the Java source code format.</p>
///     * 
///     * <p>If <code>null</code> is passed in, <code>null</code> will be returned.</p>
///     *
///     * <pre>
///     *   CharUtils.unicodeEscaped(null) = null
///     *   CharUtils.unicodeEscaped(' ')  = "\u0020"
///     *   CharUtils.unicodeEscaped('A')  = "\u0041"
///     * </pre>
///     *  </summary>
///     * <param name="ch">  the character to convert, may be null </param>
///     * <returns> the escaped unicode string, null if null input </returns>
///     
       //public static string unicodeEscaped(char ch)
       //{
       //    if (ch == null)
       //    {
       //        return null;
       //    }
       //    return unicodeEscaped(ch.charValue());
       //}

    //--------------------------------------------------------------------------
///    
///     <summary> * <p>Checks whether the character is ASCII 7 bit.</p>
///     *
///     * <pre>
///     *   CharUtils.isAscii('a')  = true
///     *   CharUtils.isAscii('A')  = true
///     *   CharUtils.isAscii('3')  = true
///     *   CharUtils.isAscii('-')  = true
///     *   CharUtils.isAscii('\n') = true
///     *   CharUtils.isAscii('&copy;') = false
///     * </pre>
///     *  </summary>
///     * <param name="ch">  the character to check </param>
///     * <returns> true if less than 128 </returns>
///     
       public static bool isAscii(char ch)
       {
           return ch < 128;
       }

///    
///     <summary> * <p>Checks whether the character is ASCII 7 bit printable.</p>
///     *
///     * <pre>
///     *   CharUtils.isAsciiPrintable('a')  = true
///     *   CharUtils.isAsciiPrintable('A')  = true
///     *   CharUtils.isAsciiPrintable('3')  = true
///     *   CharUtils.isAsciiPrintable('-')  = true
///     *   CharUtils.isAsciiPrintable('\n') = false
///     *   CharUtils.isAsciiPrintable('&copy;') = false
///     * </pre>
///     *  </summary>
///     * <param name="ch">  the character to check </param>
///     * <returns> true if between 32 and 126 inclusive </returns>
///     
       public static bool isAsciiPrintable(char ch)
       {
           return ch >= 32 && ch < 127;
       }

///    
///     <summary> * <p>Checks whether the character is ASCII 7 bit control.</p>
///     *
///     * <pre>
///     *   CharUtils.isAsciiControl('a')  = false
///     *   CharUtils.isAsciiControl('A')  = false
///     *   CharUtils.isAsciiControl('3')  = false
///     *   CharUtils.isAsciiControl('-')  = false
///     *   CharUtils.isAsciiControl('\n') = true
///     *   CharUtils.isAsciiControl('&copy;') = false
///     * </pre>
///     *  </summary>
///     * <param name="ch">  the character to check </param>
///     * <returns> true if less than 32 or equals 127 </returns>
///     
       public static bool isAsciiControl(char ch)
       {
           return ch < 32 || ch == 127;
       }

///    
///     <summary> * <p>Checks whether the character is ASCII 7 bit alphabetic.</p>
///     *
///     * <pre>
///     *   CharUtils.isAsciiAlpha('a')  = true
///     *   CharUtils.isAsciiAlpha('A')  = true
///     *   CharUtils.isAsciiAlpha('3')  = false
///     *   CharUtils.isAsciiAlpha('-')  = false
///     *   CharUtils.isAsciiAlpha('\n') = false
///     *   CharUtils.isAsciiAlpha('&copy;') = false
///     * </pre>
///     *  </summary>
///     * <param name="ch">  the character to check </param>
///     * <returns> true if between 65 and 90 or 97 and 122 inclusive </returns>
///     
       public static bool isAsciiAlpha(char ch)
       {
           return (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z');
       }

///    
///     <summary> * <p>Checks whether the character is ASCII 7 bit alphabetic upper case.</p>
///     *
///     * <pre>
///     *   CharUtils.isAsciiAlphaUpper('a')  = false
///     *   CharUtils.isAsciiAlphaUpper('A')  = true
///     *   CharUtils.isAsciiAlphaUpper('3')  = false
///     *   CharUtils.isAsciiAlphaUpper('-')  = false
///     *   CharUtils.isAsciiAlphaUpper('\n') = false
///     *   CharUtils.isAsciiAlphaUpper('&copy;') = false
///     * </pre>
///     *  </summary>
///     * <param name="ch">  the character to check </param>
///     * <returns> true if between 65 and 90 inclusive </returns>
///     
       public static bool isAsciiAlphaUpper(char ch)
       {
           return ch >= 'A' && ch <= 'Z';
       }

///    
///     <summary> * <p>Checks whether the character is ASCII 7 bit alphabetic lower case.</p>
///     *
///     * <pre>
///     *   CharUtils.isAsciiAlphaLower('a')  = true
///     *   CharUtils.isAsciiAlphaLower('A')  = false
///     *   CharUtils.isAsciiAlphaLower('3')  = false
///     *   CharUtils.isAsciiAlphaLower('-')  = false
///     *   CharUtils.isAsciiAlphaLower('\n') = false
///     *   CharUtils.isAsciiAlphaLower('&copy;') = false
///     * </pre>
///     *  </summary>
///     * <param name="ch">  the character to check </param>
///     * <returns> true if between 97 and 122 inclusive </returns>
///     
       public static bool isAsciiAlphaLower(char ch)
       {
           return ch >= 'a' && ch <= 'z';
       }

///    
///     <summary> * <p>Checks whether the character is ASCII 7 bit numeric.</p>
///     *
///     * <pre>
///     *   CharUtils.isAsciiNumeric('a')  = false
///     *   CharUtils.isAsciiNumeric('A')  = false
///     *   CharUtils.isAsciiNumeric('3')  = true
///     *   CharUtils.isAsciiNumeric('-')  = false
///     *   CharUtils.isAsciiNumeric('\n') = false
///     *   CharUtils.isAsciiNumeric('&copy;') = false
///     * </pre>
///     *  </summary>
///     * <param name="ch">  the character to check </param>
///     * <returns> true if between 48 and 57 inclusive </returns>
///     
       public static bool isAsciiNumeric(char ch)
       {
           return ch >= '0' && ch <= '9';
       }

///    
///     <summary> * <p>Checks whether the character is ASCII 7 bit numeric.</p>
///     *
///     * <pre>
///     *   CharUtils.isAsciiAlphanumeric('a')  = true
///     *   CharUtils.isAsciiAlphanumeric('A')  = true
///     *   CharUtils.isAsciiAlphanumeric('3')  = true
///     *   CharUtils.isAsciiAlphanumeric('-')  = false
///     *   CharUtils.isAsciiAlphanumeric('\n') = false
///     *   CharUtils.isAsciiAlphanumeric('&copy;') = false
///     * </pre>
///     *  </summary>
///     * <param name="ch">  the character to check </param>
///     * <returns> true if between 48 and 57 or 65 and 90 or 97 and 122 inclusive </returns>
///     
       public static bool isAsciiAlphanumeric(char ch)
       {
           return (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z') || (ch >= '0' && ch <= '9');
       }

   }

}