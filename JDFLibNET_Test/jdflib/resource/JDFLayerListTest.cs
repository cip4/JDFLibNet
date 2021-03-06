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


namespace org.cip4.jdflib.resource
{
   using Microsoft.VisualStudio.TestTools.UnitTesting;


   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using VString = org.cip4.jdflib.core.VString;
   using EnumNodeStatus = org.cip4.jdflib.core.JDFElement.EnumNodeStatus;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using JDFIntegerRange = org.cip4.jdflib.datatypes.JDFIntegerRange;
   using JDFIntegerRangeList = org.cip4.jdflib.datatypes.JDFIntegerRangeList;
   using JDFMatrix = org.cip4.jdflib.datatypes.JDFMatrix;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using EnumProcessUsage = org.cip4.jdflib.node.JDFNode.EnumProcessUsage;
   using EnumType = org.cip4.jdflib.node.JDFNode.EnumType;
   using EnumPartIDKey = org.cip4.jdflib.resource.JDFResource.EnumPartIDKey;
   using EnumPartUsage = org.cip4.jdflib.resource.JDFResource.EnumPartUsage;
   using EnumResStatus = org.cip4.jdflib.resource.JDFResource.EnumResStatus;
   using JDFContentObject = org.cip4.jdflib.resource.process.JDFContentObject;
   using JDFLayout = org.cip4.jdflib.resource.process.JDFLayout;
   using JDFRunList = org.cip4.jdflib.resource.process.JDFRunList;

   [TestClass]
   public class JDFLayerListTest : JDFTestCaseBase
   {
      private JDFRunList rlIn;
      private JDFRunList rlOut;
      private JDFNode n;
      private JDFDoc d;

      ///   
      ///	 <summary> * test layer runlist
      ///	 * 
      ///	 * @return </summary>
      ///	 
      [TestMethod]
      public virtual void testLayerRunList()
      {
         JDFElement.setLongID(false);
         setUpDoc();
         JDFIntegerRangeList pageRange = new JDFIntegerRangeList(new JDFIntegerRange(0, -1, 16));
         rlIn.setDescriptiveName("Layers are just another partversion layer selection in the link is achieved using multiple partversions");

         JDFRunList rlAll = (JDFRunList)rlIn.addPartition(EnumPartIDKey.PartVersion, "CMYK");
         rlAll.setFileURL("background.pdf");
         rlAll.setPages(pageRange);

         JDFRunList rlEn = (JDFRunList)rlIn.addPartition(EnumPartIDKey.PartVersion, "FR");
         rlEn.setFileURL("Francais.pdf");
         rlEn.setPages(pageRange);
         rlEn.setLogicalPage(16);

         JDFRunList rlDe = (JDFRunList)rlIn.addPartition(EnumPartIDKey.PartVersion, "De");
         rlDe.setFileURL("deutsch.pdf");
         rlDe.setPages(pageRange);
         rlDe.setLogicalPage(16);

         setupLayout(false);

         n.setPartStatus(new JDFAttributeMap(EnumPartIDKey.PartVersion, "De"), EnumNodeStatus.Completed, null);
         JDFResourceLink rl = n.getLink(rlIn, null);
         rl.setPartition(EnumPartIDKey.PartVersion, "CMYK De");
         d.write2File(sm_dirTestDataTemp + "LayerList.jdf", 2, false);
         rl.setPartition(EnumPartIDKey.PartVersion, "De");
         rl.setDescriptiveName("Only DE, no bkg partversion is selected");
         d.write2File(sm_dirTestDataTemp + "LayerList_BKG.jdf", 2, false);
      }

      ///   
      ///	 <summary> * test layer runlist
      ///	 * 
      ///	 * @return </summary>
      ///	 
      [TestMethod]
      public virtual void testLayerRunListWithLL()
      {
         JDFElement.setLongID(false);
         setUpDoc();
         setupRunList(0);

         setupLayout(false);

         n.setPartStatus(new JDFAttributeMap(EnumPartIDKey.PartVersion, "De"), EnumNodeStatus.Completed, null);
         JDFResourceLink rl = n.getLink(rlIn, null);
         rl.setPartition(EnumPartIDKey.PartVersion, "De");
         d.write2File(sm_dirTestDataTemp + "LayerListWithLL.jdf", 2, false);
         JDFAttributeMap map = new JDFAttributeMap();
         map.put(EnumPartIDKey.PartVersion, "De");
         map.put(EnumPartIDKey.LayerIDs, "1");
         rl.setPartMap(map);
         rl.setDescriptiveName("Only DE, no bkg partversion is selected");
         d.write2File(sm_dirTestDataTemp + "LayerListWithLL_BKG.jdf", 2, false);
      }

