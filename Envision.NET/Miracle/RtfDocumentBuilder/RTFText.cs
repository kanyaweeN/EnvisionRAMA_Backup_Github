using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Miracle.RtfDocumentBuilder.Core;

namespace Miracle.RtfDocumentBuilder
{
    /// <summary>
    /// The Rtf Text class use to create text in rtf format
    /// that format is follow by rtf text format as
    /// '{\Font[N]}{\Color[N]}{\Style} text {\Font0}{\Color0}{Style0}' format
    /// Font[N]         - Font with id as \f0, \f1 from font header define
    /// Color[N]        - Color with id as \cl0, \cl1, \hightlight1 from color header define
    /// Style           - such as \b, \i, \ul
    /// </summary>
    public class RTFText : RTFBase
    {
        #region Declare Const Parameters
        // Define font header
        private const string FONT_FAMILY_HEADER = @"\f";
        // Define font size header
        private const string FONT_SIZE_HEADER = @"\fs";
        // Define font color header
        private const string FONT_COLOR_HEADER = @"\cf";
        // Define font back color header
        private const string FONT_BACK_COLOR_HEADER = @"\highlight";
        // Define start font bold style
        private const string FS_BOLD_S = @"\b";
        // Define end font bold style
        private const string FS_BOLD_E = @"\b0";
        // Define start font italic style
        private const string FS_ITALIC_S = @"\i";
        // Define end font italic style
        private const string FS_ITALIC_E = @"\i0";
        // Define start font underline style
        private const string FS_UNDERLINE_S = @"\ul";
        // Define end font underline style
        private const string FS_UNDERLINE_E = @"\ul0";
        // Define start font double under line style
        private const string FS_DBUNDERLINE_S = @"\uldb";
        // Define end font double under line style
        private const string FS_DBUNDERLINE_E = @"\ul0";
        // Define start font strike style
        private const string FS_STRIKE_S = @"\strike";
        // Define end font strike style
        private const string FS_STRIKE_E = @"\strike0";
        // Define tab 
        private const string FS_TAB = @"\tab";

        #endregion

        #region Parser Method
        /// <summary>
        /// Static Method use to get rtf text with default font
        /// </summary>
        /// <param name="text">plan text</param>
        /// <returns>rtf text format</returns>
        public static string ParseToRtf(string plainText) { return BulidRTFText(plainText, new RTFFont(), 0, 0); }
        /// <summary>
        /// Static Method use to get rtf text with custom font
        /// </summary>
        /// <param name="plainText">plain text</param>
        /// <param name="font">custom font</param>
        /// <returns>rtf text format</returns>
        public static string ParseToRtf(string plainText, RTFFont font) { return BulidRTFText(plainText, font, 0, 0); }

        /// <summary>
        /// Static method use to get rtf text with font style
        /// </summary>
        /// <param name="plainText">plain text</param>
        /// <param name="fontStyle">font style</param>
        /// <returns>rtf text format</returns>
        public static string ParseToRtf(string plainText, FontStyles fontStyle) { return BulidRTFText(plainText, new RTFFont(fontStyle), 0, 0); }
        /// <summary>
        /// Static method use to get rtf text with font style
        /// </summary>
        /// <param name="plainText">plain text</param>
        /// <param name="fontStyle">font style</param>
        /// <returns>rtf text format</returns>
        public static string ParseToRtf(string plainText, FontStyles fontStyle, int numberOfTabBeforeText, int numberOfTabAfterText) { return BulidRTFText(plainText, new RTFFont(fontStyle), numberOfTabBeforeText, numberOfTabAfterText); }
        
        #endregion

