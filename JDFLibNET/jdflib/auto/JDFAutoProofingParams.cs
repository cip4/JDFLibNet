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
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFFileSpec = org.cip4.jdflib.resource.process.JDFFileSpec;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;

   public abstract class JDFAutoProofingParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[8];
      static JDFAutoProofingParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.DISPLAYTRAPS, 0x44444433, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.HALFTONE, 0x44444433, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.IMAGEVIEWINGSTRATEGY, 0x44444433, AttributeInfo.EnumAttributeType.string_, null, "NoImages");
         atrInfoTable[3] = new AtrInfoTable(AttributeName.MANUALFEED, 0x44444431, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[4] = new AtrInfoTable(AttributeName.PROOFRENDERINGINTENT, 0x44444431, AttributeInfo.EnumAttributeType.enumeration, EnumProofRenderingIntent.getEnum(0), "Perceptual");
         atrInfoTable[5] = new AtrInfoTable(AttributeName.PROOFTYPE, 0x44444433, AttributeInfo.EnumAttributeType.enumeration, EnumProofType.getEnum(0), "None");
         atrInfoTable[6] = new AtrInfoTable(AttributeName.COLORTYPE, 0x44444433, AttributeInfo.EnumAttributeType.enumeration, EnumColorType.getEnum(0), null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.RESOLUTION, 0x44444433, AttributeInfo.EnumAttributeType.XYPair, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.FILESPEC, 0x77777766);
         elemInfoTable[1] = new ElemInfoTable(ElementName.MEDIA, 0x77777766);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[2];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoProofingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoProofingParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoProofingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoProofingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoProofingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoProofingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoProofingParams[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for ProofRenderingIntent </summary>
      ///        

      public class EnumProofRenderingIntent : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumProofRenderingIntent(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumProofRenderingIntent getEnum(string enumName)
         {
            return (EnumProofRenderingIntent)getEnum(typeof(EnumProofRenderingIntent), enumName);
         }

         public static EnumProofRenderingIntent getEnum(int enumValue)
         {
            return (EnumProofRenderingIntent)getEnum(typeof(EnumProofRenderingIntent), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumProofRenderingIntent));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumProofRenderingIntent));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumProofRenderingIntent));
         }

         public static readonly EnumProofRenderingIntent Saturation = new EnumProofRenderingIntent("Saturation");
         public static readonly EnumProofRenderingIntent Perceptual = new EnumProofRenderingIntent("Perceptual");
         public static readonly EnumProofRenderingIntent RelativeColorimetric = new EnumProofRenderingIntent("RelativeColorimetric");
         public static readonly EnumProofRenderingIntent AbsoluteColorimetric = new EnumProofRenderingIntent("AbsoluteColorimetric");
      }



      ///        
      ///        <summary> * Enumeration strings for ProofType </summary>
      ///        

      public class EnumProofType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumProofType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumProofType getEnum(string enumName)
         {
            return (EnumProofType)getEnum(typeof(EnumProofType), enumName);
         }

         public static EnumProofType getEnum(int enumValue)
         {
            return (EnumProofType)getEnum(typeof(EnumProofType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumProofType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumProofType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumProofType));
         }

         public static readonly EnumProofType None = new EnumProofType("None");
         public static readonly EnumProofType Page = new EnumProofType("Page");
         public static readonly EnumProofType Imposition = new EnumProofType("Imposition");
      }



      ///        
      ///        <summary> * Enumeration strings for ColorType </summary>
      ///        

      public class EnumColorType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumColorType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumColorType getEnum(string enumName)
         {
            return (EnumColorType)getEnum(typeof(EnumColorType), enumName);
         }

         public static EnumColorType getEnum(int enumValue)
         {
            return (EnumColorType)getEnum(typeof(EnumColorType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumColorType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumColorType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumColorType));
         }

         public static readonly EnumColorType Monochrome = new EnumColorType("Monochrome");
         public static readonly EnumColorType BasicColor = new EnumColorType("BasicColor");
         public static readonly EnumColorType MatchedColor = new EnumColorType("MatchedColor");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute DisplayTraps
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DisplayTraps </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDisplayTraps(bool @value)
      {
         setAttribute(AttributeName.DISPLAYTRAPS, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute DisplayTraps </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getDisplayTraps()
      {
         return getBoolAttribute(AttributeName.DISPLAYTRAPS, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute HalfTone
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute HalfTone </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setHalfTone(bool @value)
      {
         setAttribute(AttributeName.HALFTONE, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute HalfTone </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getHalfTone()
      {
         return getBoolAttribute(AttributeName.HALFTONE, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ImageViewingStrategy
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ImageViewingStrategy </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setImageViewingStrategy(string @value)
      {
         setAttribute(AttributeName.IMAGEVIEWINGSTRATEGY, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ImageViewingStrategy </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getImageViewingStrategy()
      {
         return getAttribute(AttributeName.IMAGEVIEWINGSTRATEGY, null, "NoImages");
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ManualFeed
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ManualFeed </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setManualFeed(bool @value)
      {
         setAttribute(AttributeName.MANUALFEED, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute ManualFeed </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getManualFeed()
      {
         return getBoolAttribute(AttributeName.MANUALFEED, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ProofRenderingIntent
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute ProofRenderingIntent </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setProofRenderingIntent(EnumProofRenderingIntent enumVar)
      {
         setAttribute(AttributeName.PROOFRENDERINGINTENT, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute ProofRenderingIntent </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumProofRenderingIntent getProofRenderingIntent()
      {
         return EnumProofRenderingIntent.getEnum(getAttribute(AttributeName.PROOFRENDERINGINTENT, null, "Perceptual"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ProofType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute ProofType </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setProofType(EnumProofType enumVar)
      {
         setAttribute(AttributeName.PROOFTYPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute ProofType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumProofType getProofType()
      {
         return EnumProofType.getEnum(getAttribute(AttributeName.PROOFTYPE, null, "None"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ColorType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute ColorType </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setColorType(EnumColorType enumVar)
      {
         setAttribute(AttributeName.COLORTYPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute ColorType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumColorType getColorType()
      {
         return EnumColorType.getEnum(getAttribute(AttributeName.COLORTYPE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Resolution
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Resolution </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setResolution(JDFXYPair @value)
      {
         setAttribute(AttributeName.RESOLUTION, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute Resolution </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getResolution()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.RESOLUTION, null, JDFConstants.EMPTYSTRING);
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

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element FileSpec </summary>
      ///     * <returns> JDFFileSpec the element </returns>
      ///     
      public virtual JDFFileSpec getFileSpec()
      {
         return (JDFFileSpec)getElement(ElementName.FILESPEC, null, 0);
      }

      ///     <summary> (25) getCreateFileSpec
      ///     *  </summary>
      ///     * <returns> JDFFileSpec the element </returns>
      ///     
      public virtual JDFFileSpec getCreateFileSpec()
      {
         return (JDFFileSpec)getCreateElement_KElement(ElementName.FILESPEC, null, 0);
      }

      ///    
      ///     <summary> * (29) append element FileSpec </summary>
      ///     
      public virtual JDFFileSpec appendFileSpec()
      {
         return (JDFFileSpec)appendElementN(ElementName.FILESPEC, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refFileSpec(JDFFileSpec refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element Media </summary>
      ///     * <returns> JDFMedia the element </returns>
      ///     
      public virtual JDFMedia getMedia()
      {
         return (JDFMedia)getElement(ElementName.MEDIA, null, 0);
      }

      ///     <summary> (25) getCreateMedia
      ///     *  </summary>
      ///     * <returns> JDFMedia the element </returns>
      ///     
      public virtual JDFMedia getCreateMedia()
      {
         return (JDFMedia)getCreateElement_KElement(ElementName.MEDIA, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Media </summary>
      ///     
      public virtual JDFMedia appendMedia()
      {
         return (JDFMedia)appendElementN(ElementName.MEDIA, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refMedia(JDFMedia refTarget)
      {
         refElement(refTarget);
      }
   }
}
