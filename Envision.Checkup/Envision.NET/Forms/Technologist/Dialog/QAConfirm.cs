using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RIS.Common.Common;
using RIS.BusinessLogic;
using RIS.Forms.GBLMessage;
using DevExpress.XtraEditors.Repository;
namespace RIS.Forms.Technologist.Dialog
{
    public partial class QAConfirm : Form
    {
        private GBLEnvVariable env = new GBLEnvVariable();
        private string hn = string.Empty;
        private MyMessageBox msg = new MyMessageBox();
        private string accession_no = string.Empty;
        private int take = 0;
        private DataTable dttExam = new DataTable();
        

        public QAConfirm()
        {
            InitializeComponent();
        }
        public QAConfirm(string HN,string Accession_NO, int Take)
        {
            InitializeComponent();
            accession_no = Accession_NO;
            hn = HN;
            take = Take;
            getExamData();
            bindGridQA();
            bindGriHistory();
        }

        private void getExamData()
        {
            try
            {
                ProcessGetRISExam processExam = new ProcessGetRISExam();
                processExam.Invoke();
                dttExam = processExam.Result.Tables[0].Copy();
                dttExam.TableName = "RIS_EXAM";

                //ProcessGetRISExam processExam = new ProcessGetRISExam();
                //dttExam = processExam.Consumable().Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            string s = msg.ShowAlert("UID1019", env.CurrentLanguageID);
            if (s == "2")
            {
                DialogResult = DialogResult.OK;
            }
        }

        public string Comment
        {
            get { return txtComment.Text.Trim(); }
        }
        public bool Pass
        {
            get { return rdoPass.Checked; }
        }
        public int ImageCount {
            get {
                int img = Convert.ToInt32(txtNoOfImg.Text);
                return img;
            }
        }
        public DataTable Consumption
        {
            get {
                DataTable dtt = (DataTable)grdQA.DataSource;
                return dtt;
            }
        }

        private void bindGridQA()
        {
            ProcessGetRISTechconsumption process = new ProcessGetRISTechconsumption();
            DataTable dtt = new DataTable();
            process.RISTechconsumption.ACCESSION_NO = accession_no;
            process.RISTechconsumption.TAKE = (byte)take;
            process.Invoke();
            dtt = process.Result.Tables[0].Copy();
            dtt.Columns.Add("Total", typeof(decimal));
            dtt.Columns.Add("colDelete", typeof(string));
            foreach (DataRow dr in dtt.Rows)
            {
                for (int i = 0; i < dttExam.Rows.Count; i++)
                {
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
            grdQA.DataSource = dtt;
            //
            DataRow drAdd = dtt.NewRow();
            drAdd["QTY"] = 1;
            drAdd["IS_DELETED"] = "N";
            dtt.Rows.Add(drAdd);
            grdQA.DataSource = dtt;
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
            view1.Columns["QTY"].DisplayFormat.FormatString = "#,##0.00";
            view1.Columns["QTY"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view1.Columns["RATE"].Caption = "Rate";
            view1.Columns["RATE"].OptionsColumn.ReadOnly = true;
            view1.Columns["RATE"].DisplayFormat.FormatString = "#,##0.00";
            view1.Columns["RATE"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view1.Columns["Total"].Caption = "Total";
            view1.Columns["Total"].OptionsColumn.ReadOnly = true;
            view1.Columns["Total"].DisplayFormat.FormatString = "#,##0.00";
            view1.Columns["Total"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
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
            DataTable dtt = (DataTable)grdQA.DataSource;
            decimal qty = Convert.ToDecimal(spin.Value);
            decimal rate = dtt.Rows[row]["RATE"].ToString().Trim() == string.Empty ? 0 : Convert.ToDecimal(dtt.Rows[row]["RATE"]);
            dtt.Rows[row]["QTY"] = qty;
            dtt.Rows[row]["Total"] = qty * rate;
            view1.Columns["Total"].BestFit();
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
                    DataTable dtt = (DataTable)grdQA.DataSource;
                    bool flag = false;
                    for (int i = 0; i < dtt.Rows.Count; i++)
                        if (dtt.Rows[i]["EXAM_ID"].ToString().Trim() == e.Value.ToString().Trim())
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
                    updateExamID(e.Value.ToString());
                    view1.Columns["RATE"].BestFit();
                    view1.Columns["QTY"].BestFit();
                    view1.Columns["Total"].BestFit();
                    view1.Columns["EXAM_NAME"].BestFit();
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
                    DataTable dtt = (DataTable)grdQA.DataSource;
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
                    view1.Columns["RATE"].BestFit();
                    view1.Columns["QTY"].BestFit();
                    view1.Columns["Total"].BestFit();
                    view1.Columns["EXAM_NAME"].BestFit();
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
            DataTable dtt = (DataTable)grdQA.DataSource;
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
        void updateExamID(string strSearch)
        {
            DataTable dtt = (DataTable)grdQA.DataSource;
            int row = view1.FocusedRowHandle;
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
                if (canAddRow())
                {
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
            DataTable dtt = (DataTable)grdQA.DataSource;
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
            DataTable dtt = (DataTable)grdQA.DataSource;
            if (dtt.Rows.Count > 0)
            {
                string s = string.Empty;
                if (dtt.Rows[view1.FocusedRowHandle]["EXAM_ID"].ToString().Trim() == string.Empty) return;
                s = msg.ShowAlert("UID1025", env.CurrentLanguageID);
                if (s == "2")
                {
                    dtt.Rows[view1.FocusedRowHandle].Delete();
                    dtt.AcceptChanges();
                    grdQA.DataSource = dtt;
                }
            }
        }
        #endregion

        private void bindGriHistory() {
            ProcessGetRISTechconsumption process = new ProcessGetRISTechconsumption(hn);
            process.Invoke();
            DataSet ds = process.Result;
            grdHistory.DataSource = ds.Tables[0];
           
            DataColumn dcMaster = ds.Tables[0].Columns["accession_no"];
            DataColumn dcParent = ds.Tables[1].Columns["accession_no"];
            DataRelation dl = new DataRelation("Master_Details", dcMaster, dcParent);
            ds.Relations.Add(dl);

            for (int i = 0; i < viewHistory1.Columns.Count; i++)
                viewHistory1.Columns[i].Visible = false;
            viewHistory1.Columns["order_dt"].Visible = true;
            viewHistory1.Columns["order_dt"].Caption = "Date";
            viewHistory1.Columns["no_of_images"].Visible = true;
            viewHistory1.Columns["no_of_images"].Caption = "No. Of Images";

            viewHistory1.OptionsView.ShowBands = false;
            viewHistory1.OptionsDetail.ShowDetailTabs = false;
            viewHistory1.OptionsView.ShowGroupPanel = false;
            viewHistory1.BestFitColumns();


            DevExpress.XtraGrid.Columns.GridColumn colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colNoOfImage = new DevExpress.XtraGrid.Columns.GridColumn();
            //DevExpress.XtraGrid.Columns.GridColumn colQaPassed = new DevExpress.XtraGrid.Columns.GridColumn();

            colDate.Caption = "Date";
            colDate.FieldName = "order_dt";
            colDate.Visible = true;
            colDate.VisibleIndex = 0;
            colDate.OptionsColumn.ReadOnly = true;

            colNoOfImage.Caption = "Date";
            colNoOfImage.FieldName = "no_of_images";
            colNoOfImage.Visible = true;
            colNoOfImage.VisibleIndex = 1;
            colNoOfImage.OptionsColumn.ReadOnly = true;


            DevExpress.XtraGrid.Views.Grid.GridView gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colDate, colNoOfImage });
            gridView1.GridControl = grdHistory;
            gridView1.OptionsView.ShowIndicator = false;
            gridView1.OptionsView.ShowHorzLines = false;
            gridView1.OptionsView.ShowVertLines = false;


            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            gridLevelNode1.LevelTemplate = gridView1;
            gridLevelNode1.RelationName = "Root_Master";


            DevExpress.XtraGrid.Columns.GridColumn colExamName = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colQty= new DevExpress.XtraGrid.Columns.GridColumn();
            colExamName.Caption = "Consumable";
            colExamName.FieldName = "Consumbale";
            colExamName.Visible = true;
            colExamName.VisibleIndex = 0;
            colExamName.OptionsColumn.ReadOnly = true;

            colQty.Caption = "Qty";
            colQty.FieldName = "qty";
            colQty.Visible = true;
            colQty.VisibleIndex =1;
            colQty.OptionsColumn.ReadOnly = true;

            DevExpress.XtraGrid.Views.Grid.GridView gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colExamName, colQty});
            gridView2.GridControl = grdHistory;
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            gridLevelNode2.LevelTemplate = gridView2;
            gridLevelNode2.RelationName = "Master_Details";
            gridView2.Columns["Consumbale"].Width = 254;




            gridView2.OptionsView.ShowGroupPanel = false;
            gridView2.OptionsView.ShowAutoFilterRow = true;
            gridView2.OptionsView.ShowColumnHeaders = true;
            gridView2.OptionsView.ShowIndicator = false;
          
            
           
        
            grdHistory.ShowOnlyPredefinedDetails = true;
            gridLevelNode1.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] { gridLevelNode2 });
            grdHistory.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] { gridLevelNode1, gridLevelNode2 });
            grdHistory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1, gridView2 });
            
            viewHistory1.Columns["order_dt"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;

            viewHistory1.Columns["order_dt"].Width = 355;
            viewHistory1.Columns["no_of_images"].Width = 100;
        }



        private void txtNoOfImg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtComment.Focus();
        }
    }
}