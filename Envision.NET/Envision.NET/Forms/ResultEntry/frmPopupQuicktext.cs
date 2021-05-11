using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;

using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.Common;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic.ProcessRead;
using Envision.Common.Common;

namespace Envision.NET.Forms.ResultEntry
{
    public partial class frmPopupQuicktext : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmPopupQuicktext()
        {
            InitializeComponent();
        }
        public string Quicktext { get; set; }
        public string Quicktag { get; set; }
        public int QuickID { get; set; }
        public int FilterModeId { get; set; }

        private GBLEnvVariable env;
        private MyMessageBox msg;
        private void frmPopupQuicktext_Load(object sender, EventArgs e)
        {
            txtText.Text = Quicktext;
            txtTag.Text = Quicktag;
            getQuicktextMode();
        }
        private void getQuicktextMode()
        {
            int _index = 0;
            FilterModeId = string.IsNullOrEmpty(FilterModeId.ToString()) ? 0 : FilterModeId;
            ProcessGetGBLQuicktext prc = new ProcessGetGBLQuicktext();
            DataSet ds = prc.GetQuickTextFilterMode();
            cmbFilterMode.Properties.Items.Clear();
            DevExpress.XtraEditors.Controls.ComboBoxItemCollection colls = cmbFilterMode.Properties.Items;
            try
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[i]["GEN_DTL_ID"]) == FilterModeId)
                        _index = i;
                    colls.Add(new Filter_QuickText(Convert.ToInt32(ds.Tables[0].Rows[i]["GEN_DTL_ID"])
                        , ds.Tables[0].Rows[i]["GEN_TEXT"].ToString()));
                }
            }
            finally
            {
            }
            cmbFilterMode.SelectedIndex = _index;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                msg = new MyMessageBox();
                Filter_QuickText quicktext = cmbFilterMode.SelectedItem as Filter_QuickText;
                if (string.IsNullOrEmpty(QuickID.ToString()) || QuickID == 0)
                {

                    if (msg.ShowAlert("UID4001",new GBLEnvVariable().CurrentLanguageID)== "2")
                    {
                        ProcessAddGBLQuicktext add = new ProcessAddGBLQuicktext();
                        add.GBL_QUICKTEXT.CREATED_BY = new GBLEnvVariable().UserID;
                        add.GBL_QUICKTEXT.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                        add.GBL_QUICKTEXT.ORG_ID = new GBLEnvVariable().OrgID;
                        add.GBL_QUICKTEXT.QUICK_TAG = txtTag.Text.Trim();
                        add.GBL_QUICKTEXT.QUICK_TEXT = txtText.Text.Trim() ;
                        add.GBL_QUICKTEXT.IS_GLOBAL = "N"; // Change to Filter mode
                        add.GBL_QUICKTEXT.FILTER_MODE = quicktext.get_filter_mode_id();
                        add.Invoke();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    if (msg.ShowAlert("UID4002",new GBLEnvVariable().CurrentLanguageID) == "2")
                    {
                        ProcessUpdateGBLQuicktext update = new ProcessUpdateGBLQuicktext();
                        update.GBL_QUICKTEXT.QUICKTEXT_ID = QuickID;
                        update.GBL_QUICKTEXT.QUICK_TEXT = txtText.Text.Trim();
                        update.GBL_QUICKTEXT.QUICK_TAG = txtTag.Text.Trim();
                        update.GBL_QUICKTEXT.LAST_MODIFIED_BY = new GBLEnvVariable().OrgID;
                        update.GBL_QUICKTEXT.IS_GLOBAL =  "N";
                        update.GBL_QUICKTEXT.FILTER_MODE = quicktext.get_filter_mode_id();
                        update.Invoke();
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.Cancel;
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}