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



namespace org.cip4.jdflib.goldenticket
{
   using System;
   using System.Collections.Generic;


   using EnumComponentType = org.cip4.jdflib.auto.JDFAutoComponent.EnumComponentType;
   using EnumWorkStyle = org.cip4.jdflib.auto.JDFAutoConventionalPrintingParams.EnumWorkStyle;
   using EnumDeviceStatus = org.cip4.jdflib.auto.JDFAutoDeviceInfo.EnumDeviceStatus;
   using EnumMediaType = org.cip4.jdflib.auto.JDFAutoMedia.EnumMediaType;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFAudit = org.cip4.jdflib.core.JDFAudit;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFNodeInfo = org.cip4.jdflib.core.JDFNodeInfo;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using JDFSeparationList = org.cip4.jdflib.core.JDFSeparationList;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using EnumAuditType = org.cip4.jdflib.core.JDFAudit.EnumAuditType;
   using EnumNodeStatus = org.cip4.jdflib.core.JDFElement.EnumNodeStatus;
   using EnumVersion = org.cip4.jdflib.core.JDFElement.EnumVersion;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using JDFCMYKColor = org.cip4.jdflib.datatypes.JDFCMYKColor;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using EnumProcessUsage = org.cip4.jdflib.node.JDFNode.EnumProcessUsage;
   using EnumType = org.cip4.jdflib.node.JDFNode.EnumType;
   using JDFAuditPool = org.cip4.jdflib.pool.JDFAuditPool;
   using JDFDevice = org.cip4.jdflib.resource.JDFDevice;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFStrippingParams = org.cip4.jdflib.resource.JDFStrippingParams;
   using EnumPartIDKey = org.cip4.jdflib.resource.JDFResource.EnumPartIDKey;
   using EnumPartUsage = org.cip4.jdflib.resource.JDFResource.EnumPartUsage;
   using EnumResStatus = org.cip4.jdflib.resource.JDFResource.EnumResStatus;
   using JDFColor = org.cip4.jdflib.resource.process.JDFColor;
   using JDFColorPool = org.cip4.jdflib.resource.process.JDFColorPool;
   using JDFColorantControl = org.cip4.jdflib.resource.process.JDFColorantControl;
   using JDFComponent = org.cip4.jdflib.resource.process.JDFComponent;
   using JDFExposedMedia = org.cip4.jdflib.resource.process.JDFExposedMedia;
   using JDFLayout = org.cip4.jdflib.resource.process.JDFLayout;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;
   using JDFRunList = org.cip4.jdflib.resource.process.JDFRunList;
   using EnumUtil = org.cip4.jdflib.util.EnumUtil;
   using JDFDate = org.cip4.jdflib.util.JDFDate;
   using StatusCounter = org.cip4.jdflib.util.StatusCounter;
   using UrlUtil = org.cip4.jdflib.util.UrlUtil;

   ///
   /// <summary> * @author prosirai class that generates golden tickets based on ICS levels etc basegolden ticket should generally be
   /// *         the last in the cascade domain - mis - jmf - base
   /// * 
   /// *         To generate a new golden ticket, follow these steps 1.) construct the appropriate domain subclass, e.g.
   /// *         MISCPGoldenTicket for mis to conventional print 2.) call .assign(null) (or your favorite hand-coded jdf node)
   /// *         3.) retrieve the updated copy with .getNode()
   /// *  </summary>
   /// 
   public class BaseGoldenTicket
   {
      protected internal VString amountLinks = null;
      protected internal JDFNode theNode = null;
      protected internal JDFNode theExpandedNode = null;
      protected internal JDFNode thePreviousNode = null;
      protected internal JDFNode theParentNode = null;
      public JDFNode theParentProduct = null;
      protected internal EnumVersion theVersion = null;
      protected internal int baseICSLevel;
      protected internal StatusCounter theStatusCounter;
      public static string misURL = null;
      public static string deviceURL = null;
      private readonly List<BaseGoldenTicket> vKids = new List<BaseGoldenTicket>();
      public VJDFAttributeMap vParts = null;
      public VString cols = new VString("Black,Cyan,Magenta,Yellow,Spot1,Spot2,Spot3,Spot4", ",");
      public VString colsActual = new VString("Schwarz,Cyan,Magenta,Gelb,RIP 4711,RIP 4712,RIP 4713,RIP 4714", ",");
      public int[] nCols = { 0, 0 };
      protected internal VString partIDKeys = null;
      public EnumWorkStyle workStyle = EnumWorkStyle.Simplex;
      public string devID = "DeviceID";
      ///   
      ///	 <summary> * good for plan and execute </summary>
      ///	 
      public int good = 1000;
      ///   
      ///	 <summary> * pwaste for plan and execute </summary>
      ///	 
      public int waste = 100;
      public int partsAtOnce = 0; // 0 = all
      public int partsForAvailable = 1; // 1=1 loop and all is available
      public bool bExpandGrayBox = true;
      public bool bPartitionedPlateMedia = false;
      public JDFMedia paperMedia;
      ///   
      ///	 <summary> * if set, the returnURL will be initialized </summary>
      ///	 
      public string returnURL = null;
      public bool getNIFromParent = false;
      ///   
      ///     <summary> *  </summary>
      ///     
      public string m_pdfFile = "file:///here/file.pdf";

