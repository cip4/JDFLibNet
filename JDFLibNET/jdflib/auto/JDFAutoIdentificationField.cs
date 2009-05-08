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
   using JDFMatrix = org.cip4.jdflib.datatypes.JDFMatrix;
   using JDFRectangle = org.cip4.jdflib.datatypes.JDFRectangle;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;

   public abstract class JDFAutoIdentificationField : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[12];
      static JDFAutoIdentificationField()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ENCODING, 0x22222222, AttributeInfo.EnumAttributeType.enumeration, EnumEncoding.getEnum(0), null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.ENCODINGDETAILS, 0x22222222, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.BOUNDINGBOX, 0x33333333, AttributeInfo.EnumAttributeType.rectangle, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.FORMAT, 0x33333333, AttributeInfo.EnumAttributeType.Any, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.ORIENTATION, 0x33333333, AttributeInfo.EnumAttributeType.matrix, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.PAGE, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.POSITION, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumPosition.getEnum(0), null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.PURPOSE, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumPurpose.getEnum(0), null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.PURPOSEDETAILS, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.VALUE, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[10] = new AtrInfoTable(AttributeName.VALUEFORMAT, 0x33333111, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[11] = new AtrInfoTable(AttributeName.VALUETEMPLATE, 0x33333111, AttributeInfo.EnumAttributeType.string_, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoIdentificationField </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoIdentificationField(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoIdentificationField </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoIdentificationField(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoIdentificationField </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoIdentificationField(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoIdentificationField[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for Encoding </summary>
      ///        

      public class EnumEncoding : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumEncoding(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumEncoding getEnum(string enumName)
         {
            return (EnumEncoding)getEnum(typeof(EnumEncoding), enumName);
         }

         public static EnumEncoding getEnum(int enumValue)
         {
            return (EnumEncoding)getEnum(typeof(EnumEncoding), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumEncoding));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumEncoding));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumEncoding));
         }

         public static readonly EnumEncoding ASCII = new EnumEncoding("ASCII");
         public static readonly EnumEncoding Barcode = new EnumEncoding("Barcode");
         public static readonly EnumEncoding BarCode1D = new EnumEncoding("BarCode1D");
         public static readonly EnumEncoding BarCode2D = new EnumEncoding("BarCode2D");
         public static readonly EnumEncoding RFID = new EnumEncoding("RFID");
      }



      ///        
      ///        <summary> * Enumeration strings for Position </summary>
      ///        

      public class EnumPosition : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumPosition(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumPosition getEnum(string enumName)
         {
            return (EnumPosition)getEnum(typeof(EnumPosition), enumName);
         }

         public static EnumPosition getEnum(int enumValue)
         {
            return (EnumPosition)getEnum(typeof(EnumPosition), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumPosition));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumPosition));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumPosition));
         }

         public static readonly EnumPosition Header = new EnumPosition("Header");
         public static readonly EnumPosition Trailer = new EnumPosition("Trailer");
         public static readonly EnumPosition Page = new EnumPosition("Page");
         public static readonly EnumPosition Top = new EnumPosition("Top");
         public static readonly EnumPosition Bottom = new EnumPosition("Bottom");
         public static readonly EnumPosition Left = new EnumPosition("Left");
         public static readonly EnumPosition Right = new EnumPosition("Right");
         public static readonly EnumPosition Front = new EnumPosition("Front");
         public static readonly EnumPosition Back = new EnumPosition("Back");
         public static readonly EnumPosition Any = new EnumPosition("Any");
      }



      ///        
      ///        <summary> * Enumeration strings for Purpose </summary>
      ///        

      public class EnumPurpose : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumPurpose(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumPurpose getEnum(string enumName)
         {
            return (EnumPurpose)getEnum(typeof(EnumPurpose), enumName);
         }

         public static EnumPurpose getEnum(int enumValue)
         {
            return (EnumPurpose)getEnum(typeof(EnumPurpose), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumPurpose));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumPurpose));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumPurpose));
         }

         public static readonly EnumPurpose Verification = new EnumPurpose("Verification");
         public static readonly EnumPurpose Separation = new EnumPurpose("Separation");
         public static readonly EnumPurpose Label = new EnumPurpose("Label");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute Encoding
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Encoding </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setEncoding(EnumEncoding enumVar)
      {
         setAttribute(AttributeName.ENCODING, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Encoding </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumEncoding getEncoding()
      {
         return EnumEncoding.getEnum(getAttribute(AttributeName.ENCODING, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute EncodingDetails
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute EncodingDetails </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setEncodingDetails(string @value)
      {
         setAttribute(AttributeName.ENCODINGDETAILS, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute EncodingDetails </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getEncodingDetails()
      {
         return getAttribute(AttributeName.ENCODINGDETAILS, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute BoundingBox
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BoundingBox </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBoundingBox(JDFRectangle @value)
      {
         setAttribute(AttributeName.BOUNDINGBOX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFRectangle attribute BoundingBox </summary>
      ///          * <returns> JDFRectangle the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFRectangle </returns>
      ///          
      public virtual JDFRectangle getBoundingBox()
      {
         string strAttrName = "";
         JDFRectangle nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.BOUNDINGBOX, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute Format
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Format </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFormat(string @value)
      {
         setAttribute(AttributeName.FORMAT, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Format </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getFormat()
      {
         return getAttribute(AttributeName.FORMAT, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Orientation
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Orientation </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setOrientation(JDFMatrix @value)
      {
         setAttribute(AttributeName.ORIENTATION, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFMatrix attribute Orientation </summary>
      ///          * <returns> JDFMatrix the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFMatrix </returns>
      ///          
      public virtual JDFMatrix getOrientation()
      {
         string strAttrName = "";
         JDFMatrix nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.ORIENTATION, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFMatrix(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Page
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Page </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPage(int @value)
      {
         setAttribute(AttributeName.PAGE, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute Page </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getPage()
      {
         return getIntAttribute(AttributeName.PAGE, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Position
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Position </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setPosition(EnumPosition enumVar)
      {
         setAttribute(AttributeName.POSITION, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Position </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumPosition getPosition()
      {
         return EnumPosition.getEnum(getAttribute(AttributeName.POSITION, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Purpose
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Purpose </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setPurpose(EnumPurpose enumVar)
      {
         setAttribute(AttributeName.PURPOSE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Purpose </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumPurpose getPurpose()
      {
         return EnumPurpose.getEnum(getAttribute(AttributeName.PURPOSE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PurposeDetails
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PurposeDetails </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPurposeDetails(string @value)
      {
         setAttribute(AttributeName.PURPOSEDETAILS, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute PurposeDetails </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getPurposeDetails()
      {
         return getAttribute(AttributeName.PURPOSEDETAILS, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Value
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Value </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setValue(string @value)
      {
         setAttribute(AttributeName.VALUE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Value </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getValue()
      {
         return getAttribute(AttributeName.VALUE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ValueFormat
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ValueFormat </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setValueFormat(string @value)
      {
         setAttribute(AttributeName.VALUEFORMAT, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ValueFormat </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getValueFormat()
      {
         return getAttribute(AttributeName.VALUEFORMAT, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ValueTemplate
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ValueTemplate </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setValueTemplate(string @value)
      {
         setAttribute(AttributeName.VALUETEMPLATE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ValueTemplate </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getValueTemplate()
      {
         return getAttribute(AttributeName.VALUETEMPLATE, null, JDFConstants.EMPTYSTRING);
      }
   }
}
