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
   using JDFNumberRangeList = org.cip4.jdflib.datatypes.JDFNumberRangeList;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFImageShift = org.cip4.jdflib.resource.JDFImageShift;

   public abstract class JDFAutoIDPLayout : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[7];
      static JDFAutoIDPLayout()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.BORDER, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, "0");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.FINISHEDPAGEORIENTATION, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumFinishedPageOrientation.getEnum(0), "Portrait");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.FORCEFRONTSIDE, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.NUMBERUP, 0x33333333, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.PRESENTATIONDIRECTION, 0x33333333, AttributeInfo.EnumAttributeType.Any, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.ROTATE, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, "0");
         atrInfoTable[6] = new AtrInfoTable(AttributeName.SIDES, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumSides.getEnum(0), "OneSided");
         elemInfoTable[0] = new ElemInfoTable(ElementName.IMAGESHIFT, 0x33333333);
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
      ///     <summary> * Constructor for JDFAutoIDPLayout </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoIDPLayout(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoIDPLayout </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoIDPLayout(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoIDPLayout </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoIDPLayout(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoIDPLayout[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for FinishedPageOrientation </summary>
      ///        

      public class EnumFinishedPageOrientation : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumFinishedPageOrientation(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumFinishedPageOrientation getEnum(string enumName)
         {
            return (EnumFinishedPageOrientation)getEnum(typeof(EnumFinishedPageOrientation), enumName);
         }

         public static EnumFinishedPageOrientation getEnum(int enumValue)
         {
            return (EnumFinishedPageOrientation)getEnum(typeof(EnumFinishedPageOrientation), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumFinishedPageOrientation));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumFinishedPageOrientation));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumFinishedPageOrientation));
         }

         public static readonly EnumFinishedPageOrientation Portrait = new EnumFinishedPageOrientation("Portrait");
         public static readonly EnumFinishedPageOrientation Landscape = new EnumFinishedPageOrientation("Landscape");
      }



      ///        
      ///        <summary> * Enumeration strings for Sides </summary>
      ///        

      public class EnumSides : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumSides(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumSides getEnum(string enumName)
         {
            return (EnumSides)getEnum(typeof(EnumSides), enumName);
         }

         public static EnumSides getEnum(int enumValue)
         {
            return (EnumSides)getEnum(typeof(EnumSides), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumSides));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumSides));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumSides));
         }

         public static readonly EnumSides OneSided = new EnumSides("OneSided");
         public static readonly EnumSides TwoSidedLongEdge = new EnumSides("TwoSidedLongEdge");
         public static readonly EnumSides TwoSidedShortEdge = new EnumSides("TwoSidedShortEdge");
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
      //        Methods for Attribute FinishedPageOrientation
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute FinishedPageOrientation </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setFinishedPageOrientation(EnumFinishedPageOrientation enumVar)
      {
         setAttribute(AttributeName.FINISHEDPAGEORIENTATION, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute FinishedPageOrientation </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumFinishedPageOrientation getFinishedPageOrientation()
      {
         return EnumFinishedPageOrientation.getEnum(getAttribute(AttributeName.FINISHEDPAGEORIENTATION, null, "Portrait"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ForceFrontSide
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ForceFrontSide </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setForceFrontSide(JDFNumberRangeList @value)
      {
         setAttribute(AttributeName.FORCEFRONTSIDE, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFNumberRangeList attribute ForceFrontSide </summary>
      ///          * <returns> JDFNumberRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFNumberRangeList </returns>
      ///          
      public virtual JDFNumberRangeList getForceFrontSide()
      {
         string strAttrName = "";
         JDFNumberRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.FORCEFRONTSIDE, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFNumberRangeList(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute NumberUp
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute NumberUp </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setNumberUp(JDFXYPair @value)
      {
         setAttribute(AttributeName.NUMBERUP, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute NumberUp </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getNumberUp()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.NUMBERUP, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute PresentationDirection
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PresentationDirection </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPresentationDirection(string @value)
      {
         setAttribute(AttributeName.PRESENTATIONDIRECTION, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute PresentationDirection </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getPresentationDirection()
      {
         return getAttribute(AttributeName.PRESENTATIONDIRECTION, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Rotate
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Rotate </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setRotate(double @value)
      {
         setAttribute(AttributeName.ROTATE, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute Rotate </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getRotate()
      {
         return getRealAttribute(AttributeName.ROTATE, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Sides
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Sides </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setSides(EnumSides enumVar)
      {
         setAttribute(AttributeName.SIDES, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Sides </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumSides getSides()
      {
         return EnumSides.getEnum(getAttribute(AttributeName.SIDES, null, "OneSided"));
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateImageShift
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFImageShift the element </returns>
      ///     
      public virtual JDFImageShift getCreateImageShift(int iSkip)
      {
         return (JDFImageShift)getCreateElement_KElement(ElementName.IMAGESHIFT, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element ImageShift </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFImageShift the element </returns>
      ///     * default is getImageShift(0)     
      public virtual JDFImageShift getImageShift(int iSkip)
      {
         return (JDFImageShift)getElement(ElementName.IMAGESHIFT, null, iSkip);
      }

      ///    
      ///     <summary> * Get all ImageShift from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFImageShift> </returns>
      ///     
      public virtual ICollection<JDFImageShift> getAllImageShift()
      {
         List<JDFImageShift> v = new List<JDFImageShift>();

         JDFImageShift kElem = (JDFImageShift)getFirstChildElement(ElementName.IMAGESHIFT, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFImageShift)kElem.getNextSiblingElement(ElementName.IMAGESHIFT, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element ImageShift </summary>
      ///     
      public virtual JDFImageShift appendImageShift()
      {
         return (JDFImageShift)appendElement(ElementName.IMAGESHIFT, null);
      }
   }
}
