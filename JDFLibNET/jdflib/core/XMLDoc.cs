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


/* XMLDoc.cs
 * Copyright (c) 2001-2003 Heidelberger Druckmaschinen AG, All Rights Reserved.
 */

namespace org.cip4.jdflib.core
{
   using System;
   using System.Collections;
   using System.Net;
   using System.Net.Mail;
   using System.IO;
   using System.Xml;
   using System.Xml.Serialization;
   using System.Text;


   using HashUtil = org.cip4.jdflib.util.HashUtil;
   using StatusCounter = org.cip4.jdflib.util.StatusCounter;
   using StringUtil = org.cip4.jdflib.util.StringUtil;
   using UrlUtil = org.cip4.jdflib.util.UrlUtil;
   using HTTPDetails = org.cip4.jdflib.util.UrlUtil.HTTPDetails;


   //TODO: why does XMLDoc know DocumentJDFImpl ??? 

   ///
   /// * <seealso cref= <a href="http://xerces.apache.org/xerces-j/apiDocs/org/apache/xerces/dom/DocumentImpl.html"
   /// *      Xerces-Documentation< /a> </seealso>
   /// 

   public class XMLDoc : ICloneable
   {
      private DocumentJDFImpl m_doc;

      // **************************************** Constructors
      // ****************************************
      ///   
      ///	 <summary> * constructor </summary>
      ///	 
      public XMLDoc()
      {
         m_doc = new DocumentJDFImpl();
         getCreateXMLDocUserData();
      }

      public override bool Equals(object o)
      {
         if (o == null)
            return false;
         if (!(o is XMLDoc))
            return false;

         XMLDoc d = (XMLDoc)o;
         if (m_doc == null)
            return d.m_doc == null;

         return m_doc.Equals(d.m_doc);
      }

      public override int GetHashCode()
      {
         return HashUtil.GetHashCode(0, this.m_doc);
      }

      ///   
      ///	 <summary> * constructor
      ///	 *  </summary>
      ///	 * <param name="document"> </param>
      ///	 
      public XMLDoc(XmlDocument document)
      {
         if (document == null)
         {
            throw new JDFException("XMLDoc(Document) null input Document");
         }
         else if (document is DocumentJDFImpl)
         {
            m_doc = (DocumentJDFImpl)document;
            getCreateXMLDocUserData();
         }
         else
         {
            string s = document.GetType().ToString();
            throw new JDFException("XMLDoc(Document) not implemented; class=" + s);
            // m_doc = new DocumentJDFImpl(document); // does not set all fields
         }
      }

      ///   
      ///	 <summary> * constructor
      ///	 *  </summary>
      ///	 * <param name="document"> </param>
      ///	 
      public XMLDoc(DocumentJDFImpl document)
      {
         if (document == null)
         {
            throw new JDFException("XMLDoc(DocumentJDFImpl) null input Document");
         }
         m_doc = document;
         getCreateXMLDocUserData();
      }

      ///   
      ///	 <summary> * constructor
      ///	 *  </summary>
      ///	 * <param name="strDocType"> ElementName.JDF, ElementName.JMF, "Config" ... </param>
      ///	 * @deprecated use XMLDoc(String strDocType, String namespaceURI) 
      ///	 
      [Obsolete("use XMLDoc(String strDocType, String namespaceURI)")]
      public XMLDoc(string strDocType)
      {
         new XMLDoc(strDocType, null);
      }

      ///   
      ///	 <summary> * constructor
      ///	 *  </summary>
      ///	 * <param name="strDocType"> ElementName.JDF, ElementName.JMF, "Config" ... </param>
      ///	 * <param name="namespaceURI"> namespace to be used by the new XMLDoc </param>
      ///	 
      public XMLDoc(string strDocType, string namespaceURI)
      {
         m_doc = new DocumentJDFImpl();
         if (namespaceURI == null)
         {
            m_doc.bKElementOnly = true;
            m_doc.setIgnoreNSDefault(true);
         }

         setRoot(strDocType, namespaceURI);
         getCreateXMLDocUserData();
      }

      ///   
      ///	 <summary> *  </summary>
      ///	 * <param name="strDocType"> </param>
      ///	 * <returns> KElement </returns>
      ///	 * @deprecated use setRoot(String strDocType, String namespaceURI)
      ///	 *  
      ///	 
      [Obsolete("use setRoot(String strDocType, String namespaceURI)")]
      public virtual KElement setRoot(string strDocType)
      {
         return setRoot(strDocType, JDFElement.getSchemaURL());
      }

      // **************************************** Methods
      // *********************************************
      ///   
      ///	 <summary> * initialize a new root of strDocType in the document called by constructor XMLDoc(String strDocType)
      ///	 *  </summary>
      ///	 * <param name="strDocType"> qualified tag name of the doc root to create if still empty </param>
      ///	 * <param name="namespaceURI"> namespace URI of the doc root </param>
      ///	 * <returns> JDFElement - the root element
      ///	 * 
      ///	 * @default setRoot(ElementName.JDF, null) </returns>
      ///	 
      public virtual KElement setRoot(string strDocType, string namespaceURI)
      {
         KElement root = (JDFElement)m_doc.DocumentElement;

         if (root != null)
         {
            throw new JDFException("XMLDoc.setRoot:  root already exists: ");
         }

         // create a new document root element
         root = m_doc.factoryCreate(root, namespaceURI, strDocType);
         if (root != null)
         {
            appendChild(root);
         }
         return root;
      }

      ///   
      ///	 <summary> * getMemberDocument
      ///	 *  </summary>
      ///	 * <returns> the MemberDocument </returns>
      ///	 
      public virtual DocumentJDFImpl getMemberDocument()
      {
         return this.m_doc;
      }

      ///   
      ///	 <summary> * Method Flush<br>
      ///	 * clean the m_doc and restart from scratch. The root element remains
      ///	 *  </summary>
      ///	 * <returns> boolean - true if successful </returns>
      ///	 
      protected internal virtual bool flush()
      {
         return getRoot().flush();
      }

      ///   
      ///	 <summary> * get the root of the dom tree
      ///	 *  </summary>
      ///	 * <returns> JDFElement
      ///	 * 
      ///	 *         default: getRoot() </returns>
      ///	 
      public virtual KElement getRoot()
      {
         return (KElement)m_doc.DocumentElement;
      }

