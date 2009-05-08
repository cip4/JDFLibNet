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
 * JDFXYPairSpan.cs
 *
 * Last changes
 */

namespace org.cip4.jdflib.span
{
   using System;


   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFXYPairRangeList = org.cip4.jdflib.datatypes.JDFXYPairRangeList;


   ///
   /// <summary> * XYPair range class </summary>
   /// 
   public class JDFXYPairSpan : JDFSpanBase
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFXYPairSpan
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFXYPairSpan(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFXYPairSpan
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFXYPairSpan(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFXYPairSpan
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="localName"> </param>

      ///	 
      public JDFXYPairSpan(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[4];
      static JDFXYPairSpan()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ACTUAL, 0x33333333, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.PREFERRED, 0x33333333, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.RANGE, 0x33333333, AttributeInfo.EnumAttributeType.XYPairRangeList, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.OFFERRANGE, 0x33333111, AttributeInfo.EnumAttributeType.XYPairRangeList, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
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
         return "JDFXYPairSpan[ --> " + base.ToString() + " ]";
      }

      public virtual void setActual(JDFXYPair @value)
      {
         setAttribute(AttributeName.ACTUAL, @value.ToString(), null);
      }

      public virtual JDFXYPair getActual()
      {
         try
         {
            return new JDFXYPair(getAttribute(AttributeName.ACTUAL));
         }
         catch (FormatException)
         {
            throw new JDFException("JDFXYPairState.getActual: Attribute Actual is not capable to create JDFXYPair");
         }
      }

      public virtual void setPreferred(JDFXYPair @value)
      {
         setAttribute(AttributeName.PREFERRED, @value.ToString(), null);
      }

      public virtual JDFXYPair getPreferred()
      {
         try
         {
            return new JDFXYPair(getAttribute(AttributeName.PREFERRED));
         }
         catch (FormatException)
         {
            throw new JDFException("JDFXYPairState.getPreferred: Attribute Preferred is not capable to create JDFXYPair");
         }
      }

      public virtual void setRange(JDFXYPairRangeList @value)
      {
         setAttribute(AttributeName.RANGE, @value.ToString());
      }

      public virtual JDFXYPairRangeList getRange()
      {
         try
         {
            return new JDFXYPairRangeList(getAttribute(AttributeName.RANGE));
         }
         catch (FormatException)
         {
            throw new JDFException("JDFXYPairState.getRange: Attribute Range is not capable to create JDFXYPairRangeList");
         }
      }

      public override bool init()
      {
         bool b = base.init();
         setDataType(JDFSpanBase.EnumDataType.XYPairSpan);
         return b;
      }

      ///   
      ///	 <summary> * SetPreferred
      ///	 *  </summary>
      ///	 * <param name="double"> x </param>
      ///	 * <param name="double"> y </param>
      ///	 
      public virtual void setPreferred(double x, double y)
      {
         setPreferred(new JDFXYPair(x, y));
      }

      ///   
      ///	 <summary> * add an element xy to the Range attribute
      ///	 *  </summary>
      ///	 * <param name="double"> x - x value of the JDFXYPair value to add </param>
      ///	 * <param name="double"> y - y value of the JDFXYPair value to add </param>
      ///	 
      public virtual void addRange(double x, double y)
      {
         addRange(new JDFXYPair(x, y));
      }

      ///   
      ///	 <summary> * add an element xy to the Range attribute
      ///	 *  </summary>
      ///	 * <param name="double"> x1 - x value of the left JDFXYPairRange value to add </param>
      ///	 * <param name="double"> y1 - y value of the left JDFXYPairRange value to add </param>
      ///	 * <param name="double"> x2 - x value of the right JDFXYPairRange value to add </param>
      ///	 * <param name="double"> y2 - y value of the right JDFXYPairRange value to add </param>
      ///	 
      public virtual void addRange(double x1, double y1, double x2, double y2)
      {
         addRange(new JDFXYPair(x1, y1), new JDFXYPair(x2, y2));
      }

      ///   
      ///	 <summary> * add an element xy to the Range attribute as a JDFRange
      ///	 *  </summary>
      ///	 * <param name="JDFXYPair"> xy - the Range value to add </param>
      ///	 
      public virtual void addRange(JDFXYPair xy)
      {
         JDFXYPairRangeList rl = getRange();
         rl.Append(xy);
         setRange(rl);
      }

      ///   
      ///	 <summary> * add an element xy to the Range attribute as a JDFRange
      ///	 *  </summary>
      ///	 * <param name="JDFXYPair"> xy1 - left JDFXYPairRange value to add </param>
      ///	 * <param name="JDFXYPair"> xy2 - right JDFXYPairRange value to add </param>
      ///	 
      public virtual void addRange(JDFXYPair xy1, JDFXYPair xy2)
      {
         JDFXYPairRangeList rl = getRange();
         rl.Append(xy1, xy2);
         setRange(rl);
      }
   }
}
