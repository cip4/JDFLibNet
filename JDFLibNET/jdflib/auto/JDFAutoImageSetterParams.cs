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
   using JDFTransferFunction = org.cip4.jdflib.datatypes.JDFTransferFunction;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFFitPolicy = org.cip4.jdflib.resource.JDFFitPolicy;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;

   public abstract class JDFAutoImageSetterParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[18];
      static JDFAutoImageSetterParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.MIRRORAROUND, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumMirrorAround.getEnum(0), "None");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.POLARITY, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumPolarity.getEnum(0), "Positive");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.SIDES, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumSides.getEnum(0), "OneSidedFront");
         atrInfoTable[3] = new AtrInfoTable(AttributeName.ADVANCEDISTANCE, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.BURNOUTAREA, 0x33333331, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.CENTERACROSS, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumCenterAcross.getEnum(0), null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.CUTMEDIA, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.MANUALFEED, 0x33333311, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.NONPRINTABLEMARGINBOTTOM, 0x33333111, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.NONPRINTABLEMARGINLEFT, 0x33333111, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[10] = new AtrInfoTable(AttributeName.NONPRINTABLEMARGINRIGHT, 0x33333111, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[11] = new AtrInfoTable(AttributeName.NONPRINTABLEMARGINTOP, 0x33333111, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[12] = new AtrInfoTable(AttributeName.PUNCH, 0x44444333, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[13] = new AtrInfoTable(AttributeName.PUNCHTYPE, 0x44444333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[14] = new AtrInfoTable(AttributeName.RESOLUTION, 0x33333333, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[15] = new AtrInfoTable(AttributeName.ROLLCUT, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[16] = new AtrInfoTable(AttributeName.SOURCEWORKSTYLE, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumSourceWorkStyle.getEnum(0), null);
         atrInfoTable[17] = new AtrInfoTable(AttributeName.TRANSFERCURVE, 0x33333333, AttributeInfo.EnumAttributeType.TransferFunction, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.MEDIA, 0x66666661);
         elemInfoTable[1] = new ElemInfoTable(ElementName.FITPOLICY, 0x66666611);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[2];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoImageSetterParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoImageSetterParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoImageSetterParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoImageSetterParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoImageSetterParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoImageSetterParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoImageSetterParams[  --> " + base.ToString() + " ]";
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



      ///        
      ///        <summary> * Enumeration strings for CenterAcross </summary>
      ///        

      public class EnumCenterAcross : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumCenterAcross(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumCenterAcross getEnum(string enumName)
         {
            return (EnumCenterAcross)getEnum(typeof(EnumCenterAcross), enumName);
         }

         public static EnumCenterAcross getEnum(int enumValue)
         {
            return (EnumCenterAcross)getEnum(typeof(EnumCenterAcross), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumCenterAcross));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumCenterAcross));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumCenterAcross));
         }

         public static readonly EnumCenterAcross None = new EnumCenterAcross("None");
         public static readonly EnumCenterAcross FeedDirection = new EnumCenterAcross("FeedDirection");
         public static readonly EnumCenterAcross MediaWidth = new EnumCenterAcross("MediaWidth");
         public static readonly EnumCenterAcross Both = new EnumCenterAcross("Both");
      }



      ///        
      ///        <summary> * Enumeration strings for SourceWorkStyle </summary>
      ///        

      public class EnumSourceWorkStyle : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumSourceWorkStyle(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumSourceWorkStyle getEnum(string enumName)
         {
            return (EnumSourceWorkStyle)getEnum(typeof(EnumSourceWorkStyle), enumName);
         }

         public static EnumSourceWorkStyle getEnum(int enumValue)
         {
            return (EnumSourceWorkStyle)getEnum(typeof(EnumSourceWorkStyle), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumSourceWorkStyle));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumSourceWorkStyle));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumSourceWorkStyle));
         }

         public static readonly EnumSourceWorkStyle Simplex = new EnumSourceWorkStyle("Simplex");
         public static readonly EnumSourceWorkStyle WorkAndBack = new EnumSourceWorkStyle("WorkAndBack");
         public static readonly EnumSourceWorkStyle Perfecting = new EnumSourceWorkStyle("Perfecting");
         public static readonly EnumSourceWorkStyle WorkAndTurn = new EnumSourceWorkStyle("WorkAndTurn");
         public static readonly EnumSourceWorkStyle WorkAndTumble = new EnumSourceWorkStyle("WorkAndTumble");
         public static readonly EnumSourceWorkStyle WorkAndTwist = new EnumSourceWorkStyle("WorkAndTwist");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

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
         return EnumSides.getEnum(getAttribute(AttributeName.SIDES, null, "OneSidedFront"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute AdvanceDistance
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute AdvanceDistance </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAdvanceDistance(double @value)
      {
         setAttribute(AttributeName.ADVANCEDISTANCE, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute AdvanceDistance </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getAdvanceDistance()
      {
         return getRealAttribute(AttributeName.ADVANCEDISTANCE, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute BurnOutArea
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BurnOutArea </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBurnOutArea(JDFXYPair @value)
      {
         setAttribute(AttributeName.BURNOUTAREA, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute BurnOutArea </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getBurnOutArea()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.BURNOUTAREA, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute CenterAcross
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute CenterAcross </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setCenterAcross(EnumCenterAcross enumVar)
      {
         setAttribute(AttributeName.CENTERACROSS, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute CenterAcross </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumCenterAcross getCenterAcross()
      {
         return EnumCenterAcross.getEnum(getAttribute(AttributeName.CENTERACROSS, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute CutMedia
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CutMedia </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCutMedia(bool @value)
      {
         setAttribute(AttributeName.CUTMEDIA, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute CutMedia </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getCutMedia()
      {
         return getBoolAttribute(AttributeName.CUTMEDIA, null, false);
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
      //        Methods for Attribute Punch
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Punch </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPunch(bool @value)
      {
         setAttribute(AttributeName.PUNCH, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute Punch </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getPunch()
      {
         return getBoolAttribute(AttributeName.PUNCH, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PunchType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PunchType </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPunchType(string @value)
      {
         setAttribute(AttributeName.PUNCHTYPE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute PunchType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getPunchType()
      {
         return getAttribute(AttributeName.PUNCHTYPE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Resolution
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Resolution </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setResolution(JDFXYPair @value)
      {
         setAttribute(AttributeName.RESOLUTION, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute Resolution </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getResolution()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.RESOLUTION, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute RollCut
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute RollCut </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setRollCut(double @value)
      {
         setAttribute(AttributeName.ROLLCUT, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute RollCut </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getRollCut()
      {
         return getRealAttribute(AttributeName.ROLLCUT, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SourceWorkStyle
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute SourceWorkStyle </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setSourceWorkStyle(EnumSourceWorkStyle enumVar)
      {
         setAttribute(AttributeName.SOURCEWORKSTYLE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute SourceWorkStyle </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumSourceWorkStyle getSourceWorkStyle()
      {
         return EnumSourceWorkStyle.getEnum(getAttribute(AttributeName.SOURCEWORKSTYLE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TransferCurve
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TransferCurve </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTransferCurve(JDFTransferFunction @value)
      {
         setAttribute(AttributeName.TRANSFERCURVE, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFTransferFunction attribute TransferCurve </summary>
      ///          * <returns> JDFTransferFunction the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFTransferFunction </returns>
      ///          
      public virtual JDFTransferFunction getTransferCurve()
      {
         string strAttrName = "";
         JDFTransferFunction nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.TRANSFERCURVE, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFTransferFunction(strAttrName);
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
   }
}
