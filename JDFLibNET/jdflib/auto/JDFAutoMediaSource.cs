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
   using System.Collections;


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFComponent = org.cip4.jdflib.resource.process.JDFComponent;
   using JDFMedia = org.cip4.jdflib.resource.process.JDFMedia;

   public abstract class JDFAutoMediaSource : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[4];
      static JDFAutoMediaSource()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.MANUALFEED, 0x44444443, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.LEADINGEDGE, 0x44444443, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.MEDIALOCATION, 0x44444443, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.SHEETLAY, 0x44444443, AttributeInfo.EnumAttributeType.enumeration, EnumSheetLay.getEnum(0), null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.MEDIA, 0x77777776);
         elemInfoTable[1] = new ElemInfoTable(ElementName.COMPONENT, 0x77777776);
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
      ///     <summary> * Constructor for JDFAutoMediaSource </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoMediaSource(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoMediaSource </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoMediaSource(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoMediaSource </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoMediaSource(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoMediaSource[  --> " + base.ToString() + " ]";
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


      ///        
      ///        <summary> * Enumeration strings for SheetLay </summary>
      ///        

      public class EnumSheetLay : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumSheetLay(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumSheetLay getEnum(string enumName)
         {
            return (EnumSheetLay)getEnum(typeof(EnumSheetLay), enumName);
         }

         public static EnumSheetLay getEnum(int enumValue)
         {
            return (EnumSheetLay)getEnum(typeof(EnumSheetLay), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumSheetLay));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumSheetLay));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumSheetLay));
         }

         public static readonly EnumSheetLay Left = new EnumSheetLay("Left");
         public static readonly EnumSheetLay Right = new EnumSheetLay("Right");
         public static readonly EnumSheetLay Center = new EnumSheetLay("Center");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute ManualFeed
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ManualFeed </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setManualFeed(bool @value)
      {
         setAttribute(AttributeName.MANUALFEED, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute ManualFeed </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getManualFeed()
      {
         return getBoolAttribute(AttributeName.MANUALFEED, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute LeadingEdge
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute LeadingEdge </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setLeadingEdge(double @value)
      {
         setAttribute(AttributeName.LEADINGEDGE, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute LeadingEdge </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getLeadingEdge()
      {
         return getRealAttribute(AttributeName.LEADINGEDGE, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute MediaLocation
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute MediaLocation </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setMediaLocation(string @value)
      {
         setAttribute(AttributeName.MEDIALOCATION, @value, null);
      }

      ///        
      ///          <summary> * (23) get String attribute MediaLocation </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual string getMediaLocation()
      {
         return getAttribute(AttributeName.MEDIALOCATION, null, JDFConstants.EMPTYSTRING);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute SheetLay
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute SheetLay </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setSheetLay(EnumSheetLay enumVar)
      {
         setAttribute(AttributeName.SHEETLAY, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute SheetLay </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumSheetLay getSheetLay()
      {
         return EnumSheetLay.getEnum(getAttribute(AttributeName.SHEETLAY, null, null));
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element Media </summary>
      ///     * <returns> JDFMedia the element </returns>
      ///     
      public virtual JDFMedia getMedia()
      {
         return (JDFMedia)getElement(ElementName.MEDIA, null, 0);
      }

      ///     <summary> (25) getCreateMedia
      ///     *  </summary>
      ///     * <returns> JDFMedia the element </returns>
      ///     
      public virtual JDFMedia getCreateMedia()
      {
         return (JDFMedia)getCreateElement_KElement(ElementName.MEDIA, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Media </summary>
      ///     
      public virtual JDFMedia appendMedia()
      {
         return (JDFMedia)appendElementN(ElementName.MEDIA, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refMedia(JDFMedia refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element Component </summary>
      ///     * <returns> JDFComponent the element </returns>
      ///     
      public virtual JDFComponent getComponent()
      {
         return (JDFComponent)getElement(ElementName.COMPONENT, null, 0);
      }

      ///     <summary> (25) getCreateComponent
      ///     *  </summary>
      ///     * <returns> JDFComponent the element </returns>
      ///     
      public virtual JDFComponent getCreateComponent()
      {
         return (JDFComponent)getCreateElement_KElement(ElementName.COMPONENT, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Component </summary>
      ///     
      public virtual JDFComponent appendComponent()
      {
         return (JDFComponent)appendElementN(ElementName.COMPONENT, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refComponent(JDFComponent refTarget)
      {
         refElement(refTarget);
      }
   }
}
