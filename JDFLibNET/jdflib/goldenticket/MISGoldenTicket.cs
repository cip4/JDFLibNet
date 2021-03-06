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



namespace org.cip4.jdflib.goldenticket
{
   using System.Collections.Generic;

   using EnumJobDetails = org.cip4.jdflib.auto.JDFAutoStatusQuParams.EnumJobDetails;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFAudit = org.cip4.jdflib.core.JDFAudit;
   using JDFComment = org.cip4.jdflib.core.JDFComment;
   using JDFCustomerInfo = org.cip4.jdflib.core.JDFCustomerInfo;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFNodeInfo = org.cip4.jdflib.core.JDFNodeInfo;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using VString = org.cip4.jdflib.core.VString;
   using EnumVersion = org.cip4.jdflib.core.JDFElement.EnumVersion;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using JDFJMF = org.cip4.jdflib.jmf.JDFJMF;
   using JDFQuery = org.cip4.jdflib.jmf.JDFQuery;
   using JDFStatusQuParams = org.cip4.jdflib.jmf.JDFStatusQuParams;
   using JDFSubscription = org.cip4.jdflib.jmf.JDFSubscription;
   using EnumType = org.cip4.jdflib.jmf.JDFMessage.EnumType;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using JDFDevice = org.cip4.jdflib.resource.JDFDevice;
   using EnumResStatus = org.cip4.jdflib.resource.JDFResource.EnumResStatus;
   using JDFCompany = org.cip4.jdflib.resource.process.JDFCompany;
   using JDFContact = org.cip4.jdflib.resource.process.JDFContact;
   using JDFEmployee = org.cip4.jdflib.resource.process.JDFEmployee;
   using JDFPerson = org.cip4.jdflib.resource.process.JDFPerson;
   using StringUtil = org.cip4.jdflib.util.StringUtil;

   ///
   /// <summary> * @author prosirai
   /// * class that generates golden tickets based on ICS levels etc </summary>
   /// 
   public class MISGoldenTicket : BaseGoldenTicket
   {
      protected internal int misICSLevel;
      protected internal int jmfICSLevel;
      protected internal IDictionary<string, VString> catMap = new Dictionary<string, VString>();
      private string category = null;
      ///   
      ///	 <summary> * seconds ago that this started </summary>
      ///	 
      public const int preStart = 600;
      ///   
      ///	 <summary> * seconds this was active </summary>
      ///	 
      public int duration = preStart / 2;
      protected internal bool grayBox = true;
      ///   
      ///	 <summary> * create a BaseGoldenTicket </summary>
      ///	 * <param name="icsLevel"> the level to init to (1,2 or 3) </param>
      ///	 * <param name="jdfVersion"> the version to generate a golden ticket for </param>
      ///	 * <param name="jmfLevel"> level of jmf ICS to support </param>
      ///	 
      public MISGoldenTicket(int icsLevel, EnumVersion jdfVersion, int jmfLevel)
         : base(2, jdfVersion) // mis always requires base 2
      {
         misICSLevel = icsLevel;
         jmfICSLevel = jmfLevel;
         fillCatMaps();
      }

      public MISGoldenTicket(MISGoldenTicket parent)
         : base(parent) // mis always requires base 2
      {
         misICSLevel = parent.misICSLevel;
         jmfICSLevel = parent.jmfICSLevel;
         getNIFromParent = parent.getNIFromParent;
         duration = parent.duration;
         category = parent.category;
         fillCatMaps();

      }
      ///   
      ///	 <summary> *  </summary>
      ///	 
      public override void assign(JDFNode node)
      {

         base.assign(node);
         if (jmfICSLevel > 0)
         {
            JMFGoldenTicket goldenTicket = new JMFGoldenTicket(jmfICSLevel, theVersion);
            goldenTicket.devID = null;
            goldenTicket.assign(theNode);

         }
         base.init();
      }

      ///   
      ///	 * <param name="icsLevel"> </param>
      ///	 
      protected internal override JDFNodeInfo initNodeInfo()
      {

         JDFNodeInfo ni = base.initNodeInfo();

         if (theParentNode == null)
         {
            JDFEmployee emp = ni.appendEmployee();
            emp.setPersonalID("personalID1");
            emp.setRoles(new VString("CSR", null));
            if (returnURL != null)
               ni.setTargetRoute(returnURL);

            if (jmfICSLevel >= 1 && misICSLevel >= 2 || misURL != null)
            {
               JDFJMF jmf = ni.appendJMF();
               jmf.setSenderID("MISGTSender");
               JDFQuery q = jmf.appendQuery(EnumType.Status);
               q.setID(q.getID() + (System.DateTime.Now.Ticks - 621355968000000000) / 10000 % 100000);

               //ORIGINAL LINE: final JDFStatusQuParams statusQuParams = q.appendStatusQuParams();
               JDFStatusQuParams statusQuParams = q.appendStatusQuParams();
               statusQuParams.setJobID(theNode.getJobID(true));
               statusQuParams.setJobPartID(theNode.getJobPartID(false));
               statusQuParams.setJobDetails(EnumJobDetails.Brief);

               //ORIGINAL LINE: final JDFSubscription subscription = q.appendSubscription();
               JDFSubscription subscription = q.appendSubscription();
               subscription.setRepeatTime(600);
               subscription.setURL(misURL == null ? "http://MIS.printer.com/JMFSignal" : misURL);
            }
         }
         return ni;
      }

