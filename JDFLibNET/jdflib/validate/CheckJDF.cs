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
 * Titel:        check a jdf file, if is valid
 * Version:
 * Copyright:    Copyright (c) 2002
 * Autor:        Joerg Gonnermann, Dietrich Mucha
 * Firma:        Heidelberger Druckmaschinen AG
 */ 
 
namespace org.cip4.jdflib
{
   using System;
   using System.IO;
   using System.Windows.Forms;

   using JDFConstants = org.cip4.jdflib.core.JDFConstants;
   using JDFElement = org.cip4.jdflib.core.JDFElement;
   using JDFVersions = org.cip4.jdflib.core.JDFVersions;
   using KElement = org.cip4.jdflib.core.KElement;
   using VString = org.cip4.jdflib.core.VString;
   using XMLDoc = org.cip4.jdflib.core.XMLDoc;
   using EnumVersion = org.cip4.jdflib.core.JDFElement.EnumVersion;
   using EnumValidationLevel = org.cip4.jdflib.core.KElement.EnumValidationLevel;
   using EnumFitsValue = org.cip4.jdflib.datatypes.EnumFitsValue;
   using MyArgs = org.cip4.jdflib.util.MyArgs;
   using StringUtil = org.cip4.jdflib.util.StringUtil;
   using UrlUtil = org.cip4.jdflib.util.UrlUtil;
   using JDFValidator = org.cip4.jdflib.validate.JDFValidator;

   ///
   /// <summary> * Refactored JDFValidator to be non-static in order to make it thread
   /// * compatible. Previously, only one thread at a time could call JDFValidator
   /// * from within the same JVM. Now an instance of JDFValidator and the the method
   /// * validate should be called. JDFValidator can still be called from the command
   /// * line in the same way as before.
   /// * 
   /// * TODO Break out validation error handling logging so that new error handlers
   /// * can easily be registered. For example, there should be an error handler for
   /// * logging to the XML log file and an error handler for logging to the
   /// * <code>sysOut</code>. Perhaps <code>org.xml.sax.ErrorHandler</code> could be
   /// * used?
   /// * 
   /// * @author Claes Buckwalter (clabu@itn.liu.se)
   /// * @version 2008-01-02 </summary>
   /// 
   public class CheckJDF : JDFValidator
   {

      private const string usage = "\n******************************************************************************************\n" + 
         "Usage: <input JDF files>\n" + 
         "-V(ersion) -q(uiet) -c(omplete) -n(amespace) -v(alidate) -t(ime)\n" + 
         "-u(RL)<URL> -h(ost) -p(ort) -l(ocation)<schemaLocation> -L(ocation)<schemaLocation>\n" + 
         "-d(eviceCapabilities)<input JDM file>  -P(resentValueLists) \n\n" + 
         "-? usage info\n" + "-q is quiet for valid files\n" + 
         "-Q is completely quiet for all files\n" + 
         "-n will report all elements from foreign name spaces\n" + 
         "-c requires all required elements and attributes to exist, else incomplete JDF is OK\n" + 
         "-d location of a device capabilities file to test against\n" + 
         "-f force version to a given jdf version (1.0, 1.1, 1.2, 1.3)\n" + 
         "-m print multiple IDs\n" + 
         "-P device capabilities parameter. Use present value lists, otherwise allowed value lists\n" + 
         "-u URL to send the JMF to. In this case, checkJDF will validate the response from the URL\n" + 
         "-U check for dangling URL attributes\n" + 
         "-h proxy host name\n" + 
         "-p proxy port name\n" + 
         "-v validate using XML Schema validation;\n" + 
         "the Schema can be defined in the xsi:schemaLocation tag in the JDF or using the -l or -L switch\n" + 
         "-V Always print a version stamp, even in quiet mode (-q)\n" + 
         "-L location of the schema for the Namespace \"http://www.CIP4.org/JDFSchema_1_1\"\n" + 
         "Note that blanks ' ' are invalid in the file names\n" + 
         "-l location of additional private schema for validation in the same format as xsi:schemaLocation\n   " + 
         "except that multiple schema and schema/namespace pairs are separated by commas ',' not blanks ' '\n   " + 
         "The JDF schema specified in the -L switch should not be included in this list\n" + 
         "-t print out Timing information\n" + 
         "-T Translation language for the xslt output\n" + 
         "-w print out Warnings (deprecated etc.)\n" + 
         "-x output filename that contains an xml formatted error report\n" + 
         "-X XSL stylesheet to apply to the xml formatted error report as specified in -x\n";

      public CheckJDF()
         : base()
      {
         pOut.getRoot().setAttribute("Version", version);
      }