      ///   
      ///	 <summary> * write2String - write to a string;
      ///	 *  </summary>
      ///	 * <param name="indent"> the indentation of the xml
      ///	 *  </param>
      ///	 * <returns> String - output </returns>
      ///	 
      public virtual string write2String(int indent)
      {
         string strResult = JDFConstants.EMPTYSTRING;
         MemoryStream outStream = new MemoryStream();

         try
         {
            write2Stream(outStream, indent, indent == 0);
            strResult = Encoding.UTF8.GetString(outStream.ToArray());
         }
         catch (IOException e)
         {
            Console.WriteLine("write2String: " + outStream + " : " + e);
         }
         finally
         {
            if (outStream != null)
            {
               try
               {
                  outStream.Close();
               }
               catch (IOException)
               {
                  // nop
               }
            }
         }

         return strResult;
      }

      ///   
      ///	 <summary> * write2File - write to a file; Create if it doesn't exist always assume utf-8 encoding
      ///	 *  </summary>
      ///	 * <param name="oFilePath"> </param>
      ///	 * <param name="indent">
      ///	 *  </param>
      ///	 * <returns> boolean </returns>
      ///	 * @deprecated 060419 use write2File(oFilePath, indent, true);
      ///	 * @default write2File(String oFilePath, 0) 
      ///	 
      [Obsolete("060419 use write2File(oFilePath, indent, true);")]
      public virtual bool write2File(string oFilePath, int indent)
      {
         return write2File(oFilePath, indent, true);
      }

      ///   
      ///	 <summary> * write2File - write to a file; Create if it doesn't exist always assume utf-8 encoding
      ///	 *  </summary>
      ///	 * <param name="oFilePath"> where to write the file </param>
      ///	 * <param name="indent"> indentation </param>
      ///	 * <param name="bPreserveSpace"> if true, preserve whitespace
      ///	 *  </param>
      ///	 * <returns> boolean - true if successful
      ///	 * 
      ///	 * @default write2File(String oFilePath, 0) </returns>
      ///	 
      public virtual bool write2File(string oFilePath, int indent, bool bPreserveSpace)
      {
         string oFilePathLocal = oFilePath;

         if (oFilePathLocal == null)
            oFilePathLocal = m_doc.m_OriginalFileName;

         if (oFilePathLocal == null)
            return false;

         return write2File(new FileInfo(oFilePathLocal), indent, bPreserveSpace);
      }

      ///   
      ///	 <summary> * write2File - write to a file; Create if it doesn't exist always assume utf-8 encoding
      ///	 *  </summary>
      ///	 * <param name="file"> fthe file to write to </param>
      ///	 * <param name="indent"> indentation </param>
      ///	 * <param name="bPreserveSpace"> if true, preserve whitespace
      ///	 *  </param>
      ///	 * <returns> boolean - true if successful
      ///	 * 
      ///	 * @default write2File(String oFilePath, 0) </returns>
      ///	 
      public virtual bool write2File(FileInfo file, int indent, bool bPreserveSpace)
      {
         FileInfo fileLocal = file;

         if (fileLocal == null)
            return false;

         bool fSuccess = true;
         FileStream outStream = null;

         try
         {
            if (Directory.Exists(fileLocal.FullName) && getOriginalFileName() != null)
            {
               FileInfo orig = new FileInfo(getOriginalFileName());
               fileLocal = new FileInfo(fileLocal + Path.DirectorySeparatorChar.ToString() + orig.Name);
            }

            // ensure having an empty file in case it did not exist
            bool tmpBool;
            if (File.Exists(fileLocal.FullName))
            {
               File.Delete(fileLocal.FullName);
               tmpBool = true;
            }
            else if (Directory.Exists(fileLocal.FullName))
            {
               Directory.Delete(fileLocal.FullName);
               tmpBool = true;
            }
            else
               tmpBool = false;
            bool generatedAux2 = tmpBool;
            if (SupportClass.FileSupport.CreateNewFile(fileLocal))
            {
               outStream = new FileStream(fileLocal.FullName, FileMode.Create);
               write2Stream(outStream, indent, bPreserveSpace);
            }
         }
         catch (FileNotFoundException e)
         {
            Console.WriteLine("Write2File: " + fileLocal.FullName + " : " + e);
            fSuccess = false;
         }
         catch (IOException e)
         {
            Console.WriteLine("Write2File: " + fileLocal.FullName + " : " + e);
            fSuccess = false;
         }
         finally
         {
            if (outStream != null)
            {
               try
               {
                  outStream.Close();
               }
               catch (IOException)
               {
                  //nop
               }
            }
         }

         return fSuccess;
      }

      ///   
      ///	 * @deprecated use write2Stream(outStream, indent, true); 
      ///	 * <param name="outStream"> </param>
      ///	 * <param name="indent"> </param>
      ///	 * <exception cref="IOException"> </exception>
      ///	 
      [Obsolete("use write2Stream(outStream, indent, true);")]
      public virtual void write2Stream(Stream outStream, int indent)
      {
         write2Stream(outStream, indent, indent == 0);
      }

      ///   
      ///	 <summary> * write this to a stream
      ///	 *  </summary>
      ///	 * <param name="outStream"> </param>
      ///	 * <param name="indent"> </param>
      ///	 * <param name="bPreserveSpace"> </param>
      ///	 * <exception cref="IOException">
      ///	 * @since 080425 synchronized </exception>
      ///	 
      public virtual void write2Stream(Stream outStream, int indent, bool bPreserveSpace)
      {
         string indentStr = "";
         if (indent >= 0)
            indentStr = new string(' ', indent);

         for (int i = 0; i < 3; i++)
         {
            try
            {
               XmlWriterSettings settings = new XmlWriterSettings();
               settings.Encoding = Encoding.UTF8;
               settings.Indent = (indent >= 0);
               settings.IndentChars = indentStr;
               settings.NewLineChars = Environment.NewLine;
               settings.ConformanceLevel = ConformanceLevel.Document;
               XmlWriter writer = XmlTextWriter.Create(outStream, settings);

               XmlSerializer serial = new XmlSerializer(m_doc.GetType());
               // serial.setNamespaces(false); // ###DOM_1_nodes

               lock (m_doc)
               {
                  serial.Serialize(writer, m_doc);
               }
               return; // all is well here
            }
            catch (IOException x)
            {
               if (i >= 3)
                  throw x; // try three times, else ciao
               StatusCounter.sleep(1000 * (i + 1));
               Console.WriteLine("retry exception " + i + " for " + getOriginalFileName());
            }
         }
      }

