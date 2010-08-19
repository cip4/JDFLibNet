
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


//
// In order to convert some functionality to Visual C#, the Java Language Conversion Assistant
// creates "support classes" that duplicate the original functionality.  
//
// Support classes replicate the functionality of the original code, but in some cases they are 
// substantially different architecturally. Although every effort is made to preserve the 
// original architecture of the application in the converted project, the user should be aware that 
// the primary goal of these support classes is to replicate functionality, and that at times 
// the architecture of the resulting solution may differ somewhat.
//

using System;

/// <summary>
/// This exception is thrown by the XmlSaxDocumentManager in the SetProperty and SetFeature 
/// methods if a property or method couldn't be found.
/// </summary>
public class ManagerNotRecognizedException : System.Exception
{
   /// <summary>
   /// Creates a new ManagerNotRecognizedException with the message specified.
   /// </summary>
   /// <param name="Message">Error message of the exception.</param>
   public ManagerNotRecognizedException(System.String Message)
      : base(Message)
   {
   }
}

/*******************************/
/// <summary>
/// This exception is thrown by the XmlSaxDocumentManager in the SetProperty and SetFeature methods 
/// if a property or method couldn't be supported.
/// </summary>
public class ManagerNotSupportedException : System.Exception
{
   /// <summary>
   /// Creates a new ManagerNotSupportedException with the message specified.
   /// </summary>
   /// <param name="Message">Error message of the exception.</param>
   public ManagerNotSupportedException(System.String Message)
      : base(Message)
   {
   }
}

/*******************************/
/// <summary>
/// This interface will manage errors during the parsing of a XML document.
/// </summary>
public interface XmlSaxErrorHandler
{
   /// <summary>
   /// This method manage an error exception ocurred during the parsing process.
   /// </summary>
   /// <param name="exception">The exception thrown by the parser.</param>
   void error(System.Xml.XmlException exception);

   /// <summary>
   /// This method manage a fatal error exception ocurred during the parsing process.
   /// </summary>
   /// <param name="exception">The exception thrown by the parser.</param>
   void fatalError(System.Xml.XmlException exception);

   /// <summary>
   /// This method manage a warning exception ocurred during the parsing process.
   /// </summary>
   /// <param name="exception">The exception thrown by the parser.</param>
   void warning(System.Xml.XmlException exception);
}

/*******************************/
/// <summary>
/// This class is used to encapsulate a source of Xml code in an single class.
/// </summary>
public class XmlSourceSupport
{
   private System.IO.Stream bytes;
   private System.IO.StreamReader characters;
   private System.String uri;

   /// <summary>
   /// Constructs an empty XmlSourceSupport instance.
   /// </summary>
   public XmlSourceSupport()
   {
      bytes = null;
      characters = null;
      uri = null;
   }

   /// <summary>
   /// Constructs a XmlSource instance with the specified source System.IO.Stream.
   /// </summary>
   /// <param name="stream">The stream containing the document.</param>
   public XmlSourceSupport(System.IO.Stream stream)
   {
      bytes = stream;
      characters = null;
      uri = null;
   }

   /// <summary>
   /// Constructs a XmlSource instance with the specified source System.IO.StreamReader.
   /// </summary>
   /// <param name="reader">The reader containing the document.</param>
   public XmlSourceSupport(System.IO.StreamReader reader)
   {
      bytes = null;
      characters = reader;
      uri = null;
   }

   /// <summary>
   /// Construct a XmlSource instance with the specified source Uri string.
   /// </summary>
   /// <param name="source">The source containing the document.</param>
   public XmlSourceSupport(System.String source)
   {
      bytes = null;
      characters = null;
      uri = source;
   }

   /// <summary>
   /// Represents the source Stream of the XmlSource.
   /// </summary>
   public System.IO.Stream Bytes
   {
      get
      {
         return bytes;
      }
      set
      {
         bytes = value;
      }
   }

   /// <summary>
   /// Represents the source StreamReader of the XmlSource.
   /// </summary>
   public System.IO.StreamReader Characters
   {
      get
      {
         return characters;
      }
      set
      {
         characters = value;
      }
   }

   /// <summary>
   /// Represents the source URI of the XmlSource.
   /// </summary>
   public System.String Uri
   {
      get
      {
         return uri;
      }
      set
      {
         uri = value;
      }
   }
}

/*******************************/
/// <summary>
/// Contains conversion support elements such as classes, interfaces and static methods.
/// </summary>
public class SupportClass
{
   /// <summary>
   /// This method returns the literal value received
   /// </summary>
   /// <param name="literal">The literal to return</param>
   /// <returns>The received value</returns>
   public static long Identity(long literal)
   {
      return literal;
   }

   /// <summary>
   /// This method returns the literal value received
   /// </summary>
   /// <param name="literal">The literal to return</param>
   /// <returns>The received value</returns>
   public static ulong Identity(ulong literal)
   {
      return literal;
   }

   /// <summary>
   /// This method returns the literal value received
   /// </summary>
   /// <param name="literal">The literal to return</param>
   /// <returns>The received value</returns>
   public static float Identity(float literal)
   {
      return literal;
   }

   /// <summary>
   /// This method returns the literal value received
   /// </summary>
   /// <param name="literal">The literal to return</param>
   /// <returns>The received value</returns>
   public static double Identity(double literal)
   {
      return literal;
   }

   /*******************************/
   /// <summary>
   /// Performs an unsigned bitwise right shift with the specified number
   /// </summary>
   /// <param name="number">Number to operate on</param>
   /// <param name="bits">Ammount of bits to shift</param>
   /// <returns>The resulting number from the shift operation</returns>
   public static int URShift(int number, int bits)
   {
      if (number >= 0)
         return number >> bits;
      else
         return (number >> bits) + (2 << ~bits);
   }

   /// <summary>
   /// Performs an unsigned bitwise right shift with the specified number
   /// </summary>
   /// <param name="number">Number to operate on</param>
   /// <param name="bits">Ammount of bits to shift</param>
   /// <returns>The resulting number from the shift operation</returns>
   public static int URShift(int number, long bits)
   {
      return URShift(number, (int)bits);
   }

   /// <summary>
   /// Performs an unsigned bitwise right shift with the specified number
   /// </summary>
   /// <param name="number">Number to operate on</param>
   /// <param name="bits">Ammount of bits to shift</param>
   /// <returns>The resulting number from the shift operation</returns>
   public static long URShift(long number, int bits)
   {
      if (number >= 0)
         return number >> bits;
      else
         return (number >> bits) + (2L << ~bits);
   }

   /// <summary>
   /// Performs an unsigned bitwise right shift with the specified number
   /// </summary>
   /// <param name="number">Number to operate on</param>
   /// <param name="bits">Ammount of bits to shift</param>
   /// <returns>The resulting number from the shift operation</returns>
   public static long URShift(long number, long bits)
   {
      return URShift(number, (int)bits);
   }

   /*******************************/
   /// <summary>
   /// Writes the exception stack trace to the received stream
   /// </summary>
   /// <param name="throwable">Exception to obtain information from</param>
   /// <param name="stream">Output sream used to write to</param>
   public static void WriteStackTrace(System.Exception throwable, System.IO.TextWriter stream)
   {
      stream.Write(throwable.StackTrace);
      stream.Flush();
   }

   /*******************************/
   /// <summary>
   /// Converts the specified collection to its string representation.
   /// </summary>
   /// <param name="c">The collection to convert to string.</param>
   /// <returns>A string representation of the specified collection.</returns>
   public static System.String CollectionToString(System.Collections.ICollection c)
   {
      System.Text.StringBuilder s = new System.Text.StringBuilder();

      if (c != null)
      {

         System.Collections.ArrayList l = new System.Collections.ArrayList(c);

         bool isDictionary = (c is System.Collections.BitArray || c is System.Collections.Hashtable || c is System.Collections.IDictionary || c is System.Collections.Specialized.NameValueCollection || (l.Count > 0 && l[0] is System.Collections.DictionaryEntry));
         for (int index = 0; index < l.Count; index++)
         {
            if (l[index] == null)
               s.Append("null");
            else if (!isDictionary)
               s.Append(l[index]);
            else
            {
               isDictionary = true;
               if (c is System.Collections.Specialized.NameValueCollection)
                  s.Append(((System.Collections.Specialized.NameValueCollection)c).GetKey(index));
               else
                  s.Append(((System.Collections.DictionaryEntry)l[index]).Key);
               s.Append("=");
               if (c is System.Collections.Specialized.NameValueCollection)
                  s.Append(((System.Collections.Specialized.NameValueCollection)c).GetValues(index)[0]);
               else
                  s.Append(((System.Collections.DictionaryEntry)l[index]).Value);

            }
            if (index < l.Count - 1)
               s.Append(", ");
         }

         if (isDictionary)
         {
            if (c is System.Collections.ArrayList)
               isDictionary = false;
         }
         if (isDictionary)
         {
            s.Insert(0, "{");
            s.Append("}");
         }
         else
         {
            s.Insert(0, "[");
            s.Append("]");
         }
      }
      else
         s.Insert(0, "null");
      return s.ToString();
   }

   /// <summary>
   /// Tests if the specified object is a collection and converts it to its string representation.
   /// </summary>
   /// <param name="obj">The object to convert to string</param>
   /// <returns>A string representation of the specified object.</returns>
   public static System.String CollectionToString(System.Object obj)
   {
      System.String result = "";

      if (obj != null)
      {
         if (obj is System.Collections.ICollection)
            result = CollectionToString((System.Collections.ICollection)obj);
         else
            result = obj.ToString();
      }
      else
         result = "null";

      return result;
   }
   /*******************************/
   /// <summary>
   /// Provides support for DateFormat
   /// </summary>
   public class DateTimeFormatManager
   {
      static public DateTimeFormatHashTable manager = new DateTimeFormatHashTable();

      /// <summary>
      /// Hashtable class to provide functionality for dateformat properties
      /// </summary>
      public class DateTimeFormatHashTable : System.Collections.Hashtable
      {
         /// <summary>
         /// Sets the format for datetime.
         /// </summary>
         /// <param name="format">DateTimeFormat instance to set the pattern</param>
         /// <param name="newPattern">A string with the pattern format</param>
         public void SetDateFormatPattern(System.Globalization.DateTimeFormatInfo format, System.String newPattern)
         {
            if (this[format] != null)
               ((DateTimeFormatProperties)this[format]).DateFormatPattern = newPattern;
            else
            {
               DateTimeFormatProperties tempProps = new DateTimeFormatProperties();
               tempProps.DateFormatPattern = newPattern;
               Add(format, tempProps);
            }
         }

         /// <summary>
         /// Gets the current format pattern of the DateTimeFormat instance
         /// </summary>
         /// <param name="format">The DateTimeFormat instance which the value will be obtained</param>
         /// <returns>The string representing the current datetimeformat pattern</returns>
         public System.String GetDateFormatPattern(System.Globalization.DateTimeFormatInfo format)
         {
            if (this[format] == null)
               return "d-MMM-yy";
            else
               return ((DateTimeFormatProperties)this[format]).DateFormatPattern;
         }

         /// <summary>
         /// Sets the datetimeformat pattern to the giving format
         /// </summary>
         /// <param name="format">The datetimeformat instance to set</param>
         /// <param name="newPattern">The new datetimeformat pattern</param>
         public void SetTimeFormatPattern(System.Globalization.DateTimeFormatInfo format, System.String newPattern)
         {
            if (this[format] != null)
               ((DateTimeFormatProperties)this[format]).TimeFormatPattern = newPattern;
            else
            {
               DateTimeFormatProperties tempProps = new DateTimeFormatProperties();
               tempProps.TimeFormatPattern = newPattern;
               Add(format, tempProps);
            }
         }

         /// <summary>
         /// Gets the current format pattern of the DateTimeFormat instance
         /// </summary>
         /// <param name="format">The DateTimeFormat instance which the value will be obtained</param>
         /// <returns>The string representing the current datetimeformat pattern</returns>
         public System.String GetTimeFormatPattern(System.Globalization.DateTimeFormatInfo format)
         {
            if (this[format] == null)
               return "h:mm:ss tt";
            else
               return ((DateTimeFormatProperties)this[format]).TimeFormatPattern;
         }

         /// <summary>
         /// Internal class to provides the DateFormat and TimeFormat pattern properties on .NET
         /// </summary>
         class DateTimeFormatProperties
         {
            public System.String DateFormatPattern = "d-MMM-yy";
            public System.String TimeFormatPattern = "h:mm:ss tt";
         }
      }
   }
   /*******************************/
   /// <summary>
   /// Gets the DateTimeFormat instance and date instance to obtain the date with the format passed
   /// </summary>
   /// <param name="format">The DateTimeFormat to obtain the time and date pattern</param>
   /// <param name="date">The date instance used to get the date</param>
   /// <returns>A string representing the date with the time and date patterns</returns>
   public static System.String FormatDateTime(System.Globalization.DateTimeFormatInfo format, System.DateTime date)
   {
      System.String timePattern = DateTimeFormatManager.manager.GetTimeFormatPattern(format);
      System.String datePattern = DateTimeFormatManager.manager.GetDateFormatPattern(format);
      return date.ToString(datePattern + " " + timePattern, format);
   }



   /*******************************/
   /// <summary>
   /// SupportClass for the HashSet class.
   /// </summary>
   [Serializable]
   public class HashSetSupport : System.Collections.ArrayList, SetSupport
   {
      public HashSetSupport()
         : base()
      {
      }

      public HashSetSupport(System.Collections.ICollection c)
      {
         this.AddAll(c);
      }

      public HashSetSupport(int capacity)
         : base(capacity)
      {
      }

      /// <summary>
      /// Adds a new element to the ArrayList if it is not already present.
      /// </summary>		
      /// <param name="obj">Element to insert to the ArrayList.</param>
      /// <returns>Returns true if the new element was inserted, false otherwise.</returns>
      new public virtual bool Add(System.Object obj)
      {
         bool inserted;

         if ((inserted = this.Contains(obj)) == false)
         {
            base.Add(obj);
         }

         return !inserted;
      }

      /// <summary>
      /// Adds all the elements of the specified collection that are not present to the list.
      /// </summary>
      /// <param name="c">Collection where the new elements will be added</param>
      /// <returns>Returns true if at least one element was added, false otherwise.</returns>
      public bool AddAll(System.Collections.ICollection c)
      {
         System.Collections.IEnumerator e = new System.Collections.ArrayList(c).GetEnumerator();
         bool added = false;

         while (e.MoveNext() == true)
         {
            if (this.Add(e.Current) == true)
               added = true;
         }

         return added;
      }

      /// <summary>
      /// Returns a copy of the HashSet instance.
      /// </summary>		
      /// <returns>Returns a shallow copy of the current HashSet.</returns>
      public override System.Object Clone()
      {
         return base.MemberwiseClone();
      }
   }


   public class LinkedHashSet : HashSetSupport
   {
   }


   /*******************************/
   /// <summary>
   /// Represents a collection ob objects that contains no duplicate elements.
   /// </summary>	
   public interface SetSupport : System.Collections.ICollection, System.Collections.IList
   {
      /// <summary>
      /// Adds a new element to the Collection if it is not already present.
      /// </summary>
      /// <param name="obj">The object to add to the collection.</param>
      /// <returns>Returns true if the object was added to the collection, otherwise false.</returns>
      new bool Add(System.Object obj);

      /// <summary>
      /// Adds all the elements of the specified collection to the Set.
      /// </summary>
      /// <param name="c">Collection of objects to add.</param>
      /// <returns>true</returns>
      bool AddAll(System.Collections.ICollection c);
   }



   [Serializable]
   public class HashSetSupport<T> : System.Collections.Generic.List<T>, SetSupport<T>
   {
      public HashSetSupport()
         : base()
      {
      }

      public HashSetSupport(System.Collections.Generic.ICollection<T> c)
      {
         this.AddAll(c);
      }

      public HashSetSupport(int capacity)
         : base(capacity)
      {
      }

      /// <summary>
      /// Adds a new element to the ArrayList if it is not already present.
      /// </summary>		
      /// <param name="obj">Element to insert to the ArrayList.</param>
      /// <returns>Returns true if the new element was inserted, false otherwise.</returns>
      new public virtual bool Add(T obj)
      {
         bool inserted;

         if ((inserted = this.Contains(obj)) == false)
         {
            base.Add(obj);
         }

         return !inserted;
      }

      /// <summary>
      /// Adds all the elements of the specified collection that are not present to the list.
      /// </summary>
      /// <param name="c">Collection where the new elements will be added</param>
      /// <returns>Returns true if at least one element was added, false otherwise.</returns>
      public bool AddAll(System.Collections.Generic.ICollection<T> c)
      {
         System.Collections.Generic.IEnumerator<T> e = new System.Collections.Generic.List<T>(c).GetEnumerator();
         bool added = false;

         while (e.MoveNext() == true)
         {
            if (this.Add(e.Current) == true)
               added = true;
         }

         return added;
      }

