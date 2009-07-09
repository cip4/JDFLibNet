
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



namespace org.cip4.jdflib.cformat
{
   using System;
   using System.IO;
   using Microsoft.VisualStudio.TestTools.UnitTesting;


///
/// <summary> * Testing class for ScanfReader. Run the <tt>main</tt> method to test the
/// * class.
/// *  </summary>
/// * <seealso cref= ScanfReader
/// * @.author John E. Lloyd </seealso>
/// 
      [TestClass]
public class ScanfReaderTest
   {
   // ~ Instance fields

      internal ScanfReader reader;

   // ~ Constructors

   // private static void assert (boolean ok)
   // { if (!ok)
   // { Throwable e = new Throwable();
   // System.out.println ("Assertion failed:");
   // e.printStackTrace();
   // System.exit(1);
   // }
   // }
      internal ScanfReaderTest(string input)
      {
         reader = new ScanfReader(new StringReader(input));
      }

   // ~ Methods

///   
///	 <summary> * Tests the class ScanfReader. If everything is OK, the string "Passed" is
///	 * printed, and the program exits with status 0. Otherwise, diagnostics and
///	 * a stack trace are printed, and the program exits with status 1. </summary>
///	 
      static void Main(string[] args)
      {
         ScanfReaderTest test = new ScanfReaderTest("/gfhghda 0 0123 123 0xbeef 0XBeeF -45 +67" + " 45 45. .45 4.5 1.2E-0 1.33e+6");

         test.checkString("%s", "/gfhghda", null);
         test.checkInt('i', "%i", 0, null);
         test.checkInt('i', "%i", 83, null);
         test.checkInt('i', "%i", 123, null);
         test.checkInt('i', "%i", 0xbeef, null);
         test.checkInt('i', "%i", 0xbeef, null);
         test.checkInt('i', "%i", -45, null);
         test.checkInt('i', "%i", 67, null);
         test.checkDouble("%f", 45, null);
         test.checkDouble("%f", 45, null);
         test.checkDouble("%f",.45, null);
         test.checkDouble("%f", 4.5, null);
         test.checkDouble("%f", 1.2, null);
         test.checkDouble("%f", 1.33e6, null);

         test.checkString("%s", null, "EOF");
         test.checkInt('i', "%i", 0, "EOF");
         test.checkDouble("%f", 0, "EOF");
         test.checkChars("%[123]", null, "EOF");

         test = new ScanfReaderTest("hello \n \r \r\n \n\rfoo\n1234.0bar\r\n1\r\na\r\n\ra\n");

         test.checkString("%s", "hello", null);
         test.checkString("%s", "foo", null);
         test.checkLineAndCharNums(18, 6);
         test.checkRead(4, "\n123");
         test.checkLineAndCharNums(22, 7);
         test.checkDouble("%f", 4.0, null);
         test.checkLineAndCharNums(25, 7);
         test.checkRead(4, "bar\r");
         test.checkLineAndCharNums(29, 8);
         test.checkInt('i', "%i", 1, null);
         test.checkLineAndCharNums(31, 8);
         test.checkChars("%1c", "\r", null);
         test.checkLineAndCharNums(32, 9);
         test.checkRead(5, "\na\r\n\r");
         test.checkLineAndCharNums(37, 11);
         test.checkString("%s", "a", null);
         test.checkRead(1, "\n");
         test.checkLineAndCharNums(39, 12);
         test.checkRead(4, null);
         test.checkRead(4, null);

         test = new ScanfReaderTest("\n\rhi there");

         test.checkRead(1, "\n");
         test.checkRead(3, "\rhi");
         test.checkString("%s", "there", null);
         test.checkRead(4, null);
         test.checkRead(4, null);
         test.checkLineAndCharNums(10, 3);

         test = new ScanfReaderTest("abcde   12345   abcde  foobar  abcdef \t hithere" + "xyz");

         test.checkString("ab%s", "cde", null);
         test.checkString(" 12%2s5", "34", null);
         test.checkString(" a%2s", "bc", null);
         test.checkString("%s", "de", null);
         test.checkString("%1s", "f", null);
         test.checkString("%1s", "o", null);
         test.checkString("ob%1sr", "a", null);
         test.checkString(" %6s ", "abcdef", null);
         test.checkChars("%2cthere", "hi", null);

         test.checkString("%c", null, "Illegal conversion character 'c'");
         test.checkString(" %s", null, "No white space to match white space in format");
         test.checkString("y%s", null, "Char 'x' does not match char 'y' in format");

         test.checkChar("%c", 'x', null);

         test.checkChar("%x", '\0', "Illegal conversion character 'x'");
         test.checkChar(" %c", '\0', "No white space to match white space in format");
         test.checkChar("z%c", '\0', "Char 'y' does not match char 'z' in format");

         test.checkChar("%c", 'y', null);

         test.checkChars("%x", null, "Illegal conversion character 'x'");
         test.checkChars(" %c", null, "No white space to match white space in format");
         test.checkChar("y%c", '\0', "Char 'z' does not match char 'y' in format");

         test.checkChars("%1c", "z", null);

         test = new ScanfReaderTest("0123456789 ]-^-bdfmwax");

      // tests of [] character notation
         test.checkChar("0%[012]2", '1', null);
         test.checkChar("%[012]", '\0', "Input char '3' does not match '[012]'");
         test.checkChars("%[012]", null, "Input char '3' does not match '[012]'");
         test.checkChar(" %[34]", '\0', "No white space to match white space in format");
         test.checkChar("%[34]", '3', null);
         test.checkChars("%[34]", "4", null);
         test.checkChars("%3[345678]", "567", null);
         test.checkChars("%[abc4-9]", "8", null);
         test.checkChars("%[^abc4-9]", null, "Input char '9' does not match '[^abc4-9]'");

         test.checkChar("%[^abc]", '9', null);
         test.checkChar("%[^ ]", '\0', "Input char ' ' does not match '[^ ]'");
         test.checkChar("%[]]", '\0', "Input char ' ' does not match '[]]'");
         test.checkChar("%[0-9-]", '\0', "Input char ' ' does not match '[0-9-]'");
         test.checkChar("%[^-]", ' ', null);
         test.checkChars("%3[]^-]", "]-^", null);
         test.checkChars("%[0-9-]", "-", null);
         test.checkChars("%5[b-f-w]", "bdfmw", null);
         test.checkChars("%[b-f-w]", null, "Input char 'a' does not match '[b-f-w]'");
         test.checkChars("%[a^b]", "a", null);
         test.checkChars("%[b-f-w]", null, "Input char 'x' does not match '[b-f-w]'");
         test.checkChars("%[z-y]", null, "Input char 'x' does not match '[z-y]'");
         test.checkChars("%[w-q]", null, "Input char 'x' does not match '[w-q]'");
         test.checkChars("%[z-w]", "x", null);

      // integer read tests
         test = new ScanfReaderTest("0 012 123 123456 0 012 123 2345 0 " + "deadbeef DEADBeeF deadbeef " + "0 012 123 0xbeef 1230xbe012" + " xy123-34-67 +45+98 123z beef" + " xy123-34-67 +45+54 123z beef" + " xy123-34-67 +45+54 123z g" + " 12389beef" + " xy123-34-67 +45+98 123z b0x123 -0x345 +0 -0 0 -0111 +012 " + "-0x1230x0x x123z x012z x-0x45z x+67z");

         test.checkInt('d', "%d", 0, null);
         test.checkInt('d', "%d", 12, null);
         test.checkInt('d', "%d", 123, null);
         test.checkInt('d', "%3d", 123, null);
         test.checkInt('d', "%3d", 456, null);
         test.checkInt('o', "%o", 0, null);
//JAVA TO VB & C# CONVERTER TODO TASK: Octal literals cannot be represented in C#:
//         test.checkInt('o', "%o", 012, null);
//JAVA TO VB & C# CONVERTER TODO TASK: Octal literals cannot be represented in C#:
//         test.checkInt('o', "%o", 0123, null);
//JAVA TO VB & C# CONVERTER TODO TASK: Octal literals cannot be represented in C#:
//         test.checkInt('o', "%1o", 02, null);
//JAVA TO VB & C# CONVERTER TODO TASK: Octal literals cannot be represented in C#:
//         test.checkInt('o', "%3o", 0345, null);
         test.checkInt('x', "%x", 0, null);
         uint badInt = 0xdeadbeef;
         test.checkInt('x', "%x", (int) badInt, null);
         test.checkInt('x', "%x", (int) badInt, null);
         test.checkInt('x', "%4x", 0xdead, null);
         test.checkInt('x', "%4x", 0xbeef, null);
         test.checkInt('i', "%i", 0, null);
//JAVA TO VB & C# CONVERTER TODO TASK: Octal literals cannot be represented in C#:
         test.checkInt('i', "%i", 012, null);
         test.checkInt('i', "%i", 123, null);
         test.checkInt('i', "%i", 0xbeef, null);
         test.checkInt('i', "%2i", 12, null);
         test.checkInt('i', "%1i", 3, null);
         test.checkInt('i', "%4i", 0xbe, null);
//JAVA TO VB & C# CONVERTER TODO TASK: Octal literals cannot be represented in C#:
         test.checkInt('i', "%3i", 012, null);

         test.checkChars("%2c", " x", null);

         test.checkInt('d', "%x", 0, "Illegal conversion character 'x'");
         test.checkInt('d', " %d", 0, "No white space to match white space in format");
         test.checkInt('d', "yz%d", 0, "Char '1' does not match char 'z' in format");
         test.checkInt('d', "%d", 123, null);
         test.checkInt('d', "%d", -34, null);
         test.checkInt('d', "-%d", 67, null);
         test.checkInt('d', "%d", 45, null);
         test.checkInt('d', "%d", 98, null);
         test.checkInt('d', "%dzz", 123, "Char ' ' does not match char 'z' in format");
         test.checkInt('d', "%d", 0, "Malformed decimal integer");

         test.checkChars("%6c", "beef x", null);

         test.checkInt('o', "%x", 0, "Illegal conversion character 'x'");
         test.checkInt('o', " %o", 0, "No white space to match white space in format");
         test.checkInt('o', "yz%o", 0, "Char '1' does not match char 'z' in format");
//JAVA TO VB & C# CONVERTER TODO TASK: Octal literals cannot be represented in C#:
         test.checkInt('o', "%o", 0123, null);
//JAVA TO VB & C# CONVERTER TODO TASK: Octal literals cannot be represented in C#:
         test.checkInt('o', "-%o", 034, null);
//JAVA TO VB & C# CONVERTER TODO TASK: Octal literals cannot be represented in C#:
         test.checkInt('o', "-%o", 067, null);
//JAVA TO VB & C# CONVERTER TODO TASK: Octal literals cannot be represented in C#:
         test.checkInt('o', " +%o", 045, null);
//JAVA TO VB & C# CONVERTER TODO TASK: Octal literals cannot be represented in C#:
         test.checkInt('o', "+%o", 054, null);
//JAVA TO VB & C# CONVERTER TODO TASK: Octal literals cannot be represented in C#:
         test.checkInt('o', "%ozz", 0123, "Char ' ' does not match char 'z' in format");
         test.checkInt('o', "%o", 0, "Malformed octal integer");

         test.checkChars("%6c", "beef x", null);

         test.checkInt('x', "%o", 0, "Illegal conversion character 'o'");
         test.checkInt('x', " %x", 0, "No white space to match white space in format");
         test.checkInt('x', "yz%x", 0, "Char '1' does not match char 'z' in format");
         test.checkInt('x', "%x", 0x123, null);
         test.checkInt('x', "-%x", 0x34, null);
         test.checkInt('x', "-%x", 0x67, null);
         test.checkInt('x', " +%x", 0x45, null);
         test.checkInt('x', "+%x", 0x54, null);
         test.checkInt('x', "%xzz", 0x123, "Char ' ' does not match char 'z' in format");
         test.checkInt('x', "%x", 0, "Malformed hex integer");

         test.checkChar("%c", 'g', null);
//JAVA TO VB & C# CONVERTER TODO TASK: Octal literals cannot be represented in C#:
         test.checkInt('o', "%o", 0123, null);
         test.checkInt('d', "%d", 89, null);
         test.checkInt('x', "%x", 0xbeef, null);

         test.checkChars("%2c", " x", null);

         test.checkInt('i', "%g", 0, "Illegal conversion character 'g'");
         test.checkInt('i', " %i", 0, "No white space to match white space in format");
         test.checkInt('i', "yz%i", 0, "Char '1' does not match char 'z' in format");
         test.checkInt('i', "%i", 123, null);
         test.checkInt('i', "%i", -34, null);
         test.checkInt('i', "%i", -67, null);
         test.checkInt('i', "%i", 45, null);
         test.checkInt('i', "%i", 98, null);
         test.checkInt('i', "%izz", 123, "Char ' ' does not match char 'z' in format");
         test.checkInt('i', "%i", 0, "Malformed decimal integer");
         test.checkChar("%c", 'b', null);
         test.checkInt('i', "%i", 0x123, null);
         test.checkInt('i', "%i", -0x345, null);
         test.checkInt('i', "%i", 0, null);
         test.checkInt('i', "%i", -0, null);
         test.checkInt('i', "%i", 0, null);
//JAVA TO VB & C# CONVERTER TODO TASK: Octal literals cannot be represented in C#:
         test.checkInt('i', "%i", -0111, null);
//JAVA TO VB & C# CONVERTER TODO TASK: Octal literals cannot be represented in C#:
         test.checkInt('i', "%i", 012, null);

         test.checkInt('i', "%1i", 0, "Malformed integer");
         test.checkInt('i', "%2i", -0, null);
         test.checkInt('i', "x%2i", 12, null);
         test.checkInt('i', "%1i", 3, null);
         test.checkInt('i', "%2i", 0, "Malformed hex integer");
         test.checkInt('i', "x%i", 0, "Malformed hex integer");

         test.checkInt('i', " x%iz", 123, null);
//JAVA TO VB & C# CONVERTER TODO TASK: Octal literals cannot be represented in C#:
         test.checkInt('i', " x%iz", 012, null);
         test.checkInt('i', " x%iz", -0x45, null);
         test.checkInt('i', " x%iz", 67, null);

      // Floating point tests
         test = new ScanfReaderTest("0 1 123 1234 b12pp0.1 10.33 .44 " + "0.0 0.1e-4 1e+3 1e-4 1e5 1.1e-6" + "xy2.3. 11 .e4 1.4e-  1.5e 3.4g" + "yy12.345 2 .456e-1.53e20");

         test.checkDouble("%f", 0, null);
         test.checkDouble("%f", 1, null);
         test.checkDouble("%f", 123, null);
         test.checkDouble(" 1%2f4", 23, null);
         test.checkDouble(" b%f", 12, null);
         test.checkDouble("pp%f", 0.1, null);
         test.checkDouble("%f", 10.33, null);
         test.checkDouble("%f",.44, null);
         test.checkDouble("%f", 0.0, null);
         test.checkDouble("%f", 0.1e-4, null);
         test.checkDouble("%f", 1e+3, null);
         test.checkDouble("%f", 1e-4, null);
         test.checkDouble("%f", 1e5, null);
         test.checkDouble("%f", 1.1e-6, null);

         test.checkDouble("%z", 0, "Illegal conversion character 'z'");
         test.checkChar("%c", 'x', null);
         test.checkDouble(" %f", 0, "No white space to match white space in format");
         test.checkDouble("x%f", 0, "Char 'y' does not match char 'x' in format");
         test.checkDouble("y%f", 2.3, null);
         test.checkDouble("%f", 0, "Malformed floating point number: no digits");
         test.checkDouble("%f", 11, null);
         test.checkDouble("%f", 0, "Malformed floating point number: no digits");
         test.checkInt('i', "e%i", 4, null);
         test.checkDouble("%f", 0, "Malformed floating point number: no digits in exponent");
         test.checkDouble("%f", 0, "Malformed floating point number: no digits in exponent");
         test.checkDouble("%f", 3.4, null);
         test.checkChar("%c", 'g', null);

         test.checkDouble("yy%4f45", 12.3, null);
         test.checkDouble("%1f", 2, null);
         test.checkDouble("%1f", 0, "Malformed floating point number: no digits");
         test.checkDouble("%2f", 45, null);
         test.checkDouble("%3f", 0, "Malformed floating point number: no digits in exponent");
         test.checkDouble("%3f", 1.5, null);
         test.checkDouble("%3f", 3e2, null);
         test.checkChar("%c", '0', null);

         Console.WriteLine("\nPassed\n");
      }

