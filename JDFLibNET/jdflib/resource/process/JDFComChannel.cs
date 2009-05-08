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
 * JDFComChannel.cs
 * Last changes
 */

namespace org.cip4.jdflib.resource.process
{
   using System;
   using System.Collections;


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   using JDFAutoComChannel = org.cip4.jdflib.auto.JDFAutoComChannel;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using StringUtil = org.cip4.jdflib.util.StringUtil;

   public class JDFComChannel : JDFAutoComChannel
   {
      private new const long serialVersionUID = 1L;
      public const string MAILTO = "mailto:";
      public const string TEL = "tel:";

      public class EnumChannelTypeDetails : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumChannelTypeDetails(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumChannelTypeDetails getEnum(string enumName)
         {
            return (EnumChannelTypeDetails)getEnum(typeof(EnumChannelTypeDetails), enumName);
         }

         public static EnumChannelTypeDetails getEnum(int enumValue)
         {
            return (EnumChannelTypeDetails)getEnum(typeof(EnumChannelTypeDetails), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumChannelTypeDetails));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumChannelTypeDetails));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumChannelTypeDetails));
         }

         ///      
         ///		 <summary> * @deprectated - use null </summary>
         ///		 
         public static readonly EnumChannelTypeDetails Unknown = new EnumChannelTypeDetails("Unknown");
         public static readonly EnumChannelTypeDetails LandLine = new EnumChannelTypeDetails("LandLine");
         public static readonly EnumChannelTypeDetails Mobile = new EnumChannelTypeDetails("Mobile");
         public static readonly EnumChannelTypeDetails Secure = new EnumChannelTypeDetails("Secure");
         public static readonly EnumChannelTypeDetails ISDN = new EnumChannelTypeDetails("ISDN");
         public static readonly EnumChannelTypeDetails Form = new EnumChannelTypeDetails("Form");
         public static readonly EnumChannelTypeDetails Target = new EnumChannelTypeDetails("Target");
      }

      ///   
      ///	 <summary> * Constructor for JDFComChannel
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFComChannel(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFComChannel
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFComChannel(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFComChannel
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="localName"> </param>
      ///	 
      public JDFComChannel(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
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
         return "JDFComChannel[  --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * sets locator to the string specified in eMail, checking valid email
      ///	 * syntax "mailto:" is prepended, if it is not yet there
      ///	 *  </summary>
      ///	 * <param name="eMail">
      ///	 *            the email address </param>
      ///	 * <exception cref="IllegalArgumentException">
      ///	 *             if eMail is not a valid emai as defined by
      ///	 *             JDFConstants.REGEXP_EMAIL </exception>
      ///	 
      public virtual void setEMailLocator(string eMail)
      {
         string eMailLocal = eMail;

         if (eMailLocal != null)
            eMailLocal = eMailLocal.Trim();

         if (eMailLocal == null || !StringUtil.matchesIgnoreCase(eMailLocal, JDFConstants.REGEXP_EMAIL))
         {
            throw new ArgumentException("illegal email address:" + eMailLocal);
         }

         setChannelType(EnumChannelType.Email);
         if (!eMailLocal.ToLower().StartsWith(MAILTO))
            eMailLocal = MAILTO + eMailLocal;

         setLocator(eMailLocal);
      }

      ///   
      ///	 <summary> * get the email address of this, if this is an email address, else null any
      ///	 * "mailto" is stripped
      ///	 * 
      ///	 * @return </summary>
      ///	 
      public virtual string getEMailAddress()
      {
         if (!EnumChannelType.Email.Equals(getChannelType()))
            return null;
         string locator = getLocator();
         if (!StringUtil.matchesIgnoreCase(locator, JDFConstants.REGEXP_EMAIL))
            return null;
         return StringUtil.stripPrefix(locator, MAILTO, true);
      }

      ///   
      ///	 <summary> * get the phone number of this, if this is a valid phone address, else null
      ///	 * any "tel:" or "fax:" is stripped
      ///	 *  </summary>
      ///	 * <param name="stripNonNumerical">
      ///	 *            if true, remove any valid brackets, . / etc. so that a purely
      ///	 *            numerical code (except for an optional "+" for international)
      ///	 *            is returned </param>
      ///	 * <returns> the phone number </returns>
      ///	 
      public virtual string getPhoneNumber(bool stripNonNumerical)
      {
         EnumChannelType channelType = getChannelType();
         if (!EnumChannelType.Fax.Equals(channelType) && !EnumChannelType.Phone.Equals(channelType))
            return null;
         string locator = getLocator();
         if (!StringUtil.matchesIgnoreCase(locator, JDFConstants.REGEXP_PHONE))
            return null;
         locator = StringUtil.stripPrefix(locator, TEL, true);
         if (stripNonNumerical)
            locator = StringUtil.stripNot(locator, "+0123456789");
         return locator;
      }

      ///   
      ///	 <summary> * set the phone number of this, if this is a valid phone url, "tel:" or
      ///	 * "fax:" is prepended, if it is not yet there
      ///	 *  </summary>
      ///	 * <param name="phone">
      ///	 *            the phone number string </param>
      ///	 * <param name="replaceForBlank">
      ///	 *            the replacement char for non-leading blanks , typically "." or
      ///	 *            null are a good idea </param>
      ///	 * <param name="channelType">
      ///	 *            the channelType - must be either Fax or Phone </param>
      ///	 * <exception cref="IllegalArgumentException">
      ///	 *             if phone is not a valid phone number
      ///	 *  </exception>
      ///	 
      public virtual void setPhoneNumber(string phone, string replaceForBlank, EnumChannelType channelType)
      {
         string phoneLocal = phone;

         if (!EnumChannelType.Fax.Equals(channelType) && !EnumChannelType.Phone.Equals(channelType))
            throw new ArgumentException("illegal channelType: " + channelType);

         if (phoneLocal != null)
            phoneLocal = phoneLocal.Trim();

         phoneLocal = StringUtil.replaceCharSet(phoneLocal, " ", replaceForBlank, 0);
         if (phoneLocal == null || !StringUtil.matches(phoneLocal, JDFConstants.REGEXP_PHONE))
         {
            throw new ArgumentException("illegal phone number:" + phoneLocal);
         }

         setChannelType(channelType);
         if (!phoneLocal.ToLower().StartsWith(TEL))
            phoneLocal = TEL + phoneLocal;

         setLocator(phoneLocal);
      }
   }
}