      ///   
      ///	 <summary> * test layer runlist
      ///	 * 
      ///	 * @return </summary>
      ///	 
      [TestMethod]
      public virtual void testLayerRunListComplex()
      {
         JDFElement.setLongID(false);
         setUpDoc();
         setupRunList(1);
         setupLayout(true);

         n.setPartStatus(new JDFAttributeMap(EnumPartIDKey.PartVersion, "De"), EnumNodeStatus.Completed, null);
         JDFResourceLink rl = n.getLink(rlIn, null);
         rl.setPartition(EnumPartIDKey.PartVersion, "De Euro");
         d.write2File(sm_dirTestDataTemp + "LayerListDeEuro.jdf", 2, false);

         VJDFAttributeMap vMap = new VJDFAttributeMap();
         JDFAttributeMap map = new JDFAttributeMap();
         map.put(EnumPartIDKey.PartVersion, "De");
         map.put(EnumPartIDKey.LayerIDs, "1");
         vMap.Add(map);

         map = new JDFAttributeMap();
         map.put(EnumPartIDKey.PartVersion, "Euro");
         map.put(EnumPartIDKey.LayerIDs, "2");
         vMap.Add(map);
         rl.setPartMapVector(vMap);

         rl.setDescriptiveName("Only DE + Euro, no bkg partversion is selected");
         d.write2File(sm_dirTestDataTemp + "LayerListDeEuro_BKG.jdf", 2, false);
      }

      ///   
      ///	 <summary> * test layer runlist
      ///	 * 
      ///	 * @return </summary>
      ///	 
      [TestMethod]
      public virtual void testLayerRunListIdentical()
      {
         JDFElement.setLongID(false);
         setUpDoc();
         setupRunList(2);
         setupLayout(true);

         n.setPartStatus(new JDFAttributeMap(EnumPartIDKey.PartVersion, "De"), EnumNodeStatus.Completed, null);
         JDFResourceLink rl = n.getLink(rlIn, null);
         rl.setPartition(EnumPartIDKey.PartVersion, "De");
         d.write2File(sm_dirTestDataTemp + "LayerListDeEuroIdentical.jdf", 2, false);

         JDFAttributeMap map = new JDFAttributeMap();
         map.put(EnumPartIDKey.PartVersion, "De");
         map.put(EnumPartIDKey.LayerIDs, "1 2");

         rl.setPartMap(map);

         rl.setDescriptiveName("Only Language + Currency, no bkg partversion is selected");
         d.write2File(sm_dirTestDataTemp + "LayerListDeEuroIdentical_BKG.jdf", 2, false);
      }


      private void setupRunList(int type)
      {
         JDFIntegerRangeList pageRange = new JDFIntegerRangeList(new JDFIntegerRange(0, -1, 16));

         rlIn.setPartUsage(EnumPartUsage.Sparse);
         rlIn.setDescriptiveName("Explicitly partitioned by LayerIDs to enable layer selextion in the link");
         JDFRunList rlAll = (JDFRunList)rlIn.addPartition(EnumPartIDKey.LayerIDs, "0");
         rlAll.setFileURL("background.pdf");
         rlAll.setPages(pageRange);

         JDFRunList rlLanguage = (JDFRunList)rlIn.addPartition(EnumPartIDKey.LayerIDs, "1");
         JDFRunList rlEn = (JDFRunList)rlLanguage.addPartition(EnumPartIDKey.PartVersion, "FR");
         rlEn.setFileURL("francais.pdf");
         rlEn.setPages(pageRange);
         rlEn.setLogicalPage(16);

         JDFRunList rlDe = (JDFRunList)rlLanguage.addPartition(EnumPartIDKey.PartVersion, "De");
         rlDe.setFileURL("deutsch.pdf");
         rlDe.setPages(pageRange);
         rlDe.setLogicalPage(16);

         if (type == 1)
         {
            JDFRunList rlCurrency = (JDFRunList)rlIn.addPartition(EnumPartIDKey.LayerIDs, "2");
            JDFRunList rlEur = (JDFRunList)rlCurrency.addPartition(EnumPartIDKey.PartVersion, "Euro");
            rlEur.setFileURL("�.pdf");
            rlEur.setPages(pageRange);
            rlEur.setLogicalPage(32);
            JDFRunList rlCHF = (JDFRunList)rlCurrency.addPartition(EnumPartIDKey.PartVersion, "CHF");
            rlCHF.setFileURL("Fr�nkli.pdf");
            rlCHF.setPages(pageRange);
            rlCHF.setLogicalPage(32);
         }
         else if (type == 2)
         {
            JDFRunList rlCurrency = (JDFRunList)rlIn.addPartition(EnumPartIDKey.LayerIDs, "2");
            JDFRunList rlEur = (JDFRunList)rlCurrency.addPartition(EnumPartIDKey.PartVersion, "De");
            rlEur.setFileURL("�.pdf");
            rlEur.setPages(pageRange);
            rlEur.setLogicalPage(32);

            JDFRunList rlEur2 = (JDFRunList)rlCurrency.addPartition(EnumPartIDKey.PartVersion, "Fr");
            rlEur2.setIdentical(rlEur);

            JDFRunList rlCHF = (JDFRunList)rlCurrency.addPartition(EnumPartIDKey.PartVersion, "Ch");
            rlCHF.setFileURL("Fr�nkli.pdf");
            rlCHF.setPages(pageRange);
            rlCHF.setLogicalPage(32);

            JDFRunList rlCh = (JDFRunList)rlLanguage.addPartition(EnumPartIDKey.PartVersion, "Ch");
            rlCh.setIdentical(rlDe);
         }
      }


