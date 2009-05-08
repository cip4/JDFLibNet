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
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFErrorData = org.cip4.jdflib.resource.JDFErrorData;

   public abstract class JDFAutoError : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[3];
      static JDFAutoError()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ERRORID, 0x22222222, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.RESEND, 0x33333111, AttributeInfo.EnumAttributeType.enumeration, EnumResend.getEnum(0), null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.RETURNCODE, 0x33333311, AttributeInfo.EnumAttributeType.integer, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.ERRORDATA, 0x33333111);
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
      ///     <summary> * Constructor for JDFAutoError </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoError(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoError </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoError(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoError </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoError(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoError[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for Resend </summary>
      ///        

      public class EnumResend : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumResend(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumResend getEnum(string enumName)
         {
            return (EnumResend)getEnum(typeof(EnumResend), enumName);
         }

         public static EnumResend getEnum(int enumValue)
         {
            return (EnumResend)getEnum(typeof(EnumResend), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumResend));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumResend));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumResend));
         }

         public static readonly EnumResend Required = new EnumResend("Required");
         public static readonly EnumResend Prohibited = new EnumResend("Prohibited");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute ErrorID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ErrorID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setErrorID(string @value)
      {
         setAttribute(AttributeName.ERRORID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ErrorID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getErrorID()
      {
         return getAttribute(AttributeName.ERRORID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Resend
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Resend </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setResend(EnumResend enumVar)
      {
         setAttribute(AttributeName.RESEND, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Resend </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumResend getResend()
      {
         return EnumResend.getEnum(getAttribute(AttributeName.RESEND, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ReturnCode
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ReturnCode </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setReturnCode(int @value)
      {
         setAttribute(AttributeName.RETURNCODE, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute ReturnCode </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getReturnCode()
      {
         return getIntAttribute(AttributeName.RETURNCODE, null, 0);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateErrorData
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFErrorData the element </returns>
      ///     
      public virtual JDFErrorData getCreateErrorData(int iSkip)
      {
         return (JDFErrorData)getCreateElement_KElement(ElementName.ERRORDATA, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element ErrorData </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFErrorData the element </returns>
      ///     * default is getErrorData(0)     
      public virtual JDFErrorData getErrorData(int iSkip)
      {
         return (JDFErrorData)getElement(ElementName.ERRORDATA, null, iSkip);
      }

      ///    
      ///     <summary> * Get all ErrorData from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFErrorData> </returns>
      ///     
      public virtual ICollection<JDFErrorData> getAllErrorData()
      {
         List<JDFErrorData> v = new List<JDFErrorData>();

         JDFErrorData kElem = (JDFErrorData)getFirstChildElement(ElementName.ERRORDATA, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFErrorData)kElem.getNextSiblingElement(ElementName.ERRORDATA, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element ErrorData </summary>
      ///     
      public virtual JDFErrorData appendErrorData()
      {
         return (JDFErrorData)appendElement(ElementName.ERRORDATA, null);
      }
   }
}
