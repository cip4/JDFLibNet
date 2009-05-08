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
   using JDFCostCenter = org.cip4.jdflib.resource.process.JDFCostCenter;
   using JDFPerson = org.cip4.jdflib.resource.process.JDFPerson;

   public abstract class JDFAutoEmployee : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[3];
      static JDFAutoEmployee()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.PERSONALID, 0x33333333, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.ROLES, 0x33333311, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.SHIFT, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.COSTCENTER, 0x66666666);
         elemInfoTable[1] = new ElemInfoTable(ElementName.PERSON, 0x66666666);
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
      ///     <summary> * Constructor for JDFAutoEmployee </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoEmployee(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoEmployee </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoEmployee(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoEmployee </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoEmployee(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoEmployee[  --> " + base.ToString() + " ]";
      }


      public override bool init()
      {
         bool bRet = base.init();
         setResourceClass(JDFResource.EnumResourceClass.Implementation);
         return bRet;
      }


      public override EnumResourceClass getValidClass()
      {
         return JDFResource.EnumResourceClass.Implementation;
      }


      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute PersonalID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PersonalID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPersonalID(string @value)
      {
         setAttribute(AttributeName.PERSONALID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute PersonalID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getPersonalID()
      {
         return getAttribute(AttributeName.PERSONALID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Roles
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Roles </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setRoles(VString @value)
      {
         setAttribute(AttributeName.ROLES, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute Roles </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getRoles()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.ROLES, null, JDFConstants.EMPTYSTRING);
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Shift
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Shift </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setShift(string @value)
      {
         setAttribute(AttributeName.SHIFT, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Shift </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getShift()
      {
         return getAttribute(AttributeName.SHIFT, null, JDFConstants.EMPTYSTRING);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element CostCenter </summary>
      ///     * <returns> JDFCostCenter the element </returns>
      ///     
      public virtual JDFCostCenter getCostCenter()
      {
         return (JDFCostCenter)getElement(ElementName.COSTCENTER, null, 0);
      }

      ///     <summary> (25) getCreateCostCenter
      ///     *  </summary>
      ///     * <returns> JDFCostCenter the element </returns>
      ///     
      public virtual JDFCostCenter getCreateCostCenter()
      {
         return (JDFCostCenter)getCreateElement_KElement(ElementName.COSTCENTER, null, 0);
      }

      ///    
      ///     <summary> * (29) append element CostCenter </summary>
      ///     
      public virtual JDFCostCenter appendCostCenter()
      {
         return (JDFCostCenter)appendElementN(ElementName.COSTCENTER, 1, null);
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
