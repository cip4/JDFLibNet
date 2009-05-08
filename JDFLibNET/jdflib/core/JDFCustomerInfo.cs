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
 * JDFCustomerInfo,cs
 *
 * Last changes
 *
 * 2002-07-02 JG added GetHRefs()
 */


namespace org.cip4.jdflib.core
{
   using System.Xml;

   using JDFAutoCustomerInfo = org.cip4.jdflib.auto.JDFAutoCustomerInfo;
   using EnumAttributeType = org.cip4.jdflib.core.AttributeInfo.EnumAttributeType;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using JDFResourcePool = org.cip4.jdflib.pool.JDFResourcePool;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFContact = org.cip4.jdflib.resource.process.JDFContact;
   using EnumContactType = org.cip4.jdflib.resource.process.JDFContact.EnumContactType;

   ///
   /// <summary> * Title: JDFCustomerInfo.cs Description: Copyright: Copyright (c) 2002 Company: Heidelberger Druckmaschinen
   /// * 
   /// * @author Dietrich Mucha
   /// * @version 1.0 </summary>
   /// 

   public class JDFCustomerInfo : JDFAutoCustomerInfo
   {
      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[6];
      static JDFCustomerInfo()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.BILLINGCODE, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.CUSTOMERID, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.CUSTOMERJOBNAME, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.CUSTOMERORDERID, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.CUSTOMERPROJECTID, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.RREFS, 0x44444433, AttributeInfo.EnumAttributeType.IDREFS, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.COMPANY, 0x44444446);
         elemInfoTable[1] = new ElemInfoTable(ElementName.CONTACT, 0x33333331);
         elemInfoTable[2] = new ElemInfoTable(ElementName.CUSTOMERMESSAGE, 0x33333311);
      }

      ///////
      // /

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

      ///////
      // /

      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[3];

      ///////
      // /
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
      ///	 <summary> * Constructor for JDFCustomerInfo
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFCustomerInfo(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFCustomerInfo
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFCustomerInfo(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFCustomerInfo
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFCustomerInfo(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      public override bool init()
      {
         XmlNode n = ParentNode;
         if ((n != null) && (n is JDFResourcePool))
         {
            base.init();
            setResStatus(EnumResStatus.Available, false);
            setPartUsage(JDFResource.EnumPartUsage.Implicit);
         }
         return true;
      }

      public override string ToString()
      {
         return "JDFCustomerInfo[  --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * Get the linked resources matching some conditions
      ///	 *  </summary>
      ///	 * <param name="mResAtt"> map of Resource attributes to search for </param>
      ///	 * <param name="bFollowRefs"> true if internal references shall be followed
      ///	 *  </param>
      ///	 * <returns> VResource - vector with all elements matching the conditions
      ///	 * 
      ///	 *         default: GetLinkedResources(new JDFAttributeMap(), false) </returns>
      ///	 
      public virtual VElement getLinkedResources(JDFAttributeMap mResAtt, bool bFollowRefs)
      {
         VElement v = getChildElementVector(null, null, null, true, 0, false);
         VElement vL = new VElement();

         for (int i = 0; i < v.Count; i++)
         {
            if ((v[i]) is JDFRefElement)
            {
               JDFRefElement l = (JDFRefElement)v[i];
               JDFResource r = l.getTarget();
               r = r == null ? null : r.getResourceRoot();

               if (r != null && r.includesAttributes(mResAtt, true))
               {
                  vL.Add(r);
                  if (bFollowRefs)
                  {
                     vL.appendUnique(r.getvHRefRes(bFollowRefs, true));
                  }
               }
            }
         }

         return vL;
      }

      ///   
      ///	 <summary> * get a Contact with at least one contacttype set
      ///	 *  </summary>
      ///	 * <param name="contactType"> the contatcttype string </param>
      ///	 * <param name="iSkip"> number of occurrences to skip - if 0 take the first </param>
      ///	 * <returns> a matching JDFContact, null if none are found </returns>
      ///	 
      public virtual JDFContact getContactWithContactType(string contactType, int iSkip)
      {
         return (JDFContact)getChildWithMatchingAttribute(ElementName.CONTACT, AttributeName.CONTACTTYPES, null, contactType, iSkip, true, EnumAttributeType.NMTOKENS);
      }

      ///   
      ///	 <summary> * get a list of contacts with at least one contacttype set
      ///	 *  </summary>
      ///	 * <param name="contactType"> the contatcttype to look for </param>
      ///	 * <returns> VElement the vector of matching JDFContacts, null if none are found </returns>
      ///	 
      public virtual VElement getContactVectorWithContactType(string contactType)
      {
         VElement v = getChildElementVector(ElementName.CONTACT, null, null, true, 0, true);
         VElement v2 = new VElement();
         int siz = v.Count;
         for (int i = 0; i < siz; i++)
         {
            JDFContact contact = (JDFContact)v[i];
            VString contactTypes = contact.getContactTypes();
            if (contactTypes.Contains(contactType))
            {
               v2.Add(contact);
            }
         }
         return v2.Count > 0 ? v2 : null;
      }


      ///   
      ///	 <summary> * Mother of all version fixing routines
      ///	 * 
      ///	 * uses heuristics to modify this element and its children to be compatible with a given version in general, it will
      ///	 * be able to move from low to high versions but potentially fail when attempting to move from higher to lower
      ///	 * versions
      ///	 *  </summary>
      ///	 * <param name="version"> version that the resulting element should correspond to </param>
      ///	 * <returns> true if successful </returns>
      ///	 
      public override bool fixVersion(EnumVersion version)
      {
         if (hasAttribute(AttributeName.RREFS))
            removeAttribute(AttributeName.RREFS);
         return base.fixVersion(version);
      }


      ///   
      ///	 <summary> * add a contact with a given contacttype
      ///	 *  </summary>
      ///	 * <param name="typ"> </param>
      ///	 
      public virtual JDFContact appendContact(EnumContactType typ)
      {
         JDFContact c = appendContact();
         c.setContactTypes(typ);
         return c;

      }
   }
}
