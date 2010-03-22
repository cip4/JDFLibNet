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
   using System.Text;
   using Microsoft.VisualStudio.TestTools.UnitTesting;

   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFSeparationList = org.cip4.jdflib.core.JDFSeparationList;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using EnumValidationLevel = org.cip4.jdflib.core.KElement.EnumValidationLevel;
   using JDFCMYKColor = org.cip4.jdflib.datatypes.JDFCMYKColor;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using JDFResourcePool = org.cip4.jdflib.pool.JDFResourcePool;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using EnumResStatus = org.cip4.jdflib.resource.JDFResource.EnumResStatus;
   using EnumResourceClass = org.cip4.jdflib.resource.JDFResource.EnumResourceClass;
   using StringUtil = org.cip4.jdflib.util.StringUtil;

   [TestClass]
   public class JDFColorantControlTest : JDFTestCaseBase
   {
      private JDFNode elem;
      private JDFColorantControl colControl;
      private JDFSeparationList colParams;
      private JDFColorPool colPool;
      private JDFDoc d;

      ///   
      ///	 <summary> * tests the separationlist class
      ///	 *  </summary>
      ///	 
      [TestMethod]
      public void testColorantAlias()
      {
         JDFColorantAlias ca = colControl.appendColorantAlias();
         ca.setXMLComment("ColorantAlias that maps the predefined separation Black");
         ca.setReplacementColorantName("Green");
         Assert.IsTrue(ca.isValid(EnumValidationLevel.Incomplete));
         Assert.IsFalse(ca.isValid(EnumValidationLevel.Complete));
         VString vAlias = new VString("Grün grün", null);
         ca.setSeparations(vAlias);
         Assert.IsTrue(ca.isValid(EnumValidationLevel.Complete));
         byte[] b = Encoding.Default.GetBytes(vAlias.stringAt(0));
         string rawNames = StringUtil.setHexBinaryBytes(b, -1) + " ";
         b = Encoding.Default.GetBytes(vAlias.stringAt(1));
         rawNames += StringUtil.setHexBinaryBytes(b, -1);
         Assert.IsTrue(ca.isValid(EnumValidationLevel.Complete));
         ca.setAttribute("RawNames", rawNames);

         d.write2File(sm_dirTestDataTemp + "ColorantAlias.jdf", 2, false);
      }

      ///   
      ///	 <summary> * tests the proposed Color/@ActualColorName attribute
      ///	 *  </summary>
      ///	 
      [TestMethod]
      public void testActualColorName()
      {

         colParams.setXMLComment("Note that all Strings in ColorantParams etc. use Color/@Name, NOT Color/@ActualColorName");
         colParams.setSeparations(new VString("Spot1,BlackText", ","));
         colControl.setXMLComment("Simple colorantcontrol from MIS: CMYK + 1 spot+ 1 black text version; knows no more");
         d.write2File(sm_dirTestDataTemp + "ActualColorName_MIS.jdf", 2, false);

         colControl.setXMLComment("ColorantControl after prepress has correctly set ActualColorName based on pdl content");
         JDFColor co = colPool.appendColorWithName("Black", null);
         co.setXMLComment("Color that maps the predefined separation Black\n" + "ActualColorName is the new attribute that replaces ExposedMedia/@DescriptiveName as the \"Main\" PDL color");
         co.setCMYK(new JDFCMYKColor(0, 0, 0, 1));
         Assert.IsTrue(co.isValid(EnumValidationLevel.Incomplete));
         co.setAttribute("ActualColorName", "Schwarz");

         co = colPool.appendColorWithName("Yellow", null);
         co.setAttribute("ActualColorName", "Gelb");
         co.setCMYK(new JDFCMYKColor(0, 0, 1, 0));

         co = colPool.appendColorWithName("Cyan", null);
         co.setXMLComment("ActualColorName defaults to Name if not specified");
         co.setCMYK(new JDFCMYKColor(1, 0, 0, 0));

         co = colPool.appendColorWithName("Magenta", null);
         co = colPool.appendColorWithName("Spot1", null);
         co.setAttribute("ActualColorName", "Acme Aqua");
         co.setCMYK(new JDFCMYKColor(0.7, 0.2, 0.03, 0.1));

         co = colPool.appendColorWithName("BlackText", null);
         co.setAttribute("ActualColorName", "VersionsText");
         co.setCMYK(new JDFCMYKColor(0, 0, 0, 1));

         d.write2File(sm_dirTestDataTemp + "ActualColorName_Prepress.jdf", 2, false);

         JDFColorantAlias ca = colControl.appendColorantAlias();
         ca.setXMLComment("ColorantAlias that maps the additional representation (noir) to the predefined separation Black");
         ca.setReplacementColorantName("Black");
         Assert.IsTrue(ca.isValid(EnumValidationLevel.Incomplete));
         Assert.IsFalse(ca.isValid(EnumValidationLevel.Complete));
         VString vAlias = new VString("noir schwärz", null);
         ca.setSeparations(vAlias);
         Assert.IsTrue(ca.isValid(EnumValidationLevel.Complete));
         byte[] b = Encoding.Default.GetBytes(vAlias.stringAt(0));
         string rawNames = StringUtil.setHexBinaryBytes(b, -1) + " ";
         b = Encoding.Default.GetBytes(vAlias.stringAt(1));
         rawNames += StringUtil.setHexBinaryBytes(b, -1);
         ca.setAttribute("RawNames", rawNames);
         d.write2File(sm_dirTestDataTemp + "ActualColorName_with_CA.jdf", 2, false);
      }

      ///   
      ///	 <summary> * tests the separationlist class
      ///	 *  </summary>
      ///	 
      [TestMethod]
      public void testSeparationList()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode root = doc.getJDFRoot();
         JDFResourcePool resPool = root.getCreateResourcePool();
         KElement kElem = resPool.appendResource(ElementName.COLORANTCONTROL, null, null);
         Assert.IsTrue(kElem is JDFColorantControl);
         JDFColorantControl cc = ((JDFColorantControl)kElem);
         JDFSeparationList co = cc.appendColorantOrder();
         VString seps = new VString(StringUtil.tokenize("Cyan Magenta Yellow Black", " ", false));

         co.setSeparations(seps);
         CollectionAssert.AreEqual(co.getSeparations(), seps);
         VElement vSepSpec = co.getChildElementVector(ElementName.SEPARATIONSPEC, null, null, true, 0, true);
         Assert.AreEqual(seps.Count, vSepSpec.Count);
         for (int i = 0; i < vSepSpec.Count; i++)
         {
            Assert.IsFalse(vSepSpec.item(i).hasAttribute(AttributeName.CLASS));
            Assert.IsFalse(vSepSpec.item(i) is JDFResource);
         }

         Assert.AreEqual("Cyan", co.getSeparation(0));
         co.removeSeparation("Magenta");
         Assert.AreEqual("Cyan", co.getSeparation(0));
         Assert.AreEqual("Yellow", co.getSeparation(1));
         Assert.AreEqual("Black", co.getSeparation(2));
         Assert.IsNull(co.getSeparation(3));
      }

      ///   
      ///	 <summary> * tests the separationlist class
      ///	 *  </summary>
      ///	 
      [TestMethod]
      public void testGetSeparations()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode root = doc.getJDFRoot();
         JDFResourcePool resPool = root.getCreateResourcePool();
         KElement kElem = resPool.appendResource(ElementName.COLORANTCONTROL, null, null);
         Assert.IsTrue(kElem is JDFColorantControl);
         JDFColorantControl cc = ((JDFColorantControl)kElem);
         cc.setProcessColorModel("DeviceCMYK");
         Assert.IsTrue(cc.getSeparations().Contains("Cyan"));
         cc.appendColorantParams().appendSeparation("Snarf Blue");
         Assert.IsTrue(cc.getSeparations().Contains("Snarf Blue"));
      }


      [TestMethod]
      public virtual void testColorantParams()
      {
         Assert.IsTrue(colParams.isValid(KElement.EnumValidationLevel.RecursiveComplete));
      }


      [TestMethod]
      public virtual void testGetDeviceColorantOrderSeparations()
      {
         colParams.appendSeparation("Black");
         CollectionAssert.AreEqual(colControl.getSeparations(), colControl.getDeviceColorantOrderSeparations());
         Assert.AreEqual(4, colControl.getDeviceColorantOrderSeparations().Count);
         colParams.appendSeparation("Green");
         CollectionAssert.AreEqual(colControl.getSeparations(), colControl.getDeviceColorantOrderSeparations());
         Assert.AreEqual(5, colControl.getDeviceColorantOrderSeparations().Count);
         colControl.appendColorantOrder().appendSeparation("Green");
         Assert.AreEqual(1, colControl.getDeviceColorantOrderSeparations().Count);
         Assert.AreEqual("Green", colControl.getDeviceColorantOrderSeparations().stringAt(0));
      }


      [TestMethod]
      public virtual void testGetColorantOrderSeparations()
      {
         colParams.appendSeparation("Black");
         CollectionAssert.AreEqual(colControl.getSeparations(), colControl.getColorantOrderSeparations());
         Assert.AreEqual(4, colControl.getColorantOrderSeparations().Count);
         colParams.appendSeparation("Green");
         CollectionAssert.AreEqual(colControl.getSeparations(), colControl.getColorantOrderSeparations());
         Assert.AreEqual(5, colControl.getColorantOrderSeparations().Count);
      }

      ///   
      ///	 <summary> * @return </summary>
      ///	
      [TestInitialize]
      public override void setUp()
      {
         base.setUp();
         JDFElement.setLongID(false);
         d = new JDFDoc(ElementName.JDF);
         elem = d.getJDFRoot();
         JDFResourcePool rpool = elem.appendResourcePool();
         colControl = (JDFColorantControl)rpool.appendResource(ElementName.COLORANTCONTROL, EnumResourceClass.Parameter, null);
         colControl.setProcessColorModel("DeviceCMYK");
         colControl.setResStatus(EnumResStatus.Available, true);
         colParams = colControl.appendColorantParams();
         colPool = colControl.appendColorPool();
         colPool.makeRootResource(null, null, true);
      }
   }
}