      internal virtual void checkChar(string s, char val, string emsg)
      {
         Exception ex = null;
         char res = '\0';

         try
         {
            res = reader.scanChar(s);
         }
         catch (Exception e)
         {
            ex = e;
         }

         checkException(ex, emsg);

         if (emsg != null)
         {
            return;
         }

         if (res != val)
         {
            Console.WriteLine("Expected char " + val + ", got " + res);
            SupportClass.WriteStackTrace(new System.Exception(), Console.Error);
            Environment.Exit(1);
         }
      }

      internal virtual void checkChars(string s, string valStr, string emsg)
      {
         Exception ex = null;
         char[] res = null;
         string resStr;

         try
         {
            res = reader.scanChars(s);
         }
         catch (Exception e)
         {
            ex = e;
         }

         checkException(ex, emsg);

         if (emsg != null)
         {
            return;
         }

         resStr = Convert.ToString(res);

         if (!resStr.Equals(valStr))
         {
            Console.WriteLine("Expected chars '" + valStr + "', got '" + resStr + "'");
            SupportClass.WriteStackTrace(new System.Exception(), Console.Error);
            Environment.Exit(1);
         }
      }

      internal virtual void checkDouble(string s, double val, string emsg)
      {
         Exception ex = null;
         double res = 0;

         try
         {
            res = reader.scanDouble(s);
         }
         catch (Exception e)
         {
            ex = e;
         }

         checkException(ex, emsg);

         if (emsg != null)
         {
            return;
         }

         if (res != val)
         {
            Console.WriteLine("Expected double " + val + ", got " + res);
            SupportClass.WriteStackTrace(new System.Exception(), Console.Error);
            Environment.Exit(1);
         }
      }

