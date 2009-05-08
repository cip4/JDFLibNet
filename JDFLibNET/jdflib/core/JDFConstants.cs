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
 * Copyright (c) 2001-2003 Heidelberger Druckmaschinen AG, All Rights Reserved.
 * JDFConstants.cs */

namespace org.cip4.jdflib.core
{
   using System;

   public abstract class JDFConstants
   {
      ///   
      ///	 <summary> * cip4 namespace uri for any jdf </summary>
      ///	 
      public const string JDFNAMESPACE = "http://www.CIP4.org/JDFSchema_1_1";

      ///   
      ///	 <summary> * lower case flag for misspelt jdf namespace uris </summary>
      ///	 
      public const string CIP4ORG = ".cip4.org";
      ///   
      ///	 * @deprecated use null for wildcard 
      ///	 
      [Obsolete("use null for wildcard")]
      public const string WILDCARD = "*";
      public const string EMPTYSTRING = "";
      ///   
      ///	 * @deprecated use null for no namespace check 
      ///	 
      [Obsolete("use null for no namespace check")]
      public const string NONAMESPACE = EMPTYSTRING;
      ///    @deprecated use null  
      ///	 
      [Obsolete("use null")]
      public const string IMPROBABLE_STRING = "\"\'";
      public const string COMMA = ",";
      public const string BLANK = " ";
      public const string COLON = ":";
      public const string HYPHEN = "-";
      public const char CHAR_COLON = ':';
      public const string QUOTE = "\"";
      public const string SLASH = "/";
      public const string DOT = ".";
      public const string DOTSLASH = "./";
      public const string DOTDOTSLASH = "../";
      public const string AET = "@";
      public const string TILDE = "~";
      public const string STAR = "*";
      public const string UNDERSCORE = "_";

      public const string XMLNS = "xmlns";
      public const string XSI = "xsi";

      ///    @deprecated use null (not \"null\")  
      ///	 
      [Obsolete("use null (not \"null\")")]
      public const string NULL = "null";
      public const string TRUE = "true";
      public const string FALSE = "false";

      public const string NEGINF = "-INF";
      public const string POSINF = "INF";

      public const string INTERNAL = "Internal";

      // the positive INF value 0x7FEDCBAA
      /// @deprecated  
      [Obsolete]
      public const long POSINF_HEX = 0x7FEDCBAA;
      // the negative INF value 0x80123456
      /// @deprecated  
      [Obsolete]
      public const long NEGINF_HEX = 0x80123456;

      public const string INPUT_ZEROTOINFINITY = "i*";
      public const string INPUT_ONETOINFINITY = "i+";
      public const string INPUT_ZEROTOONE = "i?";
      public const string INPUT_EXACTLYONE = "i_";

      public const string OUTPUT_ZEROTOINFINITY = "o*";
      public const string OUTPUT_ONETOINFINITY = "o+";
      public const string OUTPUT_ZEROTOONE = "o?";
      public const string OUTPUT_EXACTLYONE = "o_";

      public const string VERSION_1_0 = "1.0";
      public const string VERSION_1_1 = "1.1";
      public const string VERSION_1_2 = "1.2";
      public const string VERSION_1_3 = "1.3";
      public const string VERSION_1_4 = "1.4";
      public const string VERSION_1_5 = "1.5";
      public const string VERSION_1_6 = "1.6";
      public const string VERSION_1_7 = "1.7";
      public const string VERSION_1_8 = "1.8";
      public const string VERSION_1_9 = "1.9";

      // status stuff
      public const string UNKNOWN = "Unknown";

      // EnumNodeStatus : enums accordng to JDF spec 3.1.2, Table 3-3 Status (see
      // also Table 4-2)
      public const string WAITING = "Waiting";
      public const string TESTRUNINPROGRESS = "TestRunInProgress";
      public const string READY = "Ready";
      public const string FAILEDTESTRUN = "FailedTestRun";
      public const string SETUP = "Setup";
      public const string INPROGRESS = "InProgress";
      public const string CLEANUP = "Cleanup";
      public const string SPAWNED = "Spawned";
      public const string SUSPENDED = "Suspended";
      public const string STOPPED = "Stopped";
      public const string COMPLETED = "Completed";
      public const string ABORTED = "Aborted";
      public const string POOL = "Pool";
      public const string PART = "Part";

      // EnumSpawnStatus : enums accordng to JDF spec 3.7, Table 3-11 SpawnStatus
      public const string NOTSPAWNED = "NotSpawned";
      public const string SPAWNEDRO = "SpawnedRO";
      public const string SPAWNEDRW = "SpawnedRW";

      // EnumResStatus : enums accordng to JDF spec 3.7, Table 3-11 Status
      public const string INCOMPLETE = "Incomplete";
      public const string REJECTED = "Rejected";
      public const string UNAVAILABLE = "Unavailable";
      public const string INUSE = "InUse";
      public const string DRAFT = "Draft";
      public const string COMPLETE = "Complete";
      public const string AVAILABLE = "Available";

      // EnumDeviceStatus : enums accordng to JDF spec 3.10.1.3, Table 3-33, 5-43,
      // 5-45 DeviceStatus
      // final static String UNKNOWN = "Unknown";
      public const string IDLE = "Idle";
      public const string DOWN = "Down";
      // final static String SETUP = "Setup";
      public const string RUNNING = "Running";
      // final static String CLEANUP = "Cleanup";
      // final static String STOPPED = "Stopped";

      // EnumQueueStatus : enums accordng to JDF spec 5.6.4, Table 5-78 Status of
      // a Queue
      public const string BLOCKED = "Blocked";
      public const string CLOSED = "Closed";
      public const string FULL = "Full";
      // final static String RUNNING = "Running";
      // final static String WAITING = "Waiting";
      public const string HELD = "Held";
      // additional stati
      public const string UNREACHABLE = "Unreachable";
      public const string NEEDSATTENTION = "NeedsAttention";

