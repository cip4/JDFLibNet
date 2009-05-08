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



/* JDFQueue.cs
 * @author Dietrich Mucha 
 * Copyright (C) 1999-2005 Heidelberger Druckmaschinen AG. All rights reserved. 
 */

namespace org.cip4.jdflib.jmf
{
   using System;
   using System.Runtime.CompilerServices;
   using System.Collections;
   using System.Collections.Generic;



   using JDFAutoQueue = org.cip4.jdflib.auto.JDFAutoQueue;
   using EnumQueueEntryStatus = org.cip4.jdflib.auto.JDFAutoQueueEntry.EnumQueueEntryStatus;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using QueueEntryComparator = org.cip4.jdflib.jmf.JDFQueueEntry.QueueEntryComparator;
   using NodeIdentifier = org.cip4.jdflib.node.JDFNode.NodeIdentifier;
   using JDFDate = org.cip4.jdflib.util.JDFDate;

   public class JDFQueue : JDFAutoQueue
   {
      private new const long serialVersionUID = 1L;
      ///   
      ///	 <summary> * number of concurrent running entries </summary>
      ///	 
      private int maxRunningEntries = 1;
      ///   
      ///	 <summary> * number of concurrent waiting entries </summary>
      ///	 
      private int maxWaitingEntries = 1000000;
      ///   
      ///	 <summary> * max number of completed entries to retain </summary>
      ///	 
      private int maxCompletedEntries = 0;
      private bool automated = false;
      private bool bAccepting = true; // new entries may be added to the queue
      private bool bProcessing = true; // new entries may be processed by the
      // queue processor
      private CleanupCallback cleanupCallback = null;
      private ExecuteCallback executeCallback = null;
      private Comparison<KElement> queueSorter = new Comparison<KElement>(new QueueEntryComparator().Compare);

      ///   
      ///	 <summary> * callback class definition for cleaning up in cleanup called once for every qe that is removed
      ///	 * 
      ///	 * @author prosirai
      ///	 *  </summary>
      ///	 
      public abstract class CleanupCallback
      {
         ///      
         ///		 <summary> * cleans up when a QueueEntry is removed by whatever method </summary>
         ///		 * <param name="qe"> </param>
         ///		 
         public abstract void cleanEntry(JDFQueueEntry qe);
      }

      ///   
      ///	 <summary> * callback class definition for specifying whether a QE may execute </summary>
      ///	 * <returns> true if this is executable
      ///	 * @author prosirai
      ///	 *  </returns>
      ///	 
      public abstract class ExecuteCallback
      {
         ///      
         ///		 * <param name="qe"> the queueentry to check
         ///		 * @returntrue if this qe can be executed </param>
         ///		 
         public abstract bool canExecute(JDFQueueEntry qe);
      }

