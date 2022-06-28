using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Drawing;
using Miracle.RtfDocumentBuilder.Core;

namespace Miracle.RtfDocumentBuilder
{
    /// <summary>
    /// In Rtf document header, it has font header list, color header list.
    /// 1. Font Header is defined by each paragraph or text line.
    ///     Such as : {\fonttbl [font family]*}
    ///     [font family] : {\f[N]\fnil\fcharset0 [font family name];}
    ///     [font family name] : Calibri, Microsoft Sans Serif, Tahoma
    ///     ------------
    ///     [N] = Seqeunce number is start with 0 to N
    /// 2. Color Header is defined by each paragraph.
    ///     Such as : {\colortbl ;[color code]* }
    ///     [color code] : \red255\green0\blue0;
    /// </summary>
    public class RTFDocumentBase
    {
        /// <summary>
        /// Struct use to define font header properties
        /// </summary>
        public struct FontHeaderStruct
        {
            public string FontFamily { get; set; }
            public CharSetName CharsetName { get; set; }
        }
        // Dictionary is use to mapping font family name and sequence number 
        // for each name
        private static HybridDictionary fontFamilyhybridDictionary;
        // Dictionary is use to mapping color and sequence number
        private static HybridDictionary colorHybridDictionary;
        // Dictionary is use to mapping between font enum and font name text
        private static HybridDictionary fontFamilyNameMappingHybridDictionary;
        // Dictionary is use to mapping between color enum and color rtf text format
        private static HybridDictionary colorNameMappingHybridDictionary;
        // Font famliy name list use to keep font name
        private static List<FontHeaderStruct> fontFamilyNameList;
        // Color name list use to keep color name
        private static List<RtfColor> colorNameList;
        // A font sequency number use in mapping font family name 
        private static uint fontSequencyNumber = 0;
        // A Color sequency number use in mapping color name
        private static uint colorSequencyNumber = 0;
        //start of header
        private const string PREFIX = @"{";
        //header for knowning font
        private const string PREFIX_FONT_HEADER = @"\fonttbl";
        //header for color
        private const string PREFIX_COLOR_HEADER = @"\colortbl ;";
        //end of header
        private const string POSTFIX = @"}";

        /// <summary>
        /// Get rtf color header
        /// </summary>
        public string ColorHeader { get { return this.BuildColorHeaderString(); } }
        /// <summary>
        /// Get rtf font header
        /// </summary>
        public string FontHeader { get { return this.BuildFontHeaderString(); } }
        /// <summary>
        /// Get number of font in font header
        /// </summary>
        public int FontCount { get { return fontFamilyhybridDictionary.Count; } }

        /// <summary>
        /// Get number of color in color header
        /// </summary>
        public int ColorCount { get { return colorHybridDictionary.Count; } }

