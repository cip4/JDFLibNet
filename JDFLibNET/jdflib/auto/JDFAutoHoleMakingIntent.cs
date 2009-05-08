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
   using JDFIntentResource = org.cip4.jdflib.resource.intent.JDFIntentResource;
   using JDFHoleList = org.cip4.jdflib.resource.process.postpress.JDFHoleList;
   using JDFStringSpan = org.cip4.jdflib.span.JDFStringSpan;

   public abstract class JDFAutoHoleMakingIntent : JDFIntentResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[2];
      static JDFAutoHoleMakingIntent()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.HOLEREFERENCEEDGE, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumHoleReferenceEdge.getEnum(0), "Left");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.EXTENT, 0x33333311, AttributeInfo.EnumAttributeType.XYPair, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.HOLETYPE, 0x55555555);
         elemInfoTable[1] = new ElemInfoTable(ElementName.HOLELIST, 0x66666666);
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
      ///     <summary> * Constructor for JDFAutoHoleMakingIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoHoleMakingIntent(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoHoleMakingIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoHoleMakingIntent(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoHoleMakingIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoHoleMakingIntent(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoHoleMakingIntent[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for HoleReferenceEdge </summary>
      ///        

      public class EnumHoleReferenceEdge : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumHoleReferenceEdge(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumHoleReferenceEdge getEnum(string enumName)
         {
            return (EnumHoleReferenceEdge)getEnum(typeof(EnumHoleReferenceEdge), enumName);
         }

         public static EnumHoleReferenceEdge getEnum(int enumValue)
         {
            return (EnumHoleReferenceEdge)getEnum(typeof(EnumHoleReferenceEdge), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumHoleReferenceEdge));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumHoleReferenceEdge));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumHoleReferenceEdge));
         }

         public static readonly EnumHoleReferenceEdge Left = new EnumHoleReferenceEdge("Left");
         public static readonly EnumHoleReferenceEdge Right = new EnumHoleReferenceEdge("Right");
         public static readonly EnumHoleReferenceEdge Top = new EnumHoleReferenceEdge("Top");
         public static readonly EnumHoleReferenceEdge Bottom = new EnumHoleReferenceEdge("Bottom");
         public static readonly EnumHoleReferenceEdge Pattern = new EnumHoleReferenceEdge("Pattern");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute HoleReferenceEdge
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute HoleReferenceEdge </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setHoleReferenceEdge(EnumHoleReferenceEdge enumVar)
      {
         setAttribute(AttributeName.HOLEREFERENCEEDGE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute HoleReferenceEdge </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumHoleReferenceEdge getHoleReferenceEdge()
      {
         return EnumHoleReferenceEdge.getEnum(getAttribute(AttributeName.HOLEREFERENCEEDGE, null, "Left"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Extent
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Extent </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setExtent(JDFXYPair @value)
      {
         setAttribute(AttributeName.EXTENT, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute Extent </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getExtent()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.EXTENT, null, JDFConstants.EMPTYSTRING);
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

      ///    
      ///     <summary> * (24) const get element HoleType </summary>
      ///     * <returns> JDFStringSpan the element </returns>
      ///     
      public virtual JDFStringSpan getHoleType()
      {
         return (JDFStringSpan)getElement(ElementName.HOLETYPE, null, 0);
      }

      ///     <summary> (25) getCreateHoleType
      ///     *  </summary>
      ///     * <returns> JDFStringSpan the element </returns>
      ///     
      public virtual JDFStringSpan getCreateHoleType()
      {
         return (JDFStringSpan)getCreateElement_KElement(ElementName.HOLETYPE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element HoleType </summary>
      ///     
      public virtual JDFStringSpan appendHoleType()
      {
         return (JDFStringSpan)appendElementN(ElementName.HOLETYPE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element HoleList </summary>
      ///     * <returns> JDFHoleList the element </returns>
      ///     
      public virtual JDFHoleList getHoleList()
      {
         return (JDFHoleList)getElement(ElementName.HOLELIST, null, 0);
      }

      ///     <summary> (25) getCreateHoleList
      ///     *  </summary>
      ///     * <returns> JDFHoleList the element </returns>
      ///     
      public virtual JDFHoleList getCreateHoleList()
      {
         return (JDFHoleList)getCreateElement_KElement(ElementName.HOLELIST, null, 0);
      }

      ///    
      ///     <summary> * (29) append element HoleList </summary>
      ///     
      public virtual JDFHoleList appendHoleList()
      {
         return (JDFHoleList)appendElementN(ElementName.HOLELIST, 1, null);
      }
   }
}
