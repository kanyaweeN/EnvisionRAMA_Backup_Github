using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.NET.Forms.Dialog
{
    /// Defines the signature for the method that the ValueUpdated handler need to support.
    public delegate void ValueUpdatedEventHandler(object sender, ValueUpdatedEventArgs e);


    /// Holds the event arguments for the ValueUpdated event.
    public class ValueUpdatedEventArgs : System.EventArgs
    {
        /// Used to store the new value
        private string newValue;

        /// Create a new instance of the ValueUpdatedEventArgs class.
        public ValueUpdatedEventArgs(string newValue)
        {
            this.newValue = newValue;
        }

        /// Gets the updated value
        public string NewValue
        {
            get
            {
                return this.newValue;
            }
        }
    }
}
