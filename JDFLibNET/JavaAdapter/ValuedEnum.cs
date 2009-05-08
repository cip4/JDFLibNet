
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
 }
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
   using System;
   using System.Collections;
   using System.Reflection;


   //using ClassUtils = org.apache.commons.lang.ClassUtils;

///
/// <summary> 
/// Abstract superclass for type-safe enums with integer values suitable
/// for use in switch statements.
/// </summary>>
/// *
/// * <p><em>NOTE:</em>Due to the way in which Java ClassLoaders work, comparing
/// * <code>Enum</code> objects should always be done using the equals() method,
/// * not <code>==</code>. The equals() method will try <code>==</code> first so
/// * in most cases the effect is the same.</p>
/// *
/// * <p>To use this class, it must be subclassed. For example:</p>
/// *
/// * <pre>
/// * public final class JavaVersionEnum extends ValuedEnum {
/// *   //standard enums for version of JVM
/// *   public static final int  JAVA1_0_VALUE  = 100;
/// *   public static final int  JAVA1_1_VALUE  = 110;
/// *   public static final int  JAVA1_2_VALUE  = 120;
/// *   public static final int  JAVA1_3_VALUE  = 130;
/// *   public static final JavaVersionEnum  JAVA1_0  = new JavaVersionEnum( "Java 1.0", JAVA1_0_VALUE );
/// *   public static final JavaVersionEnum  JAVA1_1  = new JavaVersionEnum( "Java 1.1", JAVA1_1_VALUE );
/// *   public static final JavaVersionEnum  JAVA1_2  = new JavaVersionEnum( "Java 1.2", JAVA1_2_VALUE );
/// *   public static final JavaVersionEnum  JAVA1_3  = new JavaVersionEnum( "Java 1.3", JAVA1_3_VALUE );
/// *
/// *   private JavaVersionEnum(String name, int value) {
/// *     super( name, value );
/// *   }
/// * 
/// *   public static JavaVersionEnum getEnum(String javaVersion) {
/// *     return (JavaVersionEnum) getEnum(JavaVersionEnum.class, javaVersion);
/// *   }
/// * 
/// *   public static JavaVersionEnum getEnum(int javaVersion) {
/// *     return (JavaVersionEnum) getEnum(JavaVersionEnum.class, javaVersion);
/// *   }
/// * 
/// *   public static IDictionary getEnumMap() {
/// *     return getEnumMap(JavaVersionEnum.class);
/// *   }
/// * 
/// *   public static IList getEnumList() {
/// *     return getEnumList(JavaVersionEnum.class);
/// *   }
/// * 
/// *   public static Iterator iterator() {
/// *     return iterator(JavaVersionEnum.class);
/// *   }
/// * }
/// * </pre>
/// *
/// * <p><em>NOTE:</em>These are declared <code>final</code>, so compilers may 
/// * inline the code. Ensure you recompile everything when using final. </p>
/// *
/// * <p>The above class could then be used as follows:</p>
/// *
/// * <pre>
/// * public void doSomething(JavaVersionEnum ver) {
/// *   switch (ver.getValue()) {
/// *     case JAVA1_0_VALUE:
/// *       // ...
/// *       break;
/// *     case JAVA1_1_VALUE:
/// *       // ...
/// *       break;
/// *     //...
/// *   }
/// * }
/// * </pre>
/// *
/// * <p>As shown, each enum has a name and a value. These can be accessed using
/// * <code>getName</code> and <code>getValue</code>.</p>
/// *
/// * <p><em>NOTE:</em> Because the switch is ultimately sitting on top of an 
/// * int, the example above is not type-safe. That is, there is nothing that 
/// * checks that JAVA1_0_VALUE is a legal constant for JavaVersionEnum. </p>
/// *
/// * <p>The <code>getEnum</code> and <code>iterator</code> methods are recommended.
/// * Unfortunately, Java restrictions require these to be coded as shown in each subclass.
/// * An alternative choice is to use the <seealso cref="EnumUtils"/> class.</p>
/// *
/// * @author Apache Avalon project
/// * @author Stephen Colebourne
/// * @since 2.1 (class existed in enum package from v1.0)
/// * @version $Id: ValuedEnum.java 466275 2006-10-20 22:02:34Z bayard $
/// 

   [Serializable]
   public abstract class ValuedEnum : Enum
   {

///    
///     <summary> * Required for serialization support.
///     *  </summary>
///     * <seealso cref= java.io.Serializable </seealso>
///     
       private const long serialVersionUID = -7129650521543789085L;

///    
///     <summary> * The value contained in enum. </summary>
///     
       private readonly int iValue;

///    
///     <summary> * Constructor for enum item.
///     * </summary>
///     * <param name="name">  the name of enum item </param>
///     * <param name="value">  the value of enum item </param>
///     
       protected internal ValuedEnum(string name, int @value) : base(name)
       {
           iValue = @value;
       }

///    
///     <summary> * <p>Gets an <code>Enum</code> object by class and value.</p>
///     *
///     * <p>This method loops through the list of <code>Enum</code>,
///     * thus if there are many <code>Enum</code>s this will be
///     * slow.</p>
///     *  </summary>
///     * <param name="enumClass">  the class of the <code>Enum</code> to get </param>
///     * <param name="value">  the value of the <code>Enum</code> to get </param>
///     * <returns> the enum object, or null if the enum does not exist </returns>
///     * <exception cref="IllegalArgumentException"> if the enum class is <code>null</code> </exception>
///     
       protected internal static Enum getEnum(System.Type enumClass, int @value)
       {
           if (enumClass == null)
           {
               throw new ArgumentException("The Enum Class must not be null");
           }
           IList list = Enum.getEnumList(enumClass);
           for (IEnumerator it = list.GetEnumerator(); it.MoveNext();)
           {
               ValuedEnum enumeration = (ValuedEnum) it.Current;
               if (enumeration.getValue() == @value)
               {
                   return enumeration;
               }
           }
           return null;
       }

///    
///     <summary> * <p>Get value of enum item.</p>
///     * </summary>
///     * <returns> the enum item's value. </returns>
///     
       public int getValue()
       {
           return iValue;
       }

///    
///     <summary> * <p>Tests for order.</p>
///     *
///     * <p>The default ordering is numeric by value, but this
///     * can be overridden by subclasses.</p>
///     *
///     * <p>NOTE: From v2.2 the enums must be of the same type.
///     * If the parameter is in a different class loader than this instance,
///     * reflection is used to compare the values.</p>
///     * </summary>
///     * <seealso cref= java.lang.Comparable#compareTo(Object) </seealso>
///     * <param name="other">  the other object to compare to </param>
///     * <returns> -ve if this is less than the other object, +ve if greater than,
///     *  <code>0</code> of equal </returns>
///     * <exception cref="ClassCastException"> if other is not an <code>Enum</code> </exception>
///     * <exception cref="NullPointerException"> if other is <code>null</code> </exception>
///     
       public override int CompareTo(object other)
       {
           if (other == this)
           {
               return 0;
           }
           if (other.GetType() != this.GetType())
           {
               if (other.GetType().FullName.Equals(this.GetType().FullName))
               {
                   return iValue - getValueInOtherClassLoader(other);
               }
               throw new InvalidCastException("Different enum class '" + other.GetType().Name /*ClassUtils.getShortClassName(other.GetType())*/ + "'");
           }
           return iValue - ((ValuedEnum) other).iValue;
       }

///    
///     <summary> * <p>Use reflection to return an objects value.</p>
///     * </summary>
///     * <param name="other">  the object to determine the value for </param>
///     * <returns> the value </returns>
///     
       private int getValueInOtherClassLoader(object other)
       {
           try
           {
               MethodInfo mth = other.GetType().GetMethod("getValue", null);
               int @value = (int) mth.Invoke(other, null);
               return @value; //.intValue();
           }
           catch (MethodAccessException)
           {
            // ignore - should never happen
           }
           catch (UnauthorizedAccessException)
           {
            // ignore - should never happen
           }
           catch (TargetInvocationException)
           {
            // ignore - should never happen
           }
           throw new SystemException("This should not happen");
       }

///    
///     <summary> * <p>Human readable description of this <code>Enum</code> item.</p>
///     * </summary>
///     * <returns> String in the form <code>type[name=value]</code>, for example:
///     *  <code>JavaVersion[Java 1.0=100]</code>. Note that the package name is
///     *  stripped from the type name. </returns>
///     
       public override string ToString()
       {
           if (iToString == null)
           {
              string shortName = getEnumClass().Name; // ClassUtils.getShortClassName(getEnumClass());
               iToString = shortName + "[" + getName() + "=" + getValue() + "]";
           }
           return iToString;
       }
   }

}