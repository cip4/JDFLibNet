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



//JAVA TO VB & C# CONVERTER NOTE: Beginning of line comments are not maintained by Java to VB & C# Converter
//ORIGINAL LINE: *//**
 /*
 * Copyright (c) 2001 Heidelberger Druckmaschinen AG, All Rights Reserved.
 *
 * JDFUsageCounter.cs
 *
 * Last changes
 */

namespace org.cip4.jdflib.resource.process
{
   using System.Collections;
   using System.Collections.Generic;


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   using JDFAutoUsageCounter = org.cip4.jdflib.auto.JDFAutoUsageCounter;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using StringUtil = org.cip4.jdflib.util.StringUtil;

   using VString = org.cip4.jdflib.core.VString;

   public class JDFUsageCounter : JDFAutoUsageCounter
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFUsageCounter
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFUsageCounter(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFUsageCounter
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFUsageCounter(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFUsageCounter
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="localName"> </param>

      ///	 
      public JDFUsageCounter(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      // **************************************** Methods
      // *********************************************
      ///   
      ///	 <summary> * toString
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public override string ToString()
      {
         return "JDFUsageCounter[  --> " + base.ToString() + " ]";
      }

      public class EnumCounterType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumCounterType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumCounterType getEnum(string enumName)
         {
            return (EnumCounterType)getEnum(typeof(EnumCounterType), enumName);
         }

         public static EnumCounterType getEnum(int enumValue)
         {
            return (EnumCounterType)getEnum(typeof(EnumCounterType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumCounterType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumCounterType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumCounterType));
         }

         public static readonly EnumCounterType Blank = new EnumCounterType("Blank");
         public static readonly EnumCounterType Insert = new EnumCounterType("Insert");
         public static readonly EnumCounterType InsertPrefuser = new EnumCounterType("InsertPrefuser");
         public static readonly EnumCounterType OneSided = new EnumCounterType("OneSided");
         public static readonly EnumCounterType TwoSided = new EnumCounterType("TwoSided");
         public static readonly EnumCounterType NormalSize = new EnumCounterType("NormalSize");
         public static readonly EnumCounterType LargeSize = new EnumCounterType("LargeSize");
         public static readonly EnumCounterType Black = new EnumCounterType("Black");
         public static readonly EnumCounterType HighlightColor = new EnumCounterType("HighlightColor");
         public static readonly EnumCounterType Color = new EnumCounterType("Color");
         public static readonly EnumCounterType Separation = new EnumCounterType("Separation");
         public static readonly EnumCounterType Varnish = new EnumCounterType("Varnish");
         public static readonly EnumCounterType User = new EnumCounterType("User");
         public static readonly EnumCounterType Auxiliary = new EnumCounterType("Auxiliary");
         public static readonly EnumCounterType Impressions = new EnumCounterType("Impressions");
         public static readonly EnumCounterType Clicks = new EnumCounterType("Clicks");
         public static readonly EnumCounterType pt = new EnumCounterType("pt");
      }

      //   
      //	 * ---------------------------------------------------------------------
      //	 * Methods for Attribute CounterTypes
      //	 * ---------------------------------------------------------------------
      //	 
      ///   
      ///	 <summary> * (5) set attribute CounterTypes
      ///	 *  </summary>
      ///	 * <param name="enumVar">
      ///	 *            : the enumVar to set the attribute to </param>
      ///	 
      public virtual void setCounterTypes(EnumCounterType enumVar)
      {
         setAttribute(AttributeName.COUNTERTYPES, enumVar.getName(), null);
      }

      ///   
      ///	 <summary> * (5) set attribute CounterTypes
      ///	 *  </summary>
      ///	 * <param name="enumVar">
      ///	 *            : the enumVar to set the attribute to </param>
      ///	 
      public virtual void setCounterTypes(ArrayList vVar)
      {
         string s = StringUtil.setvString(new VString(vVar));
         setAttribute(AttributeName.COUNTERTYPES, s, null);
      }

      ///   
      ///	 <summary> * (9) get attribute Scope
      ///	 *  </summary>
      ///	 * <returns> the value of the attribute </returns>
      ///	 
      public virtual List<ValuedEnum> getEnumCounterTypes()
      {
         return getEnumerationsAttribute(AttributeName.COUNTERTYPES, null, EnumCounterType.Auxiliary, false);
      }

      ///   
      ///	 <summary> * also checks for matchin counterID or CounteType mangled with "_", e.g.
      ///	 * UsageCounter:ID_CounterA UsageCounter:Black_SingleSided etc. </summary>
      ///	 
      public override bool matchesString(string namedResLink)
      {
         if (namedResLink == null)
            return false;
         string counterID = getCounterID();
         if (!isWildCard(counterID))
         {
            string idString = LocalName + ":" + counterID;
            if (idString.Equals(namedResLink))
               return true;
         }
         string ct = StringUtil.setvString(getCounterTypes(), "_", null, null);
         if (!isWildCard(ct) && namedResLink.Equals(LocalName + ":" + ct))
            return true;
         return base.matchesString(namedResLink);
      }
   }
}
