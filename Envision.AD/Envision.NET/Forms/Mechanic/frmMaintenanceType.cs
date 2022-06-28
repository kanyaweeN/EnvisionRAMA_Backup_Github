using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Envision.NET.Forms.Dialog;
using Envision.Common;
using Envision.NET.Forms.Main;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic;
using Envision.BusinessLogic.Delete;
using Envision.BusinessLogic.Update;

namespace Envision.NET.Forms.Mechanic
{
    public partial class frmMaintenanceType : MasterForm//Form
    {
        DataTable dtMTNType;
        DataView dvMTNType;

        DataRow drMTNType;

        MyMessageBox msg = new MyMessageBox();
        GBLEnvVariable env = new GBLEnvVariable();

        //UUL.ControlFrame.Controls.TabControl tab;
        public frmMaintenanceType()//(UUL.ControlFrame.Controls.TabControl clsCtl)
        {
            InitializeComponent();
            //tab = clsCtl;

            btnAdd.Visible = true;
            btnEdit.Visible = true;
            btnDelete.Visible = true;
            btnClose.Visible = true;

            btnCancel.Visible = false;

            ReloadMTN();

            Control_Enabled(false);

        }
        public void frmMaintenanceType_Load(object sender, System.EventArgs e)
        {
            base.CloseWaitDialog();
        }

