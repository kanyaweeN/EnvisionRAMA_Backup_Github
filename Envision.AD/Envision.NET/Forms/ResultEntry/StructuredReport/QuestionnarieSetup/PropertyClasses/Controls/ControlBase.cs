using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnarieSetup.PropertyClasses.Controls
{
    public class ControlBase
    {
        [Browsable(false)]
        public int Id { get; set; }
        [Browsable(false)]
        public int DetailId { get; set; }
        //[Browsable(false)]
        //public int OldDetailId { get; set; }
    }
}
