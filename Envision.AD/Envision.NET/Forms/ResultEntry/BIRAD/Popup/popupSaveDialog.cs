using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Envision.NET.Forms.Dialog;

namespace Envision.NET.Mammogram.ResultEntry.BIRAD.Popup
{
    public partial class popupSaveDialog : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public string TemplateName { get; set; }
        public bool IsDefault { get; set; }
        public int language = 2;
        private MyMessageBox msg;
        public popupSaveDialog()
        {
            InitializeComponent();
            this.Load += new EventHandler(popupSaveDialog_Load);
            this.msg = new MyMessageBox();
            this.btnSave.ItemClick += new ItemClickEventHandler(btnSave_ItemClick);
            this.btnClose.ItemClick += new ItemClickEventHandler(btnClose_ItemClick);
        }

        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.tbTemplateName.Text.Trim().Length > 0)
            {
                this.TemplateName = this.tbTemplateName.Text;
                this.IsDefault = this.checkEdit1.Checked;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                string result = msg.ShowAlert("UID4006", this.language);
                if (result == "1" || result == "2")
                    this.tbTemplateName.Focus();
            }
        }

        private void popupSaveDialog_Load(object sender, EventArgs e)
        {
            this.tbTemplateName.Focus();
        }

        protected override void OnClosed(EventArgs e)
        {
            this.tbTemplateName.Text = string.Empty;
            this.checkEdit1.Checked = false;
            base.OnClosed(e);
        }

        public DialogResult ShowDialog(string TemplateName, bool isDefault)
        {
            this.tbTemplateName.Text = TemplateName;
            this.checkEdit1.Checked = isDefault;
            return this.ShowDialog();
        }
    }
}