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
 * PreflightTest.cs
 * @author muchadie
 */

namespace org.cip4.jdflib.examples
{
   using Microsoft.VisualStudio.TestTools.UnitTesting;


   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using EnumSeverity = org.cip4.jdflib.auto.JDFAutoAction.EnumSeverity;
   using EnumListType = org.cip4.jdflib.auto.JDFAutoBasicPreflightTest.EnumListType;
   using EnumBox = org.cip4.jdflib.auto.JDFAutoBoxArgument.EnumBox;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using VString = org.cip4.jdflib.core.VString;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using JDFIntegerRangeList = org.cip4.jdflib.datatypes.JDFIntegerRangeList;
   using JDFNumberRange = org.cip4.jdflib.datatypes.JDFNumberRange;
   using JDFNumberRangeList = org.cip4.jdflib.datatypes.JDFNumberRangeList;
   using JDFRectangle = org.cip4.jdflib.datatypes.JDFRectangle;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFXYPairRange = org.cip4.jdflib.datatypes.JDFXYPairRange;
   using JDFXYPairRangeList = org.cip4.jdflib.datatypes.JDFXYPairRangeList;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using EnumProcessUsage = org.cip4.jdflib.node.JDFNode.EnumProcessUsage;
   using EnumType = org.cip4.jdflib.node.JDFNode.EnumType;
   using JDFAction = org.cip4.jdflib.resource.devicecapability.JDFAction;
   using JDFActionPool = org.cip4.jdflib.resource.devicecapability.JDFActionPool;
   using JDFBasicPreflightTest = org.cip4.jdflib.resource.devicecapability.JDFBasicPreflightTest;
   using JDFBooleanEvaluation = org.cip4.jdflib.resource.devicecapability.JDFBooleanEvaluation;
   using JDFEnumerationEvaluation = org.cip4.jdflib.resource.devicecapability.JDFEnumerationEvaluation;
   using JDFEvaluation = org.cip4.jdflib.resource.devicecapability.JDFEvaluation;
   using JDFIntegerEvaluation = org.cip4.jdflib.resource.devicecapability.JDFIntegerEvaluation;
   using JDFNumberEvaluation = org.cip4.jdflib.resource.devicecapability.JDFNumberEvaluation;
   using JDFRectangleEvaluation = org.cip4.jdflib.resource.devicecapability.JDFRectangleEvaluation;
   using JDFStringEvaluation = org.cip4.jdflib.resource.devicecapability.JDFStringEvaluation;
   using JDFXYPairEvaluation = org.cip4.jdflib.resource.devicecapability.JDFXYPairEvaluation;
   using JDFnot = org.cip4.jdflib.resource.devicecapability.JDFnot;
   using EnumTerm = org.cip4.jdflib.resource.devicecapability.JDFTerm.EnumTerm;
   using JDFPRItem = org.cip4.jdflib.resource.process.JDFPRItem;
   using JDFPreflightParams = org.cip4.jdflib.resource.process.JDFPreflightParams;
   using JDFPreflightReport = org.cip4.jdflib.resource.process.JDFPreflightReport;
   using JDFPreflightReportRulePool = org.cip4.jdflib.resource.process.JDFPreflightReportRulePool;
   using JDFRunList = org.cip4.jdflib.resource.process.JDFRunList;

   [TestClass]
   public class PreflightTest : JDFTestCaseBase
   {
      protected internal JDFActionPool aPool;
      protected internal JDFNode n;
      protected internal JDFPreflightParams preparms;
      protected internal JDFPreflightReportRulePool prrp;
      protected internal JDFRunList inRun;

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.JDFTestCaseBase#setUp()
      //	 
      [TestInitialize]
      public override void setUp()
      {
         base.setUp();
         JDFElement.setLongID(false);
      }


