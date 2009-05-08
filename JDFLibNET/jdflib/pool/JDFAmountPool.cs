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
 * THIS SOFTWARE IS PROVIDED ``AS IS'' AND ANY EXPRESSED OR IMPLIED
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


namespace org.cip4.jdflib.pool
{
   using System;
   using System.Collections.Generic;


   using JDFAutoAmountPool = org.cip4.jdflib.auto.JDFAutoAmountPool;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using JDFPartAmount = org.cip4.jdflib.core.JDFPartAmount;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using IAmountPoolContainer = org.cip4.jdflib.ifaces.IAmountPoolContainer;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using ContainerUtil = org.cip4.jdflib.util.ContainerUtil;
   using StringUtil = org.cip4.jdflib.util.StringUtil;
   //using VectorMap = org.cip4.jdflib.util.VectorMap;

   ///
   /// <summary> * This class represents a JDF-AuditPool </summary>
   /// 
   public class JDFAmountPool : JDFAutoAmountPool
   {
      ///   
      ///	 <summary> * map of an amountpool that allows quick access to multiple amounts
      ///	 * Class AmountMap
      ///	 * </summary>
      ///	 
      public class AmountMap : org.cip4.jdflib.util.VectorMap<JDFAttributeMap, JDFPartAmount>
      {

         ///      
         ///		 <summary> *  </summary>
         ///		 
         private const long serialVersionUID = 6548151023982113766L;

         ///      
         ///		 <summary> * Constructor AmountMap
         ///		 *  </summary>
         ///		 * <param name="vsPartIDKeys"> </param>
         ///		 
         internal AmountMap(JDFAmountPool enclosingInstance, VString vsPartIDKeys)
         {
            VElement vPartAmount = enclosingInstance.getChildElementVector(ElementName.PARTAMOUNT, null, null, true, 0, false);

            if (vPartAmount != null)
            {
               int size = vPartAmount.Count;
               for (int i = 0; i < size; i++)
               {
                  JDFPartAmount pa = (JDFPartAmount)vPartAmount[i];
                  VJDFAttributeMap vamParts = pa.getPartMapVector();

                  int size2 = vamParts.Count;
                  for (int p = 0; p < size2; p++)
                  {
                     JDFAttributeMap amPart = vamParts[p];
                     amPart.reduceMap(vsPartIDKeys);
                     putOne(amPart, pa);
                  }
               }
            }
         }

         ///      
         ///		 <summary> * Method getAmountDouble
         ///		 *  </summary>
         ///		 * <param name="amParts"> </param>
         ///		 * <param name="strAttributeName">
         ///		 *  </param>
         ///		 * <returns> the sum of all matching amounts </returns>
         ///		 
         public virtual double getAmountDouble(JDFAttributeMap amParts, string strAttributeName)
         {
            double dValue = -1.0;
            List<JDFPartAmount> lpa = null;  // TODO: Can't find definition for this method:  get(amParts);

            if (lpa != null)
            {
               double dTmp = 0.0;
               bool isFound = false;
               foreach (JDFPartAmount pa in lpa)
               {
                  string strValue = pa.getAttribute(strAttributeName, null, null);
                  if (strValue != null)
                  {
                     double dAdd = StringUtil.parseDouble(strValue, -1.0);
                     if (dAdd >= 0.0)
                     {
                        dTmp += dAdd;
                        isFound = true;
                     }
                  }
               }

               if (isFound)
               {
                  dValue = dTmp;
               }
            }

            return (dValue);
         }
      }

      ///   
      ///	 <summary> * @author Rainer Prosi, Heidelberger Druckmaschinen
      ///	 * static helper class that can be delegated from AmountPool containg classes, e.g. ResourceLink </summary>
      ///	 
      public class AmountPoolHelper
      {

