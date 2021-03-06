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
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFJobField = org.cip4.jdflib.resource.JDFJobField;
   using JDFPosition = org.cip4.jdflib.resource.process.JDFPosition;

   public abstract class JDFAutoStripMark : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[3];
      static JDFAutoStripMark()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.MARKNAME, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.MARKSIDE, 0x33333111, AttributeInfo.EnumAttributeType.enumeration, EnumMarkSide.getEnum(0), null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.STRIPMARKDETAILS, 0x33333111, AttributeInfo.EnumAttributeType.string_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.POSITION, 0x66666111);
         elemInfoTable[1] = new ElemInfoTable(ElementName.JOBFIELD, 0x66666111);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[2];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoStripMark </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoStripMark(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoStripMark </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoStripMark(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoStripMark </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoStripMark(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoStripMark[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for MarkSide </summary>
      ///        

      public class EnumMarkSide : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumMarkSide(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumMarkSide getEnum(string enumName)
         {
            return (EnumMarkSide)getEnum(typeof(EnumMarkSide), enumName);
         }

         public static EnumMarkSide getEnum(int enumValue)
         {
            return (EnumMarkSide)getEnum(typeof(EnumMarkSide), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumMarkSide));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumMarkSide));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumMarkSide));
         }

         public static readonly EnumMarkSide Front = new EnumMarkSide("Front");
         public static readonly EnumMarkSide Back = new EnumMarkSide("Back");
         public static readonly EnumMarkSide TwoSidedBackToBack = new EnumMarkSide("TwoSidedBackToBack");
         public static readonly EnumMarkSide TwoSidedIndependent = new EnumMarkSide("TwoSidedIndependent");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute MarkName
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MarkName </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMarkName(string @value)
      {
         setAttribute(AttributeName.MARKNAME, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute MarkName </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getMarkName()
      {
         return getAttribute(AttributeName.MARKNAME, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MarkSide
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute MarkSide </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setMarkSide(EnumMarkSide enumVar)
      {
         setAttribute(AttributeName.MARKSIDE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute MarkSide </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumMarkSide getMarkSide()
      {
         return EnumMarkSide.getEnum(getAttribute(AttributeName.MARKSIDE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute StripMarkDetails
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute StripMarkDetails </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setStripMarkDetails(string @value)
      {
         setAttribute(AttributeName.STRIPMARKDETAILS, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute StripMarkDetails </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getStripMarkDetails()
      {
         return getAttribute(AttributeName.STRIPMARKDETAILS, null, JDFConstants.EMPTYSTRING);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element Position </summary>
      ///     * <returns> JDFPosition the element </returns>
      ///     
      public virtual JDFPosition getPosition()
      {
         return (JDFPosition)getElement(ElementName.POSITION, null, 0);
      }

      ///     <summary> (25) getCreatePosition
      ///     *  </summary>
      ///     * <returns> JDFPosition the element </returns>
      ///     
      public virtual JDFPosition getCreatePosition()
      {
         return (JDFPosition)getCreateElement_KElement(ElementName.POSITION, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Position </summary>
      ///     
      public virtual JDFPosition appendPosition()
      {
         return (JDFPosition)appendElementN(ElementName.POSITION, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element JobField </summary>
      ///     * <returns> JDFJobField the element </returns>
      ///     
      public virtual JDFJobField getJobField()
      {
         return (JDFJobField)getElement(ElementName.JOBFIELD, null, 0);
      }

      ///     <summary> (25) getCreateJobField
      ///     *  </summary>
      ///     * <returns> JDFJobField the element </returns>
      ///     
      public virtual JDFJobField getCreateJobField()
      {
         return (JDFJobField)getCreateElement_KElement(ElementName.JOBFIELD, null, 0);
      }

      ///    
      ///     <summary> * (29) append element JobField </summary>
      ///     
      public virtual JDFJobField appendJobField()
      {
         return (JDFJobField)appendElementN(ElementName.JOBFIELD, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refJobField(JDFJobField refTarget)
      {
         refElement(refTarget);
      }
   }
}
