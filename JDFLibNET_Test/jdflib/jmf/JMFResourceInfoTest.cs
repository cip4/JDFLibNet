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
   using Microsoft.VisualStudio.TestTools.UnitTesting;

   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using EnumValidationLevel = org.cip4.jdflib.core.KElement.EnumValidationLevel;
   using EnumType = org.cip4.jdflib.jmf.JDFMessage.EnumType;
   using EnumResStatus = org.cip4.jdflib.resource.JDFResource.EnumResStatus;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;

   ///
   /// <summary> * @author Rainer Prosi
   /// * 
   /// *         Test of the ResourceInfo JMF element </summary>
   /// 
   [TestClass]
   public class JMFResourceInfoTest : JDFTestCaseBase
   {
      private JDFResourceInfo ri;

      [TestMethod]
      public virtual void testGetResource()
      {
         Assert.IsNull(ri.getResource(ElementName.MEDIA));
         JDFMedia m = (JDFMedia)ri.appendResource(ElementName.MEDIA);
         JDFMedia m2 = (JDFMedia)ri.getResource(ElementName.MEDIA);
         Assert.AreEqual(m, m2);
         Assert.IsTrue(ri.isValid(EnumValidationLevel.Complete));
      }


      [TestMethod]
      public virtual void testGetResourceNull()
      {
         JDFMedia m = (JDFMedia)ri.appendResource(ElementName.MEDIA);
         JDFMedia m2 = (JDFMedia)ri.getResource(null);
         Assert.AreEqual(m, m2);
         Assert.IsTrue(ri.isValid(EnumValidationLevel.Complete));
      }


      [TestMethod]
      public virtual void testGetResourceName()
      {
         // JDFMedia m=(JDFMedia)
         ri.appendResource(ElementName.MEDIA);
         string name = ri.getResourceName();
         Assert.AreEqual(ElementName.MEDIA, name);
      }


      [TestMethod]
      public virtual void testGetResourceID()
      {
         JDFMedia m = (JDFMedia)ri.appendResource(ElementName.MEDIA);
         string name = ri.getResourceID();
         Assert.AreEqual(m.getID(), name);
      }


      [TestMethod]
      public virtual void testGetProductID()
      {
         JDFMedia m = (JDFMedia)ri.appendResource(ElementName.MEDIA);
         m.setProductID("p1");
         string name = ri.getProductID();
         Assert.AreEqual(m.getProductID(), name);
      }


      [TestMethod]
      public virtual void testGetResStatus()
      {
         JDFMedia m = (JDFMedia)ri.appendResource(ElementName.MEDIA);
         EnumResStatus name = ri.getResStatus();
         Assert.AreEqual(m.getResStatus(false), name);
      }



      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.JDFTestCaseBase#setUp()
      //	 
      [TestInitialize]
      public override void setUp()
      {
         base.setUp();
         JDFDoc doc = new JDFDoc(ElementName.JMF);
         JDFJMF jmf = doc.getJMFRoot();

         JDFResponse r = jmf.appendResponse();
         jmf.setSenderID("DeviceSenderID");
         r.setType(EnumType.Resource);
         ri = r.getCreateResourceInfo(0);
      }
   }
}
