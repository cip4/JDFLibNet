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



   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFNumberList = org.cip4.jdflib.datatypes.JDFNumberList;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFColorMeasurementConditions = org.cip4.jdflib.resource.JDFColorMeasurementConditions;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;

   public abstract class JDFAutoDensityMeasuringField : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[13];
      static JDFAutoDensityMeasuringField()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.CENTER, 0x22222222, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.DENSITY, 0x22222222, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.DIAMETER, 0x22222222, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.DOTGAIN, 0x22222222, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.PERCENTAGE, 0x22222222, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.SCREEN, 0x22222222, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.SEPARATION, 0x22222222, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.TOLERANCECYAN, 0x22222222, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.TOLERANCEMAGENTA, 0x22222222, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.TOLERANCEYELLOW, 0x22222222, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[10] = new AtrInfoTable(AttributeName.TOLERANCEBLACK, 0x22222222, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[11] = new AtrInfoTable(AttributeName.TOLERANCEDOTGAIN, 0x22222222, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[12] = new AtrInfoTable(AttributeName.SETUP, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
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
      ///     <summary> * Constructor for JDFAutoDensityMeasuringField </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoDensityMeasuringField(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoDensityMeasuringField </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoDensityMeasuringField(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoDensityMeasuringField </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoDensityMeasuringField(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoDensityMeasuringField[  --> " + base.ToString() + " ]";
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
      //        Methods for Attribute Density
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Density </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDensity(JDFNumberList @value)
      {
         setAttribute(AttributeName.DENSITY, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFNumberList attribute Density </summary>
      ///          * <returns> JDFNumberList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFNumberList </returns>
      ///          
      public virtual JDFNumberList getDensity()
      {
         string strAttrName = "";
         JDFNumberList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.DENSITY, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute DotGain
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DotGain </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDotGain(double @value)
      {
         setAttribute(AttributeName.DOTGAIN, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute DotGain </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getDotGain()
      {
         return getRealAttribute(AttributeName.DOTGAIN, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Percentage
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Percentage </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPercentage(double @value)
      {
         setAttribute(AttributeName.PERCENTAGE, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute Percentage </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getPercentage()
      {
         return getRealAttribute(AttributeName.PERCENTAGE, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Screen
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Screen </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setScreen(string @value)
      {
         setAttribute(AttributeName.SCREEN, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Screen </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getScreen()
      {
         return getAttribute(AttributeName.SCREEN, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Separation
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Separation </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public override void setSeparation(string @value)
      {
         setAttribute(AttributeName.SEPARATION, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Separation </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public override string getSeparation()
      {
         return getAttribute(AttributeName.SEPARATION, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ToleranceCyan
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ToleranceCyan </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setToleranceCyan(JDFXYPair @value)
      {
         setAttribute(AttributeName.TOLERANCECYAN, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute ToleranceCyan </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getToleranceCyan()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.TOLERANCECYAN, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute ToleranceMagenta
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ToleranceMagenta </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setToleranceMagenta(JDFXYPair @value)
      {
         setAttribute(AttributeName.TOLERANCEMAGENTA, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute ToleranceMagenta </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getToleranceMagenta()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.TOLERANCEMAGENTA, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute ToleranceYellow
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ToleranceYellow </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setToleranceYellow(JDFXYPair @value)
      {
         setAttribute(AttributeName.TOLERANCEYELLOW, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute ToleranceYellow </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getToleranceYellow()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.TOLERANCEYELLOW, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute ToleranceBlack
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ToleranceBlack </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setToleranceBlack(JDFXYPair @value)
      {
         setAttribute(AttributeName.TOLERANCEBLACK, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute ToleranceBlack </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getToleranceBlack()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.TOLERANCEBLACK, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute ToleranceDotGain
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ToleranceDotGain </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setToleranceDotGain(JDFXYPair @value)
      {
         setAttribute(AttributeName.TOLERANCEDOTGAIN, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute ToleranceDotGain </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getToleranceDotGain()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.TOLERANCEDOTGAIN, null, JDFConstants.EMPTYSTRING);
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
