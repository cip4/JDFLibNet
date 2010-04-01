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




namespace org.cip4.jdflib.util
{
   using System;
   using System.Text;
   using System.Collections.Generic;
   using System.IO;


   ///
   /// <summary> * 
   /// * @author rainer
   /// * 
   /// *         very trivial temp file dump
   /// *  </summary>
   /// 
   public class DumpDir
   {

      ///   
      ///	 <summary> * very simple and fast mutable integer class
      ///	 * 
      ///	 * @author prosirai
      ///	 *  </summary>
      ///	 
      protected internal class MyInt
      {
         public int i = 0;

         public override string ToString()
         {
            return Convert.ToString(i);
         }
      }

      /////
      private DirectoryInfo baseDir = null;
      private static Dictionary<DirectoryInfo, MyInt> listMap = new Dictionary<DirectoryInfo, MyInt>();
      private readonly int maxKeep = 500;
      ///   
      ///	 <summary> * if true, no printouts </summary>
      ///	 
      public bool quiet = true;
      ///   
      ///     <summary> *  </summary>
      ///     
      private const long serialVersionUID = -8902151736333089036L;

      private int increment()
      {
         lock (listMap)
         {
            MyInt i = listMap[baseDir];
            return i.i++;
         }
      }

      ///   
      ///	 <summary> * create a dumpdir with dir as the root </summary>
      ///	 
      public DumpDir(DirectoryInfo dir)
      {
         baseDir = dir;
         baseDir.Create();
         lock (listMap)
         {
            MyInt index = listMap[baseDir];
            if (index == null)
            {
               index = new MyInt();
               listMap.Add(baseDir, index);
            }
            FileInfo[] names = baseDir.GetFiles();
            int max = 0;
            int l;
            for (int i = 0; i < names.Length; i++)
            {
               //.Net Substring different than java substring.
               if (names[i].FullName.Length > 9)
                  l = StringUtil.parseInt(names[i].FullName.Substring(1, 8), 0);
               else
                  l = 0;
               if (l > max)
                  max = l;
            }
            index.i = max;
         }
      }

      ///   
      ///	 <summary> * returns the base directory as a File
      ///	 * 
      ///	 * @return </summary>
      ///	 
      public virtual DirectoryInfo getDir()
      {
         return baseDir;
      }

      ///   
      ///	 <summary> * create a new File in this dump
      ///	 *  </summary>
      ///	 * <param name="header"> TODO
      ///	 *  </param>
      ///	 
      public virtual FileInfo newFile(string header)
      {
         int inc = increment();
         if (!quiet && (inc % 200 == 0))
            Console.WriteLine("jmf dump service " + baseDir + " - " + inc + " " + new JDFDate().DateTime);

         string s = StringUtil.sprintf("m%08i.tmp", "" + inc);
         FileInfo f = FileUtil.getFileInDirectory(baseDir, new FileInfo(s));
         if (header != null)
         {
            newHeader(header, f, true);
         }

         cleanup(inc);
         return f;
      }

      ///   
      ///	 <summary> * create a new File in this dump and fill it from is
      ///	 *  </summary>
      ///	 * <param name="header"> TODO </param>
      ///	 * <param name="is"> the input stream to fill
      ///	 *  </param>
      ///	 

      public virtual FileInfo newFileFromStream(string header, Stream @is)
      {
         Stream isLocal = @is;

         FileInfo dump = newFile(null);
         if (!(isLocal is BufferedStream))
         {
            isLocal = new BufferedStream(isLocal);
            isLocal.SetLength(100000L);
         }

         FileStream fs = newHeader(header, dump, false);
         if (fs != null)
         {
            try
            {
               IOUtils.CopyStream(isLocal, fs);
               fs.Flush();
               fs.Close();
               // Java to C# Conversion - No equivalent .NET
               isLocal.Position = 0;  //.reset();
            }
            catch (IOException)
            {
               // nop
            }
         }

         return dump;
      }

      ///   
      ///	 * <param name="header"> </param>
      ///	 * <param name="fs"> </param>
      ///	 * <exception cref="IOException"> </exception>
      ///	 
      private FileStream newHeader(string header, FileInfo f, bool bClose)
      {
         try
         {
            FileStream fs = new FileStream(f.FullName, FileMode.Create);

            if (header != null)
            {
               //fs.write(header.getBytes());
               SupportClass.WriteOutput(fs, Encoding.Default.GetBytes(header));
               //fs.write("\n------ end of header ----!\n".getBytes());
               SupportClass.WriteOutput(fs, Encoding.Default.GetBytes("\n------ end of header ----!\n"));
               if (bClose)
               {
                  fs.Flush();
                  fs.Close();
               }
            }
            return fs;
         }
         catch (FileNotFoundException)
         {
            // nop
         }
         catch (IOException)
         {
            // nop
         }

         return null;
      }

      ///   
      ///	 * <param name="inc"> </param>
      ///	 
      private void cleanup(int inc)
      {
         if (inc % 100 == 0)
         {
            lock (listMap[baseDir])
            {
               FileInfo[] files = baseDir.GetFiles();
               string[] names = new string[files.Length];
               for (int fi = 0; fi < files.Length; ++fi)
               {
                  names[fi] = files[fi].FullName;
               }

               if (names.Length > maxKeep)
               {
                  System.Array.Sort(names);
                  for (int i = 0; i < names.Length - maxKeep; i++)
                  {
                     FileInfo f = new FileInfo(names[i]);
                     f = FileUtil.getFileInDirectory(baseDir, f);
                     if (f != null)
                        f.Delete();
                  }
               }
            }
         }
      }

      public override string ToString()
      {
         return "DumpDir " + baseDir + " i=" + listMap[baseDir].i;
      }
   }
}
