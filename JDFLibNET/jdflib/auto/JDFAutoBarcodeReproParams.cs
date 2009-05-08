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
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFBarcodeCompParams = org.cip4.jdflib.resource.process.JDFBarcodeCompParams;

   public abstract class JDFAutoBarcodeReproParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[7];
      static JDFAutoBarcodeReproParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.BEARERBARS, 0x33333111, AttributeInfo.EnumAttributeType.enumeration, EnumBearerBars.getEnum(0), null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.HEIGHT, 0x33333111, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.MAGNIFICATION, 0x33333111, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.MASKING, 0x33333111, AttributeInfo.EnumAttributeType.enumeration, EnumMasking.getEnum(0), null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.MODULEHEIGHT, 0x33333111, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.MODULEWIDTH, 0x33333111, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.RATIO, 0x33333111, AttributeInfo.EnumAttributeType.double_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.BARCODECOMPPARAMS, 0x33333111);
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
      ///     <summary> * Constructor for JDFAutoBarcodeReproParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoBarcodeReproParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoBarcodeReproParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoBarcodeReproParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoBarcodeReproParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoBarcodeReproParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      /// <summary>
      /// String representation of this object
      /// </summary>
      /// <returns>string</returns>
      public override string ToString()
      {
         return " JDFAutoBarcodeReproParams[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for BearerBars </summary>
      ///        

      public class EnumBearerBars : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumBearerBars(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumBearerBars getEnum(string enumName)
         {
            return (EnumBearerBars)getEnum(typeof(EnumBearerBars), enumName);
         }

         public static EnumBearerBars getEnum(int enumValue)
         {
            return (EnumBearerBars)getEnum(typeof(EnumBearerBars), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumBearerBars));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumBearerBars));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumBearerBars));
         }

         public static readonly EnumBearerBars None = new EnumBearerBars("None");
         public static readonly EnumBearerBars TopBottom = new EnumBearerBars("TopBottom");
         public static readonly EnumBearerBars Box = new EnumBearerBars("Box");
         public static readonly EnumBearerBars BoxHMarks = new EnumBearerBars("BoxHMarks");
      }



      ///        
      ///        <summary> * Enumeration strings for Masking </summary>
      ///        

      public class EnumMasking : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumMasking(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumMasking getEnum(string enumName)
         {
            return (EnumMasking)getEnum(typeof(EnumMasking), enumName);
         }

         public static EnumMasking getEnum(int enumValue)
         {
            return (EnumMasking)getEnum(typeof(EnumMasking), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumMasking));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumMasking));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumMasking));
         }

         public static readonly EnumMasking None = new EnumMasking("None");
         public static readonly EnumMasking WhiteBox = new EnumMasking("WhiteBox");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute BearerBars
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute BearerBars </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setBearerBars(EnumBearerBars enumVar)
      {
         setAttribute(AttributeName.BEARERBARS, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute BearerBars </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumBearerBars getBearerBars()
      {
         return EnumBearerBars.getEnum(getAttribute(AttributeName.BEARERBARS, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Height
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Height </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setHeight(double @value)
      {
         setAttribute(AttributeName.HEIGHT, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute Height </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getHeight()
      {
         return getRealAttribute(AttributeName.HEIGHT, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Magnification
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Magnification </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMagnification(double @value)
      {
         setAttribute(AttributeName.MAGNIFICATION, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute Magnification </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getMagnification()
      {
         return getRealAttribute(AttributeName.MAGNIFICATION, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Masking
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Masking </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setMasking(EnumMasking enumVar)
      {
         setAttribute(AttributeName.MASKING, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Masking </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumMasking getMasking()
      {
         return EnumMasking.getEnum(getAttribute(AttributeName.MASKING, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ModuleHeight
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ModuleHeight </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setModuleHeight(double @value)
      {
         setAttribute(AttributeName.MODULEHEIGHT, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute ModuleHeight </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getModuleHeight()
      {
         return getRealAttribute(AttributeName.MODULEHEIGHT, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ModuleWidth
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ModuleWidth </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setModuleWidth(double @value)
      {
         setAttribute(AttributeName.MODULEWIDTH, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute ModuleWidth </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getModuleWidth()
      {
         return getRealAttribute(AttributeName.MODULEWIDTH, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Ratio
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Ratio </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setRatio(double @value)
      {
         setAttribute(AttributeName.RATIO, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute Ratio </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getRatio()
      {
         return getRealAttribute(AttributeName.RATIO, null, 0.0);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateBarcodeCompParams
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFBarcodeCompParams the element </returns>
      ///     
      public virtual JDFBarcodeCompParams getCreateBarcodeCompParams(int iSkip)
      {
         return (JDFBarcodeCompParams)getCreateElement_KElement(ElementName.BARCODECOMPPARAMS, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element BarcodeCompParams </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFBarcodeCompParams the element </returns>
      ///     * default is getBarcodeCompParams(0)     
      public virtual JDFBarcodeCompParams getBarcodeCompParams(int iSkip)
      {
         return (JDFBarcodeCompParams)getElement(ElementName.BARCODECOMPPARAMS, null, iSkip);
      }

      ///    
      ///     <summary> * Get all BarcodeCompParams from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFBarcodeCompParams> </returns>
      ///     
      public virtual ICollection<JDFBarcodeCompParams> getAllBarcodeCompParams()
      {
         List<JDFBarcodeCompParams> v = new List<JDFBarcodeCompParams>();

         JDFBarcodeCompParams kElem = (JDFBarcodeCompParams)getFirstChildElement(ElementName.BARCODECOMPPARAMS, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFBarcodeCompParams)kElem.getNextSiblingElement(ElementName.BARCODECOMPPARAMS, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element BarcodeCompParams </summary>
      ///     
      public virtual JDFBarcodeCompParams appendBarcodeCompParams()
      {
         return (JDFBarcodeCompParams)appendElement(ElementName.BARCODECOMPPARAMS, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refBarcodeCompParams(JDFBarcodeCompParams refTarget)
      {
         refElement(refTarget);
      }
   }
}
