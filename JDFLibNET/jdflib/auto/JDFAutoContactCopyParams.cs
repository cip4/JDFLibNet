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
   using System;
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
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using JDFScreeningParams = org.cip4.jdflib.resource.process.prepress.JDFScreeningParams;

   public abstract class JDFAutoContactCopyParams : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[6];
      static JDFAutoContactCopyParams()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.CONTACTSCREEN, 0x33333331, AttributeInfo.EnumAttributeType.boolean_, null, "false");
         atrInfoTable[1] = new AtrInfoTable(AttributeName.POLARITYCHANGE, 0x33333331, AttributeInfo.EnumAttributeType.boolean_, null, "true");
         atrInfoTable[2] = new AtrInfoTable(AttributeName.REPEATSTEP, 0x33333331, AttributeInfo.EnumAttributeType.XYPair, null, "1 1");
         atrInfoTable[3] = new AtrInfoTable(AttributeName.CYCLE, 0x33333331, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[4] = new AtrInfoTable(AttributeName.DIFFUSION, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumDiffusion.getEnum(0), null);
         atrInfoTable[5] = new AtrInfoTable(AttributeName.VACUUM, 0x33333331, AttributeInfo.EnumAttributeType.double_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.SCREENINGPARAMS, 0x66666661);
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
      ///     <summary> * Constructor for JDFAutoContactCopyParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoContactCopyParams(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoContactCopyParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoContactCopyParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoContactCopyParams </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoContactCopyParams(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoContactCopyParams[  --> " + base.ToString() + " ]";
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
      ///        <summary> * Enumeration strings for Diffusion </summary>
      ///        

      public class EnumDiffusion : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumDiffusion(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumDiffusion getEnum(string enumName)
         {
            return (EnumDiffusion)getEnum(typeof(EnumDiffusion), enumName);
         }

         public static EnumDiffusion getEnum(int enumValue)
         {
            return (EnumDiffusion)getEnum(typeof(EnumDiffusion), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumDiffusion));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumDiffusion));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumDiffusion));
         }

         public static readonly EnumDiffusion On = new EnumDiffusion("On");
         public static readonly EnumDiffusion Off = new EnumDiffusion("Off");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute ContactScreen
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute ContactScreen </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setContactScreen(bool @value)
      {
         setAttribute(AttributeName.CONTACTSCREEN, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute ContactScreen </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getContactScreen()
      {
         return getBoolAttribute(AttributeName.CONTACTSCREEN, null, false);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute PolarityChange
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute PolarityChange </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setPolarityChange(bool @value)
      {
         setAttribute(AttributeName.POLARITYCHANGE, @value, null);
      }

      ///        
      ///          <summary> * (18) get boolean attribute PolarityChange </summary>
      ///          * <returns> boolean the value of the attribute </returns>
      ///          
      public virtual bool getPolarityChange()
      {
         return getBoolAttribute(AttributeName.POLARITYCHANGE, null, true);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute RepeatStep
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute RepeatStep </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setRepeatStep(JDFXYPair @value)
      {
         setAttribute(AttributeName.REPEATSTEP, @value, null);
      }

      ///        
      ///          <summary> * (20) get JDFXYPair attribute RepeatStep </summary>
      ///          * <returns> JDFXYPair the value of the attribute, null if a the
      ///          *         attribute value is not a valid to create a JDFXYPair </returns>
      ///          
      public virtual JDFXYPair getRepeatStep()
      {
         string strAttrName = "";
         JDFXYPair nPlaceHolder = null;
         strAttrName = getAttribute(AttributeName.REPEATSTEP, null, JDFConstants.EMPTYSTRING);
         try
         {
            nPlaceHolder = new JDFXYPair(strAttrName);
         }
         catch (FormatException)
         {
            return null;
         }
         return nPlaceHolder;
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Cycle
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Cycle </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setCycle(int @value)
      {
         setAttribute(AttributeName.CYCLE, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute Cycle </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getCycle()
      {
         return getIntAttribute(AttributeName.CYCLE, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Diffusion
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute Diffusion </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setDiffusion(EnumDiffusion enumVar)
      {
         setAttribute(AttributeName.DIFFUSION, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute Diffusion </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumDiffusion getDiffusion()
      {
         return EnumDiffusion.getEnum(getAttribute(AttributeName.DIFFUSION, null, null));
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute Vacuum
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute Vacuum </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setVacuum(double @value)
      {
         setAttribute(AttributeName.VACUUM, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute Vacuum </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getVacuum()
      {
         return getRealAttribute(AttributeName.VACUUM, null, 0.0);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element ScreeningParams </summary>
      ///     * <returns> JDFScreeningParams the element </returns>
      ///     
      public virtual JDFScreeningParams getScreeningParams()
      {
         return (JDFScreeningParams)getElement(ElementName.SCREENINGPARAMS, null, 0);
      }

      ///     <summary> (25) getCreateScreeningParams
      ///     *  </summary>
      ///     * <returns> JDFScreeningParams the element </returns>
      ///     
      public virtual JDFScreeningParams getCreateScreeningParams()
      {
         return (JDFScreeningParams)getCreateElement_KElement(ElementName.SCREENINGPARAMS, null, 0);
      }

      ///    
      ///     <summary> * (29) append element ScreeningParams </summary>
      ///     
      public virtual JDFScreeningParams appendScreeningParams()
      {
         return (JDFScreeningParams)appendElementN(ElementName.SCREENINGPARAMS, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refScreeningParams(JDFScreeningParams refTarget)
      {
         refElement(refTarget);
      }
   }
}
