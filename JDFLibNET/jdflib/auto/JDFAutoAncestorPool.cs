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


  
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFAncestor = org.cip4.jdflib.node.JDFAncestor;
   using JDFPool = org.cip4.jdflib.pool.JDFPool;
   using JDFPart = org.cip4.jdflib.resource.JDFPart;

   public abstract class JDFAutoAncestorPool : JDFPool
   {

      private new const long serialVersionUID = 1L;

       private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[2];
       static JDFAutoAncestorPool()
       {
           elemInfoTable[0] = new ElemInfoTable(ElementName.ANCESTOR, 0x22222222);
           elemInfoTable[1] = new ElemInfoTable(ElementName.PART, 0x33333331);
       }

       protected internal override ElementInfo getTheElementInfo()
       {
           return base.getTheElementInfo().updateReplace(elemInfoTable);
       }



///    
///     <summary> * Constructor for JDFAutoAncestorPool </summary>
///     * <param name="myOwnerDocument"> </param>
///     * <param name="qualifiedName"> </param>
///     
       protected internal JDFAutoAncestorPool(CoreDocumentImpl myOwnerDocument, string qualifiedName) : base(myOwnerDocument, qualifiedName)
       {
       }

///    
///     <summary> * Constructor for JDFAutoAncestorPool </summary>
///     * <param name="myOwnerDocument"> </param>
///     * <param name="myNamespaceURI"> </param>
///     * <param name="qualifiedName"> </param>
///     
       protected internal JDFAutoAncestorPool(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName) : base(myOwnerDocument, myNamespaceURI, qualifiedName)
       {
       }

///    
///     <summary> * Constructor for JDFAutoAncestorPool </summary>
///     * <param name="myOwnerDocument"> </param>
///     * <param name="myNamespaceURI"> </param>
///     * <param name="qualifiedName"> </param>
///     * <param name="myLocalName"> </param>
///     
       protected internal JDFAutoAncestorPool(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName) : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
       {
       }


       /// <summary>
       /// String representation of this object
       /// </summary>
       /// <returns>string</returns>
       public override string ToString()
       {
           return " JDFAutoAncestorPool[  --> " + base.ToString() + " ]";
       }


// ***********************************************************************
// * Element getter / setter
// * ***********************************************************************
// 

///     <summary> (26) getCreateAncestor
///     *  </summary>
///     * <param name="iSkip"> number of elements to skip </param>
///     * <returns> JDFAncestor the element </returns>
///     
       public virtual JDFAncestor getCreateAncestor(int iSkip)
       {
           return (JDFAncestor)getCreateElement_KElement(ElementName.ANCESTOR, null, iSkip);
       }

///    
///     <summary> * (27) const get element Ancestor </summary>
///     * <param name="iSkip"> number of elements to skip </param>
///     * <returns> JDFAncestor the element </returns>
///     * default is getAncestor(0)     
       public virtual JDFAncestor getAncestor(int iSkip)
       {
           return (JDFAncestor) getElement(ElementName.ANCESTOR, null, iSkip);
       }

///    
///     <summary> * Get all Ancestor from the current element
///     *  </summary>
///     * <returns> Collection<JDFAncestor> </returns>
///     
       public virtual ICollection<JDFAncestor> getAllAncestor()
       {
           List<JDFAncestor> v = new List<JDFAncestor>();

           JDFAncestor kElem = (JDFAncestor) getFirstChildElement(ElementName.ANCESTOR, null);

           while (kElem != null)
           {
               v.Add(kElem);

               kElem = (JDFAncestor) kElem.getNextSiblingElement(ElementName.ANCESTOR, null);
           }

           return v;
       }

///    
///     <summary> * (30) append element Ancestor </summary>
///     
       public virtual JDFAncestor appendAncestor()
       {
           return (JDFAncestor) appendElement(ElementName.ANCESTOR, null);
       }

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
           return (JDFPart) getElement(ElementName.PART, null, iSkip);
       }

///    
///     <summary> * Get all Part from the current element
///     *  </summary>
///     * <returns> Collection<JDFPart> </returns>
///     
       public virtual ICollection<JDFPart> getAllPart()
       {
           List<JDFPart> v = new List<JDFPart>();

           JDFPart kElem = (JDFPart) getFirstChildElement(ElementName.PART, null);

           while (kElem != null)
           {
               v.Add(kElem);

               kElem = (JDFPart) kElem.getNextSiblingElement(ElementName.PART, null);
           }

           return v;
       }

///    
///     <summary> * (30) append element Part </summary>
///     
       public virtual JDFPart appendPart()
       {
           return (JDFPart) appendElement(ElementName.PART, null);
       }

   }

}
