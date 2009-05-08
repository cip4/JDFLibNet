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
   using JDFModule = org.cip4.jdflib.resource.devicecapability.JDFModule;

   public abstract class JDFAutoModule : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[12];
      static JDFAutoModule()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.DEVICETYPE, 0x33333111, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.MANUFACTURER, 0x33333111, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.MANUFACTURERURL, 0x33333111, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.MODELDESCRIPTION, 0x33333111, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.MODELNAME, 0x33333111, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.MODELNUMBER, 0x33333111, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.MODELURL, 0x33333111, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.MODULEID, 0x33333111, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.MODULEINDEX, 0x33333111, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.MODULETYPE, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[10] = new AtrInfoTable(AttributeName.SERIALNUMBER, 0x33333111, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[11] = new AtrInfoTable(AttributeName.SUBMODULEINDEX, 0x33333111, AttributeInfo.EnumAttributeType.integer, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.MODULE, 0x33333111);
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
      ///     <summary> * Constructor for JDFAutoModule </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoModule(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoModule </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoModule(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoModule </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoModule(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoModule[  --> " + base.ToString() + " ]";
      }


      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute DeviceType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DeviceType </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDeviceType(string @value)
      {
         setAttribute(AttributeName.DEVICETYPE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute DeviceType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getDeviceType()
      {
         return getAttribute(AttributeName.DEVICETYPE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Manufacturer
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Manufacturer </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setManufacturer(string @value)
      {
         setAttribute(AttributeName.MANUFACTURER, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Manufacturer </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getManufacturer()
      {
         return getAttribute(AttributeName.MANUFACTURER, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ManufacturerURL
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ManufacturerURL </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setManufacturerURL(string @value)
      {
         setAttribute(AttributeName.MANUFACTURERURL, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ManufacturerURL </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getManufacturerURL()
      {
         return getAttribute(AttributeName.MANUFACTURERURL, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ModelDescription
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ModelDescription </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setModelDescription(string @value)
      {
         setAttribute(AttributeName.MODELDESCRIPTION, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ModelDescription </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getModelDescription()
      {
         return getAttribute(AttributeName.MODELDESCRIPTION, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ModelName
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ModelName </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setModelName(string @value)
      {
         setAttribute(AttributeName.MODELNAME, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ModelName </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getModelName()
      {
         return getAttribute(AttributeName.MODELNAME, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ModelNumber
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ModelNumber </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setModelNumber(string @value)
      {
         setAttribute(AttributeName.MODELNUMBER, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ModelNumber </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getModelNumber()
      {
         return getAttribute(AttributeName.MODELNUMBER, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ModelURL
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ModelURL </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setModelURL(string @value)
      {
         setAttribute(AttributeName.MODELURL, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ModelURL </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getModelURL()
      {
         return getAttribute(AttributeName.MODELURL, null, JDFConstants.EMPTYSTRING);
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
      public virtual void setModuleIndex(int @value)
      {
         setAttribute(AttributeName.MODULEINDEX, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute ModuleIndex </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getModuleIndex()
      {
         return getIntAttribute(AttributeName.MODULEINDEX, null, 0);
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
      //        Methods for Attribute SerialNumber
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SerialNumber </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSerialNumber(string @value)
      {
         setAttribute(AttributeName.SERIALNUMBER, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute SerialNumber </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getSerialNumber()
      {
         return getAttribute(AttributeName.SERIALNUMBER, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SubModuleIndex
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SubModuleIndex </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSubModuleIndex(int @value)
      {
         setAttribute(AttributeName.SUBMODULEINDEX, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute SubModuleIndex </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getSubModuleIndex()
      {
         return getIntAttribute(AttributeName.SUBMODULEINDEX, null, 0);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateModule
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFModule the element </returns>
      ///     
      public virtual JDFModule getCreateModule(int iSkip)
      {
         return (JDFModule)getCreateElement_KElement(ElementName.MODULE, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Module </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFModule the element </returns>
      ///     * default is getModule(0)     
      public virtual JDFModule getModule(int iSkip)
      {
         return (JDFModule)getElement(ElementName.MODULE, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Module from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFModule> </returns>
      ///     
      public virtual ICollection<JDFModule> getAllModule()
      {
         List<JDFModule> v = new List<JDFModule>();

         JDFModule kElem = (JDFModule)getFirstChildElement(ElementName.MODULE, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFModule)kElem.getNextSiblingElement(ElementName.MODULE, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Module </summary>
      ///     
      public virtual JDFModule appendModule()
      {
         return (JDFModule)appendElement(ElementName.MODULE, null);
      }
   }
}
