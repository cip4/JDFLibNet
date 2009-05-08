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
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;

   public abstract class JDFAutoCrease : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[8];
      static JDFAutoCrease()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.DEPTH, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.RELATIVESTARTPOSITION, 0x33333311, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.RELATIVEWORKINGPATH, 0x33333311, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.STARTPOSITION, 0x33333331, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.WORKINGPATH, 0x33333331, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.WORKINGDIRECTION, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumWorkingDirection.getEnum(0), null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.TRAVEL, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.RELATIVETRAVEL, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoCrease </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoCrease(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoCrease </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoCrease(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoCrease </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoCrease(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoCrease[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for WorkingDirection </summary>
      ///        

      public class EnumWorkingDirection : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumWorkingDirection(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumWorkingDirection getEnum(string enumName)
         {
            return (EnumWorkingDirection)getEnum(typeof(EnumWorkingDirection), enumName);
         }

         public static EnumWorkingDirection getEnum(int enumValue)
         {
            return (EnumWorkingDirection)getEnum(typeof(EnumWorkingDirection), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumWorkingDirection));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumWorkingDirection));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumWorkingDirection));
         }

         public static readonly EnumWorkingDirection Top = new EnumWorkingDirection("Top");
         public static readonly EnumWorkingDirection Bottom = new EnumWorkingDirection("Bottom");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute Depth
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Depth </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDepth(double @value)
      {
         setAttribute(AttributeName.DEPTH, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute Depth </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getDepth()
      {
         return getRealAttribute(AttributeName.DEPTH, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute RelativeStartPosition
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute RelativeStartPosition </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setRelativeStartPosition(JDFXYPair @value)
      {
         setAttribute(AttributeName.RELATIVESTARTPOSITION, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute RelativeStartPosition </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getRelativeStartPosition()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.RELATIVESTARTPOSITION, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute RelativeWorkingPath
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute RelativeWorkingPath </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setRelativeWorkingPath(JDFXYPair @value)
      {
         setAttribute(AttributeName.RELATIVEWORKINGPATH, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute RelativeWorkingPath </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getRelativeWorkingPath()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.RELATIVEWORKINGPATH, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute StartPosition
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute StartPosition </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setStartPosition(JDFXYPair @value)
      {
         setAttribute(AttributeName.STARTPOSITION, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute StartPosition </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getStartPosition()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.STARTPOSITION, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute WorkingPath
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute WorkingPath </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setWorkingPath(JDFXYPair @value)
      {
         setAttribute(AttributeName.WORKINGPATH, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute WorkingPath </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getWorkingPath()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.WORKINGPATH, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute WorkingDirection
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute WorkingDirection </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setWorkingDirection(EnumWorkingDirection enumVar)
      {
         setAttribute(AttributeName.WORKINGDIRECTION, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute WorkingDirection </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumWorkingDirection getWorkingDirection()
      {
         return EnumWorkingDirection.getEnum(getAttribute(AttributeName.WORKINGDIRECTION, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Travel
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Travel </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTravel(double @value)
      {
         setAttribute(AttributeName.TRAVEL, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute Travel </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getTravel()
      {
         return getRealAttribute(AttributeName.TRAVEL, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute RelativeTravel
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute RelativeTravel </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setRelativeTravel(double @value)
      {
         setAttribute(AttributeName.RELATIVETRAVEL, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute RelativeTravel </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getRelativeTravel()
      {
         return getRealAttribute(AttributeName.RELATIVETRAVEL, null, 0.0);
      }
   }
}