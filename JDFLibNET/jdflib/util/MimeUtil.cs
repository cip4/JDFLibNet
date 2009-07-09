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
 * Created on Jul 5, 2006, 11:45:44 AM
 * org.cip4.jdflib.util.MimeUtil,cs
 * Project Name: mimeutil 
 */

namespace org.cip4.jdflib.util
{
   using System;
   using System.Runtime.CompilerServices;
   using System.Collections;
   using System.Collections.Generic;
   using System.Text;
   using System.Net;
   using System.Net.Mail;
   using System.Net.Mime;
   using System.Web;
   using System.IO;


   using IOUtils = org.apache.commons.io.IOUtils;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFParser = org.cip4.jdflib.core.JDFParser;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using XMLDoc = org.cip4.jdflib.core.XMLDoc;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using JDFCommand = org.cip4.jdflib.jmf.JDFCommand;
   using JDFJMF = org.cip4.jdflib.jmf.JDFJMF;
   using JDFResponse = org.cip4.jdflib.jmf.JDFResponse;
   using JDFNode = org.cip4.jdflib.node.JDFNode;



   ///
   /// <summary> * MIME utilities for reading and writing MIME/MULTIPART/RELATED streams
   /// * 
   /// * @author Markus Nyman, (markus.cip4@myman.se)
   /// *  </summary>
   /// 
   public class MimeUtil : UrlUtil
   {

      ///   
      ///	 <summary> * helper class to set mime details
      ///	 * 
      ///	 * @author prosirai
      ///	 *  </summary>
      ///	 
      public class MIMEDetails
      {
         ///      
         ///		 <summary> * http details </summary>
         ///		 
         public HTTPDetails httpDetails = new HTTPDetails();
         ///      
         ///		 <summary> * transfer encoding used when streaming body parts, May be null to specify java default behavior </summary>
         ///		 
         public static string defaultTransferEncoding = BINARY;
         public string transferEncoding = defaultTransferEncoding;
         public bool modifyBoundarySemicolon = false;
      }

      ///   
      ///	 <summary> * used for some after the fact cleanup - beware as it may hurt performance
      ///	 * 
      ///	 * @author prosirai
      ///	 *  </summary>
      ///	 
      private class FixSemiColonStream : Stream
      {
         private BufferedStream m_BufferedStream;
         private bool done = false;
         private int pos = 0;

         private sbyte[] smallBuf = new sbyte[5000];

         ///      
         ///		 * <param name="out"> </param>
         ///		 
         public FixSemiColonStream(Stream _out)
         {
            m_BufferedStream = new BufferedStream(_out);
         }

         //      
         //		 * (non-Javadoc)
         //		 * 
         //		 * @see java.io.BufferedOutputStream#write(int)
         //		 
         [MethodImpl(MethodImplOptions.Synchronized)]
         public void write(int b)
         {
            if (!done) // insert a ' ' where necessary...
            {
               if (pos == smallBuf.Length)
               {
                  smallBuf = null;
                  done = true;
               }
               else
               {
                  smallBuf[pos++] = (sbyte)b;
                  int first = Math.Max(0, pos - 50);
                  if (b == ';')
                  {
                     string s = new string(SupportClass.ToCharArray(smallBuf), first, pos - 1);
                     if (s.ToLower().IndexOf("content-type:") > 0)
                     {
                        smallBuf = null;
                        done = true;
                        m_BufferedStream.WriteByte(Convert.ToByte('\n'));
                     }
                  }
               }
            }
            m_BufferedStream.WriteByte(Convert.ToByte(b));
         }

         //      
         //		 * (non-Javadoc)
         //		 * 
         //		 * @see java.io.BufferedOutputStream#write(byte[], int, int)
         //		 
         [MethodImpl(MethodImplOptions.Synchronized)]
         public void write(sbyte[] b, int off, int len)
         {
            if (done)
            {
               m_BufferedStream.Write(SupportClass.ToByteArray(b), off, len);
            }
            else
            {
               for (int i = off; i < len; i++)
                  write(b[i]);
            }
         }

         public override void Close()
         {
            m_BufferedStream.Close();
         }

         public override void Flush()
         {
            m_BufferedStream.Flush();
         }

         public override bool CanRead
         {
            get { return m_BufferedStream.CanRead; }
         }

         public override bool CanSeek
         {
            get { return m_BufferedStream.CanSeek; }
         }

         public override bool CanWrite
         {
            get { return m_BufferedStream.CanWrite; }
         }

         public override long Length
         {
            get { return m_BufferedStream.Length; }
         }

         public override long Position
         {
            get
            {
               return m_BufferedStream.Position;
            }
            set
            {
               m_BufferedStream.Position = value;
            }
         }

         public override void SetLength(long value)
         {
            m_BufferedStream.SetLength(value);
         }

         public override int Read(byte[] buffer, int offset, int count)
         {
            return m_BufferedStream.Read(buffer, offset, count);
         }

         public override void Write(byte[] buffer, int offset, int count)
         {
            m_BufferedStream.Write(buffer, offset, count);
         }

         public override long Seek(long offset, SeekOrigin origin)
         {
            return m_BufferedStream.Seek(offset, origin);
         }
      }

      ///   
      ///	 <summary> * data source for binary files
      ///	 * 
      ///	 * @author prosirai
      ///	 *  </summary>
      ///	 
      public class ByteArrayDataSource : System.Windows.Forms.IDataObject
      {
         internal string contenType;
         internal ByteArrayIOStream ioStream;

