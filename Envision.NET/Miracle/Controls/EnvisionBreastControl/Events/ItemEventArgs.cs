using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionBreastControl.Enums;

namespace EnvisionBreastControl.Events
{
    public class ItemEventArgs : EventArgs
    {
        public object Item { get; set; }
        public object ContextMenuItem { get; set; }
    }
}