      // EnumQueueEntryStatus : enums accordng to JDF spec 5.6.4, Table 5-79
      // Status of a QueueEntry
      // final static String RUNNING = "Running";
      // final static String WAITING = "Waiting";
      // final static String HELD = "Held";
      public const string REMOVED = "Removed";

      // TODO deprecate duplicates that exist in ElementName and AttributeName
      public const string AUDIT = "Audit";
      public const string BUSINESSID = "BusinessID";
      public const string BUSINESSREFID = "BusinessRefID";
      public const string COLORSPACECONVERSION = "ColorSpaceConversion";
      public const string COMBINED = "Combined";
      public const string CONVENTIONALPRINTING = "ConventionalPrinting";
      public const string CUTTING = "Cutting";
      public const string DEPENDENCIES = "Dependencies";
      public const string DEPENDENCY = "Dependency";
      public const string DIGITALPRINTING = "DigitalPrinting";
      public const string DRAFTOK = "DraftOK";
      public const string FILENAME = "FileName";
      public const string FOLDING = "Folding";
      public const string IMAGEREPLACEMENT = "ImageReplacement";
      public const string IMAGESETTING = "ImageSetting";
      public const string IMPOSITION = "Imposition";
      public const string INPUT = "Input";
      public const string INTERPRETING = "Interpreting";
      public const string LAYOUTELEMENTPRODUCTION = "LayoutElementProduction";
      public const string LINK = "Link";
      public const string JDFHERING = "JDFhering";
      public const string JREF = "jRef";
      public const string MACHINE = "Machine";
      public const string MERGEID = "MergeID";
      public const string MIME = "Mime";
      public const string NEWSPAWNID = "NewSpawnID";
      public const string NODEID = "NodeID";
      public const string OPERATOR = "Operator";
      public const string OUTPUT = "Output";
      public const string PAGEELEMENTS = "PageElements";
      public const string PROCESSGROUP = "ProcessGroup";
      public const string PRODUCT = "Product";
      public const string PROJECTID = "ProjectID";
      public const string RENDERING = "Rendering";
      public const string RIPPING = "Ripping";
      public const string REF = "Ref"; // important: upper case "R"
      // see AttributeName.REF for "ref" as attribute name
      public const string RREF = "rRef";
      public const string RREFSOVERWRITTEN = "rRefsOverwritten";
      public const string RREFSROCOPIED = "rRefsROCopied";
      public const string RREFSRWCOPIED = "rRefsRWCopied";
      public const string RSUBREF = "rSubRef";
      public const string SCANNING = "Scanning";
      public const string SCREENING = "Screening";
      public const string SPAWNID = "SpawnID";
      public const string SEVERITY = "Severity";
      public const string TITLE = "Title";
      public const string TRIMMING = "Trimming";
      public const string UNBOUNDED = "unbounded";
      public const string UPDATE = "Update";

      // notification - states
      public const string NOTIFICATION_EVENT = "Event";
      public const string NOTIFICATION_INFORMATION = "Information";
      public const string NOTIFICATION_WARNING = "Warning";
      public const string NOTIFICATION_ERROR = "Error";
      public const string NOTIFICATION_FATAL = "Fatal";

      ///   
      ///	 <summary> * Constants EnumActivation Used by e.g. JDFNode - Table 3-3 </summary>
      ///	 
      /// @deprecated  
      [Obsolete]
      public const string ACTIVATION_UNKNOWN = "Unknown";
      public const string ACTIVATION_INACTIVE = "Inactive";
      public const string ACTIVATION_INFORMATIVE = "Informative";
      public const string ACTIVATION_HELD = "Held";
      public const string ACTIVATION_ACTIVE = "Active";
      public const string ACTIVATION_TESTRUN = "TestRun";
      public const string ACTIVATION_TESTRUNANDGO = "TestRunAndGo";

      ///   
      ///	 <summary> * Constants EnumPartUsage Used by e.g. JDFResource </summary>
      ///	 
      /// @deprecated  
      [Obsolete]
      public const string PARTUSAGE_UNKNOWN = "Unknown";
      public const string PARTUSAGE_EXPLICIT = "Explicit";
      public const string PARTUSAGE_IMPLICIT = "Implicit";
      public const string PARTUSAGE_SPARSE = "Sparse";

      ///   
      ///	 <summary> * Constants EnumLotControl Used by JDFResource </summary>
      ///	 
      /// @deprecated  
      [Obsolete]
      public const string LOTCONTROL_UNKNOWN = "Unknown";
      public const string LOTCONTROL_CONTROLLED = "Controlled";
      public const string LOTCONTROL_NOTCONTROLLED = "NotControlled";

