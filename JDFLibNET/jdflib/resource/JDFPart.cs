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



/*========================================================================== class JDFPart extends JDFAutoPart
 * created 2001-09-06T10:02:57GMT+02:00 ==========================================================================
 *          @COPYRIGHT Heidelberger Druckmaschinen AG, 1999-2001 ALL RIGHTS RESERVED
 *              @Author: sabjon@topmail.de   using a code generator
 * Warning! very preliminary test version. Interface subject to change without prior notice! Revision history:   ... */


namespace org.cip4.jdflib.resource
{
   using System.Collections;
   using System.Collections.Generic;



   using JDFAutoPart = org.cip4.jdflib.auto.JDFAutoPart;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using EnumPartIDKey = org.cip4.jdflib.resource.JDFResource.EnumPartIDKey;
   using StringUtil = org.cip4.jdflib.util.StringUtil;

   public class JDFPart : JDFAutoPart
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFPart
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFPart(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFPart
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFPart(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFPart
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFPart(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      ///   
      ///	 <summary> * toString()
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public override string ToString()
      {
         return "JDFPart[  --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * gets a map of all Partition key value pairs, empty if no partition keys exist
      ///	 *  </summary>
      ///	 * <returns> JDFAttributeMap </returns>
      ///	 
      public override JDFAttributeMap getPartMap()
      {
         JDFAttributeMap am = getAttributeMap();
         IEnumerator<string> it = am.Keys.GetEnumerator();
         JDFAttributeMap retMap = new JDFAttributeMap();
         while (it.MoveNext())
         {
            string key = it.Current;
            if (EnumPartIDKey.getEnum(key) != null)
               retMap.put(key, am.get(key));
         }
         return retMap;
      }

      ///   
      ///	 <summary> * sets the attributes of this to partmap removes all other attributes
      ///	 *  </summary>
      ///	 * <param name="mPart"> attribute map for the part to set </param>
      ///	 
      public override void setPartMap(JDFAttributeMap mPart)
      {
         removeAttributes(null);
         setAttributes(mPart);
      }

      ///   
      ///	 <summary> * check whether the partition values match
      ///	 *  </summary>
      ///	 * <param name="key"> the partition key </param>
      ///	 * <param name="resourceValue"> the value of key in the resource </param>
      ///	 * <param name="linkValue"> the value of key in the part element or ref </param>
      ///	 * <returns> boolean: true if linkValue matches the value or list in resourceValue
      ///	 *  </returns>
      ///	 
      public static bool matchesPart(string key, string resourceValue, string linkValue)
      {
         EnumPartIDKey eKey = EnumPartIDKey.getEnum(key);
         if (eKey == null)
            return resourceValue.Equals(linkValue);
         bool b;

         // EnumPartIDKey.PartVersion.equals(eKey)
         if (EnumPartIDKey.DocTags.Equals(eKey) || EnumPartIDKey.ItemNames.Equals(eKey) || EnumPartIDKey.PageTags.Equals(eKey) || EnumPartIDKey.RunTags.Equals(eKey) || EnumPartIDKey.SetTags.Equals(eKey))
         {
            b = StringUtil.matchesAttribute(linkValue, resourceValue, AttributeInfo.EnumAttributeType.NMTOKENS);
         }

         else if (EnumPartIDKey.DocCopies.Equals(eKey) || EnumPartIDKey.DocIndex.Equals(eKey) || EnumPartIDKey.DocRunIndex.Equals(eKey) || EnumPartIDKey.DocSheetIndex.Equals(eKey) || EnumPartIDKey.LayerIDs.Equals(eKey) || EnumPartIDKey.PageNumber.Equals(eKey) || EnumPartIDKey.RunIndex.Equals(eKey) || EnumPartIDKey.SectionIndex.Equals(eKey) || EnumPartIDKey.SetIndex.Equals(eKey) || EnumPartIDKey.SetRunIndex.Equals(eKey) || EnumPartIDKey.SetSheetIndex.Equals(eKey) || EnumPartIDKey.SheetIndex.Equals(eKey))
         {
            b = StringUtil.matchesAttribute(linkValue, resourceValue, AttributeInfo.EnumAttributeType.IntegerRangeList);
         }

         else
         {
            b = resourceValue.Equals(linkValue);
         }
         return b;
      }

      ///   
      ///	 <summary> * overlapMap - identical keys must have the same values in both maps<br>
      ///	 * similar to JDFAttribute.overlapMap, but uses matchesPart instead of equals for the comparison
      ///	 *  </summary>
      ///	 * <param name="subMap"> the map to compare
      ///	 *  </param>
      ///	 * <returns> boolean: true if identical keys have the same values in both maps </returns>
      ///	 
      public static bool overlapPartMap(JDFAttributeMap resourceMap, JDFAttributeMap linkMap)
      {
         if ((resourceMap == null) || (linkMap == null))
            return true; // null always overlaps with anything

         IEnumerator<string> subMapEnum = linkMap.getKeyIterator();
         while (subMapEnum.MoveNext())
         {
            string key = (string)subMapEnum.Current;
            string resVal = resourceMap.get(key);

            if (resVal != null)
            {
               string linkVal = linkMap.get(key);
               if (!matchesPart(key, resVal, linkVal))
               {
                  return false;
               }
            }
         }
         return true;
      }
   }
}
