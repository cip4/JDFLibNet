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




namespace org.cip4.jdflib.auto
{
   using System.Collections.Generic;



   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFCylinderPosition = org.cip4.jdflib.resource.process.JDFCylinderPosition;
   using JDFLayout = org.cip4.jdflib.resource.process.JDFLayout;

   public abstract class JDFAutoCylinderLayout : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[1];
      static JDFAutoCylinderLayout()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.DEVICEID, 0x33333111, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.LAYOUT, 0x66666111);
         elemInfoTable[1] = new ElemInfoTable(ElementName.CYLINDERPOSITION, 0x22222111);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[2];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoCylinderLayout </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoCylinderLayout(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoCylinderLayout </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoCylinderLayout(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoCylinderLayout </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoCylinderLayout(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoCylinderLayout[  --> " + base.ToString() + " ]";
      }


      public override bool init()
      {
         bool bRet = base.init();
         setResourceClass(JDFResource.EnumResourceClass.Parameter);
         return bRet;
      }


      public override EnumResourceClass getValidClass()
      {
         return JDFResource.EnumResourceClass.Parameter;
      }


      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute DeviceID
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute DeviceID </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setDeviceID(string @value)
      {
         setAttribute(AttributeName.DEVICEID, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute DeviceID </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getDeviceID()
      {
         return getAttribute(AttributeName.DEVICEID, null, JDFConstants.EMPTYSTRING);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element Layout </summary>
      ///     * <returns> JDFLayout the element </returns>
      ///     
      public virtual JDFLayout getLayout()
      {
         return (JDFLayout)getElement(ElementName.LAYOUT, null, 0);
      }

      ///     <summary> (25) getCreateLayout
      ///     *  </summary>
      ///     * <returns> JDFLayout the element </returns>
      ///     
      public virtual JDFLayout getCreateLayout()
      {
         return (JDFLayout)getCreateElement_KElement(ElementName.LAYOUT, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Layout </summary>
      ///     
      public virtual JDFLayout appendLayout()
      {
         return (JDFLayout)appendElementN(ElementName.LAYOUT, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refLayout(JDFLayout refTarget)
      {
         refElement(refTarget);
      }

      ///     <summary> (26) getCreateCylinderPosition
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFCylinderPosition the element </returns>
      ///     
      public virtual JDFCylinderPosition getCreateCylinderPosition(int iSkip)
      {
         return (JDFCylinderPosition)getCreateElement_KElement(ElementName.CYLINDERPOSITION, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element CylinderPosition </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFCylinderPosition the element </returns>
      ///     * default is getCylinderPosition(0)     
      public virtual JDFCylinderPosition getCylinderPosition(int iSkip)
      {
         return (JDFCylinderPosition)getElement(ElementName.CYLINDERPOSITION, null, iSkip);
      }

      ///    
      ///     <summary> * Get all CylinderPosition from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFCylinderPosition> </returns>
      ///     
      public virtual ICollection<JDFCylinderPosition> getAllCylinderPosition()
      {
         List<JDFCylinderPosition> v = new List<JDFCylinderPosition>();

         JDFCylinderPosition kElem = (JDFCylinderPosition)getFirstChildElement(ElementName.CYLINDERPOSITION, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFCylinderPosition)kElem.getNextSiblingElement(ElementName.CYLINDERPOSITION, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element CylinderPosition </summary>
      ///     
      public virtual JDFCylinderPosition appendCylinderPosition()
      {
         return (JDFCylinderPosition)appendElement(ElementName.CYLINDERPOSITION, null);
      }
   }
}
