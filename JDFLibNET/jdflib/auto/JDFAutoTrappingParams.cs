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
   using JDFColorantZoneDetails = org.cip4.jdflib.resource.process.JDFColorantZoneDetails;

   public abstract class JDFAutoTrappingParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[21];
      static JDFAutoTrappingParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.MINIMUMBLACKWIDTH, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, "0");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.TRAPENDSTYLE, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, "Miter");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.TRAPJOINSTYLE, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, "Miter");
         atrInfoTable[3] = new AtrInfoTable(AttributeName.BLACKCOLORLIMIT, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.BLACKDENSITYLIMIT, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.BLACKWIDTH, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.ENABLED, 0x44444433, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.HALFTONENAME, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.IMAGEINTERNALTRAPPING, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.IMAGERESOLUTION, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[10] = new AtrInfoTable(AttributeName.IMAGEMASKTRAPPING, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[11] = new AtrInfoTable(AttributeName.IMAGETOIMAGETRAPPING, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[12] = new AtrInfoTable(AttributeName.IMAGETOOBJECTTRAPPING, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[13] = new AtrInfoTable(AttributeName.IMAGETRAPPLACEMENT, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumImageTrapPlacement.getEnum(0), null);
         atrInfoTable[14] = new AtrInfoTable(AttributeName.IMAGETRAPWIDTH, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[15] = new AtrInfoTable(AttributeName.IMAGETRAPWIDTHY, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[16] = new AtrInfoTable(AttributeName.SLIDINGTRAPLIMIT, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[17] = new AtrInfoTable(AttributeName.STEPLIMIT, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[18] = new AtrInfoTable(AttributeName.TRAPCOLORSCALING, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[19] = new AtrInfoTable(AttributeName.TRAPWIDTH, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[20] = new AtrInfoTable(AttributeName.TRAPWIDTHY, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.COLORANTZONEDETAILS, 0x33333333);
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
      ///     <summary> * Constructor for JDFAutoTrappingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoTrappingParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoTrappingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoTrappingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoTrappingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoTrappingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoTrappingParams[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for ImageTrapPlacement </summary>
      ///        

      public class EnumImageTrapPlacement : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumImageTrapPlacement(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumImageTrapPlacement getEnum(string enumName)
         {
            return (EnumImageTrapPlacement)getEnum(typeof(EnumImageTrapPlacement), enumName);
         }

         public static EnumImageTrapPlacement getEnum(int enumValue)
         {
            return (EnumImageTrapPlacement)getEnum(typeof(EnumImageTrapPlacement), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumImageTrapPlacement));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumImageTrapPlacement));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumImageTrapPlacement));
         }

         public static readonly EnumImageTrapPlacement Center = new EnumImageTrapPlacement("Center");
         public static readonly EnumImageTrapPlacement Choke = new EnumImageTrapPlacement("Choke");
         public static readonly EnumImageTrapPlacement Normal = new EnumImageTrapPlacement("Normal");
         public static readonly EnumImageTrapPlacement Spread = new EnumImageTrapPlacement("Spread");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute MinimumBlackWidth
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MinimumBlackWidth </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMinimumBlackWidth(double @value)
      {
         setAttribute(AttributeName.MINIMUMBLACKWIDTH, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute MinimumBlackWidth </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getMinimumBlackWidth()
      {
         return getRealAttribute(AttributeName.MINIMUMBLACKWIDTH, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TrapEndStyle
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TrapEndStyle </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTrapEndStyle(string @value)
      {
         setAttribute(AttributeName.TRAPENDSTYLE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute TrapEndStyle </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getTrapEndStyle()
      {
         return getAttribute(AttributeName.TRAPENDSTYLE, null, "Miter");
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TrapJoinStyle
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TrapJoinStyle </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTrapJoinStyle(string @value)
      {
         setAttribute(AttributeName.TRAPJOINSTYLE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute TrapJoinStyle </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getTrapJoinStyle()
      {
         return getAttribute(AttributeName.TRAPJOINSTYLE, null, "Miter");
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute BlackColorLimit
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BlackColorLimit </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBlackColorLimit(double @value)
      {
         setAttribute(AttributeName.BLACKCOLORLIMIT, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute BlackColorLimit </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getBlackColorLimit()
      {
         return getRealAttribute(AttributeName.BLACKCOLORLIMIT, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute BlackDensityLimit
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BlackDensityLimit </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBlackDensityLimit(double @value)
      {
         setAttribute(AttributeName.BLACKDENSITYLIMIT, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute BlackDensityLimit </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getBlackDensityLimit()
      {
         return getRealAttribute(AttributeName.BLACKDENSITYLIMIT, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute BlackWidth
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BlackWidth </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBlackWidth(double @value)
      {
         setAttribute(AttributeName.BLACKWIDTH, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute BlackWidth </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getBlackWidth()
      {
         return getRealAttribute(AttributeName.BLACKWIDTH, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Enabled
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Enabled </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setEnabled(bool @value)
      {
         setAttribute(AttributeName.ENABLED, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute Enabled </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getEnabled()
      {
         return getBoolAttribute(AttributeName.ENABLED, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute HalftoneName
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute HalftoneName </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setHalftoneName(string @value)
      {
         setAttribute(AttributeName.HALFTONENAME, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute HalftoneName </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getHalftoneName()
      {
         return getAttribute(AttributeName.HALFTONENAME, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ImageInternalTrapping
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ImageInternalTrapping </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setImageInternalTrapping(bool @value)
      {
         setAttribute(AttributeName.IMAGEINTERNALTRAPPING, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute ImageInternalTrapping </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getImageInternalTrapping()
      {
         return getBoolAttribute(AttributeName.IMAGEINTERNALTRAPPING, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ImageResolution
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ImageResolution </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setImageResolution(int @value)
      {
         setAttribute(AttributeName.IMAGERESOLUTION, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute ImageResolution </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getImageResolution()
      {
         return getIntAttribute(AttributeName.IMAGERESOLUTION, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ImageMaskTrapping
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ImageMaskTrapping </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setImageMaskTrapping(bool @value)
      {
         setAttribute(AttributeName.IMAGEMASKTRAPPING, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute ImageMaskTrapping </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getImageMaskTrapping()
      {
         return getBoolAttribute(AttributeName.IMAGEMASKTRAPPING, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ImageToImageTrapping
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ImageToImageTrapping </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setImageToImageTrapping(bool @value)
      {
         setAttribute(AttributeName.IMAGETOIMAGETRAPPING, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute ImageToImageTrapping </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getImageToImageTrapping()
      {
         return getBoolAttribute(AttributeName.IMAGETOIMAGETRAPPING, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ImageToObjectTrapping
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ImageToObjectTrapping </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setImageToObjectTrapping(bool @value)
      {
         setAttribute(AttributeName.IMAGETOOBJECTTRAPPING, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute ImageToObjectTrapping </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getImageToObjectTrapping()
      {
         return getBoolAttribute(AttributeName.IMAGETOOBJECTTRAPPING, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ImageTrapPlacement
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute ImageTrapPlacement </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setImageTrapPlacement(EnumImageTrapPlacement enumVar)
      {
         setAttribute(AttributeName.IMAGETRAPPLACEMENT, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute ImageTrapPlacement </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumImageTrapPlacement getImageTrapPlacement()
      {
         return EnumImageTrapPlacement.getEnum(getAttribute(AttributeName.IMAGETRAPPLACEMENT, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ImageTrapWidth
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ImageTrapWidth </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setImageTrapWidth(double @value)
      {
         setAttribute(AttributeName.IMAGETRAPWIDTH, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute ImageTrapWidth </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getImageTrapWidth()
      {
         return getRealAttribute(AttributeName.IMAGETRAPWIDTH, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ImageTrapWidthY
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ImageTrapWidthY </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setImageTrapWidthY(double @value)
      {
         setAttribute(AttributeName.IMAGETRAPWIDTHY, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute ImageTrapWidthY </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getImageTrapWidthY()
      {
         return getRealAttribute(AttributeName.IMAGETRAPWIDTHY, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SlidingTrapLimit
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SlidingTrapLimit </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSlidingTrapLimit(double @value)
      {
         setAttribute(AttributeName.SLIDINGTRAPLIMIT, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute SlidingTrapLimit </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getSlidingTrapLimit()
      {
         return getRealAttribute(AttributeName.SLIDINGTRAPLIMIT, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute StepLimit
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute StepLimit </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setStepLimit(double @value)
      {
         setAttribute(AttributeName.STEPLIMIT, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute StepLimit </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getStepLimit()
      {
         return getRealAttribute(AttributeName.STEPLIMIT, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TrapColorScaling
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TrapColorScaling </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTrapColorScaling(double @value)
      {
         setAttribute(AttributeName.TRAPCOLORSCALING, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute TrapColorScaling </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getTrapColorScaling()
      {
         return getRealAttribute(AttributeName.TRAPCOLORSCALING, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TrapWidth
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TrapWidth </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTrapWidth(double @value)
      {
         setAttribute(AttributeName.TRAPWIDTH, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute TrapWidth </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getTrapWidth()
      {
         return getRealAttribute(AttributeName.TRAPWIDTH, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TrapWidthY
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TrapWidthY </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTrapWidthY(double @value)
      {
         setAttribute(AttributeName.TRAPWIDTHY, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute TrapWidthY </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getTrapWidthY()
      {
         return getRealAttribute(AttributeName.TRAPWIDTHY, null, 0.0);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateColorantZoneDetails
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFColorantZoneDetails the element </returns>
      ///     
      public virtual JDFColorantZoneDetails getCreateColorantZoneDetails(int iSkip)
      {
         return (JDFColorantZoneDetails)getCreateElement_KElement(ElementName.COLORANTZONEDETAILS, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element ColorantZoneDetails </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFColorantZoneDetails the element </returns>
      ///     * default is getColorantZoneDetails(0)     
      public virtual JDFColorantZoneDetails getColorantZoneDetails(int iSkip)
      {
         return (JDFColorantZoneDetails)getElement(ElementName.COLORANTZONEDETAILS, null, iSkip);
      }

      ///    
      ///     <summary> * Get all ColorantZoneDetails from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFColorantZoneDetails> </returns>
      ///     
      public virtual ICollection<JDFColorantZoneDetails> getAllColorantZoneDetails()
      {
         List<JDFColorantZoneDetails> v = new List<JDFColorantZoneDetails>();

         JDFColorantZoneDetails kElem = (JDFColorantZoneDetails)getFirstChildElement(ElementName.COLORANTZONEDETAILS, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFColorantZoneDetails)kElem.getNextSiblingElement(ElementName.COLORANTZONEDETAILS, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element ColorantZoneDetails </summary>
      ///     
      public virtual JDFColorantZoneDetails appendColorantZoneDetails()
      {
         return (JDFColorantZoneDetails)appendElement(ElementName.COLORANTZONEDETAILS, null);
      }
   }
}
