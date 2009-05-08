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
   using JDFRectangle = org.cip4.jdflib.datatypes.JDFRectangle;
   using JDFLayerList = org.cip4.jdflib.resource.JDFLayerList;
   using JDFMarkObject = org.cip4.jdflib.resource.JDFMarkObject;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFSignature = org.cip4.jdflib.resource.JDFSignature;
   using JDFContentObject = org.cip4.jdflib.resource.process.JDFContentObject;
   using JDFInsertSheet = org.cip4.jdflib.resource.process.JDFInsertSheet;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;
   using JDFMediaSource = org.cip4.jdflib.resource.process.JDFMediaSource;
   using JDFTransferCurvePool = org.cip4.jdflib.resource.process.JDFTransferCurvePool;

   public abstract class JDFAutoLayout : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[8];
      static JDFAutoLayout()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.AUTOMATED, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.LOCKORIGINS, 0x33333111, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.MAXDOCORD, 0x33333331, AttributeInfo.EnumAttributeType.integer, null, "1");
         atrInfoTable[3] = new AtrInfoTable(AttributeName.MAXSETORD, 0x33333331, AttributeInfo.EnumAttributeType.integer, null, "1");
         atrInfoTable[4] = new AtrInfoTable(AttributeName.NAME, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.MAXORD, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.SOURCEWORKSTYLE, 0x33333111, AttributeInfo.EnumAttributeType.enumeration, EnumSourceWorkStyle.getEnum(0), null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.SURFACECONTENTSBOX, 0x33333111, AttributeInfo.EnumAttributeType.rectangle, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.CONTENTOBJECT, 0x33333333);
         elemInfoTable[1] = new ElemInfoTable(ElementName.INSERTSHEET, 0x33333333);
         elemInfoTable[2] = new ElemInfoTable(ElementName.LAYERLIST, 0x66666661);
         elemInfoTable[3] = new ElemInfoTable(ElementName.MARKOBJECT, 0x33333333);
         elemInfoTable[4] = new ElemInfoTable(ElementName.MEDIA, 0x33333331);
         elemInfoTable[5] = new ElemInfoTable(ElementName.MEDIASOURCE, 0x77777776);
         elemInfoTable[6] = new ElemInfoTable(ElementName.SIGNATURE, 0x44444333);
         elemInfoTable[7] = new ElemInfoTable(ElementName.TRANSFERCURVEPOOL, 0x66666661);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[8];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoLayout </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoLayout(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoLayout </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoLayout(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoLayout </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoLayout(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoLayout[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for SourceWorkStyle </summary>
      ///        

      public class EnumSourceWorkStyle : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumSourceWorkStyle(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumSourceWorkStyle getEnum(string enumName)
         {
            return (EnumSourceWorkStyle)getEnum(typeof(EnumSourceWorkStyle), enumName);
         }

         public static EnumSourceWorkStyle getEnum(int enumValue)
         {
            return (EnumSourceWorkStyle)getEnum(typeof(EnumSourceWorkStyle), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumSourceWorkStyle));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumSourceWorkStyle));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumSourceWorkStyle));
         }

         public static readonly EnumSourceWorkStyle Simplex = new EnumSourceWorkStyle("Simplex");
         public static readonly EnumSourceWorkStyle WorkAndBack = new EnumSourceWorkStyle("WorkAndBack");
         public static readonly EnumSourceWorkStyle Perfecting = new EnumSourceWorkStyle("Perfecting");
         public static readonly EnumSourceWorkStyle WorkAndTurn = new EnumSourceWorkStyle("WorkAndTurn");
         public static readonly EnumSourceWorkStyle WorkAndTumble = new EnumSourceWorkStyle("WorkAndTumble");
         public static readonly EnumSourceWorkStyle WorkAndTwist = new EnumSourceWorkStyle("WorkAndTwist");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute Automated
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Automated </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAutomated(bool @value)
      {
         setAttribute(AttributeName.AUTOMATED, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute Automated </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getAutomated()
      {
         return getBoolAttribute(AttributeName.AUTOMATED, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute LockOrigins
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute LockOrigins </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setLockOrigins(bool @value)
      {
         setAttribute(AttributeName.LOCKORIGINS, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute LockOrigins </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getLockOrigins()
      {
         return getBoolAttribute(AttributeName.LOCKORIGINS, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MaxDocOrd
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MaxDocOrd </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMaxDocOrd(int @value)
      {
         setAttribute(AttributeName.MAXDOCORD, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute MaxDocOrd </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getMaxDocOrd()
      {
         return getIntAttribute(AttributeName.MAXDOCORD, null, 1);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MaxSetOrd
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MaxSetOrd </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMaxSetOrd(int @value)
      {
         setAttribute(AttributeName.MAXSETORD, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute MaxSetOrd </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getMaxSetOrd()
      {
         return getIntAttribute(AttributeName.MAXSETORD, null, 1);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Name
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Name </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setName(string @value)
      {
         setAttribute(AttributeName.NAME, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Name </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getName()
      {
         return getAttribute(AttributeName.NAME, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MaxOrd
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MaxOrd </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMaxOrd(int @value)
      {
         setAttribute(AttributeName.MAXORD, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute MaxOrd </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getMaxOrd()
      {
         return getIntAttribute(AttributeName.MAXORD, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SourceWorkStyle
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute SourceWorkStyle </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setSourceWorkStyle(EnumSourceWorkStyle enumVar)
      {
         setAttribute(AttributeName.SOURCEWORKSTYLE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute SourceWorkStyle </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumSourceWorkStyle getSourceWorkStyle()
      {
         return EnumSourceWorkStyle.getEnum(getAttribute(AttributeName.SOURCEWORKSTYLE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SurfaceContentsBox
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SurfaceContentsBox </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSurfaceContentsBox(JDFRectangle @value)
      {
         setAttribute(AttributeName.SURFACECONTENTSBOX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFRectangle attribute SurfaceContentsBox </summary>
      ///          * <returns> JDFRectangle the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFRectangle </returns>
      ///          
      public virtual JDFRectangle getSurfaceContentsBox()
      {
         string strAttrName = "";
         JDFRectangle nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.SURFACECONTENTSBOX, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFRectangle(strAttrName);
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

      ///     <summary> (26) getCreateContentObject
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFContentObject the element </returns>
      ///     
      public virtual JDFContentObject getCreateContentObject(int iSkip)
      {
         return (JDFContentObject)getCreateElement_KElement(ElementName.CONTENTOBJECT, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element ContentObject </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFContentObject the element </returns>
      ///     * default is getContentObject(0)     
      public virtual JDFContentObject getContentObject(int iSkip)
      {
         return (JDFContentObject)getElement(ElementName.CONTENTOBJECT, null, iSkip);
      }

      ///    
      ///     <summary> * Get all ContentObject from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFContentObject> </returns>
      ///     
      public virtual ICollection<JDFContentObject> getAllContentObject()
      {
         List<JDFContentObject> v = new List<JDFContentObject>();

         JDFContentObject kElem = (JDFContentObject)getFirstChildElement(ElementName.CONTENTOBJECT, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFContentObject)kElem.getNextSiblingElement(ElementName.CONTENTOBJECT, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element ContentObject </summary>
      ///     
      public virtual JDFContentObject appendContentObject()
      {
         return (JDFContentObject)appendElement(ElementName.CONTENTOBJECT, null);
      }

      ///     <summary> (26) getCreateInsertSheet
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFInsertSheet the element </returns>
      ///     
      public virtual JDFInsertSheet getCreateInsertSheet(int iSkip)
      {
         return (JDFInsertSheet)getCreateElement_KElement(ElementName.INSERTSHEET, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element InsertSheet </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFInsertSheet the element </returns>
      ///     * default is getInsertSheet(0)     
      public virtual JDFInsertSheet getInsertSheet(int iSkip)
      {
         return (JDFInsertSheet)getElement(ElementName.INSERTSHEET, null, iSkip);
      }

      ///    
      ///     <summary> * Get all InsertSheet from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFInsertSheet> </returns>
      ///     
      public virtual ICollection<JDFInsertSheet> getAllInsertSheet()
      {
         List<JDFInsertSheet> v = new List<JDFInsertSheet>();

         JDFInsertSheet kElem = (JDFInsertSheet)getFirstChildElement(ElementName.INSERTSHEET, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFInsertSheet)kElem.getNextSiblingElement(ElementName.INSERTSHEET, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element InsertSheet </summary>
      ///     
      public virtual JDFInsertSheet appendInsertSheet()
      {
         return (JDFInsertSheet)appendElement(ElementName.INSERTSHEET, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refInsertSheet(JDFInsertSheet refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element LayerList </summary>
      ///     * <returns> JDFLayerList the element </returns>
      ///     
      public virtual JDFLayerList getLayerList()
      {
         return (JDFLayerList)getElement(ElementName.LAYERLIST, null, 0);
      }

      ///     <summary> (25) getCreateLayerList
      ///     *  </summary>
      ///     * <returns> JDFLayerList the element </returns>
      ///     
      public virtual JDFLayerList getCreateLayerList()
      {
         return (JDFLayerList)getCreateElement_KElement(ElementName.LAYERLIST, null, 0);
      }

      ///    
      ///     <summary> * (29) append element LayerList </summary>
      ///     
      public virtual JDFLayerList appendLayerList()
      {
         return (JDFLayerList)appendElementN(ElementName.LAYERLIST, 1, null);
      }

      ///     <summary> (26) getCreateMarkObject
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFMarkObject the element </returns>
      ///     
      public virtual JDFMarkObject getCreateMarkObject(int iSkip)
      {
         return (JDFMarkObject)getCreateElement_KElement(ElementName.MARKOBJECT, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element MarkObject </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFMarkObject the element </returns>
      ///     * default is getMarkObject(0)     
      public virtual JDFMarkObject getMarkObject(int iSkip)
      {
         return (JDFMarkObject)getElement(ElementName.MARKOBJECT, null, iSkip);
      }

      ///    
      ///     <summary> * Get all MarkObject from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFMarkObject> </returns>
      ///     
      public virtual ICollection<JDFMarkObject> getAllMarkObject()
      {
         List<JDFMarkObject> v = new List<JDFMarkObject>();

         JDFMarkObject kElem = (JDFMarkObject)getFirstChildElement(ElementName.MARKOBJECT, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFMarkObject)kElem.getNextSiblingElement(ElementName.MARKOBJECT, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element MarkObject </summary>
      ///     
      public virtual JDFMarkObject appendMarkObject()
      {
         return (JDFMarkObject)appendElement(ElementName.MARKOBJECT, null);
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

      ///    
      ///     <summary> * (24) const get element MediaSource </summary>
      ///     * <returns> JDFMediaSource the element </returns>
      ///     
      public virtual JDFMediaSource getMediaSource()
      {
         return (JDFMediaSource)getElement(ElementName.MEDIASOURCE, null, 0);
      }

      ///     <summary> (25) getCreateMediaSource
      ///     *  </summary>
      ///     * <returns> JDFMediaSource the element </returns>
      ///     
      public virtual JDFMediaSource getCreateMediaSource()
      {
         return (JDFMediaSource)getCreateElement_KElement(ElementName.MEDIASOURCE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element MediaSource </summary>
      ///     
      public virtual JDFMediaSource appendMediaSource()
      {
         return (JDFMediaSource)appendElementN(ElementName.MEDIASOURCE, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refMediaSource(JDFMediaSource refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreateSignature
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFSignature the element </returns>
      ///     
      public virtual JDFSignature getCreateSignature(int iSkip)
      {
         return (JDFSignature)getCreateElement_KElement(ElementName.SIGNATURE, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Signature </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFSignature the element </returns>
      ///     * default is getSignature(0)     
      public virtual JDFSignature getSignature(int iSkip)
      {
         return (JDFSignature)getElement(ElementName.SIGNATURE, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Signature from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFSignature> </returns>
      ///     
      public virtual ICollection<JDFSignature> getAllSignature()
      {
         List<JDFSignature> v = new List<JDFSignature>();

         JDFSignature kElem = (JDFSignature)getFirstChildElement(ElementName.SIGNATURE, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFSignature)kElem.getNextSiblingElement(ElementName.SIGNATURE, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Signature </summary>
      ///     
      public virtual JDFSignature appendSignature()
      {
         return (JDFSignature)appendElement(ElementName.SIGNATURE, null);
      }

      ///    
      ///     <summary> * (24) const get element TransferCurvePool </summary>
      ///     * <returns> JDFTransferCurvePool the element </returns>
      ///     
      public virtual JDFTransferCurvePool getTransferCurvePool()
      {
         return (JDFTransferCurvePool)getElement(ElementName.TRANSFERCURVEPOOL, null, 0);
      }

      ///     <summary> (25) getCreateTransferCurvePool
      ///     *  </summary>
      ///     * <returns> JDFTransferCurvePool the element </returns>
      ///     
      public virtual JDFTransferCurvePool getCreateTransferCurvePool()
      {
         return (JDFTransferCurvePool)getCreateElement_KElement(ElementName.TRANSFERCURVEPOOL, null, 0);
      }

      ///    
      ///     <summary> * (29) append element TransferCurvePool </summary>
      ///     
      public virtual JDFTransferCurvePool appendTransferCurvePool()
      {
         return (JDFTransferCurvePool)appendElementN(ElementName.TRANSFERCURVEPOOL, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refTransferCurvePool(JDFTransferCurvePool refTarget)
      {
         refElement(refTarget);
      }
   }
}
