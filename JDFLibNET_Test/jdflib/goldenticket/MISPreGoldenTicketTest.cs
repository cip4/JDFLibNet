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

   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using EnumWorkStyle = org.cip4.jdflib.auto.JDFAutoConventionalPrintingParams.EnumWorkStyle;
   using JDFAudit = org.cip4.jdflib.core.JDFAudit;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using EnumVersion = org.cip4.jdflib.core.JDFElement.EnumVersion;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using EnumType = org.cip4.jdflib.node.JDFNode.EnumType;
   using EnumPartIDKey = org.cip4.jdflib.resource.JDFResource.EnumPartIDKey;

   [TestClass]
   public class MISPreGoldenTicketTest : JDFTestCaseBase
   {
      internal string agentName;
      internal VJDFAttributeMap vMap;


      [TestMethod]
      public virtual void testMISPreContentCreation()
      {
         MISPreGoldenTicket goldenTicket = new MISPreGoldenTicket(1, null, 2, 2, vMap);
         goldenTicket.nCols[0] = goldenTicket.nCols[1] = 4;
         goldenTicket.workStyle = EnumWorkStyle.WorkAndTurn;
         goldenTicket.setCategory(MISPreGoldenTicket.MISPRE_CONTENTCREATION);

         ProductGoldenTicket pgt = new ProductGoldenTicket(0, EnumVersion.Version_1_3, 0, 0);
         pgt.assign(null);
         pgt.createHDCity();
         JDFNode node = pgt.getNode();
         JDFNode nodePre = node.addJDFNode(EnumType.ProcessGroup);

         goldenTicket.assign(nodePre);
         BaseGoldenTicketTest.write3GTFiles(this, goldenTicket, "MISPre_ContentCreation");
      }


      [TestMethod]
      public virtual void testMISPreImpositionPreparation()
      {
         for (int i = 0; i < 4; i++)
         {

            MISPreGoldenTicket goldenTicket = new MISPreGoldenTicket(1, null, 2, 2, vMap);
            goldenTicket.bStripping = i % 2 == 1;
            goldenTicket.nCols[0] = goldenTicket.nCols[1] = 4;
            goldenTicket.workStyle = EnumWorkStyle.WorkAndTurn;
            goldenTicket.setCategory(MISPreGoldenTicket.MISPRE_IMPOSITIONPREPARATION);

            JDFNode nodePre = null;
            if (i < 2)
            {
               ProductGoldenTicket pgt = new ProductGoldenTicket(0, EnumVersion.Version_1_3, 0, 0);
               pgt.assign(null);
               pgt.createHDCity();
               JDFNode node = pgt.getNode();
               nodePre = node.addJDFNode(EnumType.ProcessGroup);
            }
            else
            {
               // nop
            }

            goldenTicket.assign(nodePre);
            BaseGoldenTicketTest.write3GTFiles(this, goldenTicket, "MISPre_" + (i < 2 ? "GB_" : "") + "ImpositionPreparation" + (goldenTicket.bStripping ? "Strip" : ""));
         }
      }

      ///   
      ///	 <summary> * the big thing
      ///	 *  </summary>
      ///	 * <exception cref="Exception"> </exception>
      ///	 
      [TestMethod]
      public virtual void testMIPreComplex()
      {

         for (int i = 0; i < 4; i++)
         {
            for (int ii = 0; ii < 2; ii++)
            {
               bool bExpand = ii == 0;
               ProductGoldenTicket pgt = new ProductGoldenTicket(0, EnumVersion.Version_1_3, 0, 0);
               pgt.assign(null);
               pgt.createHDCity();
               JDFNode node = pgt.getNode();

               JDFNode nodePre = node.addJDFNode(EnumType.ProcessGroup);
               MISPreGoldenTicket goldenTicket = new MISPreGoldenTicket(1, null, 2, 2, null);
               goldenTicket.nCols[0] = goldenTicket.nCols[1] = 4;
               goldenTicket.workStyle = EnumWorkStyle.WorkAndTurn;
               goldenTicket.bExpandGrayBox = bExpand;

               goldenTicket.setCategory(MISPreGoldenTicket.MISPRE_PREPRESSPREPARATION);
               goldenTicket.assign(nodePre);
               pgt.addKid(goldenTicket);

               MISPreGoldenTicket goldenTicket2 = new MISPreGoldenTicket(goldenTicket, vMap);
               goldenTicket2.bStripping = i % 2 == 1;
               goldenTicket2.bExpandGrayBox = bExpand;

               JDFNode nodeImp = node.addJDFNode(EnumType.ProcessGroup);
               goldenTicket2.setCategory(MISPreGoldenTicket.MISPRE_IMPOSITIONPREPARATION);
               goldenTicket2.assign(nodeImp);
               pgt.addKid(goldenTicket2);

               MISPreGoldenTicket goldenTicket3 = new MISPreGoldenTicket(goldenTicket2, null);
               JDFNode nodeRIP = node.addJDFNode(EnumType.ProcessGroup);
               goldenTicket3.bExpandGrayBox = bExpand;
               goldenTicket3.setCategory(i < 2 ? MISPreGoldenTicket.MISPRE_IMPOSITIONRIPING : MISPreGoldenTicket.MISPRE_PLATEMAKING);
               goldenTicket3.assign(nodeRIP);
               pgt.addKid(goldenTicket3);

               if (i < 2)
               {
                  MISPreGoldenTicket goldenTicket4 = new MISPreGoldenTicket(goldenTicket3, null);
                  JDFNode nodePlateSet = node.addJDFNode(EnumType.ProcessGroup);
                  goldenTicket4.setCategory(MISPreGoldenTicket.MISPRE_PLATESETTING);
                  goldenTicket4.assign(nodePlateSet);
                  pgt.addKid(goldenTicket4);
               }

               BaseGoldenTicketTest.write3GTFiles(this, pgt, "MISPre_ComplexPlate" + (i >= 2 ? "Making" : "Setting") + (goldenTicket2.bStripping ? "Strip" : "") + (bExpand ? "Expand" : ""));
            }
         }
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.JDFTestCaseBase#setUp()
      //	 
      [TestInitialize]
      public override void setUp()
      {
         agentName = JDFAudit.getStaticAgentName();
         JDFElement.setLongID(false);
         JDFAudit.setStaticAgentName("JDF MISPre golden ticket generator");
         base.setUp();
         vMap = new VJDFAttributeMap();
         JDFAttributeMap map = new JDFAttributeMap();

         for (int i = 0; i < 4; i++)
         {
            map.put(EnumPartIDKey.SignatureName, "Sig1");
            map.put(EnumPartIDKey.SheetName, i == 0 ? "Cover" : "Sheet" + i);
            map.put(EnumPartIDKey.Side, "Front");
            vMap.Add(new JDFAttributeMap(map));
            map.put(EnumPartIDKey.Side, "Back");
            vMap.Add(new JDFAttributeMap(map));

         }
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.JDFTestCaseBase#tearDown()
      //	 
      [TestCleanup]
      public override void tearDown()
      {
         JDFAudit.setStaticAgentName(agentName);
         JDFElement.setLongID(true);
         base.tearDown();
      }
   }
}
