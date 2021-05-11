using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraGrid.Columns;
using Envision.Common;
using Envision.BusinessLogic.ProcessRead;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic.ProcessCreate;

namespace Envision.NET.Forms.ResultEntry
{
    public partial class Transfer : DevExpress.XtraBars.Ribbon.RibbonForm//Form
    {
        private GBLEnvVariable env;
        private DataTable dttData;
        private DataTable dtSource;
        public Transfer()
        {
            InitializeComponent();
            env = new GBLEnvVariable();
            LoadData("");
        }
        public Transfer(string AccessionNumber)
        {
            InitializeComponent();
            env = new GBLEnvVariable();
            LoadData("'"+AccessionNumber+"'");
        }
        public Transfer(DataTable dt)
        {
            //dt = 1 column (accession_no)
            InitializeComponent();
            env = new GBLEnvVariable();
            dtSource = dt;

            string strAccession = "''";
            foreach (DataRow rowSource in dtSource.Rows)
                strAccession += ",'" + rowSource["ACCESSION_NO"].ToString() + "'";

            LoadData(strAccession);
        }
        private void LoadData(string strAccession)
        {
            dttData = new DataTable();
            Envision.BusinessLogic.ResultEntry proGet = new Envision.BusinessLogic.ResultEntry();
            proGet.RISExamresult.EMP_ID = new GBLEnvVariable().UserID;
            dttData = proGet.GetTransfer(strAccession).Copy();

            gridControl1.DataSource = dttData;

            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                gridView1.Columns[i].OptionsColumn.AllowEdit = false;
                gridView1.Columns[i].Visible = false;
            }

            //Set LookupGridView
            DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View
                = new DevExpress.XtraGrid.Views.Grid.GridView();
            repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            repositoryItemGridLookUpEdit1View.OptionsView.ShowFooter = true;
            repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;

            //Set LookupGridControl
            DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1
                = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            repositoryItemGridLookUpEdit1.AutoHeight = false;
            //repositoryItemGridLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            //new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            repositoryItemGridLookUpEdit1.DataSource = proGet.GetTransferRadiologist();
            repositoryItemGridLookUpEdit1.DisplayMember = "Radiologist Name";
            //repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
            repositoryItemGridLookUpEdit1.PopupFormWidth = 250;
            //repositoryItemGridLookUpEdit1.ServerMode = true;
            repositoryItemGridLookUpEdit1.ValueMember = "EMP_ID";
            repositoryItemGridLookUpEdit1.View = repositoryItemGridLookUpEdit1View;
            repositoryItemGridLookUpEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repositoryItemGridLookUpEdit1.NullText = "";
            repositoryItemGridLookUpEdit1.View.OptionsView.ShowAutoFilterRow = true;

            //repositoryItemGridLookUpEdit1View.Columns["EMP_ID"].Visible = false;
            //repositoryItemGridLookUpEdit1View.BestFitColumns();

            gridView1.Columns["Status"].Visible = true;
            gridView1.Columns["Accession No"].Visible = true;
            gridView1.Columns["HN"].Visible = true;
            gridView1.Columns["Patient Name"].Visible = true;
            gridView1.Columns["Exam Code"].Visible = true;
            gridView1.Columns["Exam Name"].Visible = true;
            gridView1.Columns["Transfer To"].Visible = true;

            gridView1.Columns["Status"].Width = 100;
            gridView1.Columns["Accession No"].Width = 100;
            gridView1.Columns["HN"].Width = 100;
            gridView1.Columns["Patient Name"].Width = 100;
            gridView1.Columns["Exam Code"].Width = 100;
            gridView1.Columns["Exam Name"].Width = 100;
            gridView1.Columns["Transfer To"].Width = 135;

            gridView1.Columns["Transfer To"].Caption = "Transfer To";
            gridView1.Columns["Transfer To"].OptionsColumn.AllowEdit = true;
            gridView1.Columns["Transfer To"].OptionsColumn.FixedWidth = true;
            gridView1.Columns["Transfer To"].ColumnEdit = repositoryItemGridLookUpEdit1;

