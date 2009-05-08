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
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;

   public abstract class JDFAutoPreflightAnalysis : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[6];
      static JDFAutoPreflightAnalysis()
      {
         elemInfoTable[0] = new ElemInfoTable(ElementName.COLORSRESULTSPOOL, 0x77777766);
         elemInfoTable[1] = new ElemInfoTable(ElementName.DOCUMENTRESULTSPOOL, 0x77777766);
         elemInfoTable[2] = new ElemInfoTable(ElementName.FONTSRESULTSPOOL, 0x77777766);
         elemInfoTable[3] = new ElemInfoTable(ElementName.FILETYPERESULTSPOOL, 0x77777766);
         elemInfoTable[4] = new ElemInfoTable(ElementName.IMAGESRESULTSPOOL, 0x77777766);
         elemInfoTable[5] = new ElemInfoTable(ElementName.PAGESRESULTSPOOL, 0x77777766);
      }

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoPreflightAnalysis </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPreflightAnalysis(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPreflightAnalysis </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPreflightAnalysis(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPreflightAnalysis </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoPreflightAnalysis(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoPreflightAnalysis[  --> " + base.ToString() + " ]";
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

      ///    
      ///     <summary> * (24) const get element ColorsResultsPool </summary>
      ///     * <returns> JDFElement the element </returns>
      ///     
      public virtual JDFElement getColorsResultsPool()
      {
         return (JDFElement)getElement(ElementName.COLORSRESULTSPOOL, null, 0);
      }

      ///     <summary> (25) getCreateColorsResultsPool
      ///     *  </summary>
      ///     * <returns> JDFElement the element </returns>
      ///     
      public virtual JDFElement getCreateColorsResultsPool()
      {
         return (JDFElement)getCreateElement_KElement(ElementName.COLORSRESULTSPOOL, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ColorsResultsPool </summary>
      ///     
      public virtual JDFElement appendColorsResultsPool()
      {
         return (JDFElement)appendElementN(ElementName.COLORSRESULTSPOOL, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element DocumentResultsPool </summary>
      ///     * <returns> JDFElement the element </returns>
      ///     
      public virtual JDFElement getDocumentResultsPool()
      {
         return (JDFElement)getElement(ElementName.DOCUMENTRESULTSPOOL, null, 0);
      }

      ///     <summary> (25) getCreateDocumentResultsPool
      ///     *  </summary>
      ///     * <returns> JDFElement the element </returns>
      ///     
      public virtual JDFElement getCreateDocumentResultsPool()
      {
         return (JDFElement)getCreateElement_KElement(ElementName.DOCUMENTRESULTSPOOL, null, 0);
      }

      ///    
      ///     <summary> * (29) append element DocumentResultsPool </summary>
      ///     
      public virtual JDFElement appendDocumentResultsPool()
      {
         return (JDFElement)appendElementN(ElementName.DOCUMENTRESULTSPOOL, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element FontsResultsPool </summary>
      ///     * <returns> JDFElement the element </returns>
      ///     
      public virtual JDFElement getFontsResultsPool()
      {
         return (JDFElement)getElement(ElementName.FONTSRESULTSPOOL, null, 0);
      }

      ///     <summary> (25) getCreateFontsResultsPool
      ///     *  </summary>
      ///     * <returns> JDFElement the element </returns>
      ///     
      public virtual JDFElement getCreateFontsResultsPool()
      {
         return (JDFElement)getCreateElement_KElement(ElementName.FONTSRESULTSPOOL, null, 0);
      }

      ///    
      ///     <summary> * (29) append element FontsResultsPool </summary>
      ///     
      public virtual JDFElement appendFontsResultsPool()
      {
         return (JDFElement)appendElementN(ElementName.FONTSRESULTSPOOL, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element FileTypeResultsPool </summary>
      ///     * <returns> JDFElement the element </returns>
      ///     
      public virtual JDFElement getFileTypeResultsPool()
      {
         return (JDFElement)getElement(ElementName.FILETYPERESULTSPOOL, null, 0);
      }

      ///     <summary> (25) getCreateFileTypeResultsPool
      ///     *  </summary>
      ///     * <returns> JDFElement the element </returns>
      ///     
      public virtual JDFElement getCreateFileTypeResultsPool()
      {
         return (JDFElement)getCreateElement_KElement(ElementName.FILETYPERESULTSPOOL, null, 0);
      }

      ///    
      ///     <summary> * (29) append element FileTypeResultsPool </summary>
      ///     
      public virtual JDFElement appendFileTypeResultsPool()
      {
         return (JDFElement)appendElementN(ElementName.FILETYPERESULTSPOOL, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element ImagesResultsPool </summary>
      ///     * <returns> JDFElement the element </returns>
      ///     
      public virtual JDFElement getImagesResultsPool()
      {
         return (JDFElement)getElement(ElementName.IMAGESRESULTSPOOL, null, 0);
      }

      ///     <summary> (25) getCreateImagesResultsPool
      ///     *  </summary>
      ///     * <returns> JDFElement the element </returns>
      ///     
      public virtual JDFElement getCreateImagesResultsPool()
      {
         return (JDFElement)getCreateElement_KElement(ElementName.IMAGESRESULTSPOOL, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ImagesResultsPool </summary>
      ///     
      public virtual JDFElement appendImagesResultsPool()
      {
         return (JDFElement)appendElementN(ElementName.IMAGESRESULTSPOOL, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element PagesResultsPool </summary>
      ///     * <returns> JDFElement the element </returns>
      ///     
      public virtual JDFElement getPagesResultsPool()
      {
         return (JDFElement)getElement(ElementName.PAGESRESULTSPOOL, null, 0);
      }

      ///     <summary> (25) getCreatePagesResultsPool
      ///     *  </summary>
      ///     * <returns> JDFElement the element </returns>
      ///     
      public virtual JDFElement getCreatePagesResultsPool()
      {
         return (JDFElement)getCreateElement_KElement(ElementName.PAGESRESULTSPOOL, null, 0);
      }

      ///    
      ///     <summary> * (29) append element PagesResultsPool </summary>
      ///     
      public virtual JDFElement appendPagesResultsPool()
      {
         return (JDFElement)appendElementN(ElementName.PAGESRESULTSPOOL, 1, null);
      }
   }
}
