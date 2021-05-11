using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.RtfDocumentBuilder.Core
{
    /// <summary>
    /// Setting paragraph spacing in rtf document
    /// </summary>
    public class Spacing
    {
        //define space after (default is 0) 
        private int _sa = 0;
        //define space before (default is 0)
        private int _sb = 0;
        //define space line (default is 0)
        private int _sl = 0;

        /// <summary>
        /// Get or set space after (default is 0) 
        /// </summary>
        public int After
        {
            get { return _sa; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("A value must be more than zero(0).");
                _sa = value;
            }
        }

        /// <summary>
        /// Get or set space before (default is 0) 
        /// </summary>
        public int Before
        {
            get { return _sb; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("A value must be more than zero(0).");
                _sb = value;
            }
        }

        /// <summary>
        /// Get or set Space between lines: if this control word is missing or if \ s1000 is used, the line
        /// spacing is automatically determined by the tallest character in the line; if n is a
        /// positive value, uses this size only if it is taller than the tallest character (otherwise
        /// uses the tallest character); if n is a negative value, uses the absolute value of n,
        // even if it is shorter than the tallest character.
        /// </summary>
        public int BetweenLine
        {
            get { return _sl; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("A value must be more than zero(0).");
                _sl = value;
            }
        }
    }
}
