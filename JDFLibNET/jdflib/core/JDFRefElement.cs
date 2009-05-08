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
 * COPYRIGHT Heidelberger Druckmaschinen AG, 1999-2002
 *      ALL RIGHTS RESERVED
 * @author: Thomas Kurberg
 * Last changes
 * created 2002-02-04
 * 02-07-2002  JG - modified GetTarget to handle parts
 * 02-07-2002  JG - added part handling
 * 02-07-2002  JG - added OptionalElements
 * 02-07-2002  JG - added InlineRef
 * 02-07-2002  JG - modified GetTarget for parts pointing to elements that are not 
 * 02-07-2002  JG - added DeleteRef 
 * 26-11-2002  Kai Mattern - Bugfix in InLineRef
 */

namespace org.cip4.jdflib.core
{
   using System;


   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using JDFPart = org.cip4.jdflib.resource.JDFPart;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;

   public class JDFRefElement : JDFElement
   {
      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[2];
      static JDFRefElement()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.RSUBREF, 0x44444433, AttributeInfo.EnumAttributeType.IDREF, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.RREF, 0x22222222, AttributeInfo.EnumAttributeType.IDREF, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.PART, 0x33333331);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }

      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[1];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }

      ///   
      ///	 <summary> * Constructor for JDFRefElement
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFRefElement(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFRefElement
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFRefElement(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFRefElement
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFRefElement(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      ///   
      ///	 <summary> * test Part element existence
      ///	 *  </summary>
      ///	 * @deprecated 060310 use inline hasChildElement(ElementName.PART, null); 
      ///	 
      [Obsolete("060310 use inline hasChildElement(ElementName.PART, null);")]
      public virtual bool hasPart()
      {
         return this.hasChildElement(ElementName.PART, null);
      }

      ///   
      ///	 <summary> * Set attribute rRef
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setrRef(string @value)
      {
         setAttribute(JDFConstants.RREF, @value, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * returns true if the name specified fits the node name of this
      ///	 *  </summary>
      ///	 * <param name="nodeName"> the name of the node to test. may be either local or qualified </param>
      ///	 * <param name="nameSpaceURI"> the namespace of the node to test. </param>
      ///	 * <returns> true if ok </returns>
      ///	 
      public override bool fitsName(string nodeName, string nameSpaceURI)
      {
         if (nodeName == null || nodeName.EndsWith(JDFConstants.REF))
         {
            if (base.fitsName_KElement(nodeName, nameSpaceURI))
            {
               return true;
            }
         }
         else
         {
            // if this is a valid ResourceRef, it also fits
            if (base.fitsName_KElement(nodeName + JDFConstants.REF, nameSpaceURI))
            {
               return true;
            }
         }

         return false;
      }

      ///   
      ///	 <summary> * Get string attribute rRef
      ///	 *  </summary>
      ///	 * <returns> String - the vaue of the attribute </returns>
      ///	 
      public virtual string getrRef()
      {
         return getAttribute(JDFConstants.RREF, JDFConstants.EMPTYSTRING, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * Set attribute rSubRef
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 *@deprecated in JDF 1.2 
      ///	 
      [Obsolete("in JDF 1.2")]
      public virtual void setrSubRef(string @value)
      {
         setAttribute(JDFConstants.RSUBREF, @value, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * Get string attribute rSubRef
      ///	 *  </summary>
      ///	 * <returns> String - the vaue of the attribute </returns>
      ///	 
      public virtual string getrSubRef()
      {
         return getAttribute(JDFConstants.RSUBREF, JDFConstants.EMPTYSTRING, JDFConstants.EMPTYSTRING);
      }

      public override bool isValid(EnumValidationLevel level)
      {
         bool b = base.isValid(level);
         if (!b)
         {
            return false;
         }

         JDFResource r = getTarget();

         if (r == null)
         {
            return false;
         }

         if (!Name.Equals(r.getRefString()))
         {
            return false;
         }

         if (!validResourcePosition())
         {
            return false;
         }

         // RunLists and physical resources may be referenced at the root or
         // intermediate nodes
         // if((r.getPartUsage() != JDFResource.EnumPartUsage.Explicit) &&
         // !r.isLeaf())
         // {
         // return false;
         // }

         return true;
      }


      public virtual bool validResourcePosition()
      {
         return validResourcePosition(getTarget());
      }

      ///   
      ///	 <summary> * get the referenced target resource The resource's PartUsage is evaluated to correctly retrieve implicit or
      ///	 * explicit partitions<br>
      ///	 * may return null
      ///	 *  </summary>
      ///	 * <returns> JDFResource - the reference target partition </returns>
      ///	 
      public virtual JDFResource getTargetRoot()
      {
         if (hasAttribute(AttributeName.RSUBREF))
         {
            string s = getrSubRef();
            KElement subRef = getTarget_KElement(s, AttributeName.ID);

            if (subRef != null)
            {
               return (JDFResource)subRef;
            }
            return null;
         }
         return getLinkRoot(null);
      }

      ///   
      ///	 <summary> * get the referenced target resource 
      ///	 * The resource's PartUsage is evaluated to correctly retrieve implicit or explicit partitions<br>
      ///	 * may return null
      ///	 * 
      ///	 * overrides the deprecated method JDFElement.getTarget()
      ///	 *  </summary>
      ///	 * <returns> JDFResource - the reference target partition </returns>
      ///	 
      public new JDFResource getTarget()
      {
         JDFResource targetRoot = getTargetRoot();
         if (targetRoot == null)
            return null;

         JDFAttributeMap partMap = getPartMap();
         if (partMap == null)
            return targetRoot;
         return targetRoot.getPartition(partMap, null);
      }

      ///   
      ///	 <summary> * Get element Part
      ///	 *  </summary>
      ///	 * <returns> JDFPart - the element </returns>
      ///	 
      public virtual JDFPart getPart()
      {
         return (JDFPart)getElement(ElementName.PART, JDFConstants.EMPTYSTRING, 0);
      }

      ///   
      ///	 <summary> * return the NodeName of the referenced resource
      ///	 *  </summary>
      ///	 * <returns> the nodename of the referenced resource </returns>
      ///	 
      public virtual string getRefNodeName()
      {
         KElement target = getTargetRoot();
         if (target != null)
         {
            return target.Name;
         }

         string nn = Name;
         if (nn.EndsWith(JDFConstants.REF))
         {
            nn = nn.Substring(0, nn.Length - JDFConstants.REF.Length);
            return nn;
         }

         return null;
      }

      ///   
      ///	 <summary> * return the Localname of the target
      ///	 * 
      ///	 * @return </summary>
      ///	 
      public virtual string getRefLocalName()
      {
         KElement target = getTargetRoot();
         if (target != null)
         {
            return target.LocalName;
         }

         string nn = LocalName;
         if (nn.EndsWith(JDFConstants.REF))
         {
            nn = nn.Substring(0, nn.Length - JDFConstants.REF.Length);
            return nn;
         }

         return null;
      }

      ///   
      ///	 <summary> * inline this refElement by replacing it with a copy of its target
      ///	 *  </summary>
      ///	 * <returns> JDFElement - the newly created element </returns>
      ///	 
      public virtual JDFElement inlineRef()
      {
         int i;
         JDFResource targetRes = getTarget();
         if (targetRes == null)
         {
            throw new JDFException("inlineRef: inlining null refElement rRef=" + getrRef());
         }
         JDFResource newInline = (JDFResource)appendElement(targetRes.Name, null);

         // copy elements and attributes
         newInline.setAttributes(targetRes);
         VElement v = targetRes.getChildElementVector(null, null, null, true, 0, false);

         for (i = 0; i < v.Count; i++)
         {
            newInline.copyElement(v.item(i), null);
         }

         newInline.cleanResourceAttributes();
         VString partNames = targetRes.getPartIDKeys();

         for (i = 0; i < partNames.Count; i++)
         {
            newInline.removeAttribute(partNames[i], null);
         }

         // replace this (the refElement) with newInline.
         // This effectively repositions newInline from the back to the original
         // position of this
         replaceElement(newInline);

         targetRes.deleteUnLinked();
         return newInline;
      }

      ///   
      ///	 <summary> * delete this refElement and it's target
      ///	 *  </summary>
      ///	 * <param name="bCheckRefCount"> if true, check that no other element refers to the target before deleting<br>
      ///	 *            if bCheckRefCount=false, the target is force deleted </param>
      ///	 * <returns> JDFElement the deleted targeelement
      ///	 * @since 290502 </returns>
      ///	 
      public virtual JDFElement deleteRef(bool bCheckRefCount)
      {
         JDFResource e = getTarget();
         if (e != null)
         {
            if (bCheckRefCount)
            {
               e.deleteUnLinked();
            }
            else
            {
               e.deleteNode();
            }
         }
         // now zapp myself
         return (JDFElement)deleteNode();
      }

      ///   
      ///	 <summary> * Method AppendPart.
      ///	 *  </summary>
      ///	 * <returns> JDFPart </returns>
      ///	 
      public virtual JDFPart appendPart()
      {
         return (JDFPart)appendElementN(ElementName.PART, 1, null);
      }

      ///   
      ///	 <summary> * get element JDFPart, create one if it doesn't exist
      ///	 *  </summary>
      ///	 * <returns> JDFPart </returns>
      ///	 
      public virtual JDFPart getCreatePart()
      {
         return (JDFPart)getCreateElement_KElement(ElementName.PART, null, 0);
      }

      ///   
      ///	 <summary> * @deprecated </summary>
      ///	 
      [Obsolete]
      public virtual void removePart()
      {
         removeChild(ElementName.PART, null, 0);
      }

      ///   
      ///	 <summary> * get part map vector
      ///	 *  </summary>
      ///	 * @deprecated 060310 not more than one is allowed - use getPartMap 
      ///	 * <returns> VJDFAttributeMap: vector of attribute maps, one for each part </returns>
      ///	 
      [Obsolete("060310 not more than one is allowed - use getPartMap")]
      public override VJDFAttributeMap getPartMapVector()
      {
         return getPartMapVector();
      }

      ///   
      ///	 <summary> * get part map
      ///	 *  </summary>
      ///	 * <returns> JDFAttributeMap: the attribute maps, one for each part </returns>
      ///	 
      public override JDFAttributeMap getPartMap()
      {
         return base.getPartMap();
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
      ///	 <summary> * @deprecate 060310 - remove the part defined in mPart </summary>
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
      ///	 * <returns> boolean - returns true if the part exists </returns>
      ///	 
      public override bool hasPartMap(JDFAttributeMap mPart)
      {
         return base.hasPartMap(mPart);
      }
   }
}