      ///   
      ///	 <summary> * Enumeration for partition keys Used by e.g. JDFResource </summary>
      ///	 
      /// @deprecated  
      [Obsolete]
      public const string PARTIDKEY_UNKNOWN = "Unknown";
      public const string PARTIDKEY_BINDERYSIGNATURENAME = "BinderySignatureName";
      public const string PARTIDKEY_BLOCKNAME = "BlockName";
      public const string PARTIDKEY_BUNDLEITEMINDEX = "BundleItemIndex";
      public const string PARTIDKEY_CELLINDEX = "CellIndex";
      public const string PARTIDKEY_CONDITION = "Condition";
      public const string PARTIDKEY_DOCCOPIES = "DocCopies";
      public const string PARTIDKEY_DOCINDEX = "DocIndex";
      public const string PARTIDKEY_DOCRUNINDEX = "DocRunIndex";
      public const string PARTIDKEY_DOCSHEETINDEX = "DocSheetIndex";
      public const string PARTIDKEY_FOUNTAINNUMBER = "FountainNumber";
      public const string PARTIDKEY_ITEMNAMES = "ItemNames";
      public const string PARTIDKEY_LAYERIDS = "LayerIDs";
      public const string PARTIDKEY_LOCATION = "Location";
      public const string PARTIDKEY_OPTION = "Option";
      public const string PARTIDKEY_PAGENUMBER = "PageNumber";
      public const string PARTIDKEY_PARTVERSION = "PartVersion";
      public const string PARTIDKEY_PREFLIGHTRULE = "PreflightRule";
      public const string PARTIDKEY_PREVIEWTYPE = "PreviewType";
      public const string PARTIDKEY_RIBBONNAME = "RibbonName";
      public const string PARTIDKEY_RUN = "Run";
      public const string PARTIDKEY_RUNINDEX = "RunIndex";
      public const string PARTIDKEY_RUNTAGS = "RunTags";
      public const string PARTIDKEY_RUNPAGE = "RunPage";
      public const string PARTIDKEY_SEPARATION = "Separation";
      public const string PARTIDKEY_SECTIONINDEX = "SectionIndex";
      public const string PARTIDKEY_SETDOCINDEX = "SetDocIndex";
      public const string PARTIDKEY_SETSHEETINDEX = "SetSheetIndex";
      public const string PARTIDKEY_SETINDEX = "SetIndex";
      public const string PARTIDKEY_SETRUNINDEX = "SetRunIndex";
      public const string PARTIDKEY_SHEETINDEX = "SheetIndex";
      public const string PARTIDKEY_SHEETNAME = "SheetName";
      public const string PARTIDKEY_SIDE = "Side";
      public const string PARTIDKEY_SIGNATURENAME = "SignatureName";
      public const string PARTIDKEY_TILEID = "TileID";
      public const string PARTIDKEY_WEBNAME = "WebName";

      ///   
      ///	 <summary> * Enumeration for DataType 7.1.1 Used by e.g. JDFSpanBase </summary>
      ///	 

      /// @deprecated  
      [Obsolete]
      public const string DATATYPE_UNKNOWN = "Unknown";
      public const string DATATYPE_DURATION = "DurationSpan";
      public const string DATATYPE_ENUMERATION = "EnumerationSpan";
      public const string DATATYPE_INTEGER = "IntegerSpan";
      public const string DATATYPE_NAME = "NameSpan";
      public const string DATATYPE_NUMBER = "NumberSpan";
      public const string DATATYPE_OPTION = "OptionSpan";
      public const string DATATYPE_SHAPE = "ShapeSpan";
      public const string DATATYPE_STRING = "StringSpan";
      public const string DATATYPE_TIME = "TimeSpan";
      public const string DATATYPE_XYPAIR = "XYPairSpan";

      ///   
      ///	 <summary> * Enumeration for Priority 7.1.1.1 Used by e.g. JDFSpanBase </summary>
      ///	 
      /// @deprecated  
      [Obsolete]
      public const string PRIORITY_UNKNOWN = "Unknown";
      public const string PRIORITY_NONE = "None";
      public const string PRIORITY_SUGGESTED = "Suggested";
      public const string PRIORITY_REQUIRED = "Required";

      ///   
      ///	 <summary> * Enumeration for ProcessUsage Used by e.g JDFNode </summary>
      ///	 
      /// @deprecated  
      [Obsolete]
      public const string PROCESSUSAGE_UNKNOWN = "Unknown";
      public const string PROCESSUSAGE_ANYINPUT = "AnyInput";
      public const string PROCESSUSAGE_ANYOUTPUT = "AnyOutput";
      public const string PROCESSUSAGE_ANY = "Any";
      public const string PROCESSUSAGE_REJECTED = "Rejected";
      public const string PROCESSUSAGE_ACCEPTED = "Accepted";
      public const string PROCESSUSAGE_APPLICATION = "Application";
      public const string PROCESSUSAGE_MARKS = "Marks";
      public const string PROCESSUSAGE_DOCUMENT = "Document";
      public const string PROCESSUSAGE_SURFACE = "Surface";
      public const string PROCESSUSAGE_WASTE = "Waste";
      public const string PROCESSUSAGE_GOOD = "Good";
      public const string PROCESSUSAGE_PROOF = "Proof";
      public const string PROCESSUSAGE_INPUT = "Input";
      public const string PROCESSUSAGE_PLATE = "Plate";
      public const string PROCESSUSAGE_COVER = "Cover";
      public const string PROCESSUSAGE_BOOKBLOCK = "BookBlock";
      public const string PROCESSUSAGE_BOX = "Box";
      public const string PROCESSUSAGE_COVERMATERIAL = "CoverMaterial";
      public const string PROCESSUSAGE_SPINEBOARD = "SpineBoard";
      public const string PROCESSUSAGE_COVERBOARD = "CoverBoard";
      public const string PROCESSUSAGE_CASE = "Case";
      public const string PROCESSUSAGE_FRONTENDSHEET = "FrontEndSheet";
      public const string PROCESSUSAGE_BACKENDSHEET = "BackEndSheet";
      public const string PROCESSUSAGE_CHILD = "Child";
      public const string PROCESSUSAGE_MOTHER = "Mother";
      public const string PROCESSUSAGE_JACKET = "Jacket";
      public const string PROCESSUSAGE_BOOK = "Book";
      public const string PROCESSUSAGE_LABEL = "Label";
      public const string PROCESSUSAGE_RINGBINDER = "RingBinder";
      public const string PROCESSUSAGE_ANCESTOR = "Ancestor";

      ///   
      ///	 <summary> * Enumeration for Type Used by JDFNode </summary>
      ///	 
      public const string EnumType_Prefix = "Type_";