      /// <summary>
      /// Returns a copy of the HashSet instance.
      /// </summary>		
      /// <returns>Returns a shallow copy of the current HashSet.</returns>
      //public override System.Object Clone()
      //{
      //   return base.MemberwiseClone();
      //}
   }


   /*******************************/
   /// <summary>
   /// Represents a collection ob objects that contains no duplicate elements.
   /// </summary>	
   public interface SetSupport<T> : System.Collections.Generic.ICollection<T>, System.Collections.Generic.IList<T>
   {
      /// <summary>
      /// Adds a new element to the Collection if it is not already present.
      /// </summary>
      /// <param name="obj">The object to add to the collection.</param>
      /// <returns>Returns true if the object was added to the collection, otherwise false.</returns>
      new bool Add(T obj);

      /// <summary>
      /// Adds all the elements of the specified collection to the Set.
      /// </summary>
      /// <param name="c">Collection of objects to add.</param>
      /// <returns>true</returns>
      bool AddAll(System.Collections.Generic.ICollection<T> c);
   }




   /*******************************/
   /// <summary>
   /// Receives a byte array and returns it transformed in an sbyte array
   /// </summary>
   /// <param name="byteArray">Byte array to process</param>
   /// <returns>The transformed array</returns>
   public static sbyte[] ToSByteArray(byte[] byteArray)
   {
      sbyte[] sbyteArray = null;
      if (byteArray != null)
      {
         sbyteArray = new sbyte[byteArray.Length];
         for (int index = 0; index < byteArray.Length; index++)
            sbyteArray[index] = (sbyte)byteArray[index];
      }
      return sbyteArray;
   }

   /*******************************/
   /// <summary>
   /// Converts an array of sbytes to an array of bytes
   /// </summary>
   /// <param name="sbyteArray">The array of sbytes to be converted</param>
   /// <returns>The new array of bytes</returns>
   public static byte[] ToByteArray(sbyte[] sbyteArray)
   {
      byte[] byteArray = null;

      if (sbyteArray != null)
      {
         byteArray = new byte[sbyteArray.Length];
         for (int index = 0; index < sbyteArray.Length; index++)
            byteArray[index] = (byte)sbyteArray[index];
      }
      return byteArray;
   }

   /// <summary>
   /// Converts a string to an array of bytes
   /// </summary>
   /// <param name="sourceString">The string to be converted</param>
   /// <returns>The new array of bytes</returns>
   public static byte[] ToByteArray(System.String sourceString)
   {
      return System.Text.UTF8Encoding.UTF8.GetBytes(sourceString);
   }

   /// <summary>
   /// Converts a array of object-type instances to a byte-type array.
   /// </summary>
   /// <param name="tempObjectArray">Array to convert.</param>
   /// <returns>An array of byte type elements.</returns>
   public static byte[] ToByteArray(System.Object[] tempObjectArray)
   {
      byte[] byteArray = null;
      if (tempObjectArray != null)
      {
         byteArray = new byte[tempObjectArray.Length];
         for (int index = 0; index < tempObjectArray.Length; index++)
            byteArray[index] = (byte)tempObjectArray[index];
      }
      return byteArray;
   }

   /*******************************/
   /// <summary>
   /// Provides support for BufferdInputStream
   /// </summary>
   public class BufferedStreamManager
   {
      static public BufferedStreamsHashTable manager = new BufferedStreamsHashTable();

      /// <summary>
      /// A hastable to store and keep the tracks
      /// </summary>		
      public class BufferedStreamsHashTable : System.Collections.Hashtable
      {
         /// <summary>
         /// Reset the point of read to the marked position
         /// </summary>
         /// <param name="stream">The instance of InputStream</param>
         /// <returns>The current mark position</returns>
         public long ResetMark(System.IO.Stream stream)
         {
            if (this[stream] != null)
               return ((StreamProperties)this[stream]).markposition;
            else
               return stream.Position;
         }

         /// <summary>
         /// Marks a position into the stream
         /// </summary>
         /// <param name="index">The position that will be marked</param>
         /// <param name="stream">The stream to mark</param>
         public void MarkPosition(int index, System.IO.Stream stream)
         {
            if (this[stream] == null)
            {
               StreamProperties tempProps = new StreamProperties();
               tempProps.marklimit = index;
               tempProps.markposition = stream.Position;
               Add(stream, tempProps);
            }
            else
            {
               ((StreamProperties)this[stream]).marklimit = index;
               ((StreamProperties)this[stream]).markposition = stream.Position;
            }
         }

         /// <summary>
         /// Inner class. Used to have the properties of mark on .NET
         /// </summary>
         class StreamProperties
         {
            public long markposition = -1;
            public long marklimit;
         }
      }
   }
   /*******************************/
   /// <summary>
   /// Checks if the giving File instance is a directory or file, and returns his Length
   /// </summary>
   /// <param name="file">The File instance to check</param>
   /// <returns>The length of the file</returns>
   public static long FileLength(System.IO.FileInfo file)
   {
      if (file.Exists)
         return file.Length;
      else
         return 0;
   }

   /*******************************/
   /// <summary>
   /// Provides functionality for classes that implements the IList interface.
   /// </summary>
   public class IListSupport
   {
      /// <summary>
      /// Ensures the capacity of the list to be greater or equal than the specified.
      /// </summary>
      /// <param name="list">The list to be checked.</param>
      /// <param name="capacity">The expected capacity.</param>
      public static void EnsureCapacity(System.Collections.ArrayList list, int capacity)
      {
         if (list.Capacity < capacity) list.Capacity = 2 * list.Capacity;
         if (list.Capacity < capacity) list.Capacity = capacity;
      }

      /// <summary>
      /// Adds all the elements contained into the specified collection, starting at the specified position.
      /// </summary>
      /// <param name="index">Position at which to add the first element from the specified collection.</param>
      /// <param name="list">The list used to extract the elements that will be added.</param>
      /// <returns>Returns true if all the elements were successfuly added. Otherwise returns false.</returns>
      public static bool AddAll(System.Collections.IList list, int index, System.Collections.ICollection c)
      {
         bool result = false;
         if (c != null)
         {
            System.Collections.IEnumerator tempEnumerator = new System.Collections.ArrayList(c).GetEnumerator();
            int tempIndex = index;

            while (tempEnumerator.MoveNext())
            {
               list.Insert(tempIndex++, tempEnumerator.Current);
               result = true;
            }
         }

         return result;
      }

      /// <summary>
      /// Returns an enumerator of the collection starting at the specified position.
      /// </summary>
      /// <param name="index">The position to set the iterator.</param>
      /// <returns>An IEnumerator at the specified position.</returns>
      public static System.Collections.IEnumerator GetEnumerator(System.Collections.IList list, int index)
      {
         if ((index < 0) || (index > list.Count))
            throw new System.IndexOutOfRangeException();

         System.Collections.IEnumerator tempEnumerator = list.GetEnumerator();
         if (index > 0)
         {
            int i = 0;
            while ((tempEnumerator.MoveNext()) && (i < index - 1))
               i++;
         }
         return tempEnumerator;
      }
   }


   /*******************************/
   /// <summary>
   /// This class provides functionality not found in .NET collection-related interfaces.
   /// </summary>
   public class ICollectionSupport
   {
      /// <summary>
      /// Adds a new element to the specified collection.
      /// </summary>
      /// <param name="c">Collection where the new element will be added.</param>
      /// <param name="obj">Object to add.</param>
      /// <returns>true</returns>
      public static bool Add(System.Collections.ICollection c, System.Object obj)
      {
         bool added = false;
         //Reflection. Invoke either the "add" or "Add" method.
         System.Reflection.MethodInfo method;
         try
         {
            //Get the "add" method for proprietary classes
            method = c.GetType().GetMethod("Add");
            if (method == null)
               method = c.GetType().GetMethod("add");
            int index = (int)method.Invoke(c, new System.Object[] { obj });
            if (index >= 0)
               added = true;
         }
         catch (System.Exception e)
         {
            throw e;
         }
         return added;
      }

      /// <summary>
      /// Adds all of the elements of the "c" collection to the "target" collection.
      /// </summary>
      /// <param name="target">Collection where the new elements will be added.</param>
      /// <param name="c">Collection whose elements will be added.</param>
      /// <returns>Returns true if at least one element was added, false otherwise.</returns>
      public static bool AddAll(System.Collections.ICollection target, System.Collections.ICollection c)
      {
         System.Collections.IEnumerator e = new System.Collections.ArrayList(c).GetEnumerator();
         bool added = false;

         //Reflection. Invoke "addAll" method for proprietary classes
         System.Reflection.MethodInfo method;
         try
         {
            method = target.GetType().GetMethod("addAll");

            if (method != null)
               added = (bool)method.Invoke(target, new System.Object[] { c });
            else
            {
               method = target.GetType().GetMethod("Add");
               while (e.MoveNext() == true)
               {
                  bool tempBAdded = (int)method.Invoke(target, new System.Object[] { e.Current }) >= 0;
                  added = added ? added : tempBAdded;
               }
            }
         }
         catch (System.Exception ex)
         {
            throw ex;
         }
         return added;
      }

      /// <summary>
      /// Removes all the elements from the collection.
      /// </summary>
      /// <param name="c">The collection to remove elements.</param>
      public static void Clear(System.Collections.ICollection c)
      {
         //Reflection. Invoke "Clear" method or "clear" method for proprietary classes
         System.Reflection.MethodInfo method;
         try
         {
            method = c.GetType().GetMethod("Clear");

            if (method == null)
               method = c.GetType().GetMethod("clear");

            method.Invoke(c, new System.Object[] { });
         }
         catch (System.Exception e)
         {
            throw e;
         }
      }

      /// <summary>
      /// Determines whether the collection contains the specified element.
      /// </summary>
      /// <param name="c">The collection to check.</param>
      /// <param name="obj">The object to locate in the collection.</param>
      /// <returns>true if the element is in the collection.</returns>
      public static bool Contains(System.Collections.ICollection c, System.Object obj)
      {
         bool contains = false;

         //Reflection. Invoke "contains" method for proprietary classes
         System.Reflection.MethodInfo method;
         try
         {
            method = c.GetType().GetMethod("Contains");

            if (method == null)
               method = c.GetType().GetMethod("contains");

            contains = (bool)method.Invoke(c, new System.Object[] { obj });
         }
         catch (System.Exception e)
         {
            throw e;
         }

         return contains;
      }

      /// <summary>
      /// Determines whether the collection contains all the elements in the specified collection.
      /// </summary>
      /// <param name="target">The collection to check.</param>
      /// <param name="c">Collection whose elements would be checked for containment.</param>
      /// <returns>true id the target collection contains all the elements of the specified collection.</returns>
      public static bool ContainsAll(System.Collections.ICollection target, System.Collections.ICollection c)
      {
         System.Collections.IEnumerator e = c.GetEnumerator();

         bool contains = false;

         //Reflection. Invoke "containsAll" method for proprietary classes or "Contains" method for each element in the collection
         System.Reflection.MethodInfo method;
         try
         {
            method = target.GetType().GetMethod("containsAll");

            if (method != null)
               contains = (bool)method.Invoke(target, new Object[] { c });
            else
            {
               method = target.GetType().GetMethod("Contains");
               while (e.MoveNext() == true)
               {
                  if ((contains = (bool)method.Invoke(target, new Object[] { e.Current })) == false)
                     break;
               }
            }
         }
         catch (System.Exception ex)
         {
            throw ex;
         }

         return contains;
      }

      /// <summary>
      /// Removes the specified element from the collection.
      /// </summary>
      /// <param name="c">The collection where the element will be removed.</param>
      /// <param name="obj">The element to remove from the collection.</param>
      public static bool Remove(System.Collections.ICollection c, System.Object obj)
      {
         bool changed = false;

         //Reflection. Invoke "remove" method for proprietary classes or "Remove" method
         System.Reflection.MethodInfo method;
         try
         {
            method = c.GetType().GetMethod("remove");

            if (method != null)
               method.Invoke(c, new System.Object[] { obj });
            else
            {
               method = c.GetType().GetMethod("Contains");
               changed = (bool)method.Invoke(c, new System.Object[] { obj });
               method = c.GetType().GetMethod("Remove");
               method.Invoke(c, new System.Object[] { obj });
            }
         }
         catch (System.Exception e)
         {
            throw e;
         }

         return changed;
      }

      /// <summary>
      /// Removes all the elements from the specified collection that are contained in the target collection.
      /// </summary>
      /// <param name="target">Collection where the elements will be removed.</param>
      /// <param name="c">Elements to remove from the target collection.</param>
      /// <returns>true</returns>
      public static bool RemoveAll(System.Collections.ICollection target, System.Collections.ICollection c)
      {
         System.Collections.ArrayList al = ToArrayList(c);
         System.Collections.IEnumerator e = al.GetEnumerator();

         //Reflection. Invoke "removeAll" method for proprietary classes or "Remove" for each element in the collection
         System.Reflection.MethodInfo method;
         try
         {
            method = target.GetType().GetMethod("removeAll");

            if (method != null)
               method.Invoke(target, new System.Object[] { al });
            else
            {
               method = target.GetType().GetMethod("Remove");
               System.Reflection.MethodInfo methodContains = target.GetType().GetMethod("Contains");

               while (e.MoveNext() == true)
               {
                  while ((bool)methodContains.Invoke(target, new System.Object[] { e.Current }) == true)
                     method.Invoke(target, new System.Object[] { e.Current });
               }
            }
         }
         catch (System.Exception ex)
         {
            throw ex;
         }
         return true;
      }

      /// <summary>
      /// Retains the elements in the target collection that are contained in the specified collection
      /// </summary>
      /// <param name="target">Collection where the elements will be removed.</param>
      /// <param name="c">Elements to be retained in the target collection.</param>
      /// <returns>true</returns>
      public static bool RetainAll(System.Collections.ICollection target, System.Collections.ICollection c)
      {
         System.Collections.IEnumerator e = new System.Collections.ArrayList(target).GetEnumerator();
         System.Collections.ArrayList al = new System.Collections.ArrayList(c);

         //Reflection. Invoke "retainAll" method for proprietary classes or "Remove" for each element in the collection
         System.Reflection.MethodInfo method;
         try
         {
            method = c.GetType().GetMethod("retainAll");

            if (method != null)
               method.Invoke(target, new System.Object[] { c });
            else
            {
               method = c.GetType().GetMethod("Remove");

               while (e.MoveNext() == true)
               {
                  if (al.Contains(e.Current) == false)
                     method.Invoke(target, new System.Object[] { e.Current });
               }
            }
         }
         catch (System.Exception ex)
         {
            throw ex;
         }

         return true;
      }

      /// <summary>
      /// Returns an array containing all the elements of the collection.
      /// </summary>
      /// <returns>The array containing all the elements of the collection.</returns>
      public static System.Object[] ToArray(System.Collections.ICollection c)
      {
         int index = 0;
         System.Object[] objects = new System.Object[c.Count];
         System.Collections.IEnumerator e = c.GetEnumerator();

         while (e.MoveNext())
            objects[index++] = e.Current;

         return objects;
      }

      /// <summary>
      /// Obtains an array containing all the elements of the collection.
      /// </summary>
      /// <param name="objects">The array into which the elements of the collection will be stored.</param>
      /// <returns>The array containing all the elements of the collection.</returns>
      public static System.Object[] ToArray(System.Collections.ICollection c, System.Object[] objects)
      {
         int index = 0;

         System.Type type = objects.GetType().GetElementType();
         System.Object[] objs = (System.Object[])Array.CreateInstance(type, c.Count);

         System.Collections.IEnumerator e = c.GetEnumerator();

         while (e.MoveNext())
            objs[index++] = e.Current;

         //If objects is smaller than c then do not return the new array in the parameter
         if (objects.Length >= c.Count)
            objs.CopyTo(objects, 0);

         return objs;
      }

      /// <summary>
      /// Converts an ICollection instance to an ArrayList instance.
      /// </summary>
      /// <param name="c">The ICollection instance to be converted.</param>
      /// <returns>An ArrayList instance in which its elements are the elements of the ICollection instance.</returns>
      public static System.Collections.ArrayList ToArrayList(System.Collections.ICollection c)
      {
         System.Collections.ArrayList tempArrayList = new System.Collections.ArrayList();
         System.Collections.IEnumerator tempEnumerator = c.GetEnumerator();
         while (tempEnumerator.MoveNext())
            tempArrayList.Add(tempEnumerator.Current);
         return tempArrayList;
      }
   }


