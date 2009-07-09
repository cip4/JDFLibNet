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

/* 
 * DummyTest.java
 *
 * @author Dietrich Mucha
 *
 * Copyright (C) 2005-2006 Heidelberger Druckmaschinen AG. All Rights Reserved.
 */
 
namespace org.cip4.jdflib.core
{
   using System.IO;
   using Microsoft.VisualStudio.TestTools.UnitTesting;

   using EnumValidationLevel = org.cip4.jdflib.core.KElement.EnumValidationLevel;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using EnumProcessUsage = org.cip4.jdflib.node.JDFNode.EnumProcessUsage;
   using JDFAssembly = org.cip4.jdflib.resource.process.JDFAssembly;
   using JDFAssemblySection = org.cip4.jdflib.resource.process.JDFAssemblySection;

   [TestClass]
   public class DummyTest
   {
      //internal string fileSeparator = Path.DirectorySeparatorChar.ToString();
      //internal string sm_dirTestSchema = "test" + fileSeparator + "Schema" + fileSeparator;
      //internal string sm_dirTestData = "test" + fileSeparator + "data" + fileSeparator;
      //internal string sm_dirTestDataTemp = sm_dirTestData + "temp" + fileSeparator;

      private JDFDoc doc = null;
      private JDFNode n = null;
      private JDFAssembly @as = null;

      [TestInitialize]
      public  virtual void setUp()
      {
         doc = new JDFDoc("JDF");
         n = doc.getJDFRoot();
         n.setType("Stripping", true);
         @as = (JDFAssembly) n.appendMatchingResource(ElementName.ASSEMBLY, EnumProcessUsage.AnyInput, null);
      }

      [TestMethod]
      public virtual void testSubAssemblySection()
      {
         JDFAssemblySection ass = @as.appendAssemblySection();
         ass = @as.appendAssemblySection();
         JDFAssemblySection asss = ass.appendAssemblySection();
         asss.setAssemblyIDs(new VString("a b c", " "));
         ass = @as.getAssemblySection(0);
         ass = @as.getAssemblySection(1);
         ass.setXMLComment("MyComment");
         ass = @as.getAssemblySection(2);

//		Collection<JDFAssemblySection> vASS = 
            @as.getAllAssemblySection();

         Assert.IsTrue(@as.isValid(EnumValidationLevel.Incomplete));
      }

   //    /**
   //     * Get all children from the actual element 
   //     *
   //     * @return Collection<JDFAssemblySection> collection with all found elements
   //     */
   //    public Collection<JDFAssemblySection> getAssemblySections()
   //    {
   //      Vector<JDFAssemblySection> v = new Vector<JDFAssemblySection>();
   //
   //        JDFAssemblySection kElem = (JDFAssemblySection) getFirstChildElement(ElementName.ASSEMBLYSECTION, null);
   //
   //        while (kElem != null)
   //        {
   //            v.add(kElem);
   //
   //            kElem = (JDFAssemblySection) kElem.getNextSiblingElement(ElementName.ASSEMBLYSECTION, null);
   //        }
   //
   //        return v;
   //    }