      ///   
      ///	 * @deprecated 060306 
      ///	 * <param name="elem"> </param>
      ///	 * <param name="outStream"> </param>
      ///	 * <param name="indent"> </param>
      ///	 * <exception cref="IOException"> </exception>
      ///	 
      [Obsolete("060306")]
      public static void write2StreamStatic(XmlElement elem, Stream outStream, int indent)
      {
         write2StreamStatic(elem, outStream, indent, true);
      }

      ///   
      ///	 * @deprecated 060306 
      ///	 * <param name="elem"> </param>
      ///	 * <param name="outStream"> </param>
      ///	 * <param name="indent"> </param>
      ///	 * <param name="bPreserveSpace"> </param>
      ///	 * <exception cref="IOException"> </exception>
      ///	 
      [Obsolete("060306")]
      public static void write2StreamStatic(XmlElement elem, Stream outStream, int indent, bool bPreserveSpace)
      {
         try
         {
            string indentStr = "";
            if (indent >= 0)
               indentStr = new string(' ', indent);

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
            settings.Indent = (indent >= 0);
            settings.IndentChars = indentStr;
            settings.NewLineChars = Environment.NewLine;
            settings.ConformanceLevel = ConformanceLevel.Document;
            XmlWriter writer = XmlTextWriter.Create(outStream, settings);

            XmlSerializer serial = new XmlSerializer(elem.GetType());
            // serial.setNamespaces(false); // ###DOM_1_nodes
            serial.Serialize(writer, elem);
         }
         catch (Exception)
         {
            // Java to C# Conversion - TODO: Log or print something here?
         }
      }

      ///   
      ///	 <summary> * getDoctype
      ///	 *  </summary>
      ///	 * <returns> DocumentType </returns>
      ///	 
      public virtual XmlDocumentType getDoctype()
      {
         return (m_doc == null) ? null : m_doc.DocumentType;
      }

      ///   
      ///	 <summary> * getImplementation
      ///	 *  </summary>
      ///	 * <returns> DOMImplementation </returns>
      ///	 
      public virtual XmlImplementation getImplementation()
      {
         return (m_doc == null) ? null : m_doc.Implementation;
      }

      ///   
      ///	 <summary> * getDocumentElement
      ///	 *  </summary>
      ///	 * <returns> Element </returns>
      ///	 
      public virtual XmlElement getDocumentElement()
      {
         return (m_doc == null) ? null : m_doc.DocumentElement;
      }

      ///   
      ///	 <summary> * createElement create a JDFElement that floats in nirvana. This must be appended to a node with appendChild
      ///	 * (created in namespace JDFConstants.NONAMESPACE (DOM Level 2)).<br>
      ///	 * Another way would be to use KElement.appendElement(String elementName, String nameSpaceURI)
      ///	 *  </summary>
      ///	 * <param name="elementName"> name of the element that is created
      ///	 *  </param>
      ///	 * <returns> Element - unconnected element that is created </returns>
      ///	 
      public virtual XmlElement createElement(string elementName)
      {
         XmlElement elem = null;

         if (m_doc != null)
            elem = m_doc.createElement(elementName);

         if (elem is KElement)
            ((KElement)elem).init();

         return elem;
      }

      ///   
      ///	 <summary> * createDocumentFragment
      ///	 *  </summary>
      ///	 * <returns> DocumentFragment </returns>
      ///	 
      public virtual XmlDocumentFragment createDocumentFragment()
      {
         return (m_doc == null) ? null : m_doc.CreateDocumentFragment();
      }

      ///   
      ///	 <summary> * createTextNode
      ///	 *  </summary>
      ///	 * <param name="data">
      ///	 *  </param>
      ///	 * <returns> Text </returns>
      ///	 
      public virtual XmlText createTextNode(string data)
      {
         return (m_doc == null) ? null : m_doc.CreateTextNode(data);
      }

      ///   
      ///	 <summary> * createComment
      ///	 *  </summary>
      ///	 * <param name="data">
      ///	 *  </param>
      ///	 * <returns> Comment </returns>
      ///	 
      public virtual XmlComment createComment(string data)
      {
         return (m_doc == null) ? null : m_doc.CreateComment(data);
      }

      ///   
      ///	 <summary> * create a CDATA section, which has this document as ownerDoc
      ///	 *  </summary>
      ///	 * <param name="data"> content of the CDATA
      ///	 *  </param>
      ///	 * <returns> CDATASection </returns>
      ///	 
      public virtual XmlCDataSection createCDATASection(string data)
      {
         return (m_doc == null) ? null : m_doc.CreateCDataSection(data);
      }

      ///   
      ///	 <summary> * sets the processing instruction for an xslt stylesheet
      ///	 *  </summary>
      ///	 * <param name="url"> the url of the xslt file </param>
      ///	 
      public virtual void setXSLTURL(string url)
      {
         string data = "type=\"text/xsl\" href=\"" + url + "\"";
         XmlProcessingInstruction pi = createProcessingInstruction("xml-stylesheet", data);
         insertBefore(pi, getRoot());
      }

      ///   
      ///	 <summary> * creates a ProcessingInstruction having this Document as ownerDoc
      ///	 *  </summary>
      ///	 * <param name="target"> the target "processor channel" </param>
      ///	 * <param name="data"> parameter string to be passed to the target
      ///	 *  </param>
      ///	 * <returns> ProcessingInstruction </returns>
      ///	 
      public virtual XmlProcessingInstruction createProcessingInstruction(string target, string data)
      {
         return (m_doc == null) ? null : m_doc.CreateProcessingInstruction(target, data);
      }

