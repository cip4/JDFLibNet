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


/*
 * Copyright (c) 2001 Heidelberger Druckmaschinen AG, All Rights Reserved.
 * UrlUtil.cs
 * Last changes
 */

namespace org.cip4.jdflib.util
{
   using System;
   using System.Collections;
   using System.IO;
   using System.Net;
   using System.Net.Mail;
   using System.Net.Mime;
   using System.Web;
   using System.Text;


   using IOUtils = org.apache.commons.io.IOUtils;
   using StringUtils = org.apache.commons.lang.StringUtils;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using VString = org.cip4.jdflib.core.VString;

   ///
   /// <summary> * collection of helper routines to convert urls
   /// * 
   /// * @author prosirai
   /// *  </summary>
   /// 
   public class UrlUtil
   {
      public const string POST = "POST";
      public const string GET = "GET";
      public const string CONTENT_TRANSFER_ENCODING = "Content-Transfer-Encoding";

      ///   
      ///	 <summary> * helper class to set mime details
      ///	 * 
      ///	 * @author prosirai
      ///	 *  </summary>
      ///	 
      public class HTTPDetails
      {
         ///      
         ///		 <summary> * size of http chunks to be written, if <=0 no chunks </summary>
         ///		 
         public int chunkSize = defaultChunkSize;
         public static int defaultChunkSize = 10000;

         ///      
         ///		 <summary> * apply these details to the connection specified
         ///		 *  </summary>
         ///		 * <param name="urlCon"> </param>
         ///		 
         public virtual void applyTo(HttpWebRequest urlCon)
         {
            if (urlCon != null)
            {
               if (chunkSize > 0)
               {
                  urlCon.SendChunked = true;
                  // Java to C# Conversion - QUESTION: Is there anyplace to set Chunk Size in .NET?
                  //urlCon.setChunkedStreamingMode(chunkSize);
               }
            }
         }
      }

      ///   
      ///	 <summary> * simple struct to contain the stream and type of a bodypart
      ///	 * 
      ///	 * @author prosirai
      ///	 *  </summary>
      ///	 
      public class UrlPart
      {
         ///      
         ///		 * <param name="connection"> </param>
         ///		 * <exception cref="IOException"> </exception>
         ///		 
         public UrlPart(HttpWebRequest connection)
         {
            inStream = connection.GetResponse().GetResponseStream();
            long contentLength;
            try
            {
               contentLength = connection.GetResponse().ContentLength;
            }
            catch (System.IO.IOException)
            {
               contentLength = -1;
            }
            ContentLength = contentLength;
            string contentType;
            try
            {
               contentType = connection.GetResponse().ContentType;
            }
            catch (System.ArgumentNullException)
            {
               contentType = null;
            }
            ContentType = contentType;
         }

         ///      
         ///		 * <param name="part"> </param>
         ///		 * <exception cref="MessagingException"> </exception>
         ///		 * <exception cref="IOException"> </exception>
         ///		 
         public UrlPart(Attachment part)
         {
            inStream = part.ContentStream;
            ContentLength = part.ContentStream.Length;
            ContentType = part.ContentType.Name;
         }

         public Stream inStream;
         public string ContentType;
         public long ContentLength;
      }

      // public static final String m_URIEscape = "%?:@&=+$,[]";
      public const string m_URIEscape = "%?@&=+$,[]";
      public const string TEXT_HTML = "text/html";
      public const string TEXT_PLAIN = "text/plain";
      public const string TEXT_UNKNOWN = JDFConstants.MIME_TEXTUNKNOWN;
      public const string TEXT_XML = JDFConstants.MIME_TEXTXML;
      public const string VND_JDF = JDFConstants.MIME_JDF;
      public const string VND_JMF = JDFConstants.MIME_JMF;
      public const string CONTENT_ID = "Content-ID";
      ///   
      ///	 <summary> * commonly used strings </summary>
      ///	 
      public const string CONTENT_TYPE = "Content-Type";
      public const string BASE64 = "base64";
      public const string BINARY = "binary";

