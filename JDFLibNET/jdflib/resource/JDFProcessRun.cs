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


//--------------------------------------------------------------------------------------------------


/* ========================================================================== 
 * class JDFProcessRun extends JDFAutoProcessRun
 * created 2001-09-06T10:02:57GMT+02:00 
 * ==========================================================================
 * @COPYRIGHT Heidelberger Druckmaschinen AG, 1999-2001 ALL RIGHTS RESERVED
 * @Author: sabjon@topmail.de   using a code generator 
 * Warning! very preliminary test version. 
 * Interface subject to change without prior notice! 
 * Revision history:   ... */


namespace org.cip4.jdflib.resource
{
   using System;



   using JDFAutoProcessRun = org.cip4.jdflib.auto.JDFAutoProcessRun;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using JDFDate = org.cip4.jdflib.util.JDFDate;
   using JDFDuration = org.cip4.jdflib.util.JDFDuration;


   public class JDFProcessRun : JDFAutoProcessRun
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFProcessRun
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFProcessRun(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFProcessRun
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFProcessRun(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFProcessRun
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>

      ///	 
      public JDFProcessRun(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
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
         return "JDFProcessRun[  --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * set the duration in seconds
      ///	 *  </summary>
      ///	 * <param name="seconds"> the value to set </param>
      ///	 * <exception cref="JDFException"> </exception>
      ///	 
      public virtual void setDurationSeconds(int seconds)
      {
         if (seconds < 0)
         {
            throw new JDFException("parameter must be >= 0");
         }
         JDFDuration d = new JDFDuration();
         d.setDuration(seconds);
         setAttribute("Duration", d.getDurationISO(), JDFConstants.EMPTYSTRING);
      }

      ///////
      ///   
      ///	 <summary> * get the duration in seconds
      ///	 *  </summary>
      ///	 * <returns> int: the duration value in seconds, 0 if duration does not exist </returns>
      ///	 
      public virtual int getDurationSeconds()
      {
         JDFDuration d = getDuration();
         if (d == null)
            return 0;
         return d.Duration;
      }

      ///////

      ///   
      ///	 <summary> * get the explicit or implied duration specified by Start and End
      ///	 *  </summary>
      ///	 * <returns> JDFDuration the duration </returns>
      ///	 
      public override JDFDuration getDuration()
      {
         JDFDuration dur = base.getDuration();
         if (dur != null)
            return dur;

         JDFDate dStart = getStart();
         JDFDate dEnd = getEnd();
         if (dStart == null || dEnd == null)
            return null;
         dur = new JDFDuration(dStart, dEnd);
         return dur;
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
      ///	 <summary> * check whether the part defined by mPart is included
      ///	 *  </summary>
      ///	 * <param name="mPart"> attribute map to look for </param>
      ///	 * <returns> boolean - returns true if the part exists </returns>
      ///	 
      public override bool hasPartMap(JDFAttributeMap mPart)
      {
         return base.hasPartMap(mPart);
      }


      ///   
      ///	 <summary> * add the active times in the PhaseTime pt to this processrun
      ///	 *  </summary>
      ///	 * <param name="pt"> the PhaseTimes to add </param>
      ///	 
      public virtual void addPhase(JDFPhaseTime pt)
      {
         if (pt == null)
            return;

         EnumNodeStatus status = pt.getStatus();
         if (status == null || status.Equals(EnumNodeStatus.Ready) || status.Equals(EnumNodeStatus.Completed) || status.Equals(EnumNodeStatus.FailedTestRun) || status.Equals(EnumNodeStatus.Spawned) || status.Equals(EnumNodeStatus.Stopped) || status.Equals(EnumNodeStatus.Suspended) || status.Equals(EnumNodeStatus.Waiting))
            return;

         JDFDuration dur = pt.getDuration();
         addDuration(dur.Duration);

         JDFDate start = pt.getStart();
         if (start != null)
         {
            if (start.before(getStart()))
               setStart(start);
         }

         JDFDate end = pt.getEnd();
         if (end != null)
         {
            if (end.after(getEnd()))
               setEnd(end);
         }

      }

      ///   
      ///	 <summary> * ensure that duration matches end-start, <br/> i.e. that duration is never longer than the full preiod between
      ///	 * start and end
      ///	 *  </summary>
      ///	 
      public virtual void ensureNotLonger()
      {
         JDFDate start = getStart();
         JDFDate end = getEnd();
         if (start != null && end != null)
         {
            JDFDuration total = new JDFDuration(start, end);
            if (total.CompareTo(getDuration()) < 0)
               setDuration(total);
         }
      }


      ///   
      ///	 <summary> * add delta seconds to duration and set the updated attribute value
      ///	 *  </summary>
      ///	 * <param name="seconds"> duration to add in seconds </param>
      ///	 
      public virtual void addDuration(int seconds)
      {
         JDFDuration dur = getDuration();
         int l = dur == null ? 0 : dur.Duration;
         setDurationSeconds(l + seconds);
      }

      

      ///   
      ///	 <summary> * (11) set attribute SubmissionTime
      ///	 *  </summary>
      ///	 * <param name="value"> : the value to set the attribute to or null if null, set to the current time </param>
      ///	 
      public virtual void setSubmissionTime(JDFDate @value)
      {
         JDFDate valueLocal = @value;

         if (valueLocal == null)
            valueLocal = new JDFDate();

         setAttribute(AttributeName.SUBMISSIONTIME, valueLocal.DateTimeISO, null);
      }

      ///   
      ///	 <summary> * (12) get JDFDate attribute SubmissionTime
      ///	 *  </summary>
      ///	 * <returns> JDFDate the value of the attribute </returns>
      ///	 
      public virtual JDFDate getSubmissionTime()
      {
         string str = getAttribute(AttributeName.SUBMISSIONTIME, null, null);
         if (str == null)
            return null;
         try
         {
            return new JDFDate(str);
         }
         catch (FormatException)
         {
            throw new JDFException("not a valid date string. Malformed JDF");
         }
      }

      ///   
      ///	 <summary> * (11) set attribute ReturnTime
      ///	 *  </summary>
      ///	 * <param name="value"> : the value to set the attribute to or null if null, set to the current time </param>
      ///	 
      public virtual void setReturnTime(JDFDate @value)
      {
         JDFDate valueLocal = @value;

         if (valueLocal == null)
            valueLocal = new JDFDate();

         setAttribute(AttributeName.RETURNTIME, valueLocal.DateTimeISO, null);
      }

      ///   
      ///	 <summary> * (12) get JDFDate attribute ReturnTime
      ///	 *  </summary>
      ///	 * <returns> JDFDate the value of the attribute </returns>
      ///	 
      public virtual JDFDate getReturnTime()
      {
         string str = getAttribute(AttributeName.RETURNTIME, null, null);
         if (str == null)
            return null;
         try
         {
            return new JDFDate(str);
         }
         catch (FormatException)
         {
            throw new JDFException("not a valid date string. Malformed JDF");
         }
      }

      public override bool init()
      {
         setEnd(null);
         return base.init();
      }
   }
}
