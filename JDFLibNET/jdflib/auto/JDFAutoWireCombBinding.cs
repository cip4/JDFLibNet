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
   using JDFHoleList = org.cip4.jdflib.resource.process.postpress.JDFHoleList;
   using JDFSpanWireCombMaterial = org.cip4.jdflib.span.JDFSpanWireCombMaterial;
   using JDFSpanWireCombShape = org.cip4.jdflib.span.JDFSpanWireCombShape;
   using JDFStringSpan = org.cip4.jdflib.span.JDFStringSpan;

   public abstract class JDFAutoWireCombBinding : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[4];
      static JDFAutoWireCombBinding()
      {
         elemInfoTable[0] = new ElemInfoTable(ElementName.WIRECOMBBRAND, 0x66666111);
         elemInfoTable[1] = new ElemInfoTable(ElementName.WIRECOMBMATERIAL, 0x66666666);
         elemInfoTable[2] = new ElemInfoTable(ElementName.WIRECOMBSHAPE, 0x66666666);
         elemInfoTable[3] = new ElemInfoTable(ElementName.HOLELIST, 0x66666611);
      }

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoWireCombBinding </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoWireCombBinding(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoWireCombBinding </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoWireCombBinding(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoWireCombBinding </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoWireCombBinding(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoWireCombBinding[  --> " + base.ToString() + " ]";
      }


      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element WireCombBrand </summary>
      ///     * <returns> JDFStringSpan the element </returns>
      ///     
      public virtual JDFStringSpan getWireCombBrand()
      {
         return (JDFStringSpan)getElement(ElementName.WIRECOMBBRAND, null, 0);
      }

      ///     <summary> (25) getCreateWireCombBrand
      ///     *  </summary>
      ///     * <returns> JDFStringSpan the element </returns>
      ///     
      public virtual JDFStringSpan getCreateWireCombBrand()
      {
         return (JDFStringSpan)getCreateElement_KElement(ElementName.WIRECOMBBRAND, null, 0);
      }

      ///    
      ///     <summary> * (29) append element WireCombBrand </summary>
      ///     
      public virtual JDFStringSpan appendWireCombBrand()
      {
         return (JDFStringSpan)appendElementN(ElementName.WIRECOMBBRAND, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element WireCombMaterial </summary>
      ///     * <returns> JDFSpanWireCombMaterial the element </returns>
      ///     
      public virtual JDFSpanWireCombMaterial getWireCombMaterial()
      {
         return (JDFSpanWireCombMaterial)getElement(ElementName.WIRECOMBMATERIAL, null, 0);
      }

      ///     <summary> (25) getCreateWireCombMaterial
      ///     *  </summary>
      ///     * <returns> JDFSpanWireCombMaterial the element </returns>
      ///     
      public virtual JDFSpanWireCombMaterial getCreateWireCombMaterial()
      {
         return (JDFSpanWireCombMaterial)getCreateElement_KElement(ElementName.WIRECOMBMATERIAL, null, 0);
      }

      ///    
      ///     <summary> * (29) append element WireCombMaterial </summary>
      ///     
      public virtual JDFSpanWireCombMaterial appendWireCombMaterial()
      {
         return (JDFSpanWireCombMaterial)appendElementN(ElementName.WIRECOMBMATERIAL, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element WireCombShape </summary>
      ///     * <returns> JDFSpanWireCombShape the element </returns>
      ///     
      public virtual JDFSpanWireCombShape getWireCombShape()
      {
         return (JDFSpanWireCombShape)getElement(ElementName.WIRECOMBSHAPE, null, 0);
      }

      ///     <summary> (25) getCreateWireCombShape
      ///     *  </summary>
      ///     * <returns> JDFSpanWireCombShape the element </returns>
      ///     
      public virtual JDFSpanWireCombShape getCreateWireCombShape()
      {
         return (JDFSpanWireCombShape)getCreateElement_KElement(ElementName.WIRECOMBSHAPE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element WireCombShape </summary>
      ///     
      public virtual JDFSpanWireCombShape appendWireCombShape()
      {
         return (JDFSpanWireCombShape)appendElementN(ElementName.WIRECOMBSHAPE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element HoleList </summary>
      ///     * <returns> JDFHoleList the element </returns>
      ///     
      public virtual JDFHoleList getHoleList()
      {
         return (JDFHoleList)getElement(ElementName.HOLELIST, null, 0);
      }

      ///     <summary> (25) getCreateHoleList
      ///     *  </summary>
      ///     * <returns> JDFHoleList the element </returns>
      ///     
      public virtual JDFHoleList getCreateHoleList()
      {
         return (JDFHoleList)getCreateElement_KElement(ElementName.HOLELIST, null, 0);
      }

      ///    
      ///     <summary> * (29) append element HoleList </summary>
      ///     
      public virtual JDFHoleList appendHoleList()
      {
         return (JDFHoleList)appendElementN(ElementName.HOLELIST, 1, null);
      }
   }
}
