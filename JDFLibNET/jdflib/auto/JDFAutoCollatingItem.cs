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
   using JDFMatrix = org.cip4.jdflib.datatypes.JDFMatrix;
   using JDFComponent = org.cip4.jdflib.resource.process.JDFComponent;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;

   public abstract class JDFAutoCollatingItem : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[5];
      static JDFAutoCollatingItem()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.AMOUNT, 0x33333311, AttributeInfo.EnumAttributeType.integer, null, "1");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.BUNDLEDEPTH, 0x33333311, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.ORIENTATION, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumOrientation.getEnum(0), null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.TRANSFORMATION, 0x33333311, AttributeInfo.EnumAttributeType.matrix, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.TRANSFORMATIONCONTEXT, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumTransformationContext.getEnum(0), "StackItem");
         elemInfoTable[0] = new ElemInfoTable(ElementName.COMPONENT, 0x66666611);
         elemInfoTable[1] = new ElemInfoTable(ElementName.MEDIA, 0x66666611);
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
      ///     <summary> * Constructor for JDFAutoCollatingItem </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoCollatingItem(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoCollatingItem </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoCollatingItem(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoCollatingItem </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoCollatingItem(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoCollatingItem[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for Orientation </summary>
      ///        

      public new class EnumOrientation : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumOrientation(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumOrientation getEnum(string enumName)
         {
            return (EnumOrientation)getEnum(typeof(EnumOrientation), enumName);
         }

         public static EnumOrientation getEnum(int enumValue)
         {
            return (EnumOrientation)getEnum(typeof(EnumOrientation), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumOrientation));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumOrientation));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumOrientation));
         }

         public static readonly EnumOrientation Rotate0 = new EnumOrientation("Rotate0");
         public static readonly EnumOrientation Rotate90 = new EnumOrientation("Rotate90");
         public static readonly EnumOrientation Rotate180 = new EnumOrientation("Rotate180");
         public static readonly EnumOrientation Rotate270 = new EnumOrientation("Rotate270");
         public static readonly EnumOrientation Flip0 = new EnumOrientation("Flip0");
         public static readonly EnumOrientation Flip90 = new EnumOrientation("Flip90");
         public static readonly EnumOrientation Flip180 = new EnumOrientation("Flip180");
         public static readonly EnumOrientation Flip270 = new EnumOrientation("Flip270");
      }



      ///        
      ///        <summary> * Enumeration strings for TransformationContext </summary>
      ///        

      public class EnumTransformationContext : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumTransformationContext(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumTransformationContext getEnum(string enumName)
         {
            return (EnumTransformationContext)getEnum(typeof(EnumTransformationContext), enumName);
         }

         public static EnumTransformationContext getEnum(int enumValue)
         {
            return (EnumTransformationContext)getEnum(typeof(EnumTransformationContext), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumTransformationContext));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumTransformationContext));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumTransformationContext));
         }

         public static readonly EnumTransformationContext StackItem = new EnumTransformationContext("StackItem");
         public static readonly EnumTransformationContext Component = new EnumTransformationContext("Component");
         public static readonly EnumTransformationContext CollateItem = new EnumTransformationContext("CollateItem");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute Amount
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Amount </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAmount(int @value)
      {
         setAttribute(AttributeName.AMOUNT, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute Amount </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getAmount()
      {
         return getIntAttribute(AttributeName.AMOUNT, null, 1);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute BundleDepth
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BundleDepth </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBundleDepth(int @value)
      {
         setAttribute(AttributeName.BUNDLEDEPTH, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute BundleDepth </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getBundleDepth()
      {
         return getIntAttribute(AttributeName.BUNDLEDEPTH, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Orientation
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Orientation </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setOrientation(EnumOrientation enumVar)
      {
         setAttribute(AttributeName.ORIENTATION, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Orientation </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumOrientation getOrientation()
      {
         return EnumOrientation.getEnum(getAttribute(AttributeName.ORIENTATION, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Transformation
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Transformation </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTransformation(JDFMatrix @value)
      {
         setAttribute(AttributeName.TRANSFORMATION, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFMatrix attribute Transformation </summary>
      ///          * <returns> JDFMatrix the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFMatrix </returns>
      ///          
      public virtual JDFMatrix getTransformation()
      {
         string strAttrName = "";
         JDFMatrix nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.TRANSFORMATION, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFMatrix(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TransformationContext
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute TransformationContext </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setTransformationContext(EnumTransformationContext enumVar)
      {
         setAttribute(AttributeName.TRANSFORMATIONCONTEXT, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute TransformationContext </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumTransformationContext getTransformationContext()
      {
         return EnumTransformationContext.getEnum(getAttribute(AttributeName.TRANSFORMATIONCONTEXT, null, "StackItem"));
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