      private void setUpDoc()
      {
         d = new JDFDoc("JDF");
         n = d.getJDFRoot();
         n.setJobID("JobID");
         n.setType(EnumType.Imposition);
         rlIn = (JDFRunList)n.appendMatchingResource("RunList", EnumProcessUsage.AnyInput, null);
         rlIn.setResStatus(EnumResStatus.Available, false);
         rlOut = (JDFRunList)n.appendMatchingResource("RunList", EnumProcessUsage.AnyOutput, null);
      }

      ///   
      ///	 * <param name="n"> </param>
      ///	 * <param name="rlOut"> </param>
      ///	 
      private void setupLayout(bool complex)
      {
         JDFLayout lo = (JDFLayout)n.appendMatchingResource("Layout", EnumProcessUsage.AnyInput, null);
         JDFLayerList ll = lo.appendLayerList();
         const string layerNames = "BackGround Language";

         VString layers = new VString(layerNames, " ");
         if (complex)
            layers.Add("Currency");

         for (int i = 0; i < layers.Count; i++)
         {
            ll.appendLayerDetails().setName(layers.stringAt(i));
         }

         JDFRunList rlOutDe = (JDFRunList)rlOut.addPartition(EnumPartIDKey.PartVersion, "De");
         rlOutDe.setResStatus(EnumResStatus.Available, true);
         JDFRunList rlOutEn = (JDFRunList)rlOut.addPartition(EnumPartIDKey.PartVersion, "Fr");
         rlOutEn.setResStatus(EnumResStatus.Unavailable, true);
         if (complex)
         {
            JDFRunList rlOutSwiss = (JDFRunList)rlOut.addPartition(EnumPartIDKey.PartVersion, "Ch");
            rlOutSwiss.setResStatus(EnumResStatus.Unavailable, true);
         }

         for (int i = 0; i < 2; i++)
         {
            string sheetName = "Sheet" + i;
            JDFLayout lSheet = (JDFLayout)lo.addPartition(EnumPartIDKey.SheetName, sheetName);
            JDFRunList rlSheet = (JDFRunList)rlOutDe.addPartition(EnumPartIDKey.SheetName, sheetName);
            for (int j = 0; j < 2; j++)
            {
               string side = j == 0 ? "Front" : "Back";
               JDFLayout lSide = (JDFLayout)lSheet.addPartition(EnumPartIDKey.Side, side);
               JDFRunList rlSide = (JDFRunList)rlSheet.addPartition(EnumPartIDKey.Side, side);
               rlSide.setFileURL("file://out/De/" + sheetName + "_" + side + ".tif");
               for (int k = 0; k < 4; k++)
               {
                  JDFContentObject poBkg = lSide.appendContentObject();
                  int ord = i * 8 + j * 4 + k;
                  poBkg.setOrd(ord);
                  poBkg.setOrdID(ord);

                  JDFMatrix matrix = new JDFMatrix(1.0, 0.0, 0.0, 1.0, 0.0, 0.0);
                  matrix.shift((k % 2) * 200, (k / 2) * 300);
                  poBkg.setCTM(matrix);
                  poBkg.setLayerID(0);

                  JDFContentObject poLang = lSide.appendContentObject();
                  poLang.setOrd(ord + 16);
                  poLang.setOrdID(ord);
                  poLang.setCTM(matrix);
                  poLang.setLayerID(1);

                  if (complex)
                  {
                     JDFContentObject pOCurr = lSide.appendContentObject();
                     pOCurr.setOrd(ord + 32);
                     pOCurr.setOrdID(ord);
                     pOCurr.setCTM(matrix);
                     pOCurr.setLayerID(2);
                  }
               }
            }
         }
      }
   }
}
