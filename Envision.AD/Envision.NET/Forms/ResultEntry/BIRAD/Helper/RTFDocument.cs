using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.NET.Mammogram.ResultEntry.BIRAD.Helper
{
    /// <summary>
    /// Generate rtf document text class
    /// </summary>
    public class RTFDocument
    {
        private List<RTFParagraph> document;
        private const string RTF_HEADER = @"{\rtf1\fbidis\ansi\ansicpg874\deff0\deflang1054";
        private const string RTF_FONT_HEADER = @"{\fonttbl";
        private const string RTF_COLOR_HEADER = @"{\colortbl ;";
        private const string RTF_SYN_END = @"}";
        private const string RTF_PAPER_HEADER = @"\viewkind4\uc1\pard\slmult1\lang9";

        private List<string> fontFamilyNameSet;
        private List<RTFColors> fontColorNameSet;
        private Dictionary<string, string> fontFamilySymbolMapping;
        private Dictionary<string, string> fontColorSymbolMapping;

        private RTFFont defaultFont;

        /// <summary>
        /// Create instant with default font
        /// </summary>
        /// <param name="default_font_family"></param>
        /// <param name="default_font_size"></param>
        /// <param name="default_font_color"></param>
        public RTFDocument(string default_font_family, int default_font_size, RTFColors default_font_color)
        {
            //defined default font
            this.defaultFont = new RTFFont();
            this.defaultFont.FontColor = default_font_color;
            this.defaultFont.FontFamily = default_font_family;
            this.defaultFont.FontSize = default_font_size;

            //Create parameters
            this.document = new List<RTFParagraph>();
            this.fontColorNameSet = new List<RTFColors>();
            this.fontFamilyNameSet = new List<string>();
            this.fontFamilySymbolMapping = new Dictionary<string, string>();
            this.fontColorSymbolMapping = new Dictionary<string, string>();
        }

        /// <summary>
        /// Create instant
        /// </summary>
        public RTFDocument()
            : this("Microsoft Sans Serif", 10, RTFColors.Black) { }

        /// <summary>
        /// This method use to add new paragraph
        /// </summary>
        /// <param name="paragraph">paragraph</param>
        public void Add(RTFParagraph paragraph)
        {
            this.document.Add(paragraph);
        }

        /// <summary>
        /// Tis method use to remove added paragraph
        /// </summary>
        /// <param name="paragraph">new paragraph</param>
        public void Remove(RTFParagraph paragraph)
        {
            this.document.Remove(paragraph);
        }

        /// <summary>
        /// Get RTF Document
        /// </summary>
        /// <returns>RTF Text</returns>
        public string GetRTFDocument()
        {
            string str = string.Empty;
            //Get all font family
            string font_family = RTF_FONT_HEADER; //start font family header
            string font_color = RTF_COLOR_HEADER; //start font color header
            string content = string.Empty;
            int count_font = 1;
            int count_color = 1;
            str += RTF_HEADER;
            //Create Default font header and color header
            //font family
            font_family += @"{\f0\fnil\fcharset0 "
                        + defaultFont.FontFamily.Trim() + @";}";
            this.fontFamilySymbolMapping.Add(defaultFont.FontFamily.Trim(), "f0");
            //font color
            System.Drawing.Color color = System.Drawing.Color.FromName(defaultFont.FontColor.ToString());
            font_color += @"\red" + color.R;
            font_color += @"\green" + color.G;
            font_color += @"\blue" + color.B + @";";
            this.fontColorSymbolMapping.Add(defaultFont.FontColor.ToString(), "cf0");

            foreach (RTFParagraph paragraph in this.document)
            {
                //Check font family name is exits or not
                if (!font_family.Contains(paragraph.Font.FontFamily.Trim()))
                {
                    font_family += @"{\f" + count_font + @"\fnil\fcharset0 "
                        + paragraph.Font.FontFamily.Trim() + @";}";
                    this.fontFamilySymbolMapping.Add(paragraph.Font.FontFamily, "f" + count_font);
                    count_font++;
                }
                //add font color header
                if (!this.fontColorSymbolMapping.Keys.Contains(paragraph.Font.FontColor.ToString()))
                {
                    color = System.Drawing.Color.FromName(paragraph.Font.FontColor.ToString());
                    font_color += @"\red" + color.R;
                    font_color += @"\green" + color.G;
                    font_color += @"\blue" + color.B + @";";
                    this.fontColorSymbolMapping.Add(paragraph.Font.FontColor.ToString(), "cf" + count_color);
                    count_color++;
                }
            }
            font_family += RTF_SYN_END;
            font_color += RTF_SYN_END;
            //Add paragraph
            foreach (RTFParagraph paragraph in this.document)
            {
                string text = paragraph.Word;
                //set font family
                text = @"\" + this.fontFamilySymbolMapping[paragraph.Font.FontFamily] + text + @"\f0";
                //set font color
                text = @"\" + this.fontColorSymbolMapping[paragraph.Font.FontColor.ToString()] + text + @"\cf0";
                //set font size
                text = @"\fs" + (int)(paragraph.Font.FontSize * 2) + " " + text + @"\fs" + (int)(defaultFont.FontSize * 2);
                if (paragraph.Font.IsBoldTextStyle)
                    text = @"\b" + text + @"\b0";
                if (paragraph.Font.IsItalicTextStyle)
                    text = @"\i" + text + @"\i0";
                if (paragraph.Font.IsUnderlineTextStyle)
                    text = @"\ul" + text + @"\ulnone";
                if (paragraph.TabCount > 0)
                {
                    for( int i = 0; i < paragraph.TabCount; i++)
                        text = @"\tab" + text;
                }
                if (paragraph.NewLineCount > 0)
                {
                    for (int i = 0; i < paragraph.NewLineCount; i++)
                        text += @"\par ";
                }
                content += text;
            }
            str += font_family + font_color + RTF_PAPER_HEADER + content + RTF_SYN_END;
            //Clear memory
            this.document = null;
            this.fontColorNameSet = null;
            this.fontFamilyNameSet = null;
            this.fontColorSymbolMapping = null;
            this.fontFamilySymbolMapping = null;
            return str;
        }
    }
}
