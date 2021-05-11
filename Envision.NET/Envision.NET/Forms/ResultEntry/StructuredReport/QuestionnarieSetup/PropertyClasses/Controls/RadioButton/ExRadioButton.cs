using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Enums;
using System.Collections.ObjectModel;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.Collection;
using System.ComponentModel;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.Child;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.ExPropertyGrid;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnarieSetup.PropertyClasses.Controls;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls
{
    public class ExRadioButton : ControlBase
    {
        private ExItemCollection _CheckBoxItemCollection;
        private List<CustomItem> _listEditorName;
        public ExRadioButton()
        {
            this._CheckBoxItemCollection = new ExItemCollection();
            this._listEditorName = new List<CustomItem>();
        }

        //[Browsable(false)]
        //public int Id { get; set; }

        //[TypeConverter(typeof(Converter.TypeCollectionItemConverter))]
        [Description("Add and remove Check box item")]
        [Category("Check box item Collection")]
        [Editor(typeof(ExItemCollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ExItemCollection Items
        {
            get
            {

                this.UpdateEditorName();
                return _CheckBoxItemCollection;
            }
            set
            {
                _CheckBoxItemCollection = value;
            }
        }
        [Category("Default Item")]
        [DefaultValue("")]
        [Editor(typeof(ExListBoxEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [TypeConverter(typeof(RadioButtonDefaultItemConverter))]
        public List<CustomItem> Default
        {
            get { return _listEditorName; }
            set { _listEditorName = value; }
        }

        private void UpdateEditorName()
        {
            if (this._listEditorName != null)
            {
                bool NeedUpdate = false;
                if (this._listEditorName.Count - 1 == this._CheckBoxItemCollection.Count)
                {
                    for (int i = 0; i < this._listEditorName.Count; i++)
                    {
                        if (i == 0)
                            continue;
                        if (this._CheckBoxItemCollection[i - 1].Text != this._listEditorName[i].Name)
                            NeedUpdate = true;
                    }

                }
                else
                    NeedUpdate = true;

                if (NeedUpdate)
                {
                    this._listEditorName.Clear();
                    this._listEditorName.Add(new CustomItem() { Name = "(None)", Selected = true });
                    foreach (ExItem item in this._CheckBoxItemCollection)
                    {
                        CustomItem citem = new CustomItem() { Name = item.Text };
                        this._listEditorName.Add(citem);
                    }
                }
            }
        }

        //public List<string> EditorName
        //{
        //    get { return 
        //}
    }
    internal class RadioButtonDefaultItemConverter : TypeConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                List<CustomItem> cItem = value as List<CustomItem>;
                foreach (CustomItem item in cItem)
                {
                    if (item.Selected)
                        return item.Name;

                }
                return "(None)";
            }
            else
            {
                return "(None)";
            }
        }
    }
}
