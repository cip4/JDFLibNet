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
   using JDFNumberList = org.cip4.jdflib.datatypes.JDFNumberList;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;

   public abstract class JDFAutoSideSewingParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[7];
      static JDFAutoSideSewingParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.NUMBEROFNEEDLES, 0x44444442, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.OFFSET, 0x44444442, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.NEEDLEPOSITIONS, 0x44444443, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.SEWINGPATTERN, 0x44444443, AttributeInfo.EnumAttributeType.enumeration, EnumSewingPattern.getEnum(0), null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.THREADMATERIAL, 0x44444443, AttributeInfo.EnumAttributeType.enumeration, EnumThreadMaterial.getEnum(0), null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.THREADTHICKNESS, 0x44444443, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.THREADBRAND, 0x44444443, AttributeInfo.EnumAttributeType.string_, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoSideSewingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoSideSewingParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoSideSewingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoSideSewingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoSideSewingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoSideSewingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoSideSewingParams[  --> " + base.ToString() + " ]";
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
      }



      ///        
      ///        <summary> * Enumeration strings for ThreadMaterial </summary>
      ///        

      public class EnumThreadMaterial : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumThreadMaterial(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumThreadMaterial getEnum(string enumName)
         {
            return (EnumThreadMaterial)getEnum(typeof(EnumThreadMaterial), enumName);
         }

         public static EnumThreadMaterial getEnum(int enumValue)
         {
            return (EnumThreadMaterial)getEnum(typeof(EnumThreadMaterial), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumThreadMaterial));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumThreadMaterial));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumThreadMaterial));
         }

         public static readonly EnumThreadMaterial Cotton = new EnumThreadMaterial("Cotton");
         public static readonly EnumThreadMaterial Nylon = new EnumThreadMaterial("Nylon");
         public static readonly EnumThreadMaterial Polyester = new EnumThreadMaterial("Polyester");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

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
      //        Methods for Attribute ThreadMaterial
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute ThreadMaterial </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setThreadMaterial(EnumThreadMaterial enumVar)
      {
         setAttribute(AttributeName.THREADMATERIAL, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute ThreadMaterial </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumThreadMaterial getThreadMaterial()
      {
         return EnumThreadMaterial.getEnum(getAttribute(AttributeName.THREADMATERIAL, null, null));
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
   }
}
