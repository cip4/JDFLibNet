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
   using JDFException = org.cip4.jdflib.core.JDFException;
   using VString = org.cip4.jdflib.core.VString;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFLayout = org.cip4.jdflib.resource.process.JDFLayout;
   using JDFRunList = org.cip4.jdflib.resource.process.JDFRunList;
   using JDFSheet = org.cip4.jdflib.resource.process.postpress.JDFSheet;

   public abstract class JDFAutoInsertSheet : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[7];
      static JDFAutoInsertSheet()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.SHEETTYPE, 0x22222221, AttributeInfo.EnumAttributeType.enumeration, EnumSheetType.getEnum(0), null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.SHEETUSAGE, 0x22222221, AttributeInfo.EnumAttributeType.enumeration, EnumSheetUsage.getEnum(0), null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.INCLUDEINBUNDLEITEM, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumIncludeInBundleItem.getEnum(0), null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.ISWASTE, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.MARKLIST, 0x33333331, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.SHEETFORMAT, 0x33333331, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.USAGE, 0x44444443, AttributeInfo.EnumAttributeType.enumeration, EnumSheetUsage.getEnum(0), null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.RUNLIST, 0x66666666);
         elemInfoTable[1] = new ElemInfoTable(ElementName.LAYOUT, 0x66666111);
         elemInfoTable[2] = new ElemInfoTable(ElementName.SHEET, 0x77777666);
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
      ///     <summary> * Constructor for JDFAutoInsertSheet </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoInsertSheet(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoInsertSheet </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoInsertSheet(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoInsertSheet </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoInsertSheet(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoInsertSheet[  --> " + base.ToString() + " ]";
      }


      public override bool init()
      {
         bool bRet = base.init();
         setResourceClass(JDFResource.EnumResourceClass.Parameter);
         return bRet;
      }


      public override EnumResourceClass getValidClass()
      {
         return JDFResource.EnumResourceClass.Parameter;
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
         public static readonly EnumSheetType FillSheet = new EnumSheetType("FillSheet");
         public static readonly EnumSheetType InsertSheet = new EnumSheetType("InsertSheet");
         public static readonly EnumSheetType JobSheet = new EnumSheetType("JobSheet");
         public static readonly EnumSheetType SeparatorSheet = new EnumSheetType("SeparatorSheet");
      }



      ///        
      ///        <summary> * Enumeration strings for SheetUsage </summary>
      ///        

      public class EnumSheetUsage : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumSheetUsage(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumSheetUsage getEnum(string enumName)
         {
            return (EnumSheetUsage)getEnum(typeof(EnumSheetUsage), enumName);
         }

         public static EnumSheetUsage getEnum(int enumValue)
         {
            return (EnumSheetUsage)getEnum(typeof(EnumSheetUsage), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumSheetUsage));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumSheetUsage));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumSheetUsage));
         }

         public static readonly EnumSheetUsage FillForceBack = new EnumSheetUsage("FillForceBack");
         public static readonly EnumSheetUsage FillForceFront = new EnumSheetUsage("FillForceFront");
         public static readonly EnumSheetUsage FillSheet = new EnumSheetUsage("FillSheet");
         public static readonly EnumSheetUsage FillSignature = new EnumSheetUsage("FillSignature");
         public static readonly EnumSheetUsage FillSurface = new EnumSheetUsage("FillSurface");
         public static readonly EnumSheetUsage Header = new EnumSheetUsage("Header");
         public static readonly EnumSheetUsage Interleaved = new EnumSheetUsage("Interleaved");
         public static readonly EnumSheetUsage InterleavedBefore = new EnumSheetUsage("InterleavedBefore");
         public static readonly EnumSheetUsage OnError = new EnumSheetUsage("OnError");
         public static readonly EnumSheetUsage Slip = new EnumSheetUsage("Slip");
         public static readonly EnumSheetUsage SlipCopy = new EnumSheetUsage("SlipCopy");
         public static readonly EnumSheetUsage Trailer = new EnumSheetUsage("Trailer");
      }



      ///        
      ///        <summary> * Enumeration strings for IncludeInBundleItem </summary>
      ///        

      public class EnumIncludeInBundleItem : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumIncludeInBundleItem(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumIncludeInBundleItem getEnum(string enumName)
         {
            return (EnumIncludeInBundleItem)getEnum(typeof(EnumIncludeInBundleItem), enumName);
         }

         public static EnumIncludeInBundleItem getEnum(int enumValue)
         {
            return (EnumIncludeInBundleItem)getEnum(typeof(EnumIncludeInBundleItem), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumIncludeInBundleItem));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumIncludeInBundleItem));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumIncludeInBundleItem));
         }

         public static readonly EnumIncludeInBundleItem After = new EnumIncludeInBundleItem("After");
         public static readonly EnumIncludeInBundleItem Before = new EnumIncludeInBundleItem("Before");
         public static readonly EnumIncludeInBundleItem None = new EnumIncludeInBundleItem("None");
         public static readonly EnumIncludeInBundleItem New = new EnumIncludeInBundleItem("New");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

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


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SheetUsage
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute SheetUsage </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setSheetUsage(EnumSheetUsage enumVar)
      {
         setAttribute(AttributeName.SHEETUSAGE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute SheetUsage </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumSheetUsage getSheetUsage()
      {
         return EnumSheetUsage.getEnum(getAttribute(AttributeName.SHEETUSAGE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute IncludeInBundleItem
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute IncludeInBundleItem </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setIncludeInBundleItem(EnumIncludeInBundleItem enumVar)
      {
         setAttribute(AttributeName.INCLUDEINBUNDLEITEM, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute IncludeInBundleItem </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumIncludeInBundleItem getIncludeInBundleItem()
      {
         return EnumIncludeInBundleItem.getEnum(getAttribute(AttributeName.INCLUDEINBUNDLEITEM, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute IsWaste
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute IsWaste </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setIsWaste(bool @value)
      {
         setAttribute(AttributeName.ISWASTE, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute IsWaste </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getIsWaste()
      {
         return getBoolAttribute(AttributeName.ISWASTE, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MarkList
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MarkList </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMarkList(VString @value)
      {
         setAttribute(AttributeName.MARKLIST, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute MarkList </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getMarkList()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.MARKLIST, null, JDFConstants.EMPTYSTRING);
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
      }


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
         return getAttribute(AttributeName.SHEETFORMAT, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Usage
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Usage </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setUsage(EnumSheetUsage enumVar)
      {
         setAttribute(AttributeName.USAGE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Usage </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumSheetUsage getUsage()
      {
         return EnumSheetUsage.getEnum(getAttribute(AttributeName.USAGE, null, null));
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element RunList </summary>
      ///     * <returns> JDFRunList the element </returns>
      ///     
      public virtual JDFRunList getRunList()
      {
         return (JDFRunList)getElement(ElementName.RUNLIST, null, 0);
      }

      ///     <summary> (25) getCreateRunList
      ///     *  </summary>
      ///     * <returns> JDFRunList the element </returns>
      ///     
      public virtual JDFRunList getCreateRunList()
      {
         return (JDFRunList)getCreateElement_KElement(ElementName.RUNLIST, null, 0);
      }

      ///    
      ///     <summary> * (29) append element RunList </summary>
      ///     
      public virtual JDFRunList appendRunList()
      {
         return (JDFRunList)appendElementN(ElementName.RUNLIST, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refRunList(JDFRunList refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element Layout </summary>
      ///     * <returns> JDFLayout the element </returns>
      ///     
      public virtual JDFLayout getLayout()
      {
         return (JDFLayout)getElement(ElementName.LAYOUT, null, 0);
      }

      ///     <summary> (25) getCreateLayout
      ///     *  </summary>
      ///     * <returns> JDFLayout the element </returns>
      ///     
      public virtual JDFLayout getCreateLayout()
      {
         return (JDFLayout)getCreateElement_KElement(ElementName.LAYOUT, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Layout </summary>
      ///     
      public virtual JDFLayout appendLayout()
      {
         return (JDFLayout)appendElementN(ElementName.LAYOUT, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refLayout(JDFLayout refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element Sheet </summary>
      ///     * <returns> JDFSheet the element </returns>
      ///     
      public virtual JDFSheet getSheet()
      {
         return (JDFSheet)getElement(ElementName.SHEET, null, 0);
      }

      ///     <summary> (25) getCreateSheet
      ///     *  </summary>
      ///     * <returns> JDFSheet the element </returns>
      ///     
      public virtual JDFSheet getCreateSheet()
      {
         return (JDFSheet)getCreateElement_KElement(ElementName.SHEET, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Sheet </summary>
      ///     
      public virtual JDFSheet appendSheet()
      {
         return (JDFSheet)appendElementN(ElementName.SHEET, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refSheet(JDFSheet refTarget)
      {
         refElement(refTarget);
      }
   }
}
