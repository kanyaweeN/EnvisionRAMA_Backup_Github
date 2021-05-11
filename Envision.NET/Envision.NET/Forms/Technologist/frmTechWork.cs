using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.Common.DBConnection;
using DevExpress.XtraEditors.Repository;
using RIS.Common;
using RIS.BusinessLogic;
using RIS.Common.Common;
using RIS.Operational;
using RIS.Operational.HL7.OrderManagement;
using RIS.Operational.PACS;
using RIS.Operational.ReportManager;
using RIS.Forms.GBLMessage;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace RIS.Forms.Technologist
{
    public partial class frmTechWork : Form
    {
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        private DateTime dtStart, dtEnd;
        private int perform=0;
        private int take=0;
        private int status = 1;
        private string accessionNo=string.Empty;
        private MyMessageBox msg = new MyMessageBox();
        private GBLEnvVariable env = new GBLEnvVariable();
        private dbConnection dc = new dbConnection();
        private string mode = string.Empty;
        private DataView dv = new DataView();
        private DataTable dttExam = new DataTable();
        private bool group = false;

        public frmTechWork(UUL.ControlFrame.Controls.TabControl ctrl)
        {
            InitializeComponent();
            CloseControl = ctrl;
            setDataStatus();
            txtTake.ForeColor = Color.Black;
            txtPerformName.ForeColor = Color.Black;
        }
        public frmTechWork(UUL.ControlFrame.Controls.TabControl ctrl,DateTime DateStart,int Perform,int Take,int Status,string AccessionNo)
        {
            InitializeComponent();
            CloseControl = ctrl;
            dtStart = DateStart;
            perform = Perform;
            take = Take;
            status = Status;
            accessionNo = AccessionNo;
            InitControl();
            txtTake.ForeColor = Color.Black;
            txtPerformName.ForeColor = Color.Black;
            
        }
        public frmTechWork(UUL.ControlFrame.Controls.TabControl ctrl, DateTime DateStart, int Group_id, int Take, int Status, string AccessionNo,bool IsGroup)
        {
            InitializeComponent();
            CloseControl = ctrl;
            dtStart = DateStart;
            group = IsGroup;
            perform = Group_id;
            take = Take;
            status = Status;
            accessionNo = AccessionNo;
            InitControl();
            txtTake.ForeColor = Color.Black;
            txtPerformName.ForeColor = Color.Black;
        }

        private void InitControl() {
            txtTake.Text = take.ToString();
            if (group)
                getGroupName();
            else
                getPerformName();
            setDataStatus();
            getExamData();
            getTechWork();
        }
        private void getGroupName() { 
          


        }
        private void setDataStatus()
        {
           
            DataTable dttCon = new DataTable();
            dttCon.Columns.Add("ID", typeof(int));
            dttCon.Columns.Add("Name", typeof(string));

            DataRow dr = dttCon.NewRow();
            dr[0] = 0;
            dr[1] = "Waiting";
            dttCon.Rows.Add(dr);

            dr = dttCon.NewRow();
            dr[0] = 1;
            dr[1] = "Started";
            dttCon.Rows.Add(dr);

            dr = dttCon.NewRow();
            dr[0] = 2;
            dr[1] = "Complete";
            dttCon.Rows.Add(dr);

            dr = dttCon.NewRow();
            dr[0] = 3;
            dr[1] = "Discontinued";
            dttCon.Rows.Add(dr);

            dr = dttCon.NewRow();
            dr[0] = 4;
            dr[1] = "Canceled";
            dttCon.Rows.Add(dr);

            cboStatus.Items.Clear();
            cboStatus.ValueMember = "ID";
            cboStatus.DisplayMember = "Name";
            cboStatus.DataSource = dttCon;

            if (status == 1)
                cboStatus.SelectedIndex = 1;
            else if (status == 2)
                cboStatus.SelectedIndex = 2;
            else
                cboStatus.SelectedIndex = 0;
           
         }
        private void getExamData() {
            try
            {
                ProcessGetRISExam processExam = new ProcessGetRISExam();
                processExam.Invoke();
                dttExam = processExam.Result.Tables[0].Copy();
                dttExam.TableName = "RIS_EXAM";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void getPerformName(){
            try
            {
                string sql = "select * from HR_EMP where EMP_ID=" + perform;
                DataTable dt = new DataTable();
                dt = dc.SelectDs(sql);
                txtPerformName.Text = dt.Rows[0]["FNAME"].ToString() + " " + dt.Rows[0]["MNAME"].ToString() + dt.Rows[0]["LNAME"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void getTechWork() {
            try {
                int tmpTake = take > 1 ? take - 1 : take;
                ProcessGetRISTechworks process = new ProcessGetRISTechworks();
                process.RISTechworks.ACCESSION_ON = accessionNo;
                //process.RISTechworks.TAKE =(byte) take;
                process.RISTechworks.TAKE = (byte)tmpTake;
                process.Invoke();
                if(process.Result!=null)
                    if (process.Result.Tables.Count > 0)
                    {
                        if (process.Result.Tables[0].Rows.Count > 0)
                        {
                            txtKV.Text = process.Result.Tables[0].Rows[0]["KV"].ToString();
                            txtmA.Text = process.Result.Tables[0].Rows[0]["mA"].ToString();
                            txtSec.Text = process.Result.Tables[0].Rows[0]["SEC"].ToString();
                            txtExposure.Text = process.Result.Tables[0].Rows[0]["EXPOSURE_TECHNIQUE"].ToString();
                            txtNoOfImage.Text = process.Result.Tables[0].Rows[0]["NO_OF_IMAGES"].ToString().Trim() == string.Empty ? "0" : process.Result.Tables[0].Rows[0]["NO_OF_IMAGES"].ToString();
                            txtProtocol.Text = process.Result.Tables[0].Rows[0]["PROTOCOL"].ToString();
                            mode = "Edit";
                            getConsumable();
                            bindTechGrid();
                            return;
                        }
                    }
                 mode = "New";
                 getConsumable();
                 bindTechGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void getConsumable() {
            ProcessGetRISTechconsumption process = new ProcessGetRISTechconsumption();
            DataTable dtt = new DataTable();
            if (mode == "New") { 
                process.RISTechconsumption.ACCESSION_NO="fadel cheteng";
                process.RISTechconsumption.TAKE = 0;
                process.Invoke();
                dtt = process.Result.Tables[0].Copy();
                dtt.Columns.Add("Total", typeof(decimal));
                dtt.Columns.Add("colDelete", typeof(string));
            }
            else
            {
                process.RISTechconsumption.ACCESSION_NO = accessionNo;
                int tmpTake = take > 1 ? take - 1 : take;
                process.RISTechconsumption.TAKE = (byte)tmpTake;
                process.Invoke();
                dtt = process.Result.Tables[0].Copy();
                dtt.Columns.Add("Total", typeof(decimal));
                dtt.Columns.Add("colDelete", typeof(string));
                foreach (DataRow dr in dtt.Rows) {
                    for (int i = 0; i < dttExam.Rows.Count; i++) {
                        if (dr["EXAM_ID"].ToString().Trim() == dttExam.Rows[i]["EXAM_ID"].ToString().Trim())
                        {
                            dr["EXAM_NAME"] = dttExam.Rows[i]["EXAM_NAME"].ToString();
                            decimal qty = dr["QTY"].ToString().Trim() == string.Empty ? 0 : Convert.ToDecimal(dr["QTY"]);
                            decimal rate = dr["RATE"].ToString().Trim() == string.Empty ? 0 : Convert.ToDecimal(dr["RATE"]);
                            dr["Total"] = qty * rate;
                            break;
                        }
                    }
                }
            }
            dv = new DataView(dtt);
        }
        private void bindTechGrid() {
            DataTable dtt=dv.ToTable();
            DataRow dr = dtt.NewRow();
            dr["QTY"] = 1;
            dr["IS_DELETED"] = "N";
            dtt.Rows.Add(dr);
            dv = new DataView(dtt);
            grdConsumption.DataSource = dv;
            for (int i = 0; i < dtt.Columns.Count; i++)
                view1.Columns[i].Visible = false;

            view1.OptionsView.ShowBands = false;
            view1.OptionsSelection.EnableAppearanceFocusedCell = false;
            view1.OptionsSelection.EnableAppearanceFocusedRow = false;
            view1.OptionsView.ShowColumnHeaders = true;

            RepositoryItemLookUpEdit repositoryItemLookUpEdit1 = new RepositoryItemLookUpEdit();
            repositoryItemLookUpEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repositoryItemLookUpEdit1.ImmediatePopup = true;
            repositoryItemLookUpEdit1.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            repositoryItemLookUpEdit1.AutoHeight = false;
            repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EXAM_UID", "Exam Code", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            repositoryItemLookUpEdit1.DisplayMember = "EXAM_UID";
            repositoryItemLookUpEdit1.ValueMember = "EXAM_ID";
            repositoryItemLookUpEdit1.DropDownRows = 5;
            repositoryItemLookUpEdit1.DataSource = dttExam;
            repositoryItemLookUpEdit1.NullText = string.Empty;
            repositoryItemLookUpEdit1.KeyUp += new KeyEventHandler(examID_KeyUp);
            repositoryItemLookUpEdit1.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(examID_CloseUp);
            view1.Columns["EXAM_ID"].ColumnEdit = repositoryItemLookUpEdit1;
            view1.Columns["EXAM_ID"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            view1.Columns["EXAM_ID"].Visible = true;

            RepositoryItemLookUpEdit repositoryItemLookUpEdit2 = new RepositoryItemLookUpEdit();
            repositoryItemLookUpEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repositoryItemLookUpEdit2.ImmediatePopup = true;
            repositoryItemLookUpEdit2.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            repositoryItemLookUpEdit2.AutoHeight = false;
            repositoryItemLookUpEdit2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EXAM_NAME", "Exam Name", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            repositoryItemLookUpEdit2.DisplayMember = "EXAM_NAME";
            repositoryItemLookUpEdit2.ValueMember = "EXAM_NAME";
            repositoryItemLookUpEdit2.DropDownRows = 5;
            repositoryItemLookUpEdit2.DataSource = dttExam;
            repositoryItemLookUpEdit2.NullText = string.Empty;
            repositoryItemLookUpEdit2.KeyUp += new KeyEventHandler(examName_KeyUp);
            repositoryItemLookUpEdit2.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(examName_CloseUp);
            view1.Columns["EXAM_NAME"].ColumnEdit = repositoryItemLookUpEdit2;
            view1.Columns["EXAM_NAME"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            view1.Columns["EXAM_NAME"].Visible = true;

            RepositoryItemButtonEdit btn = new RepositoryItemButtonEdit();
            btn.AutoHeight = false;
            btn.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            btn.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete;
            btn.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btn.Buttons[0].Caption = string.Empty;
            btn.Click += new EventHandler(btnDeleteRow_Click);
            view1.Columns["colDelete"].Caption = string.Empty;
            view1.Columns["colDelete"].ColumnEdit = btn;
            view1.Columns["colDelete"].ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            view1.Columns["colDelete"].Width = 50;
            view1.Columns["colDelete"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

            RepositoryItemSpinEdit spin = new RepositoryItemSpinEdit();
            spin.KeyUp += new KeyEventHandler(qty_KeyUp);
            spin.ValueChanged += new EventHandler(qty_ValueChanged);
            spin.MinValue = 0.1M;
            spin.MaxValue = 999.99M;
            view1.Columns["QTY"].ColumnEdit = spin;


            view1.Columns["QTY"].Visible = true;
            view1.Columns["RATE"].Visible = true;
            view1.Columns["Total"].Visible = true;
            view1.Columns["colDelete"].Visible = true;

            view1.Columns["EXAM_ID"].Caption = "Cons UID";
            view1.Columns["EXAM_NAME"].Caption = "Consumable Name";
            view1.Columns["QTY"].Caption = "Qty";
            view1.Columns["RATE"].Caption = "Rate";
            view1.Columns["RATE"].OptionsColumn.ReadOnly = true;
            view1.Columns["RATE"].DisplayFormat.FormatString = "#,##0.00";
            view1.Columns["RATE"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            view1.Columns["Total"].Caption = "Total";
            view1.Columns["Total"].OptionsColumn.ReadOnly = true;
            view1.Columns["Total"].DisplayFormat.FormatString = "#,##0.00";
            view1.Columns["Total"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            view1.Columns["colDelete"].Caption = string.Empty;
            view1.BestFitColumns();
        }

        #region Grid Consumption 
        void qty_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                view1.FocusedColumn = view1.VisibleColumns[0];
                view1.MoveNext();
            }
        }
        void qty_ValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.SpinEdit spin = (DevExpress.XtraEditors.SpinEdit)sender;
            decimal val = spin.Value;
            if (spin.Value.ToString().Trim() == string.Empty) return;
            if (val < 0.1M)
            {
                val = 0.1M;
                return;
            }
            int row = view1.FocusedRowHandle;
            if (mode == "Edit")
            {
                // หา row จริง ๆ
            }
            DataView dv = (DataView)grdConsumption.DataSource;
            DataTable dtt = dv.Table;
            decimal qty = Convert.ToDecimal(spin.Value);
            decimal rate = dtt.Rows[row]["RATE"].ToString().Trim() == string.Empty ? 0 : Convert.ToDecimal(dtt.Rows[row]["RATE"]);
            dtt.Rows[row]["QTY"] = qty;
            dtt.Rows[row]["Total"] = qty * rate;
            view1.RefreshData();
        }

        void examID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.AcceptValue)
            {
                if (e.Value.ToString() != string.Empty)
                {
                    DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                    int row = view1.FocusedRowHandle;
                    DataView dv = (DataView)grdConsumption.DataSource;
                    DataTable dtt = dv.Table;
                    bool flag = false;
                    for(int i=0;i<dtt.Rows.Count;i++)
                        if (dtt.Rows[i]["EXAM_ID"].ToString().Trim() == e.Value.ToString().Trim())
                        {
                            flag = true;
                            break;
                        }
                    if (flag) {
                        msg.ShowAlert("UID1044", env.CurrentLanguageID);
                        e.AcceptValue = false;
                        return;
                    }
                    updateExamID(e.Value.ToString());
                    if (view1.FocusedColumn.VisibleIndex != view1.VisibleColumns.Count - 1)
                    {
                        view1.FocusedRowHandle = row;
                        view1.FocusedColumn = view1.VisibleColumns[2];
                    }
                    else
                    {
                        view1.FocusedColumn = view1.VisibleColumns[0];
                        view1.MoveNext();
                    }
                }
            }
        }
        void examID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (view1.FocusedColumn.VisibleIndex != view1.VisibleColumns.Count - 1)
                    view1.FocusedColumn = view1.VisibleColumns[2];
                else
                {
                    view1.FocusedColumn = view1.VisibleColumns[0];
                    view1.MoveNext();
                }
            }
        }
        void examName_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.AcceptValue)
            {
                if (e.Value.ToString() != string.Empty)
                {
                    DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                    int row = view1.FocusedRowHandle;
                    bool flag = false;
                    DataView dv = (DataView)grdConsumption.DataSource;
                    DataTable dtt = dv.Table;
                    for (int i = 0; i < dtt.Rows.Count; i++)
                        if (dtt.Rows[i]["EXAM_NAME"].ToString().Trim() == e.Value.ToString().Trim())
                        {
                            flag = true;
                            break;
                        }
                    if (flag)
                    {
                        msg.ShowAlert("UID1044", env.CurrentLanguageID);
                        e.AcceptValue = false;
                        return;
                    }
                    UpdateExamName(e.Value.ToString());
                    if (view1.FocusedColumn.VisibleIndex != view1.VisibleColumns.Count - 1)
                    {
                        view1.FocusedRowHandle = row;
                        view1.FocusedColumn = view1.VisibleColumns[view1.FocusedColumn.VisibleIndex + 1];
                    }
                    else
                    {
                        view1.FocusedColumn = view1.VisibleColumns[0];
                        view1.MoveNext();
                    }
                }
            }
        }
        void examName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (view1.FocusedColumn.VisibleIndex != view1.VisibleColumns.Count - 1)
                    view1.FocusedColumn = view1.VisibleColumns[view1.FocusedColumn.VisibleIndex + 1];
                else
                {
                    view1.FocusedColumn = view1.VisibleColumns[0];
                    view1.MoveNext();
                }
            }
        }

        bool canAddRow()
        {
            DataView dv = (DataView)grdConsumption.DataSource;
            DataTable dtt = dv.Table;
            bool flag = true;
            foreach (DataRow dr in dtt.Rows)
            {
                if (dr["EXAM_ID"].ToString().Trim() == string.Empty)
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        void updateExamID(string strSearch) { 
            DataView dv = (DataView)grdConsumption.DataSource;
            DataTable dtt = dv.Table;
            int row = view1.FocusedRowHandle;
            if (mode == "Edit")
            {
                if (dtt.Rows[row]["IS_DELETED"].ToString().Trim() == "Y") { 
                    for(int j=0;j<dtt.Rows.Count;j++)
                        if (dtt.Rows[j]["IS_DELETED"].ToString().Trim() == "N")
                        {
                            row = j;
                            break;
                        }
                }
            }
            int i = 0;
            for (; i < dttExam.Rows.Count; i++)
                if (dttExam.Rows[i]["EXAM_ID"].ToString() == strSearch)
                    break;
            if (i < dttExam.Rows.Count)
            {
                DataRow dr = dttExam.Rows[i];
                dtt.Rows[row]["EXAM_ID"] = dr["EXAM_ID"];
                dtt.Rows[row]["EXAM_NAME"] = dr["EXAM_NAME"];
                dtt.Rows[row]["RATE"] = dr["RATE"];
                decimal qty = dtt.Rows[row]["QTY"].ToString().Trim() == string.Empty ? 0 : Convert.ToDecimal(dtt.Rows[row]["QTY"]);
                decimal rate = dr["RATE"].ToString().Trim() == string.Empty ? 0 : Convert.ToDecimal(dr["RATE"]);
                dtt.Rows[row]["Total"] = qty * rate;
                if (canAddRow()) {
                    dr = dtt.NewRow();
                    dr["IS_DELETED"] = "N";
                    dr["QTY"] = 1;
                    dtt.Rows.Add(dr);
                }
                view1.RefreshData();
            }
        }
        void UpdateExamName(string strSearch)
        {
            DataView dv = (DataView)grdConsumption.DataSource;
            DataTable dtt = dv.Table;
            int row = view1.FocusedRowHandle;
            int i = 0;
            for (; i < dttExam.Rows.Count; i++)
                if (dttExam.Rows[i]["EXAM_NAME"].ToString() == strSearch)
                    break;
            if (i < dttExam.Rows.Count)
            {
                DataRow dr = dttExam.Rows[i];
                dtt.Rows[row]["EXAM_ID"] = dr["EXAM_ID"];
                dtt.Rows[row]["EXAM_NAME"] = dr["EXAM_NAME"];
                dtt.Rows[row]["RATE"] = dr["RATE"];
                decimal qty = dtt.Rows[row]["QTY"].ToString().Trim() == string.Empty ? 0 : Convert.ToDecimal(dtt.Rows[row]["QTY"]);
                decimal rate = dr["RATE"].ToString().Trim() == string.Empty ? 0 : Convert.ToDecimal(dr["RATE"]);
                dtt.Rows[row]["Total"] = qty * rate;
                view1.RefreshData();
                if (canAddRow())
                {
                    dr = dtt.NewRow();
                    dr["IS_DELETED"] = "N";
                    dr["QTY"] = 1;
                    dtt.Rows.Add(dr);
                }
            }
        }

        void btnDeleteRow_Click(object sender, EventArgs e)
        {
            DataView dv = (DataView)grdConsumption.DataSource;
            DataTable dtt = dv.Table;
            if (dtt.Rows.Count > 0)
            {
                string s = string.Empty;
                if (mode == "New")
                {
                    if (dtt.Rows[view1.FocusedRowHandle]["EXAM_ID"].ToString().Trim() == string.Empty) return;
                    s = msg.ShowAlert("UID1025", env.CurrentLanguageID);
                    if (s == "2")
                    {
                        dtt.Rows[view1.FocusedRowHandle].Delete();
                        dtt.AcceptChanges();
                        dv = new DataView(dtt);
                        grdConsumption.DataSource = dv;
                    }
                }
                else
                {
                    if (dtt.Rows[view1.FocusedRowHandle]["EXAM_ID"].ToString().Trim() == string.Empty) return;
                    s = msg.ShowAlert("UID1025", env.CurrentLanguageID);
                    if (s == "2")
                    {
                        //if (dtt.Rows[view1.FocusedRowHandle]["ACCESSION_NO"].ToString().Trim() != string.Empty)
                        //    delExam.Add(Convert.ToInt32(dtt.Rows[view1.FocusedRowHandle]["EXAM_ID"]));
                        dtt.Rows[view1.FocusedRowHandle].Delete();
                        dtt.AcceptChanges();
                        dv = new DataView(dtt);
                        grdConsumption.DataSource = dv;

                    }

                }
            }
        } 
        #endregion


        #region Keydown & Validated 
        private void txtNoOfImage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtKV.Focus();
        }
        private void txtNoOfImage_Validating(object sender, CancelEventArgs e)
        {
            txtKV.Focus();
        }

        private void txtKV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtmA.Focus();
        }
        private void txtKV_Validating(object sender, CancelEventArgs e)
        {
            txtmA.Focus();
        }

        private void txtmA_Validating(object sender, CancelEventArgs e)
        {
            txtSec.Focus();
        }
        private void txtmA_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
                txtSec.Focus();
        }

        private void txtSec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cboStatus.Focus();
        }
        private void txtSec_Validating(object sender, CancelEventArgs e)
        {
            cboStatus.Focus();
        }

        private void cboStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtExposure.Focus();
        }
        private void cboStatus_Validating(object sender, CancelEventArgs e)
        {
            txtExposure.Focus();
        }

        private void btnWorkList_Validating(object sender, CancelEventArgs e)
        {
            view1.Focus();
            if (view1.RowCount > 0)
            {
                view1.FocusedRowHandle = view1.RowCount - 1;
                DevExpress.XtraGrid.Columns.GridColumn focusColumn = view1.Columns["EXAM_ID"];
                view1.FocusedColumn = focusColumn;
            }
        }
        #endregion

        private void btnComplete_Click(object sender, EventArgs e)
        {
            dtEnd = DateTime.Now;
            if (mode == "New")
            {
                string s = msg.ShowAlert("UID1019", env.CurrentLanguageID);
                if (s == "2") 
                {
                    try
                    {
                        ProcessAddRISTechworks process = new ProcessAddRISTechworks();
                        process.RISTechworks.ACCESSION_ON = accessionNo;
                        process.RISTechworks.TAKE = (byte)take;
                        process.RISTechworks.START_TIME = dtStart;
                        process.RISTechworks.END_TIME = dtEnd;
                        process.RISTechworks.EXPOSURE_TECHNIQUE = txtExposure.Text.Trim();
                        process.RISTechworks.PROTOCOL = txtProtocol.Text.Trim();
                        process.RISTechworks.KV = txtKV.Text.Trim();
                        process.RISTechworks.mA = txtmA.Text.Trim();
                        process.RISTechworks.SEC = txtSec.Text.Trim();
                        if (cboStatus.SelectedValue.ToString() == "0")
                            process.RISTechworks.STATUS = "A";
                        else if (cboStatus.SelectedValue.ToString() == "1")
                            process.RISTechworks.STATUS = "S";
                        else if (cboStatus.SelectedValue.ToString() == "2")
                            process.RISTechworks.STATUS = "C";
                        else
                            process.RISTechworks.STATUS = "X";

                        if (process.RISTechworks.STATUS == "X")
                        {
                            Dialog.Reason frm = new RIS.Forms.Technologist.Dialog.Reason();
                            frm.ShowDialog();
                            process.RISTechworks.COMMENTS = frm.Comment;
                        }
                        process.RISTechworks.NO_OF_IMAGES = Convert.ToInt32(txtNoOfImage.Text);
                        process.RISTechworks.ORG_ID = env.OrgID;
                        process.RISTechworks.CREATED_BY = env.UserID;
                        process.RISTechworks.PERFORMANCED_BY = perform;
                        process.Invoke();

                        //add consumption
                        ProcessAddRISTechconsumption processCon = new ProcessAddRISTechconsumption();
                        processCon.RISTechconsumption.ACCESSION_NO = accessionNo;
                        processCon.RISTechconsumption.TAKE = (byte)take;
                        processCon.RISTechconsumption.CREATED_BY = env.UserID;

                        dv=(DataView)grdConsumption.DataSource;
                        DataTable dtt=dv.Table;
                        foreach (DataRow dr in dtt.Rows) {
                            if (dr["EXAM_ID"].ToString().Trim() != string.Empty)
                            {
                                processCon.RISTechconsumption.EXAM_ID = Convert.ToInt32(dr["EXAM_ID"]);
                                processCon.RISTechconsumption.IS_DELETED = "N";
                                processCon.RISTechconsumption.QTY = Convert.ToDecimal(dr["QTY"]);
                                processCon.RISTechconsumption.RATE = Convert.ToDecimal(dr["RATE"]);
                                processCon.Invoke();
                            }
                        }
                        //update status order;
                        ProcessUpdateRISOrderdtl processUpdate = new ProcessUpdateRISOrderdtl();
                        processUpdate.RISOrderdtl.ACCESSION_NO = accessionNo;
                        processUpdate.RISOrderdtl.STATUS = process.RISTechworks.STATUS;
                        processUpdate.RISOrderdtl.CREATED_BY = env.UserID;
                        processUpdate.UpdateStatus();

                        ReturnMainForm();
                    }
                    catch (Exception ex) { 
                    
                    }
                }
            }
            else
            {
                string s = msg.ShowAlert("UID1020", env.CurrentLanguageID);
                if (s == "2")
                {
                    try {
                        ProcessAddRISTechworks process = new ProcessAddRISTechworks();
                        process.RISTechworks.ACCESSION_ON = accessionNo;
                        process.RISTechworks.TAKE = (byte)take;
                        process.RISTechworks.START_TIME = dtStart;
                        process.RISTechworks.END_TIME = dtEnd;
                        process.RISTechworks.EXPOSURE_TECHNIQUE = txtExposure.Text.Trim();
                        process.RISTechworks.PROTOCOL = txtProtocol.Text.Trim();
                        process.RISTechworks.KV = txtKV.Text.Trim();
                        process.RISTechworks.mA = txtmA.Text.Trim();
                        process.RISTechworks.SEC = txtSec.Text.Trim();
                        if (cboStatus.SelectedValue.ToString() == "0")
                            process.RISTechworks.STATUS = "A";
                        else if (cboStatus.SelectedValue.ToString() == "1")
                            process.RISTechworks.STATUS = "C";
                        else if (cboStatus.SelectedValue.ToString() == "2")
                            process.RISTechworks.STATUS = "C";
                        else
                            process.RISTechworks.STATUS = "X";
                        if (process.RISTechworks.STATUS == "X")
                        {
                            Dialog.Reason frm = new RIS.Forms.Technologist.Dialog.Reason();
                            frm.ShowDialog();
                            process.RISTechworks.COMMENTS = frm.Comment;
                        }
                        process.RISTechworks.NO_OF_IMAGES = Convert.ToInt32(txtNoOfImage.Text);
                        process.RISTechworks.ORG_ID = env.OrgID;
                        process.RISTechworks.CREATED_BY = env.UserID;
                        process.RISTechworks.PERFORMANCED_BY = perform;
                        process.Invoke();

                        //Consumption
                        //delete consumption
                        ProcessDeleteRISTechconsumption processDel = new ProcessDeleteRISTechconsumption();
                        processDel.RISTechconsumption.ACCESSION_NO = accessionNo;
                        processDel.RISTechconsumption.TAKE = (byte)take;
                        processDel.Invoke();

                        //add consumption
                        ProcessAddRISTechconsumption processCon = new ProcessAddRISTechconsumption();
                        processCon.RISTechconsumption.ACCESSION_NO = accessionNo;
                        processCon.RISTechconsumption.TAKE = (byte)take;
                        processCon.RISTechconsumption.CREATED_BY = env.UserID;
                        dv = (DataView)grdConsumption.DataSource;
                        DataTable dtt = dv.Table;
                        foreach (DataRow dr in dtt.Rows)
                        {
                            if (dr["EXAM_ID"].ToString().Trim() != string.Empty)
                            {
                                processCon.RISTechconsumption.EXAM_ID = Convert.ToInt32(dr["EXAM_ID"]);
                                processCon.RISTechconsumption.IS_DELETED = "N";
                                processCon.RISTechconsumption.QTY = Convert.ToDecimal(dr["QTY"]);
                                processCon.RISTechconsumption.RATE = Convert.ToDecimal(dr["RATE"]);
                                processCon.Invoke();
                            }
                        }

                        //update status order;
                        ProcessUpdateRISOrderdtl processUpdate = new ProcessUpdateRISOrderdtl();
                        processUpdate.RISOrderdtl.ACCESSION_NO = accessionNo;
                        processUpdate.RISOrderdtl.STATUS = process.RISTechworks.STATUS;
                        processUpdate.RISOrderdtl.CREATED_BY = env.UserID;
                        processUpdate.UpdateStatus();

                        ReturnMainForm();
                    }
                    catch (Exception ex) { 
                    
                    }
                }
            }
        }
        private void btnWorkList_Click(object sender, EventArgs e)
        {
            ReturnMainForm();
        }

        private void ReturnMainForm() {
            RIS.Forms.Technologist.TF05 frm = new TF05(this.CloseControl, "Capture");
            frm.BackColor = Color.White;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            page.Selected = true;
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.Add(page);
            CloseControl.TabPages.RemoveAt(index);
            frm.dateFrom.Focus();
        }

        #region Menu Tab
        private void barCapture_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RIS.Forms.Technologist.TF05 frm = new TF05(this.CloseControl, "Capture");
            frm.BackColor = Color.White;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            page.Selected = true;
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.Add(page);
            CloseControl.TabPages.RemoveAt(index);
            frm.dateFrom.Focus();
        }
        private void barQA_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RIS.Forms.Technologist.TF05 frm = new TF05(this.CloseControl, "QA");
            frm.BackColor = Color.White;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            page.Selected = true;
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.Add(page);
            CloseControl.TabPages.RemoveAt(index);
            frm.dateFrom.Focus();
        }
        private void barGroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RIS.Forms.Technologist.TF05 frm = new TF05(this.CloseControl, "Capture");
            frm.BackColor = Color.White;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            page.Selected = true;
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.Add(page);
            CloseControl.TabPages.RemoveAt(index);
            frm.dateFrom.Focus();
        }
        private void barNewOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RIS.Forms.Order.frmOrders frm = new RIS.Forms.Order.frmOrders("New", this.CloseControl);
            frm.BackColor = Color.White;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Text = frm.Text;
            UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            page.Selected = true;
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.Add(page);
            CloseControl.TabPages.RemoveAt(index);
            frm.txtHN.Focus();
        }
        private void barOrderData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //RIS.Forms.Technologist.frmPatientData frm = new frmPatientData(this.CloseControl);
            //frm.BackColor = Color.White;
            //frm.MaximizeBox = false;
            //frm.MinimizeBox = false;
            //frm.Text = frm.Text;
            //UUL.ControlFrame.Controls.TabPage page = new UUL.ControlFrame.Controls.TabPage(frm.Text, frm);
            //page.Selected = true;
            //int index = CloseControl.SelectedIndex;
            //CloseControl.TabPages.Add(page);
            //CloseControl.TabPages.RemoveAt(index);

            frmPatientData frm = new frmPatientData(accessionNo, take, false);
            frm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Height -= 112;
            frm.ShowDialog();
        }
        private void barHome_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int i = 0; i < CloseControl.TabPages.Count; i++)
            {
                if (CloseControl.TabPages[i].Title == "Home")
                {
                    CloseControl.TabPages[i].Selected = true;
                    return;
                }
            }
        }
        private void barClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.RemoveAt(index);
        }
        #endregion
    }
}


