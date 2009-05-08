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
   using JDFNumberSpan = org.cip4.jdflib.span.JDFNumberSpan;
   using JDFOptionSpan = org.cip4.jdflib.span.JDFOptionSpan;
   using JDFSpanNamedColor = org.cip4.jdflib.span.JDFSpanNamedColor;
   using JDFStringSpan = org.cip4.jdflib.span.JDFStringSpan;

   public abstract class JDFAutoTabs : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[2];
      static JDFAutoTabs()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.TABBANKS, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, "1");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.TABSPERBANK, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.TABBRAND, 0x66666111);
         elemInfoTable[1] = new ElemInfoTable(ElementName.TABEXTENSIONDISTANCE, 0x66666666);
         elemInfoTable[2] = new ElemInfoTable(ElementName.TABEXTENSIONMYLAR, 0x66666666);
         elemInfoTable[3] = new ElemInfoTable(ElementName.TABBINDMYLAR, 0x66666666);
         elemInfoTable[4] = new ElemInfoTable(ElementName.TABBODYCOPY, 0x66666666);
         elemInfoTable[5] = new ElemInfoTable(ElementName.TABMYLARCOLOR, 0x66666666);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[6];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoTabs </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoTabs(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoTabs </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoTabs(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoTabs </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoTabs(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoTabs[  --> " + base.ToString() + " ]";
      }


      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute TabBanks
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TabBanks </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTabBanks(int @value)
      {
         setAttribute(AttributeName.TABBANKS, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute TabBanks </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getTabBanks()
      {
         return getIntAttribute(AttributeName.TABBANKS, null, 1);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TabsPerBank
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TabsPerBank </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTabsPerBank(int @value)
      {
         setAttribute(AttributeName.TABSPERBANK, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute TabsPerBank </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getTabsPerBank()
      {
         return getIntAttribute(AttributeName.TABSPERBANK, null, 0);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element TabBrand </summary>
      ///     * <returns> JDFStringSpan the element </returns>
      ///     
      public virtual JDFStringSpan getTabBrand()
      {
         return (JDFStringSpan)getElement(ElementName.TABBRAND, null, 0);
      }

      ///     <summary> (25) getCreateTabBrand
      ///     *  </summary>
      ///     * <returns> JDFStringSpan the element </returns>
      ///     
      public virtual JDFStringSpan getCreateTabBrand()
      {
         return (JDFStringSpan)getCreateElement_KElement(ElementName.TABBRAND, null, 0);
      }

      ///    
      ///     <summary> * (29) append element TabBrand </summary>
      ///     
      public virtual JDFStringSpan appendTabBrand()
      {
         return (JDFStringSpan)appendElementN(ElementName.TABBRAND, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element TabExtensionDistance </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getTabExtensionDistance()
      {
         return (JDFNumberSpan)getElement(ElementName.TABEXTENSIONDISTANCE, null, 0);
      }

      ///     <summary> (25) getCreateTabExtensionDistance
      ///     *  </summary>
      ///     * <returns> JDFNumberSpan the element </returns>
      ///     
      public virtual JDFNumberSpan getCreateTabExtensionDistance()
      {
         return (JDFNumberSpan)getCreateElement_KElement(ElementName.TABEXTENSIONDISTANCE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element TabExtensionDistance </summary>
      ///     
      public virtual JDFNumberSpan appendTabExtensionDistance()
      {
         return (JDFNumberSpan)appendElementN(ElementName.TABEXTENSIONDISTANCE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element TabExtensionMylar </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getTabExtensionMylar()
      {
         return (JDFOptionSpan)getElement(ElementName.TABEXTENSIONMYLAR, null, 0);
      }

      ///     <summary> (25) getCreateTabExtensionMylar
      ///     *  </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getCreateTabExtensionMylar()
      {
         return (JDFOptionSpan)getCreateElement_KElement(ElementName.TABEXTENSIONMYLAR, null, 0);
      }

      ///    
      ///     <summary> * (29) append element TabExtensionMylar </summary>
      ///     
      public virtual JDFOptionSpan appendTabExtensionMylar()
      {
         return (JDFOptionSpan)appendElementN(ElementName.TABEXTENSIONMYLAR, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element TabBindMylar </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getTabBindMylar()
      {
         return (JDFOptionSpan)getElement(ElementName.TABBINDMYLAR, null, 0);
      }

      ///     <summary> (25) getCreateTabBindMylar
      ///     *  </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getCreateTabBindMylar()
      {
         return (JDFOptionSpan)getCreateElement_KElement(ElementName.TABBINDMYLAR, null, 0);
      }

      ///    
      ///     <summary> * (29) append element TabBindMylar </summary>
      ///     
      public virtual JDFOptionSpan appendTabBindMylar()
      {
         return (JDFOptionSpan)appendElementN(ElementName.TABBINDMYLAR, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element TabBodyCopy </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getTabBodyCopy()
      {
         return (JDFOptionSpan)getElement(ElementName.TABBODYCOPY, null, 0);
      }

      ///     <summary> (25) getCreateTabBodyCopy
      ///     *  </summary>
      ///     * <returns> JDFOptionSpan the element </returns>
      ///     
      public virtual JDFOptionSpan getCreateTabBodyCopy()
      {
         return (JDFOptionSpan)getCreateElement_KElement(ElementName.TABBODYCOPY, null, 0);
      }

      ///    
      ///     <summary> * (29) append element TabBodyCopy </summary>
      ///     
      public virtual JDFOptionSpan appendTabBodyCopy()
      {
         return (JDFOptionSpan)appendElementN(ElementName.TABBODYCOPY, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element TabMylarColor </summary>
      ///     * <returns> JDFSpanNamedColor the element </returns>
      ///     
      public virtual JDFSpanNamedColor getTabMylarColor()
      {
         return (JDFSpanNamedColor)getElement(ElementName.TABMYLARCOLOR, null, 0);
      }

      ///     <summary> (25) getCreateTabMylarColor
      ///     *  </summary>
      ///     * <returns> JDFSpanNamedColor the element </returns>
      ///     
      public virtual JDFSpanNamedColor getCreateTabMylarColor()
      {
         return (JDFSpanNamedColor)getCreateElement_KElement(ElementName.TABMYLARCOLOR, null, 0);
      }

      ///    
      ///     <summary> * (29) append element TabMylarColor </summary>
      ///     
      public virtual JDFSpanNamedColor appendTabMylarColor()
      {
         return (JDFSpanNamedColor)appendElementN(ElementName.TABMYLARCOLOR, 1, null);
      }
   }
}