      /// @deprecated  
      [Obsolete]
      public const string TYPE_UNKNOWN = "Unknown";
      public const string TYPE_PRODUCT = "Product";
      public const string TYPE_APPROVAL = "Approval";
      public const string TYPE_BUFFER = "Buffer";
      public const string TYPE_COMBINE = "Combine";
      public const string TYPE_DELIVERY = "Delivery";
      public const string TYPE_MANUALLABOR = "ManualLabor";
      public const string TYPE_ORDERING = "Ordering";
      public const string TYPE_QUALITYCONTROL = "QualityControl";
      public const string TYPE_PACKING = "Packing";
      public const string TYPE_RESOURCEDEFINITION = "ResourceDefinition";
      public const string TYPE_SPLIT = "Split";
      public const string TYPE_VERIFICATION = "Verification";
      public const string TYPE_ASSETLISTCREATION = "AssetListCreation";
      public const string TYPE_ASSETCOLLECTION = "AssetCollection";
      public const string TYPE_BENDING = "Bending";
      public const string TYPE_COLORCORRECTION = "ColorCorrection";
      public const string TYPE_COLORSPACECONVERSION = "ColorSpaceConversion";
      public const string TYPE_CONTACTCOPYING = "ContactCopying";
      public const string TYPE_CONTONECALIBRATION = "ContoneCalibration";
      public const string TYPE_CYLINDERLAYOUTPREPARATION = "CylinderLayoutPreparation";
      public const string TYPE_DBDOCTEMPLATELAYOUT = "DBDocTemplateLayout";
      public const string TYPE_DBTEMPLATEMERGING = "DBTemplateMerging";
      public const string TYPE_DIGITALDELIVERY = "DigitalDelivery";
      public const string TYPE_FILMTOPLATECOPYING = "FilmToPlateCopying";
      public const string TYPE_FORMATCONVERSION = "FormatConversion";
      public const string TYPE_IMAGEREPLACEMENT = "ImageReplacement";
      public const string TYPE_IMAGESETTING = "ImageSetting";
      public const string TYPE_IMPOSITION = "Imposition";
      public const string TYPE_INKZONECALCULATION = "InkZoneCalculation";
      public const string TYPE_INTERPRETING = "Interpreting";
      public const string TYPE_LAYOUTELEMENTPRODUCTION = "LayoutElementProduction";
      public const string TYPE_LAYOUTPREPARATION = "LayoutPreparation";
      public const string TYPE_PDFTOPSCONVERSION = "PDFToPSConversion";
      public const string TYPE_PDLCREATION = "PDLCreation";
      public const string TYPE_PREFLIGHT = "Preflight";
      public const string TYPE_PREVIEWGENERATION = "PreviewGeneration";
      public const string TYPE_PROOFING = "Proofing";
      public const string TYPE_PSTOPDFCONVERSION = "PSToPDFConversion";
      public const string TYPE_RASTERREADING = "RasterReading";
      public const string TYPE_RENDERING = "Rendering";
      public const string TYPE_SCANNING = "Scanning";
      public const string TYPE_SCREENING = "Screening";
      public const string TYPE_SEPARATION = "Separation";
      public const string TYPE_SOFTPROOFING = "SoftProofing";
      public const string TYPE_STRIPPING = "Stripping";
      public const string TYPE_TILING = "Tiling";
      public const string TYPE_TRAPPING = "Trapping";
      public const string TYPE_CONVENTIONALPRINTING = "ConventionalPrinting";
      public const string TYPE_DIGITALPRINTING = "DigitalPrinting";
      public const string TYPE_IDPRINTING = "IDPrinting";
      public const string TYPE_ADHESIVEBINDING = "AdhesiveBinding";
      public const string TYPE_BLOCKPREPARATION = "BlockPreparation";
      public const string TYPE_BOXPACKING = "BoxPacking";
      public const string TYPE_BOXFOLDING = "BoxFolding";
      public const string TYPE_BUNDLING = "Bundling";
      public const string TYPE_CASEMAKING = "CaseMaking";
      public const string TYPE_CASINGIN = "CasingIn";
      public const string TYPE_CHANNELBINDING = "ChannelBinding";
      public const string TYPE_COILBINDING = "CoilBinding";
      public const string TYPE_COLLECTING = "Collecting";
      public const string TYPE_COVERAPPLICATION = "CoverApplication";
      public const string TYPE_CREASING = "Creasing";
      public const string TYPE_CUTTING = "Cutting";
      public const string TYPE_DIVIDING = "Dividing";
      public const string TYPE_EMBOSSING = "Embossing";
      public const string TYPE_ENDSHEETGLUING = "EndSheetGluing";
      public const string TYPE_FEEDING = "Feeding";
      public const string TYPE_FOLDING = "Folding";
      public const string TYPE_GATHERING = "Gathering";
      public const string TYPE_GLUING = "Gluing";
      public const string TYPE_HEADBANDAPPLICATION = "HeadBandApplication";
      public const string TYPE_HOLEMAKING = "HoleMaking";
      public const string TYPE_INSERTING = "Inserting";
      public const string TYPE_JACKETING = "Jacketing";
      public const string TYPE_LABELING = "Labeling";
      public const string TYPE_LAMINATING = "Laminating";
      public const string TYPE_LONGITUDINALRIBBONOPERATIONS = "LongitudinalRibbonOperations";
      public const string TYPE_NUMBERING = "Numbering";
      public const string TYPE_PALLETIZING = "Palletizing";
      public const string TYPE_PERFORATING = "Perforating";
      public const string TYPE_PLASTICCOMBBINDING = "PlasticCombBinding";
      public const string TYPE_PRINTROLLING = "PrintRolling";
      public const string TYPE_RINGBINDING = "RingBinding";
      public const string TYPE_SADDLESTITCHING = "SaddleStitching";
      public const string TYPE_SHAPECUTTING = "ShapeCutting";
      public const string TYPE_SHRINKING = "Shrinking";
      public const string TYPE_SIDESEWING = "SideSewing";
      public const string TYPE_SPINEPREPARATION = "SpinePreparation";
      public const string TYPE_SPINETAPING = "SpineTaping";
      public const string TYPE_STACKING = "Stacking";
      public const string TYPE_STITCHING = "Stitching";
      public const string TYPE_STRAPPING = "Strapping";
      public const string TYPE_STRIPBINDING = "StripBinding";
      public const string TYPE_THREADSEALING = "ThreadSealing";
      public const string TYPE_THREADSEWING = "ThreadSewing";
      public const string TYPE_TRIMMING = "Trimming";
      public const string TYPE_WEBINLINEFINISHING = "WebInlineFinishing";
      public const string TYPE_WIRECOMBBINDING = "WireCombBinding";
      public const string TYPE_WRAPPING = "Wrapping";
      public const string TYPE_COMBINED = "Combined";
      public const string TYPE_PROCESSGROUP = "ProcessGroup";

