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
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFLongFold = org.cip4.jdflib.resource.process.JDFLongFold;
   using JDFLongGlue = org.cip4.jdflib.resource.process.JDFLongGlue;
   using JDFLongPerforate = org.cip4.jdflib.resource.process.JDFLongPerforate;
   using JDFLongSlit = org.cip4.jdflib.resource.process.JDFLongSlit;

   public abstract class JDFAutoLongitudinalRibbonOperationParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[4];
      static JDFAutoLongitudinalRibbonOperationParams()
      {
         elemInfoTable[0] = new ElemInfoTable(ElementName.LONGFOLD, 0x44444443);
         elemInfoTable[1] = new ElemInfoTable(ElementName.LONGGLUE, 0x44444443);
         elemInfoTable[2] = new ElemInfoTable(ElementName.LONGPERFORATE, 0x44444443);
         elemInfoTable[3] = new ElemInfoTable(ElementName.LONGSLIT, 0x44444443);
      }

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoLongitudinalRibbonOperationParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoLongitudinalRibbonOperationParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoLongitudinalRibbonOperationParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoLongitudinalRibbonOperationParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoLongitudinalRibbonOperationParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoLongitudinalRibbonOperationParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoLongitudinalRibbonOperationParams[  --> " + base.ToString() + " ]";
      }


      public override bool init()
      {
         bool bRet = base.init();
         setResourceClass(JDFResource.EnumResourceClass.Parameter);
         return bRet;
      }


      public override EnumResourceClass getValidClass()
      {
         return JDFResource.EnumResourceClass.Parameter;
      }


      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateLongFold
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFLongFold the element </returns>
      ///     
      public virtual JDFLongFold getCreateLongFold(int iSkip)
      {
         return (JDFLongFold)getCreateElement_KElement(ElementName.LONGFOLD, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element LongFold </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFLongFold the element </returns>
      ///     * default is getLongFold(0)     
      public virtual JDFLongFold getLongFold(int iSkip)
      {
         return (JDFLongFold)getElement(ElementName.LONGFOLD, null, iSkip);
      }

      ///    
      ///     <summary> * Get all LongFold from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFLongFold> </returns>
      ///     
      public virtual ICollection<JDFLongFold> getAllLongFold()
      {
         List<JDFLongFold> v = new List<JDFLongFold>();

         JDFLongFold kElem = (JDFLongFold)getFirstChildElement(ElementName.LONGFOLD, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFLongFold)kElem.getNextSiblingElement(ElementName.LONGFOLD, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element LongFold </summary>
      ///     
      public virtual JDFLongFold appendLongFold()
      {
         return (JDFLongFold)appendElement(ElementName.LONGFOLD, null);
      }

      ///     <summary> (26) getCreateLongGlue
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFLongGlue the element </returns>
      ///     
      public virtual JDFLongGlue getCreateLongGlue(int iSkip)
      {
         return (JDFLongGlue)getCreateElement_KElement(ElementName.LONGGLUE, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element LongGlue </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFLongGlue the element </returns>
      ///     * default is getLongGlue(0)     
      public virtual JDFLongGlue getLongGlue(int iSkip)
      {
         return (JDFLongGlue)getElement(ElementName.LONGGLUE, null, iSkip);
      }

      ///    
      ///     <summary> * Get all LongGlue from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFLongGlue> </returns>
      ///     
      public virtual ICollection<JDFLongGlue> getAllLongGlue()
      {
         List<JDFLongGlue> v = new List<JDFLongGlue>();

         JDFLongGlue kElem = (JDFLongGlue)getFirstChildElement(ElementName.LONGGLUE, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFLongGlue)kElem.getNextSiblingElement(ElementName.LONGGLUE, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element LongGlue </summary>
      ///     
      public virtual JDFLongGlue appendLongGlue()
      {
         return (JDFLongGlue)appendElement(ElementName.LONGGLUE, null);
      }

      ///     <summary> (26) getCreateLongPerforate
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFLongPerforate the element </returns>
      ///     
      public virtual JDFLongPerforate getCreateLongPerforate(int iSkip)
      {
         return (JDFLongPerforate)getCreateElement_KElement(ElementName.LONGPERFORATE, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element LongPerforate </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFLongPerforate the element </returns>
      ///     * default is getLongPerforate(0)     
      public virtual JDFLongPerforate getLongPerforate(int iSkip)
      {
         return (JDFLongPerforate)getElement(ElementName.LONGPERFORATE, null, iSkip);
      }

      ///    
      ///     <summary> * Get all LongPerforate from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFLongPerforate> </returns>
      ///     
      public virtual ICollection<JDFLongPerforate> getAllLongPerforate()
      {
         List<JDFLongPerforate> v = new List<JDFLongPerforate>();

         JDFLongPerforate kElem = (JDFLongPerforate)getFirstChildElement(ElementName.LONGPERFORATE, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFLongPerforate)kElem.getNextSiblingElement(ElementName.LONGPERFORATE, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element LongPerforate </summary>
      ///     
      public virtual JDFLongPerforate appendLongPerforate()
      {
         return (JDFLongPerforate)appendElement(ElementName.LONGPERFORATE, null);
      }

      ///     <summary> (26) getCreateLongSlit
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFLongSlit the element </returns>
      ///     
      public virtual JDFLongSlit getCreateLongSlit(int iSkip)
      {
         return (JDFLongSlit)getCreateElement_KElement(ElementName.LONGSLIT, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element LongSlit </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFLongSlit the element </returns>
      ///     * default is getLongSlit(0)     
      public virtual JDFLongSlit getLongSlit(int iSkip)
      {
         return (JDFLongSlit)getElement(ElementName.LONGSLIT, null, iSkip);
      }

      ///    
      ///     <summary> * Get all LongSlit from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFLongSlit> </returns>
      ///     
      public virtual ICollection<JDFLongSlit> getAllLongSlit()
      {
         List<JDFLongSlit> v = new List<JDFLongSlit>();

         JDFLongSlit kElem = (JDFLongSlit)getFirstChildElement(ElementName.LONGSLIT, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFLongSlit)kElem.getNextSiblingElement(ElementName.LONGSLIT, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element LongSlit </summary>
      ///     
      public virtual JDFLongSlit appendLongSlit()
      {
         return (JDFLongSlit)appendElement(ElementName.LONGSLIT, null);
      }
   }
}
