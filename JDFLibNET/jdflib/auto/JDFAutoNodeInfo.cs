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
   using System.Collections;
   using System.Collections.Generic;


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using VString = org.cip4.jdflib.core.VString;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFJMF = org.cip4.jdflib.jmf.JDFJMF;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFBusinessInfo = org.cip4.jdflib.resource.process.JDFBusinessInfo;
   using JDFEmployee = org.cip4.jdflib.resource.process.JDFEmployee;
   using JDFMISDetails = org.cip4.jdflib.resource.process.JDFMISDetails;
   using JDFNotificationFilter = org.cip4.jdflib.resource.process.JDFNotificationFilter;
   using JDFDate = org.cip4.jdflib.util.JDFDate;
   using JDFDuration = org.cip4.jdflib.util.JDFDuration;

   public abstract class JDFAutoNodeInfo : JDFResource
   {

      private new const long serialVersionUID = 1L;


      ///    
      ///     <summary> * Constructor for JDFAutoNodeInfo </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoNodeInfo(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoNodeInfo </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoNodeInfo(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoNodeInfo </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoNodeInfo(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoNodeInfo[  --> " + base.ToString() + " ]";
      }


      public override bool init()
      {
         bool bRet = base.init();
         setResourceClass(JDFResource.EnumResourceClass.Parameter);
         return bRet;
      }


      public override EnumResourceClass getValidClass()
      {
         return JDFResource.EnumResourceClass.Parameter;
      }


      ///        
      ///        <summary> * Enumeration strings for DueLevel </summary>
      ///        

      public class EnumDueLevel : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumDueLevel(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumDueLevel getEnum(string enumName)
         {
            return (EnumDueLevel)getEnum(typeof(EnumDueLevel), enumName);
         }

         public static EnumDueLevel getEnum(int enumValue)
         {
            return (EnumDueLevel)getEnum(typeof(EnumDueLevel), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumDueLevel));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumDueLevel));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumDueLevel));
         }

         public static readonly EnumDueLevel Unknown = new EnumDueLevel("Unknown");
         public static readonly EnumDueLevel Trivial = new EnumDueLevel("Trivial");
         public static readonly EnumDueLevel Penalty = new EnumDueLevel("Penalty");
         public static readonly EnumDueLevel JobCancelled = new EnumDueLevel("JobCancelled");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute JobPriority
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute JobPriority </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setJobPriority(int @value)
      {
         setAttribute(AttributeName.JOBPRIORITY, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute JobPriority </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getJobPriority()
      {
         return getIntAttribute(AttributeName.JOBPRIORITY, null, 50);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute CleanupDuration
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute CleanupDuration </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCleanupDuration(JDFDuration @value)
      {
         setAttribute(AttributeName.CLEANUPDURATION, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFDuration attribute CleanupDuration </summary>
      ///          * <returns> JDFDuration the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFDuration </returns>
      ///          
      public virtual JDFDuration getCleanupDuration()
      {
         string strAttrName = "";
         JDFDuration nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.CLEANUPDURATION, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute DueLevel
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute DueLevel </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setDueLevel(EnumDueLevel enumVar)
      {
         setAttribute(AttributeName.DUELEVEL, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute DueLevel </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumDueLevel getDueLevel()
      {
         return EnumDueLevel.getEnum(getAttribute(AttributeName.DUELEVEL, null, null));
      }


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
      //        Methods for Attribute FirstEnd
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (11) set attribute FirstEnd </summary>
      ///          * <param name="value">: the value to set the attribute to or null </param>
      ///          
      public virtual void setFirstEnd(JDFDate @value)
      {
         JDFDate date = @value;
         if (date == null)
            date = new JDFDate();
         setAttribute(AttributeName.FIRSTEND, date.DateTimeISO, null);
      }

      ///        
      ///          <summary> * (12) get JDFDate attribute FirstEnd </summary>
      ///          * <returns> JDFDate the value of the attribute </returns>
      ///          
      public virtual JDFDate getFirstEnd()
      {
         JDFDate nMyDate = null;
         string str = JDFConstants.EMPTYSTRING;
         str = getAttribute(AttributeName.FIRSTEND, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute FirstStart
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (11) set attribute FirstStart </summary>
      ///          * <param name="value">: the value to set the attribute to or null </param>
      ///          
      public virtual void setFirstStart(JDFDate @value)
      {
         JDFDate date = @value;
         if (date == null)
            date = new JDFDate();
         setAttribute(AttributeName.FIRSTSTART, date.DateTimeISO, null);
      }

      ///        
      ///          <summary> * (12) get JDFDate attribute FirstStart </summary>
      ///          * <returns> JDFDate the value of the attribute </returns>
      ///          
      public virtual JDFDate getFirstStart()
      {
         JDFDate nMyDate = null;
         string str = JDFConstants.EMPTYSTRING;
         str = getAttribute(AttributeName.FIRSTSTART, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute IPPVersion
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute IPPVersion </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setIPPVersion(JDFXYPair @value)
      {
         setAttribute(AttributeName.IPPVERSION, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute IPPVersion </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getIPPVersion()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.IPPVERSION, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFXYPair(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute LastEnd
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (11) set attribute LastEnd </summary>
      ///          * <param name="value">: the value to set the attribute to or null </param>
      ///          
      public virtual void setLastEnd(JDFDate @value)
      {
         JDFDate date = @value;
         if (date == null)
            date = new JDFDate();
         setAttribute(AttributeName.LASTEND, date.DateTimeISO, null);
      }

      ///        
      ///          <summary> * (12) get JDFDate attribute LastEnd </summary>
      ///          * <returns> JDFDate the value of the attribute </returns>
      ///          
      public virtual JDFDate getLastEnd()
      {
         JDFDate nMyDate = null;
         string str = JDFConstants.EMPTYSTRING;
         str = getAttribute(AttributeName.LASTEND, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute LastStart
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (11) set attribute LastStart </summary>
      ///          * <param name="value">: the value to set the attribute to or null </param>
      ///          
      public virtual void setLastStart(JDFDate @value)
      {
         JDFDate date = @value;
         if (date == null)
            date = new JDFDate();
         setAttribute(AttributeName.LASTSTART, date.DateTimeISO, null);
      }

      ///        
      ///          <summary> * (12) get JDFDate attribute LastStart </summary>
      ///          * <returns> JDFDate the value of the attribute </returns>
      ///          
      public virtual JDFDate getLastStart()
      {
         JDFDate nMyDate = null;
         string str = JDFConstants.EMPTYSTRING;
         str = getAttribute(AttributeName.LASTSTART, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute NaturalLang
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute NaturalLang </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setNaturalLang(string @value)
      {
         setAttribute(AttributeName.NATURALLANG, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute NaturalLang </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getNaturalLang()
      {
         return getAttribute(AttributeName.NATURALLANG, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute NodeStatus
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute NodeStatus </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setNodeStatus(EnumNodeStatus enumVar)
      {
         setAttribute(AttributeName.NODESTATUS, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute NodeStatus </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumNodeStatus getNodeStatus()
      {
         return EnumNodeStatus.getEnum(getAttribute(AttributeName.NODESTATUS, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute NodeStatusDetails
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute NodeStatusDetails </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setNodeStatusDetails(string @value)
      {
         setAttribute(AttributeName.NODESTATUSDETAILS, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute NodeStatusDetails </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getNodeStatusDetails()
      {
         return getAttribute(AttributeName.NODESTATUSDETAILS, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MergeTarget
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MergeTarget </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMergeTarget(bool @value)
      {
         setAttribute(AttributeName.MERGETARGET, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute MergeTarget </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getMergeTarget()
      {
         return getBoolAttribute(AttributeName.MERGETARGET, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Route
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Route </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setRoute(string @value)
      {
         setAttribute(AttributeName.ROUTE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute Route </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getRoute()
      {
         return getAttribute(AttributeName.ROUTE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SetupDuration
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute SetupDuration </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setSetupDuration(JDFDuration @value)
      {
         setAttribute(AttributeName.SETUPDURATION, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFDuration attribute SetupDuration </summary>
      ///          * <returns> JDFDuration the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFDuration </returns>
      ///          
      public virtual JDFDuration getSetupDuration()
      {
         string strAttrName = "";
         JDFDuration nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.SETUPDURATION, null, JDFConstants.EMPTYSTRING);
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


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TargetRoute
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TargetRoute </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTargetRoute(string @value)
      {
         setAttribute(AttributeName.TARGETROUTE, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute TargetRoute </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getTargetRoute()
      {
         return getAttribute(AttributeName.TARGETROUTE, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute TotalDuration
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute TotalDuration </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setTotalDuration(JDFDuration @value)
      {
         setAttribute(AttributeName.TOTALDURATION, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFDuration attribute TotalDuration </summary>
      ///          * <returns> JDFDuration the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFDuration </returns>
      ///          
      public virtual JDFDuration getTotalDuration()
      {
         string strAttrName = "";
         JDFDuration nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.TOTALDURATION, null, JDFConstants.EMPTYSTRING);
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
      //        Methods for Attribute rRefs
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute rRefs </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setrRefs(VString @value)
      {
         setAttribute(AttributeName.RREFS, @value, null);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element BusinessInfo </summary>
      ///     * <returns> JDFBusinessInfo the element </returns>
      ///     
      public virtual JDFBusinessInfo getBusinessInfo()
      {
         return (JDFBusinessInfo)getElement(ElementName.BUSINESSINFO, null, 0);
      }

      ///     <summary> (25) getCreateBusinessInfo
      ///     *  </summary>
      ///     * <returns> JDFBusinessInfo the element </returns>
      ///     
      public virtual JDFBusinessInfo getCreateBusinessInfo()
      {
         return (JDFBusinessInfo)getCreateElement_KElement(ElementName.BUSINESSINFO, null, 0);
      }

      ///    
      ///     <summary> * (29) append element BusinessInfo </summary>
      ///     
      public virtual JDFBusinessInfo appendBusinessInfo()
      {
         return (JDFBusinessInfo)appendElementN(ElementName.BUSINESSINFO, 1, null);
      }

      ///    
      ///     <summary> * (24) const get element Employee </summary>
      ///     * <returns> JDFEmployee the element </returns>
      ///     
      public virtual JDFEmployee getEmployee()
      {
         return (JDFEmployee)getElement(ElementName.EMPLOYEE, null, 0);
      }

      ///     <summary> (25) getCreateEmployee
      ///     *  </summary>
      ///     * <returns> JDFEmployee the element </returns>
      ///     
      public virtual JDFEmployee getCreateEmployee()
      {
         return (JDFEmployee)getCreateElement_KElement(ElementName.EMPLOYEE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Employee </summary>
      ///     
      public virtual JDFEmployee appendEmployee()
      {
         return (JDFEmployee)appendElementN(ElementName.EMPLOYEE, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refEmployee(JDFEmployee refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreateJMF
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFJMF the element </returns>
      ///     
      public virtual JDFJMF getCreateJMF(int iSkip)
      {
         return (JDFJMF)getCreateElement_KElement(ElementName.JMF, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element JMF </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFJMF the element </returns>
      ///     * default is getJMF(0)     
      public virtual JDFJMF getJMF(int iSkip)
      {
         return (JDFJMF)getElement(ElementName.JMF, null, iSkip);
      }

      ///    
      ///     <summary> * Get all JMF from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFJMF> </returns>
      ///     
      public virtual ICollection<JDFJMF> getAllJMF()
      {
         List<JDFJMF> v = new List<JDFJMF>();

         JDFJMF kElem = (JDFJMF)getFirstChildElement(ElementName.JMF, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFJMF)kElem.getNextSiblingElement(ElementName.JMF, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element JMF </summary>
      ///     
      public virtual JDFJMF appendJMF()
      {
         return (JDFJMF)appendElement(ElementName.JMF, null);
      }

      ///    
      ///     <summary> * (24) const get element MISDetails </summary>
      ///     * <returns> JDFMISDetails the element </returns>
      ///     
      public virtual JDFMISDetails getMISDetails()
      {
         return (JDFMISDetails)getElement(ElementName.MISDETAILS, null, 0);
      }

      ///     <summary> (25) getCreateMISDetails
      ///     *  </summary>
      ///     * <returns> JDFMISDetails the element </returns>
      ///     
      public virtual JDFMISDetails getCreateMISDetails()
      {
         return (JDFMISDetails)getCreateElement_KElement(ElementName.MISDETAILS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element MISDetails </summary>
      ///     
      public virtual JDFMISDetails appendMISDetails()
      {
         return (JDFMISDetails)appendElementN(ElementName.MISDETAILS, 1, null);
      }

      ///     <summary> (26) getCreateNotificationFilter
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFNotificationFilter the element </returns>
      ///     
      public virtual JDFNotificationFilter getCreateNotificationFilter(int iSkip)
      {
         return (JDFNotificationFilter)getCreateElement_KElement(ElementName.NOTIFICATIONFILTER, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element NotificationFilter </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFNotificationFilter the element </returns>
      ///     * default is getNotificationFilter(0)     
      public virtual JDFNotificationFilter getNotificationFilter(int iSkip)
      {
         return (JDFNotificationFilter)getElement(ElementName.NOTIFICATIONFILTER, null, iSkip);
      }

      ///    
      ///     <summary> * Get all NotificationFilter from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFNotificationFilter> </returns>
      ///     
      public virtual ICollection<JDFNotificationFilter> getAllNotificationFilter()
      {
         List<JDFNotificationFilter> v = new List<JDFNotificationFilter>();

         JDFNotificationFilter kElem = (JDFNotificationFilter)getFirstChildElement(ElementName.NOTIFICATIONFILTER, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFNotificationFilter)kElem.getNextSiblingElement(ElementName.NOTIFICATIONFILTER, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element NotificationFilter </summary>
      ///     
      public virtual JDFNotificationFilter appendNotificationFilter()
      {
         return (JDFNotificationFilter)appendElement(ElementName.NOTIFICATIONFILTER, null);
      }
   }
}