      ///   
      ///	 <summary> * Constructor for JDFQueue
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFQueue(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * set the status as if an OpenQueue command has been sent
      ///	 * 
      ///	 * @return </summary>
      ///	 
      public virtual EnumQueueStatus openQueue()
      {
         if (bAccepting)
            return getQueueStatus();
         bAccepting = true;
         return setStatusFromEntries();
      }

      ///   
      ///	 <summary> * set the status as if a CloseQueue command has been sent
      ///	 * 
      ///	 * @return </summary>
      ///	 
      public virtual EnumQueueStatus closeQueue()
      {
         if (!bAccepting)
            return getQueueStatus();
         bAccepting = false;
         return setStatusFromEntries();
      }

      ///   
      ///	 <summary> * set the status as if a HoldQueue command has been sent
      ///	 * 
      ///	 * @return </summary>
      ///	 
      public virtual EnumQueueStatus holdQueue()
      {
         if (!bProcessing)
            return getQueueStatus();
         bProcessing = false;
         return setStatusFromEntries();
      }

      ///   
      ///	 <summary> * set the status as if a HoldQueue command has been sent
      ///	 * 
      ///	 * @return </summary>
      ///	 
      public virtual EnumQueueStatus resumeQueue()
      {
         if (bProcessing)
            return getQueueStatus();
         bProcessing = true;
         return setStatusFromEntries();
      }

      ///   
      ///	 <summary> * Constructor for JDFQueue
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFQueue(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFQueue
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFQueue(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      ///   
      ///	 <summary> * toString()
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public override string ToString()
      {
         return "JDFQueue[  --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * Method getEntryCount.
      ///	 *  </summary>
      ///	 * <returns> int quantity of QueueEntry children </returns>
      ///	 
      public virtual int getEntryCount()
      {
         return numChildElements(ElementName.QUEUEENTRY, null);
      }

      ///   
      ///	 <summary> * Get a vector of all queueentry elements
      ///	 *  </summary>
      ///	 * <returns> VElement: the vector of queue entries </returns>
      ///	 
      public virtual VElement getQueueEntryVector()
      {
         return getChildElementVector(ElementName.QUEUEENTRY, null, null, true, -1, true);
      }

      ///   
      ///	 <summary> * Get a vector of queueentry elements with a given set of attributes and part maps
      ///	 *  </summary>
      ///	 * <returns> VElement: the vector of queue entries </returns>
      ///	 
      [MethodImpl(MethodImplOptions.Synchronized)]
      public virtual VElement getQueueEntryVector(JDFAttributeMap attMap, VJDFAttributeMap parts)
      {
         VElement v = getChildElementVector(ElementName.QUEUEENTRY, null, attMap, true, -1, true);
         if (parts != null)
         {
            for (int i = v.Count - 1; i >= 0; i--)
            {
               JDFQueueEntry qe = (JDFQueueEntry)v[i];
               if (!parts.Equals(qe.getPartMapVector()))
               {
                  v.RemoveAt(i);
               }
            }
         }
         return (v == null || v.Count == 0) ? null : v;
      }

      ///   
      ///	 <summary> * get a map of queueentries that uses QueueEntryID as key </summary>
      ///	 * <returns> the map, null if this is empty </returns>
      ///	 
      [MethodImpl(MethodImplOptions.Synchronized)]
      public virtual IDictionary<string, JDFQueueEntry> getQueueEntryIDMap()
      {
         Dictionary<string, JDFQueueEntry> map = null;

         VElement v = getQueueEntryVector();
         if (v != null)
         {
            int siz = v.Count;
            if (siz > 0)
            {
               map = new Dictionary<string, JDFQueueEntry>(siz);
               for (int i = 0; i < siz; i++)
               {
                  JDFQueueEntry qe = (JDFQueueEntry)v[i];
                  map.Add(qe.getQueueEntryID(), qe);
               }
            }
         }

         return map;
      }

      ///   
      ///	 <summary> * Get a vector of queueentry elements that matches a given nodeidentifier
      ///	 *  </summary>
      ///	 * <returns> VElement: the vector of queue entries </returns>
      ///	 
      [MethodImpl(MethodImplOptions.Synchronized)]
      public virtual VElement getQueueEntryVector(NodeIdentifier nid)
      {
         VElement v = getQueueEntryVector();
         if (nid == null || v == null)
            return v;

         for (int i = v.Count - 1; i >= 0; i--)
         {
            JDFQueueEntry qe = (JDFQueueEntry)v[i];
            if (!qe.matchesNodeIdentifier(nid))
            {
               v.RemoveAt(i);
            }
         }

         return (v.Count == 0) ? null : v;
      }

      ///   
      ///	 <summary> * Method getEntry: find a queuentry by position
      ///	 *  </summary>
      ///	 * <param name="i"> the index of the queueentry </param>
      ///	 * <returns> JDFQueueEntry </returns>
      ///	 * @deprecated use getQueueEntry(int) 
      ///	 
      [Obsolete("use getQueueEntry(int)")]
      public virtual JDFQueueEntry getEntry(int i)
      {
         return getQueueEntry(i);
      }

      ///   
      ///	 <summary> * create a queueEntry if this queue is accepting
      ///	 *  </summary>
      ///	 * <param name="bHeld"> , if true, set the qe Status to Held </param>
      ///	 * <returns> the newly created queueEntry, null if failed </returns>
      ///	 
      public virtual JDFQueueEntry createQueueEntry(bool bHeld)
      {
         if (!canAccept())
            return null;
         JDFQueueEntry qe = appendQueueEntry();
         qe.setQueueEntryID("qe" + uniqueID(0));
         qe.setSubmissionTime(new JDFDate());
         qe.setQueueEntryStatus(bHeld ? EnumQueueEntryStatus.Held : EnumQueueEntryStatus.Waiting);
         return qe;
      }

      ///   
      ///	 <summary> * flush this queue according to the rules defined in qf
      ///	 *  </summary>
      ///	 * <param name="qf"> </param>
      ///	 * <returns> null if none were removed, else vector of removed queuentries </returns>
      ///	 
      [MethodImpl(MethodImplOptions.Synchronized)]
      public virtual VElement flushQueue(JDFQueueFilter qf)
      {
         int siz = 0;

         VElement ve = getQueueEntryVector();
         if (ve != null)
         {
            siz = ve.Count;
            for (int i = siz - 1; i >= 0; i--)
            {
               JDFQueueEntry qe = (JDFQueueEntry)ve[i];
               if (qe.matchesQueueFilter(qf))
               {
                  if (cleanupCallback != null)
                     cleanupCallback.cleanEntry(qe);

                  qe.deleteNode();
               }
               else
               {
                  ve.RemoveAt(i);
                  siz--;
               }
            }
         }

         if (automated)
            setStatusFromEntries();

         return siz == 0 ? null : ve;

      }

      ///   
      ///	 <summary> * Method findQueueEntries
      ///	 * <p>
      ///	 * default: findQueueEntries(jobID, jobPartID, new VJDFAttributeMap(), null)
      ///	 *  </summary>
      ///	 * <param name="strJobID"> Job ID. </param>
      ///	 * <param name="strJobPartID"> Job part ID. </param>
      ///	 * <param name="vamParts"> Partition to execute, may not be null </param>
      ///	 * <param name="status"> Queue Entry Status, null means any status. </param>
      ///	 * @deprecated use getQueueEntryVector(map, partmapvector)
      ///	 *  
      ///	 * <returns> VString: vector of QueueEntry IDs </returns>
      ///	 
      [Obsolete("use getQueueEntryVector(map, partmapvector)")]
      public virtual VString findQueueEntries(string strJobID, string strJobPartID, VJDFAttributeMap vamParts, EnumQueueEntryStatus status)
      {
         VString vsQEntryIDs = new VString();

         int entryCount = getEntryCount();
         for (int i = 0; i < entryCount; i++)
         {
            JDFQueueEntry entry = getQueueEntry(i);

            string strQEJobID = entry.getJobID();
            string strQEJobPartID = entry.getJobPartID();

            VJDFAttributeMap vamQEParts = entry.getPartMapVector();

            EnumQueueEntryStatus statusQE = entry.getQueueEntryStatus();

            if (strJobID.Equals(strQEJobID) && strJobPartID.Equals(strQEJobPartID) && vamParts.Equals(vamQEParts))
            {
               if ((status == null) || (status.Equals(statusQE)))
               {
                  vsQEntryIDs.appendUnique(entry.getQueueEntryID());
               }
            }
         }

         return vsQEntryIDs;
      }

      ///   
      ///	 <summary> * Find a queueEntry by QueueEntryID<br>
      ///	 * 
      ///	 * note that you may want to use the generic getChildByTagName with the appropriate attribute map, if you have more
      ///	 * information available
      ///	 *  </summary>
      ///	 * <param name="strQEntryID"> the QueueEntryID of the requeste QueueEntry </param>
      ///	 * <returns> the QueueEntry with QueueEntryID=strQEntryID, null if strQEntryID is null or empty string or the
      ///	 *         queueentry does not exist </returns>
      ///	 * @deprecated use getQueueEntry(id) 
      ///	 
      [Obsolete("use getQueueEntry(id)")]
      public virtual JDFQueueEntry getEntry(string strQEntryID)
      {
         return getQueueEntry(strQEntryID);
      }

      ///   
      ///	 <summary> * Find a queueEntry by QueueEntryID<br>
      ///	 * 
      ///	 * note that you may want to use the generic getChildByTagName with the appropriate attribute map, if you have more
      ///	 * information available
      ///	 *  </summary>
      ///	 * <param name="strQEntryID"> the QueueEntryID of the requeste QueueEntry </param>
      ///	 * <returns> the QueueEntry with QueueEntryID=strQEntryID, null if strQEntryID is null or empty string or the
      ///	 *         queueentry does not exist
      ///	 *  </returns>
      ///	 
      public virtual JDFQueueEntry getQueueEntry(string strQEntryID)
      {
         if (isWildCard(strQEntryID))
            return null;
         return (JDFQueueEntry)getChildByTagName(ElementName.QUEUEENTRY, null, 0, new JDFAttributeMap(AttributeName.QUEUEENTRYID, strQEntryID), true, true);
      }

      ///   
      ///	 <summary> * Find a queueEntry by NodeIdentifier (jobid, jobpartid, part)<br>
      ///	 * 
      ///	 * note that you may want to use the generic getChildByTagName with the appropriate attribute map, if you have more
      ///	 * information available
      ///	 *  </summary>
      ///	 * <param name="nodeID"> the identifier - jobID, jobPartID, parts - of the qe </param>
      ///	 * <param name="nSkip"> the number of nodes to skip, cout backwards if<0 </param>
      ///	 * <returns> the QueueEntry with matching jobID, jobPartID, parts, null if nodeID is null or empty string or the
      ///	 *         queueentry does not exist
      ///	 *  </returns>
      ///	 
      public virtual JDFQueueEntry getQueueEntry(NodeIdentifier nodeID, int nSkip)
      {
         if (nodeID == null)
            return null;

         VElement v = getQueueEntryVector();
         if (v != null)
         {
            int siz = v.Count;
            int n = 0;
            if (nSkip >= 0)
            {
               for (int i = 0; i < siz; i++)
               {
                  JDFQueueEntry qe = (JDFQueueEntry)v[i];
                  NodeIdentifier ni2 = qe.getIdentifier();
                  if (ni2.matches(nodeID) && n++ >= nSkip)
                     return qe;
               }
            }
            else
            {
               for (int i = siz - 1; i >= 0; i--)
               {
                  JDFQueueEntry qe = (JDFQueueEntry)v[i];
                  NodeIdentifier ni2 = qe.getIdentifier();
                  if (ni2.matches(nodeID) && --n <= nSkip)
                     return qe;
               }
            }
         }

         return null;
      }

      /////

      ///   
      ///	 <summary> * Find the position of a queueEntry by QueueEntryID
      ///	 *  </summary>
      ///	 * <param name="strQEntryID"> the QueueEntryID of the requeste QueueEntry </param>
      ///	 * <returns> the position in the queue, -1 if not there </returns>
      ///	 
      public virtual int getQueueEntryPos(string strQEntryID)
      {
         VElement v = getChildElementVector(ElementName.QUEUEENTRY, null, null, true, 0, false);
         for (int i = 0; i < v.Count; i++)
         {
            JDFQueueEntry qe = (JDFQueueEntry)v[i];
            if (qe.getQueueEntryID().Equals(strQEntryID))
               return i;
         }
         return -1;

      }

      //
      ///   
      ///	 <summary> * Get the next QueueEntry to be processed the first entry with highest priority gets selected if deviceID is
      ///	 * specified, the entries with an explicit non matching deviceID are ignored the status of the QueueEntry MUST be
      ///	 * waiting
      ///	 *  </summary>
      ///	 * <param name="deviceID"> the deviceID of the executing device - if null any deviceID will match </param>
      ///	 * <param name="proxyFlag"> if not null, the existance of this attribute in the queueentry excludes the qe from the search
      ///	 *            used e.g. in case a queue is used as a proxy and represents previously submitted jobs as waiting
      ///	 *  </param>
      ///	 * <returns> the executable queueEntry, null if none is available </returns>
      ///	 
      [MethodImpl(MethodImplOptions.Synchronized)]
      public virtual JDFQueueEntry getNextExecutableQueueEntry()
      {
         JDFQueueEntry theEntry = null;

         if (!canExecute())
            return theEntry;

         VElement v = getQueueEntryVector(new JDFAttributeMap(AttributeName.STATUS, EnumQueueEntryStatus.Waiting), null);
         if (v != null)
         {
            int siz = v.Count;
            for (int i = 0; i < siz; i++)
            {
               JDFQueueEntry qe = (JDFQueueEntry)v[i];

               if (executeCallback != null && !executeCallback.canExecute(qe))
                  continue;

               if (theEntry == null)
               {
                  theEntry = qe;
               }
               else if (qe.CompareTo(theEntry) < 0)
               {
                  theEntry = qe;
               }
            }
         }

         return theEntry;
      }

      ///   
      ///	 <summary> * if the outgoing device processor is accepting new entries
      ///	 *  </summary>
      ///	 * <returns> true, if new entries are accepted </returns>
      ///	 
      public virtual bool canExecute()
      {
         EnumQueueStatus status = getQueueStatus();
         if (EnumQueueStatus.Blocked.Equals(status))
            return false;
         if (EnumQueueStatus.Held.Equals(status))
            return false;
         if (EnumQueueStatus.Full.Equals(status))
            return false;
         if (EnumQueueStatus.Running.Equals(status))
            return false;
         if (EnumQueueStatus.Waiting.Equals(status))
            return true;
         // if(EnumQueueStatus.Blocked.equals(status))
         // blocked or null(illegal)
         return numEntries(EnumQueueEntryStatus.Running) < maxRunningEntries;
      }

      ///   
      ///	 <summary> * if the incoming queue processor is accepting new entries
      ///	 *  </summary>
      ///	 * <returns> true, if new entries are accepted </returns>
      ///	 
      public virtual bool canAccept()
      {
         EnumQueueStatus status = getQueueStatus();
         if (EnumQueueStatus.Blocked.Equals(status))
            return false;
         if (EnumQueueStatus.Closed.Equals(status))
            return false;
         if (EnumQueueStatus.Full.Equals(status))
            return false;
         if (EnumQueueStatus.Waiting.Equals(status))
            return true;
         // if(EnumQueueStatus.Blocked.equals(status))
         // blocked or null(illegal)
         return hasAttribute(AttributeName.QUEUESIZE) ? numEntries(null) < getQueueSize() : !maxWaiting();
      }

      ///   
      ///	 <summary> * remove all entries with Status=Removed and any entries over maxCompleted that are either aborted or completed @see
      ///	 * <seealso cref="JDFQueueEntry"/> .isCompleted()
      ///	 *  </summary>
      ///	 * <returns> a vector of all removed elements </returns>
      ///	 

      [MethodImpl(MethodImplOptions.Synchronized)]
      public virtual void cleanup()
      {
         VElement v = getQueueEntryVector();
         if (v != null)
         {
            int siz = v.Count;
            int nBad = 0;
            for (int i = 0; i < siz; i++)
            {
               JDFQueueEntry qe = (JDFQueueEntry)v[i];
               EnumQueueEntryStatus status = qe.getQueueEntryStatus();
               if (EnumQueueEntryStatus.Removed.Equals(status))
               {
                  if (cleanupCallback != null)
                     cleanupCallback.cleanEntry(qe);

                  qe.deleteNode();
               }
               else if (qe.isCompleted())
               {
                  if (nBad++ >= maxCompletedEntries)
                  {
                     if (cleanupCallback != null)
                        cleanupCallback.cleanEntry(qe);

                     qe.deleteNode();
                  }
               }
            }
         }

         setStatusFromEntries();
      }

      ///   
      ///	 <summary> * copies this to the JDF Response resp, applying the filters defined in filter
      ///	 *  </summary>
      ///	 * <param name="resp"> the JDFResponse to copy this to </param>
      ///	 * <param name="filter"> the QueueFilter that sets the queue size </param>
      ///	 * <returns> the copied queue </returns>
      ///	 
      [MethodImpl(MethodImplOptions.Synchronized)]
      public virtual JDFQueue copyToResponse(JDFResponse resp, JDFQueueFilter filter)
      {
         if (resp == null)
            return null;
         resp.removeChildren(ElementName.QUEUE, null, null);
         JDFQueue newQueue = (JDFQueue)resp.copyElement(this, null);
         if (filter != null)
         {
            filter.match(newQueue);
         }
         return newQueue;

      }

      ///   
      ///	 <summary> * return the number of entries
      ///	 *  </summary>
      ///	 * <param name="qeStatus"> the queueentry status of the enries to count, if null, do not filter </param>
      ///	 * <returns> the number of active processors </returns>
      ///	 
      public virtual int numEntries(EnumQueueEntryStatus qeStatus)
      {
         int n = 0;
         JDFQueueEntry qe = (JDFQueueEntry)getFirstChildElement(ElementName.QUEUEENTRY, null);
         string stat = qeStatus == null ? null : qeStatus.getName();
         while (qe != null)
         {
            if (stat == null || stat.Equals(qe.getAttribute(AttributeName.STATUS)))
               n++;
            qe = (JDFQueueEntry)qe.getNextSiblingElement(ElementName.QUEUEENTRY, null);
         }
         return n;
      }

      ///   
      ///	 * <returns> true if the number of entries running is exceeded - performance </returns>
      ///	 
      private bool maxRunning()
      {
         return numEntries(EnumQueueEntryStatus.Running) >= maxRunningEntries;
      }

      ///   
      ///	 * <returns> true if the number of entries running is exceeded - performance </returns>
      ///	 
      private bool maxWaiting()
      {
         return numEntries(EnumQueueEntryStatus.Waiting) >= maxWaitingEntries;
      }

      ///   
      ///	 <summary> * make this a smart queue when modifying queueentries
      ///	 *  </summary>
      ///	 * <param name="_automated"> automate if true </param>
      ///	 
      public virtual void setAutomated(bool _automated)
      {
         automated = _automated;
         if (automated)
            setStatusFromEntries();
      }

      ///   
      ///	 <summary> * is this a smart queue when modifying queueentries
      ///	 *  </summary>
      ///	 * <returns>  true if this is automated </returns>
      ///	 
      public virtual bool isAutomated()
      {
         return automated;
      }

      ///   
      ///	 <summary> * get the queuesize attribute or if it does not exist, count queuentry elements
      ///	 *  </summary>
      ///	 * <returns> the size of the queue </returns>
      ///	 
      public override int getQueueSize()
      {
         if (hasAttribute(AttributeName.QUEUESIZE))
            return base.getQueueSize();
         return getEntryCount();
      }

      ///   
      ///	 <summary> * set the status of this queue based on the status values of the queueentries
      ///	 *  </summary>
      ///	 * <returns> the newly set Status, null if not modified </returns>
      ///	 
      [MethodImpl(MethodImplOptions.Synchronized)]
      public virtual EnumQueueStatus setStatusFromEntries()
      {
         // EnumQueueStatus queueStatus = getQueueStatus();
         EnumQueueStatus newStatus = null;
         if (bAccepting)
         {
            if (bProcessing)
            {
               bool maxRunning_ = maxRunning();
               bool maxWaiting_ = maxWaiting();
               if (!maxRunning_)
               {
                  if (!maxWaiting_)
                     newStatus = EnumQueueStatus.Waiting;
                  else
                     newStatus = EnumQueueStatus.Closed;

               }
               else if (!maxWaiting_)
                  newStatus = EnumQueueStatus.Running;
               else
                  newStatus = EnumQueueStatus.Full;
            }
            else
            // accepting but not processing
            {
               newStatus = EnumQueueStatus.Held;
            }
         }
         else
         // queue is closed
         {
            if (bProcessing)
            {
               newStatus = EnumQueueStatus.Closed;
            }
            else
            // accepting but not processing
            {
               newStatus = EnumQueueStatus.Blocked;
            }
         }

         if (newStatus != null)
            setQueueStatus(newStatus);

         return newStatus;
      }

      //
      ///   
      ///	 <summary> * sorts all child elements by alphabet
      ///	 *  </summary>
      ///	 
      public override void sortChildren()
      {
         sortChildren(queueSorter);
      }

      ///   
      ///	 * <returns> the maxCompletedEntries </returns>
      ///	 
      public virtual int getMaxCompletedEntries()
      {
         return maxCompletedEntries;
      }

      ///   
      ///	 <summary> * set the maximum number of completed entries to keep also call cleanup if we are automated
      ///	 *  </summary>
      ///	 * <param name="maxCompletedEntries"> the maxCompletedEntries to set </param>
      ///	 * <returns> <seealso cref="VElement"/> the list of removed entries due to cleanup </returns>
      ///	 
      public virtual void setMaxCompletedEntries(int _maxCompletedEntries)
      {
         this.maxCompletedEntries = _maxCompletedEntries;
         // VElement v=null;
         if (automated)
            cleanup();
      }

      ///   
      ///	 * <returns> the maxRunningEntries </returns>
      ///	 
      public virtual int getMaxRunningEntries()
      {
         return maxRunningEntries;
      }

      ///   
      ///	 * <param name="maxRunningEntries"> the maxRunningEntries to set </param>
      ///	 
      public virtual void setMaxRunningEntries(int _maxRunningEntries)
      {
         this.maxRunningEntries = _maxRunningEntries;
         if (automated)
            setStatusFromEntries();
      }

      ///   
      ///	 * <param name="_maxWaitingEntries"> the setMaxWaitingEntries to set, excluding held entries </param>
      ///	 
      public virtual void setMaxWaitingEntries(int _maxWaitingEntries)
      {
         this.maxWaitingEntries = _maxWaitingEntries;
         if (automated)
            setStatusFromEntries();
      }

      ///   
      ///	 * <param name="_cleanupCallback"> the cleanupCallback to set </param>
      ///	 
      public virtual void setCleanupCallback(CleanupCallback _cleanupCallback)
      {
         this.cleanupCallback = _cleanupCallback;
      }

      ///   
      ///	 * <param name="_callback"> the ExecuteCallback to set </param>
      ///	 
      public virtual void setExecuteCallback(ExecuteCallback _callback)
      {
         this.executeCallback = _callback;
      }

      ///   
      ///	 * <param name="queueSorter"> the queueSorter to set sets the Comparator to sort this queuewith </param>
      ///	 
      public virtual void setQueueSorter(Comparison<KElement> _queueSorter)
      {
         this.queueSorter = _queueSorter;
      }
   }
}
