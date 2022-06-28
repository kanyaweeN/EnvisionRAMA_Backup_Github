using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Enums;
using System.Drawing;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnarieSetup.PropertyClasses.Controls;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls
{
    [TypeConverter(typeof(ExImageConverter))]
    public class ExImage : ControlBase
    {
        private Image _img = null;
        private Positions _position = Positions.Left; 

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

        [Category("Image")]
        [Description("initialize image position")]
        [DefaultValue(Positions.Left)]
        public Positions Position
        {
            get { return _position; }
            set { _position = value; }
        }
    }

    internal class ExImageConverter : ExpandableObjectConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            //if (destinationType == typeof(string) && value is ExImage)
            //{
            //    return "(Include image)";
            //}
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    internal class ImageConv : TypeConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string) && value is Image)
            {
                //Image img = value as Image;
                //return string.Format("({0}, {1})", img.Size.Width, img.Size.Height);
                return string.Empty;
            }
            else
                return "(No Image)";
        }
    }

}
