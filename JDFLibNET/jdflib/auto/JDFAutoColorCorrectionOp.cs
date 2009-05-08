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
   using System.Collections.Generic;


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFFileSpec = org.cip4.jdflib.resource.process.JDFFileSpec;

   public abstract class JDFAutoColorCorrectionOp : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[8];
      static JDFAutoColorCorrectionOp()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.SOURCEOBJECTS, 0x33333333, AttributeInfo.EnumAttributeType.enumerations, EnumSourceObjects.getEnum(0), "All");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.ADJUSTCYANRED, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[2] = new AtrInfoTable(AttributeName.ADJUSTMAGENTAGREEN, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[3] = new AtrInfoTable(AttributeName.ADJUSTYELLOWBLUE, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.ADJUSTCONTRAST, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.ADJUSTHUE, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[6] = new AtrInfoTable(AttributeName.ADJUSTLIGHTNESS, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable[7] = new AtrInfoTable(AttributeName.ADJUSTSATURATION, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.FILESPEC, 0x33333311);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[1];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoColorCorrectionOp </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoColorCorrectionOp(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoColorCorrectionOp </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoColorCorrectionOp(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoColorCorrectionOp </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoColorCorrectionOp(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoColorCorrectionOp[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for SourceObjects </summary>
      ///        

      public class EnumSourceObjects : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumSourceObjects(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumSourceObjects getEnum(string enumName)
         {
            return (EnumSourceObjects)getEnum(typeof(EnumSourceObjects), enumName);
         }

         public static EnumSourceObjects getEnum(int enumValue)
         {
            return (EnumSourceObjects)getEnum(typeof(EnumSourceObjects), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumSourceObjects));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumSourceObjects));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumSourceObjects));
         }

         public static readonly EnumSourceObjects All = new EnumSourceObjects("All");
         public static readonly EnumSourceObjects ImagePhotographic = new EnumSourceObjects("ImagePhotographic");
         public static readonly EnumSourceObjects ImageScreenShot = new EnumSourceObjects("ImageScreenShot");
         public static readonly EnumSourceObjects Text = new EnumSourceObjects("Text");
         public static readonly EnumSourceObjects LineArt = new EnumSourceObjects("LineArt");
         public static readonly EnumSourceObjects SmoothShades = new EnumSourceObjects("SmoothShades");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute SourceObjects
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5.2) set attribute SourceObjects </summary>
      ///          * <param name="v"> vector of the enumeration values </param>
      ///          
      public virtual void setSourceObjects(List<ValuedEnum> v)
      {
         setEnumerationsAttribute(AttributeName.SOURCEOBJECTS, v, null);
      }

      ///        
      ///          <summary> * (9.2) get SourceObjects attribute SourceObjects </summary>
      ///          * <returns> Vector of the enumerations </returns>
      ///          
      public virtual List<ValuedEnum> getSourceObjects()
      {
         return getEnumerationsAttribute(AttributeName.SOURCEOBJECTS, null, EnumSourceObjects.All, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute AdjustCyanRed
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute AdjustCyanRed </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAdjustCyanRed(double @value)
      {
         setAttribute(AttributeName.ADJUSTCYANRED, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute AdjustCyanRed </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getAdjustCyanRed()
      {
         return getRealAttribute(AttributeName.ADJUSTCYANRED, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute AdjustMagentaGreen
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute AdjustMagentaGreen </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAdjustMagentaGreen(double @value)
      {
         setAttribute(AttributeName.ADJUSTMAGENTAGREEN, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute AdjustMagentaGreen </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getAdjustMagentaGreen()
      {
         return getRealAttribute(AttributeName.ADJUSTMAGENTAGREEN, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute AdjustYellowBlue
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute AdjustYellowBlue </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAdjustYellowBlue(double @value)
      {
         setAttribute(AttributeName.ADJUSTYELLOWBLUE, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute AdjustYellowBlue </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getAdjustYellowBlue()
      {
         return getRealAttribute(AttributeName.ADJUSTYELLOWBLUE, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute AdjustContrast
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute AdjustContrast </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAdjustContrast(double @value)
      {
         setAttribute(AttributeName.ADJUSTCONTRAST, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute AdjustContrast </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getAdjustContrast()
      {
         return getRealAttribute(AttributeName.ADJUSTCONTRAST, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute AdjustHue
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute AdjustHue </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAdjustHue(double @value)
      {
         setAttribute(AttributeName.ADJUSTHUE, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute AdjustHue </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getAdjustHue()
      {
         return getRealAttribute(AttributeName.ADJUSTHUE, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute AdjustLightness
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute AdjustLightness </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAdjustLightness(double @value)
      {
         setAttribute(AttributeName.ADJUSTLIGHTNESS, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute AdjustLightness </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getAdjustLightness()
      {
         return getRealAttribute(AttributeName.ADJUSTLIGHTNESS, null, 0.0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute AdjustSaturation
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute AdjustSaturation </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setAdjustSaturation(double @value)
      {
         setAttribute(AttributeName.ADJUSTSATURATION, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute AdjustSaturation </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getAdjustSaturation()
      {
         return getRealAttribute(AttributeName.ADJUSTSATURATION, null, 0.0);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateFileSpec
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFFileSpec the element </returns>
      ///     
      public virtual JDFFileSpec getCreateFileSpec(int iSkip)
      {
         return (JDFFileSpec)getCreateElement_KElement(ElementName.FILESPEC, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element FileSpec </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFFileSpec the element </returns>
      ///     * default is getFileSpec(0)     
      public virtual JDFFileSpec getFileSpec(int iSkip)
      {
         return (JDFFileSpec)getElement(ElementName.FILESPEC, null, iSkip);
      }

      ///    
      ///     <summary> * Get all FileSpec from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFFileSpec> </returns>
      ///     
      public virtual ICollection<JDFFileSpec> getAllFileSpec()
      {
         List<JDFFileSpec> v = new List<JDFFileSpec>();

         JDFFileSpec kElem = (JDFFileSpec)getFirstChildElement(ElementName.FILESPEC, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFFileSpec)kElem.getNextSiblingElement(ElementName.FILESPEC, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element FileSpec </summary>
      ///     
      public virtual JDFFileSpec appendFileSpec()
      {
         return (JDFFileSpec)appendElement(ElementName.FILESPEC, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refFileSpec(JDFFileSpec refTarget)
      {
         refElement(refTarget);
      }
   }
}