        private void LoadMTNData()
        {
            ProcessGetRISModalitymaintenancetype GetData = new ProcessGetRISModalitymaintenancetype();
            GetData.Invoke();
            DataTable table = GetData.Result.Tables[0];

            dtMTNType = table;
            dvMTNType = new DataView(table);
        }
        private void LoadMTNFilter()
        { 
            
        }
        private void LoadMTNGrid()
        {
            gridControl1.DataSource = dtMTNType;

            int k = 0;
            while (k < gridView1.Columns.Count)
            {
                gridView1.Columns[k].Visible = false;
                gridView1.Columns[k].OptionsColumn.AllowEdit = false;
                ++k;
            }

            gridView1.Columns["MTN_TYPE_UID"].ColVIndex = 1;
            gridView1.Columns["MTN_TYPE_UID"].Caption = "Type Code";

            gridView1.Columns["MTN_TYPE_DESC"].ColVIndex = 2;
            gridView1.Columns["MTN_TYPE_DESC"].Caption = "Type Desc.";

            gridView1.BestFitColumns();
        }
        private void ReloadMTN()
        {
            LoadMTNData();
            LoadMTNFilter();
            LoadMTNGrid();

            LoadDataRow();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Add")
            {
                Control_Enabled(true);
                Control_ClearText();

                btnAdd.Visible = true;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                btnClose.Visible = true;

                btnCancel.Visible = true;

                btnAdd.Text = "Save";
            }
            else
            {
                string ret = msg.ShowAlert("UID1019", env.CurrentLanguageID);
                if (ret.ToString() == "2")
                {
                    try
                    {
                        ProcessAddRISModalitymaintenanceType add = new ProcessAddRISModalitymaintenanceType();
                        add.RIS_MODALITYMAINTENANCETYPE.MTN_TYPE_UID = txtMTNUID.Text;
                        add.RIS_MODALITYMAINTENANCETYPE.MTN_TYPE_DESC = txtMTNDesc.Text;
                        add.RIS_MODALITYMAINTENANCETYPE.ORG_ID = env.OrgID;
                        add.RIS_MODALITYMAINTENANCETYPE.CREATED_BY = env.UserID;
                        add.RIS_MODALITYMAINTENANCETYPE.CREATED_ON = DateTime.Now;
                        add.Invoke();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    btnAdd.Visible = true;
                    btnEdit.Visible = true;
                    btnDelete.Visible = true;
                    btnClose.Visible = true;

                    btnCancel.Visible = false;

                    btnAdd.Text = "Add";

                    int rowCount = gridView1.RowCount;
                    ReloadMTN();
                    gridView1.FocusedRowHandle = rowCount;

                    Control_Enabled(false);
                }
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "Edit")
            {
                if (gridView1.RowCount == 0) return;

                Control_Enabled(true);

                btnAdd.Visible = false;
                btnEdit.Visible = true;
                btnDelete.Visible = false;
                btnClose.Visible = true;

                btnCancel.Visible = true;

                btnEdit.Text = "Save";
            }
            else
            {

                string ret = msg.ShowAlert("UID1019", env.CurrentLanguageID);
                if (ret.ToString() == "2")
                {
                    try
                    {
                        ProcessUpdateRISModalitymaintenancetype update = new ProcessUpdateRISModalitymaintenancetype();
                        update.RIS_MODALITYMAINTENANCETYPE.MTN_TYPE_ID = Convert.ToInt32(drMTNType["MTN_TYPE_ID"]);
                        update.RIS_MODALITYMAINTENANCETYPE.MTN_TYPE_UID = txtMTNUID.Text;
                        update.RIS_MODALITYMAINTENANCETYPE.MTN_TYPE_DESC = txtMTNDesc.Text;
                        update.RIS_MODALITYMAINTENANCETYPE.ORG_ID = env.OrgID;
                        update.RIS_MODALITYMAINTENANCETYPE.LAST_MODIFIED_BY = env.UserID;
                        update.RIS_MODALITYMAINTENANCETYPE.LAST_MODIFIED_ON = DateTime.Now;
                        update.Invoke();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    btnAdd.Visible = true;
                    btnEdit.Visible = true;
                    btnDelete.Visible = true;
                    btnClose.Visible = true;

                    btnCancel.Visible = false;

                    btnEdit.Text = "Edit";

                    int foRow = gridView1.FocusedRowHandle;
                    ReloadMTN();
                    gridView1.FocusedRowHandle = foRow;

                    Control_Enabled(false);
                }
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0) return;
            
            string ret = msg.ShowAlert("UID1025", env.CurrentLanguageID);
            if (ret.ToString() == "2")
            {
                try
                {
                    ProcessDeleteRISModalitymaintenancetype delete = new ProcessDeleteRISModalitymaintenancetype();
                    delete.RIS_MODALITYMAINTENANCETYPE.MTN_TYPE_ID = Convert.ToInt32(drMTNType["MTN_TYPE_ID"]);
                    delete.Invoke();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //btnAdd.Visible = true;
                //btnEdit.Visible = true;
                //btnDelete.Visible = true;
                //btnClose.Visible = true;

                //btnCancel.Visible = false;

                int foRow = gridView1.FocusedRowHandle;
                ReloadMTN();
                gridView1.FocusedRowHandle = foRow-1;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Control_ClearText();

            btnAdd.Visible = true;
            btnEdit.Visible = true;
            btnDelete.Visible = true;
            btnClose.Visible = true;

            btnAdd.Text = "Add";
            btnEdit.Text = "Edit";
            btnDelete.Text = "Delete";

            btnCancel.Visible = false;
            ReloadMTN();

            Control_Enabled(false);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            //int index = tab.SelectedIndex;
            //tab.TabPages.RemoveAt(index);
            this.Close();
        }

        private void Control_ClearText()
        {
            txtMTNUID.Text = "";
            txtMTNDesc.Text = "";
        }
        private void Control_Enabled(bool enable)
        {
            txtMTNUID.Enabled = enable;
            txtMTNDesc.Enabled = enable;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.FocusedRowHandle > -1)
            {
                LoadDataRow();
            }
        }
        private void LoadDataRow()
        {
            int foIndex = gridView1.FocusedRowHandle;
            if (foIndex < 0) return;
            drMTNType = gridView1.GetDataRow(foIndex);

            txtMTNUID.Text = drMTNType["MTN_TYPE_UID"].ToString();
            txtMTNDesc.Text = drMTNType["MTN_TYPE_DESC"].ToString();
        }
    }
}
