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
 * JDFDateTimeState.cs
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
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFDateTimeRange = org.cip4.jdflib.datatypes.JDFDateTimeRange;
   using JDFDateTimeRangeList = org.cip4.jdflib.datatypes.JDFDateTimeRangeList;
   using JDFDurationRangeList = org.cip4.jdflib.datatypes.JDFDurationRangeList;
   using EnumTerm = org.cip4.jdflib.resource.devicecapability.JDFTerm.EnumTerm;
   using JDFDate = org.cip4.jdflib.util.JDFDate;
   using JDFDuration = org.cip4.jdflib.util.JDFDuration;
   using EnumFitsValue = org.cip4.jdflib.datatypes.EnumFitsValue;

   public class JDFDateTimeState : JDFAbstractState
   {
      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[6];
      static JDFDateTimeState()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ALLOWEDVALUEDURATIONLIST, 0x33333311, AttributeInfo.EnumAttributeType.DurationRangeList, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.ALLOWEDVALUELIST, 0x33333311, AttributeInfo.EnumAttributeType.DateTimeRangeList, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.CURRENTVALUE, 0x33333311, AttributeInfo.EnumAttributeType.dateTime, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.DEFAULTVALUE, 0x33333311, AttributeInfo.EnumAttributeType.dateTime, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.PRESENTVALUEDURATIONLIST, 0x33333311, AttributeInfo.EnumAttributeType.DurationRangeList, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.PRESENTVALUELIST, 0x33333311, AttributeInfo.EnumAttributeType.DateTimeRangeList, null, null);
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
      ///	 <summary> * Constructor for JDFDateTimeState
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFDateTimeState(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFDateTimeState
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFDateTimeState(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFDateTimeState
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFDateTimeState(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      ///   
      ///	 <summary> * toString
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public override string ToString()
      {
         return "JDFDateTimeState[  --> " + base.ToString() + " ]";
      }

      //   
      //	 * // Attribute getter/ setter
      //	 

      ///   
      ///	 <summary> * set attribute <code>CurrentValue</code>
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            the value to set the attribute to </param>
      ///	 
      public virtual void setCurrentValue(JDFDate @value)
      {
         setAttribute(AttributeName.CURRENTVALUE, @value.DateTimeISO, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * get attribute <code>CurrentValue</code>
      ///	 *  </summary>
      ///	 * <returns> the value of the attribute </returns>
      ///	 
      public virtual JDFDate getCurrentValue()
      {
         JDFDate currentValue = null;
         string str = getAttribute(AttributeName.CURRENTVALUE, null, JDFConstants.EMPTYSTRING);
         if (!JDFConstants.EMPTYSTRING.Equals(str))
         {
            try
            {
               currentValue = new JDFDate(str);
            }
            catch (FormatException)
            {
               throw new JDFException("not a valid date string. Malformed JDF");
            }
         }
         return currentValue;
      }

      ///   
      ///	 <summary> * set attribute <code>DefaultValue</code>
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            the value to set the attribute to </param>
      ///	 
      public virtual void setDefaultValue(JDFDate @value)
      {
         setAttribute(AttributeName.DEFAULTVALUE, @value.DateTimeISO, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * get attribute <code>DefaultValue</code>
      ///	 *  </summary>
      ///	 * <returns> the value of the attribute </returns>
      ///	 
      public virtual JDFDate getDefaultValue()
      {
         JDFDate defaultValue = null;
         string str = getAttribute(AttributeName.DEFAULTVALUE, null, JDFConstants.EMPTYSTRING);
         if (!JDFConstants.EMPTYSTRING.Equals(str))
         {
            try
            {
               defaultValue = new JDFDate(str);
            }
            catch (FormatException)
            {
               throw new JDFException("not a valid date string. Malformed JDF");
            }
         }
         return defaultValue;
      }

      ///   
      ///	 <summary> * set attribute <code>AllowedValueList</code>
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            the value to set the attribute to </param>
      ///	 
      public virtual void setAllowedValueList(JDFDateTimeRangeList @value)
      {
         setAttribute(AttributeName.ALLOWEDVALUELIST, @value.ToString());
      }

      ///   
      ///	 <summary> * get attribute <code>AllowedValueList</code>
      ///	 *  </summary>
      ///	 * <returns> the value of the attribute </returns>
      ///	 
      public virtual JDFDateTimeRangeList getAllowedValueList()
      {
         try
         {
            string attribute = getAttribute(AttributeName.ALLOWEDVALUELIST, null, null);
            if (attribute != null)
               return new JDFDateTimeRangeList(attribute);
         }
         catch (FormatException)
         {
            // nop
         }
         return null;
      }

      ///   
      ///	 <summary> * set attribute <code>PresentValueList</code>
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            the value to set the attribute to </param>
      ///	 
      public virtual void setPresentValueList(JDFDateTimeRangeList @value)
      {
         setAttribute(AttributeName.PRESENTVALUELIST, @value.ToString());
      }

      ///   
      ///	 <summary> * get attribute <code>PresentValueList</code>
      ///	 *  </summary>
      ///	 * <returns> the value of the attribute </returns>
      ///	 
      public virtual JDFDateTimeRangeList getPresentValueList()
      {
         if (hasAttribute(AttributeName.PRESENTVALUELIST))
         {
            JDFDateTimeRangeList r = null;
            try
            {
               r = new JDFDateTimeRangeList(getAttribute(AttributeName.PRESENTVALUELIST));
            }
            catch (FormatException)
            {
               return null;
            }
            return r;
         }
         return getAllowedValueList();
      }

      ///   
      ///	 <summary> * set attribute <code>AllowedValueDurationList</code>
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            the value of the attribute </param>
      ///	 
      public virtual void setAllowedValueDurationList(JDFDurationRangeList @value)
      {
         setAttribute(AttributeName.ALLOWEDVALUEDURATIONLIST, @value.ToString());
      }

      ///   
      ///	 <summary> * get attribute <code>AllowedValueDurationList</code>
      ///	 *  </summary>
      ///	 * <returns> the value of the attribute </returns>
      ///	 
      public virtual JDFDurationRangeList getAllowedValueDurationList()
      {
         JDFDurationRangeList r = null;

         string allowedValueDurList = getAttribute(AttributeName.ALLOWEDVALUEDURATIONLIST, null, null);
         if (allowedValueDurList != null)
         {
            try
            {
               r = new JDFDurationRangeList(allowedValueDurList);
            }
            catch (FormatException)
            {
               return null;
            }
         }
         return r;
      }

      ///   
      ///	 <summary> * set attribute <code>PresentValueDurationList</code>
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            the value to set the attribute to </param>
      ///	 
      public virtual void setPresentValueDurationList(JDFDurationRangeList @value)
      {
         setAttribute(AttributeName.PRESENTVALUEDURATIONLIST, @value.ToString());
      }

      ///   
      ///	 <summary> * get attribute <code>PresentValueDurationList</code>
      ///	 *  </summary>
      ///	 * <returns> the value of the attribute </returns>
      ///	 
      public virtual JDFDurationRangeList getPresentValueDurationList()
      {
         if (hasAttribute(AttributeName.PRESENTVALUEDURATIONLIST))
         {
            JDFDurationRangeList r = null;
            try
            {
               r = new JDFDurationRangeList(getAttribute(AttributeName.PRESENTVALUEDURATIONLIST));
            }
            catch (FormatException)
            {
               return null;
            }
            return r;
         }
         return getAllowedValueDurationList();
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

         JDFDate date;
         try
         {
            date = new JDFDate(@value);
         }
         catch (FormatException)
         {
            return; // nop for bad values
         }
         if (testlists == null || EnumFitsValue.Allowed.Equals(testlists))
         {
            JDFDateTimeRangeList list = getAllowedValueList();
            if (list == null)
               list = new JDFDateTimeRangeList();
            list.Append(date);
            setAllowedValueList(list);

         }
         if (testlists == null || EnumFitsValue.Present.Equals(testlists))
         {
            JDFDateTimeRangeList list = getPresentValueList();
            if (list == null || !hasAttribute(AttributeName.PRESENTVALUELIST))
               list = new JDFDateTimeRangeList();
            list.Append(date);
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
      ///	 *            the test lists the value has to match. In this State the test
      ///	 *            lists are ValueList and ValueDurationList.<br>
      ///	 *            Choose one of two values: FitsValue_Allowed or
      ///	 *            FitsValue_Present. (Defaults to Allowed)
      ///	 *  </param>
      ///	 * <returns> boolean - true, if the value matches test list or if
      ///	 *         AllowedValueList is not specified </returns>
      ///	 
      public override bool fitsValue(string @value, EnumFitsValue testlists)
      {
         if (fitsListType(@value))
         {
            JDFDateTimeRangeList rangelist = null;
            try
            {
               rangelist = new JDFDateTimeRangeList(@value);
            }
            catch (FormatException)
            {
               return false;
            }

            return (fitsValueList(rangelist, testlists) && fitsValueDurationList(rangelist, testlists));
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
      ///	 *            switches between AllowedValueList and PresentValueList
      ///	 *  </param>
      ///	 * <returns> boolean - true, if <code>rangelist</code> matches the valuelist
      ///	 *         or if AllowedValueList is not specified </returns>
      ///	 
      private bool fitsValueList(JDFDateTimeRangeList rangelist, EnumFitsValue valuelist)
      {
         JDFDateTimeRangeList list;
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
      ///	 <summary> * fitsValueDurationList - tests, if the duration of the defined
      ///	 * <code>rangelist</code> value matchest the ValueDurationList, specified
      ///	 * for this State
      ///	 *  </summary>
      ///	 * <param name="rangelist">
      ///	 *            range list to test </param>
      ///	 * <param name="valuelist">
      ///	 *            switches between AllowedValueList and PresentValueList </param>
      ///	 * <returns> boolean - true, if the duration of the defined rangelist is in
      ///	 *         <code>valueList</code> or if ValueDurationList is not specified </returns>
      ///	 
      private bool fitsValueDurationList(JDFDateTimeRangeList rangelist, EnumFitsValue valuelist)
      {
         JDFDurationRangeList list;

         if (valuelist.Equals(EnumFitsValue.Allowed))
         {
            list = getAllowedValueDurationList();
         }
         else
         {
            list = getPresentValueDurationList();
         }
         if (list == null)
            return true;

         int siz = rangelist.Count;
         for (int i = 0; i < siz; i++)
         {
            JDFDateTimeRange range = (JDFDateTimeRange)rangelist[i];

            int duration = (int)((range.Right.TimeInMillis - range.Left.TimeInMillis) / 1000);
            JDFDuration d = new JDFDuration();
            d.setDuration(duration);
            if (!list.inRange(d))
               return false;
         }
         return true;
      }

      ///   
      ///	 <summary> * fitsCompleteList - tests for the case, when ListType=CompleteList, if
      ///	 * <code>value</code> matches AllowedValueList or PresentValueList,
      ///	 * specified for this State
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <param name="list">
      ///	 *            testlists are either AllowedValueList or PresentValueList
      ///	 *  </param>
      ///	 * <returns> boolean - true, if <code>value</code> matches testlist </returns>
      ///	 
      private bool fitsCompleteList(JDFDateTimeRangeList @value, JDFDateTimeRangeList list)
      {
         int v_size = @value.Count;
         int l_size = list.Count;

         if (v_size != l_size)
            return false;

         if (!@value.isUnique())
            return false;

         JDFDateTimeRangeList valueList = new JDFDateTimeRangeList(@value);

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
      ///	 *            testlists are either AllowedValueList or PresentValueList
      ///	 *  </param>
      ///	 * <returns> boolean - true, if <code>value</code> matches testlist </returns>
      ///	 
      private bool fitsCompleteOrderedList(JDFDateTimeRangeList @value, JDFDateTimeRangeList list)
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
      ///	 * the defined <code>value</code> matches AllowedValueList or
      ///	 * PresentValueList, specified for this State
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            to test </param>
      ///	 * <param name="testlists">
      ///	 *            are either AllowedValueList or PresentValueList
      ///	 *  </param>
      ///	 * <returns> boolean - true, if <code>value</code> matches testlist </returns>
      ///	 
      private bool fitsContainedList(JDFDateTimeRangeList @value, JDFDateTimeRangeList list)
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
         return EnumTerm.DateTimeEvaluation;
      }
   }
}
