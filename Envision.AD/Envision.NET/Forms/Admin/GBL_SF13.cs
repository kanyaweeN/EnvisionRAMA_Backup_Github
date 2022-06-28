using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.Common;

using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;

namespace Envision.NET.Forms.Admin
{
    public partial class GBL_SF13 : Envision.NET.Forms.Main.MasterForm
    {
        //private DBUtility dbu;
        //private UUL.ControlFrame.Controls.TabControl CloseControl;
        private MyMessageBox mmb = new MyMessageBox();
        private int startwith;
        private GBLEnvVariable env = new GBLEnvVariable();
        private List<string> statuslist = new List<string>();
        private int[] grantroleid;

        private int _empid;
        private string _empuid;
        private string _empname;
        private int _roleid;
        public int EMPID
        {
            get { return _empid; }
            set { _empid = value; }
        }
        public string EMPUID
        {
            get { return _empuid; }
            set { _empuid = value; }
        }
        public string EMPNAME
        {
            get { return _empname; }
            set { _empname = value; }
        }
        public int ROLEID
        {
            get { return _roleid; }
            set { _roleid = value; }
        }

        public GBL_SF13(int empid, string empuid, string empname)
        {
            InitializeComponent();
            EMPID = empid;
            EMPUID = empuid;
            EMPNAME = empname;
            startwith = 1;
        }
        //public GBL_SF13(UUL.ControlFrame.Controls.TabControl closecontrol)
        //{
        //    InitializeComponent();
        //    CloseControl = closecontrol;
        //    startwith = 2;
        //}
        public GBL_SF13()
        {
            InitializeComponent();
            //CloseControl = closecontrol;
            startwith = 2;
        }

        private void GBL_SF13_Load(object sender, EventArgs e)
        {
            if (startwith == 1)
            {
                txtEmpID.Text = EMPID.ToString();
                txtEmpUID.Text = EMPUID;
                txtEmpName.Text = EMPNAME;
                txtGrantor.Text = new GBLEnvVariable().UserID.ToString();
                xtraTabControl1.SelectedTabPageIndex = 0;
                SetGridControl(startwith);
            }
            else if (startwith == 2)
            {
                txtRoleID.Text = "1";
                txtRoleUID.Text = "ADM001";
                txtRoleName.Text = "Admin";
                txtGrantor.Text = new GBLEnvVariable().UserID.ToString();
                xtraTabControl1.SelectedTabPageIndex = 1;
                SetGridControl(startwith);
            }

            xtraTabControl1.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(xtraTabControl1_SelectedPageChanged);
            base.CloseWaitDialog();
        }

