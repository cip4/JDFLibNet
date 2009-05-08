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
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using VString = org.cip4.jdflib.core.VString;
   using JDFIntegerRangeList = org.cip4.jdflib.datatypes.JDFIntegerRangeList;
   using JDFDevCap = org.cip4.jdflib.resource.devicecapability.JDFDevCap;
   using JDFDeviceCap = org.cip4.jdflib.resource.devicecapability.JDFDeviceCap;
   using JDFLoc = org.cip4.jdflib.resource.devicecapability.JDFLoc;

   public abstract class JDFAutoDevCaps : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[14];
      static JDFAutoDevCaps()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.AVAILABILITY, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, JDFDeviceCap.EnumAvailability.getEnum(0), "Installed");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.CONTEXT, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumContext.getEnum(0), "Resource");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.DEVCAPREF, 0x33333111, AttributeInfo.EnumAttributeType.IDREFS, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.DEVNS, 0x33333331, AttributeInfo.EnumAttributeType.URI, null, "http://www.CIP4.org/JDFSchema_1_1");
         atrInfoTable[4] = new AtrInfoTable(AttributeName.ID, 0x33333311, AttributeInfo.EnumAttributeType.ID, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.LINKUSAGE, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, JDFResourceLink.EnumUsage.getEnum(0), null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.MODULEREFS, 0x33333111, AttributeInfo.EnumAttributeType.IDREFS, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.NAME, 0x22222221, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.PROCESSUSAGE, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.REQUIRED, 0x33333311, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[10] = new AtrInfoTable(AttributeName.RESOURCEUPDATE, 0x44444331, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable[11] = new AtrInfoTable(AttributeName.RESOURCEUSAGE, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[12] = new AtrInfoTable(AttributeName.TYPEOCCURRENCENUM, 0x33333311, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable[13] = new AtrInfoTable(AttributeName.TYPES, 0x44444431, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.DEVCAP, 0x33333331);
         elemInfoTable[1] = new ElemInfoTable(ElementName.LOC, 0x33333311);
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
      ///     <summary> * Constructor for JDFAutoDevCaps </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoDevCaps(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoDevCaps </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoDevCaps(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoDevCaps </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoDevCaps(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoDevCaps[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for Context </summary>
      ///        

      public class EnumContext : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumContext(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumContext getEnum(string enumName)
         {
            return (EnumContext)getEnum(typeof(EnumContext), enumName);
         }

         public static EnumContext getEnum(int enumValue)
         {
            return (EnumContext)getEnum(typeof(EnumContext), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumContext));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumContext));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumContext));
         }

         public static readonly EnumContext Resource = new EnumContext("Resource");
         public static readonly EnumContext Link = new EnumContext("Link");
         public static readonly EnumContext JMF = new EnumContext("JMF");
         public static readonly EnumContext Element = new EnumContext("Element");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute Availability
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Availability </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setAvailability(JDFDeviceCap.EnumAvailability enumVar)
      {
         setAttribute(AttributeName.AVAILABILITY, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Availability </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual JDFDeviceCap.EnumAvailability getAvailability()
      {
         return JDFDeviceCap.EnumAvailability.getEnum(getAttribute(AttributeName.AVAILABILITY, null, "Installed"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Context
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Context </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setContext(EnumContext enumVar)
      {
         setAttribute(AttributeName.CONTEXT, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Context </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumContext getContext()
      {
         return EnumContext.getEnum(getAttribute(AttributeName.CONTEXT, null, "Resource"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute DevCapRef
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DevCapRef </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDevCapRef(VString @value)
      {
         setAttribute(AttributeName.DEVCAPREF, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute DevCapRef </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getDevCapRef()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.DEVCAPREF, null, JDFConstants.EMPTYSTRING);
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute DevNS
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DevNS </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDevNS(string @value)
      {
         setAttribute(AttributeName.DEVNS, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute DevNS </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getDevNS()
      {
         return getAttribute(AttributeName.DEVNS, null, "http://www.CIP4.org/JDFSchema_1_1");
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setID(string @value)
      {
         setAttribute(AttributeName.ID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public override string getID()
      {
         return getAttribute(AttributeName.ID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute LinkUsage
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute LinkUsage </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setLinkUsage(JDFResourceLink.EnumUsage enumVar)
      {
         setAttribute(AttributeName.LINKUSAGE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute LinkUsage </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual JDFResourceLink.EnumUsage getLinkUsage()
      {
         return JDFResourceLink.EnumUsage.getEnum(getAttribute(AttributeName.LINKUSAGE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ModuleRefs
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ModuleRefs </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setModuleRefs(VString @value)
      {
         setAttribute(AttributeName.MODULEREFS, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute ModuleRefs </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getModuleRefs()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.MODULEREFS, null, JDFConstants.EMPTYSTRING);
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Name
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Name </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setName(string @value)
      {
         setAttribute(AttributeName.NAME, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Name </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getName()
      {
         return getAttribute(AttributeName.NAME, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ProcessUsage
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ProcessUsage </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setProcessUsage(string @value)
      {
         setAttribute(AttributeName.PROCESSUSAGE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ProcessUsage </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getProcessUsage()
      {
         return getAttribute(AttributeName.PROCESSUSAGE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Required
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Required </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setRequired(bool @value)
      {
         setAttribute(AttributeName.REQUIRED, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute Required </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getRequired()
      {
         return getBoolAttribute(AttributeName.REQUIRED, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ResourceUpdate
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ResourceUpdate </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setResourceUpdate(VString @value)
      {
         setAttribute(AttributeName.RESOURCEUPDATE, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute ResourceUpdate </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getResourceUpdate()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.RESOURCEUPDATE, null, JDFConstants.EMPTYSTRING);
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ResourceUsage
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ResourceUsage </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setResourceUsage(string @value)
      {
         setAttribute(AttributeName.RESOURCEUSAGE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ResourceUsage </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getResourceUsage()
      {
         return getAttribute(AttributeName.RESOURCEUSAGE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TypeOccurrenceNum
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TypeOccurrenceNum </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTypeOccurrenceNum(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.TYPEOCCURRENCENUM, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerRangeList attribute TypeOccurrenceNum </summary>
      ///          * <returns> JDFIntegerRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerRangeList </returns>
      ///          
      public virtual JDFIntegerRangeList getTypeOccurrenceNum()
      {
         string strAttrName = "";
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.TYPEOCCURRENCENUM, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFIntegerRangeList(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Types
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Types </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTypes(VString @value)
      {
         setAttribute(AttributeName.TYPES, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute Types </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getTypes()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.TYPES, null, JDFConstants.EMPTYSTRING);
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateDevCap
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFDevCap the element </returns>
      ///     
      public virtual JDFDevCap getCreateDevCap(int iSkip)
      {
         return (JDFDevCap)getCreateElement_KElement(ElementName.DEVCAP, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element DevCap </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFDevCap the element </returns>
      ///     * default is getDevCap(0)     
      public virtual JDFDevCap getDevCap(int iSkip)
      {
         return (JDFDevCap)getElement(ElementName.DEVCAP, null, iSkip);
      }

      ///    
      ///     <summary> * Get all DevCap from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFDevCap> </returns>
      ///     
      public virtual ICollection<JDFDevCap> getAllDevCap()
      {
         List<JDFDevCap> v = new List<JDFDevCap>();

         JDFDevCap kElem = (JDFDevCap)getFirstChildElement(ElementName.DEVCAP, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFDevCap)kElem.getNextSiblingElement(ElementName.DEVCAP, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element DevCap </summary>
      ///     
      public virtual JDFDevCap appendDevCap()
      {
         return (JDFDevCap)appendElement(ElementName.DEVCAP, null);
      }

      ///     <summary> (26) getCreateLoc
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFLoc the element </returns>
      ///     
      public virtual JDFLoc getCreateLoc(int iSkip)
      {
         return (JDFLoc)getCreateElement_KElement(ElementName.LOC, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Loc </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFLoc the element </returns>
      ///     * default is getLoc(0)     
      public virtual JDFLoc getLoc(int iSkip)
      {
         return (JDFLoc)getElement(ElementName.LOC, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Loc from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFLoc> </returns>
      ///     
      public virtual ICollection<JDFLoc> getAllLoc()
      {
         List<JDFLoc> v = new List<JDFLoc>();

         JDFLoc kElem = (JDFLoc)getFirstChildElement(ElementName.LOC, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFLoc)kElem.getNextSiblingElement(ElementName.LOC, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Loc </summary>
      ///     
      public virtual JDFLoc appendLoc()
      {
         return (JDFLoc)appendElement(ElementName.LOC, null);
      }
   }
}
