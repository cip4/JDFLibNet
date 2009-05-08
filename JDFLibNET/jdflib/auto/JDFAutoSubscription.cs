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
   using System.Collections.Generic;



   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFObservationTarget = org.cip4.jdflib.resource.JDFObservationTarget;
   using JDFDuration = org.cip4.jdflib.util.JDFDuration;

   public abstract class JDFAutoSubscription : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[6];
      static JDFAutoSubscription()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.FORMAT, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.MINDELAYTIME, 0x33333111, AttributeInfo.EnumAttributeType.duration, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.TEMPLATE, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.REPEATSTEP, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.REPEATTIME, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.URL, 0x33333333, AttributeInfo.EnumAttributeType.URL, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.OBSERVATIONTARGET, 0x33333333);
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
      ///     <summary> * Constructor for JDFAutoSubscription </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoSubscription(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoSubscription </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoSubscription(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoSubscription </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoSubscription(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoSubscription[  --> " + base.ToString() + " ]";
      }


      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute Format
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Format </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setFormat(string @value)
      {
         setAttribute(AttributeName.FORMAT, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Format </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getFormat()
      {
         return getAttribute(AttributeName.FORMAT, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MinDelayTime
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MinDelayTime </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMinDelayTime(JDFDuration @value)
      {
         setAttribute(AttributeName.MINDELAYTIME, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFDuration attribute MinDelayTime </summary>
      ///          * <returns> JDFDuration the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFDuration </returns>
      ///          
      public virtual JDFDuration getMinDelayTime()
      {
         string strAttrName = "";
         JDFDuration nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.MINDELAYTIME, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFDuration(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Template
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Template </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTemplate(string @value)
      {
         setAttribute(AttributeName.TEMPLATE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Template </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getTemplate()
      {
         return getAttribute(AttributeName.TEMPLATE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute RepeatStep
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute RepeatStep </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setRepeatStep(int @value)
      {
         setAttribute(AttributeName.REPEATSTEP, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute RepeatStep </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getRepeatStep()
      {
         return getIntAttribute(AttributeName.REPEATSTEP, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute RepeatTime
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute RepeatTime </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setRepeatTime(double @value)
      {
         setAttribute(AttributeName.REPEATTIME, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute RepeatTime </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getRepeatTime()
      {
         return getRealAttribute(AttributeName.REPEATTIME, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute URL
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute URL </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setURL(string @value)
      {
         setAttribute(AttributeName.URL, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute URL </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getURL()
      {
         return getAttribute(AttributeName.URL, null, JDFConstants.EMPTYSTRING);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateObservationTarget
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFObservationTarget the element </returns>
      ///     
      public virtual JDFObservationTarget getCreateObservationTarget(int iSkip)
      {
         return (JDFObservationTarget)getCreateElement_KElement(ElementName.OBSERVATIONTARGET, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element ObservationTarget </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFObservationTarget the element </returns>
      ///     * default is getObservationTarget(0)     
      public virtual JDFObservationTarget getObservationTarget(int iSkip)
      {
         return (JDFObservationTarget)getElement(ElementName.OBSERVATIONTARGET, null, iSkip);
      }

      ///    
      ///     <summary> * Get all ObservationTarget from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFObservationTarget> </returns>
      ///     
      public virtual ICollection<JDFObservationTarget> getAllObservationTarget()
      {
         List<JDFObservationTarget> v = new List<JDFObservationTarget>();

         JDFObservationTarget kElem = (JDFObservationTarget)getFirstChildElement(ElementName.OBSERVATIONTARGET, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFObservationTarget)kElem.getNextSiblingElement(ElementName.OBSERVATIONTARGET, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element ObservationTarget </summary>
      ///     
      public virtual JDFObservationTarget appendObservationTarget()
      {
         return (JDFObservationTarget)appendElement(ElementName.OBSERVATIONTARGET, null);
      }
   }
}