      ///   
      ///	 <summary> * returns the relative URL of a file relative to the current working directory
      ///	 *  </summary>
      ///	 * <param name="f"> the file to get the relative url for </param>
      ///	 * <param name="baseDir"> the file that describes cwd, if <code>null</code> cwd is calculated </param>
      ///	 * <param name="bEscape128"> if true, escape > 128 (URL), else retain (IRL)
      ///	 * @return </param>
      ///	 
      public static string getRelativeURL(FileInfo f, FileInfo baseDir, bool bEscape128)
      {
         string relPath = getRelativePath(f, baseDir);
         if (relPath == null)
         {
            return fileToUrl(f, true);
         }

         relPath = StringUtil.replaceChar(relPath, '\\', "/", 0);
         sbyte[] utf8 = StringUtil.setUTF8String(relPath);
         relPath = new System.String(SupportClass.ToCharArray(SupportClass.ToByteArray(utf8)));
         relPath = StringUtil.escape(relPath, m_URIEscape, "%", 16, 2, 0x21, bEscape128 ? 128 : -1);
         return relPath;
      }

      ///   
      ///	 <summary> * returns the relative URL of a file relative to the current working directory<br>
      ///	 * this includes escaping of %20 etc.
      ///	 *  </summary>
      ///	 * <param name="f"> the file to get the relative path for </param>
      ///	 * <param name="fCWD"> the file that describes cwd, if <code>null</code> cwd is calculated
      ///	 * @return </param>
      ///	 
      public static string getRelativePath(FileInfo f, FileInfo fCWD)
      {
         FileInfo fCWDLocal = fCWD;

         if (fCWDLocal == null)
            fCWDLocal = new FileInfo(System.Environment.CurrentDirectory);

         string cPath = null;
         string cwd = null;
         try
         {
            cPath = f.FullName;
            // just in case...
            cwd = fCWDLocal.FullName;
            if (cPath[0] != cwd[0])
               return null; // incompatible abs paths

         }
         catch (IOException)
         {
            return null;
         }
         VString vCwd = new VString(StringUtil.tokenize(cwd, Path.PathSeparator.ToString(), false));
         VString vPath = new VString(StringUtil.tokenize(cPath, Path.PathSeparator.ToString(), false));

         int lenPath = vPath.Count;
         int size = vCwd.Count;
         if (lenPath < size)
            size = lenPath;
         for (int i = 0; i < size; i++)
         {
            if (vCwd.stringAt(0).Equals(vPath.stringAt(0)))
            {
               vCwd.RemoveAt(0);
               vPath.RemoveAt(0);
            }
            else
            {
               break;
            }
         }
         lenPath = vPath.Count;
         size = vCwd.Count;
         string prefix = (size == 0) ? "." : "..";

         for (int i = 1; i < size; i++)
            prefix += "/..";

         string s = lenPath == 0 ? prefix : StringUtil.setvString(vPath, Path.PathSeparator.ToString(), prefix + Path.PathSeparator.ToString(), null);
         return cleanDots(s);
      }

               	 
      /// <summary>
      /// Get a readable inputstream from the CID url
      /// </summary>
      /// <param name="url">The url to get a stream for </param>
      /// <param name="multipart">The multipart mime to which the cid refers</param>
      /// <returns>The readable input stream that this filespec refers to, or null if broken or non-existent</returns>
      /// 
      public static Stream GetCidURLStream(string url, AttachmentCollection multipart)
      {
         if (url == null || url.Equals(JDFConstants.EMPTYSTRING))
            return null;
         System.Net.Mail.Attachment bp = MimeUtil.GetPartByCID(multipart, url);
         if (bp == null)
            return null;

         try
         {
            return bp.ContentStream;
         }
         catch (System.IO.IOException)
         {
            /* */
         }
         catch (System.Web.HttpException)
         {
            /* */
         }
         return null; // snafu exit
      }



      ///   
      ///	 <summary> * get the filename extension of pathName
      ///	 *  </summary>
      ///	 * <param name="pathName"> the pathName to get the extension for </param>
      ///	 * <returns> String - the filename extension </returns>
      ///	 
      public static string extension(string pathName)
      {
         if (pathName == null)
            return null;

         int index = pathName.LastIndexOf(".");
         return (index == -1) ? null : pathName.Substring(index + 1);
      }

