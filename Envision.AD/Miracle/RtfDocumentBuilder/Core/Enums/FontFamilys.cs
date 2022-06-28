using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.RtfDocumentBuilder.Core
{
    /// <summary>
    /// Definedation for font family name
    /// </summary>
    public struct FontFamilysDef
    {
        public const string Tahoma = "Tahoma";
        public const string MicrosoftSansSerif = "Microsoft Sans Serif"; //Many user use this font (envision)
        public const string Calibri = "Calibri";
        public const string TimesNewRoman = "Times New Roman";
        public const string Century = "Century";
        public const string Symbol = "Symbol";
        public const string Verdana = "Verdana";
        public const string CordiaNew = "Cordia New";
        public const string CordiaUPC = "CordiaUPC";
        public const string Script = "Script";
        public const string Roman = "Roman";
        public const string MSMincho = "MS Mincho";
        public const string MalgunGothic = "Malgun Gothic";
        // add more font here
    }
    /// <summary>
    /// Font family enum, you can add more font with out our list.
    /// before add new font family, you must make sure spelling of font name
    /// and should be support in window. Default should be tahoma because
    /// all computer can support. In envision program, many user used microsoft sans serif.
    /// </summary>
    public enum FontFamilys
    {
        None, //no font
        Tahoma, 
        MicrosoftSansSerif, 
        Calibri, 
        TimesNewRoman, 
        Century, 
        Symbol, 
        Verdana, 
        CordiaNew, 
        CordiaUPC, 
        Script, 
        Roman,
        /// <summary>
        ///  default japan font
        /// </summary>

        MSMincho,
        /// <summary>
        /// default korean font
        /// </summary>
        MalgunGothic
    }
}
