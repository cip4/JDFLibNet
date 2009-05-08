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
   using JDFCompany = org.cip4.jdflib.resource.process.JDFCompany;
   using JDFContact = org.cip4.jdflib.resource.process.JDFContact;
   using JDFDropItem = org.cip4.jdflib.resource.process.JDFDropItem;
   using JDFDate = org.cip4.jdflib.util.JDFDate;

   public abstract class JDFAutoDrop : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[7];
      static JDFAutoDrop()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.EARLIEST, 0x33333333, AttributeInfo.EnumAttributeType.dateTime, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.METHOD, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.PICKUP, 0x44444433, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.REQUIRED, 0x33333333, AttributeInfo.EnumAttributeType.dateTime, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.SERVICELEVEL, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.TRACKINGID, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.TRANSFER, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumTransfer.getEnum(0), null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.COMPANY, 0x77777776);
         elemInfoTable[1] = new ElemInfoTable(ElementName.CONTACT, 0x33333331);
         elemInfoTable[2] = new ElemInfoTable(ElementName.DROPITEM, 0x22222222);
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
      ///     <summary> * Constructor for JDFAutoDrop </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoDrop(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoDrop </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoDrop(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoDrop </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoDrop(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoDrop[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for Transfer </summary>
      ///        

      public class EnumTransfer : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumTransfer(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumTransfer getEnum(string enumName)
         {
            return (EnumTransfer)getEnum(typeof(EnumTransfer), enumName);
         }

         public static EnumTransfer getEnum(int enumValue)
         {
            return (EnumTransfer)getEnum(typeof(EnumTransfer), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumTransfer));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumTransfer));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumTransfer));
         }

         public static readonly EnumTransfer BuyerToPrinterDeliver = new EnumTransfer("BuyerToPrinterDeliver");
         public static readonly EnumTransfer BuyerToPrinterPickup = new EnumTransfer("BuyerToPrinterPickup");
         public static readonly EnumTransfer PrinterToBuyerDeliver = new EnumTransfer("PrinterToBuyerDeliver");
         public static readonly EnumTransfer PrinterToBuyerPickup = new EnumTransfer("PrinterToBuyerPickup");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute Earliest
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (11) set attribute Earliest </summary>
      ///          * <param name="value">: the value to set the attribute to or null </param>
      ///          
      public virtual void setEarliest(JDFDate @value)
      {
         JDFDate date = @value;
         if (date == null)
            date = new JDFDate();
         setAttribute(AttributeName.EARLIEST, date.DateTimeISO, null);
      }

      ///        
      ///          <summary> * (12) get JDFDate attribute Earliest </summary>
      ///          * <returns> JDFDate the value of the attribute </returns>
      ///          
      public virtual JDFDate getEarliest()
      {
         JDFDate nMyDate = null;
         string str = JDFConstants.EMPTYSTRING;
         str = getAttribute(AttributeName.EARLIEST, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute Method
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Method </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMethod(string @value)
      {
         setAttribute(AttributeName.METHOD, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Method </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getMethod()
      {
         return getAttribute(AttributeName.METHOD, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Pickup
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Pickup </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPickup(bool @value)
      {
         setAttribute(AttributeName.PICKUP, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute Pickup </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getPickup()
      {
         return getBoolAttribute(AttributeName.PICKUP, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Required
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (11) set attribute Required </summary>
      ///          * <param name="value">: the value to set the attribute to or null </param>
      ///          
      public virtual void setRequired(JDFDate @value)
      {
         JDFDate date = @value;
         if (date == null)
            date = new JDFDate();
         setAttribute(AttributeName.REQUIRED, date.DateTimeISO, null);
      }

      ///        
      ///          <summary> * (12) get JDFDate attribute Required </summary>
      ///          * <returns> JDFDate the value of the attribute </returns>
      ///          
      public virtual JDFDate getRequired()
      {
         JDFDate nMyDate = null;
         string str = JDFConstants.EMPTYSTRING;
         str = getAttribute(AttributeName.REQUIRED, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute ServiceLevel
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ServiceLevel </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setServiceLevel(string @value)
      {
         setAttribute(AttributeName.SERVICELEVEL, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ServiceLevel </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getServiceLevel()
      {
         return getAttribute(AttributeName.SERVICELEVEL, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TrackingID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TrackingID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTrackingID(string @value)
      {
         setAttribute(AttributeName.TRACKINGID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute TrackingID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getTrackingID()
      {
         return getAttribute(AttributeName.TRACKINGID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Transfer
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Transfer </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setTransfer(EnumTransfer enumVar)
      {
         setAttribute(AttributeName.TRANSFER, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Transfer </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumTransfer getTransfer()
      {
         return EnumTransfer.getEnum(getAttribute(AttributeName.TRANSFER, null, null));
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element Company </summary>
      ///     * <returns> JDFCompany the element </returns>
      ///     
      public virtual JDFCompany getCompany()
      {
         return (JDFCompany)getElement(ElementName.COMPANY, null, 0);
      }

      ///     <summary> (25) getCreateCompany
      ///     *  </summary>
      ///     * <returns> JDFCompany the element </returns>
      ///     
      public virtual JDFCompany getCreateCompany()
      {
         return (JDFCompany)getCreateElement_KElement(ElementName.COMPANY, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Company </summary>
      ///     
      public virtual JDFCompany appendCompany()
      {
         return (JDFCompany)appendElementN(ElementName.COMPANY, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refCompany(JDFCompany refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreateContact
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFContact the element </returns>
      ///     
      public virtual JDFContact getCreateContact(int iSkip)
      {
         return (JDFContact)getCreateElement_KElement(ElementName.CONTACT, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Contact </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFContact the element </returns>
      ///     * default is getContact(0)     
      public virtual JDFContact getContact(int iSkip)
      {
         return (JDFContact)getElement(ElementName.CONTACT, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Contact from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFContact> </returns>
      ///     
      public virtual ICollection<JDFContact> getAllContact()
      {
         List<JDFContact> v = new List<JDFContact>();

         JDFContact kElem = (JDFContact)getFirstChildElement(ElementName.CONTACT, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFContact)kElem.getNextSiblingElement(ElementName.CONTACT, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Contact </summary>
      ///     
      public virtual JDFContact appendContact()
      {
         return (JDFContact)appendElement(ElementName.CONTACT, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refContact(JDFContact refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreateDropItem
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFDropItem the element </returns>
      ///     
      public virtual JDFDropItem getCreateDropItem(int iSkip)
      {
         return (JDFDropItem)getCreateElement_KElement(ElementName.DROPITEM, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element DropItem </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFDropItem the element </returns>
      ///     * default is getDropItem(0)     
      public virtual JDFDropItem getDropItem(int iSkip)
      {
         return (JDFDropItem)getElement(ElementName.DROPITEM, null, iSkip);
      }

      ///    
      ///     <summary> * Get all DropItem from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFDropItem> </returns>
      ///     
      public virtual ICollection<JDFDropItem> getAllDropItem()
      {
         List<JDFDropItem> v = new List<JDFDropItem>();

         JDFDropItem kElem = (JDFDropItem)getFirstChildElement(ElementName.DROPITEM, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFDropItem)kElem.getNextSiblingElement(ElementName.DROPITEM, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element DropItem </summary>
      ///     
      public virtual JDFDropItem appendDropItem()
      {
         return (JDFDropItem)appendElement(ElementName.DROPITEM, null);
      }
   }
}
