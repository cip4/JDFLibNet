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
 * ==========================================================================
 * class JDFQueueEntry extends JDFResource
 * ==========================================================================
 * @COPYRIGHT Heidelberger Druckmaschinen AG, 1999-2001
 * ALL RIGHTS RESERVED
 * @Author sabjontopmail.de   using a code generator
 * Warning! very preliminary test version. Interface subject to change without prior notice!
 * Revision history:    ... 
 */

namespace org.cip4.jdflib.jmf
{
   using System;
   using System.Collections.Generic;



   using JDFAutoQueueEntry = org.cip4.jdflib.auto.JDFAutoQueueEntry;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFNodeInfo = org.cip4.jdflib.core.JDFNodeInfo;
   using KElement = org.cip4.jdflib.core.KElement;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using INodeIdentifiable = org.cip4.jdflib.ifaces.INodeIdentifiable;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using NodeIdentifier = org.cip4.jdflib.node.JDFNode.NodeIdentifier;
   using ContainerUtil = org.cip4.jdflib.util.ContainerUtil;
   using JDFDate = org.cip4.jdflib.util.JDFDate;

   //----------------------------------
   ///
   /// <summary> * @author prosirai
   /// * </summary>
   /// 
   public class JDFQueueEntry : JDFAutoQueueEntry, IComparable, INodeIdentifiable
   {
      public class QueueEntryComparator
      {