      ///   
      ///	 <summary> * create a BaseGoldenTicket
      ///	 *  </summary>
      ///	 * <param name="icsLevel"> the level to init to (1,2 or 3) </param>
      ///	 * <param name="jdfVersion"> the version to generate a golden ticket for </param>
      ///	 
      public BaseGoldenTicket(int icsLevel, EnumVersion jdfVersion)
      {
         baseICSLevel = icsLevel;
         theVersion = jdfVersion == null ? EnumVersion.Version_1_3 : jdfVersion;
         theStatusCounter = new StatusCounter(null, null, null);
         JDFElement.setLongID(false);
      }

      ///   
      ///	 <summary> * create a BaseGoldenTicket
      ///	 *  </summary>
      ///	 * <param name="parent">
      ///	 *  </param>
      ///	 
      public BaseGoldenTicket(BaseGoldenTicket parent)
      {
         baseICSLevel = parent.baseICSLevel;
         theVersion = parent.theVersion;
         theStatusCounter = new StatusCounter(null, null, null);
         bExpandGrayBox = parent.bExpandGrayBox;
         bPartitionedPlateMedia = parent.bPartitionedPlateMedia;
         cols = new VString(parent.cols);
         colsActual = new VString(parent.colsActual);
         nCols = parent.nCols;
         devID = parent.devID;
         good = parent.good;
         waste = parent.waste;
         paperMedia = parent.paperMedia;
         partsAtOnce = parent.partsAtOnce;
         theParentNode = parent.getNode();
         vParts = new VJDFAttributeMap(parent.vParts);
         partIDKeys = new VString(parent.partIDKeys);
         workStyle = parent.workStyle;
         JDFElement.setLongID(false);
         parent.addKid(this);
      }

      ///   
      ///	 * <param name="icsLevel"> </param>
      ///	 
      protected internal virtual JDFNodeInfo initNodeInfo()
      {

         JDFNodeInfo ni = getNIFromParent && theParentNode != null ? theParentNode.getNodeInfo() : null;
         if (ni == null)
         {
            ni = theNode.getCreateNodeInfo();
            ni.setResStatus(EnumResStatus.Available, false);
         }
         else
            theNode.linkResource(ni, EnumUsage.Input, null);

         if (returnURL != null)
            ni.setTargetRoute(returnURL);
         return ni;
      }

      ///   
      ///	 <summary> * assign a node to this golden ticket instance
      ///	 *  </summary>
      ///	 * <param name="node"> the node to assign, if null a new conforming node is generated from scratch </param>
      ///	 
      public virtual void assign(JDFNode node)
      {
         vKids.Clear();
         vKids.Add(this);
         theNode = node == null ? new JDFDoc("JDF").getJDFRoot() : node;
         theExpandedNode = theNode;
         if (theNode.getParentJDF() != null)
            theParentNode = theNode.getParentJDF();
         theParentProduct = theParentNode;
         while (theParentProduct != null && !EnumType.Product.Equals(theParentProduct.getEnumType()))
            theParentProduct = theParentProduct.getParentJDF();
         setVersion();
         init();
      }

      ///   
      ///	 <summary> * assign a previous node to this golden ticket instance, e.g. an imagesetting node
      ///	 *  </summary>
      ///	 * <param name="node"> the node to assign, if null a new conforming node is generated from scratch </param>
      ///	 
      public virtual void setPreviousNode(JDFNode node)
      {
         thePreviousNode = node;
      }

      ///   
      ///	 <summary> * add a kid to be makeready and executed
      ///	 *  </summary>
      ///	 * <param name="node"> the node to assign, if null a new conforming node is generated from scratch </param>
      ///	 
      public virtual void addKid(BaseGoldenTicket bt)
      {
         if (!vKids.Contains(bt))
            vKids.Add(bt);
      }

      ///   
      ///	 <summary> * makeready for all kids
      ///	 *  </summary>
      ///	 

      public virtual void makeReadyAll()
      {
         for (int i = 0; i < vKids.Count; i++)
            vKids[i].makeReady();
      }

