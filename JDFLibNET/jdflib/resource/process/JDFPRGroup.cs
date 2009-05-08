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


//JAVA TO VB & C# CONVERTER NOTE: Beginning of line comments are not maintained by Java to VB & C# Converter
//ORIGINAL LINE: *//**
 /*
 * Copyright (c) 2001 Heidelberger Druckmaschinen AG, All Rights Reserved.
 *
 * JDFPreflightReport.cs
 *
 * Last changes
 */
 

/*
 * Copyright (c) 2001 Heidelberger Druckmaschinen AG, All Rights Reserved.
 *
 * JDFPRGroup.cs
 *
 * Last changes
 */

namespace org.cip4.jdflib.resource.process
{


   using JDFAutoPRGroup = org.cip4.jdflib.auto.JDFAutoPRGroup;
   using EnumSeverity = org.cip4.jdflib.auto.JDFAutoAction.EnumSeverity;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using KElement = org.cip4.jdflib.core.KElement;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;


   public class JDFPRGroup : JDFAutoPRGroup
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFPRGroup
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFPRGroup(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFPRGroup
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFPRGroup(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFPRGroup
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="localName"> </param>

      ///	 
      public JDFPRGroup(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
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
         return "JDFPRGroup[  --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * @return </summary>
      ///	 
      public virtual JDFPRGroupOccurrence getPRGroupOccurrence()
      {
         // TODO Dietrich fix in autoFile
         return getPRGroupOccurrence(0);
      }

      ///   
      ///	 * <param name="groupMap">
      ///	 * @return </param>
      ///	 
      public virtual JDFPROccurrence getCreatePROccurrence(JDFAttributeMap groupMap)
      {
         JDFPROccurrence po = getPROccurrence(groupMap);
         if (po == null)
         {
            po = appendPROccurrence();
            po.setAttributes(groupMap);
         }
         return po;
      }

      ///   
      ///	 * <param name="groupMap">
      ///	 * @return </param>
      ///	 
      public virtual JDFPROccurrence getPROccurrence(JDFAttributeMap groupMap)
      {
         return (JDFPROccurrence)getChildByTagName(ElementName.PROCCURRENCE, null, 0, groupMap, true, true);
      }

      ///   
      ///	 <summary> * increment occurrences by i if this lives in a standard preflight report
      ///	 * tree, also increment the appropriate higher up counters
      ///	 *  </summary>
      ///	 * <param name="i"> </param>
      ///	 
      public virtual void addOccurrences(int i, EnumSeverity sev)
      {
         addAttribute(AttributeName.OCCURRENCES, i, null);
         KElement e = getParentNode_KElement();
         if (e is JDFPRItem)
            ((JDFPRItem)e).addOccurrences(i, sev);
         else if (e is JDFPROccurrence)
            ((JDFPROccurrence)e).addOccurrences(i, sev);
      }
   }
}