   //    public void testDeviceStatus()
   //   {
   //        JDFDoc jmfDoc = new JDFDoc("JMF");
   //        JDFJMF jmf=jmfDoc.getJMFRoot();
   //        jmf.setDescriptiveName("Initial phase when the RIP starts up");
   //        JDFSignal signal=jmf.appendSignal(JDFMessage.EnumType.Status);
   //        JDFDeviceInfo di=signal.appendDeviceInfo();
   //
   //		di.setDeviceStatus(null);
   //		System.out.println();
   //   }
   //
   //   public void testGet()
   //    {
   //		final JDFAttributeMap mARes = new JDFAttributeMap("HDM:SequenceType", "*");
   //		String value1 = mARes.get("dummy");
   //		String value2 = mARes.get("HDM:SequenceType");
   //		System.out.println();
   //    }
   //    public void testNamespace()
   //    {
   //        XMLDoc doc      = new XMLDoc(ElementName.JDF, "");
   //        KElement root = doc.getRoot();
   //
   //        root.setAttribute("xmlns","http://www.CIP4.org/JDFSchema_1_1");
   //
   //        String docNS    = "http://www.cip4.org/test/";
   //        String myPrefix = "MyPrefix";
   //
   //
   //        // add the namespace, this is mandatory for java xerces (contrary to c++ xerces )
   //        root.addNameSpace(myPrefix, docNS);
   //    }
   //   
   //    public void testGetLinkedResources() {
   ///*
   // * Claas : getChildren(String) --> getChildren(ClassName)
   // * Fehlerdatenbank 
   // * Edzard Links
   // * Test : Anfangen zu testen
   // * Rainer : type proof collections
   // */
   //    	Vector<JDFNode> vj = new Vector<JDFNode>(2);
   //    	Vector<KElement> vk = new Vector<KElement>(2);
   //    	Vector<KElement> vl = new Vector<KElement>(2);
   //    	KElement kelem = null;
   //    	JDFNode  jnode = null;
   //    	
   //    	vk = vl;
   ////    	vk = vj;
   ////    	vj = vk;
   //    	
   //    	vk.setElementAt(kelem, 0);
   //    	vk.setElementAt(jnode, 0);
   //    	vj.setElementAt(jnode, 0);
   ////    	vj.setElementAt(kelem, 0);	// no, a kelem is not a jnode
   //    	
   //		final JDFParser parser = new JDFParser();
   //		JDFDoc jdfDoc = parser.parseFile("dm_20070720_1.jdf");
   ////		JDFDoc jdfDoc = parser.parseFile("070718-01_AN.jdf");
   //		JDFNode root = jdfDoc.getJDFRoot();
   //		
   //		String contentJobHomeTemplate = getContentJobHomeTemplate(root);
   //		if (contentJobHomeTemplate == null) {
   //			// walk through visible qualify sequences
   //			JDFNode onlineContentJDF = getOnlineContentJDF(root);
   //			if (onlineContentJDF != null) {
   //				contentJobHomeTemplate = getContentJobHomeTemplate(onlineContentJDF);
   //			}
   //		}
   //		
   //		System.out.println("ContentJobHomeTemplate="+contentJobHomeTemplate);
   //	}
   //
   //    /**
   //     * return the first onlineContentJDF in the first valid qualifyNode
   //     * @param root
   //     * @return
   //     */
   //	private JDFNode getOnlineContentJDF(JDFNode root) {
   //		JDFNode onlineContentJDF = null;
   //
   //		final JDFAttributeMap mARes = new JDFAttributeMap("HDM:SequenceType", "*");
   //		VElement vSequences = root.getChildElementVector(ElementName.JDF, null, mARes, true, 0, false);
   //		Iterator vSequenceIterator = vSequences.iterator();
   //		
   //		while (vSequenceIterator.hasNext() && onlineContentJDF == null) {
   //			JDFNode qualifyNode = (JDFNode) vSequenceIterator.next();
   //			
   //			// don't use qualifyNode with "HDM:Visibility=false"
   //			if (!"false".equals(qualifyNode.getAttribute("HDM:Visibility"))) {
   //				JDFAttributeMap mapToolType = new JDFAttributeMap("HDM:ToolType", "OnlineContent");
   //				mapToolType.put("Type", "HDM:CS");
   //				VElement vOnlineContent = qualifyNode.getChildElementVector(ElementName.JDF, null, mapToolType, true, 0, false);
   //				
   //				Iterator vOnlineContentIterator = vOnlineContent.iterator();
   //				if (vOnlineContentIterator.hasNext()) {
   //					// the first onlineContentJDF is the one we use
   //					onlineContentJDF = (JDFNode) vOnlineContentIterator.next();
   //				}
   //			}
   //		}
   //		
   //		return onlineContentJDF;
   //	}
   //
   //	/**
   //	 * 
   //	 * @param root
   //	 * @return value of the attribute "ContentJobHomeTemplate" in resource "CSParams" 
   //	 * 		   or null if resource or attribute not found
   //	 */
   //	private String getContentJobHomeTemplate(JDFNode root) {
   //		final String resourceName   = "CSParams";
   //		final String attributeName  = "ContentJobHomeTemplate";
   //		JDFResource resource = getFirstLinkedResource(root, resourceName, attributeName);
   //		return resource == null
   //						? null
   //						: resource.getAttribute(attributeName);
   //	}
   //
   //	/**
   //	 * get first resource resourceName with attribute attributeName from ResourceLinkPool, null if not found
   //	 */
   //	private JDFResource getFirstLinkedResource(
   //			JDFNode root, final String resourceName, final String attributeName) {
   //		JDFResource resource    = null;
   //		
   //		JDFResourceLinkPool rlp = root.getResourceLinkPool();
   //		if (rlp != null) {
   //			final JDFAttributeMap mARes = new JDFAttributeMap(attributeName, "*");
   //			VElement vResources = rlp.getLinkedResources(resourceName, null, mARes, false);
   //			
   //			Iterator vResourceIterator = vResources.iterator();
   //			if (vResourceIterator.hasNext()) {
   //				resource = (JDFResource) vResourceIterator.next();
   //			}
   //		}
   //		
   //		return resource;
   //	}

