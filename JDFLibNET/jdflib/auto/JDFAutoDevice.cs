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
   using System.Collections.Generic;



   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using VString = org.cip4.jdflib.core.VString;
   using JDFIconList = org.cip4.jdflib.resource.JDFIconList;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFDeviceCap = org.cip4.jdflib.resource.devicecapability.JDFDeviceCap;
   using JDFModule = org.cip4.jdflib.resource.devicecapability.JDFModule;
   using JDFCostCenter = org.cip4.jdflib.resource.process.JDFCostCenter;

   public abstract class JDFAutoDevice : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[23];
      static JDFAutoDevice()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.DEVICEFAMILY, 0x44444443, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.DEVICEID, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.DEVICETYPE, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.DIRECTORY, 0x33333331, AttributeInfo.EnumAttributeType.URL, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.FRIENDLYNAME, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.ICSVERSIONS, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.JDFERRORURL, 0x33333311, AttributeInfo.EnumAttributeType.URL, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.JDFINPUTURL, 0x33333311, AttributeInfo.EnumAttributeType.URL, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.JDFOUTPUTURL, 0x33333311, AttributeInfo.EnumAttributeType.URL, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.JDFVERSIONS, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[10] = new AtrInfoTable(AttributeName.JMFSENDERID, 0x33333331, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[11] = new AtrInfoTable(AttributeName.JMFURL, 0x33333331, AttributeInfo.EnumAttributeType.URL, null, null);
         atrInfoTable[12] = new AtrInfoTable(AttributeName.KNOWNLOCALIZATIONS, 0x33333311, AttributeInfo.EnumAttributeType.languages, null, null);
         atrInfoTable[13] = new AtrInfoTable(AttributeName.MANUFACTURER, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[14] = new AtrInfoTable(AttributeName.MANUFACTURERURL, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[15] = new AtrInfoTable(AttributeName.MODELDESCRIPTION, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[16] = new AtrInfoTable(AttributeName.MODELNAME, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[17] = new AtrInfoTable(AttributeName.MODELNUMBER, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[18] = new AtrInfoTable(AttributeName.MODELURL, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[19] = new AtrInfoTable(AttributeName.SERIALNUMBER, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[20] = new AtrInfoTable(AttributeName.PRESENTATIONURL, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[21] = new AtrInfoTable(AttributeName.SECUREJMFURL, 0x33333111, AttributeInfo.EnumAttributeType.URL, null, null);
         atrInfoTable[22] = new AtrInfoTable(AttributeName.UPC, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.COSTCENTER, 0x66666666);
         elemInfoTable[1] = new ElemInfoTable(ElementName.DEVICECAP, 0x33333331);
         elemInfoTable[2] = new ElemInfoTable(ElementName.ICONLIST, 0x66666661);
         elemInfoTable[3] = new ElemInfoTable(ElementName.MODULE, 0x33333111);
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
      ///     <summary> * Constructor for JDFAutoDevice </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoDevice(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoDevice </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoDevice(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoDevice </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoDevice(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoDevice[  --> " + base.ToString() + " ]";
      }


      public override bool init()
      {
         bool bRet = base.init();
         setResourceClass(JDFResource.EnumResourceClass.Implementation);
         return bRet;
      }


      public override EnumResourceClass getValidClass()
      {
         return JDFResource.EnumResourceClass.Implementation;
      }


      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute DeviceFamily
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DeviceFamily </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDeviceFamily(string @value)
      {
         setAttribute(AttributeName.DEVICEFAMILY, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute DeviceFamily </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getDeviceFamily()
      {
         return getAttribute(AttributeName.DEVICEFAMILY, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute Directory
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Directory </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDirectory(string @value)
      {
         setAttribute(AttributeName.DIRECTORY, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Directory </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getDirectory()
      {
         return getAttribute(AttributeName.DIRECTORY, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute FriendlyName
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute FriendlyName </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFriendlyName(string @value)
      {
         setAttribute(AttributeName.FRIENDLYNAME, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute FriendlyName </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getFriendlyName()
      {
         return getAttribute(AttributeName.FRIENDLYNAME, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute JDFErrorURL
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute JDFErrorURL </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setJDFErrorURL(string @value)
      {
         setAttribute(AttributeName.JDFERRORURL, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute JDFErrorURL </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getJDFErrorURL()
      {
         return getAttribute(AttributeName.JDFERRORURL, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute JDFInputURL
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute JDFInputURL </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setJDFInputURL(string @value)
      {
         setAttribute(AttributeName.JDFINPUTURL, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute JDFInputURL </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getJDFInputURL()
      {
         return getAttribute(AttributeName.JDFINPUTURL, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute JDFOutputURL
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute JDFOutputURL </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setJDFOutputURL(string @value)
      {
         setAttribute(AttributeName.JDFOUTPUTURL, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute JDFOutputURL </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getJDFOutputURL()
      {
         return getAttribute(AttributeName.JDFOUTPUTURL, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute JDFVersions
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute JDFVersions </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setJDFVersions(string @value)
      {
         setAttribute(AttributeName.JDFVERSIONS, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute JDFVersions </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getJDFVersions()
      {
         return getAttribute(AttributeName.JDFVERSIONS, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute JMFSenderID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute JMFSenderID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setJMFSenderID(string @value)
      {
         setAttribute(AttributeName.JMFSENDERID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute JMFSenderID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getJMFSenderID()
      {
         return getAttribute(AttributeName.JMFSENDERID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute JMFURL
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute JMFURL </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setJMFURL(string @value)
      {
         setAttribute(AttributeName.JMFURL, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute JMFURL </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getJMFURL()
      {
         return getAttribute(AttributeName.JMFURL, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute KnownLocalizations
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute KnownLocalizations </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setKnownLocalizations(VString @value)
      {
         setAttribute(AttributeName.KNOWNLOCALIZATIONS, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute KnownLocalizations </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getKnownLocalizations()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.KNOWNLOCALIZATIONS, null, JDFConstants.EMPTYSTRING);
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
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
      //        Methods for Attribute PresentationURL
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PresentationURL </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPresentationURL(string @value)
      {
         setAttribute(AttributeName.PRESENTATIONURL, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute PresentationURL </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getPresentationURL()
      {
         return getAttribute(AttributeName.PRESENTATIONURL, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SecureJMFURL
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SecureJMFURL </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSecureJMFURL(string @value)
      {
         setAttribute(AttributeName.SECUREJMFURL, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute SecureJMFURL </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getSecureJMFURL()
      {
         return getAttribute(AttributeName.SECUREJMFURL, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute UPC
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute UPC </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setUPC(string @value)
      {
         setAttribute(AttributeName.UPC, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute UPC </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getUPC()
      {
         return getAttribute(AttributeName.UPC, null, JDFConstants.EMPTYSTRING);
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

      ///     <summary> (26) getCreateDeviceCap
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFDeviceCap the element </returns>
      ///     
      public virtual JDFDeviceCap getCreateDeviceCap(int iSkip)
      {
         return (JDFDeviceCap)getCreateElement_KElement(ElementName.DEVICECAP, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element DeviceCap </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFDeviceCap the element </returns>
      ///     * default is getDeviceCap(0)     
      public virtual JDFDeviceCap getDeviceCap(int iSkip)
      {
         return (JDFDeviceCap)getElement(ElementName.DEVICECAP, null, iSkip);
      }

      ///    
      ///     <summary> * Get all DeviceCap from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFDeviceCap> </returns>
      ///     
      public virtual ICollection<JDFDeviceCap> getAllDeviceCap()
      {
         List<JDFDeviceCap> v = new List<JDFDeviceCap>();

         JDFDeviceCap kElem = (JDFDeviceCap)getFirstChildElement(ElementName.DEVICECAP, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFDeviceCap)kElem.getNextSiblingElement(ElementName.DEVICECAP, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element DeviceCap </summary>
      ///     
      public virtual JDFDeviceCap appendDeviceCap()
      {
         return (JDFDeviceCap)appendElement(ElementName.DEVICECAP, null);
      }

      ///    
      ///     <summary> * (24) const get element IconList </summary>
      ///     * <returns> JDFIconList the element </returns>
      ///     
      public virtual JDFIconList getIconList()
      {
         return (JDFIconList)getElement(ElementName.ICONLIST, null, 0);
      }

      ///     <summary> (25) getCreateIconList
      ///     *  </summary>
      ///     * <returns> JDFIconList the element </returns>
      ///     
      public virtual JDFIconList getCreateIconList()
      {
         return (JDFIconList)getCreateElement_KElement(ElementName.ICONLIST, null, 0);
      }

      ///    
      ///     <summary> * (29) append element IconList </summary>
      ///     
      public virtual JDFIconList appendIconList()
      {
         return (JDFIconList)appendElementN(ElementName.ICONLIST, 1, null);
      }

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
