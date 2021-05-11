using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.Common.UtilityClass;
using RIS.BusinessLogic;
using RIS.Common.Common;
using RIS.Common;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using DevExpress.Data;
using RIS.Forms.GBLMessage;

namespace RIS.Forms.Admin
{
    public partial class RIS_SF12 : Form
    {
        DataSet ds1, ds2, ds3;
        BindingSource bs;
        int groupID;
        private MyMessageBox mmb = new MyMessageBox();

        UUL.ControlFrame.Controls.TabControl tabControl;
        RIS.Common.UtilityClass.DBUtility dbu;

        public RIS_SF12()
        {
            InitializeComponent();
            cmbGroupType.SelectedIndex = 0;
            ProcessGetManageGroupsTable processGroups = new ProcessGetManageGroupsTable();
            processGroups.Invoke();
            try{groupID = (int)processGroups.DataResult.Tables[0].Rows[0]["GROUP_ID"];}catch (Exception ex){}
            bs = new BindingSource();
        }
        public RIS_SF12(UUL.ControlFrame.Controls.TabControl tabcontrol)
        {
            InitializeComponent();
            cmbGroupType.SelectedIndex = 0;
            ProcessGetManageGroupsTable processGroups = new ProcessGetManageGroupsTable();
            processGroups.Invoke();
            try { groupID = (int)processGroups.DataResult.Tables[0].Rows[0]["GROUP_ID"]; }
            catch (Exception) { }
            bs = new BindingSource();

            tabControl = tabcontrol;
        }
        private void RIS_SF12_Load(object sender, EventArgs e)
        {
            
            LoadAll(groupID);
            SetNavigator();
            TextBinding();
            SetGridData();

            InitTreeView();

            cmbGroupType.SelectedIndexChanged +=new EventHandler(SelectedIndexChanged);
            cmbGroupType.DropDownClosed += new EventHandler(DropDownClosed);
            cmbGroupType.KeyPress += new KeyPressEventHandler(cmbGroupType_KeyPress);
        }

