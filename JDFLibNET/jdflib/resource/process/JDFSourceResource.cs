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



//--------------------------------------------------------------------------------------------------

/*
 * Copyright (c) 2005 Heidelberger Druckmaschinen AG, All Rights Reserved.
 *
 * JDFSourceResource.cs
 *
 * Last changes
 */

namespace org.cip4.jdflib.resource.process
{
   using System.Collections;



   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFRefElement = org.cip4.jdflib.core.JDFRefElement;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;

   public class JDFSourceResource : JDFElement
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFSourceResource
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFSourceResource(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFSourceResource
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFSourceResource(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFSourceResource
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="localName"> </param>
      ///	 
      public JDFSourceResource(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
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
         return "JDFSourceResource[  --> " + base.ToString() + " ]";
      }

      public virtual JDFRefElement getRefElement()
      {
         KElement e = getFirstChildElement();
         while (true)
         {
            if (e is JDFRefElement)
               return (JDFRefElement)e;
            if (e == null)
               return null;
            e = e.getNextSiblingElement();
         }
      }

      ///   
      ///	 <summary> * gets the link of the linked route
      ///	 * 
      ///	 * @return </summary>
      ///	 
      public virtual JDFResource getLinkRoot()
      {
         JDFRefElement refElement = getRefElement();
         JDFResource r = null;
         if (refElement != null)
         {
            r = refElement.getLinkRoot(null);
         }
         return r;
      }

      ///   
      ///	 <summary> * overrides the deprecated method JDFElement.getTarget()
      ///	 *  </summary>
      ///	 * <seealso cref= org.cip4.jdflib.core.JDFElement#getTarget()
      ///	 * @return </seealso>
      ///	 
      public new JDFResource getTarget()
      {
         JDFRefElement refElement = getRefElement();
         JDFResource r = null;
         if (refElement != null)
         {
            r = refElement.getTarget();
         }
         return r;
      }

      ///   
      ///	 <summary> * return a vector of unknown element nodenames
      ///	 *  </summary>
      ///	 * <param name="boolean"> bIgnorePrivate - used by JDFElement during the validation
      ///	 *        !!! Do not change the signature of this method </param>
      ///	 * <param name="int"> nMax - maximum size of the returned vector </param>
      ///	 * <returns> Vector - vector of unknown element nodenames
      ///	 * 
      ///	 *         default: GetInvalidElements(true, 999999) </returns>
      ///	 
      ///   
      ///	 <summary> * return a vector of unknown element nodenames
      ///	 * 
      ///	 * @default getUnknownElements(bIgnorePrivate, 99999999) </summary>
      ///	 
      public override VString getUnknownElements(bool bIgnorePrivate, int nMax)
      {
         return getUnknownPoolElements(JDFElement.EnumPoolType.RefElement, nMax);
      }

      public override VString getInvalidElements(EnumValidationLevel level, bool bIgnorePrivate, int nMax)
      {
         bool bIgnorePrivateLocal = bIgnorePrivate;

         if (bIgnorePrivateLocal)
            bIgnorePrivateLocal = false; // dummy to fool compiler

         VString v = base.getInvalidElements(level, bIgnorePrivateLocal, nMax);
         if (v.Count >= nMax)
            return v;

         VElement v2 = getChildElementVector_KElement(null, null, null, true, 0);
         int n = 0;
         int size = v2.Count;
         for (int i = 0; i < size; i++)
         {
            if (v2[i] is JDFRefElement)
               n++;
         }

         if (n > 1)
         {
            for (int i = 0; i < size; i++)
            {
               if (v2[i] is JDFRefElement)
                  v.appendUnique(v2[i].LocalName);
            }
         }

         return v;
      }

      ///   
      ///	 <summary> * return the LocalName of the referenced resource
      ///	 *  </summary>
      ///	 * <returns> the LocalName of the referenced resource </returns>
      ///	 
      public virtual string getSourceLocalName()
      {
         JDFRefElement refElement = getRefElement();
         if (refElement != null)
         {
            return refElement.getRefLocalName();
         }
         return null;
      }

      ///   
      ///	 <summary> * return the NodeName of the referenced resource
      ///	 *  </summary>
      ///	 * <returns> the nodename of the referenced resource </returns>
      ///	 
      public virtual string getSourcefNodeName()
      {
         JDFRefElement refElement = getRefElement();
         if (refElement != null)
         {
            return refElement.getRefNodeName();
         }
         return null;
      }

      ///   
      ///	 <summary> * delete this sourceResource and it's target
      ///	 *  </summary>
      ///	 * <param name="bool">
      ///	 *            bCheckRefCount if true, check that no other element refers to
      ///	 *            the target before deleting<br>
      ///	 *            if bCheckRefCount=false, the target is force deleted </param>
      ///	 * <returns> JDFElement the deleted targeelement
      ///	 * @since 290620 </returns>
      ///	 
      public virtual JDFElement deleteRef(bool bCheckRefCount)
      {
         JDFRefElement refElement = getRefElement();
         if (refElement != null)
         {
            return refElement.deleteRef(bCheckRefCount);
         }
         return null;
      }

      ///   
      ///	 <summary> * get list of missing elements
      ///	 *  </summary>
      ///	 * <param name="nMax">
      ///	 *            maximum size of the returned vector </param>
      ///	 
      public override VString getMissingElements(int nMax)
      {
         VString vs = getTheElementInfo().requiredElements();
         vs = getMissingElementVector(vs, nMax);
         VElement v2 = getChildElementVector_KElement(null, null, null, true, 0);
         int n = 0;
         for (int i = 0; i < v2.Count; i++)
         {
            if (v2[i] is JDFRefElement)
               n++;
         }
         if (n == 0)
            vs.Add("RefElement");

         return vs;
      }
   }
}