      [TestMethod]
      public virtual void testPreflightReport()
      {
         testPreflightProfile();
         JDFPreflightReport prp = (JDFPreflightReport)n.appendMatchingResource(ElementName.PREFLIGHTREPORT, EnumProcessUsage.AnyOutput, null);
         prp.refElement(preparms);
         prp.refElement(inRun);
         prp.refElement(prrp);

         JDFAttributeMap prMap = new JDFAttributeMap();
         VString groupBy = new VString();

         prMap.put("CompressionTypes", "JPEG");
         prMap.put("PageNumber", "2");
         groupBy.Add("PageNumber");
         JDFPRItem pi = prp.setPR(aPool.getAction(0), 2, prMap, groupBy);
         Assert.IsNotNull(pi);
         Assert.AreEqual(1, pi.getOccurrences());
         prMap.put("CompressionTypes", "JPEG2000");
         JDFPRItem pi2 = prp.setPR(aPool.getAction(0), 2, prMap, groupBy);
         Assert.IsNotNull(pi2);
         Assert.AreEqual(2, pi2.getOccurrences());
         Assert.AreEqual(pi, pi2);
         prMap.put("PageNumber", "3");
         JDFPRItem pi3 = prp.setPR(aPool.getAction(0), 3, prMap, groupBy);
         Assert.IsNotNull(pi3);
         Assert.AreEqual(3, pi3.getOccurrences());
         Assert.AreEqual(pi3, pi);
         Assert.AreEqual(new JDFIntegerRangeList("2 ~ 3"), pi.getPageSet());
         JDFPRItem pi4 = prp.setPR(aPool.getAction(1), 3, null, null);
         Assert.AreEqual(1, pi4.getOccurrences());
         Assert.AreNotEqual(pi, pi4);
         Assert.AreEqual(new JDFIntegerRangeList("3"), pi4.getPageSet());

         Assert.AreEqual(2, prp.numChildElements(ElementName.PRITEM, null));
         n.getOwnerDocument_KElement().write2File(sm_dirTestDataTemp + "PreflightReport.jdf", 2, false);
      }

      ///   
      ///	 <summary> * test preflight profile
      ///	 * 
      ///	 * @return </summary>
      ///	 
      [TestMethod]
      public virtual void testPreflightProfile()
      {

         JDFDoc d = new JDFDoc("JDF");
         n = d.getJDFRoot();
         n.setType(EnumType.Preflight);

         inRun = (JDFRunList)n.appendMatchingResource(ElementName.RUNLIST, EnumProcessUsage.AnyInput, null);
         inRun.setFileURL("input.pdf");

         preparms = (JDFPreflightParams)n.appendMatchingResource(ElementName.PREFLIGHTPARAMS, EnumProcessUsage.AnyInput, null);
         prrp = (JDFPreflightReportRulePool)n.appendMatchingResource(ElementName.PREFLIGHTREPORTRULEPOOL, EnumProcessUsage.AnyInput, null);

         // new
         aPool = (JDFActionPool)preparms.appendElement(ElementName.ACTIONPOOL);

         // now some simple tests...
         appendTransparency();
         appendNumPagesAction();
         appendSeparationAction();
         appendBWSeparationAction();
         appendTrimBoxAction();
         appendResolutionAction();
         appendResolutionActionBitMap();
         appendLineWeightAction();

         d.write2File(sm_dirTestDataTemp + "PreflightProfile.jdf", 2, false);

      }


      protected internal virtual void appendResolutionActionBitMap()
      {
         {
            JDFAction a = aPool.appendActionSetTest(EnumTerm.XYPairEvaluation, EnumTerm.IntegerEvaluation, true);
            a.setSeverity(EnumSeverity.Warning);
            JDFXYPairEvaluation resolution = (JDFXYPairEvaluation)a.getTestTerm();
            resolution.appendBasicPreflightTest("EffectiveResolution");
            resolution.setValueList(new JDFXYPairRangeList(new JDFXYPairRange(new JDFXYPair(0, 0), new JDFXYPair(1200, 1200))));
            JDFEvaluation setEval = (JDFEvaluation)a.getPreflightActionSetTerm();
            setEval.appendBasicPreflightTest("BitsPerSample");

            a.setDescriptiveName("Warn when effective resolution<1200 dpi");
         }
      }


      protected internal virtual void appendResolutionAction()
      {
         {
            JDFAction a = aPool.appendActionTest(EnumTerm.XYPairEvaluation, true);
            a.setSeverity(EnumSeverity.Warning);
            JDFXYPairEvaluation resolution = (JDFXYPairEvaluation)a.getTestTerm();
            resolution.appendBasicPreflightTest("EffectiveResolution");
            resolution.setValueList(new JDFXYPairRangeList(new JDFXYPairRange(new JDFXYPair(0, 0), new JDFXYPair(300, 300))));

            a.setDescriptiveName("Warn when effective resolution<300 dpi");
         }
      }


