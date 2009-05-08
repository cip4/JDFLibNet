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
 * Copyright (c) 2003 Heidelberger Druckmaschinen AG, All Rights Reserved.
 * ElementName.cs
 * All kind of Element names used in the JDFLib and outside of it
 */

namespace org.cip4.jdflib.core
{
   using System;

   public sealed class ElementName
   {
      private ElementName()
      {
         // to prohibit instantiation of this constant only class
      }

      public const string ACCEPTED = "Accepted";
      public const string ACKNOWLEDGE = "Acknowledge";
      public const string ACTION = "Action";
      public const string ACTIONPOOL = "ActionPool";
      public const string ADDED = "Added";
      public const string ADDRESS = "Address";
      public const string ADHESIVEBINDING = "AdhesiveBinding";
      public const string ADHESIVEBINDINGPARAMS = "AdhesiveBindingParams";
      public const string ADVANCEDPARAMS = "AdvancedParams";
      public const string AMOUNT = "Amount";
      public const string AMOUNTPOOL = "AmountPool";
      public const string ANCESTOR = "Ancestor";
      public const string ANCESTORPOOL = "AncestorPool";
      public const string AND = "and";
      public const string APPROVAL = "Approval";
      public const string APPROVALDETAILS = "ApprovalDetails";
      public const string APPROVALPARAMS = "ApprovalParams";
      public const string APPROVALPERSON = "ApprovalPerson";
      public const string APPROVALSUCCESS = "ApprovalSuccess";
      public const string ARGUMENTVALUE = "ArgumentValue";
      public const string ARTDELIVERY = "ArtDelivery";
      public const string ARTDELIVERYDATE = "ArtDeliveryDate";
      public const string ARTDELIVERYDURATION = "ArtDeliveryDuration";
      public const string ARTDELIVERYINTENT = "ArtDeliveryIntent";
      public const string ARTDELIVERYTYPE = "ArtDeliveryType";
      public const string ARTHANDLING = "ArtHandling";
      public const string ASSEMBLY = "Assembly";
      public const string ASSEMBLYSECTION = "AssemblySection";
      public const string ASSETCOLLECTION = "AssetCollection";
      public const string ASSETLISTCREATION = "AssetListCreation";
      public const string ASSETLISTCREATIONPARAMS = "AssetListCreationParams";
      public const string AUDIT = "Audit";
      public const string AUDITPOOL = "AuditPool";
      public const string AUTOMATEDOVERPRINTPARAMS = "AutomatedOverPrintParams";

      public const string BACKCOATINGS = "BackCoatings";
      public const string BACKCOVERCOLOR = "BackCoverColor";
      public const string BAND = "Band";
      public const string BARCODE = "Barcode";
      public const string BARCODEDETAILS = "BarcodeDetails";
      public const string BARCODECOMPPARAMS = "BarcodeCompParams";
      public const string BARCODEPRODUCTIONPARAMS = "BarcodeProductionParams";
      public const string BARCODEREPROPARAMS = "BarcodeReproParams";
      public const string BASICPREFLIGHTTEST = "BasicPreflightTest";
      public const string BENDINGPARAMS = "BendingParams";
      public const string BINDERBRAND = "BinderBrand";
      public const string BINDERYSIGNATURE = "BinderySignature";
      public const string BINDERMATERIAL = "BinderMaterial";
      public const string BINDINGCOLOR = "BindingColor";
      public const string BINDINGINTENT = "BindingIntent";
      public const string BINDINGLENGTH = "BindingLength";
      public const string BINDINGQUALITYMEASUREMENT = "BindingQualityMeasurement";
      public const string BINDINGQUALITYPARAMS = "BindingQualityParams";
      public const string BINDINGSIDE = "BindingSide";
      public const string BINDINGTYPE = "BindingType";
      public const string BINDITEM = "BindItem";
      public const string BINDLIST = "BindList";
      public const string BLOCKPREPARATION = "BlockPreparation";
      public const string BLOCKPREPARATIONPARAMS = "BlockPreparationParams";
      public const string BLOCKTHREADSEWING = "BlockThreadSewing";
      public const string BOOLEANEVALUATION = "BooleanEvaluation";
      public const string BOOLEANSTATE = "BooleanState";
      public const string BOOKCASE = "BookCase";
      public const string BOXAPPLICATION = "BoxApplication";
      public const string BOXARGUMENT = "BoxArgument";
      public const string BOXEDQUANTITY = "BoxedQuantity";
      public const string BOXFOLDACTION = "BoxFoldAction";
      public const string BOXFOLDINGPARAMS = "BoxFoldingParams";
      public const string BOXPACKING = "BoxPacking";
      public const string BOXPACKINGPARAMS = "BoxPackingParams";
      public const string BOXSHAPE = "BoxShape";
      public const string BOXTOBOXDIFFERENCE = "BoxToBoxDifference";
      public const string BRANDNAME = "BrandName";
      public const string BRIGHTNESS = "Brightness";
      public const string BUFFER = "Buffer";
      public const string BUFFERPARAMS = "BufferParams";
      public const string BUNDLE = "Bundle";
      public const string BUNDLEITEM = "BundleItem";
      public const string BUNDLING = "Bundling";
      public const string BUNDLINGPARAMS = "BundlingParams";
      public const string BUSINESSINFO = "BusinessInfo";
      public const string BUYERSUPPLIED = "BuyerSupplied";
      public const string BYTEMAP = "ByteMap";

