
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
 * Licensed to the Apache Software Foundation (ASF) under one or more
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

namespace org.apache.commons.lang.enums
{
   using System.Collections;


///
/// <summary> * <p>Utility class for accessing and manipulating <seealso cref="Enum"/>s.</p>
/// * </summary>
/// * <seealso cref= Enum </seealso>
/// * <seealso cref= ValuedEnum
/// * @author Stephen Colebourne
/// * @author Gary Gregory
/// * @since 2.1 (class existed in enum package from v1.0)
/// * @version $Id: EnumUtils.java 437554 2006-08-28 06:21:41Z bayard $ </seealso>
/// 
   public class EnumUtils
   {

///    
///     <summary> * Public constructor. This class should not normally be instantiated.
///     * @since 2.0 </summary>
///     
       public EnumUtils() : base()
       {
       }

///    
///     <summary> * <p>Gets an <code>Enum</code> object by class and name.</p>
///     *  </summary>
///     * <param name="enumClass">  the class of the <code>Enum</code> to get </param>
///     * <param name="name">  the name of the Enum to get, may be <code>null</code> </param>
///     * <returns> the enum object </returns>
///     * <exception cref="IllegalArgumentException"> if the enum class is <code>null</code> </exception>
///     
       public static Enum getEnum(System.Type enumClass, string name)
       {
           return Enum.getEnum(enumClass, name);
       }

///    
///     <summary> * <p>Gets a <code>ValuedEnum</code> object by class and value.</p>
///     *  </summary>
///     * <param name="enumClass">  the class of the <code>Enum</code> to get </param>
///     * <param name="value">  the value of the <code>Enum</code> to get </param>
///     * <returns> the enum object, or null if the enum does not exist </returns>
///     * <exception cref="IllegalArgumentException"> if the enum class is <code>null</code> </exception>
///     
       public static ValuedEnum getEnum(System.Type enumClass, int @value)
       {
           return (ValuedEnum) ValuedEnum.getEnum(enumClass, @value);
       }

///    
///     <summary> * <p>Gets the <code>Map</code> of <code>Enum</code> objects by
///     * name using the <code>Enum</code> class.</p>
///     *
///     * <p>If the requested class has no enum objects an empty
///     * <code>Map</code> is returned. The <code>Map</code> is unmodifiable.</p>
///     *  </summary>
///     * <param name="enumClass">  the class of the <code>Enum</code> to get </param>
///     * <returns> the enum object Map </returns>
///     * <exception cref="IllegalArgumentException"> if the enum class is <code>null</code> </exception>
///     * <exception cref="IllegalArgumentException"> if the enum class is not a subclass
///     *  of <code>Enum</code> </exception>
///     
       public static IDictionary getEnumMap(System.Type enumClass)
       {
           return Enum.getEnumMap(enumClass);
       }

///    
///     <summary> * <p>Gets the <code>List</code> of <code>Enum</code> objects using
///     * the <code>Enum</code> class.</p>
///     *
///     * <p>The list is in the order that the objects were created
///     * (source code order).</p>
///     *
///     * <p>If the requested class has no enum objects an empty
///     * <code>List</code> is returned. The <code>List</code> is unmodifiable.</p>
///     *  </summary>
///     * <param name="enumClass">  the class of the Enum to get </param>
///     * <returns> the enum object Map </returns>
///     * <exception cref="IllegalArgumentException"> if the enum class is <code>null</code> </exception>
///     * <exception cref="IllegalArgumentException"> if the enum class is not a subclass
///     *  of <code>Enum</code> </exception>
///     
       public static IList getEnumList(System.Type enumClass)
       {
           return Enum.getEnumList(enumClass);
       }

///    
///     <summary> * <p>Gets an <code>Iterator</code> over the <code>Enum</code> objects
///     * in an <code>Enum</code> class.</p>
///     *
///     * <p>The iterator is in the order that the objects were created
///     * (source code order).</p>
///     *
///     * <p>If the requested class has no enum objects an empty
///     * <code>Iterator</code> is returned. The <code>Iterator</code>
///     * is unmodifiable.</p>
///     *  </summary>
///     * <param name="enumClass">  the class of the <code>Enum</code> to get </param>
///     * <returns> an <code>Iterator</code> of the <code>Enum</code> objects </returns>
///     * <exception cref="IllegalArgumentException"> if the enum class is <code>null</code> </exception>
///     * <exception cref="IllegalArgumentException"> if the enum class is not a subclass of <code>Enum</code> </exception>
///     
       public static IEnumerator iterator(System.Type enumClass)
       {
           return Enum.getEnumList(enumClass).GetEnumerator();
       }

   }

}