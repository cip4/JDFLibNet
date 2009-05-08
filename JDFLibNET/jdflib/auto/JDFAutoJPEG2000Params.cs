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
   using JDFNumberList = org.cip4.jdflib.datatypes.JDFNumberList;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;

   public abstract class JDFAutoJPEG2000Params : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[6];
      static JDFAutoJPEG2000Params()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.CODEBLOCKSIZE, 0x33333111, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.LAYERSPERTILE, 0x33333111, AttributeInfo.EnumAttributeType.integer, null, "1");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.LAYERRATES, 0x33333111, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.NUMRESOLUTIONS, 0x33333111, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.PROGRESSIONORDER, 0x33333111, AttributeInfo.EnumAttributeType.enumeration, EnumProgressionOrder.getEnum(0), null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.TILESIZE, 0x33333111, AttributeInfo.EnumAttributeType.XYPair, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoJPEG2000Params </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoJPEG2000Params(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoJPEG2000Params </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoJPEG2000Params(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoJPEG2000Params </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoJPEG2000Params(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoJPEG2000Params[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for ProgressionOrder </summary>
      ///        

      public class EnumProgressionOrder : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumProgressionOrder(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumProgressionOrder getEnum(string enumName)
         {
            return (EnumProgressionOrder)getEnum(typeof(EnumProgressionOrder), enumName);
         }

         public static EnumProgressionOrder getEnum(int enumValue)
         {
            return (EnumProgressionOrder)getEnum(typeof(EnumProgressionOrder), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumProgressionOrder));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumProgressionOrder));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumProgressionOrder));
         }

         public static readonly EnumProgressionOrder LRCP = new EnumProgressionOrder("LRCP");
         public static readonly EnumProgressionOrder RLCP = new EnumProgressionOrder("RLCP");
         public static readonly EnumProgressionOrder RPCL = new EnumProgressionOrder("RPCL");
         public static readonly EnumProgressionOrder PCRL = new EnumProgressionOrder("PCRL");
         public static readonly EnumProgressionOrder CPRL = new EnumProgressionOrder("CPRL");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute CodeBlockSize
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CodeBlockSize </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCodeBlockSize(int @value)
      {
         setAttribute(AttributeName.CODEBLOCKSIZE, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute CodeBlockSize </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getCodeBlockSize()
      {
         return getIntAttribute(AttributeName.CODEBLOCKSIZE, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute LayersPerTile
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute LayersPerTile </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setLayersPerTile(int @value)
      {
         setAttribute(AttributeName.LAYERSPERTILE, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute LayersPerTile </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getLayersPerTile()
      {
         return getIntAttribute(AttributeName.LAYERSPERTILE, null, 1);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute LayerRates
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute LayerRates </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setLayerRates(JDFNumberList @value)
      {
         setAttribute(AttributeName.LAYERRATES, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFNumberList attribute LayerRates </summary>
      ///          * <returns> JDFNumberList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFNumberList </returns>
      ///          
      public virtual JDFNumberList getLayerRates()
      {
         string strAttrName = "";
         JDFNumberList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.LAYERRATES, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFNumberList(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute NumResolutions
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute NumResolutions </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setNumResolutions(int @value)
      {
         setAttribute(AttributeName.NUMRESOLUTIONS, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute NumResolutions </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getNumResolutions()
      {
         return getIntAttribute(AttributeName.NUMRESOLUTIONS, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ProgressionOrder
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute ProgressionOrder </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setProgressionOrder(EnumProgressionOrder enumVar)
      {
         setAttribute(AttributeName.PROGRESSIONORDER, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute ProgressionOrder </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumProgressionOrder getProgressionOrder()
      {
         return EnumProgressionOrder.getEnum(getAttribute(AttributeName.PROGRESSIONORDER, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TileSize
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TileSize </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTileSize(JDFXYPair @value)
      {
         setAttribute(AttributeName.TILESIZE, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute TileSize </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getTileSize()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.TILESIZE, null, JDFConstants.EMPTYSTRING);
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
