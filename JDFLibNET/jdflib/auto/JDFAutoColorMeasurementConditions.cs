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


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;

   public abstract class JDFAutoColorMeasurementConditions : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[8];
      static JDFAutoColorMeasurementConditions()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.DENSITYSTANDARD, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumDensityStandard.getEnum(0), "ANSIT");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.ILLUMINATION, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumIllumination.getEnum(0), "D50");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.OBSERVER, 0x33333331, AttributeInfo.EnumAttributeType.integer, null, "2");
         atrInfoTable[3] = new AtrInfoTable(AttributeName.INSTRUMENTATION, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.INKSTATE, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumInkState.getEnum(0), null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.MEASUREMENTFILTER, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumMeasurementFilter.getEnum(0), null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.SAMPLEBACKING, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumSampleBacking.getEnum(0), null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.WHITEBASE, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumWhiteBase.getEnum(0), null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoColorMeasurementConditions </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoColorMeasurementConditions(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoColorMeasurementConditions </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoColorMeasurementConditions(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoColorMeasurementConditions </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoColorMeasurementConditions(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoColorMeasurementConditions[  --> " + base.ToString() + " ]";
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



      ///        
      ///        <summary> * Enumeration strings for Illumination </summary>
      ///        

      public class EnumIllumination : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumIllumination(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumIllumination getEnum(string enumName)
         {
            return (EnumIllumination)getEnum(typeof(EnumIllumination), enumName);
         }

         public static EnumIllumination getEnum(int enumValue)
         {
            return (EnumIllumination)getEnum(typeof(EnumIllumination), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumIllumination));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumIllumination));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumIllumination));
         }

         public static readonly EnumIllumination D50 = new EnumIllumination("D50");
         public static readonly EnumIllumination D65 = new EnumIllumination("D65");
         public static readonly EnumIllumination Unknown = new EnumIllumination("Unknown");
      }



      ///        
      ///        <summary> * Enumeration strings for InkState </summary>
      ///        

      public class EnumInkState : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumInkState(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumInkState getEnum(string enumName)
         {
            return (EnumInkState)getEnum(typeof(EnumInkState), enumName);
         }

         public static EnumInkState getEnum(int enumValue)
         {
            return (EnumInkState)getEnum(typeof(EnumInkState), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumInkState));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumInkState));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumInkState));
         }

         public static readonly EnumInkState Dry = new EnumInkState("Dry");
         public static readonly EnumInkState Wet = new EnumInkState("Wet");
         public static readonly EnumInkState NA = new EnumInkState("NA");
      }



      ///        
      ///        <summary> * Enumeration strings for MeasurementFilter </summary>
      ///        

      public class EnumMeasurementFilter : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumMeasurementFilter(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumMeasurementFilter getEnum(string enumName)
         {
            return (EnumMeasurementFilter)getEnum(typeof(EnumMeasurementFilter), enumName);
         }

         public static EnumMeasurementFilter getEnum(int enumValue)
         {
            return (EnumMeasurementFilter)getEnum(typeof(EnumMeasurementFilter), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumMeasurementFilter));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumMeasurementFilter));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumMeasurementFilter));
         }

         public static readonly EnumMeasurementFilter None = new EnumMeasurementFilter("None");
         public static readonly EnumMeasurementFilter Pol = new EnumMeasurementFilter("Pol");
         public static readonly EnumMeasurementFilter UV = new EnumMeasurementFilter("UV");
      }



      ///        
      ///        <summary> * Enumeration strings for SampleBacking </summary>
      ///        

      public class EnumSampleBacking : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumSampleBacking(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumSampleBacking getEnum(string enumName)
         {
            return (EnumSampleBacking)getEnum(typeof(EnumSampleBacking), enumName);
         }

         public static EnumSampleBacking getEnum(int enumValue)
         {
            return (EnumSampleBacking)getEnum(typeof(EnumSampleBacking), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumSampleBacking));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumSampleBacking));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumSampleBacking));
         }

         public static readonly EnumSampleBacking Black = new EnumSampleBacking("Black");
         public static readonly EnumSampleBacking White = new EnumSampleBacking("White");
         public static readonly EnumSampleBacking NA = new EnumSampleBacking("NA");
      }



      ///        
      ///        <summary> * Enumeration strings for WhiteBase </summary>
      ///        

      public class EnumWhiteBase : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumWhiteBase(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumWhiteBase getEnum(string enumName)
         {
            return (EnumWhiteBase)getEnum(typeof(EnumWhiteBase), enumName);
         }

         public static EnumWhiteBase getEnum(int enumValue)
         {
            return (EnumWhiteBase)getEnum(typeof(EnumWhiteBase), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumWhiteBase));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumWhiteBase));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumWhiteBase));
         }

         public static readonly EnumWhiteBase Absolute = new EnumWhiteBase("Absolute");
         public static readonly EnumWhiteBase Paper = new EnumWhiteBase("Paper");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

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
         return EnumDensityStandard.getEnum(getAttribute(AttributeName.DENSITYSTANDARD, null, "ANSIT"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Illumination
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Illumination </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setIllumination(EnumIllumination enumVar)
      {
         setAttribute(AttributeName.ILLUMINATION, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Illumination </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumIllumination getIllumination()
      {
         return EnumIllumination.getEnum(getAttribute(AttributeName.ILLUMINATION, null, "D50"));
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
         return getIntAttribute(AttributeName.OBSERVER, null, 2);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Instrumentation
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Instrumentation </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setInstrumentation(string @value)
      {
         setAttribute(AttributeName.INSTRUMENTATION, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Instrumentation </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getInstrumentation()
      {
         return getAttribute(AttributeName.INSTRUMENTATION, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute InkState
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute InkState </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setInkState(EnumInkState enumVar)
      {
         setAttribute(AttributeName.INKSTATE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute InkState </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumInkState getInkState()
      {
         return EnumInkState.getEnum(getAttribute(AttributeName.INKSTATE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MeasurementFilter
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute MeasurementFilter </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setMeasurementFilter(EnumMeasurementFilter enumVar)
      {
         setAttribute(AttributeName.MEASUREMENTFILTER, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute MeasurementFilter </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumMeasurementFilter getMeasurementFilter()
      {
         return EnumMeasurementFilter.getEnum(getAttribute(AttributeName.MEASUREMENTFILTER, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SampleBacking
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute SampleBacking </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setSampleBacking(EnumSampleBacking enumVar)
      {
         setAttribute(AttributeName.SAMPLEBACKING, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute SampleBacking </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumSampleBacking getSampleBacking()
      {
         return EnumSampleBacking.getEnum(getAttribute(AttributeName.SAMPLEBACKING, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute WhiteBase
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute WhiteBase </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setWhiteBase(EnumWhiteBase enumVar)
      {
         setAttribute(AttributeName.WHITEBASE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute WhiteBase </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumWhiteBase getWhiteBase()
      {
         return EnumWhiteBase.getEnum(getAttribute(AttributeName.WHITEBASE, null, null));
      }
   }
}
