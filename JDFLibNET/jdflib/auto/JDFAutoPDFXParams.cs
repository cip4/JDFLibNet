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
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFRectangle = org.cip4.jdflib.datatypes.JDFRectangle;

   public abstract class JDFAutoPDFXParams : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[11];
      static JDFAutoPDFXParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.PDFX1ACHECK, 0x33333311, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.PDFX3CHECK, 0x33333311, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.PDFXBLEEDBOXTOTRIMBOXOFFSET, 0x33333311, AttributeInfo.EnumAttributeType.rectangle, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.PDFXCOMPLIANTPDFONLY, 0x33333311, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[4] = new AtrInfoTable(AttributeName.PDFXOUTPUTCONDITION, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.PDFXOUTPUTINTENTPROFILE, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.PDFXNOTRIMBOXERROR, 0x33333311, AttributeInfo.EnumAttributeType.boolean_, null, "true");
         atrInfoTable[7] = new AtrInfoTable(AttributeName.PDFXREGISTRYNAME, 0x33333311, AttributeInfo.EnumAttributeType.URL, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.PDFXSETBLEEDBOXTOMEDIABOX, 0x33333311, AttributeInfo.EnumAttributeType.boolean_, null, "true");
         atrInfoTable[9] = new AtrInfoTable(AttributeName.PDFXTRAPPED, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumPDFXTrapped.getEnum(0), null);
         atrInfoTable[10] = new AtrInfoTable(AttributeName.PDFXTRIMBOXTOMEDIABOXOFFSET, 0x33333311, AttributeInfo.EnumAttributeType.rectangle, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoPDFXParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPDFXParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPDFXParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPDFXParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPDFXParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoPDFXParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoPDFXParams[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for PDFXTrapped </summary>
      ///        

      public class EnumPDFXTrapped : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumPDFXTrapped(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumPDFXTrapped getEnum(string enumName)
         {
            return (EnumPDFXTrapped)getEnum(typeof(EnumPDFXTrapped), enumName);
         }

         public static EnumPDFXTrapped getEnum(int enumValue)
         {
            return (EnumPDFXTrapped)getEnum(typeof(EnumPDFXTrapped), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumPDFXTrapped));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumPDFXTrapped));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumPDFXTrapped));
         }

         public static readonly EnumPDFXTrapped Unknown = new EnumPDFXTrapped("Unknown");
         public static readonly EnumPDFXTrapped True = new EnumPDFXTrapped("True");
         public static readonly EnumPDFXTrapped False = new EnumPDFXTrapped("False");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute PDFX1aCheck
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PDFX1aCheck </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPDFX1aCheck(bool @value)
      {
         setAttribute(AttributeName.PDFX1ACHECK, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute PDFX1aCheck </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getPDFX1aCheck()
      {
         return getBoolAttribute(AttributeName.PDFX1ACHECK, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PDFX3Check
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PDFX3Check </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPDFX3Check(bool @value)
      {
         setAttribute(AttributeName.PDFX3CHECK, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute PDFX3Check </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getPDFX3Check()
      {
         return getBoolAttribute(AttributeName.PDFX3CHECK, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PDFXBleedBoxToTrimBoxOffset
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PDFXBleedBoxToTrimBoxOffset </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPDFXBleedBoxToTrimBoxOffset(JDFRectangle @value)
      {
         setAttribute(AttributeName.PDFXBLEEDBOXTOTRIMBOXOFFSET, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFRectangle attribute PDFXBleedBoxToTrimBoxOffset </summary>
      ///          * <returns> JDFRectangle the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFRectangle </returns>
      ///          
      public virtual JDFRectangle getPDFXBleedBoxToTrimBoxOffset()
      {
         string strAttrName = "";
         JDFRectangle nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.PDFXBLEEDBOXTOTRIMBOXOFFSET, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute PDFXCompliantPDFOnly
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PDFXCompliantPDFOnly </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPDFXCompliantPDFOnly(bool @value)
      {
         setAttribute(AttributeName.PDFXCOMPLIANTPDFONLY, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute PDFXCompliantPDFOnly </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getPDFXCompliantPDFOnly()
      {
         return getBoolAttribute(AttributeName.PDFXCOMPLIANTPDFONLY, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PDFXOutputCondition
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PDFXOutputCondition </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPDFXOutputCondition(string @value)
      {
         setAttribute(AttributeName.PDFXOUTPUTCONDITION, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute PDFXOutputCondition </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getPDFXOutputCondition()
      {
         return getAttribute(AttributeName.PDFXOUTPUTCONDITION, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PDFXOutputIntentProfile
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PDFXOutputIntentProfile </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPDFXOutputIntentProfile(string @value)
      {
         setAttribute(AttributeName.PDFXOUTPUTINTENTPROFILE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute PDFXOutputIntentProfile </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getPDFXOutputIntentProfile()
      {
         return getAttribute(AttributeName.PDFXOUTPUTINTENTPROFILE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PDFXNoTrimBoxError
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PDFXNoTrimBoxError </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPDFXNoTrimBoxError(bool @value)
      {
         setAttribute(AttributeName.PDFXNOTRIMBOXERROR, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute PDFXNoTrimBoxError </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getPDFXNoTrimBoxError()
      {
         return getBoolAttribute(AttributeName.PDFXNOTRIMBOXERROR, null, true);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PDFXRegistryName
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PDFXRegistryName </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPDFXRegistryName(string @value)
      {
         setAttribute(AttributeName.PDFXREGISTRYNAME, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute PDFXRegistryName </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getPDFXRegistryName()
      {
         return getAttribute(AttributeName.PDFXREGISTRYNAME, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PDFXSetBleedBoxToMediaBox
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PDFXSetBleedBoxToMediaBox </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPDFXSetBleedBoxToMediaBox(bool @value)
      {
         setAttribute(AttributeName.PDFXSETBLEEDBOXTOMEDIABOX, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute PDFXSetBleedBoxToMediaBox </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getPDFXSetBleedBoxToMediaBox()
      {
         return getBoolAttribute(AttributeName.PDFXSETBLEEDBOXTOMEDIABOX, null, true);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PDFXTrapped
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute PDFXTrapped </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setPDFXTrapped(EnumPDFXTrapped enumVar)
      {
         setAttribute(AttributeName.PDFXTRAPPED, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute PDFXTrapped </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumPDFXTrapped getPDFXTrapped()
      {
         return EnumPDFXTrapped.getEnum(getAttribute(AttributeName.PDFXTRAPPED, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PDFXTrimBoxToMediaBoxOffset
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PDFXTrimBoxToMediaBoxOffset </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPDFXTrimBoxToMediaBoxOffset(JDFRectangle @value)
      {
         setAttribute(AttributeName.PDFXTRIMBOXTOMEDIABOXOFFSET, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFRectangle attribute PDFXTrimBoxToMediaBoxOffset </summary>
      ///          * <returns> JDFRectangle the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFRectangle </returns>
      ///          
      public virtual JDFRectangle getPDFXTrimBoxToMediaBoxOffset()
      {
         string strAttrName = "";
         JDFRectangle nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.PDFXTRIMBOXTOMEDIABOXOFFSET, null, JDFConstants.EMPTYSTRING);
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
   }
}
