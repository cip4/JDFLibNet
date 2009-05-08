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
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFMatrix = org.cip4.jdflib.datatypes.JDFMatrix;
   using JDFRectangle = org.cip4.jdflib.datatypes.JDFRectangle;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFDeviceMark = org.cip4.jdflib.resource.JDFDeviceMark;
   using JDFJobField = org.cip4.jdflib.resource.JDFJobField;
   using JDFScavengerArea = org.cip4.jdflib.resource.JDFScavengerArea;
   using JDFCIELABMeasuringField = org.cip4.jdflib.resource.process.JDFCIELABMeasuringField;
   using JDFColorControlStrip = org.cip4.jdflib.resource.process.JDFColorControlStrip;
   using JDFDensityMeasuringField = org.cip4.jdflib.resource.process.JDFDensityMeasuringField;
   using JDFDynamicField = org.cip4.jdflib.resource.process.JDFDynamicField;
   using JDFIdentificationField = org.cip4.jdflib.resource.process.JDFIdentificationField;
   using JDFLayoutElement = org.cip4.jdflib.resource.process.JDFLayoutElement;
   using JDFRegisterMark = org.cip4.jdflib.resource.process.JDFRegisterMark;
   using JDFCutMark = org.cip4.jdflib.resource.process.postpress.JDFCutMark;

   public abstract class JDFAutoMarkObject : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[12];
      static JDFAutoMarkObject()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.TYPE, 0x44444443, AttributeInfo.EnumAttributeType.enumeration, EnumType.getEnum(0), null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.TRIMCTM, 0x33333331, AttributeInfo.EnumAttributeType.matrix, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.ORDID, 0x33333331, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.LAYOUTELEMENTPAGENUM, 0x33333331, AttributeInfo.EnumAttributeType.integer, null, "0");
         atrInfoTable[4] = new AtrInfoTable(AttributeName.SOURCECLIPPATH, 0x33333333, AttributeInfo.EnumAttributeType.PDFPath, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.CLIPBOX, 0x33333333, AttributeInfo.EnumAttributeType.rectangle, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.LAYERID, 0x33333331, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.CTM, 0x22222222, AttributeInfo.EnumAttributeType.matrix, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.CLIPPATH, 0x33333333, AttributeInfo.EnumAttributeType.PDFPath, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.ORD, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[10] = new AtrInfoTable(AttributeName.TRIMSIZE, 0x33333311, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[11] = new AtrInfoTable(AttributeName.HALFTONEPHASEORIGIN, 0x33333333, AttributeInfo.EnumAttributeType.XYPair, null, "0 0");
         elemInfoTable[0] = new ElemInfoTable(ElementName.CIELABMEASURINGFIELD, 0x33333333);
         elemInfoTable[1] = new ElemInfoTable(ElementName.COLORCONTROLSTRIP, 0x33333333);
         elemInfoTable[2] = new ElemInfoTable(ElementName.CUTMARK, 0x33333333);
         elemInfoTable[3] = new ElemInfoTable(ElementName.DENSITYMEASURINGFIELD, 0x33333333);
         elemInfoTable[4] = new ElemInfoTable(ElementName.DEVICEMARK, 0x77777661);
         elemInfoTable[5] = new ElemInfoTable(ElementName.DYNAMICFIELD, 0x33333333);
         elemInfoTable[6] = new ElemInfoTable(ElementName.IDENTIFICATIONFIELD, 0x33333333);
         elemInfoTable[7] = new ElemInfoTable(ElementName.JOBFIELD, 0x33333331);
         elemInfoTable[8] = new ElemInfoTable(ElementName.LAYOUTELEMENT, 0x66666666);
         elemInfoTable[9] = new ElemInfoTable(ElementName.REGISTERMARK, 0x33333333);
         elemInfoTable[10] = new ElemInfoTable(ElementName.SCAVENGERAREA, 0x33333331);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[11];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoMarkObject </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoMarkObject(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoMarkObject </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoMarkObject(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoMarkObject </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoMarkObject(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoMarkObject[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for Type </summary>
      ///        

      public class EnumType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumType getEnum(string enumName)
         {
            return (EnumType)getEnum(typeof(EnumType), enumName);
         }

         public static EnumType getEnum(int enumValue)
         {
            return (EnumType)getEnum(typeof(EnumType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumType));
         }

         public static readonly EnumType Content = new EnumType("Content");
         public static readonly EnumType Mark = new EnumType("Mark");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute Type
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Type </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setType(EnumType enumVar)
      {
         setAttribute(AttributeName.TYPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Type </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumType getType()
      {
         return EnumType.getEnum(getAttribute(AttributeName.TYPE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TrimCTM
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TrimCTM </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTrimCTM(JDFMatrix @value)
      {
         setAttribute(AttributeName.TRIMCTM, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFMatrix attribute TrimCTM </summary>
      ///          * <returns> JDFMatrix the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFMatrix </returns>
      ///          
      public virtual JDFMatrix getTrimCTM()
      {
         string strAttrName = "";
         JDFMatrix nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.TRIMCTM, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFMatrix(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute OrdID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute OrdID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setOrdID(int @value)
      {
         setAttribute(AttributeName.ORDID, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute OrdID </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getOrdID()
      {
         return getIntAttribute(AttributeName.ORDID, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute LayoutElementPageNum
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute LayoutElementPageNum </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setLayoutElementPageNum(int @value)
      {
         setAttribute(AttributeName.LAYOUTELEMENTPAGENUM, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute LayoutElementPageNum </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getLayoutElementPageNum()
      {
         return getIntAttribute(AttributeName.LAYOUTELEMENTPAGENUM, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SourceClipPath
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SourceClipPath </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSourceClipPath(string @value)
      {
         setAttribute(AttributeName.SOURCECLIPPATH, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute SourceClipPath </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getSourceClipPath()
      {
         return getAttribute(AttributeName.SOURCECLIPPATH, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ClipBox
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ClipBox </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setClipBox(JDFRectangle @value)
      {
         setAttribute(AttributeName.CLIPBOX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFRectangle attribute ClipBox </summary>
      ///          * <returns> JDFRectangle the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFRectangle </returns>
      ///          
      public virtual JDFRectangle getClipBox()
      {
         string strAttrName = "";
         JDFRectangle nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.CLIPBOX, null, JDFConstants.EMPTYSTRING);
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


      //         ---------------------------------------------------------------------
      //        Methods for Attribute LayerID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute LayerID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setLayerID(int @value)
      {
         setAttribute(AttributeName.LAYERID, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute LayerID </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getLayerID()
      {
         return getIntAttribute(AttributeName.LAYERID, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute CTM
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CTM </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCTM(JDFMatrix @value)
      {
         setAttribute(AttributeName.CTM, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFMatrix attribute CTM </summary>
      ///          * <returns> JDFMatrix the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFMatrix </returns>
      ///          
      public virtual JDFMatrix getCTM()
      {
         string strAttrName = "";
         JDFMatrix nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.CTM, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFMatrix(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ClipPath
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ClipPath </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setClipPath(string @value)
      {
         setAttribute(AttributeName.CLIPPATH, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ClipPath </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getClipPath()
      {
         return getAttribute(AttributeName.CLIPPATH, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Ord
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Ord </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setOrd(int @value)
      {
         setAttribute(AttributeName.ORD, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute Ord </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getOrd()
      {
         return getIntAttribute(AttributeName.ORD, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TrimSize
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TrimSize </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTrimSize(JDFXYPair @value)
      {
         setAttribute(AttributeName.TRIMSIZE, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute TrimSize </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getTrimSize()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.TRIMSIZE, null, JDFConstants.EMPTYSTRING);
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


      //         ---------------------------------------------------------------------
      //        Methods for Attribute HalfTonePhaseOrigin
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute HalfTonePhaseOrigin </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setHalfTonePhaseOrigin(JDFXYPair @value)
      {
         setAttribute(AttributeName.HALFTONEPHASEORIGIN, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute HalfTonePhaseOrigin </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getHalfTonePhaseOrigin()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.HALFTONEPHASEORIGIN, null, JDFConstants.EMPTYSTRING);
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

      ///     <summary> (26) getCreateCIELABMeasuringField
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFCIELABMeasuringField the element </returns>
      ///     
      public virtual JDFCIELABMeasuringField getCreateCIELABMeasuringField(int iSkip)
      {
         return (JDFCIELABMeasuringField)getCreateElement_KElement(ElementName.CIELABMEASURINGFIELD, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element CIELABMeasuringField </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFCIELABMeasuringField the element </returns>
      ///     * default is getCIELABMeasuringField(0)     
      public virtual JDFCIELABMeasuringField getCIELABMeasuringField(int iSkip)
      {
         return (JDFCIELABMeasuringField)getElement(ElementName.CIELABMEASURINGFIELD, null, iSkip);
      }

      ///    
      ///     <summary> * Get all CIELABMeasuringField from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFCIELABMeasuringField> </returns>
      ///     
      public virtual ICollection<JDFCIELABMeasuringField> getAllCIELABMeasuringField()
      {
         List<JDFCIELABMeasuringField> v = new List<JDFCIELABMeasuringField>();

         JDFCIELABMeasuringField kElem = (JDFCIELABMeasuringField)getFirstChildElement(ElementName.CIELABMEASURINGFIELD, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFCIELABMeasuringField)kElem.getNextSiblingElement(ElementName.CIELABMEASURINGFIELD, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element CIELABMeasuringField </summary>
      ///     
      public virtual JDFCIELABMeasuringField appendCIELABMeasuringField()
      {
         return (JDFCIELABMeasuringField)appendElement(ElementName.CIELABMEASURINGFIELD, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refCIELABMeasuringField(JDFCIELABMeasuringField refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreateColorControlStrip
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFColorControlStrip the element </returns>
      ///     
      public virtual JDFColorControlStrip getCreateColorControlStrip(int iSkip)
      {
         return (JDFColorControlStrip)getCreateElement_KElement(ElementName.COLORCONTROLSTRIP, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element ColorControlStrip </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFColorControlStrip the element </returns>
      ///     * default is getColorControlStrip(0)     
      public virtual JDFColorControlStrip getColorControlStrip(int iSkip)
      {
         return (JDFColorControlStrip)getElement(ElementName.COLORCONTROLSTRIP, null, iSkip);
      }

      ///    
      ///     <summary> * Get all ColorControlStrip from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFColorControlStrip> </returns>
      ///     
      public virtual ICollection<JDFColorControlStrip> getAllColorControlStrip()
      {
         List<JDFColorControlStrip> v = new List<JDFColorControlStrip>();

         JDFColorControlStrip kElem = (JDFColorControlStrip)getFirstChildElement(ElementName.COLORCONTROLSTRIP, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFColorControlStrip)kElem.getNextSiblingElement(ElementName.COLORCONTROLSTRIP, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element ColorControlStrip </summary>
      ///     
      public virtual JDFColorControlStrip appendColorControlStrip()
      {
         return (JDFColorControlStrip)appendElement(ElementName.COLORCONTROLSTRIP, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refColorControlStrip(JDFColorControlStrip refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreateCutMark
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFCutMark the element </returns>
      ///     
      public virtual JDFCutMark getCreateCutMark(int iSkip)
      {
         return (JDFCutMark)getCreateElement_KElement(ElementName.CUTMARK, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element CutMark </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFCutMark the element </returns>
      ///     * default is getCutMark(0)     
      public virtual JDFCutMark getCutMark(int iSkip)
      {
         return (JDFCutMark)getElement(ElementName.CUTMARK, null, iSkip);
      }

      ///    
      ///     <summary> * Get all CutMark from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFCutMark> </returns>
      ///     
      public virtual ICollection<JDFCutMark> getAllCutMark()
      {
         List<JDFCutMark> v = new List<JDFCutMark>();

         JDFCutMark kElem = (JDFCutMark)getFirstChildElement(ElementName.CUTMARK, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFCutMark)kElem.getNextSiblingElement(ElementName.CUTMARK, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element CutMark </summary>
      ///     
      public virtual JDFCutMark appendCutMark()
      {
         return (JDFCutMark)appendElement(ElementName.CUTMARK, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refCutMark(JDFCutMark refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreateDensityMeasuringField
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFDensityMeasuringField the element </returns>
      ///     
      public virtual JDFDensityMeasuringField getCreateDensityMeasuringField(int iSkip)
      {
         return (JDFDensityMeasuringField)getCreateElement_KElement(ElementName.DENSITYMEASURINGFIELD, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element DensityMeasuringField </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFDensityMeasuringField the element </returns>
      ///     * default is getDensityMeasuringField(0)     
      public virtual JDFDensityMeasuringField getDensityMeasuringField(int iSkip)
      {
         return (JDFDensityMeasuringField)getElement(ElementName.DENSITYMEASURINGFIELD, null, iSkip);
      }

      ///    
      ///     <summary> * Get all DensityMeasuringField from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFDensityMeasuringField> </returns>
      ///     
      public virtual ICollection<JDFDensityMeasuringField> getAllDensityMeasuringField()
      {
         List<JDFDensityMeasuringField> v = new List<JDFDensityMeasuringField>();

         JDFDensityMeasuringField kElem = (JDFDensityMeasuringField)getFirstChildElement(ElementName.DENSITYMEASURINGFIELD, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFDensityMeasuringField)kElem.getNextSiblingElement(ElementName.DENSITYMEASURINGFIELD, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element DensityMeasuringField </summary>
      ///     
      public virtual JDFDensityMeasuringField appendDensityMeasuringField()
      {
         return (JDFDensityMeasuringField)appendElement(ElementName.DENSITYMEASURINGFIELD, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refDensityMeasuringField(JDFDensityMeasuringField refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element DeviceMark </summary>
      ///     * <returns> JDFDeviceMark the element </returns>
      ///     
      public virtual JDFDeviceMark getDeviceMark()
      {
         return (JDFDeviceMark)getElement(ElementName.DEVICEMARK, null, 0);
      }

      ///     <summary> (25) getCreateDeviceMark
      ///     *  </summary>
      ///     * <returns> JDFDeviceMark the element </returns>
      ///     
      public virtual JDFDeviceMark getCreateDeviceMark()
      {
         return (JDFDeviceMark)getCreateElement_KElement(ElementName.DEVICEMARK, null, 0);
      }

      ///    
      ///     <summary> * (29) append element DeviceMark </summary>
      ///     
      public virtual JDFDeviceMark appendDeviceMark()
      {
         return (JDFDeviceMark)appendElementN(ElementName.DEVICEMARK, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refDeviceMark(JDFDeviceMark refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreateDynamicField
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFDynamicField the element </returns>
      ///     
      public virtual JDFDynamicField getCreateDynamicField(int iSkip)
      {
         return (JDFDynamicField)getCreateElement_KElement(ElementName.DYNAMICFIELD, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element DynamicField </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFDynamicField the element </returns>
      ///     * default is getDynamicField(0)     
      public virtual JDFDynamicField getDynamicField(int iSkip)
      {
         return (JDFDynamicField)getElement(ElementName.DYNAMICFIELD, null, iSkip);
      }

      ///    
      ///     <summary> * Get all DynamicField from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFDynamicField> </returns>
      ///     
      public virtual ICollection<JDFDynamicField> getAllDynamicField()
      {
         List<JDFDynamicField> v = new List<JDFDynamicField>();

         JDFDynamicField kElem = (JDFDynamicField)getFirstChildElement(ElementName.DYNAMICFIELD, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFDynamicField)kElem.getNextSiblingElement(ElementName.DYNAMICFIELD, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element DynamicField </summary>
      ///     
      public virtual JDFDynamicField appendDynamicField()
      {
         return (JDFDynamicField)appendElement(ElementName.DYNAMICFIELD, null);
      }

      ///     <summary> (26) getCreateIdentificationField
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFIdentificationField the element </returns>
      ///     
      public virtual JDFIdentificationField getCreateIdentificationField(int iSkip)
      {
         return (JDFIdentificationField)getCreateElement_KElement(ElementName.IDENTIFICATIONFIELD, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element IdentificationField </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFIdentificationField the element </returns>
      ///     * default is getIdentificationField(0)     
      public virtual JDFIdentificationField getIdentificationField(int iSkip)
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
      public virtual JDFIdentificationField appendIdentificationField()
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

      ///     <summary> (26) getCreateJobField
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFJobField the element </returns>
      ///     
      public virtual JDFJobField getCreateJobField(int iSkip)
      {
         return (JDFJobField)getCreateElement_KElement(ElementName.JOBFIELD, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element JobField </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFJobField the element </returns>
      ///     * default is getJobField(0)     
      public virtual JDFJobField getJobField(int iSkip)
      {
         return (JDFJobField)getElement(ElementName.JOBFIELD, null, iSkip);
      }

      ///    
      ///     <summary> * Get all JobField from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFJobField> </returns>
      ///     
      public virtual ICollection<JDFJobField> getAllJobField()
      {
         List<JDFJobField> v = new List<JDFJobField>();

         JDFJobField kElem = (JDFJobField)getFirstChildElement(ElementName.JOBFIELD, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFJobField)kElem.getNextSiblingElement(ElementName.JOBFIELD, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element JobField </summary>
      ///     
      public virtual JDFJobField appendJobField()
      {
         return (JDFJobField)appendElement(ElementName.JOBFIELD, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refJobField(JDFJobField refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element LayoutElement </summary>
      ///     * <returns> JDFLayoutElement the element </returns>
      ///     
      public virtual JDFLayoutElement getLayoutElement()
      {
         return (JDFLayoutElement)getElement(ElementName.LAYOUTELEMENT, null, 0);
      }

      ///     <summary> (25) getCreateLayoutElement
      ///     *  </summary>
      ///     * <returns> JDFLayoutElement the element </returns>
      ///     
      public virtual JDFLayoutElement getCreateLayoutElement()
      {
         return (JDFLayoutElement)getCreateElement_KElement(ElementName.LAYOUTELEMENT, null, 0);
      }

      ///    
      ///     <summary> * (29) append element LayoutElement </summary>
      ///     
      public virtual JDFLayoutElement appendLayoutElement()
      {
         return (JDFLayoutElement)appendElementN(ElementName.LAYOUTELEMENT, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refLayoutElement(JDFLayoutElement refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreateRegisterMark
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFRegisterMark the element </returns>
      ///     
      public virtual JDFRegisterMark getCreateRegisterMark(int iSkip)
      {
         return (JDFRegisterMark)getCreateElement_KElement(ElementName.REGISTERMARK, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element RegisterMark </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFRegisterMark the element </returns>
      ///     * default is getRegisterMark(0)     
      public virtual JDFRegisterMark getRegisterMark(int iSkip)
      {
         return (JDFRegisterMark)getElement(ElementName.REGISTERMARK, null, iSkip);
      }

      ///    
      ///     <summary> * Get all RegisterMark from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFRegisterMark> </returns>
      ///     
      public virtual ICollection<JDFRegisterMark> getAllRegisterMark()
      {
         List<JDFRegisterMark> v = new List<JDFRegisterMark>();

         JDFRegisterMark kElem = (JDFRegisterMark)getFirstChildElement(ElementName.REGISTERMARK, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFRegisterMark)kElem.getNextSiblingElement(ElementName.REGISTERMARK, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element RegisterMark </summary>
      ///     
      public virtual JDFRegisterMark appendRegisterMark()
      {
         return (JDFRegisterMark)appendElement(ElementName.REGISTERMARK, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refRegisterMark(JDFRegisterMark refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreateScavengerArea
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFScavengerArea the element </returns>
      ///     
      public virtual JDFScavengerArea getCreateScavengerArea(int iSkip)
      {
         return (JDFScavengerArea)getCreateElement_KElement(ElementName.SCAVENGERAREA, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element ScavengerArea </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFScavengerArea the element </returns>
      ///     * default is getScavengerArea(0)     
      public virtual JDFScavengerArea getScavengerArea(int iSkip)
      {
         return (JDFScavengerArea)getElement(ElementName.SCAVENGERAREA, null, iSkip);
      }

      ///    
      ///     <summary> * Get all ScavengerArea from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFScavengerArea> </returns>
      ///     
      public virtual ICollection<JDFScavengerArea> getAllScavengerArea()
      {
         List<JDFScavengerArea> v = new List<JDFScavengerArea>();

         JDFScavengerArea kElem = (JDFScavengerArea)getFirstChildElement(ElementName.SCAVENGERAREA, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFScavengerArea)kElem.getNextSiblingElement(ElementName.SCAVENGERAREA, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element ScavengerArea </summary>
      ///     
      public virtual JDFScavengerArea appendScavengerArea()
      {
         return (JDFScavengerArea)appendElement(ElementName.SCAVENGERAREA, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refScavengerArea(JDFScavengerArea refTarget)
      {
         refElement(refTarget);
      }
   }
}
