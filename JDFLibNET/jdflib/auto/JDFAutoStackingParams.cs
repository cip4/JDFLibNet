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



   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFIntegerList = org.cip4.jdflib.datatypes.JDFIntegerList;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFDisjointing = org.cip4.jdflib.resource.process.JDFDisjointing;

   public abstract class JDFAutoStackingParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[8];
      static JDFAutoStackingParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.COMPENSATE, 0x33333331, AttributeInfo.EnumAttributeType.boolean_, null, "true");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.LAYERAMOUNT, 0x33333331, AttributeInfo.EnumAttributeType.IntegerList, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.MAXAMOUNT, 0x33333331, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.MINAMOUNT, 0x33333331, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.MAXWEIGHT, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.OFFSET, 0x44444431, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.UNDERLAYS, 0x33333111, AttributeInfo.EnumAttributeType.IntegerList, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.STANDARDAMOUNT, 0x33333331, AttributeInfo.EnumAttributeType.integer, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.DISJOINTING, 0x66666611);
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
      ///     <summary> * Constructor for JDFAutoStackingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoStackingParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoStackingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoStackingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoStackingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoStackingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoStackingParams[  --> " + base.ToString() + " ]";
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
      //        Methods for Attribute Compensate
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Compensate </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCompensate(bool @value)
      {
         setAttribute(AttributeName.COMPENSATE, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute Compensate </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getCompensate()
      {
         return getBoolAttribute(AttributeName.COMPENSATE, null, true);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute LayerAmount
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute LayerAmount </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setLayerAmount(JDFIntegerList @value)
      {
         setAttribute(AttributeName.LAYERAMOUNT, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerList attribute LayerAmount </summary>
      ///          * <returns> JDFIntegerList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerList </returns>
      ///          
      public virtual JDFIntegerList getLayerAmount()
      {
         string strAttrName = "";
         JDFIntegerList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.LAYERAMOUNT, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFIntegerList(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MaxAmount
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MaxAmount </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMaxAmount(int @value)
      {
         setAttribute(AttributeName.MAXAMOUNT, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute MaxAmount </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getMaxAmount()
      {
         return getIntAttribute(AttributeName.MAXAMOUNT, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MinAmount
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MinAmount </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMinAmount(int @value)
      {
         setAttribute(AttributeName.MINAMOUNT, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute MinAmount </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getMinAmount()
      {
         return getIntAttribute(AttributeName.MINAMOUNT, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MaxWeight
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MaxWeight </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMaxWeight(double @value)
      {
         setAttribute(AttributeName.MAXWEIGHT, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute MaxWeight </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getMaxWeight()
      {
         return getRealAttribute(AttributeName.MAXWEIGHT, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Offset
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Offset </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setOffset(bool @value)
      {
         setAttribute(AttributeName.OFFSET, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute Offset </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getOffset()
      {
         return getBoolAttribute(AttributeName.OFFSET, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute UnderLays
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute UnderLays </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setUnderLays(JDFIntegerList @value)
      {
         setAttribute(AttributeName.UNDERLAYS, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerList attribute UnderLays </summary>
      ///          * <returns> JDFIntegerList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerList </returns>
      ///          
      public virtual JDFIntegerList getUnderLays()
      {
         string strAttrName = "";
         JDFIntegerList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.UNDERLAYS, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFIntegerList(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute StandardAmount
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute StandardAmount </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setStandardAmount(int @value)
      {
         setAttribute(AttributeName.STANDARDAMOUNT, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute StandardAmount </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getStandardAmount()
      {
         return getIntAttribute(AttributeName.STANDARDAMOUNT, null, 0);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element Disjointing </summary>
      ///     * <returns> JDFDisjointing the element </returns>
      ///     
      public virtual JDFDisjointing getDisjointing()
      {
         return (JDFDisjointing)getElement(ElementName.DISJOINTING, null, 0);
      }

      ///     <summary> (25) getCreateDisjointing
      ///     *  </summary>
      ///     * <returns> JDFDisjointing the element </returns>
      ///     
      public virtual JDFDisjointing getCreateDisjointing()
      {
         return (JDFDisjointing)getCreateElement_KElement(ElementName.DISJOINTING, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Disjointing </summary>
      ///     
      public virtual JDFDisjointing appendDisjointing()
      {
         return (JDFDisjointing)appendElementN(ElementName.DISJOINTING, 1, null);
      }
   }
}
