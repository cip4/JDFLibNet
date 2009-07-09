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
 * JDFExampleDocTest.cs
 * @author muchadie
 */

namespace org.cip4.jdflib.examples
{
   using System;
   using System.Collections;
   using System.Collections.Generic;
   using Microsoft.VisualStudio.TestTools.UnitTesting;


   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using EnumOrder = org.cip4.jdflib.auto.JDFAutoAssembly.EnumOrder;
   using EnumMediaType = org.cip4.jdflib.auto.JDFAutoMedia.EnumMediaType;
   using EnumMediaUnit = org.cip4.jdflib.auto.JDFAutoMedia.EnumMediaUnit;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFNodeInfo = org.cip4.jdflib.core.JDFNodeInfo;
   using JDFParser = org.cip4.jdflib.core.JDFParser;
   using JDFPartAmount = org.cip4.jdflib.core.JDFPartAmount;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using JDFIntegerList = org.cip4.jdflib.datatypes.JDFIntegerList;
   using JDFIntegerRangeList = org.cip4.jdflib.datatypes.JDFIntegerRangeList;
   using JDFMatrix = org.cip4.jdflib.datatypes.JDFMatrix;
   using JDFRectangle = org.cip4.jdflib.datatypes.JDFRectangle;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFDeviceFilter = org.cip4.jdflib.jmf.JDFDeviceFilter;
   using JDFDeviceInfo = org.cip4.jdflib.jmf.JDFDeviceInfo;
   using JDFJMF = org.cip4.jdflib.jmf.JDFJMF;
   using JDFMessage = org.cip4.jdflib.jmf.JDFMessage;
   using JDFQuery = org.cip4.jdflib.jmf.JDFQuery;
   using JDFRegistration = org.cip4.jdflib.jmf.JDFRegistration;
   using JDFResourceCmdParams = org.cip4.jdflib.jmf.JDFResourceCmdParams;
   using JDFResponse = org.cip4.jdflib.jmf.JDFResponse;
   using EnumFamily = org.cip4.jdflib.jmf.JDFMessage.EnumFamily;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using EnumProcessUsage = org.cip4.jdflib.node.JDFNode.EnumProcessUsage;
   using EnumType = org.cip4.jdflib.node.JDFNode.EnumType;
   using JDFAmountPool = org.cip4.jdflib.pool.JDFAmountPool;
   using JDFAuditPool = org.cip4.jdflib.pool.JDFAuditPool;
   using JDFDevice = org.cip4.jdflib.resource.JDFDevice;
   using JDFDeviceList = org.cip4.jdflib.resource.JDFDeviceList;
   using JDFLaminatingParams = org.cip4.jdflib.resource.JDFLaminatingParams;
   using JDFMarkObject = org.cip4.jdflib.resource.JDFMarkObject;
   using JDFNotification = org.cip4.jdflib.resource.JDFNotification;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFResourceAudit = org.cip4.jdflib.resource.JDFResourceAudit;
   using JDFShapeCuttingParams = org.cip4.jdflib.resource.JDFShapeCuttingParams;
   using JDFSignature = org.cip4.jdflib.resource.JDFSignature;
   using JDFStrippingParams = org.cip4.jdflib.resource.JDFStrippingParams;
   using EnumPartIDKey = org.cip4.jdflib.resource.JDFResource.EnumPartIDKey;
   using EnumPartUsage = org.cip4.jdflib.resource.JDFResource.EnumPartUsage;
   using EnumResStatus = org.cip4.jdflib.resource.JDFResource.EnumResStatus;
   using JDFArtDelivery = org.cip4.jdflib.resource.intent.JDFArtDelivery;
   using JDFArtDeliveryIntent = org.cip4.jdflib.resource.intent.JDFArtDeliveryIntent;
   using JDFLayoutIntent = org.cip4.jdflib.resource.intent.JDFLayoutIntent;
   using JDFAssembly = org.cip4.jdflib.resource.process.JDFAssembly;
   using JDFBinderySignature = org.cip4.jdflib.resource.process.JDFBinderySignature;
   using JDFColorantControl = org.cip4.jdflib.resource.process.JDFColorantControl;
   using JDFComponent = org.cip4.jdflib.resource.process.JDFComponent;
   using JDFContentObject = org.cip4.jdflib.resource.process.JDFContentObject;
   using JDFConventionalPrintingParams = org.cip4.jdflib.resource.process.JDFConventionalPrintingParams;
   using JDFCostCenter = org.cip4.jdflib.resource.process.JDFCostCenter;
   using JDFDigitalPrintingParams = org.cip4.jdflib.resource.process.JDFDigitalPrintingParams;
   using JDFExposedMedia = org.cip4.jdflib.resource.process.JDFExposedMedia;
   using JDFFileSpec = org.cip4.jdflib.resource.process.JDFFileSpec;
   using JDFLayout = org.cip4.jdflib.resource.process.JDFLayout;
   using JDFLayoutElement = org.cip4.jdflib.resource.process.JDFLayoutElement;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;
   using JDFPosition = org.cip4.jdflib.resource.process.JDFPosition;
   using JDFRunList = org.cip4.jdflib.resource.process.JDFRunList;
   using JDFSurface = org.cip4.jdflib.resource.process.JDFSurface;
   using JDFSheet = org.cip4.jdflib.resource.process.postpress.JDFSheet;
   using JDFIntegerSpan = org.cip4.jdflib.span.JDFIntegerSpan;
   using JDFXYPairSpan = org.cip4.jdflib.span.JDFXYPairSpan;
   using MyArgs = org.cip4.jdflib.util.MyArgs;
   using StringUtil = org.cip4.jdflib.util.StringUtil;
   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   ///
   /// <summary> * some simple examples
   /// * @author Rainer Prosi, Heidelberger Druckmaschinen
   /// * </summary>
   /// 
   [TestClass]
   public class JDFExampleDocTest : JDFTestCaseBase
   {
      private JDFDoc m_doc = null;

