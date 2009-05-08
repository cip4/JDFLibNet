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
 * class JDFSheet
 * ==========================================================================
 * @COPYRIGHT Heidelberger Druckmaschinen AG, 1999-2001 ALL RIGHTS RESERVED
 * @Author: sabjon@topmail.de    using a code generator 
 * Warning! very preliminary test version. 
 * Interface subject to change without prior notice!  */


namespace org.cip4.jdflib.resource.process.postpress
{
   using System;
   using System.Collections;



   using EnumSide = org.cip4.jdflib.auto.JDFAutoPart.EnumSide;
   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using VElement = org.cip4.jdflib.core.VElement;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using JDFPart = org.cip4.jdflib.resource.JDFPart;
   using JDFSignature = org.cip4.jdflib.resource.JDFSignature;
   using JDFLayout = org.cip4.jdflib.resource.process.JDFLayout;
   using JDFSurface = org.cip4.jdflib.resource.process.JDFSurface;

   public class JDFSheet : JDFSignature
   {
      private new const long serialVersionUID = 1L;
      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[5];
      static JDFSheet()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.SURFACECONTENTSBOX, 0x44444333, AttributeInfo.EnumAttributeType.rectangle, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.LOCKORIGINS, 0x44444333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.NAME, 0x44444333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.SOURCEWORKSTYLE, 0x44444333, AttributeInfo.EnumAttributeType.enumeration, EnumSourceWorkStyle.getEnum(0), null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.SURFACECONTENTSBOX, 0x44444333, AttributeInfo.EnumAttributeType.rectangle, null, null);
         elemInfoTable_Surface[0] = new ElemInfoTable(ElementName.SURFACE, 0x33333333);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         AttributeInfo ai = base.getTheAttributeInfo();
         if (LocalName.Equals(ElementName.SHEET))
            ai.updateReplace(atrInfoTable);
         return ai;
      }

      // Handle partitioned layouts
      private static ElemInfoTable[] elemInfoTable_Surface = new ElemInfoTable[1];

      protected internal override ElementInfo getTheElementInfo()
      {
         return new ElementInfo(base.getTheElementInfo(), elemInfoTable_Surface);
      }

      ///   
      ///	 <summary> * Constructor for JDFSheet
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFSheet(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFSheet
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFSheet(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFSheet
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="localName"> </param>
      ///	 
      public JDFSheet(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      public override string ToString()
      {
         return "JDFSheet[  --> " + base.ToString() + " ]";
      }

      // ________________________________________________________________________________________
      // Start FRONT Surface
      // ________________________________________________________________________________________

      public virtual JDFSurface getCreateFrontSurface()
      {
         JDFSurface e = getSurface(EnumSide.Front);
         if (e == null)
         {
            e = appendSurface();
            e.setSide(JDFPart.EnumSide.Front);
         }

         return e;
      }

      ///   
      ///	 <summary> * const get surface with the correct partition key </summary>
      ///	 
      public virtual JDFSurface getSurface(EnumSide side)
      {
         JDFSurface s = getSurface(0);
         if (s == null)
            return null;
         if (s.getSide() == side)
            return s;
         s = getSurface(1);
         if (s == null)
            return null;
         if (s.getSide() == side)
            return s;
         return null;
      }

      ///   
      ///	 <summary> * const get first element
      ///	 *  </summary>
      ///	 * @deprecated use getSurface(EnumSide side) 
      ///	 
      [Obsolete("use getSurface(EnumSide side)")]
      public virtual JDFSurface getFrontSurface()
      {
         return getSurface(EnumSide.Front);
      }

      public virtual JDFSurface appendFrontSurface()
      {
         JDFSurface e = getSurface(EnumSide.Front);
         if (e != null)
         {
            throw new JDFException("appendFrontSurface surface already exists");
         }

         e = appendSurface();
         e.setSide(JDFPart.EnumSide.Front);
         return e;
      }

      ///   
      ///	 <summary> * remove first element Surface </summary>
      ///	 
      public virtual void removeFrontSurface()
      {
         JDFSurface e = getSurface(EnumSide.Front);
         if (e != null)
         {
            e.deleteNode();
         }
      }

      ///   
      ///	 <summary> * if this is a new layout, return the partition key signaturename else
      ///	 * return Signature/@Name of this or its appropriate parent
      ///	 *  </summary>
      ///	 * <returns> the name of the signature </returns>
      ///	 
      public override string getSheetName()
      {
         if (LocalName.Equals(ElementName.SHEET))
         {
            return getName();
         }
         if (LocalName.Equals(ElementName.SURFACE))
         {
            JDFSheet sh = (JDFSheet)getParentNode_KElement();
            return sh.getSheetName();
         }
         return base.getSheetName();
      }

      ///   
      ///	 <summary> * test element Surface existance
      ///	 *  </summary>
      ///	 * <returns> boolean true if a matching element exists </returns>
      ///	 
      public virtual bool hasFrontSurface()
      {
         return getSurface(EnumSide.Front) != null;
      }

      ///   
      ///	 <summary> * create inter-resource link to refTarget
      ///	 *  </summary>
      ///	 * <param name="JDFSurface">
      ///	 *            refTarget the element that is referenced </param>
      ///	 
      public virtual void refFrontSurface(JDFSurface refTarget)
      {
         refElement(refTarget);
         refTarget.setSide(EnumSide.Back);
      }

      // _______________________________________________________________
      // Start BACK Surface
      // _______________________________________________________________

      public virtual JDFSurface getCreateBackSurface()
      {
         JDFSurface e = getSurface(EnumSide.Back);
         if (e == null)
         {
            e = appendBackSurface();
         }
         return e;
      }

      ///   
      ///	 <summary> * const get first element
      ///	 *  </summary>
      ///	 * @deprecated use getSurface(EnumSide side) 
      ///	 
      [Obsolete("use getSurface(EnumSide side)")]
      public virtual JDFSurface getBackSurface()
      {
         return getSurface(EnumSide.Back);
      }

      public virtual JDFSurface appendBackSurface()
      {
         JDFSurface e = getSurface(EnumSide.Back);
         if (e != null)
         {
            throw new JDFException("appendBackSurface surface already exists");
         }

         e = appendSurface();
         e.setSide(JDFPart.EnumSide.Back);
         return e;
      }

      ///   
      ///	 <summary> * remove back element Surface </summary>
      ///	 
      public virtual void removeBackSurface()
      {
         JDFSurface e = getSurface(EnumSide.Back);
         if (e != null)
         {
            e.deleteNode();
         }
      }

      ///   
      ///	 <summary> * test element Surface existance
      ///	 *  </summary>
      ///	 * <returns> boolean true if a matching element exists </returns>
      ///	 
      public virtual bool hasBackSurface()
      {
         return getSurface(EnumSide.Back) != null;
      }

      ///   
      ///	 <summary> * create inter-resource link to refTarget
      ///	 *  </summary>
      ///	 * <param name="JDFSurface">
      ///	 *            refTarget the element that is referenced </param>
      ///	 
      public virtual void refBackSurface(JDFSurface refTarget)
      {
         refElement(refTarget);
         refTarget.setSide(EnumSide.Back);
      }

      ///   
      ///	 <summary> * gets or appends a signature in both old and new Layouts if old: a
      ///	 * <Surface> element if new: a Side partition leaf
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            the number of signatures to skip </param>
      ///	 
      public virtual JDFSurface getCreateSurface(int iSkip)
      {
         JDFSurface s = getSurface(iSkip);
         if (s == null)
         {
            s = appendSurface();
         }
         return s;
      }

      ///   
      ///	 <summary> * gets a Surface in both old and new Layouts if old: a <Surface> element if
      ///	 * new: a Side partition leaf
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            the number of signatures to skip </param>
      ///	 
      public virtual JDFSurface getSurface(int iSkip)
      {
         return getLayoutElement(this, ElementName.SURFACE, AttributeName.SIDE, iSkip);
      }

      ///   
      ///	 <summary> * appends a Surface in both old and new Layouts if old: a <Surface> element
      ///	 * if new: a Side partition leaf </summary>
      ///	 
      public virtual JDFSurface appendSurface()
      {
         if (numSurfaces() > 1)
            throw new JDFException("appendSurface: sheet already has two surfaces");

         return appendLayoutElement(this, ElementName.SURFACE, AttributeName.SIDE);
      }

      ///   
      ///	 <summary> * counts the number of Surfaces in both old and new Layouts if old: the
      ///	 * number of <Surface> elements if new: the number of Side partition leaves
      ///	 *  </summary>
      ///	 * <returns> the number of Surfaces </returns>
      ///	 
      public virtual int numSurfaces()
      {
         return numLayoutElements(this, ElementName.SURFACE, AttributeName.SIDE);
      }

      ///   
      ///	 <summary> * (28) get vector of all direct child elements Surface
      ///	 *  </summary>
      ///	 * <param name="JDFAttributeMap">
      ///	 *            mAttrib the map of attributes to select </param>
      ///	 * <param name="boolean"> bAnd if true all attributes in the map are AND'ed, else
      ///	 *        they are OR'ed </param>
      ///	 * @deprecated use getChildElementVector() instead 
      ///	 
      [Obsolete("use getChildElementVector() instead")]
      public virtual VElement getSurfaceVector(JDFAttributeMap mAttrib, bool bAnd)
      {
         VElement myResource = new VElement();
         VElement vElem = getChildElementVector(ElementName.SURFACE, null, mAttrib, bAnd, 0, true);
         for (int i = 0; i < vElem.Count; i++)
         {
            JDFElement k = (JDFElement)vElem[i];
            JDFSurface myJDFSurface = (JDFSurface)k;
            myResource.Add(myJDFSurface);
         }
         return myResource;
      }

      ///   
      ///	 <summary> * get the vector of surfaces in this sheet
      ///	 *  </summary>
      ///	 * <returns> <seealso cref="VElement"/> the vector of surfaces in this </returns>
      ///	 
      public virtual VElement getSurfaceVector()
      {
         return getLayoutElementVector(this, ElementName.SURFACE, AttributeName.SIDE);
      }

      ///   
      ///	 <summary> * (31) create inter-resource link to refTarget
      ///	 *  </summary>
      ///	 * <param name="JDFSurface">
      ///	 *            refTarget the element that is referenced </param>
      ///	 
      public virtual void refSurface(JDFSurface refTarget)
      {
         if (JDFLayout.isNewLayout(this))
            throw new JDFException("refSheet: attempting to reference a partition");
         refElement(refTarget);
      }
   }
}
