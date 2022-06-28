using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Miracle.RtfDocumentBuilder.Core;

namespace Miracle.RtfDocumentBuilder
{
    /// <summary>
    /// Create Rtf paragraph in rtf format following as
    /// tab         - tab of paragraph
    /// new line    - new line paragraph
    /// Bullet      - using paragraph bullet
    /// not support section paragraph !!
    /// </summary>
    public class RTFParagraph : RTFDocumentBase
    {
        private Collection<string> contentCollection;
        /// <summary>
        /// Empty paragraph
        /// </summary>
        public static string EmptyText = string.Empty;
        /// <summary>
        ///  Tab character; same as ASCII 9
        /// </summary>
        private const string PS_TAB = @"\tab";
        /// <summary>
        ///  End of paragraph
        /// </summary>
        private const string PS_NEWLINE = @"\par";
        /// <summary>
        /// This group precedes all numbered/bulleted paragraphs, and contains all auto-generated
        /// text and formatting. It should precede the {\*\pn _ } destination, and it is the
        /// responsibility of RTF readers that understand the {\*\pn _ } destination to ignore this
        /// preceding group. This is a destination control word.
        /// </summary>
        private const string PS_PNTEXT = @"\pntext";

        #region Paragraph Margin
        /// <summary>
        /// \li[N] Left indent (default is 0).
        /// </summary>
        private const string PS_LI = @"\li";
        // font indent (default is 0)
        private const string PS_FI = @"\fi";
        /// <summary>
        /// \sb[N] Space before (default is 0)
        /// </summary>
        private const string PS_SB = @"\sb";
        /// <summary>
        /// \sa[N] Space after (default is 0)
        /// </summary>
        private const string PS_SA = @"\sa";
        /// <summary>
        /// Space between lines: if this control word is missing or if \ s1000 is used, the line
        /// spacing is automatically determined by the tallest character in the line; if n is a
        /// positive value, uses this size only if it is taller than the tallest character (otherwise
        /// uses the tallest character); if n is a negative value, uses the absolute value of n,
        /// even if it is shorter than the tallest character.
        /// </summary>
        private const string PS_SL = @"\sl";
        #endregion

        /// <summary>
        ///  Line spacing multiple; indicates that the current line spacing is a multiple of
        /// "Single" line spacing. This keyword can only follow the \ sl keyword and works in
        /// conjunction with it.
        /// 0   "At Least" or "Exactly" line spacing.
        /// 1   Multiple line spacing, relative to "Single"
        /// </summary>
        private const string PS_SLMUL = @"\slmul";
        // Define white space character
        public const string WHITE_SPACE = " ";
        // Start paragraph
        public const string START = @"{";
        // End paragraph
        public const string END = @"}";


        #region Const for bullets
        /// <summary>
        /// Font code for bullet in symbol font family
        /// </summary>
        private const string PS_BULLET_SYMBOL = @"\'B7";
        // Define font header
        private const string FONT_FAMILY_HEADER = @"\f";
        // Define header of specific data
        private const string PS_SPEC_DATA = @"\*";
        // Turn on paragraph
        private const string PS_TURN_ON_PARAGRAPH = @"\pn";
        // Bulleted paragraph (Level 11)
        private const string PS_BULLET_PARAGRAPH_LEVEL_11 = @"\pnlvlblt";
        // Simple paragraph numbering (Level 10)
        private const string PS_BULLET_PARAGRAPH_LEVEL_10 = @"\pnlvlbody";
        // Font family with number at N
        private const string PS_BULLET_FONT_FAMILY = @"\pnf";
        // Minimun distance from margin to body text (set default is 0)
        private const string PS_BULLET_MINIMUM_DISTANCE_MARGIN = @"\pnindent0";
        // Start at number 1
        private const string PS_BULLET_START_AT_NUMMBER1 = @"\pnstart1";
        // Decimal number
        private const string PS_BULLET_DECIMAL_NUMBER = @"\pndec";
        // Lower case alphab numbering
        private const string PS_BULLET_LOWERCASE_ALPH_NUMBER = @"\pnlcltr";
        // Upper case alphab numbering
        private const string PS_BULLET_UPPERCASE_ALPH_NUMBER = @"\pnucltr";
        // Upper case roman numbering
        private const string PS_BULLET_UPPERCASE_ROMAN_NUMBER = @"\pnucrm";
        // Lower case roman numbering
        private const string PS_BULLET_LOWERCASE_ROMAN_NUMBER = @"\pnlcrm";
        // before text at paragraph
        private const string PS_BULLET_BEFORE_TEXT = @"\pntxtb";
        // after text at paragraph
        private const string PS_BULLET_AFTER_TEXT = @"\pntxta";
        #endregion

