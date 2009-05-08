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
   using JDFModuleStatus = org.cip4.jdflib.resource.JDFModuleStatus;
   using JDFPart = org.cip4.jdflib.resource.JDFPart;
   using JDFCostCenter = org.cip4.jdflib.resource.process.JDFCostCenter;
   using JDFMISDetails = org.cip4.jdflib.resource.process.JDFMISDetails;
   using JDFDate = org.cip4.jdflib.util.JDFDate;
   using JDFDuration = org.cip4.jdflib.util.JDFDuration;

   public abstract class JDFAutoJobPhase : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[17];
      static JDFAutoJobPhase()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ACTIVATION, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumActivation.getEnum(0), null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.AMOUNT, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.DEADLINE, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumDeadLine.getEnum(0), null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.JOBID, 0x33333333, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.JOBPARTID, 0x33333333, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.PERCENTCOMPLETED, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.PHASEAMOUNT, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.PHASESTARTTIME, 0x33333311, AttributeInfo.EnumAttributeType.dateTime, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.PHASEWASTE, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.QUEUEENTRYID, 0x33333333, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[10] = new AtrInfoTable(AttributeName.RESTTIME, 0x33333331, AttributeInfo.EnumAttributeType.duration, null, null);
         atrInfoTable[11] = new AtrInfoTable(AttributeName.SPEED, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[12] = new AtrInfoTable(AttributeName.STARTTIME, 0x33333331, AttributeInfo.EnumAttributeType.dateTime, null, null);
         atrInfoTable[13] = new AtrInfoTable(AttributeName.STATUS, 0x22222222, AttributeInfo.EnumAttributeType.enumeration, EnumNodeStatus.getEnum(0), null);
         atrInfoTable[14] = new AtrInfoTable(AttributeName.STATUSDETAILS, 0x33333333, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[15] = new AtrInfoTable(AttributeName.TOTALAMOUNT, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[16] = new AtrInfoTable(AttributeName.WASTE, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.COSTCENTER, 0x66666666);
         elemInfoTable[1] = new ElemInfoTable(ElementName.MISDETAILS, 0x66666611);
         elemInfoTable[2] = new ElemInfoTable(ElementName.MODULESTATUS, 0x33333111);
         elemInfoTable[3] = new ElemInfoTable(ElementName.PART, 0x33333333);
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
      ///     <summary> * Constructor for JDFAutoJobPhase </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoJobPhase(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoJobPhase </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoJobPhase(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoJobPhase </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoJobPhase(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoJobPhase[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for Activation </summary>
      ///        

      public class EnumActivation : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumActivation(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumActivation getEnum(string enumName)
         {
            return (EnumActivation)getEnum(typeof(EnumActivation), enumName);
         }

         public static EnumActivation getEnum(int enumValue)
         {
            return (EnumActivation)getEnum(typeof(EnumActivation), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumActivation));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumActivation));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumActivation));
         }

         public static readonly EnumActivation Inactive = new EnumActivation("Inactive");
         public static readonly EnumActivation Informative = new EnumActivation("Informative");
         public static readonly EnumActivation Held = new EnumActivation("Held");
         public static readonly EnumActivation Active = new EnumActivation("Active");
         public static readonly EnumActivation TestRun = new EnumActivation("TestRun");
         public static readonly EnumActivation TestRunAndGo = new EnumActivation("TestRunAndGo");
      }



      ///        
      ///        <summary> * Enumeration strings for DeadLine </summary>
      ///        

      public class EnumDeadLine : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumDeadLine(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumDeadLine getEnum(string enumName)
         {
            return (EnumDeadLine)getEnum(typeof(EnumDeadLine), enumName);
         }

         public static EnumDeadLine getEnum(int enumValue)
         {
            return (EnumDeadLine)getEnum(typeof(EnumDeadLine), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumDeadLine));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumDeadLine));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumDeadLine));
         }

         public static readonly EnumDeadLine InTime = new EnumDeadLine("InTime");
         public static readonly EnumDeadLine Warning = new EnumDeadLine("Warning");
         public static readonly EnumDeadLine Late = new EnumDeadLine("Late");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute Activation
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Activation </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setActivation(EnumActivation enumVar)
      {
         setAttribute(AttributeName.ACTIVATION, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Activation </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumActivation getActivation()
      {
         return EnumActivation.getEnum(getAttribute(AttributeName.ACTIVATION, null, null));
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
      //        Methods for Attribute DeadLine
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute DeadLine </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setDeadLine(EnumDeadLine enumVar)
      {
         setAttribute(AttributeName.DEADLINE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute DeadLine </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumDeadLine getDeadLine()
      {
         return EnumDeadLine.getEnum(getAttribute(AttributeName.DEADLINE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute JobID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute JobID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setJobID(string @value)
      {
         setAttribute(AttributeName.JOBID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute JobID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getJobID()
      {
         return getAttribute(AttributeName.JOBID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute JobPartID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute JobPartID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setJobPartID(string @value)
      {
         setAttribute(AttributeName.JOBPARTID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute JobPartID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getJobPartID()
      {
         return getAttribute(AttributeName.JOBPARTID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PercentCompleted
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PercentCompleted </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPercentCompleted(double @value)
      {
         setAttribute(AttributeName.PERCENTCOMPLETED, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute PercentCompleted </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getPercentCompleted()
      {
         return getRealAttribute(AttributeName.PERCENTCOMPLETED, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PhaseAmount
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PhaseAmount </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPhaseAmount(double @value)
      {
         setAttribute(AttributeName.PHASEAMOUNT, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute PhaseAmount </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getPhaseAmount()
      {
         return getRealAttribute(AttributeName.PHASEAMOUNT, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PhaseStartTime
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (11) set attribute PhaseStartTime </summary>
      ///          * <param name="value">: the value to set the attribute to or null </param>
      ///          
      public virtual void setPhaseStartTime(JDFDate @value)
      {
         JDFDate date = @value;
         if (date == null)
            date = new JDFDate();
         setAttribute(AttributeName.PHASESTARTTIME, date.DateTimeISO, null);
      }

      ///        
      ///          <summary> * (12) get JDFDate attribute PhaseStartTime </summary>
      ///          * <returns> JDFDate the value of the attribute </returns>
      ///          
      public virtual JDFDate getPhaseStartTime()
      {
         JDFDate nMyDate = null;
         string str = JDFConstants.EMPTYSTRING;
         str = getAttribute(AttributeName.PHASESTARTTIME, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute PhaseWaste
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PhaseWaste </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPhaseWaste(double @value)
      {
         setAttribute(AttributeName.PHASEWASTE, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute PhaseWaste </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getPhaseWaste()
      {
         return getRealAttribute(AttributeName.PHASEWASTE, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute QueueEntryID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute QueueEntryID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setQueueEntryID(string @value)
      {
         setAttribute(AttributeName.QUEUEENTRYID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute QueueEntryID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getQueueEntryID()
      {
         return getAttribute(AttributeName.QUEUEENTRYID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute RestTime
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute RestTime </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setRestTime(JDFDuration @value)
      {
         setAttribute(AttributeName.RESTTIME, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFDuration attribute RestTime </summary>
      ///          * <returns> JDFDuration the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFDuration </returns>
      ///          
      public virtual JDFDuration getRestTime()
      {
         string strAttrName = "";
         JDFDuration nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.RESTTIME, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute StartTime
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (11) set attribute StartTime </summary>
      ///          * <param name="value">: the value to set the attribute to or null </param>
      ///          
      public virtual void setStartTime(JDFDate @value)
      {
         JDFDate date = @value;
         if (date == null)
            date = new JDFDate();
         setAttribute(AttributeName.STARTTIME, date.DateTimeISO, null);
      }

      ///        
      ///          <summary> * (12) get JDFDate attribute StartTime </summary>
      ///          * <returns> JDFDate the value of the attribute </returns>
      ///          
      public virtual JDFDate getStartTime()
      {
         JDFDate nMyDate = null;
         string str = JDFConstants.EMPTYSTRING;
         str = getAttribute(AttributeName.STARTTIME, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute TotalAmount
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TotalAmount </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTotalAmount(double @value)
      {
         setAttribute(AttributeName.TOTALAMOUNT, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute TotalAmount </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getTotalAmount()
      {
         return getRealAttribute(AttributeName.TOTALAMOUNT, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Waste
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Waste </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setWaste(double @value)
      {
         setAttribute(AttributeName.WASTE, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute Waste </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getWaste()
      {
         return getRealAttribute(AttributeName.WASTE, null, 0.0);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

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
