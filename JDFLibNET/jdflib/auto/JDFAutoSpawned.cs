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
   using JDFAudit = org.cip4.jdflib.core.JDFAudit;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using VString = org.cip4.jdflib.core.VString;
   using JDFPart = org.cip4.jdflib.resource.JDFPart;

   public abstract class JDFAutoSpawned : JDFAudit
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[8];
      static JDFAutoSpawned()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.INDEPENDENT, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.JREF, 0x22222222, AttributeInfo.EnumAttributeType.IDREF, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.JREFDESTINATION, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.NEWSPAWNID, 0x22222221, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.RREFSROCOPIED, 0x33333333, AttributeInfo.EnumAttributeType.IDREFS, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.RREFSRWCOPIED, 0x33333333, AttributeInfo.EnumAttributeType.IDREFS, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.STATUS, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumNodeStatus.getEnum(0), null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.URL, 0x33333331, AttributeInfo.EnumAttributeType.URL, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.PART, 0x33333333);
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
      ///     <summary> * Constructor for JDFAutoSpawned </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoSpawned(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoSpawned </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoSpawned(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoSpawned </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoSpawned(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoSpawned[  --> " + base.ToString() + " ]";
      }


      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute Independent
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Independent </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setIndependent(bool @value)
      {
         setAttribute(AttributeName.INDEPENDENT, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute Independent </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getIndependent()
      {
         return getBoolAttribute(AttributeName.INDEPENDENT, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute jRef
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute jRef </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setjRef(string @value)
      {
         setAttribute(AttributeName.JREF, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute jRef </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getjRef()
      {
         return getAttribute(AttributeName.JREF, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute jRefDestination
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute jRefDestination </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setjRefDestination(string @value)
      {
         setAttribute(AttributeName.JREFDESTINATION, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute jRefDestination </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getjRefDestination()
      {
         return getAttribute(AttributeName.JREFDESTINATION, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute NewSpawnID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute NewSpawnID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setNewSpawnID(string @value)
      {
         setAttribute(AttributeName.NEWSPAWNID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute NewSpawnID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getNewSpawnID()
      {
         return getAttribute(AttributeName.NEWSPAWNID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute rRefsROCopied
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute rRefsROCopied </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setrRefsROCopied(VString @value)
      {
         setAttribute(AttributeName.RREFSROCOPIED, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute rRefsROCopied </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getrRefsROCopied()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.RREFSROCOPIED, null, JDFConstants.EMPTYSTRING);
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute rRefsRWCopied
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute rRefsRWCopied </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setrRefsRWCopied(VString @value)
      {
         setAttribute(AttributeName.RREFSRWCOPIED, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute rRefsRWCopied </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getrRefsRWCopied()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.RREFSRWCOPIED, null, JDFConstants.EMPTYSTRING);
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute URL
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute URL </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setURL(string @value)
      {
         setAttribute(AttributeName.URL, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute URL </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getURL()
      {
         return getAttribute(AttributeName.URL, null, JDFConstants.EMPTYSTRING);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreatePart
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFPart the element </returns>
      ///     
      public virtual JDFPart getCreatePart(int iSkip)
      {
         return (JDFPart)getCreateElement_KElement(ElementName.PART, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Part </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFPart the element </returns>
      ///     * default is getPart(0)     
      public virtual JDFPart getPart(int iSkip)
      {
         return (JDFPart)getElement(ElementName.PART, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Part from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFPart> </returns>
      ///     
      public virtual ICollection<JDFPart> getAllPart()
      {
         List<JDFPart> v = new List<JDFPart>();

         JDFPart kElem = (JDFPart)getFirstChildElement(ElementName.PART, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFPart)kElem.getNextSiblingElement(ElementName.PART, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Part </summary>
      ///     
      public virtual JDFPart appendPart()
      {
         return (JDFPart)appendElement(ElementName.PART, null);
      }
   }
}
