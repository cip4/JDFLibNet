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



/*
 * Copyright (c) 2001 Heidelberger Druckmaschinen AG, All Rights Reserved.
 * JDFResourcePool.cs
 * Last changes
 * 2001-07-30   Torsten Kaehlert - delete isNull() and throwNull() methods in parent class KNode
 *              TKAE20010730
 * 2002-07-02   JG - RP now inherits from JDFAutoResourcePool
 * 2002-07-02   JG - back to inheriting from JDFPool
 * 2002-07-02   JG - CopyResource: setting the SpawnStatus after copying the node
 * 2002-07-02   JG - CopyResource: don't add partitions in unpartitioned resources
 *                                 to set the spawn status
 * 2002-07-02   JG - CopyResource  fixed HRefs handling
 * 2002-07-02   JG - CopyResource added spawnID parameter
 * 2002-07-02   JG - CopyResource does not add new partitions any more
 * 2002-07-02   JG - removed AddDevice, AddOperator, AddScan and AddPDF
 * 2002-07-02   JG - added GetPoolChild, GetPoolChildren
 */

namespace org.cip4.jdflib.pool
{
   using System;
   using System.Collections;



   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElemInfoTable = org.cip4.jdflib.core.ElemInfoTable;
   using ElementInfo = org.cip4.jdflib.core.ElementInfo;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using VString = org.cip4.jdflib.core.VString;
   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;

