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
 * Copyright (c) 2001-2004 Heidelberger Druckmaschinen AG, All Rights Reserved.
 * JDFElement.cs
 * Last changes
 * 2001-07-30   Torsten Kaehlert - delete isNull() and throwNull() methods in parent class KNode
 *              TKAE20010730
 * 2002-07-02 JG add SettingsPolicy Support
 * 2002-07-02 JG removed AppendElement - it is now only in KElement
 * 2002-07-02 JG added IsJDFNode()
 * 2002-07-02 JG added RemoveChild() / RemoveChildren
 * 2002-07-02 JG GetEnumerationsAttribute() bug fix in loop counter
 * 2002-07-02 JG removed GetTarget(int id,const KString & attrib) const;
 * 2002-07-02 JG GetJDFRoot, GetJMFRoot now const
 * 2002-07-02 JG GetLinks added rSubRef check to map of checked attributes
 * 2002-07-02 JG added NamedColor support
 * 2002-07-02 JG GetElement - added a check that returns the refElement if a refElement is explicitly required */


namespace org.cip4.jdflib.core
{
   using System;
   using System.Runtime.CompilerServices;
   using System.Collections;
   using System.Collections.Generic;
   using System.Reflection;
   using System.IO;
   using System.Net.Mail;
   using System.Xml;

   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;
   using EnumQueueEntryStatus = org.cip4.jdflib.auto.JDFAutoQueueEntry.EnumQueueEntryStatus;
   using EnumAttributeType = org.cip4.jdflib.core.AttributeInfo.EnumAttributeType;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using JDFDateTimeRangeList = org.cip4.jdflib.datatypes.JDFDateTimeRangeList;
   using JDFDurationRangeList = org.cip4.jdflib.datatypes.JDFDurationRangeList;
   using JDFIntegerRange = org.cip4.jdflib.datatypes.JDFIntegerRange;
   using JDFIntegerRangeList = org.cip4.jdflib.datatypes.JDFIntegerRangeList;
   using JDFNameRange = org.cip4.jdflib.datatypes.JDFNameRange;
   using JDFNameRangeList = org.cip4.jdflib.datatypes.JDFNameRangeList;
   using JDFNumList = org.cip4.jdflib.datatypes.JDFNumList;
   using JDFNumberRange = org.cip4.jdflib.datatypes.JDFNumberRange;
   using JDFNumberRangeList = org.cip4.jdflib.datatypes.JDFNumberRangeList;
   using JDFRectangleRangeList = org.cip4.jdflib.datatypes.JDFRectangleRangeList;
   using JDFShapeRangeList = org.cip4.jdflib.datatypes.JDFShapeRangeList;
   using JDFXYPairRange = org.cip4.jdflib.datatypes.JDFXYPairRange;
   using JDFXYPairRangeList = org.cip4.jdflib.datatypes.JDFXYPairRangeList;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using JDFJMF = org.cip4.jdflib.jmf.JDFJMF;
   using JDFMessage = org.cip4.jdflib.jmf.JDFMessage;
   using JDFAncestor = org.cip4.jdflib.node.JDFAncestor;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using JDFResourcePool = org.cip4.jdflib.pool.JDFResourcePool;
   using JDFPart = org.cip4.jdflib.resource.JDFPart;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using EnumResStatus = org.cip4.jdflib.resource.JDFResource.EnumResStatus;
   using ContainerUtil = org.cip4.jdflib.util.ContainerUtil;
   using JDFDate = org.cip4.jdflib.util.JDFDate;
   using JDFDuration = org.cip4.jdflib.util.JDFDuration;
   using StringUtil = org.cip4.jdflib.util.StringUtil;
   using UrlUtil = org.cip4.jdflib.util.UrlUtil;

   ///
   /// <summary> * @author Dietrich Mucha
   /// * JDFElement contains generic JDF element functionality
   /// * in general only elements in the JDF namespace will inherit from JDFElement </summary>
   /// 
   ///
   /// <summary> * @author boegerni
   /// *  </summary>
   /// 
   public class JDFElement : KElement
   {
      private new const long serialVersionUID = 1L;

