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
   using System;
   using System.Text;
   using Microsoft.VisualStudio.TestTools.UnitTesting;


   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using JDFColor = org.cip4.jdflib.resource.process.JDFColor;
   using JDFColorPool = org.cip4.jdflib.resource.process.JDFColorPool;

   ///
   /// <summary> * @author MuchaD
   /// * 
   /// *         This implements the first fixture with unit tests for class
   /// *         JDFElement. </summary>
   /// 
   [TestClass]
   public class JDFColorPoolTest : JDFTestCaseBase
   {
      internal JDFColorPool cp;

      [TestInitialize]
      public override void setUp()
      {
         try
         {
            base.setUp();
         }
         catch (Exception)
         {
            //
         }
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setType("Interpreting", false);
         cp = (JDFColorPool)n.addResource("ColorPool", null, EnumUsage.Input, null, null, null, null);
         cp.appendColorWithName("Cyan", "true");
         cp.appendColorWithName("Gr�n", "Gr�n");
         ((JDFColor)cp.appendElement("jdf:Color", JDFElement.getSchemaURL())).setName("foo");
      }

      ///   
      ///	 <summary> * Method testIncludesAttribute.
      ///	 *  </summary>
      ///	 * <exception cref="Exception"> </exception>
      ///	 
      [TestMethod]
      public virtual void testGetColorWithName()
      {
         Assert.IsNotNull(cp.getColorWithName("Gr�n"), "gr�n");
         bool caught = false;
         try
         {
            cp.appendColorWithName("Gr�n", "Gr�n");
         }
         catch (JDFException)
         {
            caught = true;
         }
         Assert.IsTrue(caught, "noappend");
      }

      ///   
      ///	 <summary> * Method testIncludesAttribute.
      ///	 *  </summary>
      ///	 * <exception cref="Exception"> </exception>
      ///	 
      [TestMethod]
      public virtual void testGetCreateColorWithName()
      {
         Assert.IsNotNull(cp.getCreateColorWithName("Gr�n", null), "gr�n");
      }


      [TestMethod]
      public virtual void testRemoveColor()
      {
         Assert.AreEqual(3, cp.numChildElements("Color", null), "num");
         cp.removeColor("bar");
         Assert.AreEqual(3, cp.numChildElements("Color", null), "num");
         cp.removeColor("Gr�n");
         Assert.AreEqual(2, cp.numChildElements("Color", null), "num");
         cp.removeColor("foo");
         Assert.AreEqual(1, cp.numChildElements("Color", null), "num");
      }


      [TestMethod]
      public virtual void testDuplicateColor()
      {
         Assert.IsNull(cp.getDuplicateColors());
         JDFColor c = cp.appendColorWithName("grun", "grun");
         Assert.IsNull(cp.getDuplicateColors());
         c.set8BitNames(Encoding.Default.GetBytes("Gr�n"));
         c.setName("grun");
         Assert.IsTrue(cp.getDuplicateColors().Contains("grun"));
      }


      public override string ToString()
      {
         return cp == null ? null : cp.ToString();
      }
   }
}
