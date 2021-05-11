///
/// PJ. Miracle (Ton) 4/12/2010
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnvisionBreastControl.Lib.Cores.Events
{
    public class CRountEventArgs : EventArgs
    {
        public object OldValue { get; set; }
        public object NewValue { get; set; }
    }
}
