using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace EnvisionBreastControl.Events
{
    public class ImportImageArgs : EventHandleBase
    {
        public Size ImageSize { get; set; }
        public string FileName { get; set; }
        public bool IsFromDragDrop { get; set; }
    }
    public delegate void onImportImageCompleted(object Sender, ImportImageArgs Args);
}