        #region Paragraph Alignment
        // Define left alignment
        private const string PS_ALIGNMENT_LEFT = @"\ql";
        // Define right alignment
        private const string PS_ALIGNMENT_RIGHT = @"\qr";
        // Define center alignment
        private const string PS_ALIGNMENT_CENTER = @"\qc";
        // Define justify alignment
        private const string PS_ALIGNMENT_JUSTIFY = @"\qj";
        #endregion

        #region Private parameter
        // Set up key numerals and numeral pairs
        private int[] ROMAN_VALUE = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };

        // set up roman key
        string[] ROMAN_KEY = new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
        // Define paragraph alignment
        private ParagraphAlignments _alignment = ParagraphAlignments.Left;
        // Define text in paragraph
        private string _text = string.Empty;

        private FontStyles _fontstyle = FontStyles.None;

        #endregion

        #region Properties

        /// <summary>
        /// Get or set paragraph alignment
        /// </summary>
        public ParagraphAlignments Alignment
        {
            get { return _alignment; }
            set { _alignment = value; }
        }
        /// <summary>
        /// Get or set text in paragraph with default font
        /// </summary>
        public string Text
        {
            get { return _text; }
            set 
            { 
                _text = value;
                if (_text != string.Empty)
                    this.CheckCharacterText(_text);
            }
        }

        #endregion

        /// <summary>
        /// Create empty paragraph
        /// </summary>
        public RTFParagraph()
            : this(string.Empty, ParagraphAlignments.Left, FontStyles.None) { }
        /// <summary>
        /// Create paragraph with initial plain text
        /// </summary>
        /// <param name="plainText">plain text</param>
        public RTFParagraph(string plainText)
            : this(plainText, ParagraphAlignments.Left, FontStyles.None) { }

        /// <summary>
        /// Create paragraph with initial plain text
        /// </summary>
        /// <param name="plainText">plain text</param>
        public RTFParagraph(string plainText, FontStyles fontstyle)
            : this(plainText, ParagraphAlignments.Left, fontstyle) { }
        /// <summary>
        /// Create paragraph with custom alignment
        /// </summary>
        /// <param name="alignment">alignment</param>
        public RTFParagraph(ParagraphAlignments alignment)
            : this(string.Empty, alignment, FontStyles.None) { }
        /// <summary>
        /// Create paragraph with initial plain text and custom alignment
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="alignment"></param>
        public RTFParagraph(string plainText, ParagraphAlignments alignment, FontStyles fontStyle)
        {
            this.contentCollection = new Collection<string>();
            this._fontstyle = fontStyle;
            this.Text = plainText;
            this.Alignment = alignment;
        }
        /// <summary>
        /// Get this paragraph in rtf format
        /// </summary>
        public string Paragraph
        {
            get 
            {
                return this.BuildParagraph();
            }
        }

        #region Normal Paragraph
        /// <summary>
        /// Method use to add new content into rtf paragraph in rtf format.
        /// Such as Image , Text , Object
        /// Image   - {\pict\.... }
        /// Text    - \f0\cf....
        /// Object  -
        /// if the content is not in rtf format, it can't run fine
        /// </summary>
        /// <param name="RtfContent">RTF content</param>
        public void AddContent(string RtfContent)
        {
            this.contentCollection.Add(RtfContent);
        }
        #endregion

