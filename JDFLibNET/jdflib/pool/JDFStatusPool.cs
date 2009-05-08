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
 * Copyright (c) 2001-2003 Heidelberger Druckmaschinen AG, All Rights Reserved.
 * String myLocalName)
 * Last changes
 */

namespace org.cip4.jdflib.pool
{
   using System.Collections;



   using JDFAutoStatusPool = org.cip4.jdflib.auto.JDFAutoStatusPool;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFPartStatus = org.cip4.jdflib.core.JDFPartStatus;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using JDFNode = org.cip4.jdflib.node.JDFNode;

   ///
   /// <summary> * This class represents a JDF-Status Pool. THe status pool describes the status of a JDF node that processes
   /// * partitioned resources. StatusPool elements are only valid if the nodes Status="Pool", otherwise the nodes status is
   /// * valid for all parts, regardless of the contents of StatusPool. </summary>
   /// 
   public class JDFStatusPool : JDFAutoStatusPool
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFStatusPool
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFStatusPool(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFStatusPool
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFStatusPool(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFStatusPool
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFStatusPool(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
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
         return "JDFStatusPool[ -->" + base.ToString() + "]";
      }

      ///   
      ///	 <summary> * getElementStatus - get the status of a part defined in StatusPool
      ///	 *  </summary>
      ///	 * <param name="mPart"> filter for the part to get the status
      ///	 *  </param>
      ///	 * <returns> EnumNodeStatus - the status for the filter defined in mPart </returns>
      ///	 
      public virtual JDFElement.EnumNodeStatus getStatus(JDFAttributeMap mPart)
      {
         JDFNode n = getParentJDF();

         if (!(n.getStatus().Equals(JDFElement.EnumNodeStatus.Pool)))
         {
            return n.getStatus();
         }

         JDFPartStatus ps = getPartStatus(mPart);

         // default to status of this
         if (ps == null)
         {
            return getStatus();
         }

         return ps.getStatus();
      }

      ///   
      ///	 <summary> * getPartStatus - get a PartStatus that fits to the filter defined by mPart
      ///	 *  </summary>
      ///	 * <param name="mPart"> the filter for the part to set the status
      ///	 *  </param>
      ///	 * <returns> JDFPartStatus - the PartStatus that fits </returns>
      ///	 
      public virtual JDFPartStatus getPartStatus(JDFAttributeMap mPart)
      {
         VElement vPartStatus = getChildElementVector(ElementName.PARTSTATUS, null, null, true, 0, false);
         int nSep = 0;
         JDFPartStatus retPartStatus = null;

         for (int i = vPartStatus.Count - 1; i >= 0; i--)
         {
            JDFPartStatus ps = (JDFPartStatus)vPartStatus[i];
            JDFAttributeMap mapPart = ps.getPartMap();

            if (mPart != null && mPart.subMap(mapPart))
            {
               if (mapPart.Count > nSep)
               {
                  nSep = mapPart.Count;
                  retPartStatus = ps; // mPart is a subset of of mapPart
               }
            }
         }

         return retPartStatus;
      }

      ///   
      ///	 <summary> * getCreatePartStatus - get a PartStatus that fits to the filter defined by mPart<br>
      ///	 * create it if it does not exist
      ///	 *  </summary>
      ///	 * <param name="mPart"> the filter for the part to set the status
      ///	 * 
      ///	 *  </param>
      ///	 * <returns> JDFPartStatus - the PartStatus that fits </returns>
      ///	 
      public virtual JDFPartStatus getCreatePartStatus(JDFAttributeMap mPart)
      {
         JDFPartStatus p = getPartStatus(mPart);

         if (p == null)
         {
            p = appendPartStatus();
            p.setPartMap(mPart);
         }

         return p;
      }

      ///   
      ///	 <summary> * getPartStatusVector - get a vector of PartStatus that fits to the filter defined by mPart
      ///	 *  </summary>
      ///	 * <param name="mPart"> the filter vector for the part to set the status.If null, return all.
      ///	 *  </param>
      ///	 * <returns> VElement - the vector of PartStatus that fit </returns>
      ///	 
      public virtual VElement getPartStatusVector(ArrayList vmPart)
      {
         if (vmPart == null)
            return getChildElementVector(ElementName.PARTSTATUS, null, null, true, -1, false);

         VElement vPartStatus = new VElement();

         for (int i = 0; i < vmPart.Count; i++)
         {
            JDFPartStatus ps = getPartStatus((JDFAttributeMap)vmPart[i]);

            if (ps != null)
            {
               vPartStatus.Add(ps);
            }
         }
         return vPartStatus;
      }

      ///   
      ///	 <summary> * get matching part status vector
      ///	 *  </summary>
      ///	 * <param name="JDFAttributeMap"> mPart </param>
      ///	 * <returns> VElement - vector of JDFPartStatus </returns>
      ///	 
      public virtual VElement getMatchingPartStatusVector(JDFAttributeMap mPart)
      {
         VElement vPartStatus = getChildElementVector(ElementName.PARTSTATUS, null, null, true, 0, false);
         VElement vPS = new VElement();

         for (int i = 0; i < vPartStatus.Count; i++)
         {
            JDFPartStatus ps = (JDFPartStatus)vPartStatus[i];
            JDFAttributeMap mapPart = ps.getPartMap();

            if (mapPart.subMap(mPart))
            {
               vPS.Add(ps); // mPart is a subset of of mapPart
            }
         }
         return vPS;
      }

      ///   
      ///	 <summary> * getCreatePartStatusVector - get a vector of PartStatus that fits to the filter defined by mPart
      ///	 *  </summary>
      ///	 * <param name="mPart"> the filter vector for the part to set the status
      ///	 *  </param>
      ///	 * <returns> VElement - vector of JDFPartStatus </returns>
      ///	 
      public virtual VElement getCreatePartStatusVector(ArrayList vmPart)
      {
         VElement vPartStatus = new VElement();

         for (int i = 0; i < vmPart.Count; i++)
         {
            JDFPartStatus ps = getCreatePartStatus((JDFAttributeMap)vmPart[i]);

            if (ps != null)
            {
               vPartStatus.Add(ps);
            }
         }

         return vPartStatus;
      }

      ///   
      ///	 <summary> * get pool children with attributes definded by <code>mAttrib</code>
      ///	 *  </summary>
      ///	 * <param name="mAttrib"> attribute map </param>
      ///	 * <returns> VElement </returns>
      ///	 
      public virtual VElement getPoolChildren(JDFAttributeMap mAttrib)
      {
         return getPoolChildrenGeneric(ElementName.PARTSTATUS, mAttrib, JDFConstants.EMPTYSTRING);
      }


      ///   
      ///	 <summary> * get pool child
      ///	 *  </summary>
      ///	 * <param name="i"> the index of the child, or <code>-1</code> to create a new one </param>
      ///	 * <param name="mAttrib"> the attribute of the child </param>
      ///	 * <returns> JDFPartStatus: the pool child matching the given conditions </returns>
      ///	 
      public virtual JDFPartStatus getPoolChild(int i, JDFAttributeMap mAttrib)
      {
         return (JDFPartStatus)getPoolChildGeneric(i, ElementName.PARTSTATUS, mAttrib, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * Set the status of the entire StatusPool
      ///	 *  </summary>
      ///	 * <param name="s"> the status to set </param>
      ///	 
      public override void setStatus(JDFElement.EnumNodeStatus s)
      {
         JDFNode n = (JDFNode)getParentNode_KElement();
         n.setStatus(JDFElement.EnumNodeStatus.Pool);
         base.setStatus(s);
      }

      ///   
      ///	 <summary> * Set the status of a part defined in StatusPool
      ///	 * <p>
      ///	 * default setStatus(vmPart, s, JDFConstants.EMPTYSTRING)
      ///	 *  </summary>
      ///	 * <param name="vmPart"> </param>
      ///	 * <param name="s"> </param>
      ///	 * <param name="statusDetails"> </param>
      ///	 
      public virtual void setStatus(VJDFAttributeMap vmPart, JDFElement.EnumNodeStatus s, string statusDetails)
      {
         for (int i = 0; i < vmPart.Count; i++)
         {
            setStatus(vmPart[i], s, statusDetails);
         }
      }


      ///   
      ///	 <summary> * Set the status of a part defined in StatusPool
      ///	 * <p>
      ///	 * default setStatus(mPart, s, JDFConstants.EMPTYSTRING)
      ///	 *  </summary>
      ///	 * <param name="mPart"> </param>
      ///	 * <param name="s"> </param>
      ///	 * <param name="statusDetails"> </param>
      ///	 
      public virtual void setStatus(JDFAttributeMap mPart, JDFElement.EnumNodeStatus s, string statusDetails)
      {
         if ((mPart != null) && !mPart.IsEmpty())
         {
            JDFPartStatus ps = getCreatePartStatus(mPart);
            ps.setStatus(s);
            if (statusDetails != null && !statusDetails.Equals(JDFConstants.EMPTYSTRING))
            {
               ps.setStatusDetails(statusDetails);
            }
         }
         else
         {
            setStatus(s);
            if (statusDetails != null && !statusDetails.Equals(JDFConstants.EMPTYSTRING))
            {
               setStatusDetails(statusDetails);
            }
         }
      }

      ///   
      ///	 <summary> * check whether the status is valid
      ///	 *  </summary>
      ///	 * <returns> true if status is valid </returns>
      ///	 
      public virtual bool validStatus()
      {
         if (!base.validAttribute(AttributeName.STATUS, null, KElement.EnumValidationLevel.Complete))
         {
            return false;
         }
         if (getStatus().Equals(JDFElement.EnumNodeStatus.Pool))
         {
            return false;
         }
         return true;
      }
   }
}