      ///   
      ///	 <summary> * get the filename extension of pathName
      ///	 *  </summary>
      ///	 * <param name="pathName"> the pathName to get the extension for </param>
      ///	 * <returns> String - the filename extension </returns>
      ///	 
      public static string removeExtension(string pathName)
      {
         if (pathName == null)
            return null;

         int index = pathName.LastIndexOf(".");
         return (index == -1) ? pathName : pathName.Substring(0, index);
      }

         
      /// <summary>
      /// Get an array of urlparts, regardless of whether this was mime or not if the stream is mime/multipart also extract that
      /// </summary>
      /// <param name="connection">Web request/response</param>
      /// <returns>The array of body parts input stream </returns>
      /// 
      public static UrlPart[] GetURLParts(HttpWebRequest connection)
      {
         if (connection == null)
            return null;

         string contentType;
         try
         {
            contentType = connection.GetResponse().Headers.Get("Content-Type");
         }
         catch (ArgumentNullException)
         {
            contentType = null;
         }
         
         string urlContentType = contentType;

         if (!MimeUtil.MULTIPART_RELATED.ToLower().Equals(urlContentType.ToLower()))
         {
            UrlPart p;
            try
            {
               p = new UrlPart(connection);
            }
            catch (IOException)
            {
               return null;
            }
            return new UrlPart[] { p };
         }

         AttachmentCollection attachments;
         try
         {
            attachments = MimeUtil.GetMultiPart(connection.GetResponse().GetResponseStream());
         }
         catch (IOException)
         {
            return null;
         }

         if (attachments == null)
            return null;
         UrlPart[] parts = new UrlPart[attachments.Count];

         int i = 0;
         foreach(Attachment attatchment in attachments)
         {
            try
            {
               ContentType ct = attatchment.ContentType;
               parts[i] = new UrlPart(attatchment);
            }
            catch (HttpException)
            {
               parts[i] = null;
            }
            catch (IOException)
            {
               parts[i] = null;
            }
            ++i;
         }
         return parts;
      }

      ///   
      ///	 <summary> * get the opened input stream for a given url string
      ///	 *  </summary>
      ///	 * <param name="urlString"> </param>
      ///	 * <param name="bodyPart">
      ///	 * @return </param>
      ///	 
      public static Stream getURLInputStream(string urlString, Attachment bodyPart)
      {
         Stream retStream = null;
         if (isCID(urlString) || bodyPart != null)
         {
            if (bodyPart != null)
            {
               // Java to C# Conversion - TODO: This doesn't make any sense.
               //ArrayList multipart = bodyPart.getParent();
               //retStream = getCidURLStream(urlString, multipart);
            }
         }
         if (retStream == null && isHttp(urlString))
         {
            try
            {
               Uri url = new Uri(urlString);
               HttpWebRequest urlConnection = (HttpWebRequest)WebRequest.Create(url);
               retStream = urlConnection.GetResponse().GetResponseStream();
            }
            catch (UriFormatException)
            {
               //
            }
            catch (IOException)
            {
               //
            }
         }
         if (retStream == null) // assume file
         {
            FileInfo f = urlToFile(urlString);
            if ((f != null)) // No .NET equivalent for canRead && f.canRead())
            {
               try
               {
                  retStream = new FileStream(f.FullName, FileMode.Open, FileAccess.Read);
               }
               catch (FileNotFoundException)
               {
                  //
               }
            }
         }
         return retStream;
      }

      ///   
      ///	 <summary> * create a new directory and return null if the directory could not be created
      ///	 *  </summary>
      ///	 * <param name="newDir"> the path or URL of the new directory </param>
      ///	 
      public static FileInfo getCreateDirectory(string newDir)
      {
         FileInfo f = UrlUtil.urlToFile(newDir);
         if (f == null)
            return null;
         bool tmpBool;
         if (File.Exists(f.FullName))
            tmpBool = true;
         else
            tmpBool = Directory.Exists(f.FullName);
         if (!tmpBool)
         {
            Directory.CreateDirectory(f.FullName);
         }
         if (Directory.Exists(f.FullName))
            return null;
         return f;
      }

      ///   
      ///	 <summary> * Convert a File to a valid file URL or IRL<br>
      ///	 * note that some internal functions use network protocol and therefor performance may be non-optimal
      ///	 *  </summary>
      ///	 * <param name="f"> the File to parse, </param>
      ///	 * <param name="bEscape128"> if true, escape non -ascii chars (URI), if false, don't (IRI) </param>
      ///	 * <returns> the URL string </returns>
      ///	 
      public static string fileToUrl(FileInfo f, bool bEscape128)
      {
         if (f == null)
            return null;
         string s = f.FullName;
         if (Path.DirectorySeparatorChar.ToString().Equals("\\"))
            s = StringUtil.replaceChar(s, '\\', "/", 0);
         s = UrlUtil.cleanDots(s);
         if (bEscape128)
         {
            s = new string(SupportClass.ToCharArray(SupportClass.ToByteArray(StringUtil.setUTF8String(s))));
            s = StringUtil.escape(s, m_URIEscape, "%", 16, 2, 0x21, 127);
         }
         else
         {
            s = StringUtil.escape(s, m_URIEscape, "%", 16, 2, 0x21, 0x7fffffff);
         }
         // if(s.length()>2 && s.charAt(1)==':' && File.separator.equals("\\"))
         // s=s.charAt(0)+s.substring(2);
         if (s[0] != '/')
            s = "///" + s;

         return "file:" + s;
      }

