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
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFFileSpec = org.cip4.jdflib.resource.process.JDFFileSpec;

   public abstract class JDFAutoFileAlias : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[5];
      static JDFAutoFileAlias()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ALIAS, 0x22222222, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.DISPOSITION, 0x44444433, AttributeInfo.EnumAttributeType.enumeration, EnumDisposition.getEnum(0), null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.MIMETYPE, 0x44444433, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.RAWALIAS, 0x33333311, AttributeInfo.EnumAttributeType.hexBinary, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.URL, 0x44444433, AttributeInfo.EnumAttributeType.URL, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.FILESPEC, 0x66666611);
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
      ///     <summary> * Constructor for JDFAutoFileAlias </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoFileAlias(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoFileAlias </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoFileAlias(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoFileAlias </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoFileAlias(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoFileAlias[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for Disposition </summary>
      ///        

      public class EnumDisposition : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumDisposition(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumDisposition getEnum(string enumName)
         {
            return (EnumDisposition)getEnum(typeof(EnumDisposition), enumName);
         }

         public static EnumDisposition getEnum(int enumValue)
         {
            return (EnumDisposition)getEnum(typeof(EnumDisposition), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumDisposition));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumDisposition));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumDisposition));
         }

         public static readonly EnumDisposition Unlink = new EnumDisposition("Unlink");
         public static readonly EnumDisposition Delete = new EnumDisposition("Delete");
         public static readonly EnumDisposition Retain = new EnumDisposition("Retain");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute Alias
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Alias </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAlias(string @value)
      {
         setAttribute(AttributeName.ALIAS, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Alias </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getAlias()
      {
         return getAttribute(AttributeName.ALIAS, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Disposition
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Disposition </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setDisposition(EnumDisposition enumVar)
      {
         setAttribute(AttributeName.DISPOSITION, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Disposition </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumDisposition getDisposition()
      {
         return EnumDisposition.getEnum(getAttribute(AttributeName.DISPOSITION, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MimeType
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MimeType </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMimeType(string @value)
      {
         setAttribute(AttributeName.MIMETYPE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute MimeType </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getMimeType()
      {
         return getAttribute(AttributeName.MIMETYPE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute RawAlias
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute RawAlias </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setRawAlias(string @value)
      {
         setAttribute(AttributeName.RAWALIAS, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute RawAlias </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getRawAlias()
      {
         return getAttribute(AttributeName.RAWALIAS, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute URL
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute URL </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setURL(string @value)
      {
         setAttribute(AttributeName.URL, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute URL </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getURL()
      {
         return getAttribute(AttributeName.URL, null, JDFConstants.EMPTYSTRING);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element FileSpec </summary>
      ///     * <returns> JDFFileSpec the element </returns>
      ///     
      public virtual JDFFileSpec getFileSpec()
      {
         return (JDFFileSpec)getElement(ElementName.FILESPEC, null, 0);
      }

      ///     <summary> (25) getCreateFileSpec
      ///     *  </summary>
      ///     * <returns> JDFFileSpec the element </returns>
      ///     
      public virtual JDFFileSpec getCreateFileSpec()
      {
         return (JDFFileSpec)getCreateElement_KElement(ElementName.FILESPEC, null, 0);
      }

      ///    
      ///     <summary> * (29) append element FileSpec </summary>
      ///     
      public virtual JDFFileSpec appendFileSpec()
      {
         return (JDFFileSpec)appendElementN(ElementName.FILESPEC, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refFileSpec(JDFFileSpec refTarget)
      {
         refElement(refTarget);
      }
   }
}
