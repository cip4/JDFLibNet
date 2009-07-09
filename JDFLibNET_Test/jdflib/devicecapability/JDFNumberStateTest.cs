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
 * JDFNumberStateTest.cs
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
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFParser = org.cip4.jdflib.core.JDFParser;
   using EnumValidationLevel = org.cip4.jdflib.core.KElement.EnumValidationLevel;
   using JDFNumberList = org.cip4.jdflib.datatypes.JDFNumberList;
   using JDFNumberRange = org.cip4.jdflib.datatypes.JDFNumberRange;
   using JDFNumberRangeList = org.cip4.jdflib.datatypes.JDFNumberRangeList;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using EnumFitsValue = org.cip4.jdflib.datatypes.EnumFitsValue;
   using JDFNumberState = org.cip4.jdflib.resource.devicecapability.JDFNumberState;

   [TestClass]
   public class JDFNumberStateTest : JDFTestCaseBase
   {

      internal JDFNumberState iState = null;

      [TestInitialize]
      public override void setUp()
      {
         base.setUp();
         JDFDoc doc = new JDFDoc("NumberState");
         iState = (JDFNumberState)doc.getRoot();

      }


      [TestMethod]
      public void testFitsValue()
      {
         JDFParser p = new JDFParser();
         string strNode = "<NumberState Name=\"BitDepth\" DefaultValue=\"1\" AllowedValueList=\"1 8.5 12\"/>";

         JDFDoc jdfDoc = p.parseString(strNode);
         JDFNumberState state = (JDFNumberState)jdfDoc.getRoot();

         JDFNumberRangeList list = new JDFNumberRangeList();
         list.Append(new JDFNumberRange(1, 12.5)); // 1~12
         // list.append(12);

         state.setListType(EnumListType.RangeList);
         Assert.IsFalse(state.fitsValue(list.ToString(), EnumFitsValue.Allowed), "ListType=RangeList");

         JDFNumberRangeList list2 = new JDFNumberRangeList();
         list2.Append(new JDFNumberRange(1, 12.5)); // 1~-2

         JDFNumberRangeList allowedVL = new JDFNumberRangeList();
         allowedVL.Append(new JDFNumberRange(1, 32.666)); // 1~32

         state.setAllowedValueList(allowedVL); // new AllowedVlaueList

         Assert.IsTrue(state.fitsValue(list2.ToString(), EnumFitsValue.Allowed));

         list.erase(list.Count - 1); // erase "1~12"
         list.Append(2);
         list.Append(12);
         list.Append(22);
         state.setListType(EnumListType.List);
         state.setAllowedValueMod(new JDFXYPair(10, 2));
         Assert.IsTrue(state.fitsValue(list.ToString(), EnumFitsValue.Allowed), "ListType=List, ValueMod=" + state.getAllowedValueMod());
      }


      [TestMethod]
      public void testSetCurrentValue()
      {
         JDFNumberList integerList = new JDFNumberList("1 2 3");
         iState.setCurrentValue(integerList);
         Assert.AreEqual(integerList, iState.getCurrentValue());
         iState.setCurrentValue(1);
         Assert.AreEqual(new JDFNumberList("1"), iState.getCurrentValue());
      }


      [TestMethod]
      public void testSetDefaultValue()
      {
         JDFNumberList integerList = new JDFNumberList("1 2 3");
         iState.setDefaultValue(integerList);
         Assert.AreEqual(integerList, iState.getDefaultValue());
         iState.setDefaultValue(1);
         Assert.AreEqual(new JDFNumberList("1"), iState.getDefaultValue());
      }


      [TestMethod]
      public void testAddValue()
      {
         JDFNumberRangeList integerList = new JDFNumberRangeList("1 2 3 4 ~ 44");
         iState.setAllowedValueList(integerList);
         iState.addValue("24", EnumFitsValue.Allowed);
         Assert.AreEqual(integerList, iState.getAllowedValueList());
         iState.addValue("45", EnumFitsValue.Allowed);
         Assert.AreEqual(new JDFNumberRangeList("1 2 3 4 ~ 44 45"), iState.getAllowedValueList());
         iState.addValue("48", EnumFitsValue.Present);
         Assert.AreEqual(new JDFNumberRangeList("48"), iState.getPresentValueList());
      }

      [TestMethod]
      public void testSetAllowedValueList()
      {
         JDFNumberRangeList integerList = new JDFNumberRangeList("1 2 3 4 ~ 44");
         iState.setAllowedValueList(integerList);
         Assert.AreEqual(integerList, iState.getPresentValueList());
         Assert.AreEqual(integerList, iState.getAllowedValueList());
         JDFNumberRangeList integerList2 = new JDFNumberRangeList("1 2 3 7~77");
         iState.setPresentValueList(integerList2);
         Assert.AreEqual(integerList2, iState.getPresentValueList());
         Assert.AreEqual(integerList, iState.getAllowedValueList());
      }


      [TestMethod]
      public void testIsValid()
      {
         JDFNumberList numberList = new JDFNumberList("1 2 3");
         iState.setDefaultValue(numberList);
         iState.setCurrentValue(numberList);
         Assert.IsFalse(iState.isValid(EnumValidationLevel.Complete));
         iState.setListType(EnumListType.List);
         Assert.IsTrue(iState.isValid(EnumValidationLevel.Complete));
         JDFNumberRangeList numberRList = new JDFNumberRangeList("1 2 3 4 ~ 44");
         iState.setAllowedValueList(numberRList);
         Assert.IsTrue(iState.isValid(EnumValidationLevel.Complete));
         JDFNumberRangeList numberList2 = new JDFNumberRangeList("1 2 3 7~77");
         iState.setPresentValueList(numberList2);
         Assert.IsTrue(iState.isValid(EnumValidationLevel.Complete));
      }
   }
}