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
 * Copyright (c) 2001-2005 Heidelberger Druckmaschinen AG, All Rights Reserved.
 *
 * JDFResourceLink.cs
 *
 * Last changes 2002-07-02 JG - added Get/SetProcessUsage 2002-07-02 JG - MyString -> KString :
 * all strings now 16 bit 2002-07-02 JG - now inherits from JDFElement 2002-07-02 JG -
 * GetProcessUsage and GetLinkedResourceName are now 2 sepaarte functions 2002-07-02 JG -
 * completely removed selector handling 2002-07-02 JG - HasResourcePartMap bug fix if no parts
 * in this - now returns true for no parts in this 2002-07-02 JG - removed JDFResource
 * GetPartition(boolean bCreate=false, int i=0); 2002-07-02 JG - added AppendPart 2002-07-02 JG -
 * added CombinedProcessIndex, PipeProtocol support 2002-07-02 JG - added AmountPool 2002-07-02
 * JG - added Transformation + Orientation support 2002-07-02 JG - removed GetAmount(boolean
 * bSelector) 2002-07-02 JG - removed GetPartTarget(int iPart=0,int iSelector=-1); 2002-07-02 JG -
 * modified GetNamedProcessUsage to default to xxx:Input / xxx:Output respectively 2002-07-02 JG -
 * SetPartition() now uses JDFResource::EnumPartIDKey 2002-07-02 JG - added GetTarget 2002-07-02
 * JG - GetTargetVector is now const 2002-07-02 JG - added GetTarget() 22-10-2003 KM -
 * IsExecutable() added bCheckChildren 22-10-2003 KM - IsExecutable() fixed bCheckChildren
 * 22-10-2003 KM - GetTarget() now returns the lowest common denominator resource if all leaves
 * are available 
 */


namespace org.cip4.jdflib.core
{
   using System;
   using System.Collections;
   using System.Collections.Generic;


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   using JDFAttributeMap = org.cip4.jdflib.datatypes.JDFAttributeMap;
   using JDFIntegerList = org.cip4.jdflib.datatypes.JDFIntegerList;
   using JDFMatrix = org.cip4.jdflib.datatypes.JDFMatrix;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using IAmountPoolContainer = org.cip4.jdflib.ifaces.IAmountPoolContainer;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using CombinedProcessIndexHelper = org.cip4.jdflib.node.JDFNode.CombinedProcessIndexHelper;
   using EnumProcessUsage = org.cip4.jdflib.node.JDFNode.EnumProcessUsage;
   using JDFAmountPool = org.cip4.jdflib.pool.JDFAmountPool;
   using JDFPool = org.cip4.jdflib.pool.JDFPool;
   using JDFResourceLinkPool = org.cip4.jdflib.pool.JDFResourceLinkPool;
   using AmountMap = org.cip4.jdflib.pool.JDFAmountPool.AmountMap;
   using AmountPoolHelper = org.cip4.jdflib.pool.JDFAmountPool.AmountPoolHelper;
   using JDFPart = org.cip4.jdflib.resource.JDFPart;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using EnumPartIDKey = org.cip4.jdflib.resource.JDFResource.EnumPartIDKey;
   using EnumPartUsage = org.cip4.jdflib.resource.JDFResource.EnumPartUsage;
   using EnumResStatus = org.cip4.jdflib.resource.JDFResource.EnumResStatus;
   using JDFLot = org.cip4.jdflib.resource.process.JDFLot;
   using JDFDate = org.cip4.jdflib.util.JDFDate;
   using JDFDuration = org.cip4.jdflib.util.JDFDuration;
   using StringUtil = org.cip4.jdflib.util.StringUtil;

   public class JDFResourceLink : JDFElement, IAmountPoolContainer
   {
      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.core.JDFElement#getInvalidAttributes(org.cip4.jdflib. core.KElement.EnumValidationLevel,
      //	 * boolean, int)
      //	 
      public override VString getInvalidAttributes(EnumValidationLevel level, bool bIgnorePrivate, int nMax)
      {
         VString v = base.getInvalidAttributes(level, bIgnorePrivate, nMax);
         if (!v.Contains(AttributeName.COMBINEDPROCESSINDEX) && !validCombinedProcessIndex())
            v.Add(AttributeName.COMBINEDPROCESSINDEX);
         return v;
      }

      public virtual void generateCombinedProcessIndex()
      {
         JDFNode n = getParentJDF();
         if (n != null)
         {
            VString types = n.getTypes();
            if (types != null)
               CombinedProcessIndexHelper.generateCombinedProcessIndex(getLinkRoot(), getUsage(), getEnumProcessUsage(), this, types);
         }
      }

