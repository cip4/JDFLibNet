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
   using System.Collections;


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFIntegerList = org.cip4.jdflib.datatypes.JDFIntegerList;
   using JDFComponent = org.cip4.jdflib.resource.process.JDFComponent;
   using JDFFeederQualityParams = org.cip4.jdflib.resource.process.JDFFeederQualityParams;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;

   public abstract class JDFAutoFeeder : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[6];
      static JDFAutoFeeder()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ALTERNATEPOSITIONS, 0x33333311, AttributeInfo.EnumAttributeType.IntegerList, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.POSITION, 0x33333311, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.FEEDERSYNCHRONIZATION, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumFeederSynchronization.getEnum(0), "Primary");
         atrInfoTable[3] = new AtrInfoTable(AttributeName.FEEDERTYPE, 0x33333311, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.LOADING, 0x33333311, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.OPENING, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumOpening.getEnum(0), "None");
         elemInfoTable[0] = new ElemInfoTable(ElementName.COMPONENT, 0x66666611);
         elemInfoTable[1] = new ElemInfoTable(ElementName.FEEDERQUALITYPARAMS, 0x66666611);
         elemInfoTable[2] = new ElemInfoTable(ElementName.MEDIA, 0x66666611);
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
      ///     <summary> * Constructor for JDFAutoFeeder </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoFeeder(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoFeeder </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoFeeder(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoFeeder </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoFeeder(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoFeeder[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for FeederSynchronization </summary>
      ///        

      public class EnumFeederSynchronization : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumFeederSynchronization(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumFeederSynchronization getEnum(string enumName)
         {
            return (EnumFeederSynchronization)getEnum(typeof(EnumFeederSynchronization), enumName);
         }

         public static EnumFeederSynchronization getEnum(int enumValue)
         {
            return (EnumFeederSynchronization)getEnum(typeof(EnumFeederSynchronization), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumFeederSynchronization));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumFeederSynchronization));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumFeederSynchronization));
         }

         public static readonly EnumFeederSynchronization Alternate = new EnumFeederSynchronization("Alternate");
         public static readonly EnumFeederSynchronization Backup = new EnumFeederSynchronization("Backup");
         public static readonly EnumFeederSynchronization Chain = new EnumFeederSynchronization("Chain");
         public static readonly EnumFeederSynchronization Primary = new EnumFeederSynchronization("Primary");
      }



      ///        
      ///        <summary> * Enumeration strings for Opening </summary>
      ///        

      public class EnumOpening : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumOpening(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumOpening getEnum(string enumName)
         {
            return (EnumOpening)getEnum(typeof(EnumOpening), enumName);
         }

         public static EnumOpening getEnum(int enumValue)
         {
            return (EnumOpening)getEnum(typeof(EnumOpening), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumOpening));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumOpening));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumOpening));
         }

         public static readonly EnumOpening Back = new EnumOpening("Back");
         public static readonly EnumOpening Front = new EnumOpening("Front");
         public static readonly EnumOpening None = new EnumOpening("None");
         public static readonly EnumOpening Sucker = new EnumOpening("Sucker");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute AlternatePositions
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute AlternatePositions </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAlternatePositions(JDFIntegerList @value)
      {
         setAttribute(AttributeName.ALTERNATEPOSITIONS, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerList attribute AlternatePositions </summary>
      ///          * <returns> JDFIntegerList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerList </returns>
      ///          
      public virtual JDFIntegerList getAlternatePositions()
      {
         string strAttrName = "";
         JDFIntegerList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.ALTERNATEPOSITIONS, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute Position
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Position </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPosition(int @value)
      {
         setAttribute(AttributeName.POSITION, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute Position </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getPosition()
      {
         return getIntAttribute(AttributeName.POSITION, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute FeederSynchronization
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute FeederSynchronization </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setFeederSynchronization(EnumFeederSynchronization enumVar)
      {
         setAttribute(AttributeName.FEEDERSYNCHRONIZATION, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute FeederSynchronization </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumFeederSynchronization getFeederSynchronization()
      {
         return EnumFeederSynchronization.getEnum(getAttribute(AttributeName.FEEDERSYNCHRONIZATION, null, "Primary"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute FeederType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute FeederType </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFeederType(string @value)
      {
         setAttribute(AttributeName.FEEDERTYPE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute FeederType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getFeederType()
      {
         return getAttribute(AttributeName.FEEDERTYPE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Loading
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Loading </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setLoading(string @value)
      {
         setAttribute(AttributeName.LOADING, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Loading </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getLoading()
      {
         return getAttribute(AttributeName.LOADING, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Opening
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Opening </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setOpening(EnumOpening enumVar)
      {
         setAttribute(AttributeName.OPENING, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Opening </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumOpening getOpening()
      {
         return EnumOpening.getEnum(getAttribute(AttributeName.OPENING, null, "None"));
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element Component </summary>
      ///     * <returns> JDFComponent the element </returns>
      ///     
      public virtual JDFComponent getComponent()
      {
         return (JDFComponent)getElement(ElementName.COMPONENT, null, 0);
      }

      ///     <summary> (25) getCreateComponent
      ///     *  </summary>
      ///     * <returns> JDFComponent the element </returns>
      ///     
      public virtual JDFComponent getCreateComponent()
      {
         return (JDFComponent)getCreateElement_KElement(ElementName.COMPONENT, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Component </summary>
      ///     
      public virtual JDFComponent appendComponent()
      {
         return (JDFComponent)appendElementN(ElementName.COMPONENT, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refComponent(JDFComponent refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element FeederQualityParams </summary>
      ///     * <returns> JDFFeederQualityParams the element </returns>
      ///     
      public virtual JDFFeederQualityParams getFeederQualityParams()
      {
         return (JDFFeederQualityParams)getElement(ElementName.FEEDERQUALITYPARAMS, null, 0);
      }

      ///     <summary> (25) getCreateFeederQualityParams
      ///     *  </summary>
      ///     * <returns> JDFFeederQualityParams the element </returns>
      ///     
      public virtual JDFFeederQualityParams getCreateFeederQualityParams()
      {
         return (JDFFeederQualityParams)getCreateElement_KElement(ElementName.FEEDERQUALITYPARAMS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element FeederQualityParams </summary>
      ///     
      public virtual JDFFeederQualityParams appendFeederQualityParams()
      {
         return (JDFFeederQualityParams)appendElementN(ElementName.FEEDERQUALITYPARAMS, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element Media </summary>
      ///     * <returns> JDFMedia the element </returns>
      ///     
      public virtual JDFMedia getMedia()
      {
         return (JDFMedia)getElement(ElementName.MEDIA, null, 0);
      }

      ///     <summary> (25) getCreateMedia
      ///     *  </summary>
      ///     * <returns> JDFMedia the element </returns>
      ///     
      public virtual JDFMedia getCreateMedia()
      {
         return (JDFMedia)getCreateElement_KElement(ElementName.MEDIA, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Media </summary>
      ///     
      public virtual JDFMedia appendMedia()
      {
         return (JDFMedia)appendElementN(ElementName.MEDIA, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refMedia(JDFMedia refTarget)
      {
         refElement(refTarget);
      }
   }
}
