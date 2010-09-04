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
 * Copyright (c) 2001 Heidelberger Druckmaschinen AG, All Rights Reserved.
 * VString.cs
 * Last changes
 */

namespace org.cip4.jdflib.core
{
   using System;
   using System.Collections;
   using System.Collections.Generic;


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;
   using EnumType = org.cip4.jdflib.node.JDFNode.EnumType;
   using StringUtil = org.cip4.jdflib.util.StringUtil;

   ///
   /// <summary> * </summary>
   /// 
   public partial class VString : List<String>
   {
      private const long serialVersionUID = 1L;
      public static readonly VString emptyVector = new VString();

      //**************************************** Constructors ****************************************
      ///    
      ///     <summary> * constructor </summary>
      ///     
      public VString()
         : base()
      {
      }

      ///    
      ///     <summary> * constructor
      ///     * </summary>
      ///     * <param name="m"> </param>
      ///     
      public VString(List<string> m)
         : base()
      {
         if (m != null)
            addAll(m.ToArray());
      }

      ///    
      ///     <summary> * constructs a VString by tokenizing a string </summary>
      ///     * <param name="strIn"> the string to tokenize by blank </param>
      ///     * @deprecated use VString (String strIn, null) 
      ///     
      [Obsolete("use VString (String strIn, null)")]
      public VString(string strIn)
         : this(strIn, null)
      {
      }

      ///    
      ///     <summary> * 
      ///     * constructs a VString by tokenizing a string </summary>
      ///     * <param name="strIn">  the string to tokenize </param>
      ///     * <param name="strSep"> the separator character </param>
      ///     
      public VString(string strIn, string strSep)
         : base()
      {
         this.Clear();

         string strSepLocal = strSep;

         if (strIn != null)
         {
            if (strSepLocal == null)
               strSepLocal = JDFConstants.BLANK;

            //StringTokenizer sToken = new StringTokenizer (strIn, strSepLocal);
            SupportClass.Tokenizer sToken = new SupportClass.Tokenizer(strIn, strSepLocal);

            while (sToken.HasMoreTokens())
            {
               this.Add(sToken.NextToken());
            }
         }
      }


      ///    
      ///     <summary> * creates a VString from an array of Strings </summary>
      ///     * <param name="a"> the array </param>
      ///     
      public VString(string[] a)
         : base(a.Length)
      {
         for (int i = 0; i < a.Length; i++)
            Add(a[i]);
      }


      // Java to C# Conversion - 
      public VString(ArrayList a)
         : base()
      {
         if (a != null)
         {
            for (int i = 0; i < a.Count; i++)
               Add(a[i].ToString());
         }
      }


      //**************************************** Methods *********************************************
      public virtual string stringAt(int index)
      {
         return base[index];
      }

      ///    
      ///     <summary> * toString
      ///     * </summary>
      ///     * <returns> String </returns>
      ///     
      public override string ToString()
      {
         return "vString[ --> " + base.ToString() + " ]";
      }

      ///    
      ///     <summary> * Method getAllStrings - returns all strings concatenated together </summary>
      ///     * <param name="strSep"> separation between the strings </param>
      ///     * <returns> String </returns>
      ///     * @deprecated use getString(strSep,null,null) 
      ///     
      [Obsolete("use getString(strSep,null,null)")]
      public virtual string getAllStrings(string strSep)
      {
         return StringUtil.setvString(this, strSep, null, null);
      }

      ///    
      ///     * <returns> all strings separated by a blank </returns>
      ///     * @deprecated use getString(JDFConstants.BLANK,null,null) 
      ///     
      [Obsolete("use getString(JDFConstants.BLANK,null,null)")]
      public virtual string getAllStrings()
      {
         return StringUtil.setvString(this, JDFConstants.BLANK, null, null);
      }

      ///    
      ///     <summary> * Method setAllStrings - put a separated string into the vString<br>
      ///     *                        e.g.  "asdf asdf asdf asdf" </summary>
      ///     * <param name="strIn">  separated string </param>
      ///     * <param name="strSep"> string separator </param>
      ///     
      public virtual void setAllStrings(string strIn, string strSep)
      {
         if ((strIn != null) && (strSep != null))
         {
            this.Clear();
            //StringTokenizer sToken = new StringTokenizer (strIn, strSep);
            SupportClass.Tokenizer sToken = new SupportClass.Tokenizer(strIn, strSep);

            while (sToken.HasMoreTokens())
            {
               this.Add(sToken.NextToken());
            }
         }
      }

