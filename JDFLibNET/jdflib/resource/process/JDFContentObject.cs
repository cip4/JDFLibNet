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
 * JDFContentObject.cs
 *
 * Last changes
 *
 * 2002-07-02 JG init() removed SetType()
 */

namespace org.cip4.jdflib.resource.process
{


   using JDFAutoContentObject = org.cip4.jdflib.auto.JDFAutoContentObject;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using IPlacedObject = org.cip4.jdflib.ifaces.IPlacedObject;

   public class JDFContentObject : JDFAutoContentObject, IPlacedObject
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFContentObject
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFContentObject(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFContentObject
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFContentObject(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFContentObject
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="localName"> </param>
      ///	 
      public JDFContentObject(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
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
         return "JDFContentObject[  --> " + base.ToString() + " ]";
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.ifaces.IPlacedObject#setTrimCTM(double, double)
      //	 
      public virtual void setTrimSize(double x, double y)
      {
         setTrimSize(new JDFXYPair(x, y));
      }

      ///   
      ///	 <summary> * calculates a "real" ord value in an automated layout
      ///	 *  </summary>
      ///	 * <param name="ord">
      ///	 *            the Value of Ord in the layout </param>
      ///	 * <param name="nPages">
      ///	 *            the total number of pages that are consumed by the Layout, if
      ///	 *            frontOffset!=0 the pages before frontOffset are NOT counted </param>
      ///	 * <param name="loop">
      ///	 *            which sheet loop are we on? </param>
      ///	 * <param name="maxOrdFront">
      ///	 *            number of pages consumed from the front of the list </param>
      ///	 * <param name="maxOrdBack">
      ///	 *            positive number of pages consumed from the back of the list </param>
      ///	 * <param name="frontOffset">
      ///	 *            page number of the first page to be placed on ord 0 in loop 0 </param>
      ///	 * <returns> the pge to assign in this Ord, -1 if no page fits </returns>
      ///	 
      public static int calcOrd(int ord, int nPages, int loop, int maxOrdFront, int maxOrdBack, int frontOffset)
      {
         int maxOrd = maxOrdFront + maxOrdBack;
         if (maxOrd * loop >= nPages)
            return -1; // we are in a loop that has no remaining pages
         int page;
         if (ord >= 0) // count from front
         {
            page = ord + loop * maxOrdFront;
         }
         else
         {
            int end = nPages + maxOrd - 1 - ((nPages + maxOrd - 1) % maxOrd); // the
            // page
            // to
            // put
            // on
            // -
            // 1
            page = end - loop * maxOrdBack + ord;
         }
         return page < nPages ? page + frontOffset : -1; // if a page evaluates
         // to e.g. 10 and we
         // only have 9 pages,
         // ciao
      }
   }
}
