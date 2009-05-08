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





/* Copyright (c) 2001 Heidelberger Druckmaschinen AG, All Rights Reserved.
 * 
 * @author Elena Skobchenko
 *
 * JDFModulePool.cs
 */

namespace org.cip4.jdflib.resource.devicecapability
{
   using System.Collections;



   using JDFAutoModulePool = org.cip4.jdflib.auto.JDFAutoModulePool;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using ICapabilityElement = org.cip4.jdflib.ifaces.ICapabilityElement;
   using EnumAvailability = org.cip4.jdflib.resource.devicecapability.JDFDeviceCap.EnumAvailability;

   public class JDFModulePool : JDFAutoModulePool
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFModulePool
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFModulePool(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFModulePool
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFModulePool(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFModulePool
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFModulePool(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      ///   
      ///	 <summary> * toString
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public override string ToString()
      {
         return "JDFModulePool[  --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * get the minimum availability
      ///	 *  </summary>
      ///	 * <param name="vModuleRefs">
      ///	 *            the list of module ids that are evaluated </param>
      ///	 * <returns> the minimum availability, null in case of an error, for instance
      ///	 *         if no modulerefs are specified </returns>
      ///	 
      public virtual EnumAvailability getMinAvailability(VString vModuleRefs)
      {
         IDictionary m = getModuleMap();
         if (vModuleRefs == null || m == null || vModuleRefs.Count == 0)
            return null; // error exit
         JDFDeviceCap.EnumAvailability minAvail = JDFDeviceCap.EnumAvailability.Installed;
         for (int i = 0; i < vModuleRefs.Count; i++)
         {
            JDFModuleCap mc = (JDFModuleCap)m[vModuleRefs.stringAt(i)];
            if (mc == null)
               return null;
            EnumAvailability a = mc.getAvailability();
            if (a == null || EnumAvailability.Module.Equals(a)) // module is not
               // valid
               // recursively
               return null;
            if (minAvail.CompareTo(a) > 0)
               minAvail = a;

         }
         return minAvail;
      }

      ///   
      ///	 <summary> * get a hashmap that uses ModuleCap/@ID as a key and has the ModuleCap as a
      ///	 * value
      ///	 *  </summary>
      ///	 * <returns> the hashmap, null if no modulecaps exist </returns>
      ///	 
      public virtual IDictionary getModuleMap()
      {
         Hashtable hashMap = null;

         VElement v = getChildElementVector(ElementName.MODULECAP, null, null, true, 0, true);
         if (v != null)
         {
            int siz = v.Count;
            hashMap = new Hashtable();
            for (int i = 0; i < siz; i++)
            {
               JDFModuleCap mc = (JDFModuleCap)v[i];
               string id = mc.getID();
               if (!isWildCard(id))
               {
                  hashMap.Add(id, mc);
               }
            }

            hashMap = hashMap.Count == 0 ? null : hashMap;
         }

         return hashMap;
      }

      ///   
      ///	 <summary> * get the module availability based on modulerefs and availability
      ///	 *  </summary>
      ///	 * <param name="caps">
      ///	 *            either A State, devcap or devcaps
      ///	 * @return </param>
      ///	 
      public static EnumAvailability getModuleAvailability(ICapabilityElement caps)
      {
         EnumAvailability a = caps.getAvailability();
         if (!EnumAvailability.Module.Equals(a))
            return a;
         JDFModulePool mp = caps.getModulePool();
         if (mp == null)
            return null;
         return mp.getMinAvailability(caps.getModuleRefs());
      }

      ///   
      ///	 * <param name="caps">
      ///	 *            the element to append the ref to
      ///	 *  </param>
      ///	 * <returns> <seealso cref="JDFModuleCap"/> the Modulecap that id refers tp </returns>
      ///	 
      public static JDFModuleCap appendModuleRef(ICapabilityElement caps, string id)
      {
         caps.setAvailability(EnumAvailability.Module);
         JDFModulePool mp = caps.getCreateModulePool();
         ((KElement)caps).appendAttribute(AttributeName.MODULEREFS, id, null, null, true);
         return mp.getCreateModuleCap(id);
      }

      ///   
      ///	 <summary> * get a modulecap with a given id
      ///	 *  </summary>
      ///	 * <param name="id">
      ///	 *            the modulecap id </param>
      ///	 * <returns> the modulecap </returns>
      ///	 
      public virtual JDFModuleCap getModuleCap(string id)
      {
         return (JDFModuleCap)getChildWithAttribute(ElementName.MODULECAP, AttributeName.ID, null, id, 0, true);
      }

      ///   
      ///	 <summary> * get a modulecap with a given id, create it if it does not exist
      ///	 *  </summary>
      ///	 * <param name="id">
      ///	 *            the modulecap id </param>
      ///	 * <returns> the modulecap </returns>
      ///	 
      public virtual JDFModuleCap getCreateModuleCap(string id)
      {
         JDFModuleCap mc = getModuleCap(id);
         if (mc == null)
         {
            mc = appendModuleCap();
            mc.setID(id);
         }
         return mc;
      }
   }
}
