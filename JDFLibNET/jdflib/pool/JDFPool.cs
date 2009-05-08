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
 * THIS SOFTWARE IS PROVIDED ``AS IS'' AND ANY EXPRESSED OR IMPLIED
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
 * JDFPool.cs
 * Last changes
 * 02-07-2002  JG - remove GetPoolChildName, AddPoolElement
 * 02-07-2002  JG - remove         AddResID, GetHRefs GetvHRefRes
 */

namespace org.cip4.jdflib.pool
{


   using JDFComment = org.cip4.jdflib.core.JDFComment;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;

   ///
   /// <summary> * This class represents a JDF-Pool which provides functionality for "network" containers and is the base class for
   /// * JDFResourcePool and GarStepNetwork </summary>
   /// 
   public abstract class JDFPool : JDFElement
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFPool
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFPool(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFPool
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFPool(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFPool
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFPool(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
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
         return "JDFPool[ --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * Gets all children with the attributes <code>name, mAttrib, nameSpaceURI</code> from the pool
      ///	 * <p>
      ///	 * default: GetPoolChildrenGeneric (JDFConstants.EMPTYSTRING, new JDFAttributeMap(), JDFConstants.EMPTYSTRING)
      ///	 *  </summary>
      ///	 * <param name="name"> name of the Child </param>
      ///	 * <param name="mAttrib"> the attribute to search for </param>
      ///	 * <param name="nameSpaceURI"> nameSpaceURI to search in </param>
      ///	 * <returns> VElement: a vector with all elements in the pool matching the conditions </returns>
      ///	 
      protected internal virtual VElement getPoolChildrenGeneric(string strName, JDFAttributeMap mAttrib, string nameSpaceURI)
      {
         VElement v = getChildElementVector(strName, nameSpaceURI, mAttrib, true, 0, false);
         for (int i = v.Count - 1; i >= 0; i--)
         {
            if (v[i] is JDFComment)
            {
               v.RemoveAt(i);
            }
         }
         return v;
      }

      ///   
      ///	 <summary> * get a child from the pool matching the parameters
      ///	 *  </summary>
      ///	 * <param name="i"> the index of the child, or -1 to make a new one. </param>
      ///	 * <param name="name"> the name of the element </param>
      ///	 * <param name="mAttrib"> the attribute of the element </param>
      ///	 * <param name="nameSpaceURI"> the namespace to search in </param>
      ///	 * <returns> JDFElement: the pool child matching the above conditions
      ///	 * 
      ///	 *         default: GetPoolChildGeneric (i, JDFConstants.EMPTYSTRING, null, JDFConstants.EMPTYSTRING) </returns>
      ///	 
      protected internal virtual JDFElement getPoolChildGeneric(int i, string strName, JDFAttributeMap mAttrib, string nameSpaceURI)
      {
         int iLocal = i;

         VElement v = getPoolChildrenGeneric(strName, mAttrib, nameSpaceURI);
         if (iLocal < 0)
         {
            iLocal = v.Count + iLocal;
            if (iLocal < 0)
            {
               return null;
            }
         }
         if (v.Count <= iLocal)
         {
            return null;
         }
         return (JDFElement)v[iLocal];
      }

      ///   
      ///	 <summary> * Append a new child if no identical child exists
      ///	 *  </summary>
      ///	 * <param name="p"> the Child to add to the element </param>
      ///	 
      protected internal virtual void appendUniqueGeneric(JDFElement p)
      {
         if (!((getPoolChildrenGeneric(null, null, null).index(p) >= 0)))
         {
            copyElement(p, null);
         }
      }

      ///   
      ///	 <summary> * Append all children of p for which no identical child exists
      ///	 *  </summary>
      ///	 * <param name="p"> the Child to add to the element </param>
      ///	 
      protected internal virtual void appendUniqueGeneric(JDFPool p)
      {
         VElement vp = p.getPoolChildrenGeneric(null, null, null);

         VElement v = getPoolChildrenGeneric(null, null, null);
         for (int i = 0; i < vp.Count; i++)
         {
            if (!v.containsElement(vp[i]))
            {
               copyElement(vp[i], null);
            }
         }
      }
   }
}