   // public void testhasAttribute()
   //    {
   //        /*
   //        <HDM:AutoSheetParams xmlns:HDM="www.heidelberg.com/schema/HDM"
   //            HDM:Granularity="Sheet" HDM:KeepAsOneSubJob="false"
   //            HDM:LayoutApproval="false" HDM:PageApproval="false"/>
   //
   //        liefert der Aufruf von KElement.hasAttribute("Granularity") true zurück.
   //        */
   //        XMLDoc xd=new XMLDoc("HDM:AutoSheetParams","www.heidelberg.com/schema/HDM");
   //        KElement root=xd.getRoot();
   //        
   //        root.setAttribute("HDM:Granularity","Sheet");
   //        root.setAttribute("HDM:KeepAsOneSubJob","false");
   //        root.setAttribute("HDM:LayoutApproval","false");
   //        root.setAttribute("HDM:PageApproval","false");
   //        
   //        assertFalse(root.hasAttribute("Granularity"));
   //    }

   //  public void test_getElementById_parseFile()
   //  {
   //	  final String dataDir = "D:\\Documents and Settings\\muchadie\\Desktop\\DTS\\BeineckeJDF's\\";
   //	  String data1 = "(L)  Broschüren 28 Seiten(06-5629).jdf";
   //	  String data2 = "(S) DD Umschläge für Weihnachtskarte(06-6160).jdf";
   //	  String data3 = "Remote Access Testbroschüre(06-5443).jdf";
   //	  String data4 = "Weihnachtskarte(06-6023).jdf";
   //	  String data5 = "Zahnarzt Selbstsicherheit 1003_10074(07-0172).jdf";
   //      final JDFParser parser = new JDFParser();
   //      JDFDoc jdfDoc = parser.parseFile(dataDir+data1);
   //      JDFNode root = (JDFNode) jdfDoc.getRoot();
   //      JDFCustomerInfo customer = root.getCustomerInfo();
   //      customer.inlineRefElements(null, null, false);
   //    
   //      System.out.println(customer.toXML());
   //
   //      jdfDoc = parser.parseFile(dataDir+data2);
   //      root = (JDFNode) jdfDoc.getRoot();
   //      customer = root.getCustomerInfo();
   //      customer.inlineRefElements(null, null, false);
   //    
   //      System.out.println(customer.toXML());
   //
   //      jdfDoc = parser.parseFile(dataDir+data3);
   //      root = (JDFNode) jdfDoc.getRoot();
   //      customer = root.getCustomerInfo();
   //      customer.inlineRefElements(null, null, false);
   //    
   //      System.out.println(customer.toXML());
   //
   //      jdfDoc = parser.parseFile(dataDir+data4);
   //      root = (JDFNode) jdfDoc.getRoot();
   //      customer = root.getCustomerInfo();
   //      customer.inlineRefElements(null, null, false);
   //    
   //      System.out.println(customer.toXML());
   //
   //      jdfDoc = parser.parseFile(dataDir+data5);
   //      root = (JDFNode) jdfDoc.getRoot();
   //      customer = root.getCustomerInfo();
   //      customer.inlineRefElements(null, null, false);
   //    
   //      System.out.println(customer.toXML());
   //  }