         ///      
         ///		 <summary> * returns the attribute occurrence in PartAmount, or the default in the ResourceLink </summary>
         ///		 * <param name="poolParent"> the pool parent
         ///		 *  </param>
         ///		 * <param name="attrib"> the attribute name </param>
         ///		 * <param name="nameSpaceURI"> the XML-namespace </param>
         ///		 * <param name="mPart"> defines which part of this ResourceLink the Amount belongs to. If empty get the ResourceLink
         ///		 *            root attribute. </param>
         ///		 * <returns> value of attribute found, null if not available </returns>
         ///		 * <param name="iSkip"> the index of the partAmount to check
         ///		 * @since 071103 </param>
         ///		 
         public static string getAmountPoolAttribute(IAmountPoolContainer poolParent, string attrib, string nameSpaceURI, JDFAttributeMap mPart, int iSkip)
         {
            // want a map but already in a partamount - snafu
            if (poolParent is JDFPartAmount)
            {
               if (mPart != null || iSkip > 1)
                  throw new JDFException("JDFResourceLink.getAmountPoolAttribute: calling method on PartAmount object");
               return iSkip == 0 ? poolParent.getAttribute(attrib, nameSpaceURI, null) : null;
            }
            // default to attribute if no amountpool
            JDFAmountPool amountPool = poolParent.getAmountPool();
            if (amountPool == null)
            {
               return iSkip > 0 ? null : poolParent.getAttribute(attrib, nameSpaceURI, null);
            }
            JDFPartAmount pa = amountPool.getPartAmount(mPart, iSkip);
            string ret = null;
            if (pa != null) // we have a pa; if it has the attribute return its
            // value, else get the link attribute
            {
               ret = pa.getAttribute(attrib, nameSpaceURI, null);
               if (ret == null)
                  ret = poolParent.getAttribute(attrib, nameSpaceURI, null);
            }

            return ret;
         }

         ///      
         ///		 <summary> * returns the attribute occurence in PartAmount, or the default in the ResourceLink
         ///		 *  </summary>
         ///		 * <param name="attrib"> the attribute name </param>
         ///		 * <param name="nameSpaceURI"> the XML-namespace </param>
         ///		 * <param name="vPart"> defines which part of this ResourceLink the Amount belongs to. If null get the ResourceLink root
         ///		 *            attribute. </param>
         ///		 * <returns> value of attribute found, null if not available
         ///		 * @since 071103 </returns>
         ///		 
         public static string getAmountPoolAttribute(IAmountPoolContainer poolParent, string attrib, string nameSpaceURI, VJDFAttributeMap vPart)
         {
            // want a map but already in a partamount - snafu
            if (poolParent is JDFPartAmount)
            {
               if (vPart != null)
                  throw new JDFException("JDFResourceLink.getAmountPoolAttribute: calling method on PartAmount object");
               return poolParent.getAttribute(attrib, nameSpaceURI, null);
            }
            // default to attribute if no amountpool
            JDFAmountPool amountPool = poolParent.getAmountPool();
            if (amountPool == null || vPart == null)
            {
               return poolParent.getAttribute(attrib, nameSpaceURI, null);
            }
            JDFPartAmount pa = amountPool.getPartAmount(vPart);
            if (pa != null) // we have a pa; if it has the attribute return its
            // value, else get the link attribute
            {
               string ret = pa.getAttribute(attrib, nameSpaceURI, null);
               if (ret != null)
                  return ret;
            }

            return poolParent.getAttribute(attrib, nameSpaceURI, null);
         }

         ///      
         ///		 <summary> * get the sum of all matching AmountPool/PartAmount/@attName as a double PartAmounts match if all attributes
         ///		 * match those in PartAmount, i.e. mPart is a submap of the searche PartAmount elements
         ///		 * 
         ///		 *  </summary>
         ///		 * <param name="attName"> the Attribute name , e.g Amount, ActualAmount </param>
         ///		 * <param name="mPart"> </param>
         ///		 * <returns> double - the element </returns>
         ///		 * <exception cref="JDFException"> if the element can not be cast to double </exception>
         ///		 
         public static double getAmountPoolDouble(IAmountPoolContainer poolParent, string attName, JDFAttributeMap mPart)
         {
            double d = 0;

            int n = 0;
            bool bFound = false;
            JDFAmountPool ap = poolParent.getAmountPool();
            while (true)
            {
               string w = getAmountPoolAttribute(poolParent, attName, null, mPart, n);
               if (isWildCard(w))
               {
                  if (ap == null || ap.getPartAmount(mPart, n) == null)
                  {
                     return bFound ? d : -1;
                  }

                  n++;
                  continue;
               }

               double dd = StringUtil.parseDouble(w, -1.234567);
               if (dd == -1.234567)
               {
                  throw new JDFException("JDFResourceLink.getAmountPoolDouble: Attribute " + attName + " has an invalid value");
               }

               d += dd;
               bFound = true;
               n++;
            }
         }

