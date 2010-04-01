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
 * Titel:        check a jdf file, if is valid
 * Version:
 * Copyright:    Copyright (c) 2002
 * Autor:        Joerg Gonnermann, Dietrich Mucha
 * Firma:        Heidelberger Druckmaschinen AG
 */

namespace org.cip4.jdflib.validate
{
   using System;
   using System.IO;
   using System.IO.Compression;
   using System.Collections;
   using System.Collections.Specialized;
   using System.Net.Mail;
   using System.Web;



   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFAudit = org.cip4.jdflib.core.JDFAudit;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFParser = org.cip4.jdflib.core.JDFParser;
   using JDFRefElement = org.cip4.jdflib.core.JDFRefElement;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using XMLDoc = org.cip4.jdflib.core.XMLDoc;
   using XMLErrorHandler = org.cip4.jdflib.core.XMLErrorHandler;
   using EnumVersion = org.cip4.jdflib.core.JDFElement.EnumVersion;
   using EnumValidationLevel = org.cip4.jdflib.core.KElement.EnumValidationLevel;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using EnumFitsValue = org.cip4.jdflib.datatypes.EnumFitsValue;
   using JDFJMF = org.cip4.jdflib.jmf.JDFJMF;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using EnumType = org.cip4.jdflib.node.JDFNode.EnumType;
   using JDFResourceLinkPool = org.cip4.jdflib.pool.JDFResourceLinkPool;
   using JDFResourcePool = org.cip4.jdflib.pool.JDFResourcePool;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using EnumPartIDKey = org.cip4.jdflib.resource.JDFResource.EnumPartIDKey;
   using JDFDeviceCap = org.cip4.jdflib.resource.devicecapability.JDFDeviceCap;
   using MimeUtil = org.cip4.jdflib.util.MimeUtil;
   using MyArgs = org.cip4.jdflib.util.MyArgs;
   using StringUtil = org.cip4.jdflib.util.StringUtil;
   using UrlUtil = org.cip4.jdflib.util.UrlUtil;

   ///
   /// <summary> * 
   /// * this is the non-commandline part of the original checkJDF and used both by the JDF Editor and checkJDF
   /// * 
   /// * Refactored JDFValidator to be non-static in order to make it thread compatible. Previously, only one thread at a time
   /// * could call JDFValidator from within the same JVM. Now an instance of JDFValidator and the the method validate should
   /// * be called. JDFValidator can still be called from the command line in the same way as before.
   /// * 
   /// * TODO Break out validation error handling logging so that new error handlers can easily be registered. For example,
   /// * there should be an error handler for logging to the XML log file and an error handler for logging to the
   /// * <code>sysOut</code>. Perhaps <code>org.xml.sax.ErrorHandler</code> could be used?
   /// * 
   /// * @author Claes Buckwalter (clabu@itn.liu.se)
   /// * @version 2008-01-02 </summary>
   /// 
   public class JDFValidator
   {
      internal VString foundNameSpaces = new VString();
      internal VString vID = new VString();
      public VString vBadID = new VString();
      public VString vMultiID = null;
      internal VString vBadJobPartID = new VString();
      internal VString vJobPartID = new VString();
      internal VElement vResources = new VElement();
      internal VElement vLinkedResources = new VElement();
      internal VElement vBadResourceLinks = new VElement();
      internal VString vSeparations = new VString();
      internal VString vSeparations2 = new VString();
      internal VString vColorPoolSeparations = new VString();
      protected internal XMLDoc pOut = new XMLDoc("CheckOutput", null);
      // list of gray boxes that are ignored when checking types for extensions
      internal static string[] aGBList = { "ImpositionRIPing", "PlateMaking", "ProofAndPlateMaking", "ImpositionProofing", "PageProofing", "RIPing", "PrePressPreparation", "ImpositionPreparation", "ProofImaging" };

      internal JDFDoc theDoc = null;
      protected internal string translation = null;
      private bool bTryFormats = false;
      private ICheckValidatorFactory validatorFactory = null;

      public bool bTiming = false;
      protected internal bool bWarning = false;
      public bool bQuiet = true;
      protected internal bool bPrintNameSpace = true;
      public bool bValidate = true;
      ///   
      ///	 <summary> * if true, warn on URL attributes that point to Nirvana </summary>
      ///	 
      public bool bWarnDanglingURL = false;
      public KElement.EnumValidationLevel level = EnumValidationLevel.Incomplete;
      public VString allFiles = null;

      public string proxyHost = null;
      public string proxyPort = null;

      public string schemaLocation = null;
      public string xmlOutputName = null;
      public string xslStyleSheet = null;

      public string devCapFile = null;
      public EnumFitsValue testlists = EnumFitsValue.Allowed;
      public bool bMultiID = false;
      private bool inOutputLoop = false;

      protected internal string version = "JDFValidator: JDF validator; -- (c) 2001-2008 CIP4" + "\nJDF 1.3 compatible version\n" + "\nCode based on schema JDF_1.3.xsd Release Candidate 001\n" + "Build version " + JDFAudit.software();

      public JDFValidator()
         : base()
      {
         pOut.getRoot().setAttribute("Version", version);
      }

      public static string toMessageString(KElement checkOut)
      {
         if (checkOut == null)
         {
            return null;
         }
         return checkOut.getAttribute("Message", null, null);
      }

      private void setErrorType(KElement reportElem, string type, string message, int indent_)
      {
         if (reportElem == null)
         {
            return;
         }
         reportElem.setAttribute("IsValid", false, null);
         reportElem.setAttribute("ErrorType", type, null);
         reportElem.setAttribute("Message", message, null);
         if (indent_ > 0)
         {
            sysOut.println(indent(indent_) + message);
         }
      }

      private void setErrorType(KElement reportElem, string type, string message)
      {
         setErrorType(reportElem, type, message, -1);
      }

      ///   
      ///	 <summary> * set the JDFDoc (JDF or JMF) to set
      ///	 *  </summary>
      ///	 * <param name="d"> the JDFDoc to set this to </param>
      ///	 
      public virtual void setDoc(JDFDoc d)
      {
         theDoc = d;
      }

      protected internal MySysOut sysOut = new MySysOut();

      ///   
      ///	 <summary> * if bI
      ///	 *  </summary>
      ///	 * <param name="bIgnore"> </param>
      ///	 
      public virtual void setIgnorePrivate(bool bIgnore)
      {
         bPrintNameSpace = !bIgnore;
      }

      ///   
      ///	 <summary> * sets the System.out print on or off
      ///	 *  </summary>
      ///	 * <param name="b"> </param>
      ///	 
      public virtual void setPrint(bool b)
      {
         sysOut.setPrint(b);
      }

      ///   
      ///	 <summary> * simple helper to create an indented string with leading blanks
      ///	 *  </summary>
      ///	 * <param name="indent"> number of leadingbla </param>
      ///	 
      private string indent(int indent)
      {
         string s = "";
         for (int i = 0; i < indent; i++)
         {
            s += " ";
         }
         return s;
      }

      ///   
      ///	 <summary> * the subroutine to print out invalid parts of a jdf.
      ///	 *  </summary>
      ///	 * <param name="JDFElement"> jdfElement - the element to test </param>
      ///	 * <param name="bool"> bQuiet - flag what to do with valid elements; quiet if true </param>
      ///	 * <param name="indent"> - indent for println() to console window </param>
      ///	 * <param name="xmlParent"> - root for XML output (if '-x' set) </param>
      ///	 * <param name="bIsNodeRoot"> - is the jdfElement a root of a whole testNode or not </param>
      ///	 

