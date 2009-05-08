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
   using JDFGlueLine = org.cip4.jdflib.resource.process.postpress.JDFGlueLine;

   public abstract class JDFAutoCaseMakingParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[8];
      static JDFAutoCaseMakingParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.BOTTOMFOLDIN, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.COVERWIDTH, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.CORNERTYPE, 0x33333331, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.FRONTFOLDIN, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.TOPFOLDIN, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.HEIGHT, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.JOINTWIDTH, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.SPINEWIDTH, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.GLUELINE, 0x66666661);
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
      ///     <summary> * Constructor for JDFAutoCaseMakingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoCaseMakingParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoCaseMakingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoCaseMakingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoCaseMakingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoCaseMakingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoCaseMakingParams[  --> " + base.ToString() + " ]";
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
      //        Methods for Attribute BottomFoldIn
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BottomFoldIn </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBottomFoldIn(double @value)
      {
         setAttribute(AttributeName.BOTTOMFOLDIN, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute BottomFoldIn </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getBottomFoldIn()
      {
         return getRealAttribute(AttributeName.BOTTOMFOLDIN, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute CoverWidth
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CoverWidth </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCoverWidth(double @value)
      {
         setAttribute(AttributeName.COVERWIDTH, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute CoverWidth </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getCoverWidth()
      {
         return getRealAttribute(AttributeName.COVERWIDTH, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute CornerType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CornerType </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCornerType(string @value)
      {
         setAttribute(AttributeName.CORNERTYPE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute CornerType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getCornerType()
      {
         return getAttribute(AttributeName.CORNERTYPE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute FrontFoldIn
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute FrontFoldIn </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFrontFoldIn(double @value)
      {
         setAttribute(AttributeName.FRONTFOLDIN, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute FrontFoldIn </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getFrontFoldIn()
      {
         return getRealAttribute(AttributeName.FRONTFOLDIN, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TopFoldIn
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TopFoldIn </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTopFoldIn(double @value)
      {
         setAttribute(AttributeName.TOPFOLDIN, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute TopFoldIn </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getTopFoldIn()
      {
         return getRealAttribute(AttributeName.TOPFOLDIN, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Height
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Height </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setHeight(double @value)
      {
         setAttribute(AttributeName.HEIGHT, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute Height </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getHeight()
      {
         return getRealAttribute(AttributeName.HEIGHT, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute JointWidth
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute JointWidth </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setJointWidth(double @value)
      {
         setAttribute(AttributeName.JOINTWIDTH, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute JointWidth </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getJointWidth()
      {
         return getRealAttribute(AttributeName.JOINTWIDTH, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SpineWidth
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SpineWidth </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSpineWidth(double @value)
      {
         setAttribute(AttributeName.SPINEWIDTH, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute SpineWidth </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getSpineWidth()
      {
         return getRealAttribute(AttributeName.SPINEWIDTH, null, 0.0);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element GlueLine </summary>
      ///     * <returns> JDFGlueLine the element </returns>
      ///     
      public virtual JDFGlueLine getGlueLine()
      {
         return (JDFGlueLine)getElement(ElementName.GLUELINE, null, 0);
      }

      ///     <summary> (25) getCreateGlueLine
      ///     *  </summary>
      ///     * <returns> JDFGlueLine the element </returns>
      ///     
      public virtual JDFGlueLine getCreateGlueLine()
      {
         return (JDFGlueLine)getCreateElement_KElement(ElementName.GLUELINE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element GlueLine </summary>
      ///     
      public virtual JDFGlueLine appendGlueLine()
      {
         return (JDFGlueLine)appendElementN(ElementName.GLUELINE, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refGlueLine(JDFGlueLine refTarget)
      {
         refElement(refTarget);
      }
   }
}