   /*******************************/
   /// <summary>
   /// This class has static methods to manage collections.
   /// </summary>
   public class CollectionsSupport
   {
      /// <summary>
      /// Copies the IList to other IList.
      /// </summary>
      /// <param name="SourceList">IList source.</param>
      /// <param name="TargetList">IList target.</param>
      public static void Copy(System.Collections.IList SourceList, System.Collections.IList TargetList)
      {
         for (int i = 0; i < SourceList.Count; i++)
            TargetList[i] = SourceList[i];
      }

      /// <summary>
      /// Replaces the elements of the specified list with the specified element.
      /// </summary>
      /// <param name="List">The list to be filled with the specified element.</param>
      /// <param name="Element">The element with which to fill the specified list.</param>
      public static void Fill(System.Collections.IList List, System.Object Element)
      {
         for (int i = 0; i < List.Count; i++)
            List[i] = Element;
      }

      /// <summary>
      /// This class implements System.Collections.IComparer and is used for Comparing two String objects by evaluating 
      /// the numeric values of the corresponding Char objects in each string.
      /// </summary>
      class CompareCharValues : System.Collections.IComparer
      {
         public int Compare(System.Object x, System.Object y)
         {
            return System.String.CompareOrdinal((System.String)x, (System.String)y);
         }
      }

      /// <summary>
      /// Obtain the maximum element of the given collection with the specified comparator.
      /// </summary>
      /// <param name="Collection">Collection from which the maximum value will be obtained.</param>
      /// <param name="Comparator">The comparator with which to determine the maximum element.</param>
      /// <returns></returns>
      public static System.Object Max(System.Collections.ICollection Collection, System.Collections.IComparer Comparator)
      {
         System.Collections.ArrayList tempArrayList;

         if (((System.Collections.ArrayList)Collection).IsReadOnly)
            throw new System.NotSupportedException();

         if ((Comparator == null) || (Comparator is System.Collections.Comparer))
         {
            try
            {
               tempArrayList = new System.Collections.ArrayList(Collection);
               tempArrayList.Sort();
            }
            catch (System.InvalidOperationException e)
            {
               throw new System.InvalidCastException(e.Message);
            }
            return (System.Object)tempArrayList[Collection.Count - 1];
         }
         else
         {
            try
            {
               tempArrayList = new System.Collections.ArrayList(Collection);
               tempArrayList.Sort(Comparator);
            }
            catch (System.InvalidOperationException e)
            {
               throw new System.InvalidCastException(e.Message);
            }
            return (System.Object)tempArrayList[Collection.Count - 1];
         }
      }

      /// <summary>
      /// Obtain the minimum element of the given collection with the specified comparator.
      /// </summary>
      /// <param name="Collection">Collection from which the minimum value will be obtained.</param>
      /// <param name="Comparator">The comparator with which to determine the minimum element.</param>
      /// <returns></returns>
      public static System.Object Min(System.Collections.ICollection Collection, System.Collections.IComparer Comparator)
      {
         System.Collections.ArrayList tempArrayList;

         if (((System.Collections.ArrayList)Collection).IsReadOnly)
            throw new System.NotSupportedException();

         if ((Comparator == null) || (Comparator is System.Collections.Comparer))
         {
            try
            {
               tempArrayList = new System.Collections.ArrayList(Collection);
               tempArrayList.Sort();
            }
            catch (System.InvalidOperationException e)
            {
               throw new System.InvalidCastException(e.Message);
            }
            return (System.Object)tempArrayList[0];
         }
         else
         {
            try
            {
               tempArrayList = new System.Collections.ArrayList(Collection);
               tempArrayList.Sort(Comparator);
            }
            catch (System.InvalidOperationException e)
            {
               throw new System.InvalidCastException(e.Message);
            }
            return (System.Object)tempArrayList[0];
         }
      }


      /// <summary>
      /// Sorts an IList collections
      /// </summary>
      /// <param name="list">The System.Collections.IList instance that will be sorted</param>
      /// <param name="Comparator">The Comparator criteria, null to use natural comparator.</param>
      public static void Sort(System.Collections.IList list, System.Collections.IComparer Comparator)
      {
         if (((System.Collections.ArrayList)list).IsReadOnly)
            throw new System.NotSupportedException();

         if ((Comparator == null) || (Comparator is System.Collections.Comparer))
         {
            try
            {
               ((System.Collections.ArrayList)list).Sort();
            }
            catch (System.InvalidOperationException e)
            {
               throw new System.InvalidCastException(e.Message);
            }
         }
         else
         {
            try
            {
               ((System.Collections.ArrayList)list).Sort(Comparator);
            }
            catch (System.InvalidOperationException e)
            {
               throw new System.InvalidCastException(e.Message);
            }
         }
      }

      /// <summary>
      /// Shuffles the list randomly.
      /// </summary>
      /// <param name="List">The list to be shuffled.</param>
      public static void Shuffle(System.Collections.IList List)
      {
         System.Random RandomList = new System.Random(unchecked((int)System.DateTime.Now.Ticks));
         Shuffle(List, RandomList);
      }

      /// <summary>
      /// Shuffles the list randomly.
      /// </summary>
      /// <param name="List">The list to be shuffled.</param>
      /// <param name="RandomList">The random to use to shuffle the list.</param>
      public static void Shuffle(System.Collections.IList List, System.Random RandomList)
      {
         System.Object source = null;
         int target = 0;

         for (int i = 0; i < List.Count; i++)
         {
            target = RandomList.Next(List.Count);
            source = (System.Object)List[i];
            List[i] = List[target];
            List[target] = source;
         }
      }
   }


   /*******************************/
   /// <summary>
   /// The class performs token processing in strings
   /// </summary>
   public class Tokenizer : System.Collections.IEnumerator
   {
      /// Position over the string
      private long currentPos = 0;

      /// Include demiliters in the results.
      private bool includeDelims = false;

      /// Char representation of the String to tokenize.
      private char[] chars = null;

      //The tokenizer uses the default delimiter set: the space character, the tab character, the newline character, and the carriage-return character and the form-feed character
      private string delimiters = " \t\n\r\f";

      /// <summary>
      /// Initializes a new class instance with a specified string to process
      /// </summary>
      /// <param name="source">String to tokenize</param>
      public Tokenizer(System.String source)
      {
         this.chars = source.ToCharArray();
      }

      /// <summary>
      /// Initializes a new class instance with a specified string to process
      /// and the specified token delimiters to use
      /// </summary>
      /// <param name="source">String to tokenize</param>
      /// <param name="delimiters">String containing the delimiters</param>
      public Tokenizer(System.String source, System.String delimiters)
         : this(source)
      {
         this.delimiters = delimiters;
      }


      /// <summary>
      /// Initializes a new class instance with a specified string to process, the specified token 
      /// delimiters to use, and whether the delimiters must be included in the results.
      /// </summary>
      /// <param name="source">String to tokenize</param>
      /// <param name="delimiters">String containing the delimiters</param>
      /// <param name="includeDelims">Determines if delimiters are included in the results.</param>
      public Tokenizer(System.String source, System.String delimiters, bool includeDelims)
         : this(source, delimiters)
      {
         this.includeDelims = includeDelims;
      }


      /// <summary>
      /// Returns the next token from the token list
      /// </summary>
      /// <returns>The string value of the token</returns>
      public System.String NextToken()
      {
         return NextToken(this.delimiters);
      }

      /// <summary>
      /// Returns the next token from the source string, using the provided
      /// token delimiters
      /// </summary>
      /// <param name="delimiters">String containing the delimiters to use</param>
      /// <returns>The string value of the token</returns>
      public System.String NextToken(System.String delimiters)
      {
         //According to documentation, the usage of the received delimiters should be temporary (only for this call).
         //However, it seems it is not true, so the following line is necessary.
         this.delimiters = delimiters;

         //at the end 
         if (this.currentPos == this.chars.Length)
            throw new System.ArgumentOutOfRangeException();
         //if over a delimiter and delimiters must be returned
         else if ((System.Array.IndexOf(delimiters.ToCharArray(), chars[this.currentPos]) != -1)
                 && this.includeDelims)
            return "" + this.chars[this.currentPos++];
         //need to get the token wo delimiters.
         else
            return nextToken(delimiters.ToCharArray());
      }

      //Returns the nextToken wo delimiters
      private System.String nextToken(char[] delimiters)
      {
         string token = "";
         long pos = this.currentPos;

         //skip possible delimiters
         while (System.Array.IndexOf(delimiters, this.chars[currentPos]) != -1)
            //The last one is a delimiter (i.e there is no more tokens)
            if (++this.currentPos == this.chars.Length)
            {
               this.currentPos = pos;
               throw new System.ArgumentOutOfRangeException();
            }

         //getting the token
         while (System.Array.IndexOf(delimiters, this.chars[this.currentPos]) == -1)
         {
            token += this.chars[this.currentPos];
            //the last one is not a delimiter
            if (++this.currentPos == this.chars.Length)
               break;
         }
         return token;
      }


      /// <summary>
      /// Determines if there are more tokens to return from the source string
      /// </summary>
      /// <returns>True or false, depending if there are more tokens</returns>
      public bool HasMoreTokens()
      {
         //keeping the current pos
         long pos = this.currentPos;

         try
         {
            this.NextToken();
         }
         catch (System.ArgumentOutOfRangeException)
         {
            return false;
         }
         finally
         {
            this.currentPos = pos;
         }
         return true;
      }

      /// <summary>
      /// Remaining tokens count
      /// </summary>
      public int Count
      {
         get
         {
            //keeping the current pos
            long pos = this.currentPos;
            int i = 0;

            try
            {
               while (true)
               {
                  this.NextToken();
                  i++;
               }
            }
            catch (System.ArgumentOutOfRangeException)
            {
               this.currentPos = pos;
               return i;
            }
         }
      }

      /// <summary>
      ///  Performs the same action as NextToken.
      /// </summary>
      public System.Object Current
      {
         get
         {
            return (Object)this.NextToken();
         }
      }

      /// <summary>
      //  Performs the same action as HasMoreTokens.
      /// </summary>
      /// <returns>True or false, depending if there are more tokens</returns>
      public bool MoveNext()
      {
         return this.HasMoreTokens();
      }

      /// <summary>
      /// Does nothing.
      /// </summary>
      public void Reset()
      {
         ;
      }
   }
   /*******************************/
   /// <summary>
   /// Represents the methods to support some operations over files.
   /// </summary>
   public class FileSupport
   {
      /// <summary>
      /// Creates a new empty file with the specified pathname.
      /// </summary>
      /// <param name="path">The abstract pathname of the file</param>
      /// <returns>True if the file does not exist and was succesfully created</returns>
      public static bool CreateNewFile(System.IO.FileInfo path)
      {
         path.Refresh();
         if (path.Exists)
         {
            return false;
         }
         else
         {
            using (System.IO.FileStream createdFile = path.Create())
            {
               createdFile.Close();
            }
            return true;
         }
      }

      /// <summary>
      /// Compares the specified object with the specified path
      /// </summary>
      /// <param name="path">An abstract pathname to compare with</param>
      /// <param name="file">An object to compare with the given pathname</param>
      /// <returns>A value indicating a lexicographically comparison of the parameters</returns>
      public static int CompareTo(System.IO.FileInfo path, System.Object file)
      {
         if (file is System.IO.FileInfo)
         {
            System.IO.FileInfo fileInfo = (System.IO.FileInfo)file;
            return path.FullName.CompareTo(fileInfo.FullName);
         }
         else
         {
            throw new System.InvalidCastException();
         }
      }

      /// <summary>
      /// Returns an array of abstract pathnames representing the files and directories of the specified path.
      /// </summary>
      /// <param name="path">The abstract pathname to list it childs.</param>
      /// <returns>An array of abstract pathnames childs of the path specified or null if the path is not a directory</returns>
      public static System.IO.FileInfo[] GetFiles(System.IO.FileInfo path)
      {
         if ((path.Attributes & System.IO.FileAttributes.Directory) > 0)
         {
            String[] fullpathnames = System.IO.Directory.GetFileSystemEntries(path.FullName);
            System.IO.FileInfo[] result = new System.IO.FileInfo[fullpathnames.Length];
            for (int i = 0; i < result.Length; i++)
               result[i] = new System.IO.FileInfo(fullpathnames[i]);
            return result;
         }
         else return null;
      }

      /// <summary>
      /// Creates an instance of System.Uri class with the pech specified
      /// </summary>
      /// <param name="path">The abstract path name to create the Uri</param>
      /// <returns>A System.Uri instance constructed with the specified path</returns>
      public static System.Uri ToUri(System.IO.FileInfo path)
      {
         System.UriBuilder uri = new System.UriBuilder();
         uri.Path = path.FullName;
         uri.Host = String.Empty;
         uri.Scheme = System.Uri.UriSchemeFile;
         return uri.Uri;
      }

      /// <summary>
      /// Returns true if the file specified by the pathname is a hidden file.
      /// </summary>
      /// <param name="file">The abstract pathname of the file to test</param>
      /// <returns>True if the file is hidden, false otherwise</returns>
      public static bool IsHidden(System.IO.FileInfo file)
      {
         return ((file.Attributes & System.IO.FileAttributes.Hidden) > 0);
      }

      /// <summary>
      /// Sets the read-only property of the file to true.
      /// </summary>
      /// <param name="file">The abstract path name of the file to modify</param>
      public static bool SetReadOnly(System.IO.FileInfo file)
      {
         try
         {
            file.Attributes = file.Attributes | System.IO.FileAttributes.ReadOnly;
            return true;
         }
         catch (System.Exception exception)
         {
            String exceptionMessage = exception.Message;
            return false;
         }
      }

      /// <summary>
      /// Sets the last modified time of the specified file with the specified value.
      /// </summary>
      /// <param name="file">The file to change it last-modified time</param>
      /// <param name="date">Total number of miliseconds since January 1, 1970 (new last-modified time)</param>
      /// <returns>True if the operation succeeded, false otherwise</returns>
      public static bool SetLastModified(System.IO.FileInfo file, long date)
      {
         try
         {
            long valueConstant = (new System.DateTime(1969, 12, 31, 18, 0, 0)).Ticks;
            file.LastWriteTime = new System.DateTime((date * 10000L) + valueConstant);
            return true;
         }
         catch (System.Exception exception)
         {
            String exceptionMessage = exception.Message;
            return false;
         }
      }
   }
   /*******************************/
   /*******************************/
   /// <summary>
   /// Gives support functions to Http internet connections.
   /// </summary>
   public class URLConnectionSupport
   {
      /// <summary>
      /// Sets the request property for the specified key
      /// </summary>
      /// <param name="connection">Connection used to assign the property value</param>
      /// <param name="key">Property name to obtain the property value</param>
      /// <param name="keyValue">The value to associate with the specified property</param>
      public static void SetRequestProperty(System.Net.HttpWebRequest connection, System.String key, System.String keyValue)
      {
         connection.Headers.Set(key, keyValue);
      }

      /// <summary>
      /// Gets the request property for the specified key
      /// </summary>
      /// <param name="connection">Connection used to obtain the property value</param>
      /// <param name="key">Property name to return it's property value</param>
      /// <returns>The value associated with the specified property</returns>
      public static System.String GetRequestProperty(System.Net.HttpWebRequest connection, System.String key)
      {
         try
         {
            return connection.Headers.Get(key);
         }
         catch (System.Exception)
         { }
         return "";
      }

      /// <summary>
      /// Receives a key and returns it's default property value
      /// </summary>
      /// <param name="key">Key name to obtain the default request value</param>
      /// <returns>The default value associated with the property</returns>
      public static System.String GetDefaultRequestProperty(System.String key)
      {
         return null;
      }

      /// <summary> 
      /// Gets the value of the "Content-Encoding" property from the collection of headers associated with the specified HttpWebRequest
      /// </summary>
      /// <param name="request">Instance of HttpWebRequest to get the headers from</param>
      /// <returns>The value of the "Content-Encoding" property if found, otherwise returns null</returns>
      public static System.String GetContentEncoding(System.Net.HttpWebRequest request)
      {
         try
         {
            return request.GetResponse().Headers.Get("Content-Encoding");
         }
         catch (System.Exception)
         { }
         return null;
      }

      /// <summary>
      /// Gets the sending date of the resource referenced by the HttpRequest
      /// </summary>
      /// <param name="request">Instance of HttpWebRequest to get the date from</param>
      /// <returns>The sending date of the resource if found, otherwise 0</returns>
      public static long GetSendingDate(System.Net.HttpWebRequest request)
      {
         long headerDate;
         try
         {
            headerDate = System.DateTime.Parse(request.GetResponse().Headers.Get("Date")).Ticks;
         }
         catch (System.Exception)
         {
            headerDate = 0;
         }
         return headerDate;
      }

