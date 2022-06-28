using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.RtfDocumentBuilder.Core
{
    /// <summary>
    /// This class use to identify 
    /// A set of characters used in Windows. Charsets refer to the same collections of characters 
    /// defined by Windows code pages, but their ID numbers can be expressed in a single byte
    /// </summary>
    public class CharSet
    {
        /// <summary>
        /// Get or set Charset name
        /// </summary>
        public CharSetName CharSetName { get; set; }
        /// <summary>
        /// Get or set Charset in hexidecimal value
        /// </summary>
        public int CharsetHexValue { get; set; }
        /// <summary>
        /// Get or set Charset in decimal value
        /// </summary>
        public int CharsetDecValue { get; set; }
        /// <summary>
        /// Get or set code page id of charset
        /// </summary>
        public int CodePageId { get; set; }

        /// <summary>
        /// A set of characters used in Windows. Charsets refer to the same collections of characters 
        /// defined by Windows code pages, but their ID numbers can be expressed in a single byte
        /// </summary>
        /// <param name="_charsetHexValue">Charset Hex Value</param>
        /// <param name="_charsetDecValue">Charset Decimal Value</param>
        /// <param name="_codePageId">Code Page Id</param>
        public CharSet(CharSetName charsetName, int _charsetHexValue, int _charsetDecValue, int _codePageId)
        {
            this.CharSetName = charsetName;
            this.CharsetDecValue = _charsetDecValue;
            this.CharsetHexValue = _charsetHexValue;
            this.CodePageId = _codePageId;
        }
    }
}
