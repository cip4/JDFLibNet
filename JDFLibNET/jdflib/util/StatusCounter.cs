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
 * org.cip4.jdflib.util.MimeUtil.cs
 * Project Name: mimeutil 
 */

namespace org.cip4.jdflib.util
{
   using System.Runtime.CompilerServices;
   using System.Collections.Generic;
   using System.Text;
   using System.Threading;


   using EnumDeviceOperationMode = org.cip4.jdflib.auto.JDFAutoDeviceInfo.EnumDeviceOperationMode;
   using EnumDeviceStatus = org.cip4.jdflib.auto.JDFAutoDeviceInfo.EnumDeviceStatus;
   using EnumWorkType = org.cip4.jdflib.auto.JDFAutoMISDetails.EnumWorkType;
   using EnumClass = org.cip4.jdflib.auto.JDFAutoNotification.EnumClass;
   using EnumReason = org.cip4.jdflib.auto.JDFAutoResourceAudit.EnumReason;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using EnumAuditType = org.cip4.jdflib.core.JDFAudit.EnumAuditType;
   using EnumNodeStatus = org.cip4.jdflib.core.JDFElement.EnumNodeStatus;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using JDFDeviceInfo = org.cip4.jdflib.jmf.JDFDeviceInfo;
   using JDFJMF = org.cip4.jdflib.jmf.JDFJMF;
   using JDFJobPhase = org.cip4.jdflib.jmf.JDFJobPhase;
   using JDFMessage = org.cip4.jdflib.jmf.JDFMessage;
   using JDFResourceInfo = org.cip4.jdflib.jmf.JDFResourceInfo;
   using JDFResourceQuParams = org.cip4.jdflib.jmf.JDFResourceQuParams;
   using JDFResponse = org.cip4.jdflib.jmf.JDFResponse;
   using JDFSignal = org.cip4.jdflib.jmf.JDFSignal;
   using EnumType = org.cip4.jdflib.jmf.JDFMessage.EnumType;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using NodeIdentifier = org.cip4.jdflib.node.JDFNode.NodeIdentifier;
   using JDFAuditPool = org.cip4.jdflib.pool.JDFAuditPool;
   using JDFNotification = org.cip4.jdflib.resource.JDFNotification;
   using JDFPhaseTime = org.cip4.jdflib.resource.JDFPhaseTime;
   using JDFProcessRun = org.cip4.jdflib.resource.JDFProcessRun;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFResourceAudit = org.cip4.jdflib.resource.JDFResourceAudit;
   using EnumPartIDKey = org.cip4.jdflib.resource.JDFResource.EnumPartIDKey;
   using EnumResStatus = org.cip4.jdflib.resource.JDFResource.EnumResStatus;
   using JDFComponent = org.cip4.jdflib.resource.process.JDFComponent;
   using JDFEmployee = org.cip4.jdflib.resource.process.JDFEmployee;
   using JDFExposedMedia = org.cip4.jdflib.resource.process.JDFExposedMedia;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;
   using JDFUsageCounter = org.cip4.jdflib.resource.process.JDFUsageCounter;

   //TODO add time related metadata

   ///
   /// <summary> * Utility class for status JDF and JMF
   /// * 
   /// * @author prosirai
   /// *  </summary>
   /// 
   public class StatusCounter
   {

      private double percentComplete = 0;
      protected internal JDFNode m_Node;
      private bool bCompleted = false;
      private JDFDoc docJMFPhaseTime;
      private JDFDoc docJMFResource;
      private JDFDoc docJMFNotification;
      protected internal VJDFAttributeMap m_vPartMap;
      protected internal VString m_ignoreParts = null;
      private string m_deviceID = null;
      private VString m_moduleID = null;
      private VString m_moduleType = null;
      private LinkAmount[] vLinkAmount = null;
      private string firstRefID = null;
      private string queueEntryID;
      private EnumDeviceOperationMode operationMode = EnumDeviceOperationMode.Productive;
      private EnumWorkType workType = null;
      protected internal SupportClass.HashSetSupport<string> setTrackWaste_ = new SupportClass.HashSetSupport<string>();
      protected internal SupportClass.HashSetSupport<string> setCopyResInfo = new SupportClass.HashSetSupport<string>();
      private EnumDeviceStatus status = null;
      private string statusDetails = null;
      private JDFDate startDate;
      private NodeIdentifier nodeID = null;
      private readonly List<JDFEmployee> vEmployees = new List<JDFEmployee>();

      public virtual int addEmployee(JDFEmployee employee)
      {
         JDFEmployee eOld = (JDFEmployee)ContainerUtil.getMatch(vEmployees, employee, 0);
         if (eOld == null)
         {
            vEmployees.Add(employee);
            resetPhase();
         }
         return vEmployees.Count;
      }

      public virtual bool removeEmployee(JDFEmployee employee)
      {
         JDFEmployee eOld = (JDFEmployee)ContainerUtil.getMatch(vEmployees, employee, 0);
         if (eOld != null)
         {
            bool b = vEmployees.Remove(employee);
            if (b)
               resetPhase();
            return b;
         }
         return false;
      }

      public override string ToString()
      {
         return "[StatusCounter - counter: " + m_deviceID + "Start date: " + startDate + " " + vLinkAmount + "]";
      }

      public virtual void writeAll()
      {
         if (m_Node != null)
         {
            getVResLink(2); // write all reslinks to disk
         }
      }

      ///   
      ///	 <summary> * construct a StatusUtil for a node n
      ///	 *  </summary>
      ///	 * <param name="node"> the JDFNode that is being processed </param>
      ///	 * <param name="vPartMap"> the map of Parts that is being processed excluding the waste partition </param>
      ///	 * <param name="vResLinks"> the reslinks that are tracked for amount handling </param>
      ///	 
      public StatusCounter(JDFNode node, VJDFAttributeMap vPartMap, VElement vResLinks)
      {
         setActiveNode(node, vPartMap, vResLinks);
      }

      ///   
      ///	 <summary> * set the currently active node
      ///	 *  </summary>
      ///	 * <param name="node"> the JDFNode that is being processed </param>
      ///	 * <param name="vPartMap"> the map of Parts that is being processed excluding the waste partition </param>
      ///	 * <param name="vResLinks"> the reslinks that are tracked for amount handling </param>
      ///	 
      public virtual void setActiveNode(JDFNode node, VJDFAttributeMap vPartMap, VElement vResLinks)
      {
         VElement vResLinksLocal = vResLinks;

         if (node == null)
            setTrackWaste_.Clear();

         bCompleted = false;
         m_Node = node;
         m_vPartMap = vPartMap;
         vLinkAmount = null;
         firstRefID = null;
         docJMFResource = null;
         docJMFPhaseTime = null;
         startDate = new JDFDate();
         nodeID = null;
         percentComplete = 0;
         if (node == null)
         {
            setPhase(null, null, EnumDeviceStatus.Idle, null);
         }

         if (m_vPartMap == null && m_Node != null)
         {
            m_vPartMap = m_Node.getNodeInfoPartMapVector();
         }

         nodeID = node != null ? node.getIdentifier() : null;
         if (m_vPartMap != null && nodeID != null && node != null)
         {
            nodeID.setTo(node.getJobID(true), node.getJobPartID(false), m_vPartMap);
         }

         if (vResLinksLocal == null && m_Node != null)
         {
            vResLinksLocal = m_Node.getResourceLinks(null);
            if (vResLinksLocal != null)
            {
               int siz = vResLinksLocal.Count;
               for (int i = siz - 1; i >= 0; i--)
               {
                  JDFResourceLink rl = (JDFResourceLink)vResLinksLocal[i];
                  if (!rl.isPhysical())
                     vResLinksLocal.RemoveAt(i);
               }
            }
         }

         setUpResLinks(vResLinksLocal);
      }