      ///   
      ///	 <summary> * a simple generic main routine for a dumb console app
      ///	 * 
      ///	 * switches: -a: actions to perform - DoAll calls all test programs -i input
      ///	 * JDF file -o output JDF FileInfo
      ///	 *  </summary>
      ///	 
      [TestMethod]
      public virtual void testAll()
      {
         string[] argV = new string[0];

         // trivial argument handling
         MyArgs args = new MyArgs(argV, "", "aio", null);

         if (argV.Length > 1 && argV[1].Equals("-?"))
         {
            // Watch for special case help request
            string usage = "JDFExample; example usages of the JDF Library\n" + "Arguments: -a: actions to perform \n" + "           -i input JDF file\n" + "           -o output JDF FileInfo\n";

            Console.WriteLine(args.usage(usage));
            return;
         }

         // setup indentation for the output - 2 blanks/level

         // get action, input and output settings from the command line
         string action = args.parameter('a');
         if (action == null || action.Equals(JDFConstants.EMPTYSTRING))
         {
            action = "DoAll";
         }

         // JMF
         // document
         // root
         string strDocType = action.EndsWith("Message") ? ElementName.JMF : ElementName.JDF; // 0 = JDF document root

         // use JDFExampleDoc as a container that holds the various example
         // routines
         doExample(strDocType, action, args.parameter('i'), args.parameter('o'));
      }

      ///   
      ///	 <summary> * dispatcher to the individual example tasks
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            action the routine to call </param>
      ///	 * <param name="String">
      ///	 *            infile name of the input JDF file to parse </param>
      ///	 * <param name="String">
      ///	 *            outfile name of the output JDF file to write </param>
      ///	 * <returns> >=0 if successful </returns>
      ///	 
      public virtual int doExample(string strDocType, string action, string inFile, string outFile)
      {
         JDFParser p = new JDFParser();
         JDFElement root = null;

         // parse the input, if it exists
         if (inFile != null && !inFile.Equals(JDFConstants.EMPTYSTRING))
         {
            m_doc = p.parseFile(sm_dirTestDataTemp + inFile);
            root = (JDFElement)m_doc.getRoot();
         }
         else
         { // clean root if it was not parsed
            m_doc = new JDFDoc(strDocType);
            root = (JDFElement)m_doc.getRoot();
         }

         int iReturn = -1;
         try
         {
            // select subroutine depending on action
            if (action.Equals("CreateSimple"))
            {
               iReturn = createSimple();
            }
            else if (action.Equals("CreateBrochure"))
            {
               iReturn = createBrochure();
            }
            else if (action.Equals("CreateRIP"))
            {
               iReturn = createRIP();
            }
            else if (action.Equals("Reprint"))
            {
               iReturn = reprint();
            }
            else if (action.Equals("CreateDigitalPrinting"))
            {
               iReturn = createDigitalPrinting();
            }
            else if (action.Equals("CreateNarrowWeb"))
            {
               iReturn = createNarrowWeb();
            }
            else if (action.Equals("CreateImposition"))
            {
               iReturn = createImposition();
            }
            else if (action.Equals("ParseNodes"))
            {
               iReturn = parseNodes();
            }
            else if (action.Equals("DoRunList"))
            {
               iReturn = doRunList();
            }
            else if (action.Equals("DoAudit"))
            {
               iReturn = doAudit();
            }
            else if (action.Equals("DoValid"))
            {
               iReturn = doValid();
            }
            else if (action.Equals("ProcessMessage"))
            {
               iReturn = processMessage(writeMessage());
            }
            else if (action.Equals("DoAll"))
            {
               iReturn = doAll();
            }
            else
            {
               // oops we don't know this one
               Console.WriteLine("JDFExampleDoc: unknown action " + action);
               return -1;
            }

         }
         catch (JDFException e)
         {
            Console.WriteLine("Caught a JDF exception :" + e.Message);
         }

         // write to output if requested
         if (outFile != null && !outFile.Equals(""))
         {
            // remove whitespace only nodes before writing
            root.eraseEmptyNodes(true);
            // remove any existing output file prior to overwriting
            // #dm# remove(outFile);
            // write the output file
            m_doc.write2File(sm_dirTestDataTemp + outFile, 0, true);
         }
         else
         {
            // no output file -> Send to console
            Console.WriteLine(">>>>>>>>>>>>>>> output of " + action);
            Console.WriteLine(this);
         }

         return iReturn;
      }


      ///   
      ///	 <summary> * Example 0: call all other examples </summary>
      ///	 
      private int doAll()
      {
         doExample(ElementName.JDF, "CreateSimple", "", "Simple.jdf");
         doExample(ElementName.JDF, "CreateRIP", "", "RIP.jdf");
         doExample(ElementName.JDF, "Reprint", "RIP.jdf", "Reprint.jdf");
         doExample(ElementName.JDF, "CreateBrochure", "", "Brochure.jdf");
         doExample(ElementName.JDF, "ParseNodes", "Brochure.jdf", "");
         doExample(ElementName.JDF, "DoRunList", "", "RunList.jdf");
         doExample(ElementName.JDF, "DoAudit", "RunList.jdf", "RunlistAudit.jdf");
         doExample(ElementName.JDF, "DoValid", "RunList.jdf", "");
         doExample(ElementName.JDF, "CreateImposition", "", "Impose.jdf");
         doExample(ElementName.JDF, "CreateDigitalPrinting", "", "DigitalPrinting.jdf");
         doExample(ElementName.JDF, "CreateNarrowWeb", "", "NarrowWeb.jdf");

         doExample(ElementName.JMF, "ProcessMessage", "", "ProcessMessage.jdf");

         return 0;
      }

      // the actual examples start here

      ///   
      ///	 <summary> * Example 1: create an incomplete product node for a simple 8.5 * 11
      ///	 * brochure from scratch </summary>
      ///	 
      private int createSimple()
      {
         // get the JDF document root element
         JDFNode productNode = (JDFNode)m_doc.getRoot();
         productNode.setType(JDFNode.EnumType.Product.getName(), false);

         // Add an intent resource
         JDFLayoutIntent layoutIntent = (JDFLayoutIntent)productNode.appendMatchingResource(ElementName.LAYOUTINTENT, JDFNode.EnumProcessUsage.AnyInput, null);

         // set the type attribute
         try
         {
            layoutIntent.setPageNumber(new JDFIntegerRangeList("4"));
         }
         catch (FormatException)
         {
            // nop is ok
         }

         // set some span elements in the intent resource
         JDFIntegerSpan pages = layoutIntent.appendPages();
         pages.setPreferred(16);

         JDFXYPairSpan dimensions = layoutIntent.appendDimensions();
         dimensions.setPreferred(8.5 * 72.0, 11.0 * 72.0);

         return 1;
      }

      ///   
      ///	 <summary> * Example 2: create a brochure structure with cover and insert from scratch </summary>
      ///	 

