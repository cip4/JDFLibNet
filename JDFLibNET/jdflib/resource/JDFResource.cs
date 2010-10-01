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


namespace org.cip4.jdflib.resource
{
   using System;
   using System.Runtime.CompilerServices;
   using System.Collections;
   using System.Collections.Generic;
   using System.Text;

   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   using EnumPreviewType = org.cip4.jdflib.auto.JDFAutoPart.EnumPreviewType;
   using EnumSide = org.cip4.jdflib.auto.JDFAutoPart.EnumSide;
   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFAudit = org.cip4.jdflib.core.JDFAudit;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFCustomerInfo = org.cip4.jdflib.core.JDFCustomerInfo;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFNodeInfo = org.cip4.jdflib.core.JDFNodeInfo;
   using JDFRefElement = org.cip4.jdflib.core.JDFRefElement;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using JDFIntegerRangeList = org.cip4.jdflib.datatypes.JDFIntegerRangeList;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using JDFJMF = org.cip4.jdflib.jmf.JDFJMF;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using EnumType = org.cip4.jdflib.node.JDFNode.EnumType;
   using JDFPool = org.cip4.jdflib.pool.JDFPool;
   using JDFResourcePool = org.cip4.jdflib.pool.JDFResourcePool;
   using JDFContact = org.cip4.jdflib.resource.process.JDFContact;
   using JDFGeneralID = org.cip4.jdflib.resource.process.JDFGeneralID;
   using JDFIdentical = org.cip4.jdflib.resource.process.JDFIdentical;
   using JDFIdentificationField = org.cip4.jdflib.resource.process.JDFIdentificationField;
   using JDFQualityControlResult = org.cip4.jdflib.resource.process.JDFQualityControlResult;
   using JDFSourceResource = org.cip4.jdflib.resource.process.JDFSourceResource;
   using EnumUtil = org.cip4.jdflib.util.EnumUtil;
   using JDFMerge = org.cip4.jdflib.util.JDFMerge;
   using StringUtil = org.cip4.jdflib.util.StringUtil;

   public class JDFResource : JDFElement
   {
      private new const long serialVersionUID = 1L;
      private static bool autoAgent = false;

      private static SupportClass.HashSetSupport<string> validParentNodeNameSet = null;
      private static SupportClass.HashSetSupport<string> validRootParentNodeNameSet = null;