         ///      
         ///		 <summary> * create a data source from a byte array
         ///		 *  </summary>
         ///		 * <param name="ioStream"> the ByteArrayIOStream to use </param>
         ///		 * <param name="_contentType"> the content type of the contents </param>
         ///		 
         public ByteArrayDataSource(ByteArrayIOStream _ioStream, string _contentType)
         {
            contenType = _contentType;
            ioStream = _ioStream;
         }

         //      
         //		 * (non-Javadoc)
         //		 * 
         //		 * @see javax.activation.DataSource#getContentType()
         //		 
         public virtual string getContentType()
         {
            return contenType;
         }

         //      
         //		 * (non-Javadoc)
         //		 * 
         //		 * @see javax.activation.DataSource#getInputStream()
         //		 
         public virtual Stream getInputStream()
         {
            return ioStream.getInputStream();
         }

         //      
         //		 * (non-Javadoc)
         //		 * 
         //		 * @see javax.activation.DataSource#getName()
         //		 
         public virtual string getName()
         {
            // not needed
            return null;
         }

         //      
         //		 * (non-Javadoc)
         //		 * 
         //		 * @see javax.activation.DataSource#getOutputStream()
         //		 
         public virtual Stream getOutputStream()
         {
            return ioStream;
         }

         //UPGRADE_TODO: The following method was automatically generated and it must be implemented in order to preserve the class logic. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1232'"
         virtual public System.Object GetData(System.String format, System.Boolean autoConvert)
         {
            return null;
         }
         //UPGRADE_TODO: The following method was automatically generated and it must be implemented in order to preserve the class logic. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1232'"
         virtual public System.Object GetData(System.String format)
         {
            return null;
         }
         //UPGRADE_TODO: The following method was automatically generated and it must be implemented in order to preserve the class logic. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1232'"
         virtual public System.Object GetData(System.Type format)
         {
            return null;
         }
         //UPGRADE_TODO: The following method was automatically generated and it must be implemented in order to preserve the class logic. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1232'"
         virtual public void SetData(System.String format, System.Boolean autoConvert, System.Object data)
         {
         }
         //UPGRADE_TODO: The following method was automatically generated and it must be implemented in order to preserve the class logic. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1232'"
         virtual public void SetData(System.String format, System.Object data)
         {
         }
         //UPGRADE_TODO: The following method was automatically generated and it must be implemented in order to preserve the class logic. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1232'"
         virtual public void SetData(System.Type format, System.Object data)
         {
         }
         //UPGRADE_TODO: The following method was automatically generated and it must be implemented in order to preserve the class logic. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1232'"
         virtual public void SetData(System.Object data)
         {
         }
         //UPGRADE_TODO: The following method was automatically generated and it must be implemented in order to preserve the class logic. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1232'"
         virtual public System.Boolean GetDataPresent(System.String format, System.Boolean autoConvert)
         {
            return false;
         }
         //UPGRADE_TODO: The following method was automatically generated and it must be implemented in order to preserve the class logic. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1232'"
         virtual public System.Boolean GetDataPresent(System.String format)
         {
            return false;
         }
         //UPGRADE_TODO: The following method was automatically generated and it must be implemented in order to preserve the class logic. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1232'"
         virtual public System.Boolean GetDataPresent(System.Type format)
         {
            return false;
         }
         //UPGRADE_TODO: The following method was automatically generated and it must be implemented in order to preserve the class logic. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1232'"
         virtual public System.String[] GetFormats(System.Boolean autoConvert)
         {
            return null;
         }
         //UPGRADE_TODO: The following method was automatically generated and it must be implemented in order to preserve the class logic. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1232'"
         virtual public System.String[] GetFormats()
         {
            return null;
         }
      }

      ///   
      ///	 <summary> * commonly used strings </summary>
      ///	 

      public const string MULTIPART_RELATED = "multipart/related";

      private static Dictionary<string, string> extensionMap = null;

      // private static Logger log = Logger.getLogger(MimeUtil.class);
      ///   
      ///	 <summary> *  </summary>
      ///	 

      public static void setContentID(Attachment bp, string cid)
      {
         if (cid == null)
            return;

         try
         {
            bp.ContentId = "<" + urlToCid(cid).Substring(4) + ">";
         }
         catch (HttpException)
         {
            // nop
         }
      }

      ///   
      ///	 <summary> * set the filename header of a bodypart to a string
      ///	 *  </summary>
      ///	 * <param name="bp"> the bodypart </param>
      ///	 * <param name="path"> the path to set
      ///	 *  </param>
      ///	 
      public static void setFileName(Attachment bp, string path)
      {
         if (path == null)
            return;
         try
         {
            bp = new Attachment(new System.IO.FileInfo(path).Name);
         }
         catch (HttpException)
         {
            // nop
         }
      }

      ///   
      ///	 <summary> * get the filename header of a bodypart a string if no file name is set, a unique filename is generated from cid
      ///	 * and content type
      ///	 *  </summary>
      ///	 * <param name="bp"> the bodypart
      ///	 *  </param>
      ///	 * <returns> the file name </returns>
      ///	 
      public static string getFileName(Attachment bp)
      {
         string s = null;
         try
         {
            s = bp.Name;
            if (s != null)
               return s;
         }
         catch (HttpException)
         {
            // nop
         }
         // TODO handle extensions here
         s = getContentID(bp);
         return s;
      }

