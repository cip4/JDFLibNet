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


namespace org.cip4.jdflib.jmf
{
   using System.Collections.Generic;
   using Microsoft.VisualStudio.TestTools.UnitTesting;


   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using EnumMediaType = org.cip4.jdflib.auto.JDFAutoMedia.EnumMediaType;
   using EnumUpdateMethod = org.cip4.jdflib.auto.JDFAutoResourceCmdParams.EnumUpdateMethod;
   using EnumScope = org.cip4.jdflib.auto.JDFAutoUsageCounter.EnumScope;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFNodeInfo = org.cip4.jdflib.core.JDFNodeInfo;
   using JDFRefElement = org.cip4.jdflib.core.JDFRefElement;
   using VString = org.cip4.jdflib.core.VString;
   using EnumNodeStatus = org.cip4.jdflib.core.JDFElement.EnumNodeStatus;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using EnumValidationLevel = org.cip4.jdflib.core.KElement.EnumValidationLevel;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using EnumFamily = org.cip4.jdflib.jmf.JDFMessage.EnumFamily;
   using EnumType = org.cip4.jdflib.jmf.JDFMessage.EnumType;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using EnumProcessUsage = org.cip4.jdflib.node.JDFNode.EnumProcessUsage;
   using NodeIdentifier = org.cip4.jdflib.node.JDFNode.NodeIdentifier;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using EnumPartIDKey = org.cip4.jdflib.resource.JDFResource.EnumPartIDKey;
   using EnumResStatus = org.cip4.jdflib.resource.JDFResource.EnumResStatus;
   using EnumResourceClass = org.cip4.jdflib.resource.JDFResource.EnumResourceClass;
   using JDFExposedMedia = org.cip4.jdflib.resource.process.JDFExposedMedia;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;
   using JDFUsageCounter = org.cip4.jdflib.resource.process.JDFUsageCounter;
   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

///
/// <summary> * @author Rainer Prosi
/// * 
/// *         Test of the Resource JMF </summary>
/// 
   [TestClass]
   public class JMFResourceTest : JDFTestCaseBase
   {
///   
///	 <summary> *  </summary>
///	 
      [TestMethod]
      public virtual void testResourceQuParams()
      {
         JDFDoc doc = new JDFDoc(ElementName.JMF);
         JDFJMF jmf = doc.getJMFRoot();

         JDFQuery c = jmf.appendQuery();
         jmf.setSenderID("MISSenderID");
         c.setType(EnumType.Resource);
         JDFResourceQuParams rqp = c.getCreateResourceQuParams(0);
         List<ValuedEnum> vClasses = new List<ValuedEnum>();
         vClasses.Add(EnumResourceClass.Consumable);
         vClasses.Add(EnumResourceClass.Handling);
         rqp.setClasses(vClasses);
         Assert.AreEqual(vClasses.ToString(), rqp.getClasses().ToString());
      }


