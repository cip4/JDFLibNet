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
   using VString = org.cip4.jdflib.core.VString;
   using JDFActionPool = org.cip4.jdflib.resource.devicecapability.JDFActionPool;
   using JDFDevCapPool = org.cip4.jdflib.resource.devicecapability.JDFDevCapPool;
   using JDFDevCaps = org.cip4.jdflib.resource.devicecapability.JDFDevCaps;
   using JDFModulePool = org.cip4.jdflib.resource.devicecapability.JDFModulePool;
   using JDFTestPool = org.cip4.jdflib.resource.devicecapability.JDFTestPool;

   public abstract class JDFAutoMessageService : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[10];
      static JDFAutoMessageService()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ACKNOWLEDGE, 0x33333331, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.COMMAND, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.GENERICATTRIBUTES, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.JMFROLE, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumJMFRole.getEnum(0), null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.PERSISTENT, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[5] = new AtrInfoTable(AttributeName.QUERY, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[6] = new AtrInfoTable(AttributeName.REGISTRATION, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[7] = new AtrInfoTable(AttributeName.SIGNAL, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[8] = new AtrInfoTable(AttributeName.TYPE, 0x22222222, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.URLSCHEMES, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.ACTIONPOOL, 0x66666111);
         elemInfoTable[1] = new ElemInfoTable(ElementName.DEVCAPPOOL, 0x66666111);
         elemInfoTable[2] = new ElemInfoTable(ElementName.DEVCAPS, 0x33333331);
         elemInfoTable[3] = new ElemInfoTable(ElementName.MODULEPOOL, 0x66666111);
         elemInfoTable[4] = new ElemInfoTable(ElementName.TESTPOOL, 0x66666111);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[5];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoMessageService </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoMessageService(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoMessageService </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoMessageService(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoMessageService </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoMessageService(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoMessageService[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for JMFRole </summary>
      ///        

      public class EnumJMFRole : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumJMFRole(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumJMFRole getEnum(string enumName)
         {
            return (EnumJMFRole)getEnum(typeof(EnumJMFRole), enumName);
         }

         public static EnumJMFRole getEnum(int enumValue)
         {
            return (EnumJMFRole)getEnum(typeof(EnumJMFRole), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumJMFRole));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumJMFRole));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumJMFRole));
         }

         public static readonly EnumJMFRole Receiver = new EnumJMFRole("Receiver");
         public static readonly EnumJMFRole Sender = new EnumJMFRole("Sender");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute Acknowledge
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Acknowledge </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAcknowledge(bool @value)
      {
         setAttribute(AttributeName.ACKNOWLEDGE, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute Acknowledge </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getAcknowledge()
      {
         return getBoolAttribute(AttributeName.ACKNOWLEDGE, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Command
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Command </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCommand(bool @value)
      {
         setAttribute(AttributeName.COMMAND, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute Command </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getCommand()
      {
         return getBoolAttribute(AttributeName.COMMAND, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute GenericAttributes
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute GenericAttributes </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setGenericAttributes(VString @value)
      {
         setAttribute(AttributeName.GENERICATTRIBUTES, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute GenericAttributes </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getGenericAttributes()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.GENERICATTRIBUTES, null, JDFConstants.EMPTYSTRING);
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute JMFRole
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute JMFRole </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setJMFRole(EnumJMFRole enumVar)
      {
         setAttribute(AttributeName.JMFROLE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute JMFRole </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumJMFRole getJMFRole()
      {
         return EnumJMFRole.getEnum(getAttribute(AttributeName.JMFROLE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Persistent
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Persistent </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPersistent(bool @value)
      {
         setAttribute(AttributeName.PERSISTENT, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute Persistent </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getPersistent()
      {
         return getBoolAttribute(AttributeName.PERSISTENT, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Query
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Query </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setQuery(bool @value)
      {
         setAttribute(AttributeName.QUERY, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute Query </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getQuery()
      {
         return getBoolAttribute(AttributeName.QUERY, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Registration
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Registration </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setRegistration(bool @value)
      {
         setAttribute(AttributeName.REGISTRATION, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute Registration </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getRegistration()
      {
         return getBoolAttribute(AttributeName.REGISTRATION, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Signal
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Signal </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSignal(bool @value)
      {
         setAttribute(AttributeName.SIGNAL, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute Signal </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getSignal()
      {
         return getBoolAttribute(AttributeName.SIGNAL, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Type
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Type </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setType(string @value)
      {
         setAttribute(AttributeName.TYPE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Type </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getType()
      {
         return getAttribute(AttributeName.TYPE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute URLSchemes
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute URLSchemes </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setURLSchemes(VString @value)
      {
         setAttribute(AttributeName.URLSCHEMES, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute URLSchemes </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getURLSchemes()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.URLSCHEMES, null, JDFConstants.EMPTYSTRING);
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element ActionPool </summary>
      ///     * <returns> JDFActionPool the element </returns>
      ///     
      public virtual JDFActionPool getActionPool()
      {
         return (JDFActionPool)getElement(ElementName.ACTIONPOOL, null, 0);
      }

      ///     <summary> (25) getCreateActionPool
      ///     *  </summary>
      ///     * <returns> JDFActionPool the element </returns>
      ///     
      public virtual JDFActionPool getCreateActionPool()
      {
         return (JDFActionPool)getCreateElement_KElement(ElementName.ACTIONPOOL, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ActionPool </summary>
      ///     
      public virtual JDFActionPool appendActionPool()
      {
         return (JDFActionPool)appendElementN(ElementName.ACTIONPOOL, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element DevCapPool </summary>
      ///     * <returns> JDFDevCapPool the element </returns>
      ///     
      public virtual JDFDevCapPool getDevCapPool()
      {
         return (JDFDevCapPool)getElement(ElementName.DEVCAPPOOL, null, 0);
      }

      ///     <summary> (25) getCreateDevCapPool
      ///     *  </summary>
      ///     * <returns> JDFDevCapPool the element </returns>
      ///     
      public virtual JDFDevCapPool getCreateDevCapPool()
      {
         return (JDFDevCapPool)getCreateElement_KElement(ElementName.DEVCAPPOOL, null, 0);
      }

      ///    
      ///     <summary> * (29) append element DevCapPool </summary>
      ///     
      public virtual JDFDevCapPool appendDevCapPool()
      {
         return (JDFDevCapPool)appendElementN(ElementName.DEVCAPPOOL, 1, null);
      }

      ///     <summary> (26) getCreateDevCaps
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFDevCaps the element </returns>
      ///     
      public virtual JDFDevCaps getCreateDevCaps(int iSkip)
      {
         return (JDFDevCaps)getCreateElement_KElement(ElementName.DEVCAPS, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element DevCaps </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFDevCaps the element </returns>
      ///     * default is getDevCaps(0)     
      public virtual JDFDevCaps getDevCaps(int iSkip)
      {
         return (JDFDevCaps)getElement(ElementName.DEVCAPS, null, iSkip);
      }

      ///    
      ///     <summary> * Get all DevCaps from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFDevCaps> </returns>
      ///     
      public virtual ICollection<JDFDevCaps> getAllDevCaps()
      {
         List<JDFDevCaps> v = new List<JDFDevCaps>();

         JDFDevCaps kElem = (JDFDevCaps)getFirstChildElement(ElementName.DEVCAPS, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFDevCaps)kElem.getNextSiblingElement(ElementName.DEVCAPS, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element DevCaps </summary>
      ///     
      public virtual JDFDevCaps appendDevCaps()
      {
         return (JDFDevCaps)appendElement(ElementName.DEVCAPS, null);
      }

      ///    
      ///     <summary> * (24) const get element ModulePool </summary>
      ///     * <returns> JDFModulePool the element </returns>
      ///     
      public virtual JDFModulePool getModulePool()
      {
         return (JDFModulePool)getElement(ElementName.MODULEPOOL, null, 0);
      }

      ///     <summary> (25) getCreateModulePool
      ///     *  </summary>
      ///     * <returns> JDFModulePool the element </returns>
      ///     
      public virtual JDFModulePool getCreateModulePool()
      {
         return (JDFModulePool)getCreateElement_KElement(ElementName.MODULEPOOL, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ModulePool </summary>
      ///     
      public virtual JDFModulePool appendModulePool()
      {
         return (JDFModulePool)appendElementN(ElementName.MODULEPOOL, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element TestPool </summary>
      ///     * <returns> JDFTestPool the element </returns>
      ///     
      public virtual JDFTestPool getTestPool()
      {
         return (JDFTestPool)getElement(ElementName.TESTPOOL, null, 0);
      }

      ///     <summary> (25) getCreateTestPool
      ///     *  </summary>
      ///     * <returns> JDFTestPool the element </returns>
      ///     
      public virtual JDFTestPool getCreateTestPool()
      {
         return (JDFTestPool)getCreateElement_KElement(ElementName.TESTPOOL, null, 0);
      }

      ///    
      ///     <summary> * (29) append element TestPool </summary>
      ///     
      public virtual JDFTestPool appendTestPool()
      {
         return (JDFTestPool)appendElementN(ElementName.TESTPOOL, 1, null);
      }
   }
}