   //    /**
   //     * write2String - write to a string; 
   //     *
   //     * @param indent the indentation of the xml
   //     *
   //     * @return String - output 
   //     */
   //    public String write2String(Document doc)
   //    {
   //        String strResult = "";
   //        ByteArrayOutputStream outStream = null;
   //        
   //        try
   //        {
   //            outStream = new ByteArrayOutputStream(4096);
   //            final OutputFormat format = new OutputFormat(doc);
   //            format.setPreserveSpace(true);
   //            format.setIndenting(false);
   //            
   //            final XMLSerializer serial = new XMLSerializer(outStream, format);
   //            serial.setNamespaces(true);    
   //            serial.asDOMSerializer();
   //            
   //            serial.serialize(doc);
   //            strResult = outStream.toString("UTF-8");
   //        }
   //        catch (IOException e)
   //        {
   //            System.out.println(
   //                "write2String: " + ((outStream != null) ? outStream.toString() : "") 
   //                                 + " : " + e);
   //        }
   //        finally
   //        {
   //            if (outStream != null)
   //            {
   //                try
   //                {
   //                    outStream.close();
   //                }
   //                catch (IOException e1)
   //                {
   //                    e1.printStackTrace();
   //                }
   //            } 
   //        }
   //        
   //        return strResult;
   //    }

   //    public void testSpawn3()
   //    {
   //        String jmfString = "<JMF ID=\"97034401_000050\" " +
   //                               "SenderID=\"My SenderID\" TimeStamp=\"2006-10-09T14:30:34+02:00\" " +
   //                               "Version=\"1.2\">" +
   //                                   "<Query ID=\"97123127_000025\" Type=\"Product\">" + 
   //                                   "</Query>" +
   //                           "</JMF>";
   //
   //        JDFDoc jdfDoc = new JDFParser().parseString(jmfString);
   //        JDFJMF msg = jdfDoc.getJMFRoot();
   //
   //        
   //        JDFQuery query = (JDFQuery) msg.getMessageElement(JDFMessage.EnumFamily.Query, null, 0);
   //        
   ////      query contains user defined type
   //        String myNewType = query.getType();
   //
   ////      use any defined type to create the response
   //        JDFResponse response = msg.appendResponse ();
   //
   ////      now switch the response type to the above mentioned user type
   //        response.setType(myNewType );
   //        
   //        
   //        String fileNameIn            = "km2";
   //
   //        JDFParser p = new JDFParser();
   //        JDFDoc jdfDocIn = p.parseFile(sm_dirTestData+fileNameIn+".jdf");
   //
   //        JDFNode root   = jdfDocIn.getJDFRoot();
   //        JDFNode subJob = root.getJobPart("Qua0", null); //Link08539766_000147
   //        VElement v = subJob.getChildElementVector("JDF", null, new JDFAttributeMap(), false, Integer.MAX_VALUE,false);
   //        VElement v2 = new VElement();
   //        
   //        for(int i = 0; i < v.size(); i++)
   //        {
   //            JDFNode spawnNode = (JDFNode)v.elementAt(i);
   //            spawnNode.getCreateAuditPool().addEvent("me",EnumSeverity.Event);
   //            spawnNode.appendComment().setText("Comment"+String.valueOf(i));
   //            final JDFSpawn spawn=new JDFSpawn(spawnNode);
   //            JDFNode spawnedNode = spawn.spawn(sm_dirTestData + fileNameIn + ".jdf",null,null,null,false,true,true,true);
   //            v2.add(spawnedNode);
   //        }
   //    }