      public const string CALL = "call";
      public const string CARTONMAXWEIGHT = "CartonMaxWeight";
      public const string CARTONQUANTITY = "CartonQuantity";
      public const string CARTONSHAPE = "CartonShape";
      public const string CARTONSTRENGTH = "CartonStrength";
      public const string CASEMAKING = "CaseMaking";
      public const string CASEMAKINGPARAMS = "CaseMakingParams";
      public const string CASINGIN = "CasingIn";
      public const string CASINGINPARAMS = "CasingInParams";
      public const string CCITTFAXPARAMS = "CCITTFaxParams";
      public const string CHANGEDATTRIBUTE = "ChangedAttribute";
      public const string CHANGEDPATH = "ChangedPath";
      public const string CHANNELBINDING = "ChannelBinding";
      public const string CHANNELBINDINGPARAMS = "ChannelBindingParams";
      public const string CHANNELBRAND = "ChannelBrand";
      public const string CHOICE = "choice";
      public const string CIELABMEASURINGFIELD = "CIELABMeasuringField";
      public const string CIRCULATION = "Circulation";
      public const string COATINGS = "Coatings";
      public const string COILBINDING = "CoilBinding";
      public const string COILBINDINGPARAMS = "CoilBindingParams";
      public const string COILBRAND = "CoilBrand";
      public const string COILMATERIAL = "CoilMaterial";
      public const string COLLECTING = "Collecting";
      public const string COLLATINGITEM = "CollatingItem";
      public const string COLLECTINGPARAMS = "CollectingParams";
      public const string COLOR = "Color";
      public const string COLORANTALIAS = "ColorantAlias";
      public const string COLORANTCONTROL = "ColorantControl";
      public const string COLORANTORDER = "ColorantOrder";
      public const string COLORANTPARAMS = "ColorantParams";
      public const string COLORANTZONEDETAILS = "ColorantZoneDetails";
      public const string COLORCONTROLSTRIP = "ColorControlStrip";
      public const string COLORCORRECTION = "ColorCorrection";
      public const string COLORCORRECTIONOP = "ColorCorrectionOp";
      public const string COLORCORRECTIONPARAMS = "ColorCorrectionParams";
      public const string COLORICCSTANDARD = "ColorICCStandard";
      public const string COLORINTENT = "ColorIntent";
      public const string COLORMEASUREMENTCONDITIONS = "ColorMeasurementConditions";
      public const string COLORNAME = "ColorName";
      public const string COLORPOOL = "ColorPool";
      public const string COLORSCONSTRAINTSPOOL = "ColorsConstraintsPool";
      /// @deprecated  
      [Obsolete]
      public const string COLORSPACECONVERSION = "ColorSpaceConversion";
      public const string COLORSPACECONVERSIONOP = "ColorSpaceConversionOp";
      public const string COLORSPACECONVERSIONPARAMS = "ColorSpaceConversionParams";
      public const string COLORSPACESUBSTITUTE = "ColorSpaceSubstitute";
      public const string COLORSRESULTSPOOL = "ColorsResultsPool";
      public const string COLORSTANDARD = "ColorStandard";
      public const string COLORSUSED = "ColorsUsed";
      public const string COLORTYPE = "ColorType";
      public const string COMBBRAND = "CombBrand";
      ///    @deprecated use EnumType.xxx.getName()  
      ///	 
      [Obsolete("use EnumType.xxx.getName()")]
      public const string COMBINE = "Combine";
      ///    @deprecated use EnumType.xxx.getName()  
      ///	 
      [Obsolete("use EnumType.xxx.getName()")]
      public const string COMBINED = "Combined";
      public const string COMCHANNEL = "ComChannel";
      public const string COMMAND = "Command";
      public const string COMMENT = "Comment";
      public const string COMPANY = "Company";
      public const string COMPONENT = "Component";
      public const string CONSTRAINTVALUE = "ConstraintValue";
      public const string CONTACT = "Contact";
      /// @deprecated use EnumType.xxx.getName()  
      [Obsolete("use EnumType.xxx.getName()")]
      public const string CONTACTCOPYING = "ContactCopying";
      public const string CONTACTCOPYPARAMS = "ContactCopyParams";
      public const string CONTAINER = "Container";
      public const string CONTENTDATA = "ContentData";
      public const string CONTENTLIST = "ContentList";
      public const string CONTENTOBJECT = "ContentObject";
      public const string CONTONECALIBRATION = "ContoneCalibration";
      /// @deprecated  
      [Obsolete]
      public const string CONVENTIONALPRINTING = "ConventionalPrinting";
      public const string CONVENTIONALPRINTINGPARAMS = "ConventionalPrintingParams";
      public const string COSTCENTER = "CostCenter";
      public const string COUNTERRESET = "CounterReset";
      public const string COVER = "Cover";
      public const string COVERAGE = "Coverage";
      /// @deprecated  
      [Obsolete]
      public const string COVERAPPLICATION = "CoverApplication";
      public const string COVERAPPLICATIONPARAMS = "CoverApplicationParams";
      public const string COVERCOLOR = "CoverColor";
      public const string COVERSTYLE = "CoverStyle";
      public const string CREASE = "Crease";
      public const string CREASING = "Creasing";
      public const string CREASINGPARAMS = "CreasingParams";
      public const string CREATED = "Created";
      public const string CREATELINK = "CreateLink";
      public const string CREATERESOURCE = "CreateResource";
      public const string CREDITCARD = "CreditCard";
      public const string CUSTOMERINFO = "CustomerInfo";
      public const string CUSTOMERMESSAGE = "CustomerMessage";
      public const string CUT = "Cut";
      public const string CUTBLOCK = "CutBlock";
      public const string CUTMARK = "CutMark";
      public const string CUTTING = "Cutting";
      public const string CUTTINGPARAMS = "CuttingParams";
      public const string CUTTYPE = "CutType";
      public const string CYLINDERLAYOUT = "CylinderLayout";
      public const string CYLINDERLAYOUTPREPARATIONPARAMS = "CylinderLayoutPreparationParams";
      public const string CYLINDERPOSITION = "CylinderPosition";

