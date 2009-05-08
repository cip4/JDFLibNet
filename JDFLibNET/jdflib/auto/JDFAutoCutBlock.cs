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
   using VString = org.cip4.jdflib.core.VString;
   using JDFMatrix = org.cip4.jdflib.datatypes.JDFMatrix;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;

   public abstract class JDFAutoCutBlock : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[7];
      static JDFAutoCutBlock()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.BLOCKSIZE, 0x22222222, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.BLOCKSUBDIVISION, 0x33333333, AttributeInfo.EnumAttributeType.XYPair, null, "1 1");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.BLOCKTRF, 0x33333333, AttributeInfo.EnumAttributeType.matrix, null, "1 0 0 1 0 0");
         atrInfoTable[3] = new AtrInfoTable(AttributeName.BLOCKTYPE, 0x22222222, AttributeInfo.EnumAttributeType.enumeration, EnumBlockType.getEnum(0), null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.ASSEMBLYIDS, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.BLOCKELEMENTSIZE, 0x33333333, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.BLOCKELEMENTTYPE, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumBlockElementType.getEnum(0), null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoCutBlock </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoCutBlock(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoCutBlock </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoCutBlock(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoCutBlock </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoCutBlock(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoCutBlock[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for BlockType </summary>
      ///        

      public class EnumBlockType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumBlockType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumBlockType getEnum(string enumName)
         {
            return (EnumBlockType)getEnum(typeof(EnumBlockType), enumName);
         }

         public static EnumBlockType getEnum(int enumValue)
         {
            return (EnumBlockType)getEnum(typeof(EnumBlockType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumBlockType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumBlockType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumBlockType));
         }

         public static readonly EnumBlockType CutBlock = new EnumBlockType("CutBlock");
         public static readonly EnumBlockType SaveBlock = new EnumBlockType("SaveBlock");
         public static readonly EnumBlockType TempBlock = new EnumBlockType("TempBlock");
         public static readonly EnumBlockType MarkBlock = new EnumBlockType("MarkBlock");
      }



      ///        
      ///        <summary> * Enumeration strings for BlockElementType </summary>
      ///        

      public class EnumBlockElementType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumBlockElementType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumBlockElementType getEnum(string enumName)
         {
            return (EnumBlockElementType)getEnum(typeof(EnumBlockElementType), enumName);
         }

         public static EnumBlockElementType getEnum(int enumValue)
         {
            return (EnumBlockElementType)getEnum(typeof(EnumBlockElementType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumBlockElementType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumBlockElementType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumBlockElementType));
         }

         public static readonly EnumBlockElementType CutElement = new EnumBlockElementType("CutElement");
         public static readonly EnumBlockElementType PunchElement = new EnumBlockElementType("PunchElement");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute BlockSize
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BlockSize </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBlockSize(JDFXYPair @value)
      {
         setAttribute(AttributeName.BLOCKSIZE, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute BlockSize </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getBlockSize()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.BLOCKSIZE, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute BlockSubdivision
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BlockSubdivision </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBlockSubdivision(JDFXYPair @value)
      {
         setAttribute(AttributeName.BLOCKSUBDIVISION, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute BlockSubdivision </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getBlockSubdivision()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.BLOCKSUBDIVISION, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute BlockTrf
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BlockTrf </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBlockTrf(JDFMatrix @value)
      {
         setAttribute(AttributeName.BLOCKTRF, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFMatrix attribute BlockTrf </summary>
      ///          * <returns> JDFMatrix the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFMatrix </returns>
      ///          
      public virtual JDFMatrix getBlockTrf()
      {
         string strAttrName = "";
         JDFMatrix nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.BLOCKTRF, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute BlockType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute BlockType </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setBlockType(EnumBlockType enumVar)
      {
         setAttribute(AttributeName.BLOCKTYPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute BlockType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumBlockType getBlockType()
      {
         return EnumBlockType.getEnum(getAttribute(AttributeName.BLOCKTYPE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute AssemblyIDs
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute AssemblyIDs </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAssemblyIDs(VString @value)
      {
         setAttribute(AttributeName.ASSEMBLYIDS, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute AssemblyIDs </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getAssemblyIDs()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.ASSEMBLYIDS, null, JDFConstants.EMPTYSTRING);
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute BlockElementSize
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BlockElementSize </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBlockElementSize(JDFXYPair @value)
      {
         setAttribute(AttributeName.BLOCKELEMENTSIZE, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute BlockElementSize </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getBlockElementSize()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.BLOCKELEMENTSIZE, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute BlockElementType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute BlockElementType </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setBlockElementType(EnumBlockElementType enumVar)
      {
         setAttribute(AttributeName.BLOCKELEMENTTYPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute BlockElementType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumBlockElementType getBlockElementType()
      {
         return EnumBlockElementType.getEnum(getAttribute(AttributeName.BLOCKELEMENTTYPE, null, null));
      }
   }
}