      private void printBad(KElement kElement, int indent_, KElement xmlParent, bool bIsNodeRoot)
      {
         int i, j;

         string id = kElement.getAttribute(AttributeName.ID, null, "");
         string pref = kElement.Prefix;
         string elmName = kElement.Name;
         string nsURI = kElement.getNamespaceURI();

         KElement testElement = null;

         if (xmlParent != null)
         {
            testElement = xmlParent.appendElement("TestElement");
            testElement.setAttribute("XPath", kElement.buildXPath(null, 1));
            testElement.setAttribute("NodeName", kElement.Name);
            string strID = kElement.getAttribute(AttributeName.ID, null, null);
            if (strID != null)
            {
               testElement.setAttribute("ID", strID);
            }
         }

         if (kElement is JDFNode)
         {
            JDFNode node = (JDFNode)kElement;
            printNode(node, indent_, testElement);

            if (bIsNodeRoot) // this will be executed only once - test of the
            // whole Node
            {
               printNodeRoot(node, xmlParent);
            }
         }

         bool isJDFNS = JDFElement.isInJDFNameSpaceStatic(kElement);
         bool bTypo = false;
         if (!isJDFNS)
         {
            string nameSpaceURI = kElement.getNamespaceURI();
            string nsLower = nameSpaceURI.ToLower();
            if (nsLower.Contains(JDFConstants.CIP4ORG) && !nsLower.Equals(JDFConstants.JDFNAMESPACE))
            {
               sysOut.println("Probable namespace Typo: xmlns=" + nameSpaceURI + " should be:" + JDFConstants.JDFNAMESPACE);
               if (testElement != null)
               {
                  bTypo = true;
                  testElement.setAttribute("NSPrefix", pref);
                  testElement.setAttribute("NSURI", nsURI);
                  testElement.setAttribute("IsPrivate", true, null);
                  testElement.setAttribute("Status", "Skipping");
                  setErrorType(testElement, "PrivateElement", "Element in Private NameSpace - probable Namespace Typo in: " + elmName + " Correct ns URI=" + JDFConstants.JDFNAMESPACE);
               }
            }
            if (bPrintNameSpace)
            {
               sysOut.print(indent(indent_ + 2));
               string status = isJDFNS ? "Testing" : "Skipping";
               sysOut.print(status + " ");

               sysOut.println("Element that is not in JDF nameSpace: <" + kElement.LocalName + "> namespace:" + pref + "  uri: " + nsURI);
               setErrorType(testElement, "PrivateElement", "Element in Private NameSpace: " + elmName);
               if (testElement != null)
               {
                  testElement.setAttribute("NSPrefix", pref);
                  testElement.setAttribute("NSURI", nsURI);
                  testElement.setAttribute("IsPrivate", true, null);
                  testElement.setAttribute("Status", "Skipping");
               }
            }
            if (kElement is JDFResourceLink)
            {
               printResourceLink((JDFResourceLink)kElement, indent_, testElement);
            }

            if (kElement is JDFRefElement)
            {
               printRefElement((JDFRefElement)kElement, indent_, testElement);
            }

            if (kElement is JDFResource)
            {
               printResource((JDFResource)kElement, indent_, testElement);
            }
            if (!bPrintNameSpace && !bTypo && xmlParent != null && testElement != null && !testElement.hasChildElements())
            {
               testElement.deleteNode();
            }
            return;
         }

         // the following code line is a copy from C++ version and
         // is used for identity of variable names for JDFValidator in Java and
         // C++.
         // In C++ here a factory object is created.
         bool bIsValid = privateValidation(kElement, testElement);

         if (!(kElement is JDFElement))
         {
            return; // TODO more
         }
         JDFElement jdfElement = (JDFElement)kElement;

         VString privateAttributes = new VString(jdfElement.getUnknownAttributes(false, 9999999));
         VString unknownAttributes = new VString(jdfElement.getUnknownAttributes(true, 9999999));
         privateAttributes.removeStrings(unknownAttributes, int.MaxValue);

         VString privateElements = new VString(jdfElement.getUnknownElements(false, 9999999));
         VString unknownElements = new VString(jdfElement.getUnknownElements(true, 9999999));
         privateElements.removeStrings(unknownElements, int.MaxValue);

         if (bPrintNameSpace)
         {
            printPrivate(privateAttributes, privateElements, jdfElement, indent_, testElement);
         }

         bool bIsOK = true;

         if (jdfElement is JDFResourceLinkPool)
         { // check typesafe node links
            bIsOK = true; // nop this is done in printnode
         }
         else if (jdfElement is JDFRefElement)
         {
            bIsOK = printRefElement((JDFRefElement)jdfElement, indent_, testElement);
         }
         else if (jdfElement is JDFResourceLink)
         {
            bIsOK = printResourceLink((JDFResourceLink)jdfElement, indent_, testElement);
         }
         else if (jdfElement is JDFResource)
         {
            bIsOK = printResource((JDFResource)jdfElement, indent_, testElement);
         }
         if (bWarnDanglingURL)
         {
            printURL(kElement, indent_, testElement);
         }

         bIsValid = jdfElement.isValid(level) && bIsValid;
         bool bValidID = id == null || id.Equals(JDFConstants.EMPTYSTRING) ? true : !vBadID.Contains(id);
         bool bUnknownElem = false;

         if (testElement != null && xmlParent != null)
         {
            if (bIsOK)
            {
               string invElems = xmlParent.getAttribute("PreReleaseElements");
               bIsOK = !StringUtil.hasToken(invElems, elmName, " ", 0);
               if (!bIsOK)
               {
                  EnumVersion v = jdfElement.getParentNode_KElement().getFirstVersion(elmName, true);
                  testElement.setAttribute("FirstVersion", v.getName());
                  setErrorType(testElement, "PreReleaseElement", elmName + " is not valid in JDF Version" + jdfElement.getVersion(true).getName() + " First Valid version: " + v.getName(), indent_ + 2);
               }
            }

            if (bIsOK && bWarning)
            {
               string invElems = xmlParent.getAttribute("DeprecatedElements");
               bIsOK = !StringUtil.hasToken(invElems, elmName, " ", 0);
               if (!bIsOK)
               {
                  EnumVersion v = jdfElement.getParentNode_KElement().getLastVersion(elmName, true);
                  testElement.setAttribute("LastVersion", v.getName());
                  setErrorType(testElement, "DeprecatedElement", elmName + " is not valid in JDF Version" + jdfElement.getVersion(true).getName() + " Last Valid version: " + v.getName(), indent_ + 2);
               }
            }

            if (bIsOK)
            {
               string invElems = xmlParent.getAttribute("PrivateElements");
               bIsOK = !StringUtil.hasToken(invElems, elmName, " ", 0);
               if (!bIsOK)
               {
                  setErrorType(testElement, "PrivateElement", elmName + " is not a valid subelement");
               }
            }
            if (bIsOK)
            {
               string swapElems = xmlParent.getAttribute("SwapElements");
               bIsOK = !StringUtil.hasToken(swapElems, elmName, " ", 0);
               if (!bIsOK)
               {
                  setErrorType(testElement, "SwapElement", elmName + " is written as an Element");
               }
            }
            if (bIsOK)
            {
               string unkElems = xmlParent.getAttribute("UnknownElements", null, null);
               if (unkElems != null)
               {
                  bIsOK = !StringUtil.hasToken(unkElems, elmName, " ", 0);
                  if (!bIsOK)
                  {
                     setErrorType(testElement, "UnknownElement", elmName + " is not defined in a " + xmlParent.LocalName);
                     bUnknownElem = true;
                  }
               }
            }
         }

         if (bUnknownElem && testElement != null)
         {
            testElement.setAttribute("IsValid", false, null);
         }
         else if (bIsValid && bValidID && bIsOK)
         {
            // print out validity if not quiet
            if (!bQuiet)
            {
               sysOut.println(indent(indent_) + "--- Valid:" + jdfElement.buildXPath(null, 1) + " " + id);
            }
            if (testElement != null)
            {
               testElement.setAttribute("IsValid", true, null);
            }
            if (bIsNodeRoot && xmlParent != null)
            {
               xmlParent.setAttribute("IsValid", true, null);
            }

         }
         else
         // this one is bad -> recurse to find a reason
         {
            if (bIsOK) // for the case "Logic is not OK", we printed this line
            // already.
            {
               sysOut.println(indent(indent_) + "!!! InValid Element: " + kElement.buildXPath(null, 1) + " " + id + " !!! ");
            }
            if (testElement != null)
            {
               testElement.setAttribute("IsValid", false, null);
            }
            sysOut.println(indent(indent_ + 2) + "Invalid Element " + elmName + " is not valid, see child elements for details");
            if (testElement != null && !testElement.hasAttribute("ErrorType"))
            {
               setErrorType(testElement, "InvalidElement", elmName + " is not valid, see child elements for details", 2);
            }

            if (!bValidID && testElement != null)
            {
               KElement e = testElement.appendElement("TestAttribute");
               setErrorType(e, "MultipleID", "Multiply defined ID = " + id, indent_);
               e.setAttribute("NodeName", "ID");
               e.setAttribute("Value", id);
               e.setAttribute("XPath", jdfElement.buildXPath(null, 1) + "/@ID");
            }

            bool printMissElms = true;
            if (jdfElement is JDFResource)
            {
               JDFResource r = (JDFResource)jdfElement;
               if (JDFResource.EnumResStatus.Incomplete.Equals(r.getResStatus(false)) || (!r.isLeaf() && (!JDFResource.EnumPartUsage.Implicit.Equals(r.getPartUsage()))))
               {
                  printMissElms = false;
               }
            }

            VString swapAtt = new VString();
            VString vTmp = jdfElement.knownElements();
            // compare missing elements with unknown attributes to find elem <->
            // attrib swaps
            int unknownSize = unknownAttributes.Count;
            for (j = 0; j < unknownSize; j++)
            {
               string unknownAttr = unknownAttributes[j];
               if (vTmp.Contains(unknownAttr))
               {
                  swapAtt.appendUnique(unknownAttr);
               }
            }

            // compare missing attributes with unknown elements to find elem <->
            // attrib swaps
            VString swapElem = new VString();
            vTmp = jdfElement.knownAttributes();
            for (j = 0; j < unknownElements.Count; j++)
            {
               string unknownElem = unknownElements[j];
               if (vTmp.Contains(unknownElem))
               {
                  swapElem.appendUnique(unknownElem);
               }
            }

            // get a list of missing and invalid attribute and element names
            VString invalidAttributes = new VString(jdfElement.getInvalidAttributes(level, true, 9999999));
            VString invalidElements = jdfElement.getInvalidElements(level, true, 9999999);
            VString missingAttributes = new VString();
            VString missingElements = new VString();
            VString deprecatedAttributes = jdfElement.getDeprecatedAttributes(9999999);
            VString deprecatedElements = jdfElement.getDeprecatedElements(9999999);
            VString prereleaseAttributes = jdfElement.getPrereleaseAttributes(9999999);
            VString prereleaseElements = jdfElement.getPrereleaseElements(9999999);

            // unknown attributes are also invalid -> remove them from the print
            // list
            invalidAttributes.removeStrings(unknownAttributes, 99999);
            invalidAttributes.removeStrings(deprecatedAttributes, 99999);
            invalidAttributes.removeStrings(prereleaseAttributes, 99999);
            unknownAttributes.removeStrings(prereleaseAttributes, 99999);
            unknownAttributes.removeStrings(deprecatedAttributes, 99999);

            // unknown elements are also invalid -> remove them from the print
            // list
            invalidElements.removeStrings(unknownElements, 99999);
            invalidElements.removeStrings(deprecatedElements, 99999);
            invalidElements.removeStrings(prereleaseElements, 99999);
            unknownElements.removeStrings(deprecatedElements, 99999);
            unknownElements.removeStrings(prereleaseElements, 99999);

            // swapped elements are also invalid -> remove them from the print
            // list
            unknownElements.removeStrings(swapElem, 99999);
            // swapped attributes are also invalid -> remove them from the print
            // list
            unknownAttributes.removeStrings(swapAtt, 99999);

            // find missing elements and attributes
            if (level.getValue() >= EnumValidationLevel.Complete.getValue())
            {
               missingAttributes = new VString(jdfElement.getMissingAttributes(9999999));
               // missing attributes are also invalid -> remove them from the
               // print list
               invalidAttributes.removeStrings(missingAttributes, 99999);
               missingElements = new VString(jdfElement.getMissingElements(9999999));
               // missing elements are also invalid -> remove them from the
               // print list
               invalidElements.removeStrings(missingElements, 99999);
            }

            // remove all warning lists
            if (!bWarning)
            {
               deprecatedElements = null;
               deprecatedAttributes = null;
            }

            // remove all double entries before printing
            unknownElements.unify();
            missingElements.unify();

            // print the various snafus

            printAttributeList(indent_, testElement, jdfElement, printMissElms, unknownAttributes, "Unknown", "Unknown Attribute");
            printAttributeList(indent_, testElement, jdfElement, printMissElms, invalidAttributes, "Invalid", "Invalid attribute Value");
            printAttributeList(indent_, testElement, jdfElement, printMissElms, deprecatedAttributes, "Deprecated", "Deprecated Attribute in JDF Version " + jdfElement.getVersion(true).getName());
            printAttributeList(indent_, testElement, jdfElement, printMissElms, prereleaseAttributes, "PreRelease", "Attribute not yet defined in JDF Version " + jdfElement.getVersion(true).getName());
            printAttributeList(indent_, testElement, jdfElement, printMissElms, missingAttributes, "Missing", "Missing Attribute");
            printAttributeList(indent_, testElement, jdfElement, printMissElms, swapAtt, "Swap", "Element written as Attribute");

            for (j = 0; j < swapElem.Count; j++)
            {
               string swEl = swapElem.stringAt(j);
               sysOut.println(indent(indent_ + 2) + "Attribute is written as Element: " + swEl);
            }

            if (swapElem.Count > 0 && testElement != null)
            {
               testElement.setAttribute("SwapElements", StringUtil.setvString(swapElem, JDFConstants.BLANK, null, null));
            }

            if (printMissElms)
            {
               for (j = 0; j < missingElements.Count; j++)
               {
                  string missEl = missingElements.stringAt(j);
                  sysOut.println(indent(indent_ + 2) + "Missing Element: " + missEl);

                  if (testElement != null)
                  {
                     KElement e = testElement.appendElement("TestElement");
                     setErrorType(e, "MissingElement", "Missing Element " + missEl);
                     e.setAttribute("XPath", jdfElement.buildXPath(null, 1) + "/" + missEl + "[1]");
                     e.setAttribute("NodeName", missEl);
                  }
               }
               if (testElement != null && missingElements.Count > 0)
               {
                  testElement.setAttribute("MissingElements", StringUtil.setvString(missingElements, JDFConstants.BLANK, null, null));
               }
            }
            for (j = 0; j < unknownElements.Count; j++)
            {
               sysOut.println(indent(indent_ + 2) + "Unknown Element: " + unknownElements.stringAt(j));
            }
            if (testElement != null && unknownElements.Count > 0)
            {
               testElement.setAttribute("UnknownElements", StringUtil.setvString(unknownElements, JDFConstants.BLANK, null, null));
            }

            printElementList(indent_, testElement, jdfElement, invalidElements, "Invalid");
            printElementList(indent_, testElement, jdfElement, deprecatedElements, "Deprecated");
            printElementList(indent_, testElement, jdfElement, prereleaseElements, "PreRelease");
            printElementList(indent_, testElement, jdfElement, privateElements, "Private");

            if (jdfElement is JDFResource)
            {
               JDFResource res = (JDFResource)jdfElement;

               if (!res.isLeaf())
               { // handle partitioned resources
                  VElement vr = res.getLeaves(false);
                  for (j = 0; j < vr.Count; j++)
                  {
                     printBad(vr[j], indent_ + 2, testElement, false);
                  }
               }
            }
         }

         // recurse through all child elements :
         VElement ve = jdfElement.getChildElementVector(null, null, null, true, 0, false);
         for (i = 0; i < ve.Count; i++)
         {
            printBad(ve[i], indent_ + 2, testElement, false);
         }
      }

