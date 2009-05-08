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
 * JDFPDFPathEvaluation.cs
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

   public class JDFPDFPathEvaluation : JDFEvaluation
   {
      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[1];
      static JDFPDFPathEvaluation()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.LENGTH, 0x33333333, AttributeInfo.EnumAttributeType.IntegerRange, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.VALUE, 0x33333333);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }

      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[1];

      protected internal override ElementInfo getTheElementInfo()
      {
         return new ElementInfo(base.getTheElementInfo(), elemInfoTable);
      }

      ///   
      ///	 <summary> * constructor for JDFPDFPathEvaluation
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFPDFPathEvaluation(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * constructor for JDFPDFPathEvaluation
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFPDFPathEvaluation(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * constructor for JDFPDFPathEvaluation
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFPDFPathEvaluation(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
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
         return "JDFPDFPathEvaluation[ --> " + base.ToString() + " ]";
      }

      //   
      //	 * // Attribute getter / setter
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
            throw new JDFException("JDFPDFPathEvaluation.getLengthRange: Attribute LENGTH is not applicable to create JDFIntegerRange");
         }
      }

      //   
      //	 * // Element getter / setter
      //	 

      public virtual JDFValue getValue(int iSkip)
      {
         JDFValue e = (JDFValue)getElement(ElementName.VALUE, JDFConstants.EMPTYSTRING, iSkip);
         return e;
      }

      public virtual JDFValue appendValue()
      {
         return (JDFValue)appendElement(ElementName.VALUE, null);
      }

      //   
      //	 * // Subelement attribute and element Getter / Setter
      //	 

      ///   
      ///	 <summary> * Set the value of the iSkip'th element <code>Value</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            the number of <code>Value</code> elements to skip </param>
      ///	 * <param name="value">
      ///	 *            value to set the element to </param>
      ///	 
      public virtual void setValueValue(int iSkip, string @value)
      {
         JDFValue e = (JDFValue)getElement(ElementName.VALUE, null, iSkip);
         e.setValue(@value);
      }

      ///   
      ///	 <summary> * Get the value of the iSkip'th subelement <code>Value</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            the number of <code>Value</code> elements to skip </param>
      ///	 * <returns> String: the value </returns>
      ///	 
      public string getValueValue(int iSkip)
      {
         JDFValue e = (JDFValue)getElement(ElementName.VALUE, null, iSkip);
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
         // TBD __Lena__ Ihhalt! Test of 20 symbols

         return fitsLength(@value) && fitsValueElem(@value);
      }

      ///   
      ///	 <summary> * fitsLength - checks whether <code>pfdPath</code> matches the Length
      ///	 * specified for this Evaluation
      ///	 *  </summary>
      ///	 * <param name="pdfPath">
      ///	 *            PDFPath to test </param>
      ///	 * <returns> boolean - true, if <code>pdfPath</code> matches the Length or if
      ///	 *         Length is not specified </returns>
      ///	 
      private bool fitsLength(string pdfPath)
      {
         if (!hasAttribute(AttributeName.LENGTH))
         {
            int len = pdfPath.Length;
            return getLengthRange().inRange(len);
         }
         return true;
      }

      ///   
      ///	 <summary> * fitsValueElem - checks whether <code>pdfPath</code> matches the
      ///	 * subelement Value specified for this Evaluation
      ///	 *  </summary>
      ///	 * <param name="pdfPath">
      ///	 *            PDFPath to test
      ///	 *  </param>
      ///	 * <returns> boolean - true, if <code>pdfPath</code> matches subelement Value </returns>
      ///	 
      private bool fitsValueElem(string pdfPath)
      {
         VElement v = getChildElementVector(ElementName.VALUE, null, null, true, 0, false);
         int siz = v.Count;
         if (siz == 0)
            return true; // Evaluation has no Value elements

         for (int i = 0; i < siz; i++)
         {
            string @value = getValueValue(i); // JDFValue elm = (JDFValue)
            // v[i];
            if (@value.CompareTo(pdfPath) == 0)
               return true; // we have found it
         }
         return false;
      }
   }
}
