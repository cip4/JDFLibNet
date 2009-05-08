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

   public abstract class JDFAutoShapeElement : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[9];
      static JDFAutoShapeElement()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.CUTBOX, 0x33333331, AttributeInfo.EnumAttributeType.rectangle, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.CUTOUT, 0x33333331, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.CUTPATH, 0x33333331, AttributeInfo.EnumAttributeType.PDFPath, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.MATERIAL, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.CUTTYPE, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumCutType.getEnum(0), "Cut");
         atrInfoTable[5] = new AtrInfoTable(AttributeName.SHAPEDEPTH, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.SHAPETYPE, 0x22222221, AttributeInfo.EnumAttributeType.enumeration, EnumShapeType.getEnum(0), null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.STATIONNAME, 0x33333111, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.TEETHPERDIMENSION, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoShapeElement </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoShapeElement(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoShapeElement </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoShapeElement(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoShapeElement </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoShapeElement(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoShapeElement[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for CutType </summary>
      ///        

      public class EnumCutType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumCutType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumCutType getEnum(string enumName)
         {
            return (EnumCutType)getEnum(typeof(EnumCutType), enumName);
         }

         public static EnumCutType getEnum(int enumValue)
         {
            return (EnumCutType)getEnum(typeof(EnumCutType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumCutType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumCutType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumCutType));
         }

         public static readonly EnumCutType Cut = new EnumCutType("Cut");
         public static readonly EnumCutType Perforate = new EnumCutType("Perforate");
      }



      ///        
      ///        <summary> * Enumeration strings for ShapeType </summary>
      ///        

      public class EnumShapeType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumShapeType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumShapeType getEnum(string enumName)
         {
            return (EnumShapeType)getEnum(typeof(EnumShapeType), enumName);
         }

         public static EnumShapeType getEnum(int enumValue)
         {
            return (EnumShapeType)getEnum(typeof(EnumShapeType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumShapeType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumShapeType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumShapeType));
         }

         public static readonly EnumShapeType Rectangular = new EnumShapeType("Rectangular");
         public static readonly EnumShapeType Round = new EnumShapeType("Round");
         public static readonly EnumShapeType Path = new EnumShapeType("Path");
         public static readonly EnumShapeType RoundedRectangle = new EnumShapeType("RoundedRectangle");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute CutBox
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CutBox </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCutBox(JDFRectangle @value)
      {
         setAttribute(AttributeName.CUTBOX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFRectangle attribute CutBox </summary>
      ///          * <returns> JDFRectangle the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFRectangle </returns>
      ///          
      public virtual JDFRectangle getCutBox()
      {
         string strAttrName = "";
         JDFRectangle nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.CUTBOX, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute CutOut
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CutOut </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCutOut(bool @value)
      {
         setAttribute(AttributeName.CUTOUT, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute CutOut </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getCutOut()
      {
         return getBoolAttribute(AttributeName.CUTOUT, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute CutPath
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CutPath </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCutPath(string @value)
      {
         setAttribute(AttributeName.CUTPATH, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute CutPath </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getCutPath()
      {
         return getAttribute(AttributeName.CUTPATH, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Material
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Material </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMaterial(string @value)
      {
         setAttribute(AttributeName.MATERIAL, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Material </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getMaterial()
      {
         return getAttribute(AttributeName.MATERIAL, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute CutType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute CutType </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setCutType(EnumCutType enumVar)
      {
         setAttribute(AttributeName.CUTTYPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute CutType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumCutType getCutType()
      {
         return EnumCutType.getEnum(getAttribute(AttributeName.CUTTYPE, null, "Cut"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ShapeDepth
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ShapeDepth </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setShapeDepth(double @value)
      {
         setAttribute(AttributeName.SHAPEDEPTH, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute ShapeDepth </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getShapeDepth()
      {
         return getRealAttribute(AttributeName.SHAPEDEPTH, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ShapeType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute ShapeType </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setShapeType(EnumShapeType enumVar)
      {
         setAttribute(AttributeName.SHAPETYPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute ShapeType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumShapeType getShapeType()
      {
         return EnumShapeType.getEnum(getAttribute(AttributeName.SHAPETYPE, null, null));
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
         return getAttribute(AttributeName.STATIONNAME, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TeethPerDimension
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TeethPerDimension </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTeethPerDimension(double @value)
      {
         setAttribute(AttributeName.TEETHPERDIMENSION, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute TeethPerDimension </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getTeethPerDimension()
      {
         return getRealAttribute(AttributeName.TEETHPERDIMENSION, null, 0.0);
      }
   }
}
