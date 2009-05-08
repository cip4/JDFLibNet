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



/*
 * Copyright (c) 2001 Heidelberger Druckmaschinen AG, All Rights Reserved.
 *
 * JDFOptionSpan.cs
 *
 * Last changes
 */

namespace org.cip4.jdflib.span
{


   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;

   public class JDFOptionSpan : JDFSpanBase
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFOptionSpan
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFOptionSpan(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFOptionSpan
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFOptionSpan(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFOptionSpan
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="localName"> </param>
      ///	 
      public JDFOptionSpan(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[4];
      static JDFOptionSpan()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ACTUAL, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.PREFERRED, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.RANGE, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKENS, null, null); // TODO
         // true
         // false
         // only
         atrInfoTable[3] = new AtrInfoTable(AttributeName.OFFERRANGE, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }

      // **************************************** Methods
      // *********************************************
      ///   
      ///	 <summary> * toString
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public override string ToString()
      {
         return "JDFOptionSpan[ --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * Set attribute Actual
      ///	 *  </summary>
      ///	 * <param name="boolean"> value - the value to set </param>
      ///	 
      public virtual void setActual(bool @value)
      {
         setAttribute(AttributeName.ACTUAL, @value, null);
      }

      ///   
      ///	 <summary> * Get attribute Actual value
      ///	 *  </summary>
      ///	 * <returns> boolean - the value of attribute Actual </returns>
      ///	 
      public virtual bool getActual()
      {
         return getBoolAttribute(AttributeName.ACTUAL, null, false);
      }

      ///   
      ///	 <summary> * Set attribute Preferred
      ///	 *  </summary>
      ///	 * <param name="boolean"> value - the value to set </param>
      ///	 
      public virtual void setPreferred(bool @value)
      {
         setAttribute(AttributeName.PREFERRED, @value, null);
      }

      ///   
      ///	 <summary> * Get attribute Preferred value
      ///	 *  </summary>
      ///	 * <returns> boolean - the value of attribute Preferred </returns>
      ///	 
      public virtual bool getPreferred()
      {
         return getBoolAttribute(AttributeName.PREFERRED, null, false);
      }

      ///   
      ///	 <summary> * Set attribute Range as a String
      ///	 *  </summary>
      ///	 * <param name="String"> value - the value to set </param>
      ///	 
      public virtual void setRange(string @value)
      {
         setAttribute(AttributeName.RANGE, @value, null);
      }

      ///   
      ///	 <summary> * Get attribute Range value
      ///	 *  </summary>
      ///	 * <returns> String - the value of attribute Range </returns>
      ///	 
      public virtual string getRange()
      {
         return getAttribute(AttributeName.RANGE, null, JDFConstants.EMPTYSTRING);
      }

      public override bool init()
      {
         bool b = base.init();
         setDataType(EnumDataType.OptionSpan);
         return b;
      }
   }
}