      ///    
      ///     <summary> * index - get the index of s in the vector
      ///     * </summary>
      ///     * <param name="String"> s
      ///     * </param>
      ///     * <returns> int </returns>
      ///     
      public virtual int index(string s)
      {
         if (s == null)
            return -1;
         int size = Count;
         for (int i = 0; i < size; i++)
         {
            if (s.Equals(stringAt(i)))
            {
               return i;
            }
         }
         return -1;
      }

      ///    
      ///    <summary> * hasString - is 's' a member of <code>this</code>?
      ///    *  </summary>
      ///    * <param name="s"> string to find
      ///    *  </param>
      ///    * <returns> boolean - true, if 's' is included in <code>this</code> </returns>
      ///    * @deprecated 2005-02-14 use contains ... 
      ///    
      [Obsolete("2005-02-14 use contains ...")]
      public virtual bool hasString(string s)
      {
         return index(s) >= 0;
      }

      ///    
      ///     <summary> * AppendUnique - append a string but ignore multiple entries
      ///     * </summary>
      ///     * <param name="v"> the string to append </param>
      ///     
      public virtual void appendUnique(string v)
      {
         if (v == null)
            return;

         if (!Contains(v))
         {
            Add(v);
         }
      }

      ///    
      ///     <summary> * AppendUnique - append a vector but ignore multiple entries
      ///     * </summary>
      ///     * <param name="v"> the vector to append </param>
      ///     
      public virtual void appendUnique(VString v)
      {
         if (v == null)
            return;
         int size = v.Count;
         if (size == 1) // speedup for single append
         {
            string theOther = v[0];
            if (!this.Contains(theOther))
               Add(theOther);
            return;
         }
         for (int i = 0; i < size; i++)
            Add(v[i]);

         unify();
      }

      ///    
      ///     <summary> * removeStrings - remove all occurrences of a string
      ///     * </summary>
      ///     * <param name="v"> </param>
      ///     * @deprecated use removeStrings(v, Integer.MAX_VALUE); 
      ///     
      [Obsolete("use removeStrings(v, Integer.MAX_VALUE);")]
      public virtual void removeStrings(VString v)
      {
         removeStrings(v, int.MaxValue);
      }


      ///    
      ///     <summary> * removeStrings - remove all occurrences of a string
      ///     * </summary>
      ///     * <param name="v">    the vector of strings to remove from <code>this</code> </param>
      ///     * <param name="nMax"> the max number of strings to remove </param>
      ///     
      public virtual void removeStrings(VString v, int nMax)
      {
         int nMaxLocal = nMax;

         if (v == null)
            return;

         for (int i = this.Count - 1; i >= 0 && nMaxLocal > 0; i--)
         {
            if (v.Contains(this[i]))
            {
               this.RemoveAt(i);
               nMaxLocal--;
            }
         }
      }

      ///    
      ///     <summary> * removeStrings - remove all occurrences of a string
      ///     * </summary>
      ///     * <param name="String"> s </param>
      ///     * @deprecated use removeStrings(s, Integer.MAX_VALUE); 
      ///     
      [Obsolete("use removeStrings(s, Integer.MAX_VALUE);")]
      public virtual void removeStrings(string s)
      {
         removeStrings(s, int.MaxValue);
      }

      ///    
      ///     <summary> * removeStrings - remove nMax occurrences of a string
      ///     * </summary>
      ///     * <param name="s">    the string to remove </param>
      ///     * <param name="nMax"> remove s max. nMax times </param>
      ///     
      public virtual void removeStrings(string s, int nMax)
      {
         int nMaxLocal = nMax;

         for (int i = this.Count - 1; i >= 0 && nMaxLocal > 0; i--)
         {
            if (this.Contains(s))
            {
               this.RemoveAt(this.index(s));
               nMaxLocal--;
            }
         }
      }

      ///    
      ///    <summary> * serialize to a string </summary>
      ///    * <param name="sep">   separator between strings </param>
      ///    * <param name="front"> string before the first entry </param>
      ///    * <param name="back">  string after the last entry
      ///    *  </param>
      ///    * <returns> a tokenized string </returns>
      ///    * @deprecated use StringUtil setVString
      ///    * default: GetString(sep, JDFConstants.EMPTYSTRING, JDFConstants.EMPTYSTRING) 
      ///    
      [Obsolete("use StringUtil setVString")]
      public virtual string getString(string sep, string front, string back)
      {
         return StringUtil.setvString(this, sep, front, back);
      }

