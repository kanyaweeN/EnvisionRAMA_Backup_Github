using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.ExPropertyGrid.Core;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Enums;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.Child;
using System.Drawing;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls
{
    [TypeConverter(typeof(ExChildConverter))]
    public class ExChild : Descriptor
    {
        public const string P_TEXT = "Text";
        public const string P_DEFAULT_TEXT = "DefaultText";
        public const string P_DEFAULT_VALUE = "DefaultValue";
        public const string P_SIZE = "Size";
        public const string P_FORCE_INPUT = "ForceInput";
        public const string P_MINIMUM = "Minimum";
        public const string P_MAXIMUM = "Maximum";
        //public const string P_IMAGE_SOURCE = "Image";
        //public const string P_POSITION = "Position";
        public const string P_GROUP_ITEM = "Items";

        private string _text = string.Empty;
        private ChildControlTypes _controlType = ChildControlTypes.Label;
        private string _defaultText = string.Empty;
        private int _defaultValue = 0;
        private Sizes _size = Sizes.Normal;
        //private Layouts _layout = Layouts.Horizontal;
        private bool _forceInput = false;
        private int _min = 0;
        private int _max = 50;
        //private Image _image = null;
        //private Positions _position = Positions.Left;
        private ExGroupItemCollection _Collection;

        [Browsable(false)]
        public int Id { get; set; }

        [Category("Control Type")]
        [DefaultValue(ChildControlTypes.Label)]
        [DisplayName("Type")]
        public ChildControlTypes Type
        {
            get { return _controlType; }
            set { _controlType = value; }
        }

        #region Property
        /// <summary>
        /// Get or set caption for item
        /// </summary>
        /// 
        //[Category("Caption and value")]
        [Category("Properties")]
        [DefaultValue("")]
        [Description("Initialize caption for child item")]
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        [Category("Properties")]
        [DefaultValue("")]
        [Description("Initialize default text into text box")]
        [DisplayName("Default Text")]
        public string DefaultText
        {
            get { return _defaultText; }
            set { _defaultText = value; }
        }

        [Category("Properties")]
        [DefaultValue(Sizes.Normal)]
        [Description("Set size of textbox")]
        public Sizes Size
        {
            get { return _size; }
            set { _size = value; }
        }

        [Category("Properties")]
        [DefaultValue(false)]
        [Description("Set force input into text box")]
        [DisplayName("Force Input")]
        public bool ForceInput
        {
            get { return _forceInput; }
            set { _forceInput = value; }
        }
        [Category("Properties")]
        [DefaultValue(0)]
        [DisplayName("Default value")]
        [Description("Initialize default value into numeric control")]
        public int DefaultValue
        {
            get { return _defaultValue; }
            set { _defaultValue = value; }
        }
        [Category("Properties")]
        [DefaultValue(0)]
        [Description("Initialize minimum value into numeric control")]
        public int Minimum
        {
            get { return _min; }
            set { _min = value; }
        }

        [Category("Properties")]
        [DefaultValue(50)]
        [Description("Initialize maximum value into numeric control")]
        public int Maximum
        {
            get { return _max; }
            set { _max = value; }
        }

        #region Image and Layout
        //[Category("Properties")]
        //[Category("Image")]
        //[DisplayName("Image")]
        //[Editor(typeof(ExImageViewer), typeof(System.Drawing.Design.UITypeEditor))]
        //[TypeConverter(typeof(ImageConv))]
        //[DefaultValue(null)]
        ////[DisplayName("Image Source")]
        ////[EditorAttribute(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        //[Description("Browsing image path")]
        //public Image Image
        //{
        //    get { return _image; }
        //    set { _image = value; }
        //}

        ////[Category("Properties")]
        //[Category("Image")]
        //[Description("initialize image position")]
        //[DefaultValue(Positions.Left)]
        //public Positions Position
        //{
        //    get { return _position; }
        //    set { _position = value; }
        //}

        //[Category("Properties")]
        //[Description("initialize control layout")]
        //[DefaultValue(Layouts.Horizontal)]
        //public Layouts Layout
        //{
        //    get { return _layout; }
        //    set { _layout = value; }
        //}
        #endregion

        [Description("Add and remove group button item")]
        [Category("Properties")]
        [Editor(typeof(ExGroupItemCollectionEdtor), typeof(System.Drawing.Design.UITypeEditor))]
        public ExGroupItemCollection Items
        {
            get { return _Collection; }
            set { _Collection = value; }
        }
        #endregion

        public ExChild()
        {
            this._Collection = new ExGroupItemCollection();
            this.PropertyCommands.AddRange(new PropertyCommand[] { 
                new PropertyCommand(P_TEXT, true, false),
                new PropertyCommand(P_DEFAULT_TEXT, true, false),
                new PropertyCommand(P_DEFAULT_VALUE, true, false),
                new PropertyCommand(P_FORCE_INPUT, true, false),
                //new PropertyCommand(P_IMAGE_SOURCE, true, false),
                new PropertyCommand(P_MAXIMUM, true, false),
                new PropertyCommand(P_MINIMUM, true, false),
                //new PropertyCommand(P_POSITION, true, false),
                new PropertyCommand(P_SIZE, true, false),
                new PropertyCommand(P_GROUP_ITEM, true, false)
            });
        }
    }

    internal class ExChildConverter : ExpandableObjectConverter
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
