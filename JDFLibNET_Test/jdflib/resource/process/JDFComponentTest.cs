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
   using Microsoft.VisualStudio.TestTools.UnitTesting;

   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using EnumComponentType = org.cip4.jdflib.auto.JDFAutoComponent.EnumComponentType;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using JDFShape = org.cip4.jdflib.datatypes.JDFShape;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFNode = org.cip4.jdflib.node.JDFNode;

   [TestClass]
   public class JDFComponentTest : JDFTestCaseBase
   {
      private JDFComponent c;
      private JDFNode root;
      private JDFDoc doc;

      ///   
      ///	 <summary> * tests the separationlist class
      ///	 *  </summary>
      ///	 
      [TestMethod]
      public void testSetDimensions()
      {
         c.setDimensions(new JDFXYPair(1, 2));
         Assert.AreEqual(new JDFShape(1, 2, 0), c.getDimensions());
      }


      [TestInitialize]
      public override void setUp()
      {
         base.setUp();
         doc = new JDFDoc("JDF");
         root = doc.getJDFRoot();
         c = (JDFComponent)root.addResource(ElementName.COMPONENT, EnumUsage.Input);
      }



      [TestMethod]
      public virtual void testSetComponentTypeAuto()
      {
         c.setComponentType(null);
         Assert.IsFalse(c.hasAttribute(AttributeName.COMPONENTTYPE));
      }



      ///   
      ///	 <summary> *  </summary>
      ///	 
      [TestMethod]
      public virtual void testGetMediaLayout()
      {
         c.setComponentType(null);
         JDFLayout lo = c.appendLayout();
         JDFMedia m = lo.appendMedia();
         Assert.AreEqual(m, c.getMedia());
         lo.makeRootResource(null, null, true);
         Assert.AreEqual(m, c.getMedia());
      }


      [TestMethod]
      public virtual void testGetMedia()
      {
         c.setComponentType(null);
         JDFMedia m = (JDFMedia)c.appendElement(ElementName.MEDIA);
         Assert.AreEqual(m, c.getMedia());
      }


      [TestMethod]
      public virtual void testSetComponentType()
      {
         c.setComponentType(EnumComponentType.PartialProduct, EnumComponentType.Sheet);
         Assert.IsTrue(c.hasAttribute(AttributeName.COMPONENTTYPE));
         Assert.AreEqual(2, c.getComponentType().Count);
         Assert.IsTrue(c.getComponentType().Contains(EnumComponentType.PartialProduct));
      }


      public override string ToString()
      {
         return c.ToString();
      }


      [TestMethod]
      public virtual void testComponentManifest()
      {
         root.getLink(c, null).setUsage(EnumUsage.Output);
         // TODO complete

         doc.write2File(sm_dirTestDataTemp + "ComponentManifest.jdf", 2, false);
      }
   }
}
