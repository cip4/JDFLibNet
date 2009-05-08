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
   using JDFResource = org.cip4.jdflib.resource.JDFResource;

   public abstract class JDFAutoFold : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[4];
      static JDFAutoFold()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.FROM, 0x22222221, AttributeInfo.EnumAttributeType.enumeration, EnumFrom.getEnum(0), null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.TO, 0x22222221, AttributeInfo.EnumAttributeType.enumeration, EnumTo.getEnum(0), null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.TRAVEL, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.RELATIVETRAVEL, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoFold </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoFold(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoFold </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoFold(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoFold </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoFold(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoFold[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for From </summary>
      ///        

      public class EnumFrom : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumFrom(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumFrom getEnum(string enumName)
         {
            return (EnumFrom)getEnum(typeof(EnumFrom), enumName);
         }

         public static EnumFrom getEnum(int enumValue)
         {
            return (EnumFrom)getEnum(typeof(EnumFrom), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumFrom));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumFrom));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumFrom));
         }

         public static readonly EnumFrom Front = new EnumFrom("Front");
         public static readonly EnumFrom Left = new EnumFrom("Left");
      }



      ///        
      ///        <summary> * Enumeration strings for To </summary>
      ///        

      public class EnumTo : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumTo(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumTo getEnum(string enumName)
         {
            return (EnumTo)getEnum(typeof(EnumTo), enumName);
         }

         public static EnumTo getEnum(int enumValue)
         {
            return (EnumTo)getEnum(typeof(EnumTo), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumTo));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumTo));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumTo));
         }

         public static readonly EnumTo Up = new EnumTo("Up");
         public static readonly EnumTo Down = new EnumTo("Down");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute From
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute From </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setFrom(EnumFrom enumVar)
      {
         setAttribute(AttributeName.FROM, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute From </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumFrom getFrom()
      {
         return EnumFrom.getEnum(getAttribute(AttributeName.FROM, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute To
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute To </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setTo(EnumTo enumVar)
      {
         setAttribute(AttributeName.TO, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute To </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumTo getTo()
      {
         return EnumTo.getEnum(getAttribute(AttributeName.TO, null, null));
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