      public const string DATETIMEEVALUATION = "DateTimeEvaluation";
      public const string DATETIMESTATE = "DateTimeState";
      public const string DBDOCTEMPLATELAYOUT = "DBDocTemplateLayout";
      public const string DBMERGEPARAMS = "DBMergeParams";
      public const string DBRULES = "DBRules";
      public const string DBSCHEMA = "DBSchema";
      public const string DBSELECTION = "DBSelection";
      public const string DBTEMPLATEMERGING = "DBTemplateMerging";
      public const string DCTPARAMS = "DCTParams";
      public const string DELETED = "Deleted";
      public const string DELIVERY = "Delivery";
      public const string DELIVERYCHARGE = "DeliveryCharge";
      public const string DELIVERYINTENT = "DeliveryIntent";
      public const string DELIVERYPARAMS = "DeliveryParams";
      public const string DENSITYMEASURINGFIELD = "DensityMeasuringField";
      public const string DEPENDENCIES = "Dependencies";
      public const string DEVCAP = "DevCap";
      public const string DEVCAPPOOL = "DevCapPool";
      public const string DEVCAPS = "DevCaps";
      public const string DEVELOPINGPARAMS = "DevelopingParams";
      public const string DEVICE = "Device";
      public const string DEVICECAP = "DeviceCap";
      public const string DEVICECOLORANTORDER = "DeviceColorantOrder";
      public const string DEVICEFILTER = "DeviceFilter";
      public const string DEVICEINFO = "DeviceInfo";
      public const string DEVICELIST = "DeviceList";
      public const string DEVICEMARK = "DeviceMark";
      public const string DEVICENCOLOR = "DeviceNColor";
      public const string DEVICENSPACE = "DeviceNSpace";
      public const string DIELAYOUT = "DieLayout";
      ///   
      ///	 * @deprecated use EnumType.Delivery.getName(); 
      ///	 
      [Obsolete("use EnumType.Delivery.getName();")]
      public const string DIGITALDELIVERY = "DigitalDelivery";
      public const string DIGITALDELIVERYPARAMS = "DigitalDeliveryParams";
      public const string DIGITALMEDIA = "DigitalMedia";
      ///   
      ///	 * @deprecated use EnumType.DigitalPrinting.getName(); 
      ///	 
      [Obsolete("use EnumType.DigitalPrinting.getName();")]
      public const string DIGITALPRINTING = "DigitalPrinting";
      public const string DIGITALPRINTINGPARAMS = "DigitalPrintingParams";
      public const string DIMENSIONS = "Dimensions";
      public const string DIRECTION = "Direction";
      public const string DISJOINTING = "Disjointing";
      public const string DISPLAYGROUP = "DisplayGroup";
      public const string DISPLAYGROUPPOOL = "DisplayGroupPool";
      public const string DISPOSITION = "Disposition";
      public const string DIVIDING = "Dividing";
      public const string DIVIDINGPARAMS = "DividingParams";
      public const string DOCUMENTCONSTRAINTSPOOL = "DocumentConstraintsPool";
      public const string DOCUMENTRESULTSPOOL = "DocumentResultsPool";
      public const string DOTSIZE = "DotSize";
      public const string DROP = "Drop";
      public const string DROPINTENT = "DropIntent";
      public const string DROPITEM = "DropItem";
      public const string DROPITEMINTENT = "DropItemIntent";
      public const string DURATIONEVALUATION = "DurationEvaluation";
      public const string DURATIONSTATE = "DurationState";
      public const string DYNAMICFIELD = "DynamicField";
      public const string DYNAMICINPUT = "DynamicInput";
      public const string EARLIEST = "Earliest";
      public const string EARLIESTDURATION = "EarliestDuration";
      public const string EDGEANGLE = "EdgeAngle";
      public const string EDGEGLUE = "EdgeGlue";
      public const string EDGEGLUING = "EdgeGluing";
      public const string EDGESHAPE = "EdgeShape";
      public const string ELEMENTCOLORPARAMS = "ElementColorParams";
      public const string EMBOSS = "Emboss";
      public const string EMBOSSING = "Embossing";
      public const string EMBOSSINGINTENT = "EmbossingIntent";
      public const string EMBOSSINGITEM = "EmbossingItem";
      public const string EMBOSSINGPARAMS = "EmbossingParams";
      public const string EMBOSSINGTYPE = "EmbossingType";
      public const string EMPLOYEE = "Employee";
      public const string EMPLOYEEDEF = "EmployeeDef";
      public const string ENDSHEET = "EndSheet";
      public const string ENDSHEETGLUING = "EndSheetGluing";
      public const string ENDSHEETGLUINGPARAMS = "EndSheetGluingParams";
      public const string ENDSHEETS = "EndSheets";
      public const string ENUMERATIONEVALUATION = "EnumerationEvaluation";
      public const string ENUMERATIONSTATE = "EnumerationState";
      public const string ERROR = "Error";
      public const string ERRORDATA = "ErrorData";
      public const string EVENT = "Event";
      public const string EXPOSEDMEDIA = "ExposedMedia";
      public const string EXTENDEDADDRESS = "ExtendedAddress";
      public const string EXTERNALIMPOSITIONTEMPLATE = "ExternalImpositionTemplate";
      public const string EXTRAVALUES = "ExtraValues";
      public const string FCNKEY = "FCNKey";
      public const string FEATUREATTRIBUTE = "FeatureAttribute";
      public const string FEATUREPOOL = "FeaturePool";
      public const string FEEDER = "Feeder";
      public const string FEEDERQUALITYPARAMS = "FeederQualityParams";
      public const string FEEDING = "Feeding";
      public const string FEEDINGPARAMS = "FeedingParams";
      public const string FILEALIAS = "FileAlias";
      public const string FILESPEC = "FileSpec";
      public const string FILESPECOUT = "FileSpecOut";
      public const string FILETYPECONSTRAINTSPOOL = "FileTypeConstraintsPool";
      public const string FILETYPERESULTSPOOL = "FileTypeResultsPool";
      public const string FILMTOPLATECOPYING = "FilmToPlateCopying";
      public const string FINISHEDDIMENSIONS = "FinishedDimensions";
      public const string FINISHEDGRAINDIRECTION = "FinishedGrainDirection";
      public const string FITPOLICY = "FitPolicy";
      public const string FLATEPARAMS = "FlateParams";
      public const string FLUSHEDRESOURCES = "FlushedResources";
      public const string FLUSHQUEUEINFO = "FlushQueueInfo";
      public const string FLUSHQUEUEPARAMS = "FlushQueueParams";
      public const string FLUSHRESOURCEPARAMS = "FlushResourceParams";
      public const string FOILCOLOR = "FoilColor";
      public const string FOLD = "Fold";
      public const string FOLDERPRODUCTION = "FolderProduction";
      public const string FOLDERSUPERSTRUCTUREWEBPATH = "FolderSuperStructureWebPath";
      public const string FOLDING = "Folding";
      public const string FOLDINGCATALOG = "FoldingCatalog";
      public const string FOLDINGINTENT = "FoldingIntent";
      public const string FOLDINGPARAMS = "FoldingParams";
      public const string FOLDINGWIDTH = "FoldingWidth";
      public const string FOLDINGWIDTHBACK = "FoldingWidthBack";
      public const string FOLDOPERATION = "FoldOperation";
      public const string FONTPARAMS = "FontParams";
      public const string FONTPOLICY = "FontPolicy";
      public const string FONTSCONSTRAINTSPOOL = "FontsConstraintsPool";
      public const string FONTSRESULTSPOOL = "FontsResultsPool";
      public const string FORMATCONVERSION = "FormatConversion";
      public const string FORMATCONVERSIONPARAMS = "FormatConversionParams";
      public const string FREQUENCY = "Frequency";
      public const string FREQUENCYSELECTION = "FrequencySelection";
      public const string FRONTCOATINGS = "FrontCoatings";

