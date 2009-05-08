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
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using VString = org.cip4.jdflib.core.VString;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFFileSpec = org.cip4.jdflib.resource.process.JDFFileSpec;

   public abstract class JDFAutoImageReplacementParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[7];
      static JDFAutoImageReplacementParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.IMAGEREPLACEMENTSTRATEGY, 0x22222222, AttributeInfo.EnumAttributeType.enumeration, EnumImageReplacementStrategy.getEnum(0), null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.IMAGEPRESCANSTRATEGY, 0x33333311, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.MAXRESOLUTION, 0x44444443, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.MINRESOLUTION, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.RESOLUTIONREDUCTIONSTRATEGY, 0x44444443, AttributeInfo.EnumAttributeType.enumeration, EnumResolutionReductionStrategy.getEnum(0), null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.IGNOREEXTENSIONS, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.MAXSEARCHRECURSION, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.FILESPEC, 0x22222221);
         elemInfoTable[1] = new ElemInfoTable(ElementName.SEARCHPATH, 0x44444443);
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
      ///     <summary> * Constructor for JDFAutoImageReplacementParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoImageReplacementParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoImageReplacementParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoImageReplacementParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoImageReplacementParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoImageReplacementParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoImageReplacementParams[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for ImageReplacementStrategy </summary>
      ///        

      public class EnumImageReplacementStrategy : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumImageReplacementStrategy(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumImageReplacementStrategy getEnum(string enumName)
         {
            return (EnumImageReplacementStrategy)getEnum(typeof(EnumImageReplacementStrategy), enumName);
         }

         public static EnumImageReplacementStrategy getEnum(int enumValue)
         {
            return (EnumImageReplacementStrategy)getEnum(typeof(EnumImageReplacementStrategy), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumImageReplacementStrategy));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumImageReplacementStrategy));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumImageReplacementStrategy));
         }

         public static readonly EnumImageReplacementStrategy Omit = new EnumImageReplacementStrategy("Omit");
         public static readonly EnumImageReplacementStrategy Proxy = new EnumImageReplacementStrategy("Proxy");
         public static readonly EnumImageReplacementStrategy Replace = new EnumImageReplacementStrategy("Replace");
         public static readonly EnumImageReplacementStrategy AttemptReplacement = new EnumImageReplacementStrategy("AttemptReplacement");
      }



      ///        
      ///        <summary> * Enumeration strings for ResolutionReductionStrategy </summary>
      ///        

      public class EnumResolutionReductionStrategy : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumResolutionReductionStrategy(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumResolutionReductionStrategy getEnum(string enumName)
         {
            return (EnumResolutionReductionStrategy)getEnum(typeof(EnumResolutionReductionStrategy), enumName);
         }

         public static EnumResolutionReductionStrategy getEnum(int enumValue)
         {
            return (EnumResolutionReductionStrategy)getEnum(typeof(EnumResolutionReductionStrategy), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumResolutionReductionStrategy));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumResolutionReductionStrategy));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumResolutionReductionStrategy));
         }

         public static readonly EnumResolutionReductionStrategy Downsample = new EnumResolutionReductionStrategy("Downsample");
         public static readonly EnumResolutionReductionStrategy Subsample = new EnumResolutionReductionStrategy("Subsample");
         public static readonly EnumResolutionReductionStrategy Bicubic = new EnumResolutionReductionStrategy("Bicubic");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute ImageReplacementStrategy
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute ImageReplacementStrategy </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setImageReplacementStrategy(EnumImageReplacementStrategy enumVar)
      {
         setAttribute(AttributeName.IMAGEREPLACEMENTSTRATEGY, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute ImageReplacementStrategy </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumImageReplacementStrategy getImageReplacementStrategy()
      {
         return EnumImageReplacementStrategy.getEnum(getAttribute(AttributeName.IMAGEREPLACEMENTSTRATEGY, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ImagePreScanStrategy
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ImagePreScanStrategy </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setImagePreScanStrategy(string @value)
      {
         setAttribute(AttributeName.IMAGEPRESCANSTRATEGY, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ImagePreScanStrategy </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getImagePreScanStrategy()
      {
         return getAttribute(AttributeName.IMAGEPRESCANSTRATEGY, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MaxResolution
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MaxResolution </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMaxResolution(double @value)
      {
         setAttribute(AttributeName.MAXRESOLUTION, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute MaxResolution </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getMaxResolution()
      {
         return getRealAttribute(AttributeName.MAXRESOLUTION, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MinResolution
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MinResolution </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMinResolution(double @value)
      {
         setAttribute(AttributeName.MINRESOLUTION, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute MinResolution </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getMinResolution()
      {
         return getRealAttribute(AttributeName.MINRESOLUTION, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ResolutionReductionStrategy
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute ResolutionReductionStrategy </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setResolutionReductionStrategy(EnumResolutionReductionStrategy enumVar)
      {
         setAttribute(AttributeName.RESOLUTIONREDUCTIONSTRATEGY, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute ResolutionReductionStrategy </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumResolutionReductionStrategy getResolutionReductionStrategy()
      {
         return EnumResolutionReductionStrategy.getEnum(getAttribute(AttributeName.RESOLUTIONREDUCTIONSTRATEGY, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute IgnoreExtensions
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute IgnoreExtensions </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setIgnoreExtensions(VString @value)
      {
         setAttribute(AttributeName.IGNOREEXTENSIONS, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute IgnoreExtensions </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getIgnoreExtensions()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.IGNOREEXTENSIONS, null, JDFConstants.EMPTYSTRING);
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MaxSearchRecursion
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MaxSearchRecursion </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMaxSearchRecursion(int @value)
      {
         setAttribute(AttributeName.MAXSEARCHRECURSION, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute MaxSearchRecursion </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getMaxSearchRecursion()
      {
         return getIntAttribute(AttributeName.MAXSEARCHRECURSION, null, 0);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

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

      ///     <summary> (26) getCreateSearchPath
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFElement the element </returns>
      ///     
      public virtual JDFElement getCreateSearchPath(int iSkip)
      {
         return (JDFElement)getCreateElement_KElement(ElementName.SEARCHPATH, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element SearchPath </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFElement the element </returns>
      ///     * default is getSearchPath(0)     
      public virtual JDFElement getSearchPath(int iSkip)
      {
         return (JDFElement)getElement(ElementName.SEARCHPATH, null, iSkip);
      }

      ///    
      ///     <summary> * Get all SearchPath from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFElement> </returns>
      ///     
      public virtual ICollection<JDFElement> getAllSearchPath()
      {
         List<JDFElement> v = new List<JDFElement>();

         JDFElement kElem = (JDFElement)getFirstChildElement(ElementName.SEARCHPATH, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFElement)kElem.getNextSiblingElement(ElementName.SEARCHPATH, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element SearchPath </summary>
      ///     
      public virtual JDFElement appendSearchPath()
      {
         return (JDFElement)appendElement(ElementName.SEARCHPATH, null);
      }
   }
}