      ///   
      ///	 <summary> * Enumeration for NameColor Used by JDFElement </summary>
      ///	 
      public const string NAMEDCOLOR_UNKNOWN = "Unknown";
      public const string NAMEDCOLOR_WHITE = "White";
      public const string NAMEDCOLOR_BLACK = "Black";
      public const string NAMEDCOLOR_GRAY = "Gray";
      public const string NAMEDCOLOR_RED = "Red";
      public const string NAMEDCOLOR_YELLOW = "Yellow";
      public const string NAMEDCOLOR_GREEN = "Green";
      public const string NAMEDCOLOR_BLUE = "Blue";
      public const string NAMEDCOLOR_TURQUOISE = "Turquoise";
      public const string NAMEDCOLOR_VIOLET = "Violet";
      public const string NAMEDCOLOR_ORANGE = "Orange";
      public const string NAMEDCOLOR_BROWN = "Brown";
      public const string NAMEDCOLOR_GOLD = "Gold";
      public const string NAMEDCOLOR_SILVER = "Silver";
      public const string NAMEDCOLOR_PINK = "Pink";
      public const string NAMEDCOLOR_BUFF = "Buff";
      public const string NAMEDCOLOR_IVORY = "Ivory";
      public const string NAMEDCOLOR_GOLDENROD = "Goldenrod";
      public const string NAMEDCOLOR_DARKWHITE = "DarkWhite";
      public const string NAMEDCOLOR_DARKBLACK = "DarkBlack";
      public const string NAMEDCOLOR_DARKGRAY = "DarkGray";
      public const string NAMEDCOLOR_DARKRED = "DarkRed";
      public const string NAMEDCOLOR_DARKYELLOW = "DarkYellow";
      public const string NAMEDCOLOR_DARKGREEN = "DarkGreen";
      public const string NAMEDCOLOR_DARKBLUE = "DarkBlue";
      public const string NAMEDCOLOR_DARKTURQUOISE = "DarkTurquoise";
      public const string NAMEDCOLOR_DARKVIOLET = "DarkViolet";
      public const string NAMEDCOLOR_DARKORANGE = "DarkOrange";
      public const string NAMEDCOLOR_DARKBROWN = "DarkBrown";
      public const string NAMEDCOLOR_DARKGOLD = "DarkGold";
      public const string NAMEDCOLOR_DARKSILVER = "DarkSilver";
      public const string NAMEDCOLOR_DARKPINK = "DarkPink";
      public const string NAMEDCOLOR_DARKBUFF = "DarkBuff";
      public const string NAMEDCOLOR_DARKIVORY = "DarkIvory";
      public const string NAMEDCOLOR_DARKGOLDENROD = "DarkGoldenrod";
      public const string NAMEDCOLOR_DARKMUSTARD = "DarkMustard";
      public const string NAMEDCOLOR_LIGHTWHITE = "LightWhite";
      public const string NAMEDCOLOR_LIGHTBLACK = "LightBlack";
      public const string NAMEDCOLOR_LIGHTGRAY = "LightGray";
      public const string NAMEDCOLOR_LIGHTRED = "LightRed";
      public const string NAMEDCOLOR_LIGHTYELLOW = "LightYellow";
      public const string NAMEDCOLOR_LIGHTGREEN = "LightGreen";
      public const string NAMEDCOLOR_LIGHTBLUE = "LightBlue";
      public const string NAMEDCOLOR_LIGHTTURQUOISE = "LightTurquoise";
      public const string NAMEDCOLOR_LIGHTVIOLET = "LightViolet";
      public const string NAMEDCOLOR_LIGHTORANGE = "LightOrange";
      public const string NAMEDCOLOR_LIGHTBROWN = "LightBrown";
      public const string NAMEDCOLOR_LIGHTGOLD = "LightGold";
      public const string NAMEDCOLOR_LIGHTSILVER = "LightSilver";
      public const string NAMEDCOLOR_LIGHTPINK = "LightPink";
      public const string NAMEDCOLOR_LIGHTBUFF = "LightBuff";
      public const string NAMEDCOLOR_LIGHTIVORY = "LightIvory";
      public const string NAMEDCOLOR_LIGHTGOLDENROD = "LightGoldenrod";
      public const string NAMEDCOLOR_LIGHTMUSTARD = "LightMustard";
      public const string NAMEDCOLOR_CLEARWHITE = "ClearWhite";
      public const string NAMEDCOLOR_CLEARBLACK = "ClearBlack";
      public const string NAMEDCOLOR_CLEARGRAY = "ClearGray";
      public const string NAMEDCOLOR_CLEARRED = "ClearRed";
      public const string NAMEDCOLOR_CLEARGREEN = "ClearGreen";
      public const string NAMEDCOLOR_CLEARBLUE = "ClearBlue";
      public const string NAMEDCOLOR_CLEARTURQUOISE = "ClearTurquoise";
      public const string NAMEDCOLOR_CLEARVIOLET = "ClearViolet";
      public const string NAMEDCOLOR_CLEARORANGE = "ClearOrange";
      public const string NAMEDCOLOR_CLEARBROWN = "ClearBrown";
      public const string NAMEDCOLOR_CLEARGOLD = "ClearGold";
      public const string NAMEDCOLOR_CLEARSILVER = "ClearSilver";
      public const string NAMEDCOLOR_CLEARPINK = "ClearPink";
      public const string NAMEDCOLOR_CLEARBUFF = "ClearBuff";
      public const string NAMEDCOLOR_CLEARIVORY = "ClearIvory";
      public const string NAMEDCOLOR_CLEARGOLDENROD = "ClearGoldenrod";
      public const string NAMEDCOLOR_CLEARMUSTARD = "ClearMustard";
      public const string NAMEDCOLOR_CLEARDARKWHITE = "ClearDarkWhite";
      public const string NAMEDCOLOR_CLEARDARKBLACK = "ClearDarkBlack";
      public const string NAMEDCOLOR_CLEARDARKGRAY = "ClearDarkGray";
      public const string NAMEDCOLOR_CLEARDARKRED = "ClearDarkRed";
      public const string NAMEDCOLOR_CLEARDARKYELLOW = "ClearDarkYellow";
      public const string NAMEDCOLOR_CLEARDARKGREEN = "ClearDarkGreen";
      public const string NAMEDCOLOR_CLEARDARKBLUE = "ClearDarkBlue";
      public const string NAMEDCOLOR_CLEARDARKTURQUOISE = "ClearDarkTurquoise";
      public const string NAMEDCOLOR_CLEARDARKVIOLET = "ClearDarkViolet";
      public const string NAMEDCOLOR_CLEARDARKORANGE = "ClearDarkOrange";
      public const string NAMEDCOLOR_CLEARDARKBROWN = "ClearDarkBrown";
      public const string NAMEDCOLOR_CLEARDARKGOLD = "ClearDarkGold";
      public const string NAMEDCOLOR_CLEARDARKSILVER = "ClearDarkSilver";
      public const string NAMEDCOLOR_CLEARDARKPINK = "ClearDarkPink";
      public const string NAMEDCOLOR_CLEARDARKBUFF = "ClearDarkBuff";
      public const string NAMEDCOLOR_CLEARDARKIVORY = "ClearDarkIvory";
      public const string NAMEDCOLOR_CLEARDARKGOLDENROD = "ClearDarkGoldenrod";
      public const string NAMEDCOLOR_CLEARLIGHTWHITE = "ClearLightWhite";
      public const string NAMEDCOLOR_CLEARLIGHTBLACK = "ClearLightBlack";
      public const string NAMEDCOLOR_CLEARLIGHTGRAY = "ClearLightGray";
      public const string NAMEDCOLOR_CLEARLIGHTRED = "ClearLightRed";
      public const string NAMEDCOLOR_CLEARLIGHTYELLOW = "ClearLightYellow";
      public const string NAMEDCOLOR_CLEARLIGHTGREEN = "ClearLightGreen";
      public const string NAMEDCOLOR_CLEARLIGHTBLUE = "ClearLightBlue";
      public const string NAMEDCOLOR_CLEARLIGHTTURQUOISE = "ClearLightTurquoise";
      public const string NAMEDCOLOR_CLEARLIGHTVIOLET = "ClearLightViolet";
      public const string NAMEDCOLOR_CLEARLIGHTORANGE = "ClearLightOrange";
      public const string NAMEDCOLOR_CLEARLIGHTBROWN = "ClearLightBrown";
      public const string NAMEDCOLOR_CLEARLIGHTGOLD = "ClearLightGold";
      public const string NAMEDCOLOR_CLEARLIGHTSILVER = "ClearLightSilver";
      public const string NAMEDCOLOR_CLEARLIGHTPINK = "ClearLightPink";
      public const string NAMEDCOLOR_CLEARLIGHTBUFF = "ClearLightBuff";
      public const string NAMEDCOLOR_CLEARLIGHTIVORY = "ClearLightIvory";
      public const string NAMEDCOLOR_CLEARLIGHTGOLDENROD = "ClearLightGoldenrod";
      public const string NAMEDCOLOR_CLEARLIGHTMUSTARD = "ClearLightMustard";
      public const string NAMEDCOLOR_MULTICOLOR = "MultiColor";
      public const string NAMEDCOLOR_NOCOLOR = "NoColor";