      protected internal virtual void appendTransparency()
      {
         {
            JDFAction a = aPool.appendActionTest(EnumTerm.BooleanEvaluation, true);
            a.setSeverity(EnumSeverity.Error);
            JDFBooleanEvaluation transparency = (JDFBooleanEvaluation)a.getTestTerm();
            transparency.appendBasicPreflightTest("TransparencyFlag");
            transparency.setValueList(false);

            a.setDescriptiveName("Error when objects with transparency exist");
         }
      }


      protected internal virtual void appendTrimBoxAction()
      {
         {
            JDFAction a = aPool.appendActionSetTest(EnumTerm.RectangleEvaluation, EnumTerm.EnumerationEvaluation, false);
            a.setSeverity(EnumSeverity.Error);
            JDFRectangleEvaluation trimBox = (JDFRectangleEvaluation)((JDFnot)a.getTestTerm()).getTerm(null, 0);
            trimBox.appendBasicPreflightTest("PageBoxSize");
            trimBox.setValueList(new JDFRectangle(0, 0, 8.5 * 72, 11 * 72));
            JDFEnumerationEvaluation setEval = (JDFEnumerationEvaluation)a.getPreflightActionSetTerm();
            setEval.appendBasicPreflightTest("PageBoxName");
            setEval.setValueList(new VString(EnumBox.TrimBox.getName(), " "));

            a.setDescriptiveName("set TrimBox to 8.5*11 Method 2");
         }
      }


      protected internal virtual void appendLineWeightAction()
      {
         JDFAction a = aPool.appendActionTest(EnumTerm.NumberEvaluation, true);
         a.setSeverity(EnumSeverity.Error);
         JDFNumberEvaluation hairLine = (JDFNumberEvaluation)a.getTestTerm();
         hairLine.setValueList(new JDFNumberRangeList(new JDFNumberRange(0.0, 0.216)));
         hairLine.appendBasicPreflightTest("StrokeThickness");

         a.setDescriptiveName("set minimum stroke width to 0.216");
      }


      protected internal virtual void appendBWSeparationAction()
      {
         JDFAction a = aPool.appendActionSetTest(EnumTerm.StringEvaluation, EnumTerm.IntegerEvaluation, false);
         a.setSeverity(EnumSeverity.Error);

         JDFStringEvaluation numSeparations = (JDFStringEvaluation)((JDFnot)a.getTestTerm()).getTerm(null, 0);
         numSeparations.appendBasicPreflightTest("SeparationList");
         a.setDescriptiveName("separation to black only on page 1 and 2");
         numSeparations.appendValueValue("Black");

         JDFIntegerEvaluation setEval = (JDFIntegerEvaluation)a.getPreflightActionSetTerm();
         setEval.appendBasicPreflightTest("PageNumber");
         setEval.appendValueList(1);
         setEval.appendValueList(2);
      }


      protected internal virtual void appendNumPagesAction()
      {
         {
            JDFAction a = aPool.appendActionTest(EnumTerm.IntegerEvaluation, false);
            a.setSeverity(EnumSeverity.Error);
            JDFIntegerEvaluation numPages = (JDFIntegerEvaluation)((JDFnot)a.getTestTerm()).getTerm(null, 0);
            numPages.appendBasicPreflightTest("NumberOfPages");
            numPages.appendValueList(4);
            a.setDescriptiveName("set number of pages to 4");
         }
      }


      protected internal virtual void appendSeparationAction()
      {
         {
            JDFAction a = aPool.appendActionSetTest(EnumTerm.StringEvaluation, EnumTerm.IntegerEvaluation, false);
            a.setSeverity(EnumSeverity.Error);

            JDFStringEvaluation numSeparations = (JDFStringEvaluation)((JDFnot)a.getTestTerm()).getTerm(null, 0);
            JDFBasicPreflightTest testSeps = numSeparations.appendBasicPreflightTest("SeparationList");
            a.setDescriptiveName("set number of separations to 6 on page 0 and 3");
            testSeps.setMinOccurs(6);
            testSeps.setMaxOccurs(6);
            testSeps.setListType(EnumListType.UniqueList);

            JDFIntegerEvaluation setEval = (JDFIntegerEvaluation)a.getPreflightActionSetTerm();
            setEval.appendBasicPreflightTest("PageNumber");
            setEval.appendValueList(0);
            setEval.appendValueList(3);
         }
      }
   }
}
