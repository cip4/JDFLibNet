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
 * JDFXYPairRangeListTest.cs
 * @author Elena Skobchenko
 * 
 * Copyright (c) 2001-2004 The International Cooperation for the Integration 
 * of Processes in  Prepress, Press and Postpress (CIP4).  All rights reserved. 
 */

namespace org.cip4.jdflib.datatypes
{
   using System;
   using Microsoft.VisualStudio.TestTools.UnitTesting;



   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using EnumValidationLevel = org.cip4.jdflib.core.KElement.EnumValidationLevel;
   using JDFTest = org.cip4.jdflib.resource.devicecapability.JDFTest;
   using JDFXYPairEvaluation = org.cip4.jdflib.resource.devicecapability.JDFXYPairEvaluation;
   using EnumTerm = org.cip4.jdflib.resource.devicecapability.JDFTerm.EnumTerm;

   [TestClass]
   public class JDFXYPairRangeListTest
   {
      [TestMethod]
      public void testSetString()
      {
         JDFXYPairRangeList rangeList = new JDFXYPairRangeList();
         try
         {
            rangeList = new JDFXYPairRangeList("0.4 1.9~1.4 2.9 0.4 1.9~2.4 3.8 0.4 1.6");
         }
         catch (FormatException dfe)
         {
            Console.WriteLine(dfe.ToString());
         }

         Assert.AreEqual("0.4 1.9 ~ 1.4 2.9 0.4 1.9 ~ 2.4 3.8 0.4 1.6", rangeList.ToString());
         // rangeList is not empty
         Assert.IsFalse(rangeList.ToString().Length == 0, "Bad Constructor from a given String");
      }


      [TestMethod]
      public void testConstructXYPairRange()
      {
         JDFXYPairRangeList rl = new JDFXYPairRangeList(new JDFXYPairRange(new JDFXYPair(2, 4), new JDFXYPair(6, 8)));
         Assert.AreEqual("2 4 ~ 6 8", rl.ToString());
      }


      [TestMethod]
      public void testFitsTolerance()
      {
         try
         {
            new JDFXYPairRangeList("0.4 1.9~1.4 2.9 0.4 1.9~2.4 3.8 0.4 1.6");

            JDFDoc d = new JDFDoc(ElementName.TEST);
            JDFTest t = (JDFTest)d.getRoot();
            t.init();
            JDFXYPairEvaluation xyPairEvaluation = (JDFXYPairEvaluation)t.appendTerm(EnumTerm.XYPairEvaluation);
            xyPairEvaluation.setTolerance(new JDFXYPair("0 0"));
            Assert.IsTrue(t.isValid(EnumValidationLevel.Complete));

            Assert.AreEqual(new JDFXYPair("0 0"), xyPairEvaluation.getTolerance());
            xyPairEvaluation.setTolerance(new JDFXYPair("0.1 0.1"));
         }
         catch (FormatException dfe)
         {
            Assert.Fail(dfe.ToString());
         }
      }
   }
}