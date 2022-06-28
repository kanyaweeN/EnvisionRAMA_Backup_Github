using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevExpress.Utils;
using Envision.Common;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic.ProcessRead;

namespace Envision.NET.Forms.Schedule
{
    public partial class frmScheduleReason : Envision.NET.Forms.Main.MasterForm  //Form
    {
        private MyMessageBox msg = new MyMessageBox();
        private GBLEnvVariable env = new GBLEnvVariable();
        private DataTable dtShow;
        public frmScheduleReason()
        {
            InitializeComponent();
            dteFromdate.DateTime = DateTime.Now;
            dteTodate.DateTime = DateTime.Now;
        }

        private void frmScheduleReason_Load(object sender, EventArgs e)
        {
            env.ErrorForm = base.Menu_Name_Class;
            rdgMode.SelectedIndex = 0;
            visibleControls();
            dtShow =  SelectDatasource(dteFromdate.DateTime, dteTodate.DateTime, "D");
            grdData.DataSource = dtShow;
            SetColumnsGrid();
            base.CloseWaitDialog();
        }
        private void visibleControls()
        {
            txtHN.Visible = false;
            dteFromdate.Visible = false;
            dteTodate.Visible = false;
            lblTo.Visible = false;
            switch (rdgMode.SelectedIndex)
            {
                case 0:
                    dteFromdate.Visible = true;
                    dteTodate.Visible = true;
                    lblTo.Visible = true;
                    break;
                case 1:
                    txtHN.Visible = true;
                    break;
            }
        }
        private DataTable SelectDatasource(DateTime dF,DateTime dT,string status)
        {
       
            DateTime tFrom = new DateTime(dF.Year, dF.Month, dF.Day, 0, 0, 0);
            DateTime tTodate = new DateTime(dT.Year, dT.Month, dT.Day, 23, 59, 59);

            ProcessGetRISScheduleReason geReason = new ProcessGetRISScheduleReason();
            geReason.RIS_SCHEDULE_LOG.MODE = rdgMode.SelectedIndex == 1 ? "HN" : "DATE";
            geReason.RIS_SCHEDULE_LOG.FROMDATE = tFrom;
            geReason.RIS_SCHEDULE_LOG.TODATE = tTodate;
            geReason.RIS_SCHEDULE_LOG.STATUS = Convert.ToChar(status);
            geReason.RIS_SCHEDULE_LOG.HN = txtHN.Text.Trim();
            geReason.Invoke();

            dtShow = geReason.Result.Tables[0];
            return dtShow;
        }
        private void SetColumnsGrid()
        {
            View1.OptionsSelection.EnableAppearanceFocusedRow = false;
            View1.OptionsBehavior.Editable = false;

            for (int i = 0; i < View1.Columns.Count; i++)
            {
                View1.Columns[i].Visible = false;
            }

            //View1.Columns["SCHEDULE_ID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            //View1.Columns["SCHEDULE_ID"].Visible = false;
            //View1.Columns["SCHEDULE_ID"].Caption = "SCHEDULE_ID";
            //View1.Columns["SCHEDULE_ID"].OptionsColumn.ReadOnly = true;

            //View1.Columns["HN"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            //View1.Columns["HN"].Visible = true;
            //View1.Columns["HN"].Caption = "HN";
            //View1.Columns["HN"].OptionsColumn.ReadOnly = true;

            //View1.Columns["START_DATETIME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            //View1.Columns["START_DATETIME"].Visible = true;
            //View1.Columns["START_DATETIME"].Caption = "SCHEDULE DATE";
            //View1.Columns["START_DATETIME"].OptionsColumn.ReadOnly = true;

            //View1.Columns["STATUS"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            //View1.Columns["STATUS"].Visible = true;
            //View1.Columns["STATUS"].Caption = "STATUS";
            //View1.Columns["STATUS"].OptionsColumn.ReadOnly = true;

            //View1.Columns["REASON"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            //View1.Columns["REASON"].Visible = true;
            //View1.Columns["REASON"].Caption = "REASON";
            //View1.Columns["REASON"].OptionsColumn.ReadOnly = true;

            //View1.Columns["LAST_MODIFIED_ON"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            //View1.Columns["LAST_MODIFIED_ON"].Visible = true;
            //View1.Columns["LAST_MODIFIED_ON"].Caption = "UPDATE DATE";
            //View1.Columns["LAST_MODIFIED_ON"].OptionsColumn.ReadOnly = true;

            //View1.Columns["USER_NAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            //View1.Columns["USER_NAME"].Visible = true;
            //View1.Columns["USER_NAME"].Caption = "USERNAME";
            //View1.Columns["USER_NAME"].OptionsColumn.ReadOnly = true;

            //View1.Columns["FULLNAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            //View1.Columns["FULLNAME"].Visible = true;
            //View1.Columns["FULLNAME"].Caption = "UPDATE BY";
            //View1.Columns["FULLNAME"].OptionsColumn.ReadOnly = true;

            //View1.Columns["MODALITY"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            //View1.Columns["MODALITY"].Visible = true;
            //View1.Columns["MODALITY"].Caption = "MODALITY";
            //View1.Columns["MODALITY"].OptionsColumn.ReadOnly = true;

            //View1.Columns["EXAM"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            //View1.Columns["EXAM"].Visible = true;
            //View1.Columns["EXAM"].Caption = "EXAM";
            //View1.Columns["EXAM"].OptionsColumn.ReadOnly = true;

            View1.Columns["SCHEDULE_ID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            View1.Columns["SCHEDULE_ID"].Visible = false;
            View1.Columns["SCHEDULE_ID"].Caption = "Schedule ID";
            View1.Columns["SCHEDULE_ID"].OptionsColumn.ReadOnly = true;

            View1.Columns["HN"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            View1.Columns["HN"].Visible = true;
            View1.Columns["HN"].Caption = "HN";
            View1.Columns["HN"].OptionsColumn.ReadOnly = true;

            View1.Columns["START_DATETIME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            View1.Columns["START_DATETIME"].Visible = true;
            View1.Columns["START_DATETIME"].Caption = "Schedule Date";
            View1.Columns["START_DATETIME"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            View1.Columns["START_DATETIME"].OptionsColumn.ReadOnly = true;

            View1.Columns["STATUS"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            View1.Columns["STATUS"].Visible = true;
            View1.Columns["STATUS"].Caption = "Status";
            View1.Columns["STATUS"].OptionsColumn.ReadOnly = true;

            View1.Columns["REASON"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            View1.Columns["REASON"].Visible = true;
            View1.Columns["REASON"].Caption = "Reason";
            View1.Columns["REASON"].OptionsColumn.ReadOnly = true;

            View1.Columns["LAST_MODIFIED_ON"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            View1.Columns["LAST_MODIFIED_ON"].Visible = true;
            View1.Columns["LAST_MODIFIED_ON"].Caption = "Update Date";
            View1.Columns["LAST_MODIFIED_ON"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            View1.Columns["LAST_MODIFIED_ON"].OptionsColumn.ReadOnly = true;

            View1.Columns["USER_NAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            View1.Columns["USER_NAME"].Visible = true;
            View1.Columns["USER_NAME"].Caption = "User Name";
            View1.Columns["USER_NAME"].OptionsColumn.ReadOnly = true;

            View1.Columns["FULLNAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            View1.Columns["FULLNAME"].Visible = true;
            View1.Columns["FULLNAME"].Caption = "Update By";
            View1.Columns["FULLNAME"].OptionsColumn.ReadOnly = true;

            View1.Columns["MODALITY"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            View1.Columns["MODALITY"].Visible = true;
            View1.Columns["MODALITY"].Caption = "Modality Name";
            View1.Columns["MODALITY"].OptionsColumn.ReadOnly = true;

            View1.Columns["EXAM"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            View1.Columns["EXAM"].Visible = true;
            View1.Columns["EXAM"].Caption = "Exam Name";
            View1.Columns["EXAM"].OptionsColumn.ReadOnly = true;
        }
        private void barClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barHome_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ((Envision.NET.Forms.Main.frmMain)this.MdiParent).DisplayHome();
           
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchData();
        }
        private void searchData()
        {
            Size s = new Size(250, 50);
            DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Loading Data", s);
            
            switch (radioGroup1.SelectedIndex)
            {
                case 0: dtShow = SelectDatasource(dteFromdate.DateTime, dteTodate.DateTime, "D"); break;
                case 1: dtShow = SelectDatasource(dteFromdate.DateTime, dteTodate.DateTime, "U"); break;
                default: dtShow = SelectDatasource(dteFromdate.DateTime, dteTodate.DateTime, "A"); break;
            }
            grdData.DataSource = dtShow;

            dlg.Close();
        }
        private void rdgMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            visibleControls();
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchData();
        }

        private void txtHN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                searchData();
        }

    }
}