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
   using JDFPart = org.cip4.jdflib.resource.JDFPart;

   public abstract class JDFAutoStatusQuParams : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[7];
      static JDFAutoStatusQuParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.DEVICEDETAILS, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumDeviceDetails.getEnum(0), "None");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.EMPLOYEEINFO, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.JOBDETAILS, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumJobDetails.getEnum(0), "None");
         atrInfoTable[3] = new AtrInfoTable(AttributeName.JOBID, 0x33333333, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.JOBPARTID, 0x33333333, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.QUEUEENTRYID, 0x33333311, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.QUEUEINFO, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         elemInfoTable[0] = new ElemInfoTable(ElementName.PART, 0x33333311);
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
      ///     <summary> * Constructor for JDFAutoStatusQuParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoStatusQuParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoStatusQuParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoStatusQuParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoStatusQuParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoStatusQuParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoStatusQuParams[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for DeviceDetails </summary>
      ///        

      public class EnumDeviceDetails : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumDeviceDetails(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumDeviceDetails getEnum(string enumName)
         {
            return (EnumDeviceDetails)getEnum(typeof(EnumDeviceDetails), enumName);
         }

         public static EnumDeviceDetails getEnum(int enumValue)
         {
            return (EnumDeviceDetails)getEnum(typeof(EnumDeviceDetails), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumDeviceDetails));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumDeviceDetails));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumDeviceDetails));
         }

         public static readonly EnumDeviceDetails None = new EnumDeviceDetails("None");
         public static readonly EnumDeviceDetails Brief = new EnumDeviceDetails("Brief");
         public static readonly EnumDeviceDetails Modules = new EnumDeviceDetails("Modules");
         public static readonly EnumDeviceDetails Details = new EnumDeviceDetails("Details");
         public static readonly EnumDeviceDetails Capability = new EnumDeviceDetails("Capability");
         public static readonly EnumDeviceDetails Full = new EnumDeviceDetails("Full");
      }



      ///        
      ///        <summary> * Enumeration strings for JobDetails </summary>
      ///        

      public class EnumJobDetails : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumJobDetails(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumJobDetails getEnum(string enumName)
         {
            return (EnumJobDetails)getEnum(typeof(EnumJobDetails), enumName);
         }

         public static EnumJobDetails getEnum(int enumValue)
         {
            return (EnumJobDetails)getEnum(typeof(EnumJobDetails), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumJobDetails));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumJobDetails));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumJobDetails));
         }

         public static readonly EnumJobDetails None = new EnumJobDetails("None");
         public static readonly EnumJobDetails MIS = new EnumJobDetails("MIS");
         public static readonly EnumJobDetails Brief = new EnumJobDetails("Brief");
         public static readonly EnumJobDetails Full = new EnumJobDetails("Full");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute DeviceDetails
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute DeviceDetails </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setDeviceDetails(EnumDeviceDetails enumVar)
      {
         setAttribute(AttributeName.DEVICEDETAILS, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute DeviceDetails </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumDeviceDetails getDeviceDetails()
      {
         return EnumDeviceDetails.getEnum(getAttribute(AttributeName.DEVICEDETAILS, null, "None"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute EmployeeInfo
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute EmployeeInfo </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setEmployeeInfo(bool @value)
      {
         setAttribute(AttributeName.EMPLOYEEINFO, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute EmployeeInfo </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getEmployeeInfo()
      {
         return getBoolAttribute(AttributeName.EMPLOYEEINFO, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute JobDetails
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute JobDetails </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setJobDetails(EnumJobDetails enumVar)
      {
         setAttribute(AttributeName.JOBDETAILS, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute JobDetails </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumJobDetails getJobDetails()
      {
         return EnumJobDetails.getEnum(getAttribute(AttributeName.JOBDETAILS, null, "None"));
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
      //        Methods for Attribute QueueInfo
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute QueueInfo </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setQueueInfo(bool @value)
      {
         setAttribute(AttributeName.QUEUEINFO, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute QueueInfo </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getQueueInfo()
      {
         return getBoolAttribute(AttributeName.QUEUEINFO, null, false);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

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
