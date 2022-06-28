using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.NET.Mammogram.ResultEntry.BIRAD.Helper
{
    public class RTFParagraph
    {
        #region Parameters and Properties
        private string strText = string.Empty;
        private RTFFont font = new RTFFont();
        private int tabCount = 0;
        private int newLineCount = 0;

        /// <summary>
        /// Get or set text
        /// </summary>
        public string Word
        {
            get { return strText; }
            set { strText = value; }
        }

        /// <summary>
        /// Get or set font
        /// </summary>
        public RTFFont Font
        {
            get { return font; }
            set { font = value; }
        }

        /// <summary>
        /// Get or set number of tab before text
        /// </summary>
        public int TabCount
        {
            get { return tabCount; }
            set { tabCount = value; }
        }

        /// <summary>
        /// Get or set number of new line
        /// </summary>
        public int NewLineCount
        {
            get { return newLineCount; }
            set { newLineCount = value; }
        }
        #endregion

        #region Ctr
        /// <summary>
        /// Set rtf word
        /// </summary>
        /// <param name="word">Normal Word</param>
        public RTFParagraph(string word) { this.Word = word; }

        /// <summary>
        /// Set rtf word by font
        /// </summary>
        /// <param name="word">Normal Word</param>
        /// <param name="rtfFont">Font Style</param>
        public RTFParagraph(string word, RTFFont rtfFont)
        {
            this.Word = word;
            this.Font = rtfFont;
        }

        /// <summary>
        /// Set rtf word with number tab before text and number newline
        /// </summary>
        /// <param name="word">Normal Word</param>
        /// <param name="tabCount">number of tab before text</param>
        /// <param name="newlineCount">number of new line after text</param>
        public RTFParagraph(string word, int tabCount, int newlineCount)
        {
            this.Word = word;
            this.TabCount = tabCount;
            this.NewLineCount = newlineCount;
        }

        /// <summary>
        /// Set rtf word with font, number tab before text and number newline
        /// </summary>
        /// <param name="word">Normal Word</param>
        /// <param name="font">Font Style</param>
        /// <param name="tabCount">number of tab before text</param>
        /// <param name="newLineCount">number of new line after text</param>
        public RTFParagraph(string word, RTFFont font, int tabCount, int newLineCount)
        {
            this.Word = word;
            this.Font = font;
            this.TabCount = tabCount;
            this.NewLineCount = newLineCount;
        }
        #endregion
    }
}
