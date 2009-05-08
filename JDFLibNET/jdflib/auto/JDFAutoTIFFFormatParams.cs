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
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFTIFFEmbeddedFile = org.cip4.jdflib.resource.process.JDFTIFFEmbeddedFile;
   using JDFTIFFtag = org.cip4.jdflib.resource.process.JDFTIFFtag;

   public abstract class JDFAutoTIFFFormatParams : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[7];
      static JDFAutoTIFFFormatParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.BYTEORDER, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumByteOrder.getEnum(0), null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.INTERLEAVING, 0x33333311, AttributeInfo.EnumAttributeType.integer, null, "1");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.WHITEISZERO, 0x33333311, AttributeInfo.EnumAttributeType.boolean_, null, "true");
         atrInfoTable[3] = new AtrInfoTable(AttributeName.SEGMENTATION, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumSegmentation.getEnum(0), null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.ROWSPERSTRIP, 0x33333311, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.TILESIZE, 0x33333311, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.SEPARATIONNAMETAG, 0x33333311, AttributeInfo.EnumAttributeType.integer, null, "270");
         elemInfoTable[0] = new ElemInfoTable(ElementName.TIFFTAG, 0x33333311);
         elemInfoTable[1] = new ElemInfoTable(ElementName.TIFFEMBEDDEDFILE, 0x33333311);
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
      ///     <summary> * Constructor for JDFAutoTIFFFormatParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoTIFFFormatParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoTIFFFormatParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoTIFFFormatParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoTIFFFormatParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoTIFFFormatParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoTIFFFormatParams[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for ByteOrder </summary>
      ///        

      public class EnumByteOrder : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumByteOrder(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumByteOrder getEnum(string enumName)
         {
            return (EnumByteOrder)getEnum(typeof(EnumByteOrder), enumName);
         }

         public static EnumByteOrder getEnum(int enumValue)
         {
            return (EnumByteOrder)getEnum(typeof(EnumByteOrder), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumByteOrder));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumByteOrder));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumByteOrder));
         }

         public static readonly EnumByteOrder II = new EnumByteOrder("II");
         public static readonly EnumByteOrder MM = new EnumByteOrder("MM");
      }



      ///        
      ///        <summary> * Enumeration strings for Segmentation </summary>
      ///        

      public class EnumSegmentation : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumSegmentation(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumSegmentation getEnum(string enumName)
         {
            return (EnumSegmentation)getEnum(typeof(EnumSegmentation), enumName);
         }

         public static EnumSegmentation getEnum(int enumValue)
         {
            return (EnumSegmentation)getEnum(typeof(EnumSegmentation), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumSegmentation));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumSegmentation));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumSegmentation));
         }

         public static readonly EnumSegmentation SingleStrip = new EnumSegmentation("SingleStrip");
         public static readonly EnumSegmentation Stripped = new EnumSegmentation("Stripped");
         public static readonly EnumSegmentation Tiled = new EnumSegmentation("Tiled");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute ByteOrder
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute ByteOrder </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setByteOrder(EnumByteOrder enumVar)
      {
         setAttribute(AttributeName.BYTEORDER, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute ByteOrder </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumByteOrder getByteOrder()
      {
         return EnumByteOrder.getEnum(getAttribute(AttributeName.BYTEORDER, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Interleaving
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Interleaving </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setInterleaving(int @value)
      {
         setAttribute(AttributeName.INTERLEAVING, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute Interleaving </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getInterleaving()
      {
         return getIntAttribute(AttributeName.INTERLEAVING, null, 1);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute WhiteIsZero
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute WhiteIsZero </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setWhiteIsZero(bool @value)
      {
         setAttribute(AttributeName.WHITEISZERO, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute WhiteIsZero </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getWhiteIsZero()
      {
         return getBoolAttribute(AttributeName.WHITEISZERO, null, true);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Segmentation
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Segmentation </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setSegmentation(EnumSegmentation enumVar)
      {
         setAttribute(AttributeName.SEGMENTATION, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Segmentation </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumSegmentation getSegmentation()
      {
         return EnumSegmentation.getEnum(getAttribute(AttributeName.SEGMENTATION, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute RowsPerStrip
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute RowsPerStrip </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setRowsPerStrip(int @value)
      {
         setAttribute(AttributeName.ROWSPERSTRIP, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute RowsPerStrip </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getRowsPerStrip()
      {
         return getIntAttribute(AttributeName.ROWSPERSTRIP, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TileSize
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TileSize </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTileSize(JDFXYPair @value)
      {
         setAttribute(AttributeName.TILESIZE, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute TileSize </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getTileSize()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.TILESIZE, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute SeparationNameTag
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SeparationNameTag </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSeparationNameTag(int @value)
      {
         setAttribute(AttributeName.SEPARATIONNAMETAG, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute SeparationNameTag </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getSeparationNameTag()
      {
         return getIntAttribute(AttributeName.SEPARATIONNAMETAG, null, 270);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateTIFFtag
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFTIFFtag the element </returns>
      ///     
      public virtual JDFTIFFtag getCreateTIFFtag(int iSkip)
      {
         return (JDFTIFFtag)getCreateElement_KElement(ElementName.TIFFTAG, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element TIFFtag </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFTIFFtag the element </returns>
      ///     * default is getTIFFtag(0)     
      public virtual JDFTIFFtag getTIFFtag(int iSkip)
      {
         return (JDFTIFFtag)getElement(ElementName.TIFFTAG, null, iSkip);
      }

      ///    
      ///     <summary> * Get all TIFFtag from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFTIFFtag> </returns>
      ///     
      public virtual ICollection<JDFTIFFtag> getAllTIFFtag()
      {
         List<JDFTIFFtag> v = new List<JDFTIFFtag>();

         JDFTIFFtag kElem = (JDFTIFFtag)getFirstChildElement(ElementName.TIFFTAG, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFTIFFtag)kElem.getNextSiblingElement(ElementName.TIFFTAG, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element TIFFtag </summary>
      ///     
      public virtual JDFTIFFtag appendTIFFtag()
      {
         return (JDFTIFFtag)appendElement(ElementName.TIFFTAG, null);
      }

      ///     <summary> (26) getCreateTIFFEmbeddedFile
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFTIFFEmbeddedFile the element </returns>
      ///     
      public virtual JDFTIFFEmbeddedFile getCreateTIFFEmbeddedFile(int iSkip)
      {
         return (JDFTIFFEmbeddedFile)getCreateElement_KElement(ElementName.TIFFEMBEDDEDFILE, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element TIFFEmbeddedFile </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFTIFFEmbeddedFile the element </returns>
      ///     * default is getTIFFEmbeddedFile(0)     
      public virtual JDFTIFFEmbeddedFile getTIFFEmbeddedFile(int iSkip)
      {
         return (JDFTIFFEmbeddedFile)getElement(ElementName.TIFFEMBEDDEDFILE, null, iSkip);
      }

      ///    
      ///     <summary> * Get all TIFFEmbeddedFile from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFTIFFEmbeddedFile> </returns>
      ///     
      public virtual ICollection<JDFTIFFEmbeddedFile> getAllTIFFEmbeddedFile()
      {
         List<JDFTIFFEmbeddedFile> v = new List<JDFTIFFEmbeddedFile>();

         JDFTIFFEmbeddedFile kElem = (JDFTIFFEmbeddedFile)getFirstChildElement(ElementName.TIFFEMBEDDEDFILE, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFTIFFEmbeddedFile)kElem.getNextSiblingElement(ElementName.TIFFEMBEDDEDFILE, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element TIFFEmbeddedFile </summary>
      ///     
      public virtual JDFTIFFEmbeddedFile appendTIFFEmbeddedFile()
      {
         return (JDFTIFFEmbeddedFile)appendElement(ElementName.TIFFEMBEDDEDFILE, null);
      }
   }
}
