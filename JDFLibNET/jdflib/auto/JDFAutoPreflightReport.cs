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
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFPRItem = org.cip4.jdflib.resource.process.JDFPRItem;
   using JDFPreflightParams = org.cip4.jdflib.resource.process.JDFPreflightParams;
   using JDFPreflightReportRulePool = org.cip4.jdflib.resource.process.JDFPreflightReportRulePool;
   using JDFRunList = org.cip4.jdflib.resource.process.JDFRunList;

   public abstract class JDFAutoPreflightReport : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[3];
      static JDFAutoPreflightReport()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ERRORCOUNT, 0x22222211, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.WARNINGCOUNT, 0x22222211, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.ERRORSTATE, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumErrorState.getEnum(0), null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.PREFLIGHTPARAMS, 0x55555511);
         elemInfoTable[1] = new ElemInfoTable(ElementName.PREFLIGHTREPORTRULEPOOL, 0x55555511);
         elemInfoTable[2] = new ElemInfoTable(ElementName.RUNLIST, 0x55555511);
         elemInfoTable[3] = new ElemInfoTable(ElementName.PRITEM, 0x33333311);
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
      ///     <summary> * Constructor for JDFAutoPreflightReport </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPreflightReport(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPreflightReport </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPreflightReport(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPreflightReport </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoPreflightReport(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoPreflightReport[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for ErrorState </summary>
      ///        

      public class EnumErrorState : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumErrorState(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumErrorState getEnum(string enumName)
         {
            return (EnumErrorState)getEnum(typeof(EnumErrorState), enumName);
         }

         public static EnumErrorState getEnum(int enumValue)
         {
            return (EnumErrorState)getEnum(typeof(EnumErrorState), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumErrorState));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumErrorState));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumErrorState));
         }

         public static readonly EnumErrorState TestNotSupported = new EnumErrorState("TestNotSupported");
         public static readonly EnumErrorState TestWrongPDL = new EnumErrorState("TestWrongPDL");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute ErrorCount
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ErrorCount </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setErrorCount(int @value)
      {
         setAttribute(AttributeName.ERRORCOUNT, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute ErrorCount </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getErrorCount()
      {
         return getIntAttribute(AttributeName.ERRORCOUNT, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute WarningCount
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute WarningCount </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setWarningCount(int @value)
      {
         setAttribute(AttributeName.WARNINGCOUNT, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute WarningCount </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getWarningCount()
      {
         return getIntAttribute(AttributeName.WARNINGCOUNT, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ErrorState
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute ErrorState </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setErrorState(EnumErrorState enumVar)
      {
         setAttribute(AttributeName.ERRORSTATE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute ErrorState </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumErrorState getErrorState()
      {
         return EnumErrorState.getEnum(getAttribute(AttributeName.ERRORSTATE, null, null));
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element PreflightParams </summary>
      ///     * <returns> JDFPreflightParams the element </returns>
      ///     
      public virtual JDFPreflightParams getPreflightParams()
      {
         return (JDFPreflightParams)getElement(ElementName.PREFLIGHTPARAMS, null, 0);
      }

      ///     <summary> (25) getCreatePreflightParams
      ///     *  </summary>
      ///     * <returns> JDFPreflightParams the element </returns>
      ///     
      public virtual JDFPreflightParams getCreatePreflightParams()
      {
         return (JDFPreflightParams)getCreateElement_KElement(ElementName.PREFLIGHTPARAMS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element PreflightParams </summary>
      ///     
      public virtual JDFPreflightParams appendPreflightParams()
      {
         return (JDFPreflightParams)appendElementN(ElementName.PREFLIGHTPARAMS, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refPreflightParams(JDFPreflightParams refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element PreflightReportRulePool </summary>
      ///     * <returns> JDFPreflightReportRulePool the element </returns>
      ///     
      public virtual JDFPreflightReportRulePool getPreflightReportRulePool()
      {
         return (JDFPreflightReportRulePool)getElement(ElementName.PREFLIGHTREPORTRULEPOOL, null, 0);
      }

      ///     <summary> (25) getCreatePreflightReportRulePool
      ///     *  </summary>
      ///     * <returns> JDFPreflightReportRulePool the element </returns>
      ///     
      public virtual JDFPreflightReportRulePool getCreatePreflightReportRulePool()
      {
         return (JDFPreflightReportRulePool)getCreateElement_KElement(ElementName.PREFLIGHTREPORTRULEPOOL, null, 0);
      }

      ///    
      ///     <summary> * (29) append element PreflightReportRulePool </summary>
      ///     
      public virtual JDFPreflightReportRulePool appendPreflightReportRulePool()
      {
         return (JDFPreflightReportRulePool)appendElementN(ElementName.PREFLIGHTREPORTRULEPOOL, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refPreflightReportRulePool(JDFPreflightReportRulePool refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element RunList </summary>
      ///     * <returns> JDFRunList the element </returns>
      ///     
      public virtual JDFRunList getRunList()
      {
         return (JDFRunList)getElement(ElementName.RUNLIST, null, 0);
      }

      ///     <summary> (25) getCreateRunList
      ///     *  </summary>
      ///     * <returns> JDFRunList the element </returns>
      ///     
      public virtual JDFRunList getCreateRunList()
      {
         return (JDFRunList)getCreateElement_KElement(ElementName.RUNLIST, null, 0);
      }

      ///    
      ///     <summary> * (29) append element RunList </summary>
      ///     
      public virtual JDFRunList appendRunList()
      {
         return (JDFRunList)appendElementN(ElementName.RUNLIST, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refRunList(JDFRunList refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreatePRItem
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFPRItem the element </returns>
      ///     
      public virtual JDFPRItem getCreatePRItem(int iSkip)
      {
         return (JDFPRItem)getCreateElement_KElement(ElementName.PRITEM, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element PRItem </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFPRItem the element </returns>
      ///     * default is getPRItem(0)     
      public virtual JDFPRItem getPRItem(int iSkip)
      {
         return (JDFPRItem)getElement(ElementName.PRITEM, null, iSkip);
      }

      ///    
      ///     <summary> * Get all PRItem from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFPRItem> </returns>
      ///     
      public virtual ICollection<JDFPRItem> getAllPRItem()
      {
         List<JDFPRItem> v = new List<JDFPRItem>();

         JDFPRItem kElem = (JDFPRItem)getFirstChildElement(ElementName.PRITEM, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFPRItem)kElem.getNextSiblingElement(ElementName.PRITEM, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element PRItem </summary>
      ///     
      public virtual JDFPRItem appendPRItem()
      {
         return (JDFPRItem)appendElement(ElementName.PRITEM, null);
      }
   }
}