      ///   
      ///	 <summary> * simple sleep wrapper that catches its exception
      ///	 *  </summary>
      ///	 * <param name="millis"> </param>
      ///	 
      public static void sleep(int millis)
      {
         try
         {
            Thread.Sleep(millis);
         }
         catch (ThreadInterruptedException)
         {
            // System.out.print(".");
         }
      }

      ///   
      ///	 <summary> * get the matching LinkAmount out of this
      ///	 *  </summary>
      ///	 * <param name="refID"> the refID, name or usage of the resource of the bag - this MUST match the refID of a ResourceLink </param>
      ///	 * <returns> the LinkAmount with matching refID, null if none found or bags is null </returns>
      ///	 
      protected internal virtual LinkAmount getLinkAmount(string refID)
      {
         string refIDLocal = refID;

         if (vLinkAmount == null || vLinkAmount.Length == 0)
         {
            return null;
         }

         if (refIDLocal == null)
            refIDLocal = getFirstRefID();

         for (int i = 0; i < vLinkAmount.Length; i++)
         {
            if (vLinkAmount[i].linkFitsKey(refIDLocal))
            {
               return vLinkAmount[i];
            }
         }

         return null;
      }

      ///   
      ///	 <summary> * get the matching LinkAmount out of this
      ///	 *  </summary>
      ///	 * <param name="refID"> the refID, name or usage of the resource of the bag - this MUST match the refID of a ResourceLink </param>
      ///	 * <returns> the actual refID of the matching resLink, null if none found or bags is null </returns>
      ///	 
      public virtual string getLinkID(string refID)
      {
         string refIDLocal = refID;

         if (vLinkAmount == null || vLinkAmount.Length == 0)
         {
            return null;
         }

         if (refIDLocal == null)
            refIDLocal = getFirstRefID();

         for (int i = 0; i < vLinkAmount.Length; i++)
         {
            if (vLinkAmount[i].linkFitsKey(refIDLocal))
            {
               return vLinkAmount[i].rl.getrRef();
            }
         }

         return null;
      }

      ///   
      ///	 <summary> * get the matching LinkAmount out of this
      ///	 *  </summary>
      ///	 * <param name="refID"> the refID, name or usage of the resource of the bag - this MUST match the refID of a ResourceLink </param>
      ///	 * <returns> the LinkAmount with matching refID, null if none found or bags is null </returns>
      ///	 
      protected internal virtual LinkAmount getLinkAmount(int n)
      {
         if (vLinkAmount == null || vLinkAmount.Length <= n)
         {
            return null;
         }
         return vLinkAmount[n];
      }

      ///   
      ///	 <summary> * get the refID of the first resource, i.e. the Resource that is being tracked in status messages
      ///	 *  </summary>
      ///	 * <returns> the rRef of the prime resource link </returns>
      ///	 
      public virtual string getFirstRefID()
      {
         if (firstRefID != null)
            return firstRefID;
         if (vLinkAmount == null || vLinkAmount.Length == 0)
         {
            return null;
         }
         return vLinkAmount[0].rl.getrRef();
      }

      ///   
      ///	 <summary> * set the id of the resource to be tracked in phasetimes, i.e. THE resource that is counted
      ///	 *  </summary>
      ///	 * <param name="resID"> </param>
      ///	 
      public virtual void setFirstRefID(string resID)
      {
         firstRefID = resID;
      }

      ///   
      ///	 <summary> * set the partIDKeys to be ignored
      ///	 *  </summary>
      ///	 * <param name="key"> </param>
      ///	 
      public virtual void addIgnorePart(EnumPartIDKey key)
      {
         if (m_ignoreParts == null && key != null)
            m_ignoreParts = new VString();
         if (key == null)
            m_ignoreParts = null;
         else
            m_ignoreParts.Add(key.getName());
      }

      ///   
      ///	 * <param name="resLinks"> </param>
      ///	 
      private void setUpResLinks(VElement resLinks)
      {
         if (resLinks == null || resLinks.Count == 0)
         {
            return;
         }
         vLinkAmount = new LinkAmount[resLinks.Count];
         for (int i = 0; i < vLinkAmount.Length; i++)
         {
            vLinkAmount[i] = new LinkAmount(this, (JDFResourceLink)resLinks[i]);
         }
      }

      ///   
      ///	 <summary> * clear all the amounts in the resource with id refID
      ///	 *  </summary>
      ///	 * <param name="refID"> id of the resource </param>
      ///	 
      public virtual void clearAmounts(string refID)
      {
         LinkAmount la = getLinkAmount(refID);
         if (la == null)
            return;
         la.lastBag.reset();
      }

      ///   
      ///	 <summary> * set the phase the amount specified by amount and waste to the resource with id refID
      ///	 *  </summary>
      ///	 * <param name="refID"> , type or usage of the resource, if null all are updated </param>
      ///	 * <param name="amount"> the amount for this phase </param>
      ///	 * <param name="waste"> the waste for this phase </param>
      ///	 
      [MethodImpl(MethodImplOptions.Synchronized)]
      public virtual void setPhase(string refID, double amount, double waste)
      {
         LinkAmount la = getLinkAmount(refID);
         if (la == null)
            return;
         la.addPhase(amount, waste, true, false);
         if (amount >= 0)
            updatePercentComplete(la);
      }

      ///   
      ///	 <summary> * add the amount specified by amount and waste to the resource with id refID
      ///	 *  </summary>
      ///	 * <param name="refID"> , type or usage of the resource, if null all are updated </param>
      ///	 * <param name="amount"> </param>
      ///	 * <param name="waste"> </param>
      ///	 * <param name="sumTotal"> if true, also sum up the total amounts, else only phase </param>
      ///	 
      [MethodImpl(MethodImplOptions.Synchronized)]
      public virtual void addPhase(string refID, double amount, double waste, bool sumTotal)
      {
         LinkAmount la = getLinkAmount(refID);
         if (la == null)
            return;
         la.addPhase(amount, waste, false, sumTotal);
         if (amount >= 0)
            updatePercentComplete(la);
      }

      ///   
      ///	 <summary> * updates percentcomplete based on la </summary>
      ///	 * <param name="la"> </param>
      ///	 
      private void updatePercentComplete(LinkAmount la)
      {
         if (la == null || la.startAmount <= 0 || !la.rl.getrRef().Equals(getFirstRefID()))
            return;
         percentComplete = la.lastBag.totalAmount / la.startAmount * 100.0;
      }

