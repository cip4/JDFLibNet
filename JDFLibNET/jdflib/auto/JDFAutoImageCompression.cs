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
   using JDFCCITTFaxParams = org.cip4.jdflib.resource.process.JDFCCITTFaxParams;
   using JDFDCTParams = org.cip4.jdflib.resource.process.JDFDCTParams;
   using JDFJBIG2Params = org.cip4.jdflib.resource.process.JDFJBIG2Params;
   using JDFJPEG2000Params = org.cip4.jdflib.resource.process.JDFJPEG2000Params;
   using JDFLZWParams = org.cip4.jdflib.resource.process.JDFLZWParams;

   public abstract class JDFAutoImageCompression : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[15];
      static JDFAutoImageCompression()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ANTIALIASIMAGES, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.AUTOFILTERIMAGES, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "true");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.CONVERTIMAGESTOINDEXED, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.DCTQUALITY, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, "0");
         atrInfoTable[4] = new AtrInfoTable(AttributeName.DOWNSAMPLEIMAGES, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[5] = new AtrInfoTable(AttributeName.ENCODECOLORIMAGES, 0x44444443, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.ENCODEIMAGES, 0x33333331, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[7] = new AtrInfoTable(AttributeName.IMAGEAUTOFILTERSTRATEGY, 0x33333311, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.IMAGEDEPTH, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.IMAGEDOWNSAMPLETHRESHOLD, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, "2.0");
         atrInfoTable[10] = new AtrInfoTable(AttributeName.IMAGEDOWNSAMPLETYPE, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumImageDownsampleType.getEnum(0), null);
         atrInfoTable[11] = new AtrInfoTable(AttributeName.IMAGEFILTER, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[12] = new AtrInfoTable(AttributeName.IMAGERESOLUTION, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[13] = new AtrInfoTable(AttributeName.IMAGETYPE, 0x22222222, AttributeInfo.EnumAttributeType.enumeration, EnumImageType.getEnum(0), null);
         atrInfoTable[14] = new AtrInfoTable(AttributeName.JPXQUALITY, 0x33333311, AttributeInfo.EnumAttributeType.integer, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.CCITTFAXPARAMS, 0x66666611);
         elemInfoTable[1] = new ElemInfoTable(ElementName.DCTPARAMS, 0x66666611);
         elemInfoTable[2] = new ElemInfoTable(ElementName.JBIG2PARAMS, 0x33333111);
         elemInfoTable[3] = new ElemInfoTable(ElementName.JPEG2000PARAMS, 0x33333111);
         elemInfoTable[4] = new ElemInfoTable(ElementName.LZWPARAMS, 0x66666611);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[5];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoImageCompression </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoImageCompression(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoImageCompression </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoImageCompression(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoImageCompression </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoImageCompression(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoImageCompression[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for ImageDownsampleType </summary>
      ///        

      public class EnumImageDownsampleType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumImageDownsampleType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumImageDownsampleType getEnum(string enumName)
         {
            return (EnumImageDownsampleType)getEnum(typeof(EnumImageDownsampleType), enumName);
         }

         public static EnumImageDownsampleType getEnum(int enumValue)
         {
            return (EnumImageDownsampleType)getEnum(typeof(EnumImageDownsampleType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumImageDownsampleType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumImageDownsampleType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumImageDownsampleType));
         }

         public static readonly EnumImageDownsampleType Average = new EnumImageDownsampleType("Average");
         public static readonly EnumImageDownsampleType Bicubic = new EnumImageDownsampleType("Bicubic");
         public static readonly EnumImageDownsampleType Subsample = new EnumImageDownsampleType("Subsample");
      }



      ///        
      ///        <summary> * Enumeration strings for ImageType </summary>
      ///        

      public class EnumImageType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumImageType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumImageType getEnum(string enumName)
         {
            return (EnumImageType)getEnum(typeof(EnumImageType), enumName);
         }

         public static EnumImageType getEnum(int enumValue)
         {
            return (EnumImageType)getEnum(typeof(EnumImageType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumImageType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumImageType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumImageType));
         }

         public static readonly EnumImageType Color = new EnumImageType("Color");
         public static readonly EnumImageType Grayscale = new EnumImageType("Grayscale");
         public static readonly EnumImageType Monochrome = new EnumImageType("Monochrome");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute AntiAliasImages
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute AntiAliasImages </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAntiAliasImages(bool @value)
      {
         setAttribute(AttributeName.ANTIALIASIMAGES, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute AntiAliasImages </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getAntiAliasImages()
      {
         return getBoolAttribute(AttributeName.ANTIALIASIMAGES, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute AutoFilterImages
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute AutoFilterImages </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAutoFilterImages(bool @value)
      {
         setAttribute(AttributeName.AUTOFILTERIMAGES, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute AutoFilterImages </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getAutoFilterImages()
      {
         return getBoolAttribute(AttributeName.AUTOFILTERIMAGES, null, true);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ConvertImagesToIndexed
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ConvertImagesToIndexed </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setConvertImagesToIndexed(bool @value)
      {
         setAttribute(AttributeName.CONVERTIMAGESTOINDEXED, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute ConvertImagesToIndexed </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getConvertImagesToIndexed()
      {
         return getBoolAttribute(AttributeName.CONVERTIMAGESTOINDEXED, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute DCTQuality
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DCTQuality </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDCTQuality(double @value)
      {
         setAttribute(AttributeName.DCTQUALITY, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute DCTQuality </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getDCTQuality()
      {
         return getRealAttribute(AttributeName.DCTQUALITY, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute DownsampleImages
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DownsampleImages </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDownsampleImages(bool @value)
      {
         setAttribute(AttributeName.DOWNSAMPLEIMAGES, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute DownsampleImages </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getDownsampleImages()
      {
         return getBoolAttribute(AttributeName.DOWNSAMPLEIMAGES, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute EncodeColorImages
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute EncodeColorImages </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setEncodeColorImages(bool @value)
      {
         setAttribute(AttributeName.ENCODECOLORIMAGES, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute EncodeColorImages </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getEncodeColorImages()
      {
         return getBoolAttribute(AttributeName.ENCODECOLORIMAGES, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute EncodeImages
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute EncodeImages </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setEncodeImages(bool @value)
      {
         setAttribute(AttributeName.ENCODEIMAGES, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute EncodeImages </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getEncodeImages()
      {
         return getBoolAttribute(AttributeName.ENCODEIMAGES, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ImageAutoFilterStrategy
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ImageAutoFilterStrategy </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setImageAutoFilterStrategy(string @value)
      {
         setAttribute(AttributeName.IMAGEAUTOFILTERSTRATEGY, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ImageAutoFilterStrategy </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getImageAutoFilterStrategy()
      {
         return getAttribute(AttributeName.IMAGEAUTOFILTERSTRATEGY, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ImageDepth
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ImageDepth </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setImageDepth(int @value)
      {
         setAttribute(AttributeName.IMAGEDEPTH, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute ImageDepth </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getImageDepth()
      {
         return getIntAttribute(AttributeName.IMAGEDEPTH, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ImageDownsampleThreshold
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ImageDownsampleThreshold </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setImageDownsampleThreshold(double @value)
      {
         setAttribute(AttributeName.IMAGEDOWNSAMPLETHRESHOLD, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute ImageDownsampleThreshold </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getImageDownsampleThreshold()
      {
         return getRealAttribute(AttributeName.IMAGEDOWNSAMPLETHRESHOLD, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ImageDownsampleType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute ImageDownsampleType </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setImageDownsampleType(EnumImageDownsampleType enumVar)
      {
         setAttribute(AttributeName.IMAGEDOWNSAMPLETYPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute ImageDownsampleType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumImageDownsampleType getImageDownsampleType()
      {
         return EnumImageDownsampleType.getEnum(getAttribute(AttributeName.IMAGEDOWNSAMPLETYPE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ImageFilter
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ImageFilter </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setImageFilter(string @value)
      {
         setAttribute(AttributeName.IMAGEFILTER, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ImageFilter </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getImageFilter()
      {
         return getAttribute(AttributeName.IMAGEFILTER, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ImageResolution
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ImageResolution </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setImageResolution(double @value)
      {
         setAttribute(AttributeName.IMAGERESOLUTION, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute ImageResolution </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getImageResolution()
      {
         return getRealAttribute(AttributeName.IMAGERESOLUTION, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ImageType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute ImageType </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setImageType(EnumImageType enumVar)
      {
         setAttribute(AttributeName.IMAGETYPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute ImageType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumImageType getImageType()
      {
         return EnumImageType.getEnum(getAttribute(AttributeName.IMAGETYPE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute JPXQuality
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute JPXQuality </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setJPXQuality(int @value)
      {
         setAttribute(AttributeName.JPXQUALITY, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute JPXQuality </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getJPXQuality()
      {
         return getIntAttribute(AttributeName.JPXQUALITY, null, 0);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element CCITTFaxParams </summary>
      ///     * <returns> JDFCCITTFaxParams the element </returns>
      ///     
      public virtual JDFCCITTFaxParams getCCITTFaxParams()
      {
         return (JDFCCITTFaxParams)getElement(ElementName.CCITTFAXPARAMS, null, 0);
      }

      ///     <summary> (25) getCreateCCITTFaxParams
      ///     *  </summary>
      ///     * <returns> JDFCCITTFaxParams the element </returns>
      ///     
      public virtual JDFCCITTFaxParams getCreateCCITTFaxParams()
      {
         return (JDFCCITTFaxParams)getCreateElement_KElement(ElementName.CCITTFAXPARAMS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element CCITTFaxParams </summary>
      ///     
      public virtual JDFCCITTFaxParams appendCCITTFaxParams()
      {
         return (JDFCCITTFaxParams)appendElementN(ElementName.CCITTFAXPARAMS, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element DCTParams </summary>
      ///     * <returns> JDFDCTParams the element </returns>
      ///     
      public virtual JDFDCTParams getDCTParams()
      {
         return (JDFDCTParams)getElement(ElementName.DCTPARAMS, null, 0);
      }

      ///     <summary> (25) getCreateDCTParams
      ///     *  </summary>
      ///     * <returns> JDFDCTParams the element </returns>
      ///     
      public virtual JDFDCTParams getCreateDCTParams()
      {
         return (JDFDCTParams)getCreateElement_KElement(ElementName.DCTPARAMS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element DCTParams </summary>
      ///     
      public virtual JDFDCTParams appendDCTParams()
      {
         return (JDFDCTParams)appendElementN(ElementName.DCTPARAMS, 1, null);
      }

      ///     <summary> (26) getCreateJBIG2Params
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFJBIG2Params the element </returns>
      ///     
      public virtual JDFJBIG2Params getCreateJBIG2Params(int iSkip)
      {
         return (JDFJBIG2Params)getCreateElement_KElement(ElementName.JBIG2PARAMS, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element JBIG2Params </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFJBIG2Params the element </returns>
      ///     * default is getJBIG2Params(0)     
      public virtual JDFJBIG2Params getJBIG2Params(int iSkip)
      {
         return (JDFJBIG2Params)getElement(ElementName.JBIG2PARAMS, null, iSkip);
      }

      ///    
      ///     <summary> * Get all JBIG2Params from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFJBIG2Params> </returns>
      ///     
      public virtual ICollection<JDFJBIG2Params> getAllJBIG2Params()
      {
         List<JDFJBIG2Params> v = new List<JDFJBIG2Params>();

         JDFJBIG2Params kElem = (JDFJBIG2Params)getFirstChildElement(ElementName.JBIG2PARAMS, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFJBIG2Params)kElem.getNextSiblingElement(ElementName.JBIG2PARAMS, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element JBIG2Params </summary>
      ///     
      public virtual JDFJBIG2Params appendJBIG2Params()
      {
         return (JDFJBIG2Params)appendElement(ElementName.JBIG2PARAMS, null);
      }

      ///     <summary> (26) getCreateJPEG2000Params
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFJPEG2000Params the element </returns>
      ///     
      public virtual JDFJPEG2000Params getCreateJPEG2000Params(int iSkip)
      {
         return (JDFJPEG2000Params)getCreateElement_KElement(ElementName.JPEG2000PARAMS, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element JPEG2000Params </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFJPEG2000Params the element </returns>
      ///     * default is getJPEG2000Params(0)     
      public virtual JDFJPEG2000Params getJPEG2000Params(int iSkip)
      {
         return (JDFJPEG2000Params)getElement(ElementName.JPEG2000PARAMS, null, iSkip);
      }

      ///    
      ///     <summary> * Get all JPEG2000Params from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFJPEG2000Params> </returns>
      ///     
      public virtual ICollection<JDFJPEG2000Params> getAllJPEG2000Params()
      {
         List<JDFJPEG2000Params> v = new List<JDFJPEG2000Params>();

         JDFJPEG2000Params kElem = (JDFJPEG2000Params)getFirstChildElement(ElementName.JPEG2000PARAMS, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFJPEG2000Params)kElem.getNextSiblingElement(ElementName.JPEG2000PARAMS, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element JPEG2000Params </summary>
      ///     
      public virtual JDFJPEG2000Params appendJPEG2000Params()
      {
         return (JDFJPEG2000Params)appendElement(ElementName.JPEG2000PARAMS, null);
      }

      ///    
      ///     <summary> * (24) const get element LZWParams </summary>
      ///     * <returns> JDFLZWParams the element </returns>
      ///     
      public virtual JDFLZWParams getLZWParams()
      {
         return (JDFLZWParams)getElement(ElementName.LZWPARAMS, null, 0);
      }

      ///     <summary> (25) getCreateLZWParams
      ///     *  </summary>
      ///     * <returns> JDFLZWParams the element </returns>
      ///     
      public virtual JDFLZWParams getCreateLZWParams()
      {
         return (JDFLZWParams)getCreateElement_KElement(ElementName.LZWPARAMS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element LZWParams </summary>
      ///     
      public virtual JDFLZWParams appendLZWParams()
      {
         return (JDFLZWParams)appendElementN(ElementName.LZWPARAMS, 1, null);
      }
   }
}
