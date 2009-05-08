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

   using EnumComponentType = org.cip4.jdflib.auto.JDFAutoComponent.EnumComponentType;
   using EnumDeviceStatus = org.cip4.jdflib.auto.JDFAutoDeviceInfo.EnumDeviceStatus;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using VString = org.cip4.jdflib.core.VString;
   using EnumNodeStatus = org.cip4.jdflib.core.JDFElement.EnumNodeStatus;
   using EnumVersion = org.cip4.jdflib.core.JDFElement.EnumVersion;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using EnumType = org.cip4.jdflib.node.JDFNode.EnumType;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFComponent = org.cip4.jdflib.resource.process.JDFComponent;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;

   ///
   /// <summary> * @author Rainer Prosi class that generates golden tickets based on ICS levels etc </summary>
   /// 
   public class MISFinGoldenTicket : MISGoldenTicket
   {
      ///   
      ///     <summary> *  </summary>
      ///     
      public const string MISFIN_SHEETFIN = "MISFIN.SheetFin";
      ///   
      ///	 <summary> * MIS FIN GB Type </summary>
      ///	 
      public const string MISFIN_BOXMAKING = "MISFIN.BoxMaking";
      ///   
      ///	 <summary> * MIS FIN GB Type </summary>
      ///	 
      public const string MISFIN_INSERTFIN = "MISFIN.InsertFin";
      ///   
      ///	 <summary> * MIS FIN GB Type </summary>
      ///	 
      public const string MISFIN_STITCHFIN = "MISFIN.StitchFin";
      ///   
      ///	 <summary> * MIS FIN GB Type </summary>
      ///	 
      public const string MISFIN_SOFTCOVERFIN = "MISFIN.SoftcoverFin";
      ///   
      ///	 <summary> * MIS FIN GB Type </summary>
      ///	 
      public const string MISFIN_HARDCOVERFIN = "MISFIN.HardcoverFin";

      protected internal int icsLevel;

      ///   
      ///	 <summary> * create a BaseGoldenTicket
      ///	 *  </summary>
      ///	 * <param name="icsLevel"> the level to init to (1,2 or 3) </param>
      ///	 * <param name="jdfVersion"> the version to generate a golden ticket for </param>
      ///	 * <param name="jmfLevel"> level of jmf ICS to support </param>
      ///	 * <param name="misLevel"> level of MIS ICS to support </param>
      ///	 * <param name="isGrayBox"> if true, write a grayBox </param>
      ///	 
      public MISFinGoldenTicket(int _icsLevel, EnumVersion jdfVersion, int _jmfLevel, int _misLevel, bool isGrayBox, VJDFAttributeMap vPartMap)
         : base(_misLevel, jdfVersion, _jmfLevel)
      {

         catMap.Add(MISFIN_SHEETFIN, new VString("Cutting Folding", null));
         partIDKeys = new VString("SignatureName,SheetName", ",");
         vParts = vPartMap;
         icsLevel = _icsLevel;
      }

      ///   
      ///     <summary> *  </summary>
      ///     
      protected internal override void fillCatMaps()
      {
         base.fillCatMaps();
         catMap.Add(MISFIN_BOXMAKING, new VString(EnumType.BoxFolding.getName(), null));

         catMap.Add(MISFIN_HARDCOVERFIN, new VString("BlockPreparation CaseMaking CasingIn", null));

         catMap.Add(MISFIN_INSERTFIN, new VString("Inserting Trimming", null));
         catMap.Add(MISFIN_SHEETFIN, new VString("Folding", null));
         catMap.Add(MISFIN_SOFTCOVERFIN, new VString("Gathering CoverApplication Trimming", null));
         catMap.Add(MISFIN_STITCHFIN, new VString("Stitching Trimming", null));
      }

      ///   
      ///	 <summary> * create a BaseGoldenTicket
      ///	 *  </summary>
      ///	 * <param name="parent"> the previous node, may be null </param>
      ///	 
      public MISFinGoldenTicket(MISFinGoldenTicket parent)
         : base(parent)
      {
      }

      ///   
      ///	 <summary> * initializes this node to a given ICS version
      ///	 *  </summary>
      ///	 * <param name="icsLevel"> the level to init to (1,2 or 3) </param>
      ///	 
      public override void init()
      {
         base.init();
      }

      public override void setActivePart(VJDFAttributeMap vp, bool bFirst)
      {
         amountLinks = null;
         if (bFirst)
            addAmountLink("Componenet:Input");
         addAmountLink("Component:Output");
         base.setActivePart(vp, bFirst);
      }

      ///   
      ///	 <summary> *  </summary>
      ///	 
      protected internal override JDFComponent initOutputComponent()
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
            outComp.setDescriptiveName("MIS-Fin output Component");
         }

         // outComp.getCreateLayout();
         JDFMedia inMedia = (JDFMedia)theNode.getResource(ElementName.MEDIA, EnumUsage.Input, 0);
         outComp.setDimensions(inMedia.getDimension());

         return outComp;

      }

      protected internal override void runphases(int pgood, int pwaste, bool bOutAvail, bool bFirst)
      {
         theStatusCounter.setPhase(EnumNodeStatus.InProgress, "Good", EnumDeviceStatus.Running, "Printing");
         runSinglePhase(pgood, pwaste, bOutAvail, bFirst);
         //finalize(); // prior to processRun
         theStatusCounter.setPhase(EnumNodeStatus.Completed, "Done", EnumDeviceStatus.Idle, "Waiting");
      }

      public override void assign(JDFNode node)
      {
         base.assign(node);
         theNode.getCreateNodeInfo().setPartIDKeys(partIDKeys);
      }
   }
}
