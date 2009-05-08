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
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFFitPolicy = org.cip4.jdflib.resource.JDFFitPolicy;
   using JDFPDFInterpretingParams = org.cip4.jdflib.resource.JDFPDFInterpretingParams;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;
   using JDFObjectResolution = org.cip4.jdflib.resource.process.JDFObjectResolution;

   public abstract class JDFAutoInterpretingParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[9];
      static JDFAutoInterpretingParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.CENTER, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.MIRRORAROUND, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumMirrorAround.getEnum(0), "None");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.POLARITY, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumPolarity.getEnum(0), "Positive");
         atrInfoTable[3] = new AtrInfoTable(AttributeName.PRINTQUALITY, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumPrintQuality.getEnum(0), "Normal");
         atrInfoTable[4] = new AtrInfoTable(AttributeName.FITTOPAGE, 0x44444443, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.POSTER, 0x33333333, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.POSTEROVERLAP, 0x33333333, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.SCALING, 0x33333333, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.SCALINGORIGIN, 0x33333333, AttributeInfo.EnumAttributeType.XYPair, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.OBJECTRESOLUTION, 0x33333333);
         elemInfoTable[1] = new ElemInfoTable(ElementName.FITPOLICY, 0x66666661);
         elemInfoTable[2] = new ElemInfoTable(ElementName.MEDIA, 0x33333331);
         elemInfoTable[3] = new ElemInfoTable(ElementName.PDFINTERPRETINGPARAMS, 0x66666661);
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
      ///     <summary> * Constructor for JDFAutoInterpretingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoInterpretingParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoInterpretingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoInterpretingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoInterpretingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoInterpretingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoInterpretingParams[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for MirrorAround </summary>
      ///        

      public class EnumMirrorAround : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumMirrorAround(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumMirrorAround getEnum(string enumName)
         {
            return (EnumMirrorAround)getEnum(typeof(EnumMirrorAround), enumName);
         }

         public static EnumMirrorAround getEnum(int enumValue)
         {
            return (EnumMirrorAround)getEnum(typeof(EnumMirrorAround), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumMirrorAround));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumMirrorAround));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumMirrorAround));
         }

         public static readonly EnumMirrorAround None = new EnumMirrorAround("None");
         public static readonly EnumMirrorAround FeedDirection = new EnumMirrorAround("FeedDirection");
         public static readonly EnumMirrorAround MediaWidth = new EnumMirrorAround("MediaWidth");
         public static readonly EnumMirrorAround Both = new EnumMirrorAround("Both");
      }



      ///        
      ///        <summary> * Enumeration strings for Polarity </summary>
      ///        

      public class EnumPolarity : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumPolarity(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumPolarity getEnum(string enumName)
         {
            return (EnumPolarity)getEnum(typeof(EnumPolarity), enumName);
         }

         public static EnumPolarity getEnum(int enumValue)
         {
            return (EnumPolarity)getEnum(typeof(EnumPolarity), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumPolarity));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumPolarity));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumPolarity));
         }

         public static readonly EnumPolarity Positive = new EnumPolarity("Positive");
         public static readonly EnumPolarity Negative = new EnumPolarity("Negative");
      }



      ///        
      ///        <summary> * Enumeration strings for PrintQuality </summary>
      ///        

      public class EnumPrintQuality : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumPrintQuality(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumPrintQuality getEnum(string enumName)
         {
            return (EnumPrintQuality)getEnum(typeof(EnumPrintQuality), enumName);
         }

         public static EnumPrintQuality getEnum(int enumValue)
         {
            return (EnumPrintQuality)getEnum(typeof(EnumPrintQuality), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumPrintQuality));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumPrintQuality));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumPrintQuality));
         }

         public static readonly EnumPrintQuality High = new EnumPrintQuality("High");
         public static readonly EnumPrintQuality Normal = new EnumPrintQuality("Normal");
         public static readonly EnumPrintQuality Draft = new EnumPrintQuality("Draft");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute Center
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Center </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCenter(bool @value)
      {
         setAttribute(AttributeName.CENTER, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute Center </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getCenter()
      {
         return getBoolAttribute(AttributeName.CENTER, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MirrorAround
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute MirrorAround </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setMirrorAround(EnumMirrorAround enumVar)
      {
         setAttribute(AttributeName.MIRRORAROUND, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute MirrorAround </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumMirrorAround getMirrorAround()
      {
         return EnumMirrorAround.getEnum(getAttribute(AttributeName.MIRRORAROUND, null, "None"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Polarity
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Polarity </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setPolarity(EnumPolarity enumVar)
      {
         setAttribute(AttributeName.POLARITY, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Polarity </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumPolarity getPolarity()
      {
         return EnumPolarity.getEnum(getAttribute(AttributeName.POLARITY, null, "Positive"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PrintQuality
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute PrintQuality </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setPrintQuality(EnumPrintQuality enumVar)
      {
         setAttribute(AttributeName.PRINTQUALITY, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute PrintQuality </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumPrintQuality getPrintQuality()
      {
         return EnumPrintQuality.getEnum(getAttribute(AttributeName.PRINTQUALITY, null, "Normal"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute FitToPage
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute FitToPage </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFitToPage(bool @value)
      {
         setAttribute(AttributeName.FITTOPAGE, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute FitToPage </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getFitToPage()
      {
         return getBoolAttribute(AttributeName.FITTOPAGE, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Poster
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Poster </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPoster(JDFXYPair @value)
      {
         setAttribute(AttributeName.POSTER, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute Poster </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getPoster()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.POSTER, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute PosterOverlap
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PosterOverlap </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPosterOverlap(JDFXYPair @value)
      {
         setAttribute(AttributeName.POSTEROVERLAP, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute PosterOverlap </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getPosterOverlap()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.POSTEROVERLAP, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute Scaling
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Scaling </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setScaling(JDFXYPair @value)
      {
         setAttribute(AttributeName.SCALING, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute Scaling </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getScaling()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.SCALING, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute ScalingOrigin
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ScalingOrigin </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setScalingOrigin(JDFXYPair @value)
      {
         setAttribute(AttributeName.SCALINGORIGIN, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute ScalingOrigin </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getScalingOrigin()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.SCALINGORIGIN, null, JDFConstants.EMPTYSTRING);
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

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateObjectResolution
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFObjectResolution the element </returns>
      ///     
      public virtual JDFObjectResolution getCreateObjectResolution(int iSkip)
      {
         return (JDFObjectResolution)getCreateElement_KElement(ElementName.OBJECTRESOLUTION, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element ObjectResolution </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFObjectResolution the element </returns>
      ///     * default is getObjectResolution(0)     
      public virtual JDFObjectResolution getObjectResolution(int iSkip)
      {
         return (JDFObjectResolution)getElement(ElementName.OBJECTRESOLUTION, null, iSkip);
      }

      ///    
      ///     <summary> * Get all ObjectResolution from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFObjectResolution> </returns>
      ///     
      public virtual ICollection<JDFObjectResolution> getAllObjectResolution()
      {
         List<JDFObjectResolution> v = new List<JDFObjectResolution>();

         JDFObjectResolution kElem = (JDFObjectResolution)getFirstChildElement(ElementName.OBJECTRESOLUTION, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFObjectResolution)kElem.getNextSiblingElement(ElementName.OBJECTRESOLUTION, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element ObjectResolution </summary>
      ///     
      public virtual JDFObjectResolution appendObjectResolution()
      {
         return (JDFObjectResolution)appendElement(ElementName.OBJECTRESOLUTION, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refObjectResolution(JDFObjectResolution refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element FitPolicy </summary>
      ///     * <returns> JDFFitPolicy the element </returns>
      ///     
      public virtual JDFFitPolicy getFitPolicy()
      {
         return (JDFFitPolicy)getElement(ElementName.FITPOLICY, null, 0);
      }

      ///     <summary> (25) getCreateFitPolicy
      ///     *  </summary>
      ///     * <returns> JDFFitPolicy the element </returns>
      ///     
      public virtual JDFFitPolicy getCreateFitPolicy()
      {
         return (JDFFitPolicy)getCreateElement_KElement(ElementName.FITPOLICY, null, 0);
      }

      ///    
      ///     <summary> * (29) append element FitPolicy </summary>
      ///     
      public virtual JDFFitPolicy appendFitPolicy()
      {
         return (JDFFitPolicy)appendElementN(ElementName.FITPOLICY, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refFitPolicy(JDFFitPolicy refTarget)
      {
         refElement(refTarget);
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

      ///    
      ///     <summary> * (24) const get element PDFInterpretingParams </summary>
      ///     * <returns> JDFPDFInterpretingParams the element </returns>
      ///     
      public virtual JDFPDFInterpretingParams getPDFInterpretingParams()
      {
         return (JDFPDFInterpretingParams)getElement(ElementName.PDFINTERPRETINGPARAMS, null, 0);
      }

      ///     <summary> (25) getCreatePDFInterpretingParams
      ///     *  </summary>
      ///     * <returns> JDFPDFInterpretingParams the element </returns>
      ///     
      public virtual JDFPDFInterpretingParams getCreatePDFInterpretingParams()
      {
         return (JDFPDFInterpretingParams)getCreateElement_KElement(ElementName.PDFINTERPRETINGPARAMS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element PDFInterpretingParams </summary>
      ///     
      public virtual JDFPDFInterpretingParams appendPDFInterpretingParams()
      {
         return (JDFPDFInterpretingParams)appendElementN(ElementName.PDFINTERPRETINGPARAMS, 1, null);
      }
   }
}
