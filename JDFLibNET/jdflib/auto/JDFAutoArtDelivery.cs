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
   using System;
   using System.Collections;
   using System.Collections.Generic;


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFIntegerRangeList = org.cip4.jdflib.datatypes.JDFIntegerRangeList;
   using JDFTool = org.cip4.jdflib.resource.JDFTool;
   using JDFCompany = org.cip4.jdflib.resource.process.JDFCompany;
   using JDFComponent = org.cip4.jdflib.resource.process.JDFComponent;
   using JDFContact = org.cip4.jdflib.resource.process.JDFContact;
   using JDFDigitalMedia = org.cip4.jdflib.resource.process.JDFDigitalMedia;
   using JDFExposedMedia = org.cip4.jdflib.resource.process.JDFExposedMedia;
   using JDFRunList = org.cip4.jdflib.resource.process.JDFRunList;
   using JDFScanParams = org.cip4.jdflib.resource.process.prepress.JDFScanParams;
   using JDFDurationSpan = org.cip4.jdflib.span.JDFDurationSpan;
   using JDFNameSpan = org.cip4.jdflib.span.JDFNameSpan;
   using JDFSpanArtHandling = org.cip4.jdflib.span.JDFSpanArtHandling;
   using JDFSpanDeliveryCharge = org.cip4.jdflib.span.JDFSpanDeliveryCharge;
   using JDFSpanTransfer = org.cip4.jdflib.span.JDFSpanTransfer;
   using JDFStringSpan = org.cip4.jdflib.span.JDFStringSpan;
   using JDFTimeSpan = org.cip4.jdflib.span.JDFTimeSpan;

   public abstract class JDFAutoArtDelivery : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[7];
      static JDFAutoArtDelivery()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.AMOUNT, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.ARTDELIVERYTYPE, 0x22222221, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.HASBLEEDS, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[3] = new AtrInfoTable(AttributeName.ISTRAPPED, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[4] = new AtrInfoTable(AttributeName.PAGELIST, 0x33333333, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.PREFLIGHTOUTPUT, 0x33333331, AttributeInfo.EnumAttributeType.URL, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.PREFLIGHTSTATUS, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumPreflightStatus.getEnum(0), null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.ARTDELIVERYDATE, 0x66666661);
         elemInfoTable[1] = new ElemInfoTable(ElementName.ARTDELIVERYDURATION, 0x66666661);
         elemInfoTable[2] = new ElemInfoTable(ElementName.ARTHANDLING, 0x66666661);
         elemInfoTable[3] = new ElemInfoTable(ElementName.DELIVERYCHARGE, 0x66666661);
         elemInfoTable[4] = new ElemInfoTable(ElementName.METHOD, 0x66666666);
         elemInfoTable[5] = new ElemInfoTable(ElementName.RETURNMETHOD, 0x66666661);
         elemInfoTable[6] = new ElemInfoTable(ElementName.SERVICELEVEL, 0x66666611);
         elemInfoTable[7] = new ElemInfoTable(ElementName.TRANSFER, 0x66666661);
         elemInfoTable[8] = new ElemInfoTable(ElementName.COMPANY, 0x77777776);
         elemInfoTable[9] = new ElemInfoTable(ElementName.COMPONENT, 0x77777776);
         elemInfoTable[10] = new ElemInfoTable(ElementName.CONTACT, 0x33333331);
         elemInfoTable[11] = new ElemInfoTable(ElementName.DIGITALMEDIA, 0x66666611);
         elemInfoTable[12] = new ElemInfoTable(ElementName.EXPOSEDMEDIA, 0x66666666);
         elemInfoTable[13] = new ElemInfoTable(ElementName.RUNLIST, 0x66666666);
         elemInfoTable[14] = new ElemInfoTable(ElementName.SCANPARAMS, 0x66666666);
         elemInfoTable[15] = new ElemInfoTable(ElementName.TOOL, 0x66666661);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[16];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoArtDelivery </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoArtDelivery(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoArtDelivery </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoArtDelivery(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoArtDelivery </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoArtDelivery(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      /// <summary>
      /// String representation of this object
      /// </summary>
      /// <returns>string</returns>
      public override string ToString()
      {
         return " JDFAutoArtDelivery[  --> " + base.ToString() + " ]";
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
      //        Methods for Attribute Amount
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Amount </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAmount(int @value)
      {
         setAttribute(AttributeName.AMOUNT, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute Amount </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getAmount()
      {
         return getIntAttribute(AttributeName.AMOUNT, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ArtDeliveryType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ArtDeliveryType </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setArtDeliveryType(string @value)
      {
         setAttribute(AttributeName.ARTDELIVERYTYPE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ArtDeliveryType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getArtDeliveryType()
      {
         return getAttribute(AttributeName.ARTDELIVERYTYPE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute HasBleeds
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute HasBleeds </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setHasBleeds(bool @value)
      {
         setAttribute(AttributeName.HASBLEEDS, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute HasBleeds </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getHasBleeds()
      {
         return getBoolAttribute(AttributeName.HASBLEEDS, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute IsTrapped
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute IsTrapped </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setIsTrapped(bool @value)
      {
         setAttribute(AttributeName.ISTRAPPED, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute IsTrapped </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getIsTrapped()
      {
         return getBoolAttribute(AttributeName.ISTRAPPED, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PageList
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PageList </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPageList(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.PAGELIST, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerRangeList attribute PageList </summary>
      ///          * <returns> JDFIntegerRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerRangeList </returns>
      ///          
      public virtual JDFIntegerRangeList getPageList()
      {
         string strAttrName = "";
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.PAGELIST, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFIntegerRangeList(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PreflightOutput
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PreflightOutput </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPreflightOutput(string @value)
      {
         setAttribute(AttributeName.PREFLIGHTOUTPUT, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute PreflightOutput </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getPreflightOutput()
      {
         return getAttribute(AttributeName.PREFLIGHTOUTPUT, null, JDFConstants.EMPTYSTRING);
      }


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
         return EnumPreflightStatus.getEnum(getAttribute(AttributeName.PREFLIGHTSTATUS, null, null));
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

      ///    
      ///     <summary> * (24) const get element Component </summary>
      ///     * <returns> JDFComponent the element </returns>
      ///     
      public virtual JDFComponent getComponent()
      {
         return (JDFComponent)getElement(ElementName.COMPONENT, null, 0);
      }

      ///     <summary> (25) getCreateComponent
      ///     *  </summary>
      ///     * <returns> JDFComponent the element </returns>
      ///     
      public virtual JDFComponent getCreateComponent()
      {
         return (JDFComponent)getCreateElement_KElement(ElementName.COMPONENT, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Component </summary>
      ///     
      public virtual JDFComponent appendComponent()
      {
         return (JDFComponent)appendElementN(ElementName.COMPONENT, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refComponent(JDFComponent refTarget)
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

      ///    
      ///     <summary> * (24) const get element DigitalMedia </summary>
      ///     * <returns> JDFDigitalMedia the element </returns>
      ///     
      public virtual JDFDigitalMedia getDigitalMedia()
      {
         return (JDFDigitalMedia)getElement(ElementName.DIGITALMEDIA, null, 0);
      }

      ///     <summary> (25) getCreateDigitalMedia
      ///     *  </summary>
      ///     * <returns> JDFDigitalMedia the element </returns>
      ///     
      public virtual JDFDigitalMedia getCreateDigitalMedia()
      {
         return (JDFDigitalMedia)getCreateElement_KElement(ElementName.DIGITALMEDIA, null, 0);
      }

      ///    
      ///     <summary> * (29) append element DigitalMedia </summary>
      ///     
      public virtual JDFDigitalMedia appendDigitalMedia()
      {
         return (JDFDigitalMedia)appendElementN(ElementName.DIGITALMEDIA, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refDigitalMedia(JDFDigitalMedia refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element ExposedMedia </summary>
      ///     * <returns> JDFExposedMedia the element </returns>
      ///     
      public virtual JDFExposedMedia getExposedMedia()
      {
         return (JDFExposedMedia)getElement(ElementName.EXPOSEDMEDIA, null, 0);
      }

      ///     <summary> (25) getCreateExposedMedia
      ///     *  </summary>
      ///     * <returns> JDFExposedMedia the element </returns>
      ///     
      public virtual JDFExposedMedia getCreateExposedMedia()
      {
         return (JDFExposedMedia)getCreateElement_KElement(ElementName.EXPOSEDMEDIA, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ExposedMedia </summary>
      ///     
      public virtual JDFExposedMedia appendExposedMedia()
      {
         return (JDFExposedMedia)appendElementN(ElementName.EXPOSEDMEDIA, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refExposedMedia(JDFExposedMedia refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element RunList </summary>
      ///     * <returns> JDFRunList the element </returns>
      ///     
      public virtual JDFRunList getRunList()
      {
         return (JDFRunList)getElement(ElementName.RUNLIST, null, 0);
      }

      ///     <summary> (25) getCreateRunList
      ///     *  </summary>
      ///     * <returns> JDFRunList the element </returns>
      ///     
      public virtual JDFRunList getCreateRunList()
      {
         return (JDFRunList)getCreateElement_KElement(ElementName.RUNLIST, null, 0);
      }

      ///    
      ///     <summary> * (29) append element RunList </summary>
      ///     
      public virtual JDFRunList appendRunList()
      {
         return (JDFRunList)appendElementN(ElementName.RUNLIST, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refRunList(JDFRunList refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element ScanParams </summary>
      ///     * <returns> JDFScanParams the element </returns>
      ///     
      public virtual JDFScanParams getScanParams()
      {
         return (JDFScanParams)getElement(ElementName.SCANPARAMS, null, 0);
      }

      ///     <summary> (25) getCreateScanParams
      ///     *  </summary>
      ///     * <returns> JDFScanParams the element </returns>
      ///     
      public virtual JDFScanParams getCreateScanParams()
      {
         return (JDFScanParams)getCreateElement_KElement(ElementName.SCANPARAMS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ScanParams </summary>
      ///     
      public virtual JDFScanParams appendScanParams()
      {
         return (JDFScanParams)appendElementN(ElementName.SCANPARAMS, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refScanParams(JDFScanParams refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element Tool </summary>
      ///     * <returns> JDFTool the element </returns>
      ///     
      public virtual JDFTool getTool()
      {
         return (JDFTool)getElement(ElementName.TOOL, null, 0);
      }

      ///     <summary> (25) getCreateTool
      ///     *  </summary>
      ///     * <returns> JDFTool the element </returns>
      ///     
      public virtual JDFTool getCreateTool()
      {
         return (JDFTool)getCreateElement_KElement(ElementName.TOOL, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Tool </summary>
      ///     
      public virtual JDFTool appendTool()
      {
         return (JDFTool)appendElementN(ElementName.TOOL, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refTool(JDFTool refTarget)
      {
         refElement(refTarget);
      }
   }
}
