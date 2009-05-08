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


/*
 * ==========================================================================
 * class JDFDeviceInfo extends JDFResource
 * ==========================================================================
 * @COPYRIGHT Heidelberger Druckmaschinen AG, 1999-2001
 * ALL RIGHTS RESERVED
 * @Author: sabjon@topmail.de   using a code generator
 * Warning! very preliminary test version. Interface subject to change without prior notice!
 * Revision history:    ... 
 */

namespace org.cip4.jdflib.jmf
{
   using System;


   using JDFAutoDeviceInfo = org.cip4.jdflib.auto.JDFAutoDeviceInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using JDFDevice = org.cip4.jdflib.resource.JDFDevice;
   using JDFModulePhase = org.cip4.jdflib.resource.JDFModulePhase;
   using JDFPhaseTime = org.cip4.jdflib.resource.JDFPhaseTime;
   using JDFEmployee = org.cip4.jdflib.resource.process.JDFEmployee;
   using JDFMISDetails = org.cip4.jdflib.resource.process.JDFMISDetails;
   using ContainerUtil = org.cip4.jdflib.util.ContainerUtil;
   using JDFDate = org.cip4.jdflib.util.JDFDate;
   using StringUtil = org.cip4.jdflib.util.StringUtil;

   //----------------------------------
   public class JDFDeviceInfo : JDFAutoDeviceInfo
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFDeviceInfo
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFDeviceInfo(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFDeviceInfo
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFDeviceInfo(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFDeviceInfo
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFDeviceInfo(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      ///   
      ///	 <summary> * toString()
      ///	 *  </summary>
      ///	 * <seealso cref= org.cip4.jdflib.auto.JDFAutoDeviceInfo#toString() </seealso>
      ///	 
      public override string ToString()
      {
         return "JDFDeviceInfo[  --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * Method getJobCount.
      ///	 *  </summary>
      ///	 * <returns> int </returns>
      ///	 * @deprecated use numChildElements(ElementName.JOBPHASE,null) 
      ///	 
      [Obsolete("use numChildElements(ElementName.JOBPHASE,null)")]
      public virtual int getJobCount()
      {
         return getChildrenByTagName(ElementName.JOBPHASE, null, null, false, true, 0).Count;
      }

      ///   
      ///	 <summary> * (11) set attribute IdleStartTime
      ///	 *  </summary>
      ///	 * <param name="value"> : the value to set the attribute to or null </param>
      ///	 
      public virtual void setIdleStartTime(JDFDate @value)
      {
         JDFDate valueLocal = @value;

         if (valueLocal == null)
            valueLocal = new JDFDate();

         setAttribute(AttributeName.IDLESTARTTIME, valueLocal.DateTimeISO, null);
      }

      ///   
      ///	 <summary> * (12) get JDFDate attribute IdleStartTime
      ///	 *  </summary>
      ///	 * <returns> JDFDate the value of the attribute </returns>
      ///	 
      public virtual JDFDate getIdleStartTime()
      {
         string str = getAttribute(AttributeName.IDLESTARTTIME, null, null);
         if (str != null)
         {
            try
            {
               return new JDFDate(str);
            }
            catch (FormatException)
            {
               // nop
            }
         }
         return null;
      }

      ///   
      ///	 <summary> * create a JobPhase message from a phaseTime Audit
      ///	 *  </summary>
      ///	 * <param name="pt"> the phasetime audit </param>
      ///	 * <returns> JDFJobPhase: the jobphase element that has been filled by the phaseTime </returns>
      ///	 
      public virtual JDFJobPhase createJobPhaseFromPhaseTime(JDFPhaseTime pt)
      {
         JDFJobPhase jp = appendJobPhase();
         JDFNode node = pt.getParentJDF();

         jp.setJobID(node.getJobID(true));
         jp.setJobPartID(StringUtil.getNonEmpty(node.getJobPartID(true)));
         VJDFAttributeMap partMapVector = pt.getPartMapVector();
         jp.setPartMapVector(partMapVector);
         jp.copyAttribute(AttributeName.STATUS, pt);
         jp.copyAttribute(AttributeName.STATUSDETAILS, pt);
         jp.setPhaseStartTime(pt.getStart());
         JDFResourceLink rl = pt.getLink(0);
         if (rl != null)
         {
            if (rl.getAmountPoolAttribute(AttributeName.ACTUALAMOUNT, null, null, 0) != null)
               jp.setPhaseAmount(rl.getActualAmount(null));
         }
         JDFMISDetails md = pt.getMISDetails();
         jp.copyElement(md, null);
         VElement modules = pt.getChildElementVector(ElementName.MODULEPHASE, null);
         if (modules != null)
         {
            int mLen = modules.Count;
            for (int i = 0; i < mLen; i++)
            {
               jp.createModuleStatusFromModulePhase((JDFModulePhase)modules[i]);
            }
         }

         // TODO set more
         jp.eraseEmptyAttributes(true);
         return jp;
      }

      ///   
      ///	 <summary> * gets the deviceID from @DeviceID if it exists, otherwise searches Device/@DeviceID
      ///	 *  </summary>
      ///	 * <returns> the appropriate deviceID for this deviceInfo </returns>
      ///	 
      public override string getDeviceID()
      {
         if (hasAttribute(AttributeName.DEVICEID))
            return base.getDeviceID();
         JDFDevice d = getDevice();
         string ret = d == null ? null : d.getDeviceID();
         if (ret == null)
         {
            KElement km = getParentNode_KElement();
            if (km is JDFMessage)
               ret = ((JDFMessage)km).getSenderID();
         }
         return ret;
      }

      ///   
      ///	 <summary> * returns true if this is the same phase, i.e. the
      ///	 *  </summary>
      ///	 * <param name="lastInfo"> the deviceInfo to compare with </param>
      ///	 * <param name="bExact"> if true, use startTime as hook, else compare stati </param>
      ///	 * <returns> true if same </returns>
      ///	 
      public virtual bool isSamePhase(JDFDeviceInfo lastInfo, bool bExact)
      {
         if (lastInfo == null)
            return false;
         if (!ContainerUtil.Equals(getDeviceID(), lastInfo.getDeviceID()))
            return false;
         if (!ContainerUtil.Equals(getDeviceOperationMode(), lastInfo.getDeviceOperationMode()))
            return false;
         if (!ContainerUtil.Equals(getDeviceStatus(), lastInfo.getDeviceStatus()))
            return false;
         if (!ContainerUtil.Equals(getStatusDetails(), lastInfo.getStatusDetails()))
            return false;
         int numEmployees = numChildElements(ElementName.EMPLOYEE, null);
         if (numEmployees != lastInfo.numChildElements(ElementName.EMPLOYEE, null))
            return false;
         bool bGood = true;
         for (int i = 0; i < numEmployees && bGood; i++)
         {
            JDFEmployee employee = lastInfo.getEmployee(i);
            if (employee != null)
               bGood = bGood && getEmployee(i).matches(employee);

         }
         if (!bGood)
            return false;

         int numJobPhases = numChildElements(ElementName.JOBPHASE, null);
         if (numJobPhases != lastInfo.numChildElements(ElementName.JOBPHASE, null))
            return false;
         bGood = true;

         for (int i = 0; i < numJobPhases; i++)
            bGood = bGood || getJobPhase(i).isSamePhase(lastInfo.getJobPhase(i), bExact);
         return bGood;
      }

      ///   
      ///	 <summary> * creates a new deviceInfo that spans lastphase and this phase
      ///	 *  </summary>
      ///	 * <param name="lastInfo"> the deviceInfo to merge </param>
      ///	 * <returns> true if successful </returns>
      ///	 
      public virtual bool mergeLastPhase(JDFDeviceInfo lastInfo)
      {
         if (!isSamePhase(lastInfo, false))
            return false;

         int numJobPhases = numChildElements(ElementName.JOBPHASE, null);
         bool bGood = true;
         for (int i = 0; i < numJobPhases; i++)
            bGood = getJobPhase(i).mergeLastPhase(lastInfo.getJobPhase(i)) || bGood;
         return bGood;
      }
   }
}
