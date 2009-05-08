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
   using JDFRectangle = org.cip4.jdflib.datatypes.JDFRectangle;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;

   public abstract class JDFAutoLaminatingParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[7];
      static JDFAutoLaminatingParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.LAMINATINGBOX, 0x22222221, AttributeInfo.EnumAttributeType.rectangle, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.ADHESIVETYPE, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.GAPLIST, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.HARDENERTYPE, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.LAMINATINGMETHOD, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumLaminatingMethod.getEnum(0), null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.NIPWIDTH, 0x33333111, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.TEMPERATURE, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoLaminatingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoLaminatingParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoLaminatingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoLaminatingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoLaminatingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoLaminatingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoLaminatingParams[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for LaminatingMethod </summary>
      ///        

      public class EnumLaminatingMethod : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumLaminatingMethod(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumLaminatingMethod getEnum(string enumName)
         {
            return (EnumLaminatingMethod)getEnum(typeof(EnumLaminatingMethod), enumName);
         }

         public static EnumLaminatingMethod getEnum(int enumValue)
         {
            return (EnumLaminatingMethod)getEnum(typeof(EnumLaminatingMethod), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumLaminatingMethod));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumLaminatingMethod));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumLaminatingMethod));
         }

         public static readonly EnumLaminatingMethod CompoundFoil = new EnumLaminatingMethod("CompoundFoil");
         public static readonly EnumLaminatingMethod DispersionGlue = new EnumLaminatingMethod("DispersionGlue");
         public static readonly EnumLaminatingMethod Fusing = new EnumLaminatingMethod("Fusing");
         public static readonly EnumLaminatingMethod Unknown = new EnumLaminatingMethod("Unknown");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute LaminatingBox
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute LaminatingBox </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setLaminatingBox(JDFRectangle @value)
      {
         setAttribute(AttributeName.LAMINATINGBOX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFRectangle attribute LaminatingBox </summary>
      ///          * <returns> JDFRectangle the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFRectangle </returns>
      ///          
      public virtual JDFRectangle getLaminatingBox()
      {
         string strAttrName = "";
         JDFRectangle nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.LAMINATINGBOX, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute AdhesiveType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute AdhesiveType </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAdhesiveType(string @value)
      {
         setAttribute(AttributeName.ADHESIVETYPE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute AdhesiveType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getAdhesiveType()
      {
         return getAttribute(AttributeName.ADHESIVETYPE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute GapList
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute GapList </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setGapList(JDFNumberList @value)
      {
         setAttribute(AttributeName.GAPLIST, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFNumberList attribute GapList </summary>
      ///          * <returns> JDFNumberList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFNumberList </returns>
      ///          
      public virtual JDFNumberList getGapList()
      {
         string strAttrName = "";
         JDFNumberList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.GAPLIST, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute HardenerType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute HardenerType </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setHardenerType(string @value)
      {
         setAttribute(AttributeName.HARDENERTYPE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute HardenerType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getHardenerType()
      {
         return getAttribute(AttributeName.HARDENERTYPE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute LaminatingMethod
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute LaminatingMethod </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setLaminatingMethod(EnumLaminatingMethod enumVar)
      {
         setAttribute(AttributeName.LAMINATINGMETHOD, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute LaminatingMethod </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumLaminatingMethod getLaminatingMethod()
      {
         return EnumLaminatingMethod.getEnum(getAttribute(AttributeName.LAMINATINGMETHOD, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute NipWidth
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute NipWidth </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setNipWidth(double @value)
      {
         setAttribute(AttributeName.NIPWIDTH, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute NipWidth </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getNipWidth()
      {
         return getRealAttribute(AttributeName.NIPWIDTH, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Temperature
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Temperature </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTemperature(double @value)
      {
         setAttribute(AttributeName.TEMPERATURE, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute Temperature </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getTemperature()
      {
         return getRealAttribute(AttributeName.TEMPERATURE, null, 0.0);
      }
   }
}
