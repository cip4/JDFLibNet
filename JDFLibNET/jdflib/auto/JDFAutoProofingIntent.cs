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
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFProofItem = org.cip4.jdflib.resource.JDFProofItem;
   using JDFIntentResource = org.cip4.jdflib.resource.intent.JDFIntentResource;

   public abstract class JDFAutoProofingIntent : JDFIntentResource
   {

      private new const long serialVersionUID = 1L;

      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[1];
      static JDFAutoProofingIntent()
      {
         elemInfoTable[0] = new ElemInfoTable(ElementName.PROOFITEM, 0x33333331);
      }

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoProofingIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoProofingIntent(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoProofingIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoProofingIntent(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoProofingIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoProofingIntent(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoProofingIntent[  --> " + base.ToString() + " ]";
      }


      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateProofItem
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFProofItem the element </returns>
      ///     
      public virtual JDFProofItem getCreateProofItem(int iSkip)
      {
         return (JDFProofItem)getCreateElement_KElement(ElementName.PROOFITEM, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element ProofItem </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFProofItem the element </returns>
      ///     * default is getProofItem(0)     
      public virtual JDFProofItem getProofItem(int iSkip)
      {
         return (JDFProofItem)getElement(ElementName.PROOFITEM, null, iSkip);
      }

      ///    
      ///     <summary> * Get all ProofItem from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFProofItem> </returns>
      ///     
      public virtual ICollection<JDFProofItem> getAllProofItem()
      {
         List<JDFProofItem> v = new List<JDFProofItem>();

         JDFProofItem kElem = (JDFProofItem)getFirstChildElement(ElementName.PROOFITEM, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFProofItem)kElem.getNextSiblingElement(ElementName.PROOFITEM, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element ProofItem </summary>
      ///     
      public virtual JDFProofItem appendProofItem()
      {
         return (JDFProofItem)appendElement(ElementName.PROOFITEM, null);
      }
   }
}
