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

namespace org.cip4.jdflib.auto
{
   using System;
   using System.IO;

   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using KElement = org.cip4.jdflib.core.KElement;
   using JDFNode = org.cip4.jdflib.node.JDFNode;

   public class AutoClassInstantiateVisitor : DirectoryVisitor
   {
      internal bool totalResult = true;

      public virtual void enterDirectory(DirectoryInfo dir)
      {
         totalResult = true;
      }

      public virtual void leaveDirectory(DirectoryInfo dir)
      {
         if (!totalResult)
         {
            totalResult = true;
            throw new Exception("Error!!! There were classes, which could not be instantiated");
         }
      }

      public virtual void visitFile(FileInfo file)
      {
         testJDFClass(file.Name);
      }

      private void testJDFClass(string fileName)
      {
         bool result = false;

         string elementName = fileName;
         string prefix = elementName.StartsWith("JDFAuto") ? "JDFAuto" : "JDF";

         //.Net Substring different than java substring.
         elementName = elementName.Substring(prefix.Length, elementName.Length - ".java".Length - prefix.Length);

      // adjust the element name
         if (elementName.StartsWith("Span"))
            elementName = elementName.Substring("Span".Length);
         else if (elementName.Equals("ShapeElement"))
            elementName = "Shape";
         else if (elementName.Equals("Node"))
            elementName = "JDF";

         JDFDoc jdfDoc = new JDFDoc(ElementName.JDF);
         JDFNode jdfRoot = (JDFNode) jdfDoc.getRoot();

         KElement kElem = jdfRoot.appendElement(elementName); // create a class
                                                // for
                                                // elementName

         string createdClass = kElem.GetType().ToString();
         createdClass = createdClass.Substring(createdClass.LastIndexOf(".") + 1);

         result = elementName.Equals(createdClass.Substring("JDF".Length)) || (elementName.Equals(ElementName.COLORSUSED) && createdClass.Equals("JDFSeparationList")) || (elementName.Equals(ElementName.SHAPE) && createdClass.Equals("JDFShapeElement")) || (elementName.EndsWith(JDFConstants.LINK) && createdClass.Substring("JDF".Length).Equals(ElementName.RESOURCELINK));

         if (!result)
         {
            totalResult = false;
            throw new Exception("Error!!! Class " + elementName + " (" + fileName + ") could not be instantiated!" + " --> missing entry in DocumentJDFImpl.sm_PackageNames ???");
         }
      }
   }
}