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
   using JDFRectangle = org.cip4.jdflib.datatypes.JDFRectangle;
   using JDFNumberSpan = org.cip4.jdflib.span.JDFNumberSpan;
   using JDFSpanCutType = org.cip4.jdflib.span.JDFSpanCutType;
   using JDFSpanShapeType = org.cip4.jdflib.span.JDFSpanShapeType;
   using JDFStringSpan = org.cip4.jdflib.span.JDFStringSpan;

   public abstract class JDFAutoShapeCut : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[4];
      static JDFAutoShapeCut()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.CUTBOX, 0x33333333, AttributeInfo.EnumAttributeType.rectangle, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.CUTOUT, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.CUTPATH, 0x33333333, AttributeInfo.EnumAttributeType.PDFPath, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.PAGES, 0x33333333, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.MATERIAL, 0x66666666);
         elemInfoTable[1] = new ElemInfoTable(ElementName.CUTTYPE, 0x66666666);
         elemInfoTable[2] = new ElemInfoTable(ElementName.SHAPEDEPTH, 0x66666661);
         elemInfoTable[3] = new ElemInfoTable(ElementName.SHAPETYPE, 0x55555555);
         elemInfoTable[4] = new ElemInfoTable(ElementName.TEETHPERDIMENSION, 0x66666666);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[5];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoShapeCut </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoShapeCut(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoShapeCut </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoShapeCut(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoShapeCut </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoShapeCut(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoShapeCut[  --> " + base.ToString() + " ]";
      }


      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute CutBox
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CutBox </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCutBox(JDFRectangle @value)
      {
         setAttribute(AttributeName.CUTBOX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFRectangle attribute CutBox </summary>
      ///          * <returns> JDFRectangle the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFRectangle </returns>
      ///          
      public virtual JDFRectangle getCutBox()
      {
         string strAttrName = "";
         JDFRectangle nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.CUTBOX, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute CutOut
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CutOut </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCutOut(bool @value)
      {
         setAttribute(AttributeName.CUTOUT, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute CutOut </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getCutOut()
      {
         return getBoolAttribute(AttributeName.CUTOUT, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute CutPath
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CutPath </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCutPath(string @value)
      {
         setAttribute(AttributeName.CUTPATH, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute CutPath </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getCutPath()
      {
         return getAttribute(AttributeName.CUTPATH, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Pages
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Pages </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPages(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.PAGES, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerRangeList attribute Pages </summary>
      ///          * <returns> JDFIntegerRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerRangeList </returns>
      ///          
      public virtual JDFIntegerRangeList getPages()
      {
         string strAttrName = "";
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.PAGES, null, JDFConstants.EMPTYSTRING);
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

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element Material </summary>
      ///     * <returns> JDFStringSpan the element </returns>
      ///     
      public virtual JDFStringSpan getMaterial()
      {
         return (JDFStringSpan)getElement(ElementName.MATERIAL, null, 0);
      }

      ///     <summary> (25) getCreateMaterial
      ///     *  </summary>
      ///     * <returns> JDFStringSpan the element </returns>
      ///     
      public virtual JDFStringSpan getCreateMaterial()
      {
         return (JDFStringSpan)getCreateElement_KElement(ElementName.MATERIAL, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Material </summary>
      ///     
      public virtual JDFStringSpan appendMaterial()
      {
         return (JDFStringSpan)appendElementN(ElementName.MATERIAL, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element CutType </summary>
      ///     * <returns> JDFSpanCutType the element </returns>
      ///     
      public virtual JDFSpanCutType getCutType()
      {
         return (JDFSpanCutType)getElement(ElementName.CUTTYPE, null, 0);
      }

      ///     <summary> (25) getCreateCutType
      ///     *  </summary>
      ///     * <returns> JDFSpanCutType the element </returns>
      ///     
      public virtual JDFSpanCutType getCreateCutType()
      {
         return (JDFSpanCutType)getCreateElement_KElement(ElementName.CUTTYPE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element CutType </summary>
      ///     
      public virtual JDFSpanCutType appendCutType()
      {
         return (JDFSpanCutType)appendElementN(ElementName.CUTTYPE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element ShapeDepth </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getShapeDepth()
      {
         return (JDFNumberSpan)getElement(ElementName.SHAPEDEPTH, null, 0);
      }

      ///     <summary> (25) getCreateShapeDepth
      ///     *  </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getCreateShapeDepth()
      {
         return (JDFNumberSpan)getCreateElement_KElement(ElementName.SHAPEDEPTH, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ShapeDepth </summary>
      ///     
      public virtual JDFNumberSpan appendShapeDepth()
      {
         return (JDFNumberSpan)appendElementN(ElementName.SHAPEDEPTH, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element ShapeType </summary>
      ///     * <returns> JDFSpanShapeType the element </returns>
      ///     
      public virtual JDFSpanShapeType getShapeType()
      {
         return (JDFSpanShapeType)getElement(ElementName.SHAPETYPE, null, 0);
      }

      ///     <summary> (25) getCreateShapeType
      ///     *  </summary>
      ///     * <returns> JDFSpanShapeType the element </returns>
      ///     
      public virtual JDFSpanShapeType getCreateShapeType()
      {
         return (JDFSpanShapeType)getCreateElement_KElement(ElementName.SHAPETYPE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ShapeType </summary>
      ///     
      public virtual JDFSpanShapeType appendShapeType()
      {
         return (JDFSpanShapeType)appendElementN(ElementName.SHAPETYPE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element TeethPerDimension </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getTeethPerDimension()
      {
         return (JDFNumberSpan)getElement(ElementName.TEETHPERDIMENSION, null, 0);
      }

      ///     <summary> (25) getCreateTeethPerDimension
      ///     *  </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getCreateTeethPerDimension()
      {
         return (JDFNumberSpan)getCreateElement_KElement(ElementName.TEETHPERDIMENSION, null, 0);
      }

      ///    
      ///     <summary> * (29) append element TeethPerDimension </summary>
      ///     
      public virtual JDFNumberSpan appendTeethPerDimension()
      {
         return (JDFNumberSpan)appendElementN(ElementName.TEETHPERDIMENSION, 1, null);
      }
   }
}
