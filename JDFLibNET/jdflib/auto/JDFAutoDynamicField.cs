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


   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFDeviceMark = org.cip4.jdflib.resource.JDFDeviceMark;

   public abstract class JDFAutoDynamicField : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[6];
      static JDFAutoDynamicField()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.FORMAT, 0x22222222, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.INPUTFIELD, 0x44444443, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.ORD, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.ORDEXPRESSION, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.REPLACEFIELD, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.TEMPLATE, 0x22222222, AttributeInfo.EnumAttributeType.string_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.DEVICEMARK, 0x66666661);
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
      ///     <summary> * Constructor for JDFAutoDynamicField </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoDynamicField(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoDynamicField </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoDynamicField(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoDynamicField </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoDynamicField(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoDynamicField[  --> " + base.ToString() + " ]";
      }


      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

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
      //        Methods for Attribute InputField
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute InputField </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setInputField(string @value)
      {
         setAttribute(AttributeName.INPUTFIELD, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute InputField </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getInputField()
      {
         return getAttribute(AttributeName.INPUTFIELD, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Ord
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Ord </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setOrd(int @value)
      {
         setAttribute(AttributeName.ORD, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute Ord </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getOrd()
      {
         return getIntAttribute(AttributeName.ORD, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute OrdExpression
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute OrdExpression </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setOrdExpression(string @value)
      {
         setAttribute(AttributeName.ORDEXPRESSION, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute OrdExpression </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getOrdExpression()
      {
         return getAttribute(AttributeName.ORDEXPRESSION, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ReplaceField
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ReplaceField </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setReplaceField(string @value)
      {
         setAttribute(AttributeName.REPLACEFIELD, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ReplaceField </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getReplaceField()
      {
         return getAttribute(AttributeName.REPLACEFIELD, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Template
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Template </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTemplate(string @value)
      {
         setAttribute(AttributeName.TEMPLATE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Template </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getTemplate()
      {
         return getAttribute(AttributeName.TEMPLATE, null, JDFConstants.EMPTYSTRING);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element DeviceMark </summary>
      ///     * <returns> JDFDeviceMark the element </returns>
      ///     
      public virtual JDFDeviceMark getDeviceMark()
      {
         return (JDFDeviceMark)getElement(ElementName.DEVICEMARK, null, 0);
      }

      ///     <summary> (25) getCreateDeviceMark
      ///     *  </summary>
      ///     * <returns> JDFDeviceMark the element </returns>
      ///     
      public virtual JDFDeviceMark getCreateDeviceMark()
      {
         return (JDFDeviceMark)getCreateElement_KElement(ElementName.DEVICEMARK, null, 0);
      }

      ///    
      ///     <summary> * (29) append element DeviceMark </summary>
      ///     
      public virtual JDFDeviceMark appendDeviceMark()
      {
         return (JDFDeviceMark)appendElementN(ElementName.DEVICEMARK, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refDeviceMark(JDFDeviceMark refTarget)
      {
         refElement(refTarget);
      }
   }
}
