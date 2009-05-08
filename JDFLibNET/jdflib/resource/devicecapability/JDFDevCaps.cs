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
 * Copyright (c) 2001 Heidelberger Druckmaschinen AG, All Rights Reserved.
 *
 * JDFDevCaps.cs
 *
 * @author Elena Skobchenko
 */


namespace org.cip4.jdflib.resource.devicecapability
{
   using System;
   using System.Collections;
   using System.Collections.Generic;
   using System.Text;



   using JDFAutoDevCaps = org.cip4.jdflib.auto.JDFAutoDevCaps;
   using EnumJMFRole = org.cip4.jdflib.auto.JDFAutoMessageService.EnumJMFRole;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using JDFIntegerList = org.cip4.jdflib.datatypes.JDFIntegerList;
   using JDFIntegerRangeList = org.cip4.jdflib.datatypes.JDFIntegerRangeList;
   using EnumFitsValue = org.cip4.jdflib.datatypes.EnumFitsValue;
   using ICapabilityElement = org.cip4.jdflib.ifaces.ICapabilityElement;
   using JDFMessage = org.cip4.jdflib.jmf.JDFMessage;
   using JDFMessageService = org.cip4.jdflib.jmf.JDFMessageService;
   using EnumFamily = org.cip4.jdflib.jmf.JDFMessage.EnumFamily;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using EnumProcessUsage = org.cip4.jdflib.node.JDFNode.EnumProcessUsage;
   using JDFResourceLinkPool = org.cip4.jdflib.pool.JDFResourceLinkPool;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using EnumAvailability = org.cip4.jdflib.resource.devicecapability.JDFDeviceCap.EnumAvailability;
   using EnumTerm = org.cip4.jdflib.resource.devicecapability.JDFTerm.EnumTerm;
   using StringUtil = org.cip4.jdflib.util.StringUtil;
   //using VectorMap = org.cip4.jdflib.util.VectorMap;

