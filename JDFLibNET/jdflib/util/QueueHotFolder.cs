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
 * Copyright (c) 2001 Heidelberger Druckmaschinen AG, All Rights Reserved.
 *
 * KString.cs
 *
 * Last changes
 */

namespace org.cip4.jdflib.util
{
   using System;
   using System.IO;

   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using KElement = org.cip4.jdflib.core.KElement;
   using EnumAuditType = org.cip4.jdflib.core.JDFAudit.EnumAuditType;
   using JDFCommand = org.cip4.jdflib.jmf.JDFCommand;
   using JDFJMF = org.cip4.jdflib.jmf.JDFJMF;
   using JDFMessage = org.cip4.jdflib.jmf.JDFMessage;
   using JDFQueueSubmissionParams = org.cip4.jdflib.jmf.JDFQueueSubmissionParams;
   using JDFReturnQueueEntryParams = org.cip4.jdflib.jmf.JDFReturnQueueEntryParams;
   using EnumType = org.cip4.jdflib.jmf.JDFMessage.EnumType;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using JDFAuditPool = org.cip4.jdflib.pool.JDFAuditPool;
   using JDFProcessRun = org.cip4.jdflib.resource.JDFProcessRun;


   ///
   /// <summary> * a hotfolder that emulates JMF queue functionality 
   /// * by applying a specific queue submission or queue return message
   /// * to any file that is dropped into it
   /// * 
   /// * @author prosirai
   /// * </summary>
   /// 
   public class QueueHotFolder : HotFolderListener
   {
      private readonly DirectoryInfo storageDir; // the physical storage where files are dumped after removal fro the hotfolder
      private readonly HotFolder hf; // the active hot folder
      private readonly QueueHotFolderListener qhfl; // the callback that is called whenever a file is dropped
      private readonly JDFCommand queueCommand; // the jdf command template that is used to generate a new message for each dropped file

      ///    
      ///     <summary> *     
      ///     * constructor for a simple queue based hotfolder watcher that is automagically started in its own thread
      ///     *  </summary>
      ///     * <param name="_hotFolderDir"> the hot folder directory to watch </param>
      ///     * <param name="_storageDir"> the storage directory wher hot files are moved to </param>
      ///     * <param name="ext"> the file extensions that are moved - if null no filtering </param>
      ///     * <param name="hfListener"> callback that receives the generated JMF - the location of the stored file will be found in the standard command parameters </param>
      ///     * <param name="_queueCommand"> the jmf template that will be used to generate a new message, null creates an empty SubmitQueueEntry template </param>
      ///     
      public QueueHotFolder(DirectoryInfo _hotFolderDir, DirectoryInfo _storageDir, string ext, QueueHotFolderListener hfListener, JDFJMF _queueCommand)
      {
         JDFJMF _queueCommandLocal = _queueCommand;

         storageDir = _storageDir;
         if (!storageDir.Exists)
            storageDir.Create(); // just in case
         qhfl = hfListener;
         if (_queueCommandLocal == null)
            _queueCommandLocal = JDFJMF.createJMF(JDFMessage.EnumFamily.Command, JDFMessage.EnumType.SubmitQueueEntry);

         queueCommand = _queueCommandLocal.getCommand(0);
         hf = new HotFolder(_hotFolderDir, ext, this);
      }

      ///    
      ///     <summary> * stop this hot folder
      ///     * </summary>
      ///     
      public virtual void stop()
      {
         hf.stop();
      }

      ///    
      ///     <summary> * restart this hot folder, create s a new listner thread and stops the old one
      ///     * </summary>
      ///     
      public virtual void restart()
      {
         hf.restart();

      }
      //     (non-Javadoc)
      //     * @see org.cip4.jdflib.util.HotFolderListener#hotFile(java.io.File)
      //     
      public virtual void hotFile(FileInfo hotFile)
      {
         FileInfo storedFile = FileUtil.moveFileToDir(hotFile, storageDir);
         if (storedFile == null)
         {
            return; // not good
         }
         string stringURL = UrlUtil.fileToUrl(storedFile, false);

         JDFDoc jmfDoc = new JDFDoc("JMF");
         JDFJMF jmfRoot = jmfDoc.getJMFRoot();
         JDFCommand newCommand = (JDFCommand)jmfRoot.copyElement(queueCommand, null);
         newCommand.removeAttribute(AttributeName.ID);
         newCommand.appendAnchor(null);
         EnumType cType = newCommand.getEnumType();
         JDFDoc jdfDoc = JDFDoc.parseFile(storedFile.FullName);

         JDFNode jdfRoot = jdfDoc == null ? null : jdfDoc.getJDFRoot();

         if (EnumType.ReturnQueueEntry.Equals(cType))
         {
            extractReturnParams(stringURL, newCommand, jdfRoot);
         }
         else if (EnumType.SubmitQueueEntry.Equals(cType))
         {
            extractSubmitParams(stringURL, newCommand, jdfRoot);
         }
         qhfl.submitted(jmfRoot);
      }

      ///    
      ///     <summary> * overwrite this method in case you want to customize the hotfolder for submitqueentry and paramtetrizing 
      ///     * the QueueSubmissionParams template is insufficient
      ///     *  </summary>
      ///     * <param name="stringURL"> the file url of the hotfolder jdf in the local storage directory (NOT the hf) </param>
      ///     * <param name="newCommand"> the command that was generated from the template </param>
      ///     * <param name="jdfRoot"> the root jdfnode of the dropped file </param>
      ///     
      protected internal virtual void extractSubmitParams(string stringURL, JDFCommand newCommand, JDFNode jdfRoot)
      {
         JDFQueueSubmissionParams sqp = newCommand.getCreateQueueSubmissionParams(0);
         sqp.setURL(stringURL);
         JDFAuditPool ap = jdfRoot == null ? null : jdfRoot.getCreateAuditPool();
         if (ap != null)
         {
            ap.createSubmitProcessRun(null);
         }
      }

      ///    
      ///     <summary> * overwrite this method in case you want to customize the hotfolder for returnqueueentryparams and paramtetrizing 
      ///     * the ReturnQueueEntryParams template is insufficient
      ///     * </summary>
      ///     * <param name="stringURL"> the file url of the hotfolder jdf in the local storage directory (NOT the hf) </param>
      ///     * <param name="newCommand"> the command that was generated from the template </param>
      ///     * <param name="jdfRoot"> the root jdfnode of the dropped file </param>
      ///     
      protected internal virtual void extractReturnParams(string stringURL, JDFCommand newCommand, JDFNode jdfRoot)
      {
         JDFReturnQueueEntryParams rqp = newCommand.getCreateReturnQueueEntryParams(0);
         rqp.setURL(stringURL);
         JDFAuditPool ap = jdfRoot == null ? null : jdfRoot.getCreateAuditPool();
         if (ap != null)
         {
            JDFProcessRun pr = (JDFProcessRun)ap.getAudit(-1, EnumAuditType.ProcessRun, null, null);
            string queueEID = pr == null ? null : pr.getAttribute(AttributeName.QUEUEENTRYID);
            if (!KElement.isWildCard(queueEID))
               rqp.setQueueEntryID(queueEID);
         }
      }
   }
}
