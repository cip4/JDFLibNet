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
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFDeviceNSpace = org.cip4.jdflib.resource.process.JDFDeviceNSpace;
   using JDFFileSpec = org.cip4.jdflib.resource.process.JDFFileSpec;
   using JDFSeparationSpec = org.cip4.jdflib.resource.process.JDFSeparationSpec;

   public abstract class JDFAutoColorSpaceConversionOp : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[9];
      static JDFAutoColorSpaceConversionOp()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.IGNOREEMBEDDEDICC, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.PRESERVEBLACK, 0x33333331, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.RENDERINGINTENT, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumRenderingIntent.getEnum(0), "ColorSpaceDependent");
         atrInfoTable[3] = new AtrInfoTable(AttributeName.RGBGRAY2BLACK, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[4] = new AtrInfoTable(AttributeName.RGBGRAY2BLACKTHRESHOLD, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, "1");
         atrInfoTable[5] = new AtrInfoTable(AttributeName.SOURCEOBJECTS, 0x33333333, AttributeInfo.EnumAttributeType.enumerations, EnumSourceObjects.getEnum(0), "All");
         atrInfoTable[6] = new AtrInfoTable(AttributeName.OPERATION, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumOperation.getEnum(0), null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.SOURCECS, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumSourceCS.getEnum(0), null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.SOURCERENDERINGINTENT, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumSourceRenderingIntent.getEnum(0), null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.DEVICENSPACE, 0x66666611);
         elemInfoTable[1] = new ElemInfoTable(ElementName.FILESPEC, 0x66666666);
         elemInfoTable[2] = new ElemInfoTable(ElementName.SEPARATIONSPEC, 0x33333311);
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
      ///     <summary> * Constructor for JDFAutoColorSpaceConversionOp </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoColorSpaceConversionOp(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoColorSpaceConversionOp </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoColorSpaceConversionOp(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoColorSpaceConversionOp </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoColorSpaceConversionOp(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoColorSpaceConversionOp[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for RenderingIntent </summary>
      ///        

      public class EnumRenderingIntent : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumRenderingIntent(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumRenderingIntent getEnum(string enumName)
         {
            return (EnumRenderingIntent)getEnum(typeof(EnumRenderingIntent), enumName);
         }

         public static EnumRenderingIntent getEnum(int enumValue)
         {
            return (EnumRenderingIntent)getEnum(typeof(EnumRenderingIntent), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumRenderingIntent));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumRenderingIntent));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumRenderingIntent));
         }

         public static readonly EnumRenderingIntent ColorSpaceDependent = new EnumRenderingIntent("ColorSpaceDependent");
         public static readonly EnumRenderingIntent Perceptual = new EnumRenderingIntent("Perceptual");
         public static readonly EnumRenderingIntent Saturation = new EnumRenderingIntent("Saturation");
         public static readonly EnumRenderingIntent RelativeColorimetric = new EnumRenderingIntent("RelativeColorimetric");
         public static readonly EnumRenderingIntent AbsoluteColorimetric = new EnumRenderingIntent("AbsoluteColorimetric");
      }



      ///        
      ///        <summary> * Enumeration strings for SourceObjects </summary>
      ///        

      public class EnumSourceObjects : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumSourceObjects(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumSourceObjects getEnum(string enumName)
         {
            return (EnumSourceObjects)getEnum(typeof(EnumSourceObjects), enumName);
         }

         public static EnumSourceObjects getEnum(int enumValue)
         {
            return (EnumSourceObjects)getEnum(typeof(EnumSourceObjects), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumSourceObjects));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumSourceObjects));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumSourceObjects));
         }

         public static readonly EnumSourceObjects All = new EnumSourceObjects("All");
         public static readonly EnumSourceObjects ImagePhotographic = new EnumSourceObjects("ImagePhotographic");
         public static readonly EnumSourceObjects ImageScreenShot = new EnumSourceObjects("ImageScreenShot");
         public static readonly EnumSourceObjects Text = new EnumSourceObjects("Text");
         public static readonly EnumSourceObjects LineArt = new EnumSourceObjects("LineArt");
         public static readonly EnumSourceObjects SmoothShades = new EnumSourceObjects("SmoothShades");
      }



      ///        
      ///        <summary> * Enumeration strings for Operation </summary>
      ///        

      public class EnumOperation : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumOperation(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumOperation getEnum(string enumName)
         {
            return (EnumOperation)getEnum(typeof(EnumOperation), enumName);
         }

         public static EnumOperation getEnum(int enumValue)
         {
            return (EnumOperation)getEnum(typeof(EnumOperation), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumOperation));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumOperation));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumOperation));
         }

         public static readonly EnumOperation Convert = new EnumOperation("Convert");
         public static readonly EnumOperation Tag = new EnumOperation("Tag");
         public static readonly EnumOperation Untag = new EnumOperation("Untag");
         public static readonly EnumOperation Retag = new EnumOperation("Retag");
         public static readonly EnumOperation ConvertIgnore = new EnumOperation("ConvertIgnore");
      }



      ///        
      ///        <summary> * Enumeration strings for SourceCS </summary>
      ///        

      public class EnumSourceCS : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumSourceCS(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumSourceCS getEnum(string enumName)
         {
            return (EnumSourceCS)getEnum(typeof(EnumSourceCS), enumName);
         }

         public static EnumSourceCS getEnum(int enumValue)
         {
            return (EnumSourceCS)getEnum(typeof(EnumSourceCS), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumSourceCS));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumSourceCS));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumSourceCS));
         }

         public static readonly EnumSourceCS CalGray = new EnumSourceCS("CalGray");
         public static readonly EnumSourceCS CalRGB = new EnumSourceCS("CalRGB");
         public static readonly EnumSourceCS Calibrated = new EnumSourceCS("Calibrated");
         public static readonly EnumSourceCS CIEBased = new EnumSourceCS("CIEBased");
         public static readonly EnumSourceCS CMYK = new EnumSourceCS("CMYK");
         public static readonly EnumSourceCS DeviceN = new EnumSourceCS("DeviceN");
         public static readonly EnumSourceCS DevIndep = new EnumSourceCS("DevIndep");
         public static readonly EnumSourceCS RGB = new EnumSourceCS("RGB");
         public static readonly EnumSourceCS Gray = new EnumSourceCS("Gray");
         public static readonly EnumSourceCS ICCBased = new EnumSourceCS("ICCBased");
         public static readonly EnumSourceCS ICCCMYK = new EnumSourceCS("ICCCMYK");
         public static readonly EnumSourceCS ICCGray = new EnumSourceCS("ICCGray");
         public static readonly EnumSourceCS ICCLAB = new EnumSourceCS("ICCLAB");
         public static readonly EnumSourceCS ICCRGB = new EnumSourceCS("ICCRGB");
         public static readonly EnumSourceCS Lab = new EnumSourceCS("Lab");
         public static readonly EnumSourceCS Separtation = new EnumSourceCS("Separtation");
         public static readonly EnumSourceCS YUV = new EnumSourceCS("YUV");
      }



      ///        
      ///        <summary> * Enumeration strings for SourceRenderingIntent </summary>
      ///        

      public class EnumSourceRenderingIntent : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumSourceRenderingIntent(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumSourceRenderingIntent getEnum(string enumName)
         {
            return (EnumSourceRenderingIntent)getEnum(typeof(EnumSourceRenderingIntent), enumName);
         }

         public static EnumSourceRenderingIntent getEnum(int enumValue)
         {
            return (EnumSourceRenderingIntent)getEnum(typeof(EnumSourceRenderingIntent), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumSourceRenderingIntent));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumSourceRenderingIntent));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumSourceRenderingIntent));
         }

         public static readonly EnumSourceRenderingIntent ColorSpaceDependent = new EnumSourceRenderingIntent("ColorSpaceDependent");
         public static readonly EnumSourceRenderingIntent Perceptual = new EnumSourceRenderingIntent("Perceptual");
         public static readonly EnumSourceRenderingIntent Saturation = new EnumSourceRenderingIntent("Saturation");
         public static readonly EnumSourceRenderingIntent RelativeColorimetric = new EnumSourceRenderingIntent("RelativeColorimetric");
         public static readonly EnumSourceRenderingIntent AbsoluteColorimetric = new EnumSourceRenderingIntent("AbsoluteColorimetric");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute IgnoreEmbeddedICC
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute IgnoreEmbeddedICC </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setIgnoreEmbeddedICC(bool @value)
      {
         setAttribute(AttributeName.IGNOREEMBEDDEDICC, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute IgnoreEmbeddedICC </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getIgnoreEmbeddedICC()
      {
         return getBoolAttribute(AttributeName.IGNOREEMBEDDEDICC, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PreserveBlack
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PreserveBlack </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPreserveBlack(bool @value)
      {
         setAttribute(AttributeName.PRESERVEBLACK, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute PreserveBlack </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getPreserveBlack()
      {
         return getBoolAttribute(AttributeName.PRESERVEBLACK, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute RenderingIntent
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute RenderingIntent </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setRenderingIntent(EnumRenderingIntent enumVar)
      {
         setAttribute(AttributeName.RENDERINGINTENT, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute RenderingIntent </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumRenderingIntent getRenderingIntent()
      {
         return EnumRenderingIntent.getEnum(getAttribute(AttributeName.RENDERINGINTENT, null, "ColorSpaceDependent"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute RGBGray2Black
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute RGBGray2Black </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setRGBGray2Black(bool @value)
      {
         setAttribute(AttributeName.RGBGRAY2BLACK, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute RGBGray2Black </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getRGBGray2Black()
      {
         return getBoolAttribute(AttributeName.RGBGRAY2BLACK, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute RGBGray2BlackThreshold
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute RGBGray2BlackThreshold </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setRGBGray2BlackThreshold(double @value)
      {
         setAttribute(AttributeName.RGBGRAY2BLACKTHRESHOLD, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute RGBGray2BlackThreshold </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getRGBGray2BlackThreshold()
      {
         return getRealAttribute(AttributeName.RGBGRAY2BLACKTHRESHOLD, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SourceObjects
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5.2) set attribute SourceObjects </summary>
      ///          * <param name="v"> vector of the enumeration values </param>
      ///          
      public virtual void setSourceObjects(List<ValuedEnum> v)
      {
         setEnumerationsAttribute(AttributeName.SOURCEOBJECTS, v, null);
      }

      ///        
      ///          <summary> * (9.2) get SourceObjects attribute SourceObjects </summary>
      ///          * <returns> Vector of the enumerations </returns>
      ///          
      public virtual List<ValuedEnum> getSourceObjects()
      {
         return getEnumerationsAttribute(AttributeName.SOURCEOBJECTS, null, EnumSourceObjects.All, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Operation
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Operation </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setOperation(EnumOperation enumVar)
      {
         setAttribute(AttributeName.OPERATION, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Operation </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumOperation getOperation()
      {
         return EnumOperation.getEnum(getAttribute(AttributeName.OPERATION, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SourceCS
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute SourceCS </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setSourceCS(EnumSourceCS enumVar)
      {
         setAttribute(AttributeName.SOURCECS, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute SourceCS </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumSourceCS getSourceCS()
      {
         return EnumSourceCS.getEnum(getAttribute(AttributeName.SOURCECS, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SourceRenderingIntent
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute SourceRenderingIntent </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setSourceRenderingIntent(EnumSourceRenderingIntent enumVar)
      {
         setAttribute(AttributeName.SOURCERENDERINGINTENT, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute SourceRenderingIntent </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumSourceRenderingIntent getSourceRenderingIntent()
      {
         return EnumSourceRenderingIntent.getEnum(getAttribute(AttributeName.SOURCERENDERINGINTENT, null, null));
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element DeviceNSpace </summary>
      ///     * <returns> JDFDeviceNSpace the element </returns>
      ///     
      public virtual JDFDeviceNSpace getDeviceNSpace()
      {
         return (JDFDeviceNSpace)getElement(ElementName.DEVICENSPACE, null, 0);
      }

      ///     <summary> (25) getCreateDeviceNSpace
      ///     *  </summary>
      ///     * <returns> JDFDeviceNSpace the element </returns>
      ///     
      public virtual JDFDeviceNSpace getCreateDeviceNSpace()
      {
         return (JDFDeviceNSpace)getCreateElement_KElement(ElementName.DEVICENSPACE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element DeviceNSpace </summary>
      ///     
      public virtual JDFDeviceNSpace appendDeviceNSpace()
      {
         return (JDFDeviceNSpace)appendElementN(ElementName.DEVICENSPACE, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refDeviceNSpace(JDFDeviceNSpace refTarget)
      {
         refElement(refTarget);
      }

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

      ///     <summary> (26) getCreateSeparationSpec
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFSeparationSpec the element </returns>
      ///     
      public virtual JDFSeparationSpec getCreateSeparationSpec(int iSkip)
      {
         return (JDFSeparationSpec)getCreateElement_KElement(ElementName.SEPARATIONSPEC, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element SeparationSpec </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFSeparationSpec the element </returns>
      ///     * default is getSeparationSpec(0)     
      public virtual JDFSeparationSpec getSeparationSpec(int iSkip)
      {
         return (JDFSeparationSpec)getElement(ElementName.SEPARATIONSPEC, null, iSkip);
      }

      ///    
      ///     <summary> * Get all SeparationSpec from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFSeparationSpec> </returns>
      ///     
      public virtual ICollection<JDFSeparationSpec> getAllSeparationSpec()
      {
         List<JDFSeparationSpec> v = new List<JDFSeparationSpec>();

         JDFSeparationSpec kElem = (JDFSeparationSpec)getFirstChildElement(ElementName.SEPARATIONSPEC, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFSeparationSpec)kElem.getNextSiblingElement(ElementName.SEPARATIONSPEC, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element SeparationSpec </summary>
      ///     
      public virtual JDFSeparationSpec appendSeparationSpec()
      {
         return (JDFSeparationSpec)appendElement(ElementName.SEPARATIONSPEC, null);
      }
   }
}
