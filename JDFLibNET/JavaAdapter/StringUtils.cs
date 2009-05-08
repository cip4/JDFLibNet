
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
 * Duplicate the Java StringUtils functionality needed by the rest of the solution
 */

namespace org.apache.commons.lang
{
   using System;
   using System.Collections;
   using System.Text;

   public class StringUtils
   {

      /// <summary>
      /// Checks if a String is empty ("") or null.
      /// </summary>
      /// <param name="str">the String to check, may be null</param>
      /// <returns>True if the String is empty or null</returns>
       public static bool IsEmpty(string str)
       {
           return str == null || str.Length == 0;
       }



       /// <summary>
       /// Checks if the String contains only unicode letters.
       /// </summary>
       /// <param name="str">the String to check, may be null</param>
       /// <returns>True if string only contains letters, and is non-null </returns>
       public static bool isAlpha(string str)
       {
           if (str == null)
           {
               return false;
           }
           int sz = str.Length;
           for (int i = 0; i < sz; i++)
           {
               if (char.IsLetter(str[i]) == false)
               {
                   return false;
               }
           }
           return true;
       }

    
       /// <summary>
       /// Checks if the String contains only unicode digits.
       /// A decimal point is not a unicode digit and returns false.
       /// </summary>
       /// <param name="str">the String to check, may be null</param>
       /// <returns>True if only contains digits, and is non-null </returns>
 
       public static bool isNumeric(string str)
       {
           if (str == null)
           {
               return false;
           }
           int sz = str.Length;
           for (int i = 0; i < sz; i++)
           {
               if (char.IsDigit(str[i]) == false)
               {
                   return false;
               }
           }
           return true;
       }

       
       /// <summary>
       /// Counts how many times the substring appears in the larger String.
       /// </summary>
       /// <param name="str">the String to check, may be null </param>
       /// <param name="sub">the substring to count, may be null </param>
       /// <returns>the number of occurrences, 0 if either String is null </returns>
       public static int countMatches(string str, string sub)
       {
          if (IsEmpty(str) || IsEmpty(sub))
          {
             return 0;
          }
          int count = 0;
          int idx = 0;
          while ((idx = str.IndexOf(sub, idx)) != -1)
          {
             count++;
             idx += sub.Length;
          }
          return count;
       }
   }
}