   //----------------------------------
   public class JDFDevCaps : JDFAutoDevCaps, ICapabilityElement
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFDevCaps
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFDevCaps(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFDevCaps
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFDevCaps(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFDevCaps
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFDevCaps(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      public override string ToString()
      {
         return "JDFDevCaps[  --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * set attribute <code>DevCapRef</code>
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            the value to set the attribute to </param>
      ///	 
      public virtual void setDevCapRef(string @value)
      {
         setAttribute(AttributeName.DEVCAPREF, @value, null);
      }

      ///   
      ///	 <summary> * set rRef to the value of devCap/@ID
      ///	 *  </summary>
      ///	 * <param name="dc">
      ///	 *            the DevCap to set </param>
      ///	 
      public virtual void setDevCapRef(JDFDevCap dc)
      {
         dc.appendAnchor(null); // just in case it is missing
         string id2 = dc.getID();
         setDevCapRef(id2);
      }

      ///   
      ///	 <summary> * set rRef to the value of devCap/@ID
      ///	 *  </summary>
      ///	 * <param name="dc">
      ///	 *            the DevCap to set </param>
      ///	 
      public override JDFDevCap appendDevCap()
      {
         JDFDevCap dc = base.appendDevCap();
         if (hasAttribute(AttributeName.NAME))
            dc.setName(getName());
         return dc;
      }

      ///   
      ///	 <summary> * set rRef to the value of devCap/@ID
      ///	 *  </summary>
      ///	 * <param name="dc">
      ///	 *            the DevCap to set </param>
      ///	 
      public virtual JDFDevCap appendDevCapInPool()
      {
         JDFDevCapPool dcp = getCreateDevCapPool();
         JDFDevCap dc = dcp.appendDevCap();
         string id2 = dc.getID();
         setDevCapRef(id2);
         if (hasAttribute(AttributeName.NAME))
            dc.setName(getName());
         return dc;
      }

      ///   
      ///	 <summary> * get the DevCapPool that contains devcap elements referenced by this
      ///	 *  </summary>
      ///	 * <returns> JDFDevCapPool the pool </returns>
      ///	 
      public virtual JDFDevCapPool getDevCapPool()
      {
         return (JDFDevCapPool)getParentPool(ElementName.DEVCAPPOOL);
      }

      ///   
      ///	 <summary> * get the DEvCapPool that contains devcap elements referenced by this
      ///	 *  </summary>
      ///	 * <returns> JDFDevCapPool the pool </returns>
      ///	 
      private KElement getParentPool(string poolName)
      {
         KElement parent = getParentNode_KElement();
         if (!(parent is JDFDeviceCap) && !(parent is JDFMessageService))
            throw new JDFException("JDFDevCap.getParentPool - invalid parent context");
         return parent.getElement(poolName);
      }

      ///   
      ///	 <summary> * get the DEvCapPool that contains devcap elements referenced by this
      ///	 *  </summary>
      ///	 * <returns> JDFDevCapPool the pool </returns>
      ///	 
      private KElement getCreateParentPool(string poolName)
      {
         KElement parent = getParentNode_KElement();
         if (!(parent is JDFDeviceCap) && !(parent is JDFMessageService))
            throw new JDFException("JDFDevCap.getParentPool - invalid parent context");
         return parent.getCreateElement(poolName);
      }

      ///   
      ///	 <summary> * get the DEvCapPool that contains devcap elements referenced by this
      ///	 *  </summary>
      ///	 * <returns> JDFDevCapPool the pool </returns>
      ///	 
      public virtual JDFModulePool getModulePool()
      {
         return (JDFModulePool)getParentPool(ElementName.MODULEPOOL);
      }

      ///   
      ///	 <summary> * get the DEvCapPool that contains devcap elements referenced by this
      ///	 *  </summary>
      ///	 * <returns> JDFDevCapPool the pool </returns>
      ///	 
      public virtual JDFModulePool getCreateModulePool()
      {
         return (JDFModulePool)getCreateParentPool(ElementName.MODULEPOOL);
      }

      ///   
      ///	 <summary> * get the DevCapPool that contains devcap elements referenced by this
      ///	 * create one if it does not exist
      ///	 *  </summary>
      ///	 * <returns> JDFDevCapPool the pool </returns>
      ///	 
      public virtual JDFDevCapPool getCreateDevCapPool()
      {
         KElement parent = getParentNode_KElement();
         if (!(parent is JDFDeviceCap) && !(parent is JDFMessageService))
            throw new JDFException("JDFDevCap.getCreateDevCapPoll - invalid parent context");
         return (JDFDevCapPool)parent.getCreateElement(ElementName.DEVCAPPOOL);
      }

      ///   
      ///	 <summary> * get the one and only devCap - note that the spec allows <code>*</code>,
      ///	 * but recommends only one <code>+</code> additional actions.<br>
      ///	 * Also search devCapPool for a matching element to DevCapRef.
      ///	 *  </summary>
      ///	 * <returns> the DevCap </returns>
      ///	 
      public virtual JDFDevCap getDevCap()
      {
         string dcr = getAttribute(AttributeName.DEVCAPREF, null, null);
         if (dcr != null)
         {
            JDFDevCapPool dcp = getDevCapPool();
            if (dcp == null)
               return null;
            return (JDFDevCap)dcp.getChildWithAttribute(ElementName.DEVCAP, AttributeName.ID, null, dcr, 0, true);
         }
         return getDevCap(0);
      }

      //   
      //	 * // FitsValue Methods
      //	 

      ///   
      ///	 <summary> * getNamePath - gets the NamePath of this DevCaps in form
      ///	 * "DevCapsName[Context=bbb, LinkUsage=ccc]/"
      ///	 * <p>
      ///	 * default: getNamePath(false)
      ///	 *  </summary>
      ///	 * <param name="onlyNames">
      ///	 *            if true, returns only DevCapsName. Default=false </param>
      ///	 * <returns> String - NamePath of this DevCaps
      ///	 *  </returns>
      ///	 * @deprecated use getNamePathVector 
      ///	 
      [Obsolete("use getNamePathVector")]
      public string getNamePath(bool onlyNames)
      {
         StringBuilder xPath = new StringBuilder(getName());
         if (!onlyNames)
         {
            xPath.Append("[Context=").Append(getContext().getName()).Append(", LinkUsage=").Append(getLinkUsage().getName()).Append("]");
         }
         return xPath.ToString();
      }

      ///   
      ///	 <summary> * Gets the NamePath of this DevCap in form "
      ///	 * <code>DevCapsName/SubelemName1/SubelemName2/...</code>"<br>
      ///	 * If this DevCap is located in DevCapPool and not in a DevCaps, it
      ///	 * describes the reusable resource. In this case DevCap root will have the
      ///	 * attribute "Name" = value of DevCaps/@Name, but will have no info about
      ///	 * <code>DevCaps/@Context</code> or <code>DevCaps/@LinkUsage</code>.
      ///	 * <p>
      ///	 * default: getNamePath(false)
      ///	 *  </summary>
      ///	 * <param name="bRecurse">
      ///	 *            if true, returns "
      ///	 *            <code>DevCapsName/SubelemName1/SubelemName2/...</code>" </param>
      ///	 * <returns> String - NamePath of this DevCap </returns>
      ///	 
      public VString getNamePathVector()
      {
         string result = getDevCapsName();
         EnumContext cont = getContext();
         VString vResult = new VString();
         if (cont.Equals(EnumContext.JMF) && (ParentNode is JDFMessageService) && result.Length > 4)
         {
            JDFMessageService serv = (JDFMessageService)ParentNode;
            List<EnumFamily> vf = serv.getFamilies();
            if (vf != null)
            {
               int size = vf.Count;
               for (int i = 0; i < size; i++)
               {
                  vResult.Add("JMF/" + vf[i].getName() + "/" + result.Substring(4));
               }
            }

            if (EnumJMFRole.Sender.Equals(serv.getJMFRole()))
               vResult.Add("JMF/Response/" + result.Substring(4));
         }
         else
         {
            if (cont.Equals(EnumContext.Link))
            {
               result = ElementName.JDF + "/" + ElementName.RESOURCELINKPOOL + "/" + result;
            }
            else if (cont.Equals(EnumContext.Resource))
            {
               string nam = result;
               result = ElementName.JDF + "/" + ElementName.RESOURCEPOOL + "/" + result;
               for (int i = 0; i < 6; i++)
               {
                  vResult.Add(result);
                  result = result + "/" + nam;
               }
            }

            vResult.Add(result);
         }
         return vResult;
      }


      
      private string getDevCapsName()
      {
         string nam = getName();
         EnumContext cont = getContext();
         if (cont.Equals(EnumContext.Link))
         {
            nam += JDFConstants.LINK;
         }
         else if (cont.Equals(EnumContext.Element) && !ElementName.JDF.Equals(nam))
         {
            nam = ElementName.JDF + "/" + nam;
         }
         else if (cont.Equals(EnumContext.JMF) && !ElementName.JMF.Equals(nam))
         {
            nam = ElementName.JMF + "/" + nam;
         }
         return nam; // default is nam for resources
      }

      ///   
      ///	 <summary> * getDevCapVector()
      ///	 *  </summary>
      ///	 * <returns> VElement </returns>
      ///	 
      public VElement getDevCapVector()
      {
         VElement vDevCap = getChildElementVector(ElementName.DEVCAP, null, null, true, 0, false);
         string dcr = getAttribute(AttributeName.DEVCAPREF, null, null);
         if (dcr != null)
         {
            JDFDevCapPool dcp = getDevCapPool();
            if (dcp != null)
            {
               VString v = new VString(StringUtil.tokenize(dcr, " ", false));
               for (int i = 0; i < v.Count; i++)
               {
                  string s = v.stringAt(i);
                  KElement dcre = dcp.getChildWithAttribute(ElementName.DEVCAP, AttributeName.ID, null, s, 0, true);
                  vDevCap.appendUnique(dcre);
               }
            }
         }
         return vDevCap;
      }

      ///   
      ///	 <summary> * devCapReport - tests if the elements in vElem fit any (logical OR) DevCap
      ///	 * element that DevCaps consists of. Composes a detailed report in XML form
      ///	 * of the errors found. If XMLDoc is null there are no errors.<br>
      ///	 * 
      ///	 * DevCaps will be checked if they are direct children of <code>this</code>
      ///	 * and referenced in DevCapPool.
      ///	 *  </summary>
      ///	 * <param name="vElem">
      ///	 *            vector of the elements to test </param>
      ///	 * <param name="testlists">
      ///	 *            testlists that are specified for the State elements
      ///	 *            (FitsValue_Allowed or FitsValue_Present)<br>
      ///	 *            Will be used in fitsValue method of the State element. </param>
      ///	 * <param name="level">
      ///	 *            validation level </param>
      ///	 * <returns> XMLDoc - XMLDoc output of the error messages.<br>
      ///	 *         If XMLDoc is null there are no errors, every element of vElem
      ///	 *         fits any DevCap element of <code>this</code>. </returns>
      ///	 * <exception cref="JDFException">
      ///	 *             if DevCaps/@DevCapRef refers to the DevCap elements in a
      ///	 *             non-existent DevCapPool </exception>
      ///	 * <exception cref="JDFException">
      ///	 *             if DevCaps/@DevCapRef refers to the non-existent DevCap </exception>
      ///	 
      public KElement devCapReport(KElement elem, EnumFitsValue testlists, EnumValidationLevel level, bool ignoreExtensions, KElement parentReport)
      {
         if (elem == null)
            return null;
         VElement dcV = getDevCapVector();
         if (dcV == null || dcV.Count == 0)
         {
            throw new JDFException("JDFDevCaps.devCapReport: Invalid DeviceCap: DevCaps/@DevCapRef refers to the non-existent DevCap: " + getDevCapRef());
         }

         KElement r = parentReport.appendElement("Invalid" + getContext().getName());
         for (int i = 0; i < dcV.Count; i++)
         {
            JDFDevCap dc = (JDFDevCap)dcV[i];
            KElement stateTestResult = dc.stateReport(elem, testlists, level, ignoreExtensions, true, r);
            if (stateTestResult == null)
            {
               r.deleteNode();
               return null; // first DevCap that fits found -> erase all error
               // messages
            }
            r.setAttribute("XPath", elem.buildXPath(null, 1));
            r.setAttribute("Name", getContextName());
            r.setAttribute("CapXPath", dc.getName());
         }

         correction_Static(r);
         return r;
      }

      ///   
      ///	 <summary> * same as getName, except that "Link" is appended in case of
      ///	 * @Context="Link"
      ///	 *  </summary>
      ///	 * <returns> the element name mangled by context </returns>
      ///	 
      public virtual string getContextName()
      {
         string s = getName();
         if (s == null)
            return null;
         EnumContext context = getContext();
         if (EnumContext.Link.Equals(context))
            s += JDFConstants.LINK;
         return s;
      }

      ///   
      ///	 <summary> * Checks XPaths for every InvalidResource element of the given XMLDoc and
      ///	 * all chidren (of arbitrary depth). Appends right ancestors if CapXPath is
      ///	 * not complete.<br>
      ///	 * The point is that that the CapXPath's are created by using getNamePath()
      ///	 * method, where the root element is a DevCaps element. But starting with
      ///	 * JDF 1.3, DevCap can be located in DevCapPool and can be called from any
      ///	 * DevCaps. So the CapXPaths in XMLDoc doc are being fixed by setting the
      ///	 * right source of calling.
      ///	 *  </summary>
      ///	 * <param name="root">
      ///	 *            root of the XMLDoc document where the CapXPaths must be
      ///	 *            corrected </param>
      ///	 
      private static void correction_Static(KElement root)
      {
         VElement v = root.getChildElementVector("InvalidResource", null, null, true, 0, false);
         for (int i = 0; i < v.Count; i++)
         {
            KElement invRes = v[i];
            VElement vv = invRes.getChildElementVector(null, null, null, true, 0, false);
            for (int j = vv.Count - 1; j >= 0; j--)
            {
               capXPathCorrection_Static(vv[j], invRes.getAttribute("CapXPath"));
            }
            removePoolElements_Static(invRes);
         }
         return;
      }

      private static void removePoolElements_Static(KElement root)
      {
         VElement v = root.getChildElementVector(null, null, null, true, 0, false);
         for (int j = v.Count - 1; j >= 0; j--)
         {
            KElement el = v[j];
            string nam = el.Name;
            if (nam.Equals("InvalidAttributes") || nam.Equals("InvalidElements") || nam.Equals("UnknownAttributes") || nam.Equals("UnknownElements") || nam.Equals("MissingAttributes"))
            {
               moveChildElementVector_Static(root, el);
               if (!el.hasChildElements() && !el.hasAttributes())
                  root.removeChild(el);
            }

         }
         VElement vv = root.getChildElementVector(null, null, null, true, 0, false);
         for (int i = vv.Count - 1; i >= 0; i--)
         {
            removePoolElements_Static(vv[i]);
         }
         return;
      }

      ///   
      ///	 <summary> * For KElement 'elem' takes information from parent and children about
      ///	 * original and corrected CapXPaths, compare them and set CapXPath as a
      ///	 * complete path to this element.<br>
      ///	 * Checks CapXPath's for every InvalidResource element of the given XMLDoc
      ///	 * and all children (of arbitrary depth). Appends right ancestors if
      ///	 * CapXPath is not complete.<br>
      ///	 *  </summary>
      ///	 * <param name="elem">
      ///	 *            "pool" element like "InvalidElements" or "InvalidAttributes".<br>
      ///	 *            From this element we have access to its parent and children
      ///	 *            and can compare their CapXPath's </param>
      ///	 * <param name="originalPath">
      ///	 *            parent CapXPath before correction. </param>
      ///	 
      private static void capXPathCorrection_Static(KElement elem, string originalPath)
      {
         string parentPath = elem.getParentNode_KElement().getAttribute("CapXPath");

         VElement vEl = elem.getChildElementVector(null, null, null, true, 0, false);

         for (int i = 0; i < vEl.Count; i++)
         {
            KElement child = (KElement)vEl[i];
            string childPath = child.getAttribute("CapXPath");

            if (!parentPath.Equals(JDFConstants.EMPTYSTRING) && !childPath.Equals(JDFConstants.EMPTYSTRING))
            {
               string childPathPart = childPath;
               if (childPath.StartsWith(originalPath))
               {
                  childPathPart = childPath.Substring(originalPath.Length + 1); // +1 removes
                  // "/"
               }
               child.setAttribute("CapXPath", parentPath + "/" + childPathPart);

               // recursion to set everywhere the right CapXPath
               VElement vSubEl = child.getChildElementVector(null, null, null, true, 0, false);
               for (int j = 0; j < vSubEl.Count; j++)
               {
                  capXPathCorrection_Static(vSubEl[j], childPath);
               }
            }
         }
         return;
      }

      ///   
      ///	 <summary> * Moves the ChildElementVector of the second element into the first
      ///	 *  </summary>
      ///	 * <param name="moveToElement">
      ///	 *            the first element - new parent for the children of the second
      ///	 *            element </param>
      ///	 * <param name="moveFromElement">
      ///	 *            the second element - element whose children will be removed </param>
      ///	 
      private static void moveChildElementVector_Static(KElement moveToElement, KElement moveFromElement)
      {
         if (moveToElement != null && moveFromElement != null)
         {
            VElement v = moveFromElement.getChildElementVector(null, null, null, true, 0, false);
            for (int i = 0; i < v.Count; i++)
            {
               moveToElement.moveElement(v[i], null);
            }
         }
         return;
      }

      ///   
      ///	 <summary> * gets the matching elements in node that match this devcap
      ///	 *  </summary>
      ///	 * <param name="node">
      ///	 *            the node to search in </param>
      ///	 * <returns> VElement - the element vector of matching elements,
      ///	 *         <code>null</code> if none were found </returns>
      ///	 
      private VElement getMatchingElementsFromNode(JDFNode node)
      {
         VElement vElem = new VElement();

         string nam = getName();
         EnumContext context = getContext();
         JDFResourceLinkPool resLinkPool = node.getResourceLinkPool();

         if (context.Equals(EnumContext.Element))
         { // vElem - for a common return type in all cases
            if (nam.Equals(ElementName.JDF))
            {
               vElem.Add(node);
            }
            else
            {
               vElem = node.getChildElementVector(nam, null, null, true, 0, false);
            }
         }
         else if (context.Equals(EnumContext.Link) || context.Equals(EnumContext.Resource))
         {
            if (resLinkPool != null)
            {
               EnumUsage linkUsage = getLinkUsage();
               string procUsage = getProcessUsage();
               bool bLink = context.Equals(EnumContext.Link);
               VElement vElemLinks = resLinkPool.getInOutLinks(linkUsage, true, nam, null);
               if (vElemLinks != null)
               {
                  int linkSize = vElemLinks.Count - 1;
                  for (int j = linkSize; j >= 0; j--)
                  {
                     JDFResourceLink rl = (JDFResourceLink)vElemLinks[j];
                     string rlProcessUsage = rl.getProcessUsage();
                     if (!rlProcessUsage.Equals(procUsage))
                     {
                        vElemLinks.RemoveAt(j);
                     }
                  }
               }

               if (!bLink)
               {
                  vElem = JDFResourceLinkPool.resourceVector(vElemLinks, null);
               }
               else
               {
                  vElem = vElemLinks;
               }
            }
         }
         else if (context.Equals(EnumContext.JMF))
         {
            // TODO __Lena__ ...
         }
         else
         { // Context_Unknown
            throw new JDFException("JDFDevCaps wrong attribute Context value");
         }

         if (vElem != null && vElem.Count == 0)
            vElem = null;

         return vElem;
      }

      ///   
      ///	 <summary> * gets the matching elements in node that match this devcaps
      ///	 *  </summary>
      ///	 * <param name="node">
      ///	 *            the node to search in </param>
      ///	 * <returns> VElement - the element vector of matching elements,
      ///	 *         <code>null</code> if none were found </returns>
      ///	 
      public virtual VElement getMatchingElementsFromJMF(JDFMessage messageElement)
      {
         string nam = getName();
         EnumContext context = getContext();

         if (!EnumContext.JMF.Equals(context) && !EnumContext.Element.Equals(context))
         {
            return null;
         }
         VElement vElem;
         if (ElementName.JMF.Equals(nam))
         {
            vElem = new VElement();
            vElem.Add(messageElement.getParentNode_KElement());
         }
         else if (messageElement.LocalName.Equals(nam))
         {
            vElem = new VElement();
            vElem.Add(messageElement);
         }
         else
         {
            vElem = messageElement.getChildElementVector(nam, null, null, true, 0, false);

            if (vElem != null && vElem.Count == 0)
               vElem = null;
         }
         return vElem;
      }

      ///   
      ///	 <summary> * append elements to the node that match this DevCap, if they do not exist
      ///	 * yet
      ///	 *  </summary>
      ///	 * <param name="node">
      ///	 *            the node to append the elements to </param>
      ///	 * <param name="bAll">
      ///	 *            if false, only add if minOccurs>=1 and required=true or a
      ///	 *            default exists
      ///	 *  </param>
      ///	 * <returns> KElement - the last element that was appended </returns>
      ///	 
      public virtual KElement appendMatchingElementsToNode(JDFNode node, bool bAll, org.cip4.jdflib.util.VectorMap<int, JDFResource> indexResMap, bool bLink)
      {
         KElement e = null;

         EnumContext context = getContext();
         if (!bLink && EnumContext.Link.Equals(context))
            return null;

         if (bLink && !EnumContext.Link.Equals(context))
            return null;

         JDFDevCap devCap = getDevCap();
         if (devCap == null)
            return null;

         int minOcc = devCap.getMinOccurs();
         if (minOcc == 0 && bAll)
            minOcc = 1;

         string nam = getName();
         for (int i = 0; i < minOcc; i++)
         {
            if (context.Equals(EnumContext.Element))
            { // vElem - for a common return type in all cases
               if (nam.Equals(ElementName.JDF))
               {
                  // nop - should actually never get here
               }
               else
               {
                  e = node.getCreateElement(nam, getDevNS(), i);
               }
            }
            else if (context.Equals(EnumContext.Resource) || context.Equals(EnumContext.Link))
            {
               EnumUsage linkUsage = getLinkUsage();
               string procUsage = getProcessUsage();
               JDFAttributeMap map = new JDFAttributeMap();
               EnumProcessUsage pu = null;

               if (procUsage != null && procUsage.Length > 0)
               {
                  map.put(AttributeName.PROCESSUSAGE, procUsage);
                  pu = EnumProcessUsage.getEnum(procUsage);
               }

               if (linkUsage != null)
               {
                  map.put(AttributeName.USAGE, linkUsage.getName());
               }

               VElement links = node.getResourceLinks(nam, map, null);
               // now look for the correct combinedprocessindex - remove all
               // non-matching
               JDFIntegerRangeList tocNum = getTypeOccurrenceNum();
               JDFIntegerList tocNum2 = tocNum == null ? null : tocNum.getIntegerList();
               if (links != null && tocNum != null)
               {
                  for (int ll = links.Count - 1; ll >= 0; ll--)
                  {
                     JDFResourceLink rl = (JDFResourceLink)links[ll];
                     JDFIntegerList il = rl.getCombinedProcessIndex();
                     if (il == null || !il.Contains(tocNum2))
                        links.RemoveAt(ll);
                  }
               }

               if (links == null || links.Count <= i)
               {
                  JDFResource r = null;
                  // get a link hook for the matching combinedprocessindex
                  if (bLink)
                  {
                     int kk = (tocNum2 == null || tocNum2.Count == 0) ? -1 : tocNum2.getInt(0);
                     if (EnumUsage.Input.Equals(linkUsage))
                        kk--;
                     List<JDFResource> v = indexResMap[kk]; // (new int(kk));
                     if (v != null)
                     {
                        int sv = v.Count;
                        for (int kkk = 0; kkk < sv; kkk++)
                        {
                           JDFResource rr = v[kkk];
                           if (rr.LocalName.Equals(nam))
                           {
                              r = rr;
                              break;
                           }
                        }
                     }
                  }

                  // we found no matching existing res - make a new one
                  if (r == null)
                  {
                     r = node.addResource(nam, null, linkUsage, pu, null, getDevNS(), null);
                     string id = devCap.getAttribute(AttributeName.ID, null, null);
                     if (id != null)
                     {
                        JDFResourceLink rl = node.getLink(r, linkUsage);

                        r.setID(id);
                        if (rl != null)
                        {
                           rl.setrRef(id);
                        }
                     }

                     if (tocNum2 == null || tocNum2.Count == 0)
                        indexResMap.putOne(-1, r); //(new int(-1), r);
                     else
                        indexResMap.putOne((int)tocNum2.elementAt(0), r); // only
                     // support
                     // 1
                     // now
                  }
                  else
                  // preexisting resource - just link it
                  {
                     e = node.linkResource(r, linkUsage, pu);
                  }

                  e = node.getLink(r, linkUsage);
                  if (e != null)
                  {
                     JDFResourceLink rl = (JDFResourceLink)e;
                     rl.setCombinedProcessIndex(tocNum2);
                  }

                  // update partititons
                  JDFEnumerationState pidKeys = devCap.getEnumerationState(AttributeName.PARTIDKEYS);
                  if (pidKeys != null)
                  {
                     VString keys = pidKeys.getAllowedValueList();
                     if (keys != null && keys.Count > 0)
                     {
                        JDFAttributeMap keyMap = new JDFAttributeMap();
                        for (int k = 0; k < keys.Count; k++)
                        {
                           string sk = "PartKey" + k;
                           string key = keys.stringAt(k);
                           if (key.Equals("RunIndex"))
                              sk = "0~-1";
                           keyMap.put(key, sk);
                        }

                        r.getCreatePartition(keyMap, keys);
                     }
                  }
               }
            }
            else if (context.Equals(EnumContext.JMF))
            {
               // TODO __Lena__ ...
            }
         }

         return e;
      }

      ///   
      ///	 <summary> * sets default elements and adds them, if there are less than minOccurs
      ///	 *  </summary>
      ///	 * <param name="node">
      ///	 *            the node to set </param>
      ///	 * <param name="bAll">
      ///	 *            if false, only add if minOccurs>=1 and required=true or a
      ///	 *            default exists, if true, always create one
      ///	 *  </param>
      ///	 * <returns> boolean true if a default element was created, else false </returns>
      ///	 
      public virtual bool setDefaultsFromCaps(JDFNode node, bool bAll)
      {
         bool modified = false;

         JDFDevCap dc = getDevCap();
         if (dc != null)
         {
            VElement v = getMatchingElementsFromNode(node);
            if (v != null)
            {
               int size = v.Count;
               for (int i = 0; i < size; i++)
               {
                  modified = dc.setDefaultsFromCaps(v.item(i), bAll) || modified;
               }
            }
         }

         return modified;
      }

      ///   
      ///	 <summary> * return the highest maxOccurs of all devCap elements
      ///	 *  </summary>
      ///	 * <returns> int - the highest maxOccurs of all devCap elements </returns>
      ///	 
      public virtual int getMaxOccurs()
      {
         int m = 0;

         VElement vDC = getDevCapVector();
         if (vDC != null)
         {
            int svDC = vDC.Count;
            for (int i = 0; i < svDC; i++)
            {
               JDFDevCap dc = (JDFDevCap)vDC[i];
               if (m < dc.getMaxOccurs())
                  m = dc.getMaxOccurs();
            }
         }

         return m;

      }

      ///   
      ///	 <summary> * return the lowest minOccurs of all devCap elements
      ///	 *  </summary>
      ///	 * <returns> int - the lowest minOccurs of all devCap elements </returns>
      ///	 
      public virtual int getMinOccurs()
      {
         int m = int.MaxValue;

         VElement vDC = getDevCapVector();
         if (vDC != null)
         {
            int svDC = vDC.Count;
            for (int i = 0; i < svDC; i++)
            {
               JDFDevCap dc = (JDFDevCap)vDC[i];
               if (m > dc.getMinOccurs())
                  m = dc.getMinOccurs();
            }
         }

         if (m <= 0 && getRequired())
            m = 1;

         return m;

      }

      ///   
      ///	 * <param name="testRoot"> </param>
      ///	 * <param name="testlists"> </param>
      ///	 * <param name="level"> </param>
      ///	 * <param name="mrp"> </param>
      ///	 * <param name="irp"> </param>
      ///	 * <param name="resLinkPool"> </param>
      ///	 * <param name="goodElems"> </param>
      ///	 * <param name="badElems"> </param>
      ///	 * <param name="devCaps">
      ///	 * @return </param>
      ///	 
      public virtual void analyzeDevCaps(KElement testRoot, EnumFitsValue testlists, EnumValidationLevel level, KElement mrp, KElement irp, SupportClass.HashSetSupport goodElems, Hashtable badElems, bool ignoreExtensions)
      {
         EnumAvailability av = getModuleAvailability();
         KElement xpathRoot = testRoot;
         VElement vElemResources = null;
         if (testRoot is JDFNode)
         {
            JDFNode jdfNode = (JDFNode)testRoot;
            vElemResources = getMatchingElementsFromNode(jdfNode);
            xpathRoot = jdfNode.getResourceLinkPool();
            if (xpathRoot == null)
               xpathRoot = testRoot;
         }
         else
         {
            vElemResources = getMatchingElementsFromJMF((JDFMessage)testRoot);
         }

         int svElemResources = vElemResources == null ? 0 : vElemResources.Count;

         EnumContext context = getContext();
         KElement r = null;
         if (EnumValidationLevel.isRequired(level) && svElemResources < getMinOccurs() && EnumAvailability.Installed.Equals(av))
         {
            if (EnumContext.Element.Equals(context) || EnumContext.JMF.Equals(context))
            {
               r = mrp.appendElement("MissingElement");
               r.setAttribute("XPath", xpathRoot.buildXPath(null, 1) + "/" + getName());
            }
            else
            {
               EnumUsage linkUsage = getLinkUsage();
               string procUsage = getProcessUsage();
               r = mrp.appendElement("MissingResourceLink");
               if (linkUsage != null)
               {
                  r.setAttribute("Usage", linkUsage.getName());
               }
               if (procUsage != null && procUsage.Length > 0)
               {
                  r.setAttribute("ProcessUsage", procUsage);
               }
               r.setAttribute("XPath", xpathRoot.buildXPath(null, 1) + "/" + getName());
            }
            r.setAttribute("Name", getName());
            r.setAttribute("CapXPath", getName());
            r.setAttribute("Occurrences", svElemResources, null);
            r.setAttribute("MinOccurs", getMinOccurs(), null);
         }
         else if (svElemResources > getMaxOccurs() || !EnumAvailability.Installed.Equals(av))
         {
            if (context.Equals(EnumContext.Element) || context.Equals(EnumContext.JMF))
            {
               r = irp.appendElement("ManyElement");
               r.setAttribute("XPath", testRoot.buildXPath(null, 1) + "/" + getName());
            }
            else
            {
               EnumUsage linkUsage = getLinkUsage();
               string procUsage = getProcessUsage();
               r = irp.appendElement("ManyResourceLink");
               if (linkUsage != null)
               {
                  r.setAttribute("Usage", linkUsage.getName());
               }

               if (procUsage != null && procUsage.Length > 0)
               {
                  r.setAttribute("ProcessUsage", procUsage);
               }

               r.setAttribute("XPath", xpathRoot.buildXPath(null, 1) + "/" + getName());
            }

            r.setAttribute("Name", getName());
            r.setAttribute("CapXPath", getName());
            r.setAttribute("Occurrences", svElemResources, null);
            r.setAttribute("MaxOccurs", getMaxOccurs(), null);
            r.setAttribute("Availability", av == null ? "None" : av.getName());
         }

         if (vElemResources != null)
         {
            for (int j = 0; j < svElemResources; j++)
            {
               KElement elem = vElemResources.item(j);
               if (!goodElems.Contains(elem))
               {
                  KElement report = devCapReport(elem, testlists, level, ignoreExtensions, irp); // InvalidResources
                  if (report == null)
                  {
                     goodElems.Add(elem);
                     KElement badReport = (KElement)badElems[elem];
                     if (badReport != null)
                        badReport.deleteNode();
                  }
                  else
                  {
                     badElems.Add(elem, report);
                  }
               }
            }
         }
      }

      ///   
      ///	 <summary> * get the availability of this devcaps based on the list of installed
      ///	 * modules in ModuleRefs and ModulePool
      ///	 * 
      ///	 * @return </summary>
      ///	 
      public virtual EnumAvailability getModuleAvailability()
      {
         return JDFModulePool.getModuleAvailability(this);
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see
      //	 * org.cip4.jdflib.core.JDFElement#getInvalidAttributes(org.cip4.jdflib.
      //	 * core.KElement.EnumValidationLevel, boolean, int)
      //	 
      public override VString getInvalidAttributes(EnumValidationLevel level, bool bIgnorePrivate, int nMax)
      {
         VString vs = base.getInvalidAttributes(level, bIgnorePrivate, nMax);
         if (nMax > 0 && vs.Count > nMax)
            return vs;
         if (!EnumValidationLevel.RecursiveComplete.Equals(level) && !EnumValidationLevel.RecursiveIncomplete.Equals(level))
            return vs;
         if (vs.Contains(AttributeName.DEVCAPREF))
            return vs;

         if (hasAttribute(AttributeName.DEVCAPREF))
         {
            JDFDevCapPool devCapPool = getDevCapPool();
            if (devCapPool == null)
            {
               vs.Add(AttributeName.DEVCAPREF);
               return vs;
            }
            VString idRefs = getDevCapRef();
            for (int i = 0; i < idRefs.Count; i++)
            {
               JDFDevCap devCap = devCapPool.getDevCap(idRefs.stringAt(i));
               if (devCap == null)
               {
                  vs.Add(AttributeName.DEVCAPREF);
                  return vs;
               }
            }
         }
         return vs;
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see
      //	 * org.cip4.jdflib.ifaces.IModuleCapability#appendModuleRef(java.lang.String
      //	 * )
      //	 
      public virtual JDFModuleCap appendModuleRef(string id)
      {
         return JDFModulePool.appendModuleRef(this, id);
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.ifaces.ICapabilityElement#getEvaluationType()
      //	 
      public virtual EnumTerm getEvaluationType()
      {
         return EnumTerm.IsPresentEvaluation;
      }
   }
}
