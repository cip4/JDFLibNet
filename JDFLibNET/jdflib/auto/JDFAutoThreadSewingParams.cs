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
   using JDFIntegerList = org.cip4.jdflib.datatypes.JDFIntegerList;
   using JDFNumberList = org.cip4.jdflib.datatypes.JDFNumberList;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFGlueLine = org.cip4.jdflib.resource.process.postpress.JDFGlueLine;

   public abstract class JDFAutoThreadSewingParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[11];
      static JDFAutoThreadSewingParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.BLINDSTITCH, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.CASTINGMATERIAL, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumCastingMaterial.getEnum(0), null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.COREMATERIAL, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumCoreMaterial.getEnum(0), null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.GLUELINEREFSHEETS, 0x33333333, AttributeInfo.EnumAttributeType.IntegerList, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.OFFSET, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.NEEDLEPOSITIONS, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.NUMBEROFNEEDLES, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.SEALING, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.SEWINGPATTERN, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumSewingPattern.getEnum(0), null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.THREADTHICKNESS, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[10] = new AtrInfoTable(AttributeName.THREADBRAND, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.GLUELINE, 0x33333333);
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
      ///     <summary> * Constructor for JDFAutoThreadSewingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoThreadSewingParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoThreadSewingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoThreadSewingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoThreadSewingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoThreadSewingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoThreadSewingParams[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for CastingMaterial </summary>
      ///        

      public class EnumCastingMaterial : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumCastingMaterial(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumCastingMaterial getEnum(string enumName)
         {
            return (EnumCastingMaterial)getEnum(typeof(EnumCastingMaterial), enumName);
         }

         public static EnumCastingMaterial getEnum(int enumValue)
         {
            return (EnumCastingMaterial)getEnum(typeof(EnumCastingMaterial), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumCastingMaterial));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumCastingMaterial));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumCastingMaterial));
         }

         public static readonly EnumCastingMaterial Cotton = new EnumCastingMaterial("Cotton");
         public static readonly EnumCastingMaterial Nylon = new EnumCastingMaterial("Nylon");
         public static readonly EnumCastingMaterial Polyester = new EnumCastingMaterial("Polyester");
      }



      ///        
      ///        <summary> * Enumeration strings for CoreMaterial </summary>
      ///        

      public class EnumCoreMaterial : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumCoreMaterial(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumCoreMaterial getEnum(string enumName)
         {
            return (EnumCoreMaterial)getEnum(typeof(EnumCoreMaterial), enumName);
         }

         public static EnumCoreMaterial getEnum(int enumValue)
         {
            return (EnumCoreMaterial)getEnum(typeof(EnumCoreMaterial), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumCoreMaterial));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumCoreMaterial));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumCoreMaterial));
         }

         public static readonly EnumCoreMaterial Cotton = new EnumCoreMaterial("Cotton");
         public static readonly EnumCoreMaterial Nylon = new EnumCoreMaterial("Nylon");
         public static readonly EnumCoreMaterial Polyester = new EnumCoreMaterial("Polyester");
      }



      ///        
      ///        <summary> * Enumeration strings for SewingPattern </summary>
      ///        

      public class EnumSewingPattern : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumSewingPattern(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumSewingPattern getEnum(string enumName)
         {
            return (EnumSewingPattern)getEnum(typeof(EnumSewingPattern), enumName);
         }

         public static EnumSewingPattern getEnum(int enumValue)
         {
            return (EnumSewingPattern)getEnum(typeof(EnumSewingPattern), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumSewingPattern));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumSewingPattern));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumSewingPattern));
         }

         public static readonly EnumSewingPattern Normal = new EnumSewingPattern("Normal");
         public static readonly EnumSewingPattern Staggered = new EnumSewingPattern("Staggered");
         public static readonly EnumSewingPattern CombinedStaggered = new EnumSewingPattern("CombinedStaggered");
         public static readonly EnumSewingPattern Side = new EnumSewingPattern("Side");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute BlindStitch
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BlindStitch </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBlindStitch(bool @value)
      {
         setAttribute(AttributeName.BLINDSTITCH, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute BlindStitch </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getBlindStitch()
      {
         return getBoolAttribute(AttributeName.BLINDSTITCH, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute CastingMaterial
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute CastingMaterial </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setCastingMaterial(EnumCastingMaterial enumVar)
      {
         setAttribute(AttributeName.CASTINGMATERIAL, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute CastingMaterial </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumCastingMaterial getCastingMaterial()
      {
         return EnumCastingMaterial.getEnum(getAttribute(AttributeName.CASTINGMATERIAL, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute CoreMaterial
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute CoreMaterial </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setCoreMaterial(EnumCoreMaterial enumVar)
      {
         setAttribute(AttributeName.COREMATERIAL, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute CoreMaterial </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumCoreMaterial getCoreMaterial()
      {
         return EnumCoreMaterial.getEnum(getAttribute(AttributeName.COREMATERIAL, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute GlueLineRefSheets
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute GlueLineRefSheets </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setGlueLineRefSheets(JDFIntegerList @value)
      {
         setAttribute(AttributeName.GLUELINEREFSHEETS, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerList attribute GlueLineRefSheets </summary>
      ///          * <returns> JDFIntegerList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerList </returns>
      ///          
      public virtual JDFIntegerList getGlueLineRefSheets()
      {
         string strAttrName = "";
         JDFIntegerList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.GLUELINEREFSHEETS, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute Offset
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Offset </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setOffset(double @value)
      {
         setAttribute(AttributeName.OFFSET, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute Offset </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getOffset()
      {
         return getRealAttribute(AttributeName.OFFSET, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute NeedlePositions
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute NeedlePositions </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setNeedlePositions(JDFNumberList @value)
      {
         setAttribute(AttributeName.NEEDLEPOSITIONS, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFNumberList attribute NeedlePositions </summary>
      ///          * <returns> JDFNumberList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFNumberList </returns>
      ///          
      public virtual JDFNumberList getNeedlePositions()
      {
         string strAttrName = "";
         JDFNumberList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.NEEDLEPOSITIONS, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFNumberList(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute NumberOfNeedles
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute NumberOfNeedles </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setNumberOfNeedles(int @value)
      {
         setAttribute(AttributeName.NUMBEROFNEEDLES, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute NumberOfNeedles </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getNumberOfNeedles()
      {
         return getIntAttribute(AttributeName.NUMBEROFNEEDLES, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Sealing
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Sealing </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSealing(bool @value)
      {
         setAttribute(AttributeName.SEALING, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute Sealing </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getSealing()
      {
         return getBoolAttribute(AttributeName.SEALING, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SewingPattern
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute SewingPattern </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setSewingPattern(EnumSewingPattern enumVar)
      {
         setAttribute(AttributeName.SEWINGPATTERN, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute SewingPattern </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumSewingPattern getSewingPattern()
      {
         return EnumSewingPattern.getEnum(getAttribute(AttributeName.SEWINGPATTERN, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ThreadThickness
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ThreadThickness </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setThreadThickness(double @value)
      {
         setAttribute(AttributeName.THREADTHICKNESS, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute ThreadThickness </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getThreadThickness()
      {
         return getRealAttribute(AttributeName.THREADTHICKNESS, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ThreadBrand
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ThreadBrand </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setThreadBrand(string @value)
      {
         setAttribute(AttributeName.THREADBRAND, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ThreadBrand </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getThreadBrand()
      {
         return getAttribute(AttributeName.THREADBRAND, null, JDFConstants.EMPTYSTRING);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateGlueLine
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFGlueLine the element </returns>
      ///     
      public virtual JDFGlueLine getCreateGlueLine(int iSkip)
      {
         return (JDFGlueLine)getCreateElement_KElement(ElementName.GLUELINE, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element GlueLine </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFGlueLine the element </returns>
      ///     * default is getGlueLine(0)     
      public virtual JDFGlueLine getGlueLine(int iSkip)
      {
         return (JDFGlueLine)getElement(ElementName.GLUELINE, null, iSkip);
      }

      ///    
      ///     <summary> * Get all GlueLine from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFGlueLine> </returns>
      ///     
      public virtual ICollection<JDFGlueLine> getAllGlueLine()
      {
         List<JDFGlueLine> v = new List<JDFGlueLine>();

         JDFGlueLine kElem = (JDFGlueLine)getFirstChildElement(ElementName.GLUELINE, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFGlueLine)kElem.getNextSiblingElement(ElementName.GLUELINE, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element GlueLine </summary>
      ///     
      public virtual JDFGlueLine appendGlueLine()
      {
         return (JDFGlueLine)appendElement(ElementName.GLUELINE, null);
      }
   }
}