        private void SetGridControl(int _startwith)
        {
            if (_startwith == 1)
            {
                view1.Columns.Clear();
                GBL_GRANTROLE grantrole = new GBL_GRANTROLE();
                ProcessGetGBLGrantRoleByEmployee processget = new ProcessGetGBLGrantRoleByEmployee();
                grantrole.EMP_ID = EMPID;
                processget.GBL_GRANTROLE = grantrole;
                processget.Invoke();
                processget.DataResult.Tables[0].Columns.Add("RoleStatus");
                gridControl1.DataSource = processget.DataResult.Tables[0].Copy();

                RepositoryItemCheckEdit chkConfirm = new RepositoryItemCheckEdit();
                chkConfirm.ValueChecked = "Y";
                chkConfirm.ValueUnchecked = "N";
                chkConfirm.CheckStyle = CheckStyles.Standard;
                chkConfirm.NullStyle = StyleIndeterminate.Unchecked;
                chkConfirm.DisplayFormat.FormatType = FormatType.Custom;
                chkConfirm.CheckedChanged += new EventHandler(chkConfirm_CheckedChanged);
                //view1.Columns["RoleStatus"].ColumnEdit = (RepositoryItemCheckEdit)chkConfirm;
                view1.Columns["RoleStatus"].ColumnEdit = chkConfirm;

                ProcessGetGBLGrantRole processget2 = new ProcessGetGBLGrantRole();
                processget2.Invoke();

                int k = 0;
                grantroleid = new int[((DataTable)gridControl1.DataSource).Rows.Count];
                foreach (DataRow row in ((DataTable)gridControl1.DataSource).Rows)
                {
                    ((DataTable)gridControl1.DataSource).Rows[k]["RoleStatus"] = "N";
                    foreach (DataRow row2 in processget2.DataResult.Tables[0].Rows)
                    {
                        if (EMPID.ToString() == row2["EMP_ID"].ToString() &&
                            row["ROLE_ID"].ToString() == row2["ROLE_ID"].ToString())
                        {
                            ((DataTable)gridControl1.DataSource).Rows[k]["RoleStatus"] = "Y";
                            grantroleid[k] = int.Parse(row2["GRANTROLE_ID"].ToString());
                            break;
                        }
                    }
                    k++;
                }

                k = 0;
                while (k < view1.Columns.Count)
                {
                    view1.Columns[k].BestFit();
                    view1.Columns[k].OptionsColumn.AllowEdit = false;
                    k++;
                }
                view1.Columns["RoleStatus"].OptionsColumn.AllowEdit = true;

                k = 0;
                statuslist.Clear();
                while (k < ((DataTable)gridControl1.DataSource).Rows.Count)
                {
                    statuslist.Add(((DataTable)gridControl1.DataSource).Rows[k]["RoleStatus"].ToString());
                    k++;
                }

                view1.Columns["ROLE_ID"].Caption = "Role ID";
                view1.Columns["ROLE_UID"].Caption = "Role UID";
                view1.Columns["ROLE_NAME"].Caption = "Role Name";
                view1.Columns["ROLE_NAME"].Width = 200;

            }
            else if (_startwith == 2)
            {
                GBL_GRANTROLE grantrole = new GBL_GRANTROLE();
                ProcessGetGBLGrantRoleByRole processget = new ProcessGetGBLGrantRoleByRole();
                try
                { grantrole.ROLE_ID = int.Parse(txtRoleID.Text); }
                catch (Exception ex)
                { btnRoleSearch_Click(new object(), new EventArgs()); }
                processget.GBL_GRANTROLE = grantrole;
                processget.Invoke();
                processget.DataResult.Tables[0].Columns.Add("EmployeeSelect", typeof(string));

                view1.Columns.Clear();
                gridControl1.DataSource = processget.DataResult.Tables[0].Copy();
                RepositoryItemCheckEdit chkConfirm = new RepositoryItemCheckEdit();
                chkConfirm.ValueChecked = "Y";
                chkConfirm.ValueUnchecked = "N";
                chkConfirm.CheckStyle = CheckStyles.Standard;
                chkConfirm.NullStyle = StyleIndeterminate.Unchecked;
                chkConfirm.DisplayFormat.FormatType = FormatType.Custom;
                chkConfirm.CheckedChanged += new EventHandler(chkConfirm_CheckedChanged);
                view1.Columns["EmployeeSelect"].ColumnEdit = chkConfirm;

                int k = 0;
                while (k < ((DataTable)gridControl1.DataSource).Rows.Count)
                {
                    ((DataTable)gridControl1.DataSource).Rows[k]["EmployeeSelect"] = "Y";
                    k++;
                }

                k = 0;
                while (k < view1.Columns.Count)
                {
                    view1.Columns[k].BestFit();
                    view1.Columns[k].OptionsColumn.AllowEdit = false;
                    k++;
                }
                view1.Columns["GRANTROLE_ID"].Visible = false;
                view1.Columns["EmployeeSelect"].OptionsColumn.AllowEdit = true;

                k = 0;
                statuslist.Clear();
                while (k < ((DataTable)gridControl1.DataSource).Rows.Count)
                {
                    statuslist.Add(((DataTable)gridControl1.DataSource).Rows[k]["EmployeeSelect"].ToString());
                    k++;
                }

                view1.Columns["EMP_ID"].Caption = "Employee ID";
                view1.Columns["EMP_UID"].Caption = "Employee UID";
                view1.Columns["NAME"].Caption = "Employee Name";

                k = 0;
                while (k < view1.Columns.Count)
                {
                    view1.Columns[k].BestFit();
                    k++;
                }
            }
        }
        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            int pageselected = e.Page.TabControl.SelectedTabPageIndex;

