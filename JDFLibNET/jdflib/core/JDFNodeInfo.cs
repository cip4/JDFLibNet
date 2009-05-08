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
 * Copyright (c) 2001-2005 Heidelberger Druckmaschinen AG, All Rights Reserved.
 *
 * JDFNodeInfo.cs
 *
 * Last changes
 *
 * 02-07-2002  JG - added GetHRefs()
 */

namespace org.cip4.jdflib.core
{
   using System;
   using System.Collections;
   using System.Xml;


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   using JDFAutoNodeInfo = org.cip4.jdflib.auto.JDFAutoNodeInfo;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using JDFJMF = org.cip4.jdflib.jmf.JDFJMF;
   using JDFQuery = org.cip4.jdflib.jmf.JDFQuery;
   using EnumFamily = org.cip4.jdflib.jmf.JDFMessage.EnumFamily;
   using EnumType = org.cip4.jdflib.jmf.JDFMessage.EnumType;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;

   ///
   /// <summary> * </summary>
   /// 
   public class JDFNodeInfo : JDFAutoNodeInfo
   {
      private new const long serialVersionUID = 1L;
      private static bool bDefaultWorkStepID = false;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[20];
      static JDFNodeInfo()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.CLEANUPDURATION, 0x33333333, AttributeInfo.EnumAttributeType.duration, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.DUELEVEL, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumDueLevel.getEnum(0), null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.END, 0x33333333, AttributeInfo.EnumAttributeType.dateTime, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.FIRSTEND, 0x33333333, AttributeInfo.EnumAttributeType.dateTime, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.FIRSTSTART, 0x33333333, AttributeInfo.EnumAttributeType.dateTime, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.IPPVERSION, 0x33333331, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.JOBPRIORITY, 0x33333331, AttributeInfo.EnumAttributeType.integer, null, "50");
         atrInfoTable[7] = new AtrInfoTable(AttributeName.LASTEND, 0x33333333, AttributeInfo.EnumAttributeType.dateTime, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.LASTSTART, 0x33333333, AttributeInfo.EnumAttributeType.dateTime, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.NATURALLANG, 0x33333331, AttributeInfo.EnumAttributeType.language, null, null);
         atrInfoTable[10] = new AtrInfoTable(AttributeName.MERGETARGET, 0x44444443, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[11] = new AtrInfoTable(AttributeName.ROUTE, 0x33333333, AttributeInfo.EnumAttributeType.URL, null, null);
         atrInfoTable[12] = new AtrInfoTable(AttributeName.RREFS, 0x44444433, AttributeInfo.EnumAttributeType.IDREFS, null, null);
         atrInfoTable[13] = new AtrInfoTable(AttributeName.SETUPDURATION, 0x33333333, AttributeInfo.EnumAttributeType.duration, null, null);
         atrInfoTable[14] = new AtrInfoTable(AttributeName.START, 0x33333333, AttributeInfo.EnumAttributeType.dateTime, null, null);
         atrInfoTable[15] = new AtrInfoTable(AttributeName.TARGETROUTE, 0x33333333, AttributeInfo.EnumAttributeType.URL, null, null);
         atrInfoTable[16] = new AtrInfoTable(AttributeName.TOTALDURATION, 0x33333333, AttributeInfo.EnumAttributeType.duration, null, null);
         atrInfoTable[17] = new AtrInfoTable(AttributeName.NODESTATUS, 0x33333111, AttributeInfo.EnumAttributeType.enumeration, EnumNodeStatus.getEnum(0), null);
         atrInfoTable[18] = new AtrInfoTable(AttributeName.NODESTATUSDETAILS, 0x33333111, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[19] = new AtrInfoTable(AttributeName.WORKSTEPID, 0x33333111, AttributeInfo.EnumAttributeType.string_, null, null); // added
         // as
         // valid
         // for
         // 1.3
         elemInfoTable[0] = new ElemInfoTable(ElementName.BUSINESSINFO, 0x33333333);
         elemInfoTable[1] = new ElemInfoTable(ElementName.EMPLOYEE, 0x33333333);
         elemInfoTable[2] = new ElemInfoTable(ElementName.JMF, 0x33333333);
         elemInfoTable[3] = new ElemInfoTable(ElementName.MISDETAILS, 0x33333311);
         elemInfoTable[4] = new ElemInfoTable(ElementName.NOTIFICATIONFILTER, 0x33333311);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         AttributeInfo ai;

         if (ParentNode.LocalName.Equals(ElementName.JDF))
         {
            ai = base.getTheAttributeInfo_JDFElement().updateReplace(atrInfoTable);
         }
         else
         {
            ai = base.getTheAttributeInfo().updateReplace(atrInfoTable);
         }

         return ai;
      }

      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[5];

      protected internal override ElementInfo getTheElementInfo()
      {
         ElementInfo ei;

         if (ParentNode.LocalName.Equals(ElementName.JDF))
         {
            ei = new ElementInfo(base.getTheElementInfo_JDFElement(), elemInfoTable);
         }
         else
         {
            ei = new ElementInfo(base.getTheElementInfo(), elemInfoTable);
         }
         return ei;
      }

      ///   
      ///	 <summary> * Constructor for JDFNodeInfo
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFNodeInfo(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFNodeInfo
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFNodeInfo(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFNodeInfo
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFNodeInfo(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      ///   
      ///	 <summary> * inner class EnumBusinessObject - printtalk based business objects </summary>
      ///	 
      public sealed class EnumBusinessObject : ValuedEnum
      {
         private const long serialVersionUID = 1L;

         private static int m_startValue = 0;

         private EnumBusinessObject(string status)
            : base(status, m_startValue++)
         {
         }

         public static EnumBusinessObject getEnum(string status)
         {
            return (EnumBusinessObject)getEnum(typeof(EnumBusinessObject), status);
         }

         public static EnumBusinessObject getEnum(int @value)
         {
            return (EnumBusinessObject)getEnum(typeof(EnumBusinessObject), @value);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumBusinessObject));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumBusinessObject));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumBusinessObject));
         }

         ///      
         ///		 <summary> * Retrieve all allowed value names of this Enum in a vector
         ///		 *  </summary>
         ///		 * <returns> the <code>String Vector of</code> names
         ///		 * @deprecated </returns>
         ///		 
         [Obsolete]
         public static ArrayList getNamesVector()
         {
            ArrayList namesVector = new ArrayList();
            IEnumerator it = iterator(typeof(EnumBusinessObject));
            while (it.MoveNext())
            {
               namesVector.Add(((ValuedEnum)it.Current).getName());
            }

            return namesVector;
         }

         ///      
         ///		 <summary> * constants EnumBusinessObject </summary>
         ///		 
         public static readonly EnumBusinessObject BusinessObject_Unknown = new EnumBusinessObject("BusinessObject_Unknown");
         public static readonly EnumBusinessObject BusinessObject_RFQ = new EnumBusinessObject("BusinessObject_RFQ");
         public static readonly EnumBusinessObject BusinessObject_Quote = new EnumBusinessObject("BusinessObject_Quote");
         public static readonly EnumBusinessObject BusinessObject_RFRequote = new EnumBusinessObject("BusinessObject_RFRequote");
         public static readonly EnumBusinessObject BusinessObject_Requote = new EnumBusinessObject("BusinessObject_Requote");
         public static readonly EnumBusinessObject BusinessObject_PO = new EnumBusinessObject("BusinessObject_PO");
         public static readonly EnumBusinessObject BusinessObject_Confirmation = new EnumBusinessObject("BusinessObject_Confirmation");
         public static readonly EnumBusinessObject BusinessObject_CO_RFQ = new EnumBusinessObject("BusinessObject_CO_RFQ");
         public static readonly EnumBusinessObject BusinessObject_CO_Quote = new EnumBusinessObject("BusinessObject_CO_Quote");
         public static readonly EnumBusinessObject BusinessObject_CO_PO = new EnumBusinessObject("BusinessObject_CO_PO");
         public static readonly EnumBusinessObject BusinessObject_CO_Confirmation = new EnumBusinessObject("BusinessObject_CO_Confirmation");
         public static readonly EnumBusinessObject BusinessObject_Invoice = new EnumBusinessObject("BusinessObject_Invoice");
         public static readonly EnumBusinessObject BusinessObject_None = new EnumBusinessObject("BusinessObject_None");

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
         return "JDFNodeInfo[ --> " + base.ToString() + " ]";
      }

      public override bool init()
      {
         XmlNode n = ParentNode;
         if (bDefaultWorkStepID && !hasAttribute(AttributeName.WORKSTEPID))
            setWorkStepID("W" + uniqueID(0));
         if (n != null && ElementName.RESOURCEPOOL.Equals(n.LocalName))
         {
            base.init();
            setResStatus(EnumResStatus.Available, false);
            setPartUsage(JDFResource.EnumPartUsage.Implicit);
         }
         return true;
      }

      ///   
      ///	 <summary> * set the workstepid
      ///	 *  </summary>
      ///	 * <param name="workStep"> </param>
      ///	 
      public virtual void setWorkStepID(string workStep)
      {
         setAttribute(AttributeName.WORKSTEPID, workStep, null);
      }

      ///   
      ///	 <summary> * get the workstepid
      ///	 *  </summary>
      ///	 * <returns> the workstepid
      ///	 *  </returns>
      ///	 
      public virtual string getWorkStepID()
      {
         return getAttribute(AttributeName.WORKSTEPID, null, "");
      }

      ///   
      ///	 <summary> * UpdateBusiness
      ///	 *  </summary>
      ///	 * <param name="businessObject"> </param>
      ///	 * <param name="newID">
      ///	 * @return </param>
      ///	 
      public virtual bool updateBusiness(EnumBusinessObject businessObject, string newID)
      {
         KElement bo = getElement(ElementName.BUSINESSINFO, JDFConstants.EMPTYSTRING, 0);

         ArrayList vBos = EnumBusinessObject.getNamesVector();
         KElement boe = bo.getChildFromList(new VString(vBos), 0, null, true);
         string bos = boe.Name;

         int oldType = vBos.IndexOf(bos);

         Console.WriteLine("JDFNodeInfo:: " + businessObject.getValue() + " Boe:: " + boe);
         boe.renameElement((string)vBos[businessObject.getValue()], JDFConstants.EMPTYSTRING);

         if (businessObject.getValue() > oldType)
         {
            boe.setAttribute(JDFConstants.BUSINESSREFID, boe.getAttribute(JDFConstants.BUSINESSID, JDFConstants.EMPTYSTRING, JDFConstants.EMPTYSTRING), JDFConstants.EMPTYSTRING);

            if (newID.Length != 0)
            {
               boe.setAttribute(JDFConstants.BUSINESSID, newID, JDFConstants.EMPTYSTRING);
            }
         }

         return true;
      }

      ///   
      ///	 <summary> * Get the linked resources matching some conditions
      ///	 *  </summary>
      ///	 * <param name="mResAtt"> map of Resource attributes to search for </param>
      ///	 * <param name="bFollowRefs"> true if internal references shall be followed </param>
      ///	 * <returns> vResource: vector with all elements matching the conditions default: GetLinkedResources(new
      ///	 *         JDFAttributeMap(), false) </returns>
      ///	 
      public virtual VElement getLinkedResources(JDFAttributeMap mResAtt, bool bFollowRefs)
      {
         VElement vChild = getChildElementVector(null, null, null, true, 0, false);
         VElement vElem = new VElement();
         for (int i = 0; i < vChild.Count; i++)
         {
            if (!(vChild[i] is JDFRefElement))
            {
               continue;
            }

            JDFRefElement l = (JDFRefElement)vChild[i];
            JDFResource r = l.getTarget();
            r = r == null ? null : r.getResourceRoot();
            if (r != null && r.includesAttributes(mResAtt, true))
            {
               vElem.Add(r); // vElem.push_back(r);
               if (bFollowRefs)
               {
                  vElem.appendUnique(r.getvHRefRes(bFollowRefs, true));
               }
            }
         }
         return vElem;
      }


      ///   
      ///	 <summary> * Mother of all version fixing routines
      ///	 * 
      ///	 * uses heuristics to modify this element and its children to be compatible with a given version in general, it will
      ///	 * be able to move from low to high versions but potentially fail when attempting to move from higher to lower
      ///	 * versions
      ///	 *  </summary>
      ///	 * <param name="version"> : version that the resulting element should correspond to </param>
      ///	 * <returns> true if successful </returns>
      ///	 
      public override bool fixVersion(EnumVersion version)
      {
         if (hasAttribute(AttributeName.RREFS))
            removeAttribute(AttributeName.RREFS);
         return base.fixVersion(version);
      }

      ///   
      ///	 <summary> * remove any resource specific attribute when making this to an element
      ///	 *  </summary>
      ///	 
      public override void cleanResourceAttributes()
      {
         removeAttribute(AttributeName.NODESTATUS);
         removeAttribute(AttributeName.NODESTATUSDETAILS);
         base.cleanResourceAttributes();
      }

      ///   
      ///	 * <returns> the bDefaultWorkStepID </returns>
      ///	 
      public static bool isDefaultWorkStepID()
      {
         return bDefaultWorkStepID;
      }

      ///   
      ///	 <summary> * if set to true, all newly generated partitions are generated with a unique WorkStepID attribute
      ///	 *  </summary>
      ///	 * <param name="defaultWorkStepID"> the bDefaultWorkStepID to set </param>
      ///	 
      public static void setDefaultWorkStepID(bool defaultWorkStepID)
      {
         bDefaultWorkStepID = defaultWorkStepID;
      }

      ///   
      ///	 <summary> * gets the subscription query for a given messagetype or creates one if not yet there note that newly created query
      ///	 * do not contain a subscription
      ///	 *  </summary>
      ///	 * <param name="queryType"> </param>
      ///	 * <returns> the appropriate query </returns>
      ///	 
      public virtual JDFQuery getCreateJMFQuery(EnumType queryType)
      {
         JDFQuery q = null;
         VElement v = getChildElementVector(ElementName.JMF, null);
         if (v != null)
         {
            int siz = v.Count;
            for (int i = 0; i < siz; i++)
            {
               JDFJMF jmf = (JDFJMF)v[i];
               q = (JDFQuery)jmf.getMessageElement(EnumFamily.Query, queryType, 0);
               if (q != null)
                  break;
            }
         }

         if (q == null)
         {
            q = appendJMF().appendQuery(queryType);
         }

         return q;
      }
   }
}
