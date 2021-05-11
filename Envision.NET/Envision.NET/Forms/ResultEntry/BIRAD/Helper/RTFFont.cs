using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.NET.Mammogram.ResultEntry.BIRAD.Helper
{
    /// <summary>
    /// RTF Font manager class
    /// </summary>
    public class RTFFont
    {
        #region Parameters and Properties
        private string rtfFontFamily = "Microsoft Sans Serif";
        private int rtfFontSize = 10;
        private bool isBold = false;
        private bool isItalic = false;
        private bool isUnderline = false;
        private RTFColors forgroundColor = RTFColors.Black;

        /// <summary>
        /// Get or set Rtf font family name
        /// </summary>
        public string FontFamily
        {
            get { return rtfFontFamily; }
            set { rtfFontFamily = value; }
        }

        /// <summary>
        /// Get or set Rtf font size
        /// </summary>
        public int FontSize
        {
            get { return rtfFontSize; }
            set { rtfFontSize = value; }
        }

        /// <summary>
        /// Get or set text weight to bold ( ตัวหนา )
        /// </summary>
        public bool IsBoldTextStyle
        {
            get { return isBold; }
            set { isBold = value; }
        }

        /// <summary>
        /// Get or set text style to italic ( ตัวเอียง )
        /// </summary>
        public bool IsItalicTextStyle
        {
            get { return isItalic; }
            set { isItalic = value; }
        }

        /// <summary>
        /// Get or set text underline ( ขีดเส้นใต้ )
        /// </summary>
        public bool IsUnderlineTextStyle
        {
            get { return isUnderline; }
            set { isUnderline = value; }
        }

        /// <summary>
        /// Get or set font color
        /// </summary>
        public RTFColors FontColor
        {
            get { return forgroundColor; }
            set { forgroundColor = value; }
        }
        #endregion

        #region Ctr
        /// <summary>
        /// Set All Properties of font
        /// </summary>
        /// <param name="fontfamily">Font Family name</param>
        /// <param name="fontSize">Font Size</param>
        /// <param name="isBold">Font Bold</param>
        /// <param name="isItalic">Font Italic</param>
        /// <param name="isUnderline">Font Underline</param>
        /// <param name="foregroundColor">Font Color</param>
        public RTFFont(string fontfamily, 
            int fontSize, 
            bool isBold, 
            bool isItalic, 
            bool isUnderline, 
            RTFColors foregroundColor)
        {
            this.FontFamily = fontfamily;
            this.FontSize = fontSize;
            this.IsBoldTextStyle = isBold;
            this.IsItalicTextStyle = isItalic;
            this.IsUnderlineTextStyle = isUnderline;
            this.FontColor = foregroundColor;
        }

        /// <summary>
        /// Set font family to text
        /// </summary>
        /// <param name="fontfamily"></param>
        public RTFFont(string fontfamily)
        {
            this.FontFamily = fontfamily;
        }

        /// <summary>
        /// Set font family and size to text
        /// </summary>
        /// <param name="fontFamily"></param>
        /// <param name="fontSize"></param>
        public RTFFont(string fontFamily, int fontSize)
        {
            this.FontFamily = fontFamily;
            this.FontSize = fontSize;
        }
        public RTFFont(bool isBold)
        {
            this.IsBoldTextStyle = isBold;
        }
        /// <summary>
        /// Get font with default
        /// </summary>
        public RTFFont() { }
        #endregion
    }
}
