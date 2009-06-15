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
 * 04022005 VF initial version
 */

namespace org.cip4.jdflib.core
{
   using System;
   using System.Collections;
   using System.Collections.Generic;


   using EnumUtils = org.apache.commons.lang.enums.EnumUtils;
   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;
   using EnumVersion = org.cip4.jdflib.core.JDFElement.EnumVersion;
   using EnumValidationLevel = org.cip4.jdflib.core.KElement.EnumValidationLevel;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using JDFCMYKColor = org.cip4.jdflib.datatypes.JDFCMYKColor;
   using JDFDateTimeRangeList = org.cip4.jdflib.datatypes.JDFDateTimeRangeList;
   using JDFDurationRangeList = org.cip4.jdflib.datatypes.JDFDurationRangeList;
   using JDFIntegerList = org.cip4.jdflib.datatypes.JDFIntegerList;
   using JDFIntegerRange = org.cip4.jdflib.datatypes.JDFIntegerRange;
   using JDFIntegerRangeList = org.cip4.jdflib.datatypes.JDFIntegerRangeList;
   using JDFLabColor = org.cip4.jdflib.datatypes.JDFLabColor;
   using JDFMatrix = org.cip4.jdflib.datatypes.JDFMatrix;
   using JDFNumberList = org.cip4.jdflib.datatypes.JDFNumberList;
   using JDFNumberRange = org.cip4.jdflib.datatypes.JDFNumberRange;
   using JDFNumberRangeList = org.cip4.jdflib.datatypes.JDFNumberRangeList;
   using JDFRGBColor = org.cip4.jdflib.datatypes.JDFRGBColor;
   using JDFRectangle = org.cip4.jdflib.datatypes.JDFRectangle;
   using JDFRectangleRangeList = org.cip4.jdflib.datatypes.JDFRectangleRangeList;
   using JDFShape = org.cip4.jdflib.datatypes.JDFShape;
   using JDFShapeRangeList = org.cip4.jdflib.datatypes.JDFShapeRangeList;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFXYPairRange = org.cip4.jdflib.datatypes.JDFXYPairRange;
   using JDFXYPairRangeList = org.cip4.jdflib.datatypes.JDFXYPairRangeList;
   using JDFDate = org.cip4.jdflib.util.JDFDate;
   using JDFDuration = org.cip4.jdflib.util.JDFDuration;
   using StringUtil = org.cip4.jdflib.util.StringUtil;
   using UrlUtil = org.cip4.jdflib.util.UrlUtil;

   ///
   /// <summary> * The maintainer of version-specific attribute information: - attribute type (for current version only) - validity per
   /// * version </summary>
   /// 
   public class AttributeInfo
   {

      internal Hashtable attribInfoTable = new Hashtable();
      private EnumVersion version = null;

      ///   
      ///	 <summary> * Constructor
      ///	 *  </summary>
      ///	 * <param name="AttributeInfo"> attrInfo_super: corresponding attrib info of super; if null: start from scratch, otherwise
      ///	 *            initialize from other AttributeInfo </param>
      ///	 * <param name="AtrInfoTable"> [] attrInfo_own: table with element-specific attribute info </param>
      ///	 
      protected internal AttributeInfo(AtrInfoTable[] attrInfo_own)
      {
         // fill table with the attributes specific to this element type (if any)
         updateReplace(attrInfo_own);
         // now all schema-based knowledge should be in the attribute info table
      }

      ///   
      ///	 <summary> * Constructor
      ///	 *  </summary>
      ///	 * <param name="AttributeInfo"> attrInfo_super: corresponding attrib info of super; if null: start from scratch, otherwise
      ///	 *            initialize from other AttributeInfo </param>
      ///	 * <param name="AtrInfoTable"> [] attrInfo_own: table with element-specific attribute info
      ///	 * @deprecated </param>
      ///	 
      [Obsolete]
      public AttributeInfo(AttributeInfo attrInfo_super, AtrInfoTable[] attrInfo_own)
      {
         // use AttributeInfo of super as a starting point
         if (attrInfo_super != null)
         {
            attribInfoTable = new Hashtable(attrInfo_super.attribInfoTable);
            version = attrInfo_super.version;
         }

         // fill table with the attributes specific to this element type (if any)
         updateReplace(attrInfo_own);

         // now all schema-based knowledge should be in the attribute info table
      }

      ///   
      ///	 <summary> * Updater
      ///	 *  </summary>
      ///	 * <param name="AtrInfoTable"> [] attrInfo_update: table with element-specific attribute info </param>
      ///	 
      public virtual AttributeInfo updateAdd(AtrInfoTable attrInfo_update)
      {
         if (attrInfo_update != null)
         {
            if (!attribInfoTable.ContainsKey(attrInfo_update.getAttributeName()))
            {
               attribInfoTable.Add(attrInfo_update.getAttributeName(), attrInfo_update.getAtrInfo());
            }
            else
            {
               // complain about duplicate attribute name
            }
         }
         return this;
      }

