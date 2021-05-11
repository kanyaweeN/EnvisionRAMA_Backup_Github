using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.Collections;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.ExPropertyGrid
{
    public class ExListBoxEditor : UITypeEditor
    {
        private IList _dataList;
        private readonly ListBox _listBox;
        private IWindowsFormsEditorService _editorService;

        public ExListBoxEditor()
        {
            _listBox = new ListBox();
            _listBox.BorderStyle = BorderStyle.None;
            _listBox.Click += new EventHandler(_listBox_Click);
            
        }

        private void _listBox_Click(object sender, EventArgs e)
        {
            this._editorService.CloseDropDown();
        }
        /// <summary>
        /// Get/Set for ListBox
        /// </summary>
        protected ListBox ListBox
        {
            get { return (_listBox); }
        }

        /// <summary>
        /// Get/Set for DataList
        /// </summary>
        protected IList DataList
        {
            get { return (_dataList); }
            set { _dataList = value; }
        }

        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (context != null && provider != null)
            {
                _editorService = provider.GetService(
                                    typeof(IWindowsFormsEditorService))
                                 as IWindowsFormsEditorService;
                if (_editorService != null)
                {
                    PopulateListBox(context, value);

                    _editorService.DropDownControl(_listBox);

                    RefreshList();
                }
            }
            return value;
        }

        private void RefreshList()
        {
            ////CustomItem item = null;
            //foreach (CustomItem ci in this._dataList)
            //{
            //    ci.Selected = false;
            //}

            for (int i = 0; i < _listBox.Items.Count; i++)
            {
                bool selectedIndex = _listBox.GetSelected(i);
                if (selectedIndex)
                {
                    (_dataList[i] as CustomItem).Selected = true;
                    _listBox.SelectedItem = (_dataList[i] as CustomItem).Name;
                    //_listBox.SetSelected(i, true);
                    //item.Selected = true;
                    //break;
                }
                else
                {
                    (_dataList[i] as CustomItem).Selected = false;
                }
            }
        }

        private void PopulateListBox(System.ComponentModel.ITypeDescriptorContext context, object value)
        {
            // Clear List
            _listBox.Items.Clear();
            _dataList = value as IList;
            if (_dataList != null)
            {
                for (int i = 0; i < _dataList.Count; i++ )
                {
                    CustomItem item = _dataList[i] as CustomItem;
                    _listBox.Items.Add(item.Name);
                    //_listBox.SetSelected(i, item.Selected);
                }
            }
            _listBox.Height = _listBox.PreferredHeight;
        }

        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }
    }
}
