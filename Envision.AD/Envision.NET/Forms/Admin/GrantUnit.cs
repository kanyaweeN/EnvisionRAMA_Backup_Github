using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;
using Envision.Common;
using Envision.NET.Forms;
using Envision.BusinessLogic;
using Envision.NET.Forms.Dialog;
using Envision.NET.Forms.Main;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessDelete;

namespace Envision.NET.Forms.Admin
{
    public partial class GrantUnit : MasterForm//Form
    {
        //private DBUtility dbu;
        //private UUL.ControlFrame.Controls.TabControl CloseControl;
        private MyMessageBox mmb = new MyMessageBox();
        private int startwith;
        private GBLEnvVariable env = new GBLEnvVariable();
        private List<string> statuslist = new List<string>();
        private int unit_id = 0;

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

        public GrantUnit(int empid, string empuid, string empname)
        {
            InitializeComponent();
            EMPID = empid;
            EMPUID = empuid;
            EMPNAME = empname;
            startwith = 1;
            this.Load +=new EventHandler(GrantUnit_Load);
        }
        public GrantUnit()//UUL.ControlFrame.Controls.TabControl closecontrol)
        {
            InitializeComponent();
            //CloseControl = closecontrol;
            startwith = 2;
            this.Load += new EventHandler(GrantUnit_Load);
        }
        public GrantUnit(int empid, string empuid, string empname, int unit)
        {
            InitializeComponent();
            EMPID = empid;
            EMPUID = empuid;
            EMPNAME = empname;
            startwith = 1;
            this.Load += new EventHandler(GrantUnit_Load);
            unit_id = unit;
        }

        private void GrantUnit_Load(object sender, EventArgs e)
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
                txtUnitID.Text = "1";
                txtUnitUID.Text = "ADM001";
                txtUnitName.Text = "Admin";
                txtGrantor.Text = new GBLEnvVariable().UserID.ToString();
                xtraTabControl1.SelectedTabPageIndex = 1;
                SetGridControl(startwith);
            }

