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



namespace org.cip4.jdflib.resource.devicecapability
{
   using System;
   using System.Xml;


   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;

   ///
   /// <summary> * 
   /// * class to collect getters and setters for term intermediate nodes
   /// * 
   /// * @author prosirai
   /// *  </summary>
   /// 
   public abstract class JDFNodeTerm : JDFTerm
   {
      private new const long serialVersionUID = -4750863965825892402L;

      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[19];
      static JDFNodeTerm()
      {
         elemInfoTable[0] = new ElemInfoTable(ElementName.AND, 0x33333311);
         elemInfoTable[1] = new ElemInfoTable(ElementName.NOT, 0x33333311);
         elemInfoTable[2] = new ElemInfoTable(ElementName.OR, 0x33333311);
         elemInfoTable[3] = new ElemInfoTable(ElementName.XOR, 0x33333311);
         elemInfoTable[4] = new ElemInfoTable(ElementName.BOOLEANEVALUATION, 0x33333311);
         elemInfoTable[5] = new ElemInfoTable(ElementName.DATETIMEEVALUATION, 0x33333311);
         elemInfoTable[6] = new ElemInfoTable(ElementName.DURATIONEVALUATION, 0x33333311);
         elemInfoTable[7] = new ElemInfoTable(ElementName.ENUMERATIONEVALUATION, 0x33333311);
         elemInfoTable[8] = new ElemInfoTable(ElementName.INTEGEREVALUATION, 0x33333311);
         elemInfoTable[9] = new ElemInfoTable(ElementName.ISPRESENTEVALUATION, 0x33333311);
         elemInfoTable[10] = new ElemInfoTable(ElementName.MATRIXEVALUATION, 0x33333311);
         elemInfoTable[11] = new ElemInfoTable(ElementName.NAMEEVALUATION, 0x33333311);
         elemInfoTable[12] = new ElemInfoTable(ElementName.NUMBEREVALUATION, 0x33333311);
         elemInfoTable[13] = new ElemInfoTable(ElementName.PDFPATHEVALUATION, 0x33333311);
         elemInfoTable[14] = new ElemInfoTable(ElementName.RECTANGLEEVALUATION, 0x33333311);
         elemInfoTable[15] = new ElemInfoTable(ElementName.SHAPEEVALUATION, 0x33333311);
         elemInfoTable[16] = new ElemInfoTable(ElementName.STRINGEVALUATION, 0x33333311);
         elemInfoTable[17] = new ElemInfoTable(ElementName.XYPAIREVALUATION, 0x33333311);
         elemInfoTable[18] = new ElemInfoTable(ElementName.TESTREF, 0x33333311);
      }

      protected internal override ElementInfo getTheElementInfo()
      {
         return new ElementInfo(base.getTheElementInfo(), elemInfoTable);
      }

      public JDFNodeTerm(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      public JDFNodeTerm(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      public JDFNodeTerm(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      ///   
      ///	 <summary> * get the iSkip'th Term of type term, do not create it if it does not exist
      ///	 *  </summary>
      ///	 * <param name="term">
      ///	 *            type of term to append </param>
      ///	 * <param name="iSkip">
      ///	 *            number of terms to skip, 0 is the first </param>
      ///	 * <returns> JDFTerm - the requested term, <code>null</code> if none exists </returns>
      ///	 
      public virtual JDFTerm getTerm(EnumTerm term, int iSkip)
      {
         if (term != null)
         {
            return (JDFTerm)getElement(term.getName(), null, iSkip);
         }
         XmlNode e = FirstChild;
         int n = 0;
         while (e != null)
         {
            if (e is JDFTerm)
            {
               if (++n > iSkip)
                  return (JDFTerm)e;
            }
            e = e.NextSibling;
         }
         return null;

      }

      ///   
      ///	 <summary> * get the iSkip'th Term of type <code>term</code>, create it if it does not
      ///	 * exist
      ///	 *  </summary>
      ///	 * <param name="term">
      ///	 *            type of term to append </param>
      ///	 * <param name="iSkip">
      ///	 *            number of terms to skip, 0 is the first </param>
      ///	 * <returns> JDFTerm - the requested term </returns>
      ///	 
      public virtual JDFTerm getCreateTerm(EnumTerm term, int iSkip)
      {
         return (JDFTerm)getCreateElement(term.getName(), null, iSkip);
      }

      ///   
      ///	 <summary> * append a Term as defined by <code>term</code>
      ///	 *  </summary>
      ///	 * <param name="term">
      ///	 *            type of term to append </param>
      ///	 * <returns> JDFTerm the appended term </returns>
      ///	 
      public virtual JDFTerm appendTerm(EnumTerm term)
      {
         return (JDFTerm)appendElement(term.getName(), null);
      }

      ///   
      ///	 <summary> * check whether the boolean logic defined by a Test and a test's
      ///	 * subelements make sense in the context of the tested element jdf </summary>
      ///	 
      public override bool fitsContext(KElement testElement)
      {
         // we only want the leaves as of now
         if (testElement is JDFResource)
         {
            JDFResource r = (JDFResource)testElement;
            if (!r.isLeaf())
               return false;
         }
         VElement v = getTermVector(null);
         int siz = v.Count;
         for (int i = 0; i < siz; i++)
         {
            JDFTerm t = (JDFTerm)v[i];
            if (!t.fitsContext(testElement)) // one bad context spoils the
               // barrell
               return false;
         }
         return siz > 0; // if no subelements, then no context
      }

      ///   
      ///	 <summary> * gets a vector of all terms
      ///	 *  </summary>
      ///	 * @deprecated use getTermVector(null)
      ///	 * @return 
      ///	 
      [Obsolete("use getTermVector(null)")]
      public virtual VElement getTermVector()
      {
         return getTermVector(null);
      }

      ///   
      ///	 <summary> * gets a vector of all terms
      ///	 *  </summary>
      ///	 * <returns> VElement - vector of JDFTerm </returns>
      ///	 
      public virtual VElement getTermVector(EnumTerm term)
      {
         if (term != null)
         {
            return getChildElementVector(term.getName(), null, null, true, 0, false);
         }

         VElement v = new VElement();
         KElement e = getFirstChildElement();
         while (e != null)
         {
            if (e is JDFTerm)
            {
               v.Add(e);
            }
            e = e.getNextSiblingElement();
         }
         return v; // if no subelements, then no context
      }

      ///   
      ///	 <summary> * gets the iSkip'th term
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            the number of terms tos skip </param>
      ///	 * <returns> JDFTerm - the iSkip'th Term
      ///	 * @deprecated </returns>
      ///	 
      [Obsolete]
      public virtual JDFTerm getTerm(int iSkip)
      {
         return getTerm(null, iSkip);
      }


      protected internal virtual VString getInvalidTerms(int iMax)
      {
         VElement v = getTermVector(null);
         int vSize = v.Count;
         VString v2 = new VString();
         if (vSize > iMax) // no more than iMax
         {
            for (int i = 0; i < vSize; i++)
            {
               string strName = v.item(i).LocalName;
               v2.appendUnique(strName);
            }
         }
         return v2;
      }


      protected internal virtual VString getMissingTerms(int iMin)
      {
         VElement v = getTermVector(null);
         VString v2 = null;
         if (v.Count < iMin)
         {
            v2 = new VString();
            v2.Add("Term");
         }
         return v2;
      }
   }
}
