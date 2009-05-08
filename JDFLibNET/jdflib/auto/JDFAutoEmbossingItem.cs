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


   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFNumberSpan = org.cip4.jdflib.span.JDFNumberSpan;
   using JDFSpanDirection = org.cip4.jdflib.span.JDFSpanDirection;
   using JDFSpanEdgeShape = org.cip4.jdflib.span.JDFSpanEdgeShape;
   using JDFSpanLevel = org.cip4.jdflib.span.JDFSpanLevel;
   using JDFSpanNamedColor = org.cip4.jdflib.span.JDFSpanNamedColor;
   using JDFStringSpan = org.cip4.jdflib.span.JDFStringSpan;
   using JDFXYPairSpan = org.cip4.jdflib.span.JDFXYPairSpan;

   public abstract class JDFAutoEmbossingItem : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[9];
      static JDFAutoEmbossingItem()
      {
         elemInfoTable[0] = new ElemInfoTable(ElementName.DIRECTION, 0x55555551);
         elemInfoTable[1] = new ElemInfoTable(ElementName.EDGEANGLE, 0x66666661);
         elemInfoTable[2] = new ElemInfoTable(ElementName.EDGESHAPE, 0x66666661);
         elemInfoTable[3] = new ElemInfoTable(ElementName.EMBOSSINGTYPE, 0x66666661);
         elemInfoTable[4] = new ElemInfoTable(ElementName.FOILCOLOR, 0x66666661);
         elemInfoTable[5] = new ElemInfoTable(ElementName.HEIGHT, 0x66666661);
         elemInfoTable[6] = new ElemInfoTable(ElementName.IMAGESIZE, 0x66666661);
         elemInfoTable[7] = new ElemInfoTable(ElementName.LEVEL, 0x66666661);
         elemInfoTable[8] = new ElemInfoTable(ElementName.POSITION, 0x66666661);
      }

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoEmbossingItem </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoEmbossingItem(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoEmbossingItem </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoEmbossingItem(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoEmbossingItem </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoEmbossingItem(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoEmbossingItem[  --> " + base.ToString() + " ]";
      }


      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element Direction </summary>
      ///     * <returns> JDFSpanDirection the element </returns>
      ///     
      public virtual JDFSpanDirection getDirection()
      {
         return (JDFSpanDirection)getElement(ElementName.DIRECTION, null, 0);
      }

      ///     <summary> (25) getCreateDirection
      ///     *  </summary>
      ///     * <returns> JDFSpanDirection the element </returns>
      ///     
      public virtual JDFSpanDirection getCreateDirection()
      {
         return (JDFSpanDirection)getCreateElement_KElement(ElementName.DIRECTION, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Direction </summary>
      ///     
      public virtual JDFSpanDirection appendDirection()
      {
         return (JDFSpanDirection)appendElementN(ElementName.DIRECTION, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element EdgeAngle </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getEdgeAngle()
      {
         return (JDFNumberSpan)getElement(ElementName.EDGEANGLE, null, 0);
      }

      ///     <summary> (25) getCreateEdgeAngle
      ///     *  </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getCreateEdgeAngle()
      {
         return (JDFNumberSpan)getCreateElement_KElement(ElementName.EDGEANGLE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element EdgeAngle </summary>
      ///     
      public virtual JDFNumberSpan appendEdgeAngle()
      {
         return (JDFNumberSpan)appendElementN(ElementName.EDGEANGLE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element EdgeShape </summary>
      ///     * <returns> JDFSpanEdgeShape the element </returns>
      ///     
      public virtual JDFSpanEdgeShape getEdgeShape()
      {
         return (JDFSpanEdgeShape)getElement(ElementName.EDGESHAPE, null, 0);
      }

      ///     <summary> (25) getCreateEdgeShape
      ///     *  </summary>
      ///     * <returns> JDFSpanEdgeShape the element </returns>
      ///     
      public virtual JDFSpanEdgeShape getCreateEdgeShape()
      {
         return (JDFSpanEdgeShape)getCreateElement_KElement(ElementName.EDGESHAPE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element EdgeShape </summary>
      ///     
      public virtual JDFSpanEdgeShape appendEdgeShape()
      {
         return (JDFSpanEdgeShape)appendElementN(ElementName.EDGESHAPE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element EmbossingType </summary>
      ///     * <returns> JDFStringSpan the element </returns>
      ///     
      public virtual JDFStringSpan getEmbossingType()
      {
         return (JDFStringSpan)getElement(ElementName.EMBOSSINGTYPE, null, 0);
      }

      ///     <summary> (25) getCreateEmbossingType
      ///     *  </summary>
      ///     * <returns> JDFStringSpan the element </returns>
      ///     
      public virtual JDFStringSpan getCreateEmbossingType()
      {
         return (JDFStringSpan)getCreateElement_KElement(ElementName.EMBOSSINGTYPE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element EmbossingType </summary>
      ///     
      public virtual JDFStringSpan appendEmbossingType()
      {
         return (JDFStringSpan)appendElementN(ElementName.EMBOSSINGTYPE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element FoilColor </summary>
      ///     * <returns> JDFSpanNamedColor the element </returns>
      ///     
      public virtual JDFSpanNamedColor getFoilColor()
      {
         return (JDFSpanNamedColor)getElement(ElementName.FOILCOLOR, null, 0);
      }

      ///     <summary> (25) getCreateFoilColor
      ///     *  </summary>
      ///     * <returns> JDFSpanNamedColor the element </returns>
      ///     
      public virtual JDFSpanNamedColor getCreateFoilColor()
      {
         return (JDFSpanNamedColor)getCreateElement_KElement(ElementName.FOILCOLOR, null, 0);
      }

      ///    
      ///     <summary> * (29) append element FoilColor </summary>
      ///     
      public virtual JDFSpanNamedColor appendFoilColor()
      {
         return (JDFSpanNamedColor)appendElementN(ElementName.FOILCOLOR, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element Height </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getHeight()
      {
         return (JDFNumberSpan)getElement(ElementName.HEIGHT, null, 0);
      }

      ///     <summary> (25) getCreateHeight
      ///     *  </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getCreateHeight()
      {
         return (JDFNumberSpan)getCreateElement_KElement(ElementName.HEIGHT, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Height </summary>
      ///     
      public virtual JDFNumberSpan appendHeight()
      {
         return (JDFNumberSpan)appendElementN(ElementName.HEIGHT, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element ImageSize </summary>
      ///     * <returns> JDFXYPairSpan the element </returns>
      ///     
      public virtual JDFXYPairSpan getImageSize()
      {
         return (JDFXYPairSpan)getElement(ElementName.IMAGESIZE, null, 0);
      }

      ///     <summary> (25) getCreateImageSize
      ///     *  </summary>
      ///     * <returns> JDFXYPairSpan the element </returns>
      ///     
      public virtual JDFXYPairSpan getCreateImageSize()
      {
         return (JDFXYPairSpan)getCreateElement_KElement(ElementName.IMAGESIZE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ImageSize </summary>
      ///     
      public virtual JDFXYPairSpan appendImageSize()
      {
         return (JDFXYPairSpan)appendElementN(ElementName.IMAGESIZE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element Level </summary>
      ///     * <returns> JDFSpanLevel the element </returns>
      ///     
      public virtual JDFSpanLevel getLevel()
      {
         return (JDFSpanLevel)getElement(ElementName.LEVEL, null, 0);
      }

      ///     <summary> (25) getCreateLevel
      ///     *  </summary>
      ///     * <returns> JDFSpanLevel the element </returns>
      ///     
      public virtual JDFSpanLevel getCreateLevel()
      {
         return (JDFSpanLevel)getCreateElement_KElement(ElementName.LEVEL, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Level </summary>
      ///     
      public virtual JDFSpanLevel appendLevel()
      {
         return (JDFSpanLevel)appendElementN(ElementName.LEVEL, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element Position </summary>
      ///     * <returns> JDFXYPairSpan the element </returns>
      ///     
      public virtual JDFXYPairSpan getPosition()
      {
         return (JDFXYPairSpan)getElement(ElementName.POSITION, null, 0);
      }

      ///     <summary> (25) getCreatePosition
      ///     *  </summary>
      ///     * <returns> JDFXYPairSpan the element </returns>
      ///     
      public virtual JDFXYPairSpan getCreatePosition()
      {
         return (JDFXYPairSpan)getCreateElement_KElement(ElementName.POSITION, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Position </summary>
      ///     
      public virtual JDFXYPairSpan appendPosition()
      {
         return (JDFXYPairSpan)appendElementN(ElementName.POSITION, 1, null);
      }
   }
}
