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

   public abstract class JDFAutoInk : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[5];
      static JDFAutoInk()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.COLORNAME, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.FAMILY, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.INKNAME, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.SPECIALINK, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.SPECIFICYIELD, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.CONTACT, 0x33333333);
         elemInfoTable[1] = new ElemInfoTable(ElementName.IDENTIFICATIONFIELD, 0x33333333);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[2];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoInk </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoInk(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoInk </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoInk(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoInk </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoInk(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoInk[  --> " + base.ToString() + " ]";
      }


      public override bool init()
      {
         bool bRet = base.init();
         setResourceClass(JDFResource.EnumResourceClass.Consumable);
         return bRet;
      }


      public override EnumResourceClass getValidClass()
      {
         return JDFResource.EnumResourceClass.Consumable;
      }


      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute ColorName
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ColorName </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setColorName(string @value)
      {
         setAttribute(AttributeName.COLORNAME, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ColorName </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getColorName()
      {
         return getAttribute(AttributeName.COLORNAME, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Family
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Family </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFamily(string @value)
      {
         setAttribute(AttributeName.FAMILY, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Family </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getFamily()
      {
         return getAttribute(AttributeName.FAMILY, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute InkName
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute InkName </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setInkName(string @value)
      {
         setAttribute(AttributeName.INKNAME, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute InkName </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getInkName()
      {
         return getAttribute(AttributeName.INKNAME, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SpecialInk
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SpecialInk </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSpecialInk(string @value)
      {
         setAttribute(AttributeName.SPECIALINK, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute SpecialInk </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getSpecialInk()
      {
         return getAttribute(AttributeName.SPECIALINK, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SpecificYield
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SpecificYield </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSpecificYield(double @value)
      {
         setAttribute(AttributeName.SPECIFICYIELD, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute SpecificYield </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getSpecificYield()
      {
         return getRealAttribute(AttributeName.SPECIFICYIELD, null, 0.0);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

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