      internal virtual void checkInt(char code, string s, int val, string emsg)
      {
         Exception ex = null;
         int res = 0;

         try
         {
            switch (code)
            {
            case 'i':
            {
               res = reader.scanInt(s);

               break;
            }

            case 'd':
            {
               res = (int) reader.scanDec(s);

               break;
            }

            case 'x':
            {
               res = (int) reader.scanHex(s);

               break;
            }

            case 'o':
            {
               res = (int) reader.scanOct(s);

               break;
            }
            }
         }
         catch (Exception e)
         {
            ex = e;
         }

         checkException(ex, emsg);

         if (emsg != null)
         {
            return;
         }

         if (res != val)
         {
            Console.WriteLine("Expected '" + code + "' " + val + ", got " + res);
            SupportClass.WriteStackTrace(new System.Exception(), Console.Error);
            Environment.Exit(1);
         }
      }

      internal virtual void checkString(string s, string val, string emsg)
      {
         Exception ex = null;
         string res = null;

         try
         {
            res = reader.scanString(s);
         }
         catch (Exception e)
         {
            ex = e;
         }

         checkException(ex, emsg);

         if (emsg != null)
         {
            return;
         }

         if (res != null && !res.Equals(val))
         {
            Console.WriteLine("Expected string " + val + ", got " + res);
            SupportClass.WriteStackTrace(new System.Exception(), Console.Error);
            Environment.Exit(1);
         }
      }

