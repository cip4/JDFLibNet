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
   using System.Collections.Generic;
   using Microsoft.VisualStudio.TestTools.UnitTesting;



   using EnumHoleType = org.cip4.jdflib.auto.JDFAutoMedia.EnumHoleType;
   using EnumMediaType = org.cip4.jdflib.auto.JDFAutoMedia.EnumMediaType;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using KElement = org.cip4.jdflib.core.KElement;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using JDFResourcePool = org.cip4.jdflib.pool.JDFResourcePool;
   using EnumPartIDKey = org.cip4.jdflib.resource.JDFResource.EnumPartIDKey;
   using EnumResourceClass = org.cip4.jdflib.resource.JDFResource.EnumResourceClass;
   using JDFHoleMakingParams = org.cip4.jdflib.resource.process.postpress.JDFHoleMakingParams;
   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   [TestClass]
   public class JDFMediaTest
   {

      // Java to C# Converstion - Don't know what this is for.
      //public JDFMediaTest(string arg0)
      //   : base(arg0)
      //{
      //}

      //   
      //	 * Test method for
      //	 * 'org.cip4.jdflib.resource.process.JDFMedia.setDimensionCM(JDFXYPair)'
      //	 
      [TestMethod]
      public void testSetGetDimension()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode root = doc.getJDFRoot();
         JDFResourcePool resPool = root.getCreateResourcePool();
         KElement kElem = resPool.appendResource(ElementName.MEDIA, EnumResourceClass.Consumable, null);
         Assert.IsTrue(kElem is JDFMedia);
         JDFMedia media = ((JDFMedia)kElem);

         media.setDimensionCM(new JDFXYPair(2.54, 2.54));

         JDFXYPair result = media.getDimension();
         Assert.AreEqual(new JDFXYPair(72, 72), result);

         result = media.getDimensionCM();
         Assert.AreEqual(new JDFXYPair(2.54, 2.54), result);

         result = media.getDimensionInch();
         Assert.AreEqual(new JDFXYPair(1, 1), result);

         media.setDimensionInch(new JDFXYPair(1, 1));

         result = media.getDimension();
         Assert.AreEqual(new JDFXYPair(72, 72), result);

         result = media.getDimensionCM();
         Assert.AreEqual(new JDFXYPair(2.54, 2.54), result);

         result = media.getDimensionInch();
         Assert.AreEqual(new JDFXYPair(1, 1), result);
      }


      [TestMethod]
      public void testThicknessFromWeight()
      {
         JDFMedia m = (JDFMedia)new JDFDoc("Media").getRoot();
         m.setThicknessFromWeight(true, false);
         m.setMediaType(EnumMediaType.Paper);
         Assert.IsFalse(m.hasAttribute(AttributeName.THICKNESS));
         m.setWeight(80.0);
         m.setThicknessFromWeight(true, false);
         Assert.AreEqual(100.0, m.getThickness(), 1.0);
         JDFMedia m2 = (JDFMedia)m.addPartition(EnumPartIDKey.Run, "r1");
         m2.setWeight(40.0);
         m.setThicknessFromWeight(true, true);
         Assert.AreEqual(50.0, m2.getThickness(), 1.0);
         Assert.AreEqual(100.0, m.getThickness(), 1.0);
      }


      [TestMethod]
      public void testHoleType()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode root = doc.getJDFRoot();
         JDFResourcePool resPool = root.getCreateResourcePool();

         // check HoleType for JDFMedia
         KElement kElem = resPool.appendResource(ElementName.MEDIA,
            EnumResourceClass.Consumable, null);
         Assert.IsTrue(kElem is JDFMedia);
         JDFMedia media = ((JDFMedia)kElem);

         List<ValuedEnum> v = new List<ValuedEnum>();
         v.Add(EnumHoleType.None);
         v.Add(EnumHoleType.C9_5m_round_0t);
         Assert.AreEqual("C9.5m-round-0t", EnumHoleType.C9_5m_round_0t.getName());

         media.setHoleType(v);
         CollectionAssert.AreEqual(media.getHoleType(), v);
         Assert.AreEqual(v[1].getName(), ((EnumHoleType)media.getHoleType()[1]).getName());
         Assert.AreEqual("C9.5m-round-0t", ((EnumHoleType)media.getHoleType()[1]).getName());

         // overwrite HoleType low level to check if conversion of DOT and HYPHEN
         // to UNDERSCORE was successful
         media.setAttribute(AttributeName.HOLETYPE, "C9.5m-round-0t");
         Assert.AreEqual(EnumHoleType.C9_5m_round_0t, (media.getHoleType()[0]));

         // now check the same with JDFHoleMakingParams
         kElem = resPool.appendResource(ElementName.HOLEMAKINGPARAMS,
            EnumResourceClass.Consumable, null);
         Assert.IsTrue(kElem is JDFHoleMakingParams);
         JDFHoleMakingParams holeMakingParams = ((JDFHoleMakingParams)kElem);

         holeMakingParams.setHoleType(v);
         CollectionAssert.AreEqual(holeMakingParams.getHoleType(), v);
         Assert.AreEqual(v[1].getName(), ((EnumHoleType)holeMakingParams.getHoleType()[1]).getName());
         Assert.AreEqual("C9.5m-round-0t", ((EnumHoleType)holeMakingParams.getHoleType()[1]).getName());
      }
   }
}