      ///   
      ///	 <summary> * simulate makeReady of this node the internal node will be modified to reflect the makeready all required
      ///	 * resources should be available </summary>
      ///	 
      public virtual void makeReady()
      {

         if (bExpandGrayBox && EnumType.ProcessGroup.Equals(theNode.getEnumType()) && theNode.hasAttribute(AttributeName.TYPES))
         {
            theExpandedNode = theNode.addCombined(theNode.getTypes());
            VElement resLinks = theNode.getResourceLinks(null);
            if (resLinks != null)
            {
               int size = resLinks.Count;
               for (int i = 0; i < size; i++)
                  ((JDFResourceLink)resLinks[i]).removeAttribute(AttributeName.COMBINEDPROCESSINDEX);
            }

            initAuditPool(theExpandedNode);
            theExpandedNode.copyElement(theNode.getResourceLinkPool(), null);
         }
         else
         {
            theExpandedNode = theNode;
         }
         VElement nodeLinks = getNodeLinks();
         theStatusCounter.setActiveNode(theExpandedNode, null, nodeLinks);

         VElement vResLinks = theExpandedNode.getResourceLinks(null);
         if (vResLinks != null)
         {
            int siz = vResLinks.Count;
            for (int i = 0; i < siz; i++)
            {
               JDFResourceLink rl = (JDFResourceLink)vResLinks[i];

               if (EnumUsage.Input.Equals(rl.getUsage()))
               {
                  VElement vRes = rl.getTargetVector(-1);
                  for (int j = 0; j < vRes.Count; j++)
                  {
                     VElement leaves = ((JDFResource)vRes[j]).getLeaves(false);
                     for (int k = 0; k < leaves.Count; k++)
                     {
                        JDFResource r = (JDFResource)leaves[k];
                        r.setResStatus(EnumResStatus.Available, true);
                     }
                  }
               }
            }
         }
      }

      public virtual void setActivePart(VJDFAttributeMap vp, bool bFirst)
      {
         theStatusCounter.setActiveNode(theExpandedNode, vp, getNodeLinks());
      }

      ///   
      ///	 <summary> * execute for all kids
      ///	 *  </summary>
      ///	 
      public virtual void executeAll(VJDFAttributeMap parts)
      {
         List<VJDFAttributeMap> vvMap = new List<VJDFAttributeMap>();

         if (parts == null)
         {
            if (partsAtOnce > 0)
            {
               int size = vParts == null ? 0 : vParts.Count;
               VJDFAttributeMap vCurr = new VJDFAttributeMap();
               for (int i = 0; i < size; i++)
               {
                  if (i % partsAtOnce == 0)
                  {
                     vCurr = new VJDFAttributeMap();
                     vvMap.Add(vCurr);
                  }
                  vCurr.Add(vParts[i]);
               }
            }
            else
            {
               vvMap.Add(vParts);
            }
         }
         else
         {
            vvMap.Add(parts);
         }
         for (int i = 0; i < vvMap.Count; i++)
         {
            setActivePart(vvMap[i], i % partsForAvailable == 0);
            for (int j = 0; j < vKids.Count; j++)
            {
               vKids[j].execute(vvMap[i], i % partsForAvailable == (partsForAvailable - 1), i % partsForAvailable == 0);
            }
         }
      }

