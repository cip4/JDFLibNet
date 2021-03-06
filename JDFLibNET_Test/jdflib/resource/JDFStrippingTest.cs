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
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFIntegerList = org.cip4.jdflib.datatypes.JDFIntegerList;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using EnumProcessUsage = org.cip4.jdflib.node.JDFNode.EnumProcessUsage;
   using EnumType = org.cip4.jdflib.node.JDFNode.EnumType;
   using EnumPartIDKey = org.cip4.jdflib.resource.JDFResource.EnumPartIDKey;
   using EnumResStatus = org.cip4.jdflib.resource.JDFResource.EnumResStatus;
   using JDFBinderySignature = org.cip4.jdflib.resource.process.JDFBinderySignature;
   using JDFRunList = org.cip4.jdflib.resource.process.JDFRunList;
   using JDFSignatureCell = org.cip4.jdflib.resource.process.JDFSignatureCell;
   using JDFStripCellParams = org.cip4.jdflib.resource.process.JDFStripCellParams;

   ///
   /// <summary> * all kinds of fun tests around Stripping also some tests for automated layout
   /// *  </summary>
   /// 
   [TestClass]
   public class JDFStrippingTest : JDFTestCaseBase
   {

      private JDFDoc doc = null;
      private JDFNode n = null;
      private JDFRunList rl = null;
      private JDFStrippingParams sp = null;
      private JDFBinderySignature bs = null;

      [TestInitialize]
      public override void setUp()
      {
         base.setUp();

         reSetUp();
      }

      /// <summary>
      /// All the setUp calls except for base.setUp.
      /// Use when you want to redo a setup without doign a teardown.
      /// </summary>
      public void reSetUp()
      {
         JDFElement.setLongID(false);
         doc = new JDFDoc("JDF");
         n = doc.getJDFRoot();
         n.setType(EnumType.Stripping);
         rl = (JDFRunList)n.appendMatchingResource(ElementName.RUNLIST, EnumProcessUsage.AnyInput, null);
         sp = (JDFStrippingParams)n.appendMatchingResource(ElementName.STRIPPINGPARAMS, EnumProcessUsage.AnyInput, null);
         bs = (JDFBinderySignature)n.addResource(ElementName.BINDERYSIGNATURE, null, null, null, null, null, null);
         sp.refBinderySignature(bs);
      }

      ///   
      ///	 <summary> * test how foldouts are generated
      ///	 *  </summary>
      ///	 * <exception cref="Exception"> </exception>
      ///	 
      [TestMethod]
      public virtual void testFoldOut()
      {
         // 0=1.3; 2=1.4
         for (int i = 0; i < 3; i++)
         {
            if (i == 1)
               continue; // rejected by wg
            reSetUp();
            n.setXMLComment("Stripping Foldout example corresponding to spec example n.6.5 - verion: " + ((i == 0) ? "multi-Cell" : ((i == 1) ? "new attribute FoldOutTrimSize" : "new attribute FaceCells (Accepted for 1.4)")));
            rl.setNPage(6);
            sp.setResStatus(EnumResStatus.Available, true);
            bs.setResStatus(EnumResStatus.Available, true);
            JDFSignatureCell sc = bs.appendSignatureCell();
            sc.setXMLComment("this is the foldout foldout cell");
            sc.setFrontPages(new JDFIntegerList("4"));
            sc.setBackPages(new JDFIntegerList("3"));
            if (i == 0 || i == 2)
            {
               sc = bs.appendSignatureCell();
               string xmlComment = "this cell is the inner page of the foldout, i.e. the page that is attached to the spine";
               sc.setFrontPages(new JDFIntegerList("5"));
               sc.setBackPages(new JDFIntegerList("2"));
               if (i == 0)
               {
                  sc.setFrontFacePages(new JDFIntegerList("4"));
                  sc.setBackFacePages(new JDFIntegerList("3"));
               }
               else
               {
                  xmlComment += "\nThe new attribute FaceCells refers to the cell(s) that describe the foldout; in this case the cell to the left.";
                  xmlComment += "\nThe front and back pages of the foldout are listed in the respective cell(s)";
                  sc.setAttribute("FaceCells", "0");
               }
               sc.setXMLComment(xmlComment);

            }

            sc = bs.appendSignatureCell();
            sc.setXMLComment("this is the cell that has no foldout");
            sc.setFrontPages(new JDFIntegerList("0"));
            sc.setBackPages(new JDFIntegerList("1"));

            JDFStrippingParams sp1 = (JDFStrippingParams)sp.addPartition(EnumPartIDKey.CellIndex, "0");
            JDFStripCellParams scp = sp1.appendStripCellParams();
            scp.setTrimSize(new JDFXYPair(200 + (i % 2) * 300, 400));
            if (i != 1)
               scp.setXMLComment("stripcell for the folded out foldout(front page=4)");
            else
               scp.setXMLComment("stripcell for the entire foldout(front page=4, foldout page =5)\nthe TrimSize applies to the entire foldout spread (page 4 and 5)\n note the new FoldoutTrimSize attribute");

            if (i != 1)
            {
               sp1 = (JDFStrippingParams)sp.addPartition(EnumPartIDKey.CellIndex, "1");
               scp = sp1.appendStripCellParams();
               scp.setTrimSize(new JDFXYPair(300, 400));
               scp.setXMLComment("stripcell for the inner page of the foldout foldout(front page=5)");
            }
            else
            {
               scp.setAttribute("FoldoutTrimSize", "200 400");
            }

            sp1 = (JDFStrippingParams)sp.addPartition(EnumPartIDKey.CellIndex, i != 1 ? "2" : "1");
            scp = sp1.appendStripCellParams();
            scp.setTrimSize(new JDFXYPair(320, 400));
            scp.setXMLComment("stripcell for the inner page of the foldout foldout(front page=0)");

            doc.write2File(sm_dirTestDataTemp + "foldoutStrip" + i + ".jdf", 2, false);
         }
      }
   }
}
