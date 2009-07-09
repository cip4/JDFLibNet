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
 * AutoTest.cs
 * 
 * @author Kai Mattern
 *
 * Copyright (C) 2002 Heidelberger Druckmaschinen AG. All Rights Reserved.
 */

namespace org.cip4.jdflib.auto
{
   using System.Collections;
   using Microsoft.VisualStudio.TestTools.UnitTesting;

   using VString = org.cip4.jdflib.core.VString;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using JDFAdhesiveBindingParams = org.cip4.jdflib.resource.JDFAdhesiveBindingParams;
   using JDFMarkObject = org.cip4.jdflib.resource.JDFMarkObject;
   using JDFLayout = org.cip4.jdflib.resource.process.JDFLayout;

   [TestClass]
   public class AutoTest
   {
   // Beware!
   // These tests are for checking versioning and JDFValidator internal details
      [TestMethod]
      public virtual void testElementVersion()
      {
         VString vPrerelease = null;
         ArrayList vOptional = null;
         VString vDeprecated = null;

         JDFDoc jdfDoc = new JDFDoc("JDF");
         JDFNode root = jdfDoc.getJDFRoot();

      // check AdhesiveBindingParams/GlueApplication
      //
         root.setVersion(JDFElement.EnumVersion.Version_1_3);
         JDFAdhesiveBindingParams adhesiveBindingParam = (JDFAdhesiveBindingParams) root.addResource(ElementName.ADHESIVEBINDINGPARAMS, null, EnumUsage.Input, null, null, null, null);
         // Java to C# Conversion - getTheElementInfo() method is "protected internal" not accessable
         //vDeprecated = adhesiveBindingParam.getTheElementInfo().deprecatedElements();
         adhesiveBindingParam.appendGlueApplication();
         vDeprecated = adhesiveBindingParam.getDeprecatedElements(99999999);
         Assert.IsTrue(vDeprecated.Contains(ElementName.GLUEAPPLICATION));

         root.setVersion(JDFElement.EnumVersion.Version_1_0);
         vDeprecated = adhesiveBindingParam.getDeprecatedElements(99999999);
         Assert.AreEqual(0, vDeprecated.Count);

      // check MarkObject/DeviceMark
      //
         root.setVersion(JDFElement.EnumVersion.Version_1_0);
         JDFLayout layout = (JDFLayout) root.addResource(ElementName.LAYOUT, null, EnumUsage.Input, null, null, null, null);
         JDFMarkObject markObject = layout.appendMarkObject();
         markObject.appendDeviceMark();
         vPrerelease = markObject.getPrereleaseElements(99999999);
         Assert.IsTrue(vPrerelease.Contains(ElementName.DEVICEMARK));

         root.setVersion(JDFElement.EnumVersion.Version_1_1);
         // Java to C# Conversion - getTheElementInfo() method is "protected internal" not accessable
         //vOptional = markObject.getTheElementInfo().optionalElements();
         Assert.IsTrue(vOptional.Contains(ElementName.DEVICEMARK));

         root.setVersion(JDFElement.EnumVersion.Version_1_2);
         // Java to C# Conversion - getTheElementInfo() method is "protected internal" not accessable
         //vOptional = markObject.getTheElementInfo().optionalElements();
         Assert.IsTrue(vOptional.Contains(ElementName.DEVICEMARK));

         root.setVersion(JDFElement.EnumVersion.Version_1_3);
         // Java to C# Conversion - getTheElementInfo() method is "protected internal" not accessable
         //vDeprecated = markObject.getTheElementInfo().deprecatedElements();
         Assert.IsTrue(vDeprecated.Contains(ElementName.DEVICEMARK));
      }
   }
}