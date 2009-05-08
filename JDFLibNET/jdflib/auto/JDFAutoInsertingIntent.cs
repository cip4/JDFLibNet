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
   using JDFInsertList = org.cip4.jdflib.resource.JDFInsertList;
   using JDFIntentResource = org.cip4.jdflib.resource.intent.JDFIntentResource;
   using JDFSpanGlueType = org.cip4.jdflib.span.JDFSpanGlueType;
   using JDFSpanMethod = org.cip4.jdflib.span.JDFSpanMethod;

   public abstract class JDFAutoInsertingIntent : JDFIntentResource
   {

      private new const long serialVersionUID = 1L;

      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[3];
      static JDFAutoInsertingIntent()
      {
         elemInfoTable[0] = new ElemInfoTable(ElementName.GLUETYPE, 0x66666666);
         elemInfoTable[1] = new ElemInfoTable(ElementName.INSERTLIST, 0x55555555);
         elemInfoTable[2] = new ElemInfoTable(ElementName.METHOD, 0x66666666);
      }

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoInsertingIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoInsertingIntent(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoInsertingIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoInsertingIntent(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoInsertingIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoInsertingIntent(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoInsertingIntent[  --> " + base.ToString() + " ]";
      }


      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element GlueType </summary>
      ///     * <returns> JDFSpanGlueType the element </returns>
      ///     
      public virtual JDFSpanGlueType getGlueType()
      {
         return (JDFSpanGlueType)getElement(ElementName.GLUETYPE, null, 0);
      }

      ///     <summary> (25) getCreateGlueType
      ///     *  </summary>
      ///     * <returns> JDFSpanGlueType the element </returns>
      ///     
      public virtual JDFSpanGlueType getCreateGlueType()
      {
         return (JDFSpanGlueType)getCreateElement_KElement(ElementName.GLUETYPE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element GlueType </summary>
      ///     
      public virtual JDFSpanGlueType appendGlueType()
      {
         return (JDFSpanGlueType)appendElementN(ElementName.GLUETYPE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element InsertList </summary>
      ///     * <returns> JDFInsertList the element </returns>
      ///     
      public virtual JDFInsertList getInsertList()
      {
         return (JDFInsertList)getElement(ElementName.INSERTLIST, null, 0);
      }

      ///     <summary> (25) getCreateInsertList
      ///     *  </summary>
      ///     * <returns> JDFInsertList the element </returns>
      ///     
      public virtual JDFInsertList getCreateInsertList()
      {
         return (JDFInsertList)getCreateElement_KElement(ElementName.INSERTLIST, null, 0);
      }

      ///    
      ///     <summary> * (29) append element InsertList </summary>
      ///     
      public virtual JDFInsertList appendInsertList()
      {
         return (JDFInsertList)appendElementN(ElementName.INSERTLIST, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element Method </summary>
      ///     * <returns> JDFSpanMethod the element </returns>
      ///     
      public virtual JDFSpanMethod getMethod()
      {
         return (JDFSpanMethod)getElement(ElementName.METHOD, null, 0);
      }

      ///     <summary> (25) getCreateMethod
      ///     *  </summary>
      ///     * <returns> JDFSpanMethod the element </returns>
      ///     
      public virtual JDFSpanMethod getCreateMethod()
      {
         return (JDFSpanMethod)getCreateElement_KElement(ElementName.METHOD, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Method </summary>
      ///     
      public virtual JDFSpanMethod appendMethod()
      {
         return (JDFSpanMethod)appendElementN(ElementName.METHOD, 1, null);
      }
   }
}
