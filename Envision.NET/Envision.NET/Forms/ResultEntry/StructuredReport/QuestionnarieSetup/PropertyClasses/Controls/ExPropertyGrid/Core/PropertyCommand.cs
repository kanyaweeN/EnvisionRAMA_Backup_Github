using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.ExPropertyGrid.Core
{
    [TypeConverter(typeof(PropertyCommandConverter))]
    public class PropertyCommand
    {
        private bool _ReadOnly = false;
        private bool _Visible = true;
        private string _Name = "Property Command";

        [Category("Property Name")]
        public string Name
        {
            get { return _Name; }
        }

        [Category("Visibility")]
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set { _ReadOnly = value; }
        }

        [Category("Visibility")]
        public bool Visible
        {
            get { return _Visible; }
            set { _Visible = value; }
        }

        public PropertyCommand()
        { }

        public PropertyCommand(string Name)
        {
            this._Name = Name;
        }

        public PropertyCommand(string Name, bool Visible, bool ReadOnly)
        {
            this._Name = Name;
            this._Visible = Visible;
            this._ReadOnly = ReadOnly;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    internal class PropertyCommandConverter : ExpandableObjectConverter
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
                return new InstanceDescriptor(typeof(PropertyCommand).GetConstructor(new Type[] { typeof(string), typeof(bool), typeof(bool) }), new object[] { ((PropertyCommand)value).Name, ((PropertyCommand)value).Visible, ((PropertyCommand)value).ReadOnly }, true);
            }
            return base.ConvertTo(context, info, value, destType);
        }


    }
}
