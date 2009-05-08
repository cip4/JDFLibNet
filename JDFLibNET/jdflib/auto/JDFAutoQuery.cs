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
   using JDFMessage = org.cip4.jdflib.jmf.JDFMessage;
   using JDFSubscription = org.cip4.jdflib.jmf.JDFSubscription;

   public abstract class JDFAutoQuery : JDFMessage
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[4];
      static JDFAutoQuery()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ACKNOWLEDGEFORMAT, 0x33333111, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.ACKNOWLEDGETEMPLATE, 0x33333111, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.ACKNOWLEDGEURL, 0x33333111, AttributeInfo.EnumAttributeType.URL, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.ACKNOWLEDGETYPE, 0x33333111, AttributeInfo.EnumAttributeType.enumerations, EnumAcknowledgeType.getEnum(0), "Completed");
         elemInfoTable[0] = new ElemInfoTable(ElementName.SUBSCRIPTION, 0x66666666);
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
      ///     <summary> * Constructor for JDFAutoQuery </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoQuery(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoQuery </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoQuery(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoQuery </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoQuery(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoQuery[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for AcknowledgeType </summary>
      ///        

      public class EnumAcknowledgeType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumAcknowledgeType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumAcknowledgeType getEnum(string enumName)
         {
            return (EnumAcknowledgeType)getEnum(typeof(EnumAcknowledgeType), enumName);
         }

         public static EnumAcknowledgeType getEnum(int enumValue)
         {
            return (EnumAcknowledgeType)getEnum(typeof(EnumAcknowledgeType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumAcknowledgeType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumAcknowledgeType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumAcknowledgeType));
         }

         public static readonly EnumAcknowledgeType Received = new EnumAcknowledgeType("Received");
         public static readonly EnumAcknowledgeType Applied = new EnumAcknowledgeType("Applied");
         public static readonly EnumAcknowledgeType Completed = new EnumAcknowledgeType("Completed");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute AcknowledgeFormat
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute AcknowledgeFormat </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAcknowledgeFormat(string @value)
      {
         setAttribute(AttributeName.ACKNOWLEDGEFORMAT, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute AcknowledgeFormat </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getAcknowledgeFormat()
      {
         return getAttribute(AttributeName.ACKNOWLEDGEFORMAT, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute AcknowledgeTemplate
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute AcknowledgeTemplate </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAcknowledgeTemplate(string @value)
      {
         setAttribute(AttributeName.ACKNOWLEDGETEMPLATE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute AcknowledgeTemplate </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getAcknowledgeTemplate()
      {
         return getAttribute(AttributeName.ACKNOWLEDGETEMPLATE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute AcknowledgeURL
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute AcknowledgeURL </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAcknowledgeURL(string @value)
      {
         setAttribute(AttributeName.ACKNOWLEDGEURL, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute AcknowledgeURL </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getAcknowledgeURL()
      {
         return getAttribute(AttributeName.ACKNOWLEDGEURL, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute AcknowledgeType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5.2) set attribute AcknowledgeType </summary>
      ///          * <param name="v"> vector of the enumeration values </param>
      ///          
      public virtual void setAcknowledgeType(List<ValuedEnum> v)
      {
         setEnumerationsAttribute(AttributeName.ACKNOWLEDGETYPE, v, null);
      }

      ///        
      ///          <summary> * (9.2) get AcknowledgeType attribute AcknowledgeType </summary>
      ///          * <returns> Vector of the enumerations </returns>
      ///          
      public virtual List<ValuedEnum> getAcknowledgeType()
      {
         return getEnumerationsAttribute(AttributeName.ACKNOWLEDGETYPE, null, EnumAcknowledgeType.Completed, false);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element Subscription </summary>
      ///     * <returns> JDFSubscription the element </returns>
      ///     
      public virtual JDFSubscription getSubscription()
      {
         return (JDFSubscription)getElement(ElementName.SUBSCRIPTION, null, 0);
      }

      ///     <summary> (25) getCreateSubscription
      ///     *  </summary>
      ///     * <returns> JDFSubscription the element </returns>
      ///     
      public virtual JDFSubscription getCreateSubscription()
      {
         return (JDFSubscription)getCreateElement_KElement(ElementName.SUBSCRIPTION, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Subscription </summary>
      ///     
      public virtual JDFSubscription appendSubscription()
      {
         return (JDFSubscription)appendElementN(ElementName.SUBSCRIPTION, 1, null);
      }
   }
}