      ///   
      ///	 <summary> * get the ContentID header of a bodypart a string
      ///	 *  </summary>
      ///	 * <param name="bp"> the bodypart
      ///	 *  </param>
      ///	 * <returns> the cid, null if there was an error </returns>
      ///	 
      public static string getContentID(Attachment bp)
      {
         string[] cids = new string[1];
         try
         {
            cids[0] = bp.ContentId;
         }
         catch (HttpException)
         {
            return null;
         }
         string s = StringUtil.setvString(cids, null, null, null);
         if (s == null)
            return s;

         return urlToCid(s).Substring(4);
      }

               	 
      /// <summary>
      /// Get the MIME Attachment from a multiPart package with a given cid
      /// </summary>
      /// <param name="mp">The multipart package to search in </param>
      /// <param name="cid">The cid of the requested attachment</param>
      /// <returns>The matching attachment, null if none is found </returns>
      /// 
      public static Attachment GetPartByCID(AttachmentCollection attachments, string cid)
      {
         foreach (Attachment attachment in attachments)
         {
            if (MatchesCID(attachment, cid))
               return attachment;
         }
         return null;
      }

      	 
      /// <summary>
      /// Get the MIME attachment from the attachment package with a given cid. Create one if it does not exist
      /// </summary>
      /// <param name="attachments">the attachment collection to search in </param>
      /// <param name="cid">the cid of the requested attachment</param>
      /// <returns>The matching attachment or new attachment if none is found </returns>
      /// 
      public static Attachment GetCreatePartByCID(AttachmentCollection attachments, string cid)
      {
         Attachment attachment = GetPartByCID(attachments, cid);
         if (attachment != null)
            return attachment;

         // Java to C# Conversion - TODO: Need a file name or a stream to create a new Attachment
         attachment = new Attachment("FileName");
         try
         {
            attachment.ContentId = cid;
            attachments.Add(attachment);
         }
         catch (HttpException)
         {
            attachment = null;
         }
         return attachment;
      }


      ///   
      ///	 <summary> * get the JDF Doc from a given body part
      ///	 *  </summary>
      ///	 * <param name="bp"> the BodyPart to search in </param>
      ///	 * <returns> JDFDoc the parsed xml JDFDoc, null if bp does not contain xml </returns>
      ///	 
      public static JDFDoc getJDFDoc(Attachment bp)
      {
         if (bp == null)
            return null;

         try
         {
            string mimeType = bp.ContentType.Name;
            if (!IsJDFMimeType(mimeType))
               return null;
            Stream @is = bp.ContentStream;
            JDFParser p = new JDFParser();
            JDFDoc doc = p.parseStream(@is);
            if (doc != null)
               doc.setBodyPart(bp);
            return doc;
         }
         catch (IOException)
         {
            return null; // snafu
         }
         catch (HttpException)
         {
            return null; // snafu
         }
      }

         
      /// <summary>
      /// Check if an Attachment matches a given cid
      /// </summary>
      /// <param name="bp">the Attachment to check </param>
      /// <param name="cid">the cid string any '<' '>' or 'cid:' prefixes are removed if null, anything matches</param>
      /// <returns>true if this attachment matches the cid </returns>
      /// 
      public static bool MatchesCID(Attachment attachment, string cid)
      {
         string cidLocal = cid;

         if (cidLocal == null)
            return true; // wildcard

         if (cidLocal.StartsWith("<"))
            cidLocal = cidLocal.Substring(1);

         if (cidLocal.ToLower().StartsWith("cid:"))
            cidLocal = cidLocal.Substring(4);

         if (cidLocal.EndsWith(">"))
            cidLocal = cidLocal.Substring(0, cidLocal.Length - 1);

         string s = attachment.ContentId;
         if (s == null)
            return false;

         return cidLocal.ToLower().Equals(s.ToLower());
      }

         
      /// <summary>
      /// Helper to create a root multipart from a file
      /// </summary>
      /// <param name="fileName">The name of the file used as input</param>
      /// <returns>The Multipart that represents the root mime, null if something went wrong </returns>
      /// 
      public static AttachmentCollection GetMultiPart(string fileName)
      {
         FileInfo f = urlToFile(fileName);
         try
         {
            // MUST be SharedFileInputStream, as the body part retrieving methods rely on the stream remaining open!
            // Java to C# Conversion - TODO: Do we need to find an equivalent of Java's SharedFileInputStream for this?
            Stream fis = new FileStream(f.FullName, FileMode.Open);
            return MimeUtil.GetMultiPart(fis);
         }
         catch (FileNotFoundException)
         {
            return null;
         }
         catch (IOException)
         {
            return null;
         }
      }

      
	   /// <summary>
	   /// Create a root multipart from an input stream
	   /// </summary>
	   /// <param name="mimeStream">The input stream</param>
	   /// <returns>The Multipart that represents the root mime, null if something went wrong </returns>
      public static AttachmentCollection GetMultiPart(Stream mimeStream)
      {
         if (mimeStream == null)
            return null;

         try
         {
            MailMessage mimeMessage = new MailMessage();


            // Java to C# Conversion - TODO: Not translated
            //mimeMessage.getDataHandler().getDataSource();
            throw new NotImplementedException("Need to implement stream to MailMessage");

            //return mimeMessage.Attachments;
         }
         catch (HttpException)
         {
            return null;
         }
      }

