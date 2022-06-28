using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.RtfDocumentBuilder.Core
{
    /// <summary>
    /// Paragraph alignment use to adjust the paragraph (line).
    /// In normal document has default paragraph alignment is left alignment.
    /// You can adjust on 4 alignment such as left, right, justify and center
    /// </summary>
    public enum ParagraphAlignments
    {
        Left,
        Right,
        Justify,
        Center
    }
}