      ///   
      ///	 <summary> * Retrieve a file for a relative or absolute file url
      ///	 *  </summary>
      ///	 * <param name="urlString"> the file url to retrieve a file for </param>
      ///	 * <returns> the file located at url </returns>
      ///	 
      public static FileInfo urlToFile(string urlString)
      {
         string urlStringLocal = urlString;

         if (urlStringLocal == null)
            return null;

         if (isCID(urlStringLocal) || isHttp(urlStringLocal))
            return null;

         if (urlStringLocal.ToLower().StartsWith("file:"))
            urlStringLocal = urlStringLocal.Substring(5); // remove "file:"

         // See if we can get a file without further processing
         try
         {
            FileInfo f = new FileInfo(urlStringLocal);
            if ((f != null) && (f.Exists))
               return f;
         }
         catch (Exception)
         {
         }

         if (Path.DirectorySeparatorChar.ToString().Equals("\\")) // on windows
         {
            if (urlStringLocal.StartsWith("///") && urlStringLocal.Length > 5 && urlStringLocal[4] == '/')
               urlStringLocal = urlStringLocal[3] + ":" + urlStringLocal.Substring(4);
            else if (urlStringLocal.StartsWith("/") && urlStringLocal.Length > 3 && urlStringLocal[2] == '/' && urlStringLocal[1] != '/')
               urlStringLocal = urlStringLocal[1] + ":" + urlStringLocal.Substring(2);
            else if (urlStringLocal.StartsWith("///"))
               urlStringLocal = urlStringLocal.Substring(3);

            urlStringLocal = StringUtil.replaceChar(urlStringLocal, '/', "\\", 0);
         }

         urlStringLocal = new string(SupportClass.ToCharArray(SupportClass.ToByteArray(StringUtil.setUTF8String(urlStringLocal)))); // ensure that any non-utf8 gets encoded to utf-8
         urlStringLocal = StringUtil.unEscape(urlStringLocal, "%", 16, 2);
         //urlStringLocal = StringUtil.getUTF8String(urlStringLocal.getBytes());
         Encoding encoding = Encoding.Default;
         urlStringLocal = StringUtil.getUTF8String(SupportClass.ToSByteArray(encoding.GetBytes(urlStringLocal)));

         return new FileInfo(urlStringLocal);
      }

      ///   
      ///	 <summary> * Create a URL for any  url string using heuristics and escaping
      ///	 *  </summary>
      ///	 * <param name="urlString"> the file url to retrieve a file for
      ///	 * @return </param>
      ///	 
      public static Uri StringToURL(string urlString)
      {
         string urlStringLocal = urlString;

         Uri url = null;

         if (urlStringLocal == null)
            return url;

         if (isEscaped(urlStringLocal))
            urlStringLocal = StringUtil.unEscape(urlStringLocal, "%", 16, 2);

         try
         {
            if (isCID(urlStringLocal) || isHttp(urlStringLocal))
            {
               url = new Uri(urlStringLocal);
            }
            else
            {
               url = new Uri(fileToUrl(urlToFile(urlStringLocal), true));
            }
         }
         catch (UriFormatException)
         {
            // nop
         }

         return url;
      }

      ///   
      ///	 <summary> * checks whether there is a remote chance that the file is useful for reading
      ///	 *  </summary>
      ///	 * <param name="f"> - File to check </param>
      ///	 * <returns> true if the file is ok </returns>
      ///	 
      public static bool isFileOK(FileInfo f)
      {
         //return f != null && !f.isDirectory() && f.canRead();
         return f != null && !Directory.Exists(f.FullName); // No .NET version of canRead();

      }

      ///   
      ///	 <summary> * test whether a given url is escaped as utf-8
      ///	 *  </summary>
      ///	 * <param name="url"> the url to test
      ///	 * @return </param>
      ///	 
      public static bool isEscaped(string url)
      {
         if (url == null)
            return false;
         int posColon = url.IndexOf(":");
         int posEscapedColon = url.ToLower().IndexOf("%3a");
         if (posColon < 0 && posEscapedColon < 0)
            return false;

         if (posColon < 0)
            posColon += int.MaxValue;
         if (posEscapedColon < 0)
            posEscapedColon += int.MaxValue;
         return posEscapedColon < posColon;
      }

