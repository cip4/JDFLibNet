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
   using JDFElement = org.cip4.jdflib.core.JDFElement;

   public abstract class JDFAutoIDPImageShift : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[8];
      static JDFAutoIDPImageShift()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.POSITIONX, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumPositionX.getEnum(0), "None");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.POSITIONY, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumPositionY.getEnum(0), "None");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.SHIFTX, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.SHIFTY, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.SHIFTXSIDE1, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.SHIFTXSIDE2, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.SHIFTYSIDE1, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.SHIFTYSIDE2, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoIDPImageShift </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoIDPImageShift(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoIDPImageShift </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoIDPImageShift(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoIDPImageShift </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoIDPImageShift(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoIDPImageShift[  --> " + base.ToString() + " ]";
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

         public static readonly EnumPositionX Center = new EnumPositionX("Center");
         public static readonly EnumPositionX Left = new EnumPositionX("Left");
         public static readonly EnumPositionX None = new EnumPositionX("None");
         public static readonly EnumPositionX Right = new EnumPositionX("Right");
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
         public static readonly EnumPositionY Center = new EnumPositionY("Center");
         public static readonly EnumPositionY None = new EnumPositionY("None");
         public static readonly EnumPositionY Top = new EnumPositionY("Top");
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
         return EnumPositionX.getEnum(getAttribute(AttributeName.POSITIONX, null, "None"));
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
         return EnumPositionY.getEnum(getAttribute(AttributeName.POSITIONY, null, "None"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ShiftX
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ShiftX </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setShiftX(int @value)
      {
         setAttribute(AttributeName.SHIFTX, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute ShiftX </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getShiftX()
      {
         return getIntAttribute(AttributeName.SHIFTX, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ShiftY
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ShiftY </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setShiftY(int @value)
      {
         setAttribute(AttributeName.SHIFTY, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute ShiftY </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getShiftY()
      {
         return getIntAttribute(AttributeName.SHIFTY, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ShiftXSide1
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ShiftXSide1 </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setShiftXSide1(int @value)
      {
         setAttribute(AttributeName.SHIFTXSIDE1, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute ShiftXSide1 </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getShiftXSide1()
      {
         return getIntAttribute(AttributeName.SHIFTXSIDE1, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ShiftXSide2
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ShiftXSide2 </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setShiftXSide2(int @value)
      {
         setAttribute(AttributeName.SHIFTXSIDE2, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute ShiftXSide2 </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getShiftXSide2()
      {
         return getIntAttribute(AttributeName.SHIFTXSIDE2, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ShiftYSide1
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ShiftYSide1 </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setShiftYSide1(int @value)
      {
         setAttribute(AttributeName.SHIFTYSIDE1, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute ShiftYSide1 </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getShiftYSide1()
      {
         return getIntAttribute(AttributeName.SHIFTYSIDE1, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ShiftYSide2
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ShiftYSide2 </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setShiftYSide2(int @value)
      {
         setAttribute(AttributeName.SHIFTYSIDE2, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute ShiftYSide2 </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getShiftYSide2()
      {
         return getIntAttribute(AttributeName.SHIFTYSIDE2, null, 0);
      }
   }
}
