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
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFMatrix = org.cip4.jdflib.datatypes.JDFMatrix;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;

   public abstract class JDFAutoLabelingParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[3];
      static JDFAutoLabelingParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.CTM, 0x33333331, AttributeInfo.EnumAttributeType.matrix, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.APPLICATION, 0x33333331, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.POSITION, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumPosition.getEnum(0), null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoLabelingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoLabelingParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoLabelingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoLabelingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoLabelingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoLabelingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoLabelingParams[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for Position </summary>
      ///        

      public class EnumPosition : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumPosition(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumPosition getEnum(string enumName)
         {
            return (EnumPosition)getEnum(typeof(EnumPosition), enumName);
         }

         public static EnumPosition getEnum(int enumValue)
         {
            return (EnumPosition)getEnum(typeof(EnumPosition), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumPosition));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumPosition));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumPosition));
         }

         public static readonly EnumPosition Top = new EnumPosition("Top");
         public static readonly EnumPosition Bottom = new EnumPosition("Bottom");
         public static readonly EnumPosition Left = new EnumPosition("Left");
         public static readonly EnumPosition Right = new EnumPosition("Right");
         public static readonly EnumPosition Front = new EnumPosition("Front");
         public static readonly EnumPosition Back = new EnumPosition("Back");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute CTM
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CTM </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCTM(JDFMatrix @value)
      {
         setAttribute(AttributeName.CTM, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFMatrix attribute CTM </summary>
      ///          * <returns> JDFMatrix the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFMatrix </returns>
      ///          
      public virtual JDFMatrix getCTM()
      {
         string strAttrName = "";
         JDFMatrix nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.CTM, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute Application
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Application </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setApplication(string @value)
      {
         setAttribute(AttributeName.APPLICATION, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Application </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getApplication()
      {
         return getAttribute(AttributeName.APPLICATION, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Position
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Position </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setPosition(EnumPosition enumVar)
      {
         setAttribute(AttributeName.POSITION, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Position </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumPosition getPosition()
      {
         return EnumPosition.getEnum(getAttribute(AttributeName.POSITION, null, null));
      }
   }
}
