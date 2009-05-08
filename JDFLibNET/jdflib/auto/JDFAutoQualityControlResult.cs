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
   using JDFBindingQualityParams = org.cip4.jdflib.resource.process.JDFBindingQualityParams;
   using JDFFileSpec = org.cip4.jdflib.resource.process.JDFFileSpec;
   using JDFQualityMeasurement = org.cip4.jdflib.resource.process.JDFQualityMeasurement;

   public abstract class JDFAutoQualityControlResult : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[2];
      static JDFAutoQualityControlResult()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.FAILED, 0x33333311, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.PASSED, 0x33333311, AttributeInfo.EnumAttributeType.integer, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.BINDINGQUALITYPARAMS, 0x66666611);
         elemInfoTable[1] = new ElemInfoTable(ElementName.FILESPEC, 0x66666611);
         elemInfoTable[2] = new ElemInfoTable(ElementName.QUALITYMEASUREMENT, 0x33333311);
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
      ///     <summary> * Constructor for JDFAutoQualityControlResult </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoQualityControlResult(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoQualityControlResult </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoQualityControlResult(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoQualityControlResult </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoQualityControlResult(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoQualityControlResult[  --> " + base.ToString() + " ]";
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
      //        Methods for Attribute Failed
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Failed </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFailed(int @value)
      {
         setAttribute(AttributeName.FAILED, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute Failed </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getFailed()
      {
         return getIntAttribute(AttributeName.FAILED, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Passed
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Passed </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPassed(int @value)
      {
         setAttribute(AttributeName.PASSED, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute Passed </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getPassed()
      {
         return getIntAttribute(AttributeName.PASSED, null, 0);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element BindingQualityParams </summary>
      ///     * <returns> JDFBindingQualityParams the element </returns>
      ///     
      public virtual JDFBindingQualityParams getBindingQualityParams()
      {
         return (JDFBindingQualityParams)getElement(ElementName.BINDINGQUALITYPARAMS, null, 0);
      }

      ///     <summary> (25) getCreateBindingQualityParams
      ///     *  </summary>
      ///     * <returns> JDFBindingQualityParams the element </returns>
      ///     
      public virtual JDFBindingQualityParams getCreateBindingQualityParams()
      {
         return (JDFBindingQualityParams)getCreateElement_KElement(ElementName.BINDINGQUALITYPARAMS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element BindingQualityParams </summary>
      ///     
      public virtual JDFBindingQualityParams appendBindingQualityParams()
      {
         return (JDFBindingQualityParams)appendElementN(ElementName.BINDINGQUALITYPARAMS, 1, null);
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

      ///     <summary> (26) getCreateQualityMeasurement
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFQualityMeasurement the element </returns>
      ///     
      public virtual JDFQualityMeasurement getCreateQualityMeasurement(int iSkip)
      {
         return (JDFQualityMeasurement)getCreateElement_KElement(ElementName.QUALITYMEASUREMENT, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element QualityMeasurement </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFQualityMeasurement the element </returns>
      ///     * default is getQualityMeasurement(0)     
      public virtual JDFQualityMeasurement getQualityMeasurement(int iSkip)
      {
         return (JDFQualityMeasurement)getElement(ElementName.QUALITYMEASUREMENT, null, iSkip);
      }

      ///    
      ///     <summary> * Get all QualityMeasurement from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFQualityMeasurement> </returns>
      ///     
      public virtual ICollection<JDFQualityMeasurement> getAllQualityMeasurement()
      {
         List<JDFQualityMeasurement> v = new List<JDFQualityMeasurement>();

         JDFQualityMeasurement kElem = (JDFQualityMeasurement)getFirstChildElement(ElementName.QUALITYMEASUREMENT, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFQualityMeasurement)kElem.getNextSiblingElement(ElementName.QUALITYMEASUREMENT, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element QualityMeasurement </summary>
      ///     
      public virtual JDFQualityMeasurement appendQualityMeasurement()
      {
         return (JDFQualityMeasurement)appendElement(ElementName.QUALITYMEASUREMENT, null);
      }
   }
}
