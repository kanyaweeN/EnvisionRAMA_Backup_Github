using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnvisionBreastControl.Events
{
    public class EventHandleBase : EventArgs
    {
        public bool IsCompleted { get; set; }
        public string ErrorMessage { get; set; }
    }
}
