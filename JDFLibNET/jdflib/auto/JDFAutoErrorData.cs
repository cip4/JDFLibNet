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
   using JDFElement = org.cip4.jdflib.core.JDFElement;

   public abstract class JDFAutoErrorData : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[4];
      static JDFAutoErrorData()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ERRORTYPE, 0x22222222, AttributeInfo.EnumAttributeType.enumeration, EnumErrorType.getEnum(0), null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.ERRORURL, 0x33333333, AttributeInfo.EnumAttributeType.URI, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.FIXEXPRESSION, 0x33333333, AttributeInfo.EnumAttributeType.Any, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.PATH, 0x33333333, AttributeInfo.EnumAttributeType.XPath, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoErrorData </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoErrorData(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoErrorData </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoErrorData(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoErrorData </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoErrorData(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoErrorData[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for ErrorType </summary>
      ///        

      public class EnumErrorType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumErrorType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumErrorType getEnum(string enumName)
         {
            return (EnumErrorType)getEnum(typeof(EnumErrorType), enumName);
         }

         public static EnumErrorType getEnum(int enumValue)
         {
            return (EnumErrorType)getEnum(typeof(EnumErrorType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumErrorType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumErrorType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumErrorType));
         }

         public static readonly EnumErrorType Invalid = new EnumErrorType("Invalid");
         public static readonly EnumErrorType Missing = new EnumErrorType("Missing");
         public static readonly EnumErrorType Unsupported = new EnumErrorType("Unsupported");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute ErrorType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute ErrorType </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setErrorType(EnumErrorType enumVar)
      {
         setAttribute(AttributeName.ERRORTYPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute ErrorType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumErrorType getErrorType()
      {
         return EnumErrorType.getEnum(getAttribute(AttributeName.ERRORTYPE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ErrorURL
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ErrorURL </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setErrorURL(string @value)
      {
         setAttribute(AttributeName.ERRORURL, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ErrorURL </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getErrorURL()
      {
         return getAttribute(AttributeName.ERRORURL, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute FixExpression
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute FixExpression </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFixExpression(string @value)
      {
         setAttribute(AttributeName.FIXEXPRESSION, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute FixExpression </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getFixExpression()
      {
         return getAttribute(AttributeName.FIXEXPRESSION, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Path
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Path </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPath(string @value)
      {
         setAttribute(AttributeName.PATH, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Path </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getPath()
      {
         return getAttribute(AttributeName.PATH, null, JDFConstants.EMPTYSTRING);
      }
   }
}
