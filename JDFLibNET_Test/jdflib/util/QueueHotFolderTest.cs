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
 * 04022005 VF initial version
 * 
 *
 * Created on Aug 26, 2004
 */

namespace org.cip4.jdflib.util
{
   using System.IO;
   using Microsoft.VisualStudio.TestTools.UnitTesting;

   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using VElement = org.cip4.jdflib.core.VElement;
   using JDFJMF = org.cip4.jdflib.jmf.JDFJMF;
   using JDFMessage = org.cip4.jdflib.jmf.JDFMessage;

   ///
   /// <summary> * @author Rainer
   /// * 
   /// *         To change the template for this generated type comment go to Window -
   /// *         Preferences - Java - Code Generation - Code and Comments </summary>
   /// 
   [TestClass]
   public class QueueHotFolderTest : JDFTestCaseBase
   {
      private DirectoryInfo theHF;
      private DirectoryInfo theStorage;
      internal QueueHotFolder hf;

      protected internal class MyListener : QueueHotFolderListener
      {
         protected internal VElement vJMF = new VElement();

         //      
         //		 * (non-Javadoc)
         //		 * 
         //		 * @see
         //		 * org.cip4.jdflib.util.QueueHotFolderListener#submitted(org.cip4.jdflib
         //		 * .jmf.JDFJMF)
         //		 
         public virtual void submitted(JDFJMF submissionJMF)
         {
            vJMF.Add(submissionJMF);
         }
      }


      [TestInitialize]
      public override void setUp()
      {
         base.setUp();
         theHF = new DirectoryInfo(sm_dirTestDataTemp + "QHFTest");
         theStorage = new DirectoryInfo(sm_dirTestDataTemp + "QHFStore");
         theHF.Create();
         FileUtil.DeleteAll(theStorage);
         theStorage.Create();
      }


      [TestMethod]
      public virtual void testSubmitSingleFile()
      {
         MyListener myListener = new MyListener();
         FileInfo file = new FileInfo(theHF + "f1.txt");
         FileInfo stFile = new FileInfo(theStorage +  "f1.txt");
         SupportClass.FileSupport.CreateNewFile(file);
         file.Refresh();
         Assert.IsTrue(file.Exists);
         Assert.IsFalse(stFile.Exists);
         hf = new QueueHotFolder(theHF, theStorage, null, myListener, null);
         StatusCounter.sleep(3000);
         Assert.IsFalse(file.Exists);
         Assert.IsTrue(stFile.Exists);
         Assert.AreEqual(1, myListener.vJMF.Count);
         JDFJMF elementAt = (JDFJMF)myListener.vJMF[0];
         Assert.AreEqual(JDFMessage.EnumType.SubmitQueueEntry, elementAt.getCommand(0).getEnumType());
         Assert.AreEqual(UrlUtil.fileToUrl(stFile, false), elementAt.getCommand(0).getQueueSubmissionParams(0).getURL());
      }


      [TestMethod]
      public virtual void teststopStart()
      {
         MyListener myListener = new MyListener();
         FileInfo file = new FileInfo(theHF + "f1.txt");
         FileInfo stFile = new FileInfo(theStorage + "f1.txt");
         SupportClass.FileSupport.CreateNewFile(file);
         file.Refresh();
         Assert.IsTrue(file.Exists);
         Assert.IsFalse(stFile.Exists);
         hf = new QueueHotFolder(theHF, theStorage, null, myListener, null);
         hf.stop();
         StatusCounter.sleep(3000);
         Assert.IsTrue(file.Exists);
         Assert.IsFalse(stFile.Exists, "FileInfo is still there after stop");
         Assert.AreEqual(0, myListener.vJMF.Count);
         hf.restart();
         StatusCounter.sleep(3000);
         Assert.IsFalse(file.Exists, "FileInfo is gone after stop");
         Assert.IsTrue(stFile.Exists);
         Assert.AreEqual(1, myListener.vJMF.Count);
         JDFJMF elementAt = (JDFJMF)myListener.vJMF[0];
         Assert.AreEqual(JDFMessage.EnumType.SubmitQueueEntry, elementAt.getCommand(0).getEnumType());
         Assert.AreEqual(UrlUtil.fileToUrl(stFile, false), elementAt.getCommand(0).getQueueSubmissionParams(0).getURL());
      }


      [TestCleanup]
      public override void tearDown()
      {
         base.tearDown();
         hf.stop();
      }
   }
}
