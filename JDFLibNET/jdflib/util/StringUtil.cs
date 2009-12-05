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
 * StringUtil.cs
 * Last changes
 */

namespace org.cip4.jdflib.util
{
   using System;
   using System.Collections;
   using System.Collections.Generic;
   using System.Text;
   using System.Text.RegularExpressions;
   using System.IO;
   using System.Xml;


   using StringUtils = org.apache.commons.lang.StringUtils;
   using EnumUtils = org.apache.commons.lang.enums.EnumUtils;
   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;
   using PrintfFormat = org.cip4.jdflib.cformat.PrintfFormat;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using KElement = org.cip4.jdflib.core.KElement;
   using VString = org.cip4.jdflib.core.VString;
   using JDFBaseDataTypes_Fields = org.cip4.jdflib.datatypes.JDFBaseDataTypes_Fields;
   using JDFIntegerList = org.cip4.jdflib.datatypes.JDFIntegerList;
   using JDFIntegerRange = org.cip4.jdflib.datatypes.JDFIntegerRange;
   using JDFIntegerRangeList = org.cip4.jdflib.datatypes.JDFIntegerRangeList;
   using JDFNumberRange = org.cip4.jdflib.datatypes.JDFNumberRange;
   using JDFNumberRangeList = org.cip4.jdflib.datatypes.JDFNumberRangeList;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFXYPairRange = org.cip4.jdflib.datatypes.JDFXYPairRange;
   using JDFXYPairRangeList = org.cip4.jdflib.datatypes.JDFXYPairRangeList;


   ///
   /// <summary> * collection of static string utilities
   /// * @author prosirai
   /// * </summary>
   /// 
   public class StringUtil
   {
      // **************************************** Constants
      // *******************************************
      private const string m_sep = JDFConstants.BLANK;
      ///   
      ///	 * @deprecated use UrlUtil.m_URIEscape 
      ///	 
      [Obsolete("use UrlUtil.m_URIEscape")]
      public const string m_URIEscape = UrlUtil.m_URIEscape;

      private StringUtil()
      {
         // hide constructor to avoid accidental instantiation
      }

      // **************************************** Methods
      // ******************************************

      ///   
      ///	 <summary> * returns a random string really important routine - written on a friday afternoon ;-) please add more at your
      ///	 * leisure.... parts (c) Monty Python
      ///	 *  </summary>
      ///	 
      private static string[] strings = { "Randomly inserted error", "fooBar", "Snafu", "Bad Karma", "What do you expect from a simulator", "Paper Jam", "Strawberry jam", "Elderberry jam", "Your mother was a hamster and your father smelt of elderberries!", "I'm French! Why do think I have this outrageous accent, you silly king-a?!", "You don't frighten us, English pig-dogs!", "Go and boil your bottom, sons of a silly person.", "I blow my nose at you, so-called Arthur King, you and all your silly English k-nnnnniggets. Thpppppt! Thppt! Thppt!", "I don't wanna talk to you no more, you empty headed animal food trough wiper!", "I fart in your general direction!", "C'est un lapin, lapin de bois.", "Quoi? Un cadeau. What? A present. Oh, un cadeau. Oui, oui. Hurry. What? Let's go. Oh. On y va. Bon magne. Over here...", "Oh. Oh, I see. Running away, eh? You yellow bastards! Come back here and take what's coming to you. I'll bite your legs off!", "You're using coconuts!", "The swallow may fly south with the sun or the house martin or the plover may seek warmer climes in winter, yet these are not strangers to our land?", "Are you suggesting coconuts migrate?", "It's not a question of where he grips it! It's a simple question of weight ratios! A five ounce bird could not carry a one pound coconut.", "Listen. In order to maintain air-speed velocity, a swallow needs to beat its wings forty-three times every second, right?", "Oh, King, eh, very nice. And how d'you get that, eh? By exploiting the workers! By 'anging on to outdated imperialist dogma which perpetuates the economic and social differences in our society. If there's ever going to be any progress with the--", "Oh! Come and see the violence inherent in the system! Help! Help! I'm being repressed!", "Here I am, brain the size of a planet, and they ask me to take you to the bridge. Call that job satisfaction, 'cause I don't.", "Ghastly, isn't it? All the doors on this spaceship have been programmed to have a cheery and sunny disposition.", "whazzap?", "Explain again how sheep's bladders may be employed to prevent earthquakes.", "Pardon me for breathing, which I never do anyway so I don't know why I even bothered to say it. Oh god, I'm so depressed.", "I've got this pain in all the diodes down my left side", "I would like to say that it is a very great pleasure, honour and privilege for me to open this bridge, but I can't because my lying circuits are all out of commission", "Do you want me to sit in the corner and rust, or just fall apart where I'm standing?", "You may think you've read Hamlet before, but you can't really appreciate it until you've read it in the original Klingon." };

      public static string getRandomString()
      {
         int pos = (int)(strings.Length * new Random(1).NextDouble() * 0.99999);
         return strings[pos];
      }

      ///   
      ///	 <summary> * Returns a string with deleted whitespaces near 'delim' and from the both ends of the string (if they were there)<br>
      ///	 * 
      ///	 * tokenizes a given string 'str' into tokens without separators. Trims every token from both sides to remove the
      ///	 * whitespaces and builds a new string from these tokens separated by 'delim'.
      ///	 *  </summary>
      ///	 * <param name="str"> working string </param>
      ///	 * <param name="delim"> the delimiter
      ///	 *  </param>
      ///	 * <returns> String - the modified string </returns>
      ///	 
      public static string zappTokenWS(string str, string delim)
      {
         string s = JDFConstants.EMPTYSTRING;

         VString vs = new VString(str, delim);
         int size = vs.Count;

         if (size > 0)
         {
            s = (vs[0]).Trim();

            for (int i = 1; i < size; i++)
            {
               s = s + delim + (vs[i]).Trim();
            }
         }
         return s;
      }

      ///   
      ///	 <summary> * format a string using C++ sprintf functionality
      ///	 *  </summary>
      ///	 * <param name="format"> the format to print, see C++ spec for details </param>
      ///	 * <param name="template"> - comma separated string - the values are parsed and the appropriate objects are created more
      ///	 *            objects exist in template than the number of '%' tokens in format, the remainder of objects is ignored
      ///	 *            duplicate '\\,' is taken as literal ',' </param>
      ///	 * <returns> String the formatted string </returns>
      ///	 * <exception cref="IllegalArgumentException"> in case format and o do not match, i.e. not eough objects are passed to fill
      ///	 *             format </exception>
      ///	 
      public static string sprintf(string format, string template)
      {
         string templateLocal = template;

         if (templateLocal == null || format == null)
            return null;
         templateLocal = StringUtil.replaceString(templateLocal, "\\,", "__comma__Äﬂ-eher selten"); // quick
         // hack
         // ;
         // -
         // )

         VString vTemplate = new VString(tokenize(templateLocal, ",", false));
         object[] vObj = new object[vTemplate.Count];
         for (int i = 0; i < vObj.Length; i++)
         {
            string s = vTemplate.stringAt(i);
            if (isInteger(s))
               vObj[i] = parseInt(s, 0); //new int(parseInt(s, 0));
            else if (isNumber(s))
            {
               vObj[i] = parseDouble(s, 0); // new double(parseDouble(s, 0));
            }
            else
            {
               vObj[i] = StringUtil.replaceString(s, "__comma__Äﬂ-eher selten", ","); // quick
               // hack
               // ;
               // -
               // )
            }
         }
         return sprintf(format, vObj);
      }

      ///   
      ///	 <summary> * format a string using C++ sprintf functionality
      ///	 *  </summary>
      ///	 * <param name="format"> the format to print, see C++ spec for details </param>
      ///	 * <param name="objects"> the array of objects, either String, Double, Integer or ValuedEnum, if objects is longer than the
      ///	 *            number of '%' tokens in format, the remainder of objects is ignored The method works fairly loosely
      ///	 *            typed, thus doubles are printed as integers, Strings are converted to numbers, if possible etc.
      ///	 *  </param>
      ///	 * <returns> String the formatted string </returns>
      ///	 * <exception cref="IllegalArgumentException"> in case format and o do not match, i.e. not eough objects are passed to fill
      ///	 *             format </exception>
      ///	 
      public static string sprintf(string format, object[] objects)
      {
         string formatLocal = format;

         if (objects == null || formatLocal == null)
            return null;

         formatLocal = StringUtil.replaceString(formatLocal, "%%", "__percent__Äﬂ-eher selten"); // quick
         // hack
         // ;
         // -
         // )
         bool bStart = formatLocal.StartsWith("%");
         VString tokens = new VString(tokenize(formatLocal, "%", false));
         int nStart = (bStart ? 0 : 1);
         if (tokens.Count > objects.Length + nStart)
            throw new ArgumentException("not enough tokens to satisfy format");

         // tokenize does not return an empty token if we start with %
         string s = bStart ? "" : tokens.stringAt(0);
         PrintfFormat f = new PrintfFormat("");

         for (int i = nStart; i < tokens.Count; i++)
         {
            f.set("%" + tokens.stringAt(i));
            object ob = objects[i - nStart];
            if (ob is string)
               s += f.tostr((string)ob);
            else if (ob is int)
               s += f.tostr((int)ob);
            else if (ob is double)
               s += f.tostr((double)ob);
            else if (ob is ValuedEnum)
               s += f.tostr(((ValuedEnum)ob).getName());
         }

         return replaceString(s, "__percent__Äﬂ-eher selten", "%"); // undo quick hack ;-)
      }