      ///   
      ///	 <summary> * simulate execution of this node the internal node will be modified to reflect the excution </summary>
      ///	 
      public virtual void execute(VJDFAttributeMap vMap, bool bOutAvail, bool bFirst)
      {
         theExpandedNode.setPartStatus(vMap, EnumNodeStatus.Completed, null);
         theNode.setPartStatus(vMap, EnumNodeStatus.Completed, null);
         runphases(good, waste, bOutAvail, bFirst);

         // VElement vResLinks=theExpandedNode.getResourceLinks(null);
         // int siz= vResLinks!=null ? vResLinks.Count : 0;
         // for(int i=0;i<siz;i++)
         // {
         // JDFResourceLink rl=(JDFResourceLink)vResLinks[i];
         //
         // if(bOutAvail )
         // {
         // VElement vRes=rl.getTargetVector(-1);
         //
         // for(int j=0;j<vRes.Count;j++)
         // {
         // VElement leaves=((JDFResource)vRes[j]).getLeaves(false);
         // for(int k=0;k<leaves.Count;k++)
         // {
         // JDFResource r=(JDFResource) leaves[k);
         // JDFAttributeMap map=r.getPartMap();
         // if(vMap==null || vMap.overlapsMap(map))
         // {
         // r.setResStatus(EnumResStatus.Available, true);
         // EnumResourceClass rc=r.getResourceClass();
         // if(((EnumResourceClass.Handling.equals(rc)||EnumResourceClass.
         // Consumable.equals(rc)||EnumResourceClass.Quantity.equals(rc)) &&
         // EnumUsage.Output.equals(rl.getUsage()))
         // ||(EnumResourceClass.Consumable.equals(rc)
         // &&EnumUsage.Input.equals(rl.getUsage())))
         // {
         // if(good>=0)
         // {
         // map.put("Condition", "Good");
         // JDFPartAmount pa=rl.getCreateAmountPool().getPartAmount(map);
         // double preSet=pa==null ? 0 : pa.getActualAmount(null);
         // rl.setActualAmount(preSet+good, map);
         // }
         // if(waste>=0)
         // {
         // map.put("Condition", "Waste");
         // JDFPartAmount pa=rl.getCreateAmountPool().getPartAmount(map);
         // double preSet=pa==null ? 0 : pa.getActualAmount(null);
         // rl.setActualAmount(preSet+waste, map);
         // }
         // }
         // }
         // }
         // }
         // }
         // }
         theExpandedNode.synchParentAmounts();
         // base requires no generic excute support
         // JDFProcessRun pr=(JDFProcessRun)
         // theNode.getCreateAuditPool().addAudit(EnumAuditType.ProcessRun,
         // null);

      }

      protected internal virtual void runphases(int pgood, int pwaste, bool bOutAvail, bool bFirst)
      {
         theStatusCounter.setPhase(EnumNodeStatus.InProgress, "NodeDetails", EnumDeviceStatus.Running, "DeviceDetails");
         runSinglePhase(pgood, pwaste, bOutAvail, bFirst);
         // Finalize(); // prior to processRun
         theStatusCounter.setPhase(EnumNodeStatus.Completed, "NodeDetails", EnumDeviceStatus.Idle, "DeviceDetails");
      }

      ///   
      ///	 <summary> * schedule this node the nodeinfo will be modified </summary>
      ///	 
      public virtual void schedule(VJDFAttributeMap nodesToCombine, int starthours, int durationhours)
      {
         VJDFAttributeMap nodesToCombineLocal = nodesToCombine;

         theNode.setPartStatus(nodesToCombineLocal, EnumNodeStatus.Waiting, null);
         JDFNodeInfo ni = theNode.getNodeInfo();
         if (nodesToCombineLocal == null)
         {
            nodesToCombineLocal = new VJDFAttributeMap();
            nodesToCombineLocal.Add(null);
         }
         for (int i = 0; i < nodesToCombineLocal.Count; i++)
         {
            JDFNodeInfo nip = (JDFNodeInfo)ni.getCreatePartition(nodesToCombineLocal[i], null);
            JDFDate d = new JDFDate();
            d.addOffset(0, 0, starthours, 0);
            nip.setStart(d);
            d.addOffset(0, 0, durationhours, 0);
            nip.setEnd(d);
         }
      }

      ///   
      ///	 * <param name="good"> </param>
      ///	 * <param name="waste"> </param>
      ///	 
      protected internal void runSinglePhase(int pgood, int pwaste, bool bOutAvail, bool bFirst)
      {
         VElement vResLinks = theExpandedNode.getResourceLinks(null);
         if (vResLinks != null)
         {
            int siz = vResLinks.Count;
            for (int i = 0; i < siz; i++)
            {
               int _good = pgood;
               JDFResourceLink rl = (JDFResourceLink)vResLinks[i];
               // only consume input for first set of runs
               if (!bFirst && EnumUsage.Input.Equals(rl.getUsage()))
                  _good = 0;
               theStatusCounter.addPhase(rl.getrRef(), _good, pwaste, true);
            }
         }
      }

      ///   
      ///	 <summary> * do the last steps prior to processrun </summary>
      ///	 
      ~BaseGoldenTicket()
      {
         // handled by statuscounter
         // int siz =amountLinks==null ? 0 : amountLinks.Count;
         // for(int i=0;i<siz;i++)
         // {
         // theStatusCounter.setResourceAudit(amountLinks[i],
         // EnumReason.ProcessResult);
         // }
      }

      protected internal virtual void setVersion()
      {
         if (theVersion == null)
            theVersion = theNode.getVersion(true);
         if (theVersion == null)
            theVersion = JDFElement.getDefaultJDFVersion();
      }

      ///   
      ///	 <summary> * initializes this node to a given ICS version
      ///	 *  </summary>
      ///	 * <param name="icsLevel"> the level to init to (1,2 or 3) </param>
      ///	 
      public virtual void init()
      {
         initJDF();
         initAuditPool(theNode);
         initDevice(null);

      }

