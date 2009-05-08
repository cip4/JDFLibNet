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


   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFHoleMakingParams = org.cip4.jdflib.resource.process.postpress.JDFHoleMakingParams;

   public abstract class JDFAutoStripBindingParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[4];
      static JDFAutoStripBindingParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.BRAND, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.DISTANCE, 0x44444431, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.LENGTHJDF, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.STRIPCOLOR, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.HOLEMAKINGPARAMS, 0x66666611);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[1];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoStripBindingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoStripBindingParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoStripBindingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoStripBindingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoStripBindingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoStripBindingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoStripBindingParams[  --> " + base.ToString() + " ]";
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
      //        Methods for Attribute Brand
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Brand </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public override void setBrand(string @value)
      {
         setAttribute(AttributeName.BRAND, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Brand </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public override string getBrand()
      {
         return getAttribute(AttributeName.BRAND, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Distance
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Distance </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDistance(double @value)
      {
         setAttribute(AttributeName.DISTANCE, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute Distance </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getDistance()
      {
         return getRealAttribute(AttributeName.DISTANCE, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute LengthJDF
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute LengthJDF </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setLengthJDF(double @value)
      {
         setAttribute(AttributeName.LENGTHJDF, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute LengthJDF </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getLengthJDF()
      {
         return getRealAttribute(AttributeName.LENGTHJDF, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute StripColor
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (13) set attribute StripColor </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setStripColor(EnumNamedColor @value)
      {
         setAttribute(AttributeName.STRIPCOLOR, @value == null ? null : @value.getName(), null);
      }

      ///        
      ///          <summary> * (19) get EnumNamedColor attribute StripColor </summary>
      ///          * <returns> EnumNamedColor the value of the attribute </returns>
      ///          
      public virtual EnumNamedColor getStripColor()
      {
         string strAttrName = "";
         EnumNamedColor nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.STRIPCOLOR, null, JDFConstants.EMPTYSTRING);
         nPlaceHolder = EnumNamedColor.getEnum(strAttrName);
         return nPlaceHolder;
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element HoleMakingParams </summary>
      ///     * <returns> JDFHoleMakingParams the element </returns>
      ///     
      public virtual JDFHoleMakingParams getHoleMakingParams()
      {
         return (JDFHoleMakingParams)getElement(ElementName.HOLEMAKINGPARAMS, null, 0);
      }

      ///     <summary> (25) getCreateHoleMakingParams
      ///     *  </summary>
      ///     * <returns> JDFHoleMakingParams the element </returns>
      ///     
      public virtual JDFHoleMakingParams getCreateHoleMakingParams()
      {
         return (JDFHoleMakingParams)getCreateElement_KElement(ElementName.HOLEMAKINGPARAMS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element HoleMakingParams </summary>
      ///     
      public virtual JDFHoleMakingParams appendHoleMakingParams()
      {
         return (JDFHoleMakingParams)appendElementN(ElementName.HOLEMAKINGPARAMS, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refHoleMakingParams(JDFHoleMakingParams refTarget)
      {
         refElement(refTarget);
      }
   }
}
