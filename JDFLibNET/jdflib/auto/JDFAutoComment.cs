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
 * THIS SOFTWARE IS PROVIDED ``AS IS'' AND ANY EXPRESSED OR IMPLIED
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
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFRectangle = org.cip4.jdflib.datatypes.JDFRectangle;
   using JDFDate = org.cip4.jdflib.util.JDFDate;

   public abstract class JDFAutoComment : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[10];
      static JDFAutoComment()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.AGENTNAME, 0x33333111, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.AGENTVERSION, 0x33333111, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.ATTRIBUTE, 0x33333331, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.AUTHOR, 0x33333111, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.BOX, 0x33333333, AttributeInfo.EnumAttributeType.rectangle, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.ID, 0x33333111, AttributeInfo.EnumAttributeType.ID, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.LANGUAGE, 0x33333333, AttributeInfo.EnumAttributeType.language, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.NAME, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, "Description");
         atrInfoTable[8] = new AtrInfoTable(AttributeName.PATH, 0x33333333, AttributeInfo.EnumAttributeType.PDFPath, null, null);
         atrInfoTable[9] = new AtrInfoTable(AttributeName.TIMESTAMP, 0x33333111, AttributeInfo.EnumAttributeType.dateTime, null, null);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoComment </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoComment(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoComment </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoComment(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoComment </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoComment(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoComment[  --> " + base.ToString() + " ]";
      }


      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute AgentName
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute AgentName </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAgentName(string @value)
      {
         setAttribute(AttributeName.AGENTNAME, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute AgentName </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getAgentName()
      {
         return getAttribute(AttributeName.AGENTNAME, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute AgentVersion
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute AgentVersion </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAgentVersion(string @value)
      {
         setAttribute(AttributeName.AGENTVERSION, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute AgentVersion </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getAgentVersion()
      {
         return getAttribute(AttributeName.AGENTVERSION, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Attribute
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Attribute </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAttributeJDF(string @value)
      {
         setAttribute(AttributeName.ATTRIBUTE, @value, null);
      }

      ///        
      ///          <summary> * (22) get String attribute Attribute </summary>
      ///          * <returns> String the value of the attribute </returns>
      ///          
      public virtual string getAttributeJDF()
      {
         return getAttribute(AttributeName.ATTRIBUTE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Author
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Author </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAuthor(string @value)
      {
         setAttribute(AttributeName.AUTHOR, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Author </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getAuthor()
      {
         return getAttribute(AttributeName.AUTHOR, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Box
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Box </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setBox(JDFRectangle @value)
      {
         setAttribute(AttributeName.BOX, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFRectangle attribute Box </summary>
      ///          * <returns> JDFRectangle the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFRectangle </returns>
      ///          
      public virtual JDFRectangle getBox()
      {
         string strAttrName = "";
         JDFRectangle nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.BOX, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFRectangle(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


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


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Language
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Language </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setLanguage(string @value)
      {
         setAttribute(AttributeName.LANGUAGE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Language </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getLanguage()
      {
         return getAttribute(AttributeName.LANGUAGE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Name
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Name </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setName(string @value)
      {
         setAttribute(AttributeName.NAME, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Name </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getName()
      {
         return getAttribute(AttributeName.NAME, null, "Description");
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Path
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Path </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPath(string @value)
      {
         setAttribute(AttributeName.PATH, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Path </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getPath()
      {
         return getAttribute(AttributeName.PATH, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TimeStamp
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (11) set attribute TimeStamp </summary>
      ///          * <param name="value">: the value to set the attribute to or null </param>
      ///          
      public virtual void setTimeStamp(JDFDate @value)
      {
         JDFDate date = @value;
         if (date == null)
            date = new JDFDate();
         setAttribute(AttributeName.TIMESTAMP, date.DateTimeISO, null);
      }

      ///        
      ///          <summary> * (12) get JDFDate attribute TimeStamp </summary>
      ///          * <returns> JDFDate the value of the attribute </returns>
      ///          
      public virtual JDFDate getTimeStamp()
      {
         JDFDate nMyDate = null;
         string str = JDFConstants.EMPTYSTRING;
         str = getAttribute(AttributeName.TIMESTAMP, null, JDFConstants.EMPTYSTRING);
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
   }
}
