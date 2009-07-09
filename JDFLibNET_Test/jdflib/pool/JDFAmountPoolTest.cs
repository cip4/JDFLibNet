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


namespace org.cip4.jdflib.pool
{
   using Microsoft.VisualStudio.TestTools.UnitTesting;

   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFPartAmount = org.cip4.jdflib.core.JDFPartAmount;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using EnumType = org.cip4.jdflib.node.JDFNode.EnumType;
   using AmountMap = org.cip4.jdflib.pool.JDFAmountPool.AmountMap;
   using EnumPartIDKey = org.cip4.jdflib.resource.JDFResource.EnumPartIDKey;
   using JDFComponent = org.cip4.jdflib.resource.process.JDFComponent;

   ///
   /// <summary> * @author RP
   /// * 
   /// *         This implements the first fixture with unit tests for class
   /// *         JDFAmountPool. </summary>
   /// 
   [TestClass]
   public class JDFAmountPoolTest : JDFTestCaseBase
   {

      ///   
      ///	 * <seealso cref= junit.framework.TestCase#toString() </seealso>
      ///	 * <returns> the string </returns>
      ///	 
      public override string ToString()
      {
         return ap == null ? " empty amountpooltest " : ap.ToString();
      }

      internal JDFAmountPool ap;

      ///   
      ///	 <summary> * Method testVirtualAmounts.
      ///	 *  </summary>
      ///	 * <exception cref="Exception"> </exception>
      ///	 
      [TestMethod]
      public virtual void testReducePartAmounts()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setType(EnumType.ConventionalPrinting);
         JDFComponent comp = (JDFComponent)n.addResource("Component", null, EnumUsage.Output, null, null, null, null);
         JDFAttributeMap map = new JDFAttributeMap(EnumPartIDKey.SignatureName, "Sig1");
         JDFResourceLink rl = n.getLink(comp, null);
         for (int i = 0; i < 5; i++)
         {
            map.put(EnumPartIDKey.SheetName, "Sheet" + i);
            comp.getCreatePartition(map, new VString("SignatureName SheetName", " "));
            rl.setAmount(500 + i, map);
            JDFAttributeMap map2 = new JDFAttributeMap(map);
            map2.put("Condition", "Good");
            rl.setActualAmount(500 + i, map2);
            map2.put("Condition", "Waste");
            rl.setActualAmount(50 + i, map2);
         }
         VJDFAttributeMap v = new VJDFAttributeMap();
         JDFAttributeMap testMap = new JDFAttributeMap(EnumPartIDKey.Condition, "Good");
         v.Add(testMap);
         JDFAmountPool aplocal = rl.getAmountPool();
         Assert.AreEqual(15, aplocal.numChildElements(ElementName.PARTAMOUNT, null), "15 pa entries");
         aplocal.reducePartAmounts(v);
         Assert.AreEqual(5, aplocal.numChildElements(ElementName.PARTAMOUNT, null), "5 pa entries");
         testMap.put("SheetName", "Sheet3");
         aplocal.reducePartAmounts(v);
         Assert.AreEqual(1, aplocal.numChildElements(ElementName.PARTAMOUNT, null), "1 pa entries");
      }

