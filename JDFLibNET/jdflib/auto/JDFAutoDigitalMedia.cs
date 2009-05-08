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
   using System.Collections.Generic;



   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFContact = org.cip4.jdflib.resource.process.JDFContact;
   using JDFIdentificationField = org.cip4.jdflib.resource.process.JDFIdentificationField;
   using JDFRunList = org.cip4.jdflib.resource.process.JDFRunList;

   public abstract class JDFAutoDigitalMedia : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[4];
      static JDFAutoDigitalMedia()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.MEDIATYPE, 0x22222211, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.CAPACITY, 0x33333311, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.MEDIALABEL, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.MEDIATYPEDETAILS, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.RUNLIST, 0x66666611);
         elemInfoTable[1] = new ElemInfoTable(ElementName.CONTACT, 0x33333311);
         elemInfoTable[2] = new ElemInfoTable(ElementName.IDENTIFICATIONFIELD, 0x33333311);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[3];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoDigitalMedia </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoDigitalMedia(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoDigitalMedia </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoDigitalMedia(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoDigitalMedia </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoDigitalMedia(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoDigitalMedia[  --> " + base.ToString() + " ]";
      }


      public override bool init()
      {
         bool bRet = base.init();
         setResourceClass(JDFResource.EnumResourceClass.Handling);
         return bRet;
      }


      public override EnumResourceClass getValidClass()
      {
         return JDFResource.EnumResourceClass.Handling;
      }


      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute MediaType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MediaType </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMediaType(string @value)
      {
         setAttribute(AttributeName.MEDIATYPE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute MediaType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getMediaType()
      {
         return getAttribute(AttributeName.MEDIATYPE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Capacity
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Capacity </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCapacity(int @value)
      {
         setAttribute(AttributeName.CAPACITY, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute Capacity </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getCapacity()
      {
         return getIntAttribute(AttributeName.CAPACITY, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MediaLabel
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MediaLabel </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMediaLabel(string @value)
      {
         setAttribute(AttributeName.MEDIALABEL, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute MediaLabel </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getMediaLabel()
      {
         return getAttribute(AttributeName.MEDIALABEL, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MediaTypeDetails
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MediaTypeDetails </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMediaTypeDetails(string @value)
      {
         setAttribute(AttributeName.MEDIATYPEDETAILS, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute MediaTypeDetails </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getMediaTypeDetails()
      {
         return getAttribute(AttributeName.MEDIATYPEDETAILS, null, JDFConstants.EMPTYSTRING);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element RunList </summary>
      ///     * <returns> JDFRunList the element </returns>
      ///     
      public virtual JDFRunList getRunList()
      {
         return (JDFRunList)getElement(ElementName.RUNLIST, null, 0);
      }

      ///     <summary> (25) getCreateRunList
      ///     *  </summary>
      ///     * <returns> JDFRunList the element </returns>
      ///     
      public virtual JDFRunList getCreateRunList()
      {
         return (JDFRunList)getCreateElement_KElement(ElementName.RUNLIST, null, 0);
      }

      ///    
      ///     <summary> * (29) append element RunList </summary>
      ///     
      public virtual JDFRunList appendRunList()
      {
         return (JDFRunList)appendElementN(ElementName.RUNLIST, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refRunList(JDFRunList refTarget)
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

      ///     <summary> (26) getCreateIdentificationField
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFIdentificationField the element </returns>
      ///     
      public override JDFIdentificationField getCreateIdentificationField(int iSkip)
      {
         return (JDFIdentificationField)getCreateElement_KElement(ElementName.IDENTIFICATIONFIELD, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element IdentificationField </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFIdentificationField the element </returns>
      ///     * default is getIdentificationField(0)     
      public override JDFIdentificationField getIdentificationField(int iSkip)
      {
         return (JDFIdentificationField)getElement(ElementName.IDENTIFICATIONFIELD, null, iSkip);
      }

      ///    
      ///     <summary> * Get all IdentificationField from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFIdentificationField> </returns>
      ///     
      public virtual ICollection<JDFIdentificationField> getAllIdentificationField()
      {
         List<JDFIdentificationField> v = new List<JDFIdentificationField>();

         JDFIdentificationField kElem = (JDFIdentificationField)getFirstChildElement(ElementName.IDENTIFICATIONFIELD, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFIdentificationField)kElem.getNextSiblingElement(ElementName.IDENTIFICATIONFIELD, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element IdentificationField </summary>
      ///     
      public override JDFIdentificationField appendIdentificationField()
      {
         return (JDFIdentificationField)appendElement(ElementName.IDENTIFICATIONFIELD, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refIdentificationField(JDFIdentificationField refTarget)
      {
         refElement(refTarget);
      }
   }
}
