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
   using JDFIntegerRangeList = org.cip4.jdflib.datatypes.JDFIntegerRangeList;
   using JDFPreflightInstanceDetail = org.cip4.jdflib.resource.process.prepress.JDFPreflightInstanceDetail;

   public abstract class JDFAutoPreflightInstance : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[2];
      static JDFAutoPreflightInstance()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.IDENTIFIER, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.PAGEREFS, 0x33333333, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.PREFLIGHTINSTANCEDETAIL, 0x33333333);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[1];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoPreflightInstance </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPreflightInstance(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPreflightInstance </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPreflightInstance(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPreflightInstance </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoPreflightInstance(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoPreflightInstance[  --> " + base.ToString() + " ]";
      }


      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute Identifier
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Identifier </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setIdentifier(string @value)
      {
         setAttribute(AttributeName.IDENTIFIER, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Identifier </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getIdentifier()
      {
         return getAttribute(AttributeName.IDENTIFIER, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PageRefs
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PageRefs </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPageRefs(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.PAGEREFS, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerRangeList attribute PageRefs </summary>
      ///          * <returns> JDFIntegerRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerRangeList </returns>
      ///          
      public virtual JDFIntegerRangeList getPageRefs()
      {
         string strAttrName = "";
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.PAGEREFS, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFIntegerRangeList(strAttrName);
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

      ///     <summary> (26) getCreatePreflightInstanceDetail
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFPreflightInstanceDetail the element </returns>
      ///     
      public virtual JDFPreflightInstanceDetail getCreatePreflightInstanceDetail(int iSkip)
      {
         return (JDFPreflightInstanceDetail)getCreateElement_KElement(ElementName.PREFLIGHTINSTANCEDETAIL, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element PreflightInstanceDetail </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFPreflightInstanceDetail the element </returns>
      ///     * default is getPreflightInstanceDetail(0)     
      public virtual JDFPreflightInstanceDetail getPreflightInstanceDetail(int iSkip)
      {
         return (JDFPreflightInstanceDetail)getElement(ElementName.PREFLIGHTINSTANCEDETAIL, null, iSkip);
      }

      ///    
      ///     <summary> * Get all PreflightInstanceDetail from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFPreflightInstanceDetail> </returns>
      ///     
      public virtual ICollection<JDFPreflightInstanceDetail> getAllPreflightInstanceDetail()
      {
         List<JDFPreflightInstanceDetail> v = new List<JDFPreflightInstanceDetail>();

         JDFPreflightInstanceDetail kElem = (JDFPreflightInstanceDetail)getFirstChildElement(ElementName.PREFLIGHTINSTANCEDETAIL, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFPreflightInstanceDetail)kElem.getNextSiblingElement(ElementName.PREFLIGHTINSTANCEDETAIL, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element PreflightInstanceDetail </summary>
      ///     
      public virtual JDFPreflightInstanceDetail appendPreflightInstanceDetail()
      {
         return (JDFPreflightInstanceDetail)appendElement(ElementName.PREFLIGHTINSTANCEDETAIL, null);
      }
   }
}