      ///   
      ///	 <summary> * set the total amount specified by amount and waste to the resource with id refID usually called when reading
      ///	 * resource audits or resource signals
      ///	 *  </summary>
      ///	 * <param name="refID"> , type or usage of the resource, if null all are updated </param>
      ///	 * <param name="amount"> the amount to set </param>
      ///	 * <param name="bWaste"> if true, set total waste, else set total good </param>
      ///	 
      [MethodImpl(MethodImplOptions.Synchronized)]
      public virtual void setTotal(string refID, double amount, bool bWaste)
      {
         LinkAmount la = getLinkAmount(refID);
         if (la == null)
            return;
         if (bWaste)
         {
            la.lastBag.totalWaste = amount;
         }
         else
         {
            la.lastBag.totalAmount = amount;
            updatePercentComplete(la);
         }
         long t = (System.DateTime.Now.Ticks - 621355968000000000) / 10000;
         if (la.lastBag.lastCall == 0)
         {
            la.lastBag.speed = 0;
            la.lastBag.lastCall = t;
            la.lastBag.amountLast = 0;
         }
         else
         {
            double dt = t - la.lastBag.lastCall;
            if (dt > 30000)
            {
               dt /= 3600000.0;
               la.lastBag.speed = (la.lastBag.totalAmount + la.lastBag.totalWaste - la.lastBag.amountLast) / dt;
               la.lastBag.amountLast = la.lastBag.totalAmount + la.lastBag.totalWaste;
               la.lastBag.lastCall = t;
            }
         }
      }

      ///   
      ///	 <summary> * get the total the amount of the resource with id refID
      ///	 *  </summary>
      ///	 * <param name="refID"> , type or usage of the resource, </param>
      ///	 
      public virtual double getTotalAmount(string refID)
      {
         LinkAmount la = getLinkAmount(refID);
         return la == null ? 0 : la.getAmount(la.lastBag.totalAmount);
      }


      /// <summary>
      /// get all total amounts of all tracked resources
      /// </summary>
      /// <returns>Total amount</returns>
      public virtual double[] getTotalAmounts()
      {
         if (vLinkAmount == null || vLinkAmount.Length == 0)
            return null;
         double[] d = new double[vLinkAmount.Length];
         for (int i = 0; i < d.Length; i++)
            d[i] = vLinkAmount[i].getAmount(vLinkAmount[i].lastBag.totalAmount);
         return d;
      }


      /// <summary>
      /// get Amount Links
      /// </summary>
      /// <returns>Array of resource links</returns>
      public virtual JDFResourceLink[] getAmountLinks()
      {
         if (vLinkAmount == null || vLinkAmount.Length == 0)
            return null;
         JDFResourceLink[] d = new JDFResourceLink[vLinkAmount.Length];
         for (int i = 0; i < d.Length; i++)
            d[i] = vLinkAmount[i].rl;
         return d;
      }


	 
      /// <summary>
      /// get phase amounts of all tracked resources
      /// </summary>
      /// <returns>Array of amounts</returns>
      public virtual double[] getPhaseAmounts()
      {
         if (vLinkAmount == null || vLinkAmount.Length == 0)
            return null;
         double[] d = new double[vLinkAmount.Length];
         for (int i = 0; i < d.Length; i++)
            d[i] = vLinkAmount[i].getAmount(vLinkAmount[i].lastBag.phaseAmount);
         return d;
      }


      /// <summary>
      /// get percent complete
      /// </summary>
      /// <returns>the percent completed of the current node</returns>
      public virtual double getPercentComplete()
      {
         return percentComplete;
      }

      ///   
      ///	 <summary> * get the total the amount of the resource with id refID
      ///	 *  </summary>
      ///	 * <param name="refID"> , type or usage of the resource, </param>
      ///	 
      public virtual double getPhaseAmount(string refID)
      {
         LinkAmount la = getLinkAmount(refID);
         return la == null ? 0 : la.getAmount(la.lastBag.phaseAmount);
      }

      ///   
      ///	 <summary> * get the total the amount of the resource with id refID
      ///	 *  </summary>
      ///	 * <param name="refID"> , type or usage of the resource, </param>
      ///	 
      public virtual double getTotalWaste(string refID)
      {
         LinkAmount la = getLinkAmount(refID);
         return la == null ? 0 : la.getAmount(la.lastBag.totalWaste);
      }

      ///   
      ///	 <summary> * get all total amounts of all tracked resources
      ///	 *  </summary>
      ///	 * <param name="i"> </param>
      ///	 
      public virtual double[] getTotalWastes()
      {
         if (vLinkAmount == null || vLinkAmount.Length == 0)
            return null;
         double[] d = new double[vLinkAmount.Length];
         for (int i = 0; i < d.Length; i++)
            d[i] = vLinkAmount[i].getAmount(vLinkAmount[i].lastBag.totalWaste);
         return d;
      }

      ///   
      ///	 <summary> * get all phase waste amounts of all tracked resources
      ///	 *  </summary>
      ///	 * <param name="i"> </param>
      ///	 
      public virtual double[] getPhaseWastes()
      {
         if (vLinkAmount == null || vLinkAmount.Length == 0)
            return null;
         double[] d = new double[vLinkAmount.Length];
         for (int i = 0; i < d.Length; i++)
            d[i] = vLinkAmount[i].getAmount(vLinkAmount[i].lastBag.phaseWaste);
         return d;
      }

      ///   
      ///	 <summary> * get the total the amount of the resource with id refID
      ///	 *  </summary>
      ///	 * <param name="refID"> , type or usage of the resource, </param>
      ///	 
      public virtual double getPhaseWaste(string refID)
      {
         LinkAmount la = getLinkAmount(refID);
         return la == null ? 0 : la.getAmount(la.lastBag.phaseWaste);
      }

      private bool resetPhase()
      {
         if (m_Node == null)
            return setIdlePhase(status, statusDetails);

         JDFAuditPool ap = m_Node.getCreateAuditPool();
         JDFPhaseTime lastPhase = ap.getLastPhase(m_vPartMap, m_moduleID == null ? null : m_moduleID.stringAt(0));
         EnumNodeStatus ns = lastPhase != null ? lastPhase.getStatus() : EnumNodeStatus.Waiting;
         string nodeStatusDetails = lastPhase != null ? lastPhase.getStatusDetails() : statusDetails;
         return setPhase(ns, nodeStatusDetails, status, statusDetails);
      }

      ///   
      ///	 <summary> * set event, append the Event element and optionally the comment<br/> overwrites existing values
      ///	 *  </summary>
      ///	 * <param name="eventID"> Event/@EventID to set </param>
      ///	 * <param name="eventValue"> Event/@EventValue to set </param>
      ///	 * <param name="comment"> the comment text, if null no comment is set </param>
      ///	 
      [MethodImpl(MethodImplOptions.Synchronized)]
      public virtual JDFNotification setEvent(string eventID, string eventValue, string comment)
      {
         JDFNotification notif = createBaseNotification();
         JDFJMF jmf = createNotificationJMF();
         JDFSignal s = jmf.appendSignal(EnumType.Notification);
         notif.setEvent(eventID, eventValue, comment);
         s.copyElement(notif, null);
         return notif;
      }

      private JDFNotification createBaseNotification()
      {
         JDFNotification notif;

         if (m_Node != null)
         {
            JDFAuditPool ap = m_Node.getCreateAuditPool();
            notif = ap.addNotification(EnumClass.Event, null, m_vPartMap);
         }
         else
         {
            notif = (JDFNotification)new JDFDoc(ElementName.NOTIFICATION).getRoot();
         }
         for (int i = 0; i < vEmployees.Count; i++)
         {
            notif.copyElement(vEmployees[i], null);
         }
         notif.setNode(m_Node);
         return notif;
      }

