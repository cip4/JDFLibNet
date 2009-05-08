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
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using VString = org.cip4.jdflib.core.VString;

   public abstract class JDFAutoPRRuleAttr : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[5];
      static JDFAutoPRRuleAttr()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.GROUPBY, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKENS, null, "Tested");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.REPORTATTR, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.LOGERRORS, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.MAXGROUPS, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.MAXPERGROUP, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoPRRuleAttr </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPRRuleAttr(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPRRuleAttr </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoPRRuleAttr(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoPRRuleAttr </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoPRRuleAttr(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoPRRuleAttr[  --> " + base.ToString() + " ]";
      }


      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute GroupBy
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute GroupBy </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setGroupBy(VString @value)
      {
         setAttribute(AttributeName.GROUPBY, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute GroupBy </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getGroupBy()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.GROUPBY, null, "Tested");
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute ReportAttr
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ReportAttr </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setReportAttr(VString @value)
      {
         setAttribute(AttributeName.REPORTATTR, @value, null);
      }

      ///        
      ///          <summary> * (21) get VString attribute ReportAttr </summary>
      ///          * <returns> VString the value of the attribute </returns>
      ///          
      public virtual VString getReportAttr()
      {
         VString vStrAttrib = new VString();
         string s = getAttribute(AttributeName.REPORTATTR, null, JDFConstants.EMPTYSTRING);
         vStrAttrib.setAllStrings(s, " ");
         return vStrAttrib;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute LogErrors
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute LogErrors </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setLogErrors(int @value)
      {
         setAttribute(AttributeName.LOGERRORS, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute LogErrors </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getLogErrors()
      {
         return getIntAttribute(AttributeName.LOGERRORS, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MaxGroups
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MaxGroups </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMaxGroups(int @value)
      {
         setAttribute(AttributeName.MAXGROUPS, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute MaxGroups </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getMaxGroups()
      {
         return getIntAttribute(AttributeName.MAXGROUPS, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MaxPerGroup
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MaxPerGroup </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMaxPerGroup(int @value)
      {
         setAttribute(AttributeName.MAXPERGROUP, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute MaxPerGroup </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getMaxPerGroup()
      {
         return getIntAttribute(AttributeName.MAXPERGROUP, null, 0);
      }
   }
}
