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
   using VString = org.cip4.jdflib.core.VString;
   using JDFQueueEntryDef = org.cip4.jdflib.jmf.JDFQueueEntryDef;
   using JDFDevice = org.cip4.jdflib.resource.JDFDevice;
   using JDFDate = org.cip4.jdflib.util.JDFDate;

   public abstract class JDFAutoQueueFilter : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[6];
      static JDFAutoQueueFilter()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.GANGNAMES, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.MAXENTRIES, 0x33333311, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.OLDERTHAN, 0x33333311, AttributeInfo.EnumAttributeType.dateTime, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.NEWERTHAN, 0x33333311, AttributeInfo.EnumAttributeType.dateTime, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.QUEUEENTRYDETAILS, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumQueueEntryDetails.getEnum(0), "Brief");
         atrInfoTable[5] = new AtrInfoTable(AttributeName.STATUSLIST, 0x33333311, AttributeInfo.EnumAttributeType.enumerations, EnumStatusList.getEnum(0), null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.QUEUEENTRYDEF, 0x33333311);
         elemInfoTable[1] = new ElemInfoTable(ElementName.DEVICE, 0x33333311);
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
      ///     <summary> * Constructor for JDFAutoQueueFilter </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoQueueFilter(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoQueueFilter </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoQueueFilter(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoQueueFilter </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoQueueFilter(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoQueueFilter[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for QueueEntryDetails </summary>
      ///        

      public class EnumQueueEntryDetails : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumQueueEntryDetails(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumQueueEntryDetails getEnum(string enumName)
         {
            return (EnumQueueEntryDetails)getEnum(typeof(EnumQueueEntryDetails), enumName);
         }

         public static EnumQueueEntryDetails getEnum(int enumValue)
         {
            return (EnumQueueEntryDetails)getEnum(typeof(EnumQueueEntryDetails), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumQueueEntryDetails));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumQueueEntryDetails));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumQueueEntryDetails));
         }

         public static readonly EnumQueueEntryDetails None = new EnumQueueEntryDetails("None");
         public static readonly EnumQueueEntryDetails Brief = new EnumQueueEntryDetails("Brief");
         public static readonly EnumQueueEntryDetails JobPhase = new EnumQueueEntryDetails("JobPhase");
         public static readonly EnumQueueEntryDetails JDF = new EnumQueueEntryDetails("JDF");
      }



      ///        
      ///        <summary> * Enumeration strings for StatusList </summary>
      ///        

      public class EnumStatusList : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumStatusList(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumStatusList getEnum(string enumName)
         {
            return (EnumStatusList)getEnum(typeof(EnumStatusList), enumName);
         }

         public static EnumStatusList getEnum(int enumValue)
         {
            return (EnumStatusList)getEnum(typeof(EnumStatusList), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumStatusList));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumStatusList));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumStatusList));
         }

         public static readonly EnumStatusList Running = new EnumStatusList("Running");
         public static readonly EnumStatusList Waiting = new EnumStatusList("Waiting");
         public static readonly EnumStatusList Held = new EnumStatusList("Held");
         public static readonly EnumStatusList Removed = new EnumStatusList("Removed");
         public static readonly EnumStatusList Suspended = new EnumStatusList("Suspended");
         public static readonly EnumStatusList PendingReturn = new EnumStatusList("PendingReturn");
         public static readonly EnumStatusList Completed = new EnumStatusList("Completed");
         public static readonly EnumStatusList Aborted = new EnumStatusList("Aborted");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute GangNames
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute GangNames </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setGangNames(VString @value)
      {
         setAttribute(AttributeName.GANGNAMES, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute GangNames </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getGangNames()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.GANGNAMES, null, JDFConstants.EMPTYSTRING);
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MaxEntries
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MaxEntries </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMaxEntries(int @value)
      {
         setAttribute(AttributeName.MAXENTRIES, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute MaxEntries </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getMaxEntries()
      {
         return getIntAttribute(AttributeName.MAXENTRIES, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute OlderThan
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (11) set attribute OlderThan </summary>
      ///          * <param name="value">: the value to set the attribute to or null </param>
      ///          
      public virtual void setOlderThan(JDFDate @value)
      {
         JDFDate date = @value;
         if (date == null)
            date = new JDFDate();
         setAttribute(AttributeName.OLDERTHAN, date.DateTimeISO, null);
      }

      ///        
      ///          <summary> * (12) get JDFDate attribute OlderThan </summary>
      ///          * <returns> JDFDate the value of the attribute </returns>
      ///          
      public virtual JDFDate getOlderThan()
      {
         JDFDate nMyDate = null;
         string str = JDFConstants.EMPTYSTRING;
         str = getAttribute(AttributeName.OLDERTHAN, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute NewerThan
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (11) set attribute NewerThan </summary>
      ///          * <param name="value">: the value to set the attribute to or null </param>
      ///          
      public virtual void setNewerThan(JDFDate @value)
      {
         JDFDate date = @value;
         if (date == null)
            date = new JDFDate();
         setAttribute(AttributeName.NEWERTHAN, date.DateTimeISO, null);
      }

      ///        
      ///          <summary> * (12) get JDFDate attribute NewerThan </summary>
      ///          * <returns> JDFDate the value of the attribute </returns>
      ///          
      public virtual JDFDate getNewerThan()
      {
         JDFDate nMyDate = null;
         string str = JDFConstants.EMPTYSTRING;
         str = getAttribute(AttributeName.NEWERTHAN, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute QueueEntryDetails
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute QueueEntryDetails </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setQueueEntryDetails(EnumQueueEntryDetails enumVar)
      {
         setAttribute(AttributeName.QUEUEENTRYDETAILS, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute QueueEntryDetails </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumQueueEntryDetails getQueueEntryDetails()
      {
         return EnumQueueEntryDetails.getEnum(getAttribute(AttributeName.QUEUEENTRYDETAILS, null, "Brief"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute StatusList
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5.2) set attribute StatusList </summary>
      ///          * <param name="v"> vector of the enumeration values </param>
      ///          
      public virtual void setStatusList(List<ValuedEnum> v)
      {
         setEnumerationsAttribute(AttributeName.STATUSLIST, v, null);
      }

      ///        
      ///          <summary> * (9.2) get StatusList attribute StatusList </summary>
      ///          * <returns> Vector of the enumerations </returns>
      ///          
      public virtual List<ValuedEnum> getStatusList()
      {
         return getEnumerationsAttribute(AttributeName.STATUSLIST, null, EnumStatusList.getEnum(0), false);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateQueueEntryDef
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFQueueEntryDef the element </returns>
      ///     
      public virtual JDFQueueEntryDef getCreateQueueEntryDef(int iSkip)
      {
         return (JDFQueueEntryDef)getCreateElement_KElement(ElementName.QUEUEENTRYDEF, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element QueueEntryDef </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFQueueEntryDef the element </returns>
      ///     * default is getQueueEntryDef(0)     
      public virtual JDFQueueEntryDef getQueueEntryDef(int iSkip)
      {
         return (JDFQueueEntryDef)getElement(ElementName.QUEUEENTRYDEF, null, iSkip);
      }

      ///    
      ///     <summary> * Get all QueueEntryDef from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFQueueEntryDef> </returns>
      ///     
      public virtual ICollection<JDFQueueEntryDef> getAllQueueEntryDef()
      {
         List<JDFQueueEntryDef> v = new List<JDFQueueEntryDef>();

         JDFQueueEntryDef kElem = (JDFQueueEntryDef)getFirstChildElement(ElementName.QUEUEENTRYDEF, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFQueueEntryDef)kElem.getNextSiblingElement(ElementName.QUEUEENTRYDEF, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element QueueEntryDef </summary>
      ///     
      public virtual JDFQueueEntryDef appendQueueEntryDef()
      {
         return (JDFQueueEntryDef)appendElement(ElementName.QUEUEENTRYDEF, null);
      }

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
   }
}
