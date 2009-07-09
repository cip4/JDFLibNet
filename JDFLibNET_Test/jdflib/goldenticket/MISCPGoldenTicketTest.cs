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
   using Microsoft.VisualStudio.TestTools.UnitTesting;

   using EnumWorkStyle = org.cip4.jdflib.auto.JDFAutoConventionalPrintingParams.EnumWorkStyle;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using JDFAudit = org.cip4.jdflib.core.JDFAudit;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using VString = org.cip4.jdflib.core.VString;
   using EnumVersion = org.cip4.jdflib.core.JDFElement.EnumVersion;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using EnumValidationLevel = org.cip4.jdflib.core.KElement.EnumValidationLevel;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using EnumType = org.cip4.jdflib.node.JDFNode.EnumType;
   using JDFDevice = org.cip4.jdflib.resource.JDFDevice;
   using EnumPartIDKey = org.cip4.jdflib.resource.JDFResource.EnumPartIDKey;

   [TestClass]
   public class MISCPGoldenTicketTest : BaseGoldenTicketTest
   {

      [TestMethod]
      public virtual void testMISCPGrayBoxFrontBack()
      {
         VJDFAttributeMap vMap = new VJDFAttributeMap();
         JDFAttributeMap map = new JDFAttributeMap();
         map.put(EnumPartIDKey.SignatureName, "Sig1");
         map.put(EnumPartIDKey.SheetName, "Sheet1");
         map.put(EnumPartIDKey.Side, "Front");
         vMap.Add(new JDFAttributeMap(map));
         map.put(EnumPartIDKey.Side, "Back");
         vMap.Add(new JDFAttributeMap(map));
         MISCPGoldenTicket cpGoldenTicket = new MISCPGoldenTicket(1, null, 2, 2, true, vMap);
         cpGoldenTicket.nCols[0] = cpGoldenTicket.nCols[1] = 4;

         cpGoldenTicket.assign(null);
         JDFNode node = cpGoldenTicket.getNode();
         cpGoldenTicket.write2File(sm_dirTestDataTemp + "GoldenTicket_Manager_MISCPS_1_GB.jdf", 2);
         Assert.IsTrue(node.getICSVersions(false).Contains("Base_L2-1.3"));
         Assert.IsTrue(node.getICSVersions(false).Contains("JMF_L2-1.3"));
         Assert.IsTrue(node.getICSVersions(false).Contains("MIS_L2-1.3"));
         Assert.IsTrue(node.getICSVersions(false).Contains("MISCPS_L1-1.3"));
         Assert.IsTrue(node.isValid(EnumValidationLevel.Complete));

         cpGoldenTicket.good = 1000;
         cpGoldenTicket.waste = 90;
         cpGoldenTicket.execute(null, true, true);
         cpGoldenTicket.makeReadyAll();
         node = cpGoldenTicket.getNode();
         cpGoldenTicket.write2File(sm_dirTestDataTemp + "GoldenTicket_Worker_MISCPS_1_GB.jdf", 2);
         Assert.IsTrue(node.getICSVersions(false).Contains("Base_L2-1.3"));
         Assert.IsTrue(node.getICSVersions(false).Contains("JMF_L2-1.3"));
         Assert.IsTrue(node.getICSVersions(false).Contains("MIS_L2-1.3"));
         Assert.IsTrue(node.getICSVersions(false).Contains("MISCPS_L1-1.3"));
         Assert.IsTrue(node.isValid(EnumValidationLevel.Complete));

         cpGoldenTicket.assign(null);
         VJDFAttributeMap mapSingle = new VJDFAttributeMap();
         map.put(EnumPartIDKey.Side, "Front");
         mapSingle.Add(map);
         cpGoldenTicket.schedule(mapSingle, 6, 2);
         map.put(EnumPartIDKey.Side, "Back");
         cpGoldenTicket.schedule(mapSingle, 8, 2);

         cpGoldenTicket.write2File(sm_dirTestDataTemp + "GoldenTicket_Manager_MISCPS_1_GB_FrontBack.jdf", 2);
         map.put(EnumPartIDKey.Side, "Front");
         cpGoldenTicket.execute(mapSingle, false, true);
         cpGoldenTicket.write2File(sm_dirTestDataTemp + "GoldenTicket_Worker_MISCPS_1_GB_FrontBack_xB.jdf", 2);
         map.put(EnumPartIDKey.Side, "Back");
         cpGoldenTicket.good = 900;
         cpGoldenTicket.waste = 30;
         cpGoldenTicket.execute(mapSingle, true, false);
         cpGoldenTicket.write2File(sm_dirTestDataTemp + "GoldenTicket_Worker_MISCPS_1_GB_FrontBack_xBF.jdf", 2);
      }


      [TestMethod]
      public virtual void testMISCPGrayBoxSimplexPoster()
      {
         VJDFAttributeMap vMap = new VJDFAttributeMap();
         JDFAttributeMap map = new JDFAttributeMap();
         map.put(EnumPartIDKey.SignatureName, "Sig1");
         map.put(EnumPartIDKey.SheetName, "Sheet1");
         map.put(EnumPartIDKey.Side, "Front");
         vMap.Add(new JDFAttributeMap(map));

         MISCPGoldenTicket cpGoldenTicket = new MISCPGoldenTicket(1, null, 2, 2, true, vMap);
         cpGoldenTicket.nCols[0] = cpGoldenTicket.nCols[1] = 6;
         cpGoldenTicket.workStyle = EnumWorkStyle.Simplex;
         cpGoldenTicket.assign(null);
         cpGoldenTicket.good = 1000;
         cpGoldenTicket.waste = 90;

         BaseGoldenTicketTest.write3GTFiles(this, cpGoldenTicket, "MISCPS_SimplexPoster");
      }


      [TestMethod]
      public virtual void testMISCPGrayBox41Poster()
      {
         VJDFAttributeMap vMap = new VJDFAttributeMap();
         JDFAttributeMap map = new JDFAttributeMap();
         map.put(EnumPartIDKey.SignatureName, "Sig1");
         map.put(EnumPartIDKey.SheetName, "Sheet1");
         map.put(EnumPartIDKey.Side, "Front");
         vMap.Add(new JDFAttributeMap(map));
         map.put(EnumPartIDKey.Side, "Back");
         vMap.Add(new JDFAttributeMap(map));

         MISCPGoldenTicket cpGoldenTicket = new MISCPGoldenTicket(1, null, 2, 2, true, vMap);
         cpGoldenTicket.nCols[0] = 4;
         cpGoldenTicket.nCols[1] = 1;
         cpGoldenTicket.workStyle = EnumWorkStyle.WorkAndTurn;
         cpGoldenTicket.assign(null);
         cpGoldenTicket.good = 1000;
         cpGoldenTicket.waste = 90;
         cpGoldenTicket.partsAtOnce = 1;
         cpGoldenTicket.partsForAvailable = 2;

         JDFNode n = cpGoldenTicket.getNode();
         JDFDevice dev = (JDFDevice)n.getResource("Device", EnumUsage.Input, 0);
         dev.removeAttribute(AttributeName.DEVICEID);
         dev.getCreatePartition(map, null).setAttribute("DeviceID", "BackSidePress");
         map.put(EnumPartIDKey.Side, "Front");
         dev.getCreatePartition(map, null).setAttribute("DeviceID", "FrontSidePress");

         write3GTFiles(this, cpGoldenTicket, "MISCPS_4_1Poster");
      }


      [TestMethod]
      public virtual void testMISCPProductGrayBoxBrochure()
      {

         VJDFAttributeMap vMap = new VJDFAttributeMap();
         for (int i = 0; i < 5; i++)
         {
            string sheetName = i == 0 ? "Cover" : "Body" + i;
            JDFAttributeMap map = new JDFAttributeMap();
            map.put(EnumPartIDKey.SignatureName, "Sig1");
            map.put(EnumPartIDKey.SheetName, sheetName);
            map.put(EnumPartIDKey.Side, "Front");
            vMap.Add(new JDFAttributeMap(map));
            map.put(EnumPartIDKey.Side, "Back");
            vMap.Add(new JDFAttributeMap(map));
         }

         MISCPGoldenTicket cpGoldenTicket = new MISCPGoldenTicket(1, null, 2, 2, true, vMap);
         cpGoldenTicket.nCols[0] = cpGoldenTicket.nCols[1] = 6;
         cpGoldenTicket.workStyle = EnumWorkStyle.WorkAndTurn;

         ProductGoldenTicket pgt = new ProductGoldenTicket(0, EnumVersion.Version_1_3, 0, 0);
         pgt.assign(null);
         pgt.createHDCity();
         JDFNode node = pgt.getNode();
         JDFNode nodeCP = node.addJDFNode(EnumType.ProcessGroup);

         cpGoldenTicket.assign(nodeCP);
         cpGoldenTicket.good = 1000;
         cpGoldenTicket.waste = 90;

         cpGoldenTicket.partsAtOnce = 2;
         BaseGoldenTicketTest.write3GTFiles(this, cpGoldenTicket, "MISCPS_ProductGrayBox");
      }

      ///   
      ///	 <summary> * test identical inks using black + text </summary>
      ///	 
      [TestMethod]
      public virtual void testIdenticalInk()
      {
         VString v = new VString("Cyan,Magenta,Yellow,Black,Text", ",");
         VString vAct = new VString("Cyan,Magenta,Yellow,Black,Text", ",");
         VString vInk = new VString("Cyan,Magenta,Yellow,Black,Black", ",");
         VString vInkProd = new VString("MIS-Ink-4711,MIS-Ink-4712,MIS-Ink-4713,MIS-Ink-4714,MIS-Ink-4714", ",");
         VJDFAttributeMap vMap = new VJDFAttributeMap();
         JDFAttributeMap map = new JDFAttributeMap();
         map.put(EnumPartIDKey.SignatureName, "Sig1");
         map.put(EnumPartIDKey.SheetName, "Sheet1");
         map.put(EnumPartIDKey.Side, "Front");
         vMap.Add(new JDFAttributeMap(map));

         JDFNode n = new JDFDoc("JDF").getJDFRoot();
         MISCPGoldenTicket cpGoldenTicket = new MISCPGoldenTicket(1, null, 2, 1, true, vMap);
         cpGoldenTicket.cols = v;
         cpGoldenTicket.colsActual = vAct;
         cpGoldenTicket.inks = vInk;
         cpGoldenTicket.inkProductIDs = vInkProd;

         // n.setType(JDFNode.EnumType.ConventionalPrinting);

         cpGoldenTicket.assign(n);
         cpGoldenTicket.good = 3000;
         cpGoldenTicket.waste = 200;
         write3GTFiles(this, cpGoldenTicket, "sameInk");
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.JDFTestCaseBase#setUp()
      //	 
      [TestInitialize]
      public override void setUp()
      {
         base.setUp();
         JDFAudit.setStaticAgentName("JDF MISCP golden ticket generator");
      }
   }
}
