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




/*
 * Copyright (c) 2001 Heidelberger Druckmaschinen AG, All Rights Reserved.
 * JDFDoc.cs
 * ------------------------------------------------------------------------------------------------- */

namespace org.cip4.jdflib.core
{
   using System;
   using System.IO;
   using System.Net;
   using System.Net.Mail;
   using System.Xml;


   using JDFJMF = org.cip4.jdflib.jmf.JDFJMF;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using JDFResourcePool = org.cip4.jdflib.pool.JDFResourcePool;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using UrlUtil = org.cip4.jdflib.util.UrlUtil;
   using HTTPDetails = org.cip4.jdflib.util.UrlUtil.HTTPDetails;

   ///
   /// <summary> * </summary>
   /// 
   public class JDFDoc : XMLDoc
   {
      // **************************************** Constructors
      // ****************************************
      ///   
      ///	 <summary> * constructor </summary>
      ///	 
      public JDFDoc()
         : base()
      {
      }

      ///   
      ///	 <summary> * constructor
      ///	 *  </summary>
      ///	 * <param name="document"> </param>
      ///	 
      public JDFDoc(XmlDocument document)
         : base(document)
      {
      }

      ///   
      ///	 <summary> * constructor
      ///	 *  </summary>
      ///	 * <param name="document"> </param>
      ///	 
      public JDFDoc(DocumentImpl document)
         : base(document)
      {
      }

      ///   
      ///	 <summary> * constructor - create the kind of JDF you need
      ///	 *  </summary>
      ///	 * <param name="strDocType"> - ElementName.JDF, ElementName.JMF, "Config" ... </param>
      ///	 
      public JDFDoc(string strDocType)
         : base(strDocType, JDFElement.getSchemaURL())
      {
      }

      // **************************************** Methods
      // *********************************************
      ///   
      ///	 <summary> * GetJDFRoot - get the jdf root
      ///	 *  </summary>
      ///	 * <returns> JDFNode - the root of the JDF file </returns>
      ///	 
      public virtual JDFNode getJDFRoot()
      {
         return (JDFNode)getJXFRoot(ElementName.JDF);
      }

      ///   
      ///	 <summary> * GetJMFRoot - get the jmf root
      ///	 *  </summary>
      ///	 * <returns> JDFJMF - the root of the JMF file </returns>
      ///	 
      public virtual JDFJMF getJMFRoot()
      {
         return (JDFJMF)getJXFRoot(ElementName.JMF);
      }

      ///   
      ///	 * <param name="rootName"> ElementName.JDF or ElementName.JMF
      ///	 * @return </param>
      ///	 
      private KElement getJXFRoot(string rootName)
      {
         KElement root = getRoot();

         if (!root.LocalName.Equals(rootName))
         {
            root = root.getChildByTagName(rootName, JDFElement.getSchemaURL(), 0, null, true, false);
         }

         return root;
      }

      ///   
      ///	 <summary> * clone
      ///	 *  </summary>
      ///	 * <returns> Object the cloned JDFDoc </returns>
      ///	 * <exception cref="CloneNotSupportedException"> </exception>
      ///	 
      public override object clone()
      {
         return new JDFDoc(((XMLDoc)base.clone()).getMemberDocument());
      }

      ///   
      ///	 <summary> * toString
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public override string ToString()
      {
         return "JDFDoc: " + base.ToString();
      }

      ///   
      ///	 <summary> * CreateJDF
      ///	 *  </summary>
      ///	 * <param name="JDFPath"> </param>
      ///	 * @deprecated simply use constructor 
      ///	 * <returns> JDFDoc </returns>
      ///	 
      [Obsolete("simply use constructor")]
      public static JDFDoc createJDF(string jdfPath)
      {
         JDFDoc new_doc = new JDFDoc();
         JDFNode root = (JDFNode)new_doc.createElement(ElementName.JDF);
         root.setAttribute(AttributeName.ID, JDFElement.uniqueID(50), JDFConstants.EMPTYSTRING);
         root.init();

         new_doc.appendChild(root);

         new_doc.write2File(jdfPath, 0, true);

         return new_doc;
      }

      ///   
      ///	 <summary> * returns a JDFNode by its id attribute
      ///	 *  </summary>
      ///	 * <param name="id"> the ID parameter of the JDF node </param>
      ///	 * <returns> JDFNode - the corresponding JDF Node, null if no such node exists </returns>
      ///	 * @deprecated use getRoot().getTarget(id, AttributeName.ID) and cast.
      ///	 *  
      ///	 
      [Obsolete("use getRoot().getTarget(id, AttributeName.ID) and cast.")]
      public virtual JDFNode getJDFNodeByID(string id)
      {

         return (JDFNode)getRoot().getTarget(id, AttributeName.ID);
      }

