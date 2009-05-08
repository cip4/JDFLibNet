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
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using VString = org.cip4.jdflib.core.VString;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;

   public abstract class JDFAutoSpinePreparationParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[8];
      static JDFAutoSpinePreparationParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.STARTPOSITION, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, "0");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.FLEXVALUE, 0x44444431, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.MILLINGDEPTH, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.NOTCHINGDEPTH, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.NOTCHINGDISTANCE, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.OPERATIONS, 0x33333331, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.PULLOUTVALUE, 0x44444431, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.WORKINGLENGTH, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoSpinePreparationParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoSpinePreparationParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoSpinePreparationParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoSpinePreparationParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoSpinePreparationParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoSpinePreparationParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoSpinePreparationParams[  --> " + base.ToString() + " ]";
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
      //        Methods for Attribute StartPosition
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute StartPosition </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setStartPosition(double @value)
      {
         setAttribute(AttributeName.STARTPOSITION, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute StartPosition </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getStartPosition()
      {
         return getRealAttribute(AttributeName.STARTPOSITION, null, 0.0);
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


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MillingDepth
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MillingDepth </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMillingDepth(double @value)
      {
         setAttribute(AttributeName.MILLINGDEPTH, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute MillingDepth </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getMillingDepth()
      {
         return getRealAttribute(AttributeName.MILLINGDEPTH, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute NotchingDepth
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute NotchingDepth </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setNotchingDepth(double @value)
      {
         setAttribute(AttributeName.NOTCHINGDEPTH, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute NotchingDepth </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getNotchingDepth()
      {
         return getRealAttribute(AttributeName.NOTCHINGDEPTH, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute NotchingDistance
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute NotchingDistance </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setNotchingDistance(double @value)
      {
         setAttribute(AttributeName.NOTCHINGDISTANCE, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute NotchingDistance </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getNotchingDistance()
      {
         return getRealAttribute(AttributeName.NOTCHINGDISTANCE, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Operations
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Operations </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setOperations(VString @value)
      {
         setAttribute(AttributeName.OPERATIONS, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute Operations </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getOperations()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.OPERATIONS, null, JDFConstants.EMPTYSTRING);
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
      }


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
      //        Methods for Attribute WorkingLength
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute WorkingLength </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setWorkingLength(double @value)
      {
         setAttribute(AttributeName.WORKINGLENGTH, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute WorkingLength </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getWorkingLength()
      {
         return getRealAttribute(AttributeName.WORKINGLENGTH, null, 0.0);
      }
   }
}
