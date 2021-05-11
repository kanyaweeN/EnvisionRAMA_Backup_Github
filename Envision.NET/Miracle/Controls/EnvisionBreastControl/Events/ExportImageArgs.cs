using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace EnvisionBreastControl.Events
{
    public class ExportImageArgs : EventHandleBase
    {
        public Size ImageSize { get; set; }
        public string FileName { get; set; }
    }
    public delegate void onExportImageCompleted(object Sender, ExportImageArgs Args);
}
