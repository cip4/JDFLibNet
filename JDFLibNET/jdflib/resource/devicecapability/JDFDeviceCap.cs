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
 * Copyright (c) 2001 Heidelberger Druckmaschinen AG, All Rights Reserved.
 * JDFDeviceCap.cs
 * @author Elena Skobchenko
 */

namespace org.cip4.jdflib.resource.devicecapability
{
   using System.Collections;
   using System.Collections.Generic;


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   using JDFAutoDeviceCap = org.cip4.jdflib.auto.JDFAutoDeviceCap;
   using EnumContext = org.cip4.jdflib.auto.JDFAutoDevCaps.EnumContext;
   using EnumJMFRole = org.cip4.jdflib.auto.JDFAutoMessageService.EnumJMFRole;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using XMLDoc = org.cip4.jdflib.core.XMLDoc;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using EnumFitsValue = org.cip4.jdflib.datatypes.EnumFitsValue;
   using ICapabilityElement = org.cip4.jdflib.ifaces.ICapabilityElement;
   using IDeviceCapable = org.cip4.jdflib.ifaces.IDeviceCapable;
   using JDFJMF = org.cip4.jdflib.jmf.JDFJMF;
   using JDFMessage = org.cip4.jdflib.jmf.JDFMessage;
   using JDFMessageService = org.cip4.jdflib.jmf.JDFMessageService;
   using JDFResponse = org.cip4.jdflib.jmf.JDFResponse;
   using EnumFamily = org.cip4.jdflib.jmf.JDFMessage.EnumFamily;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using EnumProcessUsage = org.cip4.jdflib.node.JDFNode.EnumProcessUsage;
   using EnumType = org.cip4.jdflib.node.JDFNode.EnumType;
   using StringUtil = org.cip4.jdflib.util.StringUtil;

   public class JDFDeviceCap : JDFAutoDeviceCap, IDeviceCapable
   {
      ///   
      ///     <summary> *  </summary>
      ///     
      public const string FITS_TYPE = "FitsType";
      private new const long serialVersionUID = 1L;
      private bool ignoreExtensions = false;
      private bool ignoreDefaults = false;
      private org.cip4.jdflib.util.VectorMap<int, JDFResource> setResMap = null;

