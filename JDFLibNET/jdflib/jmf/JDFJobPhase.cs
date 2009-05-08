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
 * class JDFJobPhase extends JDFResource
 * ==========================================================================
 * @COPYRIGHT Heidelberger Druckmaschinen AG, 1999-2001
 * ALL RIGHTS RESERVED
 * @Author: sabjon@topmail.de   using a code generator
 * Warning! very preliminary test version. Interface subject to change without prior notice!
 * Revision history:    ... 
 */

namespace org.cip4.jdflib.jmf
{


   using JDFAutoJobPhase = org.cip4.jdflib.auto.JDFAutoJobPhase;
   using EnumQueueEntryStatus = org.cip4.jdflib.auto.JDFAutoQueueEntry.EnumQueueEntryStatus;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using KElement = org.cip4.jdflib.core.KElement;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using INodeIdentifiable = org.cip4.jdflib.ifaces.INodeIdentifiable;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using NodeIdentifier = org.cip4.jdflib.node.JDFNode.NodeIdentifier;
   using JDFModulePhase = org.cip4.jdflib.resource.JDFModulePhase;
   using JDFModuleStatus = org.cip4.jdflib.resource.JDFModuleStatus;
   using ContainerUtil = org.cip4.jdflib.util.ContainerUtil;
   using JDFDate = org.cip4.jdflib.util.JDFDate;

