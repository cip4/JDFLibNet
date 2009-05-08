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
   using System;
   using System.Collections.Generic;



   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFIntegerList = org.cip4.jdflib.datatypes.JDFIntegerList;
   using JDFIDPFolding = org.cip4.jdflib.resource.process.JDFIDPFolding;
   using JDFIDPHoleMaking = org.cip4.jdflib.resource.process.JDFIDPHoleMaking;
   using JDFIDPStitching = org.cip4.jdflib.resource.process.JDFIDPStitching;
   using JDFIDPTrimming = org.cip4.jdflib.resource.process.JDFIDPTrimming;

   public abstract class JDFAutoIDPFinishing : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[1];
      static JDFAutoIDPFinishing()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.FINISHINGS, 0x33333333, AttributeInfo.EnumAttributeType.IntegerList, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.IDPFOLDING, 0x33333333);
         elemInfoTable[1] = new ElemInfoTable(ElementName.IDPHOLEMAKING, 0x33333333);
         elemInfoTable[2] = new ElemInfoTable(ElementName.IDPSTITCHING, 0x33333333);
         elemInfoTable[3] = new ElemInfoTable(ElementName.IDPTRIMMING, 0x33333333);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[4];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoIDPFinishing </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoIDPFinishing(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoIDPFinishing </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoIDPFinishing(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoIDPFinishing </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoIDPFinishing(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoIDPFinishing[  --> " + base.ToString() + " ]";
      }


      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute Finishings
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Finishings </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFinishings(JDFIntegerList @value)
      {
         setAttribute(AttributeName.FINISHINGS, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerList attribute Finishings </summary>
      ///          * <returns> JDFIntegerList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerList </returns>
      ///          
      public virtual JDFIntegerList getFinishings()
      {
         string strAttrName = "";
         JDFIntegerList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.FINISHINGS, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFIntegerList(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateIDPFolding
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFIDPFolding the element </returns>
      ///     
      public virtual JDFIDPFolding getCreateIDPFolding(int iSkip)
      {
         return (JDFIDPFolding)getCreateElement_KElement(ElementName.IDPFOLDING, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element IDPFolding </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFIDPFolding the element </returns>
      ///     * default is getIDPFolding(0)     
      public virtual JDFIDPFolding getIDPFolding(int iSkip)
      {
         return (JDFIDPFolding)getElement(ElementName.IDPFOLDING, null, iSkip);
      }

      ///    
      ///     <summary> * Get all IDPFolding from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFIDPFolding> </returns>
      ///     
      public virtual ICollection<JDFIDPFolding> getAllIDPFolding()
      {
         List<JDFIDPFolding> v = new List<JDFIDPFolding>();

         JDFIDPFolding kElem = (JDFIDPFolding)getFirstChildElement(ElementName.IDPFOLDING, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFIDPFolding)kElem.getNextSiblingElement(ElementName.IDPFOLDING, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element IDPFolding </summary>
      ///     
      public virtual JDFIDPFolding appendIDPFolding()
      {
         return (JDFIDPFolding)appendElement(ElementName.IDPFOLDING, null);
      }

      ///     <summary> (26) getCreateIDPHoleMaking
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFIDPHoleMaking the element </returns>
      ///     
      public virtual JDFIDPHoleMaking getCreateIDPHoleMaking(int iSkip)
      {
         return (JDFIDPHoleMaking)getCreateElement_KElement(ElementName.IDPHOLEMAKING, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element IDPHoleMaking </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFIDPHoleMaking the element </returns>
      ///     * default is getIDPHoleMaking(0)     
      public virtual JDFIDPHoleMaking getIDPHoleMaking(int iSkip)
      {
         return (JDFIDPHoleMaking)getElement(ElementName.IDPHOLEMAKING, null, iSkip);
      }

      ///    
      ///     <summary> * Get all IDPHoleMaking from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFIDPHoleMaking> </returns>
      ///     
      public virtual ICollection<JDFIDPHoleMaking> getAllIDPHoleMaking()
      {
         List<JDFIDPHoleMaking> v = new List<JDFIDPHoleMaking>();

         JDFIDPHoleMaking kElem = (JDFIDPHoleMaking)getFirstChildElement(ElementName.IDPHOLEMAKING, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFIDPHoleMaking)kElem.getNextSiblingElement(ElementName.IDPHOLEMAKING, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element IDPHoleMaking </summary>
      ///     
      public virtual JDFIDPHoleMaking appendIDPHoleMaking()
      {
         return (JDFIDPHoleMaking)appendElement(ElementName.IDPHOLEMAKING, null);
      }

      ///     <summary> (26) getCreateIDPStitching
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFIDPStitching the element </returns>
      ///     
      public virtual JDFIDPStitching getCreateIDPStitching(int iSkip)
      {
         return (JDFIDPStitching)getCreateElement_KElement(ElementName.IDPSTITCHING, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element IDPStitching </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFIDPStitching the element </returns>
      ///     * default is getIDPStitching(0)     
      public virtual JDFIDPStitching getIDPStitching(int iSkip)
      {
         return (JDFIDPStitching)getElement(ElementName.IDPSTITCHING, null, iSkip);
      }

      ///    
      ///     <summary> * Get all IDPStitching from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFIDPStitching> </returns>
      ///     
      public virtual ICollection<JDFIDPStitching> getAllIDPStitching()
      {
         List<JDFIDPStitching> v = new List<JDFIDPStitching>();

         JDFIDPStitching kElem = (JDFIDPStitching)getFirstChildElement(ElementName.IDPSTITCHING, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFIDPStitching)kElem.getNextSiblingElement(ElementName.IDPSTITCHING, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element IDPStitching </summary>
      ///     
      public virtual JDFIDPStitching appendIDPStitching()
      {
         return (JDFIDPStitching)appendElement(ElementName.IDPSTITCHING, null);
      }

      ///     <summary> (26) getCreateIDPTrimming
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFIDPTrimming the element </returns>
      ///     
      public virtual JDFIDPTrimming getCreateIDPTrimming(int iSkip)
      {
         return (JDFIDPTrimming)getCreateElement_KElement(ElementName.IDPTRIMMING, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element IDPTrimming </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFIDPTrimming the element </returns>
      ///     * default is getIDPTrimming(0)     
      public virtual JDFIDPTrimming getIDPTrimming(int iSkip)
      {
         return (JDFIDPTrimming)getElement(ElementName.IDPTRIMMING, null, iSkip);
      }

      ///    
      ///     <summary> * Get all IDPTrimming from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFIDPTrimming> </returns>
      ///     
      public virtual ICollection<JDFIDPTrimming> getAllIDPTrimming()
      {
         List<JDFIDPTrimming> v = new List<JDFIDPTrimming>();

         JDFIDPTrimming kElem = (JDFIDPTrimming)getFirstChildElement(ElementName.IDPTRIMMING, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFIDPTrimming)kElem.getNextSiblingElement(ElementName.IDPTRIMMING, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element IDPTrimming </summary>
      ///     
      public virtual JDFIDPTrimming appendIDPTrimming()
      {
         return (JDFIDPTrimming)appendElement(ElementName.IDPTRIMMING, null);
      }
   }
}
