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
 * JDFContact.cs
 * Last changes
 * 2002-07-02 JG added support for extended ContactTypes
 */

namespace org.cip4.jdflib.resource.process
{
   using System;
   using System.Collections;


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   using JDFAutoContact = org.cip4.jdflib.auto.JDFAutoContact;
   using EnumChannelType = org.cip4.jdflib.auto.JDFAutoComChannel.EnumChannelType;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using VString = org.cip4.jdflib.core.VString;


   public class JDFContact : JDFAutoContact
   {
      private new const long serialVersionUID = 1L;

      public sealed class EnumContactType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumContactType(string name)
            : base(name, m_startValue++)
         {
         }

         ///      
         ///		 * <param name="enumName">
         ///		 *            the name of the enum object to return </param>
         ///		 * <returns> the enum object if enumName is valid. Otherwise null </returns>
         ///		 
         public static EnumContactType getEnum(string enumName)
         {
            return (EnumContactType)getEnum(typeof(EnumContactType), enumName);
         }

         ///      
         ///		 * <param name="enumValue">
         ///		 *            the value of the enum object to return </param>
         ///		 * <returns> the enum object if enumName is valid. Otherwise null </returns>
         ///		 
         public static EnumContactType getEnum(int enumValue)
         {
            return (EnumContactType)getEnum(typeof(EnumContactType), enumValue);
         }

         ///      
         ///		 * <returns> a map of all EnumContactType enums </returns>
         ///		 
         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumContactType));
         }

         ///      
         ///		 * <returns> a list of all EnumContactType enums </returns>
         ///		 
         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumContactType));
         }

         ///      
         ///		 * <returns> an iterator over the enum objects </returns>
         ///		 
         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumContactType));
         }

         public static readonly EnumContactType Accounting = new EnumContactType("Accounting");
         public static readonly EnumContactType Administrator = new EnumContactType("Administrator");
         public static readonly EnumContactType Approver = new EnumContactType("Approver");
         public static readonly EnumContactType ArtReturn = new EnumContactType("ArtReturn");
         public static readonly EnumContactType Billing = new EnumContactType("Billing");
         public static readonly EnumContactType Customer = new EnumContactType("Customer");
         public static readonly EnumContactType Delivery = new EnumContactType("Delivery");
         public static readonly EnumContactType DeliveryCharge = new EnumContactType("DeliveryCharge");
         public static readonly EnumContactType Owner = new EnumContactType("Owner");
         public static readonly EnumContactType Pickup = new EnumContactType("Pickup");
         public static readonly EnumContactType Sender = new EnumContactType("Sender");
         public static readonly EnumContactType Supplier = new EnumContactType("Supplier");
         public static readonly EnumContactType SurplusReturn = new EnumContactType("SurplusReturn");
      }

      ///   
      ///	 <summary> * Constructor for JDFContact
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFContact(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFContact
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFContact(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFContact
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="localName"> </param>

      ///	 
      public JDFContact(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
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
         return "JDFContact[  --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * Set attribute ContactTypes
      ///	 *  </summary>
      ///	 * @deprecated use getContactTypes 
      ///	 *<param name="vKString">
      ///	 *            value: the value to set the attribute to </param>
      ///	 
      [Obsolete("use getContactTypes")]
      public virtual void setExtendedContactTypes(VString @value)
      {
         setContactTypes(@value);
      }

      ///   
      ///	 <summary> * Get string attribute ContactTypes
      ///	 *  </summary>
      ///	 * @deprecated use setContactTypes 
      ///	 * <returns> vKString the vaue of the attribute </returns>
      ///	 
      [Obsolete("use setContactTypes")]
      public virtual VString getExtendedContactTypes()
      {
         return getContactTypes();
      }

      ///   
      ///	 * <param name="typ">
      ///	 *            the single contacttype to set this contact to </param>
      ///	 
      public virtual void setContactTypes(EnumContactType typ)
      {
         if (typ == null)
            removeAttribute(AttributeName.CONTACTTYPES);
         else
            setAttribute(AttributeName.CONTACTTYPES, typ.getName(), null);

      }

      ///   
      ///	 * <param name="typ">
      ///	 *            the single contacttype to set this contact to </param>
      ///	 
      public virtual void addContactTypes(EnumContactType typ)
      {
         if (typ != null)
            appendAttribute(AttributeName.CONTACTTYPES, typ.getName(), null, " ", true);

      }

      ///   
      ///	 <summary> * append a comChannel with a given channelType
      ///	 *  </summary>
      ///	 * <param name="channelType">
      ///	 * @return </param>
      ///	 
      public virtual JDFComChannel appendComChannel(EnumChannelType channelType)
      {
         JDFComChannel comCh = appendComChannel();
         comCh.setChannelType(channelType);
         return comCh;
      }

      ///   
      ///	 * <param name="firstName"> </param>
      ///	 * <param name="familyName"> </param>
      ///	 
      public virtual JDFPerson setPerson(string firstName, string familyName)
      {
         JDFPerson p = null;
         if (firstName != null || familyName != null)
         {
            p = getCreatePerson();
            p.setFirstName(firstName);
            p.setFamilyName(familyName);
         }
         return p;
      }
   }
}