         ///      
         ///		 <summary> * get the exactly matching AmountPool/PartAmount/@AttName as a double
         ///		 *  </summary>
         ///		 * <param name="attName"> </param>
         ///		 * <param name="vPart"> </param>
         ///		 * <returns> double - </returns>
         ///		 * <exception cref="JDFException"> if the element can not be cast to double </exception>
         ///		 
         public static double getAmountPoolDouble(IAmountPoolContainer poolParent, string attName, VJDFAttributeMap vPart)
         {
            double d = 0;
            string w = getAmountPoolAttribute(poolParent, attName, null, vPart);
            if (w == null)
            {
               return -1;
            }
            d = StringUtil.parseDouble(w, -1.234567);
            if (d == -1.234567)
            {
               throw new JDFException("JDFResourceLink.getAmountPoolDouble: Attribute " + attName + " has an invalid value");
            }
            return d;
         }

         ///

         ///      
         ///		 <summary> * gets the sum of all matching tags, with the assumpzion that no condition defaults to good
         ///		 *  </summary>
         ///		 * <param name="poolParent">  </param>
         ///		 * <param name="attName">  </param>
         ///		 * <param name="vPart">  </param>
         ///		 * <returns> the sum
         ///		 *  </returns>
         ///		 
         public static double getAmountPoolSumDouble(IAmountPoolContainer poolParent, string attName, VJDFAttributeMap vPart)
         {
            VJDFAttributeMap vPartLocal = vPart;

            if (vPartLocal == null)
               vPartLocal = poolParent.getPartMapVector();

            if (poolParent.hasAttribute(attName))
               return poolParent.getRealAttribute(attName, null, 0);

            VJDFAttributeMap vm = vPartLocal == null ? null : new VJDFAttributeMap(vPartLocal);
            JDFResource linkRoot = poolParent.getLinkRoot();
            if (linkRoot != null && vm != null)
            {
               SupportClass.SetSupport<string> @set = linkRoot.getPartIDKeys().getSet();
               @set.Add(AttributeName.CONDITION); // retain good / waste
               vm.reduceMap(@set);
            }

            if (vm == null)
            {
               vm = new VJDFAttributeMap();
               vm.Add((JDFAttributeMap)null);
            }

            double dd = 0;
            JDFAmountPool ap = poolParent.getAmountPool();
            if (ap == null)
               return poolParent.getRealAttribute(attName, null, 0.0);

            VElement vParts = ap.getChildElementVector(ElementName.PARTAMOUNT, null);

            if (vParts.IsEmpty())
               return poolParent.getRealAttribute(attName, null, 0.0);

            bool isWaste = vPartLocal != null && vPartLocal.subMap(new JDFAttributeMap(AttributeName.CONDITION, "Waste"));
            if (!isWaste && (vPartLocal == null || !vPartLocal.subMap(new JDFAttributeMap(AttributeName.CONDITION, "*"))))
            {
               vPartLocal = new VJDFAttributeMap(vPartLocal);
               vPartLocal.Add(new JDFAttributeMap(AttributeName.CONDITION, "Good"));
            }

            for (int j = 0; j < vParts.Count; j++)
            {
               JDFPartAmount pa = (JDFPartAmount)vParts[j];
               VJDFAttributeMap partMapVector = pa.getPartMapVector();
               if (isWaste)
               {
                  bool hasCondition = partMapVector.subMap(new JDFAttributeMap(AttributeName.CONDITION, "*"));
                  if (!hasCondition)
                     continue;

               }

               if (!partMapVector.overlapsMap(vm))
                  continue;

               string ret = null;
               ret = pa.getAttribute(attName, null, null);
               if (ret == null)
                  ret = poolParent.getAttribute(attName, null, null);

               dd += StringUtil.parseDouble(ret, 0.0);
            }

            return dd;
         }

