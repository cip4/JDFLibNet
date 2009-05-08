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
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFMediaIntent = org.cip4.jdflib.resource.intent.JDFMediaIntent;
   using JDFIDPFinishing = org.cip4.jdflib.resource.process.JDFIDPFinishing;
   using JDFIDPLayout = org.cip4.jdflib.resource.process.JDFIDPLayout;
   using JDFMediaSource = org.cip4.jdflib.resource.process.JDFMediaSource;

   public abstract class JDFAutoIDPJobSheet : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[3];
      static JDFAutoIDPJobSheet()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.SHEETFORMAT, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, "Standard");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.SHEETOCCURENCE, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumSheetOccurence.getEnum(0), null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.SHEETTYPE, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumSheetType.getEnum(0), null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.IDPFINISHING, 0x33333333);
         elemInfoTable[1] = new ElemInfoTable(ElementName.IDPLAYOUT, 0x33333333);
         elemInfoTable[2] = new ElemInfoTable(ElementName.MEDIAINTENT, 0x33333333);
         elemInfoTable[3] = new ElemInfoTable(ElementName.MEDIASOURCE, 0x33333333);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[4];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoIDPJobSheet </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoIDPJobSheet(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoIDPJobSheet </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoIDPJobSheet(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoIDPJobSheet </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoIDPJobSheet(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoIDPJobSheet[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for SheetOccurence </summary>
      ///        

      public class EnumSheetOccurence : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumSheetOccurence(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumSheetOccurence getEnum(string enumName)
         {
            return (EnumSheetOccurence)getEnum(typeof(EnumSheetOccurence), enumName);
         }

         public static EnumSheetOccurence getEnum(int enumValue)
         {
            return (EnumSheetOccurence)getEnum(typeof(EnumSheetOccurence), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumSheetOccurence));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumSheetOccurence));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumSheetOccurence));
         }

         public static readonly EnumSheetOccurence Always = new EnumSheetOccurence("Always");
         public static readonly EnumSheetOccurence End = new EnumSheetOccurence("End");
         public static readonly EnumSheetOccurence OnError = new EnumSheetOccurence("OnError");
         public static readonly EnumSheetOccurence Slip = new EnumSheetOccurence("Slip");
         public static readonly EnumSheetOccurence Start = new EnumSheetOccurence("Start");
         public static readonly EnumSheetOccurence Both = new EnumSheetOccurence("Both");
         public static readonly EnumSheetOccurence None = new EnumSheetOccurence("None");
      }



      ///        
      ///        <summary> * Enumeration strings for SheetType </summary>
      ///        

      public class EnumSheetType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumSheetType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumSheetType getEnum(string enumName)
         {
            return (EnumSheetType)getEnum(typeof(EnumSheetType), enumName);
         }

         public static EnumSheetType getEnum(int enumValue)
         {
            return (EnumSheetType)getEnum(typeof(EnumSheetType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumSheetType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumSheetType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumSheetType));
         }

         public static readonly EnumSheetType AccountingSheet = new EnumSheetType("AccountingSheet");
         public static readonly EnumSheetType ErrorSheet = new EnumSheetType("ErrorSheet");
         public static readonly EnumSheetType JobSheet = new EnumSheetType("JobSheet");
         public static readonly EnumSheetType SeparatorSheet = new EnumSheetType("SeparatorSheet");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute SheetFormat
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SheetFormat </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSheetFormat(string @value)
      {
         setAttribute(AttributeName.SHEETFORMAT, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute SheetFormat </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getSheetFormat()
      {
         return getAttribute(AttributeName.SHEETFORMAT, null, "Standard");
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SheetOccurence
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute SheetOccurence </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setSheetOccurence(EnumSheetOccurence enumVar)
      {
         setAttribute(AttributeName.SHEETOCCURENCE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute SheetOccurence </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumSheetOccurence getSheetOccurence()
      {
         return EnumSheetOccurence.getEnum(getAttribute(AttributeName.SHEETOCCURENCE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SheetType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute SheetType </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setSheetType(EnumSheetType enumVar)
      {
         setAttribute(AttributeName.SHEETTYPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute SheetType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumSheetType getSheetType()
      {
         return EnumSheetType.getEnum(getAttribute(AttributeName.SHEETTYPE, null, null));
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateIDPFinishing
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFIDPFinishing the element </returns>
      ///     
      public virtual JDFIDPFinishing getCreateIDPFinishing(int iSkip)
      {
         return (JDFIDPFinishing)getCreateElement_KElement(ElementName.IDPFINISHING, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element IDPFinishing </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFIDPFinishing the element </returns>
      ///     * default is getIDPFinishing(0)     
      public virtual JDFIDPFinishing getIDPFinishing(int iSkip)
      {
         return (JDFIDPFinishing)getElement(ElementName.IDPFINISHING, null, iSkip);
      }

      ///    
      ///     <summary> * Get all IDPFinishing from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFIDPFinishing> </returns>
      ///     
      public virtual ICollection<JDFIDPFinishing> getAllIDPFinishing()
      {
         List<JDFIDPFinishing> v = new List<JDFIDPFinishing>();

         JDFIDPFinishing kElem = (JDFIDPFinishing)getFirstChildElement(ElementName.IDPFINISHING, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFIDPFinishing)kElem.getNextSiblingElement(ElementName.IDPFINISHING, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element IDPFinishing </summary>
      ///     
      public virtual JDFIDPFinishing appendIDPFinishing()
      {
         return (JDFIDPFinishing)appendElement(ElementName.IDPFINISHING, null);
      }

      ///     <summary> (26) getCreateIDPLayout
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFIDPLayout the element </returns>
      ///     
      public virtual JDFIDPLayout getCreateIDPLayout(int iSkip)
      {
         return (JDFIDPLayout)getCreateElement_KElement(ElementName.IDPLAYOUT, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element IDPLayout </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFIDPLayout the element </returns>
      ///     * default is getIDPLayout(0)     
      public virtual JDFIDPLayout getIDPLayout(int iSkip)
      {
         return (JDFIDPLayout)getElement(ElementName.IDPLAYOUT, null, iSkip);
      }

      ///    
      ///     <summary> * Get all IDPLayout from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFIDPLayout> </returns>
      ///     
      public virtual ICollection<JDFIDPLayout> getAllIDPLayout()
      {
         List<JDFIDPLayout> v = new List<JDFIDPLayout>();

         JDFIDPLayout kElem = (JDFIDPLayout)getFirstChildElement(ElementName.IDPLAYOUT, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFIDPLayout)kElem.getNextSiblingElement(ElementName.IDPLAYOUT, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element IDPLayout </summary>
      ///     
      public virtual JDFIDPLayout appendIDPLayout()
      {
         return (JDFIDPLayout)appendElement(ElementName.IDPLAYOUT, null);
      }

      ///     <summary> (26) getCreateMediaIntent
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFMediaIntent the element </returns>
      ///     
      public virtual JDFMediaIntent getCreateMediaIntent(int iSkip)
      {
         return (JDFMediaIntent)getCreateElement_KElement(ElementName.MEDIAINTENT, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element MediaIntent </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFMediaIntent the element </returns>
      ///     * default is getMediaIntent(0)     
      public virtual JDFMediaIntent getMediaIntent(int iSkip)
      {
         return (JDFMediaIntent)getElement(ElementName.MEDIAINTENT, null, iSkip);
      }

      ///    
      ///     <summary> * Get all MediaIntent from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFMediaIntent> </returns>
      ///     
      public virtual ICollection<JDFMediaIntent> getAllMediaIntent()
      {
         List<JDFMediaIntent> v = new List<JDFMediaIntent>();

         JDFMediaIntent kElem = (JDFMediaIntent)getFirstChildElement(ElementName.MEDIAINTENT, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFMediaIntent)kElem.getNextSiblingElement(ElementName.MEDIAINTENT, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element MediaIntent </summary>
      ///     
      public virtual JDFMediaIntent appendMediaIntent()
      {
         return (JDFMediaIntent)appendElement(ElementName.MEDIAINTENT, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refMediaIntent(JDFMediaIntent refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreateMediaSource
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFMediaSource the element </returns>
      ///     
      public virtual JDFMediaSource getCreateMediaSource(int iSkip)
      {
         return (JDFMediaSource)getCreateElement_KElement(ElementName.MEDIASOURCE, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element MediaSource </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFMediaSource the element </returns>
      ///     * default is getMediaSource(0)     
      public virtual JDFMediaSource getMediaSource(int iSkip)
      {
         return (JDFMediaSource)getElement(ElementName.MEDIASOURCE, null, iSkip);
      }

      ///    
      ///     <summary> * Get all MediaSource from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFMediaSource> </returns>
      ///     
      public virtual ICollection<JDFMediaSource> getAllMediaSource()
      {
         List<JDFMediaSource> v = new List<JDFMediaSource>();

         JDFMediaSource kElem = (JDFMediaSource)getFirstChildElement(ElementName.MEDIASOURCE, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFMediaSource)kElem.getNextSiblingElement(ElementName.MEDIASOURCE, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element MediaSource </summary>
      ///     
      public virtual JDFMediaSource appendMediaSource()
      {
         return (JDFMediaSource)appendElement(ElementName.MEDIASOURCE, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refMediaSource(JDFMediaSource refTarget)
      {
         refElement(refTarget);
      }
   }
}
