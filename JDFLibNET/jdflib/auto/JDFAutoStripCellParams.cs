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
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;

   public abstract class JDFAutoStripCellParams : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[19];
      static JDFAutoStripCellParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.BLEEDFACE, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.BLEEDSPINE, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.BLEEDHEAD, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.BLEEDFOOT, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.TRIMFACE, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.SPINE, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.TRIMHEAD, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.TRIMFOOT, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.FRONTOVERFOLD, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.BACKOVERFOLD, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[10] = new AtrInfoTable(AttributeName.MILLINGDEPTH, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[11] = new AtrInfoTable(AttributeName.CUTWIDTHHEAD, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[12] = new AtrInfoTable(AttributeName.CUTWIDTHFOOT, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[13] = new AtrInfoTable(AttributeName.TRIMSIZE, 0x33333311, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[14] = new AtrInfoTable(AttributeName.CREEP, 0x33333311, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[15] = new AtrInfoTable(AttributeName.SIDES, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumSides.getEnum(0), null);
         atrInfoTable[16] = new AtrInfoTable(AttributeName.MASKBLEED, 0x33333111, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[17] = new AtrInfoTable(AttributeName.MASKSEPARATION, 0x33333111, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[18] = new AtrInfoTable(AttributeName.MASK, 0x33333111, AttributeInfo.EnumAttributeType.enumeration, EnumMask.getEnum(0), null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoStripCellParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoStripCellParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoStripCellParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoStripCellParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoStripCellParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoStripCellParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoStripCellParams[  --> " + base.ToString() + " ]";
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

         public static readonly EnumSides OneSided = new EnumSides("OneSided");
         public static readonly EnumSides TwoSidedHeadToHead = new EnumSides("TwoSidedHeadToHead");
         public static readonly EnumSides TwoSidedHeadToFoot = new EnumSides("TwoSidedHeadToFoot");
      }



      ///        
      ///        <summary> * Enumeration strings for Mask </summary>
      ///        

      public class EnumMask : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumMask(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumMask getEnum(string enumName)
         {
            return (EnumMask)getEnum(typeof(EnumMask), enumName);
         }

         public static EnumMask getEnum(int enumValue)
         {
            return (EnumMask)getEnum(typeof(EnumMask), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumMask));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumMask));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumMask));
         }

         public static readonly EnumMask None = new EnumMask("None");
         public static readonly EnumMask TrimBox = new EnumMask("TrimBox");
         public static readonly EnumMask BleedBox = new EnumMask("BleedBox");
         public static readonly EnumMask SourceTrimBox = new EnumMask("SourceTrimBox");
         public static readonly EnumMask SourceBleedBox = new EnumMask("SourceBleedBox");
         public static readonly EnumMask PDL = new EnumMask("PDL");
         public static readonly EnumMask DieCut = new EnumMask("DieCut");
         public static readonly EnumMask DieBleed = new EnumMask("DieBleed");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute BleedFace
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BleedFace </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBleedFace(double @value)
      {
         setAttribute(AttributeName.BLEEDFACE, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute BleedFace </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getBleedFace()
      {
         return getRealAttribute(AttributeName.BLEEDFACE, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute BleedSpine
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BleedSpine </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBleedSpine(double @value)
      {
         setAttribute(AttributeName.BLEEDSPINE, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute BleedSpine </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getBleedSpine()
      {
         return getRealAttribute(AttributeName.BLEEDSPINE, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute BleedHead
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BleedHead </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBleedHead(double @value)
      {
         setAttribute(AttributeName.BLEEDHEAD, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute BleedHead </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getBleedHead()
      {
         return getRealAttribute(AttributeName.BLEEDHEAD, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute BleedFoot
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BleedFoot </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBleedFoot(double @value)
      {
         setAttribute(AttributeName.BLEEDFOOT, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute BleedFoot </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getBleedFoot()
      {
         return getRealAttribute(AttributeName.BLEEDFOOT, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TrimFace
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TrimFace </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTrimFace(double @value)
      {
         setAttribute(AttributeName.TRIMFACE, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute TrimFace </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getTrimFace()
      {
         return getRealAttribute(AttributeName.TRIMFACE, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Spine
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Spine </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSpine(double @value)
      {
         setAttribute(AttributeName.SPINE, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute Spine </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getSpine()
      {
         return getRealAttribute(AttributeName.SPINE, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TrimHead
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TrimHead </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTrimHead(double @value)
      {
         setAttribute(AttributeName.TRIMHEAD, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute TrimHead </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getTrimHead()
      {
         return getRealAttribute(AttributeName.TRIMHEAD, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TrimFoot
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TrimFoot </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTrimFoot(double @value)
      {
         setAttribute(AttributeName.TRIMFOOT, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute TrimFoot </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getTrimFoot()
      {
         return getRealAttribute(AttributeName.TRIMFOOT, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute FrontOverfold
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute FrontOverfold </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFrontOverfold(double @value)
      {
         setAttribute(AttributeName.FRONTOVERFOLD, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute FrontOverfold </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getFrontOverfold()
      {
         return getRealAttribute(AttributeName.FRONTOVERFOLD, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute BackOverfold
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BackOverfold </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBackOverfold(double @value)
      {
         setAttribute(AttributeName.BACKOVERFOLD, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute BackOverfold </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getBackOverfold()
      {
         return getRealAttribute(AttributeName.BACKOVERFOLD, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MillingDepth
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MillingDepth </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMillingDepth(double @value)
      {
         setAttribute(AttributeName.MILLINGDEPTH, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute MillingDepth </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getMillingDepth()
      {
         return getRealAttribute(AttributeName.MILLINGDEPTH, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute CutWidthHead
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CutWidthHead </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCutWidthHead(double @value)
      {
         setAttribute(AttributeName.CUTWIDTHHEAD, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute CutWidthHead </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getCutWidthHead()
      {
         return getRealAttribute(AttributeName.CUTWIDTHHEAD, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute CutWidthFoot
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CutWidthFoot </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCutWidthFoot(double @value)
      {
         setAttribute(AttributeName.CUTWIDTHFOOT, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute CutWidthFoot </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getCutWidthFoot()
      {
         return getRealAttribute(AttributeName.CUTWIDTHFOOT, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TrimSize
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TrimSize </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTrimSize(JDFXYPair @value)
      {
         setAttribute(AttributeName.TRIMSIZE, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute TrimSize </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getTrimSize()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.TRIMSIZE, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute Creep
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Creep </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCreep(JDFXYPair @value)
      {
         setAttribute(AttributeName.CREEP, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute Creep </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getCreep()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.CREEP, null, JDFConstants.EMPTYSTRING);
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


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MaskBleed
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MaskBleed </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMaskBleed(double @value)
      {
         setAttribute(AttributeName.MASKBLEED, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute MaskBleed </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getMaskBleed()
      {
         return getRealAttribute(AttributeName.MASKBLEED, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MaskSeparation
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MaskSeparation </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMaskSeparation(string @value)
      {
         setAttribute(AttributeName.MASKSEPARATION, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute MaskSeparation </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getMaskSeparation()
      {
         return getAttribute(AttributeName.MASKSEPARATION, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Mask
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Mask </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setMask(EnumMask enumVar)
      {
         setAttribute(AttributeName.MASK, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Mask </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumMask getMask()
      {
         return EnumMask.getEnum(getAttribute(AttributeName.MASK, null, null));
      }
   }
}
