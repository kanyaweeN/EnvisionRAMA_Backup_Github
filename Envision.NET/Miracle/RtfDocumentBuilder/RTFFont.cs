using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Miracle.RtfDocumentBuilder.Core;

namespace Miracle.RtfDocumentBuilder
{
    /// <summary>
    /// Rtf font have many option such as font family, font size, font color
    /// font style (bold, Italic, underline etc) and cover to hightlight font color
    /// </summary>
    public class RTFFont : RTFDocumentBase
    {
        // Font family Id use to set font id form font header.
        // '{\f0\fnil\charset0 Tahoma'} is mean
        // fnil     - Knownlege Font
        // charset0 - Start with character at 0
        // and font family name is Tahoma. it has font id to 0.
        // You can get from header when you added font family into font header
        private int _fontFamilyId = 0;
        // Color id is come from color header as 
        // '{\colortbl ;\red255\green0\blue0;}'
        // colortbl             - table color header
        // \red255\green0\blue0 - Red color code from rtf color table and color code is follow sequence. 
        // In this example sequence is 0 then color id is 0 too
        private int _fontColorId = 0;
        // Same as font color id concept
        private int _fontBackgroundColorId = 0;
        // Define font family name with default is Microsoft Sans Serif
        private FontFamilys _fontfamily = FontFamilys.MicrosoftSansSerif;
        // Define font size with default is 10 (pixel)
        private int _fontSize = 10;
        // Define font color with default is black color
        private RtfColor _fontColor = RtfColor.Black;
        // Define font background color with default is no color(none)
        private RtfColor _hightColor = RtfColor.None;
        // Define font style with default is no style(plan text)
        private FontStyles _fontStyle = FontStyles.None;

        #region Font Properties

        /// <summary>
        /// Get font family id from header
        /// </summary>
        public int FontFamilyId 
        { 
            get { return _fontFamilyId; }
            private set { _fontFamilyId = value; }
        }

        /// <summary>
        /// Get font color id from header
        /// </summary>
        public int FontColorId { get { return _fontFamilyId; } }

        /// <summary>
        /// /Get font background color id from headre
        /// </summary>
        public int FontBackgroundColorId { get { return _fontBackgroundColorId; } }

        /// <summary>
        /// Get or set font family name with font family collection
        /// </summary>
        public FontFamilys FontFamily
        {
            get { return _fontfamily; }
            set
            {
                // Check font family is exited ?
                if (value != _fontfamily)
                {
                    _fontfamily = value; //define new font
                    //add new font to font header and get font family id
                    _fontFamilyId = this.AddFontHeader(_fontfamily);
                }
            }
        }

        /// <summary>
        /// Get or set font size (uint)
        /// </summary>
        public int FontSize
        {
            get { return _fontSize; }
            set { _fontSize = value; }
        }

        /// <summary>
        /// Get or set font color (foreground color)
        /// </summary>
        public RtfColor FontColor
        {
            get { return _fontColor; }
            set
            {
                if (value != _fontColor)
                {
                    _fontColor = value;
                    //add new color to color header and get color header id
                    this._fontColorId = this.AddColorHeader(_fontColor);
                }
            }
        }

        /// <summary>
        /// Get or set font background color (Hightlight color)
        /// </summary>
        public RtfColor FontBackgroundColor
        {
            get { return _hightColor; }
            set
            {
                if (value != _hightColor)
                {
                    _hightColor = value;
                    //add new color to color header and get color header id
                    this._fontBackgroundColorId = this.AddColorHeader(_hightColor);
                }
            }
        }

        /// <summary>
        /// Get or set font style as bold, italic, etc..
        /// </summary>
        public FontStyles FontStyle
        {
            get { return _fontStyle; }
            set { _fontStyle = value; }
        }
        #endregion

        #region Update Font Family Id
        /// <summary>
        /// This method use to update font family id
        /// </summary>
        /// <param name="id">font id</param>
        /// <param name="font">font</param>
        public static void SetCharset(RTFFont font, CharSet charset)
        {
            int id = UpdateCharSet(font.FontFamily, charset);
            font.FontFamilyId = id;
        }
        #endregion

        #region Ctr
        /// <summary>
        /// This constructor is use default font. No set anything more.
        /// </summary>
        public RTFFont() 
        {
            this._fontFamilyId = this.AddFontHeader(_fontfamily); //add default font family and get id
            this._fontColorId = this.AddColorHeader(_fontColor); //add default font color and get id
            this._fontBackgroundColorId = this.AddColorHeader(_hightColor); //add default font background color and get id
        }

        /// <summary>
        /// This constructor is use to set new font family.
        /// </summary>
        /// <param name="fontFamily">Font family collection</param>
        public RTFFont(FontFamilys fontFamily)
        {
            this.FontFamily = fontFamily; //set new font family property
            this._fontColorId = this.AddColorHeader(_fontColor); //add default font color and get id
            this._fontBackgroundColorId = this.AddColorHeader(_hightColor); //add default font background color and get id
        }

        /// <summary>
        /// This constructor us use to set new font family and font size
        /// </summary>
        /// <param name="fontFamily">Font Family Collection</param>
        /// <param name="fontSize">Font Size (uint)</param>
        public RTFFont(FontFamilys fontFamily, int fontSize)
        {
            this.FontFamily = fontFamily; //set new font family property
            this.FontSize = fontSize;
            this._fontColorId = this.AddColorHeader(_fontColor); //add default font color and get id
            this._fontBackgroundColorId = this.AddColorHeader(_hightColor); //add default font background color and get id
        }

        /// <summary>
        /// this constructor is use to set new font style
        /// </summary>
        /// <param name="fontStyle">font style collection</param>
        public RTFFont(FontStyles fontStyle)
        {
            this.FontStyle = fontStyle; //set new font style property
            this._fontFamilyId = this.AddFontHeader(_fontfamily); //add default font family and get id
            this._fontColorId = this.AddColorHeader(_fontColor); //add default font color and get id
            this._fontBackgroundColorId = this.AddColorHeader(_hightColor); //add default font background color and get id
        }

        /// <summary>
        /// this constructor is use to set new font family, font size and font style
        /// </summary>
        /// <param name="fontFamily">Font Family Collection</param>
        /// <param name="fontSize">Font Size (uint)</param>
        /// <param name="fontStyle">Font Style</param>
        public RTFFont(FontFamilys fontFamily, int fontSize, FontStyles fontStyle)
        {
            this.FontFamily = fontFamily; //set new font family property
            this.FontSize = fontSize;
            this.FontStyle = fontStyle; //set new font style property
            this._fontColorId = this.AddColorHeader(_fontColor); //add default font color and get id
            this._fontBackgroundColorId = this.AddColorHeader(_hightColor); //add default font background color and get id
        }

        /// <summary>
        /// This constructor use to set all new font format
        /// </summary>
        /// <param name="fontFamily">Font family Collection</param>
        /// <param name="fontSize">Font Size</param>
        /// <param name="fontColor">Font Color (foreground)</param>
        /// <param name="fontBackgroundColor">Font Background Color</param>
        /// <param name="fontStyle">Font Style</param>
        public RTFFont(FontFamilys fontFamily, int fontSize, RtfColor fontColor, RtfColor fontBackgroundColor, FontStyles fontStyle)
        {
            this.FontFamily = fontFamily; //set new font family property
            this.FontSize = fontSize; //set new font size property
            this.FontStyle = fontStyle; //set new font style property
            this.FontColor = fontColor; //set new font color property
            this.FontBackgroundColor = fontBackgroundColor; //set new font background color property
        }
        #endregion

    }
}