      ///   
      ///	 <summary> * create a string from an array of tokens
      ///	 *  </summary>
      ///	 * <param name="v"> the token array </param>
      ///	 * <param name="sep"> the separator between the tokens </param>
      ///	 * <param name="front"> the front end of the string </param>
      ///	 * <param name="back"> the back end of the string </param>
      ///	 * <returns> String - the vector as String
      ///	 * 
      ///	 *         default: setvString(v, JDFConstants.BLANK, null, null) </returns>
      ///	 
      public static string setvString(string[] a, string sep, string front, string back)
      {
         if (a == null)
            return null;
         VString v = new VString(a);
         return setvString(v, sep, front, back);
      }

      ///   
      ///	 <summary> * create a string from a vector of tokens
      ///	 * <p>
      ///	 * default: setvString(v, JDFConstants.BLANK, null, null)
      ///	 *  </summary>
      ///	 * <param name="v"> the token vector
      ///	 *  </param>
      ///	 * <returns> String - the vector as String </returns>
      ///	 
      public static string setvString(VString v)
      {
         return setvString(v, m_sep, null, null);
      }

      ///   
      ///	 <summary> * create a string from a vector of tokens
      ///	 *  </summary>
      ///	 * <param name="v"> the token vector </param>
      ///	 * <param name="sep"> the separator between the tokens </param>
      ///	 * <param name="front"> the front end of the string </param>
      ///	 * <param name="back"> the back end of the string
      ///	 *  </param>
      ///	 * <returns> String - the vector as String
      ///	 * 
      ///	 *         default: setvString(v, JDFConstants.BLANK, null, null) </returns>
      ///	 
      public static string setvString(VString v, string sep, string front, string back)
      {
         if (v == null)
            return null;

         int siz = v.Count;
         StringBuilder buf = new StringBuilder(siz * 16); // guestimat 16 chars per
         // token max

         if (front != null)
            buf.Append(front);

         for (int i = 0; i < siz; i++)
         {
            if (i > 0 && sep != null)
            {
               buf.Append(sep);
            }
            object elementAt = v[i];
            if (elementAt is string)
            {
               buf.Append((string)elementAt);
            }
            else if (elementAt is ValuedEnum)
            {
               buf.Append(((ValuedEnum)elementAt).getName());
            }
            else
               throw new ArgumentException("illegal vector contents");

         }

         if (back != null)
            buf.Append(back);

         return buf.ToString();
      }

      ///   
      ///	 <summary> * n > 0 substring(0, n) take the first n chars (leftmost) n < 0 substring(0, s.length()+n) take the string and cut
      ///	 * n chars on the right example: string = "abcdefgh" string.leftStr( 2) = "ab" string.leftStr(-3) = "abcde"
      ///	 *  </summary>
      ///	 * <param name="strWork"> the string to work on </param>
      ///	 * <param name="n"> number of characters to cut (negative) or retain (positive) </param>
      ///	 * <returns> the modified string </returns>
      ///	 
      public static string leftStr(string strWork, int n)
      {
         int nLocal = n;

         if (strWork == null)
            return null;

         if (nLocal < 0)
         {
            nLocal = strWork.Length + nLocal;
         }

         if (nLocal <= 0)
         {
            return null;
         }

         return strWork.Substring(0, nLocal <= strWork.Length ? nLocal : strWork.Length);
      }

      ///   
      ///	 <summary> * get the end of a string n > 0 str.substring(str.length() - n) take the rightmost n chars n < 0 substring(-n) take
      ///	 * the string and cut n chars on the left example: string = "abcdefgh" string.rightStr( 2) = "gh"
      ///	 * string.rightStr(-3) = "defgh"
      ///	 *  </summary>
      ///	 * <param name="strWork"> the string to work on </param>
      ///	 * <param name="n"> number of characters to cut (negative) or retain (positive) </param>
      ///	 * <returns> the modified string </returns>
      ///	 
      public static string rightStr(string strWork, int n)
      {
         int nLocal = n;

         if (strWork == null)
            return null;

         if (nLocal < 0)
         {
            nLocal = strWork.Length + nLocal;
         }

         if (nLocal <= 0)
         {
            return null;
         }

         if (nLocal > strWork.Length)
         {
            return strWork;
         }

         return strWork.Substring(strWork.Length - nLocal);
      }

      ///   
      ///	 <summary> * return a vector of individual tokens<br>
      ///	 * Multiple consequtive delimitors are treated as one (similar to whitespace handling).
      ///	 * <p>
      ///	 * default: tokenize(strWork, delim, false)
      ///	 *  </summary>
      ///	 * <param name="strWork"> the string to tokenize </param>
      ///	 * <param name="delim"> the delimiter, if null use whitespace </param>
      ///	 * <param name="delim2token"> should a delimiter be a token? </param>
      ///	 * <returns> the vector of strings </returns>
      ///	 
      public static ArrayList tokenize(string strWork, string delim, bool delim2token)
      {
         string delimLocal = delim;

         delimLocal = delimLocal == null ? JDFConstants.BLANK : delimLocal;
         ArrayList v = new ArrayList();
         if (strWork != null)
         {
            if (delimLocal.Length == 1 && strWork.IndexOf(delimLocal) < 0)
            {
               v.Add(strWork);
               return v;
            }
            //StringTokenizer st = new StringTokenizer(strWork, delimLocal, delim2token);
            SupportClass.Tokenizer st = new SupportClass.Tokenizer(strWork, delimLocal, delim2token);
            while (st.HasMoreTokens())
            {
               v.Add(st.NextToken());
            }
         }

         return v;
      }

      ///   
      ///	 <summary> * check whether a String contains a given token
      ///	 * <p>
      ///	 * default: hasToken(strWork, token, delim, 0)
      ///	 *  </summary>
      ///	 * <param name="strWork"> the string to work on </param>
      ///	 * <param name="token"> the token to search for </param>
      ///	 * <param name="delim"> the delimiter of the tokens </param>
      ///	 * <param name="iSkip"> the number of matching tokens to skip before returning true </param>
      ///	 * <returns> boolean - true if <code>strWork</code> contains <code>token</code> </returns>
      ///	 
      public static bool hasToken(string strWork, string token, string delim, int iSkip)
      {
         if (strWork != null)
         {
            int posToken1 = strWork.IndexOf(token);
            if (posToken1 < 0)
               return false;
            if (posToken1 > 0)
               posToken1--; // go back one in case the char before the first
            // token was not the deliminator
            //StringTokenizer st = new StringTokenizer(strWork.Substring(posToken1), delim, false);
            SupportClass.Tokenizer st = new SupportClass.Tokenizer(strWork.Substring(posToken1), delim, false);
            int n = 0;
            while (st.HasMoreTokens())
            {
               if (st.NextToken().Equals(token))
               {
                  if (n++ >= iSkip)
                     return true;
               }
            }
         }
         return false;
      }

      ///   
      ///	 <summary> * check whether a vector of Strings contains a given token
      ///	 * <p>
      ///	 * default: hasToken(strWork, token, 0)
      ///	 *  </summary>
      ///	 * <param name="strWork"> the vector of strings string to work on </param>
      ///	 * <param name="token"> the token to search for </param>
      ///	 * <param name="iSkip"> the number of matching tokens to skip before returning true </param>
      ///	 * <returns> true, if <code>strWork</code> contains <code>token</code> </returns>
      ///	 
      public static bool hasToken(string[] strWork, string token, int iSkip)
      {
         if (strWork != null)
         {
            int n = 0;
            for (int i = 0; i < strWork.Length; i++)
            {
               if (strWork[i].Equals(token))
               {
                  if (n++ >= iSkip)
                     return true;
               }
            }
         }
         return false;
      }

