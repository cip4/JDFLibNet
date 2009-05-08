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
   using System.Collections.Generic;


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
   using JDFBand = org.cip4.jdflib.resource.JDFBand;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFColorPool = org.cip4.jdflib.resource.process.JDFColorPool;
   using JDFFileSpec = org.cip4.jdflib.resource.process.JDFFileSpec;
   using JDFPixelColorant = org.cip4.jdflib.resource.process.JDFPixelColorant;

   public abstract class JDFAutoByteMap : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[7];
      static JDFAutoByteMap()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.FRAMEHEIGHT, 0x22222222, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.FRAMEWIDTH, 0x22222222, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.HALFTONED, 0x22222222, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.INTERLEAVED, 0x22222222, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.RESOLUTION, 0x22222222, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.BANDORDERING, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumBandOrdering.getEnum(0), null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.PIXELSKIP, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.BAND, 0x22222222);
         elemInfoTable[1] = new ElemInfoTable(ElementName.COLORPOOL, 0x66666611);
         elemInfoTable[2] = new ElemInfoTable(ElementName.FILESPEC, 0x33333333);
         elemInfoTable[3] = new ElemInfoTable(ElementName.PIXELCOLORANT, 0x22222222);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[4];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoByteMap </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoByteMap(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoByteMap </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoByteMap(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoByteMap </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoByteMap(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoByteMap[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for BandOrdering </summary>
      ///        

      public class EnumBandOrdering : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumBandOrdering(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumBandOrdering getEnum(string enumName)
         {
            return (EnumBandOrdering)getEnum(typeof(EnumBandOrdering), enumName);
         }

         public static EnumBandOrdering getEnum(int enumValue)
         {
            return (EnumBandOrdering)getEnum(typeof(EnumBandOrdering), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumBandOrdering));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumBandOrdering));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumBandOrdering));
         }

         public static readonly EnumBandOrdering BandMajor = new EnumBandOrdering("BandMajor");
         public static readonly EnumBandOrdering ColorMajor = new EnumBandOrdering("ColorMajor");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute FrameHeight
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute FrameHeight </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFrameHeight(int @value)
      {
         setAttribute(AttributeName.FRAMEHEIGHT, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute FrameHeight </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getFrameHeight()
      {
         return getIntAttribute(AttributeName.FRAMEHEIGHT, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute FrameWidth
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute FrameWidth </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFrameWidth(int @value)
      {
         setAttribute(AttributeName.FRAMEWIDTH, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute FrameWidth </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getFrameWidth()
      {
         return getIntAttribute(AttributeName.FRAMEWIDTH, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Halftoned
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Halftoned </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setHalftoned(bool @value)
      {
         setAttribute(AttributeName.HALFTONED, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute Halftoned </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getHalftoned()
      {
         return getBoolAttribute(AttributeName.HALFTONED, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Interleaved
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Interleaved </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setInterleaved(bool @value)
      {
         setAttribute(AttributeName.INTERLEAVED, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute Interleaved </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getInterleaved()
      {
         return getBoolAttribute(AttributeName.INTERLEAVED, null, false);
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


      //         ---------------------------------------------------------------------
      //        Methods for Attribute BandOrdering
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute BandOrdering </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setBandOrdering(EnumBandOrdering enumVar)
      {
         setAttribute(AttributeName.BANDORDERING, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute BandOrdering </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumBandOrdering getBandOrdering()
      {
         return EnumBandOrdering.getEnum(getAttribute(AttributeName.BANDORDERING, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PixelSkip
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PixelSkip </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPixelSkip(int @value)
      {
         setAttribute(AttributeName.PIXELSKIP, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute PixelSkip </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getPixelSkip()
      {
         return getIntAttribute(AttributeName.PIXELSKIP, null, 0);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateBand
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFBand the element </returns>
      ///     
      public virtual JDFBand getCreateBand(int iSkip)
      {
         return (JDFBand)getCreateElement_KElement(ElementName.BAND, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Band </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFBand the element </returns>
      ///     * default is getBand(0)     
      public virtual JDFBand getBand(int iSkip)
      {
         return (JDFBand)getElement(ElementName.BAND, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Band from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFBand> </returns>
      ///     
      public virtual ICollection<JDFBand> getAllBand()
      {
         List<JDFBand> v = new List<JDFBand>();

         JDFBand kElem = (JDFBand)getFirstChildElement(ElementName.BAND, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFBand)kElem.getNextSiblingElement(ElementName.BAND, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Band </summary>
      ///     
      public virtual JDFBand appendBand()
      {
         return (JDFBand)appendElement(ElementName.BAND, null);
      }

      ///    
      ///     <summary> * (24) const get element ColorPool </summary>
      ///     * <returns> JDFColorPool the element </returns>
      ///     
      public virtual JDFColorPool getColorPool()
      {
         return (JDFColorPool)getElement(ElementName.COLORPOOL, null, 0);
      }

      ///     <summary> (25) getCreateColorPool
      ///     *  </summary>
      ///     * <returns> JDFColorPool the element </returns>
      ///     
      public virtual JDFColorPool getCreateColorPool()
      {
         return (JDFColorPool)getCreateElement_KElement(ElementName.COLORPOOL, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ColorPool </summary>
      ///     
      public virtual JDFColorPool appendColorPool()
      {
         return (JDFColorPool)appendElementN(ElementName.COLORPOOL, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refColorPool(JDFColorPool refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreateFileSpec
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFFileSpec the element </returns>
      ///     
      public virtual JDFFileSpec getCreateFileSpec(int iSkip)
      {
         return (JDFFileSpec)getCreateElement_KElement(ElementName.FILESPEC, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element FileSpec </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFFileSpec the element </returns>
      ///     * default is getFileSpec(0)     
      public virtual JDFFileSpec getFileSpec(int iSkip)
      {
         return (JDFFileSpec)getElement(ElementName.FILESPEC, null, iSkip);
      }

      ///    
      ///     <summary> * Get all FileSpec from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFFileSpec> </returns>
      ///     
      public virtual ICollection<JDFFileSpec> getAllFileSpec()
      {
         List<JDFFileSpec> v = new List<JDFFileSpec>();

         JDFFileSpec kElem = (JDFFileSpec)getFirstChildElement(ElementName.FILESPEC, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFFileSpec)kElem.getNextSiblingElement(ElementName.FILESPEC, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element FileSpec </summary>
      ///     
      public virtual JDFFileSpec appendFileSpec()
      {
         return (JDFFileSpec)appendElement(ElementName.FILESPEC, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refFileSpec(JDFFileSpec refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreatePixelColorant
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFPixelColorant the element </returns>
      ///     
      public virtual JDFPixelColorant getCreatePixelColorant(int iSkip)
      {
         return (JDFPixelColorant)getCreateElement_KElement(ElementName.PIXELCOLORANT, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element PixelColorant </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFPixelColorant the element </returns>
      ///     * default is getPixelColorant(0)     
      public virtual JDFPixelColorant getPixelColorant(int iSkip)
      {
         return (JDFPixelColorant)getElement(ElementName.PIXELCOLORANT, null, iSkip);
      }

      ///    
      ///     <summary> * Get all PixelColorant from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFPixelColorant> </returns>
      ///     
      public virtual ICollection<JDFPixelColorant> getAllPixelColorant()
      {
         List<JDFPixelColorant> v = new List<JDFPixelColorant>();

         JDFPixelColorant kElem = (JDFPixelColorant)getFirstChildElement(ElementName.PIXELCOLORANT, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFPixelColorant)kElem.getNextSiblingElement(ElementName.PIXELCOLORANT, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element PixelColorant </summary>
      ///     
      public virtual JDFPixelColorant appendPixelColorant()
      {
         return (JDFPixelColorant)appendElement(ElementName.PIXELCOLORANT, null);
      }
   }
}
