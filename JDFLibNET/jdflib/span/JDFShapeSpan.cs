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
 * JDFShapeSpan.cs
 */

namespace org.cip4.jdflib.span
{
   using System;



   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFShape = org.cip4.jdflib.datatypes.JDFShape;
   using JDFShapeRangeList = org.cip4.jdflib.datatypes.JDFShapeRangeList;

   public class JDFShapeSpan : JDFSpanBase
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFShapeSpan
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFShapeSpan(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFShapeSpan
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFShapeSpan(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFShapeSpan
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="localName"> </param>
      ///	 
      public JDFShapeSpan(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
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
         return "JDFShapeSpan[ --> " + base.ToString() + " ]";
      }

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[4];
      static JDFShapeSpan()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ACTUAL, 0x33333333, AttributeInfo.EnumAttributeType.shape, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.PREFERRED, 0x33333333, AttributeInfo.EnumAttributeType.shape, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.RANGE, 0x33333333, AttributeInfo.EnumAttributeType.shape, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.OFFERRANGE, 0x33333111, AttributeInfo.EnumAttributeType.shape, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }

      public virtual void setActual(JDFShape @value)
      {
         setAttribute(AttributeName.ACTUAL, @value.ToString(), null);
      }

      public virtual JDFShape getActual()
      {
         try
         {
            return new JDFShape(getAttribute(AttributeName.ACTUAL));
         }
         catch (FormatException)
         {
            throw new JDFException("JDFShapeState.getActual: Attribute Actual is not capable to create JDFShape");
         }
      }

      public virtual void setPreferred(JDFShape @value)
      {
         setAttribute(AttributeName.PREFERRED, @value.ToString(), null);
      }

      public virtual JDFShape getPreferred()
      {
         try
         {
            return new JDFShape(getAttribute(AttributeName.PREFERRED));
         }
         catch (FormatException)
         {
            throw new JDFException("JDFShapeState.getPreferred: Attribute Preferred is not capable to create JDFShape");
         }
      }

      public virtual void setRange(JDFShapeRangeList @value)
      {
         setAttribute(AttributeName.RANGE, @value.ToString());
      }

      public virtual JDFShapeRangeList getRange()
      {
         try
         {
            return new JDFShapeRangeList(getAttribute(AttributeName.RANGE));
         }
         catch (FormatException)
         {
            throw new JDFException("JDFShapeState.getRange: Attribute Range is not capable to create JDFShapeRangeList");
         }
      }

      public override bool init()
      {
         bool b = base.init();
         setDataType(EnumDataType.ShapeSpan);
         return b;
      }

      ///   
      ///	 <summary> * set the Preferred attribute
      ///	 *  </summary>
      ///	 * <param name="double"> x the preferred width </param>
      ///	 * <param name="double"> y the preferred height </param>
      ///	 * <param name="double"> z the preferred depth </param>
      ///	 
      public virtual void setPreferred(double x, double y, double z)
      {
         setPreferred(new JDFShape(x, y, z));
      }

      ///   
      ///	 <summary> * add an element shape to the Range attribute as a JDFRange
      ///	 *  </summary>
      ///	 * <param name="JDFShape"> shape the Range value </param>
      ///	 
      public virtual void addRange(JDFShape shape)
      {
         JDFShapeRangeList srl = getRange();
         srl.Append(shape);
         setRange(srl);
      }

      ///   
      ///	 <summary> * add an element x y to the Range attribute as a JDFRange
      ///	 *  </summary>
      ///	 * <param name="JDFShape"> shape1 the Range value </param>
      ///	 * <param name="JDFShape"> shape2 the Range value </param>
      ///	 
      public virtual void addRange(JDFShape shape1, JDFShape shape2)
      {
         JDFShapeRangeList srl = getRange();
         srl.Append(shape1, shape2);
         setRange(srl);
      }

      ///   
      ///	 <summary> * add an element x y zto the Range attribute as a JDFRange
      ///	 *  </summary>
      ///	 * <param name="double"> x the width </param>
      ///	 * <param name="double"> y the height </param>
      ///	 * <param name="double"> z the depth </param>
      ///	 
      public virtual void addRange(double x, double y, double z)
      {
         JDFShapeRangeList srl = getRange();
         srl.Append(new JDFShape(x, y, z));
         setRange(srl);
      }

      ///   
      ///	 <summary> * add an element x1 y1 z1~ x2 y2 z2to the Range attribute as a JDFRange
      ///	 *  </summary>
      ///	 * <param name="double"> x1 the 1. width </param>
      ///	 * <param name="double"> y1 the 1. height </param>
      ///	 * <param name="double"> z1 the 1. depth </param>
      ///	 * <param name="double"> x2 the 2. width </param>
      ///	 * <param name="double"> y2 the 2. height </param>
      ///	 * <param name="double"> z2 the 2. depth </param>
      ///	 
      public virtual void addRange(double x1, double y1, double z1, double x2, double y2, double z2)
      {
         JDFShapeRangeList srl = getRange();
         srl.Append(new JDFShape(x1, y1, z1), new JDFShape(x2, y2, z2));
         setRange(srl);
      }
   }
}
