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


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFRectangle = org.cip4.jdflib.datatypes.JDFRectangle;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFFileSpec = org.cip4.jdflib.resource.process.JDFFileSpec;

   public abstract class JDFAutoScanParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[11];
      static JDFAutoScanParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.BITDEPTH, 0x22222222, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.MAGNIFICATION, 0x33333333, AttributeInfo.EnumAttributeType.XYPair, null, "1 1");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.OUTPUTCOLORSPACE, 0x22222222, AttributeInfo.EnumAttributeType.enumeration, EnumOutputColorSpace.getEnum(0), null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.COMPRESSIONFILTER, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumCompressionFilter.getEnum(0), null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.DCTQUALITY, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.INPUTBOX, 0x33333333, AttributeInfo.EnumAttributeType.rectangle, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.MOUNTID, 0x33333333, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.MOUNTING, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumMounting.getEnum(0), null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.OUTPUTRESOLUTION, 0x33333333, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.OUTPUTSIZE, 0x33333333, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[10] = new AtrInfoTable(AttributeName.SPLITDOCUMENTS, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.FILESPEC, 0x66666666);
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
      ///     <summary> * Constructor for JDFAutoScanParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoScanParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoScanParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoScanParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoScanParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoScanParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoScanParams[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for OutputColorSpace </summary>
      ///        

      public class EnumOutputColorSpace : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumOutputColorSpace(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumOutputColorSpace getEnum(string enumName)
         {
            return (EnumOutputColorSpace)getEnum(typeof(EnumOutputColorSpace), enumName);
         }

         public static EnumOutputColorSpace getEnum(int enumValue)
         {
            return (EnumOutputColorSpace)getEnum(typeof(EnumOutputColorSpace), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumOutputColorSpace));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumOutputColorSpace));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumOutputColorSpace));
         }

         public static readonly EnumOutputColorSpace LAB = new EnumOutputColorSpace("LAB");
         public static readonly EnumOutputColorSpace RGB = new EnumOutputColorSpace("RGB");
         public static readonly EnumOutputColorSpace CMYK = new EnumOutputColorSpace("CMYK");
         public static readonly EnumOutputColorSpace GrayScale = new EnumOutputColorSpace("GrayScale");
      }



      ///        
      ///        <summary> * Enumeration strings for CompressionFilter </summary>
      ///        

      public class EnumCompressionFilter : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumCompressionFilter(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumCompressionFilter getEnum(string enumName)
         {
            return (EnumCompressionFilter)getEnum(typeof(EnumCompressionFilter), enumName);
         }

         public static EnumCompressionFilter getEnum(int enumValue)
         {
            return (EnumCompressionFilter)getEnum(typeof(EnumCompressionFilter), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumCompressionFilter));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumCompressionFilter));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumCompressionFilter));
         }

         public static readonly EnumCompressionFilter CCITTFaxEncode = new EnumCompressionFilter("CCITTFaxEncode");
         public static readonly EnumCompressionFilter DCTEncode = new EnumCompressionFilter("DCTEncode");
         public static readonly EnumCompressionFilter FlateEncode = new EnumCompressionFilter("FlateEncode");
         public static readonly EnumCompressionFilter WaveletEncode = new EnumCompressionFilter("WaveletEncode");
         public static readonly EnumCompressionFilter JBIG2Encode = new EnumCompressionFilter("JBIG2Encode");
      }



      ///        
      ///        <summary> * Enumeration strings for Mounting </summary>
      ///        

      public class EnumMounting : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumMounting(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumMounting getEnum(string enumName)
         {
            return (EnumMounting)getEnum(typeof(EnumMounting), enumName);
         }

         public static EnumMounting getEnum(int enumValue)
         {
            return (EnumMounting)getEnum(typeof(EnumMounting), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumMounting));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumMounting));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumMounting));
         }

         public static readonly EnumMounting Unfixed = new EnumMounting("Unfixed");
         public static readonly EnumMounting Fixed = new EnumMounting("Fixed");
         public static readonly EnumMounting Wet = new EnumMounting("Wet");
         public static readonly EnumMounting Registered = new EnumMounting("Registered");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute BitDepth
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BitDepth </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBitDepth(int @value)
      {
         setAttribute(AttributeName.BITDEPTH, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute BitDepth </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getBitDepth()
      {
         return getIntAttribute(AttributeName.BITDEPTH, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Magnification
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Magnification </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMagnification(JDFXYPair @value)
      {
         setAttribute(AttributeName.MAGNIFICATION, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute Magnification </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getMagnification()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.MAGNIFICATION, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute OutputColorSpace
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute OutputColorSpace </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setOutputColorSpace(EnumOutputColorSpace enumVar)
      {
         setAttribute(AttributeName.OUTPUTCOLORSPACE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute OutputColorSpace </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumOutputColorSpace getOutputColorSpace()
      {
         return EnumOutputColorSpace.getEnum(getAttribute(AttributeName.OUTPUTCOLORSPACE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute CompressionFilter
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute CompressionFilter </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setCompressionFilter(EnumCompressionFilter enumVar)
      {
         setAttribute(AttributeName.COMPRESSIONFILTER, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute CompressionFilter </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumCompressionFilter getCompressionFilter()
      {
         return EnumCompressionFilter.getEnum(getAttribute(AttributeName.COMPRESSIONFILTER, null, null));
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
      //        Methods for Attribute InputBox
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute InputBox </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setInputBox(JDFRectangle @value)
      {
         setAttribute(AttributeName.INPUTBOX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFRectangle attribute InputBox </summary>
      ///          * <returns> JDFRectangle the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFRectangle </returns>
      ///          
      public virtual JDFRectangle getInputBox()
      {
         string strAttrName = "";
         JDFRectangle nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.INPUTBOX, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFRectangle(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MountID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MountID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMountID(string @value)
      {
         setAttribute(AttributeName.MOUNTID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute MountID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getMountID()
      {
         return getAttribute(AttributeName.MOUNTID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Mounting
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Mounting </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setMounting(EnumMounting enumVar)
      {
         setAttribute(AttributeName.MOUNTING, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Mounting </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumMounting getMounting()
      {
         return EnumMounting.getEnum(getAttribute(AttributeName.MOUNTING, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute OutputResolution
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute OutputResolution </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setOutputResolution(JDFXYPair @value)
      {
         setAttribute(AttributeName.OUTPUTRESOLUTION, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute OutputResolution </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getOutputResolution()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.OUTPUTRESOLUTION, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute OutputSize
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute OutputSize </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setOutputSize(JDFXYPair @value)
      {
         setAttribute(AttributeName.OUTPUTSIZE, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute OutputSize </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getOutputSize()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.OUTPUTSIZE, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute SplitDocuments
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SplitDocuments </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSplitDocuments(int @value)
      {
         setAttribute(AttributeName.SPLITDOCUMENTS, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute SplitDocuments </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getSplitDocuments()
      {
         return getIntAttribute(AttributeName.SPLITDOCUMENTS, null, 0);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element FileSpec </summary>
      ///     * <returns> JDFFileSpec the element </returns>
      ///     
      public virtual JDFFileSpec getFileSpec()
      {
         return (JDFFileSpec)getElement(ElementName.FILESPEC, null, 0);
      }

      ///     <summary> (25) getCreateFileSpec
      ///     *  </summary>
      ///     * <returns> JDFFileSpec the element </returns>
      ///     
      public virtual JDFFileSpec getCreateFileSpec()
      {
         return (JDFFileSpec)getCreateElement_KElement(ElementName.FILESPEC, null, 0);
      }

      ///    
      ///     <summary> * (29) append element FileSpec </summary>
      ///     
      public virtual JDFFileSpec appendFileSpec()
      {
         return (JDFFileSpec)appendElementN(ElementName.FILESPEC, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refFileSpec(JDFFileSpec refTarget)
      {
         refElement(refTarget);
      }
   }
}
