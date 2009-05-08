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
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFNumberList = org.cip4.jdflib.datatypes.JDFNumberList;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;

   public abstract class JDFAutoStitchingParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[11];
      static JDFAutoStitchingParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ANGLE, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.NUMBEROFSTITCHES, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.OFFSET, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.REFERENCEEDGE, 0x44444431, AttributeInfo.EnumAttributeType.enumeration, EnumReferenceEdge.getEnum(0), null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.STAPLESHAPE, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumStapleShape.getEnum(0), null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.STITCHFROMFRONT, 0x44444433, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.STITCHPOSITIONS, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.STITCHTYPE, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumStitchType.getEnum(0), null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.STITCHWIDTH, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.WIREGAUGE, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[10] = new AtrInfoTable(AttributeName.WIREBRAND, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoStitchingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoStitchingParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoStitchingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoStitchingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoStitchingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoStitchingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoStitchingParams[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for ReferenceEdge </summary>
      ///        

      public class EnumReferenceEdge : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumReferenceEdge(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumReferenceEdge getEnum(string enumName)
         {
            return (EnumReferenceEdge)getEnum(typeof(EnumReferenceEdge), enumName);
         }

         public static EnumReferenceEdge getEnum(int enumValue)
         {
            return (EnumReferenceEdge)getEnum(typeof(EnumReferenceEdge), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumReferenceEdge));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumReferenceEdge));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumReferenceEdge));
         }

         public static readonly EnumReferenceEdge Top = new EnumReferenceEdge("Top");
         public static readonly EnumReferenceEdge Left = new EnumReferenceEdge("Left");
         public static readonly EnumReferenceEdge Right = new EnumReferenceEdge("Right");
         public static readonly EnumReferenceEdge Bottom = new EnumReferenceEdge("Bottom");
      }



      ///        
      ///        <summary> * Enumeration strings for StapleShape </summary>
      ///        

      public class EnumStapleShape : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumStapleShape(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumStapleShape getEnum(string enumName)
         {
            return (EnumStapleShape)getEnum(typeof(EnumStapleShape), enumName);
         }

         public static EnumStapleShape getEnum(int enumValue)
         {
            return (EnumStapleShape)getEnum(typeof(EnumStapleShape), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumStapleShape));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumStapleShape));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumStapleShape));
         }

         public static readonly EnumStapleShape Crown = new EnumStapleShape("Crown");
         public static readonly EnumStapleShape Overlap = new EnumStapleShape("Overlap");
         public static readonly EnumStapleShape Butted = new EnumStapleShape("Butted");
         public static readonly EnumStapleShape ClinchOut = new EnumStapleShape("ClinchOut");
         public static readonly EnumStapleShape Eyelet = new EnumStapleShape("Eyelet");
      }



      ///        
      ///        <summary> * Enumeration strings for StitchType </summary>
      ///        

      public class EnumStitchType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumStitchType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumStitchType getEnum(string enumName)
         {
            return (EnumStitchType)getEnum(typeof(EnumStitchType), enumName);
         }

         public static EnumStitchType getEnum(int enumValue)
         {
            return (EnumStitchType)getEnum(typeof(EnumStitchType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumStitchType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumStitchType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumStitchType));
         }

         public static readonly EnumStitchType Saddle = new EnumStitchType("Saddle");
         public static readonly EnumStitchType Side = new EnumStitchType("Side");
         public static readonly EnumStitchType Corner = new EnumStitchType("Corner");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute Angle
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Angle </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAngle(double @value)
      {
         setAttribute(AttributeName.ANGLE, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute Angle </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getAngle()
      {
         return getRealAttribute(AttributeName.ANGLE, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute NumberOfStitches
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute NumberOfStitches </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setNumberOfStitches(int @value)
      {
         setAttribute(AttributeName.NUMBEROFSTITCHES, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute NumberOfStitches </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getNumberOfStitches()
      {
         return getIntAttribute(AttributeName.NUMBEROFSTITCHES, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Offset
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Offset </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setOffset(double @value)
      {
         setAttribute(AttributeName.OFFSET, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute Offset </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getOffset()
      {
         return getRealAttribute(AttributeName.OFFSET, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ReferenceEdge
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute ReferenceEdge </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setReferenceEdge(EnumReferenceEdge enumVar)
      {
         setAttribute(AttributeName.REFERENCEEDGE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute ReferenceEdge </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumReferenceEdge getReferenceEdge()
      {
         return EnumReferenceEdge.getEnum(getAttribute(AttributeName.REFERENCEEDGE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute StapleShape
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute StapleShape </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setStapleShape(EnumStapleShape enumVar)
      {
         setAttribute(AttributeName.STAPLESHAPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute StapleShape </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumStapleShape getStapleShape()
      {
         return EnumStapleShape.getEnum(getAttribute(AttributeName.STAPLESHAPE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute StitchFromFront
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute StitchFromFront </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setStitchFromFront(bool @value)
      {
         setAttribute(AttributeName.STITCHFROMFRONT, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute StitchFromFront </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getStitchFromFront()
      {
         return getBoolAttribute(AttributeName.STITCHFROMFRONT, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute StitchPositions
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute StitchPositions </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setStitchPositions(JDFNumberList @value)
      {
         setAttribute(AttributeName.STITCHPOSITIONS, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFNumberList attribute StitchPositions </summary>
      ///          * <returns> JDFNumberList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFNumberList </returns>
      ///          
      public virtual JDFNumberList getStitchPositions()
      {
         string strAttrName = "";
         JDFNumberList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.STITCHPOSITIONS, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFNumberList(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute StitchType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute StitchType </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setStitchType(EnumStitchType enumVar)
      {
         setAttribute(AttributeName.STITCHTYPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute StitchType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumStitchType getStitchType()
      {
         return EnumStitchType.getEnum(getAttribute(AttributeName.STITCHTYPE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute StitchWidth
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute StitchWidth </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setStitchWidth(double @value)
      {
         setAttribute(AttributeName.STITCHWIDTH, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute StitchWidth </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getStitchWidth()
      {
         return getRealAttribute(AttributeName.STITCHWIDTH, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute WireGauge
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute WireGauge </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setWireGauge(double @value)
      {
         setAttribute(AttributeName.WIREGAUGE, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute WireGauge </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getWireGauge()
      {
         return getRealAttribute(AttributeName.WIREGAUGE, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute WireBrand
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute WireBrand </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setWireBrand(string @value)
      {
         setAttribute(AttributeName.WIREBRAND, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute WireBrand </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getWireBrand()
      {
      return getAttribute(AttributeName.WIREBRAND, null, JDFConstants.EMPTYSTRING);
      }  }
}