      public const string GANGCMDFILTER = "GangCmdFilter";
      public const string GANGINFO = "GangInfo";
      public const string GANGQUFILTER = "GangQuFilter";
      public const string GATHERING = "Gathering";
      public const string GATHERINGPARAMS = "GatheringParams";
      public const string GENERALID = "GeneralID";
      public const string GLUE = "Glue";
      public const string GLUEAPPLICATION = "GlueApplication";
      public const string GLUELINE = "GlueLine";
      public const string GLUEPROCEDURE = "GlueProcedure";
      public const string GLUETYPE = "GlueType";
      public const string GLUING = "Gluing";
      public const string GLUINGPARAMS = "GluingParams";
      public const string GRADE = "Grade";
      public const string GRAINDIRECTION = "GrainDirection";
      public const string HALFTONE = "HalfTone";
      public const string HARDCOVERBINDING = "HardCoverBinding";
      public const string HEADBANDAPPLICATION = "HeadBandApplication";
      public const string HEADBANDAPPLICATIONPARAMS = "HeadBandApplicationParams";
      public const string HEADBANDCOLOR = "HeadBandColor";
      public const string HEADBANDS = "HeadBands";
      public const string HEIGHT = "Height";
      public const string HOLE = "Hole";
      public const string HOLECOUNT = "HoleCount";
      public const string HOLELINE = "HoleLine";
      public const string HOLELIST = "HoleList";
      public const string HOLEMAKING = "HoleMaking";
      public const string HOLEMAKINGINTENT = "HoleMakingIntent";
      public const string HOLEMAKINGPARAMS = "HoleMakingParams";
      public const string HOLETYPE = "HoleType";
      public const string ICON = "Icon";
      public const string ICONLIST = "IconList";
      public const string IDENTICAL = "Identical";
      public const string IDENTIFICATIONFIELD = "IdentificationField";
      public const string IDINFO = "IDInfo";
      public const string IDPCOVER = "IDPCover";
      public const string IDPFINISHING = "IDPFinishing";
      public const string IDPFOLDING = "IDPFolding";
      public const string IDPHOLEMAKING = "IDPHoleMaking";
      public const string IDPIMAGESHIFT = "IDPImageShift";
      public const string IDPJOBSHEET = "IDPJobSheet";
      public const string IDPLAYOUT = "IDPLayout";
      public const string IDPRINTING = "IDPrinting";
      public const string IDPRINTINGPARAMS = "IDPrintingParams";
      public const string IDPSTITCHING = "IDPStitching";
      public const string IDPTRIMMING = "IDPTrimming";
      public const string IMAGECOMPRESSION = "ImageCompression";
      public const string IMAGECOMPRESSIONPARAMS = "ImageCompressionParams";
      public const string IMAGEREPLACEMENT = "ImageReplacement";
      public const string IMAGEREPLACEMENTPARAMS = "ImageReplacementParams";
      public const string IMAGESCONSTRAINTSPOOL = "ImagesConstraintsPool";
      public const string IMAGESETTERPARAMS = "ImageSetterParams";
      public const string IMAGESETTING = "ImageSetting";
      public const string IMAGESHIFT = "ImageShift";
      public const string IMAGESIZE = "ImageSize";
      public const string IMAGESRESULTSPOOL = "ImagesResultsPool";
      public const string IMAGESTRATEGY = "ImageStrategy";
      public const string IMPOSITION = "Imposition";
      public const string INK = "Ink";
      public const string INKMANUFACTURER = "InkManufacturer";
      public const string INKZONECALCULATION = "InkZoneCalculation";
      public const string INKZONECALCULATIONPARAMS = "InkZoneCalculationParams";
      public const string INKZONEPROFILE = "InkZoneProfile";
      public const string INSERT = "Insert";
      public const string INSERTING = "Inserting";
      public const string INSERTINGINTENT = "InsertingIntent";
      public const string INSERTINGPARAMS = "InsertingParams";
      public const string INSERTLIST = "InsertList";
      public const string INSERTSHEET = "InsertSheet";
      public const string INTEGEREVALUATION = "IntegerEvaluation";
      public const string INTEGERSTATE = "IntegerState";
      public const string INTENTRESOURCE = "IntentResource";
      public const string INTERPRETEDPDLDATA = "InterpretedPDLData";
      public const string INTERPRETING = "Interpreting";
      public const string INTERPRETINGPARAMS = "InterpretingParams";
      public const string ISPRESENTEVALUATION = "IsPresentEvaluation";
      public const string ISSUEDATE = "IssueDate";
      public const string ISSUENAME = "IssueName";
      public const string ISSUETYPE = "IssueType";