         ///      
         ///		 <summary> * get an amountmap for the Amountpool of poolParent </summary>
         ///		 * <param name="poolParent"> the pool parent </param>
         ///		 * <param name="vPartIDKeys"> </param>
         ///		 * <returns> the AmountMap for the Amountpool, null if no amountpool exists </returns>
         ///		 
         public static AmountMap getAmountMap(IAmountPoolContainer poolParent, VString vPartIDKeys)
         {
            if (poolParent == null || poolParent.getAmountPool() == null)
               return null;
            return poolParent.getAmountPool().getAmountMap(vPartIDKeys);
         }

         ///      
         ///		 <summary> * get double attribute Amount, defaults to the value of Amount for the linked partition
         ///		 *  </summary>
         ///		 * <param name="mPart"> partition map to retrieve Amount for </param>
         ///		 * <returns> the amount, -1 if none is specified
         ///		 * 
         ///		 * @default getAmount(null) </returns>
         ///		 
         public static double getAmount(IAmountPoolContainer poolParent, JDFAttributeMap mPart)
         {
            double d = getAmountPoolDouble(poolParent, AttributeName.AMOUNT, mPart);
            if (d == -1)
            {
               JDFResource target = poolParent.getLinkRoot();
               if (target != null)
               {
                  target = target.getPartition(mPart, null);
                  if (target != null)
                     return target.getAmount();
               }
            }
            else
            {
               return d;
            }

            return -1.0;
         }

         ///      
         ///		 <summary> * get double attribute MinAmount, defaults to getAmount if MinAmount is not set
         ///		 *  </summary>
         ///		 * <param name="mPart"> partition map to retrieve MinAmount for </param>
         ///		 * <returns> the MinAmount value
         ///		 * @default getAmount(null) </returns>
         ///		 
         public static double getMinAmount(IAmountPoolContainer poolParent, JDFAttributeMap mPart)
         {
            double d = getAmountPoolDouble(poolParent, AttributeName.MINAMOUNT, mPart);
            if (d == -1)
               return getAmount(poolParent, mPart);
            return d;
         }

         ///      
         ///		 <summary> * get double attribute MaxAmount, defaults to getAmount if MinAmount is not set
         ///		 *  </summary>
         ///		 * <param name="mPart"> partition map to retrieve MinAmount for </param>
         ///		 * <returns> the MinAmount value
         ///		 * @default getAmount(null) </returns>
         ///		 
         public static double getMaxAmount(IAmountPoolContainer poolParent, JDFAttributeMap mPart)
         {
            double d = getAmountPoolDouble(poolParent, AttributeName.MAXAMOUNT, mPart);
            if (d == -1)
               return getAmount(poolParent, mPart);
            return d;
         }

         ///      
         ///		 <summary> * sets the attribute occurence in the appropriate PartAmount when called for a resourceLink and creates the
         ///		 * AmountPool and/or PartAmount(s) if they are not yet there
         ///		 *  </summary>
         ///		 * <param name="attrib"> the attribute name </param>
         ///		 * <param name="value"> value to set in string form. </param>
         ///		 * <param name="nameSpaceURI"> the XML-namespace </param>
         ///		 * <param name="vPart"> defines which part of this ResourceLink the Amount belongs to, if empty set the ResourceLink
         ///		 *            root attribute. </param>
         ///		 * <exception cref="JDFException"> when called directly on a PartAmount
         ///		 * @since 060630 </exception>
         ///		 
         public static void setAmountPoolAttribute(IAmountPoolContainer poolParent, string attrib, string @value, string nameSpaceURI, VJDFAttributeMap vPart)
         {
            // ideally the method would be hidden in PartAmount
            if ((vPart == null) || (vPart.IsEmpty()) || vPart.Count == 1 && vPart[0].Count == 0)
            {
               poolParent.setAttribute(attrib, @value, nameSpaceURI);
               return;
            }
            poolParent.removeAttribute(attrib, nameSpaceURI); // either in the
            // pool or the
            // link, not both
            JDFAmountPool ap = poolParent.getCreateAmountPool();
            JDFPartAmount pa0 = ap.getCreatePartAmount(vPart);
            pa0.setAttribute(attrib, @value, nameSpaceURI);
         }

