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
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFNumberRange = org.cip4.jdflib.datatypes.JDFNumberRange;

   public abstract class JDFAutoScreenSelector : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[10];
      static JDFAutoScreenSelector()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ANGLE, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.ANGLEMAP, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.DOTSIZE, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.FREQUENCY, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.SCREENINGFAMILY, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.SCREENINGTYPE, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumScreeningType.getEnum(0), null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.SEPARATION, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, "All");
         atrInfoTable[7] = new AtrInfoTable(AttributeName.SOURCEFREQUENCY, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.SOURCEOBJECTS, 0x33333333, AttributeInfo.EnumAttributeType.enumerations, EnumSourceObjects.getEnum(0), "All");
         atrInfoTable[9] = new AtrInfoTable(AttributeName.SPOTFUNCTION, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoScreenSelector </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoScreenSelector(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoScreenSelector </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoScreenSelector(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoScreenSelector </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoScreenSelector(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoScreenSelector[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for ScreeningType </summary>
      ///        

      public class EnumScreeningType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumScreeningType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumScreeningType getEnum(string enumName)
         {
            return (EnumScreeningType)getEnum(typeof(EnumScreeningType), enumName);
         }

         public static EnumScreeningType getEnum(int enumValue)
         {
            return (EnumScreeningType)getEnum(typeof(EnumScreeningType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumScreeningType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumScreeningType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumScreeningType));
         }

         public static readonly EnumScreeningType AM = new EnumScreeningType("AM");
         public static readonly EnumScreeningType FM = new EnumScreeningType("FM");
         public static readonly EnumScreeningType Adaptive = new EnumScreeningType("Adaptive");
         public static readonly EnumScreeningType ErrorDiffusion = new EnumScreeningType("ErrorDiffusion");
         public static readonly EnumScreeningType HybridAM_FM = new EnumScreeningType("HybridAM-FM");
         public static readonly EnumScreeningType HybridAMline_dot = new EnumScreeningType("HybridAMline-dot");
      }



      ///        
      ///        <summary> * Enumeration strings for SourceObjects </summary>
      ///        

      public class EnumSourceObjects : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumSourceObjects(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumSourceObjects getEnum(string enumName)
         {
            return (EnumSourceObjects)getEnum(typeof(EnumSourceObjects), enumName);
         }

         public static EnumSourceObjects getEnum(int enumValue)
         {
            return (EnumSourceObjects)getEnum(typeof(EnumSourceObjects), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumSourceObjects));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumSourceObjects));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumSourceObjects));
         }

         public static readonly EnumSourceObjects All = new EnumSourceObjects("All");
         public static readonly EnumSourceObjects ImagePhotographic = new EnumSourceObjects("ImagePhotographic");
         public static readonly EnumSourceObjects ImageScreenShot = new EnumSourceObjects("ImageScreenShot");
         public static readonly EnumSourceObjects Text = new EnumSourceObjects("Text");
         public static readonly EnumSourceObjects LineArt = new EnumSourceObjects("LineArt");
         public static readonly EnumSourceObjects SmoothShades = new EnumSourceObjects("SmoothShades");
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
      //        Methods for Attribute AngleMap
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute AngleMap </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAngleMap(string @value)
      {
         setAttribute(AttributeName.ANGLEMAP, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute AngleMap </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getAngleMap()
      {
         return getAttribute(AttributeName.ANGLEMAP, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute DotSize
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DotSize </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDotSize(double @value)
      {
         setAttribute(AttributeName.DOTSIZE, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute DotSize </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getDotSize()
      {
         return getRealAttribute(AttributeName.DOTSIZE, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Frequency
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Frequency </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFrequency(double @value)
      {
         setAttribute(AttributeName.FREQUENCY, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute Frequency </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getFrequency()
      {
         return getRealAttribute(AttributeName.FREQUENCY, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ScreeningFamily
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ScreeningFamily </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setScreeningFamily(string @value)
      {
         setAttribute(AttributeName.SCREENINGFAMILY, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ScreeningFamily </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getScreeningFamily()
      {
         return getAttribute(AttributeName.SCREENINGFAMILY, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ScreeningType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute ScreeningType </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setScreeningType(EnumScreeningType enumVar)
      {
         setAttribute(AttributeName.SCREENINGTYPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute ScreeningType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumScreeningType getScreeningType()
      {
         return EnumScreeningType.getEnum(getAttribute(AttributeName.SCREENINGTYPE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Separation
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Separation </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSeparation(string @value)
      {
         setAttribute(AttributeName.SEPARATION, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Separation </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getSeparation()
      {
         return getAttribute(AttributeName.SEPARATION, null, "All");
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SourceFrequency
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SourceFrequency </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSourceFrequency(JDFNumberRange @value)
      {
         setAttribute(AttributeName.SOURCEFREQUENCY, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFNumberRange attribute SourceFrequency </summary>
      ///          * <returns> JDFNumberRange the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFNumberRange </returns>
      ///          
      public virtual JDFNumberRange getSourceFrequency()
      {
         string strAttrName = "";
         JDFNumberRange nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.SOURCEFREQUENCY, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFNumberRange(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SourceObjects
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5.2) set attribute SourceObjects </summary>
      ///          * <param name="v"> vector of the enumeration values </param>
      ///          
      public virtual void setSourceObjects(List<ValuedEnum> v)
      {
         setEnumerationsAttribute(AttributeName.SOURCEOBJECTS, v, null);
      }

      ///        
      ///          <summary> * (9.2) get SourceObjects attribute SourceObjects </summary>
      ///          * <returns> Vector of the enumerations </returns>
      ///          
      public virtual List<ValuedEnum> getSourceObjects()
      {
         return getEnumerationsAttribute(AttributeName.SOURCEOBJECTS, null, EnumSourceObjects.All, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SpotFunction
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SpotFunction </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSpotFunction(string @value)
      {
         setAttribute(AttributeName.SPOTFUNCTION, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute SpotFunction </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getSpotFunction()
      {
         return getAttribute(AttributeName.SPOTFUNCTION, null, JDFConstants.EMPTYSTRING);
      }
   }
}
