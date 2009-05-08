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
   using JDFNameSpan = org.cip4.jdflib.span.JDFNameSpan;
   using JDFNumberSpan = org.cip4.jdflib.span.JDFNumberSpan;
   using JDFOptionSpan = org.cip4.jdflib.span.JDFOptionSpan;
   using JDFSpanSurface = org.cip4.jdflib.span.JDFSpanSurface;
   using JDFSpanTemperature = org.cip4.jdflib.span.JDFSpanTemperature;

   public abstract class JDFAutoLaminatingIntent : JDFIntentResource
   {

      private new const long serialVersionUID = 1L;

      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[5];
      static JDFAutoLaminatingIntent()
      {
         elemInfoTable[0] = new ElemInfoTable(ElementName.LAMINATED, 0x77777776);
         elemInfoTable[1] = new ElemInfoTable(ElementName.TEMPERATURE, 0x55555555);
         elemInfoTable[2] = new ElemInfoTable(ElementName.SURFACE, 0x66666666);
         elemInfoTable[3] = new ElemInfoTable(ElementName.TEXTURE, 0x66666111);
         elemInfoTable[4] = new ElemInfoTable(ElementName.THICKNESS, 0x66666666);
      }

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoLaminatingIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoLaminatingIntent(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoLaminatingIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoLaminatingIntent(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoLaminatingIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoLaminatingIntent(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoLaminatingIntent[  --> " + base.ToString() + " ]";
      }


      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element Laminated </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getLaminated()
      {
         return (JDFOptionSpan)getElement(ElementName.LAMINATED, null, 0);
      }

      ///     <summary> (25) getCreateLaminated
      ///     *  </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getCreateLaminated()
      {
         return (JDFOptionSpan)getCreateElement_KElement(ElementName.LAMINATED, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Laminated </summary>
      ///     
      public virtual JDFOptionSpan appendLaminated()
      {
         return (JDFOptionSpan)appendElementN(ElementName.LAMINATED, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element Temperature </summary>
      ///     * <returns> JDFSpanTemperature the element </returns>
      ///     
      public virtual JDFSpanTemperature getTemperature()
      {
         return (JDFSpanTemperature)getElement(ElementName.TEMPERATURE, null, 0);
      }

      ///     <summary> (25) getCreateTemperature
      ///     *  </summary>
      ///     * <returns> JDFSpanTemperature the element </returns>
      ///     
      public virtual JDFSpanTemperature getCreateTemperature()
      {
         return (JDFSpanTemperature)getCreateElement_KElement(ElementName.TEMPERATURE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Temperature </summary>
      ///     
      public virtual JDFSpanTemperature appendTemperature()
      {
         return (JDFSpanTemperature)appendElementN(ElementName.TEMPERATURE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element Surface </summary>
      ///     * <returns> JDFSpanSurface the element </returns>
      ///     
      public virtual JDFSpanSurface getSurface()
      {
         return (JDFSpanSurface)getElement(ElementName.SURFACE, null, 0);
      }

      ///     <summary> (25) getCreateSurface
      ///     *  </summary>
      ///     * <returns> JDFSpanSurface the element </returns>
      ///     
      public virtual JDFSpanSurface getCreateSurface()
      {
         return (JDFSpanSurface)getCreateElement_KElement(ElementName.SURFACE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Surface </summary>
      ///     
      public virtual JDFSpanSurface appendSurface()
      {
         return (JDFSpanSurface)appendElementN(ElementName.SURFACE, 1, null);
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
   }
}