      ///   
      ///	 <summary> * test whether a given url is a cid
      ///	 *  </summary>
      ///	 * <param name="url"> the url to test
      ///	 * @return </param>
      ///	 
      public static bool isCID(string url)
      {
         string urlLocal = url;

         if (urlLocal == null)
            return false;
         if (urlLocal.StartsWith("<"))
            urlLocal = urlLocal.Substring(1);
         string lowerURL = urlLocal.ToLower();
         return lowerURL.StartsWith("cid:");
      }

      public static bool isWindowsLocalPath(string pathName)
      {
         if (pathName == null || pathName.Length <= 1 || isUNC(pathName))
            return false;
         return StringUtils.isAlpha(pathName.Substring(0, 1)) && pathName.Substring(1, 2).Equals(":") || StringUtils.countMatches(pathName, "\\") > StringUtils.countMatches(pathName, "/");

      }



      ///   
      ///	 <summary> * test whether a given url is a relative or absolute file path
      ///	 *  </summary>
      ///	 * <param name="url"> the url to test
      ///	 * @return </param>
      ///	 
      public static bool isHttp(string url)
      {
         if (url == null)
            return false;
         string lowerURL = url.ToLower();
         return lowerURL.StartsWith("http://");
      }

      public static bool isUNC(string pathName)
      {
         if (pathName == null || pathName.Length == 0)
            return false;
         return pathName.StartsWith("\\\\");
      }

      ///   
      ///	 <summary> * check whether a file is a mime file only check extensions TODO sniff file rather than check extensions
      ///	 *  </summary>
      ///	 * <param name="file"> the FILE to check </param>
      ///	 * <returns> true if the file is a MIME file </returns>
      ///	 

      public static bool isMIME(FileInfo file)
      {
         string packageName;
         try
         {
            packageName = file.FullName;
         }
         catch (IOException)
         {
            return false;
         }
         string lower = packageName.ToLower();
         return isMIMEExtenstension(lower);
      }

      ///   
      ///	 <summary> * check whether a file is a mime file
      ///	 *  </summary>
      ///	 * <param name="lower">
      ///	 * @return </param>
      ///	 
      public static bool isMIMEExtenstension(string lower)
      {
         string lowerLocal = lower;

         lowerLocal = extension(lowerLocal);
         if (lowerLocal == null)
            return false;

         return lowerLocal.ToLower().Equals("mjm".ToLower()) || lowerLocal.ToLower().Equals("mjd".ToLower()) || lowerLocal.ToLower().Equals("mim".ToLower());
      }

      ///   
      ///	 * <param name="val">
      ///	 * @return </param>
      ///	 
      public static bool isIRL(string val)
      {
         char[] c = val.ToCharArray();
         bool bFix = false;
         for (int i = 0; i < c.Length; i++)
            if (c[i] > 127)
            {
               c[i] = 'a'; // any valid char
               bFix = true;
            }

         return isURL(bFix ? new string(c) : val);
      }

      ///   
      ///	 * <param name="val">
      ///	 * @return </param>
      ///	 
      public static bool isURL(string val)
      {
         try
         {
            Uri uri = new Uri(val);
            string scheme = uri.Scheme;
            if (scheme != null && scheme.ToLower().StartsWith("http"))
            {
               if (uri.Host == null)
                  return false;
            }
            // add any other exceptions here
         }
         catch (UriFormatException)
         {
            return false;
         }
         return val.Length < 4096;
      }

      ///   
      ///	 <summary> * concatenate directory and url to a single path IF and only IF url is a relative url<br>
      ///	 * relative urls MUST NOT have a scheme (e.g. file:)
      ///	 *  </summary>
      ///	 * <param name="directory"> the url of the directory </param>
      ///	 * <param name="url"> the absolute url </param>
      ///	 * <returns> String - the local URL of url after removing directory </returns>
      ///	 
      public static string getLocalURL(string directory, string url)
      {
         if (directory == null || url == null)
            return url;
         int len = directory.Length;
         if (len > 0 && !directory.EndsWith("/"))
            len++;
         if (url.Length <= len)
            return null;
         if (!url.StartsWith(directory))
            return null;
         return url.Substring(len);
      }

