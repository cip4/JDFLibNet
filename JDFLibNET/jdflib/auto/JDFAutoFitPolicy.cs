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

   public abstract class JDFAutoFitPolicy : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[5];
      static JDFAutoFitPolicy()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.GUTTERPOLICY, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumGutterPolicy.getEnum(0), "Fixed");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.CLIPOFFSET, 0x33333331, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.MINGUTTER, 0x33333331, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.ROTATEPOLICY, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumRotatePolicy.getEnum(0), null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.SIZEPOLICY, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumSizePolicy.getEnum(0), null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoFitPolicy </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoFitPolicy(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoFitPolicy </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoFitPolicy(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoFitPolicy </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoFitPolicy(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoFitPolicy[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for GutterPolicy </summary>
      ///        

      public class EnumGutterPolicy : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumGutterPolicy(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumGutterPolicy getEnum(string enumName)
         {
            return (EnumGutterPolicy)getEnum(typeof(EnumGutterPolicy), enumName);
         }

         public static EnumGutterPolicy getEnum(int enumValue)
         {
            return (EnumGutterPolicy)getEnum(typeof(EnumGutterPolicy), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumGutterPolicy));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumGutterPolicy));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumGutterPolicy));
         }

         public static readonly EnumGutterPolicy Distribute = new EnumGutterPolicy("Distribute");
         public static readonly EnumGutterPolicy Fixed = new EnumGutterPolicy("Fixed");
      }



      ///        
      ///        <summary> * Enumeration strings for RotatePolicy </summary>
      ///        

      public class EnumRotatePolicy : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumRotatePolicy(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumRotatePolicy getEnum(string enumName)
         {
            return (EnumRotatePolicy)getEnum(typeof(EnumRotatePolicy), enumName);
         }

         public static EnumRotatePolicy getEnum(int enumValue)
         {
            return (EnumRotatePolicy)getEnum(typeof(EnumRotatePolicy), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumRotatePolicy));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumRotatePolicy));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumRotatePolicy));
         }

         public static readonly EnumRotatePolicy NoRotate = new EnumRotatePolicy("NoRotate");
         public static readonly EnumRotatePolicy RotateOrthogonal = new EnumRotatePolicy("RotateOrthogonal");
         public static readonly EnumRotatePolicy RotateClockwise = new EnumRotatePolicy("RotateClockwise");
         public static readonly EnumRotatePolicy RotateCounterClockwise = new EnumRotatePolicy("RotateCounterClockwise");
      }



      ///        
      ///        <summary> * Enumeration strings for SizePolicy </summary>
      ///        

      public class EnumSizePolicy : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumSizePolicy(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumSizePolicy getEnum(string enumName)
         {
            return (EnumSizePolicy)getEnum(typeof(EnumSizePolicy), enumName);
         }

         public static EnumSizePolicy getEnum(int enumValue)
         {
            return (EnumSizePolicy)getEnum(typeof(EnumSizePolicy), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumSizePolicy));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumSizePolicy));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumSizePolicy));
         }

         public static readonly EnumSizePolicy ClipToMaxPage = new EnumSizePolicy("ClipToMaxPage");
         public static readonly EnumSizePolicy Abort = new EnumSizePolicy("Abort");
         public static readonly EnumSizePolicy FitToPage = new EnumSizePolicy("FitToPage");
         public static readonly EnumSizePolicy ReduceToFit = new EnumSizePolicy("ReduceToFit");
         public static readonly EnumSizePolicy Tile = new EnumSizePolicy("Tile");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute GutterPolicy
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute GutterPolicy </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setGutterPolicy(EnumGutterPolicy enumVar)
      {
         setAttribute(AttributeName.GUTTERPOLICY, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute GutterPolicy </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumGutterPolicy getGutterPolicy()
      {
         return EnumGutterPolicy.getEnum(getAttribute(AttributeName.GUTTERPOLICY, null, "Fixed"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ClipOffset
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ClipOffset </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setClipOffset(JDFXYPair @value)
      {
         setAttribute(AttributeName.CLIPOFFSET, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute ClipOffset </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getClipOffset()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.CLIPOFFSET, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute MinGutter
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MinGutter </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMinGutter(JDFXYPair @value)
      {
         setAttribute(AttributeName.MINGUTTER, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute MinGutter </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getMinGutter()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.MINGUTTER, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute RotatePolicy
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute RotatePolicy </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setRotatePolicy(EnumRotatePolicy enumVar)
      {
         setAttribute(AttributeName.ROTATEPOLICY, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute RotatePolicy </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumRotatePolicy getRotatePolicy()
      {
         return EnumRotatePolicy.getEnum(getAttribute(AttributeName.ROTATEPOLICY, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SizePolicy
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute SizePolicy </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setSizePolicy(EnumSizePolicy enumVar)
      {
         setAttribute(AttributeName.SIZEPOLICY, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute SizePolicy </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumSizePolicy getSizePolicy()
      {
         return EnumSizePolicy.getEnum(getAttribute(AttributeName.SIZEPOLICY, null, null));
      }
   }
}
