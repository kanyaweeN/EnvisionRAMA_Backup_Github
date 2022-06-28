using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnarieSetup.PropertyClasses.Controls;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls
{
    public class ExLabel : ControlBase
    {
        private string _text = string.Empty;

        //[Browsable(false)]
        //public int Id { get; set; }

        [Category("Text")]
        [DefaultValue("")]
        [Description("Writing some text here.")]
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
    }
}
