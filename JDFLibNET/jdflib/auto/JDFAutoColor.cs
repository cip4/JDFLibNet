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
   using JDFCMYKColor = org.cip4.jdflib.datatypes.JDFCMYKColor;
   using JDFLabColor = org.cip4.jdflib.datatypes.JDFLabColor;
   using JDFRGBColor = org.cip4.jdflib.datatypes.JDFRGBColor;
   using JDFColorMeasurementConditions = org.cip4.jdflib.resource.JDFColorMeasurementConditions;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFDeviceNColor = org.cip4.jdflib.resource.process.JDFDeviceNColor;
   using JDFFileSpec = org.cip4.jdflib.resource.process.JDFFileSpec;
   using JDFPrintConditionColor = org.cip4.jdflib.resource.process.JDFPrintConditionColor;
   using JDFTransferCurve = org.cip4.jdflib.resource.process.JDFTransferCurve;

   public abstract class JDFAutoColor : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[17];
      static JDFAutoColor()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.MAPPINGSELECTION, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumMappingSelection.getEnum(0), "UsePDLValues");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.NAME, 0x22222222, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.ACTUALCOLORNAME, 0x33333111, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.CMYK, 0x33333333, AttributeInfo.EnumAttributeType.CMYKColor, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.COLORBOOK, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.COLORBOOKENTRY, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.COLORBOOKPREFIX, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.COLORBOOKSUFFIX, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.COLORNAME, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.COLORTYPE, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumColorType.getEnum(0), null);
         atrInfoTable[10] = new AtrInfoTable(AttributeName.DENSITY, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[11] = new AtrInfoTable(AttributeName.LAB, 0x33333333, AttributeInfo.EnumAttributeType.LabColor, null, null);
         atrInfoTable[12] = new AtrInfoTable(AttributeName.MEDIATYPE, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[13] = new AtrInfoTable(AttributeName.NEUTRALDENSITY, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[14] = new AtrInfoTable(AttributeName.RAWNAME, 0x33333311, AttributeInfo.EnumAttributeType.hexBinary, null, null);
         atrInfoTable[15] = new AtrInfoTable(AttributeName.SRGB, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[16] = new AtrInfoTable(AttributeName.USEPDLALTERNATECS, 0x44444433, AttributeInfo.EnumAttributeType.boolean_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.COLORMEASUREMENTCONDITIONS, 0x66666666);
         elemInfoTable[1] = new ElemInfoTable(ElementName.FILESPEC, 0x33333333);
         elemInfoTable[2] = new ElemInfoTable(ElementName.DEVICENCOLOR, 0x33333333);
         elemInfoTable[3] = new ElemInfoTable(ElementName.PRINTCONDITIONCOLOR, 0x33333311);
         elemInfoTable[4] = new ElemInfoTable(ElementName.TRANSFERCURVE, 0x33333333);
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
      ///     <summary> * Constructor for JDFAutoColor </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoColor(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoColor </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoColor(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoColor </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoColor(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoColor[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for MappingSelection </summary>
      ///        

      public class EnumMappingSelection : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumMappingSelection(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumMappingSelection getEnum(string enumName)
         {
            return (EnumMappingSelection)getEnum(typeof(EnumMappingSelection), enumName);
         }

         public static EnumMappingSelection getEnum(int enumValue)
         {
            return (EnumMappingSelection)getEnum(typeof(EnumMappingSelection), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumMappingSelection));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumMappingSelection));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumMappingSelection));
         }

         public static readonly EnumMappingSelection UsePDLValues = new EnumMappingSelection("UsePDLValues");
         public static readonly EnumMappingSelection UseLocalPrinterValues = new EnumMappingSelection("UseLocalPrinterValues");
         public static readonly EnumMappingSelection UseProcessColorValues = new EnumMappingSelection("UseProcessColorValues");
      }



      ///        
      ///        <summary> * Enumeration strings for ColorType </summary>
      ///        

      public class EnumColorType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumColorType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumColorType getEnum(string enumName)
         {
            return (EnumColorType)getEnum(typeof(EnumColorType), enumName);
         }

         public static EnumColorType getEnum(int enumValue)
         {
            return (EnumColorType)getEnum(typeof(EnumColorType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumColorType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumColorType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumColorType));
         }

         public static readonly EnumColorType DieLine = new EnumColorType("DieLine");
         public static readonly EnumColorType Normal = new EnumColorType("Normal");
         public static readonly EnumColorType Transparent = new EnumColorType("Transparent");
         public static readonly EnumColorType Opaque = new EnumColorType("Opaque");
         public static readonly EnumColorType OpaqueIgnore = new EnumColorType("OpaqueIgnore");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute MappingSelection
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute MappingSelection </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setMappingSelection(EnumMappingSelection enumVar)
      {
         setAttribute(AttributeName.MAPPINGSELECTION, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute MappingSelection </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumMappingSelection getMappingSelection()
      {
         return EnumMappingSelection.getEnum(getAttribute(AttributeName.MAPPINGSELECTION, null, "UsePDLValues"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Name
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Name </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setName(string @value)
      {
         setAttribute(AttributeName.NAME, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Name </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getName()
      {
         return getAttribute(AttributeName.NAME, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ActualColorName
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ActualColorName </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setActualColorName(string @value)
      {
         setAttribute(AttributeName.ACTUALCOLORNAME, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ActualColorName </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getActualColorName()
      {
         return getAttribute(AttributeName.ACTUALCOLORNAME, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute CMYK
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CMYK </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCMYK(JDFCMYKColor @value)
      {
         setAttribute(AttributeName.CMYK, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFCMYKColor attribute CMYK </summary>
      ///          * <returns> JDFCMYKColor the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFCMYKColor </returns>
      ///          
      public virtual JDFCMYKColor getCMYK()
      {
         string strAttrName = "";
         JDFCMYKColor nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.CMYK, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFCMYKColor(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ColorBook
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ColorBook </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setColorBook(string @value)
      {
         setAttribute(AttributeName.COLORBOOK, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ColorBook </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getColorBook()
      {
         return getAttribute(AttributeName.COLORBOOK, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ColorBookEntry
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ColorBookEntry </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setColorBookEntry(string @value)
      {
         setAttribute(AttributeName.COLORBOOKENTRY, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ColorBookEntry </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getColorBookEntry()
      {
         return getAttribute(AttributeName.COLORBOOKENTRY, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ColorBookPrefix
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ColorBookPrefix </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setColorBookPrefix(string @value)
      {
         setAttribute(AttributeName.COLORBOOKPREFIX, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ColorBookPrefix </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getColorBookPrefix()
      {
         return getAttribute(AttributeName.COLORBOOKPREFIX, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ColorBookSuffix
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ColorBookSuffix </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setColorBookSuffix(string @value)
      {
         setAttribute(AttributeName.COLORBOOKSUFFIX, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ColorBookSuffix </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getColorBookSuffix()
      {
         return getAttribute(AttributeName.COLORBOOKSUFFIX, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ColorName
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (13) set attribute ColorName </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setColorName(EnumNamedColor @value)
      {
         setAttribute(AttributeName.COLORNAME, @value == null ? null : @value.getName(), null);
      }

      ///        
      ///          <summary> * (19) get EnumNamedColor attribute ColorName </summary>
      ///          * <returns> EnumNamedColor the value of the attribute </returns>
      ///          
      public virtual EnumNamedColor getColorName()
      {
         string strAttrName = "";
         EnumNamedColor nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.COLORNAME, null, JDFConstants.EMPTYSTRING);
         nPlaceHolder = EnumNamedColor.getEnum(strAttrName);
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ColorType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute ColorType </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setColorType(EnumColorType enumVar)
      {
         setAttribute(AttributeName.COLORTYPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute ColorType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumColorType getColorType()
      {
         return EnumColorType.getEnum(getAttribute(AttributeName.COLORTYPE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Density
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Density </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDensity(double @value)
      {
         setAttribute(AttributeName.DENSITY, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute Density </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getDensity()
      {
         return getRealAttribute(AttributeName.DENSITY, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Lab
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Lab </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setLab(JDFLabColor @value)
      {
         setAttribute(AttributeName.LAB, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFLabColor attribute Lab </summary>
      ///          * <returns> JDFLabColor the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFLabColor </returns>
      ///          
      public virtual JDFLabColor getLab()
      {
         string strAttrName = "";
         JDFLabColor nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.LAB, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFLabColor(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MediaType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MediaType </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMediaType(string @value)
      {
         setAttribute(AttributeName.MEDIATYPE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute MediaType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getMediaType()
      {
         return getAttribute(AttributeName.MEDIATYPE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute NeutralDensity
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute NeutralDensity </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setNeutralDensity(double @value)
      {
         setAttribute(AttributeName.NEUTRALDENSITY, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute NeutralDensity </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getNeutralDensity()
      {
         return getRealAttribute(AttributeName.NEUTRALDENSITY, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute RawName
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute RawName </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setRawName(string @value)
      {
         setAttribute(AttributeName.RAWNAME, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute RawName </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getRawName()
      {
         return getAttribute(AttributeName.RAWNAME, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute sRGB
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute sRGB </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setsRGB(JDFRGBColor @value)
      {
         setAttribute(AttributeName.SRGB, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFRGBColor attribute sRGB </summary>
      ///          * <returns> JDFRGBColor the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFRGBColor </returns>
      ///          
      public virtual JDFRGBColor getsRGB()
      {
         string strAttrName = "";
         JDFRGBColor nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.SRGB, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFRGBColor(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute UsePDLAlternateCS
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute UsePDLAlternateCS </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setUsePDLAlternateCS(bool @value)
      {
         setAttribute(AttributeName.USEPDLALTERNATECS, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute UsePDLAlternateCS </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getUsePDLAlternateCS()
      {
         return getBoolAttribute(AttributeName.USEPDLALTERNATECS, null, false);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element ColorMeasurementConditions </summary>
      ///     * <returns> JDFColorMeasurementConditions the element </returns>
      ///     
      public virtual JDFColorMeasurementConditions getColorMeasurementConditions()
      {
         return (JDFColorMeasurementConditions)getElement(ElementName.COLORMEASUREMENTCONDITIONS, null, 0);
      }

      ///     <summary> (25) getCreateColorMeasurementConditions
      ///     *  </summary>
      ///     * <returns> JDFColorMeasurementConditions the element </returns>
      ///     
      public virtual JDFColorMeasurementConditions getCreateColorMeasurementConditions()
      {
         return (JDFColorMeasurementConditions)getCreateElement_KElement(ElementName.COLORMEASUREMENTCONDITIONS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ColorMeasurementConditions </summary>
      ///     
      public virtual JDFColorMeasurementConditions appendColorMeasurementConditions()
      {
         return (JDFColorMeasurementConditions)appendElementN(ElementName.COLORMEASUREMENTCONDITIONS, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refColorMeasurementConditions(JDFColorMeasurementConditions refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreateFileSpec
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFFileSpec the element </returns>
      ///     
      public virtual JDFFileSpec getCreateFileSpec(int iSkip)
      {
         return (JDFFileSpec)getCreateElement_KElement(ElementName.FILESPEC, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element FileSpec </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFFileSpec the element </returns>
      ///     * default is getFileSpec(0)     
      public virtual JDFFileSpec getFileSpec(int iSkip)
      {
         return (JDFFileSpec)getElement(ElementName.FILESPEC, null, iSkip);
      }

      ///    
      ///     <summary> * Get all FileSpec from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFFileSpec> </returns>
      ///     
      public virtual ICollection<JDFFileSpec> getAllFileSpec()
      {
         List<JDFFileSpec> v = new List<JDFFileSpec>();

         JDFFileSpec kElem = (JDFFileSpec)getFirstChildElement(ElementName.FILESPEC, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFFileSpec)kElem.getNextSiblingElement(ElementName.FILESPEC, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element FileSpec </summary>
      ///     
      public virtual JDFFileSpec appendFileSpec()
      {
         return (JDFFileSpec)appendElement(ElementName.FILESPEC, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refFileSpec(JDFFileSpec refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreateDeviceNColor
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFDeviceNColor the element </returns>
      ///     
      public virtual JDFDeviceNColor getCreateDeviceNColor(int iSkip)
      {
         return (JDFDeviceNColor)getCreateElement_KElement(ElementName.DEVICENCOLOR, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element DeviceNColor </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFDeviceNColor the element </returns>
      ///     * default is getDeviceNColor(0)     
      public virtual JDFDeviceNColor getDeviceNColor(int iSkip)
      {
         return (JDFDeviceNColor)getElement(ElementName.DEVICENCOLOR, null, iSkip);
      }

      ///    
      ///     <summary> * Get all DeviceNColor from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFDeviceNColor> </returns>
      ///     
      public virtual ICollection<JDFDeviceNColor> getAllDeviceNColor()
      {
         List<JDFDeviceNColor> v = new List<JDFDeviceNColor>();

         JDFDeviceNColor kElem = (JDFDeviceNColor)getFirstChildElement(ElementName.DEVICENCOLOR, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFDeviceNColor)kElem.getNextSiblingElement(ElementName.DEVICENCOLOR, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element DeviceNColor </summary>
      ///     
      public virtual JDFDeviceNColor appendDeviceNColor()
      {
         return (JDFDeviceNColor)appendElement(ElementName.DEVICENCOLOR, null);
      }

      ///     <summary> (26) getCreatePrintConditionColor
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFPrintConditionColor the element </returns>
      ///     
      public virtual JDFPrintConditionColor getCreatePrintConditionColor(int iSkip)
      {
         return (JDFPrintConditionColor)getCreateElement_KElement(ElementName.PRINTCONDITIONCOLOR, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element PrintConditionColor </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFPrintConditionColor the element </returns>
      ///     * default is getPrintConditionColor(0)     
      public virtual JDFPrintConditionColor getPrintConditionColor(int iSkip)
      {
         return (JDFPrintConditionColor)getElement(ElementName.PRINTCONDITIONCOLOR, null, iSkip);
      }

      ///    
      ///     <summary> * Get all PrintConditionColor from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFPrintConditionColor> </returns>
      ///     
      public virtual ICollection<JDFPrintConditionColor> getAllPrintConditionColor()
      {
         List<JDFPrintConditionColor> v = new List<JDFPrintConditionColor>();

         JDFPrintConditionColor kElem = (JDFPrintConditionColor)getFirstChildElement(ElementName.PRINTCONDITIONCOLOR, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFPrintConditionColor)kElem.getNextSiblingElement(ElementName.PRINTCONDITIONCOLOR, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element PrintConditionColor </summary>
      ///     
      public virtual JDFPrintConditionColor appendPrintConditionColor()
      {
         return (JDFPrintConditionColor)appendElement(ElementName.PRINTCONDITIONCOLOR, null);
      }

      ///     <summary> (26) getCreateTransferCurve
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFTransferCurve the element </returns>
      ///     
      public virtual JDFTransferCurve getCreateTransferCurve(int iSkip)
      {
         return (JDFTransferCurve)getCreateElement_KElement(ElementName.TRANSFERCURVE, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element TransferCurve </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFTransferCurve the element </returns>
      ///     * default is getTransferCurve(0)     
      public virtual JDFTransferCurve getTransferCurve(int iSkip)
      {
         return (JDFTransferCurve)getElement(ElementName.TRANSFERCURVE, null, iSkip);
      }

      ///    
      ///     <summary> * Get all TransferCurve from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFTransferCurve> </returns>
      ///     
      public virtual ICollection<JDFTransferCurve> getAllTransferCurve()
      {
         List<JDFTransferCurve> v = new List<JDFTransferCurve>();

         JDFTransferCurve kElem = (JDFTransferCurve)getFirstChildElement(ElementName.TRANSFERCURVE, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFTransferCurve)kElem.getNextSiblingElement(ElementName.TRANSFERCURVE, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element TransferCurve </summary>
      ///     
      public virtual JDFTransferCurve appendTransferCurve()
      {
         return (JDFTransferCurve)appendElement(ElementName.TRANSFERCURVE, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refTransferCurve(JDFTransferCurve refTarget)
      {
         refElement(refTarget);
      }
   }
}