            if (pageselected == 0)
            {
                startwith = 1;
                try
                {
                    EMPID = int.Parse(txtEmpID.Text);
                }
                catch (Exception ex)
                {
                    gridControl1.DataSource = new DataTable();
                    view1.RefreshData();
                    btnEMPSearch_Click(new object(), new EventArgs());
                    return;
                }
                SetGridControl(startwith);
            }
            else
            {
                startwith = 2;
                SetGridControl(startwith);
            }
        }
        private void chkConfirm_CheckedChanged(object sender, EventArgs e)
        {
            //DevExpress.XtraEditors.CheckEdit obj = (DevExpress.XtraEditors.CheckEdit)sender;
            //int rowIndex = view1.FocusedRowHandle;
            //DataTable dtt = (DataTable)gridControl1.DataSource;
            //try
            //{
            //    dtt.Rows[rowIndex]["EmployeeSelect"] = obj.EditValue;
            //}
            //catch (Exception EX)
            //{
            //    dtt.Rows[rowIndex]["RoleStatus"] = obj.EditValue;
            //}
            //gridControl1.DataSource = dtt;

            if (view1.FocusedRowHandle < 0) return;

            DevExpress.XtraEditors.CheckEdit obj = (DevExpress.XtraEditors.CheckEdit)sender;
            DataRow row = view1.GetDataRow(view1.FocusedRowHandle);

            DataTable dtt = (DataTable)gridControl1.DataSource;
            int rowPosi = dtt.Rows.IndexOf(row);
            try
            {
                dtt.Rows[rowPosi]["RoleStatus"] = obj.EditValue;
            }
            catch (Exception EX)
            {
            }
            dtt.AcceptChanges();
            gridControl1.DataSource = dtt;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    int index = CloseControl.SelectedIndex;
            //    CloseControl.TabPages.RemoveAt(index);
            //}
            //catch (Exception ex)
            //{
            //    this.Close();
            //}
            this.Close();
        }
        private void btnEmpSave_Click(object sender, EventArgs e)
        {
            if (txtEmpID.Text == "")// || txtEmpName.Text == "" || txtEmpUID.Text == "")
            {//MessageBox.Show("กรุณาเลือกบุคคลที่ต้องการแสดง Grantrole ด้วย \r\n โดยการคลิกที่ ปุ่ม \"...\"");
                mmb.ShowAlert("UID2007", 1); return;
            }

            DataTable dt = (DataTable)gridControl1.DataSource;

            int k = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (row["RoleStatus"].ToString() == "Y" && statuslist[k] == "Y")
                {

                }
                else if (row["RoleStatus"].ToString() == "Y" && statuslist[k] == "N")
                {
                    GBL_GRANTROLE grantrole = new GBL_GRANTROLE();
                    ProcessAddGBLGrantRoleByEmployee processadd = new ProcessAddGBLGrantRoleByEmployee();
                    grantrole.ROLE_ID = int.Parse(row["ROLE_ID"].ToString());
                    grantrole.EMP_ID = int.Parse(txtEmpID.Text);
                    grantrole.GRANTOR = new GBLEnvVariable().UserID;
                    grantrole.ORG_ID = new GBLEnvVariable().OrgID;
                    processadd.GBL_GRANTROLE = grantrole;
                    processadd.Invoke();
                }
                else if (row["RoleStatus"].ToString() == "N" && statuslist[k] == "Y")
                {
                    GBL_GRANTROLE grantrole = new GBL_GRANTROLE();
                    ProcessUpdateGBLGrantRoleISDeleted processupdate = new ProcessUpdateGBLGrantRoleISDeleted();
                    grantrole.GRANTROLE_ID = grantroleid[k];
                    processupdate.GBL_GRANTROLE = grantrole;
                    processupdate.Invoke();
                }
                else if (row["RoleStatus"].ToString() == "N" && statuslist[k] == "N")
                {

                }
                ++k;
            }

            xtraTabControl1.SelectedTabPageIndex = 0;
            SetGridControl(startwith);

            mmb.ShowAlert("UID2002", 1);

