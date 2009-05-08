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
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFAdvancedParams = org.cip4.jdflib.resource.process.JDFAdvancedParams;
   using JDFPDFXParams = org.cip4.jdflib.resource.process.JDFPDFXParams;
   using JDFThinPDFParams = org.cip4.jdflib.resource.process.JDFThinPDFParams;

   public abstract class JDFAutoPSToPDFConversionParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[15];
      static JDFAutoPSToPDFConversionParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ASCII85ENCODEPAGES, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.BINDING, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumBinding.getEnum(0), "Left");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.DETECTBLEND, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "true");
         atrInfoTable[3] = new AtrInfoTable(AttributeName.DOTHUMBNAILS, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "true");
         atrInfoTable[4] = new AtrInfoTable(AttributeName.OPTIMIZE, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "true");
         atrInfoTable[5] = new AtrInfoTable(AttributeName.AUTOROTATEPAGES, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumAutoRotatePages.getEnum(0), null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.COMPRESSPAGES, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.DEFAULTRENDERINGINTENT, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumDefaultRenderingIntent.getEnum(0), null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.ENDPAGE, 0x44444333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.IMAGEMEMORY, 0x44444433, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[10] = new AtrInfoTable(AttributeName.INITIALPAGESIZE, 0x33333331, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[11] = new AtrInfoTable(AttributeName.INITIALRESOLUTION, 0x33333331, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[12] = new AtrInfoTable(AttributeName.OVERPRINTMODE, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[13] = new AtrInfoTable(AttributeName.PDFVERSION, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[14] = new AtrInfoTable(AttributeName.STARTPAGE, 0x44444333, AttributeInfo.EnumAttributeType.integer, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.ADVANCEDPARAMS, 0x66666666);
         elemInfoTable[1] = new ElemInfoTable(ElementName.PDFXPARAMS, 0x66666611);
         elemInfoTable[2] = new ElemInfoTable(ElementName.THINPDFPARAMS, 0x66666666);
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
      ///     <summary> * Constructor for JDFAutoPSToPDFConversionParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPSToPDFConversionParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPSToPDFConversionParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPSToPDFConversionParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPSToPDFConversionParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoPSToPDFConversionParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoPSToPDFConversionParams[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for Binding </summary>
      ///        

      public class EnumBinding : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumBinding(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumBinding getEnum(string enumName)
         {
            return (EnumBinding)getEnum(typeof(EnumBinding), enumName);
         }

         public static EnumBinding getEnum(int enumValue)
         {
            return (EnumBinding)getEnum(typeof(EnumBinding), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumBinding));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumBinding));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumBinding));
         }

         public static readonly EnumBinding Left = new EnumBinding("Left");
         public static readonly EnumBinding Right = new EnumBinding("Right");
      }



      ///        
      ///        <summary> * Enumeration strings for AutoRotatePages </summary>
      ///        

      public class EnumAutoRotatePages : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumAutoRotatePages(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumAutoRotatePages getEnum(string enumName)
         {
            return (EnumAutoRotatePages)getEnum(typeof(EnumAutoRotatePages), enumName);
         }

         public static EnumAutoRotatePages getEnum(int enumValue)
         {
            return (EnumAutoRotatePages)getEnum(typeof(EnumAutoRotatePages), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumAutoRotatePages));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumAutoRotatePages));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumAutoRotatePages));
         }

         public static readonly EnumAutoRotatePages None = new EnumAutoRotatePages("None");
         public static readonly EnumAutoRotatePages All = new EnumAutoRotatePages("All");
         public static readonly EnumAutoRotatePages PageByPage = new EnumAutoRotatePages("PageByPage");
      }



      ///        
      ///        <summary> * Enumeration strings for DefaultRenderingIntent </summary>
      ///        

      public class EnumDefaultRenderingIntent : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumDefaultRenderingIntent(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumDefaultRenderingIntent getEnum(string enumName)
         {
            return (EnumDefaultRenderingIntent)getEnum(typeof(EnumDefaultRenderingIntent), enumName);
         }

         public static EnumDefaultRenderingIntent getEnum(int enumValue)
         {
            return (EnumDefaultRenderingIntent)getEnum(typeof(EnumDefaultRenderingIntent), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumDefaultRenderingIntent));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumDefaultRenderingIntent));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumDefaultRenderingIntent));
         }

         public static readonly EnumDefaultRenderingIntent Default = new EnumDefaultRenderingIntent("Default");
         public static readonly EnumDefaultRenderingIntent Perceptual = new EnumDefaultRenderingIntent("Perceptual");
         public static readonly EnumDefaultRenderingIntent Saturation = new EnumDefaultRenderingIntent("Saturation");
         public static readonly EnumDefaultRenderingIntent RelativeColorimetric = new EnumDefaultRenderingIntent("RelativeColorimetric");
         public static readonly EnumDefaultRenderingIntent AbsoluteColorimetric = new EnumDefaultRenderingIntent("AbsoluteColorimetric");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute ASCII85EncodePages
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ASCII85EncodePages </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setASCII85EncodePages(bool @value)
      {
         setAttribute(AttributeName.ASCII85ENCODEPAGES, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute ASCII85EncodePages </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getASCII85EncodePages()
      {
         return getBoolAttribute(AttributeName.ASCII85ENCODEPAGES, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Binding
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Binding </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setBinding(EnumBinding enumVar)
      {
         setAttribute(AttributeName.BINDING, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Binding </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumBinding getBinding()
      {
         return EnumBinding.getEnum(getAttribute(AttributeName.BINDING, null, "Left"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute DetectBlend
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DetectBlend </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDetectBlend(bool @value)
      {
         setAttribute(AttributeName.DETECTBLEND, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute DetectBlend </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getDetectBlend()
      {
         return getBoolAttribute(AttributeName.DETECTBLEND, null, true);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute DoThumbnails
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DoThumbnails </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDoThumbnails(bool @value)
      {
         setAttribute(AttributeName.DOTHUMBNAILS, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute DoThumbnails </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getDoThumbnails()
      {
         return getBoolAttribute(AttributeName.DOTHUMBNAILS, null, true);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Optimize
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Optimize </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setOptimize(bool @value)
      {
         setAttribute(AttributeName.OPTIMIZE, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute Optimize </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getOptimize()
      {
         return getBoolAttribute(AttributeName.OPTIMIZE, null, true);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute AutoRotatePages
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute AutoRotatePages </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setAutoRotatePages(EnumAutoRotatePages enumVar)
      {
         setAttribute(AttributeName.AUTOROTATEPAGES, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute AutoRotatePages </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumAutoRotatePages getAutoRotatePages()
      {
         return EnumAutoRotatePages.getEnum(getAttribute(AttributeName.AUTOROTATEPAGES, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute CompressPages
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CompressPages </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCompressPages(bool @value)
      {
         setAttribute(AttributeName.COMPRESSPAGES, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute CompressPages </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getCompressPages()
      {
         return getBoolAttribute(AttributeName.COMPRESSPAGES, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute DefaultRenderingIntent
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute DefaultRenderingIntent </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setDefaultRenderingIntent(EnumDefaultRenderingIntent enumVar)
      {
         setAttribute(AttributeName.DEFAULTRENDERINGINTENT, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute DefaultRenderingIntent </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumDefaultRenderingIntent getDefaultRenderingIntent()
      {
         return EnumDefaultRenderingIntent.getEnum(getAttribute(AttributeName.DEFAULTRENDERINGINTENT, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute EndPage
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute EndPage </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setEndPage(int @value)
      {
         setAttribute(AttributeName.ENDPAGE, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute EndPage </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getEndPage()
      {
         return getIntAttribute(AttributeName.ENDPAGE, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ImageMemory
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ImageMemory </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setImageMemory(int @value)
      {
         setAttribute(AttributeName.IMAGEMEMORY, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute ImageMemory </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getImageMemory()
      {
         return getIntAttribute(AttributeName.IMAGEMEMORY, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute InitialPageSize
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute InitialPageSize </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setInitialPageSize(JDFXYPair @value)
      {
         setAttribute(AttributeName.INITIALPAGESIZE, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute InitialPageSize </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getInitialPageSize()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.INITIALPAGESIZE, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute InitialResolution
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute InitialResolution </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setInitialResolution(JDFXYPair @value)
      {
         setAttribute(AttributeName.INITIALRESOLUTION, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute InitialResolution </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getInitialResolution()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.INITIALRESOLUTION, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute OverPrintMode
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute OverPrintMode </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setOverPrintMode(int @value)
      {
         setAttribute(AttributeName.OVERPRINTMODE, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute OverPrintMode </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getOverPrintMode()
      {
         return getIntAttribute(AttributeName.OVERPRINTMODE, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PDFVersion
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PDFVersion </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPDFVersion(double @value)
      {
         setAttribute(AttributeName.PDFVERSION, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute PDFVersion </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getPDFVersion()
      {
         return getRealAttribute(AttributeName.PDFVERSION, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute StartPage
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute StartPage </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setStartPage(int @value)
      {
         setAttribute(AttributeName.STARTPAGE, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute StartPage </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getStartPage()
      {
         return getIntAttribute(AttributeName.STARTPAGE, null, 0);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element AdvancedParams </summary>
      ///     * <returns> JDFAdvancedParams the element </returns>
      ///     
      public virtual JDFAdvancedParams getAdvancedParams()
      {
         return (JDFAdvancedParams)getElement(ElementName.ADVANCEDPARAMS, null, 0);
      }

      ///     <summary> (25) getCreateAdvancedParams
      ///     *  </summary>
      ///     * <returns> JDFAdvancedParams the element </returns>
      ///     
      public virtual JDFAdvancedParams getCreateAdvancedParams()
      {
         return (JDFAdvancedParams)getCreateElement_KElement(ElementName.ADVANCEDPARAMS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element AdvancedParams </summary>
      ///     
      public virtual JDFAdvancedParams appendAdvancedParams()
      {
         return (JDFAdvancedParams)appendElementN(ElementName.ADVANCEDPARAMS, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element PDFXParams </summary>
      ///     * <returns> JDFPDFXParams the element </returns>
      ///     
      public virtual JDFPDFXParams getPDFXParams()
      {
         return (JDFPDFXParams)getElement(ElementName.PDFXPARAMS, null, 0);
      }

      ///     <summary> (25) getCreatePDFXParams
      ///     *  </summary>
      ///     * <returns> JDFPDFXParams the element </returns>
      ///     
      public virtual JDFPDFXParams getCreatePDFXParams()
      {
         return (JDFPDFXParams)getCreateElement_KElement(ElementName.PDFXPARAMS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element PDFXParams </summary>
      ///     
      public virtual JDFPDFXParams appendPDFXParams()
      {
         return (JDFPDFXParams)appendElementN(ElementName.PDFXPARAMS, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element ThinPDFParams </summary>
      ///     * <returns> JDFThinPDFParams the element </returns>
      ///     
      public virtual JDFThinPDFParams getThinPDFParams()
      {
         return (JDFThinPDFParams)getElement(ElementName.THINPDFPARAMS, null, 0);
      }

      ///     <summary> (25) getCreateThinPDFParams
      ///     *  </summary>
      ///     * <returns> JDFThinPDFParams the element </returns>
      ///     
      public virtual JDFThinPDFParams getCreateThinPDFParams()
      {
         return (JDFThinPDFParams)getCreateElement_KElement(ElementName.THINPDFPARAMS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ThinPDFParams </summary>
      ///     
      public virtual JDFThinPDFParams appendThinPDFParams()
      {
         return (JDFThinPDFParams)appendElementN(ElementName.THINPDFPARAMS, 1, null);
      }
   }
}
