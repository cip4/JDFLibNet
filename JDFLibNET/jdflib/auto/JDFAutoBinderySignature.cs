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
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFNumberList = org.cip4.jdflib.datatypes.JDFNumberList;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFDieLayout = org.cip4.jdflib.resource.process.JDFDieLayout;
   using JDFSignatureCell = org.cip4.jdflib.resource.process.JDFSignatureCell;
   using JDFFold = org.cip4.jdflib.resource.process.postpress.JDFFold;

   public abstract class JDFAutoBinderySignature : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[10];
      static JDFAutoBinderySignature()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.BINDERYSIGNATURETYPE, 0x33333111, AttributeInfo.EnumAttributeType.enumeration, EnumBinderySignatureType.getEnum(0), "Fold");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.BINDINGEDGE, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumBindingEdge.getEnum(0), "Left");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.JOGEDGE, 0x33333111, AttributeInfo.EnumAttributeType.enumeration, EnumJogEdge.getEnum(0), "Top");
         atrInfoTable[3] = new AtrInfoTable(AttributeName.NUMBERUP, 0x33333311, AttributeInfo.EnumAttributeType.XYPair, null, "1 1");
         atrInfoTable[4] = new AtrInfoTable(AttributeName.FOLDCATALOG, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.BINDINGORIENTATION, 0x33333111, AttributeInfo.EnumAttributeType.enumeration, EnumBindingOrientation.getEnum(0), null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.OUTSIDEGUTTER, 0x33333111, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.STAGGERCOLUMNS, 0x33333111, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[8] = new AtrInfoTable(AttributeName.STAGGERCONTINUOUS, 0x33333111, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.STAGGERROWS, 0x33333111, AttributeInfo.EnumAttributeType.string_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.DIELAYOUT, 0x66666111);
         elemInfoTable[1] = new ElemInfoTable(ElementName.FOLD, 0x33333311);
         elemInfoTable[2] = new ElemInfoTable(ElementName.SIGNATURECELL, 0x33333311);
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
      ///     <summary> * Constructor for JDFAutoBinderySignature </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoBinderySignature(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoBinderySignature </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoBinderySignature(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoBinderySignature </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoBinderySignature(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoBinderySignature[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for BinderySignatureType </summary>
      ///        

      public class EnumBinderySignatureType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumBinderySignatureType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumBinderySignatureType getEnum(string enumName)
         {
            return (EnumBinderySignatureType)getEnum(typeof(EnumBinderySignatureType), enumName);
         }

         public static EnumBinderySignatureType getEnum(int enumValue)
         {
            return (EnumBinderySignatureType)getEnum(typeof(EnumBinderySignatureType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumBinderySignatureType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumBinderySignatureType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumBinderySignatureType));
         }

         public static readonly EnumBinderySignatureType Die = new EnumBinderySignatureType("Die");
         public static readonly EnumBinderySignatureType Fold = new EnumBinderySignatureType("Fold");
         public static readonly EnumBinderySignatureType Grid = new EnumBinderySignatureType("Grid");
      }



      ///        
      ///        <summary> * Enumeration strings for BindingEdge </summary>
      ///        

      public class EnumBindingEdge : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumBindingEdge(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumBindingEdge getEnum(string enumName)
         {
            return (EnumBindingEdge)getEnum(typeof(EnumBindingEdge), enumName);
         }

         public static EnumBindingEdge getEnum(int enumValue)
         {
            return (EnumBindingEdge)getEnum(typeof(EnumBindingEdge), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumBindingEdge));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumBindingEdge));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumBindingEdge));
         }

         public static readonly EnumBindingEdge Left = new EnumBindingEdge("Left");
         public static readonly EnumBindingEdge Right = new EnumBindingEdge("Right");
         public static readonly EnumBindingEdge Top = new EnumBindingEdge("Top");
         public static readonly EnumBindingEdge Bottom = new EnumBindingEdge("Bottom");
         public static readonly EnumBindingEdge None = new EnumBindingEdge("None");
      }



      ///        
      ///        <summary> * Enumeration strings for JogEdge </summary>
      ///        

      public class EnumJogEdge : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumJogEdge(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumJogEdge getEnum(string enumName)
         {
            return (EnumJogEdge)getEnum(typeof(EnumJogEdge), enumName);
         }

         public static EnumJogEdge getEnum(int enumValue)
         {
            return (EnumJogEdge)getEnum(typeof(EnumJogEdge), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumJogEdge));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumJogEdge));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumJogEdge));
         }

         public static readonly EnumJogEdge Left = new EnumJogEdge("Left");
         public static readonly EnumJogEdge Right = new EnumJogEdge("Right");
         public static readonly EnumJogEdge Top = new EnumJogEdge("Top");
         public static readonly EnumJogEdge Bottom = new EnumJogEdge("Bottom");
         public static readonly EnumJogEdge None = new EnumJogEdge("None");
      }



      ///        
      ///        <summary> * Enumeration strings for BindingOrientation </summary>
      ///        

      public class EnumBindingOrientation : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumBindingOrientation(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumBindingOrientation getEnum(string enumName)
         {
            return (EnumBindingOrientation)getEnum(typeof(EnumBindingOrientation), enumName);
         }

         public static EnumBindingOrientation getEnum(int enumValue)
         {
            return (EnumBindingOrientation)getEnum(typeof(EnumBindingOrientation), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumBindingOrientation));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumBindingOrientation));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumBindingOrientation));
         }

         public static readonly EnumBindingOrientation Rotate0 = new EnumBindingOrientation("Rotate0");
         public static readonly EnumBindingOrientation Rotate90 = new EnumBindingOrientation("Rotate90");
         public static readonly EnumBindingOrientation Rotate180 = new EnumBindingOrientation("Rotate180");
         public static readonly EnumBindingOrientation Rotate270 = new EnumBindingOrientation("Rotate270");
         public static readonly EnumBindingOrientation Flip0 = new EnumBindingOrientation("Flip0");
         public static readonly EnumBindingOrientation Flip90 = new EnumBindingOrientation("Flip90");
         public static readonly EnumBindingOrientation Flip180 = new EnumBindingOrientation("Flip180");
         public static readonly EnumBindingOrientation Flip270 = new EnumBindingOrientation("Flip270");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute BinderySignatureType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute BinderySignatureType </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setBinderySignatureType(EnumBinderySignatureType enumVar)
      {
         setAttribute(AttributeName.BINDERYSIGNATURETYPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute BinderySignatureType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumBinderySignatureType getBinderySignatureType()
      {
         return EnumBinderySignatureType.getEnum(getAttribute(AttributeName.BINDERYSIGNATURETYPE, null, "Fold"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute BindingEdge
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute BindingEdge </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setBindingEdge(EnumBindingEdge enumVar)
      {
         setAttribute(AttributeName.BINDINGEDGE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute BindingEdge </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumBindingEdge getBindingEdge()
      {
         return EnumBindingEdge.getEnum(getAttribute(AttributeName.BINDINGEDGE, null, "Left"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute JogEdge
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute JogEdge </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setJogEdge(EnumJogEdge enumVar)
      {
         setAttribute(AttributeName.JOGEDGE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute JogEdge </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumJogEdge getJogEdge()
      {
         return EnumJogEdge.getEnum(getAttribute(AttributeName.JOGEDGE, null, "Top"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute NumberUp
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute NumberUp </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setNumberUp(JDFXYPair @value)
      {
         setAttribute(AttributeName.NUMBERUP, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute NumberUp </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getNumberUp()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.NUMBERUP, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute FoldCatalog
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute FoldCatalog </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFoldCatalog(string @value)
      {
         setAttribute(AttributeName.FOLDCATALOG, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute FoldCatalog </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getFoldCatalog()
      {
         return getAttribute(AttributeName.FOLDCATALOG, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute BindingOrientation
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute BindingOrientation </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setBindingOrientation(EnumBindingOrientation enumVar)
      {
         setAttribute(AttributeName.BINDINGORIENTATION, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute BindingOrientation </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumBindingOrientation getBindingOrientation()
      {
         return EnumBindingOrientation.getEnum(getAttribute(AttributeName.BINDINGORIENTATION, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute OutsideGutter
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute OutsideGutter </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setOutsideGutter(bool @value)
      {
         setAttribute(AttributeName.OUTSIDEGUTTER, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute OutsideGutter </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getOutsideGutter()
      {
         return getBoolAttribute(AttributeName.OUTSIDEGUTTER, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute StaggerColumns
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute StaggerColumns </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setStaggerColumns(JDFNumberList @value)
      {
         setAttribute(AttributeName.STAGGERCOLUMNS, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFNumberList attribute StaggerColumns </summary>
      ///          * <returns> JDFNumberList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFNumberList </returns>
      ///          
      public virtual JDFNumberList getStaggerColumns()
      {
         string strAttrName = "";
         JDFNumberList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.STAGGERCOLUMNS, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFNumberList(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute StaggerContinuous
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute StaggerContinuous </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setStaggerContinuous(bool @value)
      {
         setAttribute(AttributeName.STAGGERCONTINUOUS, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute StaggerContinuous </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getStaggerContinuous()
      {
         return getBoolAttribute(AttributeName.STAGGERCONTINUOUS, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute StaggerRows
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute StaggerRows </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setStaggerRows(JDFNumberList @value)
      {
         setAttribute(AttributeName.STAGGERROWS, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFNumberList attribute StaggerRows </summary>
      ///          * <returns> JDFNumberList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFNumberList </returns>
      ///          
      public virtual JDFNumberList getStaggerRows()
      {
         string strAttrName = "";
         JDFNumberList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.STAGGERROWS, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFNumberList(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element DieLayout </summary>
      ///     * <returns> JDFDieLayout the element </returns>
      ///     
      public virtual JDFDieLayout getDieLayout()
      {
         return (JDFDieLayout)getElement(ElementName.DIELAYOUT, null, 0);
      }

      ///     <summary> (25) getCreateDieLayout
      ///     *  </summary>
      ///     * <returns> JDFDieLayout the element </returns>
      ///     
      public virtual JDFDieLayout getCreateDieLayout()
      {
         return (JDFDieLayout)getCreateElement_KElement(ElementName.DIELAYOUT, null, 0);
      }

      ///    
      ///     <summary> * (29) append element DieLayout </summary>
      ///     
      public virtual JDFDieLayout appendDieLayout()
      {
         return (JDFDieLayout)appendElementN(ElementName.DIELAYOUT, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refDieLayout(JDFDieLayout refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreateFold
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFFold the element </returns>
      ///     
      public virtual JDFFold getCreateFold(int iSkip)
      {
         return (JDFFold)getCreateElement_KElement(ElementName.FOLD, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element Fold </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFFold the element </returns>
      ///     * default is getFold(0)     
      public virtual JDFFold getFold(int iSkip)
      {
         return (JDFFold)getElement(ElementName.FOLD, null, iSkip);
      }

      ///    
      ///     <summary> * Get all Fold from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFFold> </returns>
      ///     
      public virtual ICollection<JDFFold> getAllFold()
      {
         List<JDFFold> v = new List<JDFFold>();

         JDFFold kElem = (JDFFold)getFirstChildElement(ElementName.FOLD, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFFold)kElem.getNextSiblingElement(ElementName.FOLD, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element Fold </summary>
      ///     
      public virtual JDFFold appendFold()
      {
         return (JDFFold)appendElement(ElementName.FOLD, null);
      }

      ///     <summary> (26) getCreateSignatureCell
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFSignatureCell the element </returns>
      ///     
      public virtual JDFSignatureCell getCreateSignatureCell(int iSkip)
      {
         return (JDFSignatureCell)getCreateElement_KElement(ElementName.SIGNATURECELL, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element SignatureCell </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFSignatureCell the element </returns>
      ///     * default is getSignatureCell(0)     
      public virtual JDFSignatureCell getSignatureCell(int iSkip)
      {
         return (JDFSignatureCell)getElement(ElementName.SIGNATURECELL, null, iSkip);
      }

      ///    
      ///     <summary> * Get all SignatureCell from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFSignatureCell> </returns>
      ///     
      public virtual ICollection<JDFSignatureCell> getAllSignatureCell()
      {
         List<JDFSignatureCell> v = new List<JDFSignatureCell>();

         JDFSignatureCell kElem = (JDFSignatureCell)getFirstChildElement(ElementName.SIGNATURECELL, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFSignatureCell)kElem.getNextSiblingElement(ElementName.SIGNATURECELL, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element SignatureCell </summary>
      ///     
      public virtual JDFSignatureCell appendSignatureCell()
      {
         return (JDFSignatureCell)appendElement(ElementName.SIGNATURECELL, null);
      }
   }
}