      ///   
///	 <summary> * test for nodeidentifier </summary>
///	 
      [TestMethod]
      public virtual void testGetIdentifier()
      {
         JDFDoc doc = new JDFDoc(ElementName.JMF);
         JDFJMF jmf = doc.getJMFRoot();

         JDFQuery c = jmf.appendQuery();
         jmf.setSenderID("MISSenderID");
         c.setType(EnumType.Resource);
         JDFResourceQuParams rqp = c.getCreateResourceQuParams(0);
         rqp.setJobID("J1");
         rqp.setJobPartID("p2");
         Assert.AreEqual(new NodeIdentifier("J1", "p2", null), rqp.getIdentifier());

      }


///   
///	 <summary> *  </summary>
///	 
      [TestMethod]
      public virtual void testUsageCounter()
      {
         JDFDoc doc = new JDFDoc(ElementName.JMF);
         JDFJMF jmf = doc.getJMFRoot();

         JDFSignal s = jmf.appendSignal();
         jmf.setSenderID("DeviceSenderID");

         s.setType(EnumType.Resource);
         JDFResourceQuParams rqp = s.appendResourceQuParams();
         rqp.setJobID("JobID");
         rqp.setJobPartID("JobPartID");
         rqp.setResourceName(ElementName.USAGECOUNTER);

         JDFResourceInfo ri = s.appendResourceInfo();
         ri.setActualAmount(42);
         JDFUsageCounter uc = (JDFUsageCounter) ri.appendElement(ElementName.USAGECOUNTER);
         uc.setID("UsageCounterID");
         uc.setScope(EnumScope.Job);
         uc.setCounterID("DeviceCounterID");
         uc.setResStatus(EnumResStatus.Available, true);
         uc.setCounterTypes(new VString("NormalSize", " "));
         doc.write2File(sm_dirTestDataTemp + "JMFResourceSignal.jmf", 2, false);
         Assert.IsTrue(jmf.isValid(EnumValidationLevel.Complete));
      }


///   
///	 <summary> *  </summary>
///	 
      [TestMethod]
      public virtual void testMedia()
      {
         JDFDoc doc = new JDFDoc(ElementName.JMF);
         JDFJMF jmf = doc.getJMFRoot();

         JDFSignal s = jmf.appendSignal();
         jmf.setSenderID("DeviceSenderID");

         s.setType(EnumType.Resource);
         JDFResourceQuParams rqp = s.appendResourceQuParams();
         rqp.setJobID("JobID");
         rqp.setJobPartID("JobPartID");
         rqp.setResourceName(ElementName.MEDIA);

         JDFResourceInfo ri = s.appendResourceInfo();
         ri.getCreateAmountPool();
      // TODO continue
      }

///   
///	 <summary> *  </summary>
///	 
      [TestMethod]
      public virtual void testMediaCatalog()
      {
         JDFDoc doc = new JDFDoc(ElementName.JMF);
         JDFJMF jmf = doc.getJMFRoot();
         jmf.setSenderID("DeviceSenderID");

         JDFQuery q = jmf.appendQuery(EnumType.Resource);
         q.setXMLComment("This is the query for a catalog");

         JDFResourceQuParams rqp = q.appendResourceQuParams();
         rqp.setExact(true);
         rqp.setXMLComment("Scope=Allowed is a new attribute to describe that we want a complet list of all known resources");
         rqp.setResourceName(ElementName.MEDIA);
      //		rqp.setAttribute("Scope", "Allowed");

         JDFResponse r = q.createResponse().getResponse(0);
         r = (JDFResponse) jmf.moveElement(r, null);
         r.setXMLComment("This is the response to the query - generally it will be in it's own jmf...\nThe list of ResourceInfo + the ResourceQuParams could also be specified in a Signal.");

         for (int i = 1; i < 5; i++)
         {
            JDFResourceInfo ri = r.appendResourceInfo();
            ri.setResourceName("Media");
            JDFMedia m = (JDFMedia) ri.appendResource("Media");
            m.setDescriptiveName("Description of Media #" + i);
            m.setDimensionCM(new JDFXYPair(i * 10, 13 + i % 2 * 20));
            m.setBrand("Brand #" + i);
            m.setProductID("ProductID_" + i);
            m.setMediaType(EnumMediaType.Paper);
            m.setResStatus((i < 2 ? EnumResStatus.Available : EnumResStatus.Unavailable), false);
            ri.setXMLComment("More attributes can be added as needed; Available = loaded");
         }
         doc.write2File(sm_dirTestDataTemp + "MediaCatalog.jmf", 2, false);
         Assert.IsTrue(jmf.isValid(EnumValidationLevel.Complete));
      }


///   
///	 <summary> *  </summary>
///	 
      [TestMethod]
      public virtual void testMediaRef()
      {

         JDFDoc doc = new JDFDoc(ElementName.JMF);
         JDFJMF jmf = doc.getJMFRoot();

         JDFSignal s = jmf.appendSignal();
         jmf.setSenderID("DeviceSenderID");

         s.setType(EnumType.Resource);
         JDFResourceQuParams rqp = s.appendResourceQuParams();
         rqp.setJobID("JobID");
         rqp.setJobPartID("JobPartID");
         rqp.setResourceName(ElementName.EXPOSEDMEDIA);

         JDFResourceInfo ri = s.appendResourceInfo();
         JDFExposedMedia xm = (JDFExposedMedia) ri.appendElement("ExposedMedia");

         JDFResourceInfo ri2 = s.appendResourceInfo();
         JDFMedia m = (JDFMedia) ri2.appendElement("Media");
         JDFRefElement rm = xm.refElement(m);

         Assert.AreEqual(m, rm.getTarget(), "works initially ");
         Assert.AreEqual(m, rm.getTarget(), "also works with cache");
      }


///   
///	 <summary> * apply a resource cmd </summary>
///	 
      [TestMethod]
      public virtual void testApplyResourceCmdNodeInfo()
      {
         JDFDoc doc = new JDFDoc(ElementName.JMF);
         JDFJMF jmf = doc.getJMFRoot();

         JDFCommand c = jmf.appendCommand();
         jmf.setSenderID("DeviceSenderID");

         c.setType(EnumType.Resource);
         JDFResourceCmdParams rqp = c.appendResourceCmdParams();
         rqp.setJobID("JobID");
         rqp.setJobPartID("JobPartID");
         rqp.setResourceName(ElementName.NODEINFO);
         rqp.setUsage(EnumUsage.Input);
         JDFNodeInfo niRQP = (JDFNodeInfo) rqp.appendElement(ElementName.NODEINFO);

         JDFAttributeMap sheetMap = new JDFAttributeMap("SheetName", "S1");
         rqp.setPartMap(sheetMap);
         JDFNodeInfo niRQPS1 = (JDFNodeInfo) niRQP.getCreatePartition(sheetMap, null);
         niRQPS1.setNodeStatus(EnumNodeStatus.Aborted);
         JDFDoc docJDF = new JDFDoc(ElementName.JDF);
         JDFNode jdf = docJDF.getJDFRoot();
         jdf.setType(org.cip4.jdflib.node.JDFNode.EnumType.ConventionalPrinting);
         jdf.setStatus(EnumNodeStatus.Waiting);
         jdf.setJobID("JobID");
         jdf.setJobPartID("JobPartID");

         Assert.AreEqual(EnumNodeStatus.Waiting, jdf.getPartStatus(null));
         Assert.AreEqual(EnumNodeStatus.Waiting, jdf.getStatus());
         rqp.applyResourceCommand(jdf);
         Assert.AreEqual(EnumNodeStatus.Part, jdf.getStatus());
         Assert.AreEqual(EnumNodeStatus.Waiting, jdf.getNodeInfo().getNodeStatus());
         Assert.AreEqual(EnumNodeStatus.Aborted, jdf.getPartStatus(sheetMap));

         sheetMap = new JDFAttributeMap("SheetName", "S2");
         rqp.setPartMap(sheetMap);
         niRQPS1.setAttributes(sheetMap);
         niRQPS1.setNodeStatus(EnumNodeStatus.Completed);

         rqp.applyResourceCommand(jdf);
         Assert.AreEqual(EnumNodeStatus.Part, jdf.getStatus());
         Assert.AreEqual(EnumNodeStatus.Waiting, jdf.getNodeInfo().getNodeStatus());
         Assert.AreEqual(EnumNodeStatus.Completed, jdf.getPartStatus(sheetMap));
      }

///   
///	<summary> * apply a resource cmd </summary>
///	
      [TestMethod]
      public virtual void testApplyResourceCmd()
      {
         JDFDoc doc = new JDFDoc(ElementName.JMF);
         JDFJMF jmf = doc.getJMFRoot();

         JDFCommand c = jmf.appendCommand();
         jmf.setSenderID("DeviceSenderID");

         c.setType(EnumType.Resource);
         JDFResourceCmdParams rqp = c.appendResourceCmdParams();
         rqp.setJobID("JobID");
         rqp.setJobPartID("JobPartID");
         rqp.setResourceName("Media");
         JDFMedia mediaRQP = (JDFMedia) rqp.appendElement("Media");
         mediaRQP.setDimension(new JDFXYPair(20, 30));

         JDFDoc docJDF = new JDFDoc(ElementName.JDF);
         JDFNode jdf = docJDF.getJDFRoot();
         jdf.setType(org.cip4.jdflib.node.JDFNode.EnumType.ConventionalPrinting);
         JDFMedia mediaJDF = (JDFMedia) jdf.addResource("Media", null, EnumUsage.Input, null, null, null, null);
         mediaJDF.setDimension(new JDFXYPair(40, 60));
         rqp.setJobID(jdf.getJobID(true));
         rqp.setJobPartID(jdf.getJobPartID(true));

         rqp.applyResourceCommand(jdf);
         JDFMedia m2 = (JDFMedia) jdf.getMatchingResource("Media", EnumProcessUsage.AnyInput, null, 0);
         Assert.AreEqual(new JDFXYPair(20, 30), m2.getDimension());

         JDFAttributeMap sheetMap = new JDFAttributeMap("SheetName", "S1");
         rqp.setPartMap(sheetMap);
         mediaRQP.setDimension(new JDFXYPair(200, 300));

         JDFMedia m2Sheet = (JDFMedia) m2.addPartition(EnumPartIDKey.SheetName, "S1");
         rqp.applyResourceCommand(jdf);
         Assert.AreEqual(new JDFXYPair(20, 30), m2.getDimension(), "retained root dimension");
         Assert.AreEqual(new JDFXYPair(200, 300), m2Sheet.getDimension(), "overwrote leaf root dimension");

         sheetMap.put(EnumPartIDKey.SheetName, "S2");
         rqp.setPartMap(sheetMap);
         mediaRQP.setDimension(new JDFXYPair(300, 400));

         rqp.applyResourceCommand(jdf);
         JDFMedia m2Sheet2 = (JDFMedia) m2.getPartition(sheetMap, null);
         Assert.IsNotNull(m2Sheet2);
         Assert.AreEqual(new JDFXYPair(20, 30), m2.getDimension(), "retained root dimension");
         Assert.AreEqual(new JDFXYPair(300, 400), m2Sheet2.getDimension(), "overwrote leaf root dimension");

         JDFMedia mPartRQP = (JDFMedia) mediaRQP.addPartition(EnumPartIDKey.SheetName, "S3");
         sheetMap.put(EnumPartIDKey.SheetName, "S3");
         rqp.setPartMap(sheetMap);
         mPartRQP.setDimension(new JDFXYPair(400, 600));

         rqp.applyResourceCommand(jdf);
         JDFMedia m2Sheet3 = (JDFMedia) m2.getPartition(sheetMap, null);
         Assert.AreEqual(new JDFXYPair(20, 30), m2.getDimension(), "retained root dimension");
         Assert.AreEqual(new JDFXYPair(400, 600), m2Sheet3.getDimension(), "overwrote leaf root dimension");
         Assert.IsFalse(m2Sheet3.hasAttribute_KElement("ID", null, false));

         mPartRQP.setAttribute(AttributeName.DIMENSION, "");
         mediaRQP.removeAttribute(AttributeName.DIMENSION);
         rqp.applyResourceCommand(jdf);
         JDFMedia m2Sheet4 = (JDFMedia) m2.getPartition(sheetMap, null);
         Assert.AreEqual(new JDFXYPair(20, 30), m2.getDimension(), "retained root dimension");
         Assert.IsFalse(m2Sheet4.hasAttribute_KElement(AttributeName.DIMENSION, null, false), "removed leaf dimension");
      }

///   
///	 <summary> * Method testResourceCommand
///	 *  </summary>
///	 * <exception cref="Exception"> </exception>
///	 
      [TestMethod]
      public virtual void testResourceCommand()
      {
         JDFDoc jdfDoc = JDFDoc.parseFile(sm_dirTestData + "ResourceCommandTest.jdf");
         JDFNode root = jdfDoc.getJDFRoot();
         JDFResourceCmdParams @params;

         JDFAttributeMap amAttr = new JDFAttributeMap();

         amAttr.put("Start", "2006-11-02T14:13:18+01:00");
         amAttr.put("End", "2006-11-02T15:13:18+01:00");
         string partID, resID;
         for (int i = 0; i < 2; i++)
         {

            JDFAttributeMap amParts = new JDFAttributeMap();
            if (i == 0)
            {
               amParts.put("SignatureName", "Sig001");
               amParts.put("SheetName", "FB 001");
               amParts.put("Side", "Front");
               partID = "SFP0.C";
               resID = "Link49087948_000508";
            }
            else
            {
               resID = "Link49165276_000704";
               amParts.put("SignatureName", "Sig002");
               amParts.put("SheetName", "FB 002");
               amParts.put("Side", "Back");
               partID = "SFP1.C";
            }
            @params = createResourceParams(partID, resID, amParts, amAttr);
            JDFNode n = root.getJobPart(partID, null);
            @params.applyResourceCommand(n);
            Assert.IsNotNull(n);
            JDFNodeInfo ni = (JDFNodeInfo) n.getChildWithAttribute(ElementName.NODEINFO, "ID", null, resID, 0, false);
            Assert.IsNotNull(ni);
            JDFNodeInfo nip = (JDFNodeInfo) ni.getPartition(amParts, null);
            Assert.IsNotNull(nip);
            Assert.IsFalse(nip.hasAttribute_KElement("ID", null, false));
            Assert.IsFalse(nip.hasAttribute_KElement("SheetName", null, false));
         }
      }

///   
///	 <summary> * Method testResourceCommandPartIDKeys
///	 *  </summary>
///	 
      [TestMethod]
      public virtual void testResourceCommandPartIDKeys()
      {
         JDFDoc jdfDoc = JDFDoc.parseFile(sm_dirTestData + "ResourceCmd.jdf");
         JDFDoc jdfDocJMF = JDFDoc.parseFile(sm_dirTestData + "ResourceCmd.jmf");
         JDFJMF jmf = jdfDocJMF.getJMFRoot();
         for (int i = 0; true; i++)
         {
            JDFCommand cmd = (JDFCommand) jmf.getMessageElement(JDFMessage.EnumFamily.Command, JDFMessage.EnumType.Resource, i);
            if (cmd == null)
               break;
            JDFResourceCmdParams @params = cmd.getResourceCmdParams(0);
            @params.applyResourceCommand(jdfDoc.getJDFRoot());
         }
      }


      private JDFResourceCmdParams createResourceParams(string strJobPartID, string strResourceID, JDFAttributeMap amParts, JDFAttributeMap amAttr)
      {
         JDFJMF jmf = JDFJMF.createJMF(EnumFamily.Command, JDFMessage.EnumType.Resource);

         JDFCommand cmd = jmf.getCommand(0);

         JDFResourceCmdParams @params = cmd.appendResourceCmdParams();

         const string strJobID = "RefJob-1";
         const string strPartIDKeys = "SignatureName SheetName Side";

         @params.setJobID(strJobID);
         @params.setJobPartID(strJobPartID);
         @params.setResourceID(strResourceID);
         @params.setResourceName("NodeInfo");
         @params.setUpdateMethod(EnumUpdateMethod.Incremental);

         @params.setPartMap(amParts);

         JDFResource nodeInfo = @params.appendResource("NodeInfo");

         JDFResource resLeaf = nodeInfo.getCreatePartition(amParts, new VString(strPartIDKeys, null));

         resLeaf.setAttributes(amAttr);

         return (@params);
      }
   }
}
