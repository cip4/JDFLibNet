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
   using JDFCollatingItem = org.cip4.jdflib.resource.process.JDFCollatingItem;
   using JDFFeeder = org.cip4.jdflib.resource.process.JDFFeeder;

   public abstract class JDFAutoFeedingParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[2];
      static JDFAutoFeedingParams()
      {
         elemInfoTable[0] = new ElemInfoTable(ElementName.FEEDER, 0x33333311);
         elemInfoTable[1] = new ElemInfoTable(ElementName.COLLATINGITEM, 0x33333311);
      }

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoFeedingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoFeedingParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoFeedingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoFeedingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoFeedingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoFeedingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoFeedingParams[  --> " + base.ToString() + " ]";
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

      ///     <summary> (26) getCreateFeeder
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFFeeder the element </returns>
      ///     
      public virtual JDFFeeder getCreateFeeder(int iSkip)
      {
         return (JDFFeeder)getCreateElement_KElement(ElementName.FEEDER, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Feeder </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFFeeder the element </returns>
      ///     * default is getFeeder(0)     
      public virtual JDFFeeder getFeeder(int iSkip)
      {
         return (JDFFeeder)getElement(ElementName.FEEDER, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Feeder from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFFeeder> </returns>
      ///     
      public virtual ICollection<JDFFeeder> getAllFeeder()
      {
         List<JDFFeeder> v = new List<JDFFeeder>();

         JDFFeeder kElem = (JDFFeeder)getFirstChildElement(ElementName.FEEDER, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFFeeder)kElem.getNextSiblingElement(ElementName.FEEDER, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Feeder </summary>
      ///     
      public virtual JDFFeeder appendFeeder()
      {
         return (JDFFeeder)appendElement(ElementName.FEEDER, null);
      }

      ///     <summary> (26) getCreateCollatingItem
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFCollatingItem the element </returns>
      ///     
      public virtual JDFCollatingItem getCreateCollatingItem(int iSkip)
      {
         return (JDFCollatingItem)getCreateElement_KElement(ElementName.COLLATINGITEM, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element CollatingItem </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFCollatingItem the element </returns>
      ///     * default is getCollatingItem(0)     
      public virtual JDFCollatingItem getCollatingItem(int iSkip)
      {
         return (JDFCollatingItem)getElement(ElementName.COLLATINGITEM, null, iSkip);
      }

      ///    
      ///     <summary> * Get all CollatingItem from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFCollatingItem> </returns>
      ///     
      public virtual ICollection<JDFCollatingItem> getAllCollatingItem()
      {
         List<JDFCollatingItem> v = new List<JDFCollatingItem>();

         JDFCollatingItem kElem = (JDFCollatingItem)getFirstChildElement(ElementName.COLLATINGITEM, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFCollatingItem)kElem.getNextSiblingElement(ElementName.COLLATINGITEM, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element CollatingItem </summary>
      ///     
      public virtual JDFCollatingItem appendCollatingItem()
      {
         return (JDFCollatingItem)appendElement(ElementName.COLLATINGITEM, null);
      }
   }
}
