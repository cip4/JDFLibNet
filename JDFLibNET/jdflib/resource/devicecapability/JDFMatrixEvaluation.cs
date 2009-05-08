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
 * JDFMatrixEvaluation.cs
 */


namespace org.cip4.jdflib.resource.devicecapability
{
   using System;
   using System.Collections;
   using System.Collections.Generic;
   using System.Text;



   using EnumListType = org.cip4.jdflib.auto.JDFAutoBasicPreflightTest.EnumListType;
   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using JDFMatrix = org.cip4.jdflib.datatypes.JDFMatrix;
   using JDFRectangle = org.cip4.jdflib.datatypes.JDFRectangle;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFValue = org.cip4.jdflib.resource.JDFValue;
   using JDFBaseDataTypes_Fields = org.cip4.jdflib.datatypes.JDFBaseDataTypes_Fields;
   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   public class JDFMatrixEvaluation : JDFEvaluation
   {
      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[4];
      static JDFMatrixEvaluation()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ROTATEMOD, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.SHIFT, 0x33333333, AttributeInfo.EnumAttributeType.NumberList, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.TOLERANCE, 0x33333333, AttributeInfo.EnumAttributeType.XYPair, null, "0 0");
         atrInfoTable[3] = new AtrInfoTable(AttributeName.TRANSFORMS, 0x33333333, AttributeInfo.EnumAttributeType.enumerations, EnumOrientation.getEnum(0), null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.BASICPREFLIGHTTEST, 0x33333333);
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
      ///	 <summary> * constructor for JDFMatrixEvaluation
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFMatrixEvaluation(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * constructor for JDFMatrixEvaluation
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFMatrixEvaluation(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * constructor for JDFMatrixEvaluation
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFMatrixEvaluation(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
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
         return "JDFMatrixEvaluation[ --> " + base.ToString() + " ]";
      }

      //   
      //	 * // Attribute getter/ setter
      //	 

      public virtual void setRotateMod(double @value)
      {
         setAttribute(AttributeName.ROTATEMOD, @value, null);
      }

      public virtual double getRotateMod()
      {
         return getRealAttribute(AttributeName.ROTATEMOD, null, 0.0);
      }

      public virtual void setShift(JDFRectangle @value)
      {
         setAttribute(AttributeName.SHIFT, @value.ToString());
      }

      public virtual JDFRectangle getShift()
      {

         try
         {
            return new JDFRectangle(getAttribute(AttributeName.SHIFT, null, JDFConstants.EMPTYSTRING));
         }
         catch (FormatException)
         {
            throw new JDFException("JDFMatrixEvaluation.getShift: AttributeValue not capable to create JDFRectangle");
         }
      }

      public virtual List<ValuedEnum> getTransforms()
      {
         return getEnumerationsAttribute(AttributeName.TRANSFORMS, null, JDFElement.EnumOrientation.getEnum(0), false);
      }

      public virtual void setTransforms(List<ValuedEnum> @value)
      {
         setEnumerationsAttribute(AttributeName.TRANSFORMS, @value, null);
      }

      public virtual void setTolerance(JDFXYPair @value)
      {
         setAttribute(AttributeName.TOLERANCE, @value.ToString(), null);
      }

      public override JDFXYPair getTolerance()
      {
         return base.getTolerance();
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

      //   
      //	 * // Subelement attribute and element Getter / Setter
      //	 

      ///   
      ///	 <summary> * Sets the <code>Value</code> attribute of the i-th subelement Value
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            the number of Value elements to skip </param>
      ///	 * <param name="value">
      ///	 *            value to set the attribute to </param>
      ///	 
      public virtual void setValueValue(int iSkip, JDFMatrix @value)
      {
         JDFValue e = (JDFValue)getElement(ElementName.VALUE, null, iSkip);
         e.setValue(@value.ToString());
      }

      ///   
      ///	 <summary> * Gets the <code>Value</code> attribute of the i-th subelement Value
      ///	 *  </summary>
      ///	 * <param name="iSkipthe">
      ///	 *            number of Value elements to skip </param>
      ///	 * <returns> JDFMatrix: the attribute value </returns>
      ///	 
      public JDFMatrix getValueValue(int iSkip)
      {
         JDFValue e = (JDFValue)getElement(ElementName.VALUE, null, iSkip);

         try
         {
            return new JDFMatrix(e.getValue());
         }
         catch (FormatException)
         {
            throw new JDFException("JDFMatrixState.getValueValue: AttributeValue not capable to create JDFMatrix");
         }
      }

      //   
      //	 * // FitsValue Methods
      //	 

      ///   
      ///	 <summary> * fitsValue - tests, if the defined 'value' matches testlists, specified
      ///	 * for this Evaluation
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            value - value to test </param>
      ///	 * <returns> boolean - true, if 'value' matches testlists or if testlists are
      ///	 *         not specified </returns>
      ///	 
      public override bool fitsValue(string @value)
      {
         VString vs = new VString(@value, JDFConstants.BLANK);
         int siz = vs.Count;
         if (siz % 6 != 0)
         {
            return false;
         }
         VString matrixList = new VString();
         int i = 0;
         StringBuilder sb = new StringBuilder(250);
         sb.Append(vs[i]);
         while ((i + 1) < siz)
         {
            do
            {
               sb.Append(JDFConstants.BLANK);
               i++;
               sb.Append(vs[i]);
            } while ((i + 1) % 6 != 0);
            matrixList.Add(sb.ToString());
            if ((i + 1) < siz)
            {
               i++;
               sb = new StringBuilder(250);
               sb.Append(vs[i]);
            }
         }

         if (!fitsListType(matrixList))
            return false;

         for (int k = 0; k < matrixList.Count; k++)
         {
            string str = matrixList[k];
            JDFMatrix matrix;
            try
            {
               matrix = new JDFMatrix(str);
            }
            catch (FormatException)
            {
               return false;
            }
            if ((fitsRotateMod(matrix) && fitsShift(matrix) && fitsTransforms(matrix) && fitsValueElem(matrix)) == false)
               return false;
         }
         return true;

      }

      ///   
      ///	 <summary> * fitsListType - checks whether <code>matrixList</code> matches the
      ///	 * ListType attribute specified for this Evaluation
      ///	 *  </summary>
      ///	 * <param name="matrixList">
      ///	 *            value to test </param>
      ///	 * <returns> boolean - true, if <code>matrixList</code> matches specified
      ///	 *         value of ListType </returns>
      ///	 
      private bool fitsListType(VString matrixList)
      {
         EnumListType listType = getListType();

         int size = matrixList.Count;
         for (int i = 0; i < size; i++)
         {
            try
            {
               new JDFMatrix(matrixList[i]);
            }
            catch (JDFException)
            {
               return false;
            }
            catch (FormatException)
            {
               return false;
            }
         }

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
               for (int j = 0; j < size; j++)
               {
                  if (j != i)
                  {
                     string mi = matrixList[i];
                     string mj = matrixList[j];
                     if (mi.CompareTo(mj) == 0)
                        return false;
                  }
               }
            }
            return true;
         }
         else
         {
            throw new JDFException("JDFMatrixEvaluation.fitsListType illegal ListType attribute");
         }
      }

      ///   
      ///	 <summary> * fitsValueElem - checks whether <code>matrix</code> matches subelement
      ///	 * Value, specified for this Evaluation
      ///	 *  </summary>
      ///	 * <param name="matrix">
      ///	 *            JDFMatrix to test
      ///	 *  </param>
      ///	 * <returns> boolean - true, if 'matrix' matches subelement Value </returns>
      ///	 
      private bool fitsValueElem(JDFMatrix matrix)
      {

         VElement v = getChildElementVector(ElementName.VALUE, null, null, true, 0, false);
         int siz = v.Count;
         if (siz == 0)
         {
            return true; // Evaluation has no Value elements
         }
         for (int i = 0; i < siz; i++)
         {
            JDFMatrix @value = getValueValue(i); // JDFValue elm = (JDFValue)
            // v[i];
            if (@value.Equals(matrix))
               return true; // we have found it

         }
         return false;
      }

      ///   
      ///	 <summary> * fitsRotateMod - checks whether <code>matrix</code> matches the
      ///	 * <code>RotateMod</code> attribute specified for this Evaluation
      ///	 *  </summary>
      ///	 * <param name="matrix">
      ///	 *            matrix to test </param>
      ///	 * <returns> boolean - true, if <code>matrix</code> matches the RotateMod or
      ///	 *         if RotateMod is not specified </returns>
      ///	 
      private bool fitsRotateMod(JDFMatrix matrix)
      {
         if (!hasAttribute(AttributeName.ROTATEMOD))
            return true;

         double rm = getRotateMod();

         double a = matrix.A;
         double b = matrix.B;
         double c = matrix.C;
         double d = matrix.D;

         if ((a * d - b * c) == 0)
            return false;

         double nT; // negative tolerance
         double pT; // positive tolerance

         if (hasAttribute(AttributeName.TOLERANCE))
         {
            nT = getTolerance().X;
            pT = getTolerance().Y;
         }
         else
         {
            nT = pT = JDFBaseDataTypes_Fields.EPSILON;
         }

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

         double result = (fi + nT) - (rm * (int)((fi + nT) / rm));
         double result180 = (fi + 180 + nT) - (rm * (int)((fi + 180 + nT) / rm));

         return (Math.Abs(result) <= (nT + pT) || Math.Abs(result180) <= (nT + pT)); // (fi+nT)%rm <= (nT+pT)

      }

      ///   
      ///	 <summary> * fitsShift - checks whether <code>matrix</code> matches the
      ///	 * <code>Shift</code> attribute specified for this Evaluation
      ///	 *  </summary>
      ///	 * <param name="matrix">
      ///	 *            matrix to test </param>
      ///	 * <returns> boolean - true, if 'matrix' matches the Shift or if Shift is not
      ///	 *         specified </returns>
      ///	 
      private bool fitsShift(JDFMatrix matrix)
      {
         if (!hasAttribute(AttributeName.SHIFT))
            return true;

         JDFRectangle shiftValue = new JDFRectangle(getShift());

         double minTx = shiftValue.Llx;
         double minTy = shiftValue.Lly;
         double maxTx = shiftValue.Urx;
         double maxTy = shiftValue.Ury;

         double Tx = matrix.Tx;
         double Ty = matrix.Ty;

         if (!hasAttribute(AttributeName.TOLERANCE))
         {
            return ((Tx >= minTx) && (Tx <= maxTx) && (Ty >= minTy) && (Ty <= maxTy));
         }

         double nT = getTolerance().X; // negative tolerance
         double pT = getTolerance().Y; // positive tolerance

         return ((Tx - nT >= minTx) && (Tx + pT <= maxTx) && (Ty - nT >= minTy) && (Ty + pT <= maxTy));
      }


      ///   
      ///	 <summary> * fitsTransforms - checks whether <code>matrix</code> matches the
      ///	 * <code>Transforms</code> attribute specified for this Evaluation
      ///	 *  </summary>
      ///	 * <param name="matrix">
      ///	 *            matrix to test </param>
      ///	 * <returns> boolean - true, if <code>matrix</code> matches the Transforms or
      ///	 *         if Transforms is not specified </returns>
      ///	 
      private bool fitsTransforms(JDFMatrix matrix)
      {
         if (!hasAttribute(AttributeName.TRANSFORMS))
            return true;

         double nT; // negative tolerance
         double pT; // positive tolerance

         if (hasAttribute(AttributeName.TOLERANCE))
         {
            nT = getTolerance().X;
            pT = getTolerance().Y;
         }
         else
         {
            nT = pT = JDFBaseDataTypes_Fields.EPSILON;
         }

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

         List<ValuedEnum> vTransf = getTransforms();
         int siz = vTransf.Count;
         for (int i = 0; i < siz; i++)
         {
            EnumOrientation orientation = EnumOrientation.getEnum(vTransf[i].getName()); //.intValue());

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
   }
}
