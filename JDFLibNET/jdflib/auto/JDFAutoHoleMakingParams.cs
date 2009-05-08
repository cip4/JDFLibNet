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
   using JDFIntegerList = org.cip4.jdflib.datatypes.JDFIntegerList;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFHoleLine = org.cip4.jdflib.resource.JDFHoleLine;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;
   using JDFRegisterMark = org.cip4.jdflib.resource.process.JDFRegisterMark;
   using JDFHole = org.cip4.jdflib.resource.process.postpress.JDFHole;

   public abstract class JDFAutoHoleMakingParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[7];
      static JDFAutoHoleMakingParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.CENTERREFERENCE, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumCenterReference.getEnum(0), "TrailingEdge");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.HOLETYPE, 0x22222221, AttributeInfo.EnumAttributeType.enumerations, JDFMedia.EnumHoleType.getEnum(0), null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.CENTER, 0x33333333, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.EXTENT, 0x33333333, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.HOLECOUNT, 0x33333311, AttributeInfo.EnumAttributeType.IntegerList, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.HOLEREFERENCEEDGE, 0x44444431, AttributeInfo.EnumAttributeType.enumeration, EnumHoleReferenceEdge.getEnum(0), null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.SHAPE, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumShape.getEnum(0), null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.HOLE, 0x33333333);
         elemInfoTable[1] = new ElemInfoTable(ElementName.HOLELINE, 0x33333331);
         elemInfoTable[2] = new ElemInfoTable(ElementName.REGISTERMARK, 0x66666661);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[3];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoHoleMakingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoHoleMakingParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoHoleMakingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoHoleMakingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoHoleMakingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoHoleMakingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoHoleMakingParams[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for CenterReference </summary>
      ///        

      public class EnumCenterReference : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumCenterReference(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumCenterReference getEnum(string enumName)
         {
            return (EnumCenterReference)getEnum(typeof(EnumCenterReference), enumName);
         }

         public static EnumCenterReference getEnum(int enumValue)
         {
            return (EnumCenterReference)getEnum(typeof(EnumCenterReference), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumCenterReference));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumCenterReference));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumCenterReference));
         }

         public static readonly EnumCenterReference TrailingEdge = new EnumCenterReference("TrailingEdge");
         public static readonly EnumCenterReference RegistrationMark = new EnumCenterReference("RegistrationMark");
      }



      ///        
      ///        <summary> * Enumeration strings for HoleReferenceEdge </summary>
      ///        

      public class EnumHoleReferenceEdge : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumHoleReferenceEdge(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumHoleReferenceEdge getEnum(string enumName)
         {
            return (EnumHoleReferenceEdge)getEnum(typeof(EnumHoleReferenceEdge), enumName);
         }

         public static EnumHoleReferenceEdge getEnum(int enumValue)
         {
            return (EnumHoleReferenceEdge)getEnum(typeof(EnumHoleReferenceEdge), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumHoleReferenceEdge));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumHoleReferenceEdge));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumHoleReferenceEdge));
         }

         public static readonly EnumHoleReferenceEdge Left = new EnumHoleReferenceEdge("Left");
         public static readonly EnumHoleReferenceEdge Right = new EnumHoleReferenceEdge("Right");
         public static readonly EnumHoleReferenceEdge Top = new EnumHoleReferenceEdge("Top");
         public static readonly EnumHoleReferenceEdge Bottom = new EnumHoleReferenceEdge("Bottom");
         public static readonly EnumHoleReferenceEdge Pattern = new EnumHoleReferenceEdge("Pattern");
      }



      ///        
      ///        <summary> * Enumeration strings for Shape </summary>
      ///        

      public class EnumShape : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumShape(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumShape getEnum(string enumName)
         {
            return (EnumShape)getEnum(typeof(EnumShape), enumName);
         }

         public static EnumShape getEnum(int enumValue)
         {
            return (EnumShape)getEnum(typeof(EnumShape), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumShape));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumShape));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumShape));
         }

         public static readonly EnumShape Eliptical = new EnumShape("Eliptical");
         public static readonly EnumShape Round = new EnumShape("Round");
         public static readonly EnumShape Rectangular = new EnumShape("Rectangular");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute CenterReference
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute CenterReference </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setCenterReference(EnumCenterReference enumVar)
      {
         setAttribute(AttributeName.CENTERREFERENCE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute CenterReference </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumCenterReference getCenterReference()
      {
         return EnumCenterReference.getEnum(getAttribute(AttributeName.CENTERREFERENCE, null, "TrailingEdge"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute HoleType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5.2) set attribute HoleType </summary>
      ///          * <param name="v"> vector of the enumeration values </param>
      ///          
      public virtual void setHoleType(List<ValuedEnum> v)
      {
         setEnumerationsAttribute(AttributeName.HOLETYPE, v, null);
      }

      ///        
      ///          <summary> * (9.2) get HoleType attribute HoleType </summary>
      ///          * <returns> Vector of the enumerations </returns>
      ///          
      public virtual List<ValuedEnum> getHoleType()
      {
         return getEnumerationsAttribute(AttributeName.HOLETYPE, null, JDFMedia.EnumHoleType.getEnum(0), false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Center
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Center </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCenter(JDFXYPair @value)
      {
         setAttribute(AttributeName.CENTER, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute Center </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getCenter()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.CENTER, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute Extent
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Extent </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setExtent(JDFXYPair @value)
      {
         setAttribute(AttributeName.EXTENT, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute Extent </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getExtent()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.EXTENT, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute HoleCount
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute HoleCount </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setHoleCount(JDFIntegerList @value)
      {
         setAttribute(AttributeName.HOLECOUNT, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerList attribute HoleCount </summary>
      ///          * <returns> JDFIntegerList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerList </returns>
      ///          
      public virtual JDFIntegerList getHoleCount()
      {
         string strAttrName = "";
         JDFIntegerList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.HOLECOUNT, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute HoleReferenceEdge
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute HoleReferenceEdge </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setHoleReferenceEdge(EnumHoleReferenceEdge enumVar)
      {
         setAttribute(AttributeName.HOLEREFERENCEEDGE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute HoleReferenceEdge </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumHoleReferenceEdge getHoleReferenceEdge()
      {
         return EnumHoleReferenceEdge.getEnum(getAttribute(AttributeName.HOLEREFERENCEEDGE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Shape
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Shape </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setShape(EnumShape enumVar)
      {
         setAttribute(AttributeName.SHAPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Shape </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumShape getShape()
      {
         return EnumShape.getEnum(getAttribute(AttributeName.SHAPE, null, null));
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateHole
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFHole the element </returns>
      ///     
      public virtual JDFHole getCreateHole(int iSkip)
      {
         return (JDFHole)getCreateElement_KElement(ElementName.HOLE, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Hole </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFHole the element </returns>
      ///     * default is getHole(0)     
      public virtual JDFHole getHole(int iSkip)
      {
         return (JDFHole)getElement(ElementName.HOLE, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Hole from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFHole> </returns>
      ///     
      public virtual ICollection<JDFHole> getAllHole()
      {
         List<JDFHole> v = new List<JDFHole>();

         JDFHole kElem = (JDFHole)getFirstChildElement(ElementName.HOLE, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFHole)kElem.getNextSiblingElement(ElementName.HOLE, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Hole </summary>
      ///     
      public virtual JDFHole appendHole()
      {
         return (JDFHole)appendElement(ElementName.HOLE, null);
      }

      ///     <summary> (26) getCreateHoleLine
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFHoleLine the element </returns>
      ///     
      public virtual JDFHoleLine getCreateHoleLine(int iSkip)
      {
         return (JDFHoleLine)getCreateElement_KElement(ElementName.HOLELINE, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element HoleLine </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFHoleLine the element </returns>
      ///     * default is getHoleLine(0)     
      public virtual JDFHoleLine getHoleLine(int iSkip)
      {
         return (JDFHoleLine)getElement(ElementName.HOLELINE, null, iSkip);
      }

      ///    
      ///     <summary> * Get all HoleLine from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFHoleLine> </returns>
      ///     
      public virtual ICollection<JDFHoleLine> getAllHoleLine()
      {
         List<JDFHoleLine> v = new List<JDFHoleLine>();

         JDFHoleLine kElem = (JDFHoleLine)getFirstChildElement(ElementName.HOLELINE, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFHoleLine)kElem.getNextSiblingElement(ElementName.HOLELINE, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element HoleLine </summary>
      ///     
      public virtual JDFHoleLine appendHoleLine()
      {
         return (JDFHoleLine)appendElement(ElementName.HOLELINE, null);
      }

      ///    
      ///     <summary> * (24) const get element RegisterMark </summary>
      ///     * <returns> JDFRegisterMark the element </returns>
      ///     
      public virtual JDFRegisterMark getRegisterMark()
      {
         return (JDFRegisterMark)getElement(ElementName.REGISTERMARK, null, 0);
      }

      ///     <summary> (25) getCreateRegisterMark
      ///     *  </summary>
      ///     * <returns> JDFRegisterMark the element </returns>
      ///     
      public virtual JDFRegisterMark getCreateRegisterMark()
      {
         return (JDFRegisterMark)getCreateElement_KElement(ElementName.REGISTERMARK, null, 0);
      }

      ///    
      ///     <summary> * (29) append element RegisterMark </summary>
      ///     
      public virtual JDFRegisterMark appendRegisterMark()
      {
         return (JDFRegisterMark)appendElementN(ElementName.REGISTERMARK, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refRegisterMark(JDFRegisterMark refTarget)
      {
         refElement(refTarget);
      }
   }
}
