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


/*
 * The CIP4 Software License, Version 1.0
 *
 *
 * Copyright (c) 2001-2005 The International Cooperation for the Integration of
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
 * THIS SOFTWARE IS PROVIDED ``AS IS'' AND ANY EXPRESSED OR IMPLIED
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
 *
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
   using JDFIntegerList = org.cip4.jdflib.datatypes.JDFIntegerList;
   using JDFNumberList = org.cip4.jdflib.datatypes.JDFNumberList;

   public abstract class JDFAutoDCTParams : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[7];
      static JDFAutoDCTParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.SOURCECSS, 0x22222211, AttributeInfo.EnumAttributeType.enumerations, EnumSourceCSs.getEnum(0), null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.HSAMPLES, 0x33333311, AttributeInfo.EnumAttributeType.IntegerList, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.VSAMPLES, 0x33333311, AttributeInfo.EnumAttributeType.IntegerList, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.QFACTOR, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, "1.0");
         atrInfoTable[4] = new AtrInfoTable(AttributeName.QUANTTABLE, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.HUFFTABLE, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.COLORTRANSFORM, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumColorTransform.getEnum(0), "Automatic");
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoDCTParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoDCTParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoDCTParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoDCTParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoDCTParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoDCTParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoDCTParams[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for SourceCSs </summary>
      ///        

      public class EnumSourceCSs : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumSourceCSs(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumSourceCSs getEnum(string enumName)
         {
            return (EnumSourceCSs)getEnum(typeof(EnumSourceCSs), enumName);
         }

         public static EnumSourceCSs getEnum(int enumValue)
         {
            return (EnumSourceCSs)getEnum(typeof(EnumSourceCSs), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumSourceCSs));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumSourceCSs));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumSourceCSs));
         }

         public static readonly EnumSourceCSs CalGray = new EnumSourceCSs("CalGray");
         public static readonly EnumSourceCSs CalRGB = new EnumSourceCSs("CalRGB");
         public static readonly EnumSourceCSs Calibrated = new EnumSourceCSs("Calibrated");
         public static readonly EnumSourceCSs CIEBased = new EnumSourceCSs("CIEBased");
         public static readonly EnumSourceCSs CMYK = new EnumSourceCSs("CMYK");
         public static readonly EnumSourceCSs DeviceN = new EnumSourceCSs("DeviceN");
         public static readonly EnumSourceCSs DevIndep = new EnumSourceCSs("DevIndep");
         public static readonly EnumSourceCSs RGB = new EnumSourceCSs("RGB");
         public static readonly EnumSourceCSs Gray = new EnumSourceCSs("Gray");
         public static readonly EnumSourceCSs ICCBased = new EnumSourceCSs("ICCBased");
         public static readonly EnumSourceCSs ICCCMYK = new EnumSourceCSs("ICCCMYK");
         public static readonly EnumSourceCSs ICCGray = new EnumSourceCSs("ICCGray");
         public static readonly EnumSourceCSs ICCLAB = new EnumSourceCSs("ICCLAB");
         public static readonly EnumSourceCSs ICCRGB = new EnumSourceCSs("ICCRGB");
         public static readonly EnumSourceCSs Lab = new EnumSourceCSs("Lab");
         public static readonly EnumSourceCSs Separtation = new EnumSourceCSs("Separtation");
         public static readonly EnumSourceCSs YUV = new EnumSourceCSs("YUV");
      }



      ///        
      ///        <summary> * Enumeration strings for ColorTransform </summary>
      ///        

      public class EnumColorTransform : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumColorTransform(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumColorTransform getEnum(string enumName)
         {
            return (EnumColorTransform)getEnum(typeof(EnumColorTransform), enumName);
         }

         public static EnumColorTransform getEnum(int enumValue)
         {
            return (EnumColorTransform)getEnum(typeof(EnumColorTransform), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumColorTransform));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumColorTransform));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumColorTransform));
         }

         public static readonly EnumColorTransform YUV = new EnumColorTransform("YUV");
         public static readonly EnumColorTransform None = new EnumColorTransform("None");
         public static readonly EnumColorTransform Automatic = new EnumColorTransform("Automatic");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute SourceCSs
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5.2) set attribute SourceCSs </summary>
      ///          * <param name="v"> vector of the enumeration values </param>
      ///          
      public virtual void setSourceCSs(List<ValuedEnum> v)
      {
         setEnumerationsAttribute(AttributeName.SOURCECSS, v, null);
      }

      ///        
      ///          <summary> * (9.2) get SourceCSs attribute SourceCSs </summary>
      ///          * <returns> Vector of the enumerations </returns>
      ///          
      public virtual List<ValuedEnum> getSourceCSs()
      {
         return getEnumerationsAttribute(AttributeName.SOURCECSS, null, EnumSourceCSs.getEnum(0), false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute HSamples
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute HSamples </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setHSamples(JDFIntegerList @value)
      {
         setAttribute(AttributeName.HSAMPLES, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerList attribute HSamples </summary>
      ///          * <returns> JDFIntegerList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerList </returns>
      ///          
      public virtual JDFIntegerList getHSamples()
      {
         string strAttrName = "";
         JDFIntegerList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.HSAMPLES, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute VSamples
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute VSamples </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setVSamples(JDFIntegerList @value)
      {
         setAttribute(AttributeName.VSAMPLES, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerList attribute VSamples </summary>
      ///          * <returns> JDFIntegerList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerList </returns>
      ///          
      public virtual JDFIntegerList getVSamples()
      {
         string strAttrName = "";
         JDFIntegerList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.VSAMPLES, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute QFactor
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute QFactor </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setQFactor(double @value)
      {
         setAttribute(AttributeName.QFACTOR, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute QFactor </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getQFactor()
      {
         return getRealAttribute(AttributeName.QFACTOR, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute QuantTable
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute QuantTable </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setQuantTable(JDFNumberList @value)
      {
         setAttribute(AttributeName.QUANTTABLE, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFNumberList attribute QuantTable </summary>
      ///          * <returns> JDFNumberList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFNumberList </returns>
      ///          
      public virtual JDFNumberList getQuantTable()
      {
         string strAttrName = "";
         JDFNumberList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.QUANTTABLE, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute HuffTable
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute HuffTable </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setHuffTable(JDFNumberList @value)
      {
         setAttribute(AttributeName.HUFFTABLE, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFNumberList attribute HuffTable </summary>
      ///          * <returns> JDFNumberList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFNumberList </returns>
      ///          
      public virtual JDFNumberList getHuffTable()
      {
         string strAttrName = "";
         JDFNumberList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.HUFFTABLE, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute ColorTransform
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute ColorTransform </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setColorTransform(EnumColorTransform enumVar)
      {
         setAttribute(AttributeName.COLORTRANSFORM, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute ColorTransform </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumColorTransform getColorTransform()
      {
         return EnumColorTransform.getEnum(getAttribute(AttributeName.COLORTRANSFORM, null, "Automatic"));
      }
   }
}
