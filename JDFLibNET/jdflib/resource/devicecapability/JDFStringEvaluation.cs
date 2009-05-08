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




/* Copyright (c) 2001 Heidelberger Druckmaschinen AG, All Rights Reserved.
 * 
 * @author Elena Skobchenko
 *
 * JDFStringEvaluation.cs
 */


namespace org.cip4.jdflib.resource.devicecapability
{
   using System;



   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using VElement = org.cip4.jdflib.core.VElement;
   using JDFIntegerRange = org.cip4.jdflib.datatypes.JDFIntegerRange;
   using JDFValue = org.cip4.jdflib.resource.JDFValue;
   using StringUtil = org.cip4.jdflib.util.StringUtil;


   public class JDFStringEvaluation : JDFEvaluation
   {
      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[2];
      static JDFStringEvaluation()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.LENGTH, 0x33333333, AttributeInfo.EnumAttributeType.IntegerRange, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.REGEXP, 0x33333333, AttributeInfo.EnumAttributeType.RegExp, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.VALUE, 0x33333333);
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
      ///	 <summary> * constructor for JDFStringEvaluation
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFStringEvaluation(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * constructor for JDFStringEvaluation
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFStringEvaluation(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>

      ///	 
      public JDFStringEvaluation(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
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
         return "JDFStringEvaluation[ --> " + base.ToString() + " ]";
      }

      //   
      //	 * // Attribute getter/ setter
      //	 

      public virtual void setLength(JDFIntegerRange @value)
      {
         setAttribute(AttributeName.LENGTH, @value.ToString());
      }

      public virtual JDFIntegerRange getLengthRange()
      {
         try
         {
            return new JDFIntegerRange(getAttribute(AttributeName.LENGTH));
         }
         catch (FormatException)
         {
            throw new JDFException("JDFStringEvaluation.getLengthRange: Attribute LENGTH is not capable to create JDFIntegerRange");
         }

      }

      public virtual void setRegExp(string @value)
      {
         setAttribute(AttributeName.REGEXP, @value);
      }

      public virtual string getRegExp()
      {
         return getAttribute(AttributeName.REGEXP);
      }

      //   
      //	 * // Element getter / setter
      //	 

      public virtual JDFValue getValue(int iSkip)
      {
         return (JDFValue)getElement(ElementName.VALUE, JDFConstants.EMPTYSTRING, iSkip);
      }

      ///   
      ///	 <summary> * append a <code>Value</code> element
      ///	 *  </summary>
      ///	 * <returns> JDFValue - the newly created element </returns>
      ///	 
      public virtual JDFValue appendValue()
      {
         return (JDFValue)appendElement(ElementName.VALUE, null);
      }

      ///   
      ///	 <summary> * append a <code>Value</code> element and set Value/@Value to value
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            the value string to set
      ///	 *  </param>
      ///	 * <returns> JDFValue - the newly created element </returns>
      ///	 
      public virtual JDFValue appendValueValue(string @value)
      {
         JDFValue v = (JDFValue)appendElement(ElementName.VALUE, null);
         v.setValue(@value);
         return v;
      }

      //   
      //	 * // Subelement attribute and element Getter / Setter
      //	 

      ///   
      ///	 <summary> * Sets the <code>Value</code> attribute of the iSkip'th subelement
      ///	 * <code>Value</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            the number of <code>Value</code> elements to skip </param>
      ///	 * <param name="value">
      ///	 *            value to set the attribute to </param>
      ///	 
      public virtual void setValueValue(int iSkip, string @value)
      {
         JDFValue e = (JDFValue)getCreateElement(ElementName.VALUE, null, iSkip);
         e.setValue(@value);
      }

      ///   
      ///	 <summary> * Gets the <code>Value</code> attribute of the iSkip'th subelement
      ///	 * <code>Value</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            the number of <code>Value</code> elements to skip </param>
      ///	 * <returns> String: the attribute value, <code>null</code> if no matching
      ///	 *         value element exists </returns>
      ///	 
      public string getValueValue(int iSkip)
      {
         JDFValue e = (JDFValue)getElement(ElementName.VALUE, null, iSkip);
         if (e == null)
            return null;
         return e.getValue();
      }

      //   
      //	 * // FitsValue Methods
      //	 

      ///   
      ///	 <summary> * fitsValue - checks whether <code>value</code> matches the testlists
      ///	 * specified for this Evaluation
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <returns> boolean - true, if <code>value</code> matches the testlists or if
      ///	 *         testlists are not specified </returns>
      ///	 
      public sealed override bool fitsValue(string @value)
      {
         return fitsLength(@value) && fitsRegExp(@value) && fitsValueElem(@value);
      }

      ///   
      ///	 <summary> * fitsLength - checks whether <code>str</code> matches the attribute
      ///	 * <code>Length</code> specified for this Evaluation
      ///	 *  </summary>
      ///	 * <param name="str">
      ///	 *            string to test </param>
      ///	 * <returns> boolean - true, if <code>str</code> matches <code>Length</code>
      ///	 *         or if <code>Length</code> is not specified </returns>
      ///	 
      private bool fitsLength(string str)
      {
         if (!hasAttribute(AttributeName.LENGTH))
         {
            int len = str.Length;
            return getLengthRange().inRange(len);
         }
         return true;
      }

      ///   
      ///	 <summary> * fitsRegExp - checks whether <code>str</code> matches the RegExp specified
      ///	 * for this Evaluation
      ///	 *  </summary>
      ///	 * <param name="str">
      ///	 *            string to test </param>
      ///	 * <returns> boolean - true, if <code>str</code> matches RegExp or if RegExp
      ///	 *         is not specified </returns>
      ///	 
      private bool fitsRegExp(string str)
      {
         if (!hasAttribute(AttributeName.REGEXP))
            return true;

         return StringUtil.matches(str, getRegExp());
      }

      ///   
      ///	 <summary> * fitsValueElem - checks whether <code>str</code> matches the subelement
      ///	 * <code>Value</code> specified for this Evaluation
      ///	 *  </summary>
      ///	 * <param name="str">
      ///	 *            string to test </param>
      ///	 * <returns> boolean - true, if <code>str</code> matches subelement
      ///	 *         <code>Value</code> </returns>
      ///	 
      private bool fitsValueElem(string str)
      {
         VElement v = getChildElementVector(ElementName.VALUE, null, null, true, 0, false);
         int siz = v.Count;
         if (siz == 0)
            return true; // Evaluation has no Value elements

         for (int i = 0; i < siz; i++)
         {
            string @value = getValueValue(i); // JDFValue elm =(JDFValue)
            // v[i];
            if (@value.CompareTo(str) == 0)
               return true; // we have found it

         }
         return false;
      }
   }
}
