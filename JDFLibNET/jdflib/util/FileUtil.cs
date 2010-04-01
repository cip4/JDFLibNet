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
 *    Alternately, this acknowledgment mrSubRefay appear in the software itself,
 *    if and wherever such third-party acknowledgments normally appear.
 *
 * 4. The names "CIP4" and "The International Cooperation for the Integration of
 *    Processes in  Prepress, Press and Postpress" must
 *    not be used to endorse or promote products derived from this
 *    software without prior written permission. For written
 *    permission, please contact info@cip4.org.
 *
 * 5. Products derived from this software may not be called "CIP4",
 *    nor may "CIP4" appear in their name, without prior writtenrestartProcesses()
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
 * SPECIAL, EXEMPLARY, OR CONSEQUENTIrSubRefAL DAMAGES (INCLUDING, BUT NOT
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
 * originally based on software restartProcesses()
 * copyright (c) 1999-2001, Heidelberger Druckmaschinen AG
 * copyright (c) 1999-2001, Agfa-Gevaert N.V.
 *
 * For more information on The International Cooperation for the
 * Integration of Processes in  Prepress, Press and Postpress , please see
 * <http://www.cip4.org/>.
 */


/*
 * Copyright (c) 2001 Heidelberger Druckmaschinen AG, All Rights Reserved.
 * KString.cs
 * Last changes
 */

namespace org.cip4.jdflib.util
{
   using System.IO;
   using System.Collections.Generic;


   using VString = org.cip4.jdflib.core.VString;
   //using FileFilter = java.io.FileFilter;

   ///
   /// <summary> * collection of helper routines to work with files
   /// * 
   /// * @author prosirai
   /// *  </summary>
   /// 
   public class FileUtil
   {
      ///   
      ///	 <summary> * list all files with a given extension (directories are skipped
      ///	 *  </summary>
      ///	 * <param name="dir"> the directory to search </param>
      ///	 * <param name="extension"> comma separated list of extensions to check for (null = list all) </param>
      ///	 * <returns> Files[] the matching files, null if none are found </returns>
      ///	 
      public static FileInfo[] listFilesWithExtension(DirectoryInfo dir, string extension)
      {
         if (dir == null)
            return null;
         FileInfo[] checkFiles = dir.GetFiles();
         List<FileInfo> files = new List<FileInfo>();
         ExtensionFileFilter eff = new ExtensionFileFilter(extension);
         foreach (FileInfo checkFile in checkFiles)
         {
            if (eff.accept(checkFile))
               files.Add(checkFile);
         }
         if (files.Count == 0)
            return null;
         else
            return files.ToArray();
      }

      ///   
      ///	 <summary> * list all files matching given regexp 
      ///	 *  </summary>
      ///	 * <param name="dir"> the directory to search </param>
      ///	 * <param name="expression"> regular expression </param>
      ///	 * <returns> Files[] the matching files, null if none are found </returns>
      ///	 
      public static FileInfo[] listFilesWithExpression(DirectoryInfo dir, string expression)
      {
         if (dir == null)
            return null;
         FileInfo[] checkFiles = dir.GetFiles();
         List<FileInfo> files = new List<FileInfo>();
         ExpressionFileFilter eff = new ExpressionFileFilter(expression);
         foreach (FileInfo checkFile in checkFiles)
         {
            if (eff.accept(checkFile))
               files.Add(checkFile);
         }
         if (files.Count == 0)
            return null;
         else
            return files.ToArray();
      }


      ///   
      ///	 <summary> * list all direct child directories
      ///	 *  </summary>
      ///	 * <param name="dir"> the directory to search
      ///	 *  </param>
      ///	 * <returns> Files[] the matching directories, null if none are found </returns>
      ///	 
      public static DirectoryInfo[] listDirectories(DirectoryInfo dir)
      {
         if (dir == null)
            return null;
         DirectoryInfo[] checkFiles = dir.GetDirectories();
         List<DirectoryInfo> files = new List<DirectoryInfo>();
         DirectoryFileFilter dff = new DirectoryFileFilter();
         foreach (DirectoryInfo checkFile in checkFiles)
         {
            if (dff.accept(checkFile))
               files.Add(checkFile);
         }
         if (files.Count == 0)
            return null;
         else
            return files.ToArray();
      }

      ///////

      ///   <summary> **********************
      ///	 * Inner class ***********************
      ///	 * 
      ///	 * UtilFileFilter
      ///	 *  </summary>
      ///	 ***********************************************************
      public class ExtensionFileFilter
      {
         private SupportClass.SetSupport<string> m_extension;

         ///      
         ///		 <summary> *  </summary>
         ///		 
         protected internal ExtensionFileFilter(string fileExtension)
         {
            if (fileExtension != null)
            {
               VString list = new VString(StringUtil.tokenize(fileExtension, ",", false));
               m_extension = new SupportClass.HashSetSupport<string>();
               for (int i = 0; i < list.Count; i++)
               {
                  string st = list.stringAt(i);
                  if (st.StartsWith("."))
                     st = st.Substring(1);
                  st = st.ToLower();
                  m_extension.Add(st);
               }
            }
         }

         //      
         //		 * (non-Javadoc)
         //		 * 
         //		 * @see java.io.FileFilter#accept(java.io.File)
         //		 
         public virtual bool accept(FileInfo checkFile)
         {
            if ((checkFile == null) || !checkFile.Exists)
               return false;
            if (m_extension == null)
               return true;
            string xt = UrlUtil.extension(checkFile.FullName);
            if (xt == null)
               xt = "";
            else
               xt = xt.ToLower();

            return m_extension.Contains(xt);
         }
      }

      ///   
      ///	 <summary> * simple file filter that lists all directories
      ///	 * 
      ///	 * @author prosirai
      ///	 *  </summary>
      ///	 
      protected internal class DirectoryFileFilter
      {

         //      
         //		 * (non-Javadoc)
         //		 * 
         //		 * @see java.io.FileFilter#accept(java.io.File)
         //		 
         public virtual bool accept(DirectoryInfo checkFile)
         {
            return checkFile != null && checkFile.Exists;
         }
      }

      ///   
      ///	 <summary> * simple file filter that lists all files that match a regular expression
      ///	 * 
      ///	 * @author Rainer Prosi
      ///	 *  </summary>
      ///	 
      protected internal class ExpressionFileFilter
      {
         private readonly string regExp;

         ///      
         ///		 * <param name="_regExp"> the regular expression to match
         ///		 *  </param>
         ///		 
         public ExpressionFileFilter(string _regExp)
         {
            regExp = _regExp;
         }

         ///      
         ///		 <summary> * true if a file matches a regular expression
         ///		 *  </summary>
         ///		 * <seealso cref= java.io.FileFilter#accept(java.io.File) </seealso>
         ///		 
         public virtual bool accept(FileInfo checkFile)
         {
            return checkFile != null && StringUtil.matches(checkFile.Name, regExp);
         }
      }

      ///   
      ///	 <summary> * very brutal tree zapper that will delete a file or directory tree recursively
      ///	 *  </summary>
      ///	 * <param name="dirToZapp"> the file directory to utterly anihilate </param>
      ///	 * <returns> true if ciao </returns>
      ///	
      public static bool DeleteAll(FileSystemInfo dirToZapp)
      {
         if (dirToZapp == null)
            return false;

         bool b = true;

         DirectoryInfo dir = dirToZapp as DirectoryInfo;
         if (dir != null && dir.Exists)
         {
            FileSystemInfo[] ff = dir.GetFileSystemInfos();
            if (ff != null)
            {
               int siz = ff.Length;
               for (int i = 0; i < siz; i++)
                  b = DeleteAll(ff[i]) && b;
            }
         }
         try
         {
            dirToZapp.Delete();
            dirToZapp.Refresh();
         }
         catch (IOException)
         {
            b = false;
         }

         return b;
      }

      ///   
      ///	 <summary> * dump a stream to a newly created file
      ///	 *  </summary>
      ///	 * <param name="fis"> the inputstream to read </param>
      ///	 * <returns> the file created by the stream, null if snafu </returns>
      ///	 
      public static FileInfo streamToFile(Stream fis, string fileName)
      {
         if (fis == null)
            return null;
         FileInfo tmp = UrlUtil.urlToFile(fileName);
         if (tmp == null)
         {
            return null;
         }
         try
         {
            FileStream fos = new FileStream(tmp.FullName, FileMode.Create);
            IOUtils.CopyStream(fis, fos);
            fos.Flush();
            fos.Close();
            fis.Close();
         }
         catch (FileNotFoundException)
         {
            return null;
         }
         catch (IOException)
         {
            return null;
         }

         tmp.Refresh();
         return tmp;
      }

      ///   
      ///	 <summary> * moves a File to dir by trying to rename, if this fails, a copy with subsequent delete is performed. if toFile
      ///	 * exists, it is brutally overwritten
      ///	 *  </summary>
      ///	 * <param name="fromFile"> the File to move </param>
      ///	 * <param name="toFile"> the File to create </param>
      ///	 * <returns> File the moved File if success, else null, i.e. toFile exists with the contents of fromFile </returns>
      ///	 
      public static FileInfo moveFileToDir(FileInfo fromFile, DirectoryInfo toDir)
      {
         if (fromFile == null || toDir == null)
            return null;
         FileInfo newFile = getFileInDirectory(toDir, new FileInfo(fromFile.Name));
         bool b = moveFile(fromFile, newFile);
         return b ? newFile : null;
      }

      ///   
      ///	 <summary> * moves a File by trying to rename, if this fails, a copy with subsequent delete is performed. if toFile exists, it
      ///	 * is brutally overwritten
      ///	 *  </summary>
      ///	 * <param name="fromFile"> the File to move </param>
      ///	 * <param name="toFile"> the File to create </param>
      ///	 * <returns> boolean true if success, i.e. toFile exists with the contents of fromFile </returns>
      ///	 
      public static bool moveFile(FileInfo fromFile, FileInfo toFile)
      {
         if (fromFile.FullName == toFile.FullName)
            return true;
         if (toFile.Exists)
            toFile.Delete();
         //C# to prevent fromFile from becoming toFile, not using MoveTo.
         if (!copyFile(fromFile, toFile))
         {
            return false;
         }
         try
         {
            fromFile.Delete();
            fromFile.Refresh();
         }
         catch (IOException)
         {
            return false;
         }
         return true;
      }

      ///   
      ///	 <summary> * copy a file
      ///	 *  </summary>
      ///	 * <param name="fromFile"> the source File </param>
      ///	 * <param name="toFile"> the destination File </param>
      ///	 * <returns> true if success </returns>
      ///	 * <exception cref="IOException"> </exception>
      ///	 * <exception cref="FileNotFoundException"> </exception>
      ///	 
      public static bool copyFile(FileInfo fromFile, FileInfo toFile)
      {
         if (fromFile.FullName == toFile.FullName)
            return true;

         try
         {
            fromFile.CopyTo(toFile.FullName, true);
            toFile.Refresh();
         }
         catch (IOException)
         {
            return false;
         }
         return true;
         //if (toFile.Exists)
         //   toFile.Delete();
         //try
         //{
         //   if (toFile.Create() == null)
         //      return false;
         //   FileStream fos = new FileStream(toFile.FullName, FileMode.Open);
         //   FileStream fis = new FileStream(fromFile.FullName, FileMode.Open);
         //   IOUtils.copy(fis, fos);
         //   fis.Close();
         //   fos.Close();
         //}
         //catch (IOException)
         //{
         //   return false;
         //}
         //return true;
      }

      ///   
      ///	 <summary> * returns a File object corresponding to an instance of localFile placed in dir - No OS calls are made and File is
      ///	 * NOT created
      ///	 *  </summary>
      ///	 * <param name="dir"> the File Object representing the directory </param>
      ///	 * <param name="localFile"> the local file to place in dir, note that only the path is copied - this does copy trees </param>
      ///	 * <returns> File the File object that represents localFile in Dir </returns>
      ///	 
      public static FileInfo getFileInDirectory(DirectoryInfo dir, FileInfo localFile)
      {
         if (dir == null)
            return localFile;
         if (localFile == null)
            return null;
         FileInfo ret = new FileInfo(dir.ToString() + Path.DirectorySeparatorChar.ToString() + localFile.ToString());
         return ret;
      }

      ///   
      ///	 * <param name="f"> the file to cleanup  </param>
      ///	 * <returns> the cleaned file </returns>
      ///	 
      public static FileInfo cleanURL(FileInfo f)
      {
         string s = UrlUtil.fileToUrl(f, false);
         return UrlUtil.urlToFile(s);
      }

      ///   
      ///	 * <param name="f"> the file to test  </param>
      ///	 * <returns> true if s is absolute </returns>
      ///	 
      public static bool isAbsoluteFile(FileInfo f)
      {
         string s = f.ToString();
         return isAbsoluteFile(s);
      }

      ///   
      ///	 * <param name="f"> the file path to test  </param>
      ///	 * <returns> true if s is absolute </returns>
      ///	 
      public static bool isAbsoluteFile(string f)
      {
         string fLocal = f;

         if (fLocal == null)
            return false;

         return Path.IsPathRooted(fLocal);

         //if (fLocal.StartsWith(Path.DirectorySeparatorChar.ToString()))
         //   return true;

         //FileInfo[] roots = SupportClass.ListLogicalDrives();
         //if (roots != null)
         //{
         //   fLocal = fLocal.ToLower();
         //   for (int i = 0; i < roots.Length; i++)
         //   {
         //      if (fLocal.StartsWith(roots[i].FullName.ToLower()))
         //         return true;
         //   }
         //}

         //return false;
      }
   }
}
