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
   using System.Collections.Generic;



   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFAudit = org.cip4.jdflib.core.JDFAudit;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFDevice = org.cip4.jdflib.resource.JDFDevice;
   using JDFModulePhase = org.cip4.jdflib.resource.JDFModulePhase;
   using JDFPart = org.cip4.jdflib.resource.JDFPart;
   using JDFEmployee = org.cip4.jdflib.resource.process.JDFEmployee;
   using JDFMISDetails = org.cip4.jdflib.resource.process.JDFMISDetails;
   using JDFDate = org.cip4.jdflib.util.JDFDate;

   public abstract class JDFAutoPhaseTime : JDFAudit
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[4];
      static JDFAutoPhaseTime()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.END, 0x33333333, AttributeInfo.EnumAttributeType.dateTime, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.START, 0x22222222, AttributeInfo.EnumAttributeType.dateTime, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.STATUS, 0x22222222, AttributeInfo.EnumAttributeType.enumeration, EnumNodeStatus.getEnum(0), null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.STATUSDETAILS, 0x33333333, AttributeInfo.EnumAttributeType.shortString, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.DEVICE, 0x33333333);
         elemInfoTable[1] = new ElemInfoTable(ElementName.EMPLOYEE, 0x33333333);
         elemInfoTable[2] = new ElemInfoTable(ElementName.MISDETAILS, 0x66666611);
         elemInfoTable[3] = new ElemInfoTable(ElementName.MODULEPHASE, 0x33333333);
         elemInfoTable[4] = new ElemInfoTable(ElementName.PART, 0x33333333);
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
      ///     <summary> * Constructor for JDFAutoPhaseTime </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPhaseTime(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPhaseTime </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPhaseTime(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPhaseTime </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoPhaseTime(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoPhaseTime[  --> " + base.ToString() + " ]";
      }


      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute End
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (11) set attribute End </summary>
      ///          * <param name="value">: the value to set the attribute to or null </param>
      ///          
      public virtual void setEnd(JDFDate @value)
      {
         JDFDate date = @value;
         if (date == null)
            date = new JDFDate();
         setAttribute(AttributeName.END, date.DateTimeISO, null);
      }

      ///        
      ///          <summary> * (12) get JDFDate attribute End </summary>
      ///          * <returns> JDFDate the value of the attribute </returns>
      ///          
      public virtual JDFDate getEnd()
      {
         JDFDate nMyDate = null;
         string str = JDFConstants.EMPTYSTRING;
         str = getAttribute(AttributeName.END, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute Start
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (11) set attribute Start </summary>
      ///          * <param name="value">: the value to set the attribute to or null </param>
      ///          
      public virtual void setStart(JDFDate @value)
      {
         JDFDate date = @value;
         if (date == null)
            date = new JDFDate();
         setAttribute(AttributeName.START, date.DateTimeISO, null);
      }

      ///        
      ///          <summary> * (12) get JDFDate attribute Start </summary>
      ///          * <returns> JDFDate the value of the attribute </returns>
      ///          
      public virtual JDFDate getStart()
      {
         JDFDate nMyDate = null;
         string str = JDFConstants.EMPTYSTRING;
         str = getAttribute(AttributeName.START, null, JDFConstants.EMPTYSTRING);
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

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateDevice
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFDevice the element </returns>
      ///     
      public virtual JDFDevice getCreateDevice(int iSkip)
      {
         return (JDFDevice)getCreateElement_KElement(ElementName.DEVICE, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Device </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFDevice the element </returns>
      ///     * default is getDevice(0)     
      public virtual JDFDevice getDevice(int iSkip)
      {
         return (JDFDevice)getElement(ElementName.DEVICE, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Device from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFDevice> </returns>
      ///     
      public virtual ICollection<JDFDevice> getAllDevice()
      {
         List<JDFDevice> v = new List<JDFDevice>();

         JDFDevice kElem = (JDFDevice)getFirstChildElement(ElementName.DEVICE, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFDevice)kElem.getNextSiblingElement(ElementName.DEVICE, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Device </summary>
      ///     
      public virtual JDFDevice appendDevice()
      {
         return (JDFDevice)appendElement(ElementName.DEVICE, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refDevice(JDFDevice refTarget)
      {
         refElement(refTarget);
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

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refEmployee(JDFEmployee refTarget)
      {
         refElement(refTarget);
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

      ///     <summary> (26) getCreateModulePhase
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFModulePhase the element </returns>
      ///     
      public virtual JDFModulePhase getCreateModulePhase(int iSkip)
      {
         return (JDFModulePhase)getCreateElement_KElement(ElementName.MODULEPHASE, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element ModulePhase </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFModulePhase the element </returns>
      ///     * default is getModulePhase(0)     
      public virtual JDFModulePhase getModulePhase(int iSkip)
      {
         return (JDFModulePhase)getElement(ElementName.MODULEPHASE, null, iSkip);
      }

      ///    
      ///     <summary> * Get all ModulePhase from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFModulePhase> </returns>
      ///     
      public virtual ICollection<JDFModulePhase> getAllModulePhase()
      {
         List<JDFModulePhase> v = new List<JDFModulePhase>();

         JDFModulePhase kElem = (JDFModulePhase)getFirstChildElement(ElementName.MODULEPHASE, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFModulePhase)kElem.getNextSiblingElement(ElementName.MODULEPHASE, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element ModulePhase </summary>
      ///     
      public virtual JDFModulePhase appendModulePhase()
      {
         return (JDFModulePhase)appendElement(ElementName.MODULEPHASE, null);
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