      private static EnumVersion defaultVersion = EnumVersion.Version_1_3;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[6];
      static JDFElement()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.SETTINGSPOLICY, 0x33333311, AttributeInfo.EnumAttributeType.enumeration, EnumSettingsPolicy.getEnum(0), null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.COMMENTURL, 0x33333333, AttributeInfo.EnumAttributeType.URL, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.DESCRIPTIVENAME, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.BESTEFFORTEXCEPTIONS, 0x33333331, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.MUSTHONOREXCEPTIONS, 0x33333331, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.OPERATORINTERVENTIONEXCEPTIONS, 0x33333331, AttributeInfo.EnumAttributeType.NMTOKENS, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.COMMENT, 0x33333333);
      }
      // Java to C# Conversion
      // java format string was "yyMMdd_kkmmssSS".
      // yy, MM, dd, mm, ss map exactly.
      // C# HH is 0..23, while java kk is 1..24
      // C# fff maps to java SSS. No mapping to java SS. fff is closer to SS than ff is.
      private const string dateFormatter = "yyMMdd_HHmmssfff";

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return getTheAttributeInfo_JDFElement();
      }

      protected internal virtual AttributeInfo getTheAttributeInfo_JDFElement()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }

      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[1];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }

      protected internal virtual ElementInfo getTheElementInfo_JDFElement()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }

      ///   
      ///	 <summary> * Constructor for JDFElement
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> the DOM document where this elements will be inserted </param>
      ///	 * <param name="qualifiedName"> the qualified name of the element (see www.w3.org/XML/) </param>
      ///	 
      public JDFElement(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, getSchemaURL(), qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFElement
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> the DOM document where this elements will be inserted </param>
      ///	 * <param name="myNamespaceURI"> the namespace of the elements to (see www.w3.org/XML/) </param>
      ///	 * <param name="qualifiedName"> the qualified name of the element </param>
      ///	 
      public JDFElement(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI == null ? getSchemaURL() : myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFElement
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> the DOM document where this elements will be inserted </param>
      ///	 * <param name="myNamespaceURI"> the namespace of the elements to create </param>
      ///	 * <param name="qualifiedName"> the qualified name of the element (see www.w3.org/XML/) </param>
      ///	 * <param name="myLocalName"> the local name of the element (see www.w3.org/XML/) </param>
      ///	 
      public JDFElement(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI == null ? getSchemaURL() : myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      ///   
      ///	 <summary> * Boolean Enumeration from JDF Spec Orientation of a physical resource. </summary>
      ///	 
      public sealed class EnumBoolean : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumBoolean(string name)
            : base(name.ToLower(), m_startValue++)
         {
         }

         ///      
         ///		 * <param name="enumName"> the name of the enum object to return </param>
         ///		 * <returns> the enum object if enumName is valid. Otherwise null </returns>
         ///		 
         public static EnumBoolean getEnum(string enumName)
         {
            return (EnumBoolean)getEnum(typeof(EnumBoolean), enumName.ToLower());
         }

         ///      
         ///		 * <param name="enumValue"> the value of the enum object to return </param>
         ///		 * <returns> the enum object if enumName is valid. Otherwise null </returns>
         ///		 
         public static EnumBoolean getEnum(int enumValue)
         {
            return (EnumBoolean)getEnum(typeof(EnumBoolean), enumValue);
         }

         ///      
         ///		 * <returns> a map of all orientation enums </returns>
         ///		 
         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumBoolean));
         }

         ///      
         ///		 * <returns> a list of all orientation enums </returns>
         ///		 
         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumBoolean));
         }

         ///      
         ///		 * <returns> an iterator over the enum objects </returns>
         ///		 
         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumBoolean));
         }

         // enums for validation of booleans
         public static readonly EnumBoolean True = new EnumBoolean(JDFConstants.BOOLEAN_TRUE);
         public static readonly EnumBoolean False = new EnumBoolean(JDFConstants.BOOLEAN_FALSE);
      }

      ///   
      ///	 <summary> * Orientation Enumeration <br>
      ///	 * Orientation of a physical resource. </summary>
      ///	 
      public sealed class EnumOrientation : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumOrientation(string name)
            : base(name, m_startValue++)
         {
         }

         ///      
         ///		 * <param name="enumName"> the name of the enum object to return </param>
         ///		 * <returns> the enum object if enumName is valid. Otherwise null </returns>
         ///		 
         public static EnumOrientation getEnum(string enumName)
         {
            return (EnumOrientation)getEnum(typeof(EnumOrientation), enumName);
         }

         ///      
         ///		 * <param name="enumValue"> the value of the enum object to return </param>
         ///		 * <returns> the enum object if enumName is valid. Otherwise null </returns>
         ///		 
         public static EnumOrientation getEnum(int enumValue)
         {
            return (EnumOrientation)getEnum(typeof(EnumOrientation), enumValue);
         }

         ///      
         ///		 * <returns> a map of all orientation enums </returns>
         ///		 
         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumOrientation));
         }

         ///      
         ///		 * <returns> a list of all orientation enums </returns>
         ///		 
         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumOrientation));
         }

         ///      
         ///		 * <returns> an iterator over the enum objects </returns>
         ///		 
         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumOrientation));
         }

         // enums accordng to JDF spec A.3.3.3, Table 3-3 Orientation
         public static readonly EnumOrientation Flip0 = new EnumOrientation(JDFConstants.ORIENTATION_FLIP0);
         public static readonly EnumOrientation Flip90 = new EnumOrientation(JDFConstants.ORIENTATION_FLIP90);
         public static readonly EnumOrientation Flip180 = new EnumOrientation(JDFConstants.ORIENTATION_FLIP180);
         public static readonly EnumOrientation Flip270 = new EnumOrientation(JDFConstants.ORIENTATION_FLIP270);
         public static readonly EnumOrientation Rotate0 = new EnumOrientation(JDFConstants.ORIENTATION_ROTATE0);
         public static readonly EnumOrientation Rotate90 = new EnumOrientation(JDFConstants.ORIENTATION_ROTATE90);
         public static readonly EnumOrientation Rotate180 = new EnumOrientation(JDFConstants.ORIENTATION_ROTATE180);
         public static readonly EnumOrientation Rotate270 = new EnumOrientation(JDFConstants.ORIENTATION_ROTATE270);
      }

      ///   
      ///	 <summary> * XYRelation Enumeration <br>
      ///	 * XML attributes of type XYRelation define the relationship between two ordered numbers. <br>
      ///	 * gt X>Y <br>
      ///	 * ge X>=Y <br>
      ///	 * eq X==Y <br>
      ///	 * le X<=Y <br>
      ///	 * lt X<Y <br>
      ///	 * ne X!=Y <br>
      ///	 * see JDF Spec (Appendix A.3.4) for latest changes </summary>
      ///	 
      public sealed class EnumXYRelation : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumXYRelation(string name)
            : base(name, m_startValue++)
         {
         }

         ///      
         ///		 * <param name="enumName"> the name of the enum object to return </param>
         ///		 * <returns> the enum object if enumName is valid. Otherwise null </returns>
         ///		 
         public static EnumXYRelation getEnum(string enumName)
         {
            return (EnumXYRelation)getEnum(typeof(EnumXYRelation), enumName);
         }

         ///      
         ///		 * <param name="enumValue"> the value of the enum object to return </param>
         ///		 * <returns> the enum object if enumName is valid. Otherwise null </returns>
         ///		 
         public static EnumXYRelation getEnum(int enumValue)
         {
            return (EnumXYRelation)getEnum(typeof(EnumXYRelation), enumValue);
         }

         ///      
         ///		 * <returns> a map of all XYRelation enums </returns>
         ///		 
         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumXYRelation));
         }

         ///      
         ///		 * <returns> a list of all XYRelation enums </returns>
         ///		 
         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumXYRelation));
         }

         ///      
         ///		 * <returns> an iterator over the enum objects </returns>
         ///		 
         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumXYRelation));
         }

         // enums accordng to JDF spec 3.1.2, Table 3-3 Status
         public static readonly EnumXYRelation gt = new EnumXYRelation(JDFConstants.XYRELATION_GT);
         public static readonly EnumXYRelation ge = new EnumXYRelation(JDFConstants.XYRELATION_GE);
         public static readonly EnumXYRelation eq = new EnumXYRelation(JDFConstants.XYRELATION_EQ);
         public static readonly EnumXYRelation le = new EnumXYRelation(JDFConstants.XYRELATION_LE);
         public static readonly EnumXYRelation lt = new EnumXYRelation(JDFConstants.XYRELATION_LT);
         public static readonly EnumXYRelation ne = new EnumXYRelation(JDFConstants.XYRELATION_NE);

         ///      
         ///		 <summary> * xyRelation - tests if relation x/y matches XYRelation enumeration value
         ///		 *  </summary>
         ///		 * <param name="x"> x in XYRelation ( x/y ) </param>
         ///		 * <param name="y"> y in XYRelation ( x/y ) </param>
         ///		 * <param name="nt"> negative tolerance </param>
         ///		 * <param name="pt"> positive tolerance </param>
         ///		 * <returns> true, if relation x/y matches specified enumerated value </returns>
         ///		 
         public bool evaluateXY(double x, double y, double nt, double pt)
         {
            if (this == EnumXYRelation.gt)
            {
               return x + pt > y - nt;
            }
            else if (this == EnumXYRelation.ge)
            {
               return x + pt >= y - nt;
            }
            else if (this == EnumXYRelation.eq)
            {
               return x >= y - nt && x <= y + pt;
            }
            else if (this == EnumXYRelation.le)
            {
               return x - nt <= y + pt;
            }
            else if (this == EnumXYRelation.lt)
            {
               return x - nt < y + pt;
            }
            else if (this == EnumXYRelation.ne)
            {
               return x < y - nt || x > y + pt;
            }
            else
            {
               return true;
            }
         }

      }

      ///   
      ///	 <summary> * Separation Enumeration identifies the separation name.
      ///	 * <p>
      ///	 * Possible values include:
      ///	 * <p>
      ///	 * <ul>
      ///	 * <li><b>Composite</b> - Non-separated resource.
      ///	 * <li><b>Separated</b> - The resource is separated, but the separation definition is handled internally by the
      ///	 * resource, such as a PDF file that contains SeparationInfo dictionaries.
      ///	 * <li><b>Cyan</b> - Process color.
      ///	 * <li><b>Magenta</b> - Process color.
      ///	 * <li><b>Yellow</b> - Process color.
      ///	 * <li><b>Black</b> - Process color.
      ///	 * <li><b>Red</b> - Additional process color.
      ///	 * <li><b>Green</b> - Additional process color.
      ///	 * <li><b>Blue</b> - Additional process color.
      ///	 * <li><b>Orange</b> - Additional process color.
      ///	 * <li><b>Spot</b> - Generic spot color. Used when the exact nature of the spot color is unknown.
      ///	 * <li><b>Varnish</b> - Varnish.
      ///	 * </ul>
      ///	 * Other values may be any separation name defined in the Name attribute of a
      ///	 * <seealso cref="org.cip4.jdflib.resource.process.JDFColor"/> element in the
      ///	 * <seealso cref="org.cip4.jdflib.resource.process.JDFColorPool"/>. When Separation is applied to a ColorantControlLink, it
      ///	 * defines an implicit partition that selects a subset of separations for the process that is described by the
      ///	 * ColorantControl. </summary>
      ///	 
      public sealed class EnumSeparation : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumSeparation(string name)
            : base(name, m_startValue++)
         {
         }

         ///      
         ///		 * <param name="enumName"> the name of the enum object to return </param>
         ///		 * <returns> the enum object if enumName is valid. Otherwise null </returns>
         ///		 
         public static EnumSeparation getEnum(string enumName)
         {
            return (EnumSeparation)getEnum(typeof(EnumSeparation), enumName);
         }

         ///      
         ///		 * <param name="enumValue"> the value of the enum object to return </param>
         ///		 * <returns> the enum object if enumName is valid. Otherwise null </returns>
         ///		 
         public static EnumSeparation getEnum(int enumValue)
         {
            return (EnumSeparation)getEnum(typeof(EnumSeparation), enumValue);
         }

         ///      
         ///		 * <returns> a map of all orientation enums </returns>
         ///		 
         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumSeparation));
         }

         ///      
         ///		 * <returns> a list of all orientation enums </returns>
         ///		 
         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumSeparation));
         }

         ///      
         ///		 * <returns> an iterator over the enum objects </returns>
         ///		 
         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumSeparation));
         }

         // enums accordng to JDF spec Table 3-28: Contents of the Part element
         public static readonly EnumSeparation Cyan = new EnumSeparation(JDFConstants.SEPARATION_CYAN);
         public static readonly EnumSeparation Magenta = new EnumSeparation(JDFConstants.SEPARATION_MAGENTA);
         public static readonly EnumSeparation Yellow = new EnumSeparation(JDFConstants.SEPARATION_YELLOW);
         public static readonly EnumSeparation Black = new EnumSeparation(JDFConstants.SEPARATION_BLACK);
         public static readonly EnumSeparation Red = new EnumSeparation(JDFConstants.SEPARATION_RED);
         public static readonly EnumSeparation Green = new EnumSeparation(JDFConstants.SEPARATION_GREEN);
         public static readonly EnumSeparation Blue = new EnumSeparation(JDFConstants.SEPARATION_BLUE);
         public static readonly EnumSeparation Orange = new EnumSeparation(JDFConstants.SEPARATION_ORANGE);
         public static readonly EnumSeparation Spot = new EnumSeparation(JDFConstants.SEPARATION_SPOT);
         public static readonly EnumSeparation Varnish = new EnumSeparation(JDFConstants.SEPARATION_VARNISH);
      }

      ///   
      ///	 <summary> * Enumeration of various pool types </summary>
      ///	 
      public sealed class EnumPoolType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumPoolType(string name)
            : base(name, m_startValue++)
         {
         }

         ///      
         ///		 * <param name="enumName"> the name of the enum object to return </param>
         ///		 * <returns> the enum object if enumName is valid. Otherwise null </returns>
         ///		 
         public static EnumPoolType getEnum(string enumName)
         {
            return (EnumPoolType)getEnum(typeof(EnumPoolType), enumName);
         }

         ///      
         ///		 * <param name="enumValue"> the value of the enum object to return </param>
         ///		 * <returns> the enum object if enumName is valid. Otherwise null </returns>
         ///		 
         public static EnumPoolType getEnum(int enumValue)
         {
            return (EnumPoolType)getEnum(typeof(EnumPoolType), enumValue);
         }

         ///      
         ///		 * <returns> a map of all orientation enums </returns>
         ///		 
         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumPoolType));
         }

         ///      
         ///		 * <returns> a list of all orientation enums </returns>
         ///		 
         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumPoolType));
         }

         ///      
         ///		 * <returns> an iterator over the enum objects </returns>
         ///		 
         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumPoolType));
         }

         public static readonly EnumPoolType RefElement = new EnumPoolType(ElementName.REFELEMENT);
         public static readonly EnumPoolType ResourcePool = new EnumPoolType(ElementName.RESOURCEPOOL);
         public static readonly EnumPoolType PipeParams = new EnumPoolType(ElementName.PIPEPARAMS);
         public static readonly EnumPoolType ResourceLinkPool = new EnumPoolType(ElementName.RESOURCELINKPOOL);
         public static readonly EnumPoolType AncestorPool = new EnumPoolType(ElementName.ANCESTORPOOL);
         public static readonly EnumPoolType AuditPool = new EnumPoolType(ElementName.AUDITPOOL);
         public static readonly EnumPoolType ProductionIntent = new EnumPoolType(ElementName.PRODUCTIONINTENT);
      }

      ///   
      ///	 <summary> * Enumeration of valid nodestatus types Identifies the status of the node. Possible values are:
      ///	 * <p>
      ///	 * <ul>
      ///	 * <li><b>Waiting</b> - The node may be executed, but it has not completed a test run.
      ///	 * <li><b>TestRunInProgress</b> - The node is currently executing a test run.
      ///	 * <li><b>Ready</b> - As indicated by the successful completion of a test run, all ResourceLinks are correct,
      ///	 * required resources are available, and the parameters of resources are valid. The node is ready to start.
      ///	 * <li><b>FailedTestRun</b> - An error occurred during the test run. Error information is logged in the Notification
      ///	 * element, which is an optional subelement of the AuditPool element described in Section 3.9, AuditPool.
      ///	 * <li><b>Setup</b> - The process represented by this node is currently being set up.
      ///	 * <li><b>InProgress</b> - The node is currently executing.
      ///	 * <li><b>Cleanup</b> - The process represented by this node is currently being cleaned up.
      ///	 * <li><b>Spawned</b> - The node is spawned in the form of a separate spawned JDF. The status Spawned can only be
      ///	 * assigned to the original instance of the spawned job. For details, see Section 4.4, Spawning and Merging.
      ///	 * <li><b>Stopped</b> - Execution has been stopped. If a job is Stopped, running may be resumed later. This status
      ///	 * may indicate a break, a pause, maintenance, or a breakdown - in short, any pause that does not lead the job to be
      ///	 * aborted.
      ///	 * <li><b>Completed</b> - Indicates that the node has been executed correctly, and is finished.
      ///	 * <li><b>Aborted</b> - Indicates that the process executing the node has been aborted, which means that execution
      ///	 * will not be resumed again.
      ///	 * <li><b>Pool</b> - Indicates that the node processes partitioned resources and that the Status varies depending on
      ///	 * the partition keys. Details are provided in the StatusPool element of the node.
      ///	 * <p>
      ///	 * Derivation of the Status of a parent node from the Status of child nodes is non-trivial and
      ///	 * implementation-dependent
      ///	 * </ul> </summary>
      ///	 
      public sealed class EnumNodeStatus : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumNodeStatus(string name)
            : base(name, m_startValue++)
         {
         }

         ///      
         ///		 * <param name="enumName"> the name of the enum object to return </param>
         ///		 * <returns> the enum object if enumName is valid. Otherwise null </returns>
         ///		 
         public static EnumNodeStatus getEnum(string enumName)
         {
            return (EnumNodeStatus)getEnum(typeof(EnumNodeStatus), enumName);
         }

         ///      
         ///		 * <param name="enumValue"> the value of the enum object to return </param>
         ///		 * <returns> the enum object if enumName is valid. Otherwise null </returns>
         ///		 
         public static EnumNodeStatus getEnum(int enumValue)
         {
            return (EnumNodeStatus)getEnum(typeof(EnumNodeStatus), enumValue);
         }

         ///      
         ///		 * <returns> a map of all orientation enums </returns>
         ///		 
         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumNodeStatus));
         }

         ///      
         ///		 * <returns> a list of all orientation enums </returns>
         ///		 
         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumNodeStatus));
         }

         ///      
         ///		 <summary> * returns the queuentrystatus corresponding to a node status
         ///		 *  </summary>
         ///		 * <param name="ns"> the node status to test agains </param>
         ///		 * <returns> the queentrystatus that corresponds to ns; may be null in case of pool or part </returns>
         ///		 
         public static EnumQueueEntryStatus getQueueEntryStatus(EnumNodeStatus ns)
         {
            if (EnumNodeStatus.Waiting.Equals(ns))
               return EnumQueueEntryStatus.Waiting;
            if (EnumNodeStatus.TestRunInProgress.Equals(ns))
               return EnumQueueEntryStatus.Waiting;
            if (EnumNodeStatus.Ready.Equals(ns))
               return EnumQueueEntryStatus.Waiting;
            if (EnumNodeStatus.FailedTestRun.Equals(ns))
               return EnumQueueEntryStatus.Aborted;
            if (EnumNodeStatus.Setup.Equals(ns))
               return EnumQueueEntryStatus.Running;
            if (EnumNodeStatus.InProgress.Equals(ns))
               return EnumQueueEntryStatus.Running;
            if (EnumNodeStatus.Cleanup.Equals(ns))
               return EnumQueueEntryStatus.Running;
            if (EnumNodeStatus.Spawned.Equals(ns))
               return EnumQueueEntryStatus.Running;
            if (EnumNodeStatus.Suspended.Equals(ns))
               return EnumQueueEntryStatus.Suspended;
            if (EnumNodeStatus.Stopped.Equals(ns))
               return EnumQueueEntryStatus.Suspended;
            if (EnumNodeStatus.Completed.Equals(ns))
               return EnumQueueEntryStatus.Completed;
            if (EnumNodeStatus.Aborted.Equals(ns))
               return EnumQueueEntryStatus.Aborted;

            return null; // punt
         }

         ///      
         ///		 * <returns> an iterator over the enum objects </returns>
         ///		 
         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumNodeStatus));
         }

         // enums accordng to JDF spec Table 3-4 Contents of a node
         public static readonly EnumNodeStatus Waiting = new EnumNodeStatus(JDFConstants.WAITING);
         public static readonly EnumNodeStatus TestRunInProgress = new EnumNodeStatus(JDFConstants.TESTRUNINPROGRESS);
         public static readonly EnumNodeStatus Ready = new EnumNodeStatus(JDFConstants.READY);
         public static readonly EnumNodeStatus FailedTestRun = new EnumNodeStatus(JDFConstants.FAILEDTESTRUN);
         public static readonly EnumNodeStatus Setup = new EnumNodeStatus(JDFConstants.SETUP);
         public static readonly EnumNodeStatus InProgress = new EnumNodeStatus(JDFConstants.INPROGRESS);
         public static readonly EnumNodeStatus Cleanup = new EnumNodeStatus(JDFConstants.CLEANUP);
         public static readonly EnumNodeStatus Spawned = new EnumNodeStatus(JDFConstants.SPAWNED);
         public static readonly EnumNodeStatus Suspended = new EnumNodeStatus(JDFConstants.SUSPENDED);
         public static readonly EnumNodeStatus Stopped = new EnumNodeStatus(JDFConstants.STOPPED);
         public static readonly EnumNodeStatus Completed = new EnumNodeStatus(JDFConstants.COMPLETED);
         public static readonly EnumNodeStatus Aborted = new EnumNodeStatus(JDFConstants.ABORTED);
         public static readonly EnumNodeStatus Part = new EnumNodeStatus(JDFConstants.PART);
         public static readonly EnumNodeStatus Pool = new EnumNodeStatus(JDFConstants.POOL);
      }

      ///   
      ///	 <summary> * 
      ///	 * The policy for this element indicates what happens when unsupported settings, (i.e., subelements, attributes or
      ///	 * attribute values), are present in the element. Possible values are:
      ///	 * <p>
      ///	 * <ul>
      ///	 * <li><b>BestEffort</b> - Substitute or ignore unsupported attributes, attribute values, default attribute values,
      ///	 * or elements and continue processing the job.
      ///	 * <li><b>MustHonor</b> - Reject the job when any unsupported attributes, attribute values, or elements are present.
      ///	 * <li><b>OperatorIntervention</b> - Pause job and query the operator when any unsupported attributes, attribute
      ///	 * values, or elements are present. If a device has no operator intervention capabilities, OperatorIntervention is
      ///	 * treated as MustHonor.
      ///	 * <p>
      ///	 * If not specified, SettingsPolicy is inherited from the parent element, and if not specified in the parent element
      ///	 * or further superior element, the default value defaults to "BestEffort". In JDF 1.1 SettingsPolicy was specified
      ///	 * in "Contents of a JDF node" and "Contents of the abstract Resource element". It has been removed from JDF node
      ///	 * and Resource and been promoted to all JDF elements. </summary>
      ///	 
      public sealed class EnumSettingsPolicy : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumSettingsPolicy(string name)
            : base(name, m_startValue++)
         {
         }

         ///      
         ///		 * <param name="enumName"> the name of the enum object to return </param>
         ///		 * <returns> the enum object if enumName is valid. Otherwise null </returns>
         ///		 
         public static EnumSettingsPolicy getEnum(string enumName)
         {
            return (EnumSettingsPolicy)getEnum(typeof(EnumSettingsPolicy), enumName);
         }

         ///      
         ///		 * <param name="enumValue"> the value of the enum object to return </param>
         ///		 * <returns> the enum object if enumName is valid. Otherwise null </returns>
         ///		 
         public static EnumSettingsPolicy getEnum(int enumValue)
         {
            return (EnumSettingsPolicy)getEnum(typeof(EnumSettingsPolicy), enumValue);
         }

         ///      
         ///		 * <returns> a map of all orientation enums </returns>
         ///		 
         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumSettingsPolicy));
         }

         ///      
         ///		 * <returns> a list of all orientation enums </returns>
         ///		 
         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumSettingsPolicy));
         }

         ///      
         ///		 * <returns> an iterator over the enum objects </returns>
         ///		 
         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumSettingsPolicy));
         }

         public static readonly EnumSettingsPolicy BestEffort = new EnumSettingsPolicy(JDFConstants.SETTINGSPOLICY_BESTEFFORT);
         public static readonly EnumSettingsPolicy MustHonor = new EnumSettingsPolicy(JDFConstants.SETTINGSPOLICY_MUSTHONOR);
         public static readonly EnumSettingsPolicy OperatorIntervention = new EnumSettingsPolicy(JDFConstants.SETTINGSPOLICY_OPERATORINTERVENTION);
      }

      ///   
      ///	 <summary> * Colors of preprocessed products such as Wire-O binders and cover leaflets. The entries in the following table may
      ///	 * be prefixed by either "Dark" or "Light". The result may additionally be prefixed by "Clear" to indicate
      ///	 * translucent material. For example, "ClearDarkBlue" indicates a translucent dark blue, "ClearBlue" a translucent
      ///	 * blue and "Blue" indicates an opaque blue.
      ///	 * <ul>
      ///	 * <li>Black <li>Blue <li>Brown <li>Buff <li>Cyan <i>New in JDF 1.2</i> <li> Gold <li>Goldenrod <li>Gray <li>Green
      ///	 * <li>Ivory <li>Magenta <i>New in JDF 1.2</i> <li>MultiColor <i>New in JDF 1.1</i> <li>Mustard <i>New in JDF
      ///	 * 1.1</i> <li>NoColor <li>Orange <li>Pink <li>Red <li>Silver <li>Turquoise <li>Violet <li>White <li>Yellow
      ///	 * </ul> </summary>
      ///	 
      public sealed class EnumNamedColor : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumNamedColor(string name)
            : base(name, m_startValue++)
         {
         }

         ///      
         ///		 * <param name="enumName"> the name of the enum object to return </param>
         ///		 * <returns> the enum object if enumName is valid. Otherwise null </returns>
         ///		 
         public static EnumNamedColor getEnum(string enumName)
         {
            return (EnumNamedColor)getEnum(typeof(EnumNamedColor), enumName);
         }

         ///      
         ///		 * <param name="enumValue"> the value of the enum object to return </param>
         ///		 * <returns> the enum object if enumName is valid. Otherwise null </returns>
         ///		 
         public static EnumNamedColor getEnum(int enumValue)
         {
            return (EnumNamedColor)getEnum(typeof(EnumNamedColor), enumValue);
         }

         ///      
         ///		 * <returns> a map of all orientation enums </returns>
         ///		 
         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumNamedColor));
         }

         ///      
         ///		 * <returns> a list of all orientation enums </returns>
         ///		 
         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumNamedColor));
         }

         ///      
         ///		 * <returns> an iterator over the enum objects </returns>
         ///		 
         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumNamedColor));
         }

         public static readonly EnumNamedColor White = new EnumNamedColor(JDFConstants.NAMEDCOLOR_WHITE);
         public static readonly EnumNamedColor Black = new EnumNamedColor(JDFConstants.NAMEDCOLOR_BLACK);
         public static readonly EnumNamedColor Gray = new EnumNamedColor(JDFConstants.NAMEDCOLOR_GRAY);
         public static readonly EnumNamedColor Red = new EnumNamedColor(JDFConstants.NAMEDCOLOR_RED);
         public static readonly EnumNamedColor Yellow = new EnumNamedColor(JDFConstants.NAMEDCOLOR_YELLOW);
         public static readonly EnumNamedColor Green = new EnumNamedColor(JDFConstants.NAMEDCOLOR_GREEN);
         public static readonly EnumNamedColor Blue = new EnumNamedColor(JDFConstants.NAMEDCOLOR_BLUE);
         public static readonly EnumNamedColor Turquoise = new EnumNamedColor(JDFConstants.NAMEDCOLOR_TURQUOISE);
         public static readonly EnumNamedColor Violet = new EnumNamedColor(JDFConstants.NAMEDCOLOR_VIOLET);
         public static readonly EnumNamedColor Orange = new EnumNamedColor(JDFConstants.NAMEDCOLOR_ORANGE);
         public static readonly EnumNamedColor Brown = new EnumNamedColor(JDFConstants.NAMEDCOLOR_BROWN);
         public static readonly EnumNamedColor Gold = new EnumNamedColor(JDFConstants.NAMEDCOLOR_GOLD);
         public static readonly EnumNamedColor Silver = new EnumNamedColor(JDFConstants.NAMEDCOLOR_SILVER);
         public static readonly EnumNamedColor Pink = new EnumNamedColor(JDFConstants.NAMEDCOLOR_PINK);
         public static readonly EnumNamedColor Buff = new EnumNamedColor(JDFConstants.NAMEDCOLOR_BUFF);
         public static readonly EnumNamedColor Ivory = new EnumNamedColor(JDFConstants.NAMEDCOLOR_IVORY);
         public static readonly EnumNamedColor Goldenrod = new EnumNamedColor(JDFConstants.NAMEDCOLOR_GOLDENROD);
         public static readonly EnumNamedColor DarkWhite = new EnumNamedColor(JDFConstants.NAMEDCOLOR_DARKWHITE);
         public static readonly EnumNamedColor DarkBlack = new EnumNamedColor(JDFConstants.NAMEDCOLOR_DARKBLACK);
         public static readonly EnumNamedColor DarkGray = new EnumNamedColor(JDFConstants.NAMEDCOLOR_DARKGRAY);
         public static readonly EnumNamedColor DarkRed = new EnumNamedColor(JDFConstants.NAMEDCOLOR_DARKRED);
         public static readonly EnumNamedColor DarkYellow = new EnumNamedColor(JDFConstants.NAMEDCOLOR_DARKYELLOW);
         public static readonly EnumNamedColor DarkGreen = new EnumNamedColor(JDFConstants.NAMEDCOLOR_DARKGREEN);
         public static readonly EnumNamedColor DarkBlue = new EnumNamedColor(JDFConstants.NAMEDCOLOR_DARKBLUE);
         public static readonly EnumNamedColor DarkTurquoise = new EnumNamedColor(JDFConstants.NAMEDCOLOR_DARKTURQUOISE);
         public static readonly EnumNamedColor DarkViolet = new EnumNamedColor(JDFConstants.NAMEDCOLOR_DARKVIOLET);
         public static readonly EnumNamedColor DarkOrange = new EnumNamedColor(JDFConstants.NAMEDCOLOR_DARKORANGE);
         public static readonly EnumNamedColor DarkBrown = new EnumNamedColor(JDFConstants.NAMEDCOLOR_DARKBROWN);
         public static readonly EnumNamedColor DarkGold = new EnumNamedColor(JDFConstants.NAMEDCOLOR_DARKGOLD);
         public static readonly EnumNamedColor DarkSilver = new EnumNamedColor(JDFConstants.NAMEDCOLOR_DARKSILVER);
         public static readonly EnumNamedColor DarkPink = new EnumNamedColor(JDFConstants.NAMEDCOLOR_DARKPINK);
         public static readonly EnumNamedColor DarkBuff = new EnumNamedColor(JDFConstants.NAMEDCOLOR_DARKBUFF);
         public static readonly EnumNamedColor DarkIvory = new EnumNamedColor(JDFConstants.NAMEDCOLOR_DARKIVORY);
         public static readonly EnumNamedColor DarkGoldenrod = new EnumNamedColor(JDFConstants.NAMEDCOLOR_DARKGOLDENROD);
         public static readonly EnumNamedColor DarkMustard = new EnumNamedColor(JDFConstants.NAMEDCOLOR_DARKMUSTARD);
         public static readonly EnumNamedColor LightWhite = new EnumNamedColor(JDFConstants.NAMEDCOLOR_LIGHTWHITE);
         public static readonly EnumNamedColor LightBlack = new EnumNamedColor(JDFConstants.NAMEDCOLOR_LIGHTBLACK);
         public static readonly EnumNamedColor LightGray = new EnumNamedColor(JDFConstants.NAMEDCOLOR_LIGHTGRAY);
         public static readonly EnumNamedColor LightRed = new EnumNamedColor(JDFConstants.NAMEDCOLOR_LIGHTRED);
         public static readonly EnumNamedColor LightYellow = new EnumNamedColor(JDFConstants.NAMEDCOLOR_LIGHTYELLOW);
         public static readonly EnumNamedColor LightGreen = new EnumNamedColor(JDFConstants.NAMEDCOLOR_LIGHTGREEN);
         public static readonly EnumNamedColor LightBlue = new EnumNamedColor(JDFConstants.NAMEDCOLOR_LIGHTBLUE);
         public static readonly EnumNamedColor LightTurquoise = new EnumNamedColor(JDFConstants.NAMEDCOLOR_LIGHTTURQUOISE);
         public static readonly EnumNamedColor LightViolet = new EnumNamedColor(JDFConstants.NAMEDCOLOR_LIGHTVIOLET);
         public static readonly EnumNamedColor LightOrange = new EnumNamedColor(JDFConstants.NAMEDCOLOR_LIGHTORANGE);
         public static readonly EnumNamedColor LightBrown = new EnumNamedColor(JDFConstants.NAMEDCOLOR_LIGHTBROWN);
         public static readonly EnumNamedColor LightGold = new EnumNamedColor(JDFConstants.NAMEDCOLOR_LIGHTGOLD);
         public static readonly EnumNamedColor LightSilver = new EnumNamedColor(JDFConstants.NAMEDCOLOR_LIGHTSILVER);
         public static readonly EnumNamedColor LightPink = new EnumNamedColor(JDFConstants.NAMEDCOLOR_LIGHTPINK);
         public static readonly EnumNamedColor LightBuff = new EnumNamedColor(JDFConstants.NAMEDCOLOR_LIGHTBUFF);
         public static readonly EnumNamedColor LightIvory = new EnumNamedColor(JDFConstants.NAMEDCOLOR_LIGHTIVORY);
         public static readonly EnumNamedColor LightGoldenrod = new EnumNamedColor(JDFConstants.NAMEDCOLOR_LIGHTGOLDENROD);
         public static readonly EnumNamedColor LightMustard = new EnumNamedColor(JDFConstants.NAMEDCOLOR_LIGHTMUSTARD);
         public static readonly EnumNamedColor ClearWhite = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARWHITE);
         public static readonly EnumNamedColor ClearBlack = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARBLACK);
         public static readonly EnumNamedColor ClearGray = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARGRAY);
         public static readonly EnumNamedColor ClearRed = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARRED);
         public static readonly EnumNamedColor ClearGreen = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARGREEN);
         public static readonly EnumNamedColor ClearBlue = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARBLUE);
         public static readonly EnumNamedColor ClearTurquoise = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARTURQUOISE);
         public static readonly EnumNamedColor ClearViolet = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARVIOLET);
         public static readonly EnumNamedColor ClearOrange = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARORANGE);
         public static readonly EnumNamedColor ClearBrown = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARBROWN);
         public static readonly EnumNamedColor ClearGold = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARGOLD);
         public static readonly EnumNamedColor ClearSilver = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARSILVER);
         public static readonly EnumNamedColor ClearPink = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARPINK);
         public static readonly EnumNamedColor ClearBuff = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARBUFF);
         public static readonly EnumNamedColor ClearIvory = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARIVORY);
         public static readonly EnumNamedColor ClearGoldenrod = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARGOLDENROD);
         public static readonly EnumNamedColor ClearMustard = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARMUSTARD);
         public static readonly EnumNamedColor ClearDarkWhite = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARDARKWHITE);
         public static readonly EnumNamedColor ClearDarkBlack = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARDARKBLACK);
         public static readonly EnumNamedColor ClearDarkGray = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARDARKGRAY);
         public static readonly EnumNamedColor ClearDarkRed = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARDARKRED);
         public static readonly EnumNamedColor ClearDarkYellow = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARDARKYELLOW);
         public static readonly EnumNamedColor ClearDarkGreen = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARDARKGREEN);
         public static readonly EnumNamedColor ClearDarkBlue = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARDARKBLUE);
         public static readonly EnumNamedColor ClearDarkTurquoise = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARDARKTURQUOISE);
         public static readonly EnumNamedColor ClearDarkViolet = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARDARKVIOLET);
         public static readonly EnumNamedColor ClearDarkOrange = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARDARKORANGE);
         public static readonly EnumNamedColor ClearDarkBrown = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARDARKBROWN);
         public static readonly EnumNamedColor ClearDarkGold = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARDARKGOLD);
         public static readonly EnumNamedColor ClearDarkSilver = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARDARKSILVER);
         public static readonly EnumNamedColor ClearDarkPink = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARDARKPINK);
         public static readonly EnumNamedColor ClearDarkBuff = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARDARKBUFF);
         public static readonly EnumNamedColor ClearDarkIvory = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARDARKIVORY);
         public static readonly EnumNamedColor ClearDarkGoldenrod = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARDARKGOLDENROD);
         public static readonly EnumNamedColor ClearLightWhite = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARLIGHTWHITE);
         public static readonly EnumNamedColor ClearLightBlack = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARLIGHTBLACK);
         public static readonly EnumNamedColor ClearLightGray = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARLIGHTGRAY);
         public static readonly EnumNamedColor ClearLightRed = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARLIGHTRED);
         public static readonly EnumNamedColor ClearLightYellow = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARLIGHTYELLOW);
         public static readonly EnumNamedColor ClearLightGreen = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARLIGHTGREEN);
         public static readonly EnumNamedColor ClearLightBlue = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARLIGHTBLUE);
         public static readonly EnumNamedColor ClearLightTurquoise = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARLIGHTTURQUOISE);
         public static readonly EnumNamedColor ClearLightViolet = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARLIGHTVIOLET);
         public static readonly EnumNamedColor ClearLightOrange = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARLIGHTORANGE);
         public static readonly EnumNamedColor ClearLightBrown = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARLIGHTBROWN);
         public static readonly EnumNamedColor ClearLightGold = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARLIGHTGOLD);
         public static readonly EnumNamedColor ClearLightSilver = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARLIGHTSILVER);
         public static readonly EnumNamedColor ClearLightPink = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARLIGHTPINK);
         public static readonly EnumNamedColor ClearLightBuff = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARLIGHTBUFF);
         public static readonly EnumNamedColor ClearLightIvory = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARLIGHTIVORY);
         public static readonly EnumNamedColor ClearLightGoldenrod = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARLIGHTGOLDENROD);
         public static readonly EnumNamedColor ClearLightMustard = new EnumNamedColor(JDFConstants.NAMEDCOLOR_CLEARLIGHTMUSTARD);
         public static readonly EnumNamedColor MultiColor = new EnumNamedColor(JDFConstants.NAMEDCOLOR_MULTICOLOR);
         public static readonly EnumNamedColor NoColor = new EnumNamedColor(JDFConstants.NAMEDCOLOR_NOCOLOR);
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
         return "JDFElement[  --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * Mother of all validators
      ///	 *  </summary>
      ///	 * <param name="level"> validation level
      ///	 *            <ul>
      ///	 *            <li>level EnumValidationLevel.None: always return true; <li> level EnumValidationLevel.Construct:
      ///	 *            incomplete and null elements are valid. <li>level EnumValidationLevel.Incomplete: incomplete elements
      ///	 *            are valid <li>level EnumValidationLevel.Complete: full validation <li>level
      ///	 *            EnumValidationLevel.RecursiveIncomplete: incomplete validation but follow links <li>level
      ///	 *            EnumValidationLevel.RecursiveComplete: full validation and follow links downward
      ///	 *            </ul>
      ///	 *  </param>
      ///	 * <returns> boolean the validity of the node </returns>
      ///	 
      public override bool isValid(EnumValidationLevel level)
      {
         return isValid_JDFElement(level);
      }

      ///   
      ///	 <summary> * Mother of all validators; this method is for direct access to the JDFElement valid method and short-circuit all
      ///	 * overriding virtual methods
      ///	 *  </summary>
      ///	 * <param name="level"> validation level
      ///	 *            <ul>
      ///	 *            <li>level EnumValidationLevel.None: always return true; <li> level EnumValidationLevel.Construct:
      ///	 *            incomplete and null elements are valid. <li>level EnumValidationLevel.Incomplete: incomplete elements
      ///	 *            are valid <li>level EnumValidationLevel.Complete: full validation <li>level
      ///	 *            EnumValidationLevel.RecursiveIncomplete: incomplete validation but follow links <li>level
      ///	 *            EnumValidationLevel.RecursiveComplete: full validation and follow links downward
      ///	 *            </ul>
      ///	 *  </param>
      ///	 * <returns> boolean the validity of the node </returns>
      ///	 
      public virtual bool isValid_JDFElement(EnumValidationLevel level)
      {
         // there is no explicit extension type --> these are always assumed
         // valid
         System.Type class1 = this.GetType();
         if (class1 == typeof(JDFElement) || class1 == typeof(JDFResource))
         {
            return true;
         }

         try
         {
            if (getInvalidAttributes(level, true, 1).Count > 0 || getInvalidElements(level, true, 1).Count > 0)
            {
               return false;
            }

            if (EnumValidationLevel.isRecursive(level))
            {
               EnumValidationLevel valDown = (level == EnumValidationLevel.RecursiveIncomplete) ? EnumValidationLevel.Incomplete : EnumValidationLevel.Complete;

               VElement v = getChildElementVector(null, null, null, true, 0, false);
               int size = v.Count;
               for (int i = 0; i < size; i++)
               {
                  if (v[i] is JDFRefElement)
                  {
                     JDFResource res = ((JDFRefElement)v[i]).getTarget();
                     if (!res.isValid(valDown))
                     {
                        return false;
                     }
                  }
               }
            }
            return true;
         }
         catch (JDFException)
         {
            // snafu --> it probably isn't valid...
            return false;
         }
      }

      ///   
      ///	 <summary> * Mother of all version fixing routines
      ///	 * 
      ///	 * uses heuristics to modify this element and its children to be compatible with a given version in general, it will
      ///	 * be able to move from low to high versions but potentially fail when attempting to move from higher to lower
      ///	 * versions
      ///	 *  </summary>
      ///	 * <param name="version"> version the resulting element should correspond to </param>
      ///	 * <returns> true if successful </returns>
      ///	 
      public virtual bool fixVersion(EnumVersion version)
      {
         // fix any spurious ns typos
         if (!JDFConstants.JDFNAMESPACE.Equals(getNamespaceURI()))
         {
            // Java to C# Conversion - QUESTION: Do we need to be able to assign value?
            //this.NamespaceURI = JDFConstants.JDFNAMESPACE;
            setDirty(true);
         }
         bool bRet = true;
         VElement v = getChildElementVector_KElement(null, null, null, true, -1); // do
         // not
         // follow
         // refelements
         int size = v.Count;
         for (int i = 0; i < size; i++)
         {
            KElement e = v[i];
            if (e is JDFElement) // skip stuff in unknown namespaces
            {
               JDFElement j = (JDFElement)e;
               bRet = j.fixVersion(version) && bRet;
            }
         }

         // replace all "~" with " ~ "
         JDFAttributeMap m = getAttributeMap();
         IEnumerator<string> it = m.Keys.GetEnumerator(); //.getKeyIterator();
         AttributeInfo ai = getTheAttributeInfo();
         while (it.MoveNext())
         {
            string key = it.Current;
            string @value = m.get(key);
            EnumAttributeType attType = ai.getAttributeType(key);

            if (EnumAttributeType.isRange(attType))
            {
               try
               {
                  JDFNameRangeList nrl = new JDFNameRangeList(@value);
                  setAttribute(key, nrl, null);
               }
               catch (JDFException)
               {
                  // do nothing
               }
               catch (FormatException)
               {
                  // do nothing
               }
            }
            else if (EnumAttributeType.duration.Equals(attType))
            {
               try
               {
                  setAttribute(key, new JDFDuration(@value).getDurationISO());
               }
               catch (FormatException)
               {
                  bRet = false;
               }
            }
            if (bFixVersionIDFix && @value.Length > 0 && StringUtil.IsNumeric(@value.Substring(0, 1)))
            {
               EnumAttributeType atType = ai.getAttributeType(key);
               if (atType != null)
               {
                  if (atType.Equals(EnumAttributeType.ID) || atType.Equals(EnumAttributeType.IDREF))
                  {
                     @value = "_" + @value;
                     setAttribute(key, @value);
                  }
                  else if (atType.Equals(EnumAttributeType.IDREFS))
                  {
                     VString vvalues = new VString(@value, " ");
                     for (int i = 0; i < vvalues.Count; i++)
                     {
                        string s = vvalues.stringAt(i);
                        if (s.Length > 0 && StringUtil.IsNumeric(s.Substring(0, 1)))
                        {
                           s = "_" + s;
                           vvalues[i] = s;
                        }
                     }
                     setAttribute(key, vvalues, null);
                  }
               }
            }
         }
         return bRet;
      }

      ///   
      ///	 <summary> * Check Existance of attribute SettingsPolicy
      ///	 *  </summary>
      ///	 * <param name="bInherit"> recurse through ancestors when searching </param>
      ///	 * <returns> true if attribute exists </returns>
      ///	 * @deprecated use hasAttribute 
      ///	 
      [Obsolete("use hasAttribute")]
      public virtual bool hasSettingsPolicy(bool bInherit)
      {
         return hasAttribute(AttributeName.SETTINGSPOLICY, null, bInherit);
      }

      ///   
      ///	 <summary> * Remove attribute SettingsPolicy
      ///	 *  </summary>
      ///	 * @deprecated use removeAttribute 
      ///	 
      [Obsolete("use removeAttribute")]
      public virtual void removeSettingsPolicy()
      {
         removeAttribute(AttributeName.SETTINGSPOLICY, null);
      }

      ///   
      ///	 <summary> * Remove attribute BestEffortExceptions
      ///	 *  </summary>
      ///	 * @deprecated use removeAttribute 
      ///	 
      [Obsolete("use removeAttribute")]
      public virtual void removeBestEffortExceptions()
      {
         removeAttribute(AttributeName.BESTEFFORTEXCEPTIONS, null);
      }

      ///   
      ///	 <summary> * Gets the one and reference to an ID
      ///	 *  </summary>
      ///	 * <returns> String the rRef attribute </returns>
      ///	 * @deprecated use getrRef of the coresponding sub classes instead 
      ///	 
      [Obsolete("use getrRef of the coresponding sub classes instead")]
      public virtual string getHRef()
      {
         return getAttribute(JDFConstants.RREF, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * append a reference to a target node automatically generate a unique ID attribute for target, if it does not exist
      ///	 *  </summary>
      ///	 * <param name="target"> the element to reference </param>
      ///	 * <param name="refAttribute"> name of the refering attribute, e.g. hRef, rRef </param>
      ///	 * <param name="preSet"> preset value of the ID attribute - defaults to autogenerated
      ///	 *  </param>
      ///	 * <returns> JDFElement
      ///	 * 
      ///	 * @default AppendHRef(target, null, JDFConstants.EMPTYSTRING) </returns>
      ///	 
      public virtual JDFElement appendHRef(JDFResource target, string refAttribute, string preSet)
      {
         if (target == null)
         {
            return null;
         }

         string idRef = target.getID();

         if (idRef == null || idRef.Equals(JDFConstants.EMPTYSTRING))
         {
            target.appendAnchor(preSet);
            idRef = target.getID();
         }

         return appendHRef(idRef, refAttribute, null);
      }

      ///   
      ///	 <summary> * append a reference with a specific id
      ///	 *  </summary>
      ///	 * <param name="idRef"> value of the ID-IDREF pair </param>
      ///	 * <param name="refAttribute"> value of the IDREF tag </param>
      ///	 * <param name="nameSpaceURI"> nameSpaceURI of the IDREF tag
      ///	 *  </param>
      ///	 * <returns> JDFElement
      ///	 * 
      ///	 * @default AppendHRef(idRef, JDFConstants.EMPTYSTRING, null) </returns>
      ///	 
      public virtual JDFElement appendHRef(string idRef, string refAttribute, string nameSpaceURI)
      {
         string refAttributeLocal = refAttribute;

         if (idRef == null || idRef.Length < 1)
         {
            return null;
         }

         if (refAttributeLocal == null || refAttributeLocal.Equals(JDFConstants.EMPTYSTRING))
         {
            refAttributeLocal = JDFConstants.RREF;
         }

         setAttribute(refAttributeLocal, idRef, nameSpaceURI);

         return this;
      }

      ///   
      ///	 <summary> * Sets an element attribute
      ///	 *  </summary>
      ///	 * <param name="key"> the name of the attribute to set </param>
      ///	 * <param name="value"> the JDFDuration to set </param>
      ///	 * <param name="nameSpaceURI"> the nameSpace the attribute is in
      ///	 * 
      ///	 *            default: setAttribute(key, value, null) </param>
      ///	 
      public virtual void setAttribute(string key, JDFDuration @value, string nameSpaceURI)
      {
         if (@value == null)
         {
            removeAttribute(key, nameSpaceURI);
         }
         else
         {
            base.setAttribute(key, @value.getDurationISO(), nameSpaceURI);
         }
      }

      ///   
      ///	 <summary> * Sets an element attribute
      ///	 *  </summary>
      ///	 * <param name="key"> the name of the attribute to set </param>
      ///	 * <param name="value"> the JDFDurationRangeList to set </param>
      ///	 * <param name="nameSpaceURI"> the nameSpace the attribute is in
      ///	 * 
      ///	 * @default setAttribute(key, value, null) </param>
      ///	 
      public virtual void setAttribute(string key, JDFDurationRangeList @value, string nameSpaceURI)
      {
         if (@value == null)
         {
            removeAttribute(key, nameSpaceURI);
         }
         else
         {
            base.setAttribute(key, @value.ToString(), nameSpaceURI);
         }
      }

      ///   
      ///	 <summary> * Sets an element attribute
      ///	 *  </summary>
      ///	 * <param name="key"> the name of the attribute to set </param>
      ///	 * <param name="value"> the JDFDateTimeRangeList to set </param>
      ///	 * <param name="nameSpaceURI"> the nameSpace the attribute is in
      ///	 * 
      ///	 * @default setAttribute(key, value, null) </param>
      ///	 
      public virtual void setAttribute(string key, JDFDateTimeRangeList @value, string nameSpaceURI)
      {
         if (@value == null)
         {
            removeAttribute(key, nameSpaceURI);
         }
         else
         {
            base.setAttribute(key, @value.ToString(), nameSpaceURI);
         }
      }

      ///   
      ///	 <summary> * Sets an element attribute
      ///	 *  </summary>
      ///	 * <param name="key"> the name of the attribute to set </param>
      ///	 * <param name="value"> the JDFRectangleList to set </param>
      ///	 * <param name="nameSpaceURI"> the nameSpace the attribute is in
      ///	 * 
      ///	 * @default setAttribute(key, value, null) </param>
      ///	 
      public virtual void setAttribute(string key, JDFRectangleRangeList @value, string nameSpaceURI)
      {
         if (@value == null)
         {
            removeAttribute(key, nameSpaceURI);
         }
         else
         {
            base.setAttribute(key, @value.ToString(), nameSpaceURI);
         }
      }

      ///   
      ///	 <summary> * setAttribute - Sets an element attribute
      ///	 *  </summary>
      ///	 * <param name="key"> the name of the attribute to set </param>
      ///	 * <param name="value"> the JDFShapeRangeList to set </param>
      ///	 * <param name="nameSpaceURI"> the nameSpace the attribute is in
      ///	 * 
      ///	 * @default setAttribute(key, value, null) </param>
      ///	 
      public virtual void setAttribute(string key, JDFShapeRangeList @value, string nameSpaceURI)
      {
         if (@value == null)
         {
            removeAttribute(key, nameSpaceURI);
         }
         else
         {
            base.setAttribute(key, @value.ToString(), nameSpaceURI);
         }
      }

      ///   
      ///	 <summary> * Sets an element attribute
      ///	 *  </summary>
      ///	 * <param name="key"> the name of the attribute to set </param>
      ///	 * <param name="value"> the JDFNumList to set </param>
      ///	 * <param name="nameSpaceURI"> the nameSpace the attribute is in
      ///	 * 
      ///	 * @default setAttribute(key, value, null) </param>
      ///	 
      public virtual void setAttribute(string key, JDFNumList @value, string nameSpaceURI)
      {
         if (@value == null)
         {
            removeAttribute(key, nameSpaceURI);
         }
         else
         {
            base.setAttribute(key, @value.ToString(), nameSpaceURI);
         }
      }

      ///   
      ///	 <summary> * Sets an element attribute
      ///	 *  </summary>
      ///	 * <param name="key"> the name of the attribute to set </param>
      ///	 * <param name="value"> the JDFNumberRange to set </param>
      ///	 * <param name="nameSpaceURI"> the nameSpace the attribute is in
      ///	 * 
      ///	 * @default setAttribute(key, value, null) </param>
      ///	 
      public virtual void setAttribute(string key, JDFNumberRange @value, string nameSpaceURI)
      {
         if (@value == null)
         {
            removeAttribute(key, nameSpaceURI);
         }
         else
         {
            base.setAttribute(key, @value.ToString(), nameSpaceURI);
         }
      }

      ///   
      ///	 <summary> * Sets an element attribute
      ///	 *  </summary>
      ///	 * <param name="key"> the name of the attribute to set </param>
      ///	 * <param name="value"> the JDFIntegerRange to set </param>
      ///	 * <param name="nameSpaceURI"> the nameSpace the attribute is in
      ///	 * 
      ///	 * @default setAttribute(key, value, null) </param>
      ///	 
      public virtual void setAttribute(string key, JDFIntegerRange @value, string nameSpaceURI)
      {
         if (@value == null)
         {
            removeAttribute(key, nameSpaceURI);
         }
         else
         {
            base.setAttribute(key, @value.ToString(), nameSpaceURI);
         }
      }

      ///   
      ///	 <summary> * Sets an element attribute
      ///	 *  </summary>
      ///	 * <param name="key"> the name of the attribute to set </param>
      ///	 * <param name="value"> the JDFNameRangeList to set </param>
      ///	 * <param name="nameSpaceURI"> the nameSpace the attribute is in
      ///	 * 
      ///	 * @default setAttribute(key, value, null) </param>
      ///	 
      public virtual void setAttribute(string key, JDFNameRangeList @value, string nameSpaceURI)
      {
         if (@value == null)
         {
            removeAttribute(key, nameSpaceURI);
         }
         else
         {
            base.setAttribute(key, @value.ToString(), nameSpaceURI);
         }
      }

      ///   
      ///	 <summary> * Sets an element attribute
      ///	 *  </summary>
      ///	 * <param name="key"> the name of the attribute to set </param>
      ///	 * <param name="value"> the JDFNameRange to set </param>
      ///	 * <param name="nameSpaceURI"> the nameSpace the attribute is in
      ///	 * 
      ///	 * @default setAttribute(key, value, null) </param>
      ///	 
      public virtual void setAttribute(string key, JDFNameRange @value, string nameSpaceURI)
      {
         if (@value == null)
         {
            removeAttribute(key, nameSpaceURI);
         }
         else
         {
            base.setAttribute(key, @value.ToString(), nameSpaceURI);
         }
      }

      ///   
      ///	 <summary> * Sets an element attribute
      ///	 *  </summary>
      ///	 * <param name="key"> the name of the attribute to set </param>
      ///	 * <param name="value"> the JDFNumberRangeList to set </param>
      ///	 * <param name="nameSpaceURI"> the nameSpace the attribute is in
      ///	 * 
      ///	 * @default setAttribute(key, value, null) </param>
      ///	 
      public virtual void setAttribute(string key, JDFNumberRangeList @value, string nameSpaceURI)
      {
         if (@value == null)
         {
            removeAttribute(key, nameSpaceURI);
         }
         else
         {
            base.setAttribute(key, @value.ToString(), nameSpaceURI);
         }
      }

      ///   
      ///	 <summary> * Sets an element attribute
      ///	 *  </summary>
      ///	 * <param name="key"> the name of the attribute to set </param>
      ///	 * <param name="value"> the JDFIntegerRangeList to set </param>
      ///	 * <param name="nameSpaceURI"> the nameSpace the attribute is in
      ///	 * 
      ///	 * @default setAttribute(key, value, null) </param>
      ///	 
      public virtual void setAttribute(string key, JDFIntegerRangeList @value, string nameSpaceURI)
      {
         if (@value == null)
         {
            removeAttribute(key, nameSpaceURI);
         }
         else
         {
            base.setAttribute(key, @value.ToString(), nameSpaceURI);
         }
      }

      ///   
      ///	 <summary> * Sets an element attribute
      ///	 *  </summary>
      ///	 * <param name="key"> the name of the attribute to set </param>
      ///	 * <param name="value"> the JDFXYpairRange to set </param>
      ///	 * <param name="nameSpaceURI"> the nameSpace the attribute is in
      ///	 * 
      ///	 * @default setAttribute(key, value, null) </param>
      ///	 
      public virtual void setAttribute(string key, JDFXYPairRange @value, string nameSpaceURI)
      {
         if (@value == null)
         {
            removeAttribute(key, nameSpaceURI);
         }
         else
         {
            base.setAttribute(key, @value.ToString(), nameSpaceURI);
         }
      }

      ///   
      ///	 <summary> * Sets an element attribute
      ///	 *  </summary>
      ///	 * <param name="key"> the name of the attribute to set </param>
      ///	 * <param name="value"> the JDFXYPairRangeList to set </param>
      ///	 * <param name="nameSpaceURI"> the nameSpace the attribute is in
      ///	 * 
      ///	 * @default setAttribute(key, value, null) </param>
      ///	 
      public virtual void setAttribute(string key, JDFXYPairRangeList @value, string nameSpaceURI)
      {
         if (@value == null)
         {
            removeAttribute(key, nameSpaceURI);
         }
         else
         {
            base.setAttribute(key, @value.ToString(), nameSpaceURI);
         }
      }

      ///   
      ///	 <summary> * Sets an element attribute
      ///	 *  </summary>
      ///	 * <param name="key"> the name of the attribute to set </param>
      ///	 * <param name="value"> the JDFNameRange to set </param>
      ///	 * <param name="nameSpaceURI"> the nameSpace the attribute is in
      ///	 * @deprecated
      ///	 * @default setvStringAttribute(key, value, null) </param>
      ///	 
      [Obsolete]
      public virtual void setvStringAttribute(string key, JDFNameRange @value, string nameSpaceURI)
      {
         setAttribute(key, @value.ToString(), nameSpaceURI);
      }

      ///   
      ///	 <summary> * return true if no more than one of att1 or att2 exists or exactly one of att1 or att2 exists depending on level
      ///	 *  </summary>
      ///	 * <param name="level"> validation level, if level allows optional, no attribute also returns true </param>
      ///	 * <param name="att1"> name of first attribute </param>
      ///	 * <param name="att2"> name of second attribute </param>
      ///	 * <param name="att3"> name of third optional attribute </param>
      ///	 * <param name="att4"> name of fourth optional attribute </param>
      ///	 * <returns> boolean true combination is valid
      ///	 * @default exclusiveOneOfAttribute(EnumValidationLevel level, String att1, String att2, JDFConstants.EMPTYSTRING,
      ///	 *          JDFConstants.EMPTYSTRING) </returns>
      ///	 
      public virtual bool exclusiveOneOfAttribute(EnumValidationLevel level, string att1, string att2, string att3, string att4)
      {
         int n = 0;
         bool hasAtt1 = hasAttribute(att1);
         n += hasAtt1 ? 1 : 0;
         n += hasAttribute(att2) ? 1 : 0;
         if (!att3.Equals(JDFConstants.EMPTYSTRING))
         {
            n += hasAttribute(att3) ? 1 : 0;
         }
         if (!att4.Equals(JDFConstants.EMPTYSTRING))
         {
            n += hasAttribute(att4) ? 1 : 0;
         }

         if (EnumValidationLevel.isRequired(level))
         {
            // exactly one or more than one, but not this one
            return n == 1 || ((!hasAtt1) && (n >= 1));
         }
         // at most one is good or more than one, but not this one
         return n <= 1 || !hasAtt1;
      }

      ///   
      ///	 <summary> * return true if no more than one of att1 or att2 exists or exactly one of att1 or att2 exists depending on level
      ///	 *  </summary>
      ///	 * <param name="level"> validation level, if level allows optional, no attribute also returns true </param>
      ///	 * <param name="elm1"> name of first attribute </param>
      ///	 * <param name="ns1"> namespace URI of first attribute </param>
      ///	 * <param name="elm2"> name of first attribute </param>
      ///	 * <param name="ns2"> namespace URI of first attribute </param>
      ///	 * <returns> boolean true combination is valid </returns>
      ///	 
      public virtual bool exclusiveOneOfElement(EnumValidationLevel level, string elm1, string ns1, string elm2, string ns2)
      {
         int n = 0;
         n += hasChildElement(elm1, ns1) ? 1 : 0;
         n += hasChildElement(elm2, ns2) ? 1 : 0;
         if (EnumValidationLevel.isRequired(level))
         {
            // exactly one
            return n == 1;
         }
         // at most one is good
         return n <= 1;
      }

      ///   
      ///	 <summary> * GetChildIds - get a set of all known id's in child nodes
      ///	 *  </summary>
      ///	 * <param name="attrib"> attribute name of the ID attribute, defaults to "ID" </param>
      ///	 * <param name="element"> name of the elements to be searched </param>
      ///	 * <param name="nameSpaceURI"> attribute namespace uri of the elements to include in the list
      ///	 *  </param>
      ///	 * <returns> Vector - a vector of all known ID elements
      ///	 * 
      ///	 * @default GetChildIds(AttributeName.ID, null, null) </returns>
      ///	 
      public virtual VString getChildIds(string attrib, string element, string nameSpaceURI)
      {
         VString setID = new VString();

         VElement nl = getElementsByTagName_KElement(element, nameSpaceURI);
         int l = nl.Count;

         if (l != 0)
         {
            System.Object generatedAux = nl[l - 1];
         }

         for (int i = 0; i < l; i++)
         {
            KElement kElem = nl[i];
            string s = kElem.getAttribute(attrib, nameSpaceURI, JDFConstants.EMPTYSTRING);

            if (s.Equals(JDFConstants.EMPTYSTRING))
            {
               continue;
            }
            setID.Add(s);
         }

         return setID;
      }

      ///   
      ///	 <summary> * Get the target element of a link (string id)
      ///	 *  </summary>
      ///	 * <returns> JDFElement - the element that this reference refers to </returns>
      ///	 * @deprecated use the respective subclasses getTarget functions 
      ///	 
      [Obsolete("use the respective subclasses getTarget functions")]
      public virtual JDFResource getTarget()
      {
         return (JDFResource)getTarget_JDFElement(getAttribute(AttributeName.RREF), AttributeName.ID);
      }

      ///   
      ///	 <summary> * Get the target element of a link<br>
      ///	 * overwrites KElement
      ///	 *  </summary>
      ///	 * <param name="id"> value of the ID to search </param>
      ///	 * <param name="attrib"> name of the ID tag, defaults to "ID" </param>
      ///	 * <returns> JDFElement - the element that this reference refers to
      ///	 * 
      ///	 *         default: GetTarget(GetHRef(), AttributeName.ID) </returns>
      ///	 
      public virtual JDFElement getTarget_JDFElement(string id, string attrib)
      {
         return (JDFElement)base.getTarget(id, attrib);
      }

      ///   
      ///	 <summary> * Get the JDF root
      ///	 *  </summary>
      ///	 * <returns> JDFNode - The root of the JDF File </returns>
      ///	 
      public virtual JDFNode getJDFRoot()
      {
         return (JDFNode)getDeepParent(ElementName.JDF, int.MaxValue);
      }

      ///   
      ///	 <summary> * Get the JMF root
      ///	 *  </summary>
      ///	 * <returns> JDFJMF - the root of the JMF file </returns>
      ///	 
      public virtual JDFJMF getJMFRoot()
      {
         return (JDFJMF)getDeepParent(ElementName.JMF, int.MaxValue);
      }

      ///   
      ///	 <summary> * IsRefElement - is this thing a RefElement?
      ///	 *  </summary>
      ///	 * <returns> true, if this is a refElement </returns>
      ///	 * @deprecated use instanceof JDFRefElement 
      ///	 
      [Obsolete("use instanceof JDFRefElement")]
      public virtual bool isRefElement()
      {
         return this is JDFRefElement;
      }

      ///   
      ///	 <summary> * IsRefElement - is this thing a RefElement?
      ///	 *  </summary>
      ///	 * <returns> true, if this is a refElement </returns>
      ///	 * @deprecated use instanceof JDFRefElement 
      ///	 
      [Obsolete("use instanceof JDFRefElement")]
      public static bool isRefElementStatic(KElement kElem)
      {
         return kElem is JDFRefElement;
      }

      ///   
      ///	 <summary> * tests whether this Element is a Resource.
      ///	 *  </summary>
      ///	 * <returns> boolean - true, if it is a Resource. </returns>
      ///	 * @deprecated use instanceof JDFResource instead 
      ///	 
      [Obsolete("use instanceof JDFResource instead")]
      public virtual bool isResource()
      {
         return this is JDFResource;
      }

      ///   
      ///	 <summary> * tests whether this Element is a Resource.
      ///	 *  </summary>
      ///	 * <returns> boolean - true, if it is a Resource. </returns>
      ///	 * @deprecated use instanceof JDFResource instead 
      ///	 
      [Obsolete("use instanceof JDFResource instead")]
      public static bool isResourceStatic(KElement e)
      {
         return e is JDFResource;
      }

      ///   
      ///	 <summary> * is this thing a ResourceUpdate?
      ///	 *  </summary>
      ///	 * <returns> true, if this is a ResourceUpdate </returns>
      ///	 
      public virtual bool isResourceUpdate()
      {
         return this.LocalName.EndsWith(ElementName.UPDATE);
      }

      ///   
      ///	 <summary> * Method IsResourceLink.
      ///	 *  </summary>
      ///	 * <returns> boolean </returns>
      ///	 * @deprecated use instanceof JDFResourceLink instead 
      ///	 
      [Obsolete("use instanceof JDFResourceLink instead")]
      public virtual bool isResourceLink()
      {
         return this is JDFResourceLink;
      }

      ///   
      ///	 <summary> * Method IsResourceLinkStatic.
      ///	 *  </summary>
      ///	 * <param name="kElem"> </param>
      ///	 * <returns> boolean </returns>
      ///	 * @deprecated use instanceof JDFResourceLink instead
      ///	 *  
      ///	 
      [Obsolete("use instanceof JDFResourceLink instead")]
      public static bool isResourceLinkStatic(KElement kElem)
      {
         return kElem is JDFResourceLink;
      }

      ///   
      ///	 <summary> * Check, if this is an Comment element
      ///	 *  </summary>
      ///	 * <returns> boolean - true, if this is an Comment-Element, otherwise false </returns>
      ///	 * @deprecated use instanceof JDFResourceLink instead 
      ///	 
      [Obsolete("use instanceof JDFResourceLink instead")]
      public virtual bool isComment()
      {
         return this is JDFComment;
      }

      ///   
      ///	 <summary> * Method isCommentStatic.
      ///	 *  </summary>
      ///	 * <param name="kElem"> </param>
      ///	 * <returns> boolean - true, if this is an Comment-Element, otherwise false </returns>
      ///	 * @deprecated use instanceof JDFComment instead 
      ///	 
      [Obsolete("use instanceof JDFComment instead")]
      public static bool isCommentStatic(KElement kElem)
      {
         return kElem is JDFComment;
      }

      ///   
      ///	 <summary> * is this thing a JDF Node?
      ///	 *  </summary>
      ///	 * <returns> true if this is a JDF Node </returns>
      ///	 * @deprecated use instanceof JDFNode instead 
      ///	 
      [Obsolete("use instanceof JDFNode instead")]
      public virtual bool isJDFNode()
      {
         return this is JDFNode;
      }

      ///   
      ///	 <summary> * Method IsInJDFNameSpace.
      ///	 *  </summary>
      ///	 * <returns> boolean </returns>
      ///	 * @deprecated - use isInJDFNameSpaceStatic(kElem) 
      ///	 
      [Obsolete("- use isInJDFNameSpaceStatic(kElem)")]
      public virtual bool isInJDFNameSpace()
      {
         return isInJDFNameSpaceStatic(this);
      }

      ///   
      ///	 <summary> *remove all private extensions form a jdf element and its children
      ///	 *  </summary>
      ///	 
      public virtual void removeExtensions()
      {
         XmlNode n = FirstChild;
         while (n != null)
         {
            XmlNode next = n.NextSibling; // get next prior to zapping
            string nsuri = n.NamespaceURI;
            if (!isInJDFNameSpaceStatic(nsuri))
            {
               RemoveChild(n);
            }
            else if (n is JDFElement)
            {
               ((JDFElement)n).removeExtensions();
            }

            n = next;
         }

         XmlNamedNodeMap nm = Attributes;
         if (nm != null)
         {
            int size = nm.Count;
            for (int i = size - 1; i >= 0; i--)
            {
               XmlNode na = nm.Item(i);
               string nsuri = na.NamespaceURI;
               if (!isInJDFNameSpaceStatic(nsuri))
               {
                  removeAttributeNode((XmlAttribute)na);
               }
            }
         }
      }

      ///   
      ///	 <summary> * checks whether kElem is in the JDF namespace
      ///	 *  </summary>
      ///	 * <param name="ns"> the KElement to check </param>
      ///	 * <returns> boolean - true, if kElem is in the JDF namespace </returns>
      ///	 
      public static bool isInJDFNameSpaceStatic(string ns)
      {
         //return ns == null || ns.Equals(JDFConstants.EMPTYSTRING) || (ns.compareToIgnoreCase("http://www.CIP4.org/JDFSchema_1_1") == 0) || (ns.compareToIgnoreCase("http://www.CIP4.org/JDFSchema_1") == 0);
         return ns == null || ns.Equals(JDFConstants.EMPTYSTRING) || (String.Compare(ns, "http://www.CIP4.org/JDFSchema_1_1", true) == 0) || (String.Compare(ns, "http://www.CIP4.org/JDFSchema_1", true) == 0);

      }

      ///   
      ///	 <summary> * checks whether kElem is in the JDF namespace
      ///	 *  </summary>
      ///	 * <param name="kElem"> the KElement to check </param>
      ///	 * <returns> boolean - true, if kElem is in the JDF namespace </returns>
      ///	 
      public static bool isInJDFNameSpaceStatic(KElement kElem)
      {
         if (kElem == null)
            return false; // null ain't no jdf

         string ns = kElem.getNamespaceURI();
         return isInJDFNameSpaceStatic(ns);
      }

      ///   
      ///	 <summary> * gets an inter resource link to a target resource. if target is a partition, the refElement MUST point exactly to
      ///	 * that partition
      ///	 *  </summary>
      ///	 * <param name="target"> - Target resource to link to </param>
      ///	 * <returns> the existing refElement </returns>
      ///	 
      public virtual JDFRefElement getRefElement(JDFResource target)
      {
         if (target == null)
            return null;

         JDFAttributeMap map = target.getPartMap();
         if (map != null && map.Count == 0)
            map = null;
         string id = target.getID();

         VElement v = getChildrenByTagName(target.LocalName + JDFConstants.REF, target.getNamespaceURI(), new JDFAttributeMap(AttributeName.RREF, id), false, true, 0);
         if (v != null)
         {
            int siz = v.Count;
            for (int i = 0; i < siz; i++)
            {
               JDFRefElement re = (JDFRefElement)v[i];
               JDFAttributeMap partMap = re.getPartMap();
               if (partMap != null && partMap.Count == 0)
                  partMap = null;

               if (ContainerUtil.Equals(partMap, map))
               {
                  return re;
               }
            }
         }

         return null;
      }

      ///   
      ///	 <summary> * gets an inter resource link to a target resource., creates it if it does not exist
      ///	 *  </summary>
      ///	 * <param name="target"> - Target resource to link to </param>
      ///	 
      public virtual JDFRefElement getCreateRefElement(JDFResource target)
      {
         JDFRefElement re = getRefElement(target);
         return re == null ? refElement(target) : re;
      }

      ///   
      ///	 <summary> * Creates an inter resource link to a target resource.
      ///	 *  </summary>
      ///	 * <param name="target"> - Target resource to link to </param>
      ///	 
      public virtual JDFRefElement refElement(JDFResource target)
      {
         JDFRefElement newRef = (JDFRefElement)appendElement(target.Name + JDFConstants.REF, target.getNamespaceURI());

         JDFResource root = target.getResourceRoot();

         // check whether it is a resource element
         if (target.isResourceElement())
         {
            newRef.appendHRef(target, AttributeName.RSUBREF, null);
         }

         // check whether it is a resource leaf or root
         if (!target.isResourceRoot())
         {
            JDFAttributeMap partMap = target.getPartMap();
            newRef.setPartMap(partMap);
         }
         // ID is appended to the resource root of target
         newRef.appendHRef(root, AttributeName.RREF, null);

         // move the resource to the closest common ancestor if it is not already
         // an ancestor of this
         JDFNode parent = root.getParentJDF();

         // move the resource to the closest common ancestor if it is not already
         // an ancestor of this
         while (parent != null && !parent.isAncestor(this))
         {
            parent = root.getParentJDF();
            if (parent == null)
            {
               break;
            }
            parent = parent.getParentJDF();
            if (parent == null)
            {
               newRef.deleteNode(); // cleanup
               throw new JDFException("appendRefElement resource is not in the same document");
            }

            root = (JDFResource)parent.getCreateResourcePool().moveElement(root, null);
         }

         return newRef;
      }

      ///   
      ///	 <summary> * Removes an inter resource link from this Element.
      ///	 *  </summary>
      ///	 * <param name="target"> Target to remove </param>
      ///	 
      public virtual void removeRefElement(JDFResource target)
      {
         string id = target.getID();

         if (id.Equals(JDFConstants.EMPTYSTRING))
         {
            throw new JDFException("RemoveRefElement: target has no id");
         }

         VElement v = getChildElementVector(target.getRefString(), null, null, true, 0, false);
         for (int i = 0; i < v.Count; i++)
         {
            JDFRefElement re = (JDFRefElement)v[i];

            if (re.getrRef().Equals(id) || re.getrSubRef().Equals(id))
            {
               re.deleteNode();
               break;
            }
         }
      }

      ///   
      ///	 <summary> * gets the vector of all RefElements
      ///	 *  </summary>
      ///	 * <returns> VElement - vector of JDFRefElements </returns>
      ///	 
      public virtual VElement getRefElements()
      {
         VElement v = getChildElementVector(null, null, null, true, 0, false);
         // loop backwords so that I don't invalidate the vector by deleting
         for (int i = v.Count - 1; i >= 0; i--)
         {
            KElement e = v.item(i);
            // cant be null
            if (!(e is JDFRefElement))
            {
               v.RemoveAt(i);
            }
         }
         return v;
      }

      ///   
      ///	 <summary> * UpDates rRefs attribute of this Element, corresponding to the child reference Elements of this Element.
      ///	 *  </summary>
      ///	 * @deprecated use KElement.fillHashSet(ElementName.RREF,null,hashSet) 
      ///	 
      [Obsolete("use KElement.fillHashSet(ElementName.RREF,null,hashSet)")]
      public virtual VString upDaterRefs()
      {
         VString vrRefs = new VString();
         VElement v = getChildrenByTagName(null, null, new JDFAttributeMap(JDFConstants.RREF, ""), false, true, 0);
         // grabemall

         int size = v.Count;
         for (int i = 0; i < size; i++)
         {
            KElement el_i = (v[i]);
            vrRefs.Add(el_i.getAttribute(JDFConstants.RREF, null, JDFConstants.EMPTYSTRING));
         }
         vrRefs.unify();
         return vrRefs;
      }

      ///   
      ///	 <summary> * inline refelements that match nodename and nameSpaceURI
      ///	 *  </summary>
      ///	 * <param name="nodeName"> name of the refelement (without the "Ref") </param>
      ///	 * <param name="nameSpaceURI"> </param>
      ///	 * <param name="bDirect"> if true, get direct children only, else recurse into all sub-elements </param>
      ///	 
      public virtual void inlineRefElements(string nodeName, string nameSpaceURI, bool bDirect)
      {
         VElement v = getRefElements();
         int i;
         int vSize = v.Count;
         for (i = 0; i < vSize; i++)
         {
            JDFRefElement re = (JDFRefElement)v[i];
            // it fits - inline it
            if (re.fitsName(nodeName, nameSpaceURI))
            {
               re.inlineRef();
            }
         }

         // now loop over all (!) children, to see if any descendants match
         if (!bDirect)
         {
            v = this.getChildElementVector_KElement(null, null, null, true, 0);
            vSize = v.Count;
            for (i = 0; i < vSize; i++)
            {
               if (v[i] is JDFElement)
               {
                  JDFElement e = (JDFElement)v[i];
                  e.inlineRefElements(nodeName, nameSpaceURI, bDirect);
               }
            }
         }
      }

      ///   
      ///	 <summary> * Get all children from the actual element matching the given conditions<br>
      ///	 * does NOT get refElement targets although the attributes are checked in the target elements in case of refElements
      ///	 *  </summary>
      ///	 * <param name="nodeName"> element name you are searching for </param>
      ///	 * <param name="nameSpaceURI"> nameSpace you are searching for </param>
      ///	 * <param name="mAttrib"> attributes you are lokking for </param>
      ///	 * <param name="bAnd"> if true, a child is only added if it has all attributes specified in Attributes mAttrib </param>
      ///	 * <param name="maxSize"> maximum size of the element vector </param>
      ///	 * <param name="bResolveTarget"> if true, returns the targets of the refElements<br>
      ///	 *            else the refElements are returned (if mAttrib != null), additionally the attributes of the target are
      ///	 *            checked)
      ///	 *  </param>
      ///	 * <returns> VElement - vector with all elements found
      ///	 *  </returns>
      ///	 * <seealso cref= org.cip4.jdflib.core.KElement#getChildElementVector(java.lang.String, java.lang.String,
      ///	 *      org.cip4.jdflib.datatypes.JDFAttributeMap, boolean, int, boolean) default: getChildElementVector(null,
      ///	 *      null,null, true, 0, false) </seealso>
      ///	 
      public override VElement getChildElementVector(string nodeName, string nameSpaceURI, JDFAttributeMap mAttrib, bool bAnd, int maxSize, bool bResolveTarget)
      {
         return getChildElementVector_JDFElement(nodeName, nameSpaceURI, mAttrib, bAnd, maxSize, bResolveTarget);
      }

      ///   
      ///	 <summary> * Gets children of 'this' by tag name, nameSpaceURI and attribute map, if the attribute map is not empty.<br>
      ///	 * Searches the entire tree including hidden nodes that are children of non-matching nodes
      ///	 *  </summary>
      ///	 * <param name="elementName"> elementname you are searching for </param>
      ///	 * <param name="nameSpaceURI"> nameSpace you are searching for </param>
      ///	 * <param name="mAttrib"> map of attributes you are looking for <br>
      ///	 *            Wildcards in the attribute map are supported </param>
      ///	 * <param name="bDirect"> if true, return value is a vector only of all direct child elements. <br>
      ///	 *            Otherwise the returned vector contains nodes of arbitrary depth </param>
      ///	 * <param name="bAnd"> if true, a child is only added, if it includes all attributes, specified in mAttrib </param>
      ///	 * <param name="maxSize"> maximum size of the element vector. maxSize is ignored if bDirect is false
      ///	 *  </param>
      ///	 * <returns> VElement: vector with all found elements
      ///	 *  </returns>
      ///	 * <seealso cref= org.cip4.jdflib.core.KElement#getChildElementVector(java.lang.String, java.lang.String,
      ///	 *      org.cip4.jdflib.datatypes.JDFAttributeMap, boolean, int, boolean)
      ///	 * 
      ///	 * @default getChildrenByTagName(s,null,null, false, true, 0) </seealso>
      ///	 
      public override VElement getChildrenByTagName(string elementName, string nameSpaceURI, JDFAttributeMap mAttrib, bool bDirect, bool bAnd, int maxSize)
      {

         return getChildrenByTagName(elementName, nameSpaceURI, mAttrib, bDirect, bAnd, maxSize, !isWildCard(elementName) && !elementName.EndsWith("Ref"));

      }

      ///   
      ///	 <summary> * Gets children of 'this' by tag name, nameSpaceURI and attribute map, if the attribute map is not empty.<br>
      ///	 * Searches the entire tree including hidden nodes that are children of non-matching nodes
      ///	 *  </summary>
      ///	 * <param name="elementName"> elementname you are searching for </param>
      ///	 * <param name="nameSpaceURI"> nameSpace you are searching for </param>
      ///	 * <param name="mAttrib"> map of attributes you are looking for <br>
      ///	 *            Wildcards in the attribute map are supported </param>
      ///	 * <param name="bDirect"> if true, return value is a vector only of all direct child elements. <br>
      ///	 *            Otherwise the returned vector contains nodes of arbitrary depth </param>
      ///	 * <param name="bAnd"> if true, a child is only added, if it includes all attributes, specified in mAttrib </param>
      ///	 * <param name="maxSize"> maximum size of the element vector. maxSize is ignored if bDirect is false </param>
      ///	 * <param name="bFollowRefs"> if true follow references of refElements, else return the refElement
      ///	 *  </param>
      ///	 * <returns> VElement: vector with all found elements
      ///	 *  </returns>
      ///	 * <seealso cref= org.cip4.jdflib.core.KElement#getChildElementVector(java.lang.String, java.lang.String,
      ///	 *      org.cip4.jdflib.datatypes.JDFAttributeMap, boolean, int, boolean)
      ///	 * 
      ///	 * @default getChildrenByTagName(s,null,null, false, true, 0) </seealso>
      ///	 
      public virtual VElement getChildrenByTagName(string elementName, string nameSpaceURI, JDFAttributeMap mAttrib, bool bDirect, bool bAnd, int maxSize, bool bFollowRefs)
      {
         VElement v = base.getChildrenByTagName(elementName, nameSpaceURI, mAttrib, bDirect, bAnd, maxSize);

         if (bFollowRefs == false)
            return v; // do not folow refs if explicit refs are requested

         if (v != null)
         {
            int size = v.Count;
            for (int i = 0; i < size; i++)
            {
               if (v[i] is JDFRefElement)
                  v[i] = ((JDFRefElement)v[i]).getTarget();
            }
         }

         return v;
      }

      ///   
      ///	 * <seealso cref= org.cip4.jdflib.core.KElement#getChildElementVector(java.lang.String, java.lang.String,
      ///	 *      org.cip4.jdflib.datatypes.JDFAttributeMap, boolean, int, boolean)
      ///	 *  </seealso>
      ///	 * <param name="nodeName"> </param>
      ///	 * <param name="nameSpaceURI"> </param>
      ///	 * <param name="mAttrib"> </param>
      ///	 * <param name="bAnd"> </param>
      ///	 * <param name="maxSize"> </param>
      ///	 * <param name="bResolveTarget"> - additional control how refelements are followed
      ///	 * @return </param>
      ///	 
      [MethodImpl(MethodImplOptions.Synchronized)]
      public virtual VElement getChildElementVector_JDFElement(string nodeName, string nameSpaceURI, JDFAttributeMap mAttrib, bool bAnd, int maxSize, bool bResolveTarget)
      {
         string nodeNameLocal = nodeName;
         string nameSpaceURILocal = nameSpaceURI;
         JDFAttributeMap mAttribLocal = mAttrib;
         int maxSizeLocal = maxSize;

         VElement v = new VElement();
         if (isWildCard(nodeNameLocal))
         {
            nodeNameLocal = null;
         }
         if (isWildCard(nameSpaceURILocal))
         {
            nameSpaceURILocal = null;
         }
         if (mAttribLocal != null && mAttribLocal.IsEmpty())
         {
            mAttribLocal = null;
         }
         if (maxSizeLocal == 0)
         {
            maxSizeLocal = -1;
         }

         bool bAlwaysFit = nodeNameLocal == null && nameSpaceURILocal == null;
         bool bMapEmpty = mAttribLocal == null;

         int iSize = 0;
         KElement kElem = getFirstChildElement();

         while (kElem != null)
         {
            if (bAlwaysFit || kElem.fitsName(nodeNameLocal, nameSpaceURILocal))
            {
               if (bResolveTarget && (kElem is JDFRefElement))
               {
                  try
                  {
                     JDFRefElement @ref = (JDFRefElement)kElem;
                     KElement target = @ref.getTarget();

                     // in case there is no element for the REF, target will
                     // be null and will be skipped
                     if (target != null)
                     { // we want the jdfElem version of IncludesAttributes,
                        // so we must upcast
                        if (bMapEmpty || target.includesAttributes(mAttribLocal, bAnd))
                        {
                           v.Add(target);
                           iSize++;
                        }
                     }
                  }
                  catch (JDFException)
                  {
                     // simply skip invalid refelements
                  }
               }
               else if (bMapEmpty || kElem.includesAttributes(mAttribLocal, bAnd))
               {
                  v.Add(kElem);
                  iSize++;
               }
               if (iSize == maxSizeLocal)
               {
                  break;
               }
            }
            kElem = kElem.getNextSiblingElement();
         }
         return v;
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.core.KElement#getElementNameVector()
      //	 
      public override VString getElementNameVector()
      {
         VElement e = getChildElementVector(null, null, null, true, 0, false);

         VString v = new VString();
         for (int i = 0; i < e.Count; i++)
         {
            KElement el = e[i];
            string s = el.Name;
            if (el is JDFRefElement)
            {
               s = s.Substring(0, s.Length - AttributeName.REF.Length);
            }
            v.appendUnique(s);
         }
         return v;
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.core.KElement#GetElement(String, String, int)
      //	 * 
      //	 * @default getElement(nodeName, null, 0)
      //	 
      public override KElement getElement(string nodeName, string nameSpaceURI, int iSkip)
      {
         return getElement_JDFElement(nodeName, nameSpaceURI, iSkip);
      }

      ///   
      ///	 <summary> * same as KElement.GetElement, but follows references as well.<br>
      ///	 * Thus the returned value is the target of the refElement unless the requested element is explicitely a refElement,
      ///	 * which is specified by requesting an element with nodeName="XXXRef".<br>
      ///	 * Invalid refelements are simply skipped and are not filled into the vector
      ///	 *  </summary>
      ///	 * <param name="nodeName"> name of the child node to get </param>
      ///	 * <param name="nameSpaceURI"> namespace to search for </param>
      ///	 * <param name="iSkip"> get the iSkipth element that fits
      ///	 *  </param>
      ///	 * <returns> KElement the matching element
      ///	 * 
      ///	 * @default getElement_JDFElement(nodeName, null, 0) </returns>
      ///	 
      public virtual KElement getElement_JDFElement(string nodeName, string nameSpaceURI, int iSkip)
      {
         int iSkipLocal = iSkip;
         // loop over the list
         int i = 0;
         if (iSkipLocal < 0)
            iSkipLocal = numChildElements_JDFElement(nodeName, nameSpaceURI) + iSkipLocal;
         if (iSkipLocal < 0)
            return null;
         KElement jdfElem = getFirstChildElement();
         bool bExplicitRefElement = (nodeName != null) && (nodeName.EndsWith(JDFConstants.REF));

         while (jdfElem != null)
         {
            if (jdfElem.fitsName(nodeName, nameSpaceURI))
            {
               // this guy is the one
               if (i++ == iSkipLocal)
               {
                  // follow valid (!) refElements, invalid refelements are
                  // ignored
                  // 300502 RP added check for explicit refelements
                  if (jdfElem is JDFRefElement && !bExplicitRefElement)
                  {
                     try
                     {
                        JDFRefElement re = (JDFRefElement)jdfElem;
                        KElement target = re.getTarget();
                        if (target != null)
                        {
                           return target;
                        }
                     }
                     catch (JDFException)
                     {
                        // simply ignore invalid refelements
                     }
                     i--; // this one was screwed up -> don't count it
                  }
                  else
                  { // not a refElement or explicitly want the refElement
                     return jdfElem;
                  }
               }
            }

            jdfElem = jdfElem.getNextSiblingElement();
         }

         // found no match
         return null;
      }

      ///   
      ///	 <summary> * same as <seealso cref="KElement#numChildElements(String, String)"/>, but also follows references.<br>
      ///	 * Invalid refelements are simply skipped.
      ///	 *  </summary>
      ///	 * <param name="nodeName"> the nodes to count </param>
      ///	 * <param name="nameSpaceURI"> the nameSpace to look in </param>
      ///	 * <returns> int - the number of child elements
      ///	 * 
      ///	 * @default numChildElements(String nodeName, null) </returns>
      ///	 
      public override int numChildElements(string nodeName, string nameSpaceURI)
      {
         return getChildElementVector(nodeName, nameSpaceURI, null, true, 0, false).Count;
      }

      public virtual int numChildElements_JDFElement(string nodeName, string nameSpaceURI)
      {
         return getChildElementVector_JDFElement(nodeName, nameSpaceURI, null, true, 0, false).Count;
      }

      ///   
      ///	 <summary> * Remove children that match nodeName and nameSpaceURI
      ///	 *  </summary>
      ///	 * <param name="nodeName"> name of the child node to get, if empty or null remove all </param>
      ///	 * <param name="nameSpaceURI"> namespace to search for </param>
      ///	 * <param name="mAttrib"> attribute map to search for </param>
      ///	 
      public override void removeChildren(string nodeName, string nameSpaceURI, JDFAttributeMap mAttrib)
      {
         // the loop allows jdf resources to recursively remove all children
         while (true)
         {
            VElement v = getChildElementVector_JDFElement(nodeName, nameSpaceURI, mAttrib, true, 0, false);
            if (v.Count > 0)
            {
               for (int i = 0; i < v.Count; i++)
               {
                  // may NOT call removeChild since JDFResource calls to this
                  // routine may actually change the parent
                  KElement kelem = v[i];
                  kelem.deleteNode();
               }
            }
            else
            {
               return;
            }
         }
      }

      ///   
      ///	 <summary> * is the ressource r linkable by this? used by ResorceLink and refElement
      ///	 *  </summary>
      ///	 * <param name="r"> the resource to link to </param>
      ///	 * <returns> boolean - true if r is at a valid position </returns>
      ///	 
      protected internal virtual bool validResourcePosition(JDFResource r)
      {
         if (r == null)
         {
            return false;
         }
         JDFNode nodeResource = r.getParentJDF();
         JDFNode nodeLink = getParentJDF();
         if ((nodeResource != null) && (nodeLink != null))
         {
            if (nodeResource.Equals(nodeLink))
            {
               return true;
            }
            if (nodeResource.isAncestor(nodeLink))
            {
               return true;
            }
         }
         else if (getDeepParent(ElementName.JMF, 0) != null)
         {
            // they are in the same signal, command etc..
            return getDeepParentChild(ElementName.JMF) == r.getDeepParentChild(ElementName.JMF);
         }

         return false;
      }

      ///   
      ///	 <summary> * remove child node
      ///	 *  </summary>
      ///	 * <param name="node"> name of the child node to remove, if empty or "*" remove all </param>
      ///	 * <param name="nameSpaceURI"> namespace to search for </param>
      ///	 * <param name="n"> number of nodes to skip before deleting </param>
      ///	 * <returns> KElement - the removed node </returns>
      ///	 
      public override KElement removeChild(string node, string nameSpaceURI, int n)
      {
         // use KElement because I do not want to remove the target
         VElement v = getChildElementVector_JDFElement(node, nameSpaceURI, null, true, 0, false);

         if (n >= v.Count)
         {
            return null;
         }
         // may NOT call removeChild since JDFResource calls to this routine may
         // actually change the parent
         KElement kelem = v[n];
         return kelem.deleteNode();
      }

      ///   
      ///	 <summary> * getIDPrefix
      ///	 *  </summary>
      ///	 * <returns> the default ID prefix of non-overwritten JDF elements </returns>
      ///	 
      public virtual string getIDPrefix()
      {
         return "l";
      }

      ///   
      ///	 <summary> * create and append a unique id, keep the existing one if it already exists
      ///	 *  </summary>
      ///	 * <returns> String - the value of the ID attribute after setting
      ///	 * 
      ///	 * @default appendAnchor(null) </returns>
      ///	 
      public virtual string appendAnchor(string strName)
      {
         string strNameLocal = strName;

         if (hasAttribute(AttributeName.ID))
         {
            return this.getAttribute(AttributeName.ID, null, null);
         }
         else if ((strNameLocal == null) || strNameLocal.Equals(JDFConstants.EMPTYSTRING))
         {
            string local = "";
            JDFNode n = getJDFRoot();
            if (n != null)
            {
               local = n.getSpawnID(true);

               if (!isWildCard(local))
                  local = "." + StringUtil.rightStr(local, 6) + ".";
            }
            JDFJMF m = getJMFRoot();
            if (m != null)
            {
               local = m.getSenderID();
               if (!isWildCard(local))
               {
                  local = StringUtil.replaceCharSet(local, " \t\n\f", null, 0);
                  local = "." + local + ".";
               }
            }

            strNameLocal = getIDPrefix() + local + uniqueID(0);
         }
         setAttribute(AttributeName.ID, strNameLocal, null);

         return strNameLocal;
      }

      ///   
      ///	 <summary> * put a timestamp in an attribute of the current node
      ///	 *  </summary>
      ///	 * <param name="attributeName"> the attribute name to timestamp </param>
      ///	 * <param name="timestamp"> the timestamp </param>
      ///	 
      public virtual void setAttributeNameTimeStamp(string attributeName, JDFDate timestamp)
      {
         JDFDate timestampLocal = timestamp;

         if (timestampLocal == null)
         {
            timestampLocal = new JDFDate();
         }
         setAttribute(attributeName, timestampLocal.DateTimeISO, null);
      }

      ///   
      ///	 <summary> * create a string link from an integer
      ///	 *  </summary>
      ///	 * <param name="id"> the integer value to convert to an ID </param>
      ///	 * @deprecated 060307 internal legacy method 
      ///	 * <returns> String - a unique ID string </returns>
      ///	 
      [Obsolete("060307 internal legacy method")]
      public virtual string idString(int id)
      {
         string s = JDFConstants.LINK;
         string strID = Convert.ToString(id); // int.ToString(id);

         for (int i = JDFConstants.LINK.Length - strID.Length; i > 0; i--)
         {
            s += "0";
         }

         s += strID;
         return s;
      }

      ///   
      ///	 <summary> * static version of GetParentJDF - get the local JDF node that this element resides in. <br>
      ///	 * if e is a JDF node, return it's parent<br>
      ///	 * if e is the root JDF node, return a null reference
      ///	 *  </summary>
      ///	 * <param name="e"> the KElement (may be in foreign namespace)
      ///	 *  </param>
      ///	 * <returns> JDFNode - the local parent JDF of this element </returns>
      ///	 
      public static JDFNode getParentJDF(KElement e)
      {
         KElement e2 = e;
         if (e2 is JDFNode)
         {
            e2 = e2.getParentNode_KElement();
         }
         if (e2 == null)
         {
            return null;
         }
         e2 = e2.getDeepParent(ElementName.JDF, 0);
         return e2 == e ? null : (JDFNode)e2;
      }

      ///   
      ///	 <summary> * get the local JDF node that this element resides in<br>
      ///	 * if this is a JDF node, return it's parent<br>
      ///	 * if this is the root JDF node, return a null reference
      ///	 *  </summary>
      ///	 * <returns> JDFNode - the local parent JDF of this element </returns>
      ///	 
      public virtual JDFNode getParentJDF()
      {
         return getParentJDF(this);
      }

      ///   
      ///	 <summary> * get invalid attributes
      ///	 *  </summary>
      ///	 * <param name="level"> <seealso cref="KElement.EnumValidationLevel validation level"/> </param>
      ///	 * <param name="bIgnorePrivate"> if true, do not worry about attributes in other namespaces </param>
      ///	 * <param name="nMax"> maximum size of the returned vector </param>
      ///	 * <returns> VString - a vector of invalid attribute names
      ///	 * 
      ///	 * @default getInvalidAttributes(level, true, 9999999) </returns>
      ///	 
      public virtual VString getInvalidAttributes(EnumValidationLevel level, bool bIgnorePrivate, int nMax)
      {

         AttributeInfo ai = getTheAttributeInfo();
         VString v = getInvalidAttributes_JDFElement(level, bIgnorePrivate, nMax, ai);
         string s = getNamespaceURI();
         if (s != null && s.ToLower().IndexOf(JDFConstants.CIP4ORG) >= 0 && !s.Equals(JDFConstants.JDFNAMESPACE))
         {
            if (v == null)
               v = new VString(AttributeName.XMLNS, null);
            else
               v.appendUnique(AttributeName.XMLNS);
         }
         s = getAttribute(AttributeName.XMLNSXSI, null, null);
         {
            if ((s != null) && (!s.Equals(AttributeName.XSIURI)))
               v.appendUnique(AttributeName.XMLNSXSI);
         }
         return v;
      }

      ///   
      ///	 <summary> * get invalid attributes
      ///	 *  </summary>
      ///	 * <param name="level"> <seealso cref="KElement#EnumValidationLevel validation level"/> </param>
      ///	 * <param name="bIgnorePrivate"> if true, do not worry about attributes in other namespaces </param>
      ///	 * <param name="nMax"> maximum size of the returned vector </param>
      ///	 * <returns> VString - a vector of invalid attribute names
      ///	 * 
      ///	 * @default getInvalidAttributes_JDFElement(level, true, 9999999) </returns>
      ///	 
      private VString getInvalidAttributes_JDFElement(EnumValidationLevel level, bool bIgnorePrivate, int nMax, AttributeInfo ai)
      {
         VString vAttsReturn = new VString();
         int numAtts = 0;
         VString vAtts = getAttributeVector_KElement();
         for (int i = 0; i < vAtts.Count; i++)
         {
            string key = vAtts[i];
            if (!ai.validAttribute(key, getAttribute(key, null, null), level))
            {
               vAttsReturn.Add(key);
               if (++numAtts >= nMax)
               {
                  return vAttsReturn;
               }
            }
         }

         if (EnumValidationLevel.isRequired(level) && !isIncomplete())
         {
            vAttsReturn.addAll(getMissingAttributes(nMax).ToArray());
         }

         if (vAttsReturn.Count >= nMax)
         {
            return vAttsReturn;
         }

         vAttsReturn.addAll(getUnknownAttributes(bIgnorePrivate, nMax).ToArray());
         return vAttsReturn;
      }

      ///   
      ///	 <summary> * check whether this is a subelem of an incomplete resource and thus need not contain all traits
      ///	 * 
      ///	 * @return </summary>
      ///	 
      private bool isIncomplete()
      {
         JDFResource r = JDFResource.getResourceRoot(this);
         return r == null ? false : EnumResStatus.Incomplete.Equals(r.getResStatus(false));
      }

      ///   
      ///	 <summary> * get invalid elements
      ///	 *  </summary>
      ///	 * <param name="level"> validation level </param>
      ///	 * <param name="bIgnorePrivate"> if true, do not worry about elements in other namespaces </param>
      ///	 * <param name="nMax"> maximum size of the returned vector </param>
      ///	 * <returns> VString - a vector of invalid element names
      ///	 * 
      ///	 * @default GetInvalidElements(level, true, 999999) </returns>
      ///	 
      public virtual VString getInvalidElements(EnumValidationLevel level, bool bIgnorePrivate, int nMax)
      {
         return getInvalidElements_JDFElement(level, bIgnorePrivate, nMax);
      }

      ///   
      ///	 <summary> * Method GetInvalidElements_JDFElement.
      ///	 *  </summary>
      ///	 * <param name="level"> validation level </param>
      ///	 * <param name="bIgnorePrivate"> if true, do not worry about elements in other namespaces </param>
      ///	 * <param name="nMax"> maximum size of the returned vector </param>
      ///	 * <returns> VString - a vector of invalid element names </returns>
      ///	 
      public virtual VString getInvalidElements_JDFElement(EnumValidationLevel level, bool bIgnorePrivate, int nMax)
      {
         VString vBad = new VString();
         int i = 0;
         int num = 0;
         VElement v = getChildElementVector(null, null, null, true, 0, false);

         for (i = 0; i < v.Count; i++)
         {
            KElement e = v[i];
            if (!e.isValid(level))
            {
               vBad.Add(e.LocalName);
               if (++num >= nMax)
               {
                  return vBad;
               }
            }
         }

         if (EnumValidationLevel.isRequired(level) && !isIncomplete())
         {
            vBad.appendUnique(new VString(getMissingElements(nMax)));
         }

         vBad.appendUnique(new VString(getUnknownElements(bIgnorePrivate, nMax)));

         return vBad;
      }

      ///   
      ///	 <summary> * Set attribute CommentURL
      ///	 *  </summary>
      ///	 * <param name="value"> the CommentURL value </param>
      ///	 
      public virtual void setCommentURL(string @value)
      {
         setAttribute(AttributeName.COMMENTURL, @value, null);
      }

      ///   
      ///	 <summary> * Get string attribute CommentURL
      ///	 *  </summary>
      ///	 * <returns> the value of the attribute commentURL </returns>
      ///	 
      public virtual string getCommentURL()
      {
         return getAttribute(AttributeName.COMMENTURL, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * Get the string of a refelement that points to this, i.e.NodeName+"Ref"
      ///	 *  </summary>
      ///	 * <returns> the nodename of a refelement </returns>
      ///	 
      protected internal virtual string getRefString()
      {
         return Name + JDFConstants.REF;
      }

      ///   
      ///	 <summary> * get the LDFLib version
      ///	 *  </summary>
      ///	 * <returns> the JDFLib version </returns>
      ///	 
      public virtual string jdfVersion()
      {
         return "1.3";
      }

      ///   
      ///	 <summary> * returns the official JDF schema URI for a particular version
      ///	 *  </summary>
      ///	 * <returns> the URL that fits to majorVersion and minorVersion - null if not supported </returns>
      ///	 
      public static string getSchemaURL() // fool proof schema url as of November
      // 5th, 2003
      {
         return getSchemaURL(1, 1); // "http://www.CIP4.org/JDFSchema_1_1"
      }

      ///   
      ///	 * <param name="majorVersion"> the major version - only 1 is supported </param>
      ///	 * <param name="minorVersion"> the minor version - only 0 or 1 are supported </param>
      ///	 * <returns> the URL that fits to majorVersion and minorVersion - null if not supported </returns>
      ///	 
      public static string getSchemaURL(int majorVersion, int minorVersion)
      {
         if (majorVersion == 1)
         {
            if (minorVersion == 0)
            {
               return "http://www.CIP4.org/JDFSchema_1";
            }
            else if (minorVersion >= 1)
            {
               return "http://www.CIP4.org/JDFSchema_1_1";
            }
         }
         // not supported
         return null;
      }

      ///   
      ///	 <summary> * returns the JDFElement::EnumVersion, where new elements will be generated in by default
      ///	 *  </summary>
      ///	 * <returns> the default version </returns>
      ///	 
      public static EnumVersion getDefaultJDFVersion()
      {
         return defaultVersion;
      }

      
      ///   
      ///	 <summary> * sets the JDFElement::EnumVersion, where new elements will be generated in by default<br>
      ///	 * Attention this is static and global. Therefore it should generally be be called on initialization
      ///	 *  </summary>
      ///	 * <param name="vers"> the new default version </param>
      ///	 
      [MethodImpl(MethodImplOptions.Synchronized)]
      public static void setDefaultJDFVersion(EnumVersion vers)
      {
         defaultVersion = vers;
      }

      ///   
      ///	 <summary> * get Element ID prefix
      ///	 *  </summary>
      ///	 * <returns> the ID prefix of JDFElement </returns>
      ///	 
      public virtual string getElementIDPrefix()
      {
         return "l";
      }

      ///   
      ///	 <summary> * gets a new ID for the element
      ///	 *  </summary>
      ///	 * <param name="lastID"> the highest ID that has been created before
      ///	 *  </param>
      ///	 * <returns> the unique ID string </returns>
      ///	 
      public virtual string newID(string lastID)
      {
         string idPrefix = getIDPrefix();
         if (lastID == null || lastID.Equals(JDFConstants.EMPTYSTRING))
         {
            return idPrefix + uniqueID(0);
         }

         JDFElement p = (JDFElement)getParentNode_KElement();
         if (p == null)
         {
            return idPrefix + uniqueID(0);
         }

         return generateDotID(AttributeName.ID, null);
      }

      ///   
      ///	 <summary> * generate a unique id in the syntax newID=oldID.nn <br>
      ///	 * nn is a unique number, that is generated as the first integer higher than the number of sibling elements with the
      ///	 * same name. <br>
      ///	 * Note that it is the responsibilty of the caller not to provide multiple siblings that use the same base IDs.
      ///	 *  </summary>
      ///	 * <param name="key"> the attribute that is to be set to this ID, e.g. jobpartid </param>
      ///	 * <param name="nameSpaceURI"> the attribute namespace that is to be set to this ID, e.g. jobpartid </param>
      ///	 * <returns> String - the newly generated ID in the syntax parentID.nn </returns>
      ///	 
      public virtual string generateDotID(string key, string nameSpaceURI)
      {
         string nodeName = LocalName;
         JDFElement p = (JDFElement)getParentNode_KElement();
         string idPrefix = getIDPrefix();
         if (p == null)
         {
            return idPrefix + uniqueID(0);
         }
         string parentID = p.getAttribute(key, nameSpaceURI, null);
         if (parentID == null)
         {
            return idPrefix + uniqueID(0);
         }

         VElement vn = p.getChildElementVector(nodeName, nameSpaceURI, null, true, 0, false);
         int siz = vn.Count;
         parentID += JDFConstants.DOT;

         for (int i = siz; i < 10000; i++)
         {
            string nn = parentID + i;
            bool bFound = false;
            for (int j = 0; j < siz; j++)
            {
               if (nn.Equals(((JDFElement)vn[j]).getAttribute(key, nameSpaceURI, null)))
               {
                  bFound = true;
                  break;
               }
            }
            // got an unused id matching out x.y algorithm - return it
            if (!bFound)
            {
               return nn;
            }
         }
         // panic exit!
         return idPrefix + uniqueID(0);
      }

      private static int m_lStoreID = 0;
      private static bool bIDDate = true;
      private static bool bFixVersionIDFix = false;

      ///   
      ///	 <summary> * UniqueID - create a unique id based on date and time + a counter - 6 digits are taken from id Normally this </summary>
      ///	 * should only be used internally, <seealso cref= JDFElement.appendAnchor() for details.
      ///	 *  </seealso>
      ///	 * <param name="id"> the starting id of the ID - should normally be 0 in order to increment
      ///	 *  </param>
      ///	 * <returns> the ID string value
      ///	 * 
      ///	 * @default uniqueID(0) </returns>
      ///	 
      [MethodImpl(MethodImplOptions.Synchronized)]
      public static string uniqueID(int id)
      {
         if (id != 0)
         {
            m_lStoreID = id;
         }
         string s = "00000" + Convert.ToString(m_lStoreID); // int.ToString(m_lStoreID);
         m_lStoreID = ++m_lStoreID % 100000;
         // time + 6 digits (ID)
         if (bIDDate)
         {
            // Java to C# Conversion - TODO: Test this date format
            string date = DateTime.Now.ToString(dateFormatter);
            return "_" + date + "_" + s.Substring(s.Length - 6);
         }
         return "_" + s.Substring(s.Length - 6);
      }

      ///   
      ///	 <summary> * set the ID generation algorithm to include a date
      ///	 *  </summary>
      ///	 * <param name="bLong"> if true (default), the date and time is used to generate long IDs </param>
      ///	 
      public static void setLongID(bool bLong)
      {
         bIDDate = bLong;
      }

      ///   
      ///	 <summary> * defines an enumerated list of attributes ; used by the automated code generator
      ///	 *  </summary>
      ///	 * <param name="key"> the attribute name </param>
      ///	 * <param name="v"> comma separated string of allowed values </param>
      ///	 * <param name="nameSpaceURI"> attribute namespace uri </param>
      ///	 * <param name="def"> the default enum if it does not exist </param>
      ///	 * <param name="bInherit"> if true: recurse into parent elements when searching the attribute as well
      ///	 * 
      ///	 * @since 300402
      ///	 *  </param>
      ///	 * <returns> int - the enumeration equivalent of the attribute of the attribute def if </returns>
      ///	 * @deprecated use EnumXYZ.getEnum(getAttribute(key, namespaceURI, def)
      ///	 * @default getEnumAttribute(key, v, null, -1, false) 
      ///	 
      [Obsolete("use EnumXYZ.getEnum(getAttribute(key, namespaceURI, def)")]
      public virtual int getEnumAttribute(string key, ArrayList v, string nameSpaceURI, int def, bool bInherit)
      {
         string s = null;
         int i = def;

         if (bInherit)
         {
            s = getInheritedAttribute(key, nameSpaceURI, JDFConstants.EMPTYSTRING);
         }
         else
         {
            s = getAttribute(key, nameSpaceURI, JDFConstants.EMPTYSTRING);
         }

         if (!s.Equals(JDFConstants.EMPTYSTRING) && v.Contains(s))
         {
            i = v.IndexOf(s);
         }

         return i;
      }

      ///   
      ///	 <summary> * defines an enumerated list of attributes ; used by the automated code generator
      ///	 *  </summary>
      ///	 * <param name="key"> the attribute name </param>
      ///	 * <param name="v"> comma separated string of allowed values </param>
      ///	 * <param name="nameSpaceURI"> attribute namespace uri </param>
      ///	 * <param name="def"> the default enum if it does not exist </param>
      ///	 * <param name="bInherit"> if true: recurse into parent elements when searching the attribute as well
      ///	 *  </param>
      ///	 * <returns> the Vector of enumeration equivalents of the attribute
      ///	 * @since 300402 </returns>
      ///	 * @deprecated use getEnumerationsAttribute(key, nameSpaceURI, EnumXYZ.getEnum(0), bInherit)
      ///	 * @default getEnumerationsAttribute(key, allowedValues, null, -1, false) 
      ///	 
      [Obsolete("use getEnumerationsAttribute(key, nameSpaceURI, EnumXYZ.getEnum(0), bInherit)")]
      public virtual ArrayList getEnumerationsAttribute(string key, VString v, string nameSpaceURI, int def, bool bInherit)
      {
         VString vAllowed = new VString();
         vAllowed.addAll(v.ToArray());

         string strAtt = JDFConstants.EMPTYSTRING;
         VString vs = new VString();
         VString vAtts = null;

         if (bInherit)
         {
            strAtt = getInheritedAttribute(key, nameSpaceURI, JDFConstants.EMPTYSTRING);
         }
         else
         {
            strAtt = getAttribute(key, nameSpaceURI, JDFConstants.EMPTYSTRING);
         }
         if (strAtt.Equals(JDFConstants.EMPTYSTRING))
         {
            vs.Add(strAtt);
         }
         vAtts = new VString(StringUtil.tokenize(strAtt, JDFConstants.BLANK, false));
         vs.addAll(vAtts.ToArray());

         ArrayList ret = new ArrayList();
         if (vs.IsEmpty())
         {
            if (def >= 0)
            {
               ret.Add(def); // (new int(def));
            }
            return ret;
         }

         // 080502 RP was vAllowed,size - oops
         for (int i = 0; i < vs.Count; i++)
         {
            int enumIndex = vAllowed.index(vs.stringAt(i));
            if (enumIndex >= 0)
            {
               ret.Add(enumIndex); // (new int(enumIndex));
            }
            else
            {
               // illegal value
               ret.Add(-1); // (new int(-1));
            }
         }

         return ret;
      }

      ///   
      ///	 <summary> * defines an enumerated list of attributes; used by the automated code generator
      ///	 *  </summary>
      ///	 * <param name="key"> the attribute local name </param>
      ///	 * <param name="nameSpaceURI"> the namespace URI </param>
      ///	 * <param name="enu"> a dummy enumeration of the correct type, typically EnumXYZ.getEnum(0) </param>
      ///	 * <param name="bInherit"> if true, also recurse into parent elements when searching the attribute </param>
      ///	 * <returns> Vector of ValuedEnum, null if no enum was set </returns>
      ///	 
      public virtual List<ValuedEnum> getEnumerationsAttribute(string key, string nameSpaceURI, ValuedEnum enu, bool bInherit)
      {
         string strAtt = null;
         List<ValuedEnum> vEnum = new List<ValuedEnum>();

         if (bInherit)
         {
            strAtt = getInheritedAttribute(key, nameSpaceURI, null);
         }
         else
         {
            strAtt = getAttribute(key, nameSpaceURI, null);
         }
         if (strAtt == null)
         {
            return null;
         }

         VString vAtts = new VString(StringUtil.tokenize(strAtt, JDFConstants.BLANK, false));

         try
         {
            System.Type[] methodArgs = { typeof(string) };
            MethodInfo m = enu.GetType().GetMethod("getEnum", methodArgs);
            for (int i = 0; i < vAtts.Count; i++)
            {
               object[] args = { vAtts[i] };
               ValuedEnum ve = (ValuedEnum)m.Invoke(null, args);
               // there was an invalid token
               if (ve != null)
               {
                  vEnum.Add(ve);

               }
            }
         }
         catch (System.Security.SecurityException)
         {
            // in case of exceptions, simply apply NMTOKENS rule
         }
         catch (MethodAccessException)
         {
            // in case of exceptions, simply apply NMTOKENS rule
         }
         catch (ArgumentException)
         {
            // in case of exceptions, simply apply NMTOKENS rule
         }
         catch (UnauthorizedAccessException)
         {
            // in case of exceptions, simply apply NMTOKENS rule
         }
         catch (System.Reflection.TargetInvocationException)
         {
            // in case of exceptions, simply apply NMTOKENS rule
         }
         // all were ok
         return vEnum.Count == 0 ? null : vEnum;
      }

      ///   
      ///	 <summary> * set an enumerated list of attributes; used by the automated code generator
      ///	 *  </summary>
      ///	 * <param name="key"> the attribute name </param>
      ///	 * <param name="value"> the enumeration vector </param>
      ///	 * <param name="String"> nameSpaceURI attribute namespace uri </param>
      ///	 * <exception cref="JDFException"> wrong data type in vector </exception>
      ///	 
      public virtual void setEnumerationsAttribute(string key, List<ValuedEnum> @value, string nameSpaceURI)
      {
         string s = null;
         if (@value != null)
         {
            int n = 0;
            IEnumerator valueIterator = @value.GetEnumerator();
            while (valueIterator.MoveNext())
            {
               object o = valueIterator.Current;
               if (!(o is ValuedEnum))
               {
                  throw new JDFException("setEnumerationsAttribute: wrong data type in vector");
               }

               if (n++ > 0)
               {
                  s += JDFConstants.BLANK;
               }
               else
               {
                  s = "";
               }

               s += ((ValuedEnum)o).getName();
            }
         }

         setAttribute(key, s, nameSpaceURI);
      }

      ///   
      ///	 <summary> * is the attribute valid and of type iType? <br>
      ///	 * iType is of type EnumAttributeType, but may be expanded in child classes
      ///	 *  </summary>
      ///	 * <param name="key"> the attribute name </param>
      ///	 * <param name="iType"> the attribute type </param>
      ///	 * <param name="bRequired"> true if this attribute is required </param>
      ///	 * <param name="nameSpaceURI"> attribute namespace uri
      ///	 *  </param>
      ///	 * <returns> boolean: true if the attribute is valid
      ///	 * 
      ///	 * @tbd implement URL validation </returns>
      ///	 * @deprecated clean up attributeInfo tables instead use KElement public boolean validAttribute(String key,String
      ///	 *             nameSpaceURI, EnumValidationLevel level)
      ///	 * 
      ///	 * @default ValidAttribute(key, iType, bRequired, null) 
      ///	 
      [Obsolete("clean up attributeInfo tables instead use KElement public boolean validAttribute(String key,String")]
      public virtual bool validAttribute(string key, AttributeInfo.EnumAttributeType iType, bool bRequired, string nameSpaceURI)
      {

         if (!hasAttribute(key, null, false))
         {
            return !bRequired;
         }
         string val = getAttribute(key, nameSpaceURI, null);
         return AttributeInfo.validStringForType(val, iType, null);
      }

      ///   
      ///	 <summary> * ValidEnumAttribute - is the attribute valid and does it fit allowedValues, iType is of type EnumAttributeType but
      ///	 * may be expanded in child classes
      ///	 *  </summary>
      ///	 * <param name="key"> the attribute name </param>
      ///	 * <param name="v"> Vector with all valid enums </param>
      ///	 * <param name="bRequired"> true if this attribute is required </param>
      ///	 * <param name="nameSpaceURI"> attribute namespace uri
      ///	 *  </param>
      ///	 * <returns> booelan - true if the attribute is valid </returns>
      ///	 * @deprecated use getTheAttributeInfo instead
      ///	 * @default ValidEnumAttribute(key, v, bRequired, null) 
      ///	 
      [Obsolete("use getTheAttributeInfo instead")]
      public virtual bool validEnumAttribute(string key, ArrayList v, bool bRequired, string nameSpaceURI)
      {
         if (!hasAttribute(key, nameSpaceURI, false))
         {
            return !bRequired;
         }
         return getEnumAttribute(key, v, nameSpaceURI, -1, false) >= 0;
      }

      ///   
      ///	 <summary> * is the attribute valid and does it fit allowedValues. iType is of type EnumAttributeType but may be expanded in
      ///	 * child classes
      ///	 *  </summary>
      ///	 * <param name="key"> the attribute name </param>
      ///	 * <param name="vs"> comma separated string of allowed values </param>
      ///	 * <param name="bRequired"> true if this attribute is required </param>
      ///	 * <param name="nameSpaceURI"> attribute namespace uri </param>
      ///	 * <returns> true, if the attribute is valid </returns>
      ///	 * @deprecated use getTheAttributeInfo instead 
      ///	 
      [Obsolete("use getTheAttributeInfo instead")]
      public virtual bool validEnumerationsAttribute(string key, VString vs, bool bRequired, string nameSpaceURI)
      {
         if (!hasAttribute(key, nameSpaceURI, false))
         {
            return !bRequired;
         }

         ArrayList v = getEnumerationsAttribute(key, vs, nameSpaceURI, -1, false);

         for (int i = 0; i < v.Count; i++)
         {
            if (((int)v[i]) == -1)
            {
               return false;
            }
         }

         return true;
      }

      ///   
      ///	 <summary> * get the string value from an enumerated set of values
      ///	 *  </summary>
      ///	 * <param name="value"> - the enum that is to be translated to a string </param>
      ///	 * <param name="allowedValues"> - comma separated string of allowed values </param>
      ///	 * @deprecated use EnumXYZ.getEnum(int) 
      ///	 * <returns> String - the string for the enum </returns>
      ///	 
      [Obsolete("use EnumXYZ.getEnum(int)")]
      public virtual string getEnumString(int @value, string allowedValues)
      {
         ArrayList vs = new ArrayList();
         vs.AddRange(StringUtil.tokenize(allowedValues, JDFConstants.COMMA, false));

         if (@value >= vs.Count)
         {
            return JDFConstants.EMPTYSTRING;
         }

         return (string)vs[@value];
      }

      ///   
      ///	 <summary> * Get the document object that owns this
      ///	 *  </summary>
      ///	 * <returns> JDFDoc the owner document of this </returns>
      ///	 
      public virtual JDFDoc getOwnerDocument_JDFElement()
      {
         XmlDocument doc = OwnerDocument;
         return new JDFDoc(doc);
      }

      ///   
      ///	 <summary> * map a node's localname to an enumeration defined by allowedValues
      ///	 *  </summary>
      ///	 * <param name="allowedValues"> comma separated string of allowed values
      ///	 *  </param>
      ///	 * <returns> int - the enum that corresponds to the nodename </returns>
      ///	 
      public virtual int getEnumNodeName(ArrayList allowedValues)
      {
         // 050629 RP made localname. TBD actually check whether the namespace is
         // ok
         string s = LocalName;

         for (int i = 0; i < allowedValues.Count; i++)
         {
            if (s.ToLower().Equals(((string)allowedValues[i]).ToLower()))
            {
               return i;
            } // von Thomas nachgezogen
         }

         return 0; // unknown or illegal
      }

      ///   
      ///	 <summary> * GetPartMapVector returns a vector of partmaps, null if no parts are present
      ///	 *  </summary>
      ///	 * <returns> Vector </returns>
      ///	 
      public virtual VJDFAttributeMap getPartMapVector()
      {
         VElement vE = getChildElementVector(ElementName.PART, null, null, true, 0, false);

         int size = vE.Count;
         VJDFAttributeMap v = size == 0 ? null : new VJDFAttributeMap();
         for (int i = 0; i < size; i++)
         {
            JDFPart part = (JDFPart)vE[i];
            v.Add(part.getPartMap());
         }
         return v;
      }

      ///   
      ///	 <summary> * gets the part map
      ///	 *  </summary>
      ///	 * <returns> JDFAttributeMap, of the part element </returns>
      ///	 
      public virtual JDFAttributeMap getPartMap()
      {
         JDFPart p = (JDFPart)getElement(ElementName.PART, null, 0);
         if (p == null)
         {
            return null;
         }
         return p.getPartMap();
      }

      ///   
      ///	 <summary> * sets all parts to those defined in vParts
      ///	 *  </summary>
      ///	 * <param name="vPart"> vector of attribute maps for the parts </param>
      ///	 
      public virtual void setPartMapVector(VJDFAttributeMap vPart)
      {
         removeChildren(ElementName.PART, null, null);
         if (vPart == null)
         {
            return;
         }

         for (int i = 0; i < vPart.Count; i++)
         {
            KElement p = appendElement(ElementName.PART, null);
            p.setAttributes(vPart[i]);
         }
      }

      ///   
      ///	 <summary> * sets part to mPart
      ///	 *  </summary>
      ///	 * <param name="mPart"> attribute map for the part to set </param>
      ///	 
      public virtual void setPartMap(JDFAttributeMap mPart)
      {
         removeChildren(ElementName.PART, null, null);
         if ((mPart != null) && !mPart.IsEmpty())
         {
            KElement p = appendElement(ElementName.PART, null);
            p.setAttributes(mPart);
         }
      }

      ///   
      ///	 <summary> * removes the part defined in mPart
      ///	 *  </summary>
      ///	 * <param name="mPart"> attribute map for the part to remove </param>
      ///	 
      public virtual void removePartMap(JDFAttributeMap mPart)
      {
         VElement vE = getChildElementVector(ElementName.PART, null, null, true, 0, false);

         int size = vE.Count;
         for (int i = 0; i < size; i++)
         {
            KElement e_i = (vE[i]);
            JDFAttributeMap a_Map = e_i.getAttributeMap();

            if (a_Map.subMap(mPart))
            {
               vE.RemoveAt(i);
            }
         }
      }

      ///   
      ///	 <summary> * checks whether the part defined in mPart is included in <i>this</i>
      ///	 *  </summary>
      ///	 * <param name="mPart"> Attribute map to check </param>
      ///	 * <returns> true if <i>this</i> has a part containing mPart </returns>
      ///	 
      public virtual bool hasPartMap(JDFAttributeMap mPart)
      {
         VElement vE = getChildElementVector(ElementName.PART, null, null, true, 0, false);

         int size = vE.Count;
         for (int i = 0; i < size; i++)
         {
            KElement e_i = (vE[i]);
            JDFAttributeMap a_Map = e_i.getAttributeMap();

            if (a_Map.subMap(mPart))
            {
               return true;
            }
         }
         return false;
      }

      ///   
      ///	 <summary> * returns true if the enumeration level is either Complete or RecursiveComplete, i.e. if the parameter is required
      ///	 *  </summary>
      ///	 * <param name="level"> the level to check </param>
      ///	 * <returns> true if required </returns>
      ///	 * @deprecated use EnumValidationLevel.isRequired() 
      ///	 
      [Obsolete("use EnumValidationLevel.isRequired()")]
      public static bool requiredLevel(EnumValidationLevel level)
      {
         return EnumValidationLevel.isRequired(level);
      }

      ///   
      ///	 <summary> * GetHRefs - get inter-resource linked resource IDs
      ///	 *  </summary>
      ///	 * <param name="vDoneRefs"> </param>
      ///	 * <param name="bRecurse"> if true, recurse followed refs
      ///	 *  </param>
      ///	 * <returns> VString </returns>
      ///	 * @deprecated use getHRefs(VString vDoneRefs, boolean bRecurse, boolean bExpand)
      ///	 * @default GetHRefs(null, false); 
      ///	 
      [Obsolete("use getHRefs(VString vDoneRefs, boolean bRecurse, boolean bExpand)")]
      public virtual VString getHRefs(VString vDoneRefs, bool bRecurse)
      {
         return getHRefs(vDoneRefs, bRecurse, false);
      }

      ///   
      ///	 <summary> * GetHRefs - get inter-resource linked resource IDs
      ///	 *  </summary>
      ///	 * <param name="vDoneRefs"> (use null by default) </param>
      ///	 * <param name="bRecurse"> if true recurse followed refs </param>
      ///	 * <param name="bExpand"> if true expand partitioned resources
      ///	 *  </param>
      ///	 * <returns> VString - the vector of referenced resource IDs
      ///	 * 
      ///	 * @default GetHRefs(null, false); </returns>
      ///	 
      public virtual VString getHRefs(VString vDoneRefs, bool bRecurse, bool bExpand)
      {
         VString vDoneRefsLocal = vDoneRefs;

         if (vDoneRefsLocal == null)
         {
            vDoneRefsLocal = new VString();
         }

         SupportClass.HashSetSupport h = new SupportClass.HashSetSupport();

         if (bExpand && (this is JDFResource))
         {
            VElement vLeaves = ((JDFResource)this).getLeaves(true);
            int siz = vLeaves.Count;
            for (int i = 0; i < siz; i++)
            {
               vLeaves.item(i).fillHashSet(AttributeName.RREF, null, h);
            }
         }
         else
         {
            fillHashSet(AttributeName.RREF, null, h);
         }
         int iFirstPos = vDoneRefsLocal.Count; // get the previous size
         VString v2 = new VString();
         v2.addAll((string[])h.ToArray(typeof(string)));

         vDoneRefsLocal.appendUnique(v2); // get the new size
         if (bRecurse)
         {
            int iLastPos = vDoneRefsLocal.Count;

            // recurse only the new rrefs
            for (int i = iFirstPos; i < iLastPos; i++)
            {
               string s = vDoneRefsLocal[i];
               KElement e = getTarget(s, AttributeName.ID);
               if (e is JDFElement)
               {
                  vDoneRefsLocal = ((JDFElement)e).getHRefs(vDoneRefsLocal, true, bExpand);
               }
            }
         }

         return vDoneRefsLocal;
      }

      ///   
      ///	 <summary> * get inter-resource linked resource vector
      ///	 *  </summary>
      ///	 * <param name="bRecurse"> </param>
      ///	 * @deprecated use getvHRefRes(true,false); 
      ///	 * <returns> VElement </returns>
      ///	 
      [Obsolete("use getvHRefRes(true,false);")]
      public virtual VElement getvHRefRes(bool bRecurse)
      {
         return getvHRefRes(bRecurse, false);
      }

      ///   
      ///	 <summary> * get inter-resource linked resource vector
      ///	 *  </summary>
      ///	 * <param name="bRecurse"> if true, recurse followed links </param>
      ///	 * <param name="bExpand"> if true, expand partitioned resources and follow the refs from the leaves
      ///	 *  </param>
      ///	 * <returns> VElement - the inter-resource linked resource vector </returns>
      ///	 
      public virtual VElement getvHRefRes(bool bRecurse, bool bExpand)
      {
         VString sRefs = getHRefs(null, bRecurse, bExpand);
         VElement v = new VElement();

         for (int i = 0; i < sRefs.Count; i++)
         {
            KElement kEl = getTarget(sRefs[i], AttributeName.ID);
            if (kEl is JDFResource)
            {
               v.appendUnique(kEl);
            }
         }

         return v;
      }

      ///   
      ///	 <summary> * Append to attribute rRefs if it is not yet in the list
      ///	 *  </summary>
      ///	 * <param name="value"> the rRef token to append </param>
      ///	 * @deprecated rRefs was deprecated in JDF 1.2 
      ///	 
      [Obsolete("rRefs was deprecated in JDF 1.2")]
      public virtual void appendrRefs(string @value)
      {
         appendAttribute(AttributeName.RREFS, @value, null, JDFConstants.BLANK, true);
      }

      ///   
      ///	 <summary> * Remove value from attribute rRefs if it is in the list
      ///	 *  </summary>
      ///	 * <param name="value"> the rRef token to remove from the NMTOKENS list </param>
      ///	 * @deprecated rRefs was deprecated in JDF 1.2 
      ///	 
      [Obsolete("rRefs was deprecated in JDF 1.2")]
      public virtual int removeFromrRefs(string @value)
      {
         return removeFromAttribute(AttributeName.RREFS, @value, null, JDFConstants.BLANK, -1);
      }

      // dm /**
      // * Set attribute rRefs, i.e. combine the blank separed attribute list
      // * @deprecated rRefs was deprecated in JDF 1.2
      // */
      // @Deprecated
      // public void setrRefs(VString vStr)
      // {
      // setAttribute(
      // AttributeName.RREFS,
      // StringUtil.setvString(vStr,JDFConstants.BLANK,null,null),null);
      // }
      ///   
      ///	 <summary> * Get string attribute rRefs, i.e. split the blank separed attribute list
      ///	 *  </summary>
      ///	 * @deprecated rRefs was deprecated in JDF 1.2 
      ///	 
      [Obsolete("rRefs was deprecated in JDF 1.2")]
      public virtual VString getrRefs()
      {
         VString vStr = new VString();
         vStr.setAllStrings(getAttribute_KElement(AttributeName.RREFS, null, JDFConstants.EMPTYSTRING), JDFConstants.BLANK);

         return vStr;
      }

      ///   
      ///	 <summary> * Gets the root resource of the target returns a null JDFElement if it does not exist or the name mangling is
      ///	 * illegal
      ///	 *  </summary>
      ///	 * <param name="id"> the id of the linked root. If null, the id of <i>this</i> is used.
      ///	 *  </param>
      ///	 * <returns> JDFResource the resource root of the resource referenced by this resource link </returns>
      ///	 
      public virtual JDFResource getLinkRoot(string id)
      {
         JDFResource ret = null;

         string myid = (id == null) ? getAttribute(AttributeName.RREF, null, null) : id;
         if (myid == null)
         {
            return null;
         }

         bool bSearching = true;
         XMLDocUserData ud = getXMLDocUserData();
         if (ud != null) // grab target from the cache
         {
            KElement kOwner = ud.getTarget(myid);
            if (kOwner != null)
            {
               if (kOwner is JDFResource)
               {
                  ret = (JDFResource)kOwner;
                  if (!ret.isResourceRootRoot())
                  {
                     ret = null;
                  }
               }
            }

            if (ret != null) // we found something in the cache
            {
               bSearching = false;
               if (!validResourcePosition(ret))
               {
                  bSearching = true;
                  ret = null;
               }
            }
         }

         if (ret == null)
         {

            // start with the first jdf node parent of this so that nod is
            // initialized
            JDFNode nod = (JDFNode)getDeepParent(ElementName.JDF, 0);
            if (nod != null) // we are in a JDF, not in a JMF
            {
               while (bSearching)
               {
                  if (nod != null)
                  {
                     JDFResourcePool rp = nod.getResourcePool();
                     if (rp != null)
                     {
                        ret = rp.getResourceByID(myid);
                        bSearching = ret == null;
                     }

                     if (bSearching)
                     {
                        nod = nod.getParentJDF();
                        bSearching = nod != null;
                     }
                  }
               }
            }
            else
            // we may be in a JMF and have nothing in the cache
            {
               if (bSearching)
               {
                  KElement jmf = getDeepParent(ElementName.JMF, 0);
                  if (jmf != null)
                  {
                     ret = (JDFResource)jmf.getChildWithAttribute(null, AttributeName.ID, null, myid, 0, false);
                  }
               }
            }
         }
         return ret;
      }

      ///   
      ///	 <summary> * returns the official JDF version string
      ///	 *  </summary>
      ///	 * <returns> String: the inherited version information or "1.3" if no valid version info was found </returns>
      ///	 * @deprecated use getDefaultJDFVersion() 
      ///	 
      [Obsolete("use getDefaultJDFVersion()")]
      public string version()
      {
         string ver = getInheritedAttribute(AttributeName.VERSION, null, JDFConstants.EMPTYSTRING);
         if (JDFConstants.EMPTYSTRING.Equals(ver))
         {
            return JDFConstants.VERSION_1_3;
         }
         return JDFElement.EnumVersion.getEnum(ver).getName();
      }

      ///   
      ///	 <summary> * set Version to enumVer
      ///	 *  </summary>
      ///	 * <param name="enumVer"> the EnumVersion to set </param>
      ///	 
      public virtual void setVersion(EnumVersion enumVer)
      {
         setAttribute(AttributeName.VERSION, enumVer.getName(), null);
      }

      ///   
      ///	 <summary> * get EnumVersion attribute Version
      ///	 *  </summary>
      ///	 * <returns> EnumVersion - attribute value </returns>
      ///	 * @deprecated 060505 use getVersion(boolean); 
      ///	 
      [Obsolete("060505 use getVersion(boolean);")]
      public virtual EnumVersion getVersion()
      {
         return getVersion(true);
      }

      ///   
      ///	 <summary> * get the version of this element
      ///	 *  </summary>
      ///	 * <param name="bInherit"> if true, check ancestor nodes </param>
      ///	 * <returns> the version corresponding to this element </returns>
      ///	 
      public virtual EnumVersion getVersion(bool bInherit)
      {
         return EnumVersion.getEnum(bInherit ? getInheritedAttribute(AttributeName.VERSION, null, null) : getAttribute(AttributeName.VERSION, null, null));
      }

      ///   
      ///	 <summary> * get attribute MaxVersion, defaults to version if not set
      ///	 *  </summary>
      ///	 * <param name="bInherit"> if true recurse through ancestors when searching </param>
      ///	 * <returns> EnumVersion - attribute value
      ///	 * 
      ///	 *         default - getMaxVersion(false) </returns>
      ///	 
      public virtual EnumVersion getMaxVersion(bool bInherit)
      {
         string version = (bInherit) ? getInheritedAttribute(AttributeName.MAXVERSION, null, null) : getAttribute(AttributeName.MAXVERSION, null, null);

         if (version == null)
            return getVersion(bInherit);

         return EnumVersion.getEnum(version);
      }

      ///   
      ///	 <summary> * Enumeration strings for Version
      ///	 * 
      ///	 * NOTE: If not specified the version defaults to Version 1.3 </summary>
      ///	 
      public sealed class EnumVersion : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         ///      
         ///		 * <seealso cref= java.lang.Object#toString() </seealso>
         ///		 * @deprecated just for compiling PrintReady, to be removed afterwards 
         ///		 
         [Obsolete("just for compiling PrintReady, to be removed afterwards")]
         public override string ToString()
         {
            return getName();
         }

         private EnumVersion(string name)
            : base(name, m_startValue++)
         {
         }

         ///      
         ///		 <summary> * casts a String into a corresponding EnumVersion
         ///		 *  </summary>
         ///		 * <param name="enumName"> the name of the EnumVersion </param>
         ///		 * <returns> the corresponding EnumVersion </returns>
         ///		 
         public static EnumVersion getEnum(string enumName)
         {
            EnumVersion myVersion = (EnumVersion)getEnum(typeof(EnumVersion), enumName);
            if (myVersion == null)
            {
               myVersion = EnumVersion.Version_1_3;
            }
            return myVersion;
         }

         ///      
         ///		 <summary> * casts a EnumVersion into its corresponding String
         ///		 *  </summary>
         ///		 * <param name="enumValue"> the EnumVersion to cast </param>
         ///		 * <returns> the corresponding String </returns>
         ///		 
         public static EnumVersion getEnum(int enumValue)
         {
            return (EnumVersion)getEnum(typeof(EnumVersion), enumValue);
         }

         ///      
         ///		 * <returns> Map </returns>
         ///		 
         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumVersion));
         }

         ///      
         ///		 * <returns> List </returns>
         ///		 
         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumVersion));
         }

         ///      
         ///		 <summary> * gets the EnumVersion iterator
         ///		 *  </summary>
         ///		 * <returns> Iterator </returns>
         ///		 
         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumVersion));
         }

         ///      
         ///		 <summary> * returns true if this is greater than other
         ///		 *  </summary>
         ///		 * <returns> boolean true if this>other </returns>
         ///		 
         public bool isGreater(EnumVersion other)
         {
            if (other == null)
               return true;
            return getValue() > other.getValue();
         }

         ///      
         ///		 <summary> * @ deprecated EnumVersion.Unknown - don't use EnumVersion.Unknown, it can't be deprecated because of bit
         ///		 * operations in eg. AtrInfo.getFirstVersion() </summary>
         ///		 
         public static readonly EnumVersion Unknown = new EnumVersion(JDFConstants.UNKNOWN);

         public static readonly EnumVersion Version_1_0 = new EnumVersion(JDFConstants.VERSION_1_0);
         public static readonly EnumVersion Version_1_1 = new EnumVersion(JDFConstants.VERSION_1_1);
         public static readonly EnumVersion Version_1_2 = new EnumVersion(JDFConstants.VERSION_1_2);
         public static readonly EnumVersion Version_1_3 = new EnumVersion(JDFConstants.VERSION_1_3);
         public static readonly EnumVersion Version_1_4 = new EnumVersion(JDFConstants.VERSION_1_4);
         public static readonly EnumVersion Version_1_5 = new EnumVersion(JDFConstants.VERSION_1_5);
         public static readonly EnumVersion Version_1_6 = new EnumVersion(JDFConstants.VERSION_1_6);
         public static readonly EnumVersion Version_1_7 = new EnumVersion(JDFConstants.VERSION_1_7);
         public static readonly EnumVersion Version_1_8 = new EnumVersion(JDFConstants.VERSION_1_8);
         public static readonly EnumVersion Version_1_9 = new EnumVersion(JDFConstants.VERSION_1_9);

      }

      ///   
      ///	 * <param name="enumName"> </param>
      ///	 * <returns> EnumVersion </returns>
      ///	 * @deprecated use EnumVersion.getEnum 
      ///	 
      [Obsolete("use EnumVersion.getEnum")]
      public static EnumVersion stringToVersion(string enumName)
      {
         return EnumVersion.getEnum(enumName);
      }

      ///   
      ///	 <summary> * Method getChildElements.
      ///	 *  </summary>
      ///	 * <returns> JDFElement[] </returns>
      ///	 * @deprecated use KElement.getChildElementArray()
      ///	 *             not typesafe in case of elements in foreign namespaces note that this method previously returned
      ///	 *             JDFElement[] 
      ///	 
      [Obsolete("use KElement.getChildElementArray()")]
      public virtual KElement[] getChildElements()
      {
         return getChildElementArray();
      }

      ///   
      ///	 <summary> * Method getChildrenCount.
      ///	 *  </summary>
      ///	 * <returns> int </returns>
      ///	 * @deprecated 060727 use numChildNodes(Node.ELEMENT_NODE); 
      ///	 
      [Obsolete("060727 use numChildNodes(Node.ELEMENT_NODE);")]
      public virtual int getChildElementCount()
      {
         return numChildNodes(XmlNodeType.Element);
      }

      ///   
      ///	 <summary> * Method getChildElement
      ///	 *  </summary>
      ///	 * <param name="n"> Element index n (1 based) </param>
      ///	 * <returns> JDFElement
      ///	 *  </returns>
      ///	 * @deprecated use getElement(null, null ,n) 
      ///	 
      [Obsolete("use getElement(null, null ,n)")]
      public virtual JDFElement getChildElement(int n)
      {
         int nLocal = n;

         JDFElement eReturn = null;

         XmlNodeList children = ChildNodes;

         int cnt = children.Count;

         for (int i = 0; i < cnt && eReturn == null; i++)
         {
            XmlNode node = children.Item(i);

            if (node.NodeType == XmlNodeType.Element)
            {
               nLocal--;

               if (nLocal == 0)
               {
                  eReturn = (JDFElement)node;
               }
            }
         }

         return eReturn;
      }

      ///   
      ///	 <summary> * get unknown elements for a specific pool
      ///	 *  </summary>
      ///	 * <param name="poolType"> the PoolType to look for </param>
      ///	 * <param name="nMax"> max. number of elements to retrieve </param>
      ///	 * <returns> VString of unknown pool elements
      ///	 * @default getUnknownPoolElements(EnumPoolType poolType, 99999, null) </returns>
      ///	 
      public virtual VString getUnknownPoolElements(EnumPoolType poolType, int nMax)
      {
         VElement v = getChildElementVector(null, null, null, true, 0, false);
         VString vElem = new VString();
         int n = 0;
         int siz = v.Count;
         VString knownElements_ = knownElements();
         VString badVersions = getTheElementInfo().prereleaseElements();
         badVersions.appendUnique(getTheElementInfo().deprecatedElements());

         for (int i = 0; i < siz; i++)
         {
            KElement e = v[i];

            // check for known prerelease or deprecated elements
            if (badVersions.Contains(e.LocalName))
            {
               vElem.Add(e.LocalName);
               if (++n > nMax)
               {
                  return vElem;
               }
               continue;
            }

            if (e is JDFComment)
            {
               continue;
            }

            if (((EnumPoolType.ResourcePool.Equals(poolType)) || (EnumPoolType.ProductionIntent.Equals(poolType)) || (EnumPoolType.PipeParams.Equals(poolType))) && e is JDFResource)
            {
               continue;
            }

            if (((EnumPoolType.ProductionIntent.Equals(poolType)) || (EnumPoolType.RefElement.Equals(poolType)) || (EnumPoolType.PipeParams.Equals(poolType))) && e is JDFRefElement)
            {
               continue;
            }

            if (((EnumPoolType.ResourceLinkPool.Equals(poolType)) || (EnumPoolType.PipeParams.Equals(poolType))) && e is JDFResourceLink)
            {
               continue;
            }

            if (EnumPoolType.AuditPool.Equals(poolType) && e is JDFAudit)
            {
               continue;
            }

            if (EnumPoolType.AncestorPool.Equals(poolType) && e is JDFAncestor)
            {
               continue;
            }

            if (knownElements_.Contains(e.LocalName))
            {
               continue;
            }
            if (e is JDFRefElement)
            {
               string refName = ((JDFRefElement)e).getRefLocalName();
               if (knownElements_.Contains(refName))
               {
                  continue;
               }
            }

            vElem.Add(e.LocalName);
            if (++n > nMax)
            {
               return vElem;
            }
         }

         return vElem;
      }

      ///   
      ///	 <summary> * Set attribute SettingsPolicy
      ///	 *  </summary>
      ///	 * <param name="value"> the SettingsPolicy to set </param>
      ///	 
      public virtual void setSettingsPolicy(EnumSettingsPolicy @value)
      {
         setAttribute(AttributeName.SETTINGSPOLICY, @value.getName(), null);
      }

      ///   
      ///	 <summary> * Typesafe enumerated attribute SettingsPolicy
      ///	 *  </summary>
      ///	 * <param name="bInherit"> recurse through ancestors when searching </param>
      ///	 
      public virtual EnumSettingsPolicy getSettingsPolicy(bool bInherit)
      {
         string s = null;
         if (bInherit)
         {
            s = getInheritedAttribute(AttributeName.SETTINGSPOLICY, null, null);
         }
         else
         {
            s = getAttribute(AttributeName.SETTINGSPOLICY, null, null);
         }
         return EnumSettingsPolicy.getEnum(s);
      }

      ///   
      ///	 <summary> * Sets attribute BestEffortExceptions with the vector of values
      ///	 *  </summary>
      ///	 * <param name="value"> vector of BestEffortExceptions tokens </param>
      ///	 
      public virtual void setBestEffortExceptions(VString @value)
      {
         setAttribute(AttributeName.BESTEFFORTEXCEPTIONS, @value, null);
      }

      ///   
      ///	 <summary> * Append a token to attribute BestEffortExceptions
      ///	 *  </summary>
      ///	 * <param name="value"> the new BestEffortExceptions token </param>
      ///	 
      public virtual void appendBestEffortExceptions(string @value)
      {
         appendAttribute(AttributeName.BESTEFFORTEXCEPTIONS, @value, null, JDFConstants.BLANK, true);
      }

      ///   
      ///	 <summary> * Remove a token from attribute BestEffortExceptions
      ///	 *  </summary>
      ///	 * <param name="value"> the BestEffortExceptions token to remove </param>
      ///	 
      public virtual void removeFromBestEffortExceptions(string @value)
      {
         removeFromAttribute(AttributeName.BESTEFFORTEXCEPTIONS, @value, null, JDFConstants.BLANK, -1);
      }

      ///   
      ///	 <summary> * Gets the value of attribute BestEffortExceptions
      ///	 *  </summary>
      ///	 * <returns> the attribute value </returns>
      ///	 
      public virtual string getBestEffortExceptions()
      {
         return getAttribute(AttributeName.BESTEFFORTEXCEPTIONS, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * Sets attribute MustHonorExceptions with the vector of values
      ///	 *  </summary>
      ///	 * <param name="value"> vector of MustHonorExceptions tokens </param>
      ///	 
      public virtual void setMustHonorExceptions(VString @value)
      {
         setAttribute(AttributeName.MUSTHONOREXCEPTIONS, @value, null);
      }

      ///   
      ///	 <summary> * Append a token to attribute MustHonorExceptions
      ///	 *  </summary>
      ///	 * <param name="value"> the new of MustHonorExceptions token </param>
      ///	 
      public virtual void appendMustHonorExceptions(string @value)
      {
         appendAttribute(AttributeName.MUSTHONOREXCEPTIONS, @value, null, JDFConstants.BLANK, true);
      }

      ///   
      ///	 <summary> * Remove a token from attribute MustHonorExceptions
      ///	 *  </summary>
      ///	 * <param name="value"> the new of MustHonorExceptions token </param>
      ///	 
      public virtual void removeFromMustHonorExceptions(string @value)
      {
         removeFromAttribute(AttributeName.MUSTHONOREXCEPTIONS, @value, null, JDFConstants.BLANK, -1);
      }

      ///   
      ///	 <summary> * gets the value of attribute MustHonorExceptions
      ///	 *  </summary>
      ///	 * <returns> the attribute value </returns>
      ///	 
      public virtual string getMustHonorExceptions()
      {
         return getAttribute(AttributeName.MUSTHONOREXCEPTIONS, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * Sets attribute OperatorInterventionExceptions with the vector of values
      ///	 *  </summary>
      ///	 * <param name="value"> the vector of OperatorInterventionExceptions tokens </param>
      ///	 
      public virtual void setOperatorInterventionExceptions(VString @value)
      {
         setAttribute(AttributeName.OPERATORINTERVENTIONEXCEPTIONS, @value, null);
      }

      ///   
      ///	 <summary> * Append a token to attribute OperatorInterventionExceptions
      ///	 *  </summary>
      ///	 * <param name="value"> the new of OperatorInterventionExceptions token </param>
      ///	 
      public virtual void appendOperatorInterventionExceptions(string @value)
      {
         appendAttribute(AttributeName.OPERATORINTERVENTIONEXCEPTIONS, @value, null, JDFConstants.BLANK, true);
      }

      ///   
      ///	 <summary> * Remove a token from attribute OperatorInterventionExceptions
      ///	 *  </summary>
      ///	 * <param name="value"> the new of OperatorInterventionExceptions token </param>
      ///	 
      public virtual void removeFromOperatorInterventionExceptions(string @value)
      {
         removeFromAttribute(AttributeName.OPERATORINTERVENTIONEXCEPTIONS, @value, null, JDFConstants.BLANK, -1);
      }

      ///   
      ///	 <summary> * gets the value of attribute OperatorInterventionExceptions
      ///	 *  </summary>
      ///	 * <returns> the attribute value </returns>
      ///	 
      public virtual string getOperatorInterventionExceptions()
      {
         return getAttribute(AttributeName.OPERATORINTERVENTIONEXCEPTIONS, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * Set attribute DescriptiveName
      ///	 *  </summary>
      ///	 * <param name="value"> value to set the attribute to </param>
      ///	 
      public virtual void setDescriptiveName(string @value)
      {
         setAttribute(AttributeName.DESCRIPTIVENAME, @value, null);
      }

      ///   
      ///	 <summary> * Get string attribute DescriptiveName
      ///	 *  </summary>
      ///	 * <returns> the attribute value </returns>
      ///	 
      public virtual string getDescriptiveName()
      {
         return getAttribute(AttributeName.DESCRIPTIVENAME, null, JDFConstants.EMPTYSTRING);
      }


      //   
      //	 * // Element Getter / Setter
      //	 

      ///   
      ///	 <summary> * Appends element Comment to the end of 'this'
      ///	 *  </summary>
      ///	 * <returns> the newly created JDFComment </returns>
      ///	 
      public virtual JDFComment appendComment()
      {
         return (JDFComment)appendElement(ElementName.COMMENT, null);
      }

      ///   
      ///	 <summary> * Gets the iSkip-th element Comment. If doesn't exist, creates it
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> the newly created JDFComment </returns>
      ///	 
      public virtual JDFComment getCreateComment(int iSkip)
      {
         return (JDFComment)getCreateElement_KElement(ElementName.COMMENT, null, iSkip);
      }

      ///   
      ///	 <summary> * Gets the iSkip-th element Comment
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip </param>
      ///	 * <returns> JDFComment - the matching element
      ///	 * 
      ///	 * @default getComment(0) </returns>
      ///	 
      public virtual JDFComment getComment(int iSkip)
      {
         return (JDFComment)getElement(ElementName.COMMENT, null, iSkip);
      }

      ///   
      ///	 <summary> * Gets the Comment with a give @Name
      ///	 *  </summary>
      ///	 * <param name="_name"> Comment/@Name </param>
      ///	 * <param name="index"> number of elements to skip </param>
      ///	 * <returns> JDFComment - the matching element
      ///	 *  </returns>
      ///	 
      public virtual JDFComment getComment(string _name, int index)
      {
         return (JDFComment)getChildWithAttribute(ElementName.COMMENT, AttributeName.NAME, null, _name, index, true);
      }


      ///   
      ///	 <summary> * Gets a child with matching attributes, also follows refelements
      ///	 *  </summary>
      ///	 * <param name="nodeName"> name of the child node to search for </param>
      ///	 * <param name="attName"> attribute name to search for </param>
      ///	 * <param name="nameSpaceURI"> namespace to search for </param>
      ///	 * <param name="attVal"> a special value to search for </param>
      ///	 * <param name="index"> if more then one child meets the condition, you can specify the one to return via an index </param>
      ///	 * <param name="bDirect"> if true, look only in direct children, else search through all children, grandchildren etc. </param>
      ///	 * <param name="dataType"> dataType to be matched
      ///	 *  </param>
      ///	 * <returns> JDFElement: the element which matches the above conditions
      ///	 * 
      ///	 * @default getChildWithMatchingAttribute(nodeName, attName, null, null, 0, true, EnumAttributeType.Any); </returns>
      ///	 
      public virtual JDFElement getChildWithMatchingAttribute(string nodeName, string attName, string nameSpaceURI, string attVal, int index, bool bDirect, AttributeInfo.EnumAttributeType dataType)
      {
         VElement v = getChildrenByTagName(nodeName, nameSpaceURI, null, bDirect, true, 0);
         int siz = v.Count;
         int n = 0;
         for (int i = 0; i < siz; i++)
         {
            JDFElement e = (JDFElement)v[i];
            if (e.includesMatchingAttribute(attName, attVal, dataType))
            {
               if (n++ == index)
               {
                  return e;
               }
            }
         }
         return null;
      }

      ///   
      ///	 <summary> * test whether the attributes described by attName and attVal exist<br< also checking ranges and NMTOKENS etc.
      ///	 *  </summary>
      ///	 * <param name="attName"> the name of the attribute to look for </param>
      ///	 * <param name="attVal"> the value of the attribute to look for; a values of "*" is treated as true if the attribute exists,
      ///	 *            regardless of its value </param>
      ///	 * <param name="dataType"> the dataType to be matched
      ///	 * @tbd allow for regular expressions in attVal </param>
      ///	 * <returns> true, if such attribute exists
      ///	 * 
      ///	 * @default includesMatchingAttribute(String attName, null, JDFElement.EnumAttributeType.Any) </returns>
      ///	 
      public virtual bool includesMatchingAttribute(string attName, string attVal, AttributeInfo.EnumAttributeType dataType)
      {
         string thisVal = getAttribute(attName, null, null);
         if (thisVal == null)
         {
            return false;
         }
         if (isWildCard(attVal))
         {
            return true;
         }
         if (attVal.Equals(thisVal))
            return true;
         return StringUtil.matchesAttribute(attVal, thisVal, dataType);
      }

      ///   
      ///	 <summary> *Sets attribute Status
      ///	 *  </summary>
      ///	 * <param name="s"> the status to set the attribute to </param>
      ///	 
      public virtual void setStatus(EnumNodeStatus s)
      {
         setAttribute(AttributeName.STATUS, s.getName(), null);
      }

      ///   
      ///	 <summary> * gets the value of attribute Status
      ///	 *  </summary>
      ///	 * <returns> EnumNodeStatus </returns>
      ///	 
      public virtual EnumNodeStatus getStatus()
      {
         return EnumNodeStatus.getEnum(getAttribute(AttributeName.STATUS, null, null));
      }

      ///   
      ///	 <summary> * Gets inter-resource linked resource IDs
      ///	 *  </summary>
      ///	 * <param name="vDoneRefs"> (use null as default value) </param>
      ///	 * <param name="bRecurse"> if true, return recursively linked IDs as well </param>
      ///	 * <returns> the HashSet of all refElements
      ///	 * 
      ///	 * @default getAllRefs(null, false) </returns>
      ///	 
      public virtual SupportClass.HashSetSupport getAllRefs(SupportClass.HashSetSupport vDoneRefs, bool bRecurse)
      {
         SupportClass.HashSetSupport vDoneRefsLocal = vDoneRefs;

         if (vDoneRefsLocal.Contains(this))
         {
            return vDoneRefsLocal;
         }

         VElement v = getChildElementVector_KElement(null, null, null, true, 0); // grabemall

         int size = v.Count;
         for (int i = 0; i < size; i++)
         {
            KElement e = v[i];
            if (e is JDFRefElement)
            {
               JDFRefElement @ref = (JDFRefElement)e;
               if (!vDoneRefsLocal.Contains(@ref))
               {
                  vDoneRefsLocal.Add(@ref);
                  if (bRecurse)
                  {
                     JDFResource r = @ref.getTarget();
                     if (r != null)
                     {
                        vDoneRefsLocal = r.getAllRefs(vDoneRefsLocal, bRecurse);
                     }
                  }
               }
            }
            else if (e is JDFElement)
            { // recurse tree
               vDoneRefsLocal = ((JDFElement)e).getAllRefs(vDoneRefsLocal, bRecurse);
            }
         }
         return vDoneRefsLocal;
      }

      ///   
      ///	 <summary> * gets attribute ID
      ///	 *  </summary>
      ///	 * <returns> the attribute value
      ///	 * @tbd use getID of the subclasses that may have id </returns>
      ///	 
      public virtual string getID()
      {
         return getAttribute(AttributeName.ID, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * check whether this matches a simple xpath - note that references are NOT followed in case a node name is replaced
      ///	 * with a "*"
      ///	 *  </summary>
      ///	 * <param name="path"> xpath to match </param>
      ///	 * <returns> boolean true, if this matches the given xpath </returns>
      ///	 
      public override bool matchesPath(string path, bool bFollowRefs)
      {
         if (path == null)
         {
            return true;
         }
         VString v = new VString(StringUtil.tokenize(path, "/", false));
         KElement e = this;
         KElement eLast = null;
         for (int i = v.Count - 1; i >= 0; i--)
         {
            if (e == null)
            {
               return false;
            }
            string locName = e.LocalName;
            if (!e.matchesPathName(v.stringAt(i)))
            {
               if (bFollowRefs && eLast != null && locName.Equals(ElementName.RESOURCEPOOL))
               { // now look for a refelement that points at this
                  if (eLast is JDFResource)
                  {
                     JDFResource r = (JDFResource)eLast;
                     VElement vRefs = r.getLinks(r.getRefString(), null);
                     if (vRefs != null)
                     {
                        string subPath = v.stringAt(0);
                        for (int k = 1; k <= i + 1; k++)
                        {
                           subPath += "/" + v.stringAt(k);
                        }
                        subPath += "Ref";
                        for (int j = 0; j < vRefs.Count; j++)
                        {
                           KElement eRef = vRefs.item(j);
                           bool b = eRef.matchesPath(subPath, bFollowRefs);
                           if (b)
                           {
                              return true;
                           }
                        }
                     }

                  }
               }
               // xpath is xpath -lets try not to be too smart implicitly
               // if(eLast!=null)
               // {
               // if(eLast instanceof JDFResource)
               // {
               // if(locName.equals(eLast.LocalName)){
               // e=e.getParentNode_KElement();
               // i++; // undo i--
               // continue;
               // }
               // }
               // }
               return false;
            }
            eLast = e;
            e = e.getParentNode_KElement();
         }
         if (path.StartsWith("/"))
         {
            return e == null || path.StartsWith("//"); // must be root
         }
         return true; // any location
      }

      ///   
      ///	 * <returns> the bFixVersionIDFix if true then invalid, i.e. numeric ID, IDREF and IDREFS are prefixed with an '_'
      ///	 *         when calling fixVersion </returns>
      ///	 
      public static bool isFixVersionIDFix()
      {
         return bFixVersionIDFix;
      }

      ///   
      ///	 * <param name="fixVersionIDFix"> the bFixVersionIDFix to set if true then invalid, i.e. numeric ID, IDREF and IDREFS are
      ///	 *            prefixed with an '_' when calling fixVersion </param>
      ///	 
      public static void setFixVersionIDFix(bool fixVersionIDFix)
      {
         bFixVersionIDFix = fixVersionIDFix;
      }

      public static string getValueForNewAttribute(KElement e, string attName)
      {

         // return the default if it exists
         JDFAttributeMap map = e == null ? null : e.getDefaultAttributeMap();
         if (map != null && map.ContainsKey(attName))
            return map.get(attName);

         if (attName.Equals("ID"))
            return "ID" + JDFElement.uniqueID(0);

         if (attName.Equals("JobID"))
            return "J" + JDFElement.uniqueID(0);

         if (attName.Equals("JobPartID") && (e is JDFElement))
         {
            return ((JDFElement)e).generateDotID("JobPartID", null);
         }

         if (attName.Equals("Status") && (e is JDFNode))
         {
            return "Waiting";
         }

         if (attName.Equals("Status") && (e is JDFResource))
         {
            return "Unavailable";
         }

         if (attName.Equals("Type") && (e is JDFNode))
            return "Product";

         if (attName.Equals("Type") && (e is JDFMessage))
            return "Status";

         if (attName.Equals("TimeStamp"))
            return new JDFDate().DateTimeISO;

         if (attName.Equals("ComponentType"))
            return "PartialProduct";

         if (attName.Equals("PreviewType"))
            return "Separation";

         if (e != null)
         {
            EnumAttributeType attyp = e.getAtrType(attName);
            if (attyp != null)
            {
               if (EnumAttributeType.boolean_.Equals(attyp))
                  return "true";

               if (EnumAttributeType.CMYKColor.Equals(attyp))
                  return "0 0 0 1";

               if (EnumAttributeType.RGBColor.Equals(attyp))
                  return "1 1 1";

               if (EnumAttributeType.dateTime.Equals(attyp) || EnumAttributeType.DateTimeRange.Equals(attyp) || EnumAttributeType.DateTimeRangeList.Equals(attyp))
                  return new JDFDate().DateTimeISO;

               if (EnumAttributeType.double_.Equals(attyp))
                  return "0.0";

               if (EnumAttributeType.duration.Equals(attyp) || EnumAttributeType.DurationRange.Equals(attyp) || EnumAttributeType.DurationRangeList.Equals(attyp))
                  return "PT1H";

               // TODO evaluate durations
               // if(EnumAttributeType.enumeration.equals(attyp) ||
               // EnumAttributeType.enumerations.equals(attyp))
               // return "";
               if (EnumAttributeType.integer.Equals(attyp) || EnumAttributeType.IntegerRange.Equals(attyp) || EnumAttributeType.IntegerRangeList.Equals(attyp) || EnumAttributeType.IntegerList.Equals(attyp))
                  return "0";

               if (EnumAttributeType.JDFJMFVersion.Equals(attyp))
                  return "1.3";

               if (EnumAttributeType.matrix.Equals(attyp))
                  return "1 0 0 1 0 0";

               if (EnumAttributeType.XYPair.Equals(attyp) || EnumAttributeType.XYPairRange.Equals(attyp) || EnumAttributeType.XYPairRangeList.Equals(attyp))
                  return "0 0";
            }
         }

         return "New Value";
      }

      ///   
      ///	 <summary> * returns the jdf doc referenced by url
      ///	 *  </summary>
      ///	 * <returns> the document </returns>
      ///	 
      public virtual JDFDoc getURLDoc()
      {
         string url = getAttribute(AttributeName.URL, null, JDFConstants.EMPTYSTRING);
         if (isWildCard(url))
            return null;
         Attachment bodyPart = getOwnerDocument_KElement().getBodyPart();
         Stream @is = UrlUtil.getURLInputStream(url, bodyPart);
         if (@is == null)
            return null;
         JDFParser p = new JDFParser();
         return p.parseStream(@is);
      }
      /// <summary>
      /// Override to return a proper JDFAttributeMap.
      /// </summary>
      /// <returns>A JDFAttributeMap.</returns>
      protected override IDictionary<string, string> CreateAttributeMap()
      {
         return new JDFAttributeMap();
      }
   }
}
