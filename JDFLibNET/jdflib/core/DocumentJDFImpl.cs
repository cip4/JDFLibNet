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


/* DocumentJDFImpl.cs - JDFElement Factory
 * @author Dietrich Mucha
 * 
 * This method creates at least a KElement !!! (was JDFElement until 11.2005)
 * Copyright (C) 2003 Heidelberger Druckmaschinen AG. All Rights Reserved. 
 */


namespace org.cip4.jdflib.core
{
   using System;
   using System.Runtime.CompilerServices;
   using System.Collections;
   using System.Collections.Generic;
   using System.Reflection;
   using System.Xml;


   using JDFResourcePool = org.cip4.jdflib.pool.JDFResourcePool;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;

   ///
   /// <summary> * implementation of the JDFLib class factory
   /// * @author prosirai
   /// * </summary>
   /// 
   public class DocumentJDFImpl : DocumentImpl
   {

      private const long serialVersionUID = 1L;
      ///   
      ///	 <summary> * if true, the factory is bypassed and only KElements are 
      ///	 * created rather than the typesafe element classes </summary>
      ///	 
      public bool bKElementOnly = false;
      private bool ignoreNSDefault = false;
      private bool bInJDFJMF = false;

      /// <summary> Caches default package name classes of files.  </summary>
      private static Dictionary<string, string> sm_PackageNames = new Dictionary<string, string>();

      /// <summary> Caches Classes  </summary>
      private static Dictionary<string, System.Type> sm_ClassAlreadyInstantiated = new Dictionary<string, System.Type>();

      /// <summary> Caches JDF element constructors (namespace variant)  </summary>
      private static Dictionary<string, ConstructorInfo> sm_hashCtorElementNS = new Dictionary<string, ConstructorInfo>();

      private XmlNode m_ParentNode = null;

      // used mainly for memory debugging purposes
      private long initialMem;

      ///   
      ///	 <summary> * the original file name if an element was parsed, else null </summary>
      ///	 
      public string m_OriginalFileName = null;
      // the xml output of the schema validation
      public XMLDoc m_validationResult = null;
      ///   
      ///	 <summary> * the mime bodypart that this document was parsed from </summary>
      ///	 
      public System.Net.Mail.Attachment m_Bodypart = null;

      private static readonly string jdfNSURI = JDFElement.getSchemaURL();

      ///   
      ///	 <summary> * rough guestimate of the memory used by this if called after parsing
      ///	 *  </summary>
      ///	 * <returns> the difference of memory used when calling compared to construction time </returns>
      ///	 
      public virtual long getDocMemoryUsed()
      {
         System.Diagnostics.Process rt = System.Diagnostics.Process.GetCurrentProcess();
         long mem = rt.PrivateMemorySize64;
         if (mem < initialMem)
            initialMem = mem;
         return mem - initialMem;
      }

      ///   
      ///	 * <seealso cref= org.apache.xerces.dom.CoreDocumentImpl#clone() </seealso>
      ///	 
      public override XmlNode CloneNode(bool deep)
      {
         DocumentJDFImpl clon = new DocumentJDFImpl();

         XmlNode newRoot = clon.ImportNode(DocumentElement, true);
         clon.AppendChild(newRoot);

         clon.m_Bodypart = m_Bodypart;
         clon.m_OriginalFileName = m_OriginalFileName;

         //getUserData().clear(); // otherwise, clon is indefinitely retained in userdata of the original document and we have a memory leak problem....

         //if (clon.getUserData() != null)
            //clon.getUserData().clear();

         return clon;
      }

      // public static String getPackage(String nodeName)
      // {
      // synchronized (sm_PackageNames)
      // {
      // return (String) sm_PackageNames.get(nodeName);
      // }
      // }

      ///   
      ///	 <summary> * register new custom class in the factory
      ///	 *  </summary>
      ///	 * <param name="strElement"> local name </param>
      ///	 * <param name="elemClass"> package path </param>
      ///	 
      public static void registerCustomClass(string strElement, string packagepath)
      {
         lock (sm_PackageNames)
         {
            sm_PackageNames[strElement] = packagepath;
            sm_ClassAlreadyInstantiated.Remove(strElement);
            sm_hashCtorElementNS.Remove(strElement);
         }
      }

      ///   
      ///	 * <param name="parent"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <returns> the new <seealso cref="KElement"/> </returns>
      ///	 
      internal virtual KElement factoryCreate(XmlNode parent, string qualifiedName)
      {
         setParentNode(parent); // set the parent in the factory for
         // private Elements
         return (KElement)createElement(qualifiedName);
      }

      ///   
      ///	 * <param name="parent"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName">
      ///	 * @return </param>
      ///	 
      internal virtual KElement factoryCreate(XmlNode parent, string namespaceURI, string qualifiedName)
      {
         setParentNode(parent); // set the parent in the factory for
         // private Elements
         return (KElement)createElementNS(namespaceURI, qualifiedName);
      }

      ///   
      ///	 <summary> * Constructor for DocumentJDFImpl. </summary>
      ///	 
      public DocumentJDFImpl()
         : base()
      {
         System.Diagnostics.Process rt = System.Diagnostics.Process.GetCurrentProcess();
         initialMem = rt.PrivateMemorySize64;
      }

      /// <summary>
      /// Override the CreateElement() method used by the XmlDocument Load() and CloneNode() methods
      /// Use the KElement factoryCreate() method to create an element of the right type
      /// </summary>
      /// <param name="prefix"></param>
      /// <param name="localName"></param>
      /// <param name="namespaceURI"></param>
      /// <returns></returns>

      public override XmlElement CreateElement(string prefix, string localName, string namespaceURI)
      {
         string qualifiedName = localName;
         if ((prefix != null) && (prefix.Length > 0))
            qualifiedName = prefix + ":" + localName;

         XmlElement e = factoryCreate(null, namespaceURI, qualifiedName);
         return e;
      }



