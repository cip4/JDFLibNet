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
 * THIS SOFTWARE IS PROVIDED ``AS IS'' AND ANY EXPRESSED OR IMPLIED
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
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using VString = org.cip4.jdflib.core.VString;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;

   public abstract class JDFAutoComChannel : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[4];
      static JDFAutoComChannel()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.CHANNELTYPE, 0x22222222, AttributeInfo.EnumAttributeType.enumeration, EnumChannelType.getEnum(0), null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.LOCATOR, 0x22222222, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.CHANNELTYPEDETAILS, 0x33333311, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.CHANNELUSAGE, 0x33333311, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoComChannel </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoComChannel(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoComChannel </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoComChannel(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoComChannel </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoComChannel(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoComChannel[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for ChannelType </summary>
      ///        

      public class EnumChannelType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumChannelType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumChannelType getEnum(string enumName)
         {
            return (EnumChannelType)getEnum(typeof(EnumChannelType), enumName);
         }

         public static EnumChannelType getEnum(int enumValue)
         {
            return (EnumChannelType)getEnum(typeof(EnumChannelType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumChannelType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumChannelType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumChannelType));
         }

         public static readonly EnumChannelType Phone = new EnumChannelType("Phone");
         public static readonly EnumChannelType Email = new EnumChannelType("Email");
         public static readonly EnumChannelType Fax = new EnumChannelType("Fax");
         public static readonly EnumChannelType WWW = new EnumChannelType("WWW");
         public static readonly EnumChannelType JMF = new EnumChannelType("JMF");
         public static readonly EnumChannelType PrivateDirectory = new EnumChannelType("PrivateDirectory");
         public static readonly EnumChannelType InstantMessaging = new EnumChannelType("InstantMessaging");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute ChannelType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute ChannelType </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setChannelType(EnumChannelType enumVar)
      {
         setAttribute(AttributeName.CHANNELTYPE, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute ChannelType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumChannelType getChannelType()
      {
         return EnumChannelType.getEnum(getAttribute(AttributeName.CHANNELTYPE, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Locator
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Locator </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setLocator(string @value)
      {
         setAttribute(AttributeName.LOCATOR, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Locator </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getLocator()
      {
         return getAttribute(AttributeName.LOCATOR, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ChannelTypeDetails
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ChannelTypeDetails </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setChannelTypeDetails(string @value)
      {
         setAttribute(AttributeName.CHANNELTYPEDETAILS, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ChannelTypeDetails </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getChannelTypeDetails()
      {
         return getAttribute(AttributeName.CHANNELTYPEDETAILS, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ChannelUsage
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ChannelUsage </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setChannelUsage(VString @value)
      {
         setAttribute(AttributeName.CHANNELUSAGE, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute ChannelUsage </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getChannelUsage()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.CHANNELUSAGE, null, JDFConstants.EMPTYSTRING);
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
      }
   }
}
