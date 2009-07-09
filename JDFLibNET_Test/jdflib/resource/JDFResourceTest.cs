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
 * JDFResourceTest.cs
 *
 * @author Dietrich Mucha
 *
 * Copyright (C) 2002 Heidelberger Druckmaschinen AG. All Rights Reserved. 
 */

namespace org.cip4.jdflib.resource
{
   using System;
   using System.Collections;
   using System.Collections.Generic;
   using Microsoft.VisualStudio.TestTools.UnitTesting;


   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using EnumSourceObjects = org.cip4.jdflib.auto.JDFAutoColorSpaceConversionOp.EnumSourceObjects;
   using EnumPreviewType = org.cip4.jdflib.auto.JDFAutoPart.EnumPreviewType;
   using EnumSide = org.cip4.jdflib.auto.JDFAutoPart.EnumSide;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFAudit = org.cip4.jdflib.core.JDFAudit;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFNodeInfo = org.cip4.jdflib.core.JDFNodeInfo;
   using JDFParser = org.cip4.jdflib.core.JDFParser;
   using JDFRefElement = org.cip4.jdflib.core.JDFRefElement;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using XMLDoc = org.cip4.jdflib.core.XMLDoc;
   using EnumVersion = org.cip4.jdflib.core.JDFElement.EnumVersion;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using EnumValidationLevel = org.cip4.jdflib.core.KElement.EnumValidationLevel;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using EnumProcessUsage = org.cip4.jdflib.node.JDFNode.EnumProcessUsage;
   using EnumType = org.cip4.jdflib.node.JDFNode.EnumType;
   using JDFResourcePool = org.cip4.jdflib.pool.JDFResourcePool;
   using EnumPartIDKey = org.cip4.jdflib.resource.JDFResource.EnumPartIDKey;
   using EnumPartUsage = org.cip4.jdflib.resource.JDFResource.EnumPartUsage;
   using EnumResStatus = org.cip4.jdflib.resource.JDFResource.EnumResStatus;
   using EnumResourceClass = org.cip4.jdflib.resource.JDFResource.EnumResourceClass;
   using JDFBinderySignature = org.cip4.jdflib.resource.process.JDFBinderySignature;
   using JDFColorPool = org.cip4.jdflib.resource.process.JDFColorPool;
   using JDFColorantControl = org.cip4.jdflib.resource.process.JDFColorantControl;
   using JDFComponent = org.cip4.jdflib.resource.process.JDFComponent;
   using JDFContact = org.cip4.jdflib.resource.process.JDFContact;
   using JDFCutBlock = org.cip4.jdflib.resource.process.JDFCutBlock;
   using JDFDigitalPrintingParams = org.cip4.jdflib.resource.process.JDFDigitalPrintingParams;
   using JDFExposedMedia = org.cip4.jdflib.resource.process.JDFExposedMedia;
   using JDFGeneralID = org.cip4.jdflib.resource.process.JDFGeneralID;
   using JDFLayout = org.cip4.jdflib.resource.process.JDFLayout;
   using JDFLayoutElement = org.cip4.jdflib.resource.process.JDFLayoutElement;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;
   using JDFPreview = org.cip4.jdflib.resource.process.JDFPreview;
   using JDFRunList = org.cip4.jdflib.resource.process.JDFRunList;
   using JDFSeparationSpec = org.cip4.jdflib.resource.process.JDFSeparationSpec;
   using JDFStripCellParams = org.cip4.jdflib.resource.process.JDFStripCellParams;
   using JDFFoldingParams = org.cip4.jdflib.resource.process.postpress.JDFFoldingParams;
   using JDFColorSpaceConversionOp = org.cip4.jdflib.resource.process.prepress.JDFColorSpaceConversionOp;
   using JDFColorSpaceConversionParams = org.cip4.jdflib.resource.process.prepress.JDFColorSpaceConversionParams;
   using StringUtil = org.cip4.jdflib.util.StringUtil;
   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   [TestClass]
   public class JDFResourceTest : JDFTestCaseBase
   {

      private bool b;

      [TestMethod]
      public virtual void testGetCreator()
      {
         JDFDoc doc = creatXMDoc();
         JDFNode n = doc.getJDFRoot();
         JDFExposedMedia xm = (JDFExposedMedia)n.getMatchingResource("ExposedMedia", JDFNode.EnumProcessUsage.AnyInput, null, 0);
         Assert.IsTrue(xm.getCreator(false).Contains(n));
      }


      [TestMethod]
      public virtual void testGetAttributeVector()
      {
         JDFDoc doc = creatXMDoc();
         JDFNode n = doc.getJDFRoot();
         JDFExposedMedia xm = (JDFExposedMedia)n.getMatchingResource("ExposedMedia", JDFNode.EnumProcessUsage.AnyInput, null, 0);
         JDFAttributeMap mPart = new JDFAttributeMap("SignatureName", "Sig1");
         mPart.put("SheetName", "S1");
         mPart.put("Side", "Front");
         JDFExposedMedia xmPart = (JDFExposedMedia)xm.getPartition(mPart, null);
         xmPart.setAgentName("agent");
         xmPart.setAttribute("foo:bar", "foobar", "www.foo.com");
         VString partVector = xmPart.getAttributeVector();
         Assert.IsTrue(partVector.Contains("ID"), "contains inherited attributes");
         Assert.IsTrue(partVector.Contains("SignatureName"), "contains inherited attributes");
         Assert.IsTrue(partVector.Contains("SheetName"), "contains inherited attributes");
         Assert.IsTrue(partVector.Contains("Side"), "contains inherited attributes");
         Assert.IsTrue(partVector.Contains("AgentName"), "contains inherited attributes");
         Assert.IsTrue(partVector.Contains("foo:bar"), "contains inherited attributes");
      }

      ///   
      ///	 <summary> * test the the generalized partition matching
      ///	 *  </summary>
      ///	 
      [TestMethod]
      public virtual void testGetAttributeMap()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFNode root = doc.getJDFRoot();
         root.setType(JDFNode.EnumType.ConventionalPrinting.getName(), true);
         JDFExposedMedia xm = (JDFExposedMedia)root.appendMatchingResource(ElementName.EXPOSEDMEDIA, JDFNode.EnumProcessUsage.AnyInput, null);
         xm.setResolution(new JDFXYPair(300, 300));
         xm.setPolarity(true);
         xm.setProofType(JDFExposedMedia.EnumProofType.Page);

         JDFMedia m = xm.appendMedia();
         m.setDimension(new JDFXYPair(200, 300));
         JDFExposedMedia xm2 = (JDFExposedMedia)xm.addPartition(EnumPartIDKey.SheetName, "S1");
         JDFAttributeMap xm2Map = xm2.getAttributeMap();
         xm2Map.Remove(EnumPartIDKey.SheetName.ToString());
         Assert.AreEqual(xm2Map, xm.getAttributeMap());
         xm.setAttribute("foo:bar", "foobar", "www.foo.com");
         JDFAttributeMap am = xm.getAttributeMap();
         Assert.AreEqual("foobar", am.get("foo:bar"));
         am = xm2.getAttributeMap();
         Assert.AreEqual("foobar", am.get("foo:bar"));
      }

      ///   
      ///	 <summary> * test the the generalized partition matching
      ///	 *  </summary>
      ///	 
      [TestMethod]
      public virtual void testOverlapPartMap()
      {
         JDFAttributeMap m1 = new JDFAttributeMap("PartVersion", "DE EN");
         m1.put("Run", "r2");
         JDFAttributeMap m2 = new JDFAttributeMap("PartVersion", "DE EN");
         Assert.IsTrue(JDFPart.overlapPartMap(m1, m2));
         m2.put("Run", "r2");
         Assert.IsTrue(JDFPart.overlapPartMap(m1, m2));
      }

      ///   
      ///	 <summary> * test initialization and setAutoAgent </summary>
      ///	 
      [TestMethod]
      public virtual void testInit()
      {
         for (int i = 0; i < 2; i++)
         {
            bool bb = i == 0;
            JDFResource.setAutoAgent(bb);
            JDFAudit.setStaticAgentName(JDFAudit.software());
            JDFAudit.setStaticAgentVersion(JDFElement.getDefaultJDFVersion().getName());
            JDFDoc doc = creatXMDoc();
            JDFNode n = doc.getJDFRoot();
            JDFExposedMedia xm = (JDFExposedMedia)n.getMatchingResource("ExposedMedia", JDFNode.EnumProcessUsage.AnyInput, null, 0);
            Assert.IsTrue(xm.hasAttribute(AttributeName.AGENTNAME) == bb);
            Assert.IsTrue(xm.hasAttribute(AttributeName.AGENTVERSION) == bb);
            JDFAudit.setStaticAgentName("foo");
            xm.init();
            if (bb)
            {
               Assert.AreEqual("foo", xm.getAgentName());
            }
         }
      }


      [TestMethod]
      public virtual void testMakeRootResource()
      {
         JDFNode n = new JDFDoc("JDF").getJDFRoot();
         JDFResourcePool p = n.appendResourcePool();
         JDFExposedMedia xm = (JDFExposedMedia)n.addResource(ElementName.EXPOSEDMEDIA, EnumUsage.Input);
         JDFMedia m = xm.appendMedia();
         JDFMedia m2 = (JDFMedia)m.makeRootResource(null, null, true);
         Assert.AreEqual(m2, m);
         Assert.AreEqual(p, m2.getParentNode_KElement());
      }

      ///   
      ///	 <summary> * test the the generalized partition matching
      ///	 *  </summary>
      ///	 
      [TestMethod]
      public virtual void testMatchesPart()
      {
         Assert.IsTrue(JDFPart.matchesPart("PartVersion", "DE EN FR", "DE EN FR"));
         Assert.IsTrue(JDFPart.matchesPart("RunIndex", "1 ~ 4", "2 3"));
         Assert.IsTrue(JDFPart.matchesPart("RunIndex", "1 ~ 3 5 ~ 6", "3 5"));
         Assert.IsFalse(JDFPart.matchesPart("RunIndex", "1 ~ 3 6 ~ 8", "3 ~ 6"));
         Assert.IsTrue(JDFPart.matchesPart("PartVersion", "DE EN", "DE EN"));
         Assert.IsFalse(JDFPart.matchesPart("PartVersion", "DE EN", "DEU"));
         Assert.IsTrue(JDFPart.matchesPart("Run", "R1", "R1"));
         Assert.IsFalse(JDFPart.matchesPart("Run", "R1 R2", "R1"));
         Assert.IsFalse(JDFPart.matchesPart("Run", "R2", "R1"));
         Assert.IsFalse(JDFPart.matchesPart("RunIndex", "1 ~ 4", "5"));
      }

      ///   
      ///	 <summary> * test the resource root stuff
      ///	 *  </summary>
      ///	 
      [TestMethod]
      public virtual void testGetResourcePoolNS()
      {
         // set up a test document
         JDFDoc jdfDoc = new JDFDoc("JDF");
         JDFNode root = jdfDoc.getJDFRoot();
         root.appendElement("foo:elem", "www.foo.com");
         JDFResourcePool rp = root.appendResourcePool();
         rp.appendResource("foo:res", EnumResourceClass.Parameter, "www.foo.com");
         rp.appendElement("foo:res", "www.foo.com");
         rp.appendElement("foo:elem", "www.foo.com");
      }


      [TestMethod]
      public virtual void testGetResourceRootNI13()
      {
         JDFNode rootNode = new JDFDoc("JDF").getJDFRoot();
         JDFNodeInfo ni = rootNode.getCreateNodeInfo();
         JDFContact con = ni.appendContact();
         Assert.AreEqual(ni, con.getResourceRoot());
      }

      ///   
      ///	 <summary> * test the resource root stuff
      ///	 *  </summary>
      ///	 
      [TestMethod]
      public virtual void testGetResourceRoot()
      {
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         n.setVersion(EnumVersion.Version_1_1);
         JDFLayout l = (JDFLayout)n.addResource(ElementName.LAYOUT, EnumUsage.Input);
         KElement e = l.appendSignature().appendSheet().appendContentObject();
         Assert.AreEqual(l, JDFResource.getResourceRoot(e));
         Assert.AreEqual(l, JDFResource.getResourceRoot(l));
         Assert.IsNull(JDFResource.getResourceRoot(n));
         Assert.IsNull(JDFResource.getResourceRoot(n.getAuditPool()));
      }