      ///   
      ///	 * <param name="v"> </param>
      ///	 
      public virtual bool validCombinedProcessIndex()
      {
         JDFIntegerList vCombined = getCombinedProcessIndex();
         if (vCombined == null)
            return true;
         JDFNode parentJDF = getParentJDF();
         if (parentJDF == null)
         {
            return false;
         }
         VString types = parentJDF.getTypes();
         if (types == null)
         {
            return false;
         }
         int typSize = types.Count;
         int size = vCombined.Count;
         for (int i = 0; i < size; i++)
         {
            int combinedIndex = vCombined.getInt(i);
            if (combinedIndex < 0 || combinedIndex >= typSize)
            {
               return false;
            }
         }
         return true;
      }

      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable_Abstract = new AtrInfoTable[12];
      static JDFResourceLink()
      {
         atrInfoTable_Abstract[0] = new AtrInfoTable(AttributeName.COMBINEDPROCESSINDEX, 0x33333331, AttributeInfo.EnumAttributeType.IntegerList, null, null);
         atrInfoTable_Abstract[1] = new AtrInfoTable(AttributeName.COMBINEDPROCESSTYPE, 0x44444443, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable_Abstract[2] = new AtrInfoTable(AttributeName.DRAFTOK, 0x44444333, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable_Abstract[3] = new AtrInfoTable(AttributeName.MINLATESTATUS, 0x33333111, AttributeInfo.EnumAttributeType.enumeration, EnumResStatus.getEnum(0), null);
         atrInfoTable_Abstract[4] = new AtrInfoTable(AttributeName.MINSTATUS, 0x33333111, AttributeInfo.EnumAttributeType.enumeration, EnumResStatus.getEnum(0), null);
         atrInfoTable_Abstract[5] = new AtrInfoTable(AttributeName.PIPEPARTIDKEYS, 0x33333333, AttributeInfo.EnumAttributeType.enumerations, EnumPartIDKey.getEnum(0), null);
         atrInfoTable_Abstract[6] = new AtrInfoTable(AttributeName.PIPEPROTOCOL, 0x33333331, AttributeInfo.EnumAttributeType.NMTOKEN, null, null);
         atrInfoTable_Abstract[7] = new AtrInfoTable(AttributeName.PIPEURL, 0x33333333, AttributeInfo.EnumAttributeType.URL, null, null);
         atrInfoTable_Abstract[8] = new AtrInfoTable(AttributeName.PROCESSUSAGE, 0x33333333, AttributeInfo.EnumAttributeType.string_, null, null);
         atrInfoTable_Abstract[9] = new AtrInfoTable(AttributeName.RREF, 0x22222222, AttributeInfo.EnumAttributeType.IDREF, null, null);
         atrInfoTable_Abstract[10] = new AtrInfoTable(AttributeName.RSUBREF, 0x44444433, AttributeInfo.EnumAttributeType.IDREF, null, null);
         atrInfoTable_Abstract[11] = new AtrInfoTable(AttributeName.USAGE, 0x22222222, AttributeInfo.EnumAttributeType.enumeration, EnumUsage.getEnum(0), null);
         atrInfoTable_Physical[1] = new AtrInfoTable(AttributeName.ACTUALAMOUNT, 0x33333311, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable_Physical[0] = new AtrInfoTable(AttributeName.AMOUNT, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable_Physical[9] = new AtrInfoTable(AttributeName.MAXAMOUNT, 0x33333111, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable_Physical[8] = new AtrInfoTable(AttributeName.MINAMOUNT, 0x33333111, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable_Physical[3] = new AtrInfoTable(AttributeName.ORIENTATION, 0x33333331, AttributeInfo.EnumAttributeType.enumeration, EnumOrientation.getEnum(0), null);
         atrInfoTable_Physical[4] = new AtrInfoTable(AttributeName.PIPEPAUSE, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable_Physical[5] = new AtrInfoTable(AttributeName.PIPERESUME, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable_Physical[6] = new AtrInfoTable(AttributeName.REMOTEPIPEENDPAUSE, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable_Physical[7] = new AtrInfoTable(AttributeName.REMOTEPIPEENDRESUME, 0x33333333, AttributeInfo.EnumAttributeType.double_, null, null);
         atrInfoTable_Physical[2] = new AtrInfoTable(AttributeName.TRANSFORMATION, 0x33333331, AttributeInfo.EnumAttributeType.matrix, null, null);
         atrInfoTable_Implement[0] = new AtrInfoTable(AttributeName.DURATION, 0x33333333, AttributeInfo.EnumAttributeType.duration, null, null);
         atrInfoTable_Implement[1] = new AtrInfoTable(AttributeName.RECOMMENDATION, 0x44444433, AttributeInfo.EnumAttributeType.boolean_, null, null);
         atrInfoTable_Implement[2] = new AtrInfoTable(AttributeName.START, 0x33333333, AttributeInfo.EnumAttributeType.dateTime, null, null);
         atrInfoTable_Implement[3] = new AtrInfoTable(AttributeName.STARTOFFSET, 0x33333333, AttributeInfo.EnumAttributeType.duration, null, null);
         elemInfoTable[0] = new ElemInfoTable(ElementName.AMOUNTPOOL, 0x66666661);
         elemInfoTable[1] = new ElemInfoTable(ElementName.PART, 0x33333333);
         physInfoTable[0] = new ElemInfoTable(ElementName.LOT, 0x33333111);
      }

      private static AtrInfoTable[] atrInfoTable_Physical = new AtrInfoTable[10];

      private static AtrInfoTable[] atrInfoTable_Implement = new AtrInfoTable[4];

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         AttributeInfo ai = base.getTheAttributeInfo().updateReplace(atrInfoTable_Abstract);
         if (isPhysical() || LocalName.Equals(ElementName.PARTAMOUNT))
         {
            ai.updateAdd(atrInfoTable_Physical);
         }
         else if (isImplementation() || LocalName.Equals(ElementName.PARTAMOUNT))
         {
            ai.updateAdd(atrInfoTable_Implement);
         }
         return ai;
      }

      private static ElemInfoTable[] elemInfoTable = new ElemInfoTable[2];

      private static ElemInfoTable[] physInfoTable = new ElemInfoTable[1];


      protected internal override ElementInfo getTheElementInfo()
      {
         ElementInfo ei = base.getTheElementInfo().updateReplace(elemInfoTable);
         if (this.isPhysical())
            ei.updateAdd(physInfoTable);
         return ei;
      }


      ///   
      ///	 <summary> * Constructor for JDFResourceLink
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> owner document </param>
      ///	 * <param name="qualifiedName"> qualified name </param>
      ///	 
      public JDFResourceLink(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFResourceLink
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> owner documen </param>
      ///	 * <param name="myNamespaceURI"> namespace URI </param>
      ///	 * <param name="qualifiedName"> qualified name </param>
      ///	 
      public JDFResourceLink(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFResourceLink
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> owner documen </param>
      ///	 * <param name="myNamespaceURI"> namespace URI </param>
      ///	 * <param name="qualifiedName"> qualified name </param>
      ///	 * <param name="myLocalName"> local name </param>
      ///	 
      public JDFResourceLink(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      ///   
      ///	 <summary> * Enumeration for Orientation </summary>
      ///	 
      public new sealed class EnumOrientation : ValuedEnum
      {
         private const long serialVersionUID = 1L;

         private static int m_startValue = 0;

         private EnumOrientation(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumOrientation getEnum(string enumName)
         {
            return (EnumOrientation)getEnum(typeof(EnumOrientation), enumName);
         }

         public static EnumOrientation getEnum(int enumValue)
         {
            return (EnumOrientation)getEnum(typeof(EnumOrientation), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumOrientation));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumOrientation));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumOrientation));
         }

         public static readonly EnumOrientation Flip0 = new EnumOrientation("Flip0");

         public static readonly EnumOrientation Flip90 = new EnumOrientation("Flip90");

         public static readonly EnumOrientation Flip180 = new EnumOrientation("Flip180");

         public static readonly EnumOrientation Flip270 = new EnumOrientation("Flip270");

         public static readonly EnumOrientation Rotate0 = new EnumOrientation("Rotate0");

         public static readonly EnumOrientation Rotate90 = new EnumOrientation("Rotate90");

         public static readonly EnumOrientation Rotate180 = new EnumOrientation("Rotate180");

         public static readonly EnumOrientation Rotate270 = new EnumOrientation("Rotate270");

         public static readonly EnumOrientation Matrix = new EnumOrientation("Matrix");
      }

      ///   
      ///	 <summary> * Enumeration for attribute Usage </summary>
      ///	 
      public sealed class EnumUsage : ValuedEnum
      {
         private const long serialVersionUID = 1L;

         private static int m_startValue = 0;

         private EnumUsage(string name)
            : base(name, m_startValue++)
         {
         }

         public static EnumUsage getEnum(string enumName)
         {
            return (EnumUsage)getEnum(typeof(EnumUsage), enumName);
         }

         public static EnumUsage getEnum(int enumValue)
         {
            return (EnumUsage)getEnum(typeof(EnumUsage), enumValue);
         }

         public static IDictionary getEnumMap()
         {
            return getEnumMap(typeof(EnumUsage));
         }

         public static IList getEnumList()
         {
            return getEnumList(typeof(EnumUsage));
         }

         public static IEnumerator iterator()
         {
            return iterator(typeof(EnumUsage));
         }

         public static readonly EnumUsage Input = new EnumUsage("Input");

         public static readonly EnumUsage Output = new EnumUsage("Output");

      }

      ///   
      ///	 <summary> * toString
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public override string ToString()
      {
         return "JDFResourceLink[ --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * version fixing routine for JDF
      ///	 * 
      ///	 * uses heuristics to modify this element and its children to be compatible with a given version<br>
      ///	 * in general, it will be able to move from low to high versions, but potentially fail when attempting to move from
      ///	 * higher to lower versions
      ///	 *  </summary>
      ///	 * <param name="version"> version that the resulting element should correspond to </param>
      ///	 * <returns> true if successful </returns>
      ///	 
      public override bool fixVersion(EnumVersion version)
      {
         const bool bRet = true;
         if (version != null)
         {
            if (version.getValue() >= EnumVersion.Version_1_3.getValue())
            {
               if (hasAttribute(AttributeName.DRAFTOK))
               {
                  if (!hasAttribute(AttributeName.MINSTATUS))
                     setMinStatus(EnumResStatus.Draft);
                  removeAttribute(AttributeName.DRAFTOK);
               }
            }
            else
            {
               if (hasAttribute(AttributeName.MINSTATUS))
               {
                  if (!hasAttribute(AttributeName.DRAFTOK))
                     setDraftOK(true);
                  removeAttribute(AttributeName.MINSTATUS);
               }
               removeAttribute(AttributeName.MINLATESTATUS);
            }
         }
         return base.fixVersion(version) && bRet;

      }

      ///   
      ///	 <summary> * setTarget - sets the link to the target defined by partLeaf. Automatically generates a part subelement, if
      ///	 * partleaf is not the root resource
      ///	 *  </summary>
      ///	 * <param name="resourceTarget"> the resource that this ResourceLink shoud refer to
      ///	 *  </param>
      ///	 * <exception cref="JDFException"> if an attempt is made to link to a resource sub-element </exception>
      ///	 * <returns> boolean - always true </returns>
      ///	 
      public virtual bool setTarget(JDFResource resourceTarget)
      {
         if (resourceTarget.isResourceElement())
            throw new JDFException("attempting to link to a resource subelement");

         appendHRef(resourceTarget.getResourceRoot(), JDFConstants.RREF, null);

         if (!resourceTarget.isResourceRoot())
         {
            removeChildren(ElementName.PART, null, null);
            JDFAttributeMap mPart = resourceTarget.getPartMap();
            if (mPart != null && mPart.Count > 0)
            {
               JDFElement part = appendPart();
               part.setAttributes(mPart);
            }
         }

         return true;
      }

      ///   
      ///	 <summary> * get double attribute Amount, defaults to the value of Amount for the linked partition
      ///	 *  </summary>
      ///	 * <param name="mPart"> partition map to retrieve Amount for </param>
      ///	 * <returns> the amount, -1 if none is specified
      ///	 * 
      ///	 * @default getAmount(null) </returns>
      ///	 
      public virtual double getAmount(JDFAttributeMap mPart)
      {
         return AmountPoolHelper.getAmount(this, mPart);
      }

      ///   
      ///	 <summary> * get double attribute MinAmount, defaults to getAmount if MinAmount is not set
      ///	 *  </summary>
      ///	 * <param name="mPart"> partition map to retrieve MinAmount for </param>
      ///	 * <returns> the MinAmount value
      ///	 * @default getAmount(null) </returns>
      ///	 
      public virtual double getMinAmount(JDFAttributeMap mPart)
      {
         return AmountPoolHelper.getMinAmount(this, mPart);
      }

      ///   
      ///	 <summary> * get double attribute MaxAmount, defaults to getAmount if MinAmount is not set
      ///	 *  </summary>
      ///	 * <param name="mPart"> partition map to retrieve MaxAmount for </param>
      ///	 * <returns> the MaxAmount value
      ///	 * @default getAmount(null) </returns>
      ///	 
      public virtual double getMaxAmount(JDFAttributeMap mPart)
      {
         return AmountPoolHelper.getMaxAmount(this, mPart);
      }

      ///   
      ///	 <summary> * getLinkRoot - gets the root resource of the target
      ///	 *  </summary>
      ///	 * <returns> JDFResource </returns>
      ///	 
      public virtual JDFResource getLinkRoot()
      {
         JDFResource eLink = base.getLinkRoot(null);
         if (eLink != null)
         {
            if (!(eLink.Name.Equals(getLinkedResourceName())))
            {
               return null;
            }
         }
         return eLink;
      }

      ///   
      ///	 <summary> * getLinkTarget
      ///	 *  </summary>
      ///	 * <returns> JDFResource </returns>
      ///	 * @deprecated never used 
      ///	 
      [Obsolete("never used")]
      public virtual JDFResource getLinkTarget()
      {
         return getTarget();
      }

      ///   
      ///	 <summary> * setQuantity
      ///	 *  </summary>
      ///	 * <param name="quant"> </param>
      ///	 
      public virtual void setQuantity(int quant)
      {
         setAttribute(AttributeName.AMOUNT, quant, null);
      }

      ///   
      ///	 <summary> * setAmount in PartAmount or in this if partAmount=null
      ///	 *  </summary>
      ///	 * <param name="value"> amount to set </param>
      ///	 * <param name="mPart"> partition map to set amount for
      ///	 * 
      ///	 * @default setAmount(double value, null) </param>
      ///	 
      public virtual void setAmount(double @value, JDFAttributeMap mPart)
      {
         setAmountPoolAttribute(AttributeName.AMOUNT, StringUtil.formatDouble(@value), null, mPart);
      }

      ///   
      ///	 <summary> * set MinAmount in PartAmount or in this if partAmount=null
      ///	 *  </summary>
      ///	 * <param name="value"> amount to set </param>
      ///	 * <param name="mPart"> partition map to set amount for
      ///	 * 
      ///	 * @default setAmount(double value, null) </param>
      ///	 
      public virtual void setMinAmount(double @value, JDFAttributeMap mPart)
      {
         setAmountPoolAttribute(AttributeName.MINAMOUNT, StringUtil.formatDouble(@value), null, mPart);
      }

      ///   
      ///	 <summary> * set MaxAmount in PartAmount or in this if partAmount=null
      ///	 *  </summary>
      ///	 * <param name="value"> amount to set </param>
      ///	 * <param name="mPart"> partition map to set amount for
      ///	 * 
      ///	 * @default setAmount(double value, null) </param>
      ///	 
      public virtual void setMaxAmount(double @value, JDFAttributeMap mPart)
      {

         setAmountPoolAttribute(AttributeName.MAXAMOUNT, StringUtil.formatDouble(@value), null, mPart);
      }

      ///   
      ///	 <summary> * get the status of the Resource that is linked by this link
      ///	 *  </summary>
      ///	 * <returns> JDFResource.EnumResStatus </returns>
      ///	 
      public virtual JDFResource.EnumResStatus getStatusJDF()
      {
         return JDFResource.EnumResStatus.getEnum(getLinkRoot().getResStatus(false).getName());
      }

      ///   
      ///	 <summary> * set the status of the Resource that is linked by this link
      ///	 *  </summary>
      ///	 * <param name="s"> value to set </param>
      ///	 
      public virtual void setStatus(JDFResource.EnumResStatus s)
      {
         VElement targets = getTargetVector(-1);
         for (int i = 0; i < targets.Count; i++)
         {
            ((JDFResource)targets[i]).setResStatus(s, true);
         }
      }

      ///   
      ///	 <summary> * check whether the resource is in the same node as the link
      ///	 *  </summary>
      ///	 * <returns> true, if the linked resource resides in the same node </returns>
      ///	 
      public virtual bool isLocal()
      {
         JDFElement linkParent = getParentJDF();
         JDFElement resParent = getTarget().getParentJDF();
         return resParent.isEqual(linkParent);
      }

      ///   
      ///	 <summary> * get first Part element beyond i
      ///	 *  </summary>
      ///	 * <param name="i"> number of elements to skip
      ///	 *  </param>
      ///	 * <returns> JDFResource
      ///	 * 
      ///	 * @default getPart(0) </returns>
      ///	 
      public virtual JDFPart getPart(int i)
      {
         return (JDFPart)getElement(ElementName.PART, null, i);
      }

      ///   
      ///	 <summary> * get element Part, create if it does not exist
      ///	 *  </summary>
      ///	 * <param name="i"> number of elements to skip
      ///	 *  </param>
      ///	 * <returns> JDFResource
      ///	 * 
      ///	 * @default getCreatePart(0) </returns>
      ///	 
      public virtual JDFPart getCreatePart(int i)
      {
         return (JDFPart)getCreateElement_KElement(ElementName.PART, null, i);
      }

      ///   
      ///	 <summary> * get element Audit
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public virtual string getAuditString()
      {
         string s = Name;
         //.Net Substring different than java substring.
         return s.Substring(3, s.Length - 3) + JDFConstants.AUDIT;
      }

      ///   
      ///	 <summary> * getParts - get the vector of part elements, note that a resource link with multiple part elements is effectively
      ///	 * an OR of these parts
      ///	 *  </summary>
      ///	 * <returns> VElement </returns>
      ///	 
      public virtual VElement getParts()
      {
         return getChildElementVector(ElementName.PART, null, null, true, 0, false);
      }

      ///   
      ///	 <summary> * setPart - shorthand if only one part is required, should be set to key = value
      ///	 *  </summary>
      ///	 * <param name="key"> the partition key </param>
      ///	 * <param name="value"> the partition value </param>
      ///	 
      public virtual void setPart(string key, string @value)
      {
         JDFPart part = getCreatePart(0);
         part.setAttribute(key, @value, null);
      }

      ///   
      ///	 <summary> * shorthand if only one part is required, should be set to key = value
      ///	 *  </summary>
      ///	 * <param name="key"> the partition key </param>
      ///	 * <param name="value"> the partition value </param>
      ///	 
      public virtual void setPartition(JDFResource.EnumPartIDKey key, string @value)
      {
         while (hasChildElement(ElementName.PART, null))
         {
            removePart(0);
         }

         JDFPart part = getCreatePart(0);
         part.setAttribute(key.getName(), @value, null);
      }

      ///   
      ///	 <summary> * remove element Part
      ///	 *  </summary>
      ///	 * <param name="iSkip"> number of elements to skip
      ///	 * 
      ///	 * @default removePart(0) </param>
      ///	 
      public virtual void removePart(int iSkip)
      {
         removeChild(ElementName.PART, null, iSkip);
      }

      ///   
      ///	 <summary> * isExecutable - checks whether the resource link links to a resource, which is in a state that will allow a node
      ///	 * to execute
      ///	 *  </summary>
      ///	 * <param name="partMap"> the attribute map of parts </param>
      ///	 * <param name="bCheckChildren"> if true, calculates the availability status of a resource from all child partition leaves,
      ///	 *            else the status is taken from the appropriate leaf itself
      ///	 *  </param>
      ///	 * <returns> boolean - true if the node is executable, false if not
      ///	 * 
      ///	 * @default isExecutable(null, true) </returns>
      ///	 
      public virtual bool isExecutable(JDFAttributeMap partMap, bool bCheckChildren)
      {
         if (!hasResourcePartMap(partMap, false))
         {
            return false;
         }

         VElement leaves = new VElement();
         bool bExec = false;

         if (bCheckChildren)
         {
            VElement leaves2 = getTargetVector(-1);
            for (int i = 0; i < leaves2.Count; i++)
            {
               JDFResource p = (JDFResource)leaves2[i];
               if (p == null)
               {
                  continue;
               }
               VElement targetVector = p.getLeaves(false);
               leaves.addAll(targetVector);
            }
         }

         else
         { // calculate availability directly, but only for the subelements as
            // specified by partMap
            VElement leaves2 = getTargetVector(-1);
            for (int i = 0; i < leaves2.Count; i++)
            {
               JDFResource leaf = (JDFResource)leaves2[i];
               leaf = leaf.getPartition(partMap, null);
               if (leaf != null)
                  leaves.Add(leaf);
            }
         }
         leaves.unify();

         for (int i = 0; i < leaves.Count; i++)
         {
            JDFResource leaf = (JDFResource)leaves[i];
            if (partMap != null && !partMap.IsEmpty() && !partMap.overlapMap(leaf.getPartMap()))
               continue;

            JDFResource.EnumResStatus status = leaf.getResStatus(true);
            if (status.Equals(JDFResource.EnumResStatus.InUse))
            {
               return false;
            }

            bExec = getMinStatus().getValue() <= status.getValue();
            // any leaf not executable --> the whole thing is not executable
            if (!bExec)
            {
               return false;
            }
         }
         return true;
      }

      ///   
      ///	 <summary> * get the parent ResourceLinkPool
      ///	 *  </summary>
      ///	 * <returns> JDFResourceLinkPool - the parent ResourceLinkPool </returns>
      ///	 
      protected internal virtual JDFResourceLinkPool getResourceLinkPool()
      {
         if (getParentNode_KElement() != null)
         {
            return (JDFResourceLinkPool)getParentNode_KElement();
         }

         return null;
      }

      ///   
      ///	 <summary> * gets the first resource leaf that this resourcelink refers to<br>
      ///	 * see the description of <seealso cref="#getTargetVector(int) getTargetVector"/> for details
      ///	 * 
      ///	 * overrides the deprecated method JDFElement.getTarget()
      ///	 * 
      ///	 * @since 102103 GetTarget returns the lowest common denominator 
      ///	 * 				 if all children of a resource are referenced
      ///	 *  </summary>
      ///	 * <returns> JDFResource - the first leaf that is referenced by this ResourceLink </returns>
      ///	 
      public new JDFResource getTarget()
      {
         VElement v = getTargetVector(-1);
         if (v == null)
         {
            return null;
         }
         return (JDFResource)v.getCommonAncestor();
      }

      ///   
      ///	 <summary> * Method getTargetVector gets the resource nodes this resourcelink refers to. Skips links that do not exist or
      ///	 * where the name mangling is illegal.<br>
      ///	 * Actual behavior varies according to the value of PartUsage of the referenced resource:<br>
      ///	 * if PartUsage="Explicit", all elements that are referenced in PartIDKeys and the ResourceLink must exist and fit<br>
      ///	 * if PartUsage="Implicit", the best fitting intermediate node of the partitioned resource is returned.<br>
      ///	 * Attributes in the Part elements, that are not referenced in PartIDKeys, are assumed to be logical attributes
      ///	 * (e.g. RunIndex of a RunList) and ignored when searching the part.
      ///	 *  </summary>
      ///	 * <param name="nMax"> maximum number of requested resources; -1= all
      ///	 *  </param>
      ///	 * <returns> VElement - the set of leaves that are referenced by this ResourceLink
      ///	 * 
      ///	 * @default getTargetVector(-1) </returns>
      ///	 
      public virtual VElement getTargetVector(int nMax)
      {
         // split it into leaves
         // 221003 changed GetResourcePartMapVector to GetPartMapVector
         VJDFAttributeMap vmParts = getPartMapVector();
         return getMapTargetVector(vmParts, nMax);
      }

      ///   
      ///	 <summary> * Gets the resource nodes this resourcelink refers to. Skips links that do not exist or where the name mangling is
      ///	 * illegal.<br>
      ///	 * Actual behavior varies according to the value of PartUsage of the referenced resource:<br>
      ///	 * if PartUsage="Explicit", all elements that are referenced in PartIDKeys and the ResourceLink must exist and fit<br>
      ///	 * if PartUsage="Implicit", the best fitting intermediate node of the partitioned resource is returned.<br>
      ///	 * Attributes in the Part elements, that are not referenced in PartIDKeys, are assumed to be logical attributes
      ///	 * (e.g. RunIndex of a RunList) and ignored when searching the part.
      ///	 *  </summary>
      ///	 * <param name="vmParts"> target map to use </param>
      ///	 * <param name="nMax"> maximum number of requested resources; -1= all </param>
      ///	 * <returns> VElement the set of leaves that are referenced by this ResourceLink </returns>
      ///	 
      private VElement getMapTargetVector(VJDFAttributeMap vmParts, int nMax)
      {
         VElement v = new VElement();
         // get the resource root
         JDFResource resRoot = getLinkRoot();
         if (resRoot == null)
         {
            return v;
         }

         if (vmParts == null || vmParts.IsEmpty())
         {
            v.Add(resRoot);
            return v;
         }
         // get the value of PartUsage
         JDFResource.EnumPartUsage partUsage = resRoot.getPartUsage();

         if (partUsage.Equals(JDFResource.EnumPartUsage.Implicit))
         {
            vmParts.reduceMap(resRoot.getPartIDKeys().getSet());
         }
         if (vmParts.IsEmpty())
         {
            v.Add(resRoot);
            return v;
         }

         int partSize = vmParts.Count;
         for (int i = 0; i < partSize; i++)
         {
            VElement vr = resRoot.getPartitionVector(vmParts[i], partUsage);
            if (vr != null && !vr.IsEmpty())
            {
               v.AddRange(vr);
               // we have enough!
               if (v.Count == nMax)
               {
                  break;
               }
            }
         }
         return v;
      }

      ///   
      ///	 <summary> * get the parent ResourceLinkPool
      ///	 *  </summary>
      ///	 * <returns> the parent ResourceLinkPool </returns>
      ///	 
      public virtual JDFPool getPool()
      {
         KElement deepParentNotName = getDeepParentNotName(LocalName);
         if (deepParentNotName != null)
         {
            return (JDFPool)deepParentNotName;
         }
         return null;
      }

      ///   
      ///	 <summary> * checks whether a given partMap is compatible with this link
      ///	 *  </summary>
      ///	 * <param name="partMap"> the map of parts that this link is compared to </param>
      ///	 * <param name="bCheckResource"> if true, also recurse into the resource and check if the parts exist
      ///	 *  </param>
      ///	 * <returns> boolean - true if this is compatible with partMap
      ///	 * 
      ///	 * @default HasResourcePartMap(partMap, false) </returns>
      ///	 
      public virtual bool hasResourcePartMap(JDFAttributeMap partMap, bool bCheckResource)
      {
         // TODO remove implicit partitions
         // Attention !!!
         // Don't change this method without checking if routing is still working
         // !
         // The C++ method is different and is not used, the java method is used
         // for routing.
         JDFResource linkRoot = getLinkRoot();
         if (linkRoot == null)
            return false;

         VJDFAttributeMap vPart;
         EnumPartUsage partUsage = linkRoot.getPartUsage();
         bool bImplicit = JDFResource.EnumPartUsage.Implicit.Equals(partUsage);
         if (bCheckResource)
         {
            if ((partMap == null || partMap.IsEmpty()))
            {
               return true;
            }
            JDFResource partition = linkRoot.getPartition(partMap, partUsage);
            if (partition != null && partition != linkRoot)
            {
               return true;
            }
            else if (bImplicit)
            {
               KElement childByTagName = linkRoot.getElement(linkRoot.Name);
               if (childByTagName == null)
               {
                  // there is no partition
                  return true;
               }
            }
         }
         else
         {
            vPart = getPartMapVector();
            if ((partMap == null || partMap.IsEmpty()) && (vPart == null || vPart.IsEmpty()))
            {
               return true;
            }

            int siz = vPart == null ? 0 : vPart.Count;
            if (bImplicit)
            {
               if (siz == 0 || vPart == null)
               {
                  return true;
               }

               for (int i = 0; i < siz; i++)
               {
                  if (vPart[i].overlapMap(partMap))
                     return true;
               }
            }
            else
            { // explicit
               if (siz == 0 && !bCheckResource)
               {
                  return true;
               }

               if (vPart != null)
               {
                  for (int i = 0; i < siz; i++)
                  {
                     JDFAttributeMap part = vPart[i];
                     if (part == null || part.Count == 0)
                        return true;

                     // RP 050120 swap of vPart[i] and partmap
                     // RP 070511 swap back of vPart[i] and partmap
                     if (part.subMap(partMap))
                        return true;
                  }
               }
            }
         }

         return false;
      }

      ///   
      ///	 * <param name="partMap"> </param>
      ///	 * <returns> boolean </returns>
      ///	 
      public virtual bool overlapsResourcePartMap(JDFAttributeMap partMap)
      {
         if (partMap.IsEmpty())
         {
            return true; // speed up...
         }

         VJDFAttributeMap vPart = getPartMapVector();

         int siz = vPart == null ? 0 : vPart.Count;
         // if no part, any resource that is linked is valid
         if (siz == 0)
         {
            return true;
         }

         if (vPart != null)
         {
            for (int i = 0; i < siz; i++)
            {
               if (vPart[i].overlapMap(partMap))
                  return true;
            }
         }

         return false;
      }

      ///   
      ///	 <summary> * Check whether a resource is selected by a ResourceLink.<br>
      ///	 * A resource is selected if all (partition) leaves are selected by the resource link
      ///	 *  </summary>
      ///	 * <param name="resourceToCheck"> The resource which may be selected by the ResourceLink.
      ///	 * 
      ///	 *            This ResourceLink must always be the full ResourceLink, i.e. Part Elements are not allowed as
      ///	 *            parameters.
      ///	 *  </param>
      ///	 * <returns> true, if the resource link selects the resource </returns>
      ///	 
      public virtual bool isResourceSelected(JDFResource resourceToCheck)
      {
         // For the decision, compare the leaves of the Resource with the Leaves
         // pointed to by the
         // resource link. If all leaves of the Resource are pointed to by the
         // ResourceLink, then the
         // ResourceLink selects the Resource (partition). This method checks if
         // the leaves
         // represented by the
         // Resource are a subset of the leaves represented by the ResourceLink
         bool b_ResurceIsSelected = false;

         // get the resource leaves from resource and resource link
         VElement resourceLeavesFromResource = resourceToCheck.getLeaves(false);
         VElement resourceLeavesFromLink = getTargetVector(-1);

         // number of resources found
         int i_NoResourceLeavesFromResource = resourceLeavesFromResource.Count;
         int i_NoResourceLeavesFromLink = resourceLeavesFromLink.Count;

         // compare Resource Vectors if they contain the same Resources (here
         // ResourceLeaves)
         // Ordering
         // of verctors is not important
         // Note: a method vResource::IsSubSet(vResource) would help here; the
         // following is an
         // implementation
         // for this

         int i_CurrentLeafFromResource = 0;
         int i_CurrentLeafFromLink = 0;

         // look if every Resource leaf from the ResourceLeavesFromResource is in
         // the
         // ResourceLeavesFromLink
         // vector
         bool b_SelectionIsPossible = true;
         while (b_SelectionIsPossible && i_CurrentLeafFromResource < i_NoResourceLeavesFromResource)
         {
            // get ResourceLeaf from Resource Vector to compare
            JDFResource currentLeafFromResource = (JDFResource)resourceLeavesFromResource[i_CurrentLeafFromResource];

            // compare with ResourceLeaf in ResourceLink vector till the
            // Resource is found
            // iterate the vector with leaves from ResourceLinks
            bool b_ResourceFoundInLink = false;
            while (!b_ResourceFoundInLink && i_CurrentLeafFromLink < i_NoResourceLeavesFromLink)
            {
               JDFResource currentLeafFromLink = (JDFResource)resourceLeavesFromLink[i_CurrentLeafFromLink];
               b_ResourceFoundInLink = currentLeafFromResource == currentLeafFromLink;
               i_CurrentLeafFromLink++;
            }

            // if value is false, one partition is not selected => whole
            // resource is not selected
            b_SelectionIsPossible = b_ResourceFoundInLink;
            i_CurrentLeafFromResource++;
         }

         b_ResurceIsSelected = b_SelectionIsPossible;

         return b_ResurceIsSelected;
      }

      ///   
      ///	 <summary> * get part map vector as defined by the linked resource. This returns the vector of leaves that would be returned.
      ///	 *  </summary>
      ///	 * <returns> vector of mAttribute, one for each part </returns>
      ///	 
      public virtual VJDFAttributeMap getResourcePartMapVector()
      {
         VJDFAttributeMap vMap = new VJDFAttributeMap();
         VJDFAttributeMap vPartMap = getPartMapVector();
         int nPartChildren = vPartMap == null ? 0 : vPartMap.Count;
         JDFResource root = getLinkRoot();

         VElement leaves = root.getLeaves(false);
         // loop over resource leaves
         for (int i = 0; i < leaves.Count; i++)
         {
            JDFAttributeMap leafMap = ((JDFResource)leaves[i]).getPartMap();
            if (nPartChildren > 0 && vPartMap != null) // suppress possible NPE warning for vPartMap
            { // it's reduced
               for (int j = 0; j < nPartChildren; j++)
               {
                  JDFAttributeMap mPart = vPartMap[j];
                  if (!mPart.overlapMap(leafMap))
                  {
                     continue;
                  }

                  // got one; break both loops and continue with the next leaf
                  vMap.Add(leafMap.orMap(mPart));
               }
            }
            else
            {
               // no parts in the resourcelink -> simply append the resources partmap
               vMap.Add(leafMap);
            }
         }

         return vMap.Count == 0 ? null : vMap;
      }

      ///   
      ///	 <summary> * Returns the linked resource name
      ///	 *  </summary>
      ///	 * <returns> String - the name </returns>
      ///	 
      public virtual string getLinkedResourceName()
      {
         string nodeName = Name;
         int length = nodeName.Length;
         if (length <= 4)
            throw new JDFException("invalid nodename for resource link");
         return nodeName.Substring(0, length - JDFConstants.LINK.Length);

      }

      ///   
      ///	 <summary> * Get the expected name of the linked resource and an optional processusage in name:usage format. If no
      ///	 * processusage is available, return GetLinkedResourceName:input / GetLinkedResourceName:output respectively.
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public virtual string getNamedProcessUsage()
      {
         string s = getProcessUsage();
         // 030502 RP modified to default tx xxx:Input / xxx:Output respectively
         if (isWildCard(s))
         {
            // 200602 RP need the string type - don't cycle to and from enum
            // type...
            s = getAttribute(AttributeName.USAGE, null, JDFConstants.EMPTYSTRING);

         }

         s = getLinkedResourceName() + JDFConstants.COLON + s;

         return s;
      }

      ///   
      ///	 <summary> * checks whether the resource lives in the same node or an ancestor node of the link
      ///	 *  </summary>
      ///	 * <returns> true, if the linked resource resides in a legal node </returns>
      ///	 
      public virtual bool validResourcePosition()
      {
         return validResourcePosition(getLinkRoot());
      }

      ///   
      ///	 <summary> * default validator
      ///	 *  </summary>
      ///	 * <param name="level"> validation level </param>
      ///	 * <seealso cref= org.cip4.jdflib.core.JDFElement#isValid(org.cip4.jdflib.core.KElement.EnumValidationLevel) </seealso>
      ///	 
      public override bool isValid(EnumValidationLevel level)
      {
         EnumValidationLevel levelLocal = level;

         if (levelLocal == null)
            levelLocal = EnumValidationLevel.Complete;

         bool b = base.isValid(levelLocal);
         if (!b)
            return false;

         if (this is JDFPartAmount)
            return true;

         if ((levelLocal != EnumValidationLevel.Complete) && (levelLocal != EnumValidationLevel.Incomplete) && (levelLocal != EnumValidationLevel.RecursiveIncomplete))
            return true;

         if (!validResourcePosition())
            return false;

         VElement vRes = getTargetVector(0);
         if ((vRes == null || vRes.IsEmpty()) && ((levelLocal == EnumValidationLevel.Complete) || (levelLocal == EnumValidationLevel.RecursiveComplete)))
         {
            // if any partition points to nirvana and we are validating
            // complete, the entire resource is invalid
            return false;
         }

         if (levelLocal.Equals(EnumValidationLevel.Complete))
            return true;

         if (vRes != null)
         {
            for (int iRes = 0; iRes < vRes.Count; iRes++)
            {
               JDFResource r = (JDFResource)vRes[iRes];
               // reslinks that point to nothing may be valid

               // but they certainly aren't valid if they point to the wrong
               // resource
               if (!Name.Equals(r.getLinkString()))
                  return false;

               if (levelLocal.getValue() >= EnumValidationLevel.RecursiveIncomplete.getValue())
               {
                  EnumValidationLevel valDown = (levelLocal == EnumValidationLevel.RecursiveIncomplete) ? EnumValidationLevel.Incomplete : EnumValidationLevel.Complete;

                  if (!r.isValid(valDown))
                     return false;
               }
            }
         }

         return true;
      }

      ///   
      ///	 <summary> * checks whether this is a link to a physical resource.<br>
      ///	 * Note that this method only works on links to resources that have a valid "Class" attribute.
      ///	 *  </summary>
      ///	 * <returns> true, if the link links to a physical resource </returns>
      ///	 
      public virtual bool isPhysical()
      {
         bool fIsPhysical = false;
         JDFResource resource = getLinkRoot();
         if (resource != null)
         {
            fIsPhysical = resource.isPhysical();
         }

         return fIsPhysical;
      }

      ///   
      ///	 * <returns> boolean </returns>
      ///	 
      public virtual bool isImplementation()
      {
         bool fIsImplementation = false;
         JDFResource linkRoot = getLinkRoot();
         if (linkRoot != null)
         {
            if (linkRoot.getResourceClass() == JDFResource.EnumResourceClass.Implementation)
            {
               fIsImplementation = true;
            }
         }
         return fIsImplementation;
      }

      ///   
      ///	 <summary> * append element Part </summary>
      ///	 
      public virtual JDFPart appendPart()
      {
         return (JDFPart)appendElement(ElementName.PART, null);
      }

      public virtual JDFAmountPool getAmountPool()
      {
         return (JDFAmountPool)getElement(ElementName.AMOUNTPOOL, null, 0);
      }

      public virtual JDFAmountPool getCreateAmountPool()
      {
         if (this is JDFPartAmount)
         {
            throw new JDFException("JDFResourceLink.getCreateAmountPool: calling method on PartAmount object");
         }
         return (JDFAmountPool)getCreateElement_KElement(ElementName.AMOUNTPOOL, null, 0);
      }

      public virtual JDFAmountPool appendAmountPool()
      {
         // ideally the method would be hidden in PartAmount
         if (this is JDFPartAmount)
         {
            throw new JDFException("JDFResourceLink.appendAmountPool: calling method on PartAmount object");
         }
         return (JDFAmountPool)appendElementN(ElementName.AMOUNTPOOL, 1, null);
      }

      ///   
      ///	 <summary> * get the nTh Lot element
      ///	 *  </summary>
      ///	 * <param name="n"> the index of the element </param>
      ///	 * <returns> the nth Lot, null if it does not exist </returns>
      ///	 
      public virtual JDFLot getLot(int n)
      {
         return (JDFLot)getElement(ElementName.LOT, null, n);
      }

      ///   
      ///	 <summary> * get the nTh Lot element
      ///	 *  </summary>
      ///	 * <param name="n"> the index of the element </param>
      ///	 * <returns> the nth Lot, creates all Lots in case of n-1 does not exist </returns>
      ///	 
      public virtual JDFLot getCreateLot(int n)
      {
         return (JDFLot)getCreateElement_KElement(ElementName.LOT, null, n);
      }

      ///   
      ///	 <summary> * append Lot element
      ///	 *  </summary>
      ///	 * <returns> the new Lot </returns>
      ///	 
      public virtual JDFLot appendLot()
      {
         return (JDFLot)appendElement(ElementName.LOT, null);
      }

      ///   
      ///	 <summary> * reduce the parts to the canonical representation. If all children of a parent node are in defined in parts, they
      ///	 * are replaced by their parent. E.g. the canonical representation of all leaves is the root. </summary>
      ///	 
      public virtual void reduceParts()
      {
         VJDFAttributeMap vParts = getPartMapVector();
         if (vParts.IsEmpty()) // nothing to do
         {
            return;
         }

         VJDFAttributeMap vReducedParts = getLinkRoot().reducePartVector(vParts);

         if (vParts != vReducedParts)
         {
            setPartMapVector(vReducedParts);
         }
      }

      ///   
      ///	 <summary> * Expand the target resource to contain all parts specified in the link. <br>
      ///	 * If PartUsage==Explicit or bForce==true, loop over all part elements as well.<br>
      ///	 *  </summary>
      ///	 * <param name="bForce"> if true, implicitly referenced partitions are also expanded </param>
      ///	 
      public virtual void expandTarget(bool bForce)
      {
         JDFResource r = getLinkRoot();
         if (r == null)
            return; // bail out!

         // loop over parts for partusage explicit
         if (r.getPartUsage() == JDFResource.EnumPartUsage.Explicit || bForce)
         {
            VJDFAttributeMap apParts = getPartMapVector();
            if (apParts != null)
            {
               for (int i = 0; i < apParts.Count; i++)
               {
                  VElement vExist = r.getPartitionVector(apParts[i], null);
                  if (vExist.IsEmpty())
                     r.getCreatePartition(apParts[i], null);
               }
            }
         }
      }

      ///   
      ///	 <summary> * create an Amountpool and fill it with the values of Amount and ActualAmount <br> </summary>
      ///	 
      public virtual void expandAmountPool()
      {
         VJDFAttributeMap apParts = getResourcePartMapVector();
         if (apParts == null)
            return;

         VString attribs = new VString();
         attribs.Add(AttributeName.AMOUNT);
         attribs.Add(AttributeName.ACTUALAMOUNT);

         for (int j = 0; j < attribs.Count; j++)
         {
            string attribName = attribs.stringAt(j);
            if (hasAttribute(attribName))
            {
               string att = getAttribute(attribName, null, null);
               for (int i = 0; i < apParts.Count; i++)
               {
                  setAmountPoolAttribute(attribName, att, null, apParts[i]);
               }
            }
         }
      }

      ///   
      ///	 <summary> * returns the minimum value of attribute occurence in PartAmount,
      ///	 *  </summary>
      ///	 * <param name="attrib"> the attribute name </param>
      ///	 * <param name="nameSpaceURI"> the XML-namespace URI </param>
      ///	 * <param name="mPart"> defines which part of this ResourceLink the amount belongs to. If empty get the ResourceLink root
      ///	 *            attribute. </param>
      ///	 * <param name="def"> the default value id, if no matching attribute is found </param>
      ///	 * <returns> double - the value of attribute found, def if no matches found
      ///	 * @since 060630 </returns>
      ///	 
      public virtual double getMinAmountPoolAttribute(string attrib, string nameSpaceURI, JDFAttributeMap mPart, int def)
      {
         JDFAmountPool ap = getAmountPool();
         if (ap == null)
            return def;
         VElement vPartAmount = ap.getMatchingPartAmountVector(mPart);

         bool bMatch = false;
         double d = double.MaxValue;
         int size = vPartAmount.Count;
         for (int i = 0; i < size; i++)
         {
            JDFPartAmount pa = (JDFPartAmount)vPartAmount[i];
            double realAttribute = pa.getRealAttribute(attrib, nameSpaceURI, def);
            if (realAttribute != def && realAttribute < d)
            {
               bMatch = true;
               d = realAttribute;
            }
         }
         return bMatch ? d : def;
      }

      ///   
      ///	 <summary> * get an AmountMap for the child Amountpool of this </summary>
      ///	 * <param name="vPartIDKeys"> </param>
      ///	 * <returns> the AmountMap for the Amountpool, null if no amountpool exists </returns>
      ///	 
      public virtual AmountMap getAmountMap(VString vPartIDKeys)
      {
         return AmountPoolHelper.getAmountMap(this, vPartIDKeys);
      }

      ///   
      ///	 <summary> * returns the attribute occurence in PartAmount, or the default in the ResourceLink
      ///	 *  </summary>
      ///	 * <param name="attrib"> the attribute name </param>
      ///	 * <param name="nameSpaceURI"> the XML-namespace </param>
      ///	 * <param name="mPart"> defines which part of this ResourceLink the Amount belongs to. If empty get the ResourceLink root
      ///	 *            attribute. </param>
      ///	 * <returns> value of attribute found, null if not available
      ///	 * @since 071103 </returns>
      ///	 
      public virtual string getAmountPoolAttribute(string attrib, string nameSpaceURI, JDFAttributeMap mPart, int iSkip)
      {
         return AmountPoolHelper.getAmountPoolAttribute(this, attrib, nameSpaceURI, mPart, iSkip);
      }

      ///   
      ///	 <summary> * returns the attribute occurence in PartAmount, or the default in the ResourceLink
      ///	 *  </summary>
      ///	 * <param name="attrib"> the attribute name </param>
      ///	 * <param name="nameSpaceURI"> the XML-namespace </param>
      ///	 * <param name="vPart"> defines which part of this ResourceLink the Amount belongs to. If null get the ResourceLink root
      ///	 *            attribute. </param>
      ///	 * <returns> value of attribute found, null if not available
      ///	 * @since 071103 </returns>
      ///	 
      public virtual string getAmountPoolAttribute(string attrib, string nameSpaceURI, VJDFAttributeMap vPart)
      {
         return AmountPoolHelper.getAmountPoolAttribute(this, attrib, nameSpaceURI, vPart);
      }

      ///   
      ///	 <summary> * returns true if the attribute occurrs
      ///	 *  </summary>
      ///	 * <param name="attrib"> the attribute name </param>
      ///	 * <param name="nameSpaceURI"> the XML-namespace </param>
      ///	 * <param name="mPart"> which part of this ResourceLink the Amount belongs to, if empty get the ResourceLink root attribute </param>
      ///	 * <returns> true if available </returns>
      ///	 * @deprecated 060601 use getAmountPoolAttribute(attrib,nameSpaceURI,mPart,0)!=null;
      ///	 * @since 071103 
      ///	 
      [Obsolete("060601 use getAmountPoolAttribute(attrib,nameSpaceURI,mPart,0)!=null;")]
      public virtual bool hasAmountPoolAttribute(string attrib, string nameSpaceURI, JDFAttributeMap mPart)
      {
         return getAmountPoolAttribute(attrib, nameSpaceURI, mPart, 0) != null;
      }

      ///   
      ///	 <summary> * sets the attribute occurence in the appropriate PartAmount when called for a resourceLink and creates the
      ///	 * AmountPool and/or PartAmount(s) if they are not yet there
      ///	 *  </summary>
      ///	 * <param name="attrib"> the attribute name </param>
      ///	 * <param name="value"> value to set in string form. </param>
      ///	 * <param name="nameSpaceURI"> the XML-namespace </param>
      ///	 * <param name="vPart"> defines which part of this ResourceLink the Amount belongs to, if empty set the ResourceLink root
      ///	 *            attribute. </param>
      ///	 * <exception cref="JDFException"> when called directly on a PartAmount
      ///	 * @since 060630 </exception>
      ///	 
      public virtual void setAmountPoolAttribute(string attrib, string @value, string nameSpaceURI, VJDFAttributeMap vPart)
      {
         AmountPoolHelper.setAmountPoolAttribute(this, attrib, @value, nameSpaceURI, vPart);
      }

      ///   
      ///	 <summary> * sets the attribute occurence in the appropriate PartAmount when called for a resourceLink and creates the
      ///	 * AmountPool and/or PartAmount if it is not yet there
      ///	 *  </summary>
      ///	 * <param name="attrib"> the attribute name </param>
      ///	 * <param name="value"> value to set in string form. </param>
      ///	 * <param name="nameSpaceURI"> the XML-namespace </param>
      ///	 * <param name="mPart"> defines which part of this ResourceLink the Amount belongs to, if empty set the ResourceLink root
      ///	 *            attribute </param>
      ///	 * <exception cref="JDFException"> when called directly on a PartAmount
      ///	 * @since 071103 </exception>
      ///	 
      public virtual void setAmountPoolAttribute(string attrib, string @value, string nameSpaceURI, JDFAttributeMap mPart)
      {
         AmountPoolHelper.setAmountPoolAttribute(this, attrib, @value, nameSpaceURI, mPart);
      }


      public virtual double getAmountPoolSumDouble(string attName, VJDFAttributeMap vPart)
      {
         return AmountPoolHelper.getAmountPoolSumDouble(this, attName, vPart);
      }

      ///   
      ///	 <summary> * get the exactly matching AmountPool/PartAmount/@AttName as a double
      ///	 *  </summary>
      ///	 * <param name="attName"> </param>
      ///	 * <param name="vPart"> </param>
      ///	 * <returns> double - </returns>
      ///	 * <exception cref="JDFException"> if the element can not be cast to double </exception>
      ///	 
      public virtual double getAmountPoolDouble(string attName, VJDFAttributeMap vPart)
      {
         return AmountPoolHelper.getAmountPoolDouble(this, attName, vPart);
      }

      ///   
      ///	 <summary> * get the sum of all matching AmountPool/PartAmount/@attName as a double PartAmounts match if all attributes match
      ///	 * those in PartAmount, i.e. mPart is a submap of the searche PartAmount elements
      ///	 * 
      ///	 *  </summary>
      ///	 * <param name="attName"> the Attribute name , e.g Amount, ActualAmount </param>
      ///	 * <param name="mPart"> </param>
      ///	 * <returns> double - the element </returns>
      ///	 * <exception cref="JDFException"> if the element can not be cast to double </exception>
      ///	 
      public virtual double getAmountPoolDouble(string attName, JDFAttributeMap mPart)
      {
         return AmountPoolHelper.getAmountPoolDouble(this, attName, mPart);
      }

      ///   
      ///	 <summary> * Set attribute ActualAmount in the AmountPool or in the link, depending on the value of mPart
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set ActualAmount to </param>
      ///	 * <param name="mPart"> the part map of AmountPool/PartAmount </param>
      ///	 
      public virtual void setActualAmount(double @value, JDFAttributeMap mPart)
      {
         setAmountPoolAttribute("ActualAmount", StringUtil.formatDouble(@value), null, mPart);
      }

      public virtual double getActualAmount(JDFAttributeMap mPart)
      {
         double amountPoolDouble = getAmountPoolDouble(AttributeName.ACTUALAMOUNT, mPart);
         return amountPoolDouble == -1 ? 0 : amountPoolDouble;
      }

      ///   
      ///	 <summary> * set attribute ProcessUsage
      ///	 *  </summary>
      ///	 * <param name="s"> </param>
      ///	 * @deprecated use the enum method 
      ///	 
      [Obsolete("use the enum method")]
      public virtual void setProcessUsage(string s)
      {
         setAttribute(AttributeName.PROCESSUSAGE, s, null);
      }

      ///   
      ///	 <summary> * get attribute ProcessUsage
      ///	 *  </summary>
      ///	 * <returns> String </returns>
      ///	 
      public virtual string getProcessUsage()
      {
         return getAttribute(AttributeName.PROCESSUSAGE, null, JDFConstants.EMPTYSTRING);
      }

      ///   
      ///	 <summary> * get attribute ProcessUsage
      ///	 *  </summary>
      ///	 * <returns> EnumProcessUsage </returns>
      ///	 
      public virtual EnumProcessUsage getEnumProcessUsage()
      {
         return EnumProcessUsage.getEnum(getAttribute(AttributeName.PROCESSUSAGE, null, null));
      }

      ///   
      ///	 <summary> * set attribute ProcessUsage
      ///	 *  </summary>
      ///	 * <param name="processUsage"> </param>
      ///	 
      public virtual void setProcessUsage(EnumProcessUsage processUsage)
      {
         setAttribute(AttributeName.PROCESSUSAGE, processUsage == null ? null : processUsage.getName(), null);
      }

      ///   
      ///	 <summary> * set attribute Usage
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setUsage(EnumUsage @value)
      {
         setAttribute(AttributeName.USAGE, @value == null ? null : @value.getName(), null);
      }

      ///   
      ///	 <summary> * getUsage - get the usage of the ResourceLink in a JDF node. If no usage is available, default to the resource
      ///	 * name.
      ///	 *  </summary>
      ///	 * <returns> EnumUsage </returns>
      ///	 
      public virtual EnumUsage getUsage()
      {
         return EnumUsage.getEnum(getAttribute(AttributeName.USAGE, null, null));
      }

      ///   
      ///	 <summary> * set attribute MinStatus
      ///	 *  </summary>
      ///	 * <param name="value"> the value to set the attribute to </param>
      ///	 
      public virtual void setMinStatus(JDFResource.EnumResStatus @value)
      {
         setAttribute(AttributeName.MINSTATUS, @value.getName(), null);
      }

      ///   
      ///	 <summary> * getMinStatus - get the minimum status of the ResourceLink in a JDF node. If usage is input or not available,
      ///	 * check DraftOK as well.
      ///	 *  </summary>
      ///	 * <returns> the status of the ResourceLink </returns>
      ///	 
      public virtual JDFResource.EnumResStatus getMinStatus()
      {
         EnumResStatus returnEnum;
         if (hasAttribute(AttributeName.MINSTATUS))
         {
            returnEnum = JDFResource.EnumResStatus.getEnum(getAttribute(AttributeName.MINSTATUS));
         }
         else
         {
            if (getUsage() == EnumUsage.Output)
            {
               returnEnum = JDFResource.EnumResStatus.Unavailable;
            }
            else if (getBoolAttribute(AttributeName.DRAFTOK, null, false))
            {
               returnEnum = JDFResource.EnumResStatus.Draft;
            }
            else
            {
               returnEnum = JDFResource.EnumResStatus.Available;
            }
         }

         return returnEnum;
      }

      ///   
      ///	 <summary> * Method setUsage.
      ///	 *  </summary>
      ///	 * <param name="value"> </param>
      ///	 
      public virtual void setMinLateStatus(JDFResource.EnumResStatus @value)
      {
         setAttribute(AttributeName.MINLATESTATUS, @value.getName(), null);
      }

      ///   
      ///	 <summary> * get attribute MinLateStatus
      ///	 *  </summary>
      ///	 * <returns> EnumUsage </returns>
      ///	 
      public virtual JDFResource.EnumResStatus getMinLateStatus()
      {
         if (!this.hasAttribute(AttributeName.MINLATESTATUS))
            return getMinStatus();

         return JDFResource.EnumResStatus.getEnum(getAttribute(AttributeName.MINLATESTATUS, null, null));
      }

      ///   
      ///	 <summary> * Sets the value of PipePartIDKeys
      ///	 *  </summary>
      ///	 * <param name="keys"> vector of values to set </param>
      ///	 * @deprecated use setPipePartIDKeys(Vector enum) 
      ///	 
      [Obsolete("use setPipePartIDKeys(Vector enum)")]
      public virtual void setPipePartIDKeys(VString keys)
      {
         List<ValuedEnum> vEnum = new List<ValuedEnum>();
         for (int i = 0; i < keys.Count; i++)
         {
            vEnum.Add(EnumPartIDKey.getEnum(keys[i]));
         }
         setPipePartIDKeys(vEnum);
      }

      ///   
      ///	 <summary> * Sets the value of PipePartIDKeys
      ///	 *  </summary>
      ///	 * <param name="keys"> vector of values to set </param>
      ///	 
      public virtual void setPipePartIDKeys(List<ValuedEnum> keys)
      {
         setEnumerationsAttribute(AttributeName.PIPEPARTIDKEYS, keys, null);

      }

      ///   
      ///	 <summary> * Gets a list of all valid pipe part keys for this resource
      ///	 *  </summary>
      ///	 * <returns> VString - list of all PipePartIDKeys
      ///	 * @deprecated </returns>
      ///	 
      [Obsolete]
      public virtual VString getPipePartIDKeys()
      {
         VString vPipePartIDKeys = new VString();
         List<ValuedEnum> v = getPipePartIDKeysEnum();
         for (int i = 0; i < v.Count; i++)
            vPipePartIDKeys.Add(((EnumPartIDKey)v[i]).getName());

         return vPipePartIDKeys;
      }

      ///   
      ///	 <summary> * Gets an enumerated list of all valid pipe part keys for this resource
      ///	 *  </summary>
      ///	 * <returns> Vector of EnumPartIDKey - list of all PipePartIDKeys </returns>
      ///	 
      public virtual List<ValuedEnum> getPipePartIDKeysEnum()
      {
         List<ValuedEnum> v = null;

         JDFResource res = getTarget();
         VString vPartIDKeys = res.getPartIDKeys();
         if (hasAttribute(AttributeName.PIPEPARTIDKEYS))
         {
            v = getEnumerationsAttribute(AttributeName.PIPEPARTIDKEYS, null, EnumPartIDKey.getEnum(0), false);
         }
         else
         {
            v = res.getPipePartIDKeysEnum();
         }
         for (int i = 0; i < v.Count; i++)
         {
            if (!vPartIDKeys.Contains((v[i]).getName()))
            {
               throw new JDFException("JDFResourceLink.getPipePartIDKeys: key " + v[i] + " is not subset of PartIDKey");
            }
         }
         return v;
      }

      ///   
      ///	 <summary> * sets attribute CombinedProcessIndex
      ///	 *  </summary>
      ///	 * <param name="value"> attribute value to set </param>
      ///	 
      public virtual void setCombinedProcessIndex(JDFIntegerList @value)
      {
         JDFIntegerList valueLocal = @value;

         if (valueLocal != null && valueLocal.Count == 0)
            valueLocal = null;

         setAttribute(AttributeName.COMBINEDPROCESSINDEX, valueLocal, null);
      }

      ///   
      ///	 <summary> * gets attribute CombinedProcessIndex
      ///	 *  </summary>
      ///	 * <returns> JDFIntegerList - attribute value, null if no CombinedProcessIndex is set or the format is illegal </returns>
      ///	 
      public virtual JDFIntegerList getCombinedProcessIndex()
      {
         try
         {
            string cpi = getAttribute(AttributeName.COMBINEDPROCESSINDEX, null, null);
            return cpi == null ? null : new JDFIntegerList(cpi);
         }
         catch (FormatException)
         {
            return null;
         }
      }

      ///   
      ///	 <summary> * sets attribute CombinedProcessType
      ///	 *  </summary>
      ///	 * <param name="value"> attribute value to set </param>
      ///	 
      public virtual void setCombinedProcessType(string @value)
      {
         setAttribute(AttributeName.COMBINEDPROCESSTYPE, @value);
      }

      ///   
      ///	 <summary> * gets attribute CombinedProcessType
      ///	 *  </summary>
      ///	 * <returns> String - attribute value </returns>
      ///	 
      public virtual string getCombinedProcessType()
      {
         return getAttribute(AttributeName.COMBINEDPROCESSTYPE);
      }

      ///   
      ///	 <summary> * gets list of all types referenced by CombinedProccessIndex or CombinedProcessType
      ///	 *  </summary>
      ///	 * <returns> VString - the list of types. Each type occurs at most once </returns>
      ///	 
      public virtual VString getCombinedProcessTypes()
      {
         VString vs = null;
         JDFNode parentJDF = getParentJDF();

         VString vTypes = parentJDF == null ? null : parentJDF.getTypes();

         JDFIntegerList il = getCombinedProcessIndex();
         if (il == null && !hasAttribute(AttributeName.COMBINEDPROCESSTYPE))
         {
            vs = vTypes;
         }
         else if (il != null && vTypes != null)
         {
            int[] intArray = il.getIntArray();
            int size = vTypes.Count;
            vs = new VString();
            for (int i = 0; i < intArray.Length; i++)
            {
               int index = intArray[i];
               if (index < size)
                  vs.Add(vTypes.stringAt(index));
            }
         }
         else if (hasAttribute(AttributeName.COMBINEDPROCESSTYPE))
         {
            vs = new VString();
            vs.Add(getCombinedProcessType());
         }

         if (vs != null)
         {
            vs.unify();
            if (vs.Count == 0)
               vs = null;
         }
         return vs;
      }

      ///   
      ///	 <summary> * sets attribute DraftOK if version>=1.3, set MinStatus=Draft instead of DraftOK=true
      ///	 *  </summary>
      ///	 * <param name="value"> attribute value to set </param>
      ///	 
      public virtual void setDraftOK(bool @value)
      {
         EnumVersion eVer = getVersion(true);
         if (eVer.getValue() < EnumVersion.Version_1_3.getValue())
         {
            setAttribute(AttributeName.DRAFTOK, @value, null);
         }
         else if (@value == true)
         {
            setMinStatus(JDFResource.EnumResStatus.Draft);
         }
         else
         // 1.3 DraftOK=false
         {
            setMinStatus(EnumUsage.Output.Equals(getUsage()) ? JDFResource.EnumResStatus.Unavailable : JDFResource.EnumResStatus.Available);
         }
      }

      ///   
      ///	 <summary> * gets attribute DraftOK
      ///	 *  </summary>
      ///	 * <returns> boolean - attribute value. Default is false </returns>
      ///	 
      public virtual bool getDraftOK()
      {
         if (hasAttribute(AttributeName.DRAFTOK))
         {
            return getBoolAttribute(AttributeName.DRAFTOK, null, false);
         }

         // try to infer draftok from the JDF 1.3 MinStatus flag
         if (!hasAttribute(AttributeName.MINSTATUS))
            return false;

         return getMinStatus().getValue() <= JDFResource.EnumResStatus.Draft.getValue();
      }

      ///   
      ///	 <summary> * sets attribute PipeProtocol
      ///	 *  </summary>
      ///	 * <param name="value"> attribute value to set </param>
      ///	 
      public virtual void setPipeProtocol(string @value)
      {
         setAttribute(AttributeName.PIPEPROTOCOL, @value);
      }

      ///   
      ///	 <summary> * gets string attribute PipeProtocol
      ///	 *  </summary>
      ///	 * <returns> String - attribute value. </returns>
      ///	 
      public virtual string getPipeProtocol()
      {
         string str = JDFConstants.EMPTYSTRING;
         if (!hasAttribute(AttributeName.PIPEPROTOCOL))
         {
            JDFResource res = getTarget();
            if (res != null)
            {
               str = res.getPipeProtocol();
            }
         }
         else
         {
            str = getAttribute(AttributeName.PIPEPROTOCOL);
         }
         return str;
      }

      ///   
      ///	 <summary> * sets attribute PipeURL
      ///	 *  </summary>
      ///	 * <param name="value"> attribute value to set </param>
      ///	 
      public virtual void setPipeURL(string @value)
      {
         setAttribute(AttributeName.PIPEURL, @value, null);
      }

      ///   
      ///	 <summary> * gets string attribute PipeURL
      ///	 *  </summary>
      ///	 * <returns> String - attribute value. </returns>
      ///	 
      public virtual string getPipeURL()
      {
         string str = JDFConstants.EMPTYSTRING;
         if (!hasAttribute(AttributeName.PIPEURL))
         {
            JDFResource res = getTarget();
            if (res != null)
            {
               str = res.getPipeURL();
            }
         }
         else
         {
            str = getAttribute(AttributeName.PIPEURL);
         }
         return str;
      }

      ///   
      ///	 <summary> * sets attribute rRef
      ///	 *  </summary>
      ///	 * <param name="value"> attribute value to set </param>
      ///	 
      public virtual void setrRef(string @value)
      {
         setAttribute(AttributeName.RREF, @value, null);
      }

      ///   
      ///	 <summary> * gets string attribute rRef
      ///	 *  </summary>
      ///	 * <returns> String - attribute value. </returns>
      ///	 
      public virtual string getrRef()
      {
         return getAttribute(AttributeName.RREF);
      }

      ///   
      ///	 <summary> * sets attribute rSubRef
      ///	 *  </summary>
      ///	 * <param name="value"> attribute value to set </param>
      ///	 
      public virtual void setrSubRef(string @value)
      {
         setAttribute(AttributeName.RSUBREF, @value);
      }

      ///   
      ///	 <summary> * gets string attribute rSubRef
      ///	 *  </summary>
      ///	 * <returns> String - attribute value. </returns>
      ///	 
      public virtual string getrSubRef()
      {
         return getAttribute(AttributeName.RSUBREF);
      }

      ///   
      ///	 <summary> * sets attribute PipePause
      ///	 *  </summary>
      ///	 * <param name="value"> attribute value to set </param>
      ///	 
      public virtual void setPipePause(double @value)
      {
         setAttribute(AttributeName.PIPEPAUSE, @value, null);
      }

      ///   
      ///	 <summary> * gets attribute PipePause
      ///	 *  </summary>
      ///	 * <returns> double - attribute value. </returns>
      ///	 
      public virtual double getPipePause()
      {
         return getRealAttribute(AttributeName.PIPEPAUSE, null, 0.0);
      }

      ///   
      ///	 <summary> * sets attribute PipeResume
      ///	 *  </summary>
      ///	 * <param name="value"> attribute value to set </param>
      ///	 
      public virtual void setPipeResume(double @value)
      {
         setAttribute(AttributeName.PIPERESUME, @value, null);
      }

      ///   
      ///	 <summary> * gets attribute PipeResume
      ///	 *  </summary>
      ///	 * <returns> double - attribute value. </returns>
      ///	 
      public virtual double getPipeResume()
      {
         return getRealAttribute(AttributeName.PIPERESUME, null, 0.0);
      }

      ///   
      ///	 <summary> * sets attribute Orientation
      ///	 *  </summary>
      ///	 * <param name="value"> attribute value to set </param>
      ///	 
      public virtual void setOrientation(EnumOrientation @value)
      {
         setAttribute(AttributeName.ORIENTATION, @value.getName(), null);
      }

      ///   
      ///	 <summary> * gets string attribute Orientation
      ///	 *  </summary>
      ///	 * <returns> EnumOrientation - attribute value </returns>
      ///	 
      public virtual EnumOrientation getOrientation()
      {
         return EnumOrientation.getEnum(getAttribute(AttributeName.ORIENTATION, null, null));
      }

      ///   
      ///	 <summary> * sets attribute RemotePipeEndPause
      ///	 *  </summary>
      ///	 * <param name="value"> attribute value to set </param>
      ///	 
      public virtual void setRemotePipeEndPause(double @value)
      {
         setAttribute(AttributeName.REMOTEPIPEENDPAUSE, @value, null);
      }

      ///   
      ///	 <summary> * gets attribute RemotePipeEndPause
      ///	 *  </summary>
      ///	 * <returns> double - attribute value. </returns>
      ///	 
      public virtual double getRemotePipeEndPause()
      {
         return getRealAttribute(AttributeName.REMOTEPIPEENDPAUSE, null, 0.0);
      }

      ///   
      ///	 <summary> * sets attribute RemotePipeEndResume
      ///	 *  </summary>
      ///	 * <param name="value"> attribute value to set </param>
      ///	 
      public virtual void setRemotePipeEndResume(double @value)
      {
         setAttribute(AttributeName.REMOTEPIPEENDRESUME, @value, null);
      }

      ///   
      ///	 <summary> * gets attribute RemotePipeEndResume
      ///	 *  </summary>
      ///	 * <returns> double - attribute value. </returns>
      ///	 
      public virtual double getRemotePipeEndResume()
      {
         return getRealAttribute(AttributeName.REMOTEPIPEENDRESUME, null, 0.0);
      }

      ///   
      ///	 <summary> * sets attribute Transformation(
      ///	 *  </summary>
      ///	 * <param name="value"> attribute value to set </param>
      ///	 * <exception cref="JDFException"> </exception>
      ///	 
      public virtual void setTransformation(JDFMatrix @value)
      {
         setAttribute(AttributeName.TRANSFORMATION, @value.ToString());
      }

      ///   
      ///	 <summary> * gets string attribute Transformation
      ///	 *  </summary>
      ///	 * <returns> JDFMatrix - attribute value </returns>
      ///	 * <exception cref="JDFException"> if attribute has not a type JDFMatrix </exception>
      ///	 
      public virtual JDFMatrix getTransformation()
      {
         try
         {
            return new JDFMatrix(getAttribute(AttributeName.TRANSFORMATION));
         }
         catch (FormatException)
         {
            throw new JDFException("JDFResourceLink.getTransformation: not capable to create JDFMatrix");
         }
      }

      ///   
      ///	 <summary> * sets attribute Duration
      ///	 *  </summary>
      ///	 * <param name="value"> attribute value to set </param>
      ///	 
      public virtual void setDuration(JDFDuration @value)
      {
         JDFDuration valueLocal = @value;

         if (valueLocal == null)
         {
            valueLocal = new JDFDuration();
         }

         setAttribute(AttributeName.DURATION, valueLocal.getDurationISO());
      }

      ///   
      ///	 <summary> * gets attribute Duration
      ///	 *  </summary>
      ///	 * <returns> JDFDuration - attribute value. </returns>
      ///	 * <exception cref="JDFException"> if attribute has not a type JDFDuration </exception>
      ///	 
      public virtual JDFDuration getDuration()
      {
         try
         {
            return new JDFDuration(getAttribute(AttributeName.DURATION));
         }
         catch (FormatException)
         {
            throw new JDFException("JDFResourceLink.getDuration: not capable to create JDFDuration");
         }
      }

      ///   
      ///	 <summary> * sets attribute Recommendation
      ///	 *  </summary>
      ///	 * <param name="value"> attribute value to set </param>
      ///	 
      public virtual void setRecommendation(bool @value)
      {
         setAttribute(AttributeName.RECOMMENDATION, @value, null);
      }

      ///   
      ///	 <summary> * gets attribute Recommendation
      ///	 *  </summary>
      ///	 * <returns> boolean - attribute value. </returns>
      ///	 
      public virtual bool getRecommendation()
      {
         return getBoolAttribute(AttributeName.RECOMMENDATION, null, false);
      }

      ///   
      ///	 <summary> * sets attribute Start
      ///	 *  </summary>
      ///	 * <param name="value"> attribute value to set </param>
      ///	 
      public virtual void setStart(JDFDate @value)
      {
         JDFDate valueLocal = @value;

         if (valueLocal == null)
         {
            valueLocal = new JDFDate();
         }
         setAttribute(AttributeName.START, valueLocal.DateTimeISO);
      }

      ///   
      ///	 <summary> * gets attribute Start
      ///	 *  </summary>
      ///	 * <returns> JDFDate - attribute value </returns>
      ///	 * <exception cref="JDFException"> if attribute has not a type JDFDate </exception>
      ///	 
      public virtual JDFDate getStart()
      {
         try
         {
            return new JDFDate(getAttribute(AttributeName.START, null, (new JDFDate()).DateTimeISO));
         }
         catch (FormatException)
         {
            throw new JDFException("JDFResourceLink.getStart: not capable to create JDFDate");
         }
      }

      ///   
      ///	 <summary> * sets attribute StartOffset
      ///	 *  </summary>
      ///	 * <param name="value"> - attribute value to set </param>
      ///	 
      public virtual void setStartOffset(JDFDuration @value)
      {
         JDFDuration valueLocal = @value;

         if (valueLocal == null)
         {
            valueLocal = new JDFDuration();
         }
         setAttribute(AttributeName.STARTOFFSET, valueLocal.getDurationISO());
      }

      ///   
      ///	 <summary> * gets attribute StartOffset
      ///	 *  </summary>
      ///	 * <returns> JDFDuration - attribute value </returns>
      ///	 * <exception cref="JDFException"> if attribute has not a type JDFDuration </exception>
      ///	 
      public virtual JDFDuration getStartOffset()
      {
         try
         {
            return new JDFDuration(getAttribute(AttributeName.STARTOFFSET, null, (new JDFDuration()).getDurationISO()));
         }
         catch (FormatException)
         {
            throw new JDFException("JDFResourceLink.getStartOffset: not capable to create JDFDuration");
         }
      }

      ///   
      ///	 <summary> * get part map vector
      ///	 *  </summary>
      ///	 * <returns> VJDFAttributeMap - vector of attribute maps, one for each part </returns>
      ///	 
      public override VJDFAttributeMap getPartMapVector()
      {
         return base.getPartMapVector();
      }

      ///   
      ///	 <summary> * set all parts to those define in vParts
      ///	 *  </summary>
      ///	 * <param name="vParts"> vector of attribute maps for the parts </param>
      ///	 
      public override void setPartMapVector(VJDFAttributeMap vParts)
      {
         base.setPartMapVector(vParts);
      }

      ///   
      ///	 <summary> * set all parts to those defined in vParts
      ///	 *  </summary>
      ///	 * <param name="mPart"> attribute map for the part to set </param>
      ///	 
      public override void setPartMap(JDFAttributeMap mPart)
      {
         base.setPartMap(mPart);
      }

      ///   
      ///	 <summary> * remove the part defined in mPart
      ///	 *  </summary>
      ///	 * <param name="mPart"> attribute map for the part to remove </param>
      ///	 
      public override void removePartMap(JDFAttributeMap mPart)
      {
         base.removePartMap(mPart);
      }

      ///   
      ///	 <summary> * check whether the part defined in mPart is included
      ///	 *  </summary>
      ///	 * <param name="mPart"> attribute map for the part to remove </param>
      ///	 * <returns> boolean - returns true if the part exists </returns>
      ///	 
      public override bool hasPartMap(JDFAttributeMap mPart)
      {
         return base.hasPartMap(mPart);
      }

      ///   
      ///	 <summary> * return true if this is moderately well described by namedReslink
      ///	 *  </summary>
      ///	 * <param name="namedResLink">
      ///	 * @return </param>
      ///	 
      public virtual bool matchesString(string namedResLink)
      {
         if (namedResLink == null)
            return false;

         bool bMatch = namedResLink.Equals(getNamedProcessUsage());
         bMatch = bMatch || namedResLink.Equals(getLinkedResourceName());
         bMatch = bMatch || namedResLink.Equals(LocalName);
         bMatch = bMatch || namedResLink.Equals(Name);
         bMatch = bMatch || namedResLink.Equals(getrRef());
         bMatch = bMatch || namedResLink.Equals(getAttribute(AttributeName.USAGE));
         bMatch = bMatch || namedResLink.Equals(getLinkedResourceName() + JDFConstants.COLON + getAttribute(AttributeName.USAGE));

         if (!bMatch && StringUtil.token(namedResLink, 0, JDFConstants.COLON).Equals(getLinkedResourceName()))
         {
            VElement v = getTargetVector(0);
            if (v != null)
            {
               int siz = v.Count;
               for (int i = 0; i < siz; i++)
               {
                  if (((JDFResource)v[i]).matchesString(namedResLink))
                     return true;
               }
            }
         }

         return bMatch;
      }
   }
}