      ///   
      ///	 <summary> * checkst whether the mime type corresponds to one of "application/vnd.cip4-jdf+xml";
      ///	 * "application/vnd.cip4-jmf+xml"; "text/xml";
      ///	 *  </summary>
      ///	 * <param name="mimeType"> the string to test </param>
      ///	 * <returns> true if matches </returns>
      ///	 
      public static string getMimeTypeFromExt(string fileName)
      {
         if (fileName == null)
            return TEXT_UNKNOWN;
         string ext = UrlUtil.extension(fileName);
         if (ext == null)
            return TEXT_UNKNOWN;
         ext = ext.ToLower();
         fillExtensionMap();
         ext = extensionMap[ext];
         return ext == null ? TEXT_UNKNOWN : ext;
      }


      private static void fillExtensionMap()
      {
         if (extensionMap == null)
         {
            extensionMap = new Dictionary<string, string>();

            extensionMap.Add("jdf", VND_JDF);

            extensionMap.Add("jmf", VND_JMF);

            extensionMap.Add("xml", TEXT_XML);
            extensionMap.Add("xsl", TEXT_XML);
            extensionMap.Add("xsd", TEXT_XML);

            extensionMap.Add("txt", TEXT_PLAIN);

            extensionMap.Add("mjm", MULTIPART_RELATED);
            extensionMap.Add("mjd", MULTIPART_RELATED);
            extensionMap.Add("mim", MULTIPART_RELATED);
         }
      }

               	 
      /// <summary>
      /// Checks whether the mime type corresponds to one of "application/vnd.cip4-jdf+xml", 
      /// "application/vnd.cip4-jmf+xml", or "text/xml"
      /// </summary>
      /// <param name="mimeType">The string to test </param>
      /// <returns>true if matches</returns>
      /// 
      public static bool IsJDFMimeType(string mimeType)
      {
         string mimeTypeLocal = mimeType;

         if (mimeTypeLocal == null)
            return false;

         int posSemicolon = mimeTypeLocal.IndexOf(";");
         if (posSemicolon > 0)
            mimeTypeLocal = mimeTypeLocal.Substring(0, posSemicolon);

         return JDFConstants.MIME_JDF.ToLower().Equals(mimeTypeLocal.ToLower()) || JDFConstants.MIME_JMF.ToLower().Equals(mimeTypeLocal.ToLower()) || JDFConstants.MIME_TEXTXML.ToLower().Equals(mimeTypeLocal.ToLower());
      }


      ///   
      ///	 * @deprecated use 3 parameter version 
      ///	 
      [Obsolete("use 3 parameter version")]
      public static AttachmentCollection buildMimePackage(JDFDoc docJMF, JDFDoc docJDF)
      {
         return buildMimePackage(docJMF, docJDF, true);
      }

      ///   
      ///	 <summary> * build a MIME package that contains all references in all FileSpecs of a given JDFDoc the doc is modified so that
      ///	 * all URLs are cids
      ///	 *  </summary>
      ///	 * <param name="docJMF"> the JDFDoc representation of the JMF that references the jdf to package, if null only the jdf is
      ///	 *            packaged note that the URL of docJDF must already be specified as a CID </param>
      ///	 * <param name="docJDF"> the JDFDoc representation of the JDF to package </param>
      ///	 * <param name="extendReferenced"> if true, also package any further reeferenced files
      ///	 *  </param>
      ///	 * <returns> a Message representing the resulting MIME package, null if an error occured </returns>
      ///	 
      public static AttachmentCollection buildMimePackage(JDFDoc docJMF, JDFDoc docJDF, bool extendReferenced)
      {
         // Create a MIME package
         MailMessage message = new MailMessage();
         // Java to C# Conversion - TODO: Need some work here.
         AttachmentCollection multipart = null; ;  // new MimeMultipart("related"); // JDF:
         // multipart/related

         string cid = null;
         if (docJDF != null)
         {
            string originalFileName = docJDF.getOriginalFileName();
            if (KElement.isWildCard(originalFileName))
               originalFileName = "TheJDF.jdf";

            cid = urlToCid(originalFileName);
         }

         if (docJMF != null && cid != null)
         {
            KElement e = docJMF.getRoot();
            VElement v = e.getChildrenByTagName(null, null, new JDFAttributeMap(AttributeName.URL, "*"), false, false, 0);
            if (v != null)
            {
               int siz = v.Count;
               for (int i = 0; i < siz; i++)
                  v.item(i).setAttribute(AttributeName.URL, cid);
            }
            updateXMLMultipart(multipart, docJMF, null);
         }

         if (extendReferenced)
            extendMultipart(multipart, docJDF, cid);
         else
            updateXMLMultipart(multipart, docJDF, cid);

         // Put parts in message
         try
         {
            SupportClass.MailMessageSupport.AddAttachments(message, multipart);
         }
         catch (HttpException)
         {
            return null;
         }

         return multipart;
      }