      private void checkException(Exception e, string emsg)
      {
         if ((emsg == null) && (e != null))
         {
            Console.WriteLine("Unexpected exception:");
            SupportClass.WriteStackTrace(e, Console.Error);
            Environment.Exit(1);
         }
         else if ((emsg != null) && (e == null))
         {
            Console.WriteLine("Expected exception:\n" + emsg + "\nbut got none");
            SupportClass.WriteStackTrace(new System.Exception(), Console.Error);
            Environment.Exit(1);
         }
         else if ((emsg != null) && (e != null))
         {
            if (!emsg.Equals(e.Message))
            {
               Console.WriteLine("Expected exception:\n" + emsg + "\nbut got:\n" + e.Message);
               SupportClass.WriteStackTrace(new System.Exception(), Console.Error);
               Environment.Exit(1);
            }
         }
      }

      private void checkLineAndCharNums(int numc, int numl)
      {
         bool pass = false;

         if (reader.getLineNumber() != numl)
         {
            Console.WriteLine("line number is " + reader.getLineNumber() + ", expected " + numl);
         }
         else if (reader.getCharNumber() != numc)
         {
            Console.WriteLine("char number is " + reader.getCharNumber() + ", expected " + numc);
         }
         else
         {
            pass = true;
         }

         if (!pass)
         {
            SupportClass.WriteStackTrace(new System.Exception(), Console.Error);
            Environment.Exit(1);
         }
      }

      private void checkRead(int n, string s)
      {
         char[] buf = new char[n];
         bool pass = false;
         int k = 0;

         try
         {
            k = reader.Read(buf, 0, n);
         }
         catch (Exception e)
         {
            SupportClass.WriteStackTrace(e, Console.Error);
            Environment.Exit(1);
         }

         if ((k == -1) && (s != null))
         {
            Console.WriteLine("read returns -1, expected " + s.Length);
         }
         else if (s == null)
         {
            if (k != -1)
            {
               Console.WriteLine("read returns " + k + ", expected -1");
            }
            else
            {
               pass = true;
            }
         }
         else if (s.Length != k)
         {
            Console.WriteLine("read returns " + k + ", expected " + s.Length);
         }
         else
         {
            string res = new string(buf, 0, k);

            if (!res.Equals(s))
            {
               Console.WriteLine("read returns '" + res + "', expected '" + s + "'");
            }
            else
            {
               pass = true;
            }
         }

         if (!pass)
         {
            SupportClass.WriteStackTrace(new System.Exception(), Console.Error);
            Environment.Exit(1);
         }
      }
   }
}