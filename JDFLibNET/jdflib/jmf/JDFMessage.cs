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
 * JDFMessage.cs
 * Last changes
 * 2002-07-02 JG added IsValidMessageElement() and all detailed mesaage element manipulation
 */


namespace org.cip4.jdflib.jmf
{
   using System;
   using System.Collections;
   using System.Collections.Generic;


   using ArrayUtils = org.apache.commons.lang.ArrayUtils;
   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   using JDFAutoMessage = org.cip4.jdflib.auto.JDFAutoMessage;
   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using KElement = org.cip4.jdflib.core.KElement;
   using VString = org.cip4.jdflib.core.VString;
   using JDFDevice = org.cip4.jdflib.resource.JDFDevice;
   using JDFDeviceList = org.cip4.jdflib.resource.JDFDeviceList;
   using JDFQueueEntryDefList = org.cip4.jdflib.resource.JDFQueueEntryDefList;
   using JDFNotificationFilter = org.cip4.jdflib.resource.process.JDFNotificationFilter;
   using EnumUtil = org.cip4.jdflib.util.EnumUtil;

   ///
   /// <summary> * super class for all message families Signal, Command,...
   /// * @author Rainer Prosi, Heidelberger Druckmaschinen
   /// * </summary>
   /// 
   public class JDFMessage : JDFAutoMessage
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFMessage
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFMessage(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFMessage
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFMessage(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFMessage
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFMessage(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[2];
      static JDFMessage()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.XSITYPE, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.SENDERID, 0x33333111, AttributeInfo.EnumAttributeType.shortString, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }

      public class EnumFamily : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumFamily(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumFamily getEnum(string enumName)
         {
            return (EnumFamily)getEnum(typeof(EnumFamily), enumName);
         }

         public static EnumFamily getEnum(int enumValue)
         {
            return (EnumFamily)getEnum(typeof(EnumFamily), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumFamily));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumFamily));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumFamily));
         }

         public static readonly EnumFamily Query = new EnumFamily(ElementName.QUERY);
         public static readonly EnumFamily Signal = new EnumFamily(ElementName.SIGNAL);
         public static readonly EnumFamily Command = new EnumFamily(ElementName.COMMAND);
         public static readonly EnumFamily Response = new EnumFamily(ElementName.RESPONSE);
         public static readonly EnumFamily Acknowledge = new EnumFamily(ElementName.ACKNOWLEDGE);
         public static readonly EnumFamily Registration = new EnumFamily(ElementName.REGISTRATION);
      }

      public class EnumType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumType getEnum(string enumName)
         {
            return (EnumType)getEnum(typeof(EnumType), enumName);
         }

         public static EnumType getEnum(int enumValue)
         {
            return (EnumType)getEnum(typeof(EnumType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumType));
         }

         public static readonly EnumType AbortQueueEntry = new EnumType("AbortQueueEntry");
         public static readonly EnumType CloseQueue = new EnumType("CloseQueue");
         public static readonly EnumType FlushQueue = new EnumType("FlushQueue");
         public static readonly EnumType FlushResources = new EnumType("FlushResources");
         public static readonly EnumType Events = new EnumType("Events");
         public static readonly EnumType ForceGang = new EnumType("ForceGang");
         public static readonly EnumType GangStatus = new EnumType("GangStatus");
         public static readonly EnumType HoldQueue = new EnumType("HoldQueue");
         public static readonly EnumType HoldQueueEntry = new EnumType("HoldQueueEntry");
         public static readonly EnumType KnownControllers = new EnumType("KnownControllers");
         public static readonly EnumType KnownDevices = new EnumType("KnownDevices");
         public static readonly EnumType KnownJDFServices = new EnumType("KnownJDFServices");
         public static readonly EnumType KnownMessages = new EnumType("KnownMessages");
         public static readonly EnumType ModifyNode = new EnumType("ModifyNode");
         public static readonly EnumType NewJDF = new EnumType("NewJDF");
         public static readonly EnumType NodeInfo = new EnumType("NodeInfo");
         public static readonly EnumType Notification = new EnumType("Notification");
         public static readonly EnumType Occupation = new EnumType("Occupation");
         public static readonly EnumType OpenQueue = new EnumType("OpenQueue");
         public static readonly EnumType PipeClose = new EnumType("PipeClose");
         public static readonly EnumType PipePull = new EnumType("PipePull");
         public static readonly EnumType PipePush = new EnumType("PipePush");
         public static readonly EnumType PipePause = new EnumType("PipePause");
         public static readonly EnumType QueueEntryStatus = new EnumType("QueueEntryStatus");
         public static readonly EnumType QueueStatus = new EnumType("QueueStatus");
         public static readonly EnumType RequestQueueEntry = new EnumType("RequestQueueEntry");
         public static readonly EnumType RemoveQueueEntry = new EnumType("RemoveQueueEntry");
         public static readonly EnumType RepeatMessages = new EnumType("RepeatMessages");
         public static readonly EnumType Resource = new EnumType("Resource");
         public static readonly EnumType ResourcePull = new EnumType("ResourcePull");
         public static readonly EnumType ResumeQueue = new EnumType("ResumeQueue");
         public static readonly EnumType ResumeQueueEntry = new EnumType("ResumeQueueEntry");
         public static readonly EnumType ResubmitQueueEntry = new EnumType("ResubmitQueueEntry");
         public static readonly EnumType ReturnQueueEntry = new EnumType("ReturnQueueEntry");
         public static readonly EnumType SetQueueEntryPosition = new EnumType("SetQueueEntryPosition");
         public static readonly EnumType SetQueueEntryPriority = new EnumType("SetQueueEntryPriority");
         public static readonly EnumType ShutDown = new EnumType("ShutDown");
         public static readonly EnumType Status = new EnumType("Status");
         public static readonly EnumType StopPersistentChannel = new EnumType("StopPersistentChannel");
         public static readonly EnumType SubmissionMethods = new EnumType("SubmissionMethods");
         public static readonly EnumType SubmitQueueEntry = new EnumType("SubmitQueueEntry");
         public static readonly EnumType SuspendQueueEntry = new EnumType("SuspendQueueEntry");
         public static readonly EnumType Track = new EnumType("Track");
         public static readonly EnumType UpdateJDF = new EnumType("UpdateJDF");
         public static readonly EnumType WakeUp = new EnumType("WakeUp");
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
         return "JDFMessage[ --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * IsMessageElement - is a message with this name a message element?
      ///	 *  </summary>
      ///	 * <returns> boolean </returns>
      ///	 * @deprecated use instanceof JDFMessage 
      ///	 
      [Obsolete("use instanceof JDFMessage")]
      public virtual bool isMessageElement()
      {
         return true;
      }

      ///   
      ///	 <summary> * init
      ///	 *  </summary>
      ///	 * <returns> boolean </returns>
      ///	 
      public override bool init()
      {
         appendAnchor(null);
         return base.init();
      }

      ///   
      ///	 <summary> * getIDPrefix
      ///	 *  </summary>
      ///	 * <returns> the ID prefix of JDFMessage </returns>
      ///	 
      public override string getIDPrefix()
      {
         return "m";
      }

      ///   
      ///	 <summary> * getFamily: get the enum family type
      ///	 *  </summary>
      ///	 * <returns> EnumFamily - type Family_Unknown, Family_Query, Family_Signal, Family_Command, Family_Response or
      ///	 *         Family_Acknowledge </returns>
      ///	 
      public virtual EnumFamily getFamily()
      {
         return EnumFamily.getEnum(LocalName);
      }

      ///   
      ///	 <summary> * getType: get attribute <code>Type</code>
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public override string getType()
      {
         return getAttribute(AttributeName.TYPE, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * Set attribute <code>Type</code> and <code>xsi:type</code>
      ///	 *  </summary>
      ///	 * <param name="typ"> the type </param>
      ///	 
      public override void setType(string typ)
      {
         removeAttribute("type", AttributeName.XSIURI);
         setAttribute(AttributeName.TYPE, typ, null);
         if (xmlnsPrefix(typ) == null)
         {
            setXSIType(LocalName + typ);
         }
      }

      ///   
      ///	 <summary> * SetQuery - sets the initiating query, command or registration to q
      ///	 *  </summary>
      ///	 * <param name="q"> the query, command or registration to create a response for </param>
      ///	 
      public virtual void setQuery(JDFMessage q)
      {
         EnumFamily f = getFamily();
         if (f == null || f.Equals(EnumFamily.Query) || f.Equals(EnumFamily.Command) || f.Equals(EnumFamily.Registration))
         {
            string message = f == null ? "JDFMessage.setQuery: illegal family type " : "JDFMessage.setQuery: illegal family type " + f.getName();
            throw new JDFException(message);
         }
         setrefID(q.getID());
         setType(q.getType());
      }

      ///   
      ///	 <summary> * Enumeration string for enum value
      ///	 *  </summary>
      ///	 * <param name="EnumType"> value the enumeration to translate </param>
      ///	 * <returns> KString the string representation of the enumeration </returns>
      ///	 
      public static string typeString(EnumType @value)
      {
         return @value.ToString();
      }

      ///   
      ///	 * @deprecated use EnumType to get strings
      ///	 * @return 
      ///	 
      [Obsolete("use EnumType to get strings")]
      public static string typeString()
      {
         string enums = "Unknown,Events,KnownControllers,KnownDevices,KnownJDFServices,KnownMessages," + "RepeatMessages,StopPersistentChannel,Occupation,Resource," + "Status,Track,PipeClose,PipePull,PipePush,PipePause,AbortQueueEntry," + "HoldQueueEntry,removeQueueEntry,ResubmitQueueEntry," + "ResumeQueueEntry,SetQueueEntryPosition,SetQueueEntryPriority," + "SubmitQueueEntry,CloseQueue,FlushQueue,HoldQueue,OpenQueue,QueueEntryStatus,QueueStatus," + "ResumeQueue,SubmissionMethods";
         return enums;
      }

      ///   
      ///	 <summary> * Set attribute Type
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 * @deprecated use setType() 
      ///	 
      [Obsolete("use setType()")]
      public virtual void setEnumType(EnumType @value)
      {
         setType(@value);
      }

      ///   
      ///	 <summary> * Set attribute Type
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setType(EnumType @value)
      {
         string typeName = @value == null ? null : @value.getName();
         setType(typeName);
      }

      ///   
      ///	 <summary> * create a new response for this if this is any message except response correctly fills refId, type etc.
      ///	 *  </summary>
      ///	 * <returns> the newly created message </returns>
      ///	 
      public virtual JDFJMF createResponse()
      {
         JDFMessage.EnumFamily family = getFamily();

         if (family == null)
            throw new JDFException("createResponse: creating resp from undefined message family");

         JDFJMF jmf = JDFJMF.createJMF(EnumFamily.Response, null);
         jmf.getResponse(0).setQuery(this);
         return jmf;
      }

      ///   
      ///	 <summary> * fixVersion()<br>
      ///	 * adds xsi:Type if it doesn't exist
      ///	 *  </summary>
      ///	 * <param name="version"> </param>
      ///	 
      public override bool fixVersion(EnumVersion version)
      {
         if (version != null)
         {
            version.GetType(); // dummy to fool compiler
         }
         if (hasAttribute(AttributeName.TYPE) && !hasAttribute(AttributeName.XSITYPE, AttributeName.XSIURI, false))
         {
            setAttribute(AttributeName.XSITYPE, LocalName + getType(), AttributeName.XSIURI);
         }
         return true;
      }

      ///   
      ///	 <summary> * checks whether the type of messageElement is valid for this message
      ///	 *  </summary>
      ///	 * <param name="elementName"> the name of the element to be tested </param>
      ///	 * <returns> boolean: true if valid; always true if not in JDFNameSpace </returns>
      ///	 
      public virtual bool isValidMessageElement(string elementName, int iSkip)
      {
         // this is not a standard jdf element, but rather an extension
         // we assume that anyone calling the typesafe methods knows what he is
         // doing
         if (!isInJDFNameSpaceStatic(this))
         {
            return true;
         }

         // this is not a standard jdf type, but rather an extension type
         // we assume that anyone calling the typesafe methods knows what he is
         // doing
         string sTyp = getType();
         if (KElement.xmlnsPrefix(sTyp) != null)
         {
            return true;
         }

         // it aint even valid for any family
         string[] familyTypeObj_ = familyTypeObj();
         bool isFamilyTypeString = (familyTypeObj_ == null) ? false : ArrayUtils.Contains(familyTypeObj_, elementName);
         if (!isFamilyTypeString)
         {
            return false;
         }

         EnumType typ = getEnumType();
         // the type seams to be unknown, we certainly don't know what to dump in
         if (typ == null)
         {
            return false;
         }

         List<EnumType> validList = getValidTypeVector(elementName, iSkip);
         return validList.Contains(typ);
      }

      ///   
      ///	 <summary> * returns a vector of valid messageElement types for this element
      ///	 *  </summary>
      ///	 * <param name="elementName"> the name of the element to be tested </param>
      ///	 * <returns> vector of valid EnumTypes; empty if all are invalid
      ///	 * @default getValidTypeVector(elementName, 0) </returns>
      ///	 
      private List<EnumType> getValidTypeVector(string elementName, int iSkip)
      {
         // typedef std::vector<EnumType> vEnumType;
         List<EnumType> validList = new List<EnumType>();

         // Commands
         if (elementName.Equals(ElementName.FLUSHQUEUEPARAMS))
         {
            if (iSkip == 0)
            { // validation for cardinality '?' or '-', when no more than 1
               // element are allowed
               validList.Add(EnumType.FlushQueue);
            }

         }
         else if (elementName.Equals(ElementName.FLUSHQUEUEINFO))
         {
            if (iSkip == 0)
            { // validation for cardinality '?' or '-', when no more than 1
               // element are allowed
               validList.Add(EnumType.FlushQueue);
            }

         }
         else if (elementName.Equals(ElementName.FLUSHRESOURCEPARAMS))
         {
            if (iSkip == 0)
            {
               validList.Add(EnumType.FlushResources);
            }

         }
         else if (elementName.Equals(ElementName.NEWJDFCMDPARAMS))
         {
            if (iSkip == 0)
            {
               validList.Add(EnumType.NewJDF);
            }

         }
         else if (elementName.Equals(ElementName.NODEINFOCMDPARAMS))
         {
            if (iSkip == 0)
            {
               validList.Add(EnumType.NodeInfo);
            }

         }
         else if (elementName.Equals(ElementName.PIPEPARAMS))
         {
            if (iSkip == 0)
            {
               validList.Add(EnumType.PipeClose);
               validList.Add(EnumType.PipePush);
               validList.Add(EnumType.PipePull);
               validList.Add(EnumType.PipePause);
            }

         }
         else if (elementName.Equals(ElementName.QUEUEENTRYDEF))
         {
            if (iSkip == 0)
            {
               validList.Add(EnumType.AbortQueueEntry);
               validList.Add(EnumType.HoldQueueEntry);
               validList.Add(EnumType.RemoveQueueEntry);
               validList.Add(EnumType.ResumeQueueEntry);
               validList.Add(EnumType.SuspendQueueEntry);
            }

         }
         else if (elementName.Equals(ElementName.QUEUEENTRYPRIPARAMS))
         {
            if (iSkip == 0)
            {
               validList.Add(EnumType.SetQueueEntryPriority);
            }

         }
         else if (elementName.Equals(ElementName.QUEUEENTRYPOSPARAMS))
         {
            if (iSkip == 0)
            {
               validList.Add(EnumType.SetQueueEntryPosition);
            }

         }
         else if (elementName.Equals(ElementName.QUEUEFILTER))
         {
            if (iSkip == 0)
            {
               validList.Add(EnumType.AbortQueueEntry);
               validList.Add(EnumType.CloseQueue);
               validList.Add(EnumType.FlushQueue);
               validList.Add(EnumType.FlushResources);
               validList.Add(EnumType.HoldQueue);
               validList.Add(EnumType.HoldQueueEntry);
               validList.Add(EnumType.OpenQueue);
               validList.Add(EnumType.RemoveQueueEntry);
               validList.Add(EnumType.ResourcePull);
               validList.Add(EnumType.ResubmitQueueEntry);
               validList.Add(EnumType.ResumeQueue);
               validList.Add(EnumType.ResumeQueueEntry);
               validList.Add(EnumType.SetQueueEntryPosition);
               validList.Add(EnumType.SetQueueEntryPriority);
               validList.Add(EnumType.ShutDown);
               validList.Add(EnumType.SubmitQueueEntry);
               validList.Add(EnumType.SuspendQueueEntry);
               // Queries for QueueFilter
               validList.Add(EnumType.QueueStatus);
            }

         }
         else if (elementName.Equals(ElementName.QUEUESUBMISSIONPARAMS))
         {
            if (iSkip == 0)
            {
               validList.Add(EnumType.SubmitQueueEntry);
            }

         }
         else if (elementName.Equals(ElementName.REQUESTQUEUEENTRYPARAMS))
         {
            if (iSkip == 0)
            {
               validList.Add(EnumType.RequestQueueEntry);
            }

         }
         else if (elementName.Equals(ElementName.RESOURCECMDPARAMS))
         {
            if (iSkip == 0)
            {
               validList.Add(EnumType.Resource);
            }

         }
         else if (elementName.Equals(ElementName.RESOURCEPULLPARAMS))
         {
            if (iSkip == 0)
            {
               validList.Add(EnumType.ResourcePull);
            }

         }
         else if (elementName.Equals(ElementName.RESUBMISSIONPARAMS))
         {
            if (iSkip == 0)
            {
               validList.Add(EnumType.ResubmitQueueEntry);
            }

         }
         else if (elementName.Equals(ElementName.RETURNQUEUEENTRYPARAMS))
         {
            if (iSkip == 0)
            {
               validList.Add(EnumType.ReturnQueueEntry);
            }

         }
         else if (elementName.Equals(ElementName.SHUTDOWNCMDPARAMS))
         {
            if (iSkip == 0)
            {
               validList.Add(EnumType.ShutDown);
            }

         }
         else if (elementName.Equals(ElementName.STOPPERSCHPARAMS))
         {
            if (iSkip == 0)
            {
               validList.Add(EnumType.StopPersistentChannel);
            }

         }
         else if (elementName.Equals(ElementName.WAKEUPCMDPARAMS))
         {
            if (iSkip == 0)
            {
               validList.Add(EnumType.WakeUp);
            }

            // Queries
         }
         else if (elementName.Equals(ElementName.DEVICEFILTER))
         {
            if (iSkip == 0)
            {
               validList.Add(EnumType.KnownDevices);
            }

         }
         else if (elementName.Equals(ElementName.EMPLOYEEDEF))
         {
            validList.Add(EnumType.Occupation);

         }
         else if (elementName.Equals(ElementName.KNOWNMSGQUPARAMS))
         {
            if (iSkip == 0)
            {
               validList.Add(EnumType.KnownMessages);
            }

         }
         else if (elementName.Equals(ElementName.MSGFILTER))
         {
            if (iSkip == 0)
            {
               validList.Add(EnumType.RepeatMessages);
            }

         }
         else if (elementName.Equals(ElementName.NEWJDFQUPARAMS))
         {
            if (iSkip == 0)
            {
               validList.Add(EnumType.NewJDF);
            }

         }
         else if (elementName.Equals(ElementName.NODEINFOQUPARAMS))
         {
            if (iSkip == 0)
            {
               validList.Add(EnumType.NodeInfo);
            }

         }
         else if (elementName.Equals(ElementName.NOTIFICATIONFILTER))
         {
            if (iSkip == 0)
            {
               validList.Add(EnumType.Events);
            }

         }
         else if (elementName.Equals(ElementName.QUEUEENTRYDEFLIST))
         {
            if (iSkip == 0)
            {
               validList.Add(EnumType.QueueEntryStatus);
            }

         }
         else if (elementName.Equals(ElementName.RESOURCEQUPARAMS))
         {
            if (iSkip == 0)
            {
               validList.Add(EnumType.Resource);
            }

         }
         else if (elementName.Equals(ElementName.STATUSQUPARAMS))
         {
            if (iSkip == 0)
            {
               validList.Add(EnumType.Status);
            }

         }
         else if (elementName.Equals(ElementName.TRACKFILTER))
         {
            if (iSkip == 0)
            {
               validList.Add(EnumType.Track);
            }

            // Responses
         }
         else if (elementName.Equals(ElementName.DEVICELIST))
         {
            if (iSkip == 0)
            {
               validList.Add(EnumType.KnownDevices);
            }

         }
         else if (elementName.Equals(ElementName.DEVICEINFO))
         {
            if (iSkip == 0)
            {
               validList.Add(EnumType.ShutDown);
               validList.Add(EnumType.WakeUp);
            }
            validList.Add(EnumType.Status);

         }
         else if (elementName.Equals(ElementName.FLUSHEDRESOURCES))
         {
            if (iSkip == 0)
            {
               validList.Add(EnumType.FlushResources);
            }

         }
         else if (elementName.Equals(ElementName.IDINFO))
         {
            validList.Add(EnumType.NewJDF);

         }
         else if (elementName.Equals(ElementName.JDFCONTROLLER))
         {
            validList.Add(EnumType.KnownControllers);

         }
         else if (elementName.Equals(ElementName.JDFSERVICE))
         {
            validList.Add(EnumType.KnownJDFServices);

         }
         else if (elementName.Equals(ElementName.JOBPHASE))
         {
            if (iSkip == 0)
            {
               validList.Add(EnumType.PipeClose);
               validList.Add(EnumType.PipePush);
               validList.Add(EnumType.PipePull);
               validList.Add(EnumType.PipePause);
            }

         }
         else if (elementName.Equals(ElementName.MESSAGESERVICE))
         {
            validList.Add(EnumType.KnownMessages);

         }
         else if (elementName.Equals(ElementName.NODEINFORESP))
         {
            validList.Add(EnumType.NodeInfo);

         }
         else if (elementName.Equals(ElementName.NOTIFICATIONDEF))
         {
            validList.Add(EnumType.Events);

         }
         else if (elementName.Equals(ElementName.OCCUPATION))
         {
            validList.Add(EnumType.Occupation);

         }
         else if (elementName.Equals(ElementName.QUEUE))
         {
            if (iSkip == 0)
            {
               validList.Add(EnumType.AbortQueueEntry);
               validList.Add(EnumType.CloseQueue);
               validList.Add(EnumType.FlushQueue);
               validList.Add(EnumType.HoldQueue);
               validList.Add(EnumType.HoldQueueEntry);
               validList.Add(EnumType.OpenQueue);
               validList.Add(EnumType.QueueStatus);
               validList.Add(EnumType.RemoveQueueEntry);
               validList.Add(EnumType.ResourcePull);
               validList.Add(EnumType.ResumeQueue);
               validList.Add(EnumType.ResubmitQueueEntry);
               validList.Add(EnumType.ResumeQueueEntry);
               validList.Add(EnumType.SetQueueEntryPosition);
               validList.Add(EnumType.SetQueueEntryPriority);
               validList.Add(EnumType.ShutDown);
               validList.Add(EnumType.Status);
               validList.Add(EnumType.SubmitQueueEntry);
               validList.Add(EnumType.SuspendQueueEntry);
            }

         }
         else if (elementName.Equals(ElementName.QUEUEENTRY))
         {
            if (iSkip == 0)
            {
               validList.Add(EnumType.ResourcePull);
               validList.Add(EnumType.SubmitQueueEntry);
            }
            validList.Add(EnumType.QueueEntryStatus);

         }
         else if (elementName.Equals(ElementName.RESOURCEINFO))
         {
            validList.Add(EnumType.Resource);

         }
         else if (elementName.Equals(ElementName.SUBMISSIONMETHODS))
         {
            if (iSkip == 0)
            {
               validList.Add(EnumType.SubmissionMethods);
            }

         }
         else if (elementName.Equals(ElementName.TRACKRESULT))
         {
            validList.Add(EnumType.Track);

         }
         else if (elementName.Equals(ElementName.UPDATEJDFCMDPARAMS))
         {
            if (iSkip == 0)
            {
               validList.Add(EnumType.UpdateJDF);
            }
         }
         else if (elementName.Equals(ElementName.MODIFYNODECMDPARAMS))
         {
            if (iSkip == 0)
            {
               validList.Add(EnumType.ModifyNode);
            }
         }

         else if (EnumFamily.getEnum(elementName) != null)
         {
            validList.Add(EnumType.RepeatMessages);
         }

         return validList;
      }

      ///   
      ///	 <summary> * Typesafe enumerated attribute Type
      ///	 *  </summary>
      ///	 * <returns> EnumType: the enumeration value of the attribute </returns>
      ///	 
      public virtual EnumType getEnumType()
      {
         return EnumType.getEnum(getAttribute(AttributeName.TYPE, null, null));
      }

      ///   
      ///	 <summary> * get a vector of valid object names for this family type
      ///	 *  </summary>
      ///	 * <returns> String comma separated valid object types for this family type </returns>
      ///	 
      private string[] familyTypeObj()
      {
         EnumFamily family = getFamily();
         if (family == null)
         {
            return null;
         }

         if (family.Equals(EnumFamily.Command))
         {
            return commandTypeObjString;
         }
         if (family.Equals(EnumFamily.Registration))
         {
            return registrationTypeObjString;
         }

         if (family.Equals(EnumFamily.Query))
         {
            return queryTypeObjString;
         }

         if (family.Equals(EnumFamily.Response) || family.Equals(EnumFamily.Acknowledge))
         {
            return responseTypeObjString;
         }

         if (family.Equals(EnumFamily.Signal))
         {
            if (signalTypeObjString == null)
            {
               VString v = new VString(queryTypeObjString);
               v.AddRange(responseTypeObjString);
               v.unify();
               signalTypeObjString = v.ToArray(); //new string[v.Count]);
            }
            return signalTypeObjString;
         }

         return null;
      }

      ///   
      ///	 <summary> * Enumeration strings for list of CommandTypeObj
      ///	 * 
      ///	 * @returnString comma separated list of enumerated string values </summary>
      ///	 
      private static string[] commandTypeObjString = { ElementName.FLUSHQUEUEPARAMS, ElementName.FLUSHRESOURCEPARAMS, ElementName.MODIFYNODECMDPARAMS, ElementName.NEWJDFCMDPARAMS, ElementName.NODEINFOCMDPARAMS, ElementName.PIPEPARAMS, ElementName.QUEUEENTRYDEF, ElementName.QUEUEENTRYPRIPARAMS, ElementName.QUEUEENTRYPOSPARAMS, ElementName.QUEUEFILTER, ElementName.QUEUESUBMISSIONPARAMS, ElementName.REQUESTQUEUEENTRYPARAMS, ElementName.RESOURCECMDPARAMS, ElementName.RESOURCEPULLPARAMS, ElementName.RESUBMISSIONPARAMS, ElementName.RETURNQUEUEENTRYPARAMS, ElementName.SHUTDOWNCMDPARAMS, ElementName.STOPPERSCHPARAMS, ElementName.UPDATEJDFCMDPARAMS, ElementName.WAKEUPCMDPARAMS };

      ///   
      ///	 <summary> * Enumeration strings for list of CommandTypeObj
      ///	 * 
      ///	 * @returnString comma separated list of enumerated string values </summary>
      ///	 
      private static string[] registrationTypeObjString = { ElementName.PIPEPARAMS, ElementName.RESOURCECMDPARAMS, ElementName.RESOURCEPULLPARAMS };

      ///   
      ///	 <summary> * Enumeration strings for list of QueryTypeObj
      ///	 * 
      ///	 * @returnString comma separated list of enumerated string values </summary>
      ///	 
      private static string[] queryTypeObjString = { ElementName.DEVICEFILTER, ElementName.EMPLOYEEDEF, ElementName.KNOWNMSGQUPARAMS, ElementName.MSGFILTER, ElementName.MODIFYNODECMDPARAMS, ElementName.NEWJDFQUPARAMS, ElementName.NODEINFOQUPARAMS, ElementName.NOTIFICATIONFILTER, ElementName.QUEUEENTRYDEFLIST, ElementName.QUEUEFILTER, ElementName.RESOURCEQUPARAMS, ElementName.STATUSQUPARAMS, ElementName.TRACKFILTER, ElementName.UPDATEJDFCMDPARAMS };

      ///   
      ///	 <summary> * Enumeration strings for list of ResponseTypeObj
      ///	 * 
      ///	 * @returnString comma separated list of enumerated string values </summary>
      ///	 
      private static string[] responseTypeObjString = { ElementName.DEVICELIST, ElementName.DEVICEINFO, ElementName.FLUSHQUEUEINFO, ElementName.FLUSHEDRESOURCES, ElementName.IDINFO, ElementName.JDFCONTROLLER, ElementName.JDFSERVICE, ElementName.JOBPHASE, ElementName.MESSAGESERVICE, ElementName.NODEINFORESP, ElementName.NOTIFICATIONDEF, ElementName.OCCUPATION, ElementName.QUEUE, ElementName.QUEUEENTRY, ElementName.RESOURCEINFO, ElementName.SUBMISSIONMETHODS, ElementName.TRACKRESULT, ElementName.COMMAND, ElementName.QUERY, ElementName.ACKNOWLEDGE, ElementName.RESPONSE, ElementName.SIGNAL, ElementName.REGISTRATION };
      private static string[] signalTypeObjString = null;
      private static readonly string[] elementArray = { ElementName.DEVICE, ElementName.DEVICEFILTER, ElementName.DEVICEINFO, ElementName.DEVICELIST, ElementName.FLUSHEDRESOURCES, ElementName.FLUSHQUEUEINFO, ElementName.FLUSHQUEUEPARAMS, ElementName.FLUSHRESOURCEPARAMS, ElementName.IDINFO, ElementName.JDFCONTROLLER, ElementName.JDFSERVICE, ElementName.JOBPHASE, ElementName.KNOWNMSGQUPARAMS, ElementName.MESSAGESERVICE, ElementName.MSGFILTER, ElementName.NEWJDFCMDPARAMS, ElementName.NEWJDFQUPARAMS, ElementName.NODEINFOCMDPARAMS, ElementName.NODEINFOQUPARAMS, ElementName.NODEINFORESP, ElementName.NOTIFICATIONDEF, ElementName.NOTIFICATIONFILTER, ElementName.OCCUPATION, ElementName.PIPEPARAMS, ElementName.QUEUE, ElementName.QUEUEENTRY, ElementName.QUEUEENTRYDEF, ElementName.QUEUEENTRYDEFLIST, ElementName.QUEUEENTRYPRIPARAMS, ElementName.QUEUEENTRYPOSPARAMS, ElementName.QUEUEFILTER, ElementName.QUEUESUBMISSIONPARAMS, ElementName.REQUESTQUEUEENTRYPARAMS, ElementName.RESOURCECMDPARAMS, ElementName.RESOURCEINFO, ElementName.RESOURCEPULLPARAMS, ElementName.RESOURCEQUPARAMS, ElementName.RESUBMISSIONPARAMS, ElementName.RETURNQUEUEENTRYPARAMS, ElementName.SHUTDOWNCMDPARAMS, ElementName.STATUSQUPARAMS, ElementName.STOPPERSCHPARAMS, ElementName.SUBMISSIONMETHODS, ElementName.TRACKFILTER, ElementName.TRACKRESULT, ElementName.WAKEUPCMDPARAMS };

      ///   
      ///	 <summary> * append an element<br>
      ///	 * throws an JDFException, if <code>elementName</code> is not legal
      ///	 *  </summary>
      ///	 * <param name="elementName"> name of the element to append </param>
      ///	 * <param name="nameSpaceURI"> namespace URI of the element to append </param>
      ///	 * <returns> the appended element </returns>
      ///	 
      public virtual KElement appendValidElement(string elementName, string nameSpaceURI)
      {
         int iSkip = numChildElements(elementName, nameSpaceURI);
         if (!isValidMessageElement(elementName, iSkip))
         {
            throw new JDFException("AppendValidElement: illegal element :" + elementName);
         }
         return appendElement(elementName, nameSpaceURI);
      }

      ///   
      ///	 * @deprecated use appendValidElement(elementName, null); 
      ///	 * <param name="elementName">
      ///	 * @return </param>
      ///	 
      [Obsolete("use appendValidElement(elementName, null);")]
      public virtual KElement appendValidElement(string elementName)
      {
         return appendValidElement(elementName, null);
      }

      ///   
      ///	 <summary> * get a (valid) element<br>
      ///	 * throws <code>JDFException</code> if the element is not valid
      ///	 *  </summary>
      ///	 * <param name="nodeName"> name of the element to get </param>
      ///	 * <param name="nameSpaceURI"> namespace URI of the element to get </param>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> the element </returns>
      ///	 
      public virtual KElement getValidElement(string nodeName, string nameSpaceURI, int iSkip)
      {
         if (!isValidMessageElement(nodeName, iSkip))
         {
            throw new JDFException("getValidElement: illegal element :" + nodeName);
         }

         return getElement_JDFElement(nodeName, nameSpaceURI, iSkip);
      }


      ///   
      ///	 <summary> * get a (valid) element, create if it doesn't exist<br>
      ///	 * throws <code>JDFException</code> if the element is not valid
      ///	 *  </summary>
      ///	 * <param name="nodeName"> name of the element to get </param>
      ///	 * <param name="nameSpaceURI"> namespace URI of the element to get </param>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> KElement </returns>
      ///	 
      public virtual KElement getCreateValidElement(string nodeName, string nameSpaceURI, int iSkip)
      {
         if (!isValidMessageElement(nodeName, iSkip))
         {
            throw new JDFException("getCreateValidElement: illegal element :" + nodeName);
         }

         return getCreateElement_KElement(nodeName, nameSpaceURI, iSkip);
      }

      //   
      //	 * // Element getter / Setter
      //	 

      ///   
      ///	 <summary> * get device, create if it doesn't exist
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFDevice </returns>
      ///	 
      public virtual JDFDevice getCreateDevice(int iSkip)
      {
         JDFDevice e = (JDFDevice)getCreateValidElement(ElementName.DEVICE, null, iSkip);

         return e;
      }

      
      ///   
      ///	 <summary> * append element <code>Device</code>
      ///	 *  </summary>
      ///	 * <returns> JDFDevice: the element </returns>
      ///	 
      public virtual JDFDevice appendDevice()
      {
         JDFDevice e = (JDFDevice)appendValidElement(ElementName.DEVICE, null);

         return e;
      }

      
      ///   
      ///	 <summary> * get the iSkip'th device
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFDevice: the element </returns>
      ///	 
      public virtual JDFDevice getDevice(int iSkip)
      {
         return (JDFDevice)getValidElement(ElementName.DEVICE, null, iSkip);
      }

      
      ///   
      ///	 <summary> * get iSkip'th element <code>DeviceFilter</code>, create if it doesn't exist
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFDeviceFilter: the element </returns>
      ///	 
      public virtual JDFDeviceFilter getCreateDeviceFilter(int iSkip)
      {
         JDFDeviceFilter e = (JDFDeviceFilter)getCreateValidElement(ElementName.DEVICEFILTER, null, iSkip);

         return e;
      }

      
      ///   
      ///	 <summary> * append element <code>DeviceFilter</code>
      ///	 *  </summary>
      ///	 * <returns> JDFDeviceFilter: the element </returns>
      ///	 
      public virtual JDFDeviceFilter appendDeviceFilter()
      {
         return (JDFDeviceFilter)appendValidElement(ElementName.DEVICEFILTER, null);
      }

      
      ///   
      ///	 <summary> * get iSkip'th element <code>DeviceFilter</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFDeviceFilter: the element </returns>
      ///	 
      public virtual JDFDeviceFilter getDeviceFilter(int iSkip)
      {
         return (JDFDeviceFilter)getValidElement(ElementName.DEVICEFILTER, null, iSkip);
      }

      ///   
      ///	 <summary> * get element <code>DeviceInfo</code>, create if it doesn't exist
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFDeviceInfo: the element </returns>
      ///	 
      public virtual JDFDeviceInfo getCreateDeviceInfo(int iSkip)
      {
         return (JDFDeviceInfo)getCreateValidElement(ElementName.DEVICEINFO, null, iSkip);
      }

      
      ///   
      ///	 <summary> * append element <code>DeviceInfo</code>
      ///	 *  </summary>
      ///	 * <returns> JDFDeviceInfo: the element </returns>
      ///	 
      public virtual JDFDeviceInfo appendDeviceInfo()
      {
         return (JDFDeviceInfo)appendValidElement(ElementName.DEVICEINFO, null);
      }

      

      ///   
      ///	 <summary> * get iSkip'th element <code>DeviceInfo</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFDeviceInfo: the elment </returns>
      ///	 
      public virtual JDFDeviceInfo getDeviceInfo(int iSkip)
      {
         return (JDFDeviceInfo)getValidElement(ElementName.DEVICEINFO, null, iSkip);
      }


      ///   
      ///	 <summary> * get Element <code>DeviceList</code>, create if it doesn't exist
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFDeviceList: the element </returns>
      ///	 
      public virtual JDFDeviceList getCreateDeviceList(int iSkip)
      {
         return (JDFDeviceList)getCreateValidElement(ElementName.DEVICELIST, null, iSkip);
      }

      

      ///   
      ///	 <summary> * Append element <code>DeviceList</code>
      ///	 *  </summary>
      ///	 * <returns> JDFDeviceList the element </returns>
      ///	 
      public virtual JDFDeviceList appendDeviceList()
      {
         return (JDFDeviceList)appendValidElement(ElementName.DEVICELIST, null);
      }

      
      ///   
      ///	 <summary> * get iSkip'th DeviceList element
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFDeviceList: the element </returns>
      ///	 
      public virtual JDFDeviceList getDeviceList(int iSkip)
      {
         return (JDFDeviceList)getValidElement(ElementName.DEVICELIST, null, iSkip);
      }


      ///   
      ///	 <summary> * get element <code>EmployeeDef</code>, create if it doesn't exist
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFEmployeeDef: the element </returns>
      ///	 
      public virtual JDFEmployeeDef getCreateEmployeeDef(int iSkip)
      {
         return (JDFEmployeeDef)getCreateValidElement(ElementName.EMPLOYEEDEF, null, iSkip);
      }

      

      ///   
      ///	 <summary> * Append element <code>EmployeeDef</code>
      ///	 *  </summary>
      ///	 * <returns> JDFEmployeeDef: the element </returns>
      ///	 
      public virtual JDFEmployeeDef appendEmployeeDef()
      {
         return (JDFEmployeeDef)appendValidElement(ElementName.EMPLOYEEDEF, null);
      }

      

      ///   
      ///	 <summary> * get iSkip'th element <code>EmployeeDef</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFEmployeeDef: the element </returns>
      ///	 
      public virtual JDFEmployeeDef getEmployeeDef(int iSkip)
      {
         return (JDFEmployeeDef)getValidElement(ElementName.EMPLOYEEDEF, null, iSkip);
      }


      ///   
      ///	 <summary> * get Element <code>JDFController</code>, create if it doesn't exist
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFJDFController: the element </returns>
      ///	 
      public virtual JDFJDFController getCreateJDFController(int iSkip)
      {
         return (JDFJDFController)getCreateValidElement(ElementName.JDFCONTROLLER, null, iSkip);
      }

      

      ///   
      ///	 <summary> * Append element <code>JDFController</code>
      ///	 *  </summary>
      ///	 * <returns> JDFJDFController: the element </returns>
      ///	 
      public virtual JDFJDFController appendJDFController()
      {
         return (JDFJDFController)appendValidElement(ElementName.JDFCONTROLLER, null);
      }

      
      ///   
      ///	 <summary> * get iSkip'th JDFController element
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elemts to skip </param>
      ///	 * <returns> JDFJDFController: the element </returns>
      ///	 
      public virtual JDFJDFController getJDFController(int iSkip)
      {
         return (JDFJDFController)getValidElement(ElementName.JDFCONTROLLER, null, iSkip);
      }


      ///   
      ///	 <summary> * get iSkip'th element <code>JDFService</code>, create if it doesn't exist
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFJDFService: the element </returns>
      ///	 
      public virtual JDFJDFService getCreateJDFService(int iSkip)
      {
         return (JDFJDFService)getCreateValidElement(ElementName.JDFSERVICE, null, iSkip);
      }

      

      ///   
      ///	 <summary> * Append element <code>JDFService</code>
      ///	 *  </summary>
      ///	 * <returns> JDFJDFService the element </returns>
      ///	 
      public virtual JDFJDFService appendJDFService()
      {
         return (JDFJDFService)appendValidElement(ElementName.JDFSERVICE, null);
      }

      
      ///   
      ///	 <summary> * get iSkip'th <code>JDFService</code> element
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFJDFService: the element </returns>
      ///	 
      public virtual JDFJDFService getJDFService(int iSkip)
      {
         return (JDFJDFService)getValidElement(ElementName.JDFSERVICE, null, iSkip);
      }


      ///   
      ///	 <summary> * get Element <code>JobPhase</code>, create if it doesn't exist
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFJobPhase: the element </returns>
      ///	 
      public virtual JDFJobPhase getCreateJobPhase(int iSkip)
      {
         return (JDFJobPhase)getValidElement(ElementName.JOBPHASE, null, iSkip);
      }

      

      ///   
      ///	 <summary> * append element <code>JobPhase</code>
      ///	 *  </summary>
      ///	 * <returns> JDFJobPhase: the element </returns>
      ///	 
      public virtual JDFJobPhase appendJobPhase()
      {
         return (JDFJobPhase)appendValidElement(ElementName.JOBPHASE, null);
      }

      
      ///   
      ///	 <summary> * get iSkip'th <code>JobPhase</code> element
      ///	 *  </summary>
      ///	 * <param name="iSkip"> elements to skip </param>
      ///	 * <returns> JDFJobPhase: the element </returns>
      ///	 
      public virtual JDFJobPhase getJobPhase(int iSkip)
      {
         return (JDFJobPhase)getValidElement(ElementName.JOBPHASE, null, iSkip);
      }


      ///   
      ///	 <summary> * get iSkip'th <code>KnownMsgQuParams</code> element, create if it doesn't exist
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFKnownMsgQuParams the element </returns>
      ///	 
      public virtual JDFKnownMsgQuParams getCreateKnownMsgQuParams(int iSkip)
      {
         return (JDFKnownMsgQuParams)getCreateValidElement(ElementName.KNOWNMSGQUPARAMS, null, iSkip);
      }

      

      ///   
      ///	 <summary> * append element <code>KnownMsgQuParams</code>
      ///	 *  </summary>
      ///	 * <returns> JDFKnownMsgQuParams: the element </returns>
      ///	 
      public virtual JDFKnownMsgQuParams appendKnownMsgQuParams()
      {
         return (JDFKnownMsgQuParams)appendValidElement(ElementName.KNOWNMSGQUPARAMS, null);
      }

      

      ///   
      ///	 <summary> * get iSkip'th <code>KnownMsgQuParams</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFKnownMsgQuParams: the element </returns>
      ///	 
      public virtual JDFKnownMsgQuParams getKnownMsgQuParams(int iSkip)
      {
         return (JDFKnownMsgQuParams)getValidElement(ElementName.KNOWNMSGQUPARAMS, null, iSkip);
      }


      ///   
      ///	 <summary> * get iSkip'th element <code>MessageService</code>, create if it doesn't exist
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFMessageService: the element </returns>
      ///	 
      public virtual JDFMessageService getCreateMessageService(int iSkip)
      {
         return (JDFMessageService)getCreateValidElement(ElementName.MESSAGESERVICE, null, iSkip);
      }

      

      ///   
      ///	 <summary> * append element <code>MessageService</code> </summary>
      ///	 
      public virtual JDFMessageService appendMessageService()
      {
         return (JDFMessageService)appendValidElement(ElementName.MESSAGESERVICE, null);
      }

      
      ///   
      ///	 <summary> * get iSkip'th element <code>MessageService</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFMessageService: the element </returns>
      ///	 
      public virtual JDFMessageService getMessageService(int iSkip)
      {
         return (JDFMessageService)getValidElement(ElementName.MESSAGESERVICE, null, iSkip);
      }


      ///   
      ///	 <summary> * get element <code>MsgFilter</code>, create if it doesn't exist
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFMsgFilter: the element </returns>
      ///	 
      public virtual JDFMsgFilter getCreateMsgFilter(int iSkip)
      {
         return (JDFMsgFilter)getCreateValidElement(ElementName.MSGFILTER, null, iSkip);
      }

      

      ///   
      ///	 <summary> * append element <code>MsgFilter</code>
      ///	 *  </summary>
      ///	 * <returns> JDFMsgFilter: the element </returns>
      ///	 
      public virtual JDFMsgFilter appendMsgFilter()
      {
         return (JDFMsgFilter)appendValidElement(ElementName.MSGFILTER, null);
      }

      

      ///   
      ///	 <summary> * get iSkip'th element <code>MsgFilter</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFMsgFilter: the element </returns>
      ///	 
      public virtual JDFMsgFilter getMsgFilter(int iSkip)
      {
         return (JDFMsgFilter)getValidElement(ElementName.MSGFILTER, null, iSkip);
      }


      ///   
      ///	 <summary> * get element <code>NotificationDef</code>, create if it doesn't exist
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFNotificationDef: the element </returns>
      ///	 
      public virtual JDFNotificationDef getCreateNotificationDef(int iSkip)
      {
         return (JDFNotificationDef)getCreateValidElement(ElementName.NOTIFICATIONDEF, null, iSkip);
      }

      

      ///   
      ///	 <summary> * append element <code>NotificationDef</code>
      ///	 *  </summary>
      ///	 * <returns> JDFNotificationDef: the element </returns>
      ///	 
      public virtual JDFNotificationDef appendNotificationDef()
      {
         return (JDFNotificationDef)appendValidElement(ElementName.NOTIFICATIONDEF, null);
      }

      

      ///   
      ///	 <summary> * get iSkip'th element <code>NotificationDef</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFNotificationDef: the element </returns>
      ///	 
      public virtual JDFNotificationDef getNotificationDef(int iSkip)
      {
         return (JDFNotificationDef)getValidElement(ElementName.NOTIFICATIONDEF, null, iSkip);
      }


      ///   
      ///	 <summary> * get element <code>NotificationFilter</code>, create if it doesn't exist
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFNotificationFilter: the element </returns>
      ///	 
      public virtual JDFNotificationFilter getCreateNotificationFilter(int iSkip)
      {
         return (JDFNotificationFilter)getCreateValidElement(ElementName.NOTIFICATIONFILTER, null, iSkip);
      }

      

      ///   
      ///	 <summary> * append element <code>NotificationFilter</code>
      ///	 *  </summary>
      ///	 * <returns> JDFNotificationFilter: the element </returns>
      ///	 
      public virtual JDFNotificationFilter appendNotificationFilter()
      {
         return (JDFNotificationFilter)appendValidElement(ElementName.NOTIFICATIONFILTER, null);
      }

      
      ///   
      ///	 <summary> * get iSkip'th <code>NotificationFilter</code> element
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFNotificationFilter: the element </returns>
      ///	 
      public virtual JDFNotificationFilter getNotificationFilter(int iSkip)
      {
         return (JDFNotificationFilter)getValidElement(ElementName.NOTIFICATIONFILTER, null, iSkip);
      }


      ///   
      ///	 <summary> * get iSkip'th <code>Occupation</code> element
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFOccupation: the element </returns>
      ///	 
      public virtual JDFOccupation getCreateOccupation(int iSkip)
      {
         return (JDFOccupation)getCreateValidElement(ElementName.OCCUPATION, null, iSkip);
      }

      

      ///   
      ///	 <summary> * append element <code>Occupation</code>
      ///	 *  </summary>
      ///	 * <returns> JDFOccupation: the element </returns>
      ///	 
      public virtual JDFOccupation appendOccupation()
      {
         return (JDFOccupation)appendValidElement(ElementName.OCCUPATION, null);
      }

      
      ///   
      ///	 <summary> * get iSkip'th element <code>Occupation</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFOccupation: the element </returns>
      ///	 
      public virtual JDFOccupation getOccupation(int iSkip)
      {
         return (JDFOccupation)getValidElement(ElementName.OCCUPATION, null, iSkip);
      }


      ///   
      ///	 <summary> * get iSkip'th element <code>PipeParams</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFPipeParams: the element </returns>
      ///	 
      public virtual JDFPipeParams getCreatePipeParams(int iSkip)
      {
         return (JDFPipeParams)getCreateValidElement(ElementName.PIPEPARAMS, null, iSkip);
      }

      

      ///   
      ///	 <summary> * append element <code>PipeParams</code>
      ///	 *  </summary>
      ///	 * <returns> JDFPipeParams: the element </returns>
      ///	 
      public virtual JDFPipeParams appendPipeParams()
      {
         return (JDFPipeParams)appendValidElement(ElementName.PIPEPARAMS, null);
      }

      
      ///   
      ///	 <summary> * get element <code>PipeParams</code>
      ///	 *  </summary>
      ///	 * <returns> JDFPipeParams: the element </returns>
      ///	 
      public virtual JDFPipeParams getPipeParams()
      {
         return (JDFPipeParams)getValidElement(ElementName.PIPEPARAMS, null, 0);
      }

      ///   
      ///	 <summary> * get iSkip'th element <code>PipeParams</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * @deprecated - use the 0 parameter version 
      ///	 * <returns> JDFPipeParams: the element </returns>
      ///	 
      [Obsolete("- use the 0 parameter version")]
      public virtual JDFPipeParams getPipeParams(int iSkip)
      {
         return (JDFPipeParams)getValidElement(ElementName.PIPEPARAMS, null, iSkip);
      }


      ///   
      ///	 <summary> * get iSkip'th element <code>Queue</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFQueue: the element </returns>
      ///	 
      public virtual JDFQueue getCreateQueue(int iSkip)
      {
         return (JDFQueue)getCreateValidElement(ElementName.QUEUE, null, iSkip);
      }

      

      ///   
      ///	 <summary> * append element <code>Queue</code>
      ///	 *  </summary>
      ///	 * <returns> JDFQueue: the element </returns>
      ///	 
      public virtual JDFQueue appendQueue()
      {
         return (JDFQueue)appendValidElement(ElementName.QUEUE, null);
      }

      
      ///   
      ///	 <summary> * get iSkip'th element <code>Queue</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFQueue: the element </returns>
      ///	 
      public virtual JDFQueue getQueue(int iSkip)
      {
         return (JDFQueue)getValidElement(ElementName.QUEUE, null, iSkip);
      }


      ///   
      ///	 <summary> * get iSkip'th element <code>QueueEntry</code>, create if it doesn't exist
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFQueueEntry: the element </returns>
      ///	 
      public virtual JDFQueueEntry getCreateQueueEntry(int iSkip)
      {
         return (JDFQueueEntry)getCreateValidElement(ElementName.QUEUEENTRY, null, iSkip);
      }

      
      ///   
      ///	 <summary> * append element <code>QueueEntry</code>
      ///	 *  </summary>
      ///	 * <returns> JDFQueueEntry: the element </returns>
      ///	 
      public virtual JDFQueueEntry appendQueueEntry()
      {
         return (JDFQueueEntry)appendValidElement(ElementName.QUEUEENTRY, null);
      }

      
      ///   
      ///	 <summary> * get iSkip'th element <code>QueueEntry</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFQueueEntry: the element </returns>
      ///	 
      public virtual JDFQueueEntry getQueueEntry(int iSkip)
      {
         return (JDFQueueEntry)getValidElement(ElementName.QUEUEENTRY, null, iSkip);
      }


      ///   
      ///	 <summary> * get iSkip'th element <code>QueueEntryDef</code>, create if it doesn't exist
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFQueueEntryDef: the element </returns>
      ///	 
      public virtual JDFQueueEntryDef getCreateQueueEntryDef(int iSkip)
      {
         return (JDFQueueEntryDef)getCreateValidElement(ElementName.QUEUEENTRYDEF, null, iSkip);
      }

      

      ///   
      ///	 <summary> * append element <code>QueueEntryDef</code>
      ///	 *  </summary>
      ///	 * <returns> JDFQueueEntryDef: the element </returns>
      ///	 
      public virtual JDFQueueEntryDef appendQueueEntryDef()
      {
         return (JDFQueueEntryDef)appendValidElement(ElementName.QUEUEENTRYDEF, null);
      }

      
      ///   
      ///	 <summary> * get iSkip'th element <code>QueueEntryDef</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFQueueEntryDef: the element </returns>
      ///	 
      public virtual JDFQueueEntryDef getQueueEntryDef(int iSkip)
      {
         return (JDFQueueEntryDef)getValidElement(ElementName.QUEUEENTRYDEF, null, iSkip);
      }


      ///   
      ///	 <summary> * get iSkip'th element QueueEntryDefList, create if it doesn't exist
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFQueueEntryDefList: the element </returns>
      ///	 
      public virtual JDFQueueEntryDefList getCreateQueueEntryDefList(int iSkip)
      {
         return (JDFQueueEntryDefList)getCreateValidElement(ElementName.QUEUEENTRYDEFLIST, null, iSkip);
      }

      

      ///   
      ///	 <summary> * append element <code>QueueEntryDefList</code>
      ///	 *  </summary>
      ///	 * <returns> JDFQueueEntryDefList: the element </returns>
      ///	 
      public virtual JDFQueueEntryDefList appendQueueEntryDefList()
      {
         return (JDFQueueEntryDefList)appendValidElement(ElementName.QUEUEENTRYDEFLIST, null);
      }

      
      ///   
      ///	 <summary> * get iSkip'th element <code>QueueEntryDefList</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFQueueEntryDefList: the element </returns>
      ///	 
      public virtual JDFQueueEntryDefList getQueueEntryDefList(int iSkip)
      {
         return (JDFQueueEntryDefList)getValidElement(ElementName.QUEUEENTRYDEFLIST, null, iSkip);

      }


      ///   
      ///	 <summary> * get iSkip'th element <code>QueueEntryPriParams</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFQueueEntryPriParams: the element </returns>
      ///	 
      public virtual JDFQueueEntryPriParams getCreateQueueEntryPriParams(int iSkip)
      {
         return (JDFQueueEntryPriParams)getCreateValidElement(ElementName.QUEUEENTRYPRIPARAMS, null, iSkip);
      }

      ///   
      ///	 <summary> * append element <code>QueueEntryPriParams</code>
      ///	 *  </summary>
      ///	 * <returns> JDFQueueEntryPriParams: the element </returns>
      ///	 
      public virtual JDFQueueEntryPriParams appendQueueEntryPriParams()
      {
         return (JDFQueueEntryPriParams)appendValidElement(ElementName.QUEUEENTRYPRIPARAMS, null);
      }

      ///   
      ///	 <summary> * get iSkip'th element <code>QueueEntryPriParams</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFQueueEntryPriParams: the element </returns>
      ///	 
      public virtual JDFQueueEntryPriParams getQueueEntryPriParams(int iSkip)
      {
         return (JDFQueueEntryPriParams)getValidElement(ElementName.QUEUEENTRYPRIPARAMS, null, iSkip);
      }


      ///   
      ///	 <summary> * get iSkip'th element QueueEntryPosParams, create if it doesn't exist
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFQueueEntryPosParams: the element </returns>
      ///	 
      public virtual JDFQueueEntryPosParams getCreateQueueEntryPosParams(int iSkip)
      {
         return (JDFQueueEntryPosParams)getCreateValidElement(ElementName.QUEUEENTRYPOSPARAMS, null, iSkip);
      }

      

      ///   
      ///	 <summary> * append element <code>QueueEntryPosParams</code>
      ///	 *  </summary>
      ///	 * <returns> JDFQueueEntryPosParams: the element </returns>
      ///	 
      public virtual JDFQueueEntryPosParams appendQueueEntryPosParams()
      {
         return (JDFQueueEntryPosParams)appendValidElement(ElementName.QUEUEENTRYPOSPARAMS, null);
      }

      
      ///   
      ///	 <summary> * get iSkip'th element <code>QeueEntryPosParams</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFQueueEntryPosParams: the element </returns>
      ///	 
      public virtual JDFQueueEntryPosParams getQueueEntryPosParams(int iSkip)
      {
         return (JDFQueueEntryPosParams)getValidElement(ElementName.QUEUEENTRYPOSPARAMS, null, iSkip);
      }


      ///   
      ///	 <summary> * get iSkip'th element <code>QueueSubmissionParams</code>
      ///	 *  </summary>
      ///	 * <param name="int"> iSkip number of elements to skip </param>
      ///	 * <returns> JDFQueueSubmissionParams: the element </returns>
      ///	 
      public virtual JDFQueueSubmissionParams getCreateQueueSubmissionParams(int iSkip)
      {
         return (JDFQueueSubmissionParams)getCreateValidElement(ElementName.QUEUESUBMISSIONPARAMS, null, iSkip);
      }

      

      ///   
      ///	 <summary> * append element <code>QueueSubmissionParams</code>
      ///	 *  </summary>
      ///	 * <returns> JDFQueueSubmissionParams: the element </returns>
      ///	 
      public virtual JDFQueueSubmissionParams appendQueueSubmissionParams()
      {
         return (JDFQueueSubmissionParams)appendValidElement(ElementName.QUEUESUBMISSIONPARAMS, null);
      }

      
      ///   
      ///	 <summary> * get iSkip'th element <code>QueueSubmissionParams</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFQueueSubmissionParams: the element </returns>
      ///	 
      public virtual JDFQueueSubmissionParams getQueueSubmissionParams(int iSkip)
      {
         return (JDFQueueSubmissionParams)getValidElement(ElementName.QUEUESUBMISSIONPARAMS, null, iSkip);
      }


      ///   
      ///	 <summary> * get iSkip'th element <code>ResourceCmdParams</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFResourceCmdParams: the element </returns>
      ///	 
      public virtual JDFResourceCmdParams getCreateResourceCmdParams(int iSkip)
      {
         return (JDFResourceCmdParams)getCreateValidElement(ElementName.RESOURCECMDPARAMS, null, iSkip);
      }

      

      ///   
      ///	 <summary> * append element <code>ResourceCmdParams</code>
      ///	 *  </summary>
      ///	 * <returns> JDFResourceCmdParams: the element </returns>
      ///	 
      public virtual JDFResourceCmdParams appendResourceCmdParams()
      {
         return (JDFResourceCmdParams)appendValidElement(ElementName.RESOURCECMDPARAMS, null);
      }

      
      ///   
      ///	 <summary> * get iSkip'th element <code>ResourceCmdParams</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFResourceCmdParams: the element </returns>
      ///	 
      public virtual JDFResourceCmdParams getResourceCmdParams(int iSkip)
      {
         return (JDFResourceCmdParams)getValidElement(ElementName.RESOURCECMDPARAMS, null, iSkip);
      }


      ///   
      ///	 <summary> * get iSkip'th element <code>ResourceQuParams</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFResourceQuParams: the element </returns>
      ///	 
      public virtual JDFResourceQuParams getCreateResourceQuParams(int iSkip)
      {
         return (JDFResourceQuParams)getCreateValidElement(ElementName.RESOURCEQUPARAMS, null, iSkip);
      }

      

      ///   
      ///	 <summary> * append element <code>ResourceQuParams</code>
      ///	 *  </summary>
      ///	 * <returns> JDFResourceQuParams: the element </returns>
      ///	 
      public virtual JDFResourceQuParams appendResourceQuParams()
      {
         return (JDFResourceQuParams)appendValidElement(ElementName.RESOURCEQUPARAMS, null);
      }

      
      ///   
      ///	 <summary> * get iSkip'th element <code>ResourceQuParams</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFResourceQuParams: the element </returns>
      ///	 * @deprecated use null parameter version 
      ///	 
      [Obsolete("use null parameter version")]
      public virtual JDFResourceQuParams getResourceQuParams(int iSkip)
      {
         return (JDFResourceQuParams)getValidElement(ElementName.RESOURCEQUPARAMS, null, iSkip);
      }

      ///   
      ///	 <summary> * get first element <code>ResourceQuParams</code>
      ///	 *  </summary>
      ///	 * <returns> JDFResourceQuParams: the element </returns>
      ///	 
      public virtual JDFResourceQuParams getResourceQuParams()
      {
         return (JDFResourceQuParams)getValidElement(ElementName.RESOURCEQUPARAMS, null, 0);
      }


      ///   
      ///	 <summary> * get iSkip'th element <code>ResourceInfo</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFResourceInfo: the element </returns>
      ///	 
      public virtual JDFResourceInfo getCreateResourceInfo(int iSkip)
      {
         return (JDFResourceInfo)getCreateValidElement(ElementName.RESOURCEINFO, null, iSkip);
      }

      

      ///   
      ///	 <summary> * append element <code>ResourceInfo</code>
      ///	 *  </summary>
      ///	 * <returns> JDFResourceInfo: the element </returns>
      ///	 
      public virtual JDFResourceInfo appendResourceInfo()
      {
         return (JDFResourceInfo)appendValidElement(ElementName.RESOURCEINFO, null);
      }

      
      ///   
      ///	 <summary> * get iSkip'th element <code>ResourceInfo</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFResourceInfo: the element </returns>
      ///	 
      public virtual JDFResourceInfo getResourceInfo(int iSkip)
      {
         return (JDFResourceInfo)getValidElement(ElementName.RESOURCEINFO, null, iSkip);
      }


      ///   
      ///	 <summary> * get iSkip'th element <code>StatusQuParams</code>, create if it doesn't exist
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFStatusQuParams: the element </returns>
      ///	 
      public virtual JDFStatusQuParams getCreateStatusQuParams(int iSkip)
      {
         return (JDFStatusQuParams)getCreateValidElement(ElementName.STATUSQUPARAMS, null, iSkip);
      }

      

      ///   
      ///	 <summary> * append element <code>StatusQuParams</code>
      ///	 *  </summary>
      ///	 * <returns> JDFStatusQuParams: the element </returns>
      ///	 
      public virtual JDFStatusQuParams appendStatusQuParams()
      {
         return (JDFStatusQuParams)appendValidElement(ElementName.STATUSQUPARAMS, null);
      }

      

      ///   
      ///	 <summary> * get iSkip'th element StatusQuParams
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFStatusQuParams: the element </returns>
      ///	 * @deprecated - use 0 parameter version 
      ///	 
      [Obsolete("- use 0 parameter version")]
      public virtual JDFStatusQuParams getStatusQuParams(int iSkip)
      {
         return (JDFStatusQuParams)getValidElement(ElementName.STATUSQUPARAMS, null, iSkip);
      }

      ///   
      ///	 <summary> * get iSkip'th element StatusQuParams
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFStatusQuParams: the element </returns>
      ///	 
      public virtual JDFStatusQuParams getStatusQuParams()
      {
         return (JDFStatusQuParams)getValidElement(ElementName.STATUSQUPARAMS, null, 0);
      }


      ///   
      ///	 <summary> * get iSkip'th element StopPersChParams
      ///	 *  </summary>
      ///	 * <param name="int"> iSkip number of elements to skip </param>
      ///	 * <returns> JDFStopPersChParams: the element </returns>
      ///	 
      public virtual JDFStopPersChParams getCreateStopPersChParams(int iSkip)
      {
         return (JDFStopPersChParams)getCreateValidElement(ElementName.STOPPERSCHPARAMS, null, iSkip);
      }

      

      ///   
      ///	 <summary> * append element <code>StopPersChParams</code>
      ///	 *  </summary>
      ///	 * <returns> JDFStopPersChParams: the element </returns>
      ///	 
      public virtual JDFStopPersChParams appendStopPersChParams()
      {
         return (JDFStopPersChParams)appendValidElement(ElementName.STOPPERSCHPARAMS, null);
      }

      

      ///   
      ///	 <summary> * get iSkip'th element <code>StopPersChParams</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFStopPersChParams: the element </returns>
      ///	 
      public virtual JDFStopPersChParams getStopPersChParams(int iSkip)
      {
         return (JDFStopPersChParams)getValidElement(ElementName.STOPPERSCHPARAMS, null, iSkip);
      }


      ///   
      ///	 <summary> * get iSkip'th element <code>SubmissionMethods</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFSubmissionMethods: the element </returns>
      ///	 
      public virtual JDFSubmissionMethods getCreateSubmissionMethods(int iSkip)
      {
         return (JDFSubmissionMethods)getCreateValidElement(ElementName.SUBMISSIONMETHODS, null, iSkip);
      }

      

      ///   
      ///	 <summary> * append element <code>SubmissionMethods</code>
      ///	 *  </summary>
      ///	 * <returns> JDFSubmissionMethods: the element </returns>
      ///	 
      public virtual JDFSubmissionMethods appendSubmissionMethods()
      {
         return (JDFSubmissionMethods)appendValidElement(ElementName.SUBMISSIONMETHODS, null);
      }

      
      ///   
      ///	 <summary> * get iSkip'th element <code>SubMissionMethods</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFSubmissionMethods: the element </returns>
      ///	 
      public virtual JDFSubmissionMethods getSubmissionMethods(int iSkip)
      {
         return (JDFSubmissionMethods)getValidElement(ElementName.SUBMISSIONMETHODS, null, iSkip);
      }


      ///   
      ///	 <summary> * get iSkip'th element <code>TrackFilter</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFTrackFilter: the element </returns>
      ///	 
      public virtual JDFTrackFilter getCreateTrackFilter(int iSkip)
      {
         return (JDFTrackFilter)getCreateValidElement(ElementName.TRACKFILTER, null, iSkip);
      }

      

      ///   
      ///	 <summary> * append element <code>TrackFilter</code>
      ///	 *  </summary>
      ///	 * <returns> JDFTrackFilter: the element </returns>
      ///	 
      public virtual JDFTrackFilter appendTrackFilter()
      {
         return (JDFTrackFilter)appendValidElement(ElementName.TRACKFILTER, null);
      }

      
      ///   
      ///	 <summary> * get iSkip'th element <code>TrackFilter</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFTrackFilter: the element </returns>
      ///	 
      public virtual JDFTrackFilter getTrackFilter(int iSkip)
      {
         return (JDFTrackFilter)getValidElement(ElementName.TRACKFILTER, null, iSkip);
      }


      ///   
      ///	 <summary> * get iSkip'th element <code>TrackResult</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFTrackResult: the element </returns>
      ///	 
      public virtual JDFTrackResult getCreateTrackResult(int iSkip)
      {
         return (JDFTrackResult)getCreateValidElement(ElementName.TRACKRESULT, null, iSkip);
      }

      

      ///   
      ///	 <summary> * append element <code>TrackResult</code>
      ///	 *  </summary>
      ///	 * <returns> JDFTrackResult: the element </returns>
      ///	 
      public virtual JDFTrackResult appendTrackResult()
      {
         return (JDFTrackResult)appendValidElement(ElementName.TRACKRESULT, null);
      }

      
      ///   
      ///	 <summary> * get the iSkip'th element <code>TrackResult</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip"> the number of elements to skip </param>
      ///	 * <returns> JDFTrackResult: the element </returns>
      ///	 
      public virtual JDFTrackResult getTrackResult(int iSkip)
      {
         return (JDFTrackResult)getValidElement(ElementName.TRACKRESULT, null, iSkip);
      }

      // new from QC.JMF package

      ///   
      ///	 <summary> * Returns the ReturnCode; applies to JmfResponse and JmfAcknowledge.
      ///	 *  </summary>
      ///	 * <returns> ConstReturnCode </returns>
      ///	 
      public virtual int getReturnCode()
      {
         return getIntAttribute(AttributeName.RETURNCODE, null, 0);
      }

      ///   
      ///	 <summary> * get iSkip'th element <code>IDInfo</code>, create if it doesn't exist
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFIDInfo: the element </returns>
      ///	 
      public virtual JDFIDInfo getCreateIDInfo(int iSkip)
      {
         return (JDFIDInfo)getCreateValidElement(ElementName.IDINFO, null, iSkip);
      }

      ///   
      ///	 <summary> * append element <code>IDInfo</code> JDFIDInfo: the element </summary>
      ///	 
      public virtual JDFIDInfo appendIDInfo()
      {
         return (JDFIDInfo)appendValidElement(ElementName.IDINFO, null);
      }

      ///   
      ///	 <summary> * get iSkip'th element <code>IDInfo</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip JDFIDInfo: the element </param>
      ///	 
      public virtual JDFIDInfo getIDInfo(int iSkip)
      {
         return (JDFIDInfo)getValidElement(ElementName.IDINFO, null, iSkip);
      }

      ///   
      ///	 <summary> * get iSkip'th element FlushedResources
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFFlushedResources: the element </returns>
      ///	 
      public virtual JDFFlushedResources getCreateFlushedResources(int iSkip)
      {
         return (JDFFlushedResources)getCreateValidElement(ElementName.FLUSHEDRESOURCES, null, iSkip);
      }

      ///   
      ///	 <summary> * append element <code>FlushedResources</code>
      ///	 *  </summary>
      ///	 * <returns> JDFFlushedResources: the element </returns>
      ///	 
      public virtual JDFFlushedResources appendFlushedResources()
      {
         return (JDFFlushedResources)appendValidElement(ElementName.FLUSHEDRESOURCES, null);
      }

      public virtual JDFFlushedResources getFlushedResources(int iSkip)
      {
         return (JDFFlushedResources)getValidElement(ElementName.FLUSHEDRESOURCES, null, iSkip);
      }

      public virtual JDFFlushQueueParams getCreateFlushQueueParams(int iSkip)
      {
         return (JDFFlushQueueParams)getCreateValidElement(ElementName.FLUSHQUEUEPARAMS, null, iSkip);
      }

      public virtual JDFFlushQueueInfo getCreateFlushQueueInfo(int iSkip)
      {
         return (JDFFlushQueueInfo)getCreateValidElement(ElementName.FLUSHQUEUEINFO, null, iSkip);
      }

      public virtual JDFFlushQueueInfo getFlushQueueInfo(int iSkip)
      {
         return (JDFFlushQueueInfo)getValidElement(ElementName.FLUSHQUEUEINFO, null, iSkip);
      }

      public virtual JDFFlushQueueParams appendFlushQueueParams()
      {
         return (JDFFlushQueueParams)appendValidElement(ElementName.FLUSHQUEUEPARAMS, null);
      }

      public virtual JDFFlushQueueInfo appendFlushQueueInfo()
      {
         return (JDFFlushQueueInfo)appendValidElement(ElementName.FLUSHQUEUEINFO, null);
      }

      public virtual JDFFlushQueueParams getFlushQueueParams(int iSkip)
      {
         return (JDFFlushQueueParams)getValidElement(ElementName.FLUSHQUEUEPARAMS, null, iSkip);
      }

      public virtual JDFFlushResourceParams getCreateFlushResourceParams(int iSkip)
      {
         return (JDFFlushResourceParams)getCreateValidElement(ElementName.FLUSHRESOURCEPARAMS, null, iSkip);
      }

      public virtual JDFFlushResourceParams appendFlushResourceParams()
      {
         return (JDFFlushResourceParams)appendValidElement(ElementName.FLUSHRESOURCEPARAMS, null);
      }

      public virtual JDFFlushResourceParams getFlushResourceParams(int iSkip)
      {
         return (JDFFlushResourceParams)getValidElement(ElementName.FLUSHRESOURCEPARAMS, null, iSkip);
      }

      public virtual JDFNewJDFCmdParams getCreateNewJDFCmdParams(int iSkip)
      {
         return (JDFNewJDFCmdParams)getCreateValidElement(ElementName.NEWJDFCMDPARAMS, null, iSkip);
      }

      public virtual JDFNewJDFCmdParams appendNewJDFCmdParams()
      {
         return (JDFNewJDFCmdParams)appendValidElement(ElementName.NEWJDFCMDPARAMS, null);
      }

      public virtual JDFNewJDFCmdParams getNewJDFCmdParams(int iSkip)
      {
         return (JDFNewJDFCmdParams)getValidElement(ElementName.NEWJDFCMDPARAMS, null, iSkip);
      }

      public virtual JDFNewJDFQuParams getCreateNewJDFQuParams(int iSkip)
      {
         return (JDFNewJDFQuParams)getCreateValidElement(ElementName.NEWJDFQUPARAMS, null, iSkip);
      }

      public virtual JDFNewJDFQuParams appendNewJDFQuParams()
      {
         return (JDFNewJDFQuParams)appendValidElement(ElementName.NEWJDFQUPARAMS, null);
      }

      public virtual JDFNewJDFQuParams getNewJDFQuParams(int iSkip)
      {
         return (JDFNewJDFQuParams)getValidElement(ElementName.NEWJDFQUPARAMS, null, iSkip);
      }

      public virtual JDFNodeInfoCmdParams getCreateNodeInfoCmdParams(int iSkip)
      {
         return (JDFNodeInfoCmdParams)getCreateValidElement(ElementName.NODEINFOCMDPARAMS, null, iSkip);
      }

      public virtual JDFNodeInfoCmdParams appendNodeInfoCmdParams()
      {
         return (JDFNodeInfoCmdParams)appendValidElement(ElementName.NODEINFOCMDPARAMS, null);
      }

      public virtual JDFNodeInfoCmdParams getNodeInfoCmdParams(int iSkip)
      {
         return (JDFNodeInfoCmdParams)getValidElement(ElementName.NODEINFOCMDPARAMS, null, iSkip);
      }

      public virtual JDFNodeInfoQuParams getCreateNodeInfoQuParams(int iSkip)
      {
         return (JDFNodeInfoQuParams)getCreateValidElement(ElementName.NODEINFOQUPARAMS, null, iSkip);
      }

      public virtual JDFNodeInfoQuParams appendNodeInfoQuParams()
      {
         return (JDFNodeInfoQuParams)appendValidElement(ElementName.NODEINFOQUPARAMS, null);
      }

      public virtual JDFNodeInfoQuParams getNodeInfoQuParams(int iSkip)
      {
         return (JDFNodeInfoQuParams)getValidElement(ElementName.NODEINFOQUPARAMS, null, iSkip);
      }

      public virtual JDFNodeInfoResp getCreateNodeInfoResp(int iSkip)
      {
         return (JDFNodeInfoResp)getCreateValidElement(ElementName.NODEINFORESP, null, iSkip);
      }

      public virtual JDFNodeInfoResp appendNodeInfoResp()
      {
         return (JDFNodeInfoResp)appendValidElement(ElementName.NODEINFORESP, null);
      }

      public virtual JDFNodeInfoResp getNodeInfoResp(int iSkip)
      {
         return (JDFNodeInfoResp)getValidElement(ElementName.NODEINFORESP, null, iSkip);
      }

      public virtual JDFQueueFilter getCreateQueueFilter(int iSkip)
      {
         return (JDFQueueFilter)getCreateValidElement(ElementName.QUEUEFILTER, null, iSkip);
      }

      

      public virtual JDFQueueFilter appendQueueFilter()
      {
         return (JDFQueueFilter)appendValidElement(ElementName.QUEUEFILTER, null);
      }

      

      public virtual JDFQueueFilter getQueueFilter(int iSkip)
      {
         return (JDFQueueFilter)getValidElement(ElementName.QUEUEFILTER, null, iSkip);
      }

      public virtual JDFRequestQueueEntryParams getCreateRequestQueueEntryParams(int iSkip)
      {
         return (JDFRequestQueueEntryParams)getCreateValidElement(ElementName.REQUESTQUEUEENTRYPARAMS, null, iSkip);
      }

      public virtual JDFRequestQueueEntryParams appendRequestQueueEntryParams()
      {
         return (JDFRequestQueueEntryParams)appendValidElement(ElementName.REQUESTQUEUEENTRYPARAMS, null);
      }

      public virtual JDFRequestQueueEntryParams getRequestQueueEntryParams(int iSkip)
      {
         return (JDFRequestQueueEntryParams)getValidElement(ElementName.REQUESTQUEUEENTRYPARAMS, null, iSkip);
      }

      internal virtual JDFResourcePullParams getCreateResourcePullParams(int iSkip)
      {
         return (JDFResourcePullParams)getCreateValidElement(ElementName.RESOURCEPULLPARAMS, null, iSkip);
      }

      public virtual JDFResourcePullParams appendResourcePullParams()
      {
         return (JDFResourcePullParams)appendValidElement(ElementName.RESOURCEPULLPARAMS, null);
      }

      public virtual JDFResourcePullParams getResourcePullParams(int iSkip)
      {
         return (JDFResourcePullParams)getValidElement(ElementName.RESOURCEPULLPARAMS, null, iSkip);
      }

      public virtual JDFResubmissionParams getCreateResubmissionParams(int iSkip)
      {
         return (JDFResubmissionParams)getCreateValidElement(ElementName.RESUBMISSIONPARAMS, null, iSkip);
      }

      public virtual JDFResubmissionParams appendResubmissionParams()
      {
         return (JDFResubmissionParams)appendValidElement(ElementName.RESUBMISSIONPARAMS, null);
      }

      public virtual JDFResubmissionParams getResubmissionParams(int iSkip)
      {
         return (JDFResubmissionParams)getValidElement(ElementName.RESUBMISSIONPARAMS, null, iSkip);
      }

      public virtual JDFReturnQueueEntryParams getCreateReturnQueueEntryParams(int iSkip)
      {
         return (JDFReturnQueueEntryParams)getCreateValidElement(ElementName.RETURNQUEUEENTRYPARAMS, null, iSkip);
      }

      public virtual JDFReturnQueueEntryParams appendReturnQueueEntryParams()
      {
         return (JDFReturnQueueEntryParams)appendValidElement(ElementName.RETURNQUEUEENTRYPARAMS, null);
      }

      public virtual JDFReturnQueueEntryParams getReturnQueueEntryParams(int iSkip)
      {
         return (JDFReturnQueueEntryParams)getValidElement(ElementName.RETURNQUEUEENTRYPARAMS, null, iSkip);
      }

      public virtual JDFShutDownCmdParams getCreateShutDownCmdParams(int iSkip)
      {
         return (JDFShutDownCmdParams)getCreateValidElement(ElementName.SHUTDOWNCMDPARAMS, null, iSkip);
      }

      public virtual JDFShutDownCmdParams appendShutDownCmdParams()
      {
         return (JDFShutDownCmdParams)appendValidElement(ElementName.SHUTDOWNCMDPARAMS, null);
      }

      public virtual JDFShutDownCmdParams getShutDownCmdParams(int iSkip)
      {
         return (JDFShutDownCmdParams)getValidElement(ElementName.SHUTDOWNCMDPARAMS, null, iSkip);
      }


      public virtual JDFWakeUpCmdParams getCreateWakeUpCmdParams()
      {
         return (JDFWakeUpCmdParams)getCreateValidElement(ElementName.WAKEUPCMDPARAMS, null, 0);
      }

      public virtual JDFWakeUpCmdParams appendWakeUpCmdParams()
      {
         return (JDFWakeUpCmdParams)appendValidElement(ElementName.WAKEUPCMDPARAMS, null);
      }

      public virtual JDFWakeUpCmdParams getWakeUpCmdParams()
      {
         return (JDFWakeUpCmdParams)getValidElement(ElementName.WAKEUPCMDPARAMS, null, 0);
      }


      public virtual JDFModifyNodeCmdParams getCreateModifyNodeCmdParams()
      {
         return (JDFModifyNodeCmdParams)getCreateValidElement(ElementName.MODIFYNODECMDPARAMS, null, 0);
      }

      public virtual JDFModifyNodeCmdParams appendModifyNodeCmdParams()
      {
         return (JDFModifyNodeCmdParams)appendValidElement(ElementName.MODIFYNODECMDPARAMS, null);
      }

      public virtual JDFModifyNodeCmdParams getModifyNodeCmdParams()
      {
         return (JDFModifyNodeCmdParams)getValidElement(ElementName.MODIFYNODECMDPARAMS, null, 0);
      }


      public virtual JDFUpdateJDFCmdParams getCreateUpdateJDFCmdParams()
      {
         return (JDFUpdateJDFCmdParams)getCreateValidElement(ElementName.UPDATEJDFCMDPARAMS, null, 0);
      }

      public virtual JDFUpdateJDFCmdParams appendUpdateJDFCmdParams()
      {
         return (JDFUpdateJDFCmdParams)appendValidElement(ElementName.UPDATEJDFCMDPARAMS, null);
      }

      public virtual JDFUpdateJDFCmdParams getUpdateJDFCmdParams()
      {
         return (JDFUpdateJDFCmdParams)getValidElement(ElementName.UPDATEJDFCMDPARAMS, null, 0);
      }

      ///   
      ///	 <summary> * Method getrefID.
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public virtual string getrefID()
      {
         return getAttribute(AttributeName.REFID);
      }

      ///   
      ///	 <summary> * Method setrefID.
      ///	 *  </summary>
      ///	 * <param name="refIF"> </param>
      ///	 
      public virtual void setrefID(string refID)
      {
         setAttribute(AttributeName.REFID, refID);
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.auto.JDFAutoMessage#getID()
      //	 
      public override string getID()
      {
         return this.getAttribute(AttributeName.ID, null, null);
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.core.JDFElement#getInvalidElements(org.cip4.jdflib.core .KElement.EnumValidationLevel,
      //	 * boolean, int)
      //	 
      public override VString getInvalidElements(EnumValidationLevel level, bool bIgnorePrivate, int nMax)
      {
         int nElem = 0;
         VString vElem = base.getInvalidElements(level, bIgnorePrivate, nMax);
         int n = vElem.Count;
         if (n >= nMax)
         {
            return vElem;
         }

         KElement[] ae = getChildElementArray();
         if (ae == null || ae.Length == 0)
         {
            return vElem;
         }
         SupportClass.SetSupport s = new SupportClass.HashSetSupport();
         for (int i = 0; i < ae.Length; i++)
         {
            s.Add(ae[i].LocalName);
         }

         for (int ii = 0; ii < elementArray.Length; ii++)
         {
            string element = elementArray[ii];
            if (!s.Contains(element))
            {
               continue;
            }

            nElem = numChildElements(element, null);
            for (int i = 0; i < nElem; i++)
            {
               KElement child = null;
               bool bCatch = false;

               try
               {
                  child = getValidElement(element, null, i);
               }
               catch (JDFException)
               {
                  bCatch = true;
               }
               if (bCatch || child == null || !child.isValid(level))
               {
                  vElem.appendUnique(element);
                  if (++n >= nMax)
                  {
                     return vElem;
                  }
                  break;
               }
            }
         }

         return vElem;
      }

      ///   
      ///	 <summary> * definition of optional elements in the JDF namespace </summary>
      ///	 
      // TODO move to elemeInfoTable creation
      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.core.KElement#optionalElements()
      //	 
      public override VString optionalElements()
      {
         VString s = base.optionalElements();
         EnumType t = getEnumType();
         // loop over all valid potential elements for this family
         string[] vObjs = familyTypeObj();
         // for each object, check whether it is compatible with the type of this
         for (int i = 0; i < vObjs.Length; i++)
         {
            List<EnumType> vt = getValidTypeVector(vObjs[i], 0);
            // is it there ?
            for (int j = 0; j < vt.Count; j++)
            {
               if (vt[j].Equals(t))
               {
                  // obj x is compatible with this -> add it to the list of
                  // elements
                  s.appendUnique(vObjs[i]);
                  break;
               }
            }
         }
         return s;
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.core.JDFElement#getInvalidAttributes(org.cip4.jdflib. core.KElement.EnumValidationLevel,
      //	 * boolean, int)
      //	 
      public override VString getInvalidAttributes(EnumValidationLevel level, bool bIgnorePrivate, int nMax)
      {
         VString s = base.getInvalidAttributes(level, bIgnorePrivate, nMax);
         if (s.Contains(AttributeName.XSITYPE))
         {
            return s;
         }

         if (!hasAttribute(AttributeName.XSITYPE))
         {
            return s;
         }
         string t = getType();
         if (xmlnsPrefix(t) != null)
         {
            return s;
         }
         string xs = getXSIType();
         if (xs != null && !xs.Equals(LocalName + t))
         {
            s.Add(AttributeName.XSITYPE);
         }
         return s;

      }


      ///   
      ///	 <summary> * sets the senderID of this message
      ///	 *  </summary>
      ///	 * <param name="senderID"> </param>
      ///	 
      public virtual void setSenderID(string senderID)
      {
         setAttribute(AttributeName.SENDERID, senderID);
      }


      ///   
      ///	 <summary> * gets the senderID of this message
      ///	 *  </summary>
      ///	 * <returns> String the senderID of this message or the SenderID of the parent JMF; null if neither are specified </returns>
      ///	 
      public virtual string getSenderID()
      {
         if (hasAttribute(AttributeName.SENDERID))
            return getAttribute(AttributeName.SENDERID);
         KElement parentJMF = getParentNode_KElement();
         if (parentJMF is JDFJMF)
            return ((JDFJMF)parentJMF).getSenderID();
         return null;
      }

      public override VString getDeprecatedElements(int nMax)
      {
         VString v = base.getDeprecatedElements(nMax);

         if (EnumUtil.aLessThanB(EnumVersion.Version_1_1, getVersion(true)) && hasChildElement(ElementName.JDFSERVICE, null))
            v.Add(ElementName.JDFSERVICE);
         return v;
      }

      public override EnumVersion getLastVersion(string eaName, bool bElement)
      {
         if (ElementName.JDFSERVICE.Equals(eaName) && bElement)
            return EnumVersion.Version_1_1;

         return base.getLastVersion(eaName, bElement);
      }
   }
}