      ///   
      ///	 * <param name="element">
      ///	 * @return </param>
      ///	 
      private bool privateValidation(KElement toCheck, KElement report)
      {
         if (validatorFactory == null)
            return true;
         ICheckValidator v = validatorFactory.getValidator(toCheck);
         if (v == null)
            return true;
         return v.validate(toCheck, report);
      }

      ///   
      ///	 * <param name="element"> </param>
      ///	 * <param name="indent"> </param>
      ///	 * <param name="testElement"> </param>
      ///	 
      private void printURL(KElement element, int indent, KElement testElement)
      {
         if (!element.hasAttribute(AttributeName.URL))
         {
            return;
         }
         string url = element.getAttribute(AttributeName.URL);
         if (UrlUtil.getURLInputStream(url, element.getOwnerDocument_KElement().getBodyPart()) == null)
         {
            // found bad url
            KElement e = testElement.appendElement("TestAttribute");
            setErrorType(e, "DanglingURL", "Dangling URL points to Nirvana: " + url, indent);
            e.setAttribute("NodeName", "URL");
            e.setAttribute("Value", url);
            e.setAttribute("XPath", element.buildXPath(null, 1) + "/@URL");
         }
      }

      private void printElementList(int indent_, KElement testElement, JDFElement part, VString elementVector, string whatType)
      {
         if (elementVector == null)
            return;

         elementVector.unify();
         int j;
         // String potDup=" : ";
         string potRef = " : ";
         if (whatType.Equals("Invalid"))
         {
            // potDup="- (potential duplicate): ";
            potRef = "- (potential reference to invalid element): ";
         }

         for (j = 0; j < elementVector.Count; j++)
         {
            string invalidElem = elementVector.stringAt(j);
            if (part.numChildElements(invalidElem, "") > 1)
            {
               sysOut.println(indent(indent_ + 2) + whatType + " Element " + potRef + invalidElem);
            }
            KElement ePart = part;
            KElement eInv = ePart.getElement(invalidElem, null, 0);
            if (eInv == null)
            {
               eInv = ePart.getElement(invalidElem + "Ref", null, 0);
               if (eInv != null)
               {
                  sysOut.println(indent(indent_ + 2) + whatType + " Element " + potRef + invalidElem + "Ref");
               }
            }
         }
         if (testElement != null && elementVector.Count > 0)
         {
            testElement.setAttribute(whatType + "Elements", StringUtil.setvString(elementVector, JDFConstants.BLANK, null, null));
         }
      }

      private void printAttributeList(int indent_, KElement testElement, JDFElement part, bool printMissElms, VString attributeVector, string whatType, string message)
      {
         string messageLocal = message;

         if (attributeVector == null)
            return;

         attributeVector.unify();
         string originalMessage = messageLocal;
         int j;
         for (j = 0; j < attributeVector.Count; j++)
         {
            messageLocal = originalMessage;
            string invalidAt = attributeVector[j];
            if (!((KElement)part).hasAttribute_KElement(invalidAt, "", false)) // exactly
            // this
            // node
            // (
            // e
            // .
            // g
            // .
            // ResourceElement
            // or
            // Leaf
            // )
            {
               if (EnumPartIDKey.getEnum(invalidAt) != null)
               {
                  // missing PartIDKeys are written into invalidAttributes
                  // vector
                  if (part.getAttribute(invalidAt, null, null) == null)
                  {
                     if (printMissElms)
                     {
                        KElement e = testElement.appendElement("TestAttribute");
                        setErrorType(e, "MissingAttribute", "Missing Partition key: " + invalidAt, indent_ + 2);
                        e.setAttribute("NodeName", invalidAt);
                        e.setAttribute("XPath", part.buildXPath(null, 1) + "/@" + invalidAt);
                     }
                  }
                  else
                  {
                     KElement e = testElement.appendElement("TestAttribute");
                     setErrorType(e, "InvalidAttribute", "Incorrectly placed Partition key: " + invalidAt, indent_ + 2);
                     e.setAttribute("NodeName", invalidAt);
                     e.setAttribute("XPath", part.buildXPath(null, 1) + "/@" + invalidAt);
                  }
               }
               else if (!part.hasAttribute(invalidAt, null, false)) // if the
               // resourceRoot
               // doesn
               // `t
               // have
               // it as
               // well
               {
                  if (printMissElms)
                  {
                     KElement e = testElement.appendElement("TestAttribute");
                     setErrorType(e, "MissingAttribute", "Missing required attribute: " + invalidAt, indent_ + 2);
                     e.setAttribute("NodeName", invalidAt);
                     e.setAttribute("XPath", part.buildXPath(null, 1) + "/@" + invalidAt);
                  }
               }
            }
            else
            {
               sysOut.println(indent(indent_ + 2) + whatType + " Attribute: " + invalidAt + " = " + part.getAttribute(invalidAt));
               KElement e = testElement.appendElement("TestAttribute");
               if (whatType.Equals("PreRelease"))
               {
                  EnumVersion v = part.getFirstVersion(invalidAt, false);
                  if (v != null)
                  {
                     e.setAttribute("FirstVersion", v.getName());
                     messageLocal += " First valid Version: " + v.getName();
                  }
               }
               else if (whatType.Equals("Deprecated"))
               {
                  EnumVersion v = part.getLastVersion(invalidAt, false);
                  if (v != null)
                  {
                     e.setAttribute("LastVersion", v.getName());
                     messageLocal += " Last valid Version: " + v.getName();
                  }
               }

               setErrorType(e, whatType + "Attribute", invalidAt + " " + messageLocal);
               e.setAttribute("NodeName", invalidAt);
               e.setAttribute("XPath", part.buildXPath(null, 1) + "/@" + invalidAt);
               e.setAttribute("Value", part.getAttribute(invalidAt));

            }
         }

         if (attributeVector.Count > 0)
         {
            testElement.setAttribute(whatType + "Attributes", StringUtil.setvString(attributeVector, JDFConstants.BLANK, null, null));
         }
      }

      ///   
      ///	 <summary> * For all subnodes that 'root' consist of makes the total check of Links, Resources and separations fill in the
      ///	 * vectors 'vLinkedResources', 'vResources', 'vBadResourceLinks', 'vColorPoolSeparations', 'vSeparations'. Print the
      ///	 * warnings
      ///	 *  </summary>
      ///	 * <param name="root"> - Node root we test </param>
      ///	 * <param name="bQuiet"> - Mode '-q' quiet </param>
      ///	 * <param name="level"> - validation level </param>
      ///	 * <param name="xmlParent"> - xmlParent for yml output of this check </param>
      ///	 
      private void printNodeRoot(JDFNode root, KElement xmlParent)
      {
         // get a vector with all jdf nodes and loop over all jdf nodes

         VElement vProcs = root.getvJDFNode(null, null, false);
         int i, j;
         int size = vProcs.Count;
         for (i = 0; i < size; i++)
         {
            JDFNode n = (JDFNode)vProcs[i];

            vLinkedResources.appendUnique(n.getLinkedResources(null, true));

            // find unlinked resources in ResourcePool
            JDFResourcePool rp = n.getResourcePool();
            if (rp != null)
            {
               VElement resources = rp.getPoolChildren(null, null, null);
               vResources.appendUnique(resources);
               int resSize = resources.Count;
               for (j = 0; j < resSize; j++)
               {
                  JDFResource jdfResource = (JDFResource)resources[j];
                  VElement vjdfResource = jdfResource.getvHRefRes(true, true);
                  vResources.appendUnique(vjdfResource);
               }
            }
            // add all invalid resource links in ResourcePool to
            // vBadResourceLinks
            JDFResourceLinkPool rlp = n.getResourceLinkPool();
            if (rlp != null)
            {
               VElement vLinks = rlp.getPoolChildren(null, null, null);
               if (vLinks != null)
               {
                  int size2 = vLinks.Count;
                  for (j = size2 - 1; j >= 0; j--)
                  {
                     JDFResourceLink rl = (JDFResourceLink)vLinks[j];
                     if (!n.isValidLink(level, rl, null, null))
                     {
                        vBadResourceLinks.appendUnique(rl);
                     }
                     else
                     {
                        JDFElement target = rl.getTarget();
                        if (target == null)
                        {
                           vBadResourceLinks.appendUnique(rl);
                        }
                     }
                  }
               }
            }
         }

         VElement vr = new VElement();
         for (i = 0; i < vResources.Count; i++)
         {
            JDFResource res = (JDFResource)vResources[i];
            vr.appendUnique(res.getResourceRoot());
         }
         vResources = new VElement(vr);

         vr.Clear();
         for (i = 0; i < vLinkedResources.Count; i++)
         {
            if ((vLinkedResources[i]) is JDFResource)
            {
               JDFResource linkedRes = (JDFResource)vLinkedResources[i];
               vr.appendUnique(linkedRes.getResourceRoot());
            }
         }
         vLinkedResources = new VElement(vr);

         KElement sepPool = null;
         if (xmlParent != null)
         {
            sepPool = xmlParent.appendElement("SeparationPool");
         }

         if (!bQuiet)
         {
            for (i = 0; i < vSeparations2.Count; i++)
            {
               sysOut.println("Separation Name: " + vSeparations2[i]);
               if (sepPool != null)
               {
                  KElement sep = sepPool.appendElement("Separation");
                  sep.setAttribute("SeparationName", vSeparations2.stringAt(i));
               }
            }
         }
         for (i = 0; i < vSeparations.Count; i++)
         {
            string sep = vSeparations.stringAt(i);
            sysOut.println("Warning: Separation Name not in ColorPool: " + sep);
            if (sepPool != null)
            {
               KElement warn = sepPool.appendElement("Warning");
               setErrorType(warn, "MissingSeparation", "Separation Name " + sep + " is not in ColorPool");
               warn.setAttribute("Separation", sep);
            }
         }
         for (i = 0; i < vColorPoolSeparations.Count; i++)
         {
            string sep = vColorPoolSeparations.stringAt(i);
            sysOut.println("Warning: Unreferenced Separation Name    : " + sep);
            if (sepPool != null)
            {
               KElement warn = sepPool.appendElement("Warning");
               setErrorType(warn, "UnreferencedSeparation", "Unreferenced Separation Name: " + sep + " in ColorPool");
               warn.setAttribute("Separation", sep);
            }
         }

         if (sepPool != null && !sepPool.hasChildElements() && xmlParent != null)
         {
            xmlParent.removeChild(sepPool);
         }

      }

