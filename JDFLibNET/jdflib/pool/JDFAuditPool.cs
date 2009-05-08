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
 * JDFAuditPool.cs
 * -------------------------------------------------------------------------------------------------
 * Last changes
 * 2002-07-02 JG renamed JDFProcess to JDFNode
 * 2002-07-02 JG SetPhase modified first parameter to be JDFPhaseTime::EnumNodeStatus
 * 2002-07-02 JG removed IsValid 
 * 2002-07-02 JG getAudits added const mAttribute &mAttributes=mAttribute() also fixed inversion logic bug
 * 2002-07-02 JG getAudit modified 3rd parameter to const mAttribute &mAttributes=mAttribute()
 * 2002-07-02 JG remove getPoolChildName */

namespace org.cip4.jdflib.pool
{
   using System;


   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFAudit = org.cip4.jdflib.core.JDFAudit;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using EnumAuditType = org.cip4.jdflib.core.JDFAudit.EnumAuditType;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using JDFDeviceInfo = org.cip4.jdflib.jmf.JDFDeviceInfo;
   using JDFJMF = org.cip4.jdflib.jmf.JDFJMF;
   using JDFJobPhase = org.cip4.jdflib.jmf.JDFJobPhase;
   using JDFMessage = org.cip4.jdflib.jmf.JDFMessage;
   using JDFQueueEntry = org.cip4.jdflib.jmf.JDFQueueEntry;
   using EnumType = org.cip4.jdflib.jmf.JDFMessage.EnumType;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using JDFSpawned = org.cip4.jdflib.node.JDFSpawned;
   using JDFCreated = org.cip4.jdflib.resource.JDFCreated;
   using JDFDeleted = org.cip4.jdflib.resource.JDFDeleted;
   using JDFMerged = org.cip4.jdflib.resource.JDFMerged;
   using JDFModified = org.cip4.jdflib.resource.JDFModified;
   using JDFNotification = org.cip4.jdflib.resource.JDFNotification;
   using JDFPhaseTime = org.cip4.jdflib.resource.JDFPhaseTime;
   using JDFProcessRun = org.cip4.jdflib.resource.JDFProcessRun;
   using JDFResourceAudit = org.cip4.jdflib.resource.JDFResourceAudit;
   using ContainerUtil = org.cip4.jdflib.util.ContainerUtil;
   using JDFDate = org.cip4.jdflib.util.JDFDate;
   using StringUtil = org.cip4.jdflib.util.StringUtil;