      ///   
      ///	 <summary> * Updater
      ///	 *  </summary>
      ///	 * <param name="AtrInfoTable"> [] attrInfo_update: table with element-specific attribute info </param>
      ///	 
      public virtual AttributeInfo updateAdd(AtrInfoTable[] attrInfo_update)
      {
         if (attrInfo_update != null)
         {
            for (int i = 0; i < attrInfo_update.Length; i++)
            {
               if (!attribInfoTable.ContainsKey(attrInfo_update[i].getAttributeName()))
               {
                  attribInfoTable.Add(attrInfo_update[i].getAttributeName(), attrInfo_update[i].getAtrInfo());
               }
               else
               {
                  // complain about duplicate attribute name
               }
            }
         }
         return this;
      }

      ///   
      ///	 <summary> * Updater
      ///	 *  </summary>
      ///	 * <param name="AtrInfoTable"> [] attrInfo_update: table with element-specific attribute info </param>
      ///	 
      public virtual AttributeInfo updateRemove(AtrInfoTable attrInfo_update)
      {
         if (attrInfo_update != null)
         {
            if (attribInfoTable.ContainsKey(attrInfo_update.getAttributeName()))
            {
               attribInfoTable.Remove(attrInfo_update.getAttributeName());
            }
         }
         return this;
      }

      ///   
      ///	 <summary> * Updater
      ///	 *  </summary>
      ///	 * <param name="AtrInfoTable"> [] attrInfo_update: table with element-specific attribute info to remove from attribInfoTable </param>
      ///	 
      public virtual AttributeInfo updateRemove(AtrInfoTable[] attrInfo_update)
      {
         if (attrInfo_update != null)
         {
            for (int i = 0; i < attrInfo_update.Length; i++)
            {
               if (attribInfoTable.ContainsKey(attrInfo_update[i].getAttributeName()))
               {
                  attribInfoTable.Remove(attrInfo_update[i].getAttributeName());
               }
            }
         }
         return this;
      }

      public virtual AttributeInfo updateReplace(AtrInfoTable attrInfo_update)
      {
         if (attrInfo_update != null)
         {
            // if the table already contains this key, remove it first
            if (attribInfoTable.ContainsKey(attrInfo_update.getAttributeName()))
               attribInfoTable.Remove(attrInfo_update.getAttributeName());

            attribInfoTable.Add(attrInfo_update.getAttributeName(), attrInfo_update.getAtrInfo());
         }
         return this;
      }

      public virtual AttributeInfo updateReplace(AtrInfoTable[] attrInfo_update)
      {
         if (attrInfo_update != null)
         {
            for (int i = 0; i < attrInfo_update.Length; i++)
            {
               AtrInfoTable attrInfoTable = attrInfo_update[i];

               // if the table already contains this key, remove it first
               if (attribInfoTable.ContainsKey(attrInfoTable.getAttributeName()))
                  attribInfoTable.Remove(attrInfoTable.getAttributeName());

               attribInfoTable.Add(attrInfoTable.getAttributeName(), attrInfoTable.getAtrInfo());
            }
         }
         return this;
      }

      ///   
      ///	 <summary> * Returns a list of attributes matching the requested validity for the specified JDF version.
      ///	 *  </summary>
      ///	 * <param name="EnumAttributeValidity"> attrValidity: requested validity </param>
      ///	 * <returns> VString: list of strings containing the names of the matching attributes </returns>
      ///	 
      public virtual VString conformingAttribs(EnumAttributeValidity attrValidity)
      {
         VString matchingAttribs = new VString();
         long l2 = JDFVersions.getTheMask(version);
         long v2 = JDFVersions.getTheOffset(version);

         IEnumerator iter = attribInfoTable.Keys.GetEnumerator();
         bool bOK = attrValidity == null;
         while (iter.MoveNext())
         {
            string theKey = (string)iter.Current;
            AtrInfo ai = (AtrInfo)attribInfoTable[theKey];
            if (bOK)
            {
               matchingAttribs.Add(theKey);
            }
            else
            {
               if (attrValidity != null)
               {
                  // grab values from tables
                  long l1 = ai.getAtrValidityStatus();
                  long l3 = l1 & l2;

                  // calculate correct mask from attrValidity and version
                  long v1 = attrValidity.getValue();
                  long v3 = v1 << (int)v2;

                  // tables and version coincide
                  if (l3 == v3)
                  {
                     matchingAttribs.Add(theKey);
                  }
               }
            }
         }

         return matchingAttribs;
      }

