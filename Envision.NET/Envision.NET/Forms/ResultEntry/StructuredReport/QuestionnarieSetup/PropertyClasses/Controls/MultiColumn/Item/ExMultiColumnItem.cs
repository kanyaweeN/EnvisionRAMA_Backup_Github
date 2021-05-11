using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.MultiColumn
{
    [TypeConverter(typeof(ExMultiColumnItemConverter))]
    public class ExMultiColumnItem
    {
        public string _label = "(Text)";
        public string _reportText = string.Empty;
        public bool _default = false;

        [Category("Item property")]
        [DefaultValue("(Text)")]
        public string Text
        {
            get { return _label; }
            set { _label = value; }
        }

        [Browsable(false)]
        public int Id { get; set; }

        [Category("Item property")]
        public string Value
        {
            get { return _reportText; }
            set { _reportText = value; }
        }

        [Category("Item property")]
        public bool Default
        {
            get { return _default; }
            set { _default = value; }
        }
    }

    internal class ExMultiColumnItemConverter : ExpandableObjectConverter
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
                return new InstanceDescriptor(typeof(ExMultiColumnItem).GetConstructor(new Type[0]), null, false);
            }
            return base.ConvertTo(context, info, value, destType);
        }


    }
}
