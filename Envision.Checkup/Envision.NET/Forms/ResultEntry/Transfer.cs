using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.BusinessLogic;
using RIS.Common.Common;
using RIS.Forms.GBLMessage;
using DevExpress.XtraGrid.Columns;
namespace RIS.Forms.ResultEntry
{
    public partial class Transfer : Form
    {
        private GBLEnvVariable env;
        private string accNo;
        private DataTable dttData;

        public Transfer()
        {
            InitializeComponent();
            env = new GBLEnvVariable();
            accNo = string.Empty;
            LoadData();
        }
        public Transfer(string AccessionNumber)
        {
            InitializeComponent();
            env = new GBLEnvVariable();
            accNo = AccessionNumber;
            LoadData();
        }
        public Transfer(DataTable dt)
        {
            //dt = 1 column (accession_no)
            InitializeComponent();
            env = new GBLEnvVariable();
            accNo = string.Empty;
            LoadData();
//         
            StringBuilder sbSearch = new StringBuilder();
            sbSearch.Append("[Accession No] = ''");
            
            foreach (DataRow dr in dt.Rows)
            {

                sbSearch.Append(" OR [Accession No] = '" + dr["ACCESSION_NO"].ToString() + "'");
            }
           gridView1.Columns["Accession No"].FilterInfo = new ColumnFilterInfo(sbSearch.ToString(),"Filter");
        }
        private void LoadData()
        {
            RIS.BusinessLogic.ResultEntry proGet = new RIS.BusinessLogic.ResultEntry();
            proGet.RISExamresult.MODE = 1;
            proGet.RISExamresult.EMP_ID = new RIS.Common.Common.GBLEnvVariable().UserID;
            dttData = new DataTable();
            DataTable dtt = new DataTable();
            dtt=proGet.GetTransfer().Copy();
            if (!string.IsNullOrEmpty(accNo))
            {
                DataRow[] drs = dtt.Select("[Accession No]<>'" + accNo + "'");
                dttData = dtt.Clone();
                foreach (DataRow dr in drs) {
                    DataRow r = dttData.NewRow();
                    for (int i = 0; i < dtt.Columns.Count; i++)
                        r[i] = dr[i];
                    dttData.Rows.Add(r);
                }
                dttData.AcceptChanges();
            }
            else
                dttData = dtt.Copy();
            gridControl1.DataSource = dttData;

            int k = 0;
            while (k < gridView1.Columns.Count)
            {
                gridView1.Columns[k].OptionsColumn.AllowEdit = false;
                ++k;
            }
            gridView1.Columns["ASSIGNED_TO"].Visible = false;
            gridView1.Columns["EXAM_ID"].Visible = false;
            gridView1.Columns["Order No"].Visible = false;
            gridView1.Columns["Transfer To"].OptionsColumn.AllowEdit = true;
            gridView1.Columns["Transfer To"].Width = 200;
            gridView1.Columns["Transfer To"].OptionsColumn.FixedWidth = true;
           
            SetGridView();

            SetStyleFormatCondition();
            gridView1.BestFitColumns();

            ProcessGetRISExamtransferlog getlog = new ProcessGetRISExamtransferlog(env.UserID);
            getlog.Invoke();
            grdLog.DataSource = getlog.Result.Tables[0];
        }

        private void SetGridView()
        {
             
            RIS.BusinessLogic.ResultEntry proGet = new RIS.BusinessLogic.ResultEntry();
            proGet.RISExamresult.MODE = 2;
            proGet.RISExamresult.EMP_ID = new RIS.Common.Common.GBLEnvVariable().UserID;

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
            repositoryItemGridLookUpEdit1.DataSource = proGet.GetTransfer();
            repositoryItemGridLookUpEdit1.DisplayMember = "Radiologist Name";
            //repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
            repositoryItemGridLookUpEdit1.PopupFormWidth = 250;
            //repositoryItemGridLookUpEdit1.ServerMode = true;
            repositoryItemGridLookUpEdit1.ValueMember = "EMP_ID";
            repositoryItemGridLookUpEdit1.View = repositoryItemGridLookUpEdit1View;
            repositoryItemGridLookUpEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repositoryItemGridLookUpEdit1.NullText = "";
            repositoryItemGridLookUpEdit1.View.OptionsView.ShowAutoFilterRow = true;

            repositoryItemGridLookUpEdit1View.Columns["EMP_ID"].Visible = false;
            repositoryItemGridLookUpEdit1View.BestFitColumns();

            gridView1.Columns["Transfer To"].ColumnEdit = repositoryItemGridLookUpEdit1;
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
            RIS.Forms.GBLMessage.MyMessageBox mmb = new RIS.Forms.GBLMessage.MyMessageBox();
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
                        RIS.BusinessLogic.ResultEntry proGet = new RIS.BusinessLogic.ResultEntry();
                        proGet.RISExamresult.ORDER_ID = Convert.ToInt32(row["Order No"]);
                        proGet.RISExamresult.EXAM_ID = Convert.ToInt32(row["EXAM_ID"]);
                        proGet.RISExamresult.EMP_ID = Convert.ToInt32(row["Transfer To"]);

                        proGet.UpdateTransfer();

                        ProcessAddRISExamtransferlog prc = new ProcessAddRISExamtransferlog();
                        prc.RISExamtransferlog.ACCESSION_NO = row["Accession no"].ToString();
                        prc.RISExamtransferlog.FROM_RAD = env.UserID;
                        prc.RISExamtransferlog.TO_RAD = Convert.ToInt32(row["Transfer To"]);
                        prc.RISExamtransferlog.STATUS = "A";
                        prc.RISExamtransferlog.ORG_ID = env.OrgID;
                        prc.RISExamtransferlog.CREATED_BY = env.UserID;
                        prc.RISExamtransferlog.LAST_MODIFIED_BY = env.UserID;
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