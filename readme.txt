RELEASE NOTES:

   08-May-2009

 - This is the source code for a Microsoft .NET compatible version of the JDF Library written in C#.
 
 - The code was translated from the 1.3 version, build 52 of the JDF Java code library.
  
 - It was compiled using Visual Studio 2005 and the .NET 2.0 Framework
 
 - To use this code requires Visual Studio 2005 and the .NET 2.0 Framework installed on your PC.

 - After importing the files to your PC, double click on the JDFLibNET.sln file to open the solution in Visual Studio, then build the solution.  The result should be a JDFLib.NET.DLL file suitable for use in .NET applications.
 
 - Some get and set methods have been converted to C# properties, but not nearly all.  The ideal solution would be to implement properties throughout the library and leave the get and set methods, but mark them as obsolete.  Unfortunately I did not have the time to do that yet.
 
 - There are some parts of the conversion that are not implemented, or implemented crudely.  A search for the string "Java to C# Conversion" should point them out.
 
 - I would classify the current state of the code as pre-beta.  Assume it will not work perfectly.
 
 - For any comments, questions, complaints, bug fixes, or offers of help contact:

   Mark Sebald  Email: mdsebald@hotmail.com

Thank You.