      ///   
      ///	 <summary> * Adds a JDF document to a multipart. Any files referenced by the JDF document using FileSpec/@URL are also
      ///	 * included in the multipart.
      ///	 *  </summary>
      ///	 * <param name="multipart"> the multipart to add the JDF document to </param>
      ///	 * <param name="docJDF"> the JDF document </param>
      ///	 * <param name="cid"> the CID the JDF document should have in the multipart </param>
      ///	 * <returns> the number of files added to the multipart </returns>
      ///	 
      private static int extendMultipart(AttachmentCollection multipart, JDFDoc docJDF, string cid)
      {
         int n = 0;

         if (docJDF == null)
         {
            return 0;
         }

         // Get all FileSpec elements
         KElement e = docJDF.getRoot();
         VElement fileSpecs = e.getChildrenByTagName(ElementName.FILESPEC, null, new JDFAttributeMap(AttributeName.URL, "*"), false, false, 0);
         if (fileSpecs != null)
         {
            int vSize = fileSpecs.Count;

            string[] urlStrings = listURLs(fileSpecs);
            for (int i = 0; i < urlStrings.Length; i++)
            {
               if (urlStrings[i] != null)
               {
                  // Convert URL to CID and update FileSpec
                  FileInfo f = UrlUtil.urlToFile(urlStrings[i]);

                  // Java to C# Conversion - No .NET equivalent for isAbsolute()
                  if (f != null) //&& !f.isAbsolute())
                  {
                     // Resolve relative URLs
                     if (docJDF.getOriginalFileName() != null)
                     {
                        FileInfo jdfFile = new FileInfo(docJDF.getOriginalFileName());
                        f = new System.IO.FileInfo(jdfFile.DirectoryName + "\\" + f.FullName);
                        try
                        {
                           urlStrings[i] = SupportClass.FileSupport.ToUri(f).ToString();

                        }
                        catch (UriFormatException)
                        {
                           // nop
                        }
                     }
                  }
                  // Java to C# Conversion - No .NET equivalent for canRead()
                  if (f == null || !f.Exists) //!f.canRead())
                  {
                     // Ignore unreadable files
                     urlStrings[i] = null;
                  }
                  else
                  {
                     // Update FileSpec's URL
                     fileSpecs.item(i).setAttribute(AttributeName.URL, urlToCid(urlStrings[i]), null);
                  }
                  // Set duplicate URLs to null so that the file is only added
                  // once to multipart
                  for (int j = 0; j < i; j++)
                  {
                     if (urlStrings[i] != null && urlStrings[i].Equals(urlStrings[j]))
                     {
                        urlStrings[i] = null;
                     }
                  }
               }
            }

            updateXMLMultipart(multipart, docJDF, cid);

            // add a new body part for each url
            for (int i = 0; i < vSize; i++)
            {
               string urlString = urlStrings[i];
               if (urlString != null)
               {
                  try
                  {
                     System.Windows.Forms.IDataObject dataSrc = null;
                     FileInfo f = UrlUtil.urlToFile(urlString);
                     // Java to C# Conversion - No .NET equivalent for canRead
                     if (f != null && f.Exists) // f.canRead())
                     {
                        dataSrc.SetData(f);
                     }

                     if (dataSrc == null)
                     {
                        continue; // no data source
                     }

                     Attachment messageBodyPart = new Attachment(f.Name);
                     // Java to C# Conversion - TODO: What are we trying to do here?
                     //messageBodyPart = new Attachment(((FileInfo)new DataHandler(dataSrc).getData("System.IO.FileInfo")).ToString());

                     setFileName(messageBodyPart, f == null ? null : f.FullName);
                     // messageBodyPart.setHeader("Content-Type",
                     // JMFServlet.JDF_CONTENT_TYPE); // JDF:
                     // application/vnd.cip4-jdf+xml
                     setContentID(messageBodyPart, urlString);
                     multipart.Add(messageBodyPart);
                     n++;
                  }
                  catch (HttpException)
                  {
                     // nop
                  }
               }
            }
         }

         return n;
      }

      ///   
      ///	 <summary> * Returns the values of the <i>URL</i> attribute of each element in the input list.
      ///	 *  </summary>
      ///	 * <param name="fileSpecs"> a list of elements with <i>URL</i> attributes </param>
      ///	 * <returns> an array containing the value of the <i>URL</i> attribute of each element in the input list. The order of
      ///	 *         values in the returned array corresponds to the order of the elements in the input list. </returns>
      ///	 
      private static string[] listURLs(VElement fileSpecs)
      {
         string[] urlStrings = new string[0];

         if (fileSpecs != null)
         {
            int vSize = fileSpecs.Count;
            urlStrings = new string[vSize];
            for (int i = 0; i < vSize; i++)
            {
               urlStrings[i] = fileSpecs.item(i).getAttribute(AttributeName.URL, null, null);
            }
         }

         return urlStrings;
      }


      private static string urlToCid(string urlString)
      {
         string urlStringLocal = urlString;

         if (urlStringLocal == null)
            return null;

         if (urlStringLocal.StartsWith("<"))
            urlStringLocal = urlStringLocal.Substring(1);

         if (urlStringLocal.ToLower().StartsWith("cid:"))
            urlStringLocal = urlStringLocal.Substring(4);

         if (urlStringLocal.EndsWith(">"))
            urlStringLocal = urlStringLocal.Substring(0, urlStringLocal.Length - 1);

         return "cid:" + new FileInfo(urlStringLocal).Name;
      }


