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
   using VString = org.cip4.jdflib.core.VString;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFAssembly = org.cip4.jdflib.resource.process.JDFAssembly;

   public abstract class JDFAutoCutMark : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[3];
      static JDFAutoCutMark()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.MARKTYPE, 0x22222222, AttributeInfo.EnumAttributeType.enumeration, EnumMarkType.getEnum(0), null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.POSITION, 0x22222222, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.BLOCKS, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.ASSEMBLY, 0x33333333);
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
      ///     <summary> * Constructor for JDFAutoCutMark </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoCutMark(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoCutMark </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoCutMark(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoCutMark </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoCutMark(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoCutMark[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for MarkType </summary>
      ///        

      public class EnumMarkType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumMarkType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumMarkType getEnum(string enumName)
         {
            return (EnumMarkType)getEnum(typeof(EnumMarkType), enumName);
         }

         public static EnumMarkType getEnum(int enumValue)
         {
            return (EnumMarkType)getEnum(typeof(EnumMarkType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumMarkType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumMarkType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumMarkType));
         }

         public static readonly EnumMarkType CrossCutMark = new EnumMarkType("CrossCutMark");
         public static readonly EnumMarkType TopVerticalCutMark = new EnumMarkType("TopVerticalCutMark");
         public static readonly EnumMarkType BottomVerticalCutMark = new EnumMarkType("BottomVerticalCutMark");
         public static readonly EnumMarkType LeftHorizontalCutMark = new EnumMarkType("LeftHorizontalCutMark");
         public static readonly EnumMarkType RightHorizontalCutMark = new EnumMarkType("RightHorizontalCutMark");
         public static readonly EnumMarkType LowerLeftCutMark = new EnumMarkType("LowerLeftCutMark");
         public static readonly EnumMarkType UpperLeftCutMark = new EnumMarkType("UpperLeftCutMark");
         public static readonly EnumMarkType LowerRightCutMark = new EnumMarkType("LowerRightCutMark");
         public static readonly EnumMarkType UpperRightCutMark = new EnumMarkType("UpperRightCutMark");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute MarkType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute MarkType </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setMarkType(EnumMarkType enumVar)
      {
         setAttribute(AttributeName.MARKTYPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute MarkType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumMarkType getMarkType()
      {
         return EnumMarkType.getEnum(getAttribute(AttributeName.MARKTYPE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Position
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Position </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPosition(JDFXYPair @value)
      {
         setAttribute(AttributeName.POSITION, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute Position </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getPosition()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.POSITION, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute Blocks
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Blocks </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBlocks(VString @value)
      {
         setAttribute(AttributeName.BLOCKS, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute Blocks </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getBlocks()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.BLOCKS, null, JDFConstants.EMPTYSTRING);
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateAssembly
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFAssembly the element </returns>
      ///     
      public virtual JDFAssembly getCreateAssembly(int iSkip)
      {
         return (JDFAssembly)getCreateElement_KElement(ElementName.ASSEMBLY, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Assembly </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFAssembly the element </returns>
      ///     * default is getAssembly(0)     
      public virtual JDFAssembly getAssembly(int iSkip)
      {
         return (JDFAssembly)getElement(ElementName.ASSEMBLY, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Assembly from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFAssembly> </returns>
      ///     
      public virtual ICollection<JDFAssembly> getAllAssembly()
      {
         List<JDFAssembly> v = new List<JDFAssembly>();

         JDFAssembly kElem = (JDFAssembly)getFirstChildElement(ElementName.ASSEMBLY, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFAssembly)kElem.getNextSiblingElement(ElementName.ASSEMBLY, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Assembly </summary>
      ///     
      public virtual JDFAssembly appendAssembly()
      {
         return (JDFAssembly)appendElement(ElementName.ASSEMBLY, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refAssembly(JDFAssembly refTarget)
      {
         refElement(refTarget);
      }
   }
}