      ///   
      ///	 <summary> * Print private contents
      ///	 *  </summary>
      ///	 * <param name="privateAttributes"> - vector of private attributes </param>
      ///	 * <param name="privateElements"> - vector of private elements </param>
      ///	 * <param name="jdfElement"> - jdfElement we test </param>
      ///	 * <param name="indent"> - indent for println() to console window </param>
      ///	 * <param name="testElement"> - test element of the XML output (if '-x' set) we "stand in" </param>
      ///	 
      private void printPrivate(VString privateAttributes, VString privateElements, KElement jdfElement, int indent_, KElement testElement)
      {
         int j;

         if (!privateAttributes.IsEmpty() || !privateElements.IsEmpty())
         {
            sysOut.println(indent(indent_) + "Element with private contents:   " + jdfElement.buildXPath(null, 1) + " " + jdfElement.getAttribute(AttributeName.ID, null, ""));

            if (testElement != null)
            {
               setErrorType(testElement, "PrivateContents", "Element with private contents");
               if (privateElements.Count > 0)
               {
                  testElement.setAttribute("PrivateElements", StringUtil.setvString(privateElements, JDFConstants.BLANK, null, null));
               }
            }
         }
         for (j = 0; j < privateAttributes.Count; j++)
         { // print all private parameters
            string privateAttribute = privateAttributes[j];
            string prefix = StringUtil.token(privateAttribute, 0, ":");
            string localname = StringUtil.token(privateAttribute, 1, ":");
            if (prefix != null && prefix.Equals("xmlns"))
            {
               if (!foundNameSpaces.Contains(privateAttribute))
               {
                  sysOut.println(indent(indent_ + 2) + "Foreign namespace found: " + localname + " " + jdfElement.getAttribute(privateAttribute));

                  if (testElement != null)
                  {
                     KElement e = testElement.appendElement("ForeignNSFound");
                     e.setAttribute("NSPrefix", localname);
                     e.setAttribute("NSURI", jdfElement.getAttribute(privateAttribute));
                  }
                  foundNameSpaces.Add(privateAttribute);
               }
            }
            else
            {
               sysOut.println(indent(indent_ + 2) + "Private Attribute:     " + prefix + " " + localname + " = " + jdfElement.getAttribute(privateAttribute));

               if (testElement != null)
               {
                  KElement e = testElement.appendElement("TestAttribute");
                  e.setAttribute("IsPrivate", "true");
                  e.setAttribute("NSPrefix", prefix);
                  e.setAttribute("NSURI", jdfElement.getNamespaceURIFromPrefix(prefix));
                  e.setAttribute("ErrorType", "PrivateAttribute");
                  e.setAttribute("NodeName", privateAttribute);
                  e.setAttribute("Value", jdfElement.getAttribute(privateAttribute));
                  e.setAttribute("XPath", jdfElement.buildXPath(null, 1) + "/@" + privateAttribute);
               }
            }
         }

         for (j = 0; j < privateElements.Count; j++)
         {
            sysOut.println(indent(indent_ + 2) + "Private Element:       " + privateElements.stringAt(j));

         }
      }

      ///   
      ///	 <summary> * Check a whole Node and print the problems if exist
      ///	 *  </summary>
      ///	 * <param name="jdfNode"> - JDFNode we check </param>
      ///	 * <param name="level"> - validation level </param>
      ///	 * <param name="indent"> - indent for println() to console window </param>
      ///	 * <param name="testElement"> - test element of the XML output (if '-x' set) we "stand in" </param>
      ///	 * <returns> boolean - true if valid </returns>
      ///	 
      private bool printNode(JDFNode jdfNode, int indent_, KElement testElement)
      {
         bool isValid = true;
         string jobPartID = jdfNode.getJobPartID(false);

         VString vMissingLinks = EnumValidationLevel.isRequired(level) ? jdfNode.getMissingLinkVector(9999999) : null;
         VString vInvalidLinks = jdfNode.getInvalidLinks(level, 9999999);

         bool bValidJobPartID = !vBadJobPartID.Contains(jobPartID);
         if (!bValidJobPartID)
         {
            KElement e = testElement.appendElement("TestAttribute");
            if (jobPartID.Equals(""))
            {
               setErrorType(e, "MissingAttribute", "Missing JobPartID - required by Base ICS", indent_);
            }
            else
            {
               setErrorType(e, "MultipleID", "Multiply defined JobPartID = " + jobPartID, indent_);
               e.setAttribute("Value", jobPartID);
            }
            e.setAttribute("NodeName", AttributeName.JOBPARTID);
            e.setAttribute("XPath", jdfNode.buildXPath(null, 1) + "/@JobPartID");
         }
         else
         {
            vJobPartID.Add(jobPartID);
         }

         isValid = checkType(jdfNode, indent_, testElement, isValid);

         if (vMissingLinks != null)
         {
            if (vInvalidLinks != null)
            {
               vInvalidLinks.removeStrings(vMissingLinks, 9999);
            }
            if (testElement != null && EnumValidationLevel.isRequired(level))
            {
               if (jdfNode.getElement(ElementName.RESOURCELINKPOOL, null, 0) == null)
               {
                  KElement pool = testElement.appendElement("TestElement");
                  setErrorType(pool, "MissingElement", "Missing ResourceLinkPool");
                  pool.setAttribute("NodeName", "ResourceLinkPool");
               }
               printResourceLinkPool(jdfNode.buildXPath(null, 1) + "/ResourceLinkPool[1]", testElement, vMissingLinks, "Missing");
            }
         }
         if (vInvalidLinks != null)
         {
            if (vInvalidLinks.Count > 0)
               printResourceLinkPool(jdfNode.buildXPath(null, 1) + "/ResourceLinkPool[1]", testElement, vInvalidLinks, "Invalid");
         }

         return isValid;
      }

      private bool checkType(JDFNode jdfNode, int indent_, KElement testElement, bool isValid)
      {
         bool isValidLocal = isValid;

         string errMessage = indent(indent_) + "!!! InValid Element: " + jdfNode.buildXPath(null, 1) + " " + jdfNode.getID() + " !!! ";
         if (jdfNode.hasAttribute(AttributeName.TYPE))
         {
            string typeString = jdfNode.getType();
            string nodeType = indent(indent_) + "Node Type = " + typeString;
            if (jdfNode.hasAttribute("Types", "", false))
            {
               nodeType += " - " + jdfNode.getAttribute("Types");
            }

            testElement.setAttribute("Type", typeString);
            if (jdfNode.hasAttribute("Types"))
            {
               testElement.setAttribute("Types", jdfNode.getAttribute("Types"));
               if (bPrintNameSpace && jdfNode.getEnumTypes() == null)
               {
                  VString vs = jdfNode.getTypes();
                  string msg = "";
                  int n = 0;
                  if (vs == null)
                  {
                     // illegal type for types
                  }
                  else
                  {
                     StringCollection aGBListCollection = new StringCollection();
                     aGBListCollection.AddRange(aGBList);

                     for (int i = 0; i < vs.Count; i++)
                     {
                        string t = vs.stringAt(i);
                        if (EnumType.getEnum(t) == null)
                        {
                           if (aGBListCollection.Contains(t))
                           {
                              continue;
                           }

                           if (n++ > 0)
                           {
                              msg += "; ";
                           }

                           msg += t;
                        }
                     }
                  }
                  if (n > 0)
                  {
                     KElement e = testElement.appendElement("TestAttribute");
                     setErrorType(e, "ExtensionType", "JDF/@Types contains extension types: " + msg, indent_ + 2);
                     e.setAttribute("XPath", jdfNode.buildXPath(null, 1) + "/@Types");
                     e.setAttribute("NodeName", "Types");
                     e.setAttribute("Value", msg);
                  }

               }
            }

            // check for virtual or extension types
            if (bPrintNameSpace && EnumType.getEnum(typeString) == null)
            {
               KElement e = testElement.appendElement("TestAttribute");
               setErrorType(e, "ExtensionType", "Type is an extension type: " + typeString, indent_ + 2);
               e.setAttribute("XPath", jdfNode.buildXPath(null, 1) + "/@Type");
               e.setAttribute("NodeName", "Type");
               e.setAttribute("Value", typeString);
            }

            if (typeString.Equals(JDFConstants.PRODUCT))
            {
               JDFNode n = jdfNode.getParentJDF();
               if (n != null)
               {
                  if (!JDFConstants.PRODUCT.Equals(n.getType()))
                  {
                     isValidLocal = false;
                     sysOut.println(errMessage);
                     sysOut.println(nodeType);
                     sysOut.println(indent(indent_) + "Invalid Parent for JDF Product: Type= " + n.getType());

                     setErrorType(testElement, "InvalidParentForProduct", "Invalid Parent for JDF Product: Type = " + n.getType());
                     testElement.setAttribute("NodeName", "JDF");
                     testElement.setAttribute("XPath", n.buildXPath(null, 1));
                  }
               }
            }
         }

         return isValidLocal;
      }

      ///   
      ///	 <summary> * Check ResourceLinkPool and print the problem if it contains missing resourceLinks
      ///	 *  </summary>
      ///	 * <param name="rlp"> - JDFResourceLinkPool we check </param>
      ///	 * <param name="level"> - validation level </param>
      ///	 * <param name="indent"> - indent for println() to console window </param>
      ///	 * <param name="testElement"> - test element of the XML output (if '-x' set) we "stand in" </param>
      ///	 * <returns> boolean - true if valid </returns>
      ///	 
      private void printResourceLinkPool(string rlpXPath, KElement testElement, VString vLinks, string missBad)
      {
         if (vLinks != null)
         {
            int size = vLinks.Count;
            for (int i = 0; i < size; i++)
            {
               string missResLink = vLinks.stringAt(0);
               if (testElement != null)
               {
                  KElement e = testElement.appendElement("TestElement");

                  string name = missResLink.IndexOf(":") > 0 ? StringUtil.token(missResLink, 0, ":") : missResLink;
                  string procUsage = missResLink.IndexOf(":") > 0 ? StringUtil.token(missResLink, 1, ":") : "";
                  if (procUsage.StartsWith("Any"))
                  {
                     procUsage = procUsage.Substring(3);
                  }

                  setErrorType(e, missBad + "ResourceLink", missBad + procUsage + " resourceLink ");
                  e.setAttribute("NodeName", name);
                  if (!procUsage.Equals(JDFConstants.EMPTYSTRING))
                  {
                     e.setAttribute("ProcessUsage", procUsage);
                  }

                  e.setAttribute("XPath", rlpXPath + "/" + name + "[1]");
               }

               vLinks.Remove(missResLink);
            }
         }
      }