        #region Private Method
        /// <summary>
        /// This method use to create rtf text with rtf format
        /// and that format is follow by 
        /// fontStyle|fontfamily|fontsize|fontColor|fontbackgroundColor
        /// </summary>
        /// <param name="_trimText">Plain text</param>
        /// <param name="_font">Font Setup</param>
        /// <returns>rtf text format</returns>
        private static string BulidRTFText(string trimText, RTFFont font, int numberOfTabBeforeText, int numberOfTabAfterText)
        {
            // Verdify charset of font, if text is not default(english) such as 
            // thai, korean, japan, etc you need to set specify charset
            // ------------------------- 
            // THAI_CHARSET         Code page id : 200
            // How to changed
            // 1. Change charset from 0(default) to 200
            // 2. Encoding original string to hex 
            trimText = VerifyWordFontFace.VerifyFromText(trimText, font);
            // Build RTF Text
            StringBuilder rtfStrBuilder = new StringBuilder(trimText);
            string _startFont = RTFText.FONT_FAMILY_HEADER + font.FontFamilyId; //open font syntax
            string _endFont = RTFText.FONT_FAMILY_HEADER + "0"; //end font syntax to default
            string _startFontSize = RTFText.FONT_SIZE_HEADER + (font.FontSize * 2); //open font size syntax
            string _endFontSize = RTFText.FONT_SIZE_HEADER + "20"; //end font size syntax to default
            string _startFontColor = string.Empty;
            string _endFontColor = string.Empty;
            string _startFontBackColor = string.Empty;
            string _endFontBackColor = string.Empty;
            string _startFontStyle = string.Empty;
            string _endFontStyle = string.Empty;
            //Get Font color
            if (font.FontColor != RtfColor.Black)
            {
                _startFontColor = RTFText.FONT_COLOR_HEADER + font.FontColorId; //open font color syntax
                _endFontColor = RTFText.FONT_COLOR_HEADER + "0"; //end font color syntax to default
            }
            //Get Font back color
            if (font.FontBackgroundColor != RtfColor.None)
            {
                _startFontBackColor = RTFText.FONT_BACK_COLOR_HEADER + font.FontBackgroundColorId; //open font back color syntax
                _endFontBackColor = RTFText.FONT_BACK_COLOR_HEADER + "0"; //end font back color syntax to default
            }
            //Get font style
            BuildFontStyle(ref _startFontStyle, ref _endFontStyle, font.FontStyle);
            //Set Font
            //Insert white space frist
            rtfStrBuilder.Insert(0, WHITE_SPACE);
            //insert font family
            rtfStrBuilder.Insert(0, _startFont);//insert first
            rtfStrBuilder.Insert(rtfStrBuilder.Length, _endFont);//insert last
            //inset font size
            rtfStrBuilder.Insert(0, _startFontSize);//insert first
            rtfStrBuilder.Insert(rtfStrBuilder.Length, _endFontSize);//inset last
            //insert font color
            if (!string.IsNullOrEmpty(_startFontColor))
            {
                rtfStrBuilder.Insert(0, _startFontColor); //insert first
                rtfStrBuilder.Insert(rtfStrBuilder.Length, _endFontColor); //insert last
            }
            //insert font background color
            if (!string.IsNullOrEmpty(_startFontBackColor))
            {
                rtfStrBuilder.Insert(0, _startFontBackColor); //insert first
                rtfStrBuilder.Insert(rtfStrBuilder.Length, _endFontBackColor); //inset last
            }
            //insert font style
            if (!string.IsNullOrEmpty(_startFontStyle))
            {
                rtfStrBuilder.Insert(0, _startFontStyle); //insert first
                rtfStrBuilder.Insert(rtfStrBuilder.Length, _endFontStyle); //insert last
            }
            //insert tab before text
            if (numberOfTabBeforeText != 0)
            {
                for (int i = 0; i < numberOfTabBeforeText; i++)
                    rtfStrBuilder.Insert(0, RTFText.FS_TAB);
            }
            //insert tab after text
            if (numberOfTabAfterText != 0)
            {
                for (int i = 0; i < numberOfTabAfterText; i++)
                    rtfStrBuilder.Insert(rtfStrBuilder.Length, RTFText.FS_TAB);
            }
            return rtfStrBuilder.ToString();
        }
        