   //  public void test_getElementById_parseFile()
   //  {
   //      final JDFParser parser = new JDFParser();
   //      JDFDoc jdfDoc = parser.parseFile("test.txt");
   //      KElement root = jdfDoc.getRoot();
   //    
   //      KElement kElem, kElem2;
   //      kElem = root.getTarget("Link08539836_000152", null);
   //      System.out.println();
   //  }

   //  public void test_getElementById_parseString()
   //  {
   //      String xmlString =   "<JDF ID=\"Link20704459_000351\">" +
   //                                  "<ELEM2 ID=\"Link20704459_000352\">" + 
   //                                      "<ELEM3 ID=\"Link20704459_000353\">" +
   //                                            "<Comment/>" +
   //                                      "</ELEM3>" + 
   //                                  "</ELEM2>" +
   //                           "</JDF>";
   //    
   //      final JDFParser parser = new JDFParser();
   //      parser.m_SchemaLocation = new FileInfo(sm_dirTestSchema + "JDF.xsd").toURI().toString();
   //      JDFDoc jdfDoc = parser.parseString(xmlString);
   //      KElement root = jdfDoc.getRoot();
   //    
   //      KElement kElem, kElem2;
   //      
   //      // alt funktioniert
   //      kElem2 = root.getTarget("Link20704459_000351", AttributeName.ID);
   //      assertNotNull(kElem2);
   //      
   //      // neu funktioniert nicht - http://mail-archives.apache.org/mod_mbox/xerces-j-users/200410.mbox/%3c4178694B.40708@metalab.unc.edu%3e
   //      // http://www.stylusstudio.com/xmldev/200012/post80000.html
   //      kElem = (KElement) jdfDoc.getElementById("Link20704459_000351");
   //      assertNotNull(kElem);
   //      
   //      // alt funktioniert
   //      kElem2 = root.getTarget("Link20704459_000352", AttributeName.ID);
   //      assertNotNull(kElem2);
   //
   //      // neu funktioniert nicht
   //      kElem = (KElement) jdfDoc.getElementById("Link20704459_000352");
   //      assertNotNull(kElem);
   //      
   //      // alt funktioniert
   //      kElem2 = root.getTarget("Link20704459_000353", AttributeName.ID);
   //      assertNotNull(kElem2);
   //
   //      // neu funktioniert nicht
   //      kElem = (KElement) jdfDoc.getElementById("Link20704459_000353");
   //      assertNotNull(kElem);
   //  }

   //  public void test_getElementById_parseFile()
   //  {
   //      final JDFParser parser = new JDFParser();
   //      JDFDoc jdfDoc = parser.parseFile("\\Job1.jdf");
   //      KElement root = jdfDoc.getRoot();
   //    
   //      KElement kElem, kElem2;
   //      
   //      // alt funktioniert
   //      kElem2 = root.getTarget("Link20704459_000351", AttributeName.ID);
   //      assertNotNull(kElem2);
   //
   //      // neu funktioniert nicht
   //      kElem = (KElement) jdfDoc.getElementById("Link20704459_000351");
   //      assertNotNull(kElem);
   //      
   //      
   //      kElem = (KElement) jdfDoc.getElementById("Link20704459_000352");
   //      assertNotNull(kElem);
   //      kElem2 = root.getTarget("Link20704459_000352", AttributeName.ID);
   //      assertNotNull(kElem2);
   //      
   //      kElem = (KElement) jdfDoc.getElementById("Link20704459_000353");
   //      assertNotNull(kElem);
   //      kElem2 = root.getTarget("Link20704459_000353", AttributeName.ID);
   //      assertNotNull(kElem2);
   //  }