      ///   
      ///     <summary> *  </summary>
      ///     
      protected internal virtual JDFDevice initDevice(JDFNode previousNode)
      {
         JDFDevice dev = (JDFDevice)theNode.getResource(ElementName.DEVICE, EnumUsage.Input, 0);
         if (dev == null && devID != null)
         {
            JDFResourceLink rl = null;
            dev = (JDFDevice)(theParentNode != null ? theParentNode.getResource(ElementName.DEVICE, EnumUsage.Input, 0) : null);
            if (dev == null)
            {
               dev = (JDFDevice)theNode.getCreateResource(ElementName.DEVICE, EnumUsage.Input, 0);
               dev.setDeviceID(devID);
               rl = theNode.getLink(dev, EnumUsage.Input);
            }
            else
            {
               rl = theNode.getLink(dev, EnumUsage.Input);
               if (rl == null)
                  rl = theNode.linkResource(dev, EnumUsage.Input, null);
            }
         }
         return dev;
      }

      ///   
      ///     <summary> *  </summary>
      ///     
      public virtual void initAuditPool(JDFNode node)
      {
         JDFAuditPool auditPool = node.getCreateAuditPool();
         JDFAudit a = auditPool.getAudit(-1, EnumAuditType.Created, null, null);
         if (a == null)
            a = auditPool.addAudit(EnumAuditType.Created, null);
      }

      ///   
      ///	 * <param name="theNode"> </param>
      ///	 * <param name="product">
      ///	 * @return </param>
      ///	 
      protected internal virtual JDFNode addJDFNode(JDFNode node, EnumType t)
      {
         JDFNode newNode = node.addJDFNode(t);
         newNode.setStatus(EnumNodeStatus.Waiting);
         initAuditPool(newNode);
         return newNode;
      }

      ///   
      ///     <summary> *  </summary>
      ///     
      protected internal virtual void initJDF()
      {
         string icsTag = "Base_L" + baseICSLevel + "-" + theVersion.getName();
         theNode.appendAttribute(AttributeName.ICSVERSIONS, icsTag, null, " ", true);
         theNode.setVersion(theVersion);
         theNode.setMaxVersion(theVersion);
         theNode.setStatus(EnumNodeStatus.Waiting);
         if (!theNode.hasAttribute(AttributeName.DESCRIPTIVENAME))
            theNode.setDescriptiveName("Base Golden Ticket Example Job - version: " + JDFAudit.software());

         if (theParentNode == null && !theNode.hasAttribute(AttributeName.COMMENTURL))
            theNode.setCommentURL(UrlUtil.StringToURL("http://www.example.com").ToString());
      }

      ///   
      ///	 <summary> * @return </summary>
      ///	 
      protected internal virtual VElement getNodeLinks()
      {
         VElement nodeLinks = null;
         if (amountLinks != null)
         {
            nodeLinks = new VElement();
            VElement resLinks = theExpandedNode.getResourceLinks(null);
            if (resLinks != null)
            {
               int resLinkSize = resLinks.Count;
               for (int i = 0; i < amountLinks.Count; i++)
               {
                  for (int j = 0; j < resLinkSize; j++)
                  {
                     JDFResourceLink rl = (JDFResourceLink)resLinks[j];
                     if (rl.matchesString(amountLinks[i]))
                        nodeLinks.Add(rl);
                  }
               }
            }
         }

         return nodeLinks;
      }

