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
   using System.Collections;
   using System.Collections.Generic;


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFIntegerRangeList = org.cip4.jdflib.datatypes.JDFIntegerRangeList;
   using JDFNameRangeList = org.cip4.jdflib.datatypes.JDFNameRangeList;
   using JDFPageList = org.cip4.jdflib.resource.JDFPageList;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFByteMap = org.cip4.jdflib.resource.process.JDFByteMap;
   using JDFDisposition = org.cip4.jdflib.resource.process.JDFDisposition;
   using JDFDynamicInput = org.cip4.jdflib.resource.process.JDFDynamicInput;
   using JDFInsertSheet = org.cip4.jdflib.resource.process.JDFInsertSheet;
   using JDFInterpretedPDLData = org.cip4.jdflib.resource.process.JDFInterpretedPDLData;
   using JDFLayoutElement = org.cip4.jdflib.resource.process.JDFLayoutElement;

   public abstract class JDFAutoRunList : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[23];
      static JDFAutoRunList()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.COMPONENTGRANULARITY, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumComponentGranularity.getEnum(0), "Document");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.ISPAGE, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "true");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.PAGECOPIES, 0x33333331, AttributeInfo.EnumAttributeType.integer, null, "1");
         atrInfoTable[3] = new AtrInfoTable(AttributeName.SETCOPIES, 0x33333331, AttributeInfo.EnumAttributeType.integer, null, "1");
         atrInfoTable[4] = new AtrInfoTable(AttributeName.DIRECTORY, 0x33333333, AttributeInfo.EnumAttributeType.URL, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.DOCNAMES, 0x33333333, AttributeInfo.EnumAttributeType.NameRangeList, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.DOCS, 0x33333333, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.ENDOFBUNDLEITEM, 0x33333311, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.ENDOFDOCUMENT, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.ENDOFSET, 0x33333331, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[10] = new AtrInfoTable(AttributeName.FIRSTPAGE, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[11] = new AtrInfoTable(AttributeName.LOGICALPAGE, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[12] = new AtrInfoTable(AttributeName.NDOC, 0x44444431, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[13] = new AtrInfoTable(AttributeName.NPAGE, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[14] = new AtrInfoTable(AttributeName.NSET, 0x44444431, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[15] = new AtrInfoTable(AttributeName.PAGELISTINDEX, 0x33333311, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable[16] = new AtrInfoTable(AttributeName.PAGENAMES, 0x33333333, AttributeInfo.EnumAttributeType.NameRangeList, null, null);
         atrInfoTable[17] = new AtrInfoTable(AttributeName.PAGES, 0x33333333, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable[18] = new AtrInfoTable(AttributeName.RUNTAG, 0x33333331, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[19] = new AtrInfoTable(AttributeName.SETNAMES, 0x33333331, AttributeInfo.EnumAttributeType.NameRangeList, null, null);
         atrInfoTable[20] = new AtrInfoTable(AttributeName.SETS, 0x33333331, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable[21] = new AtrInfoTable(AttributeName.SKIPPAGE, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[22] = new AtrInfoTable(AttributeName.SORTED, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.BYTEMAP, 0x66666666);
         elemInfoTable[1] = new ElemInfoTable(ElementName.DYNAMICINPUT, 0x33333333);
         elemInfoTable[2] = new ElemInfoTable(ElementName.INSERTSHEET, 0x33333333);
         elemInfoTable[3] = new ElemInfoTable(ElementName.LAYOUTELEMENT, 0x66666666);
         elemInfoTable[4] = new ElemInfoTable(ElementName.INTERPRETEDPDLDATA, 0x66666611);
         elemInfoTable[5] = new ElemInfoTable(ElementName.DISPOSITION, 0x66666666);
         elemInfoTable[6] = new ElemInfoTable(ElementName.PAGELIST, 0x66666666);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[7];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoRunList </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoRunList(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoRunList </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoRunList(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoRunList </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoRunList(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoRunList[  --> " + base.ToString() + " ]";
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


      ///        
      ///        <summary> * Enumeration strings for ComponentGranularity </summary>
      ///        

      public class EnumComponentGranularity : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumComponentGranularity(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumComponentGranularity getEnum(string enumName)
         {
            return (EnumComponentGranularity)getEnum(typeof(EnumComponentGranularity), enumName);
         }

         public static EnumComponentGranularity getEnum(int enumValue)
         {
            return (EnumComponentGranularity)getEnum(typeof(EnumComponentGranularity), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumComponentGranularity));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumComponentGranularity));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumComponentGranularity));
         }

         public static readonly EnumComponentGranularity Page = new EnumComponentGranularity("Page");
         public static readonly EnumComponentGranularity Document = new EnumComponentGranularity("Document");
         public static readonly EnumComponentGranularity Set = new EnumComponentGranularity("Set");
         public static readonly EnumComponentGranularity All = new EnumComponentGranularity("All");
         public static readonly EnumComponentGranularity BundleItem = new EnumComponentGranularity("BundleItem");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute ComponentGranularity
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute ComponentGranularity </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setComponentGranularity(EnumComponentGranularity enumVar)
      {
         setAttribute(AttributeName.COMPONENTGRANULARITY, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute ComponentGranularity </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumComponentGranularity getComponentGranularity()
      {
         return EnumComponentGranularity.getEnum(getAttribute(AttributeName.COMPONENTGRANULARITY, null, "Document"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute IsPage
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute IsPage </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setIsPage(bool @value)
      {
         setAttribute(AttributeName.ISPAGE, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute IsPage </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getIsPage()
      {
         return getBoolAttribute(AttributeName.ISPAGE, null, true);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PageCopies
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PageCopies </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPageCopies(int @value)
      {
         setAttribute(AttributeName.PAGECOPIES, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute PageCopies </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getPageCopies()
      {
         return getIntAttribute(AttributeName.PAGECOPIES, null, 1);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SetCopies
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SetCopies </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSetCopies(int @value)
      {
         setAttribute(AttributeName.SETCOPIES, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute SetCopies </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getSetCopies()
      {
         return getIntAttribute(AttributeName.SETCOPIES, null, 1);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Directory
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Directory </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDirectory(string @value)
      {
         setAttribute(AttributeName.DIRECTORY, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Directory </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getDirectory()
      {
         return getAttribute(AttributeName.DIRECTORY, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute DocNames
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DocNames </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDocNames(JDFNameRangeList @value)
      {
         setAttribute(AttributeName.DOCNAMES, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFNameRangeList attribute DocNames </summary>
      ///          * <returns> JDFNameRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFNameRangeList </returns>
      ///          
      public virtual JDFNameRangeList getDocNames()
      {
         string strAttrName = "";
         JDFNameRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.DOCNAMES, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFNameRangeList(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Docs
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Docs </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDocs(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.DOCS, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerRangeList attribute Docs </summary>
      ///          * <returns> JDFIntegerRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerRangeList </returns>
      ///          
      public virtual JDFIntegerRangeList getDocs()
      {
         string strAttrName = "";
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.DOCS, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute EndOfBundleItem
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute EndOfBundleItem </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setEndOfBundleItem(bool @value)
      {
         setAttribute(AttributeName.ENDOFBUNDLEITEM, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute EndOfBundleItem </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getEndOfBundleItem()
      {
         return getBoolAttribute(AttributeName.ENDOFBUNDLEITEM, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute EndOfDocument
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute EndOfDocument </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setEndOfDocument(bool @value)
      {
         setAttribute(AttributeName.ENDOFDOCUMENT, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute EndOfDocument </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getEndOfDocument()
      {
         return getBoolAttribute(AttributeName.ENDOFDOCUMENT, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute EndOfSet
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute EndOfSet </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setEndOfSet(bool @value)
      {
         setAttribute(AttributeName.ENDOFSET, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute EndOfSet </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getEndOfSet()
      {
         return getBoolAttribute(AttributeName.ENDOFSET, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute FirstPage
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute FirstPage </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFirstPage(int @value)
      {
         setAttribute(AttributeName.FIRSTPAGE, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute FirstPage </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getFirstPage()
      {
         return getIntAttribute(AttributeName.FIRSTPAGE, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute LogicalPage
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute LogicalPage </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setLogicalPage(int @value)
      {
         setAttribute(AttributeName.LOGICALPAGE, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute LogicalPage </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getLogicalPage()
      {
         return getIntAttribute(AttributeName.LOGICALPAGE, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute NDoc
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute NDoc </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setNDoc(int @value)
      {
         setAttribute(AttributeName.NDOC, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute NDoc </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getNDoc()
      {
         return getIntAttribute(AttributeName.NDOC, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute NPage
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute NPage </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setNPage(int @value)
      {
         setAttribute(AttributeName.NPAGE, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute NPage </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getNPage()
      {
         return getIntAttribute(AttributeName.NPAGE, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute NSet
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute NSet </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setNSet(int @value)
      {
         setAttribute(AttributeName.NSET, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute NSet </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getNSet()
      {
         return getIntAttribute(AttributeName.NSET, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PageListIndex
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PageListIndex </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPageListIndex(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.PAGELISTINDEX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerRangeList attribute PageListIndex </summary>
      ///          * <returns> JDFIntegerRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerRangeList </returns>
      ///          
      public virtual JDFIntegerRangeList getPageListIndex()
      {
         string strAttrName = "";
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.PAGELISTINDEX, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute PageNames
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PageNames </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPageNames(JDFNameRangeList @value)
      {
         setAttribute(AttributeName.PAGENAMES, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFNameRangeList attribute PageNames </summary>
      ///          * <returns> JDFNameRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFNameRangeList </returns>
      ///          
      public virtual JDFNameRangeList getPageNames()
      {
         string strAttrName = "";
         JDFNameRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.PAGENAMES, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFNameRangeList(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Pages
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Pages </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPages(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.PAGES, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerRangeList attribute Pages </summary>
      ///          * <returns> JDFIntegerRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerRangeList </returns>
      ///          
      public virtual JDFIntegerRangeList getPages()
      {
         string strAttrName = "";
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.PAGES, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute RunTag
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute RunTag </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setRunTag(string @value)
      {
         setAttribute(AttributeName.RUNTAG, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute RunTag </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getRunTag()
      {
         return getAttribute(AttributeName.RUNTAG, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SetNames
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SetNames </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSetNames(JDFNameRangeList @value)
      {
         setAttribute(AttributeName.SETNAMES, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFNameRangeList attribute SetNames </summary>
      ///          * <returns> JDFNameRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFNameRangeList </returns>
      ///          
      public virtual JDFNameRangeList getSetNames()
      {
         string strAttrName = "";
         JDFNameRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.SETNAMES, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFNameRangeList(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Sets
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Sets </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSets(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.SETS, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerRangeList attribute Sets </summary>
      ///          * <returns> JDFIntegerRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerRangeList </returns>
      ///          
      public virtual JDFIntegerRangeList getSets()
      {
         string strAttrName = "";
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.SETS, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute SkipPage
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SkipPage </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSkipPage(int @value)
      {
         setAttribute(AttributeName.SKIPPAGE, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute SkipPage </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getSkipPage()
      {
         return getIntAttribute(AttributeName.SKIPPAGE, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Sorted
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Sorted </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSorted(bool @value)
      {
         setAttribute(AttributeName.SORTED, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute Sorted </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getSorted()
      {
         return getBoolAttribute(AttributeName.SORTED, null, false);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element ByteMap </summary>
      ///     * <returns> JDFByteMap the element </returns>
      ///     
      public virtual JDFByteMap getByteMap()
      {
         return (JDFByteMap)getElement(ElementName.BYTEMAP, null, 0);
      }

      ///     <summary> (25) getCreateByteMap
      ///     *  </summary>
      ///     * <returns> JDFByteMap the element </returns>
      ///     
      public virtual JDFByteMap getCreateByteMap()
      {
         return (JDFByteMap)getCreateElement_KElement(ElementName.BYTEMAP, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ByteMap </summary>
      ///     
      public virtual JDFByteMap appendByteMap()
      {
         return (JDFByteMap)appendElementN(ElementName.BYTEMAP, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refByteMap(JDFByteMap refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreateDynamicInput
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFDynamicInput the element </returns>
      ///     
      public virtual JDFDynamicInput getCreateDynamicInput(int iSkip)
      {
         return (JDFDynamicInput)getCreateElement_KElement(ElementName.DYNAMICINPUT, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element DynamicInput </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFDynamicInput the element </returns>
      ///     * default is getDynamicInput(0)     
      public virtual JDFDynamicInput getDynamicInput(int iSkip)
      {
         return (JDFDynamicInput)getElement(ElementName.DYNAMICINPUT, null, iSkip);
      }

      ///    
      ///     <summary> * Get all DynamicInput from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFDynamicInput> </returns>
      ///     
      public virtual ICollection<JDFDynamicInput> getAllDynamicInput()
      {
         List<JDFDynamicInput> v = new List<JDFDynamicInput>();

         JDFDynamicInput kElem = (JDFDynamicInput)getFirstChildElement(ElementName.DYNAMICINPUT, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFDynamicInput)kElem.getNextSiblingElement(ElementName.DYNAMICINPUT, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element DynamicInput </summary>
      ///     
      public virtual JDFDynamicInput appendDynamicInput()
      {
         return (JDFDynamicInput)appendElement(ElementName.DYNAMICINPUT, null);
      }

      ///     <summary> (26) getCreateInsertSheet
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFInsertSheet the element </returns>
      ///     
      public virtual JDFInsertSheet getCreateInsertSheet(int iSkip)
      {
         return (JDFInsertSheet)getCreateElement_KElement(ElementName.INSERTSHEET, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element InsertSheet </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFInsertSheet the element </returns>
      ///     * default is getInsertSheet(0)     
      public virtual JDFInsertSheet getInsertSheet(int iSkip)
      {
         return (JDFInsertSheet)getElement(ElementName.INSERTSHEET, null, iSkip);
      }

      ///    
      ///     <summary> * Get all InsertSheet from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFInsertSheet> </returns>
      ///     
      public virtual ICollection<JDFInsertSheet> getAllInsertSheet()
      {
         List<JDFInsertSheet> v = new List<JDFInsertSheet>();

         JDFInsertSheet kElem = (JDFInsertSheet)getFirstChildElement(ElementName.INSERTSHEET, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFInsertSheet)kElem.getNextSiblingElement(ElementName.INSERTSHEET, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element InsertSheet </summary>
      ///     
      public virtual JDFInsertSheet appendInsertSheet()
      {
         return (JDFInsertSheet)appendElement(ElementName.INSERTSHEET, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refInsertSheet(JDFInsertSheet refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element LayoutElement </summary>
      ///     * <returns> JDFLayoutElement the element </returns>
      ///     
      public virtual JDFLayoutElement getLayoutElement()
      {
         return (JDFLayoutElement)getElement(ElementName.LAYOUTELEMENT, null, 0);
      }

      ///     <summary> (25) getCreateLayoutElement
      ///     *  </summary>
      ///     * <returns> JDFLayoutElement the element </returns>
      ///     
      public virtual JDFLayoutElement getCreateLayoutElement()
      {
         return (JDFLayoutElement)getCreateElement_KElement(ElementName.LAYOUTELEMENT, null, 0);
      }

      ///    
      ///     <summary> * (29) append element LayoutElement </summary>
      ///     
      public virtual JDFLayoutElement appendLayoutElement()
      {
         return (JDFLayoutElement)appendElementN(ElementName.LAYOUTELEMENT, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refLayoutElement(JDFLayoutElement refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element InterpretedPDLData </summary>
      ///     * <returns> JDFInterpretedPDLData the element </returns>
      ///     
      public virtual JDFInterpretedPDLData getInterpretedPDLData()
      {
         return (JDFInterpretedPDLData)getElement(ElementName.INTERPRETEDPDLDATA, null, 0);
      }

      ///     <summary> (25) getCreateInterpretedPDLData
      ///     *  </summary>
      ///     * <returns> JDFInterpretedPDLData the element </returns>
      ///     
      public virtual JDFInterpretedPDLData getCreateInterpretedPDLData()
      {
         return (JDFInterpretedPDLData)getCreateElement_KElement(ElementName.INTERPRETEDPDLDATA, null, 0);
      }

      ///    
      ///     <summary> * (29) append element InterpretedPDLData </summary>
      ///     
      public virtual JDFInterpretedPDLData appendInterpretedPDLData()
      {
         return (JDFInterpretedPDLData)appendElementN(ElementName.INTERPRETEDPDLDATA, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refInterpretedPDLData(JDFInterpretedPDLData refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element Disposition </summary>
      ///     * <returns> JDFDisposition the element </returns>
      ///     
      public virtual JDFDisposition getDisposition()
      {
         return (JDFDisposition)getElement(ElementName.DISPOSITION, null, 0);
      }

      ///     <summary> (25) getCreateDisposition
      ///     *  </summary>
      ///     * <returns> JDFDisposition the element </returns>
      ///     
      public virtual JDFDisposition getCreateDisposition()
      {
         return (JDFDisposition)getCreateElement_KElement(ElementName.DISPOSITION, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Disposition </summary>
      ///     
      public virtual JDFDisposition appendDisposition()
      {
         return (JDFDisposition)appendElementN(ElementName.DISPOSITION, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element PageList </summary>
      ///     * <returns> JDFPageList the element </returns>
      ///     
      public virtual JDFPageList getPageList()
      {
         return (JDFPageList)getElement(ElementName.PAGELIST, null, 0);
      }

      ///     <summary> (25) getCreatePageList
      ///     *  </summary>
      ///     * <returns> JDFPageList the element </returns>
      ///     
      public virtual JDFPageList getCreatePageList()
      {
         return (JDFPageList)getCreateElement_KElement(ElementName.PAGELIST, null, 0);
      }

      ///    
      ///     <summary> * (29) append element PageList </summary>
      ///     
      public virtual JDFPageList appendPageList()
      {
         return (JDFPageList)appendElementN(ElementName.PAGELIST, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refPageList(JDFPageList refTarget)
      {
         refElement(refTarget);
      }
   }
}
