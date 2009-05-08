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
   using JDFOptionSpan = org.cip4.jdflib.span.JDFOptionSpan;
   using JDFStringSpan = org.cip4.jdflib.span.JDFStringSpan;

   public abstract class JDFAutoChannelBinding : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[3];
      static JDFAutoChannelBinding()
      {
         elemInfoTable[0] = new ElemInfoTable(ElementName.CHANNELBRAND, 0x66666111);
         elemInfoTable[1] = new ElemInfoTable(ElementName.COVER, 0x66666666);
         elemInfoTable[2] = new ElemInfoTable(ElementName.THICKNESS, 0x66666666);
      }

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoChannelBinding </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoChannelBinding(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoChannelBinding </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoChannelBinding(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoChannelBinding </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoChannelBinding(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoChannelBinding[  --> " + base.ToString() + " ]";
      }


      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element ChannelBrand </summary>
      ///     * <returns> JDFStringSpan the element </returns>
      ///     
      public virtual JDFStringSpan getChannelBrand()
      {
         return (JDFStringSpan)getElement(ElementName.CHANNELBRAND, null, 0);
      }

      ///     <summary> (25) getCreateChannelBrand
      ///     *  </summary>
      ///     * <returns> JDFStringSpan the element </returns>
      ///     
      public virtual JDFStringSpan getCreateChannelBrand()
      {
         return (JDFStringSpan)getCreateElement_KElement(ElementName.CHANNELBRAND, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ChannelBrand </summary>
      ///     
      public virtual JDFStringSpan appendChannelBrand()
      {
         return (JDFStringSpan)appendElementN(ElementName.CHANNELBRAND, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element Cover </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getCover()
      {
         return (JDFOptionSpan)getElement(ElementName.COVER, null, 0);
      }

      ///     <summary> (25) getCreateCover
      ///     *  </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getCreateCover()
      {
         return (JDFOptionSpan)getCreateElement_KElement(ElementName.COVER, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Cover </summary>
      ///     
      public virtual JDFOptionSpan appendCover()
      {
         return (JDFOptionSpan)appendElementN(ElementName.COVER, 1, null);
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
   }
}