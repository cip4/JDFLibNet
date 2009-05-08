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




/* ========================================================================== 
 * class JDFValue extends JDFResource
 * ==========================================================================
 * @COPYRIGHT Heidelberger Druckmaschinen AG, 1999-2001 ALL RIGHTS RESERVED
 * @Author: sabjon@topmail.de   using a code generator 
 * Warning! very preliminary test version. 
 * Interface subject to change without prior notice! 
 * Revision history:   ... */


namespace org.cip4.jdflib.resource
{
   using System;
   using System.Collections;
   using System.Xml;



   using EnumValueUsage = org.cip4.jdflib.auto.JDFAutoValue.EnumValueUsage;
   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using JDFAbstractState = org.cip4.jdflib.resource.devicecapability.JDFAbstractState;
   using JDFLoc = org.cip4.jdflib.resource.devicecapability.JDFLoc;
   using JDFMatrixEvaluation = org.cip4.jdflib.resource.devicecapability.JDFMatrixEvaluation;
   using JDFMatrixState = org.cip4.jdflib.resource.devicecapability.JDFMatrixState;
   using JDFPDFPathEvaluation = org.cip4.jdflib.resource.devicecapability.JDFPDFPathEvaluation;
   using JDFPDFPathState = org.cip4.jdflib.resource.devicecapability.JDFPDFPathState;
   using JDFStringEvaluation = org.cip4.jdflib.resource.devicecapability.JDFStringEvaluation;
   using JDFStringState = org.cip4.jdflib.resource.devicecapability.JDFStringState;

   public class JDFValue : JDFElement // ignore JDFAutoValue
   {
      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[1];
      static JDFValue()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.VALUEUSAGE, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumValueUsage.getEnum(0), null);
         atrInfoTable_matrix[0] = new AtrInfoTable(AttributeName.ALLOWEDVALUE, 0x22222222, AttributeInfo.EnumAttributeType.matrix, null, null);
         atrInfoTable_matrix[1] = new AtrInfoTable(AttributeName.PRESENTVALUE, 0x44444431, AttributeInfo.EnumAttributeType.matrix, null, null);
         atrInfoTable_pdfpath[0] = new AtrInfoTable(AttributeName.ALLOWEDVALUE, 0x22222222, AttributeInfo.EnumAttributeType.PDFPath, null, null);
         atrInfoTable_pdfpath[1] = new AtrInfoTable(AttributeName.PRESENTVALUE, 0x44444431, AttributeInfo.EnumAttributeType.PDFPath, null, null);
         atrInfoTable_string[0] = new AtrInfoTable(AttributeName.ALLOWEDVALUE, 0x22222222, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable_string[1] = new AtrInfoTable(AttributeName.PRESENTVALUE, 0x44444431, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable_matrixEval[0] = new AtrInfoTable(AttributeName.VALUE, 0x22222222, AttributeInfo.EnumAttributeType.matrix, null, null);
         atrInfoTable_pdfpathEval[0] = new AtrInfoTable(AttributeName.VALUE, 0x22222222, AttributeInfo.EnumAttributeType.PDFPath, null, null);
         atrInfoTable_stringEval[0] = new AtrInfoTable(AttributeName.VALUE, 0x22222222, AttributeInfo.EnumAttributeType.string_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.LOC, 0x33333311);
      }

      private static AtrInfoTable[] atrInfoTable_matrix = new AtrInfoTable[2];

      private static AtrInfoTable[] atrInfoTable_pdfpath = new AtrInfoTable[2];

      private static AtrInfoTable[] atrInfoTable_string = new AtrInfoTable[2];
      private static AtrInfoTable[] atrInfoTable_matrixEval = new AtrInfoTable[1];

      private static AtrInfoTable[] atrInfoTable_pdfpathEval = new AtrInfoTable[1];

      private static AtrInfoTable[] atrInfoTable_stringEval = new AtrInfoTable[1];

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         AttributeInfo ai = base.getTheAttributeInfo();

         KElement parent = getParentNode_KElement();
         if (parent is JDFAbstractState)
         {
            ai.updateReplace(atrInfoTable);
         }

         if (parent is JDFMatrixState)
         {
            ai.updateReplace(atrInfoTable_matrix);
         }
         else if (parent is JDFPDFPathState)
         {
            ai.updateReplace(atrInfoTable_pdfpath);
         }
         else if (parent is JDFStringState)
         {
            ai.updateReplace(atrInfoTable_string);
         }
         else if (parent is JDFMatrixEvaluation)
         {
            ai.updateReplace(atrInfoTable_matrixEval);
         }
         else if (parent is JDFPDFPathEvaluation)
         {
            ai.updateReplace(atrInfoTable_pdfpathEval);
         }
         else if (parent is JDFStringEvaluation)
         {
            ai.updateReplace(atrInfoTable_stringEval);
         }

         return ai;

      }

      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[1];

      protected internal override ElementInfo getTheElementInfo()
      {
         ElementInfo ei = base.getTheElementInfo();

         XmlNode parentNode = ParentNode;
         if (parentNode is JDFAbstractState)
         {
            ei.updateAdd(elemInfoTable);
         }
         return ei;
      }