      ///   
      ///	 <summary> * Builds a MIME package.
      ///	 *  </summary>
      ///	 * <param name="vXMLDocs"> the Vector of XMLDoc representing the JMF and JDFs to be stored as the first part of the package
      ///	 *            t </param>
      ///	 * <returns> a Message representing the resulting MIME package, null if an error occured </returns>
      ///	 
      public static AttachmentCollection buildMimePackage(ArrayList vXMLDocs)
      {
         if (vXMLDocs == null || vXMLDocs.Count == 0)
            return null;

         // Create a MIME package
         MailMessage message = new MailMessage();
         AttachmentCollection multipart = null; //new MimeMultipart("related"); // JDF:
         // multipart/related
         // Add other body parts
         int imax = vXMLDocs.Count;
         for (int i = 0; i < imax; i++)
         {
            XMLDoc d1 = (XMLDoc)vXMLDocs[i];
            updateXMLMultipart(multipart, d1, null);
         }
         // Put parts in message
         try
         {
            SupportClass.MailMessageSupport.AddAttachments(message, multipart);
         }
         catch (HttpException)
         {
            return null;
         }

         return multipart;
      }


      public static Attachment updateXMLMultipart(AttachmentCollection multipart, XMLDoc xmlDoc, string cid)
      {
         string cidLocal = cid;

         if (xmlDoc == null)
            return null;

         string originalFileName = xmlDoc.getOriginalFileName();
         if (cidLocal == null)
            cidLocal = originalFileName;

         if (cidLocal == null)
         {
            KElement root = xmlDoc.getRoot();
            cidLocal = "CID_" + ((root is JDFNode && root.hasAttribute(AttributeName.ID)) ? ((JDFNode)root).getID() : JDFElement.uniqueID(0));
         }

         Attachment messageBodyPart = GetCreatePartByCID(multipart, cidLocal);
         try
         {
            setFileName(messageBodyPart, originalFileName);
            setContent(messageBodyPart, xmlDoc);
            setContentID(messageBodyPart, cidLocal);
         }
         catch (HttpException)
         {
            // skip this one
         }
         catch (IOException)
         {
            // skip this one
         }

         return messageBodyPart;
      }

      ///   
      ///	 <summary> * sets the content of a bodypart to the xmlDoc - correctly handling non-ascii features and setting the correct
      ///	 * content type
      ///	 *  </summary>
      ///	 * <param name="messageBodyPart"> the BodyPart to fill </param>
      ///	 * <param name="xmlDoc"> the xmlDoc to fill in </param>
      ///	 * <exception cref="MessagingException"> </exception>
      ///	 
      public static void setContent(Attachment messageBodyPart, XMLDoc xmlDoc)
      {
         if (messageBodyPart == null || xmlDoc == null)
            throw new HttpException("null parameters in setContent");

         // TODO better performing solution for multibyte this quick hack makes
         // quite a few copies...
         ByteArrayIOStream ios = new ByteArrayIOStream();
         xmlDoc.write2Stream(ios, 0, true);
         ByteArrayDataSource ds = new MimeUtil.ByteArrayDataSource(ios, "text/xml");

         // Java to C# Conversion - TODO: What are we trying to do here?
         // messageBodyPart = new System.Web.Mail.MailAttachment(((System.IO.FileInfo)new DataHandler(ds).getData("System.IO.FileInfo")).ToString());
         xmlDoc.setBodyPart(messageBodyPart);
         KElement root = xmlDoc.getRoot();
         if (root is JDFJMF)
         {
            // Java to C# Conversion - TODO:  Not Converted yet
            //messageBodyPart.setHeader(CONTENT_TYPE, JDFConstants.MIME_JMF); // JDF
            // :
            // application
            // /
            // vnd
            // .
            // cip4
            // -
            // jmf
            // +
            // xml
         }
         else if (root is JDFNode)
         {
            // Java to C# Conversion - TODO:  Not Converted yet
            //messageBodyPart.setHeader(CONTENT_TYPE, JDFConstants.MIME_JDF); // JDF
            // :
            // application
            // /
            // vnd
            // .
            // cip4
            // -
            // jmf
            // +
            // xml
         }

      }



      ///   
      ///	 <summary> * write a Multipart to an output URL File: and http: are currently supported Use HttpURLConnection.getInputStream()
      ///	 * to retrieve the http response
      ///	 *  </summary>
      ///	 * <param name="mp"> the mime MultiPart to write </param>
      ///	 * <param name="strUrl"> the URL to write to
      ///	 *  </param>
      ///	 * <returns> <seealso cref="HttpURLConnection"/> the opened http connection, null in case of error or file
      ///	 *  </returns>
      ///	 * <exception cref="IOException"> </exception>
      ///	 * <exception cref="MessagingException"> </exception>
      ///	 
      public static HttpWebRequest writeToURL(AttachmentCollection mp, string strUrl)
      {
         return writeToURL(mp, strUrl, null);
      }

      ///   
      ///	 <summary> * write a Multipart to an output URL File: and http: are currently supported Use HttpURLConnection.getInputStream()
      ///	 * to retrieve the http response
      ///	 *  </summary>
      ///	 * <param name="mp"> the mime MultiPart to write </param>
      ///	 * <param name="strUrl"> the URL to write to
      ///	 *  </param>
      ///	 * <returns> <seealso cref="HttpURLConnection"/> the opened http connection, null in case of error or file
      ///	 *  </returns>
      ///	 * <exception cref="IOException"> </exception>
      ///	 * <exception cref="MessagingException"> </exception>
      ///	 