      ///   
      ///	 <summary> * Returns a map of attributes with defaults for the specified JDF version.
      ///	 *  </summary>
      ///	 * <returns> JDFAttributeMap: map of strings containing the names and defaults of the matching attributes, null if no
      ///	 *         defaults exist </returns>
      ///	 
      public virtual JDFAttributeMap getDefaultAttributeMap()
      {
         JDFAttributeMap matchingAttribs = new JDFAttributeMap();

         IEnumerator iter = attribInfoTable.Keys.GetEnumerator();
         while (iter.MoveNext())
         {
            string theKey = (string)iter.Current;
            AtrInfo ai = (AtrInfo)attribInfoTable[theKey];
            long l2 = JDFVersions.getTheMask(version);
            long v2 = JDFVersions.getTheOffset(version);
            EnumAttributeValidity versionVal = EnumAttributeValidity.getEnum((int)((ai.getAtrValidityStatus() & l2) >> (int)v2));
            if (versionVal.Equals(EnumAttributeValidity.Optional) || versionVal.Equals(EnumAttributeValidity.Required))
            {
               string def = ai.getAtrDefault();
               if (def != null)
               {
                  matchingAttribs.put(theKey, def);
               }
            }
         }
         return matchingAttribs.IsEmpty() ? null : matchingAttribs;
      }

      ///   
      ///	 <summary> * Returns true if there is at least one attribute matching the requested validity for the specified JDF version.
      ///	 *  </summary>
      ///	 * <param name="EnumAttributeValidity"> attrValidity: requested validity </param>
      ///	 * <returns> boolean: true if at least one attribute matches the requested validity </returns>
      ///	 
      public virtual bool hasConformingAttrib(EnumAttributeValidity attrValidity)
      {
         IEnumerator iter = attribInfoTable.Keys.GetEnumerator();

         long l2 = JDFVersions.getTheMask(version);
         long v2 = JDFVersions.getTheOffset(version);
         while (iter.MoveNext())
         {
            AtrInfo ai = (AtrInfo)attribInfoTable[iter.Current];
            if ((ai.getAtrValidityStatus() & l2) == ((long)attrValidity.getValue() << (int)v2))
            {
               return true;
            }
         }

         return false;
      }

      ///   
      ///	 <summary> * Returns the list of required attributes for the specified JDF version.
      ///	 *  </summary>
      ///	 * <returns> VString: list of strings containing the names of the required attributes </returns>
      ///	 
      public virtual VString requiredAttribs()
      {
         return conformingAttribs(EnumAttributeValidity.Required);
      }

      ///   
      ///	 <summary> * Returns the list of optional attributes for the specified JDF version. Note: This includes attributes marked as
      ///	 * optional as well as attributes marked as deprecated (since, for backward compatibility, these are also optional).
      ///	 *  </summary>
      ///	 * <returns> VString: list of strings containing the names of the optional attributes </returns>
      ///	 
      public virtual VString optionalAttribs()
      {
         VString optionals = new VString(conformingAttribs(EnumAttributeValidity.Optional));
         optionals.appendUnique(conformingAttribs(EnumAttributeValidity.Deprecated));
         IEnumerator iter = attribInfoTable.Keys.GetEnumerator();
         // anything with a default is at least optional
         while (iter.MoveNext())
         {
            string theKey = (string)iter.Current;
            string defaultVal = getAttributeDefault(theKey);
            if (defaultVal != null)
               optionals.appendUnique(theKey);
         }

         return optionals;
      }

      ///   
      ///	 <summary> * Returns the list of all attributes for the specified JDF version.
      ///	 *  </summary>
      ///	 * <returns> VString: list of strings containing the names of the deprecated attributes </returns>
      ///	 
      public virtual VString knownAttribs()
      {
         return conformingAttribs(null);
      }

      ///   
      ///	 <summary> * Returns the list of deprecated attributes for the specified JDF version.
      ///	 *  </summary>
      ///	 * <returns> VString: list of strings containing the names of the deprecated attributes </returns>
      ///	 
      public virtual VString deprecatedAttribs()
      {
         return conformingAttribs(EnumAttributeValidity.Deprecated);
      }

      ///   
      ///	 <summary> * Returns the list of prerelease attributes (those that are only valid in a later version) for the specified JDF
      ///	 * version.
      ///	 *  </summary>
      ///	 * <returns> VString: list of strings containing the names of the prerelease attributes </returns>
      ///	 
      public virtual VString prereleaseAttribs()
      {
         return conformingAttribs(EnumAttributeValidity.None);
      }

