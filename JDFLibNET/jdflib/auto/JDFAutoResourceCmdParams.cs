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
   using JDFPart = org.cip4.jdflib.resource.JDFPart;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFMISDetails = org.cip4.jdflib.resource.process.JDFMISDetails;

   public abstract class JDFAutoResourceCmdParams : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[13];
      static JDFAutoResourceCmdParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ACTIVATION, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumActivation.getEnum(0), "Active");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.EXACT, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.JOBID, 0x33333333, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.JOBPARTID, 0x33333333, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.PROCESSUSAGE, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.PRODUCTID, 0x33333311, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.PRODUCTIONAMOUNT, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.QUEUEENTRYID, 0x33333311, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.RESOURCENAME, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.RESOURCEID, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[10] = new AtrInfoTable(AttributeName.STATUS, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, JDFResource.EnumResStatus.getEnum(0), null);
         atrInfoTable[11] = new AtrInfoTable(AttributeName.UPDATEIDS, 0x33333331, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable[12] = new AtrInfoTable(AttributeName.UPDATEMETHOD, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumUpdateMethod.getEnum(0), "Complete");
         elemInfoTable[0] = new ElemInfoTable(ElementName.PART, 0x33333311);
         elemInfoTable[1] = new ElemInfoTable(ElementName.MISDETAILS, 0x66666611);
         elemInfoTable[2] = new ElemInfoTable(ElementName.RESOURCE, 0x33333333);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[3];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoResourceCmdParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoResourceCmdParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoResourceCmdParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoResourceCmdParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoResourceCmdParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoResourceCmdParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoResourceCmdParams[  --> " + base.ToString() + " ]";
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

         public static readonly EnumActivation Held = new EnumActivation("Held");
         public static readonly EnumActivation Active = new EnumActivation("Active");
         public static readonly EnumActivation TestRun = new EnumActivation("TestRun");
         public static readonly EnumActivation TestRunAndGo = new EnumActivation("TestRunAndGo");
      }



      ///        
      ///        <summary> * Enumeration strings for UpdateMethod </summary>
      ///        

      public class EnumUpdateMethod : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumUpdateMethod(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumUpdateMethod getEnum(string enumName)
         {
            return (EnumUpdateMethod)getEnum(typeof(EnumUpdateMethod), enumName);
         }

         public static EnumUpdateMethod getEnum(int enumValue)
         {
            return (EnumUpdateMethod)getEnum(typeof(EnumUpdateMethod), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumUpdateMethod));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumUpdateMethod));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumUpdateMethod));
         }

         public static readonly EnumUpdateMethod Complete = new EnumUpdateMethod("Complete");
         public static readonly EnumUpdateMethod Incremental = new EnumUpdateMethod("Incremental");
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
         return EnumActivation.getEnum(getAttribute(AttributeName.ACTIVATION, null, "Active"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Exact
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Exact </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setExact(bool @value)
      {
         setAttribute(AttributeName.EXACT, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute Exact </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getExact()
      {
         return getBoolAttribute(AttributeName.EXACT, null, false);
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
      //        Methods for Attribute ProductionAmount
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ProductionAmount </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setProductionAmount(double @value)
      {
         setAttribute(AttributeName.PRODUCTIONAMOUNT, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute ProductionAmount </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getProductionAmount()
      {
         return getRealAttribute(AttributeName.PRODUCTIONAMOUNT, null, 0.0);
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
      //        Methods for Attribute UpdateIDs
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute UpdateIDs </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setUpdateIDs(VString @value)
      {
         setAttribute(AttributeName.UPDATEIDS, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute UpdateIDs </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getUpdateIDs()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.UPDATEIDS, null, JDFConstants.EMPTYSTRING);
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute UpdateMethod
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute UpdateMethod </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setUpdateMethod(EnumUpdateMethod enumVar)
      {
         setAttribute(AttributeName.UPDATEMETHOD, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute UpdateMethod </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumUpdateMethod getUpdateMethod()
      {
         return EnumUpdateMethod.getEnum(getAttribute(AttributeName.UPDATEMETHOD, null, "Complete"));
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

      ///     <summary> (26) getCreateResource
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFResource the element </returns>
      ///     
      public virtual JDFResource getCreateResource(int iSkip)
      {
         return (JDFResource)getCreateElement_KElement(ElementName.RESOURCE, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Resource </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFResource the element </returns>
      ///     * default is getResource(0)     
      public virtual JDFResource getResource(int iSkip)
      {
         return (JDFResource)getElement(ElementName.RESOURCE, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Resource from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFResource> </returns>
      ///     
      public virtual ICollection<JDFResource> getAllResource()
      {
         List<JDFResource> v = new List<JDFResource>();

         JDFResource kElem = (JDFResource)getFirstChildElement(ElementName.RESOURCE, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFResource)kElem.getNextSiblingElement(ElementName.RESOURCE, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Resource </summary>
      ///     
      public virtual JDFResource appendResource()
      {
         return (JDFResource)appendElement(ElementName.RESOURCE, null);
      }
   }
}
