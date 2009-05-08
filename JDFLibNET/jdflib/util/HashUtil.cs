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



/* HashUtil.cs
 * 
 * Copyright (c) 2004 Heidelberger Druckmaschinen AG, All Rights Reserved. */

namespace org.cip4.jdflib.util
{

   ///
   /// <summary> * This class provides some hashCode calculation utilities. Use the static methods of this class to generate
   /// * 
   /// * <pre>
   /// * hashCode()
   /// * </pre>
   /// * 
   /// * values in data objects. For example, to calculate the hashCode of a data object, use the methods of this class as
   /// * follows:
   /// * 
   /// * <pre>
   /// * int myIntField;
   /// * Object myObject;
   /// * 
   /// * public int hashCode()
   /// * {
   /// * 	//        int hash = super.hashCode();    // use when not extending Object
   /// * 	int hash = 0; // use when extending Object
   /// * 	hash = HashUtil.hashCode(hash, myIntField);
   /// * 	hash = HashUtil.hashCode(hash, myObject);
   /// * 	return hash;
   /// * }
   /// * </pre>
   /// * 
   /// * <br>
   /// * Hint: Start your hashCode calculation depending on the object your data object extends. If you extend Object
   /// * initialize your hash value to 0. Otherwise initialize hash to super.hashCode(). See the example code.
   /// * 
   /// * @author Manfred Steinbach </summary>
   /// 
   public class HashUtil : System.Object
   {
      public const int PRIME = 1000003;

      private HashUtil()
         : base()
      { // Prevent an instantiation

      }

      public static int GetHashCode(int source, bool x)
      {
         return PRIME * source + (x ? 1 : 0);
      }

      public static int GetHashCode(int source, int x)
      {
         return PRIME * source + x;
      }

      public static int GetHashCode(int source, long x)
      {
         //return PRIME * source + (int)(PRIME * ((ulong)x >> 32) + (x & 0xFFFFFFFF));
         return PRIME * source + (int)(PRIME * (SupportClass.URShift(x, 32)) + (x & unchecked((int)0xFFFFFFFF)));
      }

      public static int GetHashCode(int source, float x)
      {
         //return GetHashCode(source, ((new float(x).Equals(new float(0.0))) ? 0 : float.floatToIntBits(x)));
         return GetHashCode(source, ((x.Equals(0.0)) ? 0 : SupportClass.floatToIntBits(x)));
      }

      public static int GetHashCode(int source, double x)
      {
         //return GetHashCode(source, ((new double(x).Equals(new double(0.0))) ? 0L : double.doubleToLongBits(x)));
         return GetHashCode(source, ((x.Equals(0.0)) ? 0L : SupportClass.doubleToLongBits(x)));
      }

      public static int GetHashCode(int source, object x)
      {
         return (null == x) ? 0 : PRIME * source + x.GetHashCode();
      }

      public static int GetHashCode(int source, object[] x)
      {
         int sourceLocal = source;

         if (null != x)
         {
            int len = x.Length;
            for (int i = 0; i < len; i++)
            {
               sourceLocal = GetHashCode(sourceLocal, x[i]);
            }
         }

         return sourceLocal;
      }
   }
}
