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
   using JDFElement = org.cip4.jdflib.core.JDFElement;

   public abstract class JDFAutoAdvancedParams : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[17];
      static JDFAutoAdvancedParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ALLOWPSXOBJECTS, 0x33333311, AttributeInfo.EnumAttributeType.boolean_, null, "true");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.ALLOWTRANSPARENCY, 0x33333311, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.AUTOPOSITIONEPSINFO, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "true");
         atrInfoTable[3] = new AtrInfoTable(AttributeName.EMBEDJOBOPTIONS, 0x33333311, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[4] = new AtrInfoTable(AttributeName.EMITDSCWARNINGS, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[5] = new AtrInfoTable(AttributeName.LOCKDISTILLERPARAMS, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "true");
         atrInfoTable[6] = new AtrInfoTable(AttributeName.PARSEDSCCOMMENTS, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "true");
         atrInfoTable[7] = new AtrInfoTable(AttributeName.PARSEDSCCOMMENTSFORDOCINFO, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "true");
         atrInfoTable[8] = new AtrInfoTable(AttributeName.PASSTHROUGHJPEGIMAGES, 0x33333311, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[9] = new AtrInfoTable(AttributeName.PRESERVECOPYPAGE, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "true");
         atrInfoTable[10] = new AtrInfoTable(AttributeName.PRESERVEEPSINFO, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "true");
         atrInfoTable[11] = new AtrInfoTable(AttributeName.PRESERVEHALFTONEINFO, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[12] = new AtrInfoTable(AttributeName.PRESERVEOVERPRINTSETTINGS, 0x33333331, AttributeInfo.EnumAttributeType.boolean_, null, "true");
         atrInfoTable[13] = new AtrInfoTable(AttributeName.PRESERVEOPICOMMENTS, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "true");
         atrInfoTable[14] = new AtrInfoTable(AttributeName.TRANSFERFUNCTIONINFO, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumTransferFunctionInfo.getEnum(0), "Preserve");
         atrInfoTable[15] = new AtrInfoTable(AttributeName.UCRANDBGINFO, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumUCRandBGInfo.getEnum(0), "Preserve");
         atrInfoTable[16] = new AtrInfoTable(AttributeName.USEPROLOGUE, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoAdvancedParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoAdvancedParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoAdvancedParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoAdvancedParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoAdvancedParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoAdvancedParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      /// <summary>
      /// String representation of this object
      /// </summary>
      /// <returns>string</returns>
      public override string ToString()
      {
         return " JDFAutoAdvancedParams[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for TransferFunctionInfo </summary>
      ///        

      public class EnumTransferFunctionInfo : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumTransferFunctionInfo(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumTransferFunctionInfo getEnum(string enumName)
         {
            return (EnumTransferFunctionInfo)getEnum(typeof(EnumTransferFunctionInfo), enumName);
         }

         public static EnumTransferFunctionInfo getEnum(int enumValue)
         {
            return (EnumTransferFunctionInfo)getEnum(typeof(EnumTransferFunctionInfo), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumTransferFunctionInfo));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumTransferFunctionInfo));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumTransferFunctionInfo));
         }

         public static readonly EnumTransferFunctionInfo Preserve = new EnumTransferFunctionInfo("Preserve");
         public static readonly EnumTransferFunctionInfo Remove = new EnumTransferFunctionInfo("Remove");
         public static readonly EnumTransferFunctionInfo Apply = new EnumTransferFunctionInfo("Apply");
      }



      ///        
      ///        <summary> * Enumeration strings for UCRandBGInfo </summary>
      ///        

      public class EnumUCRandBGInfo : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumUCRandBGInfo(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumUCRandBGInfo getEnum(string enumName)
         {
            return (EnumUCRandBGInfo)getEnum(typeof(EnumUCRandBGInfo), enumName);
         }

         public static EnumUCRandBGInfo getEnum(int enumValue)
         {
            return (EnumUCRandBGInfo)getEnum(typeof(EnumUCRandBGInfo), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumUCRandBGInfo));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumUCRandBGInfo));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumUCRandBGInfo));
         }

         public static readonly EnumUCRandBGInfo Preserve = new EnumUCRandBGInfo("Preserve");
         public static readonly EnumUCRandBGInfo Remove = new EnumUCRandBGInfo("Remove");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute AllowPSXObjects
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute AllowPSXObjects </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAllowPSXObjects(bool @value)
      {
         setAttribute(AttributeName.ALLOWPSXOBJECTS, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute AllowPSXObjects </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getAllowPSXObjects()
      {
         return getBoolAttribute(AttributeName.ALLOWPSXOBJECTS, null, true);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute AllowTransparency
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute AllowTransparency </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAllowTransparency(bool @value)
      {
         setAttribute(AttributeName.ALLOWTRANSPARENCY, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute AllowTransparency </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getAllowTransparency()
      {
         return getBoolAttribute(AttributeName.ALLOWTRANSPARENCY, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute AutoPositionEPSInfo
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute AutoPositionEPSInfo </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAutoPositionEPSInfo(bool @value)
      {
         setAttribute(AttributeName.AUTOPOSITIONEPSINFO, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute AutoPositionEPSInfo </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getAutoPositionEPSInfo()
      {
         return getBoolAttribute(AttributeName.AUTOPOSITIONEPSINFO, null, true);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute EmbedJobOptions
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute EmbedJobOptions </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setEmbedJobOptions(bool @value)
      {
         setAttribute(AttributeName.EMBEDJOBOPTIONS, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute EmbedJobOptions </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getEmbedJobOptions()
      {
         return getBoolAttribute(AttributeName.EMBEDJOBOPTIONS, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute EmitDSCWarnings
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute EmitDSCWarnings </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setEmitDSCWarnings(bool @value)
      {
         setAttribute(AttributeName.EMITDSCWARNINGS, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute EmitDSCWarnings </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getEmitDSCWarnings()
      {
         return getBoolAttribute(AttributeName.EMITDSCWARNINGS, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute LockDistillerParams
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute LockDistillerParams </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setLockDistillerParams(bool @value)
      {
         setAttribute(AttributeName.LOCKDISTILLERPARAMS, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute LockDistillerParams </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getLockDistillerParams()
      {
         return getBoolAttribute(AttributeName.LOCKDISTILLERPARAMS, null, true);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ParseDSCComments
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ParseDSCComments </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setParseDSCComments(bool @value)
      {
         setAttribute(AttributeName.PARSEDSCCOMMENTS, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute ParseDSCComments </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getParseDSCComments()
      {
         return getBoolAttribute(AttributeName.PARSEDSCCOMMENTS, null, true);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ParseDSCCommentsForDocInfo
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ParseDSCCommentsForDocInfo </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setParseDSCCommentsForDocInfo(bool @value)
      {
         setAttribute(AttributeName.PARSEDSCCOMMENTSFORDOCINFO, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute ParseDSCCommentsForDocInfo </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getParseDSCCommentsForDocInfo()
      {
         return getBoolAttribute(AttributeName.PARSEDSCCOMMENTSFORDOCINFO, null, true);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PassThroughJPEGImages
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PassThroughJPEGImages </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPassThroughJPEGImages(bool @value)
      {
         setAttribute(AttributeName.PASSTHROUGHJPEGIMAGES, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute PassThroughJPEGImages </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getPassThroughJPEGImages()
      {
         return getBoolAttribute(AttributeName.PASSTHROUGHJPEGIMAGES, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PreserveCopyPage
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PreserveCopyPage </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPreserveCopyPage(bool @value)
      {
         setAttribute(AttributeName.PRESERVECOPYPAGE, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute PreserveCopyPage </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getPreserveCopyPage()
      {
         return getBoolAttribute(AttributeName.PRESERVECOPYPAGE, null, true);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PreserveEPSInfo
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PreserveEPSInfo </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPreserveEPSInfo(bool @value)
      {
         setAttribute(AttributeName.PRESERVEEPSINFO, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute PreserveEPSInfo </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getPreserveEPSInfo()
      {
         return getBoolAttribute(AttributeName.PRESERVEEPSINFO, null, true);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PreserveHalftoneInfo
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PreserveHalftoneInfo </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPreserveHalftoneInfo(bool @value)
      {
         setAttribute(AttributeName.PRESERVEHALFTONEINFO, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute PreserveHalftoneInfo </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getPreserveHalftoneInfo()
      {
         return getBoolAttribute(AttributeName.PRESERVEHALFTONEINFO, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PreserveOverprintSettings
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PreserveOverprintSettings </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPreserveOverprintSettings(bool @value)
      {
         setAttribute(AttributeName.PRESERVEOVERPRINTSETTINGS, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute PreserveOverprintSettings </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getPreserveOverprintSettings()
      {
         return getBoolAttribute(AttributeName.PRESERVEOVERPRINTSETTINGS, null, true);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PreserveOPIComments
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PreserveOPIComments </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPreserveOPIComments(bool @value)
      {
         setAttribute(AttributeName.PRESERVEOPICOMMENTS, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute PreserveOPIComments </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getPreserveOPIComments()
      {
         return getBoolAttribute(AttributeName.PRESERVEOPICOMMENTS, null, true);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TransferFunctionInfo
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute TransferFunctionInfo </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setTransferFunctionInfo(EnumTransferFunctionInfo enumVar)
      {
         setAttribute(AttributeName.TRANSFERFUNCTIONINFO, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute TransferFunctionInfo </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumTransferFunctionInfo getTransferFunctionInfo()
      {
         return EnumTransferFunctionInfo.getEnum(getAttribute(AttributeName.TRANSFERFUNCTIONINFO, null, "Preserve"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute UCRandBGInfo
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute UCRandBGInfo </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setUCRandBGInfo(EnumUCRandBGInfo enumVar)
      {
         setAttribute(AttributeName.UCRANDBGINFO, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute UCRandBGInfo </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumUCRandBGInfo getUCRandBGInfo()
      {
         return EnumUCRandBGInfo.getEnum(getAttribute(AttributeName.UCRANDBGINFO, null, "Preserve"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute UsePrologue
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute UsePrologue </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setUsePrologue(bool @value)
      {
         setAttribute(AttributeName.USEPROLOGUE, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute UsePrologue </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getUsePrologue()
      {
         return getBoolAttribute(AttributeName.USEPROLOGUE, null, false);
      }
   }
}
