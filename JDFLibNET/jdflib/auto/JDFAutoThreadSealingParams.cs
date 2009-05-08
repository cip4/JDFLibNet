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
   using JDFNumberList = org.cip4.jdflib.datatypes.JDFNumberList;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;

   public abstract class JDFAutoThreadSealingParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[6];
      static JDFAutoThreadSealingParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.BLINDSTITCH, 0x33333331, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.THREADMATERIAL, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumThreadMaterial.getEnum(0), null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.THREADPOSITIONS, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.THREADLENGTH, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.THREADSTITCHWIDTH, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.SEALINGTEMPERATURE, 0x33333331, AttributeInfo.EnumAttributeType.integer, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoThreadSealingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoThreadSealingParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoThreadSealingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoThreadSealingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoThreadSealingParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoThreadSealingParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoThreadSealingParams[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for ThreadMaterial </summary>
      ///        

      public class EnumThreadMaterial : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumThreadMaterial(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumThreadMaterial getEnum(string enumName)
         {
            return (EnumThreadMaterial)getEnum(typeof(EnumThreadMaterial), enumName);
         }

         public static EnumThreadMaterial getEnum(int enumValue)
         {
            return (EnumThreadMaterial)getEnum(typeof(EnumThreadMaterial), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumThreadMaterial));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumThreadMaterial));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumThreadMaterial));
         }

         public static readonly EnumThreadMaterial Cotton = new EnumThreadMaterial("Cotton");
         public static readonly EnumThreadMaterial Nylon = new EnumThreadMaterial("Nylon");
         public static readonly EnumThreadMaterial Polyester = new EnumThreadMaterial("Polyester");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute BlindStitch
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BlindStitch </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBlindStitch(bool @value)
      {
         setAttribute(AttributeName.BLINDSTITCH, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute BlindStitch </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getBlindStitch()
      {
         return getBoolAttribute(AttributeName.BLINDSTITCH, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ThreadMaterial
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute ThreadMaterial </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setThreadMaterial(EnumThreadMaterial enumVar)
      {
         setAttribute(AttributeName.THREADMATERIAL, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute ThreadMaterial </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumThreadMaterial getThreadMaterial()
      {
         return EnumThreadMaterial.getEnum(getAttribute(AttributeName.THREADMATERIAL, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ThreadPositions
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ThreadPositions </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setThreadPositions(JDFNumberList @value)
      {
         setAttribute(AttributeName.THREADPOSITIONS, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFNumberList attribute ThreadPositions </summary>
      ///          * <returns> JDFNumberList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFNumberList </returns>
      ///          
      public virtual JDFNumberList getThreadPositions()
      {
         string strAttrName = "";
         JDFNumberList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.THREADPOSITIONS, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute ThreadLength
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ThreadLength </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setThreadLength(double @value)
      {
         setAttribute(AttributeName.THREADLENGTH, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute ThreadLength </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getThreadLength()
      {
         return getRealAttribute(AttributeName.THREADLENGTH, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ThreadStitchWidth
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ThreadStitchWidth </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setThreadStitchWidth(double @value)
      {
         setAttribute(AttributeName.THREADSTITCHWIDTH, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute ThreadStitchWidth </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getThreadStitchWidth()
      {
         return getRealAttribute(AttributeName.THREADSTITCHWIDTH, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SealingTemperature
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SealingTemperature </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSealingTemperature(int @value)
      {
         setAttribute(AttributeName.SEALINGTEMPERATURE, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute SealingTemperature </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getSealingTemperature()
      {
         return getIntAttribute(AttributeName.SEALINGTEMPERATURE, null, 0);
      }
   }
}
