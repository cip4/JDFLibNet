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
 * class JDFLayout extends JDFAutoLayout
 * created 2001-09-05T08:21:57GMT+02:00 
 * ==========================================================================
 * @COPYRIGHT Heidelberger Druckmaschinen AG, 1999-2001 ALL RIGHTS RESERVED
 * @Author sabjon@topmail.de    using a code generator 
 * Warning! very preliminary test version. 
 * Interface subject to change without prior notice!  */


namespace org.cip4.jdflib.resource.process
{
   using System;


   using EnumSide = org.cip4.jdflib.auto.JDFAutoPart.EnumSide;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFRefElement = org.cip4.jdflib.core.JDFRefElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFSignature = org.cip4.jdflib.resource.JDFSignature;
   using JDFSheet = org.cip4.jdflib.resource.process.postpress.JDFSheet;

   ///
   /// <summary> * @author Rainer Prosi, Heidelberger Druckmaschinen
   /// * </summary>
   /// 
   public class JDFLayout : JDFSurface
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFLayout
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFLayout(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFLayout
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFLayout(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFLayout
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFLayout(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return "JDFLayout[  --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * version fixing routine
      ///	 * 
      ///	 * uses heuristics to modify this element and its children to be compatible
      ///	 * with a given version in general, it will be able to move from low to high
      ///	 * versions but potentially fail when attempting to move from higher to
      ///	 * lower versions
      ///	 *  </summary>
      ///	 * <param name="version">
      ///	 *            : version that the resulting element should correspond to </param>
      ///	 * <returns> true if successful </returns>
      ///	 
      public override bool fixVersion(EnumVersion version)
      {
         bool bRet = true;
         if (isResourceRoot() && version != null)
         {
            bool newLayout = isNewLayout(this);
            if (version.getValue() >= EnumVersion.Version_1_3.getValue() && !newLayout)
            {
               bRet = toNewLayout();
            }
            else if (version.getValue() < EnumVersion.Version_1_3.getValue() && newLayout)
            {
               bRet = fromNewLayout();
            }
         }
         return base.fixVersion(version) && bRet;
      }


      ///   
      ///	 <summary> * generate a JDF 1.3 compatible Layout from this (1.2)
      ///	 *  </summary>
      ///	 * <returns> true if successful </returns>
      ///	 
      public virtual bool toNewLayout()
      {
         VElement vSig = getChildElementVector(ElementName.SIGNATURE, null, null, false, 0, false);
         // loop over all signatures and rename them to Layout
         for (int iSig = 0; iSig < vSig.Count; iSig++)
         {
            JDFElement rSig = (JDFElement)vSig[iSig];
            if (rSig is JDFRefElement)
            {
               rSig = ((JDFRefElement)rSig).inlineRef();
            }
            //C# renameElement only returns the renamed element.
            rSig = (JDFElement)rSig.renameElement(ElementName.LAYOUT, null);
            JDFLayout newLO = (JDFLayout)rSig;
            newLO.setPartIDKey(EnumPartIDKey.SignatureName, rSig.getAttribute(AttributeName.NAME, null, "Sig" + Convert.ToString(iSig)));
            newLO.cleanLayoutLeaf();

            VElement vSheet = newLO.getChildElementVector(ElementName.SHEET, null, null, false, 0, false);
            // loop over all sheets and rename them to Layout
            for (int iSheet = 0; iSheet < vSheet.Count; iSheet++)
            {
               JDFElement rSheet = (JDFElement)vSheet[iSheet];
               if (rSheet is JDFRefElement)
               {
                  rSheet = ((JDFRefElement)rSheet).inlineRef();
               }
               //C# renameElement only returns the renamed element.
               rSheet = (JDFElement)rSheet.renameElement(ElementName.LAYOUT, null);
               newLO = (JDFLayout)rSheet;
               newLO.setPartIDKey(EnumPartIDKey.SheetName, rSheet.getAttribute(AttributeName.NAME, null, "Sheet" + Convert.ToString(iSheet)));
               newLO.cleanLayoutLeaf();

               VElement vSurf = newLO.getChildElementVector(ElementName.SURFACE, null, null, false, 0, false);
               // loop over all surfaces and rename them to Layout
               for (int iSurf = 0; iSurf < vSurf.Count; iSurf++)
               {
                  JDFElement rSurf = (JDFElement)vSurf[iSurf];
                  if (rSurf is JDFRefElement)
                  {
                     rSurf = ((JDFRefElement)rSurf).inlineRef();
                  }
                  //C# renameElement only returns the renamed element.
                  rSurf = (JDFElement)rSurf.renameElement(ElementName.LAYOUT, null);
                  newLO = (JDFLayout)rSurf;
                  newLO.setPartIDKey(EnumPartIDKey.Side, rSurf.getAttribute(AttributeName.SIDE, null, "Surf" + Convert.ToString(iSurf)));
                  newLO.cleanLayoutLeaf();
               }
            }
         }
         return true;
      }

      ///   
      ///	 <summary> * routine to clean up bookkeeping variables when moving from resource to
      ///	 * partition leaf </summary>
      ///	 
      private void cleanLayoutLeaf()
      {
         removeAttribute(AttributeName.NAME);
         removeAttribute(AttributeName.CLASS);
      }

      ///   
      ///	 <summary> * generate a JDF 1.2 compatible Layout from this (1.3)
      ///	 *  </summary>
      ///	 * <returns> bool true if successful
      ///	 *  </returns>
      ///	 
      public virtual bool fromNewLayout()
      {
         // TODO: fix content object placement
         VElement vLO = getChildElementVector_JDFElement(ElementName.LAYOUT, null, new JDFAttributeMap("SignatureName", ""), false, 0, false);
         VElement vSig = new VElement();
         if (vLO.IsEmpty())
         {
            JDFSignature signature = (JDFSignature)appendElement(ElementName.SIGNATURE);
            signature.setName("Sig_00");
            vSig.Add(signature);
            moveElementsTo((JDFLayout)signature);
         }
         else
         {
            JDFSignature sig = null;
            for (int i = 0; i < vLO.Count; i++)
            {
               JDFElement lo = (JDFElement)vLO[i];
               sig = null;
               if (lo.hasAttribute(AttributeName.SIGNATURENAME))
               {
                  lo.renameAttribute(AttributeName.SIGNATURENAME, AttributeName.NAME, null, null);
                  sig = (JDFSignature)lo.renameElement(ElementName.SIGNATURE, null);
                  sig.cleanResourceAttributes();
                  vSig.Add(sig);
               }
               else
               {
                  if (vSig.IsEmpty())
                  {
                     JDFSignature signature = (JDFSignature)appendElement(ElementName.SIGNATURE);
                     signature.setName("Sig_00");
                     vSig.Add(sig);
                  }
               }
               if (sig != null)
                  moveElement(sig, null);
            }
         }
         int nSheet = 0;
         for (int iSig = 0; iSig < vSig.Count; iSig++)
         {
            JDFSignature sig = (JDFSignature)vSig[iSig];
            vLO = sig.getChildElementVector_JDFElement(ElementName.LAYOUT, null, new JDFAttributeMap("SheetName", ""), false, 0, false);
            VElement vSheet = new VElement();
            if (vLO.IsEmpty())
            {
               nSheet++;
               JDFSheet sheet = (JDFSheet)sig.appendElement(ElementName.SHEET);
               sheet.setName("Sheet_" + Convert.ToString(nSheet));
               vSheet.Add(sheet);
               ((JDFLayout)sig).moveElementsTo((JDFLayout)sheet);
            }
            else
            {
               JDFSheet sheet = null;
               for (int i = 0; i < vLO.Count; i++)
               {
                  sheet = null;
                  JDFElement lo = (JDFElement)vLO[i];
                  if (lo.hasAttribute(AttributeName.SHEETNAME))
                  {
                     lo.renameAttribute(AttributeName.SHEETNAME, AttributeName.NAME, null, null);
                     sheet = (JDFSheet)lo.renameElement(ElementName.SHEET, null);
                     sheet.cleanResourceAttributes();
                     vSheet.Add(sheet);
                     nSheet++;
                  }
                  else
                  {
                     if (vSheet.IsEmpty())
                     {
                        nSheet++;
                        sheet = (JDFSheet)sig.appendElement(ElementName.SHEET);
                        sheet.setName("Sheet_" + Convert.ToString(nSheet));
                        vSheet.Add(sheet);
                     }
                     if (sheet != null)
                        sheet.moveElement(lo, null);
                  }
               }
            }

            for (int iSheet = 0; iSheet < vSheet.Count; iSheet++)
            {
               JDFSheet sheet = (JDFSheet)vSheet[iSheet];
               vLO = sheet.getChildElementVector_JDFElement(ElementName.LAYOUT, null, new JDFAttributeMap("Side", ""), false, 0, false);
               if (vLO.IsEmpty())
               {
                  JDFSurface surf = (JDFSurface)sheet.appendElement(ElementName.SURFACE);
                  surf.setSide(EnumSide.Front);
                  ((JDFLayout)sheet).moveElementsTo((JDFLayout)surf);
               }
               else
               {
                  for (int i = 0; i < vLO.Count; i++)
                  {
                     JDFSurface surface = (JDFSurface)vLO[i];
                     //C# renameElement only returns the renamed element.
                     surface = (JDFSurface)surface.renameElement(ElementName.SURFACE, null);
                     EnumSide sid = surface.getSide();
                     surface.cleanResourceAttributes();
                     surface.setSide(sid);
                  }
               }
            }
         }
         removeFromAttribute(AttributeName.PARTIDKEYS, AttributeName.SIGNATURENAME, null, JDFConstants.BLANK, -1);
         removeFromAttribute(AttributeName.PARTIDKEYS, AttributeName.SHEETNAME, null, JDFConstants.BLANK, -1);
         removeFromAttribute(AttributeName.PARTIDKEYS, AttributeName.SIDE, null, JDFConstants.BLANK, -1);
         return true;
      }


      private void moveElementsTo(JDFLayout target)
      {
         VElement vPO = getPlacedObjectVector();
         if (vPO != null)
         {
            for (int i = 0; i < vPO.Count; i++)
               target.moveElement(vPO[i], null);
         }
         vPO = getChildElementVector_JDFElement(ElementName.LAYOUT, null, null, false, 0, false);
         if (vPO != null)
         {
            for (int i = 0; i < vPO.Count; i++)
               target.moveElement(vPO[i], null);
         }

      }

      ///   
      ///	 <summary> * heuristics to check which version an element of a Layout is in: 1.3 or
      ///	 * 1.2
      ///	 * 
      ///	 * Note that this routine is static since it must be used on all sheets,
      ///	 * surfaces etc.
      ///	 *  </summary>
      ///	 * <param name="sheet">
      ///	 *            the Sheet, Surface, Signature or Layout to check </param>
      ///	 * <returns> true if this is a new, i.e. partitioned Layout
      ///	 *  </returns>
      ///	 
      public static bool isNewLayout(JDFResource sheet)
      {
         // not one of Layout, Signature, Sheet or Surface
         if (!(sheet is JDFLayout))
            return false;

         // either Signature, Sheet or Surface --> old
         if (!sheet.LocalName.Equals(ElementName.LAYOUT))
            return false;

         // it's a layout the only allowed (old) element is a signature , if it
         // exists --> old
         if (sheet.getElement_KElement(ElementName.SIGNATURE, null, 0) != null)
            return false;
         // it is a layout and it has no subelements and it is partitioned -->
         // new
         JDFResource resourceRoot = sheet.getResourceRoot();
         if (resourceRoot.hasAttribute(AttributeName.PARTIDKEYS))
            return true;
         // it is a non partitioned layout and it has palacedobjects --> new
         if (resourceRoot.hasChildElement(ElementName.CONTENTOBJECT, null) || resourceRoot.hasChildElement(ElementName.MARKOBJECT, null))
            return true;

         // now I'm ready to punt - no partition and no subelements --> assume
         // that version tags are correct
         EnumVersion v = sheet.getVersion(true);

         // no version, we are 1.3 --> assume 1.3
         if (v == null)
            return true;

         return v.getValue() >= EnumVersion.Version_1_3.getValue();
      }

      ///   
      ///	 <summary> * appends a signature in both old and new Layouts if old: a <Signature>
      ///	 * element if new: a SignatureName partition leaf </summary>
      ///	 
      public override JDFSignature appendSignature()
      {
         return appendLayoutElement(this, ElementName.SIGNATURE, AttributeName.SIGNATURENAME);
      }

      ///   
      ///	 <summary> * counts the number of signatures in both old and new Layouts if old: the
      ///	 * number of <Signature> elements if new: the number of SignatureName
      ///	 * partition leaves
      ///	 *  </summary>
      ///	 * <returns> the number of signatures </returns>
      ///	 
      public virtual int numSignatures()
      {
         return numLayoutElements(this, ElementName.SIGNATURE, AttributeName.SIGNATURENAME);
      }

      ///   
      ///	 <summary> * gets or appends a signature in both old and new Layouts if old: a
      ///	 * <Signature> element if new: a SignatureName partition leaf
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            the number of signatures to skip </param>
      ///	 
      public override JDFSignature getCreateSignature(int iSkip)
      {
         JDFSignature s = getSignature(iSkip);
         if (s == null)
         {
            s = appendSignature();
         }
         return s;
      }

      ///   
      ///	 <summary> * gets a signature in both old and new Layouts if old: a <Signature>
      ///	 * element if new: a SignatureName partition leaf
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            the number of signatures to skip </param>
      ///	 
      public override JDFSignature getSignature(int iSkip)
      {
         return getLayoutElement(this, ElementName.SIGNATURE, AttributeName.SIGNATURENAME, iSkip);
      }

      ///   
      ///	 <summary> * gets a signature in both old and new Layouts if old: a <Signature>
      ///	 * element if new: a SignatureName partition leaf </summary>
      ///	 * <param name="signatureName"> the SignatureName partition key value(new) or Signature/@Name(old)
      ///	 *  </param>
      ///	 * <returns> the signature </returns>
      ///	 
      public virtual JDFSignature getSignature(string signatureName)
      {
         return getLayoutElement(this, ElementName.SIGNATURE, AttributeName.SIGNATURENAME, signatureName);
      }

      ///   
      ///	 <summary> * gets a signature in both old and new Layouts if old: a <Signature>creates it if it does not exist
      ///	 * element if new: a SignatureName partition leaf </summary>
      ///	 * <param name="signatureName"> the SignatureName partition key value(new) or Signature/@Name(old)
      ///	 *  </param>
      ///	 * <returns> the signature </returns>
      ///	 * <exception cref="JDFException">  </exception>
      ///	 
      public virtual JDFSignature getCreateSignature(string signatureName)
      {
         return getCreateLayoutElement(this, ElementName.SIGNATURE, AttributeName.SIGNATURENAME, signatureName);
      }

      ///   
      ///	 <summary> * get the vector of sheets in this signature
      ///	 *  </summary>
      ///	 * <returns> <seealso cref="VElement"/> the vector of signatures in this </returns>
      ///	 
      public virtual VElement getSignatureVector()
      {
         return getLayoutElementVector(this, ElementName.SIGNATURE, AttributeName.SIGNATURENAME);
      }
   }
}
