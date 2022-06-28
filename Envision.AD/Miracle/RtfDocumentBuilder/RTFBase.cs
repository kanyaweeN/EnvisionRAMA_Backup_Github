using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.RtfDocumentBuilder
{
    public class RTFBase
    {
        // Define white space character
        public const string WHITE_SPACE = " ";
        // Define tab before text count
        private int _tabBeforeText = 0; //default is zero
        // Define tab after text count
        private int _tabAfterText = 0; //default is zero

        /// <summary>
        /// Get or set number of tab before text
        /// </summary>
        public int TabBeforeText
        {
            get { return _tabBeforeText; }
            set 
            {
                if (value < 0)
                    throw new ArgumentException("The specific value of tab number must be more than zero(0).");
                _tabBeforeText = value; 
            }
        }

        /// <summary>
        /// Get or set number of tab after text
        /// </summary>
        public int TabAfterText
        {
            get { return _tabAfterText; }
            set 
            {
                if (value < 0)
                    throw new ArgumentException("The specific value of tab number must be more than zero(0).");
                _tabAfterText = value; 
            }
        }
    }
}
