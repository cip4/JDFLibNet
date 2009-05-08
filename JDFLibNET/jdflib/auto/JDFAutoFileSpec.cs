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
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFContainer = org.cip4.jdflib.resource.process.JDFContainer;
   using JDFDisposition = org.cip4.jdflib.resource.process.JDFDisposition;
   using JDFFileAlias = org.cip4.jdflib.resource.process.JDFFileAlias;

   public abstract class JDFAutoFileSpec : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[24];
      static JDFAutoFileSpec()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.COMPRESSION, 0x33333311, AttributeInfo.EnumAttributeType.NMTOKEN, null, "None");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.APPLICATION, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.APPOS, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.APPVERSION, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.CHECKSUM, 0x33333331, AttributeInfo.EnumAttributeType.hexBinary, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.DISPOSITION, 0x44444433, AttributeInfo.EnumAttributeType.enumeration, EnumDisposition.getEnum(0), null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.DOCUMENTNATURALLANG, 0x33333311, AttributeInfo.EnumAttributeType.language, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.FILEFORMAT, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.FILESIZE, 0x33333311, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.FILETARGETDEVICEMODEL, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[10] = new AtrInfoTable(AttributeName.FILETEMPLATE, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[11] = new AtrInfoTable(AttributeName.FILEVERSION, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[12] = new AtrInfoTable(AttributeName.MIMETYPE, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[13] = new AtrInfoTable(AttributeName.MIMETYPEVERSION, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[14] = new AtrInfoTable(AttributeName.OVERWRITEPOLICY, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumOverwritePolicy.getEnum(0), null);
         atrInfoTable[15] = new AtrInfoTable(AttributeName.OSVERSION, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[16] = new AtrInfoTable(AttributeName.PAGEORDER, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumPageOrder.getEnum(0), null);
         atrInfoTable[17] = new AtrInfoTable(AttributeName.PASSWORD, 0x33333111, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[18] = new AtrInfoTable(AttributeName.REQUESTQUALITY, 0x33333111, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[19] = new AtrInfoTable(AttributeName.RESOURCEUSAGE, 0x33333311, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[20] = new AtrInfoTable(AttributeName.SEARCHDEPTH, 0x33333311, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[21] = new AtrInfoTable(AttributeName.UID, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[22] = new AtrInfoTable(AttributeName.URL, 0x33333333, AttributeInfo.EnumAttributeType.URL, null, null);
         atrInfoTable[23] = new AtrInfoTable(AttributeName.USERFILENAME, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.CONTAINER, 0x66666611);
         elemInfoTable[1] = new ElemInfoTable(ElementName.DISPOSITION, 0x66666611);
         elemInfoTable[2] = new ElemInfoTable(ElementName.FILEALIAS, 0x33333311);
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
      ///     <summary> * Constructor for JDFAutoFileSpec </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoFileSpec(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoFileSpec </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoFileSpec(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoFileSpec </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoFileSpec(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoFileSpec[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for Disposition </summary>
      ///        

      public class EnumDisposition : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumDisposition(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumDisposition getEnum(string enumName)
         {
            return (EnumDisposition)getEnum(typeof(EnumDisposition), enumName);
         }

         public static EnumDisposition getEnum(int enumValue)
         {
            return (EnumDisposition)getEnum(typeof(EnumDisposition), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumDisposition));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumDisposition));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumDisposition));
         }

         public static readonly EnumDisposition Unlink = new EnumDisposition("Unlink");
         public static readonly EnumDisposition Delete = new EnumDisposition("Delete");
         public static readonly EnumDisposition Retain = new EnumDisposition("Retain");
      }



      ///        
      ///        <summary> * Enumeration strings for OverwritePolicy </summary>
      ///        

      public class EnumOverwritePolicy : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumOverwritePolicy(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumOverwritePolicy getEnum(string enumName)
         {
            return (EnumOverwritePolicy)getEnum(typeof(EnumOverwritePolicy), enumName);
         }

         public static EnumOverwritePolicy getEnum(int enumValue)
         {
            return (EnumOverwritePolicy)getEnum(typeof(EnumOverwritePolicy), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumOverwritePolicy));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumOverwritePolicy));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumOverwritePolicy));
         }

         public static readonly EnumOverwritePolicy Overwrite = new EnumOverwritePolicy("Overwrite");
         public static readonly EnumOverwritePolicy RenameNew = new EnumOverwritePolicy("RenameNew");
         public static readonly EnumOverwritePolicy RenameOld = new EnumOverwritePolicy("RenameOld");
         public static readonly EnumOverwritePolicy NewVersion = new EnumOverwritePolicy("NewVersion");
         public static readonly EnumOverwritePolicy OperatorIntervention = new EnumOverwritePolicy("OperatorIntervention");
         public static readonly EnumOverwritePolicy Abort = new EnumOverwritePolicy("Abort");
      }



      ///        
      ///        <summary> * Enumeration strings for PageOrder </summary>
      ///        

      public class EnumPageOrder : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumPageOrder(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumPageOrder getEnum(string enumName)
         {
            return (EnumPageOrder)getEnum(typeof(EnumPageOrder), enumName);
         }

         public static EnumPageOrder getEnum(int enumValue)
         {
            return (EnumPageOrder)getEnum(typeof(EnumPageOrder), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumPageOrder));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumPageOrder));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumPageOrder));
         }

         public static readonly EnumPageOrder Ascending = new EnumPageOrder("Ascending");
         public static readonly EnumPageOrder Descending = new EnumPageOrder("Descending");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute Compression
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Compression </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCompression(string @value)
      {
         setAttribute(AttributeName.COMPRESSION, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Compression </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getCompression()
      {
         return getAttribute(AttributeName.COMPRESSION, null, "None");
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Application
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Application </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setApplication(string @value)
      {
         setAttribute(AttributeName.APPLICATION, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Application </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getApplication()
      {
         return getAttribute(AttributeName.APPLICATION, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute AppOS
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute AppOS </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAppOS(string @value)
      {
         setAttribute(AttributeName.APPOS, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute AppOS </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getAppOS()
      {
         return getAttribute(AttributeName.APPOS, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute AppVersion
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute AppVersion </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAppVersion(string @value)
      {
         setAttribute(AttributeName.APPVERSION, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute AppVersion </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getAppVersion()
      {
         return getAttribute(AttributeName.APPVERSION, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute CheckSum
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CheckSum </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCheckSum(string @value)
      {
         setAttribute(AttributeName.CHECKSUM, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute CheckSum </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getCheckSum()
      {
         return getAttribute(AttributeName.CHECKSUM, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Disposition
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Disposition </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setDisposition(EnumDisposition enumVar)
      {
         setAttribute(AttributeName.DISPOSITION, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Disposition </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumDisposition getDisposition()
      {
         return EnumDisposition.getEnum(getAttribute(AttributeName.DISPOSITION, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute DocumentNaturalLang
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DocumentNaturalLang </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDocumentNaturalLang(string @value)
      {
         setAttribute(AttributeName.DOCUMENTNATURALLANG, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute DocumentNaturalLang </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getDocumentNaturalLang()
      {
         return getAttribute(AttributeName.DOCUMENTNATURALLANG, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute FileFormat
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute FileFormat </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFileFormat(string @value)
      {
         setAttribute(AttributeName.FILEFORMAT, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute FileFormat </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getFileFormat()
      {
         return getAttribute(AttributeName.FILEFORMAT, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute FileSize
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute FileSize </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFileSize(string @value)
      {
         setAttribute(AttributeName.FILESIZE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute FileSize </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getFileSize()
      {
         return getAttribute(AttributeName.FILESIZE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute FileTargetDeviceModel
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute FileTargetDeviceModel </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFileTargetDeviceModel(string @value)
      {
         setAttribute(AttributeName.FILETARGETDEVICEMODEL, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute FileTargetDeviceModel </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getFileTargetDeviceModel()
      {
         return getAttribute(AttributeName.FILETARGETDEVICEMODEL, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute FileTemplate
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute FileTemplate </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFileTemplate(string @value)
      {
         setAttribute(AttributeName.FILETEMPLATE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute FileTemplate </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getFileTemplate()
      {
         return getAttribute(AttributeName.FILETEMPLATE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute FileVersion
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute FileVersion </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFileVersion(string @value)
      {
         setAttribute(AttributeName.FILEVERSION, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute FileVersion </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getFileVersion()
      {
         return getAttribute(AttributeName.FILEVERSION, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MimeType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MimeType </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMimeType(string @value)
      {
         setAttribute(AttributeName.MIMETYPE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute MimeType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getMimeType()
      {
         return getAttribute(AttributeName.MIMETYPE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MimeTypeVersion
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MimeTypeVersion </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMimeTypeVersion(string @value)
      {
         setAttribute(AttributeName.MIMETYPEVERSION, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute MimeTypeVersion </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getMimeTypeVersion()
      {
         return getAttribute(AttributeName.MIMETYPEVERSION, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute OverwritePolicy
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute OverwritePolicy </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setOverwritePolicy(EnumOverwritePolicy enumVar)
      {
         setAttribute(AttributeName.OVERWRITEPOLICY, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute OverwritePolicy </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumOverwritePolicy getOverwritePolicy()
      {
         return EnumOverwritePolicy.getEnum(getAttribute(AttributeName.OVERWRITEPOLICY, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute OSVersion
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute OSVersion </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setOSVersion(string @value)
      {
         setAttribute(AttributeName.OSVERSION, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute OSVersion </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getOSVersion()
      {
         return getAttribute(AttributeName.OSVERSION, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PageOrder
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute PageOrder </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setPageOrder(EnumPageOrder enumVar)
      {
         setAttribute(AttributeName.PAGEORDER, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute PageOrder </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumPageOrder getPageOrder()
      {
         return EnumPageOrder.getEnum(getAttribute(AttributeName.PAGEORDER, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Password
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Password </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPassword(string @value)
      {
         setAttribute(AttributeName.PASSWORD, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Password </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getPassword()
      {
         return getAttribute(AttributeName.PASSWORD, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute RequestQuality
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute RequestQuality </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setRequestQuality(double @value)
      {
         setAttribute(AttributeName.REQUESTQUALITY, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute RequestQuality </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getRequestQuality()
      {
         return getRealAttribute(AttributeName.REQUESTQUALITY, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ResourceUsage
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ResourceUsage </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setResourceUsage(string @value)
      {
         setAttribute(AttributeName.RESOURCEUSAGE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ResourceUsage </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getResourceUsage()
      {
         return getAttribute(AttributeName.RESOURCEUSAGE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SearchDepth
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SearchDepth </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSearchDepth(int @value)
      {
         setAttribute(AttributeName.SEARCHDEPTH, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute SearchDepth </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getSearchDepth()
      {
         return getIntAttribute(AttributeName.SEARCHDEPTH, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute UID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute UID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setUID(string @value)
      {
         setAttribute(AttributeName.UID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute UID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getUID()
      {
         return getAttribute(AttributeName.UID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute URL
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute URL </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setURL(string @value)
      {
         setAttribute(AttributeName.URL, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute URL </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getURL()
      {
         return getAttribute(AttributeName.URL, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute UserFileName
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute UserFileName </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setUserFileName(string @value)
      {
         setAttribute(AttributeName.USERFILENAME, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute UserFileName </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getUserFileName()
      {
         return getAttribute(AttributeName.USERFILENAME, null, JDFConstants.EMPTYSTRING);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (28) const get element Container </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFContainer the element </returns>
      ///     * default is getContainer(0)     
      public virtual JDFContainer getContainer(int iSkip)
      {
         return (JDFContainer)getElement(ElementName.CONTAINER, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Container from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFContainer> </returns>
      ///     
      public virtual ICollection<JDFContainer> getAllContainer()
      {
         List<JDFContainer> v = new List<JDFContainer>();

         JDFContainer kElem = (JDFContainer)getFirstChildElement(ElementName.CONTAINER, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFContainer)kElem.getNextSiblingElement(ElementName.CONTAINER, null);
         }

         return v;
      }

      ///     <summary> (25) getCreateContainer
      ///     *  </summary>
      ///     * <returns> JDFContainer the element </returns>
      ///     
      public virtual JDFContainer getCreateContainer()
      {
         return (JDFContainer)getCreateElement_KElement(ElementName.CONTAINER, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Container </summary>
      ///     
      public virtual JDFContainer appendContainer()
      {
         return (JDFContainer)appendElementN(ElementName.CONTAINER, 1, null);
      }

      ///    
      ///     <summary> * (28) const get element Disposition </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFDisposition the element </returns>
      ///     * default is getDisposition(0)     
      public virtual JDFDisposition getDisposition(int iSkip)
      {
         return (JDFDisposition)getElement(ElementName.DISPOSITION, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Disposition from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFDisposition> </returns>
      ///     
      public virtual ICollection<JDFDisposition> getAllDisposition()
      {
         List<JDFDisposition> v = new List<JDFDisposition>();

         JDFDisposition kElem = (JDFDisposition)getFirstChildElement(ElementName.DISPOSITION, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFDisposition)kElem.getNextSiblingElement(ElementName.DISPOSITION, null);
         }

         return v;
      }

      ///     <summary> (25) getCreateDisposition
      ///     *  </summary>
      ///     * <returns> JDFDisposition the element </returns>
      ///     
      public virtual JDFDisposition getCreateDisposition()
      {
         return (JDFDisposition)getCreateElement_KElement(ElementName.DISPOSITION, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Disposition </summary>
      ///     
      public virtual JDFDisposition appendDisposition()
      {
         return (JDFDisposition)appendElementN(ElementName.DISPOSITION, 1, null);
      }

      ///     <summary> (26) getCreateFileAlias
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFFileAlias the element </returns>
      ///     
      public virtual JDFFileAlias getCreateFileAlias(int iSkip)
      {
         return (JDFFileAlias)getCreateElement_KElement(ElementName.FILEALIAS, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element FileAlias </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFFileAlias the element </returns>
      ///     * default is getFileAlias(0)     
      public virtual JDFFileAlias getFileAlias(int iSkip)
      {
         return (JDFFileAlias)getElement(ElementName.FILEALIAS, null, iSkip);
      }

      ///    
      ///     <summary> * Get all FileAlias from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFFileAlias> </returns>
      ///     
      public virtual ICollection<JDFFileAlias> getAllFileAlias()
      {
         List<JDFFileAlias> v = new List<JDFFileAlias>();

         JDFFileAlias kElem = (JDFFileAlias)getFirstChildElement(ElementName.FILEALIAS, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFFileAlias)kElem.getNextSiblingElement(ElementName.FILEALIAS, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element FileAlias </summary>
      ///     
      public virtual JDFFileAlias appendFileAlias()
      {
         return (JDFFileAlias)appendElement(ElementName.FILEALIAS, null);
      }
   }
}
