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


namespace org.cip4.jdflib.jmf
{
   using System;
   using Microsoft.VisualStudio.TestTools.UnitTesting;


   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFRefElement = org.cip4.jdflib.core.JDFRefElement;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using EnumType = org.cip4.jdflib.jmf.JDFMessage.EnumType;
   using JDFCoilBindingParams = org.cip4.jdflib.resource.JDFCoilBindingParams;
   using JDFHeadBandApplicationParams = org.cip4.jdflib.resource.JDFHeadBandApplicationParams;
   using EnumResourceClass = org.cip4.jdflib.resource.JDFResource.EnumResourceClass;
   using JDFExposedMedia = org.cip4.jdflib.resource.process.JDFExposedMedia;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;

   [TestClass]
   public class JDFPipeParamsTest 
   {

      [TestMethod]
      public virtual void testAppendResourceLink()
      {
         JDFDoc doc = new JDFDoc(ElementName.PIPEPARAMS);
         JDFPipeParams pp = (JDFPipeParams) doc.getRoot();
         JDFResourceLink rl = pp.appendResourceLink("Dummy", true);
         Assert.AreEqual(EnumUsage.Input, rl.getUsage());
         try
         {
            rl = pp.appendResourceLink("Dummy2", true);
            Assert.Fail("max 1 rl");
         }
         catch (Exception)
         {
         // nop
         }
      }


      [TestMethod]
      public virtual void testAppendResource()
      {
         JDFDoc doc = new JDFDoc(ElementName.PIPEPARAMS);
         JDFPipeParams pp = (JDFPipeParams) doc.getRoot();
         JDFCoilBindingParams cbp = (JDFCoilBindingParams) pp.appendResource(ElementName.COILBINDINGPARAMS);
         Assert.AreEqual(EnumResourceClass.Parameter, cbp.getResourceClass());
         JDFHeadBandApplicationParams hap = (JDFHeadBandApplicationParams) pp.appendResource(ElementName.HEADBANDAPPLICATIONPARAMS);
         Assert.AreEqual(EnumResourceClass.Parameter, hap.getResourceClass());
      }


      [TestMethod]
      public virtual void testGetResourceLink()
      {
         JDFDoc doc = new JDFDoc(ElementName.JMF);
         JDFJMF jmf = doc.getJMFRoot();
         JDFCommand c = jmf.appendCommand(EnumType.PipePull);
         JDFPipeParams pp = c.appendPipeParams();
         JDFExposedMedia xm = (JDFExposedMedia) pp.appendResource(ElementName.EXPOSEDMEDIA);
         Assert.AreEqual(EnumResourceClass.Handling, xm.getResourceClass());
         JDFMedia m = (JDFMedia) pp.appendResource(ElementName.MEDIA);
         Assert.AreEqual(EnumResourceClass.Consumable, m.getResourceClass());
         JDFRefElement rm = xm.refElement(m);
         Assert.AreEqual(m, rm.getTarget());
         JDFResourceLink rl = pp.appendResourceLink(ElementName.EXPOSEDMEDIA, true);
         rl.setrRef(xm.getID());
         Assert.AreEqual(xm, rl.getTarget());
         Assert.AreEqual(pp.getResourceLink(), rl);
      }


      [TestMethod]
      public virtual void testGetResource()
      {
         JDFDoc doc = new JDFDoc(ElementName.JMF);
         JDFJMF jmf = doc.getJMFRoot();
         JDFCommand c = jmf.appendCommand(EnumType.PipePull);
         JDFPipeParams pp = c.appendPipeParams();
         JDFExposedMedia xm = (JDFExposedMedia) pp.appendResource(ElementName.EXPOSEDMEDIA);
         Assert.AreEqual(EnumResourceClass.Handling, xm.getResourceClass());
         JDFMedia m = (JDFMedia) pp.appendResource(ElementName.MEDIA);
         Assert.AreEqual(EnumResourceClass.Consumable, m.getResourceClass());
         JDFRefElement rm = xm.refElement(m);
         Assert.AreEqual(m, rm.getTarget());
         Assert.AreEqual(xm, pp.getResource(ElementName.EXPOSEDMEDIA));
         Assert.AreEqual(xm, pp.getResource(null));
         Assert.AreEqual(m, pp.getResource(ElementName.MEDIA));
         try
         {
            Assert.IsNull(pp.getResource("MediaLink"));
            Assert.Fail();
         }
         catch (JDFException)
         {
         // nop
         }

         JDFResourceLink rl = pp.appendResourceLink(ElementName.EXPOSEDMEDIA, true);
         rl.setrRef(xm.getID());
         Assert.AreEqual(xm, pp.getResource(null));
         Assert.AreEqual(rl.getTarget(), pp.getResource(null));
      }
   }
}