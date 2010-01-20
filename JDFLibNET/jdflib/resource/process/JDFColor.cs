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
 * JDFColor.cs
 * Last changes
 */

namespace org.cip4.jdflib.resource.process
{
   using System.Text;


   using JDFAutoColor = org.cip4.jdflib.auto.JDFAutoColor;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using VElement = org.cip4.jdflib.core.VElement;
   using StringUtil = org.cip4.jdflib.util.StringUtil;

   public class JDFColor : JDFAutoColor
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFColor
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFColor(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFColor
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFColor(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFColor
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="localName"> </param>
      ///	 
      public JDFColor(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
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
         return "JDFColor[  --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * Set the Name and RawName attributes to the value given in pName The value
      ///	 * in Name uses the default encoding
      ///	 *  </summary>
      ///	 * <param name="char">[] cName the 8 bit string to set the name to </param>
      ///	 
      public virtual void set8BitNames(byte[] cName)
      {
         string rawName = StringUtil.setHexBinaryBytes(cName, -1);
         setRawName(rawName);
         setName(Encoding.Default.GetString(cName));
      }

      ///   
      ///	 <summary> * Gets the ActualColorName or Name if no ActualColorName is set
      ///	 *  </summary>
      ///	 * <returns> String Name of the color extracted from RawName, or if this is
      ///	 *         missing from Name, using the default transcoder </returns>
      ///	 
      public override string getActualColorName()
      {
         string strName = getAttribute(AttributeName.ACTUALCOLORNAME, null, null);
         return strName == null ? getName() : strName;
      }

      ///   
      ///	 <summary> * Gets the 16 bit representation of the 8 bit color name Use String
      ///	 * GetRawBytes() to extract the 8 bit representation
      ///	 *  </summary>
      ///	 * <returns> String Name of the color extracted from RawName, or if this is
      ///	 *         missing from Name, using the default transcoder </returns>
      ///	 
      public virtual string get8BitName()
      {
         string strName = getAttribute(AttributeName.RAWNAME, null, null);
         if (strName != null)
         {
            byte[] rawName = Encoding.Default.GetBytes(strName);
            byte[] foundName = StringUtil.getHexBinaryBytes(rawName);

            return Encoding.Default.GetString(foundName);
         }
         return getActualColorName();
      }



      public virtual JDFFileSpec getColorProfile()
      {
         VElement v = getChildElementVector(ElementName.FILESPEC, null, null, true, 0, false);
         if (v != null)
         {
            int siz = v.Count;
            for (int i = 0; i < siz; i++)
            {
               JDFFileSpec res = (JDFFileSpec)v[i];
               if (res.hasAttribute(AttributeName.RESOURCEUSAGE))
               {
                  if (res.getResourceUsage().Equals("ColorProfile"))
                  {
                     return res;
                  }
               }
            }
         }

         return null;
      }


      public virtual JDFFileSpec getCreateColorProfile()
      {
         JDFFileSpec res = getColorProfile();
         if (res == null)
         {
            res = appendColorProfile();
         }
         return res;
      }


      public virtual JDFFileSpec appendColorProfile()
      {
         JDFFileSpec res = appendFileSpec();
         res.setResourceUsage("ColorProfile");

         return res;
      }

 
      public virtual JDFFileSpec getTargetProfile()
      {
         VElement v = getChildElementVector(ElementName.FILESPEC, null, null, true, 0, false);

         int siz = v.Count;
         for (int i = 0; i < siz; i++)
         {
            JDFFileSpec res = (JDFFileSpec)v[i];
            if (res.hasAttribute(AttributeName.RESOURCEUSAGE))
            {
               if (res.getResourceUsage().Equals("TargetProfile"))
               {
                  return res;
               }
            }
         }
         return null;
      }


      public virtual JDFFileSpec getCreateTargetProfile()
      {
         JDFFileSpec res = getTargetProfile();
         if (res == null)
         {
            res = appendTargetProfile();
         }
         return res;
      }


      internal virtual JDFFileSpec appendTargetProfile()
      {
         JDFFileSpec res = appendFileSpec();
         res.setResourceUsage("TargetProfile");

         return res;
      }

      public override bool fixVersion(EnumVersion version)
      {
         if (hasAttribute(AttributeName.USEPDLALTERNATECS))
         {
            if (!hasAttribute(AttributeName.MAPPINGSELECTION))
            {
               setMappingSelection(getUsePDLAlternateCS() ? EnumMappingSelection.UsePDLValues : EnumMappingSelection.UseProcessColorValues);
            }
            removeAttribute(AttributeName.USEPDLALTERNATECS);
         }
         return base.fixVersion(version);
      }
   }
}
