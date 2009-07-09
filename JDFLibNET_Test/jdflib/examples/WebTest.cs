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
 * WebTest.cs
 * @author muchadie
 */

namespace org.cip4.jdflib.examples
{
   using Microsoft.VisualStudio.TestTools.UnitTesting;


   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using EnumSide = org.cip4.jdflib.auto.JDFAutoPart.EnumSide;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFNodeInfo = org.cip4.jdflib.core.JDFNodeInfo;
   using KElement = org.cip4.jdflib.core.KElement;
   using VString = org.cip4.jdflib.core.VString;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using JDFMatrix = org.cip4.jdflib.datatypes.JDFMatrix;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using EnumProcessUsage = org.cip4.jdflib.node.JDFNode.EnumProcessUsage;
   using EnumType = org.cip4.jdflib.node.JDFNode.EnumType;
   using JDFResourcePool = org.cip4.jdflib.pool.JDFResourcePool;
   using JDFMarkObject = org.cip4.jdflib.resource.JDFMarkObject;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using EnumPartIDKey = org.cip4.jdflib.resource.JDFResource.EnumPartIDKey;
   using EnumResStatus = org.cip4.jdflib.resource.JDFResource.EnumResStatus;
   using EnumResourceClass = org.cip4.jdflib.resource.JDFResource.EnumResourceClass;
   using JDFByteMap = org.cip4.jdflib.resource.process.JDFByteMap;
   using JDFContentObject = org.cip4.jdflib.resource.process.JDFContentObject;
   using JDFExposedMedia = org.cip4.jdflib.resource.process.JDFExposedMedia;
   using JDFLayout = org.cip4.jdflib.resource.process.JDFLayout;
   using JDFRunList = org.cip4.jdflib.resource.process.JDFRunList;

   [TestClass]
   public class WebTest : JDFTestCaseBase
   {
      private JDFNode node;
      private JDFNodeInfo nodeInfo;
      private JDFDoc doc;

      ///   
      ///	 <summary> * test WebGrowth Compensation </summary>
      ///	 
      [TestMethod]
      public virtual void testWebGrowthCompensation()
      {

         JDFElement.setLongID(false);
         doc = new JDFDoc("JDF");
         JDFNode n = doc.getJDFRoot();
         JDFResourcePool rp = n.getCreateResourcePool();
         JDFResource lo = n.addResource("Layout", EnumResourceClass.Parameter, EnumUsage.Input, null, null, null, null);
         JDFLayout losh = (JDFLayout)lo.addPartition(EnumPartIDKey.SheetName, "Sheet1");
         JDFLayout lofr = (JDFLayout)losh.addPartition(EnumPartIDKey.Side, EnumSide.Front.getName());

         rp.appendXMLComment("LayoutShift SHOULD be partitioned: at least Side and Separation will make sense", null);

         JDFResource los = n.addResource("LayoutShift", EnumResourceClass.Parameter, EnumUsage.Input, null, null, null, null);
         los.appendXMLComment("Note that the interpolation algorithm between positions is implementation dependent", null);
         los = los.addPartition(EnumPartIDKey.Side, "Front");
         VString vSep = new VString("Cyan Magenta Yellow Black", " ");

         for (int i = 0; i < 16; i++)
         {
            int x = 720 * (i % 4);
            int y = 1000 * (i / 4);
            int ord = i % 8;
            JDFContentObject co = lofr.appendContentObject();
            co.setOrd(ord);
            co.setOrdID(i);
            co.setCTM(new JDFMatrix(1, 0, 0, 1, x, y));
            JDFMarkObject mo = lofr.appendMarkObject();
            mo.setOrd(ord);
            mo.setOrdID(i + 100);
            mo.setCTM(new JDFMatrix(1, 0, 0, 1, x + 700, y + 900));
         }
         for (int j = 0; j < vSep.Count; j++)
         {
            KElement sepShift = los.addPartition(EnumPartIDKey.Separation, vSep.stringAt(j));
            for (int i = 0; i < 16; i += 2)
            {

               int x = 720 * (i % 4);
               int y = 1000 * (i / 4);
               KElement shiftObject = sepShift.appendElement("ShiftPoint");

               shiftObject.setAttribute("Position", new JDFXYPair(x + 360, y + 500).ToString());
               shiftObject.setAttribute("CTM", new JDFMatrix(1, 0, 0, 1, j + i / 4, j + i % 4).ToString());
            }
         }
         doc.write2File(sm_dirTestDataTemp + "WebgrowthPartition.jdf", 2, false);
      }

      ///   
      ///	 <summary> * test direct imaging </summary>
      ///	 
      [TestMethod]
      public virtual void testDirectImage()
      {
         JDFElement.setLongID(false);
         doc = new JDFDoc("JDF");
         node = doc.getJDFRoot();
         node.setType(EnumType.Combined);
         VString vTypes = new VString("ImageSetting ConventionalPrinting", " ");
         node.setTypes(vTypes);
         nodeInfo = node.appendNodeInfo();
         nodeInfo.setResStatus(EnumResStatus.Available, true);
         JDFRunList rl = (JDFRunList)node.appendMatchingResource(ElementName.RUNLIST, EnumProcessUsage.AnyInput, null);
         JDFByteMap bm = rl.appendByteMap();
         bm.appendFileSpec().setURL("FileInfo:///foo.tif");
         JDFExposedMedia xm = (JDFExposedMedia)node.appendMatchingResource(ElementName.EXPOSEDMEDIA, EnumProcessUsage.Plate, null);
         xm.setDescriptiveName("Real Plate");
         xm.appendMedia();
         JDFExposedMedia xmCyl = (JDFExposedMedia)node.appendMatchingResource(ElementName.EXPOSEDMEDIA, EnumProcessUsage.Cylinder, null);
         xmCyl.setDescriptiveName("Optional cylinder");
         node.linkMatchingResource(xmCyl, EnumProcessUsage.AnyOutput, null);
         Assert.AreEqual(3, node.getResourceLinkPool().numChildElements("ExposedMediaLink", null), "2 for cylinder one for plate");
         doc.write2File(sm_dirTestDataTemp + "webDirect.jdf", 2, false);

      }

      [TestMethod]
      public virtual void testSplitDuct()
      {
         // TODO
      }
   }
}
