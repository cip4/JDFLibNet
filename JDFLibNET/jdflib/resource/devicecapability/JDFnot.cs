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





/* @author Elena Skobchenko
 *
 * JDFnot.cs
 */

namespace org.cip4.jdflib.resource.devicecapability
{
   using System;


   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;

   public class JDFnot : JDFNodeTerm
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFnot
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFnot(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFnot
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFnot(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFnot
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFnot(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      public override string ToString()
      {
         return " JDFnot[  --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * Inverts the boolean state of a Term element (and, or, xor, not,
      ///	 * Evaluation, TestRef).<br>
      ///	 * To determine the state of Term tests Evaluations that “not” consists of,
      ///	 * it checks whether attribute map 'm' has a key, specified by
      ///	 * Evaluation/BasicPreflightTest/@Name. If 'm' has such key, it checks
      ///	 * whether its value fits the testlists specified for matching the
      ///	 * Evaluation (uses FitsValue(value))
      ///	 *  </summary>
      ///	 * <param name="m">
      ///	 *            key-value pair attribute map </param>
      ///	 * <returns> boolean - true, if boolean “not” expression evaluates to “true” </returns>
      ///	 
      public override bool fitsMap(JDFAttributeMap m)
      {
         JDFTerm t = getTerm(null, 0);
         if (t == null)
            return false;
         return !t.fitsMap(m);
      }

      ///   
      ///	 <summary> * Inverts the boolean state of a Term child element (and, or, xor, not,
      ///	 * Evaluation, TestRef)
      ///	 *  </summary>
      ///	 * <param name="jdf">
      ///	 *            JDFNode we test to know if the Device can accept it </param>
      ///	 * <param name="reportRoot">
      ///	 *            the report to generate. Set to <code>null</code> if no report
      ///	 *            is requested. </param>
      ///	 * <returns> boolean - true, if boolean “not” expression evaluates to “true” </returns>
      ///	 
      public override bool fitsJDF(KElement jdf, KElement reportRoot)
      {
         KElement reportRootLocal = reportRoot;

         VElement v = getTermVector(null);
         int siz = v.Count;
         bool b = false;
         if (reportRootLocal != null)
            reportRootLocal = reportRootLocal.appendElement("not");

         int count = 0;
         for (int i = 0; i < siz; i++)
         {
            JDFTerm t = (JDFTerm)v[i];
            b = !t.fitsJDF(jdf, reportRootLocal);
            count++;
            if (reportRootLocal != null)
               reportRootLocal.setAttribute("Value", b, null);
         }

         if (reportRootLocal != null && count != 1)
            reportRootLocal.setAttribute("SyntaxWarning", "Warning: not element with more than one term, count=" + Convert.ToString(count));

         return b;
      }


      public override VString getInvalidElements(EnumValidationLevel level, bool bIgnorePrivate, int nMax)
      {
         bool bIgnorePrivateLocal = bIgnorePrivate;

         if (bIgnorePrivateLocal)
            bIgnorePrivateLocal = false; // dummy to fool compiler

         VString v = base.getInvalidElements(level, bIgnorePrivateLocal, nMax);
         if (v.Count >= nMax)
            return v;

         v.appendUnique(getInvalidTerms(1));

         return v;
      }


      public override VString getMissingElements(int nMax)
      {
         VString v = base.getMissingElements(nMax);
         if (v.Count >= nMax)
            return v;

         v.appendUnique(getMissingTerms(1));
         return v;
      }
   }
}
