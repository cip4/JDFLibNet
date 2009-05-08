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
 * 07082002 KM moved JDFElement.EnumNodeStatus GetStatus to JDFElement
 * 05092002 KM deleted GetStart() and GetEnd() if you need them use JDFProcessRun methods */

namespace org.cip4.jdflib.core
{
   using System;
   using System.Runtime.CompilerServices;
   using System.Collections;


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using JDFAuditPool = org.cip4.jdflib.pool.JDFAuditPool;
   using JDFDate = org.cip4.jdflib.util.JDFDate;
   using StringUtil = org.cip4.jdflib.util.StringUtil;

   ///
   /// <summary> * This class represents a JDF-Audit which handles individual Audit elements </summary>
   /// 
   public class JDFAudit : JDFElement
   {

      private new const long serialVersionUID = 1L;
      private const string m_libAgentName = "CIP4 JDF Writer C#";
      private const string m_libAgentVersion = "1.3 BLD 52";

      // use reasonable defaults
      private static string m_strAgentName = m_libAgentName;
      private static string m_strAgentVersion = m_libAgentVersion;
      private static string m_strAuthor = software();

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[7];
      static JDFAudit()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.AUTHOR, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.SPAWNID, 0x33333331, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.AGENTNAME, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.AGENTVERSION, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.ID, 0x33333311, AttributeInfo.EnumAttributeType.ID, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.REFID, 0x33333311, AttributeInfo.EnumAttributeType.IDREF, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.TIMESTAMP, 0x33333222, AttributeInfo.EnumAttributeType.dateTime, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }

