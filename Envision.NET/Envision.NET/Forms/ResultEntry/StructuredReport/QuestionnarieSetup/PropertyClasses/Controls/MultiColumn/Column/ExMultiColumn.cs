using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.ExPropertyGrid.Core;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.MultiColumn;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Enums;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.MultiColumn.MutiColumnItem;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls
{
    [TypeConverter(typeof(ExMultiColumnConverter))]
    public class ExMultiColumn : Descriptor
    {
      
        private ExMultiColumnItemCollection _colsCollection;
        public ExMultiColumn()
        {
            this._colsCollection = new ExMultiColumnItemCollection();
        }

        [Browsable(false)]
        public int Id { get; set; }

        [Category("Properties")]
        [Editor(typeof(ExMultiColumnItemCollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ExMultiColumnItemCollection Column
        {
            get { return _colsCollection; }
            set { _colsCollection = value; }
        }
    }

    internal class ExMultiColumnConverter : ExpandableObjectConverter
    {

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destType)
        {
            if (destType == typeof(InstanceDescriptor))
            {
                return true;
            }
            return base.CanConvertTo(context, destType);
        }


        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo info, object value, Type destType)
        {
            if (destType == typeof(InstanceDescriptor))
            {
                return new InstanceDescriptor(typeof(ExMultiColumn).GetConstructor(new Type[0]), null, false);
            }
            return base.ConvertTo(context, info, value, destType);
        }


    }
}
