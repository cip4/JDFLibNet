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
 * JDFFeaturePool.cs
 * Last changes
 */

namespace org.cip4.jdflib.resource.devicecapability
{


   using JDFAutoFeaturePool = org.cip4.jdflib.auto.JDFAutoFeaturePool;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;

   /// <summary>
   /// JDFFeaturePool
   /// </summary>
   public class JDFFeaturePool : JDFAutoFeaturePool
   {
      private new const long serialVersionUID = 1L;


      /// <summary>
      /// Constructor for JDFFeaturePool
      /// </summary>
      /// <param name="myOwnerDocument"></param>
      /// <param name="qualifiedName"></param>
      public JDFFeaturePool(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }


      /// <summary>
      /// Constructor for JDFFeaturePool
      /// </summary>
      /// <param name="myOwnerDocument"></param>
      /// <param name="myNamespaceURI"></param>
      /// <param name="qualifiedName"></param>
      public JDFFeaturePool(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }


      /// <summary>
      /// Constructor for JDFFeaturePool
      /// </summary>
      /// <param name="myOwnerDocument"></param>
      /// <param name="myNamespaceURI"></param>
      /// <param name="qualifiedName"></param>
      /// <param name="myLocalName"></param>
      public JDFFeaturePool(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      /// <summary>
      /// To String
      /// </summary>
      /// <returns>string</returns>
      public override string ToString()
      {
         return "JDFFeaturePool[  --> " + base.ToString() + " ]";
      }

      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[13];
      static JDFFeaturePool()
      {
         elemInfoTable[0] = new ElemInfoTable(ElementName.BOOLEANSTATE, 0x33333333);
         elemInfoTable[1] = new ElemInfoTable(ElementName.DATETIMESTATE, 0x33333333);
         elemInfoTable[2] = new ElemInfoTable(ElementName.DURATIONSTATE, 0x33333333);
         elemInfoTable[3] = new ElemInfoTable(ElementName.ENUMERATIONSTATE, 0x33333333);
         elemInfoTable[4] = new ElemInfoTable(ElementName.INTEGERSTATE, 0x33333333);
         elemInfoTable[5] = new ElemInfoTable(ElementName.MATRIXSTATE, 0x33333333);
         elemInfoTable[6] = new ElemInfoTable(ElementName.NAMESTATE, 0x33333333);
         elemInfoTable[7] = new ElemInfoTable(ElementName.NUMBERSTATE, 0x33333333);
         elemInfoTable[8] = new ElemInfoTable(ElementName.PDFPATHSTATE, 0x33333333);
         elemInfoTable[9] = new ElemInfoTable(ElementName.RECTANGLESTATE, 0x33333333);
         elemInfoTable[10] = new ElemInfoTable(ElementName.SHAPESTATE, 0x33333333);
         elemInfoTable[11] = new ElemInfoTable(ElementName.STRINGSTATE, 0x33333333);
         elemInfoTable[12] = new ElemInfoTable(ElementName.XYPAIRSTATE, 0x33333333);
      }

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }
   }
}
