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
 * JDFNameEvaluation.cs
 */


namespace org.cip4.jdflib.resource.devicecapability
{


   using EnumListType = org.cip4.jdflib.auto.JDFAutoBasicPreflightTest.EnumListType;
   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using VString = org.cip4.jdflib.core.VString;
   using StringUtil = org.cip4.jdflib.util.StringUtil;

   public class JDFNameEvaluation : JDFEvaluation
   {
      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[2];
      static JDFNameEvaluation()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.REGEXP, 0x33333333, AttributeInfo.EnumAttributeType.RegExp, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.VALUELIST, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }

      ///   
      ///	 <summary> * constructor for JDFNameEvaluation
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFNameEvaluation(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * constructor for JDFNameEvaluation
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFNameEvaluation(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * constructor for JDFNameEvaluation
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFNameEvaluation(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
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
         return "JDFNameEvaluation[ --> " + base.ToString() + " ]";
      }

      //   
      //	 * // Attribute getter/ setter
      //	 

      ///   
      ///	 <summary> * get attribute <code>ValueList</code>
      ///	 *  </summary>
      ///	 * <returns> VString - the attribute </returns>
      ///	 
      public virtual VString getValueList()
      {
         return new VString(StringUtil.tokenize(AttributeName.VALUELIST, JDFConstants.BLANK, false));
      }

      ///   
      ///	 <summary> * set attribute <code>ValueList</code>
      ///	 *  </summary>
      ///	 * <param name="vs">
      ///	 *            the value to set the attribute to </param>
      ///	 
      public virtual void setValueList(VString vs)
      {
         setAttribute(AttributeName.VALUELIST, StringUtil.setvString(vs, " ", null, null), null);
      }

      ///   
      ///	 <summary> * set attribute <code>RegExp</code>
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            the value to set the attribute to </param>
      ///	 
      public virtual void setRegExp(string @value)
      {
         setAttribute(AttributeName.REGEXP, @value);
      }

      ///   
      ///	 <summary> * get attribute <code>RegExp</code>
      ///	 *  </summary>
      ///	 * <returns> String - the value of the attribute </returns>
      ///	 
      public virtual string getRegExp()
      {
         return getAttribute(AttributeName.REGEXP, null, JDFConstants.EMPTYSTRING);
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
      public override bool fitsValue(string @value)
      {
         if (fitsListType(@value))
            return (fitsValueList(@value) && fitsRegExp(@value));
         return false;
      }

      ///   
      ///	 <summary> * fitsValueList - checks whether <code>value</code> matches the
      ///	 * AllowedValueList or the PresentValueList specified for this Evaluation
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            nmtokens to test </param>
      ///	 * <returns> boolean - true, if <code>value</code> matches
      ///	 *         <code>valuelist</code> or if AllowedValueList is not specified </returns>
      ///	 
      private bool fitsValueList(string @value)
      {
         if (!hasAttribute(AttributeName.VALUELIST))
            return true; // ValueList is not specified

         VString vs = new VString(@value, null);

         VString list = getValueList();

         EnumListType listType = getListType();

         if (listType.Equals(EnumListType.CompleteList))
         {
            return fitsCompleteList(vs, list);
         }
         else if (listType.Equals(EnumListType.CompleteOrderedList))
         {
            return fitsCompleteOrderedList(vs, list);
         }
         else if (listType.Equals(EnumListType.ContainedList))
         {
            return fitsContainedList(vs, list);
         }

         int v_size = vs.Count;
         int l_size = list.Count;

         for (int i = 0; i < v_size; i++) // test every token, that 'value'
         // consists of
         {
            bool bFound = false;
            for (int j = 0; j < l_size; j++)
            {
               string str_i = vs[i];
               string str_j = list[j];
               if (str_i.CompareTo(str_j) == 0)
               {
                  bFound = true;
                  break;
               }
            }
            if (!bFound)
               return false; // no such value in the 'list'
         }
         return true;
      }

      ///   
      ///	 <summary> * fitsRegExp - checks whether <code>str</code> matches the RegExp specified
      ///	 * for this Evaluation
      ///	 *  </summary>
      ///	 * <param name="str">
      ///	 *            string to test </param>
      ///	 * <returns> boolean - true, if <code>str</code> matches the RegExp or if no
      ///	 *         RegExp is specified </returns>
      ///	 
      private bool fitsRegExp(string str)
      {
         if (!hasAttribute(AttributeName.REGEXP))
            return true; // if RegExp is not specified return true
         return StringUtil.matches(str, getRegExp());
      }

      ///   
      ///	 <summary> * fitsListType - checks whether <code>value</code> matches the value of the
      ///	 * ListType attribute specified for this Evaluation
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <returns> boolean - true, if <code>value</code> matches the specified value
      ///	 *         of ListType </returns>
      ///	 
      private bool fitsListType(string @value)
      {
         if (!StringUtil.isNMTOKENS(@value, false))
            return false;

         EnumListType listType = getListType();
         if (listType == null)
            return true;

         if (listType.Equals(EnumListType.SingleValue) || listType.Equals(EnumListType.getEnum(0)))
         { // default ListType = SingleValue
            return StringUtil.isNMTOKEN(@value);
         }
         // not -
         // tested in
         // fitsValueList
         // in
         // fitsValueList
         else if (listType.Equals(EnumListType.List) || listType.Equals(EnumListType.Span) || listType.Equals(EnumListType.CompleteList) || listType.Equals(EnumListType.CompleteOrderedList) || listType.Equals(EnumListType.ContainedList)) // tested in
         // fitsValueList
         // )
         {
            return true;
         }
         else if (listType.Equals(EnumListType.UniqueList))
         {
            VString v = new VString(@value, null);
            return (isUnique(v));
         }
         else
         {
            throw new JDFException("JDFNameEvaluation.fitsListType illegal ListType attribute");
         }
      }

      ///   
      ///	 <summary> * fitsCompleteList - tests whether <code>value</code> matches the given
      ///	 * ValueList (ListType=CompleteList)
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <param name="list">
      ///	 *            ValueList </param>
      ///	 * <returns> boolean - true, if <code>value</code> matches the ValueList </returns>
      ///	 
      private bool fitsCompleteList(VString @value, VString list)
      {
         int v_size = @value.Count;
         int l_size = list.Count;

         if (v_size != l_size)
            return false;

         if (!isUnique(@value))
            return false;

         VString valueList = new VString(@value);

         bool bFound;
         for (int i = l_size - 1; i >= 0; i--)
         {
            bFound = false;
            for (int j = valueList.Count - 1; j >= 0; j--)
            {
               if (list[i].Equals(valueList[j]))
               {
                  valueList.RemoveAt(j);
                  bFound = true;
                  break;
               }
            }
            if (!bFound)
            {
               return false;
            }
         }
         return true;
      }

      ///   
      ///	 <summary> * fitsCompleteOrderedList - tests whether <code>value</code> matches the
      ///	 * given ValueList (ListType=CompleteOrderedList)
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <param name="list">
      ///	 *            ValueList </param>
      ///	 * <returns> boolean - true, if <code>value</code> matches the ValueList </returns>
      ///	 
      private bool fitsCompleteOrderedList(VString @value, VString list)
      {
         int v_size = @value.Count;
         int l_size = list.Count;

         if (v_size != l_size)
            return false;

         if (!isUnique(@value))
            return false;

         for (int i = 0; i < l_size; i++)
         {
            if (!list[i].Equals(@value[i]))
            {
               return false;
            }
         }
         return true;
      }

      ///   
      ///	 <summary> * fitsContainedList - tests whether <code>value</code> matches the given
      ///	 * ValueList (ListType=ContainedList)
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <param name="list">
      ///	 *            ValueList </param>
      ///	 * <returns> boolean - true, if <code>value</code> matches the ValueList </returns>
      ///	 
      private bool fitsContainedList(VString @value, VString list)
      {
         int v_size = @value.Count;
         int l_size = list.Count;

         for (int i = 0; i < v_size; i++)
         {
            for (int j = 0; j < l_size; j++)
            {
               if (@value[i].Equals(list[j]))
               {
                  return true;
               }
            }
         }
         return false;
      }

      ///   
      ///	 <summary> * isUnique - tests whether <code>value</code> string has unique tokens only
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <returns> boolean - true, if <code>value</code> has unique tokens only </returns>
      ///	 
      private bool isUnique(VString v)
      {
         int size = v.Count;
         for (int i = 0; i < size; i++)
         {
            for (int j = 0; j < size; j++)
            {
               if (j != i)
               {
                  string si = v[i];
                  string sj = v[j];
                  if (si.CompareTo(sj) == 0)
                     return false;
               }
            }
         }
         return true;
      }
   }
}