            xtraTabControl1.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(xtraTabControl1_SelectedPageChanged);
            btnEmpSave.Click += new EventHandler(btnEmpSave_Click);
            btnRoleSave.Click += new EventHandler(btnRoleSave_Click);
            btnClose1.Click += new EventHandler(btnClose_Click);
            btnClose2.Click +=new EventHandler(btnClose_Click);
            btnSearchEmployee.Click += new EventHandler(btnSearchEmployee_Click);
            btnSearchUnit.Click += new EventHandler(btnSearchUnit_Click);
        }

        private void SetGridControl(int startwith)
        {
            if (startwith == 1)
            {
                view1.Columns.Clear();
                ProcessGetRISUserorgmap processget = new ProcessGetRISUserorgmap();
                //processget.RISUserorgmap.EMP_ID = EMPID;
                processget.RIS_USERORGMAP.MODE = 1;
                processget.Invoke();
                processget.Result.Tables[0].Columns.Add("UnitStatus");
                gridControl1.DataSource = processget.Result.Tables[0].Copy();

                RepositoryItemCheckEdit chkConfirm = new RepositoryItemCheckEdit();
                chkConfirm.ValueChecked = "Y";
                chkConfirm.ValueUnchecked = "N";
                chkConfirm.CheckStyle = CheckStyles.Standard;
                chkConfirm.NullStyle = StyleIndeterminate.Unchecked;
                chkConfirm.DisplayFormat.FormatType = FormatType.Custom;
                chkConfirm.CheckedChanged += new EventHandler(chkConfirm_CheckedChanged);           //view1.Columns["RoleStatus"].ColumnEdit = (RepositoryItemCheckEdit)chkConfirm;
                view1.Columns["UnitStatus"].ColumnEdit = chkConfirm;

                ProcessGetRISUserorgmap processget2 = new ProcessGetRISUserorgmap();
                processget2.RIS_USERORGMAP.MODE = 2;
                processget2.Invoke();

                foreach (DataRow row in ((DataTable)gridControl1.DataSource).Rows)
                {
                    row["UnitStatus"] = "N";
                    //foreach (DataRow row2 in processget2.Result.Tables[0].Rows)
                    //{
                    //    if (EMPID.ToString() == row2["EMP_ID"].ToString() &&
                    //        (row["UNIT_ID"].ToString() == row2["UNIT_ID"].ToString())
                    //        )
                    //    {
                    //        row["UnitStatus"] = "Y";
                    //        break;
                    //    }
                    //}
                    DataRow[] drs = processget2.Result.Tables[0].Select("EMP_ID=" + EMPID.ToString() + " and UNIT_ID="+row["UNIT_ID"].ToString());
                    if(drs.Length>0)
                        row["UnitStatus"] = "Y";
                }

                int k = 0;
                while (k < view1.Columns.Count)
                {
                    //view1.Columns[k].BestFit();
                    view1.Columns[k].OptionsColumn.AllowEdit = false;
                    k++;
                }
                view1.Columns["UnitStatus"].OptionsColumn.AllowEdit = true;

                view1.Columns["UNIT_ID"].ColVIndex = 1;
                view1.Columns["UNIT_ID"].Caption = "Unit ID";
                view1.Columns["UNIT_ID"].Width = 75;

                view1.Columns["UNIT_UID"].ColVIndex = 2;
                view1.Columns["UNIT_UID"].Caption = "Unit UID";
                view1.Columns["UNIT_UID"].Width = 75;

                view1.Columns["UNIT_NAME"].ColVIndex = 3;
                view1.Columns["UNIT_NAME"].Caption = "Unit Name";
                view1.Columns["UNIT_NAME"].Width = 200;

                view1.Columns["UnitStatus"].ColVIndex = 4;
                view1.Columns["UnitStatus"].Caption = "";
                view1.Columns["UnitStatus"].Width = 50;

                k = 0;
                statuslist.Clear();
                while (k < ((DataTable)gridControl1.DataSource).Rows.Count)
                {
                    statuslist.Add(((DataTable)gridControl1.DataSource).Rows[k]["UnitStatus"].ToString());
                    k++;
                }

                foreach (DataRow row in ((DataTable)gridControl1.DataSource).Rows)
                {
                    if (row["UNIT_ID"].ToString() == unit_id.ToString())
                        row["UnitStatus"] = "Y";
                }

            }
            else if (startwith == 2)
            {
                ProcessGetRISUserorgmap processget = new ProcessGetRISUserorgmap();
                try
                { processget.RIS_USERORGMAP.UNIT_ID = int.Parse(txtUnitID.Text); }
                catch (Exception ex)
                { btnSearchUnit_Click(new object(), new EventArgs()); }
                processget.RIS_USERORGMAP.MODE = 3;
                processget.Invoke();
                processget.Result.Tables[0].Columns.Add("EmployeeSelect", typeof(string));

                view1.Columns.Clear();
                gridControl1.DataSource = processget.Result.Tables[0].Copy();
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
                    //view1.Columns[k].BestFit();
                    view1.Columns[k].OptionsColumn.AllowEdit = false;
                    k++;
                }
                view1.Columns["EmployeeSelect"].OptionsColumn.AllowEdit = true;

                view1.Columns["EMP_ID"].ColVIndex = 1;
                view1.Columns["EMP_ID"].Caption = "Employee ID";
                view1.Columns["EMP_ID"].Width = 75;

                view1.Columns["EMP_UID"].ColVIndex = 2;
                view1.Columns["EMP_UID"].Caption = "Employee UID";
                view1.Columns["EMP_UID"].Width = 75;

                view1.Columns["FULLNAME"].ColVIndex = 3;
                view1.Columns["FULLNAME"].Caption = "Employee Name";
                view1.Columns["FULLNAME"].Width = 200;

                view1.Columns["EmployeeSelect"].ColVIndex = 4;
                view1.Columns["EmployeeSelect"].Caption = "";
                view1.Columns["EmployeeSelect"].Width = 50;

                k = 0;
                statuslist.Clear();
                while (k < ((DataTable)gridControl1.DataSource).Rows.Count)
                {
                    statuslist.Add(((DataTable)gridControl1.DataSource).Rows[k]["EmployeeSelect"].ToString());
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
                    btnSearchEmployee_Click(new object(), new EventArgs());
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
            //    dtt.Rows[rowIndex]["UnitStatus"] = obj.EditValue;
            //}
            //gridControl1.DataSource = dtt;

            if(view1.FocusedRowHandle < 0) return;

            DevExpress.XtraEditors.CheckEdit obj = (DevExpress.XtraEditors.CheckEdit)sender;
            DataRow row = view1.GetDataRow(view1.FocusedRowHandle);

            DataTable dtt = (DataTable)gridControl1.DataSource;
            int rowPosi = dtt.Rows.IndexOf(row);
            try
            {
                dtt.Rows[rowPosi]["UnitStatus"] = obj.EditValue;
            }
            catch (Exception EX)
            {
            }

            dtt.AcceptChanges();
            gridControl1.DataSource = dtt;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                //int index = CloseControl.SelectedIndex;
                //CloseControl.TabPages.RemoveAt(index);
                this.Close();
            }
            catch (Exception ex)
            {
                this.Close();
            }
        }
        private void btnEmpSave_Click(object sender, EventArgs e)
        {
            if (txtEmpID.Text == "")// || txtEmpName.Text == "" || txtEmpUID.Text == "")
            {//MessageBox.Show("กรุณาเลือกบุคคลที่ต้องการแสดง Grantrole ด้วย \r\n โดยการคลิกที่ ปุ่ม \"...\"");
                mmb.ShowAlert("UID2007", 1); return;
            }

            #region oldCode

            //int k = 0;
            //while (k < view1.RowCount)
            //{
            //    DataRow row = view1.GetDataRow(k);

            //    if (row["UnitStatus"].ToString() == "Y" && statuslist[k] == "Y")
            //    {

            //    }
            //    else if (row["UnitStatus"].ToString() == "Y" && statuslist[k] == "N")
            //    {
            //        ProcessAddRISUserorgmap processadd = new ProcessAddRISUserorgmap();
            //        processadd.RISUserorgmap.EMP_ID = Convert.ToInt32(txtEmpID.Text);
            //        processadd.RISUserorgmap.ACCESS_ORG_ID = new GBLEnvVariable().OrgID;
            //        processadd.RISUserorgmap.UNIT_ID = Convert.ToInt32(row["UNIT_ID"]);
            //        processadd.RISUserorgmap.CREATED_BY = new Common.Common.GBLEnvVariable().UserID;
            //        processadd.RISUserorgmap.ORG_ID = new GBLEnvVariable().OrgID;
            //        processadd.Invoke();
            //    }
            //    else if (row["UnitStatus"].ToString() == "N" && statuslist[k] == "Y")
            //    {
            //        ProcessDeleteRISUserorgmap processupdate = new ProcessDeleteRISUserorgmap();
            //        processupdate.RISUserorgmap.EMP_ID = Convert.ToInt32(txtEmpID.Text);
            //        processupdate.RISUserorgmap.UNIT_ID = Convert.ToInt32(row["UNIT_ID"]);
            //        processupdate.Invoke();
            //    }
            //    else if (row["UnitStatus"].ToString() == "N" && statuslist[k] == "N")
            //    {

            //    }
            //    ++k;
            //}

            #endregion

            DataTable dt = (DataTable)gridControl1.DataSource;
            //DataRow[] drs = dt.Select("UnitStatus='Y'");

            int k = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (row["UnitStatus"].ToString() == "Y" && statuslist[k] == "Y")
                {

                }
                else if (row["UnitStatus"].ToString() == "Y" && statuslist[k] == "N")
                {
                    ProcessAddRISUserorgmap processadd = new ProcessAddRISUserorgmap();
                    processadd.RIS_USERORGMAP.EMP_ID = Convert.ToInt32(txtEmpID.Text);
                    processadd.RIS_USERORGMAP.ACCESS_ORG_ID = new GBLEnvVariable().OrgID;
                    processadd.RIS_USERORGMAP.UNIT_ID = Convert.ToInt32(row["UNIT_ID"]);
                    processadd.RIS_USERORGMAP.CREATED_BY = new GBLEnvVariable().UserID;
                    processadd.RIS_USERORGMAP.ORG_ID = new GBLEnvVariable().OrgID;
                    processadd.Invoke();
                }
                else if (row["UnitStatus"].ToString() == "N" && statuslist[k] == "Y")
                {
                    ProcessDeleteRISUserorgmap processupdate = new ProcessDeleteRISUserorgmap();
                    processupdate.RIS_USERORGMAP.EMP_ID = Convert.ToInt32(txtEmpID.Text);
                    processupdate.RIS_USERORGMAP.UNIT_ID = Convert.ToInt32(row["UNIT_ID"]);
                    processupdate.Invoke();
                }
                else if (row["UnitStatus"].ToString() == "N" && statuslist[k] == "N")
                {

                }
                k++;
            }

            xtraTabControl1.SelectedTabPageIndex = 0;
            SetGridControl(startwith);

            mmb.ShowAlert("UID2002", 1);

            this.Close();
        }
        private void btnRoleSave_Click(object sender, EventArgs e)
        {
            if (txtUnitID.Text == "" || txtUnitName.Text == "" || txtUnitUID.Text == "")
            { //MessageBox.Show("กรุณาเลือก role ด้วย \r\n โดยการคลิกที่ ปุ่ม \"...\""); 
                mmb.ShowAlert("UID2007", 1); return;
            }

            #region oldCode

            //int k = 0;
            //DataTable dvv = (DataTable)gridControl1.DataSource;
            //DataTable dttt = dvv;

            //while (k < view1.RowCount)
            //{
            //    DataRow row = view1.GetDataRow(k);
            //    DataRow row1 = ((DataTable)gridControl1.DataSource).Rows[k];
            //    if (row["EmployeeSelect"].ToString() == "Y" && statuslist[k] == "Y")
            //    {

            //    }
            //    else if (row["EmployeeSelect"].ToString() == "Y" && statuslist[k] == "N")
            //    {

            //    }
            //    else if (row["EmployeeSelect"].ToString() == "N" && statuslist[k] == "Y")
            //    {
            //        ProcessDeleteRISUserorgmap processupdate = new ProcessDeleteRISUserorgmap();
            //        processupdate.RISUserorgmap.EMP_ID = Convert.ToInt32(row["EMP_ID"]);
            //        processupdate.RISUserorgmap.UNIT_ID = Convert.ToInt32(txtUnitID.Text);
            //        processupdate.Invoke();
            //    }
            //    else if (row["EmployeeSelect"].ToString() == "N" && statuslist[k] == "N")
            //    {

            //    }
            //    ++k;
            //}

            #endregion

            DataTable dt = (DataTable)gridControl1.DataSource;
            //DataRow[] drs = dt.Select("UnitStatus='Y'");

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
                    ProcessDeleteRISUserorgmap processupdate = new ProcessDeleteRISUserorgmap();
                    processupdate.RIS_USERORGMAP.EMP_ID = Convert.ToInt32(row["EMP_ID"]);
                    processupdate.RIS_USERORGMAP.UNIT_ID = Convert.ToInt32(txtUnitID.Text);
                    processupdate.Invoke();
                }
                else if (row["EmployeeSelect"].ToString() == "N" && statuslist[k] == "N")
                {

                }
                k++;
            }

            xtraTabControl1.SelectedTabPageIndex = 1;
            SetGridControl(startwith);

            mmb.ShowAlert("UID2002", 1);

            this.Close();
        }
        private void btnSearchEmployee_Click(object sender, EventArgs e)
        {
            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(btnSearchEmployee_Clicks);
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
        private void btnSearchEmployee_Clicks(object sender, ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtEmpID.Text = retValue[0];
            txtEmpUID.Text = retValue[1];
            txtEmpName.Text = retValue[2];

            startwith = 1;
            EMPID = int.Parse(txtEmpID.Text);
            SetGridControl(startwith);
        }
        private void btnSearchUnit_Click(object sender, EventArgs e)
        {
//            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
//            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(btnSearchUnit_Clicks);

//            string qry = @"
//                        select
//	                        UNIT_ID,
//	                        UNIT_UID,
//                            UNIT_NAME
//                        from
//	                        HR_UNIT
//                        where
//                            UNIT_ID like '%%' OR
//                            UNIT_UID like '%%' OR
//                            UNIT_NAME like '%%'";

//            string fields = "Unit ID, Unit UID, Unit Name";
//            string con = "";
//            lv.getData(qry, fields, con, "Select Unit Detail List");
//            lv.Show();

            ProcessGetHRUnit unit = new ProcessGetHRUnit();
            unit.Invoke();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(btnSearchUnit_Clicks);
            lv.AddColumn("UNIT_ID", "ID", false, true);
            lv.AddColumn("UNIT_UID", "Code", true, true);
            lv.AddColumn("UNIT_NAME", "Name", true, true);
            lv.Text = "Role Search";

            lv.Data = unit.Result.Tables[0].Copy();
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void btnSearchUnit_Clicks(object sender, ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtUnitID.Text = retValue[0];
            txtUnitUID.Text = retValue[1];
            txtUnitName.Text = retValue[2];

            startwith = 2;
            SetGridControl(startwith);
        }
    }
}