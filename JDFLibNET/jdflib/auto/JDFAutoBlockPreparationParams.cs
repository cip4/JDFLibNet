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
   using System.Collections.Generic;


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFRegisterRibbon = org.cip4.jdflib.resource.JDFRegisterRibbon;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;

   public abstract class JDFAutoBlockPreparationParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[3];
      static JDFAutoBlockPreparationParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.BACKING, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.ROUNDING, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.TIGHTBACKING, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumTightBacking.getEnum(0), null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.REGISTERRIBBON, 0x33333331);
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
      ///     <summary> * Constructor for JDFAutoBlockPreparationParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoBlockPreparationParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoBlockPreparationParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoBlockPreparationParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoBlockPreparationParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoBlockPreparationParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoBlockPreparationParams[  --> " + base.ToString() + " ]";
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


      ///        
      ///        <summary> * Enumeration strings for TightBacking </summary>
      ///        

      public class EnumTightBacking : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumTightBacking(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumTightBacking getEnum(string enumName)
         {
            return (EnumTightBacking)getEnum(typeof(EnumTightBacking), enumName);
         }

         public static EnumTightBacking getEnum(int enumValue)
         {
            return (EnumTightBacking)getEnum(typeof(EnumTightBacking), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumTightBacking));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumTightBacking));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumTightBacking));
         }

         public static readonly EnumTightBacking Flat = new EnumTightBacking("Flat");
         public static readonly EnumTightBacking Round = new EnumTightBacking("Round");
         public static readonly EnumTightBacking FlatBacked = new EnumTightBacking("FlatBacked");
         public static readonly EnumTightBacking RoundBacked = new EnumTightBacking("RoundBacked");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute Backing
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Backing </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBacking(double @value)
      {
         setAttribute(AttributeName.BACKING, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute Backing </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getBacking()
      {
         return getRealAttribute(AttributeName.BACKING, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Rounding
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Rounding </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setRounding(double @value)
      {
         setAttribute(AttributeName.ROUNDING, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute Rounding </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getRounding()
      {
         return getRealAttribute(AttributeName.ROUNDING, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TightBacking
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute TightBacking </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setTightBacking(EnumTightBacking enumVar)
      {
         setAttribute(AttributeName.TIGHTBACKING, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute TightBacking </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumTightBacking getTightBacking()
      {
         return EnumTightBacking.getEnum(getAttribute(AttributeName.TIGHTBACKING, null, null));
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateRegisterRibbon
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFRegisterRibbon the element </returns>
      ///     
      public virtual JDFRegisterRibbon getCreateRegisterRibbon(int iSkip)
      {
         return (JDFRegisterRibbon)getCreateElement_KElement(ElementName.REGISTERRIBBON, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element RegisterRibbon </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFRegisterRibbon the element </returns>
      ///     * default is getRegisterRibbon(0)     
      public virtual JDFRegisterRibbon getRegisterRibbon(int iSkip)
      {
         return (JDFRegisterRibbon)getElement(ElementName.REGISTERRIBBON, null, iSkip);
      }

      ///    
      ///     <summary> * Get all RegisterRibbon from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFRegisterRibbon> </returns>
      ///     
      public virtual ICollection<JDFRegisterRibbon> getAllRegisterRibbon()
      {
         List<JDFRegisterRibbon> v = new List<JDFRegisterRibbon>();

         JDFRegisterRibbon kElem = (JDFRegisterRibbon)getFirstChildElement(ElementName.REGISTERRIBBON, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFRegisterRibbon)kElem.getNextSiblingElement(ElementName.REGISTERRIBBON, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element RegisterRibbon </summary>
      ///     
      public virtual JDFRegisterRibbon appendRegisterRibbon()
      {
         return (JDFRegisterRibbon)appendElement(ElementName.REGISTERRIBBON, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refRegisterRibbon(JDFRegisterRibbon refTarget)
      {
         refElement(refTarget);
      }
   }
}