      private int createBrochure()
      {
         // set up the root process
         JDFNode root = (JDFNode)m_doc.getRoot();
         JDFNode productNode = root;
         productNode.setType(JDFNode.EnumType.Product.getName(), false);

         productNode.setJobPartID("Part1");
         // define the complete output component (false -> Usage=output
         JDFComponent compBrochure = (JDFComponent)productNode.appendMatchingResource(ElementName.COMPONENT, JDFNode.EnumProcessUsage.AnyOutput, null);
         List<ValuedEnum> vComType = new List<ValuedEnum>();
         vComType.Add(JDFComponent.EnumComponentType.FinalProduct);
         compBrochure.setComponentType(vComType);
         compBrochure.setDescriptiveName("complete 16-page Brochure");
         // set the amount of the output component
         compBrochure.setAmount(10000);

         // you can now add all kinds of attributes to bindingIntent
         productNode.appendMatchingResource(ElementName.BINDINGINTENT, JDFNode.EnumProcessUsage.AnyInput, null);

         // add the component for the cover
         JDFNode prodCover = productNode.addProduct();
         prodCover.setDescriptiveName("Cover");
         prodCover.setJobPartID("Part2");

         // Add a component for the cover that resides in the ResourceLinkPool of
         // productNode
         JDFComponent compCover = (JDFComponent)prodCover.appendMatchingResource(ElementName.COMPONENT, JDFNode.EnumProcessUsage.AnyOutput, productNode);

         compCover.setDescriptiveName("Cover Component");

         vComType = new List<ValuedEnum>();
         vComType.Add(JDFComponent.EnumComponentType.PartialProduct);
         compCover.setComponentType(vComType);

         // Add an ArtDeliveryIntent to define the input files for the cover
         JDFArtDeliveryIntent artDeliveryIntent = (JDFArtDeliveryIntent)prodCover.appendMatchingResource(ElementName.ARTDELIVERYINTENT, JDFNode.EnumProcessUsage.AnyInput, null);

         JDFArtDelivery artDeliveryCover = artDeliveryIntent.appendArtDelivery();
         artDeliveryCover.setArtDeliveryType("DigitalNetwork");

         JDFRunList runListCover = artDeliveryCover.appendRunList();
         JDFFileSpec fileSpec = runListCover.appendLayoutElement().appendFileSpec();
         fileSpec.setURL("FileInfo:./cover.pdf");
         fileSpec.setApplication("Acrobat");

         // link the cover to the brochure node as input
         productNode.linkMatchingResource(compCover, JDFNode.EnumProcessUsage.AnyInput, new JDFAttributeMap());

         JDFLayoutIntent layoutIntent = (JDFLayoutIntent)prodCover.appendMatchingResource(ElementName.LAYOUTINTENT, JDFNode.EnumProcessUsage.AnyInput, null);

         layoutIntent.setNumberUp(new JDFXYPair(1, 1));
         layoutIntent.setSides(JDFLayoutIntent.EnumSides.OneSided);

         prodCover.appendMatchingResource(ElementName.COLORINTENT, JDFNode.EnumProcessUsage.AnyInput, null);

         // Add a component for the insert that resides in the ResourceLinkPool
         // of productNode
         JDFNode prodInsert = productNode.addProduct();
         prodInsert.setDescriptiveName("Insert");
         prodInsert.setJobPartID("Part3");

         // link the insert to the brochure node as input
         JDFComponent compInsert = (JDFComponent)prodInsert.appendMatchingResource(ElementName.COMPONENT, JDFNode.EnumProcessUsage.AnyOutput, productNode);

         compInsert.setDescriptiveName("Insert Component");

         vComType = new List<ValuedEnum>();
         vComType.Add(JDFComponent.EnumComponentType.PartialProduct);
         compInsert.setComponentType(vComType);
         productNode.linkMatchingResource(compInsert, JDFNode.EnumProcessUsage.AnyInput, new JDFAttributeMap());

         // add some intent resources to be filled in later
         JDFLayoutIntent insertLayoutIntent = (JDFLayoutIntent)prodInsert.appendMatchingResource(ElementName.LAYOUTINTENT, JDFNode.EnumProcessUsage.AnyInput, null);

         insertLayoutIntent.setNumberUp(new JDFXYPair(1, 1));
         insertLayoutIntent.setSides(JDFLayoutIntent.EnumSides.TwoSidedHeadToHead);
         prodInsert.appendMatchingResource(ElementName.COLORINTENT, JDFNode.EnumProcessUsage.AnyInput, null);

         // Add an ArtDeliveryIntent to define the input files for the inser
         artDeliveryIntent = (JDFArtDeliveryIntent)prodInsert.appendMatchingResource(ElementName.ARTDELIVERYINTENT, JDFNode.EnumProcessUsage.AnyInput, null);

         JDFArtDelivery artDeliveryInsert = artDeliveryIntent.appendArtDelivery();

         artDeliveryInsert.setArtDeliveryType("DigitalNetwork");

         JDFRunList runListInsert = artDeliveryInsert.appendRunList();
         JDFFileSpec insertFileSpec = runListInsert.appendLayoutElement().appendFileSpec();
         insertFileSpec.setURL("FileInfo:./insert.pdf");
         insertFileSpec.setApplication("Acrobat");

         return 0;
      }

      ///   
      ///	 <summary> * Example 3: parse a JDF or PrintTalk and print the node type + ID
      ///	 *  </summary>
      ///	 

      private int parseNodes()
      {
         // set up the root process
         JDFNode root = (JDFNode)m_doc.getRoot();
         // get a vector of all JDF nodes
         VElement vNode = root.getvJDFNode(null, null, false);
         // print summary
         Console.WriteLine("ParseNodes found " + vNode.Count + " Nodes");
         // loop over all nodes and print
         for (int i = 0; i < vNode.Count; i++)
         {
            JDFNode node = (JDFNode)vNode[i];
            Console.WriteLine("JFD Node type: " + node.getType() + " ID:" + node.getID());
         }
         Console.WriteLine("end ParseNodes");

         return 0;
      }

      ///   
      ///	 <summary> * Example 4: create an Imposition process node with a runlist the Runlist
      ///	 * has various separated, combined and referenced files </summary>
      ///	 

