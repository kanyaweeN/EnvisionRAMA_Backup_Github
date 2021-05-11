using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnvisionBreastControl.Events
{
    public class SyncItemsArgs : EventArgs
    {
        public SyncAckFormStates SyncState { get; set; }
        public object Item { get; set; }
    }
}
