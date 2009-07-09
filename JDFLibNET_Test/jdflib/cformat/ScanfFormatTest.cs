
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
   using Microsoft.VisualStudio.TestTools.UnitTesting;

///
/// <summary> * Testing class for ScanfFormat. Run the <tt>main</tt> method to test the
/// * class.
/// *  </summary>
/// * <seealso cref= ScanfFormat
/// * @.author John E. Lloyd </seealso>
/// 
   [TestClass]
   public class ScanfFormatTest
   {
   // ~ Methods

///   
///	 <summary> * Tests the class ScanfFormat. If everything is OK, the string "Passed" is
///	 * printed, and the program exits with status 0. Otherwise, diagnostics and
///	 * a stack trace are printed, and the program exits with status 1. </summary>
///	 
      static void Main(string[] args)
      {
         test("foo %d bar", -1, 'd', null, "foo ", " bar");
         test("%d", -1, 'd', null, null, null);
         test("foo %% %123f bar", 123, 'f', null, "foo % ", " bar");
         test("f%% %% %12s %%bar", 12, 's', null, "f% % ", " %bar");
         test("xxx %[123e*&^] %%bar", -1, '[', "123e*&^", "xxx ", " %bar");

         test("xxx %[123e*&^] %%bar", -1, '[', "123e*&^", "xxx ", " %bar");
         test("x%[^]]%%bar", -1, '[', "^]", "x", "%bar");
         test("x%[^ ]]%%bar", -1, '[', "^ ", "x", "]%bar");
         test("x%[]]%%bar", -1, '[', "]", "x", "%bar");
         test("x%[ ]]%%bar", -1, '[', " ", "x", "]%bar");
         test("x%[^0-9-ad-8-]%%bar", -1, '[', "^0-9-ad-8-", "x", "%bar");

      // test("foo %", "Format string terminates with '%'");
      // test("foo %123", "Premature end of format string");
      // test("foo %0d", "Zero field width specified");
      // test("foo %w", "Illegal conversion character 'w'");
      // test("foo %[123sd", "Premature end of format string");
      // test("foo %[-123sd]", -1, '[', "-123sd", "foo ", null);
      // test("foo %[--123sd]",
      // "Misplaced '-' in character match spec '[--123sd]'");
      // test("foo %[^--123sd]",
      // "Misplaced '-' in character match spec '[^--123sd]'");
      // test("foo %[^1-23--sd]",
      // "Misplaced '-' in character match spec '[^1-23--sd]'");
      // test("foo %[^1-23sd--]",
      // "Misplaced '-' in character match spec '[^1-23sd--]'");
      // test("foo %d xx %x", "Extra '%' in format string");
      // test("foo %d xx %", "Extra '%' in format string");
         Console.WriteLine("\nPassed\n");
      }

   // private static void myAssert(boolean ok)
   // {
   // if (!ok)
   // {
   // System.out.print("Assertion failed");
   // new Throwable().printStackTrace();
   // System.exit(1);
   // }
   // }
      private static bool streq(string s1, string s2)
      {
//		if ((s1 == null) && (s2 != null))
//		{
//			return false;
//		}
//		else if ((s1 != null) && (s2 == null))
//		{
//			return false;
//		}
//		else if ((s1 == null) && (s2 == null))
//		{
//			return true;
//		}
//		else
//		{
//			return s1.equals(s2);
//		}

         if (s1 == null)
         {
            return s2 == null;
         }

         return s1.Equals(s2);
      }

   // private static void test(String s, String errMsg)
   // {
   // boolean tripped = false;
   //
   // try
   // {
   // ScanfFormat fmt = new ScanfFormat(s);
   // fmt = null;
   // }
   // catch (IllegalArgumentException e)
   // {
   // if (!e.getMessage().equals(errMsg))
   // {
   // System.out.println("format '" + s + "'");
   // e.printStackTrace();
   // System.exit(1);
   // }
   //
   // tripped = true;
   // }
   // catch (Exception e)
   // {
   // System.out.println("format '" + s + "'");
   // e.printStackTrace();
   // System.exit(1);
   // }
   //
   // if (!tripped)
   // {
   // System.out.println("format '" + s + "'");
   // System.out.println("no error generated");
   // System.exit(1);
   // }
   // }
      private static void test(string s, int width, int type, string cmatch, string prefix, string suffix)
      {
         try
         {
            ScanfFormat fmt = new ScanfFormat(s);

            if (fmt.width != width)
            {
               Console.WriteLine("format '" + s + "'");
               Console.WriteLine("width=" + fmt.width + " vs. " + width);
               Environment.Exit(1);
            }

            if (fmt.type != type)
            {
               Console.WriteLine("format '" + s + "'");
               Console.WriteLine("type=" + (char) fmt.type + " vs. " + (char) type);
               Environment.Exit(1);
            }

            if (!streq(fmt.cmatch, cmatch))
            {
               Console.WriteLine("format '" + s + "'");
               Console.WriteLine("cmatch=" + fmt.cmatch + " vs. " + cmatch);
               Environment.Exit(1);
            }

            if (!streq(fmt.prefix, prefix))
            {
               Console.WriteLine("format '" + s + "'");
               Console.WriteLine("prefix=" + fmt.prefix + " vs. " + prefix);
               Environment.Exit(1);
            }

            if (!streq(fmt.suffix, suffix))
            {
               Console.WriteLine("format '" + s + "'");
               Console.WriteLine("suffix=" + fmt.suffix + " vs. " + suffix);
               Environment.Exit(1);
            }
         }
         catch (Exception e)
         {
            Console.WriteLine("Exception forming format " + s);
            SupportClass.WriteStackTrace(e, Console.Error);
            Environment.Exit(1);
         }
      }
   }
}