        #region Bullet Paragraph
        /// <summary>
        /// Add bullet paragrap with default bullet style and default paragraph margin
        /// </summary>
        /// <param name="RtfConent">Rtf content</param>
        public void AddBulletGroupContent(string[] RtfConent)
        {
            this.AddBulletGroupContent(RtfConent, ParagraphStyles.Bullet);
        }
        /// <summary>
        /// Add Gruop of bullet with paragraph style and one level margin
        /// </summary>
        /// <param name="RtfConent">content</param>
        /// <param name="paragraphStyle">paragraph style</param>
        public void AddBulletGroupContent(string[] RtfContent, ParagraphStyles paragraphStyle)
        {
            this.AddBulletGroupContent(RtfContent, paragraphStyle, ParagraphLevel.One);
        }
        /// <summary>
        /// Add Group of bullet woth paragrapj style and custom level of margin
        /// </summary>
        /// <param name="RtfContent">rtf content</param>
        /// <param name="paragraphStyle">paragraph style</param>
        /// <param name="paragraphLevel">paragraph level</param>
        public void AddBulletGroupContent(string[] RtfContent, ParagraphStyles paragraphStyle, ParagraphLevel paragraphLevel)
        {
            ParagraphStyles _paragraphStyle = paragraphStyle;
            ParagraphLevel _level = paragraphLevel;
            if (paragraphStyle == ParagraphStyles.None)
            {
                this.AddGroupContent(RtfContent);
                return;
            }
            int fontId = 0;
            string bulletHeader = string.Empty;
            string bulletDef = string.Empty;
            string paragraphMargin = string.Empty;

            if (paragraphStyle == ParagraphStyles.Bullet)
                fontId = this.AddFontHeader(FontFamilys.Symbol); //add and get bullet font id
            else
                if (this.FontCount == 0)
                    fontId = this.AddFontHeader(FontFamilys.MicrosoftSansSerif); //add default font if default font is not available
                else    
                    fontId = 0; //default font
            
            bulletDef = this.GetBulletDef(fontId, _paragraphStyle); //get specific header
            paragraphMargin = this.GetParagraphMargin(_level);// get paragraph margin

            //Build paragraph component
            for (int i = 0; i < RtfContent.Length; i++)
            {
                if (paragraphStyle == ParagraphStyles.Bullet)
                    bulletHeader = this.GetBulletHeader(fontId, _paragraphStyle); //get header
                else
                    bulletHeader = this.GetNumberBulletHeader(i + 1, fontId, _paragraphStyle); //get number bullet header
                
                StringBuilder str = new StringBuilder();
                str.Append(bulletHeader);//add header
                // Only first row need to add specifiy and paragraph
                // margin for paragraph
                if (i == 0)
                {
                    str.Append(bulletDef); //add specific header
                    str.Append(paragraphMargin); //add para margin
                }
                str.Append(RtfContent[i]); //add content
                str.Append(RTFParagraph.PS_NEWLINE); //add new line
                this.contentCollection.Add(str.ToString()); //add to main paragraph collection
            }
        }

