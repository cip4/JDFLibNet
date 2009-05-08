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
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using VString = org.cip4.jdflib.core.VString;

   public abstract class JDFAutoSubmissionMethods : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[6];
      static JDFAutoSubmissionMethods()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.FILE, 0x44444433, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.HOTFOLDER, 0x33333333, AttributeInfo.EnumAttributeType.URL, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.HTTPGET, 0x44444433, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.PACKAGING, 0x33333311, AttributeInfo.EnumAttributeType.enumerations, EnumPackaging.getEnum(0), null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.MIME, 0x44444433, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.URLSCHEMES, 0x33333311, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoSubmissionMethods </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoSubmissionMethods(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoSubmissionMethods </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoSubmissionMethods(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoSubmissionMethods </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoSubmissionMethods(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoSubmissionMethods[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for Packaging </summary>
      ///        

      public class EnumPackaging : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumPackaging(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumPackaging getEnum(string enumName)
         {
            return (EnumPackaging)getEnum(typeof(EnumPackaging), enumName);
         }

         public static EnumPackaging getEnum(int enumValue)
         {
            return (EnumPackaging)getEnum(typeof(EnumPackaging), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumPackaging));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumPackaging));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumPackaging));
         }

         public static readonly EnumPackaging MIME = new EnumPackaging("MIME");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute File
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute File </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFile(bool @value)
      {
         setAttribute(AttributeName.FILE, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute File </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getFile()
      {
         return getBoolAttribute(AttributeName.FILE, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute HotFolder
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute HotFolder </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setHotFolder(string @value)
      {
         setAttribute(AttributeName.HOTFOLDER, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute HotFolder </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getHotFolder()
      {
         return getAttribute(AttributeName.HOTFOLDER, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute HttpGet
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute HttpGet </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setHttpGet(bool @value)
      {
         setAttribute(AttributeName.HTTPGET, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute HttpGet </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getHttpGet()
      {
         return getBoolAttribute(AttributeName.HTTPGET, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Packaging
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5.2) set attribute Packaging </summary>
      ///          * <param name="v"> vector of the enumeration values </param>
      ///          
      public virtual void setPackaging(List<ValuedEnum> v)
      {
         setEnumerationsAttribute(AttributeName.PACKAGING, v, null);
      }

      ///        
      ///          <summary> * (9.2) get Packaging attribute Packaging </summary>
      ///          * <returns> Vector of the enumerations </returns>
      ///          
      public virtual List<ValuedEnum> getPackaging()
      {
         return getEnumerationsAttribute(AttributeName.PACKAGING, null, EnumPackaging.getEnum(0), false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MIME
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MIME </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMIME(bool @value)
      {
         setAttribute(AttributeName.MIME, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute MIME </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getMIME()
      {
         return getBoolAttribute(AttributeName.MIME, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute URLSchemes
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute URLSchemes </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setURLSchemes(VString @value)
      {
         setAttribute(AttributeName.URLSCHEMES, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute URLSchemes </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getURLSchemes()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.URLSCHEMES, null, JDFConstants.EMPTYSTRING);
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
      }
   }
}