      public static HttpWebRequest writeToURL(AttachmentCollection mp, string strUrl, MIMEDetails ms)
      {
         MIMEDetails msLocal = ms;

         HttpWebRequest httpURLconnection = null;

         if (msLocal == null)
            msLocal = new MIMEDetails();

         Uri url = new Uri(strUrl);
         if (url.IsFile)
         {
            writeToFile(mp, UrlUtil.urlToFile(strUrl).FullName, msLocal);
         }
         else
         // assume http
         {
            httpURLconnection = (HttpWebRequest)WebRequest.Create(url);
            httpURLconnection.Method = POST;
            SupportClass.URLConnectionSupport.SetRequestProperty(httpURLconnection, "Connection", "close");
            // Java to C# Conversion - TODO: How to extract Content type from array of attachments
            //string contentType = mp.getContentType();
            string contentType = "";
            contentType = StringUtil.token(contentType, 0, "\r");
            contentType = StringUtil.token(contentType, 0, "\n");
            SupportClass.URLConnectionSupport.SetRequestProperty(httpURLconnection, CONTENT_TYPE, contentType);
            // Java to C# Conversion - No .NET Equivalent for for setDoOutput()
            //httpURLconnection.setDoOutput(true);
            if (msLocal.httpDetails != null)
               msLocal.httpDetails.applyTo(httpURLconnection);

            try
            {
               Stream @out = httpURLconnection.GetRequestStream();
               WriteToStream(mp, @out, msLocal);
            }
            catch (System.Exception)
            {
               httpURLconnection = null;
            }
         }

         return httpURLconnection;
      }

      ///   
      ///	 <summary> * submit a multipart file to a queue
      ///	 *  </summary>
      ///	 * <param name="mp"> </param>
      ///	 * <param name="strUrl">
      ///	 * @return </param>
      ///	 * <exception cref="IOException"> </exception>
      ///	 * <exception cref="MessagingException"> </exception>
      ///	 
      public static JDFDoc writeToQueue(JDFDoc docJMF, JDFDoc docJDF, string strUrl, MIMEDetails urlDet)
      {
         JDFDoc doc = null;

         AttachmentCollection mp = buildMimePackage(docJMF, docJDF, true);
         HttpWebRequest uc = writeToURL(mp, strUrl, urlDet);
         if (uc == null)
            return doc; // file

         // Java to C# Conversion - TODO: How do we get Response code?
         int rc = 200; // uc.getResponseCode();
         if (rc == 200)
         {
            Stream inputStream = uc.GetResponse().GetResponseStream();
            BufferedStream bis = new BufferedStream(inputStream);
            SupportClass.BufferedStreamManager.manager.MarkPosition(100000, bis);
            AttachmentCollection mpRet = GetMultiPart(bis);
            if (mpRet != null)
            {
               try
               {
                  Attachment bp = (Attachment)mpRet[0];
                  doc = getJDFDoc(bp);
                  return doc;
               }
               catch (HttpException)
               {
                  // nop - try simple doc
               }
            }

            bis.Position = SupportClass.BufferedStreamManager.manager.ResetMark(bis);
            doc = new JDFParser().parseStream(bis);
            if (doc == null)
            {
               JDFCommand c = docJMF.getJMFRoot().getCommand(0);
               JDFJMF respJMF = c.createResponse();
               JDFResponse r = respJMF.getResponse(0);
               r.setErrorText("Invalid attached JDF");
               r.setReturnCode(3); // TODO correct rcs
               doc = respJMF.getOwnerDocument_JDFElement();
            }
         }
         else
         {
            JDFCommand c = docJMF.getJMFRoot().getCommand(0);
            JDFJMF respJMF = c.createResponse();
            JDFResponse r = respJMF.getResponse(0);
            r.setErrorText("Invalid http response - RC=" + rc);
            r.setReturnCode(3); // TODO correct rcs
            doc = respJMF.getOwnerDocument_JDFElement();
         }

         return doc;
      }

      ///   
      ///	 <summary> * @deprecated </summary>
      ///	 * <param name="m"> </param>
      ///	 * <param name="fileName">
      ///	 * @return </param>
      ///	 
      [Obsolete]
      public static FileInfo writeToFile(AttachmentCollection m, string fileName)
      {
         return writeToFile(m, fileName, null);
      }

      ///   
      ///	 <summary> * write a Multipart to an output file
      ///	 *  </summary>
      ///	 * <param name="mp"> the mime MultiPart to write </param>
      ///	 * <param name="outStream"> the existing output stream
      ///	 *  </param>
      ///	 * <exception cref="IOException"> </exception>
      ///	 * <exception cref="MessagingException"> </exception>
      ///	 
      public static FileInfo writeToFile(AttachmentCollection m, string fileName, MIMEDetails md)
      {
         FileInfo file = new FileInfo(fileName);
         try
         {
            FileStream fos = new FileStream(file.FullName, FileMode.OpenOrCreate);
            WriteToStream(m, fos, md);
            return file;
         }
         catch (FileNotFoundException)
         {
            return null;
         }
         catch (IOException)
         {
            return null;
         }
         catch (HttpException)
         {
            return null;
         }
      }

      ///   
      ///	 <summary> * @deprecated </summary>
      ///	 * <param name="m"> </param>
      ///	 * <param name="outStream"> </param>
      ///	 * <exception cref="IOException"> </exception>
      ///	 * <exception cref="MessagingException"> </exception>
      ///	 
      [Obsolete]
      public static void writeToStream(AttachmentCollection m, Stream outStream)
      {
         WriteToStream(m, outStream, null);
      }
      	 