      public const string JACKET = "Jacket";
      public const string JACKETFOLDINGWIDTH = "JacketFoldingWidth";
      public const string JACKETING = "Jacketing";
      public const string JACKETINGPARAMS = "JacketingParams";
      public const string JAPANBIND = "JapanBind";
      public const string JBIG2PARAMS = "JBIG2Params";
      public const string JDF = "JDF";
      public const string JDFCONTROLLER = "JDFController";
      public const string JDFSERVICE = "JDFService";
      public const string JDFSJDFCONTROLLERERVICE = "JDFService";
      public const string JMF = "JMF";
      public const string JOBFIELD = "JobField";
      public const string JOBPHASE = "JobPhase";
      public const string JOBSHEET = "JobSheet";
      public const string JPEG2000PARAMS = "JPEG2000Params";
      public const string KNOWNMSGQUPARAMS = "KnownMsgQuParams";
      public const string LABELING = "Labeling";
      public const string LABELINGPARAMS = "LabelingParams";
      public const string LAMINATED = "Laminated";
      public const string LAMINATING = "Laminating";
      public const string LAMINATINGINTENT = "LaminatingIntent";
      public const string LAMINATINGPARAMS = "LaminatingParams";
      public const string LAYERDETAILS = "LayerDetails";
      public const string LAYERLIST = "LayerList";
      public const string LAYOUT = "Layout";
      public const string LAYOUTELEMENT = "LayoutElement";
      public const string LAYOUTELEMENTPART = "LayoutElementPart";
      public const string LAYOUTELEMENTPRODUCTION = "LayoutElementProduction";
      public const string LAYOUTELEMENTPRODUCTIONPARAMS = "LayoutElementProductionParams";
      public const string LAYOUTINTENT = "LayoutIntent";
      public const string LAYOUTPREPARATION = "LayoutPreparation";
      public const string LAYOUTPREPARATIONPARAMS = "LayoutPreparationParams";
      public const string LEVEL = "Level";
      public const string LOC = "Loc";
      public const string LOCATION = "Location";
      public const string LONGFOLD = "LongFold";
      public const string LONGGLUE = "LongGlue";
      public const string LONGITUDINALRIBBONOPERATIONPARAMS = "LongitudinalRibbonOperationParams";
      public const string LONGITUDINALRIBBONOPERATIONS = "LongitudinalRibbonOperations";
      public const string LONGPERFORATE = "LongPerforate";
      public const string LONGSLIT = "LongSlit";
      public const string LOT = "Lot";
      public const string LZWPARAMS = "LZWParams";

      public const string MACRO = "macro";
      public const string MACROPOOL = "MacroPool";
      public const string MANUALLABOR = "ManualLabor";
      public const string MANUALLABORPARAMS = "ManualLaborParams";
      public const string MARKOBJECT = "MarkObject";
      public const string MATERIAL = "Material";
      public const string MATRIXEVALUATION = "MatrixEvaluation";
      public const string MATRIXSTATE = "MatrixState";
      public const string MEDIA = "Media";
      public const string MEDIACOLOR = "MediaColor";
      public const string MEDIACOLORDETAILS = "MediaColorDetails";
      public const string MEDIAINTENT = "MediaIntent";
      public const string MEDIALAYERS = "MediaLayers";
      public const string MEDIASOURCE = "MediaSource";
      public const string MEDIATYPE = "MediaType";
      public const string MEDIATYPEDETAILS = "MediaTypeDetails";
      public const string MEDIAUNIT = "MediaUnit";
      public const string MERGED = "Merged";
      public const string MESSAGE = "Message";
      public const string MESSAGESERVICE = "MessageService";
      public const string METHOD = "Method";
      public const string MILESTONE = "Milestone";
      public const string MISCCONSUMABLE = "MiscConsumable";
      public const string MISDETAILS = "MISDetails";
      public const string MODIFIED = "Modified";
      public const string MODIFYNODECMDPARAMS = "ModifyNodeCmdParams";
      public const string MODULE = "Module";
      public const string MODULECAP = "ModuleCap";
      public const string MODULEPHASE = "ModulePhase";
      public const string MODULEPOOL = "ModulePool";
      public const string MODULESTATUS = "ModuleStatus";
      public const string MOVERESOURCE = "MoveResource";
      public const string MSGFILTER = "MsgFilter";

      public const string NAMEEVALUATION = "NameEvaluation";
      public const string NAMESTATE = "NameState";
      public const string NEWCOMMENT = "NewComment";
      public const string NEWJDFCMDPARAMS = "NewJDFCmdParams";
      public const string NEWJDFQUPARAMS = "NewJDFQuParams";
      public const string NODEINFO = "NodeInfo";
      public const string NODEINFOCMDPARAMS = "NodeInfoCmdParams";
      public const string NODEINFOQUPARAMS = "NodeInfoQuParams";
      public const string NODEINFORESP = "NodeInfoResp";
      public const string NOT = "not";
      public const string NOTIFICATION = "Notification";
      public const string NOTIFICATIONDEF = "NotificationDef";
      public const string NOTIFICATIONFILTER = "NotificationFilter";
      public const string NUMBERING = "Numbering";
      public const string NUMBERINGINTENT = "NumberingIntent";
      public const string NUMBERINGPARAM = "NumberingParam";
      public const string NUMBERINGPARAMS = "NumberingParams";
      public const string NUMBERITEM = "NumberItem";
      public const string NUMBEREVALUATION = "NumberEvaluation";
      public const string NUMBERSTATE = "NumberState";

      public const string OBJECTRESOLUTION = "ObjectResolution";
      public const string OBSERVATIONTARGET = "ObservationTarget";
      public const string OCCUPATION = "Occupation";
      public const string OCGCONTROL = "OCGControl";
      public const string OFFERRANGE = "OfferRange";
      public const string OPACITY = "Opacity";
      public const string OPACITYLEVEL = "OpacityLevel";
      public const string OR = "or";
      public const string ORDERING = "Ordering";
      public const string ORDERINGPARAMS = "OrderingParams";
      public const string ORGANIZATIONALUNIT = "OrganizationalUnit";
      public const string ORIENTATION = "Orientation";
      public const string OTHERWISE = "otherwise";
      public const string OVERAGE = "Overage";

