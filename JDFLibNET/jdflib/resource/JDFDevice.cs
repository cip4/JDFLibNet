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
 * ==========================================================================
 * class JDFDevice
 * ==========================================================================
 * @COPYRIGHT Heidelberger Druckmaschinen AG, 1999-2001
 * ALL RIGHTS RESERVED
 * @Author: sabjon@topmail.de   using a code generator
 * Warning! very preliminary test version. Interface subject to change without prior notice!
 * Revision history:    ... 
 */

namespace org.cip4.jdflib.resource
{


   using JDFAutoDevice = org.cip4.jdflib.auto.JDFAutoDevice;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using XMLDoc = org.cip4.jdflib.core.XMLDoc;
   using EnumFitsValue = org.cip4.jdflib.datatypes.EnumFitsValue;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using JDFDeviceCap = org.cip4.jdflib.resource.devicecapability.JDFDeviceCap;


   public class JDFDevice : JDFAutoDevice
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFDevice
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFDevice(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFDevice
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFDevice(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFDevice
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="localName"> </param>

      ///	 
      public JDFDevice(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      public override string ToString()
      {
         return "JDFDevice[  --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * test whether a given node has the corect Types and Type Attribute
      ///	 *  </summary>
      ///	 * <param name="testRoot"> the JDF or JMF to test
      ///	 *  </param>
      ///	 * <returns> VElement - the list of matching JDF nodes, null if none found
      ///	 *  </returns>
      ///	 
      public virtual VElement getMatchingTypeNodeVector(JDFNode testRoot)
      {
         VElement vDeviceCap = getChildElementVector(ElementName.DEVICECAP, null, null, false, -1, false);
         if (vDeviceCap == null || vDeviceCap.IsEmpty())
            return null;
         VElement vRet = new VElement();
         for (int i = 0; i < vDeviceCap.Count; i++)
         {
            VElement vMatch = ((JDFDeviceCap)vDeviceCap[i]).getMatchingTypeNodeVector(testRoot);
            if (vMatch != null)
            {
               vRet.addAll(vMatch);
            }
         }
         vRet.unify();
         return vRet.IsEmpty() ? null : vRet;
      }

      ///   
      ///	 <summary> * return all deviceCap elements that correspond to testRoot
      ///	 *  </summary>
      ///	 * <param name="testRoot"> the JDF or JMF to test
      ///	 *  </param>
      ///	 * <returns> VElement - the list of matching devicecap nodes, null if none found
      ///	 *  </returns>
      ///	 
      public virtual VElement getMatchingDeviceCapVector(JDFNode testRoot, bool bLocal)
      {
         VElement vDeviceCap = getChildElementVector(ElementName.DEVICECAP, null, null, false, -1, false);
         if (vDeviceCap == null || vDeviceCap.IsEmpty())
            return null;
         VElement vRet = new VElement();
         for (int i = 0; i < vDeviceCap.Count; i++)
         {
            JDFDeviceCap dc = (JDFDeviceCap)vDeviceCap[i];
            if (dc.matchesType(testRoot, bLocal))
            {
               vRet.Add(dc);
            }
         }
         return vRet.IsEmpty() ? null : vRet;
      }

      ///   
      ///	 <summary> * test whether a given node has the corect Types and Type Attribute
      ///	 *  </summary>
      ///	 * <param name="testRoot"> the JDF or JMF to test </param>
      ///	 * <param name="bLocal"> if true, only check the root of this, else check children as well
      ///	 *  </param>
      ///	 * <returns> boolean - true if this DeviceCaps TypeExpression fits testRoot/@Type and testRoot/@Types
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
      ///	 <summary> * Gets of jdfRoot a vector of all executable nodes (jdf root or children nodes that this Device may execute)
      ///	 *  </summary>
      ///	 * <param name="jdfRoot"> the node we test </param>
      ///	 * <param name="testlists"> testlists that are specified for the State elements (FitsValue_Allowed or FitsValue_Present)<br>
      ///	 *            Will be used in fitsValue method of the State class. </param>
      ///	 * <param name="level"> validation level </param>
      ///	 * <returns> VElement - vector of executable JDFNodes </returns>
      ///	 
      public virtual VElement getExecutableJDF(JDFNode docRoot, EnumFitsValue testlists, EnumValidationLevel validationLevel)
      {
         VElement vDC = getChildElementVector(ElementName.DEVICECAP, null, null, true, -1, false);
         if (vDC == null || vDC.IsEmpty())
            return null;

         VElement vn = new VElement();
         for (int i = 0; i < vDC.Count; i++)
         {
            JDFDeviceCap dc = (JDFDeviceCap)vDC[i];
            VElement executableJDF = dc.getExecutableJDF(docRoot, testlists, validationLevel);
            if (executableJDF != null)
               vn.addAll(executableJDF);
         }
         vn.unify();
         return vn.IsEmpty() ? null : vn;
      }

      ///   
      ///	 <summary> * Composes a BugReport in XML form for the given JDFNode 'jdfRoot'. Gives a list of error messages for 'jdfRoot'
      ///	 * and every child rejected Node.<br>
      ///	 * Returns <code>null</code> if there are no errors.
      ///	 *  </summary>
      ///	 * <param name="jdfRoot"> the node to test </param>
      ///	 * <param name="testlists"> testlists that are specified for the State elements (FitsValue_Allowed or FitsValue_Present)<br>
      ///	 *            Will be used in fitsValue method of the State class. </param>
      ///	 * <param name="level"> validation level </param>
      ///	 * <returns> XMLDoc - XMLDoc output of the error messages. If XMLDoc is null there are no errors. </returns>
      ///	 
      public XMLDoc getBadJDFInfo(JDFNode jdfRoot, EnumFitsValue testlists, EnumValidationLevel level)
      {
         VElement vDC = getChildElementVector(ElementName.DEVICECAP, null, null, true, -1, false);
         if (vDC == null || vDC.IsEmpty())
            return null;

         VElement vn = new VElement();
         for (int i = 0; i < vDC.Count; i++)
         {
            JDFDeviceCap dc = (JDFDeviceCap)vDC[i];
            XMLDoc bugReport = dc.getBadJDFInfo(jdfRoot, testlists, level);
            if (bugReport == null)
               return null;
            vn.addAll(bugReport.getRoot().getChildElementVector(null, null, null, true, -1, false));
         }

         int vnSize = vn.Count;
         if (vnSize == 0)
            return null;

         XMLDoc bugReport2 = new XMLDoc("BugReport", null);
         KElement root = bugReport2.getRoot();
         bool bFit = false;
         for (int i = 0; i < vnSize; i++)
         {
            KElement e = vn[i];
            if (JDFConstants.TRUE.Equals(e.getAttribute(JDFDeviceCap.FITS_TYPE)))
               bFit = true;
         }
         if (bFit)
         {
            for (int i = 0; i < vnSize; i++)
            {
               KElement e = vn[i];
               if (JDFConstants.FALSE.Equals(e.getAttribute(JDFDeviceCap.FITS_TYPE)))
                  vn[i] = null;
            }
         }
         for (int i = 0; i < vnSize; i++)
         {
            if (vn[i] != null)
               root.moveElement(vn.item(i), null);
         }
         return bugReport2;
      }
   }
}
