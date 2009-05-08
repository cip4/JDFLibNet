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
   using JDFGlueApplication = org.cip4.jdflib.resource.process.postpress.JDFGlueApplication;

   public abstract class JDFAutoSpineTapingParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[6];
      static JDFAutoSpineTapingParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.TOPEXCESS, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, "0.0");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.HORIZONTALEXCESS, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.STRIPBRAND, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.STRIPCOLOR, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.STRIPLENGTH, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.STRIPMATERIAL, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumStripMaterial.getEnum(0), null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.GLUEAPPLICATION, 0x33333331);
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
      ///     <summary> * Constructor for JDFAutoSpineTapingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoSpineTapingParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoSpineTapingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoSpineTapingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoSpineTapingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoSpineTapingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoSpineTapingParams[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for StripMaterial </summary>
      ///        

      public class EnumStripMaterial : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumStripMaterial(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumStripMaterial getEnum(string enumName)
         {
            return (EnumStripMaterial)getEnum(typeof(EnumStripMaterial), enumName);
         }

         public static EnumStripMaterial getEnum(int enumValue)
         {
            return (EnumStripMaterial)getEnum(typeof(EnumStripMaterial), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumStripMaterial));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumStripMaterial));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumStripMaterial));
         }

         public static readonly EnumStripMaterial Calico = new EnumStripMaterial("Calico");
         public static readonly EnumStripMaterial Cardboard = new EnumStripMaterial("Cardboard");
         public static readonly EnumStripMaterial CrepePaper = new EnumStripMaterial("CrepePaper");
         public static readonly EnumStripMaterial Gauze = new EnumStripMaterial("Gauze");
         public static readonly EnumStripMaterial Paper = new EnumStripMaterial("Paper");
         public static readonly EnumStripMaterial PaperlinedMules = new EnumStripMaterial("PaperlinedMules");
         public static readonly EnumStripMaterial Tape = new EnumStripMaterial("Tape");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute TopExcess
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TopExcess </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTopExcess(double @value)
      {
         setAttribute(AttributeName.TOPEXCESS, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute TopExcess </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getTopExcess()
      {
         return getRealAttribute(AttributeName.TOPEXCESS, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute HorizontalExcess
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute HorizontalExcess </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setHorizontalExcess(double @value)
      {
         setAttribute(AttributeName.HORIZONTALEXCESS, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute HorizontalExcess </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getHorizontalExcess()
      {
         return getRealAttribute(AttributeName.HORIZONTALEXCESS, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute StripBrand
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute StripBrand </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setStripBrand(string @value)
      {
         setAttribute(AttributeName.STRIPBRAND, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute StripBrand </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getStripBrand()
      {
         return getAttribute(AttributeName.STRIPBRAND, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute StripColor
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (13) set attribute StripColor </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setStripColor(EnumNamedColor @value)
      {
         setAttribute(AttributeName.STRIPCOLOR, @value == null ? null : @value.getName(), null);
      }

      ///        
      ///          <summary> * (19) get EnumNamedColor attribute StripColor </summary>
      ///          * <returns> EnumNamedColor the value of the attribute </returns>
      ///          
      public virtual EnumNamedColor getStripColor()
      {
         string strAttrName = "";
         EnumNamedColor nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.STRIPCOLOR, null, JDFConstants.EMPTYSTRING);
         nPlaceHolder = EnumNamedColor.getEnum(strAttrName);
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute StripLength
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute StripLength </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setStripLength(double @value)
      {
         setAttribute(AttributeName.STRIPLENGTH, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute StripLength </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getStripLength()
      {
         return getRealAttribute(AttributeName.STRIPLENGTH, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute StripMaterial
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute StripMaterial </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setStripMaterial(EnumStripMaterial enumVar)
      {
         setAttribute(AttributeName.STRIPMATERIAL, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute StripMaterial </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumStripMaterial getStripMaterial()
      {
         return EnumStripMaterial.getEnum(getAttribute(AttributeName.STRIPMATERIAL, null, null));
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateGlueApplication
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFGlueApplication the element </returns>
      ///     
      public virtual JDFGlueApplication getCreateGlueApplication(int iSkip)
      {
         return (JDFGlueApplication)getCreateElement_KElement(ElementName.GLUEAPPLICATION, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element GlueApplication </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFGlueApplication the element </returns>
      ///     * default is getGlueApplication(0)     
      public virtual JDFGlueApplication getGlueApplication(int iSkip)
      {
         return (JDFGlueApplication)getElement(ElementName.GLUEAPPLICATION, null, iSkip);
      }

      ///    
      ///     <summary> * Get all GlueApplication from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFGlueApplication> </returns>
      ///     
      public virtual ICollection<JDFGlueApplication> getAllGlueApplication()
      {
         List<JDFGlueApplication> v = new List<JDFGlueApplication>();

         JDFGlueApplication kElem = (JDFGlueApplication)getFirstChildElement(ElementName.GLUEAPPLICATION, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFGlueApplication)kElem.getNextSiblingElement(ElementName.GLUEAPPLICATION, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element GlueApplication </summary>
      ///     
      public virtual JDFGlueApplication appendGlueApplication()
      {
         return (JDFGlueApplication)appendElement(ElementName.GLUEAPPLICATION, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refGlueApplication(JDFGlueApplication refTarget)
      {
         refElement(refTarget);
      }
   }
}
