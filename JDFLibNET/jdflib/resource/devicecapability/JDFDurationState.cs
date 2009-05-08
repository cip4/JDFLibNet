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
 * JDFDurationState.cs
 */


namespace org.cip4.jdflib.resource.devicecapability
{
   using System;


   using EnumListType = org.cip4.jdflib.auto.JDFAutoBasicPreflightTest.EnumListType;
   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDurationRangeList = org.cip4.jdflib.datatypes.JDFDurationRangeList;
   using EnumTerm = org.cip4.jdflib.resource.devicecapability.JDFTerm.EnumTerm;
   using JDFDuration = org.cip4.jdflib.util.JDFDuration;
   using EnumFitsValue = org.cip4.jdflib.datatypes.EnumFitsValue;


   public class JDFDurationState : JDFAbstractState
   {
      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[4];
      static JDFDurationState()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ALLOWEDVALUELIST, 0x33333311, AttributeInfo.EnumAttributeType.DurationRangeList, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.CURRENTVALUE, 0x33333311, AttributeInfo.EnumAttributeType.duration, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.DEFAULTVALUE, 0x33333311, AttributeInfo.EnumAttributeType.duration, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.PRESENTVALUELIST, 0x33333311, AttributeInfo.EnumAttributeType.DurationRangeList, null, null);
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
      ///	 <summary> * constructor for JDFDurationState
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFDurationState(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * constructor for JDFDurationState
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFDurationState(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * constructor for JDFDurationState
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFDurationState(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
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
         return "JDFDurationState[ --> " + base.ToString() + " ]";
      }

      //   
      //	 * // Attribute getter/ Setter
      //	 

      public virtual void setCurrentValue(JDFDuration @value)
      {
         setAttribute(AttributeName.CURRENTVALUE, @value.getDurationISO(), null);
      }

      public virtual JDFDuration getCurrentValue()
      {
         string str = getAttribute(AttributeName.CURRENTVALUE, null, null);
         if (str == null)
            return null;

         try
         {
            return new JDFDuration(str);
         }
         catch (FormatException)
         {
            return null;
         }
      }

      public virtual void setDefaultValue(JDFDuration @value)
      {
         setAttribute(AttributeName.DEFAULTVALUE, @value.getDurationISO(), null);
      }

      public virtual JDFDuration getDefaultValue()
      {
         string str = getAttribute(AttributeName.DEFAULTVALUE, null, null);
         if (str == null)
            return null;

         try
         {
            return new JDFDuration(str);
         }
         catch (FormatException)
         {
            return null;
         }
      }

      public virtual void setAllowedValueList(JDFDurationRangeList @value)
      {
         setAttribute(AttributeName.ALLOWEDVALUELIST, @value.ToString());
      }

      public virtual JDFDurationRangeList getAllowedValueList()
      {
         try
         {
            string attribute = getAttribute(AttributeName.ALLOWEDVALUELIST, null, null);
            if (attribute != null)
               return new JDFDurationRangeList(attribute);
         }
         catch (FormatException)
         {
            // nop
         }
         return null;
      }

      public virtual void setPresentValueList(JDFDurationRangeList @value)
      {
         setAttribute(AttributeName.PRESENTVALUELIST, @value.ToString());
      }

      public virtual JDFDurationRangeList getPresentValueList()
      {
         try
         {
            string attribute = getAttribute(AttributeName.PRESENTVALUELIST, null, null);
            if (attribute != null)
               return new JDFDurationRangeList(attribute);
         }
         catch (FormatException)
         {
            return null; // malformed so don't default
         }
         return getAllowedValueList();
      }

      //   
      //	 * // Element getter / Setter
      //	 

      //   
      //	 * // FitsValue Methods
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

         JDFDuration duration;
         try
         {
            duration = new JDFDuration(@value);
         }
         catch (FormatException)
         {
            return; // nop for bad values
         }
         if (testlists == null || EnumFitsValue.Allowed.Equals(testlists))
         {
            JDFDurationRangeList list = getAllowedValueList();
            if (list == null)
               list = new JDFDurationRangeList();
            list.Append(duration);
            setAllowedValueList(list);
         }
         if (testlists == null || EnumFitsValue.Present.Equals(testlists))
         {
            JDFDurationRangeList list = getPresentValueList();
            if (list == null || !hasAttribute(AttributeName.PRESENTVALUELIST))
               list = new JDFDurationRangeList();
            list.Append(duration);
            setPresentValueList(list);
         }
      }

      ///   
      ///	 <summary> * fitsValue - tests, if the defined value matches Allowed test lists or
      ///	 * Present test lists, specified for this State
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <param name="testlists">
      ///	 *            test lists, that the value has to match. In this State the
      ///	 *            test list is ValueList.<br>
      ///	 *            Choose one of two values: FitsValue_Allowed or
      ///	 *            FitsValue_Present. (Defaults to Allowed)
      ///	 *  </param>
      ///	 * <returns> boolean - true, if the value matches test list or if
      ///	 *         AllowedValueList is not specified </returns>
      ///	 
      public sealed override bool fitsValue(string @value, EnumFitsValue testlists)
      {
         if (fitsListType(@value))
         {
            JDFDurationRangeList rangelist = null;
            try
            {
               rangelist = new JDFDurationRangeList(@value);
            }
            catch (FormatException)
            {
               return false;
            }
            return (fitsValueList(rangelist, testlists));

         }
         return false; // the value doesn't fit ListType attribute of this State
      }

      ///   
      ///	 <summary> * fitsValueList - tests, if the defined 'rangelist' matches the
      ///	 * AllowedValueList or in the PresentValueList, specified for this State
      ///	 *  </summary>
      ///	 * <param name="rangelist">
      ///	 *            range list to test </param>
      ///	 * <param name="valuelist">
      ///	 *            switches between AllowedValueList and PresentValueList.
      ///	 *  </param>
      ///	 * <returns> boolean - true, if 'rangelist' matches the valuelist or if
      ///	 *         AllowedValueList is not specified </returns>
      ///	 
      private bool fitsValueList(JDFDurationRangeList rangelist, EnumFitsValue valuelist)
      {
         JDFDurationRangeList list;
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
            return fitsCompleteList(rangelist, list);
         }
         else if (listType.Equals(EnumListType.CompleteOrderedList))
         {
            return fitsCompleteOrderedList(rangelist, list);
         }
         else if (listType.Equals(EnumListType.ContainedList))
         {
            return fitsContainedList(rangelist, list);
         }

         return (list.isPartOfRange(rangelist));

      }

