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

namespace org.cip4.jdflib.resource.process
{



   using JDFAutoPreflightReport = org.cip4.jdflib.auto.JDFAutoPreflightReport;
   using EnumSeverity = org.cip4.jdflib.auto.JDFAutoAction.EnumSeverity;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using VString = org.cip4.jdflib.core.VString;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using JDFAction = org.cip4.jdflib.resource.devicecapability.JDFAction;


   public class JDFPreflightReport : JDFAutoPreflightReport
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFPreflightReport
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFPreflightReport(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFPreflightReport
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFPreflightReport(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFPreflightReport
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="localName"> </param>

      ///	 
      public JDFPreflightReport(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
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
         return "JDFPreflightReport[  --> " + base.ToString() + " ]";
      }

      public virtual JDFPRItem setPR(JDFAction action, int pageSet, JDFAttributeMap prMap, VString groupBy)
      {

         JDFAttributeMap groupMap = null;
         JDFAttributeMap instanceMap = null;
         if (prMap != null)
         {
            groupMap = new JDFAttributeMap(prMap);
            SupportClass.SetSupport<string> @set = groupBy.getSet();
            groupMap.reduceMap(@set);
            instanceMap = new JDFAttributeMap(prMap);
            instanceMap.removeKeys(@set);
         }
         JDFPRItem pi = getCreatePRItem(action, groupMap);

         JDFPRGroup pg = pi.getCreatePRGroup(groupMap);
         JDFPROccurrence pgInstance = pg.getCreatePROccurrence(instanceMap);
         pgInstance.addOccurrences(1, action.getSeverity());
         pi.insertPageSet(pageSet);
         return pi;
      }

      ///   
      ///	 <summary> * increments the errorCount attribute by i
      ///	 *  </summary>
      ///	 * <param name="i">
      ///	 *            the amount to increment by </param>
      ///	 
      public virtual int addErrorCount(int i)
      {
         return addAttribute(AttributeName.ERRORCOUNT, i, null);
      }

      ///   
      ///	 <summary> * increments the WarningCount attribute by i
      ///	 *  </summary>
      ///	 * <param name="i">
      ///	 *            the amount to increment by </param>
      ///	 
      public virtual int addWarningCount(int i)
      {
         return addAttribute(AttributeName.WARNINGCOUNT, i, null);
      }

      ///   
      ///	 <summary> * recursive call that sets errorcount and warning count according to the
      ///	 * value of severity
      ///	 *  </summary>
      ///	 * <param name="i">
      ///	 *            the number of occurrences to add </param>
      ///	 * <param name="sev">
      ///	 *            the severity of the occurrences </param>
      ///	 
      public virtual void addOccurrences(int i, EnumSeverity sev)
      {
         if (EnumSeverity.Warning.Equals(sev))
            addWarningCount(i);
         else if (EnumSeverity.Error.Equals(sev))
            addErrorCount(i);

      }

      ///   
      ///	 * <param name="action"> </param>
      ///	 * <param name="groupMap">
      ///	 * @return </param>
      ///	 
      public virtual JDFPRItem getCreatePRItem(JDFAction action, JDFAttributeMap groupMap)
      {
         JDFPRItem pi = getPRItem(action, null);
         if (pi == null)
         {
            pi = appendPRItem();
            pi.setActionRef(action.getID());
         }
         pi.getCreatePRGroup(groupMap);
         return pi;

      }

      ///   
      ///	 * <param name="action">
      ///	 * @return </param>
      ///	 
      private JDFPRItem getPRItem(JDFAction action, JDFAttributeMap groupMap)
      {
         string id = action == null ? null : action.getID();
         JDFAttributeMap map = (id == null) ? null : new JDFAttributeMap("ActionRef", id);
         JDFPRItem pi = (JDFPRItem)getChildByTagName(ElementName.PRITEM, null, 0, map, true, true);
         if (groupMap != null && pi != null)
         {
            JDFPRGroup pg = pi.getPRGroup(groupMap);
            if (pg == null)
               return null;
         }
         return pi;
      }

      ///   
      ///	 <summary> * generic initialization routine - normally called automagically
      ///	 * initializes required attributes to 0 </summary>
      ///	 
      public override bool init()
      {
         bool b = base.init();
         setWarningCount(0);
         setErrorCount(0);
         return b;
      }
   }
}