      ///   
      ///	 <summary> * test the resource root stuff
      ///	 *  </summary>
      ///	 
      [TestMethod]
      public virtual void testGetResourceRoot_Old()
      {
         // set up a test document
         XMLDoc jdfDoc = new XMLDoc(ElementName.COLORPOOL, JDFElement.getSchemaURL());
         JDFElement root = (JDFElement)jdfDoc.getRoot();
         JDFResource resource;
         JDFResource resRoot;

         // !(parentName != null && !parentName.equals(JDFConstants.EMPTYSTRING)
         // resRoot = ((JDFResource) root).getResourceRoot();
         // Assert.IsTrue(resRoot == null);

         resource = (JDFResource)root.appendElement(ElementName.COLOR);

         // isResourceStatic((JDFElement) parentNode)
         // Rekursion : !(parentName != null &&
         // !parentName.equals(JDFConstants.EMPTYSTRING)
         // resRoot = resource.getResourceRoot();
         // Assert.IsNull(resRoot);

         // set up a test document
         jdfDoc = new JDFDoc(ElementName.RESOURCEPOOL);
         root = (JDFElement)jdfDoc.getRoot();

         resource = (JDFResource)root.appendElement(ElementName.COLOR);

         // StringUtil.hasToken(validParentNodeNames(), parentName,
         // JDFConstants.COMMA)
         resRoot = resource.getResourceRoot();
         Assert.IsTrue(resRoot == resource);

         // set up a test document
         JDFDoc jdfDoc2 = new JDFDoc(ElementName.JDF);
         root = jdfDoc2.getJDFRoot();

         resource = (JDFResource)root.appendElement(ElementName.COLOR);
         JDFResource elem = (JDFResource)root.appendElement(ElementName.NODEINFO);

         resRoot = resource.getResourceRoot();
         Assert.IsNull(resRoot);

         // localName.equals(ElementName.NODEINFO) ||
         // localName.equals(ElementName.CUSTOMERINFO)
         resRoot = elem.getResourceRoot();
         Assert.IsTrue(resRoot == elem);

         JDFNode rootNode = (JDFNode)root;
         JDFExposedMedia xm = (JDFExposedMedia)rootNode.addResource("ExposedMedia", null, EnumUsage.Input, null, null, null, null);
         JDFMedia m = xm.appendMedia();
         Assert.AreEqual(xm, xm.getResourceRoot(), "xm");
         Assert.AreEqual(xm, m.getResourceRoot(), "m");

         JDFColorantControl cc = (JDFColorantControl)rootNode.addResource("ColorantControl", null, EnumUsage.Input, null, null, null, null);
         JDFSeparationSpec ss = cc.appendColorantParams().appendSeparationSpec();
         Assert.IsFalse(ss.hasAttribute(AttributeName.CLASS));
      }


      [TestMethod]
      public virtual void testIsResourceElement()
      {
         // get the JDF document root element
         JDFDoc jdfDoc = new JDFDoc(ElementName.JDF);
         JDFNode root = (JDFNode)jdfDoc.getRoot();

         JDFNode trappingNode = new JDFNode((CoreDocumentImpl)root.OwnerDocument, root.getNamespaceURI(), root.Name);

         trappingNode.setType(JDFNode.EnumType.Trapping.getName(), false);

         // Add an intent resource
         JDFRunList runList = (JDFRunList)trappingNode.appendMatchingResource(ElementName.RUNLIST, JDFNode.EnumProcessUsage.AnyInput, null);

         JDFLayoutElement layoutElem = runList.appendLayoutElement();

         Assert.IsFalse(runList.isResourceElement());
         Assert.IsTrue(layoutElem.isResourceElement());
      }


      [TestMethod]
      public virtual void testgetPartMap()
      {
         string strFileName = sm_dirTestData + "partitioned_private_resources.jdf";
         JDFParser p = new JDFParser();

         JDFDoc myJDFDoc = p.parseFile(strFileName);
         JDFNode myRoot = myJDFDoc.getJDFRoot();
         JDFResourcePool myResPool = myRoot.getResourcePool();
         JDFResource myPreview = (JDFResource)myResPool.getElement("Preview", "", 0);
         JDFAttributeMap m = new JDFAttributeMap();

         // m.put("SheetName", "Sheet 1");
         m.put("Side", "Front");
         m.put("Separation", "Black");
         m.put("PreviewType", "Separation");

         myPreview = myPreview.getDeepPart(m, EnumPartUsage.Explicit);
         VElement vRes = myPreview.getLeaves(false);

         for (int i = 0; i < vRes.Count; i++)
         {
            JDFAttributeMap myMap = ((JDFResource)vRes[i]).getPartMap();
            if ("Black".Equals(myMap.get("Separation")))
            {
               Assert.IsTrue(myMap.get("Side").Equals("Front"));
               Assert.IsTrue(myMap.get("PreviewType").Equals("Separation"));
               Assert.IsTrue(myMap.get("SheetName").StartsWith("Sheet ")); // "Sheet 1"
               // or
               // "Sheet 2"
               Assert.IsTrue(myMap.get("Separation").Equals("Black"));
            }
         }
      }


      [TestMethod]
      public virtual void testgetPartValues()
      {
         string strFileName = sm_dirTestData + "partitioned_private_resources.jdf";
         JDFParser p = new JDFParser();

         JDFDoc myJDFDoc = p.parseFile(strFileName);
         JDFNode myRoot = myJDFDoc.getJDFRoot();
         JDFResourcePool myResPool = myRoot.getResourcePool();
         JDFResource myPreview = (JDFResource)myResPool.getElement("Preview", "", 0);
         JDFAttributeMap m = new JDFAttributeMap();

         // m.put("Side", "Front");
         m.put("PreviewType", "Separation");
         // m.put("Separation" , "Black");

         myPreview = myPreview.getDeepPart(m, EnumPartUsage.Explicit);
         VString vPartValues = myPreview.getPartValues(JDFResource.EnumPartIDKey.Separation);

         Assert.IsTrue(((string)vPartValues[0]).Equals("Cyan"));
         Assert.IsTrue(((string)vPartValues[1]).Equals("Magenta"));
         Assert.IsTrue(((string)vPartValues[2]).Equals("Yellow"));
         Assert.IsTrue(((string)vPartValues[3]).Equals("Black"));
      }

      [TestMethod]
      public virtual void testgetPartMapVector()
      {
         string strFileName = sm_dirTestData + "partitioned_private_resources.jdf";
         JDFParser p = new JDFParser();

         JDFDoc myJDFDoc = p.parseFile(strFileName);
         JDFNode myRoot = myJDFDoc.getJDFRoot();
         JDFResourcePool myResPool = myRoot.getResourcePool();
         JDFResource myPreview = (JDFResource)myResPool.getElement("Preview", "", 0);

         VJDFAttributeMap vJDFAttrMap = myPreview.getPartMapVector(false);

         // there must be 12 maps in the map vector
         Assert.IsTrue(vJDFAttrMap.Count == 12);

         for (int i = 0; i < vJDFAttrMap.Count; i++)
         {
            JDFAttributeMap myMap = vJDFAttrMap[i];

            Assert.IsTrue(myMap.ContainsKey("Side"));
            Assert.IsTrue(myMap.ContainsKey("PreviewType"));
            Assert.IsTrue(myMap.ContainsKey("SheetName"));
         }
      }


      [TestMethod]
      public virtual void testGetChildrenByTagName()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFNode root = doc.getJDFRoot();