      ///    
      ///	 <summary> * main Schema validation + internal checkJDF Test + Test against
      ///	 * DeviceCapability File (if specified)
      ///	 *  </summary>
      ///	 * <param name="argv"> </param>
      ///	 
      public static void Main(string[] argv)
      {
         // job.jdf -n -c -v or
         // job.jdf -n -c -v -q if only invalid elements are of interest
         CheckJDF checker = new CheckJDF();
         checker.validate(argv, null);
      }

      ///    
      ///	 <summary> * Validates the JDF instance or JMF message specified by the command line
      ///	 * arguments. See the source code below for a description of what arguments
      ///	 * are valid.
      ///	 *  </summary>
      ///	 * <param name="commandLineArgs">
      ///	 *            command line arguments </param>
      ///	 
      public virtual XMLDoc validate(string[] commandLineArgs, Stream inStream)
      {
         string url = parseArgs(commandLineArgs);
         // for all files do
         if (inStream != null || url != null)
         {
            return processSingleURLStream(inStream, url);
         }
         return processAllFiles();
      }

      private string parseArgs(string[] commandLineArgs)
      {
         MyArgs args = new MyArgs(commandLineArgs, "?cmqPQvVntwU", "dlfLuhpTxX", null);

         if (args.boolParameter('?', false))
         {
            sysOut.println("JDFValidator:\n" + version + '\n' + usage);
            Application.Exit();
            
         }
         bWarning = args.boolParameter('w', false);
         bTiming = args.boolParameter('t', false);
         bQuiet = args.boolParameter('q', false);
         bWarnDanglingURL = args.boolParameter('U', false);

         this.setPrint(!args.boolParameter('Q', false));
         xmlOutputName = args.parameterString('x');
         xslStyleSheet = args.parameterString('X');
         getTranslation(args);
         pOut = new XMLDoc("CheckOutput", null);
         KElement xmlRoot = pOut.getRoot();
         xmlRoot.setAttribute("Language", "EN");

         bool bVersion = !bQuiet || args.boolParameter('V', false);
         if (bVersion)
         {
            sysOut.println('\n' + version + '\n');
            sysOut.println(args.ToString());
            xmlRoot.setAttribute("Arguments", StringUtil.setvString(commandLineArgs, " ", null, null));
         }

         bPrintNameSpace = args.boolParameter('n', false);
         bMultiID = args.boolParameter('m', false);

         if (args.hasParameter('h'))
         {
            proxyHost = args.parameterString('h');
            proxyPort = args.parameterString('p');
         }

         if (args.hasParameter('c'))
         {
            if (args.boolParameter('c', false))
            {
               level = EnumValidationLevel.Complete;
            }
            else
            {
               level = EnumValidationLevel.Incomplete;
            }
         }

         string parameterString = args.parameterString('L');
         if (parameterString != null)
         {
            setJDFSchemaLocation(new FileInfo(parameterString));
         }

         string schemaLocation0 = args.parameterString('l');

         // convert "," to blank
         if (schemaLocation0 != null)
         {
            VString vs = new VString(schemaLocation0, JDFConstants.COMMA);
            if (vs.Count % 2 != 0)
            {
               sysOut.println("error in schema location: format is \"NameSpaceURI1,Location1,NameSpaceURI2,Location2\"\n - bailing out!" + usage);
               Application.Exit();
            }
            schemaLocation0 = StringUtil.setvString(vs, JDFConstants.BLANK, JDFConstants.EMPTYSTRING, JDFConstants.EMPTYSTRING);
            schemaLocation += schemaLocation0;
         }

         if (args.hasParameter('d'))
         {
            devCapFile = args.parameterString('d');
            FileInfo fDC = UrlUtil.urlToFile(devCapFile);
            if (fDC == null || !fDC.Exists)
            {
               sysOut.println("Error reading devcap file: " + devCapFile + "\n - bailing out!\n" + usage);
               Application.Exit();
            }
         }

         bValidate = (args.boolParameter('v', false)) || (schemaLocation != null);
         string jdfVersion = args.parameterString('f');
         if (jdfVersion != null)
         {
            EnumVersion v = EnumVersion.getEnum(jdfVersion);
            JDFElement.setDefaultJDFVersion(v);
            JDFVersions.ForceVersion = true;
         }

         if (args.nargs() == 0)
         {
            sysOut.println(args.usage(usage));
            Application.Exit();
         }

         testlists = EnumFitsValue.Allowed;
         if (args.boolParameter('P', false))
         {
            testlists = EnumFitsValue.Present;
         }

         string url = args.parameterString('u');

         setAllFiles(args);
         return url;
      }

      private void getTranslation(MyArgs args)
      {
         translation = args.parameterString('T');
         if (translation != null)
         {
            translation = translation.ToUpper();
            if (translation.Length > 2)
            {
               translation = translation.Substring(0, 2);
            }
         }
      }
   }
}