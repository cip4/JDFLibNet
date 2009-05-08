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



/*  class JDFAssetListCreationParams extends JDFAutoAssetListCreationParams
 *  
 *  @COPYRIGHT Heidelberger Druckmaschinen AG, 2006. ALL RIGHTS RESERVED. 
 */



namespace org.cip4.jdflib.resource.process.prepress
{


   using JDFAutoAssetListCreationParams = org.cip4.jdflib.auto.JDFAutoAssetListCreationParams;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using JDFFileSpec = org.cip4.jdflib.resource.process.JDFFileSpec;

   public class JDFAssetListCreationParams : JDFAutoAssetListCreationParams
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * ructor for JDFAssetListCreationParams
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFAssetListCreationParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * ructor for JDFAssetListCreationParams
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFAssetListCreationParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * ructor for JDFAssetListCreationParams
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="localName"> </param>
      ///	 
      public JDFAssetListCreationParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      // **************************************** Methods
      // *********************************************
      ///   
      ///	 <summary> * toString
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public override string ToString()
      {
         return "JDFAssetListCreationParams[  --> " + base.ToString() + " ]";
      }

      public virtual JDFFileSpec getSearchPath(int iSkip)
      {
         int iSkipLocal = iSkip;

         JDFFileSpec res = null;
         VElement v = getChildElementVector(ElementName.FILESPEC, null, null, true, 0, false);
         int siz = v.Count;

         for (int i = 0; i < siz; i++)
         {
            res = (JDFFileSpec)v[i];
            if (res.hasAttribute(AttributeName.RESOURCEUSAGE))
            {
               if (res.getResourceUsage() == "SearchPath")
               {
                  if (iSkipLocal >= 0)
                  {
                     iSkipLocal--;
                  }
                  else
                  {
                     break;
                  }
               }
            }
         }

         return res;
      }

      public virtual JDFFileSpec getCreateSearchPath(int iSkip)
      {

         JDFFileSpec res = getSearchPath(iSkip);
         if (res == null)
         {
            res = appendSearchPath();
         }

         return res;
      }

      public virtual JDFFileSpec appendSearchPath()
      {

         JDFFileSpec res = appendFileSpec();
         res.setResourceUsage("SearchPath");

         return res;
      }

      public override VString getInvalidElements(EnumValidationLevel level, bool bIgnorePrivate, int nMax)
      {

         VString vElem = new VString();
         int n = 0;
         int nElem = numChildElements(ElementName.FILESPEC, null);

         for (int i = 0; i < nElem; i++)
         {

            string ru = getFileSpec(i).getResourceUsage();
            if (!ru.Equals("SearchPath"))
            {
               vElem.appendUnique(ElementName.FILESPEC);
               if (++n >= nMax)
                  return vElem;
               break;
            }
         }
         vElem.appendUnique(getInvalidElements(level, bIgnorePrivate, (nMax - n)));

         return vElem;
      }
   }
}
