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

   using EnumOrder = org.cip4.jdflib.auto.JDFAutoAssembly.EnumOrder;
   using EnumBinderySignatureType = org.cip4.jdflib.auto.JDFAutoBinderySignature.EnumBinderySignatureType;
   using EnumEncoding = org.cip4.jdflib.auto.JDFAutoIdentificationField.EnumEncoding;
   using EnumMediaType = org.cip4.jdflib.auto.JDFAutoMedia.EnumMediaType;
   using EnumPreviewFileType = org.cip4.jdflib.auto.JDFAutoPreview.EnumPreviewFileType;
   using EnumPreviewUsage = org.cip4.jdflib.auto.JDFAutoPreview.EnumPreviewUsage;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFAudit = org.cip4.jdflib.core.JDFAudit;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using EnumVersion = org.cip4.jdflib.core.JDFElement.EnumVersion;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using JDFMatrix = org.cip4.jdflib.datatypes.JDFMatrix;
   using JDFRectangle = org.cip4.jdflib.datatypes.JDFRectangle;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using EnumProcessUsage = org.cip4.jdflib.node.JDFNode.EnumProcessUsage;
   using EnumType = org.cip4.jdflib.node.JDFNode.EnumType;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFStrippingParams = org.cip4.jdflib.resource.JDFStrippingParams;
   using EnumPartIDKey = org.cip4.jdflib.resource.JDFResource.EnumPartIDKey;
   using EnumPartUsage = org.cip4.jdflib.resource.JDFResource.EnumPartUsage;
   using EnumResStatus = org.cip4.jdflib.resource.JDFResource.EnumResStatus;
   using JDFColorIntent = org.cip4.jdflib.resource.intent.JDFColorIntent;
   using JDFAssembly = org.cip4.jdflib.resource.process.JDFAssembly;
   using JDFBarcodeProductionParams = org.cip4.jdflib.resource.process.JDFBarcodeProductionParams;
   using JDFBinderySignature = org.cip4.jdflib.resource.process.JDFBinderySignature;
   using JDFContentObject = org.cip4.jdflib.resource.process.JDFContentObject;
   using JDFIdentificationField = org.cip4.jdflib.resource.process.JDFIdentificationField;
   using JDFLayout = org.cip4.jdflib.resource.process.JDFLayout;
   using JDFLayoutElementProductionParams = org.cip4.jdflib.resource.process.JDFLayoutElementProductionParams;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;
   using JDFPreview = org.cip4.jdflib.resource.process.JDFPreview;
   using JDFRunList = org.cip4.jdflib.resource.process.JDFRunList;
   using JDFPreviewGenerationParams = org.cip4.jdflib.resource.process.prepress.JDFPreviewGenerationParams;
   using StringUtil = org.cip4.jdflib.util.StringUtil;

   ///
   /// <summary> * @author Rainer Prosi class that generates golden tickets based on ICS levels etc </summary>
   /// 
   public class MISPreGoldenTicket : MISGoldenTicket
   {
      public const string MISPRE_CONTENTCREATION = "MISPRE.ContentCreation";
      public const string MISPRE_IMPOSITIONPREPARATION = "MISPRE.ImpositionPreparation";
      public const string MISPRE_PREPRESSPREPARATION = "MISPRE.PrePressPreparation";
      public const string MISPRE_IMPOSITIONRIPING = "MISPRE.ImpositionRIPing";
      public const string MISPRE_PLATEMAKING = "MISPRE.PlateMaking";
      public const string MISPRE_PLATESETTING = "MISPRE.PlateSetting";

      protected internal int icsLevel;
      public bool bStripping = false;
      public bool bSingleSided = false;

      ///   
      ///	 <summary> * create a BaseGoldenTicket
      ///	 *  </summary>
      ///	 * <param name="icsLevel"> the level to init to (1,2 or 3) </param>
      ///	 * <param name="jdfVersion"> the version to generate a golden ticket for </param>
      ///	 * <param name="jmfLevel"> level of jmf ICS to support </param>
      ///	 * <param name="misLevel"> level of MIS ICS to support </param>
      ///	 * <param name="isGrayBox"> if true, write a grayBox </param>
      ///	 
      public MISPreGoldenTicket(MISPreGoldenTicket previous, VJDFAttributeMap _vparts)
         : base(previous.misICSLevel, previous.theVersion, previous.jmfICSLevel)
      {

         partIDKeys = new VString(previous.partIDKeys);
         vParts = _vparts == null ? new VJDFAttributeMap(previous.vParts) : _vparts;
         icsLevel = previous.icsLevel;
         nCols = previous.nCols;
         workStyle = previous.workStyle;
         thePreviousNode = previous.theNode;
         theParentNode = previous.theParentNode;
      }

      ///   
      ///	 <summary> * create a BaseGoldenTicket
      ///	 *  </summary>
      ///	 * <param name="icsLevel"> the level to init to (1,2 or 3) </param>
      ///	 * <param name="jdfVersion"> the version to generate a golden ticket for </param>
      ///	 * <param name="jmfLevel"> level of jmf ICS to support </param>
      ///	 * <param name="misLevel"> level of MIS ICS to support </param>
      ///	 * <param name="isGrayBox"> if true, write a grayBox </param>
      ///	 
      public MISPreGoldenTicket(MISPreGoldenTicket parent)
         : base(parent)
      {
      }

      ///   
      ///	 <summary> *  </summary>
      ///	 
      protected internal override void fillCatMaps()
      {
         base.fillCatMaps();
         catMap.Add(MISPRE_CONTENTCREATION, new VString(EnumType.LayoutElementProduction.getName(), null));

         catMap.Add(MISPRE_IMPOSITIONPREPARATION, new VString("ImpositionPreparation", null));

         if (!bStripping)
            catMap.Add(MISPRE_PREPRESSPREPARATION, new VString("PrePressPreparation", null));
         else
            catMap.Add(MISPRE_PREPRESSPREPARATION, new VString("Stripping", null));

         catMap.Add(MISPRE_IMPOSITIONRIPING, new VString("Imposition RIPing PreviewGeneration", null));
         catMap.Add(MISPRE_PLATEMAKING, new VString("Imposition RIPing PreviewGeneration ImageSetting", null));
         catMap.Add(MISPRE_PLATESETTING, new VString("ImageSetting", null));
      }

      ///   
      ///	 <summary> * create a BaseGoldenTicket
      ///	 *  </summary>
      ///	 * <param name="_icsLevel"> the level to init to (1,2 or 3) </param>
      ///	 * <param name="jdfVersion"> the version to generate a golden ticket for </param>
      ///	 * <param name="_jmfLevel"> level of jmf ICS to support </param>
      ///	 * <param name="_misLevel"> level of MIS ICS to support </param>
      ///	 * <param name="vPartMap"> list of parts to process </param>
      ///	 
      public MISPreGoldenTicket(int _icsLevel, EnumVersion jdfVersion, int _jmfLevel, int _misLevel, VJDFAttributeMap vPartMap)
         : base(_misLevel, jdfVersion, _jmfLevel)
      {

         partIDKeys = new VString("SignatureName,SheetName,Side,Separation", ",");
         vParts = vPartMap;
         icsLevel = _icsLevel;
      }

      ///   
      ///	 <summary> * initializes this node to a given ICS version
      ///	 *  </summary>
      ///	 * <param name="icsLevel"> the level to init to (1,2 or 3) </param>
      ///	 
      public override void init()
      {
         theNode.setType(EnumType.ProcessGroup);
         initColsFromParent();
         theNode.linkOutputs(thePreviousNode);

         // put level methods?

         int ncols = getNCols();
         while (cols.Count > ncols && ncols > 0)
            cols.RemoveAt(ncols);

         if (icsLevel < 0)
            return;
         string icsTag = "MISPre_L" + icsLevel + "-" + theVersion.getName();
         theNode.appendAttribute(AttributeName.ICSVERSIONS, icsTag, null, " ", true);
         if (!theNode.hasAttribute(AttributeName.DESCRIPTIVENAME))
            theNode.setDescriptiveName("MISPre Golden Ticket Example Job - version: " + JDFAudit.software());

         string cat = getCategory();
         if (MISPRE_CONTENTCREATION.Equals(cat))
         {
            initGBContentCreation();
         }
         else if (MISPRE_PREPRESSPREPARATION.Equals(cat))
         {
            initGBPrePressPreparation();
         }
         else if (MISPRE_IMPOSITIONPREPARATION.Equals(cat))
         {
            initGBImpositionPreparation();
         }
         else if (MISPRE_IMPOSITIONRIPING.Equals(cat))
         {
            initGBImpositionRIPing();
         }
         else if (MISPRE_PLATESETTING.Equals(cat))
         {
            initGBPlateSetting();
         }
         else if (MISPRE_PLATEMAKING.Equals(cat))
         {
            initGBPlateMaking();
         }
         base.init();
         setActivePart(vParts, true);
      }

      ///   
      ///	 <summary> *  </summary>
      ///	 
      private void initGBImpositionRIPing()
      {
         linkPrepressPrepRunLists();
         initColorantControl();
         initDevice(null);
         initPreviewSep();
         initPreviewComp();
         initConduitRunListOut();
      }

      ///   
      ///	 <summary> *  </summary>
      ///	 
      private void linkPrepressPrepRunLists()
      {
         VElement vprepreviousNode = theNode.getJDFRoot().getvJDFNode(null, null, false);
         if (vprepreviousNode != null && vprepreviousNode.Count > 0)
         {
            for (int i = 0; i < vprepreviousNode.Count; i++)
            {
               JDFNode node = (JDFNode)vprepreviousNode[i];
               VString types = node.getTypes();
               if (types != null && types.Contains("PrePressPreparation"))
                  theNode.linkOutputs(node);
            }
         }
      }

      ///   
      ///	 <summary> *  </summary>
      ///	 
      private void initGBPlateMaking()
      {
         linkPrepressPrepRunLists();
         initColorantControl();
         initDevice(null);
         initPreviewSep();
         initPreviewComp();
         initPreviewGenerationParams();
         initPlateXM(EnumUsage.Output);
      }

      ///   
      ///	 <summary> *  </summary>
      ///	 
      private void initPreviewGenerationParams()
      {
         // no requirements

      }

      ///   
      ///	 <summary> *  </summary>
      ///	 
      private void initGBPlateSetting()
      {
         initColorantControl();
         initDevice(null);
         initPlateXM(EnumUsage.Output);
      }

      ///   
      ///	 <summary> *  </summary>
      ///	 
      private void initGBPrePressPreparation()
      {
         if (thePreviousNode != null)
            theNode.linkOutputs(thePreviousNode);
         else
            initDocumentRunList();
         JDFRunList rl = initConduitRunListOut();
         theNode.getLink(rl, EnumUsage.Output).setProcessUsage(EnumProcessUsage.Document);
      }

      ///   
      ///	 <summary> *  </summary>
      ///	 
      private JDFBinderySignature initBinderySignature(string catalog)
      {
         JDFBinderySignature bs = (JDFBinderySignature)theNode.addResource(ElementName.BINDERYSIGNATURE, EnumUsage.Input);
         bs.setBinderySignatureType(EnumBinderySignatureType.Fold);
         bs.setFoldCatalog(catalog);
         int f = StringUtil.parseInt(StringUtil.token(catalog, 0, "-").Substring(1), 0) / 2;
         if (f > 0)
         {
            int fx = f;
            int fy = 1;
            if (f >= 8)
            {
               fx /= 2;
               fy *= 2;
            }
            bs.setNumberUp(new JDFXYPair(fx, fy));
         }

         return bs;
      }

      ///   
      ///	 <summary> *  </summary>
      ///	 
      private void initStrippingParams()
      {
         JDFStrippingParams sp = (JDFStrippingParams)theNode.getCreateResource(ElementName.STRIPPINGPARAMS, EnumUsage.Input, 0);
         sp.setDescriptiveName("Impositioning for job " + theNode.getJobID(true));
         sp.setWorkStyle(org.cip4.jdflib.auto.JDFAutoStrippingParams.EnumWorkStyle.getEnum(workStyle.getValue()));
         // VJDFAttributeMap reduceMap=
         getReducedMap(new VString("Separation PartVersion", null));
         JDFBinderySignature bs0 = (JDFBinderySignature)theNode.getResource(ElementName.BINDERYSIGNATURE, EnumUsage.Input, 0);
         JDFBinderySignature bs1 = (JDFBinderySignature)theNode.getResource(ElementName.BINDERYSIGNATURE, EnumUsage.Input, 1);
         if (bs1 == null)
            bs1 = bs0;

         if (vParts != null)
         {
            VJDFAttributeMap reducedMap = getReducedMap(new VString("Side Separation PartVersion", " "));
            if (reducedMap != null)
            {
               int size = reducedMap.Count;
               for (int i = 0; i < size; i++)
               {
                  JDFAttributeMap part = reducedMap[i];
                  JDFResource partSP = sp.getCreatePartition(part, partIDKeys);
                  JDFBinderySignature bs = partSP.getSheetName().ToLower().Contains("cover") ? bs0 : bs1;
                  partSP.refElement(bs);
                  JDFResourceLink rl = theNode.getLink(bs, null);
                  if (rl != null)
                     rl.deleteNode();
               }
            }
         }
         else
         {
            sp.refElement(bs0);
         }

         sp.appendDevice().setDeviceID("Press_ID");
         sp.appendPosition().setRelativeBox(new JDFRectangle(0, 0, 0.5, 1));
         sp.appendPosition().setRelativeBox(new JDFRectangle(0.5, 1, 1, 1));

         sp.appendStripCellParams().setTrimSize(new JDFXYPair(8.5 * 72, 11 * 72));

         sp.refElement(initPaperMedia());
      }

      ///   
      ///	 <summary> *  </summary>
      ///	 
      private void initGBImpositionPreparation()
      {
         theNode.setTypes(new VString(bStripping ? "Stripping" : "ImpositionPreparation", null));

         if (bStripping)
         {
            initBinderySignature("F4-1");
            initBinderySignature("F8-2");
            initStrippingParams();
            initAssembly();
         }

         initOutputLayout();
         JDFRunList rlMarks = initConduitRunListOut();
         theNode.getLink(rlMarks, EnumUsage.Output).setProcessUsage(EnumProcessUsage.Marks);

      }

      ///   
      ///	 <summary> *  </summary>
      ///	 
      private void initAssembly()
      {
         JDFAssembly assem = (JDFAssembly)theNode.getCreateResource(ElementName.ASSEMBLY, EnumUsage.Input, 0);
         assem.setOrder(EnumOrder.Collecting);

      }

      ///   
      ///	 <summary> *  </summary>
      ///	 
      private void initOutputLayout()
      {
         JDFLayout lo = (JDFLayout)theNode.getCreateResource(ElementName.LAYOUT, EnumUsage.Output, 0);
         lo.setResStatus(EnumResStatus.Unavailable, false);
         VString vSigSheetSide = new VString("SignatureName SheetName Side", null);
         lo.setPartIDKeys(vSigSheetSide);
         for (int i = 0; i < vParts.Count; i++)
         {
            lo.getCreatePartition(vParts[i], vSigSheetSide);
         }
      }

      ///   
      ///	 <summary> *  </summary>
      ///	 
      private void initGBContentCreation()
      {
         theNode.setTypes(new VString(EnumType.LayoutElementProduction.getName(), null));
         JDFRunList ruli = initDocumentRunList();
         JDFResourceLink rl = theNode.getLink(ruli, EnumUsage.Input);
         rl.setProcessUsage((EnumProcessUsage)null);
         initLayoutElementProductionParams();
         initConduitRunListOut();
      }

      ///   
      ///	 <summary> *  </summary>
      ///	 
      private JDFRunList initConduitRunListOut()
      {
         JDFRunList rl = (JDFRunList)theNode.getCreateResource(ElementName.RUNLIST, EnumUsage.Output, 0);
         rl.setResStatus(EnumResStatus.Unavailable, false);
         return rl;
      }

      ///   
      ///	 <summary> *  </summary>
      ///	 
      private void initLayoutElementProductionParams()
      {
         JDFLayoutElementProductionParams lep = (JDFLayoutElementProductionParams)theNode.getCreateResource(ElementName.LAYOUTELEMENTPRODUCTIONPARAMS, EnumUsage.Input, 0);
         JDFBarcodeProductionParams bp = lep.getCreateLayoutElementPart(0).appendBarcodeProductionParams();
         JDFIdentificationField idf = bp.appendIdentificationField();
         idf.setEncoding(EnumEncoding.Barcode);
         idf.setEncodingDetails("EAN");
         idf.setValue("123456");
      }

      ///   
      ///	 <summary> * recalculate ncols from parent color intent if it exists </summary>
      ///	 
      private void initColsFromParent()
      {
         if (theParentNode == null)
            return;
         JDFColorIntent ci = (JDFColorIntent)theParentNode.getResource(ElementName.COLORINTENT, EnumUsage.Input, 0);
         if (ci == null)
            return;
         int c = ci.getNumColors();
         if (c > 0)
            nCols[0] = nCols[1] = c;
      }

      ///   
      ///	 <summary> * simulate execution of this node the internal node will be modified to reflect the excution </summary>
      ///	 
      public override void execute(VJDFAttributeMap parts, bool outputAvailable, bool bFirst)
      {
         VJDFAttributeMap partsLocal = parts;

         partsLocal = null; // alwways execute all in pp
         setActivePart(partsLocal, bFirst);
         base.execute(partsLocal, outputAvailable, bFirst);
         if (MISPRE_IMPOSITIONPREPARATION.Equals(getCategory()))
         {
            executeGBImpositionPreparation();
         }
      }

      ///   
      ///	 <summary> *  </summary>
      ///	 
      private void executeGBImpositionPreparation()
      {
         executeLayout();
         executeRunList(EnumUsage.Input);
         executeMarksRunList(EnumUsage.Output);

      }

      ///   
      ///	 <summary> *  </summary>
      ///	 
      private void executeMarksRunList(EnumUsage usage)
      {
         JDFRunList rl = (JDFRunList)theExpandedNode.getResource(ElementName.RUNLIST, usage, 0);
         if (!"Marks".Equals(theExpandedNode.getLink(rl, usage).getProcessUsage()))
            rl = (JDFRunList)theExpandedNode.getResource(ElementName.RUNLIST, usage, 1);
         if (!"Marks".Equals(theExpandedNode.getLink(rl, usage).getProcessUsage()))
            rl = null;

         if (rl != null && !rl.hasChildElement(ElementName.LAYOUTELEMENT, null))
            rl.addPDF("./folder/TheMarks.pdf", 0, -1);
      }

      ///   
      ///	 <summary> * emulate execution of a runlist by making it available </summary>
      ///	 
      private void executeRunList(EnumUsage usage)
      {
         JDFRunList rl = (JDFRunList)theExpandedNode.getResource(ElementName.RUNLIST, usage, 0);
         if (rl == null)
            return;
         if (!rl.hasChildElement(ElementName.LAYOUTELEMENT, null))
            rl.addPDF("./folder/Thedoc.pdf", 0, -1);
         if (EnumUsage.Output.Equals(usage))
            rl.setResStatus(EnumResStatus.Available, true);
      }

      ///   
      ///	 <summary> *  </summary>
      ///	 
      private void executeLayout()
      {
         JDFLayout lo = (JDFLayout)theExpandedNode.getResource(ElementName.LAYOUT, EnumUsage.Output, 0);
         if (lo != null && vParts != null)
         {
            VJDFAttributeMap reducedMap = getReducedMap(new VString("Separation PartVersion", " "));
            lo.setResStatus(EnumResStatus.Available, true);
            if (reducedMap != null)
            {
               int size = reducedMap.Count;
               for (int i = 0; i < size; i++)
               {
                  JDFAttributeMap part = reducedMap[i];
                  if (bSingleSided == true && "Back".Equals(part.get("Side")))
                     continue;

                  JDFLayout partLO = (JDFLayout)lo.getCreatePartition(part, partIDKeys);
                  for (int j = 0; j < 4; j++)
                  {
                     JDFContentObject co = partLO.appendContentObject();
                     co.setCTM(new JDFMatrix(1 + 10 * j, 2 + 20 * j, 3 + 30 * j, 4 + 40 * j, 5 + 50 * j, 6 + 0 * j));
                     co.setOrd(j + i * 4);
                  }
               }
            }
         }
      }

      ///   
      ///	 * <param name="icsLevel"> </param>
      ///	 
      protected internal virtual void initPreviewSep()
      {
         if (theParentNode != null)
            theNode.ensureLink(theParentNode.getResource(ElementName.PREVIEW, EnumUsage.Output, 0), EnumUsage.Output, null);
         JDFPreview pv = (JDFPreview)theNode.getCreateResource(ElementName.PREVIEW, EnumUsage.Output, 0);
         pv.setResStatus(EnumResStatus.Incomplete, false);
         pv.setPreviewUsage(EnumPreviewUsage.Separation);
         pv.setPartUsage(EnumPartUsage.Explicit);
         pv.setPreviewFileType(EnumPreviewFileType.PNG);

         if (vParts != null)
         {
            for (int i = 0; i < vParts.Count; i++)
            {
               JDFAttributeMap part = vParts[i];
               JDFPreview pvp = (JDFPreview)pv.getCreatePartition(part, partIDKeys);
               int ncols = "Front".Equals(part.get("Side")) ? nCols[0] : nCols[1];

               for (int j = 0; j < ncols; j++)
               {
                  pvp.getCreatePartition(EnumPartIDKey.Separation, cols.stringAt(j), partIDKeys);
                  pvp.setResStatus(EnumResStatus.Incomplete, false);
               }
            }
         }
      }

      ///   
      ///	 * <param name="icsLevel"> </param>
      ///	 
      protected internal virtual void initPreviewComp()
      {
         if (theParentNode != null)
            theNode.ensureLink(theParentNode.getResource(ElementName.PREVIEW, EnumUsage.Output, 0), EnumUsage.Output, null);
         JDFPreview pv = (JDFPreview)theNode.getCreateResource(ElementName.PREVIEW, EnumUsage.Output, 0);
         pv.setResStatus(EnumResStatus.Incomplete, false);
         pv.setPreviewUsage(EnumPreviewUsage.Viewable);
         pv.setPartUsage(EnumPartUsage.Explicit);
         pv.setPreviewFileType(EnumPreviewFileType.PNG);

         if (vParts != null)
         {
            VJDFAttributeMap vRedParts = getReducedMap(new VString("Separation", null));
            for (int i = 0; i < vRedParts.Count; i++)
            {
               JDFAttributeMap part = vParts[i];
               JDFPreview pvp = (JDFPreview)pv.getCreatePartition(part, partIDKeys);
               pvp.setResStatus(EnumResStatus.Incomplete, false);

            }
         }
      }

      ///   
      ///	 <summary> * prepare an mis fuzzy node and make it runnable by the device
      ///	 *  </summary>
      ///	 
      public override void makeReady()
      {
         base.makeReady();
         makeReadyPreviewGeneration();
      }

      ///   
      ///	 <summary> *  </summary>
      ///	 

      ///   
      ///	 <summary> *  </summary>
      ///	 
      private void makeReadyPreviewGeneration()
      {
         VString v = theExpandedNode.getAllTypes();
         if (v != null && v.Contains(EnumType.PreviewGeneration.getName()))
         {
            JDFPreviewGenerationParams pgp = (JDFPreviewGenerationParams)theExpandedNode.getCreateResource(ElementName.PREVIEWGENERATIONPARAMS, EnumUsage.Input, 0);
            pgp.setPreviewUsage(JDFPreviewGenerationParams.EnumPreviewUsage.Separation);
         }
      }

      ///   
      ///	 <summary> * @return </summary>
      ///	 
      public virtual JDFMedia getPlateMedia()
      {
         if (theNode == null)
            return null;
         for (int i = 0; i < 10; i++)
         {
            JDFMedia plate = (JDFMedia)theNode.getResource(ElementName.MEDIA, EnumUsage.Input, i);
            if (plate == null)
               return null;
            if (EnumMediaType.Plate.Equals(plate.getMediaType()))
               return plate;
         }
         return null;
      }
   }
}