      ///   
      ///	 <summary> * get a single token from a String
      ///	 * <p>
      ///	 * default: Token(strWork, index," \t\n")
      ///	 *  </summary>
      ///	 * <param name="strWork"> the String to work on </param>
      ///	 * <param name="index"> index of the token to return<br>
      ///	 *            if<0 return from end (e.g. -1 is the last token) </param>
      ///	 * <param name="delim"> the delimiter </param>
      ///	 * <returns> the single token (<code>null</code> if no token found) </returns>
      ///	 
      public static string token(string strWork, int index, string delim)
      {
         int indexLocal = index;

         string delimLocal = delim;

         if (strWork == null)
            return null; // null bleibt null

         if (delimLocal == null)
            delimLocal = JDFConstants.BLANK;

         int pos = delimLocal.Length == 1 ? strWork.IndexOf(delimLocal) : 0;
         if (pos < 0) // speed up incase we only have one entry
         {
            return (indexLocal == -1 || indexLocal == 0) ? strWork : null;
         }

         if (indexLocal < 0)
         {
            ArrayList v = StringUtil.tokenize(strWork, delimLocal, false);
            indexLocal = v.Count + indexLocal;
            if (indexLocal < 0)
               return null;

            if (indexLocal < v.Count)
               return (string)v[indexLocal];

            return null;
         }

         // index >0 don't need to calculate # of tokens
         //StringTokenizer st = new StringTokenizer(strWork, delimLocal, false);
         SupportClass.Tokenizer st = new SupportClass.Tokenizer(strWork, delimLocal, false);
         int n = 0;
         string s = null;
         while (st.HasMoreTokens())
         {
            s = st.NextToken();
            if (n++ == indexLocal)
               return s;
         }

         return null;
      }

      ///   
      ///	 <summary> * replace a character in a given String
      ///	 * <p>
      ///	 * default: replaceChar(strWork, c, s, 0)
      ///	 *  </summary>
      ///	 * <param name="strWork"> String to work on </param>
      ///	 * <param name="c"> characters to replace </param>
      ///	 * <param name="replaceString"> String to insert for c </param>
      ///	 * <param name="offset"> </param>
      ///	 * <returns> the String with replaced characters </returns>
      ///	 
      public static string replaceCharSet(string strWork, string charSet, string replaceString, int offset)
      {
         string strWorkLocal = strWork;

         if (charSet == null)
            return strWorkLocal;
         for (int i = 0; i < charSet.Length; i++)
            strWorkLocal = replaceChar(strWorkLocal, charSet[i], replaceString, offset);
         return strWorkLocal;
      }

      ///   
      ///	 <summary> * replace any of a set of characters in a given String
      ///	 * <p>
      ///	 * default: replaceChar(strWork, c, s, 0)
      ///	 *  </summary>
      ///	 * <param name="strWork"> String to work on </param>
      ///	 * <param name="c"> characters to replace </param>
      ///	 * <param name="replaceString"> String to insert for c </param>
      ///	 * <param name="offset"> </param>
      ///	 * <returns> the String with replaced characters </returns>
      ///	 
      public static string replaceChar(string strWork, char c, string replaceString, int offset)
      {
         if (strWork == null)
            return null;
         if (offset > strWork.Length)
            return strWork;

         StringBuilder b = new StringBuilder(strWork.Length * 2);
         int lastPos = offset;
         b.Append(strWork.Substring(0, offset));
         while (lastPos >= 0)
         {
            int pos = strWork.IndexOf(c, lastPos);
            if (pos >= 0)
            {
               //.Net Substring different than java substring.
               b.Append(strWork.Substring(lastPos, (pos - lastPos)));
               if (replaceString != null)
                  b.Append(replaceString);
            }
            else
            {
               b.Append(strWork.Substring(lastPos));
            }
            lastPos = pos >= 0 ? pos + 1 : pos;
         }

         return b.ToString();
      }

      ///   
      ///	 <summary> * replace a string in a given String if the replacement string is contained by the string to replace, recursively
      ///	 * replace until no ocurrences of the original remain thus replaceString("a000000", "00", "0") will return "a0"
      ///	 * rather than "a000"
      ///	 *  </summary>
      ///	 * <param name="strWork"> String to work on </param>
      ///	 * <param name="toReplace"> String to match and replace </param>
      ///	 * <param name="replaceBy"> String to insert for toReplace, null if nothing should be inserted </param>
      ///	 * <returns> the String with replaced characters </returns>
      ///	 
      public static string replaceString(string strWork, string toReplace, string replaceBy)
      {
         string strWorkLocal = strWork;

         if (strWorkLocal == null)
            return strWorkLocal;

         int lenIn = strWorkLocal.Length;
         int IndexOf = strWorkLocal.IndexOf(toReplace);
         if (IndexOf < 0)
            return strWorkLocal;

         int len = toReplace.Length;
         StringBuilder b = new StringBuilder(strWorkLocal.Length * 2);
         do
         {
            b.Append(strWorkLocal.Substring(0, IndexOf));
            if (replaceBy != null)
               b.Append(replaceBy);
            strWorkLocal = strWorkLocal.Substring(IndexOf + len);
            IndexOf = strWorkLocal.IndexOf(toReplace);
         }
         while (IndexOf >= 0);

         b.Append(strWorkLocal);

         string outString = b.ToString();
         int lenOut = outString.Length;

         return lenOut == lenIn ? outString : replaceString(outString, toReplace, replaceBy);
      }

      public static string xmlNameEscape(string strWork)
      {
         string strWorkLocal = strWork;

         strWorkLocal = replaceChar(strWorkLocal, '*', "_star_", 0);
         strWorkLocal = replaceChar(strWorkLocal, '&', "_and_", 0);

         return strWorkLocal;
      }

      ///   
      ///	 <summary> * the filename extension of pathName
      ///	 *  </summary>
      ///	 * <param name="pathName">
      ///	 * @return </param>
      ///	 * @deprecated use URLUtil.extension 
      ///	 
      [Obsolete("use URLUtil.extension")]
      public static string extension(string pathName)
      {
         return UrlUtil.extension(pathName);
      }

      public static string prefix(string strWork)
      {
         string ext = UrlUtil.extension(strWork);
         if (ext == null)
            return strWork;

         return strWork.Substring(0, strWork.Length - ext.Length - 1);
      }

      ///   
      ///	 <summary> * return null if s==null or s==def, else s<br/>
      ///	 * used e.g. to zapp "" strings </summary>
      ///	 * <param name="s"> the String to test  </param>
      ///	 * <param name="def"> the default that is converted to null </param>
      ///	 * <returns> the converted String </returns>
      ///	 
      public static string getDefaultNull(string s, string def)
      {
         return s == null || def.Equals(s) ? null : s;
      }

      ///   
      ///	 <summary> * return null if s==null or s=="", else s<br/>
      ///	 * used e.g. to zapp "" strings </summary>
      ///	 * <param name="s"> the String to test  </param>
      ///	 * <returns> the converted String </returns>
      ///	 
      public static string getNonEmpty(string s)
      {
         return s == null || JDFConstants.EMPTYSTRING.Equals(s) ? null : s;
      }

      ///   
      ///	 <summary> * replace the .extension of a file name
      ///	 *  </summary>
      ///	 * <param name="strWork"> the file path </param>
      ///	 * <param name="newExt"> the new extension (works with or without the initial "." </param>
      ///	 * <returns> the strWork with a replaced extension </returns>
      ///	 
      public static string newExtension(string strWork, string newExt)
      {
         string newExtLocal = newExt;

         if (newExtLocal == null)
            return StringUtil.prefix(strWork);

         if (!newExtLocal.StartsWith("."))
            newExtLocal = "." + newExtLocal;

         return StringUtil.prefix(strWork) + newExtLocal;
      }

      ///   
      ///	 * @deprecated 060314 use KElement.xmlnsprefix 
      ///	 * <param name="strWork"> </param>
      ///	 * <returns> String </returns>
      ///	 
      [Obsolete("060314 use KElement.xmlnsprefix")]
      public static string xmlNameSpace(string strWork)
      {
         return KElement.xmlnsPrefix(strWork);
      }


      ///   
      ///	 <summary> * get the mime type for a given extension
      ///	 *  </summary>
      ///	 * <param name="strWork"> String to work in </param>
      ///	 
      public static string mime(string strWork)
      {
         string extension = UrlUtil.extension(strWork);
         if (extension == null)
            return JDFConstants.MIME_TEXTUNKNOWN;

         extension = extension.ToLower();

         if ("pdf".Equals(extension))
         {
            return JDFConstants.MIME_PDF;
         }
         else if ("png".Equals(extension))
         {
            return JDFConstants.MIME_PNG;
         }
         else if ("tif".Equals(extension))
         {
            return JDFConstants.MIME_TIFF;
         }
         else if ("jdf".Equals(extension))
         {
            return JDFConstants.MIME_JDF;
         }
         else if ("jdf".Equals(extension))
         {
            return JDFConstants.MIME_JMF;
         }
         else if ("xml".Equals(extension))
         {
            return JDFConstants.MIME_TEXTXML;
         }
         else if ("jpg".Equals(extension) || "jpeg".Equals(extension))
         {
            return JDFConstants.MIME_JPG;
         }
         else
         {
            return JDFConstants.MIME_TEXTUNKNOWN;
         }
      }

