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
 * JDFActionPool.cs
 *
 * Last changes
 */

namespace org.cip4.jdflib.resource.devicecapability
{


   using JDFAutoActionPool = org.cip4.jdflib.auto.JDFAutoActionPool;
   using ElementName = org.cip4.jdflib.core.ElementName;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using ICapabilityElement = org.cip4.jdflib.ifaces.ICapabilityElement;
   using IDeviceCapable = org.cip4.jdflib.ifaces.IDeviceCapable;
   using EnumTerm = org.cip4.jdflib.resource.devicecapability.JDFTerm.EnumTerm;


   public class JDFActionPool : JDFAutoActionPool
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFActionPool
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFActionPool(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFActionPool
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>

      ///	 
      public JDFActionPool(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFActionPool
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="localName"> </param>

      ///	 
      public JDFActionPool(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
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
         return "JDFActionPool[  --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> *  </summary>
      ///	 * <returns> the deviceCap or MessageService that <this> resides in </returns>
      ///	 
      public virtual IDeviceCapable getDeviceCap()
      {
         return (IDeviceCapable)getParentNode_KElement();
      }

      ///   
      ///	 <summary> * append an action to this that references a Test with a term of type term
      ///	 * in the parallel TestPool
      ///	 *  </summary>
      ///	 * <param name="term">
      ///	 *            the type of term in the test </param>
      ///	 * <param name="bActionFailsOnTestTrue">
      ///	 *            if true the term is linked directly, if false a the term is
      ///	 *            inverted by enclosing it in a <not> term </param>
      ///	 
      public virtual JDFAction appendActionTest(EnumTerm term, bool bActionFailsOnTestTrue)
      {
         JDFAction action = appendAction();
         JDFTestPool testPool = (JDFTestPool)getParentNode_KElement().getCreateElement(ElementName.TESTPOOL);
         JDFTest test = null;
         if (bActionFailsOnTestTrue)
         {
            test = testPool.appendTestTerm(term);
         }
         else
         {
            test = testPool.appendTest();
            ((JDFnot)test.appendTerm(EnumTerm.not)).appendTerm(term);
         }
         action.setTest(test);
         return action;
      }

      ///   
      ///	 <summary> * append an action to this that references a Test with a term of type term
      ///	 * in the parallel TestPool
      ///	 *  </summary>
      ///	 * <param name="term">
      ///	 *            the type of term in the test </param>
      ///	 * <param name="setTerm">
      ///	 *            the term referenced by PreflightAction@SetRef </param>
      ///	 * <param name="bActionFailsOnTestTrue">
      ///	 *            if true the term is linked directly, if false a the term is
      ///	 *            inverted by enclosing it in a <not> term note that the setTest
      ///	 *            always MUST be true to evaluate.
      ///	 *  </param>
      ///	 * <returns> the newly created action </returns>
      ///	 
      public virtual JDFAction appendActionSetTest(EnumTerm term, EnumTerm setTerm, bool bActionFailsOnTestTrue)
      {
         JDFAction action = appendActionTest(term, bActionFailsOnTestTrue);
         JDFTestPool testPool = (JDFTestPool)getParentNode_KElement().getCreateElement(ElementName.TESTPOOL);
         JDFTest setTest = testPool.appendTestTerm(setTerm);
         action.setPreflightActionSetRef(setTest);
         return action;
      }

      ///   
      ///	 <summary> * append an action to this that references a Test that defines an exclusion
      ///	 * of two values
      ///	 *  </summary>
      ///	 * <param name="id1">
      ///	 *            the id of the first state or devcap to reference </param>
      ///	 * <param name="id2">
      ///	 *            the id of the 2nd state or devcap to reference
      ///	 *  </param>
      ///	 * <returns> the newly created action </returns>
      ///	 
      public virtual JDFAction appendExcludeTest(ICapabilityElement t1, ICapabilityElement t2)
      {
         if (t1 == null || t2 == null)
            return null; // snafu - cant find elements to match

         string id1 = ((JDFElement)t1).appendAnchor(null);
         string id2 = ((JDFElement)t2).appendAnchor(null);

         JDFAction action = appendActionTest(EnumTerm.and, true); // fail if a &&
         // b
         JDFand and = (JDFand)action.getTestTerm();

         JDFEvaluation ev1 = (JDFEvaluation)and.appendTerm(t1.getEvaluationType());
         ev1.setrRef(id1);
         JDFEvaluation ev2 = (JDFEvaluation)and.appendTerm(t2.getEvaluationType());
         ev2.setrRef(id2);

         return action;
      }
   }
}
