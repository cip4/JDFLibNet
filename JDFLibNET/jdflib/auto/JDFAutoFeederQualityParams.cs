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
   using JDFElement = org.cip4.jdflib.core.JDFElement;

   public abstract class JDFAutoFeederQualityParams : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[6];
      static JDFAutoFeederQualityParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.INCORRECTCOMPONENTQUALITY, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumIncorrectComponentQuality.getEnum(0), null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.INCORRECTCOMPONENTS, 0x33333311, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.DOUBLEFEEDQUALITY, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumDoubleFeedQuality.getEnum(0), null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.DOUBLEFEEDS, 0x33333311, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.BADFEEDQUALITY, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumBadFeedQuality.getEnum(0), null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.BADFEEDS, 0x33333311, AttributeInfo.EnumAttributeType.integer, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoFeederQualityParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoFeederQualityParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoFeederQualityParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoFeederQualityParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoFeederQualityParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoFeederQualityParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoFeederQualityParams[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for IncorrectComponentQuality </summary>
      ///        

      public class EnumIncorrectComponentQuality : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumIncorrectComponentQuality(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumIncorrectComponentQuality getEnum(string enumName)
         {
            return (EnumIncorrectComponentQuality)getEnum(typeof(EnumIncorrectComponentQuality), enumName);
         }

         public static EnumIncorrectComponentQuality getEnum(int enumValue)
         {
            return (EnumIncorrectComponentQuality)getEnum(typeof(EnumIncorrectComponentQuality), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumIncorrectComponentQuality));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumIncorrectComponentQuality));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumIncorrectComponentQuality));
         }

         public static readonly EnumIncorrectComponentQuality NotActive = new EnumIncorrectComponentQuality("NotActive");
         public static readonly EnumIncorrectComponentQuality Check = new EnumIncorrectComponentQuality("Check");
         public static readonly EnumIncorrectComponentQuality Waste = new EnumIncorrectComponentQuality("Waste");
         public static readonly EnumIncorrectComponentQuality StopNoWaste = new EnumIncorrectComponentQuality("StopNoWaste");
         public static readonly EnumIncorrectComponentQuality StopWaste = new EnumIncorrectComponentQuality("StopWaste");
      }



      ///        
      ///        <summary> * Enumeration strings for DoubleFeedQuality </summary>
      ///        

      public class EnumDoubleFeedQuality : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumDoubleFeedQuality(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumDoubleFeedQuality getEnum(string enumName)
         {
            return (EnumDoubleFeedQuality)getEnum(typeof(EnumDoubleFeedQuality), enumName);
         }

         public static EnumDoubleFeedQuality getEnum(int enumValue)
         {
            return (EnumDoubleFeedQuality)getEnum(typeof(EnumDoubleFeedQuality), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumDoubleFeedQuality));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumDoubleFeedQuality));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumDoubleFeedQuality));
         }

         public static readonly EnumDoubleFeedQuality NotActive = new EnumDoubleFeedQuality("NotActive");
         public static readonly EnumDoubleFeedQuality Check = new EnumDoubleFeedQuality("Check");
         public static readonly EnumDoubleFeedQuality Waste = new EnumDoubleFeedQuality("Waste");
         public static readonly EnumDoubleFeedQuality StopNoWaste = new EnumDoubleFeedQuality("StopNoWaste");
         public static readonly EnumDoubleFeedQuality StopWaste = new EnumDoubleFeedQuality("StopWaste");
      }



      ///        
      ///        <summary> * Enumeration strings for BadFeedQuality </summary>
      ///        

      public class EnumBadFeedQuality : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumBadFeedQuality(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumBadFeedQuality getEnum(string enumName)
         {
            return (EnumBadFeedQuality)getEnum(typeof(EnumBadFeedQuality), enumName);
         }

         public static EnumBadFeedQuality getEnum(int enumValue)
         {
            return (EnumBadFeedQuality)getEnum(typeof(EnumBadFeedQuality), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumBadFeedQuality));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumBadFeedQuality));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumBadFeedQuality));
         }

         public static readonly EnumBadFeedQuality NotActive = new EnumBadFeedQuality("NotActive");
         public static readonly EnumBadFeedQuality Check = new EnumBadFeedQuality("Check");
         public static readonly EnumBadFeedQuality Waste = new EnumBadFeedQuality("Waste");
         public static readonly EnumBadFeedQuality StopNoWaste = new EnumBadFeedQuality("StopNoWaste");
         public static readonly EnumBadFeedQuality StopWaste = new EnumBadFeedQuality("StopWaste");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute IncorrectComponentQuality
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute IncorrectComponentQuality </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setIncorrectComponentQuality(EnumIncorrectComponentQuality enumVar)
      {
         setAttribute(AttributeName.INCORRECTCOMPONENTQUALITY, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute IncorrectComponentQuality </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumIncorrectComponentQuality getIncorrectComponentQuality()
      {
         return EnumIncorrectComponentQuality.getEnum(getAttribute(AttributeName.INCORRECTCOMPONENTQUALITY, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute IncorrectComponents
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute IncorrectComponents </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setIncorrectComponents(int @value)
      {
         setAttribute(AttributeName.INCORRECTCOMPONENTS, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute IncorrectComponents </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getIncorrectComponents()
      {
         return getIntAttribute(AttributeName.INCORRECTCOMPONENTS, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute DoubleFeedQuality
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute DoubleFeedQuality </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setDoubleFeedQuality(EnumDoubleFeedQuality enumVar)
      {
         setAttribute(AttributeName.DOUBLEFEEDQUALITY, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute DoubleFeedQuality </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumDoubleFeedQuality getDoubleFeedQuality()
      {
         return EnumDoubleFeedQuality.getEnum(getAttribute(AttributeName.DOUBLEFEEDQUALITY, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute DoubleFeeds
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DoubleFeeds </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDoubleFeeds(int @value)
      {
         setAttribute(AttributeName.DOUBLEFEEDS, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute DoubleFeeds </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getDoubleFeeds()
      {
         return getIntAttribute(AttributeName.DOUBLEFEEDS, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute BadFeedQuality
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute BadFeedQuality </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setBadFeedQuality(EnumBadFeedQuality enumVar)
      {
         setAttribute(AttributeName.BADFEEDQUALITY, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute BadFeedQuality </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumBadFeedQuality getBadFeedQuality()
      {
         return EnumBadFeedQuality.getEnum(getAttribute(AttributeName.BADFEEDQUALITY, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute BadFeeds
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute BadFeeds </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBadFeeds(int @value)
      {
         setAttribute(AttributeName.BADFEEDS, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute BadFeeds </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getBadFeeds()
      {
         return getIntAttribute(AttributeName.BADFEEDS, null, 0);
      }
   }
}
