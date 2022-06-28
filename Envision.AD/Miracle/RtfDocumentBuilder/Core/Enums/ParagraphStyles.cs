using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.RtfDocumentBuilder.Core
{
    /// <summary>
    /// Paragraph style is use to begin text in paragraph.
    /// You want a number or bullet before text or not.
    /// you can set on this style.
    /// </summary>
    public enum ParagraphStyles
    {
        None, //no paragraph style
        /// <summary>
        /// 1, 2, 3, ... 
        /// </summary>
        Numeric,
        /// <summary>
        /// I, II, III, ...
        /// </summary>
        UpperRoman,
        /// <summary>
        /// i, ii, iii ...
        /// </summary>
        LowerRoman,
        /// <summary>
        /// A, B, C, D, ...
        /// </summary>
        UpperAlpha,
        /// <summary>
        /// a, b, c, d, ...
        /// </summary>
        LowerAlpha,
        /// <summary>
        /// bullet in symbol character ('B7)
        /// </summary>
        Bullet
    }
}
