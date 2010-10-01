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
 * THIS SOFTWARE IS PROVIDED `AS IS'' AND ANY EXPRESSED OR IMPLIED
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



//--------------------------------------------------------------------------------------------------
//Titel:        org.cip4.jdflib.util
//Version:
//Copyright:    Copyright (c) 1999
//Autor:       sabine Jonas
//Firma:      BUGH-Wuppertal
//Beschreibung:  Utility library for the JDF library
namespace org.cip4.jdflib.util
{
   using System;
   using System.Collections;
   using System.Globalization;


   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using VString = org.cip4.jdflib.core.VString;

   public class MyArgs
   {

      // Variables
      private string m_usageTable;
      private VString m_onlyArgs;
      private string m_switchParameterString;
      private string m_argumentParameterString;
      private string m_requiredParameterString;
      private readonly SupportClass.HashSetSupport m_flags = new SupportClass.HashSetSupport();
      private readonly Hashtable m_Parameters = new Hashtable();
      private VString m_argV;

      // cmd-line has or has not args and not only options( starting with "-" )

      // Construction

      ///   
      ///	 <summary> * @deprecated </summary>
      ///	 
      [Obsolete]
      public MyArgs(string[] argv, string switchParameterString, string argumentParameterString)
      {
         initMyArgs(argv, switchParameterString, argumentParameterString, null);
      }

      public MyArgs(string[] argv, string switchParameterString, string argumentParameterString, string requiredParameterString)
      {
         initMyArgs(argv, switchParameterString, argumentParameterString, requiredParameterString);
      }

      private void initMyArgs(string[] argv, string strSwitchParameter, string strArgumentParameter, string strRequiredParameter)
      {
         string[] argvLocal = argv;

         if (argvLocal == null)
            argvLocal = new string[0];

         m_switchParameterString = strSwitchParameter;
         m_argumentParameterString = strArgumentParameter;
         m_requiredParameterString = strRequiredParameter;

         m_argV = new VString(argvLocal);
         m_onlyArgs = new VString();

         // cut of the "-" from the options, but don't remove it from file names
         for (int i = 0; i < argvLocal.Length; i++)
         {
            string tempString = argvLocal[i];
            if (tempString.StartsWith("-"))
            {
               string whazzLeft = tempString.Substring(1);
               while (whazzLeft.Length > 0)
               {
                  string flag = whazzLeft.Substring(0, 1);
                  if (m_switchParameterString != null && m_switchParameterString.IndexOf(flag) >= 0)
                  {
                     m_flags.Add(flag);
                     whazzLeft = whazzLeft.Substring(1);
                  }
                  else if (m_argumentParameterString != null && m_argumentParameterString.IndexOf(flag) >= 0)
                  {
                     string wl2 = whazzLeft.Substring(1);
                     if (wl2.Length == 0 && argvLocal.Length > i + 1)
                     {
                        wl2 = argvLocal[i + 1];
                        i++;
                     }
                     m_Parameters.Add(flag, wl2);
                     whazzLeft = "";
                  }
                  else
                  {
                     // oops... don't know it; skip it
                     whazzLeft = whazzLeft.Substring(1);
                     if (!flag.Equals("-"))
                        Console.WriteLine("unknown flag:" + flag);
                  }
               }
            }
            else
            {
               m_onlyArgs.Add(tempString);
            }

         }
      }

      public override string ToString()
      {
         string s = "\n\tMyArgs: \n";
         s += "\t\t switchParameterString=" + m_switchParameterString + "\n";
         s += "\t\t argumentParameterString=" + m_argumentParameterString + "\n";
         s += "\t\t requiredParameterString=" + m_requiredParameterString + "\n";
         s += "\t\t argC    =" + m_argV.Count + "\n";
         s += "\t\t argV    =" + m_argV + "\n";
         s += "\t\t Nargs   =" + nargs() + "\n";
         s += "\t\t Flags:  =";
         IEnumerator it = m_flags.GetEnumerator();
         while (it.MoveNext())
            s += it.Current + ", ";
         s += "\n";
         it = m_Parameters.Keys.GetEnumerator();
         s += "\t\t Parameters: \n";
         while (it.MoveNext())
         {
            string key = (string)it.Current;
            s += "\t\t\t " + key + " = " + (string)m_Parameters[key] + "\n";
         }
         s += "\t\t onlyArgs=" + m_onlyArgs + "\n";

         return s += "\n";
      }

      // Methods

      public virtual string parameter(string c)
      {
         return parameter(c[0]);
      }


      public virtual string parameter(char c)
      {
         string s = "";
         s += c;
         return (string)m_Parameters[s];
      }

      public virtual string parameterString(string s)
      {
         return parameterString(s[0]);
      }

      public virtual string parameterString(char c)
      {
         return parameter(c);
      }


      public virtual int nargs()
      {
         return m_onlyArgs.Count;
      }

      public virtual string argument(int m)
      {

         if (m >= nargs())
         {
            return null;
         }
         return m_onlyArgs.stringAt(m);
      }

      ///   
      ///	 * <param name="m"> </param>
      ///	 * <returns> default: ArgumentString(0) </returns>
      ///	 
      public virtual string argumentString(int m)
      {
         return argument(m);
      }

      ///   
      ///	 <summary> * convert character to interger
      ///	 *  </summary>
      ///	 * <param name="c"> </param>
      ///	 * <param name="defaultValue"> </param>
      ///	 * <param name="radix"> </param>
      ///	 * <returns> default: IntParameter(c + JDFConstants.EMPTYSTRING, 0, 10) </returns>
      ///	 
      public virtual int intParameter(char c, int defaultValue, int radix)
      {
         return intParameter(c + JDFConstants.EMPTYSTRING, defaultValue, radix);
      }

      ///   
      ///	 * <param name="c"> </param>
      ///	 * <param name="defaultValue"> </param>
      ///	 * <param name="radix"> </param>
      ///	 * <returns> default: IntParameter(s + JDFConstants.EMPTYSTRING, 0, 10) </returns>
      ///	 
      public virtual int intParameter(string s, int defaultValue, int radix)
      {

         string paramString = parameter(s);
         try
         {
            return Convert.ToInt32(paramString, radix);
         }
         catch (FormatException)
         {
            Console.WriteLine("WARNING: Int-Parameter[" + s + "] has no Int-Argument" + " or does not exist (= [" + paramString + "] ) ==> use default value: " + defaultValue);
            return defaultValue;
         }
      }

      ///   
      ///	 <summary> * convert character to double
      ///	 *  </summary>
      ///	 * <param name="c"> </param>
      ///	 * <param name="defaultValue"> </param>
      ///	 * <returns> default: FloatParameter(JDFConstants.EMPTYSTRING + c, 0) </returns>
      ///	 
      public virtual double floatParameter(char c, double defaultValue)
      {
         return floatParameter(JDFConstants.EMPTYSTRING + c, defaultValue);
      }

      ///   
      ///	 * <param name="c"> </param>
      ///	 * <param name="defaultValue"> </param>
      ///	 * <returns> default: FloatParameter(JDFConstants.EMPTYSTRING + s, 0) </returns>
      ///	 
      public virtual double floatParameter(string s, double defaultValue)
      {

         string paramString = parameter(s);
         try
         {
            return Double.Parse(paramString, CultureInfo.InvariantCulture);
         }
         catch (FormatException)
         {
            Console.WriteLine("WARNING: Float-Parameter[" + s + "] has no Double-Argument" + " or does not exist (= [" + paramString + "] ) ==> use default value: " + defaultValue);
            return defaultValue;
         }
      }

      ///   
      ///	 <summary> * convert character to boolean
      ///	 *  </summary>
      ///	 * <param name="c"> </param>
      ///	 * <param name="defaultValue"> </param>
      ///	 * <returns> default: BoolParameter(c + JDFConstants.EMPTYSTRING, false) </returns>
      ///	 
      public virtual bool boolParameter(char c, bool defaultValue)
      {
         return boolParameter(c + JDFConstants.EMPTYSTRING, defaultValue);
      }

      ///   
      ///	 * <param name="s"> </param>
      ///	 * <param name="defaultValue"> </param>
      ///	 * <returns> default: BoolParameter(s + JDFConstants.EMPTYSTRING, false) </returns>
      ///	 
      public virtual bool boolParameter(string s, bool defaultValue)
      {
         return m_flags.Contains(s) ? true : defaultValue;
      }

      ///   
      ///	 * <param name="paramString"> </param>
      ///	 * <returns> default: Usage(JDFConstants.EMPTYSTRING) </returns>
      ///	 
      public virtual string usage(string paramString)
      {
         m_usageTable = "\n.\n.\n.usage: ";
         if (m_argV.Count > 0)
            m_usageTable += m_argV.stringAt(0);

         if (m_switchParameterString != null)
         {
            m_usageTable += "\n\t switches:   -" + m_switchParameterString;
         }
         if (m_argumentParameterString != null)
         {
            m_usageTable += "\n\t Parameters: -" + m_argumentParameterString;
         }
         if (m_requiredParameterString != null)
         {
            m_usageTable += "\n\t Required:   -" + m_requiredParameterString;
         }

         m_usageTable += "\n\t Argument(s)\n";

         if (paramString.Length != 0)
         {
            m_usageTable += "\n" + paramString + "\n";
         }

         m_usageTable += "\n.\n.\n.\n";

         return m_usageTable;
      }

      ///   
      ///	 <summary> * return true if either a flag or parameter for c is set
      ///	 *  </summary>
      ///	 * <param name="c"> the char to test for
      ///	 * @return </param>
      ///	 
      public virtual bool hasParameter(char c)
      {
         return (m_switchParameterString != null && m_switchParameterString.IndexOf(c) > -1 && m_flags.Contains("" + c)) || (parameter(c) != null);
      }
   }
}
