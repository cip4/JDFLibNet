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
 * EmptyNamespace.cs
 * 
 * @author Dietrich Mucha
 * Copyright (C) 2002 Heidelberger Druckmaschinen AG. All Rights Reserved. 
 */
 
namespace org.cip4.jdflib
{
   using System;
   using System.IO;
   using System.Text;
   using Microsoft.VisualStudio.TestTools.UnitTesting;


   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFParser = org.cip4.jdflib.core.JDFParser;

   [TestClass]
   public class EmptyNamespace : JDFTestCaseBase
   {

      [TestMethod]
      public virtual void testDefaultNamespace()
      {
         JDFDoc jdfDoc = new JDFDoc(ElementName.JDF);

         string defaultFile = "default.jdf";
         jdfDoc.write2File(sm_dirTestDataTemp + defaultFile, 0, true);

         JDFParser p = new JDFParser();
         JDFDoc jdfDocResult = p.parseFile(sm_dirTestDataTemp + defaultFile);

         jdfDocResult.getRoot();

      // assertXMLEqual (jdfDocResult.getMemberDocument (),
      // jdfDoc.getMemberDocument ());
         Assert.AreEqual(jdfDocResult.getDocumentElement().NamespaceURI, jdfDoc.getDocumentElement().NamespaceURI);

      }

      [TestMethod]
      public virtual void testEmptyNamespace()
      {
         JDFDoc jdfDoc = new JDFDoc(ElementName.JDF);

         jdfDoc.write2File(sm_dirTestDataTemp + "test.jdf", 0, true);

         FileStream reader = null;
         try
         {
            reader = new FileStream(sm_dirTestDataTemp + "test.jdf", FileMode.Open);

            byte[] buf = new byte[500];
            int readChars = reader.Read(buf, 0, 500);

            if (readChars >= 0)
            {
               string xml = Encoding.Default.GetString(buf);
               int startPoint = xml.IndexOf("<AuditPool>");
               bool namespaceOk = startPoint >= 0;

            // Xerces 2.0.1 test.jdf contains <AuditPool xmlns="">
            // Xerces 2.2.1 test.jdf contains <AuditPool>, which is correct

               if (!namespaceOk)
               {
                  string help = xml.Substring(xml.IndexOf("<AuditPool"));
                  Assert.IsTrue(namespaceOk, "This version of Apache Xerces has a namespace problem : " + help);
               }
            }
         }
         catch (FileNotFoundException e)
         {
            SupportClass.WriteStackTrace(e, Console.Error);
         }
         catch (IOException e)
         {
            SupportClass.WriteStackTrace(e, Console.Error);
         }
         finally
         {
            try
            {
               if (reader != null)
               {
                  reader.Close();
               }
            }
            catch (IOException e)
            {
            // TODO Auto-generated catch block
               SupportClass.WriteStackTrace(e, Console.Error);
            }
         }
      }
   }

}