      ///   
      ///	 <summary> * Returns the type of the given attribute for the latest JDF version. Attribute types of previous versions have to
      ///	 * be provided by attribute-specific functions (if necessary).
      ///	 *  </summary>
      ///	 * <param name="String"> attributeName: name of the attribute </param>
      ///	 * <returns> EnumAttributeType: the attribute's type </returns>
      ///	 
      public virtual EnumAttributeType getAttributeType(string attributeName)
      {
         if (attribInfoTable.ContainsKey(attributeName))
         {
            return ((AtrInfo)attribInfoTable[attributeName]).getAtrType();
         }
         return null;
      }

      ///   
      ///	 <summary> * Returns the validity of the given attribute for the latest JDF version. Attribute types of previous versions have
      ///	 * to be provided by attribute-specific functions (if necessary).
      ///	 *  </summary>
      ///	 * <param name="String"> attributeName: name of the attribute </param>
      ///	 * <returns> EnumAttributeType: the attribute's type </returns>
      ///	 
      public virtual EnumAttributeValidity getAttributeValidity(string attributeName)
      {
         if (attribInfoTable.ContainsKey(attributeName))
         {
            long l = ((AtrInfo)attribInfoTable[attributeName]).getAtrValidityStatus();
            long l2 = JDFVersions.getTheMask(version);
            long v2 = JDFVersions.getTheOffset(version);
            l = (l & l2) >> (int)v2;
            return EnumAttributeValidity.getEnum((int)l);

         }
         return null;
      }

      ///   
      ///	 <summary> * Returns the ValuedEnum that goes with attributeName
      ///	 *  </summary>
      ///	 * <param name="attributeName"> : name of the attribute </param>
      ///	 * <returns> EnumAttributeType: the attribute's type </returns>
      ///	 
      public virtual ValuedEnum getAttributeEnum(string attributeName)
      {
         if (attribInfoTable.ContainsKey(attributeName))
         {
            return ((AtrInfo)attribInfoTable[attributeName]).getEnumEnum();
         }
         return null;
      }

      ///   
      ///	 <summary> * Returns the Default that goes with attributeName
      ///	 *  </summary>
      ///	 * <param name="attributeName"> : name of the attribute </param>
      ///	 * <returns> EnumAttributeType: the attribute's type </returns>
      ///	 
      public virtual string getAttributeDefault(string attributeName)
      {
         if (attribInfoTable.ContainsKey(attributeName))
         {
            return ((AtrInfo)attribInfoTable[attributeName]).getAtrDefault();
         }
         return null;
      }

      //   
      //	 * ----------------------------------------------------------------------- Enumeration of valid attribute types
      //	 * -----------------------------------------------------------------------
      //	 

      ///   
      ///	 <summary> * Enumeration of valid attribute types </summary>
      ///	 
      public sealed class EnumAttributeType : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         ///      
         ///		 * <param name="name"> </param>
         ///		 
         private EnumAttributeType(string name)
            : base(name, m_startValue++)
         {
         }

         ///      
         ///		 * <param name="enumName"> the name of the enum object to return </param>
         ///		 * <returns> the enum object if enumName is valid. Otherwise null </returns>
         ///		 
         public static EnumAttributeType getEnum(string enumName)
         {
            EnumAttributeType eat = (EnumAttributeType)getEnum(typeof(EnumAttributeType), enumName);
            return (eat == null) ? EnumAttributeType.Any : eat;
         }

         ///      
         ///		 * <param name="enumValue"> the value of the enum object to return </param>
         ///		 * <returns> the enum object if enumName is valid. Otherwise null </returns>
         ///		 
         public static EnumAttributeType getEnum(int enumValue)
         {
            return (EnumAttributeType)getEnum(typeof(EnumAttributeType), enumValue);
         }

