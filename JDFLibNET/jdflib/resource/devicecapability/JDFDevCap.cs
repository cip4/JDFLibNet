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
 *
 * JDFDevCap.cs
 *
 * @author Elena Skobchenko
 */

namespace org.cip4.jdflib.resource.devicecapability
{
   using System;
   using System.Collections;
   using System.Collections.Generic;



   using JDFAutoDevCap = org.cip4.jdflib.auto.JDFAutoDevCap;
   using EnumListType = org.cip4.jdflib.auto.JDFAutoBasicPreflightTest.EnumListType;
   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFComment = org.cip4.jdflib.core.JDFComment;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFRefElement = org.cip4.jdflib.core.JDFRefElement;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using XMLDoc = org.cip4.jdflib.core.XMLDoc;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using EnumFitsValue = org.cip4.jdflib.datatypes.EnumFitsValue;
   using ICapabilityElement = org.cip4.jdflib.ifaces.ICapabilityElement;
   using JDFJMF = org.cip4.jdflib.jmf.JDFJMF;
   using JDFMessageService = org.cip4.jdflib.jmf.JDFMessageService;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using EnumPartUsage = org.cip4.jdflib.resource.JDFResource.EnumPartUsage;
   using EnumResStatus = org.cip4.jdflib.resource.JDFResource.EnumResStatus;
   using EnumResourceClass = org.cip4.jdflib.resource.JDFResource.EnumResourceClass;
   using EnumAvailability = org.cip4.jdflib.resource.devicecapability.JDFDeviceCap.EnumAvailability;
   using EnumTerm = org.cip4.jdflib.resource.devicecapability.JDFTerm.EnumTerm;
   using JDFSpanBase = org.cip4.jdflib.span.JDFSpanBase;
   using StringUtil = org.cip4.jdflib.util.StringUtil;

   //----------------------------------
   public class JDFDevCap : JDFAutoDevCap, ICapabilityElement
   {

      ///   
      ///     <summary> *  </summary>
      ///     
      private new const long serialVersionUID = -8230286210621220326L;
      ///   
      ///     <summary> *  </summary>
      ///     
      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[14];
      static JDFDevCap()
      {
         elemInfoTable[0] = new ElemInfoTable(ElementName.DEVCAP, 0x33333333);
         elemInfoTable[1] = new ElemInfoTable(ElementName.BOOLEANSTATE, 0x33333333);
         elemInfoTable[2] = new ElemInfoTable(ElementName.DATETIMESTATE, 0x33333333);
         elemInfoTable[3] = new ElemInfoTable(ElementName.DURATIONSTATE, 0x33333333);
         elemInfoTable[4] = new ElemInfoTable(ElementName.ENUMERATIONSTATE, 0x33333333);
         elemInfoTable[5] = new ElemInfoTable(ElementName.INTEGERSTATE, 0x33333333);
         elemInfoTable[6] = new ElemInfoTable(ElementName.MATRIXSTATE, 0x33333333);
         elemInfoTable[7] = new ElemInfoTable(ElementName.NAMESTATE, 0x33333333);
         elemInfoTable[8] = new ElemInfoTable(ElementName.NUMBERSTATE, 0x33333333);
         elemInfoTable[9] = new ElemInfoTable(ElementName.PDFPATHSTATE, 0x33333333);
         elemInfoTable[10] = new ElemInfoTable(ElementName.RECTANGLESTATE, 0x33333333);
         elemInfoTable[11] = new ElemInfoTable(ElementName.SHAPESTATE, 0x33333333);
         elemInfoTable[12] = new ElemInfoTable(ElementName.STRINGSTATE, 0x33333333);
         elemInfoTable[13] = new ElemInfoTable(ElementName.XYPAIRSTATE, 0x33333333);
         atrInfoTable[0] = new AtrInfoTable(AttributeName.MAXOCCURS, 0x33333331, AttributeInfo.EnumAttributeType.unbounded, null, "1");
      }

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[1];

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }

