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
   using JDFAudit = org.cip4.jdflib.core.JDFAudit;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFPart = org.cip4.jdflib.resource.JDFPart;
   using JDFCostCenter = org.cip4.jdflib.resource.process.JDFCostCenter;
   using JDFEmployee = org.cip4.jdflib.resource.process.JDFEmployee;

   public abstract class JDFAutoNotification : JDFAudit
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[4];
      static JDFAutoNotification()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.CLASS, 0x22222222, AttributeInfo.EnumAttributeType.enumeration, EnumClass.getEnum(0), null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.JOBID, 0x33333111, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.JOBPARTID, 0x33333111, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.TYPE, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.COSTCENTER, 0x66666666);
         elemInfoTable[1] = new ElemInfoTable(ElementName.EMPLOYEE, 0x33333333);
         elemInfoTable[2] = new ElemInfoTable(ElementName.PART, 0x33333331);
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
      ///     <summary> * Constructor for JDFAutoNotification </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoNotification(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoNotification </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoNotification(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoNotification </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoNotification(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoNotification[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for Class </summary>
      ///        

      public class EnumClass : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumClass(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumClass getEnum(string enumName)
         {
            return (EnumClass)getEnum(typeof(EnumClass), enumName);
         }

         public static EnumClass getEnum(int enumValue)
         {
            return (EnumClass)getEnum(typeof(EnumClass), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumClass));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumClass));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumClass));
         }

         public static readonly EnumClass Event = new EnumClass("Event");
         public static readonly EnumClass Information = new EnumClass("Information");
         public static readonly EnumClass Warning = new EnumClass("Warning");
         public static readonly EnumClass Error = new EnumClass("Error");
         public static readonly EnumClass Fatal = new EnumClass("Fatal");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute Class
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Class </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setClass(EnumClass enumVar)
      {
         setAttribute(AttributeName.CLASS, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (6) get EnumClass attribute Class </summary>
      ///          * <returns> EnumClass the value of the attribute </returns>
      ///          
      public virtual EnumClass getClassJDF()
      {
         return EnumClass.getEnum(getAttribute(AttributeName.CLASS, null, null));
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
