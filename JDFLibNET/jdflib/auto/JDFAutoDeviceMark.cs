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
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;

   public abstract class JDFAutoDeviceMark : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[6];
      static JDFAutoDeviceMark()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.FONT, 0x33333331, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.FONTSIZE, 0x33333331, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.MARKJUSTIFICATION, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumMarkJustification.getEnum(0), null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.MARKOFFSET, 0x33333331, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.MARKORIENTATION, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumMarkOrientation.getEnum(0), null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.MARKPOSITION, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumMarkPosition.getEnum(0), null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoDeviceMark </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoDeviceMark(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoDeviceMark </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoDeviceMark(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoDeviceMark </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoDeviceMark(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoDeviceMark[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for MarkJustification </summary>
      ///        

      public class EnumMarkJustification : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumMarkJustification(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumMarkJustification getEnum(string enumName)
         {
            return (EnumMarkJustification)getEnum(typeof(EnumMarkJustification), enumName);
         }

         public static EnumMarkJustification getEnum(int enumValue)
         {
            return (EnumMarkJustification)getEnum(typeof(EnumMarkJustification), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumMarkJustification));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumMarkJustification));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumMarkJustification));
         }

         public static readonly EnumMarkJustification Left = new EnumMarkJustification("Left");
         public static readonly EnumMarkJustification Right = new EnumMarkJustification("Right");
         public static readonly EnumMarkJustification Center = new EnumMarkJustification("Center");
      }



      ///        
      ///        <summary> * Enumeration strings for MarkOrientation </summary>
      ///        

      public class EnumMarkOrientation : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumMarkOrientation(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumMarkOrientation getEnum(string enumName)
         {
            return (EnumMarkOrientation)getEnum(typeof(EnumMarkOrientation), enumName);
         }

         public static EnumMarkOrientation getEnum(int enumValue)
         {
            return (EnumMarkOrientation)getEnum(typeof(EnumMarkOrientation), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumMarkOrientation));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumMarkOrientation));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumMarkOrientation));
         }

         public static readonly EnumMarkOrientation Vertical = new EnumMarkOrientation("Vertical");
         public static readonly EnumMarkOrientation Horizontal = new EnumMarkOrientation("Horizontal");
      }



      ///        
      ///        <summary> * Enumeration strings for MarkPosition </summary>
      ///        

      public class EnumMarkPosition : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumMarkPosition(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumMarkPosition getEnum(string enumName)
         {
            return (EnumMarkPosition)getEnum(typeof(EnumMarkPosition), enumName);
         }

         public static EnumMarkPosition getEnum(int enumValue)
         {
            return (EnumMarkPosition)getEnum(typeof(EnumMarkPosition), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumMarkPosition));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumMarkPosition));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumMarkPosition));
         }

         public static readonly EnumMarkPosition Top = new EnumMarkPosition("Top");
         public static readonly EnumMarkPosition Bottom = new EnumMarkPosition("Bottom");
         public static readonly EnumMarkPosition Left = new EnumMarkPosition("Left");
         public static readonly EnumMarkPosition Right = new EnumMarkPosition("Right");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute Font
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Font </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFont(string @value)
      {
         setAttribute(AttributeName.FONT, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Font </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getFont()
      {
         return getAttribute(AttributeName.FONT, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute FontSize
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute FontSize </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFontSize(int @value)
      {
         setAttribute(AttributeName.FONTSIZE, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute FontSize </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getFontSize()
      {
         return getIntAttribute(AttributeName.FONTSIZE, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MarkJustification
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute MarkJustification </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setMarkJustification(EnumMarkJustification enumVar)
      {
         setAttribute(AttributeName.MARKJUSTIFICATION, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute MarkJustification </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumMarkJustification getMarkJustification()
      {
         return EnumMarkJustification.getEnum(getAttribute(AttributeName.MARKJUSTIFICATION, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MarkOffset
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MarkOffset </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMarkOffset(JDFXYPair @value)
      {
         setAttribute(AttributeName.MARKOFFSET, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute MarkOffset </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getMarkOffset()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.MARKOFFSET, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute MarkOrientation
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute MarkOrientation </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setMarkOrientation(EnumMarkOrientation enumVar)
      {
         setAttribute(AttributeName.MARKORIENTATION, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute MarkOrientation </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumMarkOrientation getMarkOrientation()
      {
         return EnumMarkOrientation.getEnum(getAttribute(AttributeName.MARKORIENTATION, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MarkPosition
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute MarkPosition </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setMarkPosition(EnumMarkPosition enumVar)
      {
         setAttribute(AttributeName.MARKPOSITION, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute MarkPosition </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumMarkPosition getMarkPosition()
      {
         return EnumMarkPosition.getEnum(getAttribute(AttributeName.MARKPOSITION, null, null));
      }
   }
}
