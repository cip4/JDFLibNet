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
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;

   public abstract class JDFAutoObjectResolution : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[3];
      static JDFAutoObjectResolution()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.RESOLUTION, 0x22222222, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.SOURCEOBJECTS, 0x33333333, AttributeInfo.EnumAttributeType.enumerations, EnumSourceObjects.getEnum(0), "All");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.ANTIALIASING, 0x33333311, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoObjectResolution </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoObjectResolution(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoObjectResolution </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoObjectResolution(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoObjectResolution </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoObjectResolution(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoObjectResolution[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for SourceObjects </summary>
      ///        

      public class EnumSourceObjects : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumSourceObjects(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumSourceObjects getEnum(string enumName)
         {
            return (EnumSourceObjects)getEnum(typeof(EnumSourceObjects), enumName);
         }

         public static EnumSourceObjects getEnum(int enumValue)
         {
            return (EnumSourceObjects)getEnum(typeof(EnumSourceObjects), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumSourceObjects));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumSourceObjects));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumSourceObjects));
         }

         public static readonly EnumSourceObjects All = new EnumSourceObjects("All");
         public static readonly EnumSourceObjects ImagePhotographic = new EnumSourceObjects("ImagePhotographic");
         public static readonly EnumSourceObjects ImageScreenShot = new EnumSourceObjects("ImageScreenShot");
         public static readonly EnumSourceObjects Text = new EnumSourceObjects("Text");
         public static readonly EnumSourceObjects LineArt = new EnumSourceObjects("LineArt");
         public static readonly EnumSourceObjects SmoothShades = new EnumSourceObjects("SmoothShades");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute Resolution
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Resolution </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setResolution(JDFXYPair @value)
      {
         setAttribute(AttributeName.RESOLUTION, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute Resolution </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getResolution()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.RESOLUTION, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute SourceObjects
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5.2) set attribute SourceObjects </summary>
      ///          * <param name="v"> vector of the enumeration values </param>
      ///          
      public virtual void setSourceObjects(List<ValuedEnum> v)
      {
         setEnumerationsAttribute(AttributeName.SOURCEOBJECTS, v, null);
      }

      ///        
      ///          <summary> * (9.2) get SourceObjects attribute SourceObjects </summary>
      ///          * <returns> Vector of the enumerations </returns>
      ///          
      public virtual List<ValuedEnum> getSourceObjects()
      {
         return getEnumerationsAttribute(AttributeName.SOURCEOBJECTS, null, EnumSourceObjects.All, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute AntiAliasing
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute AntiAliasing </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAntiAliasing(string @value)
      {
         setAttribute(AttributeName.ANTIALIASING, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute AntiAliasing </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getAntiAliasing()
      {
         return getAttribute(AttributeName.ANTIALIASING, null, JDFConstants.EMPTYSTRING);
      }
   }
}
