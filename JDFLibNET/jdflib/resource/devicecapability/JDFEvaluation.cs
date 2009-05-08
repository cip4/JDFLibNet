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





/* Copyright (c) 2001 Heidelberger Druckmaschinen AG, All Rights Reserved.
 * 
 * @author Elena Skobchenko
 *
 * JDFEvaluation.cs
 */


namespace org.cip4.jdflib.resource.devicecapability
{
   using System;



   using EnumListType = org.cip4.jdflib.auto.JDFAutoBasicPreflightTest.EnumListType;
   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using KElement = org.cip4.jdflib.core.KElement;
   using VString = org.cip4.jdflib.core.VString;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using JDFBaseDataTypes = org.cip4.jdflib.datatypes.JDFBaseDataTypes;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using ICapabilityElement = org.cip4.jdflib.ifaces.ICapabilityElement;
   using IDeviceCapable = org.cip4.jdflib.ifaces.IDeviceCapable;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using StringUtil = org.cip4.jdflib.util.StringUtil;

   public abstract class JDFEvaluation : JDFTerm, JDFBaseDataTypes
   {
      private new const long serialVersionUID = -1231679460732331896L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[1];
      static JDFEvaluation()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.RREF, 0x33333333, AttributeInfo.EnumAttributeType.IDREF, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.BASICPREFLIGHTTEST, 0x33333333);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }

      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[1];

      protected internal override ElementInfo getTheElementInfo()
      {
         return new ElementInfo(base.getTheElementInfo(), elemInfoTable);
      }

      ///   
      ///	 <summary> * constructor for JDFEvaluation
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFEvaluation(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * constructor for JDFEvaluation
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFEvaluation(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * constructor for JDFEvaluation
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFEvaluation(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      // **************************************** Methods
      // *********************************************

      ///   
      ///	 <summary> * toString
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public override string ToString()
      {
         return "JDFEvaluation[ --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * fitsMap - tests whether attribute map 'm' has a key specified by
      ///	 * BasicPreflightTest/@Name. If this the case, it is checked whether its
      ///	 * value fits the testlist.
      ///	 *  </summary>
      ///	 * <param name="m">
      ///	 *            key-value pair attribute map to take the value from </param>
      ///	 * <returns> boolean - true, if 'm' has a key specified by BasicPreflightTest/@Name
      ///	 *         and fitsValue(value) returns true </returns>
      ///	 
      public override sealed bool fitsMap(JDFAttributeMap m)
      {
         JDFBasicPreflightTest basicPreflightTest = getBasicPreflightTest();
         if (basicPreflightTest == null)
            return false;
         string n = basicPreflightTest.getName();

         if (m.ContainsKey(n))
         {
            string val = m.get(n);
            return fitsValue(val);
         }
         return false; // __Lena__ ? false or smth else
      }

      ///   
      ///	 <summary> * fitsJDF - tests whether JDFNode 'jdf' can be accepted by the Device.
      ///	 * Tests if the value of resource attribute, decribed with this Evaluation,
      ///	 * fits Evaluation/@ValueList
      ///	 *  </summary>
      ///	 * <param name="jdf">
      ///	 *            jdf node to test </param>
      ///	 * <returns> boolean - true, if 'jdf' can be accepted by the Device </returns>
      ///	 
      public override bool fitsJDF(KElement jdf, KElement reportRoot)
      {
         KElement reportRootLocal = reportRoot;

         string xPath = getEvalXPath(jdf);
         if (reportRootLocal != null)
            reportRootLocal = reportRootLocal.appendElement(LocalName);

         bool b = false;
         if (xPath != null)
         {
            b = fitsPath(jdf, xPath, reportRootLocal);
         }

         if (reportRootLocal != null)
         {
            reportRootLocal.setAttribute("Value", b, null);
            reportRootLocal.setAttribute("CapXPath", getRefTargetNamePath());
            reportRootLocal.setAttribute("Name", getRefTargetName());
         }

         return b;
      }

      public override bool fitsContext(KElement jdf)
      {
         return getEvalXPath(jdf) != null;
      }

      private bool fitsPath(KElement e, string xPath, KElement reportRoot)
      {
         bool b = false;
         KElement attr = null;
         string newPath = null;

         int posAt = xPath.LastIndexOf("@");
         int posAtI = posAt > 0 ? xPath.LastIndexOf("[@") : -1;
         if (posAt < 0 || posAt == posAtI + 1) // element
         {
            KElement pathElement = e.getXPathElement(xPath);
            b = fitsValue(pathElement);
            if (b)
            {
               if (reportRoot != null)
               {
                  if (pathElement != null)
                     newPath = pathElement.buildXPath(null, 1);
                  attr = reportRoot.appendElement("TestedElement");
                  attr.setAttribute("Name", StringUtil.token(xPath, -1, "/"));
               }
            }
         }
         else
         // attribute
         {
            string attrVal = e.getXPathAttribute(xPath, null);
            b = fitsValue(attrVal);
            string attName = xPath.Substring(posAt + 1);
            KElement pathElement = e.getXPathElement(xPath.Substring(0, posAt));

            if (pathElement is JDFResource)
            {
               JDFResource r = (JDFResource)pathElement;
               JDFResource root = r.getResourceRoot();
               while (r != root)
               {
                  if (!r.hasAttribute_KElement(attName, null, false))
                  {
                     r = (JDFResource)r.getParentNode_KElement();
                  }
                  else
                  {
                     break;
                  }
               }
               pathElement = r;
               newPath = pathElement.buildXPath(null, 1) + "/@" + attName;

            }
            if (newPath != null)
               attrVal = e.getXPathAttribute(newPath, null);
            b = fitsValue(attrVal);
            if (reportRoot != null)
            {

               attr = reportRoot.appendElement("TestedAttribute");
               attr.setAttribute("Name", attName);
               attr.setAttribute("Value", attrVal);
            }
         }

         if (attr != null)
         {
            attr.setAttribute("XPath", newPath);
         }
         return b;
      }

      ///   
      ///	 <summary> * fitsValue - checks whether the <code>value</code> matches the testlists
      ///	 * specified for this Evaluation
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <returns> boolean - true, if the value matches testlists or if testlists
      ///	 *         are not specified </returns>
      ///	 
      public abstract bool fitsValue(string @value);

      ///   
      ///	 <summary> * fitsValue - checks whether <code>elem</code> matches the testlists
      ///	 * specified for this Evaluation
      ///	 *  </summary>
      ///	 * <param name="elem">
      ///	 *            element to test </param>
      ///	 * <returns> boolen - true, if the value matches testlists or if testlists are
      ///	 *         not specified </returns>
      ///	 
      public virtual bool fitsValue(KElement elem)
      {
         // TODO implement in subclasses for spans
         return elem != null;
      }

      ///   
      ///	 <summary> * gets the ListType from a corresponding State/BasicPreflightTest element
      ///	 *  </summary>
      ///	 * <returns> JDFBasicPreflightTest::EnumListType - the value of ListType
      ///	 *         attribute </returns>
      ///	 
      public virtual JDFBasicPreflightTest.EnumListType getListType()
      {
         JDFAbstractState state = getState();
         if (state != null)
         {
            return state.getListType();
         }
         JDFBasicPreflightTest basicPreflightTest = getBasicPreflightTest();
         return basicPreflightTest == null ? null : basicPreflightTest.getListType();
      }

      ///   
      ///	 <summary> * gets the XPath to the attributes of a given JDF node
      ///	 *  </summary>
      ///	 * <param name="jdf">
      ///	 *            JDF node to test </param>
      ///	 * <returns> String - the XPath to the attributes </returns>
      ///	 
      protected internal virtual string getEvalXPath(KElement jdf)
      {
         ICapabilityElement stateDC = getRefTarget();
         if (stateDC == null)
            return null;

         VString vPath = null;
         bool bElement = false;
         string attName = null;

         if (stateDC is JDFDevCap)
         {
            if (!(this is JDFIsPresentEvaluation)) // only ispresent may
               // reference a
               // devcap, all
               // others must
               // reference a state
               return null;
            bElement = true;
            JDFDevCap dc = (JDFDevCap)stateDC;
            vPath = dc.getNamePathVector(true);
            // fix up for the fact that ispresent for a resource is actually a
            // link
            if (vPath != null)
            {
               for (int i = 0; i < vPath.Count; i++)
               {
                  string path = vPath.stringAt(i);
                  VString tokens = new VString(StringUtil.tokenize(path, "/", false));
                  if (tokens.Count == 3 && tokens.stringAt(1).Equals(ElementName.RESOURCEPOOL))
                  {
                     tokens[1] = ElementName.RESOURCELINKPOOL;
                     tokens[2] = tokens.stringAt(2) + "Link";
                     vPath[i] = StringUtil.setvString(tokens, "/", null, null);
                  }
               }
            }
         }
         else if (stateDC is JDFDevCaps)
         {
            if (!(this is JDFIsPresentEvaluation)) // only ispresent may
               // reference a
               // devcap, all
               // others must
               // reference a state
               return null;
            bElement = true;
            JDFDevCaps dc = (JDFDevCaps)stateDC;
            vPath = dc.getNamePathVector();
            // fix up for the fact that ispresent for a resource is actually a
            // link
            if (vPath != null)
            {
               for (int i = 0; i < vPath.Count; i++)
               {
                  string path = vPath.stringAt(i);
                  VString tokens = new VString(StringUtil.tokenize(path, "/", false));
                  if (tokens.Count == 3 && tokens.stringAt(1).Equals(ElementName.RESOURCEPOOL))
                  {
                     tokens[1] = ElementName.RESOURCELINKPOOL;
                     string link = tokens.stringAt(2) + "Link";
                     EnumUsage lu = dc.getLinkUsage();
                     if (lu != null)
                        link += "[@Usage=\"" + lu.getName() + "\"]";
                     tokens[2] = link;
                     vPath[i] = StringUtil.setvString(tokens, "/", null, null);
                  }
               }
            }
         }
         else
         {
            // we have found our state -> take its xPath and look for
            // corresponding elem in JDFNode, we test

            JDFAbstractState state = (JDFAbstractState)stateDC;
            if (state.getListType().Equals(EnumListType.Span))
            {
               vPath = state.getNamePathVector(true);
               bElement = true;
            }
            else
            {

               KElement kdc = state.getParentNode_KElement();
               if (kdc is IDeviceCapable)
               {
                  vPath = ((IDeviceCapable)kdc).getNamePathVector();
               }
               else if (kdc is ICapabilityElement)
               {
                  vPath = ((ICapabilityElement)kdc).getNamePathVector();
               }
               attName = state.getName();
            }
         }
         if (vPath != null)
         {
            for (int i = 0; i < vPath.Count; i++)
            {
               string xPath = vPath.stringAt(i);
               int slash = xPath.Length;
               string finalS = null;
               do
               {
                  string xPath2 = xPath.Substring(0, slash);
                  if (jdf.matchesPath(xPath2, true))
                     finalS = "." + xPath.Substring(slash);
                  slash = xPath2.LastIndexOf("/");
               } while (slash >= 0 && finalS == null);

               if (finalS != null && !bElement)
               {
                  finalS += "/@" + attName;
               }
               if (finalS != null)
                  return finalS;
            }
         }
         return null;
      }

      ///   
      ///	 <summary> * getRefTargetNamePath()
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public virtual string getRefTargetNamePath()
      {
         ICapabilityElement e = getRefTarget();
         if (e is JDFAbstractState)
         {
            return ((JDFAbstractState)e).getNamePath();
         }
         else if (e is JDFDevCap)
         {
            return ((JDFDevCap)e).getNamePath(true);
         }
         else if (e is JDFDevCaps)
         {
            return ((JDFDevCaps)e).getName();
         }
         return null;
      }

      ///   
      ///	 <summary> * getRefTargetName()
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public virtual string getRefTargetName()
      {
         ICapabilityElement e = getRefTarget();
         if (e is JDFAbstractState)
         {
            return ((JDFAbstractState)e).getName();
         }
         else if (e is JDFDevCap)
         {
            return ((JDFDevCap)e).getName();
         }
         else if (e is JDFDevCaps)
         {
            return ((JDFDevCaps)e).getName();
         }
         return null;
      }

      ///   
      ///	 <summary> * setRefTarget() set the target referencened in @rRef
      ///	 *  </summary>
      ///	 * <returns> JDFElement() the referenced element, either state or a devcap </returns>
      ///	 
      public virtual void setRefTarget(JDFElement e)
      {
         JDFDeviceCap deviceCap = (JDFDeviceCap)getDeepParent(ElementName.DEVICECAP, 0);
         if (deviceCap == null)
            throw new JDFException("setRefTarget, called in dangling evaluation");

         if (!(e is JDFAbstractState) && !(e is JDFDevCap))
            throw new JDFException("setRefTarget, called for illegal target type");

         string id = e.appendAnchor(null);
         setrRef(id);
      }

      ///   
      ///	 <summary> * getRefTarget() get the target referencened in @rRef
      ///	 *  </summary>
      ///	 * <returns> ICapabilityElement the referenced element, either state or a
      ///	 *         devcap </returns>
      ///	 
      public virtual ICapabilityElement getRefTarget()
      {
         IDeviceCapable deviceCap = getDeviceCapable();
         if (deviceCap == null)
            return null;
         return deviceCap.getTargetCap(getrRef());

      }

      ///   
      ///	 <summary> * getState()
      ///	 *  </summary>
      ///	 * <returns> JDFAbstractState </returns>
      ///	 
      public virtual JDFAbstractState getState()
      {
         ICapabilityElement ic = getRefTarget();
         if (ic is JDFAbstractState)
            return (JDFAbstractState)ic;
         return null;
      }

      //   
      //	 * // Attribute Getter / Setter
      //	 

      ///   
      ///	 <summary> * Sets String attribute <code>rRef</code><br>
      ///	 * Since rRef is independent of the data type of the State element, the
      ///	 * setter is defined here
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            value: the value to set the attribute to </param>
      ///	 
      public virtual void setrRef(string @value)
      {
         setAttribute(AttributeName.RREF, @value);
      }

      ///   
      ///	 <summary> * Gets String attribute <code>rRef</code><br>
      ///	 * Since rRef is independent of the data type of the State element,the
      ///	 * getter is defined here
      ///	 *  </summary>
      ///	 * <returns> String: the attribute value </returns>
      ///	 
      public virtual string getrRef()
      {
         return getAttribute(AttributeName.RREF, null, "");
      }

      //   
      //	 * // Element Getter / Setter
      //	 
      // @{
      ///   
      ///	 <summary> * Get element <code>BasicPreflightTest</code>. Creates it if it doesn't
      ///	 * exist
      ///	 * <p>
      ///	 * default: getCreateBasicPreflightTest(0
      ///	 *  </summary>
      ///	 * <returns> JDFBasicPreflightTest: the matching element </returns>
      ///	 
      public virtual JDFBasicPreflightTest getCreateBasicPreflightTest()
      {
         return (JDFBasicPreflightTest)getCreateElement(ElementName.BASICPREFLIGHTTEST, null, 0);
      }

      ///   
      ///	 <summary> * Gets the iSkip-th element <code>BasicPreflightTest</code>. If doesn't
      ///	 * exist, creates it
      ///	 * <p>
      ///	 * default getCreateBasicPreflightTest(0)
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            number of elements to skip </param>
      ///	 * <returns> JDFBasicPreflightTest: the matching element </returns>
      ///	 * @deprecated use getCreateBasicPreflightTest() 
      ///	 
      [Obsolete("use getCreateBasicPreflightTest()")]
      public virtual JDFBasicPreflightTest getCreateBasicPreflightTest(int iSkip)
      {
         return (JDFBasicPreflightTest)getCreateElement(ElementName.BASICPREFLIGHTTEST, JDFConstants.EMPTYSTRING, iSkip);
      }

      ///   
      ///	 <summary> * Gets element <code>BasicPreflightTest</code>
      ///	 *  </summary>
      ///	 * <returns> JDFBasicPreflightTest: the matching element or <code>null</code> </returns>
      ///	 
      public virtual JDFBasicPreflightTest getBasicPreflightTest()
      {
         return (JDFBasicPreflightTest)getElement(ElementName.BASICPREFLIGHTTEST, null, 0);
      }

      ///   
      ///	 <summary> * Gets the iSkip'th element <code>BasicPreflightTest</code>
      ///	 * <p>
      ///	 * default: getBasicPreflightTest(0)
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            number of elements to skip </param>
      ///	 * <returns> JDFBasicPreflightTest: the matching element or null </returns>
      ///	 * @deprecated use getBasicPreflightTest() 
      ///	 
      [Obsolete("use getBasicPreflightTest()")]
      public virtual JDFBasicPreflightTest getBasicPreflightTest(int iSkip)
      {
         return (JDFBasicPreflightTest)getElement(ElementName.BASICPREFLIGHTTEST, JDFConstants.EMPTYSTRING, iSkip);
      }

      ///   
      ///	 <summary> * Appends element <code>BasicPreflightTest</code> to the end of
      ///	 * <code>this</code>
      ///	 *  </summary>
      ///	 * <returns> JDFBasicPreflightTest: newly created BasicPreflightTest element </returns>
      ///	 * @deprecated use appendBasicPreflightTest(name) 
      ///	 
      [Obsolete("use appendBasicPreflightTest(name)")]
      public virtual JDFBasicPreflightTest appendBasicPreflightTest()
      {
         return (JDFBasicPreflightTest)appendElementN(ElementName.BASICPREFLIGHTTEST, 1, null);
      }

      ///   
      ///	 <summary> * Appends element <code>BasicPreflightTest</code> to the end of
      ///	 * <code>this</code> and sets @Name to name
      ///	 *  </summary>
      ///	 * <param name="testName">
      ///	 *            the new Name attribute of the BasicPreflightTest </param>
      ///	 * <returns> JDFBasicPreflightTest: newly created BasicPreflightTest element </returns>
      ///	 
      public virtual JDFBasicPreflightTest appendBasicPreflightTest(string testName)
      {
         JDFBasicPreflightTest pft = (JDFBasicPreflightTest)appendElementN(ElementName.BASICPREFLIGHTTEST, 1, null);
         if (pft == null)
            return null;
         if (testName != null)
            pft.setName(testName);
         return pft;
      }

      ///   
      ///	 <summary> * tolerance is defined in all numeric evaluations - implement here!
      ///	 * 
      ///	 * @return </summary>
      ///	 
      public virtual JDFXYPair getTolerance()
      {
         try
         {
            return new JDFXYPair(getAttribute(AttributeName.TOLERANCE, null, "0 0"));
         }
         catch (FormatException)
         {
            throw new JDFException("JDFEvaluation.getTolerance: Attribute Tolerance is not applicable to create JDFXYPair");
         }
      }
   }
}
