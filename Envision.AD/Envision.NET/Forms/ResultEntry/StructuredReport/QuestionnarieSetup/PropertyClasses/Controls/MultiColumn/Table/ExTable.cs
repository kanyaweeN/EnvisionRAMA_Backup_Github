using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Enums;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnarieSetup.PropertyClasses.Controls;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.MultiColumn
{
    [TypeConverter(typeof(ExTableConverter))]
    public class ExTable : ControlBase
    {
        private SelectionTypes _selectionType = SelectionTypes.Single;
        private ExMultiColumnCollection _colsCollection;


        //[Browsable(false)]
        //public int Id { get; set; }

        [Category("Properties")]
        [DefaultValue(SelectionTypes.Single)]
        public SelectionTypes Selection
        {
            get { return _selectionType; }
            set { _selectionType = value; }
        }

        [Category("Properties")]
        [Editor(typeof(ExMultiColumnCollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ExMultiColumnCollection Column
        {
            get { return _colsCollection; }
            set { _colsCollection = value; }
        }

        public ExTable()
        {
            this._colsCollection = new ExMultiColumnCollection();
        }
    }

    internal class ExTableConverter : ExpandableObjectConverter
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
                return new InstanceDescriptor(typeof(ExTable).GetConstructor(new Type[0]), null, false);
            }
            return base.ConvertTo(context, info, value, destType);
        }


    }
}
