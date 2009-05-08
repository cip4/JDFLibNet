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


namespace org.cip4.jdflib.elementwalker
{
   using System.Collections.Generic;


   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using JDFRefElement = org.cip4.jdflib.core.JDFRefElement;
   using JDFResourceLink = org.cip4.jdflib.core.JDFResourceLink;
   using KElement = org.cip4.jdflib.core.KElement;
   using VElement = org.cip4.jdflib.core.VElement;
   using JDFNode = org.cip4.jdflib.node.JDFNode;
   using JDFResource = org.cip4.jdflib.resource.JDFResource;
   using ContainerUtil = org.cip4.jdflib.util.ContainerUtil;

   ///
   /// <summary> * @author prosirai finds unlinked resources - example usage of the walker classes </summary>
   /// 
   public class UnLinkFinder : BaseElementWalker
   {
      ///   
      ///	 * <param name="_theFactory"> </param>
      ///	 * <param name="_callBack"> </param>
      ///	 
      protected internal LinkData ld;

      public UnLinkFinder()
         : base(new BaseWalkerFactory())
      {
         ld = new LinkData();
      }

      ///   
      ///	 <summary> * get a vector of all unlinked resources of n and its children
      ///	 *  </summary>
      ///	 * <param name="n"> the node to walk
      ///	 * @return </param>
      ///	 
      public virtual VElement getUnlinkedResources(JDFNode n)
      {
         ld.clear();
         walk(n);
         List<KElement> toValueVector = ContainerUtil.toValueVector(ld.resMap, false);
         return toValueVector == null ? null : new VElement(VElement.ToVElement<KElement>(toValueVector));
      }

      ///   
      ///	 <summary> * erase all unlinked resources that are in n
      ///	 *  </summary>
      ///	 * <param name="n"> the node to clean </param>
      ///	 
      public virtual void eraseUnlinkedResources(JDFNode n)
      {
         VElement v = getUnlinkedResources(n);
         if (v != null)
         {
            int siz = v.Count;
            for (int i = 0; i < siz; i++)
               v[i].deleteNode();

            if (siz > 0)
               eraseUnlinkedResources(n);
         }
      }

      protected internal override BaseWalkerFactory getFactory()
      {
         return (BaseWalkerFactory)theFactory;
      }

      ///   
      ///	 <summary> * collection of maps
      ///	 * 
      ///	 * @author prosirai
      ///	 *  </summary>
      ///	 
      protected internal class LinkData
      {
         internal Dictionary<string, KElement> resMap = new Dictionary<string, KElement>();
         internal SupportClass.HashSetSupport<string> refSet = new SupportClass.HashSetSupport<string>();
         internal SupportClass.HashSetSupport<string> doneSet = new SupportClass.HashSetSupport<string>();

         protected internal virtual void clear()
         {
            resMap.Clear();
            refSet.Clear();
            doneSet.Clear();
         }
      }

      ///   
      ///	 <summary> * the resource walker note the naming convention Walkxxx so that it is automagically instantiated by the super
      ///	 * classes
      ///	 * 
      ///	 * @author prosirai
      ///	 *  </summary>
      ///	 
      public class WalkRes : BaseWalker
      {
         private UnLinkFinder EnclosingInstance = null;

         ///      
         ///		 <summary> * fills this into the factory </summary>
         ///		 
         public WalkRes(UnLinkFinder enclosingInstance)
            : base(enclosingInstance.getFactory())
         {
            EnclosingInstance = enclosingInstance;
         }

         public override bool walk(KElement e)
         {
            JDFResource r = (JDFResource)e;
            string id = r.getID();
            if (EnclosingInstance.ld.doneSet.Contains(id))
               return true;
            if (EnclosingInstance.ld.refSet.Contains(id))
            {
               EnclosingInstance.ld.doneSet.Add(id);
               EnclosingInstance.ld.refSet.Remove(id);
               return true;
            }
            EnclosingInstance.ld.resMap.Add(id, r);
            return true;
         }

         public override bool matches(KElement toCheck)
         {
            bool b = base.matches(toCheck);
            if (!b)
               return false;
            return (toCheck is JDFResource) && ((JDFResource)toCheck).isResourceRoot();
         }
      }

      ///   
      ///	 <summary> * the link and ref walker
      ///	 * 
      ///	 * @author prosirai
      ///	 *  </summary>
      ///	 
      public class WalkRef : BaseWalker
      {
         private UnLinkFinder EnclosingInstance = null;

         ///      
         ///		 <summary> * fills this into the factory </summary>
         ///		 
         public WalkRef(UnLinkFinder enclosingInstance)
            : base(enclosingInstance.getFactory())
         {
            EnclosingInstance = enclosingInstance;
         }

         public override bool walk(KElement e)
         {
            string id = e.getAttribute(AttributeName.RREF, null, null);
            if (id == null)
               return true;
            if (EnclosingInstance.ld.doneSet.Contains(id))
               return true;

            if (EnclosingInstance.ld.resMap.ContainsKey(id))
            {
               EnclosingInstance.ld.doneSet.Add(id);
               EnclosingInstance.ld.resMap.Remove(id);
               return true;
            }
            EnclosingInstance.ld.refSet.Add(id);
            return true;
         }

         public override bool matches(KElement toCheck)
         {
            bool b = base.matches(toCheck);
            if (!b)
               return false;
            return (toCheck is JDFResourceLink) || (toCheck is JDFRefElement);
         }

      }
   }
}
