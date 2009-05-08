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
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFFold = org.cip4.jdflib.resource.process.postpress.JDFFold;

   public abstract class JDFAutoFoldingParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[4];
      static JDFAutoFoldingParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.SHEETLAY, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumSheetLay.getEnum(0), "Left");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.DESCRIPTIONTYPE, 0x44444433, AttributeInfo.EnumAttributeType.enumeration, EnumDescriptionType.getEnum(0), null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.FOLDCATALOG, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.FOLDSHEETIN, 0x44444443, AttributeInfo.EnumAttributeType.XYPair, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.FOLD, 0x33333331);
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
      ///     <summary> * Constructor for JDFAutoFoldingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoFoldingParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoFoldingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoFoldingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoFoldingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoFoldingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoFoldingParams[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for SheetLay </summary>
      ///        

      public class EnumSheetLay : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumSheetLay(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumSheetLay getEnum(string enumName)
         {
            return (EnumSheetLay)getEnum(typeof(EnumSheetLay), enumName);
         }

         public static EnumSheetLay getEnum(int enumValue)
         {
            return (EnumSheetLay)getEnum(typeof(EnumSheetLay), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumSheetLay));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumSheetLay));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumSheetLay));
         }

         public static readonly EnumSheetLay Left = new EnumSheetLay("Left");
         public static readonly EnumSheetLay Right = new EnumSheetLay("Right");
      }



      ///        
      ///        <summary> * Enumeration strings for DescriptionType </summary>
      ///        

      public class EnumDescriptionType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumDescriptionType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumDescriptionType getEnum(string enumName)
         {
            return (EnumDescriptionType)getEnum(typeof(EnumDescriptionType), enumName);
         }

         public static EnumDescriptionType getEnum(int enumValue)
         {
            return (EnumDescriptionType)getEnum(typeof(EnumDescriptionType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumDescriptionType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumDescriptionType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumDescriptionType));
         }

         public static readonly EnumDescriptionType FoldProc = new EnumDescriptionType("FoldProc");
         public static readonly EnumDescriptionType FoldCatalog = new EnumDescriptionType("FoldCatalog");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute SheetLay
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute SheetLay </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setSheetLay(EnumSheetLay enumVar)
      {
         setAttribute(AttributeName.SHEETLAY, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute SheetLay </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumSheetLay getSheetLay()
      {
         return EnumSheetLay.getEnum(getAttribute(AttributeName.SHEETLAY, null, "Left"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute DescriptionType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute DescriptionType </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setDescriptionType(EnumDescriptionType enumVar)
      {
         setAttribute(AttributeName.DESCRIPTIONTYPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute DescriptionType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumDescriptionType getDescriptionType()
      {
         return EnumDescriptionType.getEnum(getAttribute(AttributeName.DESCRIPTIONTYPE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute FoldCatalog
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute FoldCatalog </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFoldCatalog(string @value)
      {
         setAttribute(AttributeName.FOLDCATALOG, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute FoldCatalog </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getFoldCatalog()
      {
         return getAttribute(AttributeName.FOLDCATALOG, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute FoldSheetIn
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute FoldSheetIn </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFoldSheetIn(JDFXYPair @value)
      {
         setAttribute(AttributeName.FOLDSHEETIN, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute FoldSheetIn </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getFoldSheetIn()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.FOLDSHEETIN, null, JDFConstants.EMPTYSTRING);
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

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateFold
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFFold the element </returns>
      ///     
      public virtual JDFFold getCreateFold(int iSkip)
      {
         return (JDFFold)getCreateElement_KElement(ElementName.FOLD, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Fold </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFFold the element </returns>
      ///     * default is getFold(0)     
      public virtual JDFFold getFold(int iSkip)
      {
         return (JDFFold)getElement(ElementName.FOLD, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Fold from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFFold> </returns>
      ///     
      public virtual ICollection<JDFFold> getAllFold()
      {
         List<JDFFold> v = new List<JDFFold>();

         JDFFold kElem = (JDFFold)getFirstChildElement(ElementName.FOLD, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFFold)kElem.getNextSiblingElement(ElementName.FOLD, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Fold </summary>
      ///     
      public virtual JDFFold appendFold()
      {
         return (JDFFold)appendElement(ElementName.FOLD, null);
      }
   }
}