        private void cmbGroupType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Up || e.KeyChar == (char)Keys.Down)
                e.Handled = false;
        }
        private void LoadAll(int groupid)
        {
            ds1 = new DataSet(); ds2 = new DataSet(); ds3 = new DataSet();

            ManageGroups gmng = new ManageGroups();

            ProcessGetManageGroupsTable processGroups = new ProcessGetManageGroupsTable();
            processGroups.Invoke();
            ds1.Tables.Add(processGroups.DataResult.Tables[0].Copy());
            ds1.Tables[0].TableName = "dt1";

            ProcessGetManageGroupsTableDtl processGroupsDtl = new ProcessGetManageGroupsTableDtl();
            groupID = groupid;
            gmng.GROUP_ID = groupid;
            processGroupsDtl.ManageGroups = gmng;
            processGroupsDtl.Invoke();
            ds2.Tables.Add(processGroupsDtl.DataResult.Tables[0].Copy());
            ds2.Tables[0].TableName = "dt2";

            ProcessGetManageGroups processGroupsType = new ProcessGetManageGroups();
            switch (cmbGroupType.SelectedIndex)
            {
                case 0: gmng.GROUP_TYPE = "R"; 
                        processGroupsType.ManageGroups = gmng; 
                        processGroupsType.Invoke(); break;
                case 1: gmng.GROUP_TYPE = "T"; 
                        processGroupsType.ManageGroups = gmng;
                        processGroupsType.Invoke(); break;
                case 2: gmng.GROUP_TYPE = "M"; 
                        processGroupsType.ManageGroups = gmng;
                        processGroupsType.Invoke(); break;
                default: MessageBox.Show("Item wasn't be selected "); break;
            }
            ds3.Tables.Add(processGroupsType.ResultSet.Tables[0].Copy());
            ds3.Tables[0].TableName = "dt3";

        }
        private void LoadTableMaster()
        {
            ds1 = new DataSet();

            ManageGroups gmng = new ManageGroups();

            ProcessGetManageGroupsTable processGroups = new ProcessGetManageGroupsTable();
            processGroups.Invoke();
            ds1.Tables.Add(processGroups.DataResult.Tables[0].Copy());
            ds1.Tables[0].TableName = "dt1";    

        }
        private void LoadTableDetail(int groupid)
        {
            ds2 = new DataSet();
            ManageGroups gmng = new ManageGroups();

            ProcessGetManageGroupsTableDtl processGroupsDtl = new ProcessGetManageGroupsTableDtl();
            groupID = groupid;
            gmng.GROUP_ID = groupid;
            processGroupsDtl.ManageGroups = gmng;
            processGroupsDtl.Invoke();
            ds2.Tables.Add(processGroupsDtl.DataResult.Tables[0].Copy());
            ds2.Tables[0].TableName = "dt2";

        }
        private void LoadTableGroupType(int type)
        {
            ds3 = new DataSet();

            ManageGroups gmng = new ManageGroups();

            ProcessGetManageGroups processGroupsType = new ProcessGetManageGroups();
            switch (type)
            {
                case 0: gmng.GROUP_TYPE = "R";
                    processGroupsType.ManageGroups = gmng;
                    processGroupsType.Invoke(); break;
                case 1: gmng.GROUP_TYPE = "T";
                    processGroupsType.ManageGroups = gmng;
                    processGroupsType.Invoke(); break;
                case 2: gmng.GROUP_TYPE = "M";
                    processGroupsType.ManageGroups = gmng;
                    processGroupsType.Invoke(); break;
                default: MessageBox.Show("Item wasn't be selected "); break;
            }
            ds3.Tables.Add(processGroupsType.ResultSet.Tables[0].Copy());
            ds3.Tables[0].TableName = "dt3";

        }
        private void SetNavigator()
        {
            bs.DataSource = ds1.Tables[0].Copy();
            bs.PositionChanged += new EventHandler(bs_PositionChanged);
            navigator1.BindingSource = bs;
        }
        private void TextBinding()
        {
            txtGUID.Text = string.Empty;
            txtGName.Text = string.Empty;
            txtGUsername.Text = string.Empty;
            txtGPassword.Text = string.Empty;
            txtGConNo.Text = string.Empty;
            txtGHeadUID.Text = string.Empty;
            txtGHeadName.Text = string.Empty;

            txtGUID.DataBindings.Clear();
            txtGName.DataBindings.Clear();
            txtGUsername.DataBindings.Clear();
            txtGPassword.DataBindings.Clear();
            txtGConNo.DataBindings.Clear();
            txtGHeadUID.DataBindings.Clear();
            txtGHeadName.DataBindings.Clear();

            txtGUID.DataBindings.Add("Text", bs, "GROUP_UID");
            txtGName.DataBindings.Add("Text", bs, "GROUP_NAME");
            txtGUsername.DataBindings.Add("Text", bs, "GROUP_USER_NAME");
            txtGPassword.DataBindings.Add("Text", bs, "GROUP_PASS");
            txtGConNo.DataBindings.Add("Text", bs, "GROUP_CONTACT_NO");
            txtGHeadUID.DataBindings.Add("Text", bs, "GROUP_HEAD");
            txtGHeadName.DataBindings.Add("Text", bs, "GROUP_HEAD_NAME");
            try{if (ds1.Tables[0].Rows[0]["IS_ACTIVE"].ToString() == "Y")
                    chkActive.Checked = true;
                else
                    chkActive.Checked = false;} 
            catch (Exception) { }
        }
        private void SetGridData()
        {
            ds2.Tables[0].Columns.Add("Delete");
            gridControl.DataSource = ds2.Tables[0].DefaultView;
            LoadTableDetail(groupID);
            for (int i = 0; i < view1.Columns.Count; i++)
            {
                view1.Columns[i].Visible = false;
            }

            RepositoryItemTextEdit repositoryItemTextEdit1 = new RepositoryItemTextEdit();
            repositoryItemTextEdit1.KeyPress += new KeyPressEventHandler(KeyPress);
            //repositoryItemTextEdit1.

            view1.Columns["SL"].ColumnEdit = repositoryItemTextEdit1;
            view1.Columns["SL"].Visible = true;
            view1.Columns["SL"].Caption = "Serial";
            view1.Columns["SL"].OptionsColumn.ReadOnly = false;
            view1.Columns["SL"].BestFit();
            view1.Columns["SL"].ColVIndex = 0;
            view1.Columns["SL"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            //view1.Columns["SL"].OptionsColumn.

            RepositoryItemLookUpEdit repositoryItemLookUpEdit1 = new RepositoryItemLookUpEdit();
            repositoryItemLookUpEdit1.TextEditStyle = TextEditStyles.DisableTextEditor;
            repositoryItemLookUpEdit1.ImmediatePopup = true;
            repositoryItemLookUpEdit1.SearchMode = SearchMode.OnlyInPopup;
            repositoryItemLookUpEdit1.AutoHeight = false;
            repositoryItemLookUpEdit1.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("EMP_ID", "Member ID", 20, FormatType.None, "", true, HorzAlignment.Default, ColumnSortOrder.None) });
            repositoryItemLookUpEdit1.DisplayMember = "EMP_ID";
            repositoryItemLookUpEdit1.ValueMember = "EMP_ID";
            repositoryItemLookUpEdit1.DropDownRows = 3;
            repositoryItemLookUpEdit1.DataSource = ds3.Tables[0];
            repositoryItemLookUpEdit1.NullText = string.Empty;
            repositoryItemLookUpEdit1.CloseUp += new CloseUpEventHandler(MemberID_CloseUp);

            view1.Columns["MEMBER_ID"].ColumnEdit = repositoryItemLookUpEdit1;
            view1.Columns["MEMBER_ID"].OptionsColumn.AllowSort = DefaultBoolean.False;
            view1.Columns["MEMBER_ID"].Visible = true;
            view1.Columns["MEMBER_ID"].Caption = "Member ID";
            view1.Columns["MEMBER_ID"].ColVIndex = 1;
            view1.Columns["MEMBER_ID"].BestFit();

            view1.Columns["FULLNAME"].Visible = true;
            view1.Columns["FULLNAME"].Caption = "Name";
            view1.Columns["FULLNAME"].OptionsColumn.ReadOnly = true;
            view1.Columns["FULLNAME"].BestFit();
            view1.Columns["FULLNAME"].OptionsColumn.ReadOnly = true;
            view1.Columns["FULLNAME"].ColVIndex = 2;

            RepositoryItemCheckEdit chkConfirm = new RepositoryItemCheckEdit();
            chkConfirm.ValueChecked = "Y";
            chkConfirm.ValueUnchecked = "N";
            chkConfirm.CheckStyle = CheckStyles.Standard;
            chkConfirm.NullStyle = StyleIndeterminate.Unchecked;
            chkConfirm.DisplayFormat.FormatType = FormatType.Custom;
            chkConfirm.CheckedChanged +=new EventHandler(CheckedChanged);
            view1.Columns["IS_ACTIVE"].ColumnEdit = chkConfirm;
            view1.Columns["IS_ACTIVE"].OptionsColumn.AllowSort = DefaultBoolean.False;
            view1.Columns["IS_ACTIVE"].ColVIndex = 3;

            RepositoryItemButtonEdit btn = new RepositoryItemButtonEdit();
            btn.AutoHeight = false;
            btn.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            btn.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete;
            btn.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btn.Buttons[0].Caption = string.Empty;
            btn.Click += new EventHandler(btnDeleteRow_Click);
            view1.Columns["Delete"].Caption = string.Empty;
            view1.Columns["Delete"].ColumnEdit = btn;
            view1.Columns["Delete"].ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            view1.Columns["Delete"].Width = 50;
            view1.Columns["Delete"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            view1.Columns["Delete"].Visible = true;
            view1.Columns["Delete"].ColVIndex = 4;

            view1.Columns["SL"].Caption = "Serial";
            view1.Columns["MEMBER_ID"].Caption = "ID";
            view1.Columns["FULLNAME"].Caption = "Name";
            view1.Columns["IS_ACTIVE"].Caption = "Active";

            int k = 0;
            while(k<view1.Columns.Count)
            {
                view1.Columns[k].BestFit();
                k++;
            }

        }
        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            DataTable tb = new DataTable();
            try
            {
                DataView dv = (DataView)gridControl.DataSource;
                tb = dv.Table.Copy();
            }
            catch (Exception ex)
            {
                tb = (DataTable)gridControl.DataSource;
            }
            if (view1.FocusedRowHandle == view1.RowCount - 1) return;
            //view1.DeleteSelectedRows();
            tb.Rows[view1.FocusedRowHandle].Delete();
            tb.AcceptChanges();
            gridControl.DataSource = tb.Copy().DefaultView;
            //view1.RefreshData();
        }
        private void bs_PositionChanged(object sender, EventArgs e)
        {
            if (bs.Position < 0) return;

            DataTable dt = (DataTable)bs.DataSource;
            DataRow dr = dt.Rows[bs.Position];

            if (dr["IS_ACTIVE"].ToString() == "Y")
                chkActive.Checked = true;
            else
                chkActive.Checked = false;

            switch (dr["GROUP_TYPE"].ToString().Substring(0,1))
            {
                case "R": cmbGroupType.Text = "Radiologist"; break;
                case "T": cmbGroupType.Text = "Technologist"; break;
                case "M": cmbGroupType.Text = "Mixed"; break;
                default:break;
            }

                LoadTableDetail((int)dr["GROUP_ID"]);
            SetGridData();
        }
        private void InitTreeView()
        {
            treeView1.Nodes.Clear();

            ProcessGetManageGroupsTable pgmgt = new ProcessGetManageGroupsTable();
            pgmgt.Invoke();
            DataTable dt = new DataTable();
            dt = pgmgt.DataResult.Tables[0];

            treeView1.Nodes.Add("Radiologist");
            treeView1.Nodes.Add("Technologist");
            treeView1.Nodes.Add("Mix");
            treeView1.Nodes.Add("Other");

            int k = 0;
            while (k < dt.Rows.Count)
            {
                if (dt.Rows[k][5].ToString().Substring(0, 1) == "R")
                {
                    TreeNode treenode = new TreeNode(dt.Rows[k][1] + " - " + dt.Rows[k][2] + " - " + dt.Rows[k][5]);
                    treenode.Tag = dt.Rows[k][0];
                    treeView1.Nodes[0].Nodes.Add(treenode);
                }
                else if (dt.Rows[k][5].ToString().Substring(0, 1) == "T")
                {
                    TreeNode treenode = new TreeNode(dt.Rows[k][1] + " - " + dt.Rows[k][2] + " - " + dt.Rows[k][5]);
                    treenode.Tag = dt.Rows[k][0];
                    treeView1.Nodes[1].Nodes.Add(treenode);
                }
                else if (dt.Rows[k][5].ToString().Substring(0, 1) == "M")
                {
                    TreeNode treenode = new TreeNode(dt.Rows[k][1] + " - " + dt.Rows[k][2] + " - " + dt.Rows[k][5]);
                    treenode.Tag = dt.Rows[k][0];
                    treeView1.Nodes[2].Nodes.Add(treenode);
                }
                else
                {
                    TreeNode treenode = new TreeNode(dt.Rows[k][1] + " - " + dt.Rows[k][2] + " - " + dt.Rows[k][5]);
                    treenode.Tag = dt.Rows[k][0];
                    treeView1.Nodes[3].Nodes.Add(treenode);
                }
                k++;
            }
            treeView1.ExpandAll();
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                string s = e.Node.Tag.ToString();
                DataTable dt = (DataTable)bs.DataSource;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][0].ToString().Trim() == s)
                    {
                        navigator1.BindingSource.Position = i;
                        break;
                    }
                }
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(btnSearch_Clicks);

            string qry = @"
                        select
                            EMP_ID,
	                        EMP_UID,
	                        SALUTATION,
                            FNAME,
                            LNAME
                        from
	                        HR_EMP";

            string fields = "Head ID, Head UID, SALUTATION, FNAME, LNAME";
            string con = "";
            lv.getData(qry, fields, con, "Header Detail List");
            lv.Show();
        }
        private void btnSearch_Clicks(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            //SetTextBoxAutoComplete((Convert.ToInt32(txtOrderDepartment.Tag)));
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtGHeadUID.Text = retValue[0];
            txtGHeadName.Text = retValue[2] + " " + retValue[3] + " " + retValue[4];
            //txtInsurace.Tag = retValue[0];
            //txtInsurace.Text = retValue[2];
            //myOrder.Demographic.InsuranceID = Convert.ToInt32(txtInsurace.Tag);
            //myOrder.Demographic.Insurance_Type = txtInsurace.Text;
        }
        private void EnableControl(bool enable)
        {
            txtGUID.Enabled = enable;
            txtGName.Enabled = enable;
            cmbGroupType.Enabled = enable;
            chkActive.Enabled = enable;
            txtGUsername.Enabled = enable;
            txtGPassword.Enabled = enable;
            txtGHeadUID.Enabled = enable;
            btnSearch.Enabled = enable;
            txtGHeadName.Enabled = enable;
            txtGConNo.Enabled = enable;
            gridControl.Enabled = enable;

            btnCancel.Visible = enable;

            btnAdd.Visible = !enable;
            btnEdit.Visible = !enable;
            btnDelete.Visible = !enable;
            treeView1.Enabled = !enable;
            bindingNavigatorMoveFirstItem.Visible = !enable;
            bindingNavigatorMoveLastItem.Visible = !enable;
            bindingNavigatorMoveNextItem.Visible = !enable;
            bindingNavigatorMovePreviousItem.Visible = !enable;
            bindingNavigatorCountItem.Visible = !enable;
            bindingNavigatorPositionItem.Visible = !enable;
            bindingNavigatorSeparator.Visible = !enable;
            bindingNavigatorSeparator1.Visible = !enable;

        }
        private void ClearControl()
        {
            txtGUID.DataBindings.Clear();
            txtGName.DataBindings.Clear();
            txtGUsername.DataBindings.Clear();
            txtGPassword.DataBindings.Clear();
            txtGConNo.DataBindings.Clear();
            txtGHeadUID.DataBindings.Clear();
            txtGHeadName.DataBindings.Clear();

            txtGUID.Text = "";
            txtGName.Text = "";
            txtGUsername.Text = "";
            txtGPassword.Text = "";
            txtGHeadUID.Text = "";
            txtGHeadName.Text = "";
            txtGConNo.Text = "";
            treeView1.Text = "";

            LoadTableDetail(groupID);
            gridControl.DataSource = ds2.Tables[0].Clone();
            DataRow row = ((DataTable)gridControl.DataSource).NewRow();
            ((DataTable)gridControl.DataSource).Rows.Add(row);
            view1.RefreshData();
        }
        private void CheckedChanged(object sender, EventArgs e)
        {
            DataTable tb;
            try
            {
                tb = ((DataView)gridControl.DataSource).Table;
            }
            catch (Exception ex)
            {
                tb = (DataTable)gridControl.DataSource;
            }

            try
            {
                if (tb.Rows[view1.FocusedRowHandle]["IS_ACTIVE"].ToString() == "Y")
                    tb.Rows[view1.FocusedRowHandle]["IS_ACTIVE"] = "N";
                else if (tb.Rows[view1.FocusedRowHandle]["IS_ACTIVE"].ToString() == "N")
                    tb.Rows[view1.FocusedRowHandle]["IS_ACTIVE"] = "Y";
            } catch (Exception ex) { }
            view1.RefreshData();
        }
        private void MemberID_CloseUp(object sender, CloseUpEventArgs e)
        {
            if (e.Value.ToString().Trim() == string.Empty) return;         
            int viewfocushandle = view1.FocusedRowHandle;
            DataTable tb;
            try
            {
                DataView dv = (DataView)gridControl.DataSource;
                tb = dv.Table;
            }
            catch (Exception ex)
            {
                tb = (DataTable)gridControl.DataSource;
            }

            for (int i = 0; i < view1.RowCount; i++ )
            {
                if (i == view1.FocusedRowHandle) ++i;
                if (i > view1.RowCount - 1) { break; }
                try
                {
                    if (tb.Rows[i]["MEMBER_ID"].ToString() == e.Value.ToString())
                    {
                        e.AcceptValue = false;
                        mmb.ShowAlert("UID2004", 1);
                        return;
                    }
                }
                catch (Exception ex){}
            }

            LoadTableGroupType(cmbGroupType.SelectedIndex);
            DataTable table = ds3.Tables[0];

            foreach (DataRow row in table.Rows)
            {
                if (row["EMP_ID"].ToString() == e.Value.ToString())
                {
                    //DataView vi = (DataView)gridControl.DataSource;
                    //DataTable tb = vi.Table;
                    try{
                    tb.Rows[view1.FocusedRowHandle]["SL"] = view1.FocusedRowHandle + 1;
                    tb.Rows[view1.FocusedRowHandle]["MEMBER_ID"] = e.Value.ToString();
                    tb.Rows[view1.FocusedRowHandle]["FULLNAME"] = row["FULLNAME"].ToString();
                    tb.Rows[view1.FocusedRowHandle]["GROUP_ID"] = groupID;
                    tb.Rows[view1.FocusedRowHandle]["IS_ACTIVE"] = "N";
                    gridControl.DataSource = tb.Copy().DefaultView;
                    view1.RefreshData();
                }
                catch (Exception ex) { e.AcceptValue = false; return; }
                }
            }

            if (view1.RowCount - 1 == viewfocushandle)
            {
                try
                {
                    DataView dv = (DataView)gridControl.DataSource;
                    tb = dv.Table;
                }
                catch (Exception ex)
                {
                    tb = (DataTable)gridControl.DataSource;
                }
                DataRow row = tb.NewRow();
                tb.Rows.Add(row);
                gridControl.DataSource = tb.Copy().DefaultView;
                view1.RefreshData();
            }

            int k = 0;
            while (k < view1.Columns.Count)
            {
                view1.Columns[k].BestFit();
                ++k;
            }
        }
        private void KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == '\b')
                e.Handled = false;
            else
                e.Handled = true;
        }
        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox combobox
                = (System.Windows.Forms.ComboBox)sender;
            LoadTableGroupType(combobox.SelectedIndex);

            RepositoryItemLookUpEdit repositoryItemLookUpEdit1 = new RepositoryItemLookUpEdit();
            repositoryItemLookUpEdit1.TextEditStyle = TextEditStyles.DisableTextEditor;
            repositoryItemLookUpEdit1.ImmediatePopup = true;
            repositoryItemLookUpEdit1.SearchMode = SearchMode.OnlyInPopup;
            repositoryItemLookUpEdit1.AutoHeight = false;
            repositoryItemLookUpEdit1.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("EMP_ID", "Member ID", 20, FormatType.None, "", true, HorzAlignment.Default, ColumnSortOrder.None) });
            repositoryItemLookUpEdit1.DisplayMember = "EMP_ID";
            repositoryItemLookUpEdit1.ValueMember = "EMP_ID";
            repositoryItemLookUpEdit1.DropDownRows = 3;
            repositoryItemLookUpEdit1.DataSource = ds3.Tables[0];
            repositoryItemLookUpEdit1.NullText = string.Empty;
            repositoryItemLookUpEdit1.CloseUp += new CloseUpEventHandler(MemberID_CloseUp);
            view1.Columns["MEMBER_ID"].ColumnEdit = repositoryItemLookUpEdit1;
        }
        private void DropDownClosed(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox combobox
                = (System.Windows.Forms.ComboBox)sender;
            gridControl.DataSource = ds2.Tables[0].Clone();
            DataRow row = ((DataTable)gridControl.DataSource).NewRow();
            ((DataTable)gridControl.DataSource).Rows.Add(row);
            view1.RefreshData();
        }
        private void CheckTreeViewSelected()
        {
            treeView1.SelectedNode = treeView1.Nodes[0].FirstNode;
        }

        #region ControlFirst_Click
        private void btnAdd_Click(object sender, EventArgs e)
        {
            EnableControl(true);
            ClearControl();

            btnSaveAdd.Visible = true;
            btnCancel.Visible = true;

            txtGUID.Focus();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            //if(cmbGroupType.SelectedIndex == 0)
            //{
            //    int k = 0;
            //    while (k < treeView1.Nodes[0].Nodes.Count)
            //    {
            //        if (treeView1.Nodes[0].Nodes[k].Tag.ToString() == groupID.ToString())
            //        {
            //            object s = new object();
            //            TreeViewEventArgs ee = new TreeViewEventArgs(treeView1.Nodes[0].Nodes[k]);
            //            treeView1_AfterSelect(s, ee);
            //            break;
            //        }
            //        ++k;
            //    }
            //}
            //else if (cmbGroupType.SelectedIndex == 1)
            //{ 
            
            //}
            //else if (cmbGroupType.SelectedIndex == 2)
            //{ 
            
            //}
            if (treeView1.SelectedNode == null)
            { CheckTreeViewSelected(); }

            if (treeView1.SelectedNode == null ||
                treeView1.SelectedNode.Text == "Technologist" ||
                treeView1.SelectedNode.Text == "Radiologist" ||
                treeView1.SelectedNode.Text == "Mix" ||
                treeView1.SelectedNode.Text == "Other")
            { mmb.ShowAlert("UID2005", 1); return; }

            EnableControl(true);

            cmbGroupType.Enabled = false;
            btnSaveEdit.Visible = true;
            btnCancel.Visible = true;

            DataTable tb;
            try
            {
                DataView dv = (DataView)gridControl.DataSource;
                tb = dv.Table;
            }
            catch (Exception)
            {
                tb = (DataTable)gridControl.DataSource;
            }
            DataRow row = tb.NewRow();
            tb.Rows.Add(row);
            view1.RefreshData();

            txtGUID.Focus();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(treeView1.SelectedNode == null)
            { CheckTreeViewSelected(); }

            if (treeView1.SelectedNode == null ||
                treeView1.SelectedNode.Text == "Technologist" ||
                treeView1.SelectedNode.Text == "Radiologist" ||
                treeView1.SelectedNode.Text == "Mix" ||
                treeView1.SelectedNode.Text == "Other")
            { mmb.ShowAlert("UID2006", 1); return; }

            DataTable tb = (DataTable)bs.DataSource;
            groupID = (int)tb.Rows[bs.Position]["GROUP_ID"];
            string str = mmb.ShowAlert("UID2003", 1);
            if(str == "2")
                SaveDelete();
            return;

            btnAdd.Visible = false;
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            treeView1.Enabled = false;
            bindingNavigatorMoveFirstItem.Visible = false;
            bindingNavigatorMoveLastItem.Visible = false;
            bindingNavigatorMoveNextItem.Visible = false;
            bindingNavigatorMovePreviousItem.Visible = false;
            bindingNavigatorCountItem.Visible = false;
            bindingNavigatorPositionItem.Visible = false;
            bindingNavigatorSeparator.Visible = false;
            bindingNavigatorSeparator1.Visible = false;

            btnSaveDelete.Visible = true;
            btnCancel.Visible = true;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                int index = tabControl.SelectedIndex;
                tabControl.TabPages.RemoveAt(index);
            }
            catch (Exception ex)
            {
                this.Close();
            }
        }
        #endregion

        #region ControlSecond_Click
        private void btnSaveAdd_Click(object sender, EventArgs e)
        {
            if (view1.RowCount <= 1) { string str = mmb.ShowAlert("UID2001", 1); return; }
            if (txtGUID.Text == "" || txtGName.Text == "" || txtGUsername.Text == "" ||
                txtGPassword.Text == "" || txtGHeadUID.Text == "" ||
                txtGHeadName.Text == "" || txtGConNo.Text == "")
            {
                string str = mmb.ShowAlert("UID2001", 1); return;
            }

            DataTable tb = (DataTable)bs.DataSource;
            try{groupID = (int)tb.Rows[bs.Position]["GROUP_ID"];}catch (Exception ex) { }
            txtGUID.DataBindings.Clear();
            txtGName.DataBindings.Clear();
            txtGUsername.DataBindings.Clear();
            txtGPassword.DataBindings.Clear();
            txtGConNo.DataBindings.Clear();
            txtGHeadUID.DataBindings.Clear();
            txtGHeadName.DataBindings.Clear();
            SaveAdd();
        }
        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            if (view1.RowCount <= 1) { string str = mmb.ShowAlert("UID2001", 1); return; }
            if (txtGUID.Text == "" || txtGName.Text == "" || txtGUsername.Text == "" ||
                txtGPassword.Text == "" || txtGHeadUID.Text == "" ||
                txtGHeadName.Text == "" || txtGConNo.Text == "")
            {
                string str = mmb.ShowAlert("UID2001", 1); return;
            }
            DataTable tb = (DataTable)bs.DataSource;
            groupID = (int)tb.Rows[bs.Position]["GROUP_ID"];
            SaveEdit();
        }
        private void btnSaveDelete_Click(object sender, EventArgs e)
        {
            DataTable tb = (DataTable)bs.DataSource;
            groupID = (int)tb.Rows[bs.Position]["GROUP_ID"];
            SaveDelete();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            EnableControl(false);
            btnSaveAdd.Visible = false;
            btnSaveEdit.Visible = false;
            btnSaveDelete.Visible = false;

            navigator1.BindingSource.Position = bs.Position;
            gridControl.DataSource = ds2.Tables[0].DefaultView;
            DataTable tb = (DataTable)bs.DataSource;
            try{
            switch (tb.Rows[bs.Position]["GROUP_TYPE"].ToString().Substring(0, 1))
            {
                case "R": cmbGroupType.Text = "Radiologist"; break;
                case "T": cmbGroupType.Text = "Technologist"; break;
                case "M": cmbGroupType.Text = "Mixed"; break;
                default: break;
            } }catch (Exception ex) { }

            LoadAll(groupID);
            SetNavigator();
            TextBinding();
            SetGridData();

            //InitTreeView();
        }
        #endregion

        #region ControlMethodOperator
        private void SaveAdd()
        {
            DataTable tb;
            try
            {
                tb = (DataTable)gridControl.DataSource;
            }
            catch (Exception ex)
            {
                DataView dv = (DataView)gridControl.DataSource;
                tb = dv.Table;
            }

            ManageGroups manage = new ManageGroups();
            ProcessAddManageGroups processMas = new ProcessAddManageGroups();

            manage.GROUP_UID = txtGUID.Text;
            manage.GROUP_NAME = txtGName.Text;
            manage.GROUP_USER_NAME = txtGUsername.Text;
            manage.GROUP_PASS = txtGPassword.Text;
            manage.GROUP_TYPE = cmbGroupType.Text;
            manage.GROUP_HEAD = int.Parse(txtGHeadUID.Text);
            manage.GROUP_HEAD_NAME = txtGHeadName.Text;
            manage.GROUP_CONTACT_NO = int.Parse(txtGConNo.Text);

            if (chkActive.Checked == true)
                manage.IS_ACTIVE = "Y";
            else
                manage.IS_ACTIVE = "N";

            processMas.ManageGroups = manage;
            processMas.Invoke();


            ProcessGetManageGroupsTable processGet = new ProcessGetManageGroupsTable();
            processGet.Invoke();

            ProcessAddManageGroupsDtl processDtl = new ProcessAddManageGroupsDtl();
            foreach(DataRow row in tb.Rows)
            {
                if (row != null && row["MEMBER_ID"].ToString() != "")
                {
                    manage.GROUP_ID = (int)processGet.DataResult.Tables[0].Rows[processGet.DataResult.Tables[0].Rows.Count-1]["GROUP_ID"];
                    manage.MEMBER_ID = (int)row["MEMBER_ID"];
                    manage.SL = (byte)row["SL"];
                    manage.IS_ACTIVE = row["IS_ACTIVE"].ToString();
                    processDtl.ManageGroups = manage;
                    processDtl.Invoke();
                }
            }

            groupID = (int)processGet.DataResult.Tables[0].Rows[processGet.DataResult.Tables[0].Rows.Count - 1]["GROUP_ID"];

            Refresh();
            bs.Position = processGet.DataResult.Tables[0].Rows.Count;
        }
        private void SaveEdit()
        {
            DataView dv = (DataView)gridControl.DataSource;
            DataTable tb = dv.Table;

            ManageGroups manage = new ManageGroups();

            ProcessUpdateManageGroups processUpd = new ProcessUpdateManageGroups();
            manage.GROUP_ID = groupID;
            manage.GROUP_UID = txtGUID.Text;
            manage.GROUP_NAME = txtGName.Text;
            manage.GROUP_USER_NAME = txtGUsername.Text;
            manage.GROUP_PASS = txtGPassword.Text;
            manage.GROUP_TYPE = cmbGroupType.Text;
            manage.GROUP_HEAD = int.Parse(txtGHeadUID.Text);
            manage.GROUP_HEAD_NAME = txtGHeadName.Text;
            manage.GROUP_CONTACT_NO = int.Parse(txtGConNo.Text);
            if (chkActive.Checked == true)
                manage.IS_ACTIVE = "Y";
            else
                manage.IS_ACTIVE = "N";
            processUpd.ManageGroups = manage;
            processUpd.Invoke();

            ProcessDeleteManageGroupsDtl processDel = new ProcessDeleteManageGroupsDtl();
            manage.GROUP_ID = groupID;
            processDel.ManageGroups = manage;
            processDel.Invoke();


            ProcessAddManageGroupsDtl processDtl = new ProcessAddManageGroupsDtl();
            foreach (DataRow row in tb.Rows)
            {
                try
                {
                    if (row != null && row["MEMBER_ID"].ToString() != "")
                    {
                        manage.GROUP_ID = groupID;
                        manage.MEMBER_ID = (int)row["MEMBER_ID"];
                        manage.SL = (byte)row["SL"];
                        manage.IS_ACTIVE = row["IS_ACTIVE"].ToString();
                        processDtl.ManageGroups = manage;
                        processDtl.Invoke();
                    }
                }catch (Exception ex) { }
            }

            Refresh();
        }
        private void SaveDelete()
        {
            ManageGroups manage = new ManageGroups();

            ProcessDeleteManageGroups processDel = new ProcessDeleteManageGroups();
            manage.GROUP_ID = groupID;
            processDel.ManageGroups = manage;
            processDel.Invoke();

            Refresh();
        }
        private void Refresh()
        {
            EnableControl(false);
            btnSaveAdd.Visible = false;
            btnSaveEdit.Visible = false;
            btnSaveDelete.Visible = false;

            LoadAll(groupID);
            SetNavigator();
            TextBinding();
            SetGridData();

            InitTreeView();
        }
        #endregion

        private void txtGUID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
                txtGName.Focus();
        }
        private void txtGName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                chkActive.Focus();
        }
        private void chkActive_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                txtGUsername.Focus();
        }
        private void txtGUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                txtGPassword.Focus();
        }
        private void txtGPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnSearch.Focus();
        }
    }
}