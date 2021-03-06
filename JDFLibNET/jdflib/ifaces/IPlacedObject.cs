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


namespace org.cip4.jdflib.ifaces
{

   using JDFMatrix = org.cip4.jdflib.datatypes.JDFMatrix;
   using JDFRectangle = org.cip4.jdflib.datatypes.JDFRectangle;
   using JDFXYPair = org.cip4.jdflib.datatypes.JDFXYPair;

   ///
   /// <summary> * common Interface for ContentObjects and MarkObjects
   /// * 
   /// * @author prosirai
   /// *  </summary>
   /// 
   public interface IPlacedObject
   {

      //   
      //	 * --------------------------------------------------------------------- Methods for Attribute SourceClipPath
      //	 * ---------------------------------------------------------------------
      //	 
      ///   
      ///	 <summary> * (36) set attribute SourceClipPath
      ///	 *  </summary>
      ///	 * <param name="value"> : the value to set the attribute to </param>
      ///	 
      void setSourceClipPath(string value);

      ///   
      ///	 <summary> * (23) get String attribute SourceClipPath
      ///	 *  </summary>
      ///	 * <returns> the value of the attribute </returns>
      ///	 
      string getSourceClipPath();

      //   
      //	 * --------------------------------------------------------------------- Methods for Attribute LayerID
      //	 * ---------------------------------------------------------------------
      //	 
      ///   
      ///	 <summary> * (36) set attribute LayerID
      ///	 *  </summary>
      ///	 * <param name="value"> : the value to set the attribute to </param>
      ///	 
      void setLayerID(int value);

      ///   
      ///	 <summary> * (15) get int attribute LayerID
      ///	 *  </summary>
      ///	 * <returns> int the value of the attribute </returns>
      ///	 
      int getLayerID();

      //   
      //	 * --------------------------------------------------------------------- Methods for Attribute CTM
      //	 * ---------------------------------------------------------------------
      //	 
      ///   
      ///	 <summary> * (36) set attribute CTM
      ///	 *  </summary>
      ///	 * <param name="value"> : the value to set the attribute to </param>
      ///	 
      void setCTM(JDFMatrix value);

      ///   
      ///	 <summary> * (20) get JDFMatrix attribute CTM
      ///	 *  </summary>
      ///	 * <returns> JDFMatrixthe value of the attribute, null if a the attribute value is not a valid to create a JDFMatrix </returns>
      ///	 
      JDFMatrix getCTM();

      //   
      //	 * --------------------------------------------------------------------- Methods for Attribute Ord
      //	 * ---------------------------------------------------------------------
      //	 
      ///   
      ///	 <summary> * (36) set attribute Ord
      ///	 *  </summary>
      ///	 * <param name="value"> : the value to set the attribute to </param>
      ///	 
      void setOrd(int value);

      ///   
      ///	 <summary> * (15) get int attribute Ord
      ///	 *  </summary>
      ///	 * <returns> int the value of the attribute </returns>
      ///	 
      int getOrd();

      //   
      //	 * --------------------------------------------------------------------- Methods for Attribute HalfTonePhaseOrigin
      //	 * ---------------------------------------------------------------------
      //	 
      ///   
      ///	 <summary> * (36) set attribute HalfTonePhaseOrigin
      ///	 *  </summary>
      ///	 * <param name="value"> : the value to set the attribute to </param>
      ///	 
      void setHalfTonePhaseOrigin(JDFXYPair value);

      ///   
      ///	 <summary> * (20) get JDFXYPair attribute HalfTonePhaseOrigin
      ///	 *  </summary>
      ///	 * <returns> JDFXYPairthe value of the attribute, null if a the attribute value is not a valid to create a JDFXYPair </returns>
      ///	 
      JDFXYPair getHalfTonePhaseOrigin();

      //   
      //	 * --------------------------------------------------------------------- Methods for Attribute OrdID
      //	 * ---------------------------------------------------------------------
      //	 
      ///   
      ///	 <summary> * (36) set attribute OrdID
      ///	 *  </summary>
      ///	 * <param name="value"> : the value to set the attribute to </param>
      ///	 
      void setOrdID(int value);

      ///   
      ///	 <summary> * (15) get int attribute OrdID
      ///	 *  </summary>
      ///	 * <returns> int the value of the attribute </returns>
      ///	 
      int getOrdID();

      //   
      //	 * --------------------------------------------------------------------- Methods for Attribute TrimCTM
      //	 * ---------------------------------------------------------------------
      //	 
      ///   
      ///	 <summary> * (36) set attribute TrimCTM
      ///	 *  </summary>
      ///	 * <param name="value"> : the value to set the attribute to </param>
      ///	 
      void setTrimCTM(JDFMatrix value);

      ///   
      ///	 <summary> * convenience method to set TrimSize
      ///	 *  </summary>
      ///	 * <param name="xy"> : the value to set TrimSize to </param>
      ///	 
      void setTrimSize(JDFXYPair xy);

      ///   
      ///	 <summary> * convenience method to set TrimSize
      ///	 *  </summary>
      ///	 * <param name="x"> : the value to set the x Dimension to </param>
      ///	 * <param name="x"> : the value to set the y Dimension to </param>
      ///	 
      void setTrimSize(double x, double y);

      ///   
      ///	 <summary> * (20) get JDFMatrix attribute TrimCTM
      ///	 *  </summary>
      ///	 * <returns> JDFMatrixthe value of the attribute, null if a the attribute value is not a valid to create a JDFMatrix </returns>
      ///	 
      JDFMatrix getTrimCTM();

      //   
      //	 * --------------------------------------------------------------------- Methods for Attribute ClipBox
      //	 * ---------------------------------------------------------------------
      //	 
      ///   
      ///	 <summary> * (36) set attribute ClipBox
      ///	 *  </summary>
      ///	 * <param name="value"> : the value to set the attribute to </param>
      ///	 
      void setClipBox(JDFRectangle value);

      ///   
      ///	 <summary> * (20) get JDFRectangle attribute ClipBox
      ///	 *  </summary>
      ///	 * <returns> JDFRectanglethe value of the attribute, null if a the attribute value is not a valid to create a
      ///	 *         JDFRectangle </returns>
      ///	 
      JDFRectangle getClipBox();

      //   
      //	 * --------------------------------------------------------------------- Methods for Attribute ClipPath
      //	 * ---------------------------------------------------------------------
      //	 
      ///   
      ///	 <summary> * (36) set attribute ClipPath
      ///	 *  </summary>
      ///	 * <param name="value"> : the value to set the attribute to </param>
      ///	 
      void setClipPath(string value);

      ///   
      ///	 <summary> * (23) get String attribute ClipPath
      ///	 *  </summary>
      ///	 * <returns> the value of the attribute </returns>
      ///	 
      string getClipPath();
   }
}
