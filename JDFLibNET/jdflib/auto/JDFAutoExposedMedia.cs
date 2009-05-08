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
   using JDFIntegerRangeList = org.cip4.jdflib.datatypes.JDFIntegerRangeList;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFPageList = org.cip4.jdflib.resource.JDFPageList;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFContact = org.cip4.jdflib.resource.process.JDFContact;
   using JDFFileSpec = org.cip4.jdflib.resource.process.JDFFileSpec;
   using JDFIdentificationField = org.cip4.jdflib.resource.process.JDFIdentificationField;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;
   using JDFScreeningParams = org.cip4.jdflib.resource.process.prepress.JDFScreeningParams;

   public abstract class JDFAutoExposedMedia : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[9];
      static JDFAutoExposedMedia()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.POLARITY, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "true");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.COLORTYPE, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumColorType.getEnum(0), null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.PAGELISTINDEX, 0x33333111, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.PLATETYPE, 0x33333111, AttributeInfo.EnumAttributeType.enumeration, EnumPlateType.getEnum(0), null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.PROOFNAME, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.PROOFQUALITY, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumProofQuality.getEnum(0), null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.PROOFTYPE, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumProofType.getEnum(0), null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.PUNCHTYPE, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.RESOLUTION, 0x33333333, AttributeInfo.EnumAttributeType.XYPair, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.FILESPEC, 0x66666666);
         elemInfoTable[1] = new ElemInfoTable(ElementName.MEDIA, 0x55555555);
         elemInfoTable[2] = new ElemInfoTable(ElementName.PAGELIST, 0x66666111);
         elemInfoTable[3] = new ElemInfoTable(ElementName.SCREENINGPARAMS, 0x66666666);
         elemInfoTable[4] = new ElemInfoTable(ElementName.CONTACT, 0x33333333);
         elemInfoTable[5] = new ElemInfoTable(ElementName.IDENTIFICATIONFIELD, 0x33333333);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[6];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoExposedMedia </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoExposedMedia(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoExposedMedia </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoExposedMedia(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoExposedMedia </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoExposedMedia(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoExposedMedia[  --> " + base.ToString() + " ]";
      }


      public override bool init()
      {
         bool bRet = base.init();
         setResourceClass(JDFResource.EnumResourceClass.Handling);
         return bRet;
      }


      public override EnumResourceClass getValidClass()
      {
         return JDFResource.EnumResourceClass.Handling;
      }


      ///        
      ///        <summary> * Enumeration strings for ColorType </summary>
      ///        

      public class EnumColorType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumColorType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumColorType getEnum(string enumName)
         {
            return (EnumColorType)getEnum(typeof(EnumColorType), enumName);
         }

         public static EnumColorType getEnum(int enumValue)
         {
            return (EnumColorType)getEnum(typeof(EnumColorType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumColorType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumColorType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumColorType));
         }

         public static readonly EnumColorType Color = new EnumColorType("Color");
         public static readonly EnumColorType GrayScale = new EnumColorType("GrayScale");
         public static readonly EnumColorType Monochrome = new EnumColorType("Monochrome");
      }



      ///        
      ///        <summary> * Enumeration strings for PlateType </summary>
      ///        

      public class EnumPlateType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumPlateType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumPlateType getEnum(string enumName)
         {
            return (EnumPlateType)getEnum(typeof(EnumPlateType), enumName);
         }

         public static EnumPlateType getEnum(int enumValue)
         {
            return (EnumPlateType)getEnum(typeof(EnumPlateType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumPlateType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumPlateType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumPlateType));
         }

         public static readonly EnumPlateType Exposed = new EnumPlateType("Exposed");
         public static readonly EnumPlateType Dummy = new EnumPlateType("Dummy");
      }



      ///        
      ///        <summary> * Enumeration strings for ProofQuality </summary>
      ///        

      public class EnumProofQuality : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumProofQuality(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumProofQuality getEnum(string enumName)
         {
            return (EnumProofQuality)getEnum(typeof(EnumProofQuality), enumName);
         }

         public static EnumProofQuality getEnum(int enumValue)
         {
            return (EnumProofQuality)getEnum(typeof(EnumProofQuality), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumProofQuality));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumProofQuality));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumProofQuality));
         }

         public static readonly EnumProofQuality None = new EnumProofQuality("None");
         public static readonly EnumProofQuality Halftone = new EnumProofQuality("Halftone");
         public static readonly EnumProofQuality Contone = new EnumProofQuality("Contone");
         public static readonly EnumProofQuality Conceptual = new EnumProofQuality("Conceptual");
      }



      ///        
      ///        <summary> * Enumeration strings for ProofType </summary>
      ///        

      public class EnumProofType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumProofType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumProofType getEnum(string enumName)
         {
            return (EnumProofType)getEnum(typeof(EnumProofType), enumName);
         }

         public static EnumProofType getEnum(int enumValue)
         {
            return (EnumProofType)getEnum(typeof(EnumProofType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumProofType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumProofType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumProofType));
         }

         public static readonly EnumProofType None = new EnumProofType("None");
         public static readonly EnumProofType Imposition = new EnumProofType("Imposition");
         public static readonly EnumProofType Page = new EnumProofType("Page");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute Polarity
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Polarity </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPolarity(bool @value)
      {
         setAttribute(AttributeName.POLARITY, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute Polarity </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getPolarity()
      {
         return getBoolAttribute(AttributeName.POLARITY, null, true);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ColorType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute ColorType </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setColorType(EnumColorType enumVar)
      {
         setAttribute(AttributeName.COLORTYPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute ColorType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumColorType getColorType()
      {
         return EnumColorType.getEnum(getAttribute(AttributeName.COLORTYPE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PageListIndex
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PageListIndex </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPageListIndex(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.PAGELISTINDEX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerRangeList attribute PageListIndex </summary>
      ///          * <returns> JDFIntegerRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerRangeList </returns>
      ///          
      public virtual JDFIntegerRangeList getPageListIndex()
      {
         string strAttrName = "";
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.PAGELISTINDEX, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFIntegerRangeList(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PlateType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute PlateType </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setPlateType(EnumPlateType enumVar)
      {
         setAttribute(AttributeName.PLATETYPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute PlateType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumPlateType getPlateType()
      {
         return EnumPlateType.getEnum(getAttribute(AttributeName.PLATETYPE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ProofName
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ProofName </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setProofName(string @value)
      {
         setAttribute(AttributeName.PROOFNAME, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ProofName </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getProofName()
      {
         return getAttribute(AttributeName.PROOFNAME, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ProofQuality
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute ProofQuality </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setProofQuality(EnumProofQuality enumVar)
      {
         setAttribute(AttributeName.PROOFQUALITY, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute ProofQuality </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumProofQuality getProofQuality()
      {
         return EnumProofQuality.getEnum(getAttribute(AttributeName.PROOFQUALITY, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ProofType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute ProofType </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setProofType(EnumProofType enumVar)
      {
         setAttribute(AttributeName.PROOFTYPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute ProofType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumProofType getProofType()
      {
         return EnumProofType.getEnum(getAttribute(AttributeName.PROOFTYPE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PunchType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PunchType </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPunchType(string @value)
      {
         setAttribute(AttributeName.PUNCHTYPE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute PunchType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getPunchType()
      {
         return getAttribute(AttributeName.PUNCHTYPE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Resolution
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Resolution </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setResolution(JDFXYPair @value)
      {
         setAttribute(AttributeName.RESOLUTION, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute Resolution </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getResolution()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.RESOLUTION, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFXYPair(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element FileSpec </summary>
      ///     * <returns> JDFFileSpec the element </returns>
      ///     
      public virtual JDFFileSpec getFileSpec()
      {
         return (JDFFileSpec)getElement(ElementName.FILESPEC, null, 0);
      }

      ///     <summary> (25) getCreateFileSpec
      ///     *  </summary>
      ///     * <returns> JDFFileSpec the element </returns>
      ///     
      public virtual JDFFileSpec getCreateFileSpec()
      {
         return (JDFFileSpec)getCreateElement_KElement(ElementName.FILESPEC, null, 0);
      }

      ///    
      ///     <summary> * (29) append element FileSpec </summary>
      ///     
      public virtual JDFFileSpec appendFileSpec()
      {
         return (JDFFileSpec)appendElementN(ElementName.FILESPEC, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refFileSpec(JDFFileSpec refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element Media </summary>
      ///     * <returns> JDFMedia the element </returns>
      ///     
      public virtual JDFMedia getMedia()
      {
         return (JDFMedia)getElement(ElementName.MEDIA, null, 0);
      }

      ///     <summary> (25) getCreateMedia
      ///     *  </summary>
      ///     * <returns> JDFMedia the element </returns>
      ///     
      public virtual JDFMedia getCreateMedia()
      {
         return (JDFMedia)getCreateElement_KElement(ElementName.MEDIA, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Media </summary>
      ///     
      public virtual JDFMedia appendMedia()
      {
         return (JDFMedia)appendElementN(ElementName.MEDIA, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refMedia(JDFMedia refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element PageList </summary>
      ///     * <returns> JDFPageList the element </returns>
      ///     
      public virtual JDFPageList getPageList()
      {
         return (JDFPageList)getElement(ElementName.PAGELIST, null, 0);
      }

      ///     <summary> (25) getCreatePageList
      ///     *  </summary>
      ///     * <returns> JDFPageList the element </returns>
      ///     
      public virtual JDFPageList getCreatePageList()
      {
         return (JDFPageList)getCreateElement_KElement(ElementName.PAGELIST, null, 0);
      }

      ///    
      ///     <summary> * (29) append element PageList </summary>
      ///     
      public virtual JDFPageList appendPageList()
      {
         return (JDFPageList)appendElementN(ElementName.PAGELIST, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refPageList(JDFPageList refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element ScreeningParams </summary>
      ///     * <returns> JDFScreeningParams the element </returns>
      ///     
      public virtual JDFScreeningParams getScreeningParams()
      {
         return (JDFScreeningParams)getElement(ElementName.SCREENINGPARAMS, null, 0);
      }

      ///     <summary> (25) getCreateScreeningParams
      ///     *  </summary>
      ///     * <returns> JDFScreeningParams the element </returns>
      ///     
      public virtual JDFScreeningParams getCreateScreeningParams()
      {
         return (JDFScreeningParams)getCreateElement_KElement(ElementName.SCREENINGPARAMS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ScreeningParams </summary>
      ///     
      public virtual JDFScreeningParams appendScreeningParams()
      {
         return (JDFScreeningParams)appendElementN(ElementName.SCREENINGPARAMS, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refScreeningParams(JDFScreeningParams refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreateContact
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFContact the element </returns>
      ///     
      public virtual JDFContact getCreateContact(int iSkip)
      {
         return (JDFContact)getCreateElement_KElement(ElementName.CONTACT, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Contact </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFContact the element </returns>
      ///     * default is getContact(0)     
      public virtual JDFContact getContact(int iSkip)
      {
         return (JDFContact)getElement(ElementName.CONTACT, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Contact from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFContact> </returns>
      ///     
      public virtual ICollection<JDFContact> getAllContact()
      {
         List<JDFContact> v = new List<JDFContact>();

         JDFContact kElem = (JDFContact)getFirstChildElement(ElementName.CONTACT, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFContact)kElem.getNextSiblingElement(ElementName.CONTACT, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Contact </summary>
      ///     
      public override JDFContact appendContact()
      {
         return (JDFContact)appendElement(ElementName.CONTACT, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refContact(JDFContact refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreateIdentificationField
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFIdentificationField the element </returns>
      ///     
      public override JDFIdentificationField getCreateIdentificationField(int iSkip)
      {
         return (JDFIdentificationField)getCreateElement_KElement(ElementName.IDENTIFICATIONFIELD, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element IdentificationField </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFIdentificationField the element </returns>
      ///     * default is getIdentificationField(0)     
      public override JDFIdentificationField getIdentificationField(int iSkip)
      {
         return (JDFIdentificationField)getElement(ElementName.IDENTIFICATIONFIELD, null, iSkip);
      }

      ///    
      ///     <summary> * Get all IdentificationField from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFIdentificationField> </returns>
      ///     
      public virtual ICollection<JDFIdentificationField> getAllIdentificationField()
      {
         List<JDFIdentificationField> v = new List<JDFIdentificationField>();

         JDFIdentificationField kElem = (JDFIdentificationField)getFirstChildElement(ElementName.IDENTIFICATIONFIELD, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFIdentificationField)kElem.getNextSiblingElement(ElementName.IDENTIFICATIONFIELD, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element IdentificationField </summary>
      ///     
      public override JDFIdentificationField appendIdentificationField()
      {
         return (JDFIdentificationField)appendElement(ElementName.IDENTIFICATIONFIELD, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refIdentificationField(JDFIdentificationField refTarget)
      {
         refElement(refTarget);
      }
   }
}
