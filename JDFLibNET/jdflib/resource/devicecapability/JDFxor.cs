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
 * JDFxor.cs
 */

namespace org.cip4.jdflib.resource.devicecapability
{


   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;

   public class JDFxor : JDFNodeTerm
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFxor
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFxor(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFxor
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFxor(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFxor
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFxor(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      public override string ToString()
      {
         return " JDFxor[  --> " + base.ToString() + " ]";
      }

      public virtual JDFBooleanEvaluation getBooleanEvaluation(int iSkip)
      {
         JDFBooleanEvaluation e = (JDFBooleanEvaluation)getElement(ElementName.BOOLEANEVALUATION, JDFConstants.EMPTYSTRING, iSkip);
         return e;
      }

      ///   
      ///	 <summary> * Evaluates two or more Term elements (and, or, xor, not, Evaluation,
      ///	 * TestRef) to determine if, as a set, they evaluate to �true� when combined
      ///	 * in a boolean �xor� function. ! For more than two arguments, exactly one
      ///	 * Term must evaluate to �true� for the �xor� to evaluate to �true�.<br>
      ///	 * 
      ///	 * Looks for Evaluations that �xor� consists of, and tests the status of
      ///	 * every Evaluation, until the result of a whole boolean expression is
      ///	 * determinated. Tests whether attribute map 'm' has a key specified by
      ///	 * Evaluation/BasicPreflightTest/@Name. If 'm' has such key, checks if its
      ///	 * value fits the testlists, specified for matching Evaluation (uses
      ///	 * FitsValue(value))
      ///	 *  </summary>
      ///	 * <param name="m">
      ///	 *            key-value pair attribute map </param>
      ///	 * <returns> boolean - true, if boolean �xor� expression evaluates to �true� </returns>
      ///	 
      public override bool fitsMap(JDFAttributeMap m)
      {
         VElement v = getChildElementVector(null, null, null, true, 0, false);
         int siz = v.Count;
         int count = 0;
         for (int i = 0; i < siz; i++)
         {
            JDFTerm t = (JDFTerm)v[i];
            if (t.fitsMap(m))
               count++;
            if (count > 1)
               return false;
         }

         return (count == 1);
      }

      ///   
      ///	 <summary> * Evaluates two or more Term elements (and, or, xor, not, Evaluation,
      ///	 * TestRef) to determine if, as a set, they evaluate to �true� when combined
      ///	 * in a boolean �xor� function.
      ///	 *  </summary>
      ///	 * <param name="jdf">
      ///	 *            JDFNode to test to know if the Device can accept it </param>
      ///	 * <param name="reportRoot">
      ///	 *            the report to generate; set to <code>null</code> if no report
      ///	 *            is requested </param>
      ///	 * <returns> boolean - true, if boolean �xor� expression evaluates to �true� </returns>
      ///	 
      public override bool fitsJDF(KElement jdf, KElement reportRoot)
      {
         KElement reportRootLocal = reportRoot;

         VElement v = getTermVector(null);
         if (reportRootLocal != null)
            reportRootLocal = reportRootLocal.appendElement("xor");

         int siz = v.Count;

         int count = 0;
         for (int i = 0; i < siz; i++)
         {
            JDFTerm t = (JDFTerm)v[i];
            if (t.fitsJDF(jdf, reportRootLocal))
               count++;

            if (count > 1 && reportRootLocal == null)
               break;
         }

         bool b = (count == 1);
         if (reportRootLocal != null)
            reportRootLocal.setAttribute("Value", b, null);

         return b;
      }


      public override VString getMissingElements(int nMax)
      {
         VString v = base.getMissingElements(nMax);
         if (v.Count >= nMax)
            return v;

         v.appendUnique(getMissingTerms(2));
         return v;
      }
   }
}
