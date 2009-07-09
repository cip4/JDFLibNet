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
 * JDFStateBaseTest.cs
 *
 * @author Elena Skobchenko
 * 
 * Copyright (c) 2001-2004 The International Cooperation for the Integration 
 * of Processes in  Prepress, Press and Postpress (CIP4).  All rights reserved. 
 */

namespace org.cip4.jdflib.devicecapability
{
   using System;
   using System.Collections.Generic;
   using System.Text;
   using Microsoft.VisualStudio.TestTools.UnitTesting;


   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using EnumListType = org.cip4.jdflib.auto.JDFAutoBasicPreflightTest.EnumListType;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFParser = org.cip4.jdflib.core.JDFParser;
   using VString = org.cip4.jdflib.core.VString;
   using EnumOrientation = org.cip4.jdflib.core.JDFElement.EnumOrientation;
   using JDFIntegerRangeList = org.cip4.jdflib.datatypes.JDFIntegerRangeList;
   using JDFMatrix = org.cip4.jdflib.datatypes.JDFMatrix;
   using JDFRectangle = org.cip4.jdflib.datatypes.JDFRectangle;
   using EnumFitsValue = org.cip4.jdflib.datatypes.EnumFitsValue;
   using JDFJMF = org.cip4.jdflib.jmf.JDFJMF;
   using JDFMessage = org.cip4.jdflib.jmf.JDFMessage;
   using JDFResponse = org.cip4.jdflib.jmf.JDFResponse;
   using EnumFamily = org.cip4.jdflib.jmf.JDFMessage.EnumFamily;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using JDFBooleanState = org.cip4.jdflib.resource.devicecapability.JDFBooleanState;
   using JDFDevCap = org.cip4.jdflib.resource.devicecapability.JDFDevCap;
   using JDFDevCaps = org.cip4.jdflib.resource.devicecapability.JDFDevCaps;
   using JDFDeviceCap = org.cip4.jdflib.resource.devicecapability.JDFDeviceCap;
   using JDFIntegerState = org.cip4.jdflib.resource.devicecapability.JDFIntegerState;
   using JDFMatrixState = org.cip4.jdflib.resource.devicecapability.JDFMatrixState;
   using JDFStringState = org.cip4.jdflib.resource.devicecapability.JDFStringState;
   using EnumAvailability = org.cip4.jdflib.resource.devicecapability.JDFDeviceCap.EnumAvailability;
   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   [TestClass]
   public class JDFStateBaseTest : JDFTestCaseBase
   {

      private JDFDeviceCap deviceCap;

      [TestInitialize]
      public override void setUp()
      {
         base.setUp();
         JDFDoc doc = new JDFDoc("JMF");
         JDFJMF jmf = doc.getJMFRoot();
         JDFResponse resp = (JDFResponse)jmf.appendMessageElement(EnumFamily.Response, JDFMessage.EnumType.KnownDevices);
         deviceCap = resp.appendDeviceList().appendDeviceInfo().appendDevice().appendDeviceCap();
         deviceCap.appendBooleanState("Template");
      }


      [TestMethod]
      public void testGetNamePath()
      {
         JDFParser p = new JDFParser();
         string strNode = "<DevCaps xmlns=\"http://www.CIP4.org/JDFSchema_1_1\" Name=\"RenderingParams\" LinkUsage=\"Input\">" + "<DevCap>" + "<DevCap Name=\"AutomatedOverprintParams\">" + "<BooleanState Name=\"OverPrintBlackText\" DefaultValue=\"true\" AllowedValueList=\"true false\"/>" + "<BooleanState Name=\"OverPrintBlackLineArt\" DefaultValue=\"true\" AllowedValueList=\"true false\"/>" + "</DevCap>" + "</DevCap>" + "</DevCaps>";

         JDFDoc jdfDoc = p.parseString(strNode);

         JDFDevCaps devCaps = (JDFDevCaps)jdfDoc.getRoot();

         JDFBooleanState state = (JDFBooleanState)devCaps.getChildByTagName(ElementName.BOOLEANSTATE, null, 0, null, false, true);
         Console.WriteLine(state.getNamePath());
         Assert.AreEqual(state.getNamePath(), "JDF/ResourcePool/RenderingParams/AutomatedOverprintParams/@OverPrintBlackText");
      }


      [TestMethod]
      public void testFitsListType_IntegerState()
      {
         JDFIntegerRangeList list = new JDFIntegerRangeList();
         list.Append(1);
         list.Append(8);
         list.Append(12);

         // System.out.println(state.fitsCompleteList(value, list));
         // System.out.println(state.fitsCompleteOrderedList(value, list));
         // System.out.println(state.fitsContainedList(value, list));

         // state.setListType(EnumListType.List);
         // System.out.println(state.fitsListType(list.toString()));
         // System.out.println(state.getListType());
      }


      [TestMethod]
      public void testFitsValue_StringState()
      {
         JDFDoc jdfDoc = new JDFDoc(ElementName.STRINGSTATE);
         JDFStringState root = (JDFStringState)jdfDoc.getRoot();
         root.appendValueAllowedValue("foo");
         Assert.IsTrue(root.fitsValue("foo", EnumFitsValue.Allowed));
         Assert.IsFalse(root.fitsValue("bar", EnumFitsValue.Allowed));
      }


