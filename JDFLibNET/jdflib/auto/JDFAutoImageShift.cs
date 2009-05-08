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
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;

   public abstract class JDFAutoImageShift : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[4];
      static JDFAutoImageShift()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.POSITIONX, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumPositionX.getEnum(0), null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.POSITIONY, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumPositionY.getEnum(0), null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.SHIFTBACK, 0x33333331, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.SHIFTFRONT, 0x33333331, AttributeInfo.EnumAttributeType.XYPair, null, "0 0");
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoImageShift </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoImageShift(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoImageShift </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoImageShift(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoImageShift </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoImageShift(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoImageShift[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for PositionX </summary>
      ///        

      public class EnumPositionX : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumPositionX(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumPositionX getEnum(string enumName)
         {
            return (EnumPositionX)getEnum(typeof(EnumPositionX), enumName);
         }

         public static EnumPositionX getEnum(int enumValue)
         {
            return (EnumPositionX)getEnum(typeof(EnumPositionX), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumPositionX));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumPositionX));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumPositionX));
         }

         public static readonly EnumPositionX Left = new EnumPositionX("Left");
         public static readonly EnumPositionX Right = new EnumPositionX("Right");
         public static readonly EnumPositionX Center = new EnumPositionX("Center");
         public static readonly EnumPositionX Spine = new EnumPositionX("Spine");
         public static readonly EnumPositionX None = new EnumPositionX("None");
      }



      ///        
      ///        <summary> * Enumeration strings for PositionY </summary>
      ///        

      public class EnumPositionY : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumPositionY(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumPositionY getEnum(string enumName)
         {
            return (EnumPositionY)getEnum(typeof(EnumPositionY), enumName);
         }

         public static EnumPositionY getEnum(int enumValue)
         {
            return (EnumPositionY)getEnum(typeof(EnumPositionY), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumPositionY));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumPositionY));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumPositionY));
         }

         public static readonly EnumPositionY Bottom = new EnumPositionY("Bottom");
         public static readonly EnumPositionY Top = new EnumPositionY("Top");
         public static readonly EnumPositionY Center = new EnumPositionY("Center");
         public static readonly EnumPositionY Spine = new EnumPositionY("Spine");
         public static readonly EnumPositionY None = new EnumPositionY("None");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute PositionX
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute PositionX </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setPositionX(EnumPositionX enumVar)
      {
         setAttribute(AttributeName.POSITIONX, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute PositionX </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumPositionX getPositionX()
      {
         return EnumPositionX.getEnum(getAttribute(AttributeName.POSITIONX, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PositionY
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute PositionY </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setPositionY(EnumPositionY enumVar)
      {
         setAttribute(AttributeName.POSITIONY, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute PositionY </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumPositionY getPositionY()
      {
         return EnumPositionY.getEnum(getAttribute(AttributeName.POSITIONY, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ShiftBack
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ShiftBack </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setShiftBack(JDFXYPair @value)
      {
         setAttribute(AttributeName.SHIFTBACK, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute ShiftBack </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getShiftBack()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.SHIFTBACK, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute ShiftFront
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ShiftFront </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setShiftFront(JDFXYPair @value)
      {
         setAttribute(AttributeName.SHIFTFRONT, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute ShiftFront </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getShiftFront()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.SHIFTFRONT, null, JDFConstants.EMPTYSTRING);
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
   }
}
