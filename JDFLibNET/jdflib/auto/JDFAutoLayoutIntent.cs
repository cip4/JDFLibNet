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
   using JDFIntentResource = org.cip4.jdflib.resource.intent.JDFIntentResource;
   using JDFLayout = org.cip4.jdflib.resource.process.JDFLayout;
   using JDFIntegerSpan = org.cip4.jdflib.span.JDFIntegerSpan;
   using JDFShapeSpan = org.cip4.jdflib.span.JDFShapeSpan;
   using JDFSpanFinishedGrainDirection = org.cip4.jdflib.span.JDFSpanFinishedGrainDirection;
   using JDFSpanSizePolicy = org.cip4.jdflib.span.JDFSpanSizePolicy;
   using JDFXYPairSpan = org.cip4.jdflib.span.JDFXYPairSpan;

   public abstract class JDFAutoLayoutIntent : JDFIntentResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[5];
      static JDFAutoLayoutIntent()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.FOLIOCOUNT, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumFolioCount.getEnum(0), "Booklet");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.NUMBERUP, 0x33333333, AttributeInfo.EnumAttributeType.XYPair, null, "1 1");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.FINISHEDPAGEORIENTATION, 0x44444443, AttributeInfo.EnumAttributeType.enumeration, EnumFinishedPageOrientation.getEnum(0), null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.ROTATEPOLICY, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumRotatePolicy.getEnum(0), null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.SIDES, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumSides.getEnum(0), null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.DIMENSIONS, 0x66666661);
         elemInfoTable[1] = new ElemInfoTable(ElementName.FINISHEDDIMENSIONS, 0x66666661);
         elemInfoTable[2] = new ElemInfoTable(ElementName.FINISHEDGRAINDIRECTION, 0x66666611);
         elemInfoTable[3] = new ElemInfoTable(ElementName.PAGES, 0x66666661);
         elemInfoTable[4] = new ElemInfoTable(ElementName.PAGEVARIANCE, 0x66666661);
         elemInfoTable[5] = new ElemInfoTable(ElementName.LAYOUT, 0x66666661);
         elemInfoTable[6] = new ElemInfoTable(ElementName.SIZEPOLICY, 0x66666611);
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
      ///     <summary> * Constructor for JDFAutoLayoutIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoLayoutIntent(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoLayoutIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoLayoutIntent(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoLayoutIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoLayoutIntent(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoLayoutIntent[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for FolioCount </summary>
      ///        

      public class EnumFolioCount : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumFolioCount(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumFolioCount getEnum(string enumName)
         {
            return (EnumFolioCount)getEnum(typeof(EnumFolioCount), enumName);
         }

         public static EnumFolioCount getEnum(int enumValue)
         {
            return (EnumFolioCount)getEnum(typeof(EnumFolioCount), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumFolioCount));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumFolioCount));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumFolioCount));
         }

         public static readonly EnumFolioCount Booklet = new EnumFolioCount("Booklet");
         public static readonly EnumFolioCount Flat = new EnumFolioCount("Flat");
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
      ///        <summary> * Enumeration strings for RotatePolicy </summary>
      ///        

      public class EnumRotatePolicy : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumRotatePolicy(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumRotatePolicy getEnum(string enumName)
         {
            return (EnumRotatePolicy)getEnum(typeof(EnumRotatePolicy), enumName);
         }

         public static EnumRotatePolicy getEnum(int enumValue)
         {
            return (EnumRotatePolicy)getEnum(typeof(EnumRotatePolicy), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumRotatePolicy));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumRotatePolicy));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumRotatePolicy));
         }

         public static readonly EnumRotatePolicy NoRotate = new EnumRotatePolicy("NoRotate");
         public static readonly EnumRotatePolicy RotateOrthogonal = new EnumRotatePolicy("RotateOrthogonal");
         public static readonly EnumRotatePolicy RotateClockwise = new EnumRotatePolicy("RotateClockwise");
         public static readonly EnumRotatePolicy RotateCounterClockwise = new EnumRotatePolicy("RotateCounterClockwise");
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
         public static readonly EnumSides OneSidedBack = new EnumSides("OneSidedBack");
         public static readonly EnumSides TwoSidedHeadToHead = new EnumSides("TwoSidedHeadToHead");
         public static readonly EnumSides TwoSidedHeadToFoot = new EnumSides("TwoSidedHeadToFoot");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute FolioCount
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute FolioCount </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setFolioCount(EnumFolioCount enumVar)
      {
         setAttribute(AttributeName.FOLIOCOUNT, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute FolioCount </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumFolioCount getFolioCount()
      {
         return EnumFolioCount.getEnum(getAttribute(AttributeName.FOLIOCOUNT, null, "Booklet"));
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
         return EnumFinishedPageOrientation.getEnum(getAttribute(AttributeName.FINISHEDPAGEORIENTATION, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute RotatePolicy
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute RotatePolicy </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setRotatePolicy(EnumRotatePolicy enumVar)
      {
         setAttribute(AttributeName.ROTATEPOLICY, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute RotatePolicy </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumRotatePolicy getRotatePolicy()
      {
         return EnumRotatePolicy.getEnum(getAttribute(AttributeName.ROTATEPOLICY, null, null));
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
         return EnumSides.getEnum(getAttribute(AttributeName.SIDES, null, null));
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element Dimensions </summary>
      ///     * <returns> JDFXYPairSpan the element </returns>
      ///     
      public virtual JDFXYPairSpan getDimensions()
      {
         return (JDFXYPairSpan)getElement(ElementName.DIMENSIONS, null, 0);
      }

      ///     <summary> (25) getCreateDimensions
      ///     *  </summary>
      ///     * <returns> JDFXYPairSpan the element </returns>
      ///     
      public virtual JDFXYPairSpan getCreateDimensions()
      {
         return (JDFXYPairSpan)getCreateElement_KElement(ElementName.DIMENSIONS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Dimensions </summary>
      ///     
      public virtual JDFXYPairSpan appendDimensions()
      {
         return (JDFXYPairSpan)appendElementN(ElementName.DIMENSIONS, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element FinishedDimensions </summary>
      ///     * <returns> JDFShapeSpan the element </returns>
      ///     
      public virtual JDFShapeSpan getFinishedDimensions()
      {
         return (JDFShapeSpan)getElement(ElementName.FINISHEDDIMENSIONS, null, 0);
      }

      ///     <summary> (25) getCreateFinishedDimensions
      ///     *  </summary>
      ///     * <returns> JDFShapeSpan the element </returns>
      ///     
      public virtual JDFShapeSpan getCreateFinishedDimensions()
      {
         return (JDFShapeSpan)getCreateElement_KElement(ElementName.FINISHEDDIMENSIONS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element FinishedDimensions </summary>
      ///     
      public virtual JDFShapeSpan appendFinishedDimensions()
      {
         return (JDFShapeSpan)appendElementN(ElementName.FINISHEDDIMENSIONS, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element FinishedGrainDirection </summary>
      ///     * <returns> JDFSpanFinishedGrainDirection the element </returns>
      ///     
      public virtual JDFSpanFinishedGrainDirection getFinishedGrainDirection()
      {
         return (JDFSpanFinishedGrainDirection)getElement(ElementName.FINISHEDGRAINDIRECTION, null, 0);
      }

      ///     <summary> (25) getCreateFinishedGrainDirection
      ///     *  </summary>
      ///     * <returns> JDFSpanFinishedGrainDirection the element </returns>
      ///     
      public virtual JDFSpanFinishedGrainDirection getCreateFinishedGrainDirection()
      {
         return (JDFSpanFinishedGrainDirection)getCreateElement_KElement(ElementName.FINISHEDGRAINDIRECTION, null, 0);
      }

      ///    
      ///     <summary> * (29) append element FinishedGrainDirection </summary>
      ///     
      public virtual JDFSpanFinishedGrainDirection appendFinishedGrainDirection()
      {
         return (JDFSpanFinishedGrainDirection)appendElementN(ElementName.FINISHEDGRAINDIRECTION, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element Pages </summary>
      ///     * <returns> JDFIntegerSpan the element </returns>
      ///     
      public virtual JDFIntegerSpan getPages()
      {
         return (JDFIntegerSpan)getElement(ElementName.PAGES, null, 0);
      }

      ///     <summary> (25) getCreatePages
      ///     *  </summary>
      ///     * <returns> JDFIntegerSpan the element </returns>
      ///     
      public virtual JDFIntegerSpan getCreatePages()
      {
         return (JDFIntegerSpan)getCreateElement_KElement(ElementName.PAGES, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Pages </summary>
      ///     
      public virtual JDFIntegerSpan appendPages()
      {
         return (JDFIntegerSpan)appendElementN(ElementName.PAGES, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element PageVariance </summary>
      ///     * <returns> JDFIntegerSpan the element </returns>
      ///     
      public virtual JDFIntegerSpan getPageVariance()
      {
         return (JDFIntegerSpan)getElement(ElementName.PAGEVARIANCE, null, 0);
      }

      ///     <summary> (25) getCreatePageVariance
      ///     *  </summary>
      ///     * <returns> JDFIntegerSpan the element </returns>
      ///     
      public virtual JDFIntegerSpan getCreatePageVariance()
      {
         return (JDFIntegerSpan)getCreateElement_KElement(ElementName.PAGEVARIANCE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element PageVariance </summary>
      ///     
      public virtual JDFIntegerSpan appendPageVariance()
      {
         return (JDFIntegerSpan)appendElementN(ElementName.PAGEVARIANCE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element Layout </summary>
      ///     * <returns> JDFLayout the element </returns>
      ///     
      public virtual JDFLayout getLayout()
      {
         return (JDFLayout)getElement(ElementName.LAYOUT, null, 0);
      }

      ///     <summary> (25) getCreateLayout
      ///     *  </summary>
      ///     * <returns> JDFLayout the element </returns>
      ///     
      public virtual JDFLayout getCreateLayout()
      {
         return (JDFLayout)getCreateElement_KElement(ElementName.LAYOUT, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Layout </summary>
      ///     
      public virtual JDFLayout appendLayout()
      {
         return (JDFLayout)appendElementN(ElementName.LAYOUT, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refLayout(JDFLayout refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element SizePolicy </summary>
      ///     * <returns> JDFSpanSizePolicy the element </returns>
      ///     
      public virtual JDFSpanSizePolicy getSizePolicy()
      {
         return (JDFSpanSizePolicy)getElement(ElementName.SIZEPOLICY, null, 0);
      }

      ///     <summary> (25) getCreateSizePolicy
      ///     *  </summary>
      ///     * <returns> JDFSpanSizePolicy the element </returns>
      ///     
      public virtual JDFSpanSizePolicy getCreateSizePolicy()
      {
         return (JDFSpanSizePolicy)getCreateElement_KElement(ElementName.SIZEPOLICY, null, 0);
      }

      ///    
      ///     <summary> * (29) append element SizePolicy </summary>
      ///     
      public virtual JDFSpanSizePolicy appendSizePolicy()
      {
         return (JDFSpanSizePolicy)appendElementN(ElementName.SIZEPOLICY, 1, null);
      }
   }
}
