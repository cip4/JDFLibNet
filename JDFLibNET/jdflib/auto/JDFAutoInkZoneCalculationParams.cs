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
   using JDFRectangle = org.cip4.jdflib.datatypes.JDFRectangle;
   using JDFDevice = org.cip4.jdflib.resource.JDFDevice;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;

   public abstract class JDFAutoInkZoneCalculationParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[6];
      static JDFAutoInkZoneCalculationParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.FOUNTAINPOSITIONS, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.PRINTABLEAREA, 0x33333333, AttributeInfo.EnumAttributeType.rectangle, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.ZONEWIDTH, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.ZONES, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.ZONESY, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.ZONEHEIGHT, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.DEVICE, 0x66666611);
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
      ///     <summary> * Constructor for JDFAutoInkZoneCalculationParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoInkZoneCalculationParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoInkZoneCalculationParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoInkZoneCalculationParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoInkZoneCalculationParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoInkZoneCalculationParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoInkZoneCalculationParams[  --> " + base.ToString() + " ]";
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
      //        Methods for Attribute FountainPositions
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute FountainPositions </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFountainPositions(JDFNumberList @value)
      {
         setAttribute(AttributeName.FOUNTAINPOSITIONS, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFNumberList attribute FountainPositions </summary>
      ///          * <returns> JDFNumberList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFNumberList </returns>
      ///          
      public virtual JDFNumberList getFountainPositions()
      {
         string strAttrName = "";
         JDFNumberList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.FOUNTAINPOSITIONS, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute PrintableArea
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PrintableArea </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPrintableArea(JDFRectangle @value)
      {
         setAttribute(AttributeName.PRINTABLEAREA, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFRectangle attribute PrintableArea </summary>
      ///          * <returns> JDFRectangle the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFRectangle </returns>
      ///          
      public virtual JDFRectangle getPrintableArea()
      {
         string strAttrName = "";
         JDFRectangle nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.PRINTABLEAREA, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFRectangle(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ZoneWidth
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ZoneWidth </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setZoneWidth(double @value)
      {
         setAttribute(AttributeName.ZONEWIDTH, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute ZoneWidth </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getZoneWidth()
      {
         return getRealAttribute(AttributeName.ZONEWIDTH, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Zones
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Zones </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setZones(int @value)
      {
         setAttribute(AttributeName.ZONES, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute Zones </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getZones()
      {
         return getIntAttribute(AttributeName.ZONES, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ZonesY
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ZonesY </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setZonesY(int @value)
      {
         setAttribute(AttributeName.ZONESY, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute ZonesY </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getZonesY()
      {
         return getIntAttribute(AttributeName.ZONESY, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ZoneHeight
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ZoneHeight </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setZoneHeight(double @value)
      {
         setAttribute(AttributeName.ZONEHEIGHT, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute ZoneHeight </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getZoneHeight()
      {
         return getRealAttribute(AttributeName.ZONEHEIGHT, null, 0.0);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element Device </summary>
      ///     * <returns> JDFDevice the element </returns>
      ///     
      public virtual JDFDevice getDevice()
      {
         return (JDFDevice)getElement(ElementName.DEVICE, null, 0);
      }

      ///     <summary> (25) getCreateDevice
      ///     *  </summary>
      ///     * <returns> JDFDevice the element </returns>
      ///     
      public virtual JDFDevice getCreateDevice()
      {
         return (JDFDevice)getCreateElement_KElement(ElementName.DEVICE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Device </summary>
      ///     
      public virtual JDFDevice appendDevice()
      {
         return (JDFDevice)appendElementN(ElementName.DEVICE, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refDevice(JDFDevice refTarget)
      {
         refElement(refTarget);
      }
   }
}
