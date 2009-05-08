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
   using System.Collections.Generic;


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
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFGlueLine = org.cip4.jdflib.resource.process.postpress.JDFGlueLine;

   public abstract class JDFAutoBoxFoldAction : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[2];
      static JDFAutoBoxFoldAction()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.FOLDINDEX, 0x22222111, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.ACTION, 0x33333111, AttributeInfo.EnumAttributeType.enumeration, EnumAction.getEnum(0), null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.GLUELINE, 0x33333111);
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
      ///     <summary> * Constructor for JDFAutoBoxFoldAction </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoBoxFoldAction(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoBoxFoldAction </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoBoxFoldAction(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoBoxFoldAction </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoBoxFoldAction(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoBoxFoldAction[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for Action </summary>
      ///        

      public class EnumAction : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumAction(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumAction getEnum(string enumName)
         {
            return (EnumAction)getEnum(typeof(EnumAction), enumName);
         }

         public static EnumAction getEnum(int enumValue)
         {
            return (EnumAction)getEnum(typeof(EnumAction), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumAction));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumAction));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumAction));
         }

         public static readonly EnumAction LongFoldLeftToRight = new EnumAction("LongFoldLeftToRight");
         public static readonly EnumAction LongFoldRightToLeft = new EnumAction("LongFoldRightToLeft");
         public static readonly EnumAction LongPreFoldLeftToRight = new EnumAction("LongPreFoldLeftToRight");
         public static readonly EnumAction LongPreFoldRightToLeft = new EnumAction("LongPreFoldRightToLeft");
         public static readonly EnumAction FrontFoldComplete = new EnumAction("FrontFoldComplete");
         public static readonly EnumAction FrontFoldDiagonal = new EnumAction("FrontFoldDiagonal");
         public static readonly EnumAction FrontFoldCompleteDiagonal = new EnumAction("FrontFoldCompleteDiagonal");
         public static readonly EnumAction BackFoldComplete = new EnumAction("BackFoldComplete");
         public static readonly EnumAction BackFoldDiagonal = new EnumAction("BackFoldDiagonal");
         public static readonly EnumAction BackFoldCompleteDiagonal = new EnumAction("BackFoldCompleteDiagonal");
         public static readonly EnumAction ReverseFold = new EnumAction("ReverseFold");
         public static readonly EnumAction Milling = new EnumAction("Milling");
         public static readonly EnumAction Rotate90 = new EnumAction("Rotate90");
         public static readonly EnumAction Rotate180 = new EnumAction("Rotate180");
         public static readonly EnumAction Rotate270 = new EnumAction("Rotate270");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute FoldIndex
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute FoldIndex </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFoldIndex(JDFXYPair @value)
      {
         setAttribute(AttributeName.FOLDINDEX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute FoldIndex </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getFoldIndex()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.FOLDINDEX, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFXYPair(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Action
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Action </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setAction(EnumAction enumVar)
      {
         setAttribute(AttributeName.ACTION, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Action </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumAction getAction()
      {
         return EnumAction.getEnum(getAttribute(AttributeName.ACTION, null, null));
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateGlueLine
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFGlueLine the element </returns>
      ///     
      public virtual JDFGlueLine getCreateGlueLine(int iSkip)
      {
         return (JDFGlueLine)getCreateElement_KElement(ElementName.GLUELINE, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element GlueLine </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFGlueLine the element </returns>
      ///     * default is getGlueLine(0)     
      public virtual JDFGlueLine getGlueLine(int iSkip)
      {
         return (JDFGlueLine)getElement(ElementName.GLUELINE, null, iSkip);
      }

      ///    
      ///     <summary> * Get all GlueLine from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFGlueLine> </returns>
      ///     
      public virtual ICollection<JDFGlueLine> getAllGlueLine()
      {
         List<JDFGlueLine> v = new List<JDFGlueLine>();

         JDFGlueLine kElem = (JDFGlueLine)getFirstChildElement(ElementName.GLUELINE, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFGlueLine)kElem.getNextSiblingElement(ElementName.GLUELINE, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element GlueLine </summary>
      ///     
      public virtual JDFGlueLine appendGlueLine()
      {
         return (JDFGlueLine)appendElement(ElementName.GLUELINE, null);
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
