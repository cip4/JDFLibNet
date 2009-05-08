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
 * JDFSurface.cs
 *
 * Last changes
 *
 * 2002-07-02 JG - added virtual ConsistentPartIDKeys()
 */


namespace org.cip4.jdflib.resource.process
{
   using System.Xml;

   using EnumSide = org.cip4.jdflib.auto.JDFAutoPart.EnumSide;
   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using IPlacedObject = org.cip4.jdflib.ifaces.IPlacedObject;
   using JDFSheet = org.cip4.jdflib.resource.process.postpress.JDFSheet;

   public class JDFSurface : JDFSheet
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFSurface
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFSurface(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFSurface
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFSurface(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFSurface
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="localName"> </param>
      ///	 
      public JDFSurface(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[2];
      static JDFSurface()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.SIDE, 0x44444333, AttributeInfo.EnumAttributeType.enumeration, EnumSide.getEnum(0), null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.SURFACECONTENTSBOX, 0x44444333, AttributeInfo.EnumAttributeType.rectangle, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         AttributeInfo ai = base.getTheAttributeInfo();
         if (LocalName.Equals(ElementName.SURFACE))
            ai.updateReplace(atrInfoTable);
         return ai;
      }

      public override string ToString()
      {
         return "JDFSurface[  --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * Get the placed object (Content or Mark)
      ///	 *  </summary>
      ///	 * <param name="int"> iSkip number of objects to skip </param>
      ///	 * <returns> JDFElement the placed object </returns>
      ///	 
      ///   
      ///	 <summary> * gets the vector of all placed objects that reside directly in this
      ///	 * partition retains the order of marks and content
      ///	 *  </summary>
      ///	 * <returns> the placedobject, null if none were found </returns>
      ///	 
      public virtual IPlacedObject getPlacedObject(int nSkip)
      {
         int nSkipLocal = nSkip;

         if (nSkipLocal < 0)
         {
            VElement v = getPlacedObjectVector();
            if (v == null)
               return null;

            nSkipLocal = nSkipLocal + v.Count;
            if (nSkipLocal < 0)
               return null;

            return (IPlacedObject)v[nSkipLocal];
         }

         int nFound = 0;
         XmlNode n = FirstChild;
         while (n != null)
         {
            if (n is IPlacedObject)
            {
               if (nFound >= nSkipLocal)
                  return (IPlacedObject)n;

               nFound++;
            }

            n = n.NextSibling;
         }

         return null;
      }

      ///   
      ///	 <summary> * gets the vector of all placed objects that reside directly in this
      ///	 * partition retains the order of marks and content
      ///	 *  </summary>
      ///	 * <returns> the vector of placedobjects, null if none were found </returns>
      ///	 
      public virtual VElement getPlacedObjectVector()
      {
         VElement v = new VElement();
         XmlNode n = FirstChild;
         while (n != null)
         {
            if (n is IPlacedObject)
            {
               v.Add((KElement)n);
            }
            n = n.NextSibling;
         }
         return v.Count == 0 ? null : v;
      }
   }
}
