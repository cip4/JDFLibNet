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
   using System.Collections;


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using KElement = org.cip4.jdflib.core.KElement;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using IDeviceCapable = org.cip4.jdflib.ifaces.IDeviceCapable;


   public abstract class JDFTerm : JDFElement
   {

      ///   
      ///     <summary> *  </summary>
      ///     
      private new const long serialVersionUID = 6785589345368148259L;

      ///   
      ///	 <summary> * Constructor for JDFTerm
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFTerm(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFTerm
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFTerm(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFTerm
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>

      ///	 
      public JDFTerm(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      ///   
      ///	 <summary> * Evaluates the boolean expression (child Term element): checks whether it
      ///	 * fits <code>jdf</code>
      ///	 *  </summary>
      ///	 * <param name="jdf">
      ///	 *            JDFNode to test to know if the Device can accept it </param>
      ///	 * <param name="reportRoot">
      ///	 *            the report to generate; set to <code>null</code> if no report
      ///	 *            is requested </param>
      ///	 * <returns> boolean - true, if boolean expression (child Term element)
      ///	 *         evaluates to “true” </returns>
      ///	 
      public abstract bool fitsJDF(KElement jdf, KElement reportRoot); // const
      // JDFNode

      ///   
      ///	 <summary> * checks the xpath whether this term applies
      ///	 *  </summary>
      ///	 * <param name="jdf">
      ///	 *            the KElement to check </param>
      ///	 * <returns> boolean </returns>
      ///	 
      public abstract bool fitsContext(KElement jdf);

      ///   
      ///	 <summary> * Tests whether this Term is compatible with the attribute map
      ///	 * <code>m</code> (and, or, xor, not, Evaluation, TestRef).<br>
      ///	 * To determine the state of Term tests Evaluations that “not” consists of,
      ///	 * this method checks if attribute map <code>m</code> has a key. specified
      ///	 * by Evaluation/BasicPreflightTest/@Name If <code>m</code> has such key, it
      ///	 * checks whether the value of <code>m#</code> fits the testlists specified
      ///	 * for matching Evaluation (uses FitsValue(value))
      ///	 *  </summary>
      ///	 * <param name="m">
      ///	 *            key-value pair attribute map </param>
      ///	 * <returns> boolean - true, if boolean “not” expression evaluates to “true” </returns>
      ///	 
      public abstract bool fitsMap(JDFAttributeMap m);

      public sealed class EnumTerm : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         public override string ToString()
         {
            return getName();
         }

         private EnumTerm(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumTerm getEnum(string enumName)
         {
            return (EnumTerm)getEnum(typeof(EnumTerm), enumName);
         }

         public static EnumTerm getEnum(int enumValue)
         {
            return (EnumTerm)getEnum(typeof(EnumTerm), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumTerm));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumTerm));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumTerm));
         }

         ///      
         ///		 <summary> * Constants EnumActivation </summary>
         ///		 
         public static readonly EnumTerm and = new EnumTerm(ElementName.AND);
         public static readonly EnumTerm or = new EnumTerm(ElementName.OR);
         public static readonly EnumTerm not = new EnumTerm(ElementName.NOT);
         public static readonly EnumTerm xor = new EnumTerm(ElementName.XOR);
         public static readonly EnumTerm BooleanEvaluation = new EnumTerm(ElementName.BOOLEANEVALUATION);
         public static readonly EnumTerm DateTimeEvaluation = new EnumTerm(ElementName.DATETIMEEVALUATION);
         public static readonly EnumTerm DurationEvaluation = new EnumTerm(ElementName.DURATIONEVALUATION);
         public static readonly EnumTerm EnumerationEvaluation = new EnumTerm(ElementName.ENUMERATIONEVALUATION);
         public static readonly EnumTerm IntegerEvaluation = new EnumTerm(ElementName.INTEGEREVALUATION);
         public static readonly EnumTerm IsPresentEvaluation = new EnumTerm(ElementName.ISPRESENTEVALUATION);
         public static readonly EnumTerm MatrixEvaluation = new EnumTerm(ElementName.MATRIXEVALUATION);
         public static readonly EnumTerm NameEvaluation = new EnumTerm(ElementName.NAMEEVALUATION);
         public static readonly EnumTerm NumberEvaluation = new EnumTerm(ElementName.NUMBEREVALUATION);
         public static readonly EnumTerm PDDFPathEvaluation = new EnumTerm(ElementName.PDFPATHEVALUATION);
         public static readonly EnumTerm RectangleEvaluation = new EnumTerm(ElementName.RECTANGLEEVALUATION);
         public static readonly EnumTerm ShapeEvaluation = new EnumTerm(ElementName.SHAPEEVALUATION);
         public static readonly EnumTerm StringEvaluation = new EnumTerm(ElementName.STRINGEVALUATION);
         public static readonly EnumTerm XYPairEvaluation = new EnumTerm(ElementName.XYPAIREVALUATION);
         public static readonly EnumTerm TestRef = new EnumTerm(ElementName.TESTREF);
      }

      ///   
      ///	 <summary> * get the parent devicecap or messageservice
      ///	 * 
      ///	 * @return </summary>
      ///	 
      internal virtual IDeviceCapable getDeviceCapable()
      {
         IDeviceCapable deviceCap = (IDeviceCapable)getDeepParent(ElementName.DEVICECAP, 0);
         if (deviceCap != null)
            return deviceCap;
         deviceCap = (IDeviceCapable)getDeepParent(ElementName.MESSAGESERVICE, 0);
         return deviceCap;
      }
   }
}
