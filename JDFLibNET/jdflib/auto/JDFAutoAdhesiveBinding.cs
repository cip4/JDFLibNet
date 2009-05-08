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
   using JDFOptionSpan = org.cip4.jdflib.span.JDFOptionSpan;
   using JDFSpanGlue = org.cip4.jdflib.span.JDFSpanGlue;
   using JDFSpanScoring = org.cip4.jdflib.span.JDFSpanScoring;

   public abstract class JDFAutoAdhesiveBinding : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[3];
      static JDFAutoAdhesiveBinding()
      {
         elemInfoTable[0] = new ElemInfoTable(ElementName.SCORING, 0x77777776);
         elemInfoTable[1] = new ElemInfoTable(ElementName.SPINEGLUE, 0x77777776);
         elemInfoTable[2] = new ElemInfoTable(ElementName.TAPEBINDING, 0x77777776);
      }

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoAdhesiveBinding </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoAdhesiveBinding(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoAdhesiveBinding </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoAdhesiveBinding(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoAdhesiveBinding </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoAdhesiveBinding(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      /// <summary>
      /// String representation of this object
      /// </summary>
      /// <returns>string</returns>
      public override string ToString()
      {
         return " JDFAutoAdhesiveBinding[  --> " + base.ToString() + " ]";
      }


      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element Scoring </summary>
      ///     * <returns> JDFSpanScoring the element </returns>
      ///     
      public virtual JDFSpanScoring getScoring()
      {
         return (JDFSpanScoring)getElement(ElementName.SCORING, null, 0);
      }

      ///     <summary> (25) getCreateScoring
      ///     *  </summary>
      ///     * <returns> JDFSpanScoring the element </returns>
      ///     
      public virtual JDFSpanScoring getCreateScoring()
      {
         return (JDFSpanScoring)getCreateElement_KElement(ElementName.SCORING, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Scoring </summary>
      ///     
      public virtual JDFSpanScoring appendScoring()
      {
         return (JDFSpanScoring)appendElementN(ElementName.SCORING, 1, null);
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
      ///     <summary> * (24) const get element TapeBinding </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getTapeBinding()
      {
         return (JDFOptionSpan)getElement(ElementName.TAPEBINDING, null, 0);
      }

      ///     <summary> (25) getCreateTapeBinding
      ///     *  </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getCreateTapeBinding()
      {
         return (JDFOptionSpan)getCreateElement_KElement(ElementName.TAPEBINDING, null, 0);
      }

      ///    
      ///     <summary> * (29) append element TapeBinding </summary>
      ///     
      public virtual JDFOptionSpan appendTapeBinding()
      {
         return (JDFOptionSpan)appendElementN(ElementName.TAPEBINDING, 1, null);
      }
   }
}
