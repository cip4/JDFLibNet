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
   using JDFPartStatus = org.cip4.jdflib.core.JDFPartStatus;
   using JDFPool = org.cip4.jdflib.pool.JDFPool;

   public abstract class JDFAutoStatusPool : JDFPool
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[2];
      static JDFAutoStatusPool()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.STATUS, 0x44444333, AttributeInfo.EnumAttributeType.enumeration, EnumNodeStatus.getEnum(0), null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.STATUSDETAILS, 0x44444311, AttributeInfo.EnumAttributeType.shortString, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.PARTSTATUS, 0x44444333);
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
      ///     <summary> * Constructor for JDFAutoStatusPool </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoStatusPool(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoStatusPool </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoStatusPool(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoStatusPool </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoStatusPool(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoStatusPool[  --> " + base.ToString() + " ]";
      }


      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute StatusDetails
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute StatusDetails </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setStatusDetails(string @value)
      {
         setAttribute(AttributeName.STATUSDETAILS, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute StatusDetails </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getStatusDetails()
      {
         return getAttribute(AttributeName.STATUSDETAILS, null, JDFConstants.EMPTYSTRING);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreatePartStatus
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFPartStatus the element </returns>
      ///     
      public virtual JDFPartStatus getCreatePartStatus(int iSkip)
      {
         return (JDFPartStatus)getCreateElement_KElement(ElementName.PARTSTATUS, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element PartStatus </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFPartStatus the element </returns>
      ///     * default is getPartStatus(0)     
      public virtual JDFPartStatus getPartStatus(int iSkip)
      {
         return (JDFPartStatus)getElement(ElementName.PARTSTATUS, null, iSkip);
      }

      ///    
      ///     <summary> * Get all PartStatus from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFPartStatus> </returns>
      ///     
      public virtual ICollection<JDFPartStatus> getAllPartStatus()
      {
         List<JDFPartStatus> v = new List<JDFPartStatus>();

         JDFPartStatus kElem = (JDFPartStatus)getFirstChildElement(ElementName.PARTSTATUS, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFPartStatus)kElem.getNextSiblingElement(ElementName.PARTSTATUS, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element PartStatus </summary>
      ///     
      public virtual JDFPartStatus appendPartStatus()
      {
         return (JDFPartStatus)appendElement(ElementName.PARTSTATUS, null);
      }
   }
}
