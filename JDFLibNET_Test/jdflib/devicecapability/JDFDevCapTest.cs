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
 * JDFDevCapTest.cs
 * @author Dietrich Mucha
 * Copyright (C) 2004 Heidelberger Druckmaschinen AG. All Rights Reserved.
 */ 

namespace org.cip4.jdflib.devicecapability
{
   using System.Collections.Generic;
   using Microsoft.VisualStudio.TestTools.UnitTesting;



   using EnumListType = org.cip4.jdflib.auto.JDFAutoBasicPreflightTest.EnumListType;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using EnumBoolean = org.cip4.jdflib.core.JDFElement.EnumBoolean;
   using EnumValidationLevel = org.cip4.jdflib.core.KElement.EnumValidationLevel;
   using JDFIntegerRangeList = org.cip4.jdflib.datatypes.JDFIntegerRangeList;
   using JDFNumberRangeList = org.cip4.jdflib.datatypes.JDFNumberRangeList;
   using EnumFitsValue = org.cip4.jdflib.datatypes.EnumFitsValue;
   using JDFBooleanState = org.cip4.jdflib.resource.devicecapability.JDFBooleanState;
   using JDFDateTimeState = org.cip4.jdflib.resource.devicecapability.JDFDateTimeState;
   using JDFDevCap = org.cip4.jdflib.resource.devicecapability.JDFDevCap;
   using JDFDeviceCap = org.cip4.jdflib.resource.devicecapability.JDFDeviceCap;
   using JDFDurationState = org.cip4.jdflib.resource.devicecapability.JDFDurationState;
   using JDFEnumerationState = org.cip4.jdflib.resource.devicecapability.JDFEnumerationState;
   using JDFIntegerState = org.cip4.jdflib.resource.devicecapability.JDFIntegerState;
   using JDFMatrixState = org.cip4.jdflib.resource.devicecapability.JDFMatrixState;
   using JDFModuleCap = org.cip4.jdflib.resource.devicecapability.JDFModuleCap;
   using JDFNameState = org.cip4.jdflib.resource.devicecapability.JDFNameState;
   using JDFNumberState = org.cip4.jdflib.resource.devicecapability.JDFNumberState;
   using JDFPDFPathState = org.cip4.jdflib.resource.devicecapability.JDFPDFPathState;
   using JDFRectangleState = org.cip4.jdflib.resource.devicecapability.JDFRectangleState;
   using JDFShapeState = org.cip4.jdflib.resource.devicecapability.JDFShapeState;
   using JDFStringState = org.cip4.jdflib.resource.devicecapability.JDFStringState;
   using JDFXYPairState = org.cip4.jdflib.resource.devicecapability.JDFXYPairState;
   using EnumAvailability = org.cip4.jdflib.resource.devicecapability.JDFDeviceCap.EnumAvailability;
   using JDFLayout = org.cip4.jdflib.resource.process.JDFLayout;
   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   [TestClass]
   public class JDFDevCapTest 
   {
      [TestMethod]
      public virtual void testBooleanState()
      {
         JDFDoc d = new JDFDoc("BooleanState");
         JDFBooleanState bs = (JDFBooleanState) d.getRoot();
         List<ValuedEnum> v = new List<ValuedEnum>();
         v.Add(EnumBoolean.False);
         bs.setAllowedValueList(v);
         Assert.IsTrue(bs.fitsValue("false", EnumFitsValue.Allowed));
         Assert.IsFalse(bs.fitsValue("fnarf", EnumFitsValue.Allowed));
         Assert.IsFalse(bs.fitsValue("true", EnumFitsValue.Allowed));
         v.Add(EnumBoolean.True);
         bs.setAllowedValueList(v);
         Assert.IsTrue(bs.fitsValue("true", EnumFitsValue.Allowed));
      }


      [TestMethod]
      public virtual void testIntegerState()
      {
         JDFDoc d = new JDFDoc("IntegerState");
         JDFIntegerState @is = (JDFIntegerState) d.getRoot();
         JDFIntegerRangeList irl = new JDFIntegerRangeList("12~15");
         @is.setAllowedValueList(irl);
         @is.setListType(EnumListType.RangeList);
         Assert.IsTrue(@is.fitsValue("12~15", EnumFitsValue.Allowed));
         Assert.IsFalse(@is.fitsValue("19~33", EnumFitsValue.Allowed));
         irl = new JDFIntegerRangeList("12~15 19~33");
         @is.setAllowedValueList(irl);
         Assert.IsTrue(@is.fitsValue("12~15", EnumFitsValue.Allowed));
         Assert.IsTrue(@is.fitsValue("19~33", EnumFitsValue.Allowed));
      }


