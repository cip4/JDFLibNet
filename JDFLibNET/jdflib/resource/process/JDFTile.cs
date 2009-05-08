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
 * class JDFTile extends JDFResource
 * ==========================================================================
 * @COPYRIGHT Heidelberger Druckmaschinen AG, 1999-2001 ALL RIGHTS RESERVED
 * @Author: sabjon@topmail.de    using a code generator 
 * Warning! very preliminary test version. 
 * Interface subject to change without prior notice!  */


namespace org.cip4.jdflib.resource.process
{


   using JDFAutoTile = org.cip4.jdflib.auto.JDFAutoTile;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFMarkObject = org.cip4.jdflib.resource.JDFMarkObject;


   ///
   /// <summary> * JDFTile provides utilities for the Tile resource
   /// * 
   /// * @author prosirai
   /// *  </summary>
   /// 
   public class JDFTile : JDFAutoTile
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFTile
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFTile(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFTile
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFTile(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFTile
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="localName"> </param>

      ///	 
      public JDFTile(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      public override string ToString()
      {
         return "JDFTile[  --> " + base.ToString() + " ]";
      }

      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[1];
      static JDFTile()
      {
         elemInfoTable[0] = new ElemInfoTable(ElementName.MARKOBJECT, 0x33331111);
      }

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }

      ///   
      ///	 <summary> * (26) getCreateMarkObject note that this is prerelease for JDF1.4
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            number of elements to skip </param>
      ///	 * <returns> JDFMarkObject the element </returns>
      ///	 
      // TODO remove when in auto files
      public virtual JDFMarkObject getCreateMarkObject(int iSkip)
      {
         return (JDFMarkObject)getCreateElement_KElement(ElementName.MARKOBJECT, null, iSkip);
      }

      ///   
      ///	 <summary> * (27) const get element MarkObject
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            number of elements to skip </param>
      ///	 * <returns> JDFMarkObject the element default is getMarkObject(0) note that
      ///	 *         this is prerelease for JDF1.4 </returns>
      ///	 
      public virtual JDFMarkObject getMarkObject(int iSkip)
      {
         return (JDFMarkObject)getElement(ElementName.MARKOBJECT, null, iSkip);
      }

      ///   
      ///	 <summary> * const append element MarkObject
      ///	 *  </summary>
      ///	 * <param name="iSkip">
      ///	 *            number of elements to skip </param>
      ///	 * <returns> JDFMarkObject the element default is getMarkObject(0) note that
      ///	 *         this is prerelease for JDF1.4 </returns>
      ///	 
      public virtual JDFMarkObject appendMarkObject()
      {
         return (JDFMarkObject)appendElement(ElementName.MARKOBJECT, null);
      }
   }
}
