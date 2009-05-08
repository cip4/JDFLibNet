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
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFCreateLink = org.cip4.jdflib.jmf.JDFCreateLink;
   using JDFCreateResource = org.cip4.jdflib.jmf.JDFCreateResource;
   using JDFMoveResource = org.cip4.jdflib.jmf.JDFMoveResource;
   using JDFRemoveLink = org.cip4.jdflib.jmf.JDFRemoveLink;

   public abstract class JDFAutoUpdateJDFCmdParams : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[4];
      static JDFAutoUpdateJDFCmdParams()
      {
         elemInfoTable[0] = new ElemInfoTable(ElementName.CREATELINK, 0x33333333);
         elemInfoTable[1] = new ElemInfoTable(ElementName.CREATERESOURCE, 0x33333333);
         elemInfoTable[2] = new ElemInfoTable(ElementName.MOVERESOURCE, 0x33333333);
         elemInfoTable[3] = new ElemInfoTable(ElementName.REMOVELINK, 0x33333333);
      }

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoUpdateJDFCmdParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoUpdateJDFCmdParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoUpdateJDFCmdParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoUpdateJDFCmdParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoUpdateJDFCmdParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoUpdateJDFCmdParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoUpdateJDFCmdParams[  --> " + base.ToString() + " ]";
      }


      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateCreateLink
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFCreateLink the element </returns>
      ///     
      public virtual JDFCreateLink getCreateCreateLink(int iSkip)
      {
         return (JDFCreateLink)getCreateElement_KElement(ElementName.CREATELINK, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element CreateLink </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFCreateLink the element </returns>
      ///     * default is getCreateLink(0)     
      public virtual JDFCreateLink getCreateLink(int iSkip)
      {
         return (JDFCreateLink)getElement(ElementName.CREATELINK, null, iSkip);
      }

      ///    
      ///     <summary> * Get all CreateLink from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFCreateLink> </returns>
      ///     
      public virtual ICollection<JDFCreateLink> getAllCreateLink()
      {
         List<JDFCreateLink> v = new List<JDFCreateLink>();

         JDFCreateLink kElem = (JDFCreateLink)getFirstChildElement(ElementName.CREATELINK, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFCreateLink)kElem.getNextSiblingElement(ElementName.CREATELINK, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element CreateLink </summary>
      ///     
      public virtual JDFCreateLink appendCreateLink()
      {
         return (JDFCreateLink)appendElement(ElementName.CREATELINK, null);
      }

      ///     <summary> (26) getCreateCreateResource
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFCreateResource the element </returns>
      ///     
      public virtual JDFCreateResource getCreateCreateResource(int iSkip)
      {
         return (JDFCreateResource)getCreateElement_KElement(ElementName.CREATERESOURCE, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element CreateResource </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFCreateResource the element </returns>
      ///     * default is getCreateResource(0)     
      public virtual JDFCreateResource getCreateResource(int iSkip)
      {
         return (JDFCreateResource)getElement(ElementName.CREATERESOURCE, null, iSkip);
      }

      ///    
      ///     <summary> * Get all CreateResource from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFCreateResource> </returns>
      ///     
      public virtual ICollection<JDFCreateResource> getAllCreateResource()
      {
         List<JDFCreateResource> v = new List<JDFCreateResource>();

         JDFCreateResource kElem = (JDFCreateResource)getFirstChildElement(ElementName.CREATERESOURCE, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFCreateResource)kElem.getNextSiblingElement(ElementName.CREATERESOURCE, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element CreateResource </summary>
      ///     
      public virtual JDFCreateResource appendCreateResource()
      {
         return (JDFCreateResource)appendElement(ElementName.CREATERESOURCE, null);
      }

      ///     <summary> (26) getCreateMoveResource
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFMoveResource the element </returns>
      ///     
      public virtual JDFMoveResource getCreateMoveResource(int iSkip)
      {
         return (JDFMoveResource)getCreateElement_KElement(ElementName.MOVERESOURCE, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element MoveResource </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFMoveResource the element </returns>
      ///     * default is getMoveResource(0)     
      public virtual JDFMoveResource getMoveResource(int iSkip)
      {
         return (JDFMoveResource)getElement(ElementName.MOVERESOURCE, null, iSkip);
      }

      ///    
      ///     <summary> * Get all MoveResource from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFMoveResource> </returns>
      ///     
      public virtual ICollection<JDFMoveResource> getAllMoveResource()
      {
         List<JDFMoveResource> v = new List<JDFMoveResource>();

         JDFMoveResource kElem = (JDFMoveResource)getFirstChildElement(ElementName.MOVERESOURCE, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFMoveResource)kElem.getNextSiblingElement(ElementName.MOVERESOURCE, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element MoveResource </summary>
      ///     
      public virtual JDFMoveResource appendMoveResource()
      {
         return (JDFMoveResource)appendElement(ElementName.MOVERESOURCE, null);
      }

      ///     <summary> (26) getCreateRemoveLink
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFRemoveLink the element </returns>
      ///     
      public virtual JDFRemoveLink getCreateRemoveLink(int iSkip)
      {
         return (JDFRemoveLink)getCreateElement_KElement(ElementName.REMOVELINK, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element RemoveLink </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFRemoveLink the element </returns>
      ///     * default is getRemoveLink(0)     
      public virtual JDFRemoveLink getRemoveLink(int iSkip)
      {
         return (JDFRemoveLink)getElement(ElementName.REMOVELINK, null, iSkip);
      }

      ///    
      ///     <summary> * Get all RemoveLink from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFRemoveLink> </returns>
      ///     
      public virtual ICollection<JDFRemoveLink> getAllRemoveLink()
      {
         List<JDFRemoveLink> v = new List<JDFRemoveLink>();

         JDFRemoveLink kElem = (JDFRemoveLink)getFirstChildElement(ElementName.REMOVELINK, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFRemoveLink)kElem.getNextSiblingElement(ElementName.REMOVELINK, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element RemoveLink </summary>
      ///     
      public virtual JDFRemoveLink appendRemoveLink()
      {
         return (JDFRemoveLink)appendElement(ElementName.REMOVELINK, null);
      }
   }
}
