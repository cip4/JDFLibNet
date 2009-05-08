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
   using JDFPRError = org.cip4.jdflib.resource.process.JDFPRError;
   using JDFPRGroup = org.cip4.jdflib.resource.process.JDFPRGroup;

   public abstract class JDFAutoPRItem : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[3];
      static JDFAutoPRItem()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ACTIONREF, 0x22222211, AttributeInfo.EnumAttributeType.IDREF, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.OCCURRENCES, 0x22222211, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.PAGESET, 0x33333311, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.PRERROR, 0x33333311);
         elemInfoTable[1] = new ElemInfoTable(ElementName.PRGROUP, 0x33333311);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[2];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoPRItem </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPRItem(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPRItem </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPRItem(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPRItem </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoPRItem(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoPRItem[  --> " + base.ToString() + " ]";
      }


      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute ActionRef
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ActionRef </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setActionRef(string @value)
      {
         setAttribute(AttributeName.ACTIONREF, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ActionRef </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getActionRef()
      {
         return getAttribute(AttributeName.ACTIONREF, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Occurrences
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Occurrences </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setOccurrences(int @value)
      {
         setAttribute(AttributeName.OCCURRENCES, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute Occurrences </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getOccurrences()
      {
         return getIntAttribute(AttributeName.OCCURRENCES, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PageSet
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PageSet </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPageSet(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.PAGESET, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerRangeList attribute PageSet </summary>
      ///          * <returns> JDFIntegerRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerRangeList </returns>
      ///          
      public virtual JDFIntegerRangeList getPageSet()
      {
         string strAttrName = "";
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.PAGESET, null, JDFConstants.EMPTYSTRING);
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

      ///     <summary> (26) getCreatePRError
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFPRError the element </returns>
      ///     
      public virtual JDFPRError getCreatePRError(int iSkip)
      {
         return (JDFPRError)getCreateElement_KElement(ElementName.PRERROR, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element PRError </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFPRError the element </returns>
      ///     * default is getPRError(0)     
      public virtual JDFPRError getPRError(int iSkip)
      {
         return (JDFPRError)getElement(ElementName.PRERROR, null, iSkip);
      }

      ///    
      ///     <summary> * Get all PRError from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFPRError> </returns>
      ///     
      public virtual ICollection<JDFPRError> getAllPRError()
      {
         List<JDFPRError> v = new List<JDFPRError>();

         JDFPRError kElem = (JDFPRError)getFirstChildElement(ElementName.PRERROR, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFPRError)kElem.getNextSiblingElement(ElementName.PRERROR, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element PRError </summary>
      ///     
      public virtual JDFPRError appendPRError()
      {
         return (JDFPRError)appendElement(ElementName.PRERROR, null);
      }

      ///     <summary> (26) getCreatePRGroup
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFPRGroup the element </returns>
      ///     
      public virtual JDFPRGroup getCreatePRGroup(int iSkip)
      {
         return (JDFPRGroup)getCreateElement_KElement(ElementName.PRGROUP, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element PRGroup </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFPRGroup the element </returns>
      ///     * default is getPRGroup(0)     
      public virtual JDFPRGroup getPRGroup(int iSkip)
      {
         return (JDFPRGroup)getElement(ElementName.PRGROUP, null, iSkip);
      }

      ///    
      ///     <summary> * Get all PRGroup from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFPRGroup> </returns>
      ///     
      public virtual ICollection<JDFPRGroup> getAllPRGroup()
      {
         List<JDFPRGroup> v = new List<JDFPRGroup>();

         JDFPRGroup kElem = (JDFPRGroup)getFirstChildElement(ElementName.PRGROUP, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFPRGroup)kElem.getNextSiblingElement(ElementName.PRGROUP, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element PRGroup </summary>
      ///     
      public virtual JDFPRGroup appendPRGroup()
      {
         return (JDFPRGroup)appendElement(ElementName.PRGROUP, null);
      }
   }
}
