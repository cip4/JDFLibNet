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



/*
 * Copyright (c) 2001 Heidelberger Druckmaschinen AG, All Rights Reserved.
 *
 * JDFComponent.cs
 *
 * Last changes
 */

namespace org.cip4.jdflib.resource.process
{
   using System.Collections.Generic;


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   using JDFAutoComponent = org.cip4.jdflib.auto.JDFAutoComponent;
   using EnumMediaType = org.cip4.jdflib.auto.JDFAutoMedia.EnumMediaType;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFRefElement = org.cip4.jdflib.core.JDFRefElement;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using JDFShape = org.cip4.jdflib.datatypes.JDFShape;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;


   public class JDFComponent : JDFAutoComponent
   {
      private new const long serialVersionUID = 1L;


      /// <summary>
      /// Constructor for JDFComponent
      /// </summary>
      /// <param name="myOwnerDocument"></param>
      /// <param name="qualifiedName"></param>
      public JDFComponent(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }


      /// <summary>
      /// Constructor for JDFComponent
      /// </summary>
      /// <param name="myOwnerDocument"></param>
      /// <param name="myNamespaceURI"></param>
      /// <param name="qualifiedName"></param>
      public JDFComponent(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }


      /// <summary>
      /// Constructor for JDFComponent
      /// </summary>
      /// <param name="myOwnerDocument"></param>
      /// <param name="myNamespaceURI"></param>
      /// <param name="qualifiedName"></param>
      /// <param name="myLocalName"></param>
      public JDFComponent(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      // **************************************** Methods
      // *********************************************

      /// <summary>
      /// ToString
      /// </summary>
      /// <returns>string</returns>
      public override string ToString()
      {
         return "JDFComponent[  --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * version fixing routine for JDF
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
         if (version != null)
         {
            if (version.getValue() >= EnumVersion.Version_1_3.getValue())
            {
               if (hasAttribute(AttributeName.SOURCESHEET))
               {
                  string sourceSheet = getSourceSheet();

                  JDFRefElement layoutRef = (JDFRefElement)getElement_KElement("LayoutRef", null, 0);
                  if (layoutRef != null)
                  {
                     JDFLayout lo = (JDFLayout)layoutRef.getLinkRoot(layoutRef.getrRef());
                     if (lo != null)
                        lo.fixVersion(version);

                     layoutRef.setPartMap(new JDFAttributeMap(AttributeName.SHEETNAME, sourceSheet));
                     lo = (JDFLayout)layoutRef.getTarget();
                     layoutRef.setPartMap(lo.getPartMap());
                  }
                  removeAttribute(AttributeName.SOURCESHEET);
               }
            }
            else
            {
               JDFLayout layout = getLayout();
               if (layout != null)
               {
                  string sourcesheet = layout.getSheetName();
                  setSourceSheet(sourcesheet);
                  JDFRefElement layoutRef = (JDFRefElement)getElement_KElement("LayoutRef", null, 0);
                  // JDF 1.2 layout should be unpartitioned
                  if (layoutRef != null)
                  {
                     // JDF 1.2 layout should be unpartitioned
                     layoutRef.removeChild(ElementName.PART, null, 0);
                  }
               }
            }
         }
         return base.fixVersion(version) && bRet;
      }

      ///   
      ///	 <summary> * sets the Dimension to X Y 0 convenience method to copy media dimension to
      ///	 * component
      ///	 *  </summary>
      ///	 * <param name="dimension"> </param>
      ///	 
      public virtual void setDimensions(JDFXYPair dimension)
      {
         if (dimension != null)
         {
            JDFShape s = new JDFShape(dimension.X, dimension.Y);
            base.setDimensions(s);
         }
      }

      public virtual void setComponentType(EnumComponentType partialFinal, EnumComponentType sheetWebProof)
      {
         List<ValuedEnum> v = new List<ValuedEnum>();
         if (partialFinal != null)
            v.Add(partialFinal);
         if (sheetWebProof != null)
            v.Add(sheetWebProof);
         if (v.Count == 0)
            v = null;
         setComponentType(v);
      }

      ///   
      ///	 <summary> * get the media that is associated with this component, either directly or in the layout </summary>
      ///	 * <returns> the media, null if none there  </returns>
      ///	 
      public virtual JDFMedia getMedia()
      {
         JDFMedia m = (JDFMedia)getElement(ElementName.MEDIA);
         if (m != null)
            return m;
         JDFLayout lo = getLayout();
         if (lo == null)
            return null;
         lo = (JDFLayout)lo.getPartition(getPartMap(), EnumPartUsage.Implicit);
         m = lo.getMedia(EnumMediaType.Paper);
         if (m == null)
            m = lo.getMedia(0);
         return m;
      }
   }
}