         //      
         //		 * (non-Javadoc)
         //		 * 
         //		 * @see java.util.Comparator#compare(java.lang.Object, java.lang.Object)
         //		 
         public virtual int Compare(object a1, object a2)
         {
            if (!(a1 is KElement))
               return -1;
            if (!(a2 is KElement))
               return 1;
            KElement o1 = (KElement)a1;
            KElement o2 = (KElement)a2;
            int i = o1.Name.CompareTo(o2.Name);
            if (i != 0)
               return i;
            if ((o1 is JDFQueueEntry) && (o2 is JDFQueueEntry))
            {
               JDFQueueEntry q1 = (JDFQueueEntry)o1;
               JDFQueueEntry q2 = (JDFQueueEntry)o2;
               EnumQueueEntryStatus status1 = q1.getQueueEntryStatus();
               EnumQueueEntryStatus status2 = q2.getQueueEntryStatus();
               int s1 = (status1 == null) ? 0 : status1.getValue();
               int s2 = (status2 == null) ? 0 : status2.getValue();
               if (s1 != s2)
                  return s1 - s2;
               if (q1.isCompleted())
               {
                  JDFDate d1 = q1.getEndTime();
                  JDFDate d2 = q1.getEndTime();
                  if (d1 != null && d2 != null)
                     return d1.CompareTo(d2);
               }
               else
               {
                  s1 = q1.getPriority();
                  s2 = q2.getPriority();
                  if (s1 != s2)
                     return s2 - s1;
               }

               JDFDate d11 = q1.getStartTime();
               JDFDate d22 = q2.getStartTime();
               int d = ContainerUtil.compare(d11, d22);
               if (d != 0)
                  return d;

               d11 = q1.getSubmissionTime();
               d22 = q2.getSubmissionTime();
               d = ContainerUtil.compare(d11, d22);
               if (d != 0)
                  return d;
            }
            return 0;
         }
      }

      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFQueueEntry
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFQueueEntry(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFQueueEntry
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFQueueEntry(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFQueueEntry
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFQueueEntry(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
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
         return "JDFQueueEntry[  --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * get part map vector
      ///	 *  </summary>
      ///	 * <returns> VJDFAttributeMap: vector of attribute maps, one for each part </returns>
      ///	 
      public override VJDFAttributeMap getPartMapVector()
      {
         return base.getPartMapVector();
      }

      ///   
      ///	 <summary> * set all parts to those define in vParts
      ///	 *  </summary>
      ///	 * <param name="vParts"> vector of attribute maps for the parts </param>
      ///	 
      public override void setPartMapVector(VJDFAttributeMap vParts)
      {
         base.setPartMapVector(vParts);
      }

      ///   
      ///	 <summary> * set all parts to those defined by mPart
      ///	 *  </summary>
      ///	 * <param name="mPart"> attribute map for the part to set </param>
      ///	 
      public override void setPartMap(JDFAttributeMap mPart)
      {
         base.setPartMap(mPart);
      }

      ///   
      ///	 <summary> * remove the part defined in mPart
      ///	 *  </summary>
      ///	 * <param name="mPart"> attribute map for the part to remove </param>
      ///	 
      public override void removePartMap(JDFAttributeMap mPart)
      {
         base.removePartMap(mPart);
      }

      ///   
      ///	 <summary> * return true if this qe matches the input node identifier
      ///	 *  </summary>
      ///	 * <param name="ni">
      ///	 * @return </param>
      ///	 
      public virtual bool matchesNodeIdentifier(NodeIdentifier ni)
      {
         if (ni == null)
            return false;
         NodeIdentifier niThis = getIdentifier();
         return niThis.matches(ni);
      }

      ///   
      ///	 <summary> * return true if this qe matches the input QueueFilter
      ///	 *  </summary>
      ///	 * <param name="ni">
      ///	 * @return </param>
      ///	 
      public virtual bool matchesQueueFilter(JDFQueueFilter filter)
      {
         if (filter == null)
            return true;
         return filter.matches(this);
      }

      ///   
      ///	 <summary> * check whether the part defined by mPart is included
      ///	 *  </summary>
      ///	 * <param name="mPart"> attribute map to look for </param>
      ///	 * <returns> boolean - returns true if the part exists </returns>
      ///	 
      public override bool hasPartMap(JDFAttributeMap mPart)
      {
         return base.hasPartMap(mPart);
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.auto.JDFAutoQueueEntry#setPriority(int)
      //	 
      public override void setPriority(int @value)
      {
         int oldVal = hasAttribute(AttributeName.PRIORITY) ? getPriority() : -1;
         if (isAutomated() && @value != oldVal)
         {
            JDFQueue queue = (JDFQueue)getParentNode_KElement();
            lock (queue)
            {
               base.setPriority(@value);
               queue.sortChildren();
            }
         }
         else if (@value != oldVal) // non automated
         {
            base.setPriority(@value);
         }
      }

      ///   
      ///	 <summary> * sort this into the queue based on current values assumes presorted queue
      ///	 *  </summary>
      ///	 * <param name="oldVal"> - the previous sort value, use -1 to sort from back </param>
      ///	 * @deprecated call JDFQueue.sortChildren() 
      ///	 
      [Obsolete("call JDFQueue.sortChildren()")]
      public virtual void sortQueue(int oldVal)
      {
         JDFQueue queue = (JDFQueue)getParentNode_KElement();
         queue.sortChildren();
      }

      ///   
      ///	 * <returns> true if the parent queue is automated </returns>
      ///	 
      private bool isAutomated()
      {
         KElement e = getParentNode_KElement();
         if (e is JDFQueue)
         {
            return ((JDFQueue)e).isAutomated();
         }
         return false;
      }

      ///   
      ///	 <summary> * sets the QueueEntry/@Status if the queue is automated, also resorts the queue to reflect the new Status and sets
      ///	 * the Queue/@Status based on the maximum number of concurrently running jobs also sets StartTime and EndTime
      ///	 * appropriately if the queue is automated
      ///	 *  </summary>
      ///	 * <param name="value"> the queuentry status to set
      ///	 *  </param>
      ///	 * <seealso cref= org.cip4.jdflib.auto.JDFAutoQueueEntry#setQueueEntryStatus(org.cip4.jdflib.auto.JDFAutoQueueEntry.EnumQueueEntryStatus) </seealso>
      ///	 
      public override void setQueueEntryStatus(EnumQueueEntryStatus @value)
      {
         EnumQueueEntryStatus oldVal = getQueueEntryStatus();
         if (isAutomated() && !ContainerUtil.Equals(oldVal, @value))
         {
            JDFQueue queue = (JDFQueue)getParentNode_KElement();
            lock (queue)
            {
               base.setQueueEntryStatus(@value);
               if (isCompleted())
               {
                  if (!hasAttribute(AttributeName.ENDTIME))
                     base.setEndTime(new JDFDate());
                  queue.cleanup();
               }
               if (EnumQueueEntryStatus.Running.Equals(@value))
               {
                  if (!hasAttribute(AttributeName.STARTTIME))
                     base.setStartTime(new JDFDate());
                  removeAttribute(AttributeName.ENDTIME);

               }
               queue.sortChildren();
               queue.setStatusFromEntries();
            }
         }
         else if (!ContainerUtil.Equals(oldVal, @value)) // non automated
         {
            base.setQueueEntryStatus(@value);
         }
      }

      ///   
      ///	 <summary> * gets the NodeIdetifier that matches this
      ///	 * 
      ///	 * @return </summary>
      ///	 
      public virtual NodeIdentifier getIdentifier()
      {
         NodeIdentifier ni = new NodeIdentifier();
         ni.setTo(getJobID(), getJobPartID(), getPartMapVector());
         return ni;
      }

      ///   
      ///	 <summary> * gets the NodeIdetifier that matches this
      ///	 * 
      ///	 * @return </summary>
      ///	 
      public virtual void setIdentifier(NodeIdentifier ni)
      {
         if (ni == null)
            return;
         setPartMapVector(ni.getPartMapVector());
         setJobID(ni.getJobID());
         setJobPartID(ni.getJobPartID());
      }

      ///   
      ///	 <summary> * get the next sibling queueentry
      ///	 * 
      ///	 * @return </summary>
      ///	 
      public virtual JDFQueueEntry getNextQueueEntry()
      {
         return (JDFQueueEntry)getNextSiblingElement(ElementName.QUEUEENTRY, null);
      }

      ///   
      ///	 <summary> * get the previous sibling queueentry
      ///	 * 
      ///	 * @return </summary>
      ///	 
      public virtual JDFQueueEntry getPreviousQueueEntry()
      {
         return (JDFQueueEntry)getPreviousSiblingElement(ElementName.QUEUEENTRY, null);
      }

      ///   
      ///	 <summary> * get the vector of valid next @Status values for this queue entry based on the current staus based on the table of
      ///	 * valid queue entry transitions
      ///	 *  </summary>
      ///	 * <returns> Vector<EnumQueueEntryStatus> the vector of valid new stati </returns>
      ///	 
      public virtual List<EnumQueueEntryStatus> getNextStatusVector()
      {
         List<EnumQueueEntryStatus> v = new List<EnumQueueEntryStatus>();

         EnumQueueEntryStatus qesThis = getQueueEntryStatus();
         if (qesThis == null)
         {
            IEnumerator<EnumQueueEntryStatus> it = (IEnumerator<EnumQueueEntryStatus>)EnumQueueEntryStatus.iterator();
            while (it.MoveNext())
               v.Add(it.Current);
         }
         else if (EnumQueueEntryStatus.Running.Equals(qesThis))
         {
            v.Add(EnumQueueEntryStatus.Running);
            v.Add(EnumQueueEntryStatus.PendingReturn);
            v.Add(EnumQueueEntryStatus.Completed);
            v.Add(EnumQueueEntryStatus.Aborted);
         }
         else if (EnumQueueEntryStatus.Waiting.Equals(qesThis))
         {
            v.Add(EnumQueueEntryStatus.Running);
            v.Add(EnumQueueEntryStatus.Waiting);
            v.Add(EnumQueueEntryStatus.Held);
            v.Add(EnumQueueEntryStatus.Removed);
            v.Add(EnumQueueEntryStatus.PendingReturn);
            v.Add(EnumQueueEntryStatus.Aborted);
         }
         else if (EnumQueueEntryStatus.Held.Equals(qesThis))
         {
            v.Add(EnumQueueEntryStatus.Waiting);
            v.Add(EnumQueueEntryStatus.Held);
            v.Add(EnumQueueEntryStatus.Removed);
            v.Add(EnumQueueEntryStatus.PendingReturn);
            v.Add(EnumQueueEntryStatus.Aborted);
         }
         else if (EnumQueueEntryStatus.Removed.Equals(qesThis))
         {
            v.Add(EnumQueueEntryStatus.Removed);
         }
         else if (EnumQueueEntryStatus.Suspended.Equals(qesThis))
         {
            v.Add(EnumQueueEntryStatus.Running);
            v.Add(EnumQueueEntryStatus.Suspended);
            v.Add(EnumQueueEntryStatus.Aborted);
         }
         else if (EnumQueueEntryStatus.PendingReturn.Equals(qesThis))
         {
            v.Add(EnumQueueEntryStatus.PendingReturn);
            v.Add(EnumQueueEntryStatus.Completed);
            v.Add(EnumQueueEntryStatus.Aborted);
         }
         else if (EnumQueueEntryStatus.Completed.Equals(qesThis))
         {
            v.Add(EnumQueueEntryStatus.Waiting);
            v.Add(EnumQueueEntryStatus.Removed);
            v.Add(EnumQueueEntryStatus.PendingReturn);
            v.Add(EnumQueueEntryStatus.Completed);
            v.Add(EnumQueueEntryStatus.Aborted);
         }
         else if (EnumQueueEntryStatus.Aborted.Equals(qesThis))
         {
            v.Add(EnumQueueEntryStatus.Waiting);
            v.Add(EnumQueueEntryStatus.Removed);
            v.Add(EnumQueueEntryStatus.PendingReturn);
            v.Add(EnumQueueEntryStatus.Aborted);
         }

         return v;
      }

      ///   
      ///	 * <returns> true if this entry is completed </returns>
      ///	 
      public virtual bool isCompleted()
      {
         EnumQueueEntryStatus status = getQueueEntryStatus();
         return EnumQueueEntryStatus.Completed.Equals(status) || EnumQueueEntryStatus.Removed.Equals(status) || EnumQueueEntryStatus.Aborted.Equals(status);
      }

      ///   
      ///	 <summary> * return a value based on QueueEntryStatus and Priority to sort the queue
      ///	 *  </summary>
      ///	 * <returns> int a priority for sorting - low = back </returns>
      ///	 
      [Obsolete]
      public virtual int getSortPriority()
      {
         return getSortPriority(getQueueEntryStatus(), getPriority());
      }

      ///   
      ///	 <summary> * return a value based on QueueEntryStatus and Priority to sort the queue the status is the major order whereas the
      ///	 * priority is used to order within regions of identical status
      ///	 *  </summary>
      ///	 * <returns> int a priority for sorting - low value = back of queue, high value = front of queue </returns>
      ///	 
      [Obsolete]
      public static int getSortPriority(EnumQueueEntryStatus status, int priority)
      {
         int sort = (status == null) ? 0 : 10000 - 1000 * status.getValue();
         sort += priority;
         return sort;
      }

      ///   
      ///	 <summary> * populates this queuentry with the relevant parameters extracted from a JDF jobid, partmap, jobpartid etc.
      ///	 *  </summary>
      ///	 * <param name="jdf"> </param>
      ///	 
      public virtual void setFromJDF(JDFNode jdf)
      {
         if (jdf == null)
            return;
         setJobID(jdf.getJobID(true));
         setJobPartID(jdf.getJobPartID(false));
         setPartMapVector(jdf.getPartMapVector());

         if (!hasAttribute(AttributeName.PRIORITY))
         {
            JDFNodeInfo ni = jdf.getInheritedNodeInfo("@" + AttributeName.PRIORITY);
            if (ni != null)
               copyAttribute(AttributeName.PRIORITY, ni, null, null, null);
         }

         this.eraseEmptyAttributes(true);
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see java.lang.Comparable#compareTo(java.lang.Object)
      //	 
      public virtual int CompareTo(object arg0)
      {
         return new QueueEntryComparator().Compare(this, arg0);
      }
   }
}
