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
   using JDFPayment = org.cip4.jdflib.resource.JDFPayment;
   using JDFPricing = org.cip4.jdflib.resource.intent.JDFPricing;

   public abstract class JDFAutoPricing : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[5];
      static JDFAutoPricing()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ADDITIONALPRICE, 0x44444333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.CURRENCY, 0x44444333, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.HASPRICE, 0x44444333, AttributeInfo.EnumAttributeType.boolean_, null, "true");
         atrInfoTable[3] = new AtrInfoTable(AttributeName.ITEM, 0x44444333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.PRICE, 0x44444333, AttributeInfo.EnumAttributeType.double_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.PAYMENT, 0x44444331);
         elemInfoTable[1] = new ElemInfoTable(ElementName.PRICING, 0x44444333);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[2];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoPricing </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPricing(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPricing </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPricing(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPricing </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoPricing(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoPricing[  --> " + base.ToString() + " ]";
      }


      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute AdditionalPrice
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute AdditionalPrice </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAdditionalPrice(double @value)
      {
         setAttribute(AttributeName.ADDITIONALPRICE, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute AdditionalPrice </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getAdditionalPrice()
      {
         return getRealAttribute(AttributeName.ADDITIONALPRICE, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Currency
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Currency </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCurrency(string @value)
      {
         setAttribute(AttributeName.CURRENCY, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Currency </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getCurrency()
      {
         return getAttribute(AttributeName.CURRENCY, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute HasPrice
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute HasPrice </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setHasPrice(bool @value)
      {
         setAttribute(AttributeName.HASPRICE, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute HasPrice </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getHasPrice()
      {
         return getBoolAttribute(AttributeName.HASPRICE, null, true);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Item
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Item </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setItem(string @value)
      {
         setAttribute(AttributeName.ITEM, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Item </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getItem()
      {
         return getAttribute(AttributeName.ITEM, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Price
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Price </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPrice(double @value)
      {
         setAttribute(AttributeName.PRICE, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute Price </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getPrice()
      {
         return getRealAttribute(AttributeName.PRICE, null, 0.0);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreatePayment
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFPayment the element </returns>
      ///     
      public virtual JDFPayment getCreatePayment(int iSkip)
      {
         return (JDFPayment)getCreateElement_KElement(ElementName.PAYMENT, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Payment </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFPayment the element </returns>
      ///     * default is getPayment(0)     
      public virtual JDFPayment getPayment(int iSkip)
      {
         return (JDFPayment)getElement(ElementName.PAYMENT, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Payment from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFPayment> </returns>
      ///     
      public virtual ICollection<JDFPayment> getAllPayment()
      {
         List<JDFPayment> v = new List<JDFPayment>();

         JDFPayment kElem = (JDFPayment)getFirstChildElement(ElementName.PAYMENT, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFPayment)kElem.getNextSiblingElement(ElementName.PAYMENT, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Payment </summary>
      ///     
      public virtual JDFPayment appendPayment()
      {
         return (JDFPayment)appendElement(ElementName.PAYMENT, null);
      }

      ///     <summary> (26) getCreatePricing
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFPricing the element </returns>
      ///     
      public virtual JDFPricing getCreatePricing(int iSkip)
      {
         return (JDFPricing)getCreateElement_KElement(ElementName.PRICING, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Pricing </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFPricing the element </returns>
      ///     * default is getPricing(0)     
      public virtual JDFPricing getPricing(int iSkip)
      {
         return (JDFPricing)getElement(ElementName.PRICING, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Pricing from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFPricing> </returns>
      ///     
      public virtual ICollection<JDFPricing> getAllPricing()
      {
         List<JDFPricing> v = new List<JDFPricing>();

         JDFPricing kElem = (JDFPricing)getFirstChildElement(ElementName.PRICING, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFPricing)kElem.getNextSiblingElement(ElementName.PRICING, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Pricing </summary>
      ///     
      public virtual JDFPricing appendPricing()
      {
         return (JDFPricing)appendElement(ElementName.PRICING, null);
      }
   }
}
