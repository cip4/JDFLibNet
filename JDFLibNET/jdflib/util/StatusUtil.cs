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
   using System;

   using EnumDeviceStatus = org.cip4.jdflib.auto.JDFAutoDeviceInfo.EnumDeviceStatus;
   using EnumReason = org.cip4.jdflib.auto.JDFAutoResourceAudit.EnumReason;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using VElement = org.cip4.jdflib.core.VElement;
   using EnumAuditType = org.cip4.jdflib.core.JDFAudit.EnumAuditType;
   using EnumNodeStatus = org.cip4.jdflib.core.JDFElement.EnumNodeStatus;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using JDFDeviceInfo = org.cip4.jdflib.jmf.JDFDeviceInfo;
   using JDFJMF = org.cip4.jdflib.jmf.JDFJMF;
   using JDFJobPhase = org.cip4.jdflib.jmf.JDFJobPhase;
   using JDFMessage = org.cip4.jdflib.jmf.JDFMessage;
   using JDFResourceInfo = org.cip4.jdflib.jmf.JDFResourceInfo;
   using JDFResourceQuParams = org.cip4.jdflib.jmf.JDFResourceQuParams;
   using JDFSignal = org.cip4.jdflib.jmf.JDFSignal;
   using EnumType = org.cip4.jdflib.jmf.JDFMessage.EnumType;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using JDFAuditPool = org.cip4.jdflib.pool.JDFAuditPool;
   using JDFPhaseTime = org.cip4.jdflib.resource.JDFPhaseTime;
   using JDFProcessRun = org.cip4.jdflib.resource.JDFProcessRun;
   using JDFResourceAudit = org.cip4.jdflib.resource.JDFResourceAudit;
   using EnumPartIDKey = org.cip4.jdflib.resource.JDFResource.EnumPartIDKey;

   //TODO add time related metadata

   ///
   /// <summary> * Utility class for status JDF and JMF
   /// * 
   /// * @author prosirai </summary>
   /// * @deprecated - use StatusCounter 
   /// 
   [Obsolete("- use StatusCounter")]
   public class StatusUtil
   {

      internal JDFNode m_Node;
      private JDFDoc docJMFPhaseTime;
      private JDFDoc docJMFResource;
      protected internal VJDFAttributeMap m_vPartMap;
      private string m_deviceID = null;
      private LinkAmount[] vLinkAmount = null;

      ///   
      ///	 <summary> * construct a StatusUtil for a node n
      ///	 *  </summary>
      ///	 * <param name="node"> the JDFNode that is being processed </param>
      ///	 * <param name="vPartMap"> the map of Parts that is being processed excluding the waste partition </param>
      ///	 * <param name="vResLinks"> the reslinks that are tracked for amount handling </param>
      ///	 
      public StatusUtil(JDFNode node, VJDFAttributeMap vPartMap, VElement vResLinks)
      {
         m_Node = node;
         m_vPartMap = vPartMap;
         if (m_vPartMap == null)
         {
            m_vPartMap = m_Node.getPartMapVector();
         }
         setUpResLinks(vResLinks);
      }

      ///   
      ///	 <summary> * get the matching AmountBag out of an array
      ///	 *  </summary>
      ///	 * <param name="refID"> the refID of the bag - this MUST match the refID of a ResourceLink </param>
      ///	 * <param name="bags"> the array of bags to search in </param>
      ///	 * <returns> the AmountBag with matching refID, null if none found or bags is null </returns>
      ///	 
      public static AmountBag getBag(string refID, AmountBag[] bags)
      {
         if (bags == null || refID == null)
         {
            return null;
         }
         for (int i = 0; i < bags.Length; i++)
         {
            if (bags[i].refID.Equals(refID))
            {
               return bags[i];
            }
         }
         return null;
      }

      ///   
      ///	 <summary> * get the matching LinkAmount out of this
      ///	 *  </summary>
      ///	 * <param name="refID"> the refID of the bag - this MUST match the refID of a ResourceLink </param>
      ///	 * <returns> the LinkAmount with matching refID, null if none found or bags is null </returns>
      ///	 
      public virtual LinkAmount getLinkAmount(string refID)
      {
         if (vLinkAmount == null || refID == null)
         {
            return null;
         }
         for (int i = 0; i < vLinkAmount.Length; i++)
         {
            if (vLinkAmount[i].rl.getrRef().Equals(refID))
            {
               return vLinkAmount[i];
            }
         }
         return null;
      }

      ///   
      ///	 <summary> * get the refID of the first resource, i.e. the Resource that is being tracked in status messages
      ///	 *  </summary>
      ///	 * <returns> the rRef of the prime resource link </returns>
      ///	 
      public virtual string getFirstRefID()
      {
         if (vLinkAmount == null || vLinkAmount.Length == 0)
         {
            return null;
         }
         return vLinkAmount[0].rl.getrRef();

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
      public virtual void setPhase(EnumNodeStatus nodeStatus, string nodeStatusDetails, EnumDeviceStatus deviceStatus, string deviceStatusDetails, AmountBag[] amounts)
      {
         docJMFPhaseTime = new JDFDoc(ElementName.JMF);
         JDFJMF jmf = docJMFPhaseTime.getJMFRoot();
         docJMFResource = new JDFDoc(ElementName.JMF);
         JDFJMF jmfRes = docJMFResource.getJMFRoot();

         AmountBag ab = getBag(getFirstRefID(), amounts);
         LinkAmount la = getLinkAmount(getFirstRefID());
         AmountBag lastAb = la == null ? null : la.lastBag;

         JDFAuditPool ap = m_Node.getCreateAuditPool();
         // TODO rethink when to send 2 phases
         JDFPhaseTime pt1 = ap.getLastPhase(m_vPartMap, null);
         JDFPhaseTime pt2 = pt1;
         bool bEnd = nodeStatus.Equals(EnumNodeStatus.Completed) || nodeStatus.Equals(EnumNodeStatus.Aborted);

         pt2 = ap.setPhase(nodeStatus, nodeStatusDetails, m_vPartMap, null);
         if (bEnd)
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

         if (pt1 != null && pt2 != pt1) // we explicitly added a new phasetime
         // audit, thus we need to add a closing
         // JMF for the original jobPhase
         {

            JDFSignal s = (JDFSignal)jmf.appendMessageElement(JDFMessage.EnumFamily.Signal, JDFMessage.EnumType.Status);
            JDFDeviceInfo deviceInfo = s.appendDeviceInfo();

            JDFJobPhase jp = deviceInfo.createJobPhaseFromPhaseTime(pt1);
            jp.setJobID(m_Node.getJobID(true));
            jp.setJobPartID(m_Node.getJobPartID(false));
            setJobPhaseAmounts(lastAb, jp);

            if (m_deviceID != null)
            {
               deviceInfo.setDeviceID(m_deviceID);
            }
         }

         if (pt2 != null)
         {
            JDFSignal s = (JDFSignal)jmf.appendMessageElement(JDFMessage.EnumFamily.Signal, JDFMessage.EnumType.Status);
            JDFDeviceInfo deviceInfo = s.appendDeviceInfo();
            if (!bEnd) // don't write a jobphase for an idle device
            {
               JDFJobPhase jp = deviceInfo.createJobPhaseFromPhaseTime(pt2);
               setJobPhaseAmounts(ab, jp);
            }

            deviceInfo.setDeviceStatus(deviceStatus);
            deviceInfo.setStatusDetails(deviceStatusDetails);
            deviceInfo.setDeviceID(m_deviceID);
            m_Node.setPartStatus(m_vPartMap, nodeStatus, null);
            getVResLink(amounts, 2); // update the nodes links

            generateResourceSignal(amounts, jmfRes);

            if (bEnd)
            {
               pt2.deleteNode(); // zapp the last phasetime
            }
            else
            {
               pt2.setLinks(getVResLink(amounts, 1));
               pt2.eraseEmptyAttributes(true);
            }
         }

         // cleanup!
         if (vLinkAmount != null)
         {
            for (int i = 0; i < vLinkAmount.Length; i++)
            {
               string refID = vLinkAmount[i].rl.getrRef();
               AmountBag bag = getBag(refID, amounts);
               vLinkAmount[i].lastBag = new AmountBag(bag);
            }
         }
         jmf.eraseEmptyAttributes(true);
      }

      ///   
      ///	 * <param name="amounts"> </param>
      ///	 * <param name="jmfRes"> </param>
      ///	 
      private void generateResourceSignal(AmountBag[] amounts, JDFJMF jmfRes)
      {
         if (amounts != null)
         {
            VElement vResResourceInfo = getVResLink(amounts, 3);

            JDFSignal sig = jmfRes.appendSignal(EnumType.Resource);
            JDFResourceQuParams rqp = sig.appendResourceQuParams();
            rqp.setJDF(m_Node);
            rqp.setExact(false);
            bool bAllExact = true;

            for (int i = 0; i < vResResourceInfo.Count; i++)
            {
               JDFResourceInfo ri = sig.appendResourceInfo();
               JDFResourceLink rl = (JDFResourceLink)vResResourceInfo[i];
               LinkAmount la = getLinkAmount(rl.getrRef());
               bool bExact = la.bCopyResInfo;
               bAllExact = bAllExact && bExact;
               rqp.setExact(bExact);
               ri.setLink(rl, rqp);
            }
            rqp.setExact(bAllExact);
         }
      }

      ///   
      ///	 * <param name="lastAb"> </param>
      ///	 * <param name="jp"> </param>
      ///	 
      private void setJobPhaseAmounts(AmountBag lastAb, JDFJobPhase jp)
      {
         if (lastAb == null)
         {
            return;
         }

         LinkAmount la = getLinkAmount(lastAb.refID);
         if (la == null)
         {
            return;
         }

         if (la.bTrackWaste)
         {
            if (lastAb.phaseAmount != 0)
            {
               jp.setPhaseAmount(lastAb.phaseAmount);
            }
            if (lastAb.totalAmount != 0)
            {
               jp.setAmount(lastAb.totalAmount);
            }
            if (lastAb.phaseWaste != 0)
            {
               jp.setPhaseWaste(lastAb.phaseWaste);
            }
            if (lastAb.totalWaste != 0)
            {
               jp.setWaste(lastAb.totalWaste);
            }
         }
         else
         {
            if ((lastAb.phaseAmount + lastAb.phaseWaste) != 0)
            {
               jp.setPhaseAmount(lastAb.phaseAmount + lastAb.phaseWaste);
            }
            if ((lastAb.totalAmount + lastAb.totalWaste) != 0)
            {
               jp.setAmount(lastAb.totalAmount + lastAb.totalWaste);
            }

         }
         double total = 0;

         total = la.startAmount;
         if (total != 0)
         {
            jp.setTotalAmount(total);
            jp.setPercentCompleted(lastAb.totalAmount / total * 100.0);
         }
      }

      ///   
      ///	 * <param name="resLink">
      ///	 * @return </param>
      ///	 
      private VElement getVResLink(AmountBag[] amounts, int n)
      {
         if (amounts == null && vLinkAmount == null)
         {
            return null;
         }
         if (vLinkAmount == null || amounts == null || vLinkAmount.Length != amounts.Length)
         {
            throw new JDFException("incoherent resLink sizes");
         }
         VElement vRet = new VElement();
         for (int i = 0; i < vLinkAmount.Length; i++)
         {
            LinkAmount la = vLinkAmount[i];
            if (n == 1)
            {
               vRet.Add(la.getPhaseTimeLink(getBag(la.rl.getrRef(), amounts)));
            }
            if (n == 2)
            {
               vRet.Add(la.updateNodeLink(getBag(la.rl.getrRef(), amounts)));
            }
            if (n == 3)
            {
               vRet.Add(la.getResourceInfoLink(getBag(la.rl.getrRef(), amounts)));
            }
         }
         return vRet;
      }

      ///   
      ///	 * <returns> the docJMFPhaseTime </returns>
      ///	 
      public virtual JDFDoc getDocJMFPhaseTime()
      {
         return docJMFPhaseTime;
      }

      ///   
      ///	 * <returns> the docJMFResource </returns>
      ///	 
      public virtual JDFDoc getDocJMFResource()
      {
         return docJMFResource;
      }

      //
      ///   
      ///	 <summary> * container class to set amounts and waste in phaseTime </summary>
      ///	 
      public class AmountBag
      {
         ///      
         ///		 <summary> * refID of the resourceLink to set </summary>
         ///		 
         public string refID;
         public double totalAmount;
         public double phaseAmount;
         public double totalWaste;
         public double phaseWaste;

         public override string ToString()
         {
            return "[AmountBag refID=" + refID + " totalAmount=" + totalAmount + " phaseAmount=" + phaseAmount + " totalWaste=" + totalWaste + " phaseWaste=" + phaseWaste + " ]";
         }

         ///      
         ///		 <summary> *  </summary>
         ///		 * <param name="rl"> resourceLink to the resource that is being counted </param>
         ///		 
         public AmountBag(JDFResourceLink rl)
            : this(rl.getrRef())
         {
         }

         ///      
         ///		 <summary> *  </summary>
         ///		 * <param name="_refID"> refID of the resource that is being counted </param>
         ///		 
         public AmountBag(string _refID)
         {
            refID = _refID;
            reset();
         }

         ///      
         ///         <summary> * </summary>
         ///         
         public virtual void reset()
         {
            totalAmount = 0;
            phaseAmount = 0;
            totalWaste = 0;
            phaseWaste = 0;
         }

         ///      
         ///		 <summary> * copy ctor
         ///		 *  </summary>
         ///		 * <param name="bag"> </param>
         ///		 
         public AmountBag(AmountBag bag)
         {
            refID = bag.refID;
            totalAmount = bag.totalAmount;
            phaseAmount = bag.phaseAmount;
            totalWaste = bag.totalWaste;
            phaseWaste = bag.phaseWaste;
         }

         ///      
         ///		 * <param name="iLoop"> </param>
         ///		 * <param name="j"> </param>
         ///		 * <param name="b"> </param>
         ///		 
         public virtual void addPhase(double amount, double waste, bool bNewPhase)
         {
            totalAmount += amount;
            totalWaste += waste;
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
         }
      }

      //

      public class LinkAmount
      {
         internal double startAmount = 0;
         internal double startWaste = 0;
         internal JDFResourceLink rl;
         internal AmountBag lastBag;
         public bool bTrackWaste = false;
         public bool bCopyResInfo = false;
         private StatusUtil enclosingInstance;

         internal LinkAmount(StatusUtil pEnclosingInstance, JDFResourceLink _rl)
         {
            enclosingInstance = pEnclosingInstance;

            JDFNode dump = new JDFDoc("JDF").getJDFRoot();
            dump.appendResourceLinkPool().copyElement(_rl, null);
            dump.appendResourcePool().copyElement(_rl.getTarget(), null);
            rl = (JDFResourceLink)dump.getResourceLinkPool().getElement(_rl.Name, null, 0);
            JDFAttributeMap map = (enclosingInstance.m_vPartMap == null || enclosingInstance.m_vPartMap.Count == 0) ? null : enclosingInstance.m_vPartMap[0];
            startAmount = rl.getAmount(map);
            if (startAmount == -1)
            {
               map = new JDFAttributeMap(map);
               map.put(EnumPartIDKey.Condition, "Good");
               startAmount = rl.getAmount(map);
               if (startAmount == -1)
               {
                  startAmount = 0;
               }
               map.put(EnumPartIDKey.Condition, "Waste");
               startWaste = rl.getAmount(map);
               if (startWaste == -1)
               {
                  startWaste = 0;
               }
            }
         }

         ///      
         ///		 * <param name="bag">
         ///		 * @return </param>
         ///		 
         public virtual JDFResourceLink updateNodeLink(AmountBag bag)
         {
            JDFResourceLink nodeLink = enclosingInstance.m_Node.getLink(0, null, new JDFAttributeMap(AttributeName.RREF, rl.getrRef()), null);
            if (bag != null)
            {
               VJDFAttributeMap vMap = new VJDFAttributeMap(enclosingInstance.m_vPartMap);
               if (vMap.Count == 0)
               {
                  vMap.Add(new JDFAttributeMap());
               }
               if (nodeLink != null)
               {
                  if (bTrackWaste)
                  {
                     vMap.put(EnumPartIDKey.Condition, "Good");
                     nodeLink.setAmountPoolAttribute(AttributeName.ACTUALAMOUNT, StringUtil.formatDouble(bag.totalAmount), null, vMap);
                     vMap.put(EnumPartIDKey.Condition, "Waste");
                     nodeLink.setAmountPoolAttribute(AttributeName.ACTUALAMOUNT, StringUtil.formatDouble(bag.totalWaste), null, vMap);
                  }
                  else
                  {
                     nodeLink.setAmountPoolAttribute(AttributeName.ACTUALAMOUNT, StringUtil.formatDouble(bag.totalAmount + bag.totalWaste), null, vMap);
                  }
               }
            }
            return nodeLink;
         }

         ///      
         ///		 <summary> * @return </summary>
         ///		 
         public virtual JDFResourceLink getPhaseTimeLink(AmountBag bag)
         {
            cleanAmounts();
            if (bag != null)
            {
               VJDFAttributeMap vMap = new VJDFAttributeMap(enclosingInstance.m_vPartMap);
               if (vMap.Count == 0)
               {
                  vMap.Add(new JDFAttributeMap());
               }
               if (bTrackWaste)
               {
                  vMap.put(EnumPartIDKey.Condition, "Good");
                  if (bag.phaseAmount != 0)
                  {
                     rl.setAmountPoolAttribute(AttributeName.ACTUALAMOUNT, StringUtil.formatDouble(bag.phaseAmount), null, vMap);
                  }
                  if (startAmount != 0)
                  {
                     rl.setAmountPoolAttribute(AttributeName.AMOUNT, StringUtil.formatDouble(startAmount), null, vMap);
                  }
                  vMap.put(EnumPartIDKey.Condition, "Waste");
                  if (bag.phaseWaste != 0)
                  {
                     rl.setAmountPoolAttribute(AttributeName.ACTUALAMOUNT, StringUtil.formatDouble(bag.phaseWaste), null, vMap);
                  }
                  if (startWaste != 0)
                  {
                     rl.setAmountPoolAttribute(AttributeName.AMOUNT, StringUtil.formatDouble(startWaste), null, vMap);
                  }
               }
               else
               {
                  if (bag.phaseAmount + bag.phaseWaste != 0)
                  {
                     rl.setAmountPoolAttribute(AttributeName.ACTUALAMOUNT, StringUtil.formatDouble(bag.phaseAmount + bag.phaseWaste), null, vMap);
                  }
                  if (startAmount + startWaste != 0)
                  {
                     rl.setAmountPoolAttribute(AttributeName.AMOUNT, StringUtil.formatDouble(startAmount + startWaste), null, vMap);
                  }
               }
            }
            return rl;
         }

         ///      
         ///		 <summary> * @return </summary>
         ///		 
         public virtual JDFResourceLink getResourceAuditLink(AmountBag bag)
         {
            cleanAmounts();
            if (bag != null)
            {
               VJDFAttributeMap vMap = new VJDFAttributeMap(enclosingInstance.m_vPartMap);
               if (vMap.Count == 0)
               {
                  vMap.Add(new JDFAttributeMap());
               }
               if (bTrackWaste)
               {
                  vMap.put(EnumPartIDKey.Condition, "Good");
                  if (bag.totalAmount != 0)
                  {
                     rl.setAmountPoolAttribute(AttributeName.ACTUALAMOUNT, StringUtil.formatDouble(bag.totalAmount), null, vMap);
                  }
                  if (startAmount != 0)
                  {
                     rl.setAmountPoolAttribute(AttributeName.AMOUNT, StringUtil.formatDouble(startAmount), null, vMap);
                  }
                  vMap.put(EnumPartIDKey.Condition, "Waste");
                  if (bag.totalWaste != 0)
                  {
                     rl.setAmountPoolAttribute(AttributeName.ACTUALAMOUNT, StringUtil.formatDouble(bag.totalWaste), null, vMap);
                  }
                  if (startWaste != 0)
                  {
                     rl.setAmountPoolAttribute(AttributeName.AMOUNT, StringUtil.formatDouble(startWaste), null, vMap);
                  }
               }
               else
               {
                  if (bag.totalAmount + bag.totalWaste != 0)
                  {
                     rl.setAmountPoolAttribute(AttributeName.ACTUALAMOUNT, StringUtil.formatDouble(bag.totalAmount + bag.totalWaste), null, vMap);
                  }
                  if (startAmount + startWaste != 0)
                  {
                     rl.setAmountPoolAttribute(AttributeName.AMOUNT, StringUtil.formatDouble(startAmount + startWaste), null, vMap);
                  }
               }
            }
            return rl;
         }

         ///      
         ///		 <summary> * @return </summary>
         ///		 
         public virtual JDFResourceLink getResourceInfoLink(AmountBag bag)
         {
            cleanAmounts();
            if (bag != null)
            {
               VJDFAttributeMap vMap = new VJDFAttributeMap(enclosingInstance.m_vPartMap);
               if (vMap.Count == 0)
               {
                  vMap.Add(new JDFAttributeMap());
               }
               if (bTrackWaste)
               {
                  vMap.put(EnumPartIDKey.Condition, "Good");
                  if (bag.totalAmount != 0)
                  {
                     rl.setAmountPoolAttribute(AttributeName.ACTUALAMOUNT, StringUtil.formatDouble(bag.totalAmount), null, vMap);
                  }
                  if (startAmount != 0)
                  {
                     rl.setAmountPoolAttribute(AttributeName.AMOUNT, StringUtil.formatDouble(startAmount), null, vMap);
                  }
                  vMap.put(EnumPartIDKey.Condition, "Waste");
                  if (bag.totalWaste != 0)
                  {
                     rl.setAmountPoolAttribute(AttributeName.ACTUALAMOUNT, StringUtil.formatDouble(bag.totalWaste), null, vMap);
                  }
                  if (startWaste != 0)
                  {
                     rl.setAmountPoolAttribute(AttributeName.AMOUNT, StringUtil.formatDouble(startWaste), null, vMap);
                  }
               }
               else
               {
                  if (bag.totalAmount + bag.totalWaste != 0)
                  {
                     rl.setAmountPoolAttribute(AttributeName.ACTUALAMOUNT, StringUtil.formatDouble(bag.totalAmount + bag.totalWaste), null, vMap);
                  }
                  if (startAmount + startWaste != 0)
                  {
                     rl.setAmountPoolAttribute(AttributeName.AMOUNT, StringUtil.formatDouble(startAmount + startWaste), null, vMap);
                  }
               }
            }
            return rl;
         }

         ///      
         ///		 * <param name="rl2"> </param>
         ///		 
         private void cleanAmounts()
         {
            rl.removeAttribute(AttributeName.AMOUNT);
            rl.removeAttribute(AttributeName.ACTUALAMOUNT);
            rl.removeChild(ElementName.AMOUNTPOOL, null, 0);
         }

      }

      //   
      //	 * @return the m_deviceID
      //	 
      public virtual string getDeviceID()
      {
         return m_deviceID;
      }

      ///   
      ///	 * <param name="m_deviceid"> the m_deviceID to set </param>
      ///	 
      public virtual void setDeviceID(string deviceid)
      {
         m_deviceID = deviceid;
      }

      ///   
      ///	 <summary> * set waste tracking on or off for the resourcelink rl
      ///	 *  </summary>
      ///	 * <param name="rl"> the resourcelink to the resource to track </param>
      ///	 * <param name="b"> tracking on or off </param>
      ///	 
      public virtual void setTrackWaste(JDFResourceLink rl, bool b)
      {
         LinkAmount la = getLinkAmount(rl.getrRef());
         if (la != null)
         {
            la.bTrackWaste = b;
         }
      }

      ///   
      ///	 <summary> * set copying the resource into resourceInfo on or off for the resourcelink rl
      ///	 *  </summary>
      ///	 * <param name="rl"> the resourcelink to the resource to copy </param>
      ///	 * <param name="b"> tracking on or off </param>
      ///	 
      public virtual void setCopyResInResInfo(JDFResourceLink rl, bool b)
      {
         LinkAmount la = getLinkAmount(rl.getrRef());
         if (la != null)
         {
            la.bCopyResInfo = b;
         }
      }

      ///   
      ///	 * <param name="bag"> </param>
      ///	 * <returns> JDFResourceAudit the generated audit </returns>
      ///	 
      public virtual JDFResourceAudit setResourceAudit(AmountBag bag, EnumReason reason)
      {
         JDFAuditPool ap = m_Node.getCreateAuditPool();

         JDFResourceAudit ra = ap.addResourceAudit(null);
         ra.setContentsModified(false);
         ra.setReason(reason);

         LinkAmount la = getLinkAmount(bag.refID);
         ra.copyElement(la.getResourceAuditLink(bag), null);
         ra.setPartMapVector(m_vPartMap);

         return ra;
      }

      ///   
      ///     <summary> * </summary>
      ///     
      public virtual JDFProcessRun setProcessResult(EnumNodeStatus endStatus)
      {
         JDFAuditPool ap = m_Node.getCreateAuditPool();

         JDFProcessRun pr = ap.addProcessRun(endStatus, null, m_vPartMap);
         return pr;

      }
   }
}
