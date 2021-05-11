using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.BusinessLogic;

namespace RIS.Forms.Admin
{
    public partial class QAReason : Form
    {
        DataTable dtWL = new DataTable();

        UUL.ControlFrame.Controls.TabControl clsTab;
        RIS.Common.Common.GBLEnvVariable env = new RIS.Common.Common.GBLEnvVariable();
        RIS.Forms.GBLMessage.MyMessageBox mb = new RIS.Forms.GBLMessage.MyMessageBox();

        public QAReason(UUL.ControlFrame.Controls.TabControl Tab)
        {
            InitializeComponent();
            clsTab = Tab;
        }

        private void QAReason_Load(object sender, EventArgs e)
        {
            ClockTimer.Start();
            LoadTable();
            LoadGrid();
            EnableControl(false);
        }

        private void LoadTable()
        {
            ProcessGetRISQareason bg = new ProcessGetRISQareason();
            bg.Invoke();
            dtWL = bg.Result.Tables[0].Copy();
        }

        private void LoadGrid()
        {
            gridControl1.DataSource = dtWL.Copy();
            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                gridView1.Columns[i].Visible = false;
                gridView1.Columns[i].OptionsColumn.AllowEdit = false;
            }

            #region setColumn

            gridView1.Columns["REASON_UID"].Visible = true;
            gridView1.Columns["REASON_UID"].Caption = "Reason Code";
            gridView1.Columns["REASON_UID"].VisibleIndex = 1;
            gridView1.Columns["REASON_UID"].Width = 100;

            gridView1.Columns["REASON_TEXT"].Visible = true;
            gridView1.Columns["REASON_TEXT"].Caption = "Reason Text";
            gridView1.Columns["REASON_TEXT"].VisibleIndex = 2;
            gridView1.Columns["REASON_TEXT"].Width = 100;

            gridView1.Columns["REASON_ACTION"].Visible = true;
            gridView1.Columns["REASON_ACTION"].Caption = "Reason Action";
            gridView1.Columns["REASON_ACTION"].VisibleIndex = 3;
            gridView1.Columns["REASON_ACTION"].Width = 150;

            gridView1.Columns["CREATED_ON"].Visible = true;
            gridView1.Columns["CREATED_ON"].Caption = "Created on";
            gridView1.Columns["CREATED_ON"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["CREATED_ON"].DisplayFormat.FormatString = "g";
            gridView1.Columns["CREATED_ON"].VisibleIndex = 4;
            gridView1.Columns["CREATED_ON"].Width = 100;

            #endregion setColumn
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle > -1)
            {
                LoadText();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.FocusedRowHandle > -1)
            {
                LoadText();
            }
        }

        private void LoadText()
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtReasonUid.Tag = dr["REASON_ID"].ToString();
            txtReasonUid.Text = dr["REASON_UID"].ToString();
            txtReasonText.Text = dr["REASON_TEXT"].ToString();
            txtReasonAction.Text = dr["REASON_ACTION"].ToString();
            txtCreateOn.Text = dr["CREATED_ON"].ToString();
            ClockTimer.Stop();
        }

        private void ClearText()
        {
            txtReasonUid.Tag = null;
            txtReasonUid.Text = "";
            txtReasonText.Text = "";
            txtReasonAction.Text = "";
            txtCreateOn.DateTime = DateTime.Now;
            ClockTimer.Start();
        }

        private void RefreshForm()
        {
            ClearText();
            LoadTable();
            LoadGrid();

            EnableControl(false);

            btnAdd.Visible = true;
            btnEdit.Visible = true;
            btnDelete.Visible = true;
            btnCancel.Visible = false;

            btnAdd.Text = "Add";
            btnEdit.Text = "Edit";
            btnDelete.Text = "Delete";
            btnCancel.Text = "Cancel";

            gridView1.FocusedRowHandle = -1;
            gridView1.FocusedRowHandle = 0;
        }

        private void EnableControl(bool flag)
        {
            txtReasonUid.Enabled = flag;
            txtReasonText.Enabled = flag;
            txtReasonAction.Enabled = flag;
            gridControl1.Enabled = !flag;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Add")
            {
                EnableControl(true);
                ClearText();

                btnAdd.Visible = true;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                btnCancel.Visible = true;

                layoutControlGroup2.Expanded = true;

                btnAdd.Text = "Save";
            }
            else
            {
                string str = mb.ShowAlert("UID1019", env.CurrentLanguageID);
                if (str == "2")
                {
                    ProcessAddRISQareason ba = new ProcessAddRISQareason();
                    ba.RISQareason.REASON_UID = txtReasonUid.Text;
                    ba.RISQareason.REASON_TEXT = txtReasonText.Text;
                    ba.RISQareason.REASON_ACTION = txtReasonAction.Text;
                    ba.RISQareason.ORG_ID = env.OrgID;
                    ba.RISQareason.CREATED_BY = env.UserID;
                    ba.Invoke();

                    RefreshForm();

                    btnAdd.Text = "Add";
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtReasonUid.Tag == null) return;

            if (btnEdit.Text == "Edit")
            {
                EnableControl(true);

                btnAdd.Visible = false;
                btnEdit.Visible = true;
                btnDelete.Visible = false;
                btnCancel.Visible = true;

                layoutControlGroup2.Expanded = true;

                btnEdit.Text = "Save";
            }
            else
            {
                string str = mb.ShowAlert("UID1020", env.CurrentLanguageID);
                if (str == "2")
                {
                    ProcessUpdateRISQareason bu = new ProcessUpdateRISQareason();
                    bu.RISQareason.REASON_ID = Convert.ToInt32(txtReasonUid.Tag);
                    bu.RISQareason.REASON_UID = txtReasonUid.Text;
                    bu.RISQareason.REASON_TEXT = txtReasonText.Text;
                    bu.RISQareason.REASON_ACTION = txtReasonAction.Text;
                    bu.RISQareason.ORG_ID = env.OrgID;
                    bu.RISQareason.LAST_MODIFIED_BY = env.UserID;
                    bu.Invoke();

                    RefreshForm();

                    btnEdit.Text = "Edit";
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtReasonUid.Tag != null)
            {
                string str = mb.ShowAlert("UID1025",env.CurrentLanguageID);
                if (str == "2")
                {
                    ProcessDeleteRISQareason bd = new ProcessDeleteRISQareason();
                    bd.RISQareason.REASON_ID = Convert.ToInt32(txtReasonUid.Tag);
                    bd.Invoke();

                    RefreshForm();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            int index = clsTab.SelectedIndex;
            clsTab.TabPages.RemoveAt(index);
        }

        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            txtCreateOn.DateTime = DateTime.Now;
        }
    }
}