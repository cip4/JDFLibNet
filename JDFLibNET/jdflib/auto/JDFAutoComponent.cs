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
   using VString = org.cip4.jdflib.core.VString;
   using JDFIntegerRangeList = org.cip4.jdflib.datatypes.JDFIntegerRangeList;
   using JDFMatrix = org.cip4.jdflib.datatypes.JDFMatrix;
   using JDFRectangle = org.cip4.jdflib.datatypes.JDFRectangle;
   using JDFShape = org.cip4.jdflib.datatypes.JDFShape;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFBundle = org.cip4.jdflib.resource.JDFBundle;
   using JDFPageList = org.cip4.jdflib.resource.JDFPageList;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFAssembly = org.cip4.jdflib.resource.process.JDFAssembly;
   using JDFContact = org.cip4.jdflib.resource.process.JDFContact;
   using JDFDisjointing = org.cip4.jdflib.resource.process.JDFDisjointing;
   using JDFIdentificationField = org.cip4.jdflib.resource.process.JDFIdentificationField;
   using JDFLayout = org.cip4.jdflib.resource.process.JDFLayout;
   using JDFSheet = org.cip4.jdflib.resource.process.postpress.JDFSheet;

   public abstract class JDFAutoComponent : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[18];
      static JDFAutoComponent()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.COMPONENTTYPE, 0x22222222, AttributeInfo.EnumAttributeType.enumerations, EnumComponentType.getEnum(0), null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.ISWASTE, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.ASSEMBLYIDS, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.CARTONTOPFLAPS, 0x33333111, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.DIMENSIONS, 0x33333333, AttributeInfo.EnumAttributeType.shape, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.MAXHEAT, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.OVERFOLD, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.OVERFOLDSIDE, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumOverfoldSide.getEnum(0), null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.PAGELISTINDEX, 0x33333111, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.PRODUCTTYPE, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[10] = new AtrInfoTable(AttributeName.PRODUCTTYPEDETAILS, 0x33333111, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[11] = new AtrInfoTable(AttributeName.READERPAGECOUNT, 0x33333331, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[12] = new AtrInfoTable(AttributeName.SHEETPART, 0x33333333, AttributeInfo.EnumAttributeType.rectangle, null, null);
         atrInfoTable[13] = new AtrInfoTable(AttributeName.SOURCERIBBON, 0x44444333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[14] = new AtrInfoTable(AttributeName.SOURCESHEET, 0x44444333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[15] = new AtrInfoTable(AttributeName.SOURCEWEB, 0x44444333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[16] = new AtrInfoTable(AttributeName.SURFACECOUNT, 0x33333331, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[17] = new AtrInfoTable(AttributeName.TRANSFORMATION, 0x44444443, AttributeInfo.EnumAttributeType.matrix, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.ASSEMBLY, 0x66666111);
         elemInfoTable[1] = new ElemInfoTable(ElementName.BUNDLE, 0x66666661);
         elemInfoTable[2] = new ElemInfoTable(ElementName.DISJOINTING, 0x66666666);
         elemInfoTable[3] = new ElemInfoTable(ElementName.SHEET, 0x77777766);
         elemInfoTable[4] = new ElemInfoTable(ElementName.LAYOUT, 0x66666611);
         elemInfoTable[5] = new ElemInfoTable(ElementName.PAGELIST, 0x66666111);
         elemInfoTable[6] = new ElemInfoTable(ElementName.CONTACT, 0x33333333);
         elemInfoTable[7] = new ElemInfoTable(ElementName.IDENTIFICATIONFIELD, 0x33333333);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[8];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoComponent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoComponent(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoComponent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoComponent(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoComponent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoComponent(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoComponent[  --> " + base.ToString() + " ]";
      }


      public override bool init()
      {
         bool bRet = base.init();
         setResourceClass(JDFResource.EnumResourceClass.Quantity);
         return bRet;
      }


      public override EnumResourceClass getValidClass()
      {
         return JDFResource.EnumResourceClass.Quantity;
      }


      ///        
      ///        <summary> * Enumeration strings for ComponentType </summary>
      ///        

      public class EnumComponentType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumComponentType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumComponentType getEnum(string enumName)
         {
            return (EnumComponentType)getEnum(typeof(EnumComponentType), enumName);
         }

         public static EnumComponentType getEnum(int enumValue)
         {
            return (EnumComponentType)getEnum(typeof(EnumComponentType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumComponentType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumComponentType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumComponentType));
         }

         public static readonly EnumComponentType Block = new EnumComponentType("Block");
         public static readonly EnumComponentType Other = new EnumComponentType("Other");
         public static readonly EnumComponentType Ribbon = new EnumComponentType("Ribbon");
         public static readonly EnumComponentType Sheet = new EnumComponentType("Sheet");
         public static readonly EnumComponentType Web = new EnumComponentType("Web");
         public static readonly EnumComponentType FinalProduct = new EnumComponentType("FinalProduct");
         public static readonly EnumComponentType PartialProduct = new EnumComponentType("PartialProduct");
         public static readonly EnumComponentType Proof = new EnumComponentType("Proof");
      }



      ///        
      ///        <summary> * Enumeration strings for OverfoldSide </summary>
      ///        

      public class EnumOverfoldSide : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumOverfoldSide(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumOverfoldSide getEnum(string enumName)
         {
            return (EnumOverfoldSide)getEnum(typeof(EnumOverfoldSide), enumName);
         }

         public static EnumOverfoldSide getEnum(int enumValue)
         {
            return (EnumOverfoldSide)getEnum(typeof(EnumOverfoldSide), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumOverfoldSide));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumOverfoldSide));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumOverfoldSide));
         }

         public static readonly EnumOverfoldSide Front = new EnumOverfoldSide("Front");
         public static readonly EnumOverfoldSide Back = new EnumOverfoldSide("Back");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute ComponentType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5.2) set attribute ComponentType </summary>
      ///          * <param name="v"> vector of the enumeration values </param>
      ///          
      public virtual void setComponentType(List<ValuedEnum> v)
      {
         setEnumerationsAttribute(AttributeName.COMPONENTTYPE, v, null);
      }

      ///        
      ///          <summary> * (9.2) get ComponentType attribute ComponentType </summary>
      ///          * <returns> Vector of the enumerations </returns>
      ///          
      public virtual List<ValuedEnum> getComponentType()
      {
         return getEnumerationsAttribute(AttributeName.COMPONENTTYPE, null, EnumComponentType.getEnum(0), false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute IsWaste
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute IsWaste </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setIsWaste(bool @value)
      {
         setAttribute(AttributeName.ISWASTE, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute IsWaste </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getIsWaste()
      {
         return getBoolAttribute(AttributeName.ISWASTE, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute AssemblyIDs
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute AssemblyIDs </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAssemblyIDs(VString @value)
      {
         setAttribute(AttributeName.ASSEMBLYIDS, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute AssemblyIDs </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getAssemblyIDs()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.ASSEMBLYIDS, null, JDFConstants.EMPTYSTRING);
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute CartonTopFlaps
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CartonTopFlaps </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCartonTopFlaps(JDFXYPair @value)
      {
         setAttribute(AttributeName.CARTONTOPFLAPS, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute CartonTopFlaps </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getCartonTopFlaps()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.CARTONTOPFLAPS, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute Dimensions
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Dimensions </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDimensions(JDFShape @value)
      {
         setAttribute(AttributeName.DIMENSIONS, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFShape attribute Dimensions </summary>
      ///          * <returns> JDFShape the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFShape </returns>
      ///          
      public virtual JDFShape getDimensions()
      {
         string strAttrName = "";
         JDFShape nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.DIMENSIONS, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFShape(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MaxHeat
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MaxHeat </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMaxHeat(double @value)
      {
         setAttribute(AttributeName.MAXHEAT, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute MaxHeat </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getMaxHeat()
      {
         return getRealAttribute(AttributeName.MAXHEAT, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Overfold
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Overfold </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setOverfold(double @value)
      {
         setAttribute(AttributeName.OVERFOLD, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute Overfold </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getOverfold()
      {
         return getRealAttribute(AttributeName.OVERFOLD, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute OverfoldSide
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute OverfoldSide </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setOverfoldSide(EnumOverfoldSide enumVar)
      {
         setAttribute(AttributeName.OVERFOLDSIDE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute OverfoldSide </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumOverfoldSide getOverfoldSide()
      {
         return EnumOverfoldSide.getEnum(getAttribute(AttributeName.OVERFOLDSIDE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PageListIndex
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PageListIndex </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPageListIndex(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.PAGELISTINDEX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerRangeList attribute PageListIndex </summary>
      ///          * <returns> JDFIntegerRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerRangeList </returns>
      ///          
      public virtual JDFIntegerRangeList getPageListIndex()
      {
         string strAttrName = "";
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.PAGELISTINDEX, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFIntegerRangeList(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ProductType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ProductType </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setProductType(string @value)
      {
         setAttribute(AttributeName.PRODUCTTYPE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ProductType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getProductType()
      {
         return getAttribute(AttributeName.PRODUCTTYPE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ProductTypeDetails
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ProductTypeDetails </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setProductTypeDetails(string @value)
      {
         setAttribute(AttributeName.PRODUCTTYPEDETAILS, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ProductTypeDetails </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getProductTypeDetails()
      {
         return getAttribute(AttributeName.PRODUCTTYPEDETAILS, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ReaderPageCount
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ReaderPageCount </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setReaderPageCount(int @value)
      {
         setAttribute(AttributeName.READERPAGECOUNT, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute ReaderPageCount </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getReaderPageCount()
      {
         return getIntAttribute(AttributeName.READERPAGECOUNT, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SheetPart
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SheetPart </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSheetPart(JDFRectangle @value)
      {
         setAttribute(AttributeName.SHEETPART, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFRectangle attribute SheetPart </summary>
      ///          * <returns> JDFRectangle the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFRectangle </returns>
      ///          
      public virtual JDFRectangle getSheetPart()
      {
         string strAttrName = "";
         JDFRectangle nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.SHEETPART, null, JDFConstants.EMPTYSTRING);
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


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SourceRibbon
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SourceRibbon </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSourceRibbon(string @value)
      {
         setAttribute(AttributeName.SOURCERIBBON, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute SourceRibbon </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getSourceRibbon()
      {
         return getAttribute(AttributeName.SOURCERIBBON, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SourceSheet
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SourceSheet </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSourceSheet(string @value)
      {
         setAttribute(AttributeName.SOURCESHEET, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute SourceSheet </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getSourceSheet()
      {
         return getAttribute(AttributeName.SOURCESHEET, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SourceWeb
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SourceWeb </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSourceWeb(string @value)
      {
         setAttribute(AttributeName.SOURCEWEB, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute SourceWeb </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getSourceWeb()
      {
         return getAttribute(AttributeName.SOURCEWEB, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SurfaceCount
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SurfaceCount </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSurfaceCount(int @value)
      {
         setAttribute(AttributeName.SURFACECOUNT, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute SurfaceCount </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getSurfaceCount()
      {
         return getIntAttribute(AttributeName.SURFACECOUNT, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Transformation
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Transformation </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTransformation(JDFMatrix @value)
      {
         setAttribute(AttributeName.TRANSFORMATION, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFMatrix attribute Transformation </summary>
      ///          * <returns> JDFMatrix the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFMatrix </returns>
      ///          
      public virtual JDFMatrix getTransformation()
      {
         string strAttrName = "";
         JDFMatrix nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.TRANSFORMATION, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFMatrix(strAttrName);
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
      ///     <summary> * (24) const get element Assembly </summary>
      ///     * <returns> JDFAssembly the element </returns>
      ///     
      public virtual JDFAssembly getAssembly()
      {
         return (JDFAssembly)getElement(ElementName.ASSEMBLY, null, 0);
      }

      ///     <summary> (25) getCreateAssembly
      ///     *  </summary>
      ///     * <returns> JDFAssembly the element </returns>
      ///     
      public virtual JDFAssembly getCreateAssembly()
      {
         return (JDFAssembly)getCreateElement_KElement(ElementName.ASSEMBLY, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Assembly </summary>
      ///     
      public virtual JDFAssembly appendAssembly()
      {
         return (JDFAssembly)appendElementN(ElementName.ASSEMBLY, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refAssembly(JDFAssembly refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element Bundle </summary>
      ///     * <returns> JDFBundle the element </returns>
      ///     
      public virtual JDFBundle getBundle()
      {
         return (JDFBundle)getElement(ElementName.BUNDLE, null, 0);
      }

      ///     <summary> (25) getCreateBundle
      ///     *  </summary>
      ///     * <returns> JDFBundle the element </returns>
      ///     
      public virtual JDFBundle getCreateBundle()
      {
         return (JDFBundle)getCreateElement_KElement(ElementName.BUNDLE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Bundle </summary>
      ///     
      public virtual JDFBundle appendBundle()
      {
         return (JDFBundle)appendElementN(ElementName.BUNDLE, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refBundle(JDFBundle refTarget)
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
      ///     <summary> * (24) const get element Sheet </summary>
      ///     * <returns> JDFSheet the element </returns>
      ///     
      public virtual JDFSheet getSheet()
      {
         return (JDFSheet)getElement(ElementName.SHEET, null, 0);
      }

      ///     <summary> (25) getCreateSheet
      ///     *  </summary>
      ///     * <returns> JDFSheet the element </returns>
      ///     
      public virtual JDFSheet getCreateSheet()
      {
         return (JDFSheet)getCreateElement_KElement(ElementName.SHEET, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Sheet </summary>
      ///     
      public virtual JDFSheet appendSheet()
      {
         return (JDFSheet)appendElementN(ElementName.SHEET, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refSheet(JDFSheet refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element Layout </summary>
      ///     * <returns> JDFLayout the element </returns>
      ///     
      public virtual JDFLayout getLayout()
      {
         return (JDFLayout)getElement(ElementName.LAYOUT, null, 0);
      }

      ///     <summary> (25) getCreateLayout
      ///     *  </summary>
      ///     * <returns> JDFLayout the element </returns>
      ///     
      public virtual JDFLayout getCreateLayout()
      {
         return (JDFLayout)getCreateElement_KElement(ElementName.LAYOUT, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Layout </summary>
      ///     
      public virtual JDFLayout appendLayout()
      {
         return (JDFLayout)appendElementN(ElementName.LAYOUT, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refLayout(JDFLayout refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element PageList </summary>
      ///     * <returns> JDFPageList the element </returns>
      ///     
      public virtual JDFPageList getPageList()
      {
         return (JDFPageList)getElement(ElementName.PAGELIST, null, 0);
      }

      ///     <summary> (25) getCreatePageList
      ///     *  </summary>
      ///     * <returns> JDFPageList the element </returns>
      ///     
      public virtual JDFPageList getCreatePageList()
      {
         return (JDFPageList)getCreateElement_KElement(ElementName.PAGELIST, null, 0);
      }

      ///    
      ///     <summary> * (29) append element PageList </summary>
      ///     
      public virtual JDFPageList appendPageList()
      {
         return (JDFPageList)appendElementN(ElementName.PAGELIST, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refPageList(JDFPageList refTarget)
      {
         refElement(refTarget);
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
