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




/*========================================================================== class JDFSignature extends JDFAutoSignature
 * created 2001-09-06T10:02:57GMT+02:00 ==========================================================================
 *          @COPYRIGHT Heidelberger Druckmaschinen AG, 1999-2001 ALL RIGHTS RESERVED
 *              @Author sabjon@topmail.de   using a code generator
 * Warning! very preliminary test version. Interface subject to change without prior notice! Revision history:   ... */


namespace org.cip4.jdflib.resource
{
   using System;
   using System.Collections;



   using JDFAutoLayout = org.cip4.jdflib.auto.JDFAutoLayout;
   using EnumMediaType = org.cip4.jdflib.auto.JDFAutoMedia.EnumMediaType;
   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using JDFLayout = org.cip4.jdflib.resource.process.JDFLayout;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;
   using JDFSheet = org.cip4.jdflib.resource.process.postpress.JDFSheet;

   ///
   /// <summary> * class that maps both patitioned and non-partitoned layouts
   /// * 
   /// * @author Rainer Prosi, Heidelberger Druckmaschinen
   /// * </summary>
   /// 
   public class JDFSignature : JDFAutoLayout
   {
      private new const long serialVersionUID = 1L;

      // Handle partitioned layouts
      private static ElemInfoTable[] elemInfoTable_Sheet = new ElemInfoTable[1];
      static JDFSignature()
      {
         elemInfoTable_Sheet[0] = new ElemInfoTable(ElementName.SHEET, 0x33333333);
         atrInfoTable[0] = new AtrInfoTable(AttributeName.NAME, 0x44444333, AttributeInfo.EnumAttributeType.string_, null, null);
      }

      protected internal override ElementInfo getTheElementInfo()
      {
         return new ElementInfo(base.getTheElementInfo(), elemInfoTable_Sheet);
      }

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[1];

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         AttributeInfo ai = base.getTheAttributeInfo();
         if (LocalName.Equals(ElementName.SIGNATURE))
            ai.updateReplace(atrInfoTable);
         return ai;
      }

