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




namespace org.cip4.jdflib.auto
{
   using System.Collections;
   using System.Collections.Generic;


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using VString = org.cip4.jdflib.core.VString;
   using JDFArtDelivery = org.cip4.jdflib.resource.intent.JDFArtDelivery;
   using JDFIntentResource = org.cip4.jdflib.resource.intent.JDFIntentResource;
   using JDFCompany = org.cip4.jdflib.resource.process.JDFCompany;
   using JDFContact = org.cip4.jdflib.resource.process.JDFContact;
   using JDFDurationSpan = org.cip4.jdflib.span.JDFDurationSpan;
   using JDFNameSpan = org.cip4.jdflib.span.JDFNameSpan;
   using JDFSpanArtHandling = org.cip4.jdflib.span.JDFSpanArtHandling;
   using JDFSpanDeliveryCharge = org.cip4.jdflib.span.JDFSpanDeliveryCharge;
   using JDFSpanTransfer = org.cip4.jdflib.span.JDFSpanTransfer;
   using JDFStringSpan = org.cip4.jdflib.span.JDFStringSpan;
   using JDFTimeSpan = org.cip4.jdflib.span.JDFTimeSpan;

   public abstract class JDFAutoArtDeliveryIntent : JDFIntentResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[2];
      static JDFAutoArtDeliveryIntent()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.PREFLIGHTSTATUS, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumPreflightStatus.getEnum(0), "NotPerformed");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.RETURNLIST, 0x33333331, AttributeInfo.EnumAttributeType.NMTOKENS, null, "None");
         elemInfoTable[0] = new ElemInfoTable(ElementName.ARTDELIVERYDATE, 0x66666661);
         elemInfoTable[1] = new ElemInfoTable(ElementName.ARTDELIVERYDURATION, 0x66666661);
         elemInfoTable[2] = new ElemInfoTable(ElementName.ARTHANDLING, 0x66666661);
         elemInfoTable[3] = new ElemInfoTable(ElementName.DELIVERYCHARGE, 0x66666661);
         elemInfoTable[4] = new ElemInfoTable(ElementName.METHOD, 0x66666666);
         elemInfoTable[5] = new ElemInfoTable(ElementName.RETURNMETHOD, 0x66666661);
         elemInfoTable[6] = new ElemInfoTable(ElementName.SERVICELEVEL, 0x66666611);
         elemInfoTable[7] = new ElemInfoTable(ElementName.TRANSFER, 0x66666661);
         elemInfoTable[8] = new ElemInfoTable(ElementName.ARTDELIVERY, 0x22222222);
         elemInfoTable[9] = new ElemInfoTable(ElementName.COMPANY, 0x77777776);
         elemInfoTable[10] = new ElemInfoTable(ElementName.CONTACT, 0x33333331);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[11];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoArtDeliveryIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoArtDeliveryIntent(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoArtDeliveryIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoArtDeliveryIntent(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoArtDeliveryIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoArtDeliveryIntent(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      /// <summary>
      /// String representation of this object
      /// </summary>
      /// <returns>string</returns>
      public override string ToString()
      {
         return " JDFAutoArtDeliveryIntent[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for PreflightStatus </summary>
      ///        

      public class EnumPreflightStatus : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumPreflightStatus(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumPreflightStatus getEnum(string enumName)
         {
            return (EnumPreflightStatus)getEnum(typeof(EnumPreflightStatus), enumName);
         }

         public static EnumPreflightStatus getEnum(int enumValue)
         {
            return (EnumPreflightStatus)getEnum(typeof(EnumPreflightStatus), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumPreflightStatus));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumPreflightStatus));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumPreflightStatus));
         }

         public static readonly EnumPreflightStatus NotPerformed = new EnumPreflightStatus("NotPerformed");
         public static readonly EnumPreflightStatus WithErrors = new EnumPreflightStatus("WithErrors");
         public static readonly EnumPreflightStatus WithWarnings = new EnumPreflightStatus("WithWarnings");
         public static readonly EnumPreflightStatus WithoutErrors = new EnumPreflightStatus("WithoutErrors");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute PreflightStatus
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute PreflightStatus </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setPreflightStatus(EnumPreflightStatus enumVar)
      {
         setAttribute(AttributeName.PREFLIGHTSTATUS, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute PreflightStatus </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumPreflightStatus getPreflightStatus()
      {
         return EnumPreflightStatus.getEnum(getAttribute(AttributeName.PREFLIGHTSTATUS, null, "NotPerformed"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ReturnList
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ReturnList </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setReturnList(VString @value)
      {
         setAttribute(AttributeName.RETURNLIST, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute ReturnList </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getReturnList()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.RETURNLIST, null, "None");
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element ArtDeliveryDate </summary>
      ///     * <returns> JDFTimeSpan the element </returns>
      ///     
      public virtual JDFTimeSpan getArtDeliveryDate()
      {
         return (JDFTimeSpan)getElement(ElementName.ARTDELIVERYDATE, null, 0);
      }

      ///     <summary> (25) getCreateArtDeliveryDate
      ///     *  </summary>
      ///     * <returns> JDFTimeSpan the element </returns>
      ///     
      public virtual JDFTimeSpan getCreateArtDeliveryDate()
      {
         return (JDFTimeSpan)getCreateElement_KElement(ElementName.ARTDELIVERYDATE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ArtDeliveryDate </summary>
      ///     
      public virtual JDFTimeSpan appendArtDeliveryDate()
      {
         return (JDFTimeSpan)appendElementN(ElementName.ARTDELIVERYDATE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element ArtDeliveryDuration </summary>
      ///     * <returns> JDFDurationSpan the element </returns>
      ///     
      public virtual JDFDurationSpan getArtDeliveryDuration()
      {
         return (JDFDurationSpan)getElement(ElementName.ARTDELIVERYDURATION, null, 0);
      }

      ///     <summary> (25) getCreateArtDeliveryDuration
      ///     *  </summary>
      ///     * <returns> JDFDurationSpan the element </returns>
      ///     
      public virtual JDFDurationSpan getCreateArtDeliveryDuration()
      {
         return (JDFDurationSpan)getCreateElement_KElement(ElementName.ARTDELIVERYDURATION, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ArtDeliveryDuration </summary>
      ///     
      public virtual JDFDurationSpan appendArtDeliveryDuration()
      {
         return (JDFDurationSpan)appendElementN(ElementName.ARTDELIVERYDURATION, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element ArtHandling </summary>
      ///     * <returns> JDFSpanArtHandling the element </returns>
      ///     
      public virtual JDFSpanArtHandling getArtHandling()
      {
         return (JDFSpanArtHandling)getElement(ElementName.ARTHANDLING, null, 0);
      }

      ///     <summary> (25) getCreateArtHandling
      ///     *  </summary>
      ///     * <returns> JDFSpanArtHandling the element </returns>
      ///     
      public virtual JDFSpanArtHandling getCreateArtHandling()
      {
         return (JDFSpanArtHandling)getCreateElement_KElement(ElementName.ARTHANDLING, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ArtHandling </summary>
      ///     
      public virtual JDFSpanArtHandling appendArtHandling()
      {
         return (JDFSpanArtHandling)appendElementN(ElementName.ARTHANDLING, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element DeliveryCharge </summary>
      ///     * <returns> JDFSpanDeliveryCharge the element </returns>
      ///     
      public virtual JDFSpanDeliveryCharge getDeliveryCharge()
      {
         return (JDFSpanDeliveryCharge)getElement(ElementName.DELIVERYCHARGE, null, 0);
      }

      ///     <summary> (25) getCreateDeliveryCharge
      ///     *  </summary>
      ///     * <returns> JDFSpanDeliveryCharge the element </returns>
      ///     
      public virtual JDFSpanDeliveryCharge getCreateDeliveryCharge()
      {
         return (JDFSpanDeliveryCharge)getCreateElement_KElement(ElementName.DELIVERYCHARGE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element DeliveryCharge </summary>
      ///     
      public virtual JDFSpanDeliveryCharge appendDeliveryCharge()
      {
         return (JDFSpanDeliveryCharge)appendElementN(ElementName.DELIVERYCHARGE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element Method </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getMethod()
      {
         return (JDFNameSpan)getElement(ElementName.METHOD, null, 0);
      }

      ///     <summary> (25) getCreateMethod
      ///     *  </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getCreateMethod()
      {
         return (JDFNameSpan)getCreateElement_KElement(ElementName.METHOD, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Method </summary>
      ///     
      public virtual JDFNameSpan appendMethod()
      {
         return (JDFNameSpan)appendElementN(ElementName.METHOD, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element ReturnMethod </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getReturnMethod()
      {
         return (JDFNameSpan)getElement(ElementName.RETURNMETHOD, null, 0);
      }

      ///     <summary> (25) getCreateReturnMethod
      ///     *  </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getCreateReturnMethod()
      {
         return (JDFNameSpan)getCreateElement_KElement(ElementName.RETURNMETHOD, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ReturnMethod </summary>
      ///     
      public virtual JDFNameSpan appendReturnMethod()
      {
         return (JDFNameSpan)appendElementN(ElementName.RETURNMETHOD, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element ServiceLevel </summary>
      ///     * <returns> JDFStringSpan the element </returns>
      ///     
      public virtual JDFStringSpan getServiceLevel()
      {
         return (JDFStringSpan)getElement(ElementName.SERVICELEVEL, null, 0);
      }

      ///     <summary> (25) getCreateServiceLevel
      ///     *  </summary>
      ///     * <returns> JDFStringSpan the element </returns>
      ///     
      public virtual JDFStringSpan getCreateServiceLevel()
      {
         return (JDFStringSpan)getCreateElement_KElement(ElementName.SERVICELEVEL, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ServiceLevel </summary>
      ///     
      public virtual JDFStringSpan appendServiceLevel()
      {
         return (JDFStringSpan)appendElementN(ElementName.SERVICELEVEL, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element Transfer </summary>
      ///     * <returns> JDFSpanTransfer the element </returns>
      ///     
      public virtual JDFSpanTransfer getTransfer()
      {
         return (JDFSpanTransfer)getElement(ElementName.TRANSFER, null, 0);
      }

      ///     <summary> (25) getCreateTransfer
      ///     *  </summary>
      ///     * <returns> JDFSpanTransfer the element </returns>
      ///     
      public virtual JDFSpanTransfer getCreateTransfer()
      {
         return (JDFSpanTransfer)getCreateElement_KElement(ElementName.TRANSFER, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Transfer </summary>
      ///     
      public virtual JDFSpanTransfer appendTransfer()
      {
         return (JDFSpanTransfer)appendElementN(ElementName.TRANSFER, 1, null);
      }

      ///     <summary> (26) getCreateArtDelivery
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFArtDelivery the element </returns>
      ///     
      public virtual JDFArtDelivery getCreateArtDelivery(int iSkip)
      {
         return (JDFArtDelivery)getCreateElement_KElement(ElementName.ARTDELIVERY, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element ArtDelivery </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFArtDelivery the element </returns>
      ///     * default is getArtDelivery(0)     
      public virtual JDFArtDelivery getArtDelivery(int iSkip)
      {
         return (JDFArtDelivery)getElement(ElementName.ARTDELIVERY, null, iSkip);
      }

      ///    
      ///     <summary> * Get all ArtDelivery from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFArtDelivery> </returns>
      ///     
      public virtual ICollection<JDFArtDelivery> getAllArtDelivery()
      {
         List<JDFArtDelivery> v = new List<JDFArtDelivery>();

         JDFArtDelivery kElem = (JDFArtDelivery)getFirstChildElement(ElementName.ARTDELIVERY, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFArtDelivery)kElem.getNextSiblingElement(ElementName.ARTDELIVERY, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element ArtDelivery </summary>
      ///     
      public virtual JDFArtDelivery appendArtDelivery()
      {
         return (JDFArtDelivery)appendElement(ElementName.ARTDELIVERY, null);
      }

      ///    
      ///     <summary> * (24) const get element Company </summary>
      ///     * <returns> JDFCompany the element </returns>
      ///     
      public virtual JDFCompany getCompany()
      {
         return (JDFCompany)getElement(ElementName.COMPANY, null, 0);
      }

      ///     <summary> (25) getCreateCompany
      ///     *  </summary>
      ///     * <returns> JDFCompany the element </returns>
      ///     
      public virtual JDFCompany getCreateCompany()
      {
         return (JDFCompany)getCreateElement_KElement(ElementName.COMPANY, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Company </summary>
      ///     
      public virtual JDFCompany appendCompany()
      {
         return (JDFCompany)appendElementN(ElementName.COMPANY, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refCompany(JDFCompany refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreateContact
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFContact the element </returns>
      ///     
      public virtual JDFContact getCreateContact(int iSkip)
      {
         return (JDFContact)getCreateElement_KElement(ElementName.CONTACT, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Contact </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFContact the element </returns>
      ///     * default is getContact(0)     
      public virtual JDFContact getContact(int iSkip)
      {
         return (JDFContact)getElement(ElementName.CONTACT, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Contact from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFContact> </returns>
      ///     
      public virtual ICollection<JDFContact> getAllContact()
      {
         List<JDFContact> v = new List<JDFContact>();

         JDFContact kElem = (JDFContact)getFirstChildElement(ElementName.CONTACT, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFContact)kElem.getNextSiblingElement(ElementName.CONTACT, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Contact </summary>
      ///     
      public override JDFContact appendContact()
      {
         return (JDFContact)appendElement(ElementName.CONTACT, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refContact(JDFContact refTarget)
      {
         refElement(refTarget);
      }
   }
}
