using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Miracle.RtfDocumentBuilder.Core;
using System.Collections.ObjectModel;

namespace Miracle.RtfDocumentBuilder
{
    /// <summary>
    /// Class for create rtf document following by format
    /// ------------------------------------------
    /// Contents of an RTF File
    /// An RTF file has the following syntax:
    /// <File> '{' <header> <document>'}'
    /// This syntax is overly strict; all RTF readers must read RTF that does not conform to this syntax. However,
    /// all RTF readers must correctly read RTF written according to this syntax. If you write RTF that conforms
    /// to this syntax, all correct RTF readers will read it.
    /// ------
    /// Header
    /// ------
    /// The header has the following syntax:
    /// <header> \ rtf <charset> \ deff? <fonttbl> <colortbl> <stylesheet>?
    /// -----------
    /// RTF Version
    /// -----------
    /// An entire RTF file is considered a group and must be enclosed in braces. The control word \ rtfN must
    /// follow the opening brace. The numeric parameter N identifies the version of the RTF standard used. The
    /// RTF standard described in this chapter corresponds to RTF Specification Version 1.
    /// -------------
    /// Character Set
    /// -------------
    /// After specifying the RTF version, you must declare the character set used in this document. The control
    /// word for the character set must precede any plain text or any table control words. The RTF specification
    /// currently supports the following character sets
    /// </summary>
    public class RTFDocument : RTFDocumentBase
    {
        private const string RTF_PAPER_HEADER = @"\viewkind4\uc1\pard\slmult1\lang9";
        // Resets to default paragraph properties
        private const string DOC_RESET_PARAGRAPH_TO_DEFAULT = @"\pard";
        // Ending of paragraph
        private const string DOC_END_PARAGRAPH = @"\par";
        // Rtf version 1
        private const string DOC_RTF_VERSION = @"\rtf1";
        // Start bucket syntex
        private const string DOC_START = @"{";
        // End bucket syntex
        private const string DOC_END = @"}";
        // Character Set is ANSI (default)
        private const string DOC_ANSI_CHARACTER_SET = @"\ansi";
        // Code package header with Arabic
        private const string DOC_CODE_PACKAGE = @"\cpg1252";
        // Default font in document with Fixed-pitch serif and sans serif fonts (Courier, Pica, etc.)
        private const string DOC_DEFAULT_FONT_DOCUMENT = @"\fmodern";
        // Set font at 0 is default font
        private const string DOC_DEFINE_FONT_DOC = @"\deff0";
        // define default font code at 1054
        private const string DOC_DEFLANG = @"\deflang1054";
        // define paragraph spacing
        private Spacing _spacing;
        /// <summary>
        /// Get or set paragarph spacing
        /// </summary>
        public Spacing ParagrapSpacing
        {
            get { return _spacing; }
            set { _spacing = value; }
        }
        // define paragraph contrainer
        private Collection<RTFParagraph> paragraphCollection;

        #region Ctr
        /// <summary>
        /// Craete Document with system default font style
        /// </summary>
        public RTFDocument()
            : this(FontFamilys.MicrosoftSansSerif, RtfColor.Black, new Spacing()) { }
        /// <summary>
        /// Create Document with system default font style and custom paragraph spacing
        /// </summary>
        /// <param name="paragraphSpacing">spacing</param>
        public RTFDocument(Spacing paragraphSpacing)
            : this(FontFamilys.MicrosoftSansSerif, RtfColor.Black, paragraphSpacing) { }

        /// <summary>
        /// Create document with custom font and custom spacing
        /// </summary>
        /// <param name="defaultFontfamily">font family</param>
        /// <param name="defaultFontColor">font color</param>
        /// <param name="spacing">spacing</param>
        public RTFDocument(FontFamilys defaultFontfamily, RtfColor defaultFontColor, Spacing spacing)
        {
            this.paragraphCollection = new Collection<RTFParagraph>();
            this.AddColorHeader(defaultFontColor); //add default font color
            this.AddFontHeader(defaultFontfamily); //add default font family
        }
        #endregion

        /// <summary>
        /// Get RtfDocument
        /// </summary>
        public string Document
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(this.BuildDocumentHeader());
                builder.Append(this.FontHeader);
                builder.Append(this.ColorHeader);
                builder.Append(RTF_PAPER_HEADER);
                foreach (RTFParagraph _paragraph in this.paragraphCollection)
                {
                    builder.Append(_paragraph.Paragraph);
                    builder.Append(RTFDocument.DOC_END_PARAGRAPH);
                    builder.Append(RTFDocument.DOC_RESET_PARAGRAPH_TO_DEFAULT);
                }
                builder.Append(RTFDocument.DOC_END);

                return builder.ToString();
            }
        }
        /// <summary>
        /// this method use to create rtf document header
        /// </summary>
        /// <returns></returns>
        private string BuildDocumentHeader()
        {
            StringBuilder strbuilder = new StringBuilder();
            strbuilder.Append(RTFDocument.DOC_START);
            strbuilder.Append(RTFDocument.DOC_RTF_VERSION);
            strbuilder.Append(RTFDocument.DOC_ANSI_CHARACTER_SET);
            strbuilder.Append(RTFDocument.DOC_CODE_PACKAGE);
            strbuilder.Append(RTFDocument.DOC_DEFAULT_FONT_DOCUMENT);
            strbuilder.Append(RTFDocument.DOC_DEFINE_FONT_DOC);
            strbuilder.Append(RTFDocument.DOC_DEFLANG);

            return strbuilder.ToString();
        }
        /// <summary>
        /// Add paragraph to document
        /// </summary>
        /// <param name="paragraph">paragraph</param>
        public void AddParagraph(RTFParagraph paragraph)
        {
            this.paragraphCollection.Add(paragraph);
        }
        /// <summary>
        /// Add plaintext to document (automatic new line)
        /// </summary>
        /// <param name="plaintext">plain text</param>
        public void AddParagraph(string plaintext)
        {
            this.paragraphCollection.Add(new RTFParagraph(plaintext));
        }
        /// <summary>
        /// REmove paragraph
        /// </summary>
        /// <param name="paragraph"></param>
        public void RemoveParagraph(RTFParagraph paragraph)
        {
            this.paragraphCollection.Remove(paragraph);
        }
    }
}
