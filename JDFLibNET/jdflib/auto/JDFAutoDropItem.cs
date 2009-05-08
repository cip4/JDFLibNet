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
   using JDFShape = org.cip4.jdflib.datatypes.JDFShape;
   using JDFBundle = org.cip4.jdflib.resource.JDFBundle;
   using JDFPallet = org.cip4.jdflib.resource.JDFPallet;
   using JDFRegisterRibbon = org.cip4.jdflib.resource.JDFRegisterRibbon;
   using JDFStrap = org.cip4.jdflib.resource.JDFStrap;
   using JDFTool = org.cip4.jdflib.resource.JDFTool;
   using JDFComponent = org.cip4.jdflib.resource.process.JDFComponent;
   using JDFDigitalMedia = org.cip4.jdflib.resource.process.JDFDigitalMedia;
   using JDFExposedMedia = org.cip4.jdflib.resource.process.JDFExposedMedia;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;
   using JDFRollStand = org.cip4.jdflib.resource.process.JDFRollStand;
   using JDFInk = org.cip4.jdflib.resource.process.prepress.JDFInk;

   public abstract class JDFAutoDropItem : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[9];
      static JDFAutoDropItem()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ACTUALAMOUNT, 0x33333111, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.ACTUALTOTALAMOUNT, 0x33333111, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.AMOUNT, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.TOTALAMOUNT, 0x33333111, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.TOTALDIMENSIONS, 0x33333111, AttributeInfo.EnumAttributeType.shape, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.TOTALVOLUME, 0x33333111, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.TOTALWEIGHT, 0x33333111, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.TRACKINGID, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.UNIT, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.COMPONENT, 0x22222222);
         elemInfoTable[1] = new ElemInfoTable(ElementName.EXPOSEDMEDIA, 0x22222222);
         elemInfoTable[2] = new ElemInfoTable(ElementName.INK, 0x22222222);
         elemInfoTable[3] = new ElemInfoTable(ElementName.MEDIA, 0x22222222);
         elemInfoTable[4] = new ElemInfoTable(ElementName.PALLET, 0x22222222);
         elemInfoTable[5] = new ElemInfoTable(ElementName.REGISTERRIBBON, 0x22222222);
         elemInfoTable[6] = new ElemInfoTable(ElementName.STRAP, 0x22222222);
         elemInfoTable[7] = new ElemInfoTable(ElementName.BUNDLE, 0x22222222);
         elemInfoTable[8] = new ElemInfoTable(ElementName.DIGITALMEDIA, 0x22222222);
         elemInfoTable[9] = new ElemInfoTable(ElementName.ROLLSTAND, 0x22222222);
         elemInfoTable[10] = new ElemInfoTable(ElementName.TOOL, 0x22222222);
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
      ///     <summary> * Constructor for JDFAutoDropItem </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoDropItem(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoDropItem </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoDropItem(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoDropItem </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoDropItem(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoDropItem[  --> " + base.ToString() + " ]";
      }


      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute ActualAmount
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ActualAmount </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setActualAmount(int @value)
      {
         setAttribute(AttributeName.ACTUALAMOUNT, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute ActualAmount </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getActualAmount()
      {
         return getIntAttribute(AttributeName.ACTUALAMOUNT, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ActualTotalAmount
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ActualTotalAmount </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setActualTotalAmount(int @value)
      {
         setAttribute(AttributeName.ACTUALTOTALAMOUNT, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute ActualTotalAmount </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getActualTotalAmount()
      {
         return getIntAttribute(AttributeName.ACTUALTOTALAMOUNT, null, 0);
      }


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
      //        Methods for Attribute TotalAmount
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TotalAmount </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTotalAmount(int @value)
      {
         setAttribute(AttributeName.TOTALAMOUNT, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute TotalAmount </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getTotalAmount()
      {
         return getIntAttribute(AttributeName.TOTALAMOUNT, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TotalDimensions
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TotalDimensions </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTotalDimensions(JDFShape @value)
      {
         setAttribute(AttributeName.TOTALDIMENSIONS, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFShape attribute TotalDimensions </summary>
      ///          * <returns> JDFShape the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFShape </returns>
      ///          
      public virtual JDFShape getTotalDimensions()
      {
         string strAttrName = "";
         JDFShape nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.TOTALDIMENSIONS, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFShape(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TotalVolume
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TotalVolume </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTotalVolume(double @value)
      {
         setAttribute(AttributeName.TOTALVOLUME, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute TotalVolume </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getTotalVolume()
      {
         return getRealAttribute(AttributeName.TOTALVOLUME, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TotalWeight
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TotalWeight </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTotalWeight(double @value)
      {
         setAttribute(AttributeName.TOTALWEIGHT, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute TotalWeight </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getTotalWeight()
      {
         return getRealAttribute(AttributeName.TOTALWEIGHT, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TrackingID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TrackingID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTrackingID(string @value)
      {
         setAttribute(AttributeName.TRACKINGID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute TrackingID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getTrackingID()
      {
         return getAttribute(AttributeName.TRACKINGID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Unit
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Unit </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setUnit(string @value)
      {
         setAttribute(AttributeName.UNIT, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Unit </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getUnit()
      {
         return getAttribute(AttributeName.UNIT, null, JDFConstants.EMPTYSTRING);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateComponent
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFComponent the element </returns>
      ///     
      public virtual JDFComponent getCreateComponent(int iSkip)
      {
         return (JDFComponent)getCreateElement_KElement(ElementName.COMPONENT, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Component </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFComponent the element </returns>
      ///     * default is getComponent(0)     
      public virtual JDFComponent getComponent(int iSkip)
      {
         return (JDFComponent)getElement(ElementName.COMPONENT, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Component from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFComponent> </returns>
      ///     
      public virtual ICollection<JDFComponent> getAllComponent()
      {
         List<JDFComponent> v = new List<JDFComponent>();

         JDFComponent kElem = (JDFComponent)getFirstChildElement(ElementName.COMPONENT, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFComponent)kElem.getNextSiblingElement(ElementName.COMPONENT, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Component </summary>
      ///     
      public virtual JDFComponent appendComponent()
      {
         return (JDFComponent)appendElement(ElementName.COMPONENT, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refComponent(JDFComponent refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreateExposedMedia
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFExposedMedia the element </returns>
      ///     
      public virtual JDFExposedMedia getCreateExposedMedia(int iSkip)
      {
         return (JDFExposedMedia)getCreateElement_KElement(ElementName.EXPOSEDMEDIA, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element ExposedMedia </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFExposedMedia the element </returns>
      ///     * default is getExposedMedia(0)     
      public virtual JDFExposedMedia getExposedMedia(int iSkip)
      {
         return (JDFExposedMedia)getElement(ElementName.EXPOSEDMEDIA, null, iSkip);
      }

      ///    
      ///     <summary> * Get all ExposedMedia from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFExposedMedia> </returns>
      ///     
      public virtual ICollection<JDFExposedMedia> getAllExposedMedia()
      {
         List<JDFExposedMedia> v = new List<JDFExposedMedia>();

         JDFExposedMedia kElem = (JDFExposedMedia)getFirstChildElement(ElementName.EXPOSEDMEDIA, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFExposedMedia)kElem.getNextSiblingElement(ElementName.EXPOSEDMEDIA, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element ExposedMedia </summary>
      ///     
      public virtual JDFExposedMedia appendExposedMedia()
      {
         return (JDFExposedMedia)appendElement(ElementName.EXPOSEDMEDIA, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refExposedMedia(JDFExposedMedia refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreateInk
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFInk the element </returns>
      ///     
      public virtual JDFInk getCreateInk(int iSkip)
      {
         return (JDFInk)getCreateElement_KElement(ElementName.INK, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Ink </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFInk the element </returns>
      ///     * default is getInk(0)     
      public virtual JDFInk getInk(int iSkip)
      {
         return (JDFInk)getElement(ElementName.INK, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Ink from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFInk> </returns>
      ///     
      public virtual ICollection<JDFInk> getAllInk()
      {
         List<JDFInk> v = new List<JDFInk>();

         JDFInk kElem = (JDFInk)getFirstChildElement(ElementName.INK, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFInk)kElem.getNextSiblingElement(ElementName.INK, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Ink </summary>
      ///     
      public virtual JDFInk appendInk()
      {
         return (JDFInk)appendElement(ElementName.INK, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refInk(JDFInk refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreateMedia
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFMedia the element </returns>
      ///     
      public virtual JDFMedia getCreateMedia(int iSkip)
      {
         return (JDFMedia)getCreateElement_KElement(ElementName.MEDIA, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Media </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFMedia the element </returns>
      ///     * default is getMedia(0)     
      public virtual JDFMedia getMedia(int iSkip)
      {
         return (JDFMedia)getElement(ElementName.MEDIA, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Media from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFMedia> </returns>
      ///     
      public virtual ICollection<JDFMedia> getAllMedia()
      {
         List<JDFMedia> v = new List<JDFMedia>();

         JDFMedia kElem = (JDFMedia)getFirstChildElement(ElementName.MEDIA, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFMedia)kElem.getNextSiblingElement(ElementName.MEDIA, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Media </summary>
      ///     
      public virtual JDFMedia appendMedia()
      {
         return (JDFMedia)appendElement(ElementName.MEDIA, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refMedia(JDFMedia refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreatePallet
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFPallet the element </returns>
      ///     
      public virtual JDFPallet getCreatePallet(int iSkip)
      {
         return (JDFPallet)getCreateElement_KElement(ElementName.PALLET, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Pallet </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFPallet the element </returns>
      ///     * default is getPallet(0)     
      public virtual JDFPallet getPallet(int iSkip)
      {
         return (JDFPallet)getElement(ElementName.PALLET, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Pallet from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFPallet> </returns>
      ///     
      public virtual ICollection<JDFPallet> getAllPallet()
      {
         List<JDFPallet> v = new List<JDFPallet>();

         JDFPallet kElem = (JDFPallet)getFirstChildElement(ElementName.PALLET, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFPallet)kElem.getNextSiblingElement(ElementName.PALLET, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Pallet </summary>
      ///     
      public virtual JDFPallet appendPallet()
      {
         return (JDFPallet)appendElement(ElementName.PALLET, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refPallet(JDFPallet refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreateRegisterRibbon
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFRegisterRibbon the element </returns>
      ///     
      public virtual JDFRegisterRibbon getCreateRegisterRibbon(int iSkip)
      {
         return (JDFRegisterRibbon)getCreateElement_KElement(ElementName.REGISTERRIBBON, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element RegisterRibbon </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFRegisterRibbon the element </returns>
      ///     * default is getRegisterRibbon(0)     
      public virtual JDFRegisterRibbon getRegisterRibbon(int iSkip)
      {
         return (JDFRegisterRibbon)getElement(ElementName.REGISTERRIBBON, null, iSkip);
      }

      ///    
      ///     <summary> * Get all RegisterRibbon from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFRegisterRibbon> </returns>
      ///     
      public virtual ICollection<JDFRegisterRibbon> getAllRegisterRibbon()
      {
         List<JDFRegisterRibbon> v = new List<JDFRegisterRibbon>();

         JDFRegisterRibbon kElem = (JDFRegisterRibbon)getFirstChildElement(ElementName.REGISTERRIBBON, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFRegisterRibbon)kElem.getNextSiblingElement(ElementName.REGISTERRIBBON, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element RegisterRibbon </summary>
      ///     
      public virtual JDFRegisterRibbon appendRegisterRibbon()
      {
         return (JDFRegisterRibbon)appendElement(ElementName.REGISTERRIBBON, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refRegisterRibbon(JDFRegisterRibbon refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreateStrap
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFStrap the element </returns>
      ///     
      public virtual JDFStrap getCreateStrap(int iSkip)
      {
         return (JDFStrap)getCreateElement_KElement(ElementName.STRAP, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Strap </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFStrap the element </returns>
      ///     * default is getStrap(0)     
      public virtual JDFStrap getStrap(int iSkip)
      {
         return (JDFStrap)getElement(ElementName.STRAP, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Strap from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFStrap> </returns>
      ///     
      public virtual ICollection<JDFStrap> getAllStrap()
      {
         List<JDFStrap> v = new List<JDFStrap>();

         JDFStrap kElem = (JDFStrap)getFirstChildElement(ElementName.STRAP, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFStrap)kElem.getNextSiblingElement(ElementName.STRAP, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Strap </summary>
      ///     
      public virtual JDFStrap appendStrap()
      {
         return (JDFStrap)appendElement(ElementName.STRAP, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refStrap(JDFStrap refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreateBundle
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFBundle the element </returns>
      ///     
      public virtual JDFBundle getCreateBundle(int iSkip)
      {
         return (JDFBundle)getCreateElement_KElement(ElementName.BUNDLE, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Bundle </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFBundle the element </returns>
      ///     * default is getBundle(0)     
      public virtual JDFBundle getBundle(int iSkip)
      {
         return (JDFBundle)getElement(ElementName.BUNDLE, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Bundle from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFBundle> </returns>
      ///     
      public virtual ICollection<JDFBundle> getAllBundle()
      {
         List<JDFBundle> v = new List<JDFBundle>();

         JDFBundle kElem = (JDFBundle)getFirstChildElement(ElementName.BUNDLE, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFBundle)kElem.getNextSiblingElement(ElementName.BUNDLE, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Bundle </summary>
      ///     
      public virtual JDFBundle appendBundle()
      {
         return (JDFBundle)appendElement(ElementName.BUNDLE, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refBundle(JDFBundle refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreateDigitalMedia
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFDigitalMedia the element </returns>
      ///     
      public virtual JDFDigitalMedia getCreateDigitalMedia(int iSkip)
      {
         return (JDFDigitalMedia)getCreateElement_KElement(ElementName.DIGITALMEDIA, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element DigitalMedia </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFDigitalMedia the element </returns>
      ///     * default is getDigitalMedia(0)     
      public virtual JDFDigitalMedia getDigitalMedia(int iSkip)
      {
         return (JDFDigitalMedia)getElement(ElementName.DIGITALMEDIA, null, iSkip);
      }

      ///    
      ///     <summary> * Get all DigitalMedia from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFDigitalMedia> </returns>
      ///     
      public virtual ICollection<JDFDigitalMedia> getAllDigitalMedia()
      {
         List<JDFDigitalMedia> v = new List<JDFDigitalMedia>();

         JDFDigitalMedia kElem = (JDFDigitalMedia)getFirstChildElement(ElementName.DIGITALMEDIA, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFDigitalMedia)kElem.getNextSiblingElement(ElementName.DIGITALMEDIA, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element DigitalMedia </summary>
      ///     
      public virtual JDFDigitalMedia appendDigitalMedia()
      {
         return (JDFDigitalMedia)appendElement(ElementName.DIGITALMEDIA, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refDigitalMedia(JDFDigitalMedia refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreateRollStand
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFRollStand the element </returns>
      ///     
      public virtual JDFRollStand getCreateRollStand(int iSkip)
      {
         return (JDFRollStand)getCreateElement_KElement(ElementName.ROLLSTAND, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element RollStand </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFRollStand the element </returns>
      ///     * default is getRollStand(0)     
      public virtual JDFRollStand getRollStand(int iSkip)
      {
         return (JDFRollStand)getElement(ElementName.ROLLSTAND, null, iSkip);
      }

      ///    
      ///     <summary> * Get all RollStand from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFRollStand> </returns>
      ///     
      public virtual ICollection<JDFRollStand> getAllRollStand()
      {
         List<JDFRollStand> v = new List<JDFRollStand>();

         JDFRollStand kElem = (JDFRollStand)getFirstChildElement(ElementName.ROLLSTAND, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFRollStand)kElem.getNextSiblingElement(ElementName.ROLLSTAND, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element RollStand </summary>
      ///     
      public virtual JDFRollStand appendRollStand()
      {
         return (JDFRollStand)appendElement(ElementName.ROLLSTAND, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refRollStand(JDFRollStand refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreateTool
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFTool the element </returns>
      ///     
      public virtual JDFTool getCreateTool(int iSkip)
      {
         return (JDFTool)getCreateElement_KElement(ElementName.TOOL, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Tool </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFTool the element </returns>
      ///     * default is getTool(0)     
      public virtual JDFTool getTool(int iSkip)
      {
         return (JDFTool)getElement(ElementName.TOOL, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Tool from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFTool> </returns>
      ///     
      public virtual ICollection<JDFTool> getAllTool()
      {
         List<JDFTool> v = new List<JDFTool>();

         JDFTool kElem = (JDFTool)getFirstChildElement(ElementName.TOOL, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFTool)kElem.getNextSiblingElement(ElementName.TOOL, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Tool </summary>
      ///     
      public virtual JDFTool appendTool()
      {
         return (JDFTool)appendElement(ElementName.TOOL, null);
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