      public const string PACKING = "Packing";
      public const string PACKINGINTENT = "PackingIntent";
      public const string PACKINGPARAMS = "PackingParams";
      public const string PAGEASSIGNEDLIST = "PageAssignedList";
      public const string PAGECELL = "PageCell";
      public const string PAGEDATA = "PageData";
      public const string PAGEELEMENT = "PageElement";
      public const string PAGELIST = "PageList";
      public const string PAGES = "Pages";
      public const string PAGESCONSTRAINTSPOOL = "PagesConstraintsPool";
      public const string PAGESRESULTSPOOL = "PagesResultsPool";
      public const string PAGEVARIANCE = "PageVariance";
      public const string PALLET = "Pallet";
      public const string PALLETCORNERBOARDS = "PalletCornerBoards";
      public const string PALLETIZING = "Palletizing";
      public const string PALLETIZINGPARAMS = "PalletizingParams";
      public const string PALLETMAXHEIGHT = "PalletMaxHeight";
      public const string PALLETMAXWEIGHT = "PalletMaxWeight";
      public const string PALLETQUANTITY = "PalletQuantity";
      public const string PALLETSIZE = "PalletSize";
      public const string PALLETTYPE = "PalletType";
      public const string PALLETWRAPPING = "PalletWrapping";
      public const string PARENT = "Parent";
      public const string PART = "Part";
      public const string PARTAMOUNT = "PartAmount";
      public const string PARTSTATUS = "PartStatus";
      public const string PAYMENT = "Payment";
      public const string PAYTERM = "PayTerm";
      public const string PDFINTERPRETINGPARAMS = "PDFInterpretingParams";
      public const string PDFPATHEVALUATION = "PDFPathEvaluation";
      public const string PDFPATHSTATE = "PDFPathState";
      public const string PDFTOPSCONVERSION = "PDFToPSConversion";
      public const string PDFTOPSCONVERSIONPARAMS = "PDFToPSConversionParams";
      public const string PDFXPARAMS = "PDFXParams";
      public const string PDLCREATIONPARAMS = "PDLCreationParams";
      public const string PDLRESOURCEALIAS = "PDLResourceAlias";
      public const string PERFORATE = "Perforate";
      public const string PERFORATING = "Perforating";
      public const string PERFORATINGPARAMS = "PerforatingParams";
      public const string PERFORMANCE = "Performance";
      public const string PERSON = "Person";
      public const string PHASETIME = "PhaseTime";
      public const string PIPEPARAMS = "PipeParams";
      public const string PIXELCOLORANT = "PixelColorant";
      public const string PLACEHOLDERRESOURCE = "PlaceHolderResource";
      public const string PLASTICCOMBBINDING = "PlasticCombBinding";
      public const string PLASTICCOMBBINDINGPARAMS = "PlasticCombBindingParams";
      public const string PLASTICCOMBTYPE = "PlasticCombType";
      public const string PLATECOPYPARAMS = "PlateCopyParams";
      public const string POSITION = "Position";
      public const string POSTPRESSCOMPONENTPATH = "PostPressComponentPath";
      public const string PREFLIGHT = "Preflight";
      public const string PREFLIGHTACTION = "PreflightAction";
      public const string PREFLIGHTANALYSIS = "PreflightAnalysis";
      public const string PREFLIGHTARGUMENT = "PreflightArgument";
      public const string PREFLIGHTCONSTRAINT = "PreflightConstraint";
      public const string PREFLIGHTCONSTRAINTSPOOL = "PreflightConstraintsPool";
      public const string PREFLIGHTDETAIL = "PreflightDetail";
      public const string PREFLIGHTINFORMATION = "PreflightInformation";
      public const string PREFLIGHTINSTANCE = "PreflightInstance";
      public const string PREFLIGHTINSTANCEDETAIL = "PreflightInstanceDetail";
      public const string PREFLIGHTINVENTORY = "PreflightInventory";
      public const string PREFLIGHTPARAMS = "PreflightParams";
      public const string PREFLIGHTPROFILE = "PreflightProfile";
      public const string PREFLIGHTPROFILECONSTRAINTSPOOL = "PreflightProfileConstraintsPool";
      public const string PREFLIGHTREPORT = "PreflightReport";
      public const string PREFLIGHTREPORTRULEPOOL = "PreflightReportRulePool";
      public const string PREFLIGHTRESULTSPOOL = "PreflightResultsPool";
      public const string PRERROR = "PRError";
      public const string PREVIEW = "Preview";
      public const string PREVIEWGENERATION = "PreviewGeneration";
      public const string PREVIEWGENERATIONPARAMS = "PreviewGenerationParams";
      public const string PRGROUP = "PRGroup";
      public const string PRGROUPOCCURRENCE = "PRGroupOccurrence";
      public const string PRICING = "Pricing";
      public const string PRINTCONDITION = "PrintCondition";
      public const string PRINTCONDITIONCOLOR = "PrintConditionColor";
      public const string PRINTINGUNITWEBPATH = "PrintingUnitWebPath";
      public const string PRINTPREFERENCE = "PrintPreference";
      public const string PRINTPROCESS = "PrintProcess";
      public const string PRINTROLLING = "PrintRolling";
      public const string PRINTROLLINGPARAMS = "PrintRollingParams";
      public const string PRITEM = "PRItem";
      public const string PROCCURRENCE = "PROccurrence";
      ///    @deprecated use EnumType.xxx.getName()  
      ///	 
      [Obsolete("use EnumType.xxx.getName()")]
      public const string PROCESSGROUP = "ProcessGroup";
      public const string PROCESSRUN = "ProcessRun";
      public const string PROCESSTYPE_UNKNOWN = "Unknown";
      ///    @deprecated use EnumType.xxx.getName()  
      ///	 
      [Obsolete("use EnumType.xxx.getName()")]
      public const string PRODUCT = "Product";
      public const string PRODUCTIONINTENT = "ProductionIntent";
      public const string PRODUCTIONPATH = "ProductionPath";
      public const string PRODUCTIONSUBPATH = "ProductionSubPath";
      public const string PROOFING = "Proofing";
      public const string PROOFINGINTENT = "ProofingIntent";
      public const string PROOFINGPARAMS = "ProofingParams";
      public const string PROOFITEM = "ProofItem";
      public const string PROOFTYPE = "ProofType";
      public const string PROPERTIES = "Properties";
      public const string PRRULE = "PRRule";
      public const string PRRULEATTR = "PRRuleAttr";
      public const string PSTOPDFCONVERSION = "PSToPDFConversion";
      public const string PSTOPDFCONVERSIONPARAMS = "PSToPDFConversionParams";
      public const string PUBLISHINGINTENT = "PublishingIntent";

      public const string QUALITYCONTROL = "QualityControl";
      public const string QUALITYCONTROLPARAMS = "QualityControlParams";
      public const string QUALITYCONTROLRESULT = "QualityControlResult";
      public const string QUALITYMEASUREMENT = "QualityMeasurement";
      public const string QUERY = "Query";
      public const string QUEUE = "Queue";
      public const string QUEUEENTRY = "QueueEntry";
      public const string QUEUEENTRYDEF = "QueueEntryDef";
      public const string QUEUEENTRYDEFLIST = "QueueEntryDefList";
      public const string QUEUEENTRYPOSPARAMS = "QueueEntryPosParams";
      public const string QUEUEENTRYPRIPARAMS = "QueueEntryPriParams";
      public const string QUEUEFILTER = "QueueFilter";
      public const string QUEUESUBMISSIONPARAMS = "QueueSubmissionParams";

