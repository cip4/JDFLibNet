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
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFGlueApplication = org.cip4.jdflib.resource.process.postpress.JDFGlueApplication;
   using JDFGlueLine = org.cip4.jdflib.resource.process.postpress.JDFGlueLine;

   public abstract class JDFAutoGlue : JDFElement
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[1];
      static JDFAutoGlue()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.WORKINGDIRECTION, 0x22222222, AttributeInfo.EnumAttributeType.enumeration, EnumWorkingDirection.getEnum(0), null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.GLUEAPPLICATION, 0x66666666);
         elemInfoTable[1] = new ElemInfoTable(ElementName.GLUELINE, 0x66666111);
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
      ///     <summary> * Constructor for JDFAutoGlue </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoGlue(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoGlue </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoGlue(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoGlue </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoGlue(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoGlue[  --> " + base.ToString() + " ]";
      }


      ///        
      ///        <summary> * Enumeration strings for WorkingDirection </summary>
      ///        

      public class EnumWorkingDirection : ValuedEnum
      {
         private const long serialVersionUID = 1L;
         private static int m_startValue = 0;

         private EnumWorkingDirection(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumWorkingDirection getEnum(string enumName)
         {
            return (EnumWorkingDirection)getEnum(typeof(EnumWorkingDirection), enumName);
         }

         public static EnumWorkingDirection getEnum(int enumValue)
         {
            return (EnumWorkingDirection)getEnum(typeof(EnumWorkingDirection), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumWorkingDirection));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumWorkingDirection));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumWorkingDirection));
         }

         public static readonly EnumWorkingDirection Top = new EnumWorkingDirection("Top");
         public static readonly EnumWorkingDirection Bottom = new EnumWorkingDirection("Bottom");
      }



      // ************************************************************************
      // * Attribute getter / setter
      // * ************************************************************************
      // 

      //         ---------------------------------------------------------------------
      //        Methods for Attribute WorkingDirection
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (5) set attribute WorkingDirection </summary>
      ///          * <param name="enumVar">: the enumVar to set the attribute to </param>
      ///          
      public virtual void setWorkingDirection(EnumWorkingDirection enumVar)
      {
         setAttribute(AttributeName.WORKINGDIRECTION, enumVar == null ? null : enumVar.getName(), null);
      }

      ///        
      ///          <summary> * (9) get attribute WorkingDirection </summary>
      ///          * <returns> the value of the attribute </returns>
      ///          
      public virtual EnumWorkingDirection getWorkingDirection()
      {
         return EnumWorkingDirection.getEnum(getAttribute(AttributeName.WORKINGDIRECTION, null, null));
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///    
      ///     <summary> * (24) const get element GlueApplication </summary>
      ///     * <returns> JDFGlueApplication the element </returns>
      ///     
      public virtual JDFGlueApplication getGlueApplication()
      {
         return (JDFGlueApplication)getElement(ElementName.GLUEAPPLICATION, null, 0);
      }

      ///     <summary> (25) getCreateGlueApplication
      ///     *  </summary>
      ///     * <returns> JDFGlueApplication the element </returns>
      ///     
      public virtual JDFGlueApplication getCreateGlueApplication()
      {
         return (JDFGlueApplication)getCreateElement_KElement(ElementName.GLUEAPPLICATION, null, 0);
      }

      ///    
      ///     <summary> * (29) append element GlueApplication </summary>
      ///     
      public virtual JDFGlueApplication appendGlueApplication()
      {
         return (JDFGlueApplication)appendElementN(ElementName.GLUEAPPLICATION, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refGlueApplication(JDFGlueApplication refTarget)
      {
         refElement(refTarget);
      }

      ///    
      ///     <summary> * (24) const get element GlueLine </summary>
      ///     * <returns> JDFGlueLine the element </returns>
      ///     
      public virtual JDFGlueLine getGlueLine()
      {
         return (JDFGlueLine)getElement(ElementName.GLUELINE, null, 0);
      }

      ///     <summary> (25) getCreateGlueLine
      ///     *  </summary>
      ///     * <returns> JDFGlueLine the element </returns>
      ///     
      public virtual JDFGlueLine getCreateGlueLine()
      {
         return (JDFGlueLine)getCreateElement_KElement(ElementName.GLUELINE, null, 0);
      }

      ///    
      ///     <summary> * (29) append element GlueLine </summary>
      ///     
      public virtual JDFGlueLine appendGlueLine()
      {
         return (JDFGlueLine)appendElementN(ElementName.GLUELINE, 1, null);
      }

      ///    
      ///      <summary> * (31) create inter-resource link to refTarget </summary>
      ///      * <param name="refTarget"> the element that is referenced </param>
      ///      
      public virtual void refGlueLine(JDFGlueLine refTarget)
      {
         refElement(refTarget);
      }
   }
}
