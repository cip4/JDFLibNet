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
 * MISFinTest.cs
 * @author muchadie
 */

namespace org.cip4.jdflib.examples
{
   using Microsoft.VisualStudio.TestTools.UnitTesting;


   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using EnumBundleType = org.cip4.jdflib.auto.JDFAutoBundle.EnumBundleType;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using VString = org.cip4.jdflib.core.VString;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using EnumType = org.cip4.jdflib.node.JDFNode.EnumType;
   using JDFBundle = org.cip4.jdflib.resource.JDFBundle;
   using JDFBundleItem = org.cip4.jdflib.resource.JDFBundleItem;
   using EnumPartIDKey = org.cip4.jdflib.resource.JDFResource.EnumPartIDKey;
   using EnumResStatus = org.cip4.jdflib.resource.JDFResource.EnumResStatus;
   using JDFComponent = org.cip4.jdflib.resource.process.JDFComponent;

   [TestClass]
   public class MISFinTest : JDFTestCaseBase
   {
      ///   
      ///	 <summary> * test MIS to Finishing ICS
      ///	 * 
      ///	 * @return </summary>
      ///	 
      [TestMethod]
      public virtual void testAmount()
      {
         JDFElement.setLongID(false);
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setType(EnumType.ProcessGroup);
         n.setTypes(new VString("Binding Stacking BoxPacking Palletizing", " "));
         JDFComponent comp = (JDFComponent)n.addResource(ElementName.COMPONENT, null, EnumUsage.Output, null, null, null, null);
         JDFResourceLink rl = n.getLink(comp, null);
         rl.setAmount(2, null);
         rl.setDescriptiveName("The link point to 2 pallets with a total comtent of 10000 brochures in 200 boxes");

         // create a pallet partition - may also use the root
         JDFComponent compPallet = (JDFComponent)comp.addPartition(EnumPartIDKey.DeliveryUnit0, "Pallet");

         JDFComponent compBox = (JDFComponent)compPallet.addPartition(EnumPartIDKey.DeliveryUnit1, "Box");
         JDFBundle bundlePallet = compPallet.appendBundle();
         bundlePallet.setDescriptiveName("Bundle describing 100 boxes with 5000 Brochures Contents total");
         bundlePallet.setTotalAmount(5000);
         bundlePallet.setBundleType(EnumBundleType.Pallet);
         JDFBundleItem biBoxes = bundlePallet.appendBundleItem();
         biBoxes.refElement(compBox);
         biBoxes.setAmount(100);

         JDFComponent compBrochure = (JDFComponent)compBox.addPartition(EnumPartIDKey.DeliveryUnit2, "Brochure");
         JDFBundle bundleBox = compBox.appendBundle();
         bundleBox.setDescriptiveName("Bundle describing 1 boxes with 50 Brochures Contents per box");
         bundleBox.setTotalAmount(50);
         bundleBox.setBundleType(EnumBundleType.Box);

         JDFBundleItem biBrochures = bundleBox.appendBundleItem();
         biBrochures.refElement(compBrochure);
         biBrochures.setAmount(50);

         JDFBundle bundleBrochure = compBrochure.appendBundle();
         bundleBrochure.setDescriptiveName("Dummy Bundle to inhibit inheritence of the box Bundle");
         d.write2File(sm_dirTestDataTemp + "MISFinAmount.jdf", 2, false);
      }