      ///   
      ///	 <summary> * fitsCompleteList - tests for the case, when ListType=CompleteList, if the
      ///	 * defined 'value' matches AllowedValueList or PresentValueList, specified
      ///	 * for this State
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <param name="list">
      ///	 *            testlists are either AllowedValueList or PresentValueList.
      ///	 *  </param>
      ///	 * <returns> boolean - true, if 'value' matches testlist </returns>
      ///	 
      private bool fitsCompleteList(JDFDurationRangeList @value, JDFDurationRangeList list)
      {
         int v_size = @value.Count;
         int l_size = list.Count;

         if (v_size != l_size)
            return false;

         if (!@value.isUnique())
            return false;

         JDFDurationRangeList valueList = new JDFDurationRangeList(@value);

         bool bFound;
         for (int i = l_size - 1; i >= 0; i--)
         {
            bFound = false;
            for (int j = valueList.Count - 1; j >= 0; j--)
            {
               if (list[i].Equals(valueList[j]))
               {
                  valueList.erase(j);
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
      ///	 <summary> * fitsCompleteOrderedList - tests for the case, when
      ///	 * ListType=CompleteOrderedList, if the defined 'value' matches
      ///	 * AllowedValueList or PresentValueList, specified for this State
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <param name="list">
      ///	 *            testlists are either AllowedValueList or PresentValueList.
      ///	 *  </param>
      ///	 * <returns> boolean - true, if 'value' matches testlist </returns>
      ///	 
      private bool fitsCompleteOrderedList(JDFDurationRangeList @value, JDFDurationRangeList list)
      {
         int v_size = @value.Count;
         int l_size = list.Count;

         if (v_size != l_size)
            return false;

         if (!@value.isUnique())
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
      ///	 <summary> * fitsContainedList - tests for the case, when ListType=ContainedList, if
      ///	 * the defined 'value' matches AllowedValueList or PresentValueList,
      ///	 * specified for this State
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <param name="list">
      ///	 *            testlists are either AllowedValueList or PresentValueList.
      ///	 *  </param>
      ///	 * <returns> boolean - true, if 'value' matches testlist </returns>
      ///	 
      private bool fitsContainedList(JDFDurationRangeList @value, JDFDurationRangeList list)
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

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.ifaces.ICapabilityElement#getEvaluationType()
      //	 
      public override EnumTerm getEvaluationType()
      {
         return EnumTerm.DurationEvaluation;
      }
   }
}
