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
 * ==========================================================================
 * class JDFResourceInfo extends JDFResource
 * ==========================================================================
 * @COPYRIGHT Heidelberger Druckmaschinen AG, 1999-2001
 * ALL RIGHTS RESERVED
 * @Author sabjon@topmail.de   using a code generator
 * Warning! very preliminary test version. Interface subject to change without prior notice!
 * Revision history:    ... 
 */


namespace org.cip4.jdflib.jmf
{
   using System.Collections;



   using JDFAutoResourceInfo = org.cip4.jdflib.auto.JDFAutoResourceInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using IAmountPoolContainer = org.cip4.jdflib.ifaces.IAmountPoolContainer;
   using EnumProcessUsage = org.cip4.jdflib.node.JDFNode.EnumProcessUsage;
   using JDFAmountPool = org.cip4.jdflib.pool.JDFAmountPool;
   using AmountPoolHelper = org.cip4.jdflib.pool.JDFAmountPool.AmountPoolHelper;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using EnumResStatus = org.cip4.jdflib.resource.JDFResource.EnumResStatus;
   using StringUtil = org.cip4.jdflib.util.StringUtil;

   ///
   /// <summary> * @author Rainer Prosi, Heidelberger Druckmaschinen
   /// * ResourceInfo element class </summary>
   /// 
   public class JDFResourceInfo : JDFAutoResourceInfo, IAmountPoolContainer
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFResourceInfo
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFResourceInfo(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFResourceInfo
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFResourceInfo(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFResourceInfo
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFResourceInfo(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      ///   
      ///	 <summary> * toString()
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public override string ToString()
      {
         return "JDFResourceInfo[  --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * get the resource defined by <code>resName</code>
      ///	 *  </summary>
      ///	 * <param name="resName"> name of the resource to get/create </param>
      ///	 * <returns> JDFCostCenter The element </returns>
      ///	 
      public virtual JDFResource getCreateResource(string resName)
      {
         KElement e = getCreateElement(resName, JDFConstants.EMPTYSTRING, 0);
         if (e is JDFResource)
         {
            return (JDFResource)e;
         }
         throw new JDFException("JDFResouceInfo.getCreateResource tried to create a JDFElement instead of a JDFResource");
      }

      ///   
      ///	 <summary> * get resource defined by <code>resName</code>
      ///	 *  </summary>
      ///	 * <param name="resName"> name of the resource to get </param>
      ///	 * <returns> JDFResource: the element </returns>
      ///	 
      public virtual JDFResource getResource(string resName)
      {
         for (int i = 0; true; i++)
         {
            KElement e = getElement(resName, null, i);
            if (e == null)
               return null;
            if (e is JDFResource)
            {
               return (JDFResource)e;
            }
         }
      }

      ///   
      ///	 <summary> * append resource
      ///	 *  </summary>
      ///	 * <param name="resName"> name of the resource to append </param>
      ///	 
      public virtual JDFResource appendResource(string resName)
      {
         KElement e = appendElement(resName, null);
         if (e is JDFResource)
         {
            return (JDFResource)e;
         }
         throw new JDFException("JDFResouceInfo.appendResource tried to append a JDFElement instead of a JDFResource");
      }

      ///   
      ///	 <summary> * return a vector of unknown element nodenames
      ///	 * <p>
      ///	 * default: getUnknownElements(true, 999999)
      ///	 *  </summary>
      ///	 * <param name="bIgnorePrivate"> used by JDFElement during the validation </param>
      ///	 * <param name="nMax"> maximum number of elements to get
      ///	 *  </param>
      ///	 * <returns> Vector - vector of unknown element nodenames </returns>
      ///	 
      public override VString getUnknownElements(bool bIgnorePrivate, int nMax)
      {
         return getUnknownPoolElements(JDFElement.EnumPoolType.ResourcePool, nMax);
      }

      ///   
      ///	 <summary> * Method getInvalidElements
      ///	 * <p>
      ///	 * default: GetInvalidElements(level, true, 999999)
      ///	 *  </summary>
      ///	 * <param name="level"> validation level </param>
      ///	 * <param name="bIgnorePrivate"> </param>
      ///	 * <param name="nMax"> maximum number of elements to get
      ///	 *  </param>
      ///	 * <returns> VString - vector of names of invalid elements </returns>
      ///	 
      public override VString getInvalidElements(EnumValidationLevel level, bool bIgnorePrivate, int nMax)
      {
         VString s = getInvalidElements_JDFElement(level, bIgnorePrivate, nMax);
         if (s.Count > nMax || hasAttribute(AttributeName.RESOURCENAME)) // multiple
            // are
            // allowed
            // with
            // resourcename
            // set
            return s;

         VElement v = getChildElementVector(null, null, null, true, 0, false);
         int size = v.Count;
         if (size > 1)
         {
            // remove anything but resources
            for (int i = size - 1; i >= 0; i--)
            {
               if (!(v[i] is JDFResource))
               {
                  v.RemoveAt(i);
               }
            }
            size = v.Count; // must refresh size due to removes
            // more than one resource --> evil!
            if (size > 1)
            {
               for (int j = 0; j < size; j++)
               {
                  s.appendUnique(v.item(j).LocalName);
               }
            }
         }
         return s;
      }

      ///   
      ///	 <summary> * get part map vector
      ///	 *  </summary>
      ///	 * <returns> VJDFAttributeMap: vector of attribute maps, one for each part </returns>
      ///	 
      public override VJDFAttributeMap getPartMapVector()
      {
         return base.getPartMapVector();
      }

      ///   
      ///	 <summary> * set all parts to those defined by vParts
      ///	 *  </summary>
      ///	 * <param name="vParts"> vector of attribute maps for the parts </param>
      ///	 
      public override void setPartMapVector(VJDFAttributeMap vParts)
      {
         base.setPartMapVector(vParts);
      }

      ///   
      ///	 <summary> * set all parts to those defined by mPart
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
      ///	 * <param name="mPart"> attribute map to look for </param>
      ///	 * <returns> boolean - returns true if the part exists </returns>
      ///	 
      public override bool hasPartMap(JDFAttributeMap mPart)
      {
         return base.hasPartMap(mPart);
      }

      ///   
      ///	 <summary> * sets all relevant parameters of this to the values specified in resourceLink or its linked resource or JDF node
      ///	 *  </summary>
      ///	 * <param name="resourceLink"> the resourceLink to extract the information from </param>
      ///	 * <param name="rqp"> parameters </param>
      ///	 
      public virtual void setLink(JDFResourceLink resourceLink, JDFResourceQuParams rqp)
      {
         if (resourceLink == null)
            return;
         JDFAmountPool ap = resourceLink.getAmountPool();
         if (ap != null)
         {
            copyElement(ap, null);
         }
         else
         {
            if (resourceLink.hasAttribute(AttributeName.ACTUALAMOUNT))
               setActualAmount(resourceLink.getActualAmount(null));
            if (resourceLink.hasAttribute(AttributeName.AMOUNT))
               setAmount(resourceLink.getAmount(null));
         }
         setProcessUsage(resourceLink.getEnumProcessUsage());

         JDFResource r = resourceLink.getTarget();
         if (r == null && rqp != null)
         {
            rqp.setExact(false);
         }

         bool bExact = rqp == null ? false : rqp.getExact();
         if (!bExact || r == null) // if we do not have a resource let's limp
         // along and provide as much as we have
         {
            setResourceName(resourceLink.getLinkedResourceName());
            setAttribute(AttributeName.RESOURCEID, resourceLink.getrRef());
            EnumUsage usage = resourceLink.getUsage();
            if (usage != null)
               setAttribute(AttributeName.USAGE, usage.getName());
            if (r != null && r.hasAttribute(AttributeName.PRODUCTID))
               setProductID(r.getProductID());
         }
         else
         {
            // create a copy of the resource in the original jdf
            JDFResource rr = (JDFResource)r.getParentNode_KElement().copyElement(r, null);
            rr.inlineRefElements(null, null, true);
            // move resource copy from the original node into this document
            moveElement(rr, null);
         }
      }

      ///   
      ///	 <summary> * set ProcessUsage to the enum processusage
      ///	 *  </summary>
      ///	 * <param name="processUsage"> </param>
      ///	 
      public virtual void setProcessUsage(EnumProcessUsage processUsage)
      {
         setAttribute(AttributeName.PROCESSUSAGE, processUsage == null ? null : processUsage.getName(), null);
      }

      ///   
      ///	 <summary> * if a Resource is available, return it's ProductID
      ///	 *  </summary>
      ///	 * <seealso cref= org.cip4.jdflib.auto.JDFAutoResourceInfo#getProductID() </seealso>
      ///	 
      public override string getProductID()
      {
         string _name = base.getResourceName();
         if (isWildCard(_name))
         {
            JDFResource r = getResource(null);
            if (r == null)
               return null;
            _name = r.getProductID();
         }
         return _name;
      }

      ///   
      ///	 <summary> * if a Resource is available, return it's ID
      ///	 *  </summary>
      ///	 * <seealso cref= org.cip4.jdflib.auto.JDFAutoResourceInfo#getResourceID() </seealso>
      ///	 
      public override string getResourceID()
      {
         string _name = base.getResourceID();
         if (isWildCard(_name))
         {
            JDFResource r = getResource(null);
            if (r == null)
               return null;
            _name = r.getID();
         }
         return _name;
      }

      ///   
      ///	 <summary> * if a Resource is available, return it's name
      ///	 *  </summary>
      ///	 * <seealso cref= org.cip4.jdflib.auto.JDFAutoResourceInfo#getResourceName() </seealso>
      ///	 
      public override string getResourceName()
      {

         string _name = base.getResourceName();
         if (isWildCard(_name))
         {
            JDFResource r = getResource(null);
            if (r == null)
               return null;
            _name = r.LocalName;
         }
         return _name;
      }

      ///   
      ///	 <summary> * 
      ///	 * if a Resource is available, return it's status
      ///	 *  </summary>
      ///	 * <seealso cref= org.cip4.jdflib.auto.JDFAutoResourceInfo#getResStatus() </seealso>
      ///	 
      public override EnumResStatus getResStatus()
      {
         EnumResStatus s = base.getResStatus();
         if (s == null)
         {
            JDFResource r = getResource(null);
            if (r == null)
               return null;
            s = r.getResStatus(false);
         }
         return s;
      }

      ///   
      ///	 <summary> * getLinkRoot - gets the root resource of the target based on ResourceName, if available
      ///	 *  </summary>
      ///	 * <returns> JDFResource </returns>
      ///	 
      public virtual JDFResource getLinkRoot()
      {
         return getResource(getResourceName());
      }

      ///   
      ///	 <summary> * Set attribute ActualAmount in the AmountPool or in the link, depending on the value of mPart
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set ActualAmount to </param>
      ///	 * <param name="mPart"> the part map of AmountPool/PartAmount </param>
      ///	 
      public virtual void setActualAmount(double @value, JDFAttributeMap mPart)
      {
         setAmountPoolAttribute("ActualAmount", StringUtil.formatDouble(@value), null, mPart);
      }

      ///   
      ///	 <summary> * setAmount in PartAmount or in this if partAmount=null
      ///	 *  </summary>
      ///	 * <param name="value"> amount to set </param>
      ///	 * <param name="mPart"> partition map to set amount for
      ///	 * 
      ///	 * @default setAmount(double value, null) </param>
      ///	 
      public virtual void setAmount(double @value, JDFAttributeMap mPart)
      {
         setAmountPoolAttribute(AttributeName.AMOUNT, StringUtil.formatDouble(@value), null, mPart);
      }

      ///   
      ///	 <summary> * sets the attribute occurence in the appropriate PartAmount when called for a resourceLink and creates the
      ///	 * AmountPool and/or PartAmount if it is not yet there
      ///	 *  </summary>
      ///	 * <param name="attrib"> the attribute name </param>
      ///	 * <param name="value"> value to set in string form. </param>
      ///	 * <param name="nameSpaceURI"> the XML-namespace </param>
      ///	 * <param name="mPart"> defines which part of this ResourceLink the Amount belongs to, if empty set the ResourceLink root
      ///	 *            attribute </param>
      ///	 * <exception cref="JDFException"> when called directly on a PartAmount
      ///	 * @since 071103 </exception>
      ///	 
      public virtual void setAmountPoolAttribute(string attrib, string @value, string nameSpaceURI, JDFAttributeMap mPart)
      {
         AmountPoolHelper.setAmountPoolAttribute(this, attrib, @value, nameSpaceURI, mPart);
      }

      ///   
      ///	 <summary> * sets the attribute occurence in the appropriate PartAmount when called for a resourceLink and creates the
      ///	 * AmountPool and/or PartAmount(s) if they are not yet there
      ///	 *  </summary>
      ///	 * <param name="attrib"> the attribute name </param>
      ///	 * <param name="value"> value to set in string form. </param>
      ///	 * <param name="nameSpaceURI"> the XML-namespace </param>
      ///	 * <param name="vPart"> defines which part of this ResourceLink the Amount belongs to, if empty set the ResourceLink root
      ///	 *            attribute. </param>
      ///	 * <exception cref="JDFException"> when called directly on a PartAmount
      ///	 * @since 060630 </exception>
      ///	 
      public virtual void setAmountPoolAttribute(string attrib, string @value, string nameSpaceURI, VJDFAttributeMap vPart)
      {
         AmountPoolHelper.setAmountPoolAttribute(this, attrib, @value, nameSpaceURI, vPart);
      }

      ///   
      ///	 <summary> * returns the attribute occurence in PartAmount, or the default in the ResourceLink
      ///	 *  </summary>
      ///	 * <param name="attrib"> the attribute name </param>
      ///	 * <param name="nameSpaceURI"> the XML-namespace </param>
      ///	 * <param name="mPart"> defines which part of this ResourceLink the Amount belongs to. If empty get the ResourceLink root
      ///	 *            attribute. </param>
      ///	 * <returns> value of attribute found, null if not available
      ///	 * @since 071103 </returns>
      ///	 
      public virtual string getAmountPoolAttribute(string attrib, string nameSpaceURI, JDFAttributeMap mPart, int iSkip)
      {
         return AmountPoolHelper.getAmountPoolAttribute(this, attrib, nameSpaceURI, mPart, iSkip);
      }

      ///   
      ///	 <summary> * returns the attribute occurence in PartAmount, or the default in the ResourceLink
      ///	 *  </summary>
      ///	 * <param name="attrib"> the attribute name </param>
      ///	 * <param name="nameSpaceURI"> the XML-namespace </param>
      ///	 * <param name="vPart"> defines which part of this ResourceLink the Amount belongs to. If null get the ResourceLink root
      ///	 *            attribute. </param>
      ///	 * <returns> value of attribute found, null if not available
      ///	 * @since 071103 </returns>
      ///	 
      public virtual string getAmountPoolAttribute(string attrib, string nameSpaceURI, VJDFAttributeMap vPart)
      {
         return AmountPoolHelper.getAmountPoolAttribute(this, attrib, nameSpaceURI, vPart);
      }

      ///   
      ///	 <summary> * get the sum of all matching AmountPool/PartAmount/@attName as a double PartAmounts match if all attributes match
      ///	 * those in PartAmount, i.e. mPart is a submap of the searche PartAmount elements
      ///	 * 
      ///	 *  </summary>
      ///	 * <param name="attName"> the Attribute name , e.g Amount, ActualAmount </param>
      ///	 * <param name="mPart"> </param>
      ///	 * <returns> double - the element </returns>
      ///	 * <exception cref="JDFException"> if the element can not be cast to double </exception>
      ///	 
      public virtual double getAmountPoolDouble(string attName, JDFAttributeMap mPart)
      {
         return AmountPoolHelper.getAmountPoolDouble(this, attName, mPart);
      }

      ///   
      ///	 <summary> * get the exactly matching AmountPool/PartAmount/@AttName as a double
      ///	 *  </summary>
      ///	 * <param name="attName"> </param>
      ///	 * <param name="vPart"> </param>
      ///	 * <returns> double - </returns>
      ///	 * <exception cref="JDFException"> if the element can not be cast to double </exception>
      ///	 
      public virtual double getAmountPoolDouble(string attName, VJDFAttributeMap vPart)
      {
         return AmountPoolHelper.getAmountPoolDouble(this, attName, vPart);
      }


      public virtual double getAmountPoolSumDouble(string attName, VJDFAttributeMap vPart)
      {
         return AmountPoolHelper.getAmountPoolSumDouble(this, attName, vPart);
      }
   }
}
