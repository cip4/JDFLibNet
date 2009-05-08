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


   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFIntentResource = org.cip4.jdflib.resource.intent.JDFIntentResource;
   using JDFIntegerSpan = org.cip4.jdflib.span.JDFIntegerSpan;
   using JDFNameSpan = org.cip4.jdflib.span.JDFNameSpan;
   using JDFStringSpan = org.cip4.jdflib.span.JDFStringSpan;
   using JDFTimeSpan = org.cip4.jdflib.span.JDFTimeSpan;

   public abstract class JDFAutoPublishingIntent : JDFIntentResource
   {

      private new const long serialVersionUID = 1L;

      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[4];
      static JDFAutoPublishingIntent()
      {
         elemInfoTable[0] = new ElemInfoTable(ElementName.ISSUEDATE, 0x55555111);
         elemInfoTable[1] = new ElemInfoTable(ElementName.ISSUENAME, 0x55555111);
         elemInfoTable[2] = new ElemInfoTable(ElementName.ISSUETYPE, 0x55555111);
         elemInfoTable[3] = new ElemInfoTable(ElementName.CIRCULATION, 0x66666111);
      }

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoPublishingIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPublishingIntent(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPublishingIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPublishingIntent(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPublishingIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoPublishingIntent(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoPublishingIntent[  --> " + base.ToString() + " ]";
      }


      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element IssueDate </summary>
      ///     * <returns> JDFTimeSpan the element </returns>
      ///     
      public virtual JDFTimeSpan getIssueDate()
      {
         return (JDFTimeSpan)getElement(ElementName.ISSUEDATE, null, 0);
      }

      ///     <summary> (25) getCreateIssueDate
      ///     *  </summary>
      ///     * <returns> JDFTimeSpan the element </returns>
      ///     
      public virtual JDFTimeSpan getCreateIssueDate()
      {
         return (JDFTimeSpan)getCreateElement_KElement(ElementName.ISSUEDATE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element IssueDate </summary>
      ///     
      public virtual JDFTimeSpan appendIssueDate()
      {
         return (JDFTimeSpan)appendElementN(ElementName.ISSUEDATE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element IssueName </summary>
      ///     * <returns> JDFStringSpan the element </returns>
      ///     
      public virtual JDFStringSpan getIssueName()
      {
         return (JDFStringSpan)getElement(ElementName.ISSUENAME, null, 0);
      }

      ///     <summary> (25) getCreateIssueName
      ///     *  </summary>
      ///     * <returns> JDFStringSpan the element </returns>
      ///     
      public virtual JDFStringSpan getCreateIssueName()
      {
         return (JDFStringSpan)getCreateElement_KElement(ElementName.ISSUENAME, null, 0);
      }

      ///    
      ///     <summary> * (29) append element IssueName </summary>
      ///     
      public virtual JDFStringSpan appendIssueName()
      {
         return (JDFStringSpan)appendElementN(ElementName.ISSUENAME, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element IssueType </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getIssueType()
      {
         return (JDFNameSpan)getElement(ElementName.ISSUETYPE, null, 0);
      }

      ///     <summary> (25) getCreateIssueType
      ///     *  </summary>
      ///     * <returns> JDFNameSpan the element </returns>
      ///     
      public virtual JDFNameSpan getCreateIssueType()
      {
         return (JDFNameSpan)getCreateElement_KElement(ElementName.ISSUETYPE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element IssueType </summary>
      ///     
      public virtual JDFNameSpan appendIssueType()
      {
         return (JDFNameSpan)appendElementN(ElementName.ISSUETYPE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element Circulation </summary>
      ///     * <returns> JDFIntegerSpan the element </returns>
      ///     
      public virtual JDFIntegerSpan getCirculation()
      {
         return (JDFIntegerSpan)getElement(ElementName.CIRCULATION, null, 0);
      }

      ///     <summary> (25) getCreateCirculation
      ///     *  </summary>
      ///     * <returns> JDFIntegerSpan the element </returns>
      ///     
      public virtual JDFIntegerSpan getCreateCirculation()
      {
         return (JDFIntegerSpan)getCreateElement_KElement(ElementName.CIRCULATION, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Circulation </summary>
      ///     
      public virtual JDFIntegerSpan appendCirculation()
      {
         return (JDFIntegerSpan)appendElementN(ElementName.CIRCULATION, 1, null);
      }
   }
}