      ///   
      ///	 <summary> * Constructor for JDFSignature
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFSignature(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFSignature
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFSignature(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFSignature
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFSignature(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      ///   
      ///	 <summary> * toString()
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public override string ToString()
      {
         return "JDFSignature[  --> " + base.ToString() + " ]";
      }


      public override bool init()
      {
         bool bRet = base.init();
         if (LocalName.Equals(ElementName.SIGNATURE)) // signatures are
         // resource elements
         // only!, no class
         {
            removeAttribute(AttributeName.CLASS);
         }
         return bRet;
      }

      ///   
      ///	 <summary> * gets or appends a JDFSheet in both old and new Layouts <li>if old: a <code>Sheet</code> element <li>if new: a
      ///	 * <code>SheetName</code> partition leaf
      ///	 *  </summary>
      ///	 * <param name="iSkip"> the number of Sheets to skip </param>
      ///	 * <returns> JDFSheet </returns>
      ///	 
      public virtual JDFSheet getCreateSheet(int iSkip)
      {
         JDFSheet s = getSheet(iSkip);
         if (s == null)
         {
            s = appendSheet();
         }
         return s;
      }

      ///   
      ///	 <summary> * gets a Sheet in both old and new Layouts <li>if old: a <code>Sheet</code> element <li>if new: a
      ///	 * <code>SheetName</code> partition leaf
      ///	 *  </summary>
      ///	 * <param name="iSkip"> the number of Sheets to skip </param>
      ///	 * <returns> JDFSheet </returns>
      ///	 
      public virtual JDFSheet getSheet(int iSkip)
      {
         return getLayoutElement(this, ElementName.SHEET, AttributeName.SHEETNAME, iSkip);
      }

      ///   
      ///	 <summary> * gets a signature in both old and new Layouts if old: a <Signature>
      ///	 * element if new: a SignatureName partition leaf </summary>
      ///	 * <param name="sheetName"> the SheetName partition key value(new) or Sheet/@Name(old)
      ///	 *  </param>
      ///	 * <returns> the signature </returns>
      ///	 
      public virtual JDFSheet getSheet(string sheetName)
      {
         return getLayoutElement(this, ElementName.SHEET, AttributeName.SHEETNAME, sheetName);
      }

      ///   
      ///	 <summary> * gets a signature in both old and new Layouts if old: a <Signature>creates it if it does not exist
      ///	 * element if new: a SignatureName partition leaf </summary>
      ///	 * <param name="sheetName"> the SheetName partition key value(new) or Sheet/@Name(old)
      ///	 *  </param>
      ///	 * <returns> the signature </returns>
      ///	 * <exception cref="JDFException">  </exception>
      ///	 
      public virtual JDFSheet getCreateSheet(string sheetName)
      {
         return getCreateLayoutElement(this, ElementName.SHEET, AttributeName.SHEETNAME, sheetName);
      }

      ///   
      ///	 <summary> * counts the number of Sheets in both old and new Layouts <li>if old: a <code>Sheet</code> element <li>if new: a
      ///	 * <code>SheetName</code> partition leaf
      ///	 *  </summary>
      ///	 * <returns> the number of Sheets </returns>
      ///	 
      public virtual int numSheets()
      {
         return numLayoutElements(this, ElementName.SHEET, AttributeName.SHEETNAME);
      }

      ///   
      ///	 <summary> * (28) get vector of all direct child elements Sheet
      ///	 *  </summary>
      ///	 * <param name="mAttrib"> the map of attributes to select </param>
      ///	 * <param name="bAnd"> if true all attributes in the map are AND'ed, else they are OR'ed </param>
      ///	 * @deprecated use getChildElementVector() instead 
      ///	 
      [Obsolete("use getChildElementVector() instead")]
      public virtual VElement getSheetVector(JDFAttributeMap mAttrib, bool bAnd)
      {
         VElement myResource = new VElement();
         VElement vElem = getChildElementVector(ElementName.SHEET, null, mAttrib, bAnd, 0, true);
         for (int i = 0; i < vElem.Count; i++)
         {
            JDFElement k = (JDFElement)vElem[i];
            JDFSheet myJDFSheet = (JDFSheet)k;
            myResource.Add(myJDFSheet);
         }
         return myResource;
      }

      ///   
      ///	 <summary> * get the vector of sheets in this signature
      ///	 *  </summary>
      ///	 * <returns> <seealso cref="VElement"/> the vector of signatures in this </returns>
      ///	 
      public virtual VElement getSheetVector()
      {
         return getLayoutElementVector(this, ElementName.SHEET, AttributeName.SHEETNAME);
      }

      ///   
      ///	 <summary> * appends a Sheet in both old and new Layouts <li>if old: a <code>Sheet</code> element <li>if new: a
      ///	 * <code>SheetName</code> partition leaf </summary>
      ///	 
      public virtual JDFSheet appendSheet()
      {
         return appendLayoutElement(this, ElementName.SHEET, AttributeName.SHEETNAME);
      }

      ///   
      ///	 <summary> * (31) create inter-resource link to refTarget
      ///	 *  </summary>
      ///	 * <param name="refTarget"> the element that is referenced </param>
      ///	 
      public virtual void refSheet(JDFSheet refTarget)
      {
         if (JDFLayout.isNewLayout(this))
            throw new JDFException("refSheet: attempting to reference a partition");
         refElement(refTarget);
      }

      ///   
      ///	 <summary> * appends a signature in both old and new Layouts if old: a <code>< Signature></code> element if new: a
      ///	 * SignatureName partition leaf </summary>
      ///	 * <param name="layout">  </param>
      ///	 * <param name="elementName">  </param>
      ///	 * <param name="partitionKeyName"> 
      ///	 *  </param>
      ///	 * <returns> JDFLayout </returns>
      ///	 * <exception cref="JDFException">  </exception>
      ///	 
      protected internal static JDFLayout appendLayoutElement(JDFResource layout, string elementName, string partitionKeyName)
      {
         JDFLayout s = null;
         if (JDFLayout.isNewLayout(layout))
         {
            int n = 1 + numLayoutElements(layout, elementName, partitionKeyName);
            s = (JDFLayout)layout.addPartition(EnumPartIDKey.getEnum(partitionKeyName), partitionKeyName + Convert.ToString(n));
         }
         else
         {
            s = (JDFLayout)layout.appendElement(elementName);
         }
         return s;
      }

      ///   
      ///	 <summary> * get the number of layout elements
      ///	 *  </summary>
      ///	 * <param name="layout"> </param>
      ///	 * <param name="elementName"> </param>
      ///	 * <param name="partitionKeyName"> </param>
      ///	 * <returns> int: number of layout elements </returns>
      ///	 
      protected internal static int numLayoutElements(JDFResource layout, string elementName, string partitionKeyName)
      {
         VElement v = getLayoutElementVector(layout, elementName, partitionKeyName);
         return v == null ? 0 : v.Count;
      }

      ///   
      ///	 <summary> * get a specific layout element
      ///	 *  </summary>
      ///	 * <param name="layout"> </param>
      ///	 * <param name="elementName"> </param>
      ///	 * <param name="partitionKeyName"> </param>
      ///	 * <param name="iSkip"> the index of the element, negative values count backwards from the end </param>
      ///	 * <returns> JDFLayout: the element </returns>
      ///	 
      protected internal static JDFLayout getLayoutElement(JDFResource layout, string elementName, string partitionKeyName, int iSkip)
      {
         int iSkipLocal = iSkip;

         JDFLayout s = null;
         if (JDFLayout.isNewLayout(layout))
         {
            VElement v = layout.getLeaves(true);
            VElement v2 = new VElement();
            for (int i = 0; i < v.Count; i++)
            {
               if (v[i].hasAttribute_KElement(partitionKeyName, null, false))
                  v2.Add(v[i]);
            }
            v = v2;
            if (iSkipLocal < 0)
               iSkipLocal = v.Count + iSkipLocal;

            if (iSkipLocal >= 0 && v.Count > iSkipLocal)
               s = (JDFLayout)v[iSkipLocal];
         }
         else
         {
            s = (JDFLayout)layout.getElement(elementName, null, iSkipLocal);

         }
         return s;
      }

      ///   
      ///	 <summary> * get a specific layout element by name
      ///	 *  </summary>
      ///	 * <param name="layout"> </param>
      ///	 * <param name="elementName"> </param>
      ///	 * <param name="partitionKeyName"> </param>
      ///	 * <param name="objectName">  </param>
      ///	 * <returns> JDFLayout: the element </returns>
      ///	 
      protected internal static JDFLayout getLayoutElement(JDFResource layout, string elementName, string partitionKeyName, string objectName)
      {
         JDFLayout s = null;
         if (JDFLayout.isNewLayout(layout))
         {
            s = (JDFLayout)layout.getPartition(new JDFAttributeMap(partitionKeyName, objectName), null);
         }
         else
         {
            s = (JDFLayout)layout.getChildWithAttribute(elementName, AttributeName.NAME, null, objectName, 0, true);
         }
         return s;
      }

      ///   
      ///	 <summary> * get a specific layout element by name, creates it if it does not exist
      ///	 *  </summary>
      ///	 * <param name="layout"> </param>
      ///	 * <param name="elementName"> </param>
      ///	 * <param name="partitionKeyName"> </param>
      ///	 * <param name="objectName">  </param>
      ///	 * <returns> JDFLayout: the element </returns>
      ///	 * <exception cref="JDFException"> if the location of a newly created element is not well defined  </exception>
      ///	 
      protected internal static JDFLayout getCreateLayoutElement(JDFResource layout, string elementName, string partitionKeyName, string objectName)
      {
         JDFLayout s = getLayoutElement(layout, elementName, partitionKeyName, objectName);
         if (s != null)
            return s;
         if (JDFLayout.isNewLayout(layout))
         {
            s = (JDFLayout)layout.addPartition(EnumPartIDKey.getEnum(partitionKeyName), objectName);
         }
         else
         {
            s = (JDFLayout)layout.appendElement(elementName);
            s.setName(objectName);
         }
         return s;
      }

      ///   
      ///	 <summary> * get a vector of specific layout elements
      ///	 *  </summary>
      ///	 * <param name="layout"> </param>
      ///	 * <param name="elementName"> </param>
      ///	 * <param name="partitionKeyName"> </param>
      ///	 * <returns> VElement: the vector of elements </returns>
      ///	 
      protected internal static VElement getLayoutElementVector(JDFResource layout, string elementName, string partitionKeyName)
      {
         if (JDFLayout.isNewLayout(layout))
         {
            return layout.getChildElementVector_JDFElement(ElementName.LAYOUT, null, new JDFAttributeMap(partitionKeyName, (string)null), true, 0, true);
         }
         return layout.getChildElementVector_JDFElement(elementName, null, null, true, 0, true);
      }

      ///   
      ///	 <summary> * get the leaves of a layout, either pre 1.2 or post 1.3
      ///	 *  </summary>
      ///	 * <returns> VElement the layout leaves, i.e. partition leaves(1.3+) or explicit surfaces(1.2-) </returns>
      ///	 
      public virtual VElement getLayoutLeaves(bool bAll)
      {
         if (JDFLayout.isNewLayout(this))
            return getLeaves(bAll);
         return getChildrenByTagName(ElementName.SURFACE, null, null, false, true, -1);
      }

      ///   
      ///	 <summary> * if this is a new layout, return the partition key signaturename else return Signature/@Name of this or its
      ///	 * appropriate parent
      ///	 *  </summary>
      ///	 * <returns> the name of the signature </returns>
      ///	 
      public override string getSignatureName()
      {
         if (LocalName.Equals(ElementName.SIGNATURE))
            return getName();
         if (LocalName.Equals(ElementName.SHEET))
         {
            KElement parentNode = getParentNode_KElement();
            if (parentNode is JDFSignature)
            {
               JDFSignature sig = (JDFSignature)parentNode;
               return sig.getSignatureName();
            }
         }
         else if (LocalName.Equals(ElementName.SURFACE))
         {
            KElement parentNode = getParentNode_KElement().getParentNode_KElement();
            if (parentNode is JDFSignature)
            {
               JDFSignature sig = (JDFSignature)parentNode;
               return sig.getSignatureName();
            }
         }
         return base.getSignatureName();
      }

      ///   
      ///	 <summary> * gets the corresponding media with a given mediatype </summary>
      ///	 * <param name="mediaType"> the mediaType - must NOT be null </param>
      ///	 * <returns> the media, null if none is there or mediaType==null; </returns>
      ///	 
      public virtual JDFMedia getMedia(EnumMediaType mediaType)
      {
         if (mediaType == null)
            return null;

         VElement v = getChildElementVector(ElementName.MEDIA, null);
         if (v != null)
         {
            int siz = v.Count;
            for (int i = 0; i < siz; i++)
            {
               JDFMedia m = (JDFMedia)v[i];
               if (mediaType.Equals(m.getMediaType()))
                  return m;
            }
         }

         return null;
      }
   }
}