        /// <summary>
        /// Add Paragraph Margin to paragraph
        /// </summary>
        /// <param name="_level">level of margin</param>
        /// <returns>paragraph margin</returns>
        private string GetParagraphMargin(ParagraphLevel _level)
        {
            int _fi = -360; // default font margin level 1
            int _li = 720; // default left margin level 1
            StringBuilder builder = new StringBuilder();
            switch (_level)
            {
                case ParagraphLevel.Zero: _li = 360; break;
                case ParagraphLevel.One: break;
                case ParagraphLevel.Two: _li = 1080; break;
                case ParagraphLevel.Three: _li = 1420; break;
            }
            builder.Append(RTFParagraph.PS_FI);
            builder.Append(_fi);
            builder.Append(RTFParagraph.PS_LI);
            builder.Append(_li);

            return builder.ToString();
        }
        /// <summary>
        /// Creating bullet header.
        /// To provide compatibility with existing RTF readers, all applications with the ability to automatically
        /// bullet or number paragraphs will also emit the generated text as plain text in the \pntext group. This will
        /// allow existing RTF readers to capture the plain text, and safely ignore the autonumber instructions. This
        /// group precedes all bulleted or numbered paragraphs, and will contain all the text and formatting that would
        /// be auto-generated. It should precede the {\*\pn _ } destination, and it is the responsibility of RTF readers
        /// that understand the {\*\pn _ } destination to ignore the \pntext group
        /// </summary>
        /// <param name="fontId">font id</param>
        /// <param name="paragraphStyle">paragraph style</param>
        /// <returns>bullet header</returns>
        private string GetBulletDef(int fontId, ParagraphStyles _paragraphStyle)
        {
            StringBuilder builder = new StringBuilder();
            if (_paragraphStyle == ParagraphStyles.Bullet)
            {
                builder.Append(RTFParagraph.START);
                builder.Append(RTFParagraph.PS_SPEC_DATA);
                builder.Append(RTFParagraph.PS_TURN_ON_PARAGRAPH);
                builder.Append(RTFParagraph.PS_BULLET_PARAGRAPH_LEVEL_11);
                builder.Append(RTFParagraph.PS_BULLET_FONT_FAMILY);
                builder.Append(fontId);
                builder.Append(RTFParagraph.PS_BULLET_MINIMUM_DISTANCE_MARGIN);
                builder.Append(RTFParagraph.START);
                builder.Append(RTFParagraph.PS_BULLET_BEFORE_TEXT);
                builder.Append(RTFParagraph.PS_BULLET_SYMBOL);
                builder.Append(RTFParagraph.END);
                builder.Append(RTFParagraph.END);
            }
            else
            {
                builder.Append(RTFParagraph.START);
                builder.Append(RTFParagraph.PS_SPEC_DATA);
                builder.Append(RTFParagraph.PS_TURN_ON_PARAGRAPH);
                builder.Append(RTFParagraph.PS_BULLET_PARAGRAPH_LEVEL_10);
                builder.Append(RTFParagraph.PS_BULLET_FONT_FAMILY);
                builder.Append(fontId);
                builder.Append(RTFParagraph.PS_BULLET_MINIMUM_DISTANCE_MARGIN);
                builder.Append(RTFParagraph.PS_BULLET_START_AT_NUMMBER1);
                // Chooese style with out bullet character style
                switch (_paragraphStyle)
                {
                    case ParagraphStyles.Numeric: builder.Append(RTFParagraph.PS_BULLET_DECIMAL_NUMBER); break;
                    case ParagraphStyles.UpperAlpha: builder.Append(RTFParagraph.PS_BULLET_UPPERCASE_ALPH_NUMBER); break;
                    case ParagraphStyles.LowerAlpha: builder.Append(RTFParagraph.PS_BULLET_LOWERCASE_ALPH_NUMBER); break;
                    case ParagraphStyles.UpperRoman: builder.Append(RTFParagraph.PS_BULLET_UPPERCASE_ROMAN_NUMBER); break;
                    case ParagraphStyles.LowerRoman: builder.Append(RTFParagraph.PS_BULLET_LOWERCASE_ROMAN_NUMBER); break;
                }
                builder.Append(RTFParagraph.START);
                builder.Append(RTFParagraph.PS_BULLET_AFTER_TEXT);
                builder.Append("."); //dot
                builder.Append(RTFParagraph.END);
                builder.Append(RTFParagraph.END);
            }
            return builder.ToString();
        }
        /// <summary>
        /// Creating bullet header.
        /// To provide compatibility with existing RTF readers, all applications with the ability to automatically
        /// bullet or number paragraphs will also emit the generated text as plain text in the \pntext group. This will
        /// allow existing RTF readers to capture the plain text, and safely ignore the autonumber instructions. This
        /// group precedes all bulleted or numbered paragraphs, and will contain all the text and formatting that would
        /// be auto-generated. It should precede the {\*\pn _ } destination, and it is the responsibility of RTF readers
        /// that understand the {\*\pn _ } destination to ignore the \pntext group
        /// </summary>
        /// <param name="fontId">font id</param>
        /// <param name="paragraphStyle">paragraph style</param>
        /// <returns>bullet header</returns>
        private string GetBulletHeader(int fontId, ParagraphStyles paragraphStyle)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append(RTFParagraph.START);
            strBuilder.Append(RTFParagraph.PS_PNTEXT);
            strBuilder.Append(RTFParagraph.FONT_FAMILY_HEADER);
            strBuilder.Append(fontId); //add font id
            strBuilder.Append(RTFParagraph.WHITE_SPACE);
            strBuilder.Append(RTFParagraph.PS_BULLET_SYMBOL);
            strBuilder.Append(RTFParagraph.PS_TAB);
            strBuilder.Append(RTFParagraph.END);
            //strBuilder.Append(@"{\*\pn\pnlvlblt\pnf1\pnindent0{\pntxtb\'B7}}");
            return strBuilder.ToString();
        }

        /// <summary>
        /// Get Number Bullet Header
        /// </summary>
        /// <param name="i">number sequence</param>
        /// <param name="fontId">font id</param>
        /// <param name="_paragraphStyle">paragraph Style</param>
        /// <returns></returns>
        private string GetNumberBulletHeader(int i, int fontId, ParagraphStyles _paragraphStyle)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append(RTFParagraph.START);
            strBuilder.Append(RTFParagraph.PS_PNTEXT);
            strBuilder.Append(RTFParagraph.FONT_FAMILY_HEADER);
            strBuilder.Append(fontId); //add font id
            strBuilder.Append(RTFParagraph.WHITE_SPACE);
            switch (_paragraphStyle)
            {
                case ParagraphStyles.Numeric: strBuilder.Append(i); break;
                case ParagraphStyles.LowerAlpha: break;
                case ParagraphStyles.UpperAlpha: break;
                case ParagraphStyles.UpperRoman: strBuilder.Append(this.ConvertToRomanNumbering(i)); break;
                case ParagraphStyles.LowerRoman: strBuilder.Append(this.ConvertToRomanNumbering(i).ToLower()); break;
            }
            strBuilder.Append(".");
            strBuilder.Append(RTFParagraph.PS_TAB);
            strBuilder.Append(RTFParagraph.END);

            return strBuilder.ToString();
        }
        #endregion

        #region Group Paragraph
        /// <summary>
        /// this method use to add group for content
        /// </summary>
        /// <param name="RtfContent">content with rtf format</param>
        private void AddGroupContent(string[] RtfContent)
        {
            foreach (string content in RtfContent)
                this.contentCollection.Add(content);
        }
        #endregion

        #region Build
        /// <summary>
        /// Build Paragraph
        /// </summary>
        /// <returns>full paragraph</returns>
        private string BuildParagraph()
        {
            try
            {
                StringBuilder strBuilder = new StringBuilder();
                //adjust paragraph
                switch (_alignment)
                {
                    case ParagraphAlignments.Left: break;
                    case ParagraphAlignments.Justify: strBuilder.Append(RTFParagraph.PS_ALIGNMENT_JUSTIFY); break;
                    case ParagraphAlignments.Center: strBuilder.Append(RTFParagraph.PS_ALIGNMENT_CENTER); break;
                    case ParagraphAlignments.Right: strBuilder.Append(RTFParagraph.PS_ALIGNMENT_RIGHT); break;
                }

                foreach (string content in this.contentCollection)
                {
                    strBuilder.Append(content);
                }
                return strBuilder.ToString();
            }
            finally
            {
                //this.contentCollection = null; //clear memory
            }
        }
        #endregion

        #region Helper
        /// <summary>
        /// This method use to convert number to roman number
        /// </summary>
        /// <param name="number">integer number</param>
        /// <returns>roman numbering</returns>
        public string ConvertToRomanNumbering(int number)
        {
            // Validate
            if (number < 0 || number > 3999)
                throw new ArgumentException("Value must be in the range 0 - 3,999.");

            if (number == 0) return "N";

            StringBuilder result = new StringBuilder();

            // Loop through each of the values to diminish the number
            for (int i = 0; i < 13; i++)
            {
                // If the number being converted is less than the test value, append
                // the corresponding numeral or numeral pair to the resultant string
                while (number >= ROMAN_VALUE[i])
                {
                    number -= ROMAN_VALUE[i];
                    result.Append(ROMAN_KEY[i]);
                }
            }

            // Done
            return result.ToString();
        }
        /// <summary>
        /// Check character in plain text if more than 1 charset
        /// spilt and and new group
        /// </summary>
        /// <param name="_text">plain text</param>
        private void CheckCharacterText(string _text)
        {
            //VerifyWordFontFace.VerifyFontFace[] text_part = VerifyWordFontFace.VerifyFromWord(_text);
            //Char[] char_array = _text.ToCharArray();
            //// Check all character in array
            //for (int i = 0; i < char_array.Length; i++)
            //{
                
            //}
            this.contentCollection.Add(RTFText.ParseToRtf(_text, _fontstyle));
        }

        #endregion
    }
}