      /// <summary>
      /// Gets the key for the specified index from the KeysCollection of the specified HttpWebRequest's Headers property
      /// </summary>
      /// <param name="request">Instance HttpWebRequest to get the key from</param>
      /// <param name="indexField">Index of the field to get the corresponding key</param>
      /// <returns>The key for the specified index if found, otherwise null</returns>
      public static System.String GetHeaderFieldKey(System.Net.HttpWebRequest request, int indexField)
      {
         try
         {
            return request.GetResponse().Headers.Keys.Get(indexField);
         }
         catch (System.Exception)
         { }
         return null;
      }

      /// <summary>
      /// Gets the value of the "Last-Modified" property from the collection of headers associated with the specified HttWebRequest
      /// </summary>
      /// <param name="request">Instance of HttpWebRequest to get the headers from</param>
      /// <returns>The value of the "Last-Modified" property if found, otherwise returns null</returns>
      public static long GetLastModifiedHeaderField(System.Net.HttpWebRequest request)
      {
         long fieldHeaderDate;
         try
         {
            fieldHeaderDate = System.DateTime.Parse(request.GetResponse().Headers.Get("Last-Modified")).Ticks;
         }
         catch (System.Exception)
         {
            fieldHeaderDate = 0;
         }
         return fieldHeaderDate;
      }

      /// <summary>
      /// Gets the value of the named field parsed as date in milliseconds
      /// </summary>
      /// <param name="request">Instance of System.Net.HttpWebRequest to get the headers from</param>
      /// <param name="fieldName">Name of the header field</param>
      /// <param name="defaultValue">A default value to return if the value does not exist in the headers</param>
      /// <returns></returns>
      public static long GetHeaderFieldDate(System.Net.HttpWebRequest request, System.String fieldName, long defaultValue)
      {
         long fieldHeaderDate;
         try
         {
            fieldHeaderDate = System.DateTime.Parse(request.GetResponse().Headers.Get(fieldName)).Ticks;
         }
         catch (System.Exception)
         {
            fieldHeaderDate = defaultValue;
         }
         return fieldHeaderDate;
      }
   }

   /*******************************/
   /// <summary>
   /// This interface is used to test if a XmlNode fits with a TestCase prepared in the TestXmlNode method.
   /// It has three short constants values: Accept, Reject, Skip.
   /// </summary>
   public interface FilterXml
   {
      /// <summary>
      /// This is the Static call to the TextXmlNode method
      /// </summary>
      /// <param name="Filter">The FilterXmlClass to be applied to de node</param>
      /// <param name="Node">The node to be tested</param>
      /// <returns>A short constant</returns>
      short Test(System.Xml.XmlNode Node);
   }

   public struct FilterFields
   {
      public const short Accept = 100;
      public const short Reject = 101;
      public const short Skip = 102;
      public const short All = 20;
   }


   /*******************************/
   /// <summary>
   /// This class is used to extract a subset of the nodes in a DOM document and emulates a List with those nodes,
   /// this is possible with the help of the ChildNodes property of the XmlNode class.
   /// 
   /// This class can be extended and modified.
   /// </summary>
   public class TraversalIteratorSupport
   {
      private const int All = 20;
      private System.Xml.XmlNode Root;
      private System.Xml.XmlNode Current;
      private int TypeToShow;
      private FilterXml Filter;
      private int Index;
      private System.Collections.ArrayList List;

      /// <summary>
      /// This utilitary method is used to set the Current node and the index acording with the specified node
      /// </summary>
      /// <param name="iterator">The TraversalIteratorSupport to be used</param>
      /// <param name="current">The node to be set</param>		
      private static void SetIteratorIndex(TraversalIteratorSupport iterator, System.Xml.XmlNode current)
      {
         iterator.Current = current;
         iterator.Index = iterator.List.IndexOf(current);
      }

      /// <summary>
      /// This method returns the FirstChild of the current node in the TraversalIteratorSupport instance.
      /// </summary>
      /// <param name="Iterator">The instance of iterator to be used</param>
      /// <returns> A XmlNode first child of the current node in the iterator if it pass the filter otherwise returns null</returns>
      public static System.Xml.XmlNode GetFirstChild(TraversalIteratorSupport Iterator)
      {
         System.Xml.XmlNode temp_node;
         temp_node = Iterator.Current.FirstChild;
         if (ChildrenTest(Iterator, temp_node))
            return temp_node;
         else
            return null;
      }

      /// <summary>
      /// This method returns the Current XmlNode instance
      /// </summary>
      /// <param name="Iterator">The Iterator instance to be used.</param>
      /// <returns>The Current XmlNode instance in the iterator.</returns>
      public static System.Xml.XmlNode GetCurrentNode(TraversalIteratorSupport Iterator)
      {
         return Iterator.Current;
      }

      /// <summary>
      /// This method returns the LastChild of the CurrentNode in the TraversalIteratorSupport instance.
      /// </summary>
      /// <param name="Iterator">The instance of iterator to be used</param>
      /// <returns>A XmlNode last child of the current node in the iterator if it pass the filter otherwise returns null</returns>
      public static System.Xml.XmlNode GetLastChild(TraversalIteratorSupport Iterator)
      {
         System.Xml.XmlNode temp_node;
         temp_node = Iterator.Current.LastChild;
         if (ChildrenTest(Iterator, temp_node))
            return temp_node;
         else
            return null;
      }

      /// <summary>
      /// This is a utilitary function that indicates if one XmlNode instance pass the filter process. If true, the method modify the CurrentNode property of the TraversalIteratorSupport instance
      /// </summary>
      /// <param name="Iterator">The iterator instance to be used</param>
      /// <param name="node">The XmlNode instance to be tested</param>
      /// <returns>True if the XmlNode instance pass the filter otherwise false.</returns>
      private static bool ChildrenTest(TraversalIteratorSupport Iterator, System.Xml.XmlNode node)
      {
         if (node != null)
         {
            if (Iterator.TypeToShow == TraversalIteratorSupport.All || node.NodeType == (System.Xml.XmlNodeType)Iterator.TypeToShow)
            {
               if (Iterator.Filter != null)
               {
                  short temp_short = Iterator.Filter.Test(node);
                  if (temp_short == FilterFields.Accept)
                  {
                     SetIteratorIndex(Iterator, node);
                     return true;
                  }
                  else
                     return false;
               }
               else
               {
                  SetIteratorIndex(Iterator, node);
                  return true;
               }
            }
            else return false;
         }
         else return false;
      }

      /// <summary>
      /// This method returns the next sibling of the CurrentNode.
      /// </summary>
      /// <param name="Iterator">The TraversalIteratorSupport instance to be used.</param>
      /// <returns> A System.Xml.XmlNode instance with the next sibling of the current node, otherwise false.</returns>
      public static System.Xml.XmlNode NextSibling(TraversalIteratorSupport Iterator)
      {
         System.Xml.XmlNode temp_node;
         while ((temp_node = Iterator.Current.NextSibling) != null)
         {
            if (ChildrenTest(Iterator, temp_node))
               return temp_node;
         }
         return null;
      }

      /// <summary>
      /// This method returns the previous sibling of the CurrentNode.
      /// </summary>
      /// <param name="Iterator">The TraversalIteratorSupport instance to be used.</param>
      /// <returns> A System.Xml.XmlNode instance with the previous sibling of the current node, otherwise false.</returns>
      public static System.Xml.XmlNode PreviousSibling(TraversalIteratorSupport Iterator)
      {
         System.Xml.XmlNode temp_node;
         while ((temp_node = Iterator.Current.PreviousSibling) != null)
         {
            if (ChildrenTest(Iterator, temp_node))
               return temp_node;
         }
         return null;
      }

      /// <summary>
      /// This method returns the Parent node of the CurrentNode in the TraversalIteratorSupport instance.
      /// </summary>
      /// <param name="Iterator">The TraversalIteratorSupport instance to be used.</param>
      /// <returns>A System.Xml.XmlNode instance with the parent of the current node, otherwise false.</returns>
      public static System.Xml.XmlNode ParentNode(TraversalIteratorSupport Iterator)
      {
         System.Xml.XmlNode temp_node;
         while ((temp_node = Iterator.Current.ParentNode) != null)
         {
            if (ChildrenTest(Iterator, temp_node))
               return temp_node;
         }
         return null;
      }

      /// <summary>
      /// This method sets the current node in the TraversalIteratorSupport instance
      /// </summary>
      /// <param name="Iterator">The TraversalIteratorSupport instance to be used.</param>
      /// <param name="node"> The node to be setted as Current in the instance</param>
      public static void SetCurrentNode(TraversalIteratorSupport Iterator, System.Xml.XmlNode node)
      {
         if (Iterator.List.Contains(node))
            ChildrenTest(Iterator, node);

      }

      /// <summary>
      /// Creates a new instance of the TraversalIteratorSupport class.
      /// </summary>
      /// <param name="Root"> Node that will be the first element of the Iterator.</param>
      /// <param name="TypeToShow">This parameter indicates which kinds of node will be shown.</param>
      /// <param name="Filter">This parameter will be used to Filter the nodes that will be shown, this property could be set to null.</param>
      public static TraversalIteratorSupport CreateTraversalIterator(System.Xml.XmlNode Root, int TypeToShow, FilterXml Filter)
      {
         TraversalIteratorSupport Iterator = new TraversalIteratorSupport();
         Iterator.Root = Root;
         Iterator.TypeToShow = TypeToShow;
         Iterator.Filter = Filter;
         Iterator.Index = -1;
         Iterator.List = LoadNodes(new System.Collections.ArrayList(), Root);
         return Iterator;
      }

      /// <summary>
      /// This method loads recursively all the child nodes of a System.Xml.XmlNode instance.
      /// </summary>
      /// <param name="TempList">The list that will be populated with the childs</param>
      /// <param name="root">The Parent XmlNode</param>
      /// <returns>A list with all the child nodes of the Root XmlNode</returns>
      private static System.Collections.ArrayList LoadNodes(System.Collections.ArrayList TempList, System.Xml.XmlNode root)
      {
         System.Xml.XmlNode Node;
         System.Xml.XmlNodeList TempChilds = root.ChildNodes;
         int Count = TempChilds.Count;
         for (int i = 0; i < Count; i++)
         {
            Node = TempChilds[i];
            TempList.Add(Node);
            if (Node.HasChildNodes)
               LoadNodes(TempList, Node);
         }
         return TempList;
      }

      /// <summary>
      /// This method resets the TraversalIteratorSupport instance.
      /// </summary>
      /// <param name="Iterator">The TraversalIteratorSupport instance to reset</param>
      public static void ResetTraversalIterator(TraversalIteratorSupport Iterator)
      {
         Iterator.Root = null;
         Iterator.TypeToShow = -1;
         Iterator.Filter = null;
         Iterator.Index = -1;
         Iterator.List = null;
      }

      /// <summary>
      /// This method returns the FilterXml instance used by the TraversalIteratorSupport instance.
      /// </summary>
      /// <param name="Iterator">The TraversalIteratorSupport instance</param>
      /// <returns>A FilterXml instance.</returns>
      public static FilterXml GetFilter(TraversalIteratorSupport Iterator)
      {
         return Iterator.Filter;
      }

      /// <summary>
      /// This method returns the Root element of the collection.
      /// </summary>
      /// <param name="Iterator">The TraversalIteratorSupport instance.</param>
      /// <returns>A XmlNode instance.</returns>
      public static System.Xml.XmlNode GetRoot(TraversalIteratorSupport Iterator)
      {
         return Iterator.Root;
      }

      /// <summary>
      /// This method returns the type of nodes that will be shown.
      /// </summary>
      /// <param name="Iterator">The TraversalIteratorSupport instance</param>
      /// <returns>A XmlNodeType object casted as an integer instance.</returns>
      public static int GetNodeTypeToShow(TraversalIteratorSupport Iterator)
      {
         return Iterator.TypeToShow;
      }

      /// <summary>
      /// This method returns the next node that fit with the Filter conditions.
      /// </summary>
      /// <param name="Iterator">The TraversalIteratorSupport instance.</param>
      /// <returns>The XmlNode that fit or null no node were found</returns>
      public static System.Xml.XmlNode Next(TraversalIteratorSupport Iterator)
      {
         System.Xml.XmlNode temp_node = null;
         Iterator.Index++;
         if (Iterator.Index == -1) temp_node = Iterator.Root;
         else
         {
            if (Iterator.Index > -1 && Iterator.Index < Iterator.List.Count)
            {
               if (Iterator.Root.HasChildNodes) temp_node = (System.Xml.XmlNode)Iterator.List[Iterator.Index];
               else return null;
            }
            else return null;
         }
         if (temp_node != null)
         {
            if (Iterator.TypeToShow == TraversalIteratorSupport.All || temp_node.NodeType == (System.Xml.XmlNodeType)Iterator.TypeToShow)
            {
               if (Iterator.Filter != null)
               {
                  short temp_short = Iterator.Filter.Test(temp_node);
                  if (temp_short == FilterFields.Accept)
                  {
                     Iterator.Current = temp_node;
                     return temp_node;
                  }
                  else
                  {
                     if (temp_short == FilterFields.Skip) return Next(Iterator);
                     else
                     {
                        if (temp_short == FilterFields.Reject) return Next(Iterator);
                        else return null;
                     }
                  }
               }
               else
               {
                  Iterator.Current = temp_node;
                  return temp_node;
               }
            }
            else return Next(Iterator);
         }
         else return null;
      }

      /// <summary>
      /// This method returns the previous node that fit with the filters conditions.
      /// </summary>
      /// <param name="Iterator">The TraversalIterator instances.</param>
      /// <returns>The XmlNode that fit or null no node were found.</returns>
      public static System.Xml.XmlNode Previous(TraversalIteratorSupport Iterator)
      {
         System.Xml.XmlNode temp_node = null;
         Iterator.Index--;
         if (Iterator.Index < -1) return null;
         if (Iterator.Index == -1) temp_node = Iterator.Root;
         else
         {
            if (Iterator.Index > -1 && Iterator.Index < Iterator.List.Count)
            {
               if (Iterator.Root.HasChildNodes) temp_node = (System.Xml.XmlNode)Iterator.List[Iterator.Index];
               else return null;
            }
            else return null;
         }
         if (temp_node != null)
         {
            if (Iterator.TypeToShow == TraversalIteratorSupport.All || temp_node.NodeType == (System.Xml.XmlNodeType)Iterator.TypeToShow)
            {
               if (Iterator.Filter != null)
               {
                  short temp_short = Iterator.Filter.Test(temp_node);
                  if (temp_short == FilterFields.Accept)
                  {
                     Iterator.Current = temp_node;
                     return temp_node;
                  }
                  else
                  {
                     if (temp_short == FilterFields.Skip) return Previous(Iterator);
                     else
                     {
                        if (temp_short == FilterFields.Reject) return Previous(Iterator);
                        else return null;
                     }
                  }
               }
               else
               {
                  Iterator.Current = temp_node;
                  return temp_node;
               }
            }
            else return Previous(Iterator);
         }
         else return null;
      }
   }
   /*******************************/
   /// <summary>
   /// Retrieves the elements of a System.Drawing.Drawing2D.Matrix instance in a array of double values.
   /// </summary>
   /// <param name="tempMatrix">Matrix to get the elements from.</param>
   /// <param name="elements">Array of double values to store elements of the matrix.</param>
   public static void GetMatrix(System.Drawing.Drawing2D.Matrix tempMatrix, double[] elements)
   {
      elements[0] = (System.Single)tempMatrix.Elements.GetValue(0);
      elements[1] = (System.Single)tempMatrix.Elements.GetValue(1);
      elements[2] = (System.Single)tempMatrix.Elements.GetValue(2);
      elements[3] = (System.Single)tempMatrix.Elements.GetValue(3);
      if (elements.Length > 4)
      {
         elements[4] = (System.Single)tempMatrix.Elements.GetValue(4);
         elements[5] = (System.Single)tempMatrix.Elements.GetValue(5);
      }
   }


   /*******************************/
   /// <summary>
   /// This class contains support methods to work with GraphicsPathIterators.
   /// </summary>
   public class GraphicsPathIteratorSupport
   {
      /// <summary>
      /// Adds the specified GraphicsPathIterator to the specified GraphicsPath object.
      /// </summary>
      /// <param name="graphicsPath">The GraphicsPath object to add the GraphicsPathIterator to.</param>
      /// <param name="pathIterator">The GraphicsPathIterator to add.</param>
      /// <param name="connect">A boolean value that specifies whether the first figure in the added path 
      /// is part of the last figure in the specified GraphicsPath.</param>
      public static void AddGraphicsPathIterator(System.Drawing.Drawing2D.GraphicsPath graphicsPath, System.Drawing.Drawing2D.GraphicsPathIterator pathIterator, bool connect)
      {
         System.Drawing.PointF[] pathPoints = new System.Drawing.PointF[pathIterator.Count];
         byte[] pathTypes = new byte[pathIterator.Count];
         pathIterator.CopyData(ref pathPoints, ref pathTypes, 0, pathIterator.Count - 1);
         System.Drawing.Drawing2D.GraphicsPath tempGraphicsPath = new System.Drawing.Drawing2D.GraphicsPath(pathPoints, pathTypes);
         graphicsPath.AddPath(tempGraphicsPath, connect);
      }