      ///   
      ///	 <summary> * createAttribute in namespace JDFConstants.NONAMESPACE (DOM Level 2)
      ///	 *  </summary>
      ///	 * <param name="name"> attribute name TODO fix handling of namespaces </param>
      ///	 * <returns> Attr </returns>
      ///	 
      public virtual XmlAttribute createAttribute(string name)
      {
         XmlAttribute a = null;
         if (m_doc == null)
            throw new JDFException("Creating an attribute on a null document");

         if (name.IndexOf(":") < 0)
         {
            a = m_doc.CreateAttribute(name);
         }
         else
         {
            if (name.StartsWith("xsi:"))
            {
               a = m_doc.CreateAttribute(name, AttributeName.XSIURI);
            }
            else if (name.StartsWith("xmlns:"))
            {
               a = m_doc.CreateAttribute(name, AttributeName.XMLNSURI);
            }
            else
            {
               a = m_doc.CreateAttribute(name);
            }
         }
         return a;
      }

      ///   
      ///	 <summary> * creates an EntityReference
      ///	 *  </summary>
      ///	 * <param name="name"> name of the entity to refer to
      ///	 *  </param>
      ///	 * <returns> the newly created EntityReference </returns>
      ///	 
      public virtual XmlEntityReference createEntityReference(string name)
      {
         return (m_doc == null) ? null : m_doc.CreateEntityReference(name);
      }

      ///   
      ///	 <summary> * return a NodeList of all elements having the specified tagname
      ///	 *  </summary>
      ///	 * <param name="tagname"> tag name of the elements to find (JDFConstants.star for all elements)
      ///	 *  </param>
      ///	 * <returns> NodeList </returns>
      ///	 
      public virtual XmlNodeList getElementsByTagName(string tagname)
      {
         return (m_doc == null) ? null : m_doc.GetElementsByTagName(tagname);
      }

      ///   
      ///	 <summary> * copy a node from another document in this document
      ///	 *  </summary>
      ///	 * <param name="importedNode"> node to import </param>
      ///	 * <param name="deep"> if true: recurse and import the subtree under the node as well
      ///	 *  </param>
      ///	 * <returns> Node </returns>
      ///	 
      public virtual XmlNode importNode(XmlNode importedNode, bool deep)
      {
         return (m_doc == null) ? null : m_doc.ImportNode(importedNode, deep);
      }

      ///   
      ///	 <summary> * create a Element that floats in nirvana, this must be appended to a node with appendChild
      ///	 *  </summary>
      ///	 * <param name="namespaceURI"> the namespace uri of the created element </param>
      ///	 * <param name="qualifiedName"> name of the element that is created
      ///	 *  </param>
      ///	 * <returns> Element - unconnected element that is created </returns>
      ///	 
      public virtual XmlElement createElementNS(string namespaceURI, string qualifiedName)
      {
         return (m_doc == null) ? null : m_doc.createElementNS(namespaceURI, qualifiedName);
      }

      ///   
      ///	 <summary> * create an attribute withe the given name in the given namespace
      ///	 *  </summary>
      ///	 * <param name="namespaceURI"> namespace URI of the attribute </param>
      ///	 * <param name="qualifiedName"> qualified name of the attribute
      ///	 *  </param>
      ///	 * <returns> Attr - the newly created attribute </returns>
      ///	 
      public virtual XmlAttribute createAttributeNS(string namespaceURI, string qualifiedName)
      {
         return (m_doc == null) ? null : m_doc.CreateAttribute(qualifiedName, namespaceURI);
      }

      ///   
      ///	 <summary> * get a NodeList of all elements with a given name and namespace URI
      ///	 *  </summary>
      ///	 * <param name="namespaceURI"> the namespace URI to look for </param>
      ///	 * <param name="myLocalName"> the element name to look for
      ///	 *  </param>
      ///	 * <returns> NodeList with all elements found </returns>
      ///	 
      public virtual XmlNodeList getElementsByTagNameNS(string namespaceURI, string myLocalName)
      {
         return (m_doc == null) ? null : m_doc.GetElementsByTagName(myLocalName, namespaceURI);
      }

      ///   
      ///	 <summary> * get element with ID = elementId similar to Docoment.getElementByID but works with non schema parsed documents
      ///	 *  </summary>
      ///	 * <param name="elementId"> the element ID to look for
      ///	 *  </param>
      ///	 * <returns> the Element found </returns>
      ///	 
      public virtual XmlElement getElementById(string elementId)
      {
         KElement root = getRoot();
         return root.getTarget(elementId, null);
      }

      ///   
      ///	 <summary> * gets the node name
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public virtual string getNodeName()
      {
         return (m_doc == null) ? null : m_doc.Name;
      }

      ///   
      ///	 <summary> * gets the node value
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public virtual string getNodeValue()
      {
         return (m_doc == null) ? null : m_doc.Value;
      }

      ///   
      ///	 <summary> * setthe node value
      ///	 *  </summary>
      ///	 * <param name="nodeValue"> value to set the node to </param>
      ///	 
      public virtual void setNodeValue(string nodeValue)
      {
         if (m_doc != null)
         {
            m_doc.Value = nodeValue;
         }
      }

      ///   
      ///	 <summary> * get node type
      ///	 *  </summary>
      ///	 * <returns> a <i>short</i> representing the node type </returns>
      ///	 
      public virtual XmlNodeType getNodeType()
      {
         return (m_doc == null) ? XmlNodeType.None : m_doc.NodeType;
      }

      ///   
      ///	 <summary> * get the parent node of 'this' node
      ///	 *  </summary>
      ///	 * <returns> the parent node </returns>
      ///	 
      public virtual XmlNode getParentNode()
      {
         return (m_doc == null) ? null : m_doc.ParentNode;
      }

      ///   
      ///	 <summary> * get the child nodes of this node
      ///	 *  </summary>
      ///	 * <returns> a NodeList containing the child nodes </returns>
      ///	 
      public virtual XmlNodeList getChildNodes()
      {
         return (m_doc == null) ? null : m_doc.ChildNodes;
      }

      ///   
      ///	 <summary> * get the first child node of 'this'
      ///	 *  </summary>
      ///	 * <returns> the first child node </returns>
      ///	 
      public virtual XmlNode getFirstChild()
      {
         return (m_doc == null) ? null : m_doc.FirstChild;
      }