      ///   
      ///	 <summary> * Enumeration for CleanUpMerge Used by JDFNode </summary>
      ///	 
      public const string CLEANUPMERGE_NONE = "None";
      public const string CLEANUPMERGE_REMOVERREFS = "RemoverRefs";
      public const string CLEANUPMERGE_REMOVEALL = "RemoveAll";

      public const string SETTINGSPOLICY_UNKNOWN = "Unknown";
      public const string SETTINGSPOLICY_BESTEFFORT = "BestEffort";
      public const string SETTINGSPOLICY_MUSTHONOR = "MustHonor";
      public const string SETTINGSPOLICY_OPERATORINTERVENTION = "OperatorIntervention";

      public const string ATTRIBUTETYPE_UNKNOWN = "Unknown";
      public const string ATTRIBUTETYPE_ANY = "Any";
      public const string ATTRIBUTETYPE_BOOLEAN = "boolean_";
      public const string ATTRIBUTETYPE_DOUBLE = "double_";
      public const string ATTRIBUTETYPE_INTEGER = "integer";
      public const string ATTRIBUTETYPE_NMTOKEN = "NMTOKEN";
      public const string ATTRIBUTETYPE_NMTOKENS = "NMTOKENS";
      public const string ATTRIBUTETYPE_ENUMERATION = "enumeration";
      public const string ATTRIBUTETYPE_ENUMERATIONS = "enumerations";
      public const string ATTRIBUTETYPE_NUMBERRANGE = "NumberRange";
      public const string ATTRIBUTETYPE_NUMBERRANGELIST = "NumberRangeList";
      public const string ATTRIBUTETYPE_STRING = "string";
      public const string ATTRIBUTETYPE_SHORTSTRING = "shortString";
      public const string ATTRIBUTETYPE_INTEGERRANGE = "IntegerRange";
      public const string ATTRIBUTETYPE_INTEGERLIST = "IntegerList";
      public const string ATTRIBUTETYPE_INTEGERRANGELIST = "IntegerRangeList";
      public const string ATTRIBUTETYPE_MATRIX = "matrix";
      public const string ATTRIBUTETYPE_RECTANGLE = "rectangle";
      public const string ATTRIBUTETYPE_XYPAIR = "XYPair";
      public const string ATTRIBUTETYPE_URL = "URL";
      public const string ATTRIBUTETYPE_ID = "ID";
      public const string ATTRIBUTETYPE_DATETIME = "dateTime";
      public const string ATTRIBUTETYPE_DURATION = "duration";
      public const string ATTRIBUTETYPE_SHAPE = "shape";
      public const string ATTRIBUTETYPE_IDREFS = "IDREFS";
      public const string ATTRIBUTETYPE_IDREF = "IDREF";
      public const string ATTRIBUTETYPE_RECTANGLERANGE = "RectangleRange";
      public const string ATTRIBUTETYPE_RECTANGLERANGELIST = "RectangleRangeList";
      public const string ATTRIBUTETYPE_DURATIONRANGE = "DurationRange";
      public const string ATTRIBUTETYPE_DURATIONRANGELIST = "DurationRangeList";
      public const string ATTRIBUTETYPE_DATETIMERANGE = "DateTimeRange";
      public const string ATTRIBUTETYPE_DATETIMERANGELIST = "DateTimeRangeList";
      public const string ATTRIBUTETYPE_SHAPERANGE = "ShapeRange";
      public const string ATTRIBUTETYPE_SHAPERANGELIST = "ShapeRangeList";
      public const string ATTRIBUTETYPE_NAMERANGE = "NameRange";
      public const string ATTRIBUTETYPE_NAMERANGELIST = "NameRangeList";
      public const string ATTRIBUTETYPE_URI = "URI";
      public const string ATTRIBUTETYPE_REGEXP = "RegExp";
      public const string ATTRIBUTETYPE_PDFPATH = "PDFPath";
      public const string ATTRIBUTETYPE_NUMBERLIST = "NumberList";
      public const string ATTRIBUTETYPE_XYPAIRRANGE = "XYPairRange";
      public const string ATTRIBUTETYPE_XYPAIRRANGELIST = "XYPairRangeList";
      public const string ATTRIBUTETYPE_XYRELATION = "XYRelation";
      public const string ATTRIBUTETYPE_JDFJMFVERSION = "JDFJMFVersion";
      public const string ATTRIBUTETYPE_LANGUAGE = "language";
      public const string ATTRIBUTETYPE_CMYKCOLOR = "CMYKColor";
      public const string ATTRIBUTETYPE_HEXBINARY = "hexBinary";
      public const string ATTRIBUTETYPE_LABCOLOR = "LabColor";
      public const string ATTRIBUTETYPE_LANGUAGES = "languages";
      public const string ATTRIBUTETYPE_RGBCOLOR = "RGBColor";
      public const string ATTRIBUTETYPE_TRANSFERFUNCTION = "TransferFunction";
      public const string ATTRIBUTETYPE_XPATH = "XPath";

