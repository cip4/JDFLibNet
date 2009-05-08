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
   using JDFLoc = org.cip4.jdflib.resource.devicecapability.JDFLoc;

   public abstract class JDFAutoValue : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[4];
      static JDFAutoValue()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ALLOWEDVALUE, 0x22222221, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.PRESENTVALUE, 0x44444431, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.VALUEUSAGE, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumValueUsage.getEnum(0), null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.VALUE, 0x22222222, AttributeInfo.EnumAttributeType.string_, null, null);
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
      ///     <summary> * Constructor for JDFAutoValue </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoValue(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoValue </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoValue(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoValue </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoValue(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoValue[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for ValueUsage </summary>
      ///        

      public class EnumValueUsage : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumValueUsage(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumValueUsage getEnum(string enumName)
         {
            return (EnumValueUsage)getEnum(typeof(EnumValueUsage), enumName);
         }

         public static EnumValueUsage getEnum(int enumValue)
         {
            return (EnumValueUsage)getEnum(typeof(EnumValueUsage), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumValueUsage));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumValueUsage));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumValueUsage));
         }

         public static readonly EnumValueUsage Present = new EnumValueUsage("Present");
         public static readonly EnumValueUsage Allowed = new EnumValueUsage("Allowed");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute AllowedValue
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute AllowedValue </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAllowedValue(string @value)
      {
         setAttribute(AttributeName.ALLOWEDVALUE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute AllowedValue </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getAllowedValue()
      {
         return getAttribute(AttributeName.ALLOWEDVALUE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PresentValue
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PresentValue </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPresentValue(string @value)
      {
         setAttribute(AttributeName.PRESENTVALUE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute PresentValue </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getPresentValue()
      {
         return getAttribute(AttributeName.PRESENTVALUE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ValueUsage
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute ValueUsage </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setValueUsage(EnumValueUsage enumVar)
      {
         setAttribute(AttributeName.VALUEUSAGE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute ValueUsage </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumValueUsage getValueUsage()
      {
         return EnumValueUsage.getEnum(getAttribute(AttributeName.VALUEUSAGE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Value
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Value </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setValue(string @value)
      {
         setAttribute(AttributeName.VALUE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Value </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getValue()
      {
         return getAttribute(AttributeName.VALUE, null, JDFConstants.EMPTYSTRING);
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
