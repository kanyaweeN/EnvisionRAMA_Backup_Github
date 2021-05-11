using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.Common;
using Envision.NET.Forms.Dialog;

using DevExpress.Data.Filtering;
using DevExpress.XtraGrid.Columns;
using Envision.Common.Common;
using DevExpress.XtraEditors.Controls;


namespace Envision.NET.Forms.ResultEntry.ResultDialog
{
    public partial class dlgSeverity : DevExpress.XtraBars.Ribbon.RibbonForm//  Form
    {
        private MyMessageBox msg = new MyMessageBox();
        private int _unit_id = 0;
        private string _accession_no = "";
        private int _SeverityId = -1;
        private DateTime _VerbalDatetime = DateTime.MinValue;
        private int _VerbalWith = 0;
        private string _VerbalWith_Name = "";
        private int _VerbalTime = 0;
        private bool _IS_CliticalFinding = false;
        public int SeverityId
        {
            get
            {
                return this._SeverityId;
            }
        }
        public DateTime VerbalDatetime
        {
            get
            {
                return this._VerbalDatetime;
            }
        }
        public int VerbalWith
        {
            get
            {
                return this._VerbalWith;
            }
        }
        public string VerbalWith_Name
        {
            get
            {
                return this._VerbalWith_Name;
            }
        }
        public bool IS_CliticalFinding
        {
            get
            {
                return this._IS_CliticalFinding;
            }
        }
        public int VerbalTime
        {
            get
            {
                return this._VerbalTime;
            }
        }
        public dlgSeverity(int unit_id, string accession_no)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.No;
            _accession_no = accession_no;
            _unit_id = unit_id;
        }
        private void LookupData_Load(object sender, EventArgs e)
        {
            chkActiveDiscussion.Checked = false;
            chkActiveDiscussion.Text = "Enable Discussion";
            panelDiscussion.Enabled = false;

            LoadData();
        }
        private void LoadData()
        {
            ProcessGetRISExamresultseverity prc = new ProcessGetRISExamresultseverity();
            prc.RIS_EXAMRESULTSEVERITY.UNIT_ID = _unit_id;
            prc.Invoke();
            grdSeverity.DataSource = prc.Result.Tables[0].Copy();

            gvSeverity.OptionsBehavior.Editable = false;
            gvSeverity.OptionsView.ShowGroupPanel = false;
            gvSeverity.OptionsView.ShowBands = false;
            gvSeverity.OptionsView.ColumnAutoWidth = true;
            gvSeverity.OptionsView.ShowAutoFilterRow = false;

            gvSeverity.OptionsSelection.EnableAppearanceFocusedRow = true;
            gvSeverity.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvSeverity.OptionsSelection.InvertSelection = false;
            gvSeverity.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;

            prc.GetSeverityLOG(_accession_no);
            grdPrevious.DataSource = prc.Result.Tables[0].Copy();
            columnsSeveritiyLog();

            gvPrevious.OptionsBehavior.Editable = false;
            gvPrevious.OptionsView.ShowGroupPanel = false;
            gvPrevious.OptionsView.ColumnAutoWidth = false;
            gvPrevious.OptionsView.ShowAutoFilterRow = false;

            gvPrevious.OptionsSelection.EnableAppearanceFocusedRow = true;
            gvPrevious.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvPrevious.OptionsSelection.InvertSelection = false;
            gvPrevious.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;

        }
        private void columnsSeveritiyLog()
        {
            for (int i = 0; i < gvPrevious.Columns.Count; i++)
            {
                gvPrevious.Columns[i].Visible = false;
                gvPrevious.Columns[i].OptionsColumn.AllowEdit = false;
                gvPrevious.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }



            gvPrevious.Columns["SEVERITY_NAME"].Caption = "Severity";
            gvPrevious.Columns["VERBAL_DATETIME"].Caption = "Discussion Datetime";
            gvPrevious.Columns["VERBAL_TIME"].Caption = "time(Min.)";
            gvPrevious.Columns["VERBAL_WITH"].Caption = "Physician Name";
            gvPrevious.Columns["CREATED_ON"].Caption = "Created Datetime";

            gvPrevious.Columns["SEVERITY_NAME"].Visible = true;
            gvPrevious.Columns["VERBAL_DATETIME"].Visible = true;
            gvPrevious.Columns["VERBAL_TIME"].Visible = true;
            gvPrevious.Columns["VERBAL_WITH"].Visible = true;
            gvPrevious.Columns["CREATED_ON"].Visible = true;

            gvPrevious.Columns["SEVERITY_NAME"].VisibleIndex = 1;
            gvPrevious.Columns["VERBAL_DATETIME"].VisibleIndex = 2;
            gvPrevious.Columns["VERBAL_TIME"].VisibleIndex = 3;
            gvPrevious.Columns["VERBAL_WITH"].VisibleIndex = 4;
            gvPrevious.Columns["CREATED_ON"].VisibleIndex = 5;

            gvPrevious.Columns["SEVERITY_NAME"].Width = 100;
            gvPrevious.Columns["VERBAL_DATETIME"].Width = 125;
            gvPrevious.Columns["VERBAL_TIME"].Width = 70;
            gvPrevious.Columns["VERBAL_WITH"].Width = 110;
            gvPrevious.Columns["CREATED_ON"].Width = 100;

            gvPrevious.Columns["VERBAL_DATETIME"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            gvPrevious.Columns["CREATED_ON"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
        }

        private void btnOKN_Click(object sender, EventArgs e)
        {
            if (chkActiveDiscussion.Checked)
            {
                bool flag = false;
                if (string.IsNullOrEmpty(dtEdit.Text))
                    flag = true;
                if (string.IsNullOrEmpty(txtDoctor.Text))
                    flag = true;

                if (flag)
                {
                    msg.ShowAlert("UID4049", new GBLEnvVariable().CurrentLanguageID);
                    return;
                }
                else
                {
                    _VerbalDatetime = dtEdit.DateTime;
                    _VerbalTime = Convert.ToInt32(speTime.Value);
                    _VerbalWith = txtDoctor.Tag == null ? 0 : Convert.ToInt32(txtDoctor.Tag);
                    _VerbalWith_Name = txtDoctor.Text;
                }
            }
            DataRow dr = gvSeverity.GetDataRow(gvSeverity.FocusedRowHandle);
            this._SeverityId = Convert.ToInt32(dr["SEVERITY_ID"].ToString());
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnCloseN_Click(object sender, EventArgs e)
        {
            this._SeverityId = -1;
            this._VerbalDatetime = DateTime.MinValue;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void chkActiveDiscussion_CheckedChanged(object sender, EventArgs e)
        {
            //DataRow dr = gvSeverity.GetDataRow(gvSeverity.FocusedRowHandle);
            //if (dr["IS_CRITICAL"].ToString() == "Y")
            //    chkActiveDiscussion.Checked = true;
            if (chkActiveDiscussion.Checked)
            {
                dtEdit.DateTime = DateTime.Now;
                chkActiveDiscussion.Text = "Disable Discussion";
                panelDiscussion.Enabled = true;
                this._IS_CliticalFinding = true;
            }
            else
            {
                chkActiveDiscussion.Text = "Enable Discussion";
                panelDiscussion.Enabled = false;
                this._IS_CliticalFinding = false;
            }
        }
        private void gvSeverity_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gvSeverity.FocusedRowHandle >= 0)
            {
                DevExpress.XtraLayout.Utils.LayoutVisibility PreviousCritical = loCritical.Visibility;
                DataRow dr = gvSeverity.GetDataRow(gvSeverity.FocusedRowHandle);
                dtEdit.DateTime = DateTime.Now;
                //if (dr["IS_CRITICAL"].ToString() == "Y")
                //{
                //    chkActiveDiscussion.Checked = true;
                //}
                //else
                //{
                //    chkActiveDiscussion.Checked = false;
                //}

            }
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            Envision.NET.Forms.Dialog.LookupData lv = new Envision.NET.Forms.Dialog.LookupData();
            lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(find_Doctor);
            lv.AddColumn("EMP_ID", "Doctor ID", false, true);
            lv.AddColumn("EMP_UID", "Doctor Code", true, true);
            lv.AddColumn("RadioName", "Doctor Name", true, true);
            lv.Text = "Search";

            lv.Data = RISBaseData.His_Doctor();
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void find_Doctor(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtDoctor.Tag = retValue[0];
            txtDoctor.Text = retValue[2];
        }


    }

}
