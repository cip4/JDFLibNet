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
 * JDFColorCorrectionOp.cs
 * Last changes
 */

namespace org.cip4.jdflib.resource.process.prepress
{


   using JDFAutoColorCorrectionOp = org.cip4.jdflib.auto.JDFAutoColorCorrectionOp;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using VElement = org.cip4.jdflib.core.VElement;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using JDFFileSpec = org.cip4.jdflib.resource.process.JDFFileSpec;

   public class JDFColorCorrectionOp : JDFAutoColorCorrectionOp
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * ructor for JDFColorCorrectionOp
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFColorCorrectionOp(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * ructor for JDFColorCorrectionOp
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFColorCorrectionOp(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * ructor for JDFColorCorrectionOp
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="localName"> </param>
      ///	 
      public JDFColorCorrectionOp(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
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
         return "JDFColorCorrectionOp[  --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * Gets of 'this' an existing child FileSpec(AbstractProfile) element
      ///	 *  </summary>
      ///	 * <returns> JDFFileSpec the matching AbstractProfile element or null if
      ///	 *         nothing was found </returns>
      ///	 
      public virtual JDFFileSpec getAbstractProfile()
      {
         VElement v = getChildElementVector(ElementName.FILESPEC, null, new JDFAttributeMap(), true, 0, false);

         int siz = v.Count;
         for (int i = 0; i < siz; i++)
         {
            JDFFileSpec res = (JDFFileSpec)v[i];
            if (res.hasAttribute(AttributeName.RESOURCEUSAGE))
            {
               if ("AbstractProfile".Equals(res.getResourceUsage()))
               {
                  return res;
               }
            }
         }

         return null;
      }

      ///   
      ///	 <summary> * Gets of 'this' child FileSpec(AbstractProfile) element, optionally
      ///	 * creates it, if it doesn't exist.
      ///	 *  </summary>
      ///	 * <returns> JDFFileSpec the matching AbstractProfile element </returns>
      ///	 
      public virtual JDFFileSpec getCreateAbstractProfile()
      {
         JDFFileSpec res = getAbstractProfile();
         if (res == null)
         {
            res = appendAbstractProfile();
         }

         return res;
      }

      ///   
      ///	 <summary> * Appends new FileSpec(AbstractProfile) element to the end of 'this'
      ///	 *  </summary>
      ///	 * <returns> JDFFileSpec newly created child AbstractProfile element </returns>
      ///	 
      public virtual JDFFileSpec appendAbstractProfile()
      {
         JDFFileSpec res = appendFileSpec();
         res.setResourceUsage("AbstractProfile");

         return res;
      }

      ///   
      ///	 <summary> * Gets of 'this' an existing child FileSpec(DeviceLinkProfile) element
      ///	 *  </summary>
      ///	 * <returns> JDFFileSpec the matching DeviceLinkProfile element or null if
      ///	 *         nothing was found </returns>
      ///	 
      public virtual JDFFileSpec getDeviceLinkProfile()
      {
         VElement v = getChildElementVector(ElementName.FILESPEC, null, new JDFAttributeMap(), true, 0, false);

         int siz = v.Count;
         for (int i = 0; i < siz; i++)
         {
            JDFFileSpec res = (JDFFileSpec)v[i];
            if (res.hasAttribute(AttributeName.RESOURCEUSAGE))
            {
               if ("DeviceLinkProfile".Equals(res.getResourceUsage()))
               {
                  return res;
               }
            }
         }

         return null;
      }

      ///   
      ///	 <summary> * Gets of 'this' child FileSpec(DeviceLinkProfile) element, optionally
      ///	 * creates it, if it doesn't exist.
      ///	 *  </summary>
      ///	 * <returns> JDFFileSpec the matching DeviceLinkProfile element </returns>
      ///	 
      public virtual JDFFileSpec getCreateDeviceLinkProfile()
      {
         JDFFileSpec res = getDeviceLinkProfile();
         if (res == null)
         {
            res = appendDeviceLinkProfile();
         }

         return res;
      }

      ///   
      ///	 <summary> * Appends new FileSpec(DeviceLinkProfile) element to the end of 'this'
      ///	 *  </summary>
      ///	 * <returns> JDFFileSpec newly created child DeviceLinkProfile element </returns>
      ///	 
      public virtual JDFFileSpec appendDeviceLinkProfile()
      {
         JDFFileSpec res = appendFileSpec();
         res.setResourceUsage("DeviceLinkProfile");

         return res;
      }
   }
}
