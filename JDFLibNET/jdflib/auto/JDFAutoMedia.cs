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
   using JDFLabColor = org.cip4.jdflib.datatypes.JDFLabColor;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFColorMeasurementConditions = org.cip4.jdflib.resource.JDFColorMeasurementConditions;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFColor = org.cip4.jdflib.resource.process.JDFColor;
   using JDFContact = org.cip4.jdflib.resource.process.JDFContact;
   using JDFIdentificationField = org.cip4.jdflib.resource.process.JDFIdentificationField;
   using JDFMediaLayers = org.cip4.jdflib.resource.process.JDFMediaLayers;
   using JDFHoleList = org.cip4.jdflib.resource.process.postpress.JDFHoleList;

   public abstract class JDFAutoMedia : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[42];
      static JDFAutoMedia()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.HOLETYPE, 0x33333331, AttributeInfo.EnumAttributeType.enumerations, EnumHoleType.getEnum(0), "None");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.MEDIAUNIT, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumMediaUnit.getEnum(0), "Sheet");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.PREPRINTED, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[3] = new AtrInfoTable(AttributeName.BACKCOATINGS, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumBackCoatings.getEnum(0), null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.BACKGLOSSVALUE, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.BRIGHTNESS, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.CIETINT, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.CIEWHITENESS, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.COLORNAME, 0x44444431, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.COREWEIGHT, 0x33333111, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[10] = new AtrInfoTable(AttributeName.DIMENSION, 0x33333333, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[11] = new AtrInfoTable(AttributeName.FLUTE, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[12] = new AtrInfoTable(AttributeName.FLUTEDIRECTION, 0x33333111, AttributeInfo.EnumAttributeType.enumeration, EnumFluteDirection.getEnum(0), null);
         atrInfoTable[13] = new AtrInfoTable(AttributeName.FRONTCOATINGS, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumFrontCoatings.getEnum(0), null);
         atrInfoTable[14] = new AtrInfoTable(AttributeName.FRONTGLOSSVALUE, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[15] = new AtrInfoTable(AttributeName.GRADE, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[16] = new AtrInfoTable(AttributeName.GRAINDIRECTION, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumGrainDirection.getEnum(0), null);
         atrInfoTable[17] = new AtrInfoTable(AttributeName.HOLECOUNT, 0x44444443, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[18] = new AtrInfoTable(AttributeName.IMAGABLESIDE, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumImagableSide.getEnum(0), null);
         atrInfoTable[19] = new AtrInfoTable(AttributeName.INSIDELOSS, 0x33333111, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[20] = new AtrInfoTable(AttributeName.LABCOLORVALUE, 0x33333311, AttributeInfo.EnumAttributeType.LabColor, null, null);
         atrInfoTable[21] = new AtrInfoTable(AttributeName.MEDIACOLORNAME, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[22] = new AtrInfoTable(AttributeName.MEDIACOLORNAMEDETAILS, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[23] = new AtrInfoTable(AttributeName.MEDIASETCOUNT, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[24] = new AtrInfoTable(AttributeName.MEDIATYPE, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumMediaType.getEnum(0), null);
         atrInfoTable[25] = new AtrInfoTable(AttributeName.MEDIATYPEDETAILS, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[26] = new AtrInfoTable(AttributeName.OPACITY, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumOpacity.getEnum(0), null);
         atrInfoTable[27] = new AtrInfoTable(AttributeName.OPACITYLEVEL, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[28] = new AtrInfoTable(AttributeName.OUTERCOREDIAMETER, 0x33333111, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[29] = new AtrInfoTable(AttributeName.OUTSIDEGAIN, 0x33333111, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[30] = new AtrInfoTable(AttributeName.PLATETECHNOLOGY, 0x33333111, AttributeInfo.EnumAttributeType.enumeration, EnumPlateTechnology.getEnum(0), null);
         atrInfoTable[31] = new AtrInfoTable(AttributeName.POLARITY, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumPolarity.getEnum(0), null);
         atrInfoTable[32] = new AtrInfoTable(AttributeName.RECYCLED, 0x44444433, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[33] = new AtrInfoTable(AttributeName.RECYCLEDPERCENTAGE, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[34] = new AtrInfoTable(AttributeName.ROLLDIAMETER, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[35] = new AtrInfoTable(AttributeName.SHRINKINDEX, 0x33333331, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[36] = new AtrInfoTable(AttributeName.STOCKTYPE, 0x33333331, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[37] = new AtrInfoTable(AttributeName.TEXTURE, 0x33333331, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[38] = new AtrInfoTable(AttributeName.THICKNESS, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[39] = new AtrInfoTable(AttributeName.USERMEDIATYPE, 0x44444443, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[40] = new AtrInfoTable(AttributeName.WEIGHT, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[41] = new AtrInfoTable(AttributeName.WRAPPERWEIGHT, 0x33333111, AttributeInfo.EnumAttributeType.double_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.COLOR, 0x77777776);
         elemInfoTable[1] = new ElemInfoTable(ElementName.COLORMEASUREMENTCONDITIONS, 0x66666611);
         elemInfoTable[2] = new ElemInfoTable(ElementName.MEDIALAYERS, 0x66666111);
         elemInfoTable[3] = new ElemInfoTable(ElementName.HOLELIST, 0x66666611);
         elemInfoTable[4] = new ElemInfoTable(ElementName.CONTACT, 0x33333333);
         elemInfoTable[5] = new ElemInfoTable(ElementName.IDENTIFICATIONFIELD, 0x33333333);
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
      ///     <summary> * Constructor for JDFAutoMedia </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoMedia(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoMedia </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoMedia(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoMedia </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoMedia(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoMedia[  --> " + base.ToString() + " ]";
      }


      public override bool init()
      {
         bool bRet = base.init();
         setResourceClass(JDFResource.EnumResourceClass.Consumable);
         return bRet;
      }


      public override EnumResourceClass getValidClass()
      {
         return JDFResource.EnumResourceClass.Consumable;
      }


      ///        
      ///        <summary> * Enumeration strings for HoleType </summary>
      ///        

      public class EnumHoleType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumHoleType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumHoleType getEnum(string enumName)
         {
            return (EnumHoleType)getEnum(typeof(EnumHoleType), enumName);
         }

         public static EnumHoleType getEnum(int enumValue)
         {
            return (EnumHoleType)getEnum(typeof(EnumHoleType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumHoleType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumHoleType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumHoleType));
         }

         public static readonly EnumHoleType None = new EnumHoleType("None");
         public static readonly EnumHoleType S1_generic = new EnumHoleType("S1-generic");
         public static readonly EnumHoleType S_generic = new EnumHoleType("S-generic");
         public static readonly EnumHoleType R2_generic = new EnumHoleType("R2-generic");
         public static readonly EnumHoleType R2m_DIN = new EnumHoleType("R2m-DIN");
         public static readonly EnumHoleType R2m_ISO = new EnumHoleType("R2m-ISO");
         public static readonly EnumHoleType R2m_MIB = new EnumHoleType("R2m-MIB");
         public static readonly EnumHoleType R2i_US_a = new EnumHoleType("R2i-US-a");
         public static readonly EnumHoleType R2i_US_b = new EnumHoleType("R2i-US-b");
         public static readonly EnumHoleType R3_generic = new EnumHoleType("R3-generic");
         public static readonly EnumHoleType R3i_US = new EnumHoleType("R3i-US");
         public static readonly EnumHoleType R4_generic = new EnumHoleType("R4-generic");
         public static readonly EnumHoleType R4m_DIN_A4 = new EnumHoleType("R4m-DIN-A4");
         public static readonly EnumHoleType R4m_DIN_A5 = new EnumHoleType("R4m-DIN-A5");
         public static readonly EnumHoleType R4m_swedish = new EnumHoleType("R4m-swedish");
         public static readonly EnumHoleType R4i_US = new EnumHoleType("R4i-US");
         public static readonly EnumHoleType R5_generic = new EnumHoleType("R5-generic");
         public static readonly EnumHoleType R5i_US_a = new EnumHoleType("R5i-US-a");
         public static readonly EnumHoleType R5i_US_b = new EnumHoleType("R5i-US-b");
         public static readonly EnumHoleType R5i_US_c = new EnumHoleType("R5i-US-c");
         public static readonly EnumHoleType R6_generic = new EnumHoleType("R6-generic");
         public static readonly EnumHoleType R6m_4h2s = new EnumHoleType("R6m-4h2s");
         public static readonly EnumHoleType R6m_DIN_A5 = new EnumHoleType("R6m-DIN-A5");
         public static readonly EnumHoleType R7_generic = new EnumHoleType("R7-generic");
         public static readonly EnumHoleType R7i_US_a = new EnumHoleType("R7i-US-a");
         public static readonly EnumHoleType R7i_US_b = new EnumHoleType("R7i-US-b");
         public static readonly EnumHoleType R7i_US_c = new EnumHoleType("R7i-US-c");
         public static readonly EnumHoleType R11m_7h4s = new EnumHoleType("R11m-7h4s");
         public static readonly EnumHoleType P16_9i_rect_0t = new EnumHoleType("P16_9i-rect-0t");
         public static readonly EnumHoleType P12m_rect_0t = new EnumHoleType("P12m-rect-0t");
         public static readonly EnumHoleType W2_1i_round_0t = new EnumHoleType("W2_1i-round-0t");
         public static readonly EnumHoleType W2_1i_square_0t = new EnumHoleType("W2_1i-square-0t");
         public static readonly EnumHoleType W3_1i_square_0t = new EnumHoleType("W3_1i-square-0t");
         public static readonly EnumHoleType C9_5m_round_0t = new EnumHoleType("C9.5m-round-0t");
         public static readonly EnumHoleType Explicit = new EnumHoleType("Explicit");
      }



      ///        
      ///        <summary> * Enumeration strings for MediaUnit </summary>
      ///        

      public class EnumMediaUnit : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumMediaUnit(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumMediaUnit getEnum(string enumName)
         {
            return (EnumMediaUnit)getEnum(typeof(EnumMediaUnit), enumName);
         }

         public static EnumMediaUnit getEnum(int enumValue)
         {
            return (EnumMediaUnit)getEnum(typeof(EnumMediaUnit), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumMediaUnit));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumMediaUnit));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumMediaUnit));
         }

         public static readonly EnumMediaUnit Continuous = new EnumMediaUnit("Continuous");
         public static readonly EnumMediaUnit Roll = new EnumMediaUnit("Roll");
         public static readonly EnumMediaUnit Sheet = new EnumMediaUnit("Sheet");
      }



      ///        
      ///        <summary> * Enumeration strings for BackCoatings </summary>
      ///        

      public class EnumBackCoatings : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumBackCoatings(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumBackCoatings getEnum(string enumName)
         {
            return (EnumBackCoatings)getEnum(typeof(EnumBackCoatings), enumName);
         }

         public static EnumBackCoatings getEnum(int enumValue)
         {
            return (EnumBackCoatings)getEnum(typeof(EnumBackCoatings), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumBackCoatings));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumBackCoatings));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumBackCoatings));
         }

         public static readonly EnumBackCoatings None = new EnumBackCoatings("None");
         public static readonly EnumBackCoatings Coated = new EnumBackCoatings("Coated");
         public static readonly EnumBackCoatings Glossy = new EnumBackCoatings("Glossy");
         public static readonly EnumBackCoatings HighGloss = new EnumBackCoatings("HighGloss");
         public static readonly EnumBackCoatings InkJet = new EnumBackCoatings("InkJet");
         public static readonly EnumBackCoatings Matte = new EnumBackCoatings("Matte");
         public static readonly EnumBackCoatings Polymer = new EnumBackCoatings("Polymer");
         public static readonly EnumBackCoatings Silver = new EnumBackCoatings("Silver");
         public static readonly EnumBackCoatings Satin = new EnumBackCoatings("Satin");
         public static readonly EnumBackCoatings Semigloss = new EnumBackCoatings("Semigloss");
      }



      ///        
      ///        <summary> * Enumeration strings for FluteDirection </summary>
      ///        

      public class EnumFluteDirection : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumFluteDirection(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumFluteDirection getEnum(string enumName)
         {
            return (EnumFluteDirection)getEnum(typeof(EnumFluteDirection), enumName);
         }

         public static EnumFluteDirection getEnum(int enumValue)
         {
            return (EnumFluteDirection)getEnum(typeof(EnumFluteDirection), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumFluteDirection));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumFluteDirection));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumFluteDirection));
         }

         public static readonly EnumFluteDirection LongEdge = new EnumFluteDirection("LongEdge");
         public static readonly EnumFluteDirection ShortEdge = new EnumFluteDirection("ShortEdge");
         public static readonly EnumFluteDirection XDirection = new EnumFluteDirection("XDirection");
         public static readonly EnumFluteDirection YDirection = new EnumFluteDirection("YDirection");
      }



      ///        
      ///        <summary> * Enumeration strings for FrontCoatings </summary>
      ///        

      public class EnumFrontCoatings : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumFrontCoatings(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumFrontCoatings getEnum(string enumName)
         {
            return (EnumFrontCoatings)getEnum(typeof(EnumFrontCoatings), enumName);
         }

         public static EnumFrontCoatings getEnum(int enumValue)
         {
            return (EnumFrontCoatings)getEnum(typeof(EnumFrontCoatings), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumFrontCoatings));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumFrontCoatings));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumFrontCoatings));
         }

         public static readonly EnumFrontCoatings None = new EnumFrontCoatings("None");
         public static readonly EnumFrontCoatings Coated = new EnumFrontCoatings("Coated");
         public static readonly EnumFrontCoatings Glossy = new EnumFrontCoatings("Glossy");
         public static readonly EnumFrontCoatings HighGloss = new EnumFrontCoatings("HighGloss");
         public static readonly EnumFrontCoatings InkJet = new EnumFrontCoatings("InkJet");
         public static readonly EnumFrontCoatings Matte = new EnumFrontCoatings("Matte");
         public static readonly EnumFrontCoatings Polymer = new EnumFrontCoatings("Polymer");
         public static readonly EnumFrontCoatings Silver = new EnumFrontCoatings("Silver");
         public static readonly EnumFrontCoatings Satin = new EnumFrontCoatings("Satin");
         public static readonly EnumFrontCoatings Semigloss = new EnumFrontCoatings("Semigloss");
      }



      ///        
      ///        <summary> * Enumeration strings for GrainDirection </summary>
      ///        

      public class EnumGrainDirection : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumGrainDirection(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumGrainDirection getEnum(string enumName)
         {
            return (EnumGrainDirection)getEnum(typeof(EnumGrainDirection), enumName);
         }

         public static EnumGrainDirection getEnum(int enumValue)
         {
            return (EnumGrainDirection)getEnum(typeof(EnumGrainDirection), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumGrainDirection));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumGrainDirection));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumGrainDirection));
         }

         public static readonly EnumGrainDirection LongEdge = new EnumGrainDirection("LongEdge");
         public static readonly EnumGrainDirection ShortEdge = new EnumGrainDirection("ShortEdge");
         public static readonly EnumGrainDirection XDirection = new EnumGrainDirection("XDirection");
         public static readonly EnumGrainDirection YDirection = new EnumGrainDirection("YDirection");
      }



      ///        
      ///        <summary> * Enumeration strings for ImagableSide </summary>
      ///        

      public class EnumImagableSide : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumImagableSide(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumImagableSide getEnum(string enumName)
         {
            return (EnumImagableSide)getEnum(typeof(EnumImagableSide), enumName);
         }

         public static EnumImagableSide getEnum(int enumValue)
         {
            return (EnumImagableSide)getEnum(typeof(EnumImagableSide), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumImagableSide));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumImagableSide));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumImagableSide));
         }

         public static readonly EnumImagableSide Front = new EnumImagableSide("Front");
         public static readonly EnumImagableSide Back = new EnumImagableSide("Back");
         public static readonly EnumImagableSide Both = new EnumImagableSide("Both");
         public static readonly EnumImagableSide Neither = new EnumImagableSide("Neither");
      }



      ///        
      ///        <summary> * Enumeration strings for MediaType </summary>
      ///        

      public class EnumMediaType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumMediaType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumMediaType getEnum(string enumName)
         {
            return (EnumMediaType)getEnum(typeof(EnumMediaType), enumName);
         }

         public static EnumMediaType getEnum(int enumValue)
         {
            return (EnumMediaType)getEnum(typeof(EnumMediaType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumMediaType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumMediaType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumMediaType));
         }

         public static readonly EnumMediaType CorrugatedBoard = new EnumMediaType("CorrugatedBoard");
         public static readonly EnumMediaType Disc = new EnumMediaType("Disc");
         public static readonly EnumMediaType EndBoard = new EnumMediaType("EndBoard");
         public static readonly EnumMediaType EmbossingFoil = new EnumMediaType("EmbossingFoil");
         public static readonly EnumMediaType Film = new EnumMediaType("Film");
         public static readonly EnumMediaType Foil = new EnumMediaType("Foil");
         public static readonly EnumMediaType GravureCylinder = new EnumMediaType("GravureCylinder");
         public static readonly EnumMediaType ImagingCylinder = new EnumMediaType("ImagingCylinder");
         public static readonly EnumMediaType LaminatingFoil = new EnumMediaType("LaminatingFoil");
         public static readonly EnumMediaType Other = new EnumMediaType("Other");
         public static readonly EnumMediaType Paper = new EnumMediaType("Paper");
         public static readonly EnumMediaType Plate = new EnumMediaType("Plate");
         public static readonly EnumMediaType SelfAdhesive = new EnumMediaType("SelfAdhesive");
         public static readonly EnumMediaType ShrinkFoil = new EnumMediaType("ShrinkFoil");
         public static readonly EnumMediaType Transparency = new EnumMediaType("Transparency");
         public static readonly EnumMediaType Unknown = new EnumMediaType("Unknown");
      }



      ///        
      ///        <summary> * Enumeration strings for Opacity </summary>
      ///        

      public class EnumOpacity : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumOpacity(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumOpacity getEnum(string enumName)
         {
            return (EnumOpacity)getEnum(typeof(EnumOpacity), enumName);
         }

         public static EnumOpacity getEnum(int enumValue)
         {
            return (EnumOpacity)getEnum(typeof(EnumOpacity), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumOpacity));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumOpacity));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumOpacity));
         }

         public static readonly EnumOpacity Opaque = new EnumOpacity("Opaque");
         public static readonly EnumOpacity Translucent = new EnumOpacity("Translucent");
         public static readonly EnumOpacity Transparent = new EnumOpacity("Transparent");
      }



      ///        
      ///        <summary> * Enumeration strings for PlateTechnology </summary>
      ///        

      public class EnumPlateTechnology : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumPlateTechnology(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumPlateTechnology getEnum(string enumName)
         {
            return (EnumPlateTechnology)getEnum(typeof(EnumPlateTechnology), enumName);
         }

         public static EnumPlateTechnology getEnum(int enumValue)
         {
            return (EnumPlateTechnology)getEnum(typeof(EnumPlateTechnology), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumPlateTechnology));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumPlateTechnology));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumPlateTechnology));
         }

         public static readonly EnumPlateTechnology InkJet = new EnumPlateTechnology("InkJet");
         public static readonly EnumPlateTechnology Thermal = new EnumPlateTechnology("Thermal");
         public static readonly EnumPlateTechnology UV = new EnumPlateTechnology("UV");
         public static readonly EnumPlateTechnology Visible = new EnumPlateTechnology("Visible");
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



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute HoleType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5.2) set attribute HoleType </summary>
      ///          * <param name="v"> vector of the enumeration values </param>
      ///          
      public virtual void setHoleType(List<ValuedEnum> v)
      {
         setEnumerationsAttribute(AttributeName.HOLETYPE, v, null);
      }

      ///        
      ///          <summary> * (9.2) get HoleType attribute HoleType </summary>
      ///          * <returns> Vector of the enumerations </returns>
      ///          
      public virtual List<ValuedEnum> getHoleType()
      {
         return getEnumerationsAttribute(AttributeName.HOLETYPE, null, EnumHoleType.None, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MediaUnit
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute MediaUnit </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setMediaUnit(EnumMediaUnit enumVar)
      {
         setAttribute(AttributeName.MEDIAUNIT, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute MediaUnit </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumMediaUnit getMediaUnit()
      {
         return EnumMediaUnit.getEnum(getAttribute(AttributeName.MEDIAUNIT, null, "Sheet"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PrePrinted
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PrePrinted </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPrePrinted(bool @value)
      {
         setAttribute(AttributeName.PREPRINTED, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute PrePrinted </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getPrePrinted()
      {
         return getBoolAttribute(AttributeName.PREPRINTED, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute BackCoatings
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute BackCoatings </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setBackCoatings(EnumBackCoatings enumVar)
      {
         setAttribute(AttributeName.BACKCOATINGS, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute BackCoatings </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumBackCoatings getBackCoatings()
      {
         return EnumBackCoatings.getEnum(getAttribute(AttributeName.BACKCOATINGS, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute BackGlossValue
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BackGlossValue </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBackGlossValue(double @value)
      {
         setAttribute(AttributeName.BACKGLOSSVALUE, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute BackGlossValue </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getBackGlossValue()
      {
         return getRealAttribute(AttributeName.BACKGLOSSVALUE, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Brightness
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Brightness </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBrightness(double @value)
      {
         setAttribute(AttributeName.BRIGHTNESS, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute Brightness </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getBrightness()
      {
         return getRealAttribute(AttributeName.BRIGHTNESS, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute CIETint
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CIETint </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCIETint(double @value)
      {
         setAttribute(AttributeName.CIETINT, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute CIETint </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getCIETint()
      {
         return getRealAttribute(AttributeName.CIETINT, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute CIEWhiteness
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CIEWhiteness </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCIEWhiteness(double @value)
      {
         setAttribute(AttributeName.CIEWHITENESS, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute CIEWhiteness </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getCIEWhiteness()
      {
         return getRealAttribute(AttributeName.CIEWHITENESS, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ColorName
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ColorName </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setColorName(string @value)
      {
         setAttribute(AttributeName.COLORNAME, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ColorName </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getColorName()
      {
         return getAttribute(AttributeName.COLORNAME, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute CoreWeight
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CoreWeight </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCoreWeight(double @value)
      {
         setAttribute(AttributeName.COREWEIGHT, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute CoreWeight </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getCoreWeight()
      {
         return getRealAttribute(AttributeName.COREWEIGHT, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Dimension
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Dimension </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDimension(JDFXYPair @value)
      {
         setAttribute(AttributeName.DIMENSION, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute Dimension </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getDimension()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.DIMENSION, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute Flute
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Flute </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFlute(string @value)
      {
         setAttribute(AttributeName.FLUTE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Flute </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getFlute()
      {
         return getAttribute(AttributeName.FLUTE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute FluteDirection
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute FluteDirection </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setFluteDirection(EnumFluteDirection enumVar)
      {
         setAttribute(AttributeName.FLUTEDIRECTION, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute FluteDirection </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumFluteDirection getFluteDirection()
      {
         return EnumFluteDirection.getEnum(getAttribute(AttributeName.FLUTEDIRECTION, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute FrontCoatings
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute FrontCoatings </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setFrontCoatings(EnumFrontCoatings enumVar)
      {
         setAttribute(AttributeName.FRONTCOATINGS, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute FrontCoatings </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumFrontCoatings getFrontCoatings()
      {
         return EnumFrontCoatings.getEnum(getAttribute(AttributeName.FRONTCOATINGS, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute FrontGlossValue
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute FrontGlossValue </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFrontGlossValue(double @value)
      {
         setAttribute(AttributeName.FRONTGLOSSVALUE, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute FrontGlossValue </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getFrontGlossValue()
      {
         return getRealAttribute(AttributeName.FRONTGLOSSVALUE, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Grade
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Grade </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setGrade(int @value)
      {
         setAttribute(AttributeName.GRADE, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute Grade </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getGrade()
      {
         return getIntAttribute(AttributeName.GRADE, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute GrainDirection
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute GrainDirection </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setGrainDirection(EnumGrainDirection enumVar)
      {
         setAttribute(AttributeName.GRAINDIRECTION, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute GrainDirection </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumGrainDirection getGrainDirection()
      {
         return EnumGrainDirection.getEnum(getAttribute(AttributeName.GRAINDIRECTION, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute HoleCount
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute HoleCount </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setHoleCount(int @value)
      {
         setAttribute(AttributeName.HOLECOUNT, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute HoleCount </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getHoleCount()
      {
         return getIntAttribute(AttributeName.HOLECOUNT, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ImagableSide
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute ImagableSide </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setImagableSide(EnumImagableSide enumVar)
      {
         setAttribute(AttributeName.IMAGABLESIDE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute ImagableSide </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumImagableSide getImagableSide()
      {
         return EnumImagableSide.getEnum(getAttribute(AttributeName.IMAGABLESIDE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute InsideLoss
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute InsideLoss </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setInsideLoss(double @value)
      {
         setAttribute(AttributeName.INSIDELOSS, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute InsideLoss </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getInsideLoss()
      {
         return getRealAttribute(AttributeName.INSIDELOSS, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute LabColorValue
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute LabColorValue </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setLabColorValue(JDFLabColor @value)
      {
         setAttribute(AttributeName.LABCOLORVALUE, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFLabColor attribute LabColorValue </summary>
      ///          * <returns> JDFLabColor the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFLabColor </returns>
      ///          
      public virtual JDFLabColor getLabColorValue()
      {
         string strAttrName = "";
         JDFLabColor nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.LABCOLORVALUE, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute MediaColorName
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (13) set attribute MediaColorName </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMediaColorName(EnumNamedColor @value)
      {
         setAttribute(AttributeName.MEDIACOLORNAME, @value == null ? null : @value.getName(), null);
      }

      ///        
      ///          <summary> * (19) get EnumNamedColor attribute MediaColorName </summary>
      ///          * <returns> EnumNamedColor the value of the attribute </returns>
      ///          
      public virtual EnumNamedColor getMediaColorName()
      {
         string strAttrName = "";
         EnumNamedColor nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.MEDIACOLORNAME, null, JDFConstants.EMPTYSTRING);
         nPlaceHolder = EnumNamedColor.getEnum(strAttrName);
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MediaColorNameDetails
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MediaColorNameDetails </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMediaColorNameDetails(string @value)
      {
         setAttribute(AttributeName.MEDIACOLORNAMEDETAILS, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute MediaColorNameDetails </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getMediaColorNameDetails()
      {
         return getAttribute(AttributeName.MEDIACOLORNAMEDETAILS, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MediaSetCount
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MediaSetCount </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMediaSetCount(int @value)
      {
         setAttribute(AttributeName.MEDIASETCOUNT, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute MediaSetCount </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getMediaSetCount()
      {
         return getIntAttribute(AttributeName.MEDIASETCOUNT, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MediaType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute MediaType </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setMediaType(EnumMediaType enumVar)
      {
         setAttribute(AttributeName.MEDIATYPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute MediaType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumMediaType getMediaType()
      {
         return EnumMediaType.getEnum(getAttribute(AttributeName.MEDIATYPE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MediaTypeDetails
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MediaTypeDetails </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMediaTypeDetails(string @value)
      {
         setAttribute(AttributeName.MEDIATYPEDETAILS, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute MediaTypeDetails </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getMediaTypeDetails()
      {
         return getAttribute(AttributeName.MEDIATYPEDETAILS, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Opacity
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Opacity </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setOpacity(EnumOpacity enumVar)
      {
         setAttribute(AttributeName.OPACITY, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Opacity </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumOpacity getOpacity()
      {
         return EnumOpacity.getEnum(getAttribute(AttributeName.OPACITY, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute OpacityLevel
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute OpacityLevel </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setOpacityLevel(double @value)
      {
         setAttribute(AttributeName.OPACITYLEVEL, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute OpacityLevel </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getOpacityLevel()
      {
         return getRealAttribute(AttributeName.OPACITYLEVEL, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute OuterCoreDiameter
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute OuterCoreDiameter </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setOuterCoreDiameter(double @value)
      {
         setAttribute(AttributeName.OUTERCOREDIAMETER, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute OuterCoreDiameter </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getOuterCoreDiameter()
      {
         return getRealAttribute(AttributeName.OUTERCOREDIAMETER, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute OutsideGain
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute OutsideGain </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setOutsideGain(double @value)
      {
         setAttribute(AttributeName.OUTSIDEGAIN, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute OutsideGain </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getOutsideGain()
      {
         return getRealAttribute(AttributeName.OUTSIDEGAIN, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PlateTechnology
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute PlateTechnology </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setPlateTechnology(EnumPlateTechnology enumVar)
      {
         setAttribute(AttributeName.PLATETECHNOLOGY, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute PlateTechnology </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumPlateTechnology getPlateTechnology()
      {
         return EnumPlateTechnology.getEnum(getAttribute(AttributeName.PLATETECHNOLOGY, null, null));
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
         return EnumPolarity.getEnum(getAttribute(AttributeName.POLARITY, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Recycled
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Recycled </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setRecycled(bool @value)
      {
         setAttribute(AttributeName.RECYCLED, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute Recycled </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getRecycled()
      {
         return getBoolAttribute(AttributeName.RECYCLED, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute RecycledPercentage
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute RecycledPercentage </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setRecycledPercentage(double @value)
      {
         setAttribute(AttributeName.RECYCLEDPERCENTAGE, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute RecycledPercentage </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getRecycledPercentage()
      {
         return getRealAttribute(AttributeName.RECYCLEDPERCENTAGE, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute RollDiameter
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute RollDiameter </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setRollDiameter(double @value)
      {
         setAttribute(AttributeName.ROLLDIAMETER, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute RollDiameter </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getRollDiameter()
      {
         return getRealAttribute(AttributeName.ROLLDIAMETER, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ShrinkIndex
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ShrinkIndex </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setShrinkIndex(JDFXYPair @value)
      {
         setAttribute(AttributeName.SHRINKINDEX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute ShrinkIndex </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getShrinkIndex()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.SHRINKINDEX, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute StockType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute StockType </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setStockType(string @value)
      {
         setAttribute(AttributeName.STOCKTYPE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute StockType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getStockType()
      {
         return getAttribute(AttributeName.STOCKTYPE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Texture
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Texture </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTexture(string @value)
      {
         setAttribute(AttributeName.TEXTURE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Texture </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getTexture()
      {
         return getAttribute(AttributeName.TEXTURE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Thickness
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Thickness </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setThickness(double @value)
      {
         setAttribute(AttributeName.THICKNESS, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute Thickness </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getThickness()
      {
         return getRealAttribute(AttributeName.THICKNESS, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute UserMediaType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute UserMediaType </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setUserMediaType(string @value)
      {
         setAttribute(AttributeName.USERMEDIATYPE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute UserMediaType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getUserMediaType()
      {
         return getAttribute(AttributeName.USERMEDIATYPE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Weight
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Weight </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setWeight(double @value)
      {
         setAttribute(AttributeName.WEIGHT, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute Weight </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getWeight()
      {
         return getRealAttribute(AttributeName.WEIGHT, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute WrapperWeight
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute WrapperWeight </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setWrapperWeight(double @value)
      {
         setAttribute(AttributeName.WRAPPERWEIGHT, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute WrapperWeight </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getWrapperWeight()
      {
         return getRealAttribute(AttributeName.WRAPPERWEIGHT, null, 0.0);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element Color </summary>
      ///     * <returns> JDFColor the element </returns>
      ///     
      public virtual JDFColor getColor()
      {
         return (JDFColor)getElement(ElementName.COLOR, null, 0);
      }

      ///     <summary> (25) getCreateColor
      ///     *  </summary>
      ///     * <returns> JDFColor the element </returns>
      ///     
      public virtual JDFColor getCreateColor()
      {
         return (JDFColor)getCreateElement_KElement(ElementName.COLOR, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Color </summary>
      ///     
      public virtual JDFColor appendColor()
      {
         return (JDFColor)appendElementN(ElementName.COLOR, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refColor(JDFColor refTarget)
      {
         refElement(refTarget);
      }

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

      ///    
      ///     <summary> * (24) const get element MediaLayers </summary>
      ///     * <returns> JDFMediaLayers the element </returns>
      ///     
      public virtual JDFMediaLayers getMediaLayers()
      {
         return (JDFMediaLayers)getElement(ElementName.MEDIALAYERS, null, 0);
      }

      ///     <summary> (25) getCreateMediaLayers
      ///     *  </summary>
      ///     * <returns> JDFMediaLayers the element </returns>
      ///     
      public virtual JDFMediaLayers getCreateMediaLayers()
      {
         return (JDFMediaLayers)getCreateElement_KElement(ElementName.MEDIALAYERS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element MediaLayers </summary>
      ///     
      public virtual JDFMediaLayers appendMediaLayers()
      {
         return (JDFMediaLayers)appendElementN(ElementName.MEDIALAYERS, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element HoleList </summary>
      ///     * <returns> JDFHoleList the element </returns>
      ///     
      public virtual JDFHoleList getHoleList()
      {
         return (JDFHoleList)getElement(ElementName.HOLELIST, null, 0);
      }

      ///     <summary> (25) getCreateHoleList
      ///     *  </summary>
      ///     * <returns> JDFHoleList the element </returns>
      ///     
      public virtual JDFHoleList getCreateHoleList()
      {
         return (JDFHoleList)getCreateElement_KElement(ElementName.HOLELIST, null, 0);
      }

      ///    
      ///     <summary> * (29) append element HoleList </summary>
      ///     
      public virtual JDFHoleList appendHoleList()
      {
         return (JDFHoleList)appendElementN(ElementName.HOLELIST, 1, null);
      }

      ///     <summary> (26) getCreateContact
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFContact the element </returns>
      ///     
      public virtual JDFContact getCreateContact(int iSkip)
      {
         return (JDFContact)getCreateElement_KElement(ElementName.CONTACT, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Contact </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFContact the element </returns>
      ///     * default is getContact(0)     
      public virtual JDFContact getContact(int iSkip)
      {
         return (JDFContact)getElement(ElementName.CONTACT, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Contact from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFContact> </returns>
      ///     
      public virtual ICollection<JDFContact> getAllContact()
      {
         List<JDFContact> v = new List<JDFContact>();

         JDFContact kElem = (JDFContact)getFirstChildElement(ElementName.CONTACT, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFContact)kElem.getNextSiblingElement(ElementName.CONTACT, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Contact </summary>
      ///     
      public override JDFContact appendContact()
      {
         return (JDFContact)appendElement(ElementName.CONTACT, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refContact(JDFContact refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreateIdentificationField
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFIdentificationField the element </returns>
      ///     
      public override JDFIdentificationField getCreateIdentificationField(int iSkip)
      {
         return (JDFIdentificationField)getCreateElement_KElement(ElementName.IDENTIFICATIONFIELD, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element IdentificationField </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFIdentificationField the element </returns>
      ///     * default is getIdentificationField(0)     
      public override JDFIdentificationField getIdentificationField(int iSkip)
      {
         return (JDFIdentificationField)getElement(ElementName.IDENTIFICATIONFIELD, null, iSkip);
      }

      ///    
      ///     <summary> * Get all IdentificationField from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFIdentificationField> </returns>
      ///     
      public virtual ICollection<JDFIdentificationField> getAllIdentificationField()
      {
         List<JDFIdentificationField> v = new List<JDFIdentificationField>();

         JDFIdentificationField kElem = (JDFIdentificationField)getFirstChildElement(ElementName.IDENTIFICATIONFIELD, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFIdentificationField)kElem.getNextSiblingElement(ElementName.IDENTIFICATIONFIELD, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element IdentificationField </summary>
      ///     
      public override JDFIdentificationField appendIdentificationField()
      {
         return (JDFIdentificationField)appendElement(ElementName.IDENTIFICATIONFIELD, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refIdentificationField(JDFIdentificationField refTarget)
      {
         refElement(refTarget);
      }
   }
}
