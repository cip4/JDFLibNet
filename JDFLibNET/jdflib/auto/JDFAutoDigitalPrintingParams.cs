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


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFApprovalParams = org.cip4.jdflib.resource.process.JDFApprovalParams;
   using JDFComponent = org.cip4.jdflib.resource.process.JDFComponent;
   using JDFDisjointing = org.cip4.jdflib.resource.process.JDFDisjointing;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;
   using JDFMediaSource = org.cip4.jdflib.resource.process.JDFMediaSource;
   using JDFInk = org.cip4.jdflib.resource.process.prepress.JDFInk;

   public abstract class JDFAutoDigitalPrintingParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[13];
      static JDFAutoDigitalPrintingParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.DIRECTPROOFAMOUNT, 0x33333311, AttributeInfo.EnumAttributeType.integer, null, "0");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.MANUALFEED, 0x33333331, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.COLLATE, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumCollate.getEnum(0), null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.OUTPUTBIN, 0x33333331, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.PRINTQUALITY, 0x44444443, AttributeInfo.EnumAttributeType.enumeration, EnumPrintQuality.getEnum(0), null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.NONPRINTABLEMARGINBOTTOM, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.NONPRINTABLEMARGINLEFT, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.NONPRINTABLEMARGINRIGHT, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.NONPRINTABLEMARGINTOP, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.PAGEDELIVERY, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumPageDelivery.getEnum(0), null);
         atrInfoTable[10] = new AtrInfoTable(AttributeName.PRINTINGTYPE, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumPrintingType.getEnum(0), null);
         atrInfoTable[11] = new AtrInfoTable(AttributeName.SHEETLAY, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumSheetLay.getEnum(0), null);
         atrInfoTable[12] = new AtrInfoTable(AttributeName.SIDES, 0x33333111, AttributeInfo.EnumAttributeType.enumeration, EnumSides.getEnum(0), null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.COMPONENT, 0x66666661);
         elemInfoTable[1] = new ElemInfoTable(ElementName.APPROVALPARAMS, 0x66666611);
         elemInfoTable[2] = new ElemInfoTable(ElementName.DISJOINTING, 0x66666661);
         elemInfoTable[3] = new ElemInfoTable(ElementName.INK, 0x66666111);
         elemInfoTable[4] = new ElemInfoTable(ElementName.MEDIA, 0x66666661);
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
      ///     <summary> * Constructor for JDFAutoDigitalPrintingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoDigitalPrintingParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoDigitalPrintingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoDigitalPrintingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoDigitalPrintingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoDigitalPrintingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoDigitalPrintingParams[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for Collate </summary>
      ///        

      public class EnumCollate : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumCollate(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumCollate getEnum(string enumName)
         {
            return (EnumCollate)getEnum(typeof(EnumCollate), enumName);
         }

         public static EnumCollate getEnum(int enumValue)
         {
            return (EnumCollate)getEnum(typeof(EnumCollate), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumCollate));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumCollate));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumCollate));
         }

         public static readonly EnumCollate None = new EnumCollate("None");
         public static readonly EnumCollate Sheet = new EnumCollate("Sheet");
         public static readonly EnumCollate SheetAndSet = new EnumCollate("SheetAndSet");
         public static readonly EnumCollate SheetSetAndJob = new EnumCollate("SheetSetAndJob");
         public static readonly EnumCollate SystemSpecified = new EnumCollate("SystemSpecified");
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
         public static readonly EnumPrintQuality SystemSpecified = new EnumPrintQuality("SystemSpecified");
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

         public static readonly EnumPageDelivery FanFold = new EnumPageDelivery("FanFold");
         public static readonly EnumPageDelivery SameOrderFaceUp = new EnumPageDelivery("SameOrderFaceUp");
         public static readonly EnumPageDelivery SameOrderFaceDown = new EnumPageDelivery("SameOrderFaceDown");
         public static readonly EnumPageDelivery ReverseOrderFaceUp = new EnumPageDelivery("ReverseOrderFaceUp");
         public static readonly EnumPageDelivery ReverseOrderFaceDown = new EnumPageDelivery("ReverseOrderFaceDown");
         public static readonly EnumPageDelivery SystemSpecified = new EnumPageDelivery("SystemSpecified");
      }



      ///        
      ///        <summary> * Enumeration strings for PrintingType </summary>
      ///        

      public class EnumPrintingType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumPrintingType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumPrintingType getEnum(string enumName)
         {
            return (EnumPrintingType)getEnum(typeof(EnumPrintingType), enumName);
         }

         public static EnumPrintingType getEnum(int enumValue)
         {
            return (EnumPrintingType)getEnum(typeof(EnumPrintingType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumPrintingType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumPrintingType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumPrintingType));
         }

         public static readonly EnumPrintingType SheetFed = new EnumPrintingType("SheetFed");
         public static readonly EnumPrintingType WebFed = new EnumPrintingType("WebFed");
         public static readonly EnumPrintingType ContinuousFed = new EnumPrintingType("ContinuousFed");
         public static readonly EnumPrintingType SystemSpecified = new EnumPrintingType("SystemSpecified");
      }



      ///        
      ///        <summary> * Enumeration strings for SheetLay </summary>
      ///        

      public class EnumSheetLay : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumSheetLay(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumSheetLay getEnum(string enumName)
         {
            return (EnumSheetLay)getEnum(typeof(EnumSheetLay), enumName);
         }

         public static EnumSheetLay getEnum(int enumValue)
         {
            return (EnumSheetLay)getEnum(typeof(EnumSheetLay), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumSheetLay));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumSheetLay));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumSheetLay));
         }

         public static readonly EnumSheetLay Left = new EnumSheetLay("Left");
         public static readonly EnumSheetLay Right = new EnumSheetLay("Right");
         public static readonly EnumSheetLay Center = new EnumSheetLay("Center");
         public static readonly EnumSheetLay SystemSpecified = new EnumSheetLay("SystemSpecified");
      }



      ///        
      ///        <summary> * Enumeration strings for Sides </summary>
      ///        

      public class EnumSides : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumSides(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumSides getEnum(string enumName)
         {
            return (EnumSides)getEnum(typeof(EnumSides), enumName);
         }

         public static EnumSides getEnum(int enumValue)
         {
            return (EnumSides)getEnum(typeof(EnumSides), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumSides));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumSides));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumSides));
         }

         public static readonly EnumSides OneSidedBackFlipX = new EnumSides("OneSidedBackFlipX");
         public static readonly EnumSides OneSidedBackFlipY = new EnumSides("OneSidedBackFlipY");
         public static readonly EnumSides OneSidedFront = new EnumSides("OneSidedFront");
         public static readonly EnumSides TwoSidedFlipX = new EnumSides("TwoSidedFlipX");
         public static readonly EnumSides TwoSidedFlipY = new EnumSides("TwoSidedFlipY");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute DirectProofAmount
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DirectProofAmount </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDirectProofAmount(int @value)
      {
         setAttribute(AttributeName.DIRECTPROOFAMOUNT, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute DirectProofAmount </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getDirectProofAmount()
      {
         return getIntAttribute(AttributeName.DIRECTPROOFAMOUNT, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ManualFeed
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ManualFeed </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setManualFeed(bool @value)
      {
         setAttribute(AttributeName.MANUALFEED, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute ManualFeed </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getManualFeed()
      {
         return getBoolAttribute(AttributeName.MANUALFEED, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Collate
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Collate </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setCollate(EnumCollate enumVar)
      {
         setAttribute(AttributeName.COLLATE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Collate </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumCollate getCollate()
      {
         return EnumCollate.getEnum(getAttribute(AttributeName.COLLATE, null, null));
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
      //        Methods for Attribute NonPrintableMarginBottom
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute NonPrintableMarginBottom </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setNonPrintableMarginBottom(double @value)
      {
         setAttribute(AttributeName.NONPRINTABLEMARGINBOTTOM, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute NonPrintableMarginBottom </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getNonPrintableMarginBottom()
      {
         return getRealAttribute(AttributeName.NONPRINTABLEMARGINBOTTOM, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute NonPrintableMarginLeft
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute NonPrintableMarginLeft </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setNonPrintableMarginLeft(double @value)
      {
         setAttribute(AttributeName.NONPRINTABLEMARGINLEFT, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute NonPrintableMarginLeft </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getNonPrintableMarginLeft()
      {
         return getRealAttribute(AttributeName.NONPRINTABLEMARGINLEFT, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute NonPrintableMarginRight
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute NonPrintableMarginRight </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setNonPrintableMarginRight(double @value)
      {
         setAttribute(AttributeName.NONPRINTABLEMARGINRIGHT, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute NonPrintableMarginRight </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getNonPrintableMarginRight()
      {
         return getRealAttribute(AttributeName.NONPRINTABLEMARGINRIGHT, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute NonPrintableMarginTop
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute NonPrintableMarginTop </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setNonPrintableMarginTop(double @value)
      {
         setAttribute(AttributeName.NONPRINTABLEMARGINTOP, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute NonPrintableMarginTop </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getNonPrintableMarginTop()
      {
         return getRealAttribute(AttributeName.NONPRINTABLEMARGINTOP, null, 0.0);
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
      //        Methods for Attribute PrintingType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute PrintingType </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setPrintingType(EnumPrintingType enumVar)
      {
         setAttribute(AttributeName.PRINTINGTYPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute PrintingType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumPrintingType getPrintingType()
      {
         return EnumPrintingType.getEnum(getAttribute(AttributeName.PRINTINGTYPE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SheetLay
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute SheetLay </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setSheetLay(EnumSheetLay enumVar)
      {
         setAttribute(AttributeName.SHEETLAY, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute SheetLay </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumSheetLay getSheetLay()
      {
         return EnumSheetLay.getEnum(getAttribute(AttributeName.SHEETLAY, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Sides
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Sides </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setSides(EnumSides enumVar)
      {
         setAttribute(AttributeName.SIDES, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Sides </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumSides getSides()
      {
         return EnumSides.getEnum(getAttribute(AttributeName.SIDES, null, null));
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element Component </summary>
      ///     * <returns> JDFComponent the element </returns>
      ///     
      public virtual JDFComponent getComponent()
      {
         return (JDFComponent)getElement(ElementName.COMPONENT, null, 0);
      }

      ///     <summary> (25) getCreateComponent
      ///     *  </summary>
      ///     * <returns> JDFComponent the element </returns>
      ///     
      public virtual JDFComponent getCreateComponent()
      {
         return (JDFComponent)getCreateElement_KElement(ElementName.COMPONENT, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Component </summary>
      ///     
      public virtual JDFComponent appendComponent()
      {
         return (JDFComponent)appendElementN(ElementName.COMPONENT, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refComponent(JDFComponent refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element ApprovalParams </summary>
      ///     * <returns> JDFApprovalParams the element </returns>
      ///     
      public virtual JDFApprovalParams getApprovalParams()
      {
         return (JDFApprovalParams)getElement(ElementName.APPROVALPARAMS, null, 0);
      }

      ///     <summary> (25) getCreateApprovalParams
      ///     *  </summary>
      ///     * <returns> JDFApprovalParams the element </returns>
      ///     
      public virtual JDFApprovalParams getCreateApprovalParams()
      {
         return (JDFApprovalParams)getCreateElement_KElement(ElementName.APPROVALPARAMS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ApprovalParams </summary>
      ///     
      public virtual JDFApprovalParams appendApprovalParams()
      {
         return (JDFApprovalParams)appendElementN(ElementName.APPROVALPARAMS, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refApprovalParams(JDFApprovalParams refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element Disjointing </summary>
      ///     * <returns> JDFDisjointing the element </returns>
      ///     
      public virtual JDFDisjointing getDisjointing()
      {
         return (JDFDisjointing)getElement(ElementName.DISJOINTING, null, 0);
      }

      ///     <summary> (25) getCreateDisjointing
      ///     *  </summary>
      ///     * <returns> JDFDisjointing the element </returns>
      ///     
      public virtual JDFDisjointing getCreateDisjointing()
      {
         return (JDFDisjointing)getCreateElement_KElement(ElementName.DISJOINTING, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Disjointing </summary>
      ///     
      public virtual JDFDisjointing appendDisjointing()
      {
         return (JDFDisjointing)appendElementN(ElementName.DISJOINTING, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element Ink </summary>
      ///     * <returns> JDFInk the element </returns>
      ///     
      public virtual JDFInk getInk()
      {
         return (JDFInk)getElement(ElementName.INK, null, 0);
      }

      ///     <summary> (25) getCreateInk
      ///     *  </summary>
      ///     * <returns> JDFInk the element </returns>
      ///     
      public virtual JDFInk getCreateInk()
      {
         return (JDFInk)getCreateElement_KElement(ElementName.INK, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Ink </summary>
      ///     
      public virtual JDFInk appendInk()
      {
         return (JDFInk)appendElementN(ElementName.INK, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refInk(JDFInk refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element Media </summary>
      ///     * <returns> JDFMedia the element </returns>
      ///     
      public virtual JDFMedia getMedia()
      {
         return (JDFMedia)getElement(ElementName.MEDIA, null, 0);
      }

      ///     <summary> (25) getCreateMedia
      ///     *  </summary>
      ///     * <returns> JDFMedia the element </returns>
      ///     
      public virtual JDFMedia getCreateMedia()
      {
         return (JDFMedia)getCreateElement_KElement(ElementName.MEDIA, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Media </summary>
      ///     
      public virtual JDFMedia appendMedia()
      {
         return (JDFMedia)appendElementN(ElementName.MEDIA, 1, null);
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
