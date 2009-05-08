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



   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using VString = org.cip4.jdflib.core.VString;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFAddress = org.cip4.jdflib.resource.process.JDFAddress;
   using JDFComChannel = org.cip4.jdflib.resource.process.JDFComChannel;
   using JDFCompany = org.cip4.jdflib.resource.process.JDFCompany;
   using JDFPerson = org.cip4.jdflib.resource.process.JDFPerson;

   public abstract class JDFAutoContact : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[2];
      static JDFAutoContact()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.CONTACTTYPES, 0x22222222, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.CONTACTTYPEDETAILS, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.ADDRESS, 0x66666666);
         elemInfoTable[1] = new ElemInfoTable(ElementName.COMCHANNEL, 0x33333333);
         elemInfoTable[2] = new ElemInfoTable(ElementName.COMPANY, 0x66666661);
         elemInfoTable[3] = new ElemInfoTable(ElementName.PERSON, 0x66666666);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[4];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoContact </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoContact(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoContact </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoContact(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoContact </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoContact(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoContact[  --> " + base.ToString() + " ]";
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
      //        Methods for Attribute ContactTypes
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ContactTypes </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setContactTypes(VString @value)
      {
         setAttribute(AttributeName.CONTACTTYPES, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute ContactTypes </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getContactTypes()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.CONTACTTYPES, null, JDFConstants.EMPTYSTRING);
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ContactTypeDetails
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ContactTypeDetails </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setContactTypeDetails(string @value)
      {
         setAttribute(AttributeName.CONTACTTYPEDETAILS, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ContactTypeDetails </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getContactTypeDetails()
      {
         return getAttribute(AttributeName.CONTACTTYPEDETAILS, null, JDFConstants.EMPTYSTRING);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element Address </summary>
      ///     * <returns> JDFAddress the element </returns>
      ///     
      public virtual JDFAddress getAddress()
      {
         return (JDFAddress)getElement(ElementName.ADDRESS, null, 0);
      }

      ///     <summary> (25) getCreateAddress
      ///     *  </summary>
      ///     * <returns> JDFAddress the element </returns>
      ///     
      public virtual JDFAddress getCreateAddress()
      {
         return (JDFAddress)getCreateElement_KElement(ElementName.ADDRESS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Address </summary>
      ///     
      public virtual JDFAddress appendAddress()
      {
         return (JDFAddress)appendElementN(ElementName.ADDRESS, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refAddress(JDFAddress refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreateComChannel
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFComChannel the element </returns>
      ///     
      public virtual JDFComChannel getCreateComChannel(int iSkip)
      {
         return (JDFComChannel)getCreateElement_KElement(ElementName.COMCHANNEL, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element ComChannel </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFComChannel the element </returns>
      ///     * default is getComChannel(0)     
      public virtual JDFComChannel getComChannel(int iSkip)
      {
         return (JDFComChannel)getElement(ElementName.COMCHANNEL, null, iSkip);
      }

      ///    
      ///     <summary> * Get all ComChannel from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFComChannel> </returns>
      ///     
      public virtual ICollection<JDFComChannel> getAllComChannel()
      {
         List<JDFComChannel> v = new List<JDFComChannel>();

         JDFComChannel kElem = (JDFComChannel)getFirstChildElement(ElementName.COMCHANNEL, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFComChannel)kElem.getNextSiblingElement(ElementName.COMCHANNEL, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element ComChannel </summary>
      ///     
      public virtual JDFComChannel appendComChannel()
      {
         return (JDFComChannel)appendElement(ElementName.COMCHANNEL, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refComChannel(JDFComChannel refTarget)
      {
         refElement(refTarget);
      }

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

      ///    
      ///     <summary> * (24) const get element Person </summary>
      ///     * <returns> JDFPerson the element </returns>
      ///     
      public virtual JDFPerson getPerson()
      {
         return (JDFPerson)getElement(ElementName.PERSON, null, 0);
      }

      ///     <summary> (25) getCreatePerson
      ///     *  </summary>
      ///     * <returns> JDFPerson the element </returns>
      ///     
      public virtual JDFPerson getCreatePerson()
      {
         return (JDFPerson)getCreateElement_KElement(ElementName.PERSON, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Person </summary>
      ///     
      public virtual JDFPerson appendPerson()
      {
         return (JDFPerson)appendElementN(ElementName.PERSON, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refPerson(JDFPerson refTarget)
      {
         refElement(refTarget);
      }
   }
}
