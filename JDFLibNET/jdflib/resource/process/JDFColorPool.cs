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



namespace org.cip4.jdflib.resource.process
{
   using System;
   using System.Text;
   using System.Collections.Generic;



   using JDFAutoColorPool = org.cip4.jdflib.auto.JDFAutoColorPool;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using StringUtil = org.cip4.jdflib.util.StringUtil;


   public class JDFColorPool : JDFAutoColorPool
   {
      private new const long serialVersionUID = 1L;


      /// <summary>
      /// Constructor for JDFColorPool
      /// </summary>
      /// <param name="myOwnerDocument"></param>
      /// <param name="qualifiedName"></param>
      public JDFColorPool(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }


      /// <summary>
      /// Constructor for JDFColorPool
      /// </summary>
      /// <param name="myOwnerDocument"></param>
      /// <param name="myNamespaceURI"></param>
      /// <param name="qualifiedName"></param>
      public JDFColorPool(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }


      /// <summary>
      /// Constructor for JDFColorPool
      /// </summary>
      /// <param name="myOwnerDocument"></param>
      /// <param name="myNamespaceURI"></param>
      /// <param name="qualifiedName"></param>
      /// <param name="myLocalName"></param>
      public JDFColorPool(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      // **************************************** Methods
      // *********************************************

      /// <summary>
      /// ToString
      /// </summary>
      /// <returns>string</returns>
      public override string ToString()
      {
         return "JDFColorPool[  --> " + base.ToString() + " ]";
      }

      public virtual void removeColor(string strColorName)
      {
         VElement vElem = getChildElementVector(ElementName.COLOR, null, null, true, 0, false);
         if (vElem != null)
         {
            int size = vElem.Count;
            for (int i = 0; i < size; i++)
            {
               JDFColor c = (JDFColor)vElem[i];
               if (strColorName.Equals(c.getActualColorName()))
               {
                  c.deleteNode();
               }
            }
         }
      }

      ///   
      ///	 <summary> * typesafe validator
      ///	 *  </summary>
      ///	 * <param name="EnumValidationLevel">
      ///	 *            level validation level </param>
      ///	 * <returns> boolean true if this is valid </returns>
      ///	 
      public override bool isValid(EnumValidationLevel level)
      {
         bool bValid = base.isValid(level);
         if (!bValid)
         {
            return false;
         }

         bValid = getDuplicateColors() == null;
         return bValid;
      }

      ///   
      ///	 <summary> * does this ColorPool have Color elements with identical Name or RawName
      ///	 * eattributes return false if no Color elements with identical Name or
      ///	 * RawName tags exist
      ///	 *  </summary>
      ///	 * @deprecated use getDuplicateColors()==null 
      ///	 
      [Obsolete("use getDuplicateColors()==null")]
      public virtual bool hasDuplicateColors()
      {
         return getDuplicateColors() != null;
      }

      ///   
      ///	 <summary> * does this ColorPool have Color elements with identical Name or RawName
      ///	 * eattributes return false if no Color elements with identical Name or
      ///	 * RawName tags exist </summary>
      ///	 
      public virtual VString getDuplicateColors()
      {
         VElement v = getChildElementVector(ElementName.COLOR, null, null, true, 0, false);
         SupportClass.HashSetSupport<string> vName = new SupportClass.HashSetSupport<string>();
         int nCols = v.Count;
         VString vRet = new VString();
         for (int i = 0; i < nCols; i++)
         {
            JDFColor color = (JDFColor)v[i];
            string colorName = color.getName();
            if (vName.Contains(colorName))
            {
               vRet.appendUnique(colorName);
            }
            string rawName = color.get8BitName();
            if (vName.Contains(rawName))
            {
               vRet.appendUnique(colorName);
            }
            vName.Add(colorName);
            vName.Add(rawName);
         }

         return vRet.Count == 0 ? null : vRet;
      }

      ///   
      ///	 <summary> * Get the Color Element with Name=name
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            name the name of the color
      ///	 *  </param>
      ///	 * <returns> JDFColor the color with the matching name, or null if no matching
      ///	 *         element exists </returns>
      ///	 
      public virtual JDFColor getColorWithName(string colorName)
      {
         JDFColor color = null;

         if (colorName == null)
         {
            throw new JDFException("Bad colorname:" + colorName);
         }

         VElement v = getChildElementVector(ElementName.COLOR, null, null, true, 0, false);
         if (v != null)
         {
            int pos = -1;
            int siz = v.Count;
            for (int i = 0; i < siz; i++)
            {
               color = (JDFColor)v[i];
               if (colorName.Equals(color.getName()) || colorName.Equals(color.getActualColorName()))
               {
                  if (pos < 0)
                  {
                     pos = i;
                  }
                  else
                  {
                     throw new JDFException("Multiple colors exist for:" + colorName);
                  }
               }
            }

            color = (JDFColor)(pos == -1 ? null : v[pos]);
         }

         return color;
      }

      ///   
      ///	 <summary> * Get the Color Element with RawName=rawName or Name=rawName in the
      ///	 * momentary encoding
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            rawName the 8 bit representation of the rawName of the color
      ///	 *  </param>
      ///	 * <returns> JDFColor the color with the matching name, null if no matching
      ///	 *         element exists </returns>
      ///	 
      public virtual JDFColor getColorWith8BitName(string rawName)
      {
         VElement v = getChildElementVector(ElementName.COLOR, null, null, true, 0, false);

         for (int i = 0; i < v.Count; i++)
         {
            JDFColor c = (JDFColor)v[i];
            string pRawName = new string(SupportClass.ToCharArray(SupportClass.ToByteArray(StringUtil.getRawBytes(c.get8BitName()))));
            if (pRawName.Equals(rawName))
            {
               return c;
            }
         }

         return null;
      }

      ///   
      ///	 <summary> * Get the Color Element with RawName=rawName
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            rawName the 8 bit representation of the rawName of the color
      ///	 *  </param>
      ///	 * <returns> JDFColor the color with the matching name or null if no matching
      ///	 *         element exists </returns>
      ///	 
      public virtual JDFColor getColorWithRawName(string rawName)
      {
         JDFAttributeMap m = new JDFAttributeMap();

         //string hexRawName = StringUtil.setHexBinaryBytes(rawName.getBytes(), -1);
         Encoding encoding = Encoding.Default;
         string hexRawName = StringUtil.setHexBinaryBytes(SupportClass.ToSByteArray(encoding.GetBytes(rawName)), -1);

         m.put(AttributeName.RAWNAME, hexRawName);
         VElement v = getChildElementVector(ElementName.COLOR, null, m, true, 0, false);
         if (v.Count == 0)
         {
            return null;
         }
         else if (v.Count > 1)
         {
            throw new JDFException("JDFColorPool.getColorWithRawName: too many colors\n");
         }
         return (JDFColor)v[0];
      }

      ///   
      ///	 <summary> * Append a Color Element with RawName=rawName and Name = Name
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            name the name of the color </param>
      ///	 * <param name="String">
      ///	 *            rawName he 8 bit representation of the rawName of the color
      ///	 *  </param>
      ///	 * <returns> JDFColor the color with the matching name, or null f no matching
      ///	 *         element exists </returns>
      ///	 
      public virtual JDFColor appendColorWithName(string colorName, string rawName)
      {
         JDFColor col = getColorWithName(colorName);
         if (col == null)
         {
            col = getColorWith8BitName(rawName);
         }
         if (col == null)
         {
            col = appendColor();
            if (rawName != null)
            {
               //col.set8BitNames(rawName.getBytes());
               Encoding encoding = Encoding.Default;
               col.set8BitNames(SupportClass.ToSByteArray(encoding.GetBytes(rawName)));
            }
            col.setName(colorName);
         }
         else
         {
            throw new JDFException("JDFColorPool::AppendColorWithName color exists: " + colorName + "/" + rawName);
         }

         return col;
      }

      ///   
      ///	 <summary> * Get an existing or append a Color Element with RawName=rawName and Name =
      ///	 * Name
      ///	 *  </summary>
      ///	 * <param name="colorName">
      ///	 *            the name of the color </param>
      ///	 * <param name="rawName">
      ///	 *            he 8 bit representation of the rawName of the color
      ///	 *  </param>
      ///	 * <returns> JDFColor the color with the matching name or null JDFColor if no
      ///	 *         matching element exists </returns>
      ///	 
      public virtual JDFColor getCreateColorWithName(string colorName, string rawName)
      {
         JDFColor col = rawName != null ? getColorWithRawName(rawName) : null;
         if (col != null)
         {
            return col;
         }

         // it only defaulted throught the transcoder, therefor redo
         col = getColorWithName(colorName);

         if (col == null)
         {
            col = appendColor();
            if (rawName != null)
            {
               //col.set8BitNames(rawName.getBytes());
               Encoding encoding = Encoding.Default;
               col.set8BitNames(SupportClass.ToSByteArray(encoding.GetBytes(rawName)));
            }
            col.setName(colorName);
         }
         else
         {
            if (col.hasAttribute(AttributeName.RAWNAME) && rawName != null)
            {
               // snafu - the rawname is different
               throw new JDFException("JDFColorPool.getCreateColorWithName color is inconsistent: " + colorName);
            }
         }

         return col;
      }
   }
}
