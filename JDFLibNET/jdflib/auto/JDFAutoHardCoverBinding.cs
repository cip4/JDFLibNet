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



   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFRegisterRibbon = org.cip4.jdflib.resource.JDFRegisterRibbon;
   using JDFNameSpan = org.cip4.jdflib.span.JDFNameSpan;
   using JDFNumberSpan = org.cip4.jdflib.span.JDFNumberSpan;
   using JDFOptionSpan = org.cip4.jdflib.span.JDFOptionSpan;
   using JDFSpanGlue = org.cip4.jdflib.span.JDFSpanGlue;
   using JDFSpanJacket = org.cip4.jdflib.span.JDFSpanJacket;
   using JDFSpanNamedColor = org.cip4.jdflib.span.JDFSpanNamedColor;
   using JDFSpanStripMaterial = org.cip4.jdflib.span.JDFSpanStripMaterial;
   using JDFSpanTightBacking = org.cip4.jdflib.span.JDFSpanTightBacking;

   public abstract class JDFAutoHardCoverBinding : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[20];
      static JDFAutoHardCoverBinding()
      {
         elemInfoTable[0] = new ElemInfoTable(ElementName.BLOCKTHREADSEWING, 0x66666661);
         elemInfoTable[1] = new ElemInfoTable(ElementName.COVERSTYLE, 0x66666111);
         elemInfoTable[2] = new ElemInfoTable(ElementName.ENDSHEETS, 0x66666661);
         elemInfoTable[3] = new ElemInfoTable(ElementName.HEADBANDS, 0x66666661);
         elemInfoTable[4] = new ElemInfoTable(ElementName.HEADBANDCOLOR, 0x66666661);
         elemInfoTable[5] = new ElemInfoTable(ElementName.JACKET, 0x66666661);
         elemInfoTable[6] = new ElemInfoTable(ElementName.JACKETFOLDINGWIDTH, 0x66666111);
         elemInfoTable[7] = new ElemInfoTable(ElementName.JAPANBIND, 0x66666661);
         elemInfoTable[8] = new ElemInfoTable(ElementName.SPINEBRUSHING, 0x66666661);
         elemInfoTable[9] = new ElemInfoTable(ElementName.SPINEFIBERROUGHING, 0x66666661);
         elemInfoTable[10] = new ElemInfoTable(ElementName.SPINEGLUE, 0x66666661);
         elemInfoTable[11] = new ElemInfoTable(ElementName.SPINELEVELLING, 0x66666661);
         elemInfoTable[12] = new ElemInfoTable(ElementName.SPINEMILLING, 0x66666661);
         elemInfoTable[13] = new ElemInfoTable(ElementName.SPINENOTCHING, 0x66666661);
         elemInfoTable[14] = new ElemInfoTable(ElementName.SPINESANDING, 0x66666661);
         elemInfoTable[15] = new ElemInfoTable(ElementName.SPINESHREDDING, 0x66666661);
         elemInfoTable[16] = new ElemInfoTable(ElementName.STRIPMATERIAL, 0x66666661);
         elemInfoTable[17] = new ElemInfoTable(ElementName.TIGHTBACKING, 0x66666661);
         elemInfoTable[18] = new ElemInfoTable(ElementName.THICKNESS, 0x66666661);
         elemInfoTable[19] = new ElemInfoTable(ElementName.REGISTERRIBBON, 0x33333331);
      }

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoHardCoverBinding </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoHardCoverBinding(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoHardCoverBinding </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoHardCoverBinding(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoHardCoverBinding </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoHardCoverBinding(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoHardCoverBinding[  --> " + base.ToString() + " ]";
      }


      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element BlockThreadSewing </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getBlockThreadSewing()
      {
         return (JDFOptionSpan)getElement(ElementName.BLOCKTHREADSEWING, null, 0);
      }

      ///     <summary> (25) getCreateBlockThreadSewing
      ///     *  </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getCreateBlockThreadSewing()
      {
         return (JDFOptionSpan)getCreateElement_KElement(ElementName.BLOCKTHREADSEWING, null, 0);
      }

      ///    
      ///     <summary> * (29) append element BlockThreadSewing </summary>
      ///     
      public virtual JDFOptionSpan appendBlockThreadSewing()
      {
         return (JDFOptionSpan)appendElementN(ElementName.BLOCKTHREADSEWING, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element CoverStyle </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getCoverStyle()
      {
         return (JDFNameSpan)getElement(ElementName.COVERSTYLE, null, 0);
      }

      ///     <summary> (25) getCreateCoverStyle
      ///     *  </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getCreateCoverStyle()
      {
         return (JDFNameSpan)getCreateElement_KElement(ElementName.COVERSTYLE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element CoverStyle </summary>
      ///     
      public virtual JDFNameSpan appendCoverStyle()
      {
         return (JDFNameSpan)appendElementN(ElementName.COVERSTYLE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element EndSheets </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getEndSheets()
      {
         return (JDFOptionSpan)getElement(ElementName.ENDSHEETS, null, 0);
      }

      ///     <summary> (25) getCreateEndSheets
      ///     *  </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getCreateEndSheets()
      {
         return (JDFOptionSpan)getCreateElement_KElement(ElementName.ENDSHEETS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element EndSheets </summary>
      ///     
      public virtual JDFOptionSpan appendEndSheets()
      {
         return (JDFOptionSpan)appendElementN(ElementName.ENDSHEETS, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element HeadBands </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getHeadBands()
      {
         return (JDFOptionSpan)getElement(ElementName.HEADBANDS, null, 0);
      }

      ///     <summary> (25) getCreateHeadBands
      ///     *  </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getCreateHeadBands()
      {
         return (JDFOptionSpan)getCreateElement_KElement(ElementName.HEADBANDS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element HeadBands </summary>
      ///     
      public virtual JDFOptionSpan appendHeadBands()
      {
         return (JDFOptionSpan)appendElementN(ElementName.HEADBANDS, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element HeadBandColor </summary>
      ///     * <returns> JDFSpanNamedColor the element </returns>
      ///     
      public virtual JDFSpanNamedColor getHeadBandColor()
      {
         return (JDFSpanNamedColor)getElement(ElementName.HEADBANDCOLOR, null, 0);
      }

      ///     <summary> (25) getCreateHeadBandColor
      ///     *  </summary>
      ///     * <returns> JDFSpanNamedColor the element </returns>
      ///     
      public virtual JDFSpanNamedColor getCreateHeadBandColor()
      {
         return (JDFSpanNamedColor)getCreateElement_KElement(ElementName.HEADBANDCOLOR, null, 0);
      }

      ///    
      ///     <summary> * (29) append element HeadBandColor </summary>
      ///     
      public virtual JDFSpanNamedColor appendHeadBandColor()
      {
         return (JDFSpanNamedColor)appendElementN(ElementName.HEADBANDCOLOR, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element Jacket </summary>
      ///     * <returns> JDFSpanJacket the element </returns>
      ///     
      public virtual JDFSpanJacket getJacket()
      {
         return (JDFSpanJacket)getElement(ElementName.JACKET, null, 0);
      }

      ///     <summary> (25) getCreateJacket
      ///     *  </summary>
      ///     * <returns> JDFSpanJacket the element </returns>
      ///     
      public virtual JDFSpanJacket getCreateJacket()
      {
         return (JDFSpanJacket)getCreateElement_KElement(ElementName.JACKET, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Jacket </summary>
      ///     
      public virtual JDFSpanJacket appendJacket()
      {
         return (JDFSpanJacket)appendElementN(ElementName.JACKET, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element JacketFoldingWidth </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getJacketFoldingWidth()
      {
         return (JDFNumberSpan)getElement(ElementName.JACKETFOLDINGWIDTH, null, 0);
      }

      ///     <summary> (25) getCreateJacketFoldingWidth
      ///     *  </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getCreateJacketFoldingWidth()
      {
         return (JDFNumberSpan)getCreateElement_KElement(ElementName.JACKETFOLDINGWIDTH, null, 0);
      }

      ///    
      ///     <summary> * (29) append element JacketFoldingWidth </summary>
      ///     
      public virtual JDFNumberSpan appendJacketFoldingWidth()
      {
         return (JDFNumberSpan)appendElementN(ElementName.JACKETFOLDINGWIDTH, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element JapanBind </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getJapanBind()
      {
         return (JDFOptionSpan)getElement(ElementName.JAPANBIND, null, 0);
      }

      ///     <summary> (25) getCreateJapanBind
      ///     *  </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getCreateJapanBind()
      {
         return (JDFOptionSpan)getCreateElement_KElement(ElementName.JAPANBIND, null, 0);
      }

      ///    
      ///     <summary> * (29) append element JapanBind </summary>
      ///     
      public virtual JDFOptionSpan appendJapanBind()
      {
         return (JDFOptionSpan)appendElementN(ElementName.JAPANBIND, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element SpineBrushing </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getSpineBrushing()
      {
         return (JDFOptionSpan)getElement(ElementName.SPINEBRUSHING, null, 0);
      }

      ///     <summary> (25) getCreateSpineBrushing
      ///     *  </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getCreateSpineBrushing()
      {
         return (JDFOptionSpan)getCreateElement_KElement(ElementName.SPINEBRUSHING, null, 0);
      }

      ///    
      ///     <summary> * (29) append element SpineBrushing </summary>
      ///     
      public virtual JDFOptionSpan appendSpineBrushing()
      {
         return (JDFOptionSpan)appendElementN(ElementName.SPINEBRUSHING, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element SpineFiberRoughing </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getSpineFiberRoughing()
      {
         return (JDFOptionSpan)getElement(ElementName.SPINEFIBERROUGHING, null, 0);
      }

      ///     <summary> (25) getCreateSpineFiberRoughing
      ///     *  </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getCreateSpineFiberRoughing()
      {
         return (JDFOptionSpan)getCreateElement_KElement(ElementName.SPINEFIBERROUGHING, null, 0);
      }

      ///    
      ///     <summary> * (29) append element SpineFiberRoughing </summary>
      ///     
      public virtual JDFOptionSpan appendSpineFiberRoughing()
      {
         return (JDFOptionSpan)appendElementN(ElementName.SPINEFIBERROUGHING, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element SpineGlue </summary>
      ///     * <returns> JDFSpanGlue the element </returns>
      ///     
      public virtual JDFSpanGlue getSpineGlue()
      {
         return (JDFSpanGlue)getElement(ElementName.SPINEGLUE, null, 0);
      }

      ///     <summary> (25) getCreateSpineGlue
      ///     *  </summary>
      ///     * <returns> JDFSpanGlue the element </returns>
      ///     
      public virtual JDFSpanGlue getCreateSpineGlue()
      {
         return (JDFSpanGlue)getCreateElement_KElement(ElementName.SPINEGLUE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element SpineGlue </summary>
      ///     
      public virtual JDFSpanGlue appendSpineGlue()
      {
         return (JDFSpanGlue)appendElementN(ElementName.SPINEGLUE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element SpineLevelling </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getSpineLevelling()
      {
         return (JDFOptionSpan)getElement(ElementName.SPINELEVELLING, null, 0);
      }

      ///     <summary> (25) getCreateSpineLevelling
      ///     *  </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getCreateSpineLevelling()
      {
         return (JDFOptionSpan)getCreateElement_KElement(ElementName.SPINELEVELLING, null, 0);
      }

      ///    
      ///     <summary> * (29) append element SpineLevelling </summary>
      ///     
      public virtual JDFOptionSpan appendSpineLevelling()
      {
         return (JDFOptionSpan)appendElementN(ElementName.SPINELEVELLING, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element SpineMilling </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getSpineMilling()
      {
         return (JDFOptionSpan)getElement(ElementName.SPINEMILLING, null, 0);
      }

      ///     <summary> (25) getCreateSpineMilling
      ///     *  </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getCreateSpineMilling()
      {
         return (JDFOptionSpan)getCreateElement_KElement(ElementName.SPINEMILLING, null, 0);
      }

      ///    
      ///     <summary> * (29) append element SpineMilling </summary>
      ///     
      public virtual JDFOptionSpan appendSpineMilling()
      {
         return (JDFOptionSpan)appendElementN(ElementName.SPINEMILLING, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element SpineNotching </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getSpineNotching()
      {
         return (JDFOptionSpan)getElement(ElementName.SPINENOTCHING, null, 0);
      }

      ///     <summary> (25) getCreateSpineNotching
      ///     *  </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getCreateSpineNotching()
      {
         return (JDFOptionSpan)getCreateElement_KElement(ElementName.SPINENOTCHING, null, 0);
      }

      ///    
      ///     <summary> * (29) append element SpineNotching </summary>
      ///     
      public virtual JDFOptionSpan appendSpineNotching()
      {
         return (JDFOptionSpan)appendElementN(ElementName.SPINENOTCHING, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element SpineSanding </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getSpineSanding()
      {
         return (JDFOptionSpan)getElement(ElementName.SPINESANDING, null, 0);
      }

      ///     <summary> (25) getCreateSpineSanding
      ///     *  </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getCreateSpineSanding()
      {
         return (JDFOptionSpan)getCreateElement_KElement(ElementName.SPINESANDING, null, 0);
      }

      ///    
      ///     <summary> * (29) append element SpineSanding </summary>
      ///     
      public virtual JDFOptionSpan appendSpineSanding()
      {
         return (JDFOptionSpan)appendElementN(ElementName.SPINESANDING, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element SpineShredding </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getSpineShredding()
      {
         return (JDFOptionSpan)getElement(ElementName.SPINESHREDDING, null, 0);
      }

      ///     <summary> (25) getCreateSpineShredding
      ///     *  </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getCreateSpineShredding()
      {
         return (JDFOptionSpan)getCreateElement_KElement(ElementName.SPINESHREDDING, null, 0);
      }

      ///    
      ///     <summary> * (29) append element SpineShredding </summary>
      ///     
      public virtual JDFOptionSpan appendSpineShredding()
      {
         return (JDFOptionSpan)appendElementN(ElementName.SPINESHREDDING, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element StripMaterial </summary>
      ///     * <returns> JDFSpanStripMaterial the element </returns>
      ///     
      public virtual JDFSpanStripMaterial getStripMaterial()
      {
         return (JDFSpanStripMaterial)getElement(ElementName.STRIPMATERIAL, null, 0);
      }

      ///     <summary> (25) getCreateStripMaterial
      ///     *  </summary>
      ///     * <returns> JDFSpanStripMaterial the element </returns>
      ///     
      public virtual JDFSpanStripMaterial getCreateStripMaterial()
      {
         return (JDFSpanStripMaterial)getCreateElement_KElement(ElementName.STRIPMATERIAL, null, 0);
      }

      ///    
      ///     <summary> * (29) append element StripMaterial </summary>
      ///     
      public virtual JDFSpanStripMaterial appendStripMaterial()
      {
         return (JDFSpanStripMaterial)appendElementN(ElementName.STRIPMATERIAL, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element TightBacking </summary>
      ///     * <returns> JDFSpanTightBacking the element </returns>
      ///     
      public virtual JDFSpanTightBacking getTightBacking()
      {
         return (JDFSpanTightBacking)getElement(ElementName.TIGHTBACKING, null, 0);
      }

      ///     <summary> (25) getCreateTightBacking
      ///     *  </summary>
      ///     * <returns> JDFSpanTightBacking the element </returns>
      ///     
      public virtual JDFSpanTightBacking getCreateTightBacking()
      {
         return (JDFSpanTightBacking)getCreateElement_KElement(ElementName.TIGHTBACKING, null, 0);
      }

      ///    
      ///     <summary> * (29) append element TightBacking </summary>
      ///     
      public virtual JDFSpanTightBacking appendTightBacking()
      {
         return (JDFSpanTightBacking)appendElementN(ElementName.TIGHTBACKING, 1, null);
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
   }
}
