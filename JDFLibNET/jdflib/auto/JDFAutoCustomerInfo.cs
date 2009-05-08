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
   using System.Collections.Generic;



   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFCustomerMessage = org.cip4.jdflib.core.JDFCustomerMessage;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFCompany = org.cip4.jdflib.resource.process.JDFCompany;
   using JDFContact = org.cip4.jdflib.resource.process.JDFContact;

   public abstract class JDFAutoCustomerInfo : JDFResource
   {

      private new const long serialVersionUID = 1L;


      ///    
      ///     <summary> * Constructor for JDFAutoCustomerInfo </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoCustomerInfo(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoCustomerInfo </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoCustomerInfo(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoCustomerInfo </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoCustomerInfo(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoCustomerInfo[  --> " + base.ToString() + " ]";
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


      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute BillingCode
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BillingCode </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBillingCode(string @value)
      {
         setAttribute(AttributeName.BILLINGCODE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute BillingCode </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getBillingCode()
      {
         return getAttribute(AttributeName.BILLINGCODE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute CustomerID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CustomerID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCustomerID(string @value)
      {
         setAttribute(AttributeName.CUSTOMERID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute CustomerID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getCustomerID()
      {
         return getAttribute(AttributeName.CUSTOMERID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute CustomerJobName
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CustomerJobName </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCustomerJobName(string @value)
      {
         setAttribute(AttributeName.CUSTOMERJOBNAME, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute CustomerJobName </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getCustomerJobName()
      {
         return getAttribute(AttributeName.CUSTOMERJOBNAME, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute CustomerOrderID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CustomerOrderID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCustomerOrderID(string @value)
      {
         setAttribute(AttributeName.CUSTOMERORDERID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute CustomerOrderID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getCustomerOrderID()
      {
         return getAttribute(AttributeName.CUSTOMERORDERID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute CustomerProjectID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CustomerProjectID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCustomerProjectID(string @value)
      {
         setAttribute(AttributeName.CUSTOMERPROJECTID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute CustomerProjectID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getCustomerProjectID()
      {
         return getAttribute(AttributeName.CUSTOMERPROJECTID, null, JDFConstants.EMPTYSTRING);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element Company </summary>
      ///     * <returns> JDFCompany the element </returns>
      ///     
      public virtual JDFCompany getCompany()
      {
         return (JDFCompany)getElement(ElementName.COMPANY, null, 0);
      }

      ///     <summary> (25) getCreateCompany
      ///     *  </summary>
      ///     * <returns> JDFCompany the element </returns>
      ///     
      public virtual JDFCompany getCreateCompany()
      {
         return (JDFCompany)getCreateElement_KElement(ElementName.COMPANY, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Company </summary>
      ///     
      public virtual JDFCompany appendCompany()
      {
         return (JDFCompany)appendElementN(ElementName.COMPANY, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refCompany(JDFCompany refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreateContact
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFContact the element </returns>
      ///     
      public virtual JDFContact getCreateContact(int iSkip)
      {
         return (JDFContact)getCreateElement_KElement(ElementName.CONTACT, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Contact </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFContact the element </returns>
      ///     * default is getContact(0)     
      public virtual JDFContact getContact(int iSkip)
      {
         return (JDFContact)getElement(ElementName.CONTACT, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Contact from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFContact> </returns>
      ///     
      public virtual ICollection<JDFContact> getAllContact()
      {
         List<JDFContact> v = new List<JDFContact>();

         JDFContact kElem = (JDFContact)getFirstChildElement(ElementName.CONTACT, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFContact)kElem.getNextSiblingElement(ElementName.CONTACT, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Contact </summary>
      ///     
      public override JDFContact appendContact()
      {
         return (JDFContact)appendElement(ElementName.CONTACT, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refContact(JDFContact refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreateCustomerMessage
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFCustomerMessage the element </returns>
      ///     
      public virtual JDFCustomerMessage getCreateCustomerMessage(int iSkip)
      {
         return (JDFCustomerMessage)getCreateElement_KElement(ElementName.CUSTOMERMESSAGE, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element CustomerMessage </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFCustomerMessage the element </returns>
      ///     * default is getCustomerMessage(0)     
      public virtual JDFCustomerMessage getCustomerMessage(int iSkip)
      {
         return (JDFCustomerMessage)getElement(ElementName.CUSTOMERMESSAGE, null, iSkip);
      }

      ///    
      ///     <summary> * Get all CustomerMessage from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFCustomerMessage> </returns>
      ///     
      public virtual ICollection<JDFCustomerMessage> getAllCustomerMessage()
      {
         List<JDFCustomerMessage> v = new List<JDFCustomerMessage>();

         JDFCustomerMessage kElem = (JDFCustomerMessage)getFirstChildElement(ElementName.CUSTOMERMESSAGE, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFCustomerMessage)kElem.getNextSiblingElement(ElementName.CUSTOMERMESSAGE, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element CustomerMessage </summary>
      ///     
      public virtual JDFCustomerMessage appendCustomerMessage()
      {
         return (JDFCustomerMessage)appendElement(ElementName.CUSTOMERMESSAGE, null);
      }
   }
}
