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


namespace org.cip4.jdflib.goldenticket
{

   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFAudit = org.cip4.jdflib.core.JDFAudit;
   using VString = org.cip4.jdflib.core.VString;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using EnumProcessUsage = org.cip4.jdflib.node.JDFNode.EnumProcessUsage;
   using JDFInterpretingParams = org.cip4.jdflib.resource.JDFInterpretingParams;
   using JDFDigitalPrintingParams = org.cip4.jdflib.resource.process.JDFDigitalPrintingParams;
   using JDFRunList = org.cip4.jdflib.resource.process.JDFRunList;

   ///
   /// <summary> * @author Rainer Prosi
   /// * class that generates golden tickets based on ICS levels etc </summary>
   /// 
   public class IDPGoldenTicket : MISGoldenTicket
   {
      protected internal int icsLevel;

      ///    
      ///     <summary> * create a BaseGoldenTicket </summary>
      ///     * <param name="icsLevel"> the level to init to (1,2 or 3) </param>
      ///     * <param name="jdfVersion"> the version to generate a golden ticket for </param>
      ///     * <param name="jmfLevel"> level of jmf ICS to support </param>
      ///     * <param name="misLevel"> level of MIS ICS to support </param>
      ///     * <param name="isGrayBox"> if true, write a grayBox </param>
      ///     
      public IDPGoldenTicket(IDPGoldenTicket previous, VJDFAttributeMap _vparts)
         : base(previous.misICSLevel, previous.theVersion, previous.jmfICSLevel)
      {

         partIDKeys = new VString(previous.partIDKeys);
         vParts = _vparts == null ? new VJDFAttributeMap(previous.vParts) : _vparts;
         icsLevel = previous.icsLevel;
         nCols = previous.nCols;
         workStyle = previous.workStyle;
         thePreviousNode = previous.theNode;
         theParentNode = previous.theParentNode;

      }
      ///    
      ///     <summary> *  </summary>
      ///     
      protected internal override void fillCatMaps()
      {
         base.fillCatMaps();
         catMap["IDP.DigitalPrinting"] = new VString("Interpreting Rendering DigitalPrinting", null);
         setCategory("IDP.DigitalPrinting");
      }

      ///    
      ///     <summary> * create a BaseGoldenTicket </summary>
      ///     * <param name="icsLevel"> the level to init to (1,2 or 3) </param>
      ///     * <param name="jdfVersion"> the version to generate a golden ticket for </param>
      ///     * <param name="jmfLevel"> level of jmf ICS to support </param>
      ///     * <param name="misLevel"> level of MIS ICS to support </param>
      ///     * <param name="isGrayBox"> if true, write a grayBox </param>
      ///     
      public IDPGoldenTicket(MISGoldenTicket parent)
         : base(parent)
      {
      }

      ///    
      ///     <summary> * create a BaseGoldenTicket </summary>
      ///     * <param name="icsLevel"> the level to init to (1,2 or 3) </param>
      ///     * <param name="jdfVersion"> the version to generate a golden ticket for </param>
      ///     * <param name="jmfLevel"> level of jmf ICS to support </param>
      ///     * <param name="misLevel"> level of MIS ICS to support </param>
      ///     * <param name="isGrayBox"> if true, write a grayBox </param>
      ///     
      public IDPGoldenTicket(int _icsLevel)
         : base(1, null, 2)
      {
         icsLevel = _icsLevel;
      }

      ///    
      ///     <summary> * initializes this node to a given ICS version </summary>
      ///     * <param name="icsLevel"> the level to init to (1,2 or 3) </param>
      ///     
      public override void init()
      {

         string icsTag = "IDP_L" + icsLevel + "-" + theVersion.getName();
         theNode.appendAttribute(AttributeName.ICSVERSIONS, icsTag, null, " ", true);
         if (!theNode.hasAttribute(AttributeName.DESCRIPTIVENAME))
            theNode.setDescriptiveName("IDP Golden Ticket Example Job - version: " + JDFAudit.software());
         base.init();
         setActivePart(vParts, true);
         initDocumentRunList();
         initDigitalPrintingParams();
         initOutputComponent();
         initInterpretingParams();
      }


      ///    
      ///     <summary> *  </summary>
      ///     
      private JDFInterpretingParams initInterpretingParams()
      {
         return (JDFInterpretingParams)theNode.getCreateResource(ElementName.INTERPRETINGPARAMS, EnumUsage.Input, 0);

      }
      ///    
      ///     <summary> *  </summary>
      ///     
      private JDFDigitalPrintingParams initDigitalPrintingParams()
      {
         return (JDFDigitalPrintingParams)theNode.getCreateResource(ElementName.DIGITALPRINTINGPARAMS, EnumUsage.Input, 0);

      }
      ///    
      ///     <summary> *  </summary>
      ///     
      protected internal override void initJDF()
      {
         base.initJDF();
      }

      ///    
      ///     <summary> * simulate execution of this node
      ///     * the internal node will be modified to reflect the excution </summary>
      ///     
      public override void execute(VJDFAttributeMap parts, bool outputAvailable, bool bFirst)
      {
         VJDFAttributeMap partsLocal = parts;

         partsLocal = null; // alwways execute all in pp
         setActivePart(partsLocal, bFirst);
         base.execute(partsLocal, outputAvailable, bFirst);
      }

      //     (non-Javadoc)
      //     * @see org.cip4.jdflib.goldenticket.BaseGoldenTicket#initDocumentRunList()
      //     
      protected internal override JDFRunList initDocumentRunList()
      {
         JDFRunList rl = base.initDocumentRunList();
         theNode.getLink(rl, EnumUsage.Input).setProcessUsage((EnumProcessUsage)null);

         return rl;
      }
   }
}