      /// <summary>
      /// Makes transformations to a GraphicsPath object and returns a new GraphicsPathIterator 
      /// constructed with the transformed GraphicsPath object.
      /// </summary>
      /// <param name="graphicsPath">The GraphicsPath object to transform.</param>
      /// <param name="transform">The Matrix transformation to apply.</param>
      /// <returns>A new tranformed GraphicsPathIterator object.</returns>
      public static System.Drawing.Drawing2D.GraphicsPathIterator GetGraphicsPathIterator(System.Drawing.Drawing2D.GraphicsPath graphicsPath, System.Drawing.Drawing2D.Matrix transform)
      {
         System.Drawing.Drawing2D.GraphicsPath tempGraphicsPath = new System.Drawing.Drawing2D.GraphicsPath(graphicsPath.PathPoints, graphicsPath.PathTypes);
         if (transform == null)
            tempGraphicsPath.Transform(new System.Drawing.Drawing2D.Matrix());
         else
            tempGraphicsPath.Transform(transform);
         return new System.Drawing.Drawing2D.GraphicsPathIterator(tempGraphicsPath);
      }

      /// <summary>
      /// Makes transformations to a GraphicsPath object, created using the specified rectangle, and 
      /// returns a new GraphicsPathIterator constructed with the transformed GraphicsPath object.
      /// </summary>
      /// <param name="rectangle">The rectangle used to create the GraphicsPath object.</param>
      /// <param name="transform">The transformation to apply.</param>
      /// <returns>A new transformed GraphicsPathIterator object.</returns>
      public static System.Drawing.Drawing2D.GraphicsPathIterator GetGraphicsPathIterator(System.Drawing.RectangleF rectangle, System.Drawing.Drawing2D.Matrix transform)
      {
         System.Drawing.Drawing2D.GraphicsPath tempGraphicsPath = new System.Drawing.Drawing2D.GraphicsPath();
         tempGraphicsPath.AddRectangle(rectangle);
         if (transform == null)
            tempGraphicsPath.Transform(new System.Drawing.Drawing2D.Matrix());
         else
            tempGraphicsPath.Transform(transform);
         return new System.Drawing.Drawing2D.GraphicsPathIterator(tempGraphicsPath);
      }
   }


   /*******************************/
   /// <summary>
   /// Implements number format functions
   /// </summary>
   [Serializable]
   public class TextNumberFormat
   {

      //Current localization number format infomation
      private System.Globalization.NumberFormatInfo numberFormat;
      //Enumeration of format types that can be used
      private enum formatTypes { General, Number, Currency, Percent };
      //Current format type used in the instance
      private int numberFormatType;
      //Indicates if grouping is being used
      private bool groupingActivated;
      //Current separator used
      private System.String separator;
      //Number of maximun digits in the integer portion of the number to represent the number
      private int maxIntDigits;
      //Number of minimum digits in the integer portion of the number to represent the number
      private int minIntDigits;
      //Number of maximun digits in the fraction portion of the number to represent the number
      private int maxFractionDigits;
      //Number of minimum digits in the integer portion of the number to represent the number
      private int minFractionDigits;

      /// <summary>
      /// Initializes a new instance of the object class with the default values
      /// </summary>
      public TextNumberFormat()
      {
         this.numberFormat = new System.Globalization.NumberFormatInfo();
         this.numberFormatType = (int)TextNumberFormat.formatTypes.General;
         this.groupingActivated = true;
         this.separator = this.GetSeparator((int)TextNumberFormat.formatTypes.General);
         this.maxIntDigits = 127;
         this.minIntDigits = 1;
         this.maxFractionDigits = 3;
         this.minFractionDigits = 0;
      }

      /// <summary>
      /// Sets the Maximum integer digits value. 
      /// </summary>
      /// <param name="newValue">the new value for the maxIntDigits field</param>
      public void setMaximumIntegerDigits(int newValue)
      {
         maxIntDigits = newValue;
         if (newValue <= 0)
         {
            maxIntDigits = 0;
            minIntDigits = 0;
         }
         else if (maxIntDigits < minIntDigits)
         {
            minIntDigits = maxIntDigits;
         }
      }

      /// <summary>
      /// Sets the minimum integer digits value. 
      /// </summary>
      /// <param name="newValue">the new value for the minIntDigits field</param>
      public void setMinimumIntegerDigits(int newValue)
      {
         minIntDigits = newValue;
         if (newValue <= 0)
         {
            minIntDigits = 0;
         }
         else if (maxIntDigits < minIntDigits)
         {
            maxIntDigits = minIntDigits;
         }
      }

      /// <summary>
      /// Sets the maximum fraction digits value. 
      /// </summary>
      /// <param name="newValue">the new value for the maxFractionDigits field</param>
      public void setMaximumFractionDigits(int newValue)
      {
         maxFractionDigits = newValue;
         if (newValue <= 0)
         {
            maxFractionDigits = 0;
            minFractionDigits = 0;
         }
         else if (maxFractionDigits < minFractionDigits)
         {
            minFractionDigits = maxFractionDigits;
         }
      }

      /// <summary>
      /// Sets the minimum fraction digits value. 
      /// </summary>
      /// <param name="newValue">the new value for the minFractionDigits field</param>
      public void setMinimumFractionDigits(int newValue)
      {
         minFractionDigits = newValue;
         if (newValue <= 0)
         {
            minFractionDigits = 0;
         }
         else if (maxFractionDigits < minFractionDigits)
         {
            maxFractionDigits = minFractionDigits;
         }
      }

      /// <summary>
      /// Initializes a new instance of the class with the specified number format
      /// and the amount of fractional digits to use
      /// </summary>
      /// <param name="theType">Number format</param>
      /// <param name="digits">Number of fractional digits to use</param>
      private TextNumberFormat(TextNumberFormat.formatTypes theType, int digits)
      {
         this.numberFormat = System.Globalization.NumberFormatInfo.CurrentInfo;
         this.numberFormatType = (int)theType;
         this.groupingActivated = true;
         this.separator = this.GetSeparator((int)theType);
         this.maxIntDigits = 127;
         this.minIntDigits = 1;
         this.maxFractionDigits = 3;
         this.minFractionDigits = 0;
      }

      /// <summary>
      /// Initializes a new instance of the class with the specified number format,
      /// uses the system's culture information,
      /// and assigns the amount of fractional digits to use
      /// </summary>
      /// <param name="theType">Number format</param>
      /// <param name="cultureNumberFormat">Represents information about a specific culture including the number formatting</param>
      /// <param name="digits">Number of fractional digits to use</param>
      private TextNumberFormat(TextNumberFormat.formatTypes theType, System.Globalization.CultureInfo cultureNumberFormat, int digits)
      {
         this.numberFormat = cultureNumberFormat.NumberFormat;
         this.numberFormatType = (int)theType;
         this.groupingActivated = true;
         this.separator = this.GetSeparator((int)theType);
         this.maxIntDigits = 127;
         this.minIntDigits = 1;
         this.maxFractionDigits = 3;
         this.minFractionDigits = 0;
      }

      /// <summary>
      /// Returns an initialized instance of the TextNumberFormat object
      /// using number representation.
      /// </summary>
      /// <returns>The object instance</returns>
      public static TextNumberFormat getTextNumberInstance()
      {
         TextNumberFormat instance = new TextNumberFormat(TextNumberFormat.formatTypes.Number, 3);
         return instance;
      }

      /// <summary>
      /// Returns an initialized instance of the TextNumberFormat object
      /// using currency representation.
      /// </summary>
      /// <returns>The object instance</returns>
      public static TextNumberFormat getTextNumberCurrencyInstance()
      {
         TextNumberFormat instance = new TextNumberFormat(TextNumberFormat.formatTypes.Currency, 3);
         return instance.setToCurrencyNumberFormatDefaults(instance);
      }

      /// <summary>
      /// Returns an initialized instance of the TextNumberFormat object
      /// using percent representation.
      /// </summary>
      /// <returns>The object instance</returns>
      public static TextNumberFormat getTextNumberPercentInstance()
      {
         TextNumberFormat instance = new TextNumberFormat(TextNumberFormat.formatTypes.Percent, 3);
         return instance.setToPercentNumberFormatDefaults(instance);
      }

      /// <summary>
      /// Returns an initialized instance of the TextNumberFormat object
      /// using number representation, it uses the culture format information provided.
      /// </summary>
      /// <param name="culture">Represents information about a specific culture</param>
      /// <returns>The object instance</returns>
      public static TextNumberFormat getTextNumberInstance(System.Globalization.CultureInfo culture)
      {
         TextNumberFormat instance = new TextNumberFormat(TextNumberFormat.formatTypes.Number, culture, 3);
         return instance;
      }

      /// <summary>
      /// Returns an initialized instance of the TextNumberFormat object
      /// using currency representation, it uses the culture format information provided.
      /// </summary>
      /// <param name="culture">Represents information about a specific culture</param>
      /// <returns>The object instance</returns>
      public static TextNumberFormat getTextNumberCurrencyInstance(System.Globalization.CultureInfo culture)
      {
         TextNumberFormat instance = new TextNumberFormat(TextNumberFormat.formatTypes.Currency, culture, 3);
         return instance.setToCurrencyNumberFormatDefaults(instance);
      }

      /// <summary>
      /// Returns an initialized instance of the TextNumberFormat object
      /// using percent representation, it uses the culture format information provided.
      /// </summary>
      /// <param name="culture">Represents information about a specific culture</param>
      /// <returns>The object instance</returns>
      public static TextNumberFormat getTextNumberPercentInstance(System.Globalization.CultureInfo culture)
      {
         TextNumberFormat instance = new TextNumberFormat(TextNumberFormat.formatTypes.Percent, culture, 3);
         return instance.setToPercentNumberFormatDefaults(instance);
      }

      /// <summary>
      /// Clones the object instance
      /// </summary>
      /// <returns>The cloned object instance</returns>
      public System.Object Clone()
      {
         return (System.Object)this;
      }

      /// <summary>
      /// Determines if the received object is equal to the
      /// current object instance
      /// </summary>
      /// <param name="textNumberObject">TextNumber instance to compare</param>
      /// <returns>True or false depending if the two instances are equal</returns>
      public override bool Equals(Object obj)
      {
         // Check for null values and compare run-time types.
         if (obj == null || GetType() != obj.GetType())
            return false;
         SupportClass.TextNumberFormat param = (SupportClass.TextNumberFormat)obj;
         return (numberFormat == param.numberFormat) && (numberFormatType == param.numberFormatType)
            && (groupingActivated == param.groupingActivated) && (separator == param.separator)
            && (maxIntDigits == param.maxIntDigits) && (minIntDigits == param.minIntDigits)
            && (maxFractionDigits == param.maxFractionDigits) && (minFractionDigits == param.minFractionDigits);
      }


      /// <summary>
      /// Serves as a hash function for a particular type, suitable for use in hashing algorithms and data structures like a hash table.
      /// </summary>
      /// <returns>A hash code for the current Object</returns>
      public override int GetHashCode()
      {
         return numberFormat.GetHashCode() ^ numberFormatType ^ groupingActivated.GetHashCode()
             ^ separator.GetHashCode() ^ maxIntDigits ^ minIntDigits ^ maxFractionDigits ^ minFractionDigits;
      }

      /// <summary>
      /// Formats a number with the current formatting parameters
      /// </summary>
      /// <param name="number">Source number to format</param>
      /// <returns>The formatted number string</returns>
      public System.String FormatDouble(double number)
      {
         if (this.groupingActivated)
         {
            return SetIntDigits(number.ToString(this.GetCurrentFormatString() + this.GetNumberOfDigits(number), this.numberFormat));
         }
         else
         {
            return SetIntDigits((number.ToString(this.GetCurrentFormatString() + this.GetNumberOfDigits(number), this.numberFormat)).Replace(this.separator, ""));
         }
      }

      /// <summary>
      /// Formats a number with the current formatting parameters
      /// </summary>
      /// <param name="number">Source number to format</param>
      /// <returns>The formatted number string</returns>
      public System.String FormatLong(long number)
      {
         if (this.groupingActivated)
         {
            return SetIntDigits(number.ToString(this.GetCurrentFormatString() + this.minFractionDigits, this.numberFormat));
         }
         else
         {
            return SetIntDigits((number.ToString(this.GetCurrentFormatString() + this.minFractionDigits, this.numberFormat)).Replace(this.separator, ""));
         }
      }


      /// <summary>
      /// Formats the number according to the specified number of integer digits 
      /// </summary>
      /// <param name="number">The number to format</param>
      /// <returns></returns>
      private System.String SetIntDigits(String number)
      {
         String decimals = "";
         String fraction = "";
         int i = number.IndexOf(this.numberFormat.NumberDecimalSeparator);
         if (i > 0)
         {
            fraction = number.Substring(i);
            decimals = number.Substring(0, i).Replace(this.numberFormat.NumberGroupSeparator, "");
         }
         else decimals = number.Replace(this.numberFormat.NumberGroupSeparator, "");
         decimals = decimals.PadLeft(this.MinIntDigits, '0');
         if ((i = decimals.Length - this.MaxIntDigits) > 0) decimals = decimals.Remove(0, i);
         if (this.groupingActivated)
         {
            for (i = decimals.Length; i > 3; i -= 3)
            {
               decimals = decimals.Insert(i - 3, this.numberFormat.NumberGroupSeparator);
            }
         }
         decimals = decimals + fraction;
         if (decimals.Length == 0) return "0";
         else return decimals;
      }

      /// <summary>
      /// Gets the list of all supported cultures
      /// </summary>
      /// <returns>An array of type CultureInfo that represents the supported cultures</returns>
      public static System.Globalization.CultureInfo[] GetAvailableCultures()
      {
         return System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.AllCultures);
      }

      /// <summary>
      /// Obtains the current format representation used
      /// </summary>
      /// <returns>A character representing the string format used</returns>
      private System.String GetCurrentFormatString()
      {
         System.String currentFormatString = "n";  //Default value
         switch (this.numberFormatType)
         {
            case (int)TextNumberFormat.formatTypes.Currency:
               currentFormatString = "c";
               break;

            case (int)TextNumberFormat.formatTypes.General:
               currentFormatString = "n";
               break;

            case (int)TextNumberFormat.formatTypes.Number:
               currentFormatString = "n";
               break;

            case (int)TextNumberFormat.formatTypes.Percent:
               currentFormatString = "p";
               break;
         }
         return currentFormatString;
      }

      /// <summary>
      /// Retrieves the separator used, depending on the format type specified
      /// </summary>
      /// <param name="numberFormatType">formatType enumarator value to inquire</param>
      /// <returns>The values of character separator used </returns>
      private System.String GetSeparator(int numberFormatType)
      {
         System.String separatorItem = " ";  //Default Separator

         switch (numberFormatType)
         {
            case (int)TextNumberFormat.formatTypes.Currency:
               separatorItem = this.numberFormat.CurrencyGroupSeparator;
               break;

            case (int)TextNumberFormat.formatTypes.General:
               separatorItem = this.numberFormat.NumberGroupSeparator;
               break;

            case (int)TextNumberFormat.formatTypes.Number:
               separatorItem = this.numberFormat.NumberGroupSeparator;
               break;

            case (int)TextNumberFormat.formatTypes.Percent:
               separatorItem = this.numberFormat.PercentGroupSeparator;
               break;
         }
         return separatorItem;
      }

      /// <summary>
      /// Boolean value stating if grouping is used or not
      /// </summary>
      public bool GroupingUsed
      {
         get
         {
            return (this.groupingActivated);
         }
         set
         {
            this.groupingActivated = value;
         }
      }

      /// <summary>
      /// Minimum number of integer digits to use in the number format
      /// </summary>
      public int MinIntDigits
      {
         get
         {
            return this.minIntDigits;
         }
         set
         {
            this.minIntDigits = value;
         }
      }

      /// <summary>
      /// Maximum number of integer digits to use in the number format
      /// </summary>
      public int MaxIntDigits
      {
         get
         {
            return this.maxIntDigits;
         }
         set
         {
            this.maxIntDigits = value;
         }
      }

