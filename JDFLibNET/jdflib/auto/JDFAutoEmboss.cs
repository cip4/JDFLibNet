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

   public abstract class JDFAutoEmboss : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[8];
      static JDFAutoEmboss()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.DIRECTION, 0x22222221, AttributeInfo.EnumAttributeType.enumeration, EnumDirection.getEnum(0), null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.EDGEANGLE, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.EDGESHAPE, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumEdgeShape.getEnum(0), "Rounded");
         atrInfoTable[3] = new AtrInfoTable(AttributeName.EMBOSSINGTYPE, 0x22222221, AttributeInfo.EnumAttributeType.enumeration, EnumEmbossingType.getEnum(0), null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.HEIGHT, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.IMAGESIZE, 0x33333331, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.LEVEL, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumLevel.getEnum(0), null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.POSITION, 0x33333331, AttributeInfo.EnumAttributeType.XYPair, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoEmboss </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoEmboss(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoEmboss </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoEmboss(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoEmboss </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoEmboss(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoEmboss[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for Direction </summary>
      ///        

      public class EnumDirection : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumDirection(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumDirection getEnum(string enumName)
         {
            return (EnumDirection)getEnum(typeof(EnumDirection), enumName);
         }

         public static EnumDirection getEnum(int enumValue)
         {
            return (EnumDirection)getEnum(typeof(EnumDirection), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumDirection));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumDirection));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumDirection));
         }

         public static readonly EnumDirection Both = new EnumDirection("Both");
         public static readonly EnumDirection Flat = new EnumDirection("Flat");
         public static readonly EnumDirection Raised = new EnumDirection("Raised");
         public static readonly EnumDirection Depressed = new EnumDirection("Depressed");
      }



      ///        
      ///        <summary> * Enumeration strings for EdgeShape </summary>
      ///        

      public class EnumEdgeShape : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumEdgeShape(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumEdgeShape getEnum(string enumName)
         {
            return (EnumEdgeShape)getEnum(typeof(EnumEdgeShape), enumName);
         }

         public static EnumEdgeShape getEnum(int enumValue)
         {
            return (EnumEdgeShape)getEnum(typeof(EnumEdgeShape), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumEdgeShape));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumEdgeShape));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumEdgeShape));
         }

         public static readonly EnumEdgeShape Beveled = new EnumEdgeShape("Beveled");
         public static readonly EnumEdgeShape Rounded = new EnumEdgeShape("Rounded");
      }



      ///        
      ///        <summary> * Enumeration strings for EmbossingType </summary>
      ///        

      public class EnumEmbossingType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumEmbossingType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumEmbossingType getEnum(string enumName)
         {
            return (EnumEmbossingType)getEnum(typeof(EnumEmbossingType), enumName);
         }

         public static EnumEmbossingType getEnum(int enumValue)
         {
            return (EnumEmbossingType)getEnum(typeof(EnumEmbossingType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumEmbossingType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumEmbossingType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumEmbossingType));
         }

         public static readonly EnumEmbossingType BlindEmbossing = new EnumEmbossingType("BlindEmbossing");
         public static readonly EnumEmbossingType Braille = new EnumEmbossingType("Braille");
         public static readonly EnumEmbossingType EmbossedFinish = new EnumEmbossingType("EmbossedFinish");
         public static readonly EnumEmbossingType FoilEmbossing = new EnumEmbossingType("FoilEmbossing");
         public static readonly EnumEmbossingType FoilStamping = new EnumEmbossingType("FoilStamping");
         public static readonly EnumEmbossingType RegisteredEmbossing = new EnumEmbossingType("RegisteredEmbossing");
      }



      ///        
      ///        <summary> * Enumeration strings for Level </summary>
      ///        

      public class EnumLevel : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumLevel(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumLevel getEnum(string enumName)
         {
            return (EnumLevel)getEnum(typeof(EnumLevel), enumName);
         }

         public static EnumLevel getEnum(int enumValue)
         {
            return (EnumLevel)getEnum(typeof(EnumLevel), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumLevel));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumLevel));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumLevel));
         }

         public static readonly EnumLevel SingleLevel = new EnumLevel("SingleLevel");
         public static readonly EnumLevel MultiLevel = new EnumLevel("MultiLevel");
         public static readonly EnumLevel Sculpted = new EnumLevel("Sculpted");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute Direction
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Direction </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setDirection(EnumDirection enumVar)
      {
         setAttribute(AttributeName.DIRECTION, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Direction </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumDirection getDirection()
      {
         return EnumDirection.getEnum(getAttribute(AttributeName.DIRECTION, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute EdgeAngle
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute EdgeAngle </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setEdgeAngle(double @value)
      {
         setAttribute(AttributeName.EDGEANGLE, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute EdgeAngle </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getEdgeAngle()
      {
         return getRealAttribute(AttributeName.EDGEANGLE, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute EdgeShape
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute EdgeShape </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setEdgeShape(EnumEdgeShape enumVar)
      {
         setAttribute(AttributeName.EDGESHAPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute EdgeShape </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumEdgeShape getEdgeShape()
      {
         return EnumEdgeShape.getEnum(getAttribute(AttributeName.EDGESHAPE, null, "Rounded"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute EmbossingType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute EmbossingType </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setEmbossingType(EnumEmbossingType enumVar)
      {
         setAttribute(AttributeName.EMBOSSINGTYPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute EmbossingType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumEmbossingType getEmbossingType()
      {
         return EnumEmbossingType.getEnum(getAttribute(AttributeName.EMBOSSINGTYPE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Height
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Height </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setHeight(double @value)
      {
         setAttribute(AttributeName.HEIGHT, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute Height </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getHeight()
      {
         return getRealAttribute(AttributeName.HEIGHT, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ImageSize
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ImageSize </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setImageSize(JDFXYPair @value)
      {
         setAttribute(AttributeName.IMAGESIZE, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute ImageSize </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getImageSize()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.IMAGESIZE, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute Level
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Level </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setLevel(EnumLevel enumVar)
      {
         setAttribute(AttributeName.LEVEL, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Level </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumLevel getLevel()
      {
         return EnumLevel.getEnum(getAttribute(AttributeName.LEVEL, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Position
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Position </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPosition(JDFXYPair @value)
      {
         setAttribute(AttributeName.POSITION, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute Position </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getPosition()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.POSITION, null, JDFConstants.EMPTYSTRING);
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