      ///   
      ///	 <summary> * Check RefElements and print the problem if they are not valid
      ///	 *  </summary>
      ///	 * <param name="r"> - refElement we check </param>
      ///	 * <param name="level"> - validation level </param>
      ///	 * <param name="indent"> - indent for println() to console window </param>
      ///	 * <param name="testElement"> - test element of the XML output (if '-x' set) we "stand in" </param>
      ///	 * <returns> boolean - true if valid </returns>
      ///	 
      private bool printRefElement(JDFRefElement re, int indent_, KElement testElement)
      {
         bool isValid = true;
         string rRef = re.getrRef();
         string refName = re.Name;

         string errMessage = indent(indent_) + "!!! InValid Element: " + re.buildXPath(null, 1) + " !!! ";

         if (testElement != null)
         {
            testElement.setAttribute("rRef", rRef);
            if (re.hasAttribute(AttributeName.RSUBREF))
            {
               testElement.setAttribute("rSubRef", re.getrSubRef());
            }
         }

         if (vBadID.Contains(rRef))
         {
            isValid = false;
            sysOut.println(errMessage);
            sysOut.println(indent(indent_) + "Invalid RefElement: " + refName + ". Points to the element with multiply defined ID=" + rRef);
            setErrorType(testElement, "InvalidRefElement", "RefElement: " + refName + "Points to the multiply defined ID");
         }
         else
         {
            JDFResource targEl = re.getTarget();

            if (targEl == null)
            {

               isValid = false;
               sysOut.println(errMessage);
               sysOut.println(indent(indent_) + "Dangling RefElement: " + refName + " rRef=" + rRef);
               JDFResource targRoot = re.getTargetRoot();
               if (targRoot != null)
               {
                  sysOut.println(indent(indent_) + "Refelement points to non-existing partition: " + re.getPartMap().ToString());
               }

               if (testElement != null)
               {
                  if (targRoot == null)
                  {
                     setErrorType(testElement, "DanglingRefElement", "RefElement points to nonexisting ID. rRef=" + rRef);
                  }
                  else
                  {
                     setErrorType(testElement, "DanglingPartRefElement", "RefElement points to nonexisting Partition. rRef=" + rRef);
                     testElement.appendElement("Part").setAttributes(re.getPartMap());
                     testElement.setAttribute("ResourcePartUsage", targRoot.getPartUsage().getName(), null);
                  }
               }
            }
            else if (!re.isValid(level))
            {
               isValid = false;
               sysOut.println(errMessage);
               sysOut.println(indent(indent_) + "Invalid RefElement: " + refName + " rRef=" + rRef + (re.hasAttribute(AttributeName.RSUBREF) ? (" rSubRef=" + re.getrSubRef()) : JDFConstants.EMPTYSTRING) + ". Points to " + re.getRefNodeName() + " ID=" + targEl.getAttribute(AttributeName.ID, null, ""));

               if (!re.validResourcePosition())
               {
                  JDFNode targJDF = targEl.getParentJDF();
                  string targID = targJDF == null ? "" : targJDF.getID();
                  JDFNode refJDF = re.getParentJDF();
                  string refID = refJDF == null ? "" : refJDF.getID();
                  setErrorType(testElement, "InvalidRefElement", "Invalid Context: Resource node (ID=" + targID + ") is not an ancestor of RefElement node (ID=" + refID + ")", indent_);
               }
            }
         }
         return isValid;
      }

      ///   
      ///	 <summary> * Check Resources if they are not in the vector of linked resources 'vLinkedResources', print the problem
      ///	 *  </summary>
      ///	 * <param name="r"> - resource we check </param>
      ///	 * <param name="indent"> - indent for println() to console window </param>
      ///	 * <param name="testElement"> - test element of the XML output (if '-x' set) we "stand in" </param>
      ///	 * <returns> boolean - true if valid </returns>
      ///	 
      private bool printResource(JDFResource r, int indent_, KElement testElement)
      {
         bool isValid = true;

         if (vResources.Contains(r))
         {
            if (!vLinkedResources.Contains(r))
            {
               isValid = false;
               sysOut.println(indent(indent_) + "!!! InValid Element: " + r.buildXPath(null, 1) + " " + r.getID() + " !!! ");

               sysOut.println(indent(indent_) + "Unlinked Resource: " + r.Name + " " + r.getID());

               if (testElement != null)
               {
                  setErrorType(testElement, "UnlinkedResource", "Resource is not linked or referenced");
               }
            }
            vResources.Remove(r);
         }

         return isValid;
      }

      ///   
      ///	 <summary> * Check ResourceLinks if they are in the vector of bad resourceLinks 'vBadResourceLinks', print the problem
      ///	 *  </summary>
      ///	 * <param name="rl"> - resource link we check </param>
      ///	 * <param name="level"> - validation level </param>
      ///	 * <param name="indent"> - indent for println() to console window </param>
      ///	 * <param name="testElement"> - test element of the XML output (if '-x' set) we "stand in" </param>
      ///	 * <returns> boolean - true if valid </returns>
      ///	 
      private bool printResourceLink(JDFResourceLink rl, int indent_, KElement testElement)
      {
         bool isValid = true;
         if (vBadResourceLinks.Contains(rl))
         {
            string rRef = rl.getrRef();
            string resLinkName = rl.Name;
            string procUsage = (rl.hasAttribute(AttributeName.PROCESSUSAGE) && !rl.getProcessUsage().Equals(JDFConstants.EMPTYSTRING)) ? "(ProcessUsage:" + rl.getProcessUsage() + ")" : JDFConstants.EMPTYSTRING;

            string errMessage = indent(indent_) + "!!! InValid Element: " + rl.buildXPath(null, 1) + " !!! ";

            if (testElement != null)
            {
               setErrorType(testElement, "InvalidResourceLink", "Invalid ResourceLink");
               testElement.setAttribute("rRef", rRef);
               if (rl.getUsage() != null)
               {
                  testElement.setAttribute("Usage", rl.getUsage().getName());
               }
               if (rl.hasAttribute(AttributeName.PROCESSUSAGE) && !rl.getProcessUsage().Equals(JDFConstants.EMPTYSTRING))
               {
                  testElement.setAttribute("ProcessUsage", rl.getProcessUsage());
               }
            }

            if (vBadID.Contains(rRef))
            {
               isValid = false;
               sysOut.println(errMessage);
               sysOut.println(indent(indent_) + "Invalid " + rl.getAttribute("Usage") + " ResLink: " + resLinkName + procUsage + "\nrRef points to the multiply defined ID=\"" + rRef + "\"");
               if (testElement != null)
               {
                  setErrorType(testElement, "ResLinkMultipleID", "ResourceLink rRef points to the multiply defined ID:" + rRef);
               }
            }
            else
            // ID is ok
            {
               JDFResource res = rl.getTarget();
               if (res == null)
               { // print resource links which have no target
                  isValid = false;
                  sysOut.println(errMessage);
                  sysOut.println(indent(indent_) + "Dangling " + rl.getAttribute("Usage") + " ResLink: " + resLinkName + procUsage + " " + rRef);

                  JDFResource targRoot = rl.getLinkRoot();
                  if (targRoot != null)
                  {
                     sysOut.println(indent(indent_) + "Resource Link points to non-existing partition: " + rl.getPartMapVector().ToString());
                  }

                  if (testElement != null)
                  {
                     if (targRoot == null)
                     {
                        setErrorType(testElement, "DanglingResLink", "Dangling ResourceLink; no Resource with ID = " + rRef);
                     }
                     else
                     {
                        setErrorType(testElement, "DanglingPartResLink", "ResourceLink points to nonexisting Partition. rRef=" + rRef);
                        testElement.appendElement("Part").setAttributes(rl.getPartMapVector()[0]);
                        testElement.setAttribute("ResourcePartUsage", targRoot.getPartUsage().getName(), null);
                     }
                  }
               }
               else
               {
                  // print resource links which have an invalid target
                  isValid = false;
                  sysOut.println(errMessage);
                  sysOut.print(indent(indent_) + "Invalid " + rl.getAttribute("Usage") + " ResLink: " + resLinkName + procUsage + " " + rRef + ". ");

                  if (!rl.validResourcePosition())
                  {
                     string errStr = "Points to: " + res.Name + ". Resource Node (ID=" + res.getParentJDF().getID() + ") is not an ancestor of ResLink Node (ID=" + rl.getParentJDF().getID() + ")";

                     sysOut.print(errStr);
                     setErrorType(testElement, "InvalidPosition", errStr);
                  }
                  else if (rl.isValid(level)) // but !isValidLink()
                  {
                     string resName = res.LocalName;
                     VString strLinkNames = res.getParentJDF().linkNames();
                     if (strLinkNames != null && strLinkNames.IndexOf(resName) == -1)
                     {
                        sysOut.print(" Unknown ResLink for this Type of Process");
                        if (testElement != null)
                        {
                           setErrorType(testElement, "UnknownResourceLink", "Unknown ResourceLink for Process " + res.getParentJDF().getType());
                        }
                     }
                     else
                     {
                        JDFNode n = rl.getParentJDF();
                        if (!n.isValidLink(level, rl, null, null))
                        {
                           bool foundMissing = false;
                           if (!rl.hasAttribute(AttributeName.PROCESSUSAGE))
                           {
                              VString vMissingLinks = n.getMissingLinkVector(9999);
                              if (vMissingLinks != null)
                              {
                                 int missLinkSize = vMissingLinks.Count;
                                 for (int ii = 0; ii < missLinkSize; ii++)
                                 {
                                    VString vs = new VString(StringUtil.tokenize(vMissingLinks[ii], ":", false));
                                    if (vs.Count == 2)
                                    {
                                       string linkName = vs[0];
                                       if (linkName.Equals(rl.Name))
                                       {
                                          sysOut.print(" (Potential missing ProcessUsage: " + vs[1] + ")");
                                          setErrorType(testElement, "MissingProcessUsage", "Potential missing ProcessUsage: " + vs[1]);
                                          foundMissing = true;
                                       }
                                    }
                                 }
                              }

                              if (!foundMissing)
                              {
                                 setErrorType(testElement, "UnknownResourceLink", "Incorrect ResourceLink @Usage or @ProcessUsage for Process " + n.getType());
                              }
                           }
                        }
                        else
                        {
                           sysOut.print(" (Potentially ResLink has a wrong cardinality)");
                           if (testElement != null)
                           {
                              setErrorType(testElement, "ResLinkCardinality", "Potentially ResLink has a wrong cardinality");
                           }
                        }
                     }
                  }

                  sysOut.println();
               }
            }

            vBadResourceLinks.Remove(rl);
         }

         return isValid;
      }

