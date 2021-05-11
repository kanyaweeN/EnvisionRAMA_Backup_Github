using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Enums;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls
{
    public class ExDatePick : ExImage
    {
        private DateTime _defaultDateTime = DateTime.Now;
        private bool _forceInput = false;

        //[Browsable(false)]
        //public int Id { get; set; }

        //[Browsable(false)]
        //public int DetailId { get; set; }

        [Category("Date Pick Properties")]
        [DisplayName("Force Input")]
        [DefaultValue(false)]
        [Description("Initialize force input value into date pick control")]
        public bool ForceInput
        {
            get { return _forceInput; }
            set { _forceInput = value; }
        }
    }
}
