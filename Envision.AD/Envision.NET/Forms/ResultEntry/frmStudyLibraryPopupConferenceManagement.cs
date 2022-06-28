using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Envision.BusinessLogic;
using DevExpress.XtraEditors.Controls;
using Envision.BusinessLogic.ProcessRead;
using Envision.Common;
using DevExpress.XtraEditors.Repository;
using Envision.NET.Forms.Dialog;
using Envision.Common.Common;

namespace Envision.NET.Forms.ResultEntry
{
    public partial class frmStudyLibraryPopupConferenceManagement : DevExpress.XtraEditors.XtraForm
    {
        public DataTable dataDelete { get; set; }
        public DataTable dataAdd { get; set; }
        private GBLEnvVariable env = new GBLEnvVariable(); 
        private string Accession_NO;
        private DataTable dtData;


        public frmStudyLibraryPopupConferenceManagement()
        {
            InitializeComponent();
        }
        public frmStudyLibraryPopupConferenceManagement(string accession_no)
        {
            InitializeComponent();
            dataDelete = new DataTable();
            dataAdd = new DataTable();

            Accession_NO = accession_no;
        }
        private void frmStudyLibraryPopupConferenceManagement_Load(object sender, EventArgs e)
        {
            dtData = new DataTable();
            dateConference.DateTime = DateTime.Now;
            getConferenceData();
            getGridData();
            setGridColumns();
        }

        private void getConferenceData()
        {
            LookUpSelect lks = new LookUpSelect();
            DataTable dt = lks.SelectRadStudyManagementConference().Tables[0];
            cmbConferenceData.Properties.Items.Clear();
            ComboBoxItemCollection colls = cmbConferenceData.Properties.Items;
            colls.BeginUpdate();
            try
            {
                foreach (DataRow dr in dt.Rows)
                    colls.Add(new Filter_Conferene_Mode(Convert.ToInt32(dr["CONFERENCE_ID"]), dr["CONFERENCE_TEXT"].ToString()));
            }
            finally
            {
                colls.EndUpdate();
            }
            cmbConferenceData.SelectedIndex = 0;
        }
        private void getGridData()
        {
            ProcessGetRISStudyLibrary conference = new ProcessGetRISStudyLibrary();
            conference.RIS_STUDYLIBRARY.ACCESSION_NO = Accession_NO;
            conference.RIS_STUDYLIBRARY.RADIOLOGIST_ID = env.UserID;
            DataTable dt = conference.GetDataConference();
            dt.Columns.Add("Del");
            dt.AcceptChanges();
            dtData = dt;
            grdData.DataSource = dtData;

            dataAdd = dt.Clone();
            dataDelete = dt.Clone();
        }
        private void setGridColumns()
        {
            for (int i = 0; i < viewData.Columns.Count; i++)
                viewData.Columns[i].Visible = false;

            viewData.Columns["CONFERENCE_TEXT"].Caption = "Conference";
            viewData.Columns["CONFERENCE_TEXT"].Visible = true;
            viewData.Columns["CONFERENCE_TEXT"].OptionsColumn.ReadOnly = true;
            viewData.Columns["CONFERENCE_TEXT"].OptionsColumn.AllowEdit = false;
            viewData.Columns["CONFERENCE_TEXT"].OptionsColumn.AllowFocus = false;
            viewData.Columns["CONFERENCE_TEXT"].ColVIndex = 1;

            viewData.Columns["CONFERENCE_DATE"].Caption = "Date";
            viewData.Columns["CONFERENCE_DATE"].DisplayFormat.FormatString = "dd/MM/yyyy";
            viewData.Columns["CONFERENCE_DATE"].Visible = true;
            viewData.Columns["CONFERENCE_DATE"].OptionsColumn.ReadOnly = true;
            viewData.Columns["CONFERENCE_DATE"].OptionsColumn.AllowEdit = false;
            viewData.Columns["CONFERENCE_DATE"].OptionsColumn.AllowFocus = false;
            viewData.Columns["CONFERENCE_DATE"].ColVIndex = 2;

            RepositoryItemButtonEdit btn = new RepositoryItemButtonEdit();
            btn.AutoHeight = false;
            btn.BestFitWidth = 9;
            btn.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            btn.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete;
            btn.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btn.Buttons[0].Caption = string.Empty;
            btn.Click += new EventHandler(btn_Click);
            viewData.Columns["Del"].Caption = string.Empty;
            viewData.Columns["Del"].ColumnEdit = btn;
            viewData.Columns["Del"].ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            viewData.Columns["Del"].Width = 10;
            viewData.Columns["Del"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewData.Columns["Del"].Visible = true;
            viewData.Columns["Del"].ColVIndex = 3;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (viewData.FocusedRowHandle >= 0)
            {
                DataRow row = viewData.GetDataRow(viewData.FocusedRowHandle);
                if (!string.IsNullOrEmpty(row["LIBRARY_CONFERENCE_ID"].ToString()))
                    dataDelete.Rows.Add(row.ItemArray);

                dtData.Rows.Remove(row);
                dtData.AcceptChanges();
                dataDelete.AcceptChanges();
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Filter_Conferene_Mode _conference = cmbConferenceData.SelectedItem as Filter_Conferene_Mode;
            DataRow dr = dtData.NewRow();
            dr["CONFERENCE_ID"] = _conference.id();
            dr["CONFERENCE_TEXT"] = _conference.ToString();
            dr["CONFERENCE_DATE"] = dateConference.DateTime;
            dtData.Rows.Add(dr);
            dtData.AcceptChanges();

        }

        private void frmStudyLibraryPopupConferenceManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            dataAdd = dtData.Copy();
        }
    }
}