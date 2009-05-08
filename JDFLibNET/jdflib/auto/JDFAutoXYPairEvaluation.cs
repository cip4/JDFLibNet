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
   using JDFXYPairRangeList = org.cip4.jdflib.datatypes.JDFXYPairRangeList;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFBasicPreflightTest = org.cip4.jdflib.resource.devicecapability.JDFBasicPreflightTest;

   public abstract class JDFAutoXYPairEvaluation : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[3];
      static JDFAutoXYPairEvaluation()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.TOLERANCE, 0x33333333, AttributeInfo.EnumAttributeType.XYPair, null, "0 0");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.VALUELIST, 0x33333333, AttributeInfo.EnumAttributeType.XYPairRangeList, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.XYRELATION, 0x33333333, AttributeInfo.EnumAttributeType.XYRelation, EnumXYRelation.getEnum(0), null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.BASICPREFLIGHTTEST, 0x33333333);
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
      ///     <summary> * Constructor for JDFAutoXYPairEvaluation </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoXYPairEvaluation(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoXYPairEvaluation </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoXYPairEvaluation(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoXYPairEvaluation </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoXYPairEvaluation(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoXYPairEvaluation[  --> " + base.ToString() + " ]";
      }


      public override bool init()
      {
         bool bRet = base.init();
         setResourceClass(JDFResource.EnumResourceClass.Parameter);
         return bRet;
      }


      ///        
      ///        <summary> * Enumeration strings for XYRelation </summary>
      ///        

      public new class EnumXYRelation : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumXYRelation(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumXYRelation getEnum(string enumName)
         {
            return (EnumXYRelation)getEnum(typeof(EnumXYRelation), enumName);
         }

         public static EnumXYRelation getEnum(int enumValue)
         {
            return (EnumXYRelation)getEnum(typeof(EnumXYRelation), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumXYRelation));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumXYRelation));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumXYRelation));
         }

         public static readonly EnumXYRelation gt = new EnumXYRelation("gt");
         public static readonly EnumXYRelation ge = new EnumXYRelation("ge");
         public static readonly EnumXYRelation eq = new EnumXYRelation("eq");
         public static readonly EnumXYRelation le = new EnumXYRelation("le");
         public static readonly EnumXYRelation lt = new EnumXYRelation("lt");
         public static readonly EnumXYRelation ne = new EnumXYRelation("ne");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute Tolerance
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Tolerance </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTolerance(JDFXYPair @value)
      {
         setAttribute(AttributeName.TOLERANCE, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute Tolerance </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getTolerance()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.TOLERANCE, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute ValueList
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ValueList </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setValueList(JDFXYPairRangeList @value)
      {
         setAttribute(AttributeName.VALUELIST, @value.ToString(), null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPairRangeList attribute ValueList </summary>
      ///          * <returns> JDFXYPairRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPairRangeList </returns>
      ///          
      public virtual JDFXYPairRangeList getValueList()
      {
         string strAttrName = "";
         JDFXYPairRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.VALUELIST, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFXYPairRangeList(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute XYRelation
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute XYRelation </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setXYRelation(EnumXYRelation enumVar)
      {
         setAttribute(AttributeName.XYRELATION, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute XYRelation </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumXYRelation getXYRelation()
      {
         return EnumXYRelation.getEnum(getAttribute(AttributeName.XYRELATION, null, null));
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateBasicPreflightTest
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFBasicPreflightTest the element </returns>
      ///     
      public virtual JDFBasicPreflightTest getCreateBasicPreflightTest(int iSkip)
      {
         return (JDFBasicPreflightTest)getCreateElement_KElement(ElementName.BASICPREFLIGHTTEST, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element BasicPreflightTest </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFBasicPreflightTest the element </returns>
      ///     * default is getBasicPreflightTest(0)     
      public virtual JDFBasicPreflightTest getBasicPreflightTest(int iSkip)
      {
         return (JDFBasicPreflightTest)getElement(ElementName.BASICPREFLIGHTTEST, null, iSkip);
      }

      ///    
      ///     <summary> * Get all BasicPreflightTest from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFBasicPreflightTest> </returns>
      ///     
      public virtual ICollection<JDFBasicPreflightTest> getAllBasicPreflightTest()
      {
         List<JDFBasicPreflightTest> v = new List<JDFBasicPreflightTest>();

         JDFBasicPreflightTest kElem = (JDFBasicPreflightTest)getFirstChildElement(ElementName.BASICPREFLIGHTTEST, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFBasicPreflightTest)kElem.getNextSiblingElement(ElementName.BASICPREFLIGHTTEST, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element BasicPreflightTest </summary>
      ///     
      public virtual JDFBasicPreflightTest appendBasicPreflightTest()
      {
         return (JDFBasicPreflightTest)appendElement(ElementName.BASICPREFLIGHTTEST, null);
      }
   }
}
