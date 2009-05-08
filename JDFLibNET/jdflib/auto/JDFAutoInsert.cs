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
   using JDFMatrix = org.cip4.jdflib.datatypes.JDFMatrix;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFGlueLine = org.cip4.jdflib.resource.process.postpress.JDFGlueLine;
   using JDFSpanGlueType = org.cip4.jdflib.span.JDFSpanGlueType;
   using JDFSpanMethod = org.cip4.jdflib.span.JDFSpanMethod;

   public abstract class JDFAutoInsert : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[4];
      static JDFAutoInsert()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.FOLIO, 0x22222222, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.SHEETOFFSET, 0x44444443, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.TRANSFORMATION, 0x33333333, AttributeInfo.EnumAttributeType.matrix, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.WRAPPAGES, 0x33333331, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.GLUETYPE, 0x66666666);
         elemInfoTable[1] = new ElemInfoTable(ElementName.METHOD, 0x66666666);
         elemInfoTable[2] = new ElemInfoTable(ElementName.GLUELINE, 0x33333331);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[3];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoInsert </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoInsert(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoInsert </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoInsert(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoInsert </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoInsert(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoInsert[  --> " + base.ToString() + " ]";
      }


      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute Folio
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Folio </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFolio(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.FOLIO, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerRangeList attribute Folio </summary>
      ///          * <returns> JDFIntegerRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerRangeList </returns>
      ///          
      public virtual JDFIntegerRangeList getFolio()
      {
         string strAttrName = "";
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.FOLIO, null, JDFConstants.EMPTYSTRING);
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


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SheetOffset
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SheetOffset </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSheetOffset(JDFXYPair @value)
      {
         setAttribute(AttributeName.SHEETOFFSET, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute SheetOffset </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getSheetOffset()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.SHEETOFFSET, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFXYPair(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Transformation
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Transformation </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTransformation(JDFMatrix @value)
      {
         setAttribute(AttributeName.TRANSFORMATION, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFMatrix attribute Transformation </summary>
      ///          * <returns> JDFMatrix the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFMatrix </returns>
      ///          
      public virtual JDFMatrix getTransformation()
      {
         string strAttrName = "";
         JDFMatrix nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.TRANSFORMATION, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFMatrix(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute WrapPages
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute WrapPages </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setWrapPages(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.WRAPPAGES, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerRangeList attribute WrapPages </summary>
      ///          * <returns> JDFIntegerRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerRangeList </returns>
      ///          
      public virtual JDFIntegerRangeList getWrapPages()
      {
         string strAttrName = "";
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.WRAPPAGES, null, JDFConstants.EMPTYSTRING);
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

      ///    
      ///     <summary> * (24) const get element GlueType </summary>
      ///     * <returns> JDFSpanGlueType the element </returns>
      ///     
      public virtual JDFSpanGlueType getGlueType()
      {
         return (JDFSpanGlueType)getElement(ElementName.GLUETYPE, null, 0);
      }

      ///     <summary> (25) getCreateGlueType
      ///     *  </summary>
      ///     * <returns> JDFSpanGlueType the element </returns>
      ///     
      public virtual JDFSpanGlueType getCreateGlueType()
      {
         return (JDFSpanGlueType)getCreateElement_KElement(ElementName.GLUETYPE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element GlueType </summary>
      ///     
      public virtual JDFSpanGlueType appendGlueType()
      {
         return (JDFSpanGlueType)appendElementN(ElementName.GLUETYPE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element Method </summary>
      ///     * <returns> JDFSpanMethod the element </returns>
      ///     
      public virtual JDFSpanMethod getMethod()
      {
         return (JDFSpanMethod)getElement(ElementName.METHOD, null, 0);
      }

      ///     <summary> (25) getCreateMethod
      ///     *  </summary>
      ///     * <returns> JDFSpanMethod the element </returns>
      ///     
      public virtual JDFSpanMethod getCreateMethod()
      {
         return (JDFSpanMethod)getCreateElement_KElement(ElementName.METHOD, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Method </summary>
      ///     
      public virtual JDFSpanMethod appendMethod()
      {
         return (JDFSpanMethod)appendElementN(ElementName.METHOD, 1, null);
      }

      ///     <summary> (26) getCreateGlueLine
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFGlueLine the element </returns>
      ///     
      public virtual JDFGlueLine getCreateGlueLine(int iSkip)
      {
         return (JDFGlueLine)getCreateElement_KElement(ElementName.GLUELINE, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element GlueLine </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFGlueLine the element </returns>
      ///     * default is getGlueLine(0)     
      public virtual JDFGlueLine getGlueLine(int iSkip)
      {
         return (JDFGlueLine)getElement(ElementName.GLUELINE, null, iSkip);
      }

      ///    
      ///     <summary> * Get all GlueLine from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFGlueLine> </returns>
      ///     
      public virtual ICollection<JDFGlueLine> getAllGlueLine()
      {
         List<JDFGlueLine> v = new List<JDFGlueLine>();

         JDFGlueLine kElem = (JDFGlueLine)getFirstChildElement(ElementName.GLUELINE, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFGlueLine)kElem.getNextSiblingElement(ElementName.GLUELINE, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element GlueLine </summary>
      ///     
      public virtual JDFGlueLine appendGlueLine()
      {
         return (JDFGlueLine)appendElement(ElementName.GLUELINE, null);
      }
   }
}
