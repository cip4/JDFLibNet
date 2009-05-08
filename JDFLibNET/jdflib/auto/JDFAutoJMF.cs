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



namespace org.cip4.jdflib.auto
{
   using System;
   using System.Collections.Generic;



   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using VString = org.cip4.jdflib.core.VString;
   using JDFAcknowledge = org.cip4.jdflib.jmf.JDFAcknowledge;
   using JDFCommand = org.cip4.jdflib.jmf.JDFCommand;
   using JDFQuery = org.cip4.jdflib.jmf.JDFQuery;
   using JDFRegistration = org.cip4.jdflib.jmf.JDFRegistration;
   using JDFResponse = org.cip4.jdflib.jmf.JDFResponse;
   using JDFSignal = org.cip4.jdflib.jmf.JDFSignal;
   using JDFPool = org.cip4.jdflib.pool.JDFPool;
   using JDFDate = org.cip4.jdflib.util.JDFDate;

   public abstract class JDFAutoJMF : JDFPool
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[7];
      static JDFAutoJMF()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.DEVICEID, 0x33333333, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.ICSVERSIONS, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.MAXVERSION, 0x33333111, AttributeInfo.EnumAttributeType.JDFJMFVersion, EnumVersion.getEnum(0), null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.RESPONSEURL, 0x33333311, AttributeInfo.EnumAttributeType.URL, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.SENDERID, 0x22222222, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.TIMESTAMP, 0x22222222, AttributeInfo.EnumAttributeType.dateTime, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.VERSION, 0x22222222, AttributeInfo.EnumAttributeType.JDFJMFVersion, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.COMMAND, 0x33333333);
         elemInfoTable[1] = new ElemInfoTable(ElementName.ACKNOWLEDGE, 0x33333333);
         elemInfoTable[2] = new ElemInfoTable(ElementName.RESPONSE, 0x33333333);
         elemInfoTable[3] = new ElemInfoTable(ElementName.SIGNAL, 0x33333333);
         elemInfoTable[4] = new ElemInfoTable(ElementName.QUERY, 0x33333333);
         elemInfoTable[5] = new ElemInfoTable(ElementName.REGISTRATION, 0x33333333);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[6];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoJMF </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoJMF(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoJMF </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoJMF(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoJMF </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoJMF(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoJMF[  --> " + base.ToString() + " ]";
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
      //        Methods for Attribute ICSVersions
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ICSVersions </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setICSVersions(VString @value)
      {
         setAttribute(AttributeName.ICSVERSIONS, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute ICSVersions </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getICSVersions()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.ICSVERSIONS, null, JDFConstants.EMPTYSTRING);
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MaxVersion
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute MaxVersion </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setMaxVersion(EnumVersion enumVar)
      {
         setAttribute(AttributeName.MAXVERSION, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute MaxVersion </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumVersion getMaxVersion()
      {
         return EnumVersion.getEnum(getAttribute(AttributeName.MAXVERSION, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ResponseURL
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ResponseURL </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setResponseURL(string @value)
      {
         setAttribute(AttributeName.RESPONSEURL, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ResponseURL </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getResponseURL()
      {
         return getAttribute(AttributeName.RESPONSEURL, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SenderID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SenderID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSenderID(string @value)
      {
         setAttribute(AttributeName.SENDERID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute SenderID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getSenderID()
      {
         return getAttribute(AttributeName.SENDERID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TimeStamp
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (11) set attribute TimeStamp </summary>
      ///          * <param name="value">: the value to set the attribute to or null </param>
      ///          
      public virtual void setTimeStamp(JDFDate @value)
      {
         JDFDate date = @value;
         if (date == null)
            date = new JDFDate();
         setAttribute(AttributeName.TIMESTAMP, date.DateTimeISO, null);
      }

      ///        
      ///          <summary> * (12) get JDFDate attribute TimeStamp </summary>
      ///          * <returns> JDFDate the value of the attribute </returns>
      ///          
      public virtual JDFDate getTimeStamp()
      {
         JDFDate nMyDate = null;
         string str = JDFConstants.EMPTYSTRING;
         str = getAttribute(AttributeName.TIMESTAMP, null, JDFConstants.EMPTYSTRING);
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

      ///     <summary> (26) getCreateCommand
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFCommand the element </returns>
      ///     
      public virtual JDFCommand getCreateCommand(int iSkip)
      {
         return (JDFCommand)getCreateElement_KElement(ElementName.COMMAND, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Command </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFCommand the element </returns>
      ///     * default is getCommand(0)     
      public virtual JDFCommand getCommand(int iSkip)
      {
         return (JDFCommand)getElement(ElementName.COMMAND, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Command from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFCommand> </returns>
      ///     
      public virtual ICollection<JDFCommand> getAllCommand()
      {
         List<JDFCommand> v = new List<JDFCommand>();

         JDFCommand kElem = (JDFCommand)getFirstChildElement(ElementName.COMMAND, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFCommand)kElem.getNextSiblingElement(ElementName.COMMAND, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Command </summary>
      ///     
      public virtual JDFCommand appendCommand()
      {
         return (JDFCommand)appendElement(ElementName.COMMAND, null);
      }

      ///     <summary> (26) getCreateAcknowledge
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFAcknowledge the element </returns>
      ///     
      public virtual JDFAcknowledge getCreateAcknowledge(int iSkip)
      {
         return (JDFAcknowledge)getCreateElement_KElement(ElementName.ACKNOWLEDGE, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Acknowledge </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFAcknowledge the element </returns>
      ///     * default is getAcknowledge(0)     
      public virtual JDFAcknowledge getAcknowledge(int iSkip)
      {
         return (JDFAcknowledge)getElement(ElementName.ACKNOWLEDGE, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Acknowledge from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFAcknowledge> </returns>
      ///     
      public virtual ICollection<JDFAcknowledge> getAllAcknowledge()
      {
         List<JDFAcknowledge> v = new List<JDFAcknowledge>();

         JDFAcknowledge kElem = (JDFAcknowledge)getFirstChildElement(ElementName.ACKNOWLEDGE, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFAcknowledge)kElem.getNextSiblingElement(ElementName.ACKNOWLEDGE, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Acknowledge </summary>
      ///     
      public virtual JDFAcknowledge appendAcknowledge()
      {
         return (JDFAcknowledge)appendElement(ElementName.ACKNOWLEDGE, null);
      }

      ///     <summary> (26) getCreateResponse
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFResponse the element </returns>
      ///     
      public virtual JDFResponse getCreateResponse(int iSkip)
      {
         return (JDFResponse)getCreateElement_KElement(ElementName.RESPONSE, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Response </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFResponse the element </returns>
      ///     * default is getResponse(0)     
      public virtual JDFResponse getResponse(int iSkip)
      {
         return (JDFResponse)getElement(ElementName.RESPONSE, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Response from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFResponse> </returns>
      ///     
      public virtual ICollection<JDFResponse> getAllResponse()
      {
         List<JDFResponse> v = new List<JDFResponse>();

         JDFResponse kElem = (JDFResponse)getFirstChildElement(ElementName.RESPONSE, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFResponse)kElem.getNextSiblingElement(ElementName.RESPONSE, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Response </summary>
      ///     
      public virtual JDFResponse appendResponse()
      {
         return (JDFResponse)appendElement(ElementName.RESPONSE, null);
      }

      ///     <summary> (26) getCreateSignal
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFSignal the element </returns>
      ///     
      public virtual JDFSignal getCreateSignal(int iSkip)
      {
         return (JDFSignal)getCreateElement_KElement(ElementName.SIGNAL, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Signal </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFSignal the element </returns>
      ///     * default is getSignal(0)     
      public virtual JDFSignal getSignal(int iSkip)
      {
         return (JDFSignal)getElement(ElementName.SIGNAL, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Signal from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFSignal> </returns>
      ///     
      public virtual ICollection<JDFSignal> getAllSignal()
      {
         List<JDFSignal> v = new List<JDFSignal>();

         JDFSignal kElem = (JDFSignal)getFirstChildElement(ElementName.SIGNAL, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFSignal)kElem.getNextSiblingElement(ElementName.SIGNAL, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Signal </summary>
      ///     
      public virtual JDFSignal appendSignal()
      {
         return (JDFSignal)appendElement(ElementName.SIGNAL, null);
      }

      ///     <summary> (26) getCreateQuery
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFQuery the element </returns>
      ///     
      public virtual JDFQuery getCreateQuery(int iSkip)
      {
         return (JDFQuery)getCreateElement_KElement(ElementName.QUERY, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Query </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFQuery the element </returns>
      ///     * default is getQuery(0)     
      public virtual JDFQuery getQuery(int iSkip)
      {
         return (JDFQuery)getElement(ElementName.QUERY, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Query from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFQuery> </returns>
      ///     
      public virtual ICollection<JDFQuery> getAllQuery()
      {
         List<JDFQuery> v = new List<JDFQuery>();

         JDFQuery kElem = (JDFQuery)getFirstChildElement(ElementName.QUERY, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFQuery)kElem.getNextSiblingElement(ElementName.QUERY, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Query </summary>
      ///     
      public virtual JDFQuery appendQuery()
      {
         return (JDFQuery)appendElement(ElementName.QUERY, null);
      }

      ///     <summary> (26) getCreateRegistration
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFRegistration the element </returns>
      ///     
      public virtual JDFRegistration getCreateRegistration(int iSkip)
      {
         return (JDFRegistration)getCreateElement_KElement(ElementName.REGISTRATION, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Registration </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFRegistration the element </returns>
      ///     * default is getRegistration(0)     
      public virtual JDFRegistration getRegistration(int iSkip)
      {
         return (JDFRegistration)getElement(ElementName.REGISTRATION, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Registration from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFRegistration> </returns>
      ///     
      public virtual ICollection<JDFRegistration> getAllRegistration()
      {
         List<JDFRegistration> v = new List<JDFRegistration>();

         JDFRegistration kElem = (JDFRegistration)getFirstChildElement(ElementName.REGISTRATION, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFRegistration)kElem.getNextSiblingElement(ElementName.REGISTRATION, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Registration </summary>
      ///     
      public virtual JDFRegistration appendRegistration()
      {
         return (JDFRegistration)appendElement(ElementName.REGISTRATION, null);
      }
   }
}
