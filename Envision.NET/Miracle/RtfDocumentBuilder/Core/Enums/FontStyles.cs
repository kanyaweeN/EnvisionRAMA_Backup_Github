using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.RtfDocumentBuilder.Core
{
    /// <summary>
    /// Font styles are use in normal rtf document or microsoft word
    /// Normally, font style must be more than 1 style such as bold and underline, 
    /// bold and stroke, italic and underline. So, in my enum have many style follow
    /// word editer style.
    /// </summary>
    public enum FontStyles
    {
        None, //Plain text
        Bold,
        Italic,
        Underline,
        DoubleUnderLine,
        Strike,
        BoldAndItalic,
        BoldAndUnderLine,
        BoldAndDoubleUnderLine,
        BoldAndStrike,
        BoldAndItalicAndUnderLine,
        BoldAndItalicAndDoubleUnderLine,
        BoldAndItalicAndStrike,
        BoldAndUnderLineAndStrike,
        BoldAndDoublieUnderLineAndStrike,
        BoldAndItalicAndUnderLineAndStrike,
        BoldAndItalicAndDoubleUnderLineAndStrike,
        ItalicAndUnderLine,
        ItalicAndDoubleUnderLine,
        ItalicAndStrike,
        ItalicAndUnderLineAndStrike,
        ItalicAndDoubleUnderLineAndStrike,
        UnderLineAndStrike,
        DoubleUnderLineAndStrike,
    }
}
