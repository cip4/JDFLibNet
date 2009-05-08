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
   using JDFJobPhase = org.cip4.jdflib.jmf.JDFJobPhase;
   using JDFDevice = org.cip4.jdflib.resource.JDFDevice;
   using JDFModuleStatus = org.cip4.jdflib.resource.JDFModuleStatus;
   using JDFEmployee = org.cip4.jdflib.resource.process.JDFEmployee;
   using JDFDate = org.cip4.jdflib.util.JDFDate;
   using JDFDuration = org.cip4.jdflib.util.JDFDuration;

   public abstract class JDFAutoDeviceInfo : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[11];
      static JDFAutoDeviceInfo()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.COUNTERUNIT, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.DEVICECONDITION, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumDeviceCondition.getEnum(0), null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.DEVICEID, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.DEVICEOPERATIONMODE, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumDeviceOperationMode.getEnum(0), null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.DEVICESTATUS, 0x22222222, AttributeInfo.EnumAttributeType.enumeration, EnumDeviceStatus.getEnum(0), null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.HOURCOUNTER, 0x33333333, AttributeInfo.EnumAttributeType.duration, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.POWERONTIME, 0x33333333, AttributeInfo.EnumAttributeType.dateTime, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.PRODUCTIONCOUNTER, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.SPEED, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.STATUSDETAILS, 0x33333333, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[10] = new AtrInfoTable(AttributeName.TOTALPRODUCTIONCOUNTER, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.DEVICE, 0x66666666);
         elemInfoTable[1] = new ElemInfoTable(ElementName.EMPLOYEE, 0x33333333);
         elemInfoTable[2] = new ElemInfoTable(ElementName.JOBPHASE, 0x33333333);
         elemInfoTable[3] = new ElemInfoTable(ElementName.MODULESTATUS, 0x33333333);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[4];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoDeviceInfo </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoDeviceInfo(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoDeviceInfo </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoDeviceInfo(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoDeviceInfo </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoDeviceInfo(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoDeviceInfo[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for DeviceCondition </summary>
      ///        

      public class EnumDeviceCondition : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumDeviceCondition(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumDeviceCondition getEnum(string enumName)
         {
            return (EnumDeviceCondition)getEnum(typeof(EnumDeviceCondition), enumName);
         }

         public static EnumDeviceCondition getEnum(int enumValue)
         {
            return (EnumDeviceCondition)getEnum(typeof(EnumDeviceCondition), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumDeviceCondition));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumDeviceCondition));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumDeviceCondition));
         }

         public static readonly EnumDeviceCondition OK = new EnumDeviceCondition("OK");
         public static readonly EnumDeviceCondition NeedsAttention = new EnumDeviceCondition("NeedsAttention");
         public static readonly EnumDeviceCondition Failure = new EnumDeviceCondition("Failure");
         public static readonly EnumDeviceCondition OffLine = new EnumDeviceCondition("OffLine");
      }



      ///        
      ///        <summary> * Enumeration strings for DeviceOperationMode </summary>
      ///        

      public class EnumDeviceOperationMode : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumDeviceOperationMode(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumDeviceOperationMode getEnum(string enumName)
         {
            return (EnumDeviceOperationMode)getEnum(typeof(EnumDeviceOperationMode), enumName);
         }

         public static EnumDeviceOperationMode getEnum(int enumValue)
         {
            return (EnumDeviceOperationMode)getEnum(typeof(EnumDeviceOperationMode), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumDeviceOperationMode));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumDeviceOperationMode));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumDeviceOperationMode));
         }

         public static readonly EnumDeviceOperationMode Productive = new EnumDeviceOperationMode("Productive");
         public static readonly EnumDeviceOperationMode NonProductive = new EnumDeviceOperationMode("NonProductive");
         public static readonly EnumDeviceOperationMode Maintenance = new EnumDeviceOperationMode("Maintenance");
      }



      ///        
      ///        <summary> * Enumeration strings for DeviceStatus </summary>
      ///        

      public class EnumDeviceStatus : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumDeviceStatus(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumDeviceStatus getEnum(string enumName)
         {
            return (EnumDeviceStatus)getEnum(typeof(EnumDeviceStatus), enumName);
         }

         public static EnumDeviceStatus getEnum(int enumValue)
         {
            return (EnumDeviceStatus)getEnum(typeof(EnumDeviceStatus), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumDeviceStatus));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumDeviceStatus));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumDeviceStatus));
         }

         public static readonly EnumDeviceStatus Unknown = new EnumDeviceStatus("Unknown");
         public static readonly EnumDeviceStatus Idle = new EnumDeviceStatus("Idle");
         public static readonly EnumDeviceStatus Down = new EnumDeviceStatus("Down");
         public static readonly EnumDeviceStatus Setup = new EnumDeviceStatus("Setup");
         public static readonly EnumDeviceStatus Running = new EnumDeviceStatus("Running");
         public static readonly EnumDeviceStatus Cleanup = new EnumDeviceStatus("Cleanup");
         public static readonly EnumDeviceStatus Stopped = new EnumDeviceStatus("Stopped");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute CounterUnit
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CounterUnit </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCounterUnit(string @value)
      {
         setAttribute(AttributeName.COUNTERUNIT, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute CounterUnit </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getCounterUnit()
      {
         return getAttribute(AttributeName.COUNTERUNIT, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute DeviceCondition
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute DeviceCondition </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setDeviceCondition(EnumDeviceCondition enumVar)
      {
         setAttribute(AttributeName.DEVICECONDITION, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute DeviceCondition </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumDeviceCondition getDeviceCondition()
      {
         return EnumDeviceCondition.getEnum(getAttribute(AttributeName.DEVICECONDITION, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute DeviceID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DeviceID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDeviceID(string @value)
      {
         setAttribute(AttributeName.DEVICEID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute DeviceID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getDeviceID()
      {
         return getAttribute(AttributeName.DEVICEID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute DeviceOperationMode
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute DeviceOperationMode </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setDeviceOperationMode(EnumDeviceOperationMode enumVar)
      {
         setAttribute(AttributeName.DEVICEOPERATIONMODE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute DeviceOperationMode </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumDeviceOperationMode getDeviceOperationMode()
      {
         return EnumDeviceOperationMode.getEnum(getAttribute(AttributeName.DEVICEOPERATIONMODE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute DeviceStatus
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute DeviceStatus </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setDeviceStatus(EnumDeviceStatus enumVar)
      {
         setAttribute(AttributeName.DEVICESTATUS, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute DeviceStatus </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumDeviceStatus getDeviceStatus()
      {
         return EnumDeviceStatus.getEnum(getAttribute(AttributeName.DEVICESTATUS, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute HourCounter
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute HourCounter </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setHourCounter(JDFDuration @value)
      {
         setAttribute(AttributeName.HOURCOUNTER, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFDuration attribute HourCounter </summary>
      ///          * <returns> JDFDuration the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFDuration </returns>
      ///          
      public virtual JDFDuration getHourCounter()
      {
         string strAttrName = "";
         JDFDuration nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.HOURCOUNTER, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFDuration(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PowerOnTime
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (11) set attribute PowerOnTime </summary>
      ///          * <param name="value">: the value to set the attribute to or null </param>
      ///          
      public virtual void setPowerOnTime(JDFDate @value)
      {
         JDFDate date = @value;
         if (date == null)
            date = new JDFDate();
         setAttribute(AttributeName.POWERONTIME, date.DateTimeISO, null);
      }

      ///        
      ///          <summary> * (12) get JDFDate attribute PowerOnTime </summary>
      ///          * <returns> JDFDate the value of the attribute </returns>
      ///          
      public virtual JDFDate getPowerOnTime()
      {
         JDFDate nMyDate = null;
         string str = JDFConstants.EMPTYSTRING;
         str = getAttribute(AttributeName.POWERONTIME, null, JDFConstants.EMPTYSTRING);
         if (!JDFConstants.EMPTYSTRING.Equals(str))
         {
            try
            {
               nMyDate = new JDFDate(str);
            }
            catch (FormatException)
            {
               // throw new JDFException("not a valid date string. Malformed JDF - return null");
            }
         }
         return nMyDate;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ProductionCounter
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ProductionCounter </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setProductionCounter(double @value)
      {
         setAttribute(AttributeName.PRODUCTIONCOUNTER, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute ProductionCounter </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getProductionCounter()
      {
         return getRealAttribute(AttributeName.PRODUCTIONCOUNTER, null, 0.0);
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


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TotalProductionCounter
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TotalProductionCounter </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTotalProductionCounter(double @value)
      {
         setAttribute(AttributeName.TOTALPRODUCTIONCOUNTER, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute TotalProductionCounter </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getTotalProductionCounter()
      {
         return getRealAttribute(AttributeName.TOTALPRODUCTIONCOUNTER, null, 0.0);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element Device </summary>
      ///     * <returns> JDFDevice the element </returns>
      ///     
      public virtual JDFDevice getDevice()
      {
         return (JDFDevice)getElement(ElementName.DEVICE, null, 0);
      }

      ///     <summary> (25) getCreateDevice
      ///     *  </summary>
      ///     * <returns> JDFDevice the element </returns>
      ///     
      public virtual JDFDevice getCreateDevice()
      {
         return (JDFDevice)getCreateElement_KElement(ElementName.DEVICE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Device </summary>
      ///     
      public virtual JDFDevice appendDevice()
      {
         return (JDFDevice)appendElementN(ElementName.DEVICE, 1, null);
      }

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

      ///     <summary> (26) getCreateJobPhase
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFJobPhase the element </returns>
      ///     
      public virtual JDFJobPhase getCreateJobPhase(int iSkip)
      {
         return (JDFJobPhase)getCreateElement_KElement(ElementName.JOBPHASE, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element JobPhase </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFJobPhase the element </returns>
      ///     * default is getJobPhase(0)     
      public virtual JDFJobPhase getJobPhase(int iSkip)
      {
         return (JDFJobPhase)getElement(ElementName.JOBPHASE, null, iSkip);
      }

      ///    
      ///     <summary> * Get all JobPhase from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFJobPhase> </returns>
      ///     
      public virtual ICollection<JDFJobPhase> getAllJobPhase()
      {
         List<JDFJobPhase> v = new List<JDFJobPhase>();

         JDFJobPhase kElem = (JDFJobPhase)getFirstChildElement(ElementName.JOBPHASE, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFJobPhase)kElem.getNextSiblingElement(ElementName.JOBPHASE, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element JobPhase </summary>
      ///     
      public virtual JDFJobPhase appendJobPhase()
      {
         return (JDFJobPhase)appendElement(ElementName.JOBPHASE, null);
      }

      ///     <summary> (26) getCreateModuleStatus
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFModuleStatus the element </returns>
      ///     
      public virtual JDFModuleStatus getCreateModuleStatus(int iSkip)
      {
         return (JDFModuleStatus)getCreateElement_KElement(ElementName.MODULESTATUS, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element ModuleStatus </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFModuleStatus the element </returns>
      ///     * default is getModuleStatus(0)     
      public virtual JDFModuleStatus getModuleStatus(int iSkip)
      {
         return (JDFModuleStatus)getElement(ElementName.MODULESTATUS, null, iSkip);
      }

      ///    
      ///     <summary> * Get all ModuleStatus from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFModuleStatus> </returns>
      ///     
      public virtual ICollection<JDFModuleStatus> getAllModuleStatus()
      {
         List<JDFModuleStatus> v = new List<JDFModuleStatus>();

         JDFModuleStatus kElem = (JDFModuleStatus)getFirstChildElement(ElementName.MODULESTATUS, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFModuleStatus)kElem.getNextSiblingElement(ElementName.MODULESTATUS, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element ModuleStatus </summary>
      ///     
      public virtual JDFModuleStatus appendModuleStatus()
      {
         return (JDFModuleStatus)appendElement(ElementName.MODULESTATUS, null);
      }
   }
}