      [TestMethod]
      public virtual void testgetMatchingElementsFromParentSingle()
      {
         JDFDoc ddc = new JDFDoc("DevCap");
         JDFDoc dde = new JDFDoc("Layout");
         JDFDevCap dc = (JDFDevCap) ddc.getRoot();
         JDFLayout e = (JDFLayout) dde.getRoot();

         JDFDevCap dc1 = dc.appendDevCap();
         dc1.setName("Media");
         dc1.setMaxOccurs(1);
         dc1.setMinOccurs(1);

         for (int i = 0; i < 2; i++)
         {
            string mediaType = i == 0 ? "Paper" : "Plate";
            e.appendElement("Media").setAttribute("MediaType", mediaType);

         }
         VElement devCapVector = dc.getDevCapVector(null, true);
         VElement vMatch = ((JDFDevCap) devCapVector.item(0)).getMatchingElementsFromParent(e, devCapVector);
         Assert.AreEqual(2, vMatch.Count);
         Assert.AreEqual(e.getElement("Media", null, 0), vMatch.item(0));
         Assert.AreEqual(e.getElement("Media", null, 1), vMatch.item(1));
      }


      [TestMethod]
      public virtual void testgetMatchingElementsFromParentMulti()
      {
         JDFDoc ddc = new JDFDoc("DevCap");
         JDFDoc dde = new JDFDoc("Layout");
         JDFDevCap dc = (JDFDevCap) ddc.getRoot();
         JDFLayout e = (JDFLayout) dde.getRoot();

         for (int i = 0; i < 2; i++)
         {
            JDFDevCap dc1 = dc.appendDevCap();
            dc1.setName("Media");
            dc1.setMaxOccurs(1);
            dc1.setMinOccurs(1);
            JDFEnumerationState es = dc1.appendEnumerationState("MediaType");
            string mediaType = i == 0 ? "Paper" : "Plate";
            es.setAllowedValueList(new VString(mediaType, null));

            e.appendElement("Media").setAttribute("MediaType", mediaType);

         }
         VElement devCapVector = dc.getDevCapVector(null, true);
         for (int i = 0; i < 2; i++)
         {
            VElement vMatch = ((JDFDevCap) devCapVector.item(i)).getMatchingElementsFromParent(e, devCapVector);
            Assert.AreEqual(1, vMatch.Count);
            Assert.AreEqual(e.getElement("Media", null, i), vMatch.item(0));
         }
      }


      [TestMethod]
      public virtual void testNumberState()
      {
         JDFDoc d = new JDFDoc("NumberState");
         JDFNumberState ns = (JDFNumberState) d.getRoot();
         JDFNumberRangeList nrl = new JDFNumberRangeList("12.45~15.88");
         ns.setAllowedValueList(nrl);
         ns.setListType(EnumListType.RangeList);
         Assert.IsTrue(ns.fitsValue("12.45~15.88", EnumFitsValue.Allowed));
         Assert.IsTrue(ns.fitsValue("12.45~13.0", EnumFitsValue.Allowed));
         Assert.IsFalse(ns.fitsValue("19.0~33.234", EnumFitsValue.Allowed));
         nrl = new JDFNumberRangeList("12.45~15.88 19.0~33.234");
         ns.setAllowedValueList(nrl);
         Assert.IsTrue(ns.fitsValue("12.45", EnumFitsValue.Allowed));
         Assert.IsTrue(ns.fitsValue("19.0~33.234", EnumFitsValue.Allowed));
         Assert.IsFalse(ns.fitsValue("16.01", EnumFitsValue.Allowed));
      }


