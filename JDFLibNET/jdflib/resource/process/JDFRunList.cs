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
 * JDFRunList.cs
 *
 * Last changes
 *
 * 2002-07-02 JG - added ConsistentPartIDKeys() 
 */

namespace org.cip4.jdflib.resource.process
{
   using System;
   using System.Collections;
   using System.Collections.Generic;


   using ValuedEnum = org.apache.commons.lang.enums.ValuedEnum;

   using JDFAutoRunList = org.cip4.jdflib.auto.JDFAutoRunList;
   using AtrInfoTable = org.cip4.jdflib.core.AtrInfoTable;
   using AttributeInfo = org.cip4.jdflib.core.AttributeInfo;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFException = org.cip4.jdflib.core.JDFException;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using JDFIntegerRangeList = org.cip4.jdflib.datatypes.JDFIntegerRangeList;
   using VJDFAttributeMap = org.cip4.jdflib.datatypes.VJDFAttributeMap;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using StringUtil = org.cip4.jdflib.util.StringUtil;
   using UrlUtil = org.cip4.jdflib.util.UrlUtil;


   ///
   /// <summary> * Wrapper around a JDF RunList </summary>
   /// 
   public class JDFRunList : JDFAutoRunList
   {
      private new const long serialVersionUID = 1L;

      private static AtrInfoTable[] atrInfoTable = new AtrInfoTable[1];
      static JDFRunList()
      {
         // need to add the default partition key doccopies -
         atrInfoTable[0] = new AtrInfoTable(AttributeName.DOCCOPIES, 0x33333333, AttributeInfo.EnumAttributeType.integer, null, "1");
      }

      protected internal override AttributeInfo getTheAttributeInfo()
      {
         return base.getTheAttributeInfo().updateReplace(atrInfoTable);
      }