      ///   
      ///	 <summary> * removes all dangling resources and cleans up the rrefs attributes
      ///	 *  </summary>
      ///	 * <param name="nodeNames"> the list of nodenames to remove, remove all if nodenames is empty
      ///	 * 
      ///	 * @default CollectGarbageResources(new vString()) </param>
      ///	 
      public virtual int collectGarbageResources(VString nodeNames)
      {
         bool bCollectAll = nodeNames == null || nodeNames.IsEmpty();

         VElement vProcs = getJDFRoot().getvJDFNode(null, null, false);
         VElement vResources = new VElement();
         VElement vLinkedResources = new VElement();

         // loop over all jdf nodes
         int i;
         for (i = 0; i < vProcs.Count; i++)
         {
            int j;
            JDFNode n = (JDFNode)vProcs[i];
            vLinkedResources.appendUnique(n.getLinkedResources(null, true));

            JDFResourcePool rp = n.getResourcePool();
            VElement resources = rp.getPoolChildren(null, null, null);
            vResources.appendUnique(resources);

            for (j = 0; j < resources.Count; j++)
            {
               vResources.appendUnique(((JDFResource)resources[j]).getvHRefRes(true, true));
            }
         }

         VElement vr = new VElement();
         for (i = 0; i < vResources.Count; i++)
         {
            vr.appendUnique(((JDFResource)vResources[i]).getResourceRoot());
         }

         vResources = vr;
         vr.Clear();
         for (i = 0; i < vLinkedResources.Count; i++)
         {
            vr.appendUnique(((JDFResource)vLinkedResources[i]).getResourceRoot());
         }
         vLinkedResources = vr;

         int nDeleted = 0;
         for (i = 0; i < vResources.Count; i++)
         {
            JDFResource r = (JDFResource)vResources[i];
            if (!(vLinkedResources.index(r) >= 0))
            {
               if (bCollectAll || (nodeNames != null && nodeNames.Contains(r.LocalName)))
               {
                  r.deleteNode();
                  nDeleted++;
               }
            }
         }
         // run gc a few times to really clean up
         System.Diagnostics.Process.GetCurrentProcess();
         System.GC.Collect();
         System.Diagnostics.Process.GetCurrentProcess();
         System.GC.Collect();

         return nDeleted;
      }

      ///   
      ///	 <summary> * gets the content type
      ///	 *  </summary>
      ///	 * <returns> the content type, Text/XML if neither jdf nor jmf </returns>
      ///	 
      public virtual string getContentType()
      {
         KElement e = getRoot();
         string strContentType;

         if (e is JDFNode)
         {
            strContentType = JDFConstants.MIME_JDF;
         }
         else if (e is JDFJMF)
         {
            strContentType = JDFConstants.MIME_JMF;
         }
         else
         {
            strContentType = JDFConstants.MIME_TEXTXML;
         }
         return strContentType;
      }

      ///   
      ///	 <summary> * parse a JDF file
      ///	 *  </summary>
      ///	 * <param name="fileName"> </param>
      ///	 * <returns> the parsed JDFDoc </returns>
      ///	 
      public static JDFDoc parseFile(string fileName)
      {
         JDFParser p = new JDFParser();
         return p.parseFile(fileName);
      }

      ///   
      ///	 <summary> * parse a given url
      ///	 *  </summary>
      ///	 * <param name="url"> the url to search </param>
      ///	 * <param name="bp"> the bodypart that the CID url is located in </param>
      ///	 * <returns> the parsed JDFDoc </returns>
      ///	 
      public static JDFDoc parseURL(string url, Attachment bp)
      {
         JDFParser p = new JDFParser();
         Stream inStream = UrlUtil.getURLInputStream(url, bp);
         FileInfo f = UrlUtil.urlToFile(url);

         JDFDoc d = p.parseStream(inStream);
         if (f != null && f.Exists) // Java to C# Conversion - NOTE: No .NET Equivalent for canRead()
            d.setOriginalFileName(f.FullName);
         return d;
      }

      ///   
      ///	 <summary> * initialize a new root of strDocType in the document called by constructor XMLDoc(String strDocType)
      ///	 *  </summary>
      ///	 * <param name="strDocType"> qualified tag name of the doc root to create if still empty </param>
      ///	 * <param name="namespaceURI"> namespace URI of the doc root </param>
      ///	 * <returns> KElement - the root element
      ///	 * 
      ///	 * @default setRoot(ElementName.JDF, null) </returns>
      ///	 
      public override KElement setRoot(string strDocType, string namespaceURI)
      {
         KElement root = base.setRoot(strDocType, namespaceURI);
         if (root != null)
         {
            if (root is JDFNode)
            {
               ((JDFNode)root).init();
            }
            else if (root is JDFJMF)
            {
               string comment = "Generated by the CIP4 .NET open source JDF Library version : ";
               comment += JDFAudit.software();
               ((JDFJMF)root).init();
               ((JDFJMF)root).appendXMLComment(comment, null);
            }
         }
         return root;
      }