      ///    
      ///     <summary> * create a string from a vector of tokens </summary>
      ///     * <param name="v">     vector of tokens </param>
      ///     * <param name="sep">   separator between tokens </param>
      ///     * <param name="front"> prefix to string (before the first token) </param>
      ///     * <param name="end">   suffix to string (after the last token) </param>
      ///     * <returns> condensed string of tokens separated by sep </returns>
      ///     * @deprecated use getString 
      ///     
      [Obsolete("use getString")]
      public virtual string setvString(VString v, string sep, string front, string end)
      {
         string s = front == null ? JDFConstants.EMPTYSTRING : front;
         int siz = v.Count;
         for (int i = 0; i < siz; i++)
         {
            if (i != 0) //add seperator after every add
            {
               s += sep;
            }
            s += v[i];
         }
         if (end != null)
            s += end;
         return s;
      }

      ///    
      ///     <summary> * unify - make VString unique, retaining initial order </summary>
      ///     
      public virtual void unify()
      {
         SupportClass.HashSetSupport<string> @set = new SupportClass.HashSetSupport<string>();
         int size = Count;
         for (int i = 0; i < size; i++)
         {
            string s = this.stringAt(i);
            if (@set.Contains(s))
            {
               this.RemoveAt(i);
               i--;
               size--;
            }
            else
            {
               @set.Add(s);
            }
         }
      }

      ///    
      ///     <summary> * get a string from <code>this</code>  </summary>
      ///     * <param name="s"> the String you are looking for </param>
      ///     * <returns> the String if found or null if <code>this</code> does not contain s </returns>
      ///     
      public virtual string @get(string s)
      {
         if (Contains(s))
         {
            int i = IndexOf(s);
            return this[i];
         }

         return null;
      }

      ///     
      ///     <summary> * gets a set with all entries of the Vstring
      ///     * @return </summary>
      ///     
      public virtual SupportClass.SetSupport<string> getSet()
      {
         // Java to C# Conversion - QUESTION: Need to implement LinkedHashSet?
         SupportClass.HashSetSupport<string> @set = new SupportClass.HashSetSupport<string>(); // new LinkedHashSet<string>();
         IEnumerator<string> it = GetEnumerator();
         while (it.MoveNext())
            @set.Add(it.Current);

         return @set;
      }


      ///    
      ///     <summary> * appends all strings of an array to <code>this</code> </summary>
      ///     * <param name="strings"> the array of strings to append to <code>this</code> </param>
      ///     
      public virtual void addAll(string[] strings)
      {
         //ensureCapacity(size()+strings.Length);
         for (int i = 0; i < strings.Length; i++)
            Add(strings[i]);
      }


      /// <summary>
      /// Add all of the strings in the list to this object
      /// </summary>
      /// <param name="strings"></param>
      public virtual void addAll(VString strings)
      {
         //ensureCapacity(size()+strings.Length);
         for (int i = 0; i < strings.Count; i++)
            Add(strings[i]);
      }

      ///    
      ///     <summary> * checks whether at least one of a given vector of strings is contained 
      ///     * in <code>this</code>
      ///     *  </summary>
      ///     * <param name="other"> the VSTring of values to test </param>
      ///     * <returns> true if at least one String in other is in <code>this</code> </returns>
      ///     
      public virtual bool containsAny(VString other)
      {
         if (other == null)
            return false;
         int size = other.Count;
         for (int i = 0; i < size; i++)
         {
            if (Contains(other[i]))
               return true;
         }
         return false;
      }

      ///    
      ///     <summary> * appends enumType to <code>this</code><br>
      ///     * if enumType is a ValuedEnum, the name is appended
      ///     *  </summary>
      ///     * <param name="enumType"> the object to append </param>
      ///  
      public virtual void Add(EnumType enumType)
      {
         base.Add(((ValuedEnum)enumType).getName());
      }


      /// <summary>
      /// Check if list of strings is empty
      /// </summary>
      /// <returns>true if there are no strings in the list</returns>
      public virtual bool IsEmpty()
      {
         return (this.Count == 0);
      }

      /// <summary>
      /// Check if all the strings in the list are in this VString instance
      /// </summary>
      /// <param name="list">VString list of strings</param>
      /// <returns>true if all the strings in the list are in this VString instance</returns>
      public virtual bool ContainsAll(VString list)
      {
         if (list == null)
            return true;

         if (list.Count > this.Count)
            return false;

         foreach (string item in list)
         {
            if (!this.Contains(item))
               return false;
         }
         return true;
      }
   }
}
