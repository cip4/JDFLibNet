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
   using JDFcall = org.cip4.jdflib.resource.devicecapability.JDFcall;
   using JDFchoice = org.cip4.jdflib.resource.devicecapability.JDFchoice;
   using JDFset = org.cip4.jdflib.resource.devicecapability.JDFset;

   public abstract class JDFAutomacro : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[1];
      static JDFAutomacro()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.ID, 0x22222222, AttributeInfo.EnumAttributeType.ID, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.CHOICE, 0x33333333);
         elemInfoTable[1] = new ElemInfoTable(ElementName.SET, 0x33333333);
         elemInfoTable[2] = new ElemInfoTable(ElementName.CALL, 0x33333333);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[3];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutomacro </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutomacro(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutomacro </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutomacro(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutomacro </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutomacro(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutomacro[  --> " + base.ToString() + " ]";
      }


      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute ID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setID(string @value)
      {
         setAttribute(AttributeName.ID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute ID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public override string getID()
      {
         return getAttribute(AttributeName.ID, null, JDFConstants.EMPTYSTRING);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreatechoice
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFchoice the element </returns>
      ///     
      public virtual JDFchoice getCreatechoice(int iSkip)
      {
         return (JDFchoice)getCreateElement_KElement(ElementName.CHOICE, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element choice </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFchoice the element </returns>
      ///     * default is getchoice(0)     
      public virtual JDFchoice getchoice(int iSkip)
      {
         return (JDFchoice)getElement(ElementName.CHOICE, null, iSkip);
      }

      ///    
      ///     <summary> * Get all choice from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFchoice> </returns>
      ///     
      public virtual ICollection<JDFchoice> getAllchoice()
      {
         List<JDFchoice> v = new List<JDFchoice>();

         JDFchoice kElem = (JDFchoice)getFirstChildElement(ElementName.CHOICE, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFchoice)kElem.getNextSiblingElement(ElementName.CHOICE, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element choice </summary>
      ///     
      public virtual JDFchoice appendchoice()
      {
         return (JDFchoice)appendElement(ElementName.CHOICE, null);
      }

      ///     <summary> (26) getCreateset
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFset the element </returns>
      ///     
      public virtual JDFset getCreateset(int iSkip)
      {
         return (JDFset)getCreateElement_KElement(ElementName.SET, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element set </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFset the element </returns>
      ///     * default is getset(0)     
      public virtual JDFset getset(int iSkip)
      {
         return (JDFset)getElement(ElementName.SET, null, iSkip);
      }

      ///    
      ///     <summary> * Get all set from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFset> </returns>
      ///     
      public virtual ICollection<JDFset> getAllset()
      {
         List<JDFset> v = new List<JDFset>();

         JDFset kElem = (JDFset)getFirstChildElement(ElementName.SET, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFset)kElem.getNextSiblingElement(ElementName.SET, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element set </summary>
      ///     
      public virtual JDFset appendset()
      {
         return (JDFset)appendElement(ElementName.SET, null);
      }

      ///     <summary> (26) getCreatecall
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFcall the element </returns>
      ///     
      public virtual JDFcall getCreatecall(int iSkip)
      {
         return (JDFcall)getCreateElement_KElement(ElementName.CALL, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element call </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFcall the element </returns>
      ///     * default is getcall(0)     
      public virtual JDFcall getcall(int iSkip)
      {
         return (JDFcall)getElement(ElementName.CALL, null, iSkip);
      }

      ///    
      ///     <summary> * Get all call from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFcall> </returns>
      ///     
      public virtual ICollection<JDFcall> getAllcall()
      {
         List<JDFcall> v = new List<JDFcall>();

         JDFcall kElem = (JDFcall)getFirstChildElement(ElementName.CALL, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFcall)kElem.getNextSiblingElement(ElementName.CALL, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element call </summary>
      ///     
      public virtual JDFcall appendcall()
      {
         return (JDFcall)appendElement(ElementName.CALL, null);
      }
   }
}