      ///   
      ///	 <summary> * This method sends the contents of this JDFDoc to the URL <code>strURL</code> and receives the response in the
      ///	 * returned JDFDoc. the content type is automagically set to either text/xml for undefined xml or to
      ///	 * application/vnd.cip4-jdf+xml or application/vnd.cip4-jmf+xml
      ///	 *  </summary>
      ///	 * <param name="strURL"> the URL to write to
      ///	 *  </param>
      ///	 * <returns> docResponse the response received from URL. A Null document if no response was received, or an exception
      ///	 *         occurred </returns>
      ///	 
      public virtual JDFDoc write2URL(string strURL)
      {
         KElement e = getRoot();
         if (e == null)
            return null;
         string strContentType = getContentType(e);

         XMLDoc d = base.write2URL(strURL, strContentType);
         return d == null ? null : new JDFDoc(d.getMemberDocument());
      }

      public virtual HttpWebRequest write2HTTPURL(Uri strURL, HTTPDetails det)
      {
         KElement e = getRoot();
         if (e == null)
            return null;
         string strContentType = getContentType(e);

         return base.write2HTTPURL(strURL, strContentType, det);
      }

      ///   
      ///	 <summary> * gets the contentType for a given root element
      ///	 *  </summary>
      ///	 * <param name="e">
      ///	 * @return </param>
      ///	 
      public static string getContentType(KElement e)
      {
         string strContentType = UrlUtil.TEXT_XML;
         if (e is JDFNode)
            strContentType = UrlUtil.VND_JDF;
         else if (e is JDFJMF)
            strContentType = UrlUtil.VND_JMF;
         return strContentType;
      }

      ///

      // JDFDoc write2URL(String strURL, String schemaLocation) {

      // return XMLDoc.write2URL(strURL,getContentType(),schemaLocation);
      // }

      ///

      // boolean stringParse(String in, boolean bValidate, boolean bEraseEmpty,
      // boolean bDoNamespaces, ErrorHandler pErrorHandler, String schemaLocation)
      // {
      // boolean b = XMLDoc.stringParse( in, bValidate, bEraseEmpty,
      // bDoNamespaces, pErrorHandler,schemaLocation);
      // getJDFRoot().getMinID();
      // return b;
      // }

      ///

      // boolean streamParse(InputStream in, boolean bValidate, boolean
      // bEraseEmpty,
      // boolean bDoNamespaces, ErrorHandler pErrorHandler, String schemaLocation)
      // {
      // boolean b = XMLDoc.streamParse( in, bValidate, bEraseEmpty,
      // bDoNamespaces, pErrorHandler,schemaLocation);
      // getJDFRoot().getMinID();
      // return b;
      // }

      ///

      // boolean parse(String inFile,boolean bValidate, boolean bEraseEmpty,
      // boolean bDoNamespaces, ErrorHandler pErrorHandler, String schemaLocation)
      // {
      // boolean b = XMLDoc.parse( inFile, bValidate, bEraseEmpty,
      // bDoNamespaces, pErrorHandler,schemaLocation);
      // getJDFRoot().getMinID();
      // return b;
      // }

      ///

      // boolean parse(JDF.File inFile, boolean bValidate, boolean bEraseEmpty,
      // boolean bDoNamespaces, ErrorHandler pErrorHandler, String schemaLocation)
      // {
      // boolean b = XMLDoc.parse(inFile, bValidate, bEraseEmpty,
      // bDoNamespaces, pErrorHandler,schemaLocation);
      // getJDFRoot().getMinID();
      // return b;
      // }
      ///

      // MIMEMessage createMIMEMessage() {

      // JDF.MIMEBasicPart mbp = createMIMEBasicPart();
      // MIMEMultiPart mmp = new JDF.MIMEMultiPart();
      // mmp.addBodyPart(mbp, false); // false->don't clone it
      // mmp.setContentSubType(L"related");

      // // make a MIMEMessage out of it
      // MIMEMessage mmsg = new JDF.MIMEMessage();
      // mmsg.setBody(mmp,false);

      // return mmsg;
      // }
      ///

      // MIMEBasicPart createMIMEBasicPart() {
      // JDF.MIMEBasicPart mbp = new JDF.MIMEBasicPart
      // (MIMEBasicPart.APPLICATION);
      // String docString;
      // write2String(docString);
      // mbp.setBodyData (docString);
      // mbp.setContentSubType(GetContentType().substr(12));

      // return mbp;
      // }

   }
}
