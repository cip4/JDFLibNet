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
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFNumberList = org.cip4.jdflib.datatypes.JDFNumberList;

   public abstract class JDFAutoLongGlue : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[6];
      static JDFAutoLongGlue()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.GLUEBRAND, 0x44444443, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.GLUETYPE, 0x44444443, AttributeInfo.EnumAttributeType.enumeration, EnumGlueType.getEnum(0), null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.LINEWIDTH, 0x44444443, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.MELTINGTEMPERATURE, 0x44444443, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.WORKINGLIST, 0x44444443, AttributeInfo.EnumAttributeType.string_, null, "0 1000000000");
         atrInfoTable[5] = new AtrInfoTable(AttributeName.XOFFSET, 0x44444442, AttributeInfo.EnumAttributeType.double_, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoLongGlue </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoLongGlue(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoLongGlue </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoLongGlue(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoLongGlue </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoLongGlue(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoLongGlue[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for GlueType </summary>
      ///        

      public class EnumGlueType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumGlueType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumGlueType getEnum(string enumName)
         {
            return (EnumGlueType)getEnum(typeof(EnumGlueType), enumName);
         }

         public static EnumGlueType getEnum(int enumValue)
         {
            return (EnumGlueType)getEnum(typeof(EnumGlueType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumGlueType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumGlueType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumGlueType));
         }

         public static readonly EnumGlueType ColdGlue = new EnumGlueType("ColdGlue");
         public static readonly EnumGlueType Hotmelt = new EnumGlueType("Hotmelt");
         public static readonly EnumGlueType PUR = new EnumGlueType("PUR");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute GlueBrand
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute GlueBrand </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setGlueBrand(string @value)
      {
         setAttribute(AttributeName.GLUEBRAND, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute GlueBrand </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getGlueBrand()
      {
         return getAttribute(AttributeName.GLUEBRAND, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute GlueType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute GlueType </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setGlueType(EnumGlueType enumVar)
      {
         setAttribute(AttributeName.GLUETYPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute GlueType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumGlueType getGlueType()
      {
         return EnumGlueType.getEnum(getAttribute(AttributeName.GLUETYPE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute LineWidth
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute LineWidth </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setLineWidth(double @value)
      {
         setAttribute(AttributeName.LINEWIDTH, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute LineWidth </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getLineWidth()
      {
         return getRealAttribute(AttributeName.LINEWIDTH, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MeltingTemperature
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MeltingTemperature </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMeltingTemperature(int @value)
      {
         setAttribute(AttributeName.MELTINGTEMPERATURE, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute MeltingTemperature </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getMeltingTemperature()
      {
         return getIntAttribute(AttributeName.MELTINGTEMPERATURE, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute WorkingList
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute WorkingList </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setWorkingList(JDFNumberList @value)
      {
         setAttribute(AttributeName.WORKINGLIST, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFNumberList attribute WorkingList </summary>
      ///          * <returns> JDFNumberList the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFNumberList </returns>
      ///          
      public virtual JDFNumberList getWorkingList()
      {
         string strAttrName = "";
         JDFNumberList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.WORKINGLIST, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute XOffset
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute XOffset </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setXOffset(double @value)
      {
         setAttribute(AttributeName.XOFFSET, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute XOffset </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getXOffset()
      {
         return getRealAttribute(AttributeName.XOFFSET, null, 0.0);
      }
   }
}