      ///   
      ///	 <summary> * Method testVirtualAmounts.
      ///	 *  </summary>
      ///	 * <exception cref="Exception"> </exception>
      ///	 
      [TestMethod]
      public virtual void testVirtualAmounts()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setType(EnumType.ConventionalPrinting);
         JDFComponent comp = (JDFComponent)n.addResource("Component", null, EnumUsage.Output, null, null, null, null);
         JDFAttributeMap map = new JDFAttributeMap(EnumPartIDKey.SignatureName, "Sig1");
         JDFResourceLink rl = n.getLink(comp, null);
         for (int i = 0; i < 5; i++)
         {
            map.put(EnumPartIDKey.SheetName, "Sheet" + i);
            comp.getCreatePartition(map, new VString("SignatureName SheetName", " "));
            rl.setAmount(500 + i, map);
            JDFAttributeMap map2 = new JDFAttributeMap(map);
            map2.put("Condition", "Good");
            rl.setActualAmount(500 + i, map2);
            map2.put("Condition", "Waste");
            rl.setActualAmount(50 + i, map2);

            map2.put("Condition", "Good");
            Assert.AreEqual(500 + i, rl.getActualAmount(map2), 0.01);
            map2.put("Condition", "Waste");
            Assert.AreEqual(50 + i, rl.getActualAmount(map2), 0.01);
         }
      }


      ///   
      ///	 <summary> * Method testGetMatchingPartAmountVector.
      ///	 *  </summary>
      ///	 * <exception cref="Exception"> </exception>
      ///	 
      [TestMethod]
      public virtual void testGetMatchingPartAmountVector()
      {
         JDFDoc d = JDFTestCaseBase.creatXMDoc();
         JDFNode n = d.getJDFRoot();
         JDFResourceLink xmLink = n.getLink(0, ElementName.EXPOSEDMEDIA, null, null);
         JDFAttributeMap mPart = new JDFAttributeMap("SignatureName", "Sig1");
         mPart.put("SheetName", "S1");
         mPart.put("Side", "Front");
         mPart.put("Separation", "Black");
         mPart.put("Condition", "Good");
         xmLink.setAmount(2, mPart);
         mPart.put("Condition", "Waste");
         xmLink.setAmount(1, mPart);

         JDFAmountPool aplocal = xmLink.getAmountPool();
         Assert.IsNotNull(aplocal);
         mPart.Remove("Condition");

         VElement v = aplocal.getMatchingPartAmountVector(mPart);
         Assert.AreEqual(2, v.Count);
         mPart.put("Side", "Moebius");
         v = aplocal.getMatchingPartAmountVector(mPart);
         Assert.IsNull(v, "there certainly is no moebius side ...");
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.JDFTestCaseBase#setUp()
      //	 
      [TestInitialize]
      public override void setUp()
      {
         base.setUp();
         ap = (JDFAmountPool)new JDFDoc(ElementName.AMOUNTPOOL).getRoot();
      }

      ///   
      ///	 <summary> * Method testGetMatchingPartAmountVector.
      ///	 *  </summary>
      ///	 * <exception cref="Exception"> </exception>
      ///	 
      [TestMethod]
      public virtual void testGetPartAmountMulti()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setType(EnumType.ConventionalPrinting);
         JDFComponent comp = (JDFComponent)n.addResource("Component", null, EnumUsage.Output, null, null, null, null);
         JDFAttributeMap map = new JDFAttributeMap(EnumPartIDKey.SignatureName, "Sig1");
         JDFAttributeMap mapSig = new JDFAttributeMap(map);
         JDFAttributeMap map2 = new JDFAttributeMap(EnumPartIDKey.SignatureName, "Sig1");
         JDFResourceLink rl = n.getLink(comp, null);
         map.put(EnumPartIDKey.SheetName, "Sheet");
         comp.getCreatePartition(map, new VString("SignatureName SheetName", " "));
         map.put(EnumPartIDKey.Side, "Front");
         map2.put(EnumPartIDKey.Side, "Back");
         VJDFAttributeMap vMap = new VJDFAttributeMap();
         vMap.Add(map);
         vMap.Add(map2);
         JDFAmountPool aplocal = rl.appendAmountPool();
         JDFPartAmount pa = aplocal.appendPartAmount(vMap);
         Assert.AreEqual(pa.numChildElements_JDFElement(ElementName.PART, null), 2);
         rl.setActualAmount(42, map);
         rl.setActualAmount(21, map2);
         Assert.AreEqual(2, pa.numChildElements_JDFElement(ElementName.PART, null));
         Assert.AreEqual(42.0, rl.getActualAmount(map), 0.0);
         Assert.AreEqual(42.0 + 21.0, rl.getActualAmount(mapSig), 0.0);
         Assert.AreEqual(aplocal.getPartAmount(vMap), pa);
      }

      ///   
      ///	 <summary> * Method testGetMatchingPartAmountVector.
      ///	 *  </summary>
      ///	 * <exception cref="Exception"> </exception>
      ///	 
      [TestMethod]
      public virtual void testGetCreatePartAmount()
      {
         JDFAttributeMap map = new JDFAttributeMap("Separation", "Black");
         JDFAttributeMap map2 = new JDFAttributeMap("Separation", "Cyan");
         VJDFAttributeMap vMap = new VJDFAttributeMap();
         vMap.Add(map);
         vMap.Add(map2);

         JDFPartAmount pa1 = ap.getCreatePartAmount(map);
         Assert.AreEqual(map, pa1.getPartMap());
         JDFPartAmount pa3 = ap.getCreatePartAmount(vMap);
         Assert.AreEqual(vMap, pa3.getPartMapVector());
         JDFPartAmount pa4 = ap.getCreatePartAmount(vMap);
         Assert.AreEqual(pa3, pa4);
         JDFPartAmount pa2 = ap.getCreatePartAmount(map2);
         Assert.AreEqual(map2, pa2.getPartMap());
      }

      ///   
      ///	 <summary> * Method testGetMatchingPartAmountVector.
      ///	 *  </summary>
      ///	 * <exception cref="Exception"> </exception>
      ///	 
      [TestMethod]
      public virtual void testGetAmountMap()
      {
         JDFAttributeMap map = new JDFAttributeMap("Separation", "Black");
         JDFAttributeMap map2 = new JDFAttributeMap("Separation", "Cyan");
         VJDFAttributeMap vMap = new VJDFAttributeMap();
         vMap.Add(new JDFAttributeMap(map));
         vMap.Add(new JDFAttributeMap(map2));
         for (int i = 0; i < 10; i++)
         {
            vMap.put("SignatureName", "Sig" + i);
            for (int j = 0; j < 100; j++)
            {
               vMap.put("SheetName", "Sheet" + j);
               ap.appendPartAmount(vMap).setAmount(j, null);
            }
         }
         AmountMap am = ap.getAmountMap(new VString("Separation", null));
         Assert.AreEqual(2, am.Count);
         Assert.AreEqual(50 * 99 * 10.0, am.getAmountDouble(map, "Amount"), 0.0);

         am = ap.getAmountMap(new VString("SheetName Separation", null));
         Assert.AreEqual(200, am.Count);
         Assert.AreEqual(-1.0, am.getAmountDouble(map, "Amount"), 0.0);
         map.put("SheetName", "Sheet12");
         Assert.AreEqual(10 * 12.0, am.getAmountDouble(map, "Amount"), 0.0, "10 signatures * 12");
      }

      ///   
      ///	 <summary> * make sure no npe in empty amountpools
      ///	 *  </summary>
      ///	 * <exception cref="Exception"> </exception>
      ///	 
      [TestMethod]
      public virtual void testGetPartAmountNull()
      {
         JDFAttributeMap map = new JDFAttributeMap("Separation", "Black");
         VJDFAttributeMap vMap = new VJDFAttributeMap();
         vMap.Add(map);

         JDFResourceLink rl = (JDFResourceLink)new JDFDoc("MediaLink").getRoot();
         ap = rl.appendAmountPool();
         Assert.IsNull(ap.getPartAmount(vMap));
         Assert.IsNull(ap.getPartAmount(map));
         Assert.IsNull(ap.getPartAmount(2));
         Assert.IsNull(ap.getPartAmount(0));

         JDFPartAmount pa = ap.appendPartAmount();
         Assert.IsNull(ap.getPartAmount(vMap));
         Assert.IsNull(ap.getPartAmount(map));
         Assert.IsNull(ap.getPartAmount(2));
         Assert.AreEqual(pa, ap.getPartAmount(0));
      }
   }
}