      ///   
      ///	 <summary> * Constructor for JDFDeviceCap
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFDeviceCap(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFDeviceCap
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFDeviceCap(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFDeviceCap
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFDeviceCap(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[13];
      static JDFDeviceCap()
      {
         elemInfoTable[0] = new ElemInfoTable(ElementName.BOOLEANSTATE, 0x33333111);
         elemInfoTable[1] = new ElemInfoTable(ElementName.DATETIMESTATE, 0x33333111);
         elemInfoTable[2] = new ElemInfoTable(ElementName.DURATIONSTATE, 0x33333111);
         elemInfoTable[3] = new ElemInfoTable(ElementName.ENUMERATIONSTATE, 0x33333111);
         elemInfoTable[4] = new ElemInfoTable(ElementName.INTEGERSTATE, 0x33333111);
         elemInfoTable[5] = new ElemInfoTable(ElementName.MATRIXSTATE, 0x33333111);
         elemInfoTable[6] = new ElemInfoTable(ElementName.NAMESTATE, 0x33333111);
         elemInfoTable[7] = new ElemInfoTable(ElementName.NUMBERSTATE, 0x33333111);
         elemInfoTable[8] = new ElemInfoTable(ElementName.PDFPATHSTATE, 0x33333111);
         elemInfoTable[9] = new ElemInfoTable(ElementName.RECTANGLESTATE, 0x33333111);
         elemInfoTable[10] = new ElemInfoTable(ElementName.SHAPESTATE, 0x33333111);
         elemInfoTable[11] = new ElemInfoTable(ElementName.STRINGSTATE, 0x33333111);
         elemInfoTable[12] = new ElemInfoTable(ElementName.XYPAIRSTATE, 0x33333111);
      }

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }

      // **************************************** Methods
      // *********************************************
      ///   
      ///	 <summary> * toString - StringRepresentation of JDFNode
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public override string ToString()
      {
         return "JDFDeviceCap[  --> " + base.ToString() + " ]";
      }

      public class EnumAvailability : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumAvailability(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumAvailability getEnum(string enumName)
         {
            return (EnumAvailability)getEnum(typeof(EnumAvailability), enumName);
         }

         public static EnumAvailability getEnum(int enumValue)
         {
            return (EnumAvailability)getEnum(typeof(EnumAvailability), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumAvailability));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumAvailability));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumAvailability));
         }

         public static readonly EnumAvailability NotInstalled = new EnumAvailability("NotInstalled");
         public static readonly EnumAvailability NotLicensed = new EnumAvailability("NotLicensed");
         public static readonly EnumAvailability Disabled = new EnumAvailability("Disabled");
         public static readonly EnumAvailability Installed = new EnumAvailability("Installed");
         public static readonly EnumAvailability Module = new EnumAvailability("Module");
      }

      ///   
      ///	 <summary> * Gets of this string attribute <code>TypeExpression</code> if it exists,
      ///	 * otherwise returns the literal string defined in Types
      ///	 *  </summary>
      ///	 * <returns> String - TypeExpression attribute value </returns>
      ///	 
      public override string getTypeExpression()
      {
         if (hasAttribute(AttributeName.TYPEEXPRESSION))
         {
            return base.getTypeExpression();
         }
         return getAttribute(AttributeName.TYPES);
      }

      ///   
      ///	 <summary> * (9.2) get CombinedMethod attribute <code>CombinedMethod</code>
      ///	 *  </summary>
      ///	 * <returns> Vector of the enumerations </returns>
      ///	 
      public override List<ValuedEnum> getCombinedMethod()
      {
         List<ValuedEnum> v = getEnumerationsAttribute(AttributeName.COMBINEDMETHOD, null, EnumCombinedMethod.None, false);
         if (v == null)
         {
            v = new List<ValuedEnum>();
            v.Add(EnumCombinedMethod.None);
         }
         return v;
      }

      public VString getNamePathVector()
      {
         VString vResult = new VString();
         vResult.Add(ElementName.JDF);

         return vResult;
      }

      //   
      //	 * // FitsValue Methods
      //	 

      ///   
      ///	 <summary> * Gets of jdfRoot a vector of all executable nodes (jdf root or children
      ///	 * nodes that this Device may execute)
      ///	 *  </summary>
      ///	 * <param name="jdfRoot">
      ///	 *            the node we test </param>
      ///	 * <param name="testlists">
      ///	 *            testlists that are specified for the State elements
      ///	 *            (FitsValue_Allowed or FitsValue_Present)<br>
      ///	 *            Will be used in fitsValue method of the State class. </param>
      ///	 * <param name="level">
      ///	 *            validation level </param>
      ///	 * <returns> VElement - vector of executable JDFNodes, null if none found </returns>
      ///	 
      public VElement getExecutableJDF(JDFNode jdfRoot, EnumFitsValue testlists, EnumValidationLevel level)
      {
         VElement execNodes = new VElement();
         EnumExecutionPolicy execPolicy = getExecutionPolicy();

         // here vNodes is jdfRoot + all children
         VElement vNodes = null;
         if (execPolicy.Equals(EnumExecutionPolicy.RootNode))
         {
            vNodes = new VElement();
            vNodes.Add(jdfRoot);
         }
         else
         {
            vNodes = jdfRoot.getvJDFNode(null, null, false);
         }
         XMLDoc d = new XMLDoc("dummy", null);
         for (int i = 0; i < vNodes.Count; i++)
         {
            JDFNode n = (JDFNode)vNodes[i];
            KElement root = d.getRoot();

            try
            {
               KElement nOutput = report(n, testlists, level, root); // if
               // report
               // throws
               // exception
               // - n
               // is
               // non-
               // executable
               // Node
               if (nOutput == null)
               {
                  execNodes.Add(n);
               }
            }
            catch (JDFException)
            {
               // nop
            }
         }
         return execNodes.IsEmpty() ? null : execNodes;
      }

      ///   
      ///	 <summary> * Composes a BugReport in XML form for the given JDFNode 'jdfRoot'. Gives a
      ///	 * list of error messages for 'jdfRoot' and every child rejected Node.<br>
      ///	 * Returns <code>null</code> if there are no errors.
      ///	 *  </summary>
      ///	 * <param name="jdfRoot">
      ///	 *            the node to test </param>
      ///	 * <param name="testlists">
      ///	 *            testlists that are specified for the State elements
      ///	 *            (FitsValue_Allowed or FitsValue_Present)<br>
      ///	 *            Will be used in fitsValue method of the State class. </param>
      ///	 * <param name="level">
      ///	 *            validation level </param>
      ///	 * <returns> XMLDoc - XMLDoc output of the error messages. If XMLDoc is null
      ///	 *         there are no errors. </returns>
      ///	 
      public XMLDoc getBadJDFInfo(JDFNode jdfRoot, EnumFitsValue testlists, EnumValidationLevel level)
      {
         XMLDoc bugReport = new XMLDoc("BugReport", null);
         KElement outputRoot = bugReport.getRoot();
         VElement vNodes = jdfRoot.getvJDFNode(null, null, false);

         int size = vNodes.Count;
         for (int i = 0; i < size; i++)
         {
            JDFNode n = (JDFNode)vNodes[i];
            KElement report_ = null;
            try
            {
               report_ = report(n, testlists, level, outputRoot);
            }
            catch (JDFException jdfe)
            {
               report_ = outputRoot.appendElement("RejectedNode");
               report_.setAttribute("CaughtException", jdfe.Message);
               report_.setAttribute("ID", n.getID());
               report_.setAttribute("XPath", n.buildXPath(null, 1));
            }
         }

         if (!outputRoot.HasChildNodes)
            bugReport = null;

         return bugReport;
      }

      ///   
      ///	 <summary> * Composes a BugReport in XML form for the given JMF message 'jmfRoot'.
      ///	 * Gives a list of error messages for 'jmfRoot' and every child rejected
      ///	 * element.<br>
      ///	 * Returns <code>null</code> if there are no errors.
      ///	 *  </summary>
      ///	 * <param name="jdfRoot">
      ///	 *            the node to test </param>
      ///	 * <param name="testlists">
      ///	 *            testlists that are specified for the State elements
      ///	 *            (FitsValue_Allowed or FitsValue_Present)<br>
      ///	 *            Will be used in fitsValue method of the State class. </param>
      ///	 * <param name="level">
      ///	 *            validation level </param>
      ///	 * <returns> XMLDoc - XMLDoc output of the error messages. If XMLDoc is null
      ///	 *         there are no errors. </returns>
      ///	 
      public static XMLDoc getJMFInfo(JDFJMF jmfRoot, JDFResponse knownMessagesResp, EnumFitsValue testlists, EnumValidationLevel level, bool ignoreExtensions)
      {
         XMLDoc bugReport = new XMLDoc("JMFReport", null);
         KElement parentRoot = bugReport.getRoot();

         int nBad = 0;
         if (!jmfRoot.isValid(level))
         {
            parentRoot.setAttribute("IsValid", false, null);
         }
         VElement messages = jmfRoot.getMessageVector(null, null);

         for (int i = 0; i < messages.Count; i++)
         {
            KElement messageReport = parentRoot.appendElement("InvalidMessage");
            JDFMessage m = (JDFMessage)messages[i];
            string typeJMF = m.getType();
            messageReport.setAttribute("MessageType", typeJMF);
            messageReport.setAttribute("XPath", m.buildXPath(null, 1));
            messageReport.setAttribute("ID", m.getID());
            JDFMessageService ms = getMessageServiceForJMFType(m, knownMessagesResp);
            if (ms != null)
            {
               messageReport.setAttribute(FITS_TYPE, true, null);
               invalidDevCaps(ms, m, testlists, level, messageReport, ignoreExtensions);
               actionPoolReport(ms, m, messageReport);
            }
            else
            {
               messageReport.setAttribute(FITS_TYPE, false, null);
               // TODO root.setAttribute("CapsType",typeExp);
               messageReport.setAttribute("Message", "JMF  Type: " + typeJMF + " does not match capabilities type: ");
            }

            if (!messageReport.hasChildElements() && messageReport.getBoolAttribute(FITS_TYPE, null, true))
            {
               messageReport.renameElement("ValidMessage", null);
            }
            else
            {
               nBad++;
            }
         }
         parentRoot.setAttribute("IsValid", nBad == 0, null);
         return bugReport;
      }

      ///   
      ///	 * <param name="m">
      ///	 *            the message to test </param>
      ///	 * <param name="knownMessagesResp">
      ///	 *            the Response that contains the relevant devcap fo the jmf
      ///	 *  </param>
      ///	 * <returns> the JMFMessageService element for this message based on family
      ///	 *         and type </returns>
      ///	 
      public static JDFMessageService getMessageServiceForJMFType(JDFMessage m, JDFResponse knownMessagesResp)
      {
         if (knownMessagesResp == null || !knownMessagesResp.getType().Equals("KnownMessages") || m == null || m.getType().Equals(""))
            return null;
         JDFAttributeMap map = new JDFAttributeMap(AttributeName.TYPE, m.getType());
         // now add the family selection method
         EnumFamily fam = m.getFamily();
         if (fam != null)
         {
            if (EnumFamily.Response.Equals(fam))
               map.put("JMFRole", EnumJMFRole.Sender);
            else
               map.put(fam.getName(), "true");

         }
         return (JDFMessageService)knownMessagesResp.getChildByTagName(ElementName.MESSAGESERVICE, null, 0, map, true, true);
      }

      ///   
      ///	 <summary> * Checks if Device can execute the given JDFNode 'jdfRoot'.<br>
      ///	 * First validates 'jdfRoot' and checks if its Type/Types attributes fit the
      ///	 * values of DeviceCap/@Types and DeviceCap/@CombinedMethod. If Node is
      ///	 * invalid or Type/Types don't fit it doesn't check it more detailed.<br>
      ///	 * If Type/Types fit, the whole JDFNode - all elements and attributes - will
      ///	 * be tested iot check if a Device can accept it.<br>
      ///	 * This method composes a detailed report of the found errors in XML form,
      ///	 * if jdfRoot is rejected.<br>
      ///	 * If XMLDoc is null, there are no errors and 'jdfRoot' is accepted
      ///	 *  </summary>
      ///	 * <param name="jdfRoot">
      ///	 *            the node to test </param>
      ///	 * <param name="fitsValue">
      ///	 *            testlists that are specified for the State elements
      ///	 *            (FitsValue_Allowed or FitsValue_Present)<br>
      ///	 *            Will be used in fitsValue method of the State class. </param>
      ///	 * <param name="level">
      ///	 *            validation level </param>
      ///	 * <returns> XMLDoc - XMLDoc output of the error messages. If XMLDoc is
      ///	 *         <code>null</code> there are no errors, 'jdfRoot' is accepted
      ///	 *  </returns>
      ///	 * <exception cref="JDFException">
      ///	 *             if DeviceCapabilities file is invalid: illegal value of
      ///	 *             Types(TypeExpression) attribute (if CombinedMethod is None
      ///	 *             and Types contains more than 1 process) </exception>
      ///	 * <exception cref="JDFException">
      ///	 *             if DeviceCapabilities file is invalid: illegal value of
      ///	 *             CombinedMethod attribute </exception>
      ///	 
      private KElement report(JDFNode jdfRoot, EnumFitsValue fitsValue, EnumValidationLevel level, KElement parentRoot)
      {
         KElement root = parentRoot.appendElement("RejectedNode");
         root.setAttribute("XPath", jdfRoot.buildXPath(null, 1));
         root.setAttribute("ID", jdfRoot.getID());
         string typeExp = getTypeExpression();

         if (!jdfRoot.isValid(level))
         {
            root.setAttribute("IsValid", false, null);
         }
         string badState = misMatchingStates(jdfRoot);
         if (!matchesType(jdfRoot, true) || badState != null)
         {
            string typeNode = jdfRoot.getType();
            reportTypeMatch(root, false, typeNode, typeExp);
            if (badState != null)
            {
               root.setAttribute("BadStateName", badState);
               root.setAttribute("BadStateValue", jdfRoot.getAttribute(badState, null, null));
               root.copyElement(getState(badState), null);
            }
            return root;
         }

         root = groupReport(jdfRoot, fitsValue, level, root);
         // TODO ???
         if (!root.hasChildElements() && root.getBoolAttribute(FITS_TYPE, null, true))
         {
            root.deleteNode();
            root = null;
         }
         return root;
      }

      ///   
      ///	 * <param name="jdfRoot">
      ///	 * @return </param>
      ///	 
      private string misMatchingStates(JDFNode jdfRoot)
      {
         VElement vStates = getStates();
         if (vStates == null)
            return null; // no additional matching
         for (int i = 0; i < vStates.Count; i++)
         {
            JDFAbstractState state = (JDFAbstractState)vStates[i];
            string attName = state.getName();
            if (!state.fitsValue(jdfRoot.getAttribute(attName, null, null), EnumFitsValue.Present))
               return attName;
         }
         return null; // all matched
      }

      ///   
      ///	 <summary> * test whether a given node has the corect Types and Type Attribute
      ///	 *  </summary>
      ///	 * <param name="testRoot">
      ///	 *            the JDF or JMF to test </param>
      ///	 * <param name="bLocal">
      ///	 *            if true, only check the root of this, else check children as
      ///	 *            well
      ///	 *  </param>
      ///	 * <returns> boolean - true if this DeviceCaps TypeExpression fits
      ///	 *         testRoot/@Type and testRoot/@Types
      ///	 *  </returns>
      ///	 
      public virtual bool matchesType(JDFNode testRoot, bool bLocal)
      {
         VElement v = getMatchingTypeNodeVector(testRoot);
         if (v == null)
            return false;
         if (bLocal)
            return v.Contains(testRoot);
         return true;
      }

      ///   
      ///	 <summary> * test whether a given node has the corect Types and Type Attribute
      ///	 *  </summary>
      ///	 * <param name="testRoot">
      ///	 *            the JDF or JMF to test
      ///	 *  </param>
      ///	 * <returns> VElement - the list of matching JDF nodes, null if none found
      ///	 *  </returns>
      ///	 
      public virtual VElement getMatchingTypeNodeVector(JDFNode testRoot)
      {
         if (testRoot == null || !testRoot.hasAttribute(AttributeName.TYPE))
            return null;
         VElement v = new VElement();
         string typeNode = testRoot.getType();

         List<ValuedEnum> vCombMethod = getCombinedMethod();
         string typeExp = getTypeExpression();
         for (int j = 0; j < vCombMethod.Count; j++)
         {
            EnumCombinedMethod combMethod = (EnumCombinedMethod)vCombMethod[j];

            if (combMethod.Equals(EnumCombinedMethod.None)) // node is an
            // individual
            // process
            {
               if (StringUtil.matches(typeNode, typeExp))
               {
                  v.Add(testRoot);
               }
            }
            else if (combMethod.Equals(EnumCombinedMethod.Combined) || combMethod.Equals(EnumCombinedMethod.CombinedProcessGroup) && typeNode.Equals("Combined"))
            {
               if (fitsTypes(testRoot.getAllTypes(), false))
               {
                  v.Add(testRoot);
               }
            }
            else if (combMethod.Equals(EnumCombinedMethod.GrayBox) || combMethod.Equals(EnumCombinedMethod.CombinedProcessGroup) && typeNode.Equals("ProcessGroup") && !testRoot.isGroupNode())
            {
               if (fitsTypes(testRoot.getAllTypes(), true))
               {
                  v.Add(testRoot);
               }
            }
            else if (combMethod.Equals(EnumCombinedMethod.ProcessGroup) || combMethod.Equals(EnumCombinedMethod.CombinedProcessGroup) && typeNode.Equals("ProcessGroup"))
            {
               VElement vNodes = testRoot.getvJDFNode(null, null, false);
               int size = vNodes.Count;
               for (int i = 0; i < size - 1; i++) // note the 1 which skips
               // this
               {
                  JDFNode node = (JDFNode)vNodes[i];
                  if (node.isGroupNode())
                  {
                     VElement matchingTypeNodeVector = getMatchingTypeNodeVector(node);
                     if (matchingTypeNodeVector != null)
                        v.AddRange(matchingTypeNodeVector);
                  }
                  else if (fitsTypes(node.getAllTypes(), true))
                  {
                     v.Add(node);
                  }
               }
            }
            else
            {
               throw new JDFException("JDFDeviceCap.report: Invalid DeviceCap: illegal value of CombinedMethod attribute");
            }
         }
         v.unify();
         return v.Count == 0 ? null : v;
      }

      private void reportTypeMatch(KElement report, bool matches, string typeNode, string typeExp)
      {
         report.setAttribute(FITS_TYPE, matches, null);
         report.setAttribute("NodeType", typeNode);
         report.setAttribute("CapsType", typeExp);
         report.copyAttribute(AttributeName.DESCRIPTIVENAME, this, null, null, null);
         report.setAttribute("CapXPath", buildXPath(null, 2));

         if (!matches)
            report.setAttribute("Message", "Node Type: " + typeNode + " does not match capabilities type: " + typeExp);
      }

      ///   
      ///	 <summary> * Tests JDFNode/@Types (or its equivalent of Types in the ProcessGroupNodes
      ///	 * - the concatenated string of all Type attributes in the children Nodes)
      ///	 * iot check whether it matches DeviceCap/@Types or DeviceCap/@TypeExpression
      ///	 *  </summary>
      ///	 * <param name="typesNode">
      ///	 *            attribute Types of the tested JDFNode </param>
      ///	 * <param name="bSubset">
      ///	 *            if true, a match is sufficient if a subset is specified </param>
      ///	 * <returns> boolean - true if JDFNode/@Types fits DeviceCap/@Types or
      ///	 *         DeviceCap/@TypeExpression </returns>
      ///	 * <exception cref="JDFException">
      ///	 *             if DeviceCap is invalid: both @Types and @TypeExpression are
      ///	 *             missing </exception>
      ///	 
      private bool fitsTypes(VString typesNode, bool bSubset)
      {
         if (typesNode == null || typesNode.IsEmpty())
            return false;
         if (!bSubset)
         {
            if (hasAttribute(AttributeName.TYPEEXPRESSION))
            {
               string typeExp = getTypeExpression();
               string typesNodeStr = StringUtil.setvString(typesNode, JDFConstants.BLANK, null, null);
               return StringUtil.matches(typesNodeStr, typeExp);
            }
            return typesNode.Equals(getTypes());
         }

         VString dcTypes = getTypes();
         for (int i = 0; i < typesNode.Count; i++)
         {
            string type = typesNode.stringAt(i);
            if (!dcTypes.Contains(type))
               return false;
         }
         return true;
      }

      ///   
      ///	 <summary> * Checks whether a device can execute the given ProcessGroup JDFNode
      ///	 * 'jdfRoot' (JDFNode/@Type=ProcessGroup). If JDFNode/@Types fits
      ///	 * DeviceCap/@Types, the whole JDFNode - all elements and attributes - is
      ///	 * tested iot check whether a device can accept it.<br>
      ///	 * Composes a detailed report of the found errors in XML form, if JDFNode is
      ///	 * rejected.
      ///	 *  </summary>
      ///	 * <param name="jdfRoot">
      ///	 *            the node to test </param>
      ///	 * <param name="testlists">
      ///	 *            testlists that are specified for the State elements
      ///	 *            (FitsValue_Allowed or FitsValue_Present)<br>
      ///	 *            Will be used in fitsValue method of the State class. </param>
      ///	 * <param name="level">
      ///	 *            validation level
      ///	 *  </param>
      ///	 * <returns> XMLDoc - XMLDoc output of the error messages. <br>
      ///	 *         If XMLDoc is <code>null</code> there are no errors, 'jdfRoot' is
      ///	 *         accepted </returns>
      ///	 
      private KElement groupReport(JDFNode jdfRoot, EnumFitsValue testlists, EnumValidationLevel level, KElement parentRoot)
      {
         parentRoot.setAttribute("XPath", jdfRoot.buildXPath(null, 1));
         parentRoot.setAttribute("ID", jdfRoot.getID());

         VElement vNodes = getMatchingTypeNodeVector(jdfRoot);
         if (vNodes == null)
         {
            parentRoot.setAttribute(FITS_TYPE, false, null);
         }
         else
         {
            parentRoot.setAttribute(FITS_TYPE, true, null);

            // check the status of all child nodes
            for (int i = 0; i < vNodes.Count - 1; i++)
            {
               JDFNode n = (JDFNode)vNodes[i];
               KElement childRoot = devCapsReport(n, testlists, level, parentRoot);
               if (childRoot != null)
               {
                  childRoot.setAttribute("XPath", n.buildXPath(null, 1));
                  childRoot.setAttribute("ID", n.getID());
               }
            }
            devCapsReport(jdfRoot, testlists, level, parentRoot);
         }
         return parentRoot;
      }

      ///   
      ///	 <summary> * devCapsReport - searches in JDFNode for appropriate elements for every
      ///	 * DevCaps element that DeviceCap consists of, and tests them.<br>
      ///	 * Composes a detailed report of the found errors in XML form.<br>
      ///	 * If XMLDoc is <code>null</code> there are no errors
      ///	 *  </summary>
      ///	 * <param name="jdfRoot">
      ///	 *            the node we test </param>
      ///	 * <param name="testlists">
      ///	 *            testlists that are specified for the State elements
      ///	 *            (FitsValue_Allowed or FitsValue_Present)<br>
      ///	 *            Will be used in fitsValue method of the State class. </param>
      ///	 * <param name="level">
      ///	 *            validation level </param>
      ///	 * <returns> XMLDoc - XMLDoc output of the error messages. If XMLDoc is
      ///	 *         <code>null</code> there are no errors, 'jdfRoot' is accepted </returns>
      ///	 
      private KElement devCapsReport(JDFNode jdfRoot, EnumFitsValue testlists, EnumValidationLevel level, KElement parentRoot)
      {
         // first test if there are in the JDFNode any ResourceLink or
         // NodeInfo/CustomerInfo
         // that are not described by DevCaps
         KElement root = parentRoot.appendElement("RejectedChildNode");

         if (!ignoreExtensions)
            noFoundDevCaps(jdfRoot, root);

         // if all resourceLinks and NodeInfo/CustomerInfo elements (optional)
         // are specified as DevCaps, we may test them.
         invalidDevCaps(this, jdfRoot, testlists, level, root, ignoreExtensions);
         actionPoolReport(this, jdfRoot, root);
         if (!root.hasChildElements())
         {
            root.deleteNode();
            root = null;
         }
         return root;
      }

      ///   
      ///	 <summary> * invalidDevCaps - tests if there are any invalid or missing Resources or
      ///	 * NodeInfo/CustomerInfo elements in the JDFNode.<br>
      ///	 * Composes a detailed report of the found errors in XML form. If XMLDoc is
      ///	 * <code>null</code> there are no errors.
      ///	 *  </summary>
      ///	 * <param name="parent">
      ///	 *            the devcaps parent element </param>
      ///	 * <param name="jdfRoot">
      ///	 *            node or jmf message element we test </param>
      ///	 * <returns> boolean - true if invalid devcaps were found </returns>
      ///	 * <exception cref="JDFException">
      ///	 *             if DeviceCap is invalid: has a wrong attribute Context value </exception>
      ///	 
      private static bool invalidDevCaps(KElement parent, KElement jdfRoot, EnumFitsValue testlists, EnumValidationLevel level, KElement parentReport, bool ignoreExtensions)
      {
         KElement mrp = parentReport.appendElement((jdfRoot is JDFNode) ? "MissingResources" : "MissingElements");
         KElement irp = parentReport.appendElement((jdfRoot is JDFNode) ? "InvalidResources" : "InvalidElements");
         VElement vDevCaps = parent.getChildElementVector(ElementName.DEVCAPS, null, null, true, 0, false);
         int size = vDevCaps.Count;
         SupportClass.HashSetSupport goodElems = new SupportClass.HashSetSupport();
         Hashtable badElems = new Hashtable();

         for (int i = 0; i < size; i++)
         {
            JDFDevCaps devCaps = (JDFDevCaps)vDevCaps[i];
            devCaps.analyzeDevCaps(jdfRoot, testlists, level, mrp, irp, goodElems, badElems, ignoreExtensions);
         }

         bool bRet = mrp.hasChildElements() || irp.hasChildElements();
         if (!mrp.hasChildElements())
            mrp.deleteNode();

         if (!irp.hasChildElements())
            irp.deleteNode();

         return bRet;
      }

      ///   
      ///	 <summary> * missingDevCaps - tests if there are any Resources or
      ///	 * NodeInfo/CustomerInfo elements in the JDFNode, which are not described by
      ///	 * DevCaps.<br>
      ///	 * If missing DevCaps are found, jdfRoot has elements unknown for this
      ///	 * Device resources or elements.<br>
      ///	 * Composes a detailed report of the found errors in XML form. If XMLDoc is
      ///	 * <code>null</code> there are no errors.
      ///	 *  </summary>
      ///	 * <param name="jdfRoot">
      ///	 *            node to test </param>
      ///	 * <returns> XMLDoc - XMLDoc output of the error messages. If XMLDoc is
      ///	 *         <code>null</code> there are no errors </returns>
      ///	 
      private KElement noFoundDevCaps(JDFNode jdfRoot, KElement parentReport)
      {
         KElement root = parentReport.appendElement("UnknownResources");
         VElement vLinks = jdfRoot.getResourceLinks(null);
         if (vLinks != null)
         {
            int linkSize = vLinks.Count;
            for (int j = 0; j < linkSize; j++)
            {
               JDFResourceLink link = (JDFResourceLink)vLinks[j];
               string resName = link.getLinkedResourceName();
               string processUsage = link.getProcessUsage();

               JDFAttributeMap map = new JDFAttributeMap(AttributeName.NAME, resName);
               VElement vDevCaps = getChildElementVector(ElementName.DEVCAPS, null, map, true, 0, false);

               bool bFound = false;
               int size = vDevCaps.Count;
               for (int k = 0; k < size && !bFound; k++)
               {
                  JDFDevCaps dc = (JDFDevCaps)vDevCaps[k];
                  if ((!dc.hasAttribute(AttributeName.LINKUSAGE) || dc.getLinkUsage().getName().Equals(link.getUsage().getName())) && (dc.getProcessUsage().Equals(processUsage)))
                  {
                     bFound = true;
                  }
               }
               if (!bFound)
               { // no DevCaps with Name=resName and the corresponding LinkUsage
                  // were found
                  KElement r = root.appendElement("UnknownResource");
                  r.setAttribute("XPath", link.buildXPath(null, 1));
                  r.setAttribute("Name", resName);
                  if (link.hasAttribute(AttributeName.USAGE, null, false) && !link.getUsage().getName().Equals("Unknown"))
                  {
                     r.setAttribute("Usage", link.getUsage().getName());
                  }
                  r.setAttribute("Message", "Found no DevCaps description for this resource");
               }
            }
         }

         checkNodeInfoCustomerInfo(jdfRoot, root, ElementName.NODEINFO);
         checkNodeInfoCustomerInfo(jdfRoot, root, ElementName.CUSTOMERINFO);
         checkNodeInfoCustomerInfo(jdfRoot, root, ElementName.STATUSPOOL);
         // checkNodeInfoCustomerInfo(jdfRoot, root, ElementName.AUDITPOOL);

         if (!root.hasChildElements())
         {
            root.deleteNode();
            root = null;
         }

         return root;
      }

      ///   
      ///	 <summary> * checkNodeInfoCustomerInfo - tests if there are JDFNode/NodeInfo or
      ///	 * JDFNode/CustomerInfo elements that are not described by DevCaps. If
      ///	 * missing DevCaps are found, jdfRoot has elements unknown for this Device
      ///	 * resources or elements
      ///	 *  </summary>
      ///	 * <param name="jdfRoot">
      ///	 *            node to test </param>
      ///	 * <param name="root">
      ///	 *            root of the XMLDoc output </param>
      ///	 * <param name="elementName">
      ///	 *            "NodeInfo" or "CustomerInfo" or "StatusPool" </param>
      ///	 
      private void checkNodeInfoCustomerInfo(JDFNode jdfRoot, KElement root, string elementName)
      {
         JDFAttributeMap map = new JDFAttributeMap();
         map.put(AttributeName.CONTEXT, EnumContext.Element.getName());
         map.put(AttributeName.NAME, elementName);
         KElement devCaps = getChildByTagName(ElementName.DEVCAPS, null, 0, map, true, true);
         if ((jdfRoot.getElement(elementName, null, 0) != null) && (devCaps == null))
         {
            KElement ue = root.appendElement("UnknownElement");
            ue.setAttribute("XPath", jdfRoot.getElement(elementName, null, 0).buildXPath(null, 1));
            ue.setAttribute("Name", elementName);
            ue.setAttribute("Message", "Found no DevCaps description with Context=\"Element\" for: " + elementName);
         }
         return;
      }

      ///   
      ///	 <summary> * actionPoolReport - tests if the JDFNode fits Actions from ActionPool of
      ///	 * this DeviceCap.<br>
      ///	 * Composes a detailed report of the found errors in XML form. If XMLDoc is
      ///	 * <code>null</code> - there are no errors
      ///	 *  </summary>
      ///	 * <param name="jdfRoot">
      ///	 *            node to test </param>
      ///	 * <returns> KElement - KElement output of the error messages. If KElement is
      ///	 *         <code>null</code> there are no errors, JDFNode fits the
      ///	 *         ActionPool of this DeviceCap and will be accepted by the device. </returns>
      ///	 * <exception cref="JDFException">
      ///	 *             if DeviceCap is invalid: ActionPool refers to the
      ///	 *             non-existent TestPool </exception>
      ///	 * <exception cref="JDFException">
      ///	 *             if DeviceCap is invalid: Action refers to the non-existent
      ///	 *             Test </exception>
      ///	 
      public static KElement actionPoolReport(IDeviceCapable devCapable, JDFElement jdfRootorMess, KElement parentReport)
      {
         KElement root = parentReport.appendElement("ActionPoolReport");
         JDFActionPool actionPool = devCapable.getActionPool();
         if (actionPool != null)
         {
            JDFTestPool testPool = devCapable.getTestPool();
            if (testPool == null)
            {
               throw new JDFException("JDFDeviceCap.actionPoolReport: TestPool is required but was not found. Attempt to operate on a null element");
            }
            VElement vActions = actionPool.getChildElementVector(ElementName.ACTION, null, null, true, 0, false);
            VElement allElms = jdfRootorMess.getChildrenByTagName(null, null, null, false, true, 0);
            allElms.Add(jdfRootorMess); // needed for local JDF test
            if (jdfRootorMess is JDFMessage)
            {
               JDFJMF jmf = jdfRootorMess.getJMFRoot();
               if (jmf != null)
                  allElms.Add(jmf);
            }
            int elmSize = allElms.Count;
            int actionSize = vActions.Count;
            for (int i = 0; i < elmSize; i++)
            {
               KElement e = allElms.item(i);
               for (int j = 0; j < actionSize; j++)
               {
                  JDFAction action = (JDFAction)vActions[j];
                  JDFTest test = action.getTest();
                  if (test == null)
                  {
                     continue;
                     // TODO add report of snafu
                     // throw new JDFException(
                     // "JDFDeviceCap.actionPoolReport: Test with ID=" +
                     // action.getTestRef() +
                     // " was not found. Attempt to operate on a null element"
                     // );
                  }
                  // loop to check whether the test even applies
                  if (!test.fitsContext(e))
                     continue;

                  KElement ar = root.appendElement("ActionReport");
                  if (test.fitsJDF(e, ar)) // If the Test referenced by
                  // TestRef evaluates to “true”
                  // the combination
                  { // of processes and attribute values described is not
                     // allowed
                     KElement arl = root.getChildWithAttribute("ActionReportList", "ID", null, action.getID(), 0, true);

                     if (arl == null)
                     {
                        arl = root.appendElement("ActionReportList");
                        arl.setAttribute("ID", action.getID());
                        arl.setAttribute("Severity", action.getSeverity().getName());
                     }

                     arl.moveElement(ar, null);
                     ar.setAttribute("XPath", e.buildXPath(null, 1));

                     // __Lena__ TBD choose Loc element according to the
                     // language settings
                     JDFLoc loc = action.getLoc(0);
                     if (loc != null)
                     {
                        ar.setAttribute("Message", loc.getValue());
                        string helpText = loc.getHelpText();
                        if (helpText.Length != 0)
                        {
                           ar.setAttribute("Help", helpText);
                        }
                     }
                  }
                  else
                  {
                     ar.deleteNode(); // zapp it
                  }
               }
            }
         }
         root = cleanActionPoolReport(root);
         return root;
      }

      ///   
      ///	 <summary> * remove duplicate entries that are parents of lower level entries
      ///	 *  </summary>
      ///	 * <param name="testResult">
      ///	 *            XMLDoc to clean </param>
      ///	 * <returns> XMLDoc - the cleaned doc </returns>
      ///	 
      private static KElement cleanActionPoolReport(KElement actionPoolReport)
      {
         KElement actionPoolReportLocal = actionPoolReport;

         if (actionPoolReportLocal != null)
         {
            VElement vARL = actionPoolReportLocal.getChildElementVector("ActionReportList", null, null, true, 0, false);
            for (int i = 0; i < vARL.Count; i++)
            {
               VElement actionReportList = vARL.item(i).getChildElementVector("ActionReport", null, null, true, 0, false);
               for (int j = 1; j < actionReportList.Count; j++)
               {
                  KElement e1 = actionReportList.item(j);
                  for (int k = 0; k < j; k++)
                  {
                     KElement e2 = actionReportList.item(k);
                     if (e2 == null)
                        continue;
                     if (e2.getAttribute("XPath").StartsWith(e1.getAttribute("XPath")))
                     {
                        e1.deleteNode();
                        actionReportList[j] = null;
                        break;
                     }
                     else if (e1.getAttribute("XPath").StartsWith(e2.getAttribute("XPath")))
                     {
                        e2.deleteNode();
                        actionReportList[k] = null;
                     }
                  }
               }
            }

            if (!actionPoolReportLocal.hasChildElements())
            {
               actionPoolReportLocal.deleteNode();
               actionPoolReportLocal = null;
            }
         }
         return actionPoolReportLocal;
      }


      ///   
      ///	 <summary> * creates and links devcaps to modules
      ///	 *  </summary>
      ///	 * <param name="includeNameExpression">
      ///	 *            regexp of names to include </param>
      ///	 
      public virtual void createModuleCaps(string includeNameExpression)
      {
         VElement devcaps = getChildElementVector(ElementName.DEVCAPS, null, null, true, 0, true);
         if (devcaps != null)
         {
            int siz = devcaps.Count;
            for (int i = 0; i < siz; i++)
            {
               JDFDevCaps dcs = (JDFDevCaps)devcaps[i];

               string _name = dcs.getName();
               if (StringUtil.matches(_name, includeNameExpression))
               {
                  JDFModuleCap mc = dcs.appendModuleRef("Module_" + _name);
                  mc.setAvailability(EnumAvailability.Installed);
                  mc.setDescriptiveName("Module that implements the resource: " + _name);
               }
            }
         }
      }

      ///   
      ///	 <summary> * set the defaults of node to the values defined in the child DevCap and
      ///	 * State elements
      ///	 *  </summary>
      ///	 * <param name="node">
      ///	 *            the JDFNode in which to set defaults </param>
      ///	 * <param name="bLocal">
      ///	 *            if true, set only in the local node, else recurse children </param>
      ///	 * <param name="bAll">
      ///	 *            if false, only add if minOccurs>=1 and required=true or a
      ///	 *            default exists </param>
      ///	 
      public virtual bool setDefaultsFromCaps(JDFNode node, bool bLocal, bool bAll)
      {
         bool success = false;
         bool bTestTypes = node.hasAttribute(AttributeName.TYPE);
         if (bLocal == false)
         {
            VElement vNode = node.getvJDFNode(null, null, false);
            for (int i = 0; i < vNode.Count; i++)
            {
               JDFNode nod = (JDFNode)vNode[i];
               success = setDefaultsFromCaps(nod, true, bAll) || success;
            }
            return success;
         }
         if (bTestTypes && !matchesType(node, true))
            return false;
         if (hasAttribute(AttributeName.TYPES))
         {
            node.setType(EnumType.ProcessGroup);
            List<ValuedEnum> cm = getCombinedMethod();
            if (cm != null && cm.Contains(EnumCombinedMethod.Combined))
               node.setType(EnumType.Combined);

            node.setTypes(getTypes());
         }
         addResourcesFromDevCaps(node, bAll);
         int i2;
         VElement vDevCaps = getChildElementVector(ElementName.DEVCAPS, null, null, true, 99999, false);
         // step 1, create all missing resources etc
         int size = vDevCaps.Count;
         for (i2 = 0; i2 < size; i2++)
         {
            JDFDevCaps dcs = (JDFDevCaps)vDevCaps[i2];
            success = dcs.setDefaultsFromCaps(node, bAll) || success;
         }

         VElement vStates = getStates();
         for (i2 = 0; i2 < vStates.Count; i2++)
         {
            JDFAbstractState state = (JDFAbstractState)vStates[i2];
            success = state.setDefaultsFromCaps(node, bAll) || success;
         }

         return success;
      }

      ///   
      ///	 <summary> * get all direct state elements of <this>
      ///	 *  </summary>
      ///	 * <returns> the vector of state elements </returns>
      ///	 
      public virtual VElement getStates()
      {
         VElement vStates = getChildrenByTagName(null, null, null, true, true, 0);
         for (int ii = vStates.Count - 1; ii >= 0; ii--)
         {
            if (!(vStates[ii] is JDFAbstractState))
               vStates.RemoveAt(ii);
         }
         return vStates;
      }

      ///   
      ///	 <summary> * add any missing resources, links or elements that are described by
      ///	 * devcaps elements
      ///	 *  </summary>
      ///	 * <param name="bAll">
      ///	 *            if false, only add if minOccurs>=1 and required=true or a
      ///	 *            default exists </param>
      ///	 * <param name="node"> </param>
      ///	 
      private void addResourcesFromDevCaps(JDFNode node, bool bAll)
      {
         VElement vDevCaps = getChildElementVector(ElementName.DEVCAPS, null, null, true, 99999, false);
         // step 1, create all missing resources etc
         setResMap = new org.cip4.jdflib.util.VectorMap<int, JDFResource>();
         int size = vDevCaps.Count;
         // loop over all resources first so that we have hooks for the links
         for (int i = 0; i < size; i++)
         {
            JDFDevCaps dcs = (JDFDevCaps)vDevCaps[i];
            dcs.appendMatchingElementsToNode(node, bAll, setResMap, false);
         }
         // now loop over all context=link
         for (int i = 0; i < size; i++)
         {
            JDFDevCaps dcs = (JDFDevCaps)vDevCaps[i];
            dcs.appendMatchingElementsToNode(node, bAll, setResMap, true);
         }

      }

      ///   
      ///	 <summary> * get a DevCaps element by name and further restrictions. If an Enumerative
      ///	 * restriction is null, the restriction is not checked.
      ///	 *  </summary>
      ///	 * <param name="devCapsName">
      ///	 *            the Name attribute of the DevCaps </param>
      ///	 * <param name="context">
      ///	 *            the Context attribute of the DevCaps </param>
      ///	 * <param name="linkUsage">
      ///	 *            the LinkUsage attribute of the DevCaps </param>
      ///	 * <param name="processUsage">
      ///	 *            the ProcessUsage attribute of the DevCaps </param>
      ///	 * <param name="iSkip">
      ///	 *            the iSkip'th matching DevCaps </param>
      ///	 * <returns> JDFDevCaps the matching DevCaps, null if not there </returns>
      ///	 
      public virtual JDFDevCaps getDevCapsByName(string devCapsName, EnumContext context, EnumUsage linkUsage, EnumProcessUsage processUsage, int iSkip)
      {
         JDFAttributeMap map = new JDFAttributeMap(AttributeName.NAME, devCapsName);
         if (context != null)
            map.put(AttributeName.CONTEXT, context.getName());
         if (linkUsage != null)
            map.put(AttributeName.LINKUSAGE, linkUsage.getName());
         if (processUsage != null)
            map.put(AttributeName.PROCESSUSAGE, processUsage.getName());
         return (JDFDevCaps)getChildByTagName(ElementName.DEVCAPS, null, iSkip, map, true, true);
      }

      ///   
      ///	 <summary> * set attribute <code>CombinedMethod</code> to an individual method
      ///	 *  </summary>
      ///	 * <param name="method">
      ///	 *            the individual combined method to set </param>
      ///	 
      public virtual void setCombinedMethod(EnumCombinedMethod method)
      {
         setAttribute(AttributeName.COMBINEDMETHOD, method.getName(), null);
      }

      ///   
      ///	 <summary> * set attribute <code>CombinedMethod</code> to an individual method
      ///	 *  </summary>
      ///	 * <param name="method">
      ///	 *            the individual combined method to set </param>
      ///	 
      public override void setCombinedMethod(List<ValuedEnum> vMethod)
      {
         setEnumerationsAttribute(AttributeName.COMBINEDMETHOD, vMethod, null);
      }

      ///   
      ///	 * <returns> the ignoreExtensions </returns>
      ///	 
      public virtual bool isIgnoreExtensions()
      {
         return ignoreExtensions;
      }

      ///   
      ///	 * <param name="ignoreExtensions">
      ///	 *            the ignoreExtensions to set </param>
      ///	 
      public virtual void setIgnoreExtensions(bool _ignoreExtensions)
      {
         this.ignoreExtensions = _ignoreExtensions;
      }

      ///   
      ///	 * <returns> the ignoreDefaults </returns>
      ///	 
      public virtual bool isIgnoreDefaults()
      {
         return ignoreDefaults;
      }

      ///   
      ///	 * <param name="ignoreDefaults">
      ///	 *            the ignoreDefaults to set </param>
      ///	 
      public virtual void setIgnoreDefaults(bool _ignoreDefaults)
      {
         this.ignoreDefaults = _ignoreDefaults;
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.ifaces.IDeviceCapable#getTargetCap(java.lang.String)
      //	 
      public virtual ICapabilityElement getTargetCap(string id)
      {
         KElement e = getTarget(id, null);
         if (e is ICapabilityElement)
            return (ICapabilityElement)e;
         return null;
      }

      ///   
      ///	 <summary> * appends a BooleanState with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the name attribute of the newly appended BooleanState </param>
      ///	 * <returns> JDFBooleanState: the newly appended BooleanState </returns>
      ///	 
      public virtual JDFBooleanState appendBooleanState(string nam)
      {
         JDFBooleanState s = (JDFBooleanState)appendElement(ElementName.BOOLEANSTATE, null);
         s.setName(nam);
         return s;
      }

      

      ///   
      ///	 <summary> * appends a NumberState with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the name attribute of the newly appended NumberState </param>
      ///	 * <returns> JDFNumberState: the newly appended NumberState </returns>
      ///	 
      public virtual JDFEnumerationState appendEnumerationState(string nam)
      {
         JDFEnumerationState s = (JDFEnumerationState)appendElement(ElementName.ENUMERATIONSTATE, null);
         s.setName(nam);
         return s;
      }

      

      ///   
      ///	 <summary> * appends an IntegerState with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="name">
      ///	 *            the Name attribute of the newly appended IntegerState </param>
      ///	 * <returns> JDFIntegerState: the newly appended IntegerState </returns>
      ///	 
      public virtual JDFIntegerState appendIntegerState(string nam)
      {
         JDFIntegerState s = (JDFIntegerState)appendElement(ElementName.INTEGERSTATE, null);
         s.setName(nam);
         return s;
      }

      

      ///   
      ///	 <summary> * appends a NameState with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the name attribute of the newly appended NameState </param>
      ///	 * <returns> JDFNameState: the newly appended NameState </returns>
      ///	 
      public virtual JDFNameState appendNameState(string nam)
      {
         JDFNameState s = (JDFNameState)appendElement(ElementName.NAMESTATE, null);
         s.setName(nam);
         return s;
      }

      

      ///   
      ///	 <summary> * appends a StringState with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the Name attribute of the newly appended StringState </param>
      ///	 * <returns> JDFStringState: the newly appended StringState </returns>
      ///	 
      public virtual JDFStringState appendStringState(string nam)
      {
         JDFStringState s = (JDFStringState)appendElement(ElementName.STRINGSTATE, null);
         s.setName(nam);
         return s;
      }

      

      ///   
      ///	 <summary> * gets an existing BooleanState with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the Name attribute of the newly appended BooleanState </param>
      ///	 * <returns> JDFBooleanState: the existing BooleanState </returns>
      ///	 
      public virtual JDFBooleanState getBooleanState(string nam)
      {
         return (JDFBooleanState)getChildWithAttribute(ElementName.BOOLEANSTATE, AttributeName.NAME, null, nam, 0, true);
      }

      

      ///   
      ///	 <summary> * gets a NumberState with @Name="name", appends it if it does not exist
      ///	 *  </summary>
      ///	 * <param name="name">
      ///	 *            the name attribute of the newly appended NumberState </param>
      ///	 * <returns> JDFNumberState: the existing or newly appended NumberState </returns>
      ///	 
      public virtual JDFBooleanState getCreateBooleanState(string nam)
      {
         JDFBooleanState s = getBooleanState(nam);
         if (s == null)
            s = appendBooleanState(nam);
         return s;
      }

      

      ///   
      ///	 <summary> * gets a EnumerationState with @Name="name", appends it if it does not
      ///	 * exist
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the name attribute of the newly appended EnumerationState </param>
      ///	 * <returns> JDFEnumerationState the existing or newly appended
      ///	 *         EnumerationState </returns>
      ///	 
      public virtual JDFEnumerationState getCreateEnumerationState(string nam)
      {
         JDFEnumerationState s = getEnumerationState(nam);
         if (s == null)
            s = appendEnumerationState(nam);
         return s;
      }

      ///   
      ///	 <summary> * gets an IntegerState with @Name="name", appends it if it does not yet
      ///	 * exist
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the name attribute of the newly appended IntegerState </param>
      ///	 * <returns> JDFIntegerState: the existing or newly appended IntegerState </returns>
      ///	 
      public virtual JDFIntegerState getCreateIntegerState(string nam)
      {
         JDFIntegerState s = getIntegerState(nam);
         if (s == null)
            s = appendIntegerState(nam);
         return s;
      }

      

      ///   
      ///	 <summary> * gets a NameState with @Name="name", appends it if it does not exist
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the name attribute of the newly appended NameState </param>
      ///	 * <returns> JDFNameState: the existing or newly appended NameState </returns>
      ///	 
      public virtual JDFNameState getCreateNameState(string nam)
      {
         JDFNameState s = getNameState(nam);
         if (s == null)
            s = appendNameState(nam);
         return s;
      }

      

      ///   
      ///	 <summary> * gets a StringState with @Name="name", appends it if it does not yet exist
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the Name attribute of the newly appended StringState </param>
      ///	 * <returns> JDFStringState: the existing or newly appended StringState </returns>
      ///	 
      public virtual JDFStringState getCreateStringState(string nam)
      {
         JDFStringState s = getStringState(nam);
         if (s == null)
            s = appendStringState(nam);
         return s;
      }

      

      ///   
      ///	 <summary> * gets an existing EnumerationState with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="name">
      ///	 *            the Name attribute of the newly appended EnumerationState </param>
      ///	 * <returns> JDFEnumerationState: the existing EnumerationState </returns>
      ///	 
      public virtual JDFEnumerationState getEnumerationState(string nam)
      {
         return (JDFEnumerationState)getChildWithAttribute(ElementName.ENUMERATIONSTATE, AttributeName.NAME, null, nam, 0, true);
      }

      

      ///   
      ///	 <summary> * gets an existing IntegerState with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the name attribute of the newly appended IntegerState </param>
      ///	 * <returns> JDFIntegerState: the existing IntegerState </returns>
      ///	 
      public virtual JDFIntegerState getIntegerState(string nam)
      {
         return (JDFIntegerState)getChildWithAttribute(ElementName.INTEGERSTATE, AttributeName.NAME, null, nam, 0, true);
      }

      

      ///   
      ///	 <summary> * gets an existing NameState with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the Name attribute of the newly appended NameState </param>
      ///	 * <returns> JDFNameState: the existing NameState </returns>
      ///	 
      public virtual JDFNameState getNameState(string nam)
      {
         return (JDFNameState)getChildWithAttribute(ElementName.NAMESTATE, AttributeName.NAME, null, nam, 0, true);
      }

      
      ///   
      ///	 <summary> * gets an existing NumberState with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the Name attribute of the newly appended NumberState </param>
      ///	 * <returns> JDFNumberState: the existing NumberState </returns>
      ///	 
      public virtual JDFNumberState getNumberState(string nam)
      {
         return (JDFNumberState)getChildWithAttribute(ElementName.NUMBERSTATE, AttributeName.NAME, null, nam, 0, true);
      }

      

      ///   
      ///	 <summary> * gets an existing State with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the Name attribute of the newly appended StringState </param>
      ///	 * <returns> JDFStringState: the existing StringState </returns>
      ///	 
      public virtual JDFAbstractState getState(string nam)
      {
         for (int i = 0; true; i++)
         {
            KElement e = getChildWithAttribute(null, AttributeName.NAME, null, nam, i, true);
            if (e == null)
               break;
            if (e is JDFAbstractState)
               return (JDFAbstractState)e;
         }
         return null;
      }

      ///   
      ///	 <summary> * gets an existing StringState with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the Name attribute of the newly appended StringState </param>
      ///	 * <returns> JDFStringState: the existing StringState </returns>
      ///	 
      public virtual JDFStringState getStringState(string nam)
      {
         return (JDFStringState)getChildWithAttribute(ElementName.STRINGSTATE, AttributeName.NAME, null, nam, 0, true);
      }
   }
}
