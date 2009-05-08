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
   using JDFLabColor = org.cip4.jdflib.datatypes.JDFLabColor;
   using JDFNumberList = org.cip4.jdflib.datatypes.JDFNumberList;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFColorMeasurementConditions = org.cip4.jdflib.resource.JDFColorMeasurementConditions;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;

   public abstract class JDFAutoCIELABMeasuringField : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[11];
      static JDFAutoCIELABMeasuringField()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.CENTER, 0x22222222, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.CIELAB, 0x22222222, AttributeInfo.EnumAttributeType.LabColor, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.DENSITYSTANDARD, 0x44444443, AttributeInfo.EnumAttributeType.enumeration, EnumDensityStandard.getEnum(0), null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.DIAMETER, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.LIGHT, 0x44444443, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.OBSERVER, 0x44444443, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.PERCENTAGES, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.SCREENRULING, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.SCREENSHAPE, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.SETUP, 0x44444443, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[10] = new AtrInfoTable(AttributeName.TOLERANCE, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.COLORMEASUREMENTCONDITIONS, 0x66666661);
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
      ///     <summary> * Constructor for JDFAutoCIELABMeasuringField </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoCIELABMeasuringField(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoCIELABMeasuringField </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoCIELABMeasuringField(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoCIELABMeasuringField </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoCIELABMeasuringField(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoCIELABMeasuringField[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for DensityStandard </summary>
      ///        

      public class EnumDensityStandard : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumDensityStandard(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumDensityStandard getEnum(string enumName)
         {
            return (EnumDensityStandard)getEnum(typeof(EnumDensityStandard), enumName);
         }

         public static EnumDensityStandard getEnum(int enumValue)
         {
            return (EnumDensityStandard)getEnum(typeof(EnumDensityStandard), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumDensityStandard));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumDensityStandard));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumDensityStandard));
         }

         public static readonly EnumDensityStandard ANSIA = new EnumDensityStandard("ANSIA");
         public static readonly EnumDensityStandard ANSIE = new EnumDensityStandard("ANSIE");
         public static readonly EnumDensityStandard ANSII = new EnumDensityStandard("ANSII");
         public static readonly EnumDensityStandard ANSIT = new EnumDensityStandard("ANSIT");
         public static readonly EnumDensityStandard DIN16536 = new EnumDensityStandard("DIN16536");
         public static readonly EnumDensityStandard DIN16536NB = new EnumDensityStandard("DIN16536NB");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

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
      //        Methods for Attribute CIELab
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CIELab </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCIELab(JDFLabColor @value)
      {
         setAttribute(AttributeName.CIELAB, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFLabColor attribute CIELab </summary>
      ///          * <returns> JDFLabColor the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFLabColor </returns>
      ///          
      public virtual JDFLabColor getCIELab()
      {
         string strAttrName = "";
         JDFLabColor nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.CIELAB, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFLabColor(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute DensityStandard
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute DensityStandard </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setDensityStandard(EnumDensityStandard enumVar)
      {
         setAttribute(AttributeName.DENSITYSTANDARD, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute DensityStandard </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumDensityStandard getDensityStandard()
      {
         return EnumDensityStandard.getEnum(getAttribute(AttributeName.DENSITYSTANDARD, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Diameter
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Diameter </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDiameter(double @value)
      {
         setAttribute(AttributeName.DIAMETER, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute Diameter </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getDiameter()
      {
         return getRealAttribute(AttributeName.DIAMETER, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Light
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Light </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setLight(string @value)
      {
         setAttribute(AttributeName.LIGHT, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Light </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getLight()
      {
         return getAttribute(AttributeName.LIGHT, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Observer
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Observer </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setObserver(int @value)
      {
         setAttribute(AttributeName.OBSERVER, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute Observer </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getObserver()
      {
         return getIntAttribute(AttributeName.OBSERVER, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Percentages
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Percentages </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPercentages(JDFNumberList @value)
      {
         setAttribute(AttributeName.PERCENTAGES, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFNumberList attribute Percentages </summary>
      ///          * <returns> JDFNumberList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFNumberList </returns>
      ///          
      public virtual JDFNumberList getPercentages()
      {
         string strAttrName = "";
         JDFNumberList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.PERCENTAGES, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute ScreenRuling
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ScreenRuling </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setScreenRuling(JDFNumberList @value)
      {
         setAttribute(AttributeName.SCREENRULING, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFNumberList attribute ScreenRuling </summary>
      ///          * <returns> JDFNumberList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFNumberList </returns>
      ///          
      public virtual JDFNumberList getScreenRuling()
      {
         string strAttrName = "";
         JDFNumberList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.SCREENRULING, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute ScreenShape
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ScreenShape </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setScreenShape(string @value)
      {
         setAttribute(AttributeName.SCREENSHAPE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ScreenShape </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getScreenShape()
      {
         return getAttribute(AttributeName.SCREENSHAPE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Setup
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Setup </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSetup(string @value)
      {
         setAttribute(AttributeName.SETUP, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Setup </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getSetup()
      {
         return getAttribute(AttributeName.SETUP, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Tolerance
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Tolerance </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTolerance(double @value)
      {
         setAttribute(AttributeName.TOLERANCE, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute Tolerance </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getTolerance()
      {
         return getRealAttribute(AttributeName.TOLERANCE, null, 0.0);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element ColorMeasurementConditions </summary>
      ///     * <returns> JDFColorMeasurementConditions the element </returns>
      ///     
      public virtual JDFColorMeasurementConditions getColorMeasurementConditions()
      {
         return (JDFColorMeasurementConditions)getElement(ElementName.COLORMEASUREMENTCONDITIONS, null, 0);
      }

      ///     <summary> (25) getCreateColorMeasurementConditions
      ///     *  </summary>
      ///     * <returns> JDFColorMeasurementConditions the element </returns>
      ///     
      public virtual JDFColorMeasurementConditions getCreateColorMeasurementConditions()
      {
         return (JDFColorMeasurementConditions)getCreateElement_KElement(ElementName.COLORMEASUREMENTCONDITIONS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ColorMeasurementConditions </summary>
      ///     
      public virtual JDFColorMeasurementConditions appendColorMeasurementConditions()
      {
         return (JDFColorMeasurementConditions)appendElementN(ElementName.COLORMEASUREMENTCONDITIONS, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refColorMeasurementConditions(JDFColorMeasurementConditions refTarget)
      {
         refElement(refTarget);
      }
   }
}
