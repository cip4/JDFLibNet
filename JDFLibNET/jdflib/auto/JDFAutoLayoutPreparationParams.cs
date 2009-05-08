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
   using JDFIntegerList = org.cip4.jdflib.datatypes.JDFIntegerList;
   using JDFIntegerRange = org.cip4.jdflib.datatypes.JDFIntegerRange;
   using JDFRectangle = org.cip4.jdflib.datatypes.JDFRectangle;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFDeviceMark = org.cip4.jdflib.resource.JDFDeviceMark;
   using JDFFitPolicy = org.cip4.jdflib.resource.JDFFitPolicy;
   using JDFImageShift = org.cip4.jdflib.resource.JDFImageShift;
   using JDFJobField = org.cip4.jdflib.resource.JDFJobField;
   using JDFPageCell = org.cip4.jdflib.resource.JDFPageCell;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFExternalImpositionTemplate = org.cip4.jdflib.resource.process.JDFExternalImpositionTemplate;
   using JDFInsertSheet = org.cip4.jdflib.resource.process.JDFInsertSheet;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;

   public abstract class JDFAutoLayoutPreparationParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[23];
      static JDFAutoLayoutPreparationParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.FINISHINGORDER, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumFinishingOrder.getEnum(0), "GatherFold");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.FOLDCATALOGORIENTATION, 0x33333111, AttributeInfo.EnumAttributeType.enumeration, EnumFoldCatalogOrientation.getEnum(0), "Rotate0");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.PAGEDISTRIBUTIONSCHEME, 0x33333331, AttributeInfo.EnumAttributeType.NMTOKEN, null, "Sequential");
         atrInfoTable[3] = new AtrInfoTable(AttributeName.PAGEORDER, 0x33333331, AttributeInfo.EnumAttributeType.NMTOKEN, null, "Reader");
         atrInfoTable[4] = new AtrInfoTable(AttributeName.ROTATE, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumRotate.getEnum(0), "Rotate0");
         atrInfoTable[5] = new AtrInfoTable(AttributeName.SIDES, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumSides.getEnum(0), "OneSidedFront");
         atrInfoTable[6] = new AtrInfoTable(AttributeName.BINDINGEDGE, 0x33333111, AttributeInfo.EnumAttributeType.enumeration, EnumBindingEdge.getEnum(0), null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.BACKMARKLIST, 0x33333331, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.CREEPVALUE, 0x33333331, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.FOLDCATALOG, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[10] = new AtrInfoTable(AttributeName.FRONTMARKLIST, 0x33333331, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable[11] = new AtrInfoTable(AttributeName.GUTTER, 0x33333331, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[12] = new AtrInfoTable(AttributeName.GUTTERMINIMUMLIMIT, 0x33333111, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[13] = new AtrInfoTable(AttributeName.HORIZONTALCREEP, 0x33333331, AttributeInfo.EnumAttributeType.IntegerList, null, null);
         atrInfoTable[14] = new AtrInfoTable(AttributeName.IMPLICITGUTTER, 0x33333111, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[15] = new AtrInfoTable(AttributeName.IMPLICITGUTTERMINIMUMLIMIT, 0x33333111, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[16] = new AtrInfoTable(AttributeName.NUMBERUP, 0x33333331, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[17] = new AtrInfoTable(AttributeName.PRESENTATIONDIRECTION, 0x33333331, AttributeInfo.EnumAttributeType.Any, null, null);
         atrInfoTable[18] = new AtrInfoTable(AttributeName.STACKDEPTH, 0x33333331, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[19] = new AtrInfoTable(AttributeName.STEPDOCS, 0x33333331, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[20] = new AtrInfoTable(AttributeName.STEPREPEAT, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[21] = new AtrInfoTable(AttributeName.SURFACECONTENTSBOX, 0x33333331, AttributeInfo.EnumAttributeType.rectangle, null, null);
         atrInfoTable[22] = new AtrInfoTable(AttributeName.VERTICALCREEP, 0x33333331, AttributeInfo.EnumAttributeType.IntegerList, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.IMAGESHIFT, 0x66666661);
         elemInfoTable[1] = new ElemInfoTable(ElementName.INSERTSHEET, 0x33333331);
         elemInfoTable[2] = new ElemInfoTable(ElementName.DEVICEMARK, 0x66666661);
         elemInfoTable[3] = new ElemInfoTable(ElementName.EXTERNALIMPOSITIONTEMPLATE, 0x66666111);
         elemInfoTable[4] = new ElemInfoTable(ElementName.FITPOLICY, 0x66666661);
         elemInfoTable[5] = new ElemInfoTable(ElementName.JOBFIELD, 0x33333331);
         elemInfoTable[6] = new ElemInfoTable(ElementName.MEDIA, 0x66666661);
         elemInfoTable[7] = new ElemInfoTable(ElementName.PAGECELL, 0x66666661);
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
      ///     <summary> * Constructor for JDFAutoLayoutPreparationParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoLayoutPreparationParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoLayoutPreparationParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoLayoutPreparationParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoLayoutPreparationParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoLayoutPreparationParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoLayoutPreparationParams[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for FinishingOrder </summary>
      ///        

      public class EnumFinishingOrder : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumFinishingOrder(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumFinishingOrder getEnum(string enumName)
         {
            return (EnumFinishingOrder)getEnum(typeof(EnumFinishingOrder), enumName);
         }

         public static EnumFinishingOrder getEnum(int enumValue)
         {
            return (EnumFinishingOrder)getEnum(typeof(EnumFinishingOrder), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumFinishingOrder));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumFinishingOrder));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumFinishingOrder));
         }

         public static readonly EnumFinishingOrder FoldGather = new EnumFinishingOrder("FoldGather");
         public static readonly EnumFinishingOrder FoldCollect = new EnumFinishingOrder("FoldCollect");
         public static readonly EnumFinishingOrder Gather = new EnumFinishingOrder("Gather");
         public static readonly EnumFinishingOrder GatherFold = new EnumFinishingOrder("GatherFold");
      }



      ///        
      ///        <summary> * Enumeration strings for FoldCatalogOrientation </summary>
      ///        

      public class EnumFoldCatalogOrientation : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumFoldCatalogOrientation(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumFoldCatalogOrientation getEnum(string enumName)
         {
            return (EnumFoldCatalogOrientation)getEnum(typeof(EnumFoldCatalogOrientation), enumName);
         }

         public static EnumFoldCatalogOrientation getEnum(int enumValue)
         {
            return (EnumFoldCatalogOrientation)getEnum(typeof(EnumFoldCatalogOrientation), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumFoldCatalogOrientation));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumFoldCatalogOrientation));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumFoldCatalogOrientation));
         }

         public static readonly EnumFoldCatalogOrientation Rotate0 = new EnumFoldCatalogOrientation("Rotate0");
         public static readonly EnumFoldCatalogOrientation Rotate90 = new EnumFoldCatalogOrientation("Rotate90");
         public static readonly EnumFoldCatalogOrientation Rotate180 = new EnumFoldCatalogOrientation("Rotate180");
         public static readonly EnumFoldCatalogOrientation Rotate270 = new EnumFoldCatalogOrientation("Rotate270");
         public static readonly EnumFoldCatalogOrientation Flip0 = new EnumFoldCatalogOrientation("Flip0");
         public static readonly EnumFoldCatalogOrientation Flip90 = new EnumFoldCatalogOrientation("Flip90");
         public static readonly EnumFoldCatalogOrientation Flip180 = new EnumFoldCatalogOrientation("Flip180");
         public static readonly EnumFoldCatalogOrientation Flip270 = new EnumFoldCatalogOrientation("Flip270");
      }



      ///        
      ///        <summary> * Enumeration strings for Rotate </summary>
      ///        

      public class EnumRotate : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumRotate(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumRotate getEnum(string enumName)
         {
            return (EnumRotate)getEnum(typeof(EnumRotate), enumName);
         }

         public static EnumRotate getEnum(int enumValue)
         {
            return (EnumRotate)getEnum(typeof(EnumRotate), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumRotate));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumRotate));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumRotate));
         }

         public static readonly EnumRotate Rotate0 = new EnumRotate("Rotate0");
         public static readonly EnumRotate Rotate90 = new EnumRotate("Rotate90");
         public static readonly EnumRotate Rotate180 = new EnumRotate("Rotate180");
         public static readonly EnumRotate Rotate270 = new EnumRotate("Rotate270");
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
      ///        <summary> * Enumeration strings for BindingEdge </summary>
      ///        

      public class EnumBindingEdge : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumBindingEdge(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumBindingEdge getEnum(string enumName)
         {
            return (EnumBindingEdge)getEnum(typeof(EnumBindingEdge), enumName);
         }

         public static EnumBindingEdge getEnum(int enumValue)
         {
            return (EnumBindingEdge)getEnum(typeof(EnumBindingEdge), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumBindingEdge));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumBindingEdge));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumBindingEdge));
         }

         public static readonly EnumBindingEdge Left = new EnumBindingEdge("Left");
         public static readonly EnumBindingEdge Right = new EnumBindingEdge("Right");
         public static readonly EnumBindingEdge Top = new EnumBindingEdge("Top");
         public static readonly EnumBindingEdge Bottom = new EnumBindingEdge("Bottom");
         public static readonly EnumBindingEdge None = new EnumBindingEdge("None");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute FinishingOrder
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute FinishingOrder </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setFinishingOrder(EnumFinishingOrder enumVar)
      {
         setAttribute(AttributeName.FINISHINGORDER, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute FinishingOrder </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumFinishingOrder getFinishingOrder()
      {
         return EnumFinishingOrder.getEnum(getAttribute(AttributeName.FINISHINGORDER, null, "GatherFold"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute FoldCatalogOrientation
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute FoldCatalogOrientation </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setFoldCatalogOrientation(EnumFoldCatalogOrientation enumVar)
      {
         setAttribute(AttributeName.FOLDCATALOGORIENTATION, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute FoldCatalogOrientation </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumFoldCatalogOrientation getFoldCatalogOrientation()
      {
         return EnumFoldCatalogOrientation.getEnum(getAttribute(AttributeName.FOLDCATALOGORIENTATION, null, "Rotate0"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PageDistributionScheme
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PageDistributionScheme </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPageDistributionScheme(string @value)
      {
         setAttribute(AttributeName.PAGEDISTRIBUTIONSCHEME, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute PageDistributionScheme </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getPageDistributionScheme()
      {
         return getAttribute(AttributeName.PAGEDISTRIBUTIONSCHEME, null, "Sequential");
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PageOrder
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PageOrder </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPageOrder(string @value)
      {
         setAttribute(AttributeName.PAGEORDER, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute PageOrder </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getPageOrder()
      {
         return getAttribute(AttributeName.PAGEORDER, null, "Reader");
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Rotate
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Rotate </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setRotate(EnumRotate enumVar)
      {
         setAttribute(AttributeName.ROTATE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Rotate </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumRotate getRotate()
      {
         return EnumRotate.getEnum(getAttribute(AttributeName.ROTATE, null, "Rotate0"));
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
      //        Methods for Attribute BindingEdge
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute BindingEdge </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setBindingEdge(EnumBindingEdge enumVar)
      {
         setAttribute(AttributeName.BINDINGEDGE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute BindingEdge </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumBindingEdge getBindingEdge()
      {
         return EnumBindingEdge.getEnum(getAttribute(AttributeName.BINDINGEDGE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute BackMarkList
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BackMarkList </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBackMarkList(VString @value)
      {
         setAttribute(AttributeName.BACKMARKLIST, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute BackMarkList </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getBackMarkList()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.BACKMARKLIST, null, JDFConstants.EMPTYSTRING);
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute CreepValue
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CreepValue </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCreepValue(JDFXYPair @value)
      {
         setAttribute(AttributeName.CREEPVALUE, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute CreepValue </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getCreepValue()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.CREEPVALUE, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute FoldCatalog
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute FoldCatalog </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFoldCatalog(string @value)
      {
         setAttribute(AttributeName.FOLDCATALOG, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute FoldCatalog </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getFoldCatalog()
      {
         return getAttribute(AttributeName.FOLDCATALOG, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute FrontMarkList
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute FrontMarkList </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFrontMarkList(VString @value)
      {
         setAttribute(AttributeName.FRONTMARKLIST, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute FrontMarkList </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getFrontMarkList()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.FRONTMARKLIST, null, JDFConstants.EMPTYSTRING);
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Gutter
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Gutter </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setGutter(JDFXYPair @value)
      {
         setAttribute(AttributeName.GUTTER, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute Gutter </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getGutter()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.GUTTER, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute GutterMinimumLimit
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute GutterMinimumLimit </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setGutterMinimumLimit(JDFXYPair @value)
      {
         setAttribute(AttributeName.GUTTERMINIMUMLIMIT, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute GutterMinimumLimit </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getGutterMinimumLimit()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.GUTTERMINIMUMLIMIT, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute HorizontalCreep
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute HorizontalCreep </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setHorizontalCreep(JDFIntegerList @value)
      {
         setAttribute(AttributeName.HORIZONTALCREEP, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerList attribute HorizontalCreep </summary>
      ///          * <returns> JDFIntegerList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerList </returns>
      ///          
      public virtual JDFIntegerList getHorizontalCreep()
      {
         string strAttrName = "";
         JDFIntegerList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.HORIZONTALCREEP, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFIntegerList(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ImplicitGutter
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ImplicitGutter </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setImplicitGutter(JDFXYPair @value)
      {
         setAttribute(AttributeName.IMPLICITGUTTER, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute ImplicitGutter </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getImplicitGutter()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.IMPLICITGUTTER, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute ImplicitGutterMinimumLimit
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ImplicitGutterMinimumLimit </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setImplicitGutterMinimumLimit(JDFXYPair @value)
      {
         setAttribute(AttributeName.IMPLICITGUTTERMINIMUMLIMIT, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute ImplicitGutterMinimumLimit </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getImplicitGutterMinimumLimit()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.IMPLICITGUTTERMINIMUMLIMIT, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute NumberUp
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute NumberUp </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setNumberUp(JDFXYPair @value)
      {
         setAttribute(AttributeName.NUMBERUP, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute NumberUp </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getNumberUp()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.NUMBERUP, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute PresentationDirection
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PresentationDirection </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPresentationDirection(string @value)
      {
         setAttribute(AttributeName.PRESENTATIONDIRECTION, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute PresentationDirection </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getPresentationDirection()
      {
         return getAttribute(AttributeName.PRESENTATIONDIRECTION, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute StackDepth
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute StackDepth </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setStackDepth(int @value)
      {
         setAttribute(AttributeName.STACKDEPTH, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute StackDepth </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getStackDepth()
      {
         return getIntAttribute(AttributeName.STACKDEPTH, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute StepDocs
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute StepDocs </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setStepDocs(JDFXYPair @value)
      {
         setAttribute(AttributeName.STEPDOCS, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute StepDocs </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getStepDocs()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.STEPDOCS, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute StepRepeat
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute StepRepeat </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setStepRepeat(JDFIntegerRange @value)
      {
         setAttribute(AttributeName.STEPREPEAT, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerRange attribute StepRepeat </summary>
      ///          * <returns> JDFIntegerRange the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerRange </returns>
      ///          
      public virtual JDFIntegerRange getStepRepeat()
      {
         string strAttrName = "";
         JDFIntegerRange nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.STEPREPEAT, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFIntegerRange(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SurfaceContentsBox
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SurfaceContentsBox </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSurfaceContentsBox(JDFRectangle @value)
      {
         setAttribute(AttributeName.SURFACECONTENTSBOX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFRectangle attribute SurfaceContentsBox </summary>
      ///          * <returns> JDFRectangle the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFRectangle </returns>
      ///          
      public virtual JDFRectangle getSurfaceContentsBox()
      {
         string strAttrName = "";
         JDFRectangle nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.SURFACECONTENTSBOX, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute VerticalCreep
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute VerticalCreep </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setVerticalCreep(JDFIntegerList @value)
      {
         setAttribute(AttributeName.VERTICALCREEP, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerList attribute VerticalCreep </summary>
      ///          * <returns> JDFIntegerList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerList </returns>
      ///          
      public virtual JDFIntegerList getVerticalCreep()
      {
         string strAttrName = "";
         JDFIntegerList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.VERTICALCREEP, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFIntegerList(strAttrName);
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
      ///     <summary> * (24) const get element ImageShift </summary>
      ///     * <returns> JDFImageShift the element </returns>
      ///     
      public virtual JDFImageShift getImageShift()
      {
         return (JDFImageShift)getElement(ElementName.IMAGESHIFT, null, 0);
      }

      ///     <summary> (25) getCreateImageShift
      ///     *  </summary>
      ///     * <returns> JDFImageShift the element </returns>
      ///     
      public virtual JDFImageShift getCreateImageShift()
      {
         return (JDFImageShift)getCreateElement_KElement(ElementName.IMAGESHIFT, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ImageShift </summary>
      ///     
      public virtual JDFImageShift appendImageShift()
      {
         return (JDFImageShift)appendElementN(ElementName.IMAGESHIFT, 1, null);
      }

      ///     <summary> (26) getCreateInsertSheet
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFInsertSheet the element </returns>
      ///     
      public virtual JDFInsertSheet getCreateInsertSheet(int iSkip)
      {
         return (JDFInsertSheet)getCreateElement_KElement(ElementName.INSERTSHEET, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element InsertSheet </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFInsertSheet the element </returns>
      ///     * default is getInsertSheet(0)     
      public virtual JDFInsertSheet getInsertSheet(int iSkip)
      {
         return (JDFInsertSheet)getElement(ElementName.INSERTSHEET, null, iSkip);
      }

      ///    
      ///     <summary> * Get all InsertSheet from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFInsertSheet> </returns>
      ///     
      public virtual ICollection<JDFInsertSheet> getAllInsertSheet()
      {
         List<JDFInsertSheet> v = new List<JDFInsertSheet>();

         JDFInsertSheet kElem = (JDFInsertSheet)getFirstChildElement(ElementName.INSERTSHEET, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFInsertSheet)kElem.getNextSiblingElement(ElementName.INSERTSHEET, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element InsertSheet </summary>
      ///     
      public virtual JDFInsertSheet appendInsertSheet()
      {
         return (JDFInsertSheet)appendElement(ElementName.INSERTSHEET, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refInsertSheet(JDFInsertSheet refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element DeviceMark </summary>
      ///     * <returns> JDFDeviceMark the element </returns>
      ///     
      public virtual JDFDeviceMark getDeviceMark()
      {
         return (JDFDeviceMark)getElement(ElementName.DEVICEMARK, null, 0);
      }

      ///     <summary> (25) getCreateDeviceMark
      ///     *  </summary>
      ///     * <returns> JDFDeviceMark the element </returns>
      ///     
      public virtual JDFDeviceMark getCreateDeviceMark()
      {
         return (JDFDeviceMark)getCreateElement_KElement(ElementName.DEVICEMARK, null, 0);
      }

      ///    
      ///     <summary> * (29) append element DeviceMark </summary>
      ///     
      public virtual JDFDeviceMark appendDeviceMark()
      {
         return (JDFDeviceMark)appendElementN(ElementName.DEVICEMARK, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refDeviceMark(JDFDeviceMark refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element ExternalImpositionTemplate </summary>
      ///     * <returns> JDFExternalImpositionTemplate the element </returns>
      ///     
      public virtual JDFExternalImpositionTemplate getExternalImpositionTemplate()
      {
         return (JDFExternalImpositionTemplate)getElement(ElementName.EXTERNALIMPOSITIONTEMPLATE, null, 0);
      }

      ///     <summary> (25) getCreateExternalImpositionTemplate
      ///     *  </summary>
      ///     * <returns> JDFExternalImpositionTemplate the element </returns>
      ///     
      public virtual JDFExternalImpositionTemplate getCreateExternalImpositionTemplate()
      {
         return (JDFExternalImpositionTemplate)getCreateElement_KElement(ElementName.EXTERNALIMPOSITIONTEMPLATE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ExternalImpositionTemplate </summary>
      ///     
      public virtual JDFExternalImpositionTemplate appendExternalImpositionTemplate()
      {
         return (JDFExternalImpositionTemplate)appendElementN(ElementName.EXTERNALIMPOSITIONTEMPLATE, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refExternalImpositionTemplate(JDFExternalImpositionTemplate refTarget)
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

      ///     <summary> (26) getCreateJobField
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFJobField the element </returns>
      ///     
      public virtual JDFJobField getCreateJobField(int iSkip)
      {
         return (JDFJobField)getCreateElement_KElement(ElementName.JOBFIELD, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element JobField </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFJobField the element </returns>
      ///     * default is getJobField(0)     
      public virtual JDFJobField getJobField(int iSkip)
      {
         return (JDFJobField)getElement(ElementName.JOBFIELD, null, iSkip);
      }

      ///    
      ///     <summary> * Get all JobField from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFJobField> </returns>
      ///     
      public virtual ICollection<JDFJobField> getAllJobField()
      {
         List<JDFJobField> v = new List<JDFJobField>();

         JDFJobField kElem = (JDFJobField)getFirstChildElement(ElementName.JOBFIELD, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFJobField)kElem.getNextSiblingElement(ElementName.JOBFIELD, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element JobField </summary>
      ///     
      public virtual JDFJobField appendJobField()
      {
         return (JDFJobField)appendElement(ElementName.JOBFIELD, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refJobField(JDFJobField refTarget)
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
      ///     <summary> * (24) const get element PageCell </summary>
      ///     * <returns> JDFPageCell the element </returns>
      ///     
      public virtual JDFPageCell getPageCell()
      {
         return (JDFPageCell)getElement(ElementName.PAGECELL, null, 0);
      }

      ///     <summary> (25) getCreatePageCell
      ///     *  </summary>
      ///     * <returns> JDFPageCell the element </returns>
      ///     
      public virtual JDFPageCell getCreatePageCell()
      {
         return (JDFPageCell)getCreateElement_KElement(ElementName.PAGECELL, null, 0);
      }

      ///    
      ///     <summary> * (29) append element PageCell </summary>
      ///     
      public virtual JDFPageCell appendPageCell()
      {
         return (JDFPageCell)appendElementN(ElementName.PAGECELL, 1, null);
      }
   }
}
