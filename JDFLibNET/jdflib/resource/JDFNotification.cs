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



//JAVA TO VB & C# CONVERTER NOTE: Beginning of line comments are not maintained by Java to VB & C# Converter
//ORIGINAL LINE: *//**
 /* ==========================================================================
 * class JDFNotification extends JDFAutoNotification
 * created 2001-09-06T10:02:57GMT+02:00 
 * ==========================================================================
 * ==========================================================================
 * @COPYRIGHT Heidelberger Druckmaschinen AG, 1999-2001 ALL RIGHTS RESERVED
 * @Author: sabjon@topmail.de   using a code generator 
 * Warning! very preliminary test version. 
 * Interface subject to change without prior notice! 
 * Revision history:   ... */


namespace org.cip4.jdflib.resource
{
   using System.Collections;


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   using JDFAutoNotification = org.cip4.jdflib.auto.JDFAutoNotification;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFComment = org.cip4.jdflib.core.JDFComment;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using NodeIdentifier = org.cip4.jdflib.node.JDFNode.NodeIdentifier;

   public class JDFNotification : JDFAutoNotification
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFNotification
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFNotification(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFNotification
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFNotification(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFNotification
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFNotification(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      public class EnumNotificationDetails : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumNotificationDetails(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumNotificationDetails getEnum(string enumName)
         {
            return (EnumNotificationDetails)getEnum(typeof(EnumNotificationDetails), enumName);
         }

         public static EnumNotificationDetails getEnum(int enumValue)
         {
            return (EnumNotificationDetails)getEnum(typeof(EnumNotificationDetails), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumNotificationDetails));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumNotificationDetails));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumNotificationDetails));
         }

         public static readonly EnumNotificationDetails Barcode = new EnumNotificationDetails(ElementName.BARCODE);
         public static readonly EnumNotificationDetails FCNKey = new EnumNotificationDetails(ElementName.FCNKEY);
         public static readonly EnumNotificationDetails SystemTimeSet = new EnumNotificationDetails(ElementName.SYSTEMTIMESET);
         public static readonly EnumNotificationDetails CounterReset = new EnumNotificationDetails(ElementName.COUNTERRESET);
         public static readonly EnumNotificationDetails Error = new EnumNotificationDetails(ElementName.ERROR);
         public static readonly EnumNotificationDetails Event = new EnumNotificationDetails(ElementName.EVENT);
         public static readonly EnumNotificationDetails Milestone = new EnumNotificationDetails(ElementName.MILESTONE);
      }

      ///   
      ///	 <summary> * toString()
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public override string ToString()
      {
         return "JDFNotification[  --> " + base.ToString() + " ]";
      }

      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[7];
      static JDFNotification()
      {
         elemInfoTable[0] = new ElemInfoTable(ElementName.BARCODE, 0x33333333);
         elemInfoTable[1] = new ElemInfoTable(ElementName.FCNKEY, 0x33333333);
         elemInfoTable[2] = new ElemInfoTable(ElementName.SYSTEMTIMESET, 0x33333333);
         elemInfoTable[3] = new ElemInfoTable(ElementName.COUNTERRESET, 0x33333333);
         elemInfoTable[4] = new ElemInfoTable(ElementName.ERROR, 0x33333333);
         elemInfoTable[5] = new ElemInfoTable(ElementName.EVENT, 0x33333333);
         elemInfoTable[6] = new ElemInfoTable(ElementName.MILESTONE, 0x33333333);
      }

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateAdd(elemInfoTable);
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
      ///	 <summary> * set all parts to those defined in vParts
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
      ///	 <summary> * remove the part defined by mPart
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
      ///	 * <returns> boolean - returns true if the part exists </returns>
      ///	 
      public override bool hasPartMap(JDFAttributeMap mPart)
      {
         return base.hasPartMap(mPart);
      }

      ///   
      ///	 <summary> * get element <code>Barcode</code>, create if it doesn't exist
      ///	 *  </summary>
      ///	 * <returns> JDFBarcode: the element </returns>
      ///	 
      public virtual JDFBarcode getCreateBarcode()
      {
         return (JDFBarcode)getCreateNotificationDetails(EnumNotificationDetails.Barcode);
      }

      ///   
      ///	 <summary> * append element <code>Barcode</code>
      ///	 *  </summary>
      ///	 * <returns> JDFBarcode: the element </returns>
      ///	 
      public virtual JDFBarcode appendBarcode()
      {
         return (JDFBarcode)appendNotificationDetails(EnumNotificationDetails.Barcode);
      }

      ///   
      ///	 <summary> * get element <code>Barcode</code>
      ///	 *  </summary>
      ///	 * <returns> JDFBarcode: the element </returns>
      ///	 
      public virtual JDFBarcode getBarcode()
      {
         return (JDFBarcode)getNotificationDetails();
      }

      ///   
      ///	 <summary> * get element <code>FCNKey</code>, create if it doesn't exist
      ///	 *  </summary>
      ///	 * <returns> JDFFCNKey: the element </returns>
      ///	 
      public virtual JDFFCNKey getCreateFCNKey()
      {
         return (JDFFCNKey)getCreateNotificationDetails(EnumNotificationDetails.FCNKey);
      }

      ///   
      ///	 <summary> * append element <code>FCNKey</code>
      ///	 *  </summary>
      ///	 * <returns> JDFFCNKey: the element </returns>
      ///	 
      public virtual JDFFCNKey appendFCNKey()
      {
         return (JDFFCNKey)appendNotificationDetails(EnumNotificationDetails.FCNKey);
      }

      ///   
      ///	 <summary> * get element <code>FCNKey</code>
      ///	 *  </summary>
      ///	 * <returns> JDFFCNKey: the element </returns>
      ///	 
      public virtual JDFFCNKey getFCNKey()
      {
         return (JDFFCNKey)getNotificationDetails();
      }

      ///   
      ///	 <summary> * get element <code>SystemTimeSet</code>, create if it doesn't exist
      ///	 *  </summary>
      ///	 * <returns> JDFSystemTimeSet: the element </returns>
      ///	 
      public virtual JDFSystemTimeSet getCreateSystemTimeSet()
      {
         return (JDFSystemTimeSet)getCreateNotificationDetails(EnumNotificationDetails.SystemTimeSet);
      }

      ///   
      ///	 <summary> * append element <code>SystemTimeSet</code>
      ///	 *  </summary>
      ///	 * <returns> JDFSystemTimeSet: the element </returns>
      ///	 
      public virtual JDFSystemTimeSet appendSystemTimeSet()
      {
         return (JDFSystemTimeSet)appendNotificationDetails(EnumNotificationDetails.SystemTimeSet);
      }

      ///   
      ///	 <summary> * get element <code>SystemTimeSet</code>
      ///	 *  </summary>
      ///	 * <returns> JDFSystemTimeSet: the element </returns>
      ///	 
      public virtual JDFSystemTimeSet getSystemTimeSet()
      {
         return (JDFSystemTimeSet)getNotificationDetails();
      }

      ///   
      ///	 <summary> * get element <code>CreateCounterReset</code>, create if it doesn't exist
      ///	 *  </summary>
      ///	 * <returns> JDFCreateCounterReset: the element </returns>
      ///	 
      public virtual JDFCounterReset getCreateCounterReset()
      {
         return (JDFCounterReset)getCreateNotificationDetails(EnumNotificationDetails.CounterReset);
      }

      ///   
      ///	 <summary> * append element <code>CreateCounterReset</code>
      ///	 *  </summary>
      ///	 * <returns> JDFCreateCounterReset: the element </returns>
      ///	 
      public virtual JDFCounterReset appendCounterReset()
      {
         return (JDFCounterReset)appendNotificationDetails(EnumNotificationDetails.CounterReset);
      }

      ///   
      ///	 <summary> * get element <code>CreateCounterReset</code>
      ///	 *  </summary>
      ///	 * <returns> JDFCreateCounterReset: the element </returns>
      ///	 
      public virtual JDFCounterReset getCounterReset()
      {
         return (JDFCounterReset)getNotificationDetails();
      }

      ///   
      ///	 <summary> * get comment text if available, 
      ///	 *  </summary>
      ///	 * <returns> String the comment text, else null </returns>
      ///	 
      public virtual string getCommentText()
      {
         JDFComment c = getComment(0);
         if (c == null)
            return null;
         return c.getText();
      }

      ///   
      ///	 <summary> * set comment text , also creates the comment if not there </summary>
      ///	 * <param name="text"> the comment text to set
      ///	 *  </param>
      ///	 * <returns> <seealso cref="JDFComment"/> the comment  </returns>
      ///	 
      public virtual JDFComment setCommentText(string text)
      {
         JDFComment c = getCreateComment(0);
         c.setText(text);
         return c;
      }

      ///   
      ///	 <summary> * get element <code>Error</code>, create if it doesn't exist
      ///	 *  </summary>
      ///	 * <returns> JDFError: the element </returns>
      ///	 
      public virtual JDFError getCreateError()
      {
         return (JDFError)getCreateNotificationDetails(EnumNotificationDetails.Error);
      }

      ///   
      ///	 <summary> * append element <code>Error</code>
      ///	 *  </summary>
      ///	 * <returns> JDFError: the element </returns>
      ///	 
      public virtual JDFError appendError()
      {
         return (JDFError)appendNotificationDetails(EnumNotificationDetails.Error);
      }

      ///   
      ///	 <summary> * get element <code>Error</code>
      ///	 *  </summary>
      ///	 * <returns> JDFError: the element </returns>
      ///	 
      public virtual JDFError getError()
      {
         return (JDFError)getNotificationDetails();
      }

      ///   
      ///	 <summary> * get element <code>Event</code>, create if it doesn't exist
      ///	 *  </summary>
      ///	 * <returns> JDFEvent: the element </returns>
      ///	 
      public virtual JDFEvent getCreateEvent()
      {
         return (JDFEvent)getCreateNotificationDetails(EnumNotificationDetails.Event);
      }

      ///   
      ///	 <summary> * append element <code>Event</code>
      ///	 *  </summary>
      ///	 * <returns> JDFEvent: the element </returns>
      ///	 
      public virtual JDFEvent appendEvent()
      {
         return (JDFEvent)appendNotificationDetails(EnumNotificationDetails.Event);
      }

      ///   
      ///	 <summary> * set this to an event, append the Event element and optionally the comment<br/> overwrites existing values
      ///	 *  </summary>
      ///	 * <param name="eventID"> Event/@EventID to set </param>
      ///	 * <param name="eventValue"> Event/@EventValue to set </param>
      ///	 * <param name="comment"> the comment text, if null no comment is set </param>
      ///	 * <returns> the newly created event </returns>
      ///	 
      public virtual JDFEvent setEvent(string eventID, string eventValue, string comment)
      {
         JDFEvent @event = getCreateEvent();
         if (@event == null)
            return null;
         @event.setEventID(eventID);
         @event.setEventValue(eventValue);
         setCommentText(comment);
         return @event;
      }

      public virtual void setNode(JDFNode n)
      {
         setNode(new NodeIdentifier(n));
      }

      ///   
      ///	 * <param name="identifier"> </param>
      ///	 
      public virtual void setNode(NodeIdentifier identifier)
      {
         NodeIdentifier identifierLocal = identifier;

         if (identifierLocal == null)
            identifierLocal = new NodeIdentifier((JDFNode)null);

         setJobID(identifierLocal.getJobID());
         setJobPartID(identifierLocal.getJobPartID());
         setPartMapVector(identifierLocal.getPartMapVector());
      }

      ///   
      ///	 <summary> * append one of the predefined notification details
      ///	 *  </summary>
      ///	 * <param name="details">
      ///	 * @return </param>
      ///	 
      public virtual JDFElement appendNotificationDetails(EnumNotificationDetails details)
      {
         EnumNotificationDetails det = getNotificationDetailsType();
         if (det != null && !det.Equals(details))
            return null;
         setType(details.getName());
         return (JDFElement)appendElementN(details.getName(), 1, null);
      }

      ///   
      ///	 <summary> * append one of the predefined notification details
      ///	 *  </summary>
      ///	 * <param name="details">
      ///	 * @return </param>
      ///	 
      public virtual JDFElement getCreateNotificationDetails(EnumNotificationDetails details)
      {
         JDFElement e = getNotificationDetails();
         if (e == null)
            return appendNotificationDetails(details);
         if (!details.getName().Equals(e.LocalName))
            return null;
         setType(details.getName());
         return e;
      }

      ///   
      ///	 <summary> * get the predefined notification details
      ///	 *  </summary>
      ///	 * <param name="details">
      ///	 * @return </param>
      ///	 
      public virtual JDFElement getNotificationDetails()
      {
         EnumNotificationDetails det = getNotificationDetailsType();
         if (det == null)
            return null;
         return (JDFElement)getElement(det.getName(), null, 0);
      }

      ///   
      ///	 <summary> * @return </summary>
      ///	 
      public virtual EnumNotificationDetails getNotificationDetailsType()
      {
         string s = getType();
         if (isWildCard(s))
            return null;
         return EnumNotificationDetails.getEnum(s);
      }

      ///   
      ///	 <summary> * get element <code>Event</code>
      ///	 *  </summary>
      ///	 * <returns> JDFEvent: the element </returns>
      ///	 
      public virtual JDFEvent getEvent()
      {
         return (JDFEvent)getNotificationDetails();
      }

      ///   
      ///	 <summary> * get element <code>Milestone</code>, create if it doesn't exist
      ///	 *  </summary>
      ///	 * <returns> JDFMilestone: the element </returns>
      ///	 
      public virtual JDFMilestone getCreateMilestone()
      {
         return (JDFMilestone)getCreateNotificationDetails(EnumNotificationDetails.Milestone);
      }

      ///   
      ///	 <summary> * append element <code>Milestone</code>
      ///	 *  </summary>
      ///	 * <returns> JDFMilestone: the element </returns>
      ///	 
      public virtual JDFMilestone appendMilestone()
      {
         return (JDFMilestone)appendNotificationDetails(EnumNotificationDetails.Milestone);
      }

      ///   
      ///	 <summary> * get element <code>Milestone</code>
      ///	 *  </summary>
      ///	 * <returns> JDFMilestone: the element </returns>
      ///	 
      public virtual JDFMilestone getMilestone()
      {
         return (JDFMilestone)getNotificationDetails();
      }
   }
}
