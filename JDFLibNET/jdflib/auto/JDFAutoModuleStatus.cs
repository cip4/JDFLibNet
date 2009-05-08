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
 * THIS SOFTWARE IS PROVIDED ``AS IS'' AND ANY EXPRESSED OR IMPLIED
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
   using System.Collections.Generic;



   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFIntegerList = org.cip4.jdflib.datatypes.JDFIntegerList;
   using JDFIntegerRangeList = org.cip4.jdflib.datatypes.JDFIntegerRangeList;
   using JDFDeviceInfo = org.cip4.jdflib.jmf.JDFDeviceInfo;
   using JDFEmployee = org.cip4.jdflib.resource.process.JDFEmployee;

   public abstract class JDFAutoModuleStatus : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[6];
      static JDFAutoModuleStatus()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.COMBINEDPROCESSINDEX, 0x33333333, AttributeInfo.EnumAttributeType.IntegerList, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.DEVICESTATUS, 0x22222222, AttributeInfo.EnumAttributeType.enumeration, JDFDeviceInfo.EnumDeviceStatus.getEnum(0), null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.MODULEID, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.MODULEINDEX, 0x33333333, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.MODULETYPE, 0x22222222, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.STATUSDETAILS, 0x33333333, AttributeInfo.EnumAttributeType.shortString, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.EMPLOYEE, 0x33333333);
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
      ///     <summary> * Constructor for JDFAutoModuleStatus </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoModuleStatus(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoModuleStatus </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoModuleStatus(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoModuleStatus </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoModuleStatus(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoModuleStatus[  --> " + base.ToString() + " ]";
      }


      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute CombinedProcessIndex
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CombinedProcessIndex </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCombinedProcessIndex(JDFIntegerList @value)
      {
         setAttribute(AttributeName.COMBINEDPROCESSINDEX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerList attribute CombinedProcessIndex </summary>
      ///          * <returns> JDFIntegerList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerList </returns>
      ///          
      public virtual JDFIntegerList getCombinedProcessIndex()
      {
         string strAttrName = "";
         JDFIntegerList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.COMBINEDPROCESSINDEX, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute DeviceStatus
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute DeviceStatus </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setDeviceStatus(JDFDeviceInfo.EnumDeviceStatus enumVar)
      {
         setAttribute(AttributeName.DEVICESTATUS, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute DeviceStatus </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual JDFDeviceInfo.EnumDeviceStatus getDeviceStatus()
      {
         return JDFDeviceInfo.EnumDeviceStatus.getEnum(getAttribute(AttributeName.DEVICESTATUS, null, null));
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
      //        Methods for Attribute ModuleType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ModuleType </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setModuleType(string @value)
      {
         setAttribute(AttributeName.MODULETYPE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ModuleType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getModuleType()
      {
         return getAttribute(AttributeName.MODULETYPE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute StatusDetails
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute StatusDetails </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setStatusDetails(string @value)
      {
         setAttribute(AttributeName.STATUSDETAILS, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute StatusDetails </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getStatusDetails()
      {
         return getAttribute(AttributeName.STATUSDETAILS, null, JDFConstants.EMPTYSTRING);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateEmployee
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFEmployee the element </returns>
      ///     
      public virtual JDFEmployee getCreateEmployee(int iSkip)
      {
         return (JDFEmployee)getCreateElement_KElement(ElementName.EMPLOYEE, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Employee </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFEmployee the element </returns>
      ///     * default is getEmployee(0)     
      public virtual JDFEmployee getEmployee(int iSkip)
      {
         return (JDFEmployee)getElement(ElementName.EMPLOYEE, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Employee from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFEmployee> </returns>
      ///     
      public virtual ICollection<JDFEmployee> getAllEmployee()
      {
         List<JDFEmployee> v = new List<JDFEmployee>();

         JDFEmployee kElem = (JDFEmployee)getFirstChildElement(ElementName.EMPLOYEE, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFEmployee)kElem.getNextSiblingElement(ElementName.EMPLOYEE, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Employee </summary>
      ///     
      public virtual JDFEmployee appendEmployee()
      {
         return (JDFEmployee)appendElement(ElementName.EMPLOYEE, null);
      }
   }
}
