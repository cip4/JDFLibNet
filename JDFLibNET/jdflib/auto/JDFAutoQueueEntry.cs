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
   using JDFJobPhase = org.cip4.jdflib.jmf.JDFJobPhase;
   using JDFPart = org.cip4.jdflib.resource.JDFPart;
   using JDFPreview = org.cip4.jdflib.resource.process.JDFPreview;
   using JDFDate = org.cip4.jdflib.util.JDFDate;

   public abstract class JDFAutoQueueEntry : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[10];
      static JDFAutoQueueEntry()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.DEVICEID, 0x33333311, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.ENDTIME, 0x33333311, AttributeInfo.EnumAttributeType.dateTime, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.GANGNAME, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.JOBID, 0x33333333, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.JOBPARTID, 0x33333333, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.PRIORITY, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, "1");
         atrInfoTable[6] = new AtrInfoTable(AttributeName.QUEUEENTRYID, 0x22222222, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.STATUS, 0x22222222, AttributeInfo.EnumAttributeType.enumeration, EnumQueueEntryStatus.getEnum(0), null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.STARTTIME, 0x33333311, AttributeInfo.EnumAttributeType.dateTime, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.SUBMISSIONTIME, 0x33333333, AttributeInfo.EnumAttributeType.dateTime, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.JOBPHASE, 0x66666611);
         elemInfoTable[1] = new ElemInfoTable(ElementName.PART, 0x33333311);
         elemInfoTable[2] = new ElemInfoTable(ElementName.PREVIEW, 0x33333311);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[3];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoQueueEntry </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoQueueEntry(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoQueueEntry </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoQueueEntry(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoQueueEntry </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoQueueEntry(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoQueueEntry[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for QueueEntryStatus </summary>
      ///        

      public class EnumQueueEntryStatus : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumQueueEntryStatus(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumQueueEntryStatus getEnum(string enumName)
         {
            return (EnumQueueEntryStatus)getEnum(typeof(EnumQueueEntryStatus), enumName);
         }

         public static EnumQueueEntryStatus getEnum(int enumValue)
         {
            return (EnumQueueEntryStatus)getEnum(typeof(EnumQueueEntryStatus), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumQueueEntryStatus));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumQueueEntryStatus));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumQueueEntryStatus));
         }

         public static readonly EnumQueueEntryStatus Running = new EnumQueueEntryStatus("Running");
         public static readonly EnumQueueEntryStatus Waiting = new EnumQueueEntryStatus("Waiting");
         public static readonly EnumQueueEntryStatus Held = new EnumQueueEntryStatus("Held");
         public static readonly EnumQueueEntryStatus Removed = new EnumQueueEntryStatus("Removed");
         public static readonly EnumQueueEntryStatus Suspended = new EnumQueueEntryStatus("Suspended");
         public static readonly EnumQueueEntryStatus PendingReturn = new EnumQueueEntryStatus("PendingReturn");
         public static readonly EnumQueueEntryStatus Completed = new EnumQueueEntryStatus("Completed");
         public static readonly EnumQueueEntryStatus Aborted = new EnumQueueEntryStatus("Aborted");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

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
      //        Methods for Attribute EndTime
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (11) set attribute EndTime </summary>
      ///          * <param name="value">: the value to set the attribute to or null </param>
      ///          
      public virtual void setEndTime(JDFDate @value)
      {
         JDFDate date = @value;
         if (date == null)
            date = new JDFDate();
         setAttribute(AttributeName.ENDTIME, date.DateTimeISO, null);
      }

      ///        
      ///          <summary> * (12) get JDFDate attribute EndTime </summary>
      ///          * <returns> JDFDate the value of the attribute </returns>
      ///          
      public virtual JDFDate getEndTime()
      {
         JDFDate nMyDate = null;
         string str = JDFConstants.EMPTYSTRING;
         str = getAttribute(AttributeName.ENDTIME, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute GangName
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute GangName </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setGangName(string @value)
      {
         setAttribute(AttributeName.GANGNAME, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute GangName </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getGangName()
      {
         return getAttribute(AttributeName.GANGNAME, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute Priority
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Priority </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPriority(int @value)
      {
         setAttribute(AttributeName.PRIORITY, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute Priority </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getPriority()
      {
         return getIntAttribute(AttributeName.PRIORITY, null, 1);
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
      //        Methods for Attribute Status
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Status </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setQueueEntryStatus(EnumQueueEntryStatus enumVar)
      {
         setAttribute(AttributeName.STATUS, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Status </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumQueueEntryStatus getQueueEntryStatus()
      {
         return EnumQueueEntryStatus.getEnum(getAttribute(AttributeName.STATUS, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute StartTime
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (11) set attribute StartTime </summary>
      ///          * <param name="value">: the value to set the attribute to or null </param>
      ///          
      public virtual void setStartTime(JDFDate @value)
      {
         JDFDate date = @value;
         if (date == null)
            date = new JDFDate();
         setAttribute(AttributeName.STARTTIME, date.DateTimeISO, null);
      }

      ///        
      ///          <summary> * (12) get JDFDate attribute StartTime </summary>
      ///          * <returns> JDFDate the value of the attribute </returns>
      ///          
      public virtual JDFDate getStartTime()
      {
         JDFDate nMyDate = null;
         string str = JDFConstants.EMPTYSTRING;
         str = getAttribute(AttributeName.STARTTIME, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute SubmissionTime
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (11) set attribute SubmissionTime </summary>
      ///          * <param name="value">: the value to set the attribute to or null </param>
      ///          
      public virtual void setSubmissionTime(JDFDate @value)
      {
         JDFDate date = @value;
         if (date == null)
            date = new JDFDate();
         setAttribute(AttributeName.SUBMISSIONTIME, date.DateTimeISO, null);
      }

      ///        
      ///          <summary> * (12) get JDFDate attribute SubmissionTime </summary>
      ///          * <returns> JDFDate the value of the attribute </returns>
      ///          
      public virtual JDFDate getSubmissionTime()
      {
         JDFDate nMyDate = null;
         string str = JDFConstants.EMPTYSTRING;
         str = getAttribute(AttributeName.SUBMISSIONTIME, null, JDFConstants.EMPTYSTRING);
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

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element JobPhase </summary>
      ///     * <returns> JDFJobPhase the element </returns>
      ///     
      public virtual JDFJobPhase getJobPhase()
      {
         return (JDFJobPhase)getElement(ElementName.JOBPHASE, null, 0);
      }

      ///     <summary> (25) getCreateJobPhase
      ///     *  </summary>
      ///     * <returns> JDFJobPhase the element </returns>
      ///     
      public virtual JDFJobPhase getCreateJobPhase()
      {
         return (JDFJobPhase)getCreateElement_KElement(ElementName.JOBPHASE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element JobPhase </summary>
      ///     
      public virtual JDFJobPhase appendJobPhase()
      {
         return (JDFJobPhase)appendElementN(ElementName.JOBPHASE, 1, null);
      }

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

      ///     <summary> (26) getCreatePreview
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFPreview the element </returns>
      ///     
      public virtual JDFPreview getCreatePreview(int iSkip)
      {
         return (JDFPreview)getCreateElement_KElement(ElementName.PREVIEW, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Preview </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFPreview the element </returns>
      ///     * default is getPreview(0)     
      public virtual JDFPreview getPreview(int iSkip)
      {
         return (JDFPreview)getElement(ElementName.PREVIEW, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Preview from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFPreview> </returns>
      ///     
      public virtual ICollection<JDFPreview> getAllPreview()
      {
         List<JDFPreview> v = new List<JDFPreview>();

         JDFPreview kElem = (JDFPreview)getFirstChildElement(ElementName.PREVIEW, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFPreview)kElem.getNextSiblingElement(ElementName.PREVIEW, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Preview </summary>
      ///     
      public virtual JDFPreview appendPreview()
      {
         return (JDFPreview)appendElement(ElementName.PREVIEW, null);
      }
   }
}