      public const string CHANNELTYPE_PHONE = "Phone";
      public const string CHANNELTYPE_EMAIL = "Email";
      public const string CHANNELTYPE_FAX = "Fax";
      public const string CHANNELTYPE_WWW = "WWW";
      public const string CHANNELTYPE_JMF = "JMF";
      public const string CHANNELTYPE_PRIVATEDIRECTORY = "PrivateDirectory";
      public const string CHANNELTYPE_INSTANTMESSAGING = "InstantMessaging";

      public const string CONTACTTYPES_ACCOUNTING = "Accounting";
      public const string CONTACTTYPES_ADMINISTRATOR = "Administrator";
      public const string CONTACTTYPES_APPROVER = "Approver";
      public const string CONTACTTYPES_ARTRETURN = "ArtReturn";
      public const string CONTACTTYPES_BILLING = "Billing";
      public const string CONTACTTYPES_CUSTOMER = "Customer";
      public const string CONTACTTYPES_DELIVERY = "Delivery";
      public const string CONTACTTYPES_DELIVERYCHARGE = "DeliveryCharge";
      public const string CONTACTTYPES_OWNER = "Owner";
      public const string CONTACTTYPES_PICKUP = "Pickup";
      public const string CONTACTTYPES_SENDER = "Sender";
      public const string CONTACTTYPES_SUPPLIER = "Supplier";
      public const string CONTACTTYPES_SURPLUSRETURN = "SurplusReturn";

      ///   
      ///	 <summary> * Enumeration for EnumPoolType Used by JDFElement </summary>
      ///	 
      public const string POOLTYPE_UNKNOWN = "Unknown";
      public const string POOLTYPE_RESOURCEPOOL = "ResourcePool";
      public const string POOLTYPE_RESOURCELINKPOOL = "ResourceLinkPool";
      public const string POOLTYPE_ANCESTORPOOL = "AncestorPool";
      public const string POOLTYPE_AUDITPOOL = "AuditPool";
      public const string POOLTYPE_RESOURCECMDPARAMS = "ResourceCmdParams";
      public const string POOLTYPE_RESOURCEINFO = "ResourceInfo";
      public const string POOLTYPE_PHASETIME = "PhaseTime";
      public const string POOLTYPE_PRODUCTIONINTENT = "ProductionIntent";

      public const string IMAGEFILTER_UNKNOWN = "Unknown";
      public const string IMAGEFILTER_CCITTFAXENCODE = "CCITTFaxEncode";
      public const string IMAGEFILTER_DCTENCODE = "DCTEncode";
      public const string IMAGEFILTER_FLATENCODE = "FlateEncode";

      // MIME types
      public const string MIME_PNG = "image/x-png";
      public const string MIME_TIFF = "image/tiff";
      public const string MIME_PDF = "application/pdf";
      public const string MIME_JPG = "image/jpeg";
      public const string MIME_PS = "application/postscript";
      public const string MIME_EPS = "application/postscript";
      public const string MIME_JDF = "application/vnd.cip4-jdf+xml";
      public const string MIME_JMF = "application/vnd.cip4-jmf+xml";
      public const string MIME_CIP3 = "application/vnd.cip3-ppf";
      public const string MIME_PPML = "application/vnd.podi-ppml+xml";
      public const string MIME_TEXTUNKNOWN = "text/unknown";
      public const string MIME_TEXTXML = "text/xml";