      ///   
      ///	 <summary> * print Device Capabilities: executable nodes and bugReport if exist
      ///	 *  </summary>
      ///	 * <param name="jdfRoot"> - node to test </param>
      ///	 * <param name="devCapFile"> - Device Capabilities fileName to test Node against </param>
      ///	 * <param name="testlists"> - Allowed or Present testLists (parameter '-P') </param>
      ///	 * <param name="level"> - validation level </param>
      ///	 * <param name="testElement"> - root of the XMLStructure for DeviceCap </param>
      ///	 
      private void printDevCap(JDFElement jdfRoot, KElement testElement)
      {
         if (devCapFile == null || devCapFile.Equals(JDFConstants.EMPTYSTRING) || !(jdfRoot is JDFNode))
         {
            return;
         }

         JDFNode jdfNode = (JDFNode)jdfRoot;
         JDFParser p = new JDFParser();
         JDFDoc docDevCap = p.parseFile(devCapFile);

         JDFJMF jmfRoot = docDevCap.getJMFRoot();

         if (jmfRoot == null)
         {
            sysOut.println("JMFNode == null --> can't start Test");
            if (testElement != null)
            {
               KElement kEl = testElement.appendElement("Error");
               kEl.setAttribute("Message", "JMFNode == null. Can't start Test");
            }
            return;
         }

         JDFDeviceCap deviceCap = (JDFDeviceCap)jmfRoot.getChildByTagName("DeviceCap", null, 0, null, false, true);
         if (deviceCap == null)
         {
            sysOut.println("No DeviceCap element found --> can't start Test");
            if (testElement != null)
            {
               KElement kEl = testElement.appendElement("Error");
               kEl.setAttribute("Message", "No DeviceCap element found. Can't start Test");
            }
            return;
         }

         deviceCap.setIgnoreExtensions(!bPrintNameSpace);
         sysOut.println("\n**********************************************************");
         sysOut.println("\nOutput of DeviceCapability test result follows:\n");

         KElement execRoot = testElement.appendElement("ExecutableNodes");

         VElement vExecNodes = deviceCap.getExecutableJDF(jdfNode, testlists, level);
         if (vExecNodes != null)
         {
            sysOut.println("\nExecutable Nodes are:");
            for (int j = 0; j < vExecNodes.Count; j++)
            {
               JDFNode node = (JDFNode)vExecNodes[j];
               string id = node.getAttribute(AttributeName.ID);
               string descrName = node.getAttribute(AttributeName.DESCRIPTIVENAME, null, null);
               string xPath = node.buildXPath(null, 1);
               sysOut.println(xPath + " ID= " + id + " " + descrName);

               if (execRoot != null)
               {
                  KElement exNode = execRoot.appendElement("ExecutableNode");
                  exNode.setAttribute("XPath", xPath);
                  exNode.setAttribute("ID", id);
                  exNode.setAttribute("DescriptiveName", descrName);
               }
            }
            sysOut.println();
         }
         else
         {
            sysOut.println("\nNo executable nodes that fit device capabilities were found");
            if (execRoot != null)
            {
               execRoot.setAttribute("Message", "No Executable Nodes were found");
            }
         }

         XMLDoc testResult = deviceCap.getBadJDFInfo(jdfNode, testlists, level);
         if (testResult == null)
         {
            sysOut.println("\nResult of getBadJDFInfo: No bad JDF are found\n");
            KElement bugReportRoot = testElement.appendElement("BugReport");
            bugReportRoot.setAttribute("Message", "No bad JDF were found");
         }
         else
         {
            testElement.copyElement(testResult.getRoot(), null);
         }
      }

      ///   
      ///	 <summary> * print Device Capabilities: executable nodes and bugReport if exist
      ///	 *  </summary>
      ///	 * <param name="jdfRoot"> - node to test </param>
      ///	 * <param name="devCapFile"> - Device Capabilities fileName to test Node against </param>
      ///	 * <param name="testlists"> - Allowed or Present testLists (parameter '-P') </param>
      ///	 * <param name="level"> - validation level </param>
      ///	 * <param name="testElement"> - root of the XMLStructure for DeviceCap </param>
      ///	 
      private void printJMFDevCap(JDFElement jdfRoot, KElement testElement)
      {
         if (devCapFile == null || devCapFile.Equals(JDFConstants.EMPTYSTRING) || !(jdfRoot is JDFJMF))
         {
            return;
         }

         JDFJMF jdfNode = (JDFJMF)jdfRoot;
         JDFParser p = new JDFParser();
         JDFDoc docDevCap = p.parseFile(devCapFile);

         JDFJMF jmfRoot = docDevCap.getJMFRoot();

         if (jmfRoot == null)
         {
            sysOut.println("JMFNode == null --> can't start Test");
            if (testElement != null)
            {
               KElement kEl = testElement.appendElement("Error");
               kEl.setAttribute("Message", "JMFNode == null. Can't start Test");
            }
            return;
         }
         sysOut.println("\n**********************************************************");
         sysOut.println("\nOutput of DeviceCapability test result follows:\n");

         // final XMLDoc testResult = deviceCap.getBadJDFInfo(jdfNode, testlists,
         // level);

         XMLDoc testResult = JDFDeviceCap.getJMFInfo(jdfNode, jmfRoot.getResponse(0), testlists, level, !bPrintNameSpace);

         if (testResult == null)
         {
            sysOut.println("\nResult of getBadJDFInfo: No bad JDF are found\n");
            KElement bugReportRoot = testElement.appendElement("BugReport");
            bugReportRoot.setAttribute("Message", "No bad JDF were found");
         }
         else
         {
            KElement jRoot = testElement.copyElement(testResult.getRoot(), null);
            if (!jRoot.getBoolAttribute("IsValid", null, true))
               testElement.setAttribute("IsValid", false, null);
            sysOut.println("\nResult of getBadJDFInfo: " + testResult.ToString());

         }
      }

      ///   
      ///	 <summary> * Sets correct validation status of the nodes that has invalid entries. E.g. if ResourcePool has invalid children
      ///	 * sets its status as invalid ["IsValid" = false].
      ///	 * 
      ///	 * Check the Validation Status of all children for Mode [bQuiet=true] and if there are no invalid child nodes and it
      ///	 * has no private contents - removes valid entries
      ///	 *  </summary>
      ///	 * <param name="root"> - xml output root. </param>
      ///	 * <param name="bQuiet"> - mode is quiet set by "-q" </param>
      ///	 
      private void removeValidEntriesIfQuiet(KElement root, bool bRoot)
      {
         if (root == null)
         {
            return;
         }
         JDFAttributeMap mInv = new JDFAttributeMap("IsValid", "false");
         JDFAttributeMap mVal = new JDFAttributeMap("IsValid", "true");
         VElement vEl = root.getChildElementVector_KElement(null, null, null, true, 0);
         bool bValid = true;
         for (int i = vEl.Count - 1; i >= 0; i--)
         {
            KElement el = vEl[i];
            // ignore separationpools etc - only TestElement and TestAttribute
            // are important
            if (el == null || !el.LocalName.StartsWith("Test"))
            {
               continue;
            }

            if (el.hasAttribute("IsValid") && el.getBoolAttribute("IsValid", null, false)) // has
            // attr
            // "Valid"
            // and
            // Valid=
            // true
            {
               KElement invChild = el.getChildByTagName(null, null, 0, mInv, false, true); // found
               // invalid
               // children
               if (invChild == null)
               {
                  if (bQuiet)
                  {
                     string eName = el.LocalName;
                     JDFAttributeMap mPrivate = new JDFAttributeMap();
                     mPrivate.put("HasPrivateContents", "true");
                     mPrivate.put("IsPrivate", "true");

                     removeValidEntriesIfQuiet(el, false);

                     if (!el.getBoolAttribute("HasPrivateContents", null, false) && eName != "ForeignNSFound" && (el.getChildByTagName(null, null, 0, mPrivate, false, false) == null))
                     {
                        el.deleteNode(); // if node is valid and bQuiet is
                        // true - remove it
                     }
                  }
               }
               else
               { // if node "el" contains invalid nodes, set it as invalid.
                  removeValidEntriesIfQuiet(el, false);
                  KElement valChild = el.getChildByTagName(null, null, 0, null, false, true);
                  if (valChild != null && !el.hasAttribute("ErrorType"))
                  {
                     setErrorType(el, "InvalidElement", "Element is not valid, see child elements for details");
                     el.setAttribute("IsValid", false, null);
                     bValid = false;
                  }
               }
            }
            else
            {
               bValid = false;
               KElement valChild = el.getChildByTagName(null, null, 0, mVal, false, true);
               if (valChild != null)
               {
                  removeValidEntriesIfQuiet(el, false);
               }
               valChild = el.getChildByTagName(null, null, 0, mVal, false, true);
               if (valChild != null && !el.hasAttribute("ErrorType"))
               {
                  setErrorType(el, "InvalidElement", "Element is not valid, see child elements for details");
               }
            }
         }
         if (!bValid && bRoot)
         {
            root.setAttribute("IsValid", false, null);
         }
      }

      ///   
      ///	 <summary> * Parses file and if schemaLocation is not null validates against Schema.
      ///	 *  </summary>
      ///	 * <param name="xmlFile"> - File Name to parse </param>
      ///	 * <param name="schemaLocation"> - schema location </param>
      ///	 * <param name="errorHandler"> - error handler </param>
      ///	 * <returns> JDFDoc - parsed JDFDoc, if null - exception is caught </returns>
      ///	 
      private JDFDoc parseFile(string xmlFile, XMLErrorHandler errorHandler)
      {
         JDFDoc gd = null;
         JDFParser p = new JDFParser();
         p.m_SchemaLocation = schemaLocation;
         p.m_ErrorHandler = errorHandler;

         gd = p.parseFile(xmlFile);
         if (gd == null && !bTryFormats)
         {
            sysOut.println("Error parsing File: " + xmlFile);
         }

         return gd;
      }

      ///   
      ///	 * @deprecated use setJDFSchemaLocation(File) 
      ///	 * <param name="_schemaLocation"> </param>
      ///	 
      [Obsolete("use setJDFSchemaLocation(File)")]
      public virtual void setJDFSchemaLocation(string _schemaLocation)
      {
         setJDFSchemaLocation(new FileInfo(_schemaLocation).FullName);
      }

      ///   
      ///	 * <param name="_schemaLocation"> the schema location </param>
      ///	 
      public virtual void setJDFSchemaLocation(FileInfo _schemaLocation)
      {
         if ((_schemaLocation != null) && (_schemaLocation.Length != 0))
         {
            string fileToUrl = UrlUtil.fileToUrl(_schemaLocation, false);
            schemaLocation = "http://www.CIP4.org/JDFSchema_1_1 " + fileToUrl;
         }
      }

      ///   
      ///	 <summary> * processes all files that have been placed into the public VString member JDFValidator.allFiles
      ///	 *  </summary>
      ///	 * <returns> XMLDoc the xml output document </returns>
      ///	 
      public virtual XMLDoc processAllFiles()
      {
         if (allFiles == null)
         {
            return null;
         }

         inOutputLoop = true;
         for (int arg = 0; arg < allFiles.Count; arg++)
         {
            string xmlFile = allFiles.stringAt(arg);
            VString vFiles = new VString();
            FileInfo argFile = new FileInfo(xmlFile);
            if (Directory.Exists(argFile.FullName))
            {
               FileInfo[] lFiles = argFile.Directory.GetFiles();
               for (int i = 0; i < lFiles.Length; i++)
               {
                  FileInfo fil = lFiles[i];
                  if (Directory.Exists(fil.FullName))
                  {
                     continue;
                  }
                  // Java to C# Conversion - NOTE: No .NET equivalent for canRead()
                  if (fil.Exists)
                  {
                     vFiles.Add(fil.FullName);
                  }
               }
            }
            else if (xmlFile.ToLower().EndsWith(".zip"))
            {
               processZipFile(argFile);
            }
            else if (xmlFile.ToLower().EndsWith(".mjm"))
            {
               try
               {
                  ProcessMimeStream(new FileStream(argFile.FullName, FileMode.Open));
               }
               catch (FileNotFoundException)
               {
                  // nop
               }
            }
            else
            {
               vFiles.Add(xmlFile);
            }
            for (int ff = 0; ff < vFiles.Count; ff++)
            {
               xmlFile = vFiles[ff];
               processSingleFile(xmlFile);
            }
         }
         inOutputLoop = false;
         finalizeOutput();
         return pOut;

      }

      private void finalizeOutput()
      {
         if (inOutputLoop)
            return;
         if (xmlOutputName != null && xmlOutputName.Length > 0)
         {
            if (xslStyleSheet != null)
            {
               pOut.setXSLTURL(xslStyleSheet);
               if (translation != null)
               {
                  pOut.getRoot().setAttribute("Language", translation);
               }
            }
            pOut.write2File(xmlOutputName, 2, false);
         }
      }

