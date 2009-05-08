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
   using JDFIntegerList = org.cip4.jdflib.datatypes.JDFIntegerList;

   public abstract class JDFAutoSignatureCell : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[9];
      static JDFAutoSignatureCell()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.BACKFACEPAGES, 0x33333311, AttributeInfo.EnumAttributeType.IntegerList, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.BACKPAGES, 0x33333311, AttributeInfo.EnumAttributeType.IntegerList, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.BOTTLEANGLE, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.BOTTLEAXIS, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumBottleAxis.getEnum(0), null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.FRONTFACEPAGES, 0x33333311, AttributeInfo.EnumAttributeType.IntegerList, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.FRONTPAGES, 0x33333311, AttributeInfo.EnumAttributeType.IntegerList, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.ORIENTATION, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumOrientation.getEnum(0), "Up");
         atrInfoTable[7] = new AtrInfoTable(AttributeName.SECTIONINDEX, 0x33333311, AttributeInfo.EnumAttributeType.integer, null, "0");
         atrInfoTable[8] = new AtrInfoTable(AttributeName.STATIONNAME, 0x33333111, AttributeInfo.EnumAttributeType.string_, null, "0");
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoSignatureCell </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoSignatureCell(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoSignatureCell </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoSignatureCell(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoSignatureCell </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoSignatureCell(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoSignatureCell[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for BottleAxis </summary>
      ///        

      public class EnumBottleAxis : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumBottleAxis(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumBottleAxis getEnum(string enumName)
         {
            return (EnumBottleAxis)getEnum(typeof(EnumBottleAxis), enumName);
         }

         public static EnumBottleAxis getEnum(int enumValue)
         {
            return (EnumBottleAxis)getEnum(typeof(EnumBottleAxis), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumBottleAxis));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumBottleAxis));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumBottleAxis));
         }

         public static readonly EnumBottleAxis SpineHead = new EnumBottleAxis("SpineHead");
         public static readonly EnumBottleAxis SpineFoot = new EnumBottleAxis("SpineFoot");
         public static readonly EnumBottleAxis FaceHead = new EnumBottleAxis("FaceHead");
         public static readonly EnumBottleAxis FaceFoot = new EnumBottleAxis("FaceFoot");
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

         public static readonly EnumOrientation Up = new EnumOrientation("Up");
         public static readonly EnumOrientation Down = new EnumOrientation("Down");
         public static readonly EnumOrientation Left = new EnumOrientation("Left");
         public static readonly EnumOrientation Right = new EnumOrientation("Right");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute BackFacePages
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BackFacePages </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBackFacePages(JDFIntegerList @value)
      {
         setAttribute(AttributeName.BACKFACEPAGES, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerList attribute BackFacePages </summary>
      ///          * <returns> JDFIntegerList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerList </returns>
      ///          
      public virtual JDFIntegerList getBackFacePages()
      {
         string strAttrName = "";
         JDFIntegerList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.BACKFACEPAGES, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFIntegerList(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute BackPages
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BackPages </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBackPages(JDFIntegerList @value)
      {
         setAttribute(AttributeName.BACKPAGES, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerList attribute BackPages </summary>
      ///          * <returns> JDFIntegerList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerList </returns>
      ///          
      public virtual JDFIntegerList getBackPages()
      {
         string strAttrName = "";
         JDFIntegerList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.BACKPAGES, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFIntegerList(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute BottleAngle
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BottleAngle </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBottleAngle(double @value)
      {
         setAttribute(AttributeName.BOTTLEANGLE, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute BottleAngle </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getBottleAngle()
      {
         return getRealAttribute(AttributeName.BOTTLEANGLE, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute BottleAxis
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute BottleAxis </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setBottleAxis(EnumBottleAxis enumVar)
      {
         setAttribute(AttributeName.BOTTLEAXIS, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute BottleAxis </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumBottleAxis getBottleAxis()
      {
         return EnumBottleAxis.getEnum(getAttribute(AttributeName.BOTTLEAXIS, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute FrontFacePages
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute FrontFacePages </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFrontFacePages(JDFIntegerList @value)
      {
         setAttribute(AttributeName.FRONTFACEPAGES, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerList attribute FrontFacePages </summary>
      ///          * <returns> JDFIntegerList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerList </returns>
      ///          
      public virtual JDFIntegerList getFrontFacePages()
      {
         string strAttrName = "";
         JDFIntegerList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.FRONTFACEPAGES, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFIntegerList(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute FrontPages
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute FrontPages </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFrontPages(JDFIntegerList @value)
      {
         setAttribute(AttributeName.FRONTPAGES, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerList attribute FrontPages </summary>
      ///          * <returns> JDFIntegerList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerList </returns>
      ///          
      public virtual JDFIntegerList getFrontPages()
      {
         string strAttrName = "";
         JDFIntegerList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.FRONTPAGES, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFIntegerList(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
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
         return EnumOrientation.getEnum(getAttribute(AttributeName.ORIENTATION, null, "Up"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SectionIndex
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SectionIndex </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSectionIndex(int @value)
      {
         setAttribute(AttributeName.SECTIONINDEX, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute SectionIndex </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getSectionIndex()
      {
         return getIntAttribute(AttributeName.SECTIONINDEX, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute StationName
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute StationName </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setStationName(string @value)
      {
         setAttribute(AttributeName.STATIONNAME, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute StationName </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getStationName()
      {
         return getAttribute(AttributeName.STATIONNAME, null, "0");
      }
   }
}
