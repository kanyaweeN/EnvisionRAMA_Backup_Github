using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.Collection;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.Child;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnarieSetup.PropertyClasses.Controls;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls
{
    public class ExGroup : ControlBase
    {
        private ExGroupItemCollection _Collection;
        public ExGroup()
        {
            this._Collection = new ExGroupItemCollection();
        }
        //[Browsable(false)]
        //public int Id { get; set; }

        //[TypeConverter(typeof(Converter.TypeGroupCollectionItemConverter))]
        [Description("Add and remove group button item")]
        [Category("Group item Collection")]
        [Editor(typeof(ExGroupItemCollectionEdtor), typeof(System.Drawing.Design.UITypeEditor))]
        public ExGroupItemCollection Items
        {
            get { return _Collection; }
            set { _Collection = value; }
        }
    }
}
