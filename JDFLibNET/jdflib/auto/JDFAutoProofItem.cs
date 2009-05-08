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
   using JDFIntegerRangeList = org.cip4.jdflib.datatypes.JDFIntegerRangeList;
   using JDFApprovalParams = org.cip4.jdflib.resource.process.JDFApprovalParams;
   using JDFSeparationSpec = org.cip4.jdflib.resource.process.JDFSeparationSpec;
   using JDFIntegerSpan = org.cip4.jdflib.span.JDFIntegerSpan;
   using JDFNameSpan = org.cip4.jdflib.span.JDFNameSpan;
   using JDFOptionSpan = org.cip4.jdflib.span.JDFOptionSpan;
   using JDFSpanColorType = org.cip4.jdflib.span.JDFSpanColorType;
   using JDFSpanImageStrategy = org.cip4.jdflib.span.JDFSpanImageStrategy;
   using JDFSpanProofType = org.cip4.jdflib.span.JDFSpanProofType;
   using JDFStringSpan = org.cip4.jdflib.span.JDFStringSpan;

   public abstract class JDFAutoProofItem : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[4];
      static JDFAutoProofItem()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.CONTRACT, 0x33333331, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.PAGEINDEX, 0x33333331, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.PROOFNAME, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.PROOFTARGET, 0x33333331, AttributeInfo.EnumAttributeType.URL, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.AMOUNT, 0x66666661);
         elemInfoTable[1] = new ElemInfoTable(ElementName.BRANDNAME, 0x66666661);
         elemInfoTable[2] = new ElemInfoTable(ElementName.COLORTYPE, 0x66666661);
         elemInfoTable[3] = new ElemInfoTable(ElementName.HALFTONE, 0x66666661);
         elemInfoTable[4] = new ElemInfoTable(ElementName.IMAGESTRATEGY, 0x66666611);
         elemInfoTable[5] = new ElemInfoTable(ElementName.TECHNOLOGY, 0x66666661);
         elemInfoTable[6] = new ElemInfoTable(ElementName.PROOFTYPE, 0x66666661);
         elemInfoTable[7] = new ElemInfoTable(ElementName.SEPARATIONSPEC, 0x33333331);
         elemInfoTable[8] = new ElemInfoTable(ElementName.APPROVALPARAMS, 0x66666611);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[9];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoProofItem </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoProofItem(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoProofItem </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoProofItem(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoProofItem </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoProofItem(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoProofItem[  --> " + base.ToString() + " ]";
      }


      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute Contract
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Contract </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setContract(bool @value)
      {
         setAttribute(AttributeName.CONTRACT, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute Contract </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getContract()
      {
         return getBoolAttribute(AttributeName.CONTRACT, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PageIndex
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PageIndex </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPageIndex(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.PAGEINDEX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerRangeList attribute PageIndex </summary>
      ///          * <returns> JDFIntegerRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerRangeList </returns>
      ///          
      public virtual JDFIntegerRangeList getPageIndex()
      {
         string strAttrName = "";
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.PAGEINDEX, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute ProofName
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ProofName </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setProofName(string @value)
      {
         setAttribute(AttributeName.PROOFNAME, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ProofName </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getProofName()
      {
         return getAttribute(AttributeName.PROOFNAME, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ProofTarget
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ProofTarget </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setProofTarget(string @value)
      {
         setAttribute(AttributeName.PROOFTARGET, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ProofTarget </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getProofTarget()
      {
         return getAttribute(AttributeName.PROOFTARGET, null, JDFConstants.EMPTYSTRING);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element Amount </summary>
      ///     * <returns> JDFIntegerSpan the element </returns>
      ///     
      public virtual JDFIntegerSpan getAmount()
      {
         return (JDFIntegerSpan)getElement(ElementName.AMOUNT, null, 0);
      }

      ///     <summary> (25) getCreateAmount
      ///     *  </summary>
      ///     * <returns> JDFIntegerSpan the element </returns>
      ///     
      public virtual JDFIntegerSpan getCreateAmount()
      {
         return (JDFIntegerSpan)getCreateElement_KElement(ElementName.AMOUNT, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Amount </summary>
      ///     
      public virtual JDFIntegerSpan appendAmount()
      {
         return (JDFIntegerSpan)appendElementN(ElementName.AMOUNT, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element BrandName </summary>
      ///     * <returns> JDFStringSpan the element </returns>
      ///     
      public virtual JDFStringSpan getBrandName()
      {
         return (JDFStringSpan)getElement(ElementName.BRANDNAME, null, 0);
      }

      ///     <summary> (25) getCreateBrandName
      ///     *  </summary>
      ///     * <returns> JDFStringSpan the element </returns>
      ///     
      public virtual JDFStringSpan getCreateBrandName()
      {
         return (JDFStringSpan)getCreateElement_KElement(ElementName.BRANDNAME, null, 0);
      }

      ///    
      ///     <summary> * (29) append element BrandName </summary>
      ///     
      public virtual JDFStringSpan appendBrandName()
      {
         return (JDFStringSpan)appendElementN(ElementName.BRANDNAME, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element ColorType </summary>
      ///     * <returns> JDFSpanColorType the element </returns>
      ///     
      public virtual JDFSpanColorType getColorType()
      {
         return (JDFSpanColorType)getElement(ElementName.COLORTYPE, null, 0);
      }

      ///     <summary> (25) getCreateColorType
      ///     *  </summary>
      ///     * <returns> JDFSpanColorType the element </returns>
      ///     
      public virtual JDFSpanColorType getCreateColorType()
      {
         return (JDFSpanColorType)getCreateElement_KElement(ElementName.COLORTYPE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ColorType </summary>
      ///     
      public virtual JDFSpanColorType appendColorType()
      {
         return (JDFSpanColorType)appendElementN(ElementName.COLORTYPE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element HalfTone </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getHalfTone()
      {
         return (JDFOptionSpan)getElement(ElementName.HALFTONE, null, 0);
      }

      ///     <summary> (25) getCreateHalfTone
      ///     *  </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getCreateHalfTone()
      {
         return (JDFOptionSpan)getCreateElement_KElement(ElementName.HALFTONE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element HalfTone </summary>
      ///     
      public virtual JDFOptionSpan appendHalfTone()
      {
         return (JDFOptionSpan)appendElementN(ElementName.HALFTONE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element ImageStrategy </summary>
      ///     * <returns> JDFSpanImageStrategy the element </returns>
      ///     
      public virtual JDFSpanImageStrategy getImageStrategy()
      {
         return (JDFSpanImageStrategy)getElement(ElementName.IMAGESTRATEGY, null, 0);
      }

      ///     <summary> (25) getCreateImageStrategy
      ///     *  </summary>
      ///     * <returns> JDFSpanImageStrategy the element </returns>
      ///     
      public virtual JDFSpanImageStrategy getCreateImageStrategy()
      {
         return (JDFSpanImageStrategy)getCreateElement_KElement(ElementName.IMAGESTRATEGY, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ImageStrategy </summary>
      ///     
      public virtual JDFSpanImageStrategy appendImageStrategy()
      {
         return (JDFSpanImageStrategy)appendElementN(ElementName.IMAGESTRATEGY, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element Technology </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getTechnology()
      {
         return (JDFNameSpan)getElement(ElementName.TECHNOLOGY, null, 0);
      }

      ///     <summary> (25) getCreateTechnology
      ///     *  </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getCreateTechnology()
      {
         return (JDFNameSpan)getCreateElement_KElement(ElementName.TECHNOLOGY, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Technology </summary>
      ///     
      public virtual JDFNameSpan appendTechnology()
      {
         return (JDFNameSpan)appendElementN(ElementName.TECHNOLOGY, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element ProofType </summary>
      ///     * <returns> JDFSpanProofType the element </returns>
      ///     
      public virtual JDFSpanProofType getProofType()
      {
         return (JDFSpanProofType)getElement(ElementName.PROOFTYPE, null, 0);
      }

      ///     <summary> (25) getCreateProofType
      ///     *  </summary>
      ///     * <returns> JDFSpanProofType the element </returns>
      ///     
      public virtual JDFSpanProofType getCreateProofType()
      {
         return (JDFSpanProofType)getCreateElement_KElement(ElementName.PROOFTYPE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ProofType </summary>
      ///     
      public virtual JDFSpanProofType appendProofType()
      {
         return (JDFSpanProofType)appendElementN(ElementName.PROOFTYPE, 1, null);
      }

      ///     <summary> (26) getCreateSeparationSpec
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFSeparationSpec the element </returns>
      ///     
      public virtual JDFSeparationSpec getCreateSeparationSpec(int iSkip)
      {
         return (JDFSeparationSpec)getCreateElement_KElement(ElementName.SEPARATIONSPEC, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element SeparationSpec </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFSeparationSpec the element </returns>
      ///     * default is getSeparationSpec(0)     
      public virtual JDFSeparationSpec getSeparationSpec(int iSkip)
      {
         return (JDFSeparationSpec)getElement(ElementName.SEPARATIONSPEC, null, iSkip);
      }

      ///    
      ///     <summary> * Get all SeparationSpec from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFSeparationSpec> </returns>
      ///     
      public virtual ICollection<JDFSeparationSpec> getAllSeparationSpec()
      {
         List<JDFSeparationSpec> v = new List<JDFSeparationSpec>();

         JDFSeparationSpec kElem = (JDFSeparationSpec)getFirstChildElement(ElementName.SEPARATIONSPEC, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFSeparationSpec)kElem.getNextSiblingElement(ElementName.SEPARATIONSPEC, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element SeparationSpec </summary>
      ///     
      public virtual JDFSeparationSpec appendSeparationSpec()
      {
         return (JDFSeparationSpec)appendElement(ElementName.SEPARATIONSPEC, null);
      }

      ///    
      ///     <summary> * (24) const get element ApprovalParams </summary>
      ///     * <returns> JDFApprovalParams the element </returns>
      ///     
      public virtual JDFApprovalParams getApprovalParams()
      {
         return (JDFApprovalParams)getElement(ElementName.APPROVALPARAMS, null, 0);
      }

      ///     <summary> (25) getCreateApprovalParams
      ///     *  </summary>
      ///     * <returns> JDFApprovalParams the element </returns>
      ///     
      public virtual JDFApprovalParams getCreateApprovalParams()
      {
         return (JDFApprovalParams)getCreateElement_KElement(ElementName.APPROVALPARAMS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ApprovalParams </summary>
      ///     
      public virtual JDFApprovalParams appendApprovalParams()
      {
         return (JDFApprovalParams)appendElementN(ElementName.APPROVALPARAMS, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refApprovalParams(JDFApprovalParams refTarget)
      {
         refElement(refTarget);
      }
   }
}