      private int doRunList()
      {
         // set up the root process node, which is an imposition node
         JDFNode impositionNode = (JDFNode)m_doc.getRoot();
         impositionNode.setType(JDFNode.EnumType.Imposition.getName(), false);

         // add the runlist
         JDFRunList runList = (JDFRunList)impositionNode.appendMatchingResource(ElementName.RUNLIST, JDFNode.EnumProcessUsage.Document, null);

         // set Npage to 10
         runList.setNPage(10);

         // separation names
         string separationList = "Cyan Magenta Yellow Black SpotGreen";

         // runPart is used to reference the partitioned runlist leaves
         JDFRunList runPart = runList.addSepRun(StringUtil.tokenize("Cyan.pdf Magenta.pdf Yellow.pdf Black.pdf Green.pdf", " ", false), StringUtil.tokenize(separationList, " ", false), 0, 1, true);

         // add a JDF Comment
         runPart.insertAt("Comment", 0, "", JDFElement.getSchemaURL(), JDFElement.getSchemaURL()).appendText("Preseparated Runs in multiple files\nAll LayoutElements are inline resources");

         ArrayList v = new ArrayList();
         v.Add("PreSepCMYKG.pdf");
         // add a preseparated run
         runPart = runList.addSepRun(v, StringUtil.tokenize(separationList, " ", false), 0, 2, true);
         runPart.insertAt("Comment", 0, "", JDFElement.getSchemaURL(), JDFElement.getSchemaURL()).appendText("Preseparated Runs in one file CMYKGCMYKG\nLayoutElements are inter-resource links");

         runPart = runList.addSepRun(v, StringUtil.tokenize("Cyan Yellow Black Green", " ", false), 10, 1, true);

         runPart.insertAt("Comment", 0, "", JDFElement.getSchemaURL(), JDFElement.getSchemaURL()).appendText("No Magenta, the missing sep does not exist as a page");

         // add a preseparated run
         runPart = runList.addSepRun(v, StringUtil.tokenize(separationList, " ", false), 14, 2, true);
         runPart.insertAt("Comment", 0, "", JDFElement.getSchemaURL(), JDFElement.getSchemaURL()).appendText("Continuation of Preseparated Runs in one file CMYKGCMYKG - " + "the missing sep of the previous page does not exist as a page");

         v[0] = "PreSepCCMMYYKKGG.pdf";

         // add a preseparated run
         runPart = runList.addSepRun(v, StringUtil.tokenize(separationList, " ", false), 0, 2, false);
         runPart.insertAt("Comment", 0, "", JDFElement.getSchemaURL(), JDFElement.getSchemaURL()).appendText("Preseparated Runs in one file CCMMYYKKGG");

         runPart = runList.addRun("Combined.pdf", 0, 1);
         runPart.insertAt("Comment", 0, "", JDFElement.getSchemaURL(), JDFElement.getSchemaURL()).appendText("Combined Runs in one file ");

         return 0;

      }

      ///   
      ///	 <summary> * Example 5: parse a JDF and simulate processing it also add some audit
      ///	 * elements
      ///	 *  </summary>
      ///	 

      private int doAudit()
      {
         // set up the root process
         JDFNode root = (JDFNode)m_doc.getRoot();

         // get the node audit pool
         JDFAuditPool auditPool = root.getAuditPool();

         // / do something between these calls
         auditPool.setPhase(JDFElement.EnumNodeStatus.Setup, null, null, null);
         auditPool.setPhase(JDFElement.EnumNodeStatus.InProgress, null, null, null);
         auditPool.setPhase(JDFElement.EnumNodeStatus.InProgress, null, null, null);
         auditPool.setPhase(JDFElement.EnumNodeStatus.Cleanup, null, null, null);
         Assert.AreEqual(3, auditPool.getPoolChildren("PhaseTime", null).Count);

         // get the input runlist
         VElement inOutLinks = root.getResourceLinkPool().getInOutLinks(EnumUsage.Input, false, "RunList", null);
         if (inOutLinks != null)
         {
            JDFRunList rl = (JDFRunList)inOutLinks[0];

            // pretend that cleanup modifies a resource and create a
            // ResourceAudit
            JDFResourceAudit resourceAudit = auditPool.addResourceAudit("");
            resourceAudit.addNewOldLink(true, rl, EnumUsage.Input);
            resourceAudit.setContentsModified(true);
            auditPool.setPhase(JDFElement.EnumNodeStatus.Completed, null, null, null);

            // / fill the processrun
            auditPool.addProcessRun(JDFElement.EnumNodeStatus.Completed, null, null);
         }

         return 0;
      }

      ///   
      ///	 <summary> * Example 6: parse a JDF and validate the runlist
      ///	 *  </summary>
      ///	 

      private int doValid()
      {
         Console.WriteLine("start DoValid");
         // set up the root process
         JDFNode root = (JDFNode)m_doc.getRoot();

         VElement inOutLinks = root.getResourceLinkPool().getInOutLinks(EnumUsage.Input, false, "RunList", null);
         if (inOutLinks != null)
         {
            // get the input runlist
            JDFRunList rl = (JDFRunList)inOutLinks[0];

            // is the Runlist Valid?
            bool bValid = rl.isValid(KElement.EnumValidationLevel.Complete);

            // print out validity information
            Console.WriteLine("DoValid runlist is " + (bValid ? "" : "in") + "valid !");

            // cross check with an artificially invalidated runlist
            rl.setAttribute("InvalidAttribute", "Something really Invalid", "");

            // recheck
            bValid = rl.isValid(KElement.EnumValidationLevel.Complete);

            // print out new validity information
            Console.WriteLine("DoValid runlist is " + (bValid ? "" : "in") + "valid !");
            Console.WriteLine("the following attributes are inValid: ");

            // get the vector of invalid attributes
            VString vInvalidAttributes = rl.getInvalidAttributes(KElement.EnumValidationLevel.Complete, true, 9999999);

            // print out the details
            for (int i = 0; i < vInvalidAttributes.Count; i++)
            {
               Console.WriteLine("key: " + vInvalidAttributes[i] + " value: " + rl.getAttribute((string)vInvalidAttributes[i], "", ""));
            }

            Console.WriteLine("end DoValid");
         }

         return 0;
      }

      ///   
      ///	 <summary> * Example 7:create an imposition node from from scratch </summary>
      ///	 

