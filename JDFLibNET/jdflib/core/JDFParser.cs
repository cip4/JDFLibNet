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


// * Created on Jul 3, 2003
namespace org.cip4.jdflib.core
{
   using System;
   using System.Text;
   using System.IO;
   using System.Xml;
   using System.Xml.Schema;

   using SkipInputStream = org.cip4.jdflib.util.SkipInputStream;
   using UrlUtil = org.cip4.jdflib.util.UrlUtil;

///
/// <summary> * @author matternk </summary>
/// 
   public class JDFParser : DocumentJDFImpl
   {

      ///   
      ///	 <summary> * simple search stream that will find a valid xml wherever it starts
      ///	 * 
      ///	 * @author prosirai
      ///	 *  </summary>
      ///	 
      private class XMLReaderStream : SkipInputStream
      {
         protected internal bool allowClose = false;

         ///      
         ///		 * <param name="searchTag"> </param>
         ///		 * <param name="stream2"> </param>
         ///		 * <param name="ignorecase"> </param>
         ///		 
         public XMLReaderStream(bool searchXML, Stream stream)
            : base(searchXML ? "<?xml" : null, stream, searchXML)
         {
         }

         ///      
         ///		 <summary> * the parser closes on error - something we do not want especially for the underlying stream
         ///		 *  </summary>
         ///		 * <exception cref="IOException"> </exception>
         ///		 
         public virtual void close()
         {
            try
            {
               if (allowClose)
                  base.Close();
            }
            catch (Exception)
            {
               // nop
            }
         }

      }

      public XMLErrorHandler m_ErrorHandler = null;
      public string m_SchemaLocation = null;
      public string m_DocumentClass = typeof(DocumentJDFImpl).FullName;
      public Exception m_lastExcept = null;
      public static bool m_searchStream = false;

      ///   
      ///	 <summary> * set bKElementOnly=true if you want the output ojects all to be instatnces of KElement rather than instantiated
      ///	 * JDF instances </summary>
      ///	 
      public new bool bKElementOnly = false;
      ///   
      ///	 <summary> * set ignoreNSDefault=true if you do not want any heuristics to be performed regarding DOM level 1 / 2 namespace
      ///	 * associations </summary>
      ///	 
      public bool ignoreNSDefault = false;

      ///   
      ///	 <summary> * if true, empty pools and whitespace are removed when parsing </summary>
      ///	 
      public bool m_eraseEmpty = true;

      public JDFParser()
         : base()
      {
      }

      ///   
      ///	 * @deprecated - use default constructor 
      ///	 * <param name="strDocType"> </param>
      ///	 
      [Obsolete("- use default constructor")]
      public JDFParser(string strDocType)
         : this()
      {
      }

      ///   
      ///	 * <param name="parser"> </param>
      ///	 
      public JDFParser(JDFParser parser)
         : this()
      {
         bKElementOnly = parser.bKElementOnly;
         m_eraseEmpty = parser.m_eraseEmpty;
         initParser(m_SchemaLocation, m_DocumentClass);
      }


      //public Element createElementNode(QName element)
      //{
      //   if (fCurrentNode.getLocalName() != null)
      //   {
      //      ((DocumentJDFImpl)(this.fDocument)).setParentNode(fCurrentNode);
      //   }

      //   Element e = super.createElementNode(element);
      //   ((DocumentJDFImpl)(this.fDocument)).setParentNode(null);
      //   return e;

      //}

      /// <summary>
      /// Override the CreateElement() method used by the XmlDocument Load() method
      /// Use the KElement factoryCreate() method to create an element of the right type
      /// </summary>
      /// <param name="prefix"></param>
      /// <param name="localName"></param>
      /// <param name="namespaceURI"></param>
      /// <returns></returns>

