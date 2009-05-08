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
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFBundleItem = org.cip4.jdflib.resource.JDFBundleItem;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFContact = org.cip4.jdflib.resource.process.JDFContact;
   using JDFIdentificationField = org.cip4.jdflib.resource.process.JDFIdentificationField;

   public abstract class JDFAutoBundle : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[4];
      static JDFAutoBundle()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.BUNDLETYPE, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumBundleType.getEnum(0), "Stack");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.FOLIOCOUNT, 0x33333331, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.READERPAGECOUNT, 0x33333331, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.TOTALAMOUNT, 0x33333331, AttributeInfo.EnumAttributeType.integer, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.BUNDLEITEM, 0x33333331);
         elemInfoTable[1] = new ElemInfoTable(ElementName.CONTACT, 0x33333331);
         elemInfoTable[2] = new ElemInfoTable(ElementName.IDENTIFICATIONFIELD, 0x33333331);
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
      ///     <summary> * Constructor for JDFAutoBundle </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoBundle(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoBundle </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoBundle(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoBundle </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoBundle(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoBundle[  --> " + base.ToString() + " ]";
      }


      public override bool init()
      {
         bool bRet = base.init();
         setResourceClass(JDFResource.EnumResourceClass.Quantity);
         return bRet;
      }


      public override EnumResourceClass getValidClass()
      {
         return JDFResource.EnumResourceClass.Quantity;
      }


      ///        
      ///        <summary> * Enumeration strings for BundleType </summary>
      ///        

      public class EnumBundleType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumBundleType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumBundleType getEnum(string enumName)
         {
            return (EnumBundleType)getEnum(typeof(EnumBundleType), enumName);
         }

         public static EnumBundleType getEnum(int enumValue)
         {
            return (EnumBundleType)getEnum(typeof(EnumBundleType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumBundleType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumBundleType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumBundleType));
         }

         public static readonly EnumBundleType BoundSet = new EnumBundleType("BoundSet");
         public static readonly EnumBundleType Box = new EnumBundleType("Box");
         public static readonly EnumBundleType Carton = new EnumBundleType("Carton");
         public static readonly EnumBundleType CollectedStack = new EnumBundleType("CollectedStack");
         public static readonly EnumBundleType CompensatedStack = new EnumBundleType("CompensatedStack");
         public static readonly EnumBundleType Pallet = new EnumBundleType("Pallet");
         public static readonly EnumBundleType Roll = new EnumBundleType("Roll");
         public static readonly EnumBundleType Sheet = new EnumBundleType("Sheet");
         public static readonly EnumBundleType Stack = new EnumBundleType("Stack");
         public static readonly EnumBundleType StrappedStack = new EnumBundleType("StrappedStack");
         public static readonly EnumBundleType StrappedCompensatedStack = new EnumBundleType("StrappedCompensatedStack");
         public static readonly EnumBundleType WrappedBundle = new EnumBundleType("WrappedBundle");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute BundleType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute BundleType </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setBundleType(EnumBundleType enumVar)
      {
         setAttribute(AttributeName.BUNDLETYPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute BundleType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumBundleType getBundleType()
      {
         return EnumBundleType.getEnum(getAttribute(AttributeName.BUNDLETYPE, null, "Stack"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute FolioCount
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute FolioCount </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFolioCount(int @value)
      {
         setAttribute(AttributeName.FOLIOCOUNT, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute FolioCount </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getFolioCount()
      {
         return getIntAttribute(AttributeName.FOLIOCOUNT, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ReaderPageCount
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ReaderPageCount </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setReaderPageCount(int @value)
      {
         setAttribute(AttributeName.READERPAGECOUNT, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute ReaderPageCount </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getReaderPageCount()
      {
         return getIntAttribute(AttributeName.READERPAGECOUNT, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TotalAmount
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TotalAmount </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTotalAmount(int @value)
      {
         setAttribute(AttributeName.TOTALAMOUNT, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute TotalAmount </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getTotalAmount()
      {
         return getIntAttribute(AttributeName.TOTALAMOUNT, null, 0);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateBundleItem
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFBundleItem the element </returns>
      ///     
      public virtual JDFBundleItem getCreateBundleItem(int iSkip)
      {
         return (JDFBundleItem)getCreateElement_KElement(ElementName.BUNDLEITEM, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element BundleItem </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFBundleItem the element </returns>
      ///     * default is getBundleItem(0)     
      public virtual JDFBundleItem getBundleItem(int iSkip)
      {
         return (JDFBundleItem)getElement(ElementName.BUNDLEITEM, null, iSkip);
      }

      ///    
      ///     <summary> * Get all BundleItem from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFBundleItem> </returns>
      ///     
      public virtual ICollection<JDFBundleItem> getAllBundleItem()
      {
         List<JDFBundleItem> v = new List<JDFBundleItem>();

         JDFBundleItem kElem = (JDFBundleItem)getFirstChildElement(ElementName.BUNDLEITEM, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFBundleItem)kElem.getNextSiblingElement(ElementName.BUNDLEITEM, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element BundleItem </summary>
      ///     
      public virtual JDFBundleItem appendBundleItem()
      {
         return (JDFBundleItem)appendElement(ElementName.BUNDLEITEM, null);
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
      public override JDFContact appendContact()
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

      ///     <summary> (26) getCreateIdentificationField
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFIdentificationField the element </returns>
      ///     
      public override JDFIdentificationField getCreateIdentificationField(int iSkip)
      {
         return (JDFIdentificationField)getCreateElement_KElement(ElementName.IDENTIFICATIONFIELD, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element IdentificationField </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFIdentificationField the element </returns>
      ///     * default is getIdentificationField(0)     
      public override JDFIdentificationField getIdentificationField(int iSkip)
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
      public override JDFIdentificationField appendIdentificationField()
      {
         return (JDFIdentificationField)appendElement(ElementName.IDENTIFICATIONFIELD, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refIdentificationField(JDFIdentificationField refTarget)
      {
         refElement(refTarget);
      }
   }
}
