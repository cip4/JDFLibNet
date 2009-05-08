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
   using System.Collections.Generic;



   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFSeparationList = org.cip4.jdflib.core.JDFSeparationList;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFColorPool = org.cip4.jdflib.resource.process.JDFColorPool;
   using JDFColorantAlias = org.cip4.jdflib.resource.process.JDFColorantAlias;
   using JDFDeviceNSpace = org.cip4.jdflib.resource.process.JDFDeviceNSpace;
   using JDFColorSpaceSubstitute = org.cip4.jdflib.resource.process.prepress.JDFColorSpaceSubstitute;

   public abstract class JDFAutoColorantControl : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[2];
      static JDFAutoColorantControl()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.FORCESEPARATIONS, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.PROCESSCOLORMODEL, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.COLORANTALIAS, 0x33333333);
         elemInfoTable[1] = new ElemInfoTable(ElementName.COLORANTORDER, 0x66666666);
         elemInfoTable[2] = new ElemInfoTable(ElementName.COLORANTPARAMS, 0x66666666);
         elemInfoTable[3] = new ElemInfoTable(ElementName.COLORPOOL, 0x66666666);
         elemInfoTable[4] = new ElemInfoTable(ElementName.COLORSPACESUBSTITUTE, 0x33333333);
         elemInfoTable[5] = new ElemInfoTable(ElementName.DEVICECOLORANTORDER, 0x66666666);
         elemInfoTable[6] = new ElemInfoTable(ElementName.DEVICENSPACE, 0x33333333);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[7];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoColorantControl </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoColorantControl(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoColorantControl </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoColorantControl(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoColorantControl </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoColorantControl(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoColorantControl[  --> " + base.ToString() + " ]";
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


      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute ForceSeparations
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ForceSeparations </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setForceSeparations(bool @value)
      {
         setAttribute(AttributeName.FORCESEPARATIONS, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute ForceSeparations </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getForceSeparations()
      {
         return getBoolAttribute(AttributeName.FORCESEPARATIONS, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ProcessColorModel
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ProcessColorModel </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setProcessColorModel(string @value)
      {
         setAttribute(AttributeName.PROCESSCOLORMODEL, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ProcessColorModel </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getProcessColorModel()
      {
         return getAttribute(AttributeName.PROCESSCOLORMODEL, null, JDFConstants.EMPTYSTRING);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

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
      ///     <summary> * (24) const get element ColorantOrder </summary>
      ///     * <returns> JDFSeparationList the element </returns>
      ///     
      public virtual JDFSeparationList getColorantOrder()
      {
         return (JDFSeparationList)getElement(ElementName.COLORANTORDER, null, 0);
      }

      ///     <summary> (25) getCreateColorantOrder
      ///     *  </summary>
      ///     * <returns> JDFSeparationList the element </returns>
      ///     
      public virtual JDFSeparationList getCreateColorantOrder()
      {
         return (JDFSeparationList)getCreateElement_KElement(ElementName.COLORANTORDER, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ColorantOrder </summary>
      ///     
      public virtual JDFSeparationList appendColorantOrder()
      {
         return (JDFSeparationList)appendElementN(ElementName.COLORANTORDER, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element ColorantParams </summary>
      ///     * <returns> JDFSeparationList the element </returns>
      ///     
      public virtual JDFSeparationList getColorantParams()
      {
         return (JDFSeparationList)getElement(ElementName.COLORANTPARAMS, null, 0);
      }

      ///     <summary> (25) getCreateColorantParams
      ///     *  </summary>
      ///     * <returns> JDFSeparationList the element </returns>
      ///     
      public virtual JDFSeparationList getCreateColorantParams()
      {
         return (JDFSeparationList)getCreateElement_KElement(ElementName.COLORANTPARAMS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ColorantParams </summary>
      ///     
      public virtual JDFSeparationList appendColorantParams()
      {
         return (JDFSeparationList)appendElementN(ElementName.COLORANTPARAMS, 1, null);
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

      ///     <summary> (26) getCreateColorSpaceSubstitute
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFColorSpaceSubstitute the element </returns>
      ///     
      public virtual JDFColorSpaceSubstitute getCreateColorSpaceSubstitute(int iSkip)
      {
         return (JDFColorSpaceSubstitute)getCreateElement_KElement(ElementName.COLORSPACESUBSTITUTE, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element ColorSpaceSubstitute </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFColorSpaceSubstitute the element </returns>
      ///     * default is getColorSpaceSubstitute(0)     
      public virtual JDFColorSpaceSubstitute getColorSpaceSubstitute(int iSkip)
      {
         return (JDFColorSpaceSubstitute)getElement(ElementName.COLORSPACESUBSTITUTE, null, iSkip);
      }

      ///    
      ///     <summary> * Get all ColorSpaceSubstitute from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFColorSpaceSubstitute> </returns>
      ///     
      public virtual ICollection<JDFColorSpaceSubstitute> getAllColorSpaceSubstitute()
      {
         List<JDFColorSpaceSubstitute> v = new List<JDFColorSpaceSubstitute>();

         JDFColorSpaceSubstitute kElem = (JDFColorSpaceSubstitute)getFirstChildElement(ElementName.COLORSPACESUBSTITUTE, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFColorSpaceSubstitute)kElem.getNextSiblingElement(ElementName.COLORSPACESUBSTITUTE, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element ColorSpaceSubstitute </summary>
      ///     
      public virtual JDFColorSpaceSubstitute appendColorSpaceSubstitute()
      {
         return (JDFColorSpaceSubstitute)appendElement(ElementName.COLORSPACESUBSTITUTE, null);
      }

      ///    
      ///     <summary> * (24) const get element DeviceColorantOrder </summary>
      ///     * <returns> JDFSeparationList the element </returns>
      ///     
      public virtual JDFSeparationList getDeviceColorantOrder()
      {
         return (JDFSeparationList)getElement(ElementName.DEVICECOLORANTORDER, null, 0);
      }

      ///     <summary> (25) getCreateDeviceColorantOrder
      ///     *  </summary>
      ///     * <returns> JDFSeparationList the element </returns>
      ///     
      public virtual JDFSeparationList getCreateDeviceColorantOrder()
      {
         return (JDFSeparationList)getCreateElement_KElement(ElementName.DEVICECOLORANTORDER, null, 0);
      }

      ///    
      ///     <summary> * (29) append element DeviceColorantOrder </summary>
      ///     
      public virtual JDFSeparationList appendDeviceColorantOrder()
      {
         return (JDFSeparationList)appendElementN(ElementName.DEVICECOLORANTORDER, 1, null);
      }

      ///     <summary> (26) getCreateDeviceNSpace
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFDeviceNSpace the element </returns>
      ///     
      public virtual JDFDeviceNSpace getCreateDeviceNSpace(int iSkip)
      {
         return (JDFDeviceNSpace)getCreateElement_KElement(ElementName.DEVICENSPACE, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element DeviceNSpace </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFDeviceNSpace the element </returns>
      ///     * default is getDeviceNSpace(0)     
      public virtual JDFDeviceNSpace getDeviceNSpace(int iSkip)
      {
         return (JDFDeviceNSpace)getElement(ElementName.DEVICENSPACE, null, iSkip);
      }

      ///    
      ///     <summary> * Get all DeviceNSpace from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFDeviceNSpace> </returns>
      ///     
      public virtual ICollection<JDFDeviceNSpace> getAllDeviceNSpace()
      {
         List<JDFDeviceNSpace> v = new List<JDFDeviceNSpace>();

         JDFDeviceNSpace kElem = (JDFDeviceNSpace)getFirstChildElement(ElementName.DEVICENSPACE, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFDeviceNSpace)kElem.getNextSiblingElement(ElementName.DEVICENSPACE, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element DeviceNSpace </summary>
      ///     
      public virtual JDFDeviceNSpace appendDeviceNSpace()
      {
         return (JDFDeviceNSpace)appendElement(ElementName.DEVICENSPACE, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refDeviceNSpace(JDFDeviceNSpace refTarget)
      {
         refElement(refTarget);
      }
   }
}
