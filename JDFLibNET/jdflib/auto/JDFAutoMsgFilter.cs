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




namespace org.cip4.jdflib.auto
{
   using System;
   using System.Collections;
   using System.Collections.Generic;


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFPart = org.cip4.jdflib.resource.JDFPart;
   using JDFDate = org.cip4.jdflib.util.JDFDate;

   public abstract class JDFAutoMsgFilter : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[12];
      static JDFAutoMsgFilter()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.AFTER, 0x33333333, AttributeInfo.EnumAttributeType.dateTime, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.BEFORE, 0x33333333, AttributeInfo.EnumAttributeType.dateTime, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.COUNT, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.DEVICEID, 0x33333333, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.FAMILY, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumFamily.getEnum(0), null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.JOBID, 0x33333311, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.JOBPARTID, 0x33333311, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.MESSAGEREFID, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.MESSAGEID, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.MESSAGETYPE, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[10] = new AtrInfoTable(AttributeName.QUEUEENTRYID, 0x33333311, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[11] = new AtrInfoTable(AttributeName.RECEIVERURL, 0x33333333, AttributeInfo.EnumAttributeType.URL, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.PART, 0x33333311);
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
      ///     <summary> * Constructor for JDFAutoMsgFilter </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoMsgFilter(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoMsgFilter </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoMsgFilter(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoMsgFilter </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoMsgFilter(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoMsgFilter[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for Family </summary>
      ///        

      public class EnumFamily : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumFamily(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumFamily getEnum(string enumName)
         {
            return (EnumFamily)getEnum(typeof(EnumFamily), enumName);
         }

         public static EnumFamily getEnum(int enumValue)
         {
            return (EnumFamily)getEnum(typeof(EnumFamily), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumFamily));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumFamily));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumFamily));
         }

         public static readonly EnumFamily Acknowledge = new EnumFamily("Acknowledge");
         public static readonly EnumFamily Response = new EnumFamily("Response");
         public static readonly EnumFamily Signal = new EnumFamily("Signal");
         public static readonly EnumFamily All = new EnumFamily("All");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute After
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (11) set attribute After </summary>
      ///          * <param name="value">: the value to set the attribute to or null </param>
      ///          
      public virtual void setAfter(JDFDate @value)
      {
         JDFDate date = @value;
         if (date == null)
            date = new JDFDate();
         setAttribute(AttributeName.AFTER, date.DateTimeISO, null);
      }

      ///        
      ///          <summary> * (12) get JDFDate attribute After </summary>
      ///          * <returns> JDFDate the value of the attribute </returns>
      ///          
      public virtual JDFDate getAfter()
      {
         JDFDate nMyDate = null;
         string str = JDFConstants.EMPTYSTRING;
         str = getAttribute(AttributeName.AFTER, null, JDFConstants.EMPTYSTRING);
         if (!JDFConstants.EMPTYSTRING.Equals(str))
         {
            try
            {
               nMyDate = new JDFDate(str);
            }
            catch (FormatException)
            {
               // throw new JDFException("not a valid date string. Malformed JDF - return null");
            }
         }
         return nMyDate;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Before
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (11) set attribute Before </summary>
      ///          * <param name="value">: the value to set the attribute to or null </param>
      ///          
      public virtual void setBefore(JDFDate @value)
      {
         JDFDate date = @value;
         if (date == null)
            date = new JDFDate();
         setAttribute(AttributeName.BEFORE, date.DateTimeISO, null);
      }

      ///        
      ///          <summary> * (12) get JDFDate attribute Before </summary>
      ///          * <returns> JDFDate the value of the attribute </returns>
      ///          
      public virtual JDFDate getBefore()
      {
         JDFDate nMyDate = null;
         string str = JDFConstants.EMPTYSTRING;
         str = getAttribute(AttributeName.BEFORE, null, JDFConstants.EMPTYSTRING);
         if (!JDFConstants.EMPTYSTRING.Equals(str))
         {
            try
            {
               nMyDate = new JDFDate(str);
            }
            catch (FormatException)
            {
               // throw new JDFException("not a valid date string. Malformed JDF - return null");
            }
         }
         return nMyDate;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Count
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Count </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCount(int @value)
      {
         setAttribute(AttributeName.COUNT, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute Count </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getCount()
      {
         return getIntAttribute(AttributeName.COUNT, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute DeviceID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DeviceID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDeviceID(string @value)
      {
         setAttribute(AttributeName.DEVICEID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute DeviceID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getDeviceID()
      {
         return getAttribute(AttributeName.DEVICEID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Family
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Family </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setFamily(EnumFamily enumVar)
      {
         setAttribute(AttributeName.FAMILY, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Family </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumFamily getFamily()
      {
         return EnumFamily.getEnum(getAttribute(AttributeName.FAMILY, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute JobID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute JobID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setJobID(string @value)
      {
         setAttribute(AttributeName.JOBID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute JobID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getJobID()
      {
         return getAttribute(AttributeName.JOBID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute JobPartID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute JobPartID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setJobPartID(string @value)
      {
         setAttribute(AttributeName.JOBPARTID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute JobPartID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getJobPartID()
      {
         return getAttribute(AttributeName.JOBPARTID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MessageRefID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MessageRefID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMessageRefID(string @value)
      {
         setAttribute(AttributeName.MESSAGEREFID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute MessageRefID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getMessageRefID()
      {
         return getAttribute(AttributeName.MESSAGEREFID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MessageID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MessageID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMessageID(string @value)
      {
         setAttribute(AttributeName.MESSAGEID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute MessageID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getMessageID()
      {
         return getAttribute(AttributeName.MESSAGEID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MessageType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MessageType </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMessageType(string @value)
      {
         setAttribute(AttributeName.MESSAGETYPE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute MessageType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getMessageType()
      {
         return getAttribute(AttributeName.MESSAGETYPE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute QueueEntryID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute QueueEntryID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setQueueEntryID(string @value)
      {
         setAttribute(AttributeName.QUEUEENTRYID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute QueueEntryID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getQueueEntryID()
      {
         return getAttribute(AttributeName.QUEUEENTRYID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ReceiverURL
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ReceiverURL </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setReceiverURL(string @value)
      {
         setAttribute(AttributeName.RECEIVERURL, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ReceiverURL </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getReceiverURL()
      {
         return getAttribute(AttributeName.RECEIVERURL, null, JDFConstants.EMPTYSTRING);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreatePart
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFPart the element </returns>
      ///     
      public virtual JDFPart getCreatePart(int iSkip)
      {
         return (JDFPart)getCreateElement_KElement(ElementName.PART, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Part </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFPart the element </returns>
      ///     * default is getPart(0)     
      public virtual JDFPart getPart(int iSkip)
      {
         return (JDFPart)getElement(ElementName.PART, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Part from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFPart> </returns>
      ///     
      public virtual ICollection<JDFPart> getAllPart()
      {
         List<JDFPart> v = new List<JDFPart>();

         JDFPart kElem = (JDFPart)getFirstChildElement(ElementName.PART, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFPart)kElem.getNextSiblingElement(ElementName.PART, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Part </summary>
      ///     
      public virtual JDFPart appendPart()
      {
         return (JDFPart)appendElement(ElementName.PART, null);
      }
   }
}
