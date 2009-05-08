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
   using System.IO;

   using EnumPrintingType = org.cip4.jdflib.auto.JDFAutoConventionalPrintingParams.EnumPrintingType;
   using EnumWorkStyle = org.cip4.jdflib.auto.JDFAutoConventionalPrintingParams.EnumWorkStyle;
   using EnumDeviceStatus = org.cip4.jdflib.auto.JDFAutoDeviceInfo.EnumDeviceStatus;
   using EnumPreviewFileType = org.cip4.jdflib.auto.JDFAutoPreview.EnumPreviewFileType;
   using EnumPreviewUsage = org.cip4.jdflib.auto.JDFAutoPreview.EnumPreviewUsage;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFAudit = org.cip4.jdflib.core.JDFAudit;
   using JDFNodeInfo = org.cip4.jdflib.core.JDFNodeInfo;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using EnumNodeStatus = org.cip4.jdflib.core.JDFElement.EnumNodeStatus;
   using EnumVersion = org.cip4.jdflib.core.JDFElement.EnumVersion;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using EnumType = org.cip4.jdflib.node.JDFNode.EnumType;
   using JDFDevice = org.cip4.jdflib.resource.JDFDevice;
   using EnumPartIDKey = org.cip4.jdflib.resource.JDFResource.EnumPartIDKey;
   using EnumPartUsage = org.cip4.jdflib.resource.JDFResource.EnumPartUsage;
   using EnumResStatus = org.cip4.jdflib.resource.JDFResource.EnumResStatus;
   using JDFColorIntent = org.cip4.jdflib.resource.intent.JDFColorIntent;
   using JDFColor = org.cip4.jdflib.resource.process.JDFColor;
   using JDFColorPool = org.cip4.jdflib.resource.process.JDFColorPool;
   using JDFColorantControl = org.cip4.jdflib.resource.process.JDFColorantControl;
   using JDFComponent = org.cip4.jdflib.resource.process.JDFComponent;
   using JDFConventionalPrintingParams = org.cip4.jdflib.resource.process.JDFConventionalPrintingParams;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;
   using JDFPreview = org.cip4.jdflib.resource.process.JDFPreview;
   using JDFInk = org.cip4.jdflib.resource.process.prepress.JDFInk;
   using FileUtil = org.cip4.jdflib.util.FileUtil;
   using UrlUtil = org.cip4.jdflib.util.UrlUtil;

   ///
   /// <summary> * @author Rainer Prosi class that generates golden tickets based on ICS levels etc </summary>
   /// 
   public class MISCPGoldenTicket : MISGoldenTicket
   {
      ///   
      ///	 <summary> *  </summary>
      ///	 
      public const string MISCPS_PRINTING = "MISCPS.Printing";
      public bool splitSheets = false;

      public VString inks = null;
      public VString inkProductIDs = null;

      protected internal int icsLevel;
      ///   
      ///	 <summary> * if true, previews are linked </summary>
      ///	 
      public bool previewAvailable = false;
      ///   
      ///	 <summary> * file location of preview files </summary>
      ///	 
      public string previewShare = null;
      ///   
      ///	 <summary> * if true: ppf, else png preview names are generated </summary>
      ///	 
      public bool bPPF = false;

      ///   
      ///	 <summary> * create a BaseGoldenTicket
      ///	 *  </summary>
      ///	 * <param name="_icsLevel"> the level to init to (1,2 or 3) </param>
      ///	 * <param name="jdfVersion"> the version to generate a golden ticket for </param>
      ///	 * <param name="_jmfLevel"> level of jmf ICS to support </param>
      ///	 * <param name="_misLevel"> level of MIS ICS to support </param>
      ///	 * <param name="isGrayBox"> if true, write a grayBox </param>
      ///	 * <param name="vPartMap"> the partmap vector for this node </param>
      ///	 
      public MISCPGoldenTicket(int _icsLevel, EnumVersion jdfVersion, int _jmfLevel, int _misLevel, bool isGrayBox, VJDFAttributeMap vPartMap)
         : base(_misLevel, jdfVersion, _jmfLevel)
      {
         icsLevel = _icsLevel;
         vParts = vPartMap;
         grayBox = isGrayBox;
         setup();
      }

      protected internal override void fillCatMaps()
      {
         base.fillCatMaps();
         catMap[MISCPS_PRINTING] = new VString("InkZoneCalculation ConventionalPrinting", null);
      }

      ///   
      ///	 <summary> * create a BaseGoldenTicket
      ///	 *  </summary>
      ///	 
      public MISCPGoldenTicket(MISCPGoldenTicket parent)
         : base(parent)
      {
         grayBox = parent.grayBox;
         setup();
      }

      ///   
      ///	 * <param name="parent"> </param>
      ///	 
      private void setup()
      {
         if (grayBox)
            setCategory(MISCPS_PRINTING);
         //		theStatusCounter.addIgnorePart(EnumPartIDKey.Side);
         theStatusCounter.addIgnorePart(EnumPartIDKey.Separation);
         previewShare = UrlUtil.fileToUrl(new FileInfo("\\\\Share\\Dir\\Preview_"), false);
      }

      ///   
      ///	 <summary> * initializes this node to a given ICS version
      ///	 *  </summary>
      ///	 * <param name="icsLevel"> the level to init to (1,2 or 3) </param>
      ///	 
      public override void init()
      {
         initColsFromParent();
         initAmountsFromParent();
         if (partIDKeys == null)
            partIDKeys = new VString("SignatureName SheetName Side Separation", null);

         // put level methods?

         int ncols = getNCols();
         while (cols.Count > ncols && ncols > 0)
            cols.RemoveAt(ncols);

         if (icsLevel < 0)
            return;

         string icsTag = "MISCPS_L" + icsLevel + "-" + theVersion.getName();
         theNode.appendAttribute(AttributeName.ICSVERSIONS, icsTag, null, " ", true);
         if (!theNode.hasAttribute(AttributeName.DESCRIPTIVENAME))
            theNode.setDescriptiveName("MISCPS Golden Ticket Example Job - version: " + JDFAudit.software());

         if (!grayBox)
         {
            theNode.setType(EnumType.ConventionalPrinting);
         }
         initColorantControl();
         initConventionalPrintingParams();
         JDFMedia m = initPaperMedia();
         initPlateXM(EnumUsage.Input);
         initDevice(thePreviousNode);
         JDFComponent c = initOutputComponent();
         initInk();
         base.init();
         initPreview();
         setActivePart(vParts, true);
         theStatusCounter.setTrackWaste(c.getID(), true);
         theStatusCounter.setTrackWaste(m.getID(), true);
      }

      ///   
      ///	 <summary> * recalculate ncols from parent color intent if it exists </summary>
      ///	 
      private void initColsFromParent()
      {
         if (theParentProduct == null)
            return;
         JDFColorIntent ci = (JDFColorIntent)theParentProduct.getResource(ElementName.COLORINTENT, EnumUsage.Input, 0);
         if (ci == null)
            return;
         int c = ci.getNumColors();
         if (c > 0)
            nCols[0] = nCols[1] = c;
      }

      ///   
      ///	 <summary> * recalculate ncols from parent color intent if it exists </summary>
      ///	 
      private void initAmountsFromParent()
      {
         if (theParentProduct == null)
            return;
         JDFComponent c = (JDFComponent)theParentProduct.getResource(ElementName.COMPONENT, EnumUsage.Output, 0);
         JDFResourceLink cl = theParentProduct.getLink(c, EnumUsage.Output);
         if (cl == null)
            return;
         double amount = cl.getAmount(null);
         if (amount > 0)
         {
            good = (int)amount;
            waste = (int)(good * 0.1);
         }
      }

      public override void setActivePart(VJDFAttributeMap vp, bool bFirst)
      {
         amountLinks = null;
         addAmountLink("Media:Input");
         addAmountLink("Component:Output");
         base.setActivePart(vp, bFirst);
      }

      ///   
      ///	 * <param name="icsLevel"> </param>
      ///	 
      protected internal override JDFMedia initPaperMedia()
      {
         JDFMedia m = base.initPaperMedia();
         JDFResourceLink rl = theNode.getLink(m, null);
         if (rl == null)
         {
            rl = theNode.linkResource(m, EnumUsage.Input, null);
         }
         if (vParts != null)
         {
            VJDFAttributeMap reducedMap = getReducedMap(new VString("Side Separation", " "));
            if (reducedMap != null)
            {
               int size = reducedMap.Count;
               for (int i = 0; i < size; i++)
               {
                  JDFAttributeMap part = reducedMap[i];
                  JDFAttributeMap newMap = new JDFAttributeMap(part);
                  newMap.put(AttributeName.CONDITION, "Good");
                  rl.setAmount(good, newMap);
                  rl.setMaxAmount(good + waste, newMap);
                  newMap.put(AttributeName.CONDITION, "Waste");
                  rl.setMaxAmount(waste, newMap);
               }
            }

         }

         return m;
      }

      protected internal virtual void initInk()
      {
         if (inks == null)
            return;
         JDFInk ink = (JDFInk)theNode.getCreateResource(ElementName.INK, EnumUsage.Input, 0);
         int ncols = getNCols();
         for (int j = 0; j < ncols; j++)
         {
            JDFInk inkp = (JDFInk)ink.addPartition(EnumPartIDKey.Separation, cols.stringAt(j));
            inkp.setInkName(inks[j]);
            if ((cols[j].ToLower().IndexOf("varnish") >= 0) || (inks[j].ToLower().IndexOf("varnish") >= 0))
               inkp.setFamily("Varnish");
            if (inkProductIDs != null)
               inkp.setProductID(inkProductIDs[j]);
         }
      }

      ///   
      ///	 * <param name="icsLevel"> </param>
      ///	 
      protected internal virtual void initPreview()
      {
         JDFResourceLink rlP = null;
         if (theNode.getCombinedProcessIndex(EnumType.InkZoneCalculation, 0) < 0)
            return;
         if (thePreviousNode != null)
         {
            rlP = theNode.linkResource(thePreviousNode.getResource(ElementName.PREVIEW, EnumUsage.Output, 0), EnumUsage.Input, null);
         }
         if (rlP == null && theParentNode != null)
            rlP = theNode.linkResource(theParentNode.getResource(ElementName.PREVIEW, EnumUsage.Input, 0), EnumUsage.Input, null);

         JDFPreview pv = (JDFPreview)theNode.getCreateResource(ElementName.PREVIEW, EnumUsage.Input, 0);
         pv.setResStatus(EnumResStatus.Incomplete, false);
         pv.setPreviewUsage(EnumPreviewUsage.Separation);
         pv.setPartUsage(EnumPartUsage.Explicit);
         pv.setPreviewFileType(bPPF ? EnumPreviewFileType.CIP3Single : EnumPreviewFileType.PNG);

         VJDFAttributeMap reducedMap = bPPF ? getReducedMap(new VString("Side Separation", " ")) : vParts;
         if (reducedMap != null)
         {
            int size = reducedMap.Count;
            for (int i = 0; i < size; i++)
            {
               JDFAttributeMap part = new JDFAttributeMap(reducedMap[i]);
               JDFPreview previewPartition = (JDFPreview)pv.getCreatePartition(part, partIDKeys);
               if (bPPF)
               {
                  preparePreview(previewPartition);
               }
               else
               {
                  for (int j = 0; j < getNCols(); j++)
                  {
                     part.put(EnumPartIDKey.Separation, cols.stringAt(j));
                     JDFPreview sepPreview = (JDFPreview)previewPartition.getCreatePartition(part, partIDKeys);
                     preparePreview(sepPreview);
                  }
               }
            }
         }
      }

      ///   
      ///	 <summary> * prepare a preview partition  </summary>
      ///	 * <param name="previewPartition"> </param>
      ///	 
      private void preparePreview(JDFPreview previewPartition)
      {
         if (previewAvailable)
         {
            setPreviewURL(previewPartition);
            previewPartition.setResStatus(EnumResStatus.Available, false);
         }
         else
         {
            previewPartition.setResStatus(EnumResStatus.Incomplete, false);
         }
      }

      ///   
      ///	 * <param name="icsLevel"> </param>
      ///	 
      protected internal virtual void initConventionalPrintingParams()
      {
         if (theParentNode != null)
            theNode.linkResource(theParentNode.getResource(ElementName.CONVENTIONALPRINTINGPARAMS, EnumUsage.Input, 0), EnumUsage.Input, null);
         JDFConventionalPrintingParams cpp = (JDFConventionalPrintingParams)theNode.getCreateResource(ElementName.CONVENTIONALPRINTINGPARAMS, EnumUsage.Input, 0);
         cpp.setPrintingType(EnumPrintingType.SheetFed);
         cpp.setWorkStyle(workStyle);
         cpp.setResStatus(EnumResStatus.Available, false);
      }

      protected internal override JDFDevice initDevice(JDFNode reuseNode)
      {
         if (misICSLevel < 2)
            return null;

         base.initDevice(reuseNode);

         JDFDevice dev = (JDFDevice)theNode.getCreateResource(ElementName.DEVICE, EnumUsage.Input, 0);
         VJDFAttributeMap reducedMap = getReducedMap(new VString("Side Separation", " "));
         if (reducedMap != null)
         {
            if (devID != null && splitSheets)
            {
               int size = reducedMap.Count;
               for (int i = 0; i < size; i++)
               {
                  JDFAttributeMap part = reducedMap[i];
                  JDFDevice devPart = (JDFDevice)dev.getCreatePartition(part, partIDKeys);

                  devPart.setResStatus(EnumResStatus.Available, false);
                  devPart.setDeviceID(devID);
               }
            }
         }

         return dev;
      }

      ///   
      ///	 * <param name="icsLevel"> </param>
      ///	 
      protected internal virtual void makeReadyColorantControl()
      {
         JDFColorantControl cc = (JDFColorantControl)theExpandedNode.getCreateResource(ElementName.COLORANTCONTROL, EnumUsage.Input, 0);
         JDFColorPool cp = cc.getCreateColorPool();
         for (int i = 0; i < getNCols(); i++)
         {
            string name = cols.stringAt(i);
            JDFColor c = cp.getCreateColorWithName(name, null);
            c.setActualColorName(colsActual.stringAt(i));
         }
      }

      ///   
      ///	 <summary> * prepare an mis fuzzy node and make it runnable by the device
      ///	 *  </summary>
      ///	 
      public override void makeReady()
      {
         base.makeReady();

         makeReadyPreview();
         makeReadyColorantControl();
      }

      ///   
      ///	 <summary> *  </summary>
      ///	 
      private void makeReadyPreview()
      {
         JDFPreview pv = (JDFPreview)theNode.getResource(ElementName.PREVIEW, EnumUsage.Input, 0);
         VElement v = pv == null ? new VElement() : pv.getLeaves(false);
         for (int i = 0; i < v.Count; i++)
         {
            JDFPreview pvp = (JDFPreview)v[i];
            setPreviewURL(pvp);
            pvp.setResStatus(EnumResStatus.Available, true);
         }
      }

      ///   
      ///	 * <param name="previewLeaf"> </param>
      ///	 
      private void setPreviewURL(JDFPreview previewLeaf)
      {
         DirectoryInfo share = UrlUtil.urlToFile(previewShare).Directory;
         FileInfo file;
         if (bPPF)
         {
            file = new FileInfo(previewLeaf.getSheetName() + ".ppf");
         }
         else
         {
            file = new FileInfo(previewLeaf.getSheetName() + "_" + previewLeaf.getSide().getName().Substring(0, 1) + "_" + previewLeaf.getSeparation() + ".png");

         }
         file = FileUtil.getFileInDirectory(share, file);
         previewLeaf.setURL(UrlUtil.fileToUrl(file, false));
         previewLeaf.setPreviewUsage(EnumPreviewUsage.Separation);
         previewLeaf.setPreviewFileType(EnumPreviewFileType.CIP3Single);
      }

      ///   
      ///	 * <param name="icsLevel">
      ///	 * @return </param>
      ///	 
      protected internal override JDFNodeInfo initNodeInfo()
      {
         JDFNodeInfo ni = base.initNodeInfo();
         if (vParts != null)
         {
            VJDFAttributeMap reducedMap = new VJDFAttributeMap(vParts);
            VString reduceKeys = new VString(partIDKeys);
            // simplex and perfecting are one run only
            if (EnumWorkStyle.Simplex.Equals(workStyle) || EnumWorkStyle.Perfecting.Equals(workStyle))
               reduceKeys.Remove(AttributeName.SIDE);
            reducedMap.reduceMap(reduceKeys.getSet());
            theNode.setPartStatus(reducedMap, EnumNodeStatus.Waiting, null);
            for (int i = 0; i < reducedMap.Count; i++)
            {
               JDFAttributeMap part = reducedMap[i];
               JDFNodeInfo niPart = (JDFNodeInfo)ni.getCreatePartition(part, partIDKeys);
               niPart.setDescriptiveName("Printing for" + part.ToString());
            }
         }
         return ni;
      }

      protected internal override void runphases(int pgood, int pwaste, bool bOutAvail, bool bFirst)
      {
         theStatusCounter.setPhase(EnumNodeStatus.InProgress, "Good", EnumDeviceStatus.Running, "Printing");
         runSinglePhase(pgood, pwaste, bOutAvail, bFirst);
         // Finalize(); // prior to processRun
         theStatusCounter.setPhase(EnumNodeStatus.Completed, "Done", EnumDeviceStatus.Idle, "Waiting");
      }

      public override void assign(JDFNode node)
      {

         base.assign(node);
         theNode.getCreateNodeInfo().setPartIDKeys(partIDKeys);
      }

      ///   
      ///	 <summary> * zapp any direct links to colorpool </summary>
      ///	 
      protected internal override void initColorantControl()
      {
         base.initColorantControl();
         JDFColorPool cp = (JDFColorPool)theNode.getResource(ElementName.COLORPOOL, EnumUsage.Input, 0);
         if (cp != null)
         {
            JDFResourceLink rl = theNode.getLink(cp, EnumUsage.Input);
            if (rl != null)
               rl.deleteNode();
         }
      }
   }
}
