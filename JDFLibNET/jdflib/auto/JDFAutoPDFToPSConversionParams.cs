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
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFRectangle = org.cip4.jdflib.datatypes.JDFRectangle;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;

   public abstract class JDFAutoPDFToPSConversionParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[37];
      static JDFAutoPDFToPSConversionParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.BINARYOK, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "true");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.CENTERCROPBOX, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "true");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.GENERATEPAGESTREAMS, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[3] = new AtrInfoTable(AttributeName.IGNOREANNOTFORMS, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[4] = new AtrInfoTable(AttributeName.IGNOREBG, 0x33333331, AttributeInfo.EnumAttributeType.boolean_, null, "true");
         atrInfoTable[5] = new AtrInfoTable(AttributeName.IGNORECOLORSEPS, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[6] = new AtrInfoTable(AttributeName.IGNOREDSC, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "true");
         atrInfoTable[7] = new AtrInfoTable(AttributeName.IGNOREEXTERNSTREAMREF, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[8] = new AtrInfoTable(AttributeName.IGNOREHALFTONES, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[9] = new AtrInfoTable(AttributeName.IGNOREOVERPRINT, 0x33333331, AttributeInfo.EnumAttributeType.boolean_, null, "true");
         atrInfoTable[10] = new AtrInfoTable(AttributeName.IGNOREPAGEROTATION, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[11] = new AtrInfoTable(AttributeName.IGNORERAWDATA, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[12] = new AtrInfoTable(AttributeName.IGNORESEPARABLEIMAGESONLY, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[13] = new AtrInfoTable(AttributeName.IGNORESHOWPAGE, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[14] = new AtrInfoTable(AttributeName.IGNORETRANSFERS, 0x33333331, AttributeInfo.EnumAttributeType.boolean_, null, "true");
         atrInfoTable[15] = new AtrInfoTable(AttributeName.IGNORETTFONTSFIRST, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[16] = new AtrInfoTable(AttributeName.IGNOREUCR, 0x33333331, AttributeInfo.EnumAttributeType.boolean_, null, "true");
         atrInfoTable[17] = new AtrInfoTable(AttributeName.INCLUDEBASEFONTS, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumIncludeBaseFonts.getEnum(0), "IncludeNever");
         atrInfoTable[18] = new AtrInfoTable(AttributeName.INCLUDECIDFONTS, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumIncludeCIDFonts.getEnum(0), "IncludeOncePerDoc");
         atrInfoTable[19] = new AtrInfoTable(AttributeName.INCLUDEEMBEDDEDFONTS, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumIncludeEmbeddedFonts.getEnum(0), "IncludeOncePerDoc");
         atrInfoTable[20] = new AtrInfoTable(AttributeName.INCLUDEOTHERRESOURCES, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumIncludeOtherResources.getEnum(0), "IncludeOncePerDoc");
         atrInfoTable[21] = new AtrInfoTable(AttributeName.INCLUDEPROCSETS, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumIncludeProcSets.getEnum(0), "IncludeOncePerDoc");
         atrInfoTable[22] = new AtrInfoTable(AttributeName.INCLUDETRUETYPEFONTS, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumIncludeTrueTypeFonts.getEnum(0), "IncludeOncePerDoc");
         atrInfoTable[23] = new AtrInfoTable(AttributeName.INCLUDETYPE1FONTS, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumIncludeType1Fonts.getEnum(0), "IncludeOncePerDoc");
         atrInfoTable[24] = new AtrInfoTable(AttributeName.INCLUDETYPE3FONTS, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumIncludeType3Fonts.getEnum(0), null);
         atrInfoTable[25] = new AtrInfoTable(AttributeName.OUTPUTTYPE, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumOutputType.getEnum(0), "PostScript");
         atrInfoTable[26] = new AtrInfoTable(AttributeName.PSLEVEL, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, "2");
         atrInfoTable[27] = new AtrInfoTable(AttributeName.SCALE, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, "100");
         atrInfoTable[28] = new AtrInfoTable(AttributeName.SETPAGESIZE, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[29] = new AtrInfoTable(AttributeName.SETUPPROCSETS, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "true");
         atrInfoTable[30] = new AtrInfoTable(AttributeName.SHRINKTOFIT, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[31] = new AtrInfoTable(AttributeName.SUPPRESSCENTER, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[32] = new AtrInfoTable(AttributeName.SUPPRESSROTATE, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[33] = new AtrInfoTable(AttributeName.TTAST42, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[34] = new AtrInfoTable(AttributeName.USEFONTALIASNAMES, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[35] = new AtrInfoTable(AttributeName.IGNOREDEVICEEXTGSTATE, 0x44444443, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[36] = new AtrInfoTable(AttributeName.BOUNDINGBOX, 0x33333333, AttributeInfo.EnumAttributeType.rectangle, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoPDFToPSConversionParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPDFToPSConversionParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPDFToPSConversionParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPDFToPSConversionParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPDFToPSConversionParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoPDFToPSConversionParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoPDFToPSConversionParams[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for IncludeBaseFonts </summary>
      ///        

      public class EnumIncludeBaseFonts : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumIncludeBaseFonts(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumIncludeBaseFonts getEnum(string enumName)
         {
            return (EnumIncludeBaseFonts)getEnum(typeof(EnumIncludeBaseFonts), enumName);
         }

         public static EnumIncludeBaseFonts getEnum(int enumValue)
         {
            return (EnumIncludeBaseFonts)getEnum(typeof(EnumIncludeBaseFonts), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumIncludeBaseFonts));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumIncludeBaseFonts));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumIncludeBaseFonts));
         }

         public static readonly EnumIncludeBaseFonts IncludeNever = new EnumIncludeBaseFonts("IncludeNever");
         public static readonly EnumIncludeBaseFonts IncludeOncePerDoc = new EnumIncludeBaseFonts("IncludeOncePerDoc");
         public static readonly EnumIncludeBaseFonts IncludeOncePerPage = new EnumIncludeBaseFonts("IncludeOncePerPage");
      }



      ///        
      ///        <summary> * Enumeration strings for IncludeCIDFonts </summary>
      ///        

      public class EnumIncludeCIDFonts : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumIncludeCIDFonts(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumIncludeCIDFonts getEnum(string enumName)
         {
            return (EnumIncludeCIDFonts)getEnum(typeof(EnumIncludeCIDFonts), enumName);
         }

         public static EnumIncludeCIDFonts getEnum(int enumValue)
         {
            return (EnumIncludeCIDFonts)getEnum(typeof(EnumIncludeCIDFonts), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumIncludeCIDFonts));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumIncludeCIDFonts));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumIncludeCIDFonts));
         }

         public static readonly EnumIncludeCIDFonts IncludeNever = new EnumIncludeCIDFonts("IncludeNever");
         public static readonly EnumIncludeCIDFonts IncludeOncePerDoc = new EnumIncludeCIDFonts("IncludeOncePerDoc");
         public static readonly EnumIncludeCIDFonts IncludeOncePerPage = new EnumIncludeCIDFonts("IncludeOncePerPage");
      }



      ///        
      ///        <summary> * Enumeration strings for IncludeEmbeddedFonts </summary>
      ///        

      public class EnumIncludeEmbeddedFonts : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumIncludeEmbeddedFonts(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumIncludeEmbeddedFonts getEnum(string enumName)
         {
            return (EnumIncludeEmbeddedFonts)getEnum(typeof(EnumIncludeEmbeddedFonts), enumName);
         }

         public static EnumIncludeEmbeddedFonts getEnum(int enumValue)
         {
            return (EnumIncludeEmbeddedFonts)getEnum(typeof(EnumIncludeEmbeddedFonts), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumIncludeEmbeddedFonts));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumIncludeEmbeddedFonts));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumIncludeEmbeddedFonts));
         }

         public static readonly EnumIncludeEmbeddedFonts IncludeNever = new EnumIncludeEmbeddedFonts("IncludeNever");
         public static readonly EnumIncludeEmbeddedFonts IncludeOncePerDoc = new EnumIncludeEmbeddedFonts("IncludeOncePerDoc");
         public static readonly EnumIncludeEmbeddedFonts IncludeOncePerPage = new EnumIncludeEmbeddedFonts("IncludeOncePerPage");
      }



      ///        
      ///        <summary> * Enumeration strings for IncludeOtherResources </summary>
      ///        

      public class EnumIncludeOtherResources : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumIncludeOtherResources(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumIncludeOtherResources getEnum(string enumName)
         {
            return (EnumIncludeOtherResources)getEnum(typeof(EnumIncludeOtherResources), enumName);
         }

         public static EnumIncludeOtherResources getEnum(int enumValue)
         {
            return (EnumIncludeOtherResources)getEnum(typeof(EnumIncludeOtherResources), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumIncludeOtherResources));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumIncludeOtherResources));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumIncludeOtherResources));
         }

         public static readonly EnumIncludeOtherResources IncludeNever = new EnumIncludeOtherResources("IncludeNever");
         public static readonly EnumIncludeOtherResources IncludeOncePerDoc = new EnumIncludeOtherResources("IncludeOncePerDoc");
         public static readonly EnumIncludeOtherResources IncludeOncePerPage = new EnumIncludeOtherResources("IncludeOncePerPage");
      }



      ///        
      ///        <summary> * Enumeration strings for IncludeProcSets </summary>
      ///        

      public class EnumIncludeProcSets : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumIncludeProcSets(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumIncludeProcSets getEnum(string enumName)
         {
            return (EnumIncludeProcSets)getEnum(typeof(EnumIncludeProcSets), enumName);
         }

         public static EnumIncludeProcSets getEnum(int enumValue)
         {
            return (EnumIncludeProcSets)getEnum(typeof(EnumIncludeProcSets), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumIncludeProcSets));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumIncludeProcSets));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumIncludeProcSets));
         }

         public static readonly EnumIncludeProcSets IncludeNever = new EnumIncludeProcSets("IncludeNever");
         public static readonly EnumIncludeProcSets IncludeOncePerDoc = new EnumIncludeProcSets("IncludeOncePerDoc");
         public static readonly EnumIncludeProcSets IncludeOncePerPage = new EnumIncludeProcSets("IncludeOncePerPage");
      }



      ///        
      ///        <summary> * Enumeration strings for IncludeTrueTypeFonts </summary>
      ///        

      public class EnumIncludeTrueTypeFonts : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumIncludeTrueTypeFonts(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumIncludeTrueTypeFonts getEnum(string enumName)
         {
            return (EnumIncludeTrueTypeFonts)getEnum(typeof(EnumIncludeTrueTypeFonts), enumName);
         }

         public static EnumIncludeTrueTypeFonts getEnum(int enumValue)
         {
            return (EnumIncludeTrueTypeFonts)getEnum(typeof(EnumIncludeTrueTypeFonts), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumIncludeTrueTypeFonts));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumIncludeTrueTypeFonts));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumIncludeTrueTypeFonts));
         }

         public static readonly EnumIncludeTrueTypeFonts IncludeNever = new EnumIncludeTrueTypeFonts("IncludeNever");
         public static readonly EnumIncludeTrueTypeFonts IncludeOncePerDoc = new EnumIncludeTrueTypeFonts("IncludeOncePerDoc");
         public static readonly EnumIncludeTrueTypeFonts IncludeOncePerPage = new EnumIncludeTrueTypeFonts("IncludeOncePerPage");
      }



      ///        
      ///        <summary> * Enumeration strings for IncludeType1Fonts </summary>
      ///        

      public class EnumIncludeType1Fonts : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumIncludeType1Fonts(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumIncludeType1Fonts getEnum(string enumName)
         {
            return (EnumIncludeType1Fonts)getEnum(typeof(EnumIncludeType1Fonts), enumName);
         }

         public static EnumIncludeType1Fonts getEnum(int enumValue)
         {
            return (EnumIncludeType1Fonts)getEnum(typeof(EnumIncludeType1Fonts), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumIncludeType1Fonts));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumIncludeType1Fonts));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumIncludeType1Fonts));
         }

         public static readonly EnumIncludeType1Fonts IncludeNever = new EnumIncludeType1Fonts("IncludeNever");
         public static readonly EnumIncludeType1Fonts IncludeOncePerDoc = new EnumIncludeType1Fonts("IncludeOncePerDoc");
         public static readonly EnumIncludeType1Fonts IncludeOncePerPage = new EnumIncludeType1Fonts("IncludeOncePerPage");
      }



      ///        
      ///        <summary> * Enumeration strings for IncludeType3Fonts </summary>
      ///        

      public class EnumIncludeType3Fonts : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumIncludeType3Fonts(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumIncludeType3Fonts getEnum(string enumName)
         {
            return (EnumIncludeType3Fonts)getEnum(typeof(EnumIncludeType3Fonts), enumName);
         }

         public static EnumIncludeType3Fonts getEnum(int enumValue)
         {
            return (EnumIncludeType3Fonts)getEnum(typeof(EnumIncludeType3Fonts), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumIncludeType3Fonts));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumIncludeType3Fonts));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumIncludeType3Fonts));
         }

         public static readonly EnumIncludeType3Fonts IncludeNever = new EnumIncludeType3Fonts("IncludeNever");
         public static readonly EnumIncludeType3Fonts IncludeOncePerDoc = new EnumIncludeType3Fonts("IncludeOncePerDoc");
         public static readonly EnumIncludeType3Fonts IncludeOncePerPage = new EnumIncludeType3Fonts("IncludeOncePerPage");
      }



      ///        
      ///        <summary> * Enumeration strings for OutputType </summary>
      ///        

      public class EnumOutputType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumOutputType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumOutputType getEnum(string enumName)
         {
            return (EnumOutputType)getEnum(typeof(EnumOutputType), enumName);
         }

         public static EnumOutputType getEnum(int enumValue)
         {
            return (EnumOutputType)getEnum(typeof(EnumOutputType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumOutputType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumOutputType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumOutputType));
         }

         public static readonly EnumOutputType PostScript = new EnumOutputType("PostScript");
         public static readonly EnumOutputType EPS = new EnumOutputType("EPS");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute BinaryOK
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BinaryOK </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBinaryOK(bool @value)
      {
         setAttribute(AttributeName.BINARYOK, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute BinaryOK </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getBinaryOK()
      {
         return getBoolAttribute(AttributeName.BINARYOK, null, true);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute CenterCropBox
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CenterCropBox </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCenterCropBox(bool @value)
      {
         setAttribute(AttributeName.CENTERCROPBOX, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute CenterCropBox </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getCenterCropBox()
      {
         return getBoolAttribute(AttributeName.CENTERCROPBOX, null, true);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute GeneratePageStreams
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute GeneratePageStreams </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setGeneratePageStreams(bool @value)
      {
         setAttribute(AttributeName.GENERATEPAGESTREAMS, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute GeneratePageStreams </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getGeneratePageStreams()
      {
         return getBoolAttribute(AttributeName.GENERATEPAGESTREAMS, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute IgnoreAnnotForms
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute IgnoreAnnotForms </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setIgnoreAnnotForms(bool @value)
      {
         setAttribute(AttributeName.IGNOREANNOTFORMS, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute IgnoreAnnotForms </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getIgnoreAnnotForms()
      {
         return getBoolAttribute(AttributeName.IGNOREANNOTFORMS, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute IgnoreBG
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute IgnoreBG </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setIgnoreBG(bool @value)
      {
         setAttribute(AttributeName.IGNOREBG, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute IgnoreBG </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getIgnoreBG()
      {
         return getBoolAttribute(AttributeName.IGNOREBG, null, true);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute IgnoreColorSeps
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute IgnoreColorSeps </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setIgnoreColorSeps(bool @value)
      {
         setAttribute(AttributeName.IGNORECOLORSEPS, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute IgnoreColorSeps </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getIgnoreColorSeps()
      {
         return getBoolAttribute(AttributeName.IGNORECOLORSEPS, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute IgnoreDSC
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute IgnoreDSC </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setIgnoreDSC(bool @value)
      {
         setAttribute(AttributeName.IGNOREDSC, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute IgnoreDSC </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getIgnoreDSC()
      {
         return getBoolAttribute(AttributeName.IGNOREDSC, null, true);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute IgnoreExternStreamRef
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute IgnoreExternStreamRef </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setIgnoreExternStreamRef(bool @value)
      {
         setAttribute(AttributeName.IGNOREEXTERNSTREAMREF, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute IgnoreExternStreamRef </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getIgnoreExternStreamRef()
      {
         return getBoolAttribute(AttributeName.IGNOREEXTERNSTREAMREF, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute IgnoreHalftones
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute IgnoreHalftones </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setIgnoreHalftones(bool @value)
      {
         setAttribute(AttributeName.IGNOREHALFTONES, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute IgnoreHalftones </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getIgnoreHalftones()
      {
         return getBoolAttribute(AttributeName.IGNOREHALFTONES, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute IgnoreOverprint
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute IgnoreOverprint </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setIgnoreOverprint(bool @value)
      {
         setAttribute(AttributeName.IGNOREOVERPRINT, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute IgnoreOverprint </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getIgnoreOverprint()
      {
         return getBoolAttribute(AttributeName.IGNOREOVERPRINT, null, true);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute IgnorePageRotation
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute IgnorePageRotation </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setIgnorePageRotation(bool @value)
      {
         setAttribute(AttributeName.IGNOREPAGEROTATION, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute IgnorePageRotation </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getIgnorePageRotation()
      {
         return getBoolAttribute(AttributeName.IGNOREPAGEROTATION, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute IgnoreRawData
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute IgnoreRawData </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setIgnoreRawData(bool @value)
      {
         setAttribute(AttributeName.IGNORERAWDATA, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute IgnoreRawData </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getIgnoreRawData()
      {
         return getBoolAttribute(AttributeName.IGNORERAWDATA, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute IgnoreSeparableImagesOnly
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute IgnoreSeparableImagesOnly </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setIgnoreSeparableImagesOnly(bool @value)
      {
         setAttribute(AttributeName.IGNORESEPARABLEIMAGESONLY, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute IgnoreSeparableImagesOnly </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getIgnoreSeparableImagesOnly()
      {
         return getBoolAttribute(AttributeName.IGNORESEPARABLEIMAGESONLY, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute IgnoreShowPage
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute IgnoreShowPage </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setIgnoreShowPage(bool @value)
      {
         setAttribute(AttributeName.IGNORESHOWPAGE, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute IgnoreShowPage </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getIgnoreShowPage()
      {
         return getBoolAttribute(AttributeName.IGNORESHOWPAGE, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute IgnoreTransfers
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute IgnoreTransfers </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setIgnoreTransfers(bool @value)
      {
         setAttribute(AttributeName.IGNORETRANSFERS, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute IgnoreTransfers </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getIgnoreTransfers()
      {
         return getBoolAttribute(AttributeName.IGNORETRANSFERS, null, true);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute IgnoreTTFontsFirst
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute IgnoreTTFontsFirst </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setIgnoreTTFontsFirst(bool @value)
      {
         setAttribute(AttributeName.IGNORETTFONTSFIRST, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute IgnoreTTFontsFirst </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getIgnoreTTFontsFirst()
      {
         return getBoolAttribute(AttributeName.IGNORETTFONTSFIRST, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute IgnoreUCR
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute IgnoreUCR </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setIgnoreUCR(bool @value)
      {
         setAttribute(AttributeName.IGNOREUCR, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute IgnoreUCR </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getIgnoreUCR()
      {
         return getBoolAttribute(AttributeName.IGNOREUCR, null, true);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute IncludeBaseFonts
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute IncludeBaseFonts </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setIncludeBaseFonts(EnumIncludeBaseFonts enumVar)
      {
         setAttribute(AttributeName.INCLUDEBASEFONTS, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute IncludeBaseFonts </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumIncludeBaseFonts getIncludeBaseFonts()
      {
         return EnumIncludeBaseFonts.getEnum(getAttribute(AttributeName.INCLUDEBASEFONTS, null, "IncludeNever"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute IncludeCIDFonts
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute IncludeCIDFonts </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setIncludeCIDFonts(EnumIncludeCIDFonts enumVar)
      {
         setAttribute(AttributeName.INCLUDECIDFONTS, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute IncludeCIDFonts </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumIncludeCIDFonts getIncludeCIDFonts()
      {
         return EnumIncludeCIDFonts.getEnum(getAttribute(AttributeName.INCLUDECIDFONTS, null, "IncludeOncePerDoc"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute IncludeEmbeddedFonts
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute IncludeEmbeddedFonts </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setIncludeEmbeddedFonts(EnumIncludeEmbeddedFonts enumVar)
      {
         setAttribute(AttributeName.INCLUDEEMBEDDEDFONTS, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute IncludeEmbeddedFonts </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumIncludeEmbeddedFonts getIncludeEmbeddedFonts()
      {
         return EnumIncludeEmbeddedFonts.getEnum(getAttribute(AttributeName.INCLUDEEMBEDDEDFONTS, null, "IncludeOncePerDoc"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute IncludeOtherResources
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute IncludeOtherResources </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setIncludeOtherResources(EnumIncludeOtherResources enumVar)
      {
         setAttribute(AttributeName.INCLUDEOTHERRESOURCES, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute IncludeOtherResources </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumIncludeOtherResources getIncludeOtherResources()
      {
         return EnumIncludeOtherResources.getEnum(getAttribute(AttributeName.INCLUDEOTHERRESOURCES, null, "IncludeOncePerDoc"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute IncludeProcSets
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute IncludeProcSets </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setIncludeProcSets(EnumIncludeProcSets enumVar)
      {
         setAttribute(AttributeName.INCLUDEPROCSETS, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute IncludeProcSets </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumIncludeProcSets getIncludeProcSets()
      {
         return EnumIncludeProcSets.getEnum(getAttribute(AttributeName.INCLUDEPROCSETS, null, "IncludeOncePerDoc"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute IncludeTrueTypeFonts
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute IncludeTrueTypeFonts </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setIncludeTrueTypeFonts(EnumIncludeTrueTypeFonts enumVar)
      {
         setAttribute(AttributeName.INCLUDETRUETYPEFONTS, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute IncludeTrueTypeFonts </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumIncludeTrueTypeFonts getIncludeTrueTypeFonts()
      {
         return EnumIncludeTrueTypeFonts.getEnum(getAttribute(AttributeName.INCLUDETRUETYPEFONTS, null, "IncludeOncePerDoc"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute IncludeType1Fonts
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute IncludeType1Fonts </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setIncludeType1Fonts(EnumIncludeType1Fonts enumVar)
      {
         setAttribute(AttributeName.INCLUDETYPE1FONTS, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute IncludeType1Fonts </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumIncludeType1Fonts getIncludeType1Fonts()
      {
         return EnumIncludeType1Fonts.getEnum(getAttribute(AttributeName.INCLUDETYPE1FONTS, null, "IncludeOncePerDoc"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute IncludeType3Fonts
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute IncludeType3Fonts </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setIncludeType3Fonts(EnumIncludeType3Fonts enumVar)
      {
         setAttribute(AttributeName.INCLUDETYPE3FONTS, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute IncludeType3Fonts </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumIncludeType3Fonts getIncludeType3Fonts()
      {
         return EnumIncludeType3Fonts.getEnum(getAttribute(AttributeName.INCLUDETYPE3FONTS, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute OutputType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute OutputType </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setOutputType(EnumOutputType enumVar)
      {
         setAttribute(AttributeName.OUTPUTTYPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute OutputType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumOutputType getOutputType()
      {
         return EnumOutputType.getEnum(getAttribute(AttributeName.OUTPUTTYPE, null, "PostScript"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PSLevel
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PSLevel </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPSLevel(int @value)
      {
         setAttribute(AttributeName.PSLEVEL, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute PSLevel </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getPSLevel()
      {
         return getIntAttribute(AttributeName.PSLEVEL, null, 2);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Scale
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Scale </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setScale(double @value)
      {
         setAttribute(AttributeName.SCALE, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute Scale </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getScale()
      {
         return getRealAttribute(AttributeName.SCALE, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SetPageSize
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SetPageSize </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSetPageSize(bool @value)
      {
         setAttribute(AttributeName.SETPAGESIZE, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute SetPageSize </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getSetPageSize()
      {
         return getBoolAttribute(AttributeName.SETPAGESIZE, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SetupProcsets
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SetupProcsets </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSetupProcsets(bool @value)
      {
         setAttribute(AttributeName.SETUPPROCSETS, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute SetupProcsets </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getSetupProcsets()
      {
         return getBoolAttribute(AttributeName.SETUPPROCSETS, null, true);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ShrinkToFit
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ShrinkToFit </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setShrinkToFit(bool @value)
      {
         setAttribute(AttributeName.SHRINKTOFIT, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute ShrinkToFit </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getShrinkToFit()
      {
         return getBoolAttribute(AttributeName.SHRINKTOFIT, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SuppressCenter
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SuppressCenter </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSuppressCenter(bool @value)
      {
         setAttribute(AttributeName.SUPPRESSCENTER, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute SuppressCenter </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getSuppressCenter()
      {
         return getBoolAttribute(AttributeName.SUPPRESSCENTER, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SuppressRotate
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SuppressRotate </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSuppressRotate(bool @value)
      {
         setAttribute(AttributeName.SUPPRESSROTATE, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute SuppressRotate </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getSuppressRotate()
      {
         return getBoolAttribute(AttributeName.SUPPRESSROTATE, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TTasT42
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TTasT42 </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTTasT42(bool @value)
      {
         setAttribute(AttributeName.TTAST42, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute TTasT42 </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getTTasT42()
      {
         return getBoolAttribute(AttributeName.TTAST42, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute UseFontAliasNames
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute UseFontAliasNames </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setUseFontAliasNames(bool @value)
      {
         setAttribute(AttributeName.USEFONTALIASNAMES, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute UseFontAliasNames </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getUseFontAliasNames()
      {
         return getBoolAttribute(AttributeName.USEFONTALIASNAMES, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute IgnoreDeviceExtGState
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute IgnoreDeviceExtGState </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setIgnoreDeviceExtGState(bool @value)
      {
         setAttribute(AttributeName.IGNOREDEVICEEXTGSTATE, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute IgnoreDeviceExtGState </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getIgnoreDeviceExtGState()
      {
         return getBoolAttribute(AttributeName.IGNOREDEVICEEXTGSTATE, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute BoundingBox
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BoundingBox </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBoundingBox(JDFRectangle @value)
      {
         setAttribute(AttributeName.BOUNDINGBOX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFRectangle attribute BoundingBox </summary>
      ///          * <returns> JDFRectangle the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFRectangle </returns>
      ///          
      public virtual JDFRectangle getBoundingBox()
      {
         string strAttrName = "";
         JDFRectangle nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.BOUNDINGBOX, null, JDFConstants.EMPTYSTRING);
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
   }
}