      ///   
      ///	 <summary> * Factory method; creates an <code>Element</code> having this <code>Document</code> as its OwnerDoc.
      ///	 *  </summary>
      ///	 * <param name="qualifiedName"> The name of the element type to instantiate. For XML, this is case-sensitive.
      ///	 *  </param>
      ///	 * @throws <code>DOMException(INVALID_NAME_ERR)</code> if the tag name is not acceptable. </exception>
      ///	 
      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.apache.xerces.dom.CoreDocumentImpl#createElement(java.lang.String)
      //	 
      public XmlElement createElement(string qualifiedName)
      {
         string namespaceURI = null;
         string localPart = KElement.xmlnsLocalName(qualifiedName);

         return createElementNS(namespaceURI, qualifiedName, localPart);
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.apache.xerces.dom.CoreDocumentImpl#createElementNS(java.lang.String, java.lang.String)
      //	 
      public XmlElement createElementNS(string namespaceURI, string qualifiedName)
      {
         string localPart = KElement.xmlnsLocalName(qualifiedName);
         return createElementNS(namespaceURI, qualifiedName, localPart);
      }

      //   
      //	 * (non-Javadoc)
      //	 * 
      //	 * @see org.apache.xerces.dom.CoreDocumentImpl#createElementNS(String, String, String)
      //	 
      public XmlElement createElementNS(string namespaceURI, string qualifiedName, string localPart)
      {
         ConstructorInfo constructi;
         System.Type classOfConstructor = null;
         // we are not yet in a JDF or JMF
         if (bKElementOnly)
         {
            return new KElement(this, namespaceURI, qualifiedName, localPart);
         }

         if (!bInJDFJMF && (jdfNSURI.Equals(namespaceURI) || ElementName.JDF.Equals(localPart) || ElementName.JMF.Equals(localPart)))
         {
            bInJDFJMF = true;
         }

         lock (sm_hashCtorElementNS)
         {
            sm_hashCtorElementNS.TryGetValue(qualifiedName, out constructi);

            // it has to be 1 coreDocImpl plus 3 String Parameters
            // otherwhise don't use hashtableentry
            if (constructi == null || constructi.GetParameters().Length != 4) // AS
            // 17.09.02
            {
               try
               {
                  classOfConstructor = getFactoryClass(namespaceURI, qualifiedName, localPart);
                  if (classOfConstructor != null)
                  {
                     System.Type[] constructorParameters = { typeof(CoreDocumentImpl), typeof(string), typeof(string), typeof(string) };

                     constructi = classOfConstructor.GetConstructor(constructorParameters);
                     //constructi = classOfConstructor.GetConstructor(BindingFlags.DeclaredOnly, null, constructorParameters, null);
                     putConstructorToHashMap(sm_hashCtorElementNS, qualifiedName, constructi);
                  }
               }
               catch (MethodAccessException)
               {
                  // internal error
                  string message = "(DocumentJDFImpl.createElementNS) getDeclaredConstructor() not found: ";
                  if (classOfConstructor != null)
                     message += classOfConstructor.FullName + "(CoreDocumentImpl, String, String, String)";
                  throw new Exception(message);
               }
               // Java to C# Conversion - Moved this catch block to after MethodAccessException, 
               // since there was no equivalent .NET Exception and System.Exception catches everything.
               catch (System.Exception e)
               {
                  // internal error
                  string message = "(DocumentJDFImpl.createElementNS) getFactoryClass() " + "class " + e.Message + " could not be created" + " (surplus line in sm_PackageNames or non existing class ???)";
                  throw new Exception(message);
               }
            }
         }

         object[] constructorArguments = { this, namespaceURI, qualifiedName, localPart };

         KElement newElement = createKElement(constructi, constructorArguments);

         return newElement;
      }

      ///   
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="constructi"> </param>
      ///	 
      private void putConstructorToHashMap(Dictionary<string, ConstructorInfo> hashCtorElement, string qualifiedName, ConstructorInfo constructi)
      {
         // only put the constructor into the map if its not a Resource or an
         // element
         // there are a couple of nodes which can be both resource and element
         // depending on the occurrence
         string className = constructi.DeclaringType.FullName;
         bool bSpecialClass = isSpecialClass(qualifiedName, className);
         if (bSpecialClass)
         {
            hashCtorElement[qualifiedName] = constructi;
         }
      }

      ///   
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="className">
      ///	 * @return </param>
      ///	 
      private bool isSpecialClass(string qualifiedName, string className)
      {
         bool bSpecialClass = !className.EndsWith("JDFResource") && !className.EndsWith("JDFElement")
            && !className.EndsWith("KElement") && !qualifiedName.Equals("HoleType")
            && !qualifiedName.Equals("Method") && !qualifiedName.Equals("Shape")
            && !qualifiedName.Equals("Position") && !qualifiedName.Equals("Surface");
         return bSpecialClass;
      }

      ///   
      ///	 <summary> * Method createKElement
      ///	 *  </summary>
      ///	 * <param name="constructi"> </param>
      ///	 * <param name="constructorArguments"> </param>
      ///	 * <returns> KElement (always != <code>null</code>) </returns>
      ///	 
      private KElement createKElement(ConstructorInfo constructi, object[] constructorArguments)
      {
         KElement newElement = null;
         string message = null;

         try
         {
            newElement = (KElement)constructi.Invoke(constructorArguments);
         }
         // re-throw on error is done below
         catch (UnauthorizedAccessException e)
         {
            message = "(DocumentJDFImpl.createKElement) IllegalAccessException caught :" + e.Message;
         }
         catch (System.Reflection.TargetException)
         {
            message = "(DocumentJDFImpl.createKElement) InstantiationException caught (abstract class?) : " + constructi.Name + "(CoreDocumentImpl, String, String, String)";
         }
         catch (TargetInvocationException e)
         {
            message = "(DocumentJDFImpl.createKElement) InvocationTargetException caught :" + e.Message;
         }
         catch (System.Exception e)
         {
            message = "(DocumentJDFImpl.createKElement) Exception caught :" + e.Message;
         }

         if (newElement == null)
         {
            if (message == null)
               message = "(DocumentJDFImpl.createKElement) Could not create an element with " + constructi.Name + "(CoreDocumentImpl, String, String, String)";
            // something went wrong
            throw new Exception(message);
         }

         return newElement;
      }

      ///   
      ///	 <summary> * Searches for the matching factory class in sm_PackageNames If a match could not be found then JDFResource.class
      ///	 * is returned if the element is in a resource pool else if the element is in the default name space
      ///	 * JDFElement.class is returned else KElement.class is returned
      ///	 *  </summary>
      ///	 * <param name="strNameSpaceURI"> the namespace of the class. only http://www.CIP4.org/JDFSchema_1_1 is the valid namespace
      ///	 *            for JDF Elements all other namespaces will return JDFElement.class or JDFResource.class only. </param>
      ///	 * <param name="qualifiedName"> the qualified name of the class </param>
      ///	 * <param name="localPart"> the local part of the qualified name
      ///	 * @return </param>
      ///	 
      public virtual System.Type getFactoryClass(string qualifiedName)
      {
         System.Type packageNameClass = null;

         try
         {
            packageNameClass = getFactoryClass(null, qualifiedName, qualifiedName);
         }
         catch (System.Exception)
         {
         }

         return packageNameClass;
      }

      private System.Type getFactoryClass(string strNameSpaceURI, string qualifiedName, string localPart)
      {

         Type packageNameClass;
         sm_ClassAlreadyInstantiated.TryGetValue(qualifiedName, out packageNameClass);

         if (packageNameClass == null)
         { // class not found in the buffer! Instantiate it and add it to the
            // buffer
            lock (sm_PackageNames)
            {
               string strClassPath = getFactoryClassPath(strNameSpaceURI, qualifiedName, localPart);

               bool normalElement = true;
               if (strClassPath == null)
               {
                  normalElement = false;
                  strClassPath = getSpecialClassPath(strNameSpaceURI, qualifiedName);
               }
               else
               {
                  normalElement = isSpecialClass(qualifiedName, strClassPath);
               }

               // assert strClassPath != null
               try
               {
                   packageNameClass = System.Type.GetType(strClassPath);
                   // Java to C# Conversion - Add this to support Unit Tests.  
                  //                          The JDFTestType element in defined in the JDFLibNet.Test assembly
                   if (packageNameClass == null)
                      packageNameClass = System.Type.GetType(strClassPath + ", JDFLibNet.Test, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", true);
               }
               catch (System.Exception e)
               {
                  // TODO Auto-generated catch block
                  throw new System.Exception(e.Message, e);
               }

               if (normalElement || strClassPath.Equals(sm_PackageNames["ResDefault"]))
               {
                  sm_ClassAlreadyInstantiated[qualifiedName] = packageNameClass;
               }
            }
         }
         return packageNameClass;
      }

      ///   
      ///	 * <param name="strNameSpaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="localPart">
      ///	 * @return </param>
      ///	 
      private string getFactoryClassPath(string strNameSpaceURI, string qualifiedName, string localPart)
      {
         // we are not yet in a JDF or JMF - it must be a KElement
         if (!bInJDFJMF)
            return "org.cip4.jdflib.core.KElement";

         string strClassPath = null;

         // CreateLink and RemoveLink are messages, no links
         if (qualifiedName.EndsWith(JDFConstants.LINK) && !ElementName.CREATELINK.Equals(qualifiedName) && !ElementName.REMOVELINK.Equals(qualifiedName))
         {
            sm_PackageNames.TryGetValue(ElementName.RESOURCELINK, out strClassPath);
         }
         else if (qualifiedName.EndsWith(JDFConstants.REF) && !qualifiedName.Equals(ElementName.TESTREF))
         {
            sm_PackageNames.TryGetValue(ElementName.REFELEMENT, out strClassPath);
         }
         else
         {
            sm_PackageNames.TryGetValue(qualifiedName, out strClassPath);
            if (strClassPath == null
               && (null == strNameSpaceURI || jdfNSURI.Equals(strNameSpaceURI) || JDFConstants.EMPTYSTRING.Equals(strNameSpaceURI)))
            { // the maps only contain local names for jdf - recheck in case of
               // prefix
               sm_PackageNames.TryGetValue(localPart, out strClassPath);
            }
         }
         return strClassPath;
      }

      ///   
      ///	 * <param name="nameSpaceURI">  </param>
      ///	 * <param name="strName"> </param>
      ///	 * <returns> Sting the class name </returns>
      ///	 
      private string getSpecialClassPath(string nameSpaceURI, string strName)
      {
         string strClassPath = null;

         string strParentNodeClass = null;
         if (m_ParentNode != null)
         {
            // strParentNodeClass = m_ParentNode.getClass().getCanonicalName();
            strParentNodeClass = m_ParentNode.GetType().FullName;
         }

         if (ElementName.HOLETYPE.Equals(strName))
         {
            if ("org.cip4.jdflib.resource.process.postpress.JDFRingBinding".Equals(strParentNodeClass))
            {
               strClassPath = "org.cip4.jdflib.span.JDFSpanHoleType";
            }
            else
            {
               strClassPath = "org.cip4.jdflib.span.JDFStringSpan";
            }
         }
         else if (ElementName.METHOD.Equals(strName))
         {
            if ("org.cip4.jdflib.resource.intent.JDFInsertingIntent".Equals(strParentNodeClass) || "org.cip4.jdflib.resource.JDFInsert".Equals(strParentNodeClass))
            {
               strClassPath = "org.cip4.jdflib.span.JDFSpanMethod";
            }
            else
            {
               strClassPath = "org.cip4.jdflib.span.JDFNameSpan";
            }
         }
         else if (ElementName.SHAPE.Equals(strName))
         {
            if ("org.cip4.jdflib.resource.intent.JDFBookCase".Equals(strParentNodeClass))
            {
               strClassPath = "org.cip4.jdflib.span.JDFSpanShape";
            }
            else
            {
               strClassPath = "org.cip4.jdflib.resource.JDFShapeElement";
            }
         }
         else if (ElementName.SURFACE.Equals(strName))
         {
            if ("org.cip4.jdflib.resource.intent.JDFLaminatingIntent".Equals(strParentNodeClass))
            {
               strClassPath = "org.cip4.jdflib.span.JDFSpanSurface";
            }
            else
            {
               strClassPath = "org.cip4.jdflib.resource.process.JDFLayout";
            }
         }
         else if (ElementName.POSITION.Equals(strName))
         {
            if ("org.cip4.jdflib.resource.JDFEmbossingItem".Equals(strParentNodeClass))
            {
               strClassPath = "org.cip4.jdflib.span.JDFXYPairSpan";
            }
            else
            {
               strClassPath = "org.cip4.jdflib.resource.process.JDFPosition";
            }
         }
         else
         {
            if (isDeepResource(strName))
            {
               strClassPath = sm_PackageNames["ResDefault"];
            }
            else
            {
               strClassPath = (nameSpaceURI == null && bInJDFJMF || JDFConstants.JDFNAMESPACE.Equals(nameSpaceURI)) ? (string)sm_PackageNames["EleDefault"] : (string)sm_PackageNames["OtherNSDefault"];
            }
         }

         return strClassPath;
      }

      ///   
      ///	 * <seealso cref= java.lang.Object#toString() </seealso>
      ///	 
      public override string ToString()
      {
         XmlElement rootElement = DocumentElement;
         if (rootElement != null)
         {
            return base.ToString() + rootElement.ToString();
         }
         return base.ToString();
      }

      internal virtual void setParentNode(XmlNode node)
      {
         m_ParentNode = node;
      }

      private bool isDeepResource(string strName)
      {
         if (m_ParentNode == null)
            return false;
         if (m_ParentNode is JDFResourcePool) // direct child of an rp
            return true;
         if (m_ParentNode is JDFResource) // partitioned resource leaf
         {
            return m_ParentNode.LocalName.Equals(strName);
         }
         return false;
      }

      
      // TODO revisit setting parent nodes when importing
      /// <summary>
      /// Attention! this only sets the initial parent for deep=true
      /// </summary>
      /// <param name="importedNode"></param>
      /// <param name="deep"></param>
      /// <returns></returns>
      [MethodImpl(MethodImplOptions.Synchronized)]
      public  override XmlNode ImportNode(XmlNode importedNode, bool deep)
      {
         if (importedNode == null)
            return null;
         lock (importedNode)
         {
            setParentNode(importedNode.ParentNode);
            return base.ImportNode(importedNode, deep);
         }
      }

      ///   
      ///	 <summary> * register all default classes in the factory mapping of the element names which occur during parsing to the
      ///	 * corresponding classes
      ///	 *  </summary>
      ///	 * <param name="strElement"> </param>
      ///	 * <param name="elemClass"> </param>
      ///	 
      static DocumentJDFImpl()
      {
         sm_PackageNames.Add("ResDefault", "org.cip4.jdflib.resource.JDFResource");
         sm_PackageNames.Add("EleDefault", "org.cip4.jdflib.core.JDFElement");
         sm_PackageNames.Add("OtherNSDefault", "org.cip4.jdflib.core.KElement");
         // sm_PackageNames.put("AttributeName",
         // "org.cip4.jdflib.core.AttributeName");

         // root elements
         sm_PackageNames.Add(ElementName.JDF, "org.cip4.jdflib.node.JDFNode");
         sm_PackageNames.Add(ElementName.JMF, "org.cip4.jdflib.jmf.JDFJMF");

         sm_PackageNames.Add(ElementName.ACKNOWLEDGE, "org.cip4.jdflib.jmf.JDFAcknowledge");
         sm_PackageNames.Add(ElementName.ACTION, "org.cip4.jdflib.resource.devicecapability.JDFAction");
         sm_PackageNames.Add(ElementName.ACTIONPOOL, "org.cip4.jdflib.resource.devicecapability.JDFActionPool");
         sm_PackageNames.Add(ElementName.ADDED, "org.cip4.jdflib.jmf.JDFAdded");
         sm_PackageNames.Add(ElementName.ADDRESS, "org.cip4.jdflib.resource.process.JDFAddress");
         sm_PackageNames.Add(ElementName.ADHESIVEBINDING, "org.cip4.jdflib.resource.process.postpress.JDFAdhesiveBinding");
         sm_PackageNames.Add(ElementName.ADHESIVEBINDINGPARAMS, "org.cip4.jdflib.resource.JDFAdhesiveBindingParams");
         sm_PackageNames.Add(ElementName.ADVANCEDPARAMS, "org.cip4.jdflib.resource.process.JDFAdvancedParams");
         sm_PackageNames.Add(ElementName.AMOUNT, "org.cip4.jdflib.span.JDFIntegerSpan");
         sm_PackageNames.Add(ElementName.AMOUNTPOOL, "org.cip4.jdflib.pool.JDFAmountPool");
         sm_PackageNames.Add(ElementName.ANCESTOR, "org.cip4.jdflib.node.JDFAncestor");
         sm_PackageNames.Add(ElementName.ANCESTORPOOL, "org.cip4.jdflib.pool.JDFAncestorPool");
         sm_PackageNames.Add(ElementName.AND, "org.cip4.jdflib.resource.devicecapability.JDFand");
         sm_PackageNames.Add(ElementName.APPROVALDETAILS, "org.cip4.jdflib.resource.process.JDFApprovalDetails");
         sm_PackageNames.Add(ElementName.APPROVALPARAMS, "org.cip4.jdflib.resource.process.JDFApprovalParams");
         sm_PackageNames.Add(ElementName.APPROVALPERSON, "org.cip4.jdflib.resource.process.JDFApprovalPerson");
         sm_PackageNames.Add(ElementName.APPROVALSUCCESS, "org.cip4.jdflib.resource.process.JDFApprovalSuccess");
         sm_PackageNames.Add(ElementName.ARGUMENTVALUE, "org.cip4.jdflib.resource.process.JDFArgumentValue");
         sm_PackageNames.Add(ElementName.ARTDELIVERY, "org.cip4.jdflib.resource.intent.JDFArtDelivery");
         sm_PackageNames.Add(ElementName.ARTDELIVERYDATE, "org.cip4.jdflib.span.JDFTimeSpan");
         sm_PackageNames.Add(ElementName.ARTDELIVERYINTENT, "org.cip4.jdflib.resource.intent.JDFArtDeliveryIntent");
         sm_PackageNames.Add(ElementName.ARTDELIVERYTYPE, "org.cip4.jdflib.resource.intent.JDFArtDeliveryType");
         sm_PackageNames.Add(ElementName.ARTHANDLING, "org.cip4.jdflib.span.JDFSpanArtHandling");
         sm_PackageNames.Add(ElementName.ASSEMBLY, "org.cip4.jdflib.resource.process.JDFAssembly");
         sm_PackageNames.Add(ElementName.ASSEMBLYSECTION, "org.cip4.jdflib.resource.process.JDFAssemblySection");
         // sm_PackageNames.put(ElementName.ASSETLISTCREATION,
         // "org.cip4.jdflib.resource.process.prepress.JDFAssetListCreation");
         sm_PackageNames.Add(ElementName.ASSETLISTCREATIONPARAMS, "org.cip4.jdflib.resource.process.prepress.JDFAssetListCreationParams");
         sm_PackageNames.Add(ElementName.AUDIT, "org.cip4.jdflib.core.JDFAudit");
         sm_PackageNames.Add(ElementName.AUDITPOOL, "org.cip4.jdflib.pool.JDFAuditPool");
         sm_PackageNames.Add(ElementName.AUTOMATEDOVERPRINTPARAMS, "org.cip4.jdflib.resource.process.JDFAutomatedOverPrintParams");
         sm_PackageNames.Add(ElementName.BACKCOATINGS, "org.cip4.jdflib.span.JDFSpanCoatings");
         sm_PackageNames.Add(ElementName.BACKCOVERCOLOR, "org.cip4.jdflib.span.JDFSpanNamedColor");
         sm_PackageNames.Add(ElementName.BAND, "org.cip4.jdflib.resource.JDFBand");
         sm_PackageNames.Add(ElementName.BARCODE, "org.cip4.jdflib.resource.JDFBarcode");
         sm_PackageNames.Add(ElementName.BARCODECOMPPARAMS, "org.cip4.jdflib.resource.process.JDFBarcodeCompParams");
         sm_PackageNames.Add(ElementName.BARCODEDETAILS, "org.cip4.jdflib.resource.process.JDFBarcodeDetails");
         sm_PackageNames.Add(ElementName.BARCODEREPROPARAMS, "org.cip4.jdflib.resource.process.JDFBarcodeReproParams");
         sm_PackageNames.Add(ElementName.BARCODEPRODUCTIONPARAMS, "org.cip4.jdflib.resource.process.JDFBarcodeProductionParams");
         sm_PackageNames.Add(ElementName.BASICPREFLIGHTTEST, "org.cip4.jdflib.resource.devicecapability.JDFBasicPreflightTest");
         sm_PackageNames.Add(ElementName.BENDINGPARAMS, "org.cip4.jdflib.resource.process.JDFBendingParams");
         sm_PackageNames.Add(ElementName.BINDERMATERIAL, "org.cip4.jdflib.span.JDFNameSpan");
         sm_PackageNames.Add(ElementName.BINDERYSIGNATURE, "org.cip4.jdflib.resource.process.JDFBinderySignature");
         sm_PackageNames.Add(ElementName.BINDINGCOLOR, "org.cip4.jdflib.span.JDFSpanNamedColor");
         sm_PackageNames.Add(ElementName.BINDINGINTENT, "org.cip4.jdflib.resource.intent.JDFBindingIntent");
         sm_PackageNames.Add(ElementName.BINDINGLENGTH, "org.cip4.jdflib.span.JDFSpanBindingLength");
         sm_PackageNames.Add(ElementName.BINDINGQUALITYPARAMS, "org.cip4.jdflib.resource.process.JDFBindingQualityParams");
         sm_PackageNames.Add(ElementName.BINDINGSIDE, "org.cip4.jdflib.span.JDFSpanBindingSide");
         sm_PackageNames.Add(ElementName.BINDINGTYPE, "org.cip4.jdflib.span.JDFSpanBindingType");
         sm_PackageNames.Add(ElementName.BINDITEM, "org.cip4.jdflib.resource.JDFBindItem");
         sm_PackageNames.Add(ElementName.BINDLIST, "org.cip4.jdflib.resource.JDFBindList");
         sm_PackageNames.Add(ElementName.BLOCKPREPARATIONPARAMS, "org.cip4.jdflib.resource.JDFBlockPreparationParams");
         sm_PackageNames.Add(ElementName.BLOCKTHREADSEWING, "org.cip4.jdflib.span.JDFOptionSpan");
         sm_PackageNames.Add(ElementName.BOOKCASE, "org.cip4.jdflib.resource.intent.JDFBookCase");
         sm_PackageNames.Add(ElementName.BOOLEANEVALUATION, "org.cip4.jdflib.resource.devicecapability.JDFBooleanEvaluation");
         sm_PackageNames.Add(ElementName.BOOLEANSTATE, "org.cip4.jdflib.resource.devicecapability.JDFBooleanState");
         sm_PackageNames.Add(ElementName.BOXAPPLICATION, "org.cip4.jdflib.resource.process.JDFBoxApplication");
         sm_PackageNames.Add(ElementName.BOXARGUMENT, "org.cip4.jdflib.resource.process.JDFBoxArgument");
         sm_PackageNames.Add(ElementName.BOXEDQUANTITY, "org.cip4.jdflib.span.JDFIntegerSpan");
         sm_PackageNames.Add(ElementName.BOXFOLDACTION, "org.cip4.jdflib.resource.process.JDFBoxFoldAction");
         sm_PackageNames.Add(ElementName.BOXFOLDINGPARAMS, "org.cip4.jdflib.resource.process.JDFBoxFoldingParams");
         sm_PackageNames.Add(ElementName.BOXPACKINGPARAMS, "org.cip4.jdflib.resource.JDFBoxPackingParams");
         sm_PackageNames.Add(ElementName.BOXSHAPE, "org.cip4.jdflib.span.JDFShapeSpan");
         sm_PackageNames.Add(ElementName.BOXTOBOXDIFFERENCE, "org.cip4.jdflib.resource.process.JDFBoxToBoxDifference");
         sm_PackageNames.Add(ElementName.BRANDNAME, "org.cip4.jdflib.span.JDFStringSpan");
         sm_PackageNames.Add(ElementName.BRIGHTNESS, "org.cip4.jdflib.span.JDFNumberSpan");
         sm_PackageNames.Add(ElementName.BUFFERPARAMS, "org.cip4.jdflib.resource.JDFBufferParams");
         sm_PackageNames.Add(ElementName.BUNDLE, "org.cip4.jdflib.resource.JDFBundle");
         sm_PackageNames.Add(ElementName.BUNDLEITEM, "org.cip4.jdflib.resource.JDFBundleItem");
         sm_PackageNames.Add(ElementName.BUNDLINGPARAMS, "org.cip4.jdflib.resource.process.postpress.JDFBundlingParams");
         sm_PackageNames.Add(ElementName.BUSINESSINFO, "org.cip4.jdflib.resource.process.JDFBusinessInfo");
         sm_PackageNames.Add(ElementName.BUYERSUPPLIED, "org.cip4.jdflib.span.JDFOptionSpan");
         sm_PackageNames.Add(ElementName.BYTEMAP, "org.cip4.jdflib.resource.process.JDFByteMap");
         sm_PackageNames.Add(ElementName.CALL, "org.cip4.jdflib.resource.devicecapability.JDFcall");
         sm_PackageNames.Add(ElementName.CARTONMAXWEIGHT, "org.cip4.jdflib.span.JDFNumberSpan");
         sm_PackageNames.Add(ElementName.CARTONQUANTITY, "org.cip4.jdflib.span.JDFIntegerSpan");
         sm_PackageNames.Add(ElementName.CARTONSHAPE, "org.cip4.jdflib.span.JDFShapeSpan");
         sm_PackageNames.Add(ElementName.CARTONSTRENGTH, "org.cip4.jdflib.span.JDFNumberSpan");
         sm_PackageNames.Add(ElementName.CASEMAKINGPARAMS, "org.cip4.jdflib.resource.JDFCaseMakingParams");
         sm_PackageNames.Add(ElementName.CASINGINPARAMS, "org.cip4.jdflib.resource.JDFCasingInParams");
         sm_PackageNames.Add(ElementName.CCITTFAXPARAMS, "org.cip4.jdflib.resource.process.JDFCCITTFaxParams");
         sm_PackageNames.Add(ElementName.CHANGEDATTRIBUTE, "org.cip4.jdflib.resource.JDFChangedAttribute");
         sm_PackageNames.Add(ElementName.CHANGEDPATH, "org.cip4.jdflib.jmf.JDFChangedPath");
         sm_PackageNames.Add(ElementName.CHANNELBINDING, "org.cip4.jdflib.resource.process.postpress.JDFChannelBinding");
         sm_PackageNames.Add(ElementName.CHANNELBINDINGPARAMS, "org.cip4.jdflib.resource.process.postpress.JDFChannelBindingParams");
         sm_PackageNames.Add(ElementName.CHOICE, "org.cip4.jdflib.resource.devicecapability.JDFchoice");
         sm_PackageNames.Add(ElementName.CIELABMEASURINGFIELD, "org.cip4.jdflib.resource.process.JDFCIELABMeasuringField");
         sm_PackageNames.Add(ElementName.COATINGS, "org.cip4.jdflib.span.JDFStringSpan");
         sm_PackageNames.Add(ElementName.COILBINDING, "org.cip4.jdflib.resource.process.postpress.JDFCoilBinding");
         sm_PackageNames.Add(ElementName.COILBINDINGPARAMS, "org.cip4.jdflib.resource.JDFCoilBindingParams");
         sm_PackageNames.Add(ElementName.COILMATERIAL, "org.cip4.jdflib.span.JDFSpanCoilMaterial");
         sm_PackageNames.Add(ElementName.COLLATINGITEM, "org.cip4.jdflib.resource.process.JDFCollatingItem");
         sm_PackageNames.Add(ElementName.COLLECTINGPARAMS, "org.cip4.jdflib.resource.process.JDFCollectingParams");
         sm_PackageNames.Add(ElementName.COLOR, "org.cip4.jdflib.resource.process.JDFColor");
         sm_PackageNames.Add(ElementName.COLORANTALIAS, "org.cip4.jdflib.resource.process.JDFColorantAlias");
         sm_PackageNames.Add(ElementName.COLORANTCONTROL, "org.cip4.jdflib.resource.process.JDFColorantControl");
         sm_PackageNames.Add(ElementName.COLORANTORDER, "org.cip4.jdflib.core.JDFSeparationList");
         sm_PackageNames.Add(ElementName.COLORANTPARAMS, "org.cip4.jdflib.core.JDFSeparationList");
         sm_PackageNames.Add(ElementName.COLORANTZONEDETAILS, "org.cip4.jdflib.resource.process.JDFColorantZoneDetails");
         sm_PackageNames.Add(ElementName.COLORCONTROLSTRIP, "org.cip4.jdflib.resource.process.JDFColorControlStrip");
         sm_PackageNames.Add(ElementName.COLORCORRECTIONOP, "org.cip4.jdflib.resource.process.prepress.JDFColorCorrectionOp");
         sm_PackageNames.Add(ElementName.COLORCORRECTIONPARAMS, "org.cip4.jdflib.resource.process.prepress.JDFColorCorrectionParams");
         sm_PackageNames.Add(ElementName.COLORINTENT, "org.cip4.jdflib.resource.intent.JDFColorIntent");
         sm_PackageNames.Add(ElementName.COLORMEASUREMENTCONDITIONS, "org.cip4.jdflib.resource.JDFColorMeasurementConditions");
         sm_PackageNames.Add(ElementName.COLORNAME, "org.cip4.jdflib.span.JDFSpanNamedColor");
         sm_PackageNames.Add(ElementName.COLORPOOL, "org.cip4.jdflib.resource.process.JDFColorPool");
         sm_PackageNames.Add(ElementName.COLORSPACECONVERSIONOP, "org.cip4.jdflib.resource.process.prepress.JDFColorSpaceConversionOp");
         sm_PackageNames.Add(ElementName.COLORSPACECONVERSIONPARAMS, "org.cip4.jdflib.resource.process.prepress.JDFColorSpaceConversionParams");
         sm_PackageNames.Add(ElementName.COLORSPACESUBSTITUTE, "org.cip4.jdflib.resource.process.prepress.JDFColorSpaceSubstitute");
         sm_PackageNames.Add(ElementName.COLORSRESULTSPOOL, "org.cip4.jdflib.resource.process.JDFColorsResultsPool");
         sm_PackageNames.Add(ElementName.COLORSTANDARD, "org.cip4.jdflib.span.JDFNameSpan");
         sm_PackageNames.Add(ElementName.COLORSUSED, "org.cip4.jdflib.core.JDFSeparationList");
         sm_PackageNames.Add(ElementName.COLORTYPE, "org.cip4.jdflib.span.JDFSpanColorType");
         sm_PackageNames.Add(ElementName.COMCHANNEL, "org.cip4.jdflib.resource.process.JDFComChannel");
         sm_PackageNames.Add(ElementName.COMMAND, "org.cip4.jdflib.jmf.JDFCommand");
         sm_PackageNames.Add(ElementName.COMMENT, "org.cip4.jdflib.core.JDFComment");
         sm_PackageNames.Add(ElementName.COMPANY, "org.cip4.jdflib.resource.process.JDFCompany");
         sm_PackageNames.Add(ElementName.COMPONENT, "org.cip4.jdflib.resource.process.JDFComponent");
         sm_PackageNames.Add(ElementName.CONSTRAINTVALUE, "org.cip4.jdflib.resource.process.JDFConstraintValue");
         sm_PackageNames.Add(ElementName.CONTACT, "org.cip4.jdflib.resource.process.JDFContact");
         sm_PackageNames.Add(ElementName.CONTACTCOPYPARAMS, "org.cip4.jdflib.resource.JDFContactCopyParams");
         sm_PackageNames.Add(ElementName.CONTAINER, "org.cip4.jdflib.resource.process.JDFContainer");
         sm_PackageNames.Add(ElementName.CONTENTDATA, "org.cip4.jdflib.resource.process.JDFContentData");
         sm_PackageNames.Add(ElementName.CONTENTLIST, "org.cip4.jdflib.resource.process.JDFContentList");
         sm_PackageNames.Add(ElementName.CONTENTOBJECT, "org.cip4.jdflib.resource.process.JDFContentObject");
         sm_PackageNames.Add(ElementName.CONVENTIONALPRINTINGPARAMS, "org.cip4.jdflib.resource.process.JDFConventionalPrintingParams");
         sm_PackageNames.Add(ElementName.COSTCENTER, "org.cip4.jdflib.resource.process.JDFCostCenter");
         sm_PackageNames.Add(ElementName.COUNTERRESET, "org.cip4.jdflib.resource.JDFCounterReset");
         sm_PackageNames.Add(ElementName.COVER, "org.cip4.jdflib.resource.process.JDFCover");
         sm_PackageNames.Add(ElementName.COVERAGE, "org.cip4.jdflib.span.JDFNumberSpan");
         sm_PackageNames.Add(ElementName.COVERAPPLICATIONPARAMS, "org.cip4.jdflib.resource.JDFCoverApplicationParams");
         sm_PackageNames.Add(ElementName.COVERCOLOR, "org.cip4.jdflib.span.JDFSpanNamedColor");
         sm_PackageNames.Add(ElementName.CREASE, "org.cip4.jdflib.resource.process.postpress.JDFCrease");
         sm_PackageNames.Add(ElementName.CREASINGPARAMS, "org.cip4.jdflib.resource.JDFCreasingParams");
         sm_PackageNames.Add(ElementName.CREATED, "org.cip4.jdflib.resource.JDFCreated");
         sm_PackageNames.Add(ElementName.CREATELINK, "org.cip4.jdflib.jmf.JDFCreateLink");
         sm_PackageNames.Add(ElementName.CREATERESOURCE, "org.cip4.jdflib.jmf.JDFCreateResource");
         sm_PackageNames.Add(ElementName.CREDITCARD, "org.cip4.jdflib.resource.JDFCreditCard");
         sm_PackageNames.Add(ElementName.CUSTOMERINFO, "org.cip4.jdflib.core.JDFCustomerInfo");
         sm_PackageNames.Add(ElementName.CUSTOMERMESSAGE, "org.cip4.jdflib.core.JDFCustomerMessage");
         sm_PackageNames.Add(ElementName.CUT, "org.cip4.jdflib.resource.process.postpress.JDFCut");
         sm_PackageNames.Add(ElementName.CUTBLOCK, "org.cip4.jdflib.resource.process.JDFCutBlock");
         sm_PackageNames.Add(ElementName.CUTMARK, "org.cip4.jdflib.resource.process.postpress.JDFCutMark");
         sm_PackageNames.Add(ElementName.CUTTINGPARAMS, "org.cip4.jdflib.resource.JDFCuttingParams");
         sm_PackageNames.Add(ElementName.CUTTYPE, "org.cip4.jdflib.span.JDFSpanCutType");
         sm_PackageNames.Add(ElementName.CYLINDERLAYOUT, "org.cip4.jdflib.resource.process.JDFCylinderLayout");
         sm_PackageNames.Add(ElementName.CYLINDERLAYOUTPREPARATIONPARAMS, "org.cip4.jdflib.resource.process.JDFCylinderLayoutPreparationParams");
         sm_PackageNames.Add(ElementName.CYLINDERPOSITION, "org.cip4.jdflib.resource.process.JDFCylinderPosition");
         sm_PackageNames.Add(ElementName.DATETIMEEVALUATION, "org.cip4.jdflib.resource.devicecapability.JDFDateTimeEvaluation");
         sm_PackageNames.Add(ElementName.DATETIMESTATE, "org.cip4.jdflib.resource.devicecapability.JDFDateTimeState");
         sm_PackageNames.Add(ElementName.DCTPARAMS, "org.cip4.jdflib.resource.process.JDFDCTParams");
         sm_PackageNames.Add(ElementName.DBMERGEPARAMS, "org.cip4.jdflib.resource.process.JDFDBMergeParams");
         sm_PackageNames.Add(ElementName.DBRULES, "org.cip4.jdflib.resource.process.JDFDBRules");
         sm_PackageNames.Add(ElementName.DBSCHEMA, "org.cip4.jdflib.resource.JDFDBSchema");
         sm_PackageNames.Add(ElementName.DBSELECTION, "org.cip4.jdflib.resource.process.JDFDBSelection");
         sm_PackageNames.Add(ElementName.DELETED, "org.cip4.jdflib.resource.JDFDeleted");
         sm_PackageNames.Add(ElementName.DELIVERYCHARGE, "org.cip4.jdflib.span.JDFSpanDeliveryCharge");
         sm_PackageNames.Add(ElementName.DELIVERYINTENT, "org.cip4.jdflib.resource.intent.JDFDeliveryIntent");
         sm_PackageNames.Add(ElementName.DELIVERYPARAMS, "org.cip4.jdflib.resource.process.JDFDeliveryParams");
         sm_PackageNames.Add(ElementName.DENSITYMEASURINGFIELD, "org.cip4.jdflib.resource.process.JDFDensityMeasuringField");
         sm_PackageNames.Add(ElementName.DEPENDENCIES, "org.cip4.jdflib.resource.process.JDFDependencies");
         sm_PackageNames.Add(ElementName.DEVCAP, "org.cip4.jdflib.resource.devicecapability.JDFDevCap");
         sm_PackageNames.Add(ElementName.DEVCAPPOOL, "org.cip4.jdflib.resource.devicecapability.JDFDevCapPool");
         sm_PackageNames.Add(ElementName.DEVCAPS, "org.cip4.jdflib.resource.devicecapability.JDFDevCaps");
         sm_PackageNames.Add(ElementName.DEVELOPINGPARAMS, "org.cip4.jdflib.resource.JDFDevelopingParams");
         sm_PackageNames.Add(ElementName.DEVICE, "org.cip4.jdflib.resource.JDFDevice");
         sm_PackageNames.Add(ElementName.DEVICECAP, "org.cip4.jdflib.resource.devicecapability.JDFDeviceCap");
         sm_PackageNames.Add(ElementName.DEVICECOLORANTORDER, "org.cip4.jdflib.core.JDFSeparationList");
         sm_PackageNames.Add(ElementName.DEVICEFILTER, "org.cip4.jdflib.jmf.JDFDeviceFilter");
         sm_PackageNames.Add(ElementName.DEVICEINFO, "org.cip4.jdflib.jmf.JDFDeviceInfo");
         sm_PackageNames.Add(ElementName.DEVICELIST, "org.cip4.jdflib.resource.JDFDeviceList");
         sm_PackageNames.Add(ElementName.DEVICEMARK, "org.cip4.jdflib.resource.JDFDeviceMark");
         sm_PackageNames.Add(ElementName.DEVICENCOLOR, "org.cip4.jdflib.resource.process.JDFDeviceNColor");
         sm_PackageNames.Add(ElementName.DEVICENSPACE, "org.cip4.jdflib.resource.process.JDFDeviceNSpace");
         sm_PackageNames.Add(ElementName.DIELAYOUT, "org.cip4.jdflib.resource.process.JDFDieLayout");
         sm_PackageNames.Add(ElementName.DIGITALDELIVERYPARAMS, "org.cip4.jdflib.resource.process.prepress.JDFDigitalDeliveryParams");
         sm_PackageNames.Add(ElementName.DIGITALMEDIA, "org.cip4.jdflib.resource.process.JDFDigitalMedia");
         sm_PackageNames.Add(ElementName.DIGITALPRINTINGPARAMS, "org.cip4.jdflib.resource.process.JDFDigitalPrintingParams");
         sm_PackageNames.Add(ElementName.DIMENSIONS, "org.cip4.jdflib.span.JDFXYPairSpan");
         sm_PackageNames.Add(ElementName.DIRECTION, "org.cip4.jdflib.span.JDFSpanDirection");
         sm_PackageNames.Add(ElementName.DISJOINTING, "org.cip4.jdflib.resource.process.JDFDisjointing");
         sm_PackageNames.Add(ElementName.DISPLAYGROUP, "org.cip4.jdflib.resource.devicecapability.JDFDisplayGroup");
         sm_PackageNames.Add(ElementName.DISPLAYGROUPPOOL, "org.cip4.jdflib.resource.devicecapability.JDFDisplayGroupPool");
         sm_PackageNames.Add(ElementName.DISPOSITION, "org.cip4.jdflib.resource.process.JDFDisposition");
         sm_PackageNames.Add(ElementName.DIVIDINGPARAMS, "org.cip4.jdflib.resource.process.JDFDividingParams");
         sm_PackageNames.Add(ElementName.DOCUMENTRESULTSPOOL, "org.cip4.jdflib.resource.process.JDFDocumentResultsPool");
         sm_PackageNames.Add(ElementName.DROP, "org.cip4.jdflib.resource.process.JDFDrop");
         sm_PackageNames.Add(ElementName.DROPINTENT, "org.cip4.jdflib.resource.intent.JDFDropIntent");
         sm_PackageNames.Add(ElementName.DROPITEM, "org.cip4.jdflib.resource.process.JDFDropItem");
         sm_PackageNames.Add(ElementName.DROPITEMINTENT, "org.cip4.jdflib.resource.intent.JDFDropItemIntent");
         sm_PackageNames.Add(ElementName.DURATIONEVALUATION, "org.cip4.jdflib.resource.devicecapability.JDFDurationEvaluation");
         sm_PackageNames.Add(ElementName.DURATIONSTATE, "org.cip4.jdflib.resource.devicecapability.JDFDurationState");
         sm_PackageNames.Add(ElementName.DYNAMICFIELD, "org.cip4.jdflib.resource.process.JDFDynamicField");
         sm_PackageNames.Add(ElementName.DYNAMICINPUT, "org.cip4.jdflib.resource.process.JDFDynamicInput");
         sm_PackageNames.Add(ElementName.EARLIEST, "org.cip4.jdflib.span.JDFTimeSpan");
         sm_PackageNames.Add(ElementName.EDGEANGLE, "org.cip4.jdflib.span.JDFNumberSpan");
         sm_PackageNames.Add(ElementName.EDGEGLUE, "org.cip4.jdflib.span.JDFSpanGlue");
         sm_PackageNames.Add(ElementName.EDGEGLUING, "org.cip4.jdflib.resource.JDFEdgeGluing");
         sm_PackageNames.Add(ElementName.EDGESHAPE, "org.cip4.jdflib.span.JDFSpanEdgeShape");
         sm_PackageNames.Add(ElementName.ELEMENTCOLORPARAMS, "org.cip4.jdflib.resource.process.JDFElementColorParams");
         sm_PackageNames.Add(ElementName.EMBOSS, "org.cip4.jdflib.resource.JDFEmboss");
         sm_PackageNames.Add(ElementName.EMBOSSINGINTENT, "org.cip4.jdflib.resource.intent.JDFEmbossingIntent");
         sm_PackageNames.Add(ElementName.EMBOSSINGITEM, "org.cip4.jdflib.resource.JDFEmbossingItem");
         sm_PackageNames.Add(ElementName.EMBOSSINGPARAMS, "org.cip4.jdflib.resource.JDFEmbossingParams");
         sm_PackageNames.Add(ElementName.EMBOSSINGTYPE, "org.cip4.jdflib.span.JDFStringSpan");
         sm_PackageNames.Add(ElementName.EMPLOYEE, "org.cip4.jdflib.resource.process.JDFEmployee");
         sm_PackageNames.Add(ElementName.EMPLOYEEDEF, "org.cip4.jdflib.jmf.JDFEmployeeDef");
         sm_PackageNames.Add(ElementName.ENDSHEET, "org.cip4.jdflib.resource.process.postpress.JDFEndSheet");
         sm_PackageNames.Add(ElementName.ENDSHEETGLUINGPARAMS, "org.cip4.jdflib.resource.JDFEndSheetGluingParams");
         sm_PackageNames.Add(ElementName.ENDSHEETS, "org.cip4.jdflib.span.JDFOptionSpan");
         sm_PackageNames.Add(ElementName.ENUMERATIONEVALUATION, "org.cip4.jdflib.resource.devicecapability.JDFEnumerationEvaluation");
         sm_PackageNames.Add(ElementName.ENUMERATIONSTATE, "org.cip4.jdflib.resource.devicecapability.JDFEnumerationState");
         sm_PackageNames.Add(ElementName.ERROR, "org.cip4.jdflib.resource.JDFError");
         sm_PackageNames.Add(ElementName.ERRORDATA, "org.cip4.jdflib.resource.JDFErrorData");
         sm_PackageNames.Add(ElementName.EVENT, "org.cip4.jdflib.resource.JDFEvent");
         sm_PackageNames.Add(ElementName.EXPOSEDMEDIA, "org.cip4.jdflib.resource.process.JDFExposedMedia");
         sm_PackageNames.Add(ElementName.EXTENDEDADDRESS, "org.cip4.jdflib.core.JDFComment");
         sm_PackageNames.Add(ElementName.EXTERNALIMPOSITIONTEMPLATE, "org.cip4.jdflib.resource.process.JDFExternalImpositionTemplate");
         sm_PackageNames.Add(ElementName.EXTRAVALUES, "org.cip4.jdflib.resource.process.JDFExtraValues");
         sm_PackageNames.Add(ElementName.FCNKEY, "org.cip4.jdflib.resource.JDFFCNKey");
         sm_PackageNames.Add(ElementName.FEATUREATTRIBUTE, "org.cip4.jdflib.resource.devicecapability.JDFFeatureAttribute");
         sm_PackageNames.Add(ElementName.FEATUREPOOL, "org.cip4.jdflib.resource.devicecapability.JDFFeaturePool");
         sm_PackageNames.Add(ElementName.FEEDER, "org.cip4.jdflib.resource.process.JDFFeeder");
         sm_PackageNames.Add(ElementName.FEEDERQUALITYPARAMS, "org.cip4.jdflib.resource.process.JDFFeederQualityParams");
         sm_PackageNames.Add(ElementName.FEEDINGPARAMS, "org.cip4.jdflib.resource.process.JDFFeedingParams");
         sm_PackageNames.Add(ElementName.FILEALIAS, "org.cip4.jdflib.resource.process.JDFFileAlias");
         sm_PackageNames.Add(ElementName.FILESPEC, "org.cip4.jdflib.resource.process.JDFFileSpec");
         sm_PackageNames.Add(ElementName.FILETYPERESULTSPOOL, "org.cip4.jdflib.resource.process.prepress.JDFFileTypeResultsPool");
         sm_PackageNames.Add(ElementName.FINISHEDDIMENSIONS, "org.cip4.jdflib.span.JDFShapeSpan");
         sm_PackageNames.Add(ElementName.FINISHEDGRAINDIRECTION, "org.cip4.jdflib.span.JDFSpanFinishedGrainDirection");
         sm_PackageNames.Add(ElementName.FITPOLICY, "org.cip4.jdflib.resource.JDFFitPolicy");
         sm_PackageNames.Add(ElementName.FLATEPARAMS, "org.cip4.jdflib.resource.process.JDFFlateParams");
         sm_PackageNames.Add(ElementName.FLUSHEDRESOURCES, "org.cip4.jdflib.jmf.JDFFlushedResources");
         sm_PackageNames.Add(ElementName.FLUSHQUEUEINFO, "org.cip4.jdflib.jmf.JDFFlushQueueInfo");
         sm_PackageNames.Add(ElementName.FLUSHQUEUEPARAMS, "org.cip4.jdflib.jmf.JDFFlushQueueParams");
         sm_PackageNames.Add(ElementName.FLUSHRESOURCEPARAMS, "org.cip4.jdflib.jmf.JDFFlushResourceParams");
         sm_PackageNames.Add(ElementName.FOILCOLOR, "org.cip4.jdflib.span.JDFSpanNamedColor");
         sm_PackageNames.Add(ElementName.FOLD, "org.cip4.jdflib.resource.process.postpress.JDFFold");
         sm_PackageNames.Add(ElementName.FOLDERPRODUCTION, "org.cip4.jdflib.resource.process.JDFFolderProduction");
         sm_PackageNames.Add(ElementName.FOLDINGCATALOG, "org.cip4.jdflib.span.JDFNameSpan");
         sm_PackageNames.Add(ElementName.FOLDINGINTENT, "org.cip4.jdflib.resource.intent.JDFFoldingIntent");
         sm_PackageNames.Add(ElementName.FOLDINGPARAMS, "org.cip4.jdflib.resource.process.postpress.JDFFoldingParams");
         sm_PackageNames.Add(ElementName.FOLDOPERATION, "org.cip4.jdflib.resource.process.JDFFoldOperation");
         sm_PackageNames.Add(ElementName.FONTPARAMS, "org.cip4.jdflib.resource.process.JDFFontParams");
         sm_PackageNames.Add(ElementName.FONTPOLICY, "org.cip4.jdflib.resource.process.JDFFontPolicy");
         sm_PackageNames.Add(ElementName.FONTSRESULTSPOOL, "org.cip4.jdflib.resource.process.prepress.JDFFontsResultsPool");
         sm_PackageNames.Add(ElementName.FORMATCONVERSIONPARAMS, "org.cip4.jdflib.resource.JDFFormatConversionParams");
         sm_PackageNames.Add(ElementName.FREQUENCYSELECTION, "org.cip4.jdflib.span.JDFSpanFrequencySelection");
         sm_PackageNames.Add(ElementName.FRONTCOATINGS, "org.cip4.jdflib.span.JDFSpanCoatings");
         sm_PackageNames.Add(ElementName.GANGCMDFILTER, "org.cip4.jdflib.jmf.JDFGangCmdFilter");
         sm_PackageNames.Add(ElementName.GANGINFO, "org.cip4.jdflib.jmf.JDFGangInfo");
         sm_PackageNames.Add(ElementName.GANGQUFILTER, "org.cip4.jdflib.jmf.JDFGangQuFilter");
         sm_PackageNames.Add(ElementName.GATHERINGPARAMS, "org.cip4.jdflib.resource.JDFGatheringParams");
         sm_PackageNames.Add(ElementName.GENERALID, "org.cip4.jdflib.resource.process.JDFGeneralID");
         sm_PackageNames.Add(ElementName.GLUE, "org.cip4.jdflib.resource.process.postpress.JDFGlue");
         sm_PackageNames.Add(ElementName.GLUEAPPLICATION, "org.cip4.jdflib.resource.process.postpress.JDFGlueApplication");
         sm_PackageNames.Add(ElementName.GLUELINE, "org.cip4.jdflib.resource.process.postpress.JDFGlueLine");
         sm_PackageNames.Add(ElementName.GLUEPROCEDURE, "org.cip4.jdflib.span.JDFSpanGlueProcedure");
         sm_PackageNames.Add(ElementName.GLUETYPE, "org.cip4.jdflib.span.JDFSpanGlueType");
         sm_PackageNames.Add(ElementName.GLUINGPARAMS, "org.cip4.jdflib.resource.JDFGluingParams");
         sm_PackageNames.Add(ElementName.GRADE, "org.cip4.jdflib.span.JDFIntegerSpan");
         sm_PackageNames.Add(ElementName.GRAINDIRECTION, "org.cip4.jdflib.span.JDFSpanGrainDirection");
         sm_PackageNames.Add(ElementName.HALFTONE, "org.cip4.jdflib.span.JDFOptionSpan");
         sm_PackageNames.Add(ElementName.HARDCOVERBINDING, "org.cip4.jdflib.resource.JDFHardCoverBinding");
         sm_PackageNames.Add(ElementName.HEADBANDAPPLICATIONPARAMS, "org.cip4.jdflib.resource.JDFHeadBandApplicationParams");
         sm_PackageNames.Add(ElementName.HEADBANDCOLOR, "org.cip4.jdflib.span.JDFSpanNamedColor");
         sm_PackageNames.Add(ElementName.HEADBANDS, "org.cip4.jdflib.span.JDFOptionSpan");
         sm_PackageNames.Add(ElementName.HEIGHT, "org.cip4.jdflib.span.JDFNumberSpan");
         sm_PackageNames.Add(ElementName.HOLE, "org.cip4.jdflib.resource.process.postpress.JDFHole");
         sm_PackageNames.Add(ElementName.HOLECOUNT, "org.cip4.jdflib.span.JDFIntegerSpan");
         sm_PackageNames.Add(ElementName.HOLELINE, "org.cip4.jdflib.resource.JDFHoleLine");
         sm_PackageNames.Add(ElementName.HOLELIST, "org.cip4.jdflib.resource.process.postpress.JDFHoleList");
         sm_PackageNames.Add(ElementName.HOLEMAKINGINTENT, "org.cip4.jdflib.resource.intent.JDFHoleMakingIntent");
         sm_PackageNames.Add(ElementName.HOLEMAKINGPARAMS, "org.cip4.jdflib.resource.process.postpress.JDFHoleMakingParams");
         // "HoleType" is context sensitive, see handleOtherElements() and
         // putConstructorToHashMap()
         sm_PackageNames.Add(ElementName.ICON, "org.cip4.jdflib.resource.JDFIcon");
         sm_PackageNames.Add(ElementName.ICONLIST, "org.cip4.jdflib.resource.JDFIconList");
         sm_PackageNames.Add(ElementName.IDENTICAL, "org.cip4.jdflib.resource.process.JDFIdentical");
         sm_PackageNames.Add(ElementName.IDENTIFICATIONFIELD, "org.cip4.jdflib.resource.process.JDFIdentificationField");
         sm_PackageNames.Add(ElementName.IDINFO, "org.cip4.jdflib.jmf.JDFIDInfo");
         sm_PackageNames.Add(ElementName.IDPCOVER, "org.cip4.jdflib.resource.JDFIDPCover");
         sm_PackageNames.Add(ElementName.IDPFINISHING, "org.cip4.jdflib.resource.process.JDFIDPFinishing");
         sm_PackageNames.Add(ElementName.IDPFOLDING, "org.cip4.jdflib.resource.process.JDFIDPFolding");
         sm_PackageNames.Add(ElementName.IDPHOLEMAKING, "org.cip4.jdflib.resource.process.JDFIDPHoleMaking");
         sm_PackageNames.Add(ElementName.IDPIMAGESHIFT, "org.cip4.jdflib.resource.JDFIDPImageShift");
         sm_PackageNames.Add(ElementName.IDPJOBSHEET, "org.cip4.jdflib.resource.JDFIDPJobSheet");
         sm_PackageNames.Add(ElementName.IDPLAYOUT, "org.cip4.jdflib.resource.process.JDFIDPLayout");
         sm_PackageNames.Add(ElementName.IDPRINTINGPARAMS, "org.cip4.jdflib.resource.process.press.JDFIDPrintingParams");
         sm_PackageNames.Add(ElementName.IDPSTITCHING, "org.cip4.jdflib.resource.process.JDFIDPStitching");
         sm_PackageNames.Add(ElementName.IDPTRIMMING, "org.cip4.jdflib.resource.process.JDFIDPTrimming");
         sm_PackageNames.Add(ElementName.IMAGECOMPRESSION, "org.cip4.jdflib.resource.JDFImageCompression");
         sm_PackageNames.Add(ElementName.IMAGECOMPRESSIONPARAMS, "org.cip4.jdflib.resource.process.JDFImageCompressionParams");
         sm_PackageNames.Add(ElementName.IMAGEREPLACEMENTPARAMS, "org.cip4.jdflib.resource.process.JDFImageReplacementParams");
         sm_PackageNames.Add(ElementName.IMAGESETTERPARAMS, "org.cip4.jdflib.resource.process.JDFImageSetterParams");
         sm_PackageNames.Add(ElementName.IMAGESHIFT, "org.cip4.jdflib.resource.JDFImageShift");
         sm_PackageNames.Add(ElementName.IMAGESIZE, "org.cip4.jdflib.span.JDFXYPairSpan");
         sm_PackageNames.Add(ElementName.IMAGESRESULTSPOOL, "org.cip4.jdflib.resource.process.JDFImagesResultsPool");
         sm_PackageNames.Add(ElementName.IMAGESTRATEGY, "org.cip4.jdflib.span.JDFSpanImageStrategy");
         sm_PackageNames.Add(ElementName.INK, "org.cip4.jdflib.resource.process.prepress.JDFInk");
         sm_PackageNames.Add(ElementName.INKMANUFACTURER, "org.cip4.jdflib.span.JDFNameSpan");
         sm_PackageNames.Add(ElementName.INKZONECALCULATIONPARAMS, "org.cip4.jdflib.resource.process.prepress.JDFInkZoneCalculationParams");
         sm_PackageNames.Add(ElementName.INKZONEPROFILE, "org.cip4.jdflib.resource.process.prepress.JDFInkZoneProfile");
         sm_PackageNames.Add(ElementName.INSERT, "org.cip4.jdflib.resource.JDFInsert");
         sm_PackageNames.Add(ElementName.INSERTINGINTENT, "org.cip4.jdflib.resource.intent.JDFInsertingIntent");
         sm_PackageNames.Add(ElementName.INSERTINGPARAMS, "org.cip4.jdflib.resource.JDFInsertingParams");
         sm_PackageNames.Add(ElementName.INSERTLIST, "org.cip4.jdflib.resource.JDFInsertList");
         sm_PackageNames.Add(ElementName.INSERTSHEET, "org.cip4.jdflib.resource.process.JDFInsertSheet");
         sm_PackageNames.Add(ElementName.INTEGEREVALUATION, "org.cip4.jdflib.resource.devicecapability.JDFIntegerEvaluation");
         sm_PackageNames.Add(ElementName.INTEGERSTATE, "org.cip4.jdflib.resource.devicecapability.JDFIntegerState");
         sm_PackageNames.Add(ElementName.INTENTRESOURCE, "org.cip4.jdflib.resource.intent.JDFIntentResource");
         sm_PackageNames.Add(ElementName.INTERPRETEDPDLDATA, "org.cip4.jdflib.resource.process.JDFInterpretedPDLData");
         sm_PackageNames.Add(ElementName.INTERPRETINGPARAMS, "org.cip4.jdflib.resource.JDFInterpretingParams");
         sm_PackageNames.Add(ElementName.ISPRESENTEVALUATION, "org.cip4.jdflib.resource.devicecapability.JDFIsPresentEvaluation");
         sm_PackageNames.Add(ElementName.JACKET, "org.cip4.jdflib.span.JDFSpanJacket");
         sm_PackageNames.Add(ElementName.JACKETINGPARAMS, "org.cip4.jdflib.resource.JDFJacketingParams");
         sm_PackageNames.Add(ElementName.JAPANBIND, "org.cip4.jdflib.span.JDFOptionSpan");
         sm_PackageNames.Add(ElementName.JBIG2PARAMS, "org.cip4.jdflib.resource.process.JDFJBIG2Params");
         sm_PackageNames.Add(ElementName.JDFCONTROLLER, "org.cip4.jdflib.jmf.JDFJDFController");
         sm_PackageNames.Add(ElementName.JDFSERVICE, "org.cip4.jdflib.jmf.JDFJDFService");
         sm_PackageNames.Add(ElementName.JOBFIELD, "org.cip4.jdflib.resource.JDFJobField");
         sm_PackageNames.Add(ElementName.JOBPHASE, "org.cip4.jdflib.jmf.JDFJobPhase");
         sm_PackageNames.Add(ElementName.JOBSHEET, "org.cip4.jdflib.resource.JDFJobSheet");
         sm_PackageNames.Add(ElementName.JPEG2000PARAMS, "org.cip4.jdflib.resource.process.JDFJPEG2000Params");
         sm_PackageNames.Add(ElementName.KNOWNMSGQUPARAMS, "org.cip4.jdflib.jmf.JDFKnownMsgQuParams");
         sm_PackageNames.Add(ElementName.LABELINGPARAMS, "org.cip4.jdflib.resource.JDFLabelingParams");
         sm_PackageNames.Add(ElementName.LAMINATED, "org.cip4.jdflib.span.JDFOptionSpan");
         sm_PackageNames.Add(ElementName.LAMINATINGINTENT, "org.cip4.jdflib.resource.intent.JDFLaminatingIntent");
         sm_PackageNames.Add(ElementName.LAMINATINGPARAMS, "org.cip4.jdflib.resource.JDFLaminatingParams");
         sm_PackageNames.Add(ElementName.LAYERDETAILS, "org.cip4.jdflib.resource.JDFLayerDetails");
         sm_PackageNames.Add(ElementName.LAYERLIST, "org.cip4.jdflib.resource.JDFLayerList");
         sm_PackageNames.Add(ElementName.LAYOUT, "org.cip4.jdflib.resource.process.JDFLayout");
         sm_PackageNames.Add(ElementName.LAYOUTELEMENT, "org.cip4.jdflib.resource.process.JDFLayoutElement");
         sm_PackageNames.Add(ElementName.LAYOUTELEMENTPART, "org.cip4.jdflib.resource.process.JDFLayoutElementPart");
         sm_PackageNames.Add(ElementName.LAYOUTELEMENTPRODUCTIONPARAMS, "org.cip4.jdflib.resource.process.JDFLayoutElementProductionParams");
         sm_PackageNames.Add(ElementName.LAYOUTINTENT, "org.cip4.jdflib.resource.intent.JDFLayoutIntent");
         sm_PackageNames.Add(ElementName.LAYOUTPREPARATIONPARAMS, "org.cip4.jdflib.resource.JDFLayoutPreparationParams");
         sm_PackageNames.Add(ElementName.LEVEL, "org.cip4.jdflib.span.JDFSpanLevel");
         sm_PackageNames.Add(ElementName.LOC, "org.cip4.jdflib.resource.devicecapability.JDFLoc");
         sm_PackageNames.Add(ElementName.LOCATION, "org.cip4.jdflib.resource.JDFLocation");
         sm_PackageNames.Add(ElementName.LONGFOLD, "org.cip4.jdflib.resource.process.JDFLongFold");
         sm_PackageNames.Add(ElementName.LONGGLUE, "org.cip4.jdflib.resource.process.JDFLongGlue");
         sm_PackageNames.Add(ElementName.LONGITUDINALRIBBONOPERATIONPARAMS, "org.cip4.jdflib.resource.process.JDFLongitudinalRibbonOperationParams");
         sm_PackageNames.Add(ElementName.LONGPERFORATE, "org.cip4.jdflib.resource.process.JDFLongPerforate");
         sm_PackageNames.Add(ElementName.LONGSLIT, "org.cip4.jdflib.resource.process.JDFLongSlit");
         sm_PackageNames.Add(ElementName.LOT, "org.cip4.jdflib.resource.process.JDFLot");
         sm_PackageNames.Add(ElementName.LZWPARAMS, "org.cip4.jdflib.resource.process.JDFLZWParams");
         sm_PackageNames.Add(ElementName.MACRO, "org.cip4.jdflib.resource.devicecapability.JDFmacro");
         sm_PackageNames.Add(ElementName.MACROPOOL, "org.cip4.jdflib.resource.devicecapability.JDFMacroPool");
         sm_PackageNames.Add(ElementName.MANUALLABORPARAMS, "org.cip4.jdflib.resource.process.JDFManualLaborParams");
         sm_PackageNames.Add(ElementName.MARKOBJECT, "org.cip4.jdflib.resource.JDFMarkObject");
         sm_PackageNames.Add(ElementName.MATERIAL, "org.cip4.jdflib.span.JDFStringSpan");
         sm_PackageNames.Add(ElementName.MATRIXEVALUATION, "org.cip4.jdflib.resource.devicecapability.JDFMatrixEvaluation");
         sm_PackageNames.Add(ElementName.MATRIXSTATE, "org.cip4.jdflib.resource.devicecapability.JDFMatrixState");
         sm_PackageNames.Add(ElementName.MEDIA, "org.cip4.jdflib.resource.process.JDFMedia");
         sm_PackageNames.Add(ElementName.MEDIACOLOR, "org.cip4.jdflib.span.JDFSpanNamedColor");
         sm_PackageNames.Add(ElementName.MEDIAINTENT, "org.cip4.jdflib.resource.intent.JDFMediaIntent");
         sm_PackageNames.Add(ElementName.MEDIALAYERS, "org.cip4.jdflib.resource.process.JDFMediaLayers");
         sm_PackageNames.Add(ElementName.MEDIASOURCE, "org.cip4.jdflib.resource.process.JDFMediaSource");
         sm_PackageNames.Add(ElementName.MEDIATYPE, "org.cip4.jdflib.span.JDFSpanMediaType");
         sm_PackageNames.Add(ElementName.MEDIAUNIT, "org.cip4.jdflib.span.JDFSpanMediaUnit");
         sm_PackageNames.Add(ElementName.MERGED, "org.cip4.jdflib.resource.JDFMerged");
         sm_PackageNames.Add(ElementName.MESSAGE, "org.cip4.jdflib.jmf.JDFMessage");
         sm_PackageNames.Add(ElementName.MESSAGESERVICE, "org.cip4.jdflib.jmf.JDFMessageService");
         // "Method" is context sensitive, see handleOtherElements() and
         // putConstructorToHashMap()
         sm_PackageNames.Add(ElementName.MILESTONE, "org.cip4.jdflib.resource.JDFMilestone");
         sm_PackageNames.Add(ElementName.MISCCONSUMABLE, "org.cip4.jdflib.resource.process.JDFMiscConsumable");
         sm_PackageNames.Add(ElementName.MISDETAILS, "org.cip4.jdflib.resource.process.JDFMISDetails");
         sm_PackageNames.Add(ElementName.MODIFIED, "org.cip4.jdflib.resource.JDFModified");
         sm_PackageNames.Add(ElementName.MODIFYNODECMDPARAMS, "org.cip4.jdflib.jmf.JDFModifyNodeCmdParams");
         sm_PackageNames.Add(ElementName.MODULE, "org.cip4.jdflib.resource.devicecapability.JDFModule");
         sm_PackageNames.Add(ElementName.MODULECAP, "org.cip4.jdflib.resource.devicecapability.JDFModuleCap");
         sm_PackageNames.Add(ElementName.MODULEPHASE, "org.cip4.jdflib.resource.JDFModulePhase");
         sm_PackageNames.Add(ElementName.MODULEPOOL, "org.cip4.jdflib.resource.devicecapability.JDFModulePool");
         sm_PackageNames.Add(ElementName.MODULESTATUS, "org.cip4.jdflib.resource.JDFModuleStatus");
         sm_PackageNames.Add(ElementName.MOVERESOURCE, "org.cip4.jdflib.jmf.JDFMoveResource");
         sm_PackageNames.Add(ElementName.MSGFILTER, "org.cip4.jdflib.jmf.JDFMsgFilter");
         sm_PackageNames.Add(ElementName.NAMEEVALUATION, "org.cip4.jdflib.resource.devicecapability.JDFNameEvaluation");
         sm_PackageNames.Add(ElementName.NAMESTATE, "org.cip4.jdflib.resource.devicecapability.JDFNameState");
         sm_PackageNames.Add(ElementName.NEWCOMMENT, "org.cip4.jdflib.jmf.JDFNewComment");
         sm_PackageNames.Add(ElementName.NEWJDFCMDPARAMS, "org.cip4.jdflib.jmf.JDFNewJDFCmdParams");
         sm_PackageNames.Add(ElementName.NEWJDFQUPARAMS, "org.cip4.jdflib.jmf.JDFNewJDFQuParams");
         sm_PackageNames.Add(ElementName.NODEINFO, "org.cip4.jdflib.core.JDFNodeInfo");
         sm_PackageNames.Add(ElementName.NODEINFOCMDPARAMS, "org.cip4.jdflib.jmf.JDFNodeInfoCmdParams");
         sm_PackageNames.Add(ElementName.NODEINFOQUPARAMS, "org.cip4.jdflib.jmf.JDFNodeInfoQuParams");
         sm_PackageNames.Add(ElementName.NODEINFORESP, "org.cip4.jdflib.jmf.JDFNodeInfoResp");
         sm_PackageNames.Add(ElementName.NOT, "org.cip4.jdflib.resource.devicecapability.JDFnot");
         sm_PackageNames.Add(ElementName.NOTIFICATION, "org.cip4.jdflib.resource.JDFNotification");
         sm_PackageNames.Add(ElementName.NOTIFICATIONDEF, "org.cip4.jdflib.jmf.JDFNotificationDef");
         sm_PackageNames.Add(ElementName.NOTIFICATIONFILTER, "org.cip4.jdflib.resource.process.JDFNotificationFilter");
         sm_PackageNames.Add(ElementName.NUMBEREVALUATION, "org.cip4.jdflib.resource.devicecapability.JDFNumberEvaluation");
         sm_PackageNames.Add(ElementName.NUMBERINGINTENT, "org.cip4.jdflib.resource.intent.JDFNumberingIntent");
         sm_PackageNames.Add(ElementName.NUMBERINGPARAM, "org.cip4.jdflib.resource.process.JDFNumberingParam");
         sm_PackageNames.Add(ElementName.NUMBERINGPARAMS, "org.cip4.jdflib.resource.JDFNumberingParams");
         sm_PackageNames.Add(ElementName.NUMBERITEM, "org.cip4.jdflib.resource.JDFNumberItem");
         sm_PackageNames.Add(ElementName.NUMBERSTATE, "org.cip4.jdflib.resource.devicecapability.JDFNumberState");
         sm_PackageNames.Add(ElementName.OBJECTRESOLUTION, "org.cip4.jdflib.resource.process.JDFObjectResolution");
         sm_PackageNames.Add(ElementName.OBSERVATIONTARGET, "org.cip4.jdflib.resource.JDFObservationTarget");
         sm_PackageNames.Add(ElementName.OCCUPATION, "org.cip4.jdflib.jmf.JDFOccupation");
         sm_PackageNames.Add(ElementName.OCGCONTROL, "org.cip4.jdflib.resource.process.JDFOCGControl");
         sm_PackageNames.Add(ElementName.OFFERRANGE, "org.cip4.jdflib.core.JDFComment");
         sm_PackageNames.Add(ElementName.OPACITY, "org.cip4.jdflib.span.JDFSpanOpacity");
         sm_PackageNames.Add(ElementName.OR, "org.cip4.jdflib.resource.devicecapability.JDFor");
         sm_PackageNames.Add(ElementName.ORDERINGPARAMS, "org.cip4.jdflib.resource.process.JDFOrderingParams");
         sm_PackageNames.Add(ElementName.ORGANIZATIONALUNIT, "org.cip4.jdflib.core.JDFComment");
         sm_PackageNames.Add(ElementName.ORIENTATION, "org.cip4.jdflib.span.JDFNumberSpan");
         sm_PackageNames.Add(ElementName.OTHERWISE, "org.cip4.jdflib.resource.devicecapability.JDFotherwise");
         sm_PackageNames.Add(ElementName.OVERAGE, "org.cip4.jdflib.span.JDFNumberSpan");
         sm_PackageNames.Add(ElementName.PACKINGINTENT, "org.cip4.jdflib.resource.intent.JDFPackingIntent");
         sm_PackageNames.Add(ElementName.PACKINGPARAMS, "org.cip4.jdflib.resource.process.JDFPackingParams");
         sm_PackageNames.Add(ElementName.PAGEASSIGNEDLIST, "org.cip4.jdflib.resource.process.JDFPageAssignedList");
         sm_PackageNames.Add(ElementName.PAGECELL, "org.cip4.jdflib.resource.JDFPageCell");
         sm_PackageNames.Add(ElementName.PAGEDATA, "org.cip4.jdflib.resource.process.JDFPageData");
         sm_PackageNames.Add(ElementName.PAGEELEMENT, "org.cip4.jdflib.resource.process.JDFPageElement");
         sm_PackageNames.Add(ElementName.PAGELIST, "org.cip4.jdflib.resource.JDFPageList");
         sm_PackageNames.Add(ElementName.PAGES, "org.cip4.jdflib.span.JDFIntegerSpan");
         sm_PackageNames.Add(ElementName.PAGESRESULTSPOOL, "org.cip4.jdflib.resource.process.prepress.JDFPagesResultsPool");
         sm_PackageNames.Add(ElementName.PAGEVARIANCE, "org.cip4.jdflib.span.JDFIntegerSpan");
         sm_PackageNames.Add(ElementName.PALLET, "org.cip4.jdflib.resource.JDFPallet");
         sm_PackageNames.Add(ElementName.PALLETIZINGPARAMS, "org.cip4.jdflib.resource.JDFPalletizingParams");
         sm_PackageNames.Add(ElementName.PALLETMAXHEIGHT, "org.cip4.jdflib.span.JDFNumberSpan");
         sm_PackageNames.Add(ElementName.PALLETMAXWEIGHT, "org.cip4.jdflib.span.JDFNumberSpan");
         sm_PackageNames.Add(ElementName.PALLETQUANTITY, "org.cip4.jdflib.span.JDFIntegerSpan");
         sm_PackageNames.Add(ElementName.PALLETSIZE, "org.cip4.jdflib.span.JDFXYPairSpan");
         sm_PackageNames.Add(ElementName.PALLETTYPE, "org.cip4.jdflib.span.JDFNameSpan");
         sm_PackageNames.Add(ElementName.PALLETWRAPPING, "org.cip4.jdflib.span.JDFNameSpan");
         sm_PackageNames.Add(ElementName.PART, "org.cip4.jdflib.resource.JDFPart");
         sm_PackageNames.Add(ElementName.PARTAMOUNT, "org.cip4.jdflib.core.JDFPartAmount");
         sm_PackageNames.Add(ElementName.PARTSTATUS, "org.cip4.jdflib.core.JDFPartStatus");
         sm_PackageNames.Add(ElementName.PAYMENT, "org.cip4.jdflib.resource.JDFPayment");
         sm_PackageNames.Add(ElementName.PAYTERM, "org.cip4.jdflib.core.JDFComment");
         sm_PackageNames.Add(ElementName.PDFINTERPRETINGPARAMS, "org.cip4.jdflib.resource.JDFPDFInterpretingParams");
         sm_PackageNames.Add(ElementName.PDFPATHEVALUATION, "org.cip4.jdflib.resource.devicecapability.JDFPDFPathEvaluation");
         sm_PackageNames.Add(ElementName.PDFPATHSTATE, "org.cip4.jdflib.resource.devicecapability.JDFPDFPathState");
         sm_PackageNames.Add(ElementName.PDFTOPSCONVERSIONPARAMS, "org.cip4.jdflib.resource.process.prepress.JDFPDFToPSConversionParams");
         sm_PackageNames.Add(ElementName.PDFXPARAMS, "org.cip4.jdflib.resource.process.JDFPDFXParams");
         sm_PackageNames.Add(ElementName.PDLCREATIONPARAMS, "org.cip4.jdflib.resource.process.JDFPDLCreationParams");
         sm_PackageNames.Add(ElementName.PDLRESOURCEALIAS, "org.cip4.jdflib.resource.process.prepress.JDFPDLResourceAlias");
         sm_PackageNames.Add(ElementName.PERFORATE, "org.cip4.jdflib.resource.process.JDFPerforate");
         sm_PackageNames.Add(ElementName.PERFORATINGPARAMS, "org.cip4.jdflib.resource.JDFPerforatingParams");
         sm_PackageNames.Add(ElementName.PERFORMANCE, "org.cip4.jdflib.resource.JDFPerformance");
         sm_PackageNames.Add(ElementName.PERSON, "org.cip4.jdflib.resource.process.JDFPerson");
         sm_PackageNames.Add(ElementName.PHASETIME, "org.cip4.jdflib.resource.JDFPhaseTime");
         sm_PackageNames.Add(ElementName.PIPEPARAMS, "org.cip4.jdflib.jmf.JDFPipeParams");
         sm_PackageNames.Add(ElementName.PIXELCOLORANT, "org.cip4.jdflib.resource.process.JDFPixelColorant");
         sm_PackageNames.Add(ElementName.PLACEHOLDERRESOURCE, "org.cip4.jdflib.resource.JDFPlaceHolderResource");
         sm_PackageNames.Add(ElementName.PLASTICCOMBBINDING, "org.cip4.jdflib.resource.process.postpress.JDFPlasticCombBinding");
         sm_PackageNames.Add(ElementName.PLASTICCOMBBINDINGPARAMS, "org.cip4.jdflib.resource.process.postpress.JDFPlasticCombBindingParams");
         sm_PackageNames.Add(ElementName.PLASTICCOMBTYPE, "org.cip4.jdflib.span.JDFNameSpan");
         sm_PackageNames.Add(ElementName.PLATECOPYPARAMS, "org.cip4.jdflib.resource.process.JDFPlateCopyParams");
         sm_PackageNames.Add(ElementName.POSITION, "org.cip4.jdflib.resource.process.JDFPosition");
         sm_PackageNames.Add(ElementName.PREFLIGHTACTION, "org.cip4.jdflib.resource.process.JDFPreflightAction");
         sm_PackageNames.Add(ElementName.PREFLIGHTANALYSIS, "org.cip4.jdflib.resource.JDFPreflightAnalysis");
         sm_PackageNames.Add(ElementName.PREFLIGHTARGUMENT, "org.cip4.jdflib.resource.process.JDFPreflightArgument");
         sm_PackageNames.Add(ElementName.PREFLIGHTCONSTRAINT, "org.cip4.jdflib.resource.process.prepress.JDFPreflightConstraint");
         sm_PackageNames.Add(ElementName.PREFLIGHTCONSTRAINTSPOOL, "org.cip4.jdflib.pool.JDFPreflightConstraintsPool");
         sm_PackageNames.Add(ElementName.PREFLIGHTDETAIL, "org.cip4.jdflib.resource.process.prepress.JDFPreflightDetail");
         sm_PackageNames.Add(ElementName.PREFLIGHTINSTANCE, "org.cip4.jdflib.resource.process.prepress.JDFPreflightInstance");
         sm_PackageNames.Add(ElementName.PREFLIGHTINSTANCEDETAIL, "org.cip4.jdflib.resource.process.prepress.JDFPreflightInstanceDetail");
         sm_PackageNames.Add(ElementName.PREFLIGHTINVENTORY, "org.cip4.jdflib.resource.process.prepress.JDFPreflightInventory");
         sm_PackageNames.Add(ElementName.PREFLIGHTPARAMS, "org.cip4.jdflib.resource.process.JDFPreflightParams");
         sm_PackageNames.Add(ElementName.PREFLIGHTPROFILE, "org.cip4.jdflib.resource.process.prepress.JDFPreflightProfile");
         sm_PackageNames.Add(ElementName.PREFLIGHTREPORT, "org.cip4.jdflib.resource.process.JDFPreflightReport");
         sm_PackageNames.Add(ElementName.PREFLIGHTREPORTRULEPOOL, "org.cip4.jdflib.resource.process.JDFPreflightReportRulePool");
         sm_PackageNames.Add(ElementName.PREFLIGHTRESULTSPOOL, "org.cip4.jdflib.pool.JDFPreflightResultsPool");
         sm_PackageNames.Add(ElementName.PRERROR, "org.cip4.jdflib.resource.process.JDFPRError");
         sm_PackageNames.Add(ElementName.PREVIEW, "org.cip4.jdflib.resource.process.JDFPreview");
         sm_PackageNames.Add(ElementName.PREVIEWGENERATIONPARAMS, "org.cip4.jdflib.resource.process.prepress.JDFPreviewGenerationParams");
         sm_PackageNames.Add(ElementName.PRGROUP, "org.cip4.jdflib.resource.process.JDFPRGroup");
         sm_PackageNames.Add(ElementName.PRGROUPOCCURRENCE, "org.cip4.jdflib.resource.process.JDFPRGroupOccurrence");
         sm_PackageNames.Add(ElementName.PRICING, "org.cip4.jdflib.resource.intent.JDFPricing");
         sm_PackageNames.Add(ElementName.PRINTCONDITION, "org.cip4.jdflib.resource.process.press.JDFPrintCondition");
         sm_PackageNames.Add(ElementName.PRINTCONDITIONCOLOR, "org.cip4.jdflib.resource.process.JDFPrintConditionColor");
         sm_PackageNames.Add(ElementName.PRINTPREFERENCE, "org.cip4.jdflib.span.JDFSpanPrintPreference");
         sm_PackageNames.Add(ElementName.PRINTPROCESS, "org.cip4.jdflib.span.JDFSpanPrintProcess");
         sm_PackageNames.Add(ElementName.PRINTROLLINGPARAMS, "org.cip4.jdflib.resource.process.JDFPrintRollingParams");
         sm_PackageNames.Add(ElementName.PRITEM, "org.cip4.jdflib.resource.process.JDFPRItem");
         sm_PackageNames.Add(ElementName.PROCCURRENCE, "org.cip4.jdflib.resource.process.JDFPROccurrence");
         sm_PackageNames.Add(ElementName.PROCESSRUN, "org.cip4.jdflib.resource.JDFProcessRun");
         sm_PackageNames.Add(ElementName.PRODUCTIONINTENT, "org.cip4.jdflib.resource.intent.JDFProductionIntent");
         sm_PackageNames.Add(ElementName.PRODUCTIONPATH, "org.cip4.jdflib.resource.process.JDFProductionPath");
         // ProductionSubPath is a helper class needed by ProductionPath
         sm_PackageNames.Add(ElementName.PRODUCTIONSUBPATH, "org.cip4.jdflib.resource.process.JDFProductionSubPath");
         sm_PackageNames.Add(ElementName.PROOFINGINTENT, "org.cip4.jdflib.resource.intent.JDFProofingIntent");
         sm_PackageNames.Add(ElementName.PROOFINGPARAMS, "org.cip4.jdflib.resource.process.JDFProofingParams");
         sm_PackageNames.Add(ElementName.PROOFITEM, "org.cip4.jdflib.resource.JDFProofItem");
         sm_PackageNames.Add(ElementName.PROOFTYPE, "org.cip4.jdflib.span.JDFSpanProofType");
         sm_PackageNames.Add(ElementName.PRRULE, "org.cip4.jdflib.resource.process.JDFPRRule");
         sm_PackageNames.Add(ElementName.PRRULEATTR, "org.cip4.jdflib.resource.process.JDFPRRuleAttr");
         sm_PackageNames.Add(ElementName.PSTOPDFCONVERSIONPARAMS, "org.cip4.jdflib.resource.process.prepress.JDFPSToPDFConversionParams");
         sm_PackageNames.Add(ElementName.PUBLISHINGINTENT, "org.cip4.jdflib.resource.intent.JDFPublishingIntent");
         sm_PackageNames.Add(ElementName.QUALITYCONTROLPARAMS, "org.cip4.jdflib.resource.process.JDFQualityControlParams");
         sm_PackageNames.Add(ElementName.QUALITYCONTROLRESULT, "org.cip4.jdflib.resource.process.JDFQualityControlResult");
         sm_PackageNames.Add(ElementName.QUALITYMEASUREMENT, "org.cip4.jdflib.resource.process.JDFQualityMeasurement");
         sm_PackageNames.Add(ElementName.QUERY, "org.cip4.jdflib.jmf.JDFQuery");
         sm_PackageNames.Add(ElementName.QUEUE, "org.cip4.jdflib.jmf.JDFQueue");
         sm_PackageNames.Add(ElementName.QUEUEENTRY, "org.cip4.jdflib.jmf.JDFQueueEntry");
         sm_PackageNames.Add(ElementName.QUEUEENTRYDEF, "org.cip4.jdflib.jmf.JDFQueueEntryDef");
         sm_PackageNames.Add(ElementName.QUEUEENTRYDEFLIST, "org.cip4.jdflib.resource.JDFQueueEntryDefList");
         sm_PackageNames.Add(ElementName.QUEUEENTRYPOSPARAMS, "org.cip4.jdflib.jmf.JDFQueueEntryPosParams");
         sm_PackageNames.Add(ElementName.QUEUEENTRYPRIPARAMS, "org.cip4.jdflib.jmf.JDFQueueEntryPriParams");
         sm_PackageNames.Add(ElementName.QUEUEFILTER, "org.cip4.jdflib.jmf.JDFQueueFilter");
         sm_PackageNames.Add(ElementName.QUEUESUBMISSIONPARAMS, "org.cip4.jdflib.jmf.JDFQueueSubmissionParams");
         sm_PackageNames.Add(ElementName.RANGE, "org.cip4.jdflib.core.JDFComment");
         sm_PackageNames.Add(ElementName.RECTANGLEEVALUATION, "org.cip4.jdflib.resource.devicecapability.JDFRectangleEvaluation");
         sm_PackageNames.Add(ElementName.RECTANGLESTATE, "org.cip4.jdflib.resource.devicecapability.JDFRectangleState");
         sm_PackageNames.Add(ElementName.RECYCLED, "org.cip4.jdflib.span.JDFOptionSpan");
         sm_PackageNames.Add(ElementName.REFELEMENT, "org.cip4.jdflib.core.JDFRefElement");
         sm_PackageNames.Add(ElementName.REGISTERMARK, "org.cip4.jdflib.resource.process.JDFRegisterMark");
         sm_PackageNames.Add(ElementName.REGISTERRIBBON, "org.cip4.jdflib.resource.JDFRegisterRibbon");
         sm_PackageNames.Add(ElementName.REGISTRATION, "org.cip4.jdflib.jmf.JDFRegistration");
         sm_PackageNames.Add(ElementName.REMOVED, "org.cip4.jdflib.resource.JDFRemoved");
         sm_PackageNames.Add(ElementName.REMOVELINK, "org.cip4.jdflib.jmf.JDFRemoveLink");
         sm_PackageNames.Add(ElementName.RENDERINGPARAMS, "org.cip4.jdflib.resource.process.prepress.JDFRenderingParams");
         sm_PackageNames.Add(ElementName.REQUESTQUEUEENTRYPARAMS, "org.cip4.jdflib.jmf.JDFRequestQueueEntryParams");
         sm_PackageNames.Add(ElementName.REQUIRED, "org.cip4.jdflib.span.JDFTimeSpan");
         sm_PackageNames.Add(ElementName.RESOURCE, "org.cip4.jdflib.resource.JDFResource");
         sm_PackageNames.Add(ElementName.RESOURCEAUDIT, "org.cip4.jdflib.resource.JDFResourceAudit");
         sm_PackageNames.Add(ElementName.RESOURCECMDPARAMS, "org.cip4.jdflib.jmf.JDFResourceCmdParams");
         sm_PackageNames.Add(ElementName.RESOURCEDEFINITIONPARAMS, "org.cip4.jdflib.resource.process.JDFResourceDefinitionParams");
         sm_PackageNames.Add(ElementName.RESOURCEINFO, "org.cip4.jdflib.jmf.JDFResourceInfo");
         sm_PackageNames.Add(ElementName.RESOURCELINK, "org.cip4.jdflib.core.JDFResourceLink");
         sm_PackageNames.Add(ElementName.RESOURCELINKPOOL, "org.cip4.jdflib.pool.JDFResourceLinkPool");
         sm_PackageNames.Add(ElementName.RESOURCEPARAM, "org.cip4.jdflib.resource.JDFResourceParam");
         sm_PackageNames.Add(ElementName.RESOURCEPOOL, "org.cip4.jdflib.pool.JDFResourcePool");
         sm_PackageNames.Add(ElementName.RESOURCEPULLPARAMS, "org.cip4.jdflib.jmf.JDFResourcePullParams");
         sm_PackageNames.Add(ElementName.RESOURCEQUPARAMS, "org.cip4.jdflib.jmf.JDFResourceQuParams");
         sm_PackageNames.Add(ElementName.RESPONSE, "org.cip4.jdflib.jmf.JDFResponse");
         sm_PackageNames.Add(ElementName.RESUBMISSIONPARAMS, "org.cip4.jdflib.jmf.JDFResubmissionParams");
         sm_PackageNames.Add(ElementName.RETURNMETHOD, "org.cip4.jdflib.span.JDFNameSpan");
         sm_PackageNames.Add(ElementName.RETURNQUEUEENTRYPARAMS, "org.cip4.jdflib.jmf.JDFReturnQueueEntryParams");
         sm_PackageNames.Add(ElementName.RINGBINDING, "org.cip4.jdflib.resource.process.postpress.JDFRingBinding");
         sm_PackageNames.Add(ElementName.RINGBINDINGPARAMS, "org.cip4.jdflib.resource.process.postpress.JDFRingBindingParams");
         sm_PackageNames.Add(ElementName.RINGDIAMETER, "org.cip4.jdflib.span.JDFNumberSpan");
         sm_PackageNames.Add(ElementName.RINGMECHANIC, "org.cip4.jdflib.span.JDFOptionSpan");
         sm_PackageNames.Add(ElementName.RINGSHAPE, "org.cip4.jdflib.span.JDFNameSpan");
         sm_PackageNames.Add(ElementName.RINGSYSTEM, "org.cip4.jdflib.span.JDFNameSpan");
         sm_PackageNames.Add(ElementName.RIVETSEXPOSED, "org.cip4.jdflib.span.JDFOptionSpan");
         sm_PackageNames.Add(ElementName.ROLLSTAND, "org.cip4.jdflib.resource.process.JDFRollStand");
         sm_PackageNames.Add(ElementName.RUNLIST, "org.cip4.jdflib.resource.process.JDFRunList");
         sm_PackageNames.Add(ElementName.SADDLESTITCHING, "org.cip4.jdflib.resource.process.postpress.JDFSaddleStitching");
         sm_PackageNames.Add(ElementName.SADDLESTITCHINGPARAMS, "org.cip4.jdflib.resource.process.postpress.JDFSaddleStitchingParams");
         sm_PackageNames.Add(ElementName.SCANPARAMS, "org.cip4.jdflib.resource.process.prepress.JDFScanParams");
         sm_PackageNames.Add(ElementName.SCAVENGERAREA, "org.cip4.jdflib.resource.JDFScavengerArea");
         sm_PackageNames.Add(ElementName.SCORE, "org.cip4.jdflib.resource.process.postpress.JDFScore");
         sm_PackageNames.Add(ElementName.SCORING, "org.cip4.jdflib.span.JDFSpanScoring");
         sm_PackageNames.Add(ElementName.SCREENINGPARAMS, "org.cip4.jdflib.resource.process.prepress.JDFScreeningParams");
         sm_PackageNames.Add(ElementName.SCREENINGINTENT, "org.cip4.jdflib.resource.intent.JDFScreeningIntent");
         sm_PackageNames.Add(ElementName.SCREENINGTYPE, "org.cip4.jdflib.span.JDFSpanScreeningType");
         sm_PackageNames.Add(ElementName.SCREENSELECTOR, "org.cip4.jdflib.resource.process.JDFScreenSelector");
         sm_PackageNames.Add(ElementName.SEALING, "org.cip4.jdflib.resource.process.JDFSealing");
         sm_PackageNames.Add(ElementName.SEARCHPATH, "org.cip4.jdflib.core.JDFComment");
         sm_PackageNames.Add(ElementName.SEPARATIONCONTROLPARAMS, "org.cip4.jdflib.resource.process.JDFSeparationControlParams");
         sm_PackageNames.Add(ElementName.SEPARATIONLIST, "org.cip4.jdflib.core.JDFSeparationList");
         sm_PackageNames.Add(ElementName.SEPARATIONSPEC, "org.cip4.jdflib.resource.process.JDFSeparationSpec");
         sm_PackageNames.Add(ElementName.SET, "org.cip4.jdflib.resource.devicecapability.JDFset");
         // "Shape" is context sensitive, see handleOtherElements() and
         // putConstructorToHashMap()
         sm_PackageNames.Add(ElementName.SHAPECUT, "org.cip4.jdflib.resource.intent.JDFShapeCut");
         sm_PackageNames.Add(ElementName.SHAPECUTTINGINTENT, "org.cip4.jdflib.resource.intent.JDFShapeCuttingIntent");
         sm_PackageNames.Add(ElementName.SHAPECUTTINGPARAMS, "org.cip4.jdflib.resource.JDFShapeCuttingParams");
         sm_PackageNames.Add(ElementName.SHAPEDEPTH, "org.cip4.jdflib.span.JDFNumberSpan");
         sm_PackageNames.Add(ElementName.SHAPEEVALUATION, "org.cip4.jdflib.resource.devicecapability.JDFShapeEvaluation");
         sm_PackageNames.Add(ElementName.SHAPESTATE, "org.cip4.jdflib.resource.devicecapability.JDFShapeState");
         sm_PackageNames.Add(ElementName.SHAPETYPE, "org.cip4.jdflib.span.JDFSpanShapeType");
         sm_PackageNames.Add(ElementName.SHEET, "org.cip4.jdflib.resource.process.JDFLayout");
         sm_PackageNames.Add(ElementName.SHRINKINGPARAMS, "org.cip4.jdflib.resource.JDFShrinkingParams");
         sm_PackageNames.Add(ElementName.SHUTDOWNCMDPARAMS, "org.cip4.jdflib.jmf.JDFShutDownCmdParams");
         sm_PackageNames.Add(ElementName.SIDESEWING, "org.cip4.jdflib.resource.process.postpress.JDFSideSewing");
         sm_PackageNames.Add(ElementName.SIDESEWINGPARAMS, "org.cip4.jdflib.resource.process.postpress.JDFSideSewingParams");
         sm_PackageNames.Add(ElementName.SIDESTITCHING, "org.cip4.jdflib.resource.process.postpress.JDFSideStitching");
         sm_PackageNames.Add(ElementName.SIGNAL, "org.cip4.jdflib.jmf.JDFSignal");
         sm_PackageNames.Add(ElementName.SIGNATURE, "org.cip4.jdflib.resource.process.JDFLayout");
         sm_PackageNames.Add(ElementName.SIGNATURECELL, "org.cip4.jdflib.resource.process.JDFSignatureCell");
         sm_PackageNames.Add(ElementName.SIZEINTENT, "org.cip4.jdflib.resource.intent.JDFSizeIntent");
         sm_PackageNames.Add(ElementName.SIZEPOLICY, "org.cip4.jdflib.span.JDFSpanSizePolicy");
         sm_PackageNames.Add(ElementName.SOFTCOVERBINDING, "org.cip4.jdflib.resource.JDFSoftCoverBinding");
         sm_PackageNames.Add(ElementName.SOURCERESOURCE, "org.cip4.jdflib.resource.process.JDFSourceResource");
         sm_PackageNames.Add(ElementName.SPAWNED, "org.cip4.jdflib.node.JDFSpawned");
         sm_PackageNames.Add(ElementName.SPINEBRUSHING, "org.cip4.jdflib.span.JDFOptionSpan");
         sm_PackageNames.Add(ElementName.SPINEGLUE, "org.cip4.jdflib.span.JDFSpanGlue");
         sm_PackageNames.Add(ElementName.SPINELEVELLING, "org.cip4.jdflib.span.JDFOptionSpan");
         sm_PackageNames.Add(ElementName.SPINEMILLING, "org.cip4.jdflib.span.JDFOptionSpan");
         sm_PackageNames.Add(ElementName.SPINENOTCHING, "org.cip4.jdflib.span.JDFOptionSpan");
         sm_PackageNames.Add(ElementName.SPINEPREPARATIONPARAMS, "org.cip4.jdflib.resource.JDFSpinePreparationParams");
         sm_PackageNames.Add(ElementName.SPINESANDING, "org.cip4.jdflib.span.JDFOptionSpan");
         sm_PackageNames.Add(ElementName.SPINESHREDDING, "org.cip4.jdflib.span.JDFOptionSpan");
         sm_PackageNames.Add(ElementName.SPINETAPINGPARAMS, "org.cip4.jdflib.resource.JDFSpineTapingParams");
         sm_PackageNames.Add(ElementName.STACKINGPARAMS, "org.cip4.jdflib.resource.JDFStackingParams");
         sm_PackageNames.Add(ElementName.STATION, "org.cip4.jdflib.resource.process.JDFStation");
         sm_PackageNames.Add(ElementName.STATUSPOOL, "org.cip4.jdflib.pool.JDFStatusPool");
         sm_PackageNames.Add(ElementName.STATUSQUPARAMS, "org.cip4.jdflib.jmf.JDFStatusQuParams");
         sm_PackageNames.Add(ElementName.STITCHINGPARAMS, "org.cip4.jdflib.resource.process.postpress.JDFStitchingParams");
         sm_PackageNames.Add(ElementName.STITCHNUMBER, "org.cip4.jdflib.span.JDFIntegerSpan");
         sm_PackageNames.Add(ElementName.STOCKBRAND, "org.cip4.jdflib.span.JDFStringSpan");
         sm_PackageNames.Add(ElementName.STOCKTYPE, "org.cip4.jdflib.span.JDFNameSpan");
         sm_PackageNames.Add(ElementName.STOPPERSCHPARAMS, "org.cip4.jdflib.jmf.JDFStopPersChParams");
         sm_PackageNames.Add(ElementName.STRAP, "org.cip4.jdflib.resource.JDFStrap");
         sm_PackageNames.Add(ElementName.STRAPPINGPARAMS, "org.cip4.jdflib.resource.JDFStrappingParams");
         sm_PackageNames.Add(ElementName.STRINGEVALUATION, "org.cip4.jdflib.resource.devicecapability.JDFStringEvaluation");
         sm_PackageNames.Add(ElementName.STRINGLISTVALUE, "org.cip4.jdflib.resource.process.JDFStringListValue");
         sm_PackageNames.Add(ElementName.STRINGSTATE, "org.cip4.jdflib.resource.devicecapability.JDFStringState");
         sm_PackageNames.Add(ElementName.STRIPBINDING, "org.cip4.jdflib.resource.JDFStripBinding");
         sm_PackageNames.Add(ElementName.STRIPBINDINGPARAMS, "org.cip4.jdflib.resource.process.postpress.JDFStripBindingParams");
         sm_PackageNames.Add(ElementName.STRIPCELLPARAMS, "org.cip4.jdflib.resource.process.JDFStripCellParams");
         sm_PackageNames.Add(ElementName.STRIPMARK, "org.cip4.jdflib.resource.process.JDFStripMark");
         sm_PackageNames.Add(ElementName.STRIPMATERIAL, "org.cip4.jdflib.span.JDFSpanStripMaterial");
         sm_PackageNames.Add(ElementName.STRIPPINGPARAMS, "org.cip4.jdflib.resource.JDFStrippingParams");
         sm_PackageNames.Add(ElementName.SUBMISSIONMETHODS, "org.cip4.jdflib.jmf.JDFSubmissionMethods");
         sm_PackageNames.Add(ElementName.SUBSCRIPTION, "org.cip4.jdflib.jmf.JDFSubscription");
         // "Surface" is context sensitive, see handleOtherElements() and
         // putConstructorToHashMap()
         sm_PackageNames.Add(ElementName.SURPLUSHANDLING, "org.cip4.jdflib.span.JDFSpanSurplusHandling");
         sm_PackageNames.Add(ElementName.SYSTEMTIMESET, "org.cip4.jdflib.resource.JDFSystemTimeSet");
         sm_PackageNames.Add(ElementName.TABBINDMYLAR, "org.cip4.jdflib.span.JDFOptionSpan");
         sm_PackageNames.Add(ElementName.TABBODYCOPY, "org.cip4.jdflib.span.JDFOptionSpan");
         sm_PackageNames.Add(ElementName.TABEXTENSIONDISTANCE, "org.cip4.jdflib.span.JDFNumberSpan");
         sm_PackageNames.Add(ElementName.TABEXTENSIONMYLAR, "org.cip4.jdflib.span.JDFOptionSpan");
         sm_PackageNames.Add(ElementName.TABMYLARCOLOR, "org.cip4.jdflib.span.JDFSpanNamedColor");
         sm_PackageNames.Add(ElementName.TABS, "org.cip4.jdflib.resource.JDFTabs");
         sm_PackageNames.Add(ElementName.TAPE, "org.cip4.jdflib.resource.JDFTape");
         sm_PackageNames.Add(ElementName.TAPEBINDING, "org.cip4.jdflib.span.JDFOptionSpan");
         sm_PackageNames.Add(ElementName.TAPECOLOR, "org.cip4.jdflib.span.JDFSpanNamedColor");
         sm_PackageNames.Add(ElementName.TECHNOLOGY, "org.cip4.jdflib.span.JDFNameSpan");
         sm_PackageNames.Add(ElementName.TEETHPERDIMENSION, "org.cip4.jdflib.span.JDFNumberSpan");
         sm_PackageNames.Add(ElementName.TEMPERATURE, "org.cip4.jdflib.span.JDFSpanTemperature");
         sm_PackageNames.Add(ElementName.TEST, "org.cip4.jdflib.resource.devicecapability.JDFTest");
         sm_PackageNames.Add(ElementName.TESTPOOL, "org.cip4.jdflib.resource.devicecapability.JDFTestPool");
         sm_PackageNames.Add(ElementName.TESTREF, "org.cip4.jdflib.resource.devicecapability.JDFTestRef");
         sm_PackageNames.Add(ElementName.TEXTURE, "org.cip4.jdflib.span.JDFNameSpan");
         sm_PackageNames.Add(ElementName.THICKNESS, "org.cip4.jdflib.span.JDFNumberSpan");
         sm_PackageNames.Add(ElementName.THINPDFPARAMS, "org.cip4.jdflib.resource.process.JDFThinPDFParams");
         sm_PackageNames.Add(ElementName.THREADSEALING, "org.cip4.jdflib.resource.process.postpress.JDFThreadSealing");
         sm_PackageNames.Add(ElementName.THREADSEALINGPARAMS, "org.cip4.jdflib.resource.JDFThreadSealingParams");
         sm_PackageNames.Add(ElementName.THREADSEWING, "org.cip4.jdflib.resource.process.postpress.JDFThreadSewing");
         sm_PackageNames.Add(ElementName.THREADSEWINGPARAMS, "org.cip4.jdflib.resource.process.postpress.JDFThreadSewingParams");
         sm_PackageNames.Add(ElementName.TIFFEMBEDDEDFILE, "org.cip4.jdflib.resource.process.JDFTIFFEmbeddedFile");
         sm_PackageNames.Add(ElementName.TIFFFORMATPARAMS, "org.cip4.jdflib.resource.process.JDFTIFFFormatParams");
         sm_PackageNames.Add(ElementName.TIFFTAG, "org.cip4.jdflib.resource.process.JDFTIFFtag");
         sm_PackageNames.Add(ElementName.TIGHTBACKING, "org.cip4.jdflib.span.JDFSpanTightBacking");
         sm_PackageNames.Add(ElementName.TILE, "org.cip4.jdflib.resource.process.JDFTile");
         sm_PackageNames.Add(ElementName.TOOL, "org.cip4.jdflib.resource.JDFTool");
         sm_PackageNames.Add(ElementName.TRACKFILTER, "org.cip4.jdflib.jmf.JDFTrackFilter");
         sm_PackageNames.Add(ElementName.TRACKRESULT, "org.cip4.jdflib.jmf.JDFTrackResult");
         sm_PackageNames.Add(ElementName.TRANSFER, "org.cip4.jdflib.span.JDFSpanTransfer");
         sm_PackageNames.Add(ElementName.TRANSFERCURVE, "org.cip4.jdflib.resource.process.JDFTransferCurve");
         sm_PackageNames.Add(ElementName.TRANSFERCURVEPOOL, "org.cip4.jdflib.resource.process.JDFTransferCurvePool");
         sm_PackageNames.Add(ElementName.TRANSFERCURVESET, "org.cip4.jdflib.resource.process.JDFTransferCurveSet");
         sm_PackageNames.Add(ElementName.TRANSFERFUNCTIONCONTROL, "org.cip4.jdflib.resource.JDFTransferFunctionControl");
         sm_PackageNames.Add(ElementName.TRAPPINGDETAILS, "org.cip4.jdflib.resource.process.prepress.JDFTrappingDetails");
         sm_PackageNames.Add(ElementName.TRAPPINGORDER, "org.cip4.jdflib.resource.process.prepress.JDFTrappingOrder");
         sm_PackageNames.Add(ElementName.TRAPPINGPARAMS, "org.cip4.jdflib.resource.process.prepress.JDFTrappingParams");
         sm_PackageNames.Add(ElementName.TRAPREGION, "org.cip4.jdflib.resource.process.JDFTrapRegion");
         sm_PackageNames.Add(ElementName.TRIGGER, "org.cip4.jdflib.jmf.JDFTrigger");
         sm_PackageNames.Add(ElementName.TRIMMINGPARAMS, "org.cip4.jdflib.resource.process.postpress.JDFTrimmingParams");

         sm_PackageNames.Add(ElementName.UNDERAGE, "org.cip4.jdflib.span.JDFNumberSpan");
         sm_PackageNames.Add(ElementName.UPDATEJDFCMDPARAMS, "org.cip4.jdflib.jmf.JDFUpdateJDFCmdParams");
         sm_PackageNames.Add(ElementName.USAGECOUNTER, "org.cip4.jdflib.resource.process.JDFUsageCounter");
         sm_PackageNames.Add(ElementName.USWEIGHT, "org.cip4.jdflib.span.JDFNumberSpan");

         sm_PackageNames.Add(ElementName.VALUE, "org.cip4.jdflib.resource.JDFValue");
         sm_PackageNames.Add(ElementName.VALUELOC, "org.cip4.jdflib.resource.devicecapability.JDFValueLoc");
         sm_PackageNames.Add(ElementName.VELOBINDING, "org.cip4.jdflib.resource.process.postpress.JDFVeloBinding");
         sm_PackageNames.Add(ElementName.VERIFICATIONPARAMS, "org.cip4.jdflib.resource.JDFVerificationParams");
         sm_PackageNames.Add(ElementName.VIEWBINDER, "org.cip4.jdflib.span.JDFNameSpan");

         sm_PackageNames.Add(ElementName.WAKEUPCMDPARAMS, "org.cip4.jdflib.jmf.JDFWakeUpCmdParams");
         sm_PackageNames.Add(ElementName.WEBINLINEFINISHINGPARAMS, "org.cip4.jdflib.resource.process.postpress.JDFWebInlineFinishingParams");
         sm_PackageNames.Add(ElementName.WEIGHT, "org.cip4.jdflib.span.JDFNumberSpan");
         sm_PackageNames.Add(ElementName.WHEN, "org.cip4.jdflib.resource.devicecapability.JDFwhen");
         sm_PackageNames.Add(ElementName.WIRECOMBBINDING, "org.cip4.jdflib.resource.process.postpress.JDFWireCombBinding");
         sm_PackageNames.Add(ElementName.WIRECOMBBINDINGPARAMS, "org.cip4.jdflib.resource.process.postpress.JDFWireCombBindingParams");
         sm_PackageNames.Add(ElementName.WIRECOMBMATERIAL, "org.cip4.jdflib.span.JDFSpanWireCombMaterial");
         sm_PackageNames.Add(ElementName.WIRECOMBSHAPE, "org.cip4.jdflib.span.JDFSpanWireCombShape");
         sm_PackageNames.Add(ElementName.WRAPPEDQUANTITY, "org.cip4.jdflib.span.JDFIntegerSpan");
         sm_PackageNames.Add(ElementName.WRAPPINGMATERIAL, "org.cip4.jdflib.span.JDFNameSpan");
         sm_PackageNames.Add(ElementName.WRAPPINGPARAMS, "org.cip4.jdflib.resource.JDFWrappingParams");

         sm_PackageNames.Add(ElementName.XOR, "org.cip4.jdflib.resource.devicecapability.JDFxor");
         sm_PackageNames.Add(ElementName.XPOSITION, "org.cip4.jdflib.span.JDFNumberSpan");
         sm_PackageNames.Add(ElementName.XYPAIREVALUATION, "org.cip4.jdflib.resource.devicecapability.JDFXYPairEvaluation");
         sm_PackageNames.Add(ElementName.XYPAIRSTATE, "org.cip4.jdflib.resource.devicecapability.JDFXYPairState");

         sm_PackageNames.Add(ElementName.YPOSITION, "org.cip4.jdflib.span.JDFNumberSpan");
      }

      ///   
      ///	 <summary> * get/create the associated XMLDocUserData
      ///	 *  </summary>
      ///	 * <returns> the XMLDocUserData of this </returns>
      ///	 
      protected internal virtual XMLDocUserData getXMLDocUserData()
      {
         return (XMLDocUserData)getUserData();
      }

      ///   
      ///	 * <seealso cref= org.apache.xerces.dom.CoreDocumentImpl#removeChild(org.w3c.dom.Node) </seealso>
      ///	 
      public override XmlNode RemoveChild(XmlNode arg0)
      {
         XMLDocUserData ud = getXMLDocUserData();
         if (ud != null)
            ud.clearTargets();

         return base.RemoveChild(arg0);
      }

      ///   
      ///	 * <seealso cref= org.apache.xerces.dom.CoreDocumentImpl#replaceChild(org.w3c.dom.Node, org.w3c.dom.Node) </seealso>
      ///	 
      public override XmlNode ReplaceChild(XmlNode arg0, XmlNode arg1)
      {
         XMLDocUserData ud = getXMLDocUserData();
         if (ud != null)
            ud.clearTargets();
         return base.ReplaceChild(arg0, arg1);
      }

      ///   
      ///	 * <returns> the setIgnoreNSDefault; if true no namespaces are heuristically gathered </returns>
      ///	 
      public virtual bool isIgnoreNSDefault()
      {
         return ignoreNSDefault;
      }

      ///   
      ///	 <summary> * if true no namespaces are heuristically gathered
      ///	 *  </summary>
      ///	 * <param name="_setIgnoreNSDefault"> the setIgnoreNSDefault to set </param>
      ///	 
      public virtual void setIgnoreNSDefault(bool _setIgnoreNSDefault)
      {
         this.ignoreNSDefault = _setIgnoreNSDefault;
      }


      private XMLDocUserData m_UserData = null;

      public IEnumerator getIdentifiers()
      {
         throw new NotImplementedException();
      }

      public XMLDocUserData getUserData()
      {
         return m_UserData;
      }

      public void setUserData(XMLDocUserData userData)
      {
         m_UserData = userData;
      }


      private bool m_ErrorChecking;

      public bool getErrorChecking()
      {
         return m_ErrorChecking;
      }

      public void setErrorChecking(bool errorChecking)
      {
         m_ErrorChecking = errorChecking;
      }


      private Dictionary<string, XmlElement> m_Identifiers = new Dictionary<string, XmlElement>();

      public virtual void putIdentifier(string idName, XmlElement element)
      {
         m_Identifiers[idName] = element;
      }

      public virtual XmlElement getIdentifier(string idName)
      {
         XmlElement ret;
         m_Identifiers.TryGetValue(idName, out ret);
         return ret;
      }

      public virtual void removeIdentifier(string idName)
      {
         m_Identifiers.Remove(idName);
      }


      public virtual SupportClass.TraversalIteratorSupport createNodeIterator(XmlNode root, int whatToShow, SupportClass.FilterXml filter, bool entityReferenceExpansion)
      {
         return SupportClass.TraversalIteratorSupport.CreateTraversalIterator(root, whatToShow, filter);
      }

      public virtual SupportClass.TraversalIteratorSupport createTreeWalker(XmlNode root, int whatToShow, SupportClass.FilterXml filter, bool entityReferenceExpansion)
      {
         return SupportClass.TraversalIteratorSupport.CreateTraversalIterator(root, whatToShow, filter);
      }


      public virtual XmlNotation createNotation(string name)
      {
         return (XmlNotation)CreateNode(XmlNodeType.Notation, name, NamespaceURI);
      }


      public virtual XmlElement createElementDefinition(string name)
      {
         return CreateElement(name);
      }
   }
}