      [TestMethod]
      public virtual void testEnumerationState()
      {
         JDFDoc d = new JDFDoc("EnumerationState");
         JDFEnumerationState es = (JDFEnumerationState) d.getRoot();
         VString v = new VString();
         v.Add("foo");
         v.Add("bar");

         es.setAllowedValueList(v);
         Assert.IsTrue(es.fitsValue("foo", EnumFitsValue.Allowed));
         Assert.IsTrue(es.fitsValue("bar", EnumFitsValue.Allowed));
         Assert.IsFalse(es.fitsValue("fnarf", EnumFitsValue.Allowed));

         es.setListType(EnumListType.List);
         Assert.IsTrue(es.fitsValue("foo", EnumFitsValue.Allowed));
         Assert.IsTrue(es.fitsValue("foo bar", EnumFitsValue.Allowed));
         Assert.IsTrue(es.fitsValue("foo bar foo", EnumFitsValue.Allowed));
         Assert.IsFalse(es.fitsValue("foo bar fnarf", EnumFitsValue.Allowed));

         es.setListType(EnumListType.CompleteList);
         Assert.IsFalse(es.fitsValue("foo", EnumFitsValue.Allowed));
         Assert.IsTrue(es.fitsValue("foo bar", EnumFitsValue.Allowed));
         Assert.IsTrue(es.fitsValue("bar foo", EnumFitsValue.Allowed));
         Assert.IsFalse(es.fitsValue("foo bar foo", EnumFitsValue.Allowed));
         Assert.IsFalse(es.fitsValue("foo bar fnarf", EnumFitsValue.Allowed));

      // TODO implement more list types
      // es.setListType(EnumListType.OrderedList);
      // Assert.IsFalse(es.fitsValue("foo", EnumFitsValue.Allowed));
      // Assert.IsTrue(es.fitsValue("foo bar", EnumFitsValue.Allowed));
      // Assert.IsFalse(es.fitsValue("bar foo", EnumFitsValue.Allowed));
      // Assert.IsFalse(es.fitsValue("foo bar foo", EnumFitsValue.Allowed));
      // Assert.IsFalse(es.fitsValue("foo bar fnarf", EnumFitsValue.Allowed));
      }


      [TestMethod]
      public virtual void testRegExp()
      {
         for (int i = 0; i < 2; i++)
         {
            JDFDoc d = new JDFDoc("EnumerationState");
            JDFEnumerationState es = (JDFEnumerationState) d.getRoot();

            es.setListType(EnumListType.List);
            es.setAllowedRegExp("a b( c)?( d)*");
            if (i == 1)
               es.setAllowedValueList(new VString("a b c d", " "));
            Assert.IsTrue(es.fitsValue("a b", EnumFitsValue.Allowed));
            Assert.IsTrue(es.fitsValue("a b c", EnumFitsValue.Allowed));
            Assert.IsTrue(es.fitsValue("a b c d d", EnumFitsValue.Allowed));
            Assert.IsFalse(es.fitsValue("a b c c", EnumFitsValue.Allowed));
            Assert.IsFalse(es.fitsValue("a c b", EnumFitsValue.Allowed));
            Assert.IsFalse(es.fitsValue("abc", EnumFitsValue.Allowed));
            Assert.IsFalse(es.fitsValue("A b c", EnumFitsValue.Allowed));
         }
      }


      [TestMethod]
      public virtual void testNameState()
      {
         JDFDoc d = new JDFDoc("NameState");
         JDFNameState ns = (JDFNameState) d.getRoot();
         VString nl = new VString();
         nl.Add("anna~berta");
         ns.setAllowedValueList(nl);
         ns.setListType(EnumListType.RangeList);
         Assert.IsTrue(ns.fitsValue("anna~berta", EnumFitsValue.Allowed));
         Assert.IsFalse(ns.fitsValue("hans~otto", EnumFitsValue.Allowed));
         nl.Add("anna~berta hans~otto");
         ns.setAllowedValueList(nl);
         Assert.IsTrue(ns.fitsValue("anna~berta", EnumFitsValue.Allowed));
         Assert.IsTrue(ns.fitsValue("hans~otto", EnumFitsValue.Allowed));
         ns.setAllowedValueList(null);
         ns.setAllowedRegExp("*");
         Assert.IsTrue(ns.fitsValue("hans~otto", EnumFitsValue.Allowed));
         ns.setAllowedRegExp("[ab].*");
         Assert.IsTrue(ns.fitsValue("al", EnumFitsValue.Allowed));
         Assert.IsFalse(ns.fitsValue("cl", EnumFitsValue.Allowed));
      }


      // test "getXxxState" 
      [TestMethod]
      public virtual void testGetBooleanState()
      {
         JDFDoc d = new JDFDoc("DevCap");
         JDFDevCap dc = (JDFDevCap) d.getRoot();
         JDFBooleanState bs = dc.appendBooleanState("foo");
         Assert.AreEqual("foo", bs.getName());
         bs = dc.getBooleanState("bar");
         Assert.IsNull(bs);
         bs = dc.getCreateBooleanState("bar");
         Assert.IsNotNull(bs);
         Assert.AreEqual("bar", bs.getName());
         bs = dc.getBooleanState("bar");
         Assert.IsNotNull(bs);
         Assert.AreEqual("bar", bs.getName());
      }