      public const string RANGE = "Range";
      public const string RASTERREADINGPARAMS = "RasterReadingParams";
      public const string RECTANGLEEVALUATION = "RectangleEvaluation";
      public const string RECTANGLESTATE = "RectangleState";
      public const string RECYCLED = "Recycled";
      public const string RECYCLEDPERCENTAGE = "RecycledPercentage";
      public const string REFELEMENT = "RefElement";
      public const string REGISTERMARK = "RegisterMark";
      public const string REGISTERRIBBON = "RegisterRibbon";
      public const string REGISTRATION = "Registration";
      public const string REJECTED = "Rejected";
      public const string REMOVED = "Removed";
      public const string REMOVELINK = "RemoveLink";
      public const string RENDERING = "Rendering";
      public const string RENDERINGPARAMS = "RenderingParams";
      public const string REQUESTQUEUEENTRYPARAMS = "RequestQueueEntryParams";
      public const string REQUIRED = "Required";
      public const string REQUIREDDURATION = "RequiredDuration";
      public const string RESOURCE = "Resource";
      public const string RESOURCEAUDIT = "ResourceAudit";
      public const string RESOURCECMDPARAMS = "ResourceCmdParams";
      public const string RESOURCEDEFINITION = "ResourceDefinition";
      public const string RESOURCEDEFINITIONPARAMS = "ResourceDefinitionParams";
      public const string RESOURCEINFO = "ResourceInfo";
      public const string RESOURCELINK = "ResourceLink";
      public const string RESOURCELINKPOOL = "ResourceLinkPool";
      public const string RESOURCEPARAM = "ResourceParam";
      public const string RESOURCEPOOL = "ResourcePool";
      public const string RESOURCEPULLPARAMS = "ResourcePullParams";
      public const string RESOURCEQUPARAMS = "ResourceQuParams";
      public const string RESPONSE = "Response";
      public const string RESUBMISSIONPARAMS = "ResubmissionParams";
      public const string RETURNMETHOD = "ReturnMethod";
      public const string RETURNQUEUEENTRYPARAMS = "ReturnQueueEntryParams";
      public const string RINGBINDING = "RingBinding";
      public const string RINGBINDINGPARAMS = "RingBindingParams";
      public const string RINGDIAMETER = "RingDiameter";
      public const string RINGMECHANIC = "RingMechanic";
      public const string RINGSHAPE = "RingShape";
      public const string RINGSYSTEM = "RingSystem";
      public const string RIVETSEXPOSED = "RivetsExposed";
      public const string ROLLSTAND = "RollStand";
      public const string RUNLIST = "RunList";

      public const string SADDLESTITCHING = "SaddleStitching";
      public const string SADDLESTITCHINGPARAMS = "SaddleStitchingParams";
      public const string SCANNING = "Scanning";
      public const string SCANPARAMS = "ScanParams";
      public const string SCAVENGERAREA = "ScavengerArea";
      public const string SCORE = "Score";
      public const string SCORING = "Scoring";
      public const string SCREENING = "Screening";
      public const string SCREENINGINTENT = "ScreeningIntent";
      public const string SCREENINGPARAMS = "ScreeningParams";
      public const string SCREENINGTYPE = "ScreeningType";
      public const string SCREENSELECTOR = "ScreenSelector";
      public const string SEALING = "Sealing";
      public const string SEARCHPATH = "SearchPath";
      public const string SEPARATION = "Separation";
      public const string SEPARATIONCONTROLPARAMS = "SeparationControlParams";
      public const string SEPARATIONLIST = "SeparationList";
      public const string SEPARATIONSPEC = "SeparationSpec";
      public const string SERVICELEVEL = "ServiceLevel";
      public const string SET = "set";
      public const string SHAPE = "Shape";
      public const string SHAPECUT = "ShapeCut";
      public const string SHAPECUTTING = "ShapeCutting";
      public const string SHAPECUTTINGINTENT = "ShapeCuttingIntent";
      public const string SHAPECUTTINGPARAMS = "ShapeCuttingParams";
      public const string SHAPEDEPTH = "ShapeDepth";
      public const string SHAPEELEMENT = "ShapeElement";
      public const string SHAPEEVALUATION = "ShapeEvaluation";
      public const string SHAPESTATE = "ShapeState";
      public const string SHAPETYPE = "ShapeType";
      public const string SHEET = "Sheet";
      public const string SHRINKING = "Shrinking";
      public const string SHRINKINGPARAMS = "ShrinkingParams";
      public const string SHUTDOWNCMDPARAMS = "ShutDownCmdParams";
      public const string SIDESEWING = "SideSewing";
      public const string SIDESEWINGPARAMS = "SideSewingParams";
      public const string SIDESTITCHING = "SideStitching";
      public const string SIGNAL = "Signal";
      public const string SIGNATURE = "Signature";
      public const string SIGNATURECELL = "SignatureCell";
      public const string SIZEINTENT = "SizeIntent";
      public const string SIZEPOLICY = "SizePolicy";
      public const string SOFTCOVERBINDING = "SoftCoverBinding";
      public const string SOFTPROOFING = "SoftProofing";
      public const string SOURCERESOURCE = "SourceResource";
      public const string SPAWNED = "Spawned";
      public const string SPINEBRUSHING = "SpineBrushing";
      public const string SPINEFIBERROUGHING = "SpineFiberRoughing";
      public const string SPINEFIBREROUGHING = "SpineFibreRoughing";
      public const string SPINEGLUE = "SpineGlue";
      public const string SPINELEVELLING = "SpineLevelling";
      public const string SPINEMILLING = "SpineMilling";
      public const string SPINENOTCHING = "SpineNotching";
      public const string SPINEPREPARATION = "SpinePreparation";
      public const string SPINEPREPARATIONPARAMS = "SpinePreparationParams";
      public const string SPINESANDING = "SpineSanding";
      public const string SPINESHREDDING = "SpineShredding";
      public const string SPINETAPING = "SpineTaping";
      public const string SPINETAPINGPARAMS = "SpineTapingParams";
      public const string SPLIT = "Split";
      public const string STACKING = "Stacking";
      public const string STACKINGPARAMS = "StackingParams";
      public const string STATION = "Station";
      public const string STATUSPOOL = "StatusPool";
      public const string STATUSQUPARAMS = "StatusQuParams";
      public const string STITCHING = "Stitching";
      public const string STITCHINGPARAMS = "StitchingParams";
      public const string STITCHNUMBER = "StitchNumber";
      public const string STOCKBRAND = "StockBrand";
      public const string STOCKTYPE = "StockType";
      public const string STOPPERSCHPARAMS = "StopPersChParams";
      public const string STRAP = "Strap";
      public const string STRAPPING = "Strapping";
      public const string STRAPPINGPARAMS = "StrappingParams";
      public const string STRINGLISTVALUE = "StringListValue";
      public const string STRINGEVALUATION = "StringEvaluation";
      public const string STRINGSTATE = "StringState";
      public const string STRIPBINDING = "StripBinding";
      public const string STRIPBINDINGPARAMS = "StripBindingParams";
      public const string STRIPBINDINGPARAMSUPDATE = "StripBindingParamsUpdate";
      public const string STRIPCELLPARAMS = "StripCellParams";
      public const string STRIPMARK = "StripMark";
      public const string STRIPMATERIAL = "StripMaterial";
      public const string STRIPPING = "Stripping";
      public const string STRIPPINGPARAMS = "StrippingParams";
      public const string SUBMISSIONMETHODS = "SubmissionMethods";
      public const string SUBSCRIPTION = "Subscription";
      public const string SURFACE = "Surface";
      public const string SURPLUSHANDLING = "SurplusHandling";
      public const string SYSTEMTIMESET = "SystemTimeSet";

