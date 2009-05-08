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



/* ==========================================================================
 * class JDFColorCorrectionParams extends JDFResource
 * ==========================================================================
 * @COPYRIGHT Heidelberger Druckmaschinen AG, 1999-2001 ALL RIGHTS RESERVED
 * @Author: sabjon@topmail.de    using a code generator 
 * Warning! very preliminary test version. 
 * Interface subject to change without prior notice!  */


namespace org.cip4.jdflib.resource.process.prepress
{


   using JDFAutoColorCorrectionParams = org.cip4.jdflib.auto.JDFAutoColorCorrectionParams;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using VElement = org.cip4.jdflib.core.VElement;
   using JDFFileSpec = org.cip4.jdflib.resource.process.JDFFileSpec;

   public class JDFColorCorrectionParams : JDFAutoColorCorrectionParams
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFColorCorrectionParams
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFColorCorrectionParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFColorCorrectionParams
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFColorCorrectionParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFColorCorrectionParams
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="localName"> </param>
      ///	 
      public JDFColorCorrectionParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      public override string ToString()
      {
         return "JDFColorCorrectionParams[  --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * Gets of 'this' an existing child FileSpec(FinalTargetDevice) element
      ///	 *  </summary>
      ///	 * <returns> JDFFileSpec the matching FinalTargetDevice element or null if
      ///	 *         nothing was found </returns>
      ///	 
      public virtual JDFFileSpec getFinalTargetDevice()
      {
         VElement v = getChildElementVector(ElementName.FILESPEC, null, null, true, 0, false);
         int siz = v.Count;
         for (int i = 0; i < siz; i++)
         {
            JDFFileSpec res = (JDFFileSpec)v[i];
            if (res.hasAttribute(AttributeName.RESOURCEUSAGE))
            {
               if ("FinalTargetDevice".Equals(res.getResourceUsage()))
               {
                  return res;
               }
            }
         }

         return null;
      }

      ///   
      ///	 <summary> * Gets of 'this' child FileSpec(FinalTargetDevice) element, optionally
      ///	 * creates it, if it doesn't exist.
      ///	 *  </summary>
      ///	 * <returns> JDFFileSpec: the matching FinalTargetDevice element </returns>
      ///	 
      public virtual JDFFileSpec getCreateFinalTargetDevice()
      {
         JDFFileSpec res = getFinalTargetDevice();
         if (res == null)
         {
            res = appendFinalTargetDevice();
         }

         return res;
      }

      ///   
      ///	 <summary> * Appends new FileSpec(FinalTargetDevice) element to the end of 'this'
      ///	 *  </summary>
      ///	 * <returns> JDFFileSpec: newly created child FinalTargetDevice element </returns>
      ///	 
      public virtual JDFFileSpec appendFinalTargetDevice()
      {
         JDFFileSpec res = appendFileSpec();
         res.setResourceUsage("FinalTargetDevice");

         return res;
      }

      ///   
      ///	 <summary> * Gets of 'this' an existing child FileSpec(WorkingColorSpace) element
      ///	 *  </summary>
      ///	 * <returns> JDFFileSpec: the matching WorkingColorSpace element </returns>
      ///	 
      public virtual JDFFileSpec getWorkingColorSpace()
      {
         VElement v = getChildElementVector(ElementName.FILESPEC, null, null, true, 0, false);
         int siz = v.Count;
         for (int i = 0; i < siz; i++)
         {
            JDFFileSpec res = (JDFFileSpec)v[i];
            if (res.hasAttribute(AttributeName.RESOURCEUSAGE))
            {
               if ("WorkingColorSpace".Equals(res.getResourceUsage()))
               {
                  return res;
               }
            }
         }

         return null;
      }

      ///   
      ///	 <summary> * Gets of 'this' child FileSpec(WorkingColorSpace) element, optionally
      ///	 * creates it, if it doesn't exist.
      ///	 *  </summary>
      ///	 * <returns> JDFFileSpec: the matching WorkingColorSpace element </returns>
      ///	 
      public virtual JDFFileSpec getCreateWorkingColorSpace()
      {
         JDFFileSpec res = getWorkingColorSpace();
         if (res == null)
         {
            res = appendWorkingColorSpace();
         }

         return res;
      }

      ///   
      ///	 <summary> * Appends new FileSpec(WorkingColorSpace) element to the end of 'this'
      ///	 *  </summary>
      ///	 * <returns> JDFFileSpec: newly created child WorkingColorSpace element </returns>
      ///	 
      public virtual JDFFileSpec appendWorkingColorSpace()
      {
         JDFFileSpec res = appendFileSpec();
         res.setResourceUsage("WorkingColorSpace");

         return res;
      }
   }
}
