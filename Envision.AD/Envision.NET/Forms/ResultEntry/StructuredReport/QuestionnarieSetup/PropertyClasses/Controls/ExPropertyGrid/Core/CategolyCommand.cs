using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.ExPropertyGrid.Core
{
    [TypeConverter(typeof(CategoryCommandConverter))]
    public class CategoryCommand
    {
        private string _Name = "Category Command";
        private bool _Visible = true;


        [Category("Visibility")]
        public bool Visible
        {
            get { return _Visible; }
            set { _Visible = value; }
        }

        [Category("Category Name")]
        public string Name
        {
            get { return _Name; }
        }

        public CategoryCommand()
        { }

        public CategoryCommand(string Name)
        {
            _Name = Name;
        }
        public CategoryCommand(string Name, bool Visible)
        {
            this._Name = Name;
            this._Visible = Visible;
        }
        public override string ToString()
        {
            return Name;
        }

    }

    internal class CategoryCommandConverter : ExpandableObjectConverter
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
                return new InstanceDescriptor(typeof(CategoryCommand).GetConstructor(new Type[] { typeof(string), typeof(bool) }), new object[] { ((CategoryCommand)value).Name, ((CategoryCommand)value).Visible }, true);
            }
            return base.ConvertTo(context, info, value, destType);
        }


    }
}
