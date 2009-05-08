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
   using System.Collections;


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFBindList = org.cip4.jdflib.resource.JDFBindList;
   using JDFEdgeGluing = org.cip4.jdflib.resource.JDFEdgeGluing;
   using JDFHardCoverBinding = org.cip4.jdflib.resource.JDFHardCoverBinding;
   using JDFSoftCoverBinding = org.cip4.jdflib.resource.JDFSoftCoverBinding;
   using JDFStripBinding = org.cip4.jdflib.resource.JDFStripBinding;
   using JDFTabs = org.cip4.jdflib.resource.JDFTabs;
   using JDFTape = org.cip4.jdflib.resource.JDFTape;
   using JDFBookCase = org.cip4.jdflib.resource.intent.JDFBookCase;
   using JDFIntentResource = org.cip4.jdflib.resource.intent.JDFIntentResource;
   using JDFAdhesiveBinding = org.cip4.jdflib.resource.process.postpress.JDFAdhesiveBinding;
   using JDFChannelBinding = org.cip4.jdflib.resource.process.postpress.JDFChannelBinding;
   using JDFCoilBinding = org.cip4.jdflib.resource.process.postpress.JDFCoilBinding;
   using JDFPlasticCombBinding = org.cip4.jdflib.resource.process.postpress.JDFPlasticCombBinding;
   using JDFRingBinding = org.cip4.jdflib.resource.process.postpress.JDFRingBinding;
   using JDFSaddleStitching = org.cip4.jdflib.resource.process.postpress.JDFSaddleStitching;
   using JDFSideSewing = org.cip4.jdflib.resource.process.postpress.JDFSideSewing;
   using JDFSideStitching = org.cip4.jdflib.resource.process.postpress.JDFSideStitching;
   using JDFThreadSealing = org.cip4.jdflib.resource.process.postpress.JDFThreadSealing;
   using JDFThreadSewing = org.cip4.jdflib.resource.process.postpress.JDFThreadSewing;
   using JDFWireCombBinding = org.cip4.jdflib.resource.process.postpress.JDFWireCombBinding;
   using JDFSpanBindingLength = org.cip4.jdflib.span.JDFSpanBindingLength;
   using JDFSpanBindingSide = org.cip4.jdflib.span.JDFSpanBindingSide;
   using JDFSpanBindingType = org.cip4.jdflib.span.JDFSpanBindingType;
   using JDFSpanNamedColor = org.cip4.jdflib.span.JDFSpanNamedColor;

   public abstract class JDFAutoBindingIntent : JDFIntentResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[1];
      static JDFAutoBindingIntent()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.BINDINGORDER, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumBindingOrder.getEnum(0), "Gathering");
         elemInfoTable[0] = new ElemInfoTable(ElementName.BACKCOVERCOLOR, 0x66666661);
         elemInfoTable[1] = new ElemInfoTable(ElementName.BINDINGTYPE, 0x55555555);
         elemInfoTable[2] = new ElemInfoTable(ElementName.BINDINGCOLOR, 0x66666666);
         elemInfoTable[3] = new ElemInfoTable(ElementName.BINDINGLENGTH, 0x66666666);
         elemInfoTable[4] = new ElemInfoTable(ElementName.BINDINGSIDE, 0x66666666);
         elemInfoTable[5] = new ElemInfoTable(ElementName.COVERCOLOR, 0x66666666);
         elemInfoTable[6] = new ElemInfoTable(ElementName.ADHESIVEBINDING, 0x77777776);
         elemInfoTable[7] = new ElemInfoTable(ElementName.BINDLIST, 0x66666661);
         elemInfoTable[8] = new ElemInfoTable(ElementName.BOOKCASE, 0x77777776);
         elemInfoTable[9] = new ElemInfoTable(ElementName.CHANNELBINDING, 0x66666666);
         elemInfoTable[10] = new ElemInfoTable(ElementName.COILBINDING, 0x66666666);
         elemInfoTable[11] = new ElemInfoTable(ElementName.EDGEGLUING, 0x66666661);
         elemInfoTable[12] = new ElemInfoTable(ElementName.HARDCOVERBINDING, 0x66666661);
         elemInfoTable[13] = new ElemInfoTable(ElementName.PLASTICCOMBBINDING, 0x66666666);
         elemInfoTable[14] = new ElemInfoTable(ElementName.RINGBINDING, 0x66666666);
         elemInfoTable[15] = new ElemInfoTable(ElementName.SADDLESTITCHING, 0x66666666);
         elemInfoTable[16] = new ElemInfoTable(ElementName.SIDESEWING, 0x66666666);
         elemInfoTable[17] = new ElemInfoTable(ElementName.SIDESTITCHING, 0x66666666);
         elemInfoTable[18] = new ElemInfoTable(ElementName.SOFTCOVERBINDING, 0x66666661);
         elemInfoTable[19] = new ElemInfoTable(ElementName.TAPE, 0x66666661);
         elemInfoTable[20] = new ElemInfoTable(ElementName.TABS, 0x66666666);
         elemInfoTable[21] = new ElemInfoTable(ElementName.THREADSEALING, 0x66666666);
         elemInfoTable[22] = new ElemInfoTable(ElementName.THREADSEWING, 0x66666666);
         elemInfoTable[23] = new ElemInfoTable(ElementName.STRIPBINDING, 0x66666661);
         elemInfoTable[24] = new ElemInfoTable(ElementName.WIRECOMBBINDING, 0x66666666);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[25];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoBindingIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoBindingIntent(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoBindingIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoBindingIntent(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoBindingIntent </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoBindingIntent(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoBindingIntent[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for BindingOrder </summary>
      ///        

      public class EnumBindingOrder : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumBindingOrder(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumBindingOrder getEnum(string enumName)
         {
            return (EnumBindingOrder)getEnum(typeof(EnumBindingOrder), enumName);
         }

         public static EnumBindingOrder getEnum(int enumValue)
         {
            return (EnumBindingOrder)getEnum(typeof(EnumBindingOrder), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumBindingOrder));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumBindingOrder));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumBindingOrder));
         }

         public static readonly EnumBindingOrder Collecting = new EnumBindingOrder("Collecting");
         public static readonly EnumBindingOrder Gathering = new EnumBindingOrder("Gathering");
         public static readonly EnumBindingOrder List = new EnumBindingOrder("List");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute BindingOrder
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute BindingOrder </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setBindingOrder(EnumBindingOrder enumVar)
      {
         setAttribute(AttributeName.BINDINGORDER, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute BindingOrder </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumBindingOrder getBindingOrder()
      {
         return EnumBindingOrder.getEnum(getAttribute(AttributeName.BINDINGORDER, null, "Gathering"));
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element BackCoverColor </summary>
      ///     * <returns> JDFSpanNamedColor the element </returns>
      ///     
      public virtual JDFSpanNamedColor getBackCoverColor()
      {
         return (JDFSpanNamedColor)getElement(ElementName.BACKCOVERCOLOR, null, 0);
      }

      ///     <summary> (25) getCreateBackCoverColor
      ///     *  </summary>
      ///     * <returns> JDFSpanNamedColor the element </returns>
      ///     
      public virtual JDFSpanNamedColor getCreateBackCoverColor()
      {
         return (JDFSpanNamedColor)getCreateElement_KElement(ElementName.BACKCOVERCOLOR, null, 0);
      }

      ///    
      ///     <summary> * (29) append element BackCoverColor </summary>
      ///     
      public virtual JDFSpanNamedColor appendBackCoverColor()
      {
         return (JDFSpanNamedColor)appendElementN(ElementName.BACKCOVERCOLOR, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element BindingType </summary>
      ///     * <returns> JDFSpanBindingType the element </returns>
      ///     
      public virtual JDFSpanBindingType getBindingType()
      {
         return (JDFSpanBindingType)getElement(ElementName.BINDINGTYPE, null, 0);
      }

      ///     <summary> (25) getCreateBindingType
      ///     *  </summary>
      ///     * <returns> JDFSpanBindingType the element </returns>
      ///     
      public virtual JDFSpanBindingType getCreateBindingType()
      {
         return (JDFSpanBindingType)getCreateElement_KElement(ElementName.BINDINGTYPE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element BindingType </summary>
      ///     
      public virtual JDFSpanBindingType appendBindingType()
      {
         return (JDFSpanBindingType)appendElementN(ElementName.BINDINGTYPE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element BindingColor </summary>
      ///     * <returns> JDFSpanNamedColor the element </returns>
      ///     
      public virtual JDFSpanNamedColor getBindingColor()
      {
         return (JDFSpanNamedColor)getElement(ElementName.BINDINGCOLOR, null, 0);
      }

      ///     <summary> (25) getCreateBindingColor
      ///     *  </summary>
      ///     * <returns> JDFSpanNamedColor the element </returns>
      ///     
      public virtual JDFSpanNamedColor getCreateBindingColor()
      {
         return (JDFSpanNamedColor)getCreateElement_KElement(ElementName.BINDINGCOLOR, null, 0);
      }

      ///    
      ///     <summary> * (29) append element BindingColor </summary>
      ///     
      public virtual JDFSpanNamedColor appendBindingColor()
      {
         return (JDFSpanNamedColor)appendElementN(ElementName.BINDINGCOLOR, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element BindingLength </summary>
      ///     * <returns> JDFSpanBindingLength the element </returns>
      ///     
      public virtual JDFSpanBindingLength getBindingLength()
      {
         return (JDFSpanBindingLength)getElement(ElementName.BINDINGLENGTH, null, 0);
      }

      ///     <summary> (25) getCreateBindingLength
      ///     *  </summary>
      ///     * <returns> JDFSpanBindingLength the element </returns>
      ///     
      public virtual JDFSpanBindingLength getCreateBindingLength()
      {
         return (JDFSpanBindingLength)getCreateElement_KElement(ElementName.BINDINGLENGTH, null, 0);
      }

      ///    
      ///     <summary> * (29) append element BindingLength </summary>
      ///     
      public virtual JDFSpanBindingLength appendBindingLength()
      {
         return (JDFSpanBindingLength)appendElementN(ElementName.BINDINGLENGTH, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element BindingSide </summary>
      ///     * <returns> JDFSpanBindingSide the element </returns>
      ///     
      public virtual JDFSpanBindingSide getBindingSide()
      {
         return (JDFSpanBindingSide)getElement(ElementName.BINDINGSIDE, null, 0);
      }

      ///     <summary> (25) getCreateBindingSide
      ///     *  </summary>
      ///     * <returns> JDFSpanBindingSide the element </returns>
      ///     
      public virtual JDFSpanBindingSide getCreateBindingSide()
      {
         return (JDFSpanBindingSide)getCreateElement_KElement(ElementName.BINDINGSIDE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element BindingSide </summary>
      ///     
      public virtual JDFSpanBindingSide appendBindingSide()
      {
         return (JDFSpanBindingSide)appendElementN(ElementName.BINDINGSIDE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element CoverColor </summary>
      ///     * <returns> JDFSpanNamedColor the element </returns>
      ///     
      public virtual JDFSpanNamedColor getCoverColor()
      {
         return (JDFSpanNamedColor)getElement(ElementName.COVERCOLOR, null, 0);
      }

      ///     <summary> (25) getCreateCoverColor
      ///     *  </summary>
      ///     * <returns> JDFSpanNamedColor the element </returns>
      ///     
      public virtual JDFSpanNamedColor getCreateCoverColor()
      {
         return (JDFSpanNamedColor)getCreateElement_KElement(ElementName.COVERCOLOR, null, 0);
      }

      ///    
      ///     <summary> * (29) append element CoverColor </summary>
      ///     
      public virtual JDFSpanNamedColor appendCoverColor()
      {
         return (JDFSpanNamedColor)appendElementN(ElementName.COVERCOLOR, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element AdhesiveBinding </summary>
      ///     * <returns> JDFAdhesiveBinding the element </returns>
      ///     
      public virtual JDFAdhesiveBinding getAdhesiveBinding()
      {
         return (JDFAdhesiveBinding)getElement(ElementName.ADHESIVEBINDING, null, 0);
      }

      ///     <summary> (25) getCreateAdhesiveBinding
      ///     *  </summary>
      ///     * <returns> JDFAdhesiveBinding the element </returns>
      ///     
      public virtual JDFAdhesiveBinding getCreateAdhesiveBinding()
      {
         return (JDFAdhesiveBinding)getCreateElement_KElement(ElementName.ADHESIVEBINDING, null, 0);
      }

      ///    
      ///     <summary> * (29) append element AdhesiveBinding </summary>
      ///     
      public virtual JDFAdhesiveBinding appendAdhesiveBinding()
      {
         return (JDFAdhesiveBinding)appendElementN(ElementName.ADHESIVEBINDING, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element BindList </summary>
      ///     * <returns> JDFBindList the element </returns>
      ///     
      public virtual JDFBindList getBindList()
      {
         return (JDFBindList)getElement(ElementName.BINDLIST, null, 0);
      }

      ///     <summary> (25) getCreateBindList
      ///     *  </summary>
      ///     * <returns> JDFBindList the element </returns>
      ///     
      public virtual JDFBindList getCreateBindList()
      {
         return (JDFBindList)getCreateElement_KElement(ElementName.BINDLIST, null, 0);
      }

      ///    
      ///     <summary> * (29) append element BindList </summary>
      ///     
      public virtual JDFBindList appendBindList()
      {
         return (JDFBindList)appendElementN(ElementName.BINDLIST, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element BookCase </summary>
      ///     * <returns> JDFBookCase the element </returns>
      ///     
      public virtual JDFBookCase getBookCase()
      {
         return (JDFBookCase)getElement(ElementName.BOOKCASE, null, 0);
      }

      ///     <summary> (25) getCreateBookCase
      ///     *  </summary>
      ///     * <returns> JDFBookCase the element </returns>
      ///     
      public virtual JDFBookCase getCreateBookCase()
      {
         return (JDFBookCase)getCreateElement_KElement(ElementName.BOOKCASE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element BookCase </summary>
      ///     
      public virtual JDFBookCase appendBookCase()
      {
         return (JDFBookCase)appendElementN(ElementName.BOOKCASE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element ChannelBinding </summary>
      ///     * <returns> JDFChannelBinding the element </returns>
      ///     
      public virtual JDFChannelBinding getChannelBinding()
      {
         return (JDFChannelBinding)getElement(ElementName.CHANNELBINDING, null, 0);
      }

      ///     <summary> (25) getCreateChannelBinding
      ///     *  </summary>
      ///     * <returns> JDFChannelBinding the element </returns>
      ///     
      public virtual JDFChannelBinding getCreateChannelBinding()
      {
         return (JDFChannelBinding)getCreateElement_KElement(ElementName.CHANNELBINDING, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ChannelBinding </summary>
      ///     
      public virtual JDFChannelBinding appendChannelBinding()
      {
         return (JDFChannelBinding)appendElementN(ElementName.CHANNELBINDING, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element CoilBinding </summary>
      ///     * <returns> JDFCoilBinding the element </returns>
      ///     
      public virtual JDFCoilBinding getCoilBinding()
      {
         return (JDFCoilBinding)getElement(ElementName.COILBINDING, null, 0);
      }

      ///     <summary> (25) getCreateCoilBinding
      ///     *  </summary>
      ///     * <returns> JDFCoilBinding the element </returns>
      ///     
      public virtual JDFCoilBinding getCreateCoilBinding()
      {
         return (JDFCoilBinding)getCreateElement_KElement(ElementName.COILBINDING, null, 0);
      }

      ///    
      ///     <summary> * (29) append element CoilBinding </summary>
      ///     
      public virtual JDFCoilBinding appendCoilBinding()
      {
         return (JDFCoilBinding)appendElementN(ElementName.COILBINDING, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element EdgeGluing </summary>
      ///     * <returns> JDFEdgeGluing the element </returns>
      ///     
      public virtual JDFEdgeGluing getEdgeGluing()
      {
         return (JDFEdgeGluing)getElement(ElementName.EDGEGLUING, null, 0);
      }

      ///     <summary> (25) getCreateEdgeGluing
      ///     *  </summary>
      ///     * <returns> JDFEdgeGluing the element </returns>
      ///     
      public virtual JDFEdgeGluing getCreateEdgeGluing()
      {
         return (JDFEdgeGluing)getCreateElement_KElement(ElementName.EDGEGLUING, null, 0);
      }

      ///    
      ///     <summary> * (29) append element EdgeGluing </summary>
      ///     
      public virtual JDFEdgeGluing appendEdgeGluing()
      {
         return (JDFEdgeGluing)appendElementN(ElementName.EDGEGLUING, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element HardCoverBinding </summary>
      ///     * <returns> JDFHardCoverBinding the element </returns>
      ///     
      public virtual JDFHardCoverBinding getHardCoverBinding()
      {
         return (JDFHardCoverBinding)getElement(ElementName.HARDCOVERBINDING, null, 0);
      }

      ///     <summary> (25) getCreateHardCoverBinding
      ///     *  </summary>
      ///     * <returns> JDFHardCoverBinding the element </returns>
      ///     
      public virtual JDFHardCoverBinding getCreateHardCoverBinding()
      {
         return (JDFHardCoverBinding)getCreateElement_KElement(ElementName.HARDCOVERBINDING, null, 0);
      }

      ///    
      ///     <summary> * (29) append element HardCoverBinding </summary>
      ///     
      public virtual JDFHardCoverBinding appendHardCoverBinding()
      {
         return (JDFHardCoverBinding)appendElementN(ElementName.HARDCOVERBINDING, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element PlasticCombBinding </summary>
      ///     * <returns> JDFPlasticCombBinding the element </returns>
      ///     
      public virtual JDFPlasticCombBinding getPlasticCombBinding()
      {
         return (JDFPlasticCombBinding)getElement(ElementName.PLASTICCOMBBINDING, null, 0);
      }

      ///     <summary> (25) getCreatePlasticCombBinding
      ///     *  </summary>
      ///     * <returns> JDFPlasticCombBinding the element </returns>
      ///     
      public virtual JDFPlasticCombBinding getCreatePlasticCombBinding()
      {
         return (JDFPlasticCombBinding)getCreateElement_KElement(ElementName.PLASTICCOMBBINDING, null, 0);
      }

      ///    
      ///     <summary> * (29) append element PlasticCombBinding </summary>
      ///     
      public virtual JDFPlasticCombBinding appendPlasticCombBinding()
      {
         return (JDFPlasticCombBinding)appendElementN(ElementName.PLASTICCOMBBINDING, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element RingBinding </summary>
      ///     * <returns> JDFRingBinding the element </returns>
      ///     
      public virtual JDFRingBinding getRingBinding()
      {
         return (JDFRingBinding)getElement(ElementName.RINGBINDING, null, 0);
      }

      ///     <summary> (25) getCreateRingBinding
      ///     *  </summary>
      ///     * <returns> JDFRingBinding the element </returns>
      ///     
      public virtual JDFRingBinding getCreateRingBinding()
      {
         return (JDFRingBinding)getCreateElement_KElement(ElementName.RINGBINDING, null, 0);
      }

      ///    
      ///     <summary> * (29) append element RingBinding </summary>
      ///     
      public virtual JDFRingBinding appendRingBinding()
      {
         return (JDFRingBinding)appendElementN(ElementName.RINGBINDING, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element SaddleStitching </summary>
      ///     * <returns> JDFSaddleStitching the element </returns>
      ///     
      public virtual JDFSaddleStitching getSaddleStitching()
      {
         return (JDFSaddleStitching)getElement(ElementName.SADDLESTITCHING, null, 0);
      }

      ///     <summary> (25) getCreateSaddleStitching
      ///     *  </summary>
      ///     * <returns> JDFSaddleStitching the element </returns>
      ///     
      public virtual JDFSaddleStitching getCreateSaddleStitching()
      {
         return (JDFSaddleStitching)getCreateElement_KElement(ElementName.SADDLESTITCHING, null, 0);
      }

      ///    
      ///     <summary> * (29) append element SaddleStitching </summary>
      ///     
      public virtual JDFSaddleStitching appendSaddleStitching()
      {
         return (JDFSaddleStitching)appendElementN(ElementName.SADDLESTITCHING, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element SideSewing </summary>
      ///     * <returns> JDFSideSewing the element </returns>
      ///     
      public virtual JDFSideSewing getSideSewing()
      {
         return (JDFSideSewing)getElement(ElementName.SIDESEWING, null, 0);
      }

      ///     <summary> (25) getCreateSideSewing
      ///     *  </summary>
      ///     * <returns> JDFSideSewing the element </returns>
      ///     
      public virtual JDFSideSewing getCreateSideSewing()
      {
         return (JDFSideSewing)getCreateElement_KElement(ElementName.SIDESEWING, null, 0);
      }

      ///    
      ///     <summary> * (29) append element SideSewing </summary>
      ///     
      public virtual JDFSideSewing appendSideSewing()
      {
         return (JDFSideSewing)appendElementN(ElementName.SIDESEWING, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element SideStitching </summary>
      ///     * <returns> JDFSideStitching the element </returns>
      ///     
      public virtual JDFSideStitching getSideStitching()
      {
         return (JDFSideStitching)getElement(ElementName.SIDESTITCHING, null, 0);
      }

      ///     <summary> (25) getCreateSideStitching
      ///     *  </summary>
      ///     * <returns> JDFSideStitching the element </returns>
      ///     
      public virtual JDFSideStitching getCreateSideStitching()
      {
         return (JDFSideStitching)getCreateElement_KElement(ElementName.SIDESTITCHING, null, 0);
      }

      ///    
      ///     <summary> * (29) append element SideStitching </summary>
      ///     
      public virtual JDFSideStitching appendSideStitching()
      {
         return (JDFSideStitching)appendElementN(ElementName.SIDESTITCHING, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element SoftCoverBinding </summary>
      ///     * <returns> JDFSoftCoverBinding the element </returns>
      ///     
      public virtual JDFSoftCoverBinding getSoftCoverBinding()
      {
         return (JDFSoftCoverBinding)getElement(ElementName.SOFTCOVERBINDING, null, 0);
      }

      ///     <summary> (25) getCreateSoftCoverBinding
      ///     *  </summary>
      ///     * <returns> JDFSoftCoverBinding the element </returns>
      ///     
      public virtual JDFSoftCoverBinding getCreateSoftCoverBinding()
      {
         return (JDFSoftCoverBinding)getCreateElement_KElement(ElementName.SOFTCOVERBINDING, null, 0);
      }

      ///    
      ///     <summary> * (29) append element SoftCoverBinding </summary>
      ///     
      public virtual JDFSoftCoverBinding appendSoftCoverBinding()
      {
         return (JDFSoftCoverBinding)appendElementN(ElementName.SOFTCOVERBINDING, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element Tape </summary>
      ///     * <returns> JDFTape the element </returns>
      ///     
      public virtual JDFTape getTape()
      {
         return (JDFTape)getElement(ElementName.TAPE, null, 0);
      }

      ///     <summary> (25) getCreateTape
      ///     *  </summary>
      ///     * <returns> JDFTape the element </returns>
      ///     
      public virtual JDFTape getCreateTape()
      {
         return (JDFTape)getCreateElement_KElement(ElementName.TAPE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Tape </summary>
      ///     
      public virtual JDFTape appendTape()
      {
         return (JDFTape)appendElementN(ElementName.TAPE, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element Tabs </summary>
      ///     * <returns> JDFTabs the element </returns>
      ///     
      public virtual JDFTabs getTabs()
      {
         return (JDFTabs)getElement(ElementName.TABS, null, 0);
      }

      ///     <summary> (25) getCreateTabs
      ///     *  </summary>
      ///     * <returns> JDFTabs the element </returns>
      ///     
      public virtual JDFTabs getCreateTabs()
      {
         return (JDFTabs)getCreateElement_KElement(ElementName.TABS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Tabs </summary>
      ///     
      public virtual JDFTabs appendTabs()
      {
         return (JDFTabs)appendElementN(ElementName.TABS, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element ThreadSealing </summary>
      ///     * <returns> JDFThreadSealing the element </returns>
      ///     
      public virtual JDFThreadSealing getThreadSealing()
      {
         return (JDFThreadSealing)getElement(ElementName.THREADSEALING, null, 0);
      }

      ///     <summary> (25) getCreateThreadSealing
      ///     *  </summary>
      ///     * <returns> JDFThreadSealing the element </returns>
      ///     
      public virtual JDFThreadSealing getCreateThreadSealing()
      {
         return (JDFThreadSealing)getCreateElement_KElement(ElementName.THREADSEALING, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ThreadSealing </summary>
      ///     
      public virtual JDFThreadSealing appendThreadSealing()
      {
         return (JDFThreadSealing)appendElementN(ElementName.THREADSEALING, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element ThreadSewing </summary>
      ///     * <returns> JDFThreadSewing the element </returns>
      ///     
      public virtual JDFThreadSewing getThreadSewing()
      {
         return (JDFThreadSewing)getElement(ElementName.THREADSEWING, null, 0);
      }

      ///     <summary> (25) getCreateThreadSewing
      ///     *  </summary>
      ///     * <returns> JDFThreadSewing the element </returns>
      ///     
      public virtual JDFThreadSewing getCreateThreadSewing()
      {
         return (JDFThreadSewing)getCreateElement_KElement(ElementName.THREADSEWING, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ThreadSewing </summary>
      ///     
      public virtual JDFThreadSewing appendThreadSewing()
      {
         return (JDFThreadSewing)appendElementN(ElementName.THREADSEWING, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element StripBinding </summary>
      ///     * <returns> JDFStripBinding the element </returns>
      ///     
      public virtual JDFStripBinding getStripBinding()
      {
         return (JDFStripBinding)getElement(ElementName.STRIPBINDING, null, 0);
      }

      ///     <summary> (25) getCreateStripBinding
      ///     *  </summary>
      ///     * <returns> JDFStripBinding the element </returns>
      ///     
      public virtual JDFStripBinding getCreateStripBinding()
      {
         return (JDFStripBinding)getCreateElement_KElement(ElementName.STRIPBINDING, null, 0);
      }

      ///    
      ///     <summary> * (29) append element StripBinding </summary>
      ///     
      public virtual JDFStripBinding appendStripBinding()
      {
         return (JDFStripBinding)appendElementN(ElementName.STRIPBINDING, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element WireCombBinding </summary>
      ///     * <returns> JDFWireCombBinding the element </returns>
      ///     
      public virtual JDFWireCombBinding getWireCombBinding()
      {
         return (JDFWireCombBinding)getElement(ElementName.WIRECOMBBINDING, null, 0);
      }

      ///     <summary> (25) getCreateWireCombBinding
      ///     *  </summary>
      ///     * <returns> JDFWireCombBinding the element </returns>
      ///     
      public virtual JDFWireCombBinding getCreateWireCombBinding()
      {
         return (JDFWireCombBinding)getCreateElement_KElement(ElementName.WIRECOMBBINDING, null, 0);
      }

      ///    
      ///     <summary> * (29) append element WireCombBinding </summary>
      ///     
      public virtual JDFWireCombBinding appendWireCombBinding()
      {
         return (JDFWireCombBinding)appendElementN(ElementName.WIRECOMBBINDING, 1, null);
      }
   }
}