         JDFResourcePool resPool = root.appendResourcePool();
         JDFMedia med = (JDFMedia)root.addResource("Media", EnumUsage.Input);
         JDFExposedMedia expMedia = (JDFExposedMedia)root.addResource("ExposedMedia", EnumUsage.Input);
         expMedia.refElement(med);
         VElement e = resPool.getChildrenByTagName("Media", null, null, false, true, 0);
         Assert.AreEqual(e.Count, 2);
         for (int i = 0; i < e.Count; i++)
         {
            JDFMedia m = (JDFMedia)e.item(i);
            Assert.AreEqual(med, m);
         }
      }


      [TestMethod]
      public virtual void testGetChildElement()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFNode root = doc.getJDFRoot();

         JDFResourcePool resPool = root.appendResourcePool();
         JDFColorantControl cc = (JDFColorantControl)resPool.appendElement(ElementName.COLORANTCONTROL, null);
         for (int i = 0; i < 100; i++)
         {
            cc.addPartition(EnumPartIDKey.SheetName, "Sheet" + i);
         }
         VString vs = new VString("Cyan Magenta Yello Black", null);
         cc.appendColorantOrder().setSeparations(vs);
         for (int i = 0; i < 100; i++)
         {
            JDFColorantControl cc2 = (JDFColorantControl)cc.getPartition(new JDFAttributeMap(EnumPartIDKey.SheetName, "Sheet" + i), null);
            Assert.AreEqual(vs, cc2.getColorantOrder().getSeparations());
         }
      }


      [TestMethod]
      public virtual void testGetChildElementVector()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFNode root = doc.getJDFRoot();

         JDFResourcePool resPool = root.appendResourcePool();
         JDFColorantControl colControl = (JDFColorantControl)resPool.appendElement(ElementName.COLORANTCONTROL, null);
         colControl.setProcessColorModel("DeviceCMY");
         JDFColorantControl ccPart = (JDFColorantControl)colControl.addPartition(EnumPartIDKey.Condition, "Good");
         KElement a1 = colControl.appendElement("a");
         KElement a2 = colControl.appendElement("a");
         VElement vChildren = colControl.getChildElementVector("a", null, null, true, 0, true);
         Assert.AreEqual(2, vChildren.Count);
         Assert.IsTrue(vChildren.Contains(a1));
         Assert.IsTrue(vChildren.Contains(a2));

         KElement b1 = ccPart.appendElement("b");
         KElement b2 = ccPart.appendElement("b");
         // now a leaf
         vChildren = ccPart.getChildElementVector("a", null, null, true, 0, true);
         Assert.AreEqual(2, vChildren.Count);
         Assert.IsTrue(vChildren.Contains(a1));
         Assert.IsTrue(vChildren.Contains(a2));

         vChildren = ccPart.getChildElementVector(null, null, null, true, 0, true);
         Assert.AreEqual(4, vChildren.Count);
         Assert.IsTrue(vChildren.Contains(a1));
         Assert.IsTrue(vChildren.Contains(a2));
         Assert.IsTrue(vChildren.Contains(b1));
         Assert.IsTrue(vChildren.Contains(b2));

         KElement a3 = ccPart.appendElement("a");
         // now a leaf
         vChildren = ccPart.getChildElementVector("a", null, null, true, 0, true);
         Assert.AreEqual(1, vChildren.Count);
         Assert.IsTrue(vChildren.Contains(a3));
         Assert.IsFalse(vChildren.Contains(a2));

         vChildren = ccPart.getChildElementVector(null, null, null, true, 0, true);
         Assert.AreEqual(3, vChildren.Count);
         Assert.IsTrue(vChildren.Contains(a3));
         Assert.IsFalse(vChildren.Contains(a2));
         Assert.IsTrue(vChildren.Contains(b1));
         Assert.IsTrue(vChildren.Contains(b2));
      }


      [TestMethod]
      public virtual void testGetColorPool()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFNode root = doc.getJDFRoot();

         JDFResourcePool resPool = root.appendResourcePool();
         JDFColorantControl colControl = (JDFColorantControl)resPool.appendElement(ElementName.COLORANTCONTROL, null);
         colControl.setProcessColorModel("DeviceCMY");
         colControl.appendColorantParams().appendSeparationSpec().setName("Spot");

         JDFColorSpaceConversionParams cpp = (JDFColorSpaceConversionParams)root.addResource(ElementName.COLORSPACECONVERSIONPARAMS, null, EnumUsage.Input, null, null, null, null);
         JDFColorSpaceConversionOp cso = cpp.appendColorSpaceConversionOp();
         List<ValuedEnum> sourceObjects = new List<ValuedEnum>();
         sourceObjects.Add(EnumSourceObjects.ImagePhotographic);
         sourceObjects.Add(EnumSourceObjects.LineArt);
         cso.setSourceObjects(sourceObjects);

         // getseparations
         VString vSeps = colControl.getSeparations();
         Assert.IsTrue(vSeps.Count == 4, "seps 4");
         Assert.IsTrue(vSeps.Contains("Cyan"), "seps Cyan");
         Assert.IsTrue(vSeps.Contains("Spot"), "seps Spot");
         Assert.IsTrue(!vSeps.Contains("Black"), "seps no black");

         JDFColorPool colorPool = (JDFColorPool)resPool.appendElement(ElementName.COLORPOOL, null);

         colControl.refElement(colorPool);
         // now colControl contains the ref element colPoolRef

         JDFColorPool colPool2 = colControl.getColorPool();

         // assert that we get the true color pool and not the ref element ...
         Assert.IsTrue(colorPool.Equals(colPool2));
      }

      ///   
      ///	 <summary> * tests the correct inheritence of refelements, elements and attributes
      ///	 *  </summary>
      ///	 
      [TestMethod]
      public virtual void testPartitionedAttribute()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFNode root = doc.getJDFRoot();
         root.setType(JDFNode.EnumType.ConventionalPrinting.getName(), true);
         JDFExposedMedia xm = (JDFExposedMedia)root.appendMatchingResource(ElementName.EXPOSEDMEDIA, JDFNode.EnumProcessUsage.AnyInput, null);
         xm.setResolution(new JDFXYPair(300, 300));
         xm.setPolarity(true);
         xm.setProofType(JDFExposedMedia.EnumProofType.Page);
         JDFMedia m = xm.appendMedia();
         m.setDimension(new JDFXYPair(200, 300));
         JDFExposedMedia xm2 = (JDFExposedMedia)xm.addPartition(EnumPartIDKey.SheetName, "S1");
         Assert.IsTrue(xm2.getMedia().getDimension().X == 200.0, "Media inline Dimension");
         Assert.IsTrue(xm.getResolution().X == 300.0, "ExposedMedia direct Resolution");
         Assert.IsTrue(xm2.getResolution().X == 300.0, "ExposedMedia inherited Resolution");
         m = (JDFMedia)m.makeRootResource(null, null, true);
         Assert.IsTrue(xm2.getMedia().getDimension().X == 200.0, "Media referenced Dimension");
         JDFRefElement re = (JDFRefElement)xm2.getElement("MediaRef");
         Assert.IsTrue(re != null, "refElement found");

         if (re != null)
         {
            JDFMedia m2 = (JDFMedia)re.getTarget();
            Assert.AreEqual(m2, m, "ref target");
         }
         Assert.IsTrue(xm2.hasChildElement("Media", null), "has Media");
         Assert.IsTrue(xm2.getPolarity(), "polarity true");
         xm2.setPolarity(false);
         Assert.IsFalse(xm2.getPolarity(), "polarity false");

         Assert.AreEqual(JDFExposedMedia.EnumProofType.Page, xm2.getProofType(), "prooftype");
      }

      ///   
      ///	 <summary> * tests the correct inheritence of refelements, elements and attributes
      ///	 *  </summary>
      ///	 
      [TestMethod]
      public virtual void testpartitionedElement()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFNode root = doc.getJDFRoot();
         root.setType(JDFNode.EnumType.ConventionalPrinting.getName(), true);
         JDFColorantControl cc = (JDFColorantControl)root.appendMatchingResource(ElementName.COLORANTCONTROL, JDFNode.EnumProcessUsage.AnyInput, null);
         cc.setPartUsage(EnumPartUsage.Implicit);
         ArrayList seps = StringUtil.tokenize("Cyan Magenta Yellow Black", " ", false);
         cc.appendColorantOrder().setSeparations(new VString(seps));
         JDFColorantControl cc2 = (JDFColorantControl)cc.addPartition(EnumPartIDKey.SheetName, "S1");
         seps.Add("smurf blue");
         cc2.appendColorantOrder().setSeparations(new VString(seps));
         JDFColorantControl select = (JDFColorantControl)cc.getPartition(new JDFAttributeMap(EnumPartIDKey.SheetName.getName(), "s0"), null);
         Assert.AreEqual(select, cc);
         select = (JDFColorantControl)cc.getPartition(new JDFAttributeMap(EnumPartIDKey.SheetName.getName(), "S1"), null);
         Assert.AreEqual(select, cc2);
         seps.Add("dragon red");
         cc.appendDeviceColorantOrder().setSeparations(new VString(seps));
         Assert.IsTrue(select.getColorantOrder().getSeparations().Contains("smurf blue"));
         Assert.IsTrue(select.getDeviceColorantOrder().getSeparations().Contains("dragon red"));
      }

      ///   
      ///	 <summary> * tests updateAmounts()
      ///	 *  </summary>
      ///	 
      [TestMethod]
      public virtual void testUpdateAmounts()
      {
         for (int i = 0; i < 2; i++)
         {
            JDFDoc doc = new JDFDoc(ElementName.JDF);
            JDFNode root = doc.getJDFRoot();
            if (i == 0)
               root.setType(JDFNode.EnumType.ConventionalPrinting.getName(), true);
            else
               root.setType("fooBar", false); // check whether this works with
            // non-enum types

            JDFMedia media = (JDFMedia)root.addResource(ElementName.MEDIA, null, EnumUsage.Input, null, null, null, null);
            media.setAmount(100);
            JDFComponent comp = (JDFComponent)root.addResource(ElementName.COMPONENT, null, EnumUsage.Output, null, null, null, null);
            JDFResourceLink rlMedia = root.getLink(media, null);
            JDFResourceLink rlComp = root.getLink(comp, null);
            JDFComponent c1 = (JDFComponent)comp.addPartition(EnumPartIDKey.SheetName, "S1");

            JDFAttributeMap m1 = new JDFAttributeMap(EnumPartIDKey.SheetName, "S1");
            rlComp.setActualAmount(42, m1);
            comp.updateAmounts(10);
            Assert.AreEqual(42.0, c1.getAmount(), 0.1);
            Assert.AreEqual(42.0, c1.getAmountProduced(), 0.1);
            rlMedia.setActualAmount(21, m1);
            media.updateAmounts(0);
            Assert.AreEqual(100 - 21, media.getAmount(), 0.1, "amount=100, - the 21 actual");
            Assert.AreEqual(100.0, media.getAmountRequired(), 0.1);

            rlComp.removeChild(ElementName.AMOUNTPOOL, null, 0);
            m1.put(EnumPartIDKey.Condition, "Good");
            comp.removeAttribute(AttributeName.AMOUNTPRODUCED);
            rlComp.setActualAmount(42, m1);

            m1.put(EnumPartIDKey.Condition, "Waste");
            rlComp.setActualAmount(10, m1);

            m1.put(EnumPartIDKey.Condition, "OtherWaste");
            rlComp.setActualAmount(20, m1);

            comp.updateAmounts(0);
            Assert.AreEqual(42.0, c1.getAmountProduced(), 0.1, "Anything but Condition=Good is ifnored");
         }
      }


      [TestMethod]
      public virtual void testCreatePartitions()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFElement root = doc.getJDFRoot();
         JDFResourcePool resPool = (JDFResourcePool)root.appendElement(ElementName.RESOURCEPOOL, null);
         JDFResource resPreview = resPool.appendResource("Preview", null, null);
         JDFAttributeMap partMap = new JDFAttributeMap();
         partMap.put(EnumPartIDKey.SignatureName, "Sig1");
         partMap.put(EnumPartIDKey.SheetName, "Sheet1");
         partMap.put(EnumPartIDKey.PartVersion, "De");
         JDFAttributeMap partMap2 = new JDFAttributeMap(partMap);
         partMap2.put(EnumPartIDKey.PartVersion, "En");
         VJDFAttributeMap v = new VJDFAttributeMap();
         v.Add(partMap);
         v.Add(partMap2);
         VString vs = new VString("SignatureName SheetName PartVersion", " ");
         VString vs2 = new VString("PartVersion SignatureName SheetName", " ");

         VElement parts = resPreview.createPartitions(v, vs);
         Assert.AreEqual(parts.Count, 2);

         VElement parts2 = resPreview.createPartitions(v, vs2);
         Assert.AreEqual(parts, parts2);

         // next test
         resPreview.deleteNode();
         resPreview = resPool.appendResource("Preview", null, null);

         vs = new VString("SignatureName SheetName", " ");
         VJDFAttributeMap vShort = new VJDFAttributeMap();

         JDFAttributeMap partMapShort = new JDFAttributeMap();
         partMapShort.put(EnumPartIDKey.SignatureName, "Sig1");
         partMapShort.put(EnumPartIDKey.SheetName, "Sheet1");
         vShort.Add(partMapShort);

         parts = resPreview.createPartitions(vShort, vs);
         Assert.AreEqual(1, parts.Count);

         parts2 = resPreview.createPartitions(v, vs2);
         Assert.AreEqual(2, parts2.Count, "add partVersion at end anyhow");
      }


      [TestMethod]
      public virtual void testGetCreatePartition()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFElement root = doc.getJDFRoot();
         JDFResourcePool resPool = (JDFResourcePool)root.appendElement(ElementName.RESOURCEPOOL, null);
         JDFResource resPreview = resPool.appendResource("Preview", JDFResource.EnumResourceClass.Parameter, JDFConstants.EMPTYSTRING);
         JDFAttributeMap partMap = new JDFAttributeMap();

         // create 2 PreviewType Partition
         partMap.put("PreviewType", "ThumbNail");
         JDFResource resPreviewType = resPreview.getCreatePartition(partMap, null);
         partMap.Clear();
         partMap.put("PreviewType", "Viewable");
         resPreview.getCreatePartition(partMap, null);

         // create a partition with same name under the existing one (MUST FAIL)
         try
         {
            partMap.Clear();
            partMap.put("PreviewType", "SeparatedThumbNail");
            resPreviewType.getCreatePartition(partMap, null);
            Assert.Fail("create a partition with same name");
         }
         catch (JDFException)
         {
            // do nothing
         }

         // try to create the partition directly
         // because we create a "SheetName" partition under the
         // "PreviewType="Thumbnail"
         // we dont need to add PreviewType to the partmap
         partMap.Clear();
         partMap.put("SheetName", "Cover");
         resPreviewType.getCreatePartition(partMap, null);

         // create subpartition under Preview Viewable
         partMap.Clear();
         partMap.put("PreviewType", "Viewable");
         partMap.put("SheetName", "Cover");
         resPreview.getCreatePartition(partMap, null);

         // create two new partitions in one (MUST FAIL)
         try
         {
            partMap.Clear();
            partMap.put("PreviewType", "Viewable");
            partMap.put("SheetName", "Cover");
            partMap.put("Side", "Front");
            partMap.put("WebName", "0001");
            resPreview.getCreatePartition(partMap, null);
            // failed
            Assert.IsTrue(false);
         }
         catch (JDFException)
         {
            // do nothing
         }

         // same as above but this we use the second parameter to create a
         // structure of partitions
         VString @struct = new VString();
         @struct.Add("PreviewType");
         @struct.Add("SheetName");
         @struct.Add("Side");
         @struct.Add("WebName");

         partMap.Clear();
         partMap.put("PreviewType", "Viewable");
         partMap.put("SheetName", "Cover");
         partMap.put("Side", "Front");
         partMap.put("WebName", "0001");
         JDFResource resWebName = resPreview.getCreatePartition(partMap, @struct);

         // create a partition while inside a partition
         partMap.Clear();
         partMap.put("PreviewType", "Viewable");
         partMap.put("SheetName", "Cover");
         partMap.put("Side", "Front");
         partMap.put("WebName", "0001");
         partMap.put("DocRunIndex", "0001");

         resWebName.getCreatePartition(partMap, null);

         // Nächster Test
         partMap.Clear();
         partMap.put("PreviewType", "Viewable");
         partMap.put("SheetName", "Cover");
         partMap.put("Side", "Front");
         partMap.put("WebName", "0001");
         partMap.put("DocRunIndex", "0001");

         @struct = new VString();
         @struct.Add("PreviewType");
         @struct.Add("SheetName");
         @struct.Add("Side");
         @struct.Add("WebName");
         @struct.Add("DocRunIndex");

         resWebName.getCreatePartition(partMap, @struct);

         // Nächster Test
         partMap.Clear();
         partMap.put("PreviewType", "Viewable");
         partMap.put("SheetName", "Cover");
         partMap.put("Side", "Front");
         partMap.put("WebName", "0001");
         partMap.put("DocRunIndex", "0001");
         partMap.put("CellIndex", "0002");

         @struct = new VString();
         @struct.Add("PreviewType");
         @struct.Add("SheetName");
         @struct.Add("Side");
         @struct.Add("WebName");
         @struct.Add("DocRunIndex");
         @struct.Add("CellIndex");

         resPreview.getCreatePartition(partMap, @struct);

         // create a partition while inside a partition
         partMap.Clear();
         partMap.put("PreviewType", "Viewable");
         partMap.put("SheetName", "Cover");
         partMap.put("Side", "Front");
         partMap.put("WebName", "0001");
         partMap.put("DocRunIndex", "0001");
         partMap.put("CellIndex", "0002");

         JDFResource resCellIndex = resPreview.getCreatePartition(partMap, null);

         partMap.Clear();
         partMap.put("PreviewType", "Viewable");
         partMap.put("SheetName", "Cover");
         partMap.put("Side", "Front");
         partMap.put("WebName", "0001");
         partMap.put("DocRunIndex", "0001");
         partMap.put("CellIndex", "0002");
         partMap.put("PartVersion", "003");

         resCellIndex.getCreatePartition(partMap, null);

         // nächster Test
         JDFResource r = (JDFResource)resPool.getChildByTagName("Preview", null, 0, null, true, true);
         JDFAttributeMap map = new JDFAttributeMap();
         map.put("PreviewType", "Viewable");
         map.put("SheetName", "Cover");

         JDFResource part1 = r.getPartition(map, EnumPartUsage.Explicit);
         JDFResource part2 = r.getCreatePartition(map, null);
         Assert.IsTrue(part1.Equals(part2), "part1 and part2 must be equal");

         map.put("Side", "Front");
         JDFResource part11 = part1.getPartition(map, EnumPartUsage.Explicit);
         JDFResource part12 = part1.getCreatePartition(map, null);

         Assert.IsTrue(part11.Equals(part12), "part11 and part12 must be equal");

         doc.write2File(sm_dirTestDataTemp + "testGetCreatePartition.jdf", 0, true);
      }


      [TestMethod]
      public virtual void testIdentical()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode n = doc.getJDFRoot();
         n.setType("Product", true);

         JDFComponent c = (JDFComponent)n.appendMatchingResource("Component", JDFNode.EnumProcessUsage.AnyOutput, null);
         JDFResourceLink l = n.getMatchingLink("Component", JDFNode.EnumProcessUsage.AnyOutput, 0);
         Assert.IsTrue(l != null, "link exists");
         JDFAttributeMap mPart1 = new JDFAttributeMap("SheetName", "S1");
         mPart1.put("Separation", "Yellow");
         JDFAttributeMap mPart3 = new JDFAttributeMap("SheetName", "S3");
         mPart3.put("Separation", "Yellow");

         JDFMedia med = (JDFMedia)n.addResource("Media", null, EnumUsage.Input, null, null, null, null);
         JDFExposedMedia xmed = (JDFExposedMedia)n.addResource("ExposedMedia", null, EnumUsage.Input, null, null, null, null);
         xmed.refElement(med);

         JDFComponent c1 = (JDFComponent)c.addPartition(JDFResource.EnumPartIDKey.SheetName, "S1");
         c1.addPartition(JDFResource.EnumPartIDKey.Separation, "Cyan");
         JDFComponent c1y = (JDFComponent)c1.addPartition(JDFResource.EnumPartIDKey.Separation, "Yellow");
         c1.addPartition(JDFResource.EnumPartIDKey.Separation, "Magenta");

         JDFComponent c2 = (JDFComponent)c.addPartition(JDFResource.EnumPartIDKey.SheetName, "S2");
         Assert.AreEqual("S2", c2.getSheetName(), "part ok");
         JDFComponent c3 = (JDFComponent)c.addPartition(JDFResource.EnumPartIDKey.SheetName, "S3");
         c3.setAmount(42);
         JDFAttributeMap map = c3.getPartMap();
         c3.setIdentical(c1);
         Assert.AreEqual(map, c3.getPartMap());
         Assert.IsNotNull(c3.getIdenticalMap());
         Assert.AreEqual(c3.getIdenticalMap(), c1.getPartMap());

         c3.removeChild(ElementName.IDENTICAL, null, 0);
         Assert.IsNull(c3.getIdenticalMap());
         VJDFAttributeMap vMap = new VJDFAttributeMap();
         vMap.Add(c1.getPartMap());
         vMap.Add(c3.getPartMap());
         c.setIdentical(vMap);
         Assert.AreEqual(map, c3.getPartMap());
         Assert.IsNotNull(c3.getIdenticalMap());
         Assert.AreEqual(c3.getIdenticalMap(), c1.getPartMap());

         JDFComponent c3y = (JDFComponent)c.getPartition(mPart3, null);
         Assert.AreEqual(c1y, c3y, "identical");
         c1y = (JDFComponent)c.getPartition(mPart1, null);
         Assert.AreEqual(c1y, c3y, "identical 2");
         try
         {
            c.setIdentical(c2);
            Assert.Fail("root set identical");
         }
         catch (JDFException)
         {
            //
         }
         doc.write2File(sm_dirTestDataTemp + "identical.jdf", 2, false);
      }


      [TestMethod]
      public virtual void testIdenticalValid()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode n = doc.getJDFRoot();
         n.setType("Product", true);

         JDFComponent c = (JDFComponent)n.appendMatchingResource("Component", JDFNode.EnumProcessUsage.AnyOutput, null);
         JDFResourceLink l = n.getMatchingLink("Component", JDFNode.EnumProcessUsage.AnyOutput, 0);
         Assert.IsTrue(l != null, "link exists");
         JDFAttributeMap mPart1 = new JDFAttributeMap("SheetName", "S1");
         mPart1.put("Separation", "Yellow");
         JDFAttributeMap mPart3 = new JDFAttributeMap("SheetName", "S3");
         mPart3.put("Separation", "Yellow");

         JDFMedia med = (JDFMedia)n.addResource("Media", null, EnumUsage.Input, null, null, null, null);
         JDFExposedMedia xmed = (JDFExposedMedia)n.addResource("ExposedMedia", null, EnumUsage.Input, null, null, null, null);
         xmed.refElement(med);

         JDFComponent c1 = (JDFComponent)c.addPartition(JDFResource.EnumPartIDKey.SheetName, "S1");
         c1.addPartition(JDFResource.EnumPartIDKey.Separation, "Cyan");
         c1.addPartition(JDFResource.EnumPartIDKey.Separation, "Yellow");
         c1.addPartition(JDFResource.EnumPartIDKey.Separation, "Magenta");

         JDFComponent c2 = (JDFComponent)c.addPartition(JDFResource.EnumPartIDKey.SheetName, "S2");
         Assert.AreEqual("S2", c2.getSheetName(), "part ok");
         JDFComponent c3 = (JDFComponent)c.addPartition(JDFResource.EnumPartIDKey.SheetName, "S3");
         c3.setIdentical(c1);
         Assert.IsTrue(c3.isValid(EnumValidationLevel.Incomplete));
      }


      ///   
      ///	 <summary> * test whether getpartition works for when inconsistently called </summary>
      ///	 
      [TestMethod]
      public virtual void testGetPartition()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode n = doc.getJDFRoot();
         n.setType(EnumType.Folding);
         JDFFoldingParams fp = (JDFFoldingParams)n.addResource(ElementName.FOLDINGPARAMS, null, EnumUsage.Input, null, null, null, null);
         JDFAttributeMap m = new JDFAttributeMap("SignatureName", "Sig1");
         m.put("SheetName", "Sheet1");
         JDFResource rSheet = fp.getCreatePartition(m, new VString("SignatureName SheetName", " "));
         m.put("BlockName", "Block1");
         JDFResource r = fp.getCreatePartition(m, new VString("SignatureName SheetName BlockName", " "));
         JDFAttributeMap m2 = new JDFAttributeMap("SignatureName", "Sig1");
         m2.put("SheetName", "Sheet1");
         m2.put("Side", "Front");
         r = fp.getPartition(m2, EnumPartUsage.Implicit);
         Assert.AreEqual(r, rSheet);
         r = fp.getPartition(m2, EnumPartUsage.Explicit);
         Assert.IsNull(r);
      }


      ///   
      ///	 <summary> * test whether getpartition works for lists and ranges </summary>
      ///	 
      [TestMethod]
      public virtual void testGetPartsPartition()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode n = doc.getJDFRoot();
         n.setType(EnumType.ConventionalPrinting);
         JDFExposedMedia xm = (JDFExposedMedia)n.appendMatchingResource(ElementName.EXPOSEDMEDIA, EnumProcessUsage.AnyInput, null);
         JDFExposedMedia xmp = (JDFExposedMedia)xm.addPartition(EnumPartIDKey.PartVersion, "DE FR");
         JDFMedia m = (JDFMedia)n.appendMatchingResource(ElementName.MEDIA, EnumProcessUsage.AnyInput, null);
         JDFMedia mp = (JDFMedia)m.addPartition(EnumPartIDKey.SheetIndex, "1 ~ 3");

         // tests for partition list
         // DE from DE FR
         Assert.AreEqual(xmp, xm.getPartition(new JDFAttributeMap(EnumPartIDKey.PartVersion.getName(), "DE FR"), null));
         Assert.IsNull(xm.getPartition(new JDFAttributeMap(EnumPartIDKey.PartVersion.getName(), "GR"), null));

         // get 2 from 1~3
         Assert.AreEqual(mp, m.getPartition(new JDFAttributeMap(EnumPartIDKey.SheetIndex.getName(), "2"), null));
         Assert.IsNull(m.getPartition(new JDFAttributeMap(EnumPartIDKey.SheetIndex.getName(), "42"), null));
      }


      [TestMethod]
      public virtual void testGetPartitionVector()
      {
         JDFDoc doc = creatXMDoc();
         JDFNode n = doc.getJDFRoot();
         JDFExposedMedia xm = (JDFExposedMedia)n.getMatchingResource("ExposedMedia", JDFNode.EnumProcessUsage.AnyInput, null, 0);
         xm.setPartUsage(EnumPartUsage.Implicit);
         JDFAttributeMap m = new JDFAttributeMap("SignatureName", "Sig1");
         m.put("RunIndex", "3");
         VElement v = xm.getPartitionVector(m, null);
         JDFResource r = xm.getPartition(m, null);
         Assert.AreEqual(xm.getPartition(new JDFAttributeMap("SignatureName", "Sig1"), null), r, "same as only sig1");
         int i = 0;
         Assert.IsTrue(v.Count == 4, "implicit 4");
         for (i = 0; i < v.Count; i++)
         {
            JDFExposedMedia xmp = (JDFExposedMedia)v[i];
            Assert.IsTrue(m.overlapMap(xmp.getPartMap()), "overlap of maps");
         }
         v = xm.getPartitionVector(m, EnumPartUsage.Sparse);
         for (i = 0; i < v.Count; i++)
         {
            JDFExposedMedia xmp = (JDFExposedMedia)v[i];
            Assert.IsTrue(m.overlapMap(xmp.getPartMap()), "overlap of maps");
         }
         Assert.IsTrue(v.Count == 4, "sparse 4");

         v = xm.getPartitionVector(m, EnumPartUsage.Explicit);
         Assert.IsTrue(v.Count == 0, "no explicit");

         m.Clear();
         m.put("SignatureName", "Sig1");
         m.put("SheetName", "S3");
         v = xm.getPartitionVector(m, EnumPartUsage.Explicit);
         Assert.IsTrue(v.Count == 0, "no explicit");
         v = xm.getPartitionVector(m, EnumPartUsage.Sparse);
         Assert.IsTrue(v.Count == 0, "no sparse");
         v = xm.getPartitionVector(m, EnumPartUsage.Implicit);
         Assert.IsTrue(v.Count == 1, "1 impl");
         for (i = 0; i < v.Count; i++)
         {
            JDFExposedMedia xmp = (JDFExposedMedia)v[i];
            Assert.IsTrue(m.overlapMap(xmp.getPartMap()), "overlap of maps");
         }

         m.Clear();
         m.put("SignatureName", "Sig1");
         m.put("Side", "Front");

         v = xm.getPartitionVector(m, EnumPartUsage.Explicit);
         Assert.IsTrue(v.Count == 2, "explicit key missing");
         v = xm.getPartitionVector(m, EnumPartUsage.Sparse);
         Assert.IsTrue(v.Count == 2, "no sparse");
         v = xm.getPartitionVector(m, EnumPartUsage.Implicit);
         Assert.IsTrue(v.Count == 2, "1 impl");
         for (i = 0; i < v.Count; i++)
         {
            JDFExposedMedia xmp = (JDFExposedMedia)v[i];
            Assert.IsTrue(m.overlapMap(xmp.getPartMap()), "overlap of maps");
         }
      }


      [TestMethod]
      public virtual void testDeleteUnlinked()
      {
         JDFDoc doc = creatXMDoc();
         JDFNode n = doc.getJDFRoot();
         JDFExposedMedia xm = (JDFExposedMedia)n.getMatchingResource("ExposedMedia", JDFNode.EnumProcessUsage.AnyInput, null, 0);
         JDFMedia m = xm.getMedia();
         m = (JDFMedia)m.makeRootResource(null, null, true);
         JDFResourceLink rl = n.linkResource(m, EnumUsage.Input, null);
         Assert.IsFalse(m.deleteUnLinked());
         xm.getElement_KElement("MediaRef", null, 0).deleteNode();
         Assert.IsFalse(m.deleteUnLinked());
         xm.refElement(m);
         rl.deleteNode();
         Assert.IsFalse(m.deleteUnLinked());
         n.removeResource(ElementName.EXPOSEDMEDIA, 0);
         Assert.IsNull(m.ParentNode);
      }


      [TestMethod]
      public virtual void testGetLinks()
      {
         JDFDoc doc = creatXMDoc();
         JDFNode n = doc.getJDFRoot();
         JDFExposedMedia xm = (JDFExposedMedia)n.getMatchingResource("ExposedMedia", JDFNode.EnumProcessUsage.AnyInput, null, 0);
         JDFMedia m = xm.getMedia();
         m = (JDFMedia)m.makeRootResource(null, null, true);
         VElement v = m.getLinks(null, null);
         Assert.AreEqual(1, v.Count);
         // Java to C# Conversion - Unreachable code here
         //JDFResourceLink rl = n.linkResource(m, true ? EnumUsage.Input : EnumUsage.Output, null);
         JDFResourceLink rl = n.linkResource(m, EnumUsage.Input, null);
         v = m.getLinks(null, null);
         Assert.AreEqual(2, v.Count);
         Assert.IsTrue(v.Contains(rl));
      }


      [TestMethod]
      public virtual void testGetLinksAndRefs()
      {
         JDFDoc doc = creatXMDoc();
         JDFNode n = doc.getJDFRoot();
         JDFExposedMedia xm = (JDFExposedMedia)n.getMatchingResource("ExposedMedia", JDFNode.EnumProcessUsage.AnyInput, null, 0);
         JDFMedia m = xm.getMedia();
         m = (JDFMedia)m.makeRootResource(null, null, true);
         VElement v = m.getLinksAndRefs(false, true);
         Assert.AreEqual(1, v.Count);
         JDFResourceLink rl = n.linkResource(m, EnumUsage.Input, null);
         v = m.getLinksAndRefs(false, true);
         Assert.AreEqual(1, v.Count);
         v = m.getLinksAndRefs(true, false);
         Assert.AreEqual(1, v.Count);
         Assert.IsTrue(v.Contains(rl));

         v = m.getLinksAndRefs(true, true);
         Assert.AreEqual(2, v.Count);
         Assert.IsTrue(v.Contains(rl));

         JDFMedia mPart = (JDFMedia)m.addPartition(EnumPartIDKey.SignatureName, "Sig1");
         v = mPart.getLinksAndRefs(true, true);
         Assert.AreEqual(2, v.Count, "partitioned resource has no links");
         JDFAttributeMap myMap = new JDFAttributeMap();
         myMap.put("SignatureName", "Sig2");
         rl.setPartMap(myMap);

         xm.getElement_KElement("MediaRef", null, 0).deleteNode();

         v = mPart.getLinksAndRefs(true, true);
         Assert.IsNull(v, "partitioned resource has no links");

         myMap.put("SignatureName", "Sig1");
         rl.setPartMap(myMap);
         v = mPart.getLinksAndRefs(true, true);
         Assert.AreEqual(1, v.Count, "partitioned resource has one link");
      }


      [TestMethod]
      public virtual void testGetLocalPartitionKey()
      {
         JDFDoc doc = creatXMDoc();
         JDFNode n = doc.getJDFRoot();
         JDFExposedMedia xm = (JDFExposedMedia)n.getMatchingResource("ExposedMedia", JDFNode.EnumProcessUsage.AnyInput, null, 0);
         JDFExposedMedia xmLeaf = (JDFExposedMedia)xm.getLeaves(false)[1];
         Assert.AreEqual("Side", xmLeaf.getLocalPartitionKey());
         xmLeaf = (JDFExposedMedia)xmLeaf.getParentNode_KElement();
         Assert.AreEqual("SheetName", xmLeaf.getLocalPartitionKey());
         xmLeaf = (JDFExposedMedia)xmLeaf.getParentNode_KElement();
         Assert.AreEqual("SignatureName", xmLeaf.getLocalPartitionKey());
         xmLeaf = (JDFExposedMedia)xmLeaf.getParentNode_KElement();
         Assert.IsNull(xmLeaf.getLocalPartitionKey());
      }


      [TestMethod]
      public virtual void testBuildXPath()
      {
         JDFDoc doc = creatXMDoc();
         JDFNode n = doc.getJDFRoot();
         JDFExposedMedia xm = (JDFExposedMedia)n.getMatchingResource("ExposedMedia", JDFNode.EnumProcessUsage.AnyInput, null, 0);
         JDFExposedMedia xmLeaf = (JDFExposedMedia)xm.getLeaves(false)[1];
         Assert.AreEqual("/JDF/ResourcePool[1]/ExposedMedia[1]/ExposedMedia[@SignatureName=\"Sig1\"]/ExposedMedia[@SheetName=\"S1\"]/ExposedMedia[@Side=\"Back\"]", xmLeaf.buildXPath(null, 2));
      }


      [TestMethod]
      public virtual void testBinderySignatureName()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode n = doc.getJDFRoot();
         JDFBinderySignature bs = (JDFBinderySignature)n.addResource(ElementName.BINDERYSIGNATURE, EnumUsage.Input);
         JDFBinderySignature bsp = (JDFBinderySignature)bs.addPartition(EnumPartIDKey.BinderySignatureName, "bad name");
         Assert.IsFalse(bsp.isValid(EnumValidationLevel.Incomplete), "Bad BS partidkey value - should be nmtoken");
      }


      [TestMethod]
      public virtual void testInvalidPartIDKeysLeaves()
      {
         JDFDoc doc = creatXMDoc();
         JDFNode n = doc.getJDFRoot();
         JDFExposedMedia xm = (JDFExposedMedia)n.getMatchingResource("ExposedMedia", JDFNode.EnumProcessUsage.AnyInput, null, 0);
         xm.setPartIDKeys(new VString("fnarf", " "));
         Assert.IsTrue(xm.getInvalidAttributes(EnumValidationLevel.Incomplete, true, -1).Contains(AttributeName.PARTIDKEYS));
      }


      [TestMethod]
      public virtual void testExplicitPartUsage()
      {
         JDFNode n = new JDFDoc("JDF").getJDFRoot();
         n.setType(EnumType.ProcessGroup);
         JDFResource pv = n.addResource("Preview", EnumUsage.Input);
         pv.setPartUsage(EnumPartUsage.Explicit);
         JDFResource pv1 = pv.addPartition(EnumPartIDKey.Separation, "Cyan");
         pv.setResStatus(EnumResStatus.Unavailable, false);
         Assert.IsFalse(pv.isValid(EnumValidationLevel.Complete));
         Assert.IsFalse(pv1.isValid(EnumValidationLevel.Complete));
         pv1.setResStatus(EnumResStatus.Incomplete, false);
         Assert.IsTrue(pv.isValid(EnumValidationLevel.Complete));
         Assert.IsTrue(pv1.isValid(EnumValidationLevel.Complete));
         JDFResource pv2 = pv.addPartition(EnumPartIDKey.Separation, "Blue");
         Assert.IsFalse(pv.isValid(EnumValidationLevel.Complete));
         Assert.IsFalse(pv2.isValid(EnumValidationLevel.Complete));
         Assert.IsTrue(pv1.isValid(EnumValidationLevel.Complete));
      }


      [TestMethod]
      public virtual void testInvalidPartUsage()
      {
         JDFDoc doc = creatXMDoc();
         JDFNode n = doc.getJDFRoot();
         JDFExposedMedia xm = (JDFExposedMedia)n.getMatchingResource("ExposedMedia", JDFNode.EnumProcessUsage.AnyInput, null, 0);
         xm.setPartUsage(EnumPartUsage.Sparse);
         Assert.IsFalse(xm.getInvalidAttributes(EnumValidationLevel.Incomplete, true, 999).Contains("PartUsage"));
         n.setVersion(EnumVersion.Version_1_1);
         Assert.IsTrue(xm.getInvalidAttributes(EnumValidationLevel.Incomplete, true, 999).Contains("PartUsage"));
         n.setVersion(EnumVersion.Version_1_2);
         Assert.IsTrue(xm.getInvalidAttributes(EnumValidationLevel.Incomplete, true, 999).Contains("PartUsage"));
         Assert.IsFalse(xm.getInvalidAttributes(EnumValidationLevel.NoWarnIncomplete, true, 999).Contains("PartUsage"));
      }


      [TestMethod]
      public virtual void testGetLeaves()
      {
         JDFDoc doc = creatXMDoc();
         JDFNode n = doc.getJDFRoot();
         JDFExposedMedia xm = (JDFExposedMedia)n.getMatchingResource("ExposedMedia", JDFNode.EnumProcessUsage.AnyInput, null, 0);

         VElement vL = xm.getLeaves(false);
         Assert.AreEqual(8, vL.Count, "size false");
         for (int i = 0; i < vL.Count; i++)
         {
            JDFExposedMedia xm2 = (JDFExposedMedia)vL[i];
            Assert.AreEqual(3, xm2.getPartMap().Count, "map ok");
         }

         vL = xm.getLeaves(true);
         Assert.AreEqual(15, vL.Count, "size false");
      }


      [TestMethod]
      public virtual void testGetMinStatusFromLeaves()
      {
         JDFDoc doc = creatXMDoc();
         JDFNode n = doc.getJDFRoot();
         JDFExposedMedia xm = (JDFExposedMedia)n.getMatchingResource("ExposedMedia", JDFNode.EnumProcessUsage.AnyInput, null, 0);

         xm.setResStatus(EnumResStatus.Incomplete, true);
         Assert.AreEqual(EnumResStatus.Incomplete, xm.getStatusFromLeaves(false));
         Assert.AreEqual(EnumResStatus.Incomplete, xm.getStatusFromLeaves(true));

         xm.setResStatus(EnumResStatus.Available, true);
         Assert.AreEqual(EnumResStatus.Available, xm.getStatusFromLeaves(false));
         Assert.AreEqual(EnumResStatus.Available, xm.getStatusFromLeaves(true));

         xm.setResStatus(EnumResStatus.Incomplete, true);

         VElement vL = xm.getLeaves(false);
         for (int i = 0; i < vL.Count; i++)
         {
            JDFResource r = (JDFResource)vL[i];
            r.setResStatus(EnumResStatus.InUse, false);
         }
         Assert.AreEqual(EnumResStatus.InUse, xm.getStatusFromLeaves(false));
         Assert.AreEqual(EnumResStatus.Incomplete, xm.getStatusFromLeaves(true));
      }


      public static JDFDoc creatRLDoc()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode n = doc.getJDFRoot();
         n.setJobPartID("P1");
         n.setJobID("J1");
         n.setType("Interpreting", true);

         JDFRunList rl = (JDFRunList)n.appendMatchingResource("RunList", JDFNode.EnumProcessUsage.AnyInput, null);
         for (int i = 1; i < 3; i++)
         {
            JDFRunList rlset = (JDFRunList)rl.addPartition(EnumPartIDKey.RunSet, "Set" + Convert.ToString(i));
            ArrayList filNames = StringUtil.tokenize("FCyan.pdf FMagenta.pdf FYellow.pdf FBlack.pdf", " ", false);
            ArrayList sepNames = StringUtil.tokenize("Cyan Magenta Yellow Black", " ", false);
            JDFRunList rlRun = rlset.addSepRun(filNames, sepNames, 0, 16, false);
            rlRun.setRun("Run" + Convert.ToString(i));
            rlRun.setSorted(true);
            rlRun.appendElement("foo:bar", "www.foobar.com");
         }

         return doc;
      }


      [TestMethod]
      public virtual void testSubElement()
      {
         JDFDoc doc = creatXMDoc();
         JDFNode n = doc.getJDFRoot();
         JDFExposedMedia xm = (JDFExposedMedia)n.getMatchingResource("ExposedMedia", JDFNode.EnumProcessUsage.AnyInput, null, 0);
         JDFMedia m = xm.getMedia();
         Assert.AreEqual(EnumResourceClass.Consumable, m.getResourceClass(), "Media in XM class");
         m.setBrand("fooBrand");
         Assert.IsTrue(xm.isValid(EnumValidationLevel.Complete), "xm valid");
         Assert.IsTrue(m.isValid(EnumValidationLevel.Complete), "m valid");
         m.deleteNode();
         m = xm.appendMedia();
         m.setBrand("barBrand");
         Assert.IsTrue(xm.isValid(EnumValidationLevel.Complete), "xm valid");
         Assert.IsTrue(m.isValid(EnumValidationLevel.Complete), "m valid");
      }


      [TestMethod]
      public virtual void testSetAttributes()
      {
         JDFDoc d = new JDFDoc(ElementName.JDF);
         JDFNode n = d.getJDFRoot();
         JDFResource r1 = n.addResource(ElementName.SPINETAPINGPARAMS, EnumUsage.Input);
         JDFResource r2 = n.addResource(ElementName.SPINETAPINGPARAMS, EnumUsage.Input);
         JDFResource r1p = r1.addPartition(EnumPartIDKey.SheetName, "s1").addPartition(EnumPartIDKey.Side, EnumSide.Front);
         r1p.setAgentName("a1");
         r1.setAgentVersion("v1");
         JDFResource r2p = r2.addPartition(EnumPartIDKey.SheetName, "s2").addPartition(EnumPartIDKey.Side, EnumSide.Back);
         r2p.setAttributes(r1p);
         Assert.AreEqual("a1", r2p.getAgentName(), "child copied");
         Assert.AreEqual("v1", r2p.getAgentVersion(), "root copied");
         Assert.AreEqual("s2", r2p.getSheetName(), "parent partIDKey not copied");
         Assert.AreEqual(EnumSide.Front, r2p.getSide(), "leaf partIDKey copied");
      }


      [TestMethod]
      public virtual void testSetLocked()
      {
         JDFDoc doc = creatXMDoc();
         JDFNode n = doc.getJDFRoot();
         JDFExposedMedia xm = (JDFExposedMedia)n.getMatchingResource("ExposedMedia", JDFNode.EnumProcessUsage.AnyInput, null, 0);
         xm.setLocked(false);
         Assert.IsFalse(xm.getLocked());
         Assert.IsFalse(xm.hasAttribute(AttributeName.LOCKED));
         VElement vL = xm.getLeaves(false);
         for (int i = 0; i < 1; i++)
         {
            xm.setLocked(false);
            JDFExposedMedia xm3 = (JDFExposedMedia)vL[i];
            JDFExposedMedia xm2 = (JDFExposedMedia)xm3.ParentNode;
            Assert.IsFalse(xm2.getLocked());
            Assert.IsFalse(xm3.getLocked());
            Assert.IsFalse(xm2.hasAttribute(AttributeName.LOCKED));
            Assert.IsFalse(xm3.hasAttribute(AttributeName.LOCKED));
            xm.setLocked(true);
            Assert.IsTrue(xm.getLocked());
            Assert.IsTrue(xm2.getLocked());
            Assert.IsTrue(xm3.getLocked());
            Assert.IsFalse(xm2.hasAttribute(AttributeName.LOCKED));
            Assert.IsFalse(xm3.hasAttribute(AttributeName.LOCKED));
            xm2.setLocked(false);
            Assert.IsFalse(xm2.getLocked());
            Assert.IsFalse(xm3.getLocked());
            Assert.IsTrue(xm2.hasAttribute(AttributeName.LOCKED));
            Assert.IsFalse(xm3.hasAttribute(AttributeName.LOCKED));
            xm3.setLocked(true);
            Assert.IsFalse(xm2.getLocked());
            Assert.IsTrue(xm3.getLocked());
            Assert.IsTrue(xm2.hasAttribute(AttributeName.LOCKED));
            Assert.IsTrue(xm3.hasAttribute(AttributeName.LOCKED));
         }
      }


      [TestMethod]
      public virtual void testImplicitPartitions()
      {
         JDFDoc doc = creatXMDoc();
         JDFNode n = doc.getJDFRoot();
         JDFExposedMedia xm = (JDFExposedMedia)n.getMatchingResource("ExposedMedia", JDFNode.EnumProcessUsage.AnyInput, null, 0);
         Assert.IsNull(xm.getImplicitPartitions(), "xm no impicit part");
         JDFRunList ruli = (JDFRunList)n.addResource(ElementName.RUNLIST, null, EnumUsage.Input, null, null, null, null);
         JDFCutBlock cb = (JDFCutBlock)n.addResource(ElementName.CUTBLOCK, null, EnumUsage.Input, null, null, null, null);
         try
         {
            ruli.addPartition(EnumPartIDKey.RunIndex, "1");
            Assert.Fail("no go here");
         }
         catch (JDFException)
         {
            // nop
         }
         try
         {
            cb.addPartition(EnumPartIDKey.BlockName, "1");
            Assert.Fail("no go here");
         }
         catch (JDFException)
         {
            // nop
         }
         Assert.IsFalse(ruli.hasAttribute(AttributeName.PARTIDKEYS), "pidk");
         Assert.IsFalse(cb.hasAttribute(AttributeName.PARTIDKEYS), "pidk");
         ruli.addPartition(EnumPartIDKey.SheetName, "S1");
         Assert.AreEqual(EnumPartIDKey.SheetName.getName(), ruli.getAttribute(AttributeName.PARTIDKEYS), "pidk");
      }


      [TestMethod]
      public virtual void testRemoveImplicitPartions()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode n = doc.getJDFRoot();
         n.setType(EnumType.Interpreting);
         JDFRunList rul = (JDFRunList)n.appendMatchingResource(ElementName.RUNLIST, EnumProcessUsage.AnyInput, null);

         // tests for partition list
         Assert.AreEqual(rul, rul.getPartition(new JDFAttributeMap(EnumPartIDKey.RunIndex.getName(), "2~5"), null));
         Assert.IsNull(rul.getPartition(new JDFAttributeMap(EnumPartIDKey.PartVersion.getName(), "GR"), null));

      }


      ///   
      ///	 <summary> * test expand and collapse methods </summary>
      ///	 
      [TestMethod]
      public virtual void testCollapseElement()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode n = doc.getJDFRoot();
         JDFRunList rl = (JDFRunList)n.addResource("RunList", EnumUsage.Input);
         JDFLayoutElement le = rl.appendLayoutElement();
         JDFSeparationSpec ss1 = le.appendSeparationSpec();
         ss1.setName("n1");
         JDFSeparationSpec ss2 = le.appendSeparationSpec();
         ss2.setName("n2");
         rl.addPartition(EnumPartIDKey.Run, "r1");
         rl.addPartition(EnumPartIDKey.Run, "r2");
         rl.collapse(true);
         Assert.AreEqual(ss1, le.getSeparationSpec(0));
         Assert.AreEqual(ss2, le.getSeparationSpec(1));
         rl.collapse(false);
         Assert.AreEqual(ss1, le.getSeparationSpec(0));
         Assert.AreEqual(ss2, le.getSeparationSpec(1));
         le.collapse(true);
         Assert.AreEqual(ss1, le.getSeparationSpec(0));
         Assert.AreEqual(ss2, le.getSeparationSpec(1));
         le.collapse(false);
         Assert.AreEqual(ss1, le.getSeparationSpec(0));
         Assert.AreEqual(ss2, le.getSeparationSpec(1));
      }

      ///   
      ///	 <summary> * test clonePartitions method </summary>
      ///	 
      [TestMethod]
      public virtual void testClonePartions()
      {
         KElement pool = new JDFDoc("ResourcePool").getRoot();
         JDFResource r0 = (JDFResource)pool.appendElement("Preview");
         JDFResource s1 = r0.addPartition(EnumPartIDKey.SignatureName, "s1");
         JDFResource sh1 = r0.addPartition(EnumPartIDKey.SignatureName, "s2").addPartition(EnumPartIDKey.SheetName, "sh1");
         JDFResource r1 = (JDFResource)pool.appendElement("Layout");
         r1.clonePartitions(r0, null);
         int size = r1.getLeaves(false).Count;
         Assert.AreEqual(size, r0.getLeaves(false).Count);
         for (int i = 0; i < size; i++)
         {
            Assert.AreEqual(((JDFResource)r1.getLeaves(false)[i]).getPartMap(), ((JDFResource)r0.getLeaves(false)[i]).getPartMap());
         }
         r0.addPartition(EnumPartIDKey.SignatureName, "s3").addPartition(EnumPartIDKey.SheetName, "sh1");
         r1.clonePartitions(r0, null);
         size = r1.getLeaves(false).Count;
         Assert.AreEqual(size, r0.getLeaves(false).Count, " after second application ");
         for (int i = 0; i < size; i++)
         {
            Assert.AreEqual(((JDFResource)r1.getLeaves(false)[i]).getPartMap(), ((JDFResource)r0.getLeaves(false)[i]).getPartMap());
         }
         JDFResource r2 = (JDFResource)pool.appendElement("Layout");
         r2.clonePartitions(r0, new VString("SignatureName", null));
         size = r2.getLeaves(false).Count;
         Assert.AreEqual(3, size, " after third application - only signatureName");
         for (int i = 0; i < size; i++)
         {
            Assert.AreEqual(1, ((JDFResource)r2.getLeaves(false)[i]).getPartMap().Count);
         }

         JDFResource r3 = (JDFResource)pool.appendElement("Layout");
         r3.clonePartitions(s1, null);
         size = r3.getLeaves(false).Count;
         Assert.AreEqual(1, size, " partial clone: after 4th application - only signatureName");
         for (int i = 0; i < size; i++)
         {
            Assert.AreEqual(1, ((JDFResource)r3.getLeaves(false)[i]).getPartMap().Count);
         }

         JDFResource r4 = (JDFResource)pool.appendElement("Layout");
         r4.clonePartitions(sh1, null);
         size = r4.getLeaves(false).Count;
         Assert.AreEqual(1, size, " partial clone: after 5th application - only signatureName, sheetname 1");
         for (int i = 0; i < size; i++)
         {
            Assert.AreEqual(2, ((JDFResource)r4.getLeaves(false)[i]).getPartMap().Count);
         }
         r4.clonePartitions(s1, null);
         size = r4.getLeaves(false).Count;
         Assert.AreEqual(2, size, " multiple partial clone: after 5th application - only signatureName, sheetname 1");
      }

      ///   
      ///	 <summary> * test expand and collapse methods </summary>
      ///	 
      [TestMethod]
      public virtual void testCollapse()
      {
         JDFDoc doc = creatRLDoc();
         JDFNode n = doc.getJDFRoot();

         JDFDigitalPrintingParams dpp = (JDFDigitalPrintingParams)n.addResource(ElementName.DIGITALPRINTINGPARAMS, null, EnumUsage.Input, null, null, null, null);
         dpp.collapse(true);
         dpp.collapse(false);

         JDFRunList rl = (JDFRunList)n.getMatchingResource("RunList", JDFNode.EnumProcessUsage.AnyInput, null, 0);
         JDFAttributeMap map = new JDFAttributeMap();
         map.put("RunSet", "Set2");
         JDFRunList rlSet = (JDFRunList)rl.getPartition(map, null);
         Assert.IsNotNull(rlSet);
         map.put("Run", "Run2");
         JDFRunList rlRun = (JDFRunList)rl.getPartition(map, null);
         Assert.IsNotNull(rlRun);
         map.put("Separation", "Cyan");
         JDFRunList rlSep = (JDFRunList)rl.getPartition(map, null);
         Assert.IsNotNull(rlSep);
         Assert.IsTrue(rlRun.getIsPage());

         Assert.IsFalse(rlSep.getIsPage());
         rlRun.collapse(true);
         Assert.IsTrue(rlRun.getIsPage());
         Assert.IsFalse(rlSep.getIsPage());
         Assert.IsTrue(rlSet.getIsPage());
         Assert.IsTrue(rl.getIsPage());
         rlRun.collapse(false);
         Assert.IsTrue(rlRun.getIsPage());
         Assert.IsFalse(rlSep.getIsPage());
         Assert.IsTrue(rlSet.getIsPage());
         Assert.IsTrue(rl.getIsPage());
         rlRun.setRunTag("foo");
         rlRun.expand(true);
         rlRun.collapse(false);
         Assert.IsTrue(rlRun.hasAttribute(AttributeName.RUNTAG));
         Assert.IsFalse(rlSep.hasAttribute(AttributeName.RUNTAG));
         Assert.IsFalse(rlSet.hasAttribute(AttributeName.RUNTAG));
         rlRun.expand(true);
         rlRun.collapse(true);
         Assert.IsFalse(rlRun.hasAttribute(AttributeName.RUNTAG));
         Assert.IsTrue(rlSep.hasAttribute(AttributeName.RUNTAG));
         Assert.IsFalse(rlSet.hasAttribute(AttributeName.RUNTAG));
      }

      ///   
      ///	 <summary> * test expand and collapse methods </summary>
      ///	 
      [TestMethod]
      public virtual void testFixVersion()
      {
         JDFDoc doc = creatXMDoc();
         JDFNode n = doc.getJDFRoot();
         JDFExposedMedia xm = (JDFExposedMedia)n.getMatchingResource("ExposedMedia", JDFNode.EnumProcessUsage.AnyInput, null, 0);
         JDFExposedMedia xm2 = (JDFExposedMedia)xm.getPartition(new JDFAttributeMap(EnumPartIDKey.SignatureName, "Sig1"), null);
         Assert.IsTrue(xm.isValid(EnumValidationLevel.Complete));
         xm2.setAttribute("Class", EnumResourceClass.Handling.getName());
         Assert.IsFalse(xm.isValid(EnumValidationLevel.Complete));
         xm.fixVersion(null);
         Assert.IsNull(xm2.getAttribute_KElement("Class", null, null));
         Assert.IsTrue(xm.isValid(EnumValidationLevel.Complete));
      }

      ///   
      ///	 <summary> * test expand and collapse methods </summary>
      ///	 
      [TestMethod]
      public virtual void testExpand()
      {
         JDFDoc doc = creatXMDoc();
         JDFNode n = doc.getJDFRoot();
         JDFExposedMedia xm = (JDFExposedMedia)n.getMatchingResource("ExposedMedia", JDFNode.EnumProcessUsage.AnyInput, null, 0);
         xm.setBrand("rootBrand");
         xm.setGeneralID("testID", "rootValue");
         xm.expand(false);
         xm.collapse(true);
         xm.expand(true);
         xm.collapse(false);

         JDFAttributeMap mPart = new JDFAttributeMap("SignatureName", "Sig1");
         mPart.put("SheetName", "S1");
         mPart.put("Side", "Front");
         JDFExposedMedia xmPart = (JDFExposedMedia)xm.getPartition(mPart, null);
         mPart.put("SheetName", "S2");
         JDFExposedMedia xmPart2 = (JDFExposedMedia)xm.getPartition(mPart, null);

         xmPart.setBrand("PartBrand");
         xmPart.setGeneralID("testID", "partValue");

         xm.expand(false);
         Assert.AreEqual("PartBrand", xmPart.getBrand(), "expanded sub");
         Assert.AreEqual("partValue", xmPart.getGeneralID("testID"), "expanded sub");
         Assert.AreEqual("rootBrand", xmPart2.getBrand(), "expanded sub2");
         Assert.AreEqual("rootValue", xmPart2.getGeneralID("testID"), "expanded sub2");
         Assert.IsTrue(xmPart2.hasAttribute_KElement("Brand", null, false), "hasBrand");
         Assert.IsTrue(xmPart2.getElement_KElement("GeneralID", null, 0) != null, "hasID");
         Assert.IsFalse(xmPart.hasAttribute_KElement(AttributeName.SHEETNAME, null, false), "has part Key");
         Assert.IsFalse(xmPart2.hasAttribute_KElement(AttributeName.SHEETNAME, null, false), "has part Key");

         xm.collapse(false);
         Assert.AreEqual("PartBrand", xmPart.getBrand(), "expanded sub after collapse");
         Assert.AreEqual("partValue", xmPart.getGeneralID("testID"), "expanded sub after collapse");
         Assert.AreEqual("rootBrand", xmPart2.getBrand(), "expanded sub2 after collapse");
         Assert.AreEqual("rootValue", xmPart2.getGeneralID("testID"), "expanded sub2 after collapse");
         Assert.IsFalse(xmPart2.hasAttribute_KElement("Brand", null, false), "hasBrand");
         Assert.IsTrue(xmPart2.getElement_KElement("GeneralID", null, 0) == null, "hasID");
         Assert.IsFalse(xmPart.hasAttribute_KElement(AttributeName.SHEETNAME, null, false), "has part Key");
         Assert.IsFalse(xmPart2.hasAttribute_KElement(AttributeName.SHEETNAME, null, false), "has part Key");

         JDFExposedMedia xmPart3 = (JDFExposedMedia)xmPart2.getParentNode_KElement().getParentNode_KElement();
         mPart.put("SignatureName", "Sig2");
         JDFExposedMedia xmPart4 = (JDFExposedMedia)xm.getPartition(mPart, null);

         xmPart3.expand(true);
         Assert.IsTrue(xmPart2.hasAttribute_KElement("Brand", null, false), "hasBrand");
         Assert.IsFalse(xmPart4.hasAttribute_KElement("Brand", null, false), "hasBrand");
         Assert.IsTrue(xmPart2.getElement_KElement("GeneralID", null, 0) != null, "hasID");
         Assert.IsFalse(xmPart4.getElement_KElement("GeneralID", null, 0) != null, "hasID");
         Assert.IsFalse(xmPart.hasAttribute_KElement(AttributeName.SHEETNAME, null, false), "has part Key");
         Assert.IsFalse(xmPart2.hasAttribute_KElement(AttributeName.SHEETNAME, null, false), "has part Key");

         xmPart3.collapse(false);
         Assert.IsFalse(xmPart2.hasAttribute_KElement("Brand", null, false), "hasBrand");
         Assert.IsTrue(xmPart3.hasAttribute_KElement("Brand", null, false), "hasBrand");
         Assert.IsFalse(xmPart2.getElement_KElement("GeneralID", null, 0) != null, "hasID");

         xmPart3 = (JDFExposedMedia)xmPart4.getParentNode_KElement().getParentNode_KElement();
         xmPart3.expand(true);
         Assert.IsTrue(xmPart4.hasAttribute_KElement("Brand", null, false), "hasBrand");
         Assert.IsFalse(xmPart2.hasAttribute_KElement("Brand", null, false), "hasBrand");
         Assert.IsTrue(xmPart4.getElement_KElement("GeneralID", null, 0) != null, "hasID");
         Assert.IsFalse(xmPart2.getElement_KElement("GeneralID", null, 0) != null, "hasID");
         xmPart3.collapse(false);
         Assert.IsFalse(xmPart4.hasAttribute_KElement("Brand", null, false), "hasBrand");
         Assert.IsTrue(xmPart3.hasAttribute_KElement("Brand", null, false), "hasBrand");
         Assert.IsFalse(xmPart4.getElement_KElement("GeneralID", null, 0) != null, "hasID");
         Assert.IsTrue(xmPart3.getElement("GeneralID", null, 0) != null, "hasID");

         JDFDigitalPrintingParams dpp = (JDFDigitalPrintingParams)n.addResource(ElementName.DIGITALPRINTINGPARAMS, null, EnumUsage.Input, null, null, null, null);
         dpp.expand(true);
         dpp.expand(false);
         Assert.IsTrue(dpp.hasAttribute("ID"));
      }


      [TestMethod]
      public virtual void testGeneralID()
      {
         JDFDoc doc = creatXMDoc();
         JDFNode n = doc.getJDFRoot();
         JDFExposedMedia xm = (JDFExposedMedia)n.getMatchingResource("ExposedMedia", JDFNode.EnumProcessUsage.AnyInput, null, 0);
         JDFExposedMedia xm2 = (JDFExposedMedia)xm.getPartition(new JDFAttributeMap("SignatureName", "Sig1"), EnumPartUsage.Explicit);
         xm.setGeneralID("foo", "bar");
         Assert.AreEqual("bar", xm.getGeneralID("foo"));
         Assert.AreEqual("bar", xm2.getGeneralID("foo"));
         Assert.AreEqual(1, xm.numChildElements(ElementName.GENERALID, null));
         xm.setGeneralID("foo", "bar2");
         Assert.AreEqual("bar2", xm.getGeneralID("foo"));
         Assert.AreEqual(1, xm.numChildElements(ElementName.GENERALID, null));
         Assert.AreEqual(1, xm2.numChildElements(ElementName.GENERALID, null));
         xm2.setGeneralID("foo", "bar4");
         xm.setGeneralID("foo2", "bar3");
         Assert.AreEqual("bar2", xm.getGeneralID("foo"));
         Assert.AreEqual("bar4", xm2.getGeneralID("foo"));
         Assert.AreEqual("bar3", xm.getGeneralID("foo2"));
         Assert.AreEqual(xm.numChildElements(ElementName.GENERALID, null), 2);
         xm.removeGeneralID("foo");
         Assert.IsNull(xm.getGeneralID("foo"));
         Assert.AreEqual("bar3", xm.getGeneralID("foo2"));
         Assert.AreEqual(1, xm.numChildElements(ElementName.GENERALID, null));
         xm.setGeneralID("foo3", "bar33");
         JDFGeneralID gi = xm.getGeneralID(0);
         Assert.AreEqual("foo2", gi.getIDUsage());
         xm.removeGeneralID(null);
         Assert.AreEqual(0, xm.numChildElements(ElementName.GENERALID, null));
      }


      [TestMethod]
      public virtual void testGeneralIDEmptyNamespace()
      {
         JDFDoc doc = creatXMDoc();
         JDFNode n = doc.getJDFRoot();
         JDFExposedMedia xm = (JDFExposedMedia)n.getMatchingResource("ExposedMedia", JDFNode.EnumProcessUsage.AnyInput, null, 0);

         JDFGeneralID generalID = (JDFGeneralID)xm.appendElement(ElementName.GENERALID);
         Assert.AreEqual(JDFConstants.EMPTYSTRING, generalID.getIDUsage());
         Assert.AreEqual(JDFConstants.EMPTYSTRING, generalID.getIDValue());
      }


      [TestMethod]
      public virtual void testInstantiations()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode root = doc.getJDFRoot();
         JDFResourcePool resPool = root.getCreateResourcePool();
         KElement kElem = resPool.appendElement(ElementName.STRIPPINGPARAMS);
         Assert.IsTrue(kElem is JDFStrippingParams);

         kElem = resPool.appendElement(ElementName.STRIPCELLPARAMS);
         Assert.IsTrue(kElem is JDFStripCellParams);

         kElem = resPool.appendElement(ElementName.BINDERYSIGNATURE);
         Assert.IsTrue(kElem is JDFBinderySignature);
      }


      [TestMethod]
      public virtual void testGetElement()
      {
         JDFDoc doc = creatXMDoc();
         JDFNode n = doc.getJDFRoot();
         JDFExposedMedia xm = (JDFExposedMedia)n.getMatchingResource("ExposedMedia", JDFNode.EnumProcessUsage.AnyInput, null, 0);
         JDFMedia med = xm.getMedia();

         JDFAttributeMap mPart = new JDFAttributeMap("SignatureName", "Sig1");
         mPart.put("SheetName", "S1");
         mPart.put("Side", "Front");
         JDFExposedMedia xmPart = (JDFExposedMedia)xm.getPartition(mPart, null);
         Assert.AreEqual(xm.getMedia(), med);
         Assert.AreEqual(xmPart.getMedia(), med);
         JDFExposedMedia xmPartSig = (JDFExposedMedia)xm.getPartition(new JDFAttributeMap("SignatureName", "Sig1"), null);
         JDFMedia med2 = xmPartSig.appendMedia();
         Assert.AreEqual(xm.getMedia(), med);
         Assert.AreEqual(xmPart.getMedia(), med2);
         Assert.AreEqual(xmPartSig.getMedia(), med2);

         med = (JDFMedia)med.makeRootResource(null, null, true);
         Assert.AreEqual(xm.getMedia(), med);
         Assert.AreEqual(xmPart.getMedia(), med2);
         Assert.AreEqual(xmPartSig.getMedia(), med2);
      }


      ///   
      ///	 <summary> * tests getxpathattribute for partitions </summary>
      ///	 
      [TestMethod]
      public virtual void testGetXPathAttribute()
      {
         JDFDoc doc = creatXMDoc();
         JDFNode n = doc.getJDFRoot();
         Assert.AreEqual("Sig1", n.getXPathAttribute("ResourcePool/ExposedMedia/ExposedMedia/@SignatureName", null));
         Assert.IsNull(n.getXPathAttribute("ResourcePool/ExposedMedia/ExposedMedia/ExposedMedia/@SignatureName", null));
      }

      ///   
      ///	 <summary> * tests getxpathattribute for partitions </summary>
      ///	 
      [TestMethod]
      public virtual void testGetXPathElement()
      {
         JDFDoc doc = creatXMDoc();
         JDFNode n = doc.getJDFRoot();
         Assert.IsNotNull(n.getXPathElement("//ResourcePool/ExposedMedia/ExposedMedia[@SignatureName=\"Sig1\"]"));
      }


      [TestMethod]
      public virtual void testGetResStatus()
      {
         JDFDoc doc = creatXMDoc();
         JDFNode n = doc.getJDFRoot();
         JDFExposedMedia xm = (JDFExposedMedia)n.getMatchingResource("ExposedMedia", JDFNode.EnumProcessUsage.AnyInput, null, 0);
         JDFAttributeMap mPart = new JDFAttributeMap("SignatureName", "Sig1");
         mPart.put("SheetName", "S1");
         mPart.put("Side", "Front");
         JDFExposedMedia xmPart = (JDFExposedMedia)xm.getPartition(mPart, null);
         xm.setResStatus(EnumResStatus.Unavailable, false);
         JDFMedia med = xm.getMedia();
         med.setResStatus(EnumResStatus.Unavailable, false);
         med.makeRootResource(null, null, true);

         Assert.AreEqual(EnumResStatus.Unavailable, xm.getResStatus(false));
         Assert.AreEqual(EnumResStatus.Unavailable, xmPart.getResStatus(false));
         Assert.AreEqual(EnumResStatus.Unavailable, xm.getResStatus(true));
         Assert.AreEqual(EnumResStatus.Unavailable, xmPart.getResStatus(true));

         xmPart.setResStatus(EnumResStatus.Available, false);
         Assert.AreEqual(EnumResStatus.Unavailable, xm.getResStatus(false));
         Assert.AreEqual(EnumResStatus.Available, xmPart.getResStatus(false));
         Assert.AreEqual(EnumResStatus.Unavailable, xm.getResStatus(true));
         Assert.AreEqual(EnumResStatus.Unavailable, xmPart.getResStatus(true));

         med.setResStatus(EnumResStatus.Available, false);
         Assert.AreEqual(EnumResStatus.Unavailable, xm.getResStatus(false));
         Assert.AreEqual(EnumResStatus.Available, xmPart.getResStatus(false));
         Assert.AreEqual(EnumResStatus.Unavailable, xm.getResStatus(true));
         Assert.AreEqual(EnumResStatus.Available, xmPart.getResStatus(true));

         xmPart.removeAttribute(AttributeName.STATUS);
         Assert.AreEqual(EnumResStatus.Unavailable, xm.getResStatus(false));
         Assert.AreEqual(EnumResStatus.Unavailable, xmPart.getResStatus(false));
         Assert.AreEqual(EnumResStatus.Unavailable, xm.getResStatus(true));
         Assert.AreEqual(EnumResStatus.Unavailable, xmPart.getResStatus(true));

         xm.setResStatus(EnumResStatus.Available, false);
         Assert.AreEqual(EnumResStatus.Available, xm.getResStatus(false));
         Assert.AreEqual(EnumResStatus.Available, xmPart.getResStatus(false));
         Assert.AreEqual(EnumResStatus.Available, xm.getResStatus(true));
         Assert.AreEqual(EnumResStatus.Available, xmPart.getResStatus(true));

         med.setResStatus(EnumResStatus.Unavailable, false);
         Assert.AreEqual(EnumResStatus.Available, xm.getResStatus(false));
         Assert.AreEqual(EnumResStatus.Available, xmPart.getResStatus(false));
         Assert.AreEqual(EnumResStatus.Unavailable, xm.getResStatus(true));
         Assert.AreEqual(EnumResStatus.Unavailable, xmPart.getResStatus(true));
      }


      [TestMethod]
      public virtual void testGetCreatePartition2()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFNode n = doc.getJDFRoot();
         JDFResource media = n.addResource("Media", null, EnumUsage.Input, null, null, null, null);

         media.addPartition(EnumPartIDKey.SignatureName, "sig1");
         media.addPartition(EnumPartIDKey.SignatureName, "sig2");
         try
         {
            media.getCreatePartition(EnumPartIDKey.SheetName, "sh11", new VString("SignatureName SheetName", " "));
            Assert.Fail("no parallel");
         }
         catch (JDFException)
         {
            // nop
         }
      }


      [TestMethod]
      public virtual void testGetCreatePartition3()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFNode n = doc.getJDFRoot();
         JDFResource media = n.addResource("Media", null, EnumUsage.Input, null, null, null, null);

         JDFMedia mp1 = (JDFMedia)media.addPartition(EnumPartIDKey.SignatureName, "sig1");
         mp1.addPartition(EnumPartIDKey.SheetName, "sh1");
         JDFMedia mp2 = (JDFMedia)media.addPartition(EnumPartIDKey.SignatureName, "sig2");
         mp2.addPartition(EnumPartIDKey.SheetName, "sh1");
         Assert.AreEqual(2, media.getPartitionVector(new JDFAttributeMap(AttributeName.SHEETNAME, "sh1"), null).Count);

         try
         {
            media.getCreatePartition(EnumPartIDKey.SheetName, "sh11", new VString("SignatureName SheetName", " "));
            Assert.Fail("no parallel");
         }
         catch (JDFException)
         {
            // nop
         }
      }


      [TestMethod]
      public virtual void testAddpartitionEnum()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFNode n = doc.getJDFRoot();
         JDFResource media = n.addResource("Media", null, EnumUsage.Input, null, null, null, null);
         media = media.addPartition(EnumPartIDKey.Side, EnumSide.Front);
         Assert.AreEqual(EnumSide.Front, media.getSide());
      }


      [TestMethod]
      public virtual void testAddpartition()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFNode n = doc.getJDFRoot();
         JDFResource media = n.addResource("Media", null, EnumUsage.Input, null, null, null, null);

         JDFResource sig = media.addPartition(EnumPartIDKey.SignatureName, "sig1");
         media.addPartition(EnumPartIDKey.SignatureName, "sig2");
         try
         {
            media.addPartition(EnumPartIDKey.SignatureName, "sig1");
            Assert.Fail("no identical key");
         }
         catch (JDFException)
         {
            // nop
         }

         try
         {
            media.addPartition(EnumPartIDKey.SheetName, "sh11");
            Assert.Fail("no parallel");
         }
         catch (JDFException)
         {
            // nop
         }

         try
         {
            sig.addPartition(EnumPartIDKey.SignatureName, "sig2");
            Assert.Fail("no existing");
         }
         catch (JDFException)
         {
            // nop
         }

         JDFResource sheet = sig.addPartition(EnumPartIDKey.SheetName, "sh1");
         try
         {
            sig.addPartition(EnumPartIDKey.Side, "Front");
            Assert.Fail("no existing other parallel");
         }
         catch (JDFException)
         {
            // nop
         }
         try
         {
            sheet.addPartition(EnumPartIDKey.SignatureName, "Sig3");
            Assert.Fail("no existing lower");
         }
         catch (JDFException)
         {
            // nop
         }
         sheet.addPartition(EnumPartIDKey.Side, "Front");
         sheet.addPartition(EnumPartIDKey.Side, "Back");
      }


      [TestMethod]
      public virtual void testMultiplePartIDKeys()
      {
         JDFDoc doc = creatXMDoc();
         JDFNode n = doc.getJDFRoot();
         JDFExposedMedia xm = (JDFExposedMedia)n.getMatchingResource("ExposedMedia", JDFNode.EnumProcessUsage.AnyInput, null, 0);
         JDFAttributeMap mPart = new JDFAttributeMap("SignatureName", "Sig1");
         mPart.put("SheetName", "S1");
         mPart.put("Side", "Front");
         JDFExposedMedia xmPart = (JDFExposedMedia)xm.getPartition(mPart, null);
         Assert.AreEqual(0, xmPart.getInvalidAttributes(EnumValidationLevel.Incomplete, true, 999).Count);
         JDFResource r = xmPart.addPartition(EnumPartIDKey.Condition, "Good");
         Assert.IsFalse(r.getInvalidAttributes(EnumValidationLevel.Incomplete, true, 999).Contains(EnumPartIDKey.Condition.getName()));
         xmPart.addPartition(EnumPartIDKey.Condition, "Bad").setAttribute(EnumPartIDKey.Condition.getName(), "Good");
         Assert.IsTrue(r.getInvalidAttributes(EnumValidationLevel.Incomplete, true, 999).Contains(EnumPartIDKey.Condition.getName()), "Duplicate partition found");
      }


      [TestMethod]
      public virtual void testConsistentPartIDKeys()
      {
         JDFDoc doc = creatXMDoc();
         JDFNode n = doc.getJDFRoot();
         JDFExposedMedia xm = (JDFExposedMedia)n.getMatchingResource("ExposedMedia", JDFNode.EnumProcessUsage.AnyInput, null, 0);
         JDFAttributeMap mPart = new JDFAttributeMap("SignatureName", "Sig1");
         mPart.put("SheetName", "S1");
         mPart.put("Side", "Front");
         JDFExposedMedia xmPart = (JDFExposedMedia)xm.getPartition(mPart, null);
         Assert.IsTrue(xmPart.consistentPartIDKeys(EnumPartIDKey.BinderySignatureName));
         Assert.IsTrue(xmPart.consistentPartIDKeys(EnumPartIDKey.Side));
         xmPart.removeAttribute("Side");
         Assert.IsFalse(xmPart.consistentPartIDKeys(EnumPartIDKey.Side));
         Assert.IsTrue(xmPart.getInvalidAttributes(EnumValidationLevel.Complete, false, 999).Contains("Side"));
         xm.setAttribute("Side", "Front");
         Assert.IsFalse(xmPart.consistentPartIDKeys(EnumPartIDKey.Side));
         xmPart.setAttribute("Side", "Front");
         Assert.IsFalse(xmPart.consistentPartIDKeys(EnumPartIDKey.Side));
         xm.removeAttribute("Side");
         Assert.IsTrue(xmPart.consistentPartIDKeys(EnumPartIDKey.Side));
         Assert.IsTrue(xmPart.consistentPartIDKeys(EnumPartIDKey.SheetName));
         xmPart.getParentNode_KElement().removeAttribute("SheetName");
         Assert.IsFalse(xmPart.consistentPartIDKeys(EnumPartIDKey.SheetName));
         xmPart.getParentNode_KElement().setAttribute("SignatureName", "foo");
         Assert.IsFalse(xmPart.consistentPartIDKeys(EnumPartIDKey.SheetName));
         Assert.IsTrue(xmPart.getInvalidAttributes(EnumValidationLevel.Complete, false, 999).Contains("SignatureName"));
      }


      ///   
      ///	 <summary> * jdf 1.4 preview anywhere example </summary>
      ///	 
      [TestMethod]
      public virtual void testPreview14()
      {
         JDFDoc doc = new JDFDoc("JDF");
         JDFNode n = doc.getJDFRoot();
         n.setJobPartID("P1");
         n.setJobID("J1");
         n.setType("ConventionalPrinting", true);

         JDFComponent comp = (JDFComponent)n.appendMatchingResource("Component", JDFNode.EnumProcessUsage.AnyOutput, null);
         JDFPreview pvc = (JDFPreview)comp.appendElement(ElementName.PREVIEW);
         pvc.setURL("http://somehost/pvComponent.png");
         pvc.setPreviewType(EnumPreviewType.ThumbNail);
         JDFExposedMedia xm = (JDFExposedMedia)n.appendMatchingResource("ExposedMedia", JDFNode.EnumProcessUsage.Plate, null);
         xm.appendMedia();
         JDFPreview pv = (JDFPreview)xm.appendElement(ElementName.PREVIEW);
         pv.setURL("http://somehost/pvExposedMedia.png");
         pv.setPreviewType(EnumPreviewType.ThumbNail);
         doc.write2File(sm_dirTestDataTemp + "pv14.jdf", 2, false);
      }


      [TestCleanup]
      public override void tearDown()
      {
         // TODO Auto-generated method stub
         base.tearDown();
         JDFResource.setAutoAgent(b);

      }


      [TestInitialize]
      public override void setUp()
      {
         // TODO Auto-generated method stub
         base.setUp();
         b = JDFResource.getAutoAgent();
      }
   }
}
