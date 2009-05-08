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
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFResourceParam = org.cip4.jdflib.resource.JDFResourceParam;

   public abstract class JDFAutoResourceDefinitionParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[3];
      static JDFAutoResourceDefinitionParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.DEFAULTPRIORITY, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumDefaultPriority.getEnum(0), "DefaultJDF");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.DEFAULTID, 0x44444443, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.DEFAULTJDF, 0x33333333, AttributeInfo.EnumAttributeType.URL, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.RESOURCEPARAM, 0x33333331);
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
      ///     <summary> * Constructor for JDFAutoResourceDefinitionParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoResourceDefinitionParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoResourceDefinitionParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoResourceDefinitionParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoResourceDefinitionParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoResourceDefinitionParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoResourceDefinitionParams[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for DefaultPriority </summary>
      ///        

      public class EnumDefaultPriority : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumDefaultPriority(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumDefaultPriority getEnum(string enumName)
         {
            return (EnumDefaultPriority)getEnum(typeof(EnumDefaultPriority), enumName);
         }

         public static EnumDefaultPriority getEnum(int enumValue)
         {
            return (EnumDefaultPriority)getEnum(typeof(EnumDefaultPriority), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumDefaultPriority));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumDefaultPriority));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumDefaultPriority));
         }

         public static readonly EnumDefaultPriority Application = new EnumDefaultPriority("Application");
         public static readonly EnumDefaultPriority DefaultJDF = new EnumDefaultPriority("DefaultJDF");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute DefaultPriority
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute DefaultPriority </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setDefaultPriority(EnumDefaultPriority enumVar)
      {
         setAttribute(AttributeName.DEFAULTPRIORITY, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute DefaultPriority </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumDefaultPriority getDefaultPriority()
      {
         return EnumDefaultPriority.getEnum(getAttribute(AttributeName.DEFAULTPRIORITY, null, "DefaultJDF"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute DefaultID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DefaultID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDefaultID(string @value)
      {
         setAttribute(AttributeName.DEFAULTID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute DefaultID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getDefaultID()
      {
         return getAttribute(AttributeName.DEFAULTID, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute DefaultJDF
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DefaultJDF </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDefaultJDF(string @value)
      {
         setAttribute(AttributeName.DEFAULTJDF, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute DefaultJDF </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getDefaultJDF()
      {
         return getAttribute(AttributeName.DEFAULTJDF, null, JDFConstants.EMPTYSTRING);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateResourceParam
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFResourceParam the element </returns>
      ///     
      public virtual JDFResourceParam getCreateResourceParam(int iSkip)
      {
         return (JDFResourceParam)getCreateElement_KElement(ElementName.RESOURCEPARAM, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element ResourceParam </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFResourceParam the element </returns>
      ///     * default is getResourceParam(0)     
      public virtual JDFResourceParam getResourceParam(int iSkip)
      {
         return (JDFResourceParam)getElement(ElementName.RESOURCEPARAM, null, iSkip);
      }

      ///    
      ///     <summary> * Get all ResourceParam from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFResourceParam> </returns>
      ///     
      public virtual ICollection<JDFResourceParam> getAllResourceParam()
      {
         List<JDFResourceParam> v = new List<JDFResourceParam>();

         JDFResourceParam kElem = (JDFResourceParam)getFirstChildElement(ElementName.RESOURCEPARAM, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFResourceParam)kElem.getNextSiblingElement(ElementName.RESOURCEPARAM, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element ResourceParam </summary>
      ///     
      public virtual JDFResourceParam appendResourceParam()
      {
         return (JDFResourceParam)appendElement(ElementName.RESOURCEPARAM, null);
      }
   }
}
