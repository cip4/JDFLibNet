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


   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFBundle = org.cip4.jdflib.resource.JDFBundle;
   using JDFPallet = org.cip4.jdflib.resource.JDFPallet;
   using JDFRegisterRibbon = org.cip4.jdflib.resource.JDFRegisterRibbon;
   using JDFStrap = org.cip4.jdflib.resource.JDFStrap;
   using JDFTool = org.cip4.jdflib.resource.JDFTool;
   using JDFPricing = org.cip4.jdflib.resource.intent.JDFPricing;
   using JDFComponent = org.cip4.jdflib.resource.process.JDFComponent;
   using JDFDigitalMedia = org.cip4.jdflib.resource.process.JDFDigitalMedia;
   using JDFExposedMedia = org.cip4.jdflib.resource.process.JDFExposedMedia;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;
   using JDFRollStand = org.cip4.jdflib.resource.process.JDFRollStand;
   using JDFInk = org.cip4.jdflib.resource.process.prepress.JDFInk;

   public abstract class JDFAutoDropItemIntent : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[5];
      static JDFAutoDropItemIntent()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ADDITIONALAMOUNT, 0x44444333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.AMOUNT, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.ORDEREDAMOUNT, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.PROOF, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.UNIT, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.PRICING, 0x77777666);
         elemInfoTable[1] = new ElemInfoTable(ElementName.COMPONENT, 0x66666666);
         elemInfoTable[2] = new ElemInfoTable(ElementName.EXPOSEDMEDIA, 0x66666666);
         elemInfoTable[3] = new ElemInfoTable(ElementName.INK, 0x66666666);
         elemInfoTable[4] = new ElemInfoTable(ElementName.MEDIA, 0x66666666);
         elemInfoTable[5] = new ElemInfoTable(ElementName.PALLET, 0x66666666);
         elemInfoTable[6] = new ElemInfoTable(ElementName.REGISTERRIBBON, 0x66666666);
         elemInfoTable[7] = new ElemInfoTable(ElementName.STRAP, 0x66666666);
         elemInfoTable[8] = new ElemInfoTable(ElementName.BUNDLE, 0x66666666);
         elemInfoTable[9] = new ElemInfoTable(ElementName.DIGITALMEDIA, 0x66666666);
         elemInfoTable[10] = new ElemInfoTable(ElementName.ROLLSTAND, 0x66666666);
         elemInfoTable[11] = new ElemInfoTable(ElementName.TOOL, 0x66666666);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[12];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoDropItemIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoDropItemIntent(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoDropItemIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoDropItemIntent(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoDropItemIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoDropItemIntent(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoDropItemIntent[  --> " + base.ToString() + " ]";
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
      //        Methods for Attribute OrderedAmount
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute OrderedAmount </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setOrderedAmount(int @value)
      {
         setAttribute(AttributeName.ORDEREDAMOUNT, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute OrderedAmount </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getOrderedAmount()
      {
         return getIntAttribute(AttributeName.ORDEREDAMOUNT, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Proof
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Proof </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setProof(string @value)
      {
         setAttribute(AttributeName.PROOF, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Proof </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getProof()
      {
         return getAttribute(AttributeName.PROOF, null, JDFConstants.EMPTYSTRING);
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
      ///     <summary> * (24) const get element Ink </summary>
      ///     * <returns> JDFInk the element </returns>
      ///     
      public virtual JDFInk getInk()
      {
         return (JDFInk)getElement(ElementName.INK, null, 0);
      }

      ///     <summary> (25) getCreateInk
      ///     *  </summary>
      ///     * <returns> JDFInk the element </returns>
      ///     
      public virtual JDFInk getCreateInk()
      {
         return (JDFInk)getCreateElement_KElement(ElementName.INK, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Ink </summary>
      ///     
      public virtual JDFInk appendInk()
      {
         return (JDFInk)appendElementN(ElementName.INK, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refInk(JDFInk refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element Media </summary>
      ///     * <returns> JDFMedia the element </returns>
      ///     
      public virtual JDFMedia getMedia()
      {
         return (JDFMedia)getElement(ElementName.MEDIA, null, 0);
      }

      ///     <summary> (25) getCreateMedia
      ///     *  </summary>
      ///     * <returns> JDFMedia the element </returns>
      ///     
      public virtual JDFMedia getCreateMedia()
      {
         return (JDFMedia)getCreateElement_KElement(ElementName.MEDIA, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Media </summary>
      ///     
      public virtual JDFMedia appendMedia()
      {
         return (JDFMedia)appendElementN(ElementName.MEDIA, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refMedia(JDFMedia refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element Pallet </summary>
      ///     * <returns> JDFPallet the element </returns>
      ///     
      public virtual JDFPallet getPallet()
      {
         return (JDFPallet)getElement(ElementName.PALLET, null, 0);
      }

      ///     <summary> (25) getCreatePallet
      ///     *  </summary>
      ///     * <returns> JDFPallet the element </returns>
      ///     
      public virtual JDFPallet getCreatePallet()
      {
         return (JDFPallet)getCreateElement_KElement(ElementName.PALLET, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Pallet </summary>
      ///     
      public virtual JDFPallet appendPallet()
      {
         return (JDFPallet)appendElementN(ElementName.PALLET, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refPallet(JDFPallet refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element RegisterRibbon </summary>
      ///     * <returns> JDFRegisterRibbon the element </returns>
      ///     
      public virtual JDFRegisterRibbon getRegisterRibbon()
      {
         return (JDFRegisterRibbon)getElement(ElementName.REGISTERRIBBON, null, 0);
      }

      ///     <summary> (25) getCreateRegisterRibbon
      ///     *  </summary>
      ///     * <returns> JDFRegisterRibbon the element </returns>
      ///     
      public virtual JDFRegisterRibbon getCreateRegisterRibbon()
      {
         return (JDFRegisterRibbon)getCreateElement_KElement(ElementName.REGISTERRIBBON, null, 0);
      }

      ///    
      ///     <summary> * (29) append element RegisterRibbon </summary>
      ///     
      public virtual JDFRegisterRibbon appendRegisterRibbon()
      {
         return (JDFRegisterRibbon)appendElementN(ElementName.REGISTERRIBBON, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refRegisterRibbon(JDFRegisterRibbon refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element Strap </summary>
      ///     * <returns> JDFStrap the element </returns>
      ///     
      public virtual JDFStrap getStrap()
      {
         return (JDFStrap)getElement(ElementName.STRAP, null, 0);
      }

      ///     <summary> (25) getCreateStrap
      ///     *  </summary>
      ///     * <returns> JDFStrap the element </returns>
      ///     
      public virtual JDFStrap getCreateStrap()
      {
         return (JDFStrap)getCreateElement_KElement(ElementName.STRAP, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Strap </summary>
      ///     
      public virtual JDFStrap appendStrap()
      {
         return (JDFStrap)appendElementN(ElementName.STRAP, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refStrap(JDFStrap refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element Bundle </summary>
      ///     * <returns> JDFBundle the element </returns>
      ///     
      public virtual JDFBundle getBundle()
      {
         return (JDFBundle)getElement(ElementName.BUNDLE, null, 0);
      }

      ///     <summary> (25) getCreateBundle
      ///     *  </summary>
      ///     * <returns> JDFBundle the element </returns>
      ///     
      public virtual JDFBundle getCreateBundle()
      {
         return (JDFBundle)getCreateElement_KElement(ElementName.BUNDLE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Bundle </summary>
      ///     
      public virtual JDFBundle appendBundle()
      {
         return (JDFBundle)appendElementN(ElementName.BUNDLE, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refBundle(JDFBundle refTarget)
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
      ///     <summary> * (24) const get element RollStand </summary>
      ///     * <returns> JDFRollStand the element </returns>
      ///     
      public virtual JDFRollStand getRollStand()
      {
         return (JDFRollStand)getElement(ElementName.ROLLSTAND, null, 0);
      }

      ///     <summary> (25) getCreateRollStand
      ///     *  </summary>
      ///     * <returns> JDFRollStand the element </returns>
      ///     
      public virtual JDFRollStand getCreateRollStand()
      {
         return (JDFRollStand)getCreateElement_KElement(ElementName.ROLLSTAND, null, 0);
      }

      ///    
      ///     <summary> * (29) append element RollStand </summary>
      ///     
      public virtual JDFRollStand appendRollStand()
      {
         return (JDFRollStand)appendElementN(ElementName.ROLLSTAND, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refRollStand(JDFRollStand refTarget)
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