      private static AtrInfoTable[] atrInfoTable_Abstract = new AtrInfoTable[17];
      static JDFResource()
      {
         atrInfoTable_Abstract[0] = new AtrInfoTable(AttributeName.AGENTNAME, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable_Abstract[1] = new AtrInfoTable(AttributeName.AGENTVERSION, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable_Abstract[2] = new AtrInfoTable(AttributeName.AUTHOR, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable_Abstract[3] = new AtrInfoTable(AttributeName.CATALOGID, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable_Abstract[4] = new AtrInfoTable(AttributeName.CATALOGDETAILS, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable_Abstract[5] = new AtrInfoTable(AttributeName.LOCKED, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable_Abstract[6] = new AtrInfoTable(AttributeName.PIPEID, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable_Abstract[7] = new AtrInfoTable(AttributeName.PIPEPROTOCOL, 0x33333311, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable_Abstract[8] = new AtrInfoTable(AttributeName.PIPEURL, 0x33333311, AttributeInfo.EnumAttributeType.URL, null, null);
         atrInfoTable_Abstract[9] = new AtrInfoTable(AttributeName.PRODUCTID, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable_Abstract[10] = new AtrInfoTable(AttributeName.RREFS, 0x44444433, AttributeInfo.EnumAttributeType.IDREFS, null, null);
         atrInfoTable_Abstract[11] = new AtrInfoTable(AttributeName.SPAWNSTATUS, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumSpawnStatus.getEnum(0), EnumSpawnStatus.NotSpawned.getName());
         atrInfoTable_Abstract[12] = new AtrInfoTable(AttributeName.SPAWNIDS, 0x33333331, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable_Abstract[13] = new AtrInfoTable(AttributeName.SORTING, 0x33333333, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable_Abstract[14] = new AtrInfoTable(AttributeName.SORTAMOUNT, 0x33333333, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable_Abstract[15] = new AtrInfoTable(AttributeName.PARTIDKEYS, 0x33333333, AttributeInfo.EnumAttributeType.enumerations, EnumPartIDKey.getEnum(0), null);
         atrInfoTable_Abstract[16] = new AtrInfoTable(AttributeName.PIPEPARTIDKEYS, 0x33333311, AttributeInfo.EnumAttributeType.enumerations, EnumPartIDKey.getEnum(0), null);
         atrInfoTable_Physical[0] = new AtrInfoTable(AttributeName.ALTERNATEBRAND, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable_Physical[1] = new AtrInfoTable(AttributeName.AMOUNT, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable_Physical[2] = new AtrInfoTable(AttributeName.AMOUNTPRODUCED, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable_Physical[3] = new AtrInfoTable(AttributeName.AMOUNTREQUIRED, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable_Physical[4] = new AtrInfoTable(AttributeName.BATCHID, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable_Physical[5] = new AtrInfoTable(AttributeName.BRAND, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable_Physical[6] = new AtrInfoTable(AttributeName.UNIT, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable_Physical[7] = new AtrInfoTable(AttributeName.RESOURCEWEIGHT, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable_Physical[8] = new AtrInfoTable(AttributeName.GROSSWEIGHT, 0x33333111, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable_Physical[9] = new AtrInfoTable(AttributeName.MANUFACTURER, 0x33333111, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable_Physical[10] = new AtrInfoTable(AttributeName.LOTCONTROL, 0x33333111, AttributeInfo.EnumAttributeType.enumeration, EnumLotControl.getEnum(0), null);
         atrInfoTable_Param[0] = new AtrInfoTable(AttributeName.NOOP, 0x33333331, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable_ID_Class_Required[0] = new AtrInfoTable(AttributeName.ID, 0x22222222, AttributeInfo.EnumAttributeType.ID, null, null);
         atrInfoTable_ID_Class_Required[1] = new AtrInfoTable(AttributeName.CLASS, 0x22222222, AttributeInfo.EnumAttributeType.enumeration, EnumResourceClass.getEnum(0), null);
         atrInfoTable_ID_Class_Required[2] = new AtrInfoTable(AttributeName.PARTUSAGE, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumPartUsage.getEnum(0), EnumPartUsage.Explicit.getName());

         atrInfoTable_ID_Class_Optional[0] = new AtrInfoTable(AttributeName.ID, 0x44444433, AttributeInfo.EnumAttributeType.ID, null, null);
         atrInfoTable_ID_Class_Optional[1] = new AtrInfoTable(AttributeName.CLASS, 0x33333333, AttributeInfo.EnumAttributeType.ID, null, null);
         atrInfoTable_ID_Class_Root[0] = new AtrInfoTable(AttributeName.ID, 0x33333333, AttributeInfo.EnumAttributeType.ID, null, null);
         atrInfoTable_ID_Class_Root[1] = new AtrInfoTable(AttributeName.CLASS, 0x33333333, AttributeInfo.EnumAttributeType.ID, null, null);
         atrInfoTable_ID_Class_Root[2] = new AtrInfoTable(AttributeName.PARTUSAGE, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumPartUsage.getEnum(0), null);
         atrInfoTable_Status_Required[0] = new AtrInfoTable(AttributeName.STATUS, 0x22222222, AttributeInfo.EnumAttributeType.enumeration, EnumResStatus.getEnum(0), null);
         atrInfoTable_Status_Optional[0] = new AtrInfoTable(AttributeName.STATUS, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumResStatus.getEnum(0), null);
         atrInfoTable_UpdateID_Optional[0] = new AtrInfoTable(AttributeName.UPDATEID, 0x44444331, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable_UpdateID_Required[0] = new AtrInfoTable(AttributeName.UPDATEID, 0x44444221, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable_PartIDKeys[0] = new AtrInfoTable(AttributeName.BINDERYSIGNATURENAME, 0x33333311, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable_PartIDKeys[1] = new AtrInfoTable(AttributeName.BLOCKNAME, 0x33333331, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable_PartIDKeys[2] = new AtrInfoTable(AttributeName.BUNDLEITEMINDEX, 0x33333311, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable_PartIDKeys[3] = new AtrInfoTable(AttributeName.CELLINDEX, 0x33333311, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable_PartIDKeys[4] = new AtrInfoTable(AttributeName.CONDITION, 0x33333311, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable_PartIDKeys[5] = new AtrInfoTable(AttributeName.DOCCOPIES, 0x33333333, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable_PartIDKeys[6] = new AtrInfoTable(AttributeName.DOCINDEX, 0x33333333, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable_PartIDKeys[7] = new AtrInfoTable(AttributeName.DOCRUNINDEX, 0x33333333, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable_PartIDKeys[8] = new AtrInfoTable(AttributeName.DOCSHEETINDEX, 0x33333333, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable_PartIDKeys[9] = new AtrInfoTable(AttributeName.FOUNTAINNUMBER, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable_PartIDKeys[10] = new AtrInfoTable(AttributeName.ITEMNAMES, 0x33333311, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable_PartIDKeys[11] = new AtrInfoTable(AttributeName.LAYERIDS, 0x33333331, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable_PartIDKeys[12] = new AtrInfoTable(AttributeName.LOCATION, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable_PartIDKeys[13] = new AtrInfoTable(AttributeName.OPTION, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable_PartIDKeys[14] = new AtrInfoTable(AttributeName.PAGENUMBER, 0x33333333, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable_PartIDKeys[15] = new AtrInfoTable(AttributeName.PARTVERSION, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable_PartIDKeys[16] = new AtrInfoTable(AttributeName.PREFLIGHTRULE, 0x33333311, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable_PartIDKeys[17] = new AtrInfoTable(AttributeName.PREVIEWTYPE, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumPreviewType.getEnum(0), null);
         atrInfoTable_PartIDKeys[18] = new AtrInfoTable(AttributeName.RIBBONNAME, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable_PartIDKeys[19] = new AtrInfoTable(AttributeName.RUN, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable_PartIDKeys[20] = new AtrInfoTable(AttributeName.RUNINDEX, 0x33333333, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable_PartIDKeys[21] = new AtrInfoTable(AttributeName.RUNTAGS, 0x33333331, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable_PartIDKeys[22] = new AtrInfoTable(AttributeName.RUNPAGE, 0x33333331, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable_PartIDKeys[23] = new AtrInfoTable(AttributeName.SECTIONINDEX, 0x33333311, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable_PartIDKeys[24] = new AtrInfoTable(AttributeName.SEPARATION, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable_PartIDKeys[25] = new AtrInfoTable(AttributeName.SETDOCINDEX, 0x33333311, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable_PartIDKeys[26] = new AtrInfoTable(AttributeName.SETINDEX, 0x33333331, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable_PartIDKeys[27] = new AtrInfoTable(AttributeName.SETRUNINDEX, 0x33333311, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable_PartIDKeys[28] = new AtrInfoTable(AttributeName.SETSHEETINDEX, 0x33333311, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable_PartIDKeys[29] = new AtrInfoTable(AttributeName.SHEETINDEX, 0x33333333, AttributeInfo.EnumAttributeType.IntegerRangeList, null, null);
         atrInfoTable_PartIDKeys[30] = new AtrInfoTable(AttributeName.SHEETNAME, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable_PartIDKeys[31] = new AtrInfoTable(AttributeName.SIDE, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumSide.getEnum(0), null);
         atrInfoTable_PartIDKeys[32] = new AtrInfoTable(AttributeName.SIGNATURENAME, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable_PartIDKeys[33] = new AtrInfoTable(AttributeName.TILEID, 0x33333333, AttributeInfo.EnumAttributeType.XYPair, null, null);
         atrInfoTable_PartIDKeys[34] = new AtrInfoTable(AttributeName.WEBNAME, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable_PartIDKeys[35] = new AtrInfoTable(AttributeName.DELIVERYUNIT0, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable_PartIDKeys[36] = new AtrInfoTable(AttributeName.DELIVERYUNIT1, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable_PartIDKeys[37] = new AtrInfoTable(AttributeName.DELIVERYUNIT2, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable_PartIDKeys[38] = new AtrInfoTable(AttributeName.DELIVERYUNIT3, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable_PartIDKeys[39] = new AtrInfoTable(AttributeName.DELIVERYUNIT4, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable_PartIDKeys[40] = new AtrInfoTable(AttributeName.DELIVERYUNIT5, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable_PartIDKeys[41] = new AtrInfoTable(AttributeName.DELIVERYUNIT6, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable_PartIDKeys[42] = new AtrInfoTable(AttributeName.DELIVERYUNIT7, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable_PartIDKeys[43] = new AtrInfoTable(AttributeName.DELIVERYUNIT8, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable_PartIDKeys[44] = new AtrInfoTable(AttributeName.DELIVERYUNIT9, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable_PartIDKeys[45] = new AtrInfoTable(AttributeName.EDITION, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable_PartIDKeys[46] = new AtrInfoTable(AttributeName.EDITIONVERSION, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable_PartIDKeys[47] = new AtrInfoTable(AttributeName.PAGETAGS, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable_PartIDKeys[48] = new AtrInfoTable(AttributeName.PLATELAYOUT, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable_PartIDKeys[49] = new AtrInfoTable(AttributeName.WEBSETUP, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable_PartIDKeys[50] = new AtrInfoTable(AttributeName.RUNSET, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable_PartIDKeys[51] = new AtrInfoTable(AttributeName.DOCTAGS, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable_PartIDKeys[52] = new AtrInfoTable(AttributeName.SETTAGS, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable_PartIDKeys[53] = new AtrInfoTable(AttributeName.SUBRUN, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable_PartIDKeys[54] = new AtrInfoTable(AttributeName.WEBPRODUCT, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         elemInfoTable_Abstract[0] = new ElemInfoTable(ElementName.QUALITYCONTROLRESULT, 0x33333311);
         elemInfoTable_Abstract[1] = new ElemInfoTable(ElementName.GENERALID, 0x33333111);
         elemInfoTable_Abstract[2] = new ElemInfoTable(ElementName.SOURCERESOURCE, 0x33333111);
         elemInfoTable_Abstract[3] = new ElemInfoTable(ElementName.IDENTICAL, 0x33333111);
         elemInfoTable_Physical[0] = new ElemInfoTable(ElementName.LOCATION, 0x33333333);
         elemInfoTable_Physical[1] = new ElemInfoTable(ElementName.CONTACT, 0x33333333);
         elemInfoTable_Physical[2] = new ElemInfoTable(ElementName.IDENTIFICATIONFIELD, 0x33333331);
      }

      private static AtrInfoTable[] atrInfoTable_Physical = new AtrInfoTable[11];

      private static AtrInfoTable[] atrInfoTable_Param = new AtrInfoTable[1];

      private static AtrInfoTable[] atrInfoTable_ID_Class_Required = new AtrInfoTable[3];

      private static AtrInfoTable[] atrInfoTable_ID_Class_Optional = new AtrInfoTable[2];
      private static AtrInfoTable[] atrInfoTable_ID_Class_Root = new AtrInfoTable[3];

      private static AtrInfoTable[] atrInfoTable_Status_Required = new AtrInfoTable[1];

      private static AtrInfoTable[] atrInfoTable_Status_Optional = new AtrInfoTable[1];

      private static AtrInfoTable[] atrInfoTable_UpdateID_Optional = new AtrInfoTable[1];

      private static AtrInfoTable[] atrInfoTable_UpdateID_Required = new AtrInfoTable[1];

      private static AtrInfoTable[] atrInfoTable_PartIDKeys = new AtrInfoTable[55];

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         AttributeInfo ai = base.getTheAttributeInfo().updateReplace(atrInfoTable_Abstract);

         if (isPhysical())
         {
            ai.updateAdd(atrInfoTable_Physical);
         }
         else if (isParameter())
         {
            ai.updateAdd(atrInfoTable_Param);
         }

         if (isResourceUpdate())
         {
            ai.updateAdd(atrInfoTable_UpdateID_Required);
         }
         else
         {
            ai.updateAdd(atrInfoTable_UpdateID_Optional);
         }

         if (isResourceRootRoot())
         {
            ai.updateAdd(atrInfoTable_ID_Class_Required);
            ai.updateAdd(atrInfoTable_Status_Required);
         }
         else
         {
            if (isResourceElement())
            {
               ai.updateAdd(atrInfoTable_ID_Class_Optional);
            }
            else if (isResourceRoot())
            {
               ai.updateAdd(atrInfoTable_ID_Class_Root);
               ai.updateAdd(atrInfoTable_Status_Optional);
            }
            else
            // resource partition
            {
               ai.updateAdd(atrInfoTable_Status_Optional);
            }
         }

         VString partIDKeys = getPartIDKeys();
         if (partIDKeys != null)
         {
            int siz = partIDKeys.Count;
            for (int i = 0; i < siz; i++)
            {
               string partIDKey = partIDKeys.stringAt(i);
               for (int j = 0; j < atrInfoTable_PartIDKeys.Length; j++)
               {
                  AtrInfoTable keyTable = atrInfoTable_PartIDKeys[j];
                  string key = keyTable.getAttributeName();
                  if (key.Equals(partIDKey))
                  {
                     ai.updateAdd(keyTable);
                     break;
                  }
               }
            }
         }

         return ai;
      }

      private static ElemInfoTable[] elemInfoTable_Abstract = new ElemInfoTable[4];

      private static ElemInfoTable[] elemInfoTable_Physical = new ElemInfoTable[3];

      protected internal override ElementInfo getTheElementInfo()
      {
         ElementInfo ei = base.getTheElementInfo().updateAdd(elemInfoTable_Abstract);

         if (isPhysical())
         {
            ei.updateAdd(elemInfoTable_Physical);
         }

         JDFResource resRoot = getResourceRoot();

         if (resRoot != null && resRoot.hasAttribute(AttributeName.PARTIDKEYS, null, false))
         {
            ei.updateAdd(new ElemInfoTable(Name, 0x33333333));
         }

         return ei;
      }

      //   
      //	 * These three constructors are defined first in ElementNSImpl they correspond to the three createElement methods in
      //	 * DocumentJDFImpl which are used to create the JDF elements during parsing
      //	 * 
      //	 * they are necessary in every class, which is inherited from JDFElement
      //	 

      ///   
      ///	 <summary> * Constructor for JDFResource
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFResource(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFResource
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFResource(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFResource
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFResource(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      // **************************************** Enumerations
      // *********************************************

      ///   
      ///	 <summary> * Enumeration for the policy of merging the amounts from ResourceLinks
      ///	 * <p>
      ///	 * <li><b>AmountMerge_none - </b>does not recalculate amounts</li>
      ///	 * <li><b>AmountMerge_LinkOnly - </b>calculates the Resource Amount based on the Amount values in the ResourceLinks
      ///	 * only.<br>
      ///	 * The original Resource Amount is ignored</li>
      ///	 * <li><b>AmountMerge_UpdateLink - </b>calculates the Resource Amount based on the difference of previous and
      ///	 * current resource link amounts</li> </summary>
      ///	 
      public sealed class EnumAmountMerge : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumAmountMerge(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumAmountMerge getEnum(string enumName)
         {
            return (EnumAmountMerge)getEnum(typeof(EnumAmountMerge), enumName);
         }

         public static EnumAmountMerge getEnum(int enumValue)
         {
            return (EnumAmountMerge)getEnum(typeof(EnumAmountMerge), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumAmountMerge));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumAmountMerge));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumAmountMerge));
         }

         public static readonly EnumAmountMerge None = new EnumAmountMerge("None");
         public static readonly EnumAmountMerge LinkOnly = new EnumAmountMerge("LinkOnly");
         public static readonly EnumAmountMerge UpdateLink = new EnumAmountMerge("UpdateLink");
      }

      ///   
      ///	 <summary> * Enumeration for attribute Class </summary>
      ///	 
      public sealed class EnumResourceClass : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumResourceClass(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumResourceClass getEnum(string enumName)
         {
            return (EnumResourceClass)getEnum(typeof(EnumResourceClass), enumName);
         }

         public static EnumResourceClass getEnum(int enumValue)
         {
            return (EnumResourceClass)getEnum(typeof(EnumResourceClass), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumResourceClass));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumResourceClass));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumResourceClass));
         }

         public static readonly EnumResourceClass Parameter = new EnumResourceClass("Parameter");
         public static readonly EnumResourceClass Handling = new EnumResourceClass("Handling");
         public static readonly EnumResourceClass Consumable = new EnumResourceClass("Consumable");
         public static readonly EnumResourceClass Quantity = new EnumResourceClass("Quantity");
         public static readonly EnumResourceClass Implementation = new EnumResourceClass("Implementation");
         public static readonly EnumResourceClass PlaceHolder = new EnumResourceClass("PlaceHolder");
         public static readonly EnumResourceClass Intent = new EnumResourceClass("Intent");
      }

      ///   
      ///	 <summary> * Enumeration for attribute Status </summary>
      ///	 
      public sealed class EnumResStatus : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumResStatus(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumResStatus getEnum(string enumName)
         {
            return (EnumResStatus)getEnum(typeof(EnumResStatus), enumName);
         }

         public static EnumResStatus getEnum(int enumValue)
         {
            return (EnumResStatus)getEnum(typeof(EnumResStatus), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumResStatus));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumResStatus));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumResStatus));
         }

         // EnumResStatus : enums accordng to JDF spec 3.7, Table 3-11 Status
         public static readonly EnumResStatus Incomplete = new EnumResStatus(JDFConstants.INCOMPLETE);
         public static readonly EnumResStatus Rejected = new EnumResStatus(JDFConstants.REJECTED);
         public static readonly EnumResStatus Unavailable = new EnumResStatus(JDFConstants.UNAVAILABLE);
         public static readonly EnumResStatus InUse = new EnumResStatus(JDFConstants.INUSE);
         public static readonly EnumResStatus Draft = new EnumResStatus(JDFConstants.DRAFT);
         public static readonly EnumResStatus Complete = new EnumResStatus(JDFConstants.COMPLETE);
         public static readonly EnumResStatus Available = new EnumResStatus(JDFConstants.AVAILABLE);

      }

      ///   
      ///	 <summary> * Enumeration for attribute Status </summary>
      ///	 
      public sealed class EnumLotControl : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumLotControl(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumLotControl getEnum(string enumName)
         {
            return (EnumLotControl)getEnum(typeof(EnumLotControl), enumName);
         }

         public static EnumLotControl getEnum(int enumValue)
         {
            return (EnumLotControl)getEnum(typeof(EnumLotControl), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumLotControl));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumLotControl));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumLotControl));
         }

         // EnumLotControl : enums accordng to JDF spec 3.7, Table 3-11 Status
         public static readonly EnumLotControl Controlled = new EnumLotControl(JDFConstants.LOTCONTROL_CONTROLLED);
         public static readonly EnumLotControl NotControlled = new EnumLotControl(JDFConstants.LOTCONTROL_NOTCONTROLLED);
      }

      ///   
      ///	 <summary> * Enumeration for attribute PartUsage </summary>
      ///	 
      public sealed class EnumPartUsage : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumPartUsage(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumPartUsage getEnum(string enumName)
         {
            return (EnumPartUsage)getEnum(typeof(EnumPartUsage), enumName);
         }

         public static EnumPartUsage getEnum(int enumValue)
         {
            return (EnumPartUsage)getEnum(typeof(EnumPartUsage), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumPartUsage));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumPartUsage));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumPartUsage));
         }

         // public static final EnumPartUsage Unknown = new
         // EnumPartUsage(JDFConstants.PARTUSAGE_UNKNOWN);
         public static readonly EnumPartUsage Explicit = new EnumPartUsage(JDFConstants.PARTUSAGE_EXPLICIT);
         public static readonly EnumPartUsage Sparse = new EnumPartUsage(JDFConstants.PARTUSAGE_SPARSE);
         public static readonly EnumPartUsage Implicit = new EnumPartUsage(JDFConstants.PARTUSAGE_IMPLICIT);
      }

      ///   
      ///	 <summary> * Enumeration for partition keys </summary>
      ///	 
      public sealed class EnumPartIDKey : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         ///      
         ///		 * <seealso cref= java.lang.Object#toString() </seealso>
         ///		 * @deprecated [BLD009] just for compiling PrintReady, to be removed afterwards 
         ///		 
         [Obsolete("[BLD009] just for compiling PrintReady, to be removed afterwards")]
         public override string ToString()
         {
            return getName();
         }

         private EnumPartIDKey(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumPartIDKey getEnum(string enumName)
         {
            return (EnumPartIDKey)getEnum(typeof(EnumPartIDKey), enumName);
         }

         public static EnumPartIDKey getEnum(int enumValue)
         {
            return (EnumPartIDKey)getEnum(typeof(EnumPartIDKey), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumPartIDKey));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumPartIDKey));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumPartIDKey));
         }

         public static readonly EnumPartIDKey BinderySignatureName = new EnumPartIDKey(JDFConstants.PARTIDKEY_BINDERYSIGNATURENAME);
         public static readonly EnumPartIDKey BlockName = new EnumPartIDKey(JDFConstants.PARTIDKEY_BLOCKNAME);
         public static readonly EnumPartIDKey BundleItemIndex = new EnumPartIDKey(JDFConstants.PARTIDKEY_BUNDLEITEMINDEX);
         public static readonly EnumPartIDKey CellIndex = new EnumPartIDKey(JDFConstants.PARTIDKEY_CELLINDEX);
         public static readonly EnumPartIDKey Condition = new EnumPartIDKey(JDFConstants.PARTIDKEY_CONDITION);
         public static readonly EnumPartIDKey DocCopies = new EnumPartIDKey(JDFConstants.PARTIDKEY_DOCCOPIES);
         public static readonly EnumPartIDKey DocIndex = new EnumPartIDKey(JDFConstants.PARTIDKEY_DOCINDEX);
         public static readonly EnumPartIDKey DocRunIndex = new EnumPartIDKey(JDFConstants.PARTIDKEY_DOCRUNINDEX);
         public static readonly EnumPartIDKey DocSheetIndex = new EnumPartIDKey(JDFConstants.PARTIDKEY_DOCSHEETINDEX);
         public static readonly EnumPartIDKey FountainNumber = new EnumPartIDKey(JDFConstants.PARTIDKEY_FOUNTAINNUMBER);
         public static readonly EnumPartIDKey ItemNames = new EnumPartIDKey(JDFConstants.PARTIDKEY_ITEMNAMES);
         public static readonly EnumPartIDKey LayerIDs = new EnumPartIDKey(JDFConstants.PARTIDKEY_LAYERIDS);
         public static readonly EnumPartIDKey Location = new EnumPartIDKey(JDFConstants.PARTIDKEY_LOCATION);
         public static readonly EnumPartIDKey Option = new EnumPartIDKey(JDFConstants.PARTIDKEY_OPTION);
         public static readonly EnumPartIDKey PageNumber = new EnumPartIDKey(JDFConstants.PARTIDKEY_PAGENUMBER);
         public static readonly EnumPartIDKey PartVersion = new EnumPartIDKey(JDFConstants.PARTIDKEY_PARTVERSION);
         public static readonly EnumPartIDKey PreflightRule = new EnumPartIDKey(JDFConstants.PARTIDKEY_PREFLIGHTRULE);
         public static readonly EnumPartIDKey PreviewType = new EnumPartIDKey(JDFConstants.PARTIDKEY_PREVIEWTYPE);
         public static readonly EnumPartIDKey RibbonName = new EnumPartIDKey(JDFConstants.PARTIDKEY_RIBBONNAME);
         public static readonly EnumPartIDKey Run = new EnumPartIDKey(JDFConstants.PARTIDKEY_RUN);
         public static readonly EnumPartIDKey RunIndex = new EnumPartIDKey(JDFConstants.PARTIDKEY_RUNINDEX);
         public static readonly EnumPartIDKey RunTags = new EnumPartIDKey(JDFConstants.PARTIDKEY_RUNTAGS);
         public static readonly EnumPartIDKey RunPage = new EnumPartIDKey(JDFConstants.PARTIDKEY_RUNPAGE);
         public static readonly EnumPartIDKey Separation = new EnumPartIDKey(JDFConstants.PARTIDKEY_SEPARATION);
         public static readonly EnumPartIDKey SectionIndex = new EnumPartIDKey(JDFConstants.PARTIDKEY_SECTIONINDEX);
         public static readonly EnumPartIDKey SetDocIndex = new EnumPartIDKey(JDFConstants.PARTIDKEY_SETDOCINDEX);
         public static readonly EnumPartIDKey SetSheetIndex = new EnumPartIDKey(JDFConstants.PARTIDKEY_SETSHEETINDEX);
         public static readonly EnumPartIDKey SetIndex = new EnumPartIDKey(JDFConstants.PARTIDKEY_SETINDEX);
         public static readonly EnumPartIDKey SetRunIndex = new EnumPartIDKey(JDFConstants.PARTIDKEY_SETRUNINDEX);
         public static readonly EnumPartIDKey SheetIndex = new EnumPartIDKey(JDFConstants.PARTIDKEY_SHEETINDEX);
         public static readonly EnumPartIDKey SheetName = new EnumPartIDKey(JDFConstants.PARTIDKEY_SHEETNAME);
         public static readonly EnumPartIDKey Side = new EnumPartIDKey(JDFConstants.PARTIDKEY_SIDE);
         public static readonly EnumPartIDKey SignatureName = new EnumPartIDKey(JDFConstants.PARTIDKEY_SIGNATURENAME);
         public static readonly EnumPartIDKey TileID = new EnumPartIDKey(JDFConstants.PARTIDKEY_TILEID);
         public static readonly EnumPartIDKey WebName = new EnumPartIDKey(JDFConstants.PARTIDKEY_WEBNAME);
         // new in JDF 1.3
         public static readonly EnumPartIDKey DeliveryUnit0 = new EnumPartIDKey(AttributeName.DELIVERYUNIT0);
         public static readonly EnumPartIDKey DeliveryUnit1 = new EnumPartIDKey(AttributeName.DELIVERYUNIT1);
         public static readonly EnumPartIDKey DeliveryUnit2 = new EnumPartIDKey(AttributeName.DELIVERYUNIT2);
         public static readonly EnumPartIDKey DeliveryUnit3 = new EnumPartIDKey(AttributeName.DELIVERYUNIT3);
         public static readonly EnumPartIDKey DeliveryUnit4 = new EnumPartIDKey(AttributeName.DELIVERYUNIT4);
         public static readonly EnumPartIDKey DeliveryUnit5 = new EnumPartIDKey(AttributeName.DELIVERYUNIT5);
         public static readonly EnumPartIDKey DeliveryUnit6 = new EnumPartIDKey(AttributeName.DELIVERYUNIT6);
         public static readonly EnumPartIDKey DeliveryUnit7 = new EnumPartIDKey(AttributeName.DELIVERYUNIT7);
         public static readonly EnumPartIDKey DeliveryUnit8 = new EnumPartIDKey(AttributeName.DELIVERYUNIT8);
         public static readonly EnumPartIDKey DeliveryUnit9 = new EnumPartIDKey(AttributeName.DELIVERYUNIT9);
         public static readonly EnumPartIDKey Edition = new EnumPartIDKey(AttributeName.EDITION);
         public static readonly EnumPartIDKey EditionVersion = new EnumPartIDKey(AttributeName.EDITIONVERSION);
         public static readonly EnumPartIDKey PageTags = new EnumPartIDKey(AttributeName.PAGETAGS);
         public static readonly EnumPartIDKey PlateLayout = new EnumPartIDKey(AttributeName.PLATELAYOUT);
         public static readonly EnumPartIDKey RunSet = new EnumPartIDKey(AttributeName.RUNSET);
         public static readonly EnumPartIDKey DocTags = new EnumPartIDKey(AttributeName.DOCTAGS);
         public static readonly EnumPartIDKey SetTags = new EnumPartIDKey(AttributeName.SETTAGS);
         public static readonly EnumPartIDKey SubRun = new EnumPartIDKey(AttributeName.SUBRUN);
         public static readonly EnumPartIDKey WebProduct = new EnumPartIDKey(AttributeName.WEBPRODUCT);
         public static readonly EnumPartIDKey StationName = new EnumPartIDKey(AttributeName.STATIONNAME); // jdf1
         // .3
         // errata
         // addition
         public static readonly EnumPartIDKey WebSetup = new EnumPartIDKey(AttributeName.WEBSETUP);
      }

      ///   
      ///	 <summary> * Enumeration for attribute SpawnStatus </summary>
      ///	 
      public sealed class EnumSpawnStatus : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         ///      
         ///		 * <seealso cref= java.lang.Object#toString() </seealso>
         ///		 * @deprecated [BLD009] just for compiling PrintReady, to be removed afterwards 
         ///		 
         [Obsolete("[BLD009] just for compiling PrintReady, to be removed afterwards")]
         public override string ToString()
         {
            return getName();
         }

         private EnumSpawnStatus(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumSpawnStatus getEnum(string enumName)
         {
            return (EnumSpawnStatus)getEnum(typeof(EnumSpawnStatus), enumName);
         }

         public static EnumSpawnStatus getEnum(int enumValue)
         {
            return (EnumSpawnStatus)getEnum(typeof(EnumSpawnStatus), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumSpawnStatus));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumSpawnStatus));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumSpawnStatus));
         }

         // EnumSpawnStatus : enums accordng to JDF spec 3.7, Table 3-11
         // SpawnStatus
         public static readonly EnumSpawnStatus NotSpawned = new EnumSpawnStatus(JDFConstants.NOTSPAWNED);
         public static readonly EnumSpawnStatus SpawnedRO = new EnumSpawnStatus(JDFConstants.SPAWNEDRO);
         public static readonly EnumSpawnStatus SpawnedRW = new EnumSpawnStatus(JDFConstants.SPAWNEDRW);
      }

      // **************************************** Methods
      // *********************************************
      ///   
      ///	 <summary> * toString
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public override string ToString()
      {
         return "JDFResource[ --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * Status related shorthand for really lazy people Sets Status of resource as Available if bAvailable=true or as
      ///	 * Unavailable if bAvailable=false
      ///	 *  </summary>
      ///	 * <param name="bAvailable"> </param>
      ///	 * @deprecated use SetStatus(EnumResStatus) default: setAvailable(true) 
      ///	 
      [Obsolete("use SetStatus(EnumResStatus) default: setAvailable(true)")]
      public virtual void setAvailable(bool bAvailable)
      {
         setStatus(bAvailable ? EnumResStatus.Available : EnumResStatus.Unavailable);
      }

      ///   
      ///	 <summary> * Tests whether Status of resource is Available
      ///	 *  </summary>
      ///	 * <param name="bRecurseRefs"> if bRecurseRefs is set to true, also recurses into all resources linked by rRefs and returns
      ///	 *            true if the minimum Status is Status_Available
      ///	 *  </param>
      ///	 * <returns> boolean true, if Status is Available </returns>
      ///	 * @deprecated use getStatus default: IsAvailable(false) 
      ///	 
      [Obsolete("use getStatus default: IsAvailable(false)")]
      public virtual bool isAvailable(bool bRecurseRefs)
      {
         return EnumResStatus.Available.Equals(getResStatus(bRecurseRefs));
      }

      ///   
      ///	 <summary> * Tests, whether 'this' is root of partition (i.e. there is no element with the same name over 'this')
      ///	 *  </summary>
      ///	 * <returns> boolean true, if 'this' is a root </returns>
      ///	 
      public virtual bool isRootElement()
      {
         KElement parent = getParentNode_KElement();

         if (parent == null)
         {
            throw new JDFException("JDFResource.IsRootElement: resource without parent");
         }

         return !Name.Equals(parent.Name);
      }

      ///   
      ///	 <summary> * Checks, whether this resourse is a quantity resource. For quantity resource the class of 'this' must be either
      ///	 * Quantity or Consumable
      ///	 *  </summary>
      ///	 * <returns> boolean true, if 'this' is a quantity resource </returns>
      ///	 
      public virtual bool isQuantity()
      {
         EnumResourceClass c = getResourceClass();
         return c.Equals(EnumResourceClass.Quantity) || c.Equals(EnumResourceClass.Consumable);
      }

      ///   
      ///	 <summary> * Checks, whether this resourse is a parameter resource
      ///	 *  </summary>
      ///	 * <returns> boolean true, if 'this' is a parameter resource </returns>
      ///	 
      public virtual bool isParameter()
      {
         return EnumResourceClass.Parameter.Equals(getResourceClass());
      }

      ///   
      ///	 <summary> * getLock
      ///	 *  </summary>
      ///	 * <returns> boolean
      ///	 *  </returns>
      ///	 * @deprecated [BLD009] use getLocked 
      ///	 
      [Obsolete("[BLD009] use getLocked")]
      public virtual bool getLock()
      {
         return getBoolAttribute(AttributeName.LOCKED, null, false);
      }

      ///   
      ///	 <summary> * Lock
      ///	 *  </summary>
      ///	 * <param name="bLock">
      ///	 *  </param>
      ///	 * @deprecated [BLD009] use setLocked() 
      ///	 
      [Obsolete("[BLD009] use setLocked()")]
      public virtual void @lock(bool bLock)
      {
         if (bLock)
         {
            setAttribute(AttributeName.LOCKED, true, null);
         }
         else
         {
            removeAttribute(AttributeName.LOCKED, null);
         }
      }

      ///   
      ///	 <summary> * Checks, whether the resource is one of the physical resource classes
      ///	 *  </summary>
      ///	 * <returns> boolean true, if the resource is one of the physical resource classes </returns>
      ///	 
      public virtual bool isPhysical()
      {
         EnumResourceClass c = getResourceClass();

         return EnumResourceClass.Consumable.Equals(c) || EnumResourceClass.Quantity.Equals(c) || EnumResourceClass.Handling.Equals(c);
      }

      ///   
      ///	 <summary> * Gets the root resource of 'this'
      ///	 *  </summary>
      ///	 * <returns> JDFResource - the root resource element
      ///	 *  </returns>
      ///	 * <exception cref="JDFException"> if GetResourceRoot ran into the JDF node while searching </exception>
      ///	 
      public virtual JDFResource getResourceRoot()
      {
         return getResourceRoot(this);
      }

      ///   
      ///	 <summary> * Gets the root resource of 'this'
      ///	 *  </summary>
      ///	 * <param name="elem"> the element to get the root of </param>
      ///	 * <returns> JDFResource - the root resource element
      ///	 *  </returns>
      ///	 * <exception cref="JDFException"> if GetResourceRoot ran into the JDF node while searching </exception>
      ///	 
      public static JDFResource getResourceRoot(KElement elem)
      {
         KElement elemLocal = elem;

         if (elemLocal == null)
            return null;

         elemLocal = elemLocal.getDeepParent(elemLocal.LocalName, int.MaxValue);

         KElement parentNode = elemLocal.getParentNode_KElement();
         if (parentNode != null)
         {
            string parentName = parentNode.LocalName;
            if (isValidParentNodeName(parentName))
            {
               if (parentNode is JDFNodeInfo || parentNode is JDFCustomerInfo)
               {
                  KElement par = parentNode.getParentNode_KElement();
                  if (par != null && !(par is JDFNode))
                  {
                     return getResourceRoot(parentNode);
                  }
               }

               return (JDFResource)((elemLocal is JDFResource) ? elemLocal : null);
            }

            if ((parentNode is JDFNode) || (parentNode is JDFJMF))
            {
               if ((elemLocal is JDFNodeInfo) || (elemLocal is JDFCustomerInfo))
               {
                  return (JDFResource)elemLocal;
               }

               return null; // not a resource
            }

            if ((elemLocal is JDFResource) && !(parentNode is JDFResource))
               return (JDFResource)elemLocal;

            return getResourceRoot(parentNode);
         }

         if (elemLocal is JDFResource) // parentNode == null, this is a
         // standalone resource
         {
            return (JDFResource)elemLocal;
         }

         return null;
      }

      ///   
      ///	 <summary> * Gets the resourcepool that 'this' lives in
      ///	 *  </summary>
      ///	 * <returns> JDFResourcePool: the ResourcePool where 'this' lives
      ///	 *  </returns>
      ///	 * @deprecated [BLD009] use GetResourcePool instead <br> 
      ///	 
      [Obsolete("[BLD009] use GetResourcePool instead <br>")]
      public virtual JDFResourcePool getPool()
      {
         return (JDFResourcePool)getDeepParent(ElementName.RESOURCEPOOL, 0);
      }

      ///   
      ///	 <summary> * default initialization
      ///	 *  </summary>
      ///	 * <returns> boolean true, if successful
      ///	 *  </returns>
      ///	 
      public override bool init()
      {
         if (isResourceRootRoot())
         {
            appendAnchor(null);
            if (!hasAttribute(AttributeName.STATUS))
            {
               setResStatus(EnumResStatus.Unavailable, false);
            }
            EnumVersion v = getVersion(true);
            if (v == null || v.getValue() >= EnumVersion.Version_1_2.getValue() && autoAgent)
            {
               setAgentName(JDFAudit.getStaticAgentName());
               setAgentVersion(JDFAudit.getStaticAgentVersion());
            }

         }
         return true;
      }

      ///   
      ///	 <summary> * Makes from 'this' resource subelement a root resource element (direct child) of the specified parentPool or (in
      ///	 * default case) of ResourcePool, where it lives. <br>
      ///	 * 
      ///	 * The Status and SpawnStatus attribute values of the new root resource are taken from the old root resource.
      ///	 *  </summary>
      ///	 * <param name="alias"> id attribute of the newly created resource </param>
      ///	 * <param name="parentPool"> the pool where the newly created resource is stored <br>
      ///	 *            if null the local pool is used. Must use JDFElement for the pool because of recursive #defines </param>
      ///	 * <param name="bLinkHere"> if true, creates a refelement (link) to the newly created resource at the position where 'this'
      ///	 *            originally resided.
      ///	 *  </param>
      ///	 * <returns> JDFResource the moved resource
      ///	 * 
      ///	 * @default makeRootResource(null, null, true) </returns>
      ///	 
      public virtual JDFResource makeRootResource(string alias, JDFElement parentPool, bool bLinkHere)
      {
         string aliasLocal = alias;

         JDFResource retRes = this;

         // if this is already in the resource pool do nothing
         if (isResourceElement())
         {
            JDFElement link = null;

            if (bLinkHere)
            {
               // create a RefElement at the same (in front of) position as
               // this
               link = (JDFElement)getParentNode_KElement().insertBefore(Name + JDFConstants.REF, this, null);
               if (isWildCard(aliasLocal))
               {
                  aliasLocal = getIDPrefix() + uniqueID(0);
               }

               link.appendHRef(this, null, aliasLocal);
            }

            // use the local pool if no other is specified
            JDFResourcePool rp = null;
            if (parentPool is JDFResourcePool)
            {
               rp = (JDFResourcePool)parentPool;
            }
            else if (parentPool is JDFNode)
            {
               rp = ((JDFNode)parentPool).getCreateResourcePool();
            }

            if (rp == null)
            {
               rp = getResourcePool();
            }

            if (rp == null)
            {
               rp = getJDFRoot().getCreateResourcePool();
            }

            JDFResource oldRoot = getResourceRoot();
            JDFResource newRes = rp.appendResource(this);

            if (oldRoot.hasAttribute(AttributeName.STATUS))
            {
               newRes.setResStatus(oldRoot.getResStatus(false), false);
            }

            if (oldRoot.hasAttribute(AttributeName.SPAWNSTATUS))
            {
               newRes.setSpawnStatus(oldRoot.getSpawnStatus());
            }

            newRes.init();
            retRes = newRes;
         }

         return retRes;
      }

      ///   
      ///	 <summary> * Gets the creators (bCreate=true) or consumers (bCreate=false) of this resource
      ///	 *  </summary>
      ///	 * <param name="bCreate"> switcher for getter: if true gets creators, otherwise gets consumers
      ///	 *  </param>
      ///	 * <returns> VElement list of JDF nodes that create or consume this resource </returns>
      ///	 
      public virtual VElement getCreator(bool bCreate)
      {
         // if !bCreate the return value is the consumer ;-)
         VElement v = getLinksAndRefs(true, false);
         VElement vv = new VElement();
         KElement kElem = null;
         if (v == null)
         {
            return null;
         }

         for (int i = 0; i < v.Count; i++)
         {
            kElem = v[i];
            if (kElem is JDFResourceLink)
            {
               JDFResourceLink l = (JDFResourceLink)kElem;
               if (JDFResourceLink.EnumUsage.Input.Equals(l.getUsage()) != bCreate)
               {
                  JDFPool pool = l.getPool();
                  if (pool != null)
                  {
                     vv.Add(pool.getParentNode_KElement());
                  }
               }
            }
         }
         vv.unify();
         return vv.Count > 0 ? vv : null;
      }

      ///   
      ///	 <summary> * Merges partitioned resources into this resource uses PartIDKey to identify the correct resources
      ///	 *  </summary>
      ///	 * <param name="resToMerge"> the resource leaf to merge into this </param>
      ///	 * <param name="spawnID"> the spawnID of the spawning that will now be merged </param>
      ///	 * <param name="amountPolicy"> how to clean up the Resource amounts after merging </param>
      ///	 * <param name="bLocalResource"> must be true for the local resources in a spawned node and its subnodes, which default to
      ///	 *            RW
      ///	 *  </param>
      ///	 * <exception cref="JDFException"> if here is an attempt to merge incompatible resources </exception>
      ///	 * <exception cref="JDFException"> if here is an attempt to merge incompatible partitions </exception>
      ///	 * @deprecated used only by merge - moved there
      ///	 * @default mergePartition (resToMerge, spawnID, EnumAmountMerge.None, false); 
      ///	 
      [Obsolete("used only by merge - moved there")]
      public virtual void mergePartition(JDFResource resToMerge, string spawnID, EnumAmountMerge amountPolicy, bool bLocalResource)
      {
         JDFMerge.mergePartition(this, resToMerge, spawnID, amountPolicy, bLocalResource);
      }

      ///   
      ///	 <summary> * set the partIDKeys attribute of the root of this
      ///	 *  </summary>
      ///	 * <param name="partIDKeys"> the value to set key to </param>
      ///	 
      public virtual void setPartIDKeys(VString partIDKeys)
      {
         getResourceRoot().setAttribute(AttributeName.PARTIDKEYS, StringUtil.setvString(partIDKeys, JDFConstants.BLANK, null, null));
      }

      ///   
      ///	 <summary> * Clone the resource element oldRes and merge it with this resource
      ///	 *  </summary>
      ///	 * <param name="oldRes"> the resource element to clone and to merge with this resource
      ///	 *  </param>
      ///	 * <returns> JDFResource merged resource </returns>
      ///	 
      public virtual JDFResource mergeCloneResource(JDFResource oldRes)
      {
         JDFAttributeMap m = getAttributeMap(); // get all preset
         // attributes
         mergeElement(oldRes, false); // clone oldRes onto this
         setAttributes(m); // reset all preset attributes

         return this;
      }

      ///   
      ///	 <summary> * Gets all elements with name linkName, which contain resource links that point to this resource
      ///	 *  </summary>
      ///	 * <param name="linkName"> defaults to any
      ///	 *  </param>
      ///	 * <returns> VElement vector of all found elements
      ///	 * 
      ///	 * @default getLinks(null) </returns>
      ///	 * @deprecated [BLD009] use getLinks(linkName, null) 
      ///	 
      [Obsolete("[BLD009] use getLinks(linkName, null)")]
      public virtual VElement getLinks(string linkName)
      {
         return getLinks(linkName, null);
      }

      ///   
      ///	 <summary> * Gets all elements with name linkName, which contain id/idrefs that point to this resource
      ///	 *  </summary>
      ///	 * <param name="linkName"> defaults to any </param>
      ///	 * <param name="nameSpaceURI"> attribute namespace you are searching in
      ///	 *  </param>
      ///	 * <returns> VElement - vector of all found elements
      ///	 * 
      ///	 * @default getLinks(null, null) </returns>
      ///	 
      public virtual VElement getLinks(string linkName, string nameSpaceURI)
      {
         JDFAttributeMap m = new JDFAttributeMap(AttributeName.RREF, getID());
         return getParentJDF().getChildrenByTagName(linkName, nameSpaceURI, m, false, false, 0);
      }

      ///   
      ///	 <summary> * Gets all resourcelinks and refelements that link to this
      ///	 *  </summary>
      ///	 * <returns> VElement - vector of all found elements, null if none found </returns>
      ///	 * @deprecated use getLinksAndRefs(true,true); 
      ///	 
      [Obsolete("use getLinksAndRefs(true,true);")]
      public virtual VElement getLinksAndRefs()
      {
         return getLinksAndRefs(true, true);
      }

      ///   
      ///	 <summary> * Gets all resourcelinks and refelements that link to this
      ///	 *  </summary>
      ///	 * <returns> VElement - vector of all found elements, null if none found </returns>
      ///	 
      public virtual VElement getLinksAndRefs(bool bLink, bool bRef)
      {
         if (!bLink && !bRef)
         {
            return null;
         }

         string resID = getID();

         JDFAttributeMap mID = new JDFAttributeMap(AttributeName.RREF, resID);
         VString refList = new VString();
         if (bLink)
         {
            refList.Add(getLinkString());
         }

         if (bRef)
         {
            refList.Add(getRefString());
         }

         JDFNode n = getParentJDF();
         if (n == null)
         {
            return null;
         }

         VElement vRet = null;
         if (bRef)
         {
            vRet = n.getChildrenFromList(refList, mID, false, null);
         }
         else
         {
            VElement vNodes = n.getvJDFNode(null, null, false);
            vRet = new VElement();
            int size = vNodes.Count;
            for (int i = 0; i < size; i++)
            {
               VElement vTmp = ((JDFNode)vNodes[i]).getResourceLinks(null);
               if (vTmp != null)
               {
                  int size2 = vTmp.Count;
                  for (int j = 0; j < size2; j++)
                  {
                     JDFResourceLink link = (JDFResourceLink)vTmp.item(j);
                     if (resID.Equals(link.getrRef()))
                        vRet.Add(link);
                  }
               }
            }
         }

         JDFAttributeMap mPart = getPartMap();
         if (mPart != null && mPart.Count > 0)
         {
            for (int i = vRet.Count - 1; i >= 0; i--)
            {
               KElement e = vRet[i];
               VJDFAttributeMap linkMapVector = null;
               if (e is JDFResourceLink)
               {
                  linkMapVector = ((JDFResourceLink)e).getPartMapVector();
               }
               else if (e is JDFRefElement)
               {
                  JDFAttributeMap partMap = ((JDFRefElement)e).getPartMap();
                  if (partMap != null)
                  {
                     linkMapVector = new VJDFAttributeMap();
                     linkMapVector.Add(partMap);
                  }
               }

               if (linkMapVector == null)
               {
                  continue; // the link refers to the root, thus also to this
               }

               int nZapp = 0;
               int size = linkMapVector.Count;
               for (int j = 0; j < size; j++)
               {
                  JDFAttributeMap m2 = linkMapVector[j];
                  if (!m2.overlapMap(mPart))
                  {
                     nZapp++;
                  }
               }

               if (nZapp == size) // no matching parts at all
               {
                  vRet.RemoveAt(i);
               }
            }
         }

         return vRet.Count > 0 ? vRet : null;
      }

      ///   
      ///	 <summary> * list of valid node names of potential parents for a resource
      ///	 *  </summary>
      ///	 * <param name="nodeName"> the name of the node to check against </param>
      ///	 * <returns> <seealso cref="Boolean"/> true if nodeName is the name of a valid resource parent element </returns>
      ///	 
      [MethodImpl(MethodImplOptions.Synchronized)]
      private static bool isValidParentNodeName(string nodeName)
      {
         if (validParentNodeNameSet == null)
         {
            validParentNodeNameSet = new SupportClass.HashSetSupport<string>();
            string[] nodeNames = { "ResourcePool", "PipeParams", "ResourceInfo", "ResourceCmdParams", ElementName.OCCUPATION, "DeviceInfo", "DropItemIntent", "DropItem", "ProductionIntent", "CustomerInfo", "NodeInfo", "Ancestor", "Occupation", ElementName.PHASETIME };
            for (int i = 0; i < nodeNames.Length; i++)
               validParentNodeNameSet.Add(nodeNames[i]);
         }
         return validParentNodeNameSet.Contains(nodeName);
      }

      ///   
      ///	 <summary> * list of valid node names of potential parents for a resource that impy a real resource root with class, id etc
      ///	 * list of valid node names of potential parents for a resource
      ///	 *  </summary>
      ///	 * <param name="nodeName"> the name of the node to check against </param>
      ///	 * <returns> <seealso cref="Boolean"/> true if nodeName is the name of a valid resource parent element </returns>
      ///	 
      [MethodImpl(MethodImplOptions.Synchronized)]
      private static bool isValidRootParentNodeName(string nodeName)
      {
         if (validRootParentNodeNameSet == null)
         {
            validRootParentNodeNameSet = new SupportClass.HashSetSupport<string>();
            string[] nodeNames = { "ResourcePool", "PipeParams", "ResourceInfo", "ResourceCmdParams" }; // must
            // also
            // copy
            // to
            // validParentNodeNames
            for (int i = 0; i < nodeNames.Length; i++)
               validRootParentNodeNameSet.Add(nodeNames[i]);
         }
         return validRootParentNodeNameSet.Contains(nodeName);
      }

      ///   
      ///	 <summary> * Tests, if the first ancestor with a name different from the node name is not one of
      ///	 * DropItemIntent,CustomerInfo,NodeInfo,ResourcePool,PipeParams, ResourceInfo,ResourceCmdParams. <br>
      ///	 * In other words: if this resource is a subelement, but not a resourceroot
      ///	 *  </summary>
      ///	 * <returns> boolean true, if this is a subelement but not a root </returns>
      ///	 
      public virtual bool isResourceElement()
      {
         KElement e = getDeepParentNotName(LocalName);
         if (e == null)
         {
            return false;
         }

         string par = e.LocalName;
         return !isValidRootParentNodeName(par);
      }

      ///   
      ///	 <summary> * Gets the first part that matches mAttribute
      ///	 *  </summary>
      ///	 * <param name="m"> the map of key-value partitions (where key - PartIDKey, value - its value) </param>
      ///	 * <param name="bIncomplete"> if true, also accept nodes that are are not completely specified in the partmap, <br>
      ///	 *            e.g. if partitioned by run, RunPage and only Run is specified
      ///	 *  </param>
      ///	 * <returns> JDFResource - the first matching resource leaf or node </returns>
      ///	 * @deprecated use getPartition(JDFAttributeMap m, JDFResource.EnumPartUsage partUsage)
      ///	 * @default getPartition(m, true) 
      ///	 
      [Obsolete("use getPartition(JDFAttributeMap m, JDFResource.EnumPartUsage partUsage)")]
      public virtual JDFResource getPartition(JDFAttributeMap m, bool bIncomplete)
      {
         JDFResource retRes = this;

         if (m != null && !m.IsEmpty())
         {
            retRes = getDeepPart(m, bIncomplete);
         }

         return retRes;
      }

      ///   
      ///	 <summary> * Gets the first part that matches mAttribute
      ///	 *  </summary>
      ///	 * <param name="m"> the map of key-value partitions (where key - PartIDKey, value - its value) </param>
      ///	 * <param name="partUsage"> also accept nodes that are are not completely specified in the partmap, e.g. if partitioned by
      ///	 *            run, RunPage and only Run is specified
      ///	 *  </param>
      ///	 * <returns> JDFResource: the first matching resource leaf or node
      ///	 * @default getPartition(m, null) </returns>
      ///	 
      public virtual JDFResource getPartition(JDFAttributeMap m, JDFResource.EnumPartUsage partUsage)
      {
         if (m == null || m.IsEmpty())
            return this;
         return getDeepPart(m, partUsage);
      }

      ///   
      ///	 <summary> * Gets the first part that matches key-value pair
      ///	 *  </summary>
      ///	 * <param name="key"> the PartIDKey attribute name </param>
      ///	 * <param name="value"> the string value of the partition key </param>
      ///	 * <param name="bIncomplete"> if true, also accept nodes that are are not completely specified in the partmap, e.g. if
      ///	 *            partitioned by run, RunPage and only Run is specified
      ///	 *  </param>
      ///	 * <returns> JDFResource the first matching resource leaf or node
      ///	 *  </returns>
      ///	 * @deprecated use getPartition(JDFAttributeMap m, JDFResource.EnumPartUsage partUsage)
      ///	 * @default getPartition(key, value, true) 
      ///	 
      [Obsolete("use getPartition(JDFAttributeMap m, JDFResource.EnumPartUsage partUsage)")]
      public virtual JDFResource getPartition(EnumPartIDKey key, string @value, bool bIncomplete)
      {
         JDFAttributeMap mp = new JDFAttributeMap();
         mp.put(key.ToString(), @value);

         return getPartition(mp, bIncomplete);
      }

      ///   
      ///	 <summary> * applies the partitioning of r to this. <br/>
      ///	 * 
      ///	 * Ideally called only for unpartitioned resources, but will work on consistently partitioned resources
      ///	 *  </summary>
      ///	 * <param name="the"> resource from which to clone the partitioning </param>
      ///	 * <param name="partIDKeys"> the partIDKeys to clone, if null use the existing list from r </param>
      ///	 * <exception cref="JDFException"> if this is already inconsistently partitioned </exception>
      ///	 
      public virtual void clonePartitions(JDFResource r, VString partIDKeys)
      {
         if (r == null)
            return;
         VString vParts = partIDKeys == null ? r.getPartIDKeys() : partIDKeys;
         int size = vParts == null ? 0 : vParts.Count;
         if (size == 0)
            return;
         VElement vLeaves = r.getLeaves(false); // only need the real leaves
         int leafSize = vLeaves.Count;
         for (int i = 0; i < leafSize; i++)
         {
            JDFResource leaf = (JDFResource)vLeaves[i];
            JDFAttributeMap partMap = leaf.getPartMap();
            partMap.reduceMap(vParts);
            getCreatePartition(partMap, vParts);
         }

      }

      ///   
      ///	 <summary> * Recursively adds the partition leaves defined in partMap
      ///	 *  </summary>
      ///	 * <param name="partMap"> the map of part keys </param>
      ///	 * <param name="vPartKeys"> the vector of partIDKeys strings of the resource. If empty (the default), the Resource
      ///	 *            PartIDKeys attribute is used
      ///	 *  </param>
      ///	 * <returns> JDFResource the last created partition leaf
      ///	 *  </returns>
      ///	 * <exception cref="JDFException"> if there are in the partMap not matching partitions </exception>
      ///	 * <exception cref="JDFException"> if there is an attempt to fill non-matching partIDKeys </exception>
      ///	 * <exception cref="JDFException"> if by adding of last partition key there is either non-continuous partmap or left more than
      ///	 *             one key
      ///	 * 
      ///	 * @default getCreatePartition(partMap, null) </exception>
      ///	 
      public virtual JDFResource getCreatePartition(JDFAttributeMap partMap, VString vPartKeys)
      {
         if (partMap == null)
         {
            return getResourceRoot();
         }

         JDFAttributeMap localPartMap = new JDFAttributeMap(partMap); // create
         // a
         // copy
         // because
         // it
         // might
         // get
         // modified
         bool appendEnd = true;
         VString vPartIDKeys = reorderPartKeys(vPartKeys);

         // check whether we are already ok
         int iMore = 0;
         IEnumerator<string> it = localPartMap.Keys.GetEnumerator();
         while (it.MoveNext())
         {
            string key = it.Current;
            if (!vPartIDKeys.Contains(key))
            {
               iMore++;
            }
         }
         // only heuristically add stuff if needed...
         if (iMore > 1)
         {
            vPartIDKeys = expandKeysFromNode(localPartMap, vPartIDKeys);
         }

         JDFAttributeMap thisMap = getPartMap();
         if (!JDFPart.overlapPartMap(thisMap, localPartMap))
         {
            throw new JDFException("JDFResource.GetCreatePartition: non-matching partitions");
         }

         if (thisMap != null)
         {
            VString thisKeys = thisMap.getKeys();
            int siz = (thisKeys.Count < vPartIDKeys.Count) ? thisKeys.Count : vPartIDKeys.Count;

            // remove the keys of this
            for (int i = 0; i < siz; i++)
            {
               string key = vPartIDKeys[0];
               localPartMap.Remove(key);

               vPartIDKeys.RemoveAt(0);
            }
         }

         bool allParts = true;
         bool creating = false;
         JDFResource leaf = this;
         // create all partitions
         for (int k = 0; k < vPartIDKeys.Count; k++)
         {
            string key = vPartIDKeys[k];
            EnumPartIDKey enumKey = EnumPartIDKey.getEnum(key);
            string @value = localPartMap.get(key);

            if (localPartMap.ContainsKey(key))
            {
               if (allParts)
               {
                  if (!creating)
                  {
                     JDFResource nextLeaf = leaf.getPartition(new JDFAttributeMap(key, @value), EnumPartUsage.Explicit);
                     if (nextLeaf == null)
                     {
                        creating = true;
                     }
                     else
                     {
                        leaf = nextLeaf;
                     }
                  }
                  if (creating)
                  {
                     leaf = leaf.addPartition(enumKey, @value);
                  }
                  localPartMap.Remove(key);
                  if (localPartMap.Count == 0)
                  {
                     break; // nothing left to do
                  }
               }
               else
               {
                  throw new JDFException("GetCreatePartition: Resource ID=" + getID() + " attempting to fill non-matching partIDKeys");
               }
            }
            else
            {
               allParts = false;
            }
         }

         // add last partition key
         int partSize = localPartMap.Count;
         if (appendEnd && allParts && partSize == 1) // one left and continuous,
         // can add
         {
            string key = localPartMap.getKeys()[0];
            leaf = leaf.addPartition(EnumPartIDKey.getEnum(key), localPartMap.get(key));
         }
         else if (partSize > 0) // either non - continuous or more than one left
         {
            throw new JDFException("AddPartitionMap: incompatible partmap");
         }
         return leaf;
      }

      ///   
      ///	 <summary> * reorder the partIDKeys used for generating the new partition based on existing partIDKeys
      ///	 *  </summary>
      ///	 * <param name="vPartKeys"> </param>
      ///	 * <returns> VString the reordered VString of partIDKeys </returns>
      ///	 
      private VString reorderPartKeys(VString vPartKeys)
      {
         if (vPartKeys == null || vPartKeys.IsEmpty())
         {
            return getPartIDKeys();
         }
         VString vPartIDKeys = new VString(vPartKeys);
         VString vExistingPartKeys = getPartIDKeys();
         VString vTmpPartIDKeys = new VString();
         if (vExistingPartKeys != null && !vExistingPartKeys.IsEmpty())
         {
            int n = vExistingPartKeys.Count;
            if (vPartIDKeys.Count < n)
            {
               n = vPartIDKeys.Count;
            }

            for (int i = 0; i < n; i++)
            {
               string partKey = vExistingPartKeys[i];
               if (!vPartIDKeys.Contains(partKey)) // allow reordering of the
               // existing partidkeys
               {
                  throw new JDFException("getCreatePartiton: adding incompatible partitions");
               }
               vTmpPartIDKeys.Add(partKey);
               vPartIDKeys.Remove(partKey);
            }
            for (int i = 0; i < vPartIDKeys.Count; i++)
            {
               vTmpPartIDKeys.Add(vPartIDKeys[i]);
            }
            vPartIDKeys = vTmpPartIDKeys;
         }
         return vPartIDKeys;
      }

      ///   
      ///	 <summary> * heuristic guess of the best possible partidkey sequence
      ///	 *  </summary>
      ///	 * <param name="partMap"> the partmap that we want to create </param>
      ///	 * <param name="vPartIDKeys"> the known base partidkeys </param>
      ///	 * <returns> the best guess vector of partidkeys </returns>
      ///	 
      private VString expandKeysFromNode(JDFAttributeMap partMap, VString vPartIDKeys)
      {
         JDFNode n = this.getParentJDF();
         if (n == null)
         {
            return vPartIDKeys;
         }

         VString nodeKeys = n.getPartIDKeys(partMap);
         int nodeKeySize = nodeKeys.Count;

         int partKeySize = vPartIDKeys != null ? vPartIDKeys.Count : 0;
         if (nodeKeySize <= partKeySize)
         {
            return vPartIDKeys;
         }

         if (vPartIDKeys != null)
         {
            VString.Enumerator nodeKeysIterator = nodeKeys.GetEnumerator();
            VString.Enumerator vPartIDKeysIterator = vPartIDKeys.GetEnumerator();
            while (vPartIDKeysIterator.MoveNext())
            {
               if (!vPartIDKeysIterator.Current.Equals(nodeKeysIterator.Current))
               {
                  return vPartIDKeys; // nodekeys and partkeys are
                  // incompatible, return the input
               }
            }
         }

         // all beginning elements are equal but we have more - use these as a
         // best guess
         return nodeKeys;
      }

      ///   
      ///	 <summary> * Gets the first part that matches key-value if it does not exist, create it
      ///	 *  </summary>
      ///	 * <param name="key"> the PartIDKey attribute name </param>
      ///	 * <param name="value"> the string value of the partition key </param>
      ///	 * <param name="vPartIDKeys"> the vector of partIDKeys strings of the resource.
      ///	 *  </param>
      ///	 * <returns> JDFResource the matching resource
      ///	 * 
      ///	 * @default getCreatePartition(key, value, null) </returns>
      ///	 
      public virtual JDFResource getCreatePartition(EnumPartIDKey key, string @value, VString vPartIDKeys)
      {
         JDFAttributeMap mp = new JDFAttributeMap(key.getName(), @value);
         return getCreatePartition(mp, vPartIDKeys);
      }

      ///   
      ///	 <summary> * version fixing routine
      ///	 * 
      ///	 * uses heuristics to modify this element and its children to be compatible with a given version in general, it will
      ///	 * be able to move from low to high versions but potentially fail when attempting to move from higher to lower
      ///	 * versions
      ///	 *  </summary>
      ///	 * <param name="version"> version that the resulting element should correspond to </param>
      ///	 * <returns> true if successful </returns>
      ///	 
      public override bool fixVersion(EnumVersion version)
      {
         bool bRet = true;
         if (!isResourceRootRoot())
         {
            // removeAttribute(AttributeName.STATUS);
            if (!isResourceElement())
            {
               removeAttribute(AttributeName.CLASS);
            }
         }
         else
         {
            if (hasAttribute(AttributeName.RREFS))
            {
               removeAttribute(AttributeName.RREFS);
            }

            init();
         }
         if (version != null)
         {
            if (!isResourceRootRoot())
            {
               if (version.getValue() >= EnumVersion.Version_1_2.getValue())
               {
                  removeAttribute(AttributeName.ID);
               }
            }
            else
            {
               if (version.getValue() <= EnumVersion.Version_1_2.getValue())
               {
                  if (getPartUsage() == EnumPartUsage.Sparse)
                  {
                     setPartUsage(EnumPartUsage.Implicit);
                  }
               }
            }
         }
         return base.fixVersion(version) && bRet;
      }

      ///   
      ///	 <summary> * Tests, if this leaf has a consistent PartIDKey as specified by key
      ///	 *  </summary>
      ///	 * <param name="key"> the PartIDKey attribute name </param>
      ///	 * <param name="root"> </param>
      ///	 * <param name="partIDKeys">
      ///	 *  </param>
      ///	 * <returns> boolean true, if key exists in this leaf is in PartIDKeys </returns>
      ///	 
      protected internal virtual bool consistentPartIDKeys(EnumPartIDKey key, JDFResource root, VString partIDKeys)
      {
         if (key == null)
         {
            return false;
         }
         List<ValuedEnum> vImplicitKeys = getImplicitPartitions();
         if (vImplicitKeys != null)
         {
            if (vImplicitKeys.Contains(key))
            {
               return false;
            }
         }

         string keyName = key.getName();
         int nDepth = 0;
         JDFResource r = this;
         // the key exists but is not in PartIDKeys, oops
         int index = partIDKeys.IndexOf(keyName);
         if (index < 0)
         {
            return !hasAttribute(keyName, null, false);
         }

         while (!r.Equals(root))
         {
            nDepth++;
            r = (JDFResource)r.ParentNode;
            if (r == null)
            {
               break;
            }
         }
         if (partIDKeys.Count < nDepth)
         {
            return false;
         }

         KElement e = this;
         // loop down to the resource root, checking whether exactly those
         // attributes required exist
         for (int i = nDepth - 1; i >= -1; i--)
         {
            if ((i == index) && !e.hasAttribute_KElement(keyName, null, false))
            {
               return false;
            }
            if ((i != index) && e.hasAttribute_KElement(keyName, null, false))
            {
               return false;
            }
            if (i > -1)
            {
               e = e.getParentNode_KElement();
            }
         }
         // all is well

         return true;
      }

      ///   
      ///	 <summary> * Tests, if this leaf has a consistent PartIDKey as specified by key
      ///	 *  </summary>
      ///	 * <param name="key"> the PartIDKey attribute name </param>
      ///	 * <returns> boolean true, if key exists in this leaf is in PartIDKeys </returns>
      ///	 
      public virtual bool consistentPartIDKeys(EnumPartIDKey key)
      {
         JDFResource root = getResourceRoot();
         return consistentPartIDKeys(key, root, root.getPartIDKeys());
      }


      private void removeImplicitPartions(JDFAttributeMap m)
      {
         if (m == null)
         {
            return;
         }
         List<ValuedEnum> v = getImplicitPartitions();
         if (v == null)
         {
            return;
         }
         for (int i = 0; i < v.Count; i++)
         {
            m.Remove(((EnumPartIDKey)v[i]).getName());
         }
      }



      protected internal virtual VElement getDeepPartVector(JDFAttributeMap m_in, EnumPartUsage partUsage, int matchingDepth, VString partIDKeys)
      {
         EnumPartUsage partUsageLocal = partUsage;
         int matchingDepthLocal = matchingDepth;

         JDFAttributeMap m = new JDFAttributeMap(m_in);
         VElement vReturn = new VElement();
         removeImplicitPartions(m);
         if (partUsageLocal == null)
         {
            partUsageLocal = getPartUsage();
         }

         if (m.IsEmpty())
         {
            vReturn.Add(this);
            return vReturn;
         }

         int msiz = m.Count;
         if (matchingDepthLocal == -1) // first call - check validity of the map
         {
            matchingDepthLocal = 0;
            JDFAttributeMap thisMap = getPartMap(partIDKeys);

            IEnumerator<string> it = m.Keys.GetEnumerator();
            while (it.MoveNext()) // for(int i = 0; i < msiz; i++)
            {
               string strKey = it.Current;
               EnumPartIDKey partIDKey = EnumPartIDKey.getEnum(strKey);

               // check map and throw exception if bad
               if (partIDKey == null)
               {
                  throw new JDFException("GetPartIDKeyEnum: illegal key:" + strKey);
               }

               // check whether we are already in a leaf when initially calling
               string mMapValue = m.get(strKey);
               if (thisMap != null)
               {
                  string thisMapValue = thisMap.get(strKey);

                  if (thisMapValue != null && JDFPart.matchesPart(strKey, thisMapValue, mMapValue))
                  {
                     matchingDepthLocal++;
                  }
               }
            }

            // check if we are incompatible from the start...
            if (!JDFPart.overlapPartMap(thisMap, m))
            {
               return vReturn;
            }
         }

         // if we find an <Identical> element, we must clean up the map and merge
         // in the values of
         // identical can only be in a leaf
         KElement identical = getElement_KElement(ElementName.IDENTICAL, null, 0);
         if (identical != null)
         {
            JDFPart part = (JDFPart)identical.getElement(ElementName.PART);
            if (part != null)
            {
               JDFAttributeMap identityMap = part.getPartMap();
               m.putAll(identityMap);
            }

            // the identity map is always complete from the root, we therefore
            // can start searching
            // in the root
            return getResourceRoot().getDeepPartVector(m, partUsageLocal, -1, partIDKeys);
         }

         if (msiz == matchingDepthLocal)
         {
            vReturn.Add(this);
            return vReturn;
         }

         string nodeName = Name;
         // TODO cast not safe!
         JDFResource resourceElement = (JDFResource)getElement_KElement(nodeName, null, 0);

         if (resourceElement == null) // got a leaf or found no matching children
         {
            // 150802 RP removed different treatment for leaves and no matching
            // elements
            if (partUsageLocal.getValue() >= EnumPartUsage.Sparse.getValue()) // allow
            // incomplete
            // parts
            {
               vReturn.Add(this);
            }

            return vReturn;
         }

         VElement toAppend = new VElement(); // we stick all recursively found
         // candidates into this vector
         bool hasBadChildren = false; // loop over all valid elements and
         // search downward
         bool hasMatchingAttribute = false;
         bool bSearchSame = true; // boolean that controls whether to search
         // the lower children.
         bool bCompleteMatch = false;
         string matchingKey = null;
         string matchingValue = null;
         int nChildren = 0;
         int matchingKeyPos = -1;

         while (true)
         {
            bool badChild = false;
            bool bSnafu = false;

            if (matchingKeyPos >= 0) // all other elements except the first
            // may have a predefined matching key
            {
               string sTmp = resourceElement.getAttribute_KElement(matchingKey, null, null);
               if (sTmp != null) // found a matching key;
               {
                  if (sTmp.Equals(matchingValue))
                  {
                     hasMatchingAttribute = true;
                  }
                  else
                  {
                     badChild = true;
                     hasBadChildren = true;
                  }
               }
               else
               {
                  bSnafu = true; // should never get here, but in case of a
                  // corrupt leaf structure,
                  // it could happen and will be handled gracefully
               }
            }

            if ((nChildren++ == 0) || bSnafu) // must only search the first
            // element, since only one key
            { // is allowed and all keys must be in the same sequence;
               // unless, of course, someone wrote crap JDF (bSnafu=true)
               IEnumerator<string> it = m.Keys.GetEnumerator();
               int im = 0;
               while (it.MoveNext()) // for(int im = 0; im < msiz; im++)
               {
                  string strKey = it.Current;
                  string strValue = m.get(strKey);

                  string sTmp = resourceElement.getAttribute_KElement(strKey, null, null);

                  if (sTmp != null) // found a matching key;
                  {
                     if (JDFPart.matchesPart(strKey, sTmp, strValue))
                     {
                        hasMatchingAttribute = true;
                     }
                     else
                     {
                        badChild = true;
                        hasBadChildren = true;
                     }

                     matchingKeyPos = im;
                     matchingKey = strKey;
                     matchingValue = strValue;
                     break;
                  }
                  im++;
               }
            }

            if (!badChild)
            {
               VElement dpv = resourceElement.getDeepPartVector(m, partUsageLocal, hasMatchingAttribute ? matchingDepthLocal + 1 : matchingDepthLocal, partIDKeys);

               if (dpv.Count > 0)
               {
                  toAppend.addAll(dpv);
                  bSearchSame = false; // not necessary since we have
                  // something deeper

                  if (hasMatchingAttribute && toAppend.Count == 1) // this is
                  // a
                  // potential
                  // complete
                  // match
                  // - we may just stop
                  {
                     JDFResource root = getResourceRoot();
                     JDFElement closest = (JDFElement)toAppend[0];
                     // move to root
                     int leafDepth = 0;

                     while (!closest.Equals(root))
                     {
                        leafDepth++;
                        closest = (JDFElement)closest.ParentNode;
                     }

                     bCompleteMatch = (leafDepth == msiz);
                  }
               }
            }
            if (bCompleteMatch)
            {
               break; // nothing at all left to do; jump out of loop
            }

            KElement k = resourceElement.getNextSiblingElement(nodeName, null);

            if (!(k is JDFResource))
            {
               break;
            }

            resourceElement = (JDFResource)k;
         }

         // nothing complete was found, and we are at the end of the chain
         if (bSearchSame)
         {
            // check whether all sub elements of this are accepted completely
            int appSize = toAppend.Count;
            bool bSame = (!hasMatchingAttribute) && (nChildren == appSize);

            if (bSame)
            {
               // TODO cast not safe
               resourceElement = (JDFResource)getElement_KElement(nodeName, null, 0);

               for (int n = 0; n < appSize; n++)
               {
                  if (!resourceElement.Equals(toAppend[n]))
                  {
                     bSame = false;
                     break;
                  }

                  KElement k = resourceElement.getNextSiblingElement(nodeName, null);
                  if (!(k is JDFResource))
                  {
                     break;
                  }
                  resourceElement = (JDFResource)k;
               }
            }

            if (!bSame) // something in the children warrants a closer look and
            // we are at the end
            {
               // none match and this is the last with bad kids and we want
               // incomplete stuff
               if (toAppend.IsEmpty() && hasBadChildren && (partUsageLocal.Equals(EnumPartUsage.Implicit)) && !hasMatchingAttribute)
               {
                  JDFResource root = getResourceRoot();
                  JDFResource closest = this;
                  bool bClosest = false;

                  // move to root
                  while (!closest.Equals(root))
                  {
                     // used for an explicit (non inherited) attribute check.
                     JDFElement closestElement = closest;

                     // check whether any parameters of map were found
                     IEnumerator<string> it = m.Keys.GetEnumerator();
                     while (it.MoveNext()) // for(int i = 0; i < msiz; i++)
                     {
                        string strKey = it.Current;
                        if (closestElement.hasAttribute_KElement(strKey, null, false))
                        {
                           bClosest = true;
                           break;
                        }
                     }

                     // found one that has at least one attribute from m -->
                     // stop searching
                     if (bClosest)
                     {
                        break;
                     }

                     // this one is no closer than it's parent --> take the
                     // parent and retry
                     closest = (JDFResource)closest.ParentNode;
                  }
                  vReturn.Add(closest);
               }
               else
               // this is the standard recursive case with no special handling
               {
                  vReturn.addAll(toAppend);
               }
            }
            else
            {
               // if all subelements were accepted, I am the correct root
               // note that this may recurse up closer to the root
               vReturn.Add(this);
            }
         }
         else
         // this is the standard recursive case with no special handling
         {
            vReturn.addAll(toAppend);
         }

         return vReturn;
      }

      ///   
      ///	 <summary> * Gets a matching part from somewhere down there returns the closest ancestor of all matching elements within the
      ///	 * target vector
      ///	 *  </summary>
      ///	 * <param name="m"> </param>
      ///	 * <param name="bIncomplete"> </param>
      ///	 * <returns> JDFResource </returns>
      ///	 * @deprecated use the partUsage dependent version instead 
      ///	 
      [Obsolete("use the partUsage dependent version instead")]
      public virtual JDFResource getDeepPart(JDFAttributeMap m, bool bIncomplete)
      {
         return getDeepPart(m, bIncomplete ? EnumPartUsage.Implicit : EnumPartUsage.Explicit);
      }

      ///   
      ///	 <summary> * Gets a matching part from somewhere down there,<br>
      ///	 * returns the closest ancestor of all matching elements within the target vector
      ///	 *  </summary>
      ///	 * <param name="m"> map of attributes that should fit </param>
      ///	 * <param name="partUsage"> lso accept nodes that are are not completely specified in the partmap, e.g. if partitioned by
      ///	 *            run, RunPage and only Run is specified </param>
      ///	 * <returns> the first found matching resource node or leaf </returns>
      ///	 
      public virtual JDFResource getDeepPart(JDFAttributeMap m, EnumPartUsage partUsage)
      {
         JDFResource retRes = null;
         VString partIDKeys = getPartIDKeys();
         VElement vRes = getDeepPartVector(m, partUsage, -1, partIDKeys);

         if (vRes != null)
         {
            int siz = vRes.Count;

            if (siz == 0)
            {
               // nothing fits at all
               return retRes;
            }
            else if (siz == 1)
            { // only one, take it
               retRes = (JDFResource)vRes[0];
            }
            else
            { // multiple, get the closest ancestor
               JDFResource e = (JDFResource)vRes[0];
               if (e.isResourceRoot())
               {
                  return e;
               }

               e = (JDFResource)e.ParentNode;
               do // if more than one, loop at leas once
               {
                  int i = 0;
                  for (i = siz - 1; i > 0; i--) // e is always an ancestor of
                  // vElm[i];
                  // go backwards since the chance of mismatch is
                  // greater at the end of the list
                  {
                     if (!e.isAncestor(vRes[i])) // found a
                     // misMatch
                     {
                        e = (JDFResource)e.ParentNode;
                        break;
                     }
                  }
                  if (i == 0) // went through the entire loop with no mismatch
                  // --> heureka and ciao
                  {
                     retRes = e;
                     break; // while e!=this
                  }
               }
               while (e != this);

               if (e.isResourceRoot())
               {
                  return e; // the root is always ok
               }
            }
         }

         if (retRes == null)
         {
            return null;
         }

         int retSize = -1;
         JDFResource loopRes = retRes;
         ICollection<string> vKeys = m.Keys;

         // loop unti we hit this or root, whichever is closer
         while (true)
         {
            JDFAttributeMap returnMap = loopRes.getPartMap();
            // only check the keys, not the values since <Identical> elements
            // may screw up the values...
            returnMap.reduceMap(vKeys);
            // we lost a key - break one prior to this
            if (returnMap.Count < retSize)
            {
               return retRes; // the child of the tested element
            }
            else if (retSize == -1)
            { // first loop initialization
               retSize = returnMap.Count;
            }
            // we hit the starting point - nothing left to do
            if ((loopRes == this) || loopRes.isResourceRoot())
            {
               return loopRes;
            }
            // no check failed - go one closer to the root
            retRes = loopRes;
            loopRes = (JDFResource)loopRes.ParentNode;
            if (loopRes == null)
            {
               throw (new JDFException("JDFResource::GetDeepPart ran into null element while searching tree"));
            }
         }
         // return retRes;
      }

      ///   
      ///	 <summary> * Gets a list of all direct leaves
      ///	 *  </summary>
      ///	 * <param name="bAll"> if true include all intermediate and leaf nodes including this<br>
      ///	 *            if false, include only the final leaves
      ///	 *  </param>
      ///	 * <returns> VElement - the vector of all leaves
      ///	 * 
      ///	 * @default getLeaves(false) </returns>
      ///	 
      public virtual VElement getLeaves(bool bAll)
      {
         // want possibly intermediate nodes, check the kids
         VElement vAllChildren = getChildElementVector_KElement(Name, null, null, true, 0);

         if (vAllChildren.IsEmpty())
         {
            // got a leaf
            vAllChildren.Add(this);
         }
         else
         {
            VElement vLeaves = new VElement();
            // recurse parts tree and sum up the results
            if (bAll)
            {
               vLeaves.Add(this);
            }

            int size = vAllChildren.Count;
            for (int i = 0; i < size; i++)
            {
               JDFResource pi = (JDFResource)vAllChildren[i];
               VElement v = pi.getLeaves(bAll);
               vLeaves.addAll(v);
            }

            vAllChildren = vLeaves;
         }

         return vAllChildren;
      }

      ///   
      ///	 <summary> * Tests, whether 'this' is the end of a partition (i.e. there is no element with the same name directly below)
      ///	 *  </summary>
      ///	 * <returns> boolean true, if 'this' is a leaf </returns>
      ///	 
      public virtual bool isLeaf()
      {
         return getElement_JDFElement(Name, null, 0) == null;
      }

      ///   
      ///	 <summary> * Gets a list of the values for attribute part type within the leaves
      ///	 *  </summary>
      ///	 * <param name="partType"> the PartIDKey attribute name
      ///	 *  </param>
      ///	 * <returns> Vector - a list of values of the specifird partition key </returns>
      ///	 
      public virtual VString getPartValues(EnumPartIDKey partType)
      {
         VElement v = getLeaves(false);
         VString vs = new VString();

         for (int i = 0; i < v.Count; i++)
         {
            JDFResource p = (JDFResource)v[i];
            string s = p.getAttribute(partType.getName(), null, JDFConstants.EMPTYSTRING);

            if (s != null && !s.Equals(JDFConstants.EMPTYSTRING))
            {
               bool bOK = true;
               for (int j = 0; j < vs.Count && bOK; j++)
               {
                  if (s.Equals(vs[j]))
                  {
                     bOK = false;
                  }
               }

               if (bOK)
               {
                  vs.Add(s);
               }
            }
         }

         return vs;
      }

      ///   
      ///	 <summary> * Gets an attribute value. Also follows partition parents to the resource root
      ///	 *  </summary>
      ///	 * <param name="attrib"> attribute name to get </param>
      ///	 * <param name="nameSpaceURI"> namespace to search for </param>
      ///	 * <param name="def"> attribute default that is returned if no attribute exists
      ///	 *  </param>
      ///	 * <returns> WString - attribute value
      ///	 * 
      ///	 * @default getAttribute(attrib, null, JDFConstants.EMPTYSTRING) </returns>
      ///	 
      public override string getAttribute(string attrib, string nameSpaceURI, string def)
      {
         string resultAttrib = base.getAttribute(attrib, nameSpaceURI, null);
         string nodeName = resultAttrib == null ? Name : null;
         KElement ke = this;
         while (resultAttrib == null)
         {
            ke = ke.getParentNode_KElement();
            if (ke == null || !ke.Name.Equals(nodeName))
            {
               return def;
            }
            resultAttrib = ke.getAttribute_KElement(attrib, nameSpaceURI, null);
         }

         return resultAttrib;
      }

      ///   
      ///	 <summary> * Get the Attribute Map of the actual element also following inheritence
      ///	 *  </summary>
      ///	 * <returns> JDFAttributeMap the attribute map of the actual element </returns>
      ///	 
      public override JDFAttributeMap getAttributeMap()
      {
         KElement ke = getParentNode_KElement();
         JDFAttributeMap ret = null;
         if (ke != null && ke.Name.Equals(Name))
         {
            ret = ((JDFResource)ke).getAttributeMap();
            ret.putAll(base.getAttributeMap());
         }
         else
         {
            ret = base.getAttributeMap();
         }
         return ret;
      }

      ///   
      ///	 <summary> * Checks if the actual element has a specific attribute<br>
      ///	 * this version checks within the resource and its partitioned parent xml elements
      ///	 *  </summary>
      ///	 * <param name="attrib"> the name of the attribute to look for </param>
      ///	 * <param name="nameSpaceURI"> the nameSpace to look in </param>
      ///	 * <param name="bInherit"> if true also check recursively in parent elements, regardless of partitioning
      ///	 *  </param>
      ///	 * <returns> boolean true, if the attribute is present
      ///	 * 
      ///	 * @default hasAttribute(attrib, null, false) </returns>
      ///	 
      public override bool hasAttribute(string attrib, string nameSpaceURI, bool bInherit)
      {
         return hasAttribute_JDFResource(attrib, nameSpaceURI, bInherit);
      }

      ///   
      ///	 <summary> * Checks if the actual element has a specific attribute<br>
      ///	 * this version checks within the resource and its partitioned parent xml elements this was added in order to
      ///	 * implement the c++ JDFResource::HasAttribute
      ///	 *  </summary>
      ///	 * <param name="attrib"> the name of the attribute to look for </param>
      ///	 * <param name="nameSpaceURI"> the nameSpace to look in </param>
      ///	 * <param name="bInherit"> if true also check recursively in parent elements, regardless of partitioning
      ///	 *  </param>
      ///	 * <returns> boolean true, if the attribute is present
      ///	 * 
      ///	 * @default hasAttribute_JDFResource(attrib, null, false) </returns>
      ///	 
      private bool hasAttribute_JDFResource(string attrib, string nameSpaceURI, bool bInherit)
      {
         if (bInherit)
         {
            return getInheritedAttribute(attrib, nameSpaceURI, null) != null;
         }
         return getAttribute(attrib, nameSpaceURI, null) != null;
      }

      ///   
      ///	 <summary> * The same as JDFElement.numChildElements but also follows References
      ///	 *  </summary>
      ///	 * <param name="nodeName"> the nodes to count </param>
      ///	 * <param name="nameSpaceURI"> the nameSpace to look in </param>
      ///	 * <returns> int - the number of child elements
      ///	 * 
      ///	 * @default numChildElements(JDFConstants.EMPTYSTRING, null) </returns>
      ///	 
      public override int numChildElements(string nodeName, string nameSpaceURI)
      {
         int iNumChildElements = base.numChildElements(nodeName, nameSpaceURI);

         // elements do not override, i.e. if an element from a group exists, do
         // not look below
         if (iNumChildElements == 0)
         {
            JDFElement jdfRes = (JDFElement)getParentNode_KElement();

            if (jdfRes == null || !jdfRes.Name.Equals(Name))
            {
               iNumChildElements = 0;
            }
            else
            {
               if (jdfRes is JDFResource)
               {
                  iNumChildElements = ((JDFResource)jdfRes).numChildElements(nodeName, nameSpaceURI);
               }
            }
         }

         return iNumChildElements;
      }

      ///   
      ///	 <summary> * Recursive GetElement that also checks parent nodes up to the part root this was added in order to implement the
      ///	 * c++ JDFResource::GetCreateElement
      ///	 *  </summary>
      ///	 * <param name="nodeName"> name of the child node to get </param>
      ///	 * <param name="nameSpaceURI"> namespace to search for </param>
      ///	 * <param name="iSkip"> get the iSkipth element that fits
      ///	 *  </param>
      ///	 * <returns> KElement - the matching element
      ///	 * 
      ///	 * @default getCreateElement_JDFResource(nodeName, null, 0) </returns>
      ///	 
      public virtual KElement getCreateElement_JDFResource(string nodeName, string nameSpaceURI, int iSkip)
      {
         KElement resultKElement = getElement_JDFElement(nodeName, nameSpaceURI, iSkip);

         if (resultKElement == null)
         {
            // 250202 RP changed functionality to append in case the leaf
            // does not have it brand new for partitions!
            resultKElement = appendElement(nodeName, nameSpaceURI);
         }

         return resultKElement;
      }

      ///   
      ///	 <summary> * same as KElement.getElement, but also follows references and searches parents
      ///	 *  </summary>
      ///	 * <param name="nodeName"> name of the child node to get </param>
      ///	 * <param name="nameSpaceURI"> namespace to search for </param>
      ///	 * <param name="iSkip"> get the iSkipth element that fits
      ///	 *  </param>
      ///	 * <returns> KElement: the matching element
      ///	 * 
      ///	 *         default: getElement(nodeName, null, 0) </returns>
      ///	 
      public override KElement getElement(string nodeName, string nameSpaceURI, int iSkip)
      {
         return getElement_JDFResource(nodeName, nameSpaceURI, iSkip);
      }

      ///   
      ///	 <summary> * same as KElement.getElement, but also follows references and searches parents<br>
      ///	 * this was added in order to implement the C++ JDFResource::GetElement
      ///	 *  </summary>
      ///	 * <param name="nodeName"> name of the child node to get </param>
      ///	 * <param name="nameSpaceURI"> namespace to search for </param>
      ///	 * <param name="iSkip"> get the iSkipth element that fits
      ///	 *  </param>
      ///	 * <returns> KElement - the matching element
      ///	 * 
      ///	 * @default getElement_JDFResource(nodeName, null, 0) </returns>
      ///	 
      private KElement getElement_JDFResource(string nodeName, string nameSpaceURI, int iSkip)
      {
         KElement retEle = null;

         if (base.getElement(nodeName, nameSpaceURI, 0) != null)
         {
            retEle = base.getElement(nodeName, nameSpaceURI, iSkip);
         }
         else
         {
            KElement parent = getParentNode_KElement();
            if (parent != null && parent.Name.Equals(Name))
            {
               if (!(parent is JDFResource))
               {
                  throw new JDFException("getElement_JDFResource tried to" + " return a JDFElement as a JDFResource");
               }

               retEle = ((JDFResource)parent).getElement_JDFResource(nodeName, nameSpaceURI, iSkip);
            }
         }
         return retEle;
      }

      ///   
      ///	 <summary> * Creates parts of part type 'partType' with values as defined in 'values'; the number of values is defined by the
      ///	 * number of elements in 'values'
      ///	 *  </summary>
      ///	 * <param name="partType"> part type of a new part </param>
      ///	 * <param name="values"> its value
      ///	 *  </param>
      ///	 * <returns> VElement - vector of newly created parts </returns>
      ///	 
      public virtual VElement addPartitions(EnumPartIDKey partType, VString values)
      {
         if (isResourceElement())
         {
            throw new JDFException("Attempting to add partition to resource element: " + buildXPath(null, 1));
         }

         VElement v = new VElement();
         if (!hasAttribute(partType.getName(), null, false))
         {
            VElement vLeaves = getLeaves(false);

            int size = values.Count;
            for (int i = 0; i < vLeaves.Count; i++)
            {
               for (int j = 0; j < size; j++)
               {
                  JDFResource p = (JDFResource)vLeaves[i];
                  v.Add(p.addPartition(partType, values.stringAt(j)));
               }
            }
         }

         return v;
      }

      ///   
      ///	 <summary> * Adds a new part to this node, also handles PartIDKeys in the root etc. convenience method to allow for partIDKey
      ///	 * enums rather than strings
      ///	 *  </summary>
      ///	 * <param name="partType"> part type of a new part </param>
      ///	 * <param name="value"> its value
      ///	 *  </param>
      ///	 * <returns> JDFResource - the newly created part </returns>
      ///	 
      public virtual JDFResource addPartition(EnumPartIDKey partType, ValuedEnum enumPart)
      {
         return addPartition(partType, enumPart.getName());
      }

      ///   
      ///	 <summary> * Adds a new part to this node, also handles PartIDKeys in the root etc.
      ///	 *  </summary>
      ///	 * <param name="partType"> part type of a new part </param>
      ///	 * <param name="value"> its value
      ///	 *  </param>
      ///	 * <returns> JDFResource - the newly created part </returns>
      ///	 
      public virtual JDFResource addPartition(EnumPartIDKey partType, string @value)
      {
         if (isResourceElement())
         {
            throw new JDFException("Attempting to add partition to resource element: " + buildXPath(null, 1));
         }
         if (partType == null)
         {
            throw new JDFException("Attempting to add null partition to resource: " + buildXPath(null, 1));
         }

         VString vs = getPartIDKeys();
         int posOfType = vs == null ? -1 : vs.IndexOf(partType.getName());
         if (posOfType < 0)
         {
            if (!isLeaf())
            {
               throw new JDFException("addPartion: adding inconsistent partition - parent must be a leaf");
            }
         }
         else if (posOfType == 0)
         {
            if (!isResourceRootRoot())
            {
               throw new JDFException("addPartion: adding inconsistent partition - must be root");
            }
         }
         else
         {
            if (vs != null)
            {
               string parentPart = vs.stringAt(posOfType - 1);
               if (!hasAttribute_KElement(parentPart, null, false))
               {
                  throw new JDFException("addPartion: adding inconsistent partition - parent must have partIDKey: " + parentPart);
               }
            }
         }

         if (!hasAttribute(partType.getName(), null, false))
         {
            addPartIDKey(partType);
         }

         JDFResource p = getPartition(new JDFAttributeMap(partType, @value), EnumPartUsage.Explicit);
         if (p != null)
         {
            throw new JDFException("addPartion: adding duplicate partition " + partType + "=" + @value);
         }

         p = (JDFResource)appendElement(Name, getNamespaceURI());
         if (p != null)
         {
            p.setPartIDKey(partType, @value);
         }

         return p;
      }

      ///   
      ///	 <summary> * Gets all local attribute names as an vector of strings.<br>
      ///	 * Is called from KElement.getMissingAttributeVector() as a virtual method
      ///	 *  </summary>
      ///	 * <returns> VString - the vector of attribute names </returns>
      ///	 
      public override VString getAttributeVector()
      {
         return getAttributeVector_JDFResource();
      }

      ///   
      ///	 <summary> * Gets all local attribute names as an vector of strings
      ///	 *  </summary>
      ///	 * <returns> VString the vector of attribute names </returns>
      ///	 
      public virtual VString getAttributeVector_JDFResource()
      {
         VString v = new VString();
         KElement parent = getParentNode_KElement();

         v = base.getAttributeVector();
         if ((parent != null) && parent.Name.Equals(Name))
         {
            VString par = ((JDFResource)parent).getAttributeVector_JDFResource();
            for (int i = 0; i < par.Count; i++)
            {
               string att = par[i];
               if (!v.Contains(att))
               {
                  v.Add(att);
               }
            }
         }
         return v;
      }

      ///   
      ///	 <summary> * Gets the parent element that actually contains the attribute key in a partitioned resource
      ///	 *  </summary>
      ///	 * <param name="key"> attribute key to look for </param>
      ///	 * <returns> JDFResource - the parent element that actually contains the attribute key </returns>
      ///	 
      public virtual JDFResource getAttributePart(string key)
      {
         JDFResource result = null;

         if (base.hasAttribute(key, null, false))
         {
            result = this;
         }
         else
         {
            JDFElement jdfRes = (JDFElement)getParentNode_KElement();
            if (jdfRes != null && jdfRes.Name.Equals(Name))
            {
               if (!(jdfRes is JDFResource))
               {
                  throw new JDFException("getAttributePart tried to" + " return a JDFElement as a JDFResource");
               }

               result = ((JDFResource)jdfRes).getAttributePart(key);
            }
         }

         return result;
      }

      ///   
      ///	 <summary> * Gets a unique vector of resource leaf elements that actually contain the attribute key
      ///	 *  </summary>
      ///	 * <param name="key"> attribute key to look for </param>
      ///	 * <returns> VElement a vector of resource leaf elements that actually contain the attribute key </returns>
      ///	 
      public virtual VElement getAttributePartVector(string key)
      {
         VElement leaves = getLeaves(false);
         VElement v = new VElement();

         for (int i = 0; i < leaves.Count; i++)
         {
            JDFResource p = ((JDFResource)leaves[i]).getAttributePart(key);

            if (p != null)
            {
               bool bFound = false;

               for (int j = 0; j < v.Count && !bFound; j++)
               {
                  if (p.Equals(v[j]))
                  {
                     bFound = true;
                  }
               }

               if (!bFound)
               {
                  v.Add(p);
               }
            }
         }

         return v;
      }

      ///   
      ///	 <summary> * Gets the XPath full tree representation of 'this'
      ///	 *  </summary>
      ///	 * <param name="relativeTo"> relative path to which to create an xpath </param>
      ///	 * <param name="methCountSiblings"> , if 1 count siblings, i.e. add '[n]' if 0, only specify the path of parents </param>
      ///	 * <returns> String the XPath representation of 'this' e.g. <code>/root/parent/element</code><br>
      ///	 *         <code>null</code> if parent of this is null (e.g. called on rootnode) </returns>
      ///	 
      public override string buildXPath(string relativeTo, int methCountSiblings)
      {
         if ((methCountSiblings != 2 && methCountSiblings != 3) || isResourceElement() || isResourceRoot())
         {
            return base.buildXPath(relativeTo, methCountSiblings);
         }

         string path = "/" + LocalName; // tbd handle namespaces
         string sKey = getLocalPartitionKey();
         if (sKey != null)
         {
            path += "[@" + sKey + "=\"" + getAttribute(sKey) + "\"]";
         }

         KElement parent = getParentNode_KElement();
         return parent.buildXPath(relativeTo, methCountSiblings) + path;
      }

      ///   
      ///	 <summary> * get the local partition key of this leaf
      ///	 *  </summary>
      ///	 * <returns> the key, if one exists, null otherwise </returns>
      ///	 
      public virtual string getLocalPartitionKey()
      {
         JDFResource partRoot = getResourceRoot();
         if (partRoot == null)
            return null;
         if (partRoot == this)
            return null;
         VString keys = partRoot.getPartIDKeys();
         if (keys == null)
            return null;
         int n = 0;
         KElement par = getParentNode_KElement();
         while (par != partRoot)
         {
            n++;
            par = par.getParentNode_KElement();
         }
         if (n >= keys.Count)
            return null;
         string s = keys.stringAt(n);
         return hasAttribute_KElement(s, null, false) ? s : null;
      }

      ///   
      ///	 <summary> * remove any resource specific attribute when making this to an element </summary>
      ///	 
      public virtual void cleanResourceAttributes()
      {
         // clean up resource specific attributes
         removeAttribute(AttributeName.ID);
         removeAttribute(AttributeName.CLASS);
         removeAttribute(AttributeName.STATUS);
         removeAttribute(AttributeName.PARTUSAGE);
         removeAttribute(AttributeName.NOOP);
         VString v = getPartIDKeys();
         if (v != null)
         {
            for (int i = 0; i < v.Count; i++)
            {
               removeAttribute(v.stringAt(i));
            }
         }
         removeAttribute(AttributeName.LOCKED);
         removeAttribute(AttributeName.PARTIDKEYS);
         removeAttribute(AttributeName.RREFS, null);
         removeAttribute(AttributeName.SPAWNIDS, null);
         removeAttribute(AttributeName.SPAWNSTATUS, null);

      }

      ///   
      ///	 <summary> * Removes attributes
      ///	 *  </summary>
      ///	 * <param name="attrib"> the attribute key to remove </param>
      ///	 * <param name="nameSpaceURI"> the attribute nameSpaceURI to remove
      ///	 * 
      ///	 * @default removeAttribute(attrib, null) </param>
      ///	 
      public override void removeAttribute(string attrib, string nameSpaceURI)
      {
         if (base.hasAttribute(attrib, nameSpaceURI, false))
         {
            if ((nameSpaceURI == null) || nameSpaceURI.Equals(JDFConstants.EMPTYSTRING))
            {
               removeAttribute(attrib);
            }
            else
            {
               removeAttributeNS(nameSpaceURI, attrib);
            }
         }
      }

      ///   
      ///	 <summary> * Removes attributes, also removes overwrites in any child parts
      ///	 *  </summary>
      ///	 * <param name="attrib"> the attribute key to remove </param>
      ///	 * <param name="nameSpaceURI"> the attribute nameSpaceURI to remove
      ///	 * 
      ///	 * @default removeAttribute(attrib, null) </param>
      ///	 
      public virtual void removeAttributeFromLeaves(string attrib, string nameSpaceURI)
      {
         VElement v = getLeaves(true);
         v.removeAttribute(attrib, nameSpaceURI);
      }

      ///   
      ///	 <summary> * Reduces partition so that only the parts that overlap with vResources remain
      ///	 *  </summary>
      ///	 * <param name="vValidParts"> vector of partmaps that define the individual valid parts.<br>
      ///	 *            The individual PartMaps are ored to define the final resource. </param>
      ///	 
      public virtual void reducePartitions(VJDFAttributeMap vValidParts_)
      {
         VJDFAttributeMap vValidParts = vValidParts_;

         if (vValidParts_ != null && vValidParts_.Count > 0)
         {
            VString partIDKeys = getPartIDKeys();
            vValidParts = new VJDFAttributeMap(); // need local copy
            for (int i = 0; i < vValidParts_.Count; i++)
            {
               JDFAttributeMap map = vValidParts_[i];
               VElement v = getPartitionVector(map, EnumPartUsage.Implicit);
               if (v != null)
               {
                  int vSize = v.Count;
                  for (int j = 0; j < vSize; j++)
                  {
                     JDFResource r = (JDFResource)v[j];
                     vValidParts.Add(r.getPartMap(partIDKeys));
                  }
               }
            }
         }

         int size = vValidParts == null ? 0 : vValidParts.Count;
         if (size != 0 && vValidParts != null && getPartIDKeys().Count > 0)
         {
            bool bBadParents = false;
            VElement leaves = getLeaves(false);

            // loop over all leaves of this resource
            for (int i = 0; i < leaves.Count; i++)
            {
               bool bOK = false;
               JDFResource leaf = (JDFResource)leaves[i];
               JDFAttributeMap leafMap = leaf.getPartMap();

               for (int j = 0; j < size && !bOK; j++)
               {
                  // the partition of this resource is included in the part
                  // vector --> keep it
                  if (leafMap.overlapMap(vValidParts[j]))
                  {
                     bOK = true;
                  }
               }

               if (!bOK)
               { // don't keep this leaf
                  leaf.deleteNode();
                  bBadParents = true;
               }
            }

            // I removed some, lets see if some of the parents were also bad
            if (bBadParents)
            {
               reducePartitions(vValidParts);
            }
         }
      }

      ///   
      ///	 <summary> * reduceParts
      ///	 *  </summary>
      ///	 * <param name="vParts"> </param>
      ///	 * @deprecated [BLD009] not in C++ anymore, not used internally here 
      ///	 
      [Obsolete("[BLD009] not in C++ anymore, not used internally here")]
      public virtual void reduceParts(ArrayList vParts)
      {
         if (!(vParts.Count == 0) && (getPartIDKeys().Count > 0))
         {
            VElement leaves = getLeaves(false);
            string nodeName = Name;

            for (int i = 0; i < leaves.Count; i++)
            {
               bool bOK = false;
               JDFResource leaf = (JDFResource)leaves[i];
               JDFAttributeMap leafMap = leaf.getPartMap();

               for (int j = 0; j < vParts.Count && !bOK; j++)
               {
                  if (leafMap.subMap((JDFAttributeMap)vParts[j]))
                  {
                     bOK = true;
                  }
               }

               if (!bOK)
               {
                  KElement parent = leaf.getParentNode_KElement();

                  if (parent != null)
                  {
                     bool bBreakWhile = false;
                     JDFResource parentNode = (JDFResource)parent;

                     while (nodeName.Equals(parentNode.Name) && !bBreakWhile)
                     {
                        // still in the resource
                        if (parentNode.numChildElements(nodeName, null) == 1)
                        {
                           // it only has a leaf, which is invalid,
                           // thus the intermediate node is also invalid
                           leaf = parentNode;
                           parent = parentNode.getParentNode_KElement();

                           if (parent == null)
                           {
                              bBreakWhile = true;
                           }

                           parentNode = (JDFResource)parent;
                        }
                        else
                        {
                           bBreakWhile = true;
                        }
                     }

                     leaf.deleteNode();
                  }
               }
            }
         }
      }

      ///   
      ///	 <summary> * Gets a map of all partition key-value pairs for this leaf / node. This includes a recursion to the part root.
      ///	 *  </summary>
      ///	 * <param name="ids"> </param>
      ///	 * <returns> JDFAttributeMap - the part attribute map for 'this' leaf / node </returns>
      ///	 
      public virtual JDFAttributeMap getPartMap(VString ids)
      {
         JDFAttributeMap m = new JDFAttributeMap();

         VString.Enumerator idsIterator = ids.GetEnumerator();
         while (idsIterator.MoveNext())
         {
            string id = idsIterator.Current;
            string atr = getAttribute(id, null, null);
            if (atr != null)
            {
               m.put(id, atr);
            }
         }

         return m;
      }

      ///   
      ///	 <summary> * Gets a map of all partition key-value pairs for this leaf / node this includes a recursion to the part root;
      ///	 *  </summary>
      ///	 * <returns> JDFAttributeMap - the part attribute map for 'this' leaf / node </returns>
      ///	 
      public override JDFAttributeMap getPartMap()
      {
         return getPartMap(getPartIDKeys());
      }

      ///   
      ///	 <summary> * Gets nodename of a ResourceLink that links to 'this'
      ///	 *  </summary>
      ///	 * <returns> String - name of a link to 'this' </returns>
      ///	 
      public virtual string getLinkString()
      {
         return Name + JDFConstants.LINK;
      }

      ///   
      ///	 <summary> * Merges the spawnIDs of the various partitions <br>
      ///	 * also updates SpawnStatus, if necessary <br>
      ///	 * this routine is needed to correctly handle nested spawning and merging
      ///	 *  </summary>
      ///	 * <param name="resToMerge"> the resource with potentially new spawnIDs </param>
      ///	 * <param name="previousMergeIDs"> vector of already merged spawnIDs that may still be in a partition </param>
      ///	 * @deprecated use JDFMerge.mergeSpawnIDS 
      ///	 
      [Obsolete("use JDFMerge.mergeSpawnIDS")]
      public virtual void mergeSpawnIDs(JDFResource resToMerge, VString previousMergeIDs)
      {
         if (!getID().Equals(resToMerge.getID()))
         {
            throw new JDFException("JDFResource.mergeSpawnIDs  merging incompatible resources ID = " + getID() + " IDMerge = " + resToMerge.getID());
         }

         VElement allLeaves = getLeaves(true);
         VString partIDKeys = getPartIDKeys();
         for (int i = 0; i < allLeaves.Count; i++)
         {
            JDFResource thisResNode = (JDFResource)allLeaves[i];
            JDFResource mergeResNode = resToMerge.getPartition(thisResNode.getPartMap(partIDKeys), EnumPartUsage.Explicit);

            if (mergeResNode != null)
            {
               VString vSpawnIDs = thisResNode.getSpawnIDs(false);
               int siz;
               if (vSpawnIDs == null)
               {
                  siz = 0;
                  vSpawnIDs = mergeResNode.getSpawnIDs(false);
               }
               else
               {
                  siz = vSpawnIDs.Count;
                  vSpawnIDs.appendUnique(mergeResNode.getSpawnIDs(false));
               }

               if (vSpawnIDs != null)
                  vSpawnIDs.removeStrings(previousMergeIDs, 999999);

               if (vSpawnIDs == null || vSpawnIDs.IsEmpty())
               {
                  thisResNode.removeAttribute(AttributeName.SPAWNIDS);
                  thisResNode.removeAttribute(AttributeName.SPAWNSTATUS);
               }
               else
               {
                  // AppendUnique modified the vector
                  if (siz != vSpawnIDs.Count)
                  {
                     thisResNode.setSpawnIDs(vSpawnIDs);

                     // one of the spawnstatus elements was rw, must also be
                     // valid here
                     if (mergeResNode.getSpawnStatus() == EnumSpawnStatus.SpawnedRW)
                     {
                        thisResNode.setSpawnStatus(EnumSpawnStatus.SpawnedRW);
                     }
                  }
               }
            }
         }
      }

      ///   
      ///	 <summary> * Expand so that each leaf is complete (except for ID)
      ///	 *  </summary>
      ///	 * <param name="bDeleteFromNode"> removes all intermediate elements and attributes
      ///	 * 
      ///	 * @default expand(false) </param>
      ///	 
      public virtual void expand(bool bDeleteFromNode)
      {
         VElement leaves = getLeaves(false);
         if (leaves.Count == 1 && leaves[0] == this)
         {
            return; // this is a non partitioned root node
         }

         VString parts = getRootPartAtts();

         int leafSize = leaves.Count;

         for (int i = 0; i < leafSize; i++)
         {
            JDFResource leaf = (JDFResource)leaves[i];
            VString atts = new VString(leaf.getAttributeVector_JDFResource());
            int j = 0;

            int attSize = atts.Count;
            for (j = 0; j < attSize; j++)
            {
               string aj = atts.stringAt(j);
               if (!parts.Contains(aj))
               {
                  leaf.setAttribute(aj, leaf.getAttribute(aj, null, null), null);
               }
            }

            // expand sub-elements - since 190602
            VElement vElm = leaf.getChildElementVector(null, null, null, true, 0, false);
            for (j = 0; j < vElm.Count; j++)
            {
               string nodeName = (vElm[j]).Name;
               // copy non existing element to leaf
               if (leaf.getElement_JDFElement(nodeName, null, 0) == null)
               {
                  VElement vCopy = leaf.getChildElementVector(nodeName, null, null, true, 0, false);

                  int copySize = vCopy.Count;
                  for (int k = 0; k < copySize; k++)
                  {
                     leaf.copyElement(vCopy[k], null);
                  }
               }
            }
         }

         if (bDeleteFromNode)
         {
            string nodeName = Name;

            for (int i = 0; i < leafSize; i++)
            {
               JDFResource res = (JDFResource)leaves[i];
               JDFElement r = (JDFElement)res.getParentNode_KElement();

               while (r != null && r.Name.Equals(nodeName))
               {
                  VString atts = new VString(r.getAttributeVector());
                  int j;
                  for (j = 0; j < atts.Count; j++)
                  {
                     string aj = atts.stringAt(j);
                     if (!parts.Contains(aj))
                     {
                        r.removeAttribute(aj, null);
                     }
                  }

                  // delete all intermediate elements
                  VElement vElm = r.getChildElementVector_JDFElement(null, null, null, true, 0, false);
                  for (j = 0; j < vElm.Count; j++)
                  {
                     if (!(vElm[j]).Name.Equals(nodeName))
                     {
                        (vElm[j]).deleteNode();
                     }
                  }

                  if (r == this)
                  {
                     break;
                  }

                  r = (JDFElement)r.getParentNode_KElement();
               }
            }
         }
      }

      ///   
      ///	 <summary> * get the list of attributes that are administrative only
      ///	 *  </summary>
      ///	 * <returns> the VString that lists all adminstrative and partition keys </returns>
      ///	 
      public virtual VString getRootPartAtts()
      {
         VString parts = getPartIDKeys();
         parts.Add(AttributeName.ID);
         parts.Add(AttributeName.CLASS);
         parts.Add(AttributeName.PARTIDKEYS);
         parts.Add(AttributeName.AGENTNAME);
         parts.Add(AttributeName.AGENTVERSION);
         parts.Add(AttributeName.AUTHOR);
         parts.Add(AttributeName.PARTUSAGE);
         return parts;
      }

      ///   
      ///	 <summary> * collapse all redundant attributes and elements
      ///	 *  </summary>
      ///	 * <param name="bCollapseToNode"> only collapse redundant attriutes and elements that pre-exist in the nodes
      ///	 * 
      ///	 * @default Collapse(false) </param>
      ///	 
      public virtual void collapse(bool bCollapseToNode)
      {
         VElement leaves = getLeaves(false);
         if (leaves.Count == 1 && leaves[0] == this)
         {
            return; // this is a non partitioned root node
         }

         VString parts = getRootPartAtts();
         for (int i = 0; i < leaves.Count; i++)
         {
            JDFResource leaf = (JDFResource)leaves[i];
            VString atts = leaf.getAttributeVector_JDFResource();
            atts.removeStrings(parts, int.MaxValue);
            JDFResource parent = (JDFResource)leaf.getParentNode_KElement();

            while (true)
            {
               VElement localLeaves = parent.getChildElementVector_JDFElement(Name, null, null, true, 0, false);
               collapseAttributes(bCollapseToNode, leaf, atts, parent, localLeaves);
               // since 190602 also collapse elements
               collapseElements(bCollapseToNode, leaf, parent, localLeaves);
               if (parent.isResourceRoot() || parent == this)
               {
                  break;
               }

               leaf = parent;
               parent = (JDFResource)parent.getParentNode_KElement();

            }
         }
      }



      private void collapseAttributes(bool bCollapseToNode, JDFResource leaf, VString atts, JDFResource parent, VElement localLeaves)
      {
         int localSize = localLeaves.Count;
         for (int j = 0; j < atts.Count; j++)
         {
            string att = atts.stringAt(j);
            // reduce lower stuff
            if ((!bCollapseToNode) && (!parent.hasAttribute_KElement(att, null, false)))
            {
               string attVal = leaf.getAttribute_KElement(att, null, JDFConstants.EMPTYSTRING);
               // Matt-Start
               if (!parent.getAttribute_KElement(att).Equals(attVal))
               // Matt-End
               {
                  // check all local children and grandchildren
                  bool bAllSame = true;
                  for (int l = 0; l < localSize; l++)
                  {
                     if (!(localLeaves[l]).getAttribute(att, null, JDFConstants.EMPTYSTRING).Equals(attVal))
                     {
                        bAllSame = false;
                        break;
                     }
                  }
                  // Matt-Start
                  if (bAllSame)
                  {
                     parent.setAttribute(att, attVal, null);
                     // remove from all leaves...
                     for (int l = 0; l < localSize; l++)
                     {
                        ((JDFElement)localLeaves[l]).removeAttribute(att);
                     }

                  }
               }
            }
            // remove leaf element attribute if it is defined lower in the tree
            string parentAttribute = parent.getAttribute(att, null, null);
            if (parentAttribute != null && parentAttribute.Equals(leaf.getAttribute_KElement(att, null, null)))
            {
               leaf.removeAttribute(att, null);
            }
         }
      }



      private void collapseElements(bool bCollapseToNode, JDFResource leaf, JDFResource parent, VElement localLeaves)
      {
         int localSize = localLeaves.Count;
         VElement vElm = leaf.getChildElementVector_JDFElement(null, null, null, true, 0, false);
         for (int j = 0; j < vElm.Count; j++)
         {
            string nodeName = (vElm[j]).Name;
            VElement vParentElm = parent.getChildElementVector(nodeName, null, null, true, 0, false);
            VElement vLocalElm = leaf.getChildElementVector_JDFElement(nodeName, null, null, true, 0, false);
            // vector of elements for the first leaf
            // this is reused for comparison since all leaves must be equal
            VElement localNamedElements0 = (localLeaves[0]).getChildElementVector(nodeName, null, null, true, 0, false);

            int elm0Size = localNamedElements0.Count;
            // true if all elements of all local leaves are equal and in the
            // correct sequence
            // if elm0size==0 we have nothing to do - leave loop
            bool bElmEqual = elm0Size > 0;
            // only collapse if pre-existing elements exist in the nodes
            if (bCollapseToNode && bElmEqual)
            {
               if (elm0Size == vParentElm.Count)
               {
                  // loop over all elements of leaf 0 and compare with the
                  // parent leaf
                  for (int kk = 0; kk < elm0Size; kk++)
                  {
                     KElement kelem1 = localNamedElements0[kk];
                     KElement kelem2 = vParentElm[kk];
                     if (!kelem1.isEqual(kelem2))
                     {
                        bElmEqual = false;
                        break;
                     }
                  }
               }
               else
               {
                  bElmEqual = false;
               }
            }
            if (bElmEqual)
            {
               // loop over all local leaves except 0 (which is the one we
               // compare to)
               for (int k = 1; k < localSize; k++)
               {
                  // vector of elements for leaf k.
                  VElement localNamedElements = (localLeaves[k]).getChildElementVector(nodeName, null, null, true, 0, false);
                  // not equal if a different number of elements exists
                  if (localNamedElements.Count != elm0Size)
                  {
                     bElmEqual = false;
                     break;
                  }
                  // the number of elements is identical, now compare each one
                  // individually
                  // note that the sequence is important and
                  // thus we don't have to check ordering permutations
                  for (int kk = 0; kk < elm0Size; kk++)
                  {
                     if (!(localNamedElements0[kk]).isEqual(localNamedElements[kk]))
                     {
                        bElmEqual = false;
                        break;
                     }
                  }
                  // rebreak if not equal
                  if (!bElmEqual)
                  {
                     break;
                  }
               }
            }
            // all are identical --> zapp em
            if (bElmEqual)
            {
               // delete all intermediate children before copying
               if (!bCollapseToNode)
               {
                  parent.removeChildren(nodeName, null, null);
                  for (int k = 0; k < elm0Size; k++)
                  {
                     parent.copyElement(localNamedElements0[k], null);
                  }
               }
               for (int kk = 0; kk < localSize; kk++)
               {
                  (localLeaves[kk]).removeChildren(nodeName, null, null);
               }
               // not all children are equal, but maybe this one individual; if
               // so -> ciao
            }
            else if (vParentElm.Count == vLocalElm.Count)
            {
               bool bZappEm = vParentElm.Count > 0;
               for (int k = 0; k < vParentElm.Count; k++)
               {
                  if (!(vParentElm[k]).isEqual(vLocalElm[k]))
                  {
                     bZappEm = false;
                     break;
                  }
               }
               // this leaves elements are all identical and in the same
               // sequence; we can inherit so zapp em
               if (bZappEm)
               {
                  leaf.removeChildren(nodeName, null, null);
               }
            }
         }
      }

      ///   
      ///	 <summary> * Spawns a given partition for a given SpawnID
      ///	 *  </summary>
      ///	 * <param name="spawnID"> the SpawnID that it was spawned with </param>
      ///	 * <param name="spawnStatus"> SpawnStatus to spawn this resource with </param>
      ///	 * <param name="vParts"> vector of partitions that it was spawned with </param>
      ///	 * <param name="bStayInMain"> if true, the function is applied to the main JDF, else to the spawned JDF </param>
      ///	 * @deprecated use JDFSpawn.spawnPart 
      ///	 
      [Obsolete("use JDFSpawn.spawnPart")]
      public virtual void spawnPart(string spawnID, EnumSpawnStatus spawnStatus, VJDFAttributeMap vParts, bool bStayInMain)
      {
         if (vParts != null && vParts.Count > 0)
         {
            int size = vParts.Count;
            // loop over all part maps to get best matching resource
            for (int j = 0; j < size; j++)
            {
               JDFResource pLeaf = getPartition(vParts[j], null);
               if (pLeaf != null)
               {
                  // set the lock of the leaf to true if it is RO, else unlock
                  // it
                  if (bStayInMain)
                  {
                     if ((spawnStatus == EnumSpawnStatus.SpawnedRW) || (pLeaf.getSpawnStatus() != EnumSpawnStatus.SpawnedRW))
                     {
                        pLeaf.setSpawnStatus(spawnStatus);
                        pLeaf.setLocked(spawnStatus == EnumSpawnStatus.SpawnedRW);
                     }
                  }
                  else
                  {
                     pLeaf.setLocked(spawnStatus != EnumSpawnStatus.SpawnedRW);
                  }

                  pLeaf.appendSpawnIDs(spawnID);
               }
            }
         }
         else
         {
            if (bStayInMain)
            {
               if ((spawnStatus == EnumSpawnStatus.SpawnedRW) || (getSpawnStatus() != EnumSpawnStatus.SpawnedRW))
               {
                  setSpawnStatus(spawnStatus);
                  setLocked(spawnStatus == EnumSpawnStatus.SpawnedRW);
               }
            }
            else
            {
               setLocked(spawnStatus != EnumSpawnStatus.SpawnedRW);
            }

            appendSpawnIDs(spawnID);
         }
      }

      ///   
      ///	 <summary> * Find the appropriate partition for a given SpawnID and undo the spawn procedure
      ///	 *  </summary>
      ///	 * <param name="spawnID"> the SpawnID that it was spawned with </param>
      ///	 * <param name="spawnStatus"> SpawnStatus this resource was spawned with </param>
      ///	 
      public virtual void unSpawnPart(string spawnID, EnumSpawnStatus spawnStatus)
      {
         VElement vLeaves = getNodesWithSpawnID(spawnID);
         for (int i = 0; i < vLeaves.Count; i++)
         {
            JDFResource leaf = (JDFResource)vLeaves[i];

            leaf.removeFromSpawnIDs(spawnID);
            if (spawnStatus == EnumSpawnStatus.SpawnedRW)
            {
               leaf.removeAttribute(AttributeName.LOCKED, null);
            }

            if (!leaf.hasAttribute(AttributeName.SPAWNIDS, null, false))
            {
               leaf.removeAttribute(AttributeName.SPAWNSTATUS, null);
            }
            else if (spawnStatus == EnumSpawnStatus.SpawnedRW)
            {
               // we've removed the one and only rw, it can only be ro if
               // anything is still left
               leaf.setSpawnStatus(EnumSpawnStatus.SpawnedRO);
            }
         }
      }

      ///   
      ///	 <summary> * Gets of 'this' all leaves and intermediate nodes that have an explicit spawnID set
      ///	 *  </summary>
      ///	 * <param name="spawnID"> the spawnID to look for </param>
      ///	 * <returns> VElement - the vector of nodes or leaves of 'this' that contain spawnID </returns>
      ///	 
      public virtual VElement getNodesWithSpawnID(string spawnID)
      {
         VElement v2 = getLeaves(true);

         for (int i = v2.Count - 1; i >= 0; i--)
         {
            JDFElement e = (JDFElement)v2[i];
            if (!e.hasAttribute_KElement(AttributeName.SPAWNIDS, null, false) || !e.includesMatchingAttribute(AttributeName.SPAWNIDS, spawnID, AttributeInfo.EnumAttributeType.NMTOKENS))
            {
               v2.RemoveAt(i);
            }
         }
         return v2;
      }

      ///   
      ///	 <summary> * Gets the vector of parts (resource leaves or nodes) that match mAttribute
      ///	 *  </summary>
      ///	 * <param name="m"> the map of key-value partitions (where key - PartIDKey, value - its value) </param>
      ///	 * <param name="bIncomplete"> if true, also accept nodes that are are not completely specified in the partmap,<br>
      ///	 *            e.g. if partitioned by run, RunPage and only Run is specified
      ///	 *  </param>
      ///	 * <returns> VElement - the vector of matching resource leaves or nodes </returns>
      ///	 * @deprecated use getPartitionVector(JDFAttributeMap m, EnumPartUsage partUsage)
      ///	 * 
      ///	 * @default getPartitionVector(m, true) 
      ///	 
      [Obsolete("use getPartitionVector(JDFAttributeMap m, EnumPartUsage partUsage)")]
      public virtual VElement getPartitionVector(JDFAttributeMap m, bool bIncomplete)
      {
         return getDeepPartVector(m, bIncomplete ? EnumPartUsage.Implicit : EnumPartUsage.Explicit, 0, getPartIDKeys());
      }

      ///   
      ///	 <summary> * Gets the vector of parts (resource leaves or nodes) that match mAttribute
      ///	 *  </summary>
      ///	 * <param name="m"> the map of key-value partitions (where key - PartIDKey, value - its value) </param>
      ///	 * <param name="partUsage"> also accept nodes that are are not completely specified in the partmap, e.g. if partitioned by
      ///	 *            run, RunPage and only Run is specified
      ///	 *  </param>
      ///	 * <returns> VElement - the vector of matching resource leaves or nodes
      ///	 * 
      ///	 * @default getPartitionVector(m, null) </returns>
      ///	 
      public virtual VElement getPartitionVector(JDFAttributeMap m, EnumPartUsage partUsage)
      {
         return getDeepPartVector(m, partUsage, -1, getPartIDKeys());
      }

      ///   
      ///	 <summary> * Gets the vector of parts that matches specified key-value pair
      ///	 *  </summary>
      ///	 * <param name="key"> the PartIDKey attribute name </param>
      ///	 * <param name="value"> the string value of the partition key
      ///	 *  </param>
      ///	 * <returns> VElement - the vector matching resource leaves or nodes </returns>
      ///	 * @deprecated use getPartitionVector(JDFAttributeMap m, EnumPartUsage partUsage)
      ///	 * @default getPartitionVector(key, value, true) 
      ///	 
      [Obsolete("use getPartitionVector(JDFAttributeMap m, EnumPartUsage partUsage)")]
      public virtual VElement getPartitionVector(EnumPartIDKey key, string @value, bool bIncomplete)
      {
         JDFAttributeMap mp = new JDFAttributeMap(key.getName(), @value);
         return getPartitionVector(mp, bIncomplete);
      }

      ///   
      ///	 <summary> * gets a prefix for ID creation for the element
      ///	 *  </summary>
      ///	 * <returns> String - a prefix for ID creation </returns>
      ///	 
      public override string getIDPrefix()
      {
         return "r";
      }

      ///   
      ///	 <summary> * Gets a vector of maps of all partition attribute key-value pairs for this node and all its children
      ///	 *  </summary>
      ///	 * <param name="bIntermediate"> if true also includes intermediate nodes including this </param>
      ///	 * <returns> VJDFAttributeMap - the vector of partition attribute maps for this leaf / node and all its children
      ///	 * 
      ///	 * @default getPartMapVector(false) </returns>
      ///	 
      public virtual VJDFAttributeMap getPartMapVector(bool bIntermediate)
      {
         VElement allNodes = getLeaves(bIntermediate);
         VJDFAttributeMap vReturn = new VJDFAttributeMap();
         VString ids = getPartIDKeys();

         for (int j = 0; j < allNodes.Count; j++)
         {
            JDFAttributeMap m = new JDFAttributeMap();
            JDFResource r = (JDFResource)allNodes[j];

            for (int i = 0; i < ids.Count; i++)
            {
               string strIds = ids[i];

               if (r.hasAttribute(strIds, null, false))
               {
                  m.put(strIds, r.getAttribute(strIds, null, JDFConstants.EMPTYSTRING));
               }
            }
            if (m.Count > 0)
               vReturn.appendUnique(m);
         }

         return vReturn;
      }

      ///   
      ///	 <summary> * Finds the canonical vector of parts that defines the vector of parts that fits to vParts. If all children of a
      ///	 * parent node are in vParts, they are replaced by their parent. <br>
      ///	 * for example the canonical vector of all leaves is the root
      ///	 *  </summary>
      ///	 * <param name="vParts"> the vector of parts to check against 'this' </param>
      ///	 * <returns> VJDFAttributeMap the canonical vector </returns>
      ///	 
      public virtual VJDFAttributeMap reducePartVector(VJDFAttributeMap vParts)
      {
         VJDFAttributeMap vTest = new VJDFAttributeMap();
         vTest.setVector(vParts.getVector());

         // reduce vParts internally
         for (int i = 0; i < vTest.Count; i++)
         {
            JDFAttributeMap partMapi = vTest[i];
            for (int j = vTest.Count - 1; j > i; j--)
            {
               JDFAttributeMap partMapj = vTest[j];
               if (partMapj.subMap(partMapi))
               {
                  vTest.RemoveAt(j);
               }
               else if (partMapi.subMap(partMapj))
               {
                  vTest.RemoveAt(i);
                  i--; // we erased x(i) and now have to undo i++ of the loop
                  break;
               }
            }
         }
         // this loop allows for arbitrary ordering of the incoming maps and
         // handles side effects
         while (true)
         {
            bool bChanged;
            bChanged = false;

            // loop over all partitions of the vector
            for (int i = 0; i < vTest.Count; i++)
            {
               JDFAttributeMap partMapi = vTest[i];
               JDFResource r = getPartition(partMapi, EnumPartUsage.Explicit);

               if (r == null)
               { // this partition does not exist; remove it
                  vTest.RemoveAt(i);
                  i--;
                  // we erased i which move i+1 to i which has to be checked
                  continue;
               }
               // if the root is included, all others are by defult also
               // included
               if (r.isResourceRoot())
               {
                  vTest.Clear();
                  vTest.appendUnique(new JDFAttributeMap());
                  return vTest;
               }

               // check whether all children of parent are included in vTest
               JDFElement parentElm = (JDFElement)r.getParentNode_KElement();

               if (parentElm != null)
               {
                  // must be element, since the resource version of
                  // getChildElementVector skips partition nodes
                  VElement vKids = new VElement(parentElm.getChildElementVector(Name, null, null, true, 0, false));

                  // remember idix of vtmp Vector of Integer (object type, not
                  // the simple datatype)
                  List<int> vTmp = new List<int>();

                  for (int j = 0; j < vKids.Count; j++)
                  {
                     JDFAttributeMap kidMap = ((JDFResource)vKids[j]).getPartMap();
                     int index = vTest.IndexOf(kidMap);
                     if (index >= 0)
                     {
                        vTmp.Add(index); // (new int(index));
                     }
                     else
                     {
                        // we found a child in the resource that is not in
                        // vTest, --> we cannot consolidate
                        vTmp.Clear();
                        break;
                     }
                  }

                  // all children are accounted for; replace them with parent
                  if (!(vTmp.Count == 0))
                  {
                     // we have to sort and go backwards; otherwise we
                     // invalidate the indices in vTmp
                     for (int l = vTmp.Count - 1; l >= 0; l--)
                     {
                        int mymax = -1;
                        int posMax = -1;
                        for (int kk = 0; kk < vTmp.Count; kk++)
                        {
                           //if ((vTmp[kk]).intValue() > mymax)
                           if (vTmp[kk] > mymax)
                           {
                              mymax = (vTmp[kk]); //.intValue();
                              posMax = kk;
                           }
                        }

                        // remove all kids
                        vTest.RemoveAt(mymax);
                        vTmp.RemoveAt(posMax);
                     }

                     // add parent
                     JDFResource parent = (JDFResource)parentElm;
                     vTest.appendUnique(parent.getPartMap());

                     // we modified the vector and should recheck
                     bChanged = true;
                  }

               }
            }

            // we found nothing this time; done
            if (!bChanged)
            {
               break;
            }
         }
         return vTest;
      }

      ///   
      ///	 <summary> * Generates the id of a modified resource
      ///	 *  </summary>
      ///	 * <returns> String the new id
      ///	 *  </returns>
      ///	 * <exception cref="JDFException"> if there are too many equivalent modified resources </exception>
      ///	 
      public virtual string newModifiedID()
      {
         string id = getID();
         if (id.Length < 9)
         {
            return id + "_old_001";
         }

         string postFix = id.Substring(0, 8);
         string preFix = id;
         VString siblingIDs = (VString)getResourcePool().getResIds();

         if (postFix.Substring(0, "_old_".Length).Equals("_old_"))
         {
            preFix = id.Substring(0, id.Length - 8);
         }

         int siz = siblingIDs.Count;
         string buf = JDFConstants.EMPTYSTRING;
         bool bTooManyIDs = true;
         string newModifiedID = JDFConstants.EMPTYSTRING;

         for (int i = 1; i < 1000 && bTooManyIDs; i++)
         {
            // sprintf(buf, "%.3i", i);
            buf = makeID("_old_", 3, i);

            newModifiedID = preFix + buf;
            bool bFound = false;

            for (int j = 0; j < siz && !bFound; j++)
            {
               if (newModifiedID.Equals(siblingIDs[j]))
               {
                  bFound = true;
               }
            }

            if (!bFound)
            {
               bTooManyIDs = false;
            }
         }

         if (bTooManyIDs)
         {
            throw new JDFException(" JDFResource.newModifiedID too many " + "equivalent modified resources! Resource ID = " + id);
         }

         return newModifiedID;
      }

      ///   
      ///	 <summary> * patch value on the left with 0 up to numberOfDigits and concatenate it to s
      ///	 *  </summary>
      ///	 * <param name="s"> text part of ID </param>
      ///	 * <param name="numberOfDigits"> length of number part of ID </param>
      ///	 * <param name="value"> number part of ID </param>
      ///	 * <returns> String ID
      ///	 *  </returns>
      ///	 * <exception cref="JDFException"> if numberOfValueDigits > numberOfDigits </exception>
      ///	 
      private string makeID(string s, int numberOfDigits, int @value)
      {
         string result = s;
         int myValue = @value; // new int(@value);

         int numberOfValueDigits = myValue.ToString().Length;

         if (numberOfValueDigits > numberOfDigits)
         {
            throw new JDFException("Value is bigger then maxDiggits: Cant make String");
         }

         for (int i = 0; i < numberOfDigits - numberOfValueDigits; i++)
         {
            result += "0";
         }

         result += myValue.ToString();

         return result;
      }

      ///   
      ///	 <summary> * Gets the resourcepool that 'this' lives in
      ///	 *  </summary>
      ///	 * <returns> JDFResourcePool the ResourcePool where 'this' lives<br> </returns>
      ///	 
      public virtual JDFResourcePool getResourcePool()
      {
         return (JDFResourcePool)getDeepParent(ElementName.RESOURCEPOOL, 0);
      }

      ///   
      ///	 <summary> * Tests, whether the first ancestor of 'this' is in ValidParentNodeNames - must be one of:
      ///	 * DropItemIntent,CustomerInfo,NodeInfo,ResourcePool,PipeParams ,ResourceInfo,ResourceCmdParams
      ///	 *  </summary>
      ///	 * <returns> boolean true, if 'this' is a root resource </returns>
      ///	 
      public virtual bool isResourceRoot()
      {
         KElement parentNode = this.getParentNode_KElement();
         if (parentNode == null)
         {
            return true;
         }
         if (parentNode.Name.Equals(Name))
         {
            return false;
         }

         // special handling for NI and CI as resources
         string locName = parentNode.LocalName;
         if (locName.Equals(ElementName.NODEINFO) || locName.Equals(ElementName.CUSTOMERINFO))
         {
            if (getResourcePool() != null)
            {
               return false;
            }
         }

         return isValidParentNodeName(locName);
      }

      ///   
      ///	 <summary> * Tests, whether the first ancestor of 'this' is in validRootParentNodeNames() <br>
      ///	 * must be one of: ResourcePool,PipeParams,ResourceInfo,ResourceCmdParams
      ///	 *  </summary>
      ///	 * <returns> boolean - true if this lives as a root resource in the ResourcePool </returns>
      ///	 
      public virtual bool isResourceRootRoot()
      {
         KElement parentNode = this.getParentNode_KElement();
         if (parentNode == null)
         {
            return true;
         }

         if (parentNode.Name.Equals(Name))
         {
            return false;
         }

         string locName = parentNode.LocalName;
         return isValidRootParentNodeName(locName);
      }

      ///   
      ///	 <summary> * update the amount of a resource based on the connected resource links Only Condition="Good" is counted if no
      ///	 * explicit partioning by condition is specified
      ///	 *  </summary>
      ///	 * <param name="previousAmount"> the previous resource Amount </param>
      ///	 
      public virtual void updateAmounts(double previousAmount)
      {
         double amount = getAmount();
         double amountProduced = 0;
         double amountRequired = 0;
         double deltaAmount = previousAmount;

         JDFAttributeMap partMap = getPartMap();
         JDFAttributeMap partMapGood = null; // explicit check map for
         // Condition=good
         JDFAttributeMap partMapCond = null; // explicit check map for
         // Condition=anything

         if (partMap.get(AttributeName.CONDITION) == null)
         {
            partMapGood = new JDFAttributeMap(partMap);
            partMapGood.put(AttributeName.CONDITION, "Good");
            partMapCond = new JDFAttributeMap(partMap);
            partMapCond.put(AttributeName.CONDITION, null);
         }

         if (previousAmount < 0)
         {
            deltaAmount = getAmount();
         }

         // if no output resourcelinks exist, assume that
         bool hasOutputLink = false;
         bool mustWrite = hasAttribute(AttributeName.AMOUNT);

         VElement resLinks = getLinks(getLinkString(), null);
         if (resLinks != null)
         {
            int linkSize = resLinks.Count;

            for (int i = 0; i < linkSize; i++)
            {
               JDFResourceLink rl = (JDFResourceLink)resLinks[i];

               JDFNode n = rl.getParentJDF();
               if (n != null)
               {
                  JDFNode.EnumType typ = EnumType.getEnum(n.getType());
                  if (!JDFNode.EnumType.ProcessGroup.Equals(typ) && !JDFNode.EnumType.Product.Equals(typ))
                  {
                     double rlActualAmount = 0;
                     double rlAmount = 0;
                     bool hasConditionAmount = false;
                     bool hasConditionActualAmount = false;

                     if (partMapGood != null) // first get good only, in case it
                     // exists
                     {
                        rlActualAmount = rl.getActualAmount(partMapCond);
                        rlAmount = rl.getAmount(partMapCond);
                        if (rlActualAmount > 0)
                        {
                           hasConditionActualAmount = true;
                           rlActualAmount = rl.getActualAmount(partMapGood);
                        }
                        if (rlAmount > 0)
                        {
                           hasConditionAmount = true;
                           rlAmount = rl.getAmount(partMapGood);
                        }

                     }

                     if (!hasConditionActualAmount) // if noo virtual good
                        // exists, try complete
                        rlActualAmount = rl.getActualAmount(partMap);

                     if (!hasConditionAmount)
                        rlAmount = rl.getAmount(partMap);

                     if (JDFResourceLink.EnumUsage.Input.Equals(rl.getUsage()))
                     {
                        if (rlActualAmount > 0)
                        {
                           amount -= rlActualAmount;
                           mustWrite = true;
                        }
                        if (rlAmount > 0)
                        {
                           amountRequired += rlAmount;
                           mustWrite = true;
                        }
                     }
                     else
                     {
                        if (rlActualAmount >= 0)
                        {
                           mustWrite = true;
                           amount += rlActualAmount;
                           amountProduced += rlActualAmount;
                        }

                        hasOutputLink = true;
                     }
                  }
               }

               // only update the amounts by the previous values if no onput
               // creates the resource, e.g. consumables
               if (!hasOutputLink)
               {
                  amount += deltaAmount;
               }

               if (mustWrite)
               {
                  if (amount > 0)
                  {
                     setAmount(amount);
                  }

                  if (amountProduced > 0)
                  {
                     setAmountProduced(amountProduced);
                  }

                  if (amountRequired > 0)
                  {
                     setAmountRequired(amountRequired);
                  }
               }
            }
         }
      }

      ///   
      ///	 <summary> * Gets all children from the actual element matching the given conditions also get the non-overwritten elements in
      ///	 * the parents for partitioned resources
      ///	 *  </summary>
      ///	 * <param name="element"> elementname you are searching for </param>
      ///	 * <param name="nameSpaceURI"> nameSpace you are searching for </param>
      ///	 * <param name="mAttrib"> attributes you are lokking for </param>
      ///	 * <param name="bAnd"> if true, a child is only added if it has all attributes specified in Attributes mAttrib </param>
      ///	 * <param name="maxSize"> maximum size of the element vector </param>
      ///	 * <param name="bResolveTarget"> if true, IDRef elements are followed, dummy at this level but needed in JDFElement
      ///	 *  </param>
      ///	 * <returns> VElement - vector with all found elements
      ///	 * 
      ///	 * @default getChildElementVector(null, null, null, true, 0, false) </returns>
      ///	 
      public override VElement getChildElementVector(string element, string nameSpaceURI, JDFAttributeMap mAttrib, bool bAnd, int maxSize, bool bResolveTarget)
      {
         VElement v = null;
         string nodeName = Name;
         bool bAlwaysFit = element == null && nameSpaceURI == null;
         if (bAlwaysFit)
         {
            v = new VElement();

            bool bMapEmpty = mAttrib == null;

            int iSize = 0;
            KElement kElem = getFirstChildElement();

            while (kElem != null)
            {
               if (bResolveTarget && (kElem is JDFRefElement))
               {
                  try
                  {
                     JDFRefElement @ref = (JDFRefElement)kElem;
                     KElement target = @ref.getTarget();

                     // in case there is no element for the REF, target will
                     // be null and will be skipped
                     if ((target != null) && (bMapEmpty || target.includesAttributes(mAttrib, bAnd)))
                     {
                        v.Add(target);
                        iSize++;
                     }
                  }
                  catch (JDFException)
                  {
                     // simply skip invalid refelements
                  }
               }
               else if ((bMapEmpty || kElem.includesAttributes(mAttrib, bAnd)) && !nodeName.Equals(kElem.Name))
               {
                  v.Add(kElem);
                  if (++iSize == maxSize)
                  {
                     break;
                  }
               }
               kElem = kElem.getNextSiblingElement();
            }
         }
         else
         {
            v = base.getChildElementVector(element, nameSpaceURI, mAttrib, bAnd, 0, bResolveTarget);
            // remove partitions
            for (int i = v.Count - 1; i >= 0; i--)
            {
               if (nodeName.Equals((v.item(i)).Name))
               {
                  v.RemoveAt(i);
               }
            }

         }

         if (v.Count == 0 || isWildCard(element))
         {
            // no direct kids, check parents
            KElement n = getParentNode_KElement();
            if (n != null && n.Name.Equals(Name) && (n is JDFResource))
            {
               JDFResource r = (JDFResource)n;
               // recurse into parents
               VElement v2 = r.getChildElementVector(element, nameSpaceURI, mAttrib, bAnd, maxSize, bResolveTarget);
               VString nodeNames = v.getElementNameVector(false);
               for (int i = v2.Count - 1; i >= 0; i--)
               {
                  if (nodeNames.Contains(v2.item(i).LocalName))
                     v2.RemoveAt(i);
               }
               v.AddRange(v2);
            }
         }

         return v;
      }

      ///   
      ///	 <summary> * Gets a list of all partition keys that this resource may be implicitly partitioned by, e.g. RunIndex for
      ///	 * RunList...<br>
      ///	 * gets overridden in subclasses
      ///	 *  </summary>
      ///	 * <returns> Vector of EnumPartIDKey </returns>
      ///	 
      public virtual List<ValuedEnum> getImplicitPartitions()
      {
         return null;
      }

      ///   
      ///	 <summary> * Tests if the given resources are compatible regarding their partitioning.
      ///	 * 
      ///	 * The resources are compatible if the PartIDKeys for the common start sequence of the PartIDKeys vectors are the
      ///	 * same. The resources are not compatible if one has PartIDKeys and the other not.
      ///	 *  </summary>
      ///	 * <param name="other"> the other resource to check.
      ///	 *  </param>
      ///	 * <returns> boolean - <code>true</code> if partitioning of the other resource is compatible with this resource. </returns>
      ///	 

      public virtual bool isPartitioningCompatible(JDFResource other)
      {
         bool isCompatible = false;

         // Node names must be equal.
         if (this.Name.Equals(other.Name))
         {
            isCompatible = isPartitioningCompatible(other.getPartIDKeys());
         }

         return isCompatible;
      }

      ///   
      ///	 <summary> * Tests if the resource is compatible with the given partition keys.
      ///	 * 
      ///	 * The resource is compatible if all PartIDKeys in vsPartitions are contained in this, regardless of sequence The
      ///	 * resource is not compatible if one has PartIDKeys and the other not.
      ///	 *  </summary>
      ///	 * <param name="vsPartitions"> the given partition keys to compare
      ///	 *  </param>
      ///	 * <returns> boolean - <code>true</code> if partitioning is compatible with this resource. </returns>
      ///	 
      public virtual bool isPartitioningCompatible(VString vsPartitions)
      {
         if (vsPartitions == null || vsPartitions.IsEmpty())
            return true;
         VString vsPartIDKeysThis = getPartIDKeys();
         if (vsPartIDKeysThis == null || vsPartIDKeysThis.IsEmpty())
            return false;
         return vsPartIDKeysThis.ContainsAll(vsPartitions);
      }

      ///   
      ///	 <summary> * Tests if a spawn of the given partition of the resource is allowed (by means of the JDF specification).
      ///	 *  </summary>
      ///	 * <returns> boolean - true if spawn is allowed. </returns>
      ///	 

      public virtual bool isSpawnAllowed()
      {
         JDFAttributeMap amPartMap = getPartMap();
         bool isSpawnAllowed = true;

         if (amPartMap.Count > 0) // tuning
         {
            // Find first part ID key in amPartMap.
            string strPartIDKey = null;
            VString vsPartKeys = this.getPartIDKeys();
            int nPartKeys = vsPartKeys.Count;

            // find a partIDKey, which is in the partMap too (start from the
            // end)
            for (int i = nPartKeys - 1; i >= 0 && strPartIDKey == null; i--)
            {
               string str = vsPartKeys.stringAt(i);

               if (amPartMap.ContainsKey(str))
               {
                  strPartIDKey = str;
               }
            }

            // Check found part ID key.
            if (strPartIDKey != null)
            {
               // values not allowed according to JDF 1.2, 3.8.2.4
               // || (strPartIDKey.equals (AttributeName.SORTING))
               // || (strPartIDKey.equals (AttributeName.SORTAMOUNT))
               if ((strPartIDKey.Equals(JDFConstants.PARTIDKEY_DOCINDEX)) || (strPartIDKey.Equals(JDFConstants.PARTIDKEY_DOCCOPIES)) || (strPartIDKey.Equals(JDFConstants.PARTIDKEY_DOCRUNINDEX)) || (strPartIDKey.Equals(JDFConstants.PARTIDKEY_DOCSHEETINDEX)) || (strPartIDKey.Equals(JDFConstants.PARTIDKEY_RUNINDEX)) || (strPartIDKey.Equals(JDFConstants.PARTIDKEY_SHEETINDEX)))
               {
                  isSpawnAllowed = false;
               }
            }
         }

         return isSpawnAllowed;
      }

      ///   
      ///	 <summary> * Gets of 'this' child Contact element, optionally creates it, if it doesn't exist.
      ///	 *  </summary>
      ///	 * <returns> JDFContact - the matching Contact element </returns>
      ///	 
      public virtual JDFContact getCreateContact()
      {
         return (JDFContact)getCreateElement(ElementName.CONTACT, null, 0);
      }

      ///   
      ///	 <summary> * Gets of 'this' an existing child Contact element
      ///	 *  </summary>
      ///	 * <returns> JDFContact the matching Contact element </returns>
      ///	 
      public virtual JDFContact getContact()
      {
         return (JDFContact)getElement(ElementName.CONTACT, null, 0);
      }

      ///   
      ///	 <summary> * Appends new Contact element to the end of 'this'
      ///	 *  </summary>
      ///	 * <returns> JDFContact - newly created child Contact element </returns>
      ///	 
      public virtual JDFContact appendContact()
      {
         return (JDFContact)appendElementN(ElementName.CONTACT, 1, null);
      }

      ///   
      ///	 <summary> * Gets of 'this' child Location element, optionally creates it, if it doesn't exist.
      ///	 *  </summary>
      ///	 * <returns> JDFLocation - the matching Location element </returns>
      ///	 
      public virtual JDFLocation getCreateLocationElement()
      {
         return (JDFLocation)getCreateElement(ElementName.LOCATION, null, 0);
      }

      ///   
      ///	 <summary> * Gets of 'this' an existing child Location element
      ///	 *  </summary>
      ///	 * <returns> JDFLocation - element Location </returns>
      ///	 
      public virtual JDFLocation getLocationElement()
      {
         return (JDFLocation)getElement(ElementName.LOCATION, null, 0);
      }

      ///   
      ///	 <summary> * Appends new child Location element to the end of 'this'
      ///	 *  </summary>
      ///	 * <returns> JDFLocation - newly created child Location element </returns>
      ///	 
      public virtual JDFLocation appendLocationElement()
      {
         return (JDFLocation)appendElementN(ElementName.LOCATION, 1, null);
      }

      ///   
      ///	 <summary> * create a sourceresource element that pints to source
      ///	 *  </summary>
      ///	 * <param name="source"> the resource to reference </param>
      ///	 * <returns> JDFSourceResource - the element </returns>
      ///	 
      public virtual JDFSourceResource createSourceResource(JDFResource source)
      {
         JDFSourceResource sr = appendSourceResource();
         sr.refElement(source);
         return sr;
      }

      ///   
      ///	 <summary> * appends a new SourceResource element
      ///	 *  </summary>
      ///	 * <returns> JDFSourceResource - the new sourceresource </returns>
      ///	 
      public virtual JDFSourceResource appendSourceResource()
      {
         return (JDFSourceResource)appendElement(ElementName.SOURCERESOURCE, null);
      }

      ///   
      ///	 <summary> * gets an existing SourceResource element
      ///	 *  </summary>
      ///	 * <param name="i"> the i'th sourceResource to get, 0=first etc. </param>
      ///	 * <returns> JDFSourceResource - the sourceresource </returns>
      ///	 
      public virtual JDFSourceResource getSourceResource(int i)
      {
         return (JDFSourceResource)getElement(ElementName.SOURCERESOURCE, null, i);
      }

      ///   
      ///	 <summary> * Gets of 'this' the iSkip-th IdentificationField element, optionally creates it, if it doesn't exist. If iSkip is
      ///	 * more than one larger than the number of elements, only one will be created and appended.
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of child IdentificationField elements to skip </param>
      ///	 * <returns> JDFIdentificationField - the matching IdentificationField element
      ///	 * 
      ///	 *         default: getIdentificationField(0) </returns>
      ///	 
      public virtual JDFIdentificationField getCreateIdentificationField(int iSkip)
      {
         return (JDFIdentificationField)getCreateElement(ElementName.IDENTIFICATIONFIELD, null, iSkip);
      }

      ///   
      ///	 <summary> * Gets of 'this' the iSkip-th child IdentificationField element
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of child IdentificationField elements to skip, default=0 </param>
      ///	 * <returns> JDFIdentificationField - the matching IdentificationField element
      ///	 * 
      ///	 * @default getIdentificationField(0) </returns>
      ///	 
      public virtual JDFIdentificationField getIdentificationField(int iSkip)
      {
         return (JDFIdentificationField)getElement(ElementName.IDENTIFICATIONFIELD, null, iSkip);
      }

      ///   
      ///	 <summary> * Appends new child IdentificationField element to the end of 'this'
      ///	 *  </summary>
      ///	 * <returns> JDFIdentificationField - newly created child IdentificationField element </returns>
      ///	 
      public virtual JDFIdentificationField appendIdentificationField()
      {
         return (JDFIdentificationField)appendElement(ElementName.IDENTIFICATIONFIELD, null);
      }

      ///   
      ///	 <summary> * return the PartMap of ./Identical/Part, or null if it does not exist
      ///	 *  </summary>
      ///	 * <returns> JDFAttributeMapthe - map of the part in the identical element </returns>
      ///	 
      public virtual JDFAttributeMap getIdenticalMap()
      {
         JDFIdentical ident = getIdentical();
         if (ident == null)
         {
            return null;
         }
         return ident.getPartMap();
      }

      ///   
      ///	 <summary> * get the identical element,
      ///	 *  </summary>
      ///	 * <returns> JDFIdentical - the identical element, null if noen exists </returns>
      ///	 
      public virtual JDFIdentical getIdentical()
      {

         return (JDFIdentical)getElement(ElementName.IDENTICAL, null, 0);
      }

      ///   
      ///	 <summary> * get or create the identical element,
      ///	 *  </summary>
      ///	 * <returns> JDFIdentical - the identical element </returns>
      ///	 
      public virtual JDFIdentical getCreateIdentical()
      {

         return (JDFIdentical)getCreateElement(ElementName.IDENTICAL, null, 0);
      }

      ///   
      ///	 <summary> * append an identical element,
      ///	 *  </summary>
      ///	 * <returns> JDFIdentical - the identical element </returns>
      ///	 * <exception cref="JDFException"> if an Identical already exists </exception>
      ///	 
      public virtual JDFIdentical appendIdentical()
      {
         return (JDFIdentical)appendElementN(ElementName.IDENTICAL, 1, null);
      }

      ///   
      ///	 <summary> * Sets the 1st-nth element as identical to the 0th elemennt ov vPartMap i.e. the partition leaves that match
      ///	 * vPartMap[1]...vPartMap[size-1] are set identical to vPartMap[0]
      ///	 *  </summary>
      ///	 * <param name="vPartMap"> VJDFAttributeMap to correspond to </param>
      ///	 
      public virtual void setIdentical(VJDFAttributeMap vPartMap)
      {
         if (vPartMap == null || vPartMap.Count < 2)
         {
            return;
         }
         JDFResource target = getPartition(vPartMap[0], null);
         for (int i = 1; i < vPartMap.Count; i++)
         {
            JDFResource leaf = getPartition(vPartMap[i], null);
            if (leaf != null)
            {
               leaf.setIdentical(target);
            }
         }
      }

      ///   
      ///	 <summary> * Appends new child Identifical element that refers to target also removes all subelements and attributes If an
      ///	 * identical already exists, the part element is overwritten
      ///	 *  </summary>
      ///	 * <param name="target"> the resource leaf that this leaf should reference as identical
      ///	 *  </param>
      ///	 
      public virtual void setIdentical(JDFResource target)
      {
         if (target == null)
         {
            throw new JDFException("setIdentical: cannot create Identical in null element");
         }
         if (isResourceRoot())
         {
            throw new JDFException("setIdentical: cannot create Identical in root");
         }
         if (target.getResourceRoot() != getResourceRoot())
         {
            throw new JDFException("setIdentical: Identical must be in the same resource");
         }

         JDFAttributeMap targetMap = target.getPartMap();
         JDFAttributeMap thisPart = getPartMap();
         if (thisPart.Equals(targetMap))
         {
            return; // dont set to this
         }

         JDFAttributeMap thisAllMap = getAttributeMap();
         if (thisAllMap != null)
         {
            thisAllMap.removeKeys(thisPart.Keys);
            removeAttributes(thisAllMap.getKeys());
         }

         removeChildren(null, null, null);

         JDFIdentical ident = (JDFIdentical)appendElement(ElementName.IDENTICAL);
         ident.setPartMap(targetMap);
      }

      ///   
      ///	 <summary> * Gets of 'this' the iSkip-th QualityControlResult element, optionally creates it, if it doesn't exist. If iSkip is
      ///	 * more than one larger that the number of elements, only one will be created and appended.
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of child QualityControlResult elements to skip </param>
      ///	 * <returns> JDFQualityControlResult - the matching QualityControlResult element
      ///	 * 
      ///	 * @default getCreateQualityControlResult(0) </returns>
      ///	 
      public virtual JDFQualityControlResult getCreateQualityControlResult(int iSkip)
      {
         return (JDFQualityControlResult)getCreateElement(ElementName.QUALITYCONTROLRESULT, null, iSkip);
      }

      ///   
      ///	 <summary> * Gets of 'this' the iSkip-th child QualityControlResult element
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of child QualityControlResult elements to skip, default=0 </param>
      ///	 * <returns> JDFQualityControlResult the matching QualityControlResult element
      ///	 * 
      ///	 * @default getQualityControlResult(0) </returns>
      ///	 
      public virtual JDFQualityControlResult getQualityControlResult(int iSkip)
      {
         return (JDFQualityControlResult)getElement(ElementName.QUALITYCONTROLRESULT, null, iSkip);
      }

      ///   
      ///	 <summary> * Appends new child QualityControlResult element to the end of 'this'
      ///	 *  </summary>
      ///	 * <returns> JDFQualityControlResult - newly created child QualityControlResult element </returns>
      ///	 
      public virtual JDFQualityControlResult appendQualityControlResult()
      {
         return (JDFQualityControlResult)appendElement(ElementName.QUALITYCONTROLRESULT, null);
      }

      // **************************************************************************
      // ********
      // ********************** getters, setters, validators
      // ******************************
      // **************************************************************************
      // ********

      ///   
      ///	 <summary> * Gets of 'this' the iSkip-th child Update element
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of child Update elements to skip </param>
      ///	 * <returns> JDFResource the matching Resource Update element </returns>
      ///	 * @deprecated updates never really took off in JDF
      ///	 * 
      ///	 * @default getUpdate(0) 
      ///	 
      [Obsolete("updates never really took off in JDF")]
      public virtual JDFResource getUpdate(int iSkip)
      {
         JDFResource updateResource = null;
         KElement updateElement = null;

         updateElement = getElement(getUpdateName(), null, iSkip);
         if (updateElement != null)
         {
            updateResource = (JDFResource)updateElement;
         }

         return updateResource;
      }

      ///   
      ///	 <summary> * Gets of 'this' child Update element with an appropriate UpdateID
      ///	 *  </summary>
      ///	 * @deprecated updates never really took off in JDF 
      ///	 * <param name="updateID"> UpdateID of the element to get </param>
      ///	 * <returns> JDFResource the matching Update element </returns>
      ///	 
      [Obsolete("updates never really took off in JDF")]
      public virtual JDFResource getUpdate(string updateID)
      {
         JDFResource updateResource = null;
         KElement updateElement = null;

         updateElement = getChildWithAttribute(getUpdateName(), AttributeName.UPDATEID, null, updateID, 0, true);

         if (updateElement != null)
         {
            updateResource = (JDFResource)updateElement;
         }

         return updateResource;
      }

      ///   
      ///	 <summary> * Gets of 'this' a vector of all Update elements
      ///	 *  </summary>
      ///	 * @deprecated updates never really took off in JDF 
      ///	 * <returns> VElement vector of all Resource Update elements in 'this' </returns>
      ///	 
      [Obsolete("updates never really took off in JDF")]
      public virtual VElement getUpdateVector()
      {
         return getChildElementVector(getUpdateName(), null, null, true, 0, false);
      }

      ///   
      ///	 <summary> * Removes of 'this' child Update element with an appropriate UpdateID
      ///	 *  </summary>
      ///	 * @deprecated updates never really took off in JDF 
      ///	 * <param name="updateID"> UpdateID of the element to remove </param>
      ///	 
      [Obsolete("updates never really took off in JDF")]
      public virtual void removeUpdate(string updateID)
      {
         getUpdate(updateID).deleteNode();
      }

      ///   
      ///	 <summary> * Removes of 'this' the iSkip-th child Update element
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of child Update elements to skip
      ///	 *  </param>
      ///	 * @deprecated updates never really took off in JDF
      ///	 * @default removeUpdate(0) 
      ///	 
      [Obsolete("updates never really took off in JDF")]
      public virtual void removeUpdate(int iSkip)
      {
         getUpdate(iSkip).deleteNode();
      }

      ///   
      ///	 <summary> * Appends to 'this' a resource Update element with an appropriate UpdateID
      ///	 *  </summary>
      ///	 * <param name="updateID"> updateID of the new Update element </param>
      ///	 * <returns> JDFResource newly created Resource Update element
      ///	 *  </returns>
      ///	 * <exception cref="JDFException"> if Update element with such ID already exists
      ///	 *  </exception>
      ///	 * @deprecated updates never really took off in JDF
      ///	 * @default appendUpdate(JDFConstants.EMPTYSTRING) 
      ///	 
      [Obsolete("updates never really took off in JDF")]
      public virtual JDFResource appendUpdate(string updateID)
      {
         string uid = updateID;
         JDFResource r = null;
         if (isWildCard(updateID))
         {
            uid = "Up" + uniqueID(0);
         }
         else
         {
            r = getUpdate(updateID);
            if (r != null)
            {
               throw new JDFException("JDFResource.appendUpdate: update with id = " + updateID + " exists!");
            }
         }

         KElement k = null;
         k = appendElement(getUpdateName(), null);
         if (k != null)
         {
            r = (JDFResource)k;
            r.setUpdateID(uid);
         }

         return r;
      }

      ///   
      ///	 <summary> * Gets of 'this' the number of child Update elements
      ///	 *  </summary>
      ///	 * @deprecated updates never really took off in JDF 
      ///	 * <returns> int - number of Update elements in 'this' </returns>
      ///	 
      [Obsolete("updates never really took off in JDF")]
      public virtual int numUpdates()
      {
         return numChildElements(getUpdateName(), null);
      }

      ///   
      ///	 <summary> * Tests, whether in 'this' any child Update elements already exist
      ///	 *  </summary>
      ///	 * @deprecated updates never really took off in JDF 
      ///	 * <returns> boolean - true, if 'this' has already one or more Update elements </returns>
      ///	 
      [Obsolete("updates never really took off in JDF")]
      public virtual bool hasUpdate()
      {
         return numUpdates() > 0;
      }

      ///   
      ///	 <summary> * Gets the qualified node name of resource Update based on 'this'
      ///	 *  </summary>
      ///	 * @deprecated updates never really took off in JDF 
      ///	 * <returns> String - the mangled node name </returns>
      ///	 
      [Obsolete("updates never really took off in JDF")]
      public virtual string getUpdateName()
      {
         return Name + JDFConstants.UPDATE;
      }

      ///   
      ///	 <summary> * Sets attribute AgentName
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setAgentName(string @value)
      {
         setAttribute(AttributeName.AGENTNAME, @value);
      }

      ///   
      ///	 <summary> * Gets string attribute AgentName
      ///	 *  </summary>
      ///	 * <returns> String - the attribute value </returns>
      ///	 
      public virtual string getAgentName()
      {
         return getAttribute(AttributeName.AGENTNAME);
      }

      ///   
      ///	 <summary> * Sets attribute AgentVersion
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setAgentVersion(string @value)
      {
         setAttribute(AttributeName.AGENTVERSION, @value);
      }

      ///   
      ///	 <summary> * Gets string attribute AgentVersion
      ///	 *  </summary>
      ///	 * <returns> String the - attribute value </returns>
      ///	 
      public virtual string getAgentVersion()
      {
         return getAttribute(AttributeName.AGENTVERSION);
      }

      ///   
      ///	 <summary> * Sets attribute AlternateBrand
      ///	 *  </summary>
      ///	 * <param name="value"> value to set the attribute to </param>
      ///	 
      public virtual void setAlternateBrand(string @value)
      {
         setAttribute(AttributeName.ALTERNATEBRAND, @value);
      }

      ///   
      ///	 <summary> * Gets string attribute AlternateBrand
      ///	 *  </summary>
      ///	 * <returns> String - the attribute value </returns>
      ///	 
      public virtual string getAlternateBrand()
      {
         return getAttribute(AttributeName.ALTERNATEBRAND);
      }

      ///   
      ///	 <summary> * Sets attribute Amount
      ///	 *  </summary>
      ///	 * <param name="amount"> value to set the attribute to </param>
      ///	 
      public virtual void setAmount(double amount)
      {
         setAttribute(AttributeName.AMOUNT, amount, null);
      }

      ///   
      ///	 <summary> * Gets double attribute Amount
      ///	 *  </summary>
      ///	 * <returns> double - the attribute value </returns>
      ///	 
      public virtual double getAmount()
      {
         return getRealAttribute(AttributeName.AMOUNT, null, 0.0);
      }

      ///   
      ///	 <summary> * Sets attribute AmountProduced
      ///	 *  </summary>
      ///	 * <param name="value"> value to set the attribute to </param>
      ///	 
      public virtual void setAmountProduced(double @value)
      {
         setAttribute(AttributeName.AMOUNTPRODUCED, @value, null);
      }

      ///   
      ///	 <summary> * Gets double attribute AmountProduced
      ///	 *  </summary>
      ///	 * <returns> double - the attribute value </returns>
      ///	 
      public virtual double getAmountProduced()
      {
         return getRealAttribute(AttributeName.AMOUNTPRODUCED, null, 0.0);
      }

      ///   
      ///	 <summary> * append an empty GeneralID
      ///	 *  </summary>
      ///	 * <returns> the newly created GeneralID </returns>
      ///	 
      public virtual JDFGeneralID appendGeneralID()
      {
         return (JDFGeneralID)appendElement(ElementName.GENERALID, null);
      }

      ///   
      ///	 <summary> * append a GeneralID with idValue, duplicate entries are retained
      ///	 *  </summary>
      ///	 * <param name="idUsage"> the IDUsage attribute of the generalID </param>
      ///	 * <param name="idValue"> the IDValue attribute of the generalID </param>
      ///	 * <returns> the newly created GeneralID </returns>
      ///	 
      public virtual JDFGeneralID appendGeneralID(string idUsage, string idValue)
      {
         JDFGeneralID gid = (JDFGeneralID)appendElement(ElementName.GENERALID);
         gid.setIDValue(idValue);
         gid.setIDUsage(idUsage);
         return gid;
      }

      ///   
      ///	 <summary> * gets attribute GeneralID
      ///	 *  </summary>
      ///	 * <param name="i"> get the i'th element that fits </param>
      ///	 * <returns> the attribute value </returns>
      ///	 
      public virtual JDFGeneralID getGeneralID(int i)
      {
         return (JDFGeneralID)getElement(ElementName.GENERALID, null, i);
      }

      ///   
      ///	 <summary> * Creates or Updates a GeneralID with the IDUsage idUsage and IDValue=idValue all entries with a duplicate idUsage
      ///	 * are removed
      ///	 *  </summary>
      ///	 * <param name="idUsage"> usage to set the attribute to </param>
      ///	 * <param name="idValue"> value to set the attribute to </param>
      ///	 
      public virtual void setGeneralID(string idUsage, string idValue)
      {
         JDFGeneralID gid = null;

         VElement v = getChildElementVector_JDFElement(ElementName.GENERALID, null, new JDFAttributeMap(AttributeName.IDUSAGE, idUsage), true, 0, true);
         if (v.Count == 0)
         {
            gid = (JDFGeneralID)appendElement(ElementName.GENERALID);
         }
         else if (v.Count >= 1)
         {
            gid = (JDFGeneralID)v[0];

            for (int i = 1; i < v.Count; i++)
            {
               // remove any duplicates
               (v[i]).deleteNode();
            }
         }

         if (gid != null)
         {
            gid.setIDValue(idValue);
            gid.setIDUsage(idUsage);
         }
      }

      ///   
      ///	 <summary> * removes GeneralID with the IDUsage idUsage
      ///	 *  </summary>
      ///	 * <param name="idUsage"> value to set the attribute to </param>
      ///	 
      public virtual void removeGeneralID(string idUsage)
      {
         VElement v = getChildElementVector_JDFElement(ElementName.GENERALID, null, new JDFAttributeMap(AttributeName.IDUSAGE, idUsage), true, 0, true);
         for (int i = 0; i < v.Count; i++)
         {
            (v[i]).deleteNode();
         }
      }

      ///   
      ///	 <summary> * Gets IDValue of the GeneralID with IDUsage=idUsage null, if none exists
      ///	 *  </summary>
      ///	 * <returns> double the attribute value </returns>
      ///	 
      public virtual string getGeneralID(string idUsage)
      {
         VElement v = getChildElementVector(ElementName.GENERALID, null, new JDFAttributeMap(AttributeName.IDUSAGE, idUsage), true, 0, true);
         if (v.Count == 0)
         {
            return null;
         }
         JDFGeneralID gid = (JDFGeneralID)v[0];
         return gid.getIDValue();
      }

      ///   
      ///	 <summary> * Sets attribute AmountRequired
      ///	 *  </summary>
      ///	 * <param name="value"> value to set the attribute to </param>
      ///	 
      public virtual void setAmountRequired(double @value)
      {
         setAttribute(AttributeName.AMOUNTREQUIRED, @value, null);
      }

      ///   
      ///	 <summary> * Gets double attribute AmountRequired
      ///	 *  </summary>
      ///	 * <returns> double - the attribute value </returns>
      ///	 
      public virtual double getAmountRequired()
      {
         return getRealAttribute(AttributeName.AMOUNTREQUIRED, null, 0.0);
      }

      ///   
      ///	 <summary> * Sets attribute Author
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setAuthor(string @value)
      {
         setAttribute(AttributeName.AUTHOR, @value);
      }

      ///   
      ///	 <summary> * Gets string attribute Author
      ///	 *  </summary>
      ///	 * <returns> String - the attribute value </returns>
      ///	 
      public virtual string getAuthor()
      {
         return getAttribute(AttributeName.AUTHOR);
      }

      ///   
      ///	 <summary> * Sets attribute BatchID
      ///	 *  </summary>
      ///	 * <param name="value"> value to set the attribute to </param>
      ///	 
      public virtual void setBatchID(string @value)
      {
         setAttribute(AttributeName.BATCHID, @value);
      }

      ///   
      ///	 <summary> * Gets string attribute BatchID
      ///	 *  </summary>
      ///	 * <returns> String - the attribute value </returns>
      ///	 
      public virtual string getBatchID()
      {
         return getAttribute(AttributeName.BATCHID);
      }

      ///   
      ///	 <summary> * Sets attribute BinderySignatureName
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setBinderySignatureName(string @value)
      {
         setAttribute(AttributeName.BINDERYSIGNATURENAME, @value);
      }

      ///   
      ///	 <summary> * Gets string attribute BinderySignatureName
      ///	 *  </summary>
      ///	 * <returns> String - the attribute value </returns>
      ///	 
      public virtual string getBinderySignatureName()
      {
         return getAttribute(AttributeName.BINDERYSIGNATURENAME, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * Sets attribute BlockName
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setBlockName(string @value)
      {
         setAttribute(AttributeName.BLOCKNAME, @value);
      }

      ///   
      ///	 <summary> * Gets string attribute BlockName
      ///	 *  </summary>
      ///	 * <returns> String - the attribute value </returns>
      ///	 
      public virtual string getBlockName()
      {
         return getAttribute(AttributeName.BLOCKNAME, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * Sets attribute Brand
      ///	 *  </summary>
      ///	 * <param name="value"> value to set the attribute to </param>
      ///	 
      public virtual void setBrand(string @value)
      {
         setAttribute(AttributeName.BRAND, @value);
      }

      ///   
      ///	 <summary> * Gets string attribute Brand
      ///	 *  </summary>
      ///	 * <returns> String - the attribute value </returns>
      ///	 
      public virtual string getBrand()
      {
         return getAttribute(AttributeName.BRAND);
      }

      ///   
      ///	 <summary> * Sets attribute BundleItemIndex
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setBundleItemIndex(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.BUNDLEITEMINDEX, @value.ToString());
      }

      ///   
      ///	 <summary> * Gets range attribute BundleItemIndex
      ///	 *  </summary>
      ///	 * <returns> JDFIntegerRangeList - the attribute value </returns>
      ///	 
      public virtual JDFIntegerRangeList getBundleItemIndex()
      {
         string strAttrName = getAttribute(AttributeName.BUNDLEITEMINDEX, null, null);
         try
         {
            return new JDFIntegerRangeList(strAttrName);
         }
         catch (FormatException)
         {
            // do nothing
         }
         return null;
      }

      ///   
      ///	 <summary> * Sets attribute CatalogDetails
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setCatalogDetails(string @value)
      {
         setAttribute(AttributeName.CATALOGDETAILS, @value);
      }

      ///   
      ///	 <summary> * Gets string attribute CatalogDetails
      ///	 *  </summary>
      ///	 * <returns> String - the attribute value </returns>
      ///	 
      public virtual string getCatalogDetails()
      {
         return getAttribute(AttributeName.CATALOGDETAILS);
      }

      ///   
      ///	 <summary> * Sets attribute CatalogID
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setCatalogID(string @value)
      {
         setAttribute(AttributeName.CATALOGID, @value);
      }

      ///   
      ///	 <summary> * Gets string attribute CatalogID
      ///	 *  </summary>
      ///	 * <returns> String - the attribute value </returns>
      ///	 
      public virtual string getCatalogID()
      {
         return getAttribute(AttributeName.CATALOGID);
      }

      ///   
      ///	 <summary> * Sets attribute CellIndex
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setCellIndex(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.CELLINDEX, @value.ToString());
      }

      ///   
      ///	 <summary> * Gets range attribute CellIndex
      ///	 *  </summary>
      ///	 * <returns> JDFIntegerRangeList - the attribute value </returns>
      ///	 
      public virtual JDFIntegerRangeList getCellIndex()
      {
         string strAttrName = JDFConstants.EMPTYSTRING;
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.CELLINDEX, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFIntegerRangeList(strAttrName);
         }
         catch (FormatException)
         {
            // do nothing
         }
         return nPlaceHolder;
      }

      ///   
      ///	 <summary> * Sets attribute Condition
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setCondition(string @value)
      {
         setAttribute(AttributeName.CONDITION, @value);
      }

      ///   
      ///	 <summary> * Gets string attribute Condition
      ///	 *  </summary>
      ///	 * <returns> String - the attribute value </returns>
      ///	 
      public virtual string getCondition()
      {
         return getAttribute(AttributeName.CONDITION);
      }

      ///   
      ///	 <summary> * Sets attribute DocCopies
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setDocCopies(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.DOCCOPIES, @value.ToString());
      }

      ///   
      ///	 <summary> * Gets range attribute DocCopies
      ///	 *  </summary>
      ///	 * <returns> JDFIntegerRangeList the attribute value </returns>
      ///	 
      public virtual JDFIntegerRangeList getDocCopies()
      {
         string strAttrName = JDFConstants.EMPTYSTRING;
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.DOCCOPIES, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFIntegerRangeList(strAttrName);
         }
         catch (FormatException)
         {
            // do nothing
         }
         return nPlaceHolder;
      }

      ///   
      ///	 <summary> * Sets attribute DocIndex
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setDocIndex(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.DOCINDEX, @value.ToString());
      }

      ///   
      ///	 <summary> * Gets range attribute DocIndex
      ///	 *  </summary>
      ///	 * <returns> JDFIntegerRangeList - the attribute value </returns>
      ///	 
      public virtual JDFIntegerRangeList getDocIndex()
      {
         string strAttrName = JDFConstants.EMPTYSTRING;
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.DOCINDEX, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFIntegerRangeList(strAttrName);
         }
         catch (FormatException)
         {
            // do nothing
         }
         return nPlaceHolder;
      }

      ///   
      ///	 <summary> * Sets attribute DeliveryUnit
      ///	 *  </summary>
      ///	 * <param name="iUnit"> a value between 0 and 9 to set DeliveryUnit<iUnit> </param>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setDeliveryUnit(int iUnit, string @value)
      {
         if (iUnit < 0 || iUnit > 9)
         {
            throw new JDFException("setDeliveryUnit: invalid iUnit: " + Convert.ToString(iUnit));
         }

         setAttribute(AttributeName.DELIVERYUNIT + Convert.ToString(iUnit), @value);
      }

      ///   
      ///	 <summary> * Gets attribute DeliveryUnit
      ///	 *  </summary>
      ///	 * <param name="iUnit"> a value between 0 and 9 to set DeliveryUnit<iUnit>
      ///	 *  </param>
      ///	 * <returns> String - the attribute value </returns>
      ///	 
      public virtual string getDeliveryUnit(int iUnit)
      {
         if (iUnit < 0 || iUnit > 9)
         {
            throw new JDFException("getDeliveryUnit: invalid iUnit: " + Convert.ToString(iUnit));
         }
         return getAttribute(AttributeName.DELIVERYUNIT + Convert.ToString(iUnit), null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * Sets attribute DocRunIndex
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setDocRunIndex(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.DOCRUNINDEX, @value.ToString());
      }

      ///   
      ///	 <summary> * Gets range attribute DocRunIndex
      ///	 *  </summary>
      ///	 * <returns> JDFIntegerRangeList the attribute value </returns>
      ///	 
      public virtual JDFIntegerRangeList getDocRunIndex()
      {
         string strAttrName = JDFConstants.EMPTYSTRING;
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.DOCRUNINDEX, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFIntegerRangeList(strAttrName);
         }
         catch (FormatException)
         {
            // do nothing
         }
         return nPlaceHolder;
      }

      ///   
      ///	 <summary> * Sets attribute DocSheetIndex
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setDocSheetIndex(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.DOCSHEETINDEX, @value.ToString());
      }

      ///   
      ///	 <summary> * Gets range attribute DocSheetIndex
      ///	 *  </summary>
      ///	 * <returns> JDFIntegerRangeList - the attribute value </returns>
      ///	 
      public virtual JDFIntegerRangeList getDocSheetIndex()
      {
         string strAttrName = JDFConstants.EMPTYSTRING;
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.DOCSHEETINDEX, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFIntegerRangeList(strAttrName);
         }
         catch (FormatException)
         {
            // do nothing
         }
         return nPlaceHolder;
      }

      ///   
      ///	 <summary> * Sets attribute FountainNumber
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setFountainNumber(int @value)
      {
         int i = @value; // new int(@value);
         setAttribute(AttributeName.FOUNTAINNUMBER, i.ToString());
      }

      ///   
      ///	 <summary> * Gets integer attribute FountainNumber
      ///	 *  </summary>
      ///	 * <returns> int - the attribute value </returns>
      ///	 
      public virtual int getFountainNumber()
      {
         return getIntAttribute(AttributeName.FOUNTAINNUMBER, null, 0);
      }

      ///   
      ///	 <summary> * Sets attribute ItemNames
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setItemNames(string @value)
      {
         setAttribute(AttributeName.ITEMNAMES, @value);
      }

      ///   
      ///	 <summary> * Gets string attribute ItemNames
      ///	 *  </summary>
      ///	 * <returns> String - the attribute value </returns>
      ///	 
      public virtual string getItemNames()
      {
         return getAttribute(AttributeName.ITEMNAMES, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * Sets attribute LayerIDs
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setLayerIDs(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.LAYERIDS, @value.ToString());
      }

      ///   
      ///	 <summary> * Gets range attribute LayerIDs
      ///	 *  </summary>
      ///	 * <returns> JDFIntegerRangeList - the attribute value </returns>
      ///	 
      public virtual JDFIntegerRangeList getLayerIDs()
      {
         string strAttrName = JDFConstants.EMPTYSTRING;
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.LAYERIDS, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFIntegerRangeList(strAttrName);
         }
         catch (FormatException)
         {
            // do nothing
         }
         return nPlaceHolder;
      }

      ///   
      ///	 <summary> * Sets attribute Location
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setLocation(string @value)
      {
         setAttribute(AttributeName.LOCATION, @value);
      }

      ///   
      ///	 <summary> * Gets string attribute Location
      ///	 *  </summary>
      ///	 * <returns> - String the attribute value </returns>
      ///	 
      public virtual string getLocation()
      {
         return getAttribute(AttributeName.LOCATION, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * Sets attribute Locked
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setLocked(bool @value)
      {
         string localLock = getAttribute_KElement(AttributeName.LOCKED, null, null);
         if (localLock != null)
         {
            bool b = localLock.ToUpper().Equals((JDFConstants.TRUE).ToUpper());
            if (b == @value)
            {
               return; // don't reset to current value - NOP
            }
            removeAttribute(AttributeName.LOCKED); // remove any value so that
            // we only get a true from
            // an inherited value
         }
         if (@value || getLocked())
         { // don't reset the default many times, but add false if true is
            // inherited
            setAttribute(AttributeName.LOCKED, @value, null);
         }
      }

      ///   
      ///	 <summary> * Gets boolean attribute Locked; defaults to false.
      ///	 *  </summary>
      ///	 * <returns> boolean the attribute value </returns>
      ///	 
      public virtual bool getLocked()
      {
         return getBoolAttribute(AttributeName.LOCKED, null, false);
      }

      /// <summary>
      /// Sets attribute Manufacturer.
      /// </summary>
      /// <param name="value">The value to set the attribute to.</param>
      public virtual void setManufacturer(string value)
      {
         setAttribute(AttributeName.MANUFACTURER, value);
      }
      /// <summary>
      /// Gets string attribute Manufacturer.
      /// </summary>
      /// <returns>String - the attribute value.</returns>
      public virtual string getManufacturer()
      {
         return getAttribute(AttributeName.MANUFACTURER, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * Sets attribute NoOp
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setNoOp(bool @value)
      {
         setAttribute(AttributeName.NOOP, @value, null);
      }

      ///   
      ///	 <summary> * Gets boolean attribute NoOp; defaults to false
      ///	 *  </summary>
      ///	 * <returns> boolean - the attribute value </returns>
      ///	 
      public virtual bool getNoOp()
      {
         return getBoolAttribute(AttributeName.NOOP, null, false);
      }

      ///   
      ///	 <summary> * Sets attribute Option
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setOption(string @value)
      {
         setAttribute(AttributeName.OPTION, @value);
      }

      ///   
      ///	 <summary> * Gets string attribute Option
      ///	 *  </summary>
      ///	 * <returns> String - the attribute value </returns>
      ///	 
      public virtual string getOption()
      {
         return getAttribute(AttributeName.OPTION, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * Sets attribute PageNumber
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setPageNumber(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.PAGENUMBER, @value.ToString());
      }

      ///   
      ///	 <summary> * Gets range attribute PageNumber
      ///	 *  </summary>
      ///	 * <returns> JDFIntegerRangeList - the attribute value </returns>
      ///	 
      public virtual JDFIntegerRangeList getPageNumber()
      {
         string strAttrName = JDFConstants.EMPTYSTRING;
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.PAGENUMBER, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFIntegerRangeList(strAttrName);
         }
         catch (FormatException)
         {
            // do nothing
         }
         return nPlaceHolder;
      }

      ///   
      ///	 <summary> * Adds a new PartIDKey to the root first checks for existence
      ///	 *  </summary>
      ///	 * <param name="partType"> new PartIDKey to add
      ///	 *  </param>
      ///	 * <exception cref="JDFException"> if here is an attempt to add implicit partition </exception>
      ///	 
      protected internal virtual void addPartIDKey(EnumPartIDKey partType)
      {
         string s = partType.getName();
         JDFResource r = getResourceRoot();

         List<ValuedEnum> implicitPartitions = getImplicitPartitions();
         if (implicitPartitions != null && implicitPartitions.Contains(partType))
         {
            throw new JDFException("AddPartIDKey: attempting to add implicit partition: " + s);
         }
         r.appendAttribute(AttributeName.PARTIDKEYS, s, null, JDFConstants.BLANK, true);
      }

      ///   
      ///	 <summary> * Sets the value of attibute, specified by key
      ///	 *  </summary>
      ///	 * <param name="key"> the PartIDKey attribute name </param>
      ///	 * <param name="value"> the value to set key to </param>
      ///	 
      public virtual void setPartIDKey(EnumPartIDKey key, string @value)
      {
         setAttribute(key.getName(), @value, null);
         addPartIDKey(key);
      }

      ///   
      ///	 <summary> * Gets a list of all valid part keys for this resource
      ///	 *  </summary>
      ///	 * <returns> VString - list of all PartIDKeys </returns>
      ///	 
      public virtual VString getPartIDKeys()
      {
         JDFResource partRoot = getResourceRoot();
         if (partRoot != null)
         {
            string idKeys = partRoot.getAttribute(AttributeName.PARTIDKEYS, null, null);
            return new VString(StringUtil.tokenize(idKeys, JDFConstants.BLANK, false));
         }
         return null;
      }

      ///   
      ///	 <summary> * Sets attribute PartUsage
      ///	 *  </summary>
      ///	 * <param name="value"> enumeration value of the attribute PartUsage to be set </param>
      ///	 
      public virtual void setPartUsage(EnumPartUsage @value)
      {
         setAttribute(AttributeName.PARTUSAGE, @value.getName(), null);
      }

      ///   
      ///	 <summary> * Gets typesafe enumerated value of attribute PartUsage; defaults to PartUsage_Explicit
      ///	 *  </summary>
      ///	 * <returns> EnumPartUsage - attribute enumeration value </returns>
      ///	 
      public virtual EnumPartUsage getPartUsage()
      {
         return EnumPartUsage.getEnum(getAttribute(AttributeName.PARTUSAGE, null, EnumPartUsage.Explicit.getName()));
      }

      ///   
      ///	 <summary> * Sets attribute PartUsage
      ///	 *  </summary>
      ///	 * <param name="value"> enumeration value of the attribute PartUsage to be set </param>
      ///	 
      public virtual void setLotControl(EnumLotControl @value)
      {
         setAttribute(AttributeName.LOTCONTROL, @value.getName(), null);
      }

      ///   
      ///	 <summary> * Gets typesafe enumerated value of attribute LotControl; defaults to LotControl_Explicit
      ///	 *  </summary>
      ///	 * <returns> EnumLotControl - attribute enumeration value </returns>
      ///	 
      public virtual EnumLotControl getLotControl()
      {
         return EnumLotControl.getEnum(getAttribute(AttributeName.LOTCONTROL, null, null));
      }

      ///   
      ///	 <summary> * Sets attribute PartVersion
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setPartVersion(string @value)
      {
         setAttribute(AttributeName.PARTVERSION, @value);
      }

      ///   
      ///	 <summary> * Gets string attribute PartVersion
      ///	 *  </summary>
      ///	 * <returns> String - the attribute value </returns>
      ///	 
      public virtual string getPartVersion()
      {
         return getAttribute(AttributeName.PARTVERSION, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * Sets attribute PipeID
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setPipeID(string @value)
      {
         setAttribute(AttributeName.PIPEID, @value);
      }

      ///   
      ///	 <summary> * Gets string attribute PipeID
      ///	 *  </summary>
      ///	 * <returns> String - the attribute value </returns>
      ///	 
      public virtual string getPipeID()
      {
         return getAttribute(AttributeName.PIPEID);
      }

      ///   
      ///	 <summary> * Tests, if this leaf has a PipePartIDKey as specified by key
      ///	 *  </summary>
      ///	 * <param name="key"> the PipePartIDKey attribute name </param>
      ///	 * <returns> boolean - true, if key exists in this leaf or below
      ///	 *  </returns>
      ///	 * <exception cref="JDFException"> if the specified key is illegal </exception>
      ///	 
      public virtual bool hasPipePartIDKey(EnumPartIDKey key)
      {
         return hasAttribute(key.getName());
      }

      ///   
      ///	 <summary> * Tests, if this leaf has a consistent PartIDKey as specified by key
      ///	 *  </summary>
      ///	 * <param name="key"> the PipePartIDKey attribute name </param>
      ///	 * <returns> boolean - true, if key exists in this leaf is in PipePartIDKeys </returns>
      ///	 
      public virtual bool consistentPipePartIDKeys(EnumPartIDKey key)
      {
         string s = key.getName();
         if (!hasAttribute(s))
         {
            return true;
         }

         // the key exists but is not in PipePartIDKeys, oops
         string strPipe = getResourceRoot().getAttribute(AttributeName.PIPEPARTIDKEYS);
         if (!StringUtil.hasToken(strPipe, s, JDFConstants.BLANK, 0))
         {
            return false;
         }
         // all is well
         return true;
      }

      ///   
      ///	 <summary> * Adds a new PipePartIDKey to the root, first checks for existence
      ///	 *  </summary>
      ///	 * <param name="partType"> new PipePartIDKey to add
      ///	 *  </param>
      ///	 * <exception cref="JDFException"> if here is an attempt to add implicit partition </exception>
      ///	 
      public virtual void addPipePartIDKey(EnumPartIDKey partType)
      {
         getResourceRoot().appendAttribute(AttributeName.PIPEPARTIDKEYS, partType.getName(), null, JDFConstants.BLANK, true);
      }

      ///   
      ///	 <summary> * Sets the value of attibute, specified by key
      ///	 *  </summary>
      ///	 * <param name="key"> the PipePartIDKey attribute name </param>
      ///	 * <param name="value"> the value to set key to </param>
      ///	 
      public virtual void setPipePartIDKey(EnumPartIDKey key, string @value)
      {
         setAttribute(key.getName(), @value);
         addPipePartIDKey(key);
      }

      ///   
      ///	 <summary> * Gets a list of all valid pipe part key enums for this resource
      ///	 *  </summary>
      ///	 * <returns> Vector - list of all PipePartIDKey enums </returns>
      ///	 
      public virtual List<ValuedEnum> getPipePartIDKeysEnum()
      {
         List<ValuedEnum> v = null;

         VString vPartIDKeys = getPartIDKeys();
         v = getEnumerationsAttribute(AttributeName.PIPEPARTIDKEYS, null, EnumPartIDKey.getEnum(0), false);
         for (int i = 0; i < v.Count; i++)
         {
            if (!vPartIDKeys.Contains(((EnumPartIDKey)v[i]).getName()))
            {
               throw new JDFException("JDFResource.getPipePartIDKeys: key " + v[i] + " is not subset of PartIDKey");
            }
         }
         return v;
      }

      ///   
      ///	 <summary> * Gets a list of all valid pipe part keys for this resource
      ///	 *  </summary>
      ///	 * <returns> VString list of all PipePartIDKeys
      ///	 * @deprecated </returns>
      ///	 
      [Obsolete]
      public virtual VString getPipePartIDKeys()
      {
         VString vPipePartIDKeys = new VString();
         List<ValuedEnum> v = getPipePartIDKeysEnum();
         for (int i = 0; i < v.Count; i++)
         {
            vPipePartIDKeys.Add(((EnumPartIDKey)v[i]).getName());
         }

         return vPipePartIDKeys;
      }

      ///   
      ///	 <summary> * Set attribute PipeProtocol
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setPipeProtocol(string @value)
      {
         setAttribute(AttributeName.PIPEPROTOCOL, @value);
      }

      ///   
      ///	 <summary> * Get string attribute PipeProtocol
      ///	 *  </summary>
      ///	 * <returns> String - the attribute value </returns>
      ///	 
      public virtual string getPipeProtocol()
      {
         return getAttribute(AttributeName.PIPEPROTOCOL);
      }

      ///   
      ///	 <summary> * Sets attribute PipeURL
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setPipeURL(string @value)
      {
         setAttribute(AttributeName.PIPEURL, @value);
      }

      ///   
      ///	 <summary> * Gets string attribute PipeURL
      ///	 *  </summary>
      ///	 * <returns> String - the attribute value </returns>
      ///	 
      public virtual string getPipeURL()
      {
         return getAttribute(AttributeName.PIPEURL);
      }

      ///   
      ///	 <summary> * Sets attribute PreflightRule
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setPreflightRule(string @value)
      {
         setAttribute(AttributeName.PREFLIGHTRULE, @value);
      }

      ///   
      ///	 <summary> * Gets string attribute PreflightRule
      ///	 *  </summary>
      ///	 * <returns> String the attribute value </returns>
      ///	 
      public virtual string getPreflightRule()
      {
         return getAttribute(AttributeName.PREFLIGHTRULE, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * Sets attribute PreviewType
      ///	 *  </summary>
      ///	 * <param name="value"> enumeration value of attribute PreviewType to be set </param>
      ///	 
      public virtual void setPreviewType(JDFPart.EnumPreviewType @value)
      {
         setAttribute(AttributeName.PREVIEWTYPE, @value.getName(), null);
      }

      ///   
      ///	 <summary> * Gets typesafe enumerated value of attribute PreviewType
      ///	 *  </summary>
      ///	 * <returns> JDFPart.EnumPreviewType - the enumeration value of attribute </returns>
      ///	 
      public virtual JDFPart.EnumPreviewType getPreviewType()
      {
         return JDFPart.EnumPreviewType.getEnum(getAttribute(AttributeName.PREVIEWTYPE, null, null));
      }

      ///   
      ///	 <summary> * Sets attribute ProductID
      ///	 *  </summary>
      ///	 * <param name="value"> value to set the attribute to </param>
      ///	 
      public virtual void setProductID(string @value)
      {
         setAttribute(AttributeName.PRODUCTID, @value);
      }

      ///   
      ///	 <summary> * Gets string attribute ProductID
      ///	 *  </summary>
      ///	 * <returns> String - the attribute value </returns>
      ///	 
      public virtual string getProductID()
      {
         return getAttribute(AttributeName.PRODUCTID);
      }

      ///   
      ///	 <summary> * Sets attribute Class
      ///	 * 
      ///	 * corresponds to C++ JDFResource::SetClass()
      ///	 *  </summary>
      ///	 * <param name="value"> enumeration value of the attribute Class to be set
      ///	 *  </param>
      ///	 * <exception cref="JDFException"> if here is attempt to set value as Class_Unknown or invalid class value </exception>
      ///	 
      public virtual void setResourceClass(EnumResourceClass @value)
      {
         if (@value == null)
         {
            // what a stupid thing to set it to - Ciao
            throw new JDFException("JDFResource.SetResourceClass: Invalid class value ");
         }
         // only set class for the root
         if (isResourceRootRoot() || isResourceElement())
         {
            setAttribute(AttributeName.CLASS, @value.getName(), null);
         }
         else
         // just in case, clean up
         {
            removeAttribute(AttributeName.CLASS, null);
         }
      }

      ///   
      ///	 <summary> * Gets typesafe enumerated value of attribute Class
      ///	 * 
      ///	 * corresponds to C++ JDFResource::GetClass(), getClass() already exists in Java
      ///	 *  </summary>
      ///	 * <returns> EnumResourceClass - attribute enumeration value </returns>
      ///	 
      public virtual EnumResourceClass getResourceClass()
      {
         return EnumResourceClass.getEnum(getAttribute(AttributeName.CLASS, null, null));
      }

      ///   
      ///	 <summary> * Typesafe attribute validation of Class
      ///	 * 
      ///	 * corresponds to C++ JDFResource::ValidClass()
      ///	 *  </summary>
      ///	 * <param name="level"> level of attribute validation </param>
      ///	 * <returns> boolean - true, if valid </returns>
      ///	 
      public virtual bool validResourceClass(EnumValidationLevel level)
      {

         bool b = validAttribute(AttributeName.CLASS, null, level);
         if (!b)
         {
            return false;
         }
         // don't need to check for completeness - already done in the standard
         // validAttribute call
         if (isResourceRootRoot())
         {
            return validClass();
         }
         return true;
      }

      ///   
      ///	 <summary> * Typesafe attribute validation of Class
      ///	 * 
      ///	 * corresponds to C++ JDFResource::ValidClass()
      ///	 *  </summary>
      ///	 * <returns> boolean true, if valid </returns>
      ///	 
      public bool validClass()
      {
         EnumResourceClass c = getValidClass();
         if (c == null)
         {
            return true;
         }
         if (!hasAttribute_KElement(AttributeName.CLASS, null, false))
         {
            return true;
         }
         return c == getResourceClass();
      }

      ///   
      ///	 <summary> * get the fixed class for this resource,
      ///	 *  </summary>
      ///	 * <returns> EnumResourceClass - the class of this resource, null if no fixed class is known </returns>
      ///	 
      public virtual EnumResourceClass getValidClass()
      {
         return null;
      }

      ///   
      ///	 <summary> * Sets attribute GrossWeight
      ///	 *  </summary>
      ///	 * <param name="value"> value to set the attribute to </param>
      ///	 
      public virtual void setGrossWeight(double @value)
      {
         setAttribute(AttributeName.GROSSWEIGHT, Convert.ToString(@value)); //double.ToString(@value));
      }

      ///   
      ///	 <summary> * Gets double attribute GrossWeight
      ///	 *  </summary>
      ///	 * <returns> double - the attribute value </returns>
      ///	 
      public virtual double getGrossWeight()
      {
         return getRealAttribute(AttributeName.GROSSWEIGHT, null, 0.0);
      }

      ///   
      ///	 <summary> * Sets attribute ResourceWeight
      ///	 *  </summary>
      ///	 * <param name="value"> value to set the attribute to </param>
      ///	 
      public virtual void setResourceWeight(double @value)
      {
         setAttribute(AttributeName.GROSSWEIGHT, Convert.ToString(@value)); //double.ToString(@value));
      }

      ///   
      ///	 <summary> * Gets double attribute ResourceWeight
      ///	 *  </summary>
      ///	 * <returns> double - the attribute value </returns>
      ///	 
      public virtual double getResourceWeight()
      {
         return getRealAttribute(AttributeName.GROSSWEIGHT, null, 0.0);
      }

      ///   
      ///	 <summary> * Sets attribute RibbonName
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setRibbonName(string @value)
      {
         setAttribute(AttributeName.RIBBONNAME, @value);
      }

      ///   
      ///	 <summary> * Gets string attribute RibbonName
      ///	 *  </summary>
      ///	 * <returns> String the - attribute value </returns>
      ///	 
      public virtual string getRibbonName()
      {
         return getAttribute(AttributeName.RIBBONNAME, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * Sets attribute Run
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setRun(string @value)
      {
         setAttribute(AttributeName.RUN, @value, null);
      }

      ///   
      ///	 <summary> * Gets string attribute RunSet
      ///	 *  </summary>
      ///	 * <returns> String - the attribute value </returns>
      ///	 
      public virtual string getRunSet()
      {
         return getAttribute(AttributeName.RUNSET, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * Sets attribute RunSet
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setRunSet(string @value)
      {
         setAttribute(AttributeName.RUNSET, @value, null);
      }

      ///   
      ///	 <summary> * Gets string attribute Run
      ///	 *  </summary>
      ///	 * <returns> String - the attribute value </returns>
      ///	 
      public virtual string getRun()
      {
         return getAttribute(AttributeName.RUN, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * Sets attribute RunIndex
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setRunIndex(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.RUNINDEX, @value.ToString());
      }

      ///   
      ///	 <summary> * Gets range attribute RunIndex
      ///	 *  </summary>
      ///	 * <returns> JDFIntegerRangeList the attribute value </returns>
      ///	 
      public virtual JDFIntegerRangeList getRunIndex()
      {
         string strAttrName = JDFConstants.EMPTYSTRING;
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.RUNINDEX, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFIntegerRangeList(strAttrName);
         }
         catch (FormatException)
         {
            // do nothing
         }
         return nPlaceHolder;
      }

      ///   
      ///	 <summary> * Sets attribute RunPage
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setRunPage(int @value)
      {
         setAttribute(AttributeName.RUNPAGE, @value, null);
      }

      ///   
      ///	 <summary> * Gets integer attribute RunPage
      ///	 *  </summary>
      ///	 * <returns> int - the attribute value </returns>
      ///	 
      public virtual int getRunPage()
      {
         return getIntAttribute(AttributeName.RUNPAGE, null, 0);
      }

      ///   
      ///	 <summary> * Sets attribute RunTags
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setRunTags(VString @value)
      {
         StringBuilder strBuff = new StringBuilder(100);
         for (int i = 0; i < @value.Count; i++)
         {
            strBuff.Append(@value[i]);
         }
         setAttribute(AttributeName.RUNTAGS, strBuff.ToString(), null);
      }

      ///   
      ///	 <summary> * Gets NMTOKENS attribute RunTags
      ///	 *  </summary>
      ///	 * <returns> VString - the value of the attribute </returns>
      ///	 
      public virtual VString getRunTags()
      {
         string s = getAttribute(AttributeName.RUNTAGS, null, JDFConstants.EMPTYSTRING);
         VString v = new VString(StringUtil.tokenize(s, JDFConstants.BLANK, false));
         VString vstr = new VString();
         vstr.addAll(v.ToArray());
         return vstr;
      }

      ///   
      ///	 <summary> * Sets attribute SectionIndex
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setSectionIndex(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.SECTIONINDEX, @value.ToString());
      }

      ///   
      ///	 <summary> * Gets range attribute SectionIndex
      ///	 *  </summary>
      ///	 * <returns> JDFIntegerRangeList - the attribute value </returns>
      ///	 
      public virtual JDFIntegerRangeList getSectionIndex()
      {
         string strAttrName = JDFConstants.EMPTYSTRING;
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.SECTIONINDEX, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFIntegerRangeList(strAttrName);
         }
         catch (FormatException)
         {
            // do nothing
         }
         return nPlaceHolder;
      }

      ///   
      ///	 <summary> * Sets attribute Separation
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setSeparation(string @value)
      {
         setAttribute(AttributeName.SEPARATION, @value, null);
      }

      ///   
      ///	 <summary> * Gets string attribute Separation
      ///	 *  </summary>
      ///	 * <returns> String - the attribute value </returns>
      ///	 
      public virtual string getSeparation()
      {
         return getAttribute(AttributeName.SEPARATION, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * Sets attribute SetDocIndex
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setSetDocIndex(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.SETDOCINDEX, @value.ToString());
      }

      ///   
      ///	 <summary> * Gets range attribute SetDocIndex
      ///	 *  </summary>
      ///	 * <returns> JDFIntegerRangeList - the attribute value </returns>
      ///	 
      public virtual JDFIntegerRangeList getSetDocIndex()
      {
         string strAttrName = JDFConstants.EMPTYSTRING;
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.SETDOCINDEX, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFIntegerRangeList(strAttrName);
         }
         catch (FormatException)
         {
            // do nothing
         }
         return nPlaceHolder;
      }

      ///   
      ///	 <summary> * Sets attribute SetIndex
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setSetIndex(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.SETINDEX, @value.ToString());
      }

      ///   
      ///	 <summary> * Gets range attribute SetIndex
      ///	 *  </summary>
      ///	 * <returns> JDFIntegerRangeList - the attribute value </returns>
      ///	 
      public virtual JDFIntegerRangeList getSetIndex()
      {
         string strAttrName = JDFConstants.EMPTYSTRING;
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.SETINDEX, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFIntegerRangeList(strAttrName);
         }
         catch (FormatException)
         {
            // do nothing
         }
         return nPlaceHolder;
      }

      ///   
      ///	 <summary> * Sets attribute SetRunIndex
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setSetRunIndex(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.SETRUNINDEX, @value.ToString());
      }

      ///   
      ///	 <summary> * Gets range attribute SetRunIndex
      ///	 *  </summary>
      ///	 * <returns> JDFIntegerRangeList - the attribute value </returns>
      ///	 
      public virtual JDFIntegerRangeList getSetRunIndex()
      {
         string strAttrName = JDFConstants.EMPTYSTRING;
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.SETRUNINDEX, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFIntegerRangeList(strAttrName);
         }
         catch (FormatException)
         {
            // do nothing
         }
         return nPlaceHolder;
      }

      ///   
      ///	 <summary> * Sets attribute SetSheetIndex
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setSetSheetIndex(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.SETSHEETINDEX, @value.ToString());
      }

      ///   
      ///	 <summary> * Gets range attribute SetSheetIndex
      ///	 *  </summary>
      ///	 * <returns> JDFIntegerRangeList - the attribute value </returns>
      ///	 
      public virtual JDFIntegerRangeList getSetSheetIndex()
      {
         string strAttrName = JDFConstants.EMPTYSTRING;
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.SETSHEETINDEX, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFIntegerRangeList(strAttrName);
         }
         catch (FormatException)
         {
            // do nothing
         }
         return nPlaceHolder;
      }

      ///   
      ///	 <summary> * Sets attribute SheetIndex
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setSheetIndex(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.SHEETINDEX, @value.ToString());
      }

      ///   
      ///	 <summary> * Gets range attribute SheetIndex
      ///	 *  </summary>
      ///	 * <returns> JDFIntegerRangeList - the attribute value </returns>
      ///	 
      public virtual JDFIntegerRangeList getSheetIndex()
      {
         string strAttrName = JDFConstants.EMPTYSTRING;
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.SHEETINDEX, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFIntegerRangeList(strAttrName);
         }
         catch (FormatException)
         {
            // do nothing
         }
         return nPlaceHolder;
      }

      ///   
      ///	 <summary> * Sets attribute SheetName
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setSheetName(string @value)
      {
         setAttribute(AttributeName.SHEETNAME, @value);
      }

      ///   
      ///	 <summary> * Gets string attribute SheetName
      ///	 *  </summary>
      ///	 * <returns> String - the attribute value </returns>
      ///	 
      public virtual string getSheetName()
      {
         return getAttribute(AttributeName.SHEETNAME, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * Sets attribute Side
      ///	 *  </summary>
      ///	 * <param name="value"> enumeration value of attribute Side to be set </param>
      ///	 
      public virtual void setSide(JDFPart.EnumSide @value)
      {
         setAttribute(AttributeName.SIDE, @value.getName(), null);
      }

      ///   
      ///	 <summary> * Gets typesafe enumerated value of attribute Side
      ///	 *  </summary>
      ///	 * <returns> JDFPart.EnumSide - the enumeration value of the attribute </returns>
      ///	 
      public virtual JDFPart.EnumSide getSide()
      {
         return JDFPart.EnumSide.getEnum(getAttribute(AttributeName.SIDE, null, null));
      }

      ///   
      ///	 <summary> * Sets attribute SignatureName
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setSignatureName(string @value)
      {
         setAttribute(AttributeName.SIGNATURENAME, @value);
      }

      ///   
      ///	 <summary> * Gets string attribute SignatureName
      ///	 *  </summary>
      ///	 * <returns> String - the attribute value </returns>
      ///	 
      public virtual string getSignatureName()
      {
         return getAttribute(AttributeName.SIGNATURENAME, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * Gets string attribute StationName
      ///	 *  </summary>
      ///	 * <returns> String - the attribute value </returns>
      ///	 
      public virtual string getStationName()
      {
         return getAttribute(AttributeName.STATIONNAME, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * Sets attribute StationName
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setStationName(string @value)
      {
         setAttribute(AttributeName.STATIONNAME, @value);
      }

      ///   
      ///	 <summary> * Sets attribute SortAmount
      ///	 *  </summary>
      ///	 * <param name="value"> value to set the attribute to </param>
      ///	 
      public virtual void setSortAmount(bool @value)
      {
         setAttribute(AttributeName.SORTAMOUNT, @value, null);
      }

      ///   
      ///	 <summary> * Gets boolean attribute SortAmount
      ///	 *  </summary>
      ///	 * <returns> boolean - the attribute value </returns>
      ///	 
      public virtual bool getSortAmount()
      {
         return getBoolAttribute(AttributeName.SORTAMOUNT, null, false);
      }

      ///   
      ///	 <summary> * Sets attribute Sorting
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setSorting(JDFIntegerRangeList @value)
      {
         setAttribute(AttributeName.SORTING, @value.ToString(), null);
      }

      ///   
      ///	 <summary> * Gets range attribute Sorting
      ///	 *  </summary>
      ///	 * <returns> JDFIntegerRangeList - the attribute value </returns>
      ///	 
      public virtual JDFIntegerRangeList getSorting()
      {
         string strAttrName = JDFConstants.EMPTYSTRING;
         JDFIntegerRangeList nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.SORTING, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFIntegerRangeList(strAttrName);
         }
         catch (FormatException)
         {
            // do nothing
         }
         return nPlaceHolder;
      }

      ///   
      ///	 <summary> * Appends new SpawnID token ('value') to the list of values of SpawnIDs attribute, if it is not yet in the list
      ///	 *  </summary>
      ///	 * <param name="value"> the SpawnID token to append </param>
      ///	 
      public virtual void appendSpawnIDs(string @value)
      {
         appendAttribute(AttributeName.SPAWNIDS, @value, null, JDFConstants.BLANK, true);
      }

      ///   
      ///	 <summary> * Removes SpawnID token ('value') from the list of values of SpawnIDs attribute, if it is in the list
      ///	 *  </summary>
      ///	 * <param name="value"> the SpawnID token to remove from the NMTOKENS list </param>
      ///	 * <returns> int - the number of removed tokens </returns>
      ///	 
      public virtual int removeFromSpawnIDs(string @value)
      {
         return removeFromAttribute(AttributeName.SPAWNIDS, @value, null, JDFConstants.BLANK, -1);
      }

      ///   
      ///	 <summary> * Gets string attribute SpawnIDs
      ///	 *  </summary>
      ///	 * <param name="bInherit"> if true, searches through all leaves, else searches only this leaf/node </param>
      ///	 * <returns> VString the vector of SpawnIDs
      ///	 * 
      ///	 * @default getSpawnIDs(true) </returns>
      ///	 
      public virtual VString getSpawnIDs(bool bInherit)
      {
         string attribute = bInherit ? getAttribute(AttributeName.SPAWNIDS, null, null) : getAttribute_KElement(AttributeName.SPAWNIDS, null, null);
         if (attribute == null)
            return null;
         return new VString(StringUtil.tokenize(attribute, JDFConstants.BLANK, false));
      }

      ///   
      ///	 <summary> * Sets attribute SpawnIDs
      ///	 *  </summary>
      ///	 * <param name="vStr"> the value to set the attribute to </param>
      ///	 
      public virtual void setSpawnIDs(VString vStr)
      {
         setAttribute(AttributeName.SPAWNIDS, StringUtil.setvString(vStr, JDFConstants.BLANK, null, null), null);
      }

      ///   
      ///	 <summary> * Sets attribute SpawnStatus
      ///	 *  </summary>
      ///	 * <param name="s"> enumeration value of the attribute SpawnStatus to be set </param>
      ///	 
      public virtual void setSpawnStatus(EnumSpawnStatus s)
      {
         setAttribute(AttributeName.SPAWNSTATUS, s.getName(), null);
      }

      ///   
      ///	 <summary> * Gets typesafe enumerated value of attribute SpawnStatus
      ///	 *  </summary>
      ///	 * <returns> EnumSpawnStatus - attribute enumeration value </returns>
      ///	 
      public virtual EnumSpawnStatus getSpawnStatus()
      {
         return EnumSpawnStatus.getEnum(getAttribute(AttributeName.SPAWNSTATUS, null, EnumSpawnStatus.NotSpawned.getName()));
      }

      ///   
      ///	 <summary> * Sets attribute Status
      ///	 *  </summary>
      ///	 * <param name="value"> enumeration value of the attribute Status to be set </param>
      ///	 * @deprecated use setResStatus(value, false) 
      ///	 
      [Obsolete("use setResStatus(value, false)")]
      public virtual void setStatus(EnumResStatus @value)
      {
         setAttribute(AttributeName.STATUS, @value.getName(), null);
      }

      ///   
      ///	 <summary> * Sets attribute Status
      ///	 *  </summary>
      ///	 * <param name="value"> enumeration value of the attribute Status to be set </param>
      ///	 * <param name="bCleanLeaves"> if true, remove Status attribute from any child leaves below this </param>
      ///	 * @deprecated use setResStatus(value, bCleanLeaves) 
      ///	 
      [Obsolete("use setResStatus(value, bCleanLeaves)")]
      public virtual void setStatus(EnumResStatus @value, bool bCleanLeaves)
      {
         setResStatus(@value, bCleanLeaves);
      }

      ///   
      ///	 <summary> * Gets typesafe enumerated value of attribute Status
      ///	 *  </summary>
      ///	 * <param name="bRecurseRefs"> if bRecurseRefs is set, also recurse into all resources linked by rRefs and return the
      ///	 *            minimum status </param>
      ///	 * <returns> EnumResStatus attribute enumeration value
      ///	 * 
      ///	 * @default getStatus(false) </returns>
      ///	 * @deprecated use getResStatus(bRecurseRefs) 
      ///	 
      [Obsolete("use getResStatus(bRecurseRefs)")]
      public virtual JDFResource.EnumResStatus getStatus(bool bRecurseRefs)
      {
         return getResStatus(bRecurseRefs);
      }

      ///   
      ///	 <summary> * Sets attribute Status
      ///	 *  </summary>
      ///	 * <param name="value"> enumeration value of the attribute Status to be set </param>
      ///	 * <param name="bCleanLeaves"> if true, remove Status attribute from any child leaves below this
      ///	 * 
      ///	 * @default setResStatus(value, false) </param>
      ///	 
      public virtual void setResStatus(EnumResStatus @value, bool bCleanLeaves)
      {
         if (bCleanLeaves)
         {
            this.removeAttributeFromLeaves(AttributeName.STATUS, null);
         }
         setAttribute(AttributeName.STATUS, @value.getName(), null);
      }

      ///   
      ///	 <summary> * Gets typesafe enumerated value of attribute Status
      ///	 *  </summary>
      ///	 * <param name="bRecurseRefs"> if bRecurseRefs is set, also recurse into all resources linked by rRefs and return the
      ///	 *            minimum status </param>
      ///	 * <returns> EnumResStatus - attribute enumeration value
      ///	 * 
      ///	 * @default getResStatus(false) </returns>
      ///	 
      public virtual JDFResource.EnumResStatus getResStatus(bool bRecurseRefs)
      {
         if (bRecurseRefs)
         {
            EnumResStatus ret = getResStatus(false);
            VElement v = getvHRefRes(true, true);

            for (int i = 0; i < v.Count; i++)
            {
               JDFResource rs = (JDFResource)v[i];
               EnumResStatus rss = rs.getResStatus(false);
               if (rss != null)
               {
                  if ((ret == null) || (rss.getValue() < ret.getValue()))
                  {
                     ret = rss;
                  }
               }
            }

            return ret;
         }

         // local value
         return EnumResStatus.getEnum(getAttribute(AttributeName.STATUS, null, null));
      }



      ///   
      ///	 <summary> * Gets the minimum typesafe enumerated value of attribute Status from the value of all leaves
      ///	 *  </summary>
      ///	 * <param name="bAll"> if true, also evaluate intermediate partitions, else leaves only </param>
      ///	 * <returns> EnumResStatus - the minimum Status enumeration value
      ///	 *  </returns>
      ///	 
      public virtual EnumResStatus getStatusFromLeaves(bool bAll)
      {
         EnumResStatus minStatus = null;

         VElement v = getLeaves(bAll);
         if (v != null)
         {
            int siz = v.Count;
            for (int i = 0; i < siz; i++)
            {
               JDFResource r = (JDFResource)v[i];
               if (minStatus == null)
                  minStatus = r.getResStatus(false);
               else
                  minStatus = (EnumResStatus)EnumUtil.min(minStatus, r.getResStatus(false));
            }
         }

         return minStatus;
      }



      ///   
      ///	 <summary> * Sets attribute TileID
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setTileID(JDFXYPair @value)
      {
         setAttribute(AttributeName.TILEID, @value.ToString());
      }

      ///   
      ///	 <summary> * Gets XYPair attribute TileID
      ///	 *  </summary>
      ///	 * <returns> JDFXYPair - the attribute value </returns>
      ///	 
      public virtual JDFXYPair getTileID()
      {
         string strAttrName = JDFConstants.EMPTYSTRING;
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.TILEID, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFXYPair(strAttrName);
         }
         catch (FormatException)
         {
            // do nothing
         }

         return nPlaceHolder;
      }

      ///   
      ///	 <summary> * Sets attribute Unit
      ///	 *  </summary>
      ///	 * <param name="value"> value to set the attribute to </param>
      ///	 
      public virtual void setUnit(string @value)
      {
         setAttribute(AttributeName.UNIT, @value);
      }

      ///   
      ///	 <summary> * Gets string attribute Unit
      ///	 *  </summary>
      ///	 * <returns> String - the attribute value </returns>
      ///	 
      public virtual string getUnit()
      {
         return getAttribute(AttributeName.UNIT);
      }

      ///   
      ///	 <summary> * Sets attribute UpdateID
      ///	 *  </summary>
      ///	 * <param name="value"> value to set the attribute to </param>
      ///	 
      public virtual void setUpdateID(string @value)
      {
         setAttribute(AttributeName.UPDATEID, @value, null);
      }

      ///   
      ///	 <summary> * Gets string attribute UpdateID
      ///	 *  </summary>
      ///	 * <returns> String - the attribute value </returns>
      ///	 
      public virtual string getUpdateID()
      {
         return getAttribute(AttributeName.UPDATEID, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * Sets attribute WebName
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setWebName(string @value)
      {
         setAttribute(AttributeName.WEBNAME, @value);
      }

      ///   
      ///	 <summary> * Gets string attribute WebName
      ///	 *  </summary>
      ///	 * <returns> String - the attribute value </returns>
      ///	 
      public virtual string getWebName()
      {
         return getAttribute(AttributeName.WEBNAME, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * Sets attribute WebProduct
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setWebProduct(string @value)
      {
         setAttribute(AttributeName.WEBPRODUCT, @value);
      }

      ///   
      ///	 <summary> * Gets string attribute WebProduct
      ///	 *  </summary>
      ///	 * <returns> String the attribute value </returns>
      ///	 
      public virtual string getWebProduct()
      {
         return getAttribute(AttributeName.WEBPRODUCT, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * Sets attribute WebSetup
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setWebSetup(string @value)
      {
         setAttribute(AttributeName.WEBSETUP, @value);
      }

      ///   
      ///	 <summary> * Gets string attribute WebSetup
      ///	 *  </summary>
      ///	 * <returns> String the attribute value </returns>
      ///	 
      public virtual string getWebSetup()
      {
         return getAttribute(AttributeName.WEBSETUP, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * gets an element as defined by XPath to value <br>
      ///	 * 
      ///	 * 
      ///	 * @tbd enhance the subsets of allowed XPaths, now only .,..,/,@ are supported
      ///	 *  </summary>
      ///	 * <param name="path"> XPath abbreviated syntax representation of the attribute, e.g <code>parentElement/thisElement</code>
      ///	 *            <code>parentElement/thisElement[2]</code> <code>parentElement[@a=\"b\"]/thisElement[@foo=\"bar\"]</code>
      ///	 *  </param>
      ///	 * <returns> KElement the specified element </returns>
      ///	 * <exception cref="IllegalArgumentException"> if path is not supported </exception>
      ///	 
      // @Override
      // public KElement getXPathElement(String path)
      // {
      // VElement v= getXPathElementVector(path, 1);
      // if(v==null || v.Count<1) {
      // final String nodeName=Name;
      // KElement ke=this;
      // while (v == null || v.Count==0)
      // {
      // ke = ke.getParentNode_KElement();
      // if (ke == null || !ke.Name.equals(nodeName))
      // {
      // return null;
      // }
      // v = ke.getXPathElementVector(path, 1);
      // }
      // }
      // return v.item(0);
      // }
      ///   
      ///	 <summary> * Recursively adds the partition leaves defined in vPartMap
      ///	 *  </summary>
      ///	 * <param name="vPartMap"> the vector of maps of part keys </param>
      ///	 * <param name="vPartIDKeys"> the vector of partIDKeys strings of the resource. If empty (the default) the Resource
      ///	 *            PartIDKeys attribute is used </param>
      ///	 * <returns> VElement - vector of newly created partitions
      ///	 *  </returns>
      ///	 * <exception cref="JDFException"> if there are in the partMap not matching partitions </exception>
      ///	 * <exception cref="JDFException"> if there is an attempt to fill non-matching partIDKeys </exception>
      ///	 * <exception cref="JDFException"> if by adding of last partition key there is either non-continuous partmap or left more than
      ///	 *             one key
      ///	 * 
      ///	 * @default createPartitions(vPartMap, VString.emptyVector) </exception>
      ///	 
      public virtual VElement createPartitions(VJDFAttributeMap vPartMap, VString vPartIDKeys)
      {
         VElement v = new VElement();
         VString tmp = new VString();
         for (int i = 0; i < vPartMap.Count; i++)
         {
            JDFAttributeMap map = vPartMap[i];
            VElement vExist = getPartitionVector(map, null);
            if (vExist.IsEmpty())
            {
               tmp.Clear();
               for (int j = 0; j < vPartIDKeys.Count; j++)
               {
                  if (map.ContainsKey(vPartIDKeys[j]))
                  {
                     tmp.Add(vPartIDKeys[j]);
                  }
               }
               v.Add(getCreatePartition(map, tmp));
            }
            else
            {
               v.AddRange(vExist);
            }
         }

         return v;
      }

      ///   
      ///	 <summary> * Sets attribute ID
      ///	 *  </summary>
      ///	 * <param name="value"> value to set the attribute to </param>
      ///	 
      public virtual void setID(string @value)
      {
         setAttribute(AttributeName.ID, @value, null);
      }

      ///   
      ///	 <summary> * Gets string attribute ID
      ///	 *  </summary>
      ///	 * <returns> String - the attribute value </returns>
      ///	 
      public override string getID()
      {
         return this.getAttribute(AttributeName.ID, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * calculate a new level based on the status
      ///	 *  </summary>
      ///	 * <param name="level"> </param>
      ///	 * <param name="bForce"> </param>
      ///	 * <returns> EnumValidationLevel - the modified level </returns>
      ///	 
      private EnumValidationLevel incompleteLevel(EnumValidationLevel level, bool bForce)
      {
         EnumValidationLevel levelLocal = level;

         EnumResStatus es = getResStatus(false);
         if ((es == EnumResStatus.Incomplete) || isResourceUpdate() || bForce)
         {
            levelLocal = EnumValidationLevel.incompleteLevel(levelLocal);
         }

         return levelLocal;
      }

      ///   
      ///	 <summary> * Validator of 'this'
      ///	 *  </summary>
      ///	 * <param name="level"> the valdation level </param>
      ///	 * <returns> boolean - true, if 'this' is valid </returns>
      ///	 
      public override bool isValid(EnumValidationLevel level)
      {
         EnumValidationLevel levelLocal = level;

         bool bRet = true;

         // it is supposed to be incomplete -> don't check for completeness
         levelLocal = incompleteLevel(levelLocal, false);

         bool bLeaf = isLeaf();
         EnumPartUsage partUsage = getResourceRoot().getPartUsage();
         bool bForceIncomplete = !(partUsage == EnumPartUsage.Implicit) || (partUsage == EnumPartUsage.Sparse);
         if (bLeaf)
         {
            if (!base.isValid(levelLocal))
            {
               return false;
            }
         }
         else if (isResourceUpdate())
         {
            JDFResource r = getResourceRoot();
            if (r == null)
            { // tbd details of customerinfo + nodeinfo res elements
               return true;
            }
         }
         else
         {
            if (this.getInvalidAttributes(incompleteLevel(levelLocal, bForceIncomplete), true, 1).Count > 0)
            {
               return false;
            }
            // final VElement v = getLeaves(false);
            VElement v = getChildElementVector_KElement(Name, null, null, true, 0);
            for (int i = 0; i < v.Count; i++)
            {
               if (!((JDFResource)v[i]).isValid(levelLocal))
               {
                  return false;
               }
            }
         }

         if (!isResourceRootRoot())
         {
            // PartIDKeys is only valid in the root
            if (hasAttribute_KElement(AttributeName.PARTIDKEYS, null, false))
            {
               return false;
            }

            if (!isResourceElement())
            {
               if (hasAttribute_KElement(AttributeName.CLASS, null, false))
               {
                  return false;
               }
            }
            // if partusage=implicit, the root must also be complete and valid
            // by itself
         }
         else if (!bLeaf && !bForceIncomplete)
         {
            if (!base.isValid(levelLocal))
            {
               return false;
            }
         }
         return bRet;
      }

      ///   
      ///	 <summary> * Typesafe validator. Gets a vector of invalid attributes
      ///	 *  </summary>
      ///	 * <param name="level"> flag whether incomplete elements are valid </param>
      ///	 * <param name="bIgnorePrivate"> if true, do not validate attributes in private name spaces </param>
      ///	 * <param name="nMax"> maximum size of the returned vector. Stop validation after nMax invalid attributes
      ///	 *  </param>
      ///	 * <returns> vWString a vector of invalid attributes
      ///	 * 
      ///	 * @default getInvalidAttributes(EnumValidationLevel.Complete, true, 9999999) </returns>
      ///	 
      public override VString getInvalidAttributes(EnumValidationLevel level, bool bIgnorePrivate, int nMax)
      {
         VString vAtts = base.getInvalidAttributes(level, bIgnorePrivate, nMax);

         int n = vAtts.Count;
         if (n >= nMax)
         {
            return vAtts;
         }

         // added class check here
         if (!validResourceClass(level))
         {
            vAtts.appendUnique(AttributeName.CLASS);
            if (++n >= nMax)
            {
               return vAtts;
            }
         }
         // now check whether they are in PartIDKeys

         if (!isResourceElement())
         {
            JDFResource root = getResourceRoot();
            VString partIDKeys = root.getPartIDKeys();
            int size = partIDKeys.Count;
            string currentPartition = null;
            for (int i = 0; i < size; i++)
            {
               string keyName = partIDKeys.stringAt(i);
               EnumPartIDKey nxt = EnumPartIDKey.getEnum(keyName);
               if (!consistentPartIDKeys(nxt, root, partIDKeys))
               {
                  vAtts.appendUnique(keyName);
                  if (++n >= nMax)
                  {
                     return vAtts;
                  }
               }
               if (hasAttribute_KElement(keyName, null, false))
                  currentPartition = keyName;
            }
            if (currentPartition != null) // check for multiple identical
            // partition attribute values
            {
               KElement parent = getParentNode_KElement();
               VElement vThis = parent.getChildElementVector_KElement(Name, getNamespaceURI(), new JDFAttributeMap(currentPartition, getAttribute_KElement(currentPartition)), true, 999);
               if (vThis.Count > 1)
               {
                  vAtts.appendUnique(currentPartition);
                  if (++n >= nMax)
                  {
                     return vAtts;
                  }
               }
            }
         }
         if (!EnumValidationLevel.isNoWarn(level) && isResourceRoot())
         {
            EnumPartUsage pu = getPartUsage();
            if (EnumPartUsage.Sparse.Equals(pu) && EnumVersion.Version_1_3.isGreater(getVersion(true)))
               vAtts.Add(AttributeName.PARTUSAGE);
         }

         return vAtts;
      }

      ///   
      ///	 <summary> * deletes this if it is no longer linked by either resource refs or resource links
      ///	 *  </summary>
      ///	 * <returns> true if this has been deleted </returns>
      ///	 
      public virtual bool deleteUnLinked()
      {
         bool bRet = false;
         VElement vLinks = getLinksAndRefs(true, true);

         if (vLinks == null)
         {
            VElement vRefs = getRefElements();
            if (vRefs != null)
            {
               VElement v2 = new VElement();
               for (int j = 0; j < vRefs.Count; j++)
                  v2.Add(((JDFRefElement)vRefs[j]).getTarget());
               vRefs = v2;
            }
            deleteNode();
            if (vRefs != null)
            {
               for (int j = 0; j < vRefs.Count; j++)
                  ((JDFResource)vRefs[j]).deleteUnLinked();
            }
            bRet = true;
         }
         return bRet;
      }

      ///   
      ///	 * <returns> the autoAgent </returns>
      ///	 
      public static bool getAutoAgent()
      {
         return autoAgent;
      }

      ///   
      ///	 * <param name="autoAgent"> the autoAgent to set </param>
      ///	 
      public static void setAutoAgent(bool _autoAgent)
      {
         JDFResource.autoAgent = _autoAgent;
      }

      ///   
      ///	 <summary> * check whether this resource matches a named resource string
      ///	 *  </summary>
      ///	 * <param name="namedResLink">
      ///	 * @return </param>
      ///	 
      public virtual bool matchesString(string namedResLink)
      {
         if (namedResLink == null)
            return true;
         return LocalName.Equals(namedResLink);
      }
   }
}