      ///   
      ///	 <summary> * we may want to create something similar for a zip stream
      ///	 *  </summary>
      ///	 * <param name="argFile"> </param>
      ///	 * <returns> XMLDoc the output file </returns>
      ///	 
      public virtual XMLDoc processZipFile(FileInfo argFile)
      {
         throw new NotImplementedException();

         // TODO: Java to C# Conversion.  
         //    Although .NET Framework include GZipSteam class for compressing and decompressing files,
         //    is does not include handler for ZIP file collections.  
         //    There are publicly available .NET based DLLs (i.e. http://dotnetzip.codeplex.com/) that will handle this
         //    if the JDFLib architects decide to include the DLL and and associated license in the JDFLib distribution.

         //bool bTryKeep = bTryFormats;
         //try
         //{
         //   ZipFile zip = new ZipFile(argFile);
         //   System.Collections.IEnumerator zipEnum = zip.entries();
         //   while (zipEnum.MoveNext())
         //   {
         //      ZipEntry ze = (ZipEntry)zipEnum.Current;
         //      string nam = ze.getName();
         //      // TODO handle non-ascii
         //      if (!ze.isDirectory())
         //      {
         //         Stream inStream = zip.getInputStream(ze);
         //         processSingleStream(inStream, nam, null);
         //         bTryKeep = bTryKeep && bTryFormats;
         //      }
         //   }
         //}
         //catch (ZipException)
         //{
         //   if (!bTryFormats)
         //   {
         //      KElement testFileRoot = pOut.getRoot().appendElement("TestFile");
         //      testFileRoot = testFileRoot.appendElement("Error");
         //      testFileRoot.setAttribute("Message", "Invalid zip file, Bailing out!");
         //      sysOut.println("Invalid zip file, Bailing out!");
         //   }
         //}
         //catch (IOException)
         //{
         //   if (!bTryFormats)
         //   {
         //      KElement testFileRoot = pOut.getRoot().appendElement("TestFile");
         //      testFileRoot = testFileRoot.appendElement("Error");
         //      testFileRoot.setAttribute("Message", "I/O Exception on zip file, Bailing out!");
         //      sysOut.println("I/O Exception on zip file, Bailing out!");
         //   }
         //}
         //bTryFormats = bTryKeep;
         //return pOut;
      }

         
      /// <summary>
      ///  Process a mime file
      /// </summary>
      /// <param name="inStream">Stream containing MIME file data</param>
      /// <returns>XML Document or null if not found or error</returns>
      /// 
      public virtual XMLDoc ProcessMimeStream(Stream inStream)
      {
         AttachmentCollection multi = MimeUtil.GetMultiPart(inStream);
         bool bTryKeep = bTryFormats;
         if (multi == null)
         {
            return null;
         }
         int count;
         try
         {
            count = multi.Count;
         }
         catch (HttpException)
         {
            // can't count - it must be crap
            return null;
         }

         for (int i = 0; i < count; i++)
         {
            try
            {
               Attachment bp = multi[i];
               if (bp != null)
               {
                  Stream bpStream;
                  bpStream = bp.ContentStream;
                  string fiName = bp.Name;
                  string contentType = bp.ContentType.Name;
                  if (MimeUtil.IsJDFMimeType(contentType))
                  {
                     processSingleStream(bpStream, fiName, bp);
                     bTryKeep = bTryKeep && bTryFormats;
                  }
                  else
                  {
                     sysOut.println("Mime extraction Skipping: " + fiName);
                  }
               }
            }
            catch (IOException)
            {
               // nop and continue
            }
            catch (HttpException)
            {
               // nop and continue
            }
         }
         bTryFormats = bTryKeep;
         return pOut;
      }

      ///   
      ///	 <summary> * process a single document as specified by doc if doc==null, reprocess the currently stored document
      ///	 *  </summary>
      ///	 * <param name="doc"> the parsed document to process </param>
      ///	 * <returns> the xml output of the validation </returns>
      ///	 
      public virtual XMLDoc processSingleDocument(JDFDoc doc)
      {
         if (doc != null)
         {
            theDoc = doc;
         }
         return processSingleFile(null, null, null, null);
      }

      ///   
      ///	 <summary> * process a single document as specified by doc if doc==null, reprocess the currently stored document
      ///	 *  </summary>
      ///	 * <param name="doc"> the parsed document to process </param>
      ///	 * <returns> the xml output of the validation </returns>
      ///	 
      public virtual bool isValid(JDFDoc doc)
      {
         if (doc != null)
         {
            theDoc = doc;
         }
         XMLDoc d = processSingleFile(null, null, null, null);
         if (d == null)
            return false;
         KElement testFile = d.getRoot().getElement("TestFile", null, -1);
         if (testFile == null)
            return false;
         return "true".Equals(testFile.getXPathAttribute("CheckJDFOutput/@IsValid", null));
      }

      ///   
      ///	 <summary> * process a single document as specified by doc
      ///	 *  </summary>
      ///	 * <param name="stream"> the input stream </param>
      ///	 * <param name="url"> the url that the stream is sent to
      ///	 *  </param>
      ///	 * <returns> the xml output of the validation </returns>
      ///	 
      public virtual XMLDoc processSingleURLStream(Stream stream, string url)
      {
         theDoc = null;
         return processSingleFile(stream, url, null, null);
      }

      ///   
      ///	 <summary> * process a single document as specified by doc
      ///	 *  </summary>
      ///	 * <param name="stream"> the input stream </param>
      ///	 * <param name="fileName"> the fileName that the stream originated from
      ///	 *  </param>
      ///	 * <returns> the xml output of the validation </returns>
      ///	 
      public virtual XMLDoc processSingleStream(Stream stream, string fileName, Attachment bp)
      {
         theDoc = null;
         return processSingleFile(stream, null, fileName, bp);
      }

      ///   
      ///	 <summary> * process a single file document as specified by fileName
      ///	 *  </summary>
      ///	 * <param name="fileName"> the path of the file to parse and validate </param>
      ///	 * <returns> the xml output of the validation </returns>
      ///	 
      public virtual XMLDoc processSingleFile(string fileName)
      {
         theDoc = null;
         FileInfo file = new FileInfo(fileName);
         // Java to C# Conversion - NOTE: No .NET equivalent for canRead()
         bTryFormats = file.Exists;

         XMLDoc d = processSingleFile(null, null, fileName, null);
         if (!bTryFormats)
         {
            return d;
         }
         if (bTryFormats)
         {
            d = processZipFile(file);
         }
         if (bTryFormats)
         {
            try
            {
               d = ProcessMimeStream(new FileStream(file.FullName, FileMode.Open));
            }
            catch (FileNotFoundException)
            {
               // nop
            }
         }
         return d;
      }

      ///   
      ///	 <summary> * processes a single file
      ///	 *  </summary>
      ///	 * <param name="inStream"> </param>
      ///	 * <param name="url"> </param>
      ///	 * <param name="xmlFile">
      ///	 * @return </param>
      ///	 * @deprecated - use either processSingleDoc, processSingleStream or processSinglFile(String) this will be made
      ///	 *             private 
      ///	 
      [Obsolete("- use either processSingleDoc, processSingleStream or processSinglFile(String) this will be made")]
      public virtual XMLDoc processSingleFile(Stream inStream, string url, string xmlFile)
      {
         return processSingleFile(inStream, url, xmlFile, null);
      }

