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

   public abstract class JDFAutoBoxArgument : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[4];
      static JDFAutoBoxArgument()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.BOX, 0x22222222, AttributeInfo.EnumAttributeType.enumeration, EnumBox.getEnum(0), null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.MIRRORMARGINS, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumMirrorMargins.getEnum(0), null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.OFFSET, 0x33333333, AttributeInfo.EnumAttributeType.rectangle, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.OVERLAP, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoBoxArgument </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoBoxArgument(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoBoxArgument </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoBoxArgument(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoBoxArgument </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoBoxArgument(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoBoxArgument[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for Box </summary>
      ///        

      public class EnumBox : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumBox(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumBox getEnum(string enumName)
         {
            return (EnumBox)getEnum(typeof(EnumBox), enumName);
         }

         public static EnumBox getEnum(int enumValue)
         {
            return (EnumBox)getEnum(typeof(EnumBox), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumBox));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumBox));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumBox));
         }

         public static readonly EnumBox ArtBox = new EnumBox("ArtBox");
         public static readonly EnumBox BleedBox = new EnumBox("BleedBox");
         public static readonly EnumBox CropBox = new EnumBox("CropBox");
         public static readonly EnumBox MarginsBox = new EnumBox("MarginsBox");
         public static readonly EnumBox MediaBox = new EnumBox("MediaBox");
         public static readonly EnumBox SlugBox = new EnumBox("SlugBox");
         public static readonly EnumBox TrimBox = new EnumBox("TrimBox");
      }



      ///        
      ///        <summary> * Enumeration strings for MirrorMargins </summary>
      ///        

      public class EnumMirrorMargins : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumMirrorMargins(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumMirrorMargins getEnum(string enumName)
         {
            return (EnumMirrorMargins)getEnum(typeof(EnumMirrorMargins), enumName);
         }

         public static EnumMirrorMargins getEnum(int enumValue)
         {
            return (EnumMirrorMargins)getEnum(typeof(EnumMirrorMargins), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumMirrorMargins));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumMirrorMargins));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumMirrorMargins));
         }

         public static readonly EnumMirrorMargins Vertical = new EnumMirrorMargins("Vertical");
         public static readonly EnumMirrorMargins Horizontal = new EnumMirrorMargins("Horizontal");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute Box
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Box </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setBox(EnumBox enumVar)
      {
         setAttribute(AttributeName.BOX, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Box </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumBox getBox()
      {
         return EnumBox.getEnum(getAttribute(AttributeName.BOX, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MirrorMargins
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute MirrorMargins </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setMirrorMargins(EnumMirrorMargins enumVar)
      {
         setAttribute(AttributeName.MIRRORMARGINS, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute MirrorMargins </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumMirrorMargins getMirrorMargins()
      {
         return EnumMirrorMargins.getEnum(getAttribute(AttributeName.MIRRORMARGINS, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Offset
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Offset </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setOffset(JDFRectangle @value)
      {
         setAttribute(AttributeName.OFFSET, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFRectangle attribute Offset </summary>
      ///          * <returns> JDFRectangle the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFRectangle </returns>
      ///          
      public virtual JDFRectangle getOffset()
      {
         string strAttrName = "";
         JDFRectangle nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.OFFSET, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute Overlap
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Overlap </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setOverlap(bool @value)
      {
         setAttribute(AttributeName.OVERLAP, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute Overlap </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getOverlap()
      {
         return getBoolAttribute(AttributeName.OVERLAP, null, false);
      }
   }
}
