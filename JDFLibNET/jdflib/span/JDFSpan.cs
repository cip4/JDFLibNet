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
 * JDFSpan.cs
 * Last changes
 */

namespace org.cip4.jdflib.span
{
   using System;



   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFIntegerRangeList = org.cip4.jdflib.datatypes.JDFIntegerRangeList;
   using JDFNameRange = org.cip4.jdflib.datatypes.JDFNameRange;
   using JDFNameRangeList = org.cip4.jdflib.datatypes.JDFNameRangeList;
   using JDFNumberRangeList = org.cip4.jdflib.datatypes.JDFNumberRangeList;
   using JDFRangeList = org.cip4.jdflib.datatypes.JDFRangeList;


   ///
   /// * @deprecated defines the data type dependent parts of a ranged Span resource 
   /// 
   [Obsolete("defines the data type dependent parts of a ranged Span resource")]
   public abstract class JDFSpan : JDFSpanBase
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFSpan
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFSpan(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFSpan
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFSpan(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFSpan
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="localName"> </param>

      ///	 
      public JDFSpan(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      // **************************************** Interfaces
      // ******************************************
      internal interface IntegerSpan
      {
         void setRange(JDFIntegerRangeList o);
      }

      internal interface NumberSpan
      {
         void setRange(JDFNumberRangeList o);
      }

      internal interface NameSpan
      {
         void setRange(JDFNameRangeList o);
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
         return "JDFSpan[ --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * SetPreferred
      ///	 *  </summary>
      ///	 * <param name="Object"> o </param>
      ///	 
      public virtual void setPreferred(object o)
      {
         setAttribute(AttributeName.PREFERRED, o.ToString(), JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * SetPreferred
      ///	 *  </summary>
      ///	 * <param name="double"> o </param>
      ///	 
      public virtual void setPreferred(double o)
      {
         setAttribute(AttributeName.PREFERRED, JDFConstants.EMPTYSTRING + o, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * SetPreferred
      ///	 *  </summary>
      ///	 * <param name="boolean"> o </param>
      ///	 
      public virtual void setPreferred(bool o)
      {
         setAttribute(AttributeName.PREFERRED, JDFConstants.EMPTYSTRING + o, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * SetPreferred
      ///	 *  </summary>
      ///	 * <param name="String"> o </param>
      ///	 
      public virtual void setPreferred(string o)
      {
         setAttribute(AttributeName.PREFERRED, o, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * SetActual
      ///	 *  </summary>
      ///	 * <param name="Object"> o </param>
      ///	 
      public virtual void setActual(object o)
      {
         setAttribute(AttributeName.ACTUAL, o.ToString(), JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * SetActual
      ///	 *  </summary>
      ///	 * <param name="int"> o </param>
      ///	 
      public virtual void setActual(int o)
      {
         setAttribute(AttributeName.ACTUAL, JDFConstants.EMPTYSTRING + o, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * SetActual
      ///	 *  </summary>
      ///	 * <param name="double"> o </param>
      ///	 
      public virtual void setActual(double o)
      {
         setAttribute(AttributeName.ACTUAL, JDFConstants.EMPTYSTRING + o, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * SetActual
      ///	 *  </summary>
      ///	 * <param name="boolean"> o </param>
      ///	 
      public virtual void setActual(bool o)
      {
         setAttribute(AttributeName.ACTUAL, JDFConstants.EMPTYSTRING + o, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * SetActual
      ///	 *  </summary>
      ///	 * <param name="String"> o </param>
      ///	 
      public virtual void setActual(string o)
      {
         setAttribute(AttributeName.ACTUAL, o, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * SetRange
      ///	 *  </summary>
      ///	 * <param name="String"> rs </param>
      ///	 
      public virtual void setRange(string rs)
      {
         setAttribute(AttributeName.RANGE, rs, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * SetRange
      ///	 *  </summary>
      ///	 * <param name="JDFRangeList"> rl </param>
      ///	 * @deprecated use specialized routines 
      ///	 
      [Obsolete("use specialized routines")]
      public virtual void setRange(JDFRangeList rl)
      {
         setAttribute("Range", rl.ToString(), JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * GetPreferred
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public virtual string getPreferred()
      {
         return getAttribute(AttributeName.PREFERRED, JDFConstants.EMPTYSTRING, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * GetActual
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public virtual string getActual()
      {
         return getAttribute(AttributeName.ACTUAL, JDFConstants.EMPTYSTRING, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * GetRange
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public virtual string getRange()
      {
         return getAttribute(AttributeName.RANGE, JDFConstants.EMPTYSTRING, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * AddRange
      ///	 *  </summary>
      ///	 * <param name="Object"> xMin </param>
      ///	 * <param name="Object"> xMax default is both values are equal </param>
      ///	 
      public virtual void addRange(string xMin, string xMax)
      {
         try
         {
            JDFNameRangeList rl = new JDFNameRangeList(getRange());
            rl.Append(new JDFNameRange(xMin, xMax));
            setAttribute(AttributeName.RANGE, rl.ToString(), JDFConstants.EMPTYSTRING);
         }
         catch (FormatException)
         {
            new JDFException("JDFSpan.addRange: DataFormatExceptione while creating JDFNameRange");
         }
      }
   }
}
