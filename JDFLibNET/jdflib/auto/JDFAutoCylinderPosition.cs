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
   using JDFXYPairRangeList = org.cip4.jdflib.datatypes.JDFXYPairRangeList;

   public abstract class JDFAutoCylinderPosition : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[4];
      static JDFAutoCylinderPosition()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.PLATEPOSITION, 0x22222111, AttributeInfo.EnumAttributeType.XYPairRangeList, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.PLATETYPE, 0x33333111, AttributeInfo.EnumAttributeType.enumeration, EnumPlateType.getEnum(0), "Content");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.PLATEUSAGE, 0x33333111, AttributeInfo.EnumAttributeType.enumeration, EnumPlateUsage.getEnum(0), "Original");
         atrInfoTable[3] = new AtrInfoTable(AttributeName.DEVICEMODULEINDEX, 0x22222111, AttributeInfo.EnumAttributeType.integer, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoCylinderPosition </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoCylinderPosition(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoCylinderPosition </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoCylinderPosition(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoCylinderPosition </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoCylinderPosition(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoCylinderPosition[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for PlateType </summary>
      ///        

      public class EnumPlateType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumPlateType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumPlateType getEnum(string enumName)
         {
            return (EnumPlateType)getEnum(typeof(EnumPlateType), enumName);
         }

         public static EnumPlateType getEnum(int enumValue)
         {
            return (EnumPlateType)getEnum(typeof(EnumPlateType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumPlateType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumPlateType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumPlateType));
         }

         public static readonly EnumPlateType Content = new EnumPlateType("Content");
         public static readonly EnumPlateType Dummy = new EnumPlateType("Dummy");
      }



      ///        
      ///        <summary> * Enumeration strings for PlateUsage </summary>
      ///        

      public class EnumPlateUsage : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumPlateUsage(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumPlateUsage getEnum(string enumName)
         {
            return (EnumPlateUsage)getEnum(typeof(EnumPlateUsage), enumName);
         }

         public static EnumPlateUsage getEnum(int enumValue)
         {
            return (EnumPlateUsage)getEnum(typeof(EnumPlateUsage), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumPlateUsage));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumPlateUsage));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumPlateUsage));
         }

         public static readonly EnumPlateUsage Original = new EnumPlateUsage("Original");
         public static readonly EnumPlateUsage Reuse = new EnumPlateUsage("Reuse");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute PlatePosition
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PlatePosition </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPlatePosition(JDFXYPairRangeList @value)
      {
         setAttribute(AttributeName.PLATEPOSITION, @value.ToString(), null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPairRangeList attribute PlatePosition </summary>
      ///          * <returns> JDFXYPairRangeList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPairRangeList </returns>
      ///          
      public virtual JDFXYPairRangeList getPlatePosition()
      {
         string strAttrName = "";
         JDFXYPairRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.PLATEPOSITION, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute PlateType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute PlateType </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setPlateType(EnumPlateType enumVar)
      {
         setAttribute(AttributeName.PLATETYPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute PlateType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumPlateType getPlateType()
      {
         return EnumPlateType.getEnum(getAttribute(AttributeName.PLATETYPE, null, "Content"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PlateUsage
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute PlateUsage </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setPlateUsage(EnumPlateUsage enumVar)
      {
         setAttribute(AttributeName.PLATEUSAGE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute PlateUsage </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumPlateUsage getPlateUsage()
      {
         return EnumPlateUsage.getEnum(getAttribute(AttributeName.PLATEUSAGE, null, "Original"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute DeviceModuleIndex
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DeviceModuleIndex </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDeviceModuleIndex(int @value)
      {
         setAttribute(AttributeName.DEVICEMODULEINDEX, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute DeviceModuleIndex </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getDeviceModuleIndex()
      {
         return getIntAttribute(AttributeName.DEVICEMODULEINDEX, null, 0);
      }
   }
}
