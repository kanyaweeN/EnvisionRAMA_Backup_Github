using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.Common.Common;
using RIS.BusinessLogic;
using RIS.Common.UtilityClass;
using RIS.Forms.GBLMessage;
namespace RIS.Forms.Order
{
    public enum CheckEvent
    {
        View,Add,Edit
    }
    public partial class frmDoctorMapping : Form
    {
        private CheckEvent Check = CheckEvent.View;
        private DBUtility dbu;
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        private DataTable dtt;
        private DataTable dttDoctor;
        private DataTable dttOrder;
        private BindingSource bs;
        private MyMessageBox msg = new MyMessageBox();

        public frmDoctorMapping(UUL.ControlFrame.Controls.TabControl clsCtl)
        {
            InitializeComponent();
            dbu = new DBUtility();
            this.CloseControl = clsCtl;
            initBinding();
            initControl();
            groupEmp.Visible = false;
            grdData.Visible = true;
        }
        private void frmDoctorMapping_Load(object sender, EventArgs e)
        {
            if (bs.Count > 0)
            {
                bs.MoveLast();
                bs.MoveFirst();
            }
        }

        private void bs_CurrentChanged(object sender, EventArgs e)
        {
            loadData();
            bindDataGrid();

        }

        #region Button Event.
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (textHospital.Text.Trim().Length > 0)
            {
                bindingNavigatorMoveFirstItem.Enabled = false;
                bindingNavigatorMoveLastItem.Enabled = false;
                bindingNavigatorMoveNextItem.Enabled = false;
                bindingNavigatorMovePreviousItem.Enabled = false;
                bindingNavigatorPositionItem.Enabled = false;
                btnSave.Visible = true;
                btnCancel.Visible = true;
                btnClose.Visible = false;
                btnEdit.Visible = false;
                btnAdd.Visible = false;
                groupDoctor.Enabled = true;
                btnHospital.Enabled = false;
                Check = CheckEvent.Edit;

                int id = Convert.ToInt32(textHospital.Tag.ToString());
                loadData(id);
                bindDataGrid();

            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string str = msg.ShowAlert("UID1019", new GBLEnvVariable().CurrentLanguageID);
            if (str == "2")
            {
                switch (Check)
                {
                    case CheckEvent.View:
                        break;
                    case CheckEvent.Add:
                        InsertData();                       
                        break;
                    case CheckEvent.Edit:
                        saveData();
                        break;
                    default:
                        break;
                }
                bindingNavigatorMoveFirstItem.Enabled = true;
                bindingNavigatorMoveLastItem.Enabled = true;
                bindingNavigatorMoveNextItem.Enabled = true;
                bindingNavigatorMovePreviousItem.Enabled = true;
                bindingNavigatorPositionItem.Enabled = true;
                btnSave.Visible = false;
                btnCancel.Visible = false;
                btnClose.Visible = true;
                btnEdit.Visible = true;
                btnAdd.Visible = true;
                groupDoctor.Enabled = false;
                btnHospital.Enabled = true;
                bs.MoveLast();
                bs.MoveFirst();
                groupEmp.Visible = false;
                grdData.Visible = true;
                Check = CheckEvent.View;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            bindingNavigatorMoveFirstItem.Enabled = true;
            bindingNavigatorMoveLastItem.Enabled = true;
            bindingNavigatorMoveNextItem.Enabled = true;
            bindingNavigatorMovePreviousItem.Enabled = true;
            bindingNavigatorPositionItem.Enabled = true;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            btnClose.Visible = true;
            btnEdit.Visible = true;
            btnAdd.Visible = true;
            groupDoctor.Enabled = false;
            btnHospital.Enabled = true;
            bs.MoveFirst();
            groupEmp.Visible = false;
            grdData.Visible = true;
            Check = CheckEvent.View;
            loadData();
            bindDataGrid();
        }
        private void btnHospital_Click(object sender, EventArgs e)
        {
            RIS.Forms.Admin.GBL_HOSPITAL frm = new RIS.Forms.Admin.GBL_HOSPITAL();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            frm.ShowDialog();
            initBinding();
            initControl();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            dbu.CloseFrom(CloseControl, this);
        }
        #endregion

        private void initBinding()
        {
            dtt = new DataTable();
            bs = new BindingSource();

            ProcessGetGBLHospital processHos = new ProcessGetGBLHospital();
            processHos.Invoke();
            dtt = processHos.Result.Tables[0].Copy();
            bs.DataSource = dtt;
            bs.CurrentChanged += new EventHandler(bs_CurrentChanged);
            bindingNavigator1.BindingSource = bs;

            loadDoctorData();

            textHospital.DataBindings.Clear();
            textHospital.Text = string.Empty;
            textHospital.DataBindings.Add("Tag", bs, "HOS_ID");
            textHospital.DataBindings.Add("Text", bs, "HOS_NAME");
        }
        private void initControl()
        {
            btnEdit.Enabled = bs.Count > 0 ? true : false;
            groupDoctor.Enabled = false;
            if (!btnEdit.Enabled)
            {
                loadData();
                bindDataGrid();
            }

        }
        private void loadDoctorData()
        {
            dttDoctor = new DataTable();
            ProcessGetHISDoctor process = new ProcessGetHISDoctor();
            process.Invoke();
            dttDoctor = process.Result.Tables[0].Copy();
            dttDoctor.Columns.Add("IS");
            foreach (DataRow dr in dttDoctor.Rows)
                dr["IS"] = "N";
            dttDoctor.AcceptChanges();
        }
        private void loadData()
        {
            int id;
            try
            {
                int.TryParse(textHospital.Tag.ToString(), out id);
            }
            catch
            {
                id = 0;
            }
            ProcessGetGBLHospital process = new ProcessGetGBLHospital();
            process.GBLHospital.HOS_ID = id;
            dttOrder = process.GetMappingHOS();
            grdData.DataSource = dttOrder;
        }
        private void loadData(int id)
        {
            loadDoctorData();
            ProcessGetGBLHospital process = new ProcessGetGBLHospital();
            process.GBLHospital.HOS_ID = id;
            DataTable dtt = process.GetMappingHOS();
            foreach (DataRow drSearch in dtt.Rows)
            {
                DataRow[] dr = dttDoctor.Select("EMP_ID=" + drSearch["EMP_ID"].ToString());
                if (dr.Length > 0)
                {
                    foreach (DataRow drUp in dr)
                        drUp["IS"] = "Y";
                }
            }
            dttDoctor.AcceptChanges();
            grdData.DataSource = dttDoctor;
        }
        private void bindDataGrid()
        {

            for (int i = 0; i < dttOrder.Columns.Count; i++)
                view1.Columns[i].Visible = false;

            view1.OptionsSelection.EnableAppearanceFocusedCell = false;
            view1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;

            view1.Columns["IS"].Visible = true;
            view1.Columns["IS"].Caption = string.Empty;
            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chk.ValueChecked = "Y";
            chk.ValueUnchecked = "N";
            chk.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chk.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chk.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chk.Click += new EventHandler(chk_Click);
            view1.Columns["IS"].ColumnEdit = chk;
            view1.Columns["IS"].ColVIndex = 1;
            view1.Columns["IS"].Width = 35;
            view1.Columns["SALUTATION"].Caption = string.Empty;
            view1.Columns["SALUTATION"].Visible = true;
            view1.Columns["SALUTATION"].ColVIndex = 2;
            view1.Columns["SALUTATION"].Width = 80;
            view1.Columns["SALUTATION"].OptionsColumn.ReadOnly = true;
            view1.Columns["RadioName"].Caption = "Full Name";
            view1.Columns["RadioName"].Visible = true;
            view1.Columns["RadioName"].Width = 400;
            view1.Columns["RadioName"].ColVIndex = 3;
            view1.Columns["RadioName"].OptionsColumn.ReadOnly = true;
        }
        private void chk_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
            DataTable dtt = (DataTable)grdData.DataSource;
            dtt.Rows[view1.FocusedRowHandle]["IS"] = chk.Checked ? "N" : "Y";
            grdData.DataSource = dtt;
        }
        private void saveData()
        {
            int hos_id = Convert.ToInt32(textHospital.Tag.ToString());
            //delete in map
            ProcessDeleteGBLHospital hos = new ProcessDeleteGBLHospital();
            hos.DeleteMapping(hos_id);
            //insert when is = 'Y'
            DataTable dtt = (DataTable)grdData.DataSource;
            foreach (DataRow dr in dtt.Rows)
                if (dr["IS"].ToString() == "Y")
                {
                    ProcessAddGBLHospital process = new ProcessAddGBLHospital();
                    process.GBLHospital.HOS_ID = hos_id;
                    process.GBLHospital.EMP_ID = Convert.ToInt32(dr["EMP_ID"].ToString());
                    process.GBLHospital.ORG_ID = new GBLEnvVariable().OrgID;
                    process.GBLHospital.CREATED_BY = new GBLEnvVariable().UserID;
                    process.Mapping();
                }
        }
        private void InsertData()
        {
            ProcessAddGBLEmployee processadd = new ProcessAddGBLEmployee();
            processadd.GBLEmployee = new RIS.Common.GBLEmployee();
            processadd.GBLEmployee.Salutation = txtSalutation.Text;
            processadd.GBLEmployee.Fname = txtFName.Text;
            processadd.GBLEmployee.Lname = txtLname.Text;
            processadd.GBLEmployee.Is_Active = "N";
            //processadd.GBLEmployee.Jobtitle_ID = null;
            processadd.GBLEmployee.Auth_Level_ID = 1;
            processadd.GBLEmployee.Org_ID = 1;
            processadd.GBLEmployee.Job_Type = "D";
            processadd.GBLEmployee.Is_Radiologist = "Y";
            processadd.GBLEmployee.Last_Modified_By = new GBLEnvVariable().UserID;
            processadd.GBLEmployee.Last_Modified_On = DateTime.Now;
            processadd.GBLEmployee.Created_By = processadd.GBLEmployee.Last_Modified_By;
            processadd.GBLEmployee.Created_On = DateTime.Now;

            processadd.Invoke();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (textHospital.Text.Trim().Length > 0)
            {
                bindingNavigatorMoveFirstItem.Enabled = false;
                bindingNavigatorMoveLastItem.Enabled = false;
                bindingNavigatorMoveNextItem.Enabled = false;
                bindingNavigatorMovePreviousItem.Enabled = false;
                bindingNavigatorPositionItem.Enabled = false;
                btnSave.Visible = true;
                btnCancel.Visible = true;
                btnClose.Visible = false;
                btnEdit.Visible = false;
                btnAdd.Visible = false;
                groupDoctor.Enabled = true;
                btnHospital.Enabled = false;
                groupEmp.Visible = true;
                grdData.Visible = false;
                Check = CheckEvent.Add;
                txtFName.Text = "";
                txtLname.Text = "";
                txtSalutation.Text = "";
                //int id = Convert.ToInt32(textHospital.Tag.ToString());
                //loadData(id);
                //bindDataGrid();

            }
        }
    }
}