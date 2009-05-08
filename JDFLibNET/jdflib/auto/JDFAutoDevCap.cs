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
   using System.Collections.Generic;



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
   using JDFDeviceCap = org.cip4.jdflib.resource.devicecapability.JDFDeviceCap;
   using JDFLoc = org.cip4.jdflib.resource.devicecapability.JDFLoc;

   public abstract class JDFAutoDevCap : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[9];
      static JDFAutoDevCap()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.AVAILABILITY, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, JDFDeviceCap.EnumAvailability.getEnum(0), null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.DEVCAPREFS, 0x33333111, AttributeInfo.EnumAttributeType.IDREFS, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.DEVNS, 0x33333331, AttributeInfo.EnumAttributeType.URI, null, "http://www.CIP4.org/JDFSchema_1_1");
         atrInfoTable[3] = new AtrInfoTable(AttributeName.ID, 0x33333111, AttributeInfo.EnumAttributeType.ID, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.MAXOCCURS, 0x33333331, AttributeInfo.EnumAttributeType.integer, null, "1");
         atrInfoTable[5] = new AtrInfoTable(AttributeName.MINOCCURS, 0x33333331, AttributeInfo.EnumAttributeType.integer, null, "1");
         atrInfoTable[6] = new AtrInfoTable(AttributeName.MODULEREFS, 0x33333111, AttributeInfo.EnumAttributeType.IDREFS, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.NAME, 0x33333331, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.RESOURCEUSAGE, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.LOC, 0x33333311);
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
      ///     <summary> * Constructor for JDFAutoDevCap </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoDevCap(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoDevCap </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoDevCap(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoDevCap </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoDevCap(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoDevCap[  --> " + base.ToString() + " ]";
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
         return JDFDeviceCap.EnumAvailability.getEnum(getAttribute(AttributeName.AVAILABILITY, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute DevCapRefs
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DevCapRefs </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDevCapRefs(VString @value)
      {
         setAttribute(AttributeName.DEVCAPREFS, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute DevCapRefs </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getDevCapRefs()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.DEVCAPREFS, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute MaxOccurs
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MaxOccurs </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMaxOccurs(int @value)
      {
         setAttribute(AttributeName.MAXOCCURS, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute MaxOccurs </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getMaxOccurs()
      {
         return getIntAttribute(AttributeName.MAXOCCURS, null, 1);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MinOccurs
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MinOccurs </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMinOccurs(int @value)
      {
         setAttribute(AttributeName.MINOCCURS, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute MinOccurs </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getMinOccurs()
      {
         return getIntAttribute(AttributeName.MINOCCURS, null, 1);
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

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

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
