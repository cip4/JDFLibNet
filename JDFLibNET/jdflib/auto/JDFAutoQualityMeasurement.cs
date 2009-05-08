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



namespace org.cip4.jdflib.auto
{
   using System;


   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFBindingQualityParams = org.cip4.jdflib.resource.process.JDFBindingQualityParams;
   using JDFDate = org.cip4.jdflib.util.JDFDate;

   public abstract class JDFAutoQualityMeasurement : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[4];
      static JDFAutoQualityMeasurement()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.END, 0x33333311, AttributeInfo.EnumAttributeType.dateTime, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.FAILED, 0x33333311, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.PASSED, 0x33333311, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.START, 0x33333311, AttributeInfo.EnumAttributeType.dateTime, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.BINDINGQUALITYMEASUREMENT, 0x66666611);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[1];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoQualityMeasurement </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoQualityMeasurement(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoQualityMeasurement </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoQualityMeasurement(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoQualityMeasurement </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoQualityMeasurement(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoQualityMeasurement[  --> " + base.ToString() + " ]";
      }


      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute End
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (11) set attribute End </summary>
      ///          * <param name="value">: the value to set the attribute to or null </param>
      ///          
      public virtual void setEnd(JDFDate @value)
      {
         JDFDate date = @value;
         if (date == null)
            date = new JDFDate();
         setAttribute(AttributeName.END, date.DateTimeISO, null);
      }

      ///        
      ///          <summary> * (12) get JDFDate attribute End </summary>
      ///          * <returns> JDFDate the value of the attribute </returns>
      ///          
      public virtual JDFDate getEnd()
      {
         JDFDate nMyDate = null;
         string str = JDFConstants.EMPTYSTRING;
         str = getAttribute(AttributeName.END, null, JDFConstants.EMPTYSTRING);
         if (!JDFConstants.EMPTYSTRING.Equals(str))
         {
            try
            {
               nMyDate = new JDFDate(str);
            }
            catch (FormatException)
            {
               // throw new JDFException("not a valid date string. Malformed JDF - return null");
            }
         }
         return nMyDate;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Failed
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Failed </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFailed(int @value)
      {
         setAttribute(AttributeName.FAILED, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute Failed </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getFailed()
      {
         return getIntAttribute(AttributeName.FAILED, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Passed
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Passed </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPassed(int @value)
      {
         setAttribute(AttributeName.PASSED, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute Passed </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getPassed()
      {
         return getIntAttribute(AttributeName.PASSED, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Start
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (11) set attribute Start </summary>
      ///          * <param name="value">: the value to set the attribute to or null </param>
      ///          
      public virtual void setStart(JDFDate @value)
      {
         JDFDate date = @value;
         if (date == null)
            date = new JDFDate();
         setAttribute(AttributeName.START, date.DateTimeISO, null);
      }

      ///        
      ///          <summary> * (12) get JDFDate attribute Start </summary>
      ///          * <returns> JDFDate the value of the attribute </returns>
      ///          
      public virtual JDFDate getStart()
      {
         JDFDate nMyDate = null;
         string str = JDFConstants.EMPTYSTRING;
         str = getAttribute(AttributeName.START, null, JDFConstants.EMPTYSTRING);
         if (!JDFConstants.EMPTYSTRING.Equals(str))
         {
            try
            {
               nMyDate = new JDFDate(str);
            }
            catch (FormatException)
            {
               // throw new JDFException("not a valid date string. Malformed JDF - return null");
            }
         }
         return nMyDate;
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element BindingQualityMeasurement </summary>
      ///     * <returns> JDFBindingQualityParams the element </returns>
      ///     
      public virtual JDFBindingQualityParams getBindingQualityMeasurement()
      {
         return (JDFBindingQualityParams)getElement(ElementName.BINDINGQUALITYMEASUREMENT, null, 0);
      }

      ///     <summary> (25) getCreateBindingQualityMeasurement
      ///     *  </summary>
      ///     * <returns> JDFBindingQualityParams the element </returns>
      ///     
      public virtual JDFBindingQualityParams getCreateBindingQualityMeasurement()
      {
         return (JDFBindingQualityParams)getCreateElement_KElement(ElementName.BINDINGQUALITYMEASUREMENT, null, 0);
      }

      ///    
      ///     <summary> * (29) append element BindingQualityMeasurement </summary>
      ///     
      public virtual JDFBindingQualityParams appendBindingQualityMeasurement()
      {
         return (JDFBindingQualityParams)appendElementN(ElementName.BINDINGQUALITYMEASUREMENT, 1, null);
      }
   }
}
