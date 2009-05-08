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
   using JDFDate = org.cip4.jdflib.util.JDFDate;
   using JDFDuration = org.cip4.jdflib.util.JDFDuration;

   public abstract class JDFAutoDisposition : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[6];
      static JDFAutoDisposition()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.DISPOSITIONACTION, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumDispositionAction.getEnum(0), "Delete");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.PRIORITY, 0x33333311, AttributeInfo.EnumAttributeType.integer, null, "0");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.DISPOSITIONUSAGE, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumDispositionUsage.getEnum(0), null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.EXTRADURATION, 0x33333311, AttributeInfo.EnumAttributeType.duration, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.MINDURATION, 0x33333311, AttributeInfo.EnumAttributeType.duration, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.UNTIL, 0x33333311, AttributeInfo.EnumAttributeType.dateTime, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoDisposition </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoDisposition(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoDisposition </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoDisposition(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoDisposition </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoDisposition(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoDisposition[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for DispositionAction </summary>
      ///        

      public class EnumDispositionAction : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumDispositionAction(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumDispositionAction getEnum(string enumName)
         {
            return (EnumDispositionAction)getEnum(typeof(EnumDispositionAction), enumName);
         }

         public static EnumDispositionAction getEnum(int enumValue)
         {
            return (EnumDispositionAction)getEnum(typeof(EnumDispositionAction), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumDispositionAction));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumDispositionAction));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumDispositionAction));
         }

         public static readonly EnumDispositionAction Delete = new EnumDispositionAction("Delete");
         public static readonly EnumDispositionAction Archive = new EnumDispositionAction("Archive");
      }



      ///        
      ///        <summary> * Enumeration strings for DispositionUsage </summary>
      ///        

      public class EnumDispositionUsage : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumDispositionUsage(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumDispositionUsage getEnum(string enumName)
         {
            return (EnumDispositionUsage)getEnum(typeof(EnumDispositionUsage), enumName);
         }

         public static EnumDispositionUsage getEnum(int enumValue)
         {
            return (EnumDispositionUsage)getEnum(typeof(EnumDispositionUsage), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumDispositionUsage));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumDispositionUsage));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumDispositionUsage));
         }

         public static readonly EnumDispositionUsage Input = new EnumDispositionUsage("Input");
         public static readonly EnumDispositionUsage Output = new EnumDispositionUsage("Output");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute DispositionAction
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute DispositionAction </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setDispositionAction(EnumDispositionAction enumVar)
      {
         setAttribute(AttributeName.DISPOSITIONACTION, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute DispositionAction </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumDispositionAction getDispositionAction()
      {
         return EnumDispositionAction.getEnum(getAttribute(AttributeName.DISPOSITIONACTION, null, "Delete"));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Priority
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Priority </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPriority(int @value)
      {
         setAttribute(AttributeName.PRIORITY, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute Priority </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getPriority()
      {
         return getIntAttribute(AttributeName.PRIORITY, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute DispositionUsage
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute DispositionUsage </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setDispositionUsage(EnumDispositionUsage enumVar)
      {
         setAttribute(AttributeName.DISPOSITIONUSAGE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute DispositionUsage </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumDispositionUsage getDispositionUsage()
      {
         return EnumDispositionUsage.getEnum(getAttribute(AttributeName.DISPOSITIONUSAGE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ExtraDuration
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ExtraDuration </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setExtraDuration(JDFDuration @value)
      {
         setAttribute(AttributeName.EXTRADURATION, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFDuration attribute ExtraDuration </summary>
      ///          * <returns> JDFDuration the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFDuration </returns>
      ///          
      public virtual JDFDuration getExtraDuration()
      {
         string strAttrName = "";
         JDFDuration nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.EXTRADURATION, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFDuration(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MinDuration
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MinDuration </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMinDuration(JDFDuration @value)
      {
         setAttribute(AttributeName.MINDURATION, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFDuration attribute MinDuration </summary>
      ///          * <returns> JDFDuration the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFDuration </returns>
      ///          
      public virtual JDFDuration getMinDuration()
      {
         string strAttrName = "";
         JDFDuration nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.MINDURATION, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFDuration(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Until
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (11) set attribute Until </summary>
      ///          * <param name="value">: the value to set the attribute to or null </param>
      ///          
      public virtual void setUntil(JDFDate @value)
      {
         JDFDate date = @value;
         if (date == null)
            date = new JDFDate();
         setAttribute(AttributeName.UNTIL, date.DateTimeISO, null);
      }

      ///        
      ///          <summary> * (12) get JDFDate attribute Until </summary>
      ///          * <returns> JDFDate the value of the attribute </returns>
      ///          
      public virtual JDFDate getUntil()
      {
         JDFDate nMyDate = null;
         string str = JDFConstants.EMPTYSTRING;
         str = getAttribute(AttributeName.UNTIL, null, JDFConstants.EMPTYSTRING);
         if (!JDFConstants.EMPTYSTRING.Equals(str))
         {
            try
            {
               nMyDate = new JDFDate(str);
            }
            catch (FormatException)
            {
               // throw new JDFException("not a valid date string. Malformed JDF - return null");
            }
         }
         return nMyDate;
      }
   }
}
