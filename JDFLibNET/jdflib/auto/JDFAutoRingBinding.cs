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
   using JDFNameSpan = org.cip4.jdflib.span.JDFNameSpan;
   using JDFNumberSpan = org.cip4.jdflib.span.JDFNumberSpan;
   using JDFOptionSpan = org.cip4.jdflib.span.JDFOptionSpan;
   using JDFSpanHoleType = org.cip4.jdflib.span.JDFSpanHoleType;
   using JDFStringSpan = org.cip4.jdflib.span.JDFStringSpan;

   public abstract class JDFAutoRingBinding : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[9];
      static JDFAutoRingBinding()
      {
         elemInfoTable[0] = new ElemInfoTable(ElementName.BINDERBRAND, 0x66666111);
         elemInfoTable[1] = new ElemInfoTable(ElementName.BINDERMATERIAL, 0x66666666);
         elemInfoTable[2] = new ElemInfoTable(ElementName.HOLETYPE, 0x66666661);
         elemInfoTable[3] = new ElemInfoTable(ElementName.RINGDIAMETER, 0x66666666);
         elemInfoTable[4] = new ElemInfoTable(ElementName.RINGMECHANIC, 0x66666666);
         elemInfoTable[5] = new ElemInfoTable(ElementName.RINGSHAPE, 0x66666666);
         elemInfoTable[6] = new ElemInfoTable(ElementName.RINGSYSTEM, 0x77777776);
         elemInfoTable[7] = new ElemInfoTable(ElementName.RIVETSEXPOSED, 0x66666666);
         elemInfoTable[8] = new ElemInfoTable(ElementName.VIEWBINDER, 0x66666666);
      }

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoRingBinding </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoRingBinding(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoRingBinding </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoRingBinding(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoRingBinding </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoRingBinding(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoRingBinding[  --> " + base.ToString() + " ]";
      }


      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element BinderBrand </summary>
      ///     * <returns> JDFStringSpan the element </returns>
      ///     
      public virtual JDFStringSpan getBinderBrand()
      {
         return (JDFStringSpan)getElement(ElementName.BINDERBRAND, null, 0);
      }

      ///     <summary> (25) getCreateBinderBrand
      ///     *  </summary>
      ///     * <returns> JDFStringSpan the element </returns>
      ///     
      public virtual JDFStringSpan getCreateBinderBrand()
      {
         return (JDFStringSpan)getCreateElement_KElement(ElementName.BINDERBRAND, null, 0);
      }

      ///    
      ///     <summary> * (29) append element BinderBrand </summary>
      ///     
      public virtual JDFStringSpan appendBinderBrand()
      {
         return (JDFStringSpan)appendElementN(ElementName.BINDERBRAND, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element BinderMaterial </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getBinderMaterial()
      {
         return (JDFNameSpan)getElement(ElementName.BINDERMATERIAL, null, 0);
      }

      ///     <summary> (25) getCreateBinderMaterial
      ///     *  </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getCreateBinderMaterial()
      {
         return (JDFNameSpan)getCreateElement_KElement(ElementName.BINDERMATERIAL, null, 0);
      }

      ///    
      ///     <summary> * (29) append element BinderMaterial </summary>
      ///     
      public virtual JDFNameSpan appendBinderMaterial()
      {
         return (JDFNameSpan)appendElementN(ElementName.BINDERMATERIAL, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element HoleType </summary>
      ///     * <returns> JDFSpanHoleType the element </returns>
      ///     
      public virtual JDFSpanHoleType getHoleType()
      {
         return (JDFSpanHoleType)getElement(ElementName.HOLETYPE, null, 0);
      }

      ///     <summary> (25) getCreateHoleType
      ///     *  </summary>
      ///     * <returns> JDFSpanHoleType the element </returns>
      ///     
      public virtual JDFSpanHoleType getCreateHoleType()
      {
         return (JDFSpanHoleType)getCreateElement_KElement(ElementName.HOLETYPE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element HoleType </summary>
      ///     
      public virtual JDFSpanHoleType appendHoleType()
      {
         return (JDFSpanHoleType)appendElementN(ElementName.HOLETYPE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element RingDiameter </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getRingDiameter()
      {
         return (JDFNumberSpan)getElement(ElementName.RINGDIAMETER, null, 0);
      }

      ///     <summary> (25) getCreateRingDiameter
      ///     *  </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getCreateRingDiameter()
      {
         return (JDFNumberSpan)getCreateElement_KElement(ElementName.RINGDIAMETER, null, 0);
      }

      ///    
      ///     <summary> * (29) append element RingDiameter </summary>
      ///     
      public virtual JDFNumberSpan appendRingDiameter()
      {
         return (JDFNumberSpan)appendElementN(ElementName.RINGDIAMETER, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element RingMechanic </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getRingMechanic()
      {
         return (JDFOptionSpan)getElement(ElementName.RINGMECHANIC, null, 0);
      }

      ///     <summary> (25) getCreateRingMechanic
      ///     *  </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getCreateRingMechanic()
      {
         return (JDFOptionSpan)getCreateElement_KElement(ElementName.RINGMECHANIC, null, 0);
      }

      ///    
      ///     <summary> * (29) append element RingMechanic </summary>
      ///     
      public virtual JDFOptionSpan appendRingMechanic()
      {
         return (JDFOptionSpan)appendElementN(ElementName.RINGMECHANIC, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element RingShape </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getRingShape()
      {
         return (JDFNameSpan)getElement(ElementName.RINGSHAPE, null, 0);
      }

      ///     <summary> (25) getCreateRingShape
      ///     *  </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getCreateRingShape()
      {
         return (JDFNameSpan)getCreateElement_KElement(ElementName.RINGSHAPE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element RingShape </summary>
      ///     
      public virtual JDFNameSpan appendRingShape()
      {
         return (JDFNameSpan)appendElementN(ElementName.RINGSHAPE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element RingSystem </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getRingSystem()
      {
         return (JDFNameSpan)getElement(ElementName.RINGSYSTEM, null, 0);
      }

      ///     <summary> (25) getCreateRingSystem
      ///     *  </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getCreateRingSystem()
      {
         return (JDFNameSpan)getCreateElement_KElement(ElementName.RINGSYSTEM, null, 0);
      }

      ///    
      ///     <summary> * (29) append element RingSystem </summary>
      ///     
      public virtual JDFNameSpan appendRingSystem()
      {
         return (JDFNameSpan)appendElementN(ElementName.RINGSYSTEM, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element RivetsExposed </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getRivetsExposed()
      {
         return (JDFOptionSpan)getElement(ElementName.RIVETSEXPOSED, null, 0);
      }

      ///     <summary> (25) getCreateRivetsExposed
      ///     *  </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getCreateRivetsExposed()
      {
         return (JDFOptionSpan)getCreateElement_KElement(ElementName.RIVETSEXPOSED, null, 0);
      }

      ///    
      ///     <summary> * (29) append element RivetsExposed </summary>
      ///     
      public virtual JDFOptionSpan appendRivetsExposed()
      {
         return (JDFOptionSpan)appendElementN(ElementName.RIVETSEXPOSED, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element ViewBinder </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getViewBinder()
      {
         return (JDFNameSpan)getElement(ElementName.VIEWBINDER, null, 0);
      }

      ///     <summary> (25) getCreateViewBinder
      ///     *  </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getCreateViewBinder()
      {
         return (JDFNameSpan)getCreateElement_KElement(ElementName.VIEWBINDER, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ViewBinder </summary>
      ///     
      public virtual JDFNameSpan appendViewBinder()
      {
         return (JDFNameSpan)appendElementN(ElementName.VIEWBINDER, 1, null);
      }
   }
}
