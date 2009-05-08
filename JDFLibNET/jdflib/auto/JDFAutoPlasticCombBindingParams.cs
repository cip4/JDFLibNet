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
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFHoleMakingParams = org.cip4.jdflib.resource.process.postpress.JDFHoleMakingParams;

   public abstract class JDFAutoPlasticCombBindingParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[5];
      static JDFAutoPlasticCombBindingParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.BRAND, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.COLOR, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.DIAMETER, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.THICKNESS, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.TYPE, 0x44444433, AttributeInfo.EnumAttributeType.enumeration, EnumType.getEnum(0), null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.HOLEMAKINGPARAMS, 0x66666666);
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
      ///     <summary> * Constructor for JDFAutoPlasticCombBindingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPlasticCombBindingParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPlasticCombBindingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPlasticCombBindingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPlasticCombBindingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoPlasticCombBindingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoPlasticCombBindingParams[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for Type </summary>
      ///        

      public class EnumType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumType getEnum(string enumName)
         {
            return (EnumType)getEnum(typeof(EnumType), enumName);
         }

         public static EnumType getEnum(int enumValue)
         {
            return (EnumType)getEnum(typeof(EnumType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumType));
         }

         public static readonly EnumType R2_generic = new EnumType("R2-generic");
         public static readonly EnumType S1_generic = new EnumType("S1-generic");
         public static readonly EnumType S_generic = new EnumType("S-generic");
         public static readonly EnumType R2m_DIN = new EnumType("R2m-DIN");
         public static readonly EnumType R2m_ISO = new EnumType("R2m-ISO");
         public static readonly EnumType R2m_MIB = new EnumType("R2m-MIB");
         public static readonly EnumType R2i_US_a = new EnumType("R2i-US-a");
         public static readonly EnumType R2i_US_b = new EnumType("R2i-US-b");
         public static readonly EnumType R3_generic = new EnumType("R3-generic");
         public static readonly EnumType R3i_US = new EnumType("R3i-US");
         public static readonly EnumType R4_generic = new EnumType("R4-generic");
         public static readonly EnumType R4m_DIN_A4 = new EnumType("R4m-DIN-A4");
         public static readonly EnumType R4m_DIN_A5 = new EnumType("R4m-DIN-A5");
         public static readonly EnumType R4m_swedish = new EnumType("R4m-swedish");
         public static readonly EnumType R4i_US = new EnumType("R4i-US");
         public static readonly EnumType R5_generic = new EnumType("R5-generic");
         public static readonly EnumType R5i_US_a = new EnumType("R5i-US-a");
         public static readonly EnumType R5i_US_b = new EnumType("R5i-US-b");
         public static readonly EnumType R5i_US_c = new EnumType("R5i-US-c");
         public static readonly EnumType R6_generic = new EnumType("R6-generic");
         public static readonly EnumType R6m_4h2s = new EnumType("R6m-4h2s");
         public static readonly EnumType R6m_DIN_A5 = new EnumType("R6m-DIN-A5");
         public static readonly EnumType R7_generic = new EnumType("R7-generic");
         public static readonly EnumType R7i_US_a = new EnumType("R7i-US-a");
         public static readonly EnumType R7i_US_b = new EnumType("R7i-US-b");
         public static readonly EnumType R7i_US_c = new EnumType("R7i-US-c");
         public static readonly EnumType R11m_7h4s = new EnumType("R11m-7h4s");
         public static readonly EnumType P16_9i_rect_0t = new EnumType("P16_9i-rect-0t");
         public static readonly EnumType P12m_rect_0t = new EnumType("P12m-rect-0t");
         public static readonly EnumType W2_1i_round_0t = new EnumType("W2_1i-round-0t");
         public static readonly EnumType W2_1i_square_0t = new EnumType("W2_1i-square-0t");
         public static readonly EnumType W3_1i_square_0t = new EnumType("W3_1i-square-0t");
         public static readonly EnumType C9_5m_round_0t = new EnumType("C9.5m-round-0t");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute Brand
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Brand </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public override void setBrand(string @value)
      {
         setAttribute(AttributeName.BRAND, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Brand </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public override string getBrand()
      {
         return getAttribute(AttributeName.BRAND, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Color
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (13) set attribute Color </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setColor(EnumNamedColor @value)
      {
         setAttribute(AttributeName.COLOR, @value == null ? null : @value.getName(), null);
      }

      ///        
      ///          <summary> * (19) get EnumNamedColor attribute Color </summary>
      ///          * <returns> EnumNamedColor the value of the attribute </returns>
      ///          
      public virtual EnumNamedColor getColor()
      {
         string strAttrName = "";
         EnumNamedColor nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.COLOR, null, JDFConstants.EMPTYSTRING);
         nPlaceHolder = EnumNamedColor.getEnum(strAttrName);
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Diameter
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Diameter </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDiameter(double @value)
      {
         setAttribute(AttributeName.DIAMETER, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute Diameter </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getDiameter()
      {
         return getRealAttribute(AttributeName.DIAMETER, null, 0.0);
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
      //        Methods for Attribute Type
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Type </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setType(EnumType enumVar)
      {
         setAttribute(AttributeName.TYPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Type </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumType getType()
      {
         return EnumType.getEnum(getAttribute(AttributeName.TYPE, null, null));
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element HoleMakingParams </summary>
      ///     * <returns> JDFHoleMakingParams the element </returns>
      ///     
      public virtual JDFHoleMakingParams getHoleMakingParams()
      {
         return (JDFHoleMakingParams)getElement(ElementName.HOLEMAKINGPARAMS, null, 0);
      }

      ///     <summary> (25) getCreateHoleMakingParams
      ///     *  </summary>
      ///     * <returns> JDFHoleMakingParams the element </returns>
      ///     
      public virtual JDFHoleMakingParams getCreateHoleMakingParams()
      {
         return (JDFHoleMakingParams)getCreateElement_KElement(ElementName.HOLEMAKINGPARAMS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element HoleMakingParams </summary>
      ///     
      public virtual JDFHoleMakingParams appendHoleMakingParams()
      {
         return (JDFHoleMakingParams)appendElementN(ElementName.HOLEMAKINGPARAMS, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refHoleMakingParams(JDFHoleMakingParams refTarget)
      {
         refElement(refTarget);
      }
   }
}