      ///   
      ///     <summary> * simulate execution of this node
      ///     * the internal node will be modified to reflect the excution </summary>
      ///	 
      public override void execute(VJDFAttributeMap vNodeMap, bool bOutAvail, bool bFirst)
      {
         JDFComment c = theExpandedNode.appendComment();
         c.setName("OperatorText");
         c.setText(StringUtil.getRandomString());

         base.execute(vNodeMap, bOutAvail, bFirst);


      }

      ///   
      ///	 <summary> * initializes this node to a given ICS version </summary>
      ///	 * <param name="icsLevel"> the level to init to (1,2 or 3) </param>
      ///	 
      public override void init()
      {
         if (misICSLevel < 0)
            return;
         string icsTag = "MIS_L" + misICSLevel + "-" + theVersion.getName();
         theNode.appendAttribute(AttributeName.ICSVERSIONS, icsTag, null, " ", true);
         if (!theNode.hasAttribute(AttributeName.DESCRIPTIVENAME))
            theNode.setDescriptiveName("MIS Golden Ticket Example Job - version: " + JDFAudit.software());
         if (!theNode.hasAncestorAttribute(AttributeName.JOBID, null))
            theNode.setJobID("Job" + JDFElement.uniqueID(0));

         //ORIGINAL LINE: final VString types = getTypes();
         VString types = getTypes();
         if (types != null)
         {
            theNode.setCategory(getCategory());
            theNode.setCombined(types);
            if (grayBox)
               theNode.setType(org.cip4.jdflib.node.JDFNode.EnumType.ProcessGroup);
         }
         initNodeInfo();
         initCustomerInfo();
      }

      ///   
      ///	 * <param name="icsLevel"> </param>
      ///	 
      protected internal virtual JDFCustomerInfo initCustomerInfo()
      {
         if (theParentNode != null)
         {

            //ORIGINAL LINE: final JDFCustomerInfo customerInfo = theParentNode.getCustomerInfo();
            JDFCustomerInfo customerInfo = theParentNode.getCustomerInfo();
            if (customerInfo != null)
            {
               theNode.linkResource(customerInfo, EnumUsage.Input, null);
               return customerInfo;
            }
         }
         JDFCustomerInfo ci = theNode.getCreateCustomerInfo();
         ci.setResStatus(EnumResStatus.Available, false);

         ci.setCustomerID("customerID");
         ci.setCustomerJobName("customer job name");
         ci.setCustomerOrderID("customerOrder_1");
         JDFContact contact = ci.appendContact();
         contact.makeRootResource(null, null, true);
         contact.setContactTypes(new VString("Customer Administrator", " "));
         JDFPerson person = contact.appendPerson();
         person.setFamilyName("T�pfer");
         person.setFirstName("Harald");
         JDFCompany comp = contact.appendCompany();
         comp.setOrganizationName("The Pits");
         return ci;
      }


      protected internal override JDFDevice initDevice(JDFNode reuseNode)
      {
         JDFDevice dev = base.initDevice(reuseNode);
         if (misICSLevel < 2)
            return dev;
         if (dev == null)
         {
            JDFResourceLink rl = null;
            if (reuseNode != null)
               rl = theNode.linkResource(reuseNode.getResource(ElementName.DEVICE, EnumUsage.Input, 0), EnumUsage.Input, null);
            if (rl == null && theParentNode != null)
               rl = theNode.linkResource(theParentNode.getResource(ElementName.DEVICE, EnumUsage.Input, 0), EnumUsage.Input, null);
         }
         if (devID != null)
         {
            dev = (JDFDevice)theNode.getCreateResource(ElementName.DEVICE, EnumUsage.Input, 0);
            dev.setResStatus(EnumResStatus.Available, false);
            dev.setDeviceID(devID);
            dev.setDescriptiveName("Device " + devID);
         }
         return dev;
      }

      ///   
      ///	 <summary> * add the type of amount link for resource audits etc </summary>
      ///	 * <param name="link"> </param>
      ///	 
      public override void addAmountLink(string link)
      {
         if (amountLinks == null)
            amountLinks = new VString();
         amountLinks.appendUnique(link);
      }

      public virtual string getCategory()
      {
         return category;
      }

      public virtual void setCategory(string _category)
      {
         category = _category;
      }

      ///   
      ///	 <summary> * get the correct Types from category
      ///	 * @return </summary>
      ///	 
      public virtual VString getTypes()
      {
         if (category == null)
            return null;
         return catMap[category];
      }

      ///   
      ///	 * <param name="grayBox"> the grayBox to set </param>
      ///	 
      public virtual void setGrayBox(bool pgrayBox)
      {
         this.grayBox = pgrayBox;
      }

      ///   
      ///	 <summary> *  </summary>
      ///	 
      protected internal virtual void fillCatMaps()
      {
         // nop

      }
   }
}