   //----------------------------------
   ///
   /// <summary> * describes the actual status of jobs in a device
   /// *  </summary>
   /// * Note that the old EnumStatus local class has been move to <seealso cref= JDFNode.EnumNodeStatus </seealso>
   /// 
   public class JDFJobPhase : JDFAutoJobPhase, INodeIdentifiable
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFJobPhase
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFJobPhase(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFJobPhase
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFJobPhase(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFJobPhase
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFJobPhase(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      ///   
      ///	 <summary> * toString()
      ///	 *  </summary>
      ///	 * <seealso cref= org.cip4.jdflib.auto.JDFAutoJobPhase#toString() </seealso>
      ///	 * <returns> String </returns>
      ///	 
      public override string ToString()
      {
         return "JDFJobPhase[  --> " + base.ToString() + " ]";
      }

      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[1];
      static JDFJobPhase()
      {
         elemInfoTable[0] = new ElemInfoTable(ElementName.JDF, 0x33333333);
      }

      protected internal override ElementInfo getTheElementInfo()
      {
         return new ElementInfo(base.getTheElementInfo(), elemInfoTable);
      }

      ///   
      ///	 <summary> * Returns detailed status information.
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public override string getStatusDetails()
      {
         return getAttribute(AttributeName.STATUSDETAILS);
      }

      ///   
      ///	 <summary> * Method getQueueEntryID.
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public override string getQueueEntryID()
      {
         return getInheritedStatusQuParamsAttribute(AttributeName.QUEUEENTRYID, null);
      }

      ///   
      ///	 <summary> * Method getJobID.
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public override string getJobID()
      {
         return getInheritedStatusQuParamsAttribute(AttributeName.JOBID, null);
      }

      ///   
      ///	 <summary> * Method getJobID.
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public override string getJobPartID()
      {
         return getInheritedStatusQuParamsAttribute(AttributeName.JOBPARTID, null);
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
      ///	 <summary> * set all parts to those defined in vParts
      ///	 *  </summary>
      ///	 * <param name="vParts"> vector of attribute maps for the parts </param>
      ///	 
      public override void setPartMapVector(VJDFAttributeMap vParts)
      {
         base.setPartMapVector(vParts);
      }

      ///   
      ///	 <summary> * set part to the one defined in mPart
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
      ///	 <summary> * check whether the part defined in mPart is included
      ///	 *  </summary>
      ///	 * <param name="mPart"> attribute map for the part to remove </param>
      ///	 * <returns> boolean - returns true if the part exists </returns>
      ///	 
      public override bool hasPartMap(JDFAttributeMap mPart)
      {
         return base.hasPartMap(mPart);
      }

      ///   
      ///	 <summary> * get a node, create if it doesn't exist
      ///	 *  </summary>
      ///	 * <returns> the node </returns>
      ///	 
      public virtual JDFNode getCreateNode()
      {
         return (JDFNode)getCreateElement_KElement(ElementName.JDF, null, 0);
      }

      ///   
      ///	 <summary> * append a node
      ///	 *  </summary>
      ///	 * <returns> the appended node </returns>
      ///	 
      public virtual JDFNode appendNode()
      {
         return (JDFNode)appendElementN(ElementName.JDF, 1, null);
      }

      ///   
      ///	 <summary> * apply all values of a JDF Node to this </summary>
      ///	 * <param name="node"> the node to apply </param>
      ///	 
      public virtual void applyNode(JDFNode node)
      {
         NodeIdentifier ni = node == null ? new NodeIdentifier() : node.getIdentifier();

         setIdentifier(ni);
         if (node != null)
         {
            JDFNode.EnumActivation activation = node.getActivation(true);
            if (activation != null)
               setActivation(EnumActivation.getEnum(activation.getName()));
            VJDFAttributeMap vMap = ni.getPartMapVector();
            setStatus(node.getVectorPartStatus(vMap));
            setStatusDetails(node.getVectorPartStatusDetails(vMap));
         }
      }

      ///   
      ///	 <summary> * get node
      ///	 *  </summary>
      ///	 * <returns> the node </returns>
      ///	 
      public virtual JDFNode getNode()
      {
         return (JDFNode)getElement(ElementName.JDF, null, 0);
      }

      ///   
      ///	 <summary> * get the <seealso cref="JDFStatusQuParams"/> that apply to the jobphase
      ///	 * 
      ///	 * @return </summary>
      ///	 
      public virtual JDFStatusQuParams getStatusQuParams()
      {
         KElement parent = getParentNode_KElement();
         if (!(parent is JDFDeviceInfo))
            return null;
         parent = parent.getParentNode_KElement();
         if (!(parent is JDFMessage))
            return null;
         return ((JDFMessage)parent).getStatusQuParams();

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
      ///	 * <seealso cref= org.cip4.jdflib.ifaces.INodeIdentifiable#setIdentifier(org.cip4.jdflib.node.JDFNode.NodeIdentifier) </seealso>
      ///	 * <param name="ni"> </param>
      ///	 
      public virtual void setIdentifier(NodeIdentifier ni)
      {
         NodeIdentifier niLocal = ni;

         if (niLocal == null)
            niLocal = new NodeIdentifier();

         setJobID(niLocal.getJobID());
         setJobPartID(niLocal.getJobPartID());
         setPartMapVector(niLocal.getPartMapVector());
      }

      private string getInheritedStatusQuParamsAttribute(string key, string nameSpaceURI)
      {
         string val = getAttribute(key, nameSpaceURI, null);
         if (val != null)
            return val;
         JDFStatusQuParams sqp = getStatusQuParams();
         if (sqp == null)
            return null;
         return sqp.getAttribute(key, nameSpaceURI, null);
      }

      ///   
      ///	 <summary> * creates a new ModuleStatus in this based on the values in mp generally used to create messages from audits
      ///	 *  </summary>
      ///	 * <param name="mp"> the modulephase to copy </param>
      ///	 * <returns> the new ModuleStatus element
      ///	 *  </returns>
      ///	 
      public virtual JDFModuleStatus createModuleStatusFromModulePhase(JDFModulePhase mp)
      {
         if (mp == null)
            return null;
         JDFModuleStatus ms = appendModuleStatus();
         ms.copyAttribute(AttributeName.MODULETYPE, mp);
         ms.copyAttribute(AttributeName.MODULEINDEX, mp);
         ms.copyAttribute(AttributeName.MODULEID, mp);

         return ms;
      }

      ///   
      ///	 <summary> * return the differential amount produced between this phase and lastphase
      ///	 *  </summary>
      ///	 * <param name="lastphase"> the phase
      ///	 * @return </param>
      ///	 
      public virtual double getAmountDifference(JDFJobPhase lastphase)
      {
         if (isSamePhase(lastphase, true))
         {
            return getPhaseAmount() - lastphase.getPhaseAmount();
         }
         return getPhaseAmount();
      }

      ///   
      ///	 <summary> * return the differential waste amount produced between this phase and lastphase
      ///	 *  </summary>
      ///	 * <param name="lastphase">
      ///	 * @return </param>
      ///	 
      public virtual double getWasteDifference(JDFJobPhase lastphase)
      {
         if (isSamePhase(lastphase, true))
         {
            return getPhaseWaste() - lastphase.getPhaseWaste();
         }
         return getPhaseWaste();
      }

      ///   
      ///	 <summary> * returns true if this is the same phase, i.e. the
      ///	 *  </summary>
      ///	 * <param name="lastphase"> the phase to compare with </param>
      ///	 * <param name="bExact"> if true, use startTime as hook, else compare stati
      ///	 * @return </param>
      ///	 
      public virtual bool isSamePhase(JDFJobPhase lastphase, bool bExact)
      {
         if (lastphase == null)
            return false;
         if (bExact)
         {
            JDFDate startTime = getPhaseStartTime();
            JDFDate lastStartTime = lastphase.getPhaseStartTime();
            return startTime != null && startTime.Equals(lastStartTime);
         }
         if (!ContainerUtil.Equals(getStatus(), lastphase.getStatus()))
            return false;
         if (!ContainerUtil.Equals(getStatusDetails(), lastphase.getStatusDetails()))
            return false;
         if (!ContainerUtil.Equals(getIdentifier(), lastphase.getIdentifier()))
            return false;
         return true;
      }

      ///   
      ///	 <summary> * creates a new phasetime that spans lastphase and this phase
      ///	 *  </summary>
      ///	 * <param name="lastphase"> the phase to merge </param>
      ///	 * <returns> true if successful </returns>
      ///	 
      public virtual bool mergeLastPhase(JDFJobPhase lastphase)
      {
         if (!isSamePhase(lastphase, false))
            return false;
         setStartTime(lastphase.getStartTime());
         setPhaseAmount(getPhaseAmount() + lastphase.getPhaseAmount());
         setPhaseWaste(getPhaseWaste() + lastphase.getPhaseWaste());
         return true;
      }

      ///   
      ///	 <summary> * returns the phase amount, defaults to amount if not specified </summary>
      ///	 
      public override double getPhaseAmount()
      {
         if (hasAttribute(AttributeName.PHASEAMOUNT))
            return base.getPhaseAmount();
         return base.getAmount();
      }

      ///   
      ///	 <summary> * returns the phase starttime, defaults to starttime if not specified </summary>
      ///	 
      public override JDFDate getPhaseStartTime()
      {
         if (hasAttribute(AttributeName.PHASESTARTTIME))
            return base.getPhaseStartTime();
         return base.getStartTime();
      }

      ///   
      ///	 <summary> * returns the phase waste amount, defaults to waste if not specified </summary>
      ///	 
      public override double getPhaseWaste()
      {
         if (hasAttribute(AttributeName.PHASEWASTE))
            return base.getPhaseWaste();
         return base.getWaste();
      }

      ///   
      ///	 * <returns> the queueentry status that corresponds to the status of this </returns>
      ///	 
      public virtual EnumQueueEntryStatus getQueueEntryStatus()
      {
         return EnumNodeStatus.getQueueEntryStatus(getStatus());
      }
   }
}
