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
   using JDFElementColorParams = org.cip4.jdflib.resource.process.JDFElementColorParams;
   using JDFImageCompressionParams = org.cip4.jdflib.resource.process.JDFImageCompressionParams;
   using JDFSeparationSpec = org.cip4.jdflib.resource.process.JDFSeparationSpec;
   using JDFScreeningParams = org.cip4.jdflib.resource.process.prepress.JDFScreeningParams;

   public abstract class JDFAutoContentData : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[8];
      static JDFAutoContentData()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.CATALOGID, 0x33333111, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.CATALOGDETAILS, 0x33333111, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.CONTENTTYPE, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.HASBLEEDS, 0x33333111, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.ISBLANK, 0x33333111, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.ISTRAPPED, 0x33333111, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.JOBID, 0x33333111, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.PRODUCTID, 0x33333111, AttributeInfo.EnumAttributeType.string_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.ELEMENTCOLORPARAMS, 0x66666111);
         elemInfoTable[1] = new ElemInfoTable(ElementName.IMAGECOMPRESSIONPARAMS, 0x66666111);
         elemInfoTable[2] = new ElemInfoTable(ElementName.SCREENINGPARAMS, 0x66666111);
         elemInfoTable[3] = new ElemInfoTable(ElementName.SEPARATIONSPEC, 0x33333111);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[4];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoContentData </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoContentData(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoContentData </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoContentData(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoContentData </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoContentData(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoContentData[  --> " + base.ToString() + " ]";
      }


      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute CatalogID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CatalogID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCatalogID(string @value)
      {
         setAttribute(AttributeName.CATALOGID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute CatalogID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getCatalogID()
      {
         return getAttribute(AttributeName.CATALOGID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute CatalogDetails
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CatalogDetails </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCatalogDetails(string @value)
      {
         setAttribute(AttributeName.CATALOGDETAILS, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute CatalogDetails </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getCatalogDetails()
      {
         return getAttribute(AttributeName.CATALOGDETAILS, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ContentType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ContentType </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setContentType(string @value)
      {
         setAttribute(AttributeName.CONTENTTYPE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ContentType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getContentType()
      {
         return getAttribute(AttributeName.CONTENTTYPE, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute IsBlank
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute IsBlank </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setIsBlank(bool @value)
      {
         setAttribute(AttributeName.ISBLANK, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute IsBlank </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getIsBlank()
      {
         return getBoolAttribute(AttributeName.ISBLANK, null, false);
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
      //        Methods for Attribute JobID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute JobID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setJobID(string @value)
      {
         setAttribute(AttributeName.JOBID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute JobID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getJobID()
      {
         return getAttribute(AttributeName.JOBID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ProductID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ProductID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setProductID(string @value)
      {
         setAttribute(AttributeName.PRODUCTID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ProductID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getProductID()
      {
         return getAttribute(AttributeName.PRODUCTID, null, JDFConstants.EMPTYSTRING);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element ElementColorParams </summary>
      ///     * <returns> JDFElementColorParams the element </returns>
      ///     
      public virtual JDFElementColorParams getElementColorParams()
      {
         return (JDFElementColorParams)getElement(ElementName.ELEMENTCOLORPARAMS, null, 0);
      }

      ///     <summary> (25) getCreateElementColorParams
      ///     *  </summary>
      ///     * <returns> JDFElementColorParams the element </returns>
      ///     
      public virtual JDFElementColorParams getCreateElementColorParams()
      {
         return (JDFElementColorParams)getCreateElement_KElement(ElementName.ELEMENTCOLORPARAMS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ElementColorParams </summary>
      ///     
      public virtual JDFElementColorParams appendElementColorParams()
      {
         return (JDFElementColorParams)appendElementN(ElementName.ELEMENTCOLORPARAMS, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refElementColorParams(JDFElementColorParams refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element ImageCompressionParams </summary>
      ///     * <returns> JDFImageCompressionParams the element </returns>
      ///     
      public virtual JDFImageCompressionParams getImageCompressionParams()
      {
         return (JDFImageCompressionParams)getElement(ElementName.IMAGECOMPRESSIONPARAMS, null, 0);
      }

      ///     <summary> (25) getCreateImageCompressionParams
      ///     *  </summary>
      ///     * <returns> JDFImageCompressionParams the element </returns>
      ///     
      public virtual JDFImageCompressionParams getCreateImageCompressionParams()
      {
         return (JDFImageCompressionParams)getCreateElement_KElement(ElementName.IMAGECOMPRESSIONPARAMS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ImageCompressionParams </summary>
      ///     
      public virtual JDFImageCompressionParams appendImageCompressionParams()
      {
         return (JDFImageCompressionParams)appendElementN(ElementName.IMAGECOMPRESSIONPARAMS, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refImageCompressionParams(JDFImageCompressionParams refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element ScreeningParams </summary>
      ///     * <returns> JDFScreeningParams the element </returns>
      ///     
      public virtual JDFScreeningParams getScreeningParams()
      {
         return (JDFScreeningParams)getElement(ElementName.SCREENINGPARAMS, null, 0);
      }

      ///     <summary> (25) getCreateScreeningParams
      ///     *  </summary>
      ///     * <returns> JDFScreeningParams the element </returns>
      ///     
      public virtual JDFScreeningParams getCreateScreeningParams()
      {
         return (JDFScreeningParams)getCreateElement_KElement(ElementName.SCREENINGPARAMS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ScreeningParams </summary>
      ///     
      public virtual JDFScreeningParams appendScreeningParams()
      {
         return (JDFScreeningParams)appendElementN(ElementName.SCREENINGPARAMS, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refScreeningParams(JDFScreeningParams refTarget)
      {
         refElement(refTarget);
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
   }
}
