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



namespace org.cip4.jdflib.resource.process
{
   using System;
   using Microsoft.VisualStudio.TestTools.UnitTesting;


   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using KElement = org.cip4.jdflib.core.KElement;
   using EnumVersion = org.cip4.jdflib.core.JDFElement.EnumVersion;
   using EnumValidationLevel = org.cip4.jdflib.core.KElement.EnumValidationLevel;
   using JDFMatrix = org.cip4.jdflib.datatypes.JDFMatrix;
   using JDFRectangle = org.cip4.jdflib.datatypes.JDFRectangle;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using EnumType = org.cip4.jdflib.node.JDFNode.EnumType;
   using JDFResourcePool = org.cip4.jdflib.pool.JDFResourcePool;
   using JDFMarkObject = org.cip4.jdflib.resource.JDFMarkObject;

   [TestClass]
   public class JDFTileTest : JDFTestCaseBase
   {

      //   
      //	 * Test method for
      //	 * 'org.cip4.jdflib.resource.process.JDFMedia.setDimensionCM(JDFXYPair)'
      //	 
      [TestMethod]
      public void testMarkObject()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode root = doc.getJDFRoot();
         root.setVersion(EnumVersion.Version_1_4);
         root.setType(EnumType.Tiling);
         JDFResourcePool resPool = root.getCreateResourcePool();
         KElement kElem = resPool.appendResource(ElementName.TILE, null, null);
         Assert.IsTrue(kElem is JDFTile);
         JDFTile tile = ((JDFTile)kElem);
         try
         {
            tile.setClipBox(new JDFRectangle("0 0 123 123"));
            tile.setCTM(new JDFMatrix("1 0 0 1 0 0"));
            JDFMarkObject m = tile.appendMarkObject();
            m.setOrd(0);
            m.setCTM(new JDFMatrix("1.2 0 0 1.4 1 444."));
            Assert.IsTrue(m.isValid(EnumValidationLevel.Complete));
            JDFMarkObject m2 = tile.appendMarkObject();
            m2.setOrd(0);
            m2.setCTM(new JDFMatrix("1.234 0 0 1.4 1 444."));
            Assert.IsTrue(m2.isValid(EnumValidationLevel.Complete));
            Assert.AreEqual(tile.getMarkObject(1), m2);
            Assert.AreEqual(tile.getCreateMarkObject(1), m2);
            Assert.IsTrue(tile.isValid(EnumValidationLevel.Complete));
         }
         catch (FormatException)
         {
            Assert.Fail("bad unit matrix");
         }
      }
   }
}