      ///   
      ///	 <summary> * Constructor for JDFAudit
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFAudit(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFAudit
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFAudit(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFAudit
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="localName"> </param>
      ///	 
      public JDFAudit(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      public class EnumAuditType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         protected internal EnumAuditType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumAuditType getEnum(string enumName)
         {
            return (EnumAuditType)getEnum(typeof(EnumAuditType), enumName);
         }

         public static EnumAuditType getEnum(int enumValue)
         {
            return (EnumAuditType)getEnum(typeof(EnumAuditType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumAuditType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumAuditType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumAuditType));
         }

         public static readonly EnumAuditType Created = new EnumAuditType("Created");
         public static readonly EnumAuditType Modified = new EnumAuditType("Modified");
         public static readonly EnumAuditType Deleted = new EnumAuditType("Deleted");
         public static readonly EnumAuditType Spawned = new EnumAuditType("Spawned");
         public static readonly EnumAuditType Merged = new EnumAuditType("Merged");
         public static readonly EnumAuditType Notification = new EnumAuditType("Notification");
         public static readonly EnumAuditType PhaseTime = new EnumAuditType("PhaseTime");
         public static readonly EnumAuditType ResourceAudit = new EnumAuditType("ResourceAudit");
         public static readonly EnumAuditType ProcessRun = new EnumAuditType("ProcessRun");
      }

      public sealed class EnumSeverity : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumSeverity(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumSeverity getEnum(string enumName)
         {
            return (EnumSeverity)getEnum(typeof(EnumSeverity), enumName);
         }

         public static EnumSeverity getEnum(int enumValue)
         {
            return (EnumSeverity)getEnum(typeof(EnumSeverity), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumSeverity));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumSeverity));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumSeverity));
         }

         public static readonly EnumSeverity Event = new EnumSeverity("Event");
         public static readonly EnumSeverity Information = new EnumSeverity("Information");
         public static readonly EnumSeverity Warning = new EnumSeverity("Warning");
         public static readonly EnumSeverity Error = new EnumSeverity("Error");
         public static readonly EnumSeverity Fatal = new EnumSeverity("Fatal");
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
         return "JDFAudit[ -->" + base.ToString() + "]";
      }

      ///   
      ///	 <summary> * SetSeverity
      ///	 *  </summary>
      ///	 * <param name="EnumSeverity"> s </param>
      ///	 
      public virtual void setSeverity(EnumSeverity s)
      {
         setAttribute(JDFConstants.SEVERITY, s.getName(), null);
      }

      ///   
      ///	 <summary> * GetSeverity
      ///	 *  </summary>
      ///	 * <returns> EnumSeverity </returns>
      ///	 
      public virtual EnumSeverity getSeverity()
      {
         return EnumSeverity.getEnum(getAttribute(JDFConstants.SEVERITY, null, null));
      }

      ///   
      ///	 <summary> * SetStatus
      ///	 *  </summary>
      ///	 * <param name="JDFElement"> .EnumNodeStatus s </param>
      ///	 
      public override void setStatus(JDFElement.EnumNodeStatus s)
      {
         if (s == null)
            throw new JDFException("setStatus setting to null");
         setAttribute(AttributeName.STATUS, s.getName(), null);
      }

      ///   
      ///	 <summary> * SetEndStatus
      ///	 *  </summary>
      ///	 * <param name="JDFElement"> .EnumNodeStatus s </param>
      ///	 
      public virtual void setEndStatus(JDFElement.EnumNodeStatus s)
      {
         setAttribute(AttributeName.ENDSTATUS, s.getName(), null);
      }

      ///   
      ///	 <summary> * GetEndStatus
      ///	 *  </summary>
      ///	 * <returns> JDFElement.EnumNodeStatus </returns>
      ///	 
      protected internal virtual JDFElement.EnumNodeStatus getEndStatus()
      {
         return JDFElement.EnumNodeStatus.getEnum(getAttribute(AttributeName.ENDSTATUS, null, null));
      }

      ///   
      ///	 <summary> * GetAuditType
      ///	 *  </summary>
      ///	 * <returns> EnumAuditType </returns>
      ///	 
      public virtual EnumAuditType getAuditType()
      {
         string nam = LocalName;
         return EnumAuditType.getEnum(nam);
      }

      ///   
      ///	 <summary> * GetPhase
      ///	 *  </summary>
      ///	 * @deprecated use JDFPhaseTime.getStatus() 
      ///	 * <returns> JDFElement.EnumNodeStatus </returns>
      ///	 
      [Obsolete("use JDFPhaseTime.getStatus()")]
      public virtual JDFElement.EnumNodeStatus getPhase()
      {
         if (!Name.Equals(ElementName.PHASETIME))
         {
            return null;
         }

         return base.getStatus();
      }

      ///   
      ///	 <summary> * SetPart
      ///	 *  </summary>
      ///	 * <param name="JDFAttributeMap"> m </param>
      ///	 * @deprecated 2005-10-20 - use setPartMap() in the various subclasses instead 
      ///	 
      [Obsolete("2005-10-20 - use setPartMap() in the various subclasses instead")]
      public virtual void setPart(JDFAttributeMap m)
      {
         base.setPartMap(m);
      }

      ///   
      ///	 <summary> * get part map vector
      ///	 *  </summary>
      ///	 * <returns> VJDFAttributeMap: vector of mAttribute, one for each part </returns>
      ///	 
      public override VJDFAttributeMap getPartMapVector()
      {
         return base.getPartMapVector();
      }

      ///   
      ///	 <summary> * Set attribute SpawnID </summary>
      ///	 
      public virtual void setSpawnID(string @value)
      {
         setAttribute(AttributeName.SPAWNID, @value, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * Set attribute refID </summary>
      ///	 
      public virtual void setrefID(string @value)
      {
         setAttribute(AttributeName.REFID, @value, null);
      }

      ///   
      ///	 <summary> * Set attribute refID to the ID of previous </summary>
      ///	 
      public virtual void setRef(JDFAudit previous)
      {
         if (previous != null)
         {
            string id = previous.appendAnchor(null); // ensure that previos has
            // an id
            setrefID(id);
         }
      }

      ///   
      ///	 <summary> * SetAuthor
      ///	 *  </summary>
      ///	 * <param name="String"> author </param>
      ///	 
      public virtual void setAuthor(string author)
      {
         setAttribute(AttributeName.AUTHOR, author, null);
      }

      ///   
      ///	 <summary> * SetID
      ///	 *  </summary>
      ///	 * <param name="String"> ID </param>
      ///	 
      public virtual void setID(string id)
      {
         setAttribute(AttributeName.ID, id, null);
      }

      ///   
      ///	 <summary> * SetBy
      ///	 *  </summary>
      ///	 * <param name="String"> by </param>
      ///	 * @deprecated 2005-09-01 use setAuthor() 
      ///	 
      [Obsolete("2005-09-01 use setAuthor()")]
      public virtual void setBy(string by)
      {
         if (by == null || by.Equals(JDFConstants.EMPTYSTRING))
         {
            return;
         }

         setAttribute(AttributeName.AUTHOR, by, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * Software
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public static string software()
      {
         return m_libAgentName + JDFConstants.BLANK + m_libAgentVersion;
      }

      ///   
      ///	 <summary> * init
      ///	 *  </summary>
      ///	 * <returns> boolean </returns>
      ///	 
      public override bool init()
      {
         EnumVersion auditVersion = getVersion(true);
         setAttributeNameTimeStamp(AttributeName.TIMESTAMP, null);
         if (auditVersion == null || auditVersion.getValue() >= EnumVersion.Version_1_2.getValue())
         {
            setAgentName(m_strAgentName);
            setAgentVersion(m_strAgentVersion);
         }
         if (m_strAuthor != null)
            setAuthor(m_strAuthor);

         if (auditVersion == null || auditVersion.getValue() >= EnumVersion.Version_1_3.getValue())
         {
            appendAnchor(null);
         }
         return base.init();
      }

      ///   
      ///	 <summary> * version fixing routine for JDF
      ///	 * 
      ///	 * uses heuristics to modify this element and its children to be compatible with a given version in general, it will
      ///	 * be able to move from low to high versions but potentially fail when attempting to move from higher to lower
      ///	 * versions
      ///	 *  </summary>
      ///	 * <param name="version"> : version that the resulting element should correspond to </param>
      ///	 * <returns> true if successful </returns>
      ///	 
      public override bool fixVersion(EnumVersion version)
      {
         if (version != null)
         {
            int @value = version.getValue();
            if (@value >= EnumVersion.Version_1_3.getValue())
            {
               appendAnchor(null);
            }
            else
            {
               removeAttribute(AttributeName.ID);
               // TODO fix agentname and agentversion
            }
            string author = getAuthor();
            if (@value <= EnumVersion.Version_1_1.getValue())
            {
               string tmp = getAgentName();
               bool b = false;
               if (tmp.Length != 0)
               {
                  author += "_|_" + tmp;
                  b = true;
               }
               tmp = getAgentVersion();
               if (tmp.Length != 0)
               {
                  if (!b)
                     author += "_|_ ";

                  author += "_|_" + tmp;
                  b = true;
               }
               removeAttribute(AttributeName.AGENTNAME);
               removeAttribute(AttributeName.AGENTVERSION);
               if (b)
                  setAuthor(author);
            }
            else if (author.Length > 0) // version>=1.2 and has author
            {
               VString tokens = new VString(StringUtil.tokenize(author, "_|_", false));
               if (tokens.Count == 3)
               { // it was previously fixed
                  string tmp = tokens.stringAt(0);
                  if (!tmp.Equals(JDFConstants.EMPTYSTRING) && !tmp.Equals(JDFConstants.BLANK))
                     setAuthor(tmp);
                  tmp = tokens.stringAt(1);
                  if (!tmp.Equals(JDFConstants.EMPTYSTRING) && !tmp.Equals(JDFConstants.BLANK))
                     setAgentName(tmp);
                  tmp = tokens.stringAt(2);
                  if (!tmp.Equals(JDFConstants.EMPTYSTRING) && !tmp.Equals(JDFConstants.BLANK))
                     setAgentVersion(tmp);
               }
            }
         }
         return base.fixVersion(version);
      }

      public override string getIDPrefix()
      {
         return "a";
      }

      ///   
      ///	 <summary> * SetTimeStamp
      ///	 *  </summary>
      ///	 * @deprecated 2005-12-02 use setTimeStamp(null) 
      ///	 
      [Obsolete("2005-12-02 use setTimeStamp(null)")]
      public virtual void setTimeStamp()
      {
         setTimeStamp(null);
      }

      ///   
      ///	 <summary> * GetTimeStamp
      ///	 *  </summary>
      ///	 * @deprecated use getTimeStampDate as the typed version 
      ///	 * <returns> the String value of TimeStamp </returns>
      ///	 
      [Obsolete("use getTimeStampDate as the typed version")]
      public virtual string getTimeStamp()
      {
         return getAttribute(AttributeName.TIMESTAMP, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * (12) get JDFDate attribute TimeStamp
      ///	 *  </summary>
      ///	 * <returns> JDFDate the value of the attribute </returns>
      ///	 
      public virtual JDFDate getTimeStampDate()
      {
         string str = getAttribute(AttributeName.TIMESTAMP, null, null);
         if (str == null)
            return null;
         try
         {
            return new JDFDate(str);
         }
         catch (FormatException)
         {
            throw new JDFException("not a valid date string. Malformed JDF");
         }
      }

      ///   
      ///	 <summary> * Get string attribute SpawnID </summary>
      ///	 
      public virtual string getSpawnID()
      {
         return getAttribute(AttributeName.SPAWNID, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * Get string attribute refID </summary>
      ///	 
      public virtual string getrefID()
      {
         return getAttribute(AttributeName.REFID, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * Get string attribute Author </summary>
      ///	 
      public virtual string getAuthor()
      {
         return getAttribute(AttributeName.AUTHOR);
      }

      ///   
      ///	 <summary> * Get string attribute ID </summary>
      ///	 
      public override string getID()
      {
         return getAttribute(AttributeName.ID);
      }

      ///   
      ///	 <summary> * Set attribute AgentName </summary>
      ///	 
      public virtual void setAgentName(string @value)
      {
         setAttribute(AttributeName.AGENTNAME, @value);
      }

      ///   
      ///	 <summary> * Get string attribute AgentName </summary>
      ///	 
      public virtual string getAgentName()
      {
         return getAttribute(AttributeName.AGENTNAME);
      }

      ///   
      ///	 <summary> * Set attribute AgentVersion </summary>
      ///	 
      public virtual void setAgentVersion(string @value)
      {
         setAttribute(AttributeName.AGENTVERSION, @value);
      }

      ///   
      ///	 <summary> * Get string attribute AgentVersion </summary>
      ///	 
      public virtual string getAgentVersion()
      {
         return getAttribute(AttributeName.AGENTVERSION);
      }

      ///   
      ///	 <summary> * Set attribute TimeStamp </summary>
      ///	 
      public virtual void setTimeStamp(JDFDate @value)
      {
         setAttributeNameTimeStamp(AttributeName.TIMESTAMP, @value);
      }

      public virtual JDFAuditPool getAuditPool()
      {
         return (JDFAuditPool)getDeepParent(ElementName.AUDITPOOL, 0);
      }

      ///   
      ///	 <summary> * create an update audit for this
      ///	 * 
      ///	 * @return </summary>
      ///	 
      public virtual JDFAudit createUpdateAudit()
      {
         JDFAuditPool pool = getAuditPool();
         if (pool == null)
            return null;
         JDFAudit copy = (JDFAudit)pool.copyElement(this, null);
         copy.removeAttribute(AttributeName.ID);
         copy.removeAttribute(AttributeName.AGENTNAME);
         copy.removeAttribute(AttributeName.AGENTVERSION);
         copy.init();
         copy.setRef(this);
         return copy;
      }

      ///   
      ///	 <summary> * Gets the default static AgentName that is used to preset @AgentName when generating a new Audit
      ///	 *  </summary>
      ///	 * <returns> Returns the m_strAgentName. </returns>
      ///	 
      [MethodImpl(MethodImplOptions.Synchronized)]
      public static string getStaticAgentName()
      {
         return m_strAgentName;
      }

      ///   
      ///	 <summary> * sets the default static AgentName that is used to preset @AgentName when generating a new Audit
      ///	 *  </summary>
      ///	 * <param name="agentName"> The m_strAgentName to set. </param>
      ///	 
      [MethodImpl(MethodImplOptions.Synchronized)]
      public static void setStaticAgentName(string agentName)
      {
         m_strAgentName = agentName;
      }

      ///   
      ///	 <summary> * Gets the default static Author that is used to preset @AgentName when generating a new Audit
      ///	 *  </summary>
      ///	 * <returns> Returns the m_Author. </returns>
      ///	 
      [MethodImpl(MethodImplOptions.Synchronized)]
      public static string getStaticAuthor()
      {
         return m_strAuthor;
      }

      ///   
      ///	 <summary> * sets the default static AgentName that is used to preset @AgentName when generating a new Audit
      ///	 *  </summary>
      ///	 * <param name="agentName"> The m_strAgentName to set. </param>
      ///	 
      [MethodImpl(MethodImplOptions.Synchronized)]
      public static void setStaticAuthor(string author)
      {
         m_strAuthor = author;
      }

      ///   
      ///	 <summary> * gets the default static AgentVersion that is used to preset @AgentName when generating a new Audit
      ///	 *  </summary>
      ///	 * <returns> sTRING the m_strAgentVersion. </returns>
      ///	 
      [MethodImpl(MethodImplOptions.Synchronized)]
      public static string getStaticAgentVersion()
      {
         return m_strAgentVersion;
      }

      ///   
      ///	 <summary> * Sets the default static AgentVersion that is used to preset @AgentName when generating a new Audit
      ///	 *  </summary>
      ///	 * <param name="agentVersion"> The m_strAgentVersion to set. </param>
      ///	 
      [MethodImpl(MethodImplOptions.Synchronized)]
      public static void setStaticAgentVersion(string agentVersion)
      {
         m_strAgentVersion = agentVersion;
      }
   }
}