      public override XmlElement CreateElement(string prefix, string localName, string namespaceURI)
      {
         string qualifiedName = localName;
         if ((prefix != null) && (prefix.Length > 0))
            qualifiedName = prefix + ":" + localName;

         XmlElement e = factoryCreate(null, namespaceURI, qualifiedName);
         return e;
      }


      ///   
      ///	 <summary> * parseFile - parse a file specified by strFile
      ///	 *  </summary>
      ///	 * <param name="strFile"> link to the document to parse, may be either a file path or a url </param>
      ///	 * <returns> JDFDoc or null if File not found </returns>
      ///	 
      public virtual JDFDoc parseFile(string strFile)
      {
         FileInfo file = UrlUtil.urlToFile(strFile);
         return parseFile(file);
      }

      ///   
      ///	 * <param name="file">
      ///	 * @return </param>
      ///	 
      public virtual JDFDoc parseFile(FileInfo file)
      {
         if (file == null)
            return null;

         JDFDoc doc = null;
         if (file.Exists)  // canRead() Not available in .NET
         {
            try
            {
               doc = parseStream(new FileStream(file.FullName, FileMode.Open));
               if (doc != null)
               {
                  doc.setOriginalFileName(file.FullName);
               }
               return doc;

            }
            catch (FileNotFoundException)
            {
               return null;
            }
         }
         return doc;
      }

      ///   
      ///	 <summary> * parseFile - parse a file specified by strFile
      ///	 *  </summary>
      ///	 * <param name="strFile"> link to the document to parse </param>
      ///	 * <param name="schemaLocation"> link to the schema to use, null if no validation required </param>
      ///	 * <returns> JDFDoc or null if File not found default: parseFile(strFile,null) </returns>
      ///	 * @deprecated set the parser members instead 
      ///	 
      [Obsolete("set the parser members instead")]
      public virtual JDFDoc parseFile(string strFile, string schemaLocation)
      {
         m_SchemaLocation = schemaLocation;
         return parseFile(strFile);
      }

      ///   
      ///	 <summary> * parseString - parse a string specified by stringInput
      ///	 *  </summary>
      ///	 * <param name="stringInput"> string to parse </param>
      ///	 * <returns> JDFDoc or null if parse failed default: parseString(stringInput) </returns>
      ///	 
      public virtual JDFDoc parseString(string stringInput)
      {
         if (stringInput == null)
            return null;
         MemoryStream @is;
         try
         {
            //@is = new ByteArrayInputStream(stringInput.getBytes("UTF-8"));
            Encoding encoding = Encoding.UTF8;
            @is = new MemoryStream(SupportClass.ToByteArray(SupportClass.ToSByteArray(encoding.GetBytes(stringInput))));
         }
         catch (IOException)
         {
            //@is = new ByteArrayInputStream(stringInput.getBytes());
            Encoding encoding = Encoding.Default;
            @is = new MemoryStream(SupportClass.ToByteArray(SupportClass.ToSByteArray(encoding.GetBytes(stringInput))));
         }
         return parseStream(@is);
      }

      ///   
      ///	 <summary> * parseStream - parse a stream specified by inStream
      ///	 *  </summary>
      ///	 * <param name="inStream"> stream to parse </param>
      ///	 * <returns> JDFDoc or null if parse failed default: parseStream(inStream) </returns>
      ///	 
      public virtual JDFDoc parseStream(Stream inStream)
      {
         if (inStream == null)
            return null;
         XMLReaderStream bis = new XMLReaderStream(false, inStream);
         SupportClass.BufferedStreamManager.manager.MarkPosition(0, bis);

         XmlSourceSupport inSource = new XmlSourceSupport(bis);
         JDFDoc d = parseInputSource(inSource);

         if (d == null && m_searchStream)
         {
            try
            {
               bis.Position = SupportClass.BufferedStreamManager.manager.ResetMark(bis);
            }
            catch (IOException)
            {
               bis.allowClose = true;
               bis.close();
               return null;
            }

            inSource = new XmlSourceSupport(new XMLReaderStream(true, bis));
            d = parseInputSource(inSource);
         }
         bis.allowClose = true;
         bis.close();
         return d;
      }

