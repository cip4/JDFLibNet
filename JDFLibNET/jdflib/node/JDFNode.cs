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
 * Copyright (c) 2001 Heidelberger Druckmaschinen AG, All Rights Reserved.
 * JDFNode.cs
 * Last changes
 * 2001-09-07   Torsten Kaehlert - if (!GetNodeName().equals("JDF")) changed from equals to !equals
 *              TKAE20010907
 * 2001-07-30   Torsten Kaehlert - delete isNull() and throwNull() methods in parent class KNode
 *              TKAE20010730
 * 13-02-2002   Kai Mattern - added getSpawnID
 * 13-02-2002   Kai Mattern - added removeSpawnID
 * 15-02-2002   Kai Mattern - changed isValid in linkResource (added parameter ValidationLevel_Construct)
 * 06-02-2002   Kai Mattern - added LinkNames()
 * 06-02-2002   Kai Mattern - added LinkInfo()
 * 06-02-2002   Kai Mattern - added isValidLinkIndex()
 * 06-02-2002   Kai Mattern - added getLinksLength()
 * 06-02-2002   Kai Mattern - added getGenericLinksLength()
 * 06-02-2002   Kai Mattern - added EnumProcessUsage()
 * 06-02-2002   Kai Mattern - defined ant value GENERIC_LINKS_LENGHT;
 * 07-02-2002   Kai Mattern - added getMatchingResource()
 * 07-02-2002   Kai Mattern - added getMatchingLink()
 * 07-02-2002   Kai Mattern - added getMatchingLinks()
 * 08-02-2002   Kai Mattern - added MapEnumToInfo()
 * 12-02-2002   Kai Mattern - added NumMatchingLinks()
 * 12-02-2002   Kai Mattern - added removeMatchingLink()
 * 12-02-2002   Kai Mattern - added LinkMatchingResource()
 * 18-06-2002   JG  - added UnSpawn
 * 18-06-2002   JG  - modified activation list
 * 18-06-2002   JG  - added ProjectID support
 * 18-06-2002   JG  - modified getParentJDFNode()
 * 18-06-2002   JG  - added  bSpawnROPartsOnly to Spawn(...) and addSpawnedResources(...)
 * 18-06-2002   JG  - added getAncestorAttribute(), hasAncestorAttribute()
 * 18-06-2002   JG  - getMatchingLinks() minor bug fixes
 * 18-06-2002   JG  - renamed UnSpawn to UnSpawnNode()
 * 18-06-2002   JG  - added getAncestorElement(), hasAncestorElement()
 * 18-06-2002   JG  - fixed StatusPool Handling in UnspawnNode() and setPartStatus()
 * 18-06-2002   JG  - getMissingLinkVecor() bug fix
 * 18-06-2002   JG  - removed getAncestorNode -> use getParentJDFNode instead
 * 18-06-2002   JG  - calls to getInheritedAttribute replaced by calls to getAncestorAttribute
 * 18-06-2002   JG  - calls to hasAttribute replaced by calls to hasAncestorAttribute
 * 18-06-2002   JG  - addSpawnedResources() bug fix for appending to rRefsRO / rRefsRW, 
 *                    remove call to setLocked for root of partitioned resource
 * 10-09-2002   RP  - MapEnumToInfo >= --> > bug fix
 * 27-09-2006   NB  - finished mapPut(), fixed TypeLinkInfo(), TypeLinksNames() [16x]
 */

namespace org.cip4.jdflib.node
{
   using System;
   using System.Collections;
   using System.Collections.Generic;
   using System.Text;
   using System.Xml;

   using ArrayUtils = org.apache.commons.lang.ArrayUtils;
   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   using EnumDeviceStatus = org.cip4.jdflib.auto.JDFAutoDeviceInfo.EnumDeviceStatus;
   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFAudit = org.cip4.jdflib.core.JDFAudit;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFCustomerInfo = org.cip4.jdflib.core.JDFCustomerInfo;
   using JDFCustomerMessage = org.cip4.jdflib.core.JDFCustomerMessage;
   using JDFDoc = org.cip4.jdflib.core.JDFDoc;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFNodeInfo = org.cip4.jdflib.core.JDFNodeInfo;
   using JDFPartAmount = org.cip4.jdflib.core.JDFPartAmount;
   using JDFPartStatus = org.cip4.jdflib.core.JDFPartStatus;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using XMLDocUserData = org.cip4.jdflib.core.XMLDocUserData;
   using EnumAuditType = org.cip4.jdflib.core.JDFAudit.EnumAuditType;
   using EnumUsage = org.cip4.jdflib.core.JDFResourceLink.EnumUsage;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using JDFIntegerList = org.cip4.jdflib.datatypes.JDFIntegerList;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using UnLinkFinder = org.cip4.jdflib.elementwalker.UnLinkFinder;
   using IMatches = org.cip4.jdflib.ifaces.IMatches;
   using INodeIdentifiable = org.cip4.jdflib.ifaces.INodeIdentifiable;
   using JDFJMF = org.cip4.jdflib.jmf.JDFJMF;
   using JDFAmountPool = org.cip4.jdflib.pool.JDFAmountPool;
   using JDFAncestorPool = org.cip4.jdflib.pool.JDFAncestorPool;
   using JDFAuditPool = org.cip4.jdflib.pool.JDFAuditPool;
   using JDFResourceLinkPool = org.cip4.jdflib.pool.JDFResourceLinkPool;
   using JDFResourcePool = org.cip4.jdflib.pool.JDFResourcePool;
   using JDFStatusPool = org.cip4.jdflib.pool.JDFStatusPool;
   using JDFCreated = org.cip4.jdflib.resource.JDFCreated;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFResourceAudit = org.cip4.jdflib.resource.JDFResourceAudit;
   using EnumPartUsage = org.cip4.jdflib.resource.JDFResource.EnumPartUsage;
   using EnumResStatus = org.cip4.jdflib.resource.JDFResource.EnumResStatus;
   using EnumResourceClass = org.cip4.jdflib.resource.JDFResource.EnumResourceClass;
   using JDFBusinessInfo = org.cip4.jdflib.resource.process.JDFBusinessInfo;
   using JDFCompany = org.cip4.jdflib.resource.process.JDFCompany;
   using JDFComponent = org.cip4.jdflib.resource.process.JDFComponent;
   using JDFContact = org.cip4.jdflib.resource.process.JDFContact;
   using JDFEmployee = org.cip4.jdflib.resource.process.JDFEmployee;
   using JDFMISDetails = org.cip4.jdflib.resource.process.JDFMISDetails;
   using JDFNotificationFilter = org.cip4.jdflib.resource.process.JDFNotificationFilter;
   using ContainerUtil = org.cip4.jdflib.util.ContainerUtil;
   using JDFDate = org.cip4.jdflib.util.JDFDate;
   using JDFDuration = org.cip4.jdflib.util.JDFDuration;
   using JDFMerge = org.cip4.jdflib.util.JDFMerge;
   using JDFSpawn = org.cip4.jdflib.util.JDFSpawn;
   using StatusCounter = org.cip4.jdflib.util.StatusCounter;
   using StringUtil = org.cip4.jdflib.util.StringUtil;