      ///   
      ///	 <summary> * checks whether a string is a NMTOKEN
      ///	 *  </summary>
      ///	 * <param name="strWork"> the string to check </param>
      ///	 * <returns> boolean - true if strWork is a NMTOKEN </returns>
      ///	 
      public static bool isNMTOKEN(string strWork)
      {
         // TODO add more exceptions
         if (strWork == null)
            return false;
         if (strWork.Length >= 64)
            return false;

         //// if an error occurs for XmlNames do an "Organize Imports" (different
         //// packages in Java 1.4 and 5.0)
         //   return XmlNames.isNmtoken(strWork);

         // Java to C# Conversion - NOTE: Can't find equivalent of isNntoken() in .NET. 
         //                         VerifyNMTOKEN throws XmlException if string is not valid
         try
         {
            XmlConvert.VerifyNMTOKEN(strWork);
         }
         catch (XmlException)
         {
            return false;
         }
         return true;
      }

      ///   
      ///	 <summary> * checks whether a string is an ID
      ///	 *  </summary>
      ///	 * <param name="strWork"> the string to check </param>
      ///	 * <returns> boolean - true if strWork is an ID </returns>
      ///	 
      public static bool isID(string strWork)
      {
         if (strWork == null || strWork.Length == 0)
            return false;
         if (StringUtils.isNumeric(strWork.Substring(0, 1)))
            return false;
         return isNMTOKEN(strWork);
      }

      ///   
      ///	 <summary> * return true if d1 and d2 are within a range of epsilon or close enough to be serialized identically
      ///	 *  </summary>
      ///	 * <param name="d1"> </param>
      ///	 * <param name="d2"> </param>
      ///	 * <returns> true if (almost) identical </returns>
      ///	 
      public static bool isEqual(double d1, double d2)
      {
         if (d1 == d2)
            return true;
         if (Math.Abs(d1 - d2) < JDFBaseDataTypes_Fields.EPSILON)
            return true;
         if (d1 != 0 && Math.Abs((d2 / d1) - 1.0) < JDFBaseDataTypes_Fields.EPSILON)
            return true;

         return false;
      }

      ///   
      ///	 <summary> * return -1 if d1 < d2 , 0 if d1==d2 ; +1 if d1>d2 are within a range of epsilon or close enough to be serialized
      ///	 * identically
      ///	 *  </summary>
      ///	 * <param name="d1"> </param>
      ///	 * <param name="d2"> </param>
      ///	 * <returns> int 1,0 or -1 </returns>
      ///	 
      public static int CompareTo(double d1, double d2)
      {
         if (isEqual(d1, d2))
            return 0;
         return d1 < d2 ? -1 : 1;

      }

      ///   
      ///	 <summary> * checks whether a string is matches an NMTOKENS list
      ///	 *  </summary>
      ///	 * <param name="strWork"> the string to check </param>
      ///	 * <returns> boolean - true if strWork is an NMTOKENS list </returns>
      ///	 * @deprecated 060309 use isNMTOKENS(strWork,false) 
      ///	 
      [Obsolete("060309 use isNMTOKENS(strWork,false)")]
      public static bool isNMTOKENS(string strWork)
      {
         return isNMTOKENS(strWork, false);
      }

      ///   
      ///	 <summary> * checks whether a string is a NMTOKENS list
      ///	 *  </summary>
      ///	 * <param name="strWork"> the string to check </param>
      ///	 * <param name="bID"> if true, also check that each individual token matches the pattern for an ID </param>
      ///	 * <returns> boolean true if strWork is a NMTOKENS list </returns>
      ///	 
      public static bool isNMTOKENS(string strWork, bool bID)
      {
         if (strWork == null)
            return false;
         ArrayList vs = StringUtil.tokenize(strWork, "\t ", false);
         int s = vs.Count;
         if (s == 0)
         {
            return true; // tbd is an empty list an NMTOKENS ?
         }
         for (int i = 0; i < s; i++)
         {
            if ((bID && !StringUtil.isID((string)vs[i])) || !StringUtil.isNMTOKEN((string)vs[i]))
            {
               return false;
            }
         }
         return true;
      }

      

      ///   
      ///	 <summary> * checks whether a string matches the boolean values "true" or "false"
      ///	 *  </summary>
      ///	 * <param name="strWork"> the string to check </param>
      ///	 * <returns> boolean true if strWork is represents boolean value </returns>
      ///	 
      public static bool isBoolean(string strWork)
      {
         return "true".Equals(strWork) || "false".Equals(strWork);
      }

      ///   
      ///	 <summary> * checks whether a string is a number
      ///	 *  </summary>
      ///	 * <param name="strWork"> the string to check </param>
      ///	 * <returns> boolean true if strWork is a number </returns>
      ///	 
      public static bool isNumber(string str)
      {
         if (str == null)
            return false;
         string dStr = str.Trim();
         if (dStr.Length == 0)
            return false;

         // if I get the default in both cases it is really snafu
         if ((parseDouble(str, -1234567.987) == -1234567.987) && (parseDouble(str, 9876.473) == 9876.473))
            return false;
         return true;
      }

      ///   
      ///	 <summary> * replaces all chars that are not compatible with xml1.0
      ///	 *  </summary>
      ///	 * <param name="strText"> the text to check </param>
      ///	 * <param name="replace"> the single char string to replace non xml chars with; if null the non-xml char is simply omitted </param>
      ///	 * <returns> the clean string, may be the same string </returns>
      ///	 
      public static string wipeInvalidXML10Chars(string strText, string replace)
      {
         string strTextLocal = strText;

         char[] chars = strTextLocal.ToCharArray();

         bool found = false;
         int n = 0;
         for (int i = 0; i < chars.Length; i++)
         {
            if (n > 0)
               chars[i - n] = chars[i];
            if (!isValidXML10Char(chars[i]))
            {
               if (replace != null)
                  chars[i] = replace[0];
               else
                  n++;

               found = true;
            }
         }

         if (found)
         {

            strTextLocal = new string(chars);
            if (n > 0)
               strTextLocal = strTextLocal.Substring(0, chars.Length - n);
         }

         return strTextLocal;
      }

      private static bool isValidXML10Char(char c)
      {
         if ((c >= 0x20) && (c <= 0xD7FF))
         {
            return true;
         }
         else if ((c == 0x9) || (c == 0xA) || (c == 0xD))
         {
            return true;
         }
         else if ((c >= 0xE000) && (c <= 0xFFFD))
         {
            return true;
         }
         return false;
      }

      ///   
      ///	 <summary> * find the last character in strwork that is not in strNotList
      ///	 *  </summary>
      ///	 * <param name="strWork"> the string to search </param>
      ///	 * <param name="strNotList"> the list of characters to ignore </param>
      ///	 * <returns> position of the last matching char, -1 if all strWork only contains chars from strNotList </returns>
      ///	 
      public static int find_last_not_of(string strWork, string strNotList)
      {
         if (strWork == null)
            return -1;
         if (strNotList == null || strNotList.Length == 0)
            return strWork.Length - 1;

         for (int i = strWork.Length - 1; i >= 0; i--)
         {
            if (strNotList.IndexOf(strWork[i]) < 0)
               return i;
         }

         return -1;
      }

      ///   
      ///	 <summary> * returns the position of the token, if it is in the String.<br>
      ///	 * The separator is excluded from the tokens. Multiple consecutive separators are treated as one (similar to
      ///	 * whitespace handling).
      ///	 *  </summary>
      ///	 * <param name="name"> the token to search </param>
      ///	 * <param name="separator"> separator </param>
      ///	 * <param name="iSkip"> number of tokens to skip before accepting (if 0 -> take the first etc., -1 -> first as well) </param>
      ///	 * <returns> int - 0 based position if the token exists, else -1 </returns>
      ///	 
      public static int posOfToken(string strWork, string name, string separator, int iSkip)
      {
         int posOfToken = -1;
         ArrayList vNames = new ArrayList();
         if (!name.Equals(JDFConstants.EMPTYSTRING))
         {
            vNames.AddRange(StringUtil.tokenize(strWork, separator, false));
         }

         if (iSkip == -1 || iSkip == 0)
         {
            posOfToken = vNames.IndexOf(name);
         }
         else
         {
            int occurence = 0;
            for (int i = 0; i < vNames.Count; i++)
            {
               string strName = (string)vNames[i];
               if (strName.Equals(name))
               {
                  if (occurence++ == iSkip)
                  {
                     posOfToken = i;
                     break;
                  }
               }
            }
         }
         return posOfToken;
      }

