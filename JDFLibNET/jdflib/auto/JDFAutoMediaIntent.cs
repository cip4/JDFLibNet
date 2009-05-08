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
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFIntentResource = org.cip4.jdflib.resource.intent.JDFIntentResource;
   using JDFIntegerSpan = org.cip4.jdflib.span.JDFIntegerSpan;
   using JDFNameSpan = org.cip4.jdflib.span.JDFNameSpan;
   using JDFNumberSpan = org.cip4.jdflib.span.JDFNumberSpan;
   using JDFOptionSpan = org.cip4.jdflib.span.JDFOptionSpan;
   using JDFSpanCoatings = org.cip4.jdflib.span.JDFSpanCoatings;
   using JDFSpanGrainDirection = org.cip4.jdflib.span.JDFSpanGrainDirection;
   using JDFSpanMediaType = org.cip4.jdflib.span.JDFSpanMediaType;
   using JDFSpanMediaUnit = org.cip4.jdflib.span.JDFSpanMediaUnit;
   using JDFSpanNamedColor = org.cip4.jdflib.span.JDFSpanNamedColor;
   using JDFSpanOpacity = org.cip4.jdflib.span.JDFSpanOpacity;
   using JDFStringSpan = org.cip4.jdflib.span.JDFStringSpan;
   using JDFXYPairSpan = org.cip4.jdflib.span.JDFXYPairSpan;

   public abstract class JDFAutoMediaIntent : JDFIntentResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[3];
      static JDFAutoMediaIntent()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.PREPRINTED, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.MEDIASETCOUNT, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.USERMEDIATYPE, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.BACKCOATINGS, 0x66666666);
         elemInfoTable[1] = new ElemInfoTable(ElementName.BRIGHTNESS, 0x66666666);
         elemInfoTable[2] = new ElemInfoTable(ElementName.BUYERSUPPLIED, 0x66666666);
         elemInfoTable[3] = new ElemInfoTable(ElementName.DIMENSIONS, 0x77777766);
         elemInfoTable[4] = new ElemInfoTable(ElementName.FRONTCOATINGS, 0x66666666);
         elemInfoTable[5] = new ElemInfoTable(ElementName.GRADE, 0x66666666);
         elemInfoTable[6] = new ElemInfoTable(ElementName.GRAINDIRECTION, 0x66666611);
         elemInfoTable[7] = new ElemInfoTable(ElementName.HOLECOUNT, 0x77777776);
         elemInfoTable[8] = new ElemInfoTable(ElementName.HOLETYPE, 0x66666661);
         elemInfoTable[9] = new ElemInfoTable(ElementName.MEDIACOLOR, 0x66666666);
         elemInfoTable[10] = new ElemInfoTable(ElementName.MEDIACOLORDETAILS, 0x66666611);
         elemInfoTable[11] = new ElemInfoTable(ElementName.MEDIATYPE, 0x66666661);
         elemInfoTable[12] = new ElemInfoTable(ElementName.MEDIATYPEDETAILS, 0x66666111);
         elemInfoTable[13] = new ElemInfoTable(ElementName.MEDIAUNIT, 0x77777766);
         elemInfoTable[14] = new ElemInfoTable(ElementName.OPACITY, 0x66666666);
         elemInfoTable[15] = new ElemInfoTable(ElementName.OPACITYLEVEL, 0x66666611);
         elemInfoTable[16] = new ElemInfoTable(ElementName.RECYCLED, 0x77777766);
         elemInfoTable[17] = new ElemInfoTable(ElementName.RECYCLEDPERCENTAGE, 0x66666611);
         elemInfoTable[18] = new ElemInfoTable(ElementName.STOCKBRAND, 0x66666666);
         elemInfoTable[19] = new ElemInfoTable(ElementName.STOCKTYPE, 0x66666666);
         elemInfoTable[20] = new ElemInfoTable(ElementName.TEXTURE, 0x66666666);
         elemInfoTable[21] = new ElemInfoTable(ElementName.THICKNESS, 0x66666661);
         elemInfoTable[22] = new ElemInfoTable(ElementName.USWEIGHT, 0x77777766);
         elemInfoTable[23] = new ElemInfoTable(ElementName.WEIGHT, 0x66666666);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[24];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoMediaIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoMediaIntent(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoMediaIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoMediaIntent(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoMediaIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoMediaIntent(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoMediaIntent[  --> " + base.ToString() + " ]";
      }


      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute PrePrinted
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PrePrinted </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPrePrinted(bool @value)
      {
         setAttribute(AttributeName.PREPRINTED, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute PrePrinted </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getPrePrinted()
      {
         return getBoolAttribute(AttributeName.PREPRINTED, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MediaSetCount
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MediaSetCount </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMediaSetCount(int @value)
      {
         setAttribute(AttributeName.MEDIASETCOUNT, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute MediaSetCount </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getMediaSetCount()
      {
         return getIntAttribute(AttributeName.MEDIASETCOUNT, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute UserMediaType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute UserMediaType </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setUserMediaType(string @value)
      {
         setAttribute(AttributeName.USERMEDIATYPE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute UserMediaType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getUserMediaType()
      {
         return getAttribute(AttributeName.USERMEDIATYPE, null, JDFConstants.EMPTYSTRING);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element BackCoatings </summary>
      ///     * <returns> JDFSpanCoatings the element </returns>
      ///     
      public virtual JDFSpanCoatings getBackCoatings()
      {
         return (JDFSpanCoatings)getElement(ElementName.BACKCOATINGS, null, 0);
      }

      ///     <summary> (25) getCreateBackCoatings
      ///     *  </summary>
      ///     * <returns> JDFSpanCoatings the element </returns>
      ///     
      public virtual JDFSpanCoatings getCreateBackCoatings()
      {
         return (JDFSpanCoatings)getCreateElement_KElement(ElementName.BACKCOATINGS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element BackCoatings </summary>
      ///     
      public virtual JDFSpanCoatings appendBackCoatings()
      {
         return (JDFSpanCoatings)appendElementN(ElementName.BACKCOATINGS, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element Brightness </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getBrightness()
      {
         return (JDFNumberSpan)getElement(ElementName.BRIGHTNESS, null, 0);
      }

      ///     <summary> (25) getCreateBrightness
      ///     *  </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getCreateBrightness()
      {
         return (JDFNumberSpan)getCreateElement_KElement(ElementName.BRIGHTNESS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Brightness </summary>
      ///     
      public virtual JDFNumberSpan appendBrightness()
      {
         return (JDFNumberSpan)appendElementN(ElementName.BRIGHTNESS, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element BuyerSupplied </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getBuyerSupplied()
      {
         return (JDFOptionSpan)getElement(ElementName.BUYERSUPPLIED, null, 0);
      }

      ///     <summary> (25) getCreateBuyerSupplied
      ///     *  </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getCreateBuyerSupplied()
      {
         return (JDFOptionSpan)getCreateElement_KElement(ElementName.BUYERSUPPLIED, null, 0);
      }

      ///    
      ///     <summary> * (29) append element BuyerSupplied </summary>
      ///     
      public virtual JDFOptionSpan appendBuyerSupplied()
      {
         return (JDFOptionSpan)appendElementN(ElementName.BUYERSUPPLIED, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element Dimensions </summary>
      ///     * <returns> JDFXYPairSpan the element </returns>
      ///     
      public virtual JDFXYPairSpan getDimensions()
      {
         return (JDFXYPairSpan)getElement(ElementName.DIMENSIONS, null, 0);
      }

      ///     <summary> (25) getCreateDimensions
      ///     *  </summary>
      ///     * <returns> JDFXYPairSpan the element </returns>
      ///     
      public virtual JDFXYPairSpan getCreateDimensions()
      {
         return (JDFXYPairSpan)getCreateElement_KElement(ElementName.DIMENSIONS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Dimensions </summary>
      ///     
      public virtual JDFXYPairSpan appendDimensions()
      {
         return (JDFXYPairSpan)appendElementN(ElementName.DIMENSIONS, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element FrontCoatings </summary>
      ///     * <returns> JDFSpanCoatings the element </returns>
      ///     
      public virtual JDFSpanCoatings getFrontCoatings()
      {
         return (JDFSpanCoatings)getElement(ElementName.FRONTCOATINGS, null, 0);
      }

      ///     <summary> (25) getCreateFrontCoatings
      ///     *  </summary>
      ///     * <returns> JDFSpanCoatings the element </returns>
      ///     
      public virtual JDFSpanCoatings getCreateFrontCoatings()
      {
         return (JDFSpanCoatings)getCreateElement_KElement(ElementName.FRONTCOATINGS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element FrontCoatings </summary>
      ///     
      public virtual JDFSpanCoatings appendFrontCoatings()
      {
         return (JDFSpanCoatings)appendElementN(ElementName.FRONTCOATINGS, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element Grade </summary>
      ///     * <returns> JDFIntegerSpan the element </returns>
      ///     
      public virtual JDFIntegerSpan getGrade()
      {
         return (JDFIntegerSpan)getElement(ElementName.GRADE, null, 0);
      }

      ///     <summary> (25) getCreateGrade
      ///     *  </summary>
      ///     * <returns> JDFIntegerSpan the element </returns>
      ///     
      public virtual JDFIntegerSpan getCreateGrade()
      {
         return (JDFIntegerSpan)getCreateElement_KElement(ElementName.GRADE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Grade </summary>
      ///     
      public virtual JDFIntegerSpan appendGrade()
      {
         return (JDFIntegerSpan)appendElementN(ElementName.GRADE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element GrainDirection </summary>
      ///     * <returns> JDFSpanGrainDirection the element </returns>
      ///     
      public virtual JDFSpanGrainDirection getGrainDirection()
      {
         return (JDFSpanGrainDirection)getElement(ElementName.GRAINDIRECTION, null, 0);
      }

      ///     <summary> (25) getCreateGrainDirection
      ///     *  </summary>
      ///     * <returns> JDFSpanGrainDirection the element </returns>
      ///     
      public virtual JDFSpanGrainDirection getCreateGrainDirection()
      {
         return (JDFSpanGrainDirection)getCreateElement_KElement(ElementName.GRAINDIRECTION, null, 0);
      }

      ///    
      ///     <summary> * (29) append element GrainDirection </summary>
      ///     
      public virtual JDFSpanGrainDirection appendGrainDirection()
      {
         return (JDFSpanGrainDirection)appendElementN(ElementName.GRAINDIRECTION, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element HoleCount </summary>
      ///     * <returns> JDFIntegerSpan the element </returns>
      ///     
      public virtual JDFIntegerSpan getHoleCount()
      {
         return (JDFIntegerSpan)getElement(ElementName.HOLECOUNT, null, 0);
      }

      ///     <summary> (25) getCreateHoleCount
      ///     *  </summary>
      ///     * <returns> JDFIntegerSpan the element </returns>
      ///     
      public virtual JDFIntegerSpan getCreateHoleCount()
      {
         return (JDFIntegerSpan)getCreateElement_KElement(ElementName.HOLECOUNT, null, 0);
      }

      ///    
      ///     <summary> * (29) append element HoleCount </summary>
      ///     
      public virtual JDFIntegerSpan appendHoleCount()
      {
         return (JDFIntegerSpan)appendElementN(ElementName.HOLECOUNT, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element HoleType </summary>
      ///     * <returns> JDFStringSpan the element </returns>
      ///     
      public virtual JDFStringSpan getHoleType()
      {
         return (JDFStringSpan)getElement(ElementName.HOLETYPE, null, 0);
      }

      ///     <summary> (25) getCreateHoleType
      ///     *  </summary>
      ///     * <returns> JDFStringSpan the element </returns>
      ///     
      public virtual JDFStringSpan getCreateHoleType()
      {
         return (JDFStringSpan)getCreateElement_KElement(ElementName.HOLETYPE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element HoleType </summary>
      ///     
      public virtual JDFStringSpan appendHoleType()
      {
         return (JDFStringSpan)appendElementN(ElementName.HOLETYPE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element MediaColor </summary>
      ///     * <returns> JDFSpanNamedColor the element </returns>
      ///     
      public virtual JDFSpanNamedColor getMediaColor()
      {
         return (JDFSpanNamedColor)getElement(ElementName.MEDIACOLOR, null, 0);
      }

      ///     <summary> (25) getCreateMediaColor
      ///     *  </summary>
      ///     * <returns> JDFSpanNamedColor the element </returns>
      ///     
      public virtual JDFSpanNamedColor getCreateMediaColor()
      {
         return (JDFSpanNamedColor)getCreateElement_KElement(ElementName.MEDIACOLOR, null, 0);
      }

      ///    
      ///     <summary> * (29) append element MediaColor </summary>
      ///     
      public virtual JDFSpanNamedColor appendMediaColor()
      {
         return (JDFSpanNamedColor)appendElementN(ElementName.MEDIACOLOR, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element MediaColorDetails </summary>
      ///     * <returns> JDFStringSpan the element </returns>
      ///     
      public virtual JDFStringSpan getMediaColorDetails()
      {
         return (JDFStringSpan)getElement(ElementName.MEDIACOLORDETAILS, null, 0);
      }

      ///     <summary> (25) getCreateMediaColorDetails
      ///     *  </summary>
      ///     * <returns> JDFStringSpan the element </returns>
      ///     
      public virtual JDFStringSpan getCreateMediaColorDetails()
      {
         return (JDFStringSpan)getCreateElement_KElement(ElementName.MEDIACOLORDETAILS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element MediaColorDetails </summary>
      ///     
      public virtual JDFStringSpan appendMediaColorDetails()
      {
         return (JDFStringSpan)appendElementN(ElementName.MEDIACOLORDETAILS, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element MediaType </summary>
      ///     * <returns> JDFSpanMediaType the element </returns>
      ///     
      public virtual JDFSpanMediaType getMediaType()
      {
         return (JDFSpanMediaType)getElement(ElementName.MEDIATYPE, null, 0);
      }

      ///     <summary> (25) getCreateMediaType
      ///     *  </summary>
      ///     * <returns> JDFSpanMediaType the element </returns>
      ///     
      public virtual JDFSpanMediaType getCreateMediaType()
      {
         return (JDFSpanMediaType)getCreateElement_KElement(ElementName.MEDIATYPE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element MediaType </summary>
      ///     
      public virtual JDFSpanMediaType appendMediaType()
      {
         return (JDFSpanMediaType)appendElementN(ElementName.MEDIATYPE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element MediaTypeDetails </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getMediaTypeDetails()
      {
         return (JDFNameSpan)getElement(ElementName.MEDIATYPEDETAILS, null, 0);
      }

      ///     <summary> (25) getCreateMediaTypeDetails
      ///     *  </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getCreateMediaTypeDetails()
      {
         return (JDFNameSpan)getCreateElement_KElement(ElementName.MEDIATYPEDETAILS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element MediaTypeDetails </summary>
      ///     
      public virtual JDFNameSpan appendMediaTypeDetails()
      {
         return (JDFNameSpan)appendElementN(ElementName.MEDIATYPEDETAILS, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element MediaUnit </summary>
      ///     * <returns> JDFSpanMediaUnit the element </returns>
      ///     
      public virtual JDFSpanMediaUnit getMediaUnit()
      {
         return (JDFSpanMediaUnit)getElement(ElementName.MEDIAUNIT, null, 0);
      }

      ///     <summary> (25) getCreateMediaUnit
      ///     *  </summary>
      ///     * <returns> JDFSpanMediaUnit the element </returns>
      ///     
      public virtual JDFSpanMediaUnit getCreateMediaUnit()
      {
         return (JDFSpanMediaUnit)getCreateElement_KElement(ElementName.MEDIAUNIT, null, 0);
      }

      ///    
      ///     <summary> * (29) append element MediaUnit </summary>
      ///     
      public virtual JDFSpanMediaUnit appendMediaUnit()
      {
         return (JDFSpanMediaUnit)appendElementN(ElementName.MEDIAUNIT, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element Opacity </summary>
      ///     * <returns> JDFSpanOpacity the element </returns>
      ///     
      public virtual JDFSpanOpacity getOpacity()
      {
         return (JDFSpanOpacity)getElement(ElementName.OPACITY, null, 0);
      }

      ///     <summary> (25) getCreateOpacity
      ///     *  </summary>
      ///     * <returns> JDFSpanOpacity the element </returns>
      ///     
      public virtual JDFSpanOpacity getCreateOpacity()
      {
         return (JDFSpanOpacity)getCreateElement_KElement(ElementName.OPACITY, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Opacity </summary>
      ///     
      public virtual JDFSpanOpacity appendOpacity()
      {
         return (JDFSpanOpacity)appendElementN(ElementName.OPACITY, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element OpacityLevel </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getOpacityLevel()
      {
         return (JDFNumberSpan)getElement(ElementName.OPACITYLEVEL, null, 0);
      }

      ///     <summary> (25) getCreateOpacityLevel
      ///     *  </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getCreateOpacityLevel()
      {
         return (JDFNumberSpan)getCreateElement_KElement(ElementName.OPACITYLEVEL, null, 0);
      }

      ///    
      ///     <summary> * (29) append element OpacityLevel </summary>
      ///     
      public virtual JDFNumberSpan appendOpacityLevel()
      {
         return (JDFNumberSpan)appendElementN(ElementName.OPACITYLEVEL, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element Recycled </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getRecycled()
      {
         return (JDFOptionSpan)getElement(ElementName.RECYCLED, null, 0);
      }

      ///     <summary> (25) getCreateRecycled
      ///     *  </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getCreateRecycled()
      {
         return (JDFOptionSpan)getCreateElement_KElement(ElementName.RECYCLED, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Recycled </summary>
      ///     
      public virtual JDFOptionSpan appendRecycled()
      {
         return (JDFOptionSpan)appendElementN(ElementName.RECYCLED, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element RecycledPercentage </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getRecycledPercentage()
      {
         return (JDFNumberSpan)getElement(ElementName.RECYCLEDPERCENTAGE, null, 0);
      }

      ///     <summary> (25) getCreateRecycledPercentage
      ///     *  </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getCreateRecycledPercentage()
      {
         return (JDFNumberSpan)getCreateElement_KElement(ElementName.RECYCLEDPERCENTAGE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element RecycledPercentage </summary>
      ///     
      public virtual JDFNumberSpan appendRecycledPercentage()
      {
         return (JDFNumberSpan)appendElementN(ElementName.RECYCLEDPERCENTAGE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element StockBrand </summary>
      ///     * <returns> JDFStringSpan the element </returns>
      ///     
      public virtual JDFStringSpan getStockBrand()
      {
         return (JDFStringSpan)getElement(ElementName.STOCKBRAND, null, 0);
      }

      ///     <summary> (25) getCreateStockBrand
      ///     *  </summary>
      ///     * <returns> JDFStringSpan the element </returns>
      ///     
      public virtual JDFStringSpan getCreateStockBrand()
      {
         return (JDFStringSpan)getCreateElement_KElement(ElementName.STOCKBRAND, null, 0);
      }

      ///    
      ///     <summary> * (29) append element StockBrand </summary>
      ///     
      public virtual JDFStringSpan appendStockBrand()
      {
         return (JDFStringSpan)appendElementN(ElementName.STOCKBRAND, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element StockType </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getStockType()
      {
         return (JDFNameSpan)getElement(ElementName.STOCKTYPE, null, 0);
      }

      ///     <summary> (25) getCreateStockType
      ///     *  </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getCreateStockType()
      {
         return (JDFNameSpan)getCreateElement_KElement(ElementName.STOCKTYPE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element StockType </summary>
      ///     
      public virtual JDFNameSpan appendStockType()
      {
         return (JDFNameSpan)appendElementN(ElementName.STOCKTYPE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element Texture </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getTexture()
      {
         return (JDFNameSpan)getElement(ElementName.TEXTURE, null, 0);
      }

      ///     <summary> (25) getCreateTexture
      ///     *  </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getCreateTexture()
      {
         return (JDFNameSpan)getCreateElement_KElement(ElementName.TEXTURE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Texture </summary>
      ///     
      public virtual JDFNameSpan appendTexture()
      {
         return (JDFNameSpan)appendElementN(ElementName.TEXTURE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element Thickness </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getThickness()
      {
         return (JDFNumberSpan)getElement(ElementName.THICKNESS, null, 0);
      }

      ///     <summary> (25) getCreateThickness
      ///     *  </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getCreateThickness()
      {
         return (JDFNumberSpan)getCreateElement_KElement(ElementName.THICKNESS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Thickness </summary>
      ///     
      public virtual JDFNumberSpan appendThickness()
      {
         return (JDFNumberSpan)appendElementN(ElementName.THICKNESS, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element USWeight </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getUSWeight()
      {
         return (JDFNumberSpan)getElement(ElementName.USWEIGHT, null, 0);
      }

      ///     <summary> (25) getCreateUSWeight
      ///     *  </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getCreateUSWeight()
      {
         return (JDFNumberSpan)getCreateElement_KElement(ElementName.USWEIGHT, null, 0);
      }

      ///    
      ///     <summary> * (29) append element USWeight </summary>
      ///     
      public virtual JDFNumberSpan appendUSWeight()
      {
         return (JDFNumberSpan)appendElementN(ElementName.USWEIGHT, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element Weight </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getWeight()
      {
         return (JDFNumberSpan)getElement(ElementName.WEIGHT, null, 0);
      }

      ///     <summary> (25) getCreateWeight
      ///     *  </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getCreateWeight()
      {
         return (JDFNumberSpan)getCreateElement_KElement(ElementName.WEIGHT, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Weight </summary>
      ///     
      public virtual JDFNumberSpan appendWeight()
      {
         return (JDFNumberSpan)appendElementN(ElementName.WEIGHT, 1, null);
      }
   }
}
