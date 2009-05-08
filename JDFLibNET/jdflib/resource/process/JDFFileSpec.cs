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




/* ==========================================================================
 * class JDFFileSpec
 * ==========================================================================
 * @COPYRIGHT Heidelberger Druckmaschinen AG, 1999-2001 ALL RIGHTS RESERVED
 * @Author: sabjon@topmail.de    using a code generator 
 * Warning! very preliminary test version. 
 * Interface subject to change without prior notice!  */


namespace org.cip4.jdflib.resource.process
{
   using System.IO;
   using System.Collections.Generic;



   using JDFAutoFileSpec = org.cip4.jdflib.auto.JDFAutoFileSpec;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using UrlUtil = org.cip4.jdflib.util.UrlUtil;

   public class JDFFileSpec : JDFAutoFileSpec
   {
      private new const long serialVersionUID = 1L;
      private static Dictionary<string, string> mimeMap = null;

      ///   
      ///	 <summary> * Constructor for JDFFileSpec
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFFileSpec(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFFileSpec
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFFileSpec(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFFileSpec
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="localName"> </param>

      ///	 
      public JDFFileSpec(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      public override string ToString()
      {
         return "JDFFileSpec[  --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * sets the URL attribute to an absolute file IRL (internationalized)
      ///	 *  </summary>
      ///	 * <param name="f">
      ///	 *            the file to set the URL to </param>
      ///	 * <param name="boolean"> bEscape128 if true, escape chars>128 (URL) else don't
      ///	 *        escape (IRL) </param>
      ///	 
      public virtual void setAbsoluteFileURL(FileInfo f, bool bEscape128)
      {
         string s = UrlUtil.fileToUrl(f, bEscape128);
         setMimeURL(s);
      }

      ///   
      ///	 <summary> * sets the URL attribute to an absolute file IRL (internationalized)
      ///	 *  </summary>
      ///	 * <param name="f">
      ///	 *            the file to set the URL to </param>
      ///	 * <param name="baseDir">
      ///	 *            the File representing the relative location. if null use
      ///	 *            current working dir </param>
      ///	 * <param name="boolean"> bEscape128 if true, escape chars>128 (URL) else don't
      ///	 *        escape (IRL) </param>
      ///	 
      public virtual void setRelativeURL(FileInfo f, FileInfo baseDir, bool bEscape128)
      {
         string s = UrlUtil.getRelativeURL(f, baseDir, bEscape128);
         setMimeURL(s);
      }


      ///   
      ///	 <summary> * get the input stream that reads from URL
      ///	 *  </summary>
      ///	 * <returns> InputStream the input stream that the url points to, null if the
      ///	 *         url is inaccessible </returns>
      ///	 
      public virtual Stream getURLInputStream()
      {
         string url = getURL();
         if (url.Equals(JDFConstants.EMPTYSTRING))
            return null;
         return UrlUtil.getURLInputStream(getURL(), getOwnerDocument_KElement().getBodyPart());
      }

      ///   
      ///	 <summary> * sets URL and MimeType by matching the extensions
      ///	 *  </summary>
      ///	 * <param name="url">
      ///	 *            the url to set URL </param>
      ///	 
      public virtual void setMimeURL(string url)
      {
         setURL(url);
         setMimeType(getMimeTypeFromURL(url));
      }

      ///   
      ///	 <summary> * generates the correct MIMEType for a given URL and sets it
      ///	 *  </summary>
      ///	 * <param name="url"> </param>
      ///	 
      public static string getMimeTypeFromURL(string url)
      {
         if (mimeMap == null)
         {
            mimeMap = new Dictionary<string, string>();
            mimeMap.Add("pdf", JDFConstants.MIME_PDF);
            mimeMap.Add("ps", JDFConstants.MIME_PS);

            mimeMap.Add("ppf", JDFConstants.MIME_CIP3);
            mimeMap.Add("ppml", JDFConstants.MIME_PPML);
            mimeMap.Add("jdf", JDFConstants.MIME_JDF);
            mimeMap.Add("jmf", JDFConstants.MIME_JMF);

            mimeMap.Add("xml", JDFConstants.MIME_TEXTXML);

            mimeMap.Add("jpg", JDFConstants.MIME_JPG);
            mimeMap.Add("jpeg", JDFConstants.MIME_JPG);
            mimeMap.Add("tif", JDFConstants.MIME_TIFF);
            mimeMap.Add("tiff", JDFConstants.MIME_TIFF);
         }
         string extension = UrlUtil.extension(url);
         return extension == null ? null : mimeMap[extension.ToLower()];
      }
   }
}
