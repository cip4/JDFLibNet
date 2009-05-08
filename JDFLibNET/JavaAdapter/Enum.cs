
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
   using System;
   using System.Collections;
   using System.Reflection;


   //using ClassUtils = org.apache.commons.lang.ClassUtils;
   using StringUtils = org.apache.commons.lang.StringUtils;

///
/// <summary> * <p>Abstract superclass for type-safe enums.</p>
/// *
/// * <p>One feature of the C programming language lacking in Java is enumerations. The
/// * C implementation based on ints was poor and open to abuse. The original Java
/// * recommendation and most of the JDK also uses int constants. It has been recognised
/// * however that a more robust type-safe class-based solution can be designed. This
/// * class follows the basic Java type-safe enumeration pattern.</p>
/// *
/// * <p><em>NOTE:</em> Due to the way in which Java ClassLoaders work, comparing
/// * Enum objects should always be done using <code>equals()</code>, not <code>==</code>.
/// * The equals() method will try == first so in most cases the effect is the same.</p>
/// * 
/// * <p>Of course, if you actually want (or don't mind) Enums in different class
/// * loaders being non-equal, then you can use <code>==</code>.</p>
/// * 
/// * <h4>Simple Enums</h4>
/// *
/// * <p>To use this class, it must be subclassed. For example:</p>
/// *
/// * <pre>
/// * public final class ColorEnum extends Enum {
/// *   public static final ColorEnum RED = new ColorEnum("Red");
/// *   public static final ColorEnum GREEN = new ColorEnum("Green");
/// *   public static final ColorEnum BLUE = new ColorEnum("Blue");
/// *
/// *   private ColorEnum(String color) {
/// *     super(color);
/// *   }
/// * 
/// *   public static ColorEnum getEnum(String color) {
/// *     return (ColorEnum) getEnum(ColorEnum.class, color);
/// *   }
/// * 
/// *   public static IDictionary getEnumMap() {
/// *     return getEnumMap(ColorEnum.class);
/// *   }
/// * 
/// *   public static IList getEnumList() {
/// *     return getEnumList(ColorEnum.class);
/// *   }
/// * 
/// *   public static Iterator iterator() {
/// *     return iterator(ColorEnum.class);
/// *   }
/// * }
/// * </pre>
/// *
/// * <p>As shown, each enum has a name. This can be accessed using <code>getName</code>.</p>
/// *
/// * <p>The <code>getEnum</code> and <code>iterator</code> methods are recommended.
/// * Unfortunately, Java restrictions require these to be coded as shown in each subclass.
/// * An alternative choice is to use the <seealso cref="EnumUtils"/> class.</p>
/// * 
/// * <h4>Subclassed Enums</h4>
/// * <p>A hierarchy of Enum classes can be built. In this case, the superclass is
/// * unaffected by the addition of subclasses (as per normal Java). The subclasses
/// * may add additional Enum constants <em>of the type of the superclass</em>. The
/// * query methods on the subclass will return all of the Enum constants from the
/// * superclass and subclass.</p>
/// *
/// * <pre>
/// * public final class ExtraColorEnum extends ColorEnum {
/// *   // NOTE: Color enum declared above is final, change that to get this
/// *   // example to compile.
/// *   public static final ColorEnum YELLOW = new ExtraColorEnum("Yellow");
/// *
/// *   private ExtraColorEnum(String color) {
/// *     super(color);
/// *   }
/// * 
/// *   public static ColorEnum getEnum(String color) {
/// *     return (ColorEnum) getEnum(ExtraColorEnum.class, color);
/// *   }
/// * 
/// *   public static IDictionary getEnumMap() {
/// *     return getEnumMap(ExtraColorEnum.class);
/// *   }
/// * 
/// *   public static IList getEnumList() {
/// *     return getEnumList(ExtraColorEnum.class);
/// *   }
/// * 
/// *   public static Iterator iterator() {
/// *     return iterator(ExtraColorEnum.class);
/// *   }
/// * }
/// * </pre>
/// *
/// * <p>This example will return RED, GREEN, BLUE, YELLOW from the List and iterator
/// * methods in that order. The RED, GREEN and BLUE instances will be the same (==) 
/// * as those from the superclass ColorEnum. Note that YELLOW is declared as a
/// * ColorEnum and not an ExtraColorEnum.</p>
/// * 
/// * <h4>Functional Enums</h4>
/// *
/// * <p>The enums can have functionality by defining subclasses and
/// * overriding the <code>getEnumClass()</code> method:</p>
/// * 
/// * <pre>
/// *   public static final OperationEnum PLUS = new PlusOperation();
/// *   private static final class PlusOperation extends OperationEnum {
/// *     private PlusOperation() {
/// *       super("Plus");
/// *     }
/// *     public int eval(int a, int b) {
/// *       return a + b;
/// *     }
/// *   }
/// *   public static final OperationEnum MINUS = new MinusOperation();
/// *   private static final class MinusOperation extends OperationEnum {
/// *     private MinusOperation() {
/// *       super("Minus");
/// *     }
/// *     public int eval(int a, int b) {
/// *       return a - b;
/// *     }
/// *   }
/// *
/// *   private OperationEnum(String color) {
/// *     super(color);
/// *   }
/// * 
/// *   public final Class getEnumClass() {     // NOTE: new method!
/// *     return OperationEnum.class;
/// *   }
/// *
/// *   public abstract double eval(double a, double b);
/// * 
/// *   public static OperationEnum getEnum(String name) {
/// *     return (OperationEnum) getEnum(OperationEnum.class, name);
/// *   }
/// * 
/// *   public static IDictionary getEnumMap() {
/// *     return getEnumMap(OperationEnum.class);
/// *   }
/// * 
/// *   public static IList getEnumList() {
/// *     return getEnumList(OperationEnum.class);
/// *   }
/// * 
/// *   public static Iterator iterator() {
/// *     return iterator(OperationEnum.class);
/// *   }
/// * }
/// * </pre>
/// * <p>The code above will work on JDK 1.2. If JDK1.3 and later is used,
/// * the subclasses may be defined as anonymous.</p>
/// * 
/// * <h4>Nested class Enums</h4>
/// *
/// * <p>Care must be taken with class loading when defining a static nested class
/// * for enums. The static nested class can be loaded without the surrounding outer
/// * class being loaded. This can result in an empty list/map/iterator being returned.
/// * One solution is to define a static block that references the outer class where
/// * the constants are defined. For example:</p>
/// *
/// * <pre>
/// * public final class Outer {
/// *   public static final BWEnum BLACK = new BWEnum("Black");
/// *   public static final BWEnum WHITE = new BWEnum("White");
/// *
/// *   // static nested enum class
/// *   public static final class BWEnum extends Enum {
/// * 
/// *     static {
/// *       // explicitly reference BWEnum class to force constants to load
/// *       Object obj = Outer.BLACK;
/// *     }
/// * 
/// *     // ... other methods omitted
/// *   }
/// * }
/// * </pre>
/// * 
/// * <p>Although the above solves the problem, it is not recommended. The best solution
/// * is to define the constants in the enum class, and hold references in the outer class:
/// *
/// * <pre>
/// * public final class Outer {
/// *   public static final BWEnum BLACK = BWEnum.BLACK;
/// *   public static final BWEnum WHITE = BWEnum.WHITE;
/// *
/// *   // static nested enum class
/// *   public static final class BWEnum extends Enum {
/// *     // only define constants in enum classes - private if desired
/// *     private static final BWEnum BLACK = new BWEnum("Black");
/// *     private static final BWEnum WHITE = new BWEnum("White");
/// * 
/// *     // ... other methods omitted
/// *   }
/// * }
/// * </pre>
/// * 
/// * <p>For more details, see the 'Nested' test cases.
/// *
/// * <h4>Lang Enums and Java 5.0 Enums</h4>
/// *
/// * <p>Enums were added to Java in Java 5.0. The main differences between Lang's 
/// * implementation and the new official JDK implementation are: </p>
/// * <ul>
/// * <li>The standard Enum is a not just a superclass, but is a type baked into the 
/// * language. </li>
/// * <li>The standard Enum does not support extension, so the standard methods that 
/// * are provided in the Lang enum are not available. </li>
/// * <li>Lang mandates a String name, whereas the standard Enum uses the class 
/// * name as its name. getName() changes to name(). </li>
/// * </ul>
/// *
/// * <p>Generally people should use the standard Enum. Migrating from the Lang 
/// * enum to the standard Enum is not as easy as it might be due to the lack of 
/// * class inheritence in standard Enums. This means that it's not possible 
/// * to provide a 'super-enum' which could provide the same utility methods 
/// * that the Lang enum does. The following utility class is a Java 5.0 
/// * version of our EnumUtils class and provides those utility methods. </p>
/// *
/// * <pre>
/// * import java.util.*;
/// * 
/// * public class EnumUtils {
/// * 
/// *   public static Enum getEnum(Class enumClass, String token) {
/// *     return Enum.valueOf(enumClass, token);
/// *   }
/// * 
/// *   public static Map getEnumMap(Class enumClass) {
/// *     HashMap map = new HashMap();
/// *     Iterator itr = EnumUtils.iterator(enumClass);
/// *     while(itr.hasNext()) {
/// *       Enum enm = (Enum) itr.next();
/// *       map.put( enm.name(), enm );
/// *     }
/// *     return map;
/// *   }
/// * 
/// *   public static List getEnumList(Class enumClass) {
/// *     return new ArrayList( EnumSet.allOf(enumClass) );
/// *   }
/// * 
/// *   public static Iterator iterator(Class enumClass) {
/// *     return EnumUtils.getEnumList(enumClass).iterator();
/// *   }
/// * }
/// * </pre>
/// * 
/// * @author Apache Avalon project
/// * @author Stephen Colebourne
/// * @author Chris Webb
/// * @author Mike Bowler
/// * @author Matthias Eichel
/// * @since 2.1 (class existed in enum package from v1.0)
/// * @version $Id: Enum.java 466285 2006-10-20 22:36:21Z bayard $ </summary>
/// 
   [Serializable]
   public abstract class Enum : IComparable
   {

///    
///     <summary> * Required for serialization support.
///     *  </summary>
///     * <seealso cref= java.io.Serializable </seealso>
///     
       private const long serialVersionUID = -487045951170455942L;

    // After discussion, the default size for HashMaps is used, as the
    // sizing algorithm changes across the JDK versions
///    
///     <summary> * An empty <code>Map</code>, as JDK1.2 didn't have an empty map. </summary>
///     
       private static readonly IDictionary EMPTY_MAP = new Hashtable(0);

///    
///     <summary> * <code>Map</code>, key of class name, value of <code>Entry</code>. </summary>
///     
       private static readonly IDictionary cEnumClasses = new Hashtable(); // no equivalent in .NET, new WeakHashMap();

///    
///     <summary> * The string representation of the Enum. </summary>
///     
       private readonly string iName;

///    
///     <summary> * The hashcode representation of the Enum. </summary>
///     
       [NonSerialized]
       private readonly int iHashCode;

///    
///     <summary> * The toString representation of the Enum.
///     * @since 2.0 </summary>
///     
       [NonSerialized]
       protected internal string iToString = null;

///    
///     <summary> * <p>Enable the iterator to retain the source code order.</p> </summary>
///     
       private class Entry
       {
///        
///         <summary> * Map of Enum name to Enum. </summary>
///         
           internal readonly IDictionary map = new Hashtable();
///        
///         <summary> * Map of Enum name to Enum. </summary>
///         
           // internal readonly IDictionary unmodifiableMap = Collections.unmodifiableMap(map);
///        
///         <summary> * List of Enums in source code order. </summary>
///         
           internal readonly IList list = new ArrayList(25);
///        
///         <summary> * Map of Enum name to Enum. </summary>
///         
           //internal readonly IList unmodifiableList = Collections.unmodifiableList(list);

///        
///         <summary> * <p>Restrictive constructor.</p> </summary>
///         
           protected internal Entry() : base()
           {
           }
       }

///    
///     <summary> * <p>Constructor to add a new named item to the enumeration.</p>
///     * </summary>
///     * <param name="name">  the name of the enum object,
///     *  must not be empty or <code>null</code> </param>
///     * <exception cref="IllegalArgumentException"> if the name is <code>null</code>
///     *  or an empty string </exception>
///     * <exception cref="IllegalArgumentException"> if the getEnumClass() method returns
///     *  a null or invalid Class </exception>
///     
       protected internal Enum(string name) : base()
       {
           init(name);
           iName = name;
           iHashCode = 7 + getEnumClass().GetHashCode() + 3 * name.GetHashCode();
        // cannot create toString here as subclasses may want to include other data
       }

///    
///     <summary> * Initializes the enumeration.
///     *  </summary>
///     * <param name="name">  the enum name </param>
///     * <exception cref="IllegalArgumentException"> if the name is null or empty or duplicate </exception>
///     * <exception cref="IllegalArgumentException"> if the enumClass is null or invalid </exception>
///     
       private void init(string name)
       {
           if (StringUtils.IsEmpty(name))
           {
               throw new ArgumentException("The Enum name must not be empty or null");
           }

           System.Type enumClass = getEnumClass();
           if (enumClass == null)
           {
               throw new ArgumentException("getEnumClass() must not be null");
           }
           System.Type cls = this.GetType();
           bool ok = false;
           while (cls != null && cls != typeof(Enum) && cls != typeof(ValuedEnum))
           {
               if (cls == enumClass)
               {
                   ok = true;
                   break;
               }
               cls = cls.BaseType;
           }
           if (ok == false)
           {
               throw new ArgumentException("getEnumClass() must return a superclass of this class");
           }

        // create entry
           Entry entry = (Entry) cEnumClasses[enumClass]; //.get(enumClass);
           if (entry == null)
           {
               entry = createEntry(enumClass);
               cEnumClasses[enumClass] = entry; //.put(enumClass, entry);
           }
           if (entry.map.Contains(name))
           {
               throw new ArgumentException("The Enum name must be unique, '" + name + "' has already been added");
           }
           entry.map.Add(name, this); //.put(name, this);
           entry.list.Add(this);
       }

///    
///     <summary> * <p>Handle the deserialization of the class to ensure that multiple
///     * copies are not wastefully created, or illegal enum types created.</p>
///     * </summary>
///     * <returns> the resolved object </returns>
///     
       protected internal virtual object readResolve()
       {
           Entry entry = (Entry) cEnumClasses[getEnumClass()]; //.get(getEnumClass());
           if (entry == null)
           {
               return null;
           }
           return entry.map[getName()]; //.get(getName());
       }

    //--------------------------------------------------------------------------------

///    
///     <summary> * <p>Gets an <code>Enum</code> object by class and name.</p>
///     *  </summary>
///     * <param name="enumClass">  the class of the Enum to get, must not
///     *  be <code>null</code> </param>
///     * <param name="name">  the name of the <code>Enum</code> to get,
///     *  may be <code>null</code> </param>
///     * <returns> the enum object, or <code>null</code> if the enum does not exist </returns>
///     * <exception cref="IllegalArgumentException"> if the enum class
///     *  is <code>null</code> </exception>
///     
       protected internal static Enum getEnum(System.Type enumClass, string name)
       {
           Entry entry = getEntry(enumClass);
           if (entry == null)
           {
               return null;
           }
           if ((name != null) && (entry.map.Contains(name)))
              return (Enum)entry.map[name];
           else
              return null;
       }

///    
///     <summary> * <p>Gets the <code>Map</code> of <code>Enum</code> objects by
///     * name using the <code>Enum</code> class.</p>
///     *
///     * <p>If the requested class has no enum objects an empty
///     * <code>Map</code> is returned.</p>
///     *  </summary>
///     * <param name="enumClass">  the class of the <code>Enum</code> to get,
///     *  must not be <code>null</code> </param>
///     * <returns> the enum object Map </returns>
///     * <exception cref="IllegalArgumentException"> if the enum class is <code>null</code> </exception>
///     * <exception cref="IllegalArgumentException"> if the enum class is not a subclass of Enum </exception>
///     
       protected internal static IDictionary getEnumMap(System.Type enumClass)
       {
           Entry entry = getEntry(enumClass);
           if (entry == null)
           {
               new Hashtable(0);
           }
           // Java to C# Conversion - No unmodifiable map in .NET just return a new copy of existing map.
           // return entry.unmodifiableMap;
           return new Hashtable(entry.map);
       }

///    
///     <summary> * <p>Gets the <code>List</code> of <code>Enum</code> objects using the
///     * <code>Enum</code> class.</p>
///     *
///     * <p>The list is in the order that the objects were created (source code order).
///     * If the requested class has no enum objects an empty <code>List</code> is
///     * returned.</p>
///     *  </summary>
///     * <param name="enumClass">  the class of the <code>Enum</code> to get,
///     *  must not be <code>null</code> </param>
///     * <returns> the enum object Map </returns>
///     * <exception cref="IllegalArgumentException"> if the enum class is <code>null</code> </exception>
///     * <exception cref="IllegalArgumentException"> if the enum class is not a subclass of Enum </exception>
///     
       protected internal static IList getEnumList(System.Type enumClass)
       {
           Entry entry = getEntry(enumClass);
           if (entry == null)
           {
              return new ArrayList(0);
           }
           // Java to C# Conversion - No unmodifiable list in .NET just return a new copy of existing list.
           //return entry.unmodifiableList;
           return new ArrayList(entry.list);
       }

///    
///     <summary> * <p>Gets an <code>Iterator</code> over the <code>Enum</code> objects in
///     * an <code>Enum</code> class.</p>
///     *
///     * <p>The <code>Iterator</code> is in the order that the objects were
///     * created (source code order). If the requested class has no enum
///     * objects an empty <code>Iterator</code> is returned.</p>
///     *  </summary>
///     * <param name="enumClass">  the class of the <code>Enum</code> to get,
///     *  must not be <code>null</code> </param>
///     * <returns> an iterator of the Enum objects </returns>
///     * <exception cref="IllegalArgumentException"> if the enum class is <code>null</code> </exception>
///     * <exception cref="IllegalArgumentException"> if the enum class is not a subclass of Enum </exception>
///     
       protected internal static IEnumerator iterator(System.Type enumClass)
       {
           return Enum.getEnumList(enumClass).GetEnumerator();
       }

    //-----------------------------------------------------------------------
///    
///     <summary> * <p>Gets an <code>Entry</code> from the map of Enums.</p>
///     *  </summary>
///     * <param name="enumClass">  the class of the <code>Enum</code> to get </param>
///     * <returns> the enum entry </returns>
///     
       private static Entry getEntry(System.Type enumClass)
       {
           if (enumClass == null)
           {
               throw new ArgumentException("The Enum Class must not be null");
           }
           if (typeof(Enum).IsAssignableFrom(enumClass) == false)
           {
               throw new ArgumentException("The Class must be a subclass of Enum");
           }
           Entry entry = (Entry) cEnumClasses[enumClass]; //.get(enumClass);
           return entry;
       }

///    
///     <summary> * <p>Creates an <code>Entry</code> for storing the Enums.</p>
///     *
///     * <p>This accounts for subclassed Enums.</p>
///     *  </summary>
///     * <param name="enumClass">  the class of the <code>Enum</code> to get </param>
///     * <returns> the enum entry </returns>
///     
       private static Entry createEntry(System.Type enumClass)
       {
           Entry entry = new Entry();
           System.Type cls = enumClass.BaseType;
           while (cls != null && cls != typeof(Enum) && cls != typeof(ValuedEnum))
           {
               Entry loopEntry = (Entry) cEnumClasses[cls]; //.get(cls);
               if (loopEntry != null)
               {
                   // entry.list.addAll(loopEntry.list);
                   AddAll(entry.list, loopEntry.list);

                   //entry.map.putAll(loopEntry.map);
                   PutAll(entry.map, loopEntry.map);

                   break; // stop here, as this will already have had superclasses added
               }
               cls = cls.BaseType;
           }
           return entry;
       }

    //-----------------------------------------------------------------------
///    
///     <summary> * <p>Retrieve the name of this Enum item, set in the constructor.</p>
///     *  </summary>
///     * <returns> the <code>String</code> name of this Enum item </returns>
///     
       public string getName()
       {
           return iName;
       }

///    
///     <summary> * <p>Retrieves the Class of this Enum item, set in the constructor.</p>
///     * 
///     * <p>This is normally the same as <code>getClass()</code>, but for
///     * advanced Enums may be different. If overridden, it must return a
///     * constant value.</p>
///     *  </summary>
///     * <returns> the <code>Class</code> of the enum
///     * @since 2.0 </returns>
///     
       public virtual System.Type getEnumClass()
       {
           return this.GetType();
       }

///    
///     <summary> * <p>Tests for equality.</p>
///     *
///     * <p>Two Enum objects are considered equal
///     * if they have the same class names and the same names.
///     * Identity is tested for first, so this method usually runs fast.</p>
///     * 
///     * <p>If the parameter is in a different class loader than this instance,
///     * reflection is used to compare the names.</p>
///     * </summary>
///     * <param name="other">  the other object to compare for equality </param>
///     * <returns> <code>true</code> if the Enums are equal </returns>
///     
       public sealed override bool Equals(object other)
       {
           if (other == this)
           {
               return true;
           }
           else if (other == null)
           {
               return false;
           }
           else if (other.GetType() == this.GetType())
           {
            // Ok to do a class cast to Enum here since the test above
            // guarantee both
            // classes are in the same class loader.
               return iName.Equals(((Enum) other).iName);
           }
           else
           {
            // This and other are in different class loaders, we must check indirectly
               if (other.GetType().FullName.Equals(this.GetType().FullName) == false)
               {
                   return false;
               }
               return iName.Equals(getNameInOtherClassLoader(other));
           }
       }

///    
///     <summary> * <p>Returns a suitable hashCode for the enumeration.</p>
///     * </summary>
///     * <returns> a hashcode based on the name </returns>
///     
       public sealed override int GetHashCode()
       {
           return iHashCode;
       }

///    
///     <summary> * <p>Tests for order.</p>
///     *
///     * <p>The default ordering is alphabetic by name, but this
///     * can be overridden by subclasses.</p>
///     * 
///     * <p>If the parameter is in a different class loader than this instance,
///     * reflection is used to compare the names.</p>
///     * </summary>
///     * <seealso cref= java.lang.Comparable#compareTo(Object) </seealso>
///     * <param name="other">  the other object to compare to </param>
///     * <returns> -ve if this is less than the other object, +ve if greater
///     *  than, <code>0</code> of equal </returns>
///     * <exception cref="ClassCastException"> if other is not an Enum </exception>
///     * <exception cref="NullPointerException"> if other is <code>null</code> </exception>
///     
       public virtual int CompareTo(object other)
       {
           if (other == this)
           {
               return 0;
           }
           if (other.GetType() != this.GetType())
           {
               if (other.GetType().FullName.Equals(this.GetType().FullName))
               {
                   return iName.CompareTo(getNameInOtherClassLoader(other));
               }
               throw new InvalidCastException("Different enum class '" + other.GetType().Name /*ClassUtils.getShortClassName(other.GetType())*/ + "'");
           }
           return iName.CompareTo(((Enum) other).iName);
       }

///    
///     <summary> * <p>Use reflection to return an objects class name.</p>
///     * </summary>
///     * <param name="other"> The object to determine the class name for </param>
///     * <returns> The class name </returns>
///     
       private string getNameInOtherClassLoader(object other)
       {
           try
           {
               MethodInfo mth = other.GetType().GetMethod("getName", null);
               string name = (string) mth.Invoke(other, null);
               return name;
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
///     <summary> * <p>Human readable description of this Enum item.</p>
///     *  </summary>
///     * <returns> String in the form <code>type[name]</code>, for example:
///     * <code>Color[Red]</code>. Note that the package name is stripped from
///     * the type name. </returns>
///     
       public override string ToString()
       {
           if (iToString == null)
           {
              string shortName = getEnumClass().Name; // ClassUtils.getShortClassName(getEnumClass());
               iToString = shortName + "[" + getName() + "]";
           }
           return iToString;
       }


      // Java to C# Conversion - 
      public static void AddAll(IList target, IList itemsToAdd)
      {
         for (int i = 0; i < itemsToAdd.Count; i++)
         {
            target.Add(itemsToAdd[i]);
         } 
      }

      public static void PutAll(IDictionary target, IDictionary itemsToAdd)
      {
         IEnumerator it = itemsToAdd.Keys.GetEnumerator();
         while(it.MoveNext())
         {
            object key = it.Current;
            target.Add(key, itemsToAdd[key]);
         }
      }

   }

}