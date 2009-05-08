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
   using JDFIntegerRangeList = org.cip4.jdflib.datatypes.JDFIntegerRangeList;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFApprovalParams = org.cip4.jdflib.resource.process.JDFApprovalParams;
   using JDFInk = org.cip4.jdflib.resource.process.prepress.JDFInk;

   public abstract class JDFAutoConventionalPrintingParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[18];
      static JDFAutoConventionalPrintingParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.DIRECTPROOF, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.DRYING, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumDrying.getEnum(0), null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.FIRSTSURFACE, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumFirstSurface.getEnum(0), null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.FOUNTAINSOLUTION, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumFountainSolution.getEnum(0), null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.MEDIALOCATION, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.MODULEAVAILABLEINDEX, 0x33333331, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.MODULEDRYING, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumModuleDrying.getEnum(0), null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.MODULEINDEX, 0x33333333, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.NONPRINTABLEMARGINBOTTOM, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.NONPRINTABLEMARGINLEFT, 0x33333111, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[10] = new AtrInfoTable(AttributeName.NONPRINTABLEMARGINRIGHT, 0x33333111, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[11] = new AtrInfoTable(AttributeName.NONPRINTABLEMARGINTOP, 0x33333111, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[12] = new AtrInfoTable(AttributeName.PERFECTINGMODULE, 0x33333331, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[13] = new AtrInfoTable(AttributeName.POWDER, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[14] = new AtrInfoTable(AttributeName.PRINTINGTYPE, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumPrintingType.getEnum(0), null);
         atrInfoTable[15] = new AtrInfoTable(AttributeName.SHEETLAY, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumSheetLay.getEnum(0), null);
         atrInfoTable[16] = new AtrInfoTable(AttributeName.SPEED, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[17] = new AtrInfoTable(AttributeName.WORKSTYLE, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumWorkStyle.getEnum(0), null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.INK, 0x33333333);
         elemInfoTable[1] = new ElemInfoTable(ElementName.APPROVALPARAMS, 0x66666611);
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
      ///     <summary> * Constructor for JDFAutoConventionalPrintingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoConventionalPrintingParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoConventionalPrintingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoConventionalPrintingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoConventionalPrintingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoConventionalPrintingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoConventionalPrintingParams[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for Drying </summary>
      ///        

      public class EnumDrying : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumDrying(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumDrying getEnum(string enumName)
         {
            return (EnumDrying)getEnum(typeof(EnumDrying), enumName);
         }

         public static EnumDrying getEnum(int enumValue)
         {
            return (EnumDrying)getEnum(typeof(EnumDrying), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumDrying));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumDrying));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumDrying));
         }

         public static readonly EnumDrying UV = new EnumDrying("UV");
         public static readonly EnumDrying Heatset = new EnumDrying("Heatset");
         public static readonly EnumDrying IR = new EnumDrying("IR");
         public static readonly EnumDrying On = new EnumDrying("On");
         public static readonly EnumDrying Off = new EnumDrying("Off");
      }



      ///        
      ///        <summary> * Enumeration strings for FirstSurface </summary>
      ///        

      public class EnumFirstSurface : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumFirstSurface(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumFirstSurface getEnum(string enumName)
         {
            return (EnumFirstSurface)getEnum(typeof(EnumFirstSurface), enumName);
         }

         public static EnumFirstSurface getEnum(int enumValue)
         {
            return (EnumFirstSurface)getEnum(typeof(EnumFirstSurface), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumFirstSurface));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumFirstSurface));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumFirstSurface));
         }

         public static readonly EnumFirstSurface Either = new EnumFirstSurface("Either");
         public static readonly EnumFirstSurface Front = new EnumFirstSurface("Front");
         public static readonly EnumFirstSurface Back = new EnumFirstSurface("Back");
      }



      ///        
      ///        <summary> * Enumeration strings for FountainSolution </summary>
      ///        

      public class EnumFountainSolution : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumFountainSolution(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumFountainSolution getEnum(string enumName)
         {
            return (EnumFountainSolution)getEnum(typeof(EnumFountainSolution), enumName);
         }

         public static EnumFountainSolution getEnum(int enumValue)
         {
            return (EnumFountainSolution)getEnum(typeof(EnumFountainSolution), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumFountainSolution));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumFountainSolution));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumFountainSolution));
         }

         public static readonly EnumFountainSolution On = new EnumFountainSolution("On");
         public static readonly EnumFountainSolution Off = new EnumFountainSolution("Off");
      }



      ///        
      ///        <summary> * Enumeration strings for ModuleDrying </summary>
      ///        

      public class EnumModuleDrying : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumModuleDrying(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumModuleDrying getEnum(string enumName)
         {
            return (EnumModuleDrying)getEnum(typeof(EnumModuleDrying), enumName);
         }

         public static EnumModuleDrying getEnum(int enumValue)
         {
            return (EnumModuleDrying)getEnum(typeof(EnumModuleDrying), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumModuleDrying));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumModuleDrying));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumModuleDrying));
         }

         public static readonly EnumModuleDrying UV = new EnumModuleDrying("UV");
         public static readonly EnumModuleDrying Heatset = new EnumModuleDrying("Heatset");
         public static readonly EnumModuleDrying IR = new EnumModuleDrying("IR");
         public static readonly EnumModuleDrying On = new EnumModuleDrying("On");
         public static readonly EnumModuleDrying Off = new EnumModuleDrying("Off");
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

         public static readonly EnumPrintingType ContinuousFed = new EnumPrintingType("ContinuousFed");
         public static readonly EnumPrintingType SheetFed = new EnumPrintingType("SheetFed");
         public static readonly EnumPrintingType WebFed = new EnumPrintingType("WebFed");
         public static readonly EnumPrintingType WebMultiple = new EnumPrintingType("WebMultiple");
         public static readonly EnumPrintingType WebSingle = new EnumPrintingType("WebSingle");
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
      }



      ///        
      ///        <summary> * Enumeration strings for WorkStyle </summary>
      ///        

      public class EnumWorkStyle : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumWorkStyle(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumWorkStyle getEnum(string enumName)
         {
            return (EnumWorkStyle)getEnum(typeof(EnumWorkStyle), enumName);
         }

         public static EnumWorkStyle getEnum(int enumValue)
         {
            return (EnumWorkStyle)getEnum(typeof(EnumWorkStyle), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumWorkStyle));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumWorkStyle));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumWorkStyle));
         }

         public static readonly EnumWorkStyle Simplex = new EnumWorkStyle("Simplex");
         public static readonly EnumWorkStyle WorkAndBack = new EnumWorkStyle("WorkAndBack");
         public static readonly EnumWorkStyle Perfecting = new EnumWorkStyle("Perfecting");
         public static readonly EnumWorkStyle WorkAndTurn = new EnumWorkStyle("WorkAndTurn");
         public static readonly EnumWorkStyle WorkAndTumble = new EnumWorkStyle("WorkAndTumble");
         public static readonly EnumWorkStyle WorkAndTwist = new EnumWorkStyle("WorkAndTwist");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute DirectProof
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DirectProof </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDirectProof(bool @value)
      {
         setAttribute(AttributeName.DIRECTPROOF, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute DirectProof </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getDirectProof()
      {
         return getBoolAttribute(AttributeName.DIRECTPROOF, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Drying
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Drying </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setDrying(EnumDrying enumVar)
      {
         setAttribute(AttributeName.DRYING, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Drying </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumDrying getDrying()
      {
         return EnumDrying.getEnum(getAttribute(AttributeName.DRYING, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute FirstSurface
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute FirstSurface </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setFirstSurface(EnumFirstSurface enumVar)
      {
         setAttribute(AttributeName.FIRSTSURFACE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute FirstSurface </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumFirstSurface getFirstSurface()
      {
         return EnumFirstSurface.getEnum(getAttribute(AttributeName.FIRSTSURFACE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute FountainSolution
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute FountainSolution </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setFountainSolution(EnumFountainSolution enumVar)
      {
         setAttribute(AttributeName.FOUNTAINSOLUTION, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute FountainSolution </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumFountainSolution getFountainSolution()
      {
         return EnumFountainSolution.getEnum(getAttribute(AttributeName.FOUNTAINSOLUTION, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MediaLocation
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MediaLocation </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMediaLocation(string @value)
      {
         setAttribute(AttributeName.MEDIALOCATION, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute MediaLocation </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getMediaLocation()
      {
         return getAttribute(AttributeName.MEDIALOCATION, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ModuleAvailableIndex
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ModuleAvailableIndex </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setModuleAvailableIndex(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.MODULEAVAILABLEINDEX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerRangeList attribute ModuleAvailableIndex </summary>
      ///          * <returns> JDFIntegerRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerRangeList </returns>
      ///          
      public virtual JDFIntegerRangeList getModuleAvailableIndex()
      {
         string strAttrName = "";
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.MODULEAVAILABLEINDEX, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute ModuleDrying
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute ModuleDrying </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setModuleDrying(EnumModuleDrying enumVar)
      {
         setAttribute(AttributeName.MODULEDRYING, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute ModuleDrying </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumModuleDrying getModuleDrying()
      {
         return EnumModuleDrying.getEnum(getAttribute(AttributeName.MODULEDRYING, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ModuleIndex
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ModuleIndex </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setModuleIndex(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.MODULEINDEX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerRangeList attribute ModuleIndex </summary>
      ///          * <returns> JDFIntegerRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerRangeList </returns>
      ///          
      public virtual JDFIntegerRangeList getModuleIndex()
      {
         string strAttrName = "";
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.MODULEINDEX, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute PerfectingModule
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PerfectingModule </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPerfectingModule(int @value)
      {
         setAttribute(AttributeName.PERFECTINGMODULE, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute PerfectingModule </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getPerfectingModule()
      {
         return getIntAttribute(AttributeName.PERFECTINGMODULE, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Powder
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Powder </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPowder(double @value)
      {
         setAttribute(AttributeName.POWDER, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute Powder </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getPowder()
      {
         return getRealAttribute(AttributeName.POWDER, null, 0.0);
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
      //        Methods for Attribute Speed
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Speed </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSpeed(double @value)
      {
         setAttribute(AttributeName.SPEED, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute Speed </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getSpeed()
      {
         return getRealAttribute(AttributeName.SPEED, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute WorkStyle
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute WorkStyle </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setWorkStyle(EnumWorkStyle enumVar)
      {
         setAttribute(AttributeName.WORKSTYLE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute WorkStyle </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumWorkStyle getWorkStyle()
      {
         return EnumWorkStyle.getEnum(getAttribute(AttributeName.WORKSTYLE, null, null));
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateInk
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFInk the element </returns>
      ///     
      public virtual JDFInk getCreateInk(int iSkip)
      {
         return (JDFInk)getCreateElement_KElement(ElementName.INK, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Ink </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFInk the element </returns>
      ///     * default is getInk(0)     
      public virtual JDFInk getInk(int iSkip)
      {
         return (JDFInk)getElement(ElementName.INK, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Ink from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFInk> </returns>
      ///     
      public virtual ICollection<JDFInk> getAllInk()
      {
         List<JDFInk> v = new List<JDFInk>();

         JDFInk kElem = (JDFInk)getFirstChildElement(ElementName.INK, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFInk)kElem.getNextSiblingElement(ElementName.INK, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Ink </summary>
      ///     
      public virtual JDFInk appendInk()
      {
         return (JDFInk)appendElement(ElementName.INK, null);
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
   }
}
