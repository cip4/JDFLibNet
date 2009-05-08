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
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFIntentResource = org.cip4.jdflib.resource.intent.JDFIntentResource;
   using JDFIntegerSpan = org.cip4.jdflib.span.JDFIntegerSpan;
   using JDFNameSpan = org.cip4.jdflib.span.JDFNameSpan;
   using JDFNumberSpan = org.cip4.jdflib.span.JDFNumberSpan;
   using JDFShapeSpan = org.cip4.jdflib.span.JDFShapeSpan;
   using JDFXYPairSpan = org.cip4.jdflib.span.JDFXYPairSpan;

   public abstract class JDFAutoPackingIntent : JDFIntentResource
   {

      private new const long serialVersionUID = 1L;

      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[16];
      static JDFAutoPackingIntent()
      {
         elemInfoTable[0] = new ElemInfoTable(ElementName.BOXEDQUANTITY, 0x66666666);
         elemInfoTable[1] = new ElemInfoTable(ElementName.BOXSHAPE, 0x66666666);
         elemInfoTable[2] = new ElemInfoTable(ElementName.CARTONQUANTITY, 0x66666666);
         elemInfoTable[3] = new ElemInfoTable(ElementName.CARTONSHAPE, 0x66666666);
         elemInfoTable[4] = new ElemInfoTable(ElementName.CARTONMAXWEIGHT, 0x66666666);
         elemInfoTable[5] = new ElemInfoTable(ElementName.CARTONSTRENGTH, 0x66666666);
         elemInfoTable[6] = new ElemInfoTable(ElementName.FOLDINGCATALOG, 0x66666666);
         elemInfoTable[7] = new ElemInfoTable(ElementName.PALLETCORNERBOARDS, 0x66666111);
         elemInfoTable[8] = new ElemInfoTable(ElementName.PALLETQUANTITY, 0x66666666);
         elemInfoTable[9] = new ElemInfoTable(ElementName.PALLETSIZE, 0x66666666);
         elemInfoTable[10] = new ElemInfoTable(ElementName.PALLETMAXHEIGHT, 0x66666666);
         elemInfoTable[11] = new ElemInfoTable(ElementName.PALLETMAXWEIGHT, 0x66666666);
         elemInfoTable[12] = new ElemInfoTable(ElementName.PALLETTYPE, 0x66666666);
         elemInfoTable[13] = new ElemInfoTable(ElementName.PALLETWRAPPING, 0x66666666);
         elemInfoTable[14] = new ElemInfoTable(ElementName.WRAPPEDQUANTITY, 0x66666666);
         elemInfoTable[15] = new ElemInfoTable(ElementName.WRAPPINGMATERIAL, 0x66666666);
      }

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoPackingIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPackingIntent(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPackingIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPackingIntent(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPackingIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoPackingIntent(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoPackingIntent[  --> " + base.ToString() + " ]";
      }


      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element BoxedQuantity </summary>
      ///     * <returns> JDFIntegerSpan the element </returns>
      ///     
      public virtual JDFIntegerSpan getBoxedQuantity()
      {
         return (JDFIntegerSpan)getElement(ElementName.BOXEDQUANTITY, null, 0);
      }

      ///     <summary> (25) getCreateBoxedQuantity
      ///     *  </summary>
      ///     * <returns> JDFIntegerSpan the element </returns>
      ///     
      public virtual JDFIntegerSpan getCreateBoxedQuantity()
      {
         return (JDFIntegerSpan)getCreateElement_KElement(ElementName.BOXEDQUANTITY, null, 0);
      }

      ///    
      ///     <summary> * (29) append element BoxedQuantity </summary>
      ///     
      public virtual JDFIntegerSpan appendBoxedQuantity()
      {
         return (JDFIntegerSpan)appendElementN(ElementName.BOXEDQUANTITY, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element BoxShape </summary>
      ///     * <returns> JDFShapeSpan the element </returns>
      ///     
      public virtual JDFShapeSpan getBoxShape()
      {
         return (JDFShapeSpan)getElement(ElementName.BOXSHAPE, null, 0);
      }

      ///     <summary> (25) getCreateBoxShape
      ///     *  </summary>
      ///     * <returns> JDFShapeSpan the element </returns>
      ///     
      public virtual JDFShapeSpan getCreateBoxShape()
      {
         return (JDFShapeSpan)getCreateElement_KElement(ElementName.BOXSHAPE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element BoxShape </summary>
      ///     
      public virtual JDFShapeSpan appendBoxShape()
      {
         return (JDFShapeSpan)appendElementN(ElementName.BOXSHAPE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element CartonQuantity </summary>
      ///     * <returns> JDFIntegerSpan the element </returns>
      ///     
      public virtual JDFIntegerSpan getCartonQuantity()
      {
         return (JDFIntegerSpan)getElement(ElementName.CARTONQUANTITY, null, 0);
      }

      ///     <summary> (25) getCreateCartonQuantity
      ///     *  </summary>
      ///     * <returns> JDFIntegerSpan the element </returns>
      ///     
      public virtual JDFIntegerSpan getCreateCartonQuantity()
      {
         return (JDFIntegerSpan)getCreateElement_KElement(ElementName.CARTONQUANTITY, null, 0);
      }

      ///    
      ///     <summary> * (29) append element CartonQuantity </summary>
      ///     
      public virtual JDFIntegerSpan appendCartonQuantity()
      {
         return (JDFIntegerSpan)appendElementN(ElementName.CARTONQUANTITY, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element CartonShape </summary>
      ///     * <returns> JDFShapeSpan the element </returns>
      ///     
      public virtual JDFShapeSpan getCartonShape()
      {
         return (JDFShapeSpan)getElement(ElementName.CARTONSHAPE, null, 0);
      }

      ///     <summary> (25) getCreateCartonShape
      ///     *  </summary>
      ///     * <returns> JDFShapeSpan the element </returns>
      ///     
      public virtual JDFShapeSpan getCreateCartonShape()
      {
         return (JDFShapeSpan)getCreateElement_KElement(ElementName.CARTONSHAPE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element CartonShape </summary>
      ///     
      public virtual JDFShapeSpan appendCartonShape()
      {
         return (JDFShapeSpan)appendElementN(ElementName.CARTONSHAPE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element CartonMaxWeight </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getCartonMaxWeight()
      {
         return (JDFNumberSpan)getElement(ElementName.CARTONMAXWEIGHT, null, 0);
      }

      ///     <summary> (25) getCreateCartonMaxWeight
      ///     *  </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getCreateCartonMaxWeight()
      {
         return (JDFNumberSpan)getCreateElement_KElement(ElementName.CARTONMAXWEIGHT, null, 0);
      }

      ///    
      ///     <summary> * (29) append element CartonMaxWeight </summary>
      ///     
      public virtual JDFNumberSpan appendCartonMaxWeight()
      {
         return (JDFNumberSpan)appendElementN(ElementName.CARTONMAXWEIGHT, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element CartonStrength </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getCartonStrength()
      {
         return (JDFNumberSpan)getElement(ElementName.CARTONSTRENGTH, null, 0);
      }

      ///     <summary> (25) getCreateCartonStrength
      ///     *  </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getCreateCartonStrength()
      {
         return (JDFNumberSpan)getCreateElement_KElement(ElementName.CARTONSTRENGTH, null, 0);
      }

      ///    
      ///     <summary> * (29) append element CartonStrength </summary>
      ///     
      public virtual JDFNumberSpan appendCartonStrength()
      {
         return (JDFNumberSpan)appendElementN(ElementName.CARTONSTRENGTH, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element FoldingCatalog </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getFoldingCatalog()
      {
         return (JDFNameSpan)getElement(ElementName.FOLDINGCATALOG, null, 0);
      }

      ///     <summary> (25) getCreateFoldingCatalog
      ///     *  </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getCreateFoldingCatalog()
      {
         return (JDFNameSpan)getCreateElement_KElement(ElementName.FOLDINGCATALOG, null, 0);
      }

      ///    
      ///     <summary> * (29) append element FoldingCatalog </summary>
      ///     
      public virtual JDFNameSpan appendFoldingCatalog()
      {
         return (JDFNameSpan)appendElementN(ElementName.FOLDINGCATALOG, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element PalletCornerBoards </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getPalletCornerBoards()
      {
         return (JDFNameSpan)getElement(ElementName.PALLETCORNERBOARDS, null, 0);
      }

      ///     <summary> (25) getCreatePalletCornerBoards
      ///     *  </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getCreatePalletCornerBoards()
      {
         return (JDFNameSpan)getCreateElement_KElement(ElementName.PALLETCORNERBOARDS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element PalletCornerBoards </summary>
      ///     
      public virtual JDFNameSpan appendPalletCornerBoards()
      {
         return (JDFNameSpan)appendElementN(ElementName.PALLETCORNERBOARDS, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element PalletQuantity </summary>
      ///     * <returns> JDFIntegerSpan the element </returns>
      ///     
      public virtual JDFIntegerSpan getPalletQuantity()
      {
         return (JDFIntegerSpan)getElement(ElementName.PALLETQUANTITY, null, 0);
      }

      ///     <summary> (25) getCreatePalletQuantity
      ///     *  </summary>
      ///     * <returns> JDFIntegerSpan the element </returns>
      ///     
      public virtual JDFIntegerSpan getCreatePalletQuantity()
      {
         return (JDFIntegerSpan)getCreateElement_KElement(ElementName.PALLETQUANTITY, null, 0);
      }

      ///    
      ///     <summary> * (29) append element PalletQuantity </summary>
      ///     
      public virtual JDFIntegerSpan appendPalletQuantity()
      {
         return (JDFIntegerSpan)appendElementN(ElementName.PALLETQUANTITY, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element PalletSize </summary>
      ///     * <returns> JDFXYPairSpan the element </returns>
      ///     
      public virtual JDFXYPairSpan getPalletSize()
      {
         return (JDFXYPairSpan)getElement(ElementName.PALLETSIZE, null, 0);
      }

      ///     <summary> (25) getCreatePalletSize
      ///     *  </summary>
      ///     * <returns> JDFXYPairSpan the element </returns>
      ///     
      public virtual JDFXYPairSpan getCreatePalletSize()
      {
         return (JDFXYPairSpan)getCreateElement_KElement(ElementName.PALLETSIZE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element PalletSize </summary>
      ///     
      public virtual JDFXYPairSpan appendPalletSize()
      {
         return (JDFXYPairSpan)appendElementN(ElementName.PALLETSIZE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element PalletMaxHeight </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getPalletMaxHeight()
      {
         return (JDFNumberSpan)getElement(ElementName.PALLETMAXHEIGHT, null, 0);
      }

      ///     <summary> (25) getCreatePalletMaxHeight
      ///     *  </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getCreatePalletMaxHeight()
      {
         return (JDFNumberSpan)getCreateElement_KElement(ElementName.PALLETMAXHEIGHT, null, 0);
      }

      ///    
      ///     <summary> * (29) append element PalletMaxHeight </summary>
      ///     
      public virtual JDFNumberSpan appendPalletMaxHeight()
      {
         return (JDFNumberSpan)appendElementN(ElementName.PALLETMAXHEIGHT, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element PalletMaxWeight </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getPalletMaxWeight()
      {
         return (JDFNumberSpan)getElement(ElementName.PALLETMAXWEIGHT, null, 0);
      }

      ///     <summary> (25) getCreatePalletMaxWeight
      ///     *  </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getCreatePalletMaxWeight()
      {
         return (JDFNumberSpan)getCreateElement_KElement(ElementName.PALLETMAXWEIGHT, null, 0);
      }

      ///    
      ///     <summary> * (29) append element PalletMaxWeight </summary>
      ///     
      public virtual JDFNumberSpan appendPalletMaxWeight()
      {
         return (JDFNumberSpan)appendElementN(ElementName.PALLETMAXWEIGHT, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element PalletType </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getPalletType()
      {
         return (JDFNameSpan)getElement(ElementName.PALLETTYPE, null, 0);
      }

      ///     <summary> (25) getCreatePalletType
      ///     *  </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getCreatePalletType()
      {
         return (JDFNameSpan)getCreateElement_KElement(ElementName.PALLETTYPE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element PalletType </summary>
      ///     
      public virtual JDFNameSpan appendPalletType()
      {
         return (JDFNameSpan)appendElementN(ElementName.PALLETTYPE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element PalletWrapping </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getPalletWrapping()
      {
         return (JDFNameSpan)getElement(ElementName.PALLETWRAPPING, null, 0);
      }

      ///     <summary> (25) getCreatePalletWrapping
      ///     *  </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getCreatePalletWrapping()
      {
         return (JDFNameSpan)getCreateElement_KElement(ElementName.PALLETWRAPPING, null, 0);
      }

      ///    
      ///     <summary> * (29) append element PalletWrapping </summary>
      ///     
      public virtual JDFNameSpan appendPalletWrapping()
      {
         return (JDFNameSpan)appendElementN(ElementName.PALLETWRAPPING, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element WrappedQuantity </summary>
      ///     * <returns> JDFIntegerSpan the element </returns>
      ///     
      public virtual JDFIntegerSpan getWrappedQuantity()
      {
         return (JDFIntegerSpan)getElement(ElementName.WRAPPEDQUANTITY, null, 0);
      }

      ///     <summary> (25) getCreateWrappedQuantity
      ///     *  </summary>
      ///     * <returns> JDFIntegerSpan the element </returns>
      ///     
      public virtual JDFIntegerSpan getCreateWrappedQuantity()
      {
         return (JDFIntegerSpan)getCreateElement_KElement(ElementName.WRAPPEDQUANTITY, null, 0);
      }

      ///    
      ///     <summary> * (29) append element WrappedQuantity </summary>
      ///     
      public virtual JDFIntegerSpan appendWrappedQuantity()
      {
         return (JDFIntegerSpan)appendElementN(ElementName.WRAPPEDQUANTITY, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element WrappingMaterial </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getWrappingMaterial()
      {
         return (JDFNameSpan)getElement(ElementName.WRAPPINGMATERIAL, null, 0);
      }

      ///     <summary> (25) getCreateWrappingMaterial
      ///     *  </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getCreateWrappingMaterial()
      {
         return (JDFNameSpan)getCreateElement_KElement(ElementName.WRAPPINGMATERIAL, null, 0);
      }

      ///    
      ///     <summary> * (29) append element WrappingMaterial </summary>
      ///     
      public virtual JDFNameSpan appendWrappingMaterial()
      {
         return (JDFNameSpan)appendElementN(ElementName.WRAPPINGMATERIAL, 1, null);
      }
   }
}