      [TestMethod]
      public void testFitsValue_MatrixState()
      {
         JDFDoc jdfDoc = new JDFDoc(ElementName.JDF);
         JDFNode root = jdfDoc.getJDFRoot();

         JDFMatrix matrix1 = new JDFMatrix("1 0 0 1 3.14 21631.3");
         JDFMatrix matrix2 = new JDFMatrix("0 1 1 0 2 21000");

         List<ValuedEnum> transforms = new List<ValuedEnum>();
         transforms.Add(EnumOrientation.Rotate0);
         transforms.Add(EnumOrientation.Rotate270);
         transforms.Add(EnumOrientation.Flip0);
         JDFRectangle shift = new JDFRectangle("2 4 20000 23000");

         string value1 = "1 0 0 1 3.14 21631.3";

         JDFMatrixState k = (JDFMatrixState)root.appendElement("MatrixState");
         k.appendValue();
         // k.setValueValueUsage(0, EnumFitsValue.Allowed);
         k.setValueAllowedValue(0, matrix2);

         k.appendValue();
         // k.setValueValueUsage(1, EnumFitsValue.Present);
         k.setValueAllowedValue(1, matrix1);

         k.setAllowedTransforms(transforms);
         k.setAllowedShift(shift);
         k.setAllowedRotateMod(15);

         EnumListType lt = EnumListType.UniqueList;
         // JDFAbstractState.EnumListType lt = EnumListType.ListType.Unknown;
         // JDFAbstractState.EnumListType lt = EnumListType.ListType.List;
         k.setListType(lt);
         // EnumListType listType = k.getListType();

         Assert.IsTrue(k.fitsValue(value1, EnumFitsValue.Allowed), "Matrix OK");

         string @value = "1 2 3 4 5 6 7 8 9 10 11 12 3 4 5 6 7 8";

         VString vs = new VString(@value, JDFConstants.BLANK);
         int siz = vs.Count;
         Assert.AreEqual(0, siz % 6, "It is not a Matrix");
         VString matrixList = new VString();
         int i = 0;
         StringBuilder sb = new StringBuilder(250);
         sb.Append(vs[i]);
         while ((i + 1) < siz)
         {
            do
            {
               sb.Append(JDFConstants.BLANK);
               i++;
               sb.Append(vs[i]);
            } while ((i + 1) % 6 != 0);
            matrixList.Add(sb.ToString());
            if ((i + 1) < siz)
            {
               i++;
               sb = new StringBuilder(250);
               sb.Append(vs[i]);
            }
         }
         for (int z = 0; z < matrixList.Count; z++)
         {
            JDFMatrix matrix3 = new JDFMatrix(matrixList.stringAt(z));
            //matrix3.A;
         }
      }


      ///   
      ///	 <summary> * tests defaults and handling of "unbounded" </summary>
      ///	 
      [TestMethod]
      public void testFixVersion()
      {
         JDFDevCap dc = deviceCap.appendDevCaps().appendDevCap();
         JDFIntegerState @is = dc.appendIntegerState();
         Assert.IsNull(@is.getAttribute(AttributeName.MAXOCCURS, null, null));
         @is.fixVersion(null);
         Assert.IsNull(@is.getAttribute(AttributeName.MAXOCCURS, null, null));
         @is.setAttribute(AttributeName.MAXOCCURS, "unbounded");
         @is.fixVersion(null);
         Assert.AreEqual(JDFConstants.POSINF, @is.getAttribute(AttributeName.MAXOCCURS));
         @is.setAttribute(AttributeName.MAXOCCURS, "3");
         @is.fixVersion(null);
         Assert.AreEqual("3", @is.getAttribute(AttributeName.MAXOCCURS));
      }


      ///   
      ///	 <summary> * tests defaults and handling of "unbounded" </summary>
      ///	 
      [TestMethod]
      public void testMaxOccurs()
      {
         JDFDevCap dc = deviceCap.appendDevCaps().appendDevCap();
         JDFIntegerState @is = dc.appendIntegerState();
         Assert.AreEqual(1, @is.getMaxOccurs());
         @is.setMaxOccurs(int.MaxValue);
         Assert.AreEqual(JDFConstants.POSINF, @is.getAttribute(AttributeName.MAXOCCURS, null, null));
         Assert.IsTrue(@is.getMaxOccurs() > 999);
         @is.setAttribute(AttributeName.MAXOCCURS, "unbounded");
         Assert.IsTrue(@is.getMaxOccurs() > 999, "correctly parsed unbounded for legacy support");
      }


      [TestMethod]
      public virtual void testGetNamePathVector()
      {

         JDFBooleanState b = deviceCap.getBooleanState("Template");
         VString v = b.getNamePathVector(true);
         Assert.AreEqual(1, v.Count);
         Assert.AreEqual("JDF/@Template", v.stringAt(0));
      }

      ///   
      ///	 <summary> * tests defaults </summary>
      ///	 
      [TestMethod]
      public void testMinOccurs()
      {
         JDFDevCap dc = deviceCap.appendDevCaps().appendDevCap();
         JDFIntegerState @is = dc.appendIntegerState();
         Assert.AreEqual(1, @is.getMinOccurs(), "default=1");
      }

      ///   
      ///	 <summary> * tests defaults for availability </summary>
      ///	 
      [TestMethod]
      public void testGetAvailability()
      {
         JDFDevCap dc = deviceCap.appendDevCaps().appendDevCap();
         JDFIntegerState @is = dc.appendIntegerState();

         Assert.AreEqual(EnumAvailability.Installed, dc.getAvailability());
         Assert.AreEqual(EnumAvailability.Installed, @is.getAvailability());

         dc.setAvailability(EnumAvailability.NotLicensed);
         Assert.AreEqual(EnumAvailability.NotLicensed, dc.getAvailability());
         Assert.AreEqual(EnumAvailability.NotLicensed, @is.getAvailability());
      }
   }
}