      ///   
      ///	 * <returns> JDFJMF the newly created Notification JMF </returns>
      ///	 
      [MethodImpl(MethodImplOptions.Synchronized)]
      private JDFJMF createNotificationJMF()
      {
         if (docJMFNotification == null)
         {
            docJMFNotification = createJMFDoc();
         }
         return docJMFNotification.getJMFRoot();
      }

      ///   
      ///	 <summary> * Set the Status and StatusDetails of this node update the PhaseTime audit or append a new phasetime as appropriate
      ///	 * also prepare a status JMF
      ///	 *  </summary>
      ///	 * <param name="nodeStatus"> the new status of the node </param>
      ///	 * <param name="nodeStatusDetails"> the new statusDetails of the node </param>
      ///	 * <param name="deviceStatus"> the new status of the device </param>
      ///	 * <param name="deviceStatusDetails"> the new statusDetails of the device </param>
      ///	 * <param name="vPartMap"> the vector of parts to that should be set </param>
      ///	 * <param name="vResLink"> the resourcelinks that are used to fill the various amount attributes in jobphase and phasetime
      ///	 *  </param>
      ///	 
      [MethodImpl(MethodImplOptions.Synchronized)]
      public virtual bool setPhase(EnumNodeStatus nodeStatus, string nodeStatusDetails, EnumDeviceStatus deviceStatus, string deviceStatusDetails)
      {
         if (m_Node == null)
            return setIdlePhase(deviceStatus, deviceStatusDetails);

         status = deviceStatus;
         statusDetails = deviceStatusDetails;
         JDFJMF jmfStatus = createPhaseTimeJMF();
         JDFJMF jmfRes = createResourceJMF();

         LinkAmount mainLinkAmount = getLinkAmount(getFirstRefID());

         JDFAuditPool auditPool = m_Node.getCreateAuditPool();
         // TODO rethink when to send 2 phases
         JDFPhaseTime lastPhase = auditPool.getLastPhase(m_vPartMap, m_moduleID == null ? null : m_moduleID.stringAt(0));
         JDFPhaseTime nextPhase = lastPhase;
         bool bEnd = EnumNodeStatus.Completed.Equals(nodeStatus) || EnumNodeStatus.Aborted.Equals(nodeStatus);
         bool bChanged = bEnd || lastPhase == null; // no previous audit or
         // over and out

         nextPhase = auditPool.setPhase(nodeStatus, nodeStatusDetails, m_vPartMap, new VElement(VElement.ToVElement<JDFEmployee>(vEmployees)));
         if (bEnd && !bCompleted)
         {
            writeAll();
            appendResourceAudits();
            appendProcessRun(nodeStatus, auditPool);
            bCompleted = true;
         }
         if (!bEnd) // we have been active again - need to rewrite processruns
         {
            bCompleted = false;
         }

         if (nextPhase != null)
         {
            generateResourceResponse(jmfRes);
         }

         if (lastPhase != null && nextPhase != lastPhase) // we explicitly added
         // a new phasetime audit, thus we need to add a closing JMF for the original jobPhase
         {
            bChanged = true;
            closeJobPhase(jmfStatus, mainLinkAmount, lastPhase, nextPhase); // attention
            // -
            // resets la to 0 - all calls after	 this have the new amounts
            startDate = new JDFDate();
         }

         if (nextPhase != null)
         {
            if (workType != null)
               nextPhase.getCreateMISDetails().setWorkType(workType);
            if (m_deviceID != null)
            {
               nextPhase.getCreateDevice(0).setDeviceID(m_deviceID);
            }
            nextPhase.setModules(m_moduleID, m_moduleType);

            updateCurrentJobPhase(nodeStatus, nodeStatusDetails, deviceStatus, deviceStatusDetails, jmfStatus, mainLinkAmount, nextPhase, bEnd);
         }

         jmfStatus.eraseEmptyAttributes(true);
         jmfRes.eraseEmptyAttributes(true);
         return bChanged;
      }