        /// <summary>
        /// Constructor use to create constant
        /// </summary>
        public RTFDocumentBase()
        {
            //font family
            if(fontFamilyhybridDictionary == null)
                fontFamilyhybridDictionary = new HybridDictionary(false); // create dictionary with no case sensitive
            //color
            if (colorHybridDictionary == null)
                colorHybridDictionary = new HybridDictionary(false); //create color dictionary with no case sensitive

            if (fontFamilyNameList == null)
                fontFamilyNameList = new List<FontHeaderStruct>(); //create temp font family name

            if (colorNameList == null)
                colorNameList = new List<RtfColor>();//create temp color name

            if (fontFamilyNameMappingHybridDictionary == null)
            {
                //Add Font Mapping
                fontFamilyNameMappingHybridDictionary = new HybridDictionary(false);
                fontFamilyNameMappingHybridDictionary.Add(FontFamilys.Calibri, new FontHeaderStruct() { FontFamily = FontFamilysDef.Calibri, CharsetName = CharSetName.ANSI_CHARSET });
                fontFamilyNameMappingHybridDictionary.Add(FontFamilys.Century, new FontHeaderStruct() { FontFamily = FontFamilysDef.Century, CharsetName = CharSetName.ANSI_CHARSET });
                fontFamilyNameMappingHybridDictionary.Add(FontFamilys.CordiaNew, new FontHeaderStruct() { FontFamily = FontFamilysDef.CordiaNew, CharsetName = CharSetName.ANSI_CHARSET });
                fontFamilyNameMappingHybridDictionary.Add(FontFamilys.CordiaUPC, new FontHeaderStruct() { FontFamily = FontFamilysDef.CordiaUPC, CharsetName = CharSetName.ANSI_CHARSET });
                fontFamilyNameMappingHybridDictionary.Add(FontFamilys.MicrosoftSansSerif, new FontHeaderStruct() { FontFamily = FontFamilysDef.MicrosoftSansSerif, CharsetName = CharSetName.ANSI_CHARSET });
                fontFamilyNameMappingHybridDictionary.Add(FontFamilys.Roman, new FontHeaderStruct() { FontFamily = FontFamilysDef.Roman, CharsetName = CharSetName.ANSI_CHARSET });
                fontFamilyNameMappingHybridDictionary.Add(FontFamilys.Script, new FontHeaderStruct() { FontFamily = FontFamilysDef.Script, CharsetName = CharSetName.ANSI_CHARSET });
                fontFamilyNameMappingHybridDictionary.Add(FontFamilys.Symbol, new FontHeaderStruct() { FontFamily = FontFamilysDef.Symbol, CharsetName = CharSetName.ANSI_CHARSET });
                fontFamilyNameMappingHybridDictionary.Add(FontFamilys.Tahoma, new FontHeaderStruct() { FontFamily = FontFamilysDef.Tahoma, CharsetName = CharSetName.ANSI_CHARSET });
                fontFamilyNameMappingHybridDictionary.Add(FontFamilys.TimesNewRoman, new FontHeaderStruct() { FontFamily = FontFamilysDef.TimesNewRoman, CharsetName = CharSetName.ANSI_CHARSET });
                fontFamilyNameMappingHybridDictionary.Add(FontFamilys.Verdana, new FontHeaderStruct() { FontFamily = FontFamilysDef.Verdana, CharsetName = CharSetName.ANSI_CHARSET });
                fontFamilyNameMappingHybridDictionary.Add(FontFamilys.MalgunGothic, new FontHeaderStruct() { FontFamily = FontFamilysDef.MalgunGothic, CharsetName = CharSetName.HANGUL_CHARSET });
                fontFamilyNameMappingHybridDictionary.Add(FontFamilys.MSMincho, new FontHeaderStruct() { FontFamily = FontFamilysDef.MSMincho, CharsetName = CharSetName.GB2312_CHARSET });
            
            }

            if (colorNameMappingHybridDictionary == null)
            {
                //Add Color Mapping
                colorNameMappingHybridDictionary = new HybridDictionary();
                colorNameMappingHybridDictionary.Add(RtfColor.Aqua, RTFColorsDef.Aqua);
                colorNameMappingHybridDictionary.Add(RtfColor.Black, RTFColorsDef.Black);
                colorNameMappingHybridDictionary.Add(RtfColor.Blue, RTFColorsDef.Blue);
                colorNameMappingHybridDictionary.Add(RtfColor.Fuchsia, RTFColorsDef.Fuchsia);
                colorNameMappingHybridDictionary.Add(RtfColor.Gray, RTFColorsDef.Gray);
                colorNameMappingHybridDictionary.Add(RtfColor.Green, RTFColorsDef.Green);
                colorNameMappingHybridDictionary.Add(RtfColor.Lime, RTFColorsDef.Lime);
                colorNameMappingHybridDictionary.Add(RtfColor.Maroon, RTFColorsDef.Maroon);
                colorNameMappingHybridDictionary.Add(RtfColor.Navy, RTFColorsDef.Navy);
                colorNameMappingHybridDictionary.Add(RtfColor.Olive, RTFColorsDef.Olive);
                colorNameMappingHybridDictionary.Add(RtfColor.Purple, RTFColorsDef.Purple);
                colorNameMappingHybridDictionary.Add(RtfColor.Red, RTFColorsDef.Red);
                colorNameMappingHybridDictionary.Add(RtfColor.Silver, RTFColorsDef.Silver);
                colorNameMappingHybridDictionary.Add(RtfColor.Teal, RTFColorsDef.Teal);
                colorNameMappingHybridDictionary.Add(RtfColor.White, RTFColorsDef.White);
                colorNameMappingHybridDictionary.Add(RtfColor.Yellow, RTFColorsDef.Yellow);
            }
        }
        /// <summary>
        /// This method use to add font family to font header.
        /// the font family should in window system.
        /// </summary>
        /// <param name="_fontFamily">font family collection</param>
        /// <returns>Sequence number of this font family</returns>
        internal int AddFontHeader(FontFamilys _fontfamily)
        {
            FontHeaderStruct _tmpff = ((FontHeaderStruct)fontFamilyNameMappingHybridDictionary[_fontfamily]);
            int index = 0;
            //Check font family is exits
            foreach (FontHeaderStruct fontFamily in fontFamilyhybridDictionary.Values)
            {
                if (fontFamily.FontFamily == _tmpff.FontFamily)
                    return index;
                index++;
            }
            // add new font family
            fontFamilyhybridDictionary.Add(fontSequencyNumber, fontFamilyNameMappingHybridDictionary[_fontfamily]); // add font family to dictionary
            fontFamilyNameList.Add((FontHeaderStruct)fontFamilyNameMappingHybridDictionary[_fontfamily]); //add to temp list
            
            return (int)fontSequencyNumber++; // return sequence number
        }

