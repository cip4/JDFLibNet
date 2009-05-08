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


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFCustomerInfo = org.cip4.jdflib.core.JDFCustomerInfo;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFNodeInfo = org.cip4.jdflib.core.JDFNodeInfo;
   using VString = org.cip4.jdflib.core.VString;

   public abstract class JDFAutoAncestor : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[19];
      static JDFAutoAncestor()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ACTIVATION, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumActivation.getEnum(0), null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.FILENAME, 0x33333333, AttributeInfo.EnumAttributeType.URL, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.ICSVERSIONS, 0x33333311, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.JOBID, 0x33333333, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.JOBPARTID, 0x33333333, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.MAXVERSION, 0x33333311, AttributeInfo.EnumAttributeType.JDFJMFVersion, EnumVersion.getEnum(0), null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.NODEID, 0x22222222, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.PROJECTID, 0x33333333, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.RELATEDJOBID, 0x33333311, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.RELATEDJOBPARTID, 0x33333311, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[10] = new AtrInfoTable(AttributeName.SPAWNID, 0x33333331, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[11] = new AtrInfoTable(AttributeName.STATUS, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumNodeStatus.getEnum(0), null);
         atrInfoTable[12] = new AtrInfoTable(AttributeName.STATUSDETAILS, 0x33333311, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[13] = new AtrInfoTable(AttributeName.TEMPLATE, 0x33333331, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[14] = new AtrInfoTable(AttributeName.TEMPLATEID, 0x33333311, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[15] = new AtrInfoTable(AttributeName.TEMPLATEVERSION, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[16] = new AtrInfoTable(AttributeName.TYPE, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[17] = new AtrInfoTable(AttributeName.TYPES, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable[18] = new AtrInfoTable(AttributeName.VERSION, 0x33333333, AttributeInfo.EnumAttributeType.JDFJMFVersion, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.CUSTOMERINFO, 0x66666661);
         elemInfoTable[1] = new ElemInfoTable(ElementName.NODEINFO, 0x66666661);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[2];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoAncestor </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoAncestor(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoAncestor </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoAncestor(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoAncestor </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoAncestor(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      /// <summary>
      /// String representation of this object
      /// </summary>
      /// <returns>string</returns>
      public override string ToString()
      {
         return " JDFAutoAncestor[  --> " + base.ToString() + " ]";
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
      //        Methods for Attribute FileName
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute FileName </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFileName(string @value)
      {
         setAttribute(AttributeName.FILENAME, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute FileName </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getFileName()
      {
         return getAttribute(AttributeName.FILENAME, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ICSVersions
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ICSVersions </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setICSVersions(VString @value)
      {
         setAttribute(AttributeName.ICSVERSIONS, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute ICSVersions </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getICSVersions()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.ICSVERSIONS, null, JDFConstants.EMPTYSTRING);
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
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
      //        Methods for Attribute MaxVersion
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute MaxVersion </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setMaxVersion(EnumVersion enumVar)
      {
         setAttribute(AttributeName.MAXVERSION, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute MaxVersion </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumVersion getMaxVersion()
      {
         return EnumVersion.getEnum(getAttribute(AttributeName.MAXVERSION, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute NodeID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute NodeID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setNodeID(string @value)
      {
         setAttribute(AttributeName.NODEID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute NodeID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getNodeID()
      {
         return getAttribute(AttributeName.NODEID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ProjectID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ProjectID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setProjectID(string @value)
      {
         setAttribute(AttributeName.PROJECTID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ProjectID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getProjectID()
      {
         return getAttribute(AttributeName.PROJECTID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute RelatedJobID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute RelatedJobID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setRelatedJobID(string @value)
      {
         setAttribute(AttributeName.RELATEDJOBID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute RelatedJobID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getRelatedJobID()
      {
         return getAttribute(AttributeName.RELATEDJOBID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute RelatedJobPartID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute RelatedJobPartID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setRelatedJobPartID(string @value)
      {
         setAttribute(AttributeName.RELATEDJOBPARTID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute RelatedJobPartID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getRelatedJobPartID()
      {
         return getAttribute(AttributeName.RELATEDJOBPARTID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SpawnID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SpawnID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSpawnID(string @value)
      {
         setAttribute(AttributeName.SPAWNID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute SpawnID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getSpawnID()
      {
         return getAttribute(AttributeName.SPAWNID, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute Template
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Template </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTemplate(bool @value)
      {
         setAttribute(AttributeName.TEMPLATE, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute Template </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getTemplate()
      {
         return getBoolAttribute(AttributeName.TEMPLATE, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TemplateID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TemplateID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTemplateID(string @value)
      {
         setAttribute(AttributeName.TEMPLATEID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute TemplateID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getTemplateID()
      {
         return getAttribute(AttributeName.TEMPLATEID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TemplateVersion
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TemplateVersion </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTemplateVersion(string @value)
      {
         setAttribute(AttributeName.TEMPLATEVERSION, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute TemplateVersion </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getTemplateVersion()
      {
         return getAttribute(AttributeName.TEMPLATEVERSION, null, JDFConstants.EMPTYSTRING);
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
      ///     <summary> * (24) const get element CustomerInfo </summary>
      ///     * <returns> JDFCustomerInfo the element </returns>
      ///     
      public virtual JDFCustomerInfo getCustomerInfo()
      {
         return (JDFCustomerInfo)getElement(ElementName.CUSTOMERINFO, null, 0);
      }

      ///     <summary> (25) getCreateCustomerInfo
      ///     *  </summary>
      ///     * <returns> JDFCustomerInfo the element </returns>
      ///     
      public virtual JDFCustomerInfo getCreateCustomerInfo()
      {
         return (JDFCustomerInfo)getCreateElement_KElement(ElementName.CUSTOMERINFO, null, 0);
      }

      ///    
      ///     <summary> * (29) append element CustomerInfo </summary>
      ///     
      public virtual JDFCustomerInfo appendCustomerInfo()
      {
         return (JDFCustomerInfo)appendElementN(ElementName.CUSTOMERINFO, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element NodeInfo </summary>
      ///     * <returns> JDFNodeInfo the element </returns>
      ///     
      public virtual JDFNodeInfo getNodeInfo()
      {
         return (JDFNodeInfo)getElement(ElementName.NODEINFO, null, 0);
      }

      ///     <summary> (25) getCreateNodeInfo
      ///     *  </summary>
      ///     * <returns> JDFNodeInfo the element </returns>
      ///     
      public virtual JDFNodeInfo getCreateNodeInfo()
      {
         return (JDFNodeInfo)getCreateElement_KElement(ElementName.NODEINFO, null, 0);
      }

      ///    
      ///     <summary> * (29) append element NodeInfo </summary>
      ///     
      public virtual JDFNodeInfo appendNodeInfo()
      {
         return (JDFNodeInfo)appendElementN(ElementName.NODEINFO, 1, null);
      }
   }
}