      /// <summary>
      /// Minimum number of fraction digits to use in the number format
      /// </summary>
      public int MinFractionDigits
      {
         get
         {
            return this.minFractionDigits;
         }
         set
         {
            this.minFractionDigits = value;
         }
      }

      /// <summary>
      /// Maximum number of fraction digits to use in the number format
      /// </summary>
      public int MaxFractionDigits
      {
         get
         {
            return this.maxFractionDigits;
         }
         set
         {
            this.maxFractionDigits = value;
         }
      }

      /// <summary>
      /// Sets the values of minFractionDigits and maxFractionDigits to the currency standard
      /// </summary>
      /// <param name="format">The TextNumberFormat instance to set</param>
      /// <returns>The TextNumberFormat with corresponding the default values</returns>
      private TextNumberFormat setToCurrencyNumberFormatDefaults(TextNumberFormat format)
      {
         format.maxFractionDigits = 2;
         format.minFractionDigits = 2;
         return format;
      }

      /// <summary>
      /// Sets the values of minFractionDigits and maxFractionDigits to the percent standard
      /// </summary>
      /// <param name="format">The TextNumberFormat instance to set</param>
      /// <returns>The TextNumberFormat with corresponding the default values</returns>
      private TextNumberFormat setToPercentNumberFormatDefaults(TextNumberFormat format)
      {
         format.maxFractionDigits = 0;
         format.minFractionDigits = 0;
         return format;
      }