      private int createImposition()
      {
         // set up the root process node, which is an imposition node
         JDFNode impositionNode = (JDFNode)m_doc.getRoot();
         impositionNode.setType(JDFNode.EnumType.Imposition.getName(), false);

         // add the appropriate resources
         JDFLayout layout = (JDFLayout)impositionNode.appendMatchingResource(ElementName.LAYOUT, JDFNode.EnumProcessUsage.AnyInput, null);
         JDFSignature signature = layout.appendSignature();
         JDFSheet sheet = signature.appendSheet();

         // set the surfac contents box
         try
         {
            sheet.setSurfaceContentsBox(new JDFRectangle("0.0 0.0 1842.5197 1417.322800"));
         }
         catch (FormatException)
         {
            // add exception handling here
         }

         // Add the front Surface
         JDFSurface surface = sheet.appendFrontSurface();

         // append a markobject and set some default values
         JDFMarkObject markObject = surface.appendMarkObject();

         try
         {
            markObject.setCTM(new JDFMatrix("1 0 0 1 0 0"));
         }
         catch (FormatException)
         {
            // add exception handling here
         }
         markObject.setOrd(0);

         // append a contentobject
         JDFContentObject contentObject = surface.appendContentObject();

         try
         {
            contentObject.setCTM(new JDFMatrix("1 0 0 1 0 0"));
         }
         catch (FormatException)
         {
            // add exception handling here
         }

         contentObject.setOrd(0);

         // add the document runlist
         JDFRunList docList = (JDFRunList)impositionNode.appendMatchingResource(ElementName.RUNLIST, JDFNode.EnumProcessUsage.Document, null);
         docList.addRun("Document1.pdf", 0, -1);

         docList.addRun("Document2.pdf", 0, -1);

         // separation names
         string separationList = "Cyan Magenta Yellow Black";
         // runPart is used to reference the partitioned runlist leaves
         docList.addSepRun(StringUtil.tokenize("Cyan.pdf Magenta.pdf Yellow.pdf Black.pdf", " ", false), StringUtil.tokenize(separationList, " ", false), 0, 1, true);

         // add the marks runlist
         JDFRunList markList = (JDFRunList)impositionNode.appendMatchingResource(ElementName.RUNLIST, JDFNode.EnumProcessUsage.Marks, null);

         // Append a LayoutElement to the marks runlist
         JDFLayoutElement markle = markList.appendLayoutElement();
         // Append a FileSpec to the marks LayoutElement
         JDFFileSpec markfilespec = markle.appendFileSpec();
         // set some parameters
         markfilespec.setURL("marks.pdf");

         // add the output runlist
         JDFRunList outList = (JDFRunList)impositionNode.appendMatchingResource(ElementName.RUNLIST, JDFNode.EnumProcessUsage.AnyOutput, null);

         // Append a LayoutElement to the output runlist
         JDFLayoutElement outle = outList.appendLayoutElement();
         // Append a FileSpec to the output LayoutElement
         JDFFileSpec outfilespec = outle.appendFileSpec();
         // set some parameters
         outfilespec.setURL("output.pdf");

         // append an empty generic ApprovalSuccess
         impositionNode.appendMatchingResource(ElementName.APPROVALSUCCESS, JDFNode.EnumProcessUsage.AnyInput, null);

         return 0;

      }

      ///   
      ///	 <summary> * Example 7.5: create an combined RIP node for from scratch </summary>
      ///	 
      private int createRIP()
      {

         // get the JDF document root element
         JDFNode ripNode = (JDFNode)m_doc.getRoot();

         VString vTypes = new VString();
         vTypes.setAllStrings("Interpreting Rendering ImageSetting", " ");
         ripNode.setType("Combined", true);
         ripNode.setTypes(vTypes);

         // now append the various resources
         // cast to the individual node types and append the appropriate
         // resources
         ripNode.appendMatchingResource(ElementName.INTERPRETINGPARAMS, JDFNode.EnumProcessUsage.AnyInput, null);

         JDFRunList inRunList = (JDFRunList)ripNode.appendMatchingResource(ElementName.RUNLIST, JDFNode.EnumProcessUsage.AnyInput, null);
         inRunList.addRun("File1.pdf", 0, 1);
         inRunList.addRun("File2.pdf", 0, 1);

         JDFColorantControl colorantControl = (JDFColorantControl)ripNode.appendMatchingResource(ElementName.COLORANTCONTROL, JDFNode.EnumProcessUsage.AnyInput, null);
         colorantControl.setProcessColorModel("DeviceCMYK");

         ripNode.appendMatchingResource(ElementName.RENDERINGPARAMS, JDFNode.EnumProcessUsage.AnyInput, null);

         ripNode.appendMatchingResource(ElementName.IMAGESETTERPARAMS, JDFNode.EnumProcessUsage.AnyInput, null);

         // set up the media
         JDFMedia media = (JDFMedia)ripNode.appendMatchingResource(ElementName.MEDIA, JDFNode.EnumProcessUsage.AnyInput, null);
         media.setResStatus(JDFMedia.EnumResStatus.Available, false);
         JDFResourceLink mediaLink = ripNode.getLink(media, null);
         mediaLink.setAmount(4 * 4, new JDFAttributeMap()); // 4 seps * 8 pages

         // set up the expose output media
         JDFExposedMedia exposedMedia = (JDFExposedMedia)ripNode.appendMatchingResource(ElementName.EXPOSEDMEDIA, JDFNode.EnumProcessUsage.AnyOutput, null);

         // set up one partition / page
         VElement vExposedMediaPages = exposedMedia.addPartitions(JDFResource.EnumPartIDKey.RunIndex, new VString("0 1 2 3", null));

         for (int iPage = 0; iPage < vExposedMediaPages.Count; iPage++)
         {
            // now 4 separations per page
            JDFExposedMedia exposedMediaPage = (JDFExposedMedia)vExposedMediaPages[iPage];
            exposedMediaPage.addPartitions(JDFResource.EnumPartIDKey.Separation, new VString("Cyan Magenta Yellow Black", null));
         }

         return 1;
      }

      ///   
      ///	 <summary> * Example 7.7: modify a combined RIP node for reprint of one plate from
      ///	 * scratch </summary>
      ///	 
      private int reprint()
      {

         // get the JDF document root element
         JDFNode ripNode = (JDFNode)m_doc.getRoot();

         JDFResourceLink inRunListLink = ripNode.getMatchingLink(ElementName.RUNLIST, JDFNode.EnumProcessUsage.AnyInput, 0);

         JDFResource rr = ripNode.getMatchingResource(ElementName.RUNLIST, JDFNode.EnumProcessUsage.AnyInput, new JDFAttributeMap(), 0);

         int i;
         Console.WriteLine(inRunListLink.getTarget());

         for (i = 0; i < inRunListLink.getTargetVector(-1).Count; i++)
         {
            Console.WriteLine();
            Console.WriteLine(i);
            Console.WriteLine(inRunListLink.getTargetVector(-1)[i]);
         }

         // set up the input resource link for the run list
         JDFAttributeMap partMap = new JDFAttributeMap();
         partMap.put("Run", "Run0012");
         partMap.put("RunIndex", "3");
         partMap.put("Separation", "Cyan");
         inRunListLink.setPartMap(partMap);
         Console.WriteLine(inRunListLink.getTarget());

         for (i = 0; i < inRunListLink.getTargetVector(-1).Count; i++)
         {
            Console.WriteLine();
            Console.WriteLine(i);
            Console.WriteLine(inRunListLink.getTargetVector(-1)[i]);
         }

         rr.setPartUsage(JDFResource.EnumPartUsage.Implicit);

         Console.WriteLine(inRunListLink.getTarget());

         for (i = 0; i < inRunListLink.getTargetVector(-1).Count; i++)
         {
            Console.WriteLine();
            Console.WriteLine(i);
            Console.WriteLine(inRunListLink.getTargetVector(-1)[i]);
         }

         JDFResourceLink exposedMediaLink = ripNode.getMatchingLink(ElementName.EXPOSEDMEDIA, JDFNode.EnumProcessUsage.AnyOutput, 0);
         exposedMediaLink.setPartMap(partMap);

         partMap.Clear();
         partMap.put("Separation", "Cyan");

         JDFResourceLink colorantControlLink = ripNode.getMatchingLink(ElementName.COLORANTCONTROL, JDFNode.EnumProcessUsage.AnyInput, 0);
         colorantControlLink.setPartMap(partMap);

         return 1;
      }

