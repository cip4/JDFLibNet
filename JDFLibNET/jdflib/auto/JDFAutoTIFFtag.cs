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
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFIntegerList = org.cip4.jdflib.datatypes.JDFIntegerList;
   using JDFNumberList = org.cip4.jdflib.datatypes.JDFNumberList;

   public abstract class JDFAutoTIFFtag : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[6];
      static JDFAutoTIFFtag()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.TAGNUMBER, 0x22222211, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.TAGTYPE, 0x22222211, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.INTEGERVALUE, 0x33333311, AttributeInfo.EnumAttributeType.IntegerList, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.NUMBERVALUE, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.STRINGVALUE, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.BINARYVALUE, 0x33333311, AttributeInfo.EnumAttributeType.hexBinary, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoTIFFtag </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoTIFFtag(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoTIFFtag </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoTIFFtag(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoTIFFtag </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoTIFFtag(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoTIFFtag[  --> " + base.ToString() + " ]";
      }


      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute TagNumber
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TagNumber </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTagNumber(int @value)
      {
         setAttribute(AttributeName.TAGNUMBER, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute TagNumber </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getTagNumber()
      {
         return getIntAttribute(AttributeName.TAGNUMBER, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TagType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TagType </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTagType(int @value)
      {
         setAttribute(AttributeName.TAGTYPE, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute TagType </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getTagType()
      {
         return getIntAttribute(AttributeName.TAGTYPE, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute IntegerValue
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute IntegerValue </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setIntegerValue(JDFIntegerList @value)
      {
         setAttribute(AttributeName.INTEGERVALUE, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerList attribute IntegerValue </summary>
      ///          * <returns> JDFIntegerList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerList </returns>
      ///          
      public virtual JDFIntegerList getIntegerValue()
      {
         string strAttrName = "";
         JDFIntegerList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.INTEGERVALUE, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute NumberValue
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute NumberValue </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setNumberValue(JDFNumberList @value)
      {
         setAttribute(AttributeName.NUMBERVALUE, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFNumberList attribute NumberValue </summary>
      ///          * <returns> JDFNumberList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFNumberList </returns>
      ///          
      public virtual JDFNumberList getNumberValue()
      {
         string strAttrName = "";
         JDFNumberList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.NUMBERVALUE, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute StringValue
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute StringValue </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setStringValue(string @value)
      {
         setAttribute(AttributeName.STRINGVALUE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute StringValue </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getStringValue()
      {
         return getAttribute(AttributeName.STRINGVALUE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute BinaryValue
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BinaryValue </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBinaryValue(string @value)
      {
         setAttribute(AttributeName.BINARYVALUE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute BinaryValue </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getBinaryValue()
      {
         return getAttribute(AttributeName.BINARYVALUE, null, JDFConstants.EMPTYSTRING);
      }
   }
}
