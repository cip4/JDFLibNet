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
   using JDFJobSheet = org.cip4.jdflib.resource.JDFJobSheet;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFMediaIntent = org.cip4.jdflib.resource.intent.JDFMediaIntent;
   using JDFCover = org.cip4.jdflib.resource.process.JDFCover;
   using JDFIDPFinishing = org.cip4.jdflib.resource.process.JDFIDPFinishing;
   using JDFIDPLayout = org.cip4.jdflib.resource.process.JDFIDPLayout;
   using JDFMediaSource = org.cip4.jdflib.resource.process.JDFMediaSource;

   public abstract class JDFAutoIDPrintingParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[8];
      static JDFAutoIDPrintingParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ATTRIBUTESNATURALLANG, 0x44444443, AttributeInfo.EnumAttributeType.language, null, "US");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.IDPATTRIBUTEFIDELITY, 0x44444443, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.IPPJOBPRIORITY, 0x44444443, AttributeInfo.EnumAttributeType.integer, null, "50");
         atrInfoTable[3] = new AtrInfoTable(AttributeName.IPPVERSION, 0x44444443, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.OUTPUTBIN, 0x44444443, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.PAGEDELIVERY, 0x44444443, AttributeInfo.EnumAttributeType.enumeration, EnumPageDelivery.getEnum(0), null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.PRINTQUALITY, 0x44444443, AttributeInfo.EnumAttributeType.enumeration, EnumPrintQuality.getEnum(0), null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.SHEETCOLLATE, 0x44444443, AttributeInfo.EnumAttributeType.boolean_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.COVER, 0x44444443);
         elemInfoTable[1] = new ElemInfoTable(ElementName.IDPFINISHING, 0x77777776);
         elemInfoTable[2] = new ElemInfoTable(ElementName.IDPLAYOUT, 0x77777776);
         elemInfoTable[3] = new ElemInfoTable(ElementName.JOBSHEET, 0x44444443);
         elemInfoTable[4] = new ElemInfoTable(ElementName.MEDIAINTENT, 0x77777776);
         elemInfoTable[5] = new ElemInfoTable(ElementName.MEDIASOURCE, 0x77777776);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[6];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoIDPrintingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoIDPrintingParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoIDPrintingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoIDPrintingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoIDPrintingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoIDPrintingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoIDPrintingParams[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for PageDelivery </summary>
      ///        

      public class EnumPageDelivery : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumPageDelivery(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumPageDelivery getEnum(string enumName)
         {
            return (EnumPageDelivery)getEnum(typeof(EnumPageDelivery), enumName);
         }

         public static EnumPageDelivery getEnum(int enumValue)
         {
            return (EnumPageDelivery)getEnum(typeof(EnumPageDelivery), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumPageDelivery));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumPageDelivery));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumPageDelivery));
         }

         public static readonly EnumPageDelivery SameOrderFaceUp = new EnumPageDelivery("SameOrderFaceUp");
         public static readonly EnumPageDelivery SameOrderFaceDown = new EnumPageDelivery("SameOrderFaceDown");
         public static readonly EnumPageDelivery ReverseOrderFaceUp = new EnumPageDelivery("ReverseOrderFaceUp");
         public static readonly EnumPageDelivery ReverseOrderFaceDown = new EnumPageDelivery("ReverseOrderFaceDown");
         public static readonly EnumPageDelivery SystemSpecified = new EnumPageDelivery("SystemSpecified");
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
      //        Methods for Attribute AttributesNaturalLang
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute AttributesNaturalLang </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAttributesNaturalLang(string @value)
      {
         setAttribute(AttributeName.ATTRIBUTESNATURALLANG, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute AttributesNaturalLang </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getAttributesNaturalLang()
      {
         return getAttribute(AttributeName.ATTRIBUTESNATURALLANG, null, "US");
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute IDPAttributeFidelity
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute IDPAttributeFidelity </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setIDPAttributeFidelity(bool @value)
      {
         setAttribute(AttributeName.IDPATTRIBUTEFIDELITY, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute IDPAttributeFidelity </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getIDPAttributeFidelity()
      {
         return getBoolAttribute(AttributeName.IDPATTRIBUTEFIDELITY, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute IPPJobPriority
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute IPPJobPriority </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setIPPJobPriority(int @value)
      {
         setAttribute(AttributeName.IPPJOBPRIORITY, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute IPPJobPriority </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getIPPJobPriority()
      {
         return getIntAttribute(AttributeName.IPPJOBPRIORITY, null, 50);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute IPPVersion
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute IPPVersion </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setIPPVersion(JDFXYPair @value)
      {
         setAttribute(AttributeName.IPPVERSION, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute IPPVersion </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getIPPVersion()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.IPPVERSION, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute OutputBin
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute OutputBin </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setOutputBin(string @value)
      {
         setAttribute(AttributeName.OUTPUTBIN, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute OutputBin </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getOutputBin()
      {
         return getAttribute(AttributeName.OUTPUTBIN, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PageDelivery
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute PageDelivery </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setPageDelivery(EnumPageDelivery enumVar)
      {
         setAttribute(AttributeName.PAGEDELIVERY, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute PageDelivery </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumPageDelivery getPageDelivery()
      {
         return EnumPageDelivery.getEnum(getAttribute(AttributeName.PAGEDELIVERY, null, null));
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
         return EnumPrintQuality.getEnum(getAttribute(AttributeName.PRINTQUALITY, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SheetCollate
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SheetCollate </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSheetCollate(bool @value)
      {
         setAttribute(AttributeName.SHEETCOLLATE, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute SheetCollate </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getSheetCollate()
      {
         return getBoolAttribute(AttributeName.SHEETCOLLATE, null, false);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateCover
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFCover the element </returns>
      ///     
      public virtual JDFCover getCreateCover(int iSkip)
      {
         return (JDFCover)getCreateElement_KElement(ElementName.COVER, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Cover </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFCover the element </returns>
      ///     * default is getCover(0)     
      public virtual JDFCover getCover(int iSkip)
      {
         return (JDFCover)getElement(ElementName.COVER, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Cover from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFCover> </returns>
      ///     
      public virtual ICollection<JDFCover> getAllCover()
      {
         List<JDFCover> v = new List<JDFCover>();

         JDFCover kElem = (JDFCover)getFirstChildElement(ElementName.COVER, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFCover)kElem.getNextSiblingElement(ElementName.COVER, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Cover </summary>
      ///     
      public virtual JDFCover appendCover()
      {
         return (JDFCover)appendElement(ElementName.COVER, null);
      }

      ///    
      ///     <summary> * (24) const get element IDPFinishing </summary>
      ///     * <returns> JDFIDPFinishing the element </returns>
      ///     
      public virtual JDFIDPFinishing getIDPFinishing()
      {
         return (JDFIDPFinishing)getElement(ElementName.IDPFINISHING, null, 0);
      }

      ///     <summary> (25) getCreateIDPFinishing
      ///     *  </summary>
      ///     * <returns> JDFIDPFinishing the element </returns>
      ///     
      public virtual JDFIDPFinishing getCreateIDPFinishing()
      {
         return (JDFIDPFinishing)getCreateElement_KElement(ElementName.IDPFINISHING, null, 0);
      }

      ///    
      ///     <summary> * (29) append element IDPFinishing </summary>
      ///     
      public virtual JDFIDPFinishing appendIDPFinishing()
      {
         return (JDFIDPFinishing)appendElementN(ElementName.IDPFINISHING, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element IDPLayout </summary>
      ///     * <returns> JDFIDPLayout the element </returns>
      ///     
      public virtual JDFIDPLayout getIDPLayout()
      {
         return (JDFIDPLayout)getElement(ElementName.IDPLAYOUT, null, 0);
      }

      ///     <summary> (25) getCreateIDPLayout
      ///     *  </summary>
      ///     * <returns> JDFIDPLayout the element </returns>
      ///     
      public virtual JDFIDPLayout getCreateIDPLayout()
      {
         return (JDFIDPLayout)getCreateElement_KElement(ElementName.IDPLAYOUT, null, 0);
      }

      ///    
      ///     <summary> * (29) append element IDPLayout </summary>
      ///     
      public virtual JDFIDPLayout appendIDPLayout()
      {
         return (JDFIDPLayout)appendElementN(ElementName.IDPLAYOUT, 1, null);
      }

      ///     <summary> (26) getCreateJobSheet
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFJobSheet the element </returns>
      ///     
      public virtual JDFJobSheet getCreateJobSheet(int iSkip)
      {
         return (JDFJobSheet)getCreateElement_KElement(ElementName.JOBSHEET, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element JobSheet </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFJobSheet the element </returns>
      ///     * default is getJobSheet(0)     
      public virtual JDFJobSheet getJobSheet(int iSkip)
      {
         return (JDFJobSheet)getElement(ElementName.JOBSHEET, null, iSkip);
      }

      ///    
      ///     <summary> * Get all JobSheet from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFJobSheet> </returns>
      ///     
      public virtual ICollection<JDFJobSheet> getAllJobSheet()
      {
         List<JDFJobSheet> v = new List<JDFJobSheet>();

         JDFJobSheet kElem = (JDFJobSheet)getFirstChildElement(ElementName.JOBSHEET, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFJobSheet)kElem.getNextSiblingElement(ElementName.JOBSHEET, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element JobSheet </summary>
      ///     
      public virtual JDFJobSheet appendJobSheet()
      {
         return (JDFJobSheet)appendElement(ElementName.JOBSHEET, null);
      }

      ///    
      ///     <summary> * (24) const get element MediaIntent </summary>
      ///     * <returns> JDFMediaIntent the element </returns>
      ///     
      public virtual JDFMediaIntent getMediaIntent()
      {
         return (JDFMediaIntent)getElement(ElementName.MEDIAINTENT, null, 0);
      }

      ///     <summary> (25) getCreateMediaIntent
      ///     *  </summary>
      ///     * <returns> JDFMediaIntent the element </returns>
      ///     
      public virtual JDFMediaIntent getCreateMediaIntent()
      {
         return (JDFMediaIntent)getCreateElement_KElement(ElementName.MEDIAINTENT, null, 0);
      }

      ///    
      ///     <summary> * (29) append element MediaIntent </summary>
      ///     
      public virtual JDFMediaIntent appendMediaIntent()
      {
         return (JDFMediaIntent)appendElementN(ElementName.MEDIAINTENT, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refMediaIntent(JDFMediaIntent refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element MediaSource </summary>
      ///     * <returns> JDFMediaSource the element </returns>
      ///     
      public virtual JDFMediaSource getMediaSource()
      {
         return (JDFMediaSource)getElement(ElementName.MEDIASOURCE, null, 0);
      }

      ///     <summary> (25) getCreateMediaSource
      ///     *  </summary>
      ///     * <returns> JDFMediaSource the element </returns>
      ///     
      public virtual JDFMediaSource getCreateMediaSource()
      {
         return (JDFMediaSource)getCreateElement_KElement(ElementName.MEDIASOURCE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element MediaSource </summary>
      ///     
      public virtual JDFMediaSource appendMediaSource()
      {
         return (JDFMediaSource)appendElementN(ElementName.MEDIASOURCE, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refMediaSource(JDFMediaSource refTarget)
      {
         refElement(refTarget);
      }
   }
}