      /// <summary>
      /// Write a Multipart to a Stream
      /// </summary>
      /// <param name="attachments">The mime MultiPart to write</param>
      /// <param name="outStream">The existing output stream, note that a buffered output stream is created 
      /// in case outStream is unbuffered</param>
      /// <param name="md">MIME Details</param>
      ///  
      public static void WriteToStream(AttachmentCollection attachments, Stream outStream, MIMEDetails md)
      {
         Stream outStreamLocal = outStream;

         MailMessage mm = new MailMessage();
         SupportClass.MailMessageSupport.AddAttachments(mm, attachments);
         // buffers are good - the encoders decoders otherwise hit stream
         // read/write once per byte...
         if (!(outStreamLocal is BufferedStream))
            outStreamLocal = new BufferedStream(outStreamLocal);

         if (md != null && md.modifyBoundarySemicolon)
         {
            outStreamLocal = new FixSemiColonStream(outStreamLocal);
         }

         if (md != null && md.transferEncoding != null)
         {
            foreach (Attachment attachment in attachments)
            {
               // Java to C# Conversion - TODO: What should transfer encoding be
               //setHeader(UrlUtil.CONTENT_TRANSFER_ENCODING, md.transferEncoding);
               attachment.TransferEncoding = TransferEncoding.Unknown;
            }

         }

         // Java to C# Conversion - TODO: To write mail message to stream see http://www.codeproject.com/KB/IP/smtpclientext.aspx
         //                         For an example of using the internal MailWriter type to do this.
         //mm.writeTo(outStreamLocal);

         outStreamLocal.Flush();
         outStreamLocal.Close();
      }


      /// <summary>
      /// Write a Message to a directory
      /// </summary>
      /// <param name="attachments">The mime parts to write </param>
      /// <param name="directory">The directory to use as '.' for writing the mime parts </param>
      ///
      public static void WriteToDir(AttachmentCollection attachments, DirectoryInfo directory)
      {
         if (!directory.Exists)
            directory.Create();

         foreach (Attachment attachment in attachments)
         {
            WriteBodyPartToFile(attachment, directory);
            // TODO update urls to the new file values
         }
      }

	 
      /// <summary>
      /// Write a MIME message attachment to a file in the given directory
      /// </summary>
      /// <param name="attachment">The attachment to write</param>
      /// <param name="directory">The directory to place the file into</param>
      /// 
      public static void WriteBodyPartToFile(Attachment attachment, DirectoryInfo directory)
      {
         if (!directory.Exists)
            directory.Create();

         string fileName = getFileName(attachment);
         FileInfo outFile = new FileInfo(directory.FullName + Path.DirectorySeparatorChar.ToString() + fileName);
         BufferedStream fos = new BufferedStream(new FileStream(outFile.FullName, FileMode.Open));
         Stream ins = attachment.ContentStream;
         IOUtils.copy(ins, fos);
         fos.Flush();
         fos.Close();
      }

         
	   /// <summary>
	   /// Gets the JMF document of a submitqueueentry or returnqueuentry and the attached jdf document
	   /// </summary>
	   /// <param name="mp">The Multipart to search </param>
	   /// <returns>One or two JDFDocs: bp[0] is the jmf, bp[1] is the jdf, if a JDF is referenced</returns>
      /// 
      public static JDFDoc[] GetJMFSubmission(AttachmentCollection mp)
      {
         //Attachment[] bp = getBodyParts(mp);
         if (mp == null || mp.Count < 1)
            return null;
         JDFDoc jmf = getJDFDoc(mp[0]);
         JDFJMF jmfRoot = jmf == null ? null : jmf.getJMFRoot();
         if (jmfRoot == null)
            return null;
         string subURL = jmfRoot.getSubmissionURL();

         if (subURL == null)
         {
            return new JDFDoc[] { jmf };
         }
         Attachment bpJDF = GetPartByCID(mp, subURL);
         JDFDoc[] docs = new JDFDoc[2];
         docs[0] = jmf;
         docs[1] = getJDFDoc(bpJDF);
         if (docs[1] == null)
            return new JDFDoc[] { jmf };
         return docs;
      }


      /// <summary>
      /// Get the content in the form of a string from the given attachment
      /// </summary>
      /// <param name="attachment">Attachment to get the content from</param>
      /// <returns>content string or null if not found</returns>
      /// 
      public static string GetAttachmentContent(Attachment attachment)
      {
         StringBuilder sb = new StringBuilder();
         int i = -1;
         while ((i = attachment.ContentStream.ReadByte()) != -1)
         {
            sb.Append((char)i);
         }
         if (sb.Length > 0)
            return sb.ToString();
         else
            return null;
      }


      /// <summary>
      /// Set the content of the given attachment, of necessity content type must be text.
      /// </summary>
      /// <param name="attachment">Attachment to set the content to</param>
      /// <param name="content">content string</param>
      /// 
      public static void SetAttachmentContent(Attachment attachment, string content)
      {
         if (content.Length > 0)
         {
            attachment.ContentType = new ContentType(JDFConstants.MIME_TEXTXML);
            byte[] ba = Encoding.Default.GetBytes(content);
            attachment.ContentStream.Write(ba, 0, content.Length);
         }
      }
   }
}