      ///   
      ///	 <summary> * get the last child node of 'this'
      ///	 *  </summary>
      ///	 * <returns> the last child node </returns>
      ///	 
      public virtual XmlNode getLastChild()
      {
         return (m_doc == null) ? null : m_doc.LastChild;
      }

      ///   
      ///	 <summary> * get the previous sibling of 'this'
      ///	 *  </summary>
      ///	 * <returns> the previous sibling node </returns>
      ///	 
      public virtual XmlNode getPreviousSibling()
      {
         return (m_doc == null) ? null : m_doc.PreviousSibling;
      }

      ///   
      ///	 <summary> * get the next sibling of 'this'
      ///	 *  </summary>
      ///	 * <returns> the next sibling node </returns>
      ///	 
      public virtual XmlNode getNextSibling()
      {
         return (m_doc == null) ? null : m_doc.NextSibling;
      }

      ///   
      ///	 <summary> * get the attributes associated with this node
      ///	 *  </summary>
      ///	 * <returns> NamedNodeMap containing the attributes associated with this node </returns>
      ///	 
      public virtual XmlNamedNodeMap getAttributes()
      {
         return (m_doc == null) ? null : m_doc.Attributes;
      }

      ///   
      ///	 <summary> * insert a new node before a given node
      ///	 *  </summary>
      ///	 * <param name="newChild"> the new child node to insert </param>
      ///	 * <param name="refChild"> the ref child node, the new node is inserted before it
      ///	 *  </param>
      ///	 * <returns> Node </returns>
      ///	 
      public virtual XmlNode insertBefore(XmlNode newChild, XmlNode refChild)
      {
         return (m_doc == null) ? null : m_doc.InsertBefore(newChild, refChild);
      }

      ///   
      ///	 <summary> * replace a child node with a new one
      ///	 *  </summary>
      ///	 * <param name="newChild"> the new child node to add </param>
      ///	 * <param name="oldChild"> the old child node to be replaced
      ///	 *  </param>
      ///	 * <returns> Node </returns>
      ///	 
      public virtual XmlNode replaceChild(XmlNode newChild, XmlNode oldChild)
      {
         return (m_doc == null) ? null : m_doc.replaceChild(newChild, oldChild);
      }

      ///   
      ///	 <summary> * remove a child from 'this'
      ///	 *  </summary>
      ///	 * <param name="oldChild"> the child node to be removed
      ///	 *  </param>
      ///	 * <returns> oldChild, in its new state (removed) </returns>
      ///	 
      public virtual XmlNode removeChild(XmlNode oldChild)
      {
         return (m_doc == null) ? null : m_doc.removeChild(oldChild);
      }

      ///   
      ///	 <summary> * append a new child node to 'this'
      ///	 *  </summary>
      ///	 * <param name="newChild"> new child node to add
      ///	 *  </param>
      ///	 * <returns> Node </returns>
      ///	 
      public virtual XmlNode appendChild(XmlNode newChild)
      {
         return (m_doc == null) ? null : m_doc.AppendChild(newChild);
      }

      ///   
      ///	 <summary> * test if 'this' has any children
      ///	 *  </summary>
      ///	 * <returns> boolean - true, if 'this' has children </returns>
      ///	 
      public virtual bool hasChildNodes()
      {
         return (m_doc == null) ? false : m_doc.HasChildNodes;
      }

      ///   
      ///	 <summary> * get a copy of 'this'
      ///	 *  </summary>
      ///	 * <param name="deep"> true: copy children as well
      ///	 *  </param>
      ///	 * <returns> Node - a copy of 'this' </returns>
      ///	 
      public virtual XmlNode cloneNode(bool deep)
      {
         return (m_doc == null) ? null : m_doc.CloneNode(deep);
      }

      ///   
      ///	 <summary> * normalize </summary>
      ///	 
      public virtual void normalize()
      {
         if (m_doc != null)
         {
            m_doc.Normalize();
         }
      }

      ///   
      ///	 <summary> * test whether a specific DOMImplelementation feature is supported by 'this'
      ///	 *  </summary>
      ///	 * <param name="feature"> package name of the feature to test </param>
      ///	 * <param name="version"> version number of the package name to test
      ///	 *  </param>
      ///	 * <returns> boolean - true, if the feature is sopported </returns>
      ///	 * <seealso cref= <a href="http://xerces.apache.org/xerces-j/apiDocs/org/apache/xerces/dom/NodeImpl.html#isSupported(java.lang.String,%20java.lang.String)"
      ///	 *      >Xerxes-Documentation< /a> </seealso>
      ///	 
      public virtual bool isSupported(string feature, string version)
      {
         return (m_doc == null) ? false : m_doc.Supports(feature, version);
      }

      ///   
      ///	 <summary> * get the namespace prefix of 'this' node
      ///	 *  </summary>
      ///	 * <returns> String - namespace prefix (null if unspecified) </returns>
      ///	 
      public virtual string getPrefix()
      {
         if (m_doc != null)
         {
            return m_doc.Prefix;
         }

         return null;
      }

      ///   
      ///	 <summary> * set the namespace prefix of 'this' node
      ///	 *  </summary>
      ///	 * <param name="prefix"> namespace prefix </param>
      ///	 
      public virtual void setPrefix(string prefix)
      {
         if (m_doc != null)
         {
            m_doc.Prefix = prefix;
         }
      }

      ///   
      ///	 <summary> * get the the local part of the qualified name of 'this'
      ///	 *  </summary>
      ///	 * <returns> String - local name </returns>
      ///	 
      public virtual string getLocalName()
      {
         return (m_doc == null) ? null : m_doc.LocalName;
      }

      ///   
      ///	 <summary> * check whether the underlying document is null
      ///	 *  </summary>
      ///	 * <returns> true if m_doc==null </returns>
      ///	 
      public virtual bool isNull()
      {
         return m_doc == null;
      }

      ///   
      ///	 <summary> * check if 'this' has attributes
      ///	 *  </summary>
      ///	 * <returns> true, if 'this' has attributes </returns>
      ///	 
      public virtual bool hasAttributes()
      {
         return (m_doc == null) ? false : m_doc.DocumentElement.HasAttributes;
      }

