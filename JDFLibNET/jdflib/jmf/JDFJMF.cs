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
 * 
 * JDFJMF.cs
 * 
 * Last changes
 * 
 * 2002-07-02 JG modifications in GetMessageElement() 2002-07-02 JG added GetInvalidElements(), RequiredElements()
 * 2002-07-02 JG added EnumTyp to calls of AppendCommand/Response/... 2002-07-02 JG init() added call to GetSchemaURL()
 * 
 *  */

namespace org.cip4.jdflib.jmf
{
   using System;
   using System.Collections;


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   using JDFAutoJMF = org.cip4.jdflib.auto.JDFAutoJMF;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using EnumFamily = org.cip4.jdflib.jmf.JDFMessage.EnumFamily;
   using EnumType = org.cip4.jdflib.jmf.JDFMessage.EnumType;

   ///
   /// <summary> * The wrapper for JMF messages, i.e. the root of a JMF document </summary>
   /// 
   public class JDFJMF : JDFAutoJMF
   {
      private new const long serialVersionUID = 1L;
      private static string theSenderID = null;

      ///   
      ///	 <summary> * Constructor for JDFJMF
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFJMF(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFJMF
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFJMF(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI == null ? getSchemaURL() : myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFJMF
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFJMF(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI == null ? getSchemaURL() : myNamespaceURI, qualifiedName, myLocalName)
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
         return "JDFJMF[ --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * init
      ///	 *  </summary>
      ///	 * <returns> boolean </returns>
      ///	 
      public override bool init()
      {
         base.init();
         setTimeStamp(null);
         setVersion(getDefaultJDFVersion());
         EnumVersion version = getVersion(true);
         if (!EnumVersion.Version_1_3.isGreater(version))
            setMaxVersion(version);
         setXSIType("JMFRootMessage");
         if (theSenderID != null)
            setSenderID(theSenderID);
         return true;
      }

      ///   
      ///	 <summary> * get attribute MaxVersion, defaults to version if not set
      ///	 *  </summary>
      ///	 * <param name="bInherit"> if true recurse through ancestors when searching </param>
      ///	 * <returns> EnumVersion - attribute value
      ///	 * 
      ///	 *         default - getMaxVersion(false) </returns>
      ///	 
      public override EnumVersion getMaxVersion()
      {
         string version = getAttribute(AttributeName.MAXVERSION, null, null);

         if (version == null)
            return getVersion(false);

         return EnumVersion.getEnum(version);
      }

      ///   
      ///	 <summary> * version fixing routine for JMF
      ///	 *<p>
      ///	 * Uses heuristics to modify this element and its children to be compatible with a given version.<br>
      ///	 * In general, it will be able to move from low to high versions, but potentially fail when attempting to move from
      ///	 * higher to lower versions
      ///	 *  </summary>
      ///	 * <param name="version"> version that the resulting element should correspond to </param>
      ///	 * <returns> true if successful </returns>
      ///	 
      public override bool fixVersion(EnumVersion version)
      {
         if (version != null)
         {
            setVersion(version);
            setMaxVersion(version);
         }
         return base.fixVersion(version);
      }

      ///   
      ///	 <summary> * set MaxVersion to enumVer
      ///	 *  </summary>
      ///	 * <param name="enumVer"> the EnumVersion to set </param>
      ///	 
      public override void setMaxVersion(EnumVersion enumVer)
      {
         setAttribute(AttributeName.MAXVERSION, enumVer.getName(), null);
      }

      // Appendix D (JDF 1.3) - Supported Error Codes in JMF and Notification
      // elements
      public class EnumJMFReturnCode : ValuedEnum
      {
         private const long serialVersionUID = 1L;

         private EnumJMFReturnCode(int code, string message)
            : base(message, code)
         {
         }

         public static EnumJMFReturnCode getEnum(string message)
         {
            return (EnumJMFReturnCode)getEnum(typeof(EnumJMFReturnCode), message);
         }

         public static EnumJMFReturnCode getEnum(int code)
         {
            return (EnumJMFReturnCode)getEnum(typeof(EnumJMFReturnCode), code);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumJMFReturnCode));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumJMFReturnCode));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumJMFReturnCode));
         }

         public static readonly EnumJMFReturnCode SUCCESS = new EnumJMFReturnCode(0, "Success");

         // 1..99 Protocol errors
         public static readonly EnumJMFReturnCode GENERAL_ERROR = new EnumJMFReturnCode(1, "General error");

         public static readonly EnumJMFReturnCode INTERNAL_ERROR = new EnumJMFReturnCode(2, "Internal error");

         public static readonly EnumJMFReturnCode XML_PARSER = new EnumJMFReturnCode(3, "XML parser error, e.g., if a MIME file is sent to an XML controller. ");

         public static readonly EnumJMFReturnCode XML_VALIDATION = new EnumJMFReturnCode(4, "XML validation error");

         public static readonly EnumJMFReturnCode MESSAGE_NOT_IMPLEMENTED = new EnumJMFReturnCode(5, "Query/command not implemented");

         public static readonly EnumJMFReturnCode INVALID_PARAMETER = new EnumJMFReturnCode(6, "Invalid parameters");

         public static readonly EnumJMFReturnCode INSUFFICIENT_PARAMETER = new EnumJMFReturnCode(7, "Insufficient parameters");

         public static readonly EnumJMFReturnCode DEVICE_NOT_AVAILABLE = new EnumJMFReturnCode(8, "Device not available (controller exists but not the device or queue)");

         public static readonly EnumJMFReturnCode MESSAGE_INCOMPLETE = new EnumJMFReturnCode(9, "Message incomplete.");

         public static readonly EnumJMFReturnCode MESSAGESERVICE_BUSY = new EnumJMFReturnCode(10, "Message Service is busy");

         // 100..199 Device and controller errors
         public static readonly EnumJMFReturnCode DEVICE_NOT_RUNNING = new EnumJMFReturnCode(100, "Device not running");

         public static readonly EnumJMFReturnCode INCAPABLE_REQUEST = new EnumJMFReturnCode(101, "Device incapable of fulfilling request");

         public static readonly EnumJMFReturnCode NO_EXCUTABLE_NODE = new EnumJMFReturnCode(102, "No executable node exists in the JDF");

         public static readonly EnumJMFReturnCode UNKNOWN_JOB_ID = new EnumJMFReturnCode(103, "Job ID not known by controller");

         public static readonly EnumJMFReturnCode UNKNOWN_JOBPART_ID = new EnumJMFReturnCode(104, "JobPartID not known by controller");

         public static readonly EnumJMFReturnCode UNKNOWN_QUEUE_ENRTY = new EnumJMFReturnCode(105, "Queue entry not in queue");

         public static readonly EnumJMFReturnCode QUEUE_ENRTY_ALREADY_EXECUTED = new EnumJMFReturnCode(106, "Queue request failed because queue entry is already executing");

         public static readonly EnumJMFReturnCode NO_CHANGE_EXECUTING_QUEUE_ENRTY = new EnumJMFReturnCode(107, "Queue entry is already executing. Late change is not accepted");

         public static readonly EnumJMFReturnCode RESULT_SELECTION_EMPTY = new EnumJMFReturnCode(108, "Selection or applied filter results in an empty list");

         public static readonly EnumJMFReturnCode RESULT_SELECTION_INCOMPLETE = new EnumJMFReturnCode(109, "Selection or applied filter results in an incomplete list. A buffer cannot provide the complete list queried for");

         public static readonly EnumJMFReturnCode REQUEST_FAILED_COMPLETION_TIME = new EnumJMFReturnCode(110, "Queue request of a job submission failed because the requested completion time of the job can-not be fulfilled");

         public static readonly EnumJMFReturnCode SUBSCRIPTION_REQUEST_DENIED = new EnumJMFReturnCode(111, "Subscription request denied");

         public static readonly EnumJMFReturnCode QUEUE_CLOSED = new EnumJMFReturnCode(112, "Queue request failed because the Queue is closed and does not accept new entries");

         public static readonly EnumJMFReturnCode QUEUE_ENTRY_ALREADY_IN_STATUS = new EnumJMFReturnCode(113, "Queue entry is already in the resulting status");

         public static readonly EnumJMFReturnCode QUEUE_ENTRY_COMPLETED_OR_ABORTED = new EnumJMFReturnCode(114, "Queue entry is already completed or aborted and therefore does not accept changes");

         public static readonly EnumJMFReturnCode QUEUE_ENTRY_NOT_RUNNING = new EnumJMFReturnCode(115, "Queue entry is not running");

         // 200..299 Job and pipe specific errors
         public static readonly EnumJMFReturnCode INVALID_RESOURCE_PARAMETERS = new EnumJMFReturnCode(200, "Invalid resource parameters");

         public static readonly EnumJMFReturnCode INSUFFICIENT_RESOURCE_PARAMETERS = new EnumJMFReturnCode(201, "Insufficient resource parameters");

         public static readonly EnumJMFReturnCode PIPE_UNKNOWN = new EnumJMFReturnCode(202, "Pipe unknown");

         public static readonly EnumJMFReturnCode UNLINKED_RESOURCE_LINK = new EnumJMFReturnCode(203, "Unlinked resource link");

         public static readonly EnumJMFReturnCode AUTHENTICATION_DENIED = new EnumJMFReturnCode(300, "Authentication Denied");
         public static readonly EnumJMFReturnCode SECURE_NOT_SUPPORTED = new EnumJMFReturnCode(301, "Secure channel not supported");
         public static readonly EnumJMFReturnCode SECURE_REQUIRED = new EnumJMFReturnCode(302, "Secure channel required");
         public static readonly EnumJMFReturnCode CERTIFICATE_EXPIRED = new EnumJMFReturnCode(304, "Certificate is expired");
      }

      ///   
      ///	 <summary> * GetMessage - get the ith message, regardless of type
      ///	 *  </summary>
      ///	 * <param name="i"> message index
      ///	 *  </param>
      ///	 * <returns> JDFMessage - the ith message </returns>
      ///	 * @deprecated use getMessageElement(null) 
      ///	 
      [Obsolete("use getMessageElement(null)")]
      public virtual JDFMessage getMessage(int i)
      {
         return getMessageElement(null, null, i);
      }

      ///   
      ///	 <summary> * Get the ith command
      ///	 *  </summary>
      ///	 * <param name="iLoop"> index of the message </param>
      ///	 * <param name="bCreate"> if true, create one, if it does not exist </param>
      ///	 * <returns> JDFCommand: the message element </returns>
      ///	 * @deprecated use getMessageElement 
      ///	 
      // JDFCommand GetCommand(int i=0,bool bCreate=false);
      [Obsolete("use getMessageElement")]
      public virtual JDFCommand getCommand()
      {
         return getCommand(0, false);
      }

      ///   
      ///	 <summary> *  </summary>
      ///	 * <param name="i"> </param>
      ///	 * <param name="bCreate">
      ///	 * @return </param>
      ///	 * @deprecated use getMessageElement or getCreateMessageElement 
      ///	 
      [Obsolete("use getMessageElement or getCreateMessageElement")]
      public virtual JDFCommand getCommand(int i, bool bCreate)
      {
         if (bCreate)
            return (JDFCommand)getCreateMessageElement(JDFMessage.EnumFamily.Command, null, i);
         return (JDFCommand)getMessageElement(JDFMessage.EnumFamily.Command, null, i);
      }

      ///   
      ///	 <summary> * Get the ith query,
      ///	 *  </summary>
      ///	 * <param name="iLoop"> index of the message </param>
      ///	 * <param name="bCreate"> if true, create one, if it does not exist </param>
      ///	 * <returns> JDFQuery the message element
      ///	 *  </returns>
      ///	 * @deprecated use getMessageElement 
      ///	 
      // JDFQuery GetQuery(int i=0,bool bCreate=false);
      [Obsolete("use getMessageElement")]
      public virtual JDFQuery getQuery()
      {
         return getQuery(0, false);
      }

      ///   
      ///	 <summary> *  </summary>
      ///	 * <param name="i"> </param>
      ///	 * <param name="bCreate">
      ///	 * @return </param>
      ///	 * @deprecated use getMessageElement or getCreateMessageElement 
      ///	 
      [Obsolete("use getMessageElement or getCreateMessageElement")]
      public virtual JDFQuery getQuery(int i, bool bCreate)
      {
         if (bCreate)
            return (JDFQuery)getCreateMessageElement(JDFMessage.EnumFamily.Query, null, i);

         return (JDFQuery)getMessageElement(JDFMessage.EnumFamily.Query, null, i);
      }

      ///   
      ///	 <summary> * getResponse()
      ///	 *  </summary>
      ///	 * <returns> JDFResponse the message element </returns>
      ///	 * @deprecated use getMessageElement 
      ///	 
      // JDFResponse GetResponse(int i=0,bool bCreate=false);
      [Obsolete("use getMessageElement")]
      public virtual JDFResponse getResponse()
      {
         return getResponse(0, false);
      }

      ///   
      ///	 <summary> * getResponse()
      ///	 *  </summary>
      ///	 * <param name="i"> </param>
      ///	 * <param name="bCreate">
      ///	 * @return </param>
      ///	 * @deprecated use getMessageElement or getCreateMessageElement 
      ///	 
      [Obsolete("use getMessageElement or getCreateMessageElement")]
      public virtual JDFResponse getResponse(int i, bool bCreate)
      {
         if (bCreate)
            return (JDFResponse)getCreateMessageElement(JDFMessage.EnumFamily.Response, null, i);
         return (JDFResponse)getMessageElement(JDFMessage.EnumFamily.Response, null, i);
      }

      ///   
      ///	 <summary> * Get the ith signal,
      ///	 *  </summary>
      ///	 * <param name="iLoop"> index of the message </param>
      ///	 * <param name="bCreate"> if true, create one, if it does not exist </param>
      ///	 * <returns> JDFSignal the message element </returns>
      ///	 * @deprecated use getMessageElement 
      ///	 
      // JDFSignal GetSignal(int i=0,bool bCreate=false);
      [Obsolete("use getMessageElement")]
      public virtual JDFSignal getSignal()
      {
         return getSignal(0, false);
      }

      ///   
      ///	 <summary> *  </summary>
      ///	 * <param name="i"> </param>
      ///	 * <param name="bCreate">
      ///	 * @return </param>
      ///	 * @deprecated use getMessageElement 
      ///	 
      [Obsolete("use getMessageElement")]
      public virtual JDFSignal getSignal(int i, bool bCreate)
      {
         if (bCreate)
            return (JDFSignal)getCreateMessageElement(JDFMessage.EnumFamily.Signal, null, i);
         return (JDFSignal)getMessageElement(JDFMessage.EnumFamily.Signal, null, i);
      }

      ///   
      ///	 <summary> * get an existing message element, create it if it doesn't exist
      ///	 *  </summary>
      ///	 * <param name="family"> the Message family - Query, Acknowledge, Command, Response, Registration or Signal </param>
      ///	 * <param name="i"> get the ith element </param>
      ///	 * <returns> the newly created message </returns>
      ///	 
      public virtual JDFMessage getCreateMessageElement(JDFMessage.EnumFamily family, JDFMessage.EnumType typ, int i)
      {
         if (family == null)
         {
            throw new JDFException("GetMessageElement: creating undefined message family");
         }

         JDFMessage m = getMessageElement(family, typ, i);

         if (m == null)
            m = appendMessageElement(family, typ);

         return m;
      }

      ///   
      ///	 <summary> * get an existing message element, create it if it doesn't exist
      ///	 *  </summary>
      ///	 * <param name="family"> the Message family - Query, Acknowledge, Command, Response, Registration or Signal </param>
      ///	 * <param name="i"> get the ith element </param>
      ///	 * <returns> the newly created message </returns>
      ///	 * @deprecated use getCreateMessageElement(family, null, i); 
      ///	 
      [Obsolete("use getCreateMessageElement(family, null, i);")]
      public virtual JDFMessage getCreateMessageElement(JDFMessage.EnumFamily family, int i)
      {
         return getCreateMessageElement(family, null, i);
      }

      ///   
      ///	 <summary> * append a message element to this
      ///	 *  </summary>
      ///	 * <param name="family">
      ///	 * @return </param>
      ///	 * @deprecated use appendMessageElement (family, null); 
      ///	 
      [Obsolete("use appendMessageElement (family, null);")]
      public virtual JDFMessage appendMessageElement(JDFMessage.EnumFamily family)
      {
         return appendMessageElement(family, null);
      }

      ///   
      ///	 <summary> * create a new JMF with one Message Element of family <code>family</code> and type <code>typ</code>
      ///	 *  </summary>
      ///	 * <param name="family"> the Message family - Query, Acknowledge, Command, Response, Registration or Signal </param>
      ///	 * <param name="typ"> the messages @Type value, null if unknown </param>
      ///	 * <returns> the newly created message </returns>
      ///	 
      public static JDFJMF createJMF(JDFMessage.EnumFamily family, JDFMessage.EnumType typ)
      {
         if (family == null)
            throw new JDFException("createJMF: creating undefined message family");

         JDFJMF jmf = new JDFDoc(ElementName.JMF).getJMFRoot();
         jmf.appendMessageElement(family, typ);
         return jmf;
      }

      ///   
      ///	 <summary> * append a message element to <code>this</code>
      ///	 *  </summary>
      ///	 * <param name="family"> the Message family - Query, Acknowledge, Command, Response, Registration or Signal </param>
      ///	 * <param name="typ"> the messages @Type value, null if unknown </param>
      ///	 * <returns> the newly created message </returns>
      ///	 
      public virtual JDFMessage appendMessageElement(JDFMessage.EnumFamily family, JDFMessage.EnumType typ)
      {
         if (family == null)
            throw new JDFException("appendMessageElement: creating undefined message family");

         string sFamily = family.getName();
         JDFMessage m = (JDFMessage)appendElement(sFamily, null);
         if (typ != null)
            m.setType(typ);

         return m;
      }

      ///   
      ///	 <summary> * get the ith message element of family type family
      ///	 *  </summary>
      ///	 * <param name="family"> </param>
      ///	 * <param name="i">
      ///	 * @return </param>
      ///	 * @deprecated since 060619, use getMessageElement (JDFMessage.EnumFamily family, JDFMessage.EnumType typ, int i) 
      ///	 
      [Obsolete("since 060619, use getMessageElement (JDFMessage.EnumFamily family, JDFMessage.EnumType typ, int i)")]
      public virtual JDFMessage getMessageElement(JDFMessage.EnumFamily family, int i)
      {
         return getMessageElement(family, null, i);
      }

      ///   
      ///	 <summary> * get the ith message element of family type family
      ///	 *  </summary>
      ///	 * <param name="family"> the Message family - Query, Acknowledge, Command, Response, Registration or Signal </param>
      ///	 * <param name="typ"> the messages @Type value, null if unknown </param>
      ///	 * <param name="i"> the i'th message element to get, if i<0, get from back </param>
      ///	 * <returns> the matching message, null if none are found </returns>
      ///	 
      public virtual JDFMessage getMessageElement(JDFMessage.EnumFamily family, JDFMessage.EnumType typ, int i)
      {
         int iLocal = i;

         if (iLocal < 0) // search from back
         {
            JDFMessage message = null;
            VElement v = getMessageVector(family, typ);
            if (v != null)
            {
               int siz = v.Count;
               iLocal = siz + iLocal;
               message = (JDFMessage)(iLocal >= 0 ? v[iLocal] : null);
            }

            return message;
         }

         string typString = typ == null ? null : typ.getName();
         string familyString = family == null ? null : family.getName();

         KElement e = getElement(familyString, null, 0);
         int n = 0;

         while (e != null)
         {
            if (e is JDFMessage)
            {
               if (typString == null || typString.Equals(((JDFMessage)e).getType()))
               {
                  if (n++ >= iLocal)
                     return (JDFMessage)e;
               }
            }

            e = e.getNextSiblingElement(familyString, null);
         }

         return null;
      }

      ///   
      ///	 <summary> * get a vector of all messages in this JMF
      ///	 *  </summary>
      ///	 * <returns> VElement all message elements </returns>
      ///	 * @deprecated use getMessageVector (null, null) 
      ///	 
      [Obsolete("use getMessageVector (null, null)")]
      public virtual VElement getMessageVector()
      {
         return getMessageVector(null, null);
      }

      ///   
      ///	 <summary> * get a vector of all messages in this JMF
      ///	 *  </summary>
      ///	 * <param name="family"> requested message family </param>
      ///	 * <returns> VElement all message elements </returns>
      ///	 * @deprecated use getMessageVector (family, null) 
      ///	 
      [Obsolete("use getMessageVector (family, null)")]
      public virtual VElement getMessageVector(JDFMessage.EnumFamily family)
      {
         return getMessageVector(family, null);
      }

      ///   
      ///	 <summary> * get a vector of all messages in a JMF from a JDFDoc
      ///	 *  </summary>
      ///	 * <param name="doc"> the JDFDoc to search - only valid for root JMF </param>
      ///	 * <param name="family"> requested message family </param>
      ///	 * <param name="typ"> requested message type </param>
      ///	 * <returns> VElement all message elements, null if no match found
      ///	 *  </returns>
      ///	 
      public static VElement getMessageVector(JDFDoc doc, JDFMessage.EnumFamily family, JDFMessage.EnumType typ)
      {
         if (doc == null)
            return null;
         JDFJMF jmf = doc.getJMFRoot();
         if (jmf == null)
            return null;

         VElement vM = jmf.getMessageVector(family, typ);
         return vM.Count == 0 ? null : vM;
      }

      ///   
      ///	 <summary> * get a vector of all messages in this JMF
      ///	 *  </summary>
      ///	 * <param name="family"> requested message family </param>
      ///	 * <param name="typ"> requested message type </param>
      ///	 * <returns> VElement all message elements
      ///	 *  </returns>
      ///	 
      public virtual VElement getMessageVector(JDFMessage.EnumFamily family, JDFMessage.EnumType typ)
      {
         VElement vM;
         string sFamily = (family != null) ? family.getName() : null;

         JDFAttributeMap typMap = typ == null ? null : new JDFAttributeMap(AttributeName.TYPE, typ.getName());
         vM = getChildrenByTagName(sFamily, null, typMap, true, true, 0);

         if (family == null) // only needed if call was generic
         {
            // do reverse iteration because erase invalidates
            for (int i = vM.Count - 1; i >= 0; i--)
            {
               if (!(vM[i] is JDFMessage))
               {
                  vM.RemoveAt(i);
               }
            }
         }

         return vM;
      }

      ///   
      ///	 <summary> * Get the ith acknowledge,
      ///	 *  </summary>
      ///	 * <param name="iLoop"> index of the message </param>
      ///	 * <param name="bCreate"> if true, create one, if it does not exist </param>
      ///	 * <returns> JDFAcknowledge: the message element </returns>
      ///	 * @deprecated use getMessageElement 
      ///	 
      [Obsolete("use getMessageElement")]
      public virtual JDFAcknowledge getAcknowledge()
      {
         return getAcknowledge(0, false);
      }

      ///   
      ///	 <summary> *  </summary>
      ///	 * <param name="i"> </param>
      ///	 * <param name="bCreate">
      ///	 * @return </param>
      ///	 * @deprecated use getMessageElement or appendMessageElement 
      ///	 
      [Obsolete("use getMessageElement or appendMessageElement")]
      public virtual JDFAcknowledge getAcknowledge(int i, bool bCreate)
      {
         if (bCreate)
            return (JDFAcknowledge)getCreateMessageElement(JDFMessage.EnumFamily.Acknowledge, null, i);
         return (JDFAcknowledge)getMessageElement(JDFMessage.EnumFamily.Acknowledge, null, i);
      }

      ///   
      ///	 <summary> * Append a Command
      ///	 *  </summary>
      ///	 * <param name="typ"> the type attribute of the appended message </param>
      ///	 * <returns> JDFQuery the newly created message element </returns>
      ///	 
      public virtual JDFCommand appendCommand(JDFMessage.EnumType typ)
      {
         return (JDFCommand)appendMessageElement(JDFMessage.EnumFamily.Command, typ);
      }

      ///   
      ///	 <summary> * Append a Command
      ///	 *  </summary>
      ///	 * <param name="typ"> the type attribute of the appended message </param>
      ///	 * <returns> JDFQuery the newly created message element </returns>
      ///	 
      public virtual JDFRegistration appendRegistration(JDFMessage.EnumType typ)
      {
         return (JDFRegistration)appendMessageElement(JDFMessage.EnumFamily.Registration, typ);
      }

      ///   
      ///	 <summary> * Append a query
      ///	 *  </summary>
      ///	 * <param name="typ"> the type attribute of the appended message </param>
      ///	 * <returns> JDFQuery: the newly created message element </returns>
      ///	 
      public virtual JDFQuery appendQuery(JDFMessage.EnumType typ)
      {
         return (JDFQuery)appendMessageElement(JDFMessage.EnumFamily.Query, typ);

      }

      ///   
      ///	 <summary> * Append a Signal
      ///	 *  </summary>
      ///	 * <param name="typ"> the type attribute of the appended message </param>
      ///	 * <returns> JDFSignal: the newly created message element </returns>
      ///	 
      public virtual JDFSignal appendSignal(JDFMessage.EnumType typ)
      {
         return (JDFSignal)appendMessageElement(JDFMessage.EnumFamily.Signal, typ);

      }

      ///   
      ///	 <summary> * Append a Response
      ///	 *  </summary>
      ///	 * <param name="typ"> the type attribute of the appended message </param>
      ///	 * <returns> JDFResponse the newly created message element </returns>
      ///	 
      public virtual JDFResponse appendResponse(JDFMessage.EnumType typ)
      {
         return (JDFResponse)appendMessageElement(JDFMessage.EnumFamily.Response, typ);

      }

      ///   
      ///	 <summary> * Append an Acknowledge
      ///	 *  </summary>
      ///	 * <param name="typ"> the type attribute of the appended message </param>
      ///	 * <returns> JDFAcknowledge the newly created message element </returns>
      ///	 
      public virtual JDFAcknowledge appendAcknowledge(JDFMessage.EnumType typ)
      {
         return (JDFAcknowledge)appendMessageElement(JDFMessage.EnumFamily.Acknowledge, typ);

      }

      ///   
      ///	 * <returns> the theSenderID which is used as default when initializing new messages </returns>
      ///	 
      public static string getTheSenderID()
      {
         return theSenderID;
      }

      ///   
      ///	 <summary> * set the default senderID that is used to generate jmf messages
      ///	 *  </summary>
      ///	 * <param name="theSenderID"> the theSenderID to set </param>
      ///	 
      public static void setTheSenderID(string _theSenderID)
      {
         JDFJMF.theSenderID = _theSenderID;
      }

      ///   
      ///	 <summary> * create a new response for all messages of this if the message is any message except response correctly fills
      ///	 * refId, type etc.
      ///	 *  </summary>
      ///	 * <returns> the newly created JMF with multiple responses </returns>
      ///	 
      public virtual JDFJMF createResponse()
      {
         VElement v = getMessageVector(null, null);
         JDFJMF jmf = new JDFDoc("JMF").getJMFRoot();
         for (int i = 0; i < v.Count; i++)
         {
            JDFMessage m = (JDFMessage)v[i];
            EnumFamily family = m.getFamily();
            if (family != null && EnumFamily.Response != family && EnumFamily.Acknowledge != family)
            {
               if (!m.hasAttribute(AttributeName.ID)) // in case someone sends
                  // crappy requests...
                  m.appendAnchor(null);
               JDFResponse r = jmf.appendResponse();
               r.setQuery(m);
            }
         }
         return jmf;
      }

      ///   
      ///	 <summary> * convert all responses that match the query q to signals
      ///	 *  </summary>
      ///	 * <returns> the newly created JMF with multiple responses </returns>
      ///	 
      public virtual void convertResponses(JDFQuery q)
      {
         EnumType t = q == null ? null : q.getEnumType();
         VElement v = getMessageVector(EnumFamily.Response, t);
         string qID = q == null ? null : q.getID();
         for (int i = 0; i < v.Count; i++)
         {
            JDFResponse r = (JDFResponse)v[i];
            if (qID == null || qID.Equals(r.getrefID()))
            {
               JDFSignal s = appendSignal();
               moveElement(s, r); // retain ordering
               s.convertResponse(r, q);
               r.deleteNode();
            }
         }
      }

      ///   
      ///	 <summary> * get the @URL of this message if it is either a submitQueueEntry, a returnQueuentry or a resubmitqueueentry
      ///	 * 
      ///	 * @return </summary>
      ///	 
      public virtual string getSubmissionURL()
      {
         JDFCommand cSubmit = (JDFCommand)getMessageElement(EnumFamily.Command, EnumType.SubmitQueueEntry, 0);
         if (cSubmit != null)
         {
            JDFQueueSubmissionParams qsp = cSubmit.getQueueSubmissionParams(0);
            return qsp == null ? null : isWildCard(qsp.getURL()) ? null : qsp.getURL();
         }
         cSubmit = (JDFCommand)getMessageElement(EnumFamily.Command, EnumType.ResubmitQueueEntry, 0);
         if (cSubmit != null)
         {
            JDFResubmissionParams rsp = cSubmit.getResubmissionParams(0);
            return rsp == null ? null : isWildCard(rsp.getURL()) ? null : rsp.getURL();
         }
         cSubmit = (JDFCommand)getMessageElement(EnumFamily.Command, EnumType.ReturnQueueEntry, 0);
         if (cSubmit != null)
         {
            JDFReturnQueueEntryParams rsp = cSubmit.getReturnQueueEntryParams(0);
            return rsp == null ? null : isWildCard(rsp.getURL()) ? null : rsp.getURL();
         }
         return null;

      }
   }
}
