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
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using VString = org.cip4.jdflib.core.VString;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;

   public abstract class JDFAutoFontParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[6];
      static JDFAutoFontParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.EMBEDALLFONTS, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.CANNOTEMBEDFONTPOLICY, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumCannotEmbedFontPolicy.getEnum(0), "Warning");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.ALWAYSEMBED, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.MAXSUBSETPCT, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.NEVEREMBED, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.SUBSETFONTS, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoFontParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoFontParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoFontParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoFontParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoFontParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoFontParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoFontParams[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for CannotEmbedFontPolicy </summary>
      ///        

      public class EnumCannotEmbedFontPolicy : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumCannotEmbedFontPolicy(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumCannotEmbedFontPolicy getEnum(string enumName)
         {
            return (EnumCannotEmbedFontPolicy)getEnum(typeof(EnumCannotEmbedFontPolicy), enumName);
         }

         public static EnumCannotEmbedFontPolicy getEnum(int enumValue)
         {
            return (EnumCannotEmbedFontPolicy)getEnum(typeof(EnumCannotEmbedFontPolicy), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumCannotEmbedFontPolicy));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumCannotEmbedFontPolicy));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumCannotEmbedFontPolicy));
         }

         public static readonly EnumCannotEmbedFontPolicy Warning = new EnumCannotEmbedFontPolicy("Warning");
         public static readonly EnumCannotEmbedFontPolicy Error = new EnumCannotEmbedFontPolicy("Error");
         public static readonly EnumCannotEmbedFontPolicy OK = new EnumCannotEmbedFontPolicy("OK");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute EmbedAllFonts
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute EmbedAllFonts </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setEmbedAllFonts(bool @value)
      {
         setAttribute(AttributeName.EMBEDALLFONTS, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute EmbedAllFonts </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getEmbedAllFonts()
      {
         return getBoolAttribute(AttributeName.EMBEDALLFONTS, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute CannotEmbedFontPolicy
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute CannotEmbedFontPolicy </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setCannotEmbedFontPolicy(EnumCannotEmbedFontPolicy enumVar)
      {
         setAttribute(AttributeName.CANNOTEMBEDFONTPOLICY, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute CannotEmbedFontPolicy </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumCannotEmbedFontPolicy getCannotEmbedFontPolicy()
      {
         return EnumCannotEmbedFontPolicy.getEnum(getAttribute(AttributeName.CANNOTEMBEDFONTPOLICY, null, "Warning"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute AlwaysEmbed
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute AlwaysEmbed </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAlwaysEmbed(VString @value)
      {
         setAttribute(AttributeName.ALWAYSEMBED, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute AlwaysEmbed </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getAlwaysEmbed()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.ALWAYSEMBED, null, JDFConstants.EMPTYSTRING);
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MaxSubsetPct
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MaxSubsetPct </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMaxSubsetPct(int @value)
      {
         setAttribute(AttributeName.MAXSUBSETPCT, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute MaxSubsetPct </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getMaxSubsetPct()
      {
         return getIntAttribute(AttributeName.MAXSUBSETPCT, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute NeverEmbed
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute NeverEmbed </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setNeverEmbed(VString @value)
      {
         setAttribute(AttributeName.NEVEREMBED, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute NeverEmbed </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getNeverEmbed()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.NEVEREMBED, null, JDFConstants.EMPTYSTRING);
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SubsetFonts
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SubsetFonts </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSubsetFonts(bool @value)
      {
         setAttribute(AttributeName.SUBSETFONTS, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute SubsetFonts </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getSubsetFonts()
      {
         return getBoolAttribute(AttributeName.SUBSETFONTS, null, false);
      }
   }
}
