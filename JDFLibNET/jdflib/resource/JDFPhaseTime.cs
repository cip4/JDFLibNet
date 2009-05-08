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
 * class JDFPhaseTime extends JDFAutoPhaseTime
 * created 2001-09-06T10:02:57GMT+02:00 
 * ==========================================================================
 * @COPYRIGHT Heidelberger Druckmaschinen AG, 1999-2001 ALL RIGHTS RESERVED
 * @Author: sabjon@topmail.de   using a code generator
 * Warning! very preliminary test version. Interface subject to change without prior notice! 
 * Revision history:   ... 
 */


namespace org.cip4.jdflib.resource
{
   using System;
   using System.Collections;



   using JDFAutoPhaseTime = org.cip4.jdflib.auto.JDFAutoPhaseTime;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using JDFDate = org.cip4.jdflib.util.JDFDate;
   using JDFDuration = org.cip4.jdflib.util.JDFDuration;

   public class JDFPhaseTime : JDFAutoPhaseTime
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFPhaseTime
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFPhaseTime(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFPhaseTime
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFPhaseTime(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFPhaseTime
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFPhaseTime(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
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
         return "JDFPhaseTime[  --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * set all parts to those defined in vParts
      ///	 *  </summary>
      ///	 * <param name="vParts"> vector of attribute maps for the parts </param>
      ///	 
      public override void setPartMapVector(VJDFAttributeMap vParts)
      {
         base.setPartMapVector(vParts);
      }

      ///   
      ///	 <summary> * set all parts to those defined by mPart
      ///	 *  </summary>
      ///	 * <param name="mPart"> attribute map for the part to set </param>
      ///	 
      public override void setPartMap(JDFAttributeMap mPart)
      {
         base.setPartMap(mPart);
      }

      ///   
      ///	 <summary> * remove the part defined by mPart
      ///	 *  </summary>
      ///	 * <param name="mPart"> attribute map for the part to remove </param>
      ///	 
      public override void removePartMap(JDFAttributeMap mPart)
      {
         base.removePartMap(mPart);
      }

      ///   
      ///	 <summary> * check whether the part defined in mPart is included
      ///	 *  </summary>
      ///	 * <param name="mPart"> attribute map to look for </param>
      ///	 * <returns> boolean - returns true if the part exists </returns>
      ///	 
      public override bool hasPartMap(JDFAttributeMap mPart)
      {
         return base.hasPartMap(mPart);
      }

      ///   
      ///	 <summary> * return a vector of unknown element nodenames
      ///	 * <p>
      ///	 * default: GetInvalidElements(true, 999999)
      ///	 *  </summary>
      ///	 * <param name="bIgnorePrivate"> used by JDFElement during the validation </param>
      ///	 * <param name="nMax"> maximum size of the returned vector </param>
      ///	 * <returns> Vector - vector of unknown element nodenames
      ///	 * 
      ///	 *         !!! Do not change the signature of this method </returns>
      ///	 
      public override VString getUnknownElements(bool bIgnorePrivate, int nMax)
      {
         return getUnknownPoolElements(JDFElement.EnumPoolType.ResourceLinkPool, nMax);
      }

      ///   
      ///	 <summary> * copy a Vector of resourceLinks into this PhaseTime
      ///	 *  </summary>
      ///	 * <param name="vRL"> the Vector of resourceLinks to copy - the order is significant, because the first rl will be used to
      ///	 *            fill the Amount in Signal/DeviceInfo/JobPhase </param>
      ///	 
      public virtual void setLinks(VElement vRL)
      {
         if (vRL == null)
            return;
         int size = vRL.Count;
         if (size == 0)
            return;

         for (int i = 0; i < size; i++)
         {
            JDFResourceLink rl = (JDFResourceLink)vRL[i];
            removeChildren(rl.LocalName, rl.getNamespaceURI(), null);
         }
         for (int i = 0; i < size; i++)
         {
            JDFResourceLink rl = (JDFResourceLink)vRL[i];
            copyElement(rl, null);
         }
      }

      ///   
      ///	 <summary> * return the ResourceLink in <code>this</code>, null if none exists
      ///	 *  </summary>
      ///	 * <param name="iSkip"> the nTh resourceLink to retrieve </param>
      ///	 * <returns> JDFResourceLink - <code>this</code> phaseTimes ResourceLink </returns>
      ///	 
      public virtual JDFResourceLink getLink(int iSkip)
      {
         KElement e = getFirstChildElement();
         int n = 0;
         while (e != null)
         {
            if (e is JDFResourceLink)
            {
               if (n++ >= iSkip)
                  return (JDFResourceLink)e;
            }
            e = e.getNextSiblingElement();
         }
         return null;
      }

      ///   
      ///	 <summary> * return the ResourceLink in <code>this</code>, null if none exists
      ///	 *  </summary>
      ///	 * <param name="iSkip"> the n'th resourceLink to retrieve </param>
      ///	 * <returns> JDFResourceLink - this phaseTimes ResourceLink </returns>
      ///	 
      public virtual VElement getLinkVector()
      {
         KElement e = getFirstChildElement();
         VElement vRet = new VElement();
         while (e != null)
         {
            if (e is JDFResourceLink)
            {
               vRet.Add(e);
            }
            e = e.getNextSiblingElement();
         }
         return vRet.Count == 0 ? null : vRet;
      }

      ///   
      ///	 <summary> * get the implied duration from Start and End
      ///	 *  </summary>
      ///	 * <returns> JDFDuration the duration </returns>
      ///	 
      public virtual JDFDuration getDuration()
      {
         JDFDate dStart = getStart();
         JDFDate dEnd = getEnd();
         if (dStart == null || dEnd == null)
            return null;
         int dur = (int)((dEnd.TimeInMillis - dStart.TimeInMillis) / 1000);
         if (dur < 0)
            dur = 0;
         return new JDFDuration(dur);
      }

      ///   
      ///	 * <param name="m_moduleid"> the list of module ids to add, if null: nop </param>
      ///	 * <returns> the list of ModulePhase element </returns>
      ///	 * <exception cref="IllegalArgumentException"> if the vectors have different lengths </exception>
      ///	 
      public virtual VElement setModules(VString moduleIDs, VString moduleTypes)
      {
         if (moduleIDs == null || moduleIDs.Count == 0)
            return null;
         if (moduleTypes == null || moduleTypes.Count == 0 || moduleTypes.Count != moduleIDs.Count)
            throw new ArgumentException("Inconsistent vector lengths");
         VElement v = new VElement();
         for (int i = 0; i < moduleIDs.Count; i++)
         {
            JDFModulePhase modulePhase = getCreateModulePhase(i);
            v.Add(modulePhase);
            modulePhase.setModuleID(moduleIDs.stringAt(i));
            modulePhase.setModuleType(moduleTypes.stringAt(i));
         }
         return v;
      }
   }
}