         ///      
         ///		 * <returns> a map of all orientation enums </returns>
         ///		 
         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumAttributeType));
         }

         ///      
         ///		 * <returns> a list of all orientation enums </returns>
         ///		 
         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumAttributeType));
         }

         ///      
         ///		 * <returns> an iterator over the enum objects </returns>
         ///		 
         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumAttributeType));
         }

         ///      
         ///		 * <returns> true if test is a range data type </returns>
         ///		 
         public static bool isRange(EnumAttributeType test)
         {
            return EnumAttributeType.DateTimeRange.Equals(test) || EnumAttributeType.DateTimeRangeList.Equals(test) || EnumAttributeType.DurationRange.Equals(test) || EnumAttributeType.DurationRangeList.Equals(test) || EnumAttributeType.IntegerRange.Equals(test) || EnumAttributeType.IntegerRangeList.Equals(test) || EnumAttributeType.NameRange.Equals(test) || EnumAttributeType.NameRangeList.Equals(test) || EnumAttributeType.NumberRange.Equals(test) || EnumAttributeType.NumberRangeList.Equals(test) || EnumAttributeType.RectangleRange.Equals(test) || EnumAttributeType.RectangleRangeList.Equals(test) || EnumAttributeType.ShapeRange.Equals(test) || EnumAttributeType.ShapeRangeList.Equals(test) || EnumAttributeType.XYPairRange.Equals(test) || EnumAttributeType.XYPairRangeList.Equals(test);
         }

         public static readonly EnumAttributeType Any = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_ANY);
         public static readonly EnumAttributeType boolean_ = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_BOOLEAN);
         public static readonly EnumAttributeType CMYKColor = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_CMYKCOLOR);
         public static readonly EnumAttributeType dateTime = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_DATETIME);
         public static readonly EnumAttributeType DateTimeRange = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_DATETIMERANGE);
         public static readonly EnumAttributeType DateTimeRangeList = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_DATETIMERANGELIST);
         public static readonly EnumAttributeType double_ = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_DOUBLE);
         public static readonly EnumAttributeType duration = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_DURATION);
         public static readonly EnumAttributeType DurationRange = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_DURATIONRANGE);
         public static readonly EnumAttributeType DurationRangeList = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_DURATIONRANGELIST);
         public static readonly EnumAttributeType enumeration = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_ENUMERATION); // also
         // used
         // for
         // Orientation,
         // defined in JDF
         // Spec
         public static readonly EnumAttributeType enumerations = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_ENUMERATIONS); // also
         // used
         // for
         // Orienttions,
         // defined in JDF
         // Spec
         public static readonly EnumAttributeType hexBinary = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_HEXBINARY);
         public static readonly EnumAttributeType ID = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_ID);
         public static readonly EnumAttributeType IDREF = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_IDREF);
         public static readonly EnumAttributeType IDREFS = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_IDREFS);
         public static readonly EnumAttributeType integer = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_INTEGER);
         public static readonly EnumAttributeType IntegerList = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_INTEGERLIST);
         public static readonly EnumAttributeType IntegerRange = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_INTEGERRANGE);
         public static readonly EnumAttributeType IntegerRangeList = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_INTEGERRANGELIST);
         public static readonly EnumAttributeType JDFJMFVersion = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_JDFJMFVERSION);
         public static readonly EnumAttributeType LabColor = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_LABCOLOR);
         public static readonly EnumAttributeType language = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_LANGUAGE);
         public static readonly EnumAttributeType languages = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_LANGUAGES);
         public static readonly EnumAttributeType matrix = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_MATRIX);
         public static readonly EnumAttributeType NameRange = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_NAMERANGE);
         public static readonly EnumAttributeType NameRangeList = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_NAMERANGELIST);
         public static readonly EnumAttributeType NMTOKEN = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_NMTOKEN);
         public static readonly EnumAttributeType NMTOKENS = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_NMTOKENS);
         public static readonly EnumAttributeType NumberList = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_NUMBERLIST); // equivalent
         // to
         // DoubleList, defined
         // in JDF Spec
         public static readonly EnumAttributeType NumberRange = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_NUMBERRANGE);
         public static readonly EnumAttributeType NumberRangeList = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_NUMBERRANGELIST);
         public static readonly EnumAttributeType PDFPath = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_PDFPATH);
         public static readonly EnumAttributeType rectangle = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_RECTANGLE);
         public static readonly EnumAttributeType RectangleRange = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_RECTANGLERANGE);
         public static readonly EnumAttributeType RectangleRangeList = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_RECTANGLERANGELIST);
         public static readonly EnumAttributeType RegExp = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_REGEXP);
         public static readonly EnumAttributeType RGBColor = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_RGBCOLOR);
         public static readonly EnumAttributeType shape = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_SHAPE);
         public static readonly EnumAttributeType ShapeRange = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_SHAPERANGE);
         public static readonly EnumAttributeType ShapeRangeList = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_SHAPERANGELIST);
         public static readonly EnumAttributeType shortString = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_SHORTSTRING);
         public static readonly EnumAttributeType string_ = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_STRING);
         public static readonly EnumAttributeType TransferFunction = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_TRANSFERFUNCTION);
         public static readonly EnumAttributeType unbounded = new EnumAttributeType(JDFConstants.UNBOUNDED); // needed
         // for
         // schema
         // int
         // or
         // unbounded
         public static readonly EnumAttributeType URI = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_URI);
         public static readonly EnumAttributeType URL = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_URL);
         public static readonly EnumAttributeType XYPair = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_XYPAIR);
         public static readonly EnumAttributeType XYPairRange = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_XYPAIRRANGE);
         public static readonly EnumAttributeType XYPairRangeList = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_XYPAIRRANGELIST);
         public static readonly EnumAttributeType XPath = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_XPATH);
         public static readonly EnumAttributeType XYRelation = new EnumAttributeType(JDFConstants.ATTRIBUTETYPE_XYRELATION);
      }

      //   
      //	 * ----------------------------------------------------------------------- Enumeration of attribute validity values
      //	 * -----------------------------------------------------------------------
      //	 

      ///   
      ///	 <summary> * Enumeration of attribute validity values </summary>
      ///	 
      public sealed class EnumAttributeValidity : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         ///      
         ///		 * <param name="name"> </param>
         ///		 
         private EnumAttributeValidity(string name)
            : base(name, m_startValue++)
         {
         }

         ///      
         ///		 * <param name="enumName"> the name of the enum object to return </param>
         ///		 * <returns> the enum object if enumName is valid. Otherwise null </returns>
         ///		 
         public static EnumAttributeValidity getEnum(string enumName)
         {
            return (EnumAttributeValidity)getEnum(typeof(EnumAttributeValidity), enumName);
         }

         ///      
         ///		 * <param name="enumValue"> the value of the enum object to return </param>
         ///		 * <returns> the enum object if enumName is valid. Otherwise null </returns>
         ///		 
         public static EnumAttributeValidity getEnum(int enumValue)
         {
            return (EnumAttributeValidity)getEnum(typeof(EnumAttributeValidity), enumValue);
         }

         ///      
         ///		 * <returns> a map of all orientation enums </returns>
         ///		 
         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumAttributeValidity));
         }

         ///      
         ///		 * <returns> a list of all orientation enums </returns>
         ///		 
         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumAttributeValidity));
         }

         ///      
         ///		 * <returns> an iterator over the enum objects </returns>
         ///		 
         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumAttributeValidity));
         }

         public static readonly EnumAttributeValidity Unknown = new EnumAttributeValidity(JDFConstants.ATTRIBUTEVALIDITY_UNKNOWN);
         public static readonly EnumAttributeValidity None = new EnumAttributeValidity(JDFConstants.ATTRIBUTEVALIDITY_NONE);
         public static readonly EnumAttributeValidity Required = new EnumAttributeValidity(JDFConstants.ATTRIBUTEVALIDITY_REQUIRED);
         public static readonly EnumAttributeValidity Optional = new EnumAttributeValidity(JDFConstants.ATTRIBUTEVALIDITY_OPTIONAL);
         public static readonly EnumAttributeValidity Deprecated = new EnumAttributeValidity(JDFConstants.ATTRIBUTEVALIDITY_DEPRECATED);
         public static readonly EnumAttributeValidity Any = new EnumAttributeValidity(JDFConstants.ATTRIBUTEVALIDITY_ANY);
      }

      public virtual void setVersion(EnumVersion v)
      {
         version = v;
      }

      ///   
      ///	 <summary> * returns the data type of a given attribute
      ///	 *  </summary>
      ///	 * <param name="attributeName"> the localname of the attribute to check </param>
      ///	 * <returns> the data type of attributeName </returns>
      ///	 * @deprecated 2005-08-26 
      ///	 
      [Obsolete("2005-08-26")]
      public virtual EnumAttributeType getAtrType(string attributeName)
      {
         AtrInfo ai = (AtrInfo)attribInfoTable[attributeName];
         if (ai == null)
         {
            return null;
         }
         return ai.getAtrType();
      }

      public virtual bool validAttribute(string key, string attribute, KElement.EnumValidationLevel level)
      {
         EnumAttributeType typ = getAttributeType(key);
         if (typ == null) // unknown attributes are by definition valid, the
            // check is done in the unknown method
            return true;

         // get the correct enumeration lists
         ValuedEnum enu = null;
         if ((typ == EnumAttributeType.enumeration) || (typ == EnumAttributeType.enumerations))
         {
            enu = getAttributeEnum(key);
         }
         else if (typ == EnumAttributeType.JDFJMFVersion)
         {
            enu = EnumVersion.getEnum(0);
         }

         EnumAttributeValidity val = getAttributeValidity(key);
         if (val == EnumAttributeValidity.Unknown)
         {
            return (attribute == null);
         }
         else if (val == EnumAttributeValidity.Deprecated)
         {
            return (attribute == null) || EnumValidationLevel.isNoWarn(level);
         }
         else if (val == EnumAttributeValidity.None) // prerelease may be set
         // by schema validating
         // parser
         {
            return (attribute == null) || attribute.Equals(getAttributeDefault(key)) || EnumValidationLevel.isNoWarn(level);
         }
         else if ((val == EnumAttributeValidity.Optional) || ((level != EnumValidationLevel.Complete) && (level != EnumValidationLevel.RecursiveComplete)))
         {
            return (attribute == null) || validStringForType(attribute, typ, enu);
         }
         else if (val == EnumAttributeValidity.Required)
         {
            return (attribute != null) && validStringForType(attribute, typ, enu);
         }

         return true;
      }


      public static bool validStringForType(string val, EnumAttributeType iType, ValuedEnum enu)
      {
         if (val == null)
            return false;

         try
         {
            if (iType == AttributeInfo.EnumAttributeType.Any)
            {
               return true;
            }
            if (iType == AttributeInfo.EnumAttributeType.string_)
            {
               return val.Length < 1024;
            }
            if (iType == AttributeInfo.EnumAttributeType.shortString)
            {
               return val.Length < 64;
            }
            if (iType == AttributeInfo.EnumAttributeType.ID)
            {
               return StringUtil.isID(val);
            }
            if (iType == AttributeInfo.EnumAttributeType.NMTOKEN)
            {
               return StringUtil.isNMTOKEN(val);
            }
            if (iType == AttributeInfo.EnumAttributeType.NMTOKENS)
            {
               return StringUtil.isNMTOKENS(val, false);
            }
            if (iType == AttributeInfo.EnumAttributeType.IDREF)
            {
               return StringUtil.isID(val);
            }
            if (iType == AttributeInfo.EnumAttributeType.IDREFS)
            {
               return StringUtil.isNMTOKENS(val, true);
            }
            if (iType == AttributeInfo.EnumAttributeType.boolean_)
            {
               return StringUtil.isBoolean(val);
            }
            if (iType == AttributeInfo.EnumAttributeType.double_)
            {
               return StringUtil.isNumber(val);
            }
            if (iType == AttributeInfo.EnumAttributeType.integer)
            {
               return StringUtil.isInteger(val);
            }
            // integer or unbounded
            if (iType == AttributeInfo.EnumAttributeType.unbounded)
            {
               return JDFConstants.UNBOUNDED.Equals(val) || StringUtil.isInteger(val);
            }

            if ((iType == AttributeInfo.EnumAttributeType.URI) || (iType == AttributeInfo.EnumAttributeType.URL))
            {
               return UrlUtil.isIRL(val);
            }
            else if (iType == AttributeInfo.EnumAttributeType.RegExp)
            {
               return true;
            }

            else if ((iType == AttributeInfo.EnumAttributeType.enumeration) || (iType == AttributeInfo.EnumAttributeType.JDFJMFVersion))
            {
               if (enu != null)
               {
                  ValuedEnum ve = (ValuedEnum)EnumUtils.getEnum(enu.GetType(), val);
                  return ve != null;
               }
               // limp along if something went wrong
               return StringUtil.isNMTOKEN(val);
            }
            else if (iType == AttributeInfo.EnumAttributeType.enumerations)
            {
               if (enu != null)
               {
                  VString vs = new VString(StringUtil.tokenize(val, JDFConstants.BLANK, false));
                  for (int i = 0; i < vs.Count; i++)
                  {
                     ValuedEnum ve = (ValuedEnum)EnumUtils.getEnum(enu.GetType(), vs.stringAt(i));
                     // there was an invalid token
                     if (ve == null)
                        return false;
                  }
                  // all were ok
                  return true;
               }
               // limp along if something went wrong
               return StringUtil.isNMTOKENS(val, false);
            }
            else if (iType == AttributeInfo.EnumAttributeType.IntegerRange)
            {
               new JDFIntegerRange(val);
               return true;
            }
            else if (iType == AttributeInfo.EnumAttributeType.IntegerList)
            {
               new JDFIntegerList(val);
               return true;
            }
            else if (iType == AttributeInfo.EnumAttributeType.IntegerRangeList)
            {
               new JDFIntegerRangeList(val);
               return true;
            }
            else if (iType == AttributeInfo.EnumAttributeType.NumberRange)
            {
               new JDFNumberRange(val);
               return true;
            }
            else if (iType == AttributeInfo.EnumAttributeType.NumberRangeList)
            {
               new JDFNumberRangeList(val);
               return true;
            }
            else if (iType == AttributeInfo.EnumAttributeType.NumberList)
            {
               new JDFNumberList(val);
               return true;
            }
            else if (iType == AttributeInfo.EnumAttributeType.matrix)
            {
               new JDFMatrix(val);
               return true;
            }
            else if (iType == AttributeInfo.EnumAttributeType.rectangle)
            {
               new JDFRectangle(val);
               return true;
            }
            else if (iType == AttributeInfo.EnumAttributeType.shape)
            {
               new JDFShape(val);
               return true;
            }
            else if (iType == AttributeInfo.EnumAttributeType.XYPair)
            {
               new JDFXYPair(val);
               return true;
            }
            else if (iType == AttributeInfo.EnumAttributeType.XYPairRange)
            {
               new JDFXYPairRange(val);
               return true;
            }
            else if (iType == AttributeInfo.EnumAttributeType.XYPairRangeList)
            {
               new JDFXYPairRangeList(val);
               return true;
            }
            else if (iType == AttributeInfo.EnumAttributeType.dateTime)
            {
               new JDFDate(val);
               return val.IndexOf("T") == 10; // pure dates are not valid
            }
            else if (iType == AttributeInfo.EnumAttributeType.duration)
            {
               new JDFDuration(val);
               return true;
            }
            else if (iType == AttributeInfo.EnumAttributeType.DurationRangeList)
            {
               new JDFDurationRangeList(val);
               return true;
            }
            else if (iType == AttributeInfo.EnumAttributeType.DateTimeRangeList)
            {
               new JDFDateTimeRangeList(val);
               return true;
            }
            else if (iType == AttributeInfo.EnumAttributeType.RectangleRangeList)
            {
               new JDFRectangleRangeList(val);
               return true;
            }
            else if (iType == AttributeInfo.EnumAttributeType.ShapeRangeList)
            {
               new JDFShapeRangeList(val);
               return true;
            }
            else if (iType == AttributeInfo.EnumAttributeType.CMYKColor)
            {
               new JDFCMYKColor(val);
               return true;
            }
            else if (iType == AttributeInfo.EnumAttributeType.LabColor)
            {
               new JDFLabColor(val);
               return true;
            }
            else if (iType == AttributeInfo.EnumAttributeType.RGBColor)
            {
               new JDFRGBColor(val);
               return true;
            }
            else if (iType == AttributeInfo.EnumAttributeType.language)
            {
               return validLanguageString(val);
            }
            else if (iType == AttributeInfo.EnumAttributeType.languages)
            {
               VString v = new VString(StringUtil.tokenize(val, JDFConstants.BLANK, false));
               for (int i = 0; i < v.Count; i++)
               {
                  if (!validLanguageString(v[i]))
                     return false;
               }
               return true;
            }
            else if (iType == AttributeInfo.EnumAttributeType.PDFPath)
            {
               // TODO better regexp
               return true;
            }
            else if (iType == AttributeInfo.EnumAttributeType.XPath)
            {
               // TODO better regexp
               return true;
            }
            else if (iType == AttributeInfo.EnumAttributeType.hexBinary)
            {
               return StringUtil.matches(val, JDFConstants.REGEXP_HEXBINARY);
            }
            else if (iType == AttributeInfo.EnumAttributeType.TransferFunction)
            {
               JDFNumberList nl = new JDFNumberList(val);
               return nl.Count % 2 == 0;
            }
            else
            {
               // TODO check if we are complete
               Console.WriteLine("validStringForType: unknown type:" + iType.getName());
               return false;
            }
         }
         catch (FormatException)
         {
            return false;
         }
      }

      private static bool validLanguageString(string val)
      {
         // TODO better regexp
         int l = val.Length;
         int posDash = val.IndexOf("-");
         return l >= 2 && l <= 3 || l > 4 && (posDash >= 2 && posDash < 4); // 2=en
         // ,
         // de
         // ,
         // ...
      }

      public override string ToString()
      {
         string s = "AttributeInfoTable version=" + version + " {";
         foreach (object key in attribInfoTable.Keys)
         {
            s += " {" + key.ToString() + "," + attribInfoTable[key].ToString() + "}";
         }
         s += "}";
 
         return s;
      }

      ///   
      ///	 <summary> * get the first jdf version where an attrinute of this type is valid
      ///	 *  </summary>
      ///	 * <param name="attributeName"> the name of the queried attribute
      ///	 * @return </param>
      ///	 
      public virtual EnumVersion getFirstVersion(string attributeName)
      {
         if (attribInfoTable.ContainsKey(attributeName))
         {
            return ((AtrInfo)attribInfoTable[attributeName]).getFirstVersion();
         }
         return null;
      }

      ///   
      ///	 <summary> * get the last jdf version where an attrinute of this type is valid
      ///	 *  </summary>
      ///	 * <param name="attributeName"> the name of the queried attribute
      ///	 * @return </param>
      ///	 
      public virtual EnumVersion getLastVersion(string attributeName)
      {
         if (attribInfoTable.ContainsKey(attributeName))
         {
            return ((AtrInfo)attribInfoTable[attributeName]).getLastVersion();
         }
         return null;
      }
   }
}
