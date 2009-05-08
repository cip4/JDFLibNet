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
   using System.Collections.Generic;



   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFDropItemIntent = org.cip4.jdflib.resource.intent.JDFDropItemIntent;
   using JDFPricing = org.cip4.jdflib.resource.intent.JDFPricing;
   using JDFCompany = org.cip4.jdflib.resource.process.JDFCompany;
   using JDFContact = org.cip4.jdflib.resource.process.JDFContact;
   using JDFDurationSpan = org.cip4.jdflib.span.JDFDurationSpan;
   using JDFNameSpan = org.cip4.jdflib.span.JDFNameSpan;
   using JDFSpanSurplusHandling = org.cip4.jdflib.span.JDFSpanSurplusHandling;
   using JDFSpanTransfer = org.cip4.jdflib.span.JDFSpanTransfer;
   using JDFStringSpan = org.cip4.jdflib.span.JDFStringSpan;
   using JDFTimeSpan = org.cip4.jdflib.span.JDFTimeSpan;

   public abstract class JDFAutoDropIntent : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[3];
      static JDFAutoDropIntent()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ADDITIONALAMOUNT, 0x44444311, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.BUYERACCOUNT, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.PICKUP, 0x44444443, AttributeInfo.EnumAttributeType.boolean_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.EARLIEST, 0x66666666);
         elemInfoTable[1] = new ElemInfoTable(ElementName.EARLIESTDURATION, 0x66666666);
         elemInfoTable[2] = new ElemInfoTable(ElementName.METHOD, 0x66666666);
         elemInfoTable[3] = new ElemInfoTable(ElementName.REQUIRED, 0x66666666);
         elemInfoTable[4] = new ElemInfoTable(ElementName.REQUIREDDURATION, 0x66666666);
         elemInfoTable[5] = new ElemInfoTable(ElementName.RETURNMETHOD, 0x66666661);
         elemInfoTable[6] = new ElemInfoTable(ElementName.SERVICELEVEL, 0x66666611);
         elemInfoTable[7] = new ElemInfoTable(ElementName.SURPLUSHANDLING, 0x66666661);
         elemInfoTable[8] = new ElemInfoTable(ElementName.TRANSFER, 0x66666661);
         elemInfoTable[9] = new ElemInfoTable(ElementName.COMPANY, 0x77777776);
         elemInfoTable[10] = new ElemInfoTable(ElementName.CONTACT, 0x33333331);
         elemInfoTable[11] = new ElemInfoTable(ElementName.DROPITEMINTENT, 0x22222222);
         elemInfoTable[12] = new ElemInfoTable(ElementName.PRICING, 0x77777666);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[13];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoDropIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoDropIntent(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoDropIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoDropIntent(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoDropIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoDropIntent(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoDropIntent[  --> " + base.ToString() + " ]";
      }


      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute AdditionalAmount
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute AdditionalAmount </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAdditionalAmount(int @value)
      {
         setAttribute(AttributeName.ADDITIONALAMOUNT, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute AdditionalAmount </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getAdditionalAmount()
      {
         return getIntAttribute(AttributeName.ADDITIONALAMOUNT, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute BuyerAccount
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BuyerAccount </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBuyerAccount(string @value)
      {
         setAttribute(AttributeName.BUYERACCOUNT, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute BuyerAccount </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getBuyerAccount()
      {
         return getAttribute(AttributeName.BUYERACCOUNT, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Pickup
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Pickup </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPickup(bool @value)
      {
         setAttribute(AttributeName.PICKUP, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute Pickup </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getPickup()
      {
         return getBoolAttribute(AttributeName.PICKUP, null, false);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element Earliest </summary>
      ///     * <returns> JDFTimeSpan the element </returns>
      ///     
      public virtual JDFTimeSpan getEarliest()
      {
         return (JDFTimeSpan)getElement(ElementName.EARLIEST, null, 0);
      }

      ///     <summary> (25) getCreateEarliest
      ///     *  </summary>
      ///     * <returns> JDFTimeSpan the element </returns>
      ///     
      public virtual JDFTimeSpan getCreateEarliest()
      {
         return (JDFTimeSpan)getCreateElement_KElement(ElementName.EARLIEST, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Earliest </summary>
      ///     
      public virtual JDFTimeSpan appendEarliest()
      {
         return (JDFTimeSpan)appendElementN(ElementName.EARLIEST, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element EarliestDuration </summary>
      ///     * <returns> JDFDurationSpan the element </returns>
      ///     
      public virtual JDFDurationSpan getEarliestDuration()
      {
         return (JDFDurationSpan)getElement(ElementName.EARLIESTDURATION, null, 0);
      }

      ///     <summary> (25) getCreateEarliestDuration
      ///     *  </summary>
      ///     * <returns> JDFDurationSpan the element </returns>
      ///     
      public virtual JDFDurationSpan getCreateEarliestDuration()
      {
         return (JDFDurationSpan)getCreateElement_KElement(ElementName.EARLIESTDURATION, null, 0);
      }

      ///    
      ///     <summary> * (29) append element EarliestDuration </summary>
      ///     
      public virtual JDFDurationSpan appendEarliestDuration()
      {
         return (JDFDurationSpan)appendElementN(ElementName.EARLIESTDURATION, 1, null);
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
      ///     <summary> * (24) const get element Required </summary>
      ///     * <returns> JDFTimeSpan the element </returns>
      ///     
      public virtual JDFTimeSpan getRequired()
      {
         return (JDFTimeSpan)getElement(ElementName.REQUIRED, null, 0);
      }

      ///     <summary> (25) getCreateRequired
      ///     *  </summary>
      ///     * <returns> JDFTimeSpan the element </returns>
      ///     
      public virtual JDFTimeSpan getCreateRequired()
      {
         return (JDFTimeSpan)getCreateElement_KElement(ElementName.REQUIRED, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Required </summary>
      ///     
      public virtual JDFTimeSpan appendRequired()
      {
         return (JDFTimeSpan)appendElementN(ElementName.REQUIRED, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element RequiredDuration </summary>
      ///     * <returns> JDFDurationSpan the element </returns>
      ///     
      public virtual JDFDurationSpan getRequiredDuration()
      {
         return (JDFDurationSpan)getElement(ElementName.REQUIREDDURATION, null, 0);
      }

      ///     <summary> (25) getCreateRequiredDuration
      ///     *  </summary>
      ///     * <returns> JDFDurationSpan the element </returns>
      ///     
      public virtual JDFDurationSpan getCreateRequiredDuration()
      {
         return (JDFDurationSpan)getCreateElement_KElement(ElementName.REQUIREDDURATION, null, 0);
      }

      ///    
      ///     <summary> * (29) append element RequiredDuration </summary>
      ///     
      public virtual JDFDurationSpan appendRequiredDuration()
      {
         return (JDFDurationSpan)appendElementN(ElementName.REQUIREDDURATION, 1, null);
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
      ///     <summary> * (24) const get element SurplusHandling </summary>
      ///     * <returns> JDFSpanSurplusHandling the element </returns>
      ///     
      public virtual JDFSpanSurplusHandling getSurplusHandling()
      {
         return (JDFSpanSurplusHandling)getElement(ElementName.SURPLUSHANDLING, null, 0);
      }

      ///     <summary> (25) getCreateSurplusHandling
      ///     *  </summary>
      ///     * <returns> JDFSpanSurplusHandling the element </returns>
      ///     
      public virtual JDFSpanSurplusHandling getCreateSurplusHandling()
      {
         return (JDFSpanSurplusHandling)getCreateElement_KElement(ElementName.SURPLUSHANDLING, null, 0);
      }

      ///    
      ///     <summary> * (29) append element SurplusHandling </summary>
      ///     
      public virtual JDFSpanSurplusHandling appendSurplusHandling()
      {
         return (JDFSpanSurplusHandling)appendElementN(ElementName.SURPLUSHANDLING, 1, null);
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
      public virtual JDFContact appendContact()
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

      ///     <summary> (26) getCreateDropItemIntent
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFDropItemIntent the element </returns>
      ///     
      public virtual JDFDropItemIntent getCreateDropItemIntent(int iSkip)
      {
         return (JDFDropItemIntent)getCreateElement_KElement(ElementName.DROPITEMINTENT, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element DropItemIntent </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFDropItemIntent the element </returns>
      ///     * default is getDropItemIntent(0)     
      public virtual JDFDropItemIntent getDropItemIntent(int iSkip)
      {
         return (JDFDropItemIntent)getElement(ElementName.DROPITEMINTENT, null, iSkip);
      }

      ///    
      ///     <summary> * Get all DropItemIntent from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFDropItemIntent> </returns>
      ///     
      public virtual ICollection<JDFDropItemIntent> getAllDropItemIntent()
      {
         List<JDFDropItemIntent> v = new List<JDFDropItemIntent>();

         JDFDropItemIntent kElem = (JDFDropItemIntent)getFirstChildElement(ElementName.DROPITEMINTENT, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFDropItemIntent)kElem.getNextSiblingElement(ElementName.DROPITEMINTENT, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element DropItemIntent </summary>
      ///     
      public virtual JDFDropItemIntent appendDropItemIntent()
      {
         return (JDFDropItemIntent)appendElement(ElementName.DROPITEMINTENT, null);
      }

      ///    
      ///     <summary> * (24) const get element Pricing </summary>
      ///     * <returns> JDFPricing the element </returns>
      ///     
      public virtual JDFPricing getPricing()
      {
         return (JDFPricing)getElement(ElementName.PRICING, null, 0);
      }

      ///     <summary> (25) getCreatePricing
      ///     *  </summary>
      ///     * <returns> JDFPricing the element </returns>
      ///     
      public virtual JDFPricing getCreatePricing()
      {
         return (JDFPricing)getCreateElement_KElement(ElementName.PRICING, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Pricing </summary>
      ///     
      public virtual JDFPricing appendPricing()
      {
         return (JDFPricing)appendElementN(ElementName.PRICING, 1, null);
      }
   }
}