      [TestMethod]
      public virtual void testGetIntegerState()
      {
         JDFDoc d = new JDFDoc("DevCap");
         JDFDevCap dc = (JDFDevCap) d.getRoot();
         JDFIntegerState @is = dc.appendIntegerState("foo");
         Assert.AreEqual("foo", @is.getName());
         @is = dc.getIntegerState("bar");
         Assert.IsNull(@is);
         @is = dc.getCreateIntegerState("bar");
         Assert.IsNotNull(@is);
         Assert.AreEqual("bar", @is.getName());
         @is = dc.getIntegerState("bar");
         Assert.IsNotNull(@is);
         Assert.AreEqual("bar", @is.getName());
      }


      [TestMethod]
      public virtual void testGetInValidAttributes()
      {
         JDFDoc d = new JDFDoc("DevCap");
         JDFDevCap dc = (JDFDevCap) d.getRoot();
         dc.setDevNS(null);
         Assert.AreEqual(0, dc.getInvalidAttributes(EnumValidationLevel.Complete, true, 0).Count);
         dc.setName("Foo");
         Assert.IsTrue(dc.getInvalidAttributes(EnumValidationLevel.RecursiveComplete, true, 0).Contains("DevNS"));
         Assert.IsTrue(dc.getInvalidAttributes(EnumValidationLevel.Complete, true, 0).Contains("DevNS"));
         dc.setName("FooLink");
         Assert.IsFalse(dc.getInvalidAttributes(EnumValidationLevel.Complete, true, 0).Contains("DevNS"));
         dc.setName("ScreeningParams");
         Assert.IsFalse(dc.getInvalidAttributes(EnumValidationLevel.Complete, true, 0).Contains("DevNS"));
         dc.setName("ScreeningParams_");
         Assert.IsTrue(dc.getInvalidAttributes(EnumValidationLevel.Complete, true, 0).Contains("DevNS"));
      }


      [TestMethod]
      public virtual void testGetNumberState()
      {
         JDFDoc d = new JDFDoc("DevCap");
         JDFDevCap dc = (JDFDevCap) d.getRoot();
         JDFNumberState ns = dc.appendNumberState("foo");
         Assert.AreEqual("foo", ns.getName());
         ns = dc.getNumberState("bar");
         Assert.IsNull(ns);
         ns = dc.getCreateNumberState("bar");
         Assert.IsNotNull(ns);
         Assert.AreEqual("bar", ns.getName());
         ns = dc.getNumberState("bar");
         Assert.IsNotNull(ns);
         Assert.AreEqual("bar", ns.getName());
      }


      [TestMethod]
      public virtual void testGetEnumerationState()
      {
         JDFDoc d = new JDFDoc("DevCap");
         JDFDevCap dc = (JDFDevCap) d.getRoot();
         JDFEnumerationState es = dc.appendEnumerationState("foo");
         Assert.AreEqual("foo", es.getName());
         es = dc.getEnumerationState("bar");
         Assert.IsNull(es);
         es = dc.getCreateEnumerationState("bar");
         Assert.IsNotNull(es);
         Assert.AreEqual("bar", es.getName());
         es = dc.getEnumerationState("bar");
         Assert.IsNotNull(es);
         Assert.AreEqual("bar", es.getName());
      }


      [TestMethod]
      public virtual void testGetNameState()
      {
         JDFDoc d = new JDFDoc("DevCap");
         JDFDevCap dc = (JDFDevCap) d.getRoot();
         JDFNameState ns = dc.appendNameState("foo");
         Assert.AreEqual("foo", ns.getName());
         ns = dc.getNameState("bar");
         Assert.IsNull(ns);
         ns = dc.getCreateNameState("bar");
         Assert.IsNotNull(ns);
         Assert.AreEqual("bar", ns.getName());
         ns = dc.getNameState("bar");
         Assert.IsNotNull(ns);
         Assert.AreEqual("bar", ns.getName());
      }


