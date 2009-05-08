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
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFAdded = org.cip4.jdflib.jmf.JDFAdded;
   using JDFChangedPath = org.cip4.jdflib.jmf.JDFChangedPath;
   using JDFChangedAttribute = org.cip4.jdflib.resource.JDFChangedAttribute;
   using JDFRemoved = org.cip4.jdflib.resource.JDFRemoved;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;

   public abstract class JDFAutoTrigger : JDFResource
   {

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[2];
      static JDFAutoTrigger()
      {
         atrInfoTable[0] = new AtrInfoTable(AttributeName.REPEATSTEP, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, null);
         atrInfoTable[1] = new AtrInfoTable(AttributeName.REPEATTIME, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.CHANGEDATTRIBUTE, 0x44444433);
         elemInfoTable[1] = new ElemInfoTable(ElementName.ADDED, 0x77777766);
         elemInfoTable[2] = new ElemInfoTable(ElementName.CHANGEDPATH, 0x33333311);
         elemInfoTable[3] = new ElemInfoTable(ElementName.REMOVED, 0x77777766);
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }


      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[4];

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateReplace(elemInfoTable);
      }



      ///    
      ///     <summary> * Constructor for JDFAutoTrigger </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoTrigger(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoTrigger </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     
      protected internal JDFAutoTrigger(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///    
      ///     <summary> * Constructor for JDFAutoTrigger </summary>
      ///     * <param name="myOwnerDocument"> </param>
      ///     * <param name="myNamespaceURI"> </param>
      ///     * <param name="qualifiedName"> </param>
      ///     * <param name="myLocalName"> </param>
      ///     
      protected internal JDFAutoTrigger(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }


      public override string ToString()
      {
         return " JDFAutoTrigger[  --> " + base.ToString() + " ]";
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
      //        Methods for Attribute RepeatStep
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute RepeatStep </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setRepeatStep(int @value)
      {
         setAttribute(AttributeName.REPEATSTEP, @value, null);
      }

      ///        
      ///          <summary> * (15) get int attribute RepeatStep </summary>
      ///          * <returns> int the value of the attribute </returns>
      ///          
      public virtual int getRepeatStep()
      {
         return getIntAttribute(AttributeName.REPEATSTEP, null, 0);
      }


      //         ---------------------------------------------------------------------
      //        Methods for Attribute RepeatTime
      //        --------------------------------------------------------------------- 
      ///        
      ///          <summary> * (36) set attribute RepeatTime </summary>
      ///          * <param name="value">: the value to set the attribute to </param>
      ///          
      public virtual void setRepeatTime(double @value)
      {
         setAttribute(AttributeName.REPEATTIME, @value, null);
      }

      ///        
      ///          <summary> * (17) get double attribute RepeatTime </summary>
      ///          * <returns> double the value of the attribute </returns>
      ///          
      public virtual double getRepeatTime()
      {
         return getRealAttribute(AttributeName.REPEATTIME, null, 0.0);
      }

      // ***********************************************************************
      // * Element getter / setter
      // * ***********************************************************************
      // 

      ///     <summary> (26) getCreateChangedAttribute
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFChangedAttribute the element </returns>
      ///     
      public virtual JDFChangedAttribute getCreateChangedAttribute(int iSkip)
      {
         return (JDFChangedAttribute)getCreateElement_KElement(ElementName.CHANGEDATTRIBUTE, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element ChangedAttribute </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFChangedAttribute the element </returns>
      ///     * default is getChangedAttribute(0)     
      public virtual JDFChangedAttribute getChangedAttribute(int iSkip)
      {
         return (JDFChangedAttribute)getElement(ElementName.CHANGEDATTRIBUTE, null, iSkip);
      }

      ///    
      ///     <summary> * Get all ChangedAttribute from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFChangedAttribute> </returns>
      ///     
      public virtual ICollection<JDFChangedAttribute> getAllChangedAttribute()
      {
         List<JDFChangedAttribute> v = new List<JDFChangedAttribute>();

         JDFChangedAttribute kElem = (JDFChangedAttribute)getFirstChildElement(ElementName.CHANGEDATTRIBUTE, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFChangedAttribute)kElem.getNextSiblingElement(ElementName.CHANGEDATTRIBUTE, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element ChangedAttribute </summary>
      ///     
      public virtual JDFChangedAttribute appendChangedAttribute()
      {
         return (JDFChangedAttribute)appendElement(ElementName.CHANGEDATTRIBUTE, null);
      }

      ///    
      ///     <summary> * (24) const get element Added </summary>
      ///     * <returns> JDFAdded the element </returns>
      ///     
      public virtual JDFAdded getAdded()
      {
         return (JDFAdded)getElement(ElementName.ADDED, null, 0);
      }

      ///     <summary> (25) getCreateAdded
      ///     *  </summary>
      ///     * <returns> JDFAdded the element </returns>
      ///     
      public virtual JDFAdded getCreateAdded()
      {
         return (JDFAdded)getCreateElement_KElement(ElementName.ADDED, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Added </summary>
      ///     
      public virtual JDFAdded appendAdded()
      {
         return (JDFAdded)appendElementN(ElementName.ADDED, 1, null);
      }

      ///     <summary> (26) getCreateChangedPath
      ///     *  </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFChangedPath the element </returns>
      ///     
      public virtual JDFChangedPath getCreateChangedPath(int iSkip)
      {
         return (JDFChangedPath)getCreateElement_KElement(ElementName.CHANGEDPATH, null, iSkip);
      }

      ///    
      ///     <summary> * (27) const get element ChangedPath </summary>
      ///     * <param name="iSkip"> number of elements to skip </param>
      ///     * <returns> JDFChangedPath the element </returns>
      ///     * default is getChangedPath(0)     
      public virtual JDFChangedPath getChangedPath(int iSkip)
      {
         return (JDFChangedPath)getElement(ElementName.CHANGEDPATH, null, iSkip);
      }

      ///    
      ///     <summary> * Get all ChangedPath from the current element
      ///     *  </summary>
      ///     * <returns> Collection<JDFChangedPath> </returns>
      ///     
      public virtual ICollection<JDFChangedPath> getAllChangedPath()
      {
         List<JDFChangedPath> v = new List<JDFChangedPath>();

         JDFChangedPath kElem = (JDFChangedPath)getFirstChildElement(ElementName.CHANGEDPATH, null);

         while (kElem != null)
         {
            v.Add(kElem);

            kElem = (JDFChangedPath)kElem.getNextSiblingElement(ElementName.CHANGEDPATH, null);
         }

         return v;
      }

      ///    
      ///     <summary> * (30) append element ChangedPath </summary>
      ///     
      public virtual JDFChangedPath appendChangedPath()
      {
         return (JDFChangedPath)appendElement(ElementName.CHANGEDPATH, null);
      }

      ///    
      ///     <summary> * (24) const get element Removed </summary>
      ///     * <returns> JDFRemoved the element </returns>
      ///     
      public virtual JDFRemoved getRemoved()
      {
         return (JDFRemoved)getElement(ElementName.REMOVED, null, 0);
      }

      ///     <summary> (25) getCreateRemoved
      ///     *  </summary>
      ///     * <returns> JDFRemoved the element </returns>
      ///     
      public virtual JDFRemoved getCreateRemoved()
      {
         return (JDFRemoved)getCreateElement_KElement(ElementName.REMOVED, null, 0);
      }

      ///    
      ///     <summary> * (29) append element Removed </summary>
      ///     
      public virtual JDFRemoved appendRemoved()
      {
         return (JDFRemoved)appendElementN(ElementName.REMOVED, 1, null);
      }
   }
}
