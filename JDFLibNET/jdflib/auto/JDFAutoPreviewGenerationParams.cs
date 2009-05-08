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
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFImageSetterParams = org.cip4.jdflib.resource.process.JDFImageSetterParams;

   public abstract class JDFAutoPreviewGenerationParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[6];
      static JDFAutoPreviewGenerationParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ASPECTRATIO, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumAspectRatio.getEnum(0), "Ignore");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.PREVIEWFILETYPE, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumPreviewFileType.getEnum(0), "PNG");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.PREVIEWUSAGE, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumPreviewUsage.getEnum(0), "Separation");
         atrInfoTable[3] = new AtrInfoTable(AttributeName.COMPENSATION, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumCompensation.getEnum(0), null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.RESOLUTION, 0x33333333, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.SIZE, 0x33333333, AttributeInfo.EnumAttributeType.XYPair, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.IMAGESETTERPARAMS, 0x66666661);
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
      ///     <summary> * Constructor for JDFAutoPreviewGenerationParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPreviewGenerationParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPreviewGenerationParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPreviewGenerationParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPreviewGenerationParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoPreviewGenerationParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoPreviewGenerationParams[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for AspectRatio </summary>
      ///        

      public class EnumAspectRatio : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumAspectRatio(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumAspectRatio getEnum(string enumName)
         {
            return (EnumAspectRatio)getEnum(typeof(EnumAspectRatio), enumName);
         }

         public static EnumAspectRatio getEnum(int enumValue)
         {
            return (EnumAspectRatio)getEnum(typeof(EnumAspectRatio), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumAspectRatio));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumAspectRatio));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumAspectRatio));
         }

         public static readonly EnumAspectRatio Ignore = new EnumAspectRatio("Ignore");
         public static readonly EnumAspectRatio CenterMax = new EnumAspectRatio("CenterMax");
         public static readonly EnumAspectRatio CenterMin = new EnumAspectRatio("CenterMin");
         public static readonly EnumAspectRatio Crop = new EnumAspectRatio("Crop");
         public static readonly EnumAspectRatio Expand = new EnumAspectRatio("Expand");
      }



      ///        
      ///        <summary> * Enumeration strings for PreviewFileType </summary>
      ///        

      public class EnumPreviewFileType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumPreviewFileType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumPreviewFileType getEnum(string enumName)
         {
            return (EnumPreviewFileType)getEnum(typeof(EnumPreviewFileType), enumName);
         }

         public static EnumPreviewFileType getEnum(int enumValue)
         {
            return (EnumPreviewFileType)getEnum(typeof(EnumPreviewFileType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumPreviewFileType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumPreviewFileType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumPreviewFileType));
         }

         public static readonly EnumPreviewFileType PNG = new EnumPreviewFileType("PNG");
         public static readonly EnumPreviewFileType CIP3Multiple = new EnumPreviewFileType("CIP3Multiple");
         public static readonly EnumPreviewFileType CIP3Single = new EnumPreviewFileType("CIP3Single");
      }



      ///        
      ///        <summary> * Enumeration strings for PreviewUsage </summary>
      ///        

      public class EnumPreviewUsage : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumPreviewUsage(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumPreviewUsage getEnum(string enumName)
         {
            return (EnumPreviewUsage)getEnum(typeof(EnumPreviewUsage), enumName);
         }

         public static EnumPreviewUsage getEnum(int enumValue)
         {
            return (EnumPreviewUsage)getEnum(typeof(EnumPreviewUsage), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumPreviewUsage));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumPreviewUsage));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumPreviewUsage));
         }

         public static readonly EnumPreviewUsage Separation = new EnumPreviewUsage("Separation");
         public static readonly EnumPreviewUsage SeparatedThumbNail = new EnumPreviewUsage("SeparatedThumbNail");
         public static readonly EnumPreviewUsage SeparationRaw = new EnumPreviewUsage("SeparationRaw");
         public static readonly EnumPreviewUsage ThumbNail = new EnumPreviewUsage("ThumbNail");
         public static readonly EnumPreviewUsage Viewable = new EnumPreviewUsage("Viewable");
      }



      ///        
      ///        <summary> * Enumeration strings for Compensation </summary>
      ///        

      public class EnumCompensation : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumCompensation(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumCompensation getEnum(string enumName)
         {
            return (EnumCompensation)getEnum(typeof(EnumCompensation), enumName);
         }

         public static EnumCompensation getEnum(int enumValue)
         {
            return (EnumCompensation)getEnum(typeof(EnumCompensation), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumCompensation));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumCompensation));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumCompensation));
         }

         public static readonly EnumCompensation None = new EnumCompensation("None");
         public static readonly EnumCompensation Film = new EnumCompensation("Film");
         public static readonly EnumCompensation Plate = new EnumCompensation("Plate");
         public static readonly EnumCompensation Press = new EnumCompensation("Press");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute AspectRatio
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute AspectRatio </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setAspectRatio(EnumAspectRatio enumVar)
      {
         setAttribute(AttributeName.ASPECTRATIO, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute AspectRatio </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumAspectRatio getAspectRatio()
      {
         return EnumAspectRatio.getEnum(getAttribute(AttributeName.ASPECTRATIO, null, "Ignore"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PreviewFileType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute PreviewFileType </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setPreviewFileType(EnumPreviewFileType enumVar)
      {
         setAttribute(AttributeName.PREVIEWFILETYPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute PreviewFileType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumPreviewFileType getPreviewFileType()
      {
         return EnumPreviewFileType.getEnum(getAttribute(AttributeName.PREVIEWFILETYPE, null, "PNG"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PreviewUsage
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute PreviewUsage </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setPreviewUsage(EnumPreviewUsage enumVar)
      {
         setAttribute(AttributeName.PREVIEWUSAGE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute PreviewUsage </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumPreviewUsage getPreviewUsage()
      {
         return EnumPreviewUsage.getEnum(getAttribute(AttributeName.PREVIEWUSAGE, null, "Separation"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Compensation
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Compensation </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setCompensation(EnumCompensation enumVar)
      {
         setAttribute(AttributeName.COMPENSATION, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Compensation </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumCompensation getCompensation()
      {
         return EnumCompensation.getEnum(getAttribute(AttributeName.COMPENSATION, null, null));
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


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Size
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Size </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSize(JDFXYPair @value)
      {
         setAttribute(AttributeName.SIZE, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute Size </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getSize()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.SIZE, null, JDFConstants.EMPTYSTRING);
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
      ///     <summary> * (24) const get element ImageSetterParams </summary>
      ///     * <returns> JDFImageSetterParams the element </returns>
      ///     
      public virtual JDFImageSetterParams getImageSetterParams()
      {
         return (JDFImageSetterParams)getElement(ElementName.IMAGESETTERPARAMS, null, 0);
      }

      ///     <summary> (25) getCreateImageSetterParams
      ///     *  </summary>
      ///     * <returns> JDFImageSetterParams the element </returns>
      ///     
      public virtual JDFImageSetterParams getCreateImageSetterParams()
      {
         return (JDFImageSetterParams)getCreateElement_KElement(ElementName.IMAGESETTERPARAMS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ImageSetterParams </summary>
      ///     
      public virtual JDFImageSetterParams appendImageSetterParams()
      {
         return (JDFImageSetterParams)appendElementN(ElementName.IMAGESETTERPARAMS, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refImageSetterParams(JDFImageSetterParams refTarget)
      {
         refElement(refTarget);
      }
   }
}
