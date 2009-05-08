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
   using JDFGlueLine = org.cip4.jdflib.resource.process.postpress.JDFGlueLine;

   public abstract class JDFAutoInsertingParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[4];
      static JDFAutoInsertingParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.INSERTLOCATION, 0x22222222, AttributeInfo.EnumAttributeType.enumeration, EnumInsertLocation.getEnum(0), null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.METHOD, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumMethod.getEnum(0), "BlowIn");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.SHEETOFFSET, 0x44444443, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.FINISHEDPAGE, 0x33333311, AttributeInfo.EnumAttributeType.integer, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.GLUELINE, 0x33333333);
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
      ///     <summary> * Constructor for JDFAutoInsertingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoInsertingParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoInsertingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoInsertingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoInsertingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoInsertingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoInsertingParams[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for InsertLocation </summary>
      ///        

      public class EnumInsertLocation : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumInsertLocation(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumInsertLocation getEnum(string enumName)
         {
            return (EnumInsertLocation)getEnum(typeof(EnumInsertLocation), enumName);
         }

         public static EnumInsertLocation getEnum(int enumValue)
         {
            return (EnumInsertLocation)getEnum(typeof(EnumInsertLocation), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumInsertLocation));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumInsertLocation));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumInsertLocation));
         }

         public static readonly EnumInsertLocation Front = new EnumInsertLocation("Front");
         public static readonly EnumInsertLocation Back = new EnumInsertLocation("Back");
         public static readonly EnumInsertLocation OverfoldLeft = new EnumInsertLocation("OverfoldLeft");
         public static readonly EnumInsertLocation OverfoldRight = new EnumInsertLocation("OverfoldRight");
         public static readonly EnumInsertLocation Overfold = new EnumInsertLocation("Overfold");
         public static readonly EnumInsertLocation FinishedPage = new EnumInsertLocation("FinishedPage");
      }



      ///        
      ///        <summary> * Enumeration strings for Method </summary>
      ///        

      public class EnumMethod : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumMethod(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumMethod getEnum(string enumName)
         {
            return (EnumMethod)getEnum(typeof(EnumMethod), enumName);
         }

         public static EnumMethod getEnum(int enumValue)
         {
            return (EnumMethod)getEnum(typeof(EnumMethod), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumMethod));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumMethod));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumMethod));
         }

         public static readonly EnumMethod BlowIn = new EnumMethod("BlowIn");
         public static readonly EnumMethod BindIn = new EnumMethod("BindIn");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute InsertLocation
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute InsertLocation </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setInsertLocation(EnumInsertLocation enumVar)
      {
         setAttribute(AttributeName.INSERTLOCATION, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute InsertLocation </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumInsertLocation getInsertLocation()
      {
         return EnumInsertLocation.getEnum(getAttribute(AttributeName.INSERTLOCATION, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Method
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Method </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setMethod(EnumMethod enumVar)
      {
         setAttribute(AttributeName.METHOD, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Method </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumMethod getMethod()
      {
         return EnumMethod.getEnum(getAttribute(AttributeName.METHOD, null, "BlowIn"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SheetOffset
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SheetOffset </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSheetOffset(JDFXYPair @value)
      {
         setAttribute(AttributeName.SHEETOFFSET, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute SheetOffset </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getSheetOffset()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.SHEETOFFSET, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute FinishedPage
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute FinishedPage </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFinishedPage(int @value)
      {
         setAttribute(AttributeName.FINISHEDPAGE, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute FinishedPage </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getFinishedPage()
      {
         return getIntAttribute(AttributeName.FINISHEDPAGE, null, 0);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateGlueLine
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFGlueLine the element </returns>
      ///     
      public virtual JDFGlueLine getCreateGlueLine(int iSkip)
      {
         return (JDFGlueLine)getCreateElement_KElement(ElementName.GLUELINE, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element GlueLine </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFGlueLine the element </returns>
      ///     * default is getGlueLine(0)     
      public virtual JDFGlueLine getGlueLine(int iSkip)
      {
         return (JDFGlueLine)getElement(ElementName.GLUELINE, null, iSkip);
      }

      ///    
      ///     <summary> * Get all GlueLine from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFGlueLine> </returns>
      ///     
      public virtual ICollection<JDFGlueLine> getAllGlueLine()
      {
         List<JDFGlueLine> v = new List<JDFGlueLine>();

         JDFGlueLine kElem = (JDFGlueLine)getFirstChildElement(ElementName.GLUELINE, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFGlueLine)kElem.getNextSiblingElement(ElementName.GLUELINE, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element GlueLine </summary>
      ///     
      public virtual JDFGlueLine appendGlueLine()
      {
         return (JDFGlueLine)appendElement(ElementName.GLUELINE, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refGlueLine(JDFGlueLine refTarget)
      {
         refElement(refTarget);
      }
   }
}
