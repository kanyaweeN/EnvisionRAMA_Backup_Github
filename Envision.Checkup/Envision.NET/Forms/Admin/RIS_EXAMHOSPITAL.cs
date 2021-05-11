using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RIS.Common.Common;
using RIS.BusinessLogic;
using RIS.Common.UtilityClass;
using RIS.Forms.GBLMessage;

using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;

namespace RIS.Forms.Admin
{
    public partial class RIS_EXAMHOSPITAL : Form
    {
        private DBUtility dbu;
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        private DataTable dtt;
        private BindingSource bs;
        private MyMessageBox msg = new MyMessageBox();
        private string mode = "new";

        public RIS_EXAMHOSPITAL(int i) {
            InitializeComponent();
            initControl();
            initBinding();

            bs.Position = i;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ControlBox = false;
        }
        public RIS_EXAMHOSPITAL(UUL.ControlFrame.Controls.TabControl clsCtl)
        {
            InitializeComponent();
            this.CloseControl = clsCtl;
            initControl();
            initBinding();

            //SelectDataToGrid(Convert.ToInt32(textUID.Tag.ToString()));
        }

        #region ToolStrip.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            setReadOnlyTextBox(true);
            setButtonEnabled(false);
            mode = "new";
            textUID.Focus();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            setReadOnlyTextBox(true);
            setButtonEnabled(false);
            mode = "edit";
            textUID.Focus();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string str=msg.ShowAlert("UID1025", new GBLEnvVariable().CurrentLanguageID);
            if (str == "2") {
                deleteData();
                setButtonEnabled(true);
                setReadOnlyTextBox(true);

                initControl();
                initBinding();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            setButtonEnabled(true);
            setReadOnlyTextBox(true);

            SelectDataToGrid(Convert.ToInt32(textUID.Tag.ToString()));
            //initControl();
            //initBinding();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string str = msg.ShowAlert("UID1019", new GBLEnvVariable().CurrentLanguageID);
            if (str == "2")
            {
                if (mode == "new")
                    saveData();
                else
                    updateData();
                setButtonEnabled(true);
                setReadOnlyTextBox(true);

                SelectDataToGrid(Convert.ToInt32(textUID.Tag.ToString()));
                //initControl();
                //initBinding();
            }
        } 
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (CloseControl != null)
            {
                dbu = new DBUtility();
                dbu.CloseFrom(CloseControl, this);
            }
            else
                this.Close();
        }
        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            //bs.MoveFirst();
            //double d = Convert.ToDouble(textRate.Text);
            //textRate.Text = d.ToString("#,##0.00");
            //SelectDataToGrid(Convert.ToInt32(textUID.Tag.ToString()));
        }
        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            //double d = Convert.ToDouble(textRate.Text);
            //textRate.Text = d.ToString("#,##0.00");
            //SelectDataToGrid(Convert.ToInt32(textUID.Tag.ToString()));
          //  bs.MovePrevious();
        }
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            //double d = Convert.ToDouble(textRate.Text);
            //textRate.Text = d.ToString("#,##0.00");
            //SelectDataToGrid(Convert.ToInt32(textUID.Tag.ToString()));
           // bs.MoveNext();
        }
        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            //double d = Convert.ToDouble(textRate.Text);
            //textRate.Text = d.ToString("#,##0.00");
            //SelectDataToGrid(Convert.ToInt32(textUID.Tag.ToString()));
            //bs.MoveLast();
        }
        #endregion

        #region KeyBoard Event.
        private void textUID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
        }
        private void textHospital_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
        }
        private void textAlias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
        }
        private void textPhoneNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
        }
        private void textDesc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
        } 
        #endregion

        private void initControl() {
            textUID.Text = string.Empty;
            textHospital.Text = string.Empty;
            textRate.Text = "0";

            textUID.Properties.ReadOnly = true;
            textHospital.Properties.ReadOnly = true;
            textRate.Properties.ReadOnly = true;

            gridControl1.Enabled = false;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = false;
            btnCancel.Visible = false;
        }
        private void initBinding() 
        {
            dtt = new DataTable();
            bs = new BindingSource();

            ProcessGetRISExamhospital process = new ProcessGetRISExamhospital();
            process.Invoke();
            dtt = process.Result.Tables[0].Copy();
            bs.DataSource = dtt;
            bs.PositionChanged += new EventHandler(bs_PositionChanged);
            bindingNavigator1.BindingSource = bs;

            if (dtt.Rows.Count == 0)
            {
                bindingNavigatorMoveFirstItem.Enabled = false;
                bindingNavigatorMoveLastItem.Enabled = false;
                bindingNavigatorMoveNextItem.Enabled = false;
                bindingNavigatorMovePreviousItem.Enabled = false;
                bindingNavigatorPositionItem.Enabled = false;
                btnAdd.Enabled = false;
            }
            else
            {
                setNavigator();
                bs.MoveNext();
                bs.MoveFirst();

                SelectDataToGrid(Convert.ToInt32(dtt.Rows[0]["EXAM_ID"].ToString()));
                SelectDataToGrid(Convert.ToInt32(dtt.Rows[0]["EXAM_ID"].ToString()));
                bindingNavigatorMoveFirstItem.Enabled = true;
                bindingNavigatorMoveLastItem.Enabled = true;
                bindingNavigatorMoveNextItem.Enabled = true;
                bindingNavigatorMovePreviousItem.Enabled = true;
                bindingNavigatorPositionItem.Enabled = true;
            }
        }
        private void clearInContext() {
            textUID.DataBindings.Clear();
            textHospital.DataBindings.Clear();
            textRate.DataBindings.Clear();

            textUID.Tag = null;
            textUID.Text = string.Empty;
            textHospital.Text = string.Empty;
            textRate.Text = "0";
        }
        private void setNavigator() {
            clearInContext();

            textUID.DataBindings.Add("Tag", bs, "EXAM_ID");
            textUID.DataBindings.Add("Text", bs, "EXAM_UID");
            textHospital.DataBindings.Add("Text", bs, "EXAM_NAME");
            textRate.DataBindings.Add("Text", bs, "RATE");

            btnAdd.Enabled = false;
            btnEdit.Enabled = true;
            btnDelete.Enabled = false;
        }

        void bs_PositionChanged(object sender, EventArgs e)
        {
            BindingSource bds = new BindingSource();
            bds = (BindingSource)sender;
            try
            {
                DataTable dtt = new DataTable();
                dtt = (DataTable)bds.DataSource;
                int id = Convert.ToInt32(dtt.Rows[bds.Position]["EXAM_ID"].ToString());
                double d = Convert.ToDouble(dtt.Rows[bds.Position]["RATE"].ToString());
                textRate.Text = d.ToString("#,##0.00");
                SelectDataToGrid(id);
            }
            catch { }
           // setNavigator();
        }
       
        private void setReadOnlyTextBox(bool flag) {
            textUID.Properties.ReadOnly = flag;
            textHospital.Properties.ReadOnly = flag;
            textRate.Properties.ReadOnly = flag;
        }
        private void setButtonEnabled(bool flag) {
            btnAdd.Visible = false;
            btnEdit.Visible = flag;
            btnDelete.Visible = false;
            btnClose.Visible = flag;
            btnSave.Visible = !flag;
            btnCancel.Visible = !flag;
            gridControl1.Enabled = !flag;
            bindingNavigatorMoveFirstItem.Enabled = flag;
            bindingNavigatorMoveLastItem.Enabled = flag;
            bindingNavigatorMoveNextItem.Enabled = flag;
            bindingNavigatorMovePreviousItem.Enabled = flag;
            bindingNavigatorPositionItem.Enabled = flag;
        }
        
        private void SelectDataToGrid(int id)
        {
            ProcessGetRISExamhospital getdata = new ProcessGetRISExamhospital(id);
            getdata.Invoke();
            gridControl1.DataSource = getdata.Result.Tables[0];
            //view1.OptionsView.ShowBands = false;
            view1.OptionsSelection.EnableAppearanceFocusedCell = false;
            view1.OptionsSelection.EnableAppearanceFocusedRow = false;
            view1.OptionsView.ShowColumnHeaders = true;

            for (int i = 0; i < view1.Columns.Count; i++)
                view1.Columns[i].Visible = false;

            view1.Columns["HOS_ID"].Caption = "Hospital ID";
            view1.Columns["HOS_NAME"].Caption = "Hospital Name";
            view1.Columns["HOS_NAME"].OptionsColumn.ReadOnly = true;
            view1.Columns["HOS_NAME"].OptionsColumn.AllowEdit = false;
            view1.Columns["UC_RATE"].Caption = "UC Rate";
            view1.Columns["CR_RATE"].Caption = "CR Rate";

            //view1.Columns["HOS_ID"].ColVIndex = 0;
            //view1.Columns["HOS_NAME"].ColVIndex = 1;
            //view1.Columns["UC_RATE"].ColVIndex = 2;
            //view1.Columns["CR_RATE"].ColVIndex = 3;

            view1.Columns["HOS_ID"].Visible = false;
            view1.Columns["HOS_NAME"].Visible = true;
            view1.Columns["UC_RATE"].Visible = true;
            view1.Columns["CR_RATE"].Visible = true;

            view1.Columns["HOS_NAME"].BestFit();
            view1.Columns["UC_RATE"].DisplayFormat.FormatString = "#,##0.00";
            view1.Columns["UC_RATE"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            view1.Columns["CR_RATE"].DisplayFormat.FormatString = "#,##0.00";
            view1.Columns["CR_RATE"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            //RepositoryItemLookUpEdit repositoryItemLookUpEdit6 = new RepositoryItemLookUpEdit();
            //repositoryItemLookUpEdit6.KeyUp += new KeyEventHandler(CR_RATE_KeyUp);
            //repositoryItemLookUpEdit6.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(CR_RATE_CloseUp);
            //repositoryItemLookUpEdit6.DisplayMember = "CR_RATE";
            //repositoryItemLookUpEdit6.ValueMember = "CR_RATE";
            RepositoryItemTextEdit repostext = new RepositoryItemTextEdit();
            repostext.Leave += new EventHandler(repostext_Leave);
            view1.Columns["CR_RATE"].ColumnEdit = repostext;
            //view1.Columns["CR_RATE"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            //view1.Columns["RATE"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

            
        }

        void repostext_Leave(object sender, EventArgs e)
        {
            string a = "";
            //throw new Exception("The method or operation is not implemented.");
        }
        private void saveData() {

            DataTable dt = new DataTable();
            dt =(DataTable)gridControl1.DataSource;
            //ProcessAddGBLHospital process = new ProcessAddGBLHospital();
            //process.GBLHospital.HOS_UID = textUID.Text;
            //process.GBLHospital.HOS_NAME = textHospital.Text;
            //process.GBLHospital.HOS_NAME_ALIAS = textAlias.Text;
            //process.GBLHospital.PHONE_NO = textPhoneNo.Text;
            //process.GBLHospital.DESCR = textDesc.Text;
            //process.GBLHospital.ORG_ID = new GBLEnvVariable().OrgID;
            //process.GBLHospital.CREATED_BY = new GBLEnvVariable().UserID;
            //process.GBLHospital.PERCENT_DISCOUNT = Convert.ToInt32(textRate.Text);
            //process.Invoke();
          
        }
        private void updateData() {
            DataTable dt = new DataTable();
            dt = (DataTable)gridControl1.DataSource;
            SqlTransaction tran = null;
            SqlConnection con = null;
            try
            {
                DataAccess.DataAccessBase baseData = new RIS.DataAccess.DataAccessBase();
                con = baseData.GetSQLConnection();

                con.Open();
                tran = con.BeginTransaction();

                ProcessAddRISExamhospital prcAdd = new ProcessAddRISExamhospital(tran);

                foreach (DataRow dr in dt.Rows)
                {
                    prcAdd.RISExamhospital.EXAM_ID = Convert.ToInt32(textUID.Tag.ToString());
                    prcAdd.RISExamhospital.HOS_ID = Convert.ToInt32(dr["HOS_ID"].ToString());
                    prcAdd.RISExamhospital.UC_RATE = Convert.ToDecimal(dr["UC_RATE"].ToString());
                    prcAdd.RISExamhospital.CR_RATE = Convert.ToDecimal(dr["CR_RATE"].ToString());
                    prcAdd.RISExamhospital.CREATED_BY = new GBLEnvVariable().UserID;
                    prcAdd.RISExamhospital.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;

                    prcAdd.Invoke();
                }
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                //throw new Exception(ex.Message);
                //retFlag = false;//MessageBox.Show(ex.Message);

            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                tran.Dispose();
            }
        }
        private void deleteData() {
            //ProcessDeleteGBLHospital process = new ProcessDeleteGBLHospital();
            //process.GBLHospital.HOS_ID = Convert.ToInt32(textUID.Tag.ToString());
            //process.Invoke();
        }

    }
}