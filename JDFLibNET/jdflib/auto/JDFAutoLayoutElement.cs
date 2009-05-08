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
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFIntegerRangeList = org.cip4.jdflib.datatypes.JDFIntegerRangeList;
   using JDFRectangle = org.cip4.jdflib.datatypes.JDFRectangle;
   using JDFPageList = org.cip4.jdflib.resource.JDFPageList;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFColorPool = org.cip4.jdflib.resource.process.JDFColorPool;
   using JDFDependencies = org.cip4.jdflib.resource.process.JDFDependencies;
   using JDFElementColorParams = org.cip4.jdflib.resource.process.JDFElementColorParams;
   using JDFFileSpec = org.cip4.jdflib.resource.process.JDFFileSpec;
   using JDFImageCompressionParams = org.cip4.jdflib.resource.process.JDFImageCompressionParams;
   using JDFSeparationSpec = org.cip4.jdflib.resource.process.JDFSeparationSpec;
   using JDFScreeningParams = org.cip4.jdflib.resource.process.prepress.JDFScreeningParams;

   public abstract class JDFAutoLayoutElement : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[13];
      static JDFAutoLayoutElement()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.IGNOREPDLCOPIES, 0x33333331, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.IGNOREPDLIMPOSITION, 0x33333331, AttributeInfo.EnumAttributeType.boolean_, null, "true");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.CLIPPATH, 0x33333333, AttributeInfo.EnumAttributeType.PDFPath, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.ELEMENTTYPE, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumElementType.getEnum(0), null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.HASBLEEDS, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.ISBLANK, 0x33333311, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.ISPRINTABLE, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.ISTRAPPED, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.PAGELISTINDEX, 0x33333311, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.SOURCEBLEEDBOX, 0x33333333, AttributeInfo.EnumAttributeType.rectangle, null, null);
         atrInfoTable[10] = new AtrInfoTable(AttributeName.SOURCECLIPBOX, 0x33333333, AttributeInfo.EnumAttributeType.rectangle, null, null);
         atrInfoTable[11] = new AtrInfoTable(AttributeName.SOURCETRIMBOX, 0x33333333, AttributeInfo.EnumAttributeType.rectangle, null, null);
         atrInfoTable[12] = new AtrInfoTable(AttributeName.TEMPLATE, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.COLORPOOL, 0x66666611);
         elemInfoTable[1] = new ElemInfoTable(ElementName.DEPENDENCIES, 0x66666611);
         elemInfoTable[2] = new ElemInfoTable(ElementName.ELEMENTCOLORPARAMS, 0x66666611);
         elemInfoTable[3] = new ElemInfoTable(ElementName.FILESPEC, 0x66666666);
         elemInfoTable[4] = new ElemInfoTable(ElementName.IMAGECOMPRESSIONPARAMS, 0x66666611);
         elemInfoTable[5] = new ElemInfoTable(ElementName.PAGELIST, 0x66666611);
         elemInfoTable[6] = new ElemInfoTable(ElementName.SCREENINGPARAMS, 0x66666611);
         elemInfoTable[7] = new ElemInfoTable(ElementName.SEPARATIONSPEC, 0x33333333);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[8];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoLayoutElement </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoLayoutElement(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoLayoutElement </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoLayoutElement(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoLayoutElement </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoLayoutElement(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoLayoutElement[  --> " + base.ToString() + " ]";
      }


      public override bool init()
      {
         bool bRet = base.init();
         setResourceClass(JDFResource.EnumResourceClass.Parameter);
         return bRet;
      }


      public override EnumResourceClass getValidClass()
      {
         return JDFResource.EnumResourceClass.Parameter;
      }


      ///        
      ///        <summary> * Enumeration strings for ElementType </summary>
      ///        

      public class EnumElementType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumElementType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumElementType getEnum(string enumName)
         {
            return (EnumElementType)getEnum(typeof(EnumElementType), enumName);
         }

         public static EnumElementType getEnum(int enumValue)
         {
            return (EnumElementType)getEnum(typeof(EnumElementType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumElementType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumElementType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumElementType));
         }

         public static readonly EnumElementType Auxiliary = new EnumElementType("Auxiliary");
         public static readonly EnumElementType Barcode = new EnumElementType("Barcode");
         public static readonly EnumElementType Composed = new EnumElementType("Composed");
         public static readonly EnumElementType Document = new EnumElementType("Document");
         public static readonly EnumElementType Graphic = new EnumElementType("Graphic");
         public static readonly EnumElementType IdentificationField = new EnumElementType("IdentificationField");
         public static readonly EnumElementType Image = new EnumElementType("Image");
         public static readonly EnumElementType MultiDocument = new EnumElementType("MultiDocument");
         public static readonly EnumElementType MultiSet = new EnumElementType("MultiSet");
         public static readonly EnumElementType Page = new EnumElementType("Page");
         public static readonly EnumElementType Reservation = new EnumElementType("Reservation");
         public static readonly EnumElementType Surface = new EnumElementType("Surface");
         public static readonly EnumElementType Text = new EnumElementType("Text");
         public static readonly EnumElementType Tile = new EnumElementType("Tile");
         public static readonly EnumElementType Unknown = new EnumElementType("Unknown");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute IgnorePDLCopies
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute IgnorePDLCopies </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setIgnorePDLCopies(bool @value)
      {
         setAttribute(AttributeName.IGNOREPDLCOPIES, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute IgnorePDLCopies </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getIgnorePDLCopies()
      {
         return getBoolAttribute(AttributeName.IGNOREPDLCOPIES, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute IgnorePDLImposition
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute IgnorePDLImposition </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setIgnorePDLImposition(bool @value)
      {
         setAttribute(AttributeName.IGNOREPDLIMPOSITION, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute IgnorePDLImposition </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getIgnorePDLImposition()
      {
         return getBoolAttribute(AttributeName.IGNOREPDLIMPOSITION, null, true);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ClipPath
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ClipPath </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setClipPath(string @value)
      {
         setAttribute(AttributeName.CLIPPATH, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ClipPath </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getClipPath()
      {
         return getAttribute(AttributeName.CLIPPATH, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ElementType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute ElementType </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setElementType(EnumElementType enumVar)
      {
         setAttribute(AttributeName.ELEMENTTYPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute ElementType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumElementType getElementType()
      {
         return EnumElementType.getEnum(getAttribute(AttributeName.ELEMENTTYPE, null, null));
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
      //        Methods for Attribute IsPrintable
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute IsPrintable </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setIsPrintable(bool @value)
      {
         setAttribute(AttributeName.ISPRINTABLE, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute IsPrintable </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getIsPrintable()
      {
         return getBoolAttribute(AttributeName.ISPRINTABLE, null, false);
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
      //        Methods for Attribute PageListIndex
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PageListIndex </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPageListIndex(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.PAGELISTINDEX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerRangeList attribute PageListIndex </summary>
      ///          * <returns> JDFIntegerRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerRangeList </returns>
      ///          
      public virtual JDFIntegerRangeList getPageListIndex()
      {
         string strAttrName = "";
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.PAGELISTINDEX, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute SourceBleedBox
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SourceBleedBox </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSourceBleedBox(JDFRectangle @value)
      {
         setAttribute(AttributeName.SOURCEBLEEDBOX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFRectangle attribute SourceBleedBox </summary>
      ///          * <returns> JDFRectangle the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFRectangle </returns>
      ///          
      public virtual JDFRectangle getSourceBleedBox()
      {
         string strAttrName = "";
         JDFRectangle nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.SOURCEBLEEDBOX, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFRectangle(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SourceClipBox
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SourceClipBox </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSourceClipBox(JDFRectangle @value)
      {
         setAttribute(AttributeName.SOURCECLIPBOX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFRectangle attribute SourceClipBox </summary>
      ///          * <returns> JDFRectangle the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFRectangle </returns>
      ///          
      public virtual JDFRectangle getSourceClipBox()
      {
         string strAttrName = "";
         JDFRectangle nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.SOURCECLIPBOX, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFRectangle(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SourceTrimBox
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SourceTrimBox </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSourceTrimBox(JDFRectangle @value)
      {
         setAttribute(AttributeName.SOURCETRIMBOX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFRectangle attribute SourceTrimBox </summary>
      ///          * <returns> JDFRectangle the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFRectangle </returns>
      ///          
      public virtual JDFRectangle getSourceTrimBox()
      {
         string strAttrName = "";
         JDFRectangle nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.SOURCETRIMBOX, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFRectangle(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Template
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Template </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTemplate(bool @value)
      {
         setAttribute(AttributeName.TEMPLATE, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute Template </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getTemplate()
      {
         return getBoolAttribute(AttributeName.TEMPLATE, null, false);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element ColorPool </summary>
      ///     * <returns> JDFColorPool the element </returns>
      ///     
      public virtual JDFColorPool getColorPool()
      {
         return (JDFColorPool)getElement(ElementName.COLORPOOL, null, 0);
      }

      ///     <summary> (25) getCreateColorPool
      ///     *  </summary>
      ///     * <returns> JDFColorPool the element </returns>
      ///     
      public virtual JDFColorPool getCreateColorPool()
      {
         return (JDFColorPool)getCreateElement_KElement(ElementName.COLORPOOL, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ColorPool </summary>
      ///     
      public virtual JDFColorPool appendColorPool()
      {
         return (JDFColorPool)appendElementN(ElementName.COLORPOOL, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refColorPool(JDFColorPool refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element Dependencies </summary>
      ///     * <returns> JDFDependencies the element </returns>
      ///     
      public virtual JDFDependencies getDependencies()
      {
         return (JDFDependencies)getElement(ElementName.DEPENDENCIES, null, 0);
      }

      ///     <summary> (25) getCreateDependencies
      ///     *  </summary>
      ///     * <returns> JDFDependencies the element </returns>
      ///     
      public virtual JDFDependencies getCreateDependencies()
      {
         return (JDFDependencies)getCreateElement_KElement(ElementName.DEPENDENCIES, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Dependencies </summary>
      ///     
      public virtual JDFDependencies appendDependencies()
      {
         return (JDFDependencies)appendElementN(ElementName.DEPENDENCIES, 1, null);
      }

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
      ///     <summary> * (24) const get element FileSpec </summary>
      ///     * <returns> JDFFileSpec the element </returns>
      ///     
      public virtual JDFFileSpec getFileSpec()
      {
         return (JDFFileSpec)getElement(ElementName.FILESPEC, null, 0);
      }

      ///     <summary> (25) getCreateFileSpec
      ///     *  </summary>
      ///     * <returns> JDFFileSpec the element </returns>
      ///     
      public virtual JDFFileSpec getCreateFileSpec()
      {
         return (JDFFileSpec)getCreateElement_KElement(ElementName.FILESPEC, null, 0);
      }

      ///    
      ///     <summary> * (29) append element FileSpec </summary>
      ///     
      public virtual JDFFileSpec appendFileSpec()
      {
         return (JDFFileSpec)appendElementN(ElementName.FILESPEC, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refFileSpec(JDFFileSpec refTarget)
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
      ///     <summary> * (24) const get element PageList </summary>
      ///     * <returns> JDFPageList the element </returns>
      ///     
      public virtual JDFPageList getPageList()
      {
         return (JDFPageList)getElement(ElementName.PAGELIST, null, 0);
      }

      ///     <summary> (25) getCreatePageList
      ///     *  </summary>
      ///     * <returns> JDFPageList the element </returns>
      ///     
      public virtual JDFPageList getCreatePageList()
      {
         return (JDFPageList)getCreateElement_KElement(ElementName.PAGELIST, null, 0);
      }

      ///    
      ///     <summary> * (29) append element PageList </summary>
      ///     
      public virtual JDFPageList appendPageList()
      {
         return (JDFPageList)appendElementN(ElementName.PAGELIST, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refPageList(JDFPageList refTarget)
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