      public const string TABBINDMYLAR = "TabBindMylar";
      public const string TABBODYCOPY = "TabBodyCopy";
      public const string TABBRAND = "TabBrand";
      public const string TABEXTENSIONDISTANCE = "TabExtensionDistance";
      public const string TABEXTENSIONMYLAR = "TabExtensionMylar";
      public const string TABMYLARCOLOR = "TabMylarColor";
      public const string TABS = "Tabs";
      public const string TAPE = "Tape";
      public const string TAPEBINDING = "TapeBinding";
      public const string TAPECOLOR = "TapeColor";
      public const string TECHNOLOGY = "Technology";
      public const string TEETHPERDIMENSION = "TeethPerDimension";
      public const string TEMPERATURE = "Temperature";
      public const string TEST = "Test";
      public const string TESTPOOL = "TestPool";
      public const string TESTREF = "TestRef";
      public const string TEXTURE = "Texture";
      public const string THICKNESS = "Thickness";
      public const string THINPDFPARAMS = "ThinPDFParams";
      public const string THREADSEALING = "ThreadSealing";
      public const string THREADSEALINGPARAMS = "ThreadSealingParams";
      public const string THREADSEWING = "ThreadSewing";
      public const string THREADSEWINGPARAMS = "ThreadSewingParams";
      public const string TIFFEMBEDDEDFILE = "TIFFEmbeddedFile";
      public const string TIFFTAG = "TIFFtag";
      public const string TIFFFORMATPARAMS = "TIFFFormatParams";
      public const string TIGHTBACKING = "TightBacking";
      public const string TILE = "Tile";
      public const string TILING = "Tiling";
      public const string TOOL = "Tool";
      public const string TRACKFILTER = "TrackFilter";
      public const string TRACKRESULT = "TrackResult";
      public const string TRANSFER = "Transfer";
      public const string TRANSFERCURVE = "TransferCurve";
      public const string TRANSFERCURVEPOOL = "TransferCurvePool";
      public const string TRANSFERCURVESET = "TransferCurveSet";
      public const string TRANSFERFUNCTIONCONTROL = "TransferFunctionControl";
      public const string TRAPPING = "Trapping";
      public const string TRAPPINGDETAILS = "TrappingDetails";
      public const string TRAPPINGORDER = "TrappingOrder";
      public const string TRAPPINGPARAMS = "TrappingParams";
      public const string TRAPREGION = "TrapRegion";
      public const string TRIGGER = "Trigger";
      public const string TRIMMING = "Trimming";
      public const string TRIMMINGPARAMS = "TrimmingParams";

      public const string UNDERAGE = "Underage";
      public const string UPDATE = "Update";
      public const string UPDATEJDFCMDPARAMS = "UpdateJDFCmdParams";
      public const string URL = "URL";
      public const string USAGECOUNTER = "UsageCounter";
      public const string USWEIGHT = "USWeight";

      public const string VALUE = "Value";
      public const string VALUELOC = "ValueLoc";
      public const string VELOBINDING = "VeloBinding";
      public const string VERIFICATION = "Verification";
      public const string VERIFICATIONPARAMS = "VerificationParams";
      public const string VIEWBINDER = "ViewBinder";

      public const string WAKEUPCMDPARAMS = "WakeUpCmdParams";
      public const string WEBINLINEFINISHINGPARAMS = "WebInlineFinishingParams";
      public const string WEIGHT = "Weight";
      public const string WHEN = "when";
      public const string WIRECOMBBINDING = "WireCombBinding";
      public const string WIRECOMBBINDINGPARAMS = "WireCombBindingParams";
      public const string WIRECOMBBRAND = "WireCombBrand";
      public const string WIRECOMBMATERIAL = "WireCombMaterial";
      public const string WIRECOMBSHAPE = "WireCombShape";
      public const string WRAPPEDQUANTITY = "WrappedQuantity";
      public const string WRAPPING = "Wrapping";
      public const string WRAPPINGMATERIAL = "WrappingMaterial";
      public const string WRAPPINGPARAMS = "WrappingParams";

      public const string XOR = "xor";
      public const string XPOSITION = "XPosition";
      public const string XYPAIREVALUATION = "XYPairEvaluation";
      public const string XYPAIRSTATE = "XYPairState";
      public const string YPOSITION = "YPosition";

      // muss noch einsortiert werden!
  }
}