      // JDFSheet Surface definitions
      public const string SIDE_FRONT = "Front";
      public const string SIDE_BACK = "Back";

      public const string ORIENTATION_UNKNOWN = "Unknown";
      public const string ORIENTATION_FLIP0 = "Flip0";
      public const string ORIENTATION_FLIP90 = "Flip90";
      public const string ORIENTATION_FLIP180 = "Flip180";
      public const string ORIENTATION_FLIP270 = "Flip270";
      public const string ORIENTATION_ROTATE0 = "Rotate0";
      public const string ORIENTATION_ROTATE90 = "Rotate90";
      public const string ORIENTATION_ROTATE180 = "Rotate180";
      public const string ORIENTATION_ROTATE270 = "Rotate270";

      public const string XYRELATION_UNKNOWN = "Unknown";
      public const string XYRELATION_GT = "gt";
      public const string XYRELATION_GE = "ge";
      public const string XYRELATION_EQ = "eq";
      public const string XYRELATION_LE = "le";
      public const string XYRELATION_LT = "lt";
      public const string XYRELATION_NE = "ne";

      public const string SEPARATION_UNKNOWN = "Unknown";
      public const string SEPARATION_CYAN = "cyan";
      public const string SEPARATION_MAGENTA = "magenta";
      public const string SEPARATION_YELLOW = "yellow";
      public const string SEPARATION_BLACK = "black";
      public const string SEPARATION_RED = "red";
      public const string SEPARATION_GREEN = "green";
      public const string SEPARATION_BLUE = "blue";
      public const string SEPARATION_ORANGE = "orange";
      public const string SEPARATION_SPOT = "spot";
      public const string SEPARATION_VARNISH = "varnish";

      public const string FITSVALUE_UNKNOWN = "Unknown";
      public const string FITSVALUE_ALLOWED = "Allowed";
      public const string FITSVALUE_PRESENT = "Present";

      public const string CLASS_UNKNOWN = "Unknown";
      public const string CLASS_CONSUMABLE = "Consumable";
      public const string CLASS_HANDLING = "Handling";
      public const string CLASS_INTENT = "Intent";
      public const string CLASS_IMPLEMENTATION = "Implementation";
      public const string CLASS_PARAMETER = "Parameter";
      public const string CLASS_PLACEHOLDER = "PlaceHolder";
      public const string CLASS_QUANTITY = "Quantity";

      public const string ATTRIBUTEVALIDITY_UNKNOWN = "Unknown";
      public const string ATTRIBUTEVALIDITY_NONE = "None";
      public const string ATTRIBUTEVALIDITY_REQUIRED = "Required";
      public const string ATTRIBUTEVALIDITY_OPTIONAL = "Optional";
      public const string ATTRIBUTEVALIDITY_DEPRECATED = "Deprecated";
      public const string ATTRIBUTEVALIDITY_MISSINGOPTIONAL = "MissingOptional";
      public const string ATTRIBUTEVALIDITY_MISSINGREQUIRED = "MissingRequired";
      public const string ATTRIBUTEVALIDITY_ANY = "Any";

      public const string ELEMENTVALIDITY_UNKNOWN = "Unknown";
      public const string ELEMENTVALIDITY_NONE = "None";
      public const string ELEMENTVALIDITY_REQUIRED = "Required";
      public const string ELEMENTVALIDITY_OPTIONAL = "Optional";
      public const string ELEMENTVALIDITY_DEPRECATED = "Deprecated";
      public const string ELEMENTVALIDITY_SINGLEOPTIONAL = "SingleOptional";
      public const string ELEMENTVALIDITY_SINGLEREQUIRED = "SingleRequired";
      public const string ELEMENTVALIDITY_SINGLEDEPRECATED = "SingleDeprecated";
      public const string ELEMENTVALIDITY_DUMMY = "Dummy";

      public const string VALIDATIONLEVEL_UNKNOWN = "Unknown";
      public const string VALIDATIONLEVEL_NONE = "None";
      public const string VALIDATIONLEVEL_CONSTRUCT = "Construct";
      public const string VALIDATIONLEVEL_COMPLETE = "Complete";
      public const string VALIDATIONLEVEL_INCOMPLETE = "Incomplete";
      public const string VALIDATIONLEVEL_RECURSIVEINCOMPLETE = "RecursiveIncomplete";
      public const string VALIDATIONLEVEL_RECURSIVECOMPLETE = "RecursiveComplete";

      public const string WORKTYPEDETAILS_USERERROR = "UserError";
      public const string WORKTYPEDETAILS_EQUIPMENTMALFUNCTION = "EquipmentMalfunction";
      public const string WORKTYPEDETAILS_RESOURCEDAMAGED = "ResourceDamaged";
      public const string WORKTYPEDETAILS_INTERNALCHANGE = "InternalChange";
      public const string WORKTYPEDETAILS_CUSTOMERREQUEST = "CustomerRequest";

      public const string BOOLEAN_UNKNOWN = "Unknown";
      public const string BOOLEAN_TRUE = "true";
      public const string BOOLEAN_FALSE = "false";

      public const string REGEXP_HEXBINARY = "([0-9a-fA-F]{2})+";
      public const string REGEXP_EMAIL = "(mailto:)?([_.a-zA-Z0-9\\-])+[@]([_.a-zA-Z0-9\\-])+[.]([_.a-zA-Z0-9\\-])+";
      public const string REGEXP_PHONE = "(tel:)?([+])?(([0-9./\\-])|[(]([0-9./\\-])[)])+";

      public const string JDFELEMENT = "JDFElement";
      public const string JDFNODE = "JDFNode";

   }
}