         ///      
         ///		 <summary> * sets the attribute occurence in the appropriate PartAmount when called for a resourceLink and creates the
         ///		 * AmountPool and/or PartAmount if it is not yet there
         ///		 *  </summary>
         ///		 * <param name="attrib"> the attribute name </param>
         ///		 * <param name="value"> value to set in string form. </param>
         ///		 * <param name="nameSpaceURI"> the XML-namespace </param>
         ///		 * <param name="mPart"> defines which part of this ResourceLink the Amount belongs to, if empty set the ResourceLink
         ///		 *            root attribute </param>
         ///		 * <exception cref="JDFException"> when called directly on a PartAmount
         ///		 * @since 071103 </exception>
         ///		 
         public static void setAmountPoolAttribute(IAmountPoolContainer poolParent, string attrib, string @value, string nameSpaceURI, JDFAttributeMap mPart)
         {
            // ideally the method would be hidden in PartAmount
            if ((mPart == null) || (mPart.IsEmpty()))
            {
               poolParent.setAttribute(attrib, @value, nameSpaceURI);
               return;
            }
            if (poolParent is JDFPartAmount)
            {
               throw new JDFException("JDFResourceLink.setAmountPoolAttribute: calling method on PartAmount object");
            }
            VJDFAttributeMap v = new VJDFAttributeMap();
            v.Add(mPart);
            setAmountPoolAttribute(poolParent, attrib, @value, nameSpaceURI, v);
         }

      }


      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFAmountPool
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFAmountPool(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFAmountPool
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFAmountPool(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFAmountPool
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFAmountPool(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      ///   
      ///	 * <param name="mPart"> </param>
      ///	 
      public virtual void removePartAmount(JDFAttributeMap mPart)
      {
         getPartAmount(mPart).deleteNode();
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
         return "JDFAmountPool[ -->" + base.ToString() + "]";
      }

      ///   
      ///	 <summary> * Get a PartAmount that fits to the filter defined by mPart
      ///	 *  </summary>
      ///	 * <param name="mPart"> filter for the part to set the status </param>
      ///	 * <returns> the PartAmount that fits </returns>
      ///	 
      public virtual JDFPartAmount getMatchingPartAmount(JDFAttributeMap mPart)
      {
         VElement vPartAmount = getChildElementVector(ElementName.PARTAMOUNT, null, null, true, 0, false);
         for (int i = vPartAmount.Count - 1; i >= 0; i--)
         {
            JDFPartAmount partAmount = (JDFPartAmount)vPartAmount[i];
            VJDFAttributeMap vMapPart = partAmount.getPartMapVector();

            if (vMapPart.Contains(mPart))
            {
               return partAmount; // exact match
            }
         }
         return null;
      }

      ///   
      ///	 <summary> * Get a PartAmount that exactly equals the filter defined by mPart
      ///	 *  </summary>
      ///	 * <param name="mPart"> filter for the part to set the status </param>
      ///	 * <returns> the PartAmount that fits </returns>
      ///	 
      public virtual JDFPartAmount getPartAmount(JDFAttributeMap mPart)
      {
         VElement vPartAmount = getChildElementVector(ElementName.PARTAMOUNT, null, null, true, 0, false);
         for (int i = vPartAmount.Count - 1; i >= 0; i--)
         {
            JDFPartAmount partAmount = (JDFPartAmount)vPartAmount[i];
            VJDFAttributeMap vMapPart = partAmount.getPartMapVector();

            if (vMapPart != null && vMapPart.Count == 1 && vMapPart[0].Equals(mPart))
            {
               return partAmount; // exact match
            }
         }
         return null;
      }

      ///   
      ///	 <summary> * Get a PartAmount that fits to the filter defined by mPart
      ///	 *  </summary>
      ///	 * <param name="vPart"> filter for the part to set the status </param>
      ///	 * <returns> the PartAmount that fits </returns>
      ///	 
      public virtual JDFPartAmount getPartAmount(VJDFAttributeMap vPart)
      {
         VElement vPartAmount = getChildElementVector(ElementName.PARTAMOUNT, null, null, true, 0, false);
         for (int i = vPartAmount.Count - 1; i >= 0; i--)
         {
            JDFPartAmount partAmount = (JDFPartAmount)vPartAmount[i];
            VJDFAttributeMap vMapPart = partAmount.getPartMapVector();

            if (ContainerUtil.Equals(vMapPart, vPart))
            {
               return partAmount; // exact match
            }
         }
         return null;
      }

      ///   
      ///	 <summary> * Get a PartAmount that fits to the filter defined by mPart
      ///	 *  </summary>
      ///	 * <param name="mPart"> filter for the part to set the status </param>
      ///	 * <param name="iSkip"> the iSkip'th element to get </param>
      ///	 * <returns> the PartAmount that fits </returns>
      ///	 
      public virtual JDFPartAmount getPartAmount(JDFAttributeMap mPart, int iSkip)
      {
         VElement vPartAmount = getChildElementVector(ElementName.PARTAMOUNT, null, null, true, 0, false);
         int n = 0;
         for (int i = vPartAmount.Count - 1; i >= 0; i--)
         {
            JDFPartAmount partAmount = (JDFPartAmount)vPartAmount[i];
            VJDFAttributeMap vMapPart = partAmount.getPartMapVector();

            if (vMapPart.subMap(mPart) && ++n > iSkip)
            {
               return partAmount; // exact match
            }
         }
         return null;
      }

      ///   
      ///	 <summary> * Get a PartAmount that fits to the filter defined by mPart
      ///	 *  </summary>
      ///	 * <param name="mPart"> filter for the part to set the status </param>
      ///	 * <param name="bCreate"> </param>
      ///	 * <returns> the PartAmount that fits </returns>
      ///	 * @deprecated use either getPartAmount or getCreatePartAmount 
      ///	 
      [Obsolete("use either getPartAmount or getCreatePartAmount")]
      public virtual JDFPartAmount getPartAmount(JDFAttributeMap mPart, bool bCreate)
      {
         JDFPartAmount p = getPartAmount(mPart, 0);
         if (bCreate && p == null)
         {
            p = (JDFPartAmount)appendElement("PartAmount", JDFConstants.EMPTYSTRING);
            p.setPartMap(mPart);
         }
         return p;
      }

      ///   
      ///	 <summary> * Get a vector of PartAmount that fits to the filter defined by mPart
      ///	 *  </summary>
      ///	 * <param name="mPart"> filter vector for the part to set the status </param>
      ///	 * <param name="bCreate"> </param>
      ///	 * <returns> the PartAmount that fits </returns>
      ///	 * @deprecated use getMatchingPartAmountVector default: GetPartAmountVector(VJDFAttributeMap vmPart, false) 
      ///	 
      [Obsolete("use getMatchingPartAmountVector default: GetPartAmountVector(VJDFAttributeMap vmPart, false)")]
      public virtual VElement getPartAmountVector(VJDFAttributeMap vmPart, bool bCreate)
      {
         VElement vPartAmount = new VElement();
         for (int i = 0; i < vmPart.Count; i++)
         {
            JDFPartAmount ps = getPartAmount(vmPart[i], bCreate);
            if (ps != null)
            {
               vPartAmount.Add(ps);
            }
         }
         return vPartAmount;
      }

      ///   
      ///	 <summary> * remove all partAmounts that are not specified in keepList
      ///	 *  </summary>
      ///	 * <param name="keepList"> partAmounts to keep </param>
      ///	 
      public virtual void reducePartAmounts(VJDFAttributeMap keepList)
      {
         if (keepList == null)
            return;

         VElement v = getChildElementVector(ElementName.PARTAMOUNT, null, null, true, -1, true);
         for (int i = 0; i < v.Count; i++)
         {
            JDFPartAmount pa = (JDFPartAmount)v[i];
            JDFAttributeMap map = pa.getPartMap();
            bool ciao = true;
            for (int j = 0; j < keepList.Count; j++)
            {
               if (map.subMap(keepList[j]))
               {
                  ciao = false;
                  break;
               }
            }
            if (ciao)
               pa.deleteNode();
         }
      }

      ///   
      ///	 <summary> * get an AmountMap for this Amountpool </summary>
      ///	 * <param name="vPartIDKeys"> </param>
      ///	 * <returns> the AmountMap for the Amountpool, null if no amountpool exists </returns>
      ///	 
      public virtual AmountMap getAmountMap(VString vPartIDKeys)
      {
         return new AmountMap(this, vPartIDKeys);
      }

      ///   
      ///	 <summary> * Append JDFPartAmount element
      ///	 *  </summary>
      ///	 * <param name="mPart"> JDFAttributeMap to append </param>
      ///	 
      public virtual JDFPartAmount appendPartAmount(JDFAttributeMap mPart)
      {
         JDFPartAmount p = base.appendPartAmount();
         p.setPartMap(mPart);
         return p;
      }

      ///   
      ///	 <summary> * Append JDFPartAmount elements
      ///	 *  </summary>
      ///	 * <param name="vPArt"> vector of partAmounts to append </param>
      ///	 
      public virtual JDFPartAmount appendPartAmount(VJDFAttributeMap vPart)
      {
         JDFPartAmount p = base.appendPartAmount();
         p.setPartMapVector(vPart);
         return p;
      }

      ///   
      ///	 <summary> * get JDFPartAmount specified by mPart, create a new one if it doesn't exist
      ///	 *  </summary>
      ///	 * <param name="mPart"> JDFPartAmount to get/create
      ///	 * @return </param>
      ///	 
      public virtual JDFPartAmount getCreatePartAmount(JDFAttributeMap mPart)
      {
         JDFPartAmount p = getPartAmount(mPart);
         if (p == null)
         {
            p = (JDFPartAmount)appendElement(ElementName.PARTAMOUNT, null);
            p.setPartMap(mPart);
         }
         return p;
      }

      ///   
      ///	 <summary> * get JDFPartAmount specified by mPart, create a new one if it doesn't exist
      ///	 *  </summary>
      ///	 * <param name="vPart"> JDFPartAmount to get/create
      ///	 * @return </param>
      ///	 
      public virtual JDFPartAmount getCreatePartAmount(VJDFAttributeMap vPart)
      {
         JDFPartAmount p = getPartAmount(vPart);
         if (p == null)
         {
            p = (JDFPartAmount)appendElement(ElementName.PARTAMOUNT, null);
            p.setPartMapVector(vPart);
         }
         return p;
      }

      ///   
      ///	 <summary> * Get a vector of PartAmounts which are supersets of the filter defined by mPart<br>
      ///	 * i.e. mPart is a submap of all returned elements
      ///	 *  </summary>
      ///	 * <param name="mPart"> filter vector for the part to set the status
      ///	 *  </param>
      ///	 * <returns> VElement - the vector of PartAmount elements that fit, null if nothing matches </returns>
      ///	 
      public virtual VElement getMatchingPartAmountVector(JDFAttributeMap mPart)
      {
         VElement vPartAmount = getChildElementVector(ElementName.PARTAMOUNT, null, null, true, 0, false);
         int size = vPartAmount.Count;
         if (size == 0)
            return null;
         VElement vPA = new VElement();
         for (int i = 0; i < size; i++)
         {
            JDFPartAmount ps = (JDFPartAmount)vPartAmount[i];
            VJDFAttributeMap mm = ps.getPartMapVector();
            for (int j = 0; j < mm.Count; j++)
            {
               JDFAttributeMap m = mm[j];
               if (m.subMap(mPart))
               {
                  vPA.Add(ps);
                  break;
               }
            }
         }
         return vPA.Count == 0 ? null : vPA;
      }
   }
}
