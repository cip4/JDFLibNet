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
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFSeparationSpec = org.cip4.jdflib.resource.process.JDFSeparationSpec;
   using JDFNumberSpan = org.cip4.jdflib.span.JDFNumberSpan;
   using JDFSpanNamedColor = org.cip4.jdflib.span.JDFSpanNamedColor;

   public abstract class JDFAutoNumberItem : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[2];
      static JDFAutoNumberItem()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.STARTVALUE, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, "1");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.STEP, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, "1");
         elemInfoTable[0] = new ElemInfoTable(ElementName.COLORNAME, 0x66666666);
         elemInfoTable[1] = new ElemInfoTable(ElementName.XPOSITION, 0x66666666);
         elemInfoTable[2] = new ElemInfoTable(ElementName.YPOSITION, 0x66666666);
         elemInfoTable[3] = new ElemInfoTable(ElementName.ORIENTATION, 0x66666666);
         elemInfoTable[4] = new ElemInfoTable(ElementName.SEPARATIONSPEC, 0x66666666);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[5];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoNumberItem </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoNumberItem(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoNumberItem </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoNumberItem(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoNumberItem </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoNumberItem(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoNumberItem[  --> " + base.ToString() + " ]";
      }


      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute StartValue
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute StartValue </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setStartValue(string @value)
      {
         setAttribute(AttributeName.STARTVALUE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute StartValue </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getStartValue()
      {
         return getAttribute(AttributeName.STARTVALUE, null, "1");
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Step
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Step </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setStep(int @value)
      {
         setAttribute(AttributeName.STEP, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute Step </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getStep()
      {
         return getIntAttribute(AttributeName.STEP, null, 1);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element ColorName </summary>
      ///     * <returns> JDFSpanNamedColor the element </returns>
      ///     
      public virtual JDFSpanNamedColor getColorName()
      {
         return (JDFSpanNamedColor)getElement(ElementName.COLORNAME, null, 0);
      }

      ///     <summary> (25) getCreateColorName
      ///     *  </summary>
      ///     * <returns> JDFSpanNamedColor the element </returns>
      ///     
      public virtual JDFSpanNamedColor getCreateColorName()
      {
         return (JDFSpanNamedColor)getCreateElement_KElement(ElementName.COLORNAME, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ColorName </summary>
      ///     
      public virtual JDFSpanNamedColor appendColorName()
      {
         return (JDFSpanNamedColor)appendElementN(ElementName.COLORNAME, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element XPosition </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getXPosition()
      {
         return (JDFNumberSpan)getElement(ElementName.XPOSITION, null, 0);
      }

      ///     <summary> (25) getCreateXPosition
      ///     *  </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getCreateXPosition()
      {
         return (JDFNumberSpan)getCreateElement_KElement(ElementName.XPOSITION, null, 0);
      }

      ///    
      ///     <summary> * (29) append element XPosition </summary>
      ///     
      public virtual JDFNumberSpan appendXPosition()
      {
         return (JDFNumberSpan)appendElementN(ElementName.XPOSITION, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element YPosition </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getYPosition()
      {
         return (JDFNumberSpan)getElement(ElementName.YPOSITION, null, 0);
      }

      ///     <summary> (25) getCreateYPosition
      ///     *  </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getCreateYPosition()
      {
         return (JDFNumberSpan)getCreateElement_KElement(ElementName.YPOSITION, null, 0);
      }

      ///    
      ///     <summary> * (29) append element YPosition </summary>
      ///     
      public virtual JDFNumberSpan appendYPosition()
      {
         return (JDFNumberSpan)appendElementN(ElementName.YPOSITION, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element Orientation </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getOrientation()
      {
         return (JDFNumberSpan)getElement(ElementName.ORIENTATION, null, 0);
      }

      ///     <summary> (25) getCreateOrientation
      ///     *  </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getCreateOrientation()
      {
         return (JDFNumberSpan)getCreateElement_KElement(ElementName.ORIENTATION, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Orientation </summary>
      ///     
      public virtual JDFNumberSpan appendOrientation()
      {
         return (JDFNumberSpan)appendElementN(ElementName.ORIENTATION, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element SeparationSpec </summary>
      ///     * <returns> JDFSeparationSpec the element </returns>
      ///     
      public virtual JDFSeparationSpec getSeparationSpec()
      {
         return (JDFSeparationSpec)getElement(ElementName.SEPARATIONSPEC, null, 0);
      }

      ///     <summary> (25) getCreateSeparationSpec
      ///     *  </summary>
      ///     * <returns> JDFSeparationSpec the element </returns>
      ///     
      public virtual JDFSeparationSpec getCreateSeparationSpec()
      {
         return (JDFSeparationSpec)getCreateElement_KElement(ElementName.SEPARATIONSPEC, null, 0);
      }

      ///    
      ///     <summary> * (29) append element SeparationSpec </summary>
      ///     
      public virtual JDFSeparationSpec appendSeparationSpec()
      {
         return (JDFSeparationSpec)appendElementN(ElementName.SEPARATIONSPEC, 1, null);
      }
   }
}
