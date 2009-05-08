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
 * THIS SOFTWARE IS PROVIDED ``AS IS'' AND ANY EXPRESSED OR IMPLIED
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


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using VString = org.cip4.jdflib.core.VString;
   using JDFIntegerRangeList = org.cip4.jdflib.datatypes.JDFIntegerRangeList;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;

   public abstract class JDFAutoPart : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[58];
      static JDFAutoPart()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.SORTING, 0x33333333, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.SORTAMOUNT, 0x33333333, AttributeInfo.EnumAttributeType.Any, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.BINDERYSIGNATURENAME, 0x33333311, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.BLOCKNAME, 0x33333331, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.BUNDLEITEMINDEX, 0x33333311, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.CELLINDEX, 0x33333311, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.CONDITION, 0x33333311, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.DELIVERYUNIT0, 0x33333111, AttributeInfo.EnumAttributeType.Any, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.DELIVERYUNIT1, 0x33333111, AttributeInfo.EnumAttributeType.Any, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.DELIVERYUNIT2, 0x33333111, AttributeInfo.EnumAttributeType.Any, null, null);
         atrInfoTable[10] = new AtrInfoTable(AttributeName.DELIVERYUNIT3, 0x33333111, AttributeInfo.EnumAttributeType.Any, null, null);
         atrInfoTable[11] = new AtrInfoTable(AttributeName.DELIVERYUNIT4, 0x33333111, AttributeInfo.EnumAttributeType.Any, null, null);
         atrInfoTable[12] = new AtrInfoTable(AttributeName.DELIVERYUNIT5, 0x33333111, AttributeInfo.EnumAttributeType.Any, null, null);
         atrInfoTable[13] = new AtrInfoTable(AttributeName.DELIVERYUNIT6, 0x33333111, AttributeInfo.EnumAttributeType.Any, null, null);
         atrInfoTable[14] = new AtrInfoTable(AttributeName.DELIVERYUNIT7, 0x33333111, AttributeInfo.EnumAttributeType.Any, null, null);
         atrInfoTable[15] = new AtrInfoTable(AttributeName.DELIVERYUNIT8, 0x33333111, AttributeInfo.EnumAttributeType.Any, null, null);
         atrInfoTable[16] = new AtrInfoTable(AttributeName.DELIVERYUNIT9, 0x33333111, AttributeInfo.EnumAttributeType.Any, null, null);
         atrInfoTable[17] = new AtrInfoTable(AttributeName.DOCINDEX, 0x33333333, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable[18] = new AtrInfoTable(AttributeName.DOCCOPIES, 0x33333333, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable[19] = new AtrInfoTable(AttributeName.DOCRUNINDEX, 0x33333333, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable[20] = new AtrInfoTable(AttributeName.DOCSHEETINDEX, 0x33333333, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable[21] = new AtrInfoTable(AttributeName.FOUNTAINNUMBER, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[22] = new AtrInfoTable(AttributeName.DOCTAGS, 0x33333111, AttributeInfo.EnumAttributeType.Any, null, null);
         atrInfoTable[23] = new AtrInfoTable(AttributeName.EDITION, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[24] = new AtrInfoTable(AttributeName.EDITIONVERSION, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[25] = new AtrInfoTable(AttributeName.ITEMNAMES, 0x33333311, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable[26] = new AtrInfoTable(AttributeName.LAYERIDS, 0x33333331, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable[27] = new AtrInfoTable(AttributeName.LOCATION, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[28] = new AtrInfoTable(AttributeName.OPTION, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[29] = new AtrInfoTable(AttributeName.PAGENUMBER, 0x33333333, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable[30] = new AtrInfoTable(AttributeName.PAGETAGS, 0x33333111, AttributeInfo.EnumAttributeType.Any, null, null);
         atrInfoTable[31] = new AtrInfoTable(AttributeName.PARTVERSION, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable[32] = new AtrInfoTable(AttributeName.PLATELAYOUT, 0x33333111, AttributeInfo.EnumAttributeType.Any, null, null);
         atrInfoTable[33] = new AtrInfoTable(AttributeName.PREFLIGHTRULE, 0x33333311, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[34] = new AtrInfoTable(AttributeName.PREVIEWTYPE, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumPreviewType.getEnum(0), null);
         atrInfoTable[35] = new AtrInfoTable(AttributeName.RIBBONNAME, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[36] = new AtrInfoTable(AttributeName.RUN, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[37] = new AtrInfoTable(AttributeName.RUNINDEX, 0x33333333, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable[38] = new AtrInfoTable(AttributeName.RUNPAGE, 0x33333331, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[39] = new AtrInfoTable(AttributeName.RUNSET, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[40] = new AtrInfoTable(AttributeName.RUNTAGS, 0x33333331, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable[41] = new AtrInfoTable(AttributeName.SECTIONINDEX, 0x33333311, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable[42] = new AtrInfoTable(AttributeName.SEPARATION, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[43] = new AtrInfoTable(AttributeName.SETDOCINDEX, 0x33333311, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable[44] = new AtrInfoTable(AttributeName.SETRUNINDEX, 0x33333311, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable[45] = new AtrInfoTable(AttributeName.SETSHEETINDEX, 0x33333311, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable[46] = new AtrInfoTable(AttributeName.SETTAGS, 0x33333111, AttributeInfo.EnumAttributeType.Any, null, null);
         atrInfoTable[47] = new AtrInfoTable(AttributeName.SETINDEX, 0x33333331, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable[48] = new AtrInfoTable(AttributeName.SHEETINDEX, 0x33333333, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable[49] = new AtrInfoTable(AttributeName.SHEETNAME, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[50] = new AtrInfoTable(AttributeName.SIDE, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumSide.getEnum(0), null);
         atrInfoTable[51] = new AtrInfoTable(AttributeName.SIGNATURENAME, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[52] = new AtrInfoTable(AttributeName.STATIONNAME, 0x33333333, AttributeInfo.EnumAttributeType.Any, null, null);
         atrInfoTable[53] = new AtrInfoTable(AttributeName.SUBRUN, 0x33333111, AttributeInfo.EnumAttributeType.Any, null, null);
         atrInfoTable[54] = new AtrInfoTable(AttributeName.TILEID, 0x33333333, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[55] = new AtrInfoTable(AttributeName.WEBNAME, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[56] = new AtrInfoTable(AttributeName.WEBPRODUCT, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[57] = new AtrInfoTable(AttributeName.WEBSETUP, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoPart </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPart(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPart </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPart(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPart </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoPart(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoPart[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for PreviewType </summary>
      ///        

      public class EnumPreviewType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumPreviewType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumPreviewType getEnum(string enumName)
         {
            return (EnumPreviewType)getEnum(typeof(EnumPreviewType), enumName);
         }

         public static EnumPreviewType getEnum(int enumValue)
         {
            return (EnumPreviewType)getEnum(typeof(EnumPreviewType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumPreviewType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumPreviewType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumPreviewType));
         }

         public static readonly EnumPreviewType Separation = new EnumPreviewType("Separation");
         public static readonly EnumPreviewType SeparatedThumbNail = new EnumPreviewType("SeparatedThumbNail");
         public static readonly EnumPreviewType SeparationRaw = new EnumPreviewType("SeparationRaw");
         public static readonly EnumPreviewType ThumbNail = new EnumPreviewType("ThumbNail");
         public static readonly EnumPreviewType Viewable = new EnumPreviewType("Viewable");
      }



      ///        
      ///        <summary> * Enumeration strings for Side </summary>
      ///        

      public class EnumSide : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumSide(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumSide getEnum(string enumName)
         {
            return (EnumSide)getEnum(typeof(EnumSide), enumName);
         }

         public static EnumSide getEnum(int enumValue)
         {
            return (EnumSide)getEnum(typeof(EnumSide), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumSide));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumSide));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumSide));
         }

         public static readonly EnumSide Front = new EnumSide("Front");
         public static readonly EnumSide Back = new EnumSide("Back");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute Sorting
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Sorting </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSorting(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.SORTING, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerRangeList attribute Sorting </summary>
      ///          * <returns> JDFIntegerRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerRangeList </returns>
      ///          
      public virtual JDFIntegerRangeList getSorting()
      {
         string strAttrName = "";
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.SORTING, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute SortAmount
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SortAmount </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSortAmount(string @value)
      {
         setAttribute(AttributeName.SORTAMOUNT, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute SortAmount </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getSortAmount()
      {
         return getAttribute(AttributeName.SORTAMOUNT, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute BinderySignatureName
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BinderySignatureName </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBinderySignatureName(string @value)
      {
         setAttribute(AttributeName.BINDERYSIGNATURENAME, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute BinderySignatureName </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getBinderySignatureName()
      {
         return getAttribute(AttributeName.BINDERYSIGNATURENAME, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute BlockName
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BlockName </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBlockName(string @value)
      {
         setAttribute(AttributeName.BLOCKNAME, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute BlockName </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getBlockName()
      {
         return getAttribute(AttributeName.BLOCKNAME, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute BundleItemIndex
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BundleItemIndex </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBundleItemIndex(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.BUNDLEITEMINDEX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerRangeList attribute BundleItemIndex </summary>
      ///          * <returns> JDFIntegerRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerRangeList </returns>
      ///          
      public virtual JDFIntegerRangeList getBundleItemIndex()
      {
         string strAttrName = "";
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.BUNDLEITEMINDEX, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute CellIndex
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CellIndex </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCellIndex(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.CELLINDEX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerRangeList attribute CellIndex </summary>
      ///          * <returns> JDFIntegerRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerRangeList </returns>
      ///          
      public virtual JDFIntegerRangeList getCellIndex()
      {
         string strAttrName = "";
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.CELLINDEX, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute Condition
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Condition </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCondition(string @value)
      {
         setAttribute(AttributeName.CONDITION, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Condition </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getCondition()
      {
         return getAttribute(AttributeName.CONDITION, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute DeliveryUnit0
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DeliveryUnit0 </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDeliveryUnit0(string @value)
      {
         setAttribute(AttributeName.DELIVERYUNIT0, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute DeliveryUnit0 </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getDeliveryUnit0()
      {
         return getAttribute(AttributeName.DELIVERYUNIT0, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute DeliveryUnit1
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DeliveryUnit1 </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDeliveryUnit1(string @value)
      {
         setAttribute(AttributeName.DELIVERYUNIT1, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute DeliveryUnit1 </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getDeliveryUnit1()
      {
         return getAttribute(AttributeName.DELIVERYUNIT1, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute DeliveryUnit2
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DeliveryUnit2 </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDeliveryUnit2(string @value)
      {
         setAttribute(AttributeName.DELIVERYUNIT2, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute DeliveryUnit2 </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getDeliveryUnit2()
      {
         return getAttribute(AttributeName.DELIVERYUNIT2, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute DeliveryUnit3
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DeliveryUnit3 </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDeliveryUnit3(string @value)
      {
         setAttribute(AttributeName.DELIVERYUNIT3, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute DeliveryUnit3 </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getDeliveryUnit3()
      {
         return getAttribute(AttributeName.DELIVERYUNIT3, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute DeliveryUnit4
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DeliveryUnit4 </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDeliveryUnit4(string @value)
      {
         setAttribute(AttributeName.DELIVERYUNIT4, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute DeliveryUnit4 </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getDeliveryUnit4()
      {
         return getAttribute(AttributeName.DELIVERYUNIT4, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute DeliveryUnit5
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DeliveryUnit5 </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDeliveryUnit5(string @value)
      {
         setAttribute(AttributeName.DELIVERYUNIT5, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute DeliveryUnit5 </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getDeliveryUnit5()
      {
         return getAttribute(AttributeName.DELIVERYUNIT5, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute DeliveryUnit6
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DeliveryUnit6 </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDeliveryUnit6(string @value)
      {
         setAttribute(AttributeName.DELIVERYUNIT6, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute DeliveryUnit6 </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getDeliveryUnit6()
      {
         return getAttribute(AttributeName.DELIVERYUNIT6, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute DeliveryUnit7
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DeliveryUnit7 </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDeliveryUnit7(string @value)
      {
         setAttribute(AttributeName.DELIVERYUNIT7, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute DeliveryUnit7 </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getDeliveryUnit7()
      {
         return getAttribute(AttributeName.DELIVERYUNIT7, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute DeliveryUnit8
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DeliveryUnit8 </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDeliveryUnit8(string @value)
      {
         setAttribute(AttributeName.DELIVERYUNIT8, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute DeliveryUnit8 </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getDeliveryUnit8()
      {
         return getAttribute(AttributeName.DELIVERYUNIT8, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute DeliveryUnit9
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DeliveryUnit9 </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDeliveryUnit9(string @value)
      {
         setAttribute(AttributeName.DELIVERYUNIT9, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute DeliveryUnit9 </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getDeliveryUnit9()
      {
         return getAttribute(AttributeName.DELIVERYUNIT9, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute DocIndex
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DocIndex </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDocIndex(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.DOCINDEX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerRangeList attribute DocIndex </summary>
      ///          * <returns> JDFIntegerRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerRangeList </returns>
      ///          
      public virtual JDFIntegerRangeList getDocIndex()
      {
         string strAttrName = "";
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.DOCINDEX, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute DocCopies
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DocCopies </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDocCopies(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.DOCCOPIES, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerRangeList attribute DocCopies </summary>
      ///          * <returns> JDFIntegerRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerRangeList </returns>
      ///          
      public virtual JDFIntegerRangeList getDocCopies()
      {
         string strAttrName = "";
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.DOCCOPIES, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute DocRunIndex
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DocRunIndex </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDocRunIndex(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.DOCRUNINDEX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerRangeList attribute DocRunIndex </summary>
      ///          * <returns> JDFIntegerRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerRangeList </returns>
      ///          
      public virtual JDFIntegerRangeList getDocRunIndex()
      {
         string strAttrName = "";
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.DOCRUNINDEX, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute DocSheetIndex
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DocSheetIndex </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDocSheetIndex(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.DOCSHEETINDEX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerRangeList attribute DocSheetIndex </summary>
      ///          * <returns> JDFIntegerRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerRangeList </returns>
      ///          
      public virtual JDFIntegerRangeList getDocSheetIndex()
      {
         string strAttrName = "";
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.DOCSHEETINDEX, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute FountainNumber
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute FountainNumber </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFountainNumber(int @value)
      {
         setAttribute(AttributeName.FOUNTAINNUMBER, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute FountainNumber </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getFountainNumber()
      {
         return getIntAttribute(AttributeName.FOUNTAINNUMBER, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute DocTags
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DocTags </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDocTags(string @value)
      {
         setAttribute(AttributeName.DOCTAGS, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute DocTags </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getDocTags()
      {
         return getAttribute(AttributeName.DOCTAGS, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Edition
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Edition </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setEdition(string @value)
      {
         setAttribute(AttributeName.EDITION, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Edition </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getEdition()
      {
         return getAttribute(AttributeName.EDITION, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute EditionVersion
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute EditionVersion </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setEditionVersion(string @value)
      {
         setAttribute(AttributeName.EDITIONVERSION, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute EditionVersion </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getEditionVersion()
      {
         return getAttribute(AttributeName.EDITIONVERSION, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ItemNames
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ItemNames </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setItemNames(string @value)
      {
         setAttribute(AttributeName.ITEMNAMES, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ItemNames </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getItemNames()
      {
         return getAttribute(AttributeName.ITEMNAMES, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute LayerIDs
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute LayerIDs </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setLayerIDs(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.LAYERIDS, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerRangeList attribute LayerIDs </summary>
      ///          * <returns> JDFIntegerRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerRangeList </returns>
      ///          
      public virtual JDFIntegerRangeList getLayerIDs()
      {
         string strAttrName = "";
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.LAYERIDS, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute Location
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Location </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setLocation(string @value)
      {
         setAttribute(AttributeName.LOCATION, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Location </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getLocation()
      {
         return getAttribute(AttributeName.LOCATION, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Option
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Option </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setOption(string @value)
      {
         setAttribute(AttributeName.OPTION, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Option </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getOption()
      {
         return getAttribute(AttributeName.OPTION, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PageNumber
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PageNumber </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPageNumber(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.PAGENUMBER, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerRangeList attribute PageNumber </summary>
      ///          * <returns> JDFIntegerRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerRangeList </returns>
      ///          
      public virtual JDFIntegerRangeList getPageNumber()
      {
         string strAttrName = "";
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.PAGENUMBER, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute PageTags
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PageTags </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPageTags(string @value)
      {
         setAttribute(AttributeName.PAGETAGS, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute PageTags </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getPageTags()
      {
         return getAttribute(AttributeName.PAGETAGS, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PartVersion
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PartVersion </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPartVersion(VString @value)
      {
         setAttribute(AttributeName.PARTVERSION, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute PartVersion </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getPartVersion()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.PARTVERSION, null, JDFConstants.EMPTYSTRING);
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PlateLayout
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PlateLayout </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPlateLayout(string @value)
      {
         setAttribute(AttributeName.PLATELAYOUT, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute PlateLayout </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getPlateLayout()
      {
         return getAttribute(AttributeName.PLATELAYOUT, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PreflightRule
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PreflightRule </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPreflightRule(string @value)
      {
         setAttribute(AttributeName.PREFLIGHTRULE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute PreflightRule </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getPreflightRule()
      {
         return getAttribute(AttributeName.PREFLIGHTRULE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PreviewType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute PreviewType </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setPreviewType(EnumPreviewType enumVar)
      {
         setAttribute(AttributeName.PREVIEWTYPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute PreviewType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumPreviewType getPreviewType()
      {
         return EnumPreviewType.getEnum(getAttribute(AttributeName.PREVIEWTYPE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute RibbonName
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute RibbonName </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setRibbonName(string @value)
      {
         setAttribute(AttributeName.RIBBONNAME, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute RibbonName </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getRibbonName()
      {
         return getAttribute(AttributeName.RIBBONNAME, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Run
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Run </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setRun(string @value)
      {
         setAttribute(AttributeName.RUN, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Run </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getRun()
      {
         return getAttribute(AttributeName.RUN, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute RunIndex
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute RunIndex </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setRunIndex(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.RUNINDEX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerRangeList attribute RunIndex </summary>
      ///          * <returns> JDFIntegerRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerRangeList </returns>
      ///          
      public virtual JDFIntegerRangeList getRunIndex()
      {
         string strAttrName = "";
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.RUNINDEX, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute RunPage
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute RunPage </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setRunPage(int @value)
      {
         setAttribute(AttributeName.RUNPAGE, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute RunPage </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getRunPage()
      {
         return getIntAttribute(AttributeName.RUNPAGE, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute RunSet
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute RunSet </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setRunSet(string @value)
      {
         setAttribute(AttributeName.RUNSET, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute RunSet </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getRunSet()
      {
         return getAttribute(AttributeName.RUNSET, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute RunTags
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute RunTags </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setRunTags(string @value)
      {
         setAttribute(AttributeName.RUNTAGS, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute RunTags </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getRunTags()
      {
         return getAttribute(AttributeName.RUNTAGS, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SectionIndex
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SectionIndex </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSectionIndex(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.SECTIONINDEX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerRangeList attribute SectionIndex </summary>
      ///          * <returns> JDFIntegerRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerRangeList </returns>
      ///          
      public virtual JDFIntegerRangeList getSectionIndex()
      {
         string strAttrName = "";
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.SECTIONINDEX, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute Separation
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Separation </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSeparation(string @value)
      {
         setAttribute(AttributeName.SEPARATION, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Separation </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getSeparation()
      {
         return getAttribute(AttributeName.SEPARATION, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SetDocIndex
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SetDocIndex </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSetDocIndex(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.SETDOCINDEX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerRangeList attribute SetDocIndex </summary>
      ///          * <returns> JDFIntegerRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerRangeList </returns>
      ///          
      public virtual JDFIntegerRangeList getSetDocIndex()
      {
         string strAttrName = "";
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.SETDOCINDEX, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute SetRunIndex
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SetRunIndex </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSetRunIndex(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.SETRUNINDEX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerRangeList attribute SetRunIndex </summary>
      ///          * <returns> JDFIntegerRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerRangeList </returns>
      ///          
      public virtual JDFIntegerRangeList getSetRunIndex()
      {
         string strAttrName = "";
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.SETRUNINDEX, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute SetSheetIndex
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SetSheetIndex </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSetSheetIndex(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.SETSHEETINDEX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerRangeList attribute SetSheetIndex </summary>
      ///          * <returns> JDFIntegerRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerRangeList </returns>
      ///          
      public virtual JDFIntegerRangeList getSetSheetIndex()
      {
         string strAttrName = "";
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.SETSHEETINDEX, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute SetTags
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SetTags </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSetTags(string @value)
      {
         setAttribute(AttributeName.SETTAGS, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute SetTags </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getSetTags()
      {
         return getAttribute(AttributeName.SETTAGS, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SetIndex
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SetIndex </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSetIndex(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.SETINDEX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerRangeList attribute SetIndex </summary>
      ///          * <returns> JDFIntegerRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerRangeList </returns>
      ///          
      public virtual JDFIntegerRangeList getSetIndex()
      {
         string strAttrName = "";
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.SETINDEX, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute SheetIndex
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SheetIndex </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSheetIndex(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.SHEETINDEX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerRangeList attribute SheetIndex </summary>
      ///          * <returns> JDFIntegerRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerRangeList </returns>
      ///          
      public virtual JDFIntegerRangeList getSheetIndex()
      {
         string strAttrName = "";
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.SHEETINDEX, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute SheetName
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SheetName </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSheetName(string @value)
      {
         setAttribute(AttributeName.SHEETNAME, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute SheetName </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getSheetName()
      {
         return getAttribute(AttributeName.SHEETNAME, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Side
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Side </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setSide(EnumSide enumVar)
      {
         setAttribute(AttributeName.SIDE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Side </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumSide getSide()
      {
         return EnumSide.getEnum(getAttribute(AttributeName.SIDE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SignatureName
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SignatureName </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSignatureName(string @value)
      {
         setAttribute(AttributeName.SIGNATURENAME, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute SignatureName </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getSignatureName()
      {
         return getAttribute(AttributeName.SIGNATURENAME, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute StationName
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute StationName </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setStationName(string @value)
      {
         setAttribute(AttributeName.STATIONNAME, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute StationName </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getStationName()
      {
         return getAttribute(AttributeName.STATIONNAME, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SubRun
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SubRun </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSubRun(string @value)
      {
         setAttribute(AttributeName.SUBRUN, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute SubRun </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getSubRun()
      {
         return getAttribute(AttributeName.SUBRUN, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TileID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TileID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTileID(JDFXYPair @value)
      {
         setAttribute(AttributeName.TILEID, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute TileID </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getTileID()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.TILEID, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute WebName
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute WebName </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setWebName(string @value)
      {
         setAttribute(AttributeName.WEBNAME, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute WebName </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getWebName()
      {
         return getAttribute(AttributeName.WEBNAME, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute WebProduct
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute WebProduct </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setWebProduct(string @value)
      {
         setAttribute(AttributeName.WEBPRODUCT, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute WebProduct </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getWebProduct()
      {
         return getAttribute(AttributeName.WEBPRODUCT, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute WebSetup
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute WebSetup </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setWebSetup(string @value)
      {
         setAttribute(AttributeName.WEBSETUP, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute WebSetup </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getWebSetup()
      {
         return getAttribute(AttributeName.WEBSETUP, null, JDFConstants.EMPTYSTRING);
      }
   }
}
