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


/*
 * Copyright (c) 2001 Heidelberger Druckmaschinen AG, All Rights Reserved.
 * SkipInputStream.cs
 * Last changes
 */

namespace org.cip4.jdflib.util
{
   using System;
   using System.Text;
   using System.IO;


   ///
   /// <summary> * stream class that allows allows skipping a
   /// * 
   /// * @author prosirai
   /// *  </summary>
   /// 
   public class SkipInputStream : Stream
   {
      private BufferedStream m_BufferedStream;

      private int searchSize;
      private bool ignoreCase = false;

      public SkipInputStream(string searchTag, Stream stream2, bool ignorecase) //: base(stream2)
      {
         m_BufferedStream = new BufferedStream(stream2);

         ignoreCase = ignorecase;

         searchSize = searchTag == null ? 0 : searchTag.Length;
         if (searchSize == 0)
            return;

         SupportClass.BufferedStreamManager.manager.MarkPosition(searchSize + 10, m_BufferedStream);
         try
         {
            readToTag(searchTag);
         }
         catch (IOException)
         {
            // nop
         }
      }

      ///   
      ///	 * <exception cref="IOException">
      ///	 *  </exception>
      ///	 
      private void readToTag(string searchTag)
      {
         if (searchTag == null)
            return;
         // sbyte[] bytes = searchTag.getBytes();
         Encoding encoding = Encoding.Default;
         sbyte[] bytes = SupportClass.ToSByteArray(encoding.GetBytes(searchTag));
         //sbyte[] lowerBytes = searchTag.ToLower().getBytes();
         sbyte[] lowerBytes = SupportClass.ToSByteArray(encoding.GetBytes(searchTag.ToLower()));
         int tagPos = 0;
         while (true)
         {
            if (tagPos == 0)
               SupportClass.BufferedStreamManager.manager.MarkPosition(searchSize + 10, m_BufferedStream);
            int c = m_BufferedStream.ReadByte();
            if (c == -1)
               break;
            if (c == bytes[tagPos] || ignoreCase && char.ToLower(Convert.ToChar(c)) == lowerBytes[tagPos])
            {
               tagPos++;
               if (tagPos >= searchSize) // heureka
               {
                  m_BufferedStream.Position = SupportClass.BufferedStreamManager.manager.ResetMark(m_BufferedStream);
                  return;
               }
            }
            else
            {
               tagPos = 0;
            }
         }
      }

      /// <summary>
      /// Close the stream
      /// </summary>
      public override void Close()
      {
         m_BufferedStream.Close();
      }

      public override void Flush()
      {
         m_BufferedStream.Flush();
      }

      public override bool CanRead
      {
         get { return m_BufferedStream.CanRead; }
      }

      public override bool CanSeek
      {
         get { return m_BufferedStream.CanSeek; }
      }

      public override bool CanWrite
      {
         get { return m_BufferedStream.CanWrite; }
      }

      public override long Length
      {
         get { return m_BufferedStream.Length; }
      }

      public override long Position
      {
         get
         {
            return m_BufferedStream.Position;
         }
         set
         {
            m_BufferedStream.Position = value;
         }
      }

      public override void SetLength(long value)
      {
         m_BufferedStream.SetLength(value);
      }

      public override int Read(byte[] buffer, int offset, int count)
      {
         return m_BufferedStream.Read(buffer, offset, count);
      }

      public override void Write(byte[] buffer, int offset, int count)
      {
         m_BufferedStream.Write(buffer, offset, count);
      }

      public override long Seek(long offset, SeekOrigin origin)
      {
         return m_BufferedStream.Seek(offset, origin);
      }
   }
}
