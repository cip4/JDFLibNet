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
 * JDFDateTimeEvaluation.cs
 */
 

namespace org.cip4.jdflib.resource.devicecapability
{
   using System;


  
   using EnumListType = org.cip4.jdflib.auto.JDFAutoBasicPreflightTest.EnumListType;
   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFDateTimeRange = org.cip4.jdflib.datatypes.JDFDateTimeRange;
   using JDFDateTimeRangeList = org.cip4.jdflib.datatypes.JDFDateTimeRangeList;
   using JDFDurationRangeList = org.cip4.jdflib.datatypes.JDFDurationRangeList;
   using JDFDate = org.cip4.jdflib.util.JDFDate;
   using JDFDuration = org.cip4.jdflib.util.JDFDuration;

   public class JDFDateTimeEvaluation : JDFEvaluation
   {
      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[2];
      static JDFDateTimeEvaluation()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.VALUEDURATIONLIST, 0x33333333, AttributeInfo.EnumAttributeType.DurationRangeList, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.VALUELIST, 0x33333333, AttributeInfo.EnumAttributeType.DateTimeRangeList, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }

///   
///	 <summary> * constructor for JDFDateTimeEvaluation
///	 *  </summary>
///	 * <param name="myOwnerDocument"> </param>
///	 * <param name="qualifiedName"> </param>
///	 
      public JDFDateTimeEvaluation(CoreDocumentImpl myOwnerDocument, string qualifiedName) : base(myOwnerDocument, qualifiedName)
      {
      }

///   
///	 <summary> * constructor for JDFDateTimeEvaluation
///	 *  </summary>
///	 * <param name="myOwnerDocument"> </param>
///	 * <param name="myNamespaceURI"> </param>
///	 * <param name="qualifiedName"> </param>
///	 
      public JDFDateTimeEvaluation(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName) : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

///   
///	 <summary> * constructor for JDFDateTimeEvaluation
///	 *  </summary>
///	 * <param name="myOwnerDocument"> </param>
///	 * <param name="myNamespaceURI"> </param>
///	 * <param name="qualifiedName"> </param>
///	 * <param name="myLocalName"> </param>
///	 
      public JDFDateTimeEvaluation(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName) : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
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
         return "JDFDateTimeEvaluation[  --> " + base.ToString() + " ]";
      }

//   
//	 * // Attribute getter/ Setter
//	 

///   
///	 <summary> * set attribute <code>ValueList</code>
///	 *  </summary>
///	 * <param name="value">
///	 *            the value to set the attribute to </param>
///	 
      public virtual void setValueList(JDFDateTimeRangeList @value)
      {
         setAttribute(AttributeName.VALUELIST, @value.ToString());
      }

///   
///	 <summary> * get attribute <code>ValueList</code>
///	 *  </summary>
///	 * <returns> the value of the attribute </returns>
///	 
      public virtual JDFDateTimeRangeList getValueList()
      {
         try
         {
            string attribute = getAttribute(AttributeName.VALUELIST, null, null);
            return attribute == null ? null : new JDFDateTimeRangeList(attribute);
         }
         catch (FormatException)
         {
            return null;
         }

      }

///   
///	 <summary> * set attribute <code>ValueDurationList</code>
///	 *  </summary>
///	 * <param name="value">
///	 *            the value to set the attribute to </param>
///	 
      public virtual void setValueDurationList(JDFDurationRangeList @value)
      {
         setAttribute(AttributeName.VALUEDURATIONLIST, @value.ToString());
      }

///   
///	 <summary> * get attribute <code>ValueDurationList</code>
///	 *  </summary>
///	 * <returns> the value of the attribute </returns>
///	 
      public virtual JDFDurationRangeList getValueDurationList()
      {
         try
         {
            return new JDFDurationRangeList(getAttribute(AttributeName.VALUEDURATIONLIST));
         }
         catch (FormatException)
         {
            return null;
         }

      }

//   
//	 * // FitsValue Methods
//	 