      ///   
      ///	 <summary> * Constructor for JDFValue
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFValue(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFValue
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFValue(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFValue
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="localName"> </param>
      ///	 
      public JDFValue(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      public override string ToString()
      {
         return "JDFValue[  --> " + base.ToString() + " ]";
      }

      ///   
      ///	 * @deprecated use EnumValueUsage.getEnum(enumName); 
      ///	 * <param name="enumName">
      ///	 * @return </param>
      ///	 
      [Obsolete("use EnumValueUsage.getEnum(enumName);")]
      public static EnumValueUsage stringToValueUsage(string enumName)
      {
         return EnumValueUsage.getEnum(enumName);
      }

      ///   
      ///	 <summary> * (14) set attribute AllowedValue
      ///	 *  </summary>
      ///	 * <param name="String"> value: the value to set the attribute to </param>
      ///	 
      public virtual void setAllowedValue(string @value)
      {
         setAttribute(AttributeName.ALLOWEDVALUE, @value, null);
      }

      ///   
      ///	 <summary> * (23) get String attribute AllowedValue
      ///	 *  </summary>
      ///	 * <returns> String the value of the attribute </returns>
      ///	 
      public virtual string getAllowedValue()
      {
         return getAttribute(AttributeName.ALLOWEDVALUE, null, "");
      }

      ///   
      ///	 <summary> * (14) set attribute PresentValue
      ///	 *  </summary>
      ///	 * <param name="String"> value: the value to set the attribute to </param>
      ///	 
      public virtual void setPresentValue(string @value)
      {
         setAttribute(AttributeName.PRESENTVALUE, @value, null);
      }

      ///   
      ///	 <summary> * (23) get String attribute PresentValue
      ///	 *  </summary>
      ///	 * <returns> String the value of the attribute </returns>
      ///	 
      public virtual string getPresentValue()
      {
         return getAttribute(AttributeName.PRESENTVALUE, null, "");
      }

      //   
      //	 * --------------------------------------------------------------------- Methods for Attribute ValueUsage
      //	 * ---------------------------------------------------------------------
      //	 
      ///
      ///   
      ///	 <summary> * (5) set attribute ValueUsage
      ///	 *  </summary>
      ///	 * <param name="EnumValueUsage"> enumVar: the enumVar to set the attribute to </param>
      ///	 
      public virtual void setValueUsage(EnumValueUsage enumVar)
      {
         setAttribute(AttributeName.VALUEUSAGE, enumVar.getName(), null);
      }

      ///   
      ///	 <summary> * (9) get ValueUsage attribute ValueUsage
      ///	 *  </summary>
      ///	 * <returns> EnumValueUsage the value of the attribute </returns>
      ///	 
      public virtual EnumValueUsage getValueUsage()
      {
         return EnumValueUsage.getEnum(getAttribute(AttributeName.VALUEUSAGE, null, null));
      }

      ///   
      ///	 <summary> * (14) set attribute Value
      ///	 *  </summary>
      ///	 * <param name="String"> value: the value to set the attribute to </param>
      ///	 
      public virtual void setValue(string @value)
      {
         setAttribute(AttributeName.VALUE, @value, null);
      }

      ///   
      ///	 <summary> * (23) get String attribute Value
      ///	 *  </summary>
      ///	 * <returns> String the value of the attribute </returns>
      ///	 
      public virtual string getValue()
      {
         return getAttribute(AttributeName.VALUE, null, null);
      }

      //   
      //	 * // Element getter / setter
      //	 

      ///   
      ///	 <summary> * (26) getCreateLoc
      ///	 *  </summary>
      ///	 * <param name="int"> iSkip number of elements to skip </param>
      ///	 * <returns> JDFLoc the element </returns>
      ///	 
      public virtual JDFLoc getCreateLoc(int iSkip)
      {
         return (JDFLoc)getCreateElement_KElement("Loc", null, iSkip);
      }

      ///   
      ///	 <summary> * (27) const get element Loc
      ///	 *  </summary>
      ///	 * <param name="int"> iSkip number of elements to skip </param>
      ///	 * <returns> JDFLoc the element default is getLoc(0) </returns>
      ///	 
      public virtual JDFLoc getLoc(int iSkip)
      {
         return (JDFLoc)getElement("Loc", null, iSkip);
      }

      ///   
      ///	 <summary> * (28) get vector of all direct child elements Loc
      ///	 *  </summary>
      ///	 * <param name="JDFAttributeMap"> mAttrib the map of attributes to select </param>
      ///	 * <param name="boolean"> bAnd if true all attributes in the map are AND'ed, else they are OR'ed </param>
      ///	 * @deprecated use getChildElementVector() instead 
      ///	 
      [Obsolete("use getChildElementVector() instead")]
      public virtual VElement getLocVector(JDFAttributeMap mAttrib, bool bAnd)
      {
         VElement myResource = new VElement();
         VElement vElem = getChildElementVector("Loc", null, mAttrib, bAnd, 0, true);
         for (int i = 0; i < vElem.Count; i++)
         {
            JDFElement k = (JDFElement)vElem[i];
            JDFLoc myJDFLoc = (JDFLoc)k;
            myResource.Add(myJDFLoc);
         }
         return myResource;
      }

      ///   
      ///	 * @deprecated use getChildElementVector() instead 
      ///	 
      [Obsolete("use getChildElementVector() instead")]
      public virtual VElement getLocVector()
      {
         return getLocVector(new JDFAttributeMap(), true);
      }

      public virtual JDFLoc appendLoc()
      {
         return (JDFLoc)appendElement(ElementName.LOC, null);
      }
   }
}