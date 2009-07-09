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
 * VarnishTest.cs
 * @author muchadie
 */

namespace org.cip4.jdflib.examples
{
   using Microsoft.VisualStudio.TestTools.UnitTesting;

   using JDFTestCaseBase = org.cip4.jdflib.JDFTestCaseBase;
   using EnumMediaType = org.cip4.jdflib.auto.JDFAutoMedia.EnumMediaType;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using VString = org.cip4.jdflib.core.VString;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using JDFIntegerList = org.cip4.jdflib.datatypes.JDFIntegerList;
   using JDFIntegerRangeList = org.cip4.jdflib.datatypes.JDFIntegerRangeList;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using EnumPartIDKey = org.cip4.jdflib.resource.JDFResource.EnumPartIDKey;
   using EnumResourceClass = org.cip4.jdflib.resource.JDFResource.EnumResourceClass;
   using JDFColorantControl = org.cip4.jdflib.resource.process.JDFColorantControl;
   using JDFConventionalPrintingParams = org.cip4.jdflib.resource.process.JDFConventionalPrintingParams;
   using JDFExposedMedia = org.cip4.jdflib.resource.process.JDFExposedMedia;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;
   using JDFInk = org.cip4.jdflib.resource.process.prepress.JDFInk;

   [TestClass]
   public class VarnishTest : JDFTestCaseBase
   {
      ///   
      ///	 <summary> * test iteration
      ///	 * 
      ///	 * @return </summary>
      ///	 
      [TestMethod]
      public virtual void testCombinedVarnish()
      {
         JDFElement.setLongID(false);
         JDFDoc d = new JDFDoc("JDF");
         JDFNode n = d.getJDFRoot();
         VString vCombiNodes = new VString("ConventionalPrinting Varnishing", " ");
         VString vSeparations = new VString("Cyan Magenta Yellow Black Varnish", " ");
         n.setCombined(vCombiNodes);

         JDFConventionalPrintingParams cpp = (JDFConventionalPrintingParams)n.addResource(ElementName.CONVENTIONALPRINTINGPARAMS, null, EnumUsage.Input, null, null, null, null);
         cpp.setModuleAvailableIndex(new JDFIntegerRangeList("1 ~ 6"));
         cpp.setModuleIndex(new JDFIntegerRangeList("1 ~ 4 6"));
         cpp.appendXMLComment("Module 0 and 7 are varnishing modules, 1-4 are process colors and 6 is the ink module used to varnish", null);
         n.appendMatchingResource("Component", JDFNode.EnumProcessUsage.AnyOutput, null);
         JDFExposedMedia xm = (JDFExposedMedia)n.appendMatchingResource("ExposedMedia", JDFNode.EnumProcessUsage.Plate, null);
         n.appendNodeInfo();
         JDFMedia media = xm.appendMedia();
         media.setMediaType(EnumMediaType.Plate);
         JDFInk ink = (JDFInk)n.appendMatchingResource("Ink", JDFNode.EnumProcessUsage.AnyInput, null);

         JDFResource vp = n.addResource("VarnishingParams", EnumResourceClass.Parameter, EnumUsage.Input, null, null, null, null);
         JDFExposedMedia xmVarnish = (JDFExposedMedia)n.addResource("ExposedMedia", null, EnumUsage.Input, null, null, null, null);
         JDFMedia mediaVarnish = xmVarnish.appendMedia();
         mediaVarnish.setAttribute("MediaType", "Sleeve");

         JDFResourceLink rl = n.getLink(xmVarnish, null);
         JDFColorantControl cc = (JDFColorantControl)n.appendMatchingResource(ElementName.COLORANTCONTROL, JDFNode.EnumProcessUsage.AnyInput, null);
         cc.getCreateDeviceColorantOrder().appendXMLComment("Should the VarnishingParams seps be excluded, as is shown here?", null);
         cc.getCreateDeviceColorantOrder().setSeparations(vSeparations);

         rl.setCombinedProcessIndex(new JDFIntegerList("1"));
         vSeparations.addAll(new VString("PreVarnish Varnish2", " "));

         for (int i = 0; i < vSeparations.Count; i++)
         {
            string sep = vSeparations.stringAt(i);
            ink.addPartition(EnumPartIDKey.Separation, sep);
            if (!sep.Equals("PreVarnish") && !sep.Equals("Varnish2"))
            {
               xm.addPartition(EnumPartIDKey.Separation, sep);
            }
            if (sep.Equals("Varnish2"))
            {
               vp.appendXMLComment("full varnishing in a varnishing module with or wihtout a sleeve. Full varnishing means to cover the complete media surface.", null);
               xmVarnish.addPartition(EnumPartIDKey.Separation, sep);
               JDFResource varnishPart = vp.addPartition(EnumPartIDKey.Separation, sep);
               varnishPart.setAttribute("ModuleIndex", "7");
               varnishPart.setAttribute("VarnishMethod", "Sleeve");
               varnishPart.setAttribute("VarnishArea", "Spot");
            }
            else if (sep.Equals("Varnish"))
            {
               vp.appendXMLComment("varnishing in a printing module only  with a mandatory plate. The plate may be exposed or not, for example,  for full varnihing. ", null);
               // xmVarnish.addPartition(EnumPartIDKey.Separation, sep);
               JDFResource varnishPart = vp.addPartition(EnumPartIDKey.Separation, sep);
               varnishPart.setAttribute("ModuleIndex", "6");
               varnishPart.setAttribute("VarnishMethod", "Plate");
               varnishPart.setAttribute("VarnishArea", "Full");
            }
            else if (sep.Equals("PreVarnish"))
            {
               vp.appendXMLComment("varnishing in a varnishing module only with a mandatory prepared sleeve ", null);
               xmVarnish.addPartition(EnumPartIDKey.Separation, sep);
               JDFResource varnishPart = vp.addPartition(EnumPartIDKey.Separation, sep);
               varnishPart.setAttribute("ModuleIndex", "0");
               varnishPart.setAttribute("VarnishMethod", "Sleeve");
               varnishPart.setAttribute("VarnishArea", "Full");
            }
         }

         d.write2File(sm_dirTestDataTemp + "varnishing.jdf", 2, true);
      }
   }
}
