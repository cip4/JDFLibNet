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
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFIdentificationField = org.cip4.jdflib.resource.process.JDFIdentificationField;
   using JDFInsertSheet = org.cip4.jdflib.resource.process.JDFInsertSheet;

   public abstract class JDFAutoDisjointing : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[5];
      static JDFAutoDisjointing()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.NUMBER, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.OFFSET, 0x33333333, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.OFFSETAMOUNT, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.OFFSETDIRECTION, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumOffsetDirection.getEnum(0), null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.OVERFOLD, 0x44444443, AttributeInfo.EnumAttributeType.double_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.IDENTIFICATIONFIELD, 0x33333333);
         elemInfoTable[1] = new ElemInfoTable(ElementName.INSERTSHEET, 0x66666666);
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
      ///     <summary> * Constructor for JDFAutoDisjointing </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoDisjointing(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoDisjointing </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoDisjointing(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoDisjointing </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoDisjointing(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoDisjointing[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for OffsetDirection </summary>
      ///        

      public class EnumOffsetDirection : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumOffsetDirection(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumOffsetDirection getEnum(string enumName)
         {
            return (EnumOffsetDirection)getEnum(typeof(EnumOffsetDirection), enumName);
         }

         public static EnumOffsetDirection getEnum(int enumValue)
         {
            return (EnumOffsetDirection)getEnum(typeof(EnumOffsetDirection), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumOffsetDirection));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumOffsetDirection));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumOffsetDirection));
         }

         public static readonly EnumOffsetDirection Alternate = new EnumOffsetDirection("Alternate");
         public static readonly EnumOffsetDirection Left = new EnumOffsetDirection("Left");
         public static readonly EnumOffsetDirection None = new EnumOffsetDirection("None");
         public static readonly EnumOffsetDirection Right = new EnumOffsetDirection("Right");
         public static readonly EnumOffsetDirection Straight = new EnumOffsetDirection("Straight");
         public static readonly EnumOffsetDirection SystemSpecified = new EnumOffsetDirection("SystemSpecified");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute Number
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Number </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setNumber(int @value)
      {
         setAttribute(AttributeName.NUMBER, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute Number </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getNumber()
      {
         return getIntAttribute(AttributeName.NUMBER, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Offset
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Offset </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setOffset(JDFXYPair @value)
      {
         setAttribute(AttributeName.OFFSET, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute Offset </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getOffset()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.OFFSET, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFXYPair(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute OffsetAmount
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute OffsetAmount </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setOffsetAmount(int @value)
      {
         setAttribute(AttributeName.OFFSETAMOUNT, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute OffsetAmount </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getOffsetAmount()
      {
         return getIntAttribute(AttributeName.OFFSETAMOUNT, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute OffsetDirection
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute OffsetDirection </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setOffsetDirection(EnumOffsetDirection enumVar)
      {
         setAttribute(AttributeName.OFFSETDIRECTION, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute OffsetDirection </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumOffsetDirection getOffsetDirection()
      {
         return EnumOffsetDirection.getEnum(getAttribute(AttributeName.OFFSETDIRECTION, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Overfold
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Overfold </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setOverfold(double @value)
      {
         setAttribute(AttributeName.OVERFOLD, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute Overfold </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getOverfold()
      {
         return getRealAttribute(AttributeName.OVERFOLD, null, 0.0);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateIdentificationField
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFIdentificationField the element </returns>
      ///     
      public virtual JDFIdentificationField getCreateIdentificationField(int iSkip)
      {
         return (JDFIdentificationField)getCreateElement_KElement(ElementName.IDENTIFICATIONFIELD, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element IdentificationField </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFIdentificationField the element </returns>
      ///     * default is getIdentificationField(0)     
      public virtual JDFIdentificationField getIdentificationField(int iSkip)
      {
         return (JDFIdentificationField)getElement(ElementName.IDENTIFICATIONFIELD, null, iSkip);
      }

      ///    
      ///     <summary> * Get all IdentificationField from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFIdentificationField> </returns>
      ///     
      public virtual ICollection<JDFIdentificationField> getAllIdentificationField()
      {
         List<JDFIdentificationField> v = new List<JDFIdentificationField>();

         JDFIdentificationField kElem = (JDFIdentificationField)getFirstChildElement(ElementName.IDENTIFICATIONFIELD, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFIdentificationField)kElem.getNextSiblingElement(ElementName.IDENTIFICATIONFIELD, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element IdentificationField </summary>
      ///     
      public virtual JDFIdentificationField appendIdentificationField()
      {
         return (JDFIdentificationField)appendElement(ElementName.IDENTIFICATIONFIELD, null);
      }

      ///    
      ///     <summary> * (24) const get element InsertSheet </summary>
      ///     * <returns> JDFInsertSheet the element </returns>
      ///     
      public virtual JDFInsertSheet getInsertSheet()
      {
         return (JDFInsertSheet)getElement(ElementName.INSERTSHEET, null, 0);
      }

      ///     <summary> (25) getCreateInsertSheet
      ///     *  </summary>
      ///     * <returns> JDFInsertSheet the element </returns>
      ///     
      public virtual JDFInsertSheet getCreateInsertSheet()
      {
         return (JDFInsertSheet)getCreateElement_KElement(ElementName.INSERTSHEET, null, 0);
      }

      ///    
      ///     <summary> * (29) append element InsertSheet </summary>
      ///     
      public virtual JDFInsertSheet appendInsertSheet()
      {
         return (JDFInsertSheet)appendElementN(ElementName.INSERTSHEET, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refInsertSheet(JDFInsertSheet refTarget)
      {
         refElement(refTarget);
      }
   }
}
