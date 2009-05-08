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
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFObjectResolution = org.cip4.jdflib.resource.process.JDFObjectResolution;
   using JDFTrapRegion = org.cip4.jdflib.resource.process.JDFTrapRegion;
   using JDFTrappingOrder = org.cip4.jdflib.resource.process.prepress.JDFTrappingOrder;
   using JDFTrappingParams = org.cip4.jdflib.resource.process.prepress.JDFTrappingParams;

   public abstract class JDFAutoTrappingDetails : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[4];
      static JDFAutoTrappingDetails()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.DEFAULTTRAPPING, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.IGNOREFILEPARAMS, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "true");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.TRAPPING, 0x44444433, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.TRAPPINGTYPE, 0x44444433, AttributeInfo.EnumAttributeType.integer, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.TRAPPINGORDER, 0x66666666);
         elemInfoTable[1] = new ElemInfoTable(ElementName.TRAPPINGPARAMS, 0x66666666);
         elemInfoTable[2] = new ElemInfoTable(ElementName.OBJECTRESOLUTION, 0x33333331);
         elemInfoTable[3] = new ElemInfoTable(ElementName.TRAPREGION, 0x33333333);
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
      ///     <summary> * Constructor for JDFAutoTrappingDetails </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoTrappingDetails(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoTrappingDetails </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoTrappingDetails(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoTrappingDetails </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoTrappingDetails(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoTrappingDetails[  --> " + base.ToString() + " ]";
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
      //        Methods for Attribute DefaultTrapping
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DefaultTrapping </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDefaultTrapping(bool @value)
      {
         setAttribute(AttributeName.DEFAULTTRAPPING, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute DefaultTrapping </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getDefaultTrapping()
      {
         return getBoolAttribute(AttributeName.DEFAULTTRAPPING, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute IgnoreFileParams
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute IgnoreFileParams </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setIgnoreFileParams(bool @value)
      {
         setAttribute(AttributeName.IGNOREFILEPARAMS, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute IgnoreFileParams </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getIgnoreFileParams()
      {
         return getBoolAttribute(AttributeName.IGNOREFILEPARAMS, null, true);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Trapping
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Trapping </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTrapping(bool @value)
      {
         setAttribute(AttributeName.TRAPPING, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute Trapping </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getTrapping()
      {
         return getBoolAttribute(AttributeName.TRAPPING, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TrappingType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TrappingType </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTrappingType(int @value)
      {
         setAttribute(AttributeName.TRAPPINGTYPE, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute TrappingType </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getTrappingType()
      {
         return getIntAttribute(AttributeName.TRAPPINGTYPE, null, 0);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element TrappingOrder </summary>
      ///     * <returns> JDFTrappingOrder the element </returns>
      ///     
      public virtual JDFTrappingOrder getTrappingOrder()
      {
         return (JDFTrappingOrder)getElement(ElementName.TRAPPINGORDER, null, 0);
      }

      ///     <summary> (25) getCreateTrappingOrder
      ///     *  </summary>
      ///     * <returns> JDFTrappingOrder the element </returns>
      ///     
      public virtual JDFTrappingOrder getCreateTrappingOrder()
      {
         return (JDFTrappingOrder)getCreateElement_KElement(ElementName.TRAPPINGORDER, null, 0);
      }

      ///    
      ///     <summary> * (29) append element TrappingOrder </summary>
      ///     
      public virtual JDFTrappingOrder appendTrappingOrder()
      {
         return (JDFTrappingOrder)appendElementN(ElementName.TRAPPINGORDER, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element TrappingParams </summary>
      ///     * <returns> JDFTrappingParams the element </returns>
      ///     
      public virtual JDFTrappingParams getTrappingParams()
      {
         return (JDFTrappingParams)getElement(ElementName.TRAPPINGPARAMS, null, 0);
      }

      ///     <summary> (25) getCreateTrappingParams
      ///     *  </summary>
      ///     * <returns> JDFTrappingParams the element </returns>
      ///     
      public virtual JDFTrappingParams getCreateTrappingParams()
      {
         return (JDFTrappingParams)getCreateElement_KElement(ElementName.TRAPPINGPARAMS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element TrappingParams </summary>
      ///     
      public virtual JDFTrappingParams appendTrappingParams()
      {
         return (JDFTrappingParams)appendElementN(ElementName.TRAPPINGPARAMS, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refTrappingParams(JDFTrappingParams refTarget)
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

      ///     <summary> (26) getCreateTrapRegion
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFTrapRegion the element </returns>
      ///     
      public virtual JDFTrapRegion getCreateTrapRegion(int iSkip)
      {
         return (JDFTrapRegion)getCreateElement_KElement(ElementName.TRAPREGION, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element TrapRegion </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFTrapRegion the element </returns>
      ///     * default is getTrapRegion(0)     
      public virtual JDFTrapRegion getTrapRegion(int iSkip)
      {
         return (JDFTrapRegion)getElement(ElementName.TRAPREGION, null, iSkip);
      }

      ///    
      ///     <summary> * Get all TrapRegion from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFTrapRegion> </returns>
      ///     
      public virtual ICollection<JDFTrapRegion> getAllTrapRegion()
      {
         List<JDFTrapRegion> v = new List<JDFTrapRegion>();

         JDFTrapRegion kElem = (JDFTrapRegion)getFirstChildElement(ElementName.TRAPREGION, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFTrapRegion)kElem.getNextSiblingElement(ElementName.TRAPREGION, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element TrapRegion </summary>
      ///     
      public virtual JDFTrapRegion appendTrapRegion()
      {
         return (JDFTrapRegion)appendElement(ElementName.TRAPREGION, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refTrapRegion(JDFTrapRegion refTarget)
      {
         refElement(refTarget);
      }
   }
}
