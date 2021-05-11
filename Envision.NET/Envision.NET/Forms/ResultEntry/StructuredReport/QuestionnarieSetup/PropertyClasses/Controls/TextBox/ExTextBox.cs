using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Enums;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls
{
    public class ExTextBox : ExImage
    {
        private string _defaultText = string.Empty;
        private Sizes _size = Sizes.Normal;
        private bool _forceInput = false;
        //private CImage _image = new CImage();

        //[Browsable(false)]
        //public int Id { get; set; }

        //[Browsable(false)]
        //public int DetailId { get; set; }

        [Category("Text Box Properties")]
        [DefaultValue("")]
        [Description("Initialize default text into text box")]
        public string DefaultText
        {
            get { return _defaultText; }
            set { _defaultText = value; }
        }

        [Category("Text Box Properties")]
        [DefaultValue(Sizes.Normal)]
        [Description("Set size of textbox")]
        public Sizes Size
        {
            get { return _size; }
            set { _size = value; }
        }

        [Category("Text Box Properties")]
        [DefaultValue(false)]
        [Description("Set force input into text box")]
        [DisplayName("Force Input")]
        public bool ForceInput
        {
            get { return _forceInput; }
            set { _forceInput = value; }
        }

        //[Category("Image")]
        //[DefaultValue(false)]
        //[Description("Including image into control")]
        //public CImage Image
        //{
        //    get { return _image; }
        //}
    }
}
