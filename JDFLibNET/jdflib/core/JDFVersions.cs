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
 * Copyright (c) 2005 Heidelberger Druckmaschinen AG, All Rights Reserved.
 * JDFVersions.cs
 * Created on Feb 9, 2005 by funkevol
 * 09022005 VF initial version 
 */

namespace org.cip4.jdflib.core
{
   using System;


   using EnumVersion = org.cip4.jdflib.core.JDFElement.EnumVersion;

   ///
   /// <summary> * @author funkevol
   /// * 
   /// *         TODO To change the template for this generated type comment go to Window - Preferences - Java - Code Style -
   /// *         Code Templates </summary>
   /// 
   public class JDFVersions
   {

      private static bool forceVersion = false; // if true, force all checks to
      // defaultversion
      private static JDFVersion[] jdfVersions = new JDFVersion[6];

      static JDFVersions()
      {
         jdfVersions[0] = new JDFVersion(EnumVersion.Version_1_0, 0x0000000FL, 0L);
         jdfVersions[1] = new JDFVersion(EnumVersion.Version_1_1, 0x000000F0L, 4L);
         jdfVersions[2] = new JDFVersion(EnumVersion.Version_1_2, 0x00000F00L, 8L);
         jdfVersions[3] = new JDFVersion(EnumVersion.Version_1_3, 0x0000F000L, 12L);
         jdfVersions[4] = new JDFVersion(EnumVersion.Version_1_4, 0x000F0000L, 16L);
         jdfVersions[5] = new JDFVersion(EnumVersion.Version_1_5, 0x00F00000L, 20L);
      }

      ///   
      ///	 <summary> * Returns the default JDF version.
      ///	 *  </summary>
      ///	 * @deprecated use JDFElement.getDefaultJDFVersion() 
      ///	 * <returns> String: JDF version string </returns>
      ///	 
      [Obsolete("use JDFElement.getDefaultJDFVersion()")]
      public static int getDefaultVersion()
      {
         return JDFElement.getDefaultJDFVersion().getValue() - 1;
      }

      ///   
      ///	 <summary> * Sets the default JDF version.
      ///	 *  </summary>
      ///	 * @deprecated use JDFElement.setDefaultJDFVersion(v); 
      ///	 * <returns> String: JDF version string </returns>
      ///	 
      [Obsolete("use JDFElement.setDefaultJDFVersion(v);")]
      public static void setDefaultVersion(EnumVersion v)
      {
         JDFElement.setDefaultJDFVersion(v);
      }


      /// <summary>
      /// Get/Set the JDF version that all checks are forced to.
      /// </summary>
      public static bool ForceVersion
      {
         get { return forceVersion; }
         set { forceVersion = value; }
      }

      ///   
      ///	 <summary> * getTheMask
      ///	 *  </summary>
      ///	 * <param name="v"> the version to look for </param>
      ///	 * <returns> Returns the bit mask for isolating the appropriate validity bits. </returns>
      ///	 
      public static long getTheMask(EnumVersion v)
      {
         return jdfVersions[getIndexFromVersion(v)].validityMask;
      }

      ///   
      ///	 <summary> * getTheOffset
      ///	 *  </summary>
      ///	 * <param name="v"> </param>
      ///	 * <returns> Returns the theOffset. </returns>
      ///	 
      public static long getTheOffset(EnumVersion v)
      {
         return jdfVersions[getIndexFromVersion(v)].validityOffset;
      }

      ///   
      ///	 <summary> * getIndexFromVersion
      ///	 *  </summary>
      ///	 * <param name="v">
      ///	 * @return </param>
      ///	 
      private static int getIndexFromVersion(EnumVersion v)
      {
         int i = v.getValue();
         if (forceVersion || (i <= 0) || (i > jdfVersions.Length))
         {
            i = JDFElement.getDefaultJDFVersion().getValue();
         }

         i--; // must be removed if unknown is removed
         return i;
      }

      private class JDFVersion
      {
         public EnumVersion version;
         public long validityMask;
         public long validityOffset;

         protected internal JDFVersion(EnumVersion v, long m, long o)
         {
            version = v;
            validityMask = m;
            validityOffset = o;
         }

         public override string ToString()
         {
            string s = "Version: " + version.getName();
            s += "; ValidityMask: " + Convert.ToString(validityMask, 16); // long.toHexString(validityMask);
            s += "; ValidityOffset: " + validityOffset;

            return s;
         }
      }
   }
}
