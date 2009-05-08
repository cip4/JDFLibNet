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
 * JDFAncestorPool.cs
 * Last changes
 * 2002-07-02 JG added Part element support
 * 2002-07-02 JG added GetPoolChild, GetPoolChildren
 * 2002-07-02 JG added CopyNodeData
 * 2002-07-02 JG added GetAncestorAttribute(), HasAncestorAttribute()
 * 2002-07-02 JG added GetAncestorElement(), HasAncestorElement()
 */

namespace org.cip4.jdflib.pool
{
   using System;


   using JDFAutoAncestorPool = org.cip4.jdflib.auto.JDFAutoAncestorPool;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFCustomerInfo = org.cip4.jdflib.core.JDFCustomerInfo;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFNodeInfo = org.cip4.jdflib.core.JDFNodeInfo;
   using JDFRefElement = org.cip4.jdflib.core.JDFRefElement;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using JDFAncestor = org.cip4.jdflib.node.JDFAncestor;
   using JDFNode = org.cip4.jdflib.node.JDFNode;

   ///
   /// <summary> * 
   /// * Description: This class represents an JDFAncestorPool
   /// * 
   /// * @author Torsten Kaehlert
   /// * 
   /// * @version 1.0 2002-01-28
   /// *  </summary>
   /// 
   public class JDFAncestorPool : JDFAutoAncestorPool
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFAncestorPool
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFAncestorPool(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFAncestorPool
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFAncestorPool(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFAncestorPool
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFAncestorPool(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      ///   
      ///	 <summary> * searches for the first attribute occurence in the ancestor elements
      ///	 *  </summary>
      ///	 * <param name="attrib"> the attribute name </param>
      ///	 * <param name="nameSpaceURI"> the XML-namespace </param>
      ///	 * <param name="def"> the default if it does not exist
      ///	 * @since 180502 </param>
      ///	 * <returns> value of attribute found, value of def if not available </returns>
      ///	 
      public virtual string getAncestorAttribute(string attrib, string nameSpaceURI, string def)
      {
         VElement v = getPoolChildren(null);

         // the last in list is the direct parent, the first is the original root
         for (int i = v.Count - 1; i >= 0; i--)
         {
            JDFAncestor ancestor = (JDFAncestor)v[i];
            if (ancestor.hasAttribute(attrib, nameSpaceURI, false))
            {
               return ancestor.getAttribute(attrib, nameSpaceURI, JDFConstants.EMPTYSTRING);
            }
         }
         // not found, return the default
         return def;
      }

      ///   
      ///	 <summary> * @deprecated
      ///	 *  </summary>
      ///	 * <param name="element"> </param>
      ///	 * <param name="nameSpaceURI">
      ///	 * @return </param>
      ///	 
      [Obsolete]
      public virtual KElement getAncestorElement(string element, string nameSpaceURI)
      {
         return getAncestorElement(element, nameSpaceURI, null);
      }

      ///   
      ///	 <summary> * searches for the first element occurence in the ancestor elements
      ///	 *  </summary>
      ///	 * <param name="element"> the element name </param>
      ///	 * <param name="nameSpaceURI"> the XML-namespace of the element </param>
      ///	 * <param name="xPath"> the xpath of a required attribute
      ///	 * @since 290502 </param>
      ///	 * <returns> value of attribute found, empty string if not available </returns>
      ///	 
      public virtual KElement getAncestorElement(string element, string nameSpaceURI, string xPath)
      {
         VElement v = getPoolChildren(null);
         bool bWildCard = isWildCard(xPath);
         // the last in list is the direct parent, the first is the original root
         for (int i = v.Count - 1; i >= 0; i--)
         {
            JDFAncestor ancestor = (JDFAncestor)v[i];
            KElement e = ancestor.getElement(element, nameSpaceURI, 0);
            if ((e != null) && (bWildCard || e.hasXPathNode(xPath)))
               return e;
         }
         // not found, return an empty element
         return null;
      }

      ///   
      ///	 <summary> * true id a non default occurence in the ancestor elements exists
      ///	 *  </summary>
      ///	 * <param name="attrib"> the attribute name </param>
      ///	 * <param name="nameSpaceURI"> the XML-namespace
      ///	 * @since 180502 </param>
      ///	 * <returns> value of attribute found, empty string if not available </returns>
      ///	 
      public virtual bool hasAncestorElement(string attrib, string nameSpaceURI)
      {
         return getAncestorElement(attrib, nameSpaceURI, null) != null;
      }

      ///   
      ///	 <summary> * Get the linked resources matching some conditions
      ///	 *  </summary>
      ///	 * <param name="mResAtt"> map of Resource attributes to search for </param>
      ///	 * <param name="bFollowRefs"> true if internal references shall be followed
      ///	 *  </param>
      ///	 * <returns> vResource: vector with all elements matching the conditions
      ///	 * 
      ///	 *         default: GetLinkedResources(new JDFAttributeMap(), false) </returns>
      ///	 
      public virtual VElement getLinkedResources(JDFAttributeMap mResAtt, bool bFollowRefs)
      {
         VElement vChild = getPoolChildren(mResAtt);
         VElement vElem = new VElement();
         for (int i = 0; i < vChild.Count; i++)
         {
            JDFAncestor anc = (JDFAncestor)vChild[i];
            vElem.appendUnique(anc.getLinkedResources(mResAtt, bFollowRefs));
         }
         return vElem;
      }

      ///   
      ///	 <summary> * Copy all data from rootNode into the Ancestor elements of this
      ///	 *  </summary>
      ///	 * <param name="parentNode"> the closest parent Node that contains the information to be copied </param>
      ///	 * @deprecated use public void copyNodeData (JDFNode parentNode, false, false) instead 
      ///	 
      [Obsolete("use public void copyNodeData (JDFNode parentNode, false, false) instead")]
      public virtual void copyNodeData(JDFNode parentNode)
      {
         copyNodeData(parentNode, true, true, true);
      }

      ///   
      ///	 <summary> * Copy all data from parentNode into the ancestor elements of this
      ///	 *  </summary>
      ///	 * <param name="parentNode"> the closest parent Node that contains the information to be copied </param>
      ///	 * <param name="bCopyNodeInfo"> if true, also copy the NodeInfo into the ancestor </param>
      ///	 * <param name="bCopyCustomerInfo"> if true, also copy the CustomerInfo into the ancestor </param>
      ///	 * <param name="bCopyComments"> if true, also copy the comments into the ancestor
      ///	 * @default copyNodeData(parentNode, false, false, false); </param>
      ///	 
      public virtual void copyNodeData(JDFNode parentNode, bool bCopyNodeInfo, bool bCopyCustomerInfo, bool bCopyComments)
      {
         VElement vAncestors = getPoolChildren(null);
         JDFNode node = parentNode;

         JDFNode thisParentNode = getParentJDF();

         int i;
         for (i = vAncestors.Count - 1; i >= 0; i--)
         {
            JDFAncestor ancestor = (JDFAncestor)vAncestors[i];
            if (!node.getID().Equals(ancestor.getNodeID()))
            {
               throw new JDFException("JDFAncestorPool::CopyNodeData: Invalid pairing");
            }

            ancestor.setAttributes(node);
            ancestor.removeAttribute(AttributeName.XSITYPE);
            ancestor.renameAttribute(AttributeName.ID, AttributeName.NODEID, null, null);
            // only copy nodeinfo and customerinfo in real parent nodes, not in
            // this of partitioned spawns
            if (!thisParentNode.getID().Equals(node.getID()))
            {
               if (bCopyNodeInfo)
               {
                  JDFNodeInfo nodeInfo = node.getNodeInfo();
                  if (nodeInfo != null)
                  {
                     if (nodeInfo.getParentNode_KElement() is JDFResourcePool)
                     {
                        // add a low level refelement, the copying takes
                        // place inaddspawnedresources
                        JDFRefElement re = (JDFRefElement)ancestor.appendElement(ElementName.NODEINFO + JDFConstants.REF);
                        re.setrRef(nodeInfo.getID());
                        re.setPartMap(nodeInfo.getPartMap());
                     }
                     else
                     {
                        ancestor.copyElement(nodeInfo, null);
                     }
                  }
               }

               if (bCopyCustomerInfo)
               {
                  JDFCustomerInfo customerInfo = node.getCustomerInfo();
                  if (customerInfo != null)
                  {
                     if (customerInfo.getParentNode_KElement() is JDFResourcePool)
                     {
                        // add a low level refelement, the copying takes
                        // place inaddspawnedresources
                        JDFRefElement re = (JDFRefElement)ancestor.appendElement(ElementName.CUSTOMERINFO + JDFConstants.REF);
                        re.setrRef(customerInfo.getID());
                        re.setPartMap(customerInfo.getPartMap());
                     }
                     else
                     {
                        ancestor.copyElement(customerInfo, null);
                     }
                  }
               }

               if (bCopyComments)
               {
                  VElement v = node.getChildElementVector(ElementName.COMMENT, null, null, true, 0, false);
                  for (int j = 0; j < v.Count; j++)
                  {
                     ancestor.copyElement(v[j], null);
                  }
               }

            }

            JDFNode node2 = node.getParentJDF();

            // 100602 RP added i--
            if (node2 == null)
            {
               i--;
               break;
            }
            node = node2;
         }

         // the original node was already spawned --> also copy the elements of
         // the original nodes Ancestorpool
         if (i >= 0)
         {
            VElement parentAncestors = node.getAncestorPool().getPoolChildren(null);
            int parentAncestorSize = parentAncestors.Count;
            if (parentAncestorSize < i + 1)
            {
               throw new JDFException("JDFAncestorPool.CopyNodeData: Invalid AncestorPool pairing");
            }

            // now copy the ancestorpool elements that have not yet been added
            // from the original nodes
            for (; i >= 0; i--)
            {
               JDFAncestor ancestor = (JDFAncestor)vAncestors[i];
               JDFAncestor parentAncestor = (JDFAncestor)parentAncestors[i];
               ancestor.mergeElement(parentAncestor, false);
            }
         }
      }

      ///   
      ///	 <summary> * Gets all children with the attribute out of the pool
      ///	 *  </summary>
      ///	 * <param name="mAttrib"> the attribute to search for </param>
      ///	 * <returns> VElement: a vector with all elements in the pool matching the conditions
      ///	 * 
      ///	 *         default: GetPoolChildren(null) </returns>
      ///	 
      public virtual VElement getPoolChildren(JDFAttributeMap mAttrib)
      {
         return getPoolChildrenGeneric(ElementName.ANCESTOR, mAttrib, null);
      }

      ///   
      ///	 <summary> * get a child from the pool matching the parameters
      ///	 *  </summary>
      ///	 * <param name="i"> the index of the child or -1 to make a new one. </param>
      ///	 * <param name="mAttrib"> an attribute to search for </param>
      ///	 * <returns> JDFAncestor: the pool child matching the above conditions
      ///	 * 
      ///	 *         default: GetPoolChild(i, null) </returns>
      ///	 
      public virtual JDFAncestor getPoolChild(int i, JDFAttributeMap mAttrib)
      {
         return (JDFAncestor)getPoolChildGeneric(i, ElementName.ANCESTOR, mAttrib, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * get part map vector
      ///	 *  </summary>
      ///	 * <returns> VJDFAttributeMap: vector of mAttribute, one for each part </returns>
      ///	 
      public override VJDFAttributeMap getPartMapVector()
      {
         return base.getPartMapVector();
      }

      ///   
      ///	 <summary> * set all parts to those define in vParts
      ///	 *  </summary>
      ///	 * <param name="vParts"> vector of attribute maps for the parts </param>
      ///	 
      public override void setPartMapVector(VJDFAttributeMap vParts)
      {
         base.setPartMapVector(vParts);
      }

      ///   
      ///	 <summary> * set all parts to those define in vParts
      ///	 *  </summary>
      ///	 * <param name="mPart"> attribute map for the part to set </param>
      ///	 
      public override void setPartMap(JDFAttributeMap mPart)
      {
         base.setPartMap(mPart);
      }

      ///   
      ///	 <summary> * remove the part defined in mPart
      ///	 *  </summary>
      ///	 * <param name="mPart"> attribute map for the part to remove </param>
      ///	 
      public override void removePartMap(JDFAttributeMap mPart)
      {
         base.removePartMap(mPart);
      }

      ///   
      ///	 <summary> * check whether the part defined in mPart is included
      ///	 *  </summary>
      ///	 * <param name="mPart"> attribute map for the part to remove </param>
      ///	 * <returns> true if the part exists </returns>
      ///	 
      public override bool hasPartMap(JDFAttributeMap mPart)
      {
         return base.hasPartMap(mPart);
      }

      ///   
      ///	 <summary> * check whether a defined attribute exists in the ancestor elements
      ///	 *  </summary>
      ///	 * <param name="attrib"> the attribute name to look for </param>
      ///	 * <param name="nameSpaceURI"> the XML-namespace to search in
      ///	 * @since 180502 </param>
      ///	 * <returns> value of attribute found, empty string if not available </returns>
      ///	 
      public virtual bool hasAncestorAttribute(string attrib, string nameSpaceURI)
      {
         return getAncestorAttribute(attrib, nameSpaceURI, null) != null;
      }

      ///   
      ///	 <summary> * searches for the first attribute occurence in the ancestor elements subelements<br>
      ///	 * e.g. the JobPriority in NodeInfo
      ///	 *  </summary>
      ///	 * <param name="element"> node name to look in </param>
      ///	 * <param name="attrib"> the attribute name </param>
      ///	 * <param name="nameSpaceURI"> the XML-namespace </param>
      ///	 * <param name="def"> the default if it does not exist
      ///	 * @since 200503 </param>
      ///	 * <returns> value of attribute found, empty string if not available </returns>
      ///	 
      public virtual string getAncestorElementAttribute(string element, string attrib, string nameSpaceURI, string def)
      {
         VElement v = getPoolChildren(null);
         // the last in list is the direct parent, the first is the original root

         for (int i = v.Count - 1; i >= 0; i--)
         {
            JDFAncestor ancestor = (JDFAncestor)v[i];
            KElement e = ancestor.getElement(element, nameSpaceURI, 0);
            if ((e != null) && (e.hasAttribute(attrib, nameSpaceURI, false)))
            {
               return e.getAttribute(attrib, nameSpaceURI, JDFConstants.EMPTYSTRING);
            }
         }
         return def;
      }

      ///   
      ///	 <summary> * check whether the Ancestor pool contains any part elements
      ///	 *  </summary>
      ///	 * <returns> true if the pool comtains part elements </returns>
      ///	 
      public virtual bool isPartitioned()
      {
         VJDFAttributeMap partMapVector = getPartMapVector();
         return partMapVector != null && partMapVector.Count > 0;
      }
   }
}