        /// <summary>
        /// This method use to add color to color header
        /// the color should in know color name.
        /// </summary>
        /// <param name="_rtfColor">color collection</param>
        /// <returns>Sequence number of color</returns>
        internal int AddColorHeader(RtfColor _rtfColor)
        {
            if (!colorHybridDictionary.Contains(_rtfColor))
            {
                colorHybridDictionary.Add(_rtfColor, colorSequencyNumber); // add color to dictionary
                colorNameList.Add(_rtfColor); //add to temp list
                return (int)colorSequencyNumber++; //return sequence number
            }
            else
                return Convert.ToInt32(colorHybridDictionary[_rtfColor]); // return sequence number
        }

        /// <summary>
        /// This method use to build/create string header of font family.
        /// It use to global class structured.
        /// </summary>
        /// <returns>string font header</returns>
        private string BuildFontHeaderString()
        {
            //Create string builder
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append(PREFIX);
            strBuilder.Append(PREFIX_FONT_HEADER);
            foreach (FontHeaderStruct font in fontFamilyNameList)
            {

                string _fontSeqId = "0";
                int i = 0;
                foreach (FontHeaderStruct fhs in fontFamilyhybridDictionary.Values)
                {
                    if (fhs.FontFamily == font.FontFamily 
                        && fhs.CharsetName == font.CharsetName)
                    {
                        _fontSeqId = "" + i;
                        break;
                    }
                    i++;
                }
                strBuilder.Append(@"{\f");
                strBuilder.Append(_fontSeqId);
                strBuilder.Append(@"\fnil\fcharset");
                strBuilder.Append(CharSetTable.GetCharset(font.CharsetName).CharsetDecValue);
                strBuilder.Append(@" ");
                strBuilder.Append(font.FontFamily);
                strBuilder.Append(@";}");
            }
            strBuilder.Append(POSTFIX);

            return strBuilder.ToString();
        }

        /// <summary>
        /// this method use to generate rtf color header
        /// </summary>
        /// <returns>string color header</returns>
        private string BuildColorHeaderString()
        {
            //Create string bulider
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append(PREFIX);
            strBuilder.Append(PREFIX_COLOR_HEADER);
            foreach (RtfColor color in colorNameList)
            {
                if (color == RtfColor.None)
                    continue;
                strBuilder.Append(colorNameMappingHybridDictionary[color].ToString());
                strBuilder.Append(";");
            }
            strBuilder.Append(POSTFIX);

            return strBuilder.ToString();
        }

        #region Update Charset
        /// <summary>
        /// this method use to set font with charset 
        /// when charset is not in default, need to add
        /// new one for spacify charset
        /// </summary>
        /// <param name="fontfamily">font family</param>
        /// <param name="charset">charset</param>
        /// <returns>font header id</returns>
        public static int UpdateCharSet(FontFamilys fontfamily, CharSet charset)
        {
            //check exits
            FontHeaderStruct _tmpff = ((FontHeaderStruct)fontFamilyNameMappingHybridDictionary[fontfamily]);
            int index = 0;
            foreach (FontHeaderStruct font in fontFamilyhybridDictionary.Values)
            {
                if (font.FontFamily == _tmpff.FontFamily
                    && font.CharsetName == charset.CharSetName)
                    return index;
            }
            // Get support font family for supported text
            FontFamilys _newfontFamily = SpecificallyFontTable.GetFontFamily(charset.CharSetName);
            // automatic font family
            if (_newfontFamily != FontFamilys.None)
            {
                FontHeaderStruct _tmpff2 = ((FontHeaderStruct)fontFamilyNameMappingHybridDictionary[_newfontFamily]);
                _tmpff = new FontHeaderStruct() { FontFamily = _tmpff2.FontFamily, CharsetName = charset.CharSetName };
            }
            else
                _tmpff = new FontHeaderStruct() { FontFamily = _tmpff.FontFamily, CharsetName = charset.CharSetName };

            fontFamilyhybridDictionary[fontSequencyNumber] = _tmpff;
            fontFamilyNameList.Add(_tmpff); //add to temp list

            return (int)fontSequencyNumber++;
        }
        #endregion
    }
}
