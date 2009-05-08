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
   using VString = org.cip4.jdflib.core.VString;
   using JDFDevice = org.cip4.jdflib.resource.JDFDevice;

   public abstract class JDFAutoIDInfo : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[7];
      static JDFAutoIDInfo()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.CATEGORY, 0x33333311, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.JOBID, 0x33333311, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.JOBPARTID, 0x33333311, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.PARENTJOBID, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.PARENTJOBPARTID, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.TYPE, 0x33333311, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.TYPES, 0x33333311, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.DEVICE, 0x66666611);
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
      ///     <summary> * Constructor for JDFAutoIDInfo </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoIDInfo(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoIDInfo </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoIDInfo(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoIDInfo </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoIDInfo(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoIDInfo[  --> " + base.ToString() + " ]";
      }


      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute Category
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Category </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCategory(string @value)
      {
         setAttribute(AttributeName.CATEGORY, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Category </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getCategory()
      {
         return getAttribute(AttributeName.CATEGORY, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute JobID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute JobID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setJobID(string @value)
      {
         setAttribute(AttributeName.JOBID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute JobID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getJobID()
      {
         return getAttribute(AttributeName.JOBID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute JobPartID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute JobPartID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setJobPartID(string @value)
      {
         setAttribute(AttributeName.JOBPARTID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute JobPartID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getJobPartID()
      {
         return getAttribute(AttributeName.JOBPARTID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ParentJobID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ParentJobID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setParentJobID(string @value)
      {
         setAttribute(AttributeName.PARENTJOBID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ParentJobID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getParentJobID()
      {
         return getAttribute(AttributeName.PARENTJOBID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ParentJobPartID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ParentJobPartID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setParentJobPartID(string @value)
      {
         setAttribute(AttributeName.PARENTJOBPARTID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ParentJobPartID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getParentJobPartID()
      {
         return getAttribute(AttributeName.PARENTJOBPARTID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Type
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Type </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setType(string @value)
      {
         setAttribute(AttributeName.TYPE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Type </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getType()
      {
         return getAttribute(AttributeName.TYPE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Types
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Types </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTypes(VString @value)
      {
         setAttribute(AttributeName.TYPES, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute Types </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getTypes()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.TYPES, null, JDFConstants.EMPTYSTRING);
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element Device </summary>
      ///     * <returns> JDFDevice the element </returns>
      ///     
      public virtual JDFDevice getDevice()
      {
         return (JDFDevice)getElement(ElementName.DEVICE, null, 0);
      }

      ///     <summary> (25) getCreateDevice
      ///     *  </summary>
      ///     * <returns> JDFDevice the element </returns>
      ///     
      public virtual JDFDevice getCreateDevice()
      {
         return (JDFDevice)getCreateElement_KElement(ElementName.DEVICE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Device </summary>
      ///     
      public virtual JDFDevice appendDevice()
      {
         return (JDFDevice)appendElementN(ElementName.DEVICE, 1, null);
      }
   }
}
