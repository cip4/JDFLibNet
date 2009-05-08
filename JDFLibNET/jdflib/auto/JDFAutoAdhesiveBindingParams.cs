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
   using JDFCoverApplicationParams = org.cip4.jdflib.resource.JDFCoverApplicationParams;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFSpinePreparationParams = org.cip4.jdflib.resource.JDFSpinePreparationParams;
   using JDFSpineTapingParams = org.cip4.jdflib.resource.JDFSpineTapingParams;
   using JDFGlueApplication = org.cip4.jdflib.resource.process.postpress.JDFGlueApplication;

   public abstract class JDFAutoAdhesiveBindingParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[2];
      static JDFAutoAdhesiveBindingParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.PULLOUTVALUE, 0x44444443, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.FLEXVALUE, 0x44444443, AttributeInfo.EnumAttributeType.double_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.SPINEPREPARATIONPARAMS, 0x44444442);
         elemInfoTable[1] = new ElemInfoTable(ElementName.GLUEAPPLICATION, 0x44444442);
         elemInfoTable[2] = new ElemInfoTable(ElementName.SPINETAPINGPARAMS, 0x44444442);
         elemInfoTable[3] = new ElemInfoTable(ElementName.COVERAPPLICATIONPARAMS, 0x44444442);
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
      ///     <summary> * Constructor for JDFAutoAdhesiveBindingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoAdhesiveBindingParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoAdhesiveBindingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoAdhesiveBindingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoAdhesiveBindingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoAdhesiveBindingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      /// <summary>
      /// String representation of this object
      /// </summary>
      /// <returns>string</returns>
      public override string ToString()
      {
         return " JDFAutoAdhesiveBindingParams[  --> " + base.ToString() + " ]";
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
      //        Methods for Attribute PullOutValue
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PullOutValue </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPullOutValue(double @value)
      {
         setAttribute(AttributeName.PULLOUTVALUE, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute PullOutValue </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getPullOutValue()
      {
         return getRealAttribute(AttributeName.PULLOUTVALUE, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute FlexValue
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute FlexValue </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFlexValue(double @value)
      {
         setAttribute(AttributeName.FLEXVALUE, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute FlexValue </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getFlexValue()
      {
         return getRealAttribute(AttributeName.FLEXVALUE, null, 0.0);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateSpinePreparationParams
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFSpinePreparationParams the element </returns>
      ///     
      public virtual JDFSpinePreparationParams getCreateSpinePreparationParams(int iSkip)
      {
         return (JDFSpinePreparationParams)getCreateElement_KElement(ElementName.SPINEPREPARATIONPARAMS, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element SpinePreparationParams </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFSpinePreparationParams the element </returns>
      ///     * default is getSpinePreparationParams(0)     
      public virtual JDFSpinePreparationParams getSpinePreparationParams(int iSkip)
      {
         return (JDFSpinePreparationParams)getElement(ElementName.SPINEPREPARATIONPARAMS, null, iSkip);
      }

      ///    
      ///     <summary> * Get all SpinePreparationParams from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFSpinePreparationParams> </returns>
      ///     
      public virtual ICollection<JDFSpinePreparationParams> getAllSpinePreparationParams()
      {
         List<JDFSpinePreparationParams> v = new List<JDFSpinePreparationParams>();

         JDFSpinePreparationParams kElem = (JDFSpinePreparationParams)getFirstChildElement(ElementName.SPINEPREPARATIONPARAMS, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFSpinePreparationParams)kElem.getNextSiblingElement(ElementName.SPINEPREPARATIONPARAMS, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element SpinePreparationParams </summary>
      ///     
      public virtual JDFSpinePreparationParams appendSpinePreparationParams()
      {
         return (JDFSpinePreparationParams)appendElement(ElementName.SPINEPREPARATIONPARAMS, null);
      }

      ///     <summary> (26) getCreateGlueApplication
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFGlueApplication the element </returns>
      ///     
      public virtual JDFGlueApplication getCreateGlueApplication(int iSkip)
      {
         return (JDFGlueApplication)getCreateElement_KElement(ElementName.GLUEAPPLICATION, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element GlueApplication </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFGlueApplication the element </returns>
      ///     * default is getGlueApplication(0)     
      public virtual JDFGlueApplication getGlueApplication(int iSkip)
      {
         return (JDFGlueApplication)getElement(ElementName.GLUEAPPLICATION, null, iSkip);
      }

      ///    
      ///     <summary> * Get all GlueApplication from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFGlueApplication> </returns>
      ///     
      public virtual ICollection<JDFGlueApplication> getAllGlueApplication()
      {
         List<JDFGlueApplication> v = new List<JDFGlueApplication>();

         JDFGlueApplication kElem = (JDFGlueApplication)getFirstChildElement(ElementName.GLUEAPPLICATION, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFGlueApplication)kElem.getNextSiblingElement(ElementName.GLUEAPPLICATION, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element GlueApplication </summary>
      ///     
      public virtual JDFGlueApplication appendGlueApplication()
      {
         return (JDFGlueApplication)appendElement(ElementName.GLUEAPPLICATION, null);
      }

      ///     <summary> (26) getCreateSpineTapingParams
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFSpineTapingParams the element </returns>
      ///     
      public virtual JDFSpineTapingParams getCreateSpineTapingParams(int iSkip)
      {
         return (JDFSpineTapingParams)getCreateElement_KElement(ElementName.SPINETAPINGPARAMS, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element SpineTapingParams </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFSpineTapingParams the element </returns>
      ///     * default is getSpineTapingParams(0)     
      public virtual JDFSpineTapingParams getSpineTapingParams(int iSkip)
      {
         return (JDFSpineTapingParams)getElement(ElementName.SPINETAPINGPARAMS, null, iSkip);
      }

      ///    
      ///     <summary> * Get all SpineTapingParams from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFSpineTapingParams> </returns>
      ///     
      public virtual ICollection<JDFSpineTapingParams> getAllSpineTapingParams()
      {
         List<JDFSpineTapingParams> v = new List<JDFSpineTapingParams>();

         JDFSpineTapingParams kElem = (JDFSpineTapingParams)getFirstChildElement(ElementName.SPINETAPINGPARAMS, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFSpineTapingParams)kElem.getNextSiblingElement(ElementName.SPINETAPINGPARAMS, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element SpineTapingParams </summary>
      ///     
      public virtual JDFSpineTapingParams appendSpineTapingParams()
      {
         return (JDFSpineTapingParams)appendElement(ElementName.SPINETAPINGPARAMS, null);
      }

      ///     <summary> (26) getCreateCoverApplicationParams
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFCoverApplicationParams the element </returns>
      ///     
      public virtual JDFCoverApplicationParams getCreateCoverApplicationParams(int iSkip)
      {
         return (JDFCoverApplicationParams)getCreateElement_KElement(ElementName.COVERAPPLICATIONPARAMS, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element CoverApplicationParams </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFCoverApplicationParams the element </returns>
      ///     * default is getCoverApplicationParams(0)     
      public virtual JDFCoverApplicationParams getCoverApplicationParams(int iSkip)
      {
         return (JDFCoverApplicationParams)getElement(ElementName.COVERAPPLICATIONPARAMS, null, iSkip);
      }

      ///    
      ///     <summary> * Get all CoverApplicationParams from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFCoverApplicationParams> </returns>
      ///     
      public virtual ICollection<JDFCoverApplicationParams> getAllCoverApplicationParams()
      {
         List<JDFCoverApplicationParams> v = new List<JDFCoverApplicationParams>();

         JDFCoverApplicationParams kElem = (JDFCoverApplicationParams)getFirstChildElement(ElementName.COVERAPPLICATIONPARAMS, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFCoverApplicationParams)kElem.getNextSiblingElement(ElementName.COVERAPPLICATIONPARAMS, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element CoverApplicationParams </summary>
      ///     
      public virtual JDFCoverApplicationParams appendCoverApplicationParams()
      {
         return (JDFCoverApplicationParams)appendElement(ElementName.COVERAPPLICATIONPARAMS, null);
      }
   }
}
