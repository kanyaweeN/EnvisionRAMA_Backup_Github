using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnvisionBreastControl.Events
{
    public class ItemsArgs : EventArgs
    {
        public object AddedItem { get; set; }
        public object RemovedItem { get; set; }
        public object UpdatedItem { get; set; }
        public object NewItem { get; set; }
        public object OldItem { get; set; }
    }
}