      [TestMethod]
      public virtual void testGetStringState()
      {
         JDFDoc d = new JDFDoc("DevCap");
         JDFDevCap dc = (JDFDevCap) d.getRoot();
         JDFStringState ss = dc.appendStringState("foo");
         Assert.AreEqual("foo", ss.getName());
         ss = dc.getStringState("bar");
         Assert.IsNull(ss);
         ss = dc.getCreateStringState("bar");
         Assert.IsNotNull(ss);
         Assert.AreEqual("bar", ss.getName());
         ss = dc.getStringState("bar");
         Assert.IsNotNull(ss);
         Assert.AreEqual("bar", ss.getName());
      }


      [TestMethod]
      public virtual void testGetXYPairState()
      {
         JDFDoc d = new JDFDoc("DevCap");
         JDFDevCap dc = (JDFDevCap) d.getRoot();
         JDFXYPairState xy = dc.appendXYPairState("foo");
         Assert.AreEqual("foo", xy.getName());
         xy = dc.getXYPairState("bar");
         Assert.IsNull(xy);
         xy = dc.getCreateXYPairState("bar");
         Assert.IsNotNull(xy);
         Assert.AreEqual("bar", xy.getName());
         xy = dc.getXYPairState("bar");
         Assert.IsNotNull(xy);
         Assert.AreEqual("bar", xy.getName());
      }


      [TestMethod]
      public virtual void testGetShapeState()
      {
         JDFDoc d = new JDFDoc("DevCap");
         JDFDevCap dc = (JDFDevCap) d.getRoot();
         JDFShapeState ss = dc.appendShapeState("foo");
         Assert.AreEqual("foo", ss.getName());
         ss = dc.getShapeState("bar");
         Assert.IsNull(ss);
         ss = dc.getCreateShapeState("bar");
         Assert.IsNotNull(ss);
         Assert.AreEqual("bar", ss.getName());
         ss = dc.getShapeState("bar");
         Assert.IsNotNull(ss);
         Assert.AreEqual("bar", ss.getName());
      }


      [TestMethod]
      public virtual void testGetAvailability()
      {
         JDFDoc d = new JDFDoc("DevCap");
         JDFDevCap dc = (JDFDevCap) d.getRoot();
         dc.setAvailability(EnumAvailability.NotInstalled);
         Assert.AreEqual(EnumAvailability.NotInstalled, dc.getAvailability());
         Assert.AreEqual(EnumAvailability.NotInstalled, dc.getModuleAvailability());
      }


      [TestMethod]
      public virtual void testAppendModuleRef()
      {
         JDFDoc d = new JDFDoc("DeviceCap");
         JDFDeviceCap deviceCap = (JDFDeviceCap) d.getRoot();
         JDFDevCap dc = deviceCap.appendDevCaps().appendDevCap();
         dc.setAvailability(EnumAvailability.NotInstalled);
         Assert.AreEqual(EnumAvailability.NotInstalled, dc.getAvailability());
         Assert.AreEqual(EnumAvailability.NotInstalled, dc.getModuleAvailability());
         JDFModuleCap mc = dc.appendModuleRef("MyDev");
         mc.setAvailability(EnumAvailability.Disabled);
         Assert.AreEqual(EnumAvailability.Module, dc.getAvailability());
         Assert.AreEqual(EnumAvailability.Disabled, dc.getModuleAvailability());
         Assert.AreEqual(EnumAvailability.Disabled, mc.getAvailability());
         mc = dc.appendModuleRef("MyOtherDev");
         mc.setAvailability(EnumAvailability.NotInstalled);
         Assert.AreEqual(EnumAvailability.NotInstalled, dc.getModuleAvailability());
         Assert.AreEqual(EnumAvailability.NotInstalled, mc.getAvailability());
      }


      [TestMethod]
      public virtual void testGetModuleAvailability()
      {
         JDFDoc d = new JDFDoc("DeviceCap");
         JDFDeviceCap deviceCap = (JDFDeviceCap) d.getRoot();
         JDFModuleCap mc = deviceCap.appendModulePool().appendModuleCap();
         mc.setID("i");
         mc.setAvailability(EnumAvailability.NotLicensed);
         JDFDevCap dc = deviceCap.appendDevCaps().appendDevCap();
         Assert.AreEqual(EnumAvailability.Installed, dc.getModuleAvailability());
         dc.setAvailability(EnumAvailability.Module);
         Assert.AreEqual(EnumAvailability.Module, dc.getAvailability());
         Assert.IsNull(dc.getModuleAvailability());
         dc.setModuleRefs(new VString("i", null));
         Assert.AreEqual(EnumAvailability.NotLicensed, dc.getModuleAvailability());
      }