            this.Close();
        }
        private void btnRoleSave_Click(object sender, EventArgs e)
        {
            if (txtRoleID.Text == "" || txtRoleName.Text == "" || txtRoleUID.Text == "")
            { //MessageBox.Show("กรุณาเลือก role ด้วย \r\n โดยการคลิกที่ ปุ่ม \"...\""); 
                mmb.ShowAlert("UID2007", 1); return;
            }

            DataTable dt = (DataTable)gridControl1.DataSource;

            int k = 0;
            foreach (DataRow row in dt.Rows)
            {

                if (row["EmployeeSelect"].ToString() == "Y" && statuslist[k] == "Y")
                {

                }
                else if (row["EmployeeSelect"].ToString() == "Y" && statuslist[k] == "N")
                {

                }
                else if (row["EmployeeSelect"].ToString() == "N" && statuslist[k] == "Y")
                {
                    GBL_GRANTROLE grantrole = new GBL_GRANTROLE();
                    ProcessUpdateGBLGrantRoleISDeleted processupdate = new ProcessUpdateGBLGrantRoleISDeleted();
                    grantrole.GRANTROLE_ID = int.Parse(row["GRANTROLE_ID"].ToString());
                    processupdate.GBL_GRANTROLE = grantrole;
                    processupdate.Invoke();
                }
                else if (row["EmployeeSelect"].ToString() == "N" && statuslist[k] == "N")
                {

                }
                ++k;
            }

            xtraTabControl1.SelectedTabPageIndex = 1;
            SetGridControl(startwith);

            mmb.ShowAlert("UID2002", 1);

            this.Close();
        }


        private void btnEMPSearch_Click(object sender, EventArgs e)
        {

//            LookupData lv = new LookupData();
//            lv.ValueUpdated += new ValueUpdatedEventHandler(btnEMPSearch_Clicks);

//            string qry = @"
//                        select
//                            EMP_ID,
//	                        EMP_UID,
//	                        ISNULL(SALUTATION,'')+' '+ISNULL(FNAME,'')+' '+ISNULL(MNAME,'')+' '+ISNULL(LNAME,'') AS NAME
//                        from
//	                        HR_EMP
//                        where
//                            ( EMP_ID like '%%' OR
//                            EMP_UID like '%%' OR
//                            SALUTATION like '%%' OR
//                            FNAME like '%%' OR
//                            MNAME like '%%' OR
//                            LNAME like '%%' )
//                            AND ( is_active = 'Y' )
//                        order by EMP_ID asc";

//            string fields = "Emp ID, Emp UID, Emp Name";
//            string con = "";
//            lv.getData(qry, fields, con, "Employee Detail List");
//            lv.Show();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(btnEMPSearch_Clicks);
            lv.AddColumn("EMP_ID", "ID", false, true);
            lv.AddColumn("EMP_UID", "Code", true, true);
            lv.AddColumn("FullName", "Name", true, true);
            lv.Text = "User Account Search";

            ProcessGetHREmp hr = new ProcessGetHREmp();
            hr.HR_EMP.MODE = "All";
            hr.HR_EMP.EMP_ID = 0;
            hr.HR_EMP.USER_NAME = "";
            hr.HR_EMP.UNIT_ID = 0;
            hr.HR_EMP.AUTH_LEVEL_ID = 0;
            hr.Invoke();

            lv.Data = hr.Result.Tables[0].Copy();//dtClinic;
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void btnEMPSearch_Clicks(object sender, ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtEmpID.Text = retValue[0];
            txtEmpUID.Text = retValue[1];
            txtEmpName.Text = retValue[2];

            startwith = 1;
            EMPID = int.Parse(txtEmpID.Text);
            SetGridControl(startwith);

        }
        private void btnRoleSearch_Click(object sender, EventArgs e)
        {
//            Envision.NET.Forms.Dialog.LookupData lv = new Envision.NET.Forms.Dialog.LookupData();
//            lv.ValueUpdated += new ValueUpdatedEventHandler(btnRoleSearch_Clicks);

//            string qry = @"
//                        select
//	                        ROLE_ID,
//	                        ROLE_UID,
//                            ROLE_NAME
//                        from
//	                        GBL_ROLE
//                        where
//                            ( ROLE_ID like '%%' OR
//                            ROLE_UID like '%%' OR
//                            ROLE_NAME like '%%' )
//                            AND ( is_active = 'Y' )";

//            string fields = "Role ID, Role UID, Role Name";
//            string con = "";
//            lv.getData(qry, fields, con, "Select Role Detail List");
//            lv.Show();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(btnRoleSearch_Clicks);
            lv.AddColumn("ROLE_ID", "ID", false, true);
            lv.AddColumn("ROLE_UID", "Code", true, true);
            lv.AddColumn("ROLE_NAME", "Name", true, true);
            lv.Text = "Role Search";

            ProcessGetGBLRole gb = new ProcessGetGBLRole();
            DataTable tb = gb.SelectData(11);

            lv.Data = tb.Copy();
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void btnRoleSearch_Clicks(object sender, ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtRoleID.Text = retValue[0];
            txtRoleUID.Text = retValue[1];
            txtRoleName.Text = retValue[2];

            startwith = 2;
            SetGridControl(startwith);

        }
    }
}