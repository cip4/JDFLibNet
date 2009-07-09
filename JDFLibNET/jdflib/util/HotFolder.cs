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
   using System.Runtime.CompilerServices;
   using System.Collections.Generic;
   using System.Threading;


   ///
   /// <summary> * a very simple hotfolder watcher subdirectories are ignored
   /// * 
   /// * @author prosirai
   /// *  </summary>
   /// 
   public class HotFolder : IThreadRunnable
   {
      public int stabilizeTime = 1000; // time between reads in milliseconds -
      // also minimum lenght of
      // non-modification
      private bool interrupt = false; // if set to true, the watcher interupted
      // and the thread ends
      private static int nThread = 0;

      private readonly DirectoryInfo dir;
      private DateTime lastModified = DateTime.MinValue;
      private readonly List<FileTime> lastFileTime;
      private readonly HotFolderListener hfl;
      private readonly string extension;
      private SupportClass.ThreadClass runThread;

      ///   
      ///	 <summary> * constructor for a simple hotfolder watcher that is automagically started in its own thread
      ///	 *  </summary>
      ///	 * <param name="_dir"> the Directory to watch </param>
      ///	 * <param name="ext"> the extension filter - case is ignored and lists of extensions may be specified as a comma separated
      ///	 *            list e.g. ".txt,.xml" </param>
      ///	 * <param name="_hfl"> </param>
      ///	 
      public HotFolder(DirectoryInfo _dir, string ext, HotFolderListener _hfl)
      {
         dir = _dir;
         extension = ext;
         lastFileTime = new List<FileTime>();
         hfl = _hfl;
         runThread = null;
         restart();
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      public virtual void restart()
      {
         if (runThread != null)
            Stop();
         runThread = new SupportClass.ThreadClass(new ThreadStart(this.Run), "HotFolder_" + nThread++);
         interrupt = false;
         runThread.Start();

      }

      ///   
      ///	 <summary> * stop this thread;
      ///	 *  </summary>
      ///	 
      public virtual void Stop()
      {
         interrupt = true;
         if (runThread != null)
         {
            lock (runThread)
            {
               Monitor.PulseAll(runThread);


               try
               {
                  runThread.Join(); // kill the old thread with extreme
                  // prejudice -
                  // otherwise we may have multiple concurring hf watcher
                  // threads
               }
               catch (ThreadInterruptedException)
               {
                  // nop
               }
            }
            runThread = null;
         }
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see java.lang.Runnable#run()
      //	 
      public virtual void Run()
      {
         while (!interrupt)
         {
            DateTime lastMod = dir.LastWriteTime;
            if (lastMod > lastModified || lastFileTime.Count > 0) // has the
            // directory
            // been
            // touched?
            {
               lastModified = lastMod;
               FileInfo[] files = FileUtil.listFilesWithExtension(dir, extension);
               int fileListLength = files != null ? files.Length : 0;

               for (int i = lastFileTime.Count - 1; i >= 0; i--)
               {
                  bool found = false;
                  for (int j = 0; j < fileListLength; j++)
                  // loop over all matching files in the directory
                  {
                     if (files != null)
                     {
                        FileTime lftAt = lastFileTime[i];
                        if (files[j] != null && files[j].Equals(lftAt.f))
                        {
                           found = true;
                           if (files[j].LastWriteTime == lftAt.modified)
                           {
                              if (files[j].Exists)
                              {
                                 hfl.hotFile(files[j]); // exists and stabilized - call callback
                              }
                              else
                              {
                                 found = false;
                              }
                           }
                           else
                           {
                              lftAt.modified = files[j].LastWriteTime;
                           }

                           files[j] = null; // this file has been processed,
                           // remove from list for performance
                        }
                     }
                  }

                  if (!found)
                  {
                     lastFileTime.Remove(lastFileTime[i]); // not there anymore
                  }
               }

               if (files != null)
               {
                  for (int i = 0; i < fileListLength; i++) // the file is new -
                  // add to list for nextr check
                  {
                     if (files[i] != null)
                        lastFileTime.Add(new FileTime(files[i]));
                  }
               }
            }

            StatusCounter.sleep(stabilizeTime);
         }

         Thread.CurrentThread.Interrupt();
      }

      ///   
      ///	 <summary> * simple container class that retains the last known mod date of a file
      ///	 * 
      ///	 * @author prosirai
      ///	 *  </summary>
      ///	 
      protected internal class FileTime
      {
         protected internal FileInfo f;
         protected internal DateTime modified;

         protected internal FileTime(FileInfo _f)
         {
            f = _f;
            modified = DateTime.MinValue;
         }
      }
   }
}
