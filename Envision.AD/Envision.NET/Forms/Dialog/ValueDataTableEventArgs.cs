using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Envision.NET.Forms.Dialog
{
    /// Defines the signature for the method that the ValueUpdated handler need to support.
    public delegate void ValueDataTableEventHandler(object sender, ValueDataTableEventArgs e);


    /// Holds the event arguments for the ValueUpdated event.
    public class ValueDataTableEventArgs : System.EventArgs
    {
        /// Used to store the new value
        private DataTable newValue;

        /// Create a new instance of the ValueUpdatedEventArgs class.
        public ValueDataTableEventArgs(DataTable newValue)
        {
            this.newValue = newValue;
        }

        /// Gets the updated value
        public DataTable NewValue
        {
            get
            {
                return this.newValue;
            }
        }
    }
}
