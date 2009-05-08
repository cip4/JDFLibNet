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
 * ==========================================================================
 * class JDFMessageService extends JDFResource
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
   using System.Collections;
   using System.Collections.Generic;



   using JDFAutoMessageService = org.cip4.jdflib.auto.JDFAutoMessageService;
   using EnumContext = org.cip4.jdflib.auto.JDFAutoDevCaps.EnumContext;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using KElement = org.cip4.jdflib.core.KElement;
   using VString = org.cip4.jdflib.core.VString;
   using ICapabilityElement = org.cip4.jdflib.ifaces.ICapabilityElement;
   using IDeviceCapable = org.cip4.jdflib.ifaces.IDeviceCapable;
   using EnumFamily = org.cip4.jdflib.jmf.JDFMessage.EnumFamily;
   using EnumType = org.cip4.jdflib.jmf.JDFMessage.EnumType;
   using JDFDevCaps = org.cip4.jdflib.resource.devicecapability.JDFDevCaps;

   //----------------------------------
   public class JDFMessageService : JDFAutoMessageService, IDeviceCapable
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFMessageService
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFMessageService(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFMessageService
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFMessageService(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFMessageService
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFMessageService(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.auto.JDFAutoMessageService#toString()
      //	 
      public override string ToString()
      {
         return "JDFMessageService[  --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * Typesafe enumerated attribute Type
      ///	 *  </summary>
      ///	 * <returns> EnumType: the enumeration value of the attribute </returns>
      ///	 
      public virtual EnumType getEnumType()
      {
         return EnumType.getEnum(getAttribute(AttributeName.TYPE, null, null));
      }

      ///   
      ///	 <summary> * Set attribute Type
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setType(EnumType @value)
      {
         string typeName = @value == null ? null : @value.getName();
         setType(typeName);
      }

      ///   
      ///	 <summary> * Method isCommand.
      ///	 *  </summary>
      ///	 * <returns> boolean </returns>
      ///	 * @deprecated use getCommand 
      ///	 
      [Obsolete("use getCommand")]
      public virtual bool isCommand()
      {
         return getCommand();
      }

      ///   
      ///	 <summary> * Method isQuery.
      ///	 *  </summary>
      ///	 * <returns> boolean </returns>
      ///	 * @deprecated use getQuery 
      ///	 
      [Obsolete("use getQuery")]
      public virtual bool isQuery()
      {
         return getQuery();
      }

      ///   
      ///	 <summary> * append a devcaps for this and set its context to JMF </summary>
      ///	 
      public override JDFDevCaps appendDevCaps()
      {
         JDFDevCaps dcs = base.appendDevCaps();
         dcs.setContext(EnumContext.JMF);
         return dcs;
      }

      public VString getNamePathVector()
      {
         VString vResult = new VString();
         List<EnumFamily> families = getFamilies();
         if (families != null)
         {
            int siz = families.Count;
            for (int i = 0; i < siz; i++)
               vResult.Add(families[i].getName());
         }

         return vResult;
      }

      ///   
      ///	 <summary> * get the list of supported families
      ///	 *  </summary>
      ///	 * <returns> EnumFamily[] the list of supported families </returns>
      ///	 
      public virtual List<EnumFamily> getFamilies()
      {
         List<EnumFamily> fams = new List<EnumFamily>();
         if (getCommand())
            fams.Add(EnumFamily.Command);
         if (getSignal())
            fams.Add(EnumFamily.Signal);
         if (getQuery())
            fams.Add(EnumFamily.Query);
         if (getRegistration())
            fams.Add(EnumFamily.Registration);
         if (getAcknowledge())
            fams.Add(EnumFamily.Acknowledge);
         return fams.Count == 0 ? null : fams;
      }

      ///   
      ///	 <summary> * set the list of supported families
      ///	 *  </summary>
      ///	 * <param name="fams"> the Vector of EnumFamily of supported families </param>
      ///	 
      public virtual void setFamilies(ArrayList fams)
      {
         setCommand(false);
         setSignal(false);
         setQuery(false);
         setRegistration(false);
         setAcknowledge(false);

         if (fams == null)
            return;
         for (int i = 0; i < fams.Count; i++)
         {
            try
            {
               setFamily((EnumFamily)fams[i]);
            }
            catch (JDFException)
            { // nop 
            }
         }
      }

      ///   
      ///	 <summary> * set the value of the family name to true
      ///	 *  </summary>
      ///	 * <param name="family"> </param>
      ///	 
      public virtual void setFamily(EnumFamily family)
      {
         if (family == null || EnumFamily.Response.Equals(family))
            throw new JDFException("setFamily: illegal family:" + family);
         setAttribute(family.getName(), true, null);
      }

      ///   
      ///     <summary> *  </summary>
      ///     
      public virtual ICapabilityElement getTargetCap(string id)
      {
         KElement e = getTarget(id, null);
         if (e is ICapabilityElement)
            return (ICapabilityElement)e;
         return null;
      }
   }
}