      ///   
      ///	 <summary> * Constructor for JDFRunList
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFRunList(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFRunList
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFRunList(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFRunList
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="localName"> </param>

      ///	 
      public JDFRunList(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
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
         return "JDFRunList[ --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * addRun
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            fileName
      ///	 * @deprecated
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      [Obsolete]
      public virtual JDFRunList addRun(string fileName)
      {
         return addRun(fileName, 0, -1);
      }

      ///   
      ///	 <summary> * addRun
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            fileName </param>
      ///	 * <param name="int"> first
      ///	 * @deprecated
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      [Obsolete]
      public virtual JDFRunList addRun(string fileName, int first)
      {
         return addRun(fileName, first, -1);
      }

      ///   
      ///	 <summary> * addRun
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            fileName </param>
      ///	 * <param name="int"> first </param>
      ///	 * <param name="int"> last
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      public virtual JDFRunList addRun(string fileName, int first, int last)
      {
         string runID = "Run" + uniqueID(0);
         JDFRunList r = (JDFRunList)addPartition(JDFResource.EnumPartIDKey.Run, runID); // JDFRun to RunList

         JDFIntegerRangeList irl = new JDFIntegerRangeList();
         irl.Append(first, last);
         r.setPages(irl);
         JDFLayoutElement loe = (JDFLayoutElement)r.appendElement(ElementName.LAYOUTELEMENT, JDFConstants.EMPTYSTRING);
         loe.setMimeURL(fileName);
         fixNPage();
         return r;
      }

      ///   
      ///	 <summary> * addPDF
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            fileName
      ///	 * @deprecated
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      [Obsolete]
      public virtual JDFRunList addPDF(string fileName)
      {
         return addPDF(fileName, 0, -1);
      }

      ///   
      ///	 <summary> * addPDF
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            fileName </param>
      ///	 * <param name="int"> first
      ///	 * @deprecated
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      [Obsolete]
      public virtual JDFRunList addPDF(string fileName, int first)
      {
         return addPDF(fileName, first, -1);
      }

      ///   
      ///	 <summary> * addPDF add a pdf file to this RunList
      ///	 *  </summary>
      ///	 * <param name="fileName">
      ///	 *            the URL (!) of the file </param>
      ///	 * <param name="first">
      ///	 *            0 based first page in the file </param>
      ///	 * <param name="last">
      ///	 *            0 based last page in the file
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      public virtual JDFRunList addPDF(string fileName, int first, int last)
      {
         JDFRunList r = addRun(fileName, first, last);
         JDFFileSpec fs = r.getLayoutElement().getFileSpec();
         fs.setMimeType(JDFConstants.MIME_PDF);
         return r;
      }

      ///   
      ///	 <summary> * addSepRun
      ///	 *  </summary>
      ///	 * <param name="Vector">
      ///	 *            fileSpec </param>
      ///	 * <param name="Vector">
      ///	 *            sepNames
      ///	 * @deprecated
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      [Obsolete]
      public virtual JDFRunList addSepRun(ArrayList fileNames, ArrayList sepNames)
      {
         return addSepRun(fileNames, sepNames, 0, 1, true);
      }

      ///   
      ///	 <summary> * addSepRun
      ///	 *  </summary>
      ///	 * <param name="Vector">
      ///	 *            fileSpec </param>
      ///	 * <param name="Vector">
      ///	 *            sepNames </param>
      ///	 * <param name="int"> first
      ///	 * @deprecated
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      [Obsolete]
      public virtual JDFRunList addSepRun(ArrayList fileNames, ArrayList sepNames, int first)
      {
         return addSepRun(fileNames, sepNames, first, 1, true);
      }

      ///   
      ///	 <summary> * addSepRun
      ///	 *  </summary>
      ///	 * <param name="Vector">
      ///	 *            fileSpec </param>
      ///	 * <param name="Vector">
      ///	 *            sepNames </param>
      ///	 * <param name="int"> first </param>
      ///	 * <param name="int"> n
      ///	 * @deprecated
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      [Obsolete]
      public virtual JDFRunList addSepRun(ArrayList fileNames, ArrayList sepNames, int first, int n)
      {
         return addSepRun(fileNames, sepNames, first, n, true);
      }

      ///   
      ///	 <summary> * addSepRun
      ///	 *  </summary>
      ///	 * <param name="Vector">
      ///	 *            fileSpec </param>
      ///	 * <param name="Vector">
      ///	 *            sepNames </param>
      ///	 * <param name="int"> first </param>
      ///	 * <param name="boolean"> pageMajor
      ///	 * @deprecated
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      [Obsolete]
      public virtual JDFRunList addSepRun(ArrayList fileNames, ArrayList sepNames, int first, bool pageMajor)
      {
         return addSepRun(fileNames, sepNames, first, 1, pageMajor);
      }

      ///   
      ///	 <summary> * addSepRun
      ///	 *  </summary>
      ///	 * <param name="Vector">
      ///	 *            fileSpec </param>
      ///	 * <param name="Vector">
      ///	 *            sepNames </param>
      ///	 * <param name="boolean"> pageMajor
      ///	 * @deprecated
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      [Obsolete]
      public virtual JDFRunList addSepRun(ArrayList fileNames, ArrayList sepNames, bool pageMajor)
      {
         return addSepRun(fileNames, sepNames, 0, 1, pageMajor);
      }

      ///   
      ///	 <summary> * add a run separation
      ///	 *  </summary>
      ///	 * <param name="fileNames">
      ///	 *            vector of file names for the URL attribute of the FileSpec in
      ///	 *            the LayoutElement </param>
      ///	 * <param name="sepNames">
      ///	 *            parallel vector of separation names. </param>
      ///	 * <param name="first">
      ///	 *            index of the first page in the file - Sets the RunList
      ///	 *            FirstPage attribute </param>
      ///	 * <param name="n">
      ///	 *            the number of logical pages in this run </param>
      ///	 * <param name="pageMajor">
      ///	 *            if true, separations are ordered as page Major, i.e CMYKCMYK<br>
      ///	 *            if false, ordering is CCMMYYKK
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      public virtual JDFRunList addSepRun(ArrayList fileNames, ArrayList sepNames, int first, int n, bool pageMajor)
      {
         JDFRunList r = (JDFRunList)addPartition(JDFResource.EnumPartIDKey.Run, "Run" + uniqueID(0));
         int siz = fileNames.Count;
         r.setNPage(n);
         r.setIsPage(true);

         for (int i = 0; i < sepNames.Count; i++)
         {
            JDFRunList rs = (JDFRunList)r.addPartition(JDFResource.EnumPartIDKey.Separation, sepNames[i].ToString());
            JDFLayoutElement lo = rs.appendLayoutElement();
            lo.setMimeURL(((string)fileNames[Math.Min(i, siz - 1)]));
            rs.setIsPage(false);
            if (fileNames.Count == sepNames.Count)
            {
               rs.setFirstPage(first);
            }
            else
            {
               if (pageMajor)
               {
                  rs.setSkipPage(sepNames.Count - 1);
                  rs.setFirstPage(i + first);
               }
               else
               {
                  rs.setFirstPage(i * n + first);
               }
            }
         }
         return r;
      }

      ///   
      ///	 <summary> * addSepRun
      ///	 *  </summary>
      ///	 * <param name="VElement">
      ///	 *            fileSpec </param>
      ///	 * <param name="Vector">
      ///	 *            sepNames
      ///	 * @deprecated
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      [Obsolete]
      public virtual JDFRunList addSepRun(VElement fileSpec, ArrayList sepNames)
      {
         return addSepRun(fileSpec, sepNames, 0, 1, true);
      }

      ///   
      ///	 <summary> * addSepRun
      ///	 *  </summary>
      ///	 * <param name="VElement">
      ///	 *            fileSpec </param>
      ///	 * <param name="Vector">
      ///	 *            sepNames </param>
      ///	 * <param name="int"> first
      ///	 * @deprecated
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      [Obsolete]
      public virtual JDFRunList addSepRun(VElement fileSpec, ArrayList sepNames, int first)
      {
         return addSepRun(fileSpec, sepNames, first, 1, true);
      }

      ///   
      ///	 <summary> * addSepRun
      ///	 *  </summary>
      ///	 * <param name="VElement">
      ///	 *            fileSpec </param>
      ///	 * <param name="Vector">
      ///	 *            sepNames </param>
      ///	 * <param name="int"> first </param>
      ///	 * <param name="int"> n
      ///	 * @deprecated
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      [Obsolete]
      public virtual JDFRunList addSepRun(VElement fileSpec, ArrayList sepNames, int first, int n)
      {
         return addSepRun(fileSpec, sepNames, first, n, true);
      }

      ///   
      ///	 <summary> * addSepRun
      ///	 *  </summary>
      ///	 * <param name="VElement">
      ///	 *            fileSpec </param>
      ///	 * <param name="Vector">
      ///	 *            sepNames </param>
      ///	 * <param name="int"> first </param>
      ///	 * <param name="boolean"> pageMajor
      ///	 * @deprecated
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      [Obsolete]
      public virtual JDFRunList addSepRun(VElement fileSpec, ArrayList sepNames, int first, bool pageMajor)
      {
         return addSepRun(fileSpec, sepNames, first, 1, pageMajor);
      }

      ///   
      ///	 <summary> * addSepRun
      ///	 *  </summary>
      ///	 * <param name="VElement">
      ///	 *            fileSpec </param>
      ///	 * <param name="Vector">
      ///	 *            sepNames </param>
      ///	 * <param name="boolean"> pageMajor
      ///	 * @deprecated
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      [Obsolete]
      public virtual JDFRunList addSepRun(VElement fileSpec, ArrayList sepNames, bool pageMajor)
      {
         return addSepRun(fileSpec, sepNames, 0, 1, pageMajor);
      }

      ///   
      ///	 <summary> * addSepRun
      ///	 *  </summary>
      ///	 * <param name="VElement">
      ///	 *            fileSpec </param>
      ///	 * <param name="Vector">
      ///	 *            sepNames </param>
      ///	 * <param name="int"> first </param>
      ///	 * <param name="int"> n </param>
      ///	 * <param name="boolean"> pageMajor
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 * @deprecated 060503 use the version with VString VString 
      ///	 
      [Obsolete("060503 use the version with VString VString")]
      public virtual JDFRunList addSepRun(VElement fileSpec, ArrayList sepNames, int first, int n, bool pageMajor)
      {
         JDFRunList r = (JDFRunList)addPartition(JDFResource.EnumPartIDKey.Run, "Run" + uniqueID(0)); // Test TBD
         int siz = fileSpec.Count;
         r.setNPage(n);

         for (int i = 0; i < sepNames.Count; i++)
         {
            JDFRunList rs = (JDFRunList)r.addPartition(JDFResource.EnumPartIDKey.Separation, sepNames[i].ToString());
            // HIER LIEGT DAS PROBLEM
            // JDFRunList rs = new JDFRunList(r.AddPart("Seperation",
            // sepNames[i].toString()) );
            // rs.setAttribute("Separation",(String)sepNames[i]);
            JDFResource rfspec = (JDFResource)fileSpec[Math.Min(i, siz - 1)];
            rs.refElement(rfspec);

            if (fileSpec.Count == sepNames.Count)
            {
               rs.setAttribute("FirstPage", first, JDFConstants.EMPTYSTRING);
            }
            else
            {
               if (pageMajor)
               {
                  rs.setAttribute("SkipPage", sepNames.Count - 1, JDFConstants.EMPTYSTRING);
                  rs.setAttribute("FirstPage", i + first, JDFConstants.EMPTYSTRING);
               }
               else
               {
                  rs.setAttribute("FirstPage", i * n + first, JDFConstants.EMPTYSTRING);
               }
            }
         }

         return r;
      }

      ///   
      ///	 <summary> * addSepRun
      ///	 *  </summary>
      ///	 * <param name="JDFResource">
      ///	 *            fileSpec </param>
      ///	 * <param name="String">
      ///	 *            sepNames
      ///	 * @deprecated
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      [Obsolete]
      public virtual JDFRunList addSepRun(JDFResource fileSpec, string sepNames)
      {
         VElement v = new VElement();
         v.Add(fileSpec);
         return addSepRun(v, StringUtil.tokenize(sepNames, JDFConstants.COMMA, false), 0, 1, true);
      }

      ///   
      ///	 <summary> * addSepRun
      ///	 *  </summary>
      ///	 * <param name="JDFResource">
      ///	 *            fileSpec </param>
      ///	 * <param name="String">
      ///	 *            sepNames </param>
      ///	 * <param name="int"> first
      ///	 * @deprecated
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      [Obsolete]
      public virtual JDFRunList addSepRun(JDFResource fileSpec, string sepNames, int first)
      {
         VElement v = new VElement();
         v.Add(fileSpec);
         return addSepRun(v, StringUtil.tokenize(sepNames, JDFConstants.COMMA, false), first, 1, true);
      }

      ///   
      ///	 <summary> * addSepRun
      ///	 *  </summary>
      ///	 * <param name="JDFResource">
      ///	 *            fileSpec </param>
      ///	 * <param name="String">
      ///	 *            sepNames </param>
      ///	 * <param name="int"> first </param>
      ///	 * <param name="int"> n
      ///	 * @deprecated
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      [Obsolete]
      public virtual JDFRunList addSepRun(JDFResource fileSpec, string sepNames, int first, int n)
      {
         VElement v = new VElement();
         v.Add(fileSpec);
         return addSepRun(v, StringUtil.tokenize(sepNames, JDFConstants.COMMA, false), first, n, true);
      }

      ///   
      ///	 <summary> * addSepRun
      ///	 *  </summary>
      ///	 * <param name="JDFResource">
      ///	 *            fileSpec </param>
      ///	 * <param name="String">
      ///	 *            sepNames </param>
      ///	 * <param name="int"> first </param>
      ///	 * <param name="boolean"> pageMajor
      ///	 * @deprecated
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      [Obsolete]
      public virtual JDFRunList addSepRun(JDFResource fileSpec, string sepNames, int first, bool pageMajor)
      {
         VElement v = new VElement();
         v.Add(fileSpec);
         return addSepRun(v, StringUtil.tokenize(sepNames, JDFConstants.COMMA, false), first, 1, pageMajor);
      }

      ///   
      ///	 <summary> * addSepRun
      ///	 *  </summary>
      ///	 * <param name="JDFResource">
      ///	 *            fileSpec </param>
      ///	 * <param name="String">
      ///	 *            sepNames </param>
      ///	 * <param name="boolean"> pageMajor
      ///	 * @deprecated
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      [Obsolete]
      public virtual JDFRunList addSepRun(JDFResource fileSpec, string sepNames, bool pageMajor)
      {
         VElement v = new VElement();
         v.Add(fileSpec);
         return addSepRun(v, StringUtil.tokenize(sepNames, JDFConstants.COMMA, false), 0, 1, pageMajor);
      }

      ///   
      ///	 <summary> * addSepRun
      ///	 *  </summary>
      ///	 * <param name="JDFResource">
      ///	 *            fileSpec </param>
      ///	 * <param name="String">
      ///	 *            sepNames </param>
      ///	 * <param name="String">
      ///	 *            sep
      ///	 * @deprecated
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      [Obsolete]
      public virtual JDFRunList addSepRun(JDFResource fileSpec, string sepNames, string sep)
      {
         VElement v = new VElement();
         v.Add(fileSpec);
         return addSepRun(v, StringUtil.tokenize(sepNames, sep, false), 0, 1, true);
      }

      ///   
      ///	 <summary> * addSepRun
      ///	 *  </summary>
      ///	 * <param name="JDFResource">
      ///	 *            fileSpec </param>
      ///	 * <param name="String">
      ///	 *            sepNames </param>
      ///	 * <param name="int"> first </param>
      ///	 * <param name="String">
      ///	 *            sep
      ///	 * @deprecated
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      [Obsolete]
      public virtual JDFRunList addSepRun(JDFResource fileSpec, string sepNames, int first, string sep)
      {
         VElement v = new VElement();
         v.Add(fileSpec);
         return addSepRun(v, StringUtil.tokenize(sepNames, sep, false), first, 1, true);
      }

      ///   
      ///	 <summary> * addSepRun
      ///	 *  </summary>
      ///	 * <param name="JDFResource">
      ///	 *            fileSpec </param>
      ///	 * <param name="String">
      ///	 *            sepNames </param>
      ///	 * <param name="int"> first </param>
      ///	 * <param name="int"> n </param>
      ///	 * <param name="String">
      ///	 *            sep
      ///	 * @deprecated
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      [Obsolete]
      public virtual JDFRunList addSepRun(JDFResource fileSpec, string sepNames, int first, int n, string sep)
      {
         VElement v = new VElement();
         v.Add(fileSpec);
         return addSepRun(v, StringUtil.tokenize(sepNames, sep, false), first, n, true);
      }

      ///   
      ///	 <summary> * addSepRun
      ///	 *  </summary>
      ///	 * <param name="JDFResource">
      ///	 *            fileSpec </param>
      ///	 * <param name="String">
      ///	 *            sepNames </param>
      ///	 * <param name="int"> first </param>
      ///	 * <param name="boolean"> pageMajor </param>
      ///	 * <param name="String">
      ///	 *            sep
      ///	 * @deprecated
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      [Obsolete]
      public virtual JDFRunList addSepRun(JDFResource fileSpec, string sepNames, int first, bool pageMajor, string sep)
      {
         VElement v = new VElement();
         v.Add(fileSpec);
         return addSepRun(v, StringUtil.tokenize(sepNames, sep, false), first, 1, pageMajor);
      }

      ///   
      ///	 <summary> * addSepRun
      ///	 *  </summary>
      ///	 * <param name="JDFResource">
      ///	 *            fileSpec </param>
      ///	 * <param name="String">
      ///	 *            sepNames </param>
      ///	 * <param name="boolean"> pageMajor </param>
      ///	 * <param name="String">
      ///	 *            sep
      ///	 * @deprecated
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      [Obsolete]
      public virtual JDFRunList addSepRun(JDFResource fileSpec, string sepNames, bool pageMajor, string sep)
      {
         VElement v = new VElement();
         v.Add(fileSpec);
         return addSepRun(v, StringUtil.tokenize(sepNames, sep, false), 0, 1, pageMajor);
      }

      ///   
      ///	 <summary> * addSepRun
      ///	 *  </summary>
      ///	 * <param name="JDFResource">
      ///	 *            fileSpec </param>
      ///	 * <param name="String">
      ///	 *            sepNames </param>
      ///	 * <param name="int"> first </param>
      ///	 * <param name="int"> n </param>
      ///	 * <param name="boolean"> pageMajor </param>
      ///	 * <param name="String">
      ///	 *            sep
      ///	 * @deprecated
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      [Obsolete]
      public virtual JDFRunList addSepRun(JDFResource fileSpec, string sepNames, int first, int n, bool pageMajor, string sep)
      {
         VElement v = new VElement();
         v.Add(fileSpec);
         return addSepRun(v, StringUtil.tokenize(sepNames, sep, false), first, n, pageMajor);
      }

      ///   
      ///	 <summary> * addSepRun
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            fileNames </param>
      ///	 * <param name="String">
      ///	 *            sepNames
      ///	 * @deprecated
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      [Obsolete]
      public virtual JDFRunList addSepRun(string fileNames, string sepNames)
      {
         return addSepRun(fileNames, sepNames, 0, 1, true, JDFConstants.COMMA);
      }

      ///   
      ///	 <summary> * addSepRun
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            fileNames </param>
      ///	 * <param name="String">
      ///	 *            sepNames </param>
      ///	 * <param name="int"> first
      ///	 * @deprecated
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      [Obsolete]
      public virtual JDFRunList addSepRun(string fileNames, string sepNames, int first)
      {
         return addSepRun(fileNames, sepNames, first, 1, true, JDFConstants.COMMA);
      }

      ///   
      ///	 <summary> * addSepRun
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            fileNames </param>
      ///	 * <param name="String">
      ///	 *            sepNames </param>
      ///	 * <param name="int"> first </param>
      ///	 * <param name="int"> n
      ///	 * @deprecated
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      [Obsolete]
      public virtual JDFRunList addSepRun(string fileNames, string sepNames, int first, int n)
      {
         return addSepRun(fileNames, sepNames, first, n, true, JDFConstants.COMMA);
      }

      ///   
      ///	 <summary> * addSepRun
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            fileNames </param>
      ///	 * <param name="String">
      ///	 *            sepNames </param>
      ///	 * <param name="int"> first </param>
      ///	 * <param name="boolean"> pageMajor
      ///	 * @deprecated
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      [Obsolete]
      public virtual JDFRunList addSepRun(string fileNames, string sepNames, int first, bool pageMajor)
      {
         return addSepRun(fileNames, sepNames, first, 1, pageMajor, JDFConstants.COMMA);
      }

      ///   
      ///	 <summary> * addSepRun
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            fileNames </param>
      ///	 * <param name="String">
      ///	 *            sepNames </param>
      ///	 * <param name="boolean"> pageMajor
      ///	 * @deprecated
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      [Obsolete]
      public virtual JDFRunList addSepRun(string fileNames, string sepNames, bool pageMajor)
      {
         return addSepRun(fileNames, sepNames, 0, 1, pageMajor, JDFConstants.COMMA);
      }

      ///   
      ///	 <summary> * addSepRun
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            fileNames </param>
      ///	 * <param name="String">
      ///	 *            sepNames </param>
      ///	 * <param name="String">
      ///	 *            sep
      ///	 * @deprecated
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      [Obsolete]
      public virtual JDFRunList addSepRun(string fileNames, string sepNames, string sep)
      {
         return addSepRun(fileNames, sepNames, 0, 1, true, sep);
      }

      ///   
      ///	 <summary> * addSepRun
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            fileNames </param>
      ///	 * <param name="String">
      ///	 *            sepNames </param>
      ///	 * <param name="int"> first </param>
      ///	 * <param name="String">
      ///	 *            sep
      ///	 * @deprecated
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      [Obsolete]
      public virtual JDFRunList addSepRun(string fileNames, string sepNames, int first, string sep)
      {
         return addSepRun(fileNames, sepNames, first, 1, true, sep);
      }

      ///   
      ///	 <summary> * addSepRun
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            fileNames </param>
      ///	 * <param name="String">
      ///	 *            sepNames </param>
      ///	 * <param name="int"> first </param>
      ///	 * <param name="int"> n </param>
      ///	 * <param name="String">
      ///	 *            sep
      ///	 * @deprecated
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      [Obsolete]
      public virtual JDFRunList addSepRun(string fileNames, string sepNames, int first, int n, string sep)
      {
         return addSepRun(fileNames, sepNames, first, n, true, sep);
      }

      ///   
      ///	 <summary> * addSepRun
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            fileNames </param>
      ///	 * <param name="String">
      ///	 *            sepNames </param>
      ///	 * <param name="int"> first </param>
      ///	 * <param name="boolean"> pageMajor </param>
      ///	 * <param name="String">
      ///	 *            sep
      ///	 * @deprecated
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      [Obsolete]
      public virtual JDFRunList addSepRun(string fileNames, string sepNames, int first, bool pageMajor, string sep)
      {
         return addSepRun(fileNames, sepNames, first, 1, pageMajor, sep);
      }

      ///   
      ///	 <summary> * addSepRun
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            fileNames </param>
      ///	 * <param name="String">
      ///	 *            sepNames </param>
      ///	 * <param name="boolean"> pageMajor </param>
      ///	 * <param name="String">
      ///	 *            sep
      ///	 * @deprecated
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      [Obsolete]
      public virtual JDFRunList addSepRun(string fileNames, string sepNames, bool pageMajor, string sep)
      {
         return addSepRun(fileNames, sepNames, 0, 1, pageMajor, sep);
      }

      ///   
      ///	 <summary> * addSepRun
      ///	 *  </summary>
      ///	 * <param name="String">
      ///	 *            fileNames </param>
      ///	 * <param name="String">
      ///	 *            sepNames </param>
      ///	 * <param name="int"> first </param>
      ///	 * <param name="int"> n </param>
      ///	 * <param name="boolean"> pageMajor </param>
      ///	 * <param name="String">
      ///	 *            sep
      ///	 * @deprecated
      ///	 *  </param>
      ///	 * <returns> JDFRunList </returns>
      ///	 
      [Obsolete]
      public virtual JDFRunList addSepRun(string fileNames, string sepNames, int first, int n, bool pageMajor, string sep)
      {
         return addSepRun(StringUtil.tokenize(fileNames, sep, false), StringUtil.tokenize(sepNames, sep, false), first, n, pageMajor);
      }

      ///   
      ///	 <summary> * set RunList/LayoutElement/FileSpec/@URL
      ///	 *  </summary>
      ///	 * <param name="url">
      ///	 *            the url to set </param>
      ///	 * <returns> true if ok </returns>
      ///	 
      public virtual bool setFileURL(string url)
      {
         JDFFileSpec fspec = getCreateLayoutElement().getCreateFileSpec();
         fspec.setMimeURL(url);
         return true;
      }

      ///   
      ///	 <summary> * get RunList/LayoutElement/FileSpec/@URL also evaluate RunList/@directory
      ///	 * and concatinate Directory + URL in case URL is a relative URL
      ///	 * 
      ///	 * @Directory is ignored if URL contains a scheme or is an absolute URL
      ///	 *  </summary>
      ///	 * <returns> URL if a URL or Directory attribute exists, else null </returns>
      ///	 
      public virtual string getFileURL()
      {
         JDFFileSpec fspec = getFileSpec();
         if (fspec == null)
            return null;

         return UrlUtil.getURLWithDirectory(getDirectory(), fspec.getURL());
      }

      ///   
      ///	 <summary> * (36) set attribute Pages
      ///	 *  </summary>
      ///	 * <param name="value">
      ///	 *            : the value to set the attribute to </param>
      ///	 
      public override void setPages(JDFIntegerRangeList @value)
      {
         base.setPages(@value);
         if (@value == null)
            return;
         if (@value.getElementCount() > 0)
         {
            setNPage(@value.getElementCount());
         }
      }

      ///   
      ///	 <summary> * get RunList/LayoutElement/FileSpec/@MimeType
      ///	 *  </summary>
      ///	 * <returns> MIMEType if it exists, else null </returns>
      ///	 
      public virtual string getFileMimeType()
      {
         JDFFileSpec fspec = getFileSpec();
         if (fspec == null)
            return null;
         return fspec.getMimeType();
      }

      ///   
      ///	 <summary> * get RunList/LayoutElement/FileSpec
      ///	 *  </summary>
      ///	 * <returns> JDFFileSpec FileSpec if it exists, else null </returns>
      ///	 
      public virtual JDFFileSpec getFileSpec()
      {
         JDFLayoutElement lay = getLayoutElement();
         if (lay == null)
         {
            return null;
         }
         return lay.getFileSpec();
      }

      ///   
      ///	 <summary> * get a map of VJDFAttributeMap that are sorted by the fileSpec URL key<br>
      ///	 * each url key maps the leaves that share the same URL
      ///	 *  </summary>
      ///	 * <returns> fileSpecMap a map of VJDFAttributeMap </returns>
      ///	 
      public virtual Hashtable getCommonURLFileSpecMap()
      {
         VElement vE = getLeaves(false);
         Hashtable fileMap = new Hashtable();

         // loop over all leaves of the runlist
         for (int i = 0; i < vE.Count; i++)
         {
            JDFRunList rl = (JDFRunList)vE[i];
            string url = rl.getFileURL();
            // do we have a preexisting leaf that shares the same filespec URL

            // add a new key
            VJDFAttributeMap vPart = null;
            if (!fileMap.ContainsKey(url))
            {
               vPart = new VJDFAttributeMap();
               vPart.Add(rl.getPartMap());
               fileMap.Add(url, vPart);
            }
            else
            {
               // append this leaf to a preexisting key
               vPart = (VJDFAttributeMap)fileMap[url];
               vPart.Add(rl.getPartMap());
            }
         }

         return fileMap;
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
         v.Add(EnumPartIDKey.RunIndex);
         v.Add(EnumPartIDKey.DocIndex);
         v.Add(EnumPartIDKey.DocRunIndex);
         v.Add(EnumPartIDKey.DocSheetIndex);
         v.Add(EnumPartIDKey.SetIndex);
         v.Add(EnumPartIDKey.PageNumber);
         return v;
      }

      public virtual IEnumerator getPageIterator()
      {
         return new PageIterator(this);
      }


      ///   
      ///	 <summary> * class that abstracts a RunList Partition so that you can efficiently
      ///	 * access the File using RunIndex as a marker </summary>
      ///	 
      public class JDFRunData
      {
         protected internal JDFRunList runList;
         protected internal int runIndex;
         protected internal int firstIndex;
         protected internal int lastIndex;

         ///      
         ///		 <summary> * copy constructor
         ///		 *  </summary>
         ///		 * <param name="other">
         ///		 *            the JDFRunIndex object to clone </param>
         ///		 
         public JDFRunData(JDFRunData other)
         {
            runList = other.runList;
            runIndex = other.runIndex;
            firstIndex = other.firstIndex;
            lastIndex = other.lastIndex;
         }

         ///      
         ///		 <summary> * null constructor
         ///		 *  </summary>
         ///		 
         protected internal JDFRunData()
         {
            runList = null;
            runIndex = 0;
            firstIndex = 0;
            lastIndex = 0;
         }

         ///      
         ///		 <summary> * get the 0 based page number in the file specified by RunList/@URL
         ///		 *  </summary>
         ///		 * <returns> the page number in the file; -1 if out of range </returns>
         ///		 
         public virtual int getPageInFile()
         {
            int page = -1;

            int delta = runIndex - firstIndex;
            if (runList.hasAttribute(AttributeName.PAGES))
            {
               int[] pages = runList.getPages().getIntegerList().getIntArray();
               if (delta >= pages.Length)
                  throw new JDFException("getPageInFile: Pages is kaputt");
               page = pages[delta];
            }
            else
            {
               page = runList.getFirstPage() + delta;
            }
            return page;
         }

         ///      
         ///		 * <returns> the lastIndex </returns>
         ///		 
         public virtual int getLastIndex()
         {
            return lastIndex;
         }

         ///      
         ///		 * <returns> the runIndex </returns>
         ///		 
         public virtual int getRunIndex()
         {
            return runIndex;
         }

         ///      
         ///		 * <returns> the runList </returns>
         ///		 
         public virtual JDFRunList getRunList()
         {
            return runList;
         }

         ///      
         ///		 * <param name="firstIndex">
         ///		 *            the firstIndex to set </param>
         ///		 
         public virtual int getFirstIndex()
         {
            return firstIndex;
         }
      }

      ///   
      ///	 <summary> * gets the first logical RunIndex for this partition
      ///	 *  </summary>
      ///	 * <returns> the first RunIndex that this RunList partition specifies </returns>
      ///	 
      public virtual int getFirstIndex()
      {
         return getFirstIndex(null);
      }

      ///   
      ///	 <summary> * gets the first logical RunIndex for this partition
      ///	 *  </summary>
      ///	 * <returns> the first RunIndex that this RunList partition specifies </returns>
      ///	 
      protected internal virtual int getFirstIndex(JDFRunData last)
      {
         if (hasAttribute(AttributeName.LOGICALPAGE))
            return getLogicalPage();

         if (!getIsPage())
         {
            KElement e = getParentNode_KElement();
            if (e is JDFRunList)
            {
               return ((JDFRunList)e).getFirstIndex(last);
            }
         }
         JDFRunList rl = (JDFRunList)getElement_KElement(ElementName.RUNLIST, null, 0);
         if (rl != null && rl.getIsPage())
            return rl.getFirstIndex(last);

         JDFRunList previousRL = (JDFRunList)getPreviousSiblingElement(ElementName.RUNLIST, null);
         if (previousRL == null)
            return 0;
         int offset = 0;
         if (last != null && previousRL == last.runList)
            offset = last.lastIndex;
         else
            offset = previousRL.getLastIndex(last);
         return offset + 1;
      }

      ///   
      ///	 <summary> * get the list of RunList Leaves with IsPage=true
      ///	 * 
      ///	 * @return </summary>
      ///	 
      public virtual VElement getPageLeaves()
      {
         VElement v = getLeaves(false);
         for (int i = 0; i < v.Count; i++)
         {
            JDFRunList rl = (JDFRunList)v[i];
            bool bRep = false;
            while (rl != null && !rl.getIsPage())
            {
               bRep = true;
               rl = (JDFRunList)rl.getParentNode_KElement();
            }
            if (bRep)
               v[i] = rl;
         }
         v.unify();
         return v;
      }

      ///   
      ///	 <summary> * gets the last logical RunIndex for this partition
      ///	 *  </summary>
      ///	 * <returns> the last RunIndex that this RunList partition specifies </returns>
      ///	 
      public virtual int getLastIndex()
      {
         return getLastIndex(null);
      }

      ///   
      ///	 <summary> * gets the last logical RunIndex for this partition
      ///	 *  </summary>
      ///	 * <returns> the last RunIndex that this RunList partition specifies </returns>
      ///	 
      protected internal virtual int getLastIndex(JDFRunData last)
      {
         if (!getIsPage())
         {
            KElement e = getParentNode_KElement();
            if (e is JDFRunList)
            {
               return ((JDFRunList)e).getLastIndex(last);
            }
         }
         JDFRunList rl = (JDFRunList)getElement_KElement(ElementName.RUNLIST, null, -1);
         if (rl != null && rl.getIsPage())
            return rl.getLastIndex(last);

         int offset = -1;
         if (hasAttribute(AttributeName.LOGICALPAGE))
         {
            offset = getLogicalPage() - 1;
         }
         else
         {
            JDFRunList previousRL = (JDFRunList)getPreviousSiblingElement(ElementName.RUNLIST, null);
            if (previousRL != null)
            {
               if (last != null && last.runList == previousRL)
                  offset = last.lastIndex;
               else
                  offset = previousRL.getLastIndex(last);
            }
         }
         return offset + getNPage();
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.cip4.jdflib.auto.JDFAutoRunList#getNPage()
      //	 
      public override int getNPage()
      {
         int n = 0;

         if (!getIsPage())
            return 0;

         if (hasAttribute(AttributeName.NPAGE))
            return base.getNPage();
         if (hasAttribute(AttributeName.PAGES))
         {
            JDFIntegerRangeList pages = getPages();
            return pages.getElementCount();
         }

         VElement v = getChildElementVector_KElement(LocalName, getNamespaceURI(), null, true, 0);
         if (v != null)
         {
            int siz = v.Count;
            for (int i = 0; i < siz; i++)
            {
               int page = ((JDFRunList)v[i]).getNPage();
               if (page < 0)
                  return -1;

               n += page;
            }
         }

         return n; // TODO what is the default
      }

      ///   
      ///	 <summary> * get the Partition that corresponds to a given runIndex
      ///	 *  </summary>
      ///	 * <param name="index">
      ///	 *            the runIndex to search for </param>
      ///	 * <returns> JDFRunList the partition that contains this index. use @see
      ///	 *         getPageInFile to find the correct page
      ///	 * 
      ///	 *         warning blindly calling this from inside a loop may cause
      ///	 *         performance issues - use the getPageIterator if you need
      ///	 *         performance optimized access </returns>
      ///	 
      public virtual JDFRunList getIndexPartition(int index)
      {
         VElement leaves = getPageLeaves();
         for (int i = 0; i < leaves.Count; i++)
         {
            JDFRunList rl = (JDFRunList)leaves[i];
            if (rl.getFirstIndex() <= index && rl.getLastIndex() >= index)
            {
               return rl;
            }
         }
         return null;

      }

      ///   
      ///	 <summary> * get the 0 based page number in the specified file
      ///	 *  </summary>
      ///	 * <returns> the page number in the file; -1 if ot of range </returns>
      ///	 
      public virtual int getPageInFile(int runIndex)
      {
         JDFRunData ri = new JDFRunData();
         ri.firstIndex = getFirstIndex();
         if (runIndex < ri.firstIndex)
            return -1;
         ri.lastIndex = getLastIndex();
         if (runIndex > ri.lastIndex)
            return -1;
         ri.runIndex = runIndex;
         ri.runList = this;
         return ri.getPageInFile();
      }


      ///   
      ///	 <summary> * inner iterator class </summary>
      ///	 
      private class PageIterator : IEnumerator
      {

         private readonly JDFRunList rl;
         private int index;
         private readonly int maxIndex;
         private readonly JDFRunData[] vRunIndex;
         private int lastIndex;

         ///      
         ///		 * <param name="list"> </param>
         ///		 
         public PageIterator(JDFRunList list)
         {
            lastIndex = 0;
            rl = (JDFRunList)list.getResourceRoot();
            index = list.getFirstIndex();
            maxIndex = list.getLastIndex();
            VElement leaves = rl.getPageLeaves();
            vRunIndex = new JDFRunData[leaves.Count];
            JDFRunData last = null;
            for (int i = 0; i < leaves.Count; i++)
            {
               JDFRunList _rl = (JDFRunList)leaves[i];
               int firstIndex = _rl.getFirstIndex(last);
               int _lastIndex = firstIndex + _rl.getNPage() - 1;
               JDFRunData ri = new JDFRunData();
               ri.runList = _rl;
               ri.firstIndex = firstIndex;
               ri.lastIndex = _lastIndex;
               vRunIndex[i] = ri;
               last = ri;
            }
         }

         //      
         //		 * (non-Javadoc)
         //		 * 
         //		 * @see java.util.Iterator#hasNext()
         //		 
         public virtual bool hasNext()
         {
            return index <= maxIndex;
         }

         ///      
         ///		 <summary> *  </summary>
         ///		 * <seealso cref= java.util.Iterator#next() returns a JDFRunIndex object that
         ///		 *      refers to the RunList entry and the index within it </seealso>
         ///		 
         public virtual object next()
         {
            for (int i = lastIndex; i < vRunIndex.Length; i++)
            {
               JDFRunData ri = vRunIndex[i];
               if (ri.firstIndex <= index && ri.lastIndex >= index)
               {
                  JDFRunData ri2 = new JDFRunData(ri);
                  ri2.runIndex = index;
                  index++;
                  lastIndex = i;
                  return ri2;
               }
            }
            return null;
         }

         ///      
         ///		 <summary> * (non-Javadoc) don't even dream of removing individual pages in this
         ///		 * iterator </summary>
         ///		 
         public virtual void remove()
         {
            throw new JDFException("remove not implented");
         }

         // Java to C# Conversion
         // Summary:
         //     Advances the enumerator to the next element of the collection.
         //
         // Returns:
         //     true if the enumerator was successfully advanced to the next element; false
         //     if the enumerator has passed the end of the collection.
         //
         // Exceptions:
         //   System.InvalidOperationException:
         //     The collection was modified after the enumerator was created.
         public virtual bool MoveNext()
         {
            return hasNext();
         }

         // Summary:
         //     Gets the current element in the collection.
         //
         // Returns:
         //     The current element in the collection.
         //
         // Exceptions:
         //   System.InvalidOperationException:
         //     The enumerator is positioned before the first element of the collection or
         //     after the last element.
         public object Current
         {
            get { return next(); }
         }

         //
         // Summary:
         //     Sets the enumerator to its initial position, which is before the first element
         //     in the collection.
         //
         // Exceptions:
         //   System.InvalidOperationException:
         //     The collection was modified after the enumerator was created.
         public void Reset()
         {
            throw new NotImplementedException();
         }
      }

      // /// End of iterator class /////

      public override void collapse(bool bCollapseToNode)
      {
         base.collapse(bCollapseToNode);
         fixNPage();
      }

      public override void expand(bool bCollapseToNode)
      {
         fixNPage();
         base.expand(bCollapseToNode);
      }

      ///   
      ///	 <summary> * write NPage into all leaves with IsPage=true and write the appropriate
      ///	 * value into the lower level nodes
      ///	 *  </summary>
      ///	 * <returns> int the number of pages in this partition </returns>
      ///	 
      public virtual void fixNPage()
      {
         int siz = 0;

         VElement v = getPageLeaves();
         if (v != null)
         {
            siz = v.Count;
            for (int i = 0; i < siz; i++)
            {
               JDFRunList rl = (JDFRunList)v[i];
               int page = rl.getNPage();
               if (page > 0)
                  rl.setNPage(page);
            }
         }

         VElement v2 = getLeaves(true);
         if (v2 != null)
         {
            siz = v2.Count;
            for (int i = siz - 1; i >= 0; i--)
            {
               JDFRunList rl = (JDFRunList)v2[i];
               if (v != null && v.Contains(rl))
               {
                  v2.Remove(rl); // it's a leaf
               }
               else
               {
                  rl.removeAttribute(AttributeName.NPAGE);
               }
            }
         }

         if (v2 != null)
         {
            siz = v2.Count;
            for (int i = siz - 1; i >= 0; i--)
            {
               JDFRunList rl = (JDFRunList)v2[i];
               int page = rl.getNPage();
               if (page > 0)
                  rl.setNPage(page);
            }
         }
      }

      ///   
      ///	 <summary> * get the first matching parent or this with IsPage==true
      ///	 * 
      ///	 * @return </summary>
      ///	 
      public virtual JDFRunList getTruePage()
      {
         JDFRunList rl = this;
         while (true)
         {
            if (rl.getIsPage())
               return rl;
            KElement parent = rl.getParentNode_KElement();
            if (parent is JDFRunList)
            {
               rl = (JDFRunList)parent;
            }
            else
            {
               return null;
            }
         }
      }

      ///   
      ///	 <summary> * get the first matching parent or this with IsPage==true
      ///	 * 
      ///	 * @return </summary>
      ///	 
      public virtual bool isPageLeaf()
      {
         if (!getIsPage())
            return false;

         VElement v = getChildElementVector_KElement(LocalName, getNamespaceURI(), null, true, 0);
         if (v != null)
         {
            int siz = v.Count;
            for (int i = 0; i < siz; i++)
            {
               JDFRunList rl = (JDFRunList)v[i];
               if (rl.getIsPage())
                  return false;
            }
         }

         return true;
      }

      protected internal object clone()
      {
         // TODO Auto-generated method stub
         return base.Clone();
      }
   }
}
