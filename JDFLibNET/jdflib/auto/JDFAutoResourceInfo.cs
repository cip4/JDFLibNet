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
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using JDFIntegerRangeList = org.cip4.jdflib.datatypes.JDFIntegerRangeList;
   using JDFAmountPool = org.cip4.jdflib.pool.JDFAmountPool;
   using JDFPart = org.cip4.jdflib.resource.JDFPart;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFCostCenter = org.cip4.jdflib.resource.process.JDFCostCenter;
   using JDFMISDetails = org.cip4.jdflib.resource.process.JDFMISDetails;

   public abstract class JDFAutoResourceInfo : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[14];
      static JDFAutoResourceInfo()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ACTUALAMOUNT, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.AMOUNT, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.AVAILABLEAMOUNT, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.LEVEL, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumLevel.getEnum(0), "OK");
         atrInfoTable[4] = new AtrInfoTable(AttributeName.LOCATION, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.MODULEID, 0x33333111, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.MODULEINDEX, 0x33333111, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.PROCESSUSAGE, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.PRODUCTID, 0x33333311, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.RESOURCEID, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[10] = new AtrInfoTable(AttributeName.RESOURCENAME, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[11] = new AtrInfoTable(AttributeName.STATUS, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, JDFResource.EnumResStatus.getEnum(0), null);
         atrInfoTable[12] = new AtrInfoTable(AttributeName.UNIT, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[13] = new AtrInfoTable(AttributeName.USAGE, 0x33333111, AttributeInfo.EnumAttributeType.enumeration, JDFResourceLink.EnumUsage.getEnum(0), null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.AMOUNTPOOL, 0x66666111);
         elemInfoTable[1] = new ElemInfoTable(ElementName.COSTCENTER, 0x66666666);
         elemInfoTable[2] = new ElemInfoTable(ElementName.MISDETAILS, 0x66666611);
         elemInfoTable[3] = new ElemInfoTable(ElementName.PART, 0x33333311);
         elemInfoTable[4] = new ElemInfoTable(ElementName.RESOURCE, 0x33333333);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[5];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoResourceInfo </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoResourceInfo(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoResourceInfo </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoResourceInfo(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoResourceInfo </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoResourceInfo(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoResourceInfo[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for Level </summary>
      ///        

      public class EnumLevel : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumLevel(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumLevel getEnum(string enumName)
         {
            return (EnumLevel)getEnum(typeof(EnumLevel), enumName);
         }

         public static EnumLevel getEnum(int enumValue)
         {
            return (EnumLevel)getEnum(typeof(EnumLevel), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumLevel));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumLevel));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumLevel));
         }

         public static readonly EnumLevel Empty = new EnumLevel("Empty");
         public static readonly EnumLevel Low = new EnumLevel("Low");
         public static readonly EnumLevel OK = new EnumLevel("OK");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute ActualAmount
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ActualAmount </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setActualAmount(double @value)
      {
         setAttribute(AttributeName.ACTUALAMOUNT, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute ActualAmount </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getActualAmount()
      {
         return getRealAttribute(AttributeName.ACTUALAMOUNT, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Amount
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Amount </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAmount(double @value)
      {
         setAttribute(AttributeName.AMOUNT, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute Amount </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getAmount()
      {
         return getRealAttribute(AttributeName.AMOUNT, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute AvailableAmount
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute AvailableAmount </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAvailableAmount(double @value)
      {
         setAttribute(AttributeName.AVAILABLEAMOUNT, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute AvailableAmount </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getAvailableAmount()
      {
         return getRealAttribute(AttributeName.AVAILABLEAMOUNT, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Level
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Level </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setLevel(EnumLevel enumVar)
      {
         setAttribute(AttributeName.LEVEL, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Level </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumLevel getLevel()
      {
         return EnumLevel.getEnum(getAttribute(AttributeName.LEVEL, null, "OK"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Location
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Location </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setLocation(string @value)
      {
         setAttribute(AttributeName.LOCATION, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Location </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getLocation()
      {
         return getAttribute(AttributeName.LOCATION, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ModuleID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ModuleID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setModuleID(string @value)
      {
         setAttribute(AttributeName.MODULEID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ModuleID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getModuleID()
      {
         return getAttribute(AttributeName.MODULEID, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute ProcessUsage
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ProcessUsage </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setProcessUsage(string @value)
      {
         setAttribute(AttributeName.PROCESSUSAGE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ProcessUsage </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getProcessUsage()
      {
         return getAttribute(AttributeName.PROCESSUSAGE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ProductID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ProductID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setProductID(string @value)
      {
         setAttribute(AttributeName.PRODUCTID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ProductID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getProductID()
      {
         return getAttribute(AttributeName.PRODUCTID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ResourceID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ResourceID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setResourceID(string @value)
      {
         setAttribute(AttributeName.RESOURCEID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ResourceID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getResourceID()
      {
         return getAttribute(AttributeName.RESOURCEID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ResourceName
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ResourceName </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setResourceName(string @value)
      {
         setAttribute(AttributeName.RESOURCENAME, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ResourceName </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getResourceName()
      {
         return getAttribute(AttributeName.RESOURCENAME, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Status
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Status </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setResStatus(JDFResource.EnumResStatus enumVar)
      {
         setAttribute(AttributeName.STATUS, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Status </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual JDFResource.EnumResStatus getResStatus()
      {
         return JDFResource.EnumResStatus.getEnum(getAttribute(AttributeName.STATUS, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Unit
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Unit </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setUnit(string @value)
      {
         setAttribute(AttributeName.UNIT, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Unit </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getUnit()
      {
         return getAttribute(AttributeName.UNIT, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Usage
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Usage </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setUsage(JDFResourceLink.EnumUsage enumVar)
      {
         setAttribute(AttributeName.USAGE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Usage </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual JDFResourceLink.EnumUsage getUsage()
      {
         return JDFResourceLink.EnumUsage.getEnum(getAttribute(AttributeName.USAGE, null, null));
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element AmountPool </summary>
      ///     * <returns> JDFAmountPool the element </returns>
      ///     
      public virtual JDFAmountPool getAmountPool()
      {
         return (JDFAmountPool)getElement(ElementName.AMOUNTPOOL, null, 0);
      }

      ///     <summary> (25) getCreateAmountPool
      ///     *  </summary>
      ///     * <returns> JDFAmountPool the element </returns>
      ///     
      public virtual JDFAmountPool getCreateAmountPool()
      {
         return (JDFAmountPool)getCreateElement_KElement(ElementName.AMOUNTPOOL, null, 0);
      }

      ///    
      ///     <summary> * (29) append element AmountPool </summary>
      ///     
      public virtual JDFAmountPool appendAmountPool()
      {
         return (JDFAmountPool)appendElementN(ElementName.AMOUNTPOOL, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element CostCenter </summary>
      ///     * <returns> JDFCostCenter the element </returns>
      ///     
      public virtual JDFCostCenter getCostCenter()
      {
         return (JDFCostCenter)getElement(ElementName.COSTCENTER, null, 0);
      }

      ///     <summary> (25) getCreateCostCenter
      ///     *  </summary>
      ///     * <returns> JDFCostCenter the element </returns>
      ///     
      public virtual JDFCostCenter getCreateCostCenter()
      {
         return (JDFCostCenter)getCreateElement_KElement(ElementName.COSTCENTER, null, 0);
      }

      ///    
      ///     <summary> * (29) append element CostCenter </summary>
      ///     
      public virtual JDFCostCenter appendCostCenter()
      {
         return (JDFCostCenter)appendElementN(ElementName.COSTCENTER, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element MISDetails </summary>
      ///     * <returns> JDFMISDetails the element </returns>
      ///     
      public virtual JDFMISDetails getMISDetails()
      {
         return (JDFMISDetails)getElement(ElementName.MISDETAILS, null, 0);
      }

      ///     <summary> (25) getCreateMISDetails
      ///     *  </summary>
      ///     * <returns> JDFMISDetails the element </returns>
      ///     
      public virtual JDFMISDetails getCreateMISDetails()
      {
         return (JDFMISDetails)getCreateElement_KElement(ElementName.MISDETAILS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element MISDetails </summary>
      ///     
      public virtual JDFMISDetails appendMISDetails()
      {
         return (JDFMISDetails)appendElementN(ElementName.MISDETAILS, 1, null);
      }

      ///     <summary> (26) getCreatePart
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFPart the element </returns>
      ///     
      public virtual JDFPart getCreatePart(int iSkip)
      {
         return (JDFPart)getCreateElement_KElement(ElementName.PART, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Part </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFPart the element </returns>
      ///     * default is getPart(0)     
      public virtual JDFPart getPart(int iSkip)
      {
         return (JDFPart)getElement(ElementName.PART, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Part from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFPart> </returns>
      ///     
      public virtual ICollection<JDFPart> getAllPart()
      {
         List<JDFPart> v = new List<JDFPart>();

         JDFPart kElem = (JDFPart)getFirstChildElement(ElementName.PART, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFPart)kElem.getNextSiblingElement(ElementName.PART, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Part </summary>
      ///     
      public virtual JDFPart appendPart()
      {
         return (JDFPart)appendElement(ElementName.PART, null);
      }
   }
}
