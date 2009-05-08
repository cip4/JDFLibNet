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
   using JDFOCGControl = org.cip4.jdflib.resource.process.JDFOCGControl;

   public abstract class JDFAutoPDFInterpretingParams : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[13];
      static JDFAutoPDFInterpretingParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.EMITPDFBG, 0x33333331, AttributeInfo.EnumAttributeType.boolean_, null, "true");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.EMITPDFHALFTONES, 0x33333331, AttributeInfo.EnumAttributeType.boolean_, null, "true");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.EMITPDFTRANSFERS, 0x33333331, AttributeInfo.EnumAttributeType.boolean_, null, "true");
         atrInfoTable[3] = new AtrInfoTable(AttributeName.EMITPDFUCR, 0x33333331, AttributeInfo.EnumAttributeType.boolean_, null, "true");
         atrInfoTable[4] = new AtrInfoTable(AttributeName.HONORPDFOVERPRINT, 0x33333331, AttributeInfo.EnumAttributeType.boolean_, null, "true");
         atrInfoTable[5] = new AtrInfoTable(AttributeName.ICCCOLORASDEVICECOLOR, 0x33333331, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[6] = new AtrInfoTable(AttributeName.OCGDEFAULT, 0x33333111, AttributeInfo.EnumAttributeType.enumeration, EnumOCGDefault.getEnum(0), "FromPDF");
         atrInfoTable[7] = new AtrInfoTable(AttributeName.OCGINTENT, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.OCGPROCESS, 0x33333111, AttributeInfo.EnumAttributeType.enumeration, EnumOCGProcess.getEnum(0), null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.OCGZOOM, 0x33333111, AttributeInfo.EnumAttributeType.double_, null, "1.0");
         atrInfoTable[10] = new AtrInfoTable(AttributeName.PRINTPDFANNOTATIONS, 0x33333331, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[11] = new AtrInfoTable(AttributeName.PRINTTRAPANNOTATIONS, 0x33333111, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[12] = new AtrInfoTable(AttributeName.TRANSPARENCYRENDERINGQUALITY, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.OCGCONTROL, 0x33333111);
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
      ///     <summary> * Constructor for JDFAutoPDFInterpretingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPDFInterpretingParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPDFInterpretingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPDFInterpretingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPDFInterpretingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoPDFInterpretingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoPDFInterpretingParams[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for OCGDefault </summary>
      ///        

      public class EnumOCGDefault : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumOCGDefault(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumOCGDefault getEnum(string enumName)
         {
            return (EnumOCGDefault)getEnum(typeof(EnumOCGDefault), enumName);
         }

         public static EnumOCGDefault getEnum(int enumValue)
         {
            return (EnumOCGDefault)getEnum(typeof(EnumOCGDefault), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumOCGDefault));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumOCGDefault));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumOCGDefault));
         }

         public static readonly EnumOCGDefault Exclude = new EnumOCGDefault("Exclude");
         public static readonly EnumOCGDefault FromPDF = new EnumOCGDefault("FromPDF");
         public static readonly EnumOCGDefault Include = new EnumOCGDefault("Include");
      }



      ///        
      ///        <summary> * Enumeration strings for OCGProcess </summary>
      ///        

      public class EnumOCGProcess : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumOCGProcess(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumOCGProcess getEnum(string enumName)
         {
            return (EnumOCGProcess)getEnum(typeof(EnumOCGProcess), enumName);
         }

         public static EnumOCGProcess getEnum(int enumValue)
         {
            return (EnumOCGProcess)getEnum(typeof(EnumOCGProcess), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumOCGProcess));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumOCGProcess));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumOCGProcess));
         }

         public static readonly EnumOCGProcess Export = new EnumOCGProcess("Export");
         public static readonly EnumOCGProcess Print = new EnumOCGProcess("Print");
         public static readonly EnumOCGProcess View = new EnumOCGProcess("View");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute EmitPDFBG
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute EmitPDFBG </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setEmitPDFBG(bool @value)
      {
         setAttribute(AttributeName.EMITPDFBG, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute EmitPDFBG </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getEmitPDFBG()
      {
         return getBoolAttribute(AttributeName.EMITPDFBG, null, true);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute EmitPDFHalftones
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute EmitPDFHalftones </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setEmitPDFHalftones(bool @value)
      {
         setAttribute(AttributeName.EMITPDFHALFTONES, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute EmitPDFHalftones </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getEmitPDFHalftones()
      {
         return getBoolAttribute(AttributeName.EMITPDFHALFTONES, null, true);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute EmitPDFTransfers
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute EmitPDFTransfers </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setEmitPDFTransfers(bool @value)
      {
         setAttribute(AttributeName.EMITPDFTRANSFERS, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute EmitPDFTransfers </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getEmitPDFTransfers()
      {
         return getBoolAttribute(AttributeName.EMITPDFTRANSFERS, null, true);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute EmitPDFUCR
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute EmitPDFUCR </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setEmitPDFUCR(bool @value)
      {
         setAttribute(AttributeName.EMITPDFUCR, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute EmitPDFUCR </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getEmitPDFUCR()
      {
         return getBoolAttribute(AttributeName.EMITPDFUCR, null, true);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute HonorPDFOverprint
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute HonorPDFOverprint </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setHonorPDFOverprint(bool @value)
      {
         setAttribute(AttributeName.HONORPDFOVERPRINT, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute HonorPDFOverprint </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getHonorPDFOverprint()
      {
         return getBoolAttribute(AttributeName.HONORPDFOVERPRINT, null, true);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ICCColorAsDeviceColor
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ICCColorAsDeviceColor </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setICCColorAsDeviceColor(bool @value)
      {
         setAttribute(AttributeName.ICCCOLORASDEVICECOLOR, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute ICCColorAsDeviceColor </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getICCColorAsDeviceColor()
      {
         return getBoolAttribute(AttributeName.ICCCOLORASDEVICECOLOR, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute OCGDefault
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute OCGDefault </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setOCGDefault(EnumOCGDefault enumVar)
      {
         setAttribute(AttributeName.OCGDEFAULT, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute OCGDefault </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumOCGDefault getOCGDefault()
      {
         return EnumOCGDefault.getEnum(getAttribute(AttributeName.OCGDEFAULT, null, "FromPDF"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute OCGIntent
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute OCGIntent </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setOCGIntent(string @value)
      {
         setAttribute(AttributeName.OCGINTENT, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute OCGIntent </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getOCGIntent()
      {
         return getAttribute(AttributeName.OCGINTENT, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute OCGProcess
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute OCGProcess </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setOCGProcess(EnumOCGProcess enumVar)
      {
         setAttribute(AttributeName.OCGPROCESS, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute OCGProcess </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumOCGProcess getOCGProcess()
      {
         return EnumOCGProcess.getEnum(getAttribute(AttributeName.OCGPROCESS, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute OCGZoom
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute OCGZoom </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setOCGZoom(double @value)
      {
         setAttribute(AttributeName.OCGZOOM, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute OCGZoom </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getOCGZoom()
      {
         return getRealAttribute(AttributeName.OCGZOOM, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PrintPDFAnnotations
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PrintPDFAnnotations </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPrintPDFAnnotations(bool @value)
      {
         setAttribute(AttributeName.PRINTPDFANNOTATIONS, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute PrintPDFAnnotations </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getPrintPDFAnnotations()
      {
         return getBoolAttribute(AttributeName.PRINTPDFANNOTATIONS, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PrintTrapAnnotations
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PrintTrapAnnotations </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPrintTrapAnnotations(bool @value)
      {
         setAttribute(AttributeName.PRINTTRAPANNOTATIONS, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute PrintTrapAnnotations </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getPrintTrapAnnotations()
      {
         return getBoolAttribute(AttributeName.PRINTTRAPANNOTATIONS, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TransparencyRenderingQuality
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TransparencyRenderingQuality </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTransparencyRenderingQuality(double @value)
      {
         setAttribute(AttributeName.TRANSPARENCYRENDERINGQUALITY, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute TransparencyRenderingQuality </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getTransparencyRenderingQuality()
      {
         return getRealAttribute(AttributeName.TRANSPARENCYRENDERINGQUALITY, null, 0.0);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateOCGControl
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFOCGControl the element </returns>
      ///     
      public virtual JDFOCGControl getCreateOCGControl(int iSkip)
      {
         return (JDFOCGControl)getCreateElement_KElement(ElementName.OCGCONTROL, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element OCGControl </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFOCGControl the element </returns>
      ///     * default is getOCGControl(0)     
      public virtual JDFOCGControl getOCGControl(int iSkip)
      {
         return (JDFOCGControl)getElement(ElementName.OCGCONTROL, null, iSkip);
      }

      ///    
      ///     <summary> * Get all OCGControl from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFOCGControl> </returns>
      ///     
      public virtual ICollection<JDFOCGControl> getAllOCGControl()
      {
         List<JDFOCGControl> v = new List<JDFOCGControl>();

         JDFOCGControl kElem = (JDFOCGControl)getFirstChildElement(ElementName.OCGCONTROL, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFOCGControl)kElem.getNextSiblingElement(ElementName.OCGCONTROL, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element OCGControl </summary>
      ///     
      public virtual JDFOCGControl appendOCGControl()
      {
         return (JDFOCGControl)appendElement(ElementName.OCGCONTROL, null);
      }
   }
}