      [TestMethod]
      public virtual void testAmountPalletteManifest()
      {
         JDFElement.setLongID(false);
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setType(EnumType.ProcessGroup);
         n.setTypes(new VString("Binding Stacking BoxPacking Palletizing", " "));
         JDFComponent comp = (JDFComponent)n.addResource(ElementName.COMPONENT, null, EnumUsage.Output, null, null, null, null);
         JDFResourceLink rl = n.getLink(comp, null);
         rl.setAmount(2, null);
         rl.setDescriptiveName("The link point to 2 pallets with a total comtent of 10000 brochures in 200 boxes");
         JDFComponent compBrochure = (JDFComponent)n.addResource(ElementName.COMPONENT, null, EnumUsage.Input, null, null, null, null);
         compBrochure.setResStatus(EnumResStatus.Available, true);
         compBrochure.setDescriptiveName("The individual Brochures");
         JDFResourceLink rlB = n.getLink(compBrochure, null);
         rlB.setAmount(10000, null);
         rlB.setActualAmount(9700, null);

         for (int i = 0; i < 2; i++)
         {
            // create a pallet partition - may also use the root
            JDFComponent compPallet = (JDFComponent)comp.addPartition(EnumPartIDKey.DeliveryUnit0, "Pallet" + i);
            compPallet.setProductID("Pallet_" + i);

            JDFBundle bundlePallet = compPallet.getCreateBundle();
            int nBox = i == 0 ? 100 : 94;
            bundlePallet.setDescriptiveName("Pallet Bundle describing " + nBox + " boxes with " + nBox * 50 + " Brochures Contents total");
            bundlePallet.setTotalAmount(nBox * 50);
            bundlePallet.setBundleType(EnumBundleType.Pallet);
            JDFBundleItem biBoxes = bundlePallet.appendBundleItem();

            JDFComponent compBox = (JDFComponent)compPallet.addPartition(EnumPartIDKey.DeliveryUnit1, "Box");
            biBoxes.refElement(compBox);
            biBoxes.setAmount(nBox);

            JDFBundle bundleBox = compBox.appendBundle();
            bundleBox.setDescriptiveName("Bundle describing 1 boxes with 50 Brochures Contents per box");
            bundleBox.setTotalAmount(50);
            bundleBox.setBundleType(EnumBundleType.Box);

            JDFBundleItem biBrochures = bundleBox.appendBundleItem();
            biBrochures.refElement(compBrochure);
            biBrochures.setAmount(50);
         }

         d.write2File(sm_dirTestDataTemp + "MISFinAmountManifest.jdf", 2, false);
      }


      [TestMethod]
      public virtual void testAmountPalletteCompleteManifest()
      {
         JDFElement.setLongID(false);
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setType(EnumType.ProcessGroup);
         n.setTypes(new VString("Binding Stacking BoxPacking Palletizing", " "));
         JDFComponent comp = (JDFComponent)n.addResource(ElementName.COMPONENT, null, EnumUsage.Output, null, null, null, null);
         JDFResourceLink rl = n.getLink(comp, null);
         rl.setAmount(2, null);
         rl.setDescriptiveName("The link point to 2 pallets with a total comtent of 10000 brochures in 200 boxes");
         JDFComponent compBrochure = (JDFComponent)n.addResource(ElementName.COMPONENT, null, EnumUsage.Input, null, null, null, null);
         compBrochure.setResStatus(EnumResStatus.Available, true);
         compBrochure.setDescriptiveName("The individual Brochures");
         JDFResourceLink rlB = n.getLink(compBrochure, null);
         rlB.setAmount(10000, null);
         rlB.setActualAmount(9700, null);

         for (int i = 0; i < 2; i++)
         {
            // create a pallet partition - may also use the root
            JDFComponent compPallet = (JDFComponent)comp.addPartition(EnumPartIDKey.DeliveryUnit0, "Pallet" + i);
            compPallet.setProductID("Pallet_" + i);

            JDFBundle bundlePallet = compPallet.getCreateBundle();
            int nBox = i == 0 ? 100 : 94;
            bundlePallet.setDescriptiveName("Pallet Bundle describing " + nBox + " boxes with " + nBox * 50 + " Brochures Contents total");
            bundlePallet.setTotalAmount(nBox * 50);
            bundlePallet.setBundleType(EnumBundleType.Pallet);

            for (int j = 0; j < nBox; j++)
            {
               JDFBundleItem biBoxes = bundlePallet.appendBundleItem();
               JDFComponent compBox = (JDFComponent)compPallet.addPartition(EnumPartIDKey.DeliveryUnit1, "Box_" + i + "_" + j);
               compBox.setProductID("Box_" + i + "_" + j);
               biBoxes.refElement(compBox);
               biBoxes.setAmount(1);

               JDFBundle bundleBox = compBox.appendBundle();
               bundleBox.setDescriptiveName("Bundle describing box #" + j + " with 50 Brochures Contents per box");
               bundleBox.setTotalAmount(50);
               bundleBox.setBundleType(EnumBundleType.Box);

               JDFBundleItem biBrochures = bundleBox.appendBundleItem();
               biBrochures.refElement(compBrochure);
               biBrochures.setAmount(50);
            }
         }

         d.write2File(sm_dirTestDataTemp + "MISFinAmountCompleteManifest.jdf", 2, false);
      }
   }
}