      ///   
      ///	 <summary> * Example 8:write a JMF message from scratch and fill it with various
      ///	 * signals, queries and commands return the message as a string this
      ///	 * simulates the JMF post input within an http server </summary>
      ///	 

      private string writeMessage()
      {
         // set up the root process
         JDFJMF jmf = m_doc.getJMFRoot();

         jmf.init();
         jmf.setSenderID("MessageSender");
         // append a generic query to root and cast to its type
         JDFQuery queryKnownDevices = (JDFQuery)jmf.appendMessageElement(JDFMessage.EnumFamily.Query, JDFQuery.EnumType.KnownDevices);
         JDFDeviceFilter deviceFilter = queryKnownDevices.appendDeviceFilter();
         JDFDevice device = deviceFilter.appendDevice();
         device.setDeviceID("DeviceID1");

         // serialize this document to a string
         return m_doc.write2String(0);

      }

      ///   
      ///	 <summary> * Example 9:read the JMF message from example 8 and create the appropriate
      ///	 * responses and acknowledges </summary>
      ///	 

      private int processMessage(string inputMessage)
      {
         JDFParser p = new JDFParser();

         // parse the message into a document
         JDFDoc inMessageDoc = p.parseString(inputMessage);

         // get the input document root element
         JDFJMF jmfIn = inMessageDoc.getJMFRoot();
         // get the output document root element
         JDFJMF jmfOut = inMessageDoc.getJMFRoot();
         // get all queries as a vector of elements
         VElement vMessages = jmfIn.getMessageVector(JDFMessage.EnumFamily.Query, null);

         // loop over all queries
         for (int i = 0; i < vMessages.Count; i++)
         {
            JDFQuery query = (JDFQuery)vMessages[i];
            // append a response to this docoment
            JDFResponse response = (JDFResponse)jmfOut.appendMessageElement(JDFMessage.EnumFamily.Response, null);
            // set the appropriate query information to the response
            response.setQuery(query);
            string typ = query.getType();

            // fill in the response according to query type. -> example only
            if (typ.Equals("KnownDevices"))
            {
               // read in the data of the query
               JDFDeviceFilter deviceFilter = query.getDeviceFilter(0);
               JDFDevice deviceIn = deviceFilter.getDevice(0);

               // modify the response
               JDFDeviceList deviceOutList = response.appendDeviceList();
               JDFDeviceInfo deviceInfo = deviceOutList.appendDeviceInfo();
               JDFDevice deviceOut = deviceInfo.appendDevice();
               deviceOut.setDeviceID(deviceIn.getDeviceID());
               deviceOut.setDeviceType("Coffee Machine");
               JDFCostCenter cs = deviceOut.appendCostCenter();
               cs.setCostCenterID("1234");
               cs.setName("Java Bean Cost Center");
               // ...
            }
            else
            {
               // query not implemented!
               response.setAttribute("ReturnCode", 5, "");
               JDFNotification note = response.appendNotification();
               note.setClass(JDFNotification.EnumClass.Error);
               response.setReturnCode(5);
            }
         }

         Console.WriteLine(inMessageDoc.write2String(0));
         return 0;

      }

      ///   
      ///	 <summary> * Example 10:create a DigitalPrinting node from from scratch </summary>
      ///	 

      private int createDigitalPrinting()
      {
         // set up the root process node, which is an imposition node
         JDFNode printNode = (JDFNode)m_doc.getRoot();
         printNode.setType(JDFNode.EnumType.DigitalPrinting.getName(), false);

         // add the appropriate resources
         JDFMedia media = (JDFMedia)printNode.appendMatchingResource(ElementName.MEDIA, JDFNode.EnumProcessUsage.AnyInput, null);

         // partition for Runindex=cover and RunIndex=insert
         media.addPartitions(JDFResource.EnumPartIDKey.RunIndex, new VString("0 -1,1~-2", ","));

         JDFResourceLink mediaLink = printNode.getMatchingLink(ElementName.MEDIA, JDFNode.EnumProcessUsage.AnyInput, 0);

         JDFAmountPool aPool = mediaLink.appendAmountPool();

         JDFAttributeMap mapParts = new JDFAttributeMap();
         mapParts.put(JDFResource.EnumPartIDKey.RunIndex.getName(), "0 -1");

         JDFPartAmount partAmount = aPool.appendPartAmount(mapParts);
         partAmount.setOrientation(JDFResourceLink.EnumOrientation.Flip180);
         mapParts.Clear();

         mapParts.put(JDFResource.EnumPartIDKey.RunIndex.getName(), "1~-2");

         partAmount = aPool.appendPartAmount(mapParts);
         partAmount.setOrientation(JDFResourceLink.EnumOrientation.Rotate0);

         // get the MediaLink and set the attributes
         JDFDigitalPrintingParams dpp = (JDFDigitalPrintingParams)printNode.appendMatchingResource(ElementName.DIGITALPRINTINGPARAMS, JDFNode.EnumProcessUsage.AnyInput, null);

         dpp.addPartitions(JDFResource.EnumPartIDKey.RunIndex, new VString("0 -1,1~-2", ","));

         JDFAttributeMap m = new JDFAttributeMap(JDFResource.EnumPartIDKey.RunIndex.getName(), "0 -1");
         JDFDigitalPrintingParams dppLeaf = (JDFDigitalPrintingParams)dpp.getPartition(m, EnumPartUsage.Implicit);

         m.put(JDFResource.EnumPartIDKey.RunIndex.getName(), dppLeaf.refElement(media.getPartition(m, EnumPartUsage.Implicit)).getrRef());

         m.put(JDFResource.EnumPartIDKey.RunIndex.getName(), "1 ~ -2");
         dppLeaf = (JDFDigitalPrintingParams)dpp.getPartition(m, EnumPartUsage.Implicit);

         dppLeaf.refElement(media.getPartition(m, EnumPartUsage.Implicit));

         return 0;

      }