   ///
   /// <summary> * This class represents a JDF-AuditPool </summary>
   /// 
   public class JDFAuditPool : JDFPool
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFAuditPool
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFAuditPool(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFAuditPool
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFAuditPool(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFAuditPool
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFAuditPool(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[9];
      static JDFAuditPool()
      {
         elemInfoTable[0] = new ElemInfoTable(ElementName.CREATED, 0x33333333);
         elemInfoTable[1] = new ElemInfoTable(ElementName.DELETED, 0x33333333);
         elemInfoTable[2] = new ElemInfoTable(ElementName.MODIFIED, 0x33333333);
         elemInfoTable[3] = new ElemInfoTable(ElementName.NOTIFICATION, 0x33333333);
         elemInfoTable[4] = new ElemInfoTable(ElementName.RESOURCEAUDIT, 0x33333333);
         elemInfoTable[5] = new ElemInfoTable(ElementName.SPAWNED, 0x33333333);
         elemInfoTable[6] = new ElemInfoTable(ElementName.MERGED, 0x33333333);
         elemInfoTable[7] = new ElemInfoTable(ElementName.PHASETIME, 0x33333333);
         elemInfoTable[8] = new ElemInfoTable(ElementName.PROCESSRUN, 0x33333333);
      }

      protected internal override ElementInfo getTheElementInfo()
      {
         return new ElementInfo(base.getTheElementInfo(), elemInfoTable);
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
         return "JDFAuditPool[ -->" + base.ToString() + "]";
      }

      ///   
      ///	 <summary> *  </summary>
      ///	 
      public virtual void ensureCreated()
      {
         JDFAudit created = getAudit(0, EnumAuditType.Created, null, null);
         if (created == null)
         {
            JDFAudit a = getAudit(0, null, null, null);
            JDFCreated c = addCreated(null, null);
            if (a != null)
            {
               c.setTimeStamp(a.getTimeStampDate());
               moveElement(c, a);
            }
         }
      }

      ///   
      ///	 <summary> * Add a ProcessRun Audit
      ///	 *  </summary>
      ///	 * <param name="s"> the node status at this time </param>
      ///	 * <param name="by"> the author keyword </param>
      ///	 * <returns> JDFProcessRun the newly created ProcessRun audit
      ///	 * 
      ///	 *         default: addProcessRun(s, JDFConstants.EMPTYSTRING) </returns>
      ///	 * @deprecated use addProcessRun(JDFElement.EnumNodeStatus s, JDFConstants.EMPTYSTRING, new VJDFAttributeMap()) 
      ///	 
      [Obsolete("use addProcessRun(JDFElement.EnumNodeStatus s, JDFConstants.EMPTYSTRING, new VJDFAttributeMap())")]
      public virtual JDFProcessRun addProcessRun(JDFElement.EnumNodeStatus s, string by)
      {
         return addProcessRun(s, by, null);
      }

      ///   
      ///	 <summary> * Add a ProcessRun Audit
      ///	 *  </summary>
      ///	 * <param name="s"> the node status at this time </param>
      ///	 * <param name="by"> the author keyword </param>
      ///	 * <returns> the newly created ProcessRun audit
      ///	 * 
      ///	 *         default: AddProcessRun(s, JDFConstants.EMPTYSTRING) </returns>
      ///	 
      public virtual JDFProcessRun addProcessRun(JDFElement.EnumNodeStatus s, string by, VJDFAttributeMap vmParts)
      {
         JDFProcessRun pr = (JDFProcessRun)addAudit(JDFAudit.EnumAuditType.ProcessRun, by);
         pr.setStart(null);
         pr.setEnd(null);
         pr.setEndStatus(s);
         pr.setPartMapVector(vmParts);

         return pr;
      }

      ///   
      ///	 <summary> * add an audit, called internally by the specialized functions
      ///	 *  </summary>
      ///	 * <param name="typ"> audit type </param>
      ///	 * <param name="by"> the author keyword </param>
      ///	 * <returns> JDFAudit
      ///	 * 
      ///	 *         default: AddAudit(typ, JDFConstants.EMPTYSTRING) </returns>
      ///	 
      public virtual JDFAudit addAudit(JDFAudit.EnumAuditType typ, string by)
      {
         JDFAudit l = (JDFAudit)appendElement(typ.getName(), null);
         if (by != null)
            l.setAuthor(by);

         JDFNode r = getJDFRoot();
         if (r.hasAttribute(AttributeName.SPAWNID))
         {
            l.setSpawnID(r.getSpawnID(false));
         }

         return l;
      }

      ///   
      ///	 <summary> * Append a Created audit element, if createdElem==null only add if it is not yet there
      ///	 *  </summary>
      ///	 * <param name="by"> the author keyword </param>
      ///	 * <param name="createdElem"> the created element </param>
      ///	 * <returns> the newly created Created audit
      ///	 * 
      ///	 *         default: AddCreated(by, null) </returns>
      ///	 
      public virtual JDFCreated addCreated(string by, KElement createdElem)
      {

         JDFCreated created = (JDFCreated)addAudit(JDFAudit.EnumAuditType.Created, by);

         if (createdElem != null)
         {
            string xpath = createdElem.buildXPath(getParentJDF().buildXPath(null, 1), 1);
            created.setXPath(xpath);
         }

         return created;
      }

      ///   
      ///	 <summary> * Append a Modified audit element
      ///	 *  </summary>
      ///	 * <param name="by"> the author keyword </param>
      ///	 * <param name="modifiedElem"> the modified element
      ///	 * 
      ///	 *            default: AddModified(by, null) </param>
      ///	 
      public virtual JDFModified addModified(string by, KElement modifiedElem)
      {
         JDFModified modified = (JDFModified)addAudit(JDFAudit.EnumAuditType.Modified, by);
         if (modifiedElem != null)
         {
            string xpath = modifiedElem.buildXPath(getParentJDF().buildXPath(null, 1), 1);
            modified.setXPath(xpath);
         }

         return modified;
      }

      ///   
      ///	 <summary> * Append a Deleted audit element
      ///	 *  </summary>
      ///	 * <param name="by"> the author keyword </param>
      ///	 * <param name="modifiedElem"> the modified element </param>
      ///	 * <returns> JDFDeleted the newly created Modified audit
      ///	 * 
      ///	 *         default: AddDeleted(null, null) </returns>
      ///	 
      public virtual JDFDeleted addDeleted(string by, KElement deletedElem)
      {
         JDFDeleted deleted = (JDFDeleted)addAudit(JDFAudit.EnumAuditType.Deleted, by);
         if (deletedElem != null)
         {
            string xpath = deletedElem.buildXPath(getParentJDF().buildXPath(null, 1), 1);
            deleted.setXPath(xpath);
         }

         return deleted;
      }

      ///   
      ///	 <summary> * append a ResourceAudit audit element
      ///	 *  </summary>
      ///	 * <param name="by"> the author keyword
      ///	 *  </param>
      ///	 * <returns> JDFResourceAudit - the newly created ResourceAudit audit, null if an error occured </returns>
      ///	 
      public virtual JDFResourceAudit addResourceAudit(string by)
      {
         return (JDFResourceAudit)addAudit(JDFAudit.EnumAuditType.ResourceAudit, by);
      }

      ///   
      ///	 <summary> * add a Notification Audit
      ///	 *  </summary>
      ///	 * <param name="by"> the author keyword </param>
      ///	 * <param name="s"> severity of the event
      ///	 *  </param>
      ///	 * <returns> JDFAudit - the newly created Notification Audit TODO replace with addNotification </returns>
      ///	 
      public virtual JDFAudit addEvent(string by, JDFAudit.EnumSeverity s)
      {
         JDFAudit l = addAudit(JDFAudit.EnumAuditType.Notification, by);
         l.setSeverity(s);
         return l;
      }

      ///   
      ///	 <summary> * Append a PhaseTime audit element
      ///	 *  </summary>
      ///	 * <param name="phase"> the node status at this time </param>
      ///	 * <param name="by"> the author keyword </param>
      ///	 * <param name="vmParts"> defines a vector of map of parts for which the Spawned is valid </param>
      ///	 * <returns> the newly created PhaseTime audit
      ///	 * 
      ///	 *         default: AddPhaseTime(phase, JDFConstants.EMPTYSTRING, new VJDFAttributeMap()) </returns>
      ///	 
      public virtual JDFPhaseTime addPhaseTime(EnumNodeStatus phase, string by, VJDFAttributeMap vmParts)
      {
         JDFPhaseTime myAudit = (JDFPhaseTime)addAudit(JDFAudit.EnumAuditType.PhaseTime, by);
         myAudit.setStatus(phase);
         myAudit.setStart(new JDFDate());
         myAudit.setEnd(new JDFDate());
         myAudit.setPartMapVector(vmParts);
         JDFNode parentJDF = getParentJDF();
         if (parentJDF != null)
         {
            myAudit.setSpawnID(StringUtil.getNonEmpty(parentJDF.getSpawnID(true)));
         }

         return myAudit;
      }

      ///   
      ///	 <summary> * Append a Spawned audit element
      ///	 *  </summary>
      ///	 * <param name="spawned"> the spawned node </param>
      ///	 * <param name="rRefsRO"> a vector of rRefs that are spawned read-only </param>
      ///	 * <param name="rRefsRW"> a vector of rRefs that are spawned read-write </param>
      ///	 * <param name="by"> the author keyword </param>
      ///	 * <param name="vmParts">
      ///	 *  </param>
      ///	 * <returns> JDFAudit - the newly created Spawned audit
      ///	 * 
      ///	 *         default: AddSpawned(spawned, new Vector(), new Vector(), JDFConstants.EMPTYSTRING, new
      ///	 *         VJDFAttributeMap()) </returns>
      ///	 
      public virtual JDFSpawned addSpawned(JDFNode spawned, VString rRefsRO, VString rRefsRW, string by, VJDFAttributeMap vmParts)
      {
         JDFSpawned a = (JDFSpawned)addAudit(JDFAudit.EnumAuditType.Spawned, by);
         a.setAttribute(JDFConstants.JREF, spawned.getID(), null);
         string ms = null;
         if (rRefsRO != null && !rRefsRO.IsEmpty())
         {
            ms = StringUtil.setvString(rRefsRO);
            a.setAttribute(AttributeName.RREFSROCOPIED, ms, null);
         }

         if (rRefsRW != null && !rRefsRW.IsEmpty())
         {
            ms = StringUtil.setvString(rRefsRW);
            a.setAttribute(AttributeName.RREFSRWCOPIED, ms, null);
         }

         a.setPartMapVector(vmParts);

         return a;
      }

      ///   
      ///	 <summary> * Append a Merged audit element
      ///	 *  </summary>
      ///	 * <param name="merged"> the merged node </param>
      ///	 * <param name="rRefsOverwritten"> a vector of rRefs that are overwritten </param>
      ///	 * <param name="by"> the author keyword
      ///	 *  </param>
      ///	 * <returns> JDFMerged - the newly created Merged audit
      ///	 * 
      ///	 *         default: AddMerged(merged, rRefsOverwritten, JDFConstants.EMPTYSTRING, null) </returns>
      ///	 
      public virtual JDFMerged addMerged(JDFNode merged, VString rRefsOverwritten, string by, VJDFAttributeMap vmParts)
      {
         VString rRefsOverwrittenLocal = rRefsOverwritten;

         JDFMerged mergedAudit = (JDFMerged)addAudit(JDFAudit.EnumAuditType.Merged, by);
         mergedAudit.setjRef(merged.getID());
         if (rRefsOverwrittenLocal != null && rRefsOverwrittenLocal.IsEmpty())
            rRefsOverwrittenLocal = null;
         mergedAudit.setrRefsOverwritten(rRefsOverwrittenLocal);

         mergedAudit.setPartMapVector(vmParts);
         return mergedAudit;
      }

      ///   
      ///	 <summary> * Append a Notification audit element with a Class attribute of Severity
      ///	 *  </summary>
      ///	 * <param name="by"> the author keyword </param>
      ///	 * <param name="s"> the severity
      ///	 *  </param>
      ///	 * <returns> JDFAudit - the newly created Notification audit </returns>
      ///	 
      public virtual JDFNotification addNotification(JDFNotification.EnumClass severity, string by, VJDFAttributeMap vmParts)
      {
         JDFNotification l = (JDFNotification)addAudit(JDFAudit.EnumAuditType.Notification, by);
         if (l != null)
         {
            if (severity != null)
               l.setClass(severity);
            l.setPartMapVector(vmParts);
         }
         return l;
      }

      ///   
      ///	 <summary> * getLastPhase - get the most recent PhaseTime audit in this pool
      ///	 *  </summary>
      ///	 * @deprecated use getLastPhase(VJDFAttributeMap) 
      ///	 * <returns> JDFAudit - the last PhaseTime audit </returns>
      ///	 
      [Obsolete("use getLastPhase(VJDFAttributeMap)")]
      public virtual JDFPhaseTime getLastPhase()
      {
         return getLastPhase(null, null);
      }

      ///   
      ///	 <summary> * getLastPhase - get the most recent PhaseTime audit in this pool
      ///	 *  </summary>
      ///	 * <param name="vPartMap"> the list of matching partMaps </param>
      ///	 * <returns> JDFAudit - the last PhaseTime audit </returns>
      ///	 * @deprecated use getLastPhase(vPartMap, null) 
      ///	 
      [Obsolete("use getLastPhase(vPartMap, null)")]
      public virtual JDFPhaseTime getLastPhase(VJDFAttributeMap vPartMap)
      {
         return getLastPhase(vPartMap, null);
      }

      ///   
      ///	 <summary> * getLastPhase - get the most recent PhaseTime audit in this pool
      ///	 *  </summary>
      ///	 * <param name="vPartMap"> the list of matching partMaps </param>
      ///	 * <returns> JDFAudit - the last PhaseTime audit </returns>
      ///	 
      public virtual JDFPhaseTime getLastPhase(VJDFAttributeMap vPartMap, string moduleID)
      {
         if (KElement.isWildCard(moduleID))
            return (JDFPhaseTime)getAudit(-1, EnumAuditType.PhaseTime, null, vPartMap);

         VElement e = getAudits(EnumAuditType.PhaseTime, null, vPartMap);
         if (e != null)
         {
            int size = e.Count - 1;
            for (int i = size; i >= 0; i--)
            {
               JDFPhaseTime pt = (JDFPhaseTime)e[i];
               if (pt.getChildWithAttribute(ElementName.MODULEPHASE, AttributeName.MODULEID, null, moduleID, 0, true) != null)
                  return pt;
            }
         }

         return null;
      }

      ///   
      ///	 <summary> * getAudits - get all audits with attributes and partMap
      ///	 *  </summary>
      ///	 * <param name="typ"> type of the audit to take </param>
      ///	 * <param name="mAttributes"> attribute map to filter the audits
      ///	 *  </param>
      ///	 * <returns> VElement - all elements, that matches the filter
      ///	 * 
      ///	 *         default: getAudits(null, null) </returns>
      ///	 * @deprecated use getAudits(null, null, null) 
      ///	 
      [Obsolete("use getAudits(null, null, null)")]
      public virtual VElement getAudits(JDFAudit.EnumAuditType typ, JDFAttributeMap mAttributes)
      {
         return getAudits(typ, mAttributes, null);
      }

      ///   
      ///	 <summary> * } getAudits - get all audits with attributes and partMap
      ///	 *  </summary>
      ///	 * <param name="typ"> type of the audit to take </param>
      ///	 * <param name="mAttributes"> attribute map to filter the audits </param>
      ///	 * <param name="vParts"> the partmap vector - note that not all audits legally have parts </param>
      ///	 * <returns> VElement - all elements, that matches the filter
      ///	 * 
      ///	 *         default: getAudits(null, null, null) </returns>
      ///	 
      public virtual VElement getAudits(JDFAudit.EnumAuditType typ, JDFAttributeMap mAttributes, VJDFAttributeMap vParts)
      {
         VJDFAttributeMap vPartsLocal = vParts;
         string strAuditType = null;
         if (typ != null)
         {
            strAuditType = typ.getName();
         }

         VElement vElem = getPoolChildrenGeneric(strAuditType, mAttributes, null);
         if (vPartsLocal != null && vPartsLocal.Count == 0)
            vPartsLocal = null;

         for (int i = vElem.Count - 1; i >= 0; i--)
         { // remove known comments - this would be aught in the next check but
            // we avoid the exception
            if (!(vElem[i] is JDFAudit))
            {
               vElem.RemoveAt(i);
               continue; // look at next element
            }

            JDFAudit audit = (JDFAudit)vElem[i];
            if (vPartsLocal != null && !vPartsLocal.Equals(audit.getPartMapVector()))
            {
               vElem.RemoveAt(i);
               continue; // look at next element
            }
         }
         return vElem;
      }

      ///   
      ///	 <summary> * get the index'th audit of the given typ
      ///	 *  </summary>
      ///	 * <param name="index"> index of the audit negativ values are possible and will be substracted from the vector size. For
      ///	 *            example, your given Filter returns a Vector of 10 Posible Elements and your index is -7 you will get
      ///	 *            10 - 7 = Element Number 3 </param>
      ///	 * <param name="typ"> type of the audit to take </param>
      ///	 * <param name="mAttributes"> attribute map to filter the audits </param>
      ///	 * <returns> an Audit that matches the filers
      ///	 * 
      ///	 *         default: getAudit(index, typ, null) </returns>
      ///	 * @deprecated use 4 parameter version 
      ///	 
      [Obsolete("use 4 parameter version")]
      public virtual JDFAudit getAudit(int index, JDFAudit.EnumAuditType typ, JDFAttributeMap mAttributes)
      {
         return getAudit(index, typ, mAttributes, null);
      }

      ///   
      ///	 <summary> * get the index'th audit of the given typ
      ///	 *  </summary>
      ///	 * <param name="index"> index of the audit negativ values are possible and will be substracted from the vector size. For
      ///	 *            example,your given Filter returns a Vector of 10 Posible Elements and your index is -7 you will get 10
      ///	 *            - 7 = Element Number 3 </param>
      ///	 * <param name="typ"> type of the audit to take </param>
      ///	 * <param name="mAttributes"> attribute map to filter the audits </param>
      ///	 * <param name="vParts"> the partmap vector - note that not all audits legally have parts </param>
      ///	 * <returns> an Audit that matches the filers
      ///	 * 
      ///	 *         default: getAudit(index, typ, null) </returns>
      ///	 
      public virtual JDFAudit getAudit(int index, JDFAudit.EnumAuditType typ, JDFAttributeMap mAttributes, VJDFAttributeMap vParts)
      {
         int indexLocal = index;

         VElement v = getAudits(typ, mAttributes, vParts);
         if (indexLocal < 0)
         {
            indexLocal = v.Count + indexLocal;
         }
         if (indexLocal >= v.Count || indexLocal < 0)
         {
            return null;
         }

         return (JDFAudit)v[indexLocal];
      }

      ///   
      ///	 <summary> * finds all status messages in a jmf and fills the phaseTime with the appropriate data
      ///	 *  </summary>
      ///	 * <param name="jmf"> </param>
      ///	 * <returns> vector the vector of all modified phasetime elements </returns>
      ///	 
      public virtual VElement setPhase(JDFJMF jmf)
      {
         VElement vMessages = jmf.getMessageVector(null, EnumType.Status);
         if (vMessages == null)
            return null;
         VElement vRet = new VElement();
         for (int i = 0; i < vMessages.Count; i++)
         {
            JDFMessage status = (JDFMessage)vMessages[i];
            VElement devInfos = status.getChildElementVector(ElementName.DEVICEINFO, null, null, true, 0, true);
            for (int j = 0; j < devInfos.Count; j++)
            {
               JDFDeviceInfo devInfo = (JDFDeviceInfo)devInfos[j];
               VElement phases = devInfo.getChildElementVector(ElementName.JOBPHASE, null, null, true, 0, true);
               for (int k = 0; k < phases.Count; k++)
               {
                  JDFJobPhase phase = (JDFJobPhase)phases[k];
                  string jobID = phase.getJobID();
                  if (!jobID.Equals(getParentJDF().getJobID(true)))
                     continue;
                  string jobPartID = phase.getJobPartID();
                  if (!jobPartID.Equals(getParentJDF().getJobPartID(true)))
                     continue;

                  JDFPhaseTime pt = setPhase(phase.getStatus(), phase.getStatusDetails(), phase.getPartMapVector(), devInfo.getChildElementVector(ElementName.EMPLOYEE, null));
                  pt.copyElement(phase.getMISDetails(), null);
                  pt.setEnd(jmf.getTimeStamp());
                  pt.setStart(phase.getPhaseStartTime());
                  vRet.Add(pt);
               }
            }
         }
         vRet.unify();
         return vRet.Count == 0 ? null : vRet;

      }

      ///   
      ///	 <summary> * Create or modify a PhaseTime Audit and fill it If the phase is identical to the prior phase that has been set,
      ///	 * the existing PhaseTime is modified otherwise an existing phaseTime is closed and a new phaseTime is appended
      ///	 * Phasetime elements with different Parts are treated independently
      ///	 *  </summary>
      ///	 * <param name="status"> the node status at this time </param>
      ///	 * <param name="statusDetails"> details of this status </param>
      ///	 * <param name="vmParts"> defines a vector of map of parts for which the PhaseTime is valid </param>
      ///	 * <returns> JDFPhaseTime the newly created PhaseTime audit
      ///	 * 
      ///	 *         default: SetPhase(status, null,null,null) </returns>
      ///	 * @deprecated use the 4 parameter version 
      ///	 
      [Obsolete("use the 4 parameter version")]
      public virtual JDFPhaseTime setPhase(EnumNodeStatus status, string statusDetails, VJDFAttributeMap vmParts)
      {
         return setPhase(status, statusDetails, vmParts, null);
      }

      ///   
      ///	 <summary> * Create or modify a PhaseTime Audit and fill it If the phase is identical to the prior phase that has been set,
      ///	 * the existing PhaseTime is modified otherwise an existing phaseTime is closed and a new phaseTime is appended
      ///	 * Phasetime elements with different Parts are treated independently
      ///	 *  </summary>
      ///	 * <param name="status"> the node status at this time </param>
      ///	 * <param name="statusDetails"> details of this status </param>
      ///	 * <param name="vmParts"> defines a vector of map of parts for which the PhaseTime is valid </param>
      ///	 * <param name="employees"> Vector of employees that are currently registered for this job </param>
      ///	 * <returns> JDFPhaseTime the newly created PhaseTime audit
      ///	 * 
      ///	 *         default: SetPhase(status, null,null,null) </returns>
      ///	 
      public virtual JDFPhaseTime setPhase(EnumNodeStatus status, string statusDetails, VJDFAttributeMap vmParts, VElement employees)
      {
         string statusDetailsLocal = statusDetails;

         JDFPhaseTime pt = getLastPhase(vmParts, null);
         statusDetailsLocal = StringUtil.getNonEmpty(statusDetailsLocal);
         bool bChanged = false;
         VElement ptEmployees = pt == null ? new VElement() : pt.getChildElementVector(ElementName.EMPLOYEE, null);
         if (pt == null)
         {
            bChanged = true;
         }
         else if (!ContainerUtil.Equals(pt.getStatus(), status) || !ContainerUtil.Equals(statusDetailsLocal, pt.getAttribute(AttributeName.STATUSDETAILS, null, null)) || !ptEmployees.isEqual(employees))
         {
            pt.setEnd(new JDFDate());
            bChanged = true;
         }
         if (bChanged)
         {
            pt = addPhaseTime(status, null, vmParts);
            pt.setStatusDetails(statusDetailsLocal);
            pt.copyElements(employees, null);
         }
         return pt;
      }

      ///   
      ///	 <summary> * get the linked resources matching some conditions
      ///	 *  </summary>
      ///	 * <param name="mResAtt"> map of Resource attributes to search for </param>
      ///	 * <param name="bFollowRefs"> true if internal references shall be followed </param>
      ///	 * <returns> VElement vector with all elements matching the conditions
      ///	 * 
      ///	 *         default: getLinkedResources(null, true) </returns>
      ///	 
      public virtual VElement getLinkedResources(JDFAttributeMap mResAtt, bool bFollowRefs)
      {
         VString refs = getHRefs(null, false, true);
         refs.unify();
         VElement v = new VElement();

         for (int i = 0; i < refs.Count; i++)
         {
            KElement e = getTarget(refs[i], AttributeName.ID);
            if (e != null && e.includesAttributes(mResAtt, true))
            {
               v.Add(e);
               if (bFollowRefs && (e is JDFElement))
               {
                  v.appendUnique(((JDFElement)e).getvHRefRes(bFollowRefs, true));
               }
            }
         }
         return v;
      }

      ///   
      ///	 <summary> * getLinks - get the links matching mLinkAtt out of the resource pool
      ///	 *  </summary>
      ///	 * <param name="mLinkAtt"> the attribute to search for
      ///	 *  </param>
      ///	 * <returns> VElement - vector all all elements matching the condition mLinkAtt </returns>
      ///	 * @deprecated 060216 - this seams to have accidentally been added default: getLinks(null) 
      ///	 
      [Obsolete("060216 - this seams to have accidentally been added default: getLinks(null)")]
      public virtual VElement getLinks(JDFAttributeMap mLinkAtt)
      {
         return getPoolChildrenGeneric(JDFConstants.EMPTYSTRING, mLinkAtt, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * Append a new child if no identical child exists
      ///	 *  </summary>
      ///	 * <param name="p"> the Child to add to the element </param>
      ///	 
      public virtual void appendUnique(JDFAudit p)
      {
         appendUniqueGeneric(p);
      }

      ///   
      ///	 <summary> * Append all children of p for which no identical child exists
      ///	 *  </summary>
      ///	 * <param name="p"> the Child to add to the element </param>
      ///	 
      public virtual void appendUnique(JDFAuditPool p)
      {
         appendUniqueGeneric(p);
      }

      ///   
      ///	 <summary> * gets all children with the attribute name,mAttrib, nameSpaceURI out of the pool
      ///	 *  </summary>
      ///	 * <param name="strName"> name of the Child </param>
      ///	 * <param name="mAttrib"> an attribute to search for </param>
      ///	 * <returns> VElement: a vector with all elements in the pool matching the conditions
      ///	 * 
      ///	 *         default: getPoolChildren(null,null) </returns>
      ///	 
      public virtual VElement getPoolChildren(string strName, JDFAttributeMap mAttrib)
      {
         return getPoolChildrenGeneric(strName, mAttrib, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 * <param name="cleanPolicy"> </param>
      ///	 * <param name="spawnID"> </param>
      ///	 * @deprecated use JDFMerge.cleanUpMerge 
      ///	 
      [Obsolete("use JDFMerge.cleanUpMerge")]
      public virtual void cleanUpMerge(JDFNode.EnumCleanUpMerge cleanPolicy, string spawnID)
      {
         throw new MethodAccessException("use JDFMerge.cleanUpMergeAudits");
         // JDFMerge.cleanUpMergeAudits(this, cleanPolicy, spawnID);
      }


      ///   
      ///	 <summary> * Mother of all version fixing routines
      ///	 * 
      ///	 * uses heuristics to modify this element and its children to be compatible with a given version in general, it will
      ///	 * be able to move from low to high versions but potentially fail when attempting to move from higher to lower
      ///	 * versions
      ///	 *  </summary>
      ///	 * <param name="version"> version that the resulting element should correspond to </param>
      ///	 * <returns> true if successful </returns>
      ///	 
      public override bool fixVersion(EnumVersion version)
      {
         if (hasAttribute(AttributeName.RREFS))
            removeAttribute(AttributeName.RREFS);
         return base.fixVersion(version);
      }


      ///   
      ///	 <summary> * creates a ProcessRun when this is submitted should be called by the receiving device when it initially receives
      ///	 * and enqueues the JDF
      ///	 *  </summary>
      ///	 * <param name="qe"> the queuentry element to copy information from, if null parameters will be genrated on the fly </param>
      ///	 * <returns> the newly created processRun </returns>
      ///	 
      public virtual JDFProcessRun createSubmitProcessRun(JDFQueueEntry qe)
      {
         JDFProcessRun pr = (JDFProcessRun)addAudit(EnumAuditType.ProcessRun, null);
         pr.setSubmissionTime(new JDFDate());
         if (qe != null)
         {
            pr.setPartMapVector(qe.getPartMapVector());
            pr.copyAttribute(AttributeName.QUEUEENTRYID, qe, null, null, null);
            if (qe.hasAttribute(AttributeName.SUBMISSIONTIME))
               pr.copyAttribute(AttributeName.SUBMISSIONTIME, qe, null, null, null);
         }
         if (!pr.hasAttribute(AttributeName.SUBMISSIONTIME))
            pr.setSubmissionTime(new JDFDate());
         if (!pr.hasAttribute(AttributeName.QUEUEENTRYID))
            pr.setAttribute("QueueEntryID", "qe_" + JDFElement.uniqueID(0));
         return pr;

      }
   }
}