      ///   
      ///	 <summary> * parse an input source
      ///	 *  </summary>
      ///	 * <param name="inSource"> the InputSource to parse </param>
      ///	 
      public virtual void parse(XmlSourceSupport inSource)
      {
         parseInputSource(inSource);
      }

      ///   
      ///	 <summary> * parse an input source
      ///	 *  </summary>
      ///	 * <param name="inSource"> the InputSource to parse </param>
      ///	 * <returns> JDFDoc the newly parsed doc </returns>
      ///	 
      public virtual JDFDoc parseInputSource(XmlSourceSupport inSource)
      {
         JDFDoc jdfDoc = null;
         if (inSource != null)
         {
            initParser(m_SchemaLocation, m_DocumentClass);
            jdfDoc = runParser(inSource, m_eraseEmpty);
         }

         return jdfDoc;
      }

      ///   
      ///	 <summary> * This is the sophisticated parse function, where validation, error handlers et al. can be set
      ///	 *  </summary>
      ///	 * <param name="inSource"> </param>
      ///	 * <param name="schemaLocation"> schema location, null if no validation required </param>
      ///	 * <param name="documentClassName"> </param>
      ///	 * <param name="errorHandler"> </param>
      ///	 * <param name="bEraseEmpty"> if true empty nodes are erased after parsing </param>
      ///	 * <param name="bDoNamespaces"> if false a second parse is done, where namespaces are ignored
      ///	 *  </param>
      ///	 * <returns> JDFDoc
      ///	 * 
      ///	 *         default: parseInputSource(inSource, null, DocumentJDFImpl.class.getName(), null, true, true); </returns>
      ///	 * @deprecated set the parser members instead 
      ///	 
      [Obsolete("set the parser members instead")]
      public virtual JDFDoc parseInputSource(XmlSourceSupport inSource, string schemaLocation, string documentClassName, XmlSaxErrorHandler errorHandler, bool bEraseEmpty, bool bDoNamespaces)
      {
         JDFDoc doc = null;
         if (errorHandler is XMLErrorHandler)
         {
            initParser(schemaLocation, documentClassName);
         }
         else
         {
            initParser(schemaLocation, documentClassName);
         }

         doc = runParser(inSource, bEraseEmpty);
         if (doc == null)
         { // this is the error case:
            if (!bDoNamespaces)
            {
               // try again, ignoring name spaces
               setIgnoreNamespace(false);
               doc = runParser(inSource, bEraseEmpty);
            }
         }

         return doc;
      }

      ///   
      ///	 * <param name="schemaLocation"> </param>
      ///	 * <param name="documentClassName"> </param>
      ///	 * <param name="ErrorHandler"> default: initParser(null, DocumentJDFImpl.class.getName(), null); </param>
      ///	 
      private void initParser(string schemaLocation, string documentClassName)
      {
         m_SchemaLocation = schemaLocation;
         m_DocumentClass = documentClassName;

         try
         {
            if (m_SchemaLocation == null || m_SchemaLocation.Equals(JDFConstants.EMPTYSTRING))
            {
               this.setFeature("http://xml.org/sax/features/validation", false);
               this.setFeature("http://apache.org/xml/features/validation/schema", false);
            }
            else
            {
               if (!m_SchemaLocation.StartsWith(JDFElement.getSchemaURL()))
                  m_SchemaLocation = JDFElement.getSchemaURL() + " " + m_SchemaLocation;
               this.setFeature("http://xml.org/sax/features/validation", true);
               this.setFeature("http://apache.org/xml/features/validation/schema", true);
               // this.setFeature(
               // "http://apache.org/xml/features/validation/schema/element-default"
               // , false);
               // this.setFeature(
               // "http://apache.org/xml/features/validation/schema/normalized-value"
               // , false);
               this.setProperty("http://apache.org/xml/properties/schema/external-schemaLocation", m_SchemaLocation);
            }

            // use our own JDF document for creating JDF elements
            this.setProperty("http://apache.org/xml/properties/dom/document-class-name", documentClassName);

            this.setFeature("http://apache.org/xml/features/dom/defer-node-expansion", false);
            this.setFeature("http://xml.org/sax/features/namespaces", true);

         }
         catch (Exception e)
         {
            m_lastExcept = e;
         }
      }


