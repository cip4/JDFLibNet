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
 *    Alternately, this acknowledgment mrSubRefay appear in the software itself,
 *    if and wherever such third-party acknowledgments normally appear.
 *
 * 4. The names "CIP4" and "The International Cooperation for the Integration of
 *    Processes in  Prepress, Press and Postpress" must
 *    not be used to endorse or promote products derived from this
 *    software without prior written permission. For written
 *    permission, please contact info@cip4.org.
 *
 * 5. Products derived from this software may not be called "CIP4",
 *    nor may "CIP4" appear in their name, without prior writtenrestartProcesses()
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
 * SPECIAL, EXEMPLARY, OR CONSEQUENTIrSubRefAL DAMAGES (INCLUDING, BUT NOT
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
 * originally based on software restartProcesses()
 * copyright (c) 1999-2001, Heidelberger Druckmaschinen AG
 * copyright (c) 1999-2001, Agfa-Gevaert N.V.
 *
 * For more information on The International Cooperation for the
 * Integration of Processes in  Prepress, Press and Postpress , please see
 * <http://www.cip4.org/>.
 */



namespace org.cip4.jdflib.util
{
   using System;
   using System.IO;
   using System.Collections;


   using ScanfFormat = org.cip4.jdflib.cformat.ScanfFormat;
   using ScanfMatchException = org.cip4.jdflib.cformat.ScanfMatchException;
   using ScanfReader = org.cip4.jdflib.cformat.ScanfReader;
   using VString = org.cip4.jdflib.core.VString;

   ///
   /// <summary> * @author prosirai
   /// *  </summary>
   /// 
   public partial class SScanf : ScanfReader, IEnumerator
   {
      ///   
      ///	 <summary> * creates a scanf reader for a given string and format and returns the approriate object
      ///	 * 
      ///	 * valid format identifiers %f - returns Double %i - returns Integer %d - returns Integer %x - returns Integer %o -
      ///	 * returns Integer %c - returns String %s - returns String
      ///	 *  </summary>
      ///	 * <param name="theString"> the String to scan </param>
      ///	 * <param name="format"> the formatting String to apply according to c++ sscanf rools </param>
      ///	 
      private ArrayList vFmt;
      private int pos = 0;

      public SScanf(string theString, string format)
         : base(new StringReader(theString))
      {
         string newFMT = StringUtil.replaceString(format, "%%", "__comma__€ß-eher selten");
         vFmt = StringUtil.tokenize(newFMT, "%", false);
         int siz = vFmt.Count;
         // make sure we have exactly 1 element per "real" %
         string firstChar = "%";
         if (siz > 1 && !format.StartsWith("%"))
         {
            vFmt[1] = vFmt[0] + "%" + vFmt[1];
            vFmt.RemoveAt(0);
            siz--;
            firstChar = "";
         }
         for (int i = 0; i < siz; i++)
         {
            string fmtString = (string)vFmt[i];
            fmtString = StringUtil.replaceString(fmtString, "__comma__€ß-eher selten", "%%");
            vFmt[i] = firstChar + fmtString;
            firstChar = "%";
         }

      }

      ///   
      ///	 <summary> * scan a string using C++ sscanf functionality
      ///	 *  </summary>
      ///	 * <param name="theString"> the string to scan </param>
      ///	 * <param name="format"> the format to scan, see C++ spec for details </param>
      ///	 
      public virtual ArrayList sscanf()
      {
         ArrayList v = new ArrayList();
         while (MoveNext())
            v.Add(next());
         return v;
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.cformat.ScanfReader#scanDouble(org.cip4.jdflib.cformat .ScanfFormat)
      //	 
      public override double scanDouble(ScanfFormat fmt)
      {
         if ("dxoi".IndexOf((char)fmt.type) >= 0) // also gracefully handle int as
            // double
            return scanLong(fmt);
         return base.scanDouble(fmt);
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.cformat.ScanfReader#scanString(org.cip4.jdflib.cformat .ScanfFormat)
      //	 
      public override string scanString(ScanfFormat fmt)
      {
         if ("di".IndexOf((char)fmt.type) >= 0) // also gracefully handle int as double
            return Convert.ToString(scanLong(fmt), 10);
         if ("o".IndexOf((char)fmt.type) >= 0) // also gracefully handle int as double
            return Convert.ToString(scanLong(fmt), 8);
         if ("x".IndexOf((char)fmt.type) >= 0) // also gracefully handle int as double
            return Convert.ToString(scanLong(fmt), 16);
         if ("f".IndexOf((char)fmt.type) >= 0) // also gracefully handle int as double
            return Convert.ToString(scanDouble(fmt));
         if ("c".IndexOf((char)fmt.type) >= 0) // also gracefully handle int as double
            return new string(scanChars(fmt));
         return base.scanString(fmt);
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see java.util.Iterator#hasNext()
      //	 
      public virtual bool MoveNext()
      {
         return pos < vFmt.Count;
      }

      ///   
      ///	 * returns the next Object (<seealso cref= the constructor), null if the string has been completely parsed or an invalid
      ///	 * format is scanned </seealso>
      ///	 
      private object next()
      {
         if (!MoveNext())
            return null;
         string fmtString = (string)vFmt[pos++];
         ScanfFormat fmt = new ScanfFormat(fmtString);
         try
         {
            if ("dxoi".IndexOf((char)fmt.type) >= 0)
               return scanInt(fmt); //new int(scanInt(fmt));
            if ("f".IndexOf((char)fmt.type) >= 0)
               return scanDouble(fmt); // new double(scanDouble(fmt));
            return scanString(fmt);
         }
         catch (ArgumentException)
         {
            pos = 999999;
            return null;
         }
         catch (IOException)
         {
            pos = 999999;
            return null;
         }

      }

      public object Current
      {
         get { return next(); }
      }

      public void Reset()
      {
         pos = 0;
      }

      ///   
      ///	 <summary> * NOT IMPLEMENTED - the iterator is only forward
      ///	 *  </summary>
      ///	 * <seealso cref= java.util.Iterator#remove() </seealso>
      ///	 
      public virtual void remove()
      {
         throw new ArgumentException("remove not implemented!");

      }

      ///   
      ///	 <summary> * convenience static function - see the constructor for details
      ///	 *  </summary>
      ///	 * <param name="theString"> </param>
      ///	 * <param name="format"> </param>
      ///	 * <returns> Vector of scanned objects - see constructor for details </returns>
      ///	 
      public static ArrayList sscanf(string theString, string format)
      {
         return new SScanf(theString, format).sscanf();
      }
   }
}
