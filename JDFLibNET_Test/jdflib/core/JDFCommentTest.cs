
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


namespace org.cip4.jdflib.core
{
   using Microsoft.VisualStudio.TestTools.UnitTesting;


   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using EnumValidationLevel = org.cip4.jdflib.core.KElement.EnumValidationLevel;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using JDFAuditPool = org.cip4.jdflib.pool.JDFAuditPool;
   using JDFNotification = org.cip4.jdflib.resource.JDFNotification;

   [TestClass]
   public class JDFCommentTest : JDFTestCaseBase
   {
      [TestMethod]
      public virtual void testInit()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFNode root = doc.getJDFRoot();
         JDFComment cRoot = root.appendComment();
         Assert.IsNotNull(cRoot.getAttribute(AttributeName.ID, null, null));
         Assert.IsTrue(cRoot.isValid(EnumValidationLevel.Complete));

         root.setVersion(JDFElement.EnumVersion.Version_1_2);
         JDFAuditPool ap = root.getCreateAuditPool();
         JDFNotification notif = ap.addNotification(JDFNotification.EnumClass.Information, "Me", null);
         JDFComment c = notif.appendComment();
         c.setText("This element should have no ID attribute");
         string id = c.getAttribute(AttributeName.ID, null, null);
         Assert.IsNull(id);
      }


      [TestMethod]
      public virtual void testFormat()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFNode root = doc.getJDFRoot();
         JDFComment c11 = root.appendComment();
         string txt = "This element should have no ID attribute and is a rellly long line with many many characters.. asfihAFLKFKJGFaufksgUFGagfAFKJSG";
         txt += txt;
         txt += txt; // even longer...
         c11.setText(txt);
         JDFComment c21 = root.appendComment();
         const string txt2 = "This element \n has \n crlf";
         c21.setText(txt2);
         Assert.AreEqual(txt, c11.getText(), "text is equal in DOM");
         Assert.AreEqual(txt2, c21.getText(), "text is equal in DOM");
         string commentFile = sm_dirTestDataTemp + @"\CommentTest.JDF";
         doc.write2File(commentFile, 2, true);
         JDFParser p = new JDFParser();
         JDFDoc doc2 = p.parseFile(commentFile);
         JDFNode root2 = doc2.getJDFRoot();
         JDFComment c12 = root2.getComment(0);
         JDFComment c22 = root2.getComment(1);
         Assert.AreEqual(txt, c12.getText(), "text is equal after parse");
         Assert.AreEqual(txt2, c22.getText(), "text is equal after parse");
      }


      [TestMethod]
      public virtual void testEraseEmptyNodes()
      {
         JDFDoc doc = new JDFDoc(ElementName.JDF);
         JDFNode root = doc.getJDFRoot();
         JDFComment c11 = root.appendComment();
         string txt = "      \n\n";
         c11.setText(txt);
         root.eraseEmptyNodes(true);
         Assert.AreEqual(txt, c11.getText(), "whitespace is not removed");
      }
   }
}