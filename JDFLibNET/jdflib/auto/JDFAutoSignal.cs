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


   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFMessage = org.cip4.jdflib.jmf.JDFMessage;
   using JDFTrigger = org.cip4.jdflib.jmf.JDFTrigger;
   using JDFNotification = org.cip4.jdflib.resource.JDFNotification;

   public abstract class JDFAutoSignal : JDFMessage
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[2];
      static JDFAutoSignal()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.LASTREPEAT, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.REFID, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.NOTIFICATION, 0x66666666);
         elemInfoTable[1] = new ElemInfoTable(ElementName.TRIGGER, 0x66666666);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[2];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoSignal </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoSignal(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoSignal </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoSignal(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoSignal </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoSignal(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoSignal[  --> " + base.ToString() + " ]";
      }


      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute LastRepeat
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute LastRepeat </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setLastRepeat(bool @value)
      {
         setAttribute(AttributeName.LASTREPEAT, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute LastRepeat </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getLastRepeat()
      {
         return getBoolAttribute(AttributeName.LASTREPEAT, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute refID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute refID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public override void setrefID(string @value)
      {
         setAttribute(AttributeName.REFID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute refID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public override string getrefID()
      {
         return getAttribute(AttributeName.REFID, null, JDFConstants.EMPTYSTRING);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element Notification </summary>
      ///     * <returns> JDFNotification the element </returns>
      ///     
      public virtual JDFNotification getNotification()
      {
         return (JDFNotification)getElement(ElementName.NOTIFICATION, null, 0);
      }

      ///     <summary> (25) getCreateNotification
      ///     *  </summary>
      ///     * <returns> JDFNotification the element </returns>
      ///     
      public virtual JDFNotification getCreateNotification()
      {
         return (JDFNotification)getCreateElement_KElement(ElementName.NOTIFICATION, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Notification </summary>
      ///     
      public virtual JDFNotification appendNotification()
      {
         return (JDFNotification)appendElementN(ElementName.NOTIFICATION, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element Trigger </summary>
      ///     * <returns> JDFTrigger the element </returns>
      ///     
      public virtual JDFTrigger getTrigger()
      {
         return (JDFTrigger)getElement(ElementName.TRIGGER, null, 0);
      }

      ///     <summary> (25) getCreateTrigger
      ///     *  </summary>
      ///     * <returns> JDFTrigger the element </returns>
      ///     
      public virtual JDFTrigger getCreateTrigger()
      {
         return (JDFTrigger)getCreateElement_KElement(ElementName.TRIGGER, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Trigger </summary>
      ///     
      public virtual JDFTrigger appendTrigger()
      {
         return (JDFTrigger)appendElementN(ElementName.TRIGGER, 1, null);
      }
   }
}
