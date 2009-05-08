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



/*
 * Copyright (c) 2001 Heidelberger Druckmaschinen AG, All Rights Reserved.
 * JDFArtDelivery.cs
 * Last changes
 */

namespace org.cip4.jdflib.resource.intent
{


   using JDFAutoArtDelivery = org.cip4.jdflib.auto.JDFAutoArtDelivery;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFContact = org.cip4.jdflib.resource.process.JDFContact;
   using JDFNameSpan = org.cip4.jdflib.span.JDFNameSpan;
   using JDFSpanArtHandling = org.cip4.jdflib.span.JDFSpanArtHandling;
   using JDFSpanDeliveryCharge = org.cip4.jdflib.span.JDFSpanDeliveryCharge;
   using JDFSpanTransfer = org.cip4.jdflib.span.JDFSpanTransfer;
   using JDFStringSpan = org.cip4.jdflib.span.JDFStringSpan;


   public class JDFArtDelivery : JDFAutoArtDelivery
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFArtDelivery
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFArtDelivery(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFArtDelivery
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFArtDelivery(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFArtDelivery
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="localName"> </param>

      ///	 
      public JDFArtDelivery(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
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
         return "JDFArtDelivery[  --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * Get parent node of 'this' - node ArtDeliveryIntent
      ///	 *  </summary>
      ///	 * <returns> JDFArtDeliveryIntent: ArtDeliveryIntent node </returns>
      ///	 
      public virtual JDFArtDeliveryIntent getParentArtDeliveryIntent()
      {
         return (JDFArtDeliveryIntent)ParentNode;
      }

      ///   
      ///	 <summary> * Get of 'this' the value of element ArtHandling. If not specified, get the
      ///	 * default value of element ArtHandling, that is specified in it's parent
      ///	 * element (node ArtDeliveryIntent)
      ///	 *  </summary>
      ///	 * <returns> JDFSpanArtHandling: element value </returns>
      ///	 
      public override JDFSpanArtHandling getArtHandling()
      {
         if (hasChildElement(ElementName.ARTHANDLING, null))
         {
            return base.getArtHandling();
         }
         return getParentArtDeliveryIntent().getArtHandling();
      }

      ///   
      ///	 <summary> * Get of 'this' the value of element DeliveryCharge. If not specified, get
      ///	 * the default value of element DeliveryCharge, that is specified in it's
      ///	 * parent element (node ArtDeliveryIntent)
      ///	 *  </summary>
      ///	 * <returns> JDFSpanDeliveryCharge: element value </returns>
      ///	 
      public override JDFSpanDeliveryCharge getDeliveryCharge()
      {
         if (hasChildElement(ElementName.DELIVERYCHARGE, null))
         {
            return base.getDeliveryCharge();
         }
         return getParentArtDeliveryIntent().getDeliveryCharge();
      }

      ///   
      ///	 <summary> * Get of 'this' the value of element Method. If not specified, get the
      ///	 * default value of element Method, that is specified in it's parent element
      ///	 * (node ArtDeliveryIntent)
      ///	 *  </summary>
      ///	 * <returns> JDFNameSpan: element value </returns>
      ///	 
      public override JDFNameSpan getMethod()
      {
         if (hasChildElement(ElementName.METHOD, null))
         {
            return base.getMethod();
         }
         return getParentArtDeliveryIntent().getMethod();
      }

      ///   
      ///	 <summary> * Get of 'this' the value of attribute PreflightStatus. If not specified,
      ///	 * get the default value of attribute PreflightStatus, that is specified in
      ///	 * it's parent element (node ArtDeliveryIntent)
      ///	 *  </summary>
      ///	 * <returns> EnumPreflightStatus: attribute value </returns>
      ///	 
      // TODO this does not work!
      // public JDFArtDelivery.EnumPreflightStatus getPreflightStatus()
      // {
      // if (hasAttribute(AttributeName.PREFLIGHTSTATUS, null, false))
      // {
      // return super.getPreflightStatus();
      // }
      // return getParentArtDeliveryIntent().getPreflightStatus();
      // }
      ///   
      ///	 <summary> * Get of 'this' the value of element ReturnMethod. If not specified, get
      ///	 * the default value of element ReturnMethod, that is specified in it's
      ///	 * parent element (node ArtDeliveryIntent)
      ///	 *  </summary>
      ///	 * <returns> JDFNameSpan: element value </returns>
      ///	 
      public override JDFNameSpan getReturnMethod()
      {
         if (hasChildElement(ElementName.RETURNMETHOD, null))
         {
            return base.getReturnMethod();
         }
         return getParentArtDeliveryIntent().getReturnMethod();
      }

      ///   
      ///	 <summary> * Get of 'this' the value of element ServiceLevel. If not specified, get
      ///	 * the default value of element ServiceLevel, that is specified in it's
      ///	 * parent element (node ArtDeliveryIntent)
      ///	 *  </summary>
      ///	 * <returns> JDFStringSpan: element value </returns>
      ///	 
      public override JDFStringSpan getServiceLevel()
      {
         if (hasChildElement(ElementName.SERVICELEVEL, null))
         {
            return base.getServiceLevel();
         }
         return getParentArtDeliveryIntent().getServiceLevel();
      }

      ///   
      ///	 <summary> * Get of 'this' the value of element Transfer. If not specified, get the
      ///	 * default value of element Transfer, that is specified in it's parent
      ///	 * element (node ArtDeliveryIntent)
      ///	 *  </summary>
      ///	 * <returns> JDFSpanTransfer: element value </returns>
      ///	 
      public override JDFSpanTransfer getTransfer()
      {
         if (hasChildElement(ElementName.TRANSFER, null))
         {
            return base.getTransfer();
         }
         return getParentArtDeliveryIntent().getTransfer();
      }

      ///   
      ///	 <summary> * Get of 'this' the iSkip-th child element Contact. If not specified, get
      ///	 * the child element Contact of it's parent element (node ArtDeliveryIntent)
      ///	 *  </summary>
      ///	 * <returns> JDFContact: the found element </returns>
      ///	 
      public override JDFContact getContact(int iSkip)
      {
         if (hasChildElement(ElementName.CONTACT, JDFConstants.EMPTYSTRING))
         {
            return base.getContact(iSkip);
         }
         return getParentArtDeliveryIntent().getContact();
      }
   }
}