        /// <summary>
        /// This method use to set font style
        /// </summary>
        /// <param name="_startFontStyle">start syntax font style</param>
        /// <param name="_endFontStyle">end syntax font style</param>
        /// <param name="fontStyles">font style collection</param>
        private static void BuildFontStyle(ref string _startFontStyle, ref string _endFontStyle, FontStyles fontStyles)
        {
            switch (fontStyles)
            {
                case FontStyles.None: return;
                case FontStyles.Bold:
                    _startFontStyle = RTFText.FS_BOLD_S;
                    _endFontStyle = RTFText.FS_BOLD_E; break;
                case FontStyles.BoldAndDoubleUnderLine:
                    _startFontStyle = RTFText.FS_BOLD_S + RTFText.FS_DBUNDERLINE_S;
                    _endFontStyle = RTFText.FS_BOLD_E + RTFText.FS_DBUNDERLINE_E; break;
                case FontStyles.BoldAndDoublieUnderLineAndStrike:
                    _startFontStyle = RTFText.FS_BOLD_S + RTFText.FS_DBUNDERLINE_S + RTFText.FS_STRIKE_S;
                    _endFontStyle = RTFText.FS_BOLD_E + RTFText.FS_DBUNDERLINE_E + RTFText.FS_STRIKE_E; break;
                case FontStyles.BoldAndItalic:
                    _startFontStyle = RTFText.FS_BOLD_S + RTFText.FS_ITALIC_S;
                    _endFontStyle = RTFText.FS_BOLD_E + RTFText.FS_ITALIC_E; break;
                case FontStyles.BoldAndItalicAndDoubleUnderLine:
                    _startFontStyle = RTFText.FS_BOLD_S + RTFText.FS_ITALIC_S + RTFText.FS_DBUNDERLINE_S;
                    _endFontStyle = RTFText.FS_BOLD_E + RTFText.FS_ITALIC_E + RTFText.FS_DBUNDERLINE_E; break;
                case FontStyles.BoldAndItalicAndDoubleUnderLineAndStrike:
                    _startFontStyle = RTFText.FS_BOLD_S + RTFText.FS_ITALIC_S + RTFText.FS_DBUNDERLINE_S + RTFText.FS_STRIKE_S;
                    _endFontStyle = RTFText.FS_BOLD_E + RTFText.FS_ITALIC_E + RTFText.FS_DBUNDERLINE_E + RTFText.FS_STRIKE_E; break;
                case FontStyles.BoldAndItalicAndStrike:
                    _startFontStyle = RTFText.FS_BOLD_S + RTFText.FS_ITALIC_S + RTFText.FS_STRIKE_S;
                    _endFontStyle = RTFText.FS_BOLD_E + RTFText.FS_ITALIC_E + RTFText.FS_STRIKE_E; break;
                case FontStyles.BoldAndItalicAndUnderLine:
                    _startFontStyle = RTFText.FS_BOLD_S + RTFText.FS_ITALIC_S + RTFText.FS_UNDERLINE_S;
                    _endFontStyle = RTFText.FS_BOLD_E + RTFText.FS_ITALIC_E + RTFText.FS_UNDERLINE_E; break;
                case FontStyles.BoldAndItalicAndUnderLineAndStrike:
                    _startFontStyle = RTFText.FS_BOLD_S + RTFText.FS_ITALIC_S + RTFText.FS_UNDERLINE_S + RTFText.FS_STRIKE_S;
                    _endFontStyle = RTFText.FS_BOLD_E + RTFText.FS_ITALIC_E + RTFText.FS_UNDERLINE_E + RTFText.FS_STRIKE_E; break;
                case FontStyles.BoldAndStrike:
                    _startFontStyle = RTFText.FS_BOLD_S + RTFText.FS_STRIKE_S;
                    _endFontStyle = RTFText.FS_BOLD_E + RTFText.FS_STRIKE_E; break;
                case FontStyles.BoldAndUnderLine:
                    _startFontStyle = RTFText.FS_BOLD_S + RTFText.FS_UNDERLINE_S;
                    _endFontStyle = RTFText.FS_BOLD_E + RTFText.FS_UNDERLINE_E; break;
                case FontStyles.BoldAndUnderLineAndStrike:
                    _startFontStyle = RTFText.FS_BOLD_S + RTFText.FS_UNDERLINE_S + RTFText.FS_STRIKE_S;
                    _endFontStyle = RTFText.FS_BOLD_E + RTFText.FS_UNDERLINE_E + RTFText.FS_STRIKE_E; break;
                case FontStyles.DoubleUnderLine:
                    _startFontStyle = RTFText.FS_DBUNDERLINE_S;
                    _endFontStyle = RTFText.FS_DBUNDERLINE_E; break;
                case FontStyles.DoubleUnderLineAndStrike:
                    _startFontStyle = RTFText.FS_DBUNDERLINE_S + RTFText.FS_STRIKE_S;
                    _endFontStyle = RTFText.FS_DBUNDERLINE_E + RTFText.FS_STRIKE_E; break;
                case FontStyles.Italic:
                    _startFontStyle = RTFText.FS_ITALIC_S;
                    _endFontStyle = RTFText.FS_ITALIC_E; break;
                case FontStyles.ItalicAndDoubleUnderLine:
                    _startFontStyle = RTFText.FS_ITALIC_S + RTFText.FS_DBUNDERLINE_S;
                    _endFontStyle = RTFText.FS_ITALIC_E + RTFText.FS_DBUNDERLINE_E; break;
                case FontStyles.ItalicAndDoubleUnderLineAndStrike:
                    _startFontStyle = RTFText.FS_ITALIC_S + RTFText.FS_DBUNDERLINE_S + RTFText.FS_STRIKE_S;
                    _endFontStyle = RTFText.FS_ITALIC_E + RTFText.FS_DBUNDERLINE_E + RTFText.FS_STRIKE_E; break;
                case FontStyles.ItalicAndStrike:
                    _startFontStyle = RTFText.FS_ITALIC_S + RTFText.FS_STRIKE_S;
                    _endFontStyle = RTFText.FS_ITALIC_E + RTFText.FS_STRIKE_E; break;
                case FontStyles.ItalicAndUnderLine:
                    _startFontStyle = RTFText.FS_ITALIC_S + RTFText.FS_UNDERLINE_S;
                    _endFontStyle = RTFText.FS_ITALIC_E + RTFText.FS_UNDERLINE_E; break;
                case FontStyles.ItalicAndUnderLineAndStrike:
                    _startFontStyle = RTFText.FS_ITALIC_S + RTFText.FS_UNDERLINE_S + RTFText.FS_STRIKE_S;
                    _endFontStyle = RTFText.FS_ITALIC_E + RTFText.FS_UNDERLINE_E + RTFText.FS_STRIKE_E; break;
                case FontStyles.Strike:
                    _startFontStyle = RTFText.FS_STRIKE_S;
                    _endFontStyle = RTFText.FS_STRIKE_E; break;
                case FontStyles.Underline:
                    _startFontStyle = RTFText.FS_UNDERLINE_S;
                    _endFontStyle = RTFText.FS_UNDERLINE_E; break;
                case FontStyles.UnderLineAndStrike:
                    _startFontStyle = RTFText.FS_UNDERLINE_S + RTFText.FS_STRIKE_S;
                    _endFontStyle = RTFText.FS_UNDERLINE_E + RTFText.FS_STRIKE_E; break;
            }
        }
        #endregion

    }
}
