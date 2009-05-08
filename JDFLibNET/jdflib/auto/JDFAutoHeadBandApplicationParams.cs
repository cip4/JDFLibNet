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
   using JDFGlueLine = org.cip4.jdflib.resource.process.postpress.JDFGlueLine;

   public abstract class JDFAutoHeadBandApplicationParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[8];
      static JDFAutoHeadBandApplicationParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.BOTTOMBRAND, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.BOTTOMCOLOR, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.BOTTOMLENGTH, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.TOPBRAND, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.TOPCOLOR, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.TOPLENGTH, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.STRIPMATERIAL, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumStripMaterial.getEnum(0), null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.WIDTH, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.GLUELINE, 0x33333331);
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
      ///     <summary> * Constructor for JDFAutoHeadBandApplicationParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoHeadBandApplicationParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoHeadBandApplicationParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoHeadBandApplicationParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoHeadBandApplicationParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoHeadBandApplicationParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoHeadBandApplicationParams[  --> " + base.ToString() + " ]";
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
      //        Methods for Attribute BottomBrand
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BottomBrand </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBottomBrand(string @value)
      {
         setAttribute(AttributeName.BOTTOMBRAND, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute BottomBrand </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getBottomBrand()
      {
         return getAttribute(AttributeName.BOTTOMBRAND, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute BottomColor
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (13) set attribute BottomColor </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBottomColor(EnumNamedColor @value)
      {
         setAttribute(AttributeName.BOTTOMCOLOR, @value == null ? null : @value.getName(), null);
      }

      ///        
      ///          <summary> * (19) get EnumNamedColor attribute BottomColor </summary>
      ///          * <returns> EnumNamedColor the value of the attribute </returns>
      ///          
      public virtual EnumNamedColor getBottomColor()
      {
         string strAttrName = "";
         EnumNamedColor nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.BOTTOMCOLOR, null, JDFConstants.EMPTYSTRING);
         nPlaceHolder = EnumNamedColor.getEnum(strAttrName);
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute BottomLength
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BottomLength </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBottomLength(double @value)
      {
         setAttribute(AttributeName.BOTTOMLENGTH, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute BottomLength </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getBottomLength()
      {
         return getRealAttribute(AttributeName.BOTTOMLENGTH, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TopBrand
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TopBrand </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTopBrand(string @value)
      {
         setAttribute(AttributeName.TOPBRAND, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute TopBrand </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getTopBrand()
      {
         return getAttribute(AttributeName.TOPBRAND, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TopColor
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (13) set attribute TopColor </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTopColor(EnumNamedColor @value)
      {
         setAttribute(AttributeName.TOPCOLOR, @value == null ? null : @value.getName(), null);
      }

      ///        
      ///          <summary> * (19) get EnumNamedColor attribute TopColor </summary>
      ///          * <returns> EnumNamedColor the value of the attribute </returns>
      ///          
      public virtual EnumNamedColor getTopColor()
      {
         string strAttrName = "";
         EnumNamedColor nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.TOPCOLOR, null, JDFConstants.EMPTYSTRING);
         nPlaceHolder = EnumNamedColor.getEnum(strAttrName);
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TopLength
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TopLength </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTopLength(double @value)
      {
         setAttribute(AttributeName.TOPLENGTH, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute TopLength </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getTopLength()
      {
         return getRealAttribute(AttributeName.TOPLENGTH, null, 0.0);
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


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Width
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Width </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setWidth(double @value)
      {
         setAttribute(AttributeName.WIDTH, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute Width </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getWidth()
      {
         return getRealAttribute(AttributeName.WIDTH, null, 0.0);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateGlueLine
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFGlueLine the element </returns>
      ///     
      public virtual JDFGlueLine getCreateGlueLine(int iSkip)
      {
         return (JDFGlueLine)getCreateElement_KElement(ElementName.GLUELINE, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element GlueLine </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFGlueLine the element </returns>
      ///     * default is getGlueLine(0)     
      public virtual JDFGlueLine getGlueLine(int iSkip)
      {
         return (JDFGlueLine)getElement(ElementName.GLUELINE, null, iSkip);
      }

      ///    
      ///     <summary> * Get all GlueLine from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFGlueLine> </returns>
      ///     
      public virtual ICollection<JDFGlueLine> getAllGlueLine()
      {
         List<JDFGlueLine> v = new List<JDFGlueLine>();

         JDFGlueLine kElem = (JDFGlueLine)getFirstChildElement(ElementName.GLUELINE, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFGlueLine)kElem.getNextSiblingElement(ElementName.GLUELINE, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element GlueLine </summary>
      ///     
      public virtual JDFGlueLine appendGlueLine()
      {
         return (JDFGlueLine)appendElement(ElementName.GLUELINE, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refGlueLine(JDFGlueLine refTarget)
      {
         refElement(refTarget);
      }
   }
}
