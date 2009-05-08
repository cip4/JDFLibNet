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
 * JDFEnumerationState.cs
 */


namespace org.cip4.jdflib.resource.devicecapability
{


   using EnumListType = org.cip4.jdflib.auto.JDFAutoBasicPreflightTest.EnumListType;
   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using VString = org.cip4.jdflib.core.VString;
   using EnumTerm = org.cip4.jdflib.resource.devicecapability.JDFTerm.EnumTerm;
   using StringUtil = org.cip4.jdflib.util.StringUtil;
   using EnumFitsValue = org.cip4.jdflib.datatypes.EnumFitsValue;

   public class JDFEnumerationState : JDFAbstractState
   {
      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[6];
      static JDFEnumerationState()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ALLOWEDVALUELIST, 0x33333331, AttributeInfo.EnumAttributeType.enumerations, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.CURRENTVALUE, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.DEFAULTVALUE, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.PRESENTVALUELIST, 0x33333331, AttributeInfo.EnumAttributeType.enumerations, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.ALLOWEDREGEXP, 0x33331111, AttributeInfo.EnumAttributeType.RegExp, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.PRESENTREGEXP, 0x33331111, AttributeInfo.EnumAttributeType.RegExp, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.VALUELOC, 0x33333311);
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
      ///	 <summary> * constructor for JDFEnumerationState
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFEnumerationState(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * constructor for JDFEnumerationState
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFEnumerationState(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * constructor for JDFEnumerationState
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFEnumerationState(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
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
         return "JDFEnumerationState[ --> " + base.ToString() + " ]";
      }

      //   
      //	 * // Attribute getter / setter
      //	 

      public virtual void setCurrentValue(string @value)
      {
         setAttribute(AttributeName.CURRENTVALUE, @value);
      }

      public virtual string getCurrentValue()
      {
         return getAttribute(AttributeName.CURRENTVALUE, null, JDFConstants.EMPTYSTRING);
      }

      public virtual void setDefaultValue(string @value)
      {
         setAttribute(AttributeName.DEFAULTVALUE, @value);
      }

      public virtual string getDefaultValue()
      {
         return getAttribute(AttributeName.DEFAULTVALUE, null, JDFConstants.EMPTYSTRING);
      }

      public virtual VString getAllowedValueList()
      {
         string attribute = getAttribute(AttributeName.ALLOWEDVALUELIST, null, null);
         return attribute == null ? null : new VString(attribute, null);
      }

      public virtual void setAllowedValueList(VString vs)
      {
         setAttribute(AttributeName.ALLOWEDVALUELIST, StringUtil.setvString(vs, " ", null, null), null);
      }

      public virtual VString getPresentValueList()
      {
         if (hasAttribute(AttributeName.PRESENTVALUELIST))
         {
            return new VString(getAttribute(AttributeName.PRESENTVALUELIST, null, JDFConstants.EMPTYSTRING), null);
         }
         return getAllowedValueList();
      }

      public virtual void setPresentValueList(VString vs)
      {
         string s = JDFConstants.EMPTYSTRING;
         if (vs != null)
         {
            s = StringUtil.setvString(vs, " ", null, null);
         }
         setAttribute(AttributeName.PRESENTVALUELIST, s);
      }

      //   
      //	 * // Element getter / setter
      //	 

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see
      //	 * org.cip4.jdflib.resource.devicecapability.JDFAbstractState#addValue(java
      //	 * .lang.String, org.cip4.jdflib.datatypes.JDFBaseDataTypes.EnumFitsValue)
      //	 
      public override void addValue(string @value, EnumFitsValue testlists)
      {
         if (fitsValue(@value, testlists))
            return;

         if (testlists == null || EnumFitsValue.Allowed.Equals(testlists))
         {
            VString list = getAllowedValueList();
            if (list == null)
               list = new VString();
            list.appendUnique(@value);
            setAllowedValueList(list);
         }
         if (testlists == null || EnumFitsValue.Present.Equals(testlists))
         {
            VString list = getPresentValueList();
            if (list == null || !hasAttribute(AttributeName.PRESENTVALUELIST))
               list = new VString();
            list.appendUnique(@value);
            setPresentValueList(list);
         }
      }

      ///   
      ///	 <summary> * fitsValue - tests whether <code>value</code> matches the Allowed test
      ///	 * lists or Present test lists, specified for this State
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <param name="testlist">
      ///	 *            the test lists the value has to match. In this State there is
      ///	 *            only one test list - ValueList. <br>
      ///	 *            Choose one of two values: FitsValue_Allowed or
      ///	 *            FitsValue_Present (Defaults to Allowed).
      ///	 *  </param>
      ///	 * <returns> boolean - true, if 'value' matches testlists or if
      ///	 *         AllowedValueList is not specified </returns>
      ///	 
      public override bool fitsValue(string @value, EnumFitsValue testlists)
      {
         if (fitsListType(@value))
            return (fitsValueList(@value, testlists) && fitsRegExp(@value, testlists));
         return false;
      }

      ///   
      ///	 <summary> * fitsValueList - tests whether <code>value</code> matches the
      ///	 * AllowedValueList or the PresentValueList, specified for this State
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            nmtokens to test </param>
      ///	 * <param name="valuelist">
      ///	 *            switches between AllowedValueList and PresentValueList. </param>
      ///	 * <returns> boolean - true, if <code>value</code> matches valuelist or if
      ///	 *         AllowedValueList is not specified </returns>
      ///	 
      private bool fitsValueList(string @value, EnumFitsValue valuelist)
      {
         VString vs = new VString(@value, null);

         VString list;
         if (valuelist.Equals(EnumFitsValue.Allowed))
         {
            list = getAllowedValueList();
         }
         else
         {
            list = getPresentValueList();
         }
         if (list == null)
            return true;

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
               string ve = vs[i];
               string le = list[j];
               if (ve.CompareTo(le) == 0)
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
      ///	 <summary> * fitsCompleteList - tests whether <code>value</code> matches
      ///	 * AllowedValueList or PresentValueList (ListType=CompleteList)
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <param name="list">
      ///	 *            testlist, either AllowedValueList or PresentValueList.
      ///	 *  </param>
      ///	 * <returns> boolean - true, if <code>value</code> matches testlist </returns>
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
      ///	 <summary> * fitsCompleteOrderedList - tests whether <code>value</code> matches
      ///	 * AllowedValueList or PresentValueList (ListType=CompleteOrderedList)
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <param name="list">
      ///	 *            testlist, either AllowedValueList or PresentValueList.
      ///	 *  </param>
      ///	 * <returns> boolean - true, if 'value' matches testlist </returns>
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
      ///	 <summary> * fitsContainedList - tests whether <code>value</code> matches
      ///	 * AllowedValueList or PresentValueList (ListType=ContainedList)
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <param name="list">
      ///	 *            testlist, either AllowedValueList or PresentValueList.
      ///	 *  </param>
      ///	 * <returns> boolean - true, if 'value' matches testlist </returns>
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
      ///	 <summary> * isUnique - tests, if 'value' string has unique tokens only
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

      public override string getAllowedRegExp()
      {
         return getAttribute(AttributeName.ALLOWEDREGEXP, null, JDFConstants.EMPTYSTRING);
      }

      public override string getPresentRegExp()
      {
         if (hasAttribute(AttributeName.PRESENTREGEXP))
         {
            return getAttribute(AttributeName.PRESENTREGEXP);
         }
         return getAllowedRegExp();
      }

      public virtual void setAllowedRegExp(string @value)
      {
         setAttribute(AttributeName.ALLOWEDREGEXP, @value);
      }

      public virtual void setPresentRegExp(string @value)
      {
         setAttribute(AttributeName.PRESENTREGEXP, @value);
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.ifaces.ICapabilityElement#getEvaluationType()
      //	 
      public override EnumTerm getEvaluationType()
      {
         return EnumTerm.EnumerationEvaluation;
      }
   }
}
