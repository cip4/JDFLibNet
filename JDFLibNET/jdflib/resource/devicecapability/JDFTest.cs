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
 * JDFTest.cs
 */

namespace org.cip4.jdflib.resource.devicecapability
{


   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using KElement = org.cip4.jdflib.core.KElement;
   using VString = org.cip4.jdflib.core.VString;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;

   public class JDFTest : JDFNodeTerm
   {
      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[2];
      static JDFTest()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ID, 0x22222222, AttributeInfo.EnumAttributeType.ID, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.CONTEXT, 0x33333333, AttributeInfo.EnumAttributeType.XPath, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }

      ///   
      ///	 <summary> * Constructor for JDFTest
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFTest(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFTest
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFTest(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFTest
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFTest(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      public override string ToString()
      {
         return " JDFTest[  --> " + base.ToString() + " ]";
      }

      ///

      ///   
      ///	 <summary> * set attribute <code>ID</code>
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            value to set the attribute to </param>
      ///	 
      public virtual void setID(string @value)
      {
         setAttribute(AttributeName.ID, @value, null);
      }

      public override string getID()
      {
         return getAttribute(AttributeName.ID, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * Evaluates the boolean expression (child Term element) if it fits the
      ///	 * attribute map 'm'
      ///	 *  </summary>
      ///	 * <param name="m">
      ///	 *            key-value pair attribute map </param>
      ///	 * <returns> boolean - true, if the boolean expression (child Term element)
      ///	 *         evaluates to “true” </returns>
      ///	 
      public override bool fitsMap(JDFAttributeMap m)
      {
         JDFTerm t = getTerm();
         return t == null ? false : t.fitsMap(m);
      }

      ///   
      ///	 <summary> * Evaluates the boolean expression (child Term element) if it fits the
      ///	 * JDFNode 'jdf' a value of true corresponds to a failed test, i.e. the test
      ///	 * describes INVALID states for the jdf
      ///	 *  </summary>
      ///	 * <param name="jdf">
      ///	 *            JDFNode to test to know if the Device can accept it </param>
      ///	 * <param name="reportRoot">
      ///	 *            the report to generate. Set to <code>null</code> if no report
      ///	 *            is requested. </param>
      ///	 * <returns> boolean - true, if boolean expression (child Term element)
      ///	 *         evaluates to “true” </returns>
      ///	 
      public override bool fitsJDF(KElement jdf, KElement reportRoot)
      {
         KElement reportRootLocal = reportRoot;

         if (reportRootLocal != null)
            reportRootLocal = reportRootLocal.appendElement("TestReport");
         JDFTerm t = getTerm();
         if (t == null)
            return true; // no term --> assume it is a non test; i.e. ok

         bool checkContext = true;
         if (hasAttribute(AttributeName.CONTEXT))
         {
            checkContext = !jdf.matchesPath(getContext(), true);
         }
         if (checkContext && !t.fitsContext(jdf))
            return true;
         bool b = t.fitsJDF(jdf, reportRootLocal);
         if (reportRootLocal != null)
            reportRootLocal.setAttribute("Value", b, null);
         return b;
      }

      ///   
      ///	 <summary> * gets the term from a test
      ///	 *  </summary>
      ///	 * <returns> JDFTerm the term that defines this test, <code>null</code> if
      ///	 *         there is no term </returns>
      ///	 
      public virtual JDFTerm getTerm()
      {
         return getTerm(null, 0);
      }

      public override bool init()
      {
         appendAnchor(null);
         return base.init();
      }

      ///   
      ///	 <summary> * getIDPrefix
      ///	 *  </summary>
      ///	 * <returns> the default ID prefix of non-overwritten JDF elements </returns>
      ///	 
      public override string getIDPrefix()
      {
         return "T";
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

      ///   
      ///	 <summary> * check whether the boolean logic defined by a Test and a test's
      ///	 * subelements makes sense in the context of the tested element jdf </summary>
      ///	 
      public override bool fitsContext(KElement testElement)
      {
         if (hasAttribute(AttributeName.CONTEXT))
         {
            return testElement.matchesPath(getContext(), true);
         }
         return base.fitsContext(testElement);
      }


      ///   
      ///	 <summary> * get attribute <code>Context</code> of this Test element
      ///	 *  </summary>
      ///	 * <returns> String - the value of the <code>Context</code> attribute of this
      ///	 *         test </returns>
      ///	 
      public virtual string getContext()
      {
         return getAttribute(AttributeName.CONTEXT, null, null);
      }


      ///   
      ///	 <summary> * set attribute <code>Context</code> of this Test element
      ///	 *  </summary>
      ///	 * <param name="context">
      ///	 *            the value of the <code>Context</code> attribute of this test </param>
      ///	 
      public virtual void setContext(string context)
      {
         setAttribute(AttributeName.CONTEXT, context);
      }
   }
}
