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
   using VString = org.cip4.jdflib.core.VString;
   using JDFRectangle = org.cip4.jdflib.datatypes.JDFRectangle;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFDeviceMark = org.cip4.jdflib.resource.JDFDeviceMark;
   using JDFFitPolicy = org.cip4.jdflib.resource.JDFFitPolicy;
   using JDFImageShift = org.cip4.jdflib.resource.JDFImageShift;
   using JDFColor = org.cip4.jdflib.resource.process.JDFColor;

   public abstract class JDFAutoPageCell : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[5];
      static JDFAutoPageCell()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.BORDER, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.CLIPBOX, 0x33333331, AttributeInfo.EnumAttributeType.rectangle, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.MARKLIST, 0x33333331, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.ROTATE, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumRotate.getEnum(0), "Rotate0");
         atrInfoTable[4] = new AtrInfoTable(AttributeName.TRIMSIZE, 0x33333331, AttributeInfo.EnumAttributeType.XYPair, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.COLOR, 0x66666661);
         elemInfoTable[1] = new ElemInfoTable(ElementName.DEVICEMARK, 0x66666661);
         elemInfoTable[2] = new ElemInfoTable(ElementName.FITPOLICY, 0x66666661);
         elemInfoTable[3] = new ElemInfoTable(ElementName.IMAGESHIFT, 0x66666661);
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
      ///     <summary> * Constructor for JDFAutoPageCell </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPageCell(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPageCell </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPageCell(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPageCell </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoPageCell(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoPageCell[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for Rotate </summary>
      ///        

      public class EnumRotate : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumRotate(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumRotate getEnum(string enumName)
         {
            return (EnumRotate)getEnum(typeof(EnumRotate), enumName);
         }

         public static EnumRotate getEnum(int enumValue)
         {
            return (EnumRotate)getEnum(typeof(EnumRotate), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumRotate));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumRotate));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumRotate));
         }

         public static readonly EnumRotate Rotate0 = new EnumRotate("Rotate0");
         public static readonly EnumRotate Rotate90 = new EnumRotate("Rotate90");
         public static readonly EnumRotate Rotate180 = new EnumRotate("Rotate180");
         public static readonly EnumRotate Rotate270 = new EnumRotate("Rotate270");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute Border
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Border </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBorder(double @value)
      {
         setAttribute(AttributeName.BORDER, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute Border </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getBorder()
      {
         return getRealAttribute(AttributeName.BORDER, null, 0.0);
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
      //        Methods for Attribute MarkList
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MarkList </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMarkList(VString @value)
      {
         setAttribute(AttributeName.MARKLIST, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute MarkList </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getMarkList()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.MARKLIST, null, JDFConstants.EMPTYSTRING);
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Rotate
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Rotate </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setRotate(EnumRotate enumVar)
      {
         setAttribute(AttributeName.ROTATE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Rotate </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumRotate getRotate()
      {
         return EnumRotate.getEnum(getAttribute(AttributeName.ROTATE, null, "Rotate0"));
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

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element Color </summary>
      ///     * <returns> JDFColor the element </returns>
      ///     
      public virtual JDFColor getColor()
      {
         return (JDFColor)getElement(ElementName.COLOR, null, 0);
      }

      ///     <summary> (25) getCreateColor
      ///     *  </summary>
      ///     * <returns> JDFColor the element </returns>
      ///     
      public virtual JDFColor getCreateColor()
      {
         return (JDFColor)getCreateElement_KElement(ElementName.COLOR, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Color </summary>
      ///     
      public virtual JDFColor appendColor()
      {
         return (JDFColor)appendElementN(ElementName.COLOR, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refColor(JDFColor refTarget)
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

      ///    
      ///     <summary> * (24) const get element FitPolicy </summary>
      ///     * <returns> JDFFitPolicy the element </returns>
      ///     
      public virtual JDFFitPolicy getFitPolicy()
      {
         return (JDFFitPolicy)getElement(ElementName.FITPOLICY, null, 0);
      }

      ///     <summary> (25) getCreateFitPolicy
      ///     *  </summary>
      ///     * <returns> JDFFitPolicy the element </returns>
      ///     
      public virtual JDFFitPolicy getCreateFitPolicy()
      {
         return (JDFFitPolicy)getCreateElement_KElement(ElementName.FITPOLICY, null, 0);
      }

      ///    
      ///     <summary> * (29) append element FitPolicy </summary>
      ///     
      public virtual JDFFitPolicy appendFitPolicy()
      {
         return (JDFFitPolicy)appendElementN(ElementName.FITPOLICY, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refFitPolicy(JDFFitPolicy refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element ImageShift </summary>
      ///     * <returns> JDFImageShift the element </returns>
      ///     
      public virtual JDFImageShift getImageShift()
      {
         return (JDFImageShift)getElement(ElementName.IMAGESHIFT, null, 0);
      }

      ///     <summary> (25) getCreateImageShift
      ///     *  </summary>
      ///     * <returns> JDFImageShift the element </returns>
      ///     
      public virtual JDFImageShift getCreateImageShift()
      {
         return (JDFImageShift)getCreateElement_KElement(ElementName.IMAGESHIFT, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ImageShift </summary>
      ///     
      public virtual JDFImageShift appendImageShift()
      {
         return (JDFImageShift)appendElementN(ElementName.IMAGESHIFT, 1, null);
      }
   }
}