      ///   
      ///	 <summary> * check whether a string contains a complete token
      ///	 * <p>
      ///	 * default: hasToken(strWork, token, delim)
      ///	 *  </summary>
      ///	 * <param name="strWork"> the string to work on </param>
      ///	 * <param name="typ"> the token to search for </param>
      ///	 * <param name="delim"> the delimiter of the tokens </param>
      ///	 * <returns> boolean - </returns>
      ///	 * @deprecated 060420 use hasToken(strWork, token, delim, 0) 
      ///	 
      [Obsolete("060420 use hasToken(strWork, token, delim, 0)")]
      public static bool hasToken(string strWork, string typ, string delim)
      {
         return hasToken(strWork, typ, delim, 0);
      }

      ///   
      ///	 <summary> * set this to the raw bytes specified in buffer, bypassing all transcoders
      ///	 *  </summary>
      ///	 * <param name="buffer"> the buffer to assign to <code>this</code> </param>
      ///	 * <param name="len"> </param>
      ///	 
      public static string setRawBytes(sbyte[] buffer, int len)
      {
         int lenLocal = len;

         if (lenLocal < 0)
         {
            lenLocal = buffer.Length;
         }

         char[] target = null;

         if (!(buffer.Length < 0))
         {

            if (lenLocal > 0)
            {
               target = new char[lenLocal];

               for (int i = 0; i < lenLocal; i++)
               {
                  target[i] = (char)buffer[i];
               }
            }
            else
            {
               target = new char[0]; // should never reached
            }
         }
         else
         {
            target = new char[0];
         }
         return new string(target);
      }

      ///   
      ///	 <summary> * get the raw bytes specified in strUnicode, bypassing all transcoders<br>
      ///	 * any character values above 255 is truncated (c=c&0xff)
      ///	 *  </summary>
      ///	 * <returns> char array of the raw bytes assigned to this </returns>
      ///	 
      public static sbyte[] getRawBytes(string strUnicode)
      {
         char[] pBuf = strUnicode.ToCharArray();

         int len = pBuf.Length;

         sbyte[] pc = new sbyte[len];

         for (int i = 0; i < len; i++)
         {
            pc[i] = (sbyte)(pBuf[i] & 0x00ff);
         }
         return pc;
      }

      ///   
      ///	 <summary> * get buffer as HexBinary <br>
      ///	 * any character values above 255 is truncated
      ///	 *  </summary>
      ///	 * <param name="buffer"> the String which you want to encode to HexBinary </param>
      ///	 * <param name="len"> the length of the buffer. <br>
      ///	 *            If<0, default is -1. In this case the lenght of the char array will be used. </param>
      ///	 

      public static string setHexBinaryBytes(sbyte[] buffer, int len)
      {
         int lenLocal = len;

         char[] target = null;

         if (buffer.Length >= 0)
         {
            if (lenLocal < 0)
            {
               lenLocal = buffer.Length;
               target = new char[lenLocal * 2];
            }
            if (lenLocal > 0)
            {
               target = new char[lenLocal * 2];
               for (int i = 0; i < lenLocal; i++)
               {
                  char c = (char)((buffer[i] & 0x00f0) >> 4);
                  target[2 * i] = (c >= 10) ? (char)('A' - 10 + c) : (char)('0' + c);
                  c = (char)(buffer[i] & 0x000f);
                  target[2 * i + 1] = (c >= 10) ? (char)('A' - 10 + c) : (char)('0' + c);
               }
            }
            else
            {
               target = new char[0];
            }
         }
         else
         {
            target = new char[0];
         }
         return new string(target);
      }

      ///   
      ///	 <summary> * Decode a HexBinary encoded byte array back to Unicode
      ///	 *  </summary>
      ///	 * <param name="unicodeArray"> array which stores the HexBinary </param>
      ///	 * <returns> array of byte holding the unicode chars </returns>
      ///	 
      public static sbyte[] getHexBinaryBytes(sbyte[] unicodeArray)
      {
         sbyte[] emptyArray = new sbyte[0];
         int len = unicodeArray.Length;

         // check if there is at least one 16Bit unicode char
         if (len % 2 > 0)
         {
            return emptyArray;
         }

         // this will be the container for output
         sbyte[] pc = new sbyte[len / 2];
         sbyte c = (sbyte)'0';

         for (int i = 0; i < len / 2; i++)
         {
            // maskiert das obere Byte
            int p = unicodeArray[i * 2] & 0x00ff;

            // System.out.println((int)'0');

            if (p >= '0' && p <= '9')
            {
               c = (sbyte)(p - '0');
            }
            else
            {
               if (p >= 'A' && p <= 'F')
               {
                  c = (sbyte)(10 + p - 'A');
               }
               else
               {
                  if (p >= 'a' && p <= 'f')
                  {
                     c = (sbyte)(10 + p - 'a');
                  }
                  else
                  {
                     return emptyArray;
                  }
               }
            }

            pc[i] = (sbyte)(c << 4);

            p = unicodeArray[i * 2 + 1] & 0x00ff;

            if (p >= '0' && p <= '9')
            {
               c = (sbyte)(p - '0');
            }
            else
            {
               if (p >= 'A' && p <= 'F')
               {
                  c = (sbyte)(10 + p - 'A');
               }
               else
               {
                  if (p >= 'a' && p <= 'f')
                  {
                     c = (sbyte)(10 + p - 'a');
                  }
                  else
                  {
                     return emptyArray;
                  }
               }
            }
            pc[i] += c;
         }
         return pc;
      }

      ///   
      ///	 <summary> * return the UTF8 String <code>strUnicode</code> as Unicode byte array
      ///	 *  </summary>
      ///	 * <param name="strUnicode"> the unicode string to transcode to utf8 </param>
      ///	 * <returns> a byte array[] representing the utf-8 code of the input string, <code>null</code> if an error occurred </returns>
      ///	 
      public static sbyte[] setUTF8String(string strUnicode)
      {
         if (strUnicode != null && !strUnicode.Equals(JDFConstants.EMPTYSTRING))
         {
            try
            {
               //return strUnicode.getBytes("UTF-8");
               Encoding encoding = Encoding.UTF8;
               return SupportClass.ToSByteArray(encoding.GetBytes(strUnicode));
            }
            catch (IOException)
            {
               return null;
            }
         }
         return null;
      }

      ///   
      ///	 <summary> * get the unicode string representing the UTF8 representation of the byte buffer
      ///	 *  </summary>
      ///	 * <returns> String - the unicode string representation of the utf8 bytes assigned to this, <code>null</code> if an
      ///	 *         error occurrred </returns>
      ///	 
      public static string getUTF8String(sbyte[] utf8)
      {
         if (utf8 != null && utf8.Length != 0)
         {
            try
            {
               return System.Text.Encoding.GetEncoding("UTF-8").GetString(SupportClass.ToByteArray(utf8));
            }
            catch (IOException e)
            {
               SupportClass.WriteStackTrace(e, Console.Error);
               return null;
            }
         }
         return null;
      }

      ///   
      ///	 <summary> * returns a formatted double. Truncates to 8 digits after the "." <br>
      ///	 * If the double is representable as an integer, any ".0" is stripped.
      ///	 *  </summary>
      ///	 * <param name="d"> the double to format </param>
      ///	 * <returns> the formatted string that represents d TBD handle exp format </returns>
      ///	 
      public static string formatDouble(double d)
      {
         string s;
         if (d == double.MaxValue)
         {
            s = JDFConstants.POSINF;
         }
         else if (d == -double.MaxValue)
         {
            s = JDFConstants.NEGINF;
         }
         else
         {
            s = Convert.ToString(d);
            if (s.EndsWith(".0"))
               s = s.Substring(0, s.Length - 2);
            if (s.IndexOf("E") >= 0)
            {
               object[] ad = { d };
               s = sprintf("%10.10f", ad);
            }

            if (s.Length > 10)
            {
               int posDot = s.IndexOf(JDFConstants.DOT);
               if (posDot >= 0)
               {
                  int l = s.Length;
                  if (l - posDot > 8)
                  {
                     l = posDot + 9;
                     s = s.Substring(0, l);
                     if (s.EndsWith("999"))
                        return formatDouble(d + 0.000000004);

                     int n;
                     for (n = l; n > posDot; n--)
                     {
                        //.Net Substring different than java substring.
                        if (!s.Substring(n - 1, 1).Equals("0"))
                           break;
                     }
                     s = s.Substring(0, n);
                  }
               }
            }
            if (s.EndsWith("."))
            {
               s = leftStr(s, -1);
            }
            if ("-0".Equals(s))
               s = "0";
         }
         return s;
      }

