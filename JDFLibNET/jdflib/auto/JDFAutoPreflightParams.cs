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



   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFActionPool = org.cip4.jdflib.resource.devicecapability.JDFActionPool;
   using JDFTestPool = org.cip4.jdflib.resource.devicecapability.JDFTestPool;

   public abstract class JDFAutoPreflightParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[2];
      static JDFAutoPreflightParams()
      {
         elemInfoTable[0] = new ElemInfoTable(ElementName.ACTIONPOOL, 0x22222211);
         elemInfoTable[1] = new ElemInfoTable(ElementName.TESTPOOL, 0x55555111);
      }

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoPreflightParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPreflightParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPreflightParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPreflightParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPreflightParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoPreflightParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoPreflightParams[  --> " + base.ToString() + " ]";
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


      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateActionPool
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFActionPool the element </returns>
      ///     
      public virtual JDFActionPool getCreateActionPool(int iSkip)
      {
         return (JDFActionPool)getCreateElement_KElement(ElementName.ACTIONPOOL, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element ActionPool </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFActionPool the element </returns>
      ///     * default is getActionPool(0)     
      public virtual JDFActionPool getActionPool(int iSkip)
      {
         return (JDFActionPool)getElement(ElementName.ACTIONPOOL, null, iSkip);
      }

      ///    
      ///     <summary> * Get all ActionPool from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFActionPool> </returns>
      ///     
      public virtual ICollection<JDFActionPool> getAllActionPool()
      {
         List<JDFActionPool> v = new List<JDFActionPool>();

         JDFActionPool kElem = (JDFActionPool)getFirstChildElement(ElementName.ACTIONPOOL, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFActionPool)kElem.getNextSiblingElement(ElementName.ACTIONPOOL, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element ActionPool </summary>
      ///     
      public virtual JDFActionPool appendActionPool()
      {
         return (JDFActionPool)appendElement(ElementName.ACTIONPOOL, null);
      }

      ///    
      ///     <summary> * (24) const get element TestPool </summary>
      ///     * <returns> JDFTestPool the element </returns>
      ///     
      public virtual JDFTestPool getTestPool()
      {
         return (JDFTestPool)getElement(ElementName.TESTPOOL, null, 0);
      }

      ///     <summary> (25) getCreateTestPool
      ///     *  </summary>
      ///     * <returns> JDFTestPool the element </returns>
      ///     
      public virtual JDFTestPool getCreateTestPool()
      {
         return (JDFTestPool)getCreateElement_KElement(ElementName.TESTPOOL, null, 0);
      }

      ///    
      ///     <summary> * (29) append element TestPool </summary>
      ///     
      public virtual JDFTestPool appendTestPool()
      {
         return (JDFTestPool)appendElementN(ElementName.TESTPOOL, 1, null);
      }
   }
}