#region Old Update
//ProcessUpdateRISTechworks process = new ProcessUpdateRISTechworks();
//process.RISTechworks.ACCESSION_ON = accessionNo;
//process.RISTechworks.TAKE = (byte)take;
//process.RISTechworks.START_TIME = dtStart;
//process.RISTechworks.END_TIME = dtEnd;
//process.RISTechworks.EXPOSURE_TECHNIQUE = txtExposure.Text.Trim();
//process.RISTechworks.PROTOCOL = txtProtocol.Text.Trim();
//process.RISTechworks.KV = txtKV.Text.Trim();
//process.RISTechworks.mA = txtmA.Text.Trim();
//process.RISTechworks.SEC = txtSec.Text.Trim();
//if (cboStatus.SelectedValue.ToString() == "1")
//    process.RISTechworks.STATUS = "C";
//else if (cboStatus.SelectedValue.ToString() == "2")
//    process.RISTechworks.STATUS = "C";
//else
//    process.RISTechworks.STATUS = "X";
//process.RISTechworks.NO_OF_IMAGES = Convert.ToInt32(txtNoOfImage.Text);
//process.RISTechworks.ORG_ID = env.OrgID;
//process.RISTechworks.CREATED_BY = env.UserID;
//process.RISTechworks.PERFORMANCED_BY = perform;
//process.Invoke();
#endregion