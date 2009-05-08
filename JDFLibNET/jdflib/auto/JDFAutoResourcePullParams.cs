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
   using JDFPart = org.cip4.jdflib.resource.JDFPart;
   using JDFDisposition = org.cip4.jdflib.resource.process.JDFDisposition;
   using JDFMISDetails = org.cip4.jdflib.resource.process.JDFMISDetails;

   public abstract class JDFAutoResourcePullParams : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[11];
      static JDFAutoResourcePullParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.AMOUNT, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.HOLD, 0x33333311, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.NEXTQUEUEENTRYID, 0x33333311, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.PREVQUEUEENTRYID, 0x33333311, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.JOBID, 0x33333311, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.PRIORITY, 0x33333311, AttributeInfo.EnumAttributeType.integer, null, "1");
         atrInfoTable[6] = new AtrInfoTable(AttributeName.QUEUEENTRYID, 0x33333311, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.REPEATPOLICY, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumRepeatPolicy.getEnum(0), null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.RESOURCEID, 0x22222211, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.RETURNURL, 0x33333311, AttributeInfo.EnumAttributeType.URL, null, null);
         atrInfoTable[10] = new AtrInfoTable(AttributeName.WATCHURL, 0x33333311, AttributeInfo.EnumAttributeType.URL, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.PART, 0x33333311);
         elemInfoTable[1] = new ElemInfoTable(ElementName.DISPOSITION, 0x66666611);
         elemInfoTable[2] = new ElemInfoTable(ElementName.MISDETAILS, 0x66666611);
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
      ///     <summary> * Constructor for JDFAutoResourcePullParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoResourcePullParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoResourcePullParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoResourcePullParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoResourcePullParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoResourcePullParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoResourcePullParams[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for RepeatPolicy </summary>
      ///        

      public class EnumRepeatPolicy : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumRepeatPolicy(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumRepeatPolicy getEnum(string enumName)
         {
            return (EnumRepeatPolicy)getEnum(typeof(EnumRepeatPolicy), enumName);
         }

         public static EnumRepeatPolicy getEnum(int enumValue)
         {
            return (EnumRepeatPolicy)getEnum(typeof(EnumRepeatPolicy), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumRepeatPolicy));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumRepeatPolicy));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumRepeatPolicy));
         }

         public static readonly EnumRepeatPolicy Complete = new EnumRepeatPolicy("Complete");
         public static readonly EnumRepeatPolicy CompleteOnly = new EnumRepeatPolicy("CompleteOnly");
         public static readonly EnumRepeatPolicy Fast = new EnumRepeatPolicy("Fast");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute Amount
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Amount </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAmount(double @value)
      {
         setAttribute(AttributeName.AMOUNT, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute Amount </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getAmount()
      {
         return getRealAttribute(AttributeName.AMOUNT, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Hold
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Hold </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setHold(bool @value)
      {
         setAttribute(AttributeName.HOLD, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute Hold </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getHold()
      {
         return getBoolAttribute(AttributeName.HOLD, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute NextQueueEntryID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute NextQueueEntryID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setNextQueueEntryID(string @value)
      {
         setAttribute(AttributeName.NEXTQUEUEENTRYID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute NextQueueEntryID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getNextQueueEntryID()
      {
         return getAttribute(AttributeName.NEXTQUEUEENTRYID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PrevQueueEntryID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PrevQueueEntryID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPrevQueueEntryID(string @value)
      {
         setAttribute(AttributeName.PREVQUEUEENTRYID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute PrevQueueEntryID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getPrevQueueEntryID()
      {
         return getAttribute(AttributeName.PREVQUEUEENTRYID, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute RepeatPolicy
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute RepeatPolicy </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setRepeatPolicy(EnumRepeatPolicy enumVar)
      {
         setAttribute(AttributeName.REPEATPOLICY, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute RepeatPolicy </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumRepeatPolicy getRepeatPolicy()
      {
         return EnumRepeatPolicy.getEnum(getAttribute(AttributeName.REPEATPOLICY, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ResourceID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ResourceID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setResourceID(string @value)
      {
         setAttribute(AttributeName.RESOURCEID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ResourceID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getResourceID()
      {
         return getAttribute(AttributeName.RESOURCEID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ReturnURL
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ReturnURL </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setReturnURL(string @value)
      {
         setAttribute(AttributeName.RETURNURL, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ReturnURL </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getReturnURL()
      {
         return getAttribute(AttributeName.RETURNURL, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute WatchURL
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute WatchURL </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setWatchURL(string @value)
      {
         setAttribute(AttributeName.WATCHURL, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute WatchURL </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getWatchURL()
      {
         return getAttribute(AttributeName.WATCHURL, null, JDFConstants.EMPTYSTRING);
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

      ///    
      ///     <summary> * (24) const get element Disposition </summary>
      ///     * <returns> JDFDisposition the element </returns>
      ///     
      public virtual JDFDisposition getDisposition()
      {
         return (JDFDisposition)getElement(ElementName.DISPOSITION, null, 0);
      }

      ///     <summary> (25) getCreateDisposition
      ///     *  </summary>
      ///     * <returns> JDFDisposition the element </returns>
      ///     
      public virtual JDFDisposition getCreateDisposition()
      {
         return (JDFDisposition)getCreateElement_KElement(ElementName.DISPOSITION, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Disposition </summary>
      ///     
      public virtual JDFDisposition appendDisposition()
      {
         return (JDFDisposition)appendElementN(ElementName.DISPOSITION, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element MISDetails </summary>
      ///     * <returns> JDFMISDetails the element </returns>
      ///     
      public virtual JDFMISDetails getMISDetails()
      {
         return (JDFMISDetails)getElement(ElementName.MISDETAILS, null, 0);
      }

      ///     <summary> (25) getCreateMISDetails
      ///     *  </summary>
      ///     * <returns> JDFMISDetails the element </returns>
      ///     
      public virtual JDFMISDetails getCreateMISDetails()
      {
         return (JDFMISDetails)getCreateElement_KElement(ElementName.MISDETAILS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element MISDetails </summary>
      ///     
      public virtual JDFMISDetails appendMISDetails()
      {
         return (JDFMISDetails)appendElementN(ElementName.MISDETAILS, 1, null);
      }
   }
}
