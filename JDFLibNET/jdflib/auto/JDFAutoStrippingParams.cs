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
   using VString = org.cip4.jdflib.core.VString;
   using JDFIntegerList = org.cip4.jdflib.datatypes.JDFIntegerList;
   using JDFDevice = org.cip4.jdflib.resource.JDFDevice;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFBinderySignature = org.cip4.jdflib.resource.process.JDFBinderySignature;
   using JDFExternalImpositionTemplate = org.cip4.jdflib.resource.process.JDFExternalImpositionTemplate;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;
   using JDFPosition = org.cip4.jdflib.resource.process.JDFPosition;
   using JDFStripCellParams = org.cip4.jdflib.resource.process.JDFStripCellParams;
   using JDFStripMark = org.cip4.jdflib.resource.process.JDFStripMark;

   public abstract class JDFAutoStrippingParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[5];
      static JDFAutoStrippingParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ASSEMBLYID, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.ASSEMBLYIDS, 0x33333311, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.JOBID, 0x33333311, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.SECTIONLIST, 0x33333311, AttributeInfo.EnumAttributeType.IntegerList, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.WORKSTYLE, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumWorkStyle.getEnum(0), null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.BINDERYSIGNATURE, 0x55555511);
         elemInfoTable[1] = new ElemInfoTable(ElementName.DEVICE, 0x33333311);
         elemInfoTable[2] = new ElemInfoTable(ElementName.EXTERNALIMPOSITIONTEMPLATE, 0x66666111);
         elemInfoTable[3] = new ElemInfoTable(ElementName.MEDIA, 0x33333311);
         elemInfoTable[4] = new ElemInfoTable(ElementName.POSITION, 0x33333311);
         elemInfoTable[5] = new ElemInfoTable(ElementName.STRIPCELLPARAMS, 0x66666611);
         elemInfoTable[6] = new ElemInfoTable(ElementName.STRIPMARK, 0x33333111);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[7];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoStrippingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoStrippingParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoStrippingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoStrippingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoStrippingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoStrippingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoStrippingParams[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for WorkStyle </summary>
      ///        

      public class EnumWorkStyle : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumWorkStyle(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumWorkStyle getEnum(string enumName)
         {
            return (EnumWorkStyle)getEnum(typeof(EnumWorkStyle), enumName);
         }

         public static EnumWorkStyle getEnum(int enumValue)
         {
            return (EnumWorkStyle)getEnum(typeof(EnumWorkStyle), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumWorkStyle));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumWorkStyle));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumWorkStyle));
         }

         public static readonly EnumWorkStyle Simplex = new EnumWorkStyle("Simplex");
         public static readonly EnumWorkStyle WorkAndBack = new EnumWorkStyle("WorkAndBack");
         public static readonly EnumWorkStyle Perfecting = new EnumWorkStyle("Perfecting");
         public static readonly EnumWorkStyle WorkAndTurn = new EnumWorkStyle("WorkAndTurn");
         public static readonly EnumWorkStyle WorkAndTumble = new EnumWorkStyle("WorkAndTumble");
         public static readonly EnumWorkStyle WorkAndTwist = new EnumWorkStyle("WorkAndTwist");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute AssemblyID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute AssemblyID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAssemblyID(string @value)
      {
         setAttribute(AttributeName.ASSEMBLYID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute AssemblyID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getAssemblyID()
      {
         return getAttribute(AttributeName.ASSEMBLYID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute AssemblyIDs
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute AssemblyIDs </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAssemblyIDs(VString @value)
      {
         setAttribute(AttributeName.ASSEMBLYIDS, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute AssemblyIDs </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getAssemblyIDs()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.ASSEMBLYIDS, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute SectionList
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SectionList </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSectionList(JDFIntegerList @value)
      {
         setAttribute(AttributeName.SECTIONLIST, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerList attribute SectionList </summary>
      ///          * <returns> JDFIntegerList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerList </returns>
      ///          
      public virtual JDFIntegerList getSectionList()
      {
         string strAttrName = "";
         JDFIntegerList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.SECTIONLIST, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFIntegerList(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute WorkStyle
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute WorkStyle </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setWorkStyle(EnumWorkStyle enumVar)
      {
         setAttribute(AttributeName.WORKSTYLE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute WorkStyle </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumWorkStyle getWorkStyle()
      {
         return EnumWorkStyle.getEnum(getAttribute(AttributeName.WORKSTYLE, null, null));
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element BinderySignature </summary>
      ///     * <returns> JDFBinderySignature the element </returns>
      ///     
      public virtual JDFBinderySignature getBinderySignature()
      {
         return (JDFBinderySignature)getElement(ElementName.BINDERYSIGNATURE, null, 0);
      }

      ///     <summary> (25) getCreateBinderySignature
      ///     *  </summary>
      ///     * <returns> JDFBinderySignature the element </returns>
      ///     
      public virtual JDFBinderySignature getCreateBinderySignature()
      {
         return (JDFBinderySignature)getCreateElement_KElement(ElementName.BINDERYSIGNATURE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element BinderySignature </summary>
      ///     
      public virtual JDFBinderySignature appendBinderySignature()
      {
         return (JDFBinderySignature)appendElementN(ElementName.BINDERYSIGNATURE, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refBinderySignature(JDFBinderySignature refTarget)
      {
         refElement(refTarget);
      }

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

      ///    
      ///     <summary> * (24) const get element ExternalImpositionTemplate </summary>
      ///     * <returns> JDFExternalImpositionTemplate the element </returns>
      ///     
      public virtual JDFExternalImpositionTemplate getExternalImpositionTemplate()
      {
         return (JDFExternalImpositionTemplate)getElement(ElementName.EXTERNALIMPOSITIONTEMPLATE, null, 0);
      }

      ///     <summary> (25) getCreateExternalImpositionTemplate
      ///     *  </summary>
      ///     * <returns> JDFExternalImpositionTemplate the element </returns>
      ///     
      public virtual JDFExternalImpositionTemplate getCreateExternalImpositionTemplate()
      {
         return (JDFExternalImpositionTemplate)getCreateElement_KElement(ElementName.EXTERNALIMPOSITIONTEMPLATE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ExternalImpositionTemplate </summary>
      ///     
      public virtual JDFExternalImpositionTemplate appendExternalImpositionTemplate()
      {
         return (JDFExternalImpositionTemplate)appendElementN(ElementName.EXTERNALIMPOSITIONTEMPLATE, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refExternalImpositionTemplate(JDFExternalImpositionTemplate refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreateMedia
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFMedia the element </returns>
      ///     
      public virtual JDFMedia getCreateMedia(int iSkip)
      {
         return (JDFMedia)getCreateElement_KElement(ElementName.MEDIA, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Media </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFMedia the element </returns>
      ///     * default is getMedia(0)     
      public virtual JDFMedia getMedia(int iSkip)
      {
         return (JDFMedia)getElement(ElementName.MEDIA, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Media from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFMedia> </returns>
      ///     
      public virtual ICollection<JDFMedia> getAllMedia()
      {
         List<JDFMedia> v = new List<JDFMedia>();

         JDFMedia kElem = (JDFMedia)getFirstChildElement(ElementName.MEDIA, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFMedia)kElem.getNextSiblingElement(ElementName.MEDIA, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Media </summary>
      ///     
      public virtual JDFMedia appendMedia()
      {
         return (JDFMedia)appendElement(ElementName.MEDIA, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refMedia(JDFMedia refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreatePosition
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFPosition the element </returns>
      ///     
      public virtual JDFPosition getCreatePosition(int iSkip)
      {
         return (JDFPosition)getCreateElement_KElement(ElementName.POSITION, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Position </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFPosition the element </returns>
      ///     * default is getPosition(0)     
      public virtual JDFPosition getPosition(int iSkip)
      {
         return (JDFPosition)getElement(ElementName.POSITION, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Position from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFPosition> </returns>
      ///     
      public virtual ICollection<JDFPosition> getAllPosition()
      {
         List<JDFPosition> v = new List<JDFPosition>();

         JDFPosition kElem = (JDFPosition)getFirstChildElement(ElementName.POSITION, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFPosition)kElem.getNextSiblingElement(ElementName.POSITION, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Position </summary>
      ///     
      public virtual JDFPosition appendPosition()
      {
         return (JDFPosition)appendElement(ElementName.POSITION, null);
      }

      ///    
      ///     <summary> * (24) const get element StripCellParams </summary>
      ///     * <returns> JDFStripCellParams the element </returns>
      ///     
      public virtual JDFStripCellParams getStripCellParams()
      {
         return (JDFStripCellParams)getElement(ElementName.STRIPCELLPARAMS, null, 0);
      }

      ///     <summary> (25) getCreateStripCellParams
      ///     *  </summary>
      ///     * <returns> JDFStripCellParams the element </returns>
      ///     
      public virtual JDFStripCellParams getCreateStripCellParams()
      {
         return (JDFStripCellParams)getCreateElement_KElement(ElementName.STRIPCELLPARAMS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element StripCellParams </summary>
      ///     
      public virtual JDFStripCellParams appendStripCellParams()
      {
         return (JDFStripCellParams)appendElementN(ElementName.STRIPCELLPARAMS, 1, null);
      }

      ///     <summary> (26) getCreateStripMark
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFStripMark the element </returns>
      ///     
      public virtual JDFStripMark getCreateStripMark(int iSkip)
      {
         return (JDFStripMark)getCreateElement_KElement(ElementName.STRIPMARK, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element StripMark </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFStripMark the element </returns>
      ///     * default is getStripMark(0)     
      public virtual JDFStripMark getStripMark(int iSkip)
      {
         return (JDFStripMark)getElement(ElementName.STRIPMARK, null, iSkip);
      }

      ///    
      ///     <summary> * Get all StripMark from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFStripMark> </returns>
      ///     
      public virtual ICollection<JDFStripMark> getAllStripMark()
      {
         List<JDFStripMark> v = new List<JDFStripMark>();

         JDFStripMark kElem = (JDFStripMark)getFirstChildElement(ElementName.STRIPMARK, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFStripMark)kElem.getNextSiblingElement(ElementName.STRIPMARK, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element StripMark </summary>
      ///     
      public virtual JDFStripMark appendStripMark()
      {
         return (JDFStripMark)appendElement(ElementName.STRIPMARK, null);
      }
   }
}
