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
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFIntentResource = org.cip4.jdflib.resource.intent.JDFIntentResource;
   using JDFIntegerSpan = org.cip4.jdflib.span.JDFIntegerSpan;
   using JDFXYPairSpan = org.cip4.jdflib.span.JDFXYPairSpan;

   public abstract class JDFAutoSizeIntent : JDFIntentResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[1];
      static JDFAutoSizeIntent()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.TYPE, 0x44444443, AttributeInfo.EnumAttributeType.enumeration, EnumType.getEnum(0), "Folded");
         elemInfoTable[0] = new ElemInfoTable(ElementName.DIMENSIONS, 0x77777775);
         elemInfoTable[1] = new ElemInfoTable(ElementName.PAGES, 0x77777776);
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
      ///     <summary> * Constructor for JDFAutoSizeIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoSizeIntent(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoSizeIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoSizeIntent(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoSizeIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoSizeIntent(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoSizeIntent[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for Type </summary>
      ///        

      public class EnumType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumType getEnum(string enumName)
         {
            return (EnumType)getEnum(typeof(EnumType), enumName);
         }

         public static EnumType getEnum(int enumValue)
         {
            return (EnumType)getEnum(typeof(EnumType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumType));
         }

         public static readonly EnumType Folded = new EnumType("Folded");
         public static readonly EnumType Flat = new EnumType("Flat");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute Type
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Type </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setType(EnumType enumVar)
      {
         setAttribute(AttributeName.TYPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Type </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumType getType()
      {
         return EnumType.getEnum(getAttribute(AttributeName.TYPE, null, "Folded"));
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element Dimensions </summary>
      ///     * <returns> JDFXYPairSpan the element </returns>
      ///     
      public virtual JDFXYPairSpan getDimensions()
      {
         return (JDFXYPairSpan)getElement(ElementName.DIMENSIONS, null, 0);
      }

      ///     <summary> (25) getCreateDimensions
      ///     *  </summary>
      ///     * <returns> JDFXYPairSpan the element </returns>
      ///     
      public virtual JDFXYPairSpan getCreateDimensions()
      {
         return (JDFXYPairSpan)getCreateElement_KElement(ElementName.DIMENSIONS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Dimensions </summary>
      ///     
      public virtual JDFXYPairSpan appendDimensions()
      {
         return (JDFXYPairSpan)appendElementN(ElementName.DIMENSIONS, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element Pages </summary>
      ///     * <returns> JDFIntegerSpan the element </returns>
      ///     
      public virtual JDFIntegerSpan getPages()
      {
         return (JDFIntegerSpan)getElement(ElementName.PAGES, null, 0);
      }

      ///     <summary> (25) getCreatePages
      ///     *  </summary>
      ///     * <returns> JDFIntegerSpan the element </returns>
      ///     
      public virtual JDFIntegerSpan getCreatePages()
      {
         return (JDFIntegerSpan)getCreateElement_KElement(ElementName.PAGES, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Pages </summary>
      ///     
      public virtual JDFIntegerSpan appendPages()
      {
         return (JDFIntegerSpan)appendElementN(ElementName.PAGES, 1, null);
      }
   }
}
