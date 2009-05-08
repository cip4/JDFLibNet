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
   using System.Collections.Generic;


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFAutomatedOverPrintParams = org.cip4.jdflib.resource.process.JDFAutomatedOverPrintParams;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;
   using JDFObjectResolution = org.cip4.jdflib.resource.process.JDFObjectResolution;

   public abstract class JDFAutoRenderingParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[5];
      static JDFAutoRenderingParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.BANDHEIGHT, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.BANDORDERING, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumBandOrdering.getEnum(0), null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.BANDWIDTH, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.COLORANTDEPTH, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.INTERLEAVED, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.AUTOMATEDOVERPRINTPARAMS, 0x66666666);
         elemInfoTable[1] = new ElemInfoTable(ElementName.OBJECTRESOLUTION, 0x33333333);
         elemInfoTable[2] = new ElemInfoTable(ElementName.MEDIA, 0x77777761);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[3];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoRenderingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoRenderingParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoRenderingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoRenderingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoRenderingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoRenderingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoRenderingParams[  --> " + base.ToString() + " ]";
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
      //        Methods for Attribute BandHeight
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BandHeight </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBandHeight(int @value)
      {
         setAttribute(AttributeName.BANDHEIGHT, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute BandHeight </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getBandHeight()
      {
         return getIntAttribute(AttributeName.BANDHEIGHT, null, 0);
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
      //        Methods for Attribute BandWidth
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BandWidth </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBandWidth(int @value)
      {
         setAttribute(AttributeName.BANDWIDTH, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute BandWidth </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getBandWidth()
      {
         return getIntAttribute(AttributeName.BANDWIDTH, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ColorantDepth
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ColorantDepth </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setColorantDepth(int @value)
      {
         setAttribute(AttributeName.COLORANTDEPTH, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute ColorantDepth </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getColorantDepth()
      {
         return getIntAttribute(AttributeName.COLORANTDEPTH, null, 0);
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

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element AutomatedOverPrintParams </summary>
      ///     * <returns> JDFAutomatedOverPrintParams the element </returns>
      ///     
      public virtual JDFAutomatedOverPrintParams getAutomatedOverPrintParams()
      {
         return (JDFAutomatedOverPrintParams)getElement(ElementName.AUTOMATEDOVERPRINTPARAMS, null, 0);
      }

      ///     <summary> (25) getCreateAutomatedOverPrintParams
      ///     *  </summary>
      ///     * <returns> JDFAutomatedOverPrintParams the element </returns>
      ///     
      public virtual JDFAutomatedOverPrintParams getCreateAutomatedOverPrintParams()
      {
         return (JDFAutomatedOverPrintParams)getCreateElement_KElement(ElementName.AUTOMATEDOVERPRINTPARAMS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element AutomatedOverPrintParams </summary>
      ///     
      public virtual JDFAutomatedOverPrintParams appendAutomatedOverPrintParams()
      {
         return (JDFAutomatedOverPrintParams)appendElementN(ElementName.AUTOMATEDOVERPRINTPARAMS, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refAutomatedOverPrintParams(JDFAutomatedOverPrintParams refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreateObjectResolution
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFObjectResolution the element </returns>
      ///     
      public virtual JDFObjectResolution getCreateObjectResolution(int iSkip)
      {
         return (JDFObjectResolution)getCreateElement_KElement(ElementName.OBJECTRESOLUTION, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element ObjectResolution </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFObjectResolution the element </returns>
      ///     * default is getObjectResolution(0)     
      public virtual JDFObjectResolution getObjectResolution(int iSkip)
      {
         return (JDFObjectResolution)getElement(ElementName.OBJECTRESOLUTION, null, iSkip);
      }

      ///    
      ///     <summary> * Get all ObjectResolution from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFObjectResolution> </returns>
      ///     
      public virtual ICollection<JDFObjectResolution> getAllObjectResolution()
      {
         List<JDFObjectResolution> v = new List<JDFObjectResolution>();

         JDFObjectResolution kElem = (JDFObjectResolution)getFirstChildElement(ElementName.OBJECTRESOLUTION, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFObjectResolution)kElem.getNextSiblingElement(ElementName.OBJECTRESOLUTION, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element ObjectResolution </summary>
      ///     
      public virtual JDFObjectResolution appendObjectResolution()
      {
         return (JDFObjectResolution)appendElement(ElementName.OBJECTRESOLUTION, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refObjectResolution(JDFObjectResolution refTarget)
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