            SetStyleFormatCondition();
            //gridView1.BestFitColumns();

            ProcessGetRISExamtransferlog getlog = new ProcessGetRISExamtransferlog(env.UserID);
            getlog.Invoke();
            grdLog.DataSource = getlog.Result.Tables[0];
        }
        private void SetStyleFormatCondition()
        {
            //Alive
            DevExpress.XtraGrid.StyleFormatCondition stylCon1
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView1.Columns["Status"], null, "New");
            stylCon1.Appearance.ForeColor = Color.Red;

            //Complete
            DevExpress.XtraGrid.StyleFormatCondition stylCon2
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView1.Columns["Status"], null, "Complete");
            stylCon2.Appearance.ForeColor = Color.Red;

            //Prelim
            DevExpress.XtraGrid.StyleFormatCondition stylCon3
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView1.Columns["Status"], null, "Prelim");
            stylCon3.Appearance.ForeColor = Color.Goldenrod;

            //Draft
            DevExpress.XtraGrid.StyleFormatCondition stylCon4
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView1.Columns["Status"], null, "Draft");
            stylCon4.Appearance.ForeColor = Color.Goldenrod;

            //Finalize
            DevExpress.XtraGrid.StyleFormatCondition stylCon5
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView1.Columns["Status"], null, "Finalize");
            stylCon5.Appearance.ForeColor = Color.Green;

            gridView1.FormatConditions.Clear();
            gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] { stylCon1, stylCon2, stylCon3, stylCon4, stylCon5 });
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            DataTable table = (DataTable)gridControl1.DataSource;
            MyMessageBox mmb = new MyMessageBox();
            bool flag = true;
            foreach(DataRow dr in table.Rows)
                if (dr["Transfer To"].ToString() != "") {
                    flag = false;
                    break;
                }
            if (flag) {
                mmb.ShowAlert("UID018", env.CurrentLanguageID);
                return;
            }
            
            if (mmb.ShowAlert("UID1020", env.CurrentLanguageID) == "2")
            {
                foreach (DataRow row in table.Rows)
                {
                    if (row["Transfer To"].ToString() != "")
                    {
                        Envision.BusinessLogic.ResultEntry proGet = new Envision.BusinessLogic.ResultEntry();
                        proGet.RISExamresult.ORDER_ID = Convert.ToInt32(row["Order No"]);
                        proGet.RISExamresult.EXAM_ID = Convert.ToInt32(row["EXAM_ID"]);
                        proGet.RISExamresult.EMP_ID = Convert.ToInt32(row["Transfer To"]);

                        proGet.UpdateTransfer();

                        ProcessAddRISExamtransferlog prc = new ProcessAddRISExamtransferlog();
                        prc.RIS_EXAMTRANSFERLOG.ACCESSION_NO = row["Accession no"].ToString();
                        prc.RIS_EXAMTRANSFERLOG.FROM_RAD = env.UserID;
                        prc.RIS_EXAMTRANSFERLOG.TO_RAD = Convert.ToInt32(row["Transfer To"]);
                        prc.RIS_EXAMTRANSFERLOG.STATUS = Convert.ToChar("A");
                        prc.RIS_EXAMTRANSFERLOG.ORG_ID = env.OrgID;
                        prc.RIS_EXAMTRANSFERLOG.CREATED_BY = env.UserID;
                        prc.RIS_EXAMTRANSFERLOG.LAST_MODIFIED_BY = env.UserID;
                        prc.Invoke();

                       
                    }
                }
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
            
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void Transfer_Load(object sender, EventArgs e)
        {
          //  gridView1.Columns["Accession No"].FilterInfo = new ColumnFilterInfo(" OR Accession No = '20090422XA0023' OR Accession No = '20090511XA0001'");
        }
    }
}