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
 * JDFDurationStateTest.java
 *
 * @author Elena Skobchenko
 * 
 * Copyright (c) 2001-2004 The International Cooperation for the Integration 
 * of Processes in  Prepress, Press and Postpress (CIP4).  All rights reserved. 
 */


namespace org.cip4.jdflib.devicecapability
{
   using Microsoft.VisualStudio.TestTools.UnitTesting;

   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using EnumListType = org.cip4.jdflib.auto.JDFAutoBasicPreflightTest.EnumListType;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFParser = org.cip4.jdflib.core.JDFParser;
   using EnumValidationLevel = org.cip4.jdflib.core.KElement.EnumValidationLevel;
   using JDFDurationRangeList = org.cip4.jdflib.datatypes.JDFDurationRangeList;
   using JDFDurationState = org.cip4.jdflib.resource.devicecapability.JDFDurationState;
   using JDFDuration = org.cip4.jdflib.util.JDFDuration;
   using EnumFitsValue = org.cip4.jdflib.datatypes.EnumFitsValue;

   [TestClass]
   public class JDFDurationStateTest : JDFTestCaseBase
   {

      internal JDFDurationState iState = null;

      [TestInitialize]
      public override void setUp()
      {
         base.setUp();
         JDFDoc doc = new JDFDoc("DurationState");
         iState = (JDFDurationState)doc.getRoot();
      }


      [TestMethod]
      public void testFitsValue()
      {
         JDFParser p = new JDFParser();
         string strNode = "<DurationState Name=\"BitDepth\" DefaultValue=\"PT1H\" AllowedValueList=\"PT1H~PT4H30M5S\"/>";

         JDFDoc jdfDoc = p.parseString(strNode);
         JDFDurationState state = (JDFDurationState)jdfDoc.getRoot();

         state.setListType(EnumListType.SingleValue);
         Assert.IsTrue(state.fitsValue("PT2H", EnumFitsValue.Allowed), "ListType=SingleValue");
         Assert.IsFalse(state.fitsValue("PT6H", EnumFitsValue.Allowed), "ListType=SingleValue");

         state.removeAttribute(AttributeName.ALLOWEDVALUELIST);
         Assert.IsTrue(state.fitsValue("PT2H", EnumFitsValue.Allowed), "ListType=SingleValue");
         Assert.IsTrue(state.fitsValue("PT6H", EnumFitsValue.Allowed), "ListType=SingleValue");
      }


      [TestMethod]
      public void testIsValid()
      {
         iState.setDefaultValue(new JDFDuration("P4D"));
         Assert.IsTrue(iState.isValid(EnumValidationLevel.Complete));
         iState.setCurrentValue(new JDFDuration("PT30M"));
         iState.setListType(EnumListType.SingleValue);
         Assert.IsTrue(iState.isValid(EnumValidationLevel.Complete));
         JDFDurationRangeList integerRList = new JDFDurationRangeList("PT2S PT5S");
         iState.setAllowedValueList(integerRList);
         Assert.IsTrue(iState.isValid(EnumValidationLevel.Complete));
         Assert.IsTrue(iState.isValid(EnumValidationLevel.Complete));
      }
   }
}