   //    public void testShowNameSpaceBugJMF_JDFDoc()
   //    {
   //        JDFDoc jdfDoc = new JDFDoc(ElementName.JMF);
   //
   //        JDFJMF jmf = jdfDoc.getJMFRoot();
   //        System.out.println(jmf.toXML());
   //        assertEquals(jmf.getNamespaceURI(), "http://www.CIP4.org/JDFSchema_1_1");
   //        
   ////        ElementNSImpl elem = jmf;
   ////        assertEquals(elem.getNamespaceURI(), "http://www.CIP4.org/JDFSchema_1_1");
   //    }
   //
   //    public void testShowNameSpaceBugJMF_parse()
   //    {
   //        JDFDoc jdfDoc = new JDFParser().parseString("<JMF > </JMF>");
   //        
   //        JDFJMF jmf = jdfDoc.getJMFRoot();
   //        System.out.println(jmf.toXML());
   //        assertEquals(jmf.getNamespaceURI(), "http://www.CIP4.org/JDFSchema_1_1");
   //    }
   //    
   //    public void testShowNameSpaceBugJDF_JDFDoc()
   //    {
   //        JDFDoc jdfDoc = new JDFDoc(ElementName.JDF);
   //
   //        JDFNode jdf = jdfDoc.getJDFRoot();
   //        System.out.println(jdf.toXML());
   //        assertEquals(jdf.getNamespaceURI(), "http://www.CIP4.org/JDFSchema_1_1");
   //    }
   //
   //    public void testShowNameSpaceBugJDF_parse()
   //    {
   //        JDFDoc jdfDoc = new JDFParser().parseString("<JDF > </JDF>");
   //        
   //        JDFNode jdf = jdfDoc.getJDFRoot();
   //        System.out.println(jdf.toXML());
   //        assertEquals(jdf.getNamespaceURI(), "http://www.CIP4.org/JDFSchema_1_1");
   //    }

   //    public void testNameSpace()
   //  {
   ////      JDFDoc jdfDoc = new JDFParser().parseFile("\\JDFNamespaceTest.jmf");
   //
   ////      String jmfString =   "<JMF xmlns=\"http://www.CIP4.org/JDFSchema_1_1\" ID=\"97034401_000050\" " +
   ////      "SenderID=\"My SenderID\" TimeStamp=\"2006-10-09T14:30:34+02:00\" " +
   ////      "Version=\"1.2\">" +
   ////        "<Command ID=\"97123127_000025\" Type=\"Product\">" + 
   ////            "<JDF ID=\"97133910_000025\" Type=\"Product\">" +
   ////                  "<Comment/>" +
   ////            "</JDF>" + 
   ////        "</Command>" +
   ////    "</JMF>";
   //      String jmfString =   "<JMF ID=\"97034401_000050\" " +
   //                             "SenderID=\"My SenderID\" TimeStamp=\"2006-10-09T14:30:34+02:00\" " +
   //                             "Version=\"1.2\">" +
   //                               "<Command ID=\"97123127_000025\" Type=\"Product\">" + 
   //                                   "<JDF ID=\"97133910_000025\" Type=\"Product\">" +
   //                                         "<Comment/>" +
   //                                   "</JDF>" + 
   //                               "</Command>" +
   //                           "</JMF>";
   //      
   //      JDFDoc jdfDoc = new JDFParser().parseString(jmfString);
   //      JDFJMF jmf = jdfDoc.getJMFRoot();
   //
   //      assertNotNull(jmf);
   //      assertEquals(jmf.getNamespaceURI(), "http://www.CIP4.org/JDFSchema_1_1");
   //
   //      JDFElement jdfElem = 
   //          (JDFElement) jmf.getChildByTagName(ElementName.JDF, null, 0, null, false, true);
   //      
   //      assertNotNull(jdfElem);
   //      assertEquals(jdfElem.getNamespaceURI(), "http://www.CIP4.org/JDFSchema_1_1");
   //
   //      final DocumentJDFImpl jdfDocOut = new DocumentJDFImpl();
   //      final JDFNode importNode = (JDFNode) jdfDocOut.importNode(jdfElem, true);
   //      JDFNode jdfNode = (JDFNode) jdfDocOut.appendChild(importNode);
   //      
   //      assertEquals(jdfNode.getNamespaceURI(), "http://www.CIP4.org/JDFSchema_1_1");
   //
   ////      assertTrue(jdfDocOut.write2File("\\JDFNamespaceTestOut.jmf", 0, false));
   //      System.out.println(jdfNode.toXML());
   //  }
   }

}