      ///   
      ///	 <summary> * createDocumentType
      ///	 *  </summary>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="publicID"> </param>
      ///	 * <param name="systemID">
      ///	 *  </param>
      ///	 * <returns> DocumentType </returns>
      ///	 
      public virtual XmlDocumentType createDocumentType(string qualifiedName, string publicID, string systemID)
      {
         return (m_doc == null) ? null : m_doc.CreateDocumentType(qualifiedName, publicID, systemID, null);
      }

      ///   
      ///	 <summary> * sets whether the DOM implementation performs error checking upon operations
      ///	 *  </summary>
      ///	 * <param name="check"> true - enable error checking </param>
      ///	 
      public virtual void setErrorChecking(bool check)
      {
         if (m_doc != null)
         {
            m_doc.setErrorChecking(check);
         }
      }

      ///   
      ///	 <summary> * does the DOM implementation perform error checking upon operations?
      ///	 *  </summary>
      ///	 * <returns> true - error checking is enabled, otherwise false </returns>
      ///	 
      public virtual bool getErrorChecking()
      {
         return (m_doc == null) ? false : m_doc.getErrorChecking();
      }

      ///   
      ///	 <summary> * create an entity
      ///	 *  </summary>
      ///	 * <param name="name"> name of the entity
      ///	 *  </param>
      ///	 * <returns> Entity - the newly created entity </returns>
      ///	 
      public virtual XmlEntityReference createEntity(string name)
      {
         return (m_doc == null) ? null : m_doc.CreateEntityReference(name);
      }

      ///   
      ///	 <summary> * creates a Notation having this Document as its OwnerDoc
      ///	 *  </summary>
      ///	 * <param name="name"> name of the notation
      ///	 *  </param>
      ///	 * <returns> Notation - the newly created notation </returns>
      ///	 
      public virtual XmlNotation createNotation(string name)
      {
         return (m_doc == null) ? null : m_doc.createNotation(name);
      }

      ///   
      ///	 <summary> * creates an element definition. Element definitions hold default attribute values.
      ///	 *  </summary>
      ///	 * <param name="name">
      ///	 *  </param>
      ///	 * <returns> ElementDefinitionImpl </returns>
      ///	 
      public virtual XmlElement createElementDefinition(string name)
      //public virtual ElementDefinitionImpl createElementDefinition(string name)
      {
         return (m_doc == null) ? null : m_doc.createElementDefinition(name);
      }

      ///   
      ///	 <summary> * Registers an identifier name with a specified element node
      ///	 *  </summary>
      ///	 * <param name="idName"> </param>
      ///	 * <param name="element"> </param>
      ///	 
      public virtual void putIdentifier(string idName, XmlElement element)
      {
         if (m_doc != null)
         {
            m_doc.putIdentifier(idName, element);
         }
      }

      ///   
      ///	 <summary> * gets the element with the registered name = "idName"
      ///	 *  </summary>
      ///	 * <param name="idName"> name of the element to get
      ///	 *  </param>
      ///	 * <returns> Element - the element with "idName" </returns>
      ///	 
      public virtual XmlElement getIdentifier(string idName)
      {
         return (m_doc == null) ? null : m_doc.getIdentifier(idName);
      }

      ///   
      ///	 <summary> * remove element with identifier "idName"
      ///	 *  </summary>
      ///	 * <param name="idName"> </param>
      ///	 
      public virtual void removeIdentifier(string idName)
      {
         if (m_doc != null)
         {
            m_doc.removeIdentifier(idName);
         }
      }

      ///   
      ///	 <summary> * gets the registered identifiers
      ///	 *  </summary>
      ///	 * <returns> Enumeration of registered identifiers </returns>
      ///	 
      public virtual System.Collections.IEnumerator getIdentifiers()
      {
         return (m_doc == null) ? null : m_doc.getIdentifiers();
      }

      ///   
      ///	 <summary> * create a node iterator
      ///	 *  </summary>
      ///	 * <param name="root"> the root of the iterator </param>
      ///	 * <param name="whatToShow"> the whatToShow mask </param>
      ///	 * <param name="filter"> the node filter (null = no filter)
      ///	 *  </param>
      ///	 * <returns> the newly created NodeIterator </returns>
      ///	 
      public virtual SupportClass.TraversalIteratorSupport createNodeIterator(XmlNode root, short whatToShow, SupportClass.FilterXml filter)
      {
         return (m_doc == null) ? null : m_doc.createNodeIterator(root, whatToShow, filter, false);
      }

      ///   
      ///	 <summary> * createNodeIterator
      ///	 *  </summary>
      ///	 * <param name="root"> the root of the iterator </param>
      ///	 * <param name="whatToShow"> the whatToShow mask </param>
      ///	 * <param name="filter"> the node filter (null = no filter) </param>
      ///	 * <param name="entityReferenceExpansion"> true: expand the contents of EntityReference nodes
      ///	 *  </param>
      ///	 * <returns> the newly created NodeIterator </returns>
      ///	 
      public virtual SupportClass.TraversalIteratorSupport createNodeIterator(XmlNode root, int whatToShow, SupportClass.FilterXml filter, bool entityReferenceExpansion)
      {
         return (m_doc == null) ? null : m_doc.createNodeIterator(root, whatToShow, filter, entityReferenceExpansion);
      }

      ///   
      ///	 <summary> * creats a TreeWalker
      ///	 *  </summary>
      ///	 * <param name="root"> the root of the iterator </param>
      ///	 * <param name="whatToShow"> the whatToShow mask </param>
      ///	 * <param name="filter"> the node filter (null = no filter)
      ///	 *  </param>
      ///	 * <returns> the newly created TreeWalker </returns>
      ///	 
      public virtual SupportClass.TraversalIteratorSupport createTreeWalker(XmlNode root, short whatToShow, SupportClass.FilterXml filter)
      {
         return (m_doc == null) ? null : m_doc.createTreeWalker(root, (int)whatToShow, filter, false);
      }

      ///   
      ///	 <summary> * creats a TreeWalker
      ///	 *  </summary>
      ///	 * <param name="root"> the root of the iterator </param>
      ///	 * <param name="whatToShow"> the whatToShow mask </param>
      ///	 * <param name="filter"> the node filter (null = no filter) </param>
      ///	 * <param name="entityReferenceExpansion"> true: expand the contents of EntityReference nodes
      ///	 *  </param>
      ///	 * <returns> the newly created TreeWalker </returns>
      ///	 
      public virtual SupportClass.TraversalIteratorSupport createTreeWalker(XmlNode root, int whatToShow, SupportClass.FilterXml filter, bool entityReferenceExpansion)
      {
         return (m_doc == null) ? null : m_doc.createTreeWalker(root, whatToShow, filter, entityReferenceExpansion);
      }

      ///   
      ///	 <summary> * createRange
      ///	 *  </summary>
      ///	 * <returns> Range </returns>
      ///	 
      // Java to C# Conversion - What is the .NET equivalent of Range
      //public virtual Range createRange()
      //{
      //   return (m_doc == null) ? null : m_doc.createRange();
      //}

      ///   
      ///	 <summary> * create an Event object
      ///	 *  </summary>
      ///	 * <param name="type"> type of Event interface to be created
      ///	 *  </param>
      ///	 * <returns> the newly created Event </returns>
      ///	 
      // Java to C# Conversion - What is the .NET equivalent of Event
      //public virtual Event createEvent(string type)
      //{
      //   return (m_doc == null) ? null : m_doc.createEvent(type);
      //}

      ///   
      ///	 <summary> * clone the document, completely severing all connections to the original document
      ///	 *  </summary>
      ///	 * <returns> Object </returns>
      ///	 * <exception cref="CloneNotSupportedException"> </exception>
      ///	 
      public virtual object clone()
      {
         XMLDoc clon = new XMLDoc();
         if (m_doc != null)
         {
            clon.m_doc = (DocumentJDFImpl)m_doc.clone();
         }
         return clon;
      }

      ///   
      ///	 <summary> * Method getXMLDocUserData - get the associated XMLDocUserData
      ///	 *  </summary>
      ///	 * <returns> XMLDocUserData of this object </returns>
      ///	 
      public virtual XMLDocUserData getXMLDocUserData()
      {
         XMLDocUserData userData = (XMLDocUserData)m_doc.getUserData();

         return userData;
      }

      ///   
      ///	 <summary> * does the owner document of this have an associated XMLDocUserData
      ///	 *  </summary>
      ///	 * <returns> true if XMLDocUserData of this exists </returns>
      ///	 
      protected internal virtual bool hasXMLDocUserData()
      {
         XMLDocUserData userData = (XMLDocUserData)m_doc.getUserData();

         return userData != null;
      }

      ///   
      ///	 <summary> * get/create the associated XMLDocUserData
      ///	 *  </summary>
      ///	 * <returns> the XMLDocUserData of this </returns>
      ///	 
      public virtual XMLDocUserData getCreateXMLDocUserData()
      {
         XMLDocUserData userData = (XMLDocUserData)m_doc.getUserData();
         if (userData == null)
         {
            userData = new XMLDocUserData();
            m_doc.setUserData(userData);
         }

         return userData;
      }

      ///   
      ///	 <summary> * delete the XMLDocUserData structure
      ///	 *  </summary>
      ///	 * <returns> void </returns>
      ///	 
      protected internal virtual void deleteUserData()
      {
         XMLDocUserData userData = (XMLDocUserData)m_doc.getUserData();
         if (userData != null)
         {
            // delete (userData); hopefully the garbage collector will do his
            // stuff
            m_doc.setUserData(null);
         }
      }

      ///   
      ///	 <summary> * get a vector of all IDs of elements that are dirty
      ///	 *  </summary>
      ///	 * <returns> VString - the vector of element IDs </returns>
      ///	 
      public virtual VString getDirtyIDs()
      {
         XMLDocUserData xmlUserData = getXMLDocUserData();
         if (xmlUserData != null)
         {
            return xmlUserData.getDirtyIDs();
         }
         return null;
      }

      ///   
      ///	 <summary> * clear the vector of all IDs of elements that are dirty </summary>
      ///	 
      public virtual void clearDirtyIDs()
      {
         getCreateXMLDocUserData().clearDirtyIDs();
      }

      ///   
      ///	 <summary> * is the node with ID dirty?
      ///	 *  </summary>
      ///	 * <param name="String"> id the id to be checked </param>
      ///	 * <returns> boolean - true if the node with ID=id is dirty </returns>
      ///	 
      public virtual bool isDirty(string strID)
      {
         XMLDocUserData docUserData = getXMLDocUserData();
         return docUserData == null ? false : docUserData.isDirty(strID);
      }

      ///   
      ///	 <summary> * toString
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public override string ToString()
      {
         return write2String(2);
      }

      /// <summary> Encoding.  </summary>
      protected internal const string sm_strENCODING = "UTF-8";

      ///   
      ///	 <summary> * toXML
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public virtual string toXML()
      {
         string strXML = JDFConstants.EMPTYSTRING;
         try
         {
            StringWriter osw = new StringWriter();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
            settings.Indent = false;
            settings.NewLineChars = Environment.NewLine;
            settings.ConformanceLevel = ConformanceLevel.Document;
            XmlWriter writer = XmlTextWriter.Create(osw, settings);

            KElement thisRoot = this.getRoot();
            XmlSerializer serial = new XmlSerializer(this.getDocumentElement().GetType());

            serial.Serialize(writer, this.getDocumentElement());

            strXML = osw.ToString();
         }
         catch (IOException)
         {
            strXML = "XMLDoc.toXML: ### ERROR while serializing " + this.GetType().FullName + " element.";
         }

         return strXML;
      }

      protected internal virtual void setMemberDoc(DocumentJDFImpl myDoc)
      {
         m_doc = myDoc;
         if (m_doc != null)
            getCreateXMLDocUserData();
      }

      ///   
      ///	 <summary> * This method sends the contents of this XMLDoc to the URL <code>strURL</code> and receives the response in the
      ///	 * returned XMLDoc.
      ///	 *  </summary>
      ///	 * <param name="strURL"> the URL to write to </param>
      ///	 * <param name="strContentType"> the content type to write to
      ///	 *  </param>
      ///	 * <returns> docResponse the response received from URL. if url is a file, an empty doc is returned
      ///	 * 
      ///	 *         A Null document if no response was received, or an exception occurred </returns>
      ///	 
      public virtual XMLDoc write2URL(string strURL, string strContentType)
      {
         XMLDoc docResponse = null;
         try
         {
            Uri url = new Uri(strURL);
            string protocol = url.Scheme; // file; ftp; http
            if (protocol.ToLower().Equals("File".ToLower()))
            {
               write2File(UrlUtil.urlToFile(strURL), 0, true);
               docResponse = new XMLDoc();
            }
            else
            {
               HttpWebRequest urlCon = write2HTTPURL(url, strContentType, null);
               JDFParser parser = new JDFParser();
               Stream inStream = urlCon.GetResponse().GetResponseStream();

               parser.parseStream(inStream);
               docResponse = parser == null ? null : new XMLDoc(parser);
            }

            return docResponse;
         }
         catch (IOException)
         {
         }

         return docResponse;
      }

      ///   
      ///	 * <param name="url"> </param>
      ///	 * <param name="strContentType">
      ///	 * @return </param>
      ///	 * <exception cref="IOException"> </exception>
      ///	 
      public virtual HttpWebRequest write2HTTPURL(Uri url, string strContentType, HTTPDetails det)
      {
         for (int i = 0; i < 2; i++)
         {
            try
            {
               HttpWebRequest urlCon = (HttpWebRequest)WebRequest.Create(url);
               // TODO: setDoOutput Not Translated
               //urlCon.setDoOutput(true);
               SupportClass.URLConnectionSupport.SetRequestProperty(urlCon, "Connection", "close");
               SupportClass.URLConnectionSupport.SetRequestProperty(urlCon, "Content-Type", strContentType);
               if (det != null)
               {
                  det.applyTo(urlCon);

               }
               write2Stream(urlCon.GetRequestStream(), 0, true);
               return urlCon;
            }
            catch (IOException)
            {
               StatusCounter.sleep(1000); // wait and retry once
            }
         }
         return null;
      }

      ///   
      ///	 <summary> * register new custom class in the factory
      ///	 *  </summary>
      ///	 * <param name="strElement"> local name </param>
      ///	 * <param name="packagepath"> package path </param>
      ///	 
      public static void registerCustomClass(string strElement, string packagepath)
      {
         DocumentJDFImpl.registerCustomClass(strElement, packagepath);
      }

      ///   
      ///	 <summary> * rough guestimate of the memory used by this if called after parsing
      ///	 *  </summary>
      ///	 * <returns> the difference of memory used when calling compared to construction time </returns>
      ///	 
      public virtual long getDocMemoryUsed()
      {
         return m_doc.getDocMemoryUsed();
      }

      ///   
      ///	 <summary> * get the Javax.Mail.BodyPart
      ///	 *  </summary>
      ///	 * <returns> the BodyPart </returns>
      ///	 
      public virtual Attachment getBodyPart()
      {
         return m_doc.m_Bodypart;
      }

      ///   
      ///	 <summary> * set the Javax.Mail.BodyPart
      ///	 *  </summary>
      ///	 * <param name="bodyPart"> the value to set </param>
      ///	 
      public virtual void setBodyPart(Attachment bodyPart)
      {
         m_doc.m_Bodypart = bodyPart;
      }

      ///   
      ///	 * <returns> Returns the m_OriginalFileName. </returns>
      ///	 
      public virtual string getOriginalFileName()
      {
         return m_doc.m_OriginalFileName;
      }

      ///   
      ///	 * <param name="originalFileName"> The OriginalFileName to set. </param>
      ///	 
      public virtual void setOriginalFileName(string originalFileName)
      {
         m_doc.m_OriginalFileName = originalFileName;
      }

      ///   
      ///	 * <returns> Returns the m_OriginalFileName. </returns>
      ///	 
      public virtual XMLDoc getValidationResult()
      {
         return m_doc.m_validationResult;
      }

      ///   
      ///	 * <param name="nsURI"> the namespace uri to get the schema location for </param>
      ///	 * <returns> String that corresponds to the schema, null if no schemalocation is defined for nsURI </returns>
      ///	 
      public virtual string getSchemaLocation(string nsURI)
      {
         KElement root = getRoot();
         if (root == null)
            return null;
         string schemaloc = root.getAttribute(AttributeName.SCHEMALOCATION, AttributeName.XSI, null);
         if (schemaloc == null)
            return null;
         VString strings = new VString(StringUtil.tokenize(schemaloc, " ", false));
         int indexOfNS = strings.IndexOf(nsURI);
         if (indexOfNS >= 0 && indexOfNS < strings.Count - 1)
            schemaloc = strings.stringAt(indexOfNS + 1);
         else
            return null;

         return schemaloc;
      }

      ///   
      ///	 * <param name="nsURI"> the namespace uri to get the schema location for </param>
      ///	 * <returns> File that corresponds to the schema, null if no readable file is found </returns>
      ///	 
      public virtual FileInfo getSchemaLocationFile(string nsURI)
      {

         string schemaloc = getSchemaLocation(nsURI);
         if (schemaloc == null)
            return null;

         FileInfo f = UrlUtil.urlToFile(schemaloc);
         if (f.Exists) // TODO: canRead() not translated if (f.canRead())
            return f;
         return null;
      }

      ///   
      ///	 <summary> * set xs:schemalocation to
      ///	 *  </summary>
      ///	 * <param name="nsURI"> </param>
      ///	 * <param name="_schemaLocation"> </param>
      ///	 
      public virtual void setSchemaLocation(string nsURI, FileInfo _schemaLocation)
      {
         if ((_schemaLocation != null) && (SupportClass.FileLength(_schemaLocation) > 0))
         {
            string fileToUrl = UrlUtil.fileToUrl(_schemaLocation, false);
            string schemaLocation = nsURI + " " + fileToUrl;
            KElement root = getRoot();
            if (root != null)
               root.setAttribute("xs:" + AttributeName.SCHEMALOCATION, schemaLocation, AttributeName.XSI);
         }
      }

      ///   
      ///	 * <param name="validationResult"> the validationResult to set. </param>
      ///	 
      public virtual void setValidationResult(XMLDoc validationResult)
      {
         m_doc.m_validationResult = validationResult;
      }

      public object Clone()
      {
         throw new NotImplementedException();
      }
   }
}
