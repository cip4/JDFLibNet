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
   using JDFSeparationList = org.cip4.jdflib.core.JDFSeparationList;
   using JDFIntentResource = org.cip4.jdflib.resource.intent.JDFIntentResource;
   using JDFColorPool = org.cip4.jdflib.resource.process.JDFColorPool;
   using JDFNameSpan = org.cip4.jdflib.span.JDFNameSpan;
   using JDFNumberSpan = org.cip4.jdflib.span.JDFNumberSpan;
   using JDFStringSpan = org.cip4.jdflib.span.JDFStringSpan;

   public abstract class JDFAutoColorIntent : JDFIntentResource
   {

      private new const long serialVersionUID = 1L;

      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[7];
      static JDFAutoColorIntent()
      {
         elemInfoTable[0] = new ElemInfoTable(ElementName.COATINGS, 0x66666666);
         elemInfoTable[1] = new ElemInfoTable(ElementName.COLORSTANDARD, 0x66666666);
         elemInfoTable[2] = new ElemInfoTable(ElementName.COLORICCSTANDARD, 0x66666611);
         elemInfoTable[3] = new ElemInfoTable(ElementName.COVERAGE, 0x66666666);
         elemInfoTable[4] = new ElemInfoTable(ElementName.INKMANUFACTURER, 0x77777766);
         elemInfoTable[5] = new ElemInfoTable(ElementName.COLORPOOL, 0x66666661);
         elemInfoTable[6] = new ElemInfoTable(ElementName.COLORSUSED, 0x66666666);
      }

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoColorIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoColorIntent(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoColorIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoColorIntent(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoColorIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoColorIntent(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoColorIntent[  --> " + base.ToString() + " ]";
      }


      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element Coatings </summary>
      ///     * <returns> JDFStringSpan the element </returns>
      ///     
      public virtual JDFStringSpan getCoatings()
      {
         return (JDFStringSpan)getElement(ElementName.COATINGS, null, 0);
      }

      ///     <summary> (25) getCreateCoatings
      ///     *  </summary>
      ///     * <returns> JDFStringSpan the element </returns>
      ///     
      public virtual JDFStringSpan getCreateCoatings()
      {
         return (JDFStringSpan)getCreateElement_KElement(ElementName.COATINGS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Coatings </summary>
      ///     
      public virtual JDFStringSpan appendCoatings()
      {
         return (JDFStringSpan)appendElementN(ElementName.COATINGS, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element ColorStandard </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getColorStandard()
      {
         return (JDFNameSpan)getElement(ElementName.COLORSTANDARD, null, 0);
      }

      ///     <summary> (25) getCreateColorStandard
      ///     *  </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getCreateColorStandard()
      {
         return (JDFNameSpan)getCreateElement_KElement(ElementName.COLORSTANDARD, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ColorStandard </summary>
      ///     
      public virtual JDFNameSpan appendColorStandard()
      {
         return (JDFNameSpan)appendElementN(ElementName.COLORSTANDARD, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element ColorICCStandard </summary>
      ///     * <returns> JDFStringSpan the element </returns>
      ///     
      public virtual JDFStringSpan getColorICCStandard()
      {
         return (JDFStringSpan)getElement(ElementName.COLORICCSTANDARD, null, 0);
      }

      ///     <summary> (25) getCreateColorICCStandard
      ///     *  </summary>
      ///     * <returns> JDFStringSpan the element </returns>
      ///     
      public virtual JDFStringSpan getCreateColorICCStandard()
      {
         return (JDFStringSpan)getCreateElement_KElement(ElementName.COLORICCSTANDARD, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ColorICCStandard </summary>
      ///     
      public virtual JDFStringSpan appendColorICCStandard()
      {
         return (JDFStringSpan)appendElementN(ElementName.COLORICCSTANDARD, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element Coverage </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getCoverage()
      {
         return (JDFNumberSpan)getElement(ElementName.COVERAGE, null, 0);
      }

      ///     <summary> (25) getCreateCoverage
      ///     *  </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getCreateCoverage()
      {
         return (JDFNumberSpan)getCreateElement_KElement(ElementName.COVERAGE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Coverage </summary>
      ///     
      public virtual JDFNumberSpan appendCoverage()
      {
         return (JDFNumberSpan)appendElementN(ElementName.COVERAGE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element InkManufacturer </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getInkManufacturer()
      {
         return (JDFNameSpan)getElement(ElementName.INKMANUFACTURER, null, 0);
      }

      ///     <summary> (25) getCreateInkManufacturer
      ///     *  </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getCreateInkManufacturer()
      {
         return (JDFNameSpan)getCreateElement_KElement(ElementName.INKMANUFACTURER, null, 0);
      }

      ///    
      ///     <summary> * (29) append element InkManufacturer </summary>
      ///     
      public virtual JDFNameSpan appendInkManufacturer()
      {
         return (JDFNameSpan)appendElementN(ElementName.INKMANUFACTURER, 1, null);
      }

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
      ///     <summary> * (24) const get element ColorsUsed </summary>
      ///     * <returns> JDFSeparationList the element </returns>
      ///     
      public virtual JDFSeparationList getColorsUsed()
      {
         return (JDFSeparationList)getElement(ElementName.COLORSUSED, null, 0);
      }

      ///     <summary> (25) getCreateColorsUsed
      ///     *  </summary>
      ///     * <returns> JDFSeparationList the element </returns>
      ///     
      public virtual JDFSeparationList getCreateColorsUsed()
      {
         return (JDFSeparationList)getCreateElement_KElement(ElementName.COLORSUSED, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ColorsUsed </summary>
      ///     
      public virtual JDFSeparationList appendColorsUsed()
      {
         return (JDFSeparationList)appendElementN(ElementName.COLORSUSED, 1, null);
      }
   }
}
