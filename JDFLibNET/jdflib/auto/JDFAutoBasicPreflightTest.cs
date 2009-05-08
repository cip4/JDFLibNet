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
   using JDFPreflightArgument = org.cip4.jdflib.resource.process.JDFPreflightArgument;

   public abstract class JDFAutoBasicPreflightTest : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[5];
      static JDFAutoBasicPreflightTest()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.DEVNS, 0x33333333, AttributeInfo.EnumAttributeType.URI, null, "http://www.CIP4.org/JDFSchema_1_1");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.LISTTYPE, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumListType.getEnum(0), null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.MAXOCCURS, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, "1");
         atrInfoTable[3] = new AtrInfoTable(AttributeName.MINOCCURS, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, "1");
         atrInfoTable[4] = new AtrInfoTable(AttributeName.NAME, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.PREFLIGHTARGUMENT, 0x66666666);
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
      ///     <summary> * Constructor for JDFAutoBasicPreflightTest </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoBasicPreflightTest(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoBasicPreflightTest </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoBasicPreflightTest(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoBasicPreflightTest </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoBasicPreflightTest(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoBasicPreflightTest[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for ListType </summary>
      ///        

      public class EnumListType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumListType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumListType getEnum(string enumName)
         {
            return (EnumListType)getEnum(typeof(EnumListType), enumName);
         }

         public static EnumListType getEnum(int enumValue)
         {
            return (EnumListType)getEnum(typeof(EnumListType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumListType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumListType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumListType));
         }

         public static readonly EnumListType CompleteList = new EnumListType("CompleteList");
         public static readonly EnumListType CompleteOrderedList = new EnumListType("CompleteOrderedList");
         public static readonly EnumListType ContainedList = new EnumListType("ContainedList");
         public static readonly EnumListType List = new EnumListType("List");
         public static readonly EnumListType OrderedList = new EnumListType("OrderedList");
         public static readonly EnumListType OrderedRangeList = new EnumListType("OrderedRangeList");
         public static readonly EnumListType Range = new EnumListType("Range");
         public static readonly EnumListType RangeList = new EnumListType("RangeList");
         public static readonly EnumListType SingleValue = new EnumListType("SingleValue");
         public static readonly EnumListType Span = new EnumListType("Span");
         public static readonly EnumListType UniqueList = new EnumListType("UniqueList");
         public static readonly EnumListType UniqueRangeList = new EnumListType("UniqueRangeList");
         public static readonly EnumListType UniqueOrderedList = new EnumListType("UniqueOrderedList");
         public static readonly EnumListType UniqueOrderedRangeList = new EnumListType("UniqueOrderedRangeList");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

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
      //        Methods for Attribute ListType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute ListType </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setListType(EnumListType enumVar)
      {
         setAttribute(AttributeName.LISTTYPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute ListType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumListType getListType()
      {
         return EnumListType.getEnum(getAttribute(AttributeName.LISTTYPE, null, null));
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

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element PreflightArgument </summary>
      ///     * <returns> JDFPreflightArgument the element </returns>
      ///     
      public virtual JDFPreflightArgument getPreflightArgument()
      {
         return (JDFPreflightArgument)getElement(ElementName.PREFLIGHTARGUMENT, null, 0);
      }

      ///     <summary> (25) getCreatePreflightArgument
      ///     *  </summary>
      ///     * <returns> JDFPreflightArgument the element </returns>
      ///     
      public virtual JDFPreflightArgument getCreatePreflightArgument()
      {
         return (JDFPreflightArgument)getCreateElement_KElement(ElementName.PREFLIGHTARGUMENT, null, 0);
      }

      ///    
      ///     <summary> * (29) append element PreflightArgument </summary>
      ///     
      public virtual JDFPreflightArgument appendPreflightArgument()
      {
         return (JDFPreflightArgument)appendElementN(ElementName.PREFLIGHTARGUMENT, 1, null);
      }
   }
}
