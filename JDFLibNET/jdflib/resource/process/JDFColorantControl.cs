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
 *
 * JDFColorantControl.cs
 *
 * Last changes
 */

namespace org.cip4.jdflib.resource.process
{
   using System.Collections;
   using System.Collections.Generic;


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   using JDFAutoColorantControl = org.cip4.jdflib.auto.JDFAutoColorantControl;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFSeparationList = org.cip4.jdflib.core.JDFSeparationList;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;


   public class JDFColorantControl : JDFAutoColorantControl
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFColorantControl
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFColorantControl(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFColorantControl
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFColorantControl(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFColorantControl
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="localName"> </param>

      ///	 
      public JDFColorantControl(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
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
         return "JDFColorantControl[  --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * get a list of all partition keys that this resource may be implicitly
      ///	 * partitioned by e.g. RunIndex for RunList...
      ///	 *  </summary>
      ///	 * <returns> vector of EnumPartIDKey </returns>
      ///	 

      public override List<ValuedEnum> getImplicitPartitions()
      {
         List<ValuedEnum> v = base.getImplicitPartitions();
         if (v == null)
            v = new List<ValuedEnum>();
         v.Add(EnumPartIDKey.Separation);
         return v;
      }

      public virtual VString getDeviceColorantOrderSeparations()
      {
         if (hasChildElement(ElementName.DEVICECOLORANTORDER, null))
            return base.getDeviceColorantOrder().getSeparations();
         return getColorantOrderSeparations();
      }

      ///   
      ///	 <summary> * 
      ///	 * @return </summary>
      ///	 
      public virtual VString getColorantOrderSeparations()
      {
         if (hasChildElement(ElementName.COLORANTORDER, null))
            return base.getColorantOrder().getSeparations();
         return getSeparations();
      }

      ///   
      ///	 <summary> * get the list of separations that this colorantcontrol describes adds the
      ///	 * separations that are implied by ProcessColorModel
      ///	 *  </summary>
      ///	 * <returns> VString the complete list of process and spot colors </returns>
      ///	 
      public virtual VString getAllSeparations()
      {
         VElement e = getLeaves(false);
         if (e == null)
            return null;
         VString allCols = new VString();
         for (int i = 0; i < e.Count; i++)
         {
            allCols.addAll(((JDFColorantControl)e[i]).getSeparations());
         }
         allCols.unify();
         return allCols;
      }

      ///   
      ///	 <summary> * get the list of separations that this colorantcontrol describes adds the
      ///	 * separations that are implied by ProcessColorModel
      ///	 *  </summary>
      ///	 * <returns> VString the complete list of process and spot colors </returns>
      ///	 
      public virtual VString getSeparations()
      {
         VString vName = new VString();
         string model = getProcessColorModel();
         if ("DeviceCMY".Equals(model))
         {
            vName.Add("Cyan");
            vName.Add("Magenta");
            vName.Add("Yellow");
         }
         else if ("DeviceCMYK".Equals(model))
         {
            vName.Add("Cyan");
            vName.Add("Magenta");
            vName.Add("Yellow");
            vName.Add("Black");
         }
         else if ("DeviceGray".Equals(model))
         {
            vName.Add("Black");
         }
         else if ("DeviceRGB".Equals(model))
         {
            vName.Add("Red");
            vName.Add("Green");
            vName.Add("Blue");
         }
         else if ("DeviceN".Equals(model))
         {
            vName = getDeviceNSpace(0).getSeparations();
         }

         JDFSeparationList colpar = getColorantParams();
         if (colpar != null)
         {
            vName.appendUnique(colpar.getSeparations());
         }
         vName.unify();
         return vName;
      }

      ///   
      ///	 <summary> * always reuse a colorpool </summary>
      ///	 
      public override JDFColorPool getCreateColorPool()
      {
         JDFColorPool cp = getColorPool();
         return cp == null ? base.getCreateColorPool() : cp;
      }
   }
}