      ///   
      ///	 <summary> * gets the current state of the node
      ///	 *  </summary>
      ///	 * <returns> the theNode </returns>
      ///	 
      public virtual JDFNode getNode()
      {
         return theNode;
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see java.lang.Object#toString()
      //	 
      public override string ToString()
      {
         string s = "[" + this.GetType().FullName + " Version: " + EnumUtil.getName(theVersion) + "]";
         if (theNode != null)
            s += theNode.ToString();
         return s;
      }

      ///   
      ///	 * <param name="string"> </param>
      ///	 * <param name="i"> </param>
      ///	 * <param name="b"> </param>
      ///	 
      public virtual void write2File(string file, int indent)
      {
         theNode.getOwnerDocument_KElement().write2File(file, indent, indent == 0);

      }

      public virtual StatusCounter getStatusCounter()
      {
         return theStatusCounter;
      }

      public static string getDeviceURL()
      {
         return deviceURL;
      }

      public static void setDeviceURL(string pdeviceURL)
      {
         BaseGoldenTicket.deviceURL = pdeviceURL;
      }

      public static string getMisURL()
      {
         return misURL;
      }

      public static void setMisURL(string _misURL)
      {
         BaseGoldenTicket.misURL = _misURL;
      }

      ///   
      ///	 <summary> * add the type of amount link for resource audits etc
      ///	 *  </summary>
      ///	 * <param name="link"> </param>
      ///	 
      public virtual void addAmountLink(string link)
      {
         if (amountLinks == null)
            amountLinks = new VString();
         amountLinks.appendUnique(link);
      }

      ///   
      ///	 * <param name="icsLevel"> </param>
      ///	 
      protected internal virtual void initColorantControl()
      {
         JDFResourceLink ccLink = null;
         if (thePreviousNode != null)
         {
            ccLink = theNode.linkResource(thePreviousNode.getResource(ElementName.COLORANTCONTROL, EnumUsage.Input, 0), EnumUsage.Input, null);
         }
         if (ccLink == null && theParentNode != null)
            ccLink = theNode.linkResource(theParentNode.getResource(ElementName.COLORANTCONTROL, EnumUsage.Input, 0), EnumUsage.Input, null);

         JDFColorantControl cc = (JDFColorantControl)(ccLink == null ? (JDFColorantControl)theNode.getCreateResource(ElementName.COLORANTCONTROL, EnumUsage.Input, 0) : ccLink.getTarget());
         cc.setResStatus(EnumResStatus.Available, false);

         JDFColorPool cp = (JDFColorPool)theNode.getJDFRoot().getChildByTagName(ElementName.COLORPOOL, null, 0, null, false, false);
         if (cp == null)
         {
            cp = (JDFColorPool)theNode.getCreateResource(ElementName.COLORPOOL, EnumUsage.Input, 0);
            if (theParentNode != null)
               theParentNode.getCreateResourcePool().moveElement(cp, null);
         }

         cc.refColorPool(cp);
         for (int i = 4; i < getNCols(); i++)
            cc.getCreateColorantParams().appendSeparation(cols.stringAt(i));
         for (int i = 0; i < getNCols(); i++)
         {
            string name = cols.stringAt(i);
            JDFColor c = cp.getCreateColorWithName(name, null);
            if (i == 0)
               c.setCMYK(new JDFCMYKColor(1, 0, 0, 0));
            if (i == 1)
               c.setCMYK(new JDFCMYKColor(0, 1, 0, 0));
            if (i == 2)
               c.setCMYK(new JDFCMYKColor(0, 0, 1, 0));
            if (i == 3)
               c.setCMYK(new JDFCMYKColor(0, 0, 0, 1));
         }
         cc.setProcessColorModel("DeviceCMYK");
         if (nCols[0] != nCols[1])
         {
            for (int ii = 0; ii < 2; ii++)
            {
               JDFColorantControl ccP = (JDFColorantControl)cc.addPartition(EnumPartIDKey.Side, ii == 0 ? "Front" : "Back");
               VString colsP = new VString();
               for (int iii = 0; iii < nCols[ii]; iii++)
                  colsP.Add(cols.stringAt(iii));
               JDFSeparationList co = ccP.getCreateColorantOrder();
               co.setSeparations(colsP);
            }
         }
         else
         {
            JDFSeparationList co = cc.getCreateColorantOrder();
            co.setSeparations(cols);
         }
      }

      ///   
      ///	 * <param name="icsLevel"> </param>
      ///	 
      protected internal virtual JDFMedia initPaperMedia()
      {
         JDFResourceLink rlM = null;
         if (thePreviousNode != null)
         {
            JDFMedia media = (JDFMedia)thePreviousNode.getResource(ElementName.MEDIA, EnumUsage.Input, 0);
            if (media != null && !EnumMediaType.Paper.Equals(media.getMediaType()))
               media = (JDFMedia)thePreviousNode.getResource(ElementName.MEDIA, EnumUsage.Input, 1);
            if (media != null && !EnumMediaType.Paper.Equals(media.getMediaType()))
               media = null;

            if (media == null)
            {
               media = getMediaFromNode(thePreviousNode);
               if (media == null)
               {
                  VElement v = thePreviousNode.getPredecessors(true, false);
                  if (v != null)
                  {
                     int siz = v.Count;
                     for (int i = 0; i < siz; i++)
                     {
                        media = getMediaFromNode((JDFNode)v[i]);
                        if (media != null)
                           break;
                     }
                  }
               }
            }
            rlM = theNode.linkResource(media, EnumUsage.Input, null);
         }

         if (rlM == null && theParentNode != null)
            rlM = theNode.linkResource(theParentNode.getResource(ElementName.MEDIA, EnumUsage.Input, 0), EnumUsage.Input, null);

         paperMedia = (JDFMedia)theNode.getCreateResource(ElementName.MEDIA, null, 0);
         paperMedia.setDescriptiveName("the paper to print on");
         paperMedia.setResStatus(EnumResStatus.Unavailable, false);
         paperMedia.setMediaType(EnumMediaType.Paper);
         paperMedia.setDimensionCM(new JDFXYPair(70, 102));
         paperMedia.setWeight(90);
         paperMedia.setThickness(90 / 0.8);
         return paperMedia;
      }

      ///   
      ///	 * <param name="media"> </param>
      ///	 * <param name="sNode">
      ///	 * @return </param>
      ///	 
      private JDFMedia getMediaFromNode(JDFNode sNode)
      {
         if (sNode == null)
            return null;
         JDFLayout lo = (JDFLayout)sNode.getResource(ElementName.LAYOUT, EnumUsage.Input, 0);
         if (lo != null)
         {
            JDFMedia m = lo.getMedia(0);
            if (m != null)
               return m;
         }

         JDFStrippingParams sp = (JDFStrippingParams)sNode.getResource(ElementName.STRIPPINGPARAMS, EnumUsage.Input, 0);
         if (sp != null)
         {
            return sp.getMedia(0);
         }
         return null;
      }

      ///   
      ///	 <summary> * get a reduced partionmap missing the keys in reduceKeys
      ///	 *  </summary>
      ///	 * <param name="reduceKeys">
      ///	 * @return </param>
      ///	 
      protected internal virtual VJDFAttributeMap getReducedMap(VString reduceKeys)
      {
         if (vParts == null)
            return null;
         VJDFAttributeMap reducedMap = new VJDFAttributeMap(vParts);
         reducedMap.removeKeys(reduceKeys.getSet());
         if ((reducedMap.Count == 0) || (reducedMap.Count == 1 && reducedMap[0].Count == 0))
            return null;
         return reducedMap;
      }

      ///   
      ///	 * <param name="icsLevel"> </param>
      ///	 
      protected internal virtual void initPlateXM(EnumUsage usage)
      {
         JDFResourceLink rl = null;
         if (thePreviousNode != null) // either input (for cp, or output for
            // plateset)
            rl = theNode.linkResource(thePreviousNode.getResource(ElementName.EXPOSEDMEDIA, null, 0), usage, null);

         if (rl == null && theParentNode != null)
            rl = theNode.ensureLink(theParentNode.getResource(ElementName.EXPOSEDMEDIA, null, 0), usage, null);

         JDFExposedMedia xm = (JDFExposedMedia)theNode.getCreateResource(ElementName.EXPOSEDMEDIA, usage, 0);
         xm.setPartUsage(EnumPartUsage.Explicit);
         rl = theNode.getLink(xm, null);

         JDFMedia m = ((JDFExposedMedia)xm.getLeaves(false)[0]).getMedia();
         if (m == null)
            m = initPlateMedia();
         else
         {
            m = (JDFMedia)m.getResourceRoot();
            if (theParentNode != null)
               theNode.ensureLink(theParentNode.getResource("Media", EnumUsage.Input, 0), EnumUsage.Input, null);
         }
         xm.setResStatus(EnumResStatus.Unavailable, false);
         if (!bPartitionedPlateMedia && xm.getMedia() == null)
            xm.refElement(m);
         if (EnumUsage.Input.Equals(usage))
         {
            rl.setProcessUsage(EnumProcessUsage.Plate);
            JDFResourceLink link = theNode.getLink(m, null);
            if (link != null)
               link.deleteNode();
         }

         if (vParts != null)
         {
            for (int i = 0; i < vParts.Count; i++)
            {
               JDFAttributeMap part = new JDFAttributeMap(vParts[i]);
               JDFResource xmp = xm.getCreatePartition(part, partIDKeys);
               int ncols = "Front".Equals(part.get("Side")) ? nCols[0] : nCols[1];

               for (int j = 0; j < ncols; j++)
               {
                  part.put(EnumPartIDKey.Separation, cols.stringAt(j));
                  xmp.getCreatePartition(part, partIDKeys);
               }
            }
            if (bPartitionedPlateMedia)
            {
               VJDFAttributeMap vSheets = getReducedMap(new VString("Side Separation PartVersion", null));
               for (int i = 0; i < vSheets.Count; i++)
               {
                  JDFAttributeMap part = new JDFAttributeMap(vSheets[i]);
                  JDFExposedMedia xmp = (JDFExposedMedia)xm.getCreatePartition(part, partIDKeys);
                  if (xmp.getMedia() == null)
                  {
                     xmp.refMedia((JDFMedia)m.getCreatePartition(part, null));
                  }
               }
            }
         }
      }

      ///   
      ///	 * <param name="xm">
      ///	 * @return </param>
      ///	 
      protected internal virtual JDFMedia initPlateMedia()
      {
         if (theParentNode != null)
            theNode.ensureLink(theParentNode.getResource(ElementName.MEDIA, EnumUsage.Input, 0), EnumUsage.Input, null);
         JDFMedia m = (JDFMedia)theNode.getCreateResource(ElementName.MEDIA, EnumUsage.Input, 0);
         if (EnumMediaType.Paper.Equals(m.getMediaType()))
            m = (JDFMedia)theNode.getCreateResource(ElementName.MEDIA, EnumUsage.Input, 1);
         m.setResStatus(EnumResStatus.Available, false);
         m.makeRootResource(null, theNode.getJDFRoot(), true);
         theNode.getJDFRoot().getCreateResourcePool().moveElement(m, null);
         m.setDescriptiveName("the plates to use");
         m.setMediaType(EnumMediaType.Plate);
         m.setPartUsage(EnumPartUsage.Implicit);
         if (bPartitionedPlateMedia && vParts != null)
         {
            VJDFAttributeMap vSheets = getReducedMap(new VString("Side Separation PartVersion", null));
            for (int i = 0; i < vSheets.Count; i++)
            {
               JDFAttributeMap part = new JDFAttributeMap(vSheets[i]);
               // JDFResource mm=
               m.getCreatePartition(part, partIDKeys);
            }

         }
         else
         {
            m.setDimensionCM(new JDFXYPair(70, 102));
         }
         return m;
      }

      public virtual int getNCols()
      {
         return nCols[0] == 0 ? cols.Count : Math.Max(nCols[0], nCols[1]);
      }

      ///   
      ///     <summary> *  </summary>
      ///     
      protected internal virtual JDFRunList initDocumentRunList()
      {
         JDFRunList rl = (JDFRunList)theNode.getCreateResource(ElementName.RUNLIST, EnumUsage.Input, 0);
         JDFResourceLink rll = theNode.getLink(rl, null);
         if ("Marks".Equals(rll.getProcessUsage()))
         {
            rl = (JDFRunList)theNode.getCreateResource(ElementName.RUNLIST, EnumUsage.Input, 1);
            rll = theNode.getLink(rl, null);
         }
         rll.setProcessUsage(EnumProcessUsage.Document);
         rl.addPDF(m_pdfFile, 0, -1);
         rl.setNPage(4);
         rl.setDescriptiveName("Description of this RunList");
         return rl;
      }

      ///   
      ///	 * <param name="icsLevel"> </param>
      ///	 
      protected internal virtual JDFComponent initOutputComponent()
      {
         if (thePreviousNode != null)
         {
            JDFResource parentOutComp = thePreviousNode.getResource(ElementName.COMPONENT, EnumUsage.Output, 0);
            if (parentOutComp != null)
            {
               theNode.linkResource(parentOutComp, EnumUsage.Input, null);
            }
         }
         JDFComponent outComp = (JDFComponent)(theParentNode != null ? theParentNode.getResource(ElementName.COMPONENT, EnumUsage.Output, 0) : null);
         if (outComp == null)
         {
            outComp = (JDFComponent)theNode.getCreateResource(ElementName.COMPONENT, EnumUsage.Output, 0);
            outComp.setComponentType(EnumComponentType.FinalProduct, EnumComponentType.Sheet);
            outComp.setProductType("Unknown");
         }
         else
            theNode.linkResource(outComp, EnumUsage.Output, null);

         JDFResourceLink rl = theNode.getLink(outComp, EnumUsage.Output);
         if (vParts != null)
         {
            VJDFAttributeMap reducedMap = getReducedMap(new VString("Side Separation", " "));
            if (reducedMap != null)
            {
               int size = reducedMap.Count;
               for (int i = 0; i < size; i++)
               {
                  JDFAttributeMap part = reducedMap[i];
                  JDFResource partComp = outComp.getCreatePartition(part, partIDKeys);
                  partComp.setDescriptiveName("Description for Component part# " + i);
                  JDFAttributeMap newMap = new JDFAttributeMap(part);
                  newMap.put(AttributeName.CONDITION, "Good");
                  rl.setAmount(good, newMap);
               }
            }
         }
         else
         {
            outComp.setDescriptiveName("MIS-CP output Component");
         }
         // outComp.getCreateLayout();
         JDFMedia inMedia = (JDFMedia)theNode.getResource(ElementName.MEDIA, EnumUsage.Input, 0);
         if (inMedia != null)
            outComp.setDimensions(inMedia.getDimension());
         return outComp;
      }
   }
}
