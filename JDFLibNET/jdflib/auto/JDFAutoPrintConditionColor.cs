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
   using JDFCMYKColor = org.cip4.jdflib.datatypes.JDFCMYKColor;
   using JDFLabColor = org.cip4.jdflib.datatypes.JDFLabColor;
   using JDFRGBColor = org.cip4.jdflib.datatypes.JDFRGBColor;
   using JDFDeviceNColor = org.cip4.jdflib.resource.process.JDFDeviceNColor;
   using JDFFileSpec = org.cip4.jdflib.resource.process.JDFFileSpec;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;
   using JDFTransferCurve = org.cip4.jdflib.resource.process.JDFTransferCurve;

   public abstract class JDFAutoPrintConditionColor : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[12];
      static JDFAutoPrintConditionColor()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.CMYK, 0x33333311, AttributeInfo.EnumAttributeType.CMYKColor, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.COLORBOOK, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.COLORBOOKENTRY, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.COLORBOOKPREFIX, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.COLORBOOKSUFFIX, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.DENSITY, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.LAB, 0x33333311, AttributeInfo.EnumAttributeType.LabColor, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.MAPPINGSELECTION, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumMappingSelection.getEnum(0), null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.MEDIASIDE, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumMediaSide.getEnum(0), "Both");
         atrInfoTable[9] = new AtrInfoTable(AttributeName.NEUTRALDENSITY, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[10] = new AtrInfoTable(AttributeName.PRINTCONDITIONNAME, 0x33333311, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[11] = new AtrInfoTable(AttributeName.SRGB, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.FILESPEC, 0x33333311);
         elemInfoTable[1] = new ElemInfoTable(ElementName.DEVICENCOLOR, 0x33333311);
         elemInfoTable[2] = new ElemInfoTable(ElementName.MEDIA, 0x33333311);
         elemInfoTable[3] = new ElemInfoTable(ElementName.TRANSFERCURVE, 0x33333311);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[4];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoPrintConditionColor </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPrintConditionColor(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPrintConditionColor </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPrintConditionColor(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPrintConditionColor </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoPrintConditionColor(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoPrintConditionColor[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for MediaSide </summary>
      ///        

      public class EnumMediaSide : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumMediaSide(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumMediaSide getEnum(string enumName)
         {
            return (EnumMediaSide)getEnum(typeof(EnumMediaSide), enumName);
         }

         public static EnumMediaSide getEnum(int enumValue)
         {
            return (EnumMediaSide)getEnum(typeof(EnumMediaSide), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumMediaSide));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumMediaSide));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumMediaSide));
         }

         public static readonly EnumMediaSide Front = new EnumMediaSide("Front");
         public static readonly EnumMediaSide Back = new EnumMediaSide("Back");
         public static readonly EnumMediaSide Both = new EnumMediaSide("Both");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

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
         return EnumMappingSelection.getEnum(getAttribute(AttributeName.MAPPINGSELECTION, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MediaSide
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute MediaSide </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setMediaSide(EnumMediaSide enumVar)
      {
         setAttribute(AttributeName.MEDIASIDE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute MediaSide </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumMediaSide getMediaSide()
      {
         return EnumMediaSide.getEnum(getAttribute(AttributeName.MEDIASIDE, null, "Both"));
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
      //        Methods for Attribute PrintConditionName
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PrintConditionName </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPrintConditionName(string @value)
      {
         setAttribute(AttributeName.PRINTCONDITIONNAME, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute PrintConditionName </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getPrintConditionName()
      {
         return getAttribute(AttributeName.PRINTCONDITIONNAME, null, JDFConstants.EMPTYSTRING);
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

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

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

      ///     <summary> (26) getCreateMedia
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFMedia the element </returns>
      ///     
      public virtual JDFMedia getCreateMedia(int iSkip)
      {
         return (JDFMedia)getCreateElement_KElement(ElementName.MEDIA, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Media </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFMedia the element </returns>
      ///     * default is getMedia(0)     
      public virtual JDFMedia getMedia(int iSkip)
      {
         return (JDFMedia)getElement(ElementName.MEDIA, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Media from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFMedia> </returns>
      ///     
      public virtual ICollection<JDFMedia> getAllMedia()
      {
         List<JDFMedia> v = new List<JDFMedia>();

         JDFMedia kElem = (JDFMedia)getFirstChildElement(ElementName.MEDIA, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFMedia)kElem.getNextSiblingElement(ElementName.MEDIA, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Media </summary>
      ///     
      public virtual JDFMedia appendMedia()
      {
         return (JDFMedia)appendElement(ElementName.MEDIA, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refMedia(JDFMedia refTarget)
      {
         refElement(refTarget);
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
