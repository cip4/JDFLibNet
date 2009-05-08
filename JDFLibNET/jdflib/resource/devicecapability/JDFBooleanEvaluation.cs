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
 * @author Elena Skobchenko
 *
 * JDFBooleanEvaluation.cs
 */
 

namespace org.cip4.jdflib.resource.devicecapability
{
   using System;
   using System.Collections;
   using System.Collections.Generic;


  
   using EnumListType = org.cip4.jdflib.auto.JDFAutoBasicPreflightTest.EnumListType;
   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using VString = org.cip4.jdflib.core.VString;
   using StringUtil = org.cip4.jdflib.util.StringUtil;

   public class JDFBooleanEvaluation : JDFEvaluation
   {
      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[1];
      static JDFBooleanEvaluation()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.VALUELIST, 0x33333333, AttributeInfo.EnumAttributeType.enumerations, EnumBoolean.getEnum(0), null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }

///   
///	 <summary> * Constructor for JDFBooleanEvaluation
///	 *  </summary>
///	 * <param name="myOwnerDocument"> </param>
///	 * <param name="qualifiedName"> </param>
///	 
      public JDFBooleanEvaluation(CoreDocumentImpl myOwnerDocument, string qualifiedName) : base(myOwnerDocument, qualifiedName)
      {
      }

///   
///	 <summary> * Constructor for JDFBooleanEvaluation
///	 *  </summary>
///	 * <param name="myOwnerDocument"> </param>
///	 * <param name="myNamespaceURI"> </param>
///	 * <param name="qualifiedName"> </param>
///	 
      public JDFBooleanEvaluation(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName) : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

///   
///	 <summary> * Constructor for JDFBooleanEvaluation
///	 *  </summary>
///	 * <param name="myOwnerDocument"> </param>
///	 * <param name="myNamespaceURI"> </param>
///	 * <param name="qualifiedName"> </param>
///	 * <param name="myLocalName"> </param>
///	 
      public JDFBooleanEvaluation(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName) : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
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
         return "JDFBooleanEvaluation[ --> " + base.ToString() + " ]";
      }

//   
//	 * // Attribute Getter / Setter
//	 
///   
///	 <summary> * getValueList
///	 *  </summary>
///	 * <returns> Vector of Boolean objects </returns>
///	 
      public virtual List<bool> getValueList()
      {
         string s = getAttribute(AttributeName.VALUELIST, null, null);
         VString v = new VString(StringUtil.tokenize(s, JDFConstants.BLANK, false));
         List<bool> vRet = new List<bool>();
         for (int i = 0; i < v.Count; i++)
         {
            string s2 = v[i];
            if (s2.ToLower().Equals(JDFConstants.TRUE.ToLower()))
            {
               vRet.Add(Convert.ToBoolean(true));
            }
            else if (s2.ToLower().Equals(JDFConstants.FALSE.ToLower()))
            {
               vRet.Add(Convert.ToBoolean(false));
            }

         }

         return vRet;
      }

///   
///	 <summary> * set ValueList
///	 *  </summary>
///	 * <param name="value">
///	 *            vector of Boolean values </param>
///	 
      public virtual void setValueList(ArrayList @value)
      {
         string s = JDFConstants.EMPTYSTRING;
         for (int i = 0; i < @value.Count; i++)
         {
            bool b = (bool) @value[i];
            if (b)
            {
               s += JDFConstants.TRUE;
            }
            else
            {
               s += JDFConstants.FALSE;
            }
            if (i > 0)
               s += JDFConstants.BLANK;
         }
         setAttribute(AttributeName.VALUELIST, s, null);

      }

///   
///	 <summary> * convenience method for single valued boolean lists
///	 *  </summary>
///	 * <param name="value">
///	 *            the single boolean to set ValueList to </param>
///	 
      public virtual void setValueList(bool @value)
      {
         setAttribute(AttributeName.VALUELIST, @value, null);
      }

//   
//	 * // FitsValue Methods
//	 

///   
///	 <summary> * fitsValue - tests, if the defined value matches ValueList, specified for
///	 * this Evaluation
///	 *  </summary>
///	 * <param name="valueStr">
///	 *            value to test </param>
///	 * <returns> boolean - true, if <code>value</code> matches testlists or if
///	 *         ValueList is not specified </returns>
///	 
      public override sealed bool fitsValue(string valueStr)
      {
         if (fitsListType(valueStr))
         {
            VString @value = new VString(valueStr, null);

            for (int i = 0; i < @value.Count; i++)
            {
               if (!fitsValueList(@value[i]))
                  return false;
            }
            return true; // if we are here a whole 'valueStr' fits
         }
         return false;
      }

///   
///	 <summary> * fitsValueList - tests, if the defined 'value' matches ValueList,
///	 *  </summary>
///	 * <param name="value">
///	 *            token to test </param>
///	 * <returns> boolean - true, if <code>value</code> matches valuelist or if
///	 *         ValueList is not specified </returns>
///	 
      private bool fitsValueList(string @value)
      {
         if (!hasAttribute(AttributeName.VALUELIST))
            return true;
         if (!StringUtil.isBoolean(@value))
            return false;

         List<bool> v = getValueList();

         for (int i = 0, size = v.Count; i < size; i++)
         {
            bool a = "true".Equals(@value);
            bool b = (v[i]); //.booleanValue();
            if (a == b)
               return true; // we have found it
         }
         return false;
      }

///   
///	 <summary> * fitsListType - tests, if the defined 'value' matches value of ListType
///	 * attribute, specified for this Evaluation
///	 *  </summary>
///	 * <param name="value">
///	 *            value to test </param>
///	 * <returns> boolean - true, if 'value' matches specified value of ListType </returns>
///	 
      private bool fitsListType(string @value)
      {
         VString vBool = new VString(@value, null);
         int size = vBool.Count;
         for (int i = 0; i < size; i++)
         {
            if (!StringUtil.isBoolean(vBool[i]))
               return false;
         }

         EnumListType listType = getListType();

         if (listType.Equals(EnumListType.SingleValue) || listType.Equals(EnumListType.getEnum(0)))
         { // default ListType = SingleValue
            return (size == 1);
         }
         else if (listType.Equals(EnumListType.List) || listType.Equals(EnumListType.Span))
         {
            return true;
         }
         else if (listType.Equals(EnumListType.UniqueList))
         {
            for (int i = 0; i < size; i++)
            {
               for (int j = 0; j < size; j++)
               {
                  if (j != i)
                  {
                     string bi = vBool[i];
                     string bj = vBool[j];
                     if (bi.CompareTo(bj) == 0)
                        return false;
                  }
               }
            }
            return true;
         }
         else
         {
            throw new JDFException("JDFBooleanEvaluation.fitsListType illegal ListType attribute");
         }

      }

   }
}
