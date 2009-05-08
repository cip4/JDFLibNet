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
 * JDFQueueFilter.cs
 *
 * Last changes
 *
 * 2002-07-02 JG - init() Also call super::init()
 */

namespace org.cip4.jdflib.jmf
{
   using System.Collections;
   using System.Collections.Generic;


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   using JDFAutoQueueFilter = org.cip4.jdflib.auto.JDFAutoQueueFilter;
   using EnumQueueEntryStatus = org.cip4.jdflib.auto.JDFAutoQueueEntry.EnumQueueEntryStatus;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using VElement = org.cip4.jdflib.core.VElement;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using JDFDevice = org.cip4.jdflib.resource.JDFDevice;
   using EnumUtil = org.cip4.jdflib.util.EnumUtil;

   ///
   /// <summary> * </summary>
   /// 
   public class JDFQueueFilter : JDFAutoQueueFilter
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFQueueFilter
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFQueueFilter(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFQueueFilter
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFQueueFilter(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFQueueFilter
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFQueueFilter(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
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
         return "JDFQueueFilter[  --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * GetPartMapVector returns a vector of partmaps, null if no parts are present
      ///	 *  </summary>
      ///	 * <returns> VJDFAttributeMap </returns>
      ///	 
      public override VJDFAttributeMap getPartMapVector()
      {
         return base.getPartMapVector();
      }

      ///   
      ///	 <summary> * SetPartMapVector
      ///	 *  </summary>
      ///	 * <param name="vPart"> </param>
      ///	 
      public override void setPartMapVector(VJDFAttributeMap vPart)
      {
         base.setPartMapVector(vPart);
      }

      ///   
      ///	 <summary> * return true if the queuentry matches this filter
      ///	 * 
      ///	 * @return </summary>
      ///	 
      public virtual bool matches(JDFQueueEntry qe)
      {
         if (qe == null)
            return false;

         if (EnumQueueEntryDetails.None.Equals(getQueueEntryDetails()))
            return false;

         SupportClass.SetSupport<string> qeDefs = getQueueEntryDefSet();
         if (qeDefs != null && !qeDefs.Contains(qe.getQueueEntryID()))
            return false;

         qeDefs = getDeviceIDSet();
         if (qeDefs != null && !qeDefs.Contains(qe.getDeviceID()))
            return false;

         if (hasAttribute(AttributeName.GANGNAMES) && !getGangNames().Contains(qe.getGangName()))
            return false;

         if (hasAttribute(AttributeName.STATUSLIST) && !getStatusList().Contains(qe.getQueueEntryStatus()))
            return false;

         return true;
      }

      ///   
      ///	 <summary> * (9.2) get StatusList attribute StatusList
      ///	 *  </summary>
      ///	 * <returns> Vector of the enumerations this version uses queueEntryStatus rather than an own enumeration </returns>
      ///	 
      public override List<ValuedEnum> getStatusList()
      {
         return getEnumerationsAttribute(AttributeName.STATUSLIST, null, EnumQueueEntryStatus.getEnum(0), false);
      }

      ///   
      ///	 <summary> * get the list of QueueEntryDef/@QueueEntryIDs strings as a set
      ///	 *  </summary>
      ///	 * <returns> the set of QueueEntryIDs, null if no QueueEntryDef is specified </returns>
      ///	 
      public virtual SupportClass.SetSupport<string> getQueueEntryDefSet()
      {
         SupportClass.HashSetSupport<string> @set = null;

         VElement v = getChildElementVector(ElementName.QUEUEENTRYDEF, null);
         if (v != null)
         {
            int siz = v.Count;
            @set = siz == 0 ? null : new SupportClass.HashSetSupport<string>();
            for (int i = 0; i < siz; i++)
            {
               string qeid = ((JDFQueueEntryDef)v[i]).getQueueEntryID();
               if (!isWildCard(qeid))
                  @set.Add(qeid);
            }
         }

         return @set != null && @set.Count > 0 ? @set : null;
      }

      ///   
      ///	 <summary> * get the list of Device/@DeviceIDs strings as a set
      ///	 *  </summary>
      ///	 * <returns> the set of DeviceIDs, null if no Device is specified </returns>
      ///	 
      public virtual SupportClass.SetSupport<string> getDeviceIDSet()
      {
         int size = 0;
         SupportClass.SetSupport<string> @set = null;

         VElement v = getChildElementVector(ElementName.DEVICE, null);
         if (v != null)
         {
            size = v.Count;
            @set = size == 0 ? null : new SupportClass.HashSetSupport<string>();
            for (int i = 0; i < size; i++)
            {
               string qeid = ((JDFDevice)v[i]).getDeviceID();
               if (!isWildCard(qeid))
                  @set.Add(qeid);
            }
         }

         return @set != null && @set.Count > 0 ? @set : null;
      }

      ///   
      ///	 <summary> * modifies queue to match this filter by removing all non-matching entries
      ///	 * 
      ///	 * make sure that this is a copy of any original queue as the incoming queue itself is not cloned
      ///	 *  </summary>
      ///	 * <param name="theQueue"> the queue to modify </param>
      ///	 
      public virtual void match(JDFQueue theQueue)
      {
         int maxEntries = hasAttribute(AttributeName.MAXENTRIES) ? getMaxEntries() : 999999;

         VElement v = theQueue.getQueueEntryVector();
         if (v != null)
         {
            int size = v.Count;
            theQueue.setQueueSize(size);

            for (int i = 0; i < size; i++)
            {
               JDFQueueEntry qe = (JDFQueueEntry)v[i];
               match(qe);
            }
         }

         for (int i = theQueue.numEntries(null) - 1; i >= maxEntries; i--)
            theQueue.removeChild(ElementName.QUEUEENTRY, null, maxEntries);
         // always zapp first - it is faster to find
      }

      ///   
      ///	 <summary> * modifies queueEntry to match this filter by removing all non-matching attributes and elements
      ///	 * 
      ///	 * make sure that this is a copy of any original queue as the incoming queue itself is not cloned
      ///	 *  </summary>
      ///	 * <param name="qe"> </param>
      ///	 
      public virtual void match(JDFQueueEntry qe)
      {
         if (qe == null)
            return;

         if (!matches(qe))
            qe.deleteNode();
         EnumQueueEntryDetails qed = getQueueEntryDetails();
         if (qed == null)
            qed = EnumQueueEntryDetails.Brief;
         if (EnumUtil.aLessEqualsThanB(EnumQueueEntryDetails.Brief, qed))
         {
            qe.removeChildren(ElementName.JOBPHASE, null, null);
         }
         if (EnumUtil.aLessEqualsThanB(EnumQueueEntryDetails.JobPhase, qed))
         {
            qe.removeChildren(ElementName.JDF, null, null);
         }

      }

      ///   
      ///	 <summary> * append a Device element with @DeviceID
      ///	 *  </summary>
      ///	 * <param name="deviceID"> the deviceID to set </param>
      ///	 * <seealso cref= org.cip4.jdflib.auto.JDFAutoQueueFilter#appendDevice() </seealso>
      ///	 
      public virtual JDFDevice appendDevice(string deviceID)
      {
         JDFDevice device = base.appendDevice();
         device.setDeviceID(deviceID);
         return device;
      }

      ///   
      ///	 * <param name="queueEntryID"> the queueEntryID to set </param>
      ///	 * <seealso cref= org.cip4.jdflib.auto.JDFAutoQueueFilter#appendQueueEntryDef() </seealso>
      ///	 
      public virtual JDFQueueEntryDef appendQueueEntryDef(string queueEntryID)
      {
         JDFQueueEntryDef queueEntryDef = base.appendQueueEntryDef();
         queueEntryDef.setQueueEntryID(queueEntryID);
         return queueEntryDef;
      }
   }
}