      ///   
      ///	 <summary> * append resource audits and set output resource to available, if necessary </summary>
      ///	 
      private void appendResourceAudits()
      {
         if (vLinkAmount != null)
         {
            for (int i = 0; i < vLinkAmount.Length; i++)
            {
               setResourceAudit(vLinkAmount[i].refID, EnumReason.ProcessResult);
               vLinkAmount[i].updateNodeResource();
            }
         }
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      private JDFJMF createResourceJMF()
      {
         docJMFResource = createJMFDoc();
         return docJMFResource.getJMFRoot();
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      private JDFJMF createPhaseTimeJMF()
      {
         docJMFPhaseTime = createJMFDoc();
         return docJMFPhaseTime.getJMFRoot();
      }

      private JDFDoc createJMFDoc()
      {
         JDFDoc d = new JDFDoc(ElementName.JMF);
         JDFJMF jmf = d.getJMFRoot();
         jmf.setSenderID(m_deviceID);
         return d;
      }

      ///   
      ///	 * <param name="deviceStatus"> </param>
      ///	 * <param name="deviceStatusDetails"> </param>
      ///	 * <returns> true if change since last time </returns>
      ///	 
      private bool setIdlePhase(EnumDeviceStatus deviceStatus, string deviceStatusDetails)
      {
         bool bChanged = docJMFPhaseTime == null; // first aftersetPhase
         JDFResponse r = bChanged ? null : docJMFPhaseTime.getJMFRoot().getResponse(0);
         JDFDeviceInfo lastDevInfo = r == null ? null : r.getDeviceInfo(-1);
         status = deviceStatus;
         statusDetails = deviceStatusDetails;

         bChanged = bChanged || !ContainerUtil.Equals(deviceStatusDetails, lastDevInfo == null ? null : lastDevInfo.getAttribute(AttributeName.STATUSDETAILS, null, null));
         startDate = (lastDevInfo == null || lastDevInfo.getIdleStartTime() == null || bChanged) ? new JDFDate() : lastDevInfo.getIdleStartTime();

         docJMFPhaseTime = new JDFDoc(ElementName.JMF);
         JDFResponse newResponse = docJMFPhaseTime.getJMFRoot().appendResponse(EnumType.Status);
         JDFDeviceInfo newDevInfo = newResponse.getCreateDeviceInfo(0);
         fillDeviceInfo(deviceStatus, deviceStatusDetails, newDevInfo, null);
         newDevInfo.setIdleStartTime(startDate);

         return bChanged;
      }

      ///   
      ///	 * <param name="deviceStatus"> </param>
      ///	 * <param name="deviceStatusDetails"> </param>
      ///	 * <param name="newDevInfo"> </param>
      ///	 
      private void fillDeviceInfo(EnumDeviceStatus deviceStatus, string deviceStatusDetails, JDFDeviceInfo newDevInfo, LinkAmount la)
      {
         newDevInfo.setDeviceStatus(deviceStatus);
         newDevInfo.setStatusDetails(deviceStatusDetails);
         newDevInfo.setDeviceOperationMode(operationMode);
         newDevInfo.setDeviceID(m_deviceID);
         if (la != null)
            newDevInfo.setSpeed(la.getAmount(la.lastBag.speed));
         for (int i = 0; i < vEmployees.Count; i++)
         {
            newDevInfo.copyElement(vEmployees[i], null);
         }

      }

      private void updateCurrentJobPhase(EnumNodeStatus nodeStatus, string nodeStatusDetails, EnumDeviceStatus deviceStatus, string deviceStatusDetails, JDFJMF jmf, LinkAmount la, JDFPhaseTime pt2, bool bEnd)
      {
         JDFResponse respStatus = (JDFResponse)jmf.appendMessageElement(JDFMessage.EnumFamily.Response, JDFMessage.EnumType.Status);
         JDFDeviceInfo deviceInfo = respStatus.getCreateDeviceInfo(0);
         // if(!bEnd) // don't write a jobphase for an idle device
         // {
         JDFJobPhase jp = deviceInfo.createJobPhaseFromPhaseTime(pt2);
         setJobPhaseAmounts(la, jp);
         jp.setQueueEntryID(queueEntryID);
         // }

         fillDeviceInfo(deviceStatus, deviceStatusDetails, deviceInfo, la);

         m_Node.setPartStatus(m_vPartMap, nodeStatus, nodeStatusDetails);
         getVResLink(2); // update the nodes links

         if (bEnd)
         {
            pt2.deleteNode(); // zapp the last phasetime
         }
         else
         {
            pt2.setLinks(getVResLink(1));
            pt2.eraseEmptyAttributes(true);
         }
      }

      private JDFResponse closeJobPhase(JDFJMF jmf, LinkAmount la, JDFPhaseTime pt1, JDFPhaseTime pt2)
      {
         JDFResponse respStatus = (JDFResponse)jmf.appendMessageElement(JDFMessage.EnumFamily.Response, JDFMessage.EnumType.Status);
         JDFDeviceInfo deviceInfo = respStatus.appendDeviceInfo();
         deviceInfo.setDeviceOperationMode(operationMode);
         JDFJobPhase jp = deviceInfo.createJobPhaseFromPhaseTime(pt1);
         jp.setJobID(m_Node.getJobID(true));
         jp.setJobPartID(m_Node.getJobPartID(false));
         jp.setQueueEntryID(queueEntryID);
         setJobPhaseAmounts(la, jp);
         pt1.setLinks(getVResLink(1));

         // cleanup!
         if (vLinkAmount != null)
         {
            for (int i = 0; i < vLinkAmount.Length; i++)
            {
               vLinkAmount[i].addPhase(0, 0, true, true);
            }
         }
         return respStatus;
      }

      private void appendProcessRun(EnumNodeStatus nodeStatus, JDFAuditPool ap)
      {
         JDFProcessRun pr = (JDFProcessRun)ap.addAudit(EnumAuditType.ProcessRun, null);
         pr.setPartMapVector(m_vPartMap);
         VElement audits = ap.getAudits(EnumAuditType.PhaseTime, null, m_vPartMap);
         for (int i = 0; i < audits.Count; i++)
         {
            pr.addPhase((JDFPhaseTime)audits[i]);
         }
         pr.setEndStatus(nodeStatus);
      }

      ///   
      ///	 * <param name="amounts"> </param>
      ///	 * <param name="jmfRes"> </param>
      ///	 
      private void generateResourceResponse(JDFJMF jmfRes)
      {
         VElement vResResourceInfo = getVResLink(3);
         JDFSignal sig = jmfRes.appendSignal(EnumType.Resource);
         JDFResourceQuParams rqp = sig.appendResourceQuParams();
         rqp.setJDF(m_Node);
         rqp.setExact(false);
         rqp.setQueueEntryID(queueEntryID);
         bool bAllExact = true;

         if (vResResourceInfo != null)
         {
            VElement.Enumerator vResResourceInfoIterator = vResResourceInfo.GetEnumerator();
            while (vResResourceInfoIterator.MoveNext())
            {
               JDFResourceInfo ri = sig.appendResourceInfo();
               if (workType != null)
               {
                  ri.appendMISDetails().setWorkType(workType);
               }
               JDFResourceLink rl = (JDFResourceLink)vResResourceInfoIterator.Current;
               LinkAmount la = getLinkAmount(rl.getrRef());
               bool bExact = la != null && la.isCopyResInfo();
               bAllExact = bAllExact && bExact;
               rqp.setExact(bExact);
               ri.setLink(rl, rqp);
            }
         }
         rqp.setExact(bAllExact);
      }

      ///   
      ///	 <summary> * update all status relevant data in jobphase
      ///	 * also update percentComplete if we don't have amounts
      ///	 *  </summary>
      ///	 * <param name="la"> </param>
      ///	 * <param name="jp"> </param>
      ///	 
      private void setJobPhaseAmounts(LinkAmount la, JDFJobPhase jp)
      {
         if (jp == null)
            return;
         jp.setPercentCompleted(percentComplete);

         if (la == null)
            return;

         if (la.isTrackWaste())
         {
            if (la.getAmount(la.lastBag.totalAmount) != 0)
            {
               jp.setPhaseAmount(la.getAmount(la.lastBag.phaseAmount));
               jp.setAmount(la.getAmount(la.lastBag.totalAmount));
            }
            if (la.getAmount(la.lastBag.totalWaste) != 0)
            {
               jp.setPhaseWaste(la.getAmount(la.lastBag.phaseWaste));
               jp.setWaste(la.getAmount(la.lastBag.totalWaste));
            }
         }
         else
         {
            if ((la.getAmount(la.lastBag.totalAmount) + la.getAmount(la.lastBag.totalWaste)) != 0)
            {
               jp.setPhaseAmount(la.getAmount(la.lastBag.phaseAmount) + la.getAmount(la.lastBag.phaseWaste));
               jp.setAmount(la.getAmount(la.lastBag.totalAmount) + la.getAmount(la.lastBag.totalWaste));
            }

         }
         double total = 0;

         total = la.startAmount;
         if (total != 0)
         {
            jp.setTotalAmount(total);
         }
      }

      ///   
      ///	 * <param name="resLink"> </param>
      ///	 * <param name="n"> : 1=phaseTime, 2=node, 3=resourceinfo </param>
      ///	 * <returns> VElement a vector of resourcelinks </returns>
      ///	 
      private VElement getVResLink(int n)
      {
         if (vLinkAmount == null || m_Node == null)
            return null;
         VElement vRet = new VElement();
         for (int i = 0; i < vLinkAmount.Length; i++)
         {
            LinkAmount la = vLinkAmount[i];
            if (n == 1)
            {
               vRet.Add(la.getPhaseTimeLink());
            }
            if (n == 2)
            {
               vRet.Add(la.updateNodeLink());
            }
            if (n == 3)
            {
               vRet.Add(la.getResourceInfoLink());
            }
            if (n == 4)
            {
               vRet.Add(la.getResourceAuditLink());
            }
         }
         return vRet;
      }

      ///   
      ///	 * <returns> the docJMFPhaseTime </returns>
      ///	 
      [MethodImpl(MethodImplOptions.Synchronized)]
      public virtual JDFDoc getDocJMFPhaseTime()
      {
         if (docJMFPhaseTime == null)
            setIdlePhase(EnumDeviceStatus.Idle, null);
         return (JDFDoc)docJMFPhaseTime.Clone();
      }

      ///   
      ///	 * <returns> the docJMFResource </returns>
      ///	 
      [MethodImpl(MethodImplOptions.Synchronized)]
      public virtual JDFDoc getDocJMFResource()
      {
         if (docJMFResource == null)
            return null;
         return (JDFDoc)docJMFResource.Clone();
      }

      ///   
      ///	 * <returns> the docJMFNotification </returns>
      ///	 
      [MethodImpl(MethodImplOptions.Synchronized)]
      public virtual JDFDoc getDocJMFNotification(bool bClean)
      {
         JDFDoc ret = null;
         if (docJMFNotification != null)
         {
            if (bClean)
            {
               ret = docJMFNotification;
               docJMFNotification = null;
            }
            else
            {
               ret = (JDFDoc)docJMFNotification.Clone();
            }
         }
         return ret;
      }

      //

      //

      ///   
      ///	 <summary> * container class to set amounts and waste in phaseTime </summary>
      ///	 
      public class LinkAmount
      {
         public class AmountBag
         {
            ///         
            ///			 <summary> * refID of the resourceLink to set </summary>
            ///			 
            protected internal double totalAmount;
            protected internal double phaseAmount;
            protected internal double totalWaste;
            protected internal double phaseWaste;
            protected internal long lastCall = 0;
            protected internal double speed = 0.0;
            protected internal double amountLast = 0;

            public override string ToString()
            {
               return "[AmountBag totalAmount=" + totalAmount + " phaseAmount=" + phaseAmount + " totalWaste=" + totalWaste + " phaseWaste=" + phaseWaste + " ]";
            }

            ///         
            ///			 <summary> *  </summary>
            ///			 * <param name="_refID"> refID of the resource that is being counted </param>
            ///			 
            protected internal AmountBag()
            {
               reset();
            }

            ///         
            ///			 <summary> * </summary>
            ///			 
            protected internal virtual void reset()
            {
               totalAmount = 0;
               phaseAmount = 0;
               totalWaste = 0;
               phaseWaste = 0;
            }

            ///         
            ///			 <summary> * copy ctor
            ///			 *  </summary>
            ///			 * <param name="bag"> </param>
            ///			 
            protected internal AmountBag(AmountBag bag)
            {
               totalAmount = bag.totalAmount;
               phaseAmount = bag.phaseAmount;
               totalWaste = bag.totalWaste;
               phaseWaste = bag.phaseWaste;
            }

            ///         
            ///			 * <param name="amount"> </param>
            ///			 * <param name="waste"> </param>
            ///			 * <param name="bNewPhase"> </param>
            ///			 * <param name="sumTotal"> if true, also sum up the total amounts, else only phase </param>
            ///			 
            protected internal virtual void addPhase(double amount, double waste, bool bNewPhase, bool sumTotal)
            {
               if (sumTotal)
               {
                  totalAmount += amount;
                  totalWaste += waste;
               }
               if (bNewPhase)
               {
                  phaseAmount = amount;
                  phaseWaste = waste;
               }
               else
               {
                  phaseAmount += amount;
                  phaseWaste += waste;
               }
               long t = (System.DateTime.Now.Ticks - 621355968000000000) / 10000;
               if ((totalAmount + totalWaste) == 0) // else total takes over
               {
                  if (lastCall == 0)
                  {
                     lastCall = t;
                     amountLast = 0.0;

                  }
                  // wait at least 30 seconds to calculate speed -else bad fluctuations...
                  else if (t - lastCall < 30000 && !bNewPhase)
                  {
                     amountLast += amount + waste;
                  }
                  else
                  // calculate current speed
                  {
                     amountLast += amount + waste;
                     double deltaT = t - lastCall;
                     deltaT /= 3600000.0; // milliseconds / hour
                     speed = deltaT == 0.0 ? 0.0 : amountLast / deltaT;
                     amountLast = 0.0;
                     lastCall = t;
                  }
               }
            }
         } // end AmountBag

         

         protected internal double startAmount = 0;
         protected internal double startWaste = 0;
         protected internal JDFResourceLink rl;
         protected internal string refID;
         protected internal readonly AmountBag lastBag;
         protected internal VJDFAttributeMap vResPartMap;
         private bool bInteger = false;
         private StatusCounter EnclosingInstance;

         protected internal LinkAmount(StatusCounter enclosingInstance, JDFResourceLink _rl)
         {
            EnclosingInstance = enclosingInstance;
            JDFNode dump = new JDFDoc("JDF").getJDFRoot();
            dump.appendResourceLinkPool().copyElement(_rl, null);
            JDFResource target = _rl.getTarget();
            bInteger = isInteger(target);
            dump.appendResourcePool().copyElement(target, null);
            rl = (JDFResourceLink)dump.getResourceLinkPool().getElement(_rl.Name, null, 0);

            lastBag = new AmountBag();
            refID = rl.getrRef();
            if (EnclosingInstance.m_vPartMap == null)
               vResPartMap = rl.getPartMapVector();
            else
               vResPartMap = new VJDFAttributeMap(EnclosingInstance.m_vPartMap);

            if (vResPartMap != null)
            {
               if (EnclosingInstance.m_ignoreParts != null)
               {
                  vResPartMap.removeKeys(EnclosingInstance.m_ignoreParts.getSet());
               }
               // final VString partIDKeys = target.getPartIDKeys();
               // Set keyset=partIDKeys==null ? null : partIDKeys.getSet();
               // vResPartMap.reduceMap(keyset);
               if (vResPartMap.Count == 0)
                  vResPartMap = null;
            }
            if (isTrackWaste())
            {
               VJDFAttributeMap vMap = new VJDFAttributeMap(vResPartMap);
               vMap.put(EnumPartIDKey.Condition, "Good");
               startAmount = rl.getAmountPoolSumDouble(AttributeName.AMOUNT, vMap);
               lastBag.totalAmount += rl.getAmountPoolSumDouble(AttributeName.ACTUALAMOUNT, vMap);

               vMap.put(EnumPartIDKey.Condition, "Waste");
               startWaste = rl.getAmountPoolSumDouble(AttributeName.MAXAMOUNT, vMap);
               if (startWaste <= 0.0)
                  startWaste = rl.getAmountPoolSumDouble(AttributeName.AMOUNT, vMap);
               lastBag.totalAmount += rl.getAmountPoolSumDouble(AttributeName.ACTUALAMOUNT, vMap);
            }
            else
            {
               startAmount = rl.getAmountPoolSumDouble(AttributeName.AMOUNT, vResPartMap);
               lastBag.totalAmount += rl.getAmountPoolSumDouble(AttributeName.ACTUALAMOUNT, vResPartMap);
            }
         }

         ///      
         ///		 <summary> * should the resource be displayed as an integer? </summary>
         ///		 * <param name="target"> </param>
         ///		 * <returns> true if the resource is an integer type </returns>
         ///		 
         private bool isInteger(JDFResource target)
         {
            return (target is JDFUsageCounter) || (target is JDFMedia) || (target is JDFExposedMedia) || (target is JDFComponent);
         }

         ///      
         ///		 * <returns> the updated reslink </returns>
         ///		 
         protected internal virtual JDFResourceLink updateNodeLink()
         {
            JDFResourceLink nodeLink = EnclosingInstance.m_Node.getLink(0, null, new JDFAttributeMap(AttributeName.RREF, rl.getrRef()), null);
            VJDFAttributeMap vMap = new VJDFAttributeMap(vResPartMap);
            if (vMap.Count == 0)
            {
               vMap.Add(new JDFAttributeMap());
            }
            if (nodeLink != null)
            {

               if (isTrackWaste())
               {
                  vMap.put(EnumPartIDKey.Condition, "Good");
                  nodeLink.setAmountPoolAttribute(AttributeName.ACTUALAMOUNT, formatAmount(lastBag.totalAmount), null, vMap);
                  vMap.put(EnumPartIDKey.Condition, "Waste");
                  nodeLink.setAmountPoolAttribute(AttributeName.ACTUALAMOUNT, formatAmount(lastBag.totalWaste), null, vMap);
               }
               else
               {
                  nodeLink.setAmountPoolAttribute(AttributeName.ACTUALAMOUNT, formatAmount(lastBag.totalAmount + lastBag.totalWaste), null, vMap);
               }
               // update output status
               if (lastBag.totalAmount > 0)
               {
                  JDFResource r = nodeLink.getLinkRoot();
                  if (vResPartMap != null)
                  {
                     for (int i = 0; i < vResPartMap.Count; i++)
                     {
                        JDFAttributeMap m = vResPartMap[i];
                        JDFResource rp = r.getPartition(m, null);
                        if (rp != null)
                           rp.setResStatus(EnumResStatus.Available, false);
                     }
                  }
                  else
                  {
                     r.setResStatus(EnumResStatus.Available, false);
                  }
               }
            }
            return nodeLink;
         }

         ///      
         ///		 <summary> * update the output resource to be available </summary>
         ///		 
         internal virtual void updateNodeResource()
         {
            JDFResourceLink nodeLink = EnclosingInstance.m_Node.getLink(0, null, new JDFAttributeMap(AttributeName.RREF, rl.getrRef()), null);
            if (nodeLink != null && EnumUsage.Output.Equals(nodeLink.getUsage()))
            {

               VElement vRes = nodeLink.getTargetVector(-1);
               if (vRes != null)
               {
                  int size = vRes.Count;
                  for (int i = 0; i < size; i++)
                  {
                     JDFResource r = (JDFResource)vRes[i];
                     VElement leaves = r.getLeaves(false);
                     for (int j = 0; j < leaves.Count; j++)
                     {
                        JDFResource rr = (JDFResource)leaves[j];
                        VJDFAttributeMap vMap = rr.getPartMapVector(false);
                        if (EnclosingInstance.m_vPartMap != null && EnclosingInstance.m_vPartMap.overlapsMap(vMap))
                           rr.setResStatus(EnumResStatus.Available, true);
                     }
                  }
               }
            }
         }

         ///      
         ///		 * <returns> get a link to dump into a paseTime audit </returns>
         ///		 
         protected internal virtual JDFResourceLink getPhaseTimeLink()
         {
            cleanAmounts();
            setPhaseAmounts();
            return rl;
         }

         ///      
         ///		 * <returns> JDFResourceLink the resource link for a resource audit </returns>
         ///		 
         protected internal virtual JDFResourceLink getResourceAuditLink()
         {
            cleanAmounts();
            setTotalAmounts();
            return rl;
         }

         ///      
         ///		 * <returns> JDFResourceLink the resource link for a resourceInfo </returns>
         ///		 
         protected internal virtual JDFResourceLink getResourceInfoLink()
         {
            cleanAmounts();
            return setTotalAmounts();
         }

         private JDFResourceLink setPhaseAmounts()
         {
            VJDFAttributeMap vMap = new VJDFAttributeMap(vResPartMap);
            if (vMap.Count == 0)
            {
               vMap.Add(new JDFAttributeMap());
            }
            if (isTrackWaste())
            {
               vMap.put(EnumPartIDKey.Condition, "Good");
               if (lastBag.totalAmount != 0 || startAmount > 0)
               {
                  rl.setAmountPoolAttribute(AttributeName.ACTUALAMOUNT, formatAmount(lastBag.phaseAmount), null, vMap);
               }
               if (startAmount != 0)
               {
                  rl.setAmountPoolAttribute(AttributeName.AMOUNT, formatAmount(startAmount), null, vMap);
               }
               vMap.put(EnumPartIDKey.Condition, "Waste");
               if (lastBag.totalWaste != 0 || startWaste > 0)
               {
                  rl.setAmountPoolAttribute(AttributeName.ACTUALAMOUNT, formatAmount(lastBag.phaseWaste), null, vMap);
               }
               if (startWaste != 0)
               {
                  rl.setAmountPoolAttribute(AttributeName.AMOUNT, formatAmount(startWaste), null, vMap);
               }
            }
            else
            {
               if (lastBag.totalAmount + lastBag.totalWaste != 0 || startAmount + startWaste > 0)
               {
                  rl.setAmountPoolAttribute(AttributeName.ACTUALAMOUNT, formatAmount(lastBag.phaseAmount + lastBag.phaseWaste), null, vMap);
               }
               if (startAmount + startWaste != 0)
               {
                  rl.setAmountPoolAttribute(AttributeName.AMOUNT, formatAmount(startAmount + startWaste), null, vMap);
               }
            }
            return rl;
         }

         private JDFResourceLink setTotalAmounts()
         {
            VJDFAttributeMap vMap = new VJDFAttributeMap(vResPartMap);
            if (vMap.Count == 0)
            {
               vMap.Add(new JDFAttributeMap());
            }
            if (isTrackWaste())
            {
               vMap.put(EnumPartIDKey.Condition, "Good");
               if (lastBag.totalAmount != 0)
               {
                  rl.setAmountPoolAttribute(AttributeName.ACTUALAMOUNT, formatAmount(lastBag.totalAmount), null, vMap);
               }
               if (startAmount != 0)
               {
                  rl.setAmountPoolAttribute(AttributeName.AMOUNT, formatAmount(startAmount), null, vMap);
               }
               vMap.put(EnumPartIDKey.Condition, "Waste");
               if (lastBag.totalWaste != 0)
               {
                  rl.setAmountPoolAttribute(AttributeName.ACTUALAMOUNT, formatAmount(lastBag.totalWaste), null, vMap);
               }
               if (startWaste != 0)
               {
                  rl.setAmountPoolAttribute(AttributeName.AMOUNT, formatAmount(startWaste), null, vMap);
               }
            }
            else
            {
               if (lastBag.totalAmount + lastBag.totalWaste != 0)
               {
                  rl.setAmountPoolAttribute(AttributeName.ACTUALAMOUNT, formatAmount(lastBag.totalAmount + lastBag.totalWaste), null, vMap);
               }
               if (startAmount + startWaste != 0)
               {
                  rl.setAmountPoolAttribute(AttributeName.AMOUNT, formatAmount(startAmount + startWaste), null, vMap);
               }
            }
            return rl;
         }

         ///      
         ///		 <summary> * change the value to integer, if required  </summary>
         ///		 * <returns> the formatted amount, either as integer or double </returns>
         ///		 
         protected internal virtual double getAmount(double amount)
         {
            return bInteger ? ((int)amount) : amount;
         }

         ///      
         ///		 * <returns> the formatted amount, either as integer or double </returns>
         ///		 
         protected internal virtual string formatAmount(double amount)
         {
            return bInteger ? StringUtil.formatInteger((int)amount) : StringUtil.formatDouble(amount);
         }

         ///      
         ///		 <summary> *  </summary>
         ///		 
         private void cleanAmounts()
         {

            rl.removeAttribute(AttributeName.AMOUNT);
            rl.removeAttribute(AttributeName.ACTUALAMOUNT);
            rl.removeChild(ElementName.AMOUNTPOOL, null, 0);
         }

         ///      
         ///		 * <param name="amount"> </param>
         ///		 * <param name="waste"> </param>
         ///		 * <param name="bNewPhase"> </param>
         ///		 * <param name="sumTotal"> if true, also sum up the total amounts, else only phase </param>
         ///		 
         protected internal virtual void addPhase(double amount, double waste, bool bNewPhase, bool sumTotal)
         {
            lastBag.addPhase(amount, waste, bNewPhase, sumTotal);
         }

         //      
         //		 * (non-Javadoc)
         //		 * 
         //		 * @see java.lang.Object#toString()
         //		 
         public override string ToString()
         {
            StringBuilder sb = new StringBuilder();
            sb.Append("LinkAmount: refID=");
            sb.Append(refID);
            sb.Append("\n");
            sb.Append(vResPartMap);
            sb.Append("\nstartAmount: ");
            sb.Append(startAmount);
            sb.Append("\nstartWaste: ");
            sb.Append(startWaste);
            sb.Append(lastBag);

            return sb.ToString();

         }

         protected internal virtual bool linkFitsKey(string key)
         {
            if (key == null)
               return true;

            return rl.matchesString(key);
         }

         protected internal virtual bool linkFitsKey(SupportClass.HashSetSupport<string> keys)
         {
            if (keys == null)
               return false;

            return keys.Contains("*") || keys.Contains(rl.getNamedProcessUsage()) || keys.Contains(rl.getLinkedResourceName()) || keys.Contains(refID) || keys.Contains(rl.getAttribute(AttributeName.USAGE));
         }

         ///      
         ///		 * <returns> the bCopyResInfo </returns>
         ///		 
         public virtual bool isCopyResInfo()
         {
            return linkFitsKey(EnclosingInstance.setCopyResInfo);
         }

         ///      
         ///		 * <returns> the bTrackWaste </returns>
         ///		 
         public virtual bool isTrackWaste()
         {
            return linkFitsKey(EnclosingInstance.setTrackWaste_);
         }

      }

      //   
      //	 * @return the m_deviceID
      //	 
      public virtual string getDeviceID()
      {
         return m_deviceID;
      }

      //   
      //	 * @return the m_moduleID
      //	 
      public virtual VString getModuleeID()
      {
         return m_moduleID;
      }

      ///   
      ///	 * <param name="m_deviceid"> the m_deviceID to set </param>
      ///	 
      public virtual void setDeviceID(string deviceid)
      {
         m_deviceID = deviceid;
      }

      ///   
      ///	 * <param name="m_deviceid"> the m_deviceID to set </param>
      ///	 
      public virtual void addModule(string moduleID, string moduleType)
      {
         if (m_moduleID == null)
            m_moduleID = new VString();
         if (m_moduleType == null)
            m_moduleType = new VString();
         m_moduleID.Add(moduleID);
         m_moduleType.Add(moduleType);
      }

      ///   
      ///	 <summary> * set waste tracking on or off for the resourcelink rl
      ///	 *  </summary>
      ///	 * <param name="resID"> the resource id to the resource to track </param>
      ///	 * <param name="b"> tracking on or off </param>
      ///	 
      public virtual void setTrackWaste(string resID, bool b)
      {
         if (b)
            setTrackWaste_.Add(resID);
         else
            setTrackWaste_.Remove(resID);
      }

      ///   
      ///	 <summary> * set copying the resource into resourceInfo on or off for the resourcelink rl
      ///	 *  </summary>
      ///	 * <param name="rl"> the resourcelink to the resource to copy </param>
      ///	 * <param name="b"> tracking on or off </param>
      ///	 
      public virtual void setCopyResInResInfo(string _refID, bool b)
      {
         if (b)
            setCopyResInfo.Add(_refID);
         else
            setCopyResInfo.Remove(_refID);

      }

      ///   
      ///	 <summary> *  </summary>
      ///	 * <param name="resID"> the resource ID to set/track reason for the audit </param>
      ///	 * <returns> JDFResourceAudit the generated audit </returns>
      ///	 
      [MethodImpl(MethodImplOptions.Synchronized)]
      public virtual JDFResourceAudit setResourceAudit(string resID, EnumReason reason)
      {
         LinkAmount la = getLinkAmount(resID);
         if (la == null)
            return null;
         JDFAuditPool ap = m_Node.getCreateAuditPool();

         JDFResourceAudit resourceAudit = ap.addResourceAudit(null);
         resourceAudit.setContentsModified(false);
         resourceAudit.setReason(reason);

         resourceAudit.copyElement(la.getResourceAuditLink(), null);
         resourceAudit.setPartMapVector(m_vPartMap);

         return resourceAudit;
      }

      ///   
      ///	 <summary> * </summary>
      ///	 
      public virtual JDFProcessRun setProcessResult(EnumNodeStatus endStatus)
      {
         setPhase(EnumNodeStatus.Completed, null, EnumDeviceStatus.Idle, null);
         JDFAuditPool ap = m_Node.getCreateAuditPool();
         JDFProcessRun pr = (JDFProcessRun)ap.getAudit(-1, EnumAuditType.ProcessRun, null, m_vPartMap);
         return pr;
      }

      ///   
      ///	 * <param name="queueEntryID"> </param>
      ///	 
      public virtual void setQueueEntryID(string _queueEntryID)
      {
         queueEntryID = _queueEntryID;
      }

      ///   
      ///	 * <param name="queueEntryID"> </param>
      ///	 
      public virtual string getQueueEntryID()
      {
         return queueEntryID;
      }

      ///   
      ///	 <summary> * sets the MISDetails/@WorkType for default audis, resource audits and phaseTime elements
      ///	 *  </summary>
      ///	 * <param name="_workType"> the worktype to set, if null no MISDetails and no Worktype are added. closes all ongoing phases
      ///	 *            and starts a new phase </param>
      ///	 
      public virtual void setWorkType(EnumWorkType _workType)
      {
         if (ContainerUtil.Equals(_workType, workType))
            return; // nop

         workType = _workType;
      }

      public virtual EnumDeviceStatus getStatus()
      {
         return status;
      }

      public virtual string getStatusDetails()
      {
         return statusDetails;
      }

      public virtual JDFDate getStartDate()
      {
         return startDate;
      }

      public virtual void setOperationMode(EnumDeviceOperationMode _operationMode)
      {
         operationMode = _operationMode;
      }

      ///   
      ///	 * <param name="refID"> the resource ID or name </param>
      ///	 * <returns> the planned amount for the resource </returns>
      ///	 
      public virtual double getPlannedAmount(string refID)
      {
         LinkAmount la = getLinkAmount(refID);
         return la == null ? 0 : la.getAmount(la.startAmount);
      }

      ///   
      ///	 * <param name="refID"> the resource ID or name </param>
      ///	 * <returns> the planned waste for the resource </returns>
      ///	 
      public virtual double getPlannedWaste(string refID)
      {
         LinkAmount la = getLinkAmount(refID);
         return la == null ? 0 : la.getAmount(la.startWaste);
      }

      ///   
      ///	 * <returns> the nodeID </returns>
      ///	 
      public virtual NodeIdentifier getNodeIDentifier()
      {
         return nodeID;
      }

      ///   
      ///	 <summary> * set percentComplete to percent </summary>
      ///	 * <param name="percent"> the percentage to set </param>
      ///	 
      public virtual void setPercentComplete(double percent)
      {
         percentComplete = percent;
      }

      ///   
      ///	 <summary> * update percentComplete by percent </summary>
      ///	 * <param name="percent"> the percentage to increment </param>
      ///	 
      public virtual void updatePercentComplete(double percent)
      {
         percentComplete += percent;
      }
   }
}
