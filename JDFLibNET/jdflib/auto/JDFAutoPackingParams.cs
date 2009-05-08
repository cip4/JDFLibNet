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
   using JDFShape = org.cip4.jdflib.datatypes.JDFShape;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;

   public abstract class JDFAutoPackingParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[14];
      static JDFAutoPackingParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.PALLETWRAPPING, 0x44444443, AttributeInfo.EnumAttributeType.enumeration, EnumPalletWrapping.getEnum(0), "None");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.WRAPPINGMATERIAL, 0x44444443, AttributeInfo.EnumAttributeType.NMTOKEN, null, "None");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.BOXEDQUANTITY, 0x44444443, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.BOXSHAPE, 0x44444443, AttributeInfo.EnumAttributeType.shape, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.CARTONQUANTITY, 0x44444443, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.CARTONSHAPE, 0x44444443, AttributeInfo.EnumAttributeType.shape, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.CARTONMAXWEIGHT, 0x44444443, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.CARTONSTRENGTH, 0x44444443, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.PALLETQUANTITY, 0x44444443, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.PALLETSIZE, 0x44444443, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[10] = new AtrInfoTable(AttributeName.PALLETMAXHEIGHT, 0x44444443, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[11] = new AtrInfoTable(AttributeName.PALLETMAXWEIGHT, 0x44444443, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[12] = new AtrInfoTable(AttributeName.PALLETTYPE, 0x44444443, AttributeInfo.EnumAttributeType.enumeration, EnumPalletType.getEnum(0), null);
         atrInfoTable[13] = new AtrInfoTable(AttributeName.WRAPPEDQUANTITY, 0x44444443, AttributeInfo.EnumAttributeType.integer, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoPackingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPackingParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPackingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPackingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPackingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoPackingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoPackingParams[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for PalletWrapping </summary>
      ///        

      public class EnumPalletWrapping : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumPalletWrapping(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumPalletWrapping getEnum(string enumName)
         {
            return (EnumPalletWrapping)getEnum(typeof(EnumPalletWrapping), enumName);
         }

         public static EnumPalletWrapping getEnum(int enumValue)
         {
            return (EnumPalletWrapping)getEnum(typeof(EnumPalletWrapping), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumPalletWrapping));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumPalletWrapping));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumPalletWrapping));
         }

         public static readonly EnumPalletWrapping StretchWrap = new EnumPalletWrapping("StretchWrap");
         public static readonly EnumPalletWrapping Banding = new EnumPalletWrapping("Banding");
         public static readonly EnumPalletWrapping None = new EnumPalletWrapping("None");
      }



      ///        
      ///        <summary> * Enumeration strings for PalletType </summary>
      ///        

      public class EnumPalletType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumPalletType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumPalletType getEnum(string enumName)
         {
            return (EnumPalletType)getEnum(typeof(EnumPalletType), enumName);
         }

         public static EnumPalletType getEnum(int enumValue)
         {
            return (EnumPalletType)getEnum(typeof(EnumPalletType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumPalletType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumPalletType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumPalletType));
         }

         public static readonly EnumPalletType PalletType_2Way = new EnumPalletType("2Way");
         public static readonly EnumPalletType PalletType_4Way = new EnumPalletType("4Way");
         public static readonly EnumPalletType Euro = new EnumPalletType("Euro");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute PalletWrapping
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute PalletWrapping </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setPalletWrapping(EnumPalletWrapping enumVar)
      {
         setAttribute(AttributeName.PALLETWRAPPING, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute PalletWrapping </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumPalletWrapping getPalletWrapping()
      {
         return EnumPalletWrapping.getEnum(getAttribute(AttributeName.PALLETWRAPPING, null, "None"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute WrappingMaterial
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute WrappingMaterial </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setWrappingMaterial(string @value)
      {
         setAttribute(AttributeName.WRAPPINGMATERIAL, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute WrappingMaterial </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getWrappingMaterial()
      {
         return getAttribute(AttributeName.WRAPPINGMATERIAL, null, "None");
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute BoxedQuantity
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BoxedQuantity </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBoxedQuantity(int @value)
      {
         setAttribute(AttributeName.BOXEDQUANTITY, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute BoxedQuantity </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getBoxedQuantity()
      {
         return getIntAttribute(AttributeName.BOXEDQUANTITY, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute BoxShape
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BoxShape </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBoxShape(JDFShape @value)
      {
         setAttribute(AttributeName.BOXSHAPE, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFShape attribute BoxShape </summary>
      ///          * <returns> JDFShape the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFShape </returns>
      ///          
      public virtual JDFShape getBoxShape()
      {
         string strAttrName = "";
         JDFShape nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.BOXSHAPE, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute CartonQuantity
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CartonQuantity </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCartonQuantity(int @value)
      {
         setAttribute(AttributeName.CARTONQUANTITY, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute CartonQuantity </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getCartonQuantity()
      {
         return getIntAttribute(AttributeName.CARTONQUANTITY, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute CartonShape
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CartonShape </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCartonShape(JDFShape @value)
      {
         setAttribute(AttributeName.CARTONSHAPE, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFShape attribute CartonShape </summary>
      ///          * <returns> JDFShape the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFShape </returns>
      ///          
      public virtual JDFShape getCartonShape()
      {
         string strAttrName = "";
         JDFShape nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.CARTONSHAPE, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute CartonMaxWeight
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CartonMaxWeight </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCartonMaxWeight(double @value)
      {
         setAttribute(AttributeName.CARTONMAXWEIGHT, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute CartonMaxWeight </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getCartonMaxWeight()
      {
         return getRealAttribute(AttributeName.CARTONMAXWEIGHT, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute CartonStrength
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CartonStrength </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCartonStrength(double @value)
      {
         setAttribute(AttributeName.CARTONSTRENGTH, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute CartonStrength </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getCartonStrength()
      {
         return getRealAttribute(AttributeName.CARTONSTRENGTH, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PalletQuantity
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PalletQuantity </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPalletQuantity(int @value)
      {
         setAttribute(AttributeName.PALLETQUANTITY, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute PalletQuantity </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getPalletQuantity()
      {
         return getIntAttribute(AttributeName.PALLETQUANTITY, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PalletSize
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PalletSize </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPalletSize(JDFXYPair @value)
      {
         setAttribute(AttributeName.PALLETSIZE, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute PalletSize </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getPalletSize()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.PALLETSIZE, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute PalletMaxHeight
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PalletMaxHeight </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPalletMaxHeight(double @value)
      {
         setAttribute(AttributeName.PALLETMAXHEIGHT, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute PalletMaxHeight </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getPalletMaxHeight()
      {
         return getRealAttribute(AttributeName.PALLETMAXHEIGHT, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PalletMaxWeight
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PalletMaxWeight </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPalletMaxWeight(double @value)
      {
         setAttribute(AttributeName.PALLETMAXWEIGHT, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute PalletMaxWeight </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getPalletMaxWeight()
      {
         return getRealAttribute(AttributeName.PALLETMAXWEIGHT, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PalletType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute PalletType </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setPalletType(EnumPalletType enumVar)
      {
         setAttribute(AttributeName.PALLETTYPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute PalletType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumPalletType getPalletType()
      {
         return EnumPalletType.getEnum(getAttribute(AttributeName.PALLETTYPE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute WrappedQuantity
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute WrappedQuantity </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setWrappedQuantity(int @value)
      {
         setAttribute(AttributeName.WRAPPEDQUANTITY, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute WrappedQuantity </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getWrappedQuantity()
      {
         return getIntAttribute(AttributeName.WRAPPEDQUANTITY, null, 0);
      }
   }
}
