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
   using JDFQueueEntry = org.cip4.jdflib.jmf.JDFQueueEntry;
   using JDFDevice = org.cip4.jdflib.resource.JDFDevice;

   public abstract class JDFAutoQueue : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[3];
      static JDFAutoQueue()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.STATUS, 0x22222222, AttributeInfo.EnumAttributeType.enumeration, EnumQueueStatus.getEnum(0), null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.DEVICEID, 0x22222222, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.QUEUESIZE, 0x33333311, AttributeInfo.EnumAttributeType.integer, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.DEVICE, 0x33333333);
         elemInfoTable[1] = new ElemInfoTable(ElementName.QUEUEENTRY, 0x33333333);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[2];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoQueue </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoQueue(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoQueue </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoQueue(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoQueue </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoQueue(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoQueue[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for QueueStatus </summary>
      ///        

      public class EnumQueueStatus : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumQueueStatus(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumQueueStatus getEnum(string enumName)
         {
            return (EnumQueueStatus)getEnum(typeof(EnumQueueStatus), enumName);
         }

         public static EnumQueueStatus getEnum(int enumValue)
         {
            return (EnumQueueStatus)getEnum(typeof(EnumQueueStatus), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumQueueStatus));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumQueueStatus));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumQueueStatus));
         }

         public static readonly EnumQueueStatus Blocked = new EnumQueueStatus("Blocked");
         public static readonly EnumQueueStatus Closed = new EnumQueueStatus("Closed");
         public static readonly EnumQueueStatus Full = new EnumQueueStatus("Full");
         public static readonly EnumQueueStatus Running = new EnumQueueStatus("Running");
         public static readonly EnumQueueStatus Waiting = new EnumQueueStatus("Waiting");
         public static readonly EnumQueueStatus Held = new EnumQueueStatus("Held");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute Status
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Status </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setQueueStatus(EnumQueueStatus enumVar)
      {
         setAttribute(AttributeName.STATUS, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Status </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumQueueStatus getQueueStatus()
      {
         return EnumQueueStatus.getEnum(getAttribute(AttributeName.STATUS, null, null));
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
      //        Methods for Attribute QueueSize
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute QueueSize </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setQueueSize(int @value)
      {
         setAttribute(AttributeName.QUEUESIZE, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute QueueSize </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getQueueSize()
      {
         return getIntAttribute(AttributeName.QUEUESIZE, null, 0);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateDevice
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFDevice the element </returns>
      ///     
      public virtual JDFDevice getCreateDevice(int iSkip)
      {
         return (JDFDevice)getCreateElement_KElement(ElementName.DEVICE, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Device </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFDevice the element </returns>
      ///     * default is getDevice(0)     
      public virtual JDFDevice getDevice(int iSkip)
      {
         return (JDFDevice)getElement(ElementName.DEVICE, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Device from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFDevice> </returns>
      ///     
      public virtual ICollection<JDFDevice> getAllDevice()
      {
         List<JDFDevice> v = new List<JDFDevice>();

         JDFDevice kElem = (JDFDevice)getFirstChildElement(ElementName.DEVICE, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFDevice)kElem.getNextSiblingElement(ElementName.DEVICE, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Device </summary>
      ///     
      public virtual JDFDevice appendDevice()
      {
         return (JDFDevice)appendElement(ElementName.DEVICE, null);
      }

      ///     <summary> (26) getCreateQueueEntry
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFQueueEntry the element </returns>
      ///     
      public virtual JDFQueueEntry getCreateQueueEntry(int iSkip)
      {
         return (JDFQueueEntry)getCreateElement_KElement(ElementName.QUEUEENTRY, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element QueueEntry </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFQueueEntry the element </returns>
      ///     * default is getQueueEntry(0)     
      public virtual JDFQueueEntry getQueueEntry(int iSkip)
      {
         return (JDFQueueEntry)getElement(ElementName.QUEUEENTRY, null, iSkip);
      }

      ///    
      ///     <summary> * Get all QueueEntry from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFQueueEntry> </returns>
      ///     
      public virtual ICollection<JDFQueueEntry> getAllQueueEntry()
      {
         List<JDFQueueEntry> v = new List<JDFQueueEntry>();

         JDFQueueEntry kElem = (JDFQueueEntry)getFirstChildElement(ElementName.QUEUEENTRY, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFQueueEntry)kElem.getNextSiblingElement(ElementName.QUEUEENTRY, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element QueueEntry </summary>
      ///     
      public virtual JDFQueueEntry appendQueueEntry()
      {
         return (JDFQueueEntry)appendElement(ElementName.QUEUEENTRY, null);
      }
   }
}