      ///   
      ///	 <summary> * Example 10:create a narrow web node from from scratch </summary>
      ///	 

      private int createNarrowWeb()
      {
         // set up the root process node, which is an imposition node
         JDFNode printNode = (JDFNode)m_doc.getRoot();
         printNode.setType(JDFNode.EnumType.Combined.getName(), false);
         VString types = new VString();
         types.Add("ConventionalPrinting");
         types.Add("ConventionalPrinting");
         types.Add("Laminating");
         types.Add("ShapeCutting");

         printNode.setTypes(types);
         // add the appropriate resources
         JDFMedia media = (JDFMedia)printNode.appendMatchingResource(ElementName.MEDIA, JDFNode.EnumProcessUsage.AnyInput, null);
         media.setDescriptiveName("Input Media");
         media.setMediaType(EnumMediaType.Paper);
         media.setMediaUnit(EnumMediaUnit.Roll);

         JDFComponent outComp = (JDFComponent)printNode.appendMatchingResource(ElementName.COMPONENT, JDFNode.EnumProcessUsage.AnyOutput, null);

         JDFConventionalPrintingParams cpOffset = (JDFConventionalPrintingParams)printNode.appendMatchingResource(ElementName.CONVENTIONALPRINTINGPARAMS, JDFNode.EnumProcessUsage.AnyInput, null);
         cpOffset.setDescriptiveName("Offset parameters");

         JDFExposedMedia xmOffset = (JDFExposedMedia)printNode.appendMatchingResource(ElementName.EXPOSEDMEDIA, JDFNode.EnumProcessUsage.Plate, null);
         xmOffset.setDescriptiveName("Offset Plate");
         xmOffset.addPartition(EnumPartIDKey.Side, "Front");
         xmOffset.addPartition(EnumPartIDKey.Side, "Back");

         JDFConventionalPrintingParams cpFlexo = (JDFConventionalPrintingParams)printNode.appendMatchingResource(ElementName.CONVENTIONALPRINTINGPARAMS, JDFNode.EnumProcessUsage.AnyInput, null);
         cpFlexo.setDescriptiveName("Flexo parameters");

         JDFExposedMedia xmFlexo = (JDFExposedMedia)printNode.appendMatchingResource(ElementName.EXPOSEDMEDIA, JDFNode.EnumProcessUsage.Plate, null);
         xmFlexo.setDescriptiveName("Flexo Plate");

         JDFLaminatingParams lamParm = (JDFLaminatingParams)printNode.appendMatchingResource(ElementName.LAMINATINGPARAMS, JDFNode.EnumProcessUsage.AnyInput, null);
         lamParm.setDescriptiveName("laminating parameters");

         JDFShapeCuttingParams cutParm = (JDFShapeCuttingParams)printNode.appendMatchingResource(ElementName.SHAPECUTTINGPARAMS, JDFNode.EnumProcessUsage.AnyInput, null);
         cutParm.setDescriptiveName("cutting parameters");

         // fix resource links
         JDFResourceLink rl = printNode.getLink(cpOffset, null);
         JDFIntegerList il = new JDFIntegerList();
         il.Add(0);
         rl.setCombinedProcessIndex(il);

         rl = printNode.getLink(xmOffset, null);
         rl.setCombinedProcessIndex(il);

         il.Clear();
         il.Add(1);
         rl = printNode.getLink(cpFlexo, null);
         rl.setCombinedProcessIndex(il);

         rl = printNode.getLink(xmFlexo, null);
         rl.setCombinedProcessIndex(il);

         rl = printNode.getLink(outComp, null);
         rl.setAmount(500, null);

         return 0;

      }

      ///   
      ///	 <summary> * create a simple stripping node for 2 user jobs in a gang job
      ///	 * 
      ///	 * @return </summary>
      ///	 
      [TestMethod]
      public virtual void testDigitalDelivery()
      {
         JDFElement.setLongID(false);

         JDFDoc d = new JDFDoc("JDF");
         JDFNode pgNode = d.getJDFRoot();
         pgNode.setType(EnumType.ProcessGroup);
         JDFNode delNode = creatDeliveryNode(pgNode);
         JDFRunList rl = (JDFRunList)delNode.getMatchingResource(ElementName.RUNLIST, EnumProcessUsage.AnyOutput, null, 0);

         JDFNode impNode = createImposition(pgNode);
         impNode.linkMatchingResource(rl, EnumProcessUsage.Document, null);

         d.write2File(sm_dirTestDataTemp + "DigitalDelivery.jdf", 2, false);

      }

      ///   
      ///	 <summary> * create a simple stripping node for 2 user jobs in a gang job
      ///	 * 
      ///	 * @return </summary>
      ///	 
      [TestMethod]
      public virtual void testGangDigitalDelivery()
      {
         JDFElement.setLongID(false);

         JDFNode delNode1 = creatDeliveryNode(null);
         delNode1.setJobID("Del1ID");
         JDFDoc delDoc1 = new JDFDoc(delNode1.OwnerDocument);
         JDFRunList rl1 = (JDFRunList)delNode1.getMatchingResource(ElementName.RUNLIST, EnumProcessUsage.AnyOutput, null, 0);
         rl1.setProductID("RL1ID");
         JDFRegistration reg = (JDFRegistration)delNode1.getNodeInfo().getJMF(0).getMessageElement(EnumFamily.Registration, JDFMessage.EnumType.Resource, 0);
         JDFResourceCmdParams rc = reg.getResourceCmdParams(0);
         rc.setProductID("RL1ID");
         reg.appendSubscription();

         JDFNode delNode2 = creatDeliveryNode(null);
         JDFDoc delDoc2 = new JDFDoc(delNode2.OwnerDocument);
         JDFRunList rl2 = (JDFRunList)delNode2.getMatchingResource(ElementName.RUNLIST, EnumProcessUsage.AnyOutput, null, 0);
         rl2.setProductID("RL2ID");
         JDFRegistration reg2 = (JDFRegistration)delNode2.getNodeInfo().getJMF(0).getMessageElement(EnumFamily.Registration, JDFMessage.EnumType.Resource, 0);
         JDFResourceCmdParams rc2 = reg2.getResourceCmdParams(0);
         reg2.appendSubscription();
         delNode2.setJobID("Del2ID");
         rc2.setProductID("RL2ID");

         JDFDoc dGang = new JDFDoc("JDF");
         JDFNode pgNode = dGang.getJDFRoot();
         pgNode.setJobID("GangJobID");
         pgNode.setType(EnumType.ProcessGroup);
         JDFNodeInfo pgNI = pgNode.getCreateNodeInfo();

         JDFNode combNode = createCombine(pgNode);
         JDFRunList rl = (JDFRunList)combNode.getMatchingResource(ElementName.RUNLIST, EnumProcessUsage.AnyOutput, null, 0);

         JDFNode impNode = createImposition(pgNode);
         impNode.linkMatchingResource(rl, EnumProcessUsage.Document, null);
         pgNode.setTypes(new VString("Combine,Imposition", ","));

         pgNI.appendGeneralID("GangChildID", delNode1.getJobID(true));
         pgNI.appendGeneralID("GangChildID", delNode2.getJobID(true));

         delDoc1.write2File(sm_dirTestDataTemp + "GangDelivery1.jdf", 2, false);
         delDoc2.write2File(sm_dirTestDataTemp + "GangDelivery2.jdf", 2, false);
         dGang.write2File(sm_dirTestDataTemp + "GangImpose.jdf", 2, false);

      }


