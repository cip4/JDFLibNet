
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
 * THIS SOFTWARE IS PROVIDED ``AS IS'' AND ANY EXPRESSED OR IMPLIED
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


namespace org.cip4.jdflib.core
{
   using Microsoft.VisualStudio.TestTools.UnitTesting;

   using EnumAttributeType = org.cip4.jdflib.core.AttributeInfo.EnumAttributeType;
   using EnumOrientation = org.cip4.jdflib.core.JDFElement.EnumOrientation;
   using EnumVersion = org.cip4.jdflib.core.JDFElement.EnumVersion;

   [TestClass]
   public class AttrInfoTest 
   {
      [TestMethod]
      public virtual void testgetFirstLastVersion()
      {
         AtrInfo ai = new AtrInfo(0x44433211, AttributeInfo.EnumAttributeType.boolean_, null, null);
         Assert.AreEqual(EnumVersion.Version_1_2, ai.getFirstVersion(), "");
         Assert.AreEqual(EnumVersion.Version_1_4, ai.getLastVersion(), "");

         ai = new AtrInfo(0x33333222, AttributeInfo.EnumAttributeType.boolean_, null, null);
         Assert.AreEqual(EnumVersion.Version_1_0, ai.getFirstVersion(), "");
         Assert.AreEqual(EnumVersion.Version_1_7, ai.getLastVersion(), "");
      }

      [TestMethod]
      public virtual void testValidStringForType()
      {
         Assert.IsTrue(AttributeInfo.validStringForType("1", EnumAttributeType.integer, null));
         Assert.IsFalse(AttributeInfo.validStringForType("1234567898765432", EnumAttributeType.integer, null));
         Assert.IsFalse(AttributeInfo.validStringForType("a", EnumAttributeType.integer, null));
         Assert.IsFalse(AttributeInfo.validStringForType("3.6", EnumAttributeType.integer, null));

         Assert.IsTrue(AttributeInfo.validStringForType("123456789", EnumAttributeType.double_, null));
         Assert.IsTrue(AttributeInfo.validStringForType("1234567898765432", EnumAttributeType.double_, null));
         Assert.IsFalse(AttributeInfo.validStringForType("a", EnumAttributeType.double_, null));
         Assert.IsTrue(AttributeInfo.validStringForType("3.6", EnumAttributeType.double_, null));
         Assert.IsTrue(AttributeInfo.validStringForType("3.6e3", EnumAttributeType.double_, null));

         Assert.IsTrue(AttributeInfo.validStringForType("Rotate90", EnumAttributeType.enumeration, EnumOrientation.getEnum(0)));
         Assert.IsFalse(AttributeInfo.validStringForType("Rotate91", EnumAttributeType.enumeration, EnumOrientation.getEnum(0)));

         Assert.IsTrue(AttributeInfo.validStringForType("Rotate90 Rotate180", EnumAttributeType.enumerations, EnumOrientation.getEnum(0)));
         Assert.IsFalse(AttributeInfo.validStringForType("Rotate91", EnumAttributeType.enumerations, EnumOrientation.getEnum(0)));

         Assert.IsTrue(AttributeInfo.validStringForType("1 3 ~5", EnumAttributeType.IntegerRangeList, null));
         Assert.IsFalse(AttributeInfo.validStringForType("3.6", EnumAttributeType.IntegerRangeList, null));

         Assert.IsTrue(AttributeInfo.validStringForType("1.5 3 ~5", EnumAttributeType.NumberRangeList, null));
         Assert.IsFalse(AttributeInfo.validStringForType("3.6a", EnumAttributeType.NumberRangeList, null));

         Assert.IsTrue(AttributeInfo.validStringForType("i1", EnumAttributeType.ID, null));
         Assert.IsFalse(AttributeInfo.validStringForType("42", EnumAttributeType.ID, null));

         Assert.IsTrue(AttributeInfo.validStringForType("i1", EnumAttributeType.IDREF, null));
         Assert.IsFalse(AttributeInfo.validStringForType("42", EnumAttributeType.IDREF, null));

         Assert.IsTrue(AttributeInfo.validStringForType("i1", EnumAttributeType.IDREFS, null));
         Assert.IsFalse(AttributeInfo.validStringForType("42", EnumAttributeType.IDREFS, null));
         Assert.IsTrue(AttributeInfo.validStringForType("aa i1", EnumAttributeType.IDREFS, null));
         Assert.IsFalse(AttributeInfo.validStringForType("aa 42", EnumAttributeType.IDREFS, null));

         Assert.IsFalse(AttributeInfo.validStringForType(null, EnumAttributeType.IDREFS, null));

         Assert.IsTrue(AttributeInfo.validStringForType("2006-11-26T00:00:00+00:00", EnumAttributeType.dateTime, null));
         Assert.IsTrue(AttributeInfo.validStringForType("2006-11-26T00:00:00.04G", EnumAttributeType.dateTime, null));
         Assert.IsTrue(AttributeInfo.validStringForType("2006-11-26T00:00:00.023454+01:30", EnumAttributeType.dateTime, null));
         Assert.IsFalse(AttributeInfo.validStringForType("2006-11-26T00:00G", EnumAttributeType.dateTime, null));

         Assert.IsFalse(AttributeInfo.validStringForType("2006-11-26", EnumAttributeType.dateTime, null));
         Assert.IsFalse(AttributeInfo.validStringForType("2006-11-26T", EnumAttributeType.dateTime, null));
         Assert.IsFalse(AttributeInfo.validStringForType("2006-11-26T1", EnumAttributeType.dateTime, null));

         Assert.IsTrue(AttributeInfo.validStringForType("P1Y2M3DT10H30M20.4S", EnumAttributeType.duration, null));
         Assert.IsTrue(AttributeInfo.validStringForType("P1Y2M3DT10H30M", EnumAttributeType.duration, null));
         Assert.IsTrue(AttributeInfo.validStringForType("P1Y2M3DT10H30M20S", EnumAttributeType.duration, null));

         Assert.IsTrue(AttributeInfo.validStringForType("0 1 2 3", EnumAttributeType.TransferFunction, null));
         Assert.IsTrue(AttributeInfo.validStringForType("0 1 0 3", EnumAttributeType.TransferFunction, null));
         Assert.IsFalse(AttributeInfo.validStringForType("0 1 0", EnumAttributeType.TransferFunction, null));
      }
   }
}