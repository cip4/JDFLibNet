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
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFRectangle = org.cip4.jdflib.datatypes.JDFRectangle;

   public abstract class JDFAutoPosition : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[7];
      static JDFAutoPosition()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ABSOLUTEBOX, 0x33333111, AttributeInfo.EnumAttributeType.rectangle, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.MARGINBOTTOM, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.MARGINTOP, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.MARGINLEFT, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.MARGINRIGHT, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.ORIENTATION, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumOrientation.getEnum(0), null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.RELATIVEBOX, 0x33333311, AttributeInfo.EnumAttributeType.rectangle, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoPosition </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPosition(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPosition </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPosition(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPosition </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoPosition(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoPosition[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for Orientation </summary>
      ///        

      public new class EnumOrientation : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumOrientation(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumOrientation getEnum(string enumName)
         {
            return (EnumOrientation)getEnum(typeof(EnumOrientation), enumName);
         }

         public static EnumOrientation getEnum(int enumValue)
         {
            return (EnumOrientation)getEnum(typeof(EnumOrientation), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumOrientation));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumOrientation));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumOrientation));
         }

         public static readonly EnumOrientation Rotate0 = new EnumOrientation("Rotate0");
         public static readonly EnumOrientation Rotate90 = new EnumOrientation("Rotate90");
         public static readonly EnumOrientation Rotate180 = new EnumOrientation("Rotate180");
         public static readonly EnumOrientation Rotate270 = new EnumOrientation("Rotate270");
         public static readonly EnumOrientation Flip0 = new EnumOrientation("Flip0");
         public static readonly EnumOrientation Flip90 = new EnumOrientation("Flip90");
         public static readonly EnumOrientation Flip180 = new EnumOrientation("Flip180");
         public static readonly EnumOrientation Flip270 = new EnumOrientation("Flip270");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute AbsoluteBox
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute AbsoluteBox </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAbsoluteBox(JDFRectangle @value)
      {
         setAttribute(AttributeName.ABSOLUTEBOX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFRectangle attribute AbsoluteBox </summary>
      ///          * <returns> JDFRectangle the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFRectangle </returns>
      ///          
      public virtual JDFRectangle getAbsoluteBox()
      {
         string strAttrName = "";
         JDFRectangle nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.ABSOLUTEBOX, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFRectangle(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MarginBottom
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MarginBottom </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMarginBottom(double @value)
      {
         setAttribute(AttributeName.MARGINBOTTOM, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute MarginBottom </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getMarginBottom()
      {
         return getRealAttribute(AttributeName.MARGINBOTTOM, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MarginTop
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MarginTop </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMarginTop(double @value)
      {
         setAttribute(AttributeName.MARGINTOP, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute MarginTop </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getMarginTop()
      {
         return getRealAttribute(AttributeName.MARGINTOP, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MarginLeft
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MarginLeft </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMarginLeft(double @value)
      {
         setAttribute(AttributeName.MARGINLEFT, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute MarginLeft </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getMarginLeft()
      {
         return getRealAttribute(AttributeName.MARGINLEFT, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MarginRight
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MarginRight </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMarginRight(double @value)
      {
         setAttribute(AttributeName.MARGINRIGHT, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute MarginRight </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getMarginRight()
      {
         return getRealAttribute(AttributeName.MARGINRIGHT, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Orientation
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Orientation </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setOrientation(EnumOrientation enumVar)
      {
         setAttribute(AttributeName.ORIENTATION, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Orientation </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumOrientation getOrientation()
      {
         return EnumOrientation.getEnum(getAttribute(AttributeName.ORIENTATION, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute RelativeBox
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute RelativeBox </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setRelativeBox(JDFRectangle @value)
      {
         setAttribute(AttributeName.RELATIVEBOX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFRectangle attribute RelativeBox </summary>
      ///          * <returns> JDFRectangle the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFRectangle </returns>
      ///          
      public virtual JDFRectangle getRelativeBox()
      {
         string strAttrName = "";
         JDFRectangle nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.RELATIVEBOX, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFRectangle(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }
   }
}
