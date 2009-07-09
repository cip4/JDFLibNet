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
 * JDFNameStateTest.cs
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
   using VString = org.cip4.jdflib.core.VString;
   using EnumValidationLevel = org.cip4.jdflib.core.KElement.EnumValidationLevel;
   using EnumFitsValue = org.cip4.jdflib.datatypes.EnumFitsValue;
   using JDFNameState = org.cip4.jdflib.resource.devicecapability.JDFNameState;

   [TestClass]
   public class JDFNameStateTest : JDFTestCaseBase
   {

      internal JDFNameState theState = null;

      [TestInitialize]
      public override void setUp()
      {
         base.setUp();
         JDFDoc doc = new JDFDoc("NameState");
         theState = (JDFNameState)doc.getRoot();
         theState.setAllowedValueList(new VString("a b c d", null));
      }


      [TestMethod]
      public void testFitsValue()
      {
         JDFParser p = new JDFParser();
         string strNode = "<NameState Name=\"BitDepth\" DefaultValue=\"1\" AllowedValueList=\"a b c d\"/>";

         JDFDoc jdfDoc = p.parseString(strNode);
         JDFNameState state = (JDFNameState)jdfDoc.getRoot();

         VString list = new VString("a b c", null);

         state.setListType(EnumListType.RangeList);
         Assert.IsFalse(state.fitsValue(list.ToString(), EnumFitsValue.Allowed), "ListType=RangeList");

         VString list2 = new VString();
         list2.Add("d"); // 1~-2
      }


      [TestMethod]
      public void testFitsValue_ListType()
      {
         theState.setListType(EnumListType.Range);
         Assert.IsTrue(theState.fitsValue("a", EnumFitsValue.Allowed), "single values a re ranges too");
         Assert.IsFalse(theState.fitsValue("a b", EnumFitsValue.Allowed));
         theState.setAllowedValueList(null);
         Assert.IsTrue(theState.fitsValue("a ~ b", EnumFitsValue.Allowed));
         Assert.IsFalse(theState.fitsValue("a  b", EnumFitsValue.Allowed));
      }


      [TestMethod]
      public void testSetCurrentValue()
      {
         VString integerList = new VString("1 2 3", null);
         theState.setCurrentValue(integerList);
         Assert.AreEqual(integerList, theState.getCurrentValue());
         theState.setCurrentValue("1");
         Assert.AreEqual(new VString("1", null), theState.getCurrentValue());
      }


      [TestMethod]
      public void testSetDefaultValue()
      {
         VString integerList = new VString("1 2 3", null);
         theState.setDefaultValue(integerList);
         Assert.AreEqual(integerList, theState.getDefaultValue());
         theState.setDefaultValue("1");
         Assert.AreEqual(new VString("1", null), theState.getDefaultValue());
      }


      [TestMethod]
      public void testSetAllowedValueList()
      {
         VString integerList = new VString("1 2 3 4 44", null);
         theState.setAllowedValueList(integerList);
         Assert.AreEqual(integerList, theState.getPresentValueList());
         Assert.AreEqual(integerList, theState.getAllowedValueList());
         VString integerList2 = new VString("1 2 3 7 77", null);
         theState.setPresentValueList(integerList2);
         Assert.AreEqual(integerList2, theState.getPresentValueList());
         Assert.AreEqual(integerList, theState.getAllowedValueList());
      }


      [TestMethod]
      public void testIsValid()
      {
         VString integerList = new VString("1 2 3", null);
         theState.setDefaultValue(integerList);
         theState.setCurrentValue(integerList);
         Assert.IsFalse(theState.isValid(EnumValidationLevel.Complete));
         theState.setListType(EnumListType.List);
         Assert.IsTrue(theState.isValid(EnumValidationLevel.Complete));
         VString integerRList = new VString("1 2 3 4 44", null);
         theState.setAllowedValueList(integerRList);
         Assert.IsTrue(theState.isValid(EnumValidationLevel.Complete));
         VString integerList2 = new VString("1 2 3 7 77", null);
         theState.setPresentValueList(integerList2);
         Assert.IsTrue(theState.isValid(EnumValidationLevel.Complete));
      }
   }
}
