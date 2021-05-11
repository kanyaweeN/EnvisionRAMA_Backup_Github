using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Design.Serialization;
using System.ComponentModel;
using System.Globalization;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.Collection;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Enums;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.ExPropertyGrid.Core;
using System.Drawing;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.Child
{
    [TypeConverter(typeof(ExItemConverter))]
    public class ExItem : Descriptor
    {
        private ExChildCollection _CheckBoxItemCollection;
        private string _text = "(Text)";
        private bool isDefault = false;

        private Image _img = null;
        private string _value = string.Empty;
        //private Positions _position = Positions.Left;

        [Browsable(false)]
        public int Id { get; set; }

        [Category("Image")]
        [DisplayName("Image")]
        [Editor(typeof(ExImageViewer), typeof(System.Drawing.Design.UITypeEditor))]
        [TypeConverter(typeof(ImageConv))]
        [DefaultValue(null)]
        //[EditorAttribute(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Description("Browsing image path")]
        public Image Image
        {
            get { return _img; }
            set { _img = value; }
        }

        //[Category("Image")]
        //[Description("initialize image position")]
        //[DefaultValue(Positions.Left)]
        //public Positions Position
        //{
        //    get { return _position; }
        //    set { _position = value; }
        //}

        public ExItem()
        {
            this._CheckBoxItemCollection = new ExChildCollection();
            this.PropertyCommands.Add(new PropertyCommand("Check", false, false));
        }
        [Category("Properties")]
        [DefaultValue("(Text)")]
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        [Category("Properties")]
        [DefaultValue("")]
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        [Category("Properties")]
        [DefaultValue(false)]
        public bool Check
        {
            get { return isDefault; }
            set { isDefault = value; }
        }

        [Description("Add and remove child item")]
        [Category("Child Item Collection")]
        [Editor(typeof(ExChildCollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ExChildCollection Child
        {
            get { return _CheckBoxItemCollection; }
            set { _CheckBoxItemCollection = value; }
        }
    }
    internal class ExItemConverter : ExpandableObjectConverter
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
                return new InstanceDescriptor(typeof(ExChild).GetConstructor(new Type[0]), null, false);
            }
            return base.ConvertTo(context, info, value, destType);
        }


    }
}