///   
///	 <summary> * fitsValue - tests, if the defined value matches ValueList, specified for
///	 * this Evaluation
///	 *  </summary>
///	 * <param name="value">
///	 *            value to test </param>
///	 * <returns> boolean - true, if the value matches ValueList or if ValueList is
///	 *         not specified </returns>
///	 
      public sealed override bool fitsValue(string @value)
      {
         if (!fitsListType(@value))
            return false;

         JDFDateTimeRangeList rangelist = null;
         try
         {
            rangelist = new JDFDateTimeRangeList(@value);
         }
         catch (FormatException)
         {
            return false;
         }
         return fitsValueList(rangelist) && fitsValueDurationList(rangelist);
      }

///   
///	 <summary> * fitsListType - tests, if the defined <code>value</code> matches the value
///	 * of the ListType attribute, specified for this Evaluation
///	 *  </summary>
///	 * <param name="value">
///	 *            value to test </param>
///	 * <returns> boolean - true, if <code>value</code> matches specified ListType </returns>
///	 
      private bool fitsListType(string @value)
      {
         EnumListType listType = getListType();

         JDFDateTimeRangeList rangelist;
         try
         {
            rangelist = new JDFDateTimeRangeList(@value);
         }
         catch (FormatException)
         {
            return false;
         }
         catch (JDFException)
         {
            return false;
         }

         if (listType.Equals(EnumListType.SingleValue) || listType.Equals(EnumListType.getEnum(0)))
         { // default ListType = SingleValue
            if (@value.IndexOf("P") != 0)
               return false;

            try
            {
               new JDFDate(@value);
            }
            catch (JDFException)
            {
               return false;
            }
            catch (FormatException)
            {
               return false;
            }

            return true;
         }
         else if (listType.Equals(EnumListType.RangeList) || listType.Equals(EnumListType.Span))
         {
            return true;
         }
         else if (listType.Equals(EnumListType.List))
         {
            return rangelist.isList();
         }
         else if (listType.Equals(EnumListType.OrderedList))
         {
            return (rangelist.isList() && rangelist.isOrdered());
         }
         else if (listType.Equals(EnumListType.UniqueList))
         {
            return (rangelist.isList() && rangelist.isUnique());
         }
         else if (listType.Equals(EnumListType.UniqueOrderedList))
         {
            return (rangelist.isList() && rangelist.isUniqueOrdered());
         }
         else if (listType.Equals(EnumListType.OrderedRangeList))
         {
            return rangelist.isOrdered();
         }
         else if (listType.Equals(EnumListType.UniqueRangeList))
         {
            return rangelist.isUnique();
         }
         else if (listType.Equals(EnumListType.UniqueOrderedRangeList))
         {
            return (rangelist.isUniqueOrdered());
         }
         else
         {
            throw new JDFException("JDFDateTimeEvaluation.fitsListType illegal ListType attribute");
         }
      }

///   
///	 <summary> * fitsValueList - tests, if the defined <code>rangelist</code> matches the
///	 * ValueList specified for this Evaluation
///	 *  </summary>
///	 * <param name="rangelist">
///	 *            range list to test
///	 *  </param>
///	 * <returns> boolean - true, if <code>rangelist</code> matches the valuelist
///	 *         or if ValueList is not specified </returns>
///	 
      private bool fitsValueList(JDFDateTimeRangeList rangelist)
      {
         if (!hasAttribute(AttributeName.VALUELIST))
            return true;
         return getValueList().isPartOfRange(rangelist);
      }

///   
///	 <summary> * fitsValueDurationList - tests, if the duration of the defined 'rangelist'
///	 * value matches ValueDurationList, specified for this State
///	 *  </summary>
///	 * <param name="rangelist">
///	 *            range list to test </param>
///	 * <returns> boolean - true, if the duration of the defined
///	 *         <code>rangelist</code> is in the ValueList or if
///	 *         ValueDurationList is not specified </returns>
///	 
      private bool fitsValueDurationList(JDFDateTimeRangeList rangelist)
      {
         if (hasAttribute(AttributeName.VALUEDURATIONLIST))
         {
            JDFDurationRangeList list = getValueDurationList();

            int siz = rangelist.Count;
            for (int i = 0; i < siz; i++)
            {
               JDFDateTimeRange range = (JDFDateTimeRange) rangelist[i];

               int duration = (int)((range.Right.TimeInMillis - range.Left.TimeInMillis) / 1000);
               JDFDuration d = new JDFDuration();
               d.setDuration(duration);
               if (!list.inRange(d))
                  return false;
            }
            return true;
         }
         return true;
      }
   }
}