      ///   
      ///	 <summary> * processes a single file
      ///	 *  </summary>
      ///	 * <param name="inStream"> </param>
      ///	 * <param name="url"> </param>
      ///	 * <param name="xmlFile">
      ///	 * @return </param>
      ///	 
      protected internal virtual XMLDoc processSingleFile(Stream inStream, string url, string xmlFile, Attachment bp)
      {
         KElement testFileRoot = pOut.getRoot().appendElement("TestFile");
         if (inStream == null && url == null && xmlFile == null && theDoc == null)
         {
            testFileRoot = testFileRoot.appendElement("Error");
            testFileRoot.setAttribute("Message", "No input URL, stream or file. Bailing out!");
            sysOut.println("No input URL, stream or file. Bailing out!");
            return pOut;
         }

         // reset all per file
         foundNameSpaces = new VString();
         vID.Clear();
         vBadID.Clear();
         vJobPartID.Clear();
         vJobPartID.Add("");
         vResources.Clear();
         vLinkedResources.Clear();
         vBadResourceLinks = new VElement();
         vSeparations = new VString();
         vSeparations2 = new VString();
         vColorPoolSeparations = new VString();

         // measure the time
         long lSchemaValidationTime = 0;
         long lCheckJDFTime = 0;
         long lTotalTime = 0;
         long lDevCapsTime = 0;
         long lStartTime = (System.DateTime.Now.Ticks - 621355968000000000) / 10000;
         long lEndTime = 0;
         long lStartTime_SchemaValidation = 0;
         long lEndTime_SchemaValidation = 0;
         long lStartTime_InternalCheckJDF = 0;
         long lEndTime_InternalCheckJDF = 0;

         if (!bQuiet)
         {
            sysOut.println("\n**********************************************************");
            sysOut.println("       *** Checking " + xmlFile == null ? "JDFDoc" : xmlFile + " *** ");
            if (url != null && url.Length > 0)
            {
               sysOut.println("           " + url);
            }
            sysOut.println("**********************************************************\n");
         }

         if (xmlFile != null)
         {
            testFileRoot.setAttribute("FileName", xmlFile);
         }

         if (url != null && url.Length > 0)
         {
            testFileRoot.setAttribute("URL", url);
         }

         try
         { // measure the time of parsing
            lStartTime_SchemaValidation = (System.DateTime.Now.Ticks - 621355968000000000) / 10000; //.currentTimeMillis();

            if (bValidate)
            {
               sysOut.println("\n**********************************************************");
               sysOut.println("\nOutput of the XERCES schema validation follows:\n");
            }

            // Here we Parse file 'xmlFile' and validate it against Schema
            // 'schemaLocation'.
            // We will not use JDFDoc 'gd' for internal JDFValidator and DevCaps
            // test
            // but create new one JDFDoc 'doc' with schemaLocation = null,
            // otherwise we will have non-existent errors caused by schema
            // validation !!!
            if (theDoc == null)
            {
               if (inStream == null)
               {
                  theDoc = parseFile(xmlFile, null);
               }
               else
               {
                  JDFParser p = new JDFParser();
                  p.m_SchemaLocation = schemaLocation;
                  theDoc = p.parseStream(inStream);
                  if (theDoc != null)
                  {
                     theDoc.setBodyPart(bp);
                  }
               }
            }
            bTryFormats = bTryFormats && theDoc == null;

            // measure the time of parsing
            lEndTime_SchemaValidation = System.DateTime.Now.Ticks; //.currentTimeMillis();

            if (theDoc == null)
            {
               if (bTryFormats)
               {
                  testFileRoot.deleteNode();
               }
               else
               {
                  KElement kEl = testFileRoot.appendElement("Error");
                  kEl.setAttribute("Message", "File " + xmlFile + " not found or not parsed");
               }
            }
            else
            {
               XMLDoc schemaValOutput = theDoc.getValidationResult();

               KElement schemaValRoot = null;
               if (schemaValOutput == null)
               {
                  schemaValRoot = testFileRoot.appendElement("SchemaValidationOutput");
               }
               else
               {
                  testFileRoot.copyElement(schemaValOutput.getRoot(), null);
                  schemaValRoot = testFileRoot.getElement("SchemaValidationOutput", null, 0);
               }

               if (bTiming)
               {
                  lSchemaValidationTime = lEndTime_SchemaValidation - lStartTime_SchemaValidation;

                  if (schemaValRoot != null)
                  {
                     schemaValRoot.setAttribute("ValidationTime", lSchemaValidationTime + " ms");
                  }
               }

               processURL(url);

               if (theDoc != null)
               {

                  // measure the time of internal JDFValidator
                  lStartTime_InternalCheckJDF = (System.DateTime.Now.Ticks - 621355968000000000) / 10000; //.currentTimeMillis();

                  if (bValidate)
                  {
                     sysOut.println("\n**********************************************************\n");
                     sysOut.println("Output of checkJDF proper follows:\n");
                  }

                  KElement checkJDFxmlRoot = testFileRoot.appendElement("CheckJDFOutput");

                  // JDFDoc doc for internal JDFValidator and Test against
                  // DevCaps. Important - WITHOUT SCHEMA VALIDATION!
                  JDFNode root = theDoc.getJDFRoot();
                  JDFJMF jmf = theDoc.getJMFRoot();

                  if (root != null && jmf != null)
                  { // find the correct root, if there is a jdf and a jmf
                     if (jmf.isAncestor(root))
                     {
                        root = null;
                     }
                     else
                     {
                        jmf = null;
                     }
                  }

                  if (root == null)
                  { // no jdf, maybe jmf
                     if (jmf != null)
                     {
                        printMultipleIDs(url, xmlFile, jmf, checkJDFxmlRoot);

                        printBad(jmf, 0, checkJDFxmlRoot, true);
                        printJMFDevCap(jmf, checkJDFxmlRoot);
                     }
                     else
                     {
                        checkJDFxmlRoot.setAttribute("FoundJDF", false, null);
                     }
                  }
                  else
                  { // we have a jdf
                     printMultipleIDs(url, xmlFile, root, checkJDFxmlRoot);

                     VElement allElms = root.getChildrenByTagName(null, null, null, false, true, 0);
                     allElms.Add(root);
                     int size = allElms.Count;
                     for (int i = 0; i < size; i++)
                     {
                        KElement e = allElms.item(i);

                        if (e.hasAttribute_KElement(AttributeName.ID, null, false))
                        {
                           string id = e.getAttribute(AttributeName.ID, null, "");
                           if (vID.Contains(id))
                           {
                              vBadID.Add(id);
                           }
                           else
                           {
                              vID.Add(id);
                           }
                        }

                        if (e.hasAttribute(AttributeName.SEPARATION))
                        {
                           string separation = e.getAttribute(AttributeName.SEPARATION);
                           if (!separation.Equals("All"))
                           {
                              vSeparations.appendUnique(separation);
                           }
                        }

                        if (e.LocalName.Equals(ElementName.SEPARATIONSPEC))
                        {
                           if (!e.ParentNode.LocalName.Equals(ElementName.COLORANTALIAS))
                           {
                              vSeparations.appendUnique(e.getAttribute(AttributeName.NAME));
                           }
                        }

                        if (e.LocalName.Equals(ElementName.COLOR))
                        {
                           if (e.ParentNode.LocalName.Equals(ElementName.COLORPOOL))
                           {
                              vColorPoolSeparations.appendUnique(e.getAttribute(AttributeName.NAME));
                           }
                        }
                        if (e is JDFNode)
                        {
                           JDFNode n = (JDFNode)e;
                           string jobPartID = n.getJobPartID(false);
                           if (vJobPartID.Contains(jobPartID))
                           {
                              vBadJobPartID.appendUnique(jobPartID);
                           }
                           else
                           {
                              vJobPartID.Add(jobPartID);
                           }
                        }
                     }

                     vSeparations2 = new VString(vSeparations);
                     vSeparations.removeStrings(vColorPoolSeparations, int.MaxValue);
                     vColorPoolSeparations.removeStrings(vSeparations2, int.MaxValue);

                     printBad(root, 0, checkJDFxmlRoot, true);

                     lDevCapsTime = evalDevCaps(testFileRoot, lDevCapsTime, root);
                  }

                  // clean up the output
                  removeValidEntriesIfQuiet(checkJDFxmlRoot, true);
                  if (!checkJDFxmlRoot.hasAttributes() && !checkJDFxmlRoot.hasChildElements())
                  {
                     checkJDFxmlRoot.setAttribute("IsValid", true, null);
                  }
                  lEndTime_InternalCheckJDF = (System.DateTime.Now.Ticks - 621355968000000000) / 10000; //.currentTimeMillis();

                  if (bTiming)
                  {
                     lCheckJDFTime = lEndTime_InternalCheckJDF - lStartTime_InternalCheckJDF;
                     checkJDFxmlRoot.setAttribute("InternalCheckJDFTime", lCheckJDFTime + " ms");
                  }
               }
            }
         }
         catch (JDFException e)
         {
            sysOut.println("Caught Exception: " + e.Message);
            KElement er = testFileRoot.appendElement("Error");
            er.setAttribute("Message", "Caught Exception: " + e.Message);
         }

         sysOut.println("\n**********************************************************");

         // measure the total time for this File
         lEndTime = (System.DateTime.Now.Ticks - 621355968000000000) / 10000; //.currentTimeMillis();

         if (bTiming)
         {
            sysOut.println("Schema Validation time = " + lSchemaValidationTime + " ms");
            sysOut.println("Internal checkJDF time = " + lCheckJDFTime + " ms");

            lTotalTime = lEndTime - lStartTime;
            sysOut.println("Total time = " + lTotalTime + " ms");

            testFileRoot.setAttribute("TotalTime", lTotalTime + " ms");
            if (lDevCapsTime > 0)
            {
               sysOut.println("DeviceCapabilities Test time = " + lDevCapsTime + " ms");
            }
         }
         finalizeOutput();
         return pOut;
      }

      private long evalDevCaps(KElement testFileRoot, long lDevCapsTime, JDFElement root)
      {
         long lDevCapsTimeLocal = lDevCapsTime;

         long lStartTime_TestDevCap;
         long lEndTime_TestDevCap;
         if (devCapFile != null)
         {
            // measure the time
            lStartTime_TestDevCap = (System.DateTime.Now.Ticks - 621355968000000000) / 10000; //.currentTimeMillis();

            KElement devCapTest = testFileRoot.appendElement("DeviceCapTest");

            printDevCap(root, devCapTest);

            lEndTime_TestDevCap = (System.DateTime.Now.Ticks - 621355968000000000) / 10000; //.currentTimeMillis();
            lDevCapsTimeLocal = (lEndTime_TestDevCap - lStartTime_TestDevCap);
            if (bTiming && devCapTest != null)
            {
               devCapTest.setAttribute("DeviceCapTestTime", lDevCapsTimeLocal + " ms");
            }
         }

         return lDevCapsTimeLocal;
      }

      private void printMultipleIDs(string url, string xmlFile, KElement root, KElement outRoot)
      {
         KElement outRootLocal = outRoot;

         if (bMultiID)
         {
            if (bQuiet)
            {
               sysOut.println("\n**********************************************************");
               sysOut.println("       *** Checking " + xmlFile == null ? "JDFDoc" : xmlFile + " *** ");
               if (url != null && url.Length > 0)
               {
                  sysOut.println("           " + url);
               }

               sysOut.println("**********************************************************\n");
            }

            vMultiID = root.getMultipleIDs("ID");
            if (vMultiID != null)
            {
               if (outRootLocal != null)
               {
                  outRootLocal = outRootLocal.appendElement("MultiIDs");
                  outRootLocal.setAttribute("IsValid", false, null);
               }

               sysOut.println("Multiple ID elements:\n");
               for (int i = 0; i < vMultiID.Count; i++)
               {
                  string id = vMultiID.stringAt(i);
                  VElement v = root.getChildrenByTagName(null, null, new JDFAttributeMap("ID", id), false, true, 0);
                  if (id.Equals(root.getAttribute("ID")))
                  {
                     v.Add(root);
                  }

                  for (int ii = 0; ii < v.Count; ii++)
                  {
                     KElement e = v.item(ii);
                     sysOut.println(id + " \t:" + e.buildXPath(null, 2));
                     if (outRootLocal != null)
                     {
                        KElement idRoot = outRootLocal.getChildWithAttribute("MultiID", "ID", null, e.getAttribute("ID"), 0, true);
                        if (idRoot == null)
                           idRoot = outRootLocal.appendElement("MultiID");
                        idRoot.setAttribute("ID", e.getAttribute("ID"));
                        KElement idInst = idRoot.appendElement("IDInstance");
                        idInst.setAttribute("XPath", e.buildXPath(null, 2));
                        idInst.setAttribute("Name", e.Name);
                     }
                  }
               }
            }
            else
            {
               sysOut.println("No Multiple ID elements!");
            }
         }
      }


      private void processURL(string url)
      {
         if (url != null)
         {
            if (proxyHost != null)
            {
               // Java to C# Conversion - TODO: How is this implemented in .NET?
               //System.setProperty("http.proxyHost", proxyHost);
               if (proxyPort == null)
               {
                  proxyPort = "8080";
               }
               // Java to C# Conversion - TODO: How is this implemented in .NET?
               //System.setProperty("http.proxyPort", proxyPort);
            }
            theDoc = (JDFDoc)theDoc.write2URL(url, theDoc.getContentType());
         }
      }


      protected internal virtual void setAllFiles(MyArgs args)
      {
         for (int arg = 0; arg < args.nargs(); arg++)
         {
            string xmlFile = args.argumentString(arg);
            addFile(xmlFile);
         }
      }

      public virtual void addFile(string xmlFile)
      {
         if (allFiles == null)
         {
            allFiles = new VString();
         }
         FileInfo argFile = new FileInfo(xmlFile);
         // Java to C# Conversion - NOTE: No .NET equivalent for canRead()
         if (argFile.Exists)
         {
            allFiles.appendUnique(xmlFile);
         }
         else
         {
            sysOut.println("File not found: " + argFile.FullName);
            KElement xmlRoot = pOut.getRoot();
            KElement testFileRoot = xmlRoot.appendElement("TestFile");
            testFileRoot.setAttribute("FileName", xmlFile);
            testFileRoot.setAttribute("Message", "Could not find file: " + xmlFile);
         }
      }


      ///   
      ///	 <summary> * This is just a quick and dirty class to centrally switch print on and off
      ///	 * 
      ///	 * @author prosirai
      ///	 *  </summary>
      ///	 
      protected internal class MySysOut
      {

         internal bool wannaPrint = true;

         public virtual void setPrint(bool b)
         {
            wannaPrint = b;
         }

         public virtual void println(string @string)
         {
            if (!wannaPrint)
            {
               return;
            }
            Console.WriteLine(@string);
         }

         public virtual void println()
         {
            if (!wannaPrint)
            {
               return;
            }
            Console.WriteLine();

         }

         public virtual void print(string @string)
         {
            if (!wannaPrint)
            {
               return;
            }
            Console.WriteLine(@string);
         }
      }

      ///   
      ///	 * <returns> the bWarning </returns>
      ///	 
      public virtual bool isBWarning()
      {
         return bWarning;
      }

      ///   
      ///	 * <param name="warning"> the bWarning to set </param>
      ///	 
      public virtual void setWarning(bool warning)
      {
         bWarning = warning;
         level = EnumValidationLevel.setNoWarning(level, !warning);
      }

      ///   
      ///	 * <param name="validatorFactory"> the validatorFactory to set </param>
      ///	 
      public virtual void setValidatorFactory(ICheckValidatorFactory pvalidatorFactory)
      {
         this.validatorFactory = pvalidatorFactory;
      }
   }
}
