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



namespace org.cip4.jdflib.resource.intent
{


   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using JDFComment = org.cip4.jdflib.core.JDFComment;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFDurationSpan = org.cip4.jdflib.span.JDFDurationSpan;
   using JDFEnumerationSpan = org.cip4.jdflib.span.JDFEnumerationSpan;
   using JDFIntegerSpan = org.cip4.jdflib.span.JDFIntegerSpan;
   using JDFNameSpan = org.cip4.jdflib.span.JDFNameSpan;
   using JDFNumberSpan = org.cip4.jdflib.span.JDFNumberSpan;
   using JDFOptionSpan = org.cip4.jdflib.span.JDFOptionSpan;
   using JDFShapeSpan = org.cip4.jdflib.span.JDFShapeSpan;
   using JDFSpanBase = org.cip4.jdflib.span.JDFSpanBase;
   using JDFStringSpan = org.cip4.jdflib.span.JDFStringSpan;
   using JDFTimeSpan = org.cip4.jdflib.span.JDFTimeSpan;
   using JDFXYPairSpan = org.cip4.jdflib.span.JDFXYPairSpan;
   using EnumDataType = org.cip4.jdflib.span.JDFSpanBase.EnumDataType;


   public class JDFIntentResource : JDFResource
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFIntentResource
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFIntentResource(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFIntentResource
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFIntentResource(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFIntentResource
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="localName"> </param>

      ///	 
      public JDFIntentResource(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      public override string ToString()
      {
         return "JDFInsertingIntent[  --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * set all actual values to the preset defined in preferred
      ///	 *  </summary>
      ///	 * <returns> number of elements modified </returns>
      ///	 
      public virtual int preferredToActual()
      {
         return this.preferredToActual(null);
      }

      ///   
      ///	 <summary> * set actual values to the preset defined in preferred
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            key the key of the span resource to modify, if null do all </param>
      ///	 * <returns> number of elements modified </returns>
      ///	 
      public virtual int preferredToActual(string key)
      {
         int nDone = 0;
         if (!isLeaf())
         {
            VElement leaves = getLeaves(false);
            for (int i = 0; i < leaves.Count; i++)
            {
               JDFIntentResource ri = (JDFIntentResource)leaves[i];
               nDone += ri.preferredToActual(key);
            }
            return nDone;
         }
         VString vKeys = new VString();
         if (KElement.isWildCard(key))
         {
            VElement v = getChildrenByTagName(null, null, new JDFAttributeMap(AttributeName.DATATYPE, (string)null), true, true, 0);
            for (int i = 0; i < v.Count; i++)
            {
               vKeys.Add(v[i].Name);
            }
         }
         else
         {
            vKeys.Add(key);
         }
         for (int i = 0; i < vKeys.Count; i++)
         {
            JDFSpanBase @base = (JDFSpanBase)getElement(vKeys[i], JDFConstants.EMPTYSTRING, 0);
            if (@base.preferredToActual())
            {
               nDone++;
            }
         }
         return nDone;
      }

      ///   
      ///	 <summary> * get a list of all span resources
      ///	 *  </summary>
      ///	 * <returns> VElement all Span elements of this </returns>
      ///	 
      public virtual VElement getSpans()
      {
         VElement v = getChildElementVector(null, null, null, true, 0, false);

         for (int i = v.Count - 1; i >= 0; i--)
         {
            JDFElement e = (JDFElement)v[i];
            if (e is JDFComment)
            {
               v.RemoveAt(i);
            }
         }
         return v;
      }

      ///   
      ///	 <summary> * Typesafe attribute validation of Class
      ///	 *  </summary>
      ///	 * <returns> true if class is valid </returns>
      ///	 
      public override EnumResourceClass getValidClass()
      {
         return JDFResource.EnumResourceClass.Intent;
      }

      ///   
      ///	 <summary> * default initialization
      ///	 *  </summary>
      ///	 * <returns> true if successful </returns>
      ///	 
      public override bool init()
      {
         bool b = base.init();
         this.setResourceClass(EnumResourceClass.Intent);
         return b;
      }

      ///   
      ///	 <summary> * get a number span
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            strName name of the span element </param>
      ///	 * <param name="bool">
      ///	 *            bCreate if true create a new JDFNumberSpan if it does not yet
      ///	 *            exist </param>
      ///	 * <returns> JDFNumberSpan the JDFNumberSpan </returns>
      ///	 
      public virtual JDFNumberSpan getCreateNumberSpan(string strName)
      {
         return (JDFNumberSpan)getCreateSpan(strName, JDFSpanBase.EnumDataType.NumberSpan);
      }

      ///   
      ///	 <summary> * get an option (boolean) span
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            strName name of the span element </param>
      ///	 * <param name="bool">
      ///	 *            bCreate if true create a new JDFNumberSpan if it does not yet
      ///	 *            exist </param>
      ///	 * <returns> JDFOptionSpan the JDFOptionSpan </returns>
      ///	 
      public virtual JDFOptionSpan getCreateOptionSpan(string strName)
      {
         return (JDFOptionSpan)getCreateSpan(strName, JDFSpanBase.EnumDataType.OptionSpan);
      }

      ///   
      ///	 <summary> * get an integer span
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            strName name of the span element </param>
      ///	 * <param name="bool">
      ///	 *            bCreate if true create a new JDFNumberSpan if it does not yet
      ///	 *            exist </param>
      ///	 * <returns> JDFIntegerSpan the JDFIntegerSpan </returns>
      ///	 
      public virtual JDFIntegerSpan getCreateIntegerSpan(string strName)
      {
         return (JDFIntegerSpan)getCreateSpan(strName, JDFSpanBase.EnumDataType.IntegerSpan);
      }

      ///   
      ///	 <summary> * get a namespan
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            strName name of the span element </param>
      ///	 * <param name="bool">
      ///	 *            bCreate if true create a new JDFNumberSpan if it does not yet
      ///	 *            exist </param>
      ///	 * <returns> JDFNameSpan the JDFNameSpan </returns>
      ///	 
      public virtual JDFNameSpan getCreateNameSpan(string strName)
      {
         return (JDFNameSpan)getCreateSpan(strName, JDFSpanBase.EnumDataType.NameSpan);
      }

      ///   
      ///	 <summary> * get an Enumeration span
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            strName name of the span element </param>
      ///	 * <param name="bool">
      ///	 *            bCreate if true create a new JDFNumberSpan if it does not yet
      ///	 *            exist </param>
      ///	 * <returns> JDFEnumerationSpan the JDFEnumerationSpan </returns>
      ///	 
      public virtual JDFEnumerationSpan getCreateEnumerationSpan(string strName)
      {
         return (JDFEnumerationSpan)getCreateSpan(strName, JDFSpanBase.EnumDataType.EnumerationSpan);
      }

      ///   
      ///	 <summary> * get a string span
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            strName name of the span element </param>
      ///	 * <param name="bool">
      ///	 *            bCreate if true create a new JDFNumberSpan if it does not yet
      ///	 *            exist </param>
      ///	 * <returns> JDFStringSpan the JDFStringSpan </returns>
      ///	 
      public virtual JDFStringSpan getCreateStringSpan(string strName)
      {
         return (JDFStringSpan)getCreateSpan(strName, JDFSpanBase.EnumDataType.StringSpan);
      }

      ///   
      ///	 <summary> * get a duration span
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            strName name of the span element </param>
      ///	 * <param name="bool">
      ///	 *            bCreate if true create a new getDurationSpan </param>
      ///	 * <returns> getDurationSpan the getDurationSpan </returns>
      ///	 
      public virtual JDFDurationSpan getCreateDurationSpan(string strName)
      {
         return (JDFDurationSpan)getCreateSpan(strName, JDFSpanBase.EnumDataType.DurationSpan);
      }

      ///   
      ///	 <summary> * get a time span
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            strName name of the span element </param>
      ///	 * <param name="bool">
      ///	 *            bCreate if true create a new getTimeSpan </param>
      ///	 * <returns> getTimeSpan the getTimeSpan </returns>
      ///	 
      public virtual JDFTimeSpan getCreateTimeSpan(string strName)
      {
         return (JDFTimeSpan)getCreateSpan(strName, JDFSpanBase.EnumDataType.TimeSpan);
      }

      ///   
      ///	 <summary> * get a XYPair span
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            strName name of the span element </param>
      ///	 * <param name="bool">
      ///	 *            bCreate if true create a new JDFXYPairSpan </param>
      ///	 * <returns> JDFOptionSpan the JDFOptionSpan </returns>
      ///	 
      public virtual JDFXYPairSpan getCreateCreateXYPairSpan(string strName)
      {
         return (JDFXYPairSpan)getCreateSpan(strName, JDFSpanBase.EnumDataType.XYPairSpan);
      }

      ///   
      ///	 <summary> * get a Shape span
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            strName name of the span element </param>
      ///	 * <param name="bool">
      ///	 *            bCreate if true create a new JDFShapeSpan </param>
      ///	 * <returns> JDFOptionSpan the JDFOptionSpan </returns>
      ///	 
      public virtual JDFShapeSpan getCreateCreateShapeSpan(string strName)
      {
         return (JDFShapeSpan)getCreateSpan(strName, JDFSpanBase.EnumDataType.ShapeSpan);
      }

      ///   
      ///	 <summary> * get a number span
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            strName name of the span element </param>
      ///	 * <returns> JDFNumberSpan the JDFNumberSpan </returns>
      ///	 
      public virtual JDFNumberSpan getNumberSpan(string strName)
      {
         return (JDFNumberSpan)getSpan(strName, EnumDataType.NumberSpan);
      }

      ///   
      ///	 <summary> * get an option (boolean) span
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            strName name of the span element </param>
      ///	 * <returns> JDFOptionSpan the JDFOptionSpan </returns>
      ///	 
      public virtual JDFOptionSpan getOptionSpan(string strName)
      {
         return (JDFOptionSpan)getSpan(strName, EnumDataType.OptionSpan);
      }

      ///   
      ///	 <summary> * get an integer span
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            strName name of the span element </param>
      ///	 * <returns> getIntegerSpan the getIntegerSpan </returns>
      ///	 
      public virtual JDFIntegerSpan getIntegerSpan(string strName)
      {
         return (JDFIntegerSpan)getSpan(strName, EnumDataType.IntegerSpan);
      }

      ///   
      ///	 <summary> * get a namespan
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            strName name of the span element </param>
      ///	 * <returns> JDFNameSpan the JDFNameSpan </returns>
      ///	 
      public virtual JDFNameSpan getNameSpan(string strName)
      {
         return (JDFNameSpan)getSpan(strName, EnumDataType.NameSpan);
      }

      ///   
      ///	 <summary> * get an Enumeration span
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            strName name of the span element </param>
      ///	 * <returns> getEnumerationSpan the getEnumerationSpan </returns>
      ///	 
      public virtual JDFEnumerationSpan getEnumerationSpan(string strName)
      {
         return (JDFEnumerationSpan)getSpan(strName, EnumDataType.EnumerationSpan);
      }

      ///   
      ///	 <summary> * get a string span
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            strName name of the span element </param>
      ///	 * <returns> JDFStringSpan the JDFStringSpan </returns>
      ///	 
      public virtual JDFStringSpan getStringSpan(string strName)
      {
         return (JDFStringSpan)getSpan(strName, EnumDataType.StringSpan);
      }

      ///   
      ///	 <summary> * get a duration span
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            strName name of the span element </param>
      ///	 * <returns> getDurationSpan the getDurationSpan </returns>
      ///	 
      public virtual JDFDurationSpan getDurationSpan(string strName)
      {
         return (JDFDurationSpan)getSpan(strName, EnumDataType.DurationSpan);
      }

      ///   
      ///	 <summary> * get a time span
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            strName name of the span element </param>
      ///	 * <returns> getTimeSpan the getTimeSpan </returns>
      ///	 
      public virtual JDFTimeSpan getTimeSpan(string strName)
      {
         return (JDFTimeSpan)getSpan(strName, EnumDataType.TimeSpan);
      }

      ///   
      ///	 <summary> * get a XYPair span
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            strName name of the span element </param>
      ///	 * <returns> JDFXYPairSpan the JDFXYPairSpan </returns>
      ///	 
      public virtual JDFXYPairSpan getXYPairSpan(string strName)
      {
         return (JDFXYPairSpan)getSpan(strName, EnumDataType.XYPairSpan);
      }

      ///   
      ///	 <summary> * get a Shape span
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            strName name of the span element </param>
      ///	 * <returns> JDFShapeSpan the JDFShapeSpan </returns>
      ///	 
      public virtual JDFShapeSpan getShapeSpan(string strName)
      {
         return (JDFShapeSpan)getSpan(strName, EnumDataType.ShapeSpan);
      }

      ///   
      ///	 <summary> * Append a number span if it does not yet exist, else return the existing
      ///	 * element
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            strName name of the span element </param>
      ///	 * <returns> JDFNumberSpan the JDFNumberSpan </returns>
      ///	 
      public virtual JDFNumberSpan appendNumberSpan(string strName)
      {
         return (JDFNumberSpan)appendSpan(strName, JDFSpanBase.EnumDataType.NumberSpan);
      }

      ///   
      ///	 <summary> * Append an option (boolean) span
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            strName name of the span element </param>
      ///	 * <returns> JDFOptionSpan the JDFOptionSpan </returns>
      ///	 
      public virtual JDFOptionSpan appendOptionSpan(string strName)
      {
         return (JDFOptionSpan)appendSpan(strName, JDFSpanBase.EnumDataType.OptionSpan);
      }

      ///   
      ///	 <summary> * Append an integer span if it does not yet exist, else return the existing
      ///	 * element
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            strName name of the span element </param>
      ///	 * <returns> JDFIntegerSpan the JDFIntegerSpan </returns>
      ///	 
      public virtual JDFIntegerSpan appendIntegerSpan(string strName)
      {
         return (JDFIntegerSpan)appendSpan(strName, JDFSpanBase.EnumDataType.IntegerSpan);
      }

      ///   
      ///	 <summary> * Append a name span if it does not yet exist, else return the existing
      ///	 * element
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            strName name of the span element </param>
      ///	 * <returns> JDFNameSpan the JDFNameSpan </returns>
      ///	 
      public virtual JDFNameSpan appendNameSpan(string strName)
      {
         return (JDFNameSpan)appendSpan(strName, JDFSpanBase.EnumDataType.NameSpan);
      }

      ///   
      ///	 <summary> * Append an Enumeration span if it does not yet exist, else return the
      ///	 * existing element
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            strName name of the span element </param>
      ///	 * <returns> JDFEnumerationSpan the JDFEnumerationSpan </returns>
      ///	 
      public virtual JDFEnumerationSpan appendEnumerationSpan(string strName)
      {
         return (JDFEnumerationSpan)appendSpan(strName, JDFSpanBase.EnumDataType.EnumerationSpan);
      }

      ///   
      ///	 <summary> * Append a string span if it does not yet exist, else return the existing
      ///	 * element
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            strName name of the span element </param>
      ///	 * <returns> JDFStringSpan the JDFStringSpan </returns>
      ///	 
      public virtual JDFStringSpan appendStringSpan(string strName)
      {
         return (JDFStringSpan)appendSpan(strName, JDFSpanBase.EnumDataType.StringSpan);
      }

      ///   
      ///	 <summary> * Append a duration span if it does not yet exist, else return the existing
      ///	 * element
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            strName name of the span element </param>
      ///	 * <returns> JDFDurationSpan the JDFDurationSpan </returns>
      ///	 
      public virtual JDFDurationSpan appendDurationSpan(string strName)
      {
         return (JDFDurationSpan)appendSpan(strName, JDFSpanBase.EnumDataType.DurationSpan);
      }

      ///   
      ///	 <summary> * Append a time span if it does not yet exist, else return the existing
      ///	 * element
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            strName name of the span element </param>
      ///	 * <returns> JDFTimeSpan the JDFTimeSpan </returns>
      ///	 
      public virtual JDFTimeSpan appendTimeSpan(string strName)
      {
         return (JDFTimeSpan)appendSpan(strName, JDFSpanBase.EnumDataType.TimeSpan);
      }

      ///   
      ///	 <summary> * Append a XYPair span if it does not yet exist, else return the existing
      ///	 * element
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            strName name of the span element </param>
      ///	 * <returns> JDFXYPairSpan the JDFXYPairSpan </returns>
      ///	 
      public virtual JDFXYPairSpan appendXYPairSpan(string strName)
      {
         return (JDFXYPairSpan)appendSpan(strName, JDFSpanBase.EnumDataType.XYPairSpan);
      }

      ///   
      ///	 <summary> * Append a Shape span if it does not yet exist, else return the existing
      ///	 * element
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            strName name of the span element </param>
      ///	 * <returns> JDFShapeSpan the JDFShapeSpan </returns>
      ///	 
      public virtual JDFShapeSpan appendShapeSpan(string strName)
      {
         return (JDFShapeSpan)appendSpan(strName, JDFSpanBase.EnumDataType.ShapeSpan);
      }

      ///   
      ///	 <summary> * get a span, create it if it does not exist
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            strName name of the span element </param>
      ///	 * <param name="JDFSpanBase">
      ///	 *            ::EnumDataType nType datatype of the new span </param>
      ///	 * <returns> JDFSpanBase the JDFSpanBase </returns>
      ///	 
      internal virtual JDFSpanBase getCreateSpan(string strName, JDFSpanBase.EnumDataType nType)
      {
         // / note that this is the inherited version from JDFResource!
         JDFSpanBase e = (JDFSpanBase)this.getCreateElement_JDFResource(strName, JDFConstants.EMPTYSTRING, 0);
         e.setDataType(nType);
         return e;
      }

      ///   
      ///	 <summary> * get a span
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            strName name of the span element </param>
      ///	 * <returns> JDFSpanBase the JDFSpanBase </returns>
      ///	 
      public virtual JDFSpanBase getSpan(string strName, JDFSpanBase.EnumDataType nType)
      {
         // / note that this is the inherited version from JDFResource!
         JDFSpanBase e = (JDFSpanBase)getElement(strName, JDFConstants.EMPTYSTRING, 0);
         if (e != null && nType != null)
         {
            JDFSpanBase.EnumDataType dataType = e.getDataType();
            if (!dataType.Equals(nType))
            {
               throw new JDFException("JDFIntentResource.getSpan incompatible datatypes" + e.getAttribute(AttributeName.DATATYPE));
            }
         }
         return e;
      }

      ///   
      ///	 <summary> * Append a span if it does not yet exist, else return the existing element
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            strName name of the span element </param>
      ///	 * <param name="JDFSpanBase">
      ///	 *            .EnumDataType nType datatype of the new span </param>
      ///	 * <returns> JDFSpanBase the JDFSpanBase </returns>
      ///	 
      public virtual JDFSpanBase appendSpan(string strName, JDFSpanBase.EnumDataType nType)
      {
         // / note that this is the inherited version from JDFResource!
         JDFSpanBase e = (JDFSpanBase)appendElement(strName, JDFConstants.EMPTYSTRING);
         if (nType != null)
            e.setDataType(nType);
         return e;
      }
   }
}