   public class JDFResourcePool : JDFPool
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFResourcePool
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFResourcePool(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFResourcePool
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFResourcePool(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFResourcePool
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>
      ///	 
      public JDFResourcePool(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      // **************************************** Methods
      // *********************************************
      ///   
      ///	 <summary> * this table contains only non standard versioned elements, i.e. first>=1.1 or deprecated </summary>
      ///	 
      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[90];
      static JDFResourcePool()
      {
         int i = 0;
         elemInfoTable[i++] = new ElemInfoTable(ElementName.EMBOSSINGINTENT, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.PUBLISHINGINTENT, 0x33333111);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.SIZEINTENT, 0x44444443);

         elemInfoTable[i++] = new ElemInfoTable(ElementName.ADHESIVEBINDINGPARAMS, 0x44444443);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.ASSEMBLY, 0x33333311);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.ASSETLISTCREATIONPARAMS, 0x33333311);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.BARCODECOMPPARAMS, 0x33333111);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.BARCODEREPROPARAMS, 0x33333111);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.BENDINGPARAMS, 0x33333111);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.BINDERYSIGNATURE, 0x33333311);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.BLOCKPREPARATIONPARAMS, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.BOXFOLDINGPARAMS, 0x33333111);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.BOXPACKINGPARAMS, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.BUFFERPARAMS, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.BUNDLE, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.BUNDLINGPARAMS, 0x33333311);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.CASEMAKINGPARAMS, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.CASINGINPARAMS, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.COLORMEASUREMENTCONDITIONS, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.CONTACTCOPYPARAMS, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.COVERAPPLICATIONPARAMS, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.CREASINGPARAMS, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.CUSTOMERINFO, 0x33333111);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.CUTTINGPARAMS, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.CYLINDERLAYOUT, 0x33333111);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.CYLINDERLAYOUTPREPARATIONPARAMS, 0x33333111);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.DEVELOPINGPARAMS, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.DEVICEMARK, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.DIELAYOUT, 0x33333111);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.DIGITALDELIVERYPARAMS, 0x33333311);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.DIGITALMEDIA, 0x33333311);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.DIVIDINGPARAMS, 0x44444443);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.ELEMENTCOLORPARAMS, 0x33333311);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.EMBOSSINGPARAMS, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.EXTERNALIMPOSITIONTEMPLATE, 0x33333111);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.FEEDINGPARAMS, 0x33333311);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.FITPOLICY, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.FOLD, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.FORMATCONVERSIONPARAMS, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.GLUINGPARAMS, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.HEADBANDAPPLICATIONPARAMS, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.HOLELINE, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.HOLELIST, 0x33333311);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.IDPRINTINGPARAMS, 0x44444443);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.JOBFIELD, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.LABELINGPARAMS, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.LAYOUTELEMENTPRODUCTIONPARAMS, 0x33333111);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.LAYOUTPREPARATIONPARAMS, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.LONGITUDINALRIBBONOPERATIONPARAMS, 0x44444443);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.MANUALLABORPARAMS, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.MEDIASOURCE, 0x44444443);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.MISCCONSUMABLE, 0x33333111);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.NODEINFO, 0x33333111);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.PACKINGPARAMS, 0x44444443);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.PAGELIST, 0x33333311);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.PALLET, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.PALLETIZINGPARAMS, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.PDLCREATIONPARAMS, 0x33333111);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.PERFORATINGPARAMS, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.PREFLIGHTPARAMS, 0x33333311);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.PREFLIGHTPROFILE, 0x44444433);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.PREFLIGHTREPORT, 0x33333311);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.PREFLIGHTREPORTRULEPOOL, 0x33333311);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.PRINTCONDITION, 0x33333311);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.PRINTROLLINGPARAMS, 0x33333311);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.PRODUCTIONPATH, 0x33333111);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.PROOFINGPARAMS, 0x44444433);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.QUALITYCONTROLPARAMS, 0x33333311);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.RASTERREADINGPARAMS, 0x33333111);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.REGISTERRIBBON, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.ROLLSTAND, 0x33333311);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.SADDLESTITCHINGPARAMS, 0x44444443);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.SCAVENGERAREA, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.SHAPECUTTINGPARAMS, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.SHEET, 0x44444333);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.SHRINKINGPARAMS, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.SIDESEWINGPARAMS, 0x44444443);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.SPINEPREPARATIONPARAMS, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.SPINETAPINGPARAMS, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.STACKINGPARAMS, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.STRAP, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.STRAPPINGPARAMS, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.STRIPBINDINGPARAMS, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.STRIPPINGPARAMS, 0x33333311);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.SURFACE, 0x44444333);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.THREADSEALINGPARAMS, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.TOOL, 0x33333331);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.USAGECOUNTER, 0x33333111);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.WEBINLINEFINISHINGPARAMS, 0x33333111);
         elemInfoTable[i++] = new ElemInfoTable(ElementName.WRAPPINGPARAMS, 0x33333331);
      }

      protected internal override ElementInfo getTheElementInfo()
      {
         return base.getTheElementInfo().updateAdd(elemInfoTable);
      }

      ///   
      ///	 <summary> * gets the elemeinfotable for the resourcelinkpool based on this pool<br>
      ///	 * Note that the cardinality is not updated and that the pool should be used for version checks only
      ///	 *  </summary>
      ///	 * <returns> ElemInfoTable[] the resourcelinkpools elemeninfotable </returns>
      ///	 
      public static ElemInfoTable[] getLinkInfoTable()
      {
         ElemInfoTable[] elemInfoTableLink = new ElemInfoTable[elemInfoTable.Length];
         for (int i = 0; i < elemInfoTableLink.Length; i++)
         {
            elemInfoTableLink[i] = new ElemInfoTable(elemInfoTable[i].getElementName() + JDFConstants.LINK, elemInfoTable[i].getValidityStatus());
         }
         return elemInfoTableLink;
      }

      ///   
      ///	 <summary> * toString
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public override string ToString()
      {
         return "JDFResourcePool[ --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * GetResIds - returns a set of all IDs of the resources that are in this pool
      ///	 *  </summary>
      ///	 * <returns> Vector - all IDs of the pool childs </returns>
      ///	 
      public virtual VString getResIds()
      {
         VString setID = new VString();

         VElement nl = getPoolChildren(null, null, null);

         int l = nl.Count;
         for (int i = 0; i < l; i++)
         {
            string s = ((JDFResource)nl[i]).getAttribute(AttributeName.ID);
            if (s.Equals(JDFConstants.EMPTYSTRING))
            {
               continue;
            }
            setID.Add(s);
         }
         return setID;
      }

      ///   
      ///	 <summary> * Method GetResource.
      ///	 * <p>
      ///	 * default: GetResource(name, 0, JDFConstants.EMPTYSTRING)
      ///	 *  </summary>
      ///	 * <param name="name"> name of the resource to look for </param>
      ///	 * <param name="i"> the index of the child, or -1 to create a new one </param>
      ///	 * <param name="nameSpaceURI"> the namespace to search in
      ///	 *  </param>
      ///	 * <returns> JDFResource: the resource you were looking for, <code>null</code> if not found </returns>
      ///	 
      public virtual JDFResource getResource(string strName, int i, string nameSpaceURI)
      {
         KElement poolChild = getPoolChild(i, strName, null, nameSpaceURI);

         if (poolChild != null)
         {
            return (JDFResource)poolChild;
         }

         return null;
      }

      ///   
      ///	 <summary> * append a resource
      ///	 *  </summary>
      ///	 * <param name="name"> name of the resource to append
      ///	 *  </param>
      ///	 * <returns> JDFResource: the appended resource </returns>
      ///	 
      public virtual JDFResource appendResource(JDFResource res)
      {
         return (JDFResource)moveElement(res, null);
      }

      ///   
      ///	 <summary> * append a resource
      ///	 * <p>
      ///	 * default: AppendResource(name, resClass, null)
      ///	 *  </summary>
      ///	 * <param name="strName"> name of the resource to append </param>
      ///	 * <param name="resClass"> class of the resource to append </param>
      ///	 * <param name="nameSpaceURI"> the namespace for the resource
      ///	 *  </param>
      ///	 * <returns> JDFResource: the appended resource </returns>
      ///	 
      public virtual JDFResource appendResource(string strName, JDFResource.EnumResourceClass resClass, string nameSpaceURI)
      {
         KElement appElement = appendElement(strName, nameSpaceURI);
         if (appElement is JDFResource)
         {
            JDFResource r = (JDFResource)appElement;
            if (!r.hasAttribute(AttributeName.CLASS) && resClass != null)
            {
               r.setResourceClass(resClass);
            }
            return r;
         }
         return null;
      }

      ///   
      ///	 <summary> * copies a resource recursively, optionally fixes status flags and locks in the source resource
      ///	 * <p>
      ///	 * default: copyResource(r, null, new VJDFAttributeMap(), null)
      ///	 *  </summary>
      ///	 * <param name="r"> the resource to copy into this </param>
      ///	 * <param name="copyStatus"> rw or ro </param>
      ///	 * <param name="vParts"> part map vector of the partitions to copy </param>
      ///	 * <param name="spawnID"> the spawnID of the spawning that initiated the copy </param>
      ///	 * <returns> VString: vector of resource names that have been copied </returns>
      ///	 * @deprecated use JDFNode.copySpawnedResources
      ///	 * 
      ///	 *  
      ///	 
      [Obsolete("use JDFNode.copySpawnedResources")]
      public virtual VString copyResource(JDFResource r, JDFResource.EnumSpawnStatus copyStatus, VJDFAttributeMap vParts, string spawnID)
      {
         VString ss = getResIds();
         VString v = new VString();

         // r is not yet here copy r
         if (!ss.Contains(r.getID()))
         {
            JDFResource rNew = null;
            // if spawning, fix stati and locks
            if (copyStatus == JDFResource.EnumSpawnStatus.SpawnedRO)
            {
               // copy the complete resource as RO - no need to reduce
               // partitions
               r.appendSpawnIDs(spawnID);
               rNew = (JDFResource)copyElement(r, null);
               rNew.setLocked(true);
               r.setSpawnStatus(copyStatus);

            }
            else if (copyStatus == JDFResource.EnumSpawnStatus.SpawnedRW)
            {
               if (vParts.Count == 0)
               { // just copy the whole thing - no parts specified
                  r.appendSpawnIDs(spawnID);
                  rNew = (JDFResource)copyElement(r, null);
                  r.setSpawnStatus(copyStatus);
               }
               else
               {
                  rNew = (JDFResource)copyElement(r, null);
                  rNew.reducePartitions(vParts);
                  // reduce any unneeded leaves
                  // loop over all part maps to get best matching resource
                  for (int i = 0; i < vParts.Count; i++)
                  {
                     JDFResource pLeaf = r.getPartition(vParts[i], null);
                     JDFResource pNewLeaf = rNew.getPartition(vParts[i], null);
                     if (pLeaf != null)
                     {
                        pLeaf.setSpawnStatus(copyStatus);
                        pLeaf.appendSpawnIDs(spawnID);
                     }
                     if (pNewLeaf != null)
                     {
                        pNewLeaf.appendSpawnIDs(spawnID);
                     }
                  }
               }
            }

            if (rNew != null)
            {
               v.Add(rNew.getID());
            }
         }

         VString vs = r.getHRefs(null, false, true);
         // add recursively copied resources
         for (int i = 0; i < vs.Count; i++)
         {
            string id = vs[i];
            // the referenced resource is in this pool - continue
            if (ss.Contains(id))
            {
               continue;
            }

            // the referenced resource has already been merged in - continue
            if (v.Contains(id))
            {
               continue;
            }

            JDFResource next = (JDFResource)getDocRoot().getTarget(id, AttributeName.ID);
            if (next == null)
            {
               // 071101 RP added r is by definition in the original document
               // which also contains the rrefs elements
               next = (JDFResource)r.getDocRoot().getTarget(id, AttributeName.ID);
               // and now all those interlinked resources
               VString vv = copyResource(next, copyStatus, vParts, spawnID);
               v.AddRange(vv);
            }
         }

         return v;
      }

      ///   
      ///	 <summary> * Method GetPoolChildren Gets all children with the attribute name,mAttrib, nameSpaceURI out of the pool
      ///	 *  </summary>
      ///	 * <param name="name"> - name of the child </param>
      ///	 * <param name="mAttrib"> - a attribute to search for </param>
      ///	 * <param name="nameSpaceURI"> </param>
      ///	 * <returns> VElement - a vector with all elements in the pool matching the conditions
      ///	 * 
      ///	 *         default: GetPoolChildren(null, null, null) </returns>
      ///	 
      public virtual VElement getPoolChildren(string strName, JDFAttributeMap mAttrib, string nameSpaceURI)
      {
         return getPoolChildren_JDFResourcePool(strName, mAttrib, nameSpaceURI);
      }

      ///   
      ///	 <summary> * Method getPoolChildren_JDFResourcePool<br>
      ///	 * Gets all children with the attributes <code>name, mAttrib, nameSpaceURI</code> from the pool
      ///	 *  </summary>
      ///	 * <param name="name"> name of the child </param>
      ///	 * <param name="mAttrib"> attribute to search for </param>
      ///	 * <param name="nameSpaceURI"> namespace to search in </param>
      ///	 * <returns> VElement - a vector with all elements in the pool matching the conditions </returns>
      ///	 
      private VElement getPoolChildren_JDFResourcePool(string strName, JDFAttributeMap mAttrib, string nameSpaceURI)
      {
         VElement v = getPoolChildrenGeneric(strName, mAttrib, nameSpaceURI);

         for (int i = v.Count - 1; i >= 0; i--)
         {
            if (!(v[i] is JDFResource))
            {
               v.RemoveAt(i);
            }
         }
         return v;
      }

      ///   
      ///	 <summary> * Method getPoolChild<br>
      ///	 * get a child resource from the pool matching the parameters
      ///	 * <p>
      ///	 * default: GetPoolChild(i, null, null, null)
      ///	 *  </summary>
      ///	 * <param name="i"> the index of the child or -1 to make a new one. </param>
      ///	 * <param name="name"> the name of the element </param>
      ///	 * <param name="mAttrib"> the attribute of the element </param>
      ///	 * <param name="nameSpaceURI"> the namespace to search in </param>
      ///	 * <returns> JDFResource: the pool child matching the conditions above </returns>
      ///	 
      public virtual JDFResource getPoolChild(int i, string strName, JDFAttributeMap mAttrib, string nameSpaceURI)
      {
         return getPoolChild_JDFResourcePool(i, strName, mAttrib, nameSpaceURI);
      }

      ///   
      ///	 <summary> * Method getPoolChild_JDFResourcePool<br>
      ///	 * get a child resource from the pool matching the parameters
      ///	 *  </summary>
      ///	 * <param name="i"> the index of the child or -1 to make a new one. </param>
      ///	 * <param name="name"> the name of the element </param>
      ///	 * <param name="mAttrib"> the attribute of the element </param>
      ///	 * <param name="nameSpaceURI"> the namespace to search in </param>
      ///	 * <returns> JDFResource: the pool child matching the above conditions </returns>
      ///	 
      private JDFResource getPoolChild_JDFResourcePool(int i, string strName, JDFAttributeMap mAttrib, string nameSpaceURI)
      {
         int iLocal = i;

         VElement v = getPoolChildren(strName, mAttrib, nameSpaceURI);
         if (iLocal < 0)
         {
            iLocal = v.Count + iLocal;
            if (iLocal < 0)
            {
               return null;
            }
         }
         if (v.Count <= iLocal)
         {
            return null;
         }

         JDFResource jdfResource = (JDFResource)v[iLocal];
         return jdfResource;
      }

      ///   
      ///	 <summary> * return a vector of unknown element nodenames
      ///	 * <p>
      ///	 * default: GetUnknownElements(true, 99999999)
      ///	 *  </summary>
      ///	 * <param name="bIgnorePrivate"> ignores private elements. !Must be here to provide correct validation </param>
      ///	 * <param name="nMax"> - max entries in vector </param>
      ///	 * <returns> Vector of unknown element nodenames </returns>
      ///	 
      public override VString getUnknownElements(bool bIgnorePrivate, int nMax)
      {
         return getUnknownPoolElements(JDFElement.EnumPoolType.ResourcePool, nMax);

      }

      ///   
      ///	 <summary> * returns a the resource with ID=<code>id</code>, if it is in this pool
      ///	 *  </summary>
      ///	 * <param name="id"> the ID of the requested resource </param>
      ///	 * <returns> JDFResource: the resource, empty element if it does not exist </returns>
      ///	 
      public virtual JDFResource getResourceByID(string id)
      {
         KElement e = getChildWithAttribute(null, AttributeName.ID, null, id, 0, true);
         return (e is JDFResource) ? (JDFResource)e : null;

      }

      ///   
      ///	 <summary> * get refElements
      ///	 *  </summary>
      ///	 * <param name="vDoneRefs"> used internally for recursion </param>
      ///	 * <param name="bRecurse"> if true, also return recursively linked IDs </param>
      ///	 * <returns> HashSet: the vector of referenced resource IDs </returns>
      ///	 
      public override SupportClass.HashSetSupport getAllRefs(SupportClass.HashSetSupport vDoneRefs, bool bRecurse)
      {
         SupportClass.HashSetSupport vDoneRefsLocal = vDoneRefs;

         VElement vResources = getPoolChildren(null, null, null);
         int size = vResources.Count;
         for (int i = 0; i < size; i++)
         {
            JDFResource r = (JDFResource)vResources[i];
            vDoneRefsLocal = r.getResourceRoot().getAllRefs(vDoneRefsLocal, bRecurse);
         }

         return vDoneRefsLocal;
      }


      ///   
      ///	 <summary> * Mother of all version fixing routines<br>
      ///	 * 
      ///	 * Uses heuristics to modify this element and its children to be compatible with a given version.<br>
      ///	 * In general, it will be able to move from low to high versions, but potentially fail when attempting to move from
      ///	 * higher to lower versions.
      ///	 *  </summary>
      ///	 * <param name="version"> version that the resulting element should correspond to </param>
      ///	 * <returns> true if successful </returns>
      ///	 
      public override bool fixVersion(EnumVersion version)
      {
         if (hasAttribute(AttributeName.RREFS))
            removeAttribute(AttributeName.RREFS);
         return base.fixVersion(version);
      }


      ///   
      ///	 <summary> * get all completely unlinked resources
      ///	 *  </summary>
      ///	 * <returns> V the vector of unlinked resources. </returns>
      ///	 
      public virtual VElement getUnlinkedResources()
      {
         VElement v = getPoolChildren(null, null, null);
         if (v == null || v.Count == 0)
            return null;
         for (int i = v.Count - 1; i >= 0; i--)
         {
            JDFResource r = (JDFResource)v[i];
            VElement v2 = r.getLinksAndRefs(true, true);
            if (v2 != null)
               v.RemoveAt(i);
         }
         return v.Count == 0 ? null : v;
      }
   }
}
