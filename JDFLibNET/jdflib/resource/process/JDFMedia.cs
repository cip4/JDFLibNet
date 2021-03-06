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
 * JDFMedia
 *
 * Last changes
 *
 * 2002-07-02 JG added ValidMediaType() to correctly handle explicit Unknown enumeration
 * 2002-07-02 JG de-inlined copy constructor
 */


namespace org.cip4.jdflib.resource.process
{


   using JDFAutoMedia = org.cip4.jdflib.auto.JDFAutoMedia;
   using AttributeName = org.cip4.jdflib.core.AttributeName;
   using VElement = org.cip4.jdflib.core.VElement;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;

   public class JDFMedia : JDFAutoMedia
   {
      private new const long serialVersionUID = 1L;

      ///   
      ///	 <summary> * Constructor for JDFMedia
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFMedia(CoreDocumentImpl myOwnerDocument, string qualifiedName)
         : base(myOwnerDocument, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFMedia
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 
      public JDFMedia(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName)
      {
      }

      ///   
      ///	 <summary> * Constructor for JDFMedia
      ///	 *  </summary>
      ///	 * <param name="ownerDocument"> </param>
      ///	 * <param name="namespaceURI"> </param>
      ///	 * <param name="qualifiedName"> </param>
      ///	 * <param name="localName"> </param>
      ///	 
      public JDFMedia(CoreDocumentImpl myOwnerDocument, string myNamespaceURI, string qualifiedName, string myLocalName)
         : base(myOwnerDocument, myNamespaceURI, qualifiedName, myLocalName)
      {
      }

      public override string ToString()
      {
         return "JDFMedia[  --> " + base.ToString() + " ]";
      }

      ///   
      ///	 <summary> * calculates paper thickness from weight, if and only if weight exists but
      ///	 * not thickness
      ///	 *  </summary>
      ///	 * <param name="bLocal">
      ///	 *            if true, only evaluate locally set attributes in this
      ///	 *            partition, else check inherited attributes </param>
      ///	 * <param name="bRecurse">
      ///	 *            if true, do for all children, grandchildren rtc, else only
      ///	 *            local </param>
      ///	 
      public virtual void setThicknessFromWeight(bool bLocal, bool bRecurse)
      {
         EnumMediaType mT = getMediaType();
         if (!EnumMediaType.Paper.Equals(mT))
            return; // only useful for paper
         if (bRecurse)
         {
            VElement v = getLeaves(true);
            int size = v.Count;
            for (int i = 0; i < size; i++)
               ((JDFMedia)v[i]).setThicknessFromWeight(bLocal, false);
         }
         else
         {
            string w = bLocal ? getAttribute_KElement(AttributeName.WEIGHT) : getAttribute(AttributeName.WEIGHT);
            if (isWildCard(w))
               return; // no weight to use
            string t = bLocal ? getAttribute_KElement(AttributeName.THICKNESS) : getAttribute(AttributeName.THICKNESS);
            if (!isWildCard(t))
               return; // no weight to use
            setThickness(getWeight() * 1.25); // assume average density of 0.8
            // g/cm^3
            // TODO improve calculation based on grade etc.
         }
      }

      ///   
      ///	 <summary> * Set attribute Dimension (in point)
      ///	 *  </summary>
      ///	 * <param name="JDFXYPair">
      ///	 *            value: the value (in centimeter) to set the dimension to </param>
      ///	 
      public virtual void setDimensionCM(JDFXYPair @value)
      {
         JDFXYPair xyp = new JDFXYPair(@value); // don't change the original
         xyp.scale(72.0 / 2.54);
         setDimension(xyp);
      }

      ///   
      ///	 <summary> * Get attribute Dimension in centimeter
      ///	 *  </summary>
      ///	 * <returns> JDFXYPair the dimension in centimeter </returns>
      ///	 
      public virtual JDFXYPair getDimensionCM()
      {
         JDFXYPair xyp = getDimension();
         xyp.scale(2.54 / 72.0);
         return xyp;
      }

      ///   
      ///	 <summary> * Set attribute Dimension (in point)
      ///	 *  </summary>
      ///	 * <param name="JDFXYPair">
      ///	 *            value: the value (in inch) to set the dimension to </param>
      ///	 
      public virtual void setDimensionInch(JDFXYPair @value)
      {
         JDFXYPair xyp = new JDFXYPair(@value); // don't change the original
         xyp.scale(72.0);
         setDimension(xyp);
      }

      ///   
      ///	 <summary> * Get attribute Dimension in inch
      ///	 *  </summary>
      ///	 * <returns> JDFXYPair the dimension in inch </returns>
      ///	 
      public virtual JDFXYPair getDimensionInch()
      {
         JDFXYPair xyp = getDimension();
         xyp.scale(1.0 / 72.0);
         return xyp;
      }
   }
}
