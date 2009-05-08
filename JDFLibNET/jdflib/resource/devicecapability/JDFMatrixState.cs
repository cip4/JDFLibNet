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
 * JDFMatrixState.cs
 */


namespace org.cip4.jdflib.resource.devicecapability
{
   using System;
   using System.Collections;
   using System.Collections.Generic;


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   using EnumListType = org.cip4.jdflib.auto.JDFAutoBasicPreflightTest.EnumListType;
   using EnumValueUsage = org.cip4.jdflib.auto.JDFAutoValue.EnumValueUsage;
   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using JDFMatrix = org.cip4.jdflib.datatypes.JDFMatrix;
   using JDFRectangle = org.cip4.jdflib.datatypes.JDFRectangle;
   using JDFValue = org.cip4.jdflib.resource.JDFValue;
   using EnumTerm = org.cip4.jdflib.resource.devicecapability.JDFTerm.EnumTerm;
   using StringUtil = org.cip4.jdflib.util.StringUtil;
   using EnumFitsValue = org.cip4.jdflib.datatypes.EnumFitsValue;
   using JDFBaseDataTypes_Fields = org.cip4.jdflib.datatypes.JDFBaseDataTypes_Fields;

   public class JDFMatrixState : JDFAbstractState
   {
      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[8];
      static JDFMatrixState()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ALLOWEDROTATEMOD, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.ALLOWEDSHIFT, 0x33333311, AttributeInfo.EnumAttributeType.NumberList, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.ALLOWEDTRANSFORMS, 0x33333311, AttributeInfo.EnumAttributeType.enumerations, EnumOrientation.getEnum(0), null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.CURRENTVALUE, 0x33333331, AttributeInfo.EnumAttributeType.matrix, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.DEFAULTVALUE, 0x33333331, AttributeInfo.EnumAttributeType.matrix, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.PRESENTROTATEMOD, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.PRESENTSHIFT, 0x33333311, AttributeInfo.EnumAttributeType.NumberList, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.PRESENTTRANSFORMS, 0x44444431, AttributeInfo.EnumAttributeType.enumerations, EnumOrientation.getEnum(0), null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.VALUE, 0x33333311);
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
      ///	 <summary> * constructor for JDFMatrixState
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFMatrixState(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * constructor for JDFMatrixState
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFMatrixState(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFMatrixState(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
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
         return "JDFMatrixState[ --> " + base.ToString() + " ]";
      }

      public virtual void setCurrentValue(JDFMatrix @value)
      {
         setAttribute(AttributeName.CURRENTVALUE, @value.ToString(), null);
      }

      public virtual JDFMatrix getCurrentValue()
      {
         try
         {
            return new JDFMatrix(getAttribute(AttributeName.CURRENTVALUE));
         }
         catch (FormatException)
         {
            throw new JDFException("JDFMatrixState.getCurrentValue: Attribute CURRENTVALUE is not capable to create JDFMatrix");
         }
      }

      public virtual void setDefaultValue(JDFMatrix @value)
      {
         setAttribute(AttributeName.DEFAULTVALUE, @value.ToString(), null);
      }

      public virtual JDFMatrix getDefaultValue()
      {
         try
         {
            return new JDFMatrix(getAttribute(AttributeName.DEFAULTVALUE));
         }
         catch (FormatException)
         {
            throw new JDFException("JDFMatrixState.getDefaultValue: Attribute DEFAULTVALUE is not capable to create JDFMatrix");
         }
      }

      public virtual void setAllowedRotateMod(double @value)
      {
         setAttribute(AttributeName.ALLOWEDROTATEMOD, @value, null);
      }

      public virtual double getAllowedRotateMod()
      {
         return getRealAttribute(AttributeName.ALLOWEDROTATEMOD, null, 0.0);
      }

      public virtual void setPresentRotateMod(double @value)
      {
         setAttribute(AttributeName.PRESENTROTATEMOD, @value, null);
      }

      public virtual double getPresentRotateMod()
      {
         if (hasAttribute(AttributeName.PRESENTROTATEMOD))
         {
            return getRealAttribute(AttributeName.PRESENTROTATEMOD, null, 0.0);
         }
         return getAllowedRotateMod();
      }

      public virtual void setAllowedShift(JDFRectangle @value)
      {
         setAttribute(AttributeName.ALLOWEDSHIFT, @value.ToString());
      }

      public virtual JDFRectangle getAllowedShift()
      {

         try
         {
            return new JDFRectangle(getAttribute(AttributeName.ALLOWEDSHIFT, null, JDFConstants.EMPTYSTRING));
         }
         catch (FormatException)
         {
            throw new JDFException("JDFMatrixState.getAllowedShift: AttributeValue not capable to create JDFRectangle");
         }
      }

      public virtual void setPresentShift(JDFRectangle @value)
      {
         setAttribute(AttributeName.PRESENTSHIFT, @value.ToString());
      }

      public virtual JDFRectangle getPresentShift()
      {
         if (hasAttribute(AttributeName.PRESENTSHIFT))
         {
            try
            {
               return new JDFRectangle(getAttribute(AttributeName.PRESENTSHIFT, null, JDFConstants.EMPTYSTRING));
            }
            catch (FormatException)
            {
               throw new JDFException("JDFMatrixState.getPresentShift: AttributeValue not capable to create JDFRectangle");
            }
         }
         return getAllowedShift();
      }

      public virtual List<ValuedEnum> getAllowedTransforms()
      {
         return getEnumerationsAttribute(AttributeName.ALLOWEDTRANSFORMS, null, EnumOrientation.getEnum(0), false);
      }

      public virtual void setAllowedTransforms(List<ValuedEnum> @value)
      {
         setEnumerationsAttribute(AttributeName.ALLOWEDTRANSFORMS, @value, null);
      }

      public virtual List<ValuedEnum> getPresentTransforms()
      {
         if (hasAttribute(AttributeName.PRESENTTRANSFORMS))
         {
            return getEnumerationsAttribute(AttributeName.PRESENTTRANSFORMS, null, EnumOrientation.getEnum(0), false);
         }
         return getAllowedTransforms();
      }

      public virtual void setPresentTransforms(List<ValuedEnum> @value)
      {
         setEnumerationsAttribute(AttributeName.PRESENTTRANSFORMS, @value, null);
      }

      //   
      //	 * // Element getter / setter
      //	 

      public virtual JDFValue getValue(int iSkip)
      {
         return (JDFValue)getElement(ElementName.VALUE, JDFConstants.EMPTYSTRING, iSkip);
      }

      public virtual JDFValue appendValue()
      {
         return (JDFValue)appendElement(ElementName.VALUE, null);
      }

      ///   
      ///	 <summary> * Appends element Loc to the end of the iSkip'th subelement Value
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            number of Value elements to skip (iSkip=0 - first Value
      ///	 *            element) </param>
      ///	 * <returns> JDFLoc: newly created Loc element </returns>
      ///	 
      public override JDFLoc appendValueLocLoc(int iSkip)
      {
         JDFValue val = getValue(iSkip);
         if (val == null)
            return null;
         return val.appendLoc();
      }

      //   
      //	 * // Subelement attribute and element Getter / Setter
      //	 

      ///   
      ///	 <summary> * Sets the AllowedValue attribute of the iSkip'th subelement Value
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            the number of Value elements to skip </param>
      ///	 * <param name="value">
      ///	 *            value to set the attribute to </param>
      ///	 
      public virtual void setValueAllowedValue(int iSkip, JDFMatrix @value)
      {
         JDFValue e = (JDFValue)getElement(ElementName.VALUE, null, iSkip);
         e.setAllowedValue(@value.ToString());
      }

      ///   
      ///	 <summary> * Gets the AllowedValue attribute of the iSkip'th subelement Value
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            the number of Value elements to skip </param>
      ///	 * <returns> JDFMatrix: the attribute value </returns>
      ///	 
      public JDFMatrix getValueAllowedValue(int iSkip)
      {
         JDFValue e = (JDFValue)getElement(ElementName.VALUE, null, iSkip);

         try
         {
            return new JDFMatrix(e.getAllowedValue());
         }
         catch (FormatException)
         {
            throw new JDFException("JDFMatrixState.getValueAllowedValue: AttributeValue not capable to create JDFMatrix");
         }

      }

      ///   
      ///	 <summary> * Sets the ValueUsage attribute of the iSkip'th subelement Value
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            the number of Value elements to skip </param>
      ///	 * <param name="value">
      ///	 *            value to set the attribute to </param>
      ///	 
      public virtual void setValueValueUsage(int iSkip, EnumFitsValue @value)
      {
         JDFValue e = (JDFValue)getElement(ElementName.VALUE, null, iSkip);
         e.setValueUsage(EnumValueUsage.getEnum(@value.getName()));
      }

      ///   
      ///	 <summary> * Gets the value of attribute ValueUsage of the iSkip'th subelement Value
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            the number of Value elements to skip </param>
      ///	 * <returns> EnumFitsValue: the attribute value </returns>
      ///	 
      public EnumFitsValue getValueValueUsage(int iSkip)
      {
         JDFValue e = (JDFValue)getElement(ElementName.VALUE, null, iSkip);
         return EnumFitsValue.getEnum(e.getValueUsage().getName());
      }

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

         try
         {
            new JDFMatrix(@value);
         }
         catch (FormatException)
         {
            return; // nop for bad values
         }
         if (testlists == null || EnumFitsValue.Allowed.Equals(testlists))
         {
            JDFValue v = appendValue();
            v.setAllowedValue(@value);
            if (testlists != null)
               v.setValueUsage(EnumValueUsage.Allowed);
         }
         if (EnumFitsValue.Present.Equals(testlists))
         {
            JDFValue v = appendValue();
            v.setAllowedValue(@value);
            if (testlists != null)
               v.setValueUsage(EnumValueUsage.Present);
         }
      }

      public virtual void appendValue(JDFMatrix @value, EnumFitsValue testlists)
      {
         if (testlists == null || EnumFitsValue.Allowed.Equals(testlists))
         {
            JDFValue v = appendValue();
            v.setAllowedValue(@value.ToString());
            if (testlists != null)
               v.setValueUsage(EnumValueUsage.Allowed);
         }
         if (EnumFitsValue.Present.Equals(testlists))
         {
            JDFValue v = appendValue();
            v.setAllowedValue(@value.ToString());
            if (testlists != null)
               v.setValueUsage(EnumValueUsage.Present);
         }
      }

      //   
      //	 * // FitsValue Methods
      //	 

      ///   
      ///	 <summary> * fitsValue - checks whether <code>value</code> matches the Allowed test
      ///	 * lists or Present test lists specified for this State
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to test </param>
      ///	 * <param name="testlists">
      ///	 *            the test lists the value has to match. In this State the test
      ///	 *            lists are RotateMod, Shift, Transforms and ValueElem.<br>
      ///	 *            Choose one of two values: FitsValue_Allowed or
      ///	 *            FitsValue_Present. (Defaults to Allowed)
      ///	 *  </param>
      ///	 * <returns> boolean - true, if the value matches all test lists or if Allowed
      ///	 *         test lists are not specified </returns>
      ///	 
      public override bool fitsValue(string @value, EnumFitsValue testlists)
      {
         VString vs = new VString(@value, JDFConstants.BLANK);
         int siz = vs.Count;
         if (siz % 6 != 0)
         {
            return false;
         }
         List<JDFMatrix> matrixList = new List<JDFMatrix>();

         for (int i = 0; i < siz; i += 6)
         {
            VString v = new VString();
            v.Capacity = 6;
            for (int j = 0; j < 6; j++)
               v.Add(vs.stringAt(i + j));

            try
            {
               JDFMatrix m = new JDFMatrix(StringUtil.setvString(vs, " ", null, null));
               matrixList.Add(m);
            }
            catch (FormatException)
            {
               return false;
            }
         }

         if (fitsListType(matrixList))
         {
            for (int k = 0; k < matrixList.Count; k++)
            {
               JDFMatrix matrix = matrixList[k];
               if (!fitsRotateMod(matrix, testlists) || !fitsShift(matrix, testlists) || !fitsTransforms(matrix, testlists) || !fitsValueElem(matrix, testlists))
                  return false;
            }
            return true;
         }
         return false;
      }

      ///   
      ///	 <summary> * fitsListType - checks whether <code>matrixList</code> matches the value
      ///	 * of the ListType attribute specified for this State
      ///	 *  </summary>
      ///	 * <param name="matrixList">
      ///	 *            vector of matrices to test
      ///	 *  </param>
      ///	 * <returns> boolean - true, if 'value' matches specified ListType </returns>
      ///	 
      private bool fitsListType(List<JDFMatrix> matrixList)
      {
         EnumListType listType = getListType();

         int size = matrixList.Count;

         if (listType.Equals(EnumListType.SingleValue) || listType.Equals(EnumListType.getEnum(0)))
         { // default ListType = SingleValue
            return (size == 1);
         }
         else if (listType.Equals(EnumListType.List))
         {
            return true;
         }
         else if (listType.Equals(EnumListType.UniqueList))
         {
            for (int i = 0; i < size; i++)
            {
               for (int j = i + 1; j < size; j++)
               {
                  JDFMatrix mi = matrixList[i];
                  JDFMatrix mj = matrixList[j];
                  if (mi.Equals(mj))
                     return false;
               }
            }
            return true;
         }
         else
         {
            throw new JDFException("JDFMatrixState.fitsListType illegal ListType attribute");
         }
      }

      ///   
      ///	 <summary> * fitsValueElem - tests, if JDFMatrix <code>matrix</code> matches
      ///	 * subelement Value, specified for this State
      ///	 *  </summary>
      ///	 * <param name="matrix">
      ///	 *            JDFMatrix to test </param>
      ///	 * <param name="valuelist">
      ///	 *            switches between Allowed and Present configuration in
      ///	 *            subelement Value.
      ///	 *  </param>
      ///	 * <returns> boolean - true, if <code>matrix</code> matches subelement Value </returns>
      ///	 
      private bool fitsValueElem(JDFMatrix matrix, EnumFitsValue valuelist)
      {

         VElement v = getChildElementVector(ElementName.VALUE, null, null, true, 0, false);
         int siz = v.Count;
         bool hasValue = false;
         for (int i = 0; i < siz; i++)
         {
            JDFValue elm = (JDFValue)v[i];
            if (elm.hasAttribute(AttributeName.VALUEUSAGE))
            {
               EnumFitsValue valueUsage = getValueValueUsage(i);
               if (valuelist.Equals(valueUsage))
               {
                  hasValue = true;
                  JDFMatrix @value = getValueAllowedValue(i);
                  if (@value.Equals(matrix))
                     return true; // we have found it
               }
            }
            else
            {
               hasValue = true;
               JDFMatrix @value = getValueAllowedValue(i);
               if (@value.Equals(matrix))
                  return true; // we have found it
            }
         }
         return !hasValue; // if no matching, there was no filter
      }

      ///   
      ///	 <summary> * fitsRotateMod - checks whether matrix matches the AllowedRotateMod or
      ///	 * PresentRotateMod, specified for this State
      ///	 *  </summary>
      ///	 * <param name="matrix">
      ///	 *            matrix to test </param>
      ///	 * <param name="rotatemod">
      ///	 *            switches between AllowedRotateMod and PresentRotateMod. </param>
      ///	 * <returns> boolean - true, if <code>matrix</code> matches the RotateMod or
      ///	 *         if AllowedRotateMod is not specified </returns>
      ///	 
      private bool fitsRotateMod(JDFMatrix matrix, EnumFitsValue rotatemod)
      {
         if (rotatemod == null || rotatemod.Equals(EnumFitsValue.Allowed))
         {
            if (!hasAttribute(AttributeName.ALLOWEDROTATEMOD))
               return true;
         }
         else
         {
            if (!hasAttribute(AttributeName.ALLOWEDROTATEMOD) && !hasAttribute(AttributeName.PRESENTROTATEMOD))
               return true;
         }

         double rm;
         if (rotatemod == null || rotatemod.Equals(EnumFitsValue.Allowed))
         {
            rm = getAllowedRotateMod();
         }
         else
         {
            rm = getPresentRotateMod();
         }

         double a = matrix.A;
         double b = matrix.B;
         double c = matrix.C;
         double d = matrix.D;

         if ((a * d - b * c) == 0)
            return false;

         double param = a / Math.Sqrt(Math.Abs(a * d - b * c));

         if (((param - JDFBaseDataTypes_Fields.EPSILON) > 1) || ((param + JDFBaseDataTypes_Fields.EPSILON) < -1))
         {
            return false;
         }
         if (param > 1)
         {
            param = param - JDFBaseDataTypes_Fields.EPSILON;
         }
         if (param < -1)
         {
            param = param + JDFBaseDataTypes_Fields.EPSILON;
         }

         double fi = Math.Acos(param) * 180 / Math.PI; //0~180

         double result = (fi + JDFBaseDataTypes_Fields.EPSILON) - (rm * (int)((fi + JDFBaseDataTypes_Fields.EPSILON) / rm));
         double result180 = (fi + 180 + JDFBaseDataTypes_Fields.EPSILON) - (rm * (int)((fi + 180 + JDFBaseDataTypes_Fields.EPSILON) / rm));

         return ((Math.Abs(result) <= 2 * JDFBaseDataTypes_Fields.EPSILON) || (Math.Abs(result180) <= 2 * JDFBaseDataTypes_Fields.EPSILON));

      }

      ///   
      ///	 <summary> * fitsShift - checks whether <code>matrix</code> matches the AllowedShift
      ///	 * or PresentShift specified for this State
      ///	 *  </summary>
      ///	 * <param name="matrix">
      ///	 *            matrix to test </param>
      ///	 * <param name="shift">
      ///	 *            switches between AllowedShift and PresentShift. </param>
      ///	 * <returns> boolean - true, if <code>matrix</code> matches the Shift or if
      ///	 *         AllowedShift is not specified </returns>
      ///	 
      private bool fitsShift(JDFMatrix matrix, EnumFitsValue shift)
      {

         if (shift == null || shift.Equals(EnumFitsValue.Allowed))
         {
            if (!hasAttribute(AttributeName.ALLOWEDSHIFT))
               return true;
         }
         else
         {
            if (!hasAttribute(AttributeName.ALLOWEDSHIFT) && !hasAttribute(AttributeName.PRESENTSHIFT))
               return true;
         }

         JDFRectangle shiftValue;
         if (shift == null || shift.Equals(EnumFitsValue.Allowed))
         {
            shiftValue = new JDFRectangle(getAllowedShift());
         }
         else
         {
            shiftValue = new JDFRectangle(getPresentShift());
         }

         double minTx = shiftValue.Llx;
         double minTy = shiftValue.Lly;
         double maxTx = shiftValue.Urx;
         double maxTy = shiftValue.Ury;

         double Tx = matrix.Tx;
         double Ty = matrix.Ty;

         return ((Tx >= minTx) && (Tx <= maxTx) && (Ty >= minTy) && (Ty <= maxTy));
      }


      ///   
      ///	 <summary> * fitsTransforms - checks whether <code>matrix</code> matches the
      ///	 * AllowedTransforms or PresentTransforms, specified for this State
      ///	 *  </summary>
      ///	 * <param name="matrix">
      ///	 *            matrix to test </param>
      ///	 * <param name="transforms">
      ///	 *            switches between AllowedTransforms and PresentTransforms. </param>
      ///	 * <returns> boolean - true, if <code>matrix</code> matches the Transforms or
      ///	 *         if AllowedTransforms is not specified </returns>
      ///	 
      private bool fitsTransforms(JDFMatrix matrix, EnumFitsValue transforms)
      {
         if (transforms == null || transforms.Equals(EnumFitsValue.Allowed))
         {
            if (!hasAttribute(AttributeName.ALLOWEDTRANSFORMS))
               return true;
         }
         else
         {
            if (!hasAttribute(AttributeName.ALLOWEDTRANSFORMS) && !hasAttribute(AttributeName.PRESENTTRANSFORMS))
               return true;
         }

         double nT = JDFBaseDataTypes_Fields.EPSILON; // negative tolerance
         double pT = JDFBaseDataTypes_Fields.EPSILON; // positive tolerance

         double a = matrix.A;
         double b = matrix.B;
         double c = matrix.C;
         double d = matrix.D;

         double det = (a * d - b * c);

         if (det == 0)
            return false;

         a = a / Math.Sqrt(Math.Abs(det));
         b = b / Math.Sqrt(Math.Abs(det));
         c = c / Math.Sqrt(Math.Abs(det));
         d = d / Math.Sqrt(Math.Abs(det));

         List<ValuedEnum> vTransf;
         if (transforms == null || transforms.Equals(EnumFitsValue.Allowed))
         {
            vTransf = getAllowedTransforms();
         }
         else
         {
            vTransf = getPresentTransforms();
         }
         int siz = vTransf.Count;
         for (int i = 0; i < siz; i++)
         {
            EnumOrientation orientation = (EnumOrientation)vTransf[i];

            if (orientation.Equals(EnumOrientation.Flip0)) // a=1 b=0 c=0 d=-1
            {
               if ((a - 1 < pT) && (a - 1 > -nT) && (b < pT) && (b > -nT) && (c < pT) && (c > -nT) && (d + 1 < pT) && (d + 1 > -nT))
                  return true;
               continue;
            } // a=0 b=-1
            else if (orientation.Equals(EnumOrientation.Flip90))
            // c=-1 d=0
            {
               if ((a < pT) && (a > -nT) && (b + 1 < pT) && (b + 1 > -nT) && (c + 1 < pT) && (c + 1 > -nT) && (d < pT) && (d > -nT))
                  return true;
               continue;
            } // a=-1 b=0
            else if (orientation.Equals(EnumOrientation.Flip180))
            // c=0 d=1
            {
               if ((a + 1 < pT) && (a + 1 > -nT) && (b < pT) && (b > -nT) && (c < pT) && (c > -nT) && (d - 1 < pT) && (d - 1 > -nT))
                  return true;
               continue;
            } // a=0 b=1
            else if (orientation.Equals(EnumOrientation.Flip270))
            // c=1 d=0
            {
               if ((a < pT) && (a > -nT) && (b - 1 < pT) && (b - 1 > -nT) && (c - 1 < pT) && (c - 1 > -nT) && (d < pT) && (d > -nT))
                  return true;
               continue;
            } // a=1 b=0
            else if (orientation.Equals(EnumOrientation.Rotate0))
            // c=0 d=1
            {
               if ((a - 1 < pT) && (a - 1 > -nT) && (b < pT) && (b > -nT) && (c < pT) && (c > -nT) && (d - 1 < pT) && (d - 1 > -nT))
                  return true;
               continue;
            } // a=0 b=1
            else if (orientation.Equals(EnumOrientation.Rotate90))
            // c=-1
            // d=0
            {
               if ((a < pT) && (a > -nT) && (b - 1 < pT) && (b - 1 > -nT) && (c + 1 < pT) && (c + 1 > -nT) && (d < pT) && (d > -nT))
                  return true;
               continue;
            } // a=-1
            else if (orientation.Equals(EnumOrientation.Rotate180))
            // b=0
            // c=0
            // d=-1
            {
               if ((a + 1 < pT) && (a + 1 > -nT) && (b < pT) && (b > -nT) && (c < pT) && (c > -nT) && (d + 1 < pT) && (d + 1 > -nT))
                  return true;
               continue;
            } // a=0
            else if (orientation.Equals(EnumOrientation.Rotate270))
            // b=-1
            // c=1
            // d=0
            {
               if ((a < pT) && (a > -nT) && (b + 1 < pT) && (b + 1 > -nT) && (c - 1 < pT) && (c - 1 > -nT) && (d < pT) && (d > -nT))
                  return true;
               continue;
            }
            else
            {
               return true;
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
         return EnumTerm.MatrixEvaluation;
      }
   }
}
