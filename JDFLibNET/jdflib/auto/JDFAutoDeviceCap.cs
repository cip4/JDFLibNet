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
   using System.Collections.Generic;


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using VString = org.cip4.jdflib.core.VString;
   using JDFPerformance = org.cip4.jdflib.resource.JDFPerformance;
   using JDFActionPool = org.cip4.jdflib.resource.devicecapability.JDFActionPool;
   using JDFDevCapPool = org.cip4.jdflib.resource.devicecapability.JDFDevCapPool;
   using JDFDevCaps = org.cip4.jdflib.resource.devicecapability.JDFDevCaps;
   using JDFDisplayGroupPool = org.cip4.jdflib.resource.devicecapability.JDFDisplayGroupPool;
   using JDFFeaturePool = org.cip4.jdflib.resource.devicecapability.JDFFeaturePool;
   using JDFMacroPool = org.cip4.jdflib.resource.devicecapability.JDFMacroPool;
   using JDFModulePool = org.cip4.jdflib.resource.devicecapability.JDFModulePool;
   using JDFTestPool = org.cip4.jdflib.resource.devicecapability.JDFTestPool;

   public abstract class JDFAutoDeviceCap : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[9];
      static JDFAutoDeviceCap()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.COMBINEDMETHOD, 0x33333331, AttributeInfo.EnumAttributeType.enumerations, EnumCombinedMethod.getEnum(0), "None");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.EXECUTIONPOLICY, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumExecutionPolicy.getEnum(0), "AllFound");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.GENERICATTRIBUTES, 0x33333331, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.LANG, 0x33333311, AttributeInfo.EnumAttributeType.languages, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.OPTIONALCOMBINEDTYPES, 0x44444431, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.TYPE, 0x44444431, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.TYPEEXPRESSION, 0x33333311, AttributeInfo.EnumAttributeType.Any, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.TYPEORDER, 0x44444431, AttributeInfo.EnumAttributeType.enumeration, EnumTypeOrder.getEnum(0), null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.TYPES, 0x33333331, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.ACTIONPOOL, 0x66666611);
         elemInfoTable[1] = new ElemInfoTable(ElementName.DEVCAPPOOL, 0x66666111);
         elemInfoTable[2] = new ElemInfoTable(ElementName.DEVCAPS, 0x33333331);
         elemInfoTable[3] = new ElemInfoTable(ElementName.DISPLAYGROUPPOOL, 0x66666611);
         elemInfoTable[4] = new ElemInfoTable(ElementName.FEATUREPOOL, 0x66666611);
         elemInfoTable[5] = new ElemInfoTable(ElementName.MACROPOOL, 0x66666611);
         elemInfoTable[6] = new ElemInfoTable(ElementName.MODULEPOOL, 0x66666111);
         elemInfoTable[7] = new ElemInfoTable(ElementName.PERFORMANCE, 0x33333331);
         elemInfoTable[8] = new ElemInfoTable(ElementName.TESTPOOL, 0x66666611);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[9];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoDeviceCap </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoDeviceCap(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoDeviceCap </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoDeviceCap(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoDeviceCap </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoDeviceCap(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoDeviceCap[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for CombinedMethod </summary>
      ///        

      public class EnumCombinedMethod : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumCombinedMethod(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumCombinedMethod getEnum(string enumName)
         {
            return (EnumCombinedMethod)getEnum(typeof(EnumCombinedMethod), enumName);
         }

         public static EnumCombinedMethod getEnum(int enumValue)
         {
            return (EnumCombinedMethod)getEnum(typeof(EnumCombinedMethod), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumCombinedMethod));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumCombinedMethod));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumCombinedMethod));
         }

         public static readonly EnumCombinedMethod Combined = new EnumCombinedMethod("Combined");
         public static readonly EnumCombinedMethod CombinedProcessGroup = new EnumCombinedMethod("CombinedProcessGroup");
         public static readonly EnumCombinedMethod GrayBox = new EnumCombinedMethod("GrayBox");
         public static readonly EnumCombinedMethod ProcessGroup = new EnumCombinedMethod("ProcessGroup");
         public static readonly EnumCombinedMethod None = new EnumCombinedMethod("None");
      }



      ///        
      ///        <summary> * Enumeration strings for ExecutionPolicy </summary>
      ///        

      public class EnumExecutionPolicy : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumExecutionPolicy(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumExecutionPolicy getEnum(string enumName)
         {
            return (EnumExecutionPolicy)getEnum(typeof(EnumExecutionPolicy), enumName);
         }

         public static EnumExecutionPolicy getEnum(int enumValue)
         {
            return (EnumExecutionPolicy)getEnum(typeof(EnumExecutionPolicy), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumExecutionPolicy));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumExecutionPolicy));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumExecutionPolicy));
         }

         public static readonly EnumExecutionPolicy RootNode = new EnumExecutionPolicy("RootNode");
         public static readonly EnumExecutionPolicy FirstFound = new EnumExecutionPolicy("FirstFound");
         public static readonly EnumExecutionPolicy AllFound = new EnumExecutionPolicy("AllFound");
      }



      ///        
      ///        <summary> * Enumeration strings for TypeOrder </summary>
      ///        

      public class EnumTypeOrder : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumTypeOrder(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumTypeOrder getEnum(string enumName)
         {
            return (EnumTypeOrder)getEnum(typeof(EnumTypeOrder), enumName);
         }

         public static EnumTypeOrder getEnum(int enumValue)
         {
            return (EnumTypeOrder)getEnum(typeof(EnumTypeOrder), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumTypeOrder));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumTypeOrder));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumTypeOrder));
         }

         public static readonly EnumTypeOrder Fixed = new EnumTypeOrder("Fixed");
         public static readonly EnumTypeOrder Unordered = new EnumTypeOrder("Unordered");
         public static readonly EnumTypeOrder Unrestricted = new EnumTypeOrder("Unrestricted");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute CombinedMethod
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5.2) set attribute CombinedMethod </summary>
      ///          * <param name="v"> vector of the enumeration values </param>
      ///          
      public virtual void setCombinedMethod(List<ValuedEnum> v)
      {
         setEnumerationsAttribute(AttributeName.COMBINEDMETHOD, v, null);
      }

      ///        
      ///          <summary> * (9.2) get CombinedMethod attribute CombinedMethod </summary>
      ///          * <returns> Vector of the enumerations </returns>
      ///          
      public virtual List<ValuedEnum> getCombinedMethod()
      {
         return getEnumerationsAttribute(AttributeName.COMBINEDMETHOD, null, EnumCombinedMethod.None, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ExecutionPolicy
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute ExecutionPolicy </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setExecutionPolicy(EnumExecutionPolicy enumVar)
      {
         setAttribute(AttributeName.EXECUTIONPOLICY, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute ExecutionPolicy </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumExecutionPolicy getExecutionPolicy()
      {
         return EnumExecutionPolicy.getEnum(getAttribute(AttributeName.EXECUTIONPOLICY, null, "AllFound"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute GenericAttributes
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute GenericAttributes </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setGenericAttributes(VString @value)
      {
         setAttribute(AttributeName.GENERICATTRIBUTES, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute GenericAttributes </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getGenericAttributes()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.GENERICATTRIBUTES, null, JDFConstants.EMPTYSTRING);
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Lang
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Lang </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setLang(VString @value)
      {
         setAttribute(AttributeName.LANG, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute Lang </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getLang()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.LANG, null, JDFConstants.EMPTYSTRING);
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute OptionalCombinedTypes
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute OptionalCombinedTypes </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setOptionalCombinedTypes(VString @value)
      {
         setAttribute(AttributeName.OPTIONALCOMBINEDTYPES, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute OptionalCombinedTypes </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getOptionalCombinedTypes()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.OPTIONALCOMBINEDTYPES, null, JDFConstants.EMPTYSTRING);
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Type
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Type </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setType(string @value)
      {
         setAttribute(AttributeName.TYPE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Type </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getType()
      {
         return getAttribute(AttributeName.TYPE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TypeExpression
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TypeExpression </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTypeExpression(string @value)
      {
         setAttribute(AttributeName.TYPEEXPRESSION, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute TypeExpression </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getTypeExpression()
      {
         return getAttribute(AttributeName.TYPEEXPRESSION, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TypeOrder
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute TypeOrder </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setTypeOrder(EnumTypeOrder enumVar)
      {
         setAttribute(AttributeName.TYPEORDER, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute TypeOrder </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumTypeOrder getTypeOrder()
      {
         return EnumTypeOrder.getEnum(getAttribute(AttributeName.TYPEORDER, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Types
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Types </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTypes(VString @value)
      {
         setAttribute(AttributeName.TYPES, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute Types </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getTypes()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.TYPES, null, JDFConstants.EMPTYSTRING);
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element ActionPool </summary>
      ///     * <returns> JDFActionPool the element </returns>
      ///     
      public virtual JDFActionPool getActionPool()
      {
         return (JDFActionPool)getElement(ElementName.ACTIONPOOL, null, 0);
      }

      ///     <summary> (25) getCreateActionPool
      ///     *  </summary>
      ///     * <returns> JDFActionPool the element </returns>
      ///     
      public virtual JDFActionPool getCreateActionPool()
      {
         return (JDFActionPool)getCreateElement_KElement(ElementName.ACTIONPOOL, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ActionPool </summary>
      ///     
      public virtual JDFActionPool appendActionPool()
      {
         return (JDFActionPool)appendElementN(ElementName.ACTIONPOOL, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element DevCapPool </summary>
      ///     * <returns> JDFDevCapPool the element </returns>
      ///     
      public virtual JDFDevCapPool getDevCapPool()
      {
         return (JDFDevCapPool)getElement(ElementName.DEVCAPPOOL, null, 0);
      }

      ///     <summary> (25) getCreateDevCapPool
      ///     *  </summary>
      ///     * <returns> JDFDevCapPool the element </returns>
      ///     
      public virtual JDFDevCapPool getCreateDevCapPool()
      {
         return (JDFDevCapPool)getCreateElement_KElement(ElementName.DEVCAPPOOL, null, 0);
      }

      ///    
      ///     <summary> * (29) append element DevCapPool </summary>
      ///     
      public virtual JDFDevCapPool appendDevCapPool()
      {
         return (JDFDevCapPool)appendElementN(ElementName.DEVCAPPOOL, 1, null);
      }

      ///     <summary> (26) getCreateDevCaps
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFDevCaps the element </returns>
      ///     
      public virtual JDFDevCaps getCreateDevCaps(int iSkip)
      {
         return (JDFDevCaps)getCreateElement_KElement(ElementName.DEVCAPS, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element DevCaps </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFDevCaps the element </returns>
      ///     * default is getDevCaps(0)     
      public virtual JDFDevCaps getDevCaps(int iSkip)
      {
         return (JDFDevCaps)getElement(ElementName.DEVCAPS, null, iSkip);
      }

      ///    
      ///     <summary> * Get all DevCaps from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFDevCaps> </returns>
      ///     
      public virtual ICollection<JDFDevCaps> getAllDevCaps()
      {
         List<JDFDevCaps> v = new List<JDFDevCaps>();

         JDFDevCaps kElem = (JDFDevCaps)getFirstChildElement(ElementName.DEVCAPS, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFDevCaps)kElem.getNextSiblingElement(ElementName.DEVCAPS, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element DevCaps </summary>
      ///     
      public virtual JDFDevCaps appendDevCaps()
      {
         return (JDFDevCaps)appendElement(ElementName.DEVCAPS, null);
      }

      ///    
      ///     <summary> * (24) const get element DisplayGroupPool </summary>
      ///     * <returns> JDFDisplayGroupPool the element </returns>
      ///     
      public virtual JDFDisplayGroupPool getDisplayGroupPool()
      {
         return (JDFDisplayGroupPool)getElement(ElementName.DISPLAYGROUPPOOL, null, 0);
      }

      ///     <summary> (25) getCreateDisplayGroupPool
      ///     *  </summary>
      ///     * <returns> JDFDisplayGroupPool the element </returns>
      ///     
      public virtual JDFDisplayGroupPool getCreateDisplayGroupPool()
      {
         return (JDFDisplayGroupPool)getCreateElement_KElement(ElementName.DISPLAYGROUPPOOL, null, 0);
      }

      ///    
      ///     <summary> * (29) append element DisplayGroupPool </summary>
      ///     
      public virtual JDFDisplayGroupPool appendDisplayGroupPool()
      {
         return (JDFDisplayGroupPool)appendElementN(ElementName.DISPLAYGROUPPOOL, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element FeaturePool </summary>
      ///     * <returns> JDFFeaturePool the element </returns>
      ///     
      public virtual JDFFeaturePool getFeaturePool()
      {
         return (JDFFeaturePool)getElement(ElementName.FEATUREPOOL, null, 0);
      }

      ///     <summary> (25) getCreateFeaturePool
      ///     *  </summary>
      ///     * <returns> JDFFeaturePool the element </returns>
      ///     
      public virtual JDFFeaturePool getCreateFeaturePool()
      {
         return (JDFFeaturePool)getCreateElement_KElement(ElementName.FEATUREPOOL, null, 0);
      }

      ///    
      ///     <summary> * (29) append element FeaturePool </summary>
      ///     
      public virtual JDFFeaturePool appendFeaturePool()
      {
         return (JDFFeaturePool)appendElementN(ElementName.FEATUREPOOL, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element MacroPool </summary>
      ///     * <returns> JDFMacroPool the element </returns>
      ///     
      public virtual JDFMacroPool getMacroPool()
      {
         return (JDFMacroPool)getElement(ElementName.MACROPOOL, null, 0);
      }

      ///     <summary> (25) getCreateMacroPool
      ///     *  </summary>
      ///     * <returns> JDFMacroPool the element </returns>
      ///     
      public virtual JDFMacroPool getCreateMacroPool()
      {
         return (JDFMacroPool)getCreateElement_KElement(ElementName.MACROPOOL, null, 0);
      }

      ///    
      ///     <summary> * (29) append element MacroPool </summary>
      ///     
      public virtual JDFMacroPool appendMacroPool()
      {
         return (JDFMacroPool)appendElementN(ElementName.MACROPOOL, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element ModulePool </summary>
      ///     * <returns> JDFModulePool the element </returns>
      ///     
      public virtual JDFModulePool getModulePool()
      {
         return (JDFModulePool)getElement(ElementName.MODULEPOOL, null, 0);
      }

      ///     <summary> (25) getCreateModulePool
      ///     *  </summary>
      ///     * <returns> JDFModulePool the element </returns>
      ///     
      public virtual JDFModulePool getCreateModulePool()
      {
         return (JDFModulePool)getCreateElement_KElement(ElementName.MODULEPOOL, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ModulePool </summary>
      ///     
      public virtual JDFModulePool appendModulePool()
      {
         return (JDFModulePool)appendElementN(ElementName.MODULEPOOL, 1, null);
      }

      ///     <summary> (26) getCreatePerformance
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFPerformance the element </returns>
      ///     
      public virtual JDFPerformance getCreatePerformance(int iSkip)
      {
         return (JDFPerformance)getCreateElement_KElement(ElementName.PERFORMANCE, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Performance </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFPerformance the element </returns>
      ///     * default is getPerformance(0)     
      public virtual JDFPerformance getPerformance(int iSkip)
      {
         return (JDFPerformance)getElement(ElementName.PERFORMANCE, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Performance from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFPerformance> </returns>
      ///     
      public virtual ICollection<JDFPerformance> getAllPerformance()
      {
         List<JDFPerformance> v = new List<JDFPerformance>();

         JDFPerformance kElem = (JDFPerformance)getFirstChildElement(ElementName.PERFORMANCE, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFPerformance)kElem.getNextSiblingElement(ElementName.PERFORMANCE, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Performance </summary>
      ///     
      public virtual JDFPerformance appendPerformance()
      {
         return (JDFPerformance)appendElement(ElementName.PERFORMANCE, null);
      }

      ///    
      ///     <summary> * (24) const get element TestPool </summary>
      ///     * <returns> JDFTestPool the element </returns>
      ///     
      public virtual JDFTestPool getTestPool()
      {
         return (JDFTestPool)getElement(ElementName.TESTPOOL, null, 0);
      }

      ///     <summary> (25) getCreateTestPool
      ///     *  </summary>
      ///     * <returns> JDFTestPool the element </returns>
      ///     
      public virtual JDFTestPool getCreateTestPool()
      {
         return (JDFTestPool)getCreateElement_KElement(ElementName.TESTPOOL, null, 0);
      }

      ///    
      ///     <summary> * (29) append element TestPool </summary>
      ///     
      public virtual JDFTestPool appendTestPool()
      {
         return (JDFTestPool)appendElementN(ElementName.TESTPOOL, 1, null);
      }
   }
}