      ///   
      ///	 <summary> * Constructor for JDFDevCap
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFDevCap(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFDevCap
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFDevCap(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFDevCap
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFDevCap(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      ///   
      ///	 <summary> * toString()
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public override string ToString()
      {
         return "JDFDevCap[  --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * all devcap elements should have an id </summary>
      ///	 
      public override bool init()
      {
         appendAnchor(null); // just in case it is missing
         return base.init();
      }

      ///   
      ///	 <summary> * set attribute <code>DevCapRefs</code>
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            the value to set the attribute to </param>
      ///	 
      public override void setDevCapRefs(VString @value)
      {
         setAttribute(AttributeName.DEVCAPREFS, @value, null);
      }

      ///   
      ///	 <summary> * set attribute <code>ID</code>
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            the value to set the attribute to </param>
      ///	 
      public override void setID(string @value)
      {
         setAttribute(AttributeName.ID, @value, null);
      }

      ///   
      ///	 <summary> * get String attribute <code>ID</code>
      ///	 *  </summary>
      ///	 * <returns> String: the value of the attribute </returns>
      ///	 
      public override string getID()
      {
         return getAttribute(AttributeName.ID, null, JDFConstants.EMPTYSTRING);
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.core.JDFElement#getIDPrefix()
      //	 
      public override string getIDPrefix()
      {
         return "d";
      }

      ///   
      ///	 <summary> * getAvailability - gets typesafe enumerated attribute
      ///	 * <code>Availability</code>
      ///	 *  </summary>
      ///	 * <returns> EnumAvailability: the enumeration value of the attribute </returns>
      ///	 
      public override EnumAvailability getAvailability()
      {
         EnumAvailability avail = EnumAvailability.getEnum(getAttribute(AttributeName.AVAILABILITY, null, null));

         if (avail == null)
         {
            string parName = ParentNode.Name;
            if (parName.Equals(ElementName.DEVCAP))
            {
               JDFDevCap devCap = (JDFDevCap)ParentNode;
               avail = devCap.getAvailability();
            }
            else if (parName.Equals(ElementName.DEVCAPS))
            {
               JDFDevCaps devCaps = (JDFDevCaps)ParentNode;
               avail = devCaps.getAvailability();
            }
         }
         return avail == null ? EnumAvailability.Installed : avail;
      }

      

      ///   
      ///	 <summary> * get iSkip'th element <code>DevCap</code>
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            number of elements to skip (0 -> get first element) </param>
      ///	 * <returns> the value of the attribute </returns>
      ///	 
      public virtual JDFDevCap getDevCap(int iSkip)
      {
         return (JDFDevCap)getElement(ElementName.DEVCAP, JDFConstants.EMPTYSTRING, iSkip);
      }

      

      ///   
      ///	 <summary> * get iSkip'th element <code>DevCap</code>, create if it doesn't exist
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            number of elements to skip </param>
      ///	 * <returns> the value of the attribute </returns>
      ///	 
      public virtual JDFDevCap getCreateDevCap(int iSkip)
      {
         return (JDFDevCap)getCreateElement(ElementName.DEVCAP, JDFConstants.EMPTYSTRING, iSkip);
      }

      

      ///   
      ///	 <summary> * append element <code>DevCap</code>
      ///	 *  </summary>
      ///	 * <returns> the appended element </returns>
      ///	 
      public virtual JDFDevCap appendDevCap()
      {
         return (JDFDevCap)appendElement(ElementName.DEVCAP, null);
      }

      

      ///   
      ///	 <summary> * append dc/@ID to the value of devCap/@ID
      ///	 *  </summary>
      ///	 * <param name="dc">
      ///	 *            the devCap to append </param>
      ///	 
      public virtual void appendDevCapRefs(JDFDevCap dc)
      {
         if (!(dc.ParentNode is JDFDevCapPool))
            throw new JDFException("appendDevCapRefs: referenced devCap must reide in a devCapPool");
         dc.appendAnchor(null); // just in case it is missing
         string id2 = dc.getID();
         appendDevCapRefs(id2);
      }

      

      ///   
      ///	 <summary> * append dc/@ID to the value of devCap/@ID
      ///	 *  </summary>
      ///	 * <param name="dcID">
      ///	 *            @ID of the devCap to append </param>
      ///	 
      public virtual void appendDevCapRefs(string dcID)
      {
         appendAttribute(AttributeName.DEVCAPREFS, dcID, null, " ", true);
      }

      

      ///   
      ///	 <summary> * gets the iSkip'th existing BooleanState
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            number of elements to skip (0 -> get first element) </param>
      ///	 * <returns> JDFBooleanState: the existing BooleanState </returns>
      ///	 
      public virtual JDFBooleanState getBooleanState(int iSkip)
      {
         return (JDFBooleanState)getElement(ElementName.BOOLEANSTATE, null, iSkip);
      }

      

      ///   
      ///	 <summary> * gets an existing BooleanState with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the Name attribute of the newly appended BooleanState </param>
      ///	 * <returns> JDFBooleanState: the existing BooleanState </returns>
      ///	 
      public virtual JDFBooleanState getBooleanState(string nam)
      {
         return (JDFBooleanState)getChildWithAttribute(ElementName.BOOLEANSTATE, AttributeName.NAME, null, nam, 0, true);
      }

      

      ///   
      ///	 * @deprecated use method with parameter (string) instead
      ///	 * @return 
      ///	 
      [Obsolete("use method with parameter (string) instead")]
      public virtual JDFBooleanState getCreateBooleanState(int iSkip)
      {
         return (JDFBooleanState)getCreateElement(ElementName.BOOLEANSTATE, null, iSkip);
      }

      

      ///   
      ///	 <summary> * gets a NumberState with @Name="name", appends it if it does not exist
      ///	 *  </summary>
      ///	 * <param name="name">
      ///	 *            the name attribute of the newly appended NumberState </param>
      ///	 * <returns> JDFNumberState: the existing or newly appended NumberState </returns>
      ///	 
      public virtual JDFBooleanState getCreateBooleanState(string nam)
      {
         JDFBooleanState s = getBooleanState(nam);
         if (s == null)
            s = appendBooleanState(nam);
         return s;
      }

      

      ///   
      ///	 * @deprecated use method with parameter (string) instead
      ///	 * @return 
      ///	 
      [Obsolete("use method with parameter (string) instead")]
      public virtual JDFBooleanState appendBooleanState()
      {
         return (JDFBooleanState)appendElement(ElementName.BOOLEANSTATE, null);
      }

      ///   
      ///	 <summary> * appends a BooleanState with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the name attribute of the newly appended BooleanState </param>
      ///	 * <returns> JDFBooleanState: the newly appended BooleanState </returns>
      ///	 
      public virtual JDFBooleanState appendBooleanState(string nam)
      {
         JDFBooleanState s = (JDFBooleanState)appendElement(ElementName.BOOLEANSTATE, null);
         s.setName(nam);
         return s;
      }

      
      

      ///   
      ///	 <summary> * gets the iSkip'th existing IntegerState
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            number of elements to skip (0 -> get first element) </param>
      ///	 * <returns> JDFIntegerState: the existing IntegerState </returns>
      ///	 
      public virtual JDFIntegerState getIntegerState(int iSkip)
      {
         JDFIntegerState e = (JDFIntegerState)getElement(ElementName.INTEGERSTATE, null, iSkip);
         return e;
      }

      

      ///   
      ///	 <summary> * gets an existing IntegerState with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the name attribute of the newly appended IntegerState </param>
      ///	 * <returns> JDFIntegerState: the existing IntegerState </returns>
      ///	 
      public virtual JDFIntegerState getIntegerState(string nam)
      {
         return (JDFIntegerState)getChildWithAttribute(ElementName.INTEGERSTATE, AttributeName.NAME, null, nam, 0, true);
      }

      

      ///   
      ///	 * @deprecated use method with parameter (string) instead
      ///	 * @return 
      ///	 
      [Obsolete("use method with parameter (string) instead")]
      public virtual JDFIntegerState getCreateIntegerState(int iSkip)
      {
         return (JDFIntegerState)getCreateElement(ElementName.INTEGERSTATE, null, iSkip);
      }

      ///   
      ///	 <summary> * gets an IntegerState with @Name="name", appends it if it does not yet
      ///	 * exist
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the name attribute of the newly appended IntegerState </param>
      ///	 * <returns> JDFIntegerState: the existing or newly appended IntegerState </returns>
      ///	 
      public virtual JDFIntegerState getCreateIntegerState(string nam)
      {
         JDFIntegerState s = getIntegerState(nam);
         if (s == null)
            s = appendIntegerState(nam);
         return s;
      }

      

      ///   
      ///	 <summary> * append an IntegerState with no name set
      ///	 *  </summary>
      ///	 * <returns> JDFIntegerState: the newly appended IntegerState </returns>
      ///	 
      public virtual JDFIntegerState appendIntegerState()
      {
         return (JDFIntegerState)appendElement(ElementName.INTEGERSTATE, null);
      }

      

      ///   
      ///	 <summary> * appends an IntegerState with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="name">
      ///	 *            the Name attribute of the newly appended IntegerState </param>
      ///	 * <returns> JDFIntegerState: the newly appended IntegerState </returns>
      ///	 
      public virtual JDFIntegerState appendIntegerState(string nam)
      {
         JDFIntegerState s = (JDFIntegerState)appendElement(ElementName.INTEGERSTATE, null);
         s.setName(nam);
         return s;
      }

      
      

      ///   
      ///	 <summary> * gets the iSkip'th existing NumberState
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            number of elements to skip </param>
      ///	 * <returns> JDFNumberState: the existing NumberState </returns>
      ///	 
      public virtual JDFNumberState getNumberState(int iSkip)
      {
         return (JDFNumberState)getElement(ElementName.NUMBERSTATE, null, iSkip);
      }

      
      ///   
      ///	 <summary> * gets an existing NumberState with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the Name attribute of the newly appended NumberState </param>
      ///	 * <returns> JDFNumberState: the existing NumberState </returns>
      ///	 
      public virtual JDFNumberState getNumberState(string nam)
      {
         return (JDFNumberState)getChildWithAttribute(ElementName.NUMBERSTATE, AttributeName.NAME, null, nam, 0, true);
      }

      

      ///   
      ///	 * @deprecated use method with parameter (string) instead
      ///	 * @return 
      ///	 
      [Obsolete("use method with parameter (string) instead")]
      public virtual JDFNumberState getCreateNumberState(int iSkip)
      {
         return (JDFNumberState)getCreateElement(ElementName.NUMBERSTATE, null, iSkip);
      }

      

      ///   
      ///	 <summary> * gets a NumberState with @Name="name", appends it if it does not yet exist
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the Name attribute of the newly appended NumberState </param>
      ///	 * <returns> JDFNumberState: the existing or newly appended NumberState </returns>
      ///	 
      public virtual JDFNumberState getCreateNumberState(string nam)
      {
         JDFNumberState s = getNumberState(nam);
         if (s == null)
            s = appendNumberState(nam);
         return s;
      }

      
      ///   
      ///	 <summary> * appends a NumberState with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the Name attribute of the newly appended NumberState </param>
      ///	 * <returns> JDFNumberState: the newly appended NumberState </returns>
      ///	 
      public virtual JDFNumberState appendNumberState(string nam)
      {
         JDFNumberState s = (JDFNumberState)appendElement(ElementName.NUMBERSTATE, null);
         s.setName(nam);
         return s;
      }

      ///   
      ///	 * @deprecated use method with parameter (string) instead
      ///	 * @return 
      ///	 
      [Obsolete("use method with parameter (string) instead")]
      public virtual JDFNumberState appendNumberState()
      {
         return appendNumberState(null);
      }

      
      

      ///   
      ///	 <summary> * gets the iSkip'th existing EnumerationState
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            number of elements to skip (0 -> get first element) </param>
      ///	 * <returns> JDFEnumerationState: the existing EnumerationState </returns>
      ///	 
      public virtual JDFEnumerationState getEnumerationState(int iSkip)
      {
         return (JDFEnumerationState)getElement(ElementName.ENUMERATIONSTATE, null, iSkip);
      }

      

      ///   
      ///	 <summary> * gets an existing EnumerationState with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="name">
      ///	 *            the Name attribute of the newly appended EnumerationState </param>
      ///	 * <returns> JDFEnumerationState: the existing EnumerationState </returns>
      ///	 
      public virtual JDFEnumerationState getEnumerationState(string nam)
      {
         return (JDFEnumerationState)getChildWithAttribute(ElementName.ENUMERATIONSTATE, AttributeName.NAME, null, nam, 0, true);
      }

      

      ///   
      ///	 <summary> * gets the iSkip'th existing EnumerationState, creates it if it doesn't
      ///	 * exist
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            number of elements to skip (0 -> get first element) </param>
      ///	 * <returns> JDFEnumerationState: the existing EnumerationState
      ///	 * @deprecated </returns>
      ///	 
      [Obsolete]
      public virtual JDFEnumerationState getCreateEnumerationState(int iSkip)
      {
         return (JDFEnumerationState)getCreateElement(ElementName.ENUMERATIONSTATE, null, iSkip);
      }

      

      ///   
      ///	 <summary> * gets a EnumerationState with @Name="name", appends it if it does not
      ///	 * exist
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the name attribute of the newly appended EnumerationState </param>
      ///	 * <returns> JDFEnumerationState the existing or newly appended
      ///	 *         EnumerationState </returns>
      ///	 
      public virtual JDFEnumerationState getCreateEnumerationState(string nam)
      {
         JDFEnumerationState s = getEnumerationState(nam);
         if (s == null)
            s = appendEnumerationState(nam);
         return s;
      }

      

      ///   
      ///	 * @deprecated use method with parameter (string) instead
      ///	 * @return 
      ///	 
      [Obsolete("use method with parameter (string) instead")]
      public virtual JDFEnumerationState appendEnumerationState()
      {
         return (JDFEnumerationState)appendElement(ElementName.ENUMERATIONSTATE, null);
      }

      

      ///   
      ///	 <summary> * appends a NumberState with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the name attribute of the newly appended NumberState </param>
      ///	 * <returns> JDFNumberState: the newly appended NumberState </returns>
      ///	 
      public virtual JDFEnumerationState appendEnumerationState(string nam)
      {
         JDFEnumerationState s = (JDFEnumerationState)appendElement(ElementName.ENUMERATIONSTATE, null);
         s.setName(nam);
         return s;
      }

      
      

      ///   
      ///	 <summary> * gets the iSkip'th existing NameState
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            number of elements to skip </param>
      ///	 * <returns> JDFNameState: the existing NameState </returns>
      ///	 
      public virtual JDFNameState getNameState(int iSkip)
      {
         return (JDFNameState)getElement(ElementName.NAMESTATE, null, iSkip);
      }

      

      ///   
      ///	 <summary> * gets an existing NameState with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the Name attribute of the newly appended NameState </param>
      ///	 * <returns> JDFNameState: the existing NameState </returns>
      ///	 
      public virtual JDFNameState getNameState(string nam)
      {
         return (JDFNameState)getChildWithAttribute(ElementName.NAMESTATE, AttributeName.NAME, null, nam, 0, true);
      }

      

      ///   
      ///	 * @deprecated use method with parameter (string) instead
      ///	 * @return 
      ///	 
      [Obsolete("use method with parameter (string) instead")]
      public virtual JDFNameState getCreateNameState(int iSkip)
      {
         return (JDFNameState)getCreateElement(ElementName.NAMESTATE, null, iSkip);
      }

      

      ///   
      ///	 <summary> * gets a NameState with @Name="name", appends it if it does not exist
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the name attribute of the newly appended NameState </param>
      ///	 * <returns> JDFNameState: the existing or newly appended NameState </returns>
      ///	 
      public virtual JDFNameState getCreateNameState(string nam)
      {
         JDFNameState s = getNameState(nam);
         if (s == null)
            s = appendNameState(nam);
         return s;
      }

      

      ///   
      ///	 * @deprecated use method with parameter (string) instead
      ///	 * @return 
      ///	 
      [Obsolete("use method with parameter (string) instead")]
      public virtual JDFNameState appendNameState()
      {
         return (JDFNameState)appendElement(ElementName.NAMESTATE, null);
      }

      

      ///   
      ///	 <summary> * appends a NameState with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the name attribute of the newly appended NameState </param>
      ///	 * <returns> JDFNameState: the newly appended NameState </returns>
      ///	 
      public virtual JDFNameState appendNameState(string nam)
      {
         JDFNameState s = (JDFNameState)appendElement(ElementName.NAMESTATE, null);
         s.setName(nam);
         return s;
      }

      
      

      ///   
      ///	 <summary> * gets the iSkip'th existing StringState
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            number of elements to skip </param>
      ///	 * <returns> JDFStringState: the existing StringState </returns>
      ///	 
      public virtual JDFStringState getStringState(int iSkip)
      {
         return (JDFStringState)getElement(ElementName.STRINGSTATE, null, iSkip);
      }

      

      ///   
      ///	 <summary> * gets an existing StringState with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the Name attribute of the newly appended StringState </param>
      ///	 * <returns> JDFStringState: the existing StringState </returns>
      ///	 
      public virtual JDFStringState getStringState(string nam)
      {
         return (JDFStringState)getChildWithAttribute(ElementName.STRINGSTATE, AttributeName.NAME, null, nam, 0, true);
      }

      

      ///   
      ///	 * @deprecated use method with parameter (string) instead
      ///	 * @return 
      ///	 
      [Obsolete("use method with parameter (string) instead")]
      public virtual JDFStringState getCreateStringState(int iSkip)
      {
         return (JDFStringState)getCreateElement(ElementName.STRINGSTATE, null, iSkip);
      }

      

      ///   
      ///	 <summary> * gets a StringState with @Name="name", appends it if it does not yet exist
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the Name attribute of the newly appended StringState </param>
      ///	 * <returns> JDFStringState: the existing or newly appended StringState </returns>
      ///	 
      public virtual JDFStringState getCreateStringState(string nam)
      {
         JDFStringState s = getStringState(nam);
         if (s == null)
            s = appendStringState(nam);
         return s;
      }

      

      ///   
      ///	 * @deprecated use method with parameter (string) instead
      ///	 * @return 
      ///	 
      [Obsolete("use method with parameter (string) instead")]
      public virtual JDFStringState appendStringState()
      {
         return (JDFStringState)appendElement(ElementName.STRINGSTATE, null);
      }

      

      ///   
      ///	 <summary> * appends a StringState with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the Name attribute of the newly appended StringState </param>
      ///	 * <returns> JDFStringState: the newly appended StringState </returns>
      ///	 
      public virtual JDFStringState appendStringState(string nam)
      {
         JDFStringState s = (JDFStringState)appendElement(ElementName.STRINGSTATE, null);
         s.setName(nam);
         return s;
      }

      
      

      ///   
      ///	 <summary> * gets the iSkip'th existing XYPairState
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            number of elements to skip </param>
      ///	 * <returns> JDFXYPairState: the existing XYPairState </returns>
      ///	 
      public virtual JDFXYPairState getXYPairState(int iSkip)
      {
         return (JDFXYPairState)getElement(ElementName.XYPAIRSTATE, null, iSkip);
      }

      

      ///   
      ///	 <summary> * gets an existing XYPairState with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the Name attribute of the newly appended XYPairState </param>
      ///	 * <returns> JDFXYPairState: the existing XYPairState </returns>
      ///	 
      public virtual JDFXYPairState getXYPairState(string nam)
      {
         return (JDFXYPairState)getChildWithAttribute(ElementName.XYPAIRSTATE, AttributeName.NAME, null, nam, 0, true);
      }

      

      ///   
      ///	 * @deprecated use method with parameter (string) instead
      ///	 * @return 
      ///	 
      [Obsolete("use method with parameter (string) instead")]
      public virtual JDFXYPairState getCreateXYPairState(int iSkip)
      {
         return (JDFXYPairState)getCreateElement(ElementName.XYPAIRSTATE, null, iSkip);
      }

      

      ///   
      ///	 <summary> * gets a XYPairState with @Name="name", appends it if it does not yet exist
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the Name attribute of the newly appended XYPairState </param>
      ///	 * <returns> JDFXYPairState: the existing or newly appended XYPairState </returns>
      ///	 
      public virtual JDFXYPairState getCreateXYPairState(string nam)
      {
         JDFXYPairState s = getXYPairState(nam);
         if (s == null)
            s = appendXYPairState(nam);
         return s;
      }

      

      ///   
      ///	 * @deprecated use method with parameter (string) instead
      ///	 * @return 
      ///	 
      [Obsolete("use method with parameter (string) instead")]
      public virtual JDFXYPairState appendXYPairState()
      {
         return (JDFXYPairState)appendElement(ElementName.XYPAIRSTATE, null);
      }

      

      ///   
      ///	 <summary> * appends a XYPairState with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the Name attribute of the newly appended XYPairState </param>
      ///	 * <returns> JDFXYPairState: the newly appended XYPairState </returns>
      ///	 
      public virtual JDFXYPairState appendXYPairState(string nam)
      {
         JDFXYPairState s = (JDFXYPairState)appendElement(ElementName.XYPAIRSTATE, null);
         s.setName(nam);
         return s;
      }

      
      

      ///   
      ///	 <summary> * gets the iSkip'th existing ShapeState
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            number of elements to skip (0 -> get first element) </param>
      ///	 * <returns> JDFShapeState the existing ShapeState </returns>
      ///	 
      public virtual JDFShapeState getShapeState(int iSkip)
      {
         return (JDFShapeState)getElement(ElementName.SHAPESTATE, null, iSkip);
      }

      

      ///   
      ///	 <summary> * gets an existing ShapeState with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the Name attribute of the newly appended ShapeState </param>
      ///	 * <returns> JDFShapeState: the existing ShapeState </returns>
      ///	 
      public virtual JDFShapeState getShapeState(string nam)
      {
         return (JDFShapeState)getChildWithAttribute(ElementName.SHAPESTATE, AttributeName.NAME, null, nam, 0, true);
      }

      

      ///   
      ///	 * @deprecated use method with parameter (string) instead
      ///	 * @return 
      ///	 
      [Obsolete("use method with parameter (string) instead")]
      public virtual JDFShapeState getCreateShapeState(int iSkip)
      {
         return (JDFShapeState)getCreateElement(ElementName.SHAPESTATE, null, iSkip);
      }

      

      ///   
      ///	 <summary> * gets a ShapeState with @Name="name", appends it if it does not yet exist
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the Name attribute of the newly appended ShapeState </param>
      ///	 * <returns> JDFShapeState: the existing or newly appended ShapeState </returns>
      ///	 
      public virtual JDFShapeState getCreateShapeState(string nam)
      {
         JDFShapeState s = getShapeState(nam);
         if (s == null)
            s = appendShapeState(nam);
         return s;
      }

      

      ///   
      ///	 * @deprecated use method with parameter (string) instead
      ///	 * @return 
      ///	 
      [Obsolete("use method with parameter (string) instead")]
      public virtual JDFShapeState appendShapeState()
      {
         return (JDFShapeState)appendElement(ElementName.SHAPESTATE, null);
      }

      

      ///   
      ///	 <summary> * appends a ShapeState with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the Name attribute of the newly appended ShapeState </param>
      ///	 * <returns> JDFShapeState: the newly appended ShapeState </returns>
      ///	 
      public virtual JDFShapeState appendShapeState(string nam)
      {
         JDFShapeState s = (JDFShapeState)appendElement(ElementName.SHAPESTATE, null);
         s.setName(nam);
         return s;
      }

      
      

      ///   
      ///	 <summary> * gets the iSkip'th existing MatrixState
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            number of elements to skip (0 -> get first element) </param>
      ///	 * <returns> JDFMatrixState the existing MatrixState </returns>
      ///	 
      public virtual JDFMatrixState getMatrixState(int iSkip)
      {
         return (JDFMatrixState)getElement(ElementName.MATRIXSTATE, null, iSkip);
      }

      

      ///   
      ///	 <summary> * gets an existing MatrixState with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the Name attribute of the newly appended MatrixState </param>
      ///	 * <returns> JDFMatrixState: the existing MatrixState </returns>
      ///	 
      public virtual JDFMatrixState getMatrixState(string nam)
      {
         return (JDFMatrixState)getChildWithAttribute(ElementName.MATRIXSTATE, AttributeName.NAME, null, nam, 0, true);
      }

      

      ///   
      ///	 * @deprecated use method with parameter (string) instead
      ///	 * @return 
      ///	 
      [Obsolete("use method with parameter (string) instead")]
      public virtual JDFMatrixState getCreateMatrixState(int iSkip)
      {
         return (JDFMatrixState)getCreateElement(ElementName.MATRIXSTATE, null, iSkip);
      }

      ///   
      ///	 <summary> * gets a MatrixState with @Name="name", appends it if it does not yet exist
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the Name attribute of the newly appended MatrixState </param>
      ///	 * <returns> JDFMatrixState: the existing or newly appended MatrixState </returns>
      ///	 
      public virtual JDFMatrixState getCreateMatrixState(string nam)
      {
         JDFMatrixState s = getMatrixState(nam);
         if (s == null)
            s = appendMatrixState(nam);
         return s;
      }

      

      ///   
      ///	 * @deprecated use method with parameter (string) instead
      ///	 * @return 
      ///	 
      [Obsolete("use method with parameter (string) instead")]
      public virtual JDFMatrixState appendMatrixState()
      {
         return (JDFMatrixState)appendElement(ElementName.MATRIXSTATE, null);
      }

      

      ///   
      ///	 <summary> * appends a MatrixState with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the Name attribute of the newly appended MatrixState </param>
      ///	 * <returns> JDFMatrixState: the newly appended MatrixState </returns>
      ///	 
      public virtual JDFMatrixState appendMatrixState(string nam)
      {
         JDFMatrixState s = (JDFMatrixState)appendElement(ElementName.MATRIXSTATE, null);
         s.setName(nam);
         return s;
      }

      
      

      ///   
      ///	 <summary> * gets the iSkip'th existing DateTimeState
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            number of elements to skip (0 -> get first element) </param>
      ///	 * <returns> JDFDateTimeState the existing DateTimeState </returns>
      ///	 
      public virtual JDFDateTimeState getDateTimeState(int iSkip)
      {
         return (JDFDateTimeState)getElement(ElementName.DATETIMESTATE, null, iSkip);
      }

      

      ///   
      ///	 <summary> * gets an existing DateTimeState with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the Name attribute of the newly appended DateTimeState </param>
      ///	 * <returns> JDFDateTimeState: the existing DateTimeState </returns>
      ///	 
      public virtual JDFDateTimeState getDateTimeState(string nam)
      {
         return (JDFDateTimeState)getChildWithAttribute(ElementName.DATETIMESTATE, AttributeName.NAME, null, nam, 0, true);
      }

      

      ///   
      ///	 * @deprecated use method with parameter (string) instead
      ///	 * @return 
      ///	 
      [Obsolete("use method with parameter (string) instead")]
      public virtual JDFDateTimeState getCreateDateTimeState(int iSkip)
      {
         return (JDFDateTimeState)getCreateElement(ElementName.DATETIMESTATE, null, iSkip);
      }

      

      ///   
      ///	 <summary> * gets a DateTimeState with @Name="name", appends it if it does not yet
      ///	 * exist
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the Name attribute of the newly appended DateTimeState </param>
      ///	 * <returns> JDFDateTimeState: the existing or newly appended DateTimeState </returns>
      ///	 
      public virtual JDFDateTimeState getCreateDateTimeState(string nam)
      {
         JDFDateTimeState s = getDateTimeState(nam);
         if (s == null)
            s = appendDateTimeState(nam);
         return s;
      }

      

      ///   
      ///	 * @deprecated use method with parameter (string) instead
      ///	 * @return 
      ///	 
      [Obsolete("use method with parameter (string) instead")]
      public virtual JDFDateTimeState appendDateTimeState()
      {
         return (JDFDateTimeState)appendElement(ElementName.DATETIMESTATE, null);
      }

      

      ///   
      ///	 <summary> * appends a DateTimeState with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the Name attribute of the newly appended DateTimeState </param>
      ///	 * <returns> JDFDateTimeState: the newly appended DateTimeState </returns>
      ///	 
      public virtual JDFDateTimeState appendDateTimeState(string nam)
      {
         JDFDateTimeState s = (JDFDateTimeState)appendElement(ElementName.DATETIMESTATE, null);
         s.setName(nam);
         return s;
      }

      
      

      ///   
      ///	 <summary> * gets the iSkip'th existing DurationState
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            number of elements to skip (0 -> get first element) </param>
      ///	 * <returns> JDFDurationState the existing DurationState </returns>
      ///	 
      public virtual JDFDurationState getDurationState(int iSkip)
      {
         return (JDFDurationState)getElement(ElementName.DURATIONSTATE, null, iSkip);
      }

      

      ///   
      ///	 <summary> * gets an existing DurationState with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the Name attribute of the newly appended DurationState </param>
      ///	 * <returns> JDFDurationState: the existing DurationState </returns>
      ///	 
      public virtual JDFDurationState getDurationState(string nam)
      {
         return (JDFDurationState)getChildWithAttribute(ElementName.DURATIONSTATE, AttributeName.NAME, null, nam, 0, true);
      }

      

      ///   
      ///	 * @deprecated use method with parameter (string) instead
      ///	 * @return 
      ///	 
      [Obsolete("use method with parameter (string) instead")]
      public virtual JDFDurationState getCreateDurationState(int iSkip)
      {
         return (JDFDurationState)getCreateElement(ElementName.DURATIONSTATE, null, iSkip);
      }

      

      ///   
      ///	 <summary> * gets a DurationState with @Name="name", appends it if it does not yet
      ///	 * exist
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the Name attribute of the newly appended DurationState </param>
      ///	 * <returns> JDFDurationState: the existing or newly appended DurationState </returns>
      ///	 
      public virtual JDFDurationState getCreateDurationState(string nam)
      {
         JDFDurationState s = getDurationState(nam);
         if (s == null)
            s = appendDurationState(nam);
         return s;
      }

      

      ///   
      ///	 * @deprecated use method with parameter (string) instead
      ///	 * @return 
      ///	 
      [Obsolete("use method with parameter (string) instead")]
      public virtual JDFDurationState appendDurationState()
      {
         return (JDFDurationState)appendElement(ElementName.DURATIONSTATE, null);
      }

      

      ///   
      ///	 <summary> * appends a DurationState with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the Name attribute of the newly appended DurationState </param>
      ///	 * <returns> JDFDurationState: the newly appended DurationState </returns>
      ///	 
      public virtual JDFDurationState appendDurationState(string nam)
      {
         JDFDurationState s = (JDFDurationState)appendElement(ElementName.DURATIONSTATE, null);
         s.setName(nam);
         return s;
      }

      

      ///   
      ///	 <summary> * gets the iSkip'th existing PDFPathState
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            number of elements to skip (0 -> get first element) </param>
      ///	 * <returns> JDFPDFPathState: the existing PDFPathState </returns>
      ///	 
      public virtual JDFPDFPathState getPDFPathState(int iSkip)
      {
         return (JDFPDFPathState)getElement(ElementName.PDFPATHSTATE, null, iSkip);
      }

      

      ///   
      ///	 <summary> * gets an existing PDFPathState with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the Name attribute of the newly appended PDFPathState </param>
      ///	 * <returns> JDFPDFPathState: the existing PDFPathState </returns>
      ///	 
      public virtual JDFPDFPathState getPDFPathState(string nam)
      {
         return (JDFPDFPathState)getChildWithAttribute(ElementName.PDFPATHSTATE, AttributeName.NAME, null, nam, 0, true);
      }

      

      ///   
      ///	 * @deprecated use method with parameter (string) instead
      ///	 * @return 
      ///	 
      [Obsolete("use method with parameter (string) instead")]
      public virtual JDFPDFPathState getCreatePDFPathState(int iSkip)
      {
         return (JDFPDFPathState)getCreateElement(ElementName.PDFPATHSTATE, null, iSkip);
      }

      

      ///   
      ///	 <summary> * gets a PDFPathState with @Name="name", appends it if it does not yet
      ///	 * exist
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the Name attribute of the newly appended PDFPathState </param>
      ///	 * <returns> JDFPDFPathState: the existing or newly appended PDFPathState </returns>
      ///	 
      public virtual JDFPDFPathState getCreatePDFPathState(string nam)
      {
         JDFPDFPathState s = getPDFPathState(nam);
         if (s == null)
            s = appendPDFPathState(nam);
         return s;
      }

      

      ///   
      ///	 * @deprecated use method with parameter (string) instead
      ///	 * @return 
      ///	 
      [Obsolete("use method with parameter (string) instead")]
      public virtual JDFPDFPathState appendPDFPathState()
      {
         return (JDFPDFPathState)appendElement(ElementName.PDFPATHSTATE, null);
      }

      

      ///   
      ///	 <summary> * appends a PDFPathState with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the Name attribute of the newly appended PDFPathState </param>
      ///	 * <returns> JDFPDFPathState: the newly appended PDFPathState </returns>
      ///	 
      public virtual JDFPDFPathState appendPDFPathState(string nam)
      {
         JDFPDFPathState s = (JDFPDFPathState)appendElement(ElementName.PDFPATHSTATE, null);
         s.setName(nam);
         return s;
      }

      
      

      ///   
      ///	 <summary> * gets the iSkip'th existing RectangleState
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            number of elements to skip (0 -> get first element) </param>
      ///	 * <returns> JDFRectangleState: the existing RectangleState </returns>
      ///	 
      public virtual JDFRectangleState getRectangleState(int iSkip)
      {
         return (JDFRectangleState)getElement(ElementName.RECTANGLESTATE, null, iSkip);
      }

      

      ///   
      ///	 <summary> * gets an existing RectangleState with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the Name attribute of the newly appended RectangleState </param>
      ///	 * <returns> JDFRectangleState: the existing RectangleState </returns>
      ///	 
      public virtual JDFRectangleState getRectangleState(string nam)
      {
         return (JDFRectangleState)getChildWithAttribute(ElementName.RECTANGLESTATE, AttributeName.NAME, null, nam, 0, true);
      }

      

      ///   
      ///	 * @deprecated use method with parameter (string) instead
      ///	 * @return 
      ///	 
      [Obsolete("use method with parameter (string) instead")]
      public virtual JDFRectangleState getCreateRectangleState(int iSkip)
      {
         return (JDFRectangleState)getCreateElement(ElementName.RECTANGLESTATE, null, iSkip);
      }

      

      ///   
      ///	 <summary> * gets a RectangleState with @Name="name", appends it if it does not yet
      ///	 * exist
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the Name attribute of the newly appended RectangleState </param>
      ///	 * <returns> JDFRectangleState: the existing or newly appended RectangleState </returns>
      ///	 
      public virtual JDFRectangleState getCreateRectangleState(string nam)
      {
         JDFRectangleState s = getRectangleState(nam);
         if (s == null)
            s = appendRectangleState(nam);
         return s;
      }

      

      ///   
      ///	 * @deprecated use method with parameter (string) instead
      ///	 * @return 
      ///	 
      [Obsolete("use method with parameter (string) instead")]
      public virtual JDFRectangleState appendRectangleState()
      {
         return (JDFRectangleState)appendElement(ElementName.RECTANGLESTATE, null);
      }

      

      ///   
      ///	 <summary> * appends a RectangleState with @Name="name"
      ///	 *  </summary>
      ///	 * <param name="nam">
      ///	 *            the Name attribute of the newly appended RectangleState </param>
      ///	 * <returns> JDFRectangleState: the newly appended RectangleState </returns>
      ///	 
      public virtual JDFRectangleState appendRectangleState(string nam)
      {
         JDFRectangleState s = (JDFRectangleState)appendElement(ElementName.RECTANGLESTATE, null);
         s.setName(nam);
         return s;
      }

      //   
      //	 * // FitsValue Methods
      //	 
      ///   
      ///	 <summary> * get the DEvCapPool that contains devcap elements referenced by this
      ///	 *  </summary>
      ///	 * <returns> JDFDevCapPool the pool </returns>
      ///	 
      private KElement getParentPool(string poolName)
      {
         KElement parent = getPoolParent();
         return parent.getElement(poolName);
      }

      ///   
      ///	 <summary> * get the DEvCapPool that contains devcap elements referenced by this
      ///	 *  </summary>
      ///	 * <returns> JDFDevCapPool the pool </returns>
      ///	 
      private KElement getCreateParentPool(string poolName)
      {
         KElement parent = getPoolParent();
         return parent.getCreateElement(poolName);
      }

      private bool getIgnoreDefaults()
      {
         KElement p = getPoolParent();
         if (p is JDFDeviceCap)
            return ((JDFDeviceCap)p).isIgnoreDefaults();
         return false;
      }

      private KElement getPoolParent()
      {
         KElement parent = getDeepParent(ElementName.DEVICECAP, 0);
         if (parent == null)
            parent = getDeepParent(ElementName.MESSAGESERVICE, 0);
         if (parent != null && !(parent is JDFDeviceCap) && !(parent is JDFMessageService))
            throw new JDFException("JDFDevCap.getParentPool - invalid parent context");
         return parent;
      }

      ///   
      ///	 <summary> * Gets of this the Vector of all direct child DevCap elements plus the
      ///	 * referenced (by attribute DevCapRefs) reusable DevCap elements, that are
      ///	 * located in DevCapPool
      ///	 *  </summary>
      ///	 * <param name="devCaps"> </param>
      ///	 * <param name="bDirect">
      ///	 *  </param>
      ///	 * <returns> VElement - vector of all direct child DevCap elements plus the
      ///	 *         referenced reusable DevCap elements, that are located in
      ///	 *         DevCapPool. </returns>
      ///	 
      public VElement getDevCapVector(VElement devCaps, bool bDirect)
      {
         int preFill = 0;
         VElement vDevCap = getChildElementVector(ElementName.DEVCAP, null, null, true, 0, false);
         if (devCaps != null)
         {
            preFill = devCaps.Count;
            devCaps.appendUnique(vDevCap);
            vDevCap = devCaps;
         }
         else
         // first call
         {
            if (bDirect == false)
               vDevCap.appendUnique(this);
         }

         if (hasAttribute(AttributeName.DEVCAPREFS))
         {
            JDFDevCapPool devCapPool = (JDFDevCapPool)getParentPool(ElementName.DEVCAPPOOL);
            if (devCapPool != null)
            {
               VString idRefs = getDevCapRefs();
               for (int i = 0; i < idRefs.Count; i++)
               {
                  JDFDevCap devCap = devCapPool.getDevCap(idRefs.stringAt(i));
                  if (devCap != null)
                  {
                     vDevCap.appendUnique(devCap);
                  }
                  else
                  {
                     throw new JDFException("JDFDevCap.getDevCapVector: Attribute DevCapRefs refers to the non-existent DevCap: " + idRefs.stringAt(i));
                  }
               }
            }
            else
            {
               throw new JDFException("JDFDevCap.getDevCapVector: Attribute DevCapRefs refers to the non-existent DevCapPool");
            }
         }
         if (bDirect == false)
         {
            for (int i = preFill; i < vDevCap.Count; i++)
            {
               JDFDevCap dcChild = (JDFDevCap)vDevCap[i];
               vDevCap = dcChild.getDevCapVector(vDevCap, bDirect);
            }
         }
         return vDevCap;
      }

      ///   
      ///	 <summary> * Tests if the attributes and subelements of the given element match the
      ///	 * corresponding States and DevCap subelements of this DevCap.<br>
      ///	 * Composes a detailed report of the found errors in XML form. If XMLDoc
      ///	 * equals null - there are no errors
      ///	 *  </summary>
      ///	 * <param name="e">
      ///	 *            element to test </param>
      ///	 * <param name="testlists">
      ///	 *            FitsValue_Allowed or FitsValue_Present testlists that are
      ///	 *            specified for the State elements. (Will be used in fitsValue
      ///	 *            method of the State element) </param>
      ///	 * <param name="level">
      ///	 *            validation level </param>
      ///	 * <returns> XMLDoc - XMLDoc output of the error messages. If XMLDoc is
      ///	 *         <code>null</code> there are no errors.<br>
      ///	 *         Element <code>e</code> fits the corresponding States and DevCap
      ///	 *         subelements of this DevCap. </returns>
      ///	 
      public KElement stateReport(KElement e, EnumFitsValue testlists, EnumValidationLevel level, bool ignoreExtensions, bool bRecurse, KElement parentReport)
      {
         bool bRecurseLocal = bRecurse;
         KElement parentReportLocal = parentReport;

         // 'e' in DeviceCapabilities is described by this DevCap

         // first test if there are any subelements of 'e' that are not described
         // by DevCap
         if (!(e is JDFNode) && !ignoreExtensions)
         {
            missingDevCap(e, parentReportLocal);
         }

         // DevCap contains: (1) description of parts;
         // (2) description of subelements;
         // (3) description of attributes

         // (1) Test Partition Leaves: 'e' - is partitioned, its leaves must be
         // described by 'this' DevCap
         if (e is JDFResource && bRecurseLocal)
         {
            JDFResource res = (JDFResource)e;
            JDFResource resourceRoot = res.getResourceRoot();
            if (resourceRoot.hasAttribute_KElement(AttributeName.PARTIDKEYS, null, false))
            {
               VElement vLeaves = res.getLeaves(!EnumPartUsage.Explicit.Equals(resourceRoot.getPartUsage()));

               int size = vLeaves.Count;
               for (int i = 0; i < size; i++)
               {
                  JDFResource leaf = (JDFResource)vLeaves[i];
                  KElement p = parentReportLocal.appendElement("InvalidPartitionLeaf");
                  KElement partTestResult = stateReport(leaf, testlists, level, ignoreExtensions, false, p);
                  if (partTestResult != null)
                  {
                     string path = leaf.buildXPath(null, 1);
                     p.setAttribute("XPath", path);
                     string leafPath = path.Substring(res.buildXPath(null, 1).Length);
                     p.setAttribute("LeafXPath", res.Name + leafPath);
                  }
                  else
                  {
                     p.deleteNode();
                  }
               }
            }
            else
            {
               bRecurseLocal = false; // not partitioned - just pass through e
            }
         }
         else
         {
            bRecurseLocal = false;
         }

         if (!bRecurseLocal)
         {
            subelementsTest(e, testlists, level, ignoreExtensions, parentReportLocal);

            // (3) Test Attributes, Spans and Comments - described by States
            spanAndAttributesTest(e, testlists, level, ignoreExtensions, parentReportLocal);
         }
         if (!parentReportLocal.hasChildElements())
         {
            parentReportLocal = null;
         }
         return parentReportLocal;
      }

      ///   
      ///	 <summary> * Tests subelements of the element <code>e</code> whether they fit the
      ///	 * corresponding DevCap elements of <code>this</code>.<br>
      ///	 * ! Recursively returns to stateReport to test the attributes of the
      ///	 * subelements.<br>
      ///	 * Composes a detailed report of the found errors in XML form. <br>
      ///	 * If XMLDoc is <code>null</code> there are no errors.
      ///	 *  </summary>
      ///	 * <param name="testElem">
      ///	 *            element to test </param>
      ///	 * <param name="testlists">
      ///	 *            FitsValue_Allowed or FitsValue_Present testlists that are
      ///	 *            specified for the State elements. (Will be used in fitsValue
      ///	 *            method of the State element.) </param>
      ///	 * <param name="level">
      ///	 *            validation level </param>
      ///	 * <returns> XMLDoc - XMLDoc output of the error messages. If XMLDoc equals
      ///	 *         null - there are no errors, 'e' fits the corresponding DevCap
      ///	 *         elements of 'this' DevCap </returns>
      ///	 
      private KElement subelementsTest(KElement testElem, EnumFitsValue testlists, EnumValidationLevel level, bool ignoreExtensions, KElement parentReport)
      {
         KElement parentReportLocal = parentReport;

         VElement vDevCap = getDevCapVector(null, true); // vDevCap - contains
         // DevCap elements of
         // this DevCap

         SupportClass.HashSetSupport goodElems = new SupportClass.HashSetSupport();
         Hashtable badElems = new Hashtable();

         for (int k = 0; k < vDevCap.Count; k++)
         { // if there are any DevCap subelements in this DavCap
            // then element e must have subelements, and we are going to check
            // them first
            JDFDevCap dc = (JDFDevCap)vDevCap[k];
            string dcName = dc.getName();
            EnumAvailability av = dc.getModuleAvailability();
            if (!EnumAvailability.Installed.Equals(av))
               continue;

            // vElem - direct children of the Node.
            // If 'dcName' is a partition Leaf - gets only children of the Leaf.
            VElement vElem = dc.getMatchingElementsFromParent(testElem, vDevCap);

            int occurs = vElem == null ? 0 : vElem.Count;
            KElement r;
            int minOccurs = dc.getMinOccurs();
            int maxOccurs = dc.getMaxOccurs();
            if (occurs > maxOccurs && vElem != null)
            {
               for (int j = 0; j < occurs; j++)
               {
                  KElement subEl = vElem.item(j);
                  r = parentReportLocal.appendElement("InvalidElement");
                  r.setAttribute("CapXPath", dc.getNamePath(true));
                  r.setAttribute("XPath", subEl.buildXPath(null, 1));
                  r.setAttribute("Name", dcName);
                  r.setAttribute("Message", "Element occurrence exceeds value of MaxOccurs");
                  r.setAttribute("MaxOccurs", maxOccurs, null); // MaxOccurs
                  r.setAttribute("FoundElements", occurs, null);
               }
            }
            else if (occurs < minOccurs && EnumValidationLevel.isRequired(level))
            {
               r = parentReportLocal.appendElement("MissingElement");
               r.setAttribute("CapXPath", dc.getNamePath(true));
               r.setAttribute("XPath", testElem.buildXPath(null, 1) + "/" + dcName);
               r.setAttribute("Name", dcName);
               r.setAttribute("Message", "Element occurrence is less than value of MinOccurs");
               r.setAttribute("MinOccurs", minOccurs, null);
               r.setAttribute("FoundElements", occurs, null);
            }

            if (vElem != null)
            {
               // there were elements that didn't pass some of the tests - assume
               // that these are actually invalid and report on them
               for (int j = 0; j < occurs; j++)
               {
                  KElement subEl = vElem.item(j);
                  if (goodElems.Contains(subEl))
                     continue;
                  r = parentReportLocal.appendElement("InvalidElement");
                  KElement recursionResult = dc.stateReport(subEl, testlists, level, ignoreExtensions, true, r);

                  if (recursionResult == null)
                  {
                     goodElems.Add(subEl);
                     KElement badReport = (KElement)badElems[subEl];
                     if (badReport != null)
                        badReport.deleteNode();
                  }
                  else
                  {
                     recursionResult.appendAttribute("DevCapRefs", dc.getID(), null, " ", true);
                     badElems.Add(subEl, recursionResult);
                  }

                  if (recursionResult != null)
                  {
                     r.setAttribute("CapXPath", dc.getNamePath(true));
                     r.setAttribute("XPath", subEl.buildXPath(null, 1));
                     r.setAttribute("Name", dcName);
                  }
                  else
                  {
                     r.deleteNode();
                  }
               }
            }
         }

         if (!parentReportLocal.hasChildElements())
         {
            parentReportLocal = null;
         }

         return parentReportLocal;
      }

      ///   
      ///	 <summary> * Tests attributes and span elements (if <code>e</code> is a intent
      ///	 * resource) of the element <code>e</code>.<br>
      ///	 * Checks whether they fit the corresponding State elements of
      ///	 * <code>this</code>.<br>
      ///	 * Composes a detailed report of the errors found in XML form. If XMLDoc is
      ///	 * <code>null</code> there are no errors.
      ///	 *  </summary>
      ///	 * <param name="e">
      ///	 *            element to test </param>
      ///	 * <param name="testlists">
      ///	 *            FitsValue_Allowed or FitsValue_Present testlists that are
      ///	 *            specified for the State elements. (Will be used in fitsValue
      ///	 *            method of the State element.) </param>
      ///	 * <param name="level">
      ///	 *            validation level </param>
      ///	 * <returns> XMLDoc - XMLDoc output of the error messages. If XMLDoc is
      ///	 *         <code>null</code> there are no errors, <code>e</code> fits the
      ///	 *         corresponding State elements of <code>this</code> </returns>
      ///	 
      private KElement spanAndAttributesTest(KElement e, EnumFitsValue testlists, EnumValidationLevel level, bool ignoreExtensions, KElement parentReport)
      {
         KElement parentReportLocal = parentReport;

         KElement msp = parentReportLocal.appendElement("UnknownAttributes");
         KElement map = parentReportLocal.appendElement("MissingAttributes");
         KElement iap = parentReportLocal.appendElement("InvalidAttributes");

         // vSubElem - contains all subelements of this DevCap
         VElement vStates = getStates(true, null);
         JDFAttributeMap missMap = new JDFAttributeMap();
         JDFAttributeMap capMap = new JDFAttributeMap();

         JDFAttributeMap defMap = getIgnoreDefaults() ? null : e.getDefaultAttributeMap();
         JDFAttributeMap am = new JDFAttributeMap(defMap);
         am.putAll(e.getAttributeMap()); // only attribute map of 'e'
         JDFAttributeMap m = getSpanAndAttributesMap(e); // get of 'e' as a map
         // of attributes: (1)
         // all attributes,
         // (2) span key-values (in case of intent resource), (3) comments
         VString vKeys = m.getKeys(); // we'll use "keys" to find the appropriate
         // State elements in DevCap

         if (vStates != null)
         {
            int sizeStates = vStates.Count;
            for (int j = 0; j < sizeStates; j++) // SubElem can be DevCap, can be
            // Loc, can be any State element
            { // here we need only States
               JDFAbstractState state = (JDFAbstractState)vStates.item(j);
               string nam = state.getName();
               EnumAvailability av = state.getModuleAvailability();
               if (!EnumAvailability.Installed.Equals(av))
                  continue;

               int size = vKeys.Count;
               for (int i = size - 1; i >= 0; i--)
               {
                  string key = vKeys[i];
                  if (nam.Equals(key) || (key.Equals("CommentText") && nam.Length == 0)) // if
                  // name
                  // is
                  // absent
                  // -
                  // state
                  // describes
                  // a
                  // Comment
                  {
                     string @value = nam.Length != 0 ? m.get(key) : m.get("CommentText");
                     if (!state.fitsValue(@value, testlists))
                     { // The attribute/span was found but it has the wrong value

                        KElement r;
                        if (!am.ContainsKey(key) && !key.Equals("CommentText")) // it
                        // is
                        // Span
                        // but
                        // not
                        // Attribute
                        {
                           r = iap.appendElement("InvalidSpan");
                           r.setAttribute("XPath", e.buildXPath(null, 1) + "/" + key);
                           r.setAttribute("Message", "Span value doesn't fit this State description");
                        }
                        else if (key.Equals("CommentText"))
                        {
                           r = iap.appendElement("InvalidComment");
                           r.setAttribute("XPath", e.buildXPath(null, 1) + "/" + key);
                           r.setAttribute("Message", "Comment doesn't fit this State description");
                        }
                        else
                        {
                           r = iap.appendElement("InvalidAttribute");
                           r.setAttribute("XPath", e.buildXPath(null, 1) + "/@" + key);
                           r.setAttribute("Message", "Attribute value doesn't fit this State description");
                        }

                        r.setAttribute("Name", key);
                        r.setAttribute("CapXPath", state.getNamePath());
                        r.setAttribute("Value", @value);
                        r.copyElement(state, null);

                     }

                     vKeys.RemoveAt(i); // The attribute/span was found,
                     // checked, so we don't need it
                     // any more in vKeys
                     break; // go to next State
                  }
               }

               if ((size == vKeys.Count) && state.getRequired() && EnumValidationLevel.isRequired(level))
               { // No attribute/span found but state is required

                  if (state.getListType().Equals(EnumListType.Span))
                  {
                     missMap.put(nam, "Span");
                  }
                  else
                  {
                     missMap.put(nam, "Attribute");
                  }
                  capMap.put(nam, state.getNamePath());
               }
            }
         }

         EnumValidationLevel l2 = level;
         if (e is JDFResource)
         {
            if (EnumResStatus.Incomplete.Equals(((JDFResource)e).getResStatus(false)))
               l2 = EnumValidationLevel.incompleteLevel(level);
         }

         if (EnumValidationLevel.isRequired(l2))
         {
            VString missAts = e.getMissingAttributes(9999999);
            for (int i = 0; i < missAts.Count; i++)
               missMap.put(missAts.stringAt(i), "Attribute");
            missAts = e.getMissingElements(99999);
            for (int i = 0; i < missAts.Count; i++)
            {
               string stringAt = missAts.stringAt(i);
               if (stringAt.EndsWith("Span"))
                  missMap.put(stringAt, "Span");
            }
         }

         IEnumerator<string> missIt = missMap.getKeyIterator();
         while (missIt.MoveNext())
         { // No attribute/span found but state is required
            string nam = (string)missIt.Current;
            string typ = missMap.get(nam);

            KElement ms = map.appendElement("Missing" + typ);
            ms.setAttribute("Message", "Missing " + typ);
            ms.setAttribute("XPath", e.buildXPath(null, 1) + "/@" + nam);
            string capNamePath = capMap.get(nam);
            if (capNamePath != null)
               ms.setAttribute("CapXPath", capNamePath);
            ms.setAttribute("Name", nam);
         }

         if (!ignoreExtensions)
         {
            for (int x = 0; x < vKeys.Count; x++)
            { // if there are in vKeys still some attibutes, they must be
               // generic attributes
               string key = vKeys[x];

               if (!isGenericAttribute(key) && (defMap == null || !defMap.ContainsKey(key)))
               { // if the rest attributes are not generic -> Node is rejected
                  KElement us;
                  if (!am.ContainsKey(key) && !key.Equals("CommentText"))
                  {
                     us = msp.appendElement("UnknownSpan");
                     us.setAttribute("XPath", e.buildXPath(null, 1) + "/" + key);
                     us.setAttribute("CapXPath", getNamePath(true) + "/" + key);
                  }
                  else
                  {
                     us = msp.appendElement("UnknownAttribute");
                     us.setAttribute("XPath", e.buildXPath(null, 1) + "/@" + key);
                     us.setAttribute("CapXPath", getNamePath(true) + "/@" + key);
                  }
                  us.setAttribute("Name", key);
                  us.setAttribute("Message", "No State description for " + key);
               }
            }
         }

         if (!map.hasChildElements())
            parentReportLocal.removeChild(map);

         if (!iap.hasChildElements())
            parentReportLocal.removeChild(iap);

         if (!msp.hasChildElements())
            parentReportLocal.removeChild(msp);

         if (!parentReportLocal.hasChildElements())
         {
            parentReportLocal = null;
         }

         return parentReportLocal;
      }

      ///   
      ///	 <summary> * Gets a map of Attributes, Comments and Span key-value pairs for
      ///	 * <code>e</code>. All of them must be described as State elements.
      ///	 *  </summary>
      ///	 * <param name="e">
      ///	 *            element to get the attribute map for </param>
      ///	 * <returns> JDFAttributeMap - a map of Attributes, Comments and Span
      ///	 *         key-value pairs </returns>
      ///	 
      private JDFAttributeMap getSpanAndAttributesMap(KElement e)
      {
         JDFAttributeMap defMap = getIgnoreDefaults() ? null : e.getDefaultAttributeMap();
         JDFAttributeMap m = new JDFAttributeMap(defMap);
         m.putAll(e.getAttributeMap()); // only attribute map of 'e'

         if (e is JDFResource)
         {
            JDFResource r = (JDFResource)e; // if 'e' is an Intent Resource
            // add to 'm' a 'spanMap'
            if (r.getResourceClass() == EnumResourceClass.Intent)
            {
               JDFAttributeMap spanMap = getSpanValueMap(r);
               VString vSpanMapKeys = spanMap.getKeys();
               for (int k = 0; k < vSpanMapKeys.Count; k++)
               {
                  string spanKey = vSpanMapKeys[k];
                  m.put(spanKey, spanMap.get(spanKey));
               }
            }
         }
         else if (e is JDFComment)
         {
            JDFComment c = (JDFComment)e;
            m.put("CommentText", c.getText(0));
         }

         return m;
      }

      ///   
      ///	 <summary> * Gets a map of key-value pairs for the intent resource <code>r</code>. The
      ///	 * key of the map is a Span NodeName, the value is a combination of actual,
      ///	 * preferred and range values
      ///	 *  </summary>
      ///	 * <param name="r">
      ///	 *            intent resource to get the SpanValueMap of </param>
      ///	 * <returns> JDFAttributeMap - SpanValueMap </returns>
      ///	 
      private JDFAttributeMap getSpanValueMap(JDFResource r)
      {
         JDFAttributeMap map = new JDFAttributeMap();
         VElement v = r.getChildElementVector(null, null, null, true, 0, false);
         for (int i = 0; i < v.Count; i++)
         {
            KElement el = v.item(i);
            if (el is JDFSpanBase)
            {
               // JDFSpanBase span = (JDFSpanBase) el;
               // String value = span.getValue();

               string @value = el.hasAttribute(AttributeName.ACTUAL) ? el.getAttribute(AttributeName.ACTUAL) : el.getAttribute(AttributeName.PREFERRED);

               if (@value.Length == 0)
                  @value = el.getAttribute(AttributeName.RANGE);

               map.put(el.Name, @value);
            }
         }
         return map;
      }

      ///   
      ///	 <summary> * Tests if there are any subelements of the element elem that are not
      ///	 * described by DevCap.<br>
      ///	 * Composes a detailed report of the found errors in XML form. If XMLDoc is
      ///	 * <code>null</code> there are no errors.
      ///	 *  </summary>
      ///	 * <param name="elem">
      ///	 *            element to test </param>
      ///	 * <returns> KElement - output of the error messages. If XMLDoc is
      ///	 *         <code>null</code> there are no errors. </returns>
      ///	 
      private KElement missingDevCap(KElement elem, KElement parentReport)
      {
         KElement root = parentReport.appendElement("UnknownElements");
         VElement vDevCap = getDevCapVector(null, true);

         VElement vSubElem = elem.getChildElementVector(null, null, null, true, 0, true); // follows the refelements
         // for every one child of the 'elem' we look for the corresponding
         // DevCap description
         for (int i = 0; i < vSubElem.Count; i++)
         {
            KElement e = vSubElem.item(i);
            if (e is JDFSpanBase)
            {
               continue; // Spans are described as State elements not as DevCap
            }
            else if (e is JDFNode)
            {
               continue; // nodes are described as high level DevCaps
            }
            else
            {
               string nam = e.Name; // we are looking for DevCap whose
               // atr_Name is equal 'nam'
               bool bFound = false;
               EnumAvailability foundAv = null;

               for (int k = 0; k < vDevCap.Count; k++)
               {
                  JDFDevCap devCap = (JDFDevCap)vDevCap[k];
                  if (devCap.getName().Equals(nam)) // getName() as default
                  // takes the name of a
                  // parent DevCaps
                  {
                     EnumAvailability moduleAvailability = devCap.getModuleAvailability();
                     if (EnumAvailability.Installed.Equals(moduleAvailability))
                     {
                        bFound = true;
                        break;
                     }
                     else if (foundAv == null)
                     {
                        foundAv = moduleAvailability;
                     }
                     else if (moduleAvailability != null && foundAv.getValue() < moduleAvailability.getValue())
                     {
                        foundAv = moduleAvailability;
                     }
                  }
               }
               if (!bFound)
               {
                  KElement us = root.appendElement("UnknownElement");
                  us.setAttribute("XPath", e.buildXPath(null, 1));
                  us.setAttribute("CapXPath", getNamePath(false) + JDFConstants.SLASH + nam);
                  us.setAttribute("Name", nam);
                  us.setAttribute("Message", "Found no DevCap description for this element");
                  us.setAttribute("Availability", foundAv == null ? "None" : foundAv.getName());
               }
            }
         }

         if (!root.hasChildElements())
         {
            root.deleteNode();
            root = null;
         }
         return root;
      }

      ///   
      ///	 <summary> * Checks if the attributes key of the tested element is a generic
      ///	 * attribute. (Gets this attribute of DeviceCap element)
      ///	 *  </summary>
      ///	 * <param name="key">
      ///	 *            attribute key to test </param>
      ///	 * <returns> boolean - true if the key is a generic attribute </returns>
      ///	 
      private bool isGenericAttribute(string key)
      {
         if (key == null)
            return true;
         if (key.StartsWith(AttributeName.XMLNS))
            return true;

         KElement deviceCap = getDeepParent(ElementName.DEVICECAP, 0);
         if (deviceCap == null)
            deviceCap = getDeepParent(ElementName.MESSAGESERVICE, 0);
         if (deviceCap == null)
            return false;

         VString s = new VString(StringUtil.tokenize(deviceCap.getAttribute(AttributeName.GENERICATTRIBUTES), " ", false));
         return s != null && (s.Contains(key) || s.Contains("*"));
      }

      ///   
      ///	 <summary> * Gets the NamePath of this DevCap in form
      ///	 * "DevCapsName/SubelemName1/SubelemName2/..."<br>
      ///	 * If this DevCap is located in DevCapPool and not in a DevCaps - it
      ///	 * describes the reusable resource and DevCap root will have the attribute
      ///	 * "Name" = value of DevCaps/@Name, but will have no info about
      ///	 * DevCaps/@Context or DevCaps/@LinkUsage
      ///	 * <p>
      ///	 * default: getNamePath(false)
      ///	 *  </summary>
      ///	 * <param name="bRecurse">
      ///	 *            if true, returns "DevCapsName/SubelemName1/SubelemName2/..." </param>
      ///	 * <returns> String - NamePath of this DevCap </returns>
      ///	 
      public string getNamePath(bool bRecurse)
      {
         VString paths = getNamePathVector(bRecurse);
         if (paths == null || paths.Count < 1)
            return null;
         return paths.stringAt(0);

      }

      public virtual VString getNamePathVector()
      {
         return getNamePathVector(true);
      }

      ///   
      ///	 <summary> * Gets the NamePath of this DevCap in form
      ///	 * "DevCapsName/SubelemName1/SubelemName2/..."<br>
      ///	 * If this DevCap is located in DevCapPool and not in a DevCaps - it
      ///	 * describes the reusable resource and DevCap root will have the attribute
      ///	 * "Name" = value of DevCaps/@Name, but will have no info about
      ///	 * DevCaps/@Context or DevCaps/@LinkUsage
      ///	 *  </summary>
      ///	 * <param name="bRecurse">
      ///	 *            if true, returns "DevCapsName/SubelemName1/SubelemName2/..." </param>
      ///	 * <returns> String - NamePath of this DevCap, null if no name is specified
      ///	 * 
      ///	 *         default: getNamePath(true) </returns>
      ///	 
      public VString getNamePathVector(bool bRecurse)
      {
         string result = getName();
         VString vResult = null;
         if (result == null)
            return null;

         KElement parentNode = getParentNode_KElement();

         if (parentNode is JDFDevCap)
         { // subsub elem - always recurse
            JDFDevCap devCap = (JDFDevCap)parentNode;
            vResult = devCap.getNamePathVector(bRecurse);
         } // if DevCap is located
         else if (parentNode is JDFDevCapPool)
         // in DevCapPool it is
         // reusable and there
         // are no info from
         // DevCaps
         // (Context,LinkUsage)
         {
            if (bRecurse)
            {
               string id = getID();
               if (!id.Equals(""))
               {
                  VElement v = parentNode.getChildrenByTagName("DevCap", null, null, false, true, 0);
                  KElement deviceCap = parentNode.getParentNode_KElement();

                  for (int i = 0; i < v.Count; i++)
                  {
                     JDFDevCap dc = (JDFDevCap)v[i];
                     VString refs = dc.getDevCapRefs();
                     if (refs.Contains(id))
                     {
                        if (vResult == null)
                           vResult = new VString();
                        string dcID = dc.getAttribute(AttributeName.ID, null, null);
                        JDFDevCaps dcs = (JDFDevCaps)(dcID == null ? null : deviceCap.getChildWithAttribute(ElementName.DEVCAPS, AttributeName.DEVCAPREF, null, dcID, 0, true));
                        if (dcs != null)
                        {
                           vResult.appendUnique(dcs.getNamePathVector());
                        }
                        else
                        {
                           vResult.appendUnique(dc.getNamePathVector(bRecurse));
                        }
                     }
                  }
                  JDFDevCaps dcs2 = (JDFDevCaps)deviceCap.getChildWithAttribute(ElementName.DEVCAPS, AttributeName.DEVCAPREF, null, id, 0, true);
                  if (dcs2 != null)
                  {
                     VString vResult2 = dcs2.getNamePathVector();
                     if (vResult == null)
                     {
                        vResult = vResult2;
                     }
                     else
                     {
                        StringUtil.concatStrings(vResult, "/" + result);
                        vResult.appendUnique(vResult2);
                     }
                     return vResult;
                  }
                  // TODO mixed mode devcaps subelements + devcappool
               }
            }
         } // need to add jdf in case
         else if (parentNode is JDFDevCaps)
         // of Context="Element"
         // or Context="JDF"
         {
            JDFDevCaps devCaps = (JDFDevCaps)parentNode;
            vResult = devCaps.getNamePathVector();
            return vResult; // return here directly because the first devCap in
            // the tree repeats the name of the devCaps
         }
         if (vResult == null)
         {
            vResult = new VString();
            vResult.Add(result);
         }
         else
         {
            StringUtil.concatStrings(vResult, "/" + result);
         }
         return vResult;
      }

      ///   
      ///	 <summary> * gets String attribute Name, inherits from devcap or devcaps if necessary
      ///	 *  </summary>
      ///	 * <returns> String - the value of the attribute </returns>
      ///	 
      public override string getName()
      {
         string s = getAttribute(AttributeName.NAME, null, null);
         if (s == null)
         {
            KElement parentNode = getParentNode_KElement();
            if (parentNode is JDFDevCaps)
            {
               JDFDevCaps devCaps = (JDFDevCaps)ParentNode;
               s = devCaps.getName();
            }
            else if (parentNode is JDFDevCap)
            {
               JDFDevCap devCap = (JDFDevCap)ParentNode;
               s = devCap.getName();
            }
            else if (parentNode is JDFDevCapPool)
            {
               string id = getID();
               if (!id.Equals(""))
               {
                  JDFDeviceCap dec = (JDFDeviceCap)parentNode.ParentNode;
                  JDFDevCaps dcs = (JDFDevCaps)dec.getChildWithAttribute(ElementName.DEVCAPS, AttributeName.DEVCAPREF, null, id, 0, true);
                  if (dcs != null)
                     s = dcs.getName();

               }
            }
         }
         return s;
      }

      ///   
      ///	 <summary> * return the vector of all states
      ///	 *  </summary>
      ///	 * <param name="bDirect">
      ///	 *            if false, recurse into child elements, else return only direct
      ///	 *            child states </param>
      ///	 * <param name="id">
      ///	 *            ID attribute of the requested string </param>
      ///	 * <returns> VElement </returns>
      ///	 
      public virtual VElement getStates(bool bDirect, string id)
      {
         JDFAttributeMap m = null;
         if (id != null)
         {
            m = new JDFAttributeMap(AttributeName.ID, id);
         }
         VElement v = null;
         if (bDirect == true)
         {
            v = getChildrenByTagName(null, null, m, bDirect, true, 0);
            for (int i = v.Count - 1; i >= 0; i--)
            {
               if (!(v[i] is JDFAbstractState))
                  v.RemoveAt(i);
            }
         }
         else
         {
            v = new VElement();
            VElement vdevCap = getDevCapVector(null, false);
            for (int i = 0; i < vdevCap.Count; i++)
            {
               JDFDevCap child = (JDFDevCap)vdevCap[i];
               v.appendUnique(child.getStates(true, id));
            }
         }
         return v;
      }

      ///   
      ///	 <summary> * Sets attribute <code>MaxOccurs</code>, also handles unbounded
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            the value to set the attribute to </param>
      ///	 
      public override void setMaxOccurs(int @value)
      {
         if (@value == int.MaxValue)
         {
            setAttribute(AttributeName.MAXOCCURS, JDFConstants.POSINF, null);
         }
         else
         {
            setAttribute(AttributeName.MAXOCCURS, @value, null);
         }
      }

      ///   
      ///	 <summary> * Gets integer attribute <code>MaxOccurs</code>, also handles unbounded
      ///	 *  </summary>
      ///	 * <returns> int: the attribute value </returns>
      ///	 
      public override int getMaxOccurs()
      {
         string s = getAttribute(AttributeName.MAXOCCURS, null, null);
         if (JDFConstants.UNBOUNDED.Equals(s))
            return int.MaxValue;
         return StringUtil.parseInt(s, 1);
      }

      ///   
      ///	 <summary> * gets the matching elements in the node that match <code>this</code>
      ///	 *  </summary>
      ///	 * <param name="node">
      ///	 *            the node to search in </param>
      ///	 * <param name="testValidity">
      ///	 *            if true, recusively check for validity of the elements, else
      ///	 *            only get children by name
      ///	 *  </param>
      ///	 * <returns> VElement - the element vector of matching elements,
      ///	 *         <code>null</code> if none were found </returns>
      ///	 
      public virtual VElement getMatchingElementsFromParent(KElement parent, VElement vDevCap)
      {
         VElement v = getAllMatchingElementsFromParent(parent);
         if (v == null)
            return null;

         string _name = getName();
         VElement vOther = new VElement();
         if (vDevCap != null)
         {
            for (int i = 0; i < vDevCap.Count; i++)
            {
               JDFDevCap dcOther = (JDFDevCap)vDevCap[i];
               if (dcOther == this)
                  continue;
               if (!_name.Equals(dcOther.getName()))
                  continue;
               VElement vOtherMatch = dcOther.getAllMatchingElementsFromParent(parent);
               if (vOtherMatch == null)
                  continue;
               vOther.Add(dcOther);
            }
         }
         if (vOther.Count == 0) // no other elements that we have to worry about
            return v;

         XMLDoc doc = new XMLDoc("dummy", null);
         KElement repRootDummy = doc.getRoot();
         for (int i = v.Count - 1; i >= 0; i--)
         {
            KElement e = v.item(i);

            repRootDummy.flush();
            if (spanAndAttributesTest(e, EnumFitsValue.Allowed, EnumValidationLevel.Incomplete, true, repRootDummy) != null || subelementsTest(e, EnumFitsValue.Allowed, EnumValidationLevel.Incomplete, true, repRootDummy) != null)
            {
               // check if an element fits to a different devcap in this, if so
               // remove it from the check
               for (int j = 0; j < vOther.Count; j++)
               {
                  repRootDummy.flush();
                  JDFDevCap dcOther = (JDFDevCap)vOther[j];
                  if (dcOther.spanAndAttributesTest(e, EnumFitsValue.Allowed, EnumValidationLevel.Incomplete, true, repRootDummy) == null && dcOther.subelementsTest(e, EnumFitsValue.Allowed, EnumValidationLevel.Incomplete, true, repRootDummy) == null)
                  {
                     v.RemoveAt(i);
                     break; // j
                  }
               }
            }
         }
         return v.Count != 0 ? v : null;
      }

      ///   
      ///	 <summary> * gets the matching elements in the node that match the nodename of this
      ///	 *  </summary>
      ///	 * <param name="node">
      ///	 *            the node to search in </param>
      ///	 * <returns> VElement - the element vector of matching elements,
      ///	 *         <code>null</code> if none were found </returns>
      ///	 
      public virtual VElement getAllMatchingElementsFromParent(KElement parent)
      {
         string nam = getName();
         JDFAttributeMap map = null;
         if (parent is JDFJMF)
         {
            JDFNameState ns = getNameState(AttributeName.TYPE);
            if (ns != null)
            {
               VString valList = ns.getAllowedValueList();
               if (valList != null)
               {
                  map = new JDFAttributeMap(AttributeName.TYPE, valList.stringAt(0));
               }
            }
         }

         VElement subElems = parent.getChildElementVector(nam, null, map, true, 999999, true);
         return subElems.Count == 0 ? null : subElems;
      }

      ///   
      ///	 <summary> * sets the element and attribute defaults
      ///	 *  </summary>
      ///	 * <param name="element">
      ///	 *            the element that is defaulted </param>
      ///	 * <param name="bAll">
      ///	 *            if false, only add if minOccurs>=1 and required=true or a
      ///	 *            default exists </param>
      ///	 * <returns> ignored </returns>
      ///	 
      public virtual bool setDefaultsFromCaps(KElement element, bool bAll)
      {
         bool success = false;
         if (element is JDFResource)
         {
            JDFResource r = (JDFResource)element;
            if (!r.isLeaf())
            {
               VElement vR = r.getLeaves(false);
               for (int i = 0; i < vR.Count; i++)
               {
                  success = setDefaultsFromCaps(vR.item(i), bAll) || success;
               }
               return success;
            }
         }
         // default leaf or element case -
         VElement vSubDevCap = null;
         try
         {
            vSubDevCap = getDevCapVector(null, true);
         }
         catch (JDFException)
         {
            return false;
         }
         for (int i = 0; i < vSubDevCap.Count; i++)
         {
            JDFDevCap subDevCap = (JDFDevCap)vSubDevCap[i];
            int minOccurs = subDevCap.getMinOccurs();
            if (minOccurs == 0 && bAll)
               minOccurs = 1;
            VElement subElms = subDevCap.getMatchingElementsFromParent(element, vSubDevCap);
            if (minOccurs > 0)
            {
               int occurs = subElms == null ? 0 : subElms.Count;
               if (occurs < minOccurs && subElms == null)
                  subElms = new VElement();

               if (subElms != null)
               {
                  for (int ii = occurs; ii < minOccurs; ii++)
                  {
                     string id = subDevCap.getID();
                     KElement isThere = id == null ? null : element.getOwnerDocument_KElement().getRoot().getTarget(id, AttributeName.ID);
                     if (!(isThere is JDFResource) || !(element is JDFElement))
                     {
                        KElement newSub = element.appendElement(subDevCap.getName(), subDevCap.getDevNS());
                        subElms.Add(newSub);
                     }
                     else
                     {
                        JDFRefElement re = ((JDFElement)element).refElement((JDFResource)isThere);
                        subElms.Add(re.getTarget());
                     }

                     success = true;
                  }
               }
            }

            if (subElms != null)
            {
               int subSize = subElms.Count;
               for (int ii = 0; ii < subSize; ii++)
               {
                  success = subDevCap.setDefaultsFromCaps(subElms.item(ii), bAll) || success;
               }
            }
         }

         // states
         VElement vStates = getStates(true, null);
         for (int i = 0; i < vStates.Count; i++)
         {
            JDFAbstractState state = (JDFAbstractState)vStates[i];
            success = state.setDefaultsFromCaps(element, bAll) || success;
         }

         return false;
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see
      //	 * org.cip4.jdflib.core.JDFElement#getInvalidAttributes(org.cip4.jdflib.
      //	 * core.KElement.EnumValidationLevel, boolean, int)
      //	 
      public override VString getInvalidAttributes(EnumValidationLevel level, bool bIgnorePrivate, int nMax)
      {
         VString vs = base.getInvalidAttributes(level, bIgnorePrivate, nMax);
         if (nMax > 0 && vs.Count > nMax)
            return vs;

         if (EnumValidationLevel.isRecursive(level) && !vs.Contains(AttributeName.DEVCAPREFS) && hasAttribute(AttributeName.DEVCAPREFS))
         {
            JDFDeviceCap deviceCap = (JDFDeviceCap)getDeepParent(ElementName.DEVICECAP, 0);
            JDFDevCapPool devCapPool = deviceCap == null ? null : deviceCap.getDevCapPool();
            if (devCapPool == null)
            {
               vs.Add(AttributeName.DEVCAPREFS);
               return vs;
            }
            VString idRefs = getDevCapRefs();
            for (int i = 0; i < idRefs.Count; i++)
            {
               JDFDevCap devCap = devCapPool.getDevCap(idRefs.stringAt(i));
               if (devCap == null)
               {
                  vs.Add(AttributeName.DEVCAPREFS);
                  return vs;
               }
            }
         }
         string nam = getName();
         if (!vs.Contains(AttributeName.NAME) && nam != null && getDevNS().Equals(JDFElement.getSchemaURL()))
         {
            nam = KElement.xmlnsLocalName(nam);
            JDFDoc tmpDoc = new JDFDoc(nam);
            KElement tmpRoot = tmpDoc.getRoot();
            if (typeof(JDFElement).Equals(tmpRoot.GetType()))
            {
               vs.Add(AttributeName.DEVNS); // the element is not a known jdf
               // resource
            }
         }
         return vs;
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.ifaces.IModuleCapability#getModulePool()
      //	 
      public virtual JDFModulePool getModulePool()
      {
         return (JDFModulePool)getParentPool(ElementName.MODULEPOOL);
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.ifaces.IModuleCapability#getModulePool()
      //	 
      public virtual JDFModulePool getCreateModulePool()
      {
         return (JDFModulePool)getCreateParentPool(ElementName.MODULEPOOL);
      }

      ///   
      ///	 <summary> * get the availability of this devcaps based on the list of installed
      ///	 * modules in ModuleRefs and ModulePool
      ///	 * 
      ///	 * @return </summary>
      ///	 
      public virtual EnumAvailability getModuleAvailability()
      {
         return JDFModulePool.getModuleAvailability(this);
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see
      //	 * org.cip4.jdflib.ifaces.IModuleCapability#appendModuleRef(java.lang.String
      //	 * )
      //	 
      public virtual JDFModuleCap appendModuleRef(string id)
      {
         return JDFModulePool.appendModuleRef(this, id);
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.ifaces.ICapabilityElement#getEvaluationType()
      //	 
      public virtual EnumTerm getEvaluationType()
      {
         return EnumTerm.IsPresentEvaluation;
      }
   }
}
