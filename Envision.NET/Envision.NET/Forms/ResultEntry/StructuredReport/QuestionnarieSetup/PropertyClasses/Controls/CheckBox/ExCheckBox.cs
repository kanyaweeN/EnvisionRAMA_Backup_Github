using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Enums;
using System.Collections.ObjectModel;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.Collection;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.Child;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnarieSetup.PropertyClasses.Controls;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls
{
    public class ExCheckBox : ControlBase
    {
        private ExItemCollection _CheckBoxItemCollection;
        public ExCheckBox()
        {
            this._CheckBoxItemCollection = new ExItemCollection();
        }

        //[Browsable(false)]
        //public int Id { get; set; }

        //[TypeConverter(typeof(Converter.TypeCollectionItemConverter))]
        [Description("Add and remove Check box item")]
        [Category("Check box item Collection")]
        [Editor(typeof(ExCheckItemCollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ExItemCollection Items
        {
            get { return _CheckBoxItemCollection; }
            set { _CheckBoxItemCollection = value; }
        }
    }
}