      ///   
      ///	 <summary> * returns a formatted integer, replaces string constants with according int constants
      ///	 *  </summary>
      ///	 * <param name="i"> the integer to format </param>
      ///	 * <returns> the formatted string that represents i TBD handle exp format </returns>
      ///	 
      public static string formatInteger(int i)
      {
         string s = null;

         if (i == int.MaxValue)
         {
            s = JDFConstants.POSINF;
         }
         else if (i == int.MinValue)
         {
            s = JDFConstants.NEGINF;
         }
         else
         {
            s = Convert.ToString(i);
         }
         return s;
      }

      ///   
      ///	 <summary> * checks whether <code>str</code> reprents an integer
      ///	 *  </summary>
      ///	 * <param name="str"> the String to check </param>
      ///	 * <returns> boolean - true if the string represents an integer number </returns>
      ///	 
      public static bool isInteger(string str)
      {
         if (str == null)
            return false;
         string intStr = str.Trim();
         if (intStr.Length == 0)
            return false;

         if (intStr.Equals(JDFConstants.POSINF))
            return true;

         if (intStr.Equals(JDFConstants.NEGINF))
            return true;
         // hack for xml schema conformance, which uses unbounded to define +
         // infinity
         if (intStr.Equals("unbounded"))
            return true;

         try
         {
            Convert.ToInt32(intStr);
            return true;
         }
         catch (FormatException)
         {
            return false;
         }
         catch (OverflowException)
         {
            return false;
         }
      }

      ///   
      ///	 <summary> * escape a string by prepending escapeChar and a numerical representation of the string. Characters to be escaped
      ///	 * are defined by toEscape, escapeBelow and escapeAbove
      ///	 * <p>
      ///	 * default: escape(String toEscape, null, 0, 0, 0, 256); //Note that an escaped character can't be unescaped without
      ///	 * the knowledge of the escapelength
      ///	 *  </summary>
      ///	 * <param name="strToEscape"> the String to escape </param>
      ///	 * <param name="strCharSet"> the set of characters that should be escaped eg "‹÷ƒ¸ˆ‰" </param>
      ///	 * <param name="strEscapeChar"> the character sequence that marks an escape sequence. If <code>null</code>, "\\" is used
      ///	 *  </param>
      ///	 * <param name="iRadix"> the numerical representation base of the escaped chars, e.g. 8 for octal, 16 for hex<br>
      ///	 *            if radix == 0 the escape char is merely inserted<br>
      ///	 *            if radix <0 the escape char is replaced by the prefix<br>
      ///	 *            valid radix: -1,0,2,8,10,16
      ///	 *  </param>
      ///	 * <param name="iEscapeLen"> the number of digits per escaped char, not including escapeChar
      ///	 *  </param>
      ///	 * <param name="iEscapeBelow"> all characters with an encoding below escapeBelow should also be escaped
      ///	 *  </param>
      ///	 * <param name="iEscapeAbove"> all characters with an encoding above escapeAbove should also be escaped
      ///	 *  </param>
      ///	 * <returns> the string where all illegal sequences have been replaced by their escaped representation </returns>
      ///	 
      public static string escape(string strToEscape, string strCharSet, string strEscapeChar, int iRadix, int iEscapeLen, int iEscapeBelow, int iEscapeAbove)
      {
         int iEscapeAboveLocal = iEscapeAbove;
         string strEscapeCharLocal = strEscapeChar;

         if (strEscapeCharLocal == null)
         {
            strEscapeCharLocal = "\\";
         }

         if (iEscapeAboveLocal < 0)
            iEscapeAboveLocal = 0x7fffffff;

         // String escapedString = JDFConstants.EMPTYSTRING;
         //sbyte[] a_toEscape = strToEscape.getBytes();
         Encoding encoding = Encoding.Default;
         sbyte[] a_toEscape = SupportClass.ToSByteArray(encoding.GetBytes(strToEscape));
         int l = a_toEscape.Length;
         int cToEscape;
         sbyte[] escaped = new sbyte[a_toEscape.Length * 4];
         int posE = 0;
         //sbyte[] escapeCharbytes = strEscapeCharLocal.getBytes();
         sbyte[] escapeCharbytes = SupportClass.ToSByteArray(encoding.GetBytes(strEscapeCharLocal));

         for (int i = 0; i < l; i++)
         {
            cToEscape = a_toEscape[i];
            if (cToEscape < 0)
               cToEscape = 256 + cToEscape;

            if ((cToEscape > iEscapeAboveLocal) || (cToEscape < iEscapeBelow) || (strCharSet != null && strCharSet.IndexOf(Convert.ToChar(cToEscape)) != -1))
            { // the character must be escaped
               for (int ee = 0; ee < escapeCharbytes.Length; ee++)
               {
                  escaped[posE] = escapeCharbytes[ee];
                  posE++;
               }

               if (iRadix > 0)
               { // radix is a flag to convert to octal, hex etc.
                  StringBuilder buf = new StringBuilder();

                  if (iRadix == 2)
                  {
                     buf.Append(Convert.ToString(cToEscape, 2));  //int.toBinaryString(cToEscape));
                  }
                  else if (iRadix == 8)
                  {
                     buf.Append(Convert.ToString(cToEscape, 8)); //int.toOctalString(cToEscape));
                  }
                  else if (iRadix == 10)
                  {
                     buf.Append(Convert.ToString(cToEscape)); //int.ToString(cToEscape));
                  }
                  else if (iRadix == 16)
                  {
                     buf.Append(Convert.ToString(cToEscape, 16)); //int.toHexString(cToEscape));
                  }
                  else
                  {
                     throw new ArgumentException("StringUtil.escape radix out of range");
                  }

                  if (iEscapeLen > 0)
                  { // check if the length of the buffer is smaler then the
                     // ordered escape length. If this is the case
                     // insert some 0 in front of. for Example buf = 12345
                     // iEscapeLen is 7. The result String is 0012345
                     int lenBuf = buf.Length;
                     if (lenBuf < iEscapeLen)
                     {
                        for (int j = 0; j < iEscapeLen - lenBuf; j++)
                        {
                           buf.Insert(j, '0');
                        }
                     }
                  }

                  //sbyte[] bufbytes = buf.ToString().getBytes();
                  encoding = Encoding.Default;
                  sbyte[] bufbytes = SupportClass.ToSByteArray(encoding.GetBytes(buf.ToString()));
                  for (int ee = 0; ee < bufbytes.Length; ee++)
                  {
                     escaped[posE] = bufbytes[ee];
                     posE++;
                  }

                  // empty StringBuffer
                  buf.Remove(0, buf.Length);
               }
               else if (iRadix < 0)
               {
                  // noop
               }
               else
               { // radix = 0; just insert the escape character in front of the
                  // actual char
                  escaped[posE] = a_toEscape[i];
                  posE++;
               }
            }
            else
            { // no escape necessary --> just copy it
               escaped[posE] = a_toEscape[i];
               posE++;
            }
         }

         string escapedString = new string(SupportClass.ToCharArray(escaped), 0, posE);

         return escapedString;
      }

      ///   
      ///	 <summary> * unescape a String which was escaped with the Java StringUtil.escape method
      ///	 *  </summary>
      ///	 * <param name="strToUnescape"> the String to unescape. For example <code>zz\d6\zzz\c4\\dc\z\d6\\24\\3f\zz‰z</code> </param>
      ///	 * <param name="strEscapeChar"> the char which indicates a escape sequenze "\\" in this case (thats also the default) </param>
      ///	 * <param name="iRadix"> the radix of the escape sequenze. 16 in this example. </param>
      ///	 * <param name="escapeLen"> the number of digits per escaped char, not including strEscapeChar
      ///	 *  </param>
      ///	 * <returns> the unescaped String. <code>zz÷zzzƒ‹z÷$?zz‰z</code> in this example </returns>
      ///	 
      public static string unEscape(string strToUnescape, string strEscapeChar, int iRadix, int escapeLen)
      {
         // sbyte[] byteUnEscape = strToUnescape.getBytes();
         Encoding encoding = Encoding.Default;
         sbyte[] byteUnEscape = SupportClass.ToSByteArray(encoding.GetBytes(strToUnescape));
         sbyte[] byteEscape = new sbyte[byteUnEscape.Length];
         //sbyte escapeChar = strEscapeChar.getBytes()[0]; // dont even dream of
         sbyte escapeChar = (sbyte)encoding.GetBytes(strEscapeChar)[0]; // dont even dream of
         // using Ä as an escape
         // char
         int n = 0;
         sbyte[] escapeSeq = new sbyte[escapeLen];

         for (int i = 0; i < byteUnEscape.Length; i++)
         {
            if (byteUnEscape[i] != escapeChar)
            {
               byteEscape[n++] = byteUnEscape[i];
            }
            else
            {
               for (int j = 0; j < escapeLen; j++)
                  escapeSeq[j] = byteUnEscape[++i];

               string strIsEscaped = new string(SupportClass.ToCharArray(SupportClass.ToByteArray(escapeSeq))); // get the escaped
               // str 'd6'
               int integer = Convert.ToInt32(strIsEscaped, iRadix); // and
               // get
               // the
               // int
               // value
               byteEscape[n++] = (sbyte)integer; //.intValue();
            }
         }
         sbyte[] stringByte = null;
         if (n == byteEscape.Length)
            stringByte = byteEscape;
         else
         {
            stringByte = new sbyte[n];
            for (int i = 0; i < n; i++)
               stringByte[i] = byteEscape[i];
         }
         return new string(SupportClass.ToCharArray(SupportClass.ToByteArray(stringByte)));
      }

