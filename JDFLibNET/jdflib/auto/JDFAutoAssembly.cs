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
   using VString = org.cip4.jdflib.core.VString;
   using JDFIntegerList = org.cip4.jdflib.datatypes.JDFIntegerList;
   using JDFPageList = org.cip4.jdflib.resource.JDFPageList;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFAssemblySection = org.cip4.jdflib.resource.process.JDFAssemblySection;
   using JDFPageAssignedList = org.cip4.jdflib.resource.process.JDFPageAssignedList;

   public abstract class JDFAutoAssembly : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[7];
      static JDFAutoAssembly()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.JOGSIDE, 0x33333111, AttributeInfo.EnumAttributeType.enumeration, EnumJogSide.getEnum(0), "Top");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.ORDER, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumOrder.getEnum(0), "Gathering");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.BINDINGSIDE, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumBindingSide.getEnum(0), "Left");
         atrInfoTable[3] = new AtrInfoTable(AttributeName.ASSEMBLYID, 0x44444311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.ASSEMBLYIDS, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.JOBID, 0x33333311, AttributeInfo.EnumAttributeType.shortString, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.PHYSICALSECTION, 0x33333111, AttributeInfo.EnumAttributeType.IntegerList, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.ASSEMBLYSECTION, 0x33333311);
         elemInfoTable[1] = new ElemInfoTable(ElementName.PAGELIST, 0x66666111);
         elemInfoTable[2] = new ElemInfoTable(ElementName.PAGEASSIGNEDLIST, 0x33333111);
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
      ///     <summary> * Constructor for JDFAutoAssembly </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoAssembly(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoAssembly </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoAssembly(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoAssembly </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoAssembly(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      /// <summary>
      /// String representation of this object
      /// </summary>
      /// <returns>string</returns>
      public override string ToString()
      {
         return " JDFAutoAssembly[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for JogSide </summary>
      ///        

      public class EnumJogSide : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumJogSide(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumJogSide getEnum(string enumName)
         {
            return (EnumJogSide)getEnum(typeof(EnumJogSide), enumName);
         }

         public static EnumJogSide getEnum(int enumValue)
         {
            return (EnumJogSide)getEnum(typeof(EnumJogSide), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumJogSide));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumJogSide));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumJogSide));
         }

         public static readonly EnumJogSide Left = new EnumJogSide("Left");
         public static readonly EnumJogSide Right = new EnumJogSide("Right");
         public static readonly EnumJogSide Top = new EnumJogSide("Top");
         public static readonly EnumJogSide Bottom = new EnumJogSide("Bottom");
         public static readonly EnumJogSide None = new EnumJogSide("None");
      }



      ///        
      ///        <summary> * Enumeration strings for Order </summary>
      ///        

      public class EnumOrder : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumOrder(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumOrder getEnum(string enumName)
         {
            return (EnumOrder)getEnum(typeof(EnumOrder), enumName);
         }

         public static EnumOrder getEnum(int enumValue)
         {
            return (EnumOrder)getEnum(typeof(EnumOrder), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumOrder));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumOrder));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumOrder));
         }

         public static readonly EnumOrder Collecting = new EnumOrder("Collecting");
         public static readonly EnumOrder Gathering = new EnumOrder("Gathering");
         public static readonly EnumOrder None = new EnumOrder("None");
         public static readonly EnumOrder List = new EnumOrder("List");
      }



      ///        
      ///        <summary> * Enumeration strings for BindingSide </summary>
      ///        

      public class EnumBindingSide : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumBindingSide(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumBindingSide getEnum(string enumName)
         {
            return (EnumBindingSide)getEnum(typeof(EnumBindingSide), enumName);
         }

         public static EnumBindingSide getEnum(int enumValue)
         {
            return (EnumBindingSide)getEnum(typeof(EnumBindingSide), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumBindingSide));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumBindingSide));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumBindingSide));
         }

         public static readonly EnumBindingSide Left = new EnumBindingSide("Left");
         public static readonly EnumBindingSide Right = new EnumBindingSide("Right");
         public static readonly EnumBindingSide Top = new EnumBindingSide("Top");
         public static readonly EnumBindingSide Bottom = new EnumBindingSide("Bottom");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute JogSide
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute JogSide </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setJogSide(EnumJogSide enumVar)
      {
         setAttribute(AttributeName.JOGSIDE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute JogSide </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumJogSide getJogSide()
      {
         return EnumJogSide.getEnum(getAttribute(AttributeName.JOGSIDE, null, "Top"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Order
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Order </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setOrder(EnumOrder enumVar)
      {
         setAttribute(AttributeName.ORDER, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Order </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumOrder getOrder()
      {
         return EnumOrder.getEnum(getAttribute(AttributeName.ORDER, null, "Gathering"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute BindingSide
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute BindingSide </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setBindingSide(EnumBindingSide enumVar)
      {
         setAttribute(AttributeName.BINDINGSIDE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute BindingSide </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumBindingSide getBindingSide()
      {
         return EnumBindingSide.getEnum(getAttribute(AttributeName.BINDINGSIDE, null, "Left"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute AssemblyID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute AssemblyID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAssemblyID(string @value)
      {
         setAttribute(AttributeName.ASSEMBLYID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute AssemblyID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getAssemblyID()
      {
         return getAttribute(AttributeName.ASSEMBLYID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute AssemblyIDs
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute AssemblyIDs </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAssemblyIDs(VString @value)
      {
         setAttribute(AttributeName.ASSEMBLYIDS, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute AssemblyIDs </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getAssemblyIDs()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.ASSEMBLYIDS, null, JDFConstants.EMPTYSTRING);
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute JobID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute JobID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setJobID(string @value)
      {
         setAttribute(AttributeName.JOBID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute JobID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getJobID()
      {
         return getAttribute(AttributeName.JOBID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PhysicalSection
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PhysicalSection </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPhysicalSection(JDFIntegerList @value)
      {
         setAttribute(AttributeName.PHYSICALSECTION, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFIntegerList attribute PhysicalSection </summary>
      ///          * <returns> JDFIntegerList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFIntegerList </returns>
      ///          
      public virtual JDFIntegerList getPhysicalSection()
      {
         string strAttrName = "";
         JDFIntegerList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.PHYSICALSECTION, null, JDFConstants.EMPTYSTRING);
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

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateAssemblySection
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFAssemblySection the element </returns>
      ///     
      public virtual JDFAssemblySection getCreateAssemblySection(int iSkip)
      {
         return (JDFAssemblySection)getCreateElement_KElement(ElementName.ASSEMBLYSECTION, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element AssemblySection </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFAssemblySection the element </returns>
      ///     * default is getAssemblySection(0)     
      public virtual JDFAssemblySection getAssemblySection(int iSkip)
      {
         return (JDFAssemblySection)getElement(ElementName.ASSEMBLYSECTION, null, iSkip);
      }

      ///    
      ///     <summary> * Get all AssemblySection from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFAssemblySection> </returns>
      ///     
      public virtual ICollection<JDFAssemblySection> getAllAssemblySection()
      {
         List<JDFAssemblySection> v = new List<JDFAssemblySection>();

         JDFAssemblySection kElem = (JDFAssemblySection)getFirstChildElement(ElementName.ASSEMBLYSECTION, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFAssemblySection)kElem.getNextSiblingElement(ElementName.ASSEMBLYSECTION, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element AssemblySection </summary>
      ///     
      public virtual JDFAssemblySection appendAssemblySection()
      {
         return (JDFAssemblySection)appendElement(ElementName.ASSEMBLYSECTION, null);
      }

      ///    
      ///     <summary> * (24) const get element PageList </summary>
      ///     * <returns> JDFPageList the element </returns>
      ///     
      public virtual JDFPageList getPageList()
      {
         return (JDFPageList)getElement(ElementName.PAGELIST, null, 0);
      }

      ///     <summary> (25) getCreatePageList
      ///     *  </summary>
      ///     * <returns> JDFPageList the element </returns>
      ///     
      public virtual JDFPageList getCreatePageList()
      {
         return (JDFPageList)getCreateElement_KElement(ElementName.PAGELIST, null, 0);
      }

      ///    
      ///     <summary> * (29) append element PageList </summary>
      ///     
      public virtual JDFPageList appendPageList()
      {
         return (JDFPageList)appendElementN(ElementName.PAGELIST, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refPageList(JDFPageList refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreatePageAssignedList
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFPageAssignedList the element </returns>
      ///     
      public virtual JDFPageAssignedList getCreatePageAssignedList(int iSkip)
      {
         return (JDFPageAssignedList)getCreateElement_KElement(ElementName.PAGEASSIGNEDLIST, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element PageAssignedList </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFPageAssignedList the element </returns>
      ///     * default is getPageAssignedList(0)     
      public virtual JDFPageAssignedList getPageAssignedList(int iSkip)
      {
         return (JDFPageAssignedList)getElement(ElementName.PAGEASSIGNEDLIST, null, iSkip);
      }

      ///    
      ///     <summary> * Get all PageAssignedList from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFPageAssignedList> </returns>
      ///     
      public virtual ICollection<JDFPageAssignedList> getAllPageAssignedList()
      {
         List<JDFPageAssignedList> v = new List<JDFPageAssignedList>();

         JDFPageAssignedList kElem = (JDFPageAssignedList)getFirstChildElement(ElementName.PAGEASSIGNEDLIST, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFPageAssignedList)kElem.getNextSiblingElement(ElementName.PAGEASSIGNEDLIST, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element PageAssignedList </summary>
      ///     
      public virtual JDFPageAssignedList appendPageAssignedList()
      {
         return (JDFPageAssignedList)appendElement(ElementName.PAGEASSIGNEDLIST, null);
      }
   }
}