      ///   
      ///	 * <param name="parser"> </param>
      ///	 * <param name="inSource"> </param>
      ///	 * <param name="bEraseEmpty">
      ///	 * @return </param>
      ///	 
      private JDFDoc runParser(XmlSourceSupport inSource, bool bEraseEmpty)
      {

         JDFDoc doc = new JDFDoc();
         try
         {
            XmlReaderSettings settings = new XmlReaderSettings();
            XmlReader reader = XmlTextReader.Create(inSource.Bytes, settings);
            base.Load(reader);
            doc.setMemberDoc((DocumentJDFImpl)this);
            if (bEraseEmpty)
            {
               doc.getRoot().eraseEmptyNodes(true); // cleanup the XML
            }
         }
         catch (StackOverflowException)
         {
            m_lastExcept = null;
            doc = null;
         }
         catch (Exception e)
         {
            m_lastExcept = e;
            doc = null;
         }

         if (doc != null && m_ErrorHandler != null)
         {
            doc.setValidationResult(m_ErrorHandler.getXMLOutput());
            m_ErrorHandler.cleanXML(m_SchemaLocation);
         }

         if (doc != null)
         {
            KElement root = doc.getRoot();
            DocumentJDFImpl memberDocument = doc.getMemberDocument();
            string namespaceURI = root.getNamespaceURI();
            if (namespaceURI == null || !namespaceURI.ToLower().Contains(JDFConstants.CIP4ORG))
            {
               memberDocument.bKElementOnly = true;
               memberDocument.setIgnoreNSDefault(true);
            }
            else
            {
               memberDocument.setIgnoreNSDefault(ignoreNSDefault);
            }
         }
         return doc;
      }

      private void setIgnoreNamespace(bool toSet)
      {
         try
         {
            this.setFeature("http://xml.org/sax/features/namespaces", toSet);
            this.setFeature("http://xml.org/sax/features/validation", toSet);
         }
         catch (Exception e)
         {
            m_lastExcept = e;
         }
      }

      ///   
      ///	 * <param name="_schemaLocation"> the schema location </param>
      ///	 
      public virtual void setJDFSchemaLocation(FileInfo _schemaLocation)
      {
         if (_schemaLocation != null && _schemaLocation.Length != 0)
         {
            string fileToUrl = UrlUtil.fileToUrl(_schemaLocation, false);
            m_SchemaLocation = "http://www.CIP4.org/JDFSchema_1_1 " + fileToUrl;
         }
      }



      ///   
      ///	 <summary> * (non-Javadoc) reset all internal variables to a reasonable default
      ///	 *  </summary>
      ///	 * <seealso cref= org.apache.xerces.parsers.AbstractDOMParser#reset() </seealso>
      ///	 
      public virtual void cleanup()
      {
         bKElementOnly = false;
         m_lastExcept = null;
         ignoreNSDefault = false;
         m_eraseEmpty = true;
         m_ErrorHandler = null;
         m_SchemaLocation = null;
         m_DocumentClass = typeof(DocumentJDFImpl).FullName;
      }

      private void setFeature(string name, bool value)
      {
         // Java to C# Conversion - TODO: Do we need to implement this?
      }

      private void setProperty(string name, string value)
      {
         // Java to C# Conversion - TODO: Do we need to implement this?
      }
   }
}