      ///   
      ///	 <summary> * concatenate directory and url to a single path IF and only IF url is a relative url<br>
      ///	 * relative urls MUST NOT have a scheme (e.g. file:)
      ///	 *  </summary>
      ///	 * <param name="directory"> the url of the directory </param>
      ///	 * <param name="url"> the relative url of the file </param>
      ///	 * <returns> String - the concatenated URL of the directory + file </returns>
      ///	 
      public static string getURLWithDirectory(string directory, string url)
      {
         string directoryLocal = directory;
         string urlLocal = url;

         if (directoryLocal == null || JDFConstants.EMPTYSTRING.Equals(directoryLocal))
            return urlLocal;

         if (urlLocal == null)
            return directoryLocal;

         if (urlLocal.IndexOf(":") > 0 && ((urlLocal.IndexOf("/") < 0) || urlLocal.IndexOf("/") > urlLocal.IndexOf(":"))) // has
            // scheme
            return urlLocal;

         if (urlLocal.StartsWith("/"))
         {
            try
            {
               Uri dirURI = new Uri(directoryLocal);
               directoryLocal = dirURI.Scheme + ":";
               if (!urlLocal.StartsWith("//"))
                  urlLocal = "/" + urlLocal;
            }
            catch (UriFormatException)
            {
               // nop
            }
         }

         if (!directoryLocal.EndsWith("/") && !urlLocal.StartsWith("/"))
            directoryLocal += "/";

         return cleanDots(directoryLocal + urlLocal);
      }

      ///   
      ///	 <summary> * remove any internal "../" "./" and "//" from a url
      ///	 *  </summary>
      ///	 * <param name="url"> the url to clean </param>
      ///	 * <returns> String - the clean path </returns>
      ///	 
      public static string cleanDots(string url)
      {
         if (url == null)
            return null;
         string dummy = url;
         int posDouble = url.IndexOf("//");
         string prefix = url.StartsWith("/") ? "/" : "";
         if (posDouble >= 0)
         {
            prefix = url.Substring(0, posDouble + 2);
            dummy = url.Substring(posDouble + 2);
         }
         VString vs = new VString(StringUtil.tokenize(dummy, "/", false));
         for (int i = vs.Count - 1; i > 0; i--)
         {
            if (vs.stringAt(i).Equals("") || vs.stringAt(i).Equals("."))
            {
               vs.RemoveAt(i);
            }
         }
         for (int i = vs.Count - 1; i > 0; i--)
         {
            if (vs.stringAt(i).Equals(".."))
            {
               for (int j = i - 1; j >= 0; j--)
               {
                  if (!vs.stringAt(j).Equals(".."))
                  {
                     vs.RemoveAt(i--);
                     vs.RemoveAt(j);
                     break;
                  }
               }
            }
         }

         return prefix + (vs.IsEmpty() ? "." : StringUtil.setvString(vs, "/", null, null));
      }

      ///   
      ///	 <summary> * write a Stream to an output URL File: and http: are currently supported Use HttpURLConnection.getInputStream() to
      ///	 * retrieve the http response
      ///	 *  </summary>
      ///	 * <param name="strUrl"> the URL to write to </param>
      ///	 * <param name="sream"> the input stream to read from </param>
      ///	 * <param name="method"> GET or POST </param>
      ///	 * <param name="contentType"> the contenttype to set MUST BE SET! </param>
      ///	 * <returns> <seealso cref="UrlPart"/> the opened http connection, null in case of error
      ///	 *  </returns>
      ///	 
      public static UrlPart writeToURL(string strUrl, Stream stream, string method, string contentType, HTTPDetails details)
      {
         string contentTypeLocal = contentType;

         try
         {
            Uri url = new Uri(strUrl);
            HttpWebRequest httpURLconnection = (HttpWebRequest)WebRequest.Create(url);
            httpURLconnection.Method = method;
            SupportClass.URLConnectionSupport.SetRequestProperty(httpURLconnection, "Connection", "close");
            contentTypeLocal = StringUtil.token(contentTypeLocal, 0, "\r\n");
            SupportClass.URLConnectionSupport.SetRequestProperty(httpURLconnection, CONTENT_TYPE, contentTypeLocal);
            // Java to C# Conversion - No equivalent for .NET
            //httpURLconnection.setDoOutput(true);
            if (details != null)
               details.applyTo(httpURLconnection);

            Stream @out = httpURLconnection.GetRequestStream();

            if (stream != null)
               IOUtils.copy(stream, @out);

            @out.Flush();
            @out.Close();

            return new UrlPart(httpURLconnection);
         }
         catch (Exception)
         {
            // System.out.print(x);
         }

         return null;
      }
   }
}