   ///
   /// <summary> * This is the main node for the JDF ticket. Others are around, but this is the main one to do editing. </summary>
   /// 
   public class JDFNode : JDFElement, INodeIdentifiable
   {
      ///   
      ///	 <summary> * 0x22222222 is the HexValue used so programmers know which attribute/element is REQUIRED when
      ///	 * "Add Required elements/attributes" is selected. The validation tool will also throw an error until the
      ///	 * attribute/element is added. </summary>
      ///	 
      private static AtrInfoTable[] atrInfoTable_abstract = new AtrInfoTable[21];
      static JDFNode()
      {
         atrInfoTable_abstract[0] = new AtrInfoTable(AttributeName.ACTIVATION, 0x33333333, AttributeInfo.EnumAttributeType.enumeration, EnumActivation.getEnum(0), null);
         atrInfoTable_abstract[1] = new AtrInfoTable(AttributeName.CATEGORY, 0x33333311, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable_abstract[2] = new AtrInfoTable(AttributeName.ICSVERSIONS, 0x33333311, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable_abstract[3] = new AtrInfoTable(AttributeName.ID, 0x22222222, AttributeInfo.EnumAttributeType.ID, null, null);
         atrInfoTable_abstract[4] = new AtrInfoTable(AttributeName.JOBID, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable_abstract[5] = new AtrInfoTable(AttributeName.JOBPARTID, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable_abstract[6] = new AtrInfoTable(AttributeName.MAXVERSION, 0x33333311, AttributeInfo.EnumAttributeType.JDFJMFVersion, null, null);
         atrInfoTable_abstract[7] = new AtrInfoTable(AttributeName.NAMEDFEATURES, 0x33333311, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable_abstract[8] = new AtrInfoTable(AttributeName.PROJECTID, 0x33333331, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable_abstract[9] = new AtrInfoTable(AttributeName.RELATEDJOBID, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable_abstract[10] = new AtrInfoTable(AttributeName.RELATEDJOBPARTID, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable_abstract[11] = new AtrInfoTable(AttributeName.SPAWNID, 0x33333331, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable_abstract[12] = new AtrInfoTable(AttributeName.STATUS, 0x22222222, AttributeInfo.EnumAttributeType.enumeration, EnumNodeStatus.getEnum(0), null);
         atrInfoTable_abstract[13] = new AtrInfoTable(AttributeName.STATUSDETAILS, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable_abstract[14] = new AtrInfoTable(AttributeName.TEMPLATE, 0x33333311, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable_abstract[15] = new AtrInfoTable(AttributeName.TEMPLATEID, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable_abstract[16] = new AtrInfoTable(AttributeName.TEMPLATEVERSION, 0x33333311, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable_abstract[17] = new AtrInfoTable(AttributeName.TYPE, 0x22222222, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable_abstract[18] = new AtrInfoTable(AttributeName.VERSION, 0x33333333, AttributeInfo.EnumAttributeType.JDFJMFVersion, EnumVersion.getEnum(0), null);
         atrInfoTable_abstract[19] = new AtrInfoTable(AttributeName.XMLNS, 0x33333331, AttributeInfo.EnumAttributeType.URI, EnumVersion.getEnum(0), null);
         atrInfoTable_abstract[20] = new AtrInfoTable(AttributeName.XSITYPE, 0x33333311, AttributeInfo.EnumAttributeType.NMTOKEN, EnumVersion.getEnum(0), null);
         atrInfoTable_root[0] = new AtrInfoTable(AttributeName.VERSION, 0x22222222, AttributeInfo.EnumAttributeType.JDFJMFVersion, EnumVersion.getEnum(0), null);
         atrInfoTable_root[1] = new AtrInfoTable(AttributeName.XMLNS, 0x22222221, AttributeInfo.EnumAttributeType.URI, null, null);
         atrInfoTable_Combined[0] = new AtrInfoTable(AttributeName.TYPES, 0x22222222, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable_PG[0] = new AtrInfoTable(AttributeName.TYPES, 0x33333333, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         elemInfoTable_abstract[0] = new ElemInfoTable(ElementName.AUDITPOOL, 0x66666666);
         elemInfoTable_abstract[1] = new ElemInfoTable(ElementName.CUSTOMERINFO, 0x77777666);
         elemInfoTable_abstract[2] = new ElemInfoTable(ElementName.NODEINFO, 0x77777666);
         elemInfoTable_abstract[3] = new ElemInfoTable(ElementName.RESOURCELINKPOOL, 0x66666666);
         elemInfoTable_abstract[4] = new ElemInfoTable(ElementName.RESOURCEPOOL, 0x66666666);
         elemInfoTable_abstract[5] = new ElemInfoTable(ElementName.STATUSPOOL, 0x77777666);
         elemInfoTable_root[0] = new ElemInfoTable(ElementName.ANCESTORPOOL, 0x66666666);
         elemInfoTable_JDF[0] = new ElemInfoTable(ElementName.JDF, 0x33333333);
         // links
         mapPut(EnumType.Product.getName(), ",Component,ArtDeliveryIntent,BindingIntent,ColorIntent,DeliveryIntent,EmbossingIntent,FoldingIntent," + "HoleMakingIntent,InsertingIntent,LaminatingIntent,LayoutIntent,MediaIntent,NumberingIntent," + "PackingIntent,ProductionIntent,ProofingIntent,ScreeningIntent,ShapeCuttingIntent,SizeIntent", ",o+ i* i*Cover i?Jacket i?Parent i*EndSheet,i?,i?,i?,i?,i?,i?," + "i?,i?,i?,i?,i?,i?," + "i?,i?,i?,i?,i?,i?");

         // links
         mapPut(EnumType.ProcessGroup.getName(), ",*", ",i* o*");

         // links
         mapPut(EnumType.Combined.getName(), ",", ",");

         // ----- general -----
         // links
         mapPut(EnumType.Approval.getName(), ",*,ApprovalSuccess,ApprovalParams", ",o*Rejected o*Accepted i*,o_,i_");

         // links
         mapPut(EnumType.Buffer.getName(), ",*,BufferParams", ",o_ i_,i_");

         // links
         mapPut(EnumType.Combine.getName(), ",*", ",o_ i+");

         // links
         mapPut(EnumType.Delivery.getName(), ",*,DeliveryParams", ",o+ i?,i_");

         // links
         mapPut(EnumType.ManualLabor.getName(), ",*,ManualLaborParams", ",o_ i*,i_");

         // links
         mapPut(EnumType.Ordering.getName(), ",*,OrderingParams", ",o+,i_");

         // links
         mapPut(EnumType.Packing.getName(), ",*,PackingParams", ",o_ i_,i_");

         // links
         mapPut(EnumType.QualityControl.getName(), ",*,QualityControlResult,QualityControlParams", ",o_ i_,o_,i_");

         // links
         mapPut(EnumType.ResourceDefinition.getName(), ",*,ResourceDefinitionParams", ",o+ i*,i?");

         // links
         mapPut(EnumType.Split.getName(), ",*", ",o+ i_");

         // links
         mapPut(EnumType.Verification.getName(), ",*,DBSelection,ApprovalSuccess,VerificationParams,IdentificationField,DBSchema", ",o? i?,o? i?,o?,i_,i*,i?");

         // ----- prepress -----
         // links
         mapPut(EnumType.AssetListCreation.getName(), ",AssetListCreationParams,RunList", ",i_,i_ o_");

         // links
         mapPut(EnumType.Bending.getName(), ",BendingParams,ExposedMedia,Media", ",i_,i? o_,i?");

         // links
         mapPut(EnumType.ColorCorrection.getName(), ",ColorantControl,ColorCorrectionParams,RunList", ",i?,i_,o_ i_");

         // links
         mapPut(EnumType.ColorSpaceConversion.getName(), ",ColorantControl,ColorSpaceConversionParams,RunList", ",i?,i_,o_ i_");

         // links
         mapPut(EnumType.ContactCopying.getName(), ",ContactCopyParams,DevelopingParams,ExposedMedia,Media,PlateCopyParams", ",i_,i?,o_ i+,i_,i?");

         // links
         mapPut(EnumType.ContoneCalibration.getName(), ",RunList,ScreeningParams,TransferFunctionControl", ",o_ i_,i?,i?");

         // links
         mapPut(EnumType.CylinderLayoutPreparation.getName(), ",CylinderLayoutPreparationParams,Layout,RunList,CylinderLayout", ",i?,i_,i_,o_");

         // links
         mapPut(EnumType.DBDocTemplateLayout.getName(), ",DBRules,DBSchema,LayoutElement", ",i_,i_,o* i*");

         // links
         mapPut(EnumType.DBTemplateMerging.getName(), ",DBMergeParams,DBSelection,LayoutElement,RunList", ",i_,i_,i*,o_");

         // links
         mapPut(EnumType.DigitalDelivery.getName(), ",DigitalDeliveryParams,RunList", ",i_,o+ i*");

         // links
         mapPut(EnumType.FilmToPlateCopying.getName(), ",DevelopingParams,ExposedMedia,Media,PlateCopyParams", ",i?,o_ i_,i_,i_");

         // links
         mapPut(EnumType.FormatConversion.getName(), ",FormatConversionParams,RunList", ",i_,o_ i_");

         // links
         mapPut(EnumType.ImageReplacement.getName(), ",ImageCompressionParams,ImageReplacementParams,RunList", ",i?,i_,o_ i_");

         // links
         mapPut(EnumType.ImageSetting.getName(), ",ColorantControl,DevelopingParams,ImageSetterParams,Media," + "RunList,TransferCurvePool,ExposedMedia", ",i?,i?,i?,i?," + "i_,i?,o_ i?");

         // links
         mapPut(EnumType.Imposition.getName(), ",Layout,RunList", ",i_,o_ i?Marks i_Document");

         // links
         mapPut(EnumType.InkZoneCalculation.getName(), ",InkZoneCalculationParams,InkZoneProfile,Layout," + "TransferCurvePool,Sheet,Preview", ",i?,o_,i?," + "i?,i?,i_");

         // links
         mapPut(EnumType.Interpreting.getName(), ",ColorantControl,FontPolicy,InterpretedPDLData" + ",InterpretingParams,PDLResourceAlias,RunList", ",i?,i?,o?" + ",i_,i*,o? i_");

         // links
         mapPut(EnumType.LayoutElementProduction.getName(), ",LayoutElement,RunList,LayoutElementProductionParams", ",o? i*,i* o?,i?");

         // links
         mapPut(EnumType.LayoutPreparation.getName(), ",LayoutPreparationParams,RunList,Layout,TransferCurvePool", ",i_,o?Marks i?Marks i?Document,o_,o?");

         // links
         mapPut(EnumType.PDFToPSConversion.getName(), ",PDFToPSConversionParams,RunList", ",i_,o_ i_");

         // links
         mapPut(EnumType.PDLCreation.getName(), ",ImageCompressionParams,PDLCreationParams,RunList", ",i?,i?,o_ i_");

         // links
         mapPut(EnumType.Preflight.getName(), ",PreflightParams,PreflightReportRulePool,RunList,PreflightReport", ",i_,i_,i_,o_");

         // links
         mapPut(EnumType.PreviewGeneration.getName(), ",ColorantControl,ExposedMedia,PreviewGenerationParams" + ",RunList,TransferCurvePool,Preview", ",i?,i?,i_" + ",i?,i?,o_ i?");

         // links
         mapPut(EnumType.Proofing.getName(), ",ColorantControl,ColorSpaceConversionParams" + ",ExposedMedia,Layout,Media,ProofingParams,RunList", ",i?,i?" + ",o_,i?,i_,i_,i?Marks i_Document");

         // links
         mapPut(EnumType.PSToPDFConversion.getName(), ",FontParams,ImageCompressionParams" + ",PSToPDFConversionParams,RunList", ",i?,i?" + ",i?,o_ i_");

         // links
         mapPut(EnumType.RasterReading.getName(), ",RasterReadingParams,RunList", ",i?,o_ i_");

         // links
         mapPut(EnumType.Rendering.getName(), ",InterpretedPDLData,Media,RenderingParams,RunList", ",i?,i?,i?,o_ i?");

         // links
         mapPut(EnumType.Scanning.getName(), ",ExposedMedia,ScanParams,RunList", ",i_,i_,o_");

         // links
         mapPut(EnumType.Screening.getName(), ",RunList,ScreeningParams", ",o_ i_,i_");

         // links
         mapPut(EnumType.Separation.getName(), ",ColorantControl,RunList,SeparationControlParams", ",i?,o_ i_,i_");

         // links
         mapPut(EnumType.SoftProofing.getName(), ",ColorantControl,ColorSpaceConversionParams,Layout" + ",ProofingParams,RunList", ",i?,i?,i?" + ",i_,i?Marks i_Document");

         // links
         mapPut(EnumType.Stripping.getName(), ",RunList,Layout,Assembly,TransferCurvePool,StrippingParams,ColorantControl", ",o?Marks o?Document i?Document,o_,i+,i?,i_,i?");

         // links
         mapPut(EnumType.Tiling.getName(), ",RunList,Tile", ",o_ i?Marks i_Surface,i_");

         // links
         mapPut(EnumType.Trapping.getName(), ",ColorantControl,RunList,TrappingDetails,FontPolicy", ",i?,o_ i_,i_,i?");

         // ----- press -----
         // link info
         mapPut(EnumType.ConventionalPrinting.getName(), ",ColorantControl,Component,ConventionalPrintingParams" + ",ExposedMedia,Ink,InkZoneProfile,Layout,Media" + ",PrintCondition,Sheet,TransferCurvePool", ",i?,o?Waste o_ i?Proof i?Input i?,i_," + "i?Plate i?Cylinder i?Proof,i?,i?,i?,i?," + "i?,i?,i?");

         // links
         mapPut(EnumType.DigitalPrinting.getName(), ",ColorantControl,Component,DigitalPrintingParams" + ",ExposedMedia,Ink,PrintCondition,Media,RunList" + ",Layout,Sheet,TransferCurvePool", ",i?,o?Waste o_ i?Proof i*Input i*,i_" + ",i?,i?,i?,i*,i_" + ",i?,i?,i?");

         // links
         mapPut(EnumType.IDPrinting.getName(), ",ColorantControl,Component,ExposedMedia,FontPolicy" + ",Ink,InterpretingParams,IDPrintingParams,Media" + ",RenderingParams,RunList,ScreeningParams" + ",TransferFunctionControl", ",i?,o?Waste o_Good i?Proof i?Input i?Cover,i?,i?" + ",i?,i*,i?,i?" + ",i?,i_,i?" + ",i?");

         // ----- postpress -----
         // links
         mapPut(EnumType.AdhesiveBinding.getName(), ",AdhesiveBindingParams,Component", ",i_,o_ i?Cover i_BookBlock");

         // links
         mapPut(EnumType.BlockPreparation.getName(), ",Component,BlockPreparationParams", ",o_ i_,i_");

         // links
         mapPut(EnumType.BoxFolding.getName(), ",Component,BoxFoldingParams", ",o_ i*Application i_,i_");

         // links
         mapPut(EnumType.BoxPacking.getName(), ",Component,BoxPackingParams", ",o_ i?Box i_,i_");

         // links
         mapPut(EnumType.Bundling.getName(), ",Component,BundlingParams,Media", ",o_ i_,i_,i?");

         // links
         mapPut(EnumType.CaseMaking.getName(), ",Component,CaseMakingParams,Media", ",o_ i?CoverMaterial,i_,i?SpineBoard i_CoverBoard i?CoverMaterial");

         // links
         mapPut(EnumType.CasingIn.getName(), ",Component,CasingInParams", ",o_ i_Case i_,i_");

         // links
         mapPut(EnumType.ChannelBinding.getName(), ",ChannelBindingParams,Component", ",i_,o_ i?Cover i_BookBlock");

         // links
         mapPut(EnumType.CoilBinding.getName(), ",CoilBindingParams,Component", ",i_,o_ i_");

         // links
         mapPut(EnumType.Collecting.getName(), ",CollectingParams,Component,DBRules,DBSelection" + ",IdentificationField,Assembly", ",i?,o_ i+,i*,i?" + ",i?,i?");

         // links
         mapPut(EnumType.CoverApplication.getName(), ",Component,CoverApplicationParams", ",o_ i_Cover i_,i_");

         // links
         mapPut(EnumType.Creasing.getName(), ",CreasingParams,Component", ",i_,o_ i_");

         // links
         mapPut(EnumType.Cutting.getName(), ",Component,CutBlock,CutMark,CuttingParams,Media", ",o* i?,i*,i*,i_,o* i?");

         // links
         mapPut(EnumType.Dividing.getName(), ",Component,DividingParams", ",o_ i_,i_");

         // links
         mapPut(EnumType.Embossing.getName(), ",Component,EmbossingParams,Media,Tool", ",o_ i_,i_,i?,i?");

         // links
         mapPut(EnumType.EndSheetGluing.getName(), ",Component,EndSheetGluingParams", ",o_ i_FrontEndSheet i_BookBlock i_BackEndSheet,i_");

         // links
         mapPut(EnumType.Feeding.getName(), ",Component,FeedingParams,Media", ",o* i*,i_,o* i*");

         // links
         mapPut(EnumType.Folding.getName(), ",Component,FoldingParams", ",o_ i_,i_");

         // links
         mapPut(EnumType.Gathering.getName(), ",Assembly,Component,DBRules,DBSelection" + ",GatheringParams,IdentificationField", ",i?,o_ i+,i*,i?" + ",i_,i?");

         // links
         mapPut(EnumType.Gluing.getName(), ",Component,GluingParams", ",o_ i_,i_");

         // links
         mapPut(EnumType.HeadBandApplication.getName(), ",Component,HeadBandApplicationParams", ",o_ i_,i_");

         // links
         mapPut(EnumType.HoleMaking.getName(), ",Component,HoleMakingParams", ",o_ i_,i_");

         // links
         mapPut(EnumType.Inserting.getName(), ",Component,DBRules,DBSelection" + ",IdentificationField,InsertingParams", ",o_ i_Child i?Mother i?,i?,i?" + ",i?,i_");

         // links
         mapPut(EnumType.Jacketing.getName(), ",Component,JacketingParams", ",o_ i_Jacket i_Book,i_");

         // links
         mapPut(EnumType.Labeling.getName(), ",Component,LabelingParams", ",o_ i?Label i_,i_");

         // links
         mapPut(EnumType.Laminating.getName(), ",Component,LaminatingParams,Media", ",o_ i_,i_,i?");

         // links
         mapPut(EnumType.LongitudinalRibbonOperations.getName(), ",Component,LongitudinalRibbonOperationParams", ",o+ i_,i_");

         // links
         mapPut(EnumType.Numbering.getName(), ",Component,NumberingParams", ",o_ i_,i_");

         // links
         mapPut(EnumType.Palletizing.getName(), ",Component,PalletizingParams,Pallet", ",o_ i_,i_,i_");

         // links
         mapPut(EnumType.Perforating.getName(), ",PerforatingParams,Component", ",i_,o_ i_");

         // links
         mapPut(EnumType.PlasticCombBinding.getName(), ",Component,PlasticCombBindingParams", ",o_ i_,i_");

         // links
         mapPut(EnumType.PrintRolling.getName(), ",Component,PrintRollingParams,RollStand", ",o_ i_,i?,i?");

         // links
         mapPut(EnumType.RingBinding.getName(), ",Component,RingBindingParams", ",o_ i?RingBinder i_BookBlock,i_");

         // links
         mapPut(EnumType.SaddleStitching.getName(), ",Component,SaddleStitchingParams", ",o_ i_,i_");

         // links
         mapPut(EnumType.ShapeCutting.getName(), ",Component,ShapeCuttingParams,Tool", ",o+ i_,i?,i*");

         // links
         mapPut(EnumType.Shrinking.getName(), ",Component,ShrinkingParams", ",o_ i_,i_");

         // links
         mapPut(EnumType.SideSewing.getName(), ",Component,SideSewingParams", ",o_ i_,i_");

         // links
         mapPut(EnumType.SpinePreparation.getName(), ",Component,SpinePreparationParams", ",o_ i_,i_");

         // links
         mapPut(EnumType.SpineTaping.getName(), ",Component,SpineTapingParams", ",o_ i_,i_");

         // links
         mapPut(EnumType.Stacking.getName(), ",Component,StackingParams", ",o_ i_,i_");

         // links
         mapPut(EnumType.Stitching.getName(), ",Component,StitchingParams", ",o_ i_,i_");

         // links
         mapPut(EnumType.Strapping.getName(), ",Component,StrappingParams,Strap", ",o_ i_,i_,i?");

         // links
         mapPut(EnumType.StripBinding.getName(), ",Component,StripBindingParams", ",o_ i_,i_");

         // links
         mapPut(EnumType.ThreadSealing.getName(), ",Component,ThreadSealingParams", ",o_ i_,i_");

         // links
         mapPut(EnumType.ThreadSewing.getName(), ",Component,ThreadSewingParams", ",o_ i_,i_");

         // links
         mapPut(EnumType.Trimming.getName(), ",Component,TrimmingParams", ",o_ i_,i_");

         // links
         mapPut(EnumType.WebInlineFinishing.getName(), ",Assembly,Component,ProductionPath" + ",StrippingParams,WebInlineFinishingParams", ",i?,o_ i_,i?" + ",i?,i?");

         // links
         mapPut(EnumType.WireCombBinding.getName(), ",Component,WireCombBindingParams", ",o_ i_,i_");

         // links
         mapPut(EnumType.Wrapping.getName(), ",Component,WrappingParams,Media", ",o_ i_,i_,i?");

         // links
         mapPut(EnumType.PrepressPreparation.getName(), ",RunList,*", ",i_Document o_Document,i* o*");

         // links
         mapPut(EnumType.ImpositionPreparation.getName(), ",Layout,RunList,*", ",o_,i?Document o?Document o_Marks,,i* o*");
         // links
         mapPut(EnumType.RIPing.getName(), ",InterpretingParams,RenderingParams,RunList,*", ",i?,i?,o_ i_Document i?Marks,i* o*");

         // links
         mapPut(EnumType.PlateSetting.getName(), ",*,ExposedMedia,Preview", ",i* o*,o_,o*");
         // links
         mapPut(EnumType.PlateMaking.getName(), ",*,RunList,ExposedMedia,Preview,Media", ",i* o*,i_Document i?Marks,o_,o*,i_");
         // links
         mapPut(EnumType.ProofAndPlateMaking.getName(), ",*,RunList,ExposedMedia,Preview,Media", ",i* o*,i_Document i?Marks,o+,o*,i_");
         // links
         mapPut(EnumType.ImpositionProofing.getName(), ",*,RunList,ExposedMedia,Media", ",i* o*,i_Document i?Marks,o+,i_");
         // links
         mapPut(EnumType.PageProofing.getName(), ",*,RunList,ExposedMedia,Media", ",i* o*,i_Document i?Marks,o+,i_");

         // links
         mapPut(EnumType.PageSoftProofing.getName(), ",*,RunList", ",i* o*,i_Document i?Marks");
         // links
         mapPut(EnumType.ProofImaging.getName(), ",InterpretingParams,RenderingParams,RunList,*", ",i?,i?,i? i?Document i?Marks,i* o*");

      }
      private static AtrInfoTable[] atrInfoTable_root = new AtrInfoTable[2];

      private static AtrInfoTable[] atrInfoTable_Combined = new AtrInfoTable[1];

      private static AtrInfoTable[] atrInfoTable_PG = new AtrInfoTable[1];

      ///   
      ///	 <summary> * definition of optional attributes in the JDF namespace
      ///	 *  </summary>
      ///	 * <returns> comma separated list of optional attributes for JDF nodes </returns>
      ///	 
      protected internal override AttributeInfo getTheAttributeInfo()
      {
         AttributeInfo ai = base.getTheAttributeInfo().updateReplace(atrInfoTable_abstract);
         string nodeType = getType();
         if (JDFConstants.PROCESSGROUP.Equals(nodeType) && !hasChildElement(ElementName.JDF, null))
         {
            ai.updateAdd(atrInfoTable_PG);
         }
         else if (JDFConstants.COMBINED.Equals(nodeType))
         {
            ai.updateAdd(atrInfoTable_Combined);
         }

         if (isJDFRoot())
         {
            ai.updateReplace(atrInfoTable_root);
         }

         return ai;
      }

      private static ElemInfoTable[] elemInfoTable_abstract = new ElemInfoTable[6];

      private static ElemInfoTable[] elemInfoTable_root = new ElemInfoTable[1];

      private static ElemInfoTable[] elemInfoTable_JDF = new ElemInfoTable[1];

      ///   
      ///	 <summary> *  </summary>
      ///	 
      protected internal override ElementInfo getTheElementInfo()
      {
         ElementInfo ei = base.getTheElementInfo().updateReplace(elemInfoTable_abstract);

         string typ = getType();
         if (JDFConstants.PROCESSGROUP.Equals(typ) || JDFConstants.PRODUCT.Equals(typ))
         {
            ei.updateAdd(elemInfoTable_JDF);
         }

         if (isJDFRoot())
         {
            ei.updateAdd(elemInfoTable_root);
         }

         return ei;
      }

      ///   
      ///	 <summary> * Constructor for JDFNode
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFNode(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFNode
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFNode(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFNode
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFNode(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      ///   
      ///	 <summary> * Member Variablen </summary>
      ///	 
      private static Hashtable m_LinkNamesMap = new Hashtable();
      private static Hashtable m_LinkInfoMap = new Hashtable();

      private static readonly string[] m_GenericLinkInfo = { JDFConstants.INPUT_ZEROTOINFINITY, JDFConstants.INPUT_ZEROTOONE, JDFConstants.INPUT_ZEROTOINFINITY, JDFConstants.INPUT_ZEROTOINFINITY, JDFConstants.INPUT_ZEROTOINFINITY, JDFConstants.INPUT_ZEROTOONE, JDFConstants.INPUT_ZEROTOINFINITY, JDFConstants.INPUT_ZEROTOINFINITY, JDFConstants.INPUT_ZEROTOINFINITY, JDFConstants.INPUT_ZEROTOINFINITY };

      private static string[] m_strGenericLinkNames = { ElementName.APPROVALSUCCESS, ElementName.CUSTOMERINFO, ElementName.DEVICE, ElementName.EMPLOYEE, ElementName.MISCCONSUMABLE, ElementName.NODEINFO, ElementName.PREFLIGHTREPORT, ElementName.PREVIEW, ElementName.TOOL, ElementName.USAGECOUNTER };

      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Enumeration for the policy of cleaning up the Spawn and Merge audits </summary>
      ///	 
      public sealed class EnumCleanUpMerge : ValuedEnum
      {
         private const long serialVersionUID = 1L;

         private static int m_startValue = 0;

         //      
         //		 * (non-Javadoc)
         //		 * 
         //		 * @see org.apache.commons.lang.enums.ValuedEnum#toString()
         //		 
         public override string ToString()
         {
            return getName();
         }

         private EnumCleanUpMerge(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumCleanUpMerge getEnum(string enumName)
         {
            return (EnumCleanUpMerge)getEnum(typeof(EnumCleanUpMerge), enumName);
         }

         public static EnumCleanUpMerge getEnum(int enumValue)
         {
            return (EnumCleanUpMerge)getEnum(typeof(EnumCleanUpMerge), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumCleanUpMerge));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumCleanUpMerge));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumCleanUpMerge));
         }

         ///      
         ///		 <summary> * Constants EnumActivation </summary>
         ///		 
         public static readonly EnumCleanUpMerge None = new EnumCleanUpMerge(JDFConstants.CLEANUPMERGE_NONE);
         public static readonly EnumCleanUpMerge RemoveRRefs = new EnumCleanUpMerge(JDFConstants.CLEANUPMERGE_REMOVERREFS);
         public static readonly EnumCleanUpMerge RemoveAll = new EnumCleanUpMerge(JDFConstants.CLEANUPMERGE_REMOVEALL);
      }

      ///   
      ///	 <summary> * inner class EnumActivation:<br>
      ///	 * Enumeration for attribute Activation </summary>
      ///	 
      public sealed class EnumActivation : ValuedEnum
      {
         private const long serialVersionUID = 1L;

         private static int m_startValue = 0;

         private EnumActivation(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumActivation getEnum(string enumName)
         {
            return (EnumActivation)getEnum(typeof(EnumActivation), enumName);
         }

         public static EnumActivation getEnum(int enumValue)
         {
            return (EnumActivation)getEnum(typeof(EnumActivation), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumActivation));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumActivation));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumActivation));
         }

         public static readonly EnumActivation Unknown = null;

         public static readonly EnumActivation Inactive = new EnumActivation(JDFConstants.ACTIVATION_INACTIVE);
         public static readonly EnumActivation Informative = new EnumActivation(JDFConstants.ACTIVATION_INFORMATIVE);
         public static readonly EnumActivation Held = new EnumActivation(JDFConstants.ACTIVATION_HELD);
         public static readonly EnumActivation TestRun = new EnumActivation(JDFConstants.ACTIVATION_TESTRUN);
         public static readonly EnumActivation TestRunAndGo = new EnumActivation(JDFConstants.ACTIVATION_TESTRUNANDGO);
         public static readonly EnumActivation Active = new EnumActivation(JDFConstants.ACTIVATION_ACTIVE);
      }

      ///   
      ///	 <summary> * Constants EnumActivation use EnumActivation.xxx instead of the deprecated constants EnumActivation.Activation_xxx </summary>
      ///	 

      ///    @deprecated use EnumActivation.Inactive  
      ///	 
      [Obsolete("use EnumActivation.Inactive")]
      public static readonly EnumActivation Activation_Inactive = EnumActivation.Inactive;
      ///    @deprecated use EnumActivation.EnumActivation.Informative  
      ///	 
      [Obsolete("use EnumActivation.EnumActivation.Informative")]
      public static readonly EnumActivation Activation_Informative = EnumActivation.Informative;
      ///    @deprecated use EnumActivation.Held  
      ///	 
      [Obsolete("use EnumActivation.Held")]
      public static readonly EnumActivation Activation_Held = EnumActivation.Held;
      ///    @deprecated use EnumActivation.TestRun  
      ///	 
      [Obsolete("use EnumActivation.TestRun")]
      public static readonly EnumActivation Activation_TestRun = EnumActivation.TestRun;
      ///    @deprecated use EnumActivation.TestRunAndGo  
      ///	 
      [Obsolete("use EnumActivation.TestRunAndGo")]
      public static readonly EnumActivation Activation_TestRunAndGo = EnumActivation.TestRunAndGo;
      ///    @deprecated use EnumActivation.Active  
      ///	 
      [Obsolete("use EnumActivation.Active")]
      public static readonly EnumActivation Activation_Active = EnumActivation.Active;

      ///   
      ///	 <summary> * inner class EnumType: Enumeration for accessing typesafe node types </summary>
      ///	 
      public sealed class EnumType : ValuedEnum
      {
         private const long serialVersionUID = 1L;

         private static int m_startValue = 0;

         private EnumType(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumType getEnum(string enumName)
         {
            EnumType myEnum = (EnumType)getEnum(typeof(EnumType), enumName);
            return myEnum;
         }

         public static EnumType getEnum(int enumValue)
         {
            return (EnumType)getEnum(typeof(EnumType), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumType));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumType));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumType));
         }

         // generic
         public static readonly EnumType ProcessGroup = new EnumType(JDFConstants.TYPE_PROCESSGROUP);
         public static readonly EnumType Combined = new EnumType(JDFConstants.TYPE_COMBINED);
         public static readonly EnumType Product = new EnumType(JDFConstants.TYPE_PRODUCT);
         public static readonly EnumType Approval = new EnumType(JDFConstants.TYPE_APPROVAL);
         public static readonly EnumType Buffer = new EnumType(JDFConstants.TYPE_BUFFER);
         public static readonly EnumType Combine = new EnumType(JDFConstants.TYPE_COMBINE);
         public static readonly EnumType Delivery = new EnumType(JDFConstants.TYPE_DELIVERY);
         public static readonly EnumType ManualLabor = new EnumType(JDFConstants.TYPE_MANUALLABOR);
         public static readonly EnumType Ordering = new EnumType(JDFConstants.TYPE_ORDERING);
         public static readonly EnumType Packing = new EnumType(JDFConstants.TYPE_PACKING);
         public static readonly EnumType QualityControl = new EnumType(JDFConstants.TYPE_QUALITYCONTROL);
         public static readonly EnumType ResourceDefinition = new EnumType(JDFConstants.TYPE_RESOURCEDEFINITION);
         public static readonly EnumType Split = new EnumType(JDFConstants.TYPE_SPLIT);
         public static readonly EnumType Verification = new EnumType(JDFConstants.TYPE_VERIFICATION);

         // prepress
         public static readonly EnumType AssetListCreation = new EnumType(JDFConstants.TYPE_ASSETLISTCREATION);
         public static readonly EnumType Bending = new EnumType(JDFConstants.TYPE_BENDING);
         public static readonly EnumType ColorCorrection = new EnumType(JDFConstants.TYPE_COLORCORRECTION);
         public static readonly EnumType ColorSpaceConversion = new EnumType(JDFConstants.TYPE_COLORSPACECONVERSION);
         public static readonly EnumType ContactCopying = new EnumType(JDFConstants.TYPE_CONTACTCOPYING);
         public static readonly EnumType ContoneCalibration = new EnumType(JDFConstants.TYPE_CONTONECALIBRATION);
         public static readonly EnumType CylinderLayoutPreparation = new EnumType(JDFConstants.TYPE_CYLINDERLAYOUTPREPARATION);
         public static readonly EnumType DBDocTemplateLayout = new EnumType(JDFConstants.TYPE_DBDOCTEMPLATELAYOUT);
         public static readonly EnumType DBTemplateMerging = new EnumType(JDFConstants.TYPE_DBTEMPLATEMERGING);
         public static readonly EnumType DigitalDelivery = new EnumType(JDFConstants.TYPE_DIGITALDELIVERY);
         public static readonly EnumType FilmToPlateCopying = new EnumType(JDFConstants.TYPE_FILMTOPLATECOPYING);
         public static readonly EnumType FormatConversion = new EnumType(JDFConstants.TYPE_FORMATCONVERSION);
         public static readonly EnumType ImageReplacement = new EnumType(JDFConstants.TYPE_IMAGEREPLACEMENT);
         public static readonly EnumType ImageSetting = new EnumType(JDFConstants.TYPE_IMAGESETTING);
         public static readonly EnumType Imposition = new EnumType(JDFConstants.TYPE_IMPOSITION);
         public static readonly EnumType InkZoneCalculation = new EnumType(JDFConstants.TYPE_INKZONECALCULATION);
         public static readonly EnumType Interpreting = new EnumType(JDFConstants.TYPE_INTERPRETING);
         public static readonly EnumType LayoutElementProduction = new EnumType(JDFConstants.TYPE_LAYOUTELEMENTPRODUCTION);
         public static readonly EnumType LayoutPreparation = new EnumType(JDFConstants.TYPE_LAYOUTPREPARATION);
         public static readonly EnumType PDFToPSConversion = new EnumType(JDFConstants.TYPE_PDFTOPSCONVERSION);
         public static readonly EnumType PDLCreation = new EnumType(JDFConstants.TYPE_PDLCREATION);
         public static readonly EnumType Preflight = new EnumType(JDFConstants.TYPE_PREFLIGHT);
         public static readonly EnumType PreviewGeneration = new EnumType(JDFConstants.TYPE_PREVIEWGENERATION);
         public static readonly EnumType Proofing = new EnumType(JDFConstants.TYPE_PROOFING);
         public static readonly EnumType PSToPDFConversion = new EnumType(JDFConstants.TYPE_PSTOPDFCONVERSION);
         public static readonly EnumType RasterReading = new EnumType(JDFConstants.TYPE_RASTERREADING);
         public static readonly EnumType Rendering = new EnumType(JDFConstants.TYPE_RENDERING);
         public static readonly EnumType RIPing = new EnumType("RIPing");
         public static readonly EnumType Scanning = new EnumType(JDFConstants.TYPE_SCANNING);
         public static readonly EnumType Screening = new EnumType(JDFConstants.TYPE_SCREENING);
         public static readonly EnumType Separation = new EnumType(JDFConstants.TYPE_SEPARATION);
         public static readonly EnumType SoftProofing = new EnumType(JDFConstants.TYPE_SOFTPROOFING);
         public static readonly EnumType Stripping = new EnumType(JDFConstants.TYPE_STRIPPING);
         public static readonly EnumType Tiling = new EnumType(JDFConstants.TYPE_TILING);
         public static readonly EnumType Trapping = new EnumType(JDFConstants.TYPE_TRAPPING);

         // press
         public static readonly EnumType ConventionalPrinting = new EnumType(JDFConstants.TYPE_CONVENTIONALPRINTING);
         public static readonly EnumType DigitalPrinting = new EnumType(JDFConstants.TYPE_DIGITALPRINTING);
         public static readonly EnumType IDPrinting = new EnumType(JDFConstants.TYPE_IDPRINTING);

         // postpress
         public static readonly EnumType AdhesiveBinding = new EnumType(JDFConstants.TYPE_ADHESIVEBINDING);
         public static readonly EnumType BlockPreparation = new EnumType(JDFConstants.TYPE_BLOCKPREPARATION);
         public static readonly EnumType BoxPacking = new EnumType(JDFConstants.TYPE_BOXPACKING);
         public static readonly EnumType BoxFolding = new EnumType(JDFConstants.TYPE_BOXFOLDING);
         public static readonly EnumType Bundling = new EnumType(JDFConstants.TYPE_BUNDLING);
         public static readonly EnumType CaseMaking = new EnumType(JDFConstants.TYPE_CASEMAKING);
         public static readonly EnumType CasingIn = new EnumType(JDFConstants.TYPE_CASINGIN);
         public static readonly EnumType ChannelBinding = new EnumType(JDFConstants.TYPE_CHANNELBINDING);
         public static readonly EnumType CoilBinding = new EnumType(JDFConstants.TYPE_COILBINDING);
         public static readonly EnumType Collecting = new EnumType(JDFConstants.TYPE_COLLECTING);
         public static readonly EnumType CoverApplication = new EnumType(JDFConstants.TYPE_COVERAPPLICATION);
         public static readonly EnumType Creasing = new EnumType(JDFConstants.TYPE_CREASING);
         public static readonly EnumType Cutting = new EnumType(JDFConstants.TYPE_CUTTING);
         public static readonly EnumType Dividing = new EnumType(JDFConstants.TYPE_DIVIDING);
         public static readonly EnumType Embossing = new EnumType(JDFConstants.TYPE_EMBOSSING);
         public static readonly EnumType EndSheetGluing = new EnumType(JDFConstants.TYPE_ENDSHEETGLUING);
         public static readonly EnumType Feeding = new EnumType(JDFConstants.TYPE_FEEDING);
         public static readonly EnumType Folding = new EnumType(JDFConstants.TYPE_FOLDING);
         public static readonly EnumType Gathering = new EnumType(JDFConstants.TYPE_GATHERING);
         public static readonly EnumType Gluing = new EnumType(JDFConstants.TYPE_GLUING);
         public static readonly EnumType HeadBandApplication = new EnumType(JDFConstants.TYPE_HEADBANDAPPLICATION);
         public static readonly EnumType HoleMaking = new EnumType(JDFConstants.TYPE_HOLEMAKING);
         public static readonly EnumType Inserting = new EnumType(JDFConstants.TYPE_INSERTING);
         public static readonly EnumType Jacketing = new EnumType(JDFConstants.TYPE_JACKETING);
         public static readonly EnumType Labeling = new EnumType(JDFConstants.TYPE_LABELING);
         public static readonly EnumType Laminating = new EnumType(JDFConstants.TYPE_LAMINATING);
         public static readonly EnumType LongitudinalRibbonOperations = new EnumType(JDFConstants.TYPE_LONGITUDINALRIBBONOPERATIONS);
         public static readonly EnumType Numbering = new EnumType(JDFConstants.TYPE_NUMBERING);
         public static readonly EnumType Palletizing = new EnumType(JDFConstants.TYPE_PALLETIZING);
         public static readonly EnumType Perforating = new EnumType(JDFConstants.TYPE_PERFORATING);
         public static readonly EnumType PlasticCombBinding = new EnumType(JDFConstants.TYPE_PLASTICCOMBBINDING);
         public static readonly EnumType PrintRolling = new EnumType(JDFConstants.TYPE_PRINTROLLING);
         public static readonly EnumType RingBinding = new EnumType(JDFConstants.TYPE_RINGBINDING);
         public static readonly EnumType SaddleStitching = new EnumType(JDFConstants.TYPE_SADDLESTITCHING);
         public static readonly EnumType ShapeCutting = new EnumType(JDFConstants.TYPE_SHAPECUTTING);
         public static readonly EnumType Shrinking = new EnumType(JDFConstants.TYPE_SHRINKING);
         public static readonly EnumType SideSewing = new EnumType(JDFConstants.TYPE_SIDESEWING);
         public static readonly EnumType SpinePreparation = new EnumType(JDFConstants.TYPE_SPINEPREPARATION);
         public static readonly EnumType SpineTaping = new EnumType(JDFConstants.TYPE_SPINETAPING);
         public static readonly EnumType Stacking = new EnumType(JDFConstants.TYPE_STACKING);
         public static readonly EnumType Stitching = new EnumType(JDFConstants.TYPE_STITCHING);
         public static readonly EnumType Strapping = new EnumType(JDFConstants.TYPE_STRAPPING);
         public static readonly EnumType StripBinding = new EnumType(JDFConstants.TYPE_STRIPBINDING);
         public static readonly EnumType ThreadSealing = new EnumType(JDFConstants.TYPE_THREADSEALING);
         public static readonly EnumType ThreadSewing = new EnumType(JDFConstants.TYPE_THREADSEWING);
         public static readonly EnumType Trimming = new EnumType(JDFConstants.TYPE_TRIMMING);
         public static readonly EnumType WebInlineFinishing = new EnumType(JDFConstants.TYPE_WEBINLINEFINISHING);
         public static readonly EnumType WireCombBinding = new EnumType(JDFConstants.TYPE_WIRECOMBBINDING);
         public static readonly EnumType Wrapping = new EnumType(JDFConstants.TYPE_WRAPPING);

         // prepress gray box types
         public static readonly EnumType PlateSetting = new EnumType("PlateSetting");
         public static readonly EnumType PlateMaking = new EnumType("PlateMaking");
         public static readonly EnumType ProofAndPlateMaking = new EnumType("ProofAndPlateMaking");
         public static readonly EnumType ImpositionPreparation = new EnumType("ImpositionPreparation");
         public static readonly EnumType ImpositionProofing = new EnumType("ImpositionProofing");
         public static readonly EnumType PageProofing = new EnumType("PageProofing");
         public static readonly EnumType PageSoftProofing = new EnumType("PageSoftProofing");
         public static readonly EnumType PrepressPreparation = new EnumType("PrePressPreparation");
         public static readonly EnumType ProofImaging = new EnumType("ProofImaging");
      }

      ///   
      ///	 <summary> * Constants EnumType use EnumType.xxx instead of the deprecated constants EnumType.Type_xxx </summary>
      ///	 
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_ProcessGroup = EnumType.ProcessGroup;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Combined = EnumType.Combined;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Product = EnumType.Product;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Approval = EnumType.Approval;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Buffer = EnumType.Buffer;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Combine = EnumType.Combine;
      /// @deprecated use EnumType.xxx  
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Delivery = EnumType.Delivery;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_ManualLabor = EnumType.ManualLabor;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Ordering = EnumType.Ordering;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Packing = EnumType.Packing;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_QualityControl = EnumType.QualityControl;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_ResourceDefinition = EnumType.ResourceDefinition;
      ///    @deprecated use EnumType.Type_xxx x  
      ///	 
      [Obsolete("use EnumType.Type_xxx x")]
      public static readonly EnumType Type_Split = EnumType.Split;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Verification = EnumType.Verification;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_AssetListCreation = EnumType.AssetListCreation;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_ColorCorrection = EnumType.ColorCorrection;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_ColorSpaceConversion = EnumType.ColorSpaceConversion;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_ContactCopying = EnumType.ContactCopying;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_ContoneCalibration = EnumType.ContoneCalibration;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_DBDocTemplateLayout = EnumType.DBDocTemplateLayout;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_DBTemplateMerging = EnumType.DBTemplateMerging;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_DigitalDelivery = EnumType.DigitalDelivery;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_FilmToPlateCopying = EnumType.FilmToPlateCopying;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_FormatConversion = EnumType.FormatConversion;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_ImageReplacement = EnumType.ImageReplacement;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_ImageSetting = EnumType.ImageSetting;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Imposition = EnumType.Imposition;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_InkZoneCalculation = EnumType.InkZoneCalculation;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Interpreting = EnumType.Interpreting;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_LayoutElementProduction = EnumType.LayoutElementProduction;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_LayoutPreparation = EnumType.LayoutPreparation;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_PDFToPSConversion = EnumType.PDFToPSConversion;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Preflight = EnumType.Preflight;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_PreviewGeneration = EnumType.PreviewGeneration;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Proofing = EnumType.Proofing;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_PSToPDFConversion = EnumType.PSToPDFConversion;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Rendering = EnumType.Rendering;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Scanning = EnumType.Scanning;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Screening = EnumType.Screening;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Separation = EnumType.Separation;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_SoftProofing = EnumType.SoftProofing;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Stripping = EnumType.Stripping;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Tiling = EnumType.Tiling;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Trapping = EnumType.Trapping;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_ConventionalPrinting = EnumType.ConventionalPrinting;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_DigitalPrinting = EnumType.DigitalPrinting;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_IDPrinting = EnumType.IDPrinting;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_AdhesiveBinding = EnumType.AdhesiveBinding;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_BlockPreparation = EnumType.BlockPreparation;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_BoxPacking = EnumType.BoxPacking;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Bundling = EnumType.Bundling;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_CaseMaking = EnumType.CaseMaking;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_CasingIn = EnumType.CasingIn;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_ChannelBinding = EnumType.ChannelBinding;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_CoilBinding = EnumType.CoilBinding;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Collecting = EnumType.Collecting;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_CoverApplication = EnumType.CoverApplication;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Creasing = EnumType.Creasing;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Cutting = EnumType.Cutting;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Dividing = EnumType.Dividing;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Embossing = EnumType.Embossing;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_EndSheetGluing = EnumType.EndSheetGluing;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Feeding = EnumType.Feeding;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Folding = EnumType.Folding;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Gathering = EnumType.Gathering;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Gluing = EnumType.Gluing;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_HeadBandApplication = EnumType.HeadBandApplication;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_HoleMaking = EnumType.HoleMaking;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Inserting = EnumType.Inserting;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Jacketing = EnumType.Jacketing;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Labeling = EnumType.Labeling;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Laminating = EnumType.Laminating;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_LongitudinalRibbonOperations = EnumType.LongitudinalRibbonOperations;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Numbering = EnumType.Numbering;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Palletizing = EnumType.Palletizing;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Perforating = EnumType.Perforating;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_PlasticCombBinding = EnumType.PlasticCombBinding;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_PrintRolling = EnumType.PrintRolling;
      ///    @deprecated use EnumType.xxx 
      ///	  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_RingBinding = EnumType.RingBinding;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_SaddleStitching = EnumType.SaddleStitching;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_ShapeCutting = EnumType.ShapeCutting;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Shrinking = EnumType.Shrinking;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_SideSewing = EnumType.SideSewing;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_SpinePreparation = EnumType.SpinePreparation;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_SpineTaping = EnumType.SpineTaping;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Stacking = EnumType.Stacking;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Stitching = EnumType.Stitching;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Strapping = EnumType.Strapping;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_StripBinding = EnumType.StripBinding;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_ThreadSealing = EnumType.ThreadSealing;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_ThreadSewing = EnumType.ThreadSewing;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Trimming = EnumType.Trimming;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_WireCombBinding = EnumType.WireCombBinding;
      ///    @deprecated use EnumType.xxx  
      ///	 
      [Obsolete("use EnumType.xxx")]
      public static readonly EnumType Type_Wrapping = EnumType.Wrapping;

      ///   
      ///	 <summary> * add entries to a HashMap
      ///	 *  </summary>
      ///	 * <param name="key"> key for the new entry </param>
      ///	 * <param name="addon"> </param>
      ///	 * <param name="mMaps"> </param>
      ///	 * <param name="hm"> HashMap to add the new entry to </param>
      ///	 
      private static void nameMapPut(string key, string addon, string[] mMaps, Hashtable hm)
      {
         VString vs = new VString(StringUtil.tokenize(addon, JDFConstants.COMMA, false));
         string[] v = new string[mMaps.Length + vs.Count];
         int i = 0;
         for (; i < mMaps.Length; i++)
         {
            v[i] = mMaps[i];
         }
         for (i = 0; i < vs.Count; i++)
         {
            v[i + mMaps.Length] = vs.stringAt(i);
         }
         hm.Add(key, v);
      }

      ///   
      ///	 <summary> * add new entries to m_strGenericLinkNames and m_GenericLinkInfo
      ///	 *  </summary>
      ///	 * <param name="key"> key for the new entry </param>
      ///	 * <param name="nameAddon"> value of the new entry in m_strGenericLinkNames </param>
      ///	 * <param name="linkAddon"> value of the new entry in m_GenericLinkInfo </param>
      ///	 
      private static void mapPut(string key, string nameAddon, string linkAddon)
      {
         nameMapPut(key, nameAddon, m_strGenericLinkNames, m_LinkNamesMap);
         nameMapPut(key, linkAddon, m_GenericLinkInfo, m_LinkInfoMap);
      }

      // Note: This MUST be behind the enum declaration because the enums are used

      // **************************************** Constructors
      // ****************************************
      // NEWWWW

      public class CombinedProcessIndexHelper
      {
         ///      
         ///		 * <param name="jdfResource"> </param>
         ///		 * <param name="usage"> </param>
         ///		 * <param name="processUsage"> </param>
         ///		 * <param name="resourceLink"> </param>
         ///		 * <param name="types"> </param>
         ///		 
         public static void generateCombinedProcessIndex(JDFResource jdfResource, EnumUsage usage, EnumProcessUsage processUsage, JDFResourceLink resourceLink, VString types)
         {
            JDFIntegerList cpi = new JDFIntegerList();
            string resName = jdfResource.LocalName;
            int typSize = types.Count;
            int lastGot = -2; // not -1!!!
            string[] typeLinkNamesLast = null;
            for (int i = 0; i < typSize; i++)
            {
               bool bAddCPI = false;
               EnumType t = EnumType.getEnum(types.stringAt(i));
               string[] typeLinkNames_ = typeLinkNames(t);
               if (typeLinkNames_ != null && ArrayUtils.Contains(typeLinkNames_, resName))
               {
                  // if we already added a cpi, but this is an exchange
                  // resource, only set cpi for the last one
                  int iPos = ArrayUtils.IndexOf(typeLinkNames_, resName);
                  VString typeInfo = new VString(StringUtil.tokenize(typeLinkInfo(t)[iPos], " ", false));
                  bool bMatchUsage = false;
                  string inOut = null;
                  if (usage != null)
                  {
                     inOut = usage == EnumUsage.Input ? "i" : "o";
                  }

                  for (int ti = 0; ti < typeInfo.Count; ti++)
                  {
                     string sti = typeInfo.stringAt(ti);
                     if (inOut == null || sti.StartsWith(inOut))
                     {
                        if (processUsage == null || processUsage.getName().Equals(sti.Substring(2)))
                        {
                           bMatchUsage = true;
                           bAddCPI = true;
                           break; // one match is enough!
                        }
                     }
                  }
                  if (bMatchUsage && lastGot == i - 1)
                  {
                     bAddCPI = cleanCombinedProcessIndex(usage, types, cpi, resName, lastGot, typeLinkNamesLast, bAddCPI, typeInfo);
                  }
                  if (bAddCPI)
                  {
                     cpi.Add(i);
                  }
                  lastGot = i;
                  typeLinkNamesLast = typeLinkNames_;
               }
            }
            if (cpi.Count > 0)
            {
               resourceLink.setCombinedProcessIndex(cpi);
            }
         }

         ///      
         ///		 <summary> * remove any duplicate combinedprocessusages
         ///		 *  </summary>
         ///		 * <param name="usage"> </param>
         ///		 * <param name="types"> </param>
         ///		 * <param name="cpi"> </param>
         ///		 * <param name="resName"> </param>
         ///		 * <param name="lastGot"> </param>
         ///		 * <param name="typeLinkNamesLast"> </param>
         ///		 * <param name="bAddCPI"> </param>
         ///		 * <param name="typeInfo"> </param>
         ///		 * <returns> boolean </returns>
         ///		 
         protected internal static bool cleanCombinedProcessIndex(EnumUsage usage, VString types, JDFIntegerList cpi, string resName, int lastGot, string[] typeLinkNamesLast, bool bAddCPI, VString typeInfo)
         {
            bool bAddCPILocal = bAddCPI;

            int iPosLast = ArrayUtils.IndexOf(typeLinkNamesLast, resName);
            // the i* i?pu ... list of this
            // the o* i?pu ... list of the previous type
            VString typeInfoLast = new VString(StringUtil.tokenize(typeLinkInfo(EnumType.getEnum(types.stringAt(lastGot)))[iPosLast], " ", false));
            bool bOut = false;

            for (int ii = 0; ii < typeInfoLast.Count; ii++)
            {
               if (typeInfoLast.stringAt(ii).StartsWith("o"))
               {
                  bOut = true; // we found a matching output
                  break;
               }
            }

            if (bOut)
            {
               bool bIn = false;
               bOut = false;
               for (int ii = 0; ii < typeInfo.Count; ii++)
               {
                  if (!bIn && typeInfo.stringAt(ii).StartsWith("i"))
                  {
                     bIn = true; // after finding a matching output in last,
                     // we find an input here
                  }

                  if (!bOut && typeInfo.stringAt(ii).StartsWith("o"))
                  {
                     bOut = true; // after finding a matching output in last,
                     // we find an input here
                  }
               }

               if (bIn && bOut)
               { // remove the last output if we found a pass through
                  if (EnumUsage.Input.Equals(usage))
                  {
                     bAddCPILocal = false;
                  }
                  else
                  {
                     cpi.RemoveAt(-1);
                     bAddCPILocal = true;
                  }
               }
               else
               {
                  // not continuous - reset
                  bAddCPILocal = true;
               }
            }

            return bAddCPILocal;
         }
      }

      ///   
      ///	 <summary> * class to identify nodes even after parsing, e.g in hashmaps <br/> uses JobID, JobPartID and the partMapVector as
      ///	 * identifier
      ///	 *  </summary>
      ///	 
      public sealed class NodeIdentifier : IMatches, INodeIdentifiable
      {
         private string _jobID;
         private string _jobPartID;
         private VJDFAttributeMap _partMapVector;

         public NodeIdentifier(string jobID, string jobPartID, VJDFAttributeMap partMapVector)
         {
            setTo(jobID, jobPartID, partMapVector);
         }

         ///      
         ///		 * <param name="jobID"> </param>
         ///		 * <param name="jobPartID"> </param>
         ///		 * <param name="partMapVector"> </param>
         ///		 
         public void setTo(string jobID, string jobPartID, VJDFAttributeMap partMapVector)
         {
            _jobID = isWildCard(jobID) ? null : jobID;
            _jobPartID = isWildCard(jobPartID) ? null : jobPartID;
            _partMapVector = partMapVector;
         }

         public NodeIdentifier()
         {
            setTo(null, null, null);

         }

         ///      
         ///		 <summary> * sets a NodeIdentifier to a given JDF node identifier uses the AncestorPool or NodeInfo or output resource in that
         ///		 * sequence to determine the partmap
         ///		 *  </summary>
         ///		 * <param name="n"> </param>
         ///		 
         public void setIdentifier(NodeIdentifier n)
         {
            if (n == null)
               setTo(null, null, null);
            else
               setTo(n._jobID, n._jobPartID, n._partMapVector);
         }

         ///      
         ///		 <summary> * sets a NodeIdentifier to a given JDF node
         ///		 *  </summary>
         ///		 * <param name="n"> </param>
         ///		 
         public void setTo(INodeIdentifiable qe)
         {
            if (qe == null)
               setTo(null, null, null);
            else
               setIdentifier(qe.getIdentifier());
         }

         ///      
         ///		 <summary> * creates a NodeIdentifier from a given QueueEntry
         ///		 *  </summary>
         ///		 * <param name="qe"> the queueEntry </param>
         ///		 
         public NodeIdentifier(INodeIdentifiable ni)
            : this()
         {
            setTo(ni);
         }

         //      
         //		 * (non-Javadoc)
         //		 * 
         //		 * @see java.lang.Object#equals(java.lang.Object)
         //		 
         public override bool Equals(object inObject)
         {
            if (!(inObject is INodeIdentifiable))
               return false;
            NodeIdentifier mt = ((INodeIdentifiable)inObject).getIdentifier();
            bool b = ContainerUtil.Equals(mt._jobID, _jobID);
            b = b && ContainerUtil.Equals(mt._jobPartID, _jobPartID);
            return b && ContainerUtil.Equals(mt._partMapVector, _partMapVector);

         }

         ///      
         ///		 <summary> * return true if the nodeIdentifier matches this, i.e. if all parameters match or o has matching wildcards, or
         ///		 * o==null
         ///		 *  </summary>
         ///		 * <seealso cref= IMatches </seealso>
         ///		 * <param name="o"> the nodeidentifier that this should match<br/> if o is a String, check for match with jobID
         ///		 *  </param>
         ///		 * <returns> true, if this matches o </returns>
         ///		 
         public bool matches(object o)
         {
            if (o == null)
               return true;
            if (o is string) // check for JobID only
               return ContainerUtil.Equals(_jobID, o);

            if (!(o is INodeIdentifiable))
               return false;
            NodeIdentifier niInput = ((INodeIdentifiable)o).getIdentifier();
            bool b = isWildCard(niInput._jobID) || ContainerUtil.Equals(niInput._jobID, _jobID);
            b = b && (isWildCard(niInput._jobID) || ContainerUtil.Equals(niInput._jobPartID, _jobPartID)) || (_jobPartID != null && niInput._jobPartID != null && niInput._jobPartID.StartsWith(_jobPartID + "."));
            return b && ((_partMapVector == null) || (_partMapVector != null && _partMapVector.overlapsMap(niInput._partMapVector)));
         }

         //      
         //		 * (non-Javadoc)
         //		 * 
         //		 * @see java.lang.Object#hashCode()
         //		 
         public override int GetHashCode()
         {
            return (_jobID == null ? 0 : _jobID.GetHashCode()) + (_jobPartID == null ? 0 : _jobPartID.GetHashCode()) + (_partMapVector == null ? 0 : _partMapVector.GetHashCode());
         }

         //      
         //		 * (non-Javadoc)
         //		 * 
         //		 * @see java.lang.Object#toString()
         //		 
         public override string ToString()
         {
            return "NodeIdentifier :" + _jobID + " " + _jobPartID + "\n" + _partMapVector;
         }

         public string getJobID()
         {
            return _jobID;
         }

         public string getJobPartID()
         {
            return _jobPartID;
         }

         public VJDFAttributeMap getPartMapVector()
         {
            return _partMapVector;
         }

         ///      
         ///		 <summary> * formalism so zhat we can use this as a <seealso cref="INodeIdentifiable"/>
         ///		 *  </summary>
         ///		 * <seealso cref= org.cip4.jdflib.ifaces.INodeIdentifiable#getIdentifier() </seealso>
         ///		 
         public NodeIdentifier getIdentifier()
         {
            return this;
         }

      }

      ///   
      ///	 <summary> * Enumeration for accessing typesafe nodes </summary>
      ///	 
      public sealed class EnumProcessUsage : ValuedEnum
      {
         private const long serialVersionUID = 1L;

         private static int m_startValue = 0;

         private EnumProcessUsage(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumProcessUsage getEnum(string enumName)
         {
            return (EnumProcessUsage)getEnum(typeof(EnumProcessUsage), enumName);
         }

         public static EnumProcessUsage getEnum(int enumValue)
         {
            return (EnumProcessUsage)getEnum(typeof(EnumProcessUsage), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumProcessUsage));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumProcessUsage));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumProcessUsage));
         }

         public static readonly EnumProcessUsage AnyInput = new EnumProcessUsage(JDFConstants.PROCESSUSAGE_ANYINPUT);
         public static readonly EnumProcessUsage AnyOutput = new EnumProcessUsage(JDFConstants.PROCESSUSAGE_ANYOUTPUT);
         ///      
         ///		 * @deprecated use null instead 
         ///		 
         [Obsolete("use null instead")]
         public static readonly EnumProcessUsage Any = new EnumProcessUsage(JDFConstants.PROCESSUSAGE_ANY);
         public static readonly EnumProcessUsage Rejected = new EnumProcessUsage(JDFConstants.PROCESSUSAGE_REJECTED);
         public static readonly EnumProcessUsage Accepted = new EnumProcessUsage(JDFConstants.PROCESSUSAGE_ACCEPTED);
         public static readonly EnumProcessUsage Application = new EnumProcessUsage(JDFConstants.PROCESSUSAGE_APPLICATION);
         public static readonly EnumProcessUsage Marks = new EnumProcessUsage(JDFConstants.PROCESSUSAGE_MARKS);
         public static readonly EnumProcessUsage Document = new EnumProcessUsage(JDFConstants.PROCESSUSAGE_DOCUMENT);
         public static readonly EnumProcessUsage Surface = new EnumProcessUsage(JDFConstants.PROCESSUSAGE_SURFACE);
         public static readonly EnumProcessUsage Waste = new EnumProcessUsage(JDFConstants.PROCESSUSAGE_WASTE);
         public static readonly EnumProcessUsage Proof = new EnumProcessUsage(JDFConstants.PROCESSUSAGE_PROOF);
         public static readonly EnumProcessUsage Input = new EnumProcessUsage(JDFConstants.PROCESSUSAGE_INPUT);
         public static readonly EnumProcessUsage Plate = new EnumProcessUsage(JDFConstants.PROCESSUSAGE_PLATE);
         public static readonly EnumProcessUsage Cylinder = new EnumProcessUsage("Cylinder");
         public static readonly EnumProcessUsage Good = new EnumProcessUsage(JDFConstants.PROCESSUSAGE_GOOD);
         public static readonly EnumProcessUsage Cover = new EnumProcessUsage(JDFConstants.PROCESSUSAGE_COVER);
         public static readonly EnumProcessUsage BookBlock = new EnumProcessUsage(JDFConstants.PROCESSUSAGE_BOOKBLOCK);
         public static readonly EnumProcessUsage Box = new EnumProcessUsage(JDFConstants.PROCESSUSAGE_BOX);
         public static readonly EnumProcessUsage CoverMaterial = new EnumProcessUsage(JDFConstants.PROCESSUSAGE_COVERMATERIAL);
         public static readonly EnumProcessUsage SpineBoard = new EnumProcessUsage(JDFConstants.PROCESSUSAGE_SPINEBOARD);
         public static readonly EnumProcessUsage CoverBoard = new EnumProcessUsage(JDFConstants.PROCESSUSAGE_COVERBOARD);
         public static readonly EnumProcessUsage Case = new EnumProcessUsage(JDFConstants.PROCESSUSAGE_CASE);
         public static readonly EnumProcessUsage FrontEndSheet = new EnumProcessUsage(JDFConstants.PROCESSUSAGE_FRONTENDSHEET);
         public static readonly EnumProcessUsage BackEndSheet = new EnumProcessUsage(JDFConstants.PROCESSUSAGE_BACKENDSHEET);
         public static readonly EnumProcessUsage Child = new EnumProcessUsage(JDFConstants.PROCESSUSAGE_CHILD);
         public static readonly EnumProcessUsage Mother = new EnumProcessUsage(JDFConstants.PROCESSUSAGE_MOTHER);
         public static readonly EnumProcessUsage Jacket = new EnumProcessUsage(JDFConstants.PROCESSUSAGE_JACKET);
         public static readonly EnumProcessUsage Book = new EnumProcessUsage(JDFConstants.PROCESSUSAGE_BOOK);
         public static readonly EnumProcessUsage Label = new EnumProcessUsage(JDFConstants.PROCESSUSAGE_LABEL);
         public static readonly EnumProcessUsage RingBinder = new EnumProcessUsage(JDFConstants.PROCESSUSAGE_RINGBINDER);
         public static readonly EnumProcessUsage Ancestor = new EnumProcessUsage(JDFConstants.PROCESSUSAGE_ANCESTOR);
      }

      ///   
      ///	 <summary> * constants EnumProcessUsage use EnumProcessUsage.xxx instead of the deprecated constants
      ///	 * EnumProcessUsage.ProcessUsage_xxx </summary>
      ///	 
      ///    @deprecated use EnumProcessUsage.xxx  
      ///	 
      [Obsolete("use EnumProcessUsage.xxx")]
      public static readonly EnumProcessUsage ProcessUsage_AnyInput = EnumProcessUsage.AnyInput;
      ///    @deprecated use EnumProcessUsage.xxx  
      ///	 
      [Obsolete("use EnumProcessUsage.xxx")]
      public static readonly EnumProcessUsage ProcessUsage_AnyOutput = EnumProcessUsage.AnyOutput;
      ///    @deprecated use EnumProcessUsage.xxx  
      ///	 
      [Obsolete("use EnumProcessUsage.xxx")]
      public static readonly EnumProcessUsage ProcessUsage_Any = null; //EnumProcessUsage.Any;
      ///    @deprecated use EnumProcessUsage.xxx  
      ///	 
      [Obsolete("use EnumProcessUsage.xxx")]
      public static readonly EnumProcessUsage ProcessUsage_Rejected = EnumProcessUsage.Rejected;
      ///    @deprecated use EnumProcessUsage.xxx  
      ///	 
      [Obsolete("use EnumProcessUsage.xxx")]
      public static readonly EnumProcessUsage ProcessUsage_Accepted = EnumProcessUsage.Accepted;
      ///    @deprecated use EnumProcessUsage.xxx  
      ///	 
      [Obsolete("use EnumProcessUsage.xxx")]
      public static readonly EnumProcessUsage ProcessUsage_Marks = EnumProcessUsage.Marks;
      ///    @deprecated use EnumProcessUsage.xxx  
      ///	 
      [Obsolete("use EnumProcessUsage.xxx")]
      public static readonly EnumProcessUsage ProcessUsage_Document = EnumProcessUsage.Document;
      ///    @deprecated use EnumProcessUsage.xxx  
      ///	 
      [Obsolete("use EnumProcessUsage.xxx")]
      public static readonly EnumProcessUsage ProcessUsage_Surface = EnumProcessUsage.Surface;
      ///    @deprecated use EnumProcessUsage.xxx  
      ///	 
      [Obsolete("use EnumProcessUsage.xxx")]
      public static readonly EnumProcessUsage ProcessUsage_Waste = EnumProcessUsage.Waste;
      ///    @deprecated use EnumProcessUsage.xxx  
      ///	 
      [Obsolete("use EnumProcessUsage.xxx")]
      public static readonly EnumProcessUsage ProcessUsage_Proof = EnumProcessUsage.Proof;
      ///    @deprecated use EnumProcessUsage.xxx  
      ///	 
      [Obsolete("use EnumProcessUsage.xxx")]
      public static readonly EnumProcessUsage ProcessUsage_Input = EnumProcessUsage.Input;
      ///    @deprecated use EnumProcessUsage.xxx  
      ///	 
      [Obsolete("use EnumProcessUsage.xxx")]
      public static readonly EnumProcessUsage ProcessUsage_Plate = EnumProcessUsage.Plate;
      ///    @deprecated use EnumProcessUsage.xxx  
      ///	 
      [Obsolete("use EnumProcessUsage.xxx")]
      public static readonly EnumProcessUsage ProcessUsage_Good = EnumProcessUsage.Good;
      ///    @deprecated use EnumProcessUsage.xxx  
      ///	 
      [Obsolete("use EnumProcessUsage.xxx")]
      public static readonly EnumProcessUsage ProcessUsage_Cover = EnumProcessUsage.Cover;
      ///    @deprecated use EnumProcessUsage.xxx  
      ///	 
      [Obsolete("use EnumProcessUsage.xxx")]
      public static readonly EnumProcessUsage ProcessUsage_BookBlock = EnumProcessUsage.BookBlock;
      ///    @deprecated use EnumProcessUsage.xxx  
      ///	 
      [Obsolete("use EnumProcessUsage.xxx")]
      public static readonly EnumProcessUsage ProcessUsage_Box = EnumProcessUsage.Box;
      ///    @deprecated use EnumProcessUsage.xxx  
      ///	 
      [Obsolete("use EnumProcessUsage.xxx")]
      public static readonly EnumProcessUsage ProcessUsage_CoverMaterial = EnumProcessUsage.CoverMaterial;
      ///    @deprecated use EnumProcessUsage.xxx  
      ///	 
      [Obsolete("use EnumProcessUsage.xxx")]
      public static readonly EnumProcessUsage ProcessUsage_SpineBoard = EnumProcessUsage.SpineBoard;
      ///    @deprecated use EnumProcessUsage.xxx  
      ///	 
      [Obsolete("use EnumProcessUsage.xxx")]
      public static readonly EnumProcessUsage ProcessUsage_CoverBoard = EnumProcessUsage.CoverBoard;
      ///    @deprecated use EnumProcessUsage.xxx  
      ///	 
      [Obsolete("use EnumProcessUsage.xxx")]
      public static readonly EnumProcessUsage ProcessUsage_Case = EnumProcessUsage.Case;
      ///    @deprecated use EnumProcessUsage.xxx  
      ///	 
      [Obsolete("use EnumProcessUsage.xxx")]
      public static readonly EnumProcessUsage ProcessUsage_FrontEndSheet = EnumProcessUsage.FrontEndSheet;
      ///    @deprecated use EnumProcessUsage.xxx  
      ///	 
      [Obsolete("use EnumProcessUsage.xxx")]
      public static readonly EnumProcessUsage ProcessUsage_BackEndSheet = EnumProcessUsage.BackEndSheet;
      ///    @deprecated use EnumProcessUsage.xxx  
      ///	 
      [Obsolete("use EnumProcessUsage.xxx")]
      public static readonly EnumProcessUsage ProcessUsage_Child = EnumProcessUsage.Child;
      ///    @deprecated use EnumProcessUsage.xxx  
      ///	 
      [Obsolete("use EnumProcessUsage.xxx")]
      public static readonly EnumProcessUsage ProcessUsage_Mother = EnumProcessUsage.Mother;
      ///    @deprecated use EnumProcessUsage.xxx  
      ///	 
      [Obsolete("use EnumProcessUsage.xxx")]
      public static readonly EnumProcessUsage ProcessUsage_Jacket = EnumProcessUsage.Jacket;
      ///    @deprecated use EnumProcessUsage.xxx  
      ///	 
      [Obsolete("use EnumProcessUsage.xxx")]
      public static readonly EnumProcessUsage ProcessUsage_Book = EnumProcessUsage.Book;
      ///    @deprecated use EnumProcessUsage.xxx  
      ///	 
      [Obsolete("use EnumProcessUsage.xxx")]
      public static readonly EnumProcessUsage ProcessUsage_Label = EnumProcessUsage.Label;
      ///    @deprecated use EnumProcessUsage.xxx  
      ///	 
      [Obsolete("use EnumProcessUsage.xxx")]
      public static readonly EnumProcessUsage ProcessUsage_RingBinder = EnumProcessUsage.RingBinder;
      ///    @deprecated use EnumProcessUsage.xxx  
      ///	 
      [Obsolete("use EnumProcessUsage.xxx")]
      public static readonly EnumProcessUsage ProcessUsage_Ancestor = EnumProcessUsage.Ancestor;

      // **************************************** Methods
      // *********************************************
      ///   
      ///	 <summary> * toString - StringRepresentation of JDFNode
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public override string ToString()
      {
         return "JDFNode[ --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * init - init the node
      ///	 *  </summary>
      ///	 * <returns> boolean: always true </returns>
      ///	 
      public override bool init()
      {
         if (hasAttribute(AttributeName.ID))
         {
            return false; // has previously been initialized
         }

         string id = appendAnchor(null);
         // 080612 moved from root only to all nodes
         ensureCreated();
         if (isJDFRoot())
         {
            // create a standard JDFRoot with namespace, version, comment and
            // audit pool
            addNameSpace(null, getSchemaURL());
            setVersion(getDefaultJDFVersion());

            string comment = "Generated by the CIP4 C# open source JDF Library version : ";
            comment += JDFAudit.software();
            appendXMLComment(comment, null);

            // set an initial jobpartid
            if (!hasAttribute(AttributeName.JOBPARTID))
            {
               setJobPartID(id);
            }
         }
         else
         {
            // set an initial jobpartid
            if (!hasAttribute(AttributeName.JOBPARTID))
            {
               setJobPartID(generateDotID(AttributeName.JOBPARTID, null));
            }
         }

         setStatus(JDFElement.EnumNodeStatus.Waiting);
         return true;
      }


      ///   
      ///	 <summary> * is this the JDF root element, i.e. it has no JDF above it
      ///	 *  </summary>
      ///	 * <returns> true, if this is a root </returns>
      ///	 
      public virtual bool isJDFRoot()
      {
         KElement e = getParentNode_KElement();
         if (e == null)
         {
            return true;
         }
         return !(e is JDFNode);
      }

      ////
      // TODO check if we really dont need this method. a processUsage.toString
      // should have the same effekt.
      // public String ProcessUsageString(EnumProcessUsage processUsage)
      // {
      // return ProcessUsageString().Token(processUsage,String.comma);
      // }
      //  
      ////

      ///   
      ///	 <summary> * definition of resource link names in the JDF namespace
      ///	 *  </summary>
      ///	 * <returns> String list of resource names that may be linked </returns>
      ///	 
      public virtual VString linkNames()
      {
         EnumType typ = EnumType.getEnum(getType());
         if (typ == null)
         {
            return null;
         }

         if (typ.Equals(EnumType.Combined) || (typ == EnumType.ProcessGroup && hasAttribute(AttributeName.TYPES)))
         {
            VString v = new VString(m_strGenericLinkNames);
            VString vTypes = getTypes();
            vTypes = expandGrayBoxTypes(vTypes);
            if (vTypes == null)
            {
               return null;
            }

            int size = vTypes.Count;
            for (int i = 0; i < size; i++)
            {
               EnumType t = EnumType.getEnum(vTypes.stringAt(i));
               string[] typeLinkNames_ = typeLinkNames(t);
               if (typeLinkNames_ == null)
               {
                  return null; // bail out - it's open anyhow
               }
               for (int j = m_strGenericLinkNames.Length; j < typeLinkNames_.Length; j++)
               {
                  v.Add(typeLinkNames_[j]);
               }
            }
            return v;
         }

         // sinmple single type
         string[] typeLinkNames2 = typeLinkNames(typ);
         if (typeLinkNames2 == null)
         {
            return null; // bail out - it's open anyhow
         }
         return new VString(typeLinkNames2);
      }

      ///   
      ///	 <summary> * Expand abstract types that are only valid in gray boxes to the respective explicit types
      ///	 *  </summary>
      ///	 * <param name="types"> </param>
      ///	 
      private VString expandGrayBoxTypes(VString types)
      {
         if (types == null)
         {
            return null;
         }
         VString vNew = new VString();
         for (int i = 0; i < types.Count; i++)
         {
            string typ = types.stringAt(i);
            // if(typ.equals("RIPing"))
            // {
            // vNew.add(EnumType.Imposition.getName());
            // vNew.add(EnumType.Interpreting.getName());
            // vNew.add(EnumType.ColorSpaceConversion.getName());
            // vNew.add(EnumType.Trapping.getName());
            // vNew.add(EnumType.Rendering.getName());
            // vNew.add(EnumType.Screening.getName());
            // }
            // else
            // {
            vNew.Add(typ);
            // }
         }
         return vNew;
      }

      ///   
      ///	 <summary> * definition of resource link usage, cardinality and ProcessUsage in the JDF namespace
      ///	 *  </summary>
      ///	 * <returns> String list of resource information usages that may be linked </returns>
      ///	 
      public virtual VString linkInfo()
      {
         EnumType typ = EnumType.getEnum(getType());
         if (typ == null)
         {
            return null;
         }
         if (typ.Equals(EnumType.Combined) || (typ == EnumType.ProcessGroup && hasAttribute(AttributeName.TYPES)))
         {

            VString vLinkInfo = new VString(m_GenericLinkInfo);
            VString vNames = new VString(m_strGenericLinkNames);

            VString vTypes = getTypes();
            vTypes = expandGrayBoxTypes(vTypes);
            if (vTypes == null)
            {
               return null;
            }
            int i = 0;
            for (i = 0; i < vTypes.Count; i++)
            {
               EnumType t = EnumType.getEnum(vTypes[i]);
               if (t == null)
               {
                  return null;
               }

               string[] typeLinkInfo_ = typeLinkInfo(t);
               string[] typeLinkNames_ = typeLinkNames(t);
               if (typeLinkInfo_ == null || typeLinkNames_ == null)
               {
                  return null;
               }

               for (int j = m_GenericLinkInfo.Length; j < typeLinkInfo_.Length; j++)
               {
                  vLinkInfo.Add(typeLinkInfo_[j]);
                  vNames.Add(typeLinkNames_[j]);
               }
            }

            // make the intermediate links optional
            int s = vLinkInfo.Count;
            // loop over all links
            for (i = 0; i < s; i++)
            {
               VString typeList = new VString(StringUtil.tokenize(vLinkInfo[i], JDFConstants.BLANK, false));
               for (int iTyp = 0; iTyp < typeList.Count; iTyp++)
               {
                  string strTyp = typeList[iTyp];
                  if (strTyp[0] == 'o')
                  {
                     string linkName = vNames[i];
                     // loop over all links behind this one in types
                     for (int j = i + 1; j < s; j++)
                     {
                        if (vNames[j].Equals(linkName))
                        { // if the names match, they should fit
                           bool bGotOne = false;

                           VString typeList2 = new VString(StringUtil.tokenize(vLinkInfo[j], JDFConstants.BLANK, false));

                           for (int iTyp2 = 0; iTyp2 < typeList2.Count; iTyp2++)
                           {
                              string typ2 = typeList2[iTyp2];
                              if (typ2[0] == 'i')
                              {
                                 bGotOne = true;
                                 // make them optional
                                 if (typ2[1] == '_')
                                 {
                                    char[] c_typ2 = typ2.ToCharArray();
                                    c_typ2[1] = '?';
                                    typ2 = new string(c_typ2);
                                 }
                                 else if (typ2[1] == '+')
                                 {
                                    char[] c_typ2 = typ2.ToCharArray();
                                    c_typ2[1] = '*';
                                    typ2 = new string(c_typ2);
                                 }
                                 typeList2[iTyp2] = typ2;
                              }
                           }
                           if (bGotOne)
                           {
                              // replace input link entry
                              vLinkInfo[j] = StringUtil.setvString(typeList2, JDFConstants.BLANK, null, null);
                              if (strTyp[1] == '_')
                              {
                                 char[] c_strTyp = strTyp.ToCharArray();
                                 c_strTyp[1] = '?';
                                 strTyp = new string(c_strTyp);
                              }
                              else if (strTyp[1] == '+')
                              {
                                 char[] c_strTyp = strTyp.ToCharArray();
                                 c_strTyp[1] = '*';
                                 strTyp = new string(c_strTyp);
                              }
                              typeList[iTyp] = strTyp;
                           }
                        }
                     }
                  }
               }
               vLinkInfo[i] = StringUtil.setvString(typeList, JDFConstants.BLANK, null, null);
            }
            return vLinkInfo;
         }
         return new VString(typeLinkInfo(typ));
      }

      ///   
      ///	 <summary> * definition of resource link names in the JDF namespace
      ///	 *  </summary>
      ///	 * <returns> String list of resource names that may be linked </returns>
      ///	 
      protected internal static string[] typeLinkNames(EnumType typeNum)
      {
         if (typeNum == null)
         {
            return null;
         }
         return (string[])m_LinkNamesMap[typeNum.getName()];
      }


      ///   
      ///	 <summary> * definition of resource link usage, cardinality and ProcessUsage in the JDF namespace for a given EnumType
      ///	 *  </summary>
      ///	 * <param name="typeNum"> EnumType to get LinkInfo for </param>
      ///	 * <returns> String list of resource information usages that may be linked for this EnumType </returns>
      ///	 
      protected internal static string[] typeLinkInfo(EnumType typeNum)
      {
         string[] strValueOfEnum = (string[])m_LinkInfoMap[typeNum.getName()];
         return (strValueOfEnum == null) ? m_GenericLinkInfo : strValueOfEnum;
      }

      // --------------------------------------------------------------------------

      ///   
      ///	 <summary> * sets the node's partition status and StatusDetails
      ///	 *  </summary>
      ///	 * <param name="vmattr"> vector Attribute maps of partition </param>
      ///	 * <param name="status"> Status to set </param>
      ///	 * <returns> boolean: success or not </returns>
      ///	 * @deprecated use 3 parameter version 
      ///	 
      [Obsolete("use 3 parameter version")]
      public virtual bool setPartStatus(VJDFAttributeMap vmattr, EnumNodeStatus status)
      {
         return setPartStatus(vmattr, status, null);
      }

      ///   
      ///	 <summary> * sets the node's partition status and StatusDetails
      ///	 *  </summary>
      ///	 * <param name="vmattr"> vector Attribute maps of partition </param>
      ///	 * <param name="status"> Status to set </param>
      ///	 * <returns> boolean: success or not </returns>
      ///	 
      public virtual bool setPartStatus(VJDFAttributeMap vmattr, EnumNodeStatus status, string statusDetails)
      {
         bool bRet = true;
         int siz = 0;

         if (vmattr != null)
         {
            siz = vmattr.Count;
            for (int i = 0; i < siz; i++)
            {
               bRet = setPartStatus(vmattr[i], status, statusDetails) && bRet;
            }
         }

         if (vmattr == null || siz == 0)
         {
            bRet = setPartStatus((JDFAttributeMap)null, status, statusDetails);
         }

         return bRet;
      }

      ///   
      ///	 <summary> * set the node's partition status if nodeinfo is partitioned, all leaves NodeStati below part are removed
      ///	 *  </summary>
      ///	 * <param name="mattr"> Attribute map of partition </param>
      ///	 * <param name="status"> Status to set </param>
      ///	 * <returns> boolean: success or not </returns>
      ///	 * @deprecated use 3 parameter version 
      ///	 
      [Obsolete("use 3 parameter version")]
      public virtual bool setPartStatus(JDFAttributeMap mattr, JDFElement.EnumNodeStatus status)
      {
         return setPartStatus(mattr, status, null);
      }

      ///   
      ///	 <summary> * set the node's partition status if nodeinfo is partitioned, all leaves NodeStati below part are removed
      ///	 *  </summary>
      ///	 * <param name="mattr"> Attribute map of partition </param>
      ///	 * <param name="status"> Status to set </param>
      ///	 * <returns> boolean: success or not </returns>
      ///	 
      public virtual bool setPartStatus(JDFAttributeMap mattr, JDFElement.EnumNodeStatus status, string statusDetails)
      {
         string statusDetailsLocal = statusDetails;

         EnumNodeStatus stat = getStatus();
         statusDetailsLocal = StringUtil.getNonEmpty(statusDetailsLocal);
         // 100602 handle nasty combination
         if (mattr != null && (!mattr.IsEmpty() && (status.Equals(JDFElement.EnumNodeStatus.Pool) || status.Equals(JDFElement.EnumNodeStatus.Part))))
         {
            // throw an exception??? this is a snafu to set an individual part
            // status to pool
            return false;
         }

         if (mattr == null || mattr.IsEmpty())
         {
            setStatus(status);
            if (statusDetailsLocal != null)
               setStatusDetails(statusDetailsLocal);
            removeChild(ElementName.STATUSPOOL, null, 0);
            if (getVersion(true).getValue() >= JDFElement.EnumVersion.Version_1_3.getValue())
            {
               JDFNodeInfo ni = getNodeInfo();
               if (ni != null)
               {
                  ni.removeAttributeFromLeaves(AttributeName.NODESTATUS, null);
                  ni.setNodeStatus(status);
                  if (statusDetailsLocal != null)
                  {
                     ni.removeAttributeFromLeaves(AttributeName.NODESTATUSDETAILS, null);
                     ni.setNodeStatusDetails(statusDetailsLocal);
                  }
               }
            }
            return true;
         }

         if (getVersion(true).getValue() < JDFElement.EnumVersion.Version_1_3.getValue())
         {
            // we are setting an individual attribute
            JDFStatusPool statusPool = getCreateStatusPool();

            if (!stat.Equals(JDFElement.EnumNodeStatus.Pool))
            {
               statusPool.setStatus(stat);
               setStatus(JDFElement.EnumNodeStatus.Pool);
            }

            statusPool.setStatus(mattr, status, statusDetailsLocal);

            // this can happen if status = the previous status
            // just remove the pool and reset the status to the original status

            if (statusPool.numChildElements(ElementName.PARTSTATUS, null) == 0)
            {
               setStatus(status);
               if (statusDetailsLocal != null)
                  setStatusDetails(statusDetailsLocal);
               statusPool.deleteNode();
            }
         }
         else
         // version >=1.3
         {
            JDFNodeInfo ni = getCreateNodeInfo();
            if (getStatus() != JDFElement.EnumNodeStatus.Part)
            { // set a decent default status for implicit
               ni.setNodeStatus(getStatus());
               if (statusDetailsLocal != null)
               {
                  ni.setNodeStatusDetails(statusDetailsLocal);
               }
            }

            ni.getResourceRoot().setPartUsage(JDFResource.EnumPartUsage.Implicit);
            VElement ve = ni.getPartitionVector(mattr, EnumPartUsage.Explicit);
            if (ve.IsEmpty()) // no preexisting matching partition - attempt to
            // create it
            {
               ve.Add(ni.getCreatePartition(mattr, null));
            }

            for (int i = 0; i < ve.Count; i++)
            {
               ni = (JDFNodeInfo)ve[i];
               ni.removeAttributeFromLeaves(AttributeName.NODESTATUS, null);
               ni.setNodeStatus(status);
               if (statusDetailsLocal != null)
               {
                  ni.removeAttributeFromLeaves(AttributeName.NODESTATUSDETAILS, null);
                  ni.setNodeStatusDetails(statusDetailsLocal);
               }
            }
            setStatus(JDFElement.EnumNodeStatus.Part);
         }
         return true;
      }

      ///   
      ///	 <summary> * get the status for the vector v </summary>
      ///	 * <param name="vMap"> the vevtor of partmaps </param>
      ///	 * <returns> the status, null if the value is not consistent </returns>
      ///	 
      public virtual EnumNodeStatus getVectorPartStatus(VJDFAttributeMap vMap)
      {
         if (vMap == null || vMap.Count == 0)
            return getPartStatus(null);
         EnumNodeStatus status = getPartStatus(vMap[0]);
         if (status == null)
            return null;
         for (int i = 1; i < vMap.Count; i++)
         {
            EnumNodeStatus status2 = getPartStatus(vMap[i]);
            if (!status.Equals(status2))
               return null;
         }
         return status;
      }

      ///   
      ///	 <summary> * get the statusdetails for the vector v </summary>
      ///	 * <param name="vMap"> the vevtor of partmaps </param>
      ///	 * <returns> the status, null if the value is not consistent </returns>
      ///	 
      public virtual string getVectorPartStatusDetails(VJDFAttributeMap vMap)
      {
         if (vMap == null || vMap.Count == 0)
            return getPartStatusDetails(null);
         string status = getPartStatusDetails(vMap[0]);
         if (status == null)
            return null;
         for (int i = 1; i < vMap.Count; i++)
         {
            string status2 = getPartStatusDetails(vMap[i]);
            if (!status.Equals(status2))
               return null;
         }
         return status;
      }

      ///////
      ///   
      ///	 <summary> * get the node's partition status
      ///	 *  </summary>
      ///	 * <param name="mattr"> Attribute map of partition </param>
      ///	 * <returns> JDFElement.EnumNodeStatus: Status of the partition, null if no Status exists </returns>
      ///	 
      public virtual JDFElement.EnumNodeStatus getPartStatus(JDFAttributeMap mattr)
      {
         EnumNodeStatus stat = getStatus();
         if ((stat != EnumNodeStatus.Pool) && (stat != EnumNodeStatus.Part))
         {
            return stat;
         }
         else if (stat == EnumNodeStatus.Part)
         {
            JDFNodeInfo ni = getNodeInfo();
            if (ni == null)
            {
               return null;
            }
            ni = (JDFNodeInfo)ni.getPartition(mattr, null);
            if (ni == null)
            {
               return null;
            }
            stat = ni.getNodeStatus();

            VElement vLeaves = ni.getLeaves(false);
            int size = vLeaves.Count;

            for (int i = 0; i < size; i++)
            {
               JDFNodeInfo niCmp = (JDFNodeInfo)vLeaves[i];
               JDFAttributeMap map = niCmp.getPartMap();
               if (map != null && !map.overlapMap(mattr))
               {
                  continue;
               }

               if (niCmp.getNodeStatus() != stat)
               {
                  return null; // inconsistent
               }
            }
         }
         else if (stat == EnumNodeStatus.Pool)
         {
            JDFStatusPool statusPool = getStatusPool();
            if (statusPool == null)
            {
               return null;
            }
            stat = statusPool.getStatus(mattr);
         }
         return stat;
      }

      ///   
      ///	 <summary> * get the node's partition statusdetails
      ///	 *  </summary>
      ///	 * <param name="mattr"> Attribute map of partition </param>
      ///	 * <param name="bFromLeaves"> if false, get the directly specified value if true ignore the directly specified value and
      ///	 *            calculate the value from leaves, if any
      ///	 *  </param>
      ///	 * <returns> String: Status of the partition, null if no Status exists (note the null return!) </returns>
      ///	 
      public virtual string getPartStatusDetails(JDFAttributeMap mattr)
      {
         EnumNodeStatus stat = getStatus();
         string statDetails = null;
         if ((stat != EnumNodeStatus.Pool) && (stat != EnumNodeStatus.Part))
         {
            return StringUtil.getNonEmpty(getStatusDetails());
         }
         else if (stat == EnumNodeStatus.Part)
         {
            JDFNodeInfo ni = getNodeInfo();
            if (ni == null)
            {
               return null;
            }
            ni = (JDFNodeInfo)ni.getPartition(mattr, null);
            if (ni == null)
            {
               return null;
            }
            statDetails = ni.getNodeStatusDetails();

            VElement vLeaves = ni.getLeaves(false);
            int size = vLeaves.Count;

            for (int i = 0; i < size; i++)
            {
               JDFNodeInfo niCmp = (JDFNodeInfo)vLeaves[i];
               JDFAttributeMap map = niCmp.getPartMap();
               if (map != null && !map.overlapMap(mattr))
               {
                  continue;
               }

               if (!ContainerUtil.Equals(statDetails, niCmp.getNodeStatusDetails()))
               {
                  return null; // inconsistent
               }
            }
         }
         else if (stat == EnumNodeStatus.Pool)
         {
            JDFStatusPool statusPool = getStatusPool();
            if (statusPool == null)
            {
               return null;
            }

            JDFPartStatus ps = statusPool.getPartStatus(mattr);
            statDetails = ps == null ? null : StringUtil.getNonEmpty(ps.getStatusDetails());
         }

         return StringUtil.getNonEmpty(statDetails);
      }

      ///   
      ///	 <summary> * Set the Status and StatusDetails of this node update the PhaseTime audit or append a new phasetime as appropriate
      ///	 * also generate a status JMF
      ///	 *  </summary>
      ///	 * <param name="nodeStatus"> the new status of the node </param>
      ///	 * <param name="nodeStatusDetails"> the new statusDetails of the node </param>
      ///	 * <param name="deviceStatus"> the new status of the device </param>
      ///	 * <param name="deviceStatusDetails"> the new statusDetails of the device </param>
      ///	 * <param name="vPartMap"> the vector of parts to that should be set
      ///	 *  </param>
      ///	 * <returns> The root element representing the PhaseTime JMF </returns>
      ///	 * @deprecated use the version with deviceID 
      ///	 
      [Obsolete("use the version with deviceID")]
      public virtual JDFDoc setPhase(EnumNodeStatus nodeStatus, string nodeStatusDetails, EnumDeviceStatus deviceStatus, string deviceStatusDetails, VJDFAttributeMap vPartMap)
      {
         StatusCounter sc = new StatusCounter(this, vPartMap, null);
         sc.setPhase(nodeStatus, nodeStatusDetails, deviceStatus, deviceStatusDetails);
         return sc.getDocJMFPhaseTime();
      }

      ///   
      ///	 <summary> * return the partMapVector defined by nodeInfo partitioning null if nodeInfo is not partitioned or if the node
      ///	 * status is neither pool nor part
      ///	 *  </summary>
      ///	 * <returns> the vector of PartMaps </returns>
      ///	 
      public virtual VJDFAttributeMap getStatusPartMapVector()
      {
         EnumNodeStatus status = getStatus();
         if (EnumNodeStatus.Pool.Equals(status))
         {
            JDFStatusPool pool = getStatusPool();
            if (pool != null)
            {
               VJDFAttributeMap vMap = new VJDFAttributeMap();
               VElement vParts = pool.getPartStatusVector(null);
               for (int i = 0; i < vParts.Count; i++)
               {
                  JDFPartStatus ps = (JDFPartStatus)vParts.item(i);
                  vMap.appendUnique(ps.getPartMap());
               }
               vMap.unify();
               return vMap;
            }
         }
         else if (EnumNodeStatus.Part.Equals(status))
         {
            JDFNodeInfo ni = getNodeInfo();
            if (ni != null)
            {
               return ni.getPartMapVector(true);
            }
         }

         return null; // nop
      }

      ///   
      ///	 <summary> * return the partMapVector defined in AncestorPool, null if no AncestorPool exists, or AncestorPool has no Part
      ///	 * elements
      ///	 *  </summary>
      ///	 * <returns> the vector of PartMaps </returns>
      ///	 
      public override VJDFAttributeMap getPartMapVector()
      {
         JDFAncestorPool ancPool = getAncestorPool();
         if (ancPool != null)
         {
            return ancPool.getPartMapVector();
         }
         return null;
      }

      ///   
      ///	 <summary> * return the partMapVector defined in AncestorPool or NodeInfo or output resource in that sequence, null if no
      ///	 * NodeInfo exists, or NodeInfo has no Part elements
      ///	 *  </summary>
      ///	 * <returns> the vector of PartMaps </returns>
      ///	 
      public virtual VJDFAttributeMap getNodeInfoPartMapVector()
      {
         VJDFAttributeMap vm = getPartMapVector();
         if (vm == null)
         {
            JDFNodeInfo ni = getNodeInfo();
            vm = ni == null ? null : ni.getPartMapVector(false);
            if (vm == null)
            {
               JDFResource output = getResource(null, EnumUsage.Output, null, 0);
               vm = output == null ? null : output.getPartMapVector(false);
            }

         }
         return vm == null || vm.Count == 0 ? null : vm;
      }

      ///   
      ///	 <summary> * getActivation
      ///	 *  </summary>
      ///	 * @deprecated 060406 use getActivation(false) 
      ///	 * <returns> EnumActivation </returns>
      ///	 
      [Obsolete("060406 use getActivation(false)")]
      public virtual EnumActivation getActivation()
      {
         return getActivation(false);
      }

      ///   
      ///	 <summary> * get attribute Activation; defaults to Active
      ///	 *  </summary>
      ///	 * <param name="bWalkThroughAnchestors"> if true, walks through all anchestors which may overwrite the local activation
      ///	 *            state
      ///	 *  </param>
      ///	 * <returns> the enumeration value of the attribute </returns>
      ///	 
      public virtual JDFNode.EnumActivation getActivation(bool bWalkThroughAnchestors)
      {
         EnumActivation res = null;
         if (bWalkThroughAnchestors)
         {
            res = EnumActivation.Active;
            JDFNode p = this;
            while (p != null)
            {
               // walk through through all anchestors, to parent to grandparent
               // to grandgrandparent
               // and so on until root and compare the Activation state
               EnumActivation a = EnumActivation.getEnum(p.getAttribute(AttributeName.ACTIVATION, null, null));
               if (a != null)
               {
                  int @value = a.getValue();
                  if ((@value <= EnumActivation.TestRun.getValue()) || (res.getValue() < EnumActivation.Active.getValue()))
                  {
                     res = (@value < res.getValue()) ? a : res; // smaller
                     // enums are
                     // inherited
                     // to all
                     // descendants
                  }
                  else
                  { // special case for non-linear test run / test run and go
                     if (res.Equals(EnumActivation.TestRunAndGo))
                     {
                        res = a; // either TRG or TR
                     }
                     else
                     {
                        // nop it remains TestRun
                     }
                  }
               }
               p = (JDFNode)p.getParentNode_KElement();
            } // end while
         }
         else
         {
            res = EnumActivation.getEnum(getAttribute(AttributeName.ACTIVATION, null, null));
         }
         return res;
      }

      ///   
      ///	 <summary> * Set attribute Activation
      ///	 *  </summary>
      ///	 * <param name="bActive"> the value to set the attribute to </param>
      ///	 
      public virtual void setActivation(EnumActivation bActive)
      {
         setAttribute(AttributeName.ACTIVATION, bActive.getName(), JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * addModified
      ///	 *  </summary>
      ///	 * <param name="by">
      ///	 *  </param>
      ///	 * <returns> JDFAudit </returns>
      ///	 
      public virtual JDFAudit addModified(string by)
      {
         return getCreateAuditPool().addModified(by, null);
      }

      ///   
      ///	 <summary> * Get the linked resource with name=strName
      ///	 *  </summary>
      ///	 * <param name="strName"> the resource name </param>
      ///	 * <param name="usage"> the ResourceLink Usage, if null either in or out are accepted </param>
      ///	 * <param name="int"> i the nuber of matches to skip, if negative, count backwards </param>
      ///	 * <returns> the matching resource, null if none matches </returns>
      ///	 
      public virtual JDFResource getResource(string strName, EnumUsage usage, int i)
      {
         return getResource(strName, usage, null, i);
      }

      ///   
      ///	 <summary> * Get the linked resource with name=strName
      ///	 *  </summary>
      ///	 * <param name="strName"> the resource name </param>
      ///	 * <param name="usage"> the ResourceLink Usage, if null either in or out are accepted </param>
      ///	 * <param name="processUsage"> the processUsage of the respective resource </param>
      ///	 * <param name="int"> i the nuber of matches to skip, if negative, count backwards </param>
      ///	 * <returns> the matching resource, null if none matches </returns>
      ///	 
      public virtual JDFResource getResource(string strName, EnumUsage usage, EnumProcessUsage processUsage, int i)
      {
         int iLocal = i;

         VElement velem = null;
         JDFResourceLinkPool rlp = getResourceLinkPool();
         if (rlp != null)
         {
            JDFAttributeMap mALink = new JDFAttributeMap(); // map of requesetd
            // link attributes
            if (usage != null)
               mALink.put(AttributeName.USAGE, usage);

            if (processUsage != null)
               mALink.put(AttributeName.PROCESSUSAGE, processUsage);

            if (mALink.Count == 0)
               mALink = null;

            velem = rlp.getLinkedResources(strName, mALink, null, false);
         }

         int siz = velem == null ? 0 : velem.Count;
         if (iLocal < 0)
            iLocal += siz;

         if (siz == 0 || iLocal < 0 || iLocal >= siz || velem == null)
            return null;

         return (JDFResource)velem[iLocal];
      }

      ///   
      ///	 <summary> * Get the linked resource with name=strName; create it if it does not exist
      ///	 *  </summary>
      ///	 * <param name="strName"> the resource name </param>
      ///	 * <param name="usage"> the ResourceLink Usage, if null either in or out are accepted </param>
      ///	 * <param name="int"> i the nuber of matches to skip, if negative, count backwards </param>
      ///	 * <returns> the matching resource,
      ///	 *  </returns>
      ///	 * <exception cref="JDFException"> if resource does not exist and EnumUsage is null </exception>
      ///	 
      public virtual JDFResource getCreateResource(string strName, EnumUsage usage, int i)
      {
         JDFResource r = getResource(strName, usage, i);
         if (r == null)
            r = addResource(strName, usage);
         return r;
      }

      ///   
      ///	 <summary> * addResource - add a resource to resroot and link it to this process
      ///	 *  </summary>
      ///	 * <param name="strName"> the localname of the resource </param>
      ///	 * <param name="resClass"> the JFD/@Class of the resource; if null, find from factory </param>
      ///	 * <param name="bInput"> if true, the resource is linked as input, else output </param>
      ///	 * <param name="resRoot"> the node where to add the Resource, if null defaults to this. Note that the link is always in this </param>
      ///	 * <param name="bLink"> if true, creat a ResourceLink to the newly created resource </param>
      ///	 * <param name="nameSpaceURI"> the nsURI of the resource, if null take the default ns
      ///	 *  </param>
      ///	 * <returns> JDFResource </returns>
      ///	 * @deprecated use addResource(String strName, JDFResource.EnumResourceClass resClass, EnumUsage usage,
      ///	 *             EnumProcessUsage processUsage, JDFNode resRoot, String nameSpaceURI)
      ///	 * @default addResource(name, null, bInput, null, true, null) 
      ///	 
      [Obsolete("use addResource(String strName, JDFResource.EnumResourceClass resClass, EnumUsage usage,")]
      public virtual JDFResource addResource(string strName, JDFResource.EnumResourceClass resClass, bool bInput, JDFNode resRoot, bool bLink, string nameSpaceURI)
      {
         EnumUsage usage = null;
         if (bLink)
         {
            usage = bInput ? EnumUsage.Input : EnumUsage.Output;
         }
         return addResource(strName, resClass, usage, null, resRoot, nameSpaceURI, null);
      }

      ///   
      ///	 <summary> * addResource - add a resource to resroot and link it to this process utility with the minimal parameter set
      ///	 *  </summary>
      ///	 * <param name="strName"> the localname of the resource </param>
      ///	 * <param name="usage"> the Usage attribute of the ResourceLink. If null, the resource is not linked </param>
      ///	 * <returns> JDFResource the new resource
      ///	 * 
      ///	 * @default addResource(name, null, usage, null, null, null,null) </returns>
      ///	 
      public virtual JDFResource addResource(string strName, EnumUsage usage)
      {
         return addResource(strName, null, usage, null, null, null, null);
      }

      ///   
      ///	 <summary> * addResource - add a resource to resroot and link it to this process
      ///	 *  </summary>
      ///	 * <param name="strName"> the localname of the resource </param>
      ///	 * <param name="resClass"> the JFD/@Class of the resource; if null, find the resource class from factory </param>
      ///	 * <param name="usage"> the Usage attribute of the ResourceLink. If null, the resource is not linked </param>
      ///	 * <param name="processUsage"> the processUsage attribute of the link to the resource </param>
      ///	 * <param name="resRoot"> the node to add the Resource to, defaults to 'this' if null. Note that the link is always in
      ///	 *            'this' </param>
      ///	 * <param name="nameSpaceURI"> the nsURI of the resource, if null take the default ns </param>
      ///	 * <param name="toReplace"> the resource to replace by this - also add a resource audit </param>
      ///	 * <returns> JDFResource
      ///	 * 
      ///	 * @default addResource(name, null, usage, null, null, null,null) </returns>
      ///	 
      public virtual JDFResource addResource(string strName, JDFResource.EnumResourceClass resClass, EnumUsage usage, EnumProcessUsage processUsage, JDFNode resRoot, string nameSpaceURI, JDFResource toReplace)
      {
         JDFResource.EnumResourceClass resClassLocal = resClass;
         JDFNode resRootLocal = resRoot;

         if (resRootLocal == null)
         {
            resRootLocal = this;
         }

         JDFResourcePool p = resRootLocal.getCreateResourcePool();
         JDFResource r = p.appendResource(strName, null, nameSpaceURI);

         if (usage != null)
         {
            linkResource(r, usage, processUsage);
         }

         // if the factory already did a type safe class creation, use it instead
         EnumResourceClass resClass2 = r.getResourceClass();
         if (resClass2 != null)
         {
            resClassLocal = resClass2;
         }
         if (resClassLocal != null)
         {
            r.setResourceClass(resClassLocal);
         }

         // parameters and consumables are assumed to be available by default
         if (EnumUsage.Input.Equals(usage) && resClassLocal != null && ((resClassLocal.Equals(JDFResource.EnumResourceClass.Parameter)) || (resClassLocal.Equals(JDFResource.EnumResourceClass.Consumable))))
         {
            r.setResStatus(EnumResStatus.Available, false);
         }
         else
         {
            r.setResStatus(JDFResource.EnumResStatus.Unavailable, false);
         }
         if (toReplace != null)
         {
            JDFAuditPool auditPool = getCreateAuditPool();
            JDFResourceAudit resourceAudit = auditPool.addResourceAudit(null);
            resourceAudit.addNewOldLink(true, r, usage);
            resourceAudit.addNewOldLink(false, toReplace, usage);
            JDFResourceLinkPool resourceLinkPool = getResourceLinkPool();
            VElement vRL = (resourceLinkPool == null) ? null : resourceLinkPool.getInOutLinks(usage, true, null, null);
            if (vRL != null)
            {
               for (int i = 0; i < vRL.Count; i++)
               {
                  JDFResourceLink l = (JDFResourceLink)vRL[i];
                  if (l.getTarget() == toReplace)
                  {
                     l.deleteNode();
                  }
               }
            }
         }
         return r;
      }

      ///   
      ///	 <summary> * LinkResource: create a resourceLink in the resourceLinkPool that refers to the resource jdfResource also sets the
      ///	 * appropriate combined process index
      ///	 * 
      ///	 *  </summary>
      ///	 * <param name="jdfResource"> the resource or partition to link to </param>
      ///	 * <param name="input"> it true, link as input, else link as output </param>
      ///	 * <param name="bForce"> if true, create a new link, even if an existing link already exists
      ///	 *  </param>
      ///	 * <returns> JDFResourceLink the new link </returns>
      ///	 * @deprecated use linkResource(enum)
      ///	 * @default LinkResource(r, true, false) 
      ///	 
      [Obsolete("use linkResource(enum)")]
      public virtual JDFResourceLink linkResource(JDFResource jdfResource, bool input, bool bForce)
      {
         bool bForceLocal = bForce;

         if (bForceLocal)
         {
            bForceLocal = true;
         }

         return linkResource(jdfResource, input ? EnumUsage.Input : EnumUsage.Output, null);
      }

      ///   
      ///	 <summary> * LinkResource: create a resourceLink in the resourceLinkPool that refers to the resource jdfResource also sets the
      ///	 * appropriate combined process index
      ///	 * 
      ///	 *  </summary>
      ///	 * <param name="jdfResource"> the resource or partition to link to </param>
      ///	 * <param name="usage"> Usage of the resource </param>
      ///	 * <param name="processUsage"> processUsage of the resource
      ///	 *  </param>
      ///	 * <returns> JDFResourceLink the new link
      ///	 * 
      ///	 * @default LinkResource(r, usage, null) </returns>
      ///	 
      public virtual JDFResourceLink linkResource(JDFResource jdfResource, EnumUsage usage, EnumProcessUsage processUsage)
      {
         if (jdfResource == null)
         {
            return null;
         }

         JDFResourceLinkPool resourceLinkPool = getCreateResourceLinkPool();
         JDFResourceLink resourceLink = resourceLinkPool.linkResource(jdfResource, usage, processUsage);
         VString types = getTypes();
         // generate
         if (types != null && !EnumResourceClass.Implementation.Equals(jdfResource.getResourceClass()) && !(jdfResource is JDFNodeInfo))
         {
            CombinedProcessIndexHelper.generateCombinedProcessIndex(jdfResource, usage, processUsage, resourceLink, types);
         }
         return resourceLink;
      }

      ///   
      ///	 <summary> * ensureLink: if it does not yet exist, create a resourceLink in the resourceLinkPool that refers to the resource
      ///	 * jdfResource also sets the appropriate combined process index
      ///	 * 
      ///	 *  </summary>
      ///	 * <param name="jdfResource"> the resource or partition to link to </param>
      ///	 * <param name="usage"> Usage of the resource </param>
      ///	 * <param name="processUsage"> processUsage of the resource
      ///	 *  </param>
      ///	 * <returns> JDFResourceLink the link
      ///	 * 
      ///	 * @default LinkResource(r, usage, null) </returns>
      ///	 
      public virtual JDFResourceLink ensureLink(JDFResource jdfResource, EnumUsage usage, EnumProcessUsage processUsage)
      {
         if (jdfResource == null)
            return null;
         JDFAttributeMap m = new JDFAttributeMap();
         if (usage != null)
            m.put(AttributeName.USAGE, usage);
         if (processUsage != null)
            m.put(AttributeName.PROCESSUSAGE, processUsage);
         JDFResourceLink rl = getLink(0, jdfResource.Name, m, null);
         if (rl == null)
            rl = linkResource(jdfResource, usage, processUsage);
         return rl;
      }

      ///   
      ///	 <summary> * get the resourcelinks in the resourcepool of this node
      ///	 *  </summary>
      ///	 * <returns> VElement the vector of ResorceLinks: </returns>
      ///	 * @deprecated use getResourceLinks(null) 
      ///	 
      [Obsolete("use getResourceLinks(null)")]
      public virtual VElement getResourceLinks()
      {
         return getResourceLinks(null);
      }

      ///   
      ///	 <summary> * get the resourcelinks in the resourcepool of this node
      ///	 *  </summary>
      ///	 * <param name="mLinkAtt"> the map of attributes
      ///	 *  </param>
      ///	 * <returns> VElement - the vector of ResourceLinks, null if none exist: </returns>
      ///	 
      public virtual VElement getResourceLinks(JDFAttributeMap mLinkAtt)
      {
         JDFResourceLinkPool resList = getResourceLinkPool();
         if (resList == null)
         {
            return null;
         }

         // return contents as vector
         return resList.getPoolChildren(null, mLinkAtt, null);
      }

      ///   
      ///	 <summary> * get the linked resources matching certain conditions<br>
      ///	 * combines all linked resources from ResourceLinkPool, CustomerInfo, NodeInfo and AuditPool
      ///	 *  </summary>
      ///	 * <param name="mResAtt"> map of Resource attributes to search for </param>
      ///	 * <param name="bFollowRefs"> true if internal references shall be followed
      ///	 *  </param>
      ///	 * <returns> vResource: vector with all elements matching the conditions
      ///	 * 
      ///	 * @default getLinkedResources(null, false) </returns>
      ///	 
      public virtual VElement getLinkedResources(JDFAttributeMap mResAtt, bool bFollowRefs)
      {
         JDFResourceLinkPool resourceLinkPool = getResourceLinkPool();
         VElement vLinkedResources = new VElement();
         if (resourceLinkPool != null)
         {
            vLinkedResources = resourceLinkPool.getLinkedResources(null, null, mResAtt, bFollowRefs);
         }

         JDFAuditPool auditPool = getAuditPool();
         if (auditPool != null)
         {
            vLinkedResources.appendUnique(auditPool.getLinkedResources(null, true));
         }

         // only needed for the JDF 1.2 subelement, resources are handled
         // generically
         JDFCustomerInfo customerInfo = (JDFCustomerInfo)getElement(ElementName.CUSTOMERINFO);
         if (customerInfo != null)
         {
            vLinkedResources.appendUnique(customerInfo.getLinkedResources(mResAtt, bFollowRefs));
         }

         // only needed for the JDF 1.2 subelement, resources are handled
         // generically
         JDFNodeInfo nodeInfo = (JDFNodeInfo)getElement(ElementName.NODEINFO);
         if (nodeInfo != null)
         {
            vLinkedResources.appendUnique(nodeInfo.getLinkedResources(mResAtt, bFollowRefs));
         }

         JDFAncestorPool ancestorPool = getAncestorPool();
         if (ancestorPool != null)
         {
            vLinkedResources.appendUnique(ancestorPool.getLinkedResources(mResAtt, bFollowRefs));
         }
         return vLinkedResources;
      }

      ///   
      ///	 <summary> * get all the unlinked resources in this node<br>
      ///	 * TODO: also include resources that are only linked by other unlinked resources
      ///	 * 
      ///	 * @boolean bLocal if true, only in the local resourcepool, else also recurse into children
      ///	 *  </summary>
      ///	 * <returns> vElement vector with all
      ///	 *  </returns>
      ///	 
      public virtual VElement getUnlinkedResources(bool bLocal)
      {
         JDFResourcePool resourcePool = getResourcePool();
         if (resourcePool == null)
         {
            return null;
         }
         VElement vUnlinkedResources = resourcePool.getUnlinkedResources();
         if (bLocal)
         {
            return vUnlinkedResources;
         }
         if (vUnlinkedResources == null)
         {
            vUnlinkedResources = new VElement();
         }
         VElement children = getvJDFNode(null, null, true);
         for (int i = 0; i < children.Count; i++)
         {
            vUnlinkedResources.addAll(((JDFNode)children[i]).getUnlinkedResources(bLocal));
         }
         return vUnlinkedResources.Count == 0 ? null : vUnlinkedResources;
      }

      ///   
      ///	 <summary> * get a vector of all direct predecessor or following nodes, depending on bPre
      ///	 *  </summary>
      ///	 * <param name="bPre"> if true get predecessors, if false get following nodes
      ///	 *  </param>
      ///	 * <returns> Vector of pre / post decessor nodes </returns>
      ///	 *@deprecated use getPredecessors(bPre,false); 
      ///	 
      [Obsolete("use getPredecessors(bPre,false);")]
      public virtual VElement getPredecessors(bool bPre)
      {
         return getPredecessors(bPre, false);
      }

      ///   
      ///	 <summary> * get a vector of all direct predecessor or following nodes, depending on bPre
      ///	 *  </summary>
      ///	 * <param name="bPre"> if true get predecessors, if false get following nodes </param>
      ///	 * <param name="bDirect"> if true, only return the direct condidates
      ///	 *  </param>
      ///	 * <returns> Vector of pre / post decessor nodes </returns>
      ///	 
      public virtual VElement getPredecessors(bool bPre, bool bDirect)
      {
         SupportClass.HashSetSupport<KElement> hashSet = new SupportClass.HashSetSupport<KElement>();
         getPredecessorImpl(bPre, bDirect, hashSet);

         VElement v = new VElement();
         IEnumerator<KElement> it = hashSet.GetEnumerator();
         while (it.MoveNext())
         {
            v.Add(it.Current);
         }
         return v;

      }

      private void getPredecessorImpl(bool bPre, bool bDirect, SupportClass.HashSetSupport<KElement> h)
      {
         JDFResourceLinkPool rlp = getResourceLinkPool();

         // get either all input or output resources, depending on bPre
         VElement vLoc = (rlp == null) ? null : rlp.getInOutLinks(bPre ? EnumUsage.Input : EnumUsage.Output, false, null, null);

         if (vLoc != null)
         {
            VElement.Enumerator vLocIterator = vLoc.GetEnumerator();
            while (vLocIterator.MoveNext())
            {
               JDFResource r = (JDFResource)vLocIterator.Current;
               // get all creator or consumer processes
               VElement vc = r.getCreator(bPre);

               if (vc != null)
               {
                  VElement.Enumerator vcIterator = vc.GetEnumerator();
                  while (vcIterator.MoveNext())
                  {
                     JDFNode p = (JDFNode)vcIterator.Current;
                     if (h.Contains(p))
                     {
                        continue; // snafu
                     }
                     h.Add(p);

                     if (!bDirect)
                     {
                        p.getPredecessorImpl(bPre, bDirect, h);
                     }
                  }
               }
            }
         }
      }

      ///   
      ///	 <summary> * isExecutable - checks whether a node is executable by checking the resources linked by the resourcelinkpool and @Status
      ///	 * or NodeInfo/@NodeStatus
      ///	 *  </summary>
      ///	 * <param name="partMap"> the Attribute to check </param>
      ///	 * <param name="bCheckChildren"> if true, calculates the availability Status of a resource from all child partition leaves,
      ///	 *            else the Status is taken from the appropriate leaf itself
      ///	 *  </param>
      ///	 * <returns> boolean - true if the node is executable, false if not
      ///	 * 
      ///	 *         default: isExecutable(null, true) </returns>
      ///	 

      public virtual bool isExecutable(JDFAttributeMap partMap, bool bCheckChildren)
      {
         JDFResourceLinkPool resourceLinkPool = getResourceLinkPool();
         if (resourceLinkPool == null)
            return false;
         VElement v = resourceLinkPool.getPoolChildren(null, null, null);
         EnumNodeStatus status = getPartStatus(partMap);
         if ((status != EnumNodeStatus.Waiting) && (status != EnumNodeStatus.Ready))
         {
            return false;
         }

         if (v != null)
         {
            for (int i = 0; i < v.Count; i++)
            {
               JDFResourceLink rl = (JDFResourceLink)v[i];

               if (rl != null && !rl.isExecutable(partMap, bCheckChildren))
               {
                  return false;
               }
            }
         }

         return true;
      }

      ///   
      ///	 <summary> * gets the status of a certain partition of the node. The partition is given by a map of partition attributes or by
      ///	 * a JDFResource object containing such a map.
      ///	 *  </summary>
      ///	 * <param name="mattr"> </param>
      ///	 * @deprecated use getPartStatus() 
      ///	 

      [Obsolete("use getPartStatus()")]
      public virtual JDFElement.EnumNodeStatus getProcessStatus(JDFAttributeMap mattr)
      {
         JDFElement.EnumNodeStatus stat = getStatus();

         if (stat.CompareTo(JDFElement.EnumNodeStatus.Pool) != 0)
         {
            return stat;
         }

         stat = null;
         KElement statusPoolEl = getElement_JDFElement(ElementName.STATUSPOOL, null, 0);

         if (statusPoolEl == null)
         {
            return stat;
         }
         JDFStatusPool statusPool = (JDFStatusPool)statusPoolEl;
         return statusPool.getStatus(mattr);
      }

      ///   
      ///	 <summary> *
      ///
      ///	 * </summary>
      ///	 

      ///   
      ///	 <summary> * ResourceTypeEqual<br>
      ///	 * Checks whether the given resources are of the same type. Resources are considered equal by this method if they
      ///	 * have identical Class attributes and their resource type is equal. Basically the resource type is the node name.<br>
      ///	 * Two resources with different node names are considered equal if their Type attributes from the ToolConfig.xml
      ///	 * file are equal. This is not implemented yet. Instead of it is hard-coded that "RunList" and "HDM:ReportList" are
      ///	 * of the same type.
      ///	 *  </summary>
      ///	 * <param name="res1"> first resource </param>
      ///	 * <param name="res2"> second resource </param>
      ///	 * <returns> boolean </returns>
      ///	 
      public static bool resourceTypeEqual(JDFResource res1, JDFResource res2)
      {
         JDFResource.EnumResourceClass res1_class = res1.getResourceClass();
         JDFResource.EnumResourceClass res2_class = res2.getResourceClass();

         if (!res1_class.Equals(res2_class))
         {
            return false;
         }

         string res1_type = res1.Name;
         string res2_type = res2.Name;

         if (res1_type.CompareTo("HDM:ReportList") == 0)
         {
            res1_type = ElementName.RUNLIST;
         }

         if (res2_type.CompareTo("HDM:ReportList") == 0)
         {
            res2_type = ElementName.RUNLIST;
         }

         if (res1_type.CompareTo(res2_type) == 0)
         {
            return true;
         }

         return false;
      }

      ///   
      ///	 <summary> * Get a vector of all JDF children with type nodeType
      ///	 *  </summary>
      ///	 * <param name="nodeType"> : node Type attribute </param>
      ///	 * <param name="active"> : Activation of the requesetd nodes, if null ignore activation </param>
      ///	 * <param name="bDirect"> : if true, get direct children only, else recurse down the tree and include this, i.e. return a
      ///	 *            complete tree starting at this
      ///	 * 
      ///	 * @return: VElement of JDF nodes
      ///	 * 
      ///	 *          default: getvJDFNode(null, JDFNode.EnumActivation.Unknown, false) </param>
      ///	 

      ///   
      ///	 <summary> * Get a vector of all JDF children with type nodeType
      ///	 *  </summary>
      ///	 * <param name="task"> node type </param>
      ///	 * <param name="active"> Activation of the requested nodes, if null ignore activation </param>
      ///	 * <param name="bDirect"> if true, get direct children only, else recurse down the tree and include this, i.e. return a
      ///	 *            complete tree starting at this
      ///	 *  </param>
      ///	 * <returns> VElement of JDF nodes
      ///	 * @default getvJDFNode(null, null, false) </returns>
      ///	 
      public virtual VElement getvJDFNode(string task, EnumActivation active, bool bDirect)
      {

         VElement v = new VElement();
         VElement l = getTree(ElementName.JDF, null, null, bDirect, true);
         // only create a complete tree including this in the recursive case
         if (!bDirect)
         {
            l.Add(this);
         }

         bool wantTask = !KElement.isWildCard(task);
         int size = l.Count;
         for (int i = 0; i < size; i++)
         {
            JDFNode p = (JDFNode)l[i];
            if (p.fitsActivation(active, true) && (!wantTask || p.getType().Equals(task)))
            {
               v.Add(p);
            }
         }
         return v;
      }

      ///   
      ///	 <summary> * getvJDFNode
      ///	 *  </summary>
      ///	 * <param name="task"> </param>
      ///	 * <param name="active">
      ///	 *  </param>
      ///	 * <returns> Vector of JDFNodes
      ///	 * 
      ///	 * @default getvJDFNode(null, false) </returns>
      ///	 * @deprecated use public Vector getvJDFNode(task, JDFNode.EnumActivation.Unknown, false) 
      ///	 
      [Obsolete("use public Vector getvJDFNode(task, JDFNode.EnumActivation.Unknown, false)")]
      public virtual VElement getvJDFNode(string task, bool active)
      {
         return getvJDFNode(task, null, active);
      }

      ///   
      ///	 <summary> * isActive
      ///	 *  </summary>
      ///	 * @deprecated use fitsActivation
      ///	 *  
      ///	 * <returns> boolean </returns>
      ///	 
      [Obsolete("use fitsActivation")]
      public virtual bool isActive()
      {
         return fitsActivation(EnumActivation.Active, true);
      }

      ///   
      ///	 * @deprecated use fitsActivation 
      ///	 * <param name="bWalkThroughAnchestors"> </param>
      ///	 * <returns> boolean </returns>
      ///	 
      [Obsolete("use fitsActivation")]
      public virtual bool isActive(bool bWalkThroughAnchestors)
      {
         return fitsActivation(EnumActivation.Active, bWalkThroughAnchestors);
      }


      ///   
      ///	 <summary> * the activation state of this node
      ///	 *  </summary>
      ///	 * <param name="active"> </param>
      ///	 * <param name="bWalkThroughAnchestors"> if true, walks through all anchestors which may overwrite the local activation
      ///	 *            state </param>
      ///	 * <returns> boolean </returns>
      ///	 
      public virtual bool fitsActivation(EnumActivation active, bool bWalkThroughAnchestors)
      {
         if (active == null)
         {
            return true;
         }
         EnumActivation a = getActivation(bWalkThroughAnchestors);
         if (active.Equals(EnumActivation.TestRun))
         {
            return a.Equals(EnumActivation.TestRun) || a.Equals(EnumActivation.TestRunAndGo);
         }
         else if (active.Equals(EnumActivation.Active))
         {
            return a.Equals(EnumActivation.Active) || a.Equals(EnumActivation.TestRunAndGo);
         }
         else
         {
            return a.Equals(active);
         }
      }

      ///   
      ///	 <summary> * removeNode - remove a node. If bLeaveSubmit is true, leave a stub with the id and status field
      ///	 *  </summary>
      ///	 * <param name="bLeaveSubmit"> if true, leave a stub with id and status field
      ///	 * 
      ///	 * @default removeNode(true)
      ///	 * @deprecated </param>
      ///	 
      [Obsolete]
      public virtual void removeNode(bool bLeaveSubmit)
      {
         if (bLeaveSubmit)
         {
            string id = getID();
            removeAttributes(VString.emptyVector);
            setAttribute(AttributeName.ID, id, null);
            setStatus(JDFElement.EnumNodeStatus.Spawned);
            removeChildren(null, null, null);
         }
         else
         {
            deleteNode();
         }
      }

      ///   
      ///	 <summary> * addTask
      ///	 *  </summary>
      ///	 * <param name="task"> </param>
      ///	 * <param name="tasks"> </param>
      ///	 * @deprecated use addJDFNode 
      ///	 * <returns> JDFNode </returns>
      ///	 
      [Obsolete("use addJDFNode")]
      public virtual JDFNode addTask(string task, VString tasks)
      {
         if (task.Equals(JDFConstants.EMPTYSTRING))
         {
            return this;
         }

         JDFNode p = (JDFNode)appendElement(ElementName.JDF, null);

         if (p != null)
         {
            if (task.Equals(JDFConstants.COMBINED))
            {
               p.setCombined(tasks);
            }
            else
            {
               p.setType(task, false);
            }
         }

         return p;
      }

      ///   
      ///	 <summary> * addTask
      ///	 *  </summary>
      ///	 * <param name="task">
      ///	 *  </param>
      ///	 * <returns> JDFNode </returns>
      ///	 * @deprecated use addJDFNode 
      ///	 
      [Obsolete("use addJDFNode")]
      public virtual JDFNode addTask(string task)
      {
         return addTask(task, null);
      }

      ///   
      ///	 <summary> * setType set the type attribute to the enumeration type also set xsi:type etc
      ///	 *  </summary>
      ///	 * <param name="typ"> the new type to set this to </param>
      ///	 
      public virtual void setType(EnumType typ)
      {
         setType(typ == null ? null : typ.getName(), true);
      }

      ///   
      ///	 <summary> * setType set the type attribute to the string type
      ///	 *  </summary>
      ///	 * <param name="newType"> the new type to set this to </param>
      ///	 * <param name="checkName"> if true, check whether this type exists and throw an exception if not
      ///	 *  </param>
      ///	 * <returns> ignore, always true </returns>
      ///	 * <exception cref="JDFException"> if type is not a known JDF type
      ///	 * @default setType(newType, false) </exception>
      ///	 
      public virtual bool setType(string newType, bool checkName)
      {
         EnumType eTyp = EnumType.getEnum(newType);
         if (!checkName || eTyp != null)
         {
            removeAttribute("type", AttributeName.XSIURI);
            setAttribute(AttributeName.TYPE, newType, null);
            if (eTyp != null)
            {
               setXSIType(newType);
               if (!eTyp.Equals(EnumType.Combined) && !eTyp.Equals(EnumType.ProcessGroup))
               {
                  removeAttribute(AttributeName.TYPES);
               }
            }
         }
         else
         {
            throw new JDFException("SetType illegal type: " + newType);
         }
         return true;
      }

      ///   
      ///	 <summary> * getType - get node Type
      ///	 *  </summary>
      ///	 * <returns> String - the type </returns>
      ///	 
      public virtual string getType()
      {
         return getAttribute(AttributeName.TYPE, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * getType - get node Types or Type attribute
      ///	 *  </summary>
      ///	 * <returns> String - the type </returns>
      ///	 
      public virtual string getTypesString()
      {
         string s = getAttribute(AttributeName.TYPES, null, null);
         return s == null ? getType() : s;
      }

      ///   
      ///	 <summary> * version fixing routine for JDF
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
         if (version != null)
         {
            setVersion(version);
            setMaxVersion(version);
            bRet = fixNiCi(version);
         }
         if (!hasAttribute(AttributeName.JOBPARTID))
         {
            setJobPartID(generateDotID(AttributeName.JOBPARTID, null));
         }

         if (isJDFRoot() && !hasAncestorAttribute(AttributeName.JOBID, null))
         {
            setJobID(generateDotID(AttributeName.JOBID, null));
         }
         EnumType enumType = getEnumType();
         if (enumType != null)
            setType(enumType); // fixes xsi:type stuff

         return base.fixVersion(version) && bRet;
      }


      ///   
      ///	 <summary> * fix NodeInfo and CustomerInfo
      ///	 *  </summary>
      ///	 * <param name="version"> target version
      ///	 * @return </param>
      ///	 
      private bool fixNiCi(EnumVersion version)
      {
         bool bRet = true;

         // fix NodeInfo and CustomerInfo
         for (int i = 0; i < 2; i++)
         {
            string nam = (i > 0) ? ElementName.NODEINFO : ElementName.CUSTOMERINFO;
            string linkNam = nam + JDFConstants.LINK;
            if (version.getValue() >= EnumVersion.Version_1_3.getValue())
            {
               bRet = fixNiCiToResource(i, nam, linkNam);
            }
            else
            { // move to version <= 1.2
               fixNiCiToElement(i, nam, linkNam);
            }
         }
         return bRet;
      }

      private void fixNiCiToElement(int i, string nam, string linkNam)
      {
         JDFResourceLinkPool rlp = getResourceLinkPool();
         if (rlp != null && rlp.hasChildElement(linkNam, null))
         {
            JDFResourceLink rl = rlp.getPoolChild(0, linkNam, null, null);
            JDFResource root = rl.getLinkRoot();
            JDFElement e = (JDFElement)getCreateElement(nam);

            // not partitioned, simply copy into nodeinfo element
            if (!root.hasAttribute(AttributeName.PARTIDKEYS))
            {
               e.mergeElement(root, false);
               if (i == 1)
               {
                  if (getStatus() == EnumNodeStatus.Part)
                  {
                     moveAttribute(AttributeName.STATUS, e, AttributeName.NODESTATUS, null, null);
                     if (e.hasAttribute(AttributeName.NODESTATUSDETAILS))
                     {
                        moveAttribute(AttributeName.STATUSDETAILS, e, AttributeName.NODESTATUSDETAILS, null, null);
                     }
                  }
               }
            }
            else
            { // partitioned nodeinfo or customerinfo handling
               if (i == 1)
               { // copy nodeinfo stati into statuspool
                  setStatus(EnumNodeStatus.Pool);
                  VElement vLeaves = root.getLeaves(false);
                  JDFStatusPool sp = getCreateStatusPool();
                  sp.removeChildren(null, null, null);
                  for (int j = 0; j < vLeaves.Count; j++)
                  {
                     JDFNodeInfo ni = (JDFNodeInfo)vLeaves[j];
                     JDFPartStatus ps = sp.appendPartStatus();
                     ps.setPartMap(ni.getPartMap());
                     ps.setAttribute(AttributeName.STATUS, ni.getAttribute(AttributeName.NODESTATUS));
                     if (ni.hasAttribute(AttributeName.STATUSDETAILS))
                     {
                        ps.setAttribute(AttributeName.STATUSDETAILS, ni.getAttribute(AttributeName.NODESTATUSDETAILS));
                     }
                  }
               }
               // merge the most fitting resource partition into the
               // unpartitioned
               // nodeinfo or customerinfo
               JDFResource target = rl.getTarget();
               target.removeChildren(target.Name, null, null);
               target.expand(false);
               e.mergeElement(target, false);
               string partidkeys = root.getAttribute(AttributeName.PARTIDKEYS, null, null);
               if (partidkeys != null)
               {
                  e.setAttribute(AttributeName.PARTIDKEYS, partidkeys);
               }
            }

            ((JDFResource)e).cleanResourceAttributes();

            // ciao bello
            rl.deleteNode();
            root.deleteNode();
         }
      }

      ////

      private bool fixNiCiToResource(int i, string nam, string linkNam)
      {
         bool bRet = true;
         JDFResourceLinkPool rlp = getResourceLinkPool();
         if (hasChildElement(nam, null) || ((i == 1) && hasChildElement(ElementName.STATUSPOOL, null)))
         {
            JDFElement e = (JDFElement)getElement(nam);
            // move nodeinfo or CustomerInfo into the resource
            if (rlp == null || !rlp.hasChildElement(linkNam, null))
            {
               JDFResource r = addResource(nam, null, EnumUsage.Input, null, null, null, null);
               if (e != null)
               {
                  r.mergeElement(e, false);
               }
               if (i == 1) // nodeinfo
               {
                  JDFNodeInfo ni = (JDFNodeInfo)r;

                  if (hasChildElement(ElementName.STATUSPOOL, null))
                  {

                     // get PartStatus vector
                     JDFStatusPool statusPool = getStatusPool();
                     VElement vPartStatus = statusPool.getPoolChildren(null);
                     setStatus(EnumNodeStatus.Part);
                     JDFAttributeMap mps = null;
                     if (!vPartStatus.IsEmpty())
                     {
                        JDFPartStatus ps = (JDFPartStatus)vPartStatus[0];
                        mps = ps.getPartMap();
                     }
                     VString partIDKeys = getPartIDKeys(mps);

                     ni.setAttribute(AttributeName.NODESTATUS, statusPool.getAttribute(AttributeName.STATUS));
                     ni.setAttribute(AttributeName.NODESTATUSDETAILS, statusPool.getStatusDetails());
                     for (int ips = 0; ips < vPartStatus.Count; ips++)
                     {
                        JDFPartStatus ps = (JDFPartStatus)vPartStatus[ips];
                        try
                        { // see if the partstatus is consistent with what
                           // we have
                           ni = (JDFNodeInfo)r.getCreatePartition(ps.getPartMap(), partIDKeys);
                        }
                        catch (JDFException)
                        {
                           // couldn't create a partiton - flag failure and
                           // move on
                           bRet = false;
                           continue;
                        }
                        ni.setAttribute(AttributeName.NODESTATUS, ps.getAttribute(AttributeName.STATUS));
                        if (ps.hasAttribute(AttributeName.STATUSDETAILS))
                        {
                           ni.setAttribute(AttributeName.NODESTATUSDETAILS, ps.getStatusDetails());
                        }
                     }
                     removeChild(ElementName.STATUSPOOL, null, 0);
                  }
                  else
                  // no statuspool
                  {
                     // not yet
                  }
               }
            }
            // have both link and element - snafu simply remove element
            removeChild(nam, null, 0);
         }
         return bRet;
      }

      ///   
      ///	 <summary> * typesafe validator, checks whether all resource links are ok
      ///	 *  </summary>
      ///	 * <param name="level"> validation level </param>
      ///	 * <returns> true if this node is valid </returns>
      ///	 
      public override bool isValid(EnumValidationLevel level)
      {
         bool bValid = base.isValid(level);
         if (!bValid)
         {
            return false;
         }

         bValid = !hasInvalidLinks(level);
         if (bValid && EnumType.Product.Equals(getEnumType()))
         {
            JDFNode n = getParentJDF();
            if (n != null)
            {
               bValid = EnumType.Product.Equals(n.getEnumType());
            }
         }
         return bValid;
      }

      ///   
      ///	 <summary> * true if invalid Links are in this element
      ///	 *  </summary>
      ///	 * <param name="level"> validation level </param>
      ///	 * <returns> boolean - true if unknown Links are in this element
      ///	 * 
      ///	 * @default public boolean hasInvalidLinks (ValidationLevel_Complete) </returns>
      ///	 
      public virtual bool hasInvalidLinks(EnumValidationLevel level)
      {
         return getInvalidLinks(level, 1).Count > 0;
      }

      ///   
      ///	 <summary> * typesafe validator utility
      ///	 *  </summary>
      ///	 * <param name="level"> validation level </param>
      ///	 * <param name="nMax"> max. size of the returned vector </param>
      ///	 * <returns> vector of invalid Link names
      ///	 * 
      ///	 * @default getInvalidLinks (ValidationLevel_Complete, Integer.MAX_VALUE) </returns>
      ///	 
      public virtual VString getInvalidLinks(EnumValidationLevel level, int nMax)
      {
         VString vElem = new VString();
         List<int> foundSingleLinks = new List<int>();
         List<int> foundSingleLinks2 = new List<int>();

         JDFResourceLinkPool linkPool = getResourceLinkPool();
         if (linkPool != null)
         {
            VElement vLinks = linkPool.getPoolChildren(null, null, null);
            if (vLinks != null)
            {
               for (int i = vLinks.Count - 1; i >= 0; i--)
               {
                  JDFResourceLink rl = (JDFResourceLink)vLinks[i];
                  if (!isValidLink(level, rl, foundSingleLinks, foundSingleLinks2))
                  {
                     vElem.appendUnique(rl.getLinkedResourceName());
                  }
               }
            }
         }

         if (EnumValidationLevel.isRequired(level))
         {
            vElem.appendUnique(getMissingLinkVector(nMax));
         }

         return vElem;
      }

      ///   
      ///	 <summary> * update the node status or nodeinfo/@NodeStatus for all partitions specified in vMap
      ///	 *  </summary>
      ///	 * <param name="vMap"> the map of partitions to apply the update algorithm to </param>
      ///	 * <param name="updateKids"> if true, also recursively update all kids, if false move to root without updating kids </param>
      ///	 * <param name="updateParents"> if true, recurse down to the root, updatimg the satus based on modifications in this </param>
      ///	 
      public virtual void updatePartStatus(VJDFAttributeMap vMap, bool updateKids, bool updateParents)
      {
         VElement vNodes = getvJDFNode(null, null, true);
         if (vNodes != null && !vNodes.IsEmpty())
         {

            int kidsize = vNodes.Count;
            // clean kids first and then start algorithm based on clean kids
            VJDFAttributeMap statusMaps = new VJDFAttributeMap();
            for (int i = 0; i < kidsize; i++)
            {
               JDFNode node = (JDFNode)vNodes.item(i);
               if (updateKids)
               {
                  node.updatePartStatus(vMap, updateKids, false);
               }
               statusMaps.addAll(node.getStatusPartMapVector());
            }
            statusMaps.unify();
            if (statusMaps.Count > 0)
            {
               for (int i = statusMaps.Count - 1; i >= 0; i--)
               {
                  JDFAttributeMap map = statusMaps[i];
                  if (!map.subMap(vMap))
                  {
                     statusMaps.RemoveAt(i);
                  }
               }
               if (statusMaps.Count == 0)
               {
                  return;
               }
            }
            else
            {
               statusMaps.Add(null);
            }
            for (int i = 0; i < statusMaps.Count; i++)
            {
               JDFAttributeMap map = statusMaps[i];
               EnumNodeStatus minStatus = EnumNodeStatus.Completed;
               for (int j = 0; j < kidsize; j++)
               {
                  JDFNode node = (JDFNode)vNodes.item(j);

                  EnumNodeStatus status = node.getPartStatus(map);
                  if (status == null)
                  {
                     minStatus = null;
                     break; // no consistent status, don't set
                  }
                  if (minStatus.getValue() > status.getValue())
                  {
                     minStatus = status;
                  }
               }
               if (minStatus != null)
               {
                  setPartStatus(map, minStatus, null);
               }
            }
         }

         // recurse down to root
         if (updateParents)
         {
            JDFNode parent = getParentJDF();
            if (parent != null)
            {
               parent.updatePartStatus(vMap, false, true);
            }
         }

      }

      ///   
      ///	 <summary> * UpDateStatus - update the status of a node depending on its resources and child nodes
      ///	 *  </summary>
      ///	 * @deprecated use updatePartStatus(VJDFAttributeMAP) 
      ///	 
      [Obsolete("use updatePartStatus(VJDFAttributeMAP)")]
      public virtual void upDateStatus()
      {
         JDFResourceLinkPool resourceLinkPool = getResourceLinkPool();
         if (resourceLinkPool == null)
         {
            return;
         }

         VElement vOut = resourceLinkPool.getInOutLinks(EnumUsage.Output, false, null, null);
         if (vOut == null || vOut.IsEmpty())
         {
            return;
         }

         bool bReady = true;
         for (int i = 0; i < vOut.Count; i++)
         {
            JDFResource g = (JDFResource)vOut[i];

            if (g.getResStatus(false).getValue() < EnumResStatus.Available.getValue())
            {
               bReady = false;
            }
         }

         if (bReady)
         {
            setStatus(JDFElement.EnumNodeStatus.Completed);
            KElement parent = getParentNode_KElement();

            if (parent != null)
            {
               JDFNode p = (JDFNode)parent;
               p.upDateStatus();
            }
         }
      }

      ///   
      ///	 <summary> * getJobPart - get a child node with a given jobpartid
      ///	 *  </summary>
      ///	 * <param name="jobPartID"> the ID of the part job </param>
      ///	 * <param name="jobID"> the ID of the job
      ///	 *  </param>
      ///	 * <returns> JDFNode
      ///	 * 
      ///	 * @default getJobPart(jobPartID, JDFConstants.EMPTYSTRING) </returns>
      ///	 
      public virtual JDFNode getJobPart(string jobPartID, string jobID)
      {
         JDFAttributeMap jobPartIDMap = new JDFAttributeMap(AttributeName.JOBPARTID, jobPartID);
         if (jobID != null && !jobID.Equals(JDFConstants.EMPTYSTRING))
         {
            jobPartIDMap.put(AttributeName.JOBID, jobID);
         }
         return (JDFNode)getTreeElement(Name, null, jobPartIDMap, false, true);
      }

      ///   
      ///	 <summary> * add any resources that live in ancestor nodes to this node
      ///	 *  </summary>
      ///	 * <param name="vRWResources"> vector of resource names and Usage / ProcessUsage that are spawned as rw <br>
      ///	 *            the format is one of:<br>
      ///	 *            <li>ResName</li><br>
      ///	 *            <li>ResName:Input</li><br>
      ///	 *            <li>ResName:Output</li><br>
      ///	 *            <li>ResName:ProcessUsage</li><br>
      ///	 *            <li>ID<br> </param>
      ///	 * <param name="vSpawnParts"> vector of JDFAttributeMaps that describe the parts to spawn
      ///	 *  </param>
      ///	 * <returns> HashSet of resources or resource partitions that would be spawned rw multiple times </returns>
      ///	 
      public virtual ICollection checkSpawnedResources(VString vRWResources, VJDFAttributeMap vSpawnParts)
      {
         JDFSpawn spawn = new JDFSpawn(this);
         spawn.vSpawnParts = vSpawnParts;
         spawn.vRWResources_in = new VString(vRWResources);
         return spawn.checkSpawnedResources();
      }

      ///   
      ///	 <summary> * get inter-resource linked resource refs and resourcs links
      ///	 *  </summary>
      ///	 * <param name="vDoneRefs"> </param>
      ///	 * <param name="bRecurse"> if true, also return references linked from the resource pool directly
      ///	 *  </param>
      ///	 * <returns> HashSet of referenced resource refs and links </returns>
      ///	 
      public override SupportClass.HashSetSupport getAllRefs(SupportClass.HashSetSupport vDoneRefs, bool bRecurse)
      {
         SupportClass.HashSetSupport v1 = vDoneRefs != null ? vDoneRefs : new SupportClass.LinkedHashSet();
         // the following code probably does more harm than hel in the standard
         // case
         // and only speeds up pathologically ordered JDF
         //
         // if(vDoneRefs==null)
         // {
         // XMLDocUserData ud=getXMLDocUserData();
         // if(ud!=null && ud.getIDCache())
         // {
         // //prefill cache!
         // JDFNode root=getJDFRoot();
         // VElement v=root.getChildrenByTagName(ElementName.RESOURCEPOOL, null,
         // null, false, true, 0);
         // for(int i=0;i<v.Count;i++)
         // {
         // JDFResourcePool rp=(JDFResourcePool)v.get(i);
         // rp.getResourceByID("1"); // invalid so that it will search all!
         // }
         // }
         // }
         JDFResourcePool rp = getResourcePool();
         if (rp != null && bRecurse)
         {
            v1 = rp.getAllRefs(v1, bRecurse);
         }

         JDFResourceLinkPool rlp = getResourceLinkPool();
         if (rlp != null)
         {
            v1 = rlp.getAllRefs(v1, bRecurse);
         }

         // only 1.2 direct element - resources are retrieved from the
         // ResourcePool
         JDFCustomerInfo ci = (JDFCustomerInfo)getElement(ElementName.CUSTOMERINFO);
         if (ci != null)
         {
            v1 = ci.getAllRefs(v1, bRecurse);
         }

         // only 1.2 direct element - resources are retrieved from the
         // ResourcePool
         JDFNodeInfo ni = (JDFNodeInfo)getElement(ElementName.NODEINFO);
         if (ni != null)
         {
            v1 = ni.getAllRefs(v1, bRecurse);
         }

         JDFAncestorPool ap = getAncestorPool();
         if (ap != null)
         {
            v1 = ap.getAllRefs(v1, true);
         }

         VElement vNodes = getvJDFNode(null, null, true);
         int size = vNodes.Count;
         for (int i = 0; i < size; i++)
         {
            v1 = ((JDFNode)vNodes[i]).getAllRefs(v1, bRecurse);
         }

         return v1;
      }

      ///   
      ///	 <summary> * setCombined - set the combined node types to the values in vCombiNodes
      ///	 *  </summary>
      ///	 * <param name="vCombiNodes"> </param>
      ///	 
      public virtual void setCombined(VString vCombiNodes)
      {
         setType(JDFConstants.COMBINED, false);
         setTypes(vCombiNodes);
      }

      ///   
      ///	 <summary> * getCombinedTypes - get the list of combined types if this is a combined node
      ///	 *  </summary>
      ///	 * @deprecated use getTypes() or getEnumTypes() 
      ///	 * <returns> Vector </returns>
      ///	 
      [Obsolete("use getTypes() or getEnumTypes()")]
      public virtual ArrayList getCombinedTypes()
      {
         if (!isTypesNode())
         {
            return new ArrayList();
         }

         string s = getAttribute(AttributeName.TYPES, null, JDFConstants.EMPTYSTRING);
         return StringUtil.tokenize(s, JDFConstants.BLANK, false);
      }

      ///   
      ///	 <summary> * addComponent - add a component resource to resroot and link it to this process
      ///	 *  </summary>
      ///	 * <param name="cType"> </param>
      ///	 * <param name="bInput"> </param>
      ///	 * <param name="resRoot"> </param>
      ///	 * <param name="bLink">
      ///	 *  </param>
      ///	 * <returns> JDFComponent </returns>
      ///	 * @deprecated use standard addResource
      ///	 * @default addComponent(cType, bInput, null, true) 
      ///	 
      [Obsolete("use standard addResource")]
      public virtual JDFComponent addComponent(string cType, bool bInput, JDFNode resRoot, bool bLink)
      {
         JDFComponent c = (JDFComponent)addResource(ElementName.COMPONENT, JDFResource.EnumResourceClass.Quantity, bInput, resRoot, bLink, null);

         if (c != null)
         {
            // true --> input resource
            c.setResStatus(JDFResource.EnumResStatus.Unavailable, false);
            c.setDescriptiveName(cType);
         }

         return c;
      }

      ///   
      ///	 <summary> * Set attribute SpawnID
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setSpawnID(string @value)
      {
         setAttribute(JDFConstants.SPAWNID, @value, null);
      }

      ///   
      ///	 <summary> * spawn a node; url is the file name of the new node, vRWResourceUsage is the vector of Resources Usages (or Names
      ///	 * if no usage exists for the process) that are spawned RW, all others are spawned read only; vParts is the vector
      ///	 * of part maps that are to be spawned, defaults to no part, i.e. the whole thing
      ///	 *  </summary>
      ///	 * <param name="parentURL"> </param>
      ///	 * <param name="spawnURL"> URL of the spawned JDF file </param>
      ///	 * <param name="vRWResources_in"> vector of resource names and Usage / ProcessUsage that are spawned as rw <br>
      ///	 *            the format is one of:<br>
      ///	 *            ResName:Input<br>
      ///	 *            ResName:Output<br>
      ///	 *            ResName:ProcessUsage<br> </param>
      ///	 * <param name="vSpawnParts"> vector of mAttributes that describe the parts to spawn, only valid PartIDKeys are allowed </param>
      ///	 * <param name="bSpawnROPartsOnly"> if true, only the parts of RO resources that are specified in vParts are spawned, else
      ///	 *            the complete resource is spawned </param>
      ///	 * <param name="bCopyNodeInfo"> copy the NodeInfo elements into the Ancestors </param>
      ///	 * <param name="bCopyCustomerInfo"> copy the CustomerInfo elements into the Ancestors </param>
      ///	 * <param name="bCopyComments"> copy the Comment elements into the Ancestors
      ///	 *  </param>
      ///	 * <returns> The spawned node
      ///	 * @since 050831 added bCopyComments
      ///	 * @tbd enhance nested spawning of partitioned nodes </returns>
      ///	 * @deprecated - use JDFSpawn class ( see code below)
      ///	 * @default spawn(parentURL, null, null, null, false, false, false, false) 
      ///	 
      [Obsolete("- use JDFSpawn class ( see code below)")]
      public virtual JDFNode spawn(string parentURL, string spawnURL, ArrayList vRWResources_in, VJDFAttributeMap vSpawnParts, bool bSpawnROPartsOnly, bool bCopyNodeInfo, bool bCopyCustomerInfo, bool bCopyComments)
      {
         JDFSpawn spawn = new JDFSpawn(this);
         return spawn.spawn(parentURL, spawnURL, vRWResources_in, vSpawnParts, bSpawnROPartsOnly, bCopyNodeInfo, bCopyCustomerInfo, bCopyComments);
      }

      ////

      ///   
      ///	 <summary> * spawn a node in informative mode without modifying the root JDF; url is the file name of the new node, the
      ///	 * parameters except for the list of rw resources, which are by definition empty, are identical to those of Spawn
      ///	 * 
      ///	 * vRWResourceUsage is the vector of Resources Usages, Resource Names or Resource IDs that are spawned RW, all
      ///	 * others are spawned read only; vParts is the vector of part maps that are to be spawned, defaults to no part, i.e.
      ///	 * the whole thing
      ///	 *  </summary>
      ///	 * <param name="spawnURL"> URL of the spawned JDF file </param>
      ///	 * <param name="vSpawnParts"> vector of mAttributes that describe the parts to spawn </param>
      ///	 * <param name="bSpawnROPartsOnly"> if true, only the parts of RO resources that are specified in vParts are spawned, else
      ///	 *            the complete resource is spawned </param>
      ///	 * <param name="bCopyNodeInfo"> copy the NodeInfo elements into the Ancestors </param>
      ///	 * <param name="bCopyCustomerInfo"> copy the CustomerInfo elements into the Ancestors </param>
      ///	 * <param name="bCopyComments"> copy the Comment elements into the Ancestors </param>
      ///	 * <returns> JDFDoc - the spawned node's owner document.
      ///	 * 
      ///	 * @default spawnInformative(parentURL, null, null, false, false, false, false); </returns>
      ///	 * @deprecated use JDFSpawn.spawnInformative() 
      ///	 
      [Obsolete("use JDFSpawn.spawnInformative()")]
      public virtual JDFNode spawnInformative(string parentURL, string spawnURL, VJDFAttributeMap vSpawnParts, bool bSpawnROPartsOnly, bool bCopyNodeInfo, bool bCopyCustomerInfo, bool bCopyComments)
      {
         JDFSpawn _spawn = new JDFSpawn(this);
         return _spawn.spawnInformative(parentURL, spawnURL, vSpawnParts, bSpawnROPartsOnly, bCopyNodeInfo, bCopyCustomerInfo, bCopyComments);
      }


      ///   
      ///	 <summary> * Method unSpawn. undo a spawn, removing any and all bookkeeping of that spawning
      ///	 *  </summary>
      ///	 * <param name="spawnID"> spawnID of the spawn to undo </param>
      ///	 * <returns> the fixed unspawned node </returns>
      ///	 * @deprecated use new JDFSpawn(this).unSpawn(spawnID); 
      ///	 
      [Obsolete("use new JDFSpawn(this).unSpawn(spawnID);")]
      public virtual JDFNode unSpawn(string spawnID)
      {
         return new JDFSpawn(this).unSpawn(spawnID);
      }

      ///   
      ///	 <summary> * merge nodes in a way that no duplicate elements are created<br>
      ///	 * attention !! this kills pools !!
      ///	 *  </summary>
      ///	 * <param name="e"> the node element to merge with the current node </param>
      ///	 * <param name="bDelete"> if true KElement e will be deleted </param>
      ///	 * <returns> JDFNode: the merged node element </returns>
      ///	 
      // JDFNode MergeNode(JDFNode e,bool bDelete);
      public virtual JDFNode mergeNode(JDFNode e, bool bDelete)
      {
         // merge nodes in a way that no duplicate elements are created
         // attention - this kills pools....

         VElement v = e.getChildElementVector(null, null, null, true, 0, false);
         for (int i = 0; i < v.Count; i++)
         {
            KElement m = v[i];
            string strName = m.Name;
            KElement mHere = null;
            if ((strName.Equals(ElementName.NODEINFO)) || (strName.Equals(ElementName.CUSTOMERINFO)) || (strName.Equals(ElementName.RESOURCEPOOL)) || (strName.Equals(ElementName.RESOURCELINKPOOL)) || (strName.Equals(ElementName.ANCESTORPOOL)) || (strName.Equals(ElementName.AUDITPOOL)))
            {
               mHere = getElement_JDFElement(m.Name, null, 0);
            }
            if (mHere == null)
            {
               if (bDelete)
               {
                  moveElement(m, null);
               }
               else
               {
                  copyElement(m, null);
               }
            }
            else
            {
               mHere.mergeElement(m, bDelete);
               if (bDelete)
               {
                  m.deleteNode();
               }
            }
         }

         setAttributes(e);
         return this;
      }

      ///   
      ///	 <summary> * getLink - get the resourcelink that resides in the ResourceLinkPool of this node and references the resource r
      ///	 *  </summary>
      ///	 * <param name="r"> the resource you are searching a link for </param>
      ///	 * <param name="bInput">
      ///	 *  </param>
      ///	 * <returns> JDFResourceLink - the resource link you was searching for or if not found, a new empty JDFResource Link
      ///	 * 
      ///	 * @default getLink(r, true) </returns>
      ///	 * @deprecated use getLink(resource, EnumUsage) 
      ///	 
      [Obsolete("use getLink(resource, EnumUsage)")]
      public virtual JDFResourceLink getLink(JDFResource r, bool bInput)
      {
         return getLink(r, bInput ? EnumUsage.Input : EnumUsage.Output);
      }

      ///   
      ///	 <summary> * getLink - get the resourcelink that resides in the ResourceLinkPool of this node and references the resource r
      ///	 *  </summary>
      ///	 * <param name="r"> the resource you are searching a link for </param>
      ///	 * <param name="usage"> the usage attribute of the link. If null, both input and output resourelinks will be returned
      ///	 *  </param>
      ///	 * <returns> JDFResourceLink - the resource link you was searching for or if not found, null
      ///	 *  </returns>
      ///	 
      public virtual JDFResourceLink getLink(JDFResource r, EnumUsage usage)
      {
         // get the reslink pool
         JDFResourceLinkPool p = getResourceLinkPool();

         if (p == null || r == null)
         {
            return null;
         }

         // get any possible links
         VElement v = p.getInOutLinks(usage, true, null, null);

         if (v != null)
         {
            // is it the right one?
            int vSize = v.Count;
            for (int i = 0; i < vSize; i++)
            {
               JDFResourceLink resLink = (JDFResourceLink)v[i];

               if (resLink != null && resLink.getrRef().Equals(r.getID()) && resLink.Name.Equals(r.getLinkString()))
               {
                  return resLink;
               }
            }
         }

         // nothing found
         return null;
      }

      ///   
      ///	 <summary> * getRoot - this function returns the root of the JDF document
      ///	 *  </summary>
      ///	 * <returns> JDFNode - the root node of the document </returns>
      ///	 
      public virtual JDFNode getRoot()
      {
         return (JDFNode)getDeepParent(ElementName.JDF, int.MaxValue);
      }

      ///   
      ///	 <summary> * Get an ordered list of all Parents ID attributes:<br>
      ///	 * the last entry is the direct parent, the last-1 entry is the grandparent etc.<br>
      ///	 * This is analog to the definition of JDFAncestorPool
      ///	 *  </summary>
      ///	 * <returns> vector of strings representing the node IDs </returns>
      ///	 
      public virtual VString getAncestorIDs()
      {
         VString vs = new VString();
         JDFNode me = this;

         while (true)
         {
            string pid = me.getID();
            vs.Add(pid);

            KElement parent = me.getParentNode_KElement();

            if (parent == null)
            {
               break;
            }
            else if (!(parent is JDFNode))
            {
               break;
            }

            me = (JDFNode)parent;
         }

         // 010702 invert
         VString vs2 = new VString();
         for (int i = vs.Count - 1; i >= 0; i--)
         {
            vs2.Add(vs[i]);
         }

         return vs2;
      }

      ///   
      ///	 <summary> * getAncestorNode - return the ancestor node
      ///	 *  </summary>
      ///	 * <param name="nSkip"> </param>
      ///	 * @deprecated use getParentJDF() 
      ///	 * <returns> JDFNode - the ancestor node </returns>
      ///	 
      [Obsolete("use getParentJDF()")]
      public virtual JDFNode getAncestorNode(int nSkip)
      {
         KElement parent = getParentNode_KElement();
         JDFNode node = (JDFNode)parent;

         if (node != null)
         {
            for (int i = 0; i < nSkip; i++)
            {
               parent = node.getParentNode_KElement();
               node = (JDFNode)parent;

               if (node == null)
               {
                  break;
               }
            }
         }

         return node;
      }

      ///   
      ///	 <summary> * searches for the first element occurence in the parent nodes and then the ancestor elements of the root
      ///	 * ancestorpool
      ///	 *  </summary>
      ///	 * <param name="attrib"> the element name </param>
      ///	 * <param name="nameSpaceURI"> the XML-namespace </param>
      ///	 * <param name="def"> the default value, if there is no ancestor attribute
      ///	 *  </param>
      ///	 * <returns> String - value of attribute found, value of def if not available
      ///	 * 
      ///	 * @default getAncestorAttribute(attrib, null, null) </returns>
      ///	 
      public virtual string getAncestorAttribute(string attrib, string nameSpaceURI, string def)
      {
         string s = getInheritedAttribute(attrib, nameSpaceURI, null);
         if (s != null)
         {
            return s;
         }
         JDFNode root = getJDFRoot();
         if (root == null)
         {
            return def;
         }
         // not in the inherited nodes, check the root node's AncestorPool
         JDFAncestorPool ap = root.getAncestorPool();
         if (ap == null)
         {
            return def;
         }
         return ap.getAncestorAttribute(attrib, nameSpaceURI, def);
      }

      ///   
      ///	 <summary> * true if a non default attribute occurence in the parent nodes and then the ancestor elements of the root
      ///	 * ancestorpool exists
      ///	 *  </summary>
      ///	 * <param name="attrib"> the attribute name </param>
      ///	 * <param name="nameSpaceURI"> the XML-namespace
      ///	 *  </param>
      ///	 * <returns> true if the attribute exists
      ///	 * 
      ///	 * @default hasAncestorAttribute(attrib, null) </returns>
      ///	 
      public virtual bool hasAncestorAttribute(string attrib, string nameSpaceURI)
      {
         return getAncestorAttribute(attrib, nameSpaceURI, null) != null;
      }

      ///   
      ///	 <summary> * Check existance of attribute Activation
      ///	 *  </summary>
      ///	 * <param name="bInherit"> recurse through ancestors and Ancestor elements of the AncestorPool when searching </param>
      ///	 * <returns> true if attribute Activation exists </returns>
      ///	 
      // bool hasActivation(bool bInherit=false) ;
      public virtual bool hasActivation(bool bInherit)
      {
         if (bInherit)
         {
            return hasAncestorAttribute(AttributeName.ACTIVATION, null);
         }
         return hasAttribute(AttributeName.ACTIVATION, null, false);
      }

      ///   
      ///	 <summary> * Check existence of attribute JobID
      ///	 *  </summary>
      ///	 * <param name="bInherit"> recurse through ancestors and Ancestor elements of the AncestorPool when searching </param>
      ///	 * <returns> true if attribute JobID exists
      ///	 * @deprecated </returns>
      ///	 
      [Obsolete]
      public virtual bool hasJobID(bool bInherit)
      {
         if (bInherit)
         {
            return hasAncestorAttribute(AttributeName.JOBID, null);
         }
         return hasAttribute(AttributeName.JOBID, null, false);
      }

      ///   
      ///	 <summary> * searches for the first element occurence in the ancestor elements
      ///	 *  </summary>
      ///	 * <param name="element"> the attribute name </param>
      ///	 * <param name="nameSpaceURI"> the XML-namespace
      ///	 * @since 180502 </param>
      ///	 * <returns> the KElement found </returns>
      ///	 
      public virtual KElement getAncestorElement(string element, string nameSpaceURI)
      {
         JDFElement e = (JDFElement)getInheritedElement(element, nameSpaceURI, 0);
         if (e != null)
         {
            return e;
         }

         JDFNode root = getJDFRoot();
         if (root == null)
         {
            return null;
         }
         // not in the inherited nodes, check the root node's AncestorPool
         JDFAncestorPool ap = root.getAncestorPool();
         if (ap == null)
         {
            return null;
         }

         return ap.getAncestorElement(element, nameSpaceURI, null);
      }

      ///   
      ///	 <summary> * true if a non default attribute occurs in the parent nodes and then the ancestor elements of the root
      ///	 * ancestorpool exists
      ///	 * 
      ///	 *@deprecated </summary>
      ///	 * <param name="element"> the attribute name </param>
      ///	 * <param name="nameSpaceURI"> the XML-namespace
      ///	 * @since 180502 </param>
      ///	 * <returns> boolean - true if the attribute exists </returns>
      ///	 
      [Obsolete]
      public virtual bool hasAncestorElement(string element, string nameSpaceURI)
      {

         return getAncestorElement(element, nameSpaceURI) != null;
      }

      ///   
      ///	 <summary> * addParameter - add a parameter resource to resroot and link it to this process
      ///	 *  </summary>
      ///	 * <param name="strName"> </param>
      ///	 * <param name="bInput"> </param>
      ///	 * <param name="resRoot"> </param>
      ///	 * <param name="bLink">
      ///	 *  </param>
      ///	 * <returns> JDFResource </returns>
      ///	 * @deprecated use addResource(strName, JDFResource.EnumClass.Parameter, bInput, resRoot, bLink, null) 
      ///	 
      [Obsolete("use addResource(strName, JDFResource.EnumClass.Parameter, bInput, resRoot, bLink, null)")]
      public virtual JDFResource addParameter(string strName, bool bInput, JDFNode resRoot, bool bLink)
      {
         return addResource(strName, JDFResource.EnumResourceClass.Parameter, bInput, resRoot, bLink, null);
      }

      ///   
      ///	 <summary> * addConsumable - add a consumable resource to resroot and link it to this process
      ///	 *  </summary>
      ///	 * <param name="strName"> </param>
      ///	 * <param name="bInput"> </param>
      ///	 * <param name="resRoot"> </param>
      ///	 * <param name="bLink">
      ///	 *  </param>
      ///	 * @deprecated use addResource(name, null, true, null, true) 
      ///	 * <returns> JDFResource
      ///	 * 
      ///	 * @default addResource(name, null, true, null, true) </returns>
      ///	 
      [Obsolete("use addResource(name, null, true, null, true)")]
      public virtual JDFResource addConsumable(string strName, bool bInput, JDFNode resRoot, bool bLink)
      {
         return addResource(strName, JDFResource.EnumResourceClass.Consumable, bInput, resRoot, bLink, null);
      }

      ///   
      ///	 <summary> * addHandling - add a handling resource to resroot and link it to this process
      ///	 *  </summary>
      ///	 * <param name="strName"> </param>
      ///	 * <param name="bInput"> </param>
      ///	 * <param name="resRoot"> </param>
      ///	 * <param name="bLink">
      ///	 *  </param>
      ///	 * @deprecated use addResource(name, null, true, null, true) 
      ///	 * <returns> JDFResource
      ///	 * 
      ///	 * @default addResource(name, JDFResource.EnumClass.Handling, true, null, true) </returns>
      ///	 
      [Obsolete("use addResource(name, null, true, null, true)")]
      public virtual JDFResource addHandling(string strName, bool bInput, JDFNode resRoot, bool bLink)
      {
         return addResource(strName, JDFResource.EnumResourceClass.Handling, bInput, resRoot, bLink, null);
      }

      ///   
      ///	 <summary> * isCombined - is this a Combined resource type ?
      ///	 *  </summary>
      ///	 * <returns> boolean - true if it is, otherwise false </returns>
      ///	 * @deprecated use JDFConstants.COMBINED.equals(getType()); 
      ///	 
      [Obsolete("use JDFConstants.COMBINED.equals(getType());")]
      public virtual bool isCombined()
      {
         return JDFConstants.COMBINED.Equals(getType());
      }

      ///   
      ///	 <summary> * Is this a Combined node type ?
      ///	 *  </summary>
      ///	 * <returns> boolean - true if this is a product node </returns>
      ///	 * @deprecated use JDFConstants.PRODUCT.equals(getType()); 
      ///	 
      [Obsolete("use JDFConstants.PRODUCT.equals(getType());")]
      public virtual bool isProduct()
      {
         return JDFConstants.PRODUCT.Equals(getType());
      }

      ///   
      ///	 <summary> * Is this a Combined node type ?
      ///	 *  </summary>
      ///	 * <returns> boolean - true if this is a combined node </returns>
      ///	 * @deprecated use JDFConstants.PROCESSGROUP.equals(getType()); 
      ///	 
      [Obsolete("use JDFConstants.PROCESSGROUP.equals(getType());")]
      public virtual bool isProcessGroup()
      {
         return JDFConstants.PROCESSGROUP.Equals(getType());
      }

      ///   
      ///	 <summary> * Is this a group node type (ProcessGroup or Product)?
      ///	 *  </summary>
      ///	 * <returns> boolean - true if this is a combined node </returns>
      ///	 
      public virtual bool isGroupNode()
      {
         EnumType type2 = getEnumType();
         return EnumType.ProcessGroup.Equals(type2) && !hasAttribute(AttributeName.TYPES) || EnumType.Product.Equals(type2);
      }

      ///   
      ///	 <summary> * Is this a group node type that allows @Types (ProcessGroup or Combined)?
      ///	 *  </summary>
      ///	 * <returns> boolean - true if this is a combined node </returns>
      ///	 
      public virtual bool isTypesNode()
      {
         EnumType type2 = getEnumType();
         // return EnumType.ProcessGroup.equals(type2) &&
         // !hasChildElement(ElementName.JDF, null) ||
         // EnumType.Combined.equals(type2);
         return EnumType.ProcessGroup.Equals(type2) || EnumType.Combined.Equals(type2);

      }

      ///   
      ///	 <summary> * getIDPrefix
      ///	 *  </summary>
      ///	 * <returns> the ID prefix of JDFNode </returns>
      ///	 
      public override string getIDPrefix()
      {
         return "n";
      }

      ///   
      ///	 <summary> * get string attribute JobID
      ///	 *  </summary>
      ///	 * <param name="bInherit"> recurse through ancestors when searching </param>
      ///	 * <returns> String - attribute value </returns>
      ///	 
      public virtual string getJobID(bool bInherit)
      {
         if (bInherit)
         {
            return getAncestorAttribute(AttributeName.JOBID, null, JDFConstants.EMPTYSTRING);
         }
         return getAttribute(AttributeName.JOBID, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * get string attribute JobID
      ///	 *  </summary>
      ///	 * <returns> attribute value </returns>
      ///	 * @deprecated use getJobPartID(false); 
      ///	 
      [Obsolete("use getJobPartID(false);")]
      public virtual string getJobPartID()
      {
         return getJobPartID(false);
      }

      ///   
      ///	 <summary> * get string attribute JobID
      ///	 *  </summary>
      ///	 * <param name="bInherit"> if true recurse through ancestors when searching </param>
      ///	 * <returns> String - attribute value
      ///	 * 
      ///	 * @default getJobPartID(flase) </returns>
      ///	 
      public virtual string getJobPartID(bool bInherit)
      {
         if (bInherit)
         {
            return getAncestorAttribute(AttributeName.JOBPARTID, null, JDFConstants.EMPTYSTRING);
         }
         return getAttribute(AttributeName.JOBPARTID, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * Set attribute JobPartID
      ///	 *  </summary>
      ///	 * <param name="jobPartID"> the value to set the attribute to </param>
      ///	 
      public virtual void setJobPartID(string jobPartID)
      {
         setAttribute(AttributeName.JOBPARTID, jobPartID, null);
      }

      ///   
      ///	 <summary> * set attribute JobID
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setJobID(string @value)
      {
         setAttribute(AttributeName.JOBID, @value, null);
      }

      ///   
      ///	 <summary> * test element StatusPool existence
      ///	 *  </summary>
      ///	 * <returns> boolean - true if a matching element exists
      ///	 * @deprecated </returns>
      ///	 
      [Obsolete]
      public virtual bool hasStatusPool()
      {
         return numChildElements(ElementName.STATUSPOOL, null) > 0;
      }

      ///   
      ///	 <summary> * get string attribute SpawnID
      ///	 *  </summary>
      ///	 * <returns> String - attribute value </returns>
      ///	 * @deprecated use getSpawnID(boolean) 
      ///	 
      [Obsolete("use getSpawnID(boolean)")]
      public virtual string getSpawnID()
      {
         return getSpawnID(false);
      }

      ///   
      ///	 <summary> * get string attribute SpawnID
      ///	 *  </summary>
      ///	 * <param name="bInherit"> if true recurse through ancestors when searching </param>
      ///	 * <returns> String - attribute value
      ///	 * 
      ///	 * @default getSpawnID(false) </returns>
      ///	 
      public virtual string getSpawnID(bool bInherit)
      {
         if (bInherit)
         {
            return getAncestorAttribute(AttributeName.SPAWNID, null, JDFConstants.EMPTYSTRING);
         }
         return getAttribute(AttributeName.SPAWNID);
      }

      ///   
      ///	 <summary> * remove attribute SpawnID
      ///	 * 
      ///	 * @deprecated </summary>
      ///	 
      [Obsolete]
      public virtual void removeSpawnID()
      {
         removeAttribute(JDFConstants.SPAWNID, null);
      }

      ///   
      ///	 <summary> * remove element AncestorPool
      ///	 * 
      ///	 * @deprecated </summary>
      ///	 
      [Obsolete]
      public virtual void removeAncestorPool()
      {
         removeChild(ElementName.ANCESTORPOOL, null, 0);
      }

      ///   
      ///	 <summary> * get the Parent JDFNode, null if the parent element is the document or an envelope xml
      ///	 *  </summary>
      ///	 * <returns> JDFNode: the parent JDF, null if this is the root JDF </returns>
      ///	 * @deprecated use getParentJDF() 
      ///	 * 
      [Obsolete("use getParentJDF()")]
      public virtual JDFNode getParentJDFNode()
      {
         return getParentJDF();
      }

      ///   
      ///	 <summary> * get the Parent JDFNode, null if the parent element is the document or an envelope xml
      ///	 *  </summary>
      ///	 * <returns> JDFNode: the parent JDF, null if this is the root JDF </returns>
      ///	 
      public override JDFNode getParentJDF()
      {
         KElement jdfElem = getParentNode_KElement();
         if (jdfElem is JDFNode)
         {
            return (JDFNode)jdfElem;
         }
         return null;
      }

      ///   
      ///	 <summary> * definition of resource link usage, cardinality and ProcessUsage in the JDF namespace for one index
      ///	 *  </summary>
      ///	 * <param name="namIndex"> index of the named list, if<0 tokenize all </param>
      ///	 * <returns> list of resource process usages that may be linked </returns>
      ///	 
      private VString vLinkInfo(int namIndex)
      {
         int namIndexLocal = namIndex;

         VString vRet = new VString();
         VString linkInfo_ = linkInfo();

         if (namIndexLocal < 0)
         {
            // tokenize retains order
            return new VString(linkInfo_);
         }

         VString linkNames_ = linkNames();

         string strName = linkNames_.stringAt(namIndexLocal);

         while (namIndexLocal >= 0)
         {
            string kToken = linkInfo_.stringAt(namIndexLocal);
            VString vToken = new VString(StringUtil.tokenize(kToken, JDFConstants.BLANK, false));

            vRet.addAll(vToken);
            namIndexLocal = linkNames_.IndexOf(strName, ++namIndexLocal);
         }

         return vRet.IsEmpty() ? null : vRet;
      }

      ///   
      ///	 <summary> * Get the index in Linknames of the ResourceLink described by rl
      ///	 *  </summary>
      ///	 * <param name="rl"> </param>
      ///	 * <param name="nOccur"> for looping over combined nodes </param>
      ///	 * <returns> -1 if it does not fit </returns>
      ///	 
      private int[] getMatchingNamIndex(JDFResourceLink rl, int nOccur)
      {
         int[] ret = new int[2];
         ret[0] = ret[1] = -1;
         if (rl == null)
         {
            return ret;
         }

         // 311002 KM added nOccur for looping over combined nodes
         // TBD evaluate CombinedProcessIndex when generating nOccur
         VString linkNames_ = linkNames();
         if (linkNames_ == null)
         {
            return ret;
         }

         int namIndex = linkNames_.IndexOf(rl.getLinkedResourceName());

         // int namIndex = vName.index((new
         // KString(rl.Name)).leftStr(-4), nOccur);
         // 120802 rp add check for *
         if (namIndex < 0)
         {
            namIndex = linkNames_.IndexOf(JDFConstants.STAR);
         }

         if (namIndex < 0)
         {
            return ret;
         }

         VString vIndex = vLinkInfo(namIndex);
         if (vIndex == null)
         {
            return ret;
         }

         int iLoop = 0;
         for (int i = 0; i < vIndex.Count; i++)
         {

            string typ = vIndex[i];

            if (typ[0] == 'i' && !JDFResourceLink.EnumUsage.Input.Equals(rl.getUsage()))
            {
               continue;
            }
            if (typ[0] == 'o' && !JDFResourceLink.EnumUsage.Output.Equals(rl.getUsage()))
            {
               continue;
            }
            if (typ.Length > 2)
            { // processusage is specified
               if (!StringUtil.rightStr(typ, -2).Equals(rl.getProcessUsage()))
               {
                  continue;
               }
            }
            else
            { // no processusage is specified
               if (rl.hasAttribute(AttributeName.PROCESSUSAGE))
               {
                  continue;
               }

            }
            if (iLoop++ < nOccur)
            {
               continue;
            }
            ret[0] = namIndex;
            ret[1] = i;
            return ret;
         }
         return ret;
      }

      ///   
      ///	 <summary> * Check existence of attribute Type
      ///	 *  </summary>
      ///	 * <returns> boolean - true if attribute Type exists </returns>
      ///	 * @deprecated use inline hasAttribute 
      ///	 
      [Obsolete("use inline hasAttribute")]
      public virtual bool hasType()
      {
         return hasAttribute(AttributeName.TYPE, null, false);
      }

      ///   
      ///	 <summary> * get a vector of Link names that may be inserted in this element if the links need a processusage, the format is
      ///	 * LinkName:ProcessUsage
      ///	 *  </summary>
      ///	 * <param name="nMax"> maximum size of the returned vector </param>
      ///	 * <returns> vector of strings that contains insertable link names </returns>
      ///	 
      public virtual VString getInsertLinkVector(int nMax)
      {
         VString names = linkNames();
         VString vInsert = new VString();
         for (int i = 0; i < names.Count; i++)
         {
            VString types = vLinkInfo(i);
            for (int j = 0; j < types.Count; j++)
            {
               EnumProcessUsage pu = getEnumProcessUsage(types[j], 0);
               if ((types[j])[1] == '?' || (types[j])[1] == '_')
               {
                  // 110602 added
                  if (getMatchingLink(names[i], pu, 0) != null)
                  {
                     continue; // skip existing links with maxOccurs=1
                  }
               }

               string s = names[i] + "Link";
               if (pu != null)
               {
                  s += JDFConstants.COLON + pu.getName();
               }
               vInsert.Add(s);
               if (vInsert.Count >= nMax)
               {
                  break;
               }
            }
         }
         return vInsert;
      }


      ///   
      ///	 <summary> * get the resource that matches the typesafe link described by i
      ///	 *  </summary>
      ///	 * <param name="info"> the LinkInfo string for this name </param>
      ///	 * <param name="i"> the index of the pu to find </param>
      ///	 * <returns> the enumerated process usage of this checked link
      ///	 * @default getEnumProcessUsage(info, 0) </returns>
      ///	 
      public virtual EnumProcessUsage getEnumProcessUsage(string info, int i)
      {
         string iToken = StringUtil.token(info, i, JDFConstants.BLANK);
         if (iToken.Equals(JDFConstants.EMPTYSTRING))
         {
            return null;
         }

         if (iToken.Length > 2)
         {
            string pu = iToken.Substring(2);
            return EnumProcessUsage.getEnum(pu);
         }

         if (iToken[0] == 'i')
         {
            return EnumProcessUsage.AnyInput;
         }
         else if (iToken[0] == 'o')
         {
            return EnumProcessUsage.AnyOutput;
         }
         else
         {
            throw new JDFException("JDFNode.getEnumProcessUsage: bad input: " + info);
         }
      }

      ///   
      ///	 <summary> * test element AncestorPool existance
      ///	 *  </summary>
      ///	 * @deprecated use numChildElements(ElementName.ANCESTORPOOL, null) > 0; 
      ///	 * <returns> bool true if a matching element exists </returns>
      ///	 
      [Obsolete("use numChildElements(ElementName.ANCESTORPOOL, null) > 0;")]
      public virtual bool hasAncestorPool()
      {
         return numChildElements(ElementName.ANCESTORPOOL, null) > 0;
      }

      ///   
      ///	 <summary> * Check existance of attribute ProjectID
      ///	 *  </summary>
      ///	 * <param name="bInherit"> recurse through ancestors when searching </param>
      ///	 * <returns> true if attribute ProjectID exists
      ///	 * @deprecated </returns>
      ///	 
      [Obsolete]
      public virtual bool hasProjectID(bool bInherit)
      {
         if (bInherit)
         {
            return hasAncestorAttribute(JDFConstants.PROJECTID, null);
         }
         return hasAttribute(JDFConstants.PROJECTID, null, false);
      }

      ///   
      ///	 <summary> * Check existence of attribute ProjectID
      ///	 *  </summary>
      ///	 * <returns> true if attribute ProjectID exists
      ///	 * @deprecated </returns>
      ///	 
      [Obsolete]
      public virtual bool hasProjectID()
      {
         return hasProjectID(false);
      }

      ///   
      ///	 <summary> * set attribute ProjectID
      ///	 *  </summary>
      ///	 * <param name="strValue"> the value to set the attribute to </param>
      ///	 
      public virtual void setProjectID(string strValue)
      {
         setAttribute(JDFConstants.PROJECTID, strValue, null);
      }

      ///   
      ///	 <summary> * get string attribute ProjectID
      ///	 *  </summary>
      ///	 * <param name="bInherit"> recurse through ancestors when searching </param>
      ///	 * <returns> the value of the attribute </returns>
      ///	 
      public virtual string getProjectID(bool bInherit)
      {
         if (bInherit)
         {
            return getAncestorAttribute(JDFConstants.PROJECTID, null, JDFConstants.EMPTYSTRING);
         }
         return getAttribute(JDFConstants.PROJECTID, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * get string attribute ProjectID
      ///	 *  </summary>
      ///	 * <returns> the value of the attribute </returns>
      ///	 * @deprecated use getProjectID(boolean bInherit) 
      ///	 
      [Obsolete("use getProjectID(boolean bInherit)")]
      public virtual string getProjectID()
      {
         return getProjectID(false);
      }

      ///   
      ///	 <summary> * definition of the length of LinkNames, LinkInfo for generic JDF nodes
      ///	 *  </summary>
      ///	 * <returns> int - length of the generic () link string functions, </returns>
      ///	 * @deprecated use m_strGenericLinkNames.length; 
      ///	 
      [Obsolete("use m_strGenericLinkNames.length;")]
      public virtual int getGenericLinksLength()
      {
         return m_strGenericLinkNames.Length;
      }

      ///   
      ///	 <summary> * isValidLink check whether an index is legal for this class
      ///	 *  </summary>
      ///	 * <param name="level"> the checking level </param>
      ///	 * <param name="rl"> the JDFResourceLink to check </param>
      ///	 * <param name="doneNameList"> Vector of Integer </param>
      ///	 * <param name="doneIndexList"> Vector of Integer </param>
      ///	 * <returns> true if valid </returns>
      ///	 
      public virtual bool isValidLink(EnumValidationLevel level, JDFResourceLink rl, List<int> doneNameList, List<int> doneIndexList)
      {
         List<int> doneNameListLocal = doneNameList;
         List<int> doneIndexListLocal = doneIndexList;

         if (rl == null)
         {
            return false;
         }

         if (!isInJDFNameSpaceStatic(rl))
         {
            return true;
         }

         // allow call with initial null
         if (doneIndexListLocal == null)
         {
            doneIndexListLocal = new List<int>();
         }
         if (doneNameListLocal == null)
         {
            doneNameListLocal = new List<int>();
         }

         int nOccur = 0;
         int iIndex;
         int namIndex;

         // loop over all potential occurrences
         while (true)
         {
            // on the C++ side the following two methods are represented with
            // a method getMatchingIndex(rl, iIndex, nOccur) that
            // has 3 parameters, one of them is a reference(!) at iIndex
            int[] ii = getMatchingNamIndex(rl, nOccur);
            namIndex = ii[0];
            iIndex = ii[1];

            // not found -> check whether this node is known yet
            if (namIndex < 0)
            {
               EnumType enumType = getEnumType();
               if (enumType == null || enumType.Equals(EnumType.ProcessGroup) || (enumType.Equals(EnumType.Combined) && getEnumTypes() == null))
               {
                  return true;
               }
               return false;
            }

            // loop over all completed occurrences with maxOccurs=1
            // if they have already been found, search for next occurrence
            bool bTryNext = false;
            int dns = doneNameListLocal.Count;

            for (int i = 0; i < dns; i++)
            {
               //if (((int) doneNameListLocal[i]).intValue() == namIndex && ((int) doneIndexListLocal[i]).intValue() == iIndex)
               if (((int)doneNameListLocal[i]) == namIndex && ((int)doneIndexListLocal[i]) == iIndex)
               {
                  nOccur++; // this one is gone, try next
                  bTryNext = true;
                  break;
               }
            }

            if (!bTryNext) // we got here and the link is potentially valid
            {
               break;
            }
         }

         bool isValid = rl.isValid(level);

         // TODO remove line wchar_t card=vLinkInfo(namIndex)[iIndex][1];
         VString vCard = vLinkInfo(namIndex);
         string str = vCard.stringAt(iIndex);
         char card = str[1];

         if (isValid && ((card == '_') || (card == '?')))
         {
            doneNameListLocal.Add(namIndex);
            doneIndexListLocal.Add(iIndex);
         }

         return isValid;
      }

      ///   
      ///	 * @deprecated use getMissingLinkVector 
      ///	 * <param name="nMax"> </param>
      ///	 * <returns> VString </returns>
      ///	 
      [Obsolete("use getMissingLinkVector")]
      public virtual VString getMissingLinks(int nMax)
      {
         return getMissingLinkVector(nMax);
      }

      ////

      ///   
      ///	 <summary> * get the links that match the typesafe resource name if the Resource type is not defined for the process
      ///	 * represented by this node see chapter 6 JDFSpec, then the links are ignored
      ///	 *  </summary>
      ///	 * <param name="resName"> of the resource to remove </param>
      ///	 * <param name="bLink"> if false, returns the linked resources, else if true, returns the ResourceLink elements </param>
      ///	 * <param name="processUsage"> enum that defines if all links matching the name or only those matching the name usage and/or
      ///	 *            processusage are requested </param>
      ///	 * <returns> vector of resourcelink elements </returns>
      ///	 
      public virtual VElement getMatchingLinks(string resName, bool bLink, EnumProcessUsage processUsage)
      {
         VElement vE = null;

         JDFResourceLinkPool rlp = getResourceLinkPool();
         if (rlp == null)
         {
            return null;
         }

         VString linkNames_ = linkNames();
         if (linkNames_ == null)
         {
            return rlp.getInOutLinks(null, bLink, resName, null);
         }

         int namIndex = linkNames_.IndexOf(resName);
         if (namIndex < 0)
         {
            namIndex = linkNames_.IndexOf(JDFConstants.STAR);
            if (namIndex < 0)
            {
               return null;
            }
         }

         VString vInfo = vLinkInfo(namIndex);

         if (processUsage != null && processUsage.getValue() > EnumProcessUsage.AnyOutput.getValue())
         {
            string pu = processUsage.getName();
            for (int i = 0; i < vInfo.Count; i++)
            {
               if ((vInfo[i]).EndsWith(pu))
               {
                  bool bInput = (vInfo[i])[0] == 'i';
                  // 240502 RP bug fix by Komori
                  vE = rlp.getInOutLinks(bInput ? EnumUsage.Input : EnumUsage.Output, bLink, resName, processUsage);
                  break;
               }
            }
         }
         else
         {
            if (processUsage == null)
            {
               string linkName = null;
               if (resName != null && !resName.EndsWith("Link"))
                  linkName = resName + "Link";
               vE = rlp.getPoolChildren(linkName, null, null);
               if (!bLink)
               {
                  vE = JDFResourceLinkPool.resourceVector(vE, resName);
               }
            }
            else if (processUsage == EnumProcessUsage.AnyInput)
            {
               vE = rlp.getInOutLinks(EnumUsage.Input, bLink, resName, null);
               // 170205 RP remove internal pipes from all inputs
               // TODO ideally we would check if they are connected, but this
               // is a sufficient 98% solution
               if (bLink && vE != null)
               {
                  VElement.Enumerator vEIterator = vE.GetEnumerator();
                  while (vEIterator.MoveNext())
                  {
                     JDFResourceLink rl = (JDFResourceLink)vEIterator.Current;
                     if (rl.getPipeProtocol().Equals(JDFConstants.INTERNAL))
                     {
                        vEIterator.Dispose();
                     }
                  }
               }
            }
            else if (processUsage == EnumProcessUsage.AnyOutput)
            {
               // Java to C# Conversion - Eliminate unreachable code warning
               //vE = rlp.getInOutLinks(false ? EnumUsage.Input : EnumUsage.Output, bLink, resName, null);
               vE = rlp.getInOutLinks(EnumUsage.Output, bLink, resName, null);

               // 170205 RP remove internal pipes from all outputs
               // TODO ideally we would check if they are connected, but this
               // is a sufficient 98% solution
               if (bLink && vE != null)
               {
                  VElement.Enumerator vEIterator = vE.GetEnumerator();
                  while (vEIterator.MoveNext())
                  {
                     JDFResourceLink rl = (JDFResourceLink)vEIterator.Current;
                     if (JDFConstants.INTERNAL.Equals(rl.getPipeProtocol()))
                     {
                        vEIterator.Dispose();
                     }
                  }
               }
            }
         }
         return vE;
      }

      ///   
      ///	 <summary> * get a vector of Link names that are missing in this element<br>
      ///	 * if the links need a processusage, the format is LinkName:ProcessUsage
      ///	 *  </summary>
      ///	 * <param name="nMax"> maximum size of the returned vector </param>
      ///	 * <returns> VString vector of strings that contains missing Link names </returns>
      ///	 
      public virtual VString getMissingLinkVector(int nMax)
      {
         VString names = linkNames();
         if (names == null)
         {
            return null;
         }

         if (getType().Equals(EnumType.ProcessGroup.getName()))
         { // TODO fix processgroup with Types and gray box category entries
            return null;
         }

         VString vMissing = new VString();
         int nameSize = names.Count;
         for (int i = 0; i < nameSize; i++)
         {
            string nam = names.stringAt(i);
            bool namDone = false;
            for (int k = 0; k < i; k++)
            {
               if (names.stringAt(k).Equals(nam))
               {
                  namDone = true;
                  break;
               }
            }

            if (namDone)
            {
               continue; // already tested this name - vLinkInfo collects all
               // data
            }

            VString types = vLinkInfo(i);
            if (types != null)
            {
               VString.Enumerator typesIterator = types.GetEnumerator();
               while (typesIterator.MoveNext())
               {
                  string typesAt = typesIterator.Current;
                  if (typesAt[1] == '+' || typesAt[1] == '_')
                  {
                     // 110602 added
                     EnumProcessUsage pu = getEnumProcessUsage(typesAt, 0);
                     if (getMatchingLink(names[i], pu, 0) == null)
                     {
                        string s = names[i] + "Link";

                        if (pu != null)
                        {
                           s += JDFConstants.COLON + pu.getName();
                        }

                        vMissing.Add(s);
                        if (vMissing.Count >= nMax)
                        {
                           break;
                        }
                     }
                  }
               }
            }
         }

         return vMissing;
      }

      ///   
      ///	 <summary> *  </summary>
      ///	 * <param name="resName"> </param>
      ///	 * <param name="processUsage"> </param>
      ///	 * <param name="partMap"> </param>
      ///	 * <param name="pos"> </param>
      ///	 * @deprecated use getMatchingResource(String resName, EnumProcessUsage processUsage, JDFAttributeMap partMap, int
      ///	 *             pos)) 
      ///	 * <returns> JDFResource </returns>
      ///	 
      [Obsolete("use getMatchingResource(String resName, EnumProcessUsage processUsage, JDFAttributeMap partMap, int")]
      public virtual JDFResource getMatchingResource(string resName, int processUsage, JDFAttributeMap partMap, int pos)
      {
         JDFResourceLink rl = getMatchingLink(resName, EnumProcessUsage.getEnum(processUsage), pos);

         if (rl == null)
         {
            return null;
         }

         if (!partMap.IsEmpty() && !rl.hasPartMap(partMap))
         {
            return null;
         }

         JDFResource r = rl.getTarget();
         return r.getPartition(partMap, null);
      }

      ///   
      ///	 <summary> * get the resource that matches a typesafe resource name if the Resource type is not defined for the process
      ///	 * represented by this node see chapter 6 JDFSpec, then the resource is ignored
      ///	 *  </summary>
      ///	 * <param name="resName"> of the resource to remove </param>
      ///	 * <param name="processUsage"> enum that defines if all links matching the name or only those matching the name usage and/or
      ///	 *            processusage are requested </param>
      ///	 * <param name="partMap"> </param>
      ///	 * <param name="pos"> the position of the link if multiple matching links exist </param>
      ///	 * <returns> JDFResource - the resourcelink element </returns>
      ///	 
      public virtual JDFResource getMatchingResource(string resName, EnumProcessUsage processUsage, JDFAttributeMap partMap, int pos)
      {
         JDFResourceLink rl = getMatchingLink(resName, processUsage, pos);
         if (rl == null)
         {
            return null;
         }

         if (partMap != null && !partMap.IsEmpty() && !rl.hasPartMap(partMap))
         {
            return null;
         }

         JDFResource r = rl.getTarget();
         if (r == null)
         {
            return null;
         }

         return r.getPartition(partMap, null);
      }

      ///   
      ///	 <summary> * get the link that matches the typesafe resource name<br>
      ///	 * if the Resource type is not defined for the process represented by this node, the link is ignored (see JDF Spec
      ///	 * Chapter 6)
      ///	 *  </summary>
      ///	 * <param name="resName"> name of the resource to remove </param>
      ///	 * <param name="processUsage"> enum that defines if all links matching the name or only those matching the name usage and/or
      ///	 *            processusage are requested </param>
      ///	 * <param name="pos"> the position of the link (if multiple matching links exist) </param>
      ///	 * <returns> JDFResourceLink - the resourcelink </returns>
      ///	 
      public virtual JDFResourceLink getMatchingLink(string resName, EnumProcessUsage processUsage, int pos)
      {
         JDFResourceLink rl = null;

         VElement vE = getMatchingLinks(resName, true, processUsage);
         if (vE != null && vE.Count > pos)
         {
            rl = (JDFResourceLink)vE[pos];
         }
         return rl;
      }

      ///   
      ///	 <summary> * Method AppendMatchingResource. Appends a resource and link it to this if it is listed in the list of valid nodes
      ///	 * for for a JDF with the given type also creates the matching resource link in this
      ///	 *  </summary>
      ///	 * <param name="resName"> the name of the resource to add </param>
      ///	 * <param name="processUsage"> the processUsage of the resourcelink of the resource to add: <li>null
      ///	 *            EnumProcessUsage.AnyOutput - for input but no processUsage</li> <li>EnumProcessUsage.AnyOutput - for
      ///	 *            output but no processUsage</li>
      ///	 *  </param>
      ///	 * <param name="resourceRoot"> the root JDF node, that is the parent of the resourcepool where the resource should be added.
      ///	 *            If null, this node is assumed.
      ///	 *  </param>
      ///	 * <returns> JDFResource the newly created resource </returns>
      ///	 
      public virtual JDFResource appendMatchingResource(string resName, EnumProcessUsage processUsage, JDFNode resourceRoot)
      {
         // TODO check comment for processUsage
         VString vtyp = getMatchType(resName, processUsage);
         if (vtyp == null) // anything goes
         {
            bool bInput = !EnumProcessUsage.AnyOutput.Equals(processUsage);
            EnumUsage usage = bInput ? EnumUsage.Input : EnumUsage.Output;

            JDFResource r = addResource(resName, usage);
            JDFResourceLink rl = getLink(r, null);
            if (processUsage != null && processUsage.getValue() > EnumProcessUsage.AnyOutput.getValue())
            {
               rl.setProcessUsage(processUsage);
            }
            return r;
         }

         int nFound = 0;
         string foundTyp = null;
         bool foundMulti = false;
         int iInputFound = 0; // 1 is in, 2 is out

         for (int i = 0; i < vtyp.Count; i++)
         {
            string typ = vtyp[i];
            bool bInput = typ[0] == 'i';

            if ((typ[1] == '?') || (typ[1] == '_'))
            {
               if (numMatchingLinks(resName, false, processUsage) > nFound)
               {
                  nFound++; // TODO need to fix this, it is only a 90%
                  // solution
                  continue;
               }
            }
            if (foundTyp == null)
            {
               foundTyp = typ;
               iInputFound = bInput ? 1 : 2;

            }
            else if (!typ.Equals(foundTyp))
            {
               foundMulti = true;
               if ((bInput ? 1 : 2) != iInputFound)
               {
                  iInputFound = 0; // we could have either in or out - cannot
                  // link
                  break;
               }
            }
         }
         if (foundTyp == null)
         {
            // should only get here it the link alreay exists
            throw new JDFException("JDFNode.appendMatchingResource already exists");
         }
         JDFResource r2 = addResource(resName, EnumUsage.Input);
         if (iInputFound > 0)
         {
            JDFResourceLink rl = linkResource(r2, iInputFound == 1 ? EnumUsage.Input : EnumUsage.Output, null);
            if (!foundMulti && foundTyp.Length > 2)
            {
               rl.setProcessUsage(EnumProcessUsage.getEnum(foundTyp.Substring(2)));
            }
         }

         return r2;
      }

      ///   
      ///	 <summary> * get the matching types for a given resource
      ///	 *  </summary>
      ///	 * <param name="resName"> </param>
      ///	 * <param name="processUsage"> </param>
      ///	 * <returns> null if anything goes, an empty list if nothing goes, else the list of valid entries </returns>
      ///	 
      private VString getMatchType(string resName, EnumProcessUsage processUsage)
      {
         VString vRet = new VString();
         VString linkNames_ = linkNames();
         if (linkNames_ == null)
         {
            return null;
         }

         int namIndex = linkNames_.IndexOf(resName);
         if (namIndex < 0)
         {
            namIndex = linkNames_.IndexOf(JDFConstants.STAR);
         }
         if (namIndex < 0)
         {
            throw new JDFException("JDFNode.appendMatchingResource invalid resName: " + resName);
         }

         VString vInfo = vLinkInfo(namIndex);
         if (vInfo == null)
         {
            return null;
         }

         if ((processUsage == null))
         {
            return vInfo; // no filtering required
         }

         string infoTemp = null;
         string pu = processUsage.getName();

         for (int i = 0; i < vInfo.Count; i++)
         {
            infoTemp = vInfo[i];

            if (processUsage.getValue() > EnumProcessUsage.AnyOutput.getValue())
            {
               if (infoTemp.EndsWith(pu))
               {
                  vRet.Add(infoTemp);
               }
            }
            else
            {
               if (processUsage.getValue() == EnumProcessUsage.AnyInput.getValue() && infoTemp[0] == 'i')
               {
                  vRet.Add(infoTemp);
               }
               else if (processUsage.getValue() == EnumProcessUsage.AnyOutput.getValue() && infoTemp[0] == 'o')
               {
                  vRet.Add(infoTemp);
               }
            }
         }

         return vRet;
      }

      ///   
      ///	 <summary> * remove the link that matches the typesafe link resource name
      ///	 *  </summary>
      ///	 * <param name="resName"> name of the resource to remove </param>
      ///	 * <param name="processUsage"> enum that defines if all links matching the name or only those matching the name usage and/or
      ///	 *            processusage are requested </param>
      ///	 * <param name="bRemoveResource"> also remove the resource, if it is not linked by any other process </param>
      ///	 * <param name="pos"> the position of the link, if multiple matching links exist </param>
      ///	 * <returns> true if successful
      ///	 * 
      ///	 * @default removeMatchingLink(resName, processUsage, false, 0) </returns>
      ///	 
      public virtual bool removeMatchingLink(string resName, int processUsage, bool bRemoveResource, int pos)
      {
         JDFResourceLink l = null;
         l = getMatchingLink(resName, EnumProcessUsage.getEnum(processUsage), pos);
         if (l == null)
         {
            return false;
         }
         if (bRemoveResource)
         {
            JDFResource r = l.getLinkRoot();
            if (r.getLinks(null, null).Count == 0)
            {
               r.deleteNode();
            }
         }
         l.deleteNode();
         return true;
      }

      ///   
      ///	 <summary> * remove the link that matches the typesafe link resource name
      ///	 *  </summary>
      ///	 * <param name="resName"> name of the resource to remove </param>
      ///	 * <param name="processUsage"> enum that defines if all links matching the name or only those matching the name usage and/or
      ///	 *            processusage are requested </param>
      ///	 * <param name="bRemoveResource"> also remove the resource, if it is not linked by any other process </param>
      ///	 * <returns> true if successful
      ///	 * 
      ///	 * @default removeMatchingLink(resName, processUsage, false, 0) </returns>
      ///	 
      public virtual bool removeMatchingLinks(string resName, EnumProcessUsage processUsage, bool bRemoveResource)
      {
         VElement v = getMatchingLinks(resName, true, processUsage);
         for (int i = 0; i < v.Count; i++)
         {
            if (bRemoveResource)
            {
               JDFResource r = ((JDFResourceLink)v[i]).getLinkRoot();
               // only remove if not linked from elsewhere
               if (r.getLinks(null, null).IsEmpty())
               {
                  r.deleteNode();
               }
            }
            ((JDFResourceLink)v[i]).deleteNode();
         }
         return v.Count > 0;
      }

      ///   
      ///	 <summary> * Append a resource that matches the typesafe link described by resource name
      ///	 *  </summary>
      ///	 * <param name="resource"> the resource to link </param>
      ///	 * <param name="processUsage"> enum that defines if all links matching the name or only those matching the name usage and/or
      ///	 *            processusage are requested </param>
      ///	 * <param name="partMap"> the Attribute map of parts </param>
      ///	 * <returns> the new link, null if failure
      ///	 * 
      ///	 * @default linkMatchingResource(resource, processUsage, null) </returns>
      ///	 
      public virtual JDFResourceLink linkMatchingResource(JDFResource resource, EnumProcessUsage processUsage, JDFAttributeMap partMap)
      {
         JDFResourceLink rl = null;

         string resName = resource.LocalName;
         VString vtyp = getMatchType(resName, processUsage);

         if (vtyp != null)
         {
            VString.Enumerator vtypIterator = vtyp.GetEnumerator();
            while (vtypIterator.MoveNext())
            {
               string typ = vtypIterator.Current;
               if ((typ[1] == '?') || (typ[1] == '_'))
               {
                  if (numMatchingLinks(resName, false, processUsage) > 0)
                  {
                     continue; // not this one...
                  }
               }

               rl = linkResource(resource, typ[0] == 'i' ? EnumUsage.Input : EnumUsage.Output, null);
               if (typ.Length > 2)
               {
                  rl.setProcessUsage(EnumProcessUsage.getEnum(typ.Substring(2)));
               }

               rl.setPartMap(partMap);

               return rl;
            }
         }

         // should only get here it the link alreay exists
         throw new JDFException("JDFNode.LinkMatchingResource already exists");
      }

      ///   
      ///	 <summary> * get the number of links that match the typesafe link resource name
      ///	 *  </summary>
      ///	 * <param name="resName"> name of the resources to match </param>
      ///	 * <param name="bLink"> if false: returns the linked resources, if true: returns the ResourceLink elements </param>
      ///	 * <param name="processUsage"> enum that defines if all links matching the name or only those matching the name usage and/or
      ///	 *            processusage are requested </param>
      ///	 * <returns> int - the number of resourcelink elements
      ///	 * 
      ///	 * @default numMatchingLinks(resName, true, ProcessUsage_Any.getValue()) </returns>
      ///	 
      public virtual int numMatchingLinks(string resName, bool bLink, EnumProcessUsage processUsage)
      {
         int iNumMatchingLinks = 0;
         VElement v = getMatchingLinks(resName, bLink, processUsage);
         if (v != null)
         {
            iNumMatchingLinks = v.Count;
         }
         return iNumMatchingLinks;
      }

      //   
      //	 * // Element getter / setter
      //	 

      public virtual JDFAncestorPool getCreateAncestorPool()
      {
         return (JDFAncestorPool)getCreateElement_KElement(ElementName.ANCESTORPOOL, null, 0);
      }

      public virtual JDFAncestorPool appendAncestorPool()
      {
         return (JDFAncestorPool)appendElementN(ElementName.ANCESTORPOOL, 1, null);
      }

      public virtual JDFAncestorPool getAncestorPool()
      {
         return (JDFAncestorPool)getElement(ElementName.ANCESTORPOOL, null, 0);
      }


      public virtual JDFAuditPool getCreateAuditPool()
      {
         return (JDFAuditPool)getCreateElement_KElement(ElementName.AUDITPOOL, null, 0);
      }

      public virtual JDFAuditPool appendAuditPool()
      {
         return (JDFAuditPool)appendElementN(ElementName.AUDITPOOL, 1, null);
      }

      public virtual JDFAuditPool getAuditPool()
      {
         return (JDFAuditPool)getElement(ElementName.AUDITPOOL, null, 0);
      }

      ///   
      ///	 <summary> * gets the existing CustomerInfo or creates a new one if none exists this method will check if a NodeInfo exists,
      ///	 *  </summary>
      ///	 * <returns> the found or created CustomerInfo. </returns>
      ///	 
      public virtual JDFCustomerInfo getCreateCustomerInfo()
      {
         return (JDFCustomerInfo)getCreateNiCi(ElementName.CUSTOMERINFO);
      }

      ///   
      ///	 <summary> * appends a CustomerInfo to this
      ///	 *  </summary>
      ///	 * <returns> the appended CustomerInfo </returns>
      ///	 
      public virtual JDFCustomerInfo appendCustomerInfo()
      {
         if (getCustomerInfo() != null)
         {
            throw new JDFException("JDFNode.appendCustomerInfo: CustomerInfo already exists");
         }
         return getCreateCustomerInfo();
      }

      ///   
      ///	 <summary> * gets the existing CustomerInfo
      ///	 *  </summary>
      ///	 * <returns> the existing CustomerInfo. </returns>
      ///	 
      public virtual JDFCustomerInfo getCustomerInfo()
      {
         return (JDFCustomerInfo)getNiCi(ElementName.CUSTOMERINFO, false, null);
      }

      ///   
      ///	 <summary> * gets the NodeIdetifier that matches this
      ///	 * 
      ///	 * @return </summary>
      ///	 
      public virtual NodeIdentifier getIdentifier()
      {
         return new NodeIdentifier(getJobID(true), getJobPartID(false), getNodeInfoPartMapVector());
      }

      ///   
      ///	 <summary> * gets the existing inherited CustomerInfo or NodeInfo from parents including ancestorpool
      ///	 *  </summary>
      ///	 * <param name="elementName"> name of the element to look for </param>
      ///	 * <param name="bInherit"> if true: recurse into parents </param>
      ///	 * <param name="xPath"> </param>
      ///	 * <returns> the existing CustomerInfo or NodeInfo </returns>
      ///	 
      private KElement getNiCi(string elementName, bool bInherit, string xPath)
      {
         // always get the element
         KElement nici = getElement(elementName);
         EnumVersion eVer = getVersion(true);

         // if version>=1.0 or no direct element is there try the resource
         if (eVer != null && eVer.getValue() >= EnumVersion.Version_1_3.getValue() || (nici == null))
         {
            JDFResourceLinkPool rlp = getResourceLinkPool();
            if (rlp != null)
            {
               VElement v = rlp.getPoolChildren(elementName + "Link", new JDFAttributeMap(AttributeName.USAGE, "Input"), null);
               if (v != null)
               {
                  int siz = v.Count;
                  VString types = getTypes();

                  for (int i = 0; i < siz; i++)
                  {
                     JDFResourceLink rl = (JDFResourceLink)v[i];
                     JDFIntegerList combinedProcessIndex = rl.getCombinedProcessIndex();
                     if (combinedProcessIndex == null || (types != null && combinedProcessIndex.Count == types.Count))
                     {
                        // in case of multiple parts - grab root - else
                        // potential performance hit
                        nici = rl.getPart(1) == null ? rl.getTarget() : rl.getLinkRoot();
                        break;
                     }
                  }
               }
            }
         }

         KElement nici2 = nici;

         // continue search if not found but retain nici
         while (nici2 != null && (xPath != null) && (!nici2.hasXPathNode(xPath)))
         {
            if ((nici2 is JDFResource) && !((JDFResource)nici2).isResourceRoot())
               nici2 = nici2.getParentNode_KElement();
            else
               nici = nici2 = null;
         }

         if (nici != null || !bInherit)
         {
            return nici;
         }

         JDFNode parent = getParentJDF();
         if (parent != null)
         {
            return parent.getNiCi(elementName, bInherit, xPath);
         }
         JDFAncestorPool ap = getAncestorPool();
         if (ap != null)
         {
            return ap.getAncestorElement(elementName, null, xPath);
         }
         return null;
      }


      ///   
      ///	 <summary> * gets the existing NodeInfo or creates a new one if none exists this method will check if a NodeInfo exists,
      ///	 *  </summary>
      ///	 * <returns> the found or created nodeinfo. </returns>
      ///	 
      public virtual JDFNodeInfo getCreateNodeInfo()
      {
         return (JDFNodeInfo)getCreateNiCi(ElementName.NODEINFO);
      }

      ///   
      ///	 <summary> * gets the existing NodeInfo or creates a new one if none exists this method will check if a NodeInfo/CustomerInfo
      ///	 * exists,
      ///	 *  </summary>
      ///	 * <returns> the found or created NodeInfo/CustomerInfo </returns>
      ///	 
      private KElement getCreateNiCi(string s)
      {
         // check if this already has a Nodeinfo/CustomerInfo
         KElement nici = getNiCi(s, false, null);
         if (nici == null)
         {
            EnumVersion eVer = getVersion(true);
            if (eVer != null && eVer.getValue() >= EnumVersion.Version_1_3.getValue())
            {
               nici = addResource(s, null, EnumUsage.Input, null, this, null, null);
            }
            else
            {
               nici = appendElement(s);
            }
         }
         return nici;
      }

      ///   
      ///	 <summary> * appends a NodeInfo to this
      ///	 *  </summary>
      ///	 * <returns> the appended NodeInfo </returns>
      ///	 
      public virtual JDFNodeInfo appendNodeInfo()
      {
         if (getNodeInfo() != null)
         {
            throw new JDFException("JDFNodeInfo.appendNodeInfo: NodeInfo already exists");
         }
         return getCreateNodeInfo();
      }

      ///   
      ///	 <summary> * appends a NodeInfo for a given combinedprocessindex to this
      ///	 *  </summary>
      ///	 * <param name="combinedProcessIndex"> the combinedprocessindex that must be explicitly specified in the link </param>
      ///	 * <returns> the appended NodeInfo </returns>
      ///	 * <exception cref="JDFException"> if combinedProcessIndex is outside the legal range implied by @Types </exception>
      ///	 
      public virtual JDFNodeInfo appendNodeInfo(int combinedProcessIndex)
      {
         if (combinedProcessIndex < 0 || combinedProcessIndex >= getTypes().Count)
            throw new JDFException("appendNodeInfo: appending ni for non existing ccombinedProcessIndex:" + combinedProcessIndex + " types=" + getTypes());
         if (getNodeInfo(combinedProcessIndex) != null)
         {
            throw new JDFException("JDFNodeInfo.appendNodeInfo: NodeInfo already exists");
         }
         JDFNodeInfo ni = (JDFNodeInfo)addResource(ElementName.NODEINFO, EnumUsage.Input);
         JDFResourceLink rl = getLink(ni, null);
         rl.setCombinedProcessIndex(new JDFIntegerList(combinedProcessIndex));
         return ni;
      }

      ///   
      ///	 <summary> * gets the existing local NodeInfo if it is a resource or an element
      ///	 *  </summary>
      ///	 * <param name="combinedProcessIndex"> the combinedprocessindex that must be explicitly specified in the link </param>
      ///	 * <returns> the existing NodeInfo. </returns>
      ///	 
      public virtual JDFNodeInfo getNodeInfo(int combinedProcessIndex)
      {
         if (combinedProcessIndex < 0 || combinedProcessIndex >= getTypes().Count)
            return null;
         JDFResourceLinkPool rlp = getResourceLinkPool();
         if (rlp == null)
            return null;
         JDFResourceLink rl = (JDFResourceLink)rlp.getChildWithMatchingAttribute("NodeInfoLink", AttributeName.COMBINEDPROCESSINDEX, null, Convert.ToString(combinedProcessIndex), 0, true, AttributeInfo.EnumAttributeType.IntegerList);
         if (rl == null)
            return null;

         return (JDFNodeInfo)rl.getTarget();
      }

      ///   
      ///	 <summary> * gets the existing local NodeInfo if it is a resource or an element
      ///	 *  </summary>
      ///	 * <returns> the existing NodeInfo. </returns>
      ///	 
      public virtual JDFNodeInfo getNodeInfo()
      {
         return (JDFNodeInfo)getNiCi(ElementName.NODEINFO, false, null);
      }


      ///   
      ///	 <summary> * get first NodeInfo element from child list or child list of any ancestor
      ///	 *  </summary>
      ///	 * <param name="xPath"> the xPath to an element or attribute that must exist in the queried CustomerInfo<br>
      ///	 *            note that attributes must be marked with an "@", if xPath=null, simply return the next in line
      ///	 *  </param>
      ///	 * <returns> JDFNodeInfo The matching NodeInfo element </returns>
      ///	 
      public virtual JDFNodeInfo getInheritedNodeInfo(string xPath)
      {
         return (JDFNodeInfo)getNiCi(ElementName.NODEINFO, true, xPath);
      }

      ///   
      ///	 <summary> * get first NodeInfo element from child list or child list of any ancestor
      ///	 *  </summary>
      ///	 * <returns> JDFNodeInfo - the element </returns>
      ///	 * @deprecated 060221 use getInheritedNodeInfo(String xPath) 
      ///	 
      [Obsolete("060221 use getInheritedNodeInfo(String xPath)")]
      public virtual JDFNodeInfo getInheritedNodeInfo()
      {
         return getInheritedNodeInfo(null);
      }

      ///   
      ///	 <summary> * remove element NodeInfo
      ///	 * 
      ///	 * with ProcessUsage="Ancestor" is infinity. Use removeNodeInfos() to remove all. </summary>
      ///	 
      public virtual void removeNodeInfo()
      {
         removeNiCi(ElementName.NODEINFO);
      }

      ///   
      ///	 <summary> * remove element Customerinfo whether it is an element or a resource </summary>
      ///	 
      public virtual void removeCustomerInfo()
      {
         removeNiCi(ElementName.CUSTOMERINFO);
      }

      ///   
      ///	 <summary> * remove element NodeInfo or CustomerInfo, no matter whether it is an element or a resource
      ///	 *  </summary>
      ///	 * <param name="elmName"> name of the element to remove </param>
      ///	 
      private void removeNiCi(string elmName)
      {
         // just in case : zapp them both
         removeResource(elmName, 0);
         removeChild(elmName, null, 0);
      }

      ///   
      ///	 <summary> * removes all NodeInfo elements
      ///	 *  </summary>
      ///	 * @deprecated removes only 1 NodeInfo. In Version 1.3 the cardinality of NodeInfo 
      ///	 
      [Obsolete("removes only 1 NodeInfo. In Version 1.3 the cardinality of NodeInfo")]
      public virtual void removeNodeInfos()
      {
         while (numNodeInfos() > 0)
         {
            KElement remRes = removeResource(ElementName.NODEINFO, 0);
            if (remRes == null)
            {
               // removed all in the resource pool
               break;
            }
         }

         // remove all direct childs
         VElement nodeInfoChilds = getChildElementVector(ElementName.NODEINFO, null, null, false, int.MaxValue, false);
         for (int i = 0; i < nodeInfoChilds.Count; i++)
         {
            removeChild((XmlNode)nodeInfoChilds[i]);
         }
      }

      ///   
      ///	 <summary> * removes all CustomerInfo elements whether it is an element or a resource
      ///	 *  </summary>
      ///	 * @deprecated 060220 use removeCustomerInfo 
      ///	 
      [Obsolete("060220 use removeCustomerInfo")]
      public virtual void removeCustomerInfos()
      {
         // TODO hasCustomerInfo returns true if there is one or more
         // customerinfo ANYWHERE
         // so the while loop will end in an infinite loop (the break prohibit
         // this but thats not
         // realy nice (same for removeNodeInfos)!
         while (hasCustomerInfo())
         {
            KElement remRes = removeResource(ElementName.CUSTOMERINFO, 0);
            if (remRes == null)
            {
               // remove all in the resource pool
               break;
            }
         }

         // remove all direct childs
         VElement nodeInfoChilds = getChildElementVector(ElementName.CUSTOMERINFO, null, null, false, int.MaxValue, false);
         for (int i = 0; i < nodeInfoChilds.Count; i++)
         {
            removeChild((XmlNode)nodeInfoChilds[i]);
         }
      }

      ///   
      ///	 <summary> * removes all unlinked resources </summary>
      ///	 
      public virtual void eraseUnlinkedResources()
      {
         // VElement v=getUnlinkedResources(false);
         // while(v!=null)
         // {
         // for(int i=0;i<v.Count;i++)
         // {
         // ((JDFResource)v[i]).deleteNode();
         // }
         // v=getUnlinkedResources(false); // repeat until no unlinked are found
         // }
         UnLinkFinder uf = new UnLinkFinder();
         uf.eraseUnlinkedResources(this);
      }

      ///   
      ///	 <summary> * removes a Resource from this ResourceLinkPool and from the resourcePool if it is no longer linked to any other
      ///	 * process
      ///	 *  </summary>
      ///	 * <param name="nodeName"> the Nodename of the Resource "NodeInfo" for example </param>
      ///	 * <param name="iSkip"> number to skip before deleting </param>
      ///	 * <returns> KElement the removed resource, null if nothing was found or deleted (e.g. 4 found and the 5th is the one
      ///	 *         to delete). The link is not returned<br>
      ///	 *         If the link is deleted and the resource is still linked to another process, null is returned. </returns>
      ///	 
      public virtual JDFResource removeResource(string nodeName, int iSkip)
      {
         JDFResource kRet = null;

         JDFResourceLinkPool rlp = getResourceLinkPool();
         if (rlp != null)
         {
            string linkName = nodeName + "Link";

            JDFResourceLink rl = (JDFResourceLink)rlp.getChildByTagName(linkName, null, iSkip, null, true, false);
            if (rl != null)
            {
               kRet = rl.getTarget();
               rlp.removeChild(rl);
               if (!kRet.deleteUnLinked())
               {
                  kRet = null;
               }
            }
         }
         return kRet;
      }

      ///   
      ///	 <summary> * Number of NodeInfo elements
      ///	 *  </summary>
      ///	 * <returns> int number of matching elements </returns>
      ///	 * @deprecated must never be more than one... 
      ///	 
      [Obsolete("must never be more than one...")]
      public virtual int numNodeInfos()
      {
         int i = numChildElements(ElementName.NODEINFO, null);

         JDFResourceLinkPool rlp = getResourceLinkPool();
         if (rlp != null)
         {
            VElement poolChildren = rlp.getPoolChildren("NodeInfoLink", null, null);
            if (poolChildren != null)
            {
               i += poolChildren.Count;
            }
         }

         return i;
      }

      ///   
      ///	 <summary> * Number of NodeInfo elements
      ///	 *  </summary>
      ///	 * <returns> int - number of matching elements </returns>
      ///	 * @deprecated must never be more than one... 
      ///	 
      [Obsolete("must never be more than one...")]
      public virtual int numCustomerInfos()
      {
         int i = numChildElements(ElementName.CUSTOMERINFO, null);

         JDFResourceLinkPool rlp = getResourceLinkPool();
         if (rlp != null)
         {
            VElement poolChildren = rlp.getPoolChildren("CustomerInfoLink", null, null);
            if (poolChildren != null)
            {
               i += poolChildren.Count;
            }
         }

         return i;
      }

      ///   
      ///	 <summary> * test whether either an element NodeInfo or a JDF 1.3 NodeInfo Resource exists
      ///	 *  </summary>
      ///	 * <returns> true if at least one matching element exists </returns>
      ///	 * @deprecated use getNodeInfo()!=null 
      ///	 
      [Obsolete("use getNodeInfo()!=null")]
      public virtual bool hasNodeInfo()
      {
         return getNodeInfo() != null;
      }

      ///   
      ///	 <summary> * test whether either an element CustomerInfo or a JDF 1.3 CustomerInfo Resource exists
      ///	 *  </summary>
      ///	 * <returns> bool true if at least one matching element exists </returns>
      ///	 * @deprecated use getCustomerInfo()!=null 
      ///	 
      [Obsolete("use getCustomerInfo()!=null")]
      public virtual bool hasCustomerInfo()
      {
         return getCustomerInfo() != null;
      }


      ///   
      ///	 <summary> * Get element ResourceLinkPool, create if it doesn't exist
      ///	 *  </summary>
      ///	 * <returns> the found/created element </returns>
      ///	 
      public virtual JDFResourceLinkPool getCreateResourceLinkPool()
      {
         return (JDFResourceLinkPool)getCreateElement_KElement(ElementName.RESOURCELINKPOOL, null, 0);
      }

      ///   
      ///	 <summary> * Append a ResourceLinkPool element, return existing element if one already exist
      ///	 *  </summary>
      ///	 * <returns> the ResourceLinkPool element </returns>
      ///	 
      public virtual JDFResourceLinkPool appendResourceLinkPool()
      {
         return (JDFResourceLinkPool)appendElementN(ElementName.RESOURCELINKPOOL, 1, null);
      }

      ///   
      ///	 <summary> * get the first ResourceLinkPool element
      ///	 *  </summary>
      ///	 * <returns> the element </returns>
      ///	 
      public virtual JDFResourceLinkPool getResourceLinkPool()
      {
         return (JDFResourceLinkPool)getElement(ElementName.RESOURCELINKPOOL, null, 0);
      }


      ///   
      ///	 <summary> * Get element ResourcePool, create if it doesn't exist
      ///	 *  </summary>
      ///	 * <returns> the found/created element </returns>
      ///	 
      public virtual JDFResourcePool getCreateResourcePool()
      {
         return (JDFResourcePool)getCreateElement_KElement(ElementName.RESOURCEPOOL, null, 0);
      }

      ///   
      ///	 <summary> * append a ResourcePool element, return existing element if one already exist
      ///	 *  </summary>
      ///	 * <returns> the ResourcePool element </returns>
      ///	 
      public virtual JDFResourcePool appendResourcePool()
      {
         return (JDFResourcePool)appendElementN(ElementName.RESOURCEPOOL, 1, null);
      }

      ///   
      ///	 <summary> * get the first ResourcePool element
      ///	 *  </summary>
      ///	 * <returns> the element </returns>
      ///	 
      public virtual JDFResourcePool getResourcePool()
      {
         return (JDFResourcePool)getElement(ElementName.RESOURCEPOOL, null, 0);
      }


      ///   
      ///	 <summary> * Get element StatusPool, create if it doesn't exist
      ///	 *  </summary>
      ///	 * <returns> the found/created element </returns>
      ///	 
      public virtual JDFStatusPool getCreateStatusPool()
      {
         setStatus(JDFElement.EnumNodeStatus.Pool);
         return (JDFStatusPool)getCreateElement_KElement(ElementName.STATUSPOOL, null, 0);
      }

      ///   
      ///	 <summary> * append a StatusPool element, return existing element if one already exist
      ///	 *  </summary>
      ///	 * <returns> the StatusPool element </returns>
      ///	 
      public virtual JDFStatusPool appendStatusPool()
      {
         setStatus(JDFElement.EnumNodeStatus.Pool);
         return (JDFStatusPool)appendElementN(ElementName.STATUSPOOL, 1, null);
      }

      ///   
      ///	 <summary> * get the first StatusPool element
      ///	 *  </summary>
      ///	 * <returns> the element </returns>
      ///	 
      public virtual JDFStatusPool getStatusPool()
      {
         return (JDFStatusPool)getElement(ElementName.STATUSPOOL, null, 0);
      }

      ///   
      ///	 <summary> * get a Child JDFNode with a given ID attribute
      ///	 *  </summary>
      ///	 * <param name="id"> the id of the child </param>
      ///	 * <param name="bDirect"> if true, only direct children, else recurse down the tree
      ///	 *  </param>
      ///	 * <returns> JDFNode - the parent JDF, null if this is the root JDF
      ///	 * 
      ///	 * @default getChildJDFNode(id, false) </returns>
      ///	 
      public virtual JDFNode getChildJDFNode(string id, bool bDirect)
      {
         JDFAttributeMap m = new JDFAttributeMap(AttributeName.ID, id);
         return (JDFNode)getTreeElement(ElementName.JDF, null, m, bDirect, true);
      }

      ///   
      ///	 <summary> * Check existence of attribute "version"
      ///	 *  </summary>
      ///	 * <param name="bInherit"> recurse through ancestors and Ancestor elements of the AncestorPool when searching </param>
      ///	 * <returns> true if attribute Version exists
      ///	 * 
      ///	 * @default hasVersion(false) </returns>
      ///	 
      public virtual bool hasVersion(bool bInherit)
      {
         if (bInherit)
         {
            return hasAncestorAttribute(AttributeName.VERSION, null);
         }
         return hasAttribute(AttributeName.VERSION, null, false);
      }

      ///   
      ///	 <summary> * set attribute "version"
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 * @deprecated use JDFElement.setVersion(EnumVersion.getEnum(value)) 
      ///	 
      [Obsolete("use JDFElement.setVersion(EnumVersion.getEnum(value))")]
      public virtual void setVersion(string @value)
      {
         setAttribute(AttributeName.VERSION, @value, null);
      }

      ///   
      ///	 <summary> * get enum attribute "version"
      ///	 *  </summary>
      ///	 * <param name="bInherit"> recurse through ancestors when searching </param>
      ///	 * <returns> EnumVersion - attribute value
      ///	 * 
      ///	 * @default getVersion(false)
      ///	 * 
      ///	 *          this method replaces the C++ methods GetVersion and GetEnumVersion </returns>
      ///	 
      public override EnumVersion getVersion(bool bInherit)
      {
         string version;
         if (bInherit)
         {
            version = getAncestorAttribute(AttributeName.VERSION, null, null);
         }
         else
         {
            version = getAttribute(AttributeName.VERSION, null, null);
         }

         return EnumVersion.getEnum(version);
      }

      ///   
      ///	 <summary> * clone the target resource of this and generate a ResourceAudit in the parent node's AuditPool. Both resourcelinks
      ///	 * of the ResourceAudit are filled in.<br>
      ///	 * The resource selected by this may now be modified. <br>
      ///	 * The cloned copy has a new Id in the format: (thisID)_old_nnn
      ///	 *  </summary>
      ///	 * <returns> the ResourceAudit that was created </returns>
      ///	 
      public virtual JDFResourceAudit cloneResourceToModify(JDFResourceLink resLink)
      {
         JDFResourceAudit resourceAudit = null;

         JDFResource r = resLink.getLinkRoot();
         if (r == null)
            return null;
         JDFResourcePool pool = r.getParentJDF().getResourcePool();
         JDFResource oldCopy = (JDFResource)pool.copyElement(r, null);

         if (oldCopy != null)
         {
            oldCopy.setLocked(true);
            string newID = r.newModifiedID();
            oldCopy.setID(newID);
            resourceAudit = prepareToModifyLink(resLink);
            JDFResourceLink resLinkAudit = (JDFResourceLink)resourceAudit.copyElement(resLink, null);

            if (resLinkAudit != null)
            {
               resLinkAudit.setrRef(newID);
            }
         }

         return resourceAudit;
      }


      ///   
      ///	 <summary> * Generate a ResourceAudit in the parent node's AuditPool an initial copy of the not yet modified resourcelink is
      ///	 * inserted<br>
      ///	 * call JDFResourceAudit.UpdateLink with the modified link to finalize
      ///	 *  </summary>
      ///	 * <returns> the ResourceAudit that was created </returns>
      ///	 
      public virtual JDFResourceAudit prepareToModifyLink(JDFResourceLink resLink)
      {

         JDFAuditPool ap = getCreateAuditPool();
         JDFResourceAudit resourceAudit = ap.addResourceAudit(null);
         if (resourceAudit != null)
         {
            resourceAudit.setContentsModified(false);
            resourceAudit.updateLink(resLink);
         }
         return resourceAudit;
      }

      ///   
      ///	 <summary> * get the Types as a vector of strings
      ///	 *  </summary>
      ///	 * <returns> vector of Strings in Types, null if this may not contain multiple types </returns>
      ///	 
      public virtual VString getTypes()
      {
         if (!isTypesNode())
            return null;
         string types = getAttribute(AttributeName.TYPES, null, null);
         return types == null ? null : new VString(types, null);
      }

      ///   
      ///	 <summary> * get the Types as a vector of EnumType
      ///	 *  </summary>
      ///	 * <returns> vector of enumerated types, null if extensions exist that hinder us from generating a complete vector<br>
      ///	 *         e.g. extension types or gray box names </returns>
      ///	 
      public virtual List<EnumType> getEnumTypes()
      {
         List<EnumType> vs = null;
         VString types = getTypes();
         if (types != null)
         {
            VString.Enumerator typesIterator = types.GetEnumerator();
            while (typesIterator.MoveNext())
            {
               EnumType typ = EnumType.getEnum(typesIterator.Current);
               if (typ == null)
               {
                  return null;
               }
               if (vs == null)
               {
                  vs = new List<EnumType>();
               }
               vs.Add(typ);
            }
         }
         return vs;
      }

      ///   
      ///	 <summary> * get the first index of a process in types after start
      ///	 *  </summary>
      ///	 * <param name="typ"> the Type to search for </param>
      ///	 * <param name="start"> the position to start searching at - generally 0 </param>
      ///	 * <returns> int the position of the first occurence after start,-1 if none is found </returns>
      ///	 
      public virtual int getCombinedProcessIndex(EnumType typ, int start)
      {
         if (typ == null)
            return -1;
         return getCombinedProcessIndex(typ.getName(), start);
      }

      ///   
      ///	 <summary> * get the first index of a process in types after start
      ///	 *  </summary>
      ///	 * <param name="typ"> the Type to search for </param>
      ///	 * <param name="start"> the position to start searching at - generally 0 </param>
      ///	 * <returns> int the position of the first occurence after start,-1 if none is found </returns>
      ///	 
      public virtual int getCombinedProcessIndex(string typ, int start)
      {
         VString types = getTypes();
         if (types == null)
            return -1;
         return types.IndexOf(typ, start);
      }

      ///   
      ///	 <summary> * add typ to the types list if this is a combined node or gray box
      ///	 *  </summary>
      ///	 * <param name="typ"> </param>
      ///	 
      public virtual void addTypes(EnumType typ)
      {
         if (!isTypesNode() || typ == null)
            return;
         appendAttribute(AttributeName.TYPES, typ.getName(), null, " ", false);
      }

      ///   
      ///	 <summary> * Gets the vector of the string Type/Types attribute values of the given JDFNode by recursively traversing the tree<br>
      ///	 * returns exactly one element="Product" if the tested node's type is product
      ///	 *  </summary>
      ///	 * <returns> VString - vector of Type/Types attributes of the tested ProcessGroup JDFNode </returns>
      ///	 * <exception cref="JDFException"> if the tested JDFNode has an illegal combination of attribute 'Types' and child JDFNodes </exception>
      ///	 
      public virtual VString getAllTypes()
      {
         VString vs = null;
         string myType = getType();
         if (myType.Equals(JDFConstants.PRODUCT))
         {
            vs = new VString(JDFConstants.PRODUCT, null);
         }
         else if (myType.Equals(JDFConstants.COMBINED))
         {
            vs = getTypes();
         }
         else if (myType.Equals(JDFConstants.PROCESSGROUP))
         {
            VElement vNodes = getvJDFNode(null, null, true);
            VString vsTypes = getTypes();
            int nodeSize = vNodes.Count;
            for (int i = 0; i < nodeSize; i++)
            {
               JDFNode node = (JDFNode)vNodes[i];
               VString allTypes = node.getAllTypes();
               if (allTypes != null)
               {
                  if (vs == null)
                  {
                     vs = allTypes;
                  }
                  else
                  {
                     vs.addAll(allTypes);
                  }
               }
            }
            if (vsTypes != null) // grey box or simple type
            {
               if (vs != null)
               {
                  vs.addAll(vsTypes);
               }
               else
               {
                  vs = vsTypes; // __Lena__ May contain GrayBoxes
               }
            }

         }
         else
         {
            string type = myType;
            vs = new VString(type, null);
         }
         return vs;
      }

      // new since Ver 2.0
      //   
      //	 * Attribute Types must be defined in Combined Nodes (Type="Combined") and may be defined in ProcessGroup Nodes
      //	 * (Type="ProcessGroup")
      //	 
      ///   
      ///	 <summary> * set node Types , also set Type to Combined
      ///	 *  </summary>
      ///	 * <param name="vCombiNodes"> vector of types </param>
      ///	 
      public virtual void setTypes(VString vCombiNodes)
      {
         EnumType type = EnumType.getEnum(getType());
         // 080408 lets be gracefull in case we are building sequentially
         if (type == null || EnumType.Combined.Equals(type) || EnumType.ProcessGroup.Equals(type))
         {
            setAttribute(AttributeName.TYPES, vCombiNodes, null);
         }
         else
         {
            throw new JDFException("Setting Types on illegal node Type:" + getType());
         }
      }

      ///   
      ///	 <summary> * get the links that are selected by a given CombinedProcessIndex<br>
      ///	 * all links with no CombinedProcessIndex are included in the list
      ///	 *  </summary>
      ///	 * <param name="combinedProcessIndex"> the nTh occurence of the CombinedProcessIndex field, -1 if all valid positions are ok
      ///	 * 
      ///	 * @default getLinksForCombinedProcessIndex(-1) </param>
      ///	 
      public virtual VElement getLinksForCombinedProcessIndex(int combinedProcessIndex)
      {
         EnumType typ = getEnumType();
         if (!EnumType.Combined.Equals(typ) && !EnumType.ProcessGroup.Equals(typ))
         {
            return null;
         }

         VElement vLinks = getResourceLinks(null, null, null);
         if (vLinks == null)
         {
            return null;
         }

         string indexString = StringUtil.formatInteger(combinedProcessIndex);
         // loop over all links
         for (int i = vLinks.Count - 1; i >= 0; i--)
         {
            JDFResourceLink rl = (JDFResourceLink)vLinks[i];
            if (rl.hasAttribute(AttributeName.COMBINEDPROCESSINDEX) && !rl.includesMatchingAttribute(AttributeName.COMBINEDPROCESSINDEX, indexString, AttributeInfo.EnumAttributeType.IntegerList))
            {
               vLinks.RemoveAt(i);
            }
         }
         return vLinks;
      }

      ///   
      ///	 <summary> * get the links that are selected by a given CombinedProcessIndex<br>
      ///	 * all links with no CombinedProcessIndex are included in the list
      ///	 *  </summary>
      ///	 * <param name="type"> the process type for which to get the links </param>
      ///	 * <param name="nType"> the nTh occurence of the Type field, -1 if all valid positions are ok
      ///	 * 
      ///	 * @default getLinksForType(type, -1) </param>
      ///	 
      public virtual VElement getLinksForType(EnumType type, int nType)
      {
         EnumType typ = getEnumType();
         if (typ == null)
         {
            return null;
         }
         // not combined, simpy get links from entire node
         if (typ.Equals(type))
         {
            return getResourceLinks(null, null, null);
         }

         // nasty - mismatching type attribute
         if (!typ.Equals(EnumType.Combined) && !typ.Equals(EnumType.ProcessGroup))
         {
            return null;
         }

         // no types - this is a corrupt node
         List<EnumType> vTypes = getEnumTypes();
         if (vTypes == null)
         {
            return null;
         }
         int typSize = vTypes.Count;

         // no links here at all
         VElement vLinks = getResourceLinks(null, null, null);
         if (vLinks == null)
         {
            return null;
         }

         // loop over all links and remove non-matching entries
         for (int i = vLinks.Count - 1; i >= 0; i--)
         {
            JDFResourceLink rl = (JDFResourceLink)vLinks[i];
            JDFIntegerList cpi = rl.getCombinedProcessIndex();
            if (cpi != null) // there is a cpi, check if it matches
            {
               int size = cpi.Count;
               bool bFound = false;
               // loop over indeces of CombinedProcessIndex
               for (int j = 0; j < size; j++)
               {
                  int index = cpi.getInt(j);
                  if (index < typSize) // the index points to a vaild position
                  // in the list
                  {
                     EnumType cpiType = vTypes[index];
                     if (cpiType.Equals(type))
                     {
                        if (nType < 0) // flag not to check which ocurrence
                        {
                           bFound = true;
                        }
                        else
                        {
                           int nFound = -1;
                           for (int k = 0; k <= index; k++) // count
                           // occurences
                           // of this
                           // process
                           // type in
                           // front of
                           // and
                           // including
                           // this
                           {
                              EnumType cpiTypeCount = vTypes[k];
                              if (cpiTypeCount.Equals(type))
                              {
                                 nFound++;
                              }
                           }
                           bFound = nFound == nType;
                           if (bFound)
                           {
                              break;
                           }
                        }
                     }
                  }
               }
               // found non matching cpi - remove link
               if (!bFound)
               {
                  vLinks.RemoveAt(i);
               }
            }
         }

         return vLinks;
      }

      ///   
      ///	 <summary> * get the enumerated type value of @Type
      ///	 *  </summary>
      ///	 * <returns> the enumerated type </returns>
      ///	 
      public virtual EnumType getEnumType()
      {
         return EnumType.getEnum(getType());
      }

      ///   
      ///	 <summary> * insert a new Process into @Types at the position pos
      ///	 *  </summary>
      ///	 * <param name="type"> the process type </param>
      ///	 * <param name="beforePos"> the position before which to add the in the list, 0 is first, ... -1 is before the last, very
      ///	 *            large is append </param>
      ///	 
      public virtual void insertTypeInTypes(EnumType type, int beforePos)
      {
         int beforePosLocal = beforePos;

         VString types = getTypes();
         if (types == null)
         {
            types = new VString();
         }

         int typeSize = types.Count;
         if (beforePosLocal < 0)
         {
            beforePosLocal = typeSize + beforePosLocal;
         }

         if (beforePosLocal < 0)
         {
            beforePosLocal = 0;
         }

         if (beforePosLocal <= typeSize) // insert somehwere within the list
         {
            VElement vResLinks = getResourceLinks(null, new JDFAttributeMap(AttributeName.COMBINEDPROCESSINDEX, ""), null);
            if (vResLinks != null)
            {
               for (int i = 0; i < vResLinks.Count; i++)
               {
                  JDFResourceLink rl = (JDFResourceLink)vResLinks[i];
                  int[] cpi = rl.getCombinedProcessIndex().getIntArray();
                  for (int j = 0; j < cpi.Length; j++)
                  {
                     if (cpi[j] >= beforePosLocal)
                     {
                        cpi[j]++;
                     }
                  }

                  rl.setCombinedProcessIndex(new JDFIntegerList(cpi));
               }
            }

            types.Insert(beforePosLocal, type.getName());
         }
         else
         // append at end
         {
            types.Add(type.getName());
         }

         setTypes(types);
      }

      ///   
      ///	 <summary> * Get an ordered list of the ids of the parents of this node<br>
      ///	 * the last element in the pool is the direct parent, the second to last is the grandparent etc. The first element
      ///	 * is the original root element.
      ///	 *  </summary>
      ///	 * <returns> the list of ids in the order parent, grandparent... </returns>
      ///	 
      public virtual VString getParentIds()
      {
         VString vs = new VString();
         if (getAncestorPool() != null)
         {
            VElement v = getAncestorPool().getPoolChildren(null);

            for (int i = 0; i < v.Count; i++)
            {
               vs.Add(((JDFAncestor)v[i]).getNodeID());
            }
         }
         return vs;
      }

      ///   
      ///	 <summary> * merge a previously spawned JDF into a node that is a child of, or this root
      ///	 *  </summary>
      ///	 * <param name="toMerge"> the previosly spawned jdf node </param>
      ///	 * <param name="urlMerge"> the url of the ??? </param>
      ///	 * <param name="cleanPolicy"> how to clean up the spawn and merge audits after merging </param>
      ///	 * <param name="amountPolicy"> how to clean up the Resource amounts after merging </param>
      ///	 * <returns> JDFNode - the merged node in the new document<br>
      ///	 *         note that the return value used to be boolean. The boolean value is now replaced by exceptions. This
      ///	 *         always corresponds to <code>true</code>.
      ///	 *  </returns>
      ///	 * <exception cref="JDFException"> if toMerge has already been merged </exception>
      ///	 * <exception cref="JDFException"> if toMerge was not spawned from this </exception>
      ///	 * <exception cref="JDFException"> if toMerge has no AncestorPool
      ///	 * 
      ///	 * @default mergeJDF(toMerge, null, JDFNode.EnumCleanUpMerge.None, JDFResource.EnumAmountMerge.None) </exception>
      ///	 * @deprecated use JDFMerge class 
      ///	 
      [Obsolete("use JDFMerge class")]
      public virtual JDFNode mergeJDF(JDFNode toMerge, string urlMerge, EnumCleanUpMerge cleanPolicy, JDFResource.EnumAmountMerge amountPolicy)
      {
         return new JDFMerge(this).mergeJDF(toMerge, urlMerge, cleanPolicy, amountPolicy);
      }


      ///   
      ///	 <summary> * check whether a node with the same ID as one in p's ancestorpool exists in this document
      ///	 *  </summary>
      ///	 * <param name="p"> the node to check </param>
      ///	 * <returns> true if a node with the same ID as one in p's ancestorpool exists </returns>
      ///	 
      public virtual bool hasParent(JDFNode p)
      {
         VString vpa = p.getAncestorIDs();
         VString vParents = getParentIds();
         vParents.Add(getID());

         if (vpa.Count == 0)
         {
            return false;
         }
         string id = vpa[0];
         if (id.Equals(JDFConstants.EMPTYSTRING))
         {
            throw new JDFException("JDFNode.HasParent: no id???");
         }
         for (int i = 0; i < vParents.Count; i++)
         {
            if (id.Equals(vParents[i]))
            {
               return true;
            }
         }
         return false;
      }


      ///   
      ///	 <summary> * loop over all IDs and find the min ID that will create unique new IDs
      ///	 *  </summary>
      ///	 * <returns> the new minimum ID that will generate unique IDs </returns>
      ///	 
      public virtual int getMinID()
      {
         VElement v = getChildrenByTagName(null, null, null, false, true, 0);
         v.Add(this);

         int iMax = 0;
         VString vIDNames = new VString("ID SpawnID MergeID NewSpawnID", null);
         int idSize = vIDNames.Count;

         int size = v.Count;
         for (int i = 0; i < size; i++)
         {
            KElement jdfElem = v.item(i);

            for (int j = 0; j < idSize; j++)
            {
               // 4 = size of the atr vector
               // get the rightmost last 4 numerical characters as seed for
               // UniqueID()

               string strID = jdfElem.getAttribute(vIDNames.stringAt(j), null, null);
               if (strID != null)
               {
                  if (strID.Length > 7)
                  {
                     strID = strID.Substring(strID.Length - 7); // only use
                     // the
                     // last
                     // 5
                     // chars
                  }

                  int pos = StringUtil.find_last_not_of(strID, "0123456789");

                  if (pos == -1)
                  {
                     continue;
                  }

                  strID = strID.Substring(pos + 1);
                  strID = strID.Trim();
                  int len = strID.Length;

                  if (strID.Equals(JDFConstants.EMPTYSTRING))
                  {
                     continue;
                  }

                  int iPos = 0;
                  while (iPos < len && strID[iPos] == '0')
                  {
                     iPos++;
                  }

                  if (iPos > 0)
                  {
                     strID = strID.Substring(iPos);
                  }

                  if (strID.Equals(JDFConstants.EMPTYSTRING))
                  {
                     continue;
                  }

                  int iS = Convert.ToInt32(strID); // new int(strID).intValue();
                  if (iS > 1000000) // not in the simple ordering
                  {
                     iS = iS % 1000000;
                  }

                  iMax = (iS > iMax) ? iS : iMax;
               }
            }
         }

         uniqueID(iMax);

         return iMax;
      }

      ///   
      ///	 <summary> * gets the maximum job part id; note that this assumes integer job part ids return
      ///	 *  </summary>
      ///	 * <param name="idPrefix"> </param>
      ///	 * <returns> int </returns>
      ///	 
      public virtual int getMaxJobPartId(string idPrefix)
      {
         VElement v = getvJDFNode(null, null, false);
         int prefixSize = idPrefix.Length;
         int iMax = -1;
         int size = v.Count;
         for (int i = 0; i < size; i++)
         {
            JDFNode e = (JDFNode)v[i];
            string s = e.getJobPartID(false);
            if (s.Equals(JDFConstants.EMPTYSTRING) || s.Substring(0, prefixSize).Equals(idPrefix.Substring(0, prefixSize)))
            {
               continue;
            }
            s = s.Substring(prefixSize).Trim();

            int pos = 0;
            int len = s.Length;

            while ((pos < len) && (s[pos] == '0'))
            {
               pos++;
            }
            // 300402 RP added
            if (pos > 0)
            {
               s = s.Substring(s.Length - pos); //.rightStr(-pos)
               // ;
            }
            if (s.Equals(JDFConstants.EMPTYSTRING))
            {
               continue;
            }
            //iMax = (new int(s).intValue() > iMax) ? new int(s).intValue() : iMax;
            iMax = (Convert.ToInt32(s) > iMax) ? Convert.ToInt32(s) : iMax;

         }
         return iMax;
      }


      ///   
      ///	 <summary> * add a JDFNode remove @Types to avoid inconsistent JDF
      ///	 *  </summary>
      ///	 * <param name="typ"> type of JDFNode to add </param>
      ///	 * <returns> JDFNodethe added JDFNode </returns>
      ///	 
      public virtual JDFNode addJDFNode(string typ)
      {
         EnumType t = EnumType.getEnum(getType());

         if (t == null || !t.Equals(EnumType.Product) && !t.Equals(EnumType.ProcessGroup))
         {
            throw new JDFException("JDFNode.addJDFNode adding ProcessGroup to invalid node type: Type = " + getType());
         }
         JDFNode p = (JDFNode)appendElement(ElementName.JDF, null);
         if (typ != null && !typ.Equals(JDFConstants.EMPTYSTRING))
         {
            p.setType(typ, false);
         }
         removeAttribute(AttributeName.TYPES); // otherwise we have an illegal
         // combination
         return p;
      }


      ///   
      ///	 <summary> * add a JDFNode
      ///	 *  </summary>
      ///	 * <param name="typ"> enum type of JDFNode to add </param>
      ///	 * <returns> the added JDFNode </returns>
      ///	 
      public virtual JDFNode addJDFNode(EnumType typ)
      {
         JDFNode p = addJDFNode((string)null);
         p.setType(typ);
         return p;
      }


      ///   
      ///	 * @deprecated use addJDFNode(EnumType typ) or addJDFNode(String typ) 
      ///	 
      [Obsolete("use addJDFNode(EnumType typ) or addJDFNode(String typ)")]
      public virtual JDFNode addProcess(string prodName)
      {
         JDFNode p = addJDFNode(prodName);
         return p;
      }


      ///   
      ///	 <summary> * Add a process group node
      ///	 *  </summary>
      ///	 * <param name="tasks"> types of the processgroup </param>
      ///	 * <returns> the added JDFNode
      ///	 * 
      ///	 * @default addProcessGroup(null) </returns>
      ///	 
      public virtual JDFNode addProcessGroup(VString tasks)
      {
         JDFNode p = addJDFNode(EnumType.ProcessGroup);
         p.setType(EnumType.ProcessGroup.getName(), false);
         if (tasks != null && !tasks.Equals(VString.emptyVector))
         {
            p.setTypes(tasks);
         }
         return p;
      }


      ///   
      ///	 <summary> * add a combined node
      ///	 *  </summary>
      ///	 * <param name="tasks"> types of the node to add </param>
      ///	 * <returns> the added node </returns>
      ///	 
      public virtual JDFNode addCombined(VString tasks)
      {
         JDFNode cNode = addJDFNode(EnumType.Combined);
         cNode.setTypes(tasks);
         return cNode;
      }

      ///   
      ///	 <summary> * add a product node to this
      ///	 *  </summary>
      ///	 * <exception cref="JDFException"> ith this is not a Product itself </exception>
      ///	 
      public virtual JDFNode addProduct()
      {
         if (!EnumType.getEnum(getType()).Equals(EnumType.Product))
         {
            throw new JDFException("JDFNode.AddProduct adding Product to invalid node type: Type = " + getType());
         }
         JDFNode p = addJDFNode(EnumType.Product);
         return p;
      }

      ///   
      ///	 <summary> * remove all completed nodes
      ///	 * 
      ///	 * @deprecated </summary>
      ///	 
      [Obsolete]
      public virtual bool removeCompleted()
      {
         VElement v = getCompleted();
         for (int i = 0; i < v.Count; i++)
         {
            JDFNode pr = (JDFNode)v[i];
            pr.removeNode(false);
         }
         return true;
      }

      ///   
      ///	 <summary> * get a vector with all nodes
      ///	 *  </summary>
      ///	 * <returns> vector with all nodes </returns>
      ///	 
      public virtual VElement getCompleted()
      {
         VElement v = getvJDFNode(null, null, false);
         VElement v2 = new VElement();
         int size = v.Count;
         for (int i = 0; i < size; i++)
         {
            JDFNode pr = (JDFNode)v[i];
            if (pr == null)
            {
               break;
            }
            if (pr.getStatus().Equals(EnumNodeStatus.Completed))
            {
               v2.Add(pr);
            }
         }
         return v2;
      }


      ///   
      ///	 <summary> * Returns a resource with id anywhere in the tree below this node similar to getTarget(id) but looks only in the
      ///	 * resource pool's direct children
      ///	 *  </summary>
      ///	 * <param name="id"> the id of the resource
      ///	 *  </param>
      ///	 * <returns> the resource, if available </returns>
      ///	 
      public virtual JDFResource getTargetResource(string id)
      {

         XMLDocUserData ud = getXMLDocUserData();
         if (ud != null)
         {
            KElement e = ud.getTarget(id);
            if (e is JDFResource)
            {
               return (JDFResource)e;
            }
         }

         JDFResourcePool p = getResourcePool();

         if (p != null)
         {
            JDFResource r = p.getResourceByID(id);
            if (r != null)
            {
               return r;
            }
         }

         VElement v = getvJDFNode(null, null, true);
         for (int i = 0; i < v.Count; i++)
         {
            JDFResource r = ((JDFNode)v[i]).getTargetResource(id);
            if (r != null)
            {
               return r;
            }
         }
         return null;
      }

      ///   
      ///	 <summary> * searches for the first attribute occurence in the ancestor elements subelements
      ///	 *  </summary>
      ///	 * <param name="attrib"> the attribute name </param>
      ///	 * <param name="nameSpaceURI"> the XML-namespace </param>
      ///	 * <param name="def"> default value, if no matching attribute is found
      ///	 * @since 180502 </param>
      ///	 * <returns> String - value of attribute found, empty string if not available </returns>
      ///	 
      public virtual string getAncestorElementAttribute(string element, string attrib, string nameSpaceURI, string def)
      {
         JDFNode n = this;
         while (n != null)
         {
            KElement e = getElement(element, nameSpaceURI, 0);

            if ((e != null) && (e.hasAttribute(attrib, nameSpaceURI, false)))
            {
               return e.getAttribute(attrib, nameSpaceURI, null);
            }

            n = getParentJDF();
         }

         JDFNode root = getJDFRoot();
         if (root == null)
         {
            return def;
         }
         JDFAncestorPool ancestorPool = root.getAncestorPool();
         if (ancestorPool == null)
         {
            return def;
         }
         return ancestorPool.getAncestorElementAttribute(element, attrib, nameSpaceURI, def);

      }

      ///   
      ///	 <summary> * true if a non default attribute occurs in the parent nodes and the ancestor elements subelements of the root
      ///	 * ancestorpool exists
      ///	 *  </summary>
      ///	 * <param name="element"> </param>
      ///	 * <param name="attrib"> the attribute name </param>
      ///	 * <param name="nameSpaceURI"> the XML-namespace
      ///	 * @since 180502 </param>
      ///	 * <returns> true if the attribute exists </returns>
      ///	 
      public virtual bool hasAncestorElementAttribute(string element, string attrib, string nameSpaceURI)
      {
         return getAncestorElementAttribute(element, attrib, nameSpaceURI, null) != null;
      }

      ///   
      ///	 <summary> * Get vector of linked input resource intents
      ///	 *  </summary>
      ///	 * <returns> VElement vector of all input intent resources that are linked as inputs to this node </returns>
      ///	 
      public virtual VElement getIntents()
      {
         VElement velem = null;

         JDFResourceLinkPool rlp = getResourceLinkPool();

         if (rlp != null)
         {
            JDFAttributeMap mALink = new JDFAttributeMap(AttributeName.USAGE, "Input"); // map
            // of
            // requesetd
            // link
            // attributes
            JDFAttributeMap mARes = new JDFAttributeMap(AttributeName.CLASS, "Intent"); // map
            // of
            // requesetd
            // resource
            // attributes

            velem = rlp.getLinkedResources(null, mALink, mARes, false);
         }
         return velem; // grab em, don't worry about the resname
      }

      ///   
      ///	 <summary> * get a vector of ResourceLink elements that exist but are unknown by this element
      ///	 *  </summary>
      ///	 * <param name="vInNameSpace"> list of namespaces where unknown Links are searched for<br>
      ///	 *            if null, all namespaces are searched </param>
      ///	 * <param name="nMax"> maximum size of the returned vector </param>
      ///	 * <returns> VElement vector of unknown elements
      ///	 * @since 060730 return type changed to VElement - but since the routine was utterly broken, we should be ok </returns>
      ///	 
      public virtual VElement getUnknownLinkVector(VString vInNameSpace, int nMax)
      {
         VElement vUnknown = null;

         VString names = linkNames();
         VElement ve = getResourceLinks(null, null, null);
         bool bAllNS = vInNameSpace == null || vInNameSpace.IsEmpty();

         if (vInNameSpace != null)
         {
            for (int j = 0; j < vInNameSpace.Count; j++)
            {
               // tokenize needs a blank
               if (vInNameSpace[j].Equals(JDFConstants.BLANK))
               {
                  vInNameSpace[j] = JDFConstants.EMPTYSTRING;
               }
            }
         }

         if (ve != null)
         {
            VElement.Enumerator veIterator = ve.GetEnumerator();
            while (veIterator.MoveNext())
            {
               JDFResourceLink rl = (JDFResourceLink)veIterator.Current;
               string nodename = rl.Name.Substring(0, rl.Name.Length - 4);

               if (bAllNS || (vInNameSpace != null && vInNameSpace.Contains(xmlnsPrefix(nodename))))
               {
                  if (!names.Contains(nodename))
                  {
                     if (vUnknown == null)
                     {
                        vUnknown = new VElement();
                     }

                     vUnknown.Add(rl);
                     if (vUnknown.Count >= nMax)
                     {
                        break;
                     }
                  }
               }
            }
         }

         return vUnknown;
      }

      ///   
      ///	 <summary> * set attribute Category
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setCategory(string @value)
      {
         setAttribute(AttributeName.CATEGORY, @value);
      }

      ///   
      ///	 <summary> * get string attribute Category
      ///	 *  </summary>
      ///	 * <returns> the attribute value </returns>
      ///	 
      public virtual string getCategory()
      {
         return getAttribute(AttributeName.CATEGORY);
      }

      ///   
      ///	 * @deprecated - use getCategory() instead 
      ///	 
      [Obsolete("- use getCategory() instead")]
      public virtual string getCategory(bool bInherit)
      {
         if (bInherit)
         {
            return getAncestorAttribute(AttributeName.CATEGORY, null, JDFConstants.EMPTYSTRING);
         }
         return getAttribute(AttributeName.CATEGORY);
      }

      ///   
      ///	 <summary> * set attribute ICSVersions
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setICSVersions(VString @value)
      {
         setAttribute(AttributeName.ICSVERSIONS, @value, null);
      }

      ///   
      ///	 <summary> * get NMTOKENS attribute ICSVersions
      ///	 *  </summary>
      ///	 * <param name="bInherit"> if true recurse through ancestors when searching </param>
      ///	 * <returns> VString - attribute value
      ///	 * 
      ///	 * @default getICSVersions(false) </returns>
      ///	 
      public virtual VString getICSVersions(bool bInherit)
      {
         if (bInherit)
         {
            return new VString(getAncestorAttribute(AttributeName.ICSVERSIONS, null, JDFConstants.EMPTYSTRING), null);
         }
         return new VString(getAttribute(AttributeName.ICSVERSIONS), null);
      }

      ///   
      ///	 <summary> * set attribute ID
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setID(string @value)
      {
         setAttribute(AttributeName.ID, @value);
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.core.JDFElement#getID()
      //	 
      public override string getID()
      {
         return this.getAttribute(AttributeName.ID, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * set MaxVersion to enumVer
      ///	 *  </summary>
      ///	 * <param name="enumVer"> the EnumVersion to set </param>
      ///	 
      public virtual void setMaxVersion(EnumVersion enumVer)
      {
         setAttribute(AttributeName.MAXVERSION, enumVer.getName(), null);
      }

      ///   
      ///	 <summary> *  </summary>
      ///	 * <param name="value"> the string version to set MaxVersion to </param>
      ///	 * @deprecated use setMaxVersion(EnumVersion) 
      ///	 
      [Obsolete("use setMaxVersion(EnumVersion)")]
      public virtual void setMaxVersion(string @value)
      {
         setAttribute(AttributeName.MAXVERSION, @value);
      }

      ///   
      ///	 <summary> * get attribute MaxVersion, defaults to version if not set
      ///	 *  </summary>
      ///	 * <param name="bInherit"> if true recurse through ancestors when searching </param>
      ///	 * <returns> EnumVersion - attribute value
      ///	 * 
      ///	 *         default - getMaxVersion(false) </returns>
      ///	 
      public override EnumVersion getMaxVersion(bool bInherit)
      {
         string version = (bInherit) ? getAncestorAttribute(AttributeName.MAXVERSION, null, null) : getAttribute(AttributeName.MAXVERSION, null, null);

         if (version == null)
            return getVersion(bInherit);

         return EnumVersion.getEnum(version);
      }

      ///   
      ///	 <summary> * set attribute NamedFeatures
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setNamedFeatures(VString @value)
      {
         StringBuilder strbuff = new StringBuilder(100);
         for (int i = 0; i < @value.Count; i++)
         {
            strbuff.Append(@value[i]);
         }
         setAttribute(AttributeName.NAMEDFEATURES, strbuff.ToString());
      }

      ///   
      ///	 <summary> * Get NMTOKENS attribute NamedFeatures
      ///	 *  </summary>
      ///	 * <returns> the attribute value </returns>
      ///	 
      public virtual VString getNamedFeatures()
      {
         return new VString(getAttribute(AttributeName.NAMEDFEATURES, null, JDFConstants.EMPTYSTRING), null);
      }

      ///   
      ///	 * @deprecated - use getNamedFeatures() instead 
      ///	 
      [Obsolete("- use getNamedFeatures() instead")]
      public virtual VString GetNamedFeatures(bool bInherit)
      {
         VString v = new VString();
         ArrayList v2;

         if (bInherit)
         {
            v2 = StringUtil.tokenize(getAncestorAttribute(AttributeName.NAMEDFEATURES, null, JDFConstants.EMPTYSTRING), JDFConstants.BLANK, false);
            v.AddRange(new VString(v2));
            return v;
         }
         v2 = StringUtil.tokenize(getAttribute(AttributeName.NAMEDFEATURES), JDFConstants.BLANK, false);
         v.AddRange(new VString(v2));
         return v;
      }

      ///   
      ///	 <summary> * set attribute ProjectID
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setRelatedJobID(string @value)
      {
         setAttribute(AttributeName.RELATEDJOBID, @value);
      }

      ///   
      ///	 <summary> * get string attribute RelatedJobID
      ///	 *  </summary>
      ///	 * <param name="bInherit"> recurse through ancestors when searching </param>
      ///	 * <returns> the attribute value </returns>
      ///	 
      public virtual string getRelatedJobID(bool bInherit)
      {
         if (bInherit)
         {
            return getAncestorAttribute(AttributeName.RELATEDJOBID, null, JDFConstants.EMPTYSTRING);
         }
         return getAttribute(AttributeName.RELATEDJOBID);
      }

      ///   
      ///	 <summary> * set attribute RelatedJobPartID
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setRelatedJobPartID(string @value)
      {
         setAttribute(AttributeName.RELATEDJOBPARTID, @value);
      }

      ///   
      ///	 <summary> * get string attribute RelatedJobPartID
      ///	 *  </summary>
      ///	 * <param name="bInherit"> recurse through ancestors when searching </param>
      ///	 * <returns> the attribute value </returns>
      ///	 
      public virtual string getRelatedJobPartID(bool bInherit)
      {
         if (bInherit)
         {
            return getAncestorAttribute(AttributeName.RELATEDJOBPARTID, null, JDFConstants.EMPTYSTRING);
         }
         return getAttribute(AttributeName.RELATEDJOBPARTID);
      }

      ///   
      ///	 <summary> * set attribute StatusDetails
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setStatusDetails(string @value)
      {
         setAttribute(AttributeName.STATUSDETAILS, @value);
      }

      ///   
      ///	 <summary> * get string attribute StatusDetails
      ///	 *  </summary>
      ///	 * <returns> the attribute value </returns>
      ///	 
      public virtual string getStatusDetails()
      {
         return getAttribute(AttributeName.STATUSDETAILS);
      }

      ///   
      ///	 * @deprecated - use getStatusDetails() instead 
      ///	 
      [Obsolete("- use getStatusDetails() instead")]
      public virtual string getStatusDetails(bool bInherit)
      {
         if (bInherit)
         {
            return getAncestorAttribute(AttributeName.STATUSDETAILS, null, JDFConstants.EMPTYSTRING);
         }
         return getAttribute(AttributeName.STATUSDETAILS);
      }

      ///   
      ///	 <summary> * set attribute Template
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setTemplate(bool @value)
      {
         setAttribute(AttributeName.TEMPLATE, @value, null);
      }

      ///   
      ///	 <summary> * get boolean attribute Template, default=false
      ///	 *  </summary>
      ///	 * <returns> the attribute value </returns>
      ///	 
      public virtual bool getTemplate()
      {
         return getBoolAttribute(AttributeName.TEMPLATE, null, false);
      }

      ///   
      ///	 <summary> * set attribute TemplateID
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setTemplateID(string @value)
      {
         setAttribute(AttributeName.TEMPLATEID, @value);
      }

      ///   
      ///	 <summary> * get string attribute TemplateID
      ///	 *  </summary>
      ///	 * <param name="bInherit"> recurse through ancestors when searching </param>
      ///	 * <returns> the attribute value </returns>
      ///	 
      public virtual string getTemplateID(bool bInherit)
      {
         if (bInherit)
         {
            return getAncestorAttribute(AttributeName.TEMPLATEID, null, JDFConstants.EMPTYSTRING);
         }
         return getAttribute(AttributeName.TEMPLATEID);
      }

      ///   
      ///	 <summary> * set attribute TemplateVersion
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setTemplateVersion(string @value)
      {
         setAttribute(AttributeName.TEMPLATEVERSION, @value);
      }

      ///   
      ///	 <summary> * get string attribute TemplateVersion
      ///	 *  </summary>
      ///	 * <param name="bInherit"> recurse through ancestors when searching </param>
      ///	 * <returns> the attribute value </returns>
      ///	 
      public virtual string getTemplateVersion(bool bInherit)
      {
         if (bInherit)
         {
            return getAncestorAttribute(AttributeName.TEMPLATEVERSION, null, JDFConstants.EMPTYSTRING);
         }
         return getAttribute(AttributeName.TEMPLATEVERSION);
      }

      ///   
      ///	 <summary> * get the NodeInfo/@workstepid for a given partition if no workstepID exists, returns jobPartID
      ///	 *  </summary>
      ///	 * <returns> the workstepid
      ///	 *  </returns>
      ///	 
      public virtual string getWorkStepID(JDFAttributeMap map)
      {
         JDFNodeInfo ni = getNodeInfo();
         if (ni == null)
            return getJobPartID(false);
         ni = (JDFNodeInfo)ni.getPartition(map, null);
         if (ni == null)
            return getJobPartID(false);
         string wsID = ni.getWorkStepID();
         return isWildCard(wsID) ? getJobPartID(false) : wsID;
      }

      ///   
      ///	 *@deprecated 06ß221 use getInheritedNodeInfo(String attName) 
      ///	 * <returns> JDFDuration </returns>
      ///	 
      [Obsolete("06ß221 use getInheritedNodeInfo(String attName)")]
      public virtual JDFDuration getNodeInfoCleanupDuration()
      {
         return getInheritedNodeInfo(null).getCleanupDuration();
      }

      ///   
      ///	 *@deprecated 06ß221 use getInheritedNodeInfo(String attName) 
      ///	 * <returns> JDFMISDetails.EnumCostType </returns>
      ///	 
      [Obsolete("06ß221 use getInheritedNodeInfo(String attName)")]
      public virtual JDFMISDetails.EnumCostType getNodeInfoCostType()
      {
         JDFNodeInfo inheritedNodeInfo = getInheritedNodeInfo(null);
         if (inheritedNodeInfo == null)
         {
            return null;
         }
         JDFMISDetails details = inheritedNodeInfo.getMISDetails();
         if (details == null)
         {
            return null;
         }
         return details.getCostType();
      }

      ///   
      ///	 * @deprecated 06ß221 use getInheritedNodeInfo(String attName) 
      ///	 
      [Obsolete("06ß221 use getInheritedNodeInfo(String attName)")]
      public virtual JDFNodeInfo.EnumDueLevel getNodeInfoDueLevel()
      {
         JDFNodeInfo inheritedNodeInfo = getInheritedNodeInfo(null);
         if (inheritedNodeInfo == null)
         {
            return null;
         }
         return inheritedNodeInfo.getDueLevel();
      }

      ///   
      ///	 *@deprecated 06ß221 use getInheritedNodeInfo(String attName) 
      ///	 
      [Obsolete("06ß221 use getInheritedNodeInfo(String attName)")]
      public virtual JDFDate getNodeInfoEnd()
      {
         JDFNodeInfo inheritedNodeInfo = getInheritedNodeInfo(null);
         if (inheritedNodeInfo == null)
         {
            return null;
         }
         return inheritedNodeInfo.getEnd();
      }

      ///   
      ///	 *@deprecated 06ß221 use getInheritedNodeInfo(String attName) 
      ///	 
      [Obsolete("06ß221 use getInheritedNodeInfo(String attName)")]
      public virtual JDFDate getNodeInfoFirstEnd()
      {
         JDFNodeInfo inheritedNodeInfo = getInheritedNodeInfo(null);
         if (inheritedNodeInfo == null)
         {
            return null;
         }
         return inheritedNodeInfo.getFirstEnd();
      }

      ///   
      ///	 *@deprecated 06ß221 use getInheritedNodeInfo(String attName) 
      ///	 
      [Obsolete("06ß221 use getInheritedNodeInfo(String attName)")]
      public virtual JDFDate getNodeInfoFirstStart()
      {
         JDFNodeInfo inheritedNodeInfo = getInheritedNodeInfo(null);
         if (inheritedNodeInfo == null)
         {
            return null;
         }
         return inheritedNodeInfo.getFirstStart();
      }

      ///   
      ///	 *@deprecated 06ß221 use getInheritedNodeInfo(String attName) 
      ///	 
      [Obsolete("06ß221 use getInheritedNodeInfo(String attName)")]
      public virtual JDFXYPair getNodeInfoIPPVersion()
      {
         JDFNodeInfo inheritedNodeInfo = getInheritedNodeInfo(null);
         if (inheritedNodeInfo == null)
         {
            return null;
         }
         return inheritedNodeInfo.getIPPVersion();
      }

      ///   
      ///	 *@deprecated 06ß221 use getInheritedNodeInfo(String attName) 
      ///	 
      [Obsolete("06ß221 use getInheritedNodeInfo(String attName)")]
      public virtual int getNodeInfoJobPriority()
      {
         JDFNodeInfo inheritedNodeInfo = getInheritedNodeInfo(null);
         if (inheritedNodeInfo == null)
         {
            return 0;
         }
         return inheritedNodeInfo.getJobPriority();
      }

      ///   
      ///	 *@deprecated 06ß221 use getInheritedNodeInfo(String attName) 
      ///	 
      [Obsolete("06ß221 use getInheritedNodeInfo(String attName)")]
      public virtual JDFDate getNodeInfoLastEnd()
      {
         JDFNodeInfo inheritedNodeInfo = getInheritedNodeInfo(null);
         if (inheritedNodeInfo == null)
         {
            return null;
         }
         return inheritedNodeInfo.getLastEnd();
      }

      ///   
      ///	 *@deprecated 06ß221 use getInheritedNodeInfo(String attName) 
      ///	 
      [Obsolete("06ß221 use getInheritedNodeInfo(String attName)")]
      public virtual JDFDate getNodeInfoLastStart()
      {
         JDFNodeInfo inheritedNodeInfo = getInheritedNodeInfo(null);
         if (inheritedNodeInfo == null)
         {
            return null;
         }
         return inheritedNodeInfo.getLastStart();
      }

      ///   
      ///	 *@deprecated 06ß221 use getInheritedNodeInfo(String attName) 
      ///	 
      [Obsolete("06ß221 use getInheritedNodeInfo(String attName)")]
      public virtual string getNodeInfoNaturalLang()
      {
         JDFNodeInfo inheritedNodeInfo = getInheritedNodeInfo(null);
         if (inheritedNodeInfo == null)
         {
            return JDFConstants.EMPTYSTRING;
         }
         return inheritedNodeInfo.getNaturalLang();
      }

      ///   
      ///	 *@deprecated 06ß221 use getInheritedNodeInfo(String attName) 
      ///	 
      [Obsolete("06ß221 use getInheritedNodeInfo(String attName)")]
      public virtual string getNodeInfoRoute()
      {
         JDFNodeInfo inheritedNodeInfo = getInheritedNodeInfo(null);
         if (inheritedNodeInfo == null)
         {
            return JDFConstants.EMPTYSTRING;
         }
         return inheritedNodeInfo.getRoute();
      }

      ///   
      ///	 *@deprecated 06ß221 use getInheritedNodeInfo(String attName) 
      ///	 
      [Obsolete("06ß221 use getInheritedNodeInfo(String attName)")]
      public virtual JDFDuration getNodeInfoSetupDuration()
      {
         JDFNodeInfo inheritedNodeInfo = getInheritedNodeInfo(null);
         if (inheritedNodeInfo == null)
         {
            return null;
         }
         return inheritedNodeInfo.getSetupDuration();
      }

      ///   
      ///	 *@deprecated 06ß221 use getInheritedNodeInfo(String attName) 
      ///	 
      [Obsolete("06ß221 use getInheritedNodeInfo(String attName)")]
      public virtual JDFDate getNodeInfoStart()
      {
         JDFNodeInfo inheritedNodeInfo = getInheritedNodeInfo(null);
         if (inheritedNodeInfo == null)
         {
            return null;
         }
         return inheritedNodeInfo.getStart();
      }

      ///   
      ///	 *@deprecated 06ß221 use getInheritedNodeInfo(String attName) 
      ///	 
      [Obsolete("06ß221 use getInheritedNodeInfo(String attName)")]
      public virtual string getNodeInfoTargetRoute()
      {
         JDFNodeInfo inheritedNodeInfo = getInheritedNodeInfo(null);
         if (inheritedNodeInfo == null)
         {
            return JDFConstants.EMPTYSTRING;
         }
         return inheritedNodeInfo.getTargetRoute();
      }

      ///   
      ///	 *@deprecated 06ß221 use getInheritedNodeInfo(String attName) 
      ///	 
      [Obsolete("06ß221 use getInheritedNodeInfo(String attName)")]
      public virtual JDFDuration getNodeInfoTotalDuration()
      {
         JDFNodeInfo inheritedNodeInfo = getInheritedNodeInfo(null);
         if (inheritedNodeInfo == null)
         {
            return null;
         }
         return inheritedNodeInfo.getTotalDuration();
      }

      ///   
      ///	 *@deprecated 06ß221 use getInheritedNodeInfo(String attName) 
      ///	 
      [Obsolete("06ß221 use getInheritedNodeInfo(String attName)")]
      public virtual JDFMISDetails.EnumWorkType getNodeInfoWorkType()
      {
         JDFNodeInfo inheritedNodeInfo = getInheritedNodeInfo(null);
         if (inheritedNodeInfo == null)
         {
            return null;
         }
         JDFMISDetails details = inheritedNodeInfo.getMISDetails();
         if (details == null)
         {
            return null;
         }
         return details.getWorkType();
      }

      ///   
      ///	 *@deprecated 06ß221 use getInheritedNodeInfo(String attName) 
      ///	 
      [Obsolete("06ß221 use getInheritedNodeInfo(String attName)")]
      public virtual string getNodeInfoWorkTypeDetails()
      {
         JDFNodeInfo inheritedNodeInfo = getInheritedNodeInfo(null);
         if (inheritedNodeInfo == null)
         {
            return null;
         }
         JDFMISDetails details = inheritedNodeInfo.getMISDetails();
         if (details == null)
         {
            return null;
         }
         return details.getWorkTypeDetails();
      }

      ///   
      ///	 *@deprecated 06ß221 use getInheritedNodeInfo(String attName) 
      ///	 
      [Obsolete("06ß221 use getInheritedNodeInfo(String attName)")]
      public virtual JDFBusinessInfo getNodeInfoBusinessInfo()
      {
         JDFNodeInfo inheritedNodeInfo = getInheritedNodeInfo(null);
         if (inheritedNodeInfo == null)
         {
            return null;
         }
         return inheritedNodeInfo.getBusinessInfo();
      }

      ///   
      ///	 *@deprecated 06ß221 use getInheritedNodeInfo(String attName) 
      ///	 
      [Obsolete("06ß221 use getInheritedNodeInfo(String attName)")]
      public virtual JDFEmployee getNodeInfoEmployee()
      {
         JDFNodeInfo inheritedNodeInfo = getInheritedNodeInfo(null);
         if (inheritedNodeInfo == null)
         {
            return null;
         }
         return inheritedNodeInfo.getEmployee();
      }

      ///   
      ///	 *@deprecated 06ß221 use getInheritedNodeInfo(String attName) 
      ///	 
      [Obsolete("06ß221 use getInheritedNodeInfo(String attName)")]
      public virtual JDFJMF getNodeInfoJMF(int iSkip)
      {
         JDFNodeInfo inheritedNodeInfo = getInheritedNodeInfo(null);
         if (inheritedNodeInfo == null)
         {
            return null;
         }
         return inheritedNodeInfo.getJMF(iSkip);
      }

      ///   
      ///	 *@deprecated 06ß221 use getInheritedNodeInfo(String attName) 
      ///	 
      [Obsolete("06ß221 use getInheritedNodeInfo(String attName)")]
      public virtual JDFNotificationFilter getNodeInfoNotificationFilter(int iSkip)
      {
         JDFNodeInfo inheritedNodeInfo = getInheritedNodeInfo(null);
         if (inheritedNodeInfo == null)
         {
            return null;
         }
         return inheritedNodeInfo.getNotificationFilter(iSkip);
      }

      ///   
      ///	 <summary> * get first CustomerInfo element from child list or child list of any ancestor
      ///	 *  </summary>
      ///	 * <param name="xPath"> the the xPath to an element or attribute that must exist in the queried CustomerInfo<br>
      ///	 *            note that attributes must be marked with an "@", if xPath=null, simply return the next in line
      ///	 *  </param>
      ///	 * <returns> the matching CustomerInfo element </returns>
      ///	 
      public virtual JDFCustomerInfo getInheritedCustomerInfo(string xPath)
      {
         return (JDFCustomerInfo)getNiCi(ElementName.CUSTOMERINFO, true, xPath);
      }

      ///   
      ///	 <summary> * get first CustomerInfo element from child list or child list of any ancestor
      ///	 *  </summary>
      ///	 * @deprecated 06ß221 use getInheritedCustomerInfo(String xPath) 
      ///	 * <returns> CustomerInfo The matching CustomerInfo element </returns>
      ///	 
      [Obsolete("06ß221 use getInheritedCustomerInfo(String xPath)")]
      public virtual JDFCustomerInfo getInheritedCustomerInfo()
      {
         return getInheritedCustomerInfo(null);
      }

      ///   
      ///	 *@deprecated 06ß221 use getInheritedCustomerInfo(String attName) 
      ///	 
      [Obsolete("06ß221 use getInheritedCustomerInfo(String attName)")]
      public virtual string getCustomerInfoBillingCode()
      {
         JDFCustomerInfo inheritedCustomerInfo = getInheritedCustomerInfo();
         if (inheritedCustomerInfo == null)
         {
            return JDFConstants.EMPTYSTRING;
         }
         return inheritedCustomerInfo.getBillingCode();
      }

      ///   
      ///	 *@deprecated 06ß221 use getInheritedCustomerInfo(String attName) 
      ///	 
      [Obsolete("06ß221 use getInheritedCustomerInfo(String attName)")]
      public virtual string getCustomerInfoCustomerID()
      {
         JDFCustomerInfo inheritedCustomerInfo = getInheritedCustomerInfo();
         if (inheritedCustomerInfo == null)
         {
            return JDFConstants.EMPTYSTRING;
         }
         return inheritedCustomerInfo.getCustomerID();
      }

      ///   
      ///	 *@deprecated 06ß221 use getInheritedCustomerInfo(String attName) 
      ///	 
      [Obsolete("06ß221 use getInheritedCustomerInfo(String attName)")]
      public virtual string getCustomerInfoCustomerJobName()
      {
         JDFCustomerInfo inheritedCustomerInfo = getInheritedCustomerInfo();
         if (inheritedCustomerInfo == null)
         {
            return JDFConstants.EMPTYSTRING;
         }
         return inheritedCustomerInfo.getCustomerJobName();
      }

      ///   
      ///	 *@deprecated 06ß221 use getInheritedCustomerInfo(String attName) 
      ///	 
      [Obsolete("06ß221 use getInheritedCustomerInfo(String attName)")]
      public virtual string getCustomerInfoCustomerOrderID()
      {
         JDFCustomerInfo inheritedCustomerInfo = getInheritedCustomerInfo();
         if (inheritedCustomerInfo == null)
         {
            return JDFConstants.EMPTYSTRING;
         }
         return inheritedCustomerInfo.getCustomerOrderID();
      }

      ///   
      ///	 *@deprecated 06ß221 use getInheritedCustomerInfo(String attName) 
      ///	 
      [Obsolete("06ß221 use getInheritedCustomerInfo(String attName)")]
      public virtual string getCustomerInfoCustomerProjectID()
      {
         JDFCustomerInfo inheritedCustomerInfo = getInheritedCustomerInfo();
         if (inheritedCustomerInfo == null)
         {
            return JDFConstants.EMPTYSTRING;
         }
         return inheritedCustomerInfo.getCustomerProjectID();
      }

      ///   
      ///	 *@deprecated 06ß221 use getInheritedCustomerInfo(String attName) 
      ///	 
      [Obsolete("06ß221 use getInheritedCustomerInfo(String attName)")]
      public virtual JDFCompany getCustomerInfoCompany()
      {
         JDFCustomerInfo inheritedCustomerInfo = getInheritedCustomerInfo();
         if (inheritedCustomerInfo == null)
         {
            return null;
         }
         return inheritedCustomerInfo.getCompany();
      }

      ///   
      ///	 *@deprecated 06ß221 use getInheritedCustomerInfo(String attName) 
      ///	 
      [Obsolete("06ß221 use getInheritedCustomerInfo(String attName)")]
      public virtual JDFContact getCustomerInfoContact(int iSkip)
      {
         JDFCustomerInfo inheritedCustomerInfo = getInheritedCustomerInfo();
         if (inheritedCustomerInfo == null)
         {
            return null;
         }
         return inheritedCustomerInfo.getContact(iSkip);
      }

      ///   
      ///	 *@deprecated 06ß221 use getInheritedCustomerInfo(String attName) 
      ///	 
      [Obsolete("06ß221 use getInheritedCustomerInfo(String attName)")]
      public virtual JDFCustomerMessage getCustomerInfoCustomerMessage(int iSkip)
      {
         JDFCustomerInfo inheritedCustomerInfo = getInheritedCustomerInfo();
         if (inheritedCustomerInfo == null)
         {
            return null;
         }
         return inheritedCustomerInfo.getCustomerMessage(iSkip);
      }

      ///   
      ///	 <summary> * Checks if this process is the successor of the given process node.
      ///	 *  </summary>
      ///	 * <param name="proc"> node to check against
      ///	 *  </param>
      ///	 * <returns> boolean - <code>true</code> if this process is successor of given process </returns>
      ///	 

      public virtual bool isSuccessor(JDFNode proc)
      {
         bool isSuccessor = false;

         if (isProcessNode() && proc.isProcessNode())
         {
            VString vsInputResIDs = getResourceIDs(true);

            VString vsOutputResIDs = proc.getResourceIDs(false);

            for (int i = 0; (i < vsInputResIDs.Count) && !isSuccessor; i++)
            {
               isSuccessor = vsOutputResIDs.Contains(vsInputResIDs[i]);
            }
         }

         return isSuccessor;
      }

      ///   
      ///	 <summary> * Returns the input or output resource IDs of this process node.
      ///	 *  </summary>
      ///	 * <param name="isInput"> <li><code>true</code> to get input resource IDs.</li> <li>
      ///	 *            <code>false</code> to get output resource IDs.</li>
      ///	 *  </param>
      ///	 * <returns> VString - Vector containing resource IDs. </returns>
      ///	 
      public virtual VString getResourceIDs(bool isInput)
      {
         VString vsLinks = new VString();
         JDFResourceLinkPool linkPool = getResourceLinkPool();
         if (linkPool != null)
         {
            VElement vInOutLinks = linkPool.getInOutLinks(isInput ? EnumUsage.Input : EnumUsage.Output, true, null, null);
            if (vInOutLinks != null)
            {
               int nInOutLinks = vInOutLinks.Count;
               for (int i = 0; i < nInOutLinks; i++)
               {
                  JDFResourceLink link = (JDFResourceLink)vInOutLinks[i];
                  vsLinks.Add(link.getrRef());
               }
            }
         }

         return vsLinks;
      }

      ///   
      ///	 <summary> * Gets the executable partitions of the resource in this node (with corresponding resource link). The part maps
      ///	 * returned may be nested. If the empty part map is contained, the whole resource is executable.<br>
      ///	 * 
      ///	 * Availability of a resource depends on the status, the availability of refered sub-partitions and the part usage.
      ///	 *  </summary>
      ///	 * <param name="link"> the resource link. </param>
      ///	 * <param name="res"> the resource. (legacy dummy the resource is actually calculated from the link) </param>
      ///	 * <param name="minStatus"> minimum resource status to include. </param>
      ///	 * @deprecated use getExecutablePartitions(link, minStatus); 
      ///	 * <returns> VJDFAttributeMap - A part map vector containing the executable partitions. </returns>
      ///	 
      [Obsolete("use getExecutablePartitions(link, minStatus);")]
      public virtual VJDFAttributeMap getExecutablePartitions(JDFResourceLink link, JDFResource res, JDFResource.EnumResStatus minStatus)
      {
         JDFResource resLocal = res;

         if (resLocal != null)
            resLocal = null; // satisfy compiler

         return getExecutablePartitions(link, minStatus);
      }

      ///   
      ///	 <summary> * Method getExecutablePartitions
      ///	 *  </summary>
      ///	 * @deprecated only for backward compatibility !!!
      ///	 *  
      ///	 * <param name="link"> </param>
      ///	 * <param name="minStatus">
      ///	 * @return </param>
      ///	 

      [Obsolete("only for backward compatibility !!!")]
      public virtual VJDFAttributeMap getExecutablePartitions(JDFResourceLink link, JDFResource.EnumResStatus minStatus)
      {
         return (getExecutablePartitions(link, minStatus, true));
      }

      ///   
      ///	 <summary> * Gets the executable partitions of the resource in this node (with corresponding resource link). The part maps
      ///	 * returned may be nested. If the empty part map is contained, the whole resource is executable.<br>
      ///	 * 
      ///	 * Availability of a resource depends on the status, the availability of refered sub-partitions and the part usage.
      ///	 *  </summary>
      ///	 * <param name="link"> the resource link. </param>
      ///	 * <param name="minStatus"> minimum resource status to include. </param>
      ///	 * <param name="bCheckNodeStatus"> check node status.
      ///	 *  </param>
      ///	 * <returns> VJDFAttributeMap - A part map vector containing the executable partitions. </returns>
      ///	 

      public virtual VJDFAttributeMap getExecutablePartitions(JDFResourceLink link, JDFResource.EnumResStatus minStatus, bool bCheckNodeStatus)
      {
         VJDFAttributeMap vp = new VJDFAttributeMap();
         if (link == null)
            return null;
         VElement v = link.getTargetVector(0);
         for (int i = 0; i < v.Count; i++)
         {
            JDFResource res = (JDFResource)v[i];
            addExecutablePartitions(link, res, res.getPartIDKeys(), vp, minStatus, bCheckNodeStatus);
         }
         vp.unify();
         return vp;
      }

      private ExecPartFlags addExecutablePartitions(JDFResourceLink link, JDFResource res, VString vsPartIDKeys, VJDFAttributeMap vamPartMaps, JDFResource.EnumResStatus minStatus, bool bCheckNodeStatus)
      {
         JDFAttributeMap amPartMap = res.getPartMap();

         // Check if all child partitions are executable.
         //

         VElement veChildPartitions = res.getChildElementVector_JDFElement(res.Name, null, null, false, 0, true);

         int nChildPartitions = veChildPartitions.Count;

         // Check if this is a leaf partition.
         //

         bool isLeaf = false;

         if (nChildPartitions == 0)
         {
            if (vsPartIDKeys != null)
            {
               VString vsMapKeys = amPartMap.getKeys();

               if (vsMapKeys != null)
               {
                  isLeaf = vsMapKeys.ContainsAll(vsPartIDKeys);
               }
            }
            else
            {
               isLeaf = true;
            }
         }

         // Check the process status.
         //

         bool isProcStatOK = false;

         JDFElement.EnumNodeStatus stat = getPartStatus(amPartMap);

         if (bCheckNodeStatus)
         {
            if (((stat == null) && (isLeaf)) || (stat == JDFNode.EnumNodeStatus.Waiting) || (stat == JDFNode.EnumNodeStatus.Ready))
            {
               isProcStatOK = true;
            }
         }
         else
         {
            isProcStatOK = true;
         }

         JDFResource.EnumPartUsage partUsage = res.getPartUsage();

         bool allChildsAvailable = true;
         for (int i = 0; i < nChildPartitions; i++)
         {
            JDFResource sub = (JDFResource)veChildPartitions[i];
            JDFAttributeMap amSub = sub.getPartMap();

            if (link.overlapsResourcePartMap(amSub))
            {
               ExecPartFlags ExecChild = addExecutablePartitions(link, sub, vsPartIDKeys, vamPartMaps, minStatus, bCheckNodeStatus);
               if (!ExecChild.isAvailable())
               {
                  allChildsAvailable = false;
               }

               if (!ExecChild.isProcStatOK() && (partUsage != JDFResource.EnumPartUsage.Implicit))
               {
                  isProcStatOK = false;
               }
            }
         }

         // Determine status of resource.
         //

         JDFResource.EnumResStatus statRes = res.getResStatus(false);
         bool isAvailable = (statRes.getValue() >= minStatus.getValue());

         if (nChildPartitions > 0) // Non leaf
         {
            // In case special parts are referenced by the link, the
            // resource should behave as if it has explicit part usage
            // when determining availability.
            //

            if (!allChildsAvailable)
            {
               isAvailable = false;
            }
            else
            {
               if ((partUsage != JDFResource.EnumPartUsage.Implicit) || (link.hasChildElement(ElementName.PART, null)))
               {
                  isAvailable = true;
               }
            }
         }

         // Add part map if executable, and spawn is allowed.
         //

         bool hasResourcePartMap = link.hasResourcePartMap(amPartMap, true);

         bool isExecutable = hasResourcePartMap && isProcStatOK && isAvailable && res.isSpawnAllowed();

         if (isExecutable)
         {
            if ((isLeaf) && (stat == null)) // leaf with unknown PartStatus
            {
               if (getStatus() == EnumNodeStatus.Part)
               {
                  JDFNodeInfo ni = getNodeInfo();

                  VElement veParts = ni.getPartitionVector(amPartMap, JDFResource.EnumPartUsage.Implicit);

                  if ((veParts == null) || veParts.IsEmpty())
                  {
                     vamPartMaps.Add(amPartMap);
                  }
                  else
                  {
                     for (int p = 0; p < veParts.Count; p++)
                     {
                        JDFNodeInfo niPart = (JDFNodeInfo)veParts[p];

                        JDFElement.EnumNodeStatus statPart = niPart.getNodeStatus();

                        if ((statPart == JDFNode.EnumNodeStatus.Waiting) || (statPart == JDFNode.EnumNodeStatus.Ready))
                        {
                           vamPartMaps.appendUnique(niPart.getPartMap());
                        }
                     }
                  }
               }
            }
            else
            {
               vamPartMaps.Add(amPartMap);
            }
         }

         // Return the two booleans as integer.
         //

         return new ExecPartFlags(isAvailable, isProcStatOK);
      }

      ///   
      ///	 <summary> * Class ExecPartFlags
      ///	 * 
      ///	 * Returned by <code>addExecutablePartitions</code>
      ///	 *  </summary>
      ///	 
      public sealed class ExecPartFlags
      {
         private readonly bool m_isAvailable;
         private readonly bool m_isProcStatOK;

         public ExecPartFlags(bool isAvailable, bool isProcStatOK)
         {
            m_isAvailable = isAvailable;
            m_isProcStatOK = isProcStatOK;
         }

         internal bool isAvailable()
         {
            return m_isAvailable;
         }

         internal bool isProcStatOK()
         {
            return m_isProcStatOK;
         }
      }

      ///   
      ///	 <summary> * Gets all child process nodes. This function replaces the JDFDoc.getProcessNodes, which may be implemented as
      ///	 * getJDFRoot.getProcessNodes();
      ///	 *  </summary>
      ///	 * @deprecated use getvJDFNode(null,null,false) and skip intermediate nodes
      ///	 *  
      ///	 * <returns> JDFNode [] - All child process nodes. </returns>
      ///	 

      [Obsolete("use getvJDFNode(null,null,false) and skip intermediate nodes")]
      public virtual JDFNode[] getProcessNodes()
      {
         VElement vJDFNodes = getvJDFNode(null, null, false);

         ArrayList vProcessNodes = new ArrayList();

         JDFNode[] processNodes = null;

         for (int i = 0; i < vJDFNodes.Count; i++)
         {
            JDFNode jdfNode = (JDFNode)vJDFNodes[i];

            if (jdfNode.isProcessNode())
            {
               vProcessNodes.Add(jdfNode);
            }
         }

         processNodes = new JDFNode[vProcessNodes.Count];

         vProcessNodes.CopyTo(processNodes);

         return processNodes;
      }

      ///   
      ///	 <summary> * Checks if this node is a simple process (including Combined) leaf node.
      ///	 *  </summary>
      ///	 * <returns> boolean - <code>true</code> if this is a process node. </returns>
      ///	 
      public virtual bool isProcessNode()
      {
         return !isGroupNode();
      }

      ///   
      ///	 <summary> * add an internal pipe (an input and an output link to an explicitly defined exchange resource)
      ///	 *  </summary>
      ///	 * <param name="resourceName"> The name of the reource to create </param>
      ///	 * <param name="indexOutput"> the CombinedProcessIndex of the output ResourceLink to the internal pipe </param>
      ///	 * <param name="indexInput"> the CombinedProcessIndex of the input ResourceLink to the internal pipe </param>
      ///	 * <returns> JDFResource - the newly created resource </returns>
      ///	 
      public virtual JDFResource addInternalPipe(string resourceName, int indexOutput, int indexInput)
      {
         if (EnumType.getEnum(getType()) != EnumType.Combined)
         {
            throw new JDFException("JDFNode.addInternalPipe: adding pipe to node that is not combined " + getType());
         }
         JDFResource r = addResource(resourceName, null, null, null, null, null, null);
         r.setPipeProtocol(JDFConstants.INTERNAL);

         JDFResourceLink rl = linkResource(r, EnumUsage.Input, null);
         rl.setPipeProtocol(JDFConstants.INTERNAL); // redundant but not harmful
         rl.setCombinedProcessIndex(new JDFIntegerList(indexInput));

         rl = linkResource(r, EnumUsage.Output, null);
         rl.setPipeProtocol(JDFConstants.INTERNAL); // redundant but not harmful
         rl.setCombinedProcessIndex(new JDFIntegerList(indexOutput));

         return r;
      }

      ///   
      ///	 <summary> * get a heuristic partidkey vector from the partitons of the linked resources
      ///	 *  </summary>
      ///	 * <param name="partMap"> the partmap to order. If not specified, use the output link
      ///	 *  </param>
      ///	 * <returns> the ordered vector of partIDKeys </returns>
      ///	 
      public virtual VString getPartIDKeys(JDFAttributeMap partMap)
      {
         VString matchingPartIDKeys = new VString();
         if ((partMap != null) && partMap.Count > 1)
         {
            JDFResourceLinkPool resourceLinkPool = getResourceLinkPool();
            if (resourceLinkPool != null)
            {
               VElement linkedResources = resourceLinkPool.getLinkedResources(null, null, null, false);
               int linkedResourcesSize = linkedResources.Count;
               for (int i = 0; i < linkedResourcesSize; i++)
               {
                  JDFResource resource = (JDFResource)linkedResources[i];
                  VString partIDKeys = resource.getPartIDKeys();
                  if (partIDKeys.Count >= partMap.Count && partIDKeys.ContainsAll(partMap.getKeys()))
                  {
                     matchingPartIDKeys = partIDKeys;
                     break;
                  }
               }
            }
         }
         else
         {
            if (partMap != null)
            {
               matchingPartIDKeys = partMap.getKeys();
            }
         }
         if (matchingPartIDKeys.IsEmpty())
         {
            // grab output link and partition nodeinfo accordingly
            VElement vRes = null;
            JDFResourceLinkPool rp = getResourceLinkPool();
            if (rp != null)
            {
               vRes = rp.getInOutLinks(EnumUsage.Output, false, null, null);
            }

            // get heuristic list of partidkeys from the output
            if (vRes != null && vRes.Count > 0)
            {
               JDFResource r = (JDFResource)vRes[0];
               JDFResource resRoot = r.getResourceRoot();
               if (resRoot != null)
               {
                  matchingPartIDKeys = resRoot.getPartIDKeys();
               }
            }
         }

         return matchingPartIDKeys;
      }

      ///   
      ///	 <summary> * prepare the nodeinfo for a list of parts, e.g. for a partitioned spawn if nodeinfo is prepartitioned it will
      ///	 * return a vector of all matching leaves
      ///	 *  </summary>
      ///	 * <param name="vSpawnParts"> the list of parts
      ///	 *  </param>
      ///	 * <returns> the vector of nodeinfo leaves </returns>
      ///	 
      public virtual VElement prepareNodeInfo(VJDFAttributeMap vSpawnParts)
      {
         // make sure we have a nodeinfo in case we have to merge stati
         JDFNodeInfo ni = getCreateNodeInfo();
         VElement vni = new VElement();

         if (ni.hasAttribute(AttributeName.CLASS, null, false))
         { // it is a 1.3 style resource
            JDFAttributeMap spawnPart = new JDFAttributeMap();
            if (vSpawnParts != null && vSpawnParts.Count > 0)
            {
               for (int i = 0; i < vSpawnParts.Count; i++)
               {
                  if (vSpawnParts[i].Count > spawnPart.Count)
                  {
                     spawnPart = vSpawnParts[i];
                  }
               }

               VString partVector = getPartIDKeys(spawnPart);
               if (getStatus() != EnumNodeStatus.Part)
               {
                  ni.setAttribute(AttributeName.NODESTATUS, getAttribute(AttributeName.STATUS));
                  this.setStatus(EnumNodeStatus.Part);
               }

               for (int i = 0; i < vSpawnParts.Count; i++)
               {
                  // in case we spawn a subset, try to get the superset list
                  // first
                  VElement vLeaves = ni.getPartitionVector(vSpawnParts[i], EnumPartUsage.Explicit);
                  // no preexisting leaves - create them
                  if (vLeaves.IsEmpty())
                  {
                     JDFNodeInfo niLeaf = (JDFNodeInfo)ni.getCreatePartition(vSpawnParts[i], partVector);
                     niLeaf.setAttribute(AttributeName.NODESTATUS, "Waiting");
                     vni.Add(niLeaf);
                  }
                  else
                  // we have existing leaves, use them
                  {
                     for (int j = 0; j < vLeaves.Count; j++)
                     {
                        vni.Add(vLeaves[j]);
                     }
                  }
               }
            }
            else
            // not partitioned
            {
               vni.Add(ni); // simply return the 1.3 resource
            }
         }
         else
         {
            vni.Add(ni); // simply return the 1.2 element
         }
         vni.unify();
         return vni;
      }

      ///   
      ///	 <summary> * getLinks - get the links matching mLinkAtt out of the resource link pool
      ///	 *  </summary>
      ///	 * <param name="linkName"> the name of the link including or excluding the "Link", If it is omitted, it will be added </param>
      ///	 * <param name="mLinkAtt"> the attributes to search for </param>
      ///	 * <param name="linkNS"> the namespace of the link
      ///	 *  </param>
      ///	 * <returns> VElement - all elements matching the condition mLinkAtt
      ///	 * @default getLinks(null,null,null) </returns>
      ///	 * @deprecated - use getResourceLinks 
      ///	 
      [Obsolete("- use getResourceLinks")]
      public virtual VElement getLinks(string linkName, JDFAttributeMap mLinkAtt, string linkNS)
      {
         return getResourceLinks(linkName, mLinkAtt, linkNS);
      }

      ///   
      ///	 <summary> * getLinks - get the links matching mLinkAtt out of the resource link pool
      ///	 *  </summary>
      ///	 * <param name="linkName"> the name of the link including or excluding the "Link", If it is omitted, it will be added </param>
      ///	 * <param name="mLinkAtt"> the attributes to search for </param>
      ///	 * <param name="linkNS"> the namespace of the link
      ///	 *  </param>
      ///	 * <returns> VElement - all elements matching the condition mLinkAtt,
      ///	 * @default getLinks(null,null,null) </returns>
      ///	 
      public virtual VElement getResourceLinks(string linkName, JDFAttributeMap mLinkAtt, string linkNS)
      {
         string linkNameLocal = linkName;

         JDFResourceLinkPool rlp = getResourceLinkPool();
         if (rlp == null)
         {
            return null;
         }
         if (linkNameLocal != null && !linkNameLocal.EndsWith(JDFConstants.LINK))
         {
            linkNameLocal += JDFConstants.LINK;
         }

         return rlp.getPoolChildren(linkNameLocal, mLinkAtt, linkNS);
      }

      ///   
      ///	 <summary> * getLink - get the n'th link matching mLinkAtt out of the resource link pool
      ///	 *  </summary>
      ///	 * <param name="index"> the index of the matching link </param>
      ///	 * <param name="linkName"> the name of the link including or excluding the "Link". If it is omitted, it will be added. </param>
      ///	 * <param name="mLinkAtt"> the attributes to search for </param>
      ///	 * <param name="linkNS"> the namespace of the link
      ///	 *  </param>
      ///	 * <returns> JDFResourceLink - the ResourceLink matching the condition mLinkAtt
      ///	 * @default getLinks(null,null,null) </returns>
      ///	 
      public virtual JDFResourceLink getLink(int index, string linkName, JDFAttributeMap mLinkAtt, string linkNS)
      {
         string linkNameLocal = linkName;

         JDFResourceLinkPool rlp = getResourceLinkPool();
         if (rlp == null)
         {
            return null;
         }
         if (linkNameLocal != null && !linkNameLocal.EndsWith(JDFConstants.LINK))
         {
            linkNameLocal += JDFConstants.LINK;
         }

         return rlp.getPoolChild(index, linkNameLocal, mLinkAtt, linkNS);
      }

      ///   
      ///	 <summary> * Gets all elements with name linkName, which contain resource links that point to this resource
      ///	 *  </summary>
      ///	 * <param name="linkName"> defaults to any </param>
      ///	 * <param name="nameSpaceURI"> attribute namespace you are searching in
      ///	 *  </param>
      ///	 * <returns> VElement vector of all found elements </returns>
      ///	 * @deprecated this routine does not belong here at all!
      ///	 * @default getLinks(null, null) 
      ///	 
      [Obsolete("this routine does not belong here at all!")]
      public virtual VElement getLinks(string linkName, string nameSpaceURI)
      {
         JDFAttributeMap m = new JDFAttributeMap(AttributeName.RREF, getID());
         return getDocRoot().getChildrenByTagName(linkName, nameSpaceURI, m, false, false, 0);
      }

      ///   
      ///	 <summary> * sorts all elements alphabetically also recurses into the resourcepool and the sub JDF Node NO other sub-elements
      ///	 * are sorted
      ///	 *  </summary>
      ///	 * <seealso cref= org.cip4.jdflib.core.KElement#sortChildren() </seealso>
      ///	 
      public override void sortChildren()
      {
         base.sortChildren(); // KElement.sortChildren is NOT recursive
         JDFResourcePool rp = getResourcePool();
         if (rp != null)
         {
            rp.sortChildren();
         }
         VElement vNode = getvJDFNode(null, null, true);
         for (int i = 0; i < vNode.Count; i++)
         {
            vNode.item(i).sortChildren();
         }
      }

      ///   
      ///	 <summary> * returns all subnodes of this (including this) that match ni
      ///	 *  </summary>
      ///	 * <param name="ni"> the Identifier to match
      ///	 * @return </param>
      ///	 
      public virtual VElement getMatchingNodes(NodeIdentifier ni)
      {
         VElement v = getvJDFNode(null, null, false);
         if (ni == null)
            return v;

         int siz = 0;
         if (v != null)
         {
            siz = v.Count;
            for (int i = siz - 1; i >= 0; i--)
            {
               JDFNode n = (JDFNode)v[i];
               if (!n.getIdentifier().matches(ni))
                  v.RemoveAt(i);
            }
         }

         siz = v == null ? 0 : v.Count;
         return siz == 0 ? null : v;
      }

      ///   
      ///	 <summary> * links all output resources of thePreviousNode as inputs to this
      ///	 *  </summary>
      ///	 * <param name="thePreviousNode"> </param>
      ///	 
      public virtual void linkOutputs(JDFNode thePreviousNode)
      {
         if (thePreviousNode == null)
            return;
         JDFResourceLinkPool resourceLinkPool = thePreviousNode.getResourceLinkPool();
         if (resourceLinkPool == null)
            return;
         VElement v = resourceLinkPool.getInOutLinks(EnumUsage.Output, true, null, null);
         JDFResourceLinkPool rlp = getCreateResourceLinkPool();
         for (int i = 0; i < v.Count; i++)
         {
            JDFResourceLink rl0 = (JDFResourceLink)v[i];
            JDFResourceLink rl = (JDFResourceLink)rlp.getChildWithAttribute(null, AttributeName.RREF, null, rl0.getrRef(), 0, true);
            if (rl == null)
            {
               JDFResource r = rl0.getLinkRoot();
               rl = linkResource(r, EnumUsage.Input, rl0.getEnumProcessUsage());
               rl.removeAttribute(AttributeName.COMBINEDPROCESSINDEX);
            }
         }
      }

      ///   
      ///	 <summary> * synchronize the amounts of a gray box parent with the expanded jdfnode </summary>
      ///	 
      public virtual void synchParentAmounts()
      {
         JDFNode parent = getParentJDF();
         if (parent == null)
            return;
         JDFResourceLinkPool parentPool = parent.getResourceLinkPool();
         JDFResourceLinkPool linkPool = getResourceLinkPool();
         if (parentPool == null || linkPool == null)
            return;
         VElement links = linkPool.getPoolChildren(null, null, null);
         if (links == null)
            return;
         for (int i = 0; i < links.Count; i++)
         {
            JDFResourceLink link = (JDFResourceLink)links[i];
            JDFResourceLink parentLink = (JDFResourceLink)parentPool.getChildWithAttribute(link.LocalName, AttributeName.RREF, null, link.getrRef(), 0, true);
            if (parentLink != null)
            {
               VJDFAttributeMap vParts = link.getPartMapVector();
               if (vParts == null)
               {
                  vParts = new VJDFAttributeMap();
                  vParts.Add(null);
               }
               for (int j = 0; j < vParts.Count; j++)
               {
                  JDFAmountPool amountPool = link.getAmountPool();
                  if (amountPool != null)
                  {
                     JDFAmountPool parentAmountPool = parentLink.getCreateAmountPool();
                     VElement parts = amountPool.getMatchingPartAmountVector(vParts[j]);
                     if (parts != null)
                     {
                        int pSiz = parts.Count;
                        for (int k = 0; k < pSiz; k++)
                        {
                           JDFPartAmount pa = (JDFPartAmount)parts[k];
                           if (pa.hasAttribute(AttributeName.ACTUALAMOUNT))
                           {
                              VJDFAttributeMap vPAMap = pa.getPartMapVector();
                              JDFPartAmount parentPA = parentAmountPool.getCreatePartAmount(vPAMap);
                              parentPA.copyAttribute(AttributeName.ACTUALAMOUNT, pa, null, null, null);
                           }
                        }
                     }
                  }
                  else
                  {
                     parentLink.copyAttribute(AttributeName.ACTUALAMOUNT, link, null, null, null);
                  }
                  // if(parentLink)
               }
            }
         }
      }

      ///   
      ///	 <summary> * ensure that an auditpool with a created audit exists - base ICS fodder </summary>
      ///	 
      private void ensureCreated()
      {
         JDFAuditPool ap = getCreateAuditPool();
         ap.ensureCreated();
      }


      ///   
      ///	 <summary> * make any combined or single type process to a gray box
      ///	 *  </summary>
      ///	 * <param name="bExpand"> if true, create a parent gray box that wraps this, else simply rename this </param>
      ///	 
      public virtual void toGrayBox(bool bExpand)
      {
         EnumType t = getEnumType();
         string typeString = getType();

         if (EnumType.ProcessGroup.Equals(t) || EnumType.Product.Equals(t))
            return;
         if (!EnumType.Combined.Equals(t))
         {
            renameAttribute(AttributeName.TYPE, AttributeName.TYPES, null, null);
         }

         setType(EnumType.ProcessGroup);
         if (bExpand)
         {
            JDFNode child = addJDFNode(typeString);
            string jobPart = getJobPartID(false);
            child.setJobID(jobPart);
            setJobPartID("pg." + jobPart);
            child.copyElement(getResourceLinkPool(), null);
            removeAttribute(AttributeName.TYPES);
            JDFAuditPool ap = child.getCreateAuditPool();
            ap.ensureCreated();
            JDFCreated c = (JDFCreated)ap.getAudit(0, EnumAuditType.Created, null, null);
            if (c == null)
               c = ap.addCreated(null, null);
            c.setDescriptiveName("automatically generated by toGrayBox");
         }
      }

      ///   
      ///	 * <seealso cref= org.cip4.jdflib.ifaces.INodeIdentifiable#setIdentifier(org.cip4.jdflib.node.JDFNode.NodeIdentifier) </seealso>
      ///	 * <param name="ni"> </param>
      ///	 
      public virtual void setIdentifier(NodeIdentifier ni)
      {
         NodeIdentifier niLocal = ni;

         if (niLocal == null)
            niLocal = new NodeIdentifier();

         setJobID(niLocal.getJobID());
         setJobPartID(niLocal.getJobPartID());
         setPartMapVector(niLocal.getPartMapVector());
      }
   }
}
