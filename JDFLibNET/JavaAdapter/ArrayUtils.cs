
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
 * Duplicate the Java ArrayUtils functionality needed by the rest of the solution
 */


namespace org.apache.commons.lang
{
   using System;

   /// <summary>
   /// Array Utils support class
   /// </summary>
   public class ArrayUtils
   {

      public static string[] EMPTY_STRING_ARRAY = new string[0];

      /// <summary>
      /// Searches array of strings for given item
      /// </summary>
      /// <param name="array"></param>
      /// <param name="item"></param>
      /// <returns>true if item is contained in string array</returns>
      public static bool Contains (string[] array, string item)
      {
         if ((array != null) && (array.Length > 0))
         {
            for (int i = 0; i < array.Length; ++i)
            {
               if (array[i] == item)
                  return true;
            }
         }
         return false;
      }

      /// <summary>
      /// Find array index of item in string array
      /// </summary>
      /// <param name="array"></param>
      /// <param name="item"></param>
      /// <returns>Array index of item in string array or -1 if not found</returns>
      public static int IndexOf(string[] array, string item)
      {
         if ((array != null) && (array.Length > 0))
         {
            for (int i = 0; i < array.Length; ++i)
            {
               if (array[i] == item)
                  return i;
            }
         }
         return -1;
      }


      /// <summary>
      /// Determine if character array is empty
      /// </summary>
      /// <param name="array"></param>
      /// <returns>true if character array is empty</returns>
      public static bool IsEmpty(char[] array)
      {
         if ((array ==null) || (array.Length == 0))
         {
            return true;
         }

         return false;
      }


      /// <summary>
      /// Reverse the elements of an array
      /// </summary>
      /// <param name="array"></param>
      public static void reverse(object[] array)
      {
         if ((array == null) || (array.Length == 0))
         {
            return;
         }
         int i = 0;
         int j = array.Length - 1;
         object tmp;
         while (j > i)
         {
            tmp = array[j];
            array[j] = array[i];
            array[i] = tmp;
            j--;
            i++;
         }
      }
   }
}