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
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFAutomatedOverPrintParams = org.cip4.jdflib.resource.process.JDFAutomatedOverPrintParams;
   using JDFColorantAlias = org.cip4.jdflib.resource.process.JDFColorantAlias;
   using JDFFileSpec = org.cip4.jdflib.resource.process.JDFFileSpec;
   using JDFColorSpaceConversionOp = org.cip4.jdflib.resource.process.prepress.JDFColorSpaceConversionOp;

   public abstract class JDFAutoElementColorParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[2];
      static JDFAutoElementColorParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.COLORMANAGEMENTSYSTEM, 0x33333311, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.ICCOUTPUTPROFILEUSAGE, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumICCOutputProfileUsage.getEnum(0), null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.AUTOMATEDOVERPRINTPARAMS, 0x66666611);
         elemInfoTable[1] = new ElemInfoTable(ElementName.COLORANTALIAS, 0x22222211);
         elemInfoTable[2] = new ElemInfoTable(ElementName.COLORSPACECONVERSIONOP, 0x66666611);
         elemInfoTable[3] = new ElemInfoTable(ElementName.FILESPEC, 0x66666611);
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
      ///     <summary> * Constructor for JDFAutoElementColorParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoElementColorParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoElementColorParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoElementColorParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoElementColorParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoElementColorParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoElementColorParams[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for ICCOutputProfileUsage </summary>
      ///        

      public class EnumICCOutputProfileUsage : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumICCOutputProfileUsage(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumICCOutputProfileUsage getEnum(string enumName)
         {
            return (EnumICCOutputProfileUsage)getEnum(typeof(EnumICCOutputProfileUsage), enumName);
         }

         public static EnumICCOutputProfileUsage getEnum(int enumValue)
         {
            return (EnumICCOutputProfileUsage)getEnum(typeof(EnumICCOutputProfileUsage), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumICCOutputProfileUsage));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumICCOutputProfileUsage));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumICCOutputProfileUsage));
         }

         public static readonly EnumICCOutputProfileUsage PDLActual = new EnumICCOutputProfileUsage("PDLActual");
         public static readonly EnumICCOutputProfileUsage PDLReference = new EnumICCOutputProfileUsage("PDLReference");
         public static readonly EnumICCOutputProfileUsage IgnorePDL = new EnumICCOutputProfileUsage("IgnorePDL");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute ColorManagementSystem
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ColorManagementSystem </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setColorManagementSystem(string @value)
      {
         setAttribute(AttributeName.COLORMANAGEMENTSYSTEM, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ColorManagementSystem </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getColorManagementSystem()
      {
         return getAttribute(AttributeName.COLORMANAGEMENTSYSTEM, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ICCOutputProfileUsage
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute ICCOutputProfileUsage </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setICCOutputProfileUsage(EnumICCOutputProfileUsage enumVar)
      {
         setAttribute(AttributeName.ICCOUTPUTPROFILEUSAGE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute ICCOutputProfileUsage </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumICCOutputProfileUsage getICCOutputProfileUsage()
      {
         return EnumICCOutputProfileUsage.getEnum(getAttribute(AttributeName.ICCOUTPUTPROFILEUSAGE, null, null));
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

      ///     <summary> (26) getCreateColorantAlias
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFColorantAlias the element </returns>
      ///     
      public virtual JDFColorantAlias getCreateColorantAlias(int iSkip)
      {
         return (JDFColorantAlias)getCreateElement_KElement(ElementName.COLORANTALIAS, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element ColorantAlias </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFColorantAlias the element </returns>
      ///     * default is getColorantAlias(0)     
      public virtual JDFColorantAlias getColorantAlias(int iSkip)
      {
         return (JDFColorantAlias)getElement(ElementName.COLORANTALIAS, null, iSkip);
      }

      ///    
      ///     <summary> * Get all ColorantAlias from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFColorantAlias> </returns>
      ///     
      public virtual ICollection<JDFColorantAlias> getAllColorantAlias()
      {
         List<JDFColorantAlias> v = new List<JDFColorantAlias>();

         JDFColorantAlias kElem = (JDFColorantAlias)getFirstChildElement(ElementName.COLORANTALIAS, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFColorantAlias)kElem.getNextSiblingElement(ElementName.COLORANTALIAS, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element ColorantAlias </summary>
      ///     
      public virtual JDFColorantAlias appendColorantAlias()
      {
         return (JDFColorantAlias)appendElement(ElementName.COLORANTALIAS, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refColorantAlias(JDFColorantAlias refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element ColorSpaceConversionOp </summary>
      ///     * <returns> JDFColorSpaceConversionOp the element </returns>
      ///     
      public virtual JDFColorSpaceConversionOp getColorSpaceConversionOp()
      {
         return (JDFColorSpaceConversionOp)getElement(ElementName.COLORSPACECONVERSIONOP, null, 0);
      }

      ///     <summary> (25) getCreateColorSpaceConversionOp
      ///     *  </summary>
      ///     * <returns> JDFColorSpaceConversionOp the element </returns>
      ///     
      public virtual JDFColorSpaceConversionOp getCreateColorSpaceConversionOp()
      {
         return (JDFColorSpaceConversionOp)getCreateElement_KElement(ElementName.COLORSPACECONVERSIONOP, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ColorSpaceConversionOp </summary>
      ///     
      public virtual JDFColorSpaceConversionOp appendColorSpaceConversionOp()
      {
         return (JDFColorSpaceConversionOp)appendElementN(ElementName.COLORSPACECONVERSIONOP, 1, null);
      }

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
   }
}
