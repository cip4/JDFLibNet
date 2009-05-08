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
   using JDFMatrix = org.cip4.jdflib.datatypes.JDFMatrix;
   using JDFRectangle = org.cip4.jdflib.datatypes.JDFRectangle;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;

   public abstract class JDFAutoContentObject : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[14];
      static JDFAutoContentObject()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.TYPE, 0x44444443, AttributeInfo.EnumAttributeType.enumeration, EnumType.getEnum(0), null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.SOURCECLIPPATH, 0x33333333, AttributeInfo.EnumAttributeType.PDFPath, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.SETORD, 0x33333331, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.LAYERID, 0x33333331, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.CTM, 0x22222222, AttributeInfo.EnumAttributeType.matrix, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.ORD, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.TRIMSIZE, 0x33333311, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.HALFTONEPHASEORIGIN, 0x33333333, AttributeInfo.EnumAttributeType.XYPair, null, "0 0");
         atrInfoTable[8] = new AtrInfoTable(AttributeName.ORDEXPRESSION, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.ORDID, 0x33333331, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[10] = new AtrInfoTable(AttributeName.TRIMCTM, 0x33333331, AttributeInfo.EnumAttributeType.matrix, null, null);
         atrInfoTable[11] = new AtrInfoTable(AttributeName.DOCORD, 0x33333331, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[12] = new AtrInfoTable(AttributeName.CLIPBOX, 0x33333333, AttributeInfo.EnumAttributeType.rectangle, null, null);
         atrInfoTable[13] = new AtrInfoTable(AttributeName.CLIPPATH, 0x33333333, AttributeInfo.EnumAttributeType.PDFPath, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoContentObject </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoContentObject(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoContentObject </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoContentObject(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoContentObject </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoContentObject(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoContentObject[  --> " + base.ToString() + " ]";
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

         public static readonly EnumType Content = new EnumType("Content");
         public static readonly EnumType Mark = new EnumType("Mark");
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
         return EnumType.getEnum(getAttribute(AttributeName.TYPE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SourceClipPath
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SourceClipPath </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSourceClipPath(string @value)
      {
         setAttribute(AttributeName.SOURCECLIPPATH, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute SourceClipPath </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getSourceClipPath()
      {
         return getAttribute(AttributeName.SOURCECLIPPATH, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SetOrd
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SetOrd </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSetOrd(int @value)
      {
         setAttribute(AttributeName.SETORD, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute SetOrd </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getSetOrd()
      {
         return getIntAttribute(AttributeName.SETORD, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute LayerID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute LayerID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setLayerID(int @value)
      {
         setAttribute(AttributeName.LAYERID, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute LayerID </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getLayerID()
      {
         return getIntAttribute(AttributeName.LAYERID, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute CTM
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CTM </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCTM(JDFMatrix @value)
      {
         setAttribute(AttributeName.CTM, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFMatrix attribute CTM </summary>
      ///          * <returns> JDFMatrix the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFMatrix </returns>
      ///          
      public virtual JDFMatrix getCTM()
      {
         string strAttrName = "";
         JDFMatrix nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.CTM, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFMatrix(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Ord
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Ord </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setOrd(int @value)
      {
         setAttribute(AttributeName.ORD, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute Ord </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getOrd()
      {
         return getIntAttribute(AttributeName.ORD, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TrimSize
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TrimSize </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTrimSize(JDFXYPair @value)
      {
         setAttribute(AttributeName.TRIMSIZE, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute TrimSize </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getTrimSize()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.TRIMSIZE, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute HalfTonePhaseOrigin
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute HalfTonePhaseOrigin </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setHalfTonePhaseOrigin(JDFXYPair @value)
      {
         setAttribute(AttributeName.HALFTONEPHASEORIGIN, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute HalfTonePhaseOrigin </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getHalfTonePhaseOrigin()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.HALFTONEPHASEORIGIN, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute OrdExpression
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute OrdExpression </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setOrdExpression(string @value)
      {
         setAttribute(AttributeName.ORDEXPRESSION, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute OrdExpression </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getOrdExpression()
      {
         return getAttribute(AttributeName.ORDEXPRESSION, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute OrdID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute OrdID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setOrdID(int @value)
      {
         setAttribute(AttributeName.ORDID, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute OrdID </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getOrdID()
      {
         return getIntAttribute(AttributeName.ORDID, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TrimCTM
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TrimCTM </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTrimCTM(JDFMatrix @value)
      {
         setAttribute(AttributeName.TRIMCTM, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFMatrix attribute TrimCTM </summary>
      ///          * <returns> JDFMatrix the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFMatrix </returns>
      ///          
      public virtual JDFMatrix getTrimCTM()
      {
         string strAttrName = "";
         JDFMatrix nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.TRIMCTM, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFMatrix(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute DocOrd
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DocOrd </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDocOrd(int @value)
      {
         setAttribute(AttributeName.DOCORD, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute DocOrd </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getDocOrd()
      {
         return getIntAttribute(AttributeName.DOCORD, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ClipBox
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ClipBox </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setClipBox(JDFRectangle @value)
      {
         setAttribute(AttributeName.CLIPBOX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFRectangle attribute ClipBox </summary>
      ///          * <returns> JDFRectangle the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFRectangle </returns>
      ///          
      public virtual JDFRectangle getClipBox()
      {
         string strAttrName = "";
         JDFRectangle nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.CLIPBOX, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute ClipPath
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ClipPath </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setClipPath(string @value)
      {
         setAttribute(AttributeName.CLIPPATH, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ClipPath </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getClipPath()
      {
         return getAttribute(AttributeName.CLIPPATH, null, JDFConstants.EMPTYSTRING);
      }
   }
}