      private JDFNode createImposition(JDFNode pgNode)
      {
         JDFNode impNode = ceateNewNode(EnumType.Imposition, pgNode);
         impNode.appendMatchingResource(ElementName.LAYOUT, EnumProcessUsage.AnyInput, null);
         return impNode;
      }


      private JDFNode createCombine(JDFNode pgNode)
      {
         JDFNode combNode = ceateNewNode(EnumType.Combine, pgNode);
         JDFRunList rl = (JDFRunList)combNode.appendMatchingResource(ElementName.RUNLIST, EnumProcessUsage.AnyInput, null);
         rl.setProductID("RL1ID");

         rl = (JDFRunList)combNode.appendMatchingResource(ElementName.RUNLIST, EnumProcessUsage.AnyInput, null);
         rl.setProductID("RL2ID");

         rl = (JDFRunList)combNode.appendMatchingResource(ElementName.RUNLIST, EnumProcessUsage.AnyOutput, pgNode);

         JDFRunList rlp = (JDFRunList)rl.addPartition(EnumPartIDKey.RunSet, "RL1ID");
         rlp.setDescriptiveName("Partition for first input");

         rlp = (JDFRunList)rl.addPartition(EnumPartIDKey.RunSet, "RL2ID");
         rlp.setDescriptiveName("Partition for second input");

         rl.setResStatus(EnumResStatus.Unavailable, true);

         return combNode;
      }


      private JDFNode creatDeliveryNode(JDFNode pgNode)
      {
         JDFNode delNode = null;
         delNode = ceateNewNode(EnumType.DigitalDelivery, pgNode);
         delNode.appendMatchingResource(ElementName.DIGITALDELIVERYPARAMS, EnumProcessUsage.AnyInput, null);
         JDFRunList rl = (JDFRunList)delNode.appendMatchingResource(ElementName.RUNLIST, EnumProcessUsage.AnyOutput, null);
         rl.setResStatus(EnumResStatus.Unavailable, false);
         JDFNodeInfo ni = delNode.getCreateNodeInfo();
         JDFJMF jmf = ni.appendJMF();
         JDFRegistration reg = (JDFRegistration)jmf.appendMessageElement(EnumFamily.Registration, JDFMessage.EnumType.Resource);
         JDFResourceCmdParams resCmd = reg.appendResourceCmdParams();
         resCmd.setResourceName(ElementName.RUNLIST);
         resCmd.setJobID("GangJobID");
         return delNode;
      }


      private JDFNode ceateNewNode(EnumType enumType, JDFNode parentNode)
      {
         JDFNode delNode;
         if (parentNode == null)
         {
            JDFDoc d = new JDFDoc("JDF");
            delNode = d.getJDFRoot();
            delNode.setType(enumType);
         }
         else
         {
            delNode = parentNode.addJDFNode(enumType);
         }
         return delNode;
      }

      ///   
      ///	 <summary> * create a simple stripping node for 2 user jobs in a gang job
      ///	 * 
      ///	 * @return </summary>
      ///	 
      public virtual int testMISGang()
      {
         JDFElement.setLongID(false);
         // set up the root process node, which is an imposition node
         JDFDoc d = new JDFDoc("JDF");
         JDFNode misNode = d.getJDFRoot();
         misNode.setJobID("GangJob");
         misNode.setType(EnumType.Stripping);
         JDFAssembly as1 = (JDFAssembly)misNode.appendMatchingResource(ElementName.ASSEMBLY, EnumProcessUsage.AnyInput, null);
         as1.setAssemblyIDs(new VString("As1", null));
         as1.setOrder(EnumOrder.Collecting);
         as1.setJobID("job1");
         JDFAssembly as2 = (JDFAssembly)misNode.appendMatchingResource(ElementName.ASSEMBLY, EnumProcessUsage.AnyInput, null);
         as2.setAssemblyIDs(new VString("As2", null));
         as2.setOrder(EnumOrder.Collecting);
         as2.setJobID("job2");
         JDFStrippingParams sp = (JDFStrippingParams)misNode.appendMatchingResource(ElementName.STRIPPINGPARAMS, EnumProcessUsage.AnyInput, null);
         JDFStrippingParams sp1 = (JDFStrippingParams)sp.addPartition(EnumPartIDKey.BinderySignatureName, "BS1");
         sp1.setAssemblyIDs(new VString("As1", null));
         sp1.setJobID("job1");

         JDFBinderySignature bs1 = sp1.appendBinderySignature();
         bs1 = (JDFBinderySignature)bs1.makeRootResource(null, null, true);
         JDFPosition pos1 = sp1.appendPosition();
         try
         {
            pos1.setRelativeBox(new JDFRectangle("0 0 0.5 1"));
         }
         catch (FormatException)
         {
            Assert.Fail("rectangle");
         }

         JDFStrippingParams sp2 = (JDFStrippingParams)sp.addPartition(EnumPartIDKey.BinderySignatureName, "BS2");
         sp2.setAssemblyIDs(new VString("As2", null));
         sp2.setJobID("job2");

         sp2.refElement(bs1);
         JDFPosition pos2 = sp2.appendPosition();
         try
         {
            pos2.setRelativeBox(new JDFRectangle("0.5 0 1 1"));
         }
         catch (FormatException)
         {
            Assert.Fail("rectangle");
         }
         d.write2File(sm_dirTestDataTemp + "StrippingGang.jdf", 2, false);
         return 0;
      }
   }
}