      ///   
      ///	 <summary> * converts a VString to a single string represents all members of the VString concatenated together
      ///	 *  </summary>
      ///	 * @deprecated use vs.getString(\" \",null,null) 
      ///	 * <returns> String - the unicode string representation of the utf8 bytes assigned to this, null if an error occurrred </returns>
      ///	 
      [Obsolete("use vs.getString(\" \",null,null)")]
      public static string vStringToString(VString vs)
      {
         return StringUtil.setvString(vs, " ", null, null);
      }

      ///   
      ///	 <summary> * parses a string to double and catches any format exception
      ///	 *  </summary>
      ///	 * <param name="s"> the string to parse </param>
      ///	 * <param name="def"> the default to return in case of error </param>
      ///	 * <returns> the parsed double of s
      ///	 * @since 080404 handles "" gracefully </returns>
      ///	 
      public static double parseDouble(string s, double def)
      {
         string sLocal = s;

         if (KElement.isWildCard(sLocal))
            return def;

         double d = def;
         sLocal = sLocal.Trim();
         if (sLocal.Equals(JDFConstants.POSINF))
            return double.MaxValue;

         if (sLocal.Equals(JDFConstants.NEGINF))
            return -double.MaxValue;

         try
         {
            d = Convert.ToDouble(sLocal);
         }
         catch (FormatException)
         {
            d = def;
         }

         return d;
      }

      ///   
      ///	 <summary> * parses a string to double and catches any format exception
      ///	 *  </summary>
      ///	 * <param name="s"> the string to parse </param>
      ///	 * <param name="def"> the default to return in case of error </param>
      ///	 * <returns> the parsed double of s
      ///	 * @since 080404 handles "" gracefully </returns>
      ///	 
      public static bool parseBoolean(string s, bool def)
      {
         string sLocal = s;

         if (KElement.isWildCard(sLocal))
            return def;

         sLocal = sLocal.Trim().ToLower();
         if ("false".Equals(sLocal))
            return false;

         if ("true".Equals(sLocal))
            return true;

         return def;
      }

      ///   
      ///	 <summary> * parses a string to double and catches any format exception
      ///	 *  </summary>
      ///	 * <param name="s"> the string to parse </param>
      ///	 * <param name="def"> the default to return in case of error </param>
      ///	 * <returns> the parsed double of s
      ///	 * @since 080404 handles "" gracefully </returns>
      ///	 
      public static int parseInt(string s, int def)
      {
         string sLocal = s;

         if (KElement.isWildCard(sLocal))
            return def;

         int i = def;
         sLocal = sLocal.Trim();
         if (sLocal.Equals(JDFConstants.POSINF))
            return int.MaxValue;

         if (sLocal.Equals(JDFConstants.NEGINF))
            return int.MinValue;

         try
         {
            i = Convert.ToInt32(sLocal);
         }
         catch (FormatException)
         {
            i = def;
         }

         return i;
      }

      ///   
      ///	 <summary> * Convert a UNC path to a valid file URL or IRL note that some internal functions use network protocol and therefor
      ///	 * performance may be non-optimal
      ///	 *  </summary>
      ///	 * <param name="unc"> The UNC string to parse, may also be used for local characters </param>
      ///	 * <param name="bEscape128"> if true, escape non -ascii chars (URI), if false, don't (IRI) </param>
      ///	 * <returns> the URL string </returns>
      ///	 
      public static string uncToUrl(string unc, bool bEscape128)
      {
         return UrlUtil.fileToUrl(new FileInfo(unc), bEscape128);
      }

      ///   
      ///	 <summary> * gets the file name from a path - regardless of the OS syntax that the path is declared in
      ///	 *  </summary>
      ///	 * <param name="pathName">
      ///	 * @return </param>
      ///	 
      public static string pathToName(string pathName)
      {
         if (UrlUtil.isWindowsLocalPath(pathName) || UrlUtil.isUNC(pathName))
            return token(pathName, -1, "\\");
         return token(pathName, -1, "/");
      }

      ///   
      ///	 * @deprecated use UrlUtil.isWindowsLocalPath(pathName); 
      ///	 
      [Obsolete("use UrlUtil.isWindowsLocalPath(pathName);")]
      public static bool isWindowsLocalPath(string pathName)
      {
         return UrlUtil.isWindowsLocalPath(pathName);

      }


      ///   
      ///	 * @deprecated use URLUtil.isUNC(pathName) 
      ///	 
      [Obsolete("use URLUtil.isUNC(pathName)")]
      public static bool isUNC(string pathName)
      {
         return UrlUtil.isUNC(pathName);
      }

      ///   
      ///	 <summary> * checks whether smallAtt is a matching subset of bigAtt depending on datatype
      ///	 *  </summary>
      ///	 * <param name="smallAtt"> the small att to test </param>
      ///	 * <param name="bigAtt"> the big att, e.g. list to test against </param>
      ///	 * <param name="dataType"> the datatype of the big att
      ///	 *  </param>
      ///	 * <returns> true if smallAtt is a matching subset of bigAtt </returns>
      ///	 
      public static bool matchesAttribute(string smallAtt, string bigAtt, AttributeInfo.EnumAttributeType dataType)
      {
         if (dataType == null || dataType.Equals(AttributeInfo.EnumAttributeType.Any))
            return bigAtt.Equals(smallAtt);

         if ((dataType.Equals(AttributeInfo.EnumAttributeType.NMTOKENS)) || (dataType.Equals(AttributeInfo.EnumAttributeType.enumerations)) || (dataType.Equals(AttributeInfo.EnumAttributeType.IDREFS)))
         {
            // check for matching individual NMTOKEN
            ArrayList vSmall = StringUtil.tokenize(smallAtt, JDFConstants.BLANK, false);
            for (int i = 0; i < vSmall.Count; i++)
            {
               if (!StringUtil.hasToken(bigAtt, (string)vSmall[i], JDFConstants.BLANK, 0))
               {
                  return false;
               }
            }

            return true;
         }

         if (dataType.Equals(AttributeInfo.EnumAttributeType.NumberRange))
         {
            try
            {
               JDFNumberRange r = new JDFNumberRange(bigAtt);
               if (r.inRange(Convert.ToDouble(smallAtt)))
               {
                  return true;
               }
            }
            catch (FormatException)
            {
               // do nothing
            }
            catch (JDFException)
            {
               // do nothing
            }
            catch (ArgumentException)
            {
               // do nothing
            }
         }

         if (dataType.Equals(AttributeInfo.EnumAttributeType.NumberRangeList))
         {
            try
            {
               JDFNumberRangeList r = new JDFNumberRangeList(bigAtt);
               if (r.inRange(Convert.ToDouble(smallAtt)))
               {
                  return true;
               }
            }
            catch (FormatException)
            {
               // do nothing
            }
            catch (JDFException)
            {
               // do nothing
            }
            catch (ArgumentException)
            {
               // do nothing
            }
         }

         if (dataType.Equals(AttributeInfo.EnumAttributeType.IntegerList))
         {
            try
            {
               JDFIntegerList rBig = new JDFIntegerList(bigAtt);
               int i = Convert.ToInt32(smallAtt);
               if (rBig.Contains(i))
               {
                  return true;
               }
            }
            catch (FormatException)
            {
               // do nothing
            }
            catch (JDFException)
            {
               // do nothing
            }
            catch (ArgumentException)
            {
               // do nothing
            }
         }
         if (dataType.Equals(AttributeInfo.EnumAttributeType.IntegerRange))
         {
            try
            {
               JDFIntegerRange rBig = new JDFIntegerRange(bigAtt, int.MaxValue);
               JDFIntegerRange rSmal = new JDFIntegerRange(smallAtt, int.MaxValue);
               if (rBig.isPartOfRange(rSmal))
               {
                  return true;
               }
            }
            catch (FormatException)
            {
               // do nothing
            }
            catch (JDFException)
            {
               // do nothing
            }
            catch (ArgumentException)
            {
               // do nothing
            }
         }

         if (dataType.Equals(AttributeInfo.EnumAttributeType.IntegerRangeList))
         {
            try
            {
               JDFIntegerRangeList rBig = new JDFIntegerRangeList(bigAtt, int.MaxValue);
               JDFIntegerRangeList rSmal = new JDFIntegerRangeList(smallAtt, int.MaxValue);
               if (rBig.isPartOfRange(rSmal))
               {
                  return true;
               }
            }
            catch (FormatException)
            {
               // do nothing
            }
            catch (JDFException)
            {
               // do nothing
            }
            catch (ArgumentException)
            {
               // do nothing
            }
         }

         if (dataType.Equals(AttributeInfo.EnumAttributeType.XYPairRange))
         {
            try
            {
               JDFXYPair xypair = new JDFXYPair(smallAtt);
               JDFXYPairRange r = new JDFXYPairRange(bigAtt);
               if (r.inRange(xypair))
               {
                  return true;
               }
            }
            catch (FormatException)
            {
               // do nothing
            }
            catch (ArgumentException)
            {
               // do nothing
            }
         }

         if (dataType.Equals(AttributeInfo.EnumAttributeType.XYPairRangeList))
         {
            try
            {
               JDFXYPair xypair = new JDFXYPair(smallAtt);
               JDFXYPairRangeList r = new JDFXYPairRangeList(bigAtt);
               if (r.inRange(xypair))
               {
                  return true;
               }
            }
            catch (FormatException)
            {
               // do nothing
            }
            catch (ArgumentException)
            {
               // do nothing
            }
         }

         return false;
      }

      ///   
      ///	 <summary> * match a regular expression using String.matches(), but also catch exceptions and handle simplified regexp. The
      ///	 * <code>null</code> expression is assumed to match anything.
      ///	 *  </summary>
      ///	 * <param name="str"> the string to match </param>
      ///	 * <param name="regExp"> the expression to match against </param>
      ///	 * <returns> true, if str matches regExp or regexp is empty </returns>
      ///	 
      public static bool matches(string str, string regExp)
      {
         string regExpLocal = regExp;

         if (str == null)
            return false;

         // the null expression is assumed to match anything
         if ((regExpLocal == null) || (regExpLocal.Length == 0))
            return true;

         // this is a really common mistake
         if (regExpLocal.Equals("*"))
            regExpLocal = ".*";

         bool b;
         try
         {
            //b = str.matches(regExpLocal);
            b = Regex.IsMatch(str, regExpLocal);

         }
         catch (System.Data.SyntaxErrorException)
         {
            b = false;
         }

         return b;
      }

      ///   
      ///	 <summary> * match a regular expression using ignoring cases using String.matches(), but also catch exceptions and handle
      ///	 * simplified regexp. The <code>null</code> expression is assumed to match anything.
      ///	 *  </summary>
      ///	 * <param name="str"> the string to match </param>
      ///	 * <param name="regExp"> the expression to match against </param>
      ///	 * <returns> true, if str matches regExp or regexp is empty </returns>
      ///	 
      public static bool matchesIgnoreCase(string str, string regExp)
      {
         return matches(str == null ? null : str.ToLower(), regExp == null ? null : regExp.ToLower());
      }

      ///   
      ///	 <summary> * add the string appendString to all Strings in VString vs
      ///	 *  </summary>
      ///	 * <param name="vS"> the string vector </param>
      ///	 * <param name="appendString"> the string to append </param>
      ///	 
      public static void concatStrings(VString vS, string appendString)
      {
         if (vS != null)
         {
            for (int i = 0; i < vS.Count; i++)
            {
               string s = vS.stringAt(i);
               s += appendString;
               vS[i] = s;
            }
         }
      }

      ///

      ///   
      ///	 <summary> * returns the relative URL of a file relative to the current working directory
      ///	 *  </summary>
      ///	 * <param name="f"> the file to get the relative url for </param>
      ///	 * <param name="baseDir"> the file that describes cwd, if null cwd is calculated
      ///	 * @return </param>
      ///	 * @deprecated use getRelativeURL(File f, File fCWD, boolean bEscape128) 
      ///	 
      [Obsolete("use getRelativeURL(File f, File fCWD, boolean bEscape128)")]
      public static string getRelativeURL(FileInfo f, FileInfo baseDir)
      {
         return UrlUtil.getRelativeURL(f, baseDir, true);
      }

      ///   
      ///	 <summary> * returns the relative URL of a file relative to the current workin directory
      ///	 *  </summary>
      ///	 * <param name="f"> the file to get the relative url for </param>
      ///	 * <param name="baseDir"> the file that describes cwd, if null cwd is calculated </param>
      ///	 * <param name="bEscape128"> if true, escape > 128 (URL) else retain (IRL)
      ///	 * @return </param>
      ///	 *@deprecated use URLUtil.getRelativeURL 
      ///	 
      [Obsolete("use URLUtil.getRelativeURL")]
      public static string getRelativeURL(FileInfo f, FileInfo baseDir, bool bEscape128)
      {
         return UrlUtil.getRelativeURL(f, baseDir, bEscape128);
      }

      ///   
      ///	 <summary> * returns the relative URL of a file relative to the current working directory<br>
      ///	 * this includes escaping of %20 etc.
      ///	 *  </summary>
      ///	 * <param name="f"> the file to get the relative path for </param>
      ///	 * <param name="fCWD"> the file that describes cwd, if <code>null</code> cwd is calculated
      ///	 * @return </param>
      ///	 * @deprecated use URLUtil.getRelativePath(f, fCWD); 
      ///	 
      [Obsolete("use URLUtil.getRelativePath(f, fCWD);")]
      public static string getRelativePath(FileInfo f, FileInfo fCWD)
      {
         return UrlUtil.getRelativePath(f, fCWD);
      }

      ///   
      ///	 <summary> * get a vector of names in an iteration
      ///	 *  </summary>
      ///	 * <param name="e"> any member of the enum to iterate over </param>
      ///	 * <returns> VString - the vector of enum names </returns>
      ///	 
      public static VString getNamesVector(System.Type e)
      {
         VString namesVector = new VString();
         IEnumerator it = EnumUtils.iterator(e);
         while (it.MoveNext())
         {
            namesVector.Add(((ValuedEnum)it.Current).getName());
         }

         return namesVector;
      }



      ///   
      ///	 <summary> * get a vector of elements in an iteration
      ///	 *  </summary>
      ///	 * <param name="e"> any member of the enum to iterate over </param>
      ///	 * <returns> Vector - the vector of enum instances </returns>
      ///	 
      public static ArrayList getEnumsVector(System.Type e)
      {
         ArrayList v = new ArrayList();
         IEnumerator it = EnumUtils.iterator(e);
         while (it.MoveNext())
         {
            v.Add(it.Current);
         }
         return v;
      }

      ///   
      ///	 * <param name="f"> </param>
      ///	 * <param name="b">
      ///	 * @return </param>
      ///	 * @deprecated use UrlUtil.fileToUrl(f, b); 
      ///	 
      [Obsolete("use UrlUtil.fileToUrl(f, b);")]
      public static string fileToUrl(FileInfo f, bool b)
      {
         return UrlUtil.fileToUrl(f, b);
      }

      ///   
      ///	 <summary> * strip a prefix, if it is there else return the string
      ///	 *  </summary>
      ///	 * <param name="str"> the string to strip </param>
      ///	 * <param name="prefix"> the prefix to strip </param>
      ///	 * <param name="bIgnoreCase"> if true ignore the case of the prefix
      ///	 * @return </param>
      ///	 
      public static string stripPrefix(string str, string prefix, bool bIgnoreCase)
      {
         string strLocal = str;
         string prefixLocal = prefix;

         if (strLocal == null)
            return null;

         if (prefixLocal == null)
            return strLocal;

         if (bIgnoreCase)
         {
            strLocal = strLocal.ToLower();
            prefixLocal = prefixLocal.ToLower();
         }

         if (strLocal.StartsWith(prefixLocal))
         {
            strLocal = StringUtil.rightStr(strLocal, -prefixLocal.Length);
         }

         return strLocal;
      }

      ///   
      ///	 <summary> * returns a new string that has all characters stripped from work that are not in keepChars
      ///	 *  </summary>
      ///	 * <param name="work"> </param>
      ///	 * <param name="keepChars">
      ///	 * @return </param>
      ///	 
      public static string stripNot(string work, string keepChars)
      {
         if (work == null || keepChars == null)
            return null;
         StringBuilder b = new StringBuilder(work.Length);
         for (int i = 0; i < work.Length; i++)
         {
            if (keepChars.IndexOf(work[i]) >= 0)
               b.Append(work[i]);

         }
         return b.Length > 0 ? b.ToString() : null;
      }
   }
}
