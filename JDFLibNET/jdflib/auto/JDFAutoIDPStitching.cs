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
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFStitchingParams = org.cip4.jdflib.resource.process.postpress.JDFStitchingParams;

   public abstract class JDFAutoIDPStitching : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[2];
      static JDFAutoIDPStitching()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.STITCHINGPOSITION, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumStitchingPosition.getEnum(0), null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.STITCHINGREFERENCEEDGE, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumStitchingReferenceEdge.getEnum(0), null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.STITCHINGPARAMS, 0x33333333);
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
      ///     <summary> * Constructor for JDFAutoIDPStitching </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoIDPStitching(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoIDPStitching </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoIDPStitching(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoIDPStitching </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoIDPStitching(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoIDPStitching[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for StitchingPosition </summary>
      ///        

      public class EnumStitchingPosition : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumStitchingPosition(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumStitchingPosition getEnum(string enumName)
         {
            return (EnumStitchingPosition)getEnum(typeof(EnumStitchingPosition), enumName);
         }

         public static EnumStitchingPosition getEnum(int enumValue)
         {
            return (EnumStitchingPosition)getEnum(typeof(EnumStitchingPosition), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumStitchingPosition));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumStitchingPosition));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumStitchingPosition));
         }

         public static readonly EnumStitchingPosition None = new EnumStitchingPosition("None");
         public static readonly EnumStitchingPosition TopLeft = new EnumStitchingPosition("TopLeft");
         public static readonly EnumStitchingPosition BottomLeft = new EnumStitchingPosition("BottomLeft");
         public static readonly EnumStitchingPosition TopRight = new EnumStitchingPosition("TopRight");
         public static readonly EnumStitchingPosition BottomRight = new EnumStitchingPosition("BottomRight");
         public static readonly EnumStitchingPosition LeftEdge = new EnumStitchingPosition("LeftEdge");
         public static readonly EnumStitchingPosition TopEdge = new EnumStitchingPosition("TopEdge");
         public static readonly EnumStitchingPosition RightEdge = new EnumStitchingPosition("RightEdge");
         public static readonly EnumStitchingPosition BottomEdge = new EnumStitchingPosition("BottomEdge");
         public static readonly EnumStitchingPosition DualLeftEdge = new EnumStitchingPosition("DualLeftEdge");
         public static readonly EnumStitchingPosition DualTopEdge = new EnumStitchingPosition("DualTopEdge");
         public static readonly EnumStitchingPosition DualRightEdge = new EnumStitchingPosition("DualRightEdge");
         public static readonly EnumStitchingPosition DualBottomEdge = new EnumStitchingPosition("DualBottomEdge");
      }



      ///        
      ///        <summary> * Enumeration strings for StitchingReferenceEdge </summary>
      ///        

      public class EnumStitchingReferenceEdge : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumStitchingReferenceEdge(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumStitchingReferenceEdge getEnum(string enumName)
         {
            return (EnumStitchingReferenceEdge)getEnum(typeof(EnumStitchingReferenceEdge), enumName);
         }

         public static EnumStitchingReferenceEdge getEnum(int enumValue)
         {
            return (EnumStitchingReferenceEdge)getEnum(typeof(EnumStitchingReferenceEdge), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumStitchingReferenceEdge));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumStitchingReferenceEdge));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumStitchingReferenceEdge));
         }

         public static readonly EnumStitchingReferenceEdge Bottom = new EnumStitchingReferenceEdge("Bottom");
         public static readonly EnumStitchingReferenceEdge Top = new EnumStitchingReferenceEdge("Top");
         public static readonly EnumStitchingReferenceEdge Left = new EnumStitchingReferenceEdge("Left");
         public static readonly EnumStitchingReferenceEdge Right = new EnumStitchingReferenceEdge("Right");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute StitchingPosition
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute StitchingPosition </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setStitchingPosition(EnumStitchingPosition enumVar)
      {
         setAttribute(AttributeName.STITCHINGPOSITION, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute StitchingPosition </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumStitchingPosition getStitchingPosition()
      {
         return EnumStitchingPosition.getEnum(getAttribute(AttributeName.STITCHINGPOSITION, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute StitchingReferenceEdge
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute StitchingReferenceEdge </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setStitchingReferenceEdge(EnumStitchingReferenceEdge enumVar)
      {
         setAttribute(AttributeName.STITCHINGREFERENCEEDGE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute StitchingReferenceEdge </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumStitchingReferenceEdge getStitchingReferenceEdge()
      {
         return EnumStitchingReferenceEdge.getEnum(getAttribute(AttributeName.STITCHINGREFERENCEEDGE, null, null));
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateStitchingParams
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFStitchingParams the element </returns>
      ///     
      public virtual JDFStitchingParams getCreateStitchingParams(int iSkip)
      {
         return (JDFStitchingParams)getCreateElement_KElement(ElementName.STITCHINGPARAMS, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element StitchingParams </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFStitchingParams the element </returns>
      ///     * default is getStitchingParams(0)     
      public virtual JDFStitchingParams getStitchingParams(int iSkip)
      {
         return (JDFStitchingParams)getElement(ElementName.STITCHINGPARAMS, null, iSkip);
      }

      ///    
      ///     <summary> * Get all StitchingParams from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFStitchingParams> </returns>
      ///     
      public virtual ICollection<JDFStitchingParams> getAllStitchingParams()
      {
         List<JDFStitchingParams> v = new List<JDFStitchingParams>();

         JDFStitchingParams kElem = (JDFStitchingParams)getFirstChildElement(ElementName.STITCHINGPARAMS, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFStitchingParams)kElem.getNextSiblingElement(ElementName.STITCHINGPARAMS, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element StitchingParams </summary>
      ///     
      public virtual JDFStitchingParams appendStitchingParams()
      {
         return (JDFStitchingParams)appendElement(ElementName.STITCHINGPARAMS, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refStitchingParams(JDFStitchingParams refTarget)
      {
         refElement(refTarget);
      }
   }
}