      /// <summary>
      /// Gets the number of fraction digits thats must be used by the format methods
      /// </summary>
      /// <param name="number">The double number</param>
      /// <returns>The number of fraction digits to use</returns>
      private int GetNumberOfDigits(Double number)
      {
         int counter = 0;
         double temp = System.Math.Abs(number);
         while ((temp % 1) > 0)
         {
            temp *= 10;
            counter++;
         }
         return (counter < this.minFractionDigits) ? this.minFractionDigits : ((counter < this.maxFractionDigits) ? counter : this.maxFractionDigits);
      }
   }
   /*******************************/
   /// <summary>
   /// Summary description for EqualsSupport.
   /// </summary>
   public class EqualsSupport
   {
      /// <summary>
      /// Determines whether two Collections instances are equal.
      /// </summary>
      /// <param name="source">The first Collections to compare. </param>
      /// <param name="target">The second Collections to compare. </param>
      /// <returns>Return true if the first collection is the same instance as the second collection, otherwise returns false.</returns>
      public static bool Equals(System.Collections.ICollection source, System.Collections.ICollection target)
      {
         bool equal = true;

         System.Collections.ArrayList sourceInterfaces = new System.Collections.ArrayList(source.GetType().GetInterfaces());
         System.Collections.ArrayList targetInterfaces = new System.Collections.ArrayList(target.GetType().GetInterfaces());

         if (sourceInterfaces.Contains(System.Type.GetType("SupportClass+SetSupport")) &&
            !targetInterfaces.Contains(System.Type.GetType("SupportClass+SetSupport")))
            equal = false;
         else if (targetInterfaces.Contains(System.Type.GetType("SupportClass+SetSupport")) &&
            !sourceInterfaces.Contains(System.Type.GetType("SupportClass+SetSupport")))
            equal = false;

         if (equal)
         {
            System.Collections.IEnumerator sourceEnumerator = ReverseStack(source);
            System.Collections.IEnumerator targetEnumerator = ReverseStack(target);

            if (source.Count != target.Count)
               equal = false;

            while (sourceEnumerator.MoveNext() && targetEnumerator.MoveNext())
               if (!sourceEnumerator.Current.Equals(targetEnumerator.Current))
                  equal = false;
         }

         return equal;
      }

      /// <summary>
      /// Determines if a Collection is equal to the Object.
      /// </summary>
      /// <param name="source">The first Collections to compare.</param>
      /// <param name="target">The Object to compare.</param>
      /// <returns>Return true if the first collection contains the same values of the second Object, otherwise returns false.</returns>
      public static bool Equals(System.Collections.ICollection source, System.Object target)
      {
         return (target is System.Collections.ICollection) ? Equals(source, (System.Collections.ICollection)target) : false;
      }

      /// <summary>
      /// Determines if a IDictionaryEnumerator is equal to the Object.
      /// </summary>
      /// <param name="source">The first IDictionaryEnumerator to compare.</param>
      /// <param name="target">The second Object to compare.</param>
      /// <returns>Return true if the first IDictionaryEnumerator contains the same values of the second Object, otherwise returns false.</returns>
      public static bool Equals(System.Collections.IDictionaryEnumerator source, System.Object target)
      {
         return (target is System.Collections.IDictionaryEnumerator) ? Equals(source, (System.Collections.IDictionaryEnumerator)target) : false;
      }

      /// <summary>
      /// Determines if a IDictionary is equal to the Object.
      /// </summary>
      /// <param name="source">The first IDictionary to compare.</param>
      /// <param name="target">The second Object to compare.</param>
      /// <returns>Return true if the first IDictionary contains the same values of the second Object, otherwise returns false.</returns>
      public static bool Equals(System.Collections.IDictionary source, System.Object target)
      {
         return (target is System.Collections.IDictionary) ? Equals(source, (System.Collections.IDictionary)target) : false;
      }

      /// <summary>
      /// Determines whether two IDictionaryEnumerator instances are equals.
      /// </summary>
      /// <param name="source">The first IDictionaryEnumerator to compare.</param>
      /// <param name="target">The second IDictionaryEnumerator to compare.</param>
      /// <returns>Return true if the first IDictionaryEnumerator contains the same values as the second IDictionaryEnumerator, otherwise return false.</returns>
      public static bool Equals(System.Collections.IDictionaryEnumerator source, System.Collections.IDictionaryEnumerator target)
      {
         while (source.MoveNext() && target.MoveNext())
            if (source.Key.Equals(target.Key))
               if (source.Value.Equals(target.Value))
                  return true;
         return false;
      }

      /// <summary>
      /// Reverses the Stack Collection received.
      /// </summary>
      /// <param name="collection">The collection to reverse.</param>
      /// <returns>The collection received in reverse order if it was a System.Collections.Stack type, otherwise it does 
      /// nothing to the collection.</returns>
      public static System.Collections.IEnumerator ReverseStack(System.Collections.ICollection collection)
      {
         if ((collection.GetType()) == (typeof(System.Collections.Stack)))
         {
            System.Collections.ArrayList collectionStack = new System.Collections.ArrayList(collection);
            collectionStack.Reverse();
            return collectionStack.GetEnumerator();
         }
         else
            return collection.GetEnumerator();
      }

      /// <summary>
      /// Determines whether two IDictionary instances are equal.
      /// </summary>
      /// <param name="source">The first Collection to compare.</param>
      /// <param name="target">The second Collection to compare.</param>
      /// <returns>Return true if the first collection is the same instance as the second collection, otherwise return false.</returns>
      public static bool Equals(System.Collections.IDictionary source, System.Collections.IDictionary target)
      {
         System.Collections.Hashtable targetAux = new System.Collections.Hashtable(target);

         if (source.Count == targetAux.Count)
         {
            System.Collections.IEnumerator sourceEnum = source.Keys.GetEnumerator();
            while (sourceEnum.MoveNext())
               if (targetAux.Contains(sourceEnum.Current))
                  targetAux.Remove(sourceEnum.Current);
               else
                  return false;
         }
         else
            return false;
         if (targetAux.Count == 0)
            return true;
         else
            return false;
      }
   }


   /*******************************/
   /// <summary>
   /// Converts an array of sbytes to an array of chars
   /// </summary>
   /// <param name="sByteArray">The array of sbytes to convert</param>
   /// <returns>The new array of chars</returns>
   public static char[] ToCharArray(sbyte[] sByteArray)
   {
      return System.Text.UTF8Encoding.UTF8.GetChars(ToByteArray(sByteArray));
   }

   /// <summary>
   /// Converts an array of bytes to an array of chars
   /// </summary>
   /// <param name="byteArray">The array of bytes to convert</param>
   /// <returns>The new array of chars</returns>
   public static char[] ToCharArray(byte[] byteArray)
   {
      return System.Text.UTF8Encoding.UTF8.GetChars(byteArray);
   }

   /*******************************/
   /// <summary>
   /// Write an array of bytes int the FileStream specified.
   /// </summary>
   /// <param name="FileStreamWrite">FileStream that must be updated.</param>
   /// <param name="Source">Array of bytes that must be written in the FileStream.</param>
   public static void WriteOutput(System.IO.FileStream FileStreamWrite, byte[] Source)
   {
      FileStreamWrite.Write(Source, 0, Source.Length);
   }


   /*******************************/
   /// <summary>
   /// Gets the logical drives on this computer.
   /// </summary>
   /// <returns>An array of FileInfo objects denoting the available logical drives.</returns>
   public static System.IO.FileInfo[] ListLogicalDrives()
   {
      System.String[] tempString = System.IO.Directory.GetLogicalDrives();
      System.IO.FileInfo[] returnValue = new System.IO.FileInfo[tempString.Length];
      for (int index = 0; index < tempString.Length; index++)
         returnValue[index] = new System.IO.FileInfo(tempString[index]);
      return returnValue;
   }


   /*******************************/
   /// <summary>
   /// This class manages different features for calendars.
   /// The different calendars are internally managed using a hashtable structure.
   /// </summary>
   public class CalendarManager
   {
      /// <summary>
      /// Field used to get or set the year.
      /// </summary>
      public const int YEAR = 1;

      /// <summary>
      /// Field used to get or set the month.
      /// </summary>
      public const int MONTH = 2;

      /// <summary>
      /// Field used to get or set the day of the month.
      /// </summary>
      public const int DATE = 5;

      /// <summary>
      /// Field used to get or set the hour of the morning or afternoon.
      /// </summary>
      public const int HOUR = 10;

      /// <summary>
      /// Field used to get or set the minute within the hour.
      /// </summary>
      public const int MINUTE = 12;

      /// <summary>
      /// Field used to get or set the second within the minute.
      /// </summary>
      public const int SECOND = 13;

      /// <summary>
      /// Field used to get or set the millisecond within the second.
      /// </summary>
      public const int MILLISECOND = 14;

      /// <summary>
      /// Field used to get or set the day of the year.
      /// </summary>
      public const int DAY_OF_YEAR = 4;

      /// <summary>
      /// Field used to get or set the day of the month.
      /// </summary>
      public const int DAY_OF_MONTH = 6;

      /// <summary>
      /// Field used to get or set the day of the week.
      /// </summary>
      public const int DAY_OF_WEEK = 7;

      /// <summary>
      /// Field used to get or set the hour of the day.
      /// </summary>
      public const int HOUR_OF_DAY = 11;

      /// <summary>
      /// Field used to get or set whether the HOUR is before or after noon.
      /// </summary>
      public const int AM_PM = 9;

      /// <summary>
      /// Field used to get or set the value of the AM_PM field which indicates the period of the day from midnight to just before noon.
      /// </summary>
      public const int AM = 0;

      /// <summary>
      /// Field used to get or set the value of the AM_PM field which indicates the period of the day from noon to just before midnight.
      /// </summary>
      public const int PM = 1;

      /// <summary>
      /// The hashtable that contains the calendars and its properties.
      /// </summary>
      static public CalendarHashTable manager = new CalendarHashTable();

      /// <summary>
      /// Internal class that inherits from HashTable to manage the different calendars.
      /// This structure will contain an instance of System.Globalization.Calendar that represents 
      /// a type of calendar and its properties (represented by an instance of CalendarProperties 
      /// class).
      /// </summary>
      public class CalendarHashTable : System.Collections.Hashtable
      {
         /// <summary>
         /// Gets the calendar current date and time.
         /// </summary>
         /// <param name="calendar">The calendar to get its current date and time.</param>
         /// <returns>A System.DateTime value that indicates the current date and time for the 
         /// calendar given.</returns>
         public System.DateTime GetDateTime(System.Globalization.Calendar calendar)
         {
            if (this[calendar] != null)
               return ((CalendarProperties)this[calendar]).dateTime;
            else
            {
               CalendarProperties tempProps = new CalendarProperties();
               tempProps.dateTime = System.DateTime.Now;
               this.Add(calendar, tempProps);
               return this.GetDateTime(calendar);
            }
         }

         /// <summary>
         /// Sets the specified System.DateTime value to the specified calendar.
         /// </summary>
         /// <param name="calendar">The calendar to set its date.</param>
         /// <param name="date">The System.DateTime value to set to the calendar.</param>
         public void SetDateTime(System.Globalization.Calendar calendar, System.DateTime date)
         {
            if (this[calendar] != null)
            {
               ((CalendarProperties)this[calendar]).dateTime = date;
            }
            else
            {
               CalendarProperties tempProps = new CalendarProperties();
               tempProps.dateTime = date;
               this.Add(calendar, tempProps);
            }
         }

         /// <summary>
         /// Sets the corresponding field in an specified calendar with the value given.
         /// If the specified calendar does not have exist in the hash table, it creates a 
         /// new instance of the calendar with the current date and time and then assings it 
         /// the new specified value.
         /// </summary>
         /// <param name="calendar">The calendar to set its date or time.</param>
         /// <param name="field">One of the fields that composes a date/time.</param>
         /// <param name="fieldValue">The value to be set.</param>
         public void Set(System.Globalization.Calendar calendar, int field, int fieldValue)
         {
            if (this[calendar] != null)
            {
               System.DateTime tempDate = ((CalendarProperties)this[calendar]).dateTime;
               switch (field)
               {
                  case CalendarManager.DATE:
                     tempDate = tempDate.AddDays(fieldValue - tempDate.Day);
                     break;
                  case CalendarManager.HOUR:
                     tempDate = tempDate.AddHours(fieldValue - tempDate.Hour);
                     break;
                  case CalendarManager.MILLISECOND:
                     tempDate = tempDate.AddMilliseconds(fieldValue - tempDate.Millisecond);
                     break;
                  case CalendarManager.MINUTE:
                     tempDate = tempDate.AddMinutes(fieldValue - tempDate.Minute);
                     break;
                  case CalendarManager.MONTH:
                     //Month value is 0-based. e.g., 0 for January
                     tempDate = tempDate.AddMonths((fieldValue + 1) - tempDate.Month);
                     break;
                  case CalendarManager.SECOND:
                     tempDate = tempDate.AddSeconds(fieldValue - tempDate.Second);
                     break;
                  case CalendarManager.YEAR:
                     tempDate = tempDate.AddYears(fieldValue - tempDate.Year);
                     break;
                  case CalendarManager.DAY_OF_MONTH:
                     tempDate = tempDate.AddDays(fieldValue - tempDate.Day);
                     break;
                  case CalendarManager.DAY_OF_WEEK:
                     tempDate = tempDate.AddDays((fieldValue - 1) - (int)tempDate.DayOfWeek);
                     break;
                  case CalendarManager.DAY_OF_YEAR:
                     tempDate = tempDate.AddDays(fieldValue - tempDate.DayOfYear);
                     break;
                  case CalendarManager.HOUR_OF_DAY:
                     tempDate = tempDate.AddHours(fieldValue - tempDate.Hour);
                     break;

                  default:
                     break;
               }
               ((CalendarProperties)this[calendar]).dateTime = tempDate;
            }
            else
            {
               CalendarProperties tempProps = new CalendarProperties();
               tempProps.dateTime = System.DateTime.Now;
               this.Add(calendar, tempProps);
               this.Set(calendar, field, fieldValue);
            }
         }

         /// <summary>
         /// Sets the corresponding date (day, month and year) to the calendar specified.
         /// If the calendar does not exist in the hash table, it creates a new instance and sets 
         /// its values.
         /// </summary>
         /// <param name="calendar">The calendar to set its date.</param>
         /// <param name="year">Integer value that represent the year.</param>
         /// <param name="month">Integer value that represent the month.</param>
         /// <param name="day">Integer value that represent the day.</param>
         public void Set(System.Globalization.Calendar calendar, int year, int month, int day)
         {
            if (this[calendar] != null)
            {
               this.Set(calendar, CalendarManager.YEAR, year);
               this.Set(calendar, CalendarManager.MONTH, month);
               this.Set(calendar, CalendarManager.DATE, day);
            }
            else
            {
               CalendarProperties tempProps = new CalendarProperties();
               tempProps.dateTime = System.DateTime.Now;
               this.Add(calendar, tempProps);
               this.Set(calendar, year, month, day);
            }
         }

         /// <summary>
         /// Sets the corresponding date (day, month and year) and hour (hour and minute) 
         /// to the calendar specified.
         /// If the calendar does not exist in the hash table, it creates a new instance and sets 
         /// its values.
         /// </summary>
         /// <param name="calendar">The calendar to set its date and time.</param>
         /// <param name="year">Integer value that represent the year.</param>
         /// <param name="month">Integer value that represent the month.</param>
         /// <param name="day">Integer value that represent the day.</param>
         /// <param name="hour">Integer value that represent the hour.</param>
         /// <param name="minute">Integer value that represent the minutes.</param>
         public void Set(System.Globalization.Calendar calendar, int year, int month, int day, int hour, int minute)
         {
            if (this[calendar] != null)
            {
               this.Set(calendar, CalendarManager.YEAR, year);
               this.Set(calendar, CalendarManager.MONTH, month);
               this.Set(calendar, CalendarManager.DATE, day);
               this.Set(calendar, CalendarManager.HOUR, hour);
               this.Set(calendar, CalendarManager.MINUTE, minute);
            }
            else
            {
               CalendarProperties tempProps = new CalendarProperties();
               tempProps.dateTime = System.DateTime.Now;
               this.Add(calendar, tempProps);
               this.Set(calendar, year, month, day, hour, minute);
            }
         }

         /// <summary>
         /// Sets the corresponding date (day, month and year) and hour (hour, minute and second) 
         /// to the calendar specified.
         /// If the calendar does not exist in the hash table, it creates a new instance and sets 
         /// its values.
         /// </summary>
         /// <param name="calendar">The calendar to set its date and time.</param>
         /// <param name="year">Integer value that represent the year.</param>
         /// <param name="month">Integer value that represent the month.</param>
         /// <param name="day">Integer value that represent the day.</param>
         /// <param name="hour">Integer value that represent the hour.</param>
         /// <param name="minute">Integer value that represent the minutes.</param>
         /// <param name="second">Integer value that represent the seconds.</param>
         public void Set(System.Globalization.Calendar calendar, int year, int month, int day, int hour, int minute, int second)
         {
            if (this[calendar] != null)
            {
               this.Set(calendar, CalendarManager.YEAR, year);
               this.Set(calendar, CalendarManager.MONTH, month);
               this.Set(calendar, CalendarManager.DATE, day);
               this.Set(calendar, CalendarManager.HOUR, hour);
               this.Set(calendar, CalendarManager.MINUTE, minute);
               this.Set(calendar, CalendarManager.SECOND, second);
            }
            else
            {
               CalendarProperties tempProps = new CalendarProperties();
               tempProps.dateTime = System.DateTime.Now;
               this.Add(calendar, tempProps);
               this.Set(calendar, year, month, day, hour, minute, second);
            }
         }

         /// <summary>
         /// Gets the value represented by the field specified.
         /// </summary>
         /// <param name="calendar">The calendar to get its date or time.</param>
         /// <param name="field">One of the field that composes a date/time.</param>
         /// <returns>The integer value for the field given.</returns>
         public int Get(System.Globalization.Calendar calendar, int field)
         {
            if (this[calendar] != null)
            {
               int tempHour;
               switch (field)
               {
                  case CalendarManager.DATE:
                     return ((CalendarProperties)this[calendar]).dateTime.Day;
                  case CalendarManager.HOUR:
                     tempHour = ((CalendarProperties)this[calendar]).dateTime.Hour;
                     return tempHour > 12 ? tempHour - 12 : tempHour;
                  case CalendarManager.MILLISECOND:
                     return ((CalendarProperties)this[calendar]).dateTime.Millisecond;
                  case CalendarManager.MINUTE:
                     return ((CalendarProperties)this[calendar]).dateTime.Minute;
                  case CalendarManager.MONTH:
                     //Month value is 0-based. e.g., 0 for January
                     return ((CalendarProperties)this[calendar]).dateTime.Month - 1;
                  case CalendarManager.SECOND:
                     return ((CalendarProperties)this[calendar]).dateTime.Second;
                  case CalendarManager.YEAR:
                     return ((CalendarProperties)this[calendar]).dateTime.Year;
                  case CalendarManager.DAY_OF_MONTH:
                     return ((CalendarProperties)this[calendar]).dateTime.Day;
                  case CalendarManager.DAY_OF_YEAR:
                     return (int)(((CalendarProperties)this[calendar]).dateTime.DayOfYear);
                  case CalendarManager.DAY_OF_WEEK:
                     return (int)(((CalendarProperties)this[calendar]).dateTime.DayOfWeek) + 1;
                  case CalendarManager.HOUR_OF_DAY:
                     return ((CalendarProperties)this[calendar]).dateTime.Hour;
                  case CalendarManager.AM_PM:
                     tempHour = ((CalendarProperties)this[calendar]).dateTime.Hour;
                     return tempHour > 12 ? CalendarManager.PM : CalendarManager.AM;

                  default:
                     return 0;
               }
            }
            else
            {
               CalendarProperties tempProps = new CalendarProperties();
               tempProps.dateTime = System.DateTime.Now;
               this.Add(calendar, tempProps);
               return this.Get(calendar, field);
            }
         }

         /// <summary>
         /// Sets the time in the specified calendar with the long value.
         /// </summary>
         /// <param name="calendar">The calendar to set its date and time.</param>
         /// <param name="milliseconds">A long value that indicates the milliseconds to be set to 
         /// the hour for the calendar.</param>
         public void SetTimeInMilliseconds(System.Globalization.Calendar calendar, long milliseconds)
         {
            if (this[calendar] != null)
            {
               ((CalendarProperties)this[calendar]).dateTime = new System.DateTime(milliseconds);
            }
            else
            {
               CalendarProperties tempProps = new CalendarProperties();
               tempProps.dateTime = new System.DateTime(System.TimeSpan.TicksPerMillisecond * milliseconds);
               this.Add(calendar, tempProps);
            }
         }

         /// <summary>
         /// Gets what the first day of the week is; e.g., Sunday in US, Monday in France.
         /// </summary>
         /// <param name="calendar">The calendar to get its first day of the week.</param>
         /// <returns>A System.DayOfWeek value indicating the first day of the week.</returns>
         public System.DayOfWeek GetFirstDayOfWeek(System.Globalization.Calendar calendar)
         {
            if (this[calendar] != null)
            {
               if (((CalendarProperties)this[calendar]).dateTimeFormat == null)
               {
                  ((CalendarProperties)this[calendar]).dateTimeFormat = new System.Globalization.DateTimeFormatInfo();
                  ((CalendarProperties)this[calendar]).dateTimeFormat.FirstDayOfWeek = System.DayOfWeek.Sunday;
               }
               return ((CalendarProperties)this[calendar]).dateTimeFormat.FirstDayOfWeek;
            }
            else
            {
               CalendarProperties tempProps = new CalendarProperties();
               tempProps.dateTime = System.DateTime.Now;
               tempProps.dateTimeFormat = new System.Globalization.DateTimeFormatInfo();
               tempProps.dateTimeFormat.FirstDayOfWeek = System.DayOfWeek.Sunday;
               this.Add(calendar, tempProps);
               return this.GetFirstDayOfWeek(calendar);
            }
         }

         /// <summary>
         /// Sets what the first day of the week is; e.g., Sunday in US, Monday in France.
         /// </summary>
         /// <param name="calendar">The calendar to set its first day of the week.</param>
         /// <param name="firstDayOfWeek">A System.DayOfWeek value indicating the first day of the week
         /// to be set.</param>
         public void SetFirstDayOfWeek(System.Globalization.Calendar calendar, System.DayOfWeek firstDayOfWeek)
         {
            if (this[calendar] != null)
            {
               if (((CalendarProperties)this[calendar]).dateTimeFormat == null)
                  ((CalendarProperties)this[calendar]).dateTimeFormat = new System.Globalization.DateTimeFormatInfo();

               ((CalendarProperties)this[calendar]).dateTimeFormat.FirstDayOfWeek = firstDayOfWeek;
            }
            else
            {
               CalendarProperties tempProps = new CalendarProperties();
               tempProps.dateTime = System.DateTime.Now;
               tempProps.dateTimeFormat = new System.Globalization.DateTimeFormatInfo();
               this.Add(calendar, tempProps);
               this.SetFirstDayOfWeek(calendar, firstDayOfWeek);
            }
         }

         /// <summary>
         /// Removes the specified calendar from the hash table.
         /// </summary>
         /// <param name="calendar">The calendar to be removed.</param>
         public void Clear(System.Globalization.Calendar calendar)
         {
            if (this[calendar] != null)
               this.Remove(calendar);
         }

         /// <summary>
         /// Removes the specified field from the calendar given.
         /// If the field does not exists in the calendar, the calendar is removed from the table.
         /// </summary>
         /// <param name="calendar">The calendar to remove the value from.</param>
         /// <param name="field">The field to be removed from the calendar.</param>
         public void Clear(System.Globalization.Calendar calendar, int field)
         {
            if (this[calendar] != null)
               this.Set(calendar, field, 0);
         }

         /// <summary>
         /// Internal class that represents the properties of a calendar instance.
         /// </summary>
         class CalendarProperties
         {
            /// <summary>
            /// The date and time of a calendar.
            /// </summary>
            public System.DateTime dateTime;

            /// <summary>
            /// The format for the date and time in a calendar.
            /// </summary>
            public System.Globalization.DateTimeFormatInfo dateTimeFormat;
         }
      }
   }
   /*******************************/
   /// <summary>
   /// This class contains static methods to manage mail messages.
   /// </summary>
   /// <summary>
   public class MailMessageSupport
   {
      /// <summary>
      /// Parses the given header and adds it to the specified SortedList.
      /// </summary>
      /// <param name="headers">The sorted list where to add the new header</param>
      /// <param name="newHeader">The new header to be parsed and added to the sorted list</param>
      public static void AddHeader(System.Collections.SortedList headers, System.String newHeader)
      {
         System.String[] tempSplittedHeader = newHeader.Split(new char[] { ':' });
         if (tempSplittedHeader.Length > 1)
            headers.Add(tempSplittedHeader[0], tempSplittedHeader[1].TrimStart());
         else
            headers.Add(tempSplittedHeader[0], "");
      }

      /// <summary>
      /// Parses the given header and adds it to the specified list of headers of a MailMessage object.
      /// </summary>
      /// <param name="message">The mail message to add the headers.</param>
      /// <param name="newHeader">The new header to be parsed and added to message.</param>
      public static void AddHeader(System.Net.Mail.MailMessage message, System.String newHeader)
      {
         System.String[] tempSplittedHeader = newHeader.Split(new char[] { ':' });
         if (tempSplittedHeader.Length > 1)
            message.Headers.Add(tempSplittedHeader[0], tempSplittedHeader[1].TrimStart());
         else
            message.Headers.Add(tempSplittedHeader[0], "");
      }

      /// <summary>
      /// Adds the attachments information inside the arraylist to the message.
      /// </summary>
      /// <param name="message">The message which will receive the attachments.</param>
      /// <param name="attchs">An ArrayList containing the attachments.</param>
      /// 
      public static void AddAttachments(System.Net.Mail.MailMessage message, System.Net.Mail.AttachmentCollection attachments)
      {
         foreach(System.Net.Mail.Attachment attatchment in attachments)
            message.Attachments.Add(attatchment);
      }

      /// <summary>
      /// AppendAddresses retrieves the Mail Addresses stored in the UriBuilder array and appends 
      /// them into the property of the referenced MailMessage specified in the rType object.
      /// If the rType object is null, a new HttpException is thrown.
      /// </summary>
      /// <param name="message">the MailMessage object.</param>
      /// <param name="uriArray">the UriBuilder array.</param>
      /// <param name="rType">the type of the recipient.</param>
      //public static void AppendAddresses(System.Net.Mail.MailMessage message, System.UriBuilder[] uriArray, RecipientTypeSupport rType)
      //{
      //   if (rType != null)
      //   {
      //      if (uriArray != null)
      //      {
      //         for (int index = 0; index < uriArray.Length; index++)
      //         {
      //            if (rType.Equals(RecipientTypeSupport.From))
      //               message.From += ";" + uriArray[index].Uri.ToString().Substring(uriArray[index].Uri.ToString().IndexOf(":") + 1);
      //            else if (rType.Equals(RecipientTypeSupport.To))
      //               message.To += ";" + uriArray[index].Uri.ToString().Substring(uriArray[index].Uri.ToString().IndexOf(":") + 1);
      //            else if (rType.Equals(RecipientTypeSupport.Cc))
      //               message.CC += ";" + uriArray[index].Uri.ToString().Substring(uriArray[index].Uri.ToString().IndexOf(":") + 1);
      //            else
      //               message.Bcc += ";" + uriArray[index].Uri.ToString().Substring(uriArray[index].Uri.ToString().IndexOf(":") + 1);
      //         }
      //      }
      //   }
      //   else
      //      throw new System.Web.HttpException();
      //}

      /// <summary>
      /// AppendAddresses uses the Mail Addresses stored in the UriBuilder instance and appends 
      /// them into the property of the referenced MailMessage specified in the rType object.
      /// If the rType object is null, a new HttpException is thrown.
      /// </summary>
      /// <param name="message">the MailMessage object.</param>
      /// <param name="address">the UriBuilder address.</param>
      /// <param name="rType">the type of the recipient.</param>
      //public static void AppendAddresses(System.Net.Mail.MailMessage message, System.UriBuilder address, RecipientTypeSupport rType)
      //{
      //   if (rType != null)
      //   {
      //      if (address != null)
      //      {
      //         if (rType.Equals(RecipientTypeSupport.To))
      //            message.To += ";" + address.Uri.ToString().Substring(address.Uri.ToString().IndexOf(":") + 1);
      //         else if (rType.Equals(RecipientTypeSupport.Cc))
      //            message.Cc += ";" + address.Uri.ToString().Substring(address.Uri.ToString().IndexOf(":") + 1);
      //         else
      //            message.Bcc += ";" + address.Uri.ToString().Substring(address.Uri.ToString().IndexOf(":") + 1);
      //      }
      //   }
      //   else
      //      throw new System.Web.HttpException();
      //}

      /// <summary>
      /// AppendAddresses uses the Mail Addresses stored in a string and appends them 
      /// into the property of the referenced MailMessage specified in the rType object.
      /// If the rType object is null, a new HttpException is thrown
      /// </summary>
      /// <param name="message">the MailMessage object.</param>
      /// <param name="address">the string with the addresses.</param>
      /// <param name="rType">the type of the recipient.</param>
      //public static void AppendAddresses(System.Net.Mail.MailMessage message, System.String address, RecipientTypeSupport rType)
      //{
      //   if (rType != null)
      //      MailMessageSupport.AppendAddresses(message, MailMessageSupport.ParseAddress(address), rType);
      //   else
      //      throw new System.Web.HttpException();
      //}

      /// <summary>
      /// DefineReceivers retrieves the Mail Addresses stored in the UriBuilder array and appends 
      /// them into the property of the referenced MailMessage specified in the rType object.
      /// If the UriBuilder array is null, then the corresponding Recipient is cleared.
      /// If the rType object is null, then a new HttpException is thrown.
      /// </summary>
      /// <param name="message">The MailMessage referenced object.</param>
      /// <param name="uriArray">The UriBuilder array.</param>
      /// <param name="rType">the type of the recipient.</param>
      //public static void DefineReceivers(System.Net.Mail.MailMessage message, System.UriBuilder[] uriArray, RecipientTypeSupport rType)
      //{
      //   if (rType != null)
      //   {
      //      if (rType.Equals(RecipientTypeSupport.To))
      //         message.To = null;
      //      else if (rType.Equals(RecipientTypeSupport.Cc))
      //         message.Cc = null;
      //      else
      //         message.Bcc = null;

      //      if (uriArray != null)
      //      {
      //         for (int index = 0; index < uriArray.Length; index++)
      //         {
      //            if (rType.Equals(RecipientTypeSupport.To))
      //               message.To += uriArray[index].Uri.ToString().Substring(uriArray[index].Uri.ToString().IndexOf(":") + 1) + ";";
      //            else if (rType.Equals(RecipientTypeSupport.Cc))
      //               message.Cc += uriArray[index].Uri.ToString().Substring(uriArray[index].Uri.ToString().IndexOf(":") + 1) + ";";
      //            else
      //               message.Bcc += uriArray[index].Uri.ToString().Substring(uriArray[index].Uri.ToString().IndexOf(":") + 1) + ";";
      //         }
      //      }
      //   }
      //   else
      //      throw new System.Web.HttpException();
      //}

      /// <summary>
      /// DefineReceivers retrieves the Mail Addresses stored in the UriBuilder instance and appends them 
      /// into the property of the referenced MailMessage specified in the rType object.
      /// If the UriBuilder object is null, then the corresponding recipient is cleared.
      /// If the rType object is null, a new HttpException is thrown.
      /// </summary>
      /// <param name="message">the MailMessage object.</param>
      /// <param name="address">the UriBuilder instance.</param>
      /// <param name="rType">the recipient type.</param>
      //public static void DefineReceivers(System.Net.Mail.MailMessage message, System.UriBuilder address, RecipientTypeSupport rType)
      //{
      //   if (rType != null)
      //   {
      //      if (rType.Equals(RecipientTypeSupport.To))
      //         message.To = null;
      //      else if (rType.Equals(RecipientTypeSupport.Cc))
      //         message.Cc = null;
      //      else
      //         message.Bcc = null;

      //      if (address != null)
      //      {
      //         if (rType.Equals(RecipientTypeSupport.To))
      //            message.To += address.Uri.ToString().Substring(address.Uri.ToString().IndexOf(":") + 1) + ";";
      //         else if (rType.Equals(RecipientTypeSupport.Cc))
      //            message.Cc += address.Uri.ToString().Substring(address.Uri.ToString().IndexOf(":") + 1) + ";";
      //         else
      //            message.Bcc += address.Uri.ToString().Substring(address.Uri.ToString().IndexOf(":") + 1) + ";";
      //      }
      //   }
      //   else
      //      throw new System.Web.HttpException();
      //}

      /// <summary>
      /// DefineReceivers retrieves the Mail Addresses stored in the String instance and appends them into the
      /// property of the referenced MailMessage specified in the rType object.
      /// If the rType object is null, a new HttpException is thrown.
      /// </summary>
      /// <param name="message">the mailmessage object</param>
      /// <param name="address">string to retrieve the addresses from</param>
      /// <param name="rType">type of recipient</param>
      //public static void DefineReceivers(System.Net.Mail.MailMessage message, System.String address, RecipientTypeSupport rType)
      //{
      //   if (rType != null)
      //      MailMessageSupport.DefineReceivers(message, MailMessageSupport.ParseAddress(address), rType);
      //   else
      //      throw new System.Web.HttpException();
      //}

      /// <summary>
      /// DeliverMsgTo takes the current MailMessage object and sends it to the specified UriBuilder array, ignoring any 
      /// previous recipient specified within the message.
      /// </summary>
      /// <param name="message">Current MailMessage object.</param>
      /// <param name="addresses">Array of recipients.</param>
      //public static void DeliverMsgTo(System.Net.Mail.MailMessage message, System.UriBuilder[] addresses)
      //{
      //   message.Bcc = message.Cc = message.To = "";
      //   for (int index = 0; index < addresses.Length; index++)
      //      message.To += addresses[index].Uri.ToString().Substring(addresses[index].Uri.ToString().IndexOf(":") + 1) + ";";
      //   System.Net.Mail.SmtpMail.Send(message);
      //}

      /// <summary>
      /// Parses a string containing the address separated by comma, and return a System.UriBuilder array
      /// with the addresses.
      /// </summary>
      /// <param name="address">The String with the addresses.</param>
      /// <returns>An array of System.UirBuilder containing the addresses.</returns>
      public static System.UriBuilder[] ParseAddress(System.String address)
      {
         address = address.TrimEnd(',');
         address = address.TrimStart(',');
         System.String[] addresses = address.Split(',');
         System.Collections.ArrayList addresslist = new System.Collections.ArrayList();
         int count = 0;
         while (count < addresses.Length)
         {
            if (!(addresses[count].Equals("") || addresses[count].Trim().Equals("")))
               addresslist.Add(addresses[count].Trim());
            count++;
         }
         System.UriBuilder[] UriAddresses = new System.UriBuilder[addresslist.Count];
         for (int index = 0; index < addresslist.Count; index++)
            UriAddresses[index] = new System.UriBuilder("mailto:" + addresslist[index]);
         return UriAddresses;
      }

      /// <summary>
      /// Parses a string containing the address separated by comma, and return a System.UriBuilder array
      /// with the addresses.
      /// </summary>
      /// <param name="address">The String with the addresses.</param>
      /// <returns>An array of System.UirBuilder containing the addresses.</returns>
      public static System.UriBuilder[] ParseFromAddress(System.String address)
      {
         if ((address == "") || (address == null)) return null;
         address = address.TrimEnd(';');
         address = address.TrimStart(';');
         System.String[] addresses = address.Split(';');
         System.Collections.ArrayList addresslist = new System.Collections.ArrayList();
         int count = 0;
         while (count < addresses.Length)
         {
            if (!(addresses[count].Equals("") || addresses[count].Trim().Equals("")))
               addresslist.Add(addresses[count].Trim());
            count++;
         }
         System.UriBuilder[] UriAddresses = new System.UriBuilder[addresslist.Count];
         for (int index = 0; index < addresslist.Count; index++)
            UriAddresses[index] = new System.UriBuilder("mailto:" + addresslist[index]);
         return UriAddresses;
      }


      /// <summary>
      /// Constructs a String with the addresses inside the System.UriBuilder array.
      /// </summary>
      /// <param name="adresses">System.UriBuilder array with the address inside of it.</param>
      /// <returns>A string with the addresses separated by comma.</returns>
      public static System.String AddressesToString(System.UriBuilder[] addresses)
      {
         if (addresses != null)
         {
            System.String saddresses = System.String.Empty;
            for (int index = 0; index < addresses.Length; index++)
               saddresses += (addresses[index].UserName.TrimEnd(',').TrimStart(',').Trim()
                  + "@"
                  + addresses[index].Host.TrimEnd(',').TrimStart(',').Trim())
                  + ",";
            return saddresses.TrimEnd(',');
         }
         else
            return null;
      }

      /// <summary>
      /// SetAddresses retrieves the Mail Address stored in the UriBuilder object and 
      /// sets it into the From property of the referenced MailMessage.
      /// If the UriBuilder object is null, then the From field is cleared.
      /// </summary>
      /// <param name="message">The MailMessage referenced object.</param>
      /// <param name="theAddress">The UriBuilder Object.</param>
      //public static void SetAddress(System.Net.Mail.MailMessage message, System.UriBuilder theAddress)
      //{
      //   message.From = (theAddress != null) ? theAddress.Uri.ToString().Substring(theAddress.Uri.ToString().IndexOf(":") + 1) : null;
      //}

      /// <summary>
      /// Parses a string containing the address separeted by semicolon, and returns a System.UriBuilder array
      /// with the addresses.
      /// </summary>
      /// <param name="address">The String with the addresses.</param>
      /// <returns>An array of System.UirBuilder containing the addresses.</returns>
      public static System.UriBuilder[] ParseMail(System.String address)
      {
         address = address.TrimEnd(';');
         address = address.TrimStart(';');
         System.String[] addresses = address.Split(';');
         System.Collections.ArrayList addresslist = new System.Collections.ArrayList();
         int count = 0;
         while (count < addresses.Length)
         {
            if (!(addresses[count].Equals("") || addresses[count].Trim().Equals("")))
               addresslist.Add(addresses[count].Trim());
            count++;
         }
         System.UriBuilder[] UriAddresses = new System.UriBuilder[addresslist.Count];
         for (int index = 0; index < addresslist.Count; index++)
            UriAddresses[index] = new System.UriBuilder("mailto:" + addresslist[index]);
         return UriAddresses;
      }


      /// <summary>
      /// RetrieveReceivers retrieves the Mail Addresses stored in the UriBuilder instance and 
      /// appends them into the property of the referenced MailMessage specified in the "type" string.
      /// If the rType object is null, a new HttpException is thrown.
      /// </summary>
      /// <param name="message">The MailMessage referenced object.</param>
      /// <param name="rType">The type of the address to add.</param>
      /// <returns>An array of System.UirBuilder containing the addresses.</returns>
      //public static System.UriBuilder[] RetrieveReceivers(System.Net.Mail.MailMessage message, RecipientTypeSupport rType)
      //{
      //   if (rType != null)
      //   {
      //      if (rType.Equals(RecipientTypeSupport.To))
      //         return (message.To == null) ? null : ParseMail(message.To);
      //      else if (rType.Equals(RecipientTypeSupport.Cc))
      //         return (message.Cc == null) ? null : ParseMail(message.Cc);
      //      else
      //         return (message.Bcc == null) ? null : ParseMail(message.Bcc);
      //   }
      //   else
      //      throw new System.Web.HttpException();
      //}


      /// <summary>
      /// Copy the properties of a Message.
      /// </summary>
      /// <param name="messageSource">The message source</param>
      //public static System.Net.Mail.MailMessage Clone(System.Net.Mail.MailMessage messageSource)
      //{
      //   System.Net.Mail.MailMessage tempMime = new System.Net.Mail.MailMessage();
      //   Clone(tempMime, messageSource);
      //   return tempMime;
      //}

      /// <summary>
      /// Copy the properties of a Message.
      /// </summary>
      /// <param name="target">The message target</param>
      /// <param name="messageSource">The message source</param>
   //   public static void Clone(System.Net.Mail.MailMessage target, System.Net.Mail.MailMessage messageSource)
   //   {
   //      foreach (Object e in messageSource.Attachments)
   //         target.Attachments.Add(e);
   //      // Bcc
   //      target.Bcc = messageSource.Bcc;
   //      //Body 
   //      target.Body = messageSource.Body;
   //      //BodyEncoding
   //      target.BodyEncoding = messageSource.BodyEncoding;
   //      //BodyFormat
   //      target.BodyFormat = messageSource.BodyFormat;
   //      //Cc
   //      target.Cc = messageSource.Cc;
   //      //Fields
   //      foreach (System.Collections.DictionaryEntry e in messageSource.Fields)
   //         target.Fields.Add(e.Key, e.Value);
   //      //From
   //      target.From = messageSource.From;
   //      //Headers
   //      foreach (System.Collections.DictionaryEntry e in messageSource.Headers)
   //         target.Headers.Add(e.Key, e.Value);
   //      //Priority
   //      target.Priority = messageSource.Priority;
   //      //Subject
   //      target.Subject = messageSource.Subject;
   //      //To
   //      target.To = messageSource.To;
   //      //UrlContentBase
   //      target.UrlContentBase = messageSource.UrlContentBase;
   //      //UrlContentLocation
   //      target.UrlContentLocation = messageSource.UrlContentLocation;
   //   }
   }

   /*******************************/
   /// <summary>
   /// Defines the type of recipients used in the sending process of a mail message.
   /// </summary>
   public class RecipientTypeSupport
   {
      private System.String type;
      protected RecipientTypeSupport(System.String type)
      {
         this.type = type;
      }

      /// <summary>
      /// Defines the primary recipients in the sending process of a mail message.
      /// </summary>
      public static readonly RecipientTypeSupport To = new RecipientTypeSupport("To");

      /// <summary>
      /// Defines "carbon copy" recipients in the sending process of a mail message.
      /// </summary>
      public static readonly RecipientTypeSupport Cc = new RecipientTypeSupport("Cc");

      /// <summary>
      /// Defines "blind carbon copy" recipients in the sending process of a mail message.
      /// </summary>
      public static readonly RecipientTypeSupport Bcc = new RecipientTypeSupport("Bcc");

      /// <summary>
      /// Defines the sender in the sending process of a mail message.
      /// </summary>
      public static readonly RecipientTypeSupport From = new RecipientTypeSupport("From");
   }


   /*******************************/
   /// <summary>
   /// Checks if a file have write permissions
   /// </summary>
   /// <param name="file">The file instance to check</param>
   /// <returns>True if have write permissions otherwise false</returns>
   public static bool FileCanWrite(System.IO.FileInfo file)
   {
      return (System.IO.File.GetAttributes(file.FullName) & System.IO.FileAttributes.ReadOnly) != System.IO.FileAttributes.ReadOnly;
   }

   /*******************************/
   /// <summary>Reads a number of characters from the current source Stream and writes the data to the target array at the specified index.</summary>
   /// <param name="sourceStream">The source Stream to read from.</param>
   /// <param name="target">Contains the array of characteres read from the source Stream.</param>
   /// <param name="start">The starting index of the target array.</param>
   /// <param name="count">The maximum number of characters to read from the source Stream.</param>
   /// <returns>The number of characters read. The number will be less than or equal to count depending on the data available in the source Stream. Returns -1 if the end of the stream is reached.</returns>
   public static System.Int32 ReadInput(System.IO.Stream sourceStream, byte[] target, int start, int count)
   {
      // Returns 0 bytes if not enough space in target
      if (target.Length == 0)
         return 0;

      byte[] receiver = new byte[target.Length];
      int bytesRead = sourceStream.Read(receiver, start, count);

      // Returns -1 if EOF
      if (bytesRead == 0)
         return -1;

      for (int i = start; i < start + bytesRead; i++)
         target[i] = receiver[i];

      return bytesRead;
   }

   /// <summary>Reads a number of characters from the current source TextReader and writes the data to the target array at the specified index.</summary>
   /// <param name="sourceTextReader">The source TextReader to read from</param>
   /// <param name="target">Contains the array of characteres read from the source TextReader.</param>
   /// <param name="start">The starting index of the target array.</param>
   /// <param name="count">The maximum number of characters to read from the source TextReader.</param>
   /// <returns>The number of characters read. The number will be less than or equal to count depending on the data available in the source TextReader. Returns -1 if the end of the stream is reached.</returns>
   public static System.Int32 ReadInput(System.IO.TextReader sourceTextReader, byte[] target, int start, int count)
   {
      // Returns 0 bytes if not enough space in target
      if (target.Length == 0) return 0;

      char[] charArray = new char[target.Length];
      int bytesRead = sourceTextReader.Read(charArray, start, count);

      // Returns -1 if EOF
      if (bytesRead == 0) return -1;

      for (int index = start; index < start + bytesRead; index++)
         target[index] = (byte)charArray[index];

      return bytesRead;
   }

   /*******************************/
   //Provides access to a static System.Random class instance
   static public System.Random Random = new System.Random();


   /*******************************/
   /// <summary>
   /// Reverses string values.
   /// </summary>
   /// <param name="text">The StringBuilder object containing the string to be reversed.</param>
   /// <returns>The reversed string contained in a StringBuilder object.</returns>
   public static System.Text.StringBuilder ReverseString(System.Text.StringBuilder text)
   {
      char[] tmpChar = text.ToString().ToCharArray();
      System.Array.Reverse(tmpChar);
      return new System.Text.StringBuilder(new System.String(tmpChar));
   }


   [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit)]
   struct intLongFloatDoubleUnion
   {
      [System.Runtime.InteropServices.FieldOffset(0)]
      public int intValue;

      [System.Runtime.InteropServices.FieldOffset(0)]
      public float floatValue;

      [System.Runtime.InteropServices.FieldOffset(0)]
      public long longValue;

      [System.Runtime.InteropServices.FieldOffset(0)]
      public double doubleValue;
   }


   /// <summary>
   /// Returns a representation of the specified floating-point value 
   /// according to the IEEE 754 floating-point" single format" bit layout. 
   /// </summary>
   /// <param name="value">Floating-point number</param>
   /// <returns>Bits that represent the floating-point number</returns>
   public static int floatToIntBits(float value)
   {

      if (float.IsPositiveInfinity(value))
         return  0x7f800000;

      if (float.IsNegativeInfinity(value))
         return unchecked((int)0xff800000);

      if (float.IsNaN(value))
         return  0x7fc00000;

      // Bit 31 (the bit that is selected by the mask 0x80000000) represents the sign of the floating-point number. 
      // Bits 30-23 (the bits that are selected by the mask 0x7f800000) represent the exponent. 
      // Bits 22-0 (the bits that are selected by the mask 0x007fffff) represent the significand (sometimes called the mantissa) of the floating-point number. 
      intLongFloatDoubleUnion union = new intLongFloatDoubleUnion();
      union.floatValue = value;

      return union.intValue;
   }


   /// <summary>
   /// Returns a representation of the specified floating-point value 
   /// according to the IEEE 754 floating-point" double format" bit layout. 
   /// </summary>
   /// <param name="value">Floating-point number</param>
   /// <returns>Bits that represent the floating-point number</returns>
   public static long doubleToLongBits(double value)
   {

      if (double.IsPositiveInfinity(value))
         return 0x7ff0000000000000L;

      if (double.IsNegativeInfinity(value))
         return unchecked((long) 0xfff0000000000000L);

      if (double.IsNaN(value))
         return 0x7ff8000000000000L;

      // Bit 63 (the bit that is selected by the mask 0x8000000000000000L) represents the sign of the floating-point number. 
      // Bits 62-52 (the bits that are selected by the mask 0x7ff0000000000000L) represent the exponent. 
      // Bits 51-0 (the bits that are selected by the mask 0x000fffffffffffffL) represent the significand (sometimes called the mantissa) of the floating-point number. 
      intLongFloatDoubleUnion union = new intLongFloatDoubleUnion();
      union.doubleValue = value;
      return union.longValue;
   }


}
