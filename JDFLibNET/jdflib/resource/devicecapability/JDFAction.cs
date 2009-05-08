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
 * JDFAction.cs
 *
 * Last changes
 */

namespace org.cip4.jdflib.resource.devicecapability
{


   using JDFAutoAction = org.cip4.jdflib.auto.JDFAutoAction;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using KElement = org.cip4.jdflib.core.KElement;
   using JDFPreflightAction = org.cip4.jdflib.resource.process.JDFPreflightAction;


   public class JDFAction : JDFAutoAction
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFAction
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFAction(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFAction
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFAction(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFAction
      ///	 *  </summary>
      ///	 * <param name="myOwnerDocument"> </param>
      ///	 * <param name="myNamespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="myLocalName"> </param>

      ///	 
      public JDFAction(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
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
         return "JDFAction[  --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * get the Test element in the TestPool that is referenced by this action
      ///	 *  </summary>
      ///	 * <returns> JDFTest: the referenced test, null if none exists </returns>
      ///	 
      public virtual JDFTest getTest()
      {
         JDFTestPool testPool = getTestPool();
         if (testPool == null)
            return null;
         return testPool.getTest(getTestRef());
      }

      ///   
      ///	 <summary> * get the testPool that all IDRefs in this action refer to
      ///	 *  </summary>
      ///	 * <returns> JDFTestPool: the neighboring TestPool </returns>
      ///	 
      public virtual JDFTestPool getTestPool()
      {
         KElement commonParent = getActionPool().getParentNode_KElement();
         if (commonParent == null)
            return null;

         JDFTestPool testPool = (JDFTestPool)commonParent.getElement(ElementName.TESTPOOL);
         return testPool;
      }

      ///   
      ///	 <summary> * get the root Term of the Test element in the TestPool that is referenced
      ///	 * by this action
      ///	 *  </summary>
      ///	 * <returns> JDFTerm: the referenced term, null if none exists </returns>
      ///	 
      public virtual JDFTerm getTestTerm()
      {
         JDFTest test = getTest();
         if (test == null)
            return null;
         return test.getTerm(null, 0);
      }

      ///   
      ///	 <summary> * get the action pool <code>this</code> resides in
      ///	 *  </summary>
      ///	 * <returns> JDFActionPool - the actionpool </returns>
      ///	 
      public virtual JDFActionPool getActionPool()
      {
         return (JDFActionPool)getParentNode_KElement();
      }

      ///   
      ///	 <summary> * init()
      ///	 *  </summary>
      ///	 * <seealso cref= org.cip4.jdflib.core.KElement#init() </seealso>
      ///	 
      public override bool init()
      {
         appendAnchor(null);
         return base.init();
      }

      ///   
      ///	 <summary> * getIDPrefix
      ///	 *  </summary>
      ///	 * <returns> String: the default ID prefix of non-overwritten JDF elements </returns>
      ///	 
      public override string getIDPrefix()
      {
         return "A";
      }

      ///   
      ///	 <summary> * set testRef to the value of test/@ID
      ///	 *  </summary>
      ///	 * <param name="test">
      ///	 *            the value to set testRef to </param>
      ///	 
      public virtual void setTest(JDFTest test)
      {
         test.appendAnchor(null); // just in case it is missing
         string id2 = test.getID();
         setTestRef(id2);
      }

      ///   
      ///	 <summary> * set PreflightAction/@SetRef to the value of test/@ID
      ///	 *  </summary>
      ///	 * <param name="test">
      ///	 *            the test to use </param>
      ///	 
      public virtual void setPreflightActionSetRef(JDFTest test)
      {
         test.appendAnchor(null); // just in case it is missing
         string id2 = test.getID();
         getCreatePreflightAction(0).setSetRef(id2);
      }

      ///   
      ///	 <summary> * get the test defined by PreflightAction/@SetRef
      ///	 *  </summary>
      ///	 * <returns> JDFTest: the test to use </returns>
      ///	 
      public virtual JDFTest getPreflightActionSetRef()
      {
         JDFPreflightAction pfa = getPreflightAction(0);
         if (pfa == null)
            return null;
         string setRef = pfa.getSetRef();
         JDFTestPool testPool = getTestPool();
         if (testPool == null)
            return null;
         return testPool.getTest(setRef);
      }

      ///   
      ///	 <summary> * get the term defined by PreflightAction/@SetRef
      ///	 *  </summary>
      ///	 * <returns> JDFTerm: the term to use </returns>
      ///	 
      public virtual JDFTerm getPreflightActionSetTerm()
      {
         JDFTest test = getPreflightActionSetRef();
         if (test == null)
            return null;
         return test.getTerm();
      }
   }
}
