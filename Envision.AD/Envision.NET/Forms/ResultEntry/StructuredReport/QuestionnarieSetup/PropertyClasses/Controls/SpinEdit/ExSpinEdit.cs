using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls
{
    public class ExSpinEdit : ExImage
    {
        private int _defaultValue = 0;
        private int _min = 0;
        private int _max = 50;
        private bool _forceInput = false;

        //[Browsable(false)]
        //public int Id { get; set; }

        //[Browsable(false)]
        //public int DetailId { get; set; }

        [Category("Numeric Properties")]
        [DefaultValue(0)]
        [DisplayName("Default value")]
        [Description("Initialize default value into numeric control")]
        public int DefaultValue
        {
            get { return _defaultValue; }
            set { _defaultValue = value; }
        }

        [Category("Numeric Properties")]
        [DefaultValue(0)]
        [Description("Initialize minimum value into numeric control")]
        public int Minimum
        {
            get { return _min; }
            set { _min = value; }
        }

        [Category("Numeric Properties")]
        [DefaultValue(50)]
        [Description("Initialize maximum value into numeric control")]
        public int Maximum
        {
            get { return _max; }
            set { _max = value; }
        }
        [Category("Numeric Properties")]
        [DefaultValue(false)]
        [Description("Set force input into text box")]
        [DisplayName("Force Input")]
        public bool ForceInput
        {
            get { return _forceInput; }
            set { _forceInput = value; }
        }
    }
}