      [TestMethod]
      public virtual void testGetMatrixState()
      {
         JDFDoc d = new JDFDoc("DevCap");
         JDFDevCap dc = (JDFDevCap) d.getRoot();
         JDFMatrixState ms = dc.appendMatrixState("foo");
         Assert.AreEqual("foo", ms.getName());
         ms = dc.getMatrixState("bar");
         Assert.IsNull(ms);
         ms = dc.getCreateMatrixState("bar");
         Assert.IsNotNull(ms);
         Assert.AreEqual("bar", ms.getName());
         ms = dc.getMatrixState("bar");
         Assert.IsNotNull(ms);
         Assert.AreEqual("bar", ms.getName());
      }


      [TestMethod]
      public virtual void testGetDateTimeState()
      {
         JDFDoc d = new JDFDoc("DevCap");
         JDFDevCap dc = (JDFDevCap) d.getRoot();
         JDFDateTimeState dts = dc.appendDateTimeState("foo");
         Assert.AreEqual("foo", dts.getName());
         dts = dc.getDateTimeState("bar");
         Assert.IsNull(dts);
         dts = dc.getCreateDateTimeState("bar");
         Assert.IsNotNull(dts);
         Assert.AreEqual("bar", dts.getName());
         dts = dc.getDateTimeState("bar");
         Assert.IsNotNull(dts);
         Assert.AreEqual("bar", dts.getName());
      }


      [TestMethod]
      public virtual void testGetDurationState()
      {
         JDFDoc d = new JDFDoc("DevCap");
         JDFDevCap dc = (JDFDevCap) d.getRoot();
         JDFDurationState ds = dc.appendDurationState("foo");
         Assert.AreEqual("foo", ds.getName());
         ds = dc.getDurationState("bar");
         Assert.IsNull(ds);
         ds = dc.getCreateDurationState("bar");
         Assert.IsNotNull(ds);
         Assert.AreEqual("bar", ds.getName());
         ds = dc.getDurationState("bar");
         Assert.IsNotNull(ds);
         Assert.AreEqual("bar", ds.getName());
      }


      [TestMethod]
      public virtual void testGetPDFPathState()
      {
         JDFDoc d = new JDFDoc("DevCap");
         JDFDevCap dc = (JDFDevCap) d.getRoot();
         JDFPDFPathState pps = dc.appendPDFPathState("foo");
         Assert.AreEqual("foo", pps.getName());
         pps = dc.getPDFPathState("bar");
         Assert.IsNull(pps);
         pps = dc.getCreatePDFPathState("bar");
         Assert.IsNotNull(pps);
         Assert.AreEqual("bar", pps.getName());
         pps = dc.getPDFPathState("bar");
         Assert.IsNotNull(pps);
         Assert.AreEqual("bar", pps.getName());
      }


      [TestMethod]
      public virtual void testGetRectangleState()
      {
         JDFDoc d = new JDFDoc("DevCap");
         JDFDevCap dc = (JDFDevCap) d.getRoot();
         JDFRectangleState rs = dc.appendRectangleState("foo");
         Assert.AreEqual("foo", rs.getName());
         rs = dc.getRectangleState("bar");
         Assert.IsNull(rs);
         rs = dc.getCreateRectangleState("bar");
         Assert.IsNotNull(rs);
         Assert.AreEqual("bar", rs.getName());
         rs = dc.getRectangleState("bar");
         Assert.IsNotNull(rs);
         Assert.AreEqual("bar", rs.getName());
      }


      [TestMethod]
      public virtual void testStateReportRequired()
      {
         JDFDoc d = new JDFDoc("DevCap");
         JDFDevCap dc = (JDFDevCap) d.getRoot();
         dc.setName("foo");
         JDFIntegerState @is = dc.appendIntegerState();
         @is.setName("bar1");
         @is.setRequired(true);
         JDFIntegerState is2 = dc.appendIntegerState();
         is2.setName("bar2");
         is2.setRequired(false);

         JDFDoc d2 = new JDFDoc("foo");
         KElement foo = d2.getRoot();

         JDFDoc d3 = new JDFDoc("parent");
         KElement parent = d3.getRoot();
         dc.stateReport(foo, EnumFitsValue.Allowed, EnumValidationLevel.Complete, false, true, parent);
         Assert.IsTrue(parent.ToString().IndexOf("bar1") >= 0);
         Assert.IsFalse(parent.ToString().IndexOf("bar2") >= 0);
      }